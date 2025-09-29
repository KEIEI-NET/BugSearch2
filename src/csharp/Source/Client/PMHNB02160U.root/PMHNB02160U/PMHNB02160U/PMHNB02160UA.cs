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
using Broadleaf.Application.Controller.Util;    // ADD 2008/03/31 不具合対応[12911]：スペースキーでの項目選択機能を実装
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Resources;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 売上内容分析表UIフォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 売上内容分析表UIフォームクラス</br>
    /// <br>Programmer : 30452 上野 俊治</br>
    /// <br>Date       : 2008.11.11</br>
    /// <br>Update Note: 2008.11.21 30452 上野 俊治</br>
    /// <br>            ・対象日付チェック修正</br>
    /// <br></br>
    /// </remarks>
    public partial class PMHNB02160UA : Form,
                                IPrintConditionInpType,					// 帳票共通（条件入力タイプ）
                                IPrintConditionInpTypeSelectedSection,	// 帳票業務（条件入力）拠点選択
                                IPrintConditionInpTypePdfCareer			// 帳票業務（条件入力）PDF出力履歴管理
    {
        #region ■ コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public PMHNB02160UA()
        {
            InitializeComponent();

            // 企業コード取得
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            // 拠点用のHashtable作成
            this._selectedSectionList = new Hashtable();

            // 日付取得部品
            this._dateGet = DateGetAcs.GetInstance();

            // ガイドアクセスクラス初期化
            this._employeeAcs = new EmployeeAcs();
            this._userGuideAcs = new UserGuideAcs();

            // 抽出条件クラス
            this._salesHistAnalyzeCndtn = new SalesHistAnalyzeCndtn();
        }
        #endregion

        #region ■ private定数
        #region Interface関連
        //--IPrintConditionInpTypePdfCareerのプロパティ用変数 -------------------------
        // クラスID
        private const string ct_ClassID = "PMHNB02160UA";
        // プログラムID
        private const string ct_PGID = "PMHNB02160U";
        //// 帳票名称
        private string _printName = "売上内容分析表";
        // 帳票キー	
        private string _printKey = "95eb6a52-7c60-44e7-bea3-b58a452a8d31";
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
        // 従業員マスタアクセスクラス
        EmployeeAcs _employeeAcs;
        // ユーザマスタアクセスクラス（地区ガイド用）
        private UserGuideAcs _userGuideAcs;
        

        // 得意先ガイド用
        private UltraButton _customerGuideSender;
        // 得意先ガイド結果OKフラグ
        private bool _customerGuideOK;

        // 売上内容分析表 抽出条件データクラス
        private SalesHistAnalyzeCndtn _salesHistAnalyzeCndtn;

        // 企業コード
        private string _enterpriseCode = "";

        // ADD 2009/03/31 不具合対応[12911]：スペースキーでの項目選択機能を実装 ---------->>>>>
        /// <summary>累計印刷ラジオボタンのKeyPressイベントのヘルパ</summary>
        private readonly OptionSetKeyPressEventHelper _monthReportDivRadioKeyPressHelper = new OptionSetKeyPressEventHelper();
        /// <summary>
        /// 累計印刷ラジオボタンのKeyPressイベントのヘルパを取得します。
        /// </summary>
        /// <value>累計印刷ラジオボタンのKeyPressイベントのヘルパ</value>
        public OptionSetKeyPressEventHelper MonthReportDivRadioKeyPressHelper
        {
            get { return _monthReportDivRadioKeyPressHelper; }
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
        // ADD 2009/03/31 不具合対応[12911]：スペースキーでの項目選択機能を実装 ----------<<<<<

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
        /// <br>Date		: 2008.11.11</br>
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
            printInfo.jyoken = this._salesHistAnalyzeCndtn;
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
        /// <br>Date		: 2008.11.11</br>
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
        /// <br>Date		: 2008.11.11</br>
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
        /// <br>Date		: 2008.11.11</br>
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
        /// <br>Date		: 2008.11.11</br>
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
        /// <br>Date		: 2008.11.11</br>
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
        /// <br>Date		: 2008.11.11</br>
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
        /// <br>Date		: 2008.11.11</br>
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
        /// <br>Date		: 2008.11.11</br>
        /// </remarks>
        private int InitializeScreen(out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            errMsg = string.Empty;

            try
            {
                // ガイドボタン設定
                this.SetIconImage(this.uButton_CustomerCodeStGuid, Size16_Index.STAR1);
                this.SetIconImage(this.uButton_CustomerCodeEdGuid, Size16_Index.STAR1);
                this.SetIconImage(this.uButton_EmployeeCdStGuid, Size16_Index.STAR1);
                this.SetIconImage(this.uButton_EmployeeCdEdGuid, Size16_Index.STAR1);
                this.SetIconImage(this.uButton_AreaCodeStGuid, Size16_Index.STAR1);
                this.SetIconImage(this.uButton_AreaCodeEdGuid, Size16_Index.STAR1);

                // 処理年月を取得
                DateTime yearMonth = DateTime.Now;

                this.tde_Date_St.SetDateTime(yearMonth);
                this.tde_Date_Ed.SetDateTime(yearMonth);

                // 累計印刷
                this.uos_MonthReportDiv.Value = 1;
                this.uos_MonthReportDiv.FocusedIndex = 1;   // ADD 2008/03/31 不具合対応[12911]：スペースキーでの項目選択機能を実装

                // 改頁
                this.uos_NewPageDiv.Value = 0;

                // 発行タイプ
                this.tComboEditor_PrintType.SelectedIndex = 0;

                // 得意先
                this.tNedit_CustomerCode_St.SetInt(0);
                this.tNedit_CustomerCode_Ed.SetInt(0);
                // 担当者
                this.tEdit_EmployeeCode_St.DataText = string.Empty;
                this.tEdit_EmployeeCode_Ed.DataText = string.Empty;
                // 地区
                this.tNedit_SalesAreaCode_St.SetInt(0);
                this.tNedit_SalesAreaCode_Ed.SetInt(0);

                // 初期フォーカス設定
                this.tde_Date_St.Focus();
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
        /// <br>Date		: 2008.11.11</br>
        /// </remarks>
        private bool ScreenInputCheck(ref string errMessage, ref Control errComponent)
        {
            bool status = true;

            DateGetAcs.CheckDateRangeResult cdrResult;

            const string ct_NoInput = "を入力して下さい";
            const string ct_InputError = "の入力が不正です";
            const string ct_RangeError = "の範囲指定に誤りがあります";

            // 対象日付
            if (!CallCheckDateRange(out cdrResult, ref this.tde_Date_St, ref this.tde_Date_Ed))
            {
                switch (cdrResult)
                {
                    case DateGetAcs.CheckDateRangeResult.ErrorOfStartNoInput:
                        {
                            errMessage = string.Format("開始対象日付{0}", ct_NoInput);
                            errComponent = this.tde_Date_St;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfStartInvalid:
                        {
                            errMessage = string.Format("開始対象日付{0}", ct_InputError);
                            errComponent = this.tde_Date_St;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfEndNoInput:
                        {
                            errMessage = string.Format("終了対象日付{0}", ct_NoInput);
                            errComponent = this.tde_Date_Ed;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfEndInvalid:
                        {
                            errMessage = string.Format("終了対象日付{0}", ct_InputError);
                            errComponent = this.tde_Date_Ed;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfReverse:
                    case DateGetAcs.CheckDateRangeResult.ErrorOfRangeOver:
                        {
                            errMessage = string.Format("対象日付{0}", ct_RangeError);
                            errComponent = this.tde_Date_St;
                        }
                        break;
                }

                status = false;
            }
            // 得意先
            else if ((this.tNedit_CustomerCode_St.GetInt() > this.tNedit_CustomerCode_Ed.GetInt()) && (this.tNedit_CustomerCode_Ed.GetInt() != 0))
            {
                errMessage = string.Format("得意先{0}", ct_RangeError);
                errComponent = this.tNedit_CustomerCode_St;
                status = false;
            }
            // 担当者
            else if ((this.tEdit_EmployeeCode_St.DataText.TrimEnd() != string.Empty ) &&
                ( this.tEdit_EmployeeCode_Ed.DataText.TrimEnd() != string.Empty ) &&
                ( this.tEdit_EmployeeCode_St.DataText.TrimEnd().CompareTo( this.tEdit_EmployeeCode_Ed.DataText.TrimEnd() ) > 0 ))
            {
                errMessage = string.Format( "担当者{0}", ct_RangeError );
                errComponent = this.tEdit_EmployeeCode_St;
                status = false;
            }
            // 地区
            else if ((this.tNedit_SalesAreaCode_St.GetInt() > this.tNedit_SalesAreaCode_Ed.GetInt()) && (this.tNedit_SalesAreaCode_Ed.GetInt() != 0))
            {
                errMessage = string.Format("地区{0}", ct_RangeError);
                errComponent = this.tNedit_SalesAreaCode_St;
                status = false;
            }

            return status;
        }

        /// <summary>
        /// 日付チェック処理呼び出し
        /// </summary>
        /// <param name="cdrResult"></param>
        /// <param name="stDate"></param>
        /// <param name="edDate"></param>
        /// <returns></returns>
        private bool CallCheckDateRange(out DateGetAcs.CheckDateRangeResult cdrResult, ref TDateEdit stDate, ref TDateEdit edDate)
        {
            // --- ADD 2008/11/21 -------------------------------->>>>>
            // 開始日付の変換前に入力チェック
            DateGetAcs.CheckDateResult cdr = _dateGet.CheckDate(ref stDate);

            if (cdr == DateGetAcs.CheckDateResult.ErrorOfNoInput)
            {
                // 入力なし
                cdrResult = DateGetAcs.CheckDateRangeResult.ErrorOfStartNoInput;
                return false;
            }
            else if (cdr == DateGetAcs.CheckDateResult.ErrorOfInvalid)
            {
                // 入力不正
                cdrResult = DateGetAcs.CheckDateRangeResult.ErrorOfStartInvalid;
                return false;
            }
            // --- ADD 2008/11/21 --------------------------------<<<<<

            // 期間チェックは累計の開始日と終了日で行う
            TDateEdit monthStartDate = new TDateEdit();
            monthStartDate.SetDateTime(this.GetMonthStartDate(stDate.GetDateTime()));

            cdrResult = _dateGet.CheckDateRange(DateGetAcs.YmdType.YearMonth, 3, ref monthStartDate, ref tde_Date_Ed, false);
            if (cdrResult != DateGetAcs.CheckDateRangeResult.OK)
            {
                return false;
            }

            // 開始日と終了日(画面入力)の範囲チェック (累計開始日だと逆転する可能性がある)
            if (stDate.GetDateTime().CompareTo(edDate.GetDateTime()) > 0)
            {
                cdrResult = DateGetAcs.CheckDateRangeResult.ErrorOfReverse;
                return false;
            }

            return (cdrResult == DateGetAcs.CheckDateRangeResult.OK);
        }

        /// <summary>
        /// 抽出条件設定処理(画面→抽出条件)
        /// </summary>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note		: 画面→抽出条件へ設定する。</br>
        /// <br>Programmer	: 30452 上野 俊治</br>
        /// <br>Date		: 2008.11.11</br>
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
                this._salesHistAnalyzeCndtn.IsOptSection = this._isOptSection;
                // 拠点コード
                this._salesHistAnalyzeCndtn.SectionCode = (string[])new ArrayList(this._selectedSectionList.Values).ToArray(typeof(string));
                // 企業コード
                this._salesHistAnalyzeCndtn.EnterpriseCode = this._enterpriseCode;

                // 対象年月
                // 開始対象日付
                this._salesHistAnalyzeCndtn.St_SalesDate = this.tde_Date_St.GetLongDate();
                // 終了対象日付
                this._salesHistAnalyzeCndtn.Ed_SalesDate = this.tde_Date_Ed.GetLongDate();

                // 自社締め日を考慮した開始日を取得（DateTime → int）
                TDateEdit tmpTDE = new TDateEdit();
                tmpTDE.SetDateTime(this.GetMonthStartDate(this.tde_Date_St.GetDateTime()));

                // 計上期年月(開始)
                this._salesHistAnalyzeCndtn.St_MonthReportDate = tmpTDE.GetLongDate();
                // 計上期年月(終了)
                this._salesHistAnalyzeCndtn.Ed_MonthReportDate = this.tde_Date_Ed.GetLongDate();
                
                // 累計印刷
                this._salesHistAnalyzeCndtn.MonthReportDiv = (SalesHistAnalyzeCndtn.MonthReportDivState)this.uos_MonthReportDiv.CheckedItem.DataValue;

                // 改頁
                this._salesHistAnalyzeCndtn.NewPageDiv = (SalesHistAnalyzeCndtn.NewPageDivState)this.uos_NewPageDiv.CheckedItem.DataValue;
                
                // 発行タイプ
                this._salesHistAnalyzeCndtn.PrintDiv = (SalesHistAnalyzeCndtn.PrintDivState)this.tComboEditor_PrintType.SelectedItem.DataValue;

                // 開始得意先コード
                this._salesHistAnalyzeCndtn.St_CustomerCode = this.tNedit_CustomerCode_St.GetInt();
                // 終了得意先コード
                this._salesHistAnalyzeCndtn.Ed_CustomerCode = this.tNedit_CustomerCode_Ed.GetInt();

                // 開始担当者コード
                this._salesHistAnalyzeCndtn.St_SalesEmployeeCd = this.tEdit_EmployeeCode_St.DataText;
                // 終了担当者コード
                this._salesHistAnalyzeCndtn.Ed_SalesEmployeeCd = this.tEdit_EmployeeCode_Ed.DataText;

                // 開始地区コード
                this._salesHistAnalyzeCndtn.St_SalesAreaCode = this.tNedit_SalesAreaCode_St.GetInt();
                // 終了地区コード
                this._salesHistAnalyzeCndtn.Ed_SalesAreaCode = this.tNedit_SalesAreaCode_Ed.GetInt();

            }
            catch (Exception)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }

            return status;
        }

        /// <summary>
        /// 自社締め日に対応した累計開始日を取得する。
        /// </summary>
        /// <returns></returns>
        private DateTime GetMonthStartDate(DateTime startDate)
        {
            int targetYear;
            DateTime yearMonth;
            DateTime startMonthDate;
            DateTime endMonthDate;
            this._dateGet.GetYearMonth(startDate, out yearMonth, out targetYear, out startMonthDate, out endMonthDate);

            return startMonthDate;
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
        /// <br>Date		: 2008.11.11</br>
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
        /// PMHNB02160UA_Loadイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note		: フォーム読込イベント。</br>
        /// <br>Programmer	: 30452 上野 俊治</br>
        /// <br>Date		: 2008.11.11</br>
        /// </remarks>
        private void PMHNB02160UA_Load(object sender, EventArgs e)
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

            // ADD 2009/03/31 不具合対応[12911]：スペースキーでの項目選択機能を実装 ---------->>>>>
            MonthReportDivRadioKeyPressHelper.ControlList.Add(this.uos_MonthReportDiv);
            MonthReportDivRadioKeyPressHelper.StartSpaceKeyControl();

            NewPageDivRadioKeyPressHelper.ControlList.Add(this.uos_NewPageDiv);
            NewPageDivRadioKeyPressHelper.StartSpaceKeyControl();
            // ADD 2009/03/31 不具合対応[12911]：スペースキーでの項目選択機能を実装 ----------<<<<<
        }

        /// <summary>
        /// GroupCollapsing Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: UltraExplorerBarGroupが縮小される前に発生する。</br>
        /// <br>Programmer	: 30452 上野 俊治</br>
        /// <br>Date		: 2008.11.11</br>
        /// </remarks>
        private void ueb_MainExplorerBar_GroupCollapsing(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
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
        /// GroupExpanding Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: UltraExplorerBarGroupが展開される前に発生する。</br>
        /// <br>Programmer	: 30452 上野 俊治</br>
        /// <br>Date		: 2008.11.11</br>
        /// </remarks>
        private void ueb_MainExplorerBar_GroupExpanding(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
        {
            if ((e.Group.Key == "ReportSelectGroup") ||
                (e.Group.Key == "PrintOderGroup") ||
                (e.Group.Key == "PrintConditionGroup"))
            {
                // グループの展開をキャンセル
                e.Cancel = true;
            }

        }

        /// <summary>
        /// 得意先ガイドクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_CustomerCodeGuid_Click(object sender, EventArgs e)
        {
            _customerGuideOK = false;

            // 押下されたボタンを退避
            if (sender is UltraButton)
            {
                _customerGuideSender = (UltraButton)sender;
            }

            PMKHN04005UA customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_NORMAL, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY);
            customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.customerSearchForm_CustomerSelect);
            customerSearchForm.ShowDialog(this);

            if (_customerGuideOK)
            {
                if (sender == this.uButton_CustomerCodeStGuid)
                {
                    this.tNedit_CustomerCode_Ed.Focus();
                }
                else
                {
                    this.tEdit_EmployeeCode_St.Focus();
                }
            }

        }

        /// <summary>
        /// 得意先ガイド選択イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="customerSearchRet"></param>
        void customerSearchForm_CustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        {
            if (customerSearchRet == null) return;

            CustomerInfo customerInfo;
            CustomerInfoAcs customerInfoAcs = new CustomerInfoAcs();

            int status = customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, customerSearchRet.EnterpriseCode, customerSearchRet.CustomerCode, true, out customerInfo);
            if (status != 0) return;

            if (_customerGuideSender == this.uButton_CustomerCodeStGuid)
            {
                this.tNedit_CustomerCode_St.SetInt(customerInfo.CustomerCode);
            }
            else
            {
                this.tNedit_CustomerCode_Ed.SetInt(customerInfo.CustomerCode);
            }

            _customerGuideOK = true;
        }

        /// <summary>
        /// 担当者ガイド選択イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_EmployeeCdGuid_Click(object sender, EventArgs e)
        {
            // ガイド起動
            Employee employee = new Employee();
            int status = _employeeAcs.ExecuteGuid(this._enterpriseCode, true, out employee);

            if (status == 0)
            {
                if (sender == this.uButton_EmployeeCdStGuid)
                {
                    this.tEdit_EmployeeCode_St.Text = employee.EmployeeCode.TrimEnd();
                    this.tEdit_EmployeeCode_Ed.Focus();
                }
                else
                {
                    this.tEdit_EmployeeCode_Ed.Text = employee.EmployeeCode.TrimEnd();
                    this.tNedit_SalesAreaCode_St.Focus();
                }
            }
        }

        /// <summary>
        /// 地区ガイド選択イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_AreaCodeGuid_Click(object sender, EventArgs e)
        {
            // ガイド起動
            UserGdBd userGdBd = new UserGdBd();
            UserGdHd userGdHd = new UserGdHd();

            int status = this._userGuideAcs.ExecuteGuid(this._enterpriseCode, out userGdHd, out userGdBd, 21);

            if (status == 0)
            {
                if (sender == this.uButton_AreaCodeStGuid)
                {
                    this.tNedit_SalesAreaCode_St.SetInt(userGdBd.GuideCode);
                    this.tNedit_SalesAreaCode_Ed.Focus();
                }
                else
                {
                    this.tNedit_SalesAreaCode_Ed.SetInt(userGdBd.GuideCode);
                    this.tde_Date_St.Focus();
                }
            }
        }

        /// <summary>
        /// リターンキー押下イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tRetKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {

        }
        #endregion
    }
}