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
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Controller.Util; // ADD 2008/12/17

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 得意先別取引分布表UIフォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 得意先別取引分布表UIフォームクラス</br>
    /// <br>Programmer : 30452 上野 俊治</br>
    /// <br>Date       : 2008.11.21</br>
    /// <br>Update Note: 2008.12.16 30452 上野 俊治</br>
    /// <br>            ・「対象日付」を「対象日」に修正</br>
    /// <br>Update Note: 2008.12.17 30452 上野 俊治</br>
    /// <br>            ・スペースキーでのラジオボタンチェックを追加</br>
    /// <br></br>
    /// </remarks>
    public partial class PMHNB02180UA : Form,
                                IPrintConditionInpType,					// 帳票共通（条件入力タイプ）
                                IPrintConditionInpTypeSelectedSection,	// 帳票業務（条件入力）拠点選択
                                IPrintConditionInpTypePdfCareer			// 帳票業務（条件入力）PDF出力履歴管理
    {
        #region ■ コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public PMHNB02180UA()
        {
            InitializeComponent();

            // 企業コード取得
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            // 拠点用のHashtable作成
            this._selectedSectionList = new Hashtable();

            // 日付取得部品
            _dateGet = DateGetAcs.GetInstance();
            // 担当者ガイド
            _employeeAcs = new EmployeeAcs();
            // 地区ガイド
            _userGuideAcs = new UserGuideAcs();

            // 抽出条件クラス
            this._custSalesDistributionReportParam = new CustSalesDistributionReportParam();
        }
        #endregion

        #region ■ private定数
        #region Interface関連
        //--IPrintConditionInpTypePdfCareerのプロパティ用変数 -------------------------
        // クラスID
        private const string ct_ClassID = "PMHNB02180UA";
        // プログラムID
        private const string ct_PGID = "PMHNB02180U";
        //// 帳票名称
        private string _printName = "得意先別取引分布表";
        // 帳票キー	
        private string _printKey = "cdaf9c23-09cd-4b11-9c8e-6ce319278012";
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

        // 得意先ガイド用
        private UltraButton _customerGuideSender;
        // 得意先ガイド結果OKフラグ
        private bool _customerGuideOK;

        // 従業員マスタアクセスクラス
        EmployeeAcs _employeeAcs;
        // ユーザマスタアクセスクラス（地区ガイド用）
        private UserGuideAcs _userGuideAcs;


        // 得意先別取引分布表 抽出条件データクラス
        private CustSalesDistributionReportParam _custSalesDistributionReportParam;

        // 企業コード
        private string _enterpriseCode = "";

        // --- ADD 2008/12/17 -------------------------------->>>>>
        /// <summary>実績なし印刷ラジオボタンのKeyPressイベントのヘルパ</summary>
        private readonly OptionSetKeyPressEventHelper _uos_SearchDivRadioKeyPressHelper = new OptionSetKeyPressEventHelper();
        /// <summary>改頁ラジオボタンのKeyPressイベントのヘルパ</summary>
        private readonly OptionSetKeyPressEventHelper _uos_NewPageDivRadioKeyPressHelper = new OptionSetKeyPressEventHelper();

        /// <summary>
        /// 実績なし印刷ラジオボタンのKeyPressイベントのヘルパを取得します。
        /// </summary>
        /// <value>実績なし印刷ラジオボタンのKeyPressイベントのヘルパ</value>
        public OptionSetKeyPressEventHelper Uos_SearchDivRadioKeyPressHelper
        {
            get { return _uos_SearchDivRadioKeyPressHelper; }
        }

        /// <summary>
        /// 改頁ラジオボタンのKeyPressイベントのヘルパを取得します。
        /// </summary>
        /// <value>改頁ラジオボタンのKeyPressイベントのヘルパ</value>
        public OptionSetKeyPressEventHelper Uos_NewPageDivRadioKeyPressHelper
        {
            get { return _uos_NewPageDivRadioKeyPressHelper; }
        }
        // --- ADD 2008/12/17 --------------------------------<<<<<

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
        /// <br>Date		: 2008.11.21</br>
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
            printInfo.jyoken = this._custSalesDistributionReportParam;
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
        /// <br>Date		: 2008.11.21</br>
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
        /// <br>Date		: 2008.11.21</br>
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
        /// <br>Date		: 2008.11.21</br>
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
        /// <br>Date		: 2008.11.21</br>
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
        /// <br>Date		: 2008.11.21</br>
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
        /// <br>Date		: 2008.11.21</br>
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
        /// <br>Date		: 2008.11.21</br>
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
        /// <br>Date		: 2008.11.21</br>
        /// </remarks>
        private int InitializeScreen(out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            errMsg = string.Empty;

            try
            {
                // ガイドボタン設定
                this.SetIconImage(this.uButton_EmployeeCdStGuid, Size16_Index.STAR1);
                this.SetIconImage(this.uButton_EmployeeCdEdGuid, Size16_Index.STAR1);
                this.SetIconImage(this.uButton_CustomerCodeStGuid, Size16_Index.STAR1);
                this.SetIconImage(this.uButton_CustomerCodeEdGuid, Size16_Index.STAR1);
                this.SetIconImage(this.uButton_AreaCodeStGuid, Size16_Index.STAR1);
                this.SetIconImage(this.uButton_AreaCodeEdGuid, Size16_Index.STAR1);

                // 対象日
                tde_St_AddUpDate.SetDateTime(DateTime.Now);
                tde_Ed_AddUpDate.SetDateTime(DateTime.Now);

                // 実績なし印刷 する
                this.uos_SearchDiv.CheckedIndex = 0;
                
                // 改頁 拠点
                this.uos_NewPageDiv.CheckedIndex = 0;
                
                // 順位付設定 単位 全拠点
                this.tComboEditor_RankSection.SelectedIndex = 0;
                // 順位付設定 上位・下位 上位
                this.tComboEditor_RankHighLow.SelectedIndex = 0;
                // 順位付設定 最大値 99999999
                this.tNedit_RankOrderMax.SetInt(99999999);
                
                // 順位指定 純売上
                this.tComboEditor_RankStandard.SelectedIndex = 0;

                // 印刷順 コード
                this.tComboEditor_PrintOrder.SelectedIndex = 0;

                // 発行タイプ 得意先別
                this.tComboEditor_PrintType.SelectedIndex = 0;

                // 担当者
                this.tEdit_EmployeeCode_St.DataText = string.Empty;
                this.tEdit_EmployeeCode_Ed.DataText = string.Empty;
                // 地区
                this.tNedit_SalesAreaCode_St.SetInt(0);
                this.tNedit_SalesAreaCode_Ed.SetInt(0);
                // 得意先
                this.tNedit_CustomerCode_St.SetInt(0);
                this.tNedit_CustomerCode_Ed.SetInt(0);

                // 初期フォーカス
                this.tde_St_AddUpDate.Focus();
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
        /// <br>Date		: 2008.11.21</br>
        /// </remarks>
        private bool ScreenInputCheck(ref string errMessage, ref Control errComponent)
        {
            bool status = true;

            DateGetAcs.CheckDateRangeResult cdrResult;

            const string ct_NoInput = "を入力して下さい";
            const string ct_InputError = "の入力が不正です";
            const string ct_RangeError = "の範囲指定に誤りがあります";
            const string ct_RangeError1 = "は同一月内で入力して下さい";

            // 対象期間
            if (CallCheckDateRange(out cdrResult, ref tde_St_AddUpDate, ref tde_Ed_AddUpDate) == false)
            {
                switch (cdrResult)
                {
                    case DateGetAcs.CheckDateRangeResult.ErrorOfStartNoInput:
                        {
                            errMessage = string.Format("開始対象日{0}", ct_NoInput);
                            errComponent = this.tde_St_AddUpDate;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfStartInvalid:
                        {
                            errMessage = string.Format("開始対象日{0}", ct_InputError);
                            errComponent = this.tde_St_AddUpDate;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfEndNoInput:
                        {
                            errMessage = string.Format("終了対象日{0}", ct_NoInput);
                            errComponent = this.tde_Ed_AddUpDate;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfEndInvalid:
                        {
                            errMessage = string.Format("終了対象日{0}", ct_InputError);
                            errComponent = this.tde_Ed_AddUpDate;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfReverse:
                        {
                            errMessage = string.Format("対象日{0}", ct_RangeError);
                            errComponent = this.tde_St_AddUpDate;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfRangeOver:
                    case DateGetAcs.CheckDateRangeResult.ErrorOfNotOnMonth:
                        {
                            errMessage = string.Format("対象日{0}", ct_RangeError1);
                            errComponent = this.tde_St_AddUpDate;
                        }
                        break;
                }
                status = false;
            }
            // 順位付設定(最大値)
            else if (this.tNedit_RankOrderMax.GetInt() == 0)
            {
                errMessage = string.Format("順位付け設定{0}", ct_NoInput);
                errComponent = this.tNedit_RankOrderMax;
                status = false;
            }
            // 担当者
            else if (this.tEdit_EmployeeCode_St.DataText.CompareTo(this.tEdit_EmployeeCode_Ed.DataText) > 0 && !string.IsNullOrEmpty(this.tEdit_EmployeeCode_Ed.DataText))
            {
                errMessage = string.Format("担当者{0}", ct_RangeError);
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
            // 得意先
            else if ((this.tNedit_CustomerCode_St.GetInt() > this.tNedit_CustomerCode_Ed.GetInt()) && (this.tNedit_CustomerCode_Ed.GetInt() != 0))
            {
                errMessage = string.Format("得意先{0}", ct_RangeError);
                errComponent = this.tNedit_CustomerCode_St;
                status = false;
            }
            

            return status;
        }

        /// <summary>
        /// 日付チェック処理呼び出し
        /// </summary>
        /// <param name="cdrResult"></param>
        /// <param name="tde_St_AddUpYearMonth"></param>
        /// <param name="tde_Ed_AddUpYearMonth"></param>
        /// <returns></returns>
        private bool CallCheckDateRange(out DateGetAcs.CheckDateRangeResult cdrResult, ref TDateEdit tde_St_AddUpYearMonth, ref TDateEdit tde_Ed_AddUpYearMonth)
        {
            cdrResult = _dateGet.CheckDateRange(DateGetAcs.YmdType.YearMonth, 1, ref this.tde_St_AddUpDate, ref this.tde_Ed_AddUpDate, false, false, true);
            return (cdrResult == DateGetAcs.CheckDateRangeResult.OK);
        }

        /// <summary>
        /// 抽出条件設定処理(画面→抽出条件)
        /// </summary>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note		: 画面→抽出条件へ設定する。</br>
        /// <br>Programmer	: 30452 上野 俊治</br>
        /// <br>Date		: 2008.11.21</br>
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
                this._custSalesDistributionReportParam.IsOptSection = this._isOptSection;
                // 拠点コード
                this._custSalesDistributionReportParam.SectionCode = (string[])new ArrayList(this._selectedSectionList.Values).ToArray(typeof(string));
                // 企業コード
                this._custSalesDistributionReportParam.EnterpriseCode = this._enterpriseCode;

                // 開始対象日付
                this._custSalesDistributionReportParam.StSalesDate = this.tde_St_AddUpDate.GetLongDate();
                // 終了対象日付
                this._custSalesDistributionReportParam.EdSalesDate = this.tde_Ed_AddUpDate.GetLongDate();

                // 終了日を含む月の情報を取得
                DateTime yearMonth;
                int year;
                DateTime startMonthDate;
                DateTime endMonthDate;

                _dateGet.GetThisYearMonth(out yearMonth, out year, out startMonthDate, out endMonthDate);

                // 期首日
                if (startMonthDate.Day > this.tde_St_AddUpDate.GetDateTime().Day)
                {
                    // 期首日は入力の前の月
                    this._custSalesDistributionReportParam.StartDate = new DateTime(this.tde_St_AddUpDate.GetDateTime().Year,
                                                                                    this.tde_St_AddUpDate.GetDateTime().Month - 1,
                                                                                    startMonthDate.Day);
                }
                else
                {
                    // 期首日は入力した月
                    this._custSalesDistributionReportParam.StartDate = new DateTime(this.tde_St_AddUpDate.GetDateTime().Year,
                                                                                    this.tde_St_AddUpDate.GetDateTime().Month,
                                                                                    startMonthDate.Day);
                }

                // 実績区分
                this._custSalesDistributionReportParam.SearchDiv = (int)this.uos_SearchDiv.CheckedItem.DataValue;

                // 改頁
                this._custSalesDistributionReportParam.NewPageDiv = (CustSalesDistributionReportParam.NewPageDivState)this.uos_NewPageDiv.CheckedItem.DataValue;

                // 順位付設定　単位
                this._custSalesDistributionReportParam.RankSection = (CustSalesDistributionReportParam.RankSectionState)this.tComboEditor_RankSection.SelectedItem.DataValue;
                // 順位付設定　上位下位
                this._custSalesDistributionReportParam.RankHighLow = (CustSalesDistributionReportParam.RankHighLowState)this.tComboEditor_RankHighLow.SelectedItem.DataValue;
                // 順位付設定　最大値
                this._custSalesDistributionReportParam.RankOrderMax = this.tNedit_RankOrderMax.GetInt();
                // 順位指定
                this._custSalesDistributionReportParam.RankStandard = (CustSalesDistributionReportParam.RankStandardState)this.tComboEditor_RankStandard.SelectedItem.DataValue;
                // 印刷順
                this._custSalesDistributionReportParam.PrintOrder = (CustSalesDistributionReportParam.PrintOrderState)this.tComboEditor_PrintOrder.SelectedItem.DataValue;

                // 発行タイプ
                this._custSalesDistributionReportParam.PrintType = (CustSalesDistributionReportParam.PrintTypeState)this.tComboEditor_PrintType.SelectedItem.DataValue;

                // 開始得意先コード
                this._custSalesDistributionReportParam.StCustomerCode = this.tNedit_CustomerCode_St.GetInt();
                // 終了得意先コード
                this._custSalesDistributionReportParam.EdCustomerCode = this.tNedit_CustomerCode_Ed.GetInt();
                // 開始担当者コード
                this._custSalesDistributionReportParam.StSalesEmployeeCd = this.tEdit_EmployeeCode_St.DataText;
                // 終了担当者コード
                this._custSalesDistributionReportParam.EdSalesEmployeeCd = this.tEdit_EmployeeCode_Ed.DataText;
                // 開始地区コード
                this._custSalesDistributionReportParam.StSalesAreaCode = this.tNedit_SalesAreaCode_St.GetInt();
                // 終了地区コード
                this._custSalesDistributionReportParam.EdSalesAreaCode = this.tNedit_SalesAreaCode_Ed.GetInt();

            }
            catch (Exception)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }

            return status;
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
        /// <br>Date		: 2008.11.21</br>
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
        /// PMHNB02180UA_Loadイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note		: フォーム読込イベント。</br>
        /// <br>Programmer	: 30452 上野 俊治</br>
        /// <br>Date		: 2008.11.21</br>
        /// </remarks>
        private void PMHNB02180UA_Load(object sender, EventArgs e)
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

            // --- ADD 2008/12/17 -------------------------------->>>>>
            Uos_SearchDivRadioKeyPressHelper.ControlList.Add(this.uos_SearchDiv);
            Uos_SearchDivRadioKeyPressHelper.StartSpaceKeyControl();

            Uos_NewPageDivRadioKeyPressHelper.ControlList.Add(this.uos_NewPageDiv);
            Uos_NewPageDivRadioKeyPressHelper.StartSpaceKeyControl();
            // --- ADD 2008/12/17 --------------------------------<<<<<
        }

        /// <summary>
        /// GroupCollapsing Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: UltraExplorerBarGroupが縮小される前に発生する。</br>
        /// <br>Programmer	: 30452 上野 俊治</br>
        /// <br>Date		: 2008.11.21</br>
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
        /// <br>Date		: 2008.11.21</br>
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
        /// tRetKeyControl1_ChangeFocusイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tRetKeyControl1_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
        {
            // タブ、Enterキーでのガイド遷移不可
            if (e.PrevCtrl == this.tde_St_AddUpDate)
            {
                if (e.NextCtrl == uButton_CustomerCodeEdGuid && (e.Key == Keys.Tab || e.Key == Keys.Enter))
                {
                    e.NextCtrl = this.tNedit_CustomerCode_Ed;
                }
            }
            else if (e.PrevCtrl == this.tEdit_EmployeeCode_St)
            {
                if (e.NextCtrl == this.uButton_EmployeeCdStGuid && (e.Key == Keys.Tab || e.Key == Keys.Enter))
                {
                    e.NextCtrl = this.tEdit_EmployeeCode_Ed;
                }
            }
            else if (e.PrevCtrl == this.tEdit_EmployeeCode_Ed)
            {
                if (e.NextCtrl == this.uButton_EmployeeCdStGuid && (e.Key == Keys.Tab || e.Key == Keys.Enter))
                {
                    e.NextCtrl = this.tEdit_EmployeeCode_St;
                }
                else if (e.NextCtrl == this.uButton_EmployeeCdEdGuid && (e.Key == Keys.Tab || e.Key == Keys.Enter))
                {
                    e.NextCtrl = this.tNedit_SalesAreaCode_St;
                }
            }
            else if (e.PrevCtrl == this.tNedit_SalesAreaCode_St)
            {
                if (e.NextCtrl == this.uButton_EmployeeCdEdGuid && (e.Key == Keys.Tab || e.Key == Keys.Enter))
                {
                    e.NextCtrl = this.tEdit_EmployeeCode_Ed;
                }
                else if (e.NextCtrl == this.uButton_AreaCodeStGuid && (e.Key == Keys.Tab || e.Key == Keys.Enter))
                {
                    e.NextCtrl = this.tNedit_SalesAreaCode_Ed;
                }
            }
            else if (e.PrevCtrl == this.tNedit_SalesAreaCode_Ed)
            {
                if (e.NextCtrl == this.uButton_AreaCodeStGuid && (e.Key == Keys.Tab || e.Key == Keys.Enter))
                {
                    e.NextCtrl = this.tNedit_SalesAreaCode_St;
                }
                else if (e.NextCtrl == this.uButton_AreaCodeEdGuid && (e.Key == Keys.Tab || e.Key == Keys.Enter))
                {
                    e.NextCtrl = this.tNedit_CustomerCode_St;
                }
            }
            else if (e.PrevCtrl == this.tNedit_CustomerCode_St)
            {
                if (e.NextCtrl == this.uButton_AreaCodeEdGuid && (e.Key == Keys.Tab || e.Key == Keys.Enter))
                {
                    e.NextCtrl = this.tNedit_SalesAreaCode_Ed;
                }
                else if (e.NextCtrl == this.uButton_CustomerCodeStGuid && (e.Key == Keys.Tab || e.Key == Keys.Enter))
                {
                    e.NextCtrl = this.tNedit_CustomerCode_Ed;
                }
            }
            else if (e.PrevCtrl == this.tNedit_CustomerCode_Ed)
            {
                if (e.NextCtrl == this.uButton_CustomerCodeStGuid && (e.Key == Keys.Tab || e.Key == Keys.Enter))
                {
                    e.NextCtrl = this.tNedit_CustomerCode_St;
                }
                else if (e.NextCtrl == this.uButton_CustomerCodeEdGuid && (e.Key == Keys.Tab || e.Key == Keys.Enter))
                {
                    e.NextCtrl = this.tde_St_AddUpDate;
                }
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
                    this.tde_St_AddUpDate.Focus();
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
                    this.tNedit_CustomerCode_St.Focus();
                }
            }
        }
        #endregion
    }
}