//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 担当者別実績照会
// プログラム概要   : 担当者別実績照会一覧を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 汪千来
// 作 成 日  2009/04/01  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 王開強
// 修 正 日  2010/07/20  修正内容 : テキスト出力
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : chenyd
// 修 正 日  2010/08/12  修正内容 : 障害ID:13038 テキスト出力対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 朱 猛
// 修 正 日  2010/10/09  修正内容 : 障害ID:15880対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : liyp
// 修 正 日  2011/02/16  修正内容 : テキスト出力対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 陳艶丹
// 修 正 日  2024/11/29  修正内容 : PMKOBETSU-4368 2024年PKG格上のログ出力対応
//----------------------------------------------------------------------------//


using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Remoting.ParamData;//ADD 2024/11/29 陳艶丹 PMKOBETSU-4368 2024年PKG格上のログ出力対応
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Globarization;
using System.Net.NetworkInformation;
using Broadleaf.Application.Controller;
using Broadleaf.Application; // ADD 2010/07/20
using Infragistics.Excel; // ADD 2010/07/20
using Infragistics.Win.UltraWinGrid; // ADD 2010/07/20
using Broadleaf.Application.Controller.Facade; // ADD 2010/07/20

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 担当者別実績照会 入力フォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 担当者別実績照会入力フォームクラスです。</br>
    /// <br>Programmer : 汪千来</br>
    /// <br>Date       : 2009.04.01</br>
    /// <br>Update Note: 2010/08/12、2010/08/20 chenyd</br>
    /// <br>            ・障害ID:13038 テキスト出力対応</br>
    /// <br>Update Note: 2010/08/23 chenyd</br>
    /// <br>            ・テキスト出力対応13482</br>
    /// <br>Update Note: 2010/09/21 zhume</br>
    /// <br>            ・テキスト出力対応14876</br>
    /// <br>Update Note:2011/02/16 liyp</br>
    /// <br>            テキスト出力対応</br>
    /// <br>Update Note: 2024/11/29 陳艶丹</br>
    /// <br>            ・PMKOBETSU-4368 2024年PKG格上のログ出力対応</br>
    /// </remarks>
    public partial class PMHNB04161UA : Form
    {
        #region ■  Private Members
        /// <summary>イメージリスト</summary>
        /// <remarks></remarks>
        private ImageList _imageList16 = null;

        /// <summary>PMHNB04161UBオブジェクト</summary>
        /// <remarks></remarks>
        private PMHNB04161UB _inputDetails;

        /// <summary>従業員マスタアクセスクラス</summary>
        /// <remarks></remarks>
        private EmployeeAcs _employeeAcs;

        /// <summary>自拠点</summary>
        /// <remarks></remarks>
        private string _loginSectionCode;

        /// <summary>拠点アクセスクラス</summary>
        /// <remarks></remarks>
        private SecInfoSetAcs _secInfoSetAcs;


        private DialogResult _dialogRes = DialogResult.Cancel;


        private Control _prevControl = null;

        /// <summary>拠点コンボボックス</summary>
        /// <remarks></remarks>
        private Infragistics.Win.UltraWinToolbars.ComboBoxTool _sectionComboBox;

        /// <summary>担当者別実績照会 データクラス</summary>
        /// <remarks></remarks>
        private EmployeeResultsCtdtn _EmployeeResultsCtdtn;

        /// <summary>企業コード</summary>
        /// <remarks></remarks>
        private string _enterpriseCode;

        /// <summary>担当者別実績照会 条件データキャッシュ</summary>
        /// <remarks></remarks>
        private EmployeeResultsCtdtn _paraEmployeeResultsSlipCache_Display;

        //日付取得部品
        private DateGetAcs _dateGet;

        /// <summary>担当者別実績照会 テーブルアクセスクラス</summary>
        /// <remarks></remarks> 
        private EmployeeResultsAcs _employeeResultsAcs = null;
        // --- ADD 2010/07/20-------------------------------->>>>>
        private PMHNB04161UC _extractSetupFrm = null;           // 出力条件設定画面

        private PMHNB04161UD _userSetupFrm = null;            // ユーザー設定画面

        /// <summary>テキスト出力オプション情報</summary>
        private int _opt_TextOutput;

        private IOperationAuthority _operationAuthority;    // 操作権限の制御オブジェクト
        private Dictionary<OperationCode, bool> _operationAuthorityList;  // 操作権限の制御リスト(直接参照すると遅いのでディクショナリ化)
        // --- ADD 2010/07/20--------------------------------<<<<<
        private bool checkFlg = false; //  ADD 2010/08/12 障害ID:13038対応

        private bool isSearch = false;                          // 検索ボタンをクリックするかどうか  // ADD 2010/09/14

        private bool isError = false; // ADD 2010/09/25

        private string _employeeCodeSt = string.Empty; // ADD 2010/09/28 障害報告 #15609 
        private string _employeeCodeEd = string.Empty; // ADD 2010/09/28 障害報告 #15609 
        private string _sectionCodeAllowZero = string.Empty; // ADD 2010/09/28 障害報告 #15609 

        //--- ADD 2024/11/29 陳艶丹 PMKOBETSU-4368 2024年PKG格上のログ出力対応 ---->>>>>
        private TextOutPutOprtnHisLogAcs TextOutPutOprtnHisLogAcsObj = null;
        //--- ADD 2024/11/29 陳艶丹 PMKOBETSU-4368 2024年PKG格上のログ出力対応 ----<<<<<
        #endregion

        # region ■ Private const

        ///// <summary> 日付違う</summary>
        ////private const string ct_InputError = "日付の指定に誤りがあります。";
        /// <summary> 範囲チェック</summary>
        private const string MESSAGE_StartEndError = "開始≦終了となるよう設定してください。";
        /// <summary> 必須入力チェック</summary>
        private const string MESSAGE_NoInput = "を入力してください。";
        /// <summary> 有効な日付チェック</summary>
        private const string MESSAGE_InvalidDate = "有効な日付ではありません。";
        /// <summary> 全社コード [00] </summary>
        private const string WHOLE_SECTION_CODE = "00";
        /// <summary> 全社名称 [全社] </summary>
        private const string WHOLE_SECTION_NAME = "全社";
        /// <summary> 名称 [担当者] </summary>
        private const string SALESINPUT_NAME = "担当者";
        /// <summary> 名称 [受注者] </summary>
        private const string FRONTEMPLOYEE_SECTION_NAME = "受注者";
        /// <summary> 名称 [発行者] </summary>
        private const string SALESEMPLOYEE_NAME = "発行者";

        //--- ADD 2024/11/29 陳艶丹 PMKOBETSU-4368 2024年PKG格上のログ出力対応 ---->>>>>
        /// <summary> テキスト出力メソッド名</summary>
        private const string TEXT_METHODNM = "outputTextData";
        /// <summary> Excel出力メソッド名</summary>
        private const string EXCEL_METHODNM = "outputExcelData";
        /// <summary> 期間区分 [日計] </summary>
        private const string DURINGDIV_DAILY = "日計";
        /// <summary> 期間区分 [月計] </summary>
        private const string DURINGDIV_MOONGAUGE = "月計";
        /// <summary> 期間区分 [当期] </summary>
        private const string DURINGDIV_CURRENTPERIOD = "当期";
        /// <summary> 出力件数</summary>
        private const string COUNTNUMSTR = "データ出力件数:{0},";
        /// <summary>担当者別実績照会PGID</summary>
        private const string CT_EMPLOYEE_RESULT_PGID = "PMHNB04161U";
        /// <summary> アセンブリ名</summary>
        private const string ASSEMBLYNM = "担当者別実績照会";
        /// <summary> テキストとExcel出力条件</summary>
        private const string OUTPUTCON = "参照区分:{0},期間区分:{1},拠点:{2} ～ {3},{0}:{4} ～ {5},期間:{6} ～ {7},出力ファイル名:{8}";
        /// <summary> テキストとExcel出力条件2</summary>
        private const string OUTPUTCON2 = "参照区分:{0},期間区分:{1},拠点:{2} ～ {3},{0}:{4} ～ {5},出力ファイル名:{6}";
        /// <summary> 最初から</summary>
        private const string STARTSTR = "最初から";
        /// <summary> 最後まで</summary>
        private const string ENDSTR = "最後まで";
        //--- ADD 2024/11/29 陳艶丹 PMKOBETSU-4368 2024年PKG格上のログ出力対応 ----<<<<<

        //エラー条件メッセージ
        const string ct_InputError = "の指定に誤りがあります。";
        const string ct_NoInput = "を入力して下さい。";
        const string ct_RangeError = "の範囲指定に誤りがあります。";
        const string ct_RangeOverError = "は締日より１ヶ月の範囲内で入力して下さい。";

        const string ct_RangeYearMonthOverError = "は12か月以内で入力して下さい。";
        const string ct_NotOnYearError = "が同一年度内ではありません。";
        const string ct_NotOnMonthError = "が同一月内ではありません。";

        /// <summary>検索時メッセージ「条件に合致するデータが存在しません。」</summary>
        private const string MSG_MATCHED_DATA_NOT_FOUND = "条件に合致するデータが存在しません。"; // ADD 2010/07/20
        /// <summary>チェック時メッセージ「出力ファイル名が指定されていません。設定ボタンから設定を行ってください。」</summary>
        private const string MSG_OUTPUTFILENAME_NOTFOUND = "出力ファイル名が指定されていません。設定ボタンから設定を行ってください。"; // ADD 2010/07/20

        # endregion

        #region ■ Constroctors
        /// <summary>
        /// 担当者別実績照会 入力フォームクラスクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 担当者別実績照会 入力フォームクラスクラスのコンストラクタです</br>
        /// <br>Programmer : 汪千来</br>
        /// <br>Date       : 2009.04.01</br>
        /// <br>Update Note: 2024/11/29 陳艶丹</br>
        /// <br>管理番号   : 12070203-00</br>
        /// <br>           : PMKOBETSU-4368 2024年PKG格上のログ出力対応</br>
        /// </remarks>
        public PMHNB04161UA()
        {
            InitializeComponent();

            _EmployeeResultsCtdtn = new EmployeeResultsCtdtn();

            //日付取得部品
            this._dateGet = DateGetAcs.GetInstance();

            this._inputDetails = new PMHNB04161UB();
            this._imageList16 = IconResourceManagement.ImageList16;
            this._employeeResultsAcs = EmployeeResultsAcs.GetInstance();
            this._paraEmployeeResultsSlipCache_Display = new EmployeeResultsCtdtn();
            if (this._employeeResultsAcs.GetParaEmployeeResultsSlipCache() != null)
            {
                this._paraEmployeeResultsSlipCache_Display = this._employeeResultsAcs.GetParaEmployeeResultsSlipCache();
            }
            //this._employeeResultsAcs.StatusBarMessageSetting += new EmployeeResultsAcs.SettingStatusBarMessageEventHandler(this.SetStatusBarMessage);
            this._sectionComboBox = (Infragistics.Win.UltraWinToolbars.ComboBoxTool)this.tToolbarsManager_MainMenu.Tools["ComboBoxTool_SectionCode"];

            // テキスト出力オプションの制御　// ADD 2010/07/20
            this.CacheOptionInfo();　// ADD 2010/07/20
            //--- ADD 2024/11/29 陳艶丹 PMKOBETSU-4368 2024年PKG格上のログ出力対応---->>>>>
            TextOutPutOprtnHisLogAcsObj = new TextOutPutOprtnHisLogAcs();//テキスト出力操作ログおよび出力時アラートメッセージ表示処理の対象
            //--- ADD 2024/11/29 陳艶丹 PMKOBETSU-4368 2024年PKG格上のログ出力対応----<<<<<
        }
        #endregion

        #region ■ Private Methods
        // --- ADD 2010/07/20-------------------------------->>>>>
        /// <summary>
        /// オプション情報キャッシュ
        /// </summary>
        /// <remarks>
        /// <br>Note       : オプション情報制御処理。</br>
        /// <br>Programmer : 王開強</br>
        /// <br>Date       : 2010/07/20</br>
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
                this.tToolbarsManager_MainMenu.Tools["ButtonTool_Text"].SharedProps.Visible = true;
                // EXCEL出力
                this.tToolbarsManager_MainMenu.Tools["ButtonTool_Excel"].SharedProps.Visible = true;
                // 設定
                this.tToolbarsManager_MainMenu.Tools["ButtonTool_Setup"].SharedProps.Visible = true;
            }
            //テキスト出力オプションが無効の場合
            else
            {
                // テキスト出力
                this.tToolbarsManager_MainMenu.Tools["ButtonTool_Text"].SharedProps.Visible = false;
                // EXCEL出力
                this.tToolbarsManager_MainMenu.Tools["ButtonTool_Excel"].SharedProps.Visible = false;
                // 設定
                this.tToolbarsManager_MainMenu.Tools["ButtonTool_Setup"].SharedProps.Visible = false;
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
                // 設定
                this.tToolbarsManager_MainMenu.Tools["ButtonTool_Setup"].SharedProps.Visible = false; // ADD 2010/08/23
            }
            #endregion
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

        /// <summary>操作権限の制御オブジェクト</summary>
        private IOperationAuthority MyOpeCtrl
        {
            get
            {
                if (_operationAuthority == null)
                {
                    _operationAuthority = OpeAuthCtrlFacade.CreateReferenceOperationAuthority("PMHNB04160U", this);
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
        // --- ADD 2010/07/20 --------------------------------<<<<<

        /// <summary>
        /// ツールバー初期設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : ツールバーの初期値を設定する</br>
        /// <br>Programmer : 汪千来</br>
        /// <br>Date       : 2009.04.01</br>
        /// </remarks>
        private void ToolBarInitilSetting()
        {
            if (_secInfoSetAcs == null)
            {
                _secInfoSetAcs = new SecInfoSetAcs();
            }

            SecInfoSet secInfoSet;
            int status = this._secInfoSetAcs.Read(out secInfoSet, this._enterpriseCode, this._loginSectionCode);

            // ログイン担当者拠点名称の設定
            Infragistics.Win.UltraWinToolbars.LabelTool loginSectionNameLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)tToolbarsManager_MainMenu.Tools["Label_SectionName"];
            //loginSectionNameLabel.SharedProps.Caption = LoginInfoAcquisition.Employee.BelongSectionName;
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                loginSectionNameLabel.SharedProps.Caption = secInfoSet.SectionGuideNm;
            }
            loginSectionNameLabel.SharedProps.Visible = true;

            // ログイン担当者の設定
            Infragistics.Win.UltraWinToolbars.LabelTool loginNameLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)tToolbarsManager_MainMenu.Tools["LabelTool_LoginName"];
            loginNameLabel.SharedProps.Caption = LoginInfoAcquisition.Employee.Name;
        }

        /// <summary>
        /// コンボボックスの設定
        /// </summary>
        /// <remarks>
        /// <br>Note       : コンボボックスを設定する</br>
        /// <br>Programmer : 汪千来</br>
        /// <br>Date       : 2009.04.01</br>
        /// </remarks>
        private void ComboInitialSetting()
        {
            //参照区分
            this.tComboEditor_Refer.Items.Clear();
            this.tComboEditor_Refer.Items.Add(1, "担当者");
            this.tComboEditor_Refer.Items.Add(2, "受注者");
            this.tComboEditor_Refer.Items.Add(3, "発行者");
            this.tComboEditor_Refer.MaxDropDownItems = this.tComboEditor_Refer.Items.Count;
            this.tComboEditor_Refer.SelectedIndex = 0;

            //期間区分
            this.tComboEditor_During.Items.Clear();
            this.tComboEditor_During.Items.Add(1, "日計");
            this.tComboEditor_During.Items.Add(2, "月計");
            this.tComboEditor_During.Items.Add(3, "当期");
            this.tComboEditor_During.MaxDropDownItems = this.tComboEditor_During.Items.Count;
            this.tComboEditor_During.SelectedIndex = 0;
        }

        /// <summary>
        /// アイコンの設定
        /// </summary>
        /// <remarks>
        /// <br>Note       : アイコンを設定する</br>
        /// <br>Programmer : 汪千来</br>
        /// <br>Date       : 2009.04.01</br>
        /// </remarks>
        private void ButtonInitialSetting()
        {
            this.tToolbarsManager_MainMenu.ImageListSmall = this._imageList16;

            Infragistics.Win.UltraWinToolbars.ButtonTool closeButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Close"];
            Infragistics.Win.UltraWinToolbars.ButtonTool searchButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Search"];
            Infragistics.Win.UltraWinToolbars.ButtonTool clearButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Clear"];
            Infragistics.Win.UltraWinToolbars.LabelTool sectionLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)this.tToolbarsManager_MainMenu.Tools["LabelTool_SectionTitle"];
            Infragistics.Win.UltraWinToolbars.LabelTool loginLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)this.tToolbarsManager_MainMenu.Tools["LabelTool_LoginTitle"];
            // --- ADD 2010/07/20-------------------------------->>>>>
            Infragistics.Win.UltraWinToolbars.ButtonTool textButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Text"];
            Infragistics.Win.UltraWinToolbars.ButtonTool excelButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Excel"];
            Infragistics.Win.UltraWinToolbars.ButtonTool setUpButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Setup"];
            // --- ADD 2010/07/20 --------------------------------<<<<<

            closeButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
            searchButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SEARCH;
            clearButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.ALLCANCEL;
            sectionLabel.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.BASE;
            loginLabel.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.EMPLOYEE;
            // --- ADD 2010/07/20-------------------------------->>>>>
            textButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CSVOUTPUT;
            excelButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CSVOUTPUT;
            setUpButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SETUP1;
            // --- ADD 2010/07/20 --------------------------------<<<<<


            this.uButton_Section.ImageList = this._imageList16;
            this.uButton_St_EmployeeCode.ImageList = this._imageList16;
            this.ultraButton_Ed_EmployeeCode.ImageList = this._imageList16;

            this.uButton_Section.Appearance.Image = (int)Size16_Index.STAR1;
            this.uButton_St_EmployeeCode.Appearance.Image = (int)Size16_Index.STAR1;
            this.ultraButton_Ed_EmployeeCode.Appearance.Image = (int)Size16_Index.STAR1;

        }

        /// <summary>
        /// ステータスバーメッセージ表示イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="message">メッセージ</param>
        /// <remarks>
        /// <br>Note       :ステータスバーメッセージ表示イベントを行う。 </br>
        /// <br>Programmer : 汪千来</br>
        /// <br>Date       : 2009.04.01</br>
        /// </remarks>
        private void SetStatusBarMessage(object sender, string message)
        {
            this.uStatusBar_Main.Panels[0].Text = message;
        }

        # region [ChangeFocus]
        /// <summary>
        /// 矢印キーでのフォーカス移動イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : 矢印キーでのフォーカス移動イベントを行います。</br>
        /// <br>Programmer : 汪千来</br>
        /// <br>Date       : 2009.04.01</br>
        /// <br>Update Note: 2010/09/21 zhume</br>
        /// <br>             Redmine#14876 テキスト出力対応</br>
        /// </remarks>
        private void tRetKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null) return;
            this._prevControl = e.NextCtrl;

            SetStatusBarMessage(this, "");

            // 名称取得 ============================================ //
            # region [名称取得]
            switch (e.PrevCtrl.Name)
            {
                //-----------------------------------------------------
                // 拠点
                //-----------------------------------------------------
                case "tEdit_SectionCodeAllowZero":
                    {
                        if (!WHOLE_SECTION_CODE.Equals(tEdit_SectionCodeAllowZero.Text))
                        {
                            // オフライン状態チェック	
                            // オフライン状態チェック	
                            if (!CheckOnline())
                            {
                                TMsgDisp.Show(
                                    emErrorLevel.ERR_LEVEL_STOP,
                                    "拠点",
                                    "拠点" + "データ読み込みに失敗しました。",
                                    (int)ConstantManagement.DB_Status.ctDB_OFFLINE, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);

                                tEdit_SectionCodeAllowZero.Text = _paraEmployeeResultsSlipCache_Display.SectionCode;
                                uLabel_SectionName.Text = _paraEmployeeResultsSlipCache_Display.SectionCodeNm;
                                break;
                            }
                        }
                        else
                        {
                            tEdit_SectionCodeAllowZero.Text = WHOLE_SECTION_CODE;
                            uLabel_SectionName.Text = WHOLE_SECTION_NAME;
                            _paraEmployeeResultsSlipCache_Display.SectionCode = WHOLE_SECTION_CODE;
                            _paraEmployeeResultsSlipCache_Display.SectionCodeNm = WHOLE_SECTION_NAME;

                            if (!e.ShiftKey)
                            {
                                // NextCtrl制御
                                switch (e.Key)
                                {
                                    case Keys.Return:
                                    case Keys.Tab:
                                        {
                                            e.NextCtrl = this.tComboEditor_Refer;
                                            break;
                                        }
                                }
                            }
                            else
                            {
                                int DuringType = Convert.ToInt32(tComboEditor_During.SelectedItem.DataValue);
                                if (1 == DuringType)
                                {
                                    if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                                    {
                                        // 移動し
                                        e.NextCtrl = this.tDateEdit_Ed_During;
                                    }
                                }
                                else if (2 == DuringType)
                                {
                                    if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                                    {
                                        // 移動し
                                        e.NextCtrl = this.tDateEdit_Ed_YearMonth;
                                    }
                                }
                                else if (3 == DuringType)
                                {
                                    if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                                    {
                                        // 移動し
                                        e.NextCtrl = this.tComboEditor_During;
                                    }
                                }
                            }
                        }

                        # region [拠点]

                        bool status;

                        if (tEdit_SectionCodeAllowZero.Text == _paraEmployeeResultsSlipCache_Display.SectionCode
                            && (!string.IsNullOrEmpty(uLabel_SectionName.Text)) && (WHOLE_SECTION_NAME.Equals(uLabel_SectionName.Text)))
                        {
                            _paraEmployeeResultsSlipCache_Display.SectionCode = WHOLE_SECTION_CODE;
                            _paraEmployeeResultsSlipCache_Display.SectionCodeNm = WHOLE_SECTION_NAME;
                            this.tEdit_SectionCodeAllowZero.Text = WHOLE_SECTION_CODE;
                            this.uLabel_SectionName.Text = WHOLE_SECTION_NAME;
                            status = true;
                            break;
                        }
                        else
                        {
                            string zeroSec = tEdit_SectionCodeAllowZero.Text.Trim().PadLeft(2, '0');
                            if (!string.IsNullOrEmpty(tEdit_SectionCodeAllowZero.Text))
                            {

                                string code;
                                string name;

                                // 拠点読み込み
                                //status = ReadSection(tEdit_SectionCodeAllowZero.Text, out code, out name);
                                status = ReadSection(zeroSec, out code, out name);

                                // コード・名称を更新
                                if (status)
                                {
                                    tEdit_SectionCodeAllowZero.Text = code.TrimEnd();
                                    _paraEmployeeResultsSlipCache_Display.SectionCode = code.TrimEnd();
                                    if (!string.IsNullOrEmpty(name))
                                    {
                                        _paraEmployeeResultsSlipCache_Display.SectionCodeNm = name.TrimEnd();
                                    }
                                    uLabel_SectionName.Text = name;
                                }
                            }
                            else
                            {
                                // パラメータに保存
                                tEdit_SectionCodeAllowZero.Text = WHOLE_SECTION_CODE;
                                _paraEmployeeResultsSlipCache_Display.SectionCode = WHOLE_SECTION_CODE;
                                _paraEmployeeResultsSlipCache_Display.SectionCodeNm = WHOLE_SECTION_NAME;
                                uLabel_SectionName.Text = WHOLE_SECTION_NAME;
                                status = true;
                            }
                        }

                        if (status == true)
                        {
                            isError = false; // ADD 2010/09/21
                            if (!e.ShiftKey)
                            {
                                // NextCtrl制御
                                switch (e.Key)
                                {
                                    case Keys.Return:
                                    case Keys.Tab:
                                        {
                                            //if (_paraEmployeeResultsSlipCache_Display.SectionCode == WHOLE_SECTION_NAME)
                                            //{
                                            //    e.NextCtrl = this.uButton_Section;
                                            //}
                                            //else
                                            //{
                                            e.NextCtrl = this.tComboEditor_Refer;
                                            //}
                                            break;
                                        }
                                }
                            }
                            else
                            {
                                int DuringType = Convert.ToInt32(tComboEditor_During.SelectedItem.DataValue);
                                if (1 == DuringType)
                                {
                                    if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                                    {
                                        // 移動し
                                        e.NextCtrl = this.tDateEdit_Ed_During;
                                    }
                                }
                                else if (2 == DuringType)
                                {
                                    if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                                    {
                                        // 移動し
                                        e.NextCtrl = this.tDateEdit_Ed_YearMonth;
                                    }
                                }
                                else if (3 == DuringType)
                                {
                                    if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                                    {
                                        // 移動し
                                        e.NextCtrl = this.tComboEditor_During;
                                    }
                                }
                            }
                        }
                        else
                        {
                            e.NextCtrl = e.PrevCtrl;
                            tEdit_SectionCodeAllowZero.Text = _paraEmployeeResultsSlipCache_Display.SectionCode;
                            uLabel_SectionName.Text = _paraEmployeeResultsSlipCache_Display.SectionCodeNm;
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "拠点が存在しません。",
                                -1,
                                MessageBoxButtons.OK);
                            checkFlg = true; //ADD 2010/08/12 障害ID:13038対応
                            isError = true; // ADD 2010/09/21
                        }
                        # endregion
                    }
                    break;
                //-----------------------------------------------------
                // 担当者(開始)
                //-----------------------------------------------------
                case "tEdit_EmployeeCode_St":
                    {
                        if (!string.IsNullOrEmpty(tEdit_EmployeeCode_St.DataText))
                        {
                            // オフライン状態チェック	
                            if (!CheckOnline())
                            {
                                // オフライン状態チェック	
                                if (!CheckOnline())
                                {
                                    TMsgDisp.Show(
                                        emErrorLevel.ERR_LEVEL_STOP,
                                        "担当者(開始)",
                                        "担当者(開始)" + "データ読み込みに失敗しました。",
                                        (int)ConstantManagement.DB_Status.ctDB_OFFLINE, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                                }
                                tEdit_EmployeeCode_St.DataText = _paraEmployeeResultsSlipCache_Display.St_EmployeeCode;
                                uLabel_SalesEmployeeNm_St.Text = _paraEmployeeResultsSlipCache_Display.St_EmployeeCodeNm;
                                break;
                            }
                        }
                        else
                        {
                            tEdit_EmployeeCode_St.DataText = string.Empty;
                            uLabel_SalesEmployeeNm_St.Text = string.Empty;
                            _paraEmployeeResultsSlipCache_Display.St_EmployeeCode = string.Empty;
                            _paraEmployeeResultsSlipCache_Display.St_EmployeeCodeNm = string.Empty;
                            break;
                        }

                        # region [担当者]
                        bool status;

                        // 入力無し
                        if (string.IsNullOrEmpty(this.tEdit_EmployeeCode_St.Text.Trim()))
                        {
                            // 設定値保存、名称のクリア
                            _paraEmployeeResultsSlipCache_Display.St_EmployeeCode = string.Empty;
                            _paraEmployeeResultsSlipCache_Display.St_EmployeeCodeNm = string.Empty;
                            this.uLabel_SalesEmployeeNm_St.Text = string.Empty;
                            this.tEdit_EmployeeCode_St.Text = string.Empty;
                            status = true;

                            break;
                        }

                        string zerotcode_St = tEdit_EmployeeCode_St.Text.Trim().PadLeft(4, '0');
                        tEdit_EmployeeCode_St.Text = zerotcode_St; // ADD 2010/09/21
                        if ((zerotcode_St.Equals(_paraEmployeeResultsSlipCache_Display.St_EmployeeCode))
                            && (!string.IsNullOrEmpty(uLabel_SalesEmployeeNm_St.Text)))
                        {
                            status = true;
                        }
                        else
                        {
                            string code;
                            string name;

                            // 読み込み
                            status = ReadEmployee(zerotcode_St, out code, out name);

                            // コード・名称を更新
                            if (status)
                            {
                                //tEdit_EmployeeCode_St.Text = code.TrimEnd();
                                if (!string.IsNullOrEmpty(name))
                                {
                                    uLabel_SalesEmployeeNm_St.Text = name.TrimEnd();
                                }
                                _paraEmployeeResultsSlipCache_Display.St_EmployeeCode = code.TrimEnd();

                                if (!string.IsNullOrEmpty(name))
                                {
                                    _paraEmployeeResultsSlipCache_Display.St_EmployeeCodeNm = name.TrimEnd();
                                }
                            }
                            //uLabel_StockAgentName.Text = name;
                        }

                        if (status == true)
                        {
                            isError = false; // ADD 2010/09/21
                            if (!e.ShiftKey)
                            {
                                // NextCtrl制御
                                switch (e.Key)
                                {
                                    case Keys.Return:
                                    case Keys.Tab:
                                        {
                                            if (_paraEmployeeResultsSlipCache_Display.St_EmployeeCode == string.Empty)
                                            {
                                                e.NextCtrl = this.uButton_St_EmployeeCode;
                                            }
                                            else
                                            {
                                                e.NextCtrl = this.tEdit_EmployeeCode_Ed;
                                            }
                                            break;
                                        }
                                }
                            }
                        }
                        else
                        {
                            e.NextCtrl = e.PrevCtrl;
                            tEdit_EmployeeCode_St.DataText = _paraEmployeeResultsSlipCache_Display.St_EmployeeCode;
                            uLabel_SalesEmployeeNm_St.Text = _paraEmployeeResultsSlipCache_Display.St_EmployeeCodeNm;
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "従業員が存在しません。",
                                -1,
                                MessageBoxButtons.OK);
                            checkFlg = true; //ADD 2010/08/12 障害ID:13038対応
                            isError = true; // ADD 2010/09/21
                        }
                        # endregion
                    }
                    break;
                //-----------------------------------------------------
                // 担当者(終了)
                //-----------------------------------------------------
                case "tEdit_EmployeeCode_Ed":
                    {
                        if (!string.IsNullOrEmpty(tEdit_EmployeeCode_Ed.DataText))
                        {
                            // オフライン状態チェック	
                            if (!CheckOnline())
                            {
                                // オフライン状態チェック	
                                if (!CheckOnline())
                                {
                                    TMsgDisp.Show(
                                        emErrorLevel.ERR_LEVEL_STOP,
                                        "担当者(終了)",
                                        "担当者(終了)" + "データ読み込みに失敗しました。",
                                        (int)ConstantManagement.DB_Status.ctDB_OFFLINE, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                                }
                                tEdit_EmployeeCode_Ed.DataText = _paraEmployeeResultsSlipCache_Display.Ed_EmployeeCode;
                                uLabel_SalesEmployeeNm_Ed.Text = _paraEmployeeResultsSlipCache_Display.Ed_EmployeeCodeNm;
                                break;
                            }
                        }
                        else
                        {
                            tEdit_EmployeeCode_Ed.DataText = string.Empty;
                            uLabel_SalesEmployeeNm_Ed.Text = string.Empty;
                            _paraEmployeeResultsSlipCache_Display.Ed_EmployeeCode = string.Empty;
                            _paraEmployeeResultsSlipCache_Display.Ed_EmployeeCodeNm = string.Empty;
                            break;
                        }

                        # region [担当者]
                        bool status;

                        // 入力無し
                        if (string.IsNullOrEmpty(this.tEdit_EmployeeCode_Ed.Text.Trim()))
                        {
                            // 設定値保存、名称のクリア
                            _paraEmployeeResultsSlipCache_Display.Ed_EmployeeCode = string.Empty;
                            _paraEmployeeResultsSlipCache_Display.Ed_EmployeeCodeNm = string.Empty;
                            this.uLabel_SalesEmployeeNm_Ed.Text = string.Empty;
                            this.tEdit_EmployeeCode_Ed.Text = string.Empty;
                            status = true;

                            break;
                        }

                        string zerotcode_Ed = tEdit_EmployeeCode_Ed.Text.Trim().PadLeft(4, '0');
                        tEdit_EmployeeCode_Ed.Text = zerotcode_Ed; // ADD 2010/09/21
                        if ((zerotcode_Ed.Equals(_paraEmployeeResultsSlipCache_Display.Ed_EmployeeCode))
                            && (!string.IsNullOrEmpty(uLabel_SalesEmployeeNm_Ed.Text)))
                        {
                            status = true;
                        }
                        else
                        {
                            string code;
                            string name;

                            // 読み込み
                            status = ReadEmployee(zerotcode_Ed, out code, out name);

                            // コード・名称を更新
                            if (status)
                            {
                                //tEdit_EmployeeCode_Ed.Text = code.TrimEnd();
                                _paraEmployeeResultsSlipCache_Display.Ed_EmployeeCode = code.TrimEnd();
                                if (!string.IsNullOrEmpty(name))
                                {
                                    uLabel_SalesEmployeeNm_Ed.Text = name.TrimEnd();
                                    _paraEmployeeResultsSlipCache_Display.Ed_EmployeeCodeNm = name.TrimEnd();
                                }
                            }
                            //uLabel_StockAgentName.Text = name;
                        }

                        if (status == true)
                        {
                            isError = false; // ADD 2010/09/21
                            if (!e.ShiftKey)
                            {
                                // NextCtrl制御
                                switch (e.Key)
                                {
                                    case Keys.Return:
                                    case Keys.Tab:
                                        {
                                            if (_paraEmployeeResultsSlipCache_Display.Ed_EmployeeCode == string.Empty)
                                            {
                                                e.NextCtrl = this.ultraButton_Ed_EmployeeCode;
                                            }
                                            else
                                            {
                                                e.NextCtrl = this.tComboEditor_During;
                                            }
                                            break;
                                        }
                                }
                            }
                            else
                            {
                                if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                                {
                                    // 移動し
                                    if (string.IsNullOrEmpty(uLabel_SalesEmployeeNm_St.Text))
                                    {
                                        e.NextCtrl = this.uButton_St_EmployeeCode;
                                    }
                                    else
                                    {
                                        e.NextCtrl = this.tEdit_EmployeeCode_St;
                                    }
                                }
                            }
                        }
                        else
                        {
                            e.NextCtrl = e.PrevCtrl;
                            tEdit_EmployeeCode_Ed.DataText = _paraEmployeeResultsSlipCache_Display.Ed_EmployeeCode;
                            uLabel_SalesEmployeeNm_Ed.Text = _paraEmployeeResultsSlipCache_Display.Ed_EmployeeCodeNm;
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "従業員が存在しません。",
                                -1,
                                MessageBoxButtons.OK);
                            checkFlg = true; //ADD 2010/08/12 障害ID:13038対応
                            isError = true; // ADD 2010/09/21
                        }
                        # endregion
                    }
                    break;
                //-----------------------------------------------------
                // 期間（終了）
                //-----------------------------------------------------
                case "tDateEdit_Ed_During":
                case "tDateEdit_Ed_YearMonth":
                    {
                        # region [フォーカス制御]
                        // フォーカス制御
                        if (!e.ShiftKey)
                        {
                            // NextCtrl制御
                            switch (e.Key)
                            {
                                case Keys.Return:
                                case Keys.Tab:
                                    {
                                        // 移動しない
                                        e.NextCtrl = this._inputDetails;
                                        break;
                                    }
                            }
                        }
                        else
                        {
                            int DuringType = Convert.ToInt32(tComboEditor_During.SelectedItem.DataValue);
                            if (1 == DuringType)
                            {
                                if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                                {
                                    // 移動し
                                    e.NextCtrl = this.tDateEdit_St_During;
                                }
                            }
                            else if (2 == DuringType)
                            {
                                if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                                {
                                    // 移動し
                                    e.NextCtrl = this.tDateEdit_St_YearMonth;
                                }
                            }
                            else if (3 == DuringType)
                            {
                                if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                                {
                                    // 移動し
                                    e.NextCtrl = this.tComboEditor_During;
                                }
                            }
                        }
                        # endregion
                    }
                    break;
                case "tComboEditor_During":
                    {
                        # region [フォーカス制御]
                        // フォーカス制御
                        if (e.ShiftKey)
                        {
                            // NextCtrl制御
                            switch (e.Key)
                            {
                                case Keys.Return:
                                case Keys.Tab:
                                    {
                                        // 移動しない
                                        if (string.IsNullOrEmpty(uLabel_SalesEmployeeNm_Ed.Text))
                                        {
                                            e.NextCtrl = this.ultraButton_Ed_EmployeeCode;
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.tEdit_EmployeeCode_Ed;
                                        }
                                        break;
                                    }
                            }
                        }
                        # endregion
                    }
                    break;
                case "tComboEditor_Refer":
                    {
                        # region [フォーカス制御]
                        // フォーカス制御
                        if (e.ShiftKey)
                        {
                            // NextCtrl制御
                            switch (e.Key)
                            {
                                case Keys.Return:
                                case Keys.Tab:
                                    {
                                        // 移動しない
                                        if (string.IsNullOrEmpty(uLabel_SectionName.Text))
                                        {
                                            e.NextCtrl = this.uButton_Section;
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.tEdit_SectionCodeAllowZero;
                                        }
                                        break;
                                    }
                            }
                        }
                        # endregion
                    }
                    break;
            }
            # endregion
        }

        # endregion [ChangeFocus]

        # region [ChangeFocus時のRead処理]
        /// <summary>
        /// 拠点Read
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="code">拠点コード</param>
        /// <param name="name">拠点名称</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 拠点Readを行う。 </br>
        /// <br>Programmer : 汪千来</br>
        /// <br>Date       : 2009.04.01</br>
        /// <br>Update Note: 2010/09/21 zhume</br>
        /// <br>             Redmine#14876 テキスト出力対応</br>
        /// </remarks>
        private bool ReadSection(string sectionCode, out string code, out string name)
        {
            bool result = false;

            // 未入力判定
            if (sectionCode != string.Empty && sectionCode != WHOLE_SECTION_CODE) // 2009.01.06 add [9693]
            {
                // 読み込み
                if (_secInfoSetAcs == null)
                {
                    _secInfoSetAcs = new SecInfoSetAcs();
                }
                SecInfoSet secInfoSet;
                int status = _secInfoSetAcs.Read(out secInfoSet, this._enterpriseCode, sectionCode);

                //if (status == 0 && secInfoSet != null) // DEL 2010/09/21
                if (status == 0 && secInfoSet != null && secInfoSet.LogicalDeleteCode == 0) // ADD 2010/09/21
                {
                    // 該当あり→表示
                    code = secInfoSet.SectionCode.TrimEnd();
                    name = secInfoSet.SectionGuideNm;

                    result = true;
                }
                else
                {
                    code = WHOLE_SECTION_CODE;
                    name = WHOLE_SECTION_NAME;

                    // ＮＧにする
                    result = false;
                }
            }
            else
            {
                code = WHOLE_SECTION_CODE;
                name = WHOLE_SECTION_NAME;

                result = true;
            }

            return result;
        }

        /// <summary>
        /// 従業員Read
        /// </summary>
        /// <param name="employeeCode">従業員コード</param>
        /// <param name="code">従業員コード</param>
        /// <param name="name">従業員名称</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 従業員Readを行う。 </br>
        /// <br>Programmer : 汪千来</br>
        /// <br>Date       : 2009.04.01</br>
        /// <br>Update Note: 2010/09/21 zhume</br>
        /// <br>             Redmine#14876 テキスト出力対応</br>
        /// </remarks>
        private bool ReadEmployee(string employeeCode, out string code, out string name)
        {
            bool result = false;

            // 未入力判定
            if (employeeCode != string.Empty)
            {
                // 読み込み
                if (_employeeAcs == null)
                {
                    _employeeAcs = new EmployeeAcs();
                }
                Employee employee;
                int status = _employeeAcs.Read(out employee, this._enterpriseCode, employeeCode);

                //if (status == 0 && employee != null) // DEL 2010/09/21
                if (status == 0 && employee != null && employee.LogicalDeleteCode == 0) // ADD 2010/09/21
                {
                    // 該当あり→表示
                    code = employee.EmployeeCode.TrimEnd();
                    name = employee.Name;

                    result = true;
                }
                else
                {
                    // 該当なし→クリア
                    code = string.Empty;
                    name = string.Empty;

                    // ＮＧにする
                    result = false;
                }
            }
            else
            {
                // 未入力→クリア
                code = string.Empty;
                name = string.Empty;

                result = true;
            }

            return result;
        }
        # endregion

        # region [入力チェック]
        /// <summary>
        /// 入力項目チェック処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 入力項目チェック処理を行う。 </br>
        /// <br>Programmer : 汪千来</br>
        /// <br>Date       : 2009.04.01</br>
        /// </remarks>
        //private Control CheckInputPara() // DEL 2010/07/20
        private Control CheckInputPara(bool msgFlg) // ADD 2010/07/20
        {
            string errMessage = null;

            # region 存在チェック
            //拠点コード
            string code;
            string name;
            bool existFlg = false;
            if (!string.IsNullOrEmpty(tEdit_SectionCodeAllowZero.Text))
            {
                // 拠点読み込み
                existFlg = ReadSection(tEdit_SectionCodeAllowZero.Text, out code, out name);
                if (!existFlg)
                {
                    errMessage = "該当する拠点が存在しません。";
                    if (msgFlg) // ADD 2010/07/20
                        TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                errMessage,
                                0,
                                MessageBoxButtons.OK);
                    tEdit_SectionCodeAllowZero.Focus();
                    return tEdit_SectionCodeAllowZero;
                }
            }

            //担当者コード（開始）＞　担当者コード（終了）のチェック
            if (!string.IsNullOrEmpty(tEdit_EmployeeCode_St.Text) && !string.IsNullOrEmpty(tEdit_EmployeeCode_Ed.Text))
            {
                if (tEdit_EmployeeCode_St.DataText.Trim().PadLeft(4, '0').CompareTo(
                    tEdit_EmployeeCode_Ed.DataText.Trim().PadLeft(4, '0')) >= 1)
                {
                    errMessage = "担当者範囲の指定に誤りがあります。";
                    if (msgFlg) // ADD 2010/07/20
                        TMsgDisp.Show(
                                    this,
                                    emErrorLevel.ERR_LEVEL_INFO,
                                    this.Name,
                                    errMessage,
                                    0,
                                    MessageBoxButtons.OK);

                    if ("tEdit_EmployeeCode_St".Equals(this._prevControl.Name))
                    {
                        tEdit_EmployeeCode_St.Focus();
                    }
                    else if ("tEdit_EmployeeCode_Ed".Equals(this._prevControl.Name))
                    {
                        tEdit_EmployeeCode_Ed.Focus();
                    }
                    else
                    {
                        tEdit_EmployeeCode_St.Focus();
                    }
                    return tEdit_EmployeeCode_St;
                }
            }
            # endregion 存在チェック


            # region 必須入力チェック

            //期間区分
            int duringFlg = Convert.ToInt32(tComboEditor_During.SelectedItem.DataValue);

            //日付
            DateGetAcs.CheckDateRangeResult cdrResult;

            if (duringFlg == 1)
            {
                // 期間（開始～終了）
                if (CallCheckDateForYearMonthDayRange(out cdrResult, ref tDateEdit_St_During, ref tDateEdit_Ed_During) == false)
                {
                    switch (cdrResult)
                    {
                        case DateGetAcs.CheckDateRangeResult.ErrorOfStartNoInput:
                            {
                                errMessage = string.Format("期間(開始){0}", MESSAGE_NoInput);
                                if (msgFlg) // ADD 2010/07/20
                                    TMsgDisp.Show(
                                                this,
                                                emErrorLevel.ERR_LEVEL_INFO,
                                                this.Name,
                                                errMessage,
                                                0,
                                                MessageBoxButtons.OK);
                                tDateEdit_St_During.Focus();
                                return tDateEdit_St_During;
                            }
                        case DateGetAcs.CheckDateRangeResult.ErrorOfStartInvalid:
                            {
                                errMessage = string.Format("期間(開始){0}", ct_InputError);
                                if (msgFlg) // ADD 2010/07/20
                                    TMsgDisp.Show(
                                                this,
                                                emErrorLevel.ERR_LEVEL_INFO,
                                                this.Name,
                                                errMessage,
                                                0,
                                                MessageBoxButtons.OK);
                                tDateEdit_St_During.Focus();
                                return tDateEdit_St_During;
                            }
                        case DateGetAcs.CheckDateRangeResult.ErrorOfEndNoInput:
                            {
                                errMessage = string.Format("期間(終了){0}", ct_NoInput);
                                if (msgFlg) // ADD 2010/07/20
                                    TMsgDisp.Show(
                                                this,
                                                emErrorLevel.ERR_LEVEL_INFO,
                                                this.Name,
                                                errMessage,
                                                0,
                                                MessageBoxButtons.OK);
                                tDateEdit_Ed_During.Focus();
                                return tDateEdit_Ed_During;
                            }
                        case DateGetAcs.CheckDateRangeResult.ErrorOfEndInvalid:
                            {
                                errMessage = string.Format("期間(終了){0}", ct_InputError);
                                if (msgFlg) // ADD 2010/07/20
                                    TMsgDisp.Show(
                                                this,
                                                emErrorLevel.ERR_LEVEL_INFO,
                                                this.Name,
                                                errMessage,
                                                0,
                                                MessageBoxButtons.OK);
                                tDateEdit_Ed_During.Focus();
                                return tDateEdit_Ed_During;
                            }
                        case DateGetAcs.CheckDateRangeResult.ErrorOfReverse:
                            {
                                errMessage = string.Format("期間{0}", ct_RangeError);
                                if (msgFlg) // ADD 2010/07/20
                                    TMsgDisp.Show(
                                                this,
                                                emErrorLevel.ERR_LEVEL_INFO,
                                                this.Name,
                                                errMessage,
                                                0,
                                                MessageBoxButtons.OK);
                                tDateEdit_St_During.Focus();
                                return tDateEdit_St_During;

                            }
                        case DateGetAcs.CheckDateRangeResult.ErrorOfNotOnMonth:
                            {
                                errMessage = string.Format("開始・終了日付{0}", ct_NotOnMonthError);
                                if (msgFlg) // ADD 2010/07/20
                                    TMsgDisp.Show(
                                                this,
                                                emErrorLevel.ERR_LEVEL_INFO,
                                                this.Name,
                                                errMessage,
                                                0,
                                                MessageBoxButtons.OK);
                                tDateEdit_St_During.Focus();
                                return tDateEdit_St_During;
                            }
                        case DateGetAcs.CheckDateRangeResult.ErrorOfRangeOver:
                            {
                                errMessage = string.Format("期間{0}", ct_RangeOverError);
                                if (msgFlg) // ADD 2010/07/20
                                    TMsgDisp.Show(
                                                this,
                                                emErrorLevel.ERR_LEVEL_INFO,
                                                this.Name,
                                                errMessage,
                                                0,
                                                MessageBoxButtons.OK);
                                tDateEdit_St_During.Focus();
                                return tDateEdit_St_During;
                            }
                    }
                }
            }
            else if (duringFlg == 2)
            {
                // 期間（開始～終了）
                if (CallCheckDateForYearMonthRange(out cdrResult, ref tDateEdit_St_YearMonth, ref tDateEdit_Ed_YearMonth) == false)
                {
                    switch (cdrResult)
                    {
                        case DateGetAcs.CheckDateRangeResult.ErrorOfStartNoInput:
                            {
                                errMessage = string.Format("期間(開始){0}", ct_NoInput);
                                if (msgFlg) // ADD 2010/07/20
                                    TMsgDisp.Show(
                                                this,
                                                emErrorLevel.ERR_LEVEL_INFO,
                                                this.Name,
                                                errMessage,
                                                0,
                                                MessageBoxButtons.OK);
                                tDateEdit_St_YearMonth.Focus();
                                return tDateEdit_St_YearMonth;
                            }
                        case DateGetAcs.CheckDateRangeResult.ErrorOfStartInvalid:
                            {
                                errMessage = string.Format("期間(開始){0}", ct_InputError);
                                if (msgFlg) // ADD 2010/07/20
                                    TMsgDisp.Show(
                                                this,
                                                emErrorLevel.ERR_LEVEL_INFO,
                                                this.Name,
                                                errMessage,
                                                0,
                                                MessageBoxButtons.OK);
                                tDateEdit_St_YearMonth.Focus();
                                return tDateEdit_St_YearMonth;
                            }
                        case DateGetAcs.CheckDateRangeResult.ErrorOfEndNoInput:
                            {
                                errMessage = string.Format("期間(終了){0}", ct_NoInput);
                                if (msgFlg) // ADD 2010/07/20
                                    TMsgDisp.Show(
                                                this,
                                                emErrorLevel.ERR_LEVEL_INFO,
                                                this.Name,
                                                errMessage,
                                                0,
                                                MessageBoxButtons.OK);
                                tDateEdit_Ed_YearMonth.Focus();
                                return tDateEdit_Ed_YearMonth;
                            }
                        case DateGetAcs.CheckDateRangeResult.ErrorOfEndInvalid:
                            {
                                errMessage = string.Format("期間(終了){0}", ct_InputError);
                                if (msgFlg) // ADD 2010/07/20
                                    TMsgDisp.Show(
                                                this,
                                                emErrorLevel.ERR_LEVEL_INFO,
                                                this.Name,
                                                errMessage,
                                                0,
                                                MessageBoxButtons.OK);
                                tDateEdit_Ed_YearMonth.Focus();
                                return tDateEdit_Ed_YearMonth;
                            }
                        case DateGetAcs.CheckDateRangeResult.ErrorOfReverse:
                            {
                                errMessage = string.Format("期間{0}", ct_RangeError);
                                if (msgFlg) // ADD 2010/07/20
                                    TMsgDisp.Show(
                                                this,
                                                emErrorLevel.ERR_LEVEL_INFO,
                                                this.Name,
                                                errMessage,
                                                0,
                                                MessageBoxButtons.OK);
                                tDateEdit_St_YearMonth.Focus();
                                return tDateEdit_St_YearMonth;

                            }
                        case DateGetAcs.CheckDateRangeResult.ErrorOfRangeOver:
                            {
                                errMessage = string.Format("期間{0}", ct_RangeYearMonthOverError);
                                if (msgFlg) // ADD 2010/07/20
                                    TMsgDisp.Show(
                                                this,
                                                emErrorLevel.ERR_LEVEL_INFO,
                                                this.Name,
                                                errMessage,
                                                0,
                                                MessageBoxButtons.OK);
                                tDateEdit_St_YearMonth.Focus();
                                return tDateEdit_St_YearMonth;
                            }
                        case DateGetAcs.CheckDateRangeResult.ErrorOfNotOnYear:
                            {
                                errMessage = string.Format("開始・終了年月{0}", ct_NotOnYearError);
                                if (msgFlg) // ADD 2010/07/20
                                    TMsgDisp.Show(
                                                this,
                                                emErrorLevel.ERR_LEVEL_INFO,
                                                this.Name,
                                                errMessage,
                                                0,
                                                MessageBoxButtons.OK);
                                tDateEdit_St_YearMonth.Focus();
                                return tDateEdit_St_YearMonth;
                            }
                    }
                }
            }

            # endregion 必須入力チェック


            return null;
        }
        #endregion

        #region ◎ 年月入力チェック処理

        /// <summary>
        /// 日付((YYYYMM))チェック処理呼び出し
        /// </summary>
        /// <param name="cdrResult"></param>
        /// <param name="startDateEdit"></param>
        /// <param name="endDateEdit"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 日付チェック処理呼び出しを行います。</br>
        /// <br>Programmer : 汪千来</br>
        /// <br>Date       : 2009.01.05</br>
        /// </remarks>
        public bool CallCheckDateForYearMonthRange(out DateGetAcs.CheckDateRangeResult cdrResult, ref TDateEdit startDateEdit, ref TDateEdit endDateEdit)
        {
            // --- DEL 2010/07/20-------------------------------->>>>>
            ////期間区分
            //int duringFlg = Convert.ToInt32(tComboEditor_During.SelectedItem.DataValue);

            //if (duringFlg == 2)
            //{
            // --- DEL 2010/07/20--------------------------------<<<<<
                // 当月の場合、年度跨りのチェックなし
            cdrResult = _dateGet.CheckDateRange(DateGetAcs.YmdType.YearMonth, 12, ref startDateEdit, ref endDateEdit, false, true);
            // --- DEL 2010/07/20-------------------------------->>>>>
            //}
            //else
            //{
            //    // 当期を含む場合、年度跨りをチェック
            //    cdrResult = _dateGet.CheckDateRange(DateGetAcs.YmdType.YearMonth, 12, ref startDateEdit, ref endDateEdit, false, true);

            //    //if (cdrResult == DateGetAcs.CheckDateRangeResult.ErrorOfNotOnYear)
            //    //{
            //    //    // 年度跨り以外を再チェック
            //    //    cdrResult = _dateGet.CheckDateRange(DateGetAcs.YmdType.YearMonth, 12, ref startDateEdit, ref endDateEdit, false);

            //    //    if (cdrResult == DateGetAcs.CheckDateRangeResult.OK)
            //    //    {
            //    //        // 年度跨りエラーの場合は当月にする
            //    //        this.PrintType_ultraOptionSet.CheckedIndex = 0;
            //    //    }
            //    //}
            //}
            // --- DEL 2010/07/20--------------------------------<<<<<


            return (cdrResult == DateGetAcs.CheckDateRangeResult.OK);
        }

        /// <summary>
        /// 日付(YYYYMMDD)チェック処理呼び出し
        /// </summary>
        /// <param name="cdrResult"></param>
        /// <param name="tde_St_OrderDataCreateDate"></param>
        /// <param name="tde_Ed_OrderDataCreateDate"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 日付の入力チェックを行います。</br>
        /// <br>Programmer : 汪千来</br>
        /// <br>Date       : 2009.01.05</br>
        /// </remarks>
        public bool CallCheckDateForYearMonthDayRange(out DateGetAcs.CheckDateRangeResult cdrResult, ref TDateEdit tde_St_OrderDataCreateDate, ref TDateEdit tde_Ed_OrderDataCreateDate)
        {
            cdrResult = _dateGet.CheckDateRange(DateGetAcs.YmdType.YearMonth, 1, ref tde_St_OrderDataCreateDate, ref tde_Ed_OrderDataCreateDate, false, false, true);
            return (cdrResult == DateGetAcs.CheckDateRangeResult.OK);
        }

        /// <summary>
        /// 日付入力チェック処理
        /// </summary>
        /// <param name="control">チェック対象コントロール</param>
        /// <returns>true:チェックOK,false:チェックNG</returns>
        /// <remarks>
        /// <br>Note       : 日付の入力チェックを行います。</br>
        /// <br>Programmer : 汪千来</br>
        /// <br>Date       : 2009.04.05</br>
        /// </remarks>
        private bool InputDateYYYYMMDDEditCheack(TDateEdit control)
        {
            // 日付を数値型で取得
            int date = control.GetLongDate();
            int yy = date / 10000;
            int mm = date / 100 % 100;
            int dd = date % 100;

            // 日付未入力チェック
            if (date == 0) return false;

            // システムサポートチェック
            if (yy < 1900) return false;

            // 年・月・日別入力チェック
            switch (control.DateFormat)
            {
                // 年・月・日表示時
                case emDateFormat.dfG2Y2M2D:
                case emDateFormat.df4Y2M2D:
                case emDateFormat.df2Y2M2D:
                    if (yy == 0 || mm == 0 || dd == 0) return false;
                    break;
                // 年・月    表示時
                case emDateFormat.dfG2Y2M:
                case emDateFormat.df4Y2M:
                case emDateFormat.df2Y2M:
                    if (yy == 0 || mm == 0) return false;
                    break;
                // 年        表示時
                case emDateFormat.dfG2Y:
                case emDateFormat.df4Y:
                case emDateFormat.df2Y:
                    if (yy == 0) return false;
                    break;
                // 月・日　　表示時
                case emDateFormat.df2M2D:
                    if (mm == 0 || dd == 0) return false;
                    break;
                // 月        表示時
                case emDateFormat.df2M:
                    if (mm == 0) return false;
                    break;
                // 日        表示時
                case emDateFormat.df2D:
                    if (dd == 0) return false;
                    break;
            }

            DateTime dt = TDateTime.LongDateToDateTime("YYYYMMDD", date);
            // 単純日付妥当性チェック
            if (TDateTime.IsAvailableDate(dt) == false) return false;

            return true;
        }


        /// <summary>
        /// 日付入力チェック処理
        /// </summary>
        /// <param name="control">チェック対象コントロール</param>
        /// <returns>true:チェックOK,false:チェックNG</returns>
        /// <remarks>
        /// <br>Note       : 日付の入力チェックを行います。</br>
        /// <br>Programmer : 汪千来</br>
        /// <br>Date       : 2009.04.08</br>
        /// </remarks>
        private bool InputDateYYYYMMEditCheack(TDateEdit control)
        {
            // 日付を数値型で取得
            int date = control.GetLongDate();
            int yy = date / 10000;
            int mm = date / 100 % 100;
            int dd = date % 100;

            // 日付未入力チェック
            if (date == 0) return false;

            // システムサポートチェック
            if (yy < 1900) return false;

            // 年・月・日別入力チェック
            switch (control.DateFormat)
            {
                // 年・月・日表示時
                case emDateFormat.dfG2Y2M2D:
                case emDateFormat.df4Y2M2D:
                case emDateFormat.df2Y2M2D:
                    if (yy == 0 || mm == 0 || dd == 0) return false;
                    break;
                // 年・月    表示時
                case emDateFormat.dfG2Y2M:
                case emDateFormat.df4Y2M:
                case emDateFormat.df2Y2M:
                    if (yy == 0 || mm == 0) return false;
                    break;
                // 年        表示時
                case emDateFormat.dfG2Y:
                case emDateFormat.df4Y:
                case emDateFormat.df2Y:
                    if (yy == 0) return false;
                    break;
                // 月・日　　表示時
                case emDateFormat.df2M2D:
                    if (mm == 0 || dd == 0) return false;
                    break;
                // 月        表示時
                case emDateFormat.df2M:
                    if (mm == 0) return false;
                    break;
                // 日        表示時
                case emDateFormat.df2D:
                    if (dd == 0) return false;
                    break;
            }

            DateTime dt = TDateTime.LongDateToDateTime("YYYYMM", date / 100);
            // 単純日付妥当性チェック
            if (TDateTime.IsAvailableDate(dt) == false) return false;

            return true;
        }
        #endregion

        # region [検索]
        /// <summary>
        /// 担当者別実績照会検索実行処理
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 従業員Readを行う。 </br>
        /// <br>Programmer : 汪千来</br>
        /// <br>Date       : 2009.04.01</br>
        /// <br>Update Note: 2010/09/21 zhume</br>
        /// <br>             Redmine#14876 テキスト出力対応</br>
        /// </remarks>
        //private Control SearchEmployeeResults() // DEL 2010/07/20
        private Control SearchEmployeeResults(bool msgFlg) // ADD 2010/07/20
        {
            // ----- ADD 2010/09/21 ---------------------------->>>>>
            if (this.tEdit_SectionCodeAllowZero.Focused)
            {
                this._prevControl = this.tEdit_SectionCodeAllowZero;
            }
            else if (this.tEdit_EmployeeCode_St.Focused)
            {
                this._prevControl = this.tEdit_EmployeeCode_St;
            }
            else if (this.tEdit_EmployeeCode_Ed.Focused)
            {
                this._prevControl = this.tEdit_EmployeeCode_Ed;
            }
            // ----- ADD 2010/09/21 ----------------------------<<<<<
            if (this._prevControl != null)
            {
                //hasCheckError = false;
                ChangeFocusEventArgs e = new ChangeFocusEventArgs(false, false, false, Keys.Return, this._prevControl, this._prevControl);
                this.tRetKeyControl1_ChangeFocus(this, e);
                // ----- ADD 2010/09/21 ---------------------------->>>>>
                if (isError == true)
                {
                    return null;
                }
                // ----- ADD 2010/09/21 ----------------------------<<<<<
            }

            // 入力項目チェック処理
            //Control control = this.CheckInputPara(); // DEL 2010/07/20
            Control control = this.CheckInputPara(msgFlg); // ADD 2010/07/20

            if (control != null)
            {
                return control;
            }

            EmployeeResultsCtdtn employeeResultsCtdtn = new EmployeeResultsCtdtn();

            // 読込条件パラメータクラス設定処理
            this.SetReadPara(out employeeResultsCtdtn);

            // オフライン状態チェック	
            if (!CheckOnline())
            {
                // オフライン状態チェック	
                //if (!CheckOnline()) // DEL 2010/07/20
                if (!CheckOnline() && msgFlg) // ADD 2010/07/20
                {
                    TMsgDisp.Show(
                        emErrorLevel.ERR_LEVEL_STOP,
                        "担当者別実績照会",
                        "担当者別実績照会" + "データ読み込みに失敗しました。",
                        (int)ConstantManagement.DB_Status.ctDB_OFFLINE, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                }
                return control;
            }

            // 担当者別実績照会情報読込・データセット格納処理
            if (this._employeeResultsAcs.SetSearchData(employeeResultsCtdtn) == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                tEdit_SectionCodeAllowZero.Focus();
            }
            else
            {
                if (msgFlg) // ADD 2010/07/20
                { // ADD 2010/07/20
                    TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "該当データが存在しません。",
                                0,
                                MessageBoxButtons.OK);
                } // ADD 2010/07/20
            }



            return null;
        }
        # endregion

        /// <summary>
        /// フォーム終了イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : フォーム終了イベントを行う。 </br>
        /// <br>Programmer : 汪千来</br>
        /// <br>Date       : 2009.04.01</br>
        /// </remarks>
        private void PMHNB04161UA_FormClosed(object sender, FormClosedEventArgs e)
        {
            DialogResult = _dialogRes;
        }

        #region 値変更後発生イベント
        /// <summary>
        /// 期間区分コンボボックス値変更後発生イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : 期間区分コンボボックス値変更後発生イベントを行う。 </br>
        /// <br>Programmer : 汪千来</br>
        /// <br>Date       : 2009.04.01</br>
        /// </remarks>
        private void tComboEditor_During_ValueChanged(object sender, EventArgs e)
        {
            //期間区分flg
            int duringFlg = Convert.ToInt32(tComboEditor_During.SelectedItem.DataValue);
            if (duringFlg == 1)
            {
                uLabel_During_From_To.Visible = true;

                //期間(開始)YYYYMMDD
                tDateEdit_St_During.Visible = true;

                //期間(終了)YYYYMMDD
                tDateEdit_Ed_During.Visible = true;


                //期間(開始)YYYYMM
                tDateEdit_St_YearMonth.Visible = false;

                //期間(終了)YYYYMM
                tDateEdit_Ed_YearMonth.Visible = false;

                uLabel_To_OutputDay.Visible = true;

                // 売上日
                DateTime staratDate;
                DateTime endDate;
                this._dateGet.GetPeriod(DateGetAcs.ProcModeDivState.PastDays, 1, out staratDate, out endDate);

                if (tDateEdit_St_During.GetDateTime().Equals(DateTime.MinValue))
                {
                    //期間(開始)YYYYMMDD
                    this.tDateEdit_St_During.Visible = true;
                    this.tDateEdit_St_During.Clear();
                    this.tDateEdit_St_During.SetDateTime(staratDate);
                }

                if (tDateEdit_Ed_During.GetDateTime().Equals(DateTime.MinValue))
                {
                    //期間(終了)YYYYMMDD
                    this.tDateEdit_Ed_During.Visible = true;
                    this.tDateEdit_Ed_During.Clear();
                    this.tDateEdit_Ed_During.SetDateTime(endDate);
                }

                this._inputDetails.InitialSettingGridCol(1);

            }
            else if (duringFlg == 2)
            {
                uLabel_During_From_To.Visible = true;

                //期間(開始)YYYYMMDD
                tDateEdit_St_During.Visible = false;

                //期間(終了)YYYYMMDD
                tDateEdit_Ed_During.Visible = false;


                //期間(開始)YYYYMM
                tDateEdit_St_YearMonth.Visible = true;

                //期間(終了)YYYYMM
                tDateEdit_Ed_YearMonth.Visible = true;

                uLabel_To_OutputDay.Visible = true;


                // 当月を設定
                DateTime nowYearMonth;
                DateTime startMonthDate;
                DateTime endMonthDate;
                int thisYear;

                this._dateGet.GetThisYearMonth(out nowYearMonth, out thisYear, out startMonthDate, out endMonthDate);

                if (tDateEdit_St_YearMonth.GetDateTime().Equals(DateTime.MinValue))
                {
                    this.tDateEdit_St_YearMonth.SetDateTime(startMonthDate);
                }

                if (tDateEdit_Ed_YearMonth.GetDateTime().Equals(DateTime.MinValue))
                {
                    this.tDateEdit_Ed_YearMonth.SetDateTime(endMonthDate);
                }
                this._inputDetails.InitialSettingGridCol(2);
            }
            else
            {

                uLabel_During_From_To.Visible = false;

                //期間(開始)YYYYMMDD
                tDateEdit_St_During.Visible = false;

                //期間(終了)YYYYMMDD
                tDateEdit_Ed_During.Visible = false;


                //期間(開始)YYYYMM
                tDateEdit_St_YearMonth.Visible = false;

                //期間(終了)YYYYMM
                tDateEdit_Ed_YearMonth.Visible = false;

                uLabel_To_OutputDay.Visible = false;

                //当期を設定
                DateTime nowYearMonth;
                DateTime startMonthDate;
                DateTime endMonthDate;
                DateTime startYearDate;
                DateTime endYearDate;
                int thisYear;

                this._dateGet.GetThisYearMonth(out nowYearMonth, out thisYear, out startMonthDate, out endMonthDate, out startYearDate, out endYearDate);

                this.tDateEdit_St_YearMonth.SetDateTime(startYearDate);
                this.tDateEdit_Ed_YearMonth.SetDateTime(endYearDate);

                this._inputDetails.InitialSettingGridCol(3);

            }

            this._employeeResultsAcs.ClearEmployeeResultsDataTable();
        }

        /// <summary>
        /// 参照区分コンボボックス値変更後発生イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : 参照区分コンボボックス値変更後発生イベントを行う。 </br>
        /// <br>Programmer : 汪千来</br>
        /// <br>Date       : 2009.04.01</br>
        /// </remarks>
        private void tComboEditor_Refer_ValueChanged(object sender, EventArgs e)
        {
            //参照区分flg
            int duringFlg = Convert.ToInt32(tComboEditor_Refer.SelectedItem.DataValue);

            if (duringFlg == 1)
            {
                uLabel_EmployeeCode.Text = SALESINPUT_NAME;
            }
            else if (duringFlg == 2)
            {
                uLabel_EmployeeCode.Text = FRONTEMPLOYEE_SECTION_NAME;
            }
            else
            {
                uLabel_EmployeeCode.Text = SALESEMPLOYEE_NAME;
            }

            ClearDetail();

            this.isSearch = false; // ADD 2010/09/21

            this._employeeResultsAcs.ClearEmployeeResultsDataTable();
            // ---ADD 2010/10/09 --------------------->>>
            if (this._userSetupFrm != null)
            {
                this._userSetupFrm.ReferDiv = duringFlg;
                this._userSetupFrm.AnalysisTextSettingAcs.ReferDivValue = duringFlg;
                this._userSetupFrm.AnalysisTextSettingAcs.AnalysisTextSetting.ReferDivValue = duringFlg;
            }
            // ---ADD 2010/10/09 ---------------------<<<


        }


        /// <summary>
        /// 拠点値変更後発生イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : 拠点値変更後発生イベントを行う。 </br>
        /// <br>Programmer : 汪千来</br>
        /// <br>Date       : 2009.04.01</br>
        /// </remarks>
        private void tEdit_SectionCodeAllowZero_ValueChanged(object sender, EventArgs e)
        {
            if (!this._sectionCodeAllowZero.Trim().PadLeft(2, '0').Equals(tEdit_SectionCodeAllowZero.Text.Trim().PadLeft(2, '0'))) // ADD 2010/09/28 障害報告 #15609 
            { // ADD 2010/09/28 障害報告 #15609 
                ClearDetail();

                this.isSearch = false; // ADD 2010/09/21

                this._employeeResultsAcs.ClearEmployeeResultsDataTable();
            } // ADD 2010/09/28 障害報告 #15609 
        }


        /// <summary>
        /// 担当者コード（開始）値変更後発生イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : 担当者コード（開始）値変更後発生イベントを行う。 </br>
        /// <br>Programmer : 汪千来</br>
        /// <br>Date       : 2009.04.01</br>
        /// </remarks>
        private void tEdit_EmployeeCode_St_ValueChanged(object sender, EventArgs e)
        {
            if (!this._employeeCodeSt.Trim().PadLeft(4, '0').Equals(tEdit_EmployeeCode_St.Text.Trim().PadLeft(4, '0'))) // ADD 2010/09/28 障害報告 #15609 
            { // ADD 2010/09/28 障害報告 #15609 
                ClearDetail();

                this.isSearch = false; // ADD 2010/09/21

                this._employeeResultsAcs.ClearEmployeeResultsDataTable();
            } // ADD 2010/09/28 障害報告 #15609 

        }


        /// <summary>
        /// 担当者コード（終了）値変更後発生イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : 担当者コード（終了）値変更後発生イベントを行う。 </br>
        /// <br>Programmer : 汪千来</br>
        /// <br>Date       : 2009.04.01</br>
        /// </remarks>
        private void tEdit_EmployeeCode_Ed_ValueChanged(object sender, EventArgs e)
        {
            if (!this._employeeCodeEd.Trim().PadLeft(4, '0').Equals(tEdit_EmployeeCode_Ed.Text.Trim().PadLeft(4, '0'))) // ADD 2010/09/28 障害報告 #15609 
            { // ADD 2010/09/28 障害報告 #15609 
                ClearDetail();

                this.isSearch = false; // ADD 2010/09/21

                this._employeeResultsAcs.ClearEmployeeResultsDataTable();
            } // ADD 2010/09/28 障害報告 #15609 

        }


        /// <summary>
        /// 期間（開始）値変更後発生イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : 期間（開始）値変更後発生イベントを行う。 </br>
        /// <br>Programmer : 汪千来</br>
        /// <br>Date       : 2009.04.01</br>
        /// </remarks>
        private void tDateEdit_St_YearMonth_ValueChanged(object sender, EventArgs e)
        {
            ClearDetail();

            this.isSearch = false; // ADD 2010/09/21

            this._employeeResultsAcs.ClearEmployeeResultsDataTable();

        }


        /// <summary>
        /// 期間(終了)値変更後発生イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : 期間(終了)値変更後発生イベントを行う。 </br>
        /// <br>Programmer : 汪千来</br>
        /// <br>Date       : 2009.04.01</br>
        /// </remarks>
        private void tDateEdit_Ed_YearMonth_ValueChanged(object sender, EventArgs e)
        {
            ClearDetail();

            this.isSearch = false; // ADD 2010/09/21

            this._employeeResultsAcs.ClearEmployeeResultsDataTable();
        }


        /// <summary>
        /// 期間（開始）値変更後発生イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : 期間（開始）値変更後発生イベントを行う。 </br>
        /// <br>Programmer : 汪千来</br>
        /// <br>Date       : 2009.04.01</br>
        /// </remarks>
        private void tDateEdit_St_During_ValueChanged(object sender, EventArgs e)
        {
            ClearDetail();

            this.isSearch = false; // ADD 2010/09/21

            this._employeeResultsAcs.ClearEmployeeResultsDataTable();

        }


        /// <summary>
        /// 期間(終了)値変更後発生イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : 期間(終了)値変更後発生イベントを行う。 </br>
        /// <br>Programmer : 汪千来</br>
        /// <br>Date       : 2009.04.01</br>
        /// </remarks>
        private void tDateEdit_Ed_During_ValueChanged(object sender, EventArgs e)
        {
            ClearDetail();

            this.isSearch = false; // ADD 2010/09/21

            this._employeeResultsAcs.ClearEmployeeResultsDataTable();
        }

        /// <summary>
        /// 画面ヘッダクリア処理
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 画面ヘッダクリア処理を行う。 </br>
        /// <br>Programmer : 汪千来</br>
        /// <br>Date       : 2009.04.01</br>
        /// </remarks>
        private void ClearDetail()
        {
            if (tComboEditor_During.SelectedItem != null)
            {
                int duringFlg = Convert.ToInt32(tComboEditor_During.SelectedItem.DataValue);
                if (duringFlg == 1)
                {
                    this._inputDetails.InitialSettingGridCol(1);
                }
                else if (duringFlg == 2)
                {
                    this._inputDetails.InitialSettingGridCol(2);
                }
                else
                {
                    this._inputDetails.InitialSettingGridCol(3);
                }
            }
        }

        #endregion

        #endregion

        #region ■ Event
        /// <summary>フォームロード</summary>
        /// <param name="sender">イベントのソース</param>
        /// <param name="e">イベントデータを格納している<see cref="EventArgs"/>。</param>
        /// <remarks>
        /// <br>Note        : フォームロード処理を行う</br>
        /// <br>Programmer	: 汪千来</br>	
        /// <br>Date        : 2009.04.01</br>
        /// </remarks>
        private void PMHNB04161UA_Load(object sender, EventArgs e)
        {
            this.panel_Detail.Controls.Add(this._inputDetails);
            this._inputDetails.Dock = DockStyle.Fill;
            this._inputDetails.InitialSettingGridCol(1);
            //　企業コードを取得する
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            // 自拠点コードを取得する
            this._loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode.TrimEnd();

            this.ToolBarInitilSetting();
            this.ButtonInitialSetting();
            this.ComboInitialSetting();

            // 元に戻す処理
            this.ClearDisplayHeader();
            this.SetDisplayHeaderInfo();
            this._employeeResultsAcs.ClearEmployeeResultsDataTable();

            this.tEdit_SectionCodeAllowZero.Text = WHOLE_SECTION_CODE;
            uLabel_SectionName.Text = WHOLE_SECTION_NAME;


        }

        #endregion

        #region ■ オフライン状態チェック処理

        /// <summary>
        /// ログオン時オンライン状態チェック処理
        /// </summary>
        /// <returns>チェック処理結果</returns>
        /// <remarks>
        /// <br>Note       : ログオン時オンライン状態チェック処理を行う。 </br>
        /// <br>Programmer : 汪千来</br>
        /// <br>Date       : 2009.04.01</br>
        /// </remarks>
        private bool CheckOnline()
        {
            if (Broadleaf.Application.Common.LoginInfoAcquisition.OnlineFlag == false)
            {
                return false;
            }
            else
            {
                // ローカルエリア接続状態によるオンライン判定
                if (CheckRemoteOn() == false)
                {
                    return false;
                }
            }

            return true;
        }


        /// <summary>
        /// リモート接続可能判定
        /// </summary>
        /// <returns>判定結果</returns>
        /// <remarks>
        /// <br>Note       : リモート接続可能判定処理を行う。 </br>
        /// <br>Programmer : 汪千来</br>
        /// <br>Date       : 2009.04.01</br>
        /// </remarks>
        private bool CheckRemoteOn()
        {
            bool isLocalAreaConnected = NetworkInterface.GetIsNetworkAvailable();

            if (isLocalAreaConnected == false)
            {
                // インターネット接続不能状態
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion

        # region ■ 各コントロールイベント処理

        /// <summary>
        /// ツールバーボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       :ツールバーボタンクリックイベントを行う。 </br>
        /// <br>Programmer : 汪千来</br>
        /// <br>Date       : 2009.04.01</br>
        /// <br>Note       : 担当者別実績照会情報を読み込みます。</br>
        /// <br>Programmer : 王開強</br>
        /// <br>Date       : 2010/07/20</br>
        /// </remarks>
        private void tToolbarsManager_MainMenu_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            // 一括ゼロ詰め処理	
            //uiSetControl1.SettingAllControlsZeroPaddedText(); // DEL 2010/07/20
            switch (e.Tool.Key)
            {
                case "ButtonTool_Close":
                    {
                        this.SetDialogRes(DialogResult.Cancel);
                        // 終了処理
                        this.CloseForm();
                        break;
                    }
                case "ButtonTool_Search":
                    {

                        // 検索処理
                        //SearchEmployeeResults(); // DEL 2010/07/20
                        SearchEmployeeResults(true); // ADD 2010/07/20
                        this.isSearch = true; // ADD 2010/09/14
                        break;

                    }
                case "ButtonTool_Clear":
                    {

                        this.ClearDisplayHeader();
                        this.SetDisplayHeaderInfo();
                        this._employeeResultsAcs.ClearEmployeeResultsDataTable();
                        this.isSearch = false; // ADD 2010/09/14

                        // 初期フォーカス
                        this.SetInitFocus(this);

                        break;
                    }
                // --- ADD 2010/07/20-------------------------------->>>>>
                case "ButtonTool_Text":
                    {
                        this.ExportIntoTextFile(false);
                        break;
                    }
                case "ButtonTool_Excel":
                    {
                        this.exportIntoExcelData(true);
                        break;
                    }
                case "ButtonTool_Setup":
                    {
                        if (this._userSetupFrm == null)
                            //this._userSetupFrm = new PMHNB04161UD(); // DEL 2010/10/09
                            this._userSetupFrm = new PMHNB04161UD(Convert.ToInt16(this.tComboEditor_Refer.Value)); // ADD 2010/10/09

                        this._userSetupFrm.ShowDialog();
                        break;
                    }
                // --- ADD 2010/07/20 --------------------------------<<<<<
            }
        }
        # endregion

        # region ■ [読み込み条件]

        /// <summary>
        /// 読込条件パラメータ設定処理
        /// </summary>
        /// <param>読込条件パラメータクラス</param>
        /// <param name="employeeResultsCtdtn">読込条件パラメータ</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 読込条件パラメータ設定処理を行う。 </br>
        /// <br>Programmer : 汪千来</br>
        /// <br>Date       : 2009.04.01</br>
        /// </remarks>
        public void SetReadPara(out EmployeeResultsCtdtn employeeResultsCtdtn)
        {
            employeeResultsCtdtn = new EmployeeResultsCtdtn();

            //企業コード
            employeeResultsCtdtn.EnterpriseCode = this._enterpriseCode;

            //拠点
            employeeResultsCtdtn.SectionCode = this.tEdit_SectionCodeAllowZero.Text;

            //拠点名称
            employeeResultsCtdtn.SectionCodeNm = this.uLabel_SectionName.Text;
            
            //参照区分  
            employeeResultsCtdtn.ReferType = Convert.ToInt32(tComboEditor_Refer.SelectedItem.DataValue);
            //担当者(開始)
            employeeResultsCtdtn.St_EmployeeCode = this.tEdit_EmployeeCode_St.Text;
            //担当者(終了)
            employeeResultsCtdtn.Ed_EmployeeCode = this.tEdit_EmployeeCode_Ed.Text;
            //担当者名称(開始)
            employeeResultsCtdtn.St_EmployeeCodeNm = this.uLabel_SalesEmployeeNm_St.Text;
            //担当者名称(終了)
            employeeResultsCtdtn.Ed_EmployeeCodeNm = this.uLabel_SalesEmployeeNm_Ed.Text;

            //期間区分
            employeeResultsCtdtn.DuringType = Convert.ToInt32(tComboEditor_During.SelectedItem.DataValue);

            if (employeeResultsCtdtn.DuringType == 1)
            {

                //期間(開始)YYYYMMDD
                employeeResultsCtdtn.St_DuringTime = tDateEdit_St_During.GetDateTime();

                //期間(終了)YYYYMMDD
                employeeResultsCtdtn.Ed_DuringTime = tDateEdit_Ed_During.GetDateTime();

            }
            else if (employeeResultsCtdtn.DuringType == 2 || employeeResultsCtdtn.DuringType == 3)
            {
                //期間(開始)YYYYMM
                employeeResultsCtdtn.St_YearMonth = tDateEdit_St_YearMonth.GetDateTime();

                //期間(終了)YYYYMM
                employeeResultsCtdtn.Ed_YearMonth = tDateEdit_Ed_YearMonth.GetDateTime();
            }
            // --- ADD 2010/07/20-------------------------------->>>>>
            //画面ビュー・出力ビューフラグ  
            employeeResultsCtdtn.ViewFlg = "MAIN";
            // --- ADD 2010/07/20--------------------------------<<<<<

        }

        #endregion

        # region ■ ヘッダ処理
        /// <summary>
        /// 画面ヘッダクリア処理
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 画面ヘッダクリア処理を行う。 </br>
        /// <br>Programmer : 汪千来</br>
        /// <br>Date       : 2009.04.01</br>
        /// </remarks>
        private void ClearDisplayHeader()
        {
            // 拠点
            this.tEdit_SectionCodeAllowZero.Text = WHOLE_SECTION_CODE;
            this.uLabel_SectionName.Text = WHOLE_SECTION_NAME;
            _paraEmployeeResultsSlipCache_Display.SectionCode = WHOLE_SECTION_CODE;
            _paraEmployeeResultsSlipCache_Display.SectionCodeNm = WHOLE_SECTION_NAME;

            // 参照区分
            this.tComboEditor_Refer.SelectedIndex = 0;

            //期間区分
            this.tComboEditor_During.SelectedIndex = 0;


            //担当者
            tEdit_EmployeeCode_St.Text = string.Empty;
            tEdit_EmployeeCode_Ed.Text = string.Empty;

            uLabel_SalesEmployeeNm_St.Text = string.Empty;
            uLabel_SalesEmployeeNm_Ed.Text = string.Empty;

            // 入力日
            this.tDateEdit_St_During.Clear();
            this.tDateEdit_Ed_During.Clear();

        }


        /// <summary>
        /// 画面ヘッダ表示処理
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 画面ヘッダ表示処理を行う。 </br>
        /// <br>Programmer : 汪千来</br>
        /// <br>Date       : 2009.04.01</br>
        /// </remarks>
        private void SetDisplayHeaderInfo()
        {
            // コンボボックス項目初期表示
            this.tComboEditor_Refer.SelectedIndex = 0;
            this.tComboEditor_During.SelectedIndex = 0;

            this.uLabel_During_From_To.Visible = true;

            _prevControl = this.tEdit_SectionCodeAllowZero;

            // 売上日
            DateTime staratDate;
            DateTime endDate;
            this._dateGet.GetPeriod(DateGetAcs.ProcModeDivState.PastDays, 1, out staratDate, out endDate);

            //期間(開始)YYYYMMDD
            this.tDateEdit_St_During.Visible = true;
            this.tDateEdit_St_During.Clear();
            this.tDateEdit_St_During.SetDateTime(staratDate);

            //期間(終了)YYYYMMDD
            this.tDateEdit_Ed_During.Visible = true;
            this.tDateEdit_Ed_During.Clear();
            this.tDateEdit_Ed_During.SetDateTime(endDate);

            //期間(開始)YYYYMM
            this.tDateEdit_St_YearMonth.Visible = false;

            //期間(終了)YYYYMM
            this.tDateEdit_Ed_YearMonth.Visible = false;

            this.uLabel_To_OutputDay.Visible = true;


            // 拠点設定
            this.tEdit_SectionCodeAllowZero.Text = WHOLE_SECTION_CODE;
            this.uLabel_SectionName.Text = WHOLE_SECTION_NAME;

        }

        /// <summary>
        /// ダイアログリザルト設定処理
        /// </summary>
        /// <param name="dialogRes">ダイアログリザルト</param>
        /// <remarks>
        /// <br>Note       : ダイアログリザルト設定処理を行う。 </br>
        /// <br>Programmer : 汪千来</br>
        /// <br>Date       : 2009.04.01</br>
        /// </remarks>
        public void SetDialogRes(DialogResult dialogRes)
        {
            _dialogRes = dialogRes;
        }

        /// <summary>
        /// フォーム初回表示イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PMHNB04161UA_Shown(object sender, EventArgs e)
        {
            this.SetInitFocus(this);
        }

        /// <summary>
        /// 初期フォーカス設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 初期フォーカス設定処理を行う。 </br>
        /// <br>Programmer : 汪千来</br>
        /// <br>Date       : 2009.04.01</br>
        /// </remarks>
        public Control SetInitFocus(object sender)
        {
            this.tEdit_SectionCodeAllowZero.Focus();
            this.tEdit_SectionCodeAllowZero.SelectAll();
            return this.tEdit_SectionCodeAllowZero;
        }



        # endregion

        #region ■ 画面終了処理
        /// <summary>
        /// 画面終了処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面終了処理を行う。 </br>
        /// <br>Programmer : 汪千来</br>
        /// <br>Date       : 2009.04.01</br>
        /// </remarks>
        public void CloseForm()
        {
            this.Close();
        }
        #endregion

        # region ■ [ガイドボタンクリック]
        /// <summary>
        /// 拠点ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : 拠点ガイドボタンクリックイベントを行う。 </br>
        /// <br>Programmer : 汪千来</br>
        /// <br>Date       : 2009.04.01</br>
        /// </remarks>
        private void uButton_Section_Click(object sender, EventArgs e)
        {
            // オフライン状態チェック	
            if (!CheckOnline())
            {
                TMsgDisp.Show(
                    emErrorLevel.ERR_LEVEL_STOP,
                    this.Text,
                    "拠点ガイド" + "画面初期化処理に失敗しました。",
                    (int)ConstantManagement.DB_Status.ctDB_OFFLINE, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                return;
            }

            if (_secInfoSetAcs == null)
            {
                _secInfoSetAcs = new SecInfoSetAcs();
            }

            SecInfoSet secInfoSet;
            int status = _secInfoSetAcs.ExecuteGuid(this._enterpriseCode, true, out secInfoSet);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                tEdit_SectionCodeAllowZero.Text = secInfoSet.SectionCode.Trim();
                this._sectionCodeAllowZero = this.tEdit_SectionCodeAllowZero.Text; // ADD 2010/09/21
                _paraEmployeeResultsSlipCache_Display.SectionCode = secInfoSet.SectionCode.Trim();

                _EmployeeResultsCtdtn.SectionCode = secInfoSet.SectionCode.Trim();

                if (!string.IsNullOrEmpty(secInfoSet.SectionGuideNm))
                {
                    uLabel_SectionName.Text = secInfoSet.SectionGuideNm.Trim();
                    _EmployeeResultsCtdtn.SectionCodeNm = secInfoSet.SectionGuideNm.Trim();

                    _paraEmployeeResultsSlipCache_Display.SectionCodeNm = secInfoSet.SectionGuideNm.Trim();
                }

                // フォーカス移動
                tComboEditor_Refer.Focus();
            }
        }

        /// <summary>
        /// 担当者(開始)ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : 担当者(開始)ガイドボタンクリックイベントを行う。 </br>
        /// <br>Programmer : 汪千来</br>
        /// <br>Date       : 2009.04.01</br>
        /// </remarks>
        private void uButton_St_EmployeeCode_Click(object sender, EventArgs e)
        {
            // オフライン状態チェック	
            if (!CheckOnline())
            {
                TMsgDisp.Show(
                    emErrorLevel.ERR_LEVEL_STOP,
                    this.Text,
                    "従業員ガイド" + "画面初期化処理に失敗しました。",
                    (int)ConstantManagement.DB_Status.ctDB_OFFLINE, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                return;
            }

            if (_employeeAcs == null)
            {
                _employeeAcs = new EmployeeAcs();
            }

            Employee employee;
            int status = _employeeAcs.ExecuteGuid(this._enterpriseCode, true, out employee);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                tEdit_EmployeeCode_St.Text = employee.EmployeeCode.Trim();

                _paraEmployeeResultsSlipCache_Display.St_EmployeeCode = employee.EmployeeCode.Trim();

                if (!string.IsNullOrEmpty(employee.Name))
                {
                    uLabel_SalesEmployeeNm_St.Text = employee.Name.Trim();
                    this._employeeCodeSt = this.tEdit_EmployeeCode_St.Text; // ADD 2010/09/21
                    _EmployeeResultsCtdtn.St_EmployeeCodeNm = employee.Name.Trim();

                    _paraEmployeeResultsSlipCache_Display.St_EmployeeCodeNm = employee.Name.Trim();
                }
                _EmployeeResultsCtdtn.St_EmployeeCode = employee.EmployeeCode.Trim();

                tEdit_EmployeeCode_Ed.Focus();
            }
        }

        /// <summary>
        /// 担当者(終了)ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : 担当者(終了)ガイドボタンクリックイベントを行う。 </br>
        /// <br>Programmer : 汪千来</br>
        /// <br>Date       : 2009.04.01</br>
        /// </remarks>
        private void ultraButton_Ed_EmployeeCode_Click(object sender, EventArgs e)
        {
            // オフライン状態チェック	
            if (!CheckOnline())
            {
                TMsgDisp.Show(
                    emErrorLevel.ERR_LEVEL_STOP,
                    this.Text,
                    "従業員ガイド" + "画面初期化処理に失敗しました。",
                    (int)ConstantManagement.DB_Status.ctDB_OFFLINE, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                return;
            }

            if (_employeeAcs == null)
            {
                _employeeAcs = new EmployeeAcs();
            }

            Employee employee;
            int status = _employeeAcs.ExecuteGuid(this._enterpriseCode, true, out employee);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                tEdit_EmployeeCode_Ed.Text = employee.EmployeeCode.Trim();
                this._employeeCodeEd = this.tEdit_EmployeeCode_Ed.Text; // ADD 2010/09/21
                _EmployeeResultsCtdtn.Ed_EmployeeCode = employee.EmployeeCode.Trim();

                _paraEmployeeResultsSlipCache_Display.Ed_EmployeeCode = employee.EmployeeCode.Trim();

                if (!string.IsNullOrEmpty(employee.Name))
                {
                    uLabel_SalesEmployeeNm_Ed.Text = employee.Name.TrimEnd();
                    _EmployeeResultsCtdtn.Ed_EmployeeCodeNm = employee.Name.TrimEnd();

                    _paraEmployeeResultsSlipCache_Display.Ed_EmployeeCodeNm = employee.Name.TrimEnd();
                }

                tComboEditor_During.Focus();
            }
        }

        #endregion

        // --- ADD 2010/07/20-------------------------------->>>>>
        /// <summary>
        /// EXCELデータ出力
        /// </summary>
        /// <br>Update Note: 2024/11/29 陳艶丹</br>
        /// <br>             PMKOBETSU-4368 2024年PKG格上のログ出力対応</br>
        private void exportIntoExcelData(bool excelFlg)
        {
            // --- ADD 2010/08/12 障害ID:13038対応-------------------------------->>>>>
            if (this._prevControl != null)
            {
                checkFlg = false;
                ChangeFocusEventArgs e = new ChangeFocusEventArgs(false, false, false, Keys.Return, this._prevControl, this._prevControl);
                this.tRetKeyControl1_ChangeFocus(this, e);
            }
            if (!checkFlg)
            {
                // --- ADD 2010/08/12 障害ID:13038対応--------------------------------<<<<<
                this._extractSetupFrm = new PMHNB04161UC();

                this._extractSetupFrm.FormcloseFlg = false;
                // 出力形式
                this._extractSetupFrm.ExcelFlg = excelFlg;
                // 開始拠点
                this._extractSetupFrm.SectionCodeSt = this.tEdit_SectionCodeAllowZero.Text;
                // 終了拠点
                this._extractSetupFrm.SectionCodeEd = this.tEdit_SectionCodeAllowZero.Text;
                // 参照区分
                this._extractSetupFrm.ReferDiv = this.tComboEditor_Refer.SelectedIndex;
                // 期間区分
                this._extractSetupFrm.DuringDiv = this.tComboEditor_During.SelectedIndex;
                // 開始担当者
                this._extractSetupFrm.EmployeeCodeSt = this.tEdit_EmployeeCode_St.Text;
                // 終了担当者
                this._extractSetupFrm.EmployeeCodeEd = this.tEdit_EmployeeCode_Ed.Text;
                // 開始期間
                this._extractSetupFrm.DuringSt = this.tDateEdit_St_During.GetDateTime();
                // 終了期間
                this._extractSetupFrm.DuringEd = this.tDateEdit_Ed_During.GetDateTime();
                // 開始期間(年月)
                this._extractSetupFrm.DuringYmSt = this.tDateEdit_St_YearMonth.GetLongDate();
                this._extractSetupFrm.DuringYmEd = this.tDateEdit_Ed_YearMonth.GetLongDate();

                this._extractSetupFrm.OutputData += new PMHNB04161UC.OutputDataEvent(this.outputExcelData); // ADD 2010/10/09

                //----- ADD 2024/11/29 陳艶丹 PMKOBETSU-4368 2024年PKG格上のログ出力対応 ----->>>>>
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
                //----- ADD 2024/11/29 陳艶丹 PMKOBETSU-4368 2024年PKG格上のログ出力対応 -----<<<<<

                this._extractSetupFrm.ShowDialog();

                // --- DEL 2010/10/09 ---------->>>
                //if (this._extractSetupFrm.DResult == DialogResult.Cancel)
                //{
                //    return;
                //}

                //EmployeeResultsCtdtn employeeResultsCtdtn = new EmployeeResultsCtdtn();
                //// 読込条件パラメータクラス設定処理
                //this.SetReadParaForOutput(out employeeResultsCtdtn);

                //// グリッド列設定処理
                //int duringFlg = _extractSetupFrm.DuringDiv;
                //int referDiv = this._extractSetupFrm.ReferDiv; // ADD 2010/09/09
                //if (duringFlg == 1)
                //{
                //    //this._inputDetails.InitialSettingGridColForOutput(1); // DEL 2010/09/09
                //    this._inputDetails.InitialSettingGridColForOutput(1, referDiv); // ADD 2010/09/09
                //}
                //else if (duringFlg == 2)
                //{
                //    //this._inputDetails.InitialSettingGridColForOutput(2); // DEL 2010/09/09
                //    this._inputDetails.InitialSettingGridColForOutput(2, referDiv); // ADD 2010/09/09
                //}
                //else
                //{
                //    //this._inputDetails.InitialSettingGridColForOutput(2); // DEL 2010/09/09
                //    this._inputDetails.InitialSettingGridColForOutput(2, referDiv); // ADD 2010/09/09
                //}
                ////this._employeeResultsAcs.SearchForOutput(employeeResultsCtdtn);// DEL 2010/08/20
                ////this._employeeResultsAcs.SearchForOutput(employeeResultsCtdtn, this._extractSetupFrm.SectionCodeSt); // ADD 2010/08/20
                //this._employeeResultsAcs.SearchForOutput(employeeResultsCtdtn, this._extractSetupFrm.SectionCodeSt, this._extractSetupFrm.SectionCodeEd); // ADD 2010/09/21

                //if (this._employeeResultsAcs.DataSet.EmployeeResults.Count == 0)
                //{
                //    // 出力前の状態を戻ります
                //    ClearDetail();

                //    // 検索処理
                //    if (this.isSearch) // ADD 2010/09/14
                //        SearchEmployeeResults(false);

                //    TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Name,
                //        MSG_MATCHED_DATA_NOT_FOUND, -1, MessageBoxButtons.OK);

                //    return;
                //}

                //try
                //{
                //    if (this.ultraGridExcelExporter1.Export(this._inputDetails.uGrid_Details, this._extractSetupFrm.SettingFileName) != null)
                //    {
                //        // データセットをクリア
                //        this._employeeResultsAcs.DataSet.EmployeeResults.Clear(); // ADD 2010/09/14

                //        // 出力前の状態を戻ります
                //        ClearDetail();

                //        // 検索処理
                //        if (this.isSearch) // ADD 2010/09/14
                //            SearchEmployeeResults(false);
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
                //    this._employeeResultsAcs.DataSet.EmployeeResults.Clear(); // ADD 2010/09/14

                //    // 出力前の状態を戻ります
                //    ClearDetail(); // ADD 2010/09/14

                //    // 検索処理
                //    if (this.isSearch) // ADD 2010/09/14
                //        SearchEmployeeResults(false); // ADD 2010/09/14

                //    TMsgDisp.Show(
                //        this,
                //        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                //        this.Name,
                //        ex.Message,
                //        -1,
                //        MessageBoxButtons.OK);
                //}
                // --- DEL 2010/10/09 ----------<<<
            } //ADD 2010/08/12 障害ID:13038対応
            
        }

        /// <summary>
        /// 残高一覧をテキスト出力します。
        /// </summary>
        /// <br>Update Note : 2024/11/29 陳艶丹</br>
        /// <br>             PMKOBETSU-4368 2024年PKG格上のログ出力対応</br>
        private void ExportIntoTextFile(bool excelFlg)
        {
            // --- ADD 2010/08/12 障害ID:13038対応-------------------------------->>>>>
            if (this._prevControl != null)
            {
                checkFlg = false;
                ChangeFocusEventArgs e = new ChangeFocusEventArgs(false, false, false, Keys.Return, this._prevControl, this._prevControl);
                this.tRetKeyControl1_ChangeFocus(this, e);
            }
            if (!checkFlg)
            {
                // --- ADD 2010/08/12 障害ID:13038対応--------------------------------<<<<<
                this._extractSetupFrm = new PMHNB04161UC();

                this._extractSetupFrm.FormcloseFlg = false;
                // 出力形式
                this._extractSetupFrm.ExcelFlg = excelFlg;
                // 開始拠点
                this._extractSetupFrm.SectionCodeSt = this.tEdit_SectionCodeAllowZero.Text;
                // 終了拠点
                this._extractSetupFrm.SectionCodeEd = this.tEdit_SectionCodeAllowZero.Text;
                // 参照区分
                this._extractSetupFrm.ReferDiv = this.tComboEditor_Refer.SelectedIndex;
                // 期間区分
                this._extractSetupFrm.DuringDiv = this.tComboEditor_During.SelectedIndex;
                // 開始担当者
                this._extractSetupFrm.EmployeeCodeSt = this.tEdit_EmployeeCode_St.Text;
                // 終了担当者
                this._extractSetupFrm.EmployeeCodeEd = this.tEdit_EmployeeCode_Ed.Text;
                // 開始期間
                this._extractSetupFrm.DuringSt = this.tDateEdit_St_During.GetDateTime();
                // 終了期間
                this._extractSetupFrm.DuringEd = this.tDateEdit_Ed_During.GetDateTime();
                // 開始期間(年月)
                this._extractSetupFrm.DuringYmSt = this.tDateEdit_St_YearMonth.GetLongDate();
                // 終了期間(年月)
                this._extractSetupFrm.DuringYmEd = this.tDateEdit_Ed_YearMonth.GetLongDate();

                this._extractSetupFrm.OutputData += new PMHNB04161UC.OutputDataEvent(this.outputTextData); // ADD 2010/10/09

                //----- ADD 2024/11/29 陳艶丹 PMKOBETSU-4368 2024年PKG格上のログ出力対応 ----->>>>>
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
                //----- ADD 2024/11/29 陳艶丹 PMKOBETSU-4368 2024年PKG格上のログ出力対応 -----<<<<<

                this._extractSetupFrm.ShowDialog();

                // --- DEL 2010/10/09 ---------->>>
                //if (this._extractSetupFrm.DResult == DialogResult.Cancel)
                //{
                //    return;
                //}

                //EmployeeResultsCtdtn employeeResultsCtdtn = new EmployeeResultsCtdtn();
                //// 読込条件パラメータクラス設定処理
                //this.SetReadParaForOutput(out employeeResultsCtdtn);

                //// グリッド列設定処理
                //int duringFlg = _extractSetupFrm.DuringDiv;
                //int referDiv = this._extractSetupFrm.ReferDiv; // ADD 2010/09/09
                //if (duringFlg == 1)
                //{
                //    //this._inputDetails.InitialSettingGridColForOutput(1); // DEL 2010/09/09
                //    this._inputDetails.InitialSettingGridColForOutput(1, referDiv); // ADD 2010/09/09
                //}
                //else if (duringFlg == 2)
                //{
                //    //this._inputDetails.InitialSettingGridColForOutput(2); // DEL 2010/09/09
                //    this._inputDetails.InitialSettingGridColForOutput(2, referDiv); // ADD 2010/09/09
                //}
                //else
                //{
                //    //this._inputDetails.InitialSettingGridColForOutput(2); // DEL 2010/09/09
                //    this._inputDetails.InitialSettingGridColForOutput(2, referDiv); // ADD 2010/09/09
                //}
                ////this._employeeResultsAcs.SearchForOutput(employeeResultsCtdtn); // DEL 2010/08/20
                ////this._employeeResultsAcs.SearchForOutput(employeeResultsCtdtn, this._extractSetupFrm.SectionCodeSt); // ADD 2010/08/20
                //this._employeeResultsAcs.SearchForOutput(employeeResultsCtdtn, this._extractSetupFrm.SectionCodeSt, this._extractSetupFrm.SectionCodeEd); // ADD 2010/09/21


                ////string outputFileName = this._extractSetupFrm.SettingFileName;
                //if (String.IsNullOrEmpty(outputFileName))
                //{
                //    // 出力前の状態を戻ります
                //    ClearDetail();

                //    // 検索処理
                //    if (this.isSearch) // ADD 2010/09/14
                //        SearchEmployeeResults(false);

                //    // ファイル名が指定されていないとエラー
                //    TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Name,
                //        MSG_OUTPUTFILENAME_NOTFOUND, -1, MessageBoxButtons.OK);
                //    return;
                //}

                //if (this._employeeResultsAcs.DataSet.EmployeeResults.Count == 0)
                //{
                //    // 出力前の状態を戻ります
                //    ClearDetail();

                //    // 検索処理
                //    if (this.isSearch) // ADD 2010/09/14
                //        SearchEmployeeResults(false);

                //    TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Name,
                //        MSG_MATCHED_DATA_NOT_FOUND, -1, MessageBoxButtons.OK);

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

                //DataTable targetTable = this._employeeResultsAcs.DataSet.EmployeeResults;
                //// --- UPD 2010/09/09 ---------->>>>>
                ////targetTable.Columns["EmployeeCode"].Caption = "担当者";
                //if (referDiv == 1)
                //{
                //    targetTable.Columns["EmployeeCode"].Caption = "担当者";
                //    targetTable.Columns["EmployeeName"].Caption = "担当者名";
                //}
                //else if (referDiv == 2)
                //{
                //    targetTable.Columns["EmployeeCode"].Caption = "受注者";
                //    targetTable.Columns["EmployeeName"].Caption = "受注者名";
                //}
                //else if (referDiv == 3)
                //{
                //    targetTable.Columns["EmployeeCode"].Caption = "発行者";
                //    targetTable.Columns["EmployeeName"].Caption = "発行者名";
                //}
                //// --- UPD 2010/09/09 ----------<<<<<
                //targetTable.Columns["BackSalesTotalTaxExc"].Caption = "売上金額";
                //targetTable.Columns["RetGoodSalesTotalTaxExc"].Caption = "返品額";
                //targetTable.Columns["BackSalesDisTtlTaxExc"].Caption = "値引額";
                //targetTable.Columns["PureSales"].Caption = "純売上";
                //targetTable.Columns["SectionName"].Caption = "拠点";
                //targetTable.Columns["SalesTargetMoney"].Caption = "売上目標額";
                //targetTable.Columns["SalesStructure"].Caption = "売上構成比";
                ////targetTable.Columns["EmployeeName"].Caption = "担当者名"; // DEL 2010/09/09
                //targetTable.Columns["TotalCost"].Caption = "原価";
                //targetTable.Columns["RetGoodsPct"].Caption = "返品率";
                //targetTable.Columns["DisTtlPct"].Caption = "値引率";
                //targetTable.Columns["GrossProfit"].Caption = "粗利額";
                //targetTable.Columns["GrossProfitPct"].Caption = "粗利率";
                //targetTable.Columns["TargetPct"].Caption = "売上目標達成率";
                //targetTable.Columns["RetGoodsStructure"].Caption = "返品構成比";

                //if (this._extractSetupFrm.DuringDiv == 1)
                //{
                //    targetTable.Columns["DuringSt"].Caption = "開始年月日";
                //    targetTable.Columns["DuringEd"].Caption = "終了年月日";
                //}
                //else
                //{
                //    targetTable.Columns["DuringSt"].Caption = "開始年月";
                //    targetTable.Columns["DuringEd"].Caption = "終了年月";
                //}

                //Infragistics.Win.UltraWinGrid.ColumnsCollection Columns = this._inputDetails.uGrid_Details.DisplayLayout.Bands[0].Columns;
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
                //tw.DataSource = this._employeeResultsAcs.DataSet.EmployeeResults.DefaultView;

                //# region [フォーマットリスト]
                //Dictionary<string, string> formatList = new Dictionary<string, string>();
                //foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn col in this._inputDetails.uGrid_Details.DisplayLayout.Bands[0].Columns)
                //{
                //    if (col.Hidden == false)
                //    {
                //        formatList.Add(col.Key, col.Format);
                //    }
                //}
                //tw.FormatList = formatList;

                //#endregion // フォーマットリスト

                //#region オプションセット
                //// ファイル名
                ////tw.OutputFileName = this._extractSetupFrm.SettingFileName;
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
                //// データセットをクリア
                //this._employeeResultsAcs.DataSet.EmployeeResults.Clear(); // ADD 2010/09/14
                
                //// 出力前の状態を戻ります
                //ClearDetail();

                //// 検索処理
                //if (this.isSearch) // ADD 2010/09/14
                //    SearchEmployeeResults(false);

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
                // --- DEL 2010/10/09 ----------<<<
            }
        }

        //----- ADD 2024/11/29 陳艶丹 PMKOBETSU-4368 2024年PKG格上のログ出力対応 ---->>>>>
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
        /// <br>Date       : 2024/11/29</br>
        /// </remarks>
        private int TextOutPutWrite(int mode, ref TextOutPutOprtnHisLogWork textOutPutOprtnHisLogWorkObj, out string errMsg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            try
            {
                string outPutCon = string.Empty;
                textOutPutOprtnHisLogWorkObj = new TextOutPutOprtnHisLogWork();
                // ログデータ対象アセンブリID
                textOutPutOprtnHisLogWorkObj.LogDataObjAssemblyID = CT_EMPLOYEE_RESULT_PGID;
                // ログデータ対象アセンブリ名称
                textOutPutOprtnHisLogWorkObj.LogDataObjAssemblyNm = ASSEMBLYNM;
                // ログデータ対象起動プログラム名称
                textOutPutOprtnHisLogWorkObj.LogDataObjBootProgramNm = ASSEMBLYNM;
                if (mode == (int)OperationCode.TextOut || mode == (int)OperationCode.ExcelOut)
                {
                    if (mode == (int)OperationCode.TextOut)
                    {
                        // テキスト出力の場合
                        // ログデータ対象処理名:テキスト出力メソッド名
                        textOutPutOprtnHisLogWorkObj.LogDataObjProcNm = TEXT_METHODNM;
                    }
                    else
                    {
                        // Excel出力の場合
                        // ログデータ対象処理名:Excel出力メソッド名
                        textOutPutOprtnHisLogWorkObj.LogDataObjProcNm = EXCEL_METHODNM;
                    }
                }

                // ログオペレーションデータ
                //参照区分
                string referDivStr = string.Empty;
                //出力ファイル名
                string　outputFileName = string.Empty;
                if (this._extractSetupFrm.ReferDiv == 1)
                {
                    referDivStr = SALESINPUT_NAME; //担当者
                    outputFileName = this._extractSetupFrm.SettingFileName;
                }
                else if (this._extractSetupFrm.ReferDiv == 2)
                {
                    referDivStr = FRONTEMPLOYEE_SECTION_NAME;//受注者
                    outputFileName = this._extractSetupFrm.SettingFileNameSeller;
                }
                else if (this._extractSetupFrm.ReferDiv == 3)
                {
                    referDivStr = SALESEMPLOYEE_NAME;//発行者
                    outputFileName = this._extractSetupFrm.SettingFileNamePublisher;
                }
                else 
                {
                    referDivStr = string.Empty;
                    outputFileName = this._extractSetupFrm.SettingFileName;
                }
           
                // 拠点
                string sectionCdSt = this._extractSetupFrm.SectionCodeLogSt.Trim();
                sectionCdSt = string.IsNullOrEmpty(sectionCdSt) ? STARTSTR : sectionCdSt;
                string sectionCdEd = this._extractSetupFrm.SectionCodeLogEd.Trim();
                sectionCdEd = string.IsNullOrEmpty(sectionCdEd) ? ENDSTR : sectionCdEd;
                // 担当者
                string employeeCodeSt = this._extractSetupFrm.EmployeeCodeSt.Trim();
                employeeCodeSt = string.IsNullOrEmpty(employeeCodeSt) ? STARTSTR : employeeCodeSt;
                string employeeCodeEd = this._extractSetupFrm.EmployeeCodeEd.Trim();
                employeeCodeEd = string.IsNullOrEmpty(employeeCodeEd) ? ENDSTR : employeeCodeEd;


                //期間区分
                string duringDivStr = string.Empty;
                if (this._extractSetupFrm.DuringDiv == 1)
                {
                    // 日計
                    duringDivStr = DURINGDIV_DAILY;
                    // 期間(開始)YYYYMMDD
                    string duringSt = this._extractSetupFrm.DuringSt.ToString();
                    duringSt = string.IsNullOrEmpty(duringSt) ? STARTSTR : duringSt;
                    // 期間(終了)YYYYMMDD
                    string duringEd = this._extractSetupFrm.DuringEd.ToString();
                    duringEd = string.IsNullOrEmpty(duringEd) ? ENDSTR : duringEd;
                    // ログオペレーションデータ
                    outPutCon = string.Format(OUTPUTCON, referDivStr, duringDivStr, sectionCdSt, sectionCdEd, employeeCodeSt,
                        employeeCodeEd, duringSt, duringEd, outputFileName);
                }
                else if (this._extractSetupFrm.DuringDiv == 2)
                {
                    // 月計
                    duringDivStr = DURINGDIV_MOONGAUGE;
                    // 期間(開始)YYYYMM
                    string duringSt = TDateTime.LongDateToDateTime(this._extractSetupFrm.DuringYmSt).ToString("yyyy/MM");
                    // 期間(終了)YYYYMM
                    string duringEd = TDateTime.LongDateToDateTime(this._extractSetupFrm.DuringYmEd).ToString("yyyy/MM");
                    duringEd = string.IsNullOrEmpty(duringEd) ? ENDSTR : duringEd;
                    // ログオペレーションデータ
                    outPutCon = string.Format(OUTPUTCON, referDivStr, duringDivStr, sectionCdSt, sectionCdEd, employeeCodeSt,
                        employeeCodeEd, duringSt, duringEd, outputFileName);
                }
                else if (this._extractSetupFrm.DuringDiv == 3)
                {
                    // 当期
                    duringDivStr = DURINGDIV_CURRENTPERIOD;
                    // ログオペレーションデータ
                    outPutCon = string.Format(OUTPUTCON2, referDivStr, duringDivStr, sectionCdSt, sectionCdEd, employeeCodeSt,
                        employeeCodeEd, outputFileName);
                }
                else
                {
                    duringDivStr = string.Empty;
                    // ログオペレーションデータ
                    outPutCon = string.Format(OUTPUTCON2, referDivStr, duringDivStr, sectionCdSt, sectionCdEd, employeeCodeSt,
                        employeeCodeEd, outputFileName);
                }

                // ログオペレーションデータの設定
                textOutPutOprtnHisLogWorkObj.LogOperationData = outPutCon;
                status = TextOutPutOprtnHisLogAcsObj.Write(this, ref textOutPutOprtnHisLogWorkObj, out errMsg);
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
            }

            return status;
        }
        //----- ADD 2024/11/29 陳艶丹 2024年PKG格上のログ出力対応 -----<<<<<

        // --- ADD 2010/10/09 ---------->>>
        /// <summary>
        /// Excel出力処理
        /// </summary>
        /// <returns>True:正常; False:異常</returns>
        /// <br>Update Note :2024/11/29 陳艶丹</br>
        /// <br>             PMKOBETSU-4368 2024年PKG格上のログ出力対応</br>
        private bool outputExcelData()
        {
            if (this._extractSetupFrm.DResult == DialogResult.Cancel)
            {
                return true;
            }

            //----- ADD 2024/11/29 陳艶丹 PMKOBETSU-4368 2024年PKG格上のログ出力対応 ---->>>>>
            // エラーメッセージ
            string errMsg = string.Empty;
            TextOutPutOprtnHisLogWork textOutPutOprtnHisLogWorkObj = null;
            // テキスト出力操作ログ登録及び出力時アラートメッセージ表示処理「Excel出力」
            int logStatus = TextOutPutWrite((int)OperationCode.ExcelOut, ref textOutPutOprtnHisLogWorkObj, out errMsg);

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
            //----- ADD 2024/11/29 陳艶丹 PMKOBETSU-4368 2024年PKG格上のログ出力対応 ----<<<<<

            EmployeeResultsCtdtn employeeResultsCtdtn = new EmployeeResultsCtdtn();
            // 読込条件パラメータクラス設定処理
            this.SetReadParaForOutput(out employeeResultsCtdtn);

            // グリッド列設定処理
            int duringFlg = _extractSetupFrm.DuringDiv;
            int referDiv = this._extractSetupFrm.ReferDiv;
            if (duringFlg == 1)
            {
                this._inputDetails.InitialSettingGridColForOutput(1, referDiv);
            }
            else if (duringFlg == 2)
            {
                this._inputDetails.InitialSettingGridColForOutput(2, referDiv);
            }
            else
            {
                this._inputDetails.InitialSettingGridColForOutput(2, referDiv);
            }
            this._employeeResultsAcs.SearchForOutput(employeeResultsCtdtn, this._extractSetupFrm.SectionCodeSt, this._extractSetupFrm.SectionCodeEd);

            if (this._employeeResultsAcs.DataSet.EmployeeResults.Count == 0)
            {
                // 出力前の状態を戻ります
                ClearDetail();

                // 検索処理
                if (this.isSearch)
                    SearchEmployeeResults(false);

                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Name,
                    MSG_MATCHED_DATA_NOT_FOUND, -1, MessageBoxButtons.OK);

                return false;
            }

            try
            {
                string outputFileName = string.Empty;
                // 参照区分は受注者の場合
                if (referDiv == 2)
                {
                    outputFileName = this._extractSetupFrm.SettingFileNameSeller;
                }
                // 参照区分は発行者の場合
                else if (referDiv == 3)
                {
                    outputFileName = this._extractSetupFrm.SettingFileNamePublisher;
                }
                // そのほかの場合
                else
                {
                    outputFileName = this._extractSetupFrm.SettingFileName;
                }

                if (this.ultraGridExcelExporter1.Export(this._inputDetails.uGrid_Details, outputFileName) != null)
                {
                    int outputCount = ((DataTable)this._inputDetails.uGrid_Details.DataSource).Rows.Count; //ADD 2024/11/29 陳艶丹 PMKOBETSU-4368 2024年PKG格上のログ出力対応
                    // データセットをクリア
                    this._employeeResultsAcs.DataSet.EmployeeResults.Clear();

                    // 出力前の状態を戻ります
                    ClearDetail();

                    // 検索処理
                    if (this.isSearch)
                        SearchEmployeeResults(false);
                    // 成功
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        "EXCELデータを出力しました。",
                        -1,
                        MessageBoxButtons.OK);

                    //----- ADD 2024/11/29 陳艶丹 PMKOBETSU-4368 2024年PKG格上のログ出力対応 ----->>>>>
                    // エラーメッセージ
                    errMsg = string.Empty;
                    // 操作履歴登録
                    textOutPutOprtnHisLogWorkObj.LogOperationData = string.Format(COUNTNUMSTR, outputCount.ToString()) + textOutPutOprtnHisLogWorkObj.LogOperationData;
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
                    //----- ADD 2024/11/29 陳艶丹 PMKOBETSU-4368 2024年PKG格上のログ出力対応 -----<<<<<
                }
                return true;
            }
            catch (Exception ex)
            {
                // データセットをクリア
                this._employeeResultsAcs.DataSet.EmployeeResults.Clear();

                // 出力前の状態を戻ります
                ClearDetail();

                // 検索処理
                if (this.isSearch)
                    SearchEmployeeResults(false);

                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                    this.Name,
                    ex.Message,
                    -1,
                    MessageBoxButtons.OK);
                return false;
            }
        }

        /// <summary>
        /// テキスト出力処理
        /// </summary>
        /// <returns>True:正常; False:異常</returns>
        /// <br>Update Note:2011/02/16 liyp</br>
        /// <br>            テキスト出力対応</br>
        /// <br>Update Note :2024/11/29 陳艶丹</br>
        /// <br>             PMKOBETSU-4368 2024年PKG格上のログ出力対応</br>
        private bool outputTextData()
        {
            this._employeeResultsAcs.ExcOrtxtDiv = true; // ADD 2011/02/16
            if (this._extractSetupFrm.DResult == DialogResult.Cancel)
            {
                return true;
            }

            //----- ADD 2024/11/29 陳艶丹 PMKOBETSU-4368 2024年PKG格上のログ出力対応 ---->>>>>
            // エラーメッセージ
            string errMsg = string.Empty;
            TextOutPutOprtnHisLogWork textOutPutOprtnHisLogWorkObj = null;
            // テキスト出力操作ログ登録及び出力時アラートメッセージ表示処理「テキスト出力」
            int logStatus = TextOutPutWrite((int)OperationCode.TextOut, ref textOutPutOprtnHisLogWorkObj, out errMsg);

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
            //----- ADD 2024/11/29 陳艶丹 PMKOBETSU-4368 2024年PKG格上のログ出力対応 ----<<<<<

            EmployeeResultsCtdtn employeeResultsCtdtn = new EmployeeResultsCtdtn();
            // 読込条件パラメータクラス設定処理
            this.SetReadParaForOutput(out employeeResultsCtdtn);

            // グリッド列設定処理
            int duringFlg = _extractSetupFrm.DuringDiv;
            int referDiv = this._extractSetupFrm.ReferDiv;
            if (duringFlg == 1)
            {
                this._inputDetails.InitialSettingGridColForOutput(1, referDiv);
            }
            else if (duringFlg == 2)
            {
                this._inputDetails.InitialSettingGridColForOutput(2, referDiv);
            }
            else
            {
                this._inputDetails.InitialSettingGridColForOutput(2, referDiv);
            }
            this._employeeResultsAcs.SearchForOutput(employeeResultsCtdtn, this._extractSetupFrm.SectionCodeSt, this._extractSetupFrm.SectionCodeEd);

            string outputFileName = string.Empty;
            // 参照区分は受注者の場合
            if (referDiv == 2)
            {
                outputFileName = this._extractSetupFrm.SettingFileNameSeller;
            }
            // 参照区分は発行者の場合
            else if (referDiv == 3)
            {
                outputFileName = this._extractSetupFrm.SettingFileNamePublisher;
            }
            // そのほかの場合
            else
            {
                outputFileName = this._extractSetupFrm.SettingFileName;
            }

            if (String.IsNullOrEmpty(outputFileName))
            {
                // 出力前の状態を戻ります
                ClearDetail();

                // 検索処理
                if (this.isSearch)
                    SearchEmployeeResults(false);

                // ファイル名が指定されていないとエラー
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Name,
                    MSG_OUTPUTFILENAME_NOTFOUND, -1, MessageBoxButtons.OK);
                return false;
            }

            if (this._employeeResultsAcs.DataSet.EmployeeResults.Count == 0)
            {
                // 出力前の状態を戻ります
                ClearDetail();

                // 検索処理
                if (this.isSearch)
                    SearchEmployeeResults(false);

                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Name,
                    MSG_MATCHED_DATA_NOT_FOUND, -1, MessageBoxButtons.OK);

                return false;
            }

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

            DataTable targetTable = this._employeeResultsAcs.DataSet.EmployeeResults;

            if (referDiv == 1)
            {
                targetTable.Columns["EmployeeCode"].Caption = "担当者";
                targetTable.Columns["EmployeeName"].Caption = "担当者名";
            }
            else if (referDiv == 2)
            {
                targetTable.Columns["EmployeeCode"].Caption = "受注者";
                targetTable.Columns["EmployeeName"].Caption = "受注者名";
            }
            else if (referDiv == 3)
            {
                targetTable.Columns["EmployeeCode"].Caption = "発行者";
                targetTable.Columns["EmployeeName"].Caption = "発行者名";
            }

            targetTable.Columns["BackSalesTotalTaxExc"].Caption = "売上金額";
            targetTable.Columns["RetGoodSalesTotalTaxExc"].Caption = "返品額";
            targetTable.Columns["BackSalesDisTtlTaxExc"].Caption = "値引額";
            targetTable.Columns["PureSales"].Caption = "純売上";
            targetTable.Columns["SectionName"].Caption = "拠点";
            targetTable.Columns["SalesTargetMoney"].Caption = "売上目標額";
            targetTable.Columns["SalesStructure"].Caption = "売上構成比";
            targetTable.Columns["TotalCost"].Caption = "原価";
            targetTable.Columns["RetGoodsPct"].Caption = "返品率";
            targetTable.Columns["DisTtlPct"].Caption = "値引率";
            targetTable.Columns["GrossProfit"].Caption = "粗利額";
            targetTable.Columns["GrossProfitPct"].Caption = "粗利率";
            targetTable.Columns["TargetPct"].Caption = "売上目標達成率";
            targetTable.Columns["RetGoodsStructure"].Caption = "返品構成比";

            if (this._extractSetupFrm.DuringDiv == 1)
            {
                targetTable.Columns["DuringSt"].Caption = "開始年月日";
                targetTable.Columns["DuringEd"].Caption = "終了年月日";
            }
            else
            {
                targetTable.Columns["DuringSt"].Caption = "開始年月";
                targetTable.Columns["DuringEd"].Caption = "終了年月";
            }

            Infragistics.Win.UltraWinGrid.ColumnsCollection Columns = this._inputDetails.uGrid_Details.DisplayLayout.Bands[0].Columns;
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
                // ------------ ADD 2011/02/16 --------------------->>>>>
                if (Columns[i].ToString().Equals("RetGoodsStructure") 
                    || Columns[i].ToString().Equals("SalesStructure") 
                    || Columns[i].ToString().Equals("RetGoodsPct") 
                    || Columns[i].ToString().Equals("DisTtlPct") 
                    || Columns[i].ToString().Equals("GrossProfitPct") 
                    || Columns[i].ToString().Equals("TargetPct"))
                {
                    Columns[i].Format = "0.00;-0.00;";
                }
                else
                {
                    Columns[i].Format = ""; 
                }
                // ------------ ADD 2011/02/16 ---------------------<<<<<
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
            tw.DataSource = this._employeeResultsAcs.DataSet.EmployeeResults.DefaultView;

            # region [フォーマットリスト]
            Dictionary<string, string> formatList = new Dictionary<string, string>();
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn col in this._inputDetails.uGrid_Details.DisplayLayout.Bands[0].Columns)
            {
                if (col.Hidden == false)
                {
                    formatList.Add(col.Key, col.Format);
                }
            }
            tw.FormatList = formatList;

            #endregion // フォーマットリスト

            #region オプションセット
            // ファイル名
            // 参照区分は受注者の場合
            if (referDiv == 2)
            {
                tw.OutputFileName = this._extractSetupFrm.SettingFileNameSeller;
            }
            // 参照区分は発行者の場合
            else if (referDiv == 3)
            {
                tw.OutputFileName = this._extractSetupFrm.SettingFileNamePublisher;
            }
            // そのほかの場合
            else
            {
                tw.OutputFileName = this._extractSetupFrm.SettingFileName;
            }
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
            // データセットをクリア
            this._employeeResultsAcs.DataSet.EmployeeResults.Clear();

            // 出力前の状態を戻ります
            ClearDetail();

            // 検索処理
            if (this.isSearch)
                SearchEmployeeResults(false);

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

                //----- ADD 2024/11/29 陳艶丹 PMKOBETSU-4368 2024年PKG格上のログ出力対応 ----->>>>>
                // エラーメッセージ
                errMsg = string.Empty;
                // 操作履歴登録
                textOutPutOprtnHisLogWorkObj.LogOperationData = string.Format(COUNTNUMSTR, outputCount.ToString()) + textOutPutOprtnHisLogWorkObj.LogOperationData;
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
                //----- ADD 2024/11/29 陳艶丹 PMKOBETSU-4368 2024年PKG格上のログ出力対応 -----<<<<<
                return true;
            }
        }
        // --- ADD 2010/10/09 ----------<<<

        /// <summary>
        /// 読込条件パラメータ設定処理(出力用)
        /// </summary>
        /// <param>読込条件パラメータクラス</param>
        /// <param name="employeeResultsCtdtn">読込条件パラメータ</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 読込条件パラメータ設定処理を行う。 </br>
        /// <br>Programmer : 王開強</br>
        /// <br>Date       : 2010/07/20</br>
        /// </remarks>
        public void SetReadParaForOutput(out EmployeeResultsCtdtn employeeResultsCtdtn)
        {
            employeeResultsCtdtn = new EmployeeResultsCtdtn();

            //企業コード
            employeeResultsCtdtn.EnterpriseCode = this._enterpriseCode;

            employeeResultsCtdtn.SectionCodeList = this._extractSetupFrm.SectionCodeList;

            //参照区分  
            employeeResultsCtdtn.ReferType = this._extractSetupFrm.ReferDiv;
            //担当者(開始)
            employeeResultsCtdtn.St_EmployeeCode = this._extractSetupFrm.EmployeeCodeSt;
            //担当者(終了)
            employeeResultsCtdtn.Ed_EmployeeCode = this._extractSetupFrm.EmployeeCodeEd;

            //期間区分
            employeeResultsCtdtn.DuringType = this._extractSetupFrm.DuringDiv;

            if (employeeResultsCtdtn.DuringType == 1)
            {

                //期間(開始)YYYYMMDD
                employeeResultsCtdtn.St_DuringTime = this._extractSetupFrm.DuringSt;

                //期間(終了)YYYYMMDD
                employeeResultsCtdtn.Ed_DuringTime = this._extractSetupFrm.DuringEd;

            }
            else if (employeeResultsCtdtn.DuringType == 2 || employeeResultsCtdtn.DuringType == 3)
            {
                //期間(開始)YYYYMM
                employeeResultsCtdtn.St_YearMonth = TDateTime.LongDateToDateTime(this._extractSetupFrm.DuringYmSt);

                //期間(終了)YYYYMM
                employeeResultsCtdtn.Ed_YearMonth =  TDateTime.LongDateToDateTime(this._extractSetupFrm.DuringYmEd);
            }
            //画面ビュー・出力ビューフラグ  
            employeeResultsCtdtn.ViewFlg = "OUTPUT";

        }

        /// <summary>
        /// セルのコレクションイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <br>Note       : コンポーネントがクリックされたときに発生します。</br>
        /// <br>Programmer : 王開強</br>
        /// <br>Date       : 2010/07/20</br>
        private void ultraGridExcelExporter1_CellExported(object sender, Infragistics.Win.UltraWinGrid.ExcelExport.CellExportedEventArgs e)
        {
            int index = e.CurrentRowIndex;
            for (int celIndex = 0; celIndex < 18; celIndex++)
            {
                IWorksheetCellFormat tmCF = e.CurrentWorksheet.Rows[index].Cells[celIndex].CellFormat;
                if (7 == celIndex || 9 == celIndex || 12 == celIndex || 14 == celIndex || 16 == celIndex || 17 == celIndex) 
                    tmCF.FormatString = "0.00%;-0.00%;";
                else
                    tmCF.FormatString = "#,###,##0;-#,###,##0;";
                e.CurrentWorksheet.Rows[index].Cells[celIndex].CellFormat.SetFormatting(tmCF);
            }

        }

        // --- ADD 2010/07/20 --------------------------------<<<<<

        // --- ADD 2010/09/28 障害報告 #15609-------------------------------->>>>>
        /// <summary>
        /// tEdit_EmployeeCode_St_Leave
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tEdit_EmployeeCode_St_Leave(object sender, EventArgs e)
        {
            this._employeeCodeSt = this.tEdit_EmployeeCode_St.Text;
        }

        /// <summary>
        /// tEdit_EmployeeCode_Ed_Leave
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tEdit_EmployeeCode_Ed_Leave(object sender, EventArgs e)
        {
            this._employeeCodeEd = this.tEdit_EmployeeCode_Ed.Text;
        }

        /// <summary>
        /// tEdit_SectionCodeAllowZero_Leave
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tEdit_SectionCodeAllowZero_Leave(object sender, EventArgs e)
        {
            this._sectionCodeAllowZero = this.tEdit_SectionCodeAllowZero.Text;
        }
        // --- ADD 2010/09/28 障害報告 #15609--------------------------------<<<<<

    }

}