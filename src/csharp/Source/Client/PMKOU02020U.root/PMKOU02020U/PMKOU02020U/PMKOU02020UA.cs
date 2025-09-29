using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Infragistics.Win.Misc;

using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Controller.Util;    // ADD 2008/03/31 不具合対応[12921]：スペースキーでの項目選択機能を実装
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 仕入分析表UIフォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 仕入分析表UIフォームクラス</br>
    /// <br>Programmer : 30452 上野 俊治</br>
    /// <br>Date       : 2008.11.10</br>
    /// <br>Update Note: 2009.01.23 30452 上野 俊治</br>
    /// <br>            ・障害対応10381(当期期間の抽出条件を修正)</br>
    /// <br>           : 2009/03/05       照田 貴志　不具合対応[12188]</br>
    /// <br></br>
    /// </remarks>
    public partial class PMKOU02020UA : Form,
                                IPrintConditionInpType,					// 帳票共通（条件入力タイプ）
                                IPrintConditionInpTypeSelectedSection,	// 帳票業務（条件入力）拠点選択
                                IPrintConditionInpTypePdfCareer			// 帳票業務（条件入力）PDF出力履歴管理
    {
        #region ■ コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public PMKOU02020UA()
        {
            InitializeComponent();

            // 企業コード取得
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            // 拠点用のHashtable作成
            this._selectedSectionList = new Hashtable();

            // 日付取得部品
            _dateGet = DateGetAcs.GetInstance();

            // ガイド初期化
            this._supplierAcs = new SupplierAcs();

            // 抽出条件クラス
            this._slipHistAnalyzeParam = new SlipHistAnalyzeParam();

            // UI設定保存コンポーネント設定
            this.SetUIMemInputControl();
        }
        #endregion

        #region ■ private定数
        #region Interface関連
        //--IPrintConditionInpTypePdfCareerのプロパティ用変数 -------------------------
        // クラスID
        private const string ct_ClassID = "PMKOU02020UA";
        // プログラムID
        private const string ct_PGID = "PMKOU02020U";
        //// 帳票名称
        private string _printName = "仕入分析表";
        // 帳票キー	
        private string _printKey = "f32b6893-216e-4b60-aad8-b95825bd7e09";
        #endregion
        #endregion

        #region ■ private変数

        #region Interface関連
        //--IPrintConditionInpTypeのプロパティ用変数 ----------------------------------
        // 抽出ボタン状態取得プロパティ
        private bool _canExtract = false;
        // PDF出力ボタン状態取得プロパティ    
        private bool _canPdf = true;
        // 印刷ボタン状態取得プロパティ
        private bool _canPrint = true;
        // 抽出ボタン表示有無プロパティ
        private bool _visibledExtractButton = false;
        // PDF出力ボタン表示有無プロパティ	
        private bool _visibledPdfButton = true;
        // 印刷ボタン表示有無プロパティ
        private bool _visibledPrintButton = true;

        //--IPrintConditionInpTypeSelectedSectionのプロパティ用変数 -------------------
        // 計上拠点選択表示取得プロパティ
        private bool _visibledSelectAddUpCd = false;
        // 拠点オプション有無
        private bool _isOptSection = false;
        // 本社機能有無
        private bool _isMainOfficeFunc = false;
        // 選択拠点リスト
        private Hashtable _selectedSectionList = new Hashtable();
        #endregion

        // 画面イメージコントロール部品
        private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();
        // 日付取得部品
        private DateGetAcs _dateGet;

        // 仕入先ガイド
        private SupplierAcs _supplierAcs;

        // 仕入分析表 抽出条件データクラス
        private SlipHistAnalyzeParam _slipHistAnalyzeParam;

        // 企業コード
        private string _enterpriseCode = "";

        // ADD 2009/03/31 不具合対応[12921]：スペースキーでの項目選択機能を実装 ---------->>>>>
        /// <summary>構成比単位ラジオボタンのKeyPressイベントのヘルパ</summary>
        private readonly OptionSetKeyPressEventHelper _constUnitRadioKeyPressHelper = new OptionSetKeyPressEventHelper();
        /// <summary>
        /// 構成比単位ラジオボタンのKeyPressイベントのヘルパを取得します。
        /// </summary>
        /// <value>構成比単位ラジオボタンのKeyPressイベントのヘルパ</value>
        public OptionSetKeyPressEventHelper ConstUnitRadioKeyPressHelper
        {
            get { return _constUnitRadioKeyPressHelper; }
        }

        /// <summary>金額単位ラジオボタンのKeyPressイベントのヘルパ</summary>
        private readonly OptionSetKeyPressEventHelper _moneyUnitDivRadioKeyPressHelper = new OptionSetKeyPressEventHelper();
        /// <summary>
        /// 金額単位ラジオボタンのKeyPressイベントのヘルパを取得します。
        /// </summary>
        /// <value>金額単位ラジオボタンのKeyPressイベントのヘルパ</value>
        public OptionSetKeyPressEventHelper MoneyUnitDivRadioKeyPressHelper
        {
            get { return _moneyUnitDivRadioKeyPressHelper; }
        }

        /// <summary>改頁ラジオボタンのKeyPressイベントのヘルパ</summary>
        private readonly OptionSetKeyPressEventHelper _newPageDivRadioKeyPressHelper = new OptionSetKeyPressEventHelper();
        /// <summary>
        /// 改頁ラジオボタンのKeyPressイベントのヘルパを取得します。
        /// </summary>
        /// <value>改頁ラジオボタンのKeyPressイベントのヘルパ</value>
        public OptionSetKeyPressEventHelper NewPageDivRadioKeyPressHelper
        {
            get { return _newPageDivRadioKeyPressHelper; }
        }
        // ADD 2009/03/31 不具合対応[12921]：スペースキーでの項目選択機能を実装 ----------<<<<<

        #endregion

        #region ■ IPrintConditionInpType メンバ
        #region イベント
        /// <summary> 親ツールバー設定イベント </summary>
        public event ParentToolbarSettingEventHandler ParentToolbarSettingEvent;
        #endregion

        #region Publicプロパティ
        /// <summary> 抽出ボタン状態取得プロパティ </summary>
        public bool CanExtract
        {
            get { return this._canExtract; }
        }

        /// <summary> PDF出力ボタン状態取得プロパティ </summary>
        public bool CanPdf
        {
            get { return this._canPdf; }
        }

        /// <summary> 印刷ボタン状態取得プロパティ </summary>
        public bool CanPrint
        {
            get { return this._canPrint; }
        }

        /// <summary> 抽出ボタン表示有無プロパティ </summary>
        public bool VisibledExtractButton
        {
            get { return this._visibledExtractButton; }
        }

        /// <summary> PDF出力ボタン表示有無プロパティ </summary>
        public bool VisibledPdfButton
        {
            get { return this._visibledPdfButton; }
        }

        /// <summary> 印刷ボタン表示プロパティ </summary>
        public bool VisibledPrintButton
        {
            get { return this._visibledPrintButton; }
        }

        #endregion

        #region ◆ Public Method
        #region ◎ 抽出処理
        /// <summary>
        /// 抽出処理
        /// </summary>
        /// <param name="parameter">パラメータ</param>
        /// <returns>0( 固定 )</returns>
        public int Extract(ref object parameter)
        {
            // 抽出処理は無いので処理終了
            return 0;
        }
        #endregion

        #region ◎ 印刷処理
        /// <summary>
        /// 印刷処理
        /// </summary>
        /// <param name="parameter">パラメータ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note		: 印刷処理を行う。</br>
        /// <br>Programmer	: 30452 上野 俊治</br>
        /// <br>Date		: 2008.11.10</br>
        /// </remarks>
        public int Print(ref object parameter)
        {
            SFCMN06001U printDialog = new SFCMN06001U();		// 帳票選択ガイド
            SFCMN06002C printInfo = parameter as SFCMN06002C;	// 印刷情報パラメータ

            // 企業コードをセット
            printInfo.enterpriseCode = this._enterpriseCode;
            printInfo.kidopgid = ct_PGID;				// 起動PGID

            // PDF出力履歴用
            printInfo.key = this._printKey;
            printInfo.prpnm = this._printName;

            printInfo.PrintPaperSetCd = 0;
            // 画面→抽出条件クラス
            int status = this.SetExtraInfoFromScreen();
            if (status != 0)
            {
                return -1;
            }

            // 抽出条件の設定
            printInfo.jyoken = this._slipHistAnalyzeParam;
            printDialog.PrintInfo = printInfo;

            // 帳票選択ガイド
            DialogResult dialogResult = printDialog.ShowDialog();

            if (printInfo.status == (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN)
            {
                MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "該当するデータがありません", 0);
            }

            parameter = printInfo;

            return printInfo.status;
        }
        #endregion

        #region ◎ 印刷前確認処理
        /// <summary>
        /// 印刷前確認処理
        /// </summary>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note		: 印刷前確認処理を行う。(入力チェックなど)</br>
        /// <br>Programmer	: 30452 上野 俊治</br>
        /// <br>Date		: 2008.11.10</br>
        /// </remarks>
        public bool PrintBeforeCheck()
        {
            bool status = true;

            string errMessage = "";
            Control errComponent = null;

            if (!this.ScreenInputCheck(ref errMessage, ref errComponent))
            {
                // メッセージを表示
                this.MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, errMessage, 0);

                // コントロールにフォーカスをセット
                if (errComponent != null)
                {
                    errComponent.Focus();
                }

                status = false;
            }

            return status;
        }
        #endregion

        #region ◎ 画面表示処理
        /// <summary>
        /// 画面表示処理
        /// </summary>
        /// <param name="parameter">起動パラメータ</param>
        /// <remarks>
        /// <br>Note		: 画面表示を行う。</br>
        /// <br>Programmer	: 30452 上野 俊治</br>
        /// <br>Date		: 2008.11.10</br>
        /// </remarks>
        public void Show(object parameter)
        {
            this.Show();
            return;
        }
        #endregion

        #endregion
        #endregion ■ IPrintConditionInpType メンバ

        #region ■ IPrintConditionInpTypeSelectedSection メンバ
        #region ◆ Public Property

        /// <summary> 本社機能プロパティ </summary>
        public bool IsMainOfficeFunc
        {
            get { return _isMainOfficeFunc; }
            set { _isMainOfficeFunc = value; }
        }

        /// <summary> 拠点オプションプロパティ </summary>
        public bool IsOptSection
        {
            get { return _isOptSection; }
            set { _isOptSection = value; }
        }

        /// <summary> 計上拠点選択表示取得プロパティ </summary>
        public bool VisibledSelectAddUpCd
        {
            get { return _visibledSelectAddUpCd; }
        }

        #endregion ◆ Public Property

        #region ◆ Public Method

        #region ◎ 拠点選択処理
        /// <summary>
        /// 拠点選択処理
        /// </summary>
        /// <param name="sectionCode">選択拠点コード</param>
        /// <param name="checkState">選択状態</param>
        /// <remarks>
        /// <br>Note		: 拠点選択処理を行う。</br>
        /// <br>Programmer	: 30452 上野 俊治</br>
        /// <br>Date		: 2008.11.10</br>
        /// </remarks>
        public void CheckedSection(string sectionCode, CheckState checkState)
        {
            // 拠点を選択した時
            if (checkState == CheckState.Checked)
            {
                // 全社が選択された場合
                if (sectionCode == "0")
                {
                    this._selectedSectionList.Clear();

                }

                if (!this._selectedSectionList.ContainsKey(sectionCode))
                {
                    this._selectedSectionList.Add(sectionCode, sectionCode);
                }

            }
            // 拠点選択を解除した時
            else if (checkState == CheckState.Unchecked)
            {
                if (this._selectedSectionList.ContainsKey(sectionCode))
                {
                    this._selectedSectionList.Remove(sectionCode);
                }
            }
        }
        #endregion

        #region ◎ 初期選択計上拠点設定処理( 未実装 )
        /// <summary>
        /// 初期選択計上拠点設定処理( 未実装 )
        /// </summary>
        /// <param name="addUpCd"></param>
        /// <remarks>
        /// <br>Note		: 未実装</br>
        /// <br>Programmer	: 30452 上野 俊治</br>
        /// <br>Date		: 2008.11.10</br>
        /// </remarks>
        public void InitSelectAddUpCd(int addUpCd)
        {
            // 計上拠点選択がないので未実装
        }
        #endregion

        #region ◎ 初期選択拠点設定処理
        /// <summary>
        /// 初期選択拠点設定処理
        /// </summary>
        /// <param name="sectionCodeLst">選択拠点コードリスト</param>
        /// <remarks>
        /// <br>Note		: 拠点リストの初期化を行う。</br>
        /// <br>Programmer	: 30452 上野 俊治</br>
        /// <br>Date		: 2008.11.10</br>
        /// </remarks>
        public void InitSelectSection(string[] sectionCodeLst)
        {
            // 選択リスト初期化
            this._selectedSectionList.Clear();

            foreach (string wk in sectionCodeLst)
            {
                this._selectedSectionList.Add(wk, wk);
            }
        }
        #endregion

        #region ◎ 初期拠点選択表示チェック処理
        /// <summary>
        /// 初期拠点選択表示チェック処理
        /// </summary>
        /// <param name="isDefaultState">true：スライダー表示　false：スライダー非表示</param>
        /// <remarks>
        /// <br>Note		: 拠点選択スライダーの表示有無を判定する。</br>
        /// <br>			: 拠点オプション、本社機能以外の個別の表示有無判定を行う。</br>
        /// <br>Programmer	: 30452 上野 俊治</br>
        /// <br>Date		: 2008.11.10</br>
        /// </remarks>
        public bool InitVisibleCheckSection(bool isDefaultState)
        {
            return isDefaultState;
        }
        #endregion

        #region ◎ 計上拠点選択処理( 未実装 )
        /// <summary>
        /// 計上拠点選択処理( 未実装 )
        /// </summary>
        /// <param name="addUpCd"></param>
        /// <remarks>
        /// <br>Note		: 未実装</br>
        /// <br>Programmer	: 30452 上野 俊治</br>
        /// <br>Date		: 2008.11.10</br>
        /// </remarks>
        public void SelectedAddUpCd(int addUpCd)
        {
            // 計上拠点選択がないので未実装
        }
        #endregion

        #endregion ◆ Public Method
        #endregion ■ IPrintConditionInpTypeSelectedSection メンバ

        #region ■ IPrintConditionInpTypePdfCareer メンバ
        #region ◆ Public Property

        /// <summary> 帳票キープロパティ </summary>
        public string PrintKey
        {
            get { return this._printKey; }
        }

        /// <summary> 帳票名プロパティ </summary>
        public string PrintName
        {
            get { return this._printName; }
        }

        #endregion ◆ Public Method
        #endregion ■ IPrintConditionInpTypePdfCareer メンバ

        #region ■ privateメソッド
        /// <summary>
        /// 画面初期化処理
        /// </summary>
        /// <remarks>
        /// <br>Note		: 画面初期化を行う</br>
        /// <br>Programmer	: 30452 上野 俊治</br>
        /// <br>Date		: 2008.11.10</br>
        /// </remarks>
        private int InitializeScreen(out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            errMsg = string.Empty;

            try
            {
                // ガイドボタン設定
                this.SetIconImage(this.uButton_SupplierCdStGuid, Size16_Index.STAR1);
                this.SetIconImage(this.uButton_SupplierCdEdGuid, Size16_Index.STAR1);

                // 対象年月を取得 (初期値：処理年月)
                /* ---ADD 2009/03/05 不具合対応[12188] -------------------------------->>>>>
                DateTime yearMonth;
                this._dateGet.GetThisYearMonth(out yearMonth);

                this.tde_St_AddUpYearMonth.SetDateTime(yearMonth);
                this.tde_Ed_AddUpYearMonth.SetDateTime(yearMonth);
                   ---ADD 2009/03/05 不具合対応[12188] --------------------------------<<<<< */
                // ---ADD 2009/03/05 不具合対応[12188] -------------------------------->>>>>
                TotalDayCalculator totalDayCalculator = TotalDayCalculator.GetInstance();
                DateTime prevTotalDay;
                DateTime currentTotalDay;
                DateTime prevTotalMonth;
                DateTime currentTotalMonth;
                totalDayCalculator.InitializeHisMonthlyAccPay();
                totalDayCalculator.GetHisTotalDayMonthlyAccPay(LoginInfoAcquisition.Employee.BelongSectionCode, out prevTotalDay, out currentTotalDay, out prevTotalMonth, out currentTotalMonth);
                if (currentTotalMonth != DateTime.MinValue)
                {
                    // 売上今回月次更新日を設定
                    this.tde_St_AddUpYearMonth.SetDateTime(currentTotalMonth);
                    this.tde_Ed_AddUpYearMonth.SetDateTime(currentTotalMonth);
                }
                else
                {
                    // 当月を設定
                    DateTime nowYearMonth;
                    this._dateGet.GetThisYearMonth(out nowYearMonth);

                    this.tde_St_AddUpYearMonth.SetDateTime(nowYearMonth);
                    this.tde_Ed_AddUpYearMonth.SetDateTime(nowYearMonth);
                }
                // ---ADD 2009/03/05 不具合対応[12188] --------------------------------<<<<<



                // 構成比単位
                this.uos_ConstUnit.CheckedIndex = 0;
                // 金額単位
                this.uos_MoneyUnitDiv.CheckedIndex = 0;
                // 改頁
                this.uos_NewPageDiv.CheckedIndex = 0;

                // 発行タイプ
                this.tComboEditor_PrintType.SelectedIndex = 0;
                // 印刷タイプ
                this.tComboEditor_PrintTermType.SelectedIndex = 0;

                // 仕入先
                this.tNedit_SupplierCd_St.SetInt(0);
                this.tNedit_SupplierCd_Ed.SetInt(0);

                // 前回表示状態が保存されていれば上書き
                this.uiMemInput1.ReadMemInput();

                // 初期フォーカス
                this.tde_St_AddUpYearMonth.Focus();
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }

            return status;
        }

        /// <summary>
        /// ボタンアイコン設定処理
        /// </summary>
        /// <param name="settingControl">アイコンセットするコントロール</param>
        /// <param name="iconIndex">アイコンインデックス</param>
        private void SetIconImage(object settingControl, Size16_Index iconIndex)
        {
            ((UltraButton)settingControl).ImageList = IconResourceManagement.ImageList16;
            ((UltraButton)settingControl).Appearance.Image = iconIndex;
        }

        /// <summary>
        /// 入力チェック処理
        /// </summary>
        /// <param name="errMessage">エラーメッセージ</param>
        /// <param name="errComponent">エラー発生コンポーネント</param>
        /// <returns>True:OK, False:NG</returns>
        /// <remarks>
        /// <br>Note		: 画面の入力チェックを行う。</br>
        /// <br>Programmer	: 30452 上野 俊治</br>
        /// <br>Date		: 2008.11.10</br>
        /// </remarks>
        private bool ScreenInputCheck(ref string errMessage, ref Control errComponent)
        {
            bool status = true;

            DateGetAcs.CheckDateRangeResult cdrResult;

            const string ct_NoInput = "を入力して下さい";
            const string ct_InputError = "の入力が不正です";
            const string ct_RangeError = "の範囲指定に誤りがあります";
            const string ct_ErrorOfRangeOver = "は同一年度内で入力して下さい";

            // 対象年月
            if (CallCheckDateRange(out cdrResult, ref tde_St_AddUpYearMonth, ref tde_Ed_AddUpYearMonth) == false)
            {
                switch (cdrResult)
                {
                    case DateGetAcs.CheckDateRangeResult.ErrorOfStartNoInput:
                        {
                            errMessage = string.Format("開始対象年月{0}", ct_NoInput);
                            errComponent = this.tde_St_AddUpYearMonth;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfStartInvalid:
                        {
                            errMessage = string.Format("開始対象年月{0}", ct_InputError);
                            errComponent = this.tde_St_AddUpYearMonth;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfEndNoInput:
                        {
                            errMessage = string.Format("終了対象年月{0}", ct_NoInput);
                            errComponent = this.tde_Ed_AddUpYearMonth;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfEndInvalid:
                        {
                            errMessage = string.Format("終了対象年月{0}", ct_InputError);
                            errComponent = this.tde_Ed_AddUpYearMonth;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfReverse:
                        {
                            errMessage = string.Format("対象年月{0}", ct_RangeError);
                            errComponent = this.tde_St_AddUpYearMonth;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfRangeOver:
                    case DateGetAcs.CheckDateRangeResult.ErrorOfNotOnYear:
                        {
                            errMessage = string.Format("対象年月{0}", ct_ErrorOfRangeOver);
                            errComponent = this.tde_St_AddUpYearMonth;
                        }
                        break;
                }
                status = false;
            }
            // 仕入先
            else if ((this.tNedit_SupplierCd_St.GetInt() > this.tNedit_SupplierCd_Ed.GetInt()) && (this.tNedit_SupplierCd_Ed.GetInt() != 0))
            {
                errMessage = string.Format("仕入先{0}", ct_RangeError);
                errComponent = this.tNedit_SupplierCd_St;
                status = false;
            }

            return status;
        }

        /// <summary>
        /// 日付チェック処理呼び出し
        /// </summary>
        /// <param name="cdrResult"></param>
        /// <param name="tde_St_OrderDataCreateDate"></param>
        /// <param name="tde_Ed_OrderDataCreateDate"></param>
        /// <returns></returns>
        private bool CallCheckDateRange(out DateGetAcs.CheckDateRangeResult cdrResult, ref TDateEdit tde_St_OrderDataCreateDate, ref TDateEdit tde_Ed_OrderDataCreateDate)
        {
            cdrResult = _dateGet.CheckDateRange(DateGetAcs.YmdType.YearMonth, 12, ref tde_St_OrderDataCreateDate, ref tde_Ed_OrderDataCreateDate, false, true);
            return (cdrResult == DateGetAcs.CheckDateRangeResult.OK);
        }

        /// <summary>
        /// 抽出条件設定処理(画面→抽出条件)
        /// </summary>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note		: 画面→抽出条件へ設定する。</br>
        /// <br>Programmer	: 30452 上野 俊治</br>
        /// <br>Date		: 2008.11.10</br>
        /// </remarks>
        private int SetExtraInfoFromScreen()
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            try
            {
                // 全拠点チェック
                bool allSections = false;

                foreach (object obj in _selectedSectionList.Values)
                {
                    if (obj is string)
                    {
                        if ((obj as string) == "0")
                        {
                            allSections = true;
                            break;
                        }
                    }
                }
                if (allSections)
                {
                    _selectedSectionList.Clear();
                }

                // 拠点オプション
                this._slipHistAnalyzeParam.IsOptSection = this._isOptSection;
                // 拠点コード
                this._slipHistAnalyzeParam.SectionCodes = (string[])new ArrayList(this._selectedSectionList.Values).ToArray(typeof(string));
                // 企業コード
                this._slipHistAnalyzeParam.EnterpriseCode = this._enterpriseCode;

                // 開始年度(YYYYMM)
                this._slipHistAnalyzeParam.StAddUpYearMonth = this.tde_St_AddUpYearMonth.GetLongDate() / 100;
                // 終了年度(YYYYMM)
                this._slipHistAnalyzeParam.EdAddUpYearMonth = this.tde_Ed_AddUpYearMonth.GetLongDate() / 100;

                // 開始月を含む年の情報を取得
                int year;
                int addYears;
                DateTime stYMonth;
                DateTime edYMonth;
                _dateGet.GetYearFromMonth(tde_Ed_AddUpYearMonth.GetDateTime(), out year, out addYears, out stYMonth, out edYMonth);

                // --- DEL 2009/01/23 -------------------------------->>>>>
                //int tmpStMonth = stYMonth.Month; // 期首月
                //int tmpEdMonth = this.tde_Ed_AddUpYearMonth.GetDateTime().Month; // 終了月は入力から取得

                //// 開始計上年月(YYYYMM)
                //this._slipHistAnalyzeParam.StAnnualAddUpYearMonth = ((this.tde_Ed_AddUpYearMonth.GetLongDate() / 10000) * 100) + tmpStMonth;
                //// 終了計上年月(YYYYMM)
                //this._slipHistAnalyzeParam.EdAnnualAddUpYearMonth = ((this.tde_Ed_AddUpYearMonth.GetLongDate() / 10000) * 100) + tmpEdMonth;
                // --- DEL 2009/01/23 --------------------------------<<<<<
                // --- ADD 2009/01/23 -------------------------------->>>>>
                // 開始計上年月(YYYYMM)
                this._slipHistAnalyzeParam.StAnnualAddUpYearMonth = stYMonth.Year * 100 + stYMonth.Month;
                // 終了計上年月(YYYYMM)
                this._slipHistAnalyzeParam.EdAnnualAddUpYearMonth = this.tde_Ed_AddUpYearMonth.GetLongDate() / 100;
                // --- ADD 2009/01/23 --------------------------------<<<<<

                // 構成比単位
                this._slipHistAnalyzeParam.ConstUnitDiv = (SlipHistAnalyzeParam.ConstUnitDivState)this.uos_ConstUnit.CheckedItem.DataValue;
                // 金額単位
                this._slipHistAnalyzeParam.MoneyUnitDiv = (SlipHistAnalyzeParam.MoneyUnitDivState)this.uos_MoneyUnitDiv.CheckedItem.DataValue;
                // 改頁
                this._slipHistAnalyzeParam.NewPageDiv = (SlipHistAnalyzeParam.NewPageDivState)this.uos_NewPageDiv.CheckedItem.DataValue;
                // 発行タイプ
                this._slipHistAnalyzeParam.PrintType = (SlipHistAnalyzeParam.PrintTypeState)this.tComboEditor_PrintType.SelectedItem.DataValue;
                // 印刷タイプ
                this._slipHistAnalyzeParam.PrintTermType = (SlipHistAnalyzeParam.PrintTermTypeState)this.tComboEditor_PrintTermType.SelectedItem.DataValue;

                // 開始仕入先コード
                this._slipHistAnalyzeParam.StSupplierCd = this.tNedit_SupplierCd_St.GetInt();
                // 終了仕入先コード
                this._slipHistAnalyzeParam.EdSupplierCd = this.tNedit_SupplierCd_Ed.GetInt();

            }
            catch (Exception)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }

            return status;
        }

        /// <summary>
        /// UIMemInputの保存項目設定
        /// </summary>
        private void SetUIMemInputControl()
        {
            // 入力保存項目をセット
            List<Control> saveCtrAry = new List<Control>();

            //saveCtrAry.Add(this.tde_St_AddUpYearMonth);           //DEL 2009/03/05 不具合対応[12188]
            //saveCtrAry.Add(this.tde_Ed_AddUpYearMonth);           //DEL 2009/03/05 不具合対応[12188]
            saveCtrAry.Add(this.uos_ConstUnit);
            saveCtrAry.Add(this.uos_MoneyUnitDiv);
            saveCtrAry.Add(this.uos_NewPageDiv);
            saveCtrAry.Add(this.tComboEditor_PrintType);
            saveCtrAry.Add(this.tComboEditor_PrintTermType);
            saveCtrAry.Add(this.tNedit_SupplierCd_St);
            saveCtrAry.Add(this.tNedit_SupplierCd_Ed);

            this.uiMemInput1.TargetControls = saveCtrAry;
            this.uiMemInput1.ReadOnLoad = false;
        }

        /// <summary>
        /// エラーメッセージ表示処理
        /// </summary>
        /// <param name="iLevel">エラーレベル</param>
        /// <param name="message">表示メッセージ</param>
        /// <param name="status">ステータス</param>
        /// <remarks>
        /// <br>Note       : エラーメッセージの表示を行います。</br>
        /// <br>Programmer	: 30452 上野 俊治</br>
        /// <br>Date		: 2008.11.10</br>
        /// </remarks>
        private void MsgDispProc(emErrorLevel iLevel, string message, int status)
        {
            TMsgDisp.Show(
                iLevel, 							// エラーレベル
                ct_ClassID,							// アセンブリＩＤまたはクラスＩＤ
                this._printName,					// プログラム名称
                "", 								// 処理名称
                "",									// オペレーション
                message,							// 表示するメッセージ
                status, 							// ステータス値
                null, 								// エラーが発生したオブジェクト
                MessageBoxButtons.OK, 				// 表示するボタン
                MessageBoxDefaultButton.Button1);	// 初期表示ボタン
        }
        #endregion

        #region ■ コントロールイベント
        /// <summary>
        /// PMKOU02020UA_Loadイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note		: フォーム読込イベント。</br>
        /// <br>Programmer	: 30452 上野 俊治</br>
        /// <br>Date		: 2008.10.31</br>
        /// </remarks>
        private void PMKOU02020UA_Load(object sender, EventArgs e)
        {
            string errMsg = string.Empty;

            // コントロール初期化
            int status = this.InitializeScreen(out errMsg);
            if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                MsgDispProc(emErrorLevel.ERR_LEVEL_STOPDISP, errMsg, status);
                return;
            }

            // 画面イメージ統一
            this._controlScreenSkin.LoadSkin();						// 画面スキンファイルの読込(デフォルトスキン指定)
            this._controlScreenSkin.SettingScreenSkin(this);		// 画面スキン変更

            ParentToolbarSettingEvent(this);						// ツールバーボタン設定イベント起動

            // ADD 2009/03/31 不具合対応[12921]：スペースキーでの項目選択機能を実装 ---------->>>>>
            ConstUnitRadioKeyPressHelper.ControlList.Add(this.uos_ConstUnit);
            ConstUnitRadioKeyPressHelper.StartSpaceKeyControl();

            MoneyUnitDivRadioKeyPressHelper.ControlList.Add(this.uos_MoneyUnitDiv);
            MoneyUnitDivRadioKeyPressHelper.StartSpaceKeyControl();

            NewPageDivRadioKeyPressHelper.ControlList.Add(this.uos_NewPageDiv);
            NewPageDivRadioKeyPressHelper.StartSpaceKeyControl();
            // ADD 2009/03/31 不具合対応[12921]：スペースキーでの項目選択機能を実装 ----------<<<<<
        }

        /// <summary>
        /// 仕入先(開始)ボタン押下イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_SupplierCdStGuid_Click(object sender, EventArgs e)
        {
            // 仕入先ガイド起動
            Supplier supplier;

            int status = this._supplierAcs.ExecuteGuid(out supplier, this._enterpriseCode, "");

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this.tNedit_SupplierCd_St.SetInt(supplier.SupplierCd);
                this.tNedit_SupplierCd_Ed.Focus();
            }
        }

        /// <summary>
        /// 仕入先(終了)ボタン押下イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_SupplierCdEdGuid_Click(object sender, EventArgs e)
        {
            // 仕入先ガイド起動
            Supplier supplier;

            int status = this._supplierAcs.ExecuteGuid(out supplier, this._enterpriseCode, "");

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this.tNedit_SupplierCd_Ed.SetInt(supplier.SupplierCd);
                this.tde_St_AddUpYearMonth.Focus();
            }
        }

        /// <summary>
        /// ChangeFocusイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tArrowKeyControl1_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == this.tde_St_AddUpYearMonth)
            {
                if (e.NextCtrl == this.uButton_SupplierCdEdGuid && (e.Key == Keys.Tab || e.Key == Keys.Enter))
                {
                    e.NextCtrl = this.tNedit_SupplierCd_Ed;
                }
            }
            else if (e.PrevCtrl == this.tNedit_SupplierCd_St)
            {
                if (e.NextCtrl == this.uButton_SupplierCdStGuid && (e.Key == Keys.Tab || e.Key == Keys.Enter))
                {
                    e.NextCtrl = this.tNedit_SupplierCd_Ed;
                }
            }
            else if (e.PrevCtrl == this.tNedit_SupplierCd_Ed)
            {
                if (e.NextCtrl == this.uButton_SupplierCdStGuid && (e.Key == Keys.Tab || e.Key == Keys.Enter))
                {
                    e.NextCtrl = this.tNedit_SupplierCd_St;
                }
                else if (e.NextCtrl == this.uButton_SupplierCdEdGuid && (e.Key == Keys.Tab || e.Key == Keys.Enter))
                {
                    e.NextCtrl = this.tde_St_AddUpYearMonth;
                }
            }
        }

        /// <summary>
        /// tde_St_AddUpYearMonth_Leaveイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tde_St_AddUpYearMonth_Leave(object sender, EventArgs e)
        {
            int longDate = this.tde_St_AddUpYearMonth.GetLongDate();
            longDate = (longDate / 100) * 100 + 1;
            this.tde_St_AddUpYearMonth.SetLongDate(longDate);
        }

        /// <summary>
        /// tde_Ed_AddUpYearMonth_Leaveイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tde_Ed_AddUpYearMonth_Leave(object sender, EventArgs e)
        {
            int longDate = this.tde_Ed_AddUpYearMonth.GetLongDate();
            longDate = (longDate / 100) * 100 + 1;
            this.tde_Ed_AddUpYearMonth.SetLongDate(longDate);
        }

        /// <summary>
        /// ultraExplorerBar1_GroupCollapsingイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ultraExplorerBar1_GroupCollapsing(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
        {
            if ((e.Group.Key == "ReportSelectGroup") ||
                (e.Group.Key == "PrintOderGroup") ||
                (e.Group.Key == "PrintConditionGroup"))
            {
                // グループの縮小をキャンセル
                e.Cancel = true;
            }
        }

        /// <summary>
        /// ultraExplorerBar1_GroupExpandingイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ultraExplorerBar1_GroupExpanding(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
        {
            if ((e.Group.Key == "ReportSelectGroup") ||
                (e.Group.Key == "PrintOderGroup") ||
                (e.Group.Key == "PrintConditionGroup"))
            {
                // グループの展開をキャンセル
                e.Cancel = true;
            }
        }
        #endregion

        

    }
}