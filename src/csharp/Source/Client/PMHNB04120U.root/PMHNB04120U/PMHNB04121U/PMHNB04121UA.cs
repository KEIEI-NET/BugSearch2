//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : 得意先過年度実績照会
// プログラム概要   : 得意先過年度実績照会の検索、表示
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30418 徳永
// 作 成 日  2008/11/18  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 上野 俊治
// 修 正 日  2009/02/26  修正内容 : 障害対応11994 会計年度の取得処理を修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 忍 幸史
// 修 正 日  2009/03/09  修正内容 : 障害対応11994 会計年度の取得処理を修正
//                                : 当年度の概念等、根本的に仕様が変更されたため対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 忍 幸史
// 修 正 日  2009/03/12  修正内容 : 障害対応12304
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30413 犬飼
// 修 正 日  2009/05/25  修正内容 : 障害対応13330
//----------------------------------------------------------------------------//
// 管理番号  10600008-00 作成担当 : 李占川
// 修 正 日  2010/06/28  修正内容 : テキスト出力対応
//----------------------------------------------------------------------------//
// 管理番号  10600008-00 作成担当 : 姜凱  
// 修 正 日  2010/07/20  修正内容 : Excel、テキスト出力対応（６次改良追加依頼分）
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : chenyd  
// 修 正 日  2010/08/12  修正内容 : 障害対応13026
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : tianjw  
// 修 正 日  2010/09/09  修正内容 : redmine #14434対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : tianjw  
// 修 正 日  2010/09/13  修正内容 : テキスト出力対応　不具合対応#14643
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : tianjw  
// 修 正 日  2010/09/21  修正内容 : テキスト出力対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : yangmj    
// 修 正 日  2010/10/09  修正内容 : テキスト出力対応 不具合対応#15879
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : liyp    
// 修 正 日  2011/02/16  修正内容 : テキスト出力対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 陳艶丹
// 修 正 日  2024/11/22  修正内容 : PMKOBETSU-4368 2024年PKG格上のログ出力対応
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Collections;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Application.Remoting.ParamData;//ADD 2024/11/22 陳艶丹 PMKOBETSU-4368 2024年PKG格上のログ出力対応
using Broadleaf.Application.Resources;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Library.Windows.Forms;
//using Broadleaf.Application.Common;       // DEL 2009/05/25
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Windows.Forms;
using Broadleaf.Library.Globarization;
using Broadleaf.Application.Controller.Facade;
using Infragistics.Excel;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 得意先過年度実績照会
    /// </summary>
    ///<remarks>
    /// <br>Note        : 得意先過年度実績照会UIフォームクラス</br>
    /// <br>Programmer  : 30418 徳永</br>
    /// <br>Date        : 2008/11/18</br>
    /// <br>Update Note : 2009/02/26 30452 上野 俊治</br>
    /// <br>             ・障害対応11994 会計年度の取得処理を修正</br>
    /// <br>Update Note : 2009/03/09 30414 忍 幸史</br>
    /// <br>             ・障害対応11994 会計年度の取得処理を修正</br>
    /// <br>             　当年度の概念等、根本的に仕様が変更されたため対応</br>
    /// <br>Update Note : 2009/03/12 30414 忍 幸史</br>
    /// <br>             ・障害対応12304</br>
    /// <br>Update Note : 2010/06/28 李占川</br>
    /// <br>             ・テキスト出力対応</br>
    /// <br>UpdateNote  : 2010/07/20 姜凱</br>
    /// <br>             ・Excel、テキスト出力対応（６次改良追加依頼分）</br>
    /// <br>UpdateNote  : 2010/08/12 chenyd</br>
    /// <br>             ・障害対応13026</br>
    /// <br>UpdateNote  : 2010/08/23 chenyd</br>
    /// <br>             ・障害対応13482</br>
    /// <br>UpdateNote  : 2010/09/13 tianjw</br>
    /// <br>             ・テキスト出力対応　不具合対応#14643</br>
    /// <br>UpdateNote  : 2010/09/21 tianjw</br>
    /// <br>             ・テキスト出力対応　不具合対応#14876</br>
    /// <br>Update Note: 2010/10/09 yangmj</br>
    /// <br>            ・テキスト出力対応 不具合対応#15879</br> 
    /// <br>Update Note: 2011/02/16 liyp</br>
    /// <br>            ・テキスト出力対応</br> 
    /// <br>Update Note :2024/11/22 陳艶丹</br>
    /// <br>            ・PMKOBETSU-4368 2024年PKG格上のログ出力対応</br>
    /// </remarks>
    public partial class PMHNB04121UA : Form
    {

        #region プライベート変数

        #region ローカルクラス

        /// <summary>得意先過年度実績照会抽出条件クラス</summary>
        CustomInqOrderCndtn _customInqOrderCndtn = null;

        /// <summary>得意先過年度実績照会アクセスクラス</summary>
        CustPastExperienceAcs _custPastExperienceAcs = null;

        #endregion // ローカルクラス

        #region クラス

        /// <summary>拠点アクセスクラス</summary>
        private SecInfoAcs _secInfoAcs;

        /// <summary>拠点アクセスクラス</summary>
        private SecInfoSetAcs _secInfoSetAcs;

        /// <summary>拠点情報データクラス</summary>
        private SecInfoSet _sectionInfo;

        /// <summary>得意先検索アクセスクラス</summary>
        private CustomerInfoAcs _customerInfoAcs;

        /// <summary>得意先情報データクラス</summary>
        private CustomerInfo _customerInfo;

        /// <summary>自社情報アクセスクラス</summary>
        private DateGetAcs _dateGetAcs = null;

        /// <summary>UIスキン設定コントロール</summary>
        private ControlScreenSkin _controlScreenSkin = null;

        // --- ADD 2009/03/09 障害ID:11994対応------------------------------------------------------>>>>>
        /// <summary>締日算出モジュール</summary>
        private TotalDayCalculator _totalDayCalculator = null;
        // --- ADD 2009/03/09 障害ID:11994対応------------------------------------------------------<<<<<

        //--- ADD 2024/11/22 陳艶丹 PMKOBETSU-4368 2024年PKG格上のログ出力対応 ---->>>>>
        private TextOutPutOprtnHisLogAcs TextOutPutOprtnHisLogAcsObj = null;
        //--- ADD 2024/11/22 陳艶丹 PMKOBETSU-4368 2024年PKG格上のログ出力対応 ----<<<<<
        #endregion // クラス

        #region データセット

        /// <summary>得意先過年度実績照会情報データセット</summary>
        CustomInqOrderDataSet _dataSet = null;

        #endregion // データセット

        #region コード類

        /// <summary>企業コード</summary>
        private string _enterpriseCode = string.Empty;

        /// <summary>自拠点コード</summary>
        private string _loginSectionCode = string.Empty;

        /// <summary>ログインユーザーコード</summary>
        private string _loginUserCd = string.Empty;

        /// <summary>ログインユーザー名</summary>
        private string _loginUserName = string.Empty;

        /// <summary>拠点コード</summary>
        private string _sectionCode = string.Empty;

        /// <summary>得意先コード</summary>
        private int _customerCd = 0;

        /// <summary>ボタン用イメージリスト</summary>
        private ImageList _imageList16 = null;

        #endregion // コード類

        #region 会計年度関連

        /// <summary>自社設定取得アクセスクラス</summary>
        private CompanyInfAcs _companyInfAcs;

        // --- DEL 2009/03/09 障害ID:11994対応------------------------------------------------------>>>>>
        ///// <summary>年月</summary>
        //private DateTime _yearMonth;
        // --- DEL 2009/03/09 障害ID:11994対応------------------------------------------------------<<<<<

        /// <summary>会計年度</summary>
        private int _fiscalYear = 0;

        // --- DEL 2009/03/09 障害ID:11994対応------------------------------------------------------>>>>>
        ///// <summary>年月度開始日</summary>
        //private DateTime _fYearStartMonthDate;

        ///// <summary>年月度終了日</summary>
        //private DateTime _fYearEndMonthDate;

        ///// <summary>年度開始日</summary>
        //private DateTime _fYearStartYearDate;

        ///// <summary>年度終了日</summary>
        //private DateTime _fYearEndYearDate;
        // --- DEL 2009/03/09 障害ID:11994対応------------------------------------------------------<<<<<

        // ---------------------- ADD 2010/07/20 --------------------------------->>>>>
        private PMHNB04121UB _userSetupFrm = null;              // ユーザー設定画面 
        private PMHNB04121UC _extractSetupFrm = null;           // 出力条件設定画面 
        private bool isSearch = false;                          // 検索ボタンをクリックするかどうか
        private int _opt_TextOutput;                            // テキスト出力オプション情報
        // ---------------------- ADD 2010/07/20 -----------------------------------<<<<<
        private bool isError = false; // ADD 2010/09/21

        private DataView _dViewBak = null; // ADD 2010/09/21

        #endregion // 会計年度関連

        #endregion // プライベート変数
        #region
        // ---------------------- ADD 2010/07/20 --------------------------------->>>>>
        private Infragistics.Win.UltraWinToolbars.ButtonTool _setupButton;					// 設定ボタン
        private Infragistics.Win.UltraWinToolbars.ButtonTool _textButton;                   // テキスト出力ボタン
        private Infragistics.Win.UltraWinToolbars.ButtonTool _excelButton;                  // Excel出力ボタン
        // ---------------------- ADD 2010/07/20 -----------------------------------<<<<<
        #endregion
        #region 定数

        /// <summary>全社コード名称：初期値「全社」</summary>
        private const string CT_NAME_ALLSECCODE = "全社";

        /// <summary>エラーメッセージ：「会計年度開始日が取得されていません。」</summary>
        private const string CT_FISCAL_START_DATE_NOT_QUALIFIED = "会計年度開始日が取得されていません。";

        /// <summary>エラーメッセージ：「会計年度終了日が取得されていません。」</summary>
        private const string CT_FISCAL_END_DATE_NOT_QUALIFIED = "会計年度終了日が取得されていません。";

        /// <summary>エラーメッセージ：「企業コードが取得されていません。」</summary>
        private const string CT_ENTERPRISE_CODE_NOT_QUALIFIED = "企業コードが取得されていません。";

        // 2008.12.09 modify start [8891]
        /// <summary>エラーメッセージ：「得意先コードが入力されていません。」</summary>
        private const string CT_CUSTOMER_CODE_NOT_QUALIFIED = "得意先コードが入力されていません。";

        /// <summary>エラーメッセージ：「入力された拠点コードは使用できません。」</summary>
        private const string CT_INVALID_SECTION = "入力された拠点コードは使用できません。";

        /// <summary>エラーメッセージ：「入力されたコードに該当する得意先がありません。」</summary>
        private const string CT_INVALID_CUSTOMER = "入力されたコードに該当する得意先がありません。";

        //--- ADD 2024/11/22 陳艶丹 PMKOBETSU-4368 2024年PKG格上のログ出力対応 ---->>>>>
        // メソッド名
        private const string MethodNm = "outputTextData";
        private const string MethodNm2 = "outputExcelData";
        // 出力件数
        private const string CountNumStr = "データ出力件数:{0},";
        /// <summary>得意先過年度実績照会PGID</summary>
        private const string CUSTOM_INQ_RESULT_PGID = "PMHNB04121U";
        // アセンブリ名
        private const string AssemblyNm = "得意先過年度実績照会";
        // テキストとExcel出力条件
        private const string Con = "拠点:{0} ～ {1},得意先:{2} ～ {3},出力ファイル名:{4}";
        // 最初から
        private const string StartStr = "最初から";
        // 最後まで
        private const string EndStr = "最後まで";
        //--- ADD 2024/11/22 陳艶丹 PMKOBETSU-4368 2024年PKG格上のログ出力対応 ----<<<<<

        #endregion // 定数
        // 2010/07/20 Add >>>
        #region
        private IOperationAuthority _operationAuthority;    // 操作権限の制御オブジェクト
        private Dictionary<OperationCode, bool> _operationAuthorityList;  // 操作権限の制御リスト
        #endregion
        // 2010/07/20 Add <<<
        #region ■列挙体

        // 2010/02/22 Add >>>
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

        #region プロパティ

        /// <summary>操作権限の制御オブジェクト</summary>
        private IOperationAuthority MyOpeCtrl
        {
            get
            {
                if (_operationAuthority == null)
                {
                    _operationAuthority = OpeAuthCtrlFacade.CreateReferenceOperationAuthority("MHNB04120U", this);
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
        // 2010/07/20 Add <<<

        #endregion
        #region コンストラクタ

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Update Note: 2024/11/22 陳艶丹</br>
        /// <br>管理番号   : 12070203-00</br>
        /// <br>           : PMKOBETSU-4368 2024年PKG格上のログ出力対応</br>
        /// </remarks>
        public PMHNB04121UA()
        {
            InitializeComponent();

            InitializeVariable();

            // -----ADD 2010/07/20 ---------------------->>>>>
            // テキスト出力オプションの制御　
            this.CacheOptionInfo();
            // -----ADD 2010/07/20 ----------------------<<<<<
            //--- ADD 2024/11/22 陳艶丹 PMKOBETSU-4368 2024年PKG格上のログ出力対応---->>>>>
            TextOutPutOprtnHisLogAcsObj = new TextOutPutOprtnHisLogAcs();//テキスト出力操作ログおよび出力時アラートメッセージ表示処理の対象
            //--- ADD 2024/11/22 陳艶丹 PMKOBETSU-4368 2024年PKG格上のログ出力対応----<<<<<
        }

        /// <summary>
        /// フォーム表示後イベント（初期フォーカス関連）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PMHNB04121UA_Shown(object sender, System.EventArgs e)
        {
            // 初期フォーカス
            this.tEdit_SectionCodeAllowZero.Focus();
        }

        #endregion // コンストラクタ

        #region 配色

        /// <summary>グリッド カラー1</summary>
        private readonly Color _rowFiscalColBackColor1 = Color.FromArgb(89, 135, 214);
        /// <summary>グリッド カラー2</summary>
        private readonly Color _rowFiscalColBackColor2 = Color.FromArgb(7, 59, 150);
        /// <summary>グリッド 文字色1</summary>
        private readonly Color _rowFiscalColForeColor1 = Color.FromArgb(255, 255, 255);

        /// <summary>グリッド ヘッダーカラー1</summary>
        private readonly Color _headerBackColor1 = Color.FromArgb(89, 135, 214);
        /// <summary>グリッド ヘッダーカラー2</summary>
        private readonly Color _headerBackColor2 = Color.FromArgb(7, 59, 150);
        /// <summary>グリッド 文字色1</summary>
        private readonly Color _headerForeColor1 = Color.FromArgb(255, 255, 255);



        #endregion // 配色

        #region プライベート関数

        /// <summary>
        /// コントロール類初期配置
        /// </summary>
        private void InitializeVariable()
        {

            // UIスキン設定コントロール
            this._controlScreenSkin = new ControlScreenSkin();

            #region アクセスクラス初期化

            this._secInfoAcs = new SecInfoAcs();
            this._secInfoSetAcs = new SecInfoSetAcs();          // 拠点
            this._customerInfoAcs = new CustomerInfoAcs();      // 得意先
            this._dateGetAcs = DateGetAcs.GetInstance();        // 会計年度取得
            this._companyInfAcs = new CompanyInfAcs();          // 自社設定
            // --- ADD 2009/03/09 障害ID:11994対応------------------------------------------------------>>>>>
            this._totalDayCalculator = TotalDayCalculator.GetInstance();    // 締日算出モジュール
            // --- ADD 2009/03/09 障害ID:11994対応------------------------------------------------------<<<<<

            #endregion // アクセスクラス初期化

            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;                 // 企業コード
            this._loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;   // 自拠点コード
            this._loginUserCd = LoginInfoAcquisition.Employee.EmployeeCode;             // ログインユーザーコード
            this._loginUserName = LoginInfoAcquisition.Employee.Name;                   // ログインユーザー名

            #region ボタンイメージ設定

            // イメージリストを指定(16x16)
            this._imageList16 = IconResourceManagement.ImageList16;

            // ボタンイメージを設定
            this.uButton_SectionGuide.ImageList = this._imageList16;
            this.uButton_SectionGuide.Appearance.Image = (int)Size16_Index.STAR1;

            this.uButton_CustomerGuide.ImageList = this._imageList16;
            this.uButton_CustomerGuide.Appearance.Image = (int)Size16_Index.STAR1;

            // ツールバーアイコン
            this.tToolbarsManager_MainMenu.ImageListSmall = this._imageList16;
            this.tToolbarsManager_MainMenu.Tools["ButtonTool_Close"].SharedProps.AppearancesSmall.Appearance.Image = (int)Size16_Index.CLOSE;
            // --- CHG 2009/03/12 障害ID:12304対応------------------------------------------------------>>>>>
            //this.tToolbarsManager_MainMenu.Tools["ButtonTool_Decision"].SharedProps.AppearancesSmall.Appearance.Image = (int)Size16_Index.DECISION;
            this.tToolbarsManager_MainMenu.Tools["ButtonTool_Decision"].SharedProps.AppearancesSmall.Appearance.Image = (int)Size16_Index.SEARCH;
            // --- CHG 2009/03/12 障害ID:12304対応------------------------------------------------------<<<<<
            this.tToolbarsManager_MainMenu.Tools["ButtonTool_Clear"].SharedProps.AppearancesSmall.Appearance.Image = (int)Size16_Index.ALLCANCEL;

            // --- ADD 2010/06/28 ---------->>>>>
            this.tToolbarsManager_MainMenu.Tools["ButtonTool_TextOutput"].SharedProps.AppearancesSmall.Appearance.Image = (int)Size16_Index.CSVOUTPUT;
            this.tToolbarsManager_MainMenu.Tools["ButtonTool_ExcelOutput"].SharedProps.AppearancesSmall.Appearance.Image = (int)Size16_Index.CSVOUTPUT;
            this.tToolbarsManager_MainMenu.Tools["ButtonTool_Setup"].SharedProps.AppearancesSmall.Appearance.Image = (int)Size16_Index.SETUP1;
            // --- ADD 2010/06/28 ----------<<<<<
            // ---------------------- ADD 2010/07/20 --------------------------------->>>>>
            this._setupButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Setup"];
            this._textButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_TextOutput"];
            this._excelButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_ExcelOutput"];
            // ---------------------- ADD 2010/07/20 -----------------------------------<<<<<
            #endregion // ボタンイメージ設定

            #region 検索条件クラス作成

            this._customInqOrderCndtn = new CustomInqOrderCndtn();

            #endregion // 検索条件クラス作成

            #region コントロールスキン対応

            List<string> controlNameList = new List<string>();
            controlNameList.Add(this.uExpandableGroupBox_Condition.Name);
            this._controlScreenSkin.SetExceptionCtrl(controlNameList);
            this._controlScreenSkin.LoadSkin();
            this._controlScreenSkin.SettingScreenSkin(this);

            #endregion // コントロールスキン対応

            // --- DEL 2009/03/09 障害ID:11994対応------------------------------------------------------>>>>>
            //#region 会計年度取得(自社情報マスタ)

            //// 自社情報読み込み(会計年度を取得)
            //CompanyInf companyInf;
            //int status = this._companyInfAcs.Read(out companyInf, this._enterpriseCode);
            //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            //{
            //    this._fiscalYear = companyInf.FinancialYear;
            //}

            //// 自社情報より会計年度開始日、終了日を取得
            //// --- DEL 2009/02/26 -------------------------------->>>>>
            ////int year = 0;
            ////_dateGetAcs.GetThisYearMonth(out this._yearMonth,               // *使用しません*
            ////                            out year,                           // *使用しません*
            ////                            out this._fYearStartMonthDate,      // *使用しません*
            ////                            out this._fYearEndMonthDate,        // *使用しません*
            ////                            out this._fYearStartYearDate,       // 会計年度開始日
            ////                            out this._fYearEndYearDate);        // 会計年度終了日
            //// --- DEL 2009/02/26 --------------------------------<<<<<
            //// --- ADD 2009/02/26 -------------------------------->>>>>
            //List<DateTime> startMonthDateList;
            //List<DateTime> endMonthDateList;
            //List<DateTime> yearMonth;
            //_dateGetAcs.GetFinancialYearTable(out startMonthDateList, out endMonthDateList, out yearMonth);

            //this._fYearStartYearDate = startMonthDateList[0]; // 会計年度開始日
            //this._fYearEndYearDate = endMonthDateList[11]; // 会計年度終了日
            //// --- ADD 2009/02/26 -------------------------------->>>>>

            //#endregion // 会計年度取得(自社情報マスタ)
            // --- DEL 2009/03/09 障害ID:11994対応------------------------------------------------------<<<<<

            #region グリッド設定

            // アクセスクラスを初期化し、データセットを取得
            this._custPastExperienceAcs = new CustPastExperienceAcs();
            this._dataSet = this._custPastExperienceAcs.DataSet;

            // グリッドで表示に使用するデータビューを作成
            DataView dView = new DataView(this._dataSet.CustomInqResult);

            // データソースとしてデータビューを指定
            this.uGrid_Details.DataSource = dView;

            // グリッド列を設定
            InitializeGridColumns(this.uGrid_Details.DisplayLayout.Bands[0].Columns);

            #endregion // グリッド設定

            // 画面クリア
            InitializeScreen();

        }

        #region 拠点名称取得

        /// <summary>
        /// 拠点名称取得処理
        /// </summary>
        /// <param name="sectionCd">検索する拠点コード</param>
        /// <returns>拠点名</returns>
        /// <br>Update Note : 2010/09/21 tianjw</br>
        /// <br>              Redmine#14876 テキスト出力対応</br>
        private string GetSectionName(string sectionCd)
        {
            int status = this._secInfoSetAcs.Read(out _sectionInfo, this._enterpriseCode, sectionCd);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                isError = false; // ADD 2010/09/21
                // 2008.12.02 add start []
                if (_sectionInfo.LogicalDeleteCode == 0)
                {
                    isError = false; // ADD 2010/09/21
                    return _sectionInfo.SectionGuideNm;
                }
                else
                {
                    TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, "PMHNB04120U",
                        CT_INVALID_SECTION, 0, MessageBoxButtons.OK);
                    this.tEdit_SectionCodeAllowZero.Clear();
                    isError = true; // ADD 2010/09/21
                    return string.Empty;
                }
            }
            else
            {
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, "PMHNB04120U",
                    CT_INVALID_SECTION, 0, MessageBoxButtons.OK);
                this.tEdit_SectionCodeAllowZero.Clear();
                isError = true; // ADD 2010/09/21
                // 2008.12.02 add end []
                return string.Empty;
            }
        }

        #endregion // 拠点名称取得

        #region 得意先名取得

        /// <summary>
        /// 得意先名取得処理
        /// </summary>
        /// <returns></returns>
        /// <br>Update Note : 2010/09/21 tianjw</br>
        /// <br>              Redmine#14876 テキスト出力対応</br>
        private string GetCustomerName(int customerCd)
        {
            int status = this._customerInfoAcs.ReadDBData(this._enterpriseCode, customerCd, out _customerInfo);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                isError = false; // ADD 2010/09/21
                //if (_customerInfo == null || String.IsNullOrEmpty(_customerInfo.CustomerSnm.Trim())) //DEL 2010/07/20 
                if (_customerInfo == null)                                                             //ADD 2010/07/20 
                {
                    TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, "PMHNB04120U",
                        CT_INVALID_CUSTOMER, 0, MessageBoxButtons.OK);
                    this.tNedit_CustomerCode.Clear();
                    isError = true; // ADD 2010/09/21
                    this.tNedit_CustomerCode.Focus(); // ADD 2010/09/21
                    return string.Empty;
                }
                else
                {
                    isError = false; // ADD 2010/09/21
                    return _customerInfo.CustomerSnm.Trim(); 
                }
            }
            else
            {
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, "PMHNB04120U",
                    CT_INVALID_CUSTOMER, 0, MessageBoxButtons.OK);
                this.tNedit_CustomerCode.Clear();
                isError = true; // ADD 2010/09/21
                this.tNedit_CustomerCode.Focus(); // ADD 2010/09/21
                return string.Empty;
            }
        }

        #endregion // 得意先名取得

        #region 画面の初期化

        /// <summary>
        /// 画面の初期化
        /// </summary>
        /// <br>Update Note: 2010/09/21 tianjw</br>
        /// <br>            ・テキスト出力対応</br>
        private void InitializeScreen()
        {
            this.tEdit_SectionCodeAllowZero.Clear();
            this.tEdit_SectionName.Clear();
            this.tNedit_CustomerCode.Clear();
            this.tEdit_CustomerName.Clear();

            // データセットもクリア
            this._dataSet.CustomInqResult.Clear();

            // ログインユーザー名表示
            this.tToolbarsManager_MainMenu.Tools["LabelTool_LoginChargeName"].SharedProps.Caption = this._loginUserName;

            // フォーカスを拠点に
            this.tEdit_SectionCodeAllowZero.Focus();

            // ----------- ADD 2010/09/21 ---------------------------------->>>>>
            // グリッドで表示に使用するデータビューを作成
            DataView dataView = new DataView(this._dataSet.CustomInqResult);

            // データソースとしてデータビューを指定
            this.uGrid_Details.DataSource = dataView;

            this._dViewBak = dataView;
            // ----------- ADD 2010/09/21 ----------------------------------<<<<<
        }

        #endregion // 画面の初期化

        #region グリッド列初期化

        /// <summary>
        /// グリッド列の初期化
        /// </summary>
        /// <param name="Columns"></param>
        private void InitializeGridColumns(Infragistics.Win.UltraWinGrid.ColumnsCollection Columns)
        {
            // 表示形式のある列で使用
            string formatCurrency = "#,##0;-#,##0;";

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
            }

            //--------------------------------------------------------------------------------
            //  表示するカラム情報
            //--------------------------------------------------------------------------------

            // 年度
            Columns[this._dataSet.CustomInqResult.FiscalYearStringColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.CustomInqResult.FiscalYearStringColumn.ColumnName].Width = 130;
            Columns[this._dataSet.CustomInqResult.FiscalYearStringColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            Columns[this._dataSet.CustomInqResult.FiscalYearStringColumn.ColumnName].Header.Caption = "";
            Columns[this._dataSet.CustomInqResult.FiscalYearStringColumn.ColumnName].Header.Appearance.BackColor = _headerBackColor1;
            Columns[this._dataSet.CustomInqResult.FiscalYearStringColumn.ColumnName].Header.Appearance.BackColor2 = _headerBackColor2;
            Columns[this._dataSet.CustomInqResult.FiscalYearStringColumn.ColumnName].Header.Appearance.ForeColor = _headerForeColor1;
            Columns[this._dataSet.CustomInqResult.FiscalYearStringColumn.ColumnName].Header.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            Columns[this._dataSet.CustomInqResult.FiscalYearStringColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
            Columns[this._dataSet.CustomInqResult.FiscalYearStringColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.CustomInqResult.FiscalYearStringColumn.ColumnName].CellAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
            Columns[this._dataSet.CustomInqResult.FiscalYearStringColumn.ColumnName].CellAppearance.ForeColor = _rowFiscalColForeColor1;
            Columns[this._dataSet.CustomInqResult.FiscalYearStringColumn.ColumnName].CellAppearance.BackColor = _rowFiscalColBackColor1;
            Columns[this._dataSet.CustomInqResult.FiscalYearStringColumn.ColumnName].CellAppearance.BackColor2 = _rowFiscalColBackColor2;
            Columns[this._dataSet.CustomInqResult.FiscalYearStringColumn.ColumnName].CellAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;

            // 純売上
            Columns[this._dataSet.CustomInqResult.NetSalesColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.CustomInqResult.NetSalesColumn.ColumnName].Width = 250;
            Columns[this._dataSet.CustomInqResult.NetSalesColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[this._dataSet.CustomInqResult.NetSalesColumn.ColumnName].Header.Caption = "純　売　上";
            Columns[this._dataSet.CustomInqResult.NetSalesColumn.ColumnName].Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
            Columns[this._dataSet.CustomInqResult.NetSalesColumn.ColumnName].Header.Appearance.BackColor = _headerBackColor1;
            Columns[this._dataSet.CustomInqResult.NetSalesColumn.ColumnName].Header.Appearance.BackColor2 = _headerBackColor2;
            Columns[this._dataSet.CustomInqResult.NetSalesColumn.ColumnName].Header.Appearance.ForeColor = _headerForeColor1;
            Columns[this._dataSet.CustomInqResult.NetSalesColumn.ColumnName].Header.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            Columns[this._dataSet.CustomInqResult.NetSalesColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
            Columns[this._dataSet.CustomInqResult.NetSalesColumn.ColumnName].Format = formatCurrency;
            Columns[this._dataSet.CustomInqResult.NetSalesColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // 純売上
            Columns[this._dataSet.CustomInqResult.GrossProfitColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.CustomInqResult.GrossProfitColumn.ColumnName].Width = 250;
            Columns[this._dataSet.CustomInqResult.GrossProfitColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[this._dataSet.CustomInqResult.GrossProfitColumn.ColumnName].Header.Caption = "粗　利";
            Columns[this._dataSet.CustomInqResult.GrossProfitColumn.ColumnName].Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
            Columns[this._dataSet.CustomInqResult.GrossProfitColumn.ColumnName].Header.Appearance.BackColor = _headerBackColor1;
            Columns[this._dataSet.CustomInqResult.GrossProfitColumn.ColumnName].Header.Appearance.BackColor2 = _headerBackColor2;
            Columns[this._dataSet.CustomInqResult.GrossProfitColumn.ColumnName].Header.Appearance.ForeColor = _headerForeColor1;
            Columns[this._dataSet.CustomInqResult.GrossProfitColumn.ColumnName].Header.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            Columns[this._dataSet.CustomInqResult.GrossProfitColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
            Columns[this._dataSet.CustomInqResult.GrossProfitColumn.ColumnName].Format = formatCurrency;
            Columns[this._dataSet.CustomInqResult.GrossProfitColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

        }

        // ---------------------- ADD 2010/07/20 --------------------------------->>>>>
        /// <summary>
        /// グリッド列の初期化
        /// </summary>
        /// <param name="fiscalYear">会計年度</param>
        /// <br>Update Note: 2010/08/12 chenyd</br>
        /// <br>            ・障害ID:13026 テキスト出力対応</br> 
        /// <br>Update Note: 2010/09/09 tianjw</br>
        /// <br>            ・redmine #14434対応</br> 
        /// <br>Update Note: 2010/09/13 tianjw</br>
        /// <br>            ・テキスト出力対応　不具合対応#14643</br> 
        private void InitializeGridColumnsForOutput(int fiscalYear)
        {
            string moneyFormat = "#,##0;-#,##0;";

            int defoWidth = 94;     //（13桁）
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn col in this.uGrid_Details.DisplayLayout.Bands[0].Columns)
            {
                // 全ての列をいったん非表示にする。
                col.Hidden = true;
                col.CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                col.CellAppearance.ImageHAlign = Infragistics.Win.HAlign.Left;
                col.CellAppearance.ImageVAlign = Infragistics.Win.VAlign.Middle;
                // フォントサイズ：9
                //col.CellAppearance.FontData.SizeInPoints = 9f;   // フォントサイズ変更  // DEL 2010/08/12 障害ID:13026対応
                col.Width = defoWidth;
            }

            // 拠点ｺｰﾄﾞ
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.AddUpSecCodeColumn.ColumnName].Hidden = false;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.AddUpSecCodeColumn.ColumnName].Header.Caption = "拠点";
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.AddUpSecCodeColumn.ColumnName].Width = 60;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.AddUpSecCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.AddUpSecCodeColumn.ColumnName].Format = "";
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.AddUpSecCodeColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.AddUpSecCodeColumn.ColumnName].MaxLength = 2;

            // 得意先ｺｰﾄﾞ
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.CustomerCodeColumn.ColumnName].Hidden = false;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.CustomerCodeColumn.ColumnName].Header.Caption = "得意先";
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.CustomerCodeColumn.ColumnName].Width = 100;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.CustomerCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.CustomerCodeColumn.ColumnName].Format = "";
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.CustomerCodeColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.AddUpSecCodeColumn.ColumnName].MaxLength = 8;

            // 得意先名称
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.CustomerNameColumn.ColumnName].Hidden = false;
            // ----- UPD 2010/09/09 ----->>>>>
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.CustomerNameColumn.ColumnName].Header.Caption = "得意先名称";
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.CustomerNameColumn.ColumnName].Header.Caption = "得意先名";
            // ----- UPD 2010/09/09 -----<<<<<
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.CustomerNameColumn.ColumnName].Width = 220;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.CustomerNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.CustomerNameColumn.ColumnName].Format = "";
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.CustomerNameColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

            // 過年度実績・順売上（例2002年度）
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.NetSales1Column.ColumnName].Format = moneyFormat;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.NetSales1Column.ColumnName].Hidden = false;
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.NetSales1Column.ColumnName].Header.Caption = "過年度実績・順売上（" + (fiscalYear - 7).ToString() + "年度）"; // DEL 2010/0913
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.NetSales1Column.ColumnName].Header.Caption = "過年度実績・純売上（" + (fiscalYear - 7).ToString() + "年度）"; // ADD 2010/09/13
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.NetSales1Column.ColumnName].Width = 220;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.NetSales1Column.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.NetSales1Column.ColumnName].Format = moneyFormat;

            // 過年度実績・粗利（例2002年度）
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.GrossProfit1Column.ColumnName].Format = moneyFormat;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.GrossProfit1Column.ColumnName].Hidden = false;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.GrossProfit1Column.ColumnName].Header.Caption = "過年度実績・粗利（" + (fiscalYear - 7).ToString() + "年度）";
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.GrossProfit1Column.ColumnName].Width = 220;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.GrossProfit1Column.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.GrossProfit1Column.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

            // 過年度実績・順売上（例2003年度）
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.NetSales2Column.ColumnName].Format = moneyFormat;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.NetSales2Column.ColumnName].Hidden = false;
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.NetSales2Column.ColumnName].Header.Caption = "過年度実績・順売上（" + (fiscalYear - 6).ToString() + "年度）"; // DEL 2010/0913
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.NetSales2Column.ColumnName].Header.Caption = "過年度実績・純売上（" + (fiscalYear - 6).ToString() + "年度）"; // ADD 2010/09/13
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.NetSales2Column.ColumnName].Width = 220;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.NetSales2Column.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

            // 過年度実績・粗利（例2003年度）
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.GrossProfit2Column.ColumnName].Format = moneyFormat;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.GrossProfit2Column.ColumnName].Hidden = false;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.GrossProfit2Column.ColumnName].Header.Caption = "過年度実績・粗利（" + (fiscalYear - 6).ToString() + "年度）";
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.GrossProfit2Column.ColumnName].Width = 220;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.GrossProfit2Column.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.GrossProfit2Column.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

            // 過年度実績・順売上（例2004年度）
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.NetSales3Column.ColumnName].Format = moneyFormat;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.NetSales3Column.ColumnName].Hidden = false;
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.NetSales3Column.ColumnName].Header.Caption = "過年度実績・順売上（" + (fiscalYear - 5).ToString() + "年度）"; // DEL 2010/0913
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.NetSales3Column.ColumnName].Header.Caption = "過年度実績・純売上（" + (fiscalYear - 5).ToString() + "年度）"; // ADD 2010/09/13
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.NetSales3Column.ColumnName].Width = 220;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.NetSales3Column.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

            // 過年度実績・粗利（例2004年度）
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.GrossProfit3Column.ColumnName].Format = moneyFormat;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.GrossProfit3Column.ColumnName].Hidden = false;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.GrossProfit3Column.ColumnName].Header.Caption = "過年度実績・粗利（" + (fiscalYear - 5).ToString() + "年度）";
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.GrossProfit3Column.ColumnName].Width = 220;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.GrossProfit3Column.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.GrossProfit3Column.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

            // 過年度実績・順売上（例2005年度）
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.NetSales4Column.ColumnName].Format = moneyFormat;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.NetSales4Column.ColumnName].Hidden = false;
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.NetSales4Column.ColumnName].Header.Caption = "過年度実績・順売上（" + (fiscalYear - 4).ToString() + "年度）"; // DEL 2010/0913
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.NetSales4Column.ColumnName].Header.Caption = "過年度実績・純売上（" + (fiscalYear - 4).ToString() + "年度）"; // ADD 2010/09/13
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.NetSales4Column.ColumnName].Width = 220;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.NetSales4Column.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

            // 過年度実績・粗利（例2005年度）
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.GrossProfit4Column.ColumnName].Format = moneyFormat;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.GrossProfit4Column.ColumnName].Hidden = false;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.GrossProfit4Column.ColumnName].Header.Caption = "過年度実績・粗利（" + (fiscalYear - 4).ToString() + "年度）";
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.GrossProfit4Column.ColumnName].Width = 220;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.GrossProfit4Column.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.GrossProfit4Column.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

            // 過年度実績・順売上（例2006年度）
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.NetSales5Column.ColumnName].Format = moneyFormat;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.NetSales5Column.ColumnName].Hidden = false;
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.NetSales5Column.ColumnName].Header.Caption = "過年度実績・順売上（" + (fiscalYear - 3).ToString() + "年度）"; // DEL 2010/0913
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.NetSales5Column.ColumnName].Header.Caption = "過年度実績・純売上（" + (fiscalYear - 3).ToString() + "年度）"; // ADD 2010/09/13
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.NetSales5Column.ColumnName].Width = 220;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.NetSales5Column.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

            // 過年度実績・粗利（例2006年度）
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.GrossProfit5Column.ColumnName].Format = moneyFormat;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.GrossProfit5Column.ColumnName].Hidden = false;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.GrossProfit5Column.ColumnName].Header.Caption = "過年度実績・粗利（" + (fiscalYear - 3).ToString() + "年度）";
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.GrossProfit5Column.ColumnName].Width = 220;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.GrossProfit5Column.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.GrossProfit5Column.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

            // 過年度実績・順売上（例2007年度）
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.NetSales6Column.ColumnName].Format = moneyFormat;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.NetSales6Column.ColumnName].Hidden = false;
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.NetSales6Column.ColumnName].Header.Caption = "過年度実績・順売上（" + (fiscalYear - 2).ToString() + "年度）"; // DEL 2010/0913
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.NetSales6Column.ColumnName].Header.Caption = "過年度実績・純売上（" + (fiscalYear - 2).ToString() + "年度）"; // ADD 2010/09/13
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.NetSales6Column.ColumnName].Width = 220;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.NetSales6Column.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

            // 過年度実績・粗利（例2007年度）
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.GrossProfit6Column.ColumnName].Format = moneyFormat;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.GrossProfit6Column.ColumnName].Hidden = false;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.GrossProfit6Column.ColumnName].Header.Caption = "過年度実績・粗利（" + (fiscalYear - 2).ToString() + "年度）";
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.GrossProfit6Column.ColumnName].Width = 220;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.GrossProfit6Column.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.GrossProfit6Column.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

            // 過年度実績・順売上（例2008年度）
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.NetSales7Column.ColumnName].Format = moneyFormat;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.NetSales7Column.ColumnName].Hidden = false;
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.NetSales7Column.ColumnName].Header.Caption = "過年度実績・順売上（" + (fiscalYear - 1).ToString() + "年度）"; // DEL 2010/0913
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.NetSales7Column.ColumnName].Header.Caption = "過年度実績・純売上（" + (fiscalYear - 1).ToString() + "年度）"; // ADD 2010/09/13
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.NetSales7Column.ColumnName].Width = 220;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.NetSales7Column.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

            // 過年度実績・粗利（例2008年度）
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.GrossProfit7Column.ColumnName].Format = moneyFormat;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.GrossProfit7Column.ColumnName].Hidden = false;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.GrossProfit7Column.ColumnName].Header.Caption = "過年度実績・粗利（" + (fiscalYear - 1).ToString() + "年度）";
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.GrossProfit7Column.ColumnName].Width = 220;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.GrossProfit7Column.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.GrossProfit7Column.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

            // 過年度実績・順売上（例2009年度）
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.NetSales8Column.ColumnName].Format = moneyFormat;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.NetSales8Column.ColumnName].Hidden = false;
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.NetSales8Column.ColumnName].Header.Caption = "過年度実績・順売上（" + fiscalYear.ToString() + "年度）"; // DEL 2010/0913
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.NetSales8Column.ColumnName].Header.Caption = "過年度実績・純売上（" + fiscalYear.ToString() + "年度）"; // ADD 2010/09/13
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.NetSales8Column.ColumnName].Width = 220;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.NetSales8Column.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

            // 過年度実績・粗利（例2009年度）
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.GrossProfit8Column.ColumnName].Format = moneyFormat;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.GrossProfit8Column.ColumnName].Hidden = false;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.GrossProfit8Column.ColumnName].Header.Caption = "過年度実績・粗利（" + fiscalYear.ToString() + "年度）";
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.GrossProfit8Column.ColumnName].Width = 220;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.GrossProfit8Column.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.CustomInqResult.GrossProfit8Column.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

        }
        // ---------------------- ADD 2010/07/20 -----------------------------------<<<<<
        #endregion //

        #region 検索

        /// <summary>
        /// 検索
        /// </summary>
        /// <br>Update Note : 2010/09/21 tianjw</br>
        /// <br>              Redmine#14876 テキスト出力対応</br>
        private void Search()
        {
            // -------- ADD 2010/09/21 ----------------------------------------->>>>>
            // グリッドで表示に使用するデータビューを作成
            DataView dataView = new DataView(this._dataSet.CustomInqResult);

            // データソースとしてデータビューを指定
            this.uGrid_Details.DataSource = dataView;
            // -------- ADD 2010/09/21 -----------------------------------------<<<<<

            // 画面から検索条件クラスを作成

            // 企業コードをセット
            this._customInqOrderCndtn.EnterpriseCode = this._enterpriseCode;

            // 拠点コードをセット
            if (this.tEdit_SectionCodeAllowZero.Text.Trim().Equals("0") ||
                this.tEdit_SectionCodeAllowZero.Text.Trim().Equals("00"))
            {
                this._customInqOrderCndtn.AddUpSecCode = string.Empty;
                //this._customInqOrderCndtn.AddUpSecName = string.Empty;
                this._customInqOrderCndtn.AddUpSecName = "全社";
            }
            else if (String.IsNullOrEmpty(this.tEdit_SectionCodeAllowZero.Text.Trim()))
            {
                this._customInqOrderCndtn.AddUpSecCode = string.Empty;
                //this._customInqOrderCndtn.AddUpSecName = string.Empty;
                this._customInqOrderCndtn.AddUpSecName = "全社";
            }
            else
            {
                this._customInqOrderCndtn.AddUpSecCode = this.tEdit_SectionCodeAllowZero.Text.Trim();
                this._customInqOrderCndtn.AddUpSecName = this.tEdit_SectionName.Text.Trim();
            }

            // 得意先コードをセット
            this._customInqOrderCndtn.CustomerCode = this.tNedit_CustomerCode.GetInt();

            // --- CHG 2009/03/09 障害ID:11994対応------------------------------------------------------>>>>>
            //// 会計年度開始日をセット
            //if (this._fYearStartYearDate != DateTime.MinValue)
            //{
            //    this._customInqOrderCndtn.St_AddUpYearMonth = TDateTime.DateTimeToLongDate(this._fYearStartYearDate.AddYears(-1));
            //}

            //// 会計年度終了日をセット
            //if (this._fYearEndYearDate != DateTime.MinValue)
            //{
            //    this._customInqOrderCndtn.Ed_AddUpYearMonth = TDateTime.DateTimeToLongDate(this._fYearEndYearDate.AddYears(-1));
            //}
            // 会計年度情報取得
            int startDate;
            int endDate;
            int status = GetFinancialYearInfo(this._customInqOrderCndtn.AddUpSecCode, out this._fiscalYear, out startDate, out endDate);
            if (status == 0)
            {
                this._customInqOrderCndtn.St_AddUpYearMonth = startDate;
                this._customInqOrderCndtn.Ed_AddUpYearMonth = endDate;
            }
            // --- CHG 2009/03/09 障害ID:11994対応------------------------------------------------------<<<<<

            // --------------- ADD 2010/09/21 -------------------------->>>>>
            // 拠点
            if (this.tEdit_SectionCodeAllowZero.Focused)
            {
                EventArgs eArgs = new EventArgs();
                this.tEdit_SectionCodeAllowZero.Text = this.uiSetControl.GetZeroPaddedText(this.tEdit_SectionCodeAllowZero.Name, this.tEdit_SectionCodeAllowZero.Text);
                tEdit_SectionCodeAllowZero_Leave(null, eArgs);
                if (isError == true)
                {
                    return;
                }
            }
            // 得意先
            if (this.tNedit_CustomerCode.Focused)
            {
                EventArgs eArgs = new EventArgs();
                this.tNedit_CustomerCode.Text = this.uiSetControl.GetZeroPaddedText(this.tNedit_CustomerCode.Name, this.tNedit_CustomerCode.Text);
                tNedit_CustomerCode_Leave(null, eArgs);
                if (isError == true)
                {
                    return;
                }
            }
            // --------------- ADD 2010/09/21 --------------------------<<<<<

            // パラメータチェック
            string errorMsg = string.Empty;
            if (!CheckParameter(out errorMsg))
            {
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, "PMHNB04120U",
                               errorMsg, 0, MessageBoxButtons.OK);
                return;
            }
            else
            {
                // データセットをクリア
                this._dataSet.CustomInqResult.Clear();

                // 会計年度をセット
                this._custPastExperienceAcs.FiscalYear = _fiscalYear;

                // 検索実行
                this._custPastExperienceAcs.Search(this._customInqOrderCndtn);

                // ソート順を作成
                DataView dView = (DataView)this.uGrid_Details.DataSource;
                dView.Sort = "FiscalYear Desc";

                // 全てのグリッドの背景色を調整
                //RowColorChangeAll(false, 0);

            }
        }

        #endregion // 検索

        #region パラメータチェック関数

        /// <summary>
        /// パラメータチェック関数
        /// </summary>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        private bool CheckParameter(out string errorMsg)
        {
            errorMsg = string.Empty;

            // パラメータが必須のものをチェック

            // 年度開始日
            if (this._customInqOrderCndtn.St_AddUpYearMonth == 0)
            {
                errorMsg = CT_FISCAL_START_DATE_NOT_QUALIFIED;
                return false;
            }

            // 年度終了日
            if (this._customInqOrderCndtn.Ed_AddUpYearMonth == 0)
            {
                errorMsg = CT_FISCAL_END_DATE_NOT_QUALIFIED;
                return false;
            }

            // 得意先コード
            if (this._customInqOrderCndtn.CustomerCode == 0)
            {
                errorMsg = CT_CUSTOMER_CODE_NOT_QUALIFIED;
                return false;
            }

            // 企業コード
            if (String.IsNullOrEmpty(this._customInqOrderCndtn.EnterpriseCode))
            {
                errorMsg = CT_ENTERPRISE_CODE_NOT_QUALIFIED;
                return false;
            }

            return true;
        }

        #endregion // パラメータチェック関数

        #region グリッドの背景色を変更

        /// <summary>
        /// 行の背景色変更処理
        /// </summary>
        /// <param name="isSelected">bool 選択されている</param>
        /// <param name="gridRow">行オブジェクト</param>
        private void RowColorChangeAll(bool isSelected, Infragistics.Win.UltraWinGrid.UltraGridRow gridRow)
        {
            if (gridRow == null) return;

            //// 対象行が選択されているかそうでないかで配色が異なる
            //if (isSelected)
            ////{
            //    // グリッドの背景色を設定
            //    gridRow.Appearance.BackColor = _rowBackColor1;
            //    gridRow.Appearance.BackColor2 = _rowBackColor2;
            //    // グラデーションを設定
            //    gridRow.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            //}
            //else
            //{
            // 背景色を標準の配色に戻す
            if (gridRow.Index % 2 == 1)
            {
                gridRow.Appearance.BackColor = Color.Lavender;
            }
            else
            {
                gridRow.Appearance.BackColor = Color.White;
            }
            // グラデーションを設定
            gridRow.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Default;
            //}
        }

        #endregion // グリッドの背景色を変更

        // --- ADD 2009/03/09 障害ID:11994対応------------------------------------------------------>>>>>
        #region 会計年度取得(今回月次処理日より算出)
        /// <summary>
        /// 会計年度情報取得処理
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="financialYear">会計年度</param>
        /// <param name="startDate">年度開始日</param>
        /// <param name="endDate">年度終了日</param>
        /// <returns>ステータス</returns>
        private int GetFinancialYearInfo(string sectionCode, out int financialYear, out int startDate, out int endDate)
        {
            //----------------------------------------------------------------------------------------------
            // 会計年度  ：今回月次処理日を含む年度(=日付取得部品より取得)をセット
            // 年度開始日：対象の会計年度の開始日(=日付取得部品より取得)をセット
            // 年度終了日：対象の会計年度の終了日(=日付取得部品より取得)をセット
            //----------------------------------------------------------------------------------------------

            financialYear = 0;
            startDate = 0;
            endDate = 0;

            // DEL 2009/05/25 ------>>>
            //DateTime prevTotalDay;
            //DateTime currentTotalDay;
            // DEL 2009/05/25 ------<<<
            DateTime dummyDate;
            DateTime startYearDate;
            DateTime endYearDate;

            int status;

            // DEL 2009/05/25 ------>>>
            //// 全社
            //if ((sectionCode.Trim() == "") || (sectionCode.Trim() == "0") || (sectionCode.Trim() == "00"))
            //{
            //    status = this._totalDayCalculator.GetHisTotalDayMonthlyAccRec(String.Empty, out prevTotalDay, out currentTotalDay);
            //    if (status == 0)
            //    {
            //        this._dateGetAcs.GetYearMonth(currentTotalDay, out dummyDate, out financialYear, out dummyDate, out dummyDate, out startYearDate, out endYearDate);
            //        startDate = TDateTime.DateTimeToLongDate(startYearDate);
            //        endDate = TDateTime.DateTimeToLongDate(endYearDate);
            //    }
            //}
            //// 拠点
            //else
            //{
            //    status = this._totalDayCalculator.GetHisTotalDayMonthlyAccRec(sectionCode.Trim(), out prevTotalDay, out currentTotalDay);
            //    if (status == 0)
            //    {
            //        this._dateGetAcs.GetYearMonth(currentTotalDay, out dummyDate, out financialYear, out dummyDate, out dummyDate, out startYearDate, out endYearDate);
            //        startDate = TDateTime.DateTimeToLongDate(startYearDate);
            //        endDate = TDateTime.DateTimeToLongDate(endYearDate);
            //    }
            //}
            // DEL 2009/05/25 ------<<<

            // ADD 2009/05/25 ------>>>
            // 自社設定マスタの会計年度を取得
            CompanyInf companyInf = this._dateGetAcs.GetCompanyInf();
            status = -1;
            if (companyInf != null)
            {
                // 自社設定マスタの期首年月日で年度開始／終了日を取得
                DateTime dateTime = TDateTime.LongDateToDateTime(companyInf.CompanyBiginDate);
                this._dateGetAcs.GetYearMonth(dateTime, out dummyDate, out financialYear, out dummyDate, out dummyDate, out startYearDate, out endYearDate);
                startDate = TDateTime.DateTimeToLongDate(startYearDate);
                endDate = TDateTime.DateTimeToLongDate(endYearDate);
                status = 0;
            }
            // ADD 2009/05/25 ------<<<

            return (status);
        }
        #endregion 会計年度取得(今回月次処理日より算出)
        // --- ADD 2009/03/09 障害ID:11994対応------------------------------------------------------<<<<<

        #endregion // プライベート関数

        #region コントロールメソッド

        #region ガイドボタン

        /// <summary>
        /// 拠点ガイドボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_SectionGuide_Click(object sender, EventArgs e)
        {
            // 拠点ガイド表示
            int status = this._secInfoSetAcs.ExecuteGuid(this._enterpriseCode, false, out _sectionInfo);

            // ステータスが正常時のみ情報をUIにセット
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this.tEdit_SectionCodeAllowZero.Text = _sectionInfo.SectionCode.Trim();
                this.tEdit_SectionName.Text = _sectionInfo.SectionGuideNm.Trim();
            }
            else
            {
                // 2008.12.02 del start [8578]
                //this.tEdit_SectionCodeAllowZero.Clear();
                //this.tEdit_SectionName.Text = "";
                // 2008.12.02 del end [8578]
            }
        }

        /// <summary>
        /// 得意先ガイドボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_CustomerGuide_Click(object sender, EventArgs e)
        {
            // 得意先ガイド表示
            PMKHN04005UA customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_CUSTOMER_ONLY, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY);
            customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.CustomerSearchForm_CustomerSelect);
            DialogResult result = customerSearchForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                // 現在処理なし
            }
        }

        #endregion // ガイドボタン

        #region 得意先選択ガイドボタンクリック時イベント

        /// <summary>
        /// 得意先選択ガイドボタンクリック時発生イベント
        /// </summary>
        /// <param name="sender">PMKHN4002Eフォームオブジェクト</param>
        /// <param name="customerSearchRet">得意先情報戻り値クラス(PMKHN4002E)</param>
        private void CustomerSearchForm_CustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        {
            // イベントハンドラを渡した相手から戻り値クラスを受け取れなければ終了
            if (customerSearchRet == null) return;

            // DBデータを読み出す(キャッシュを使用)
            CustomerInfo customerInfo;
            int status = this._customerInfoAcs.ReadDBData(customerSearchRet.EnterpriseCode, customerSearchRet.CustomerCode, true, out customerInfo);

            // ステータスによりエラーメッセージを出力
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (customerInfo == null)
                {
                    TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Name,
                        "選択した得意先は得意先情報入力が行われていない為、使用出来ません。",
                        status, MessageBoxButtons.OK);
                    return;
                }
            }
            else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Name,
                    "選択した得意先は既に削除されています。",
                    status, MessageBoxButtons.OK);
                return;
            }
            else
            {
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_STOPDISP, this.Name,
                    "得意先情報の取得に失敗しました。",
                    status, MessageBoxButtons.OK);
                return;
            }

            // 得意先情報をUIに設定
            this.tNedit_CustomerCode.SetInt(customerInfo.CustomerCode);
            this.tEdit_CustomerName.Text = customerInfo.CustomerSnm.TrimEnd();
        }

        #endregion // 得意先選択ガイドボタンクリック時イベント

        #region ツールバー

        /// <summary>
        /// ツールバー
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tToolbarsManager_MainMenu_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
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

                #region 確定ボタン
                case "ButtonTool_Decision":
                    {
                        Search();
                        _dViewBak = new DataView(this._dataSet.CustomInqResult.Copy()); // ADD 2010/09/21
                        this.isSearch = true; // ADD 2010/07/20
                        break;
                    }
                #endregion // クリアボタン

                #region クリアボタン
                case "ButtonTool_Clear":
                    {
                        InitializeScreen();
                        this.isSearch = false; // ADD 2010/09/14
                        break;
                    }
                #endregion // クリアボタン

                // --- ADD 2010/06/28 ---------->>>>>
                #region テキスト出力ボタン
                case "ButtonTool_TextOutput":
                    {
                        this.ExportIntoTextFile(false); // ADD 2010/07/20
                        break;
                    }
                #endregion // テキスト出力ボタン

                #region Excel出力ボタン
                case "ButtonTool_ExcelOutput":
                    {
                        this.exportIntoExcelData(true);// ADD 2010/07/20
                        break;
                    }
                #endregion // Excel出力ボタン

                #region 設定ボタン
                case "ButtonTool_Setup":
                    {
                        // ---------------------- ADD 2010/07/20 --------------------------------->>>>>
                        if (this._userSetupFrm == null)
                            this._userSetupFrm = new PMHNB04121UB();

                        this._userSetupFrm.ShowDialog();
                        // ---------------------- ADD 2010/07/20 -----------------------------------<<<<<
                        break;
                    }
                #endregion // 設定ボタン
                // --- ADD 2010/06/28 ----------<<<<<
                default: break;
            }
        }

        #endregion // ツールバー

        #region 名称変換(Leaveイベント)

        /// <summary>
        /// 拠点コード
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tEdit_SectionCodeAllowZero_Leave(object sender, EventArgs e)
        {
            // 名称変換
            this._sectionCode = this.tEdit_SectionCodeAllowZero.Text.Trim().PadLeft(2, '0');
            string sectionName = string.Empty;

            // 全社対応処理
            if (this._sectionCode.Equals("0") || this._sectionCode.Equals("00"))
            {
                // コードは00へ（検索時には00のとき空白にする）
                this._sectionCode = "00";
                sectionName = CT_NAME_ALLSECCODE;
                this.tEdit_SectionName.Text = sectionName;
                this.tNedit_CustomerCode.Focus();
            }
            else if (!String.IsNullOrEmpty(this._sectionCode))
            {
                sectionName = this.GetSectionName(this._sectionCode);
                if (!String.IsNullOrEmpty(sectionName))
                {
                    this.tEdit_SectionName.Text = sectionName;
                }
                else
                {
                    // 2008.12.09 modify start [8890]
                    sectionName = CT_NAME_ALLSECCODE;
                    this.tEdit_SectionName.Text = sectionName;
                    //this.tEdit_SectionName.Clear();
                    // 2008.12.09 modify end [8890]
                    this.tEdit_SectionCodeAllowZero.Focus(); // ADD 2010/09/21
                }
            }
        }

        /// <summary>
        /// 得意先コード
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <br>Update Note : 2010/09/21 tianjw</br>
        /// <br>              Redmine#14876 テキスト出力対応</br>
        private void tNedit_CustomerCode_Leave(object sender, EventArgs e)
        {
            // 名称変換
            this._customerCd = this.tNedit_CustomerCode.GetInt();
            string customerName = string.Empty;

            if (_customerCd != 0)
            {
                customerName = this.GetCustomerName(this._customerCd);
                // -------- ADD 2010/09/21 ------>>>>>
                if (isError == true)
                {
                    return;
                }
                // -------- ADD 2010/09/21 ------<<<<<
                if (!String.IsNullOrEmpty(customerName))
                {
                    this.tEdit_CustomerName.Text = customerName;
                }
                else
                {
                    this.tEdit_CustomerName.Clear();
                    // 2008.12.09 add start [8889]
                    this.uButton_CustomerGuide.Focus();
                    // 2008.12.09 add end [8889]
                }
            }
            else
            {
                this.tEdit_CustomerName.Clear();
            }
        }

        #endregion // 名称変換(Leaveイベント)

        #region アローキーコントロール

        /// <summary>
        /// アローキーコントロール
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <br>Update Note : 2010/09/21 tianjw</br>
        /// <br>              テキスト出力対応</br>
        private void tArrowKeyControl_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null) return;

            // 名前により分岐
            switch (e.PrevCtrl.Name)
            {
                //---------------------------------------------------------------
                // フィールド間移動
                //---------------------------------------------------------------

                #region 拠点コード
                case "tEdit_SectionCodeAllowZero":
                    {
                        // ------- ADD 2010/09/21 --------------------------------------------------------------->>>>>
                        this.tEdit_SectionCodeAllowZero.Text = this.uiSetControl.GetZeroPaddedText(this.tEdit_SectionCodeAllowZero.Name, this.tEdit_SectionCodeAllowZero.Text);

                        tEdit_SectionCodeAllowZero_Leave(null, null);
                        if (!this.isError)
                        {
                        // ------- ADD 2010/09/21 ---------------------------------------------------------------<<<<<
                            switch (e.Key)
                            {
                                case Keys.Enter:
                                case Keys.Tab:
                                    {
                                        if (String.IsNullOrEmpty(this.tEdit_SectionCodeAllowZero.Text.Trim()))
                                        {
                                            e.NextCtrl = this.uButton_SectionGuide;
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.tNedit_CustomerCode;
                                        }
                                        break;
                                    }
                                case Keys.Down:
                                    {
                                        e.NextCtrl = this.tNedit_CustomerCode;
                                        break;
                                    }
                                case Keys.Up:
                                    {
                                        e.NextCtrl = this.tNedit_CustomerCode;
                                        break;
                                    }
                            }
                        // ------- ADD 2010/09/21 --------------------------------------------------------------->>>>>
                        }
                        else
                        {
                            e.NextCtrl = null;
                        }
                        // ------- ADD 2010/09/21 ---------------------------------------------------------------<<<<<
                        break;
                    }
                #endregion // 拠点コード

                #region 拠点ガイド
                case "uButton_SectionGuide":
                    {
                        switch (e.Key)
                        {
                            case Keys.Enter:
                            case Keys.Tab:
                            case Keys.Up:
                            case Keys.Down:
                                {
                                    e.NextCtrl = this.tNedit_CustomerCode;
                                    break;
                                }
                        }
                        break;
                    }
                #endregion // 拠点ガイド

                #region 得意先コード
                case "tNedit_CustomerCode":
                    {
                        switch (e.Key)
                        {
                            case Keys.Enter:
                            case Keys.Tab:
                            case Keys.Down:
                                {
                                    if (String.IsNullOrEmpty(this.tNedit_CustomerCode.Text.Trim()))
                                    {
                                        e.NextCtrl = this.uButton_CustomerGuide;
                                    }
                                    else
                                    {
                                        //if (this.uGrid_Details.Rows.Count > 0)
                                        //{
                                        //    e.NextCtrl = this.uGrid_Details;
                                        //}
                                        //else
                                        //{
                                        e.NextCtrl = uExpandableGroupBox_Condition;// this.tEdit_SectionCodeAllowZero;
                                        //}
                                    }
                                    break;
                                }
                            case Keys.Up:
                                {
                                    e.NextCtrl = this.tEdit_SectionCodeAllowZero;
                                    break;
                                }
                        }
                        break;
                    }
                #endregion // 得意先コード

                #region 得意先ガイド
                case "uButton_CustomerGuide":
                    {
                        switch (e.Key)
                        {
                            case Keys.Enter:
                            case Keys.Tab:
                            case Keys.Down:
                                {
                                    //if (this.uGrid_Details.Rows.Count > 0)
                                    //{
                                    //    e.NextCtrl = this.uGrid_Details;
                                    //}
                                    //else
                                    //{
                                    e.NextCtrl = uExpandableGroupBox_Condition;
                                    //}
                                    break;
                                }
                            case Keys.Up:
                                {
                                    e.NextCtrl = this.tEdit_SectionCodeAllowZero;
                                    break;
                                }
                        }
                        break;
                    }
                #endregion // 得意先ガイド

                default: break;

            }
        }

        #endregion // アローキーコントロール

        #endregion // コントロールメソッド
        // ---------------------- ADD 2010/07/20 --------------------------------->>>>>
        # region プライベートメソッド
        /// <summary>
        /// EXCELデータ出力
        /// </summary>
        /// <param name="excelFlg">出力形式フラグ</param>
        /// <remarks>
        /// <br>Note       : 得意先過年度実績照会をEXCELデータ出力します。</br>
        /// <br>Programmer : 姜凱</br>
        /// <br>Date       : 2010/07/19</br>
        /// <br>Update Note: 2010/09/21 tianjw</br>
        /// <br>            ・テキスト出力対応</br> 
        /// <br>Update Note: 2010/10/09 yangmj</br>
        /// <br>            ・テキスト出力対応 不具合対応#15879</br> 
        /// <br>Update Note: 2024/11/22 陳艶丹</br>
        /// <br>            ・PMKOBETSU-4368 2024年PKG格上のログ出力対応</br>
        /// </remarks>
        private void exportIntoExcelData(bool excelFlg)
        {
            //if (this._extractSetupFrm == null) // DEL 2010/09/21
                this._extractSetupFrm = new PMHNB04121UC();
            // 出力形式
            this._extractSetupFrm.ExcelFlg = excelFlg;

            this._extractSetupFrm.OutputData += new PMHNB04121UC.OutputDataEvent(this.outputExcelData); // ADD 2010/10/09

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
                    DialogResult dialogResult = TMsgDisp.Show(form, emErrorLevel.ERR_LEVEL_STOP, this.Name,
                                errMsg, logStatus, MessageBoxButtons.OK);
                    form.TopMost = false;
                }
                // 中止
                return;
            }
            //----- ADD 2024/11/22 陳艶丹 PMKOBETSU-4368 2024年PKG格上のログ出力対応 -----<<<<<

            this._extractSetupFrm.ShowDialog();

            // --- DEL 2010/10/09 ---------->>>>>
            //if (this._extractSetupFrm.DResult == DialogResult.Cancel)
            //{
            //    return;
            //}

            //SFCMN00299CA processingDialog = new SFCMN00299CA();
            //try
            //{
            //    processingDialog.Title = "抽出処理";
            //    processingDialog.Message = "現在、データ抽出中です。";
            //    processingDialog.DispCancelButton = false;
            //    processingDialog.Show((Form)this.Parent);
            //    this._custPastExperienceAcs.SearchAll(this._enterpriseCode, this._extractSetupFrm.SectionCodeList, this._extractSetupFrm.SelectionCodeList);

            //}
            //finally
            //{
            //    processingDialog.Dispose();
            //}
            //if (this._dataSet.CustomInqResult.Count == 0)
            //{
            //    // データセットをクリア
            //    this._dataSet.CustomInqResult.Clear();
            //    // グリッド列を設定
            //    InitializeGridColumns(this.uGrid_Details.DisplayLayout.Bands[0].Columns);
            //    // --------------------- UPD 2010/09/21 ------------>>>>>
            //    this.uGrid_Details.DataSource = _dViewBak;

            //    //if (isSearch)
            //    //{
            //    //    this.Search();
            //    //}
            //    // --------------------- UPD 2010/09/21 ------------<<<<<
            //    TMsgDisp.Show(
            //        this,
            //        emErrorLevel.ERR_LEVEL_EXCLAMATION,
            //        this.Name,
            //        "条件に合致するデータが存在しません。",
            //        -1,
            //        MessageBoxButtons.OK);
            //    return;
            //}

            //this.InitializeGridColumnsForOutput(this._custPastExperienceAcs.FiscalYear);

            //try
            //{
            //    if (this.ultraGridExcelExporter1.Export(this.uGrid_Details, this._extractSetupFrm.SettingFileName) != null)
            //    {
            //        // データセットをクリア
            //        this._dataSet.CustomInqResult.Clear();
            //        // グリッド列を設定
            //        InitializeGridColumns(this.uGrid_Details.DisplayLayout.Bands[0].Columns);
            //        // --------------------- UPD 2010/09/21 ------------>>>>>
            //        this.uGrid_Details.DataSource = _dViewBak;
            //        //if (isSearch)
            //        //{
            //        //    this.Search();
            //        //}
            //        // --------------------- UPD 2010/09/21 ------------<<<<<
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
            //    // データセットをクリア
            //    this._dataSet.CustomInqResult.Clear();
            //    // グリッド列を設定
            //    InitializeGridColumns(this.uGrid_Details.DisplayLayout.Bands[0].Columns);
            //    // --------------------- UPD 2010/09/21 ------------>>>>>
            //    this.uGrid_Details.DataSource = _dViewBak;
            //    //if (isSearch)
            //    //{
            //    //    this.Search();
            //    //}
            //    // --------------------- UPD 2010/09/21 ------------<<<<<

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
        /// テキスト出力
        /// </summary>
        /// <param name="excelFlg">出力形式フラグ</param>
        /// <remarks>
        /// <br>Note       : 得意先過年度実績照会をテキスト出力します。</br>
        /// <br>Programmer : 姜凱</br>
        /// <br>Date       : 2010/07/19</br>
        /// <br>Update Note: 2010/09/13 tianjw</br>
        /// <br>            ・テキスト出力対応　不具合対応#14643</br>
        /// <br>Update Note: 2010/09/21 tianjw</br>
        /// <br>            ・テキスト出力対応</br> 
        /// <br>Update Note: 2010/10/09 yangmj</br>
        /// <br>            ・テキスト出力対応 不具合対応#15879</br> 
        /// <br>Update Note : 2024/11/22 陳艶丹</br>
        /// <br>            ・PMKOBETSU-4368 2024年PKG格上のログ出力対応</br>
        /// </remarks>
        private void ExportIntoTextFile(bool excelFlg)
        {
            //if (this._extractSetupFrm == null) // DEL 2010/09/21
                this._extractSetupFrm = new PMHNB04121UC();
            // 出力形式
            this._extractSetupFrm.ExcelFlg = excelFlg;

            this._extractSetupFrm.OutputData += new PMHNB04121UC.OutputDataEvent(this.outputTextData); // ADD 2010/10/09

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
                    DialogResult dialogResult = TMsgDisp.Show(form, emErrorLevel.ERR_LEVEL_STOP, this.Name,
                                errMsg, logStatus, MessageBoxButtons.OK);
                    form.TopMost = false;
                }
                // 中止
                return;
            }
            //----- ADD 2024/11/22 陳艶丹 PMKOBETSU-4368 2024年PKG格上のログ出力対応 -----<<<<<

            this._extractSetupFrm.ShowDialog();

            // --- DEL 2010/10/09 ---------->>>>>
            //if (this._extractSetupFrm.DResult == DialogResult.Cancel)
            //{
            //    return;
            //}

            //SFCMN00299CA processingDialog = new SFCMN00299CA();
            //try
            //{
            //    processingDialog.Title = "抽出処理";
            //    processingDialog.Message = "現在、データ抽出中です。";
            //    processingDialog.DispCancelButton = false;
            //    processingDialog.Show((Form)this.Parent);
            //    this._custPastExperienceAcs.SearchAll(this._enterpriseCode, this._extractSetupFrm.SectionCodeList, this._extractSetupFrm.SelectionCodeList);
            //}
            //finally
            //{
            //    processingDialog.Dispose();
            //}
            //if (this._dataSet.CustomInqResult.Count == 0)
            //{
            //    // データセットをクリア
            //    this._dataSet.CustomInqResult.Clear();
            //    // グリッド列を設定
            //    InitializeGridColumns(this.uGrid_Details.DisplayLayout.Bands[0].Columns);
            //    // --------------------- UPD 2010/09/21 ------------>>>>>
            //    this.uGrid_Details.DataSource = _dViewBak;
            //    //if (isSearch)
            //    //{
            //    //    this.Search();
            //    //}
            //    // --------------------- UPD 2010/09/21 ------------<<<<<
            //    TMsgDisp.Show(
            //        this,
            //        emErrorLevel.ERR_LEVEL_EXCLAMATION,
            //        this.Name,
            //        "条件に合致するデータが存在しません。",
            //        -1,
            //        MessageBoxButtons.OK);
            //    return;
            //}

            //this.InitializeGridColumnsForOutput(this._custPastExperienceAcs.FiscalYear);

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

            //DataTable targetTable = this._dataSet.CustomInqResult;
            //// -------------------------------------------DEL 2010/09/13 --------------------------------------------------------------------->>>>>
            ////targetTable.Columns["NetSales1"].Caption = "過年度実績・順売上（" + (this._custPastExperienceAcs.FiscalYear - 7).ToString() + "年度）";
            ////targetTable.Columns["NetSales2"].Caption = "過年度実績・順売上（" + (this._custPastExperienceAcs.FiscalYear - 6).ToString() + "年度）";
            ////targetTable.Columns["NetSales3"].Caption = "過年度実績・順売上（" + (this._custPastExperienceAcs.FiscalYear - 5).ToString() + "年度）";
            ////targetTable.Columns["NetSales4"].Caption = "過年度実績・順売上（" + (this._custPastExperienceAcs.FiscalYear - 4).ToString() + "年度）";
            ////targetTable.Columns["NetSales5"].Caption = "過年度実績・順売上（" + (this._custPastExperienceAcs.FiscalYear - 3).ToString() + "年度）";
            ////targetTable.Columns["NetSales6"].Caption = "過年度実績・順売上（" + (this._custPastExperienceAcs.FiscalYear - 2).ToString() + "年度）";
            ////targetTable.Columns["NetSales7"].Caption = "過年度実績・順売上（" + (this._custPastExperienceAcs.FiscalYear - 1).ToString() + "年度）";
            ////targetTable.Columns["NetSales8"].Caption = "過年度実績・順売上（" + (this._custPastExperienceAcs.FiscalYear).ToString() + "年度）";
            //// -------------------------------------------DEL 2010/09/13 ---------------------------------------------------------------------<<<<<
            //// -------------------------------------------ADD 2010/09/13 --------------------------------------------------------------------->>>>>
            //targetTable.Columns["NetSales1"].Caption = "過年度実績・純売上（" + (this._custPastExperienceAcs.FiscalYear - 7).ToString() + "年度）";
            //targetTable.Columns["NetSales2"].Caption = "過年度実績・純売上（" + (this._custPastExperienceAcs.FiscalYear - 6).ToString() + "年度）";
            //targetTable.Columns["NetSales3"].Caption = "過年度実績・純売上（" + (this._custPastExperienceAcs.FiscalYear - 5).ToString() + "年度）";
            //targetTable.Columns["NetSales4"].Caption = "過年度実績・純売上（" + (this._custPastExperienceAcs.FiscalYear - 4).ToString() + "年度）";
            //targetTable.Columns["NetSales5"].Caption = "過年度実績・純売上（" + (this._custPastExperienceAcs.FiscalYear - 3).ToString() + "年度）";
            //targetTable.Columns["NetSales6"].Caption = "過年度実績・純売上（" + (this._custPastExperienceAcs.FiscalYear - 2).ToString() + "年度）";
            //targetTable.Columns["NetSales7"].Caption = "過年度実績・純売上（" + (this._custPastExperienceAcs.FiscalYear - 1).ToString() + "年度）";
            //targetTable.Columns["NetSales8"].Caption = "過年度実績・純売上（" + (this._custPastExperienceAcs.FiscalYear).ToString() + "年度）";
            //// -------------------------------------------ADDL 2010/09/13 ---------------------------------------------------------------------<<<<<
            //targetTable.Columns["GrossProfit1"].Caption = "過年度実績・粗利（" + (this._custPastExperienceAcs.FiscalYear - 7).ToString() + "年度）";
            //targetTable.Columns["GrossProfit2"].Caption = "過年度実績・粗利（" + (this._custPastExperienceAcs.FiscalYear - 6).ToString() + "年度）";
            //targetTable.Columns["GrossProfit3"].Caption = "過年度実績・粗利（" + (this._custPastExperienceAcs.FiscalYear - 5).ToString() + "年度）";
            //targetTable.Columns["GrossProfit4"].Caption = "過年度実績・粗利（" + (this._custPastExperienceAcs.FiscalYear - 4).ToString() + "年度）";
            //targetTable.Columns["GrossProfit5"].Caption = "過年度実績・粗利（" + (this._custPastExperienceAcs.FiscalYear - 3).ToString() + "年度）";
            //targetTable.Columns["GrossProfit6"].Caption = "過年度実績・粗利（" + (this._custPastExperienceAcs.FiscalYear - 2).ToString() + "年度）";
            //targetTable.Columns["GrossProfit7"].Caption = "過年度実績・粗利（" + (this._custPastExperienceAcs.FiscalYear - 1).ToString() + "年度）";
            //targetTable.Columns["GrossProfit8"].Caption = "過年度実績・粗利（" + (this._custPastExperienceAcs.FiscalYear).ToString() + "年度）";


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

            //if (status == 9)// 異常終了
            //{
            //    // データセットをクリア
            //    this._dataSet.CustomInqResult.Clear();
            //    // グリッド列を設定
            //    InitializeGridColumns(this.uGrid_Details.DisplayLayout.Bands[0].Columns);
            //    // --------------------- UPD 2010/09/21 ------------>>>>>
            //    this.uGrid_Details.DataSource = _dViewBak;
            //    //if (isSearch)
            //    //{
            //    //    this.Search();
            //    //}
            //    // --------------------- UPD 2010/09/21 ------------<<<<<
            //    // 出力失敗
            //    TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Name,
            //        "ファイルへの出力に失敗しました。", -1, MessageBoxButtons.OK);
            //}
            //else
            //{
            //    // データセットをクリア
            //    this._dataSet.CustomInqResult.Clear();
            //    // グリッド列を設定
            //    InitializeGridColumns(this.uGrid_Details.DisplayLayout.Bands[0].Columns);
            //    // --------------------- UPD 2010/09/21 ------------>>>>>
            //    this.uGrid_Details.DataSource = _dViewBak;
            //    //if (isSearch)
            //    //{
            //    //    this.Search();
            //    //}
            //    // --------------------- UPD 2010/09/21 ------------<<<<<
            //    // 出力成功
            //    TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, this.Name,
            //        outputCount.ToString() + "行のデータをファイルへ出力しました。", -1, MessageBoxButtons.OK);
            //}
            // --- DEL 2010/10/09 ----------<<<<<
        }
        // --- ADD 2010/10/09 ---------->>>>>
                /// <summary>
        /// テキスト出力処理
        /// </summary>
        /// <returns>True:正常; False:異常</returns>
        /// <br>Update Note: 2011/02/16 liyp</br>
        /// <br>            ・テキスト出力対応</br> 
        /// <br>Update Note :2024/11/22 陳艶丹</br>
        /// <br>            ・PMKOBETSU-4368 2024年PKG格上のログ出力対応</br>
        private bool outputTextData()
        {
            if (this._extractSetupFrm.DResult == DialogResult.Cancel)
            {
                return true;
            }

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
                // テキスト出力操作ログ登録及び出力時アラートメッセージ表示処理「テキスト出力」
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
                this._custPastExperienceAcs.SearchAll(this._enterpriseCode, this._extractSetupFrm.SectionCodeList, this._extractSetupFrm.SelectionCodeList);

                // グリッドで表示に使用するデータビューを作成
                DataView dataView = new DataView(this._dataSet.CustomInqResult);

                // データソースとしてデータビューを指定
                this.uGrid_Details.DataSource = dataView;
            }
            finally
            {
                processingDialog.Dispose();
            }
            if (this._dataSet.CustomInqResult.Count == 0)
            {
                // データセットをクリア
                this._dataSet.CustomInqResult.Clear();
                // グリッド列を設定
                InitializeGridColumns(this.uGrid_Details.DisplayLayout.Bands[0].Columns);
                // --------------------- UPD 2010/09/21 ------------>>>>>
                this.uGrid_Details.DataSource = _dViewBak;
                //if (isSearch)
                //{
                //    this.Search();
                //}
                // --------------------- UPD 2010/09/21 ------------<<<<<
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                    this.Name,
                    "条件に合致するデータが存在しません。",
                    -1,
                    MessageBoxButtons.OK);
                return false;
            }

            this.InitializeGridColumnsForOutput(this._custPastExperienceAcs.FiscalYear);

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

            DataTable targetTable = this._dataSet.CustomInqResult;
            // -------------------------------------------DEL 2010/09/13 --------------------------------------------------------------------->>>>>
            //targetTable.Columns["NetSales1"].Caption = "過年度実績・順売上（" + (this._custPastExperienceAcs.FiscalYear - 7).ToString() + "年度）";
            //targetTable.Columns["NetSales2"].Caption = "過年度実績・順売上（" + (this._custPastExperienceAcs.FiscalYear - 6).ToString() + "年度）";
            //targetTable.Columns["NetSales3"].Caption = "過年度実績・順売上（" + (this._custPastExperienceAcs.FiscalYear - 5).ToString() + "年度）";
            //targetTable.Columns["NetSales4"].Caption = "過年度実績・順売上（" + (this._custPastExperienceAcs.FiscalYear - 4).ToString() + "年度）";
            //targetTable.Columns["NetSales5"].Caption = "過年度実績・順売上（" + (this._custPastExperienceAcs.FiscalYear - 3).ToString() + "年度）";
            //targetTable.Columns["NetSales6"].Caption = "過年度実績・順売上（" + (this._custPastExperienceAcs.FiscalYear - 2).ToString() + "年度）";
            //targetTable.Columns["NetSales7"].Caption = "過年度実績・順売上（" + (this._custPastExperienceAcs.FiscalYear - 1).ToString() + "年度）";
            //targetTable.Columns["NetSales8"].Caption = "過年度実績・順売上（" + (this._custPastExperienceAcs.FiscalYear).ToString() + "年度）";
            // -------------------------------------------DEL 2010/09/13 ---------------------------------------------------------------------<<<<<
            // -------------------------------------------ADD 2010/09/13 --------------------------------------------------------------------->>>>>
            targetTable.Columns["NetSales1"].Caption = "過年度実績・純売上（" + (this._custPastExperienceAcs.FiscalYear - 7).ToString() + "年度）";
            targetTable.Columns["NetSales2"].Caption = "過年度実績・純売上（" + (this._custPastExperienceAcs.FiscalYear - 6).ToString() + "年度）";
            targetTable.Columns["NetSales3"].Caption = "過年度実績・純売上（" + (this._custPastExperienceAcs.FiscalYear - 5).ToString() + "年度）";
            targetTable.Columns["NetSales4"].Caption = "過年度実績・純売上（" + (this._custPastExperienceAcs.FiscalYear - 4).ToString() + "年度）";
            targetTable.Columns["NetSales5"].Caption = "過年度実績・純売上（" + (this._custPastExperienceAcs.FiscalYear - 3).ToString() + "年度）";
            targetTable.Columns["NetSales6"].Caption = "過年度実績・純売上（" + (this._custPastExperienceAcs.FiscalYear - 2).ToString() + "年度）";
            targetTable.Columns["NetSales7"].Caption = "過年度実績・純売上（" + (this._custPastExperienceAcs.FiscalYear - 1).ToString() + "年度）";
            targetTable.Columns["NetSales8"].Caption = "過年度実績・純売上（" + (this._custPastExperienceAcs.FiscalYear).ToString() + "年度）";
            // -------------------------------------------ADDL 2010/09/13 ---------------------------------------------------------------------<<<<<
            targetTable.Columns["GrossProfit1"].Caption = "過年度実績・粗利（" + (this._custPastExperienceAcs.FiscalYear - 7).ToString() + "年度）";
            targetTable.Columns["GrossProfit2"].Caption = "過年度実績・粗利（" + (this._custPastExperienceAcs.FiscalYear - 6).ToString() + "年度）";
            targetTable.Columns["GrossProfit3"].Caption = "過年度実績・粗利（" + (this._custPastExperienceAcs.FiscalYear - 5).ToString() + "年度）";
            targetTable.Columns["GrossProfit4"].Caption = "過年度実績・粗利（" + (this._custPastExperienceAcs.FiscalYear - 4).ToString() + "年度）";
            targetTable.Columns["GrossProfit5"].Caption = "過年度実績・粗利（" + (this._custPastExperienceAcs.FiscalYear - 3).ToString() + "年度）";
            targetTable.Columns["GrossProfit6"].Caption = "過年度実績・粗利（" + (this._custPastExperienceAcs.FiscalYear - 2).ToString() + "年度）";
            targetTable.Columns["GrossProfit7"].Caption = "過年度実績・粗利（" + (this._custPastExperienceAcs.FiscalYear - 1).ToString() + "年度）";
            targetTable.Columns["GrossProfit8"].Caption = "過年度実績・粗利（" + (this._custPastExperienceAcs.FiscalYear).ToString() + "年度）";


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
                Columns[i].Format = "";// ADD 2011/02/16
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

            if (status == 9)// 異常終了
            {
                // データセットをクリア
                this._dataSet.CustomInqResult.Clear();
                // グリッド列を設定
                InitializeGridColumns(this.uGrid_Details.DisplayLayout.Bands[0].Columns);
                // --------------------- UPD 2010/09/21 ------------>>>>>
                this.uGrid_Details.DataSource = _dViewBak;
                //if (isSearch)
                //{
                //    this.Search();
                //}
                // --------------------- UPD 2010/09/21 ------------<<<<<
                // 出力失敗
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Name,
                    "ファイルへの出力に失敗しました。", -1, MessageBoxButtons.OK);
                return false;
            }
            else
            {
                // データセットをクリア
                this._dataSet.CustomInqResult.Clear();
                // グリッド列を設定
                InitializeGridColumns(this.uGrid_Details.DisplayLayout.Bands[0].Columns);
                // --------------------- UPD 2010/09/21 ------------>>>>>
                this.uGrid_Details.DataSource = _dViewBak;
                //if (isSearch)
                //{
                //    this.Search();
                //}
                // --------------------- UPD 2010/09/21 ------------<<<<<
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
                textOutPutOprtnHisLogWorkObj.LogDataObjAssemblyID = CUSTOM_INQ_RESULT_PGID;
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
                string sectionCdSt = this._extractSetupFrm.SectionCodeSt;
                sectionCdSt = string.IsNullOrEmpty(sectionCdSt) ? StartStr : sectionCdSt;
                string sectionCdEd = this._extractSetupFrm.SectionCodeEd;
                sectionCdEd = string.IsNullOrEmpty(sectionCdEd) ? EndStr : sectionCdEd;
                // 得意先
                string customerCdSt = this._extractSetupFrm.CustomerCodeSt;
                customerCdSt = string.IsNullOrEmpty(customerCdSt) ? StartStr : customerCdSt;
                string customerCdEd = this._extractSetupFrm.CustomerCodeEd;
                customerCdEd = string.IsNullOrEmpty(customerCdEd) ? EndStr : customerCdEd;

                outPutCon = string.Format(Con, sectionCdSt, sectionCdEd, customerCdSt, customerCdEd, this._extractSetupFrm.SettingFileName);
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
        //----- ADD 2024/11/22 陳艶丹 PMKOBETSU-4368 2024年PKG格上のログ出力対応 ----<<<<<

        /// <summary>
        /// Excel出力処理
        /// </summary>
        /// <returns>True:正常; False:異常</returns>
        /// <br>Update Note :2024/11/22 陳艶丹</br>
        /// <br>             PMKOBETSU-4368 2024年PKG格上のログ出力対応</br>
        private bool outputExcelData()
        {
            if (this._extractSetupFrm.DResult == DialogResult.Cancel)
            {
                return true;
            }

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
                // テキスト出力操作ログ登録及び出力時アラートメッセージ表示処理「テキスト出力」
                logStatus = TextOutPutWrite((int)OperationCode.ExcelOut, ref textOutPutOprtnHisLogWorkObj, out errMsg);

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
                this._custPastExperienceAcs.SearchAll(this._enterpriseCode, this._extractSetupFrm.SectionCodeList, this._extractSetupFrm.SelectionCodeList);
                // グリッドで表示に使用するデータビューを作成
                DataView dataView = new DataView(this._dataSet.CustomInqResult);

                // データソースとしてデータビューを指定
                this.uGrid_Details.DataSource = dataView;
            }
            finally
            {
                processingDialog.Dispose();
            }
            if (this._dataSet.CustomInqResult.Count == 0)
            {
                // データセットをクリア
                this._dataSet.CustomInqResult.Clear();
                // グリッド列を設定
                InitializeGridColumns(this.uGrid_Details.DisplayLayout.Bands[0].Columns);
                // --------------------- UPD 2010/09/21 ------------>>>>>
                this.uGrid_Details.DataSource = _dViewBak;

                //if (isSearch)
                //{
                //    this.Search();
                //}
                // --------------------- UPD 2010/09/21 ------------<<<<<
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                    this.Name,
                    "条件に合致するデータが存在しません。",
                    -1,
                    MessageBoxButtons.OK);
                return false;
            }

            this.InitializeGridColumnsForOutput(this._custPastExperienceAcs.FiscalYear);

            try
            {
                if (this.ultraGridExcelExporter1.Export(this.uGrid_Details, this._extractSetupFrm.SettingFileName) != null)
                {
                    //----- ADD 2024/11/22 陳艶丹 PMKOBETSU-4368 2024年PKG格上のログ出力対応 ----->>>>>
                    //ログデータ抽出データ件数
                    int outputCount = this._dataSet.CustomInqResult.Count;
                    //----- ADD 2024/11/22 陳艶丹 PMKOBETSU-4368 2024年PKG格上のログ出力対応 -----<<<<<
                    // データセットをクリア
                    this._dataSet.CustomInqResult.Clear();
                    // グリッド列を設定
                    InitializeGridColumns(this.uGrid_Details.DisplayLayout.Bands[0].Columns);
                    // --------------------- UPD 2010/09/21 ------------>>>>>
                    this.uGrid_Details.DataSource = _dViewBak;
                    //if (isSearch)
                    //{
                    //    this.Search();
                    //}
                    // --------------------- UPD 2010/09/21 ------------<<<<<
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
                            DialogResult dialogResult = TMsgDisp.Show(form, emErrorLevel.ERR_LEVEL_STOP, this.Name,
                                        errMsg, logStatus, MessageBoxButtons.OK);
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
                // データセットをクリア
                this._dataSet.CustomInqResult.Clear();
                // グリッド列を設定
                InitializeGridColumns(this.uGrid_Details.DisplayLayout.Bands[0].Columns);
                // --------------------- UPD 2010/09/21 ------------>>>>>
                this.uGrid_Details.DataSource = _dViewBak;
                //if (isSearch)
                //{
                //    this.Search();
                //}
                // --------------------- UPD 2010/09/21 ------------<<<<<

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
        // --- ADD 2010/10/09 ----------<<<<<
        /// <summary>
        /// オプション情報キャッシュ
        /// </summary>
        /// <remarks>
        /// <br>Note       : オプション情報制御処理。</br>
        /// <br>Programmer : 姜凱</br>
        /// <br>Date       : 2010/07/19</br>
        /// </remarks>
        private void CacheOptionInfo()
        {
            Broadleaf.Application.Remoting.ParamData.PurchaseStatus textOutputPs;
            textOutputPs = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_TextOutput);
            if (textOutputPs == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                this._opt_TextOutput = 1;
            }
            else
            {
                this._opt_TextOutput = 0;
            }
            #region[テキスト出力、Excel出力]
            //テキスト出力オプションが有効の場合
            if (this._opt_TextOutput == 1)
            {
                // テキスト出力
                this.tToolbarsManager_MainMenu.Tools["ButtonTool_TextOutput"].SharedProps.Visible = true;
                // EXCEL出力
                this.tToolbarsManager_MainMenu.Tools["ButtonTool_ExcelOutput"].SharedProps.Visible = true;
                //設定画面
                this.tToolbarsManager_MainMenu.Tools["ButtonTool_Setup"].SharedProps.Visible = true; //ADD 2010/08/23
            }
            //テキスト出力オプションが無効の場合
            else
            {
                // テキスト出力
                this.tToolbarsManager_MainMenu.Tools["ButtonTool_TextOutput"].SharedProps.Visible = false;
                // EXCEL出力
                this.tToolbarsManager_MainMenu.Tools["ButtonTool_ExcelOutput"].SharedProps.Visible = false;
                //設定画面
                this.tToolbarsManager_MainMenu.Tools["ButtonTool_Setup"].SharedProps.Visible = false; //ADD 2010/08/23

            }
            #endregion
            if (!OpeAuthDictionary[OperationCode.TextOut])
            {
                this.tToolbarsManager_MainMenu.Tools["ButtonTool_TextOutput"].SharedProps.Visible = false;
                this.tToolbarsManager_MainMenu.Tools["ButtonTool_TextOutput"].SharedProps.Shortcut = Shortcut.None;
            }
            if (!OpeAuthDictionary[OperationCode.ExcelOut])
            {
                this.tToolbarsManager_MainMenu.Tools["ButtonTool_ExcelOutput"].SharedProps.Visible = false;
                this.tToolbarsManager_MainMenu.Tools["ButtonTool_ExcelOutput"].SharedProps.Shortcut = Shortcut.None;
            }
            if ((!OpeAuthDictionary[OperationCode.TextOut]) && (!OpeAuthDictionary[OperationCode.ExcelOut])) //ADD 2010/08/23
            {
                this.tToolbarsManager_MainMenu.Tools["ButtonTool_Setup"].SharedProps.Visible = false; //ADD 2010/08/23
            }
        }
        #endregion // プライベートメソッド

        # region [Excelエクスポータイベント処理]
        /// <summary>
        /// セルのコレクションイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <br>Note       : コンポーネントがクリックされたときに発生します。</br>
        /// <br>Programmer : 姜凱</br>
        /// <br>Date       : 2010/07/19</br>
        /// <br>Update Note: 2010/09/13 tianjw</br>
        /// <br>            ・テキスト出力対応　不具合対応#14643</br> 
        private void ultraGridExcelExporter1_CellExported(object sender, Infragistics.Win.UltraWinGrid.ExcelExport.CellExportedEventArgs e)
        {
            int index = e.CurrentRowIndex;
            for (int celIndex = 0; celIndex < 24; celIndex++)
            {
                IWorksheetCellFormat tmCF = e.CurrentWorksheet.Rows[index].Cells[celIndex].CellFormat;
                tmCF.FormatString = "#,###,##0;-#,###,##0;0";
                e.CurrentWorksheet.Rows[index].Cells[celIndex].CellFormat.SetFormatting(tmCF);
                // ------------------ADD 2010/09/13 --------------------------->>>>>
                if (celIndex < 3)
                {
                    e.CurrentWorksheet.Rows[index].Cells[celIndex].CellFormat.Alignment = HorizontalCellAlignment.Left;
                }
                // ------------------ADD 2010/09/13 ---------------------------<<<<<
            }
        }
        # endregion

        // ---------------------- ADD 2010/07/20 ---------------------------------<<<<<
    }
}