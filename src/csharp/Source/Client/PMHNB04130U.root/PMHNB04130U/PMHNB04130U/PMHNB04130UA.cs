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

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 得意先別過年度統計表UIフォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 得意先別過年度統計表UIフォームクラス</br>
    /// <br>Programmer : 30452 上野 俊治</br>
    /// <br>Date       : 2008.10.31</br>
    /// <br></br>
    /// </remarks>
    public partial class PMHNB04130UA : Form,
                                IPrintConditionInpType,					// 帳票共通（条件入力タイプ）
                                IPrintConditionInpTypeSelectedSection,	// 帳票業務（条件入力）拠点選択
                                IPrintConditionInpTypePdfCareer			// 帳票業務（条件入力）PDF出力履歴管理
    {
        #region ■ コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public PMHNB04130UA()
        {
            InitializeComponent();

            // 企業コード取得
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            // 拠点用のHashtable作成
            this._selectedSectionList = new Hashtable();

            // 日付取得部品
            _dateGet = DateGetAcs.GetInstance();

            // 抽出条件クラス
            this._custFinancialListCndtn = new CustFinancialListCndtn();
        }
        #endregion

        #region ■ private定数
        #region Interface関連
        //--IPrintConditionInpTypePdfCareerのプロパティ用変数 -------------------------
		// クラスID
        private const string ct_ClassID         = "PMHNB04130UA";
		// プログラムID
        private const string ct_PGID            = "PMHNB04130U";
		//// 帳票名称
		private string _printName				= "過年度統計表";    
        // 帳票キー	
        private string _printKey                = "9b7209b2-71b8-483a-bb1e-9833b38d1b1f";
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

        // 得意先別過年度統計表 抽出条件データクラス
        private CustFinancialListCndtn _custFinancialListCndtn;

        // 企業コード
        private string _enterpriseCode = "";

        // 初期化中フラグ (イベント制御用)
        private bool _initializeFinish = true;

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
        /// <br>Date		: 2008.10.31</br>
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
            printInfo.jyoken = this._custFinancialListCndtn;
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
        /// <br>Date		: 2008.10.31</br>
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
        /// <br>Date		: 2008.10.31</br>
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
        /// <br>Date		: 2008.10.31</br>
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
        /// <br>Date		: 2008.10.31</br>
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
        /// <br>Date		: 2008.10.31</br>
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
        /// <br>Date		: 2008.10.31</br>
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
        /// <br>Date		: 2008.10.31</br>
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
        /// <br>Date		: 2008.10.31</br>
        /// </remarks>
        private int InitializeScreen(out string errMsg)
        {
            _initializeFinish = false;

            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            errMsg = string.Empty;

            try
            {
                // ガイドボタン設定
                this.SetIconImage(this.uButton_CustomerCodeStGuid, Size16_Index.STAR1);
                this.SetIconImage(this.uButton_CustomerCodeEdGuid, Size16_Index.STAR1);

                // 対象期間取得
                DateTime stDate;
                DateTime edDate;

                // 会計年度取得
                _dateGet.GetThisYearMonth(out edDate);
                // 初期値は7年前(当年含めて8年間)
                stDate = edDate.AddYears(-7);

                tde_St_AddUpYearMonth.SetDateTime(stDate);
                tde_Ed_AddUpYearMonth.SetDateTime(edDate);

                // 金額単位 円
                this.uos_MoneyUnitDiv.Value = (int)CustFinancialListCndtn.MoneyUnitState.One;

                // 発行タイプ
                this.tComboEditor_PrintType.SelectedIndex = 0;
                // 印刷タイプ
                this.tComboEditor_PrintMoneyType.SelectedIndex = 0;

                // 改頁
                Infragistics.Win.ValueList valueList1 = this.GetNewPageDivValueList();

                this.uos_NewPageDiv.ResetValueList();

                for (int i = 0; i < valueList1.ValueListItems.Count; i++)
                {
                    Infragistics.Win.ValueListItem vlltem = new Infragistics.Win.ValueListItem();
                    vlltem.Tag = valueList1.ValueListItems[i].Tag;
                    vlltem.DataValue = valueList1.ValueListItems[i].DataValue;
                    vlltem.DisplayText = valueList1.ValueListItems[i].DisplayText;
                    this.uos_NewPageDiv.Items.Add(vlltem);
                }

                // 初期値は"しない"
                this.uos_NewPageDiv.Value = (int)CustFinancialListCndtn.NewPageDivState.None;

                // 得意先
                this.tNedit_CustomerCode_St.SetInt(0);
                this.tNedit_CustomerCode_Ed.SetInt(0);

                this.tde_St_AddUpYearMonth.Focus();
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
            finally
            {
                _initializeFinish = true;
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
        /// <br>Date		: 2008.10.31</br>
        /// </remarks>
        private bool ScreenInputCheck(ref string errMessage, ref Control errComponent)
        {
            bool status = true;

            DateGetAcs.CheckDateRangeResult cdrResult;

            const string ct_NoInput = "を入力して下さい";
            const string ct_InputError = "の入力が不正です";
            const string ct_RangeError = "の範囲指定に誤りがあります";
            const string ct_RangeError1 = "の範囲指定に誤りがあります(８年以内で設定して下さい)";

            // 対象期間
            if (CallCheckDateRange(out cdrResult, ref tde_St_AddUpYearMonth, ref tde_Ed_AddUpYearMonth) == false)
            {
                switch (cdrResult)
                {
                    case DateGetAcs.CheckDateRangeResult.ErrorOfStartNoInput:
                        {
                            errMessage = string.Format("開始対象期間{0}", ct_NoInput);
                            errComponent = this.tde_St_AddUpYearMonth;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfStartInvalid:
                        {
                            errMessage = string.Format("開始対象期間{0}", ct_InputError);
                            errComponent = this.tde_St_AddUpYearMonth;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfEndNoInput:
                        {
                            errMessage = string.Format("終了対象期間{0}", ct_NoInput);
                            errComponent = this.tde_Ed_AddUpYearMonth;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfEndInvalid:
                        {
                            errMessage = string.Format("終了対象期間{0}", ct_InputError);
                            errComponent = this.tde_Ed_AddUpYearMonth;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfReverse:
                        {
                            errMessage = string.Format("対象期間{0}", ct_RangeError);
                            errComponent = this.tde_St_AddUpYearMonth;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfRangeOver:
                        {
                            errMessage = string.Format("対象期間{0}", ct_RangeError1);
                            errComponent = this.tde_St_AddUpYearMonth;
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
            cdrResult = _dateGet.CheckDateRange(DateGetAcs.YmdType.Year, 8, ref tde_St_AddUpYearMonth, ref tde_Ed_AddUpYearMonth, false, false);
            return (cdrResult == DateGetAcs.CheckDateRangeResult.OK);
        }

        /// <summary>
        /// 抽出条件設定処理(画面→抽出条件)
        /// </summary>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note		: 画面→抽出条件へ設定する。</br>
        /// <br>Programmer	: 30452 上野 俊治</br>
        /// <br>Date		: 2008.10.31</br>
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
                this._custFinancialListCndtn.IsOptSection = this._isOptSection;
                // 拠点コード
                this._custFinancialListCndtn.AddUpSecCodes = (string[])new ArrayList(this._selectedSectionList.Values).ToArray(typeof(string));
                // 企業コード
                this._custFinancialListCndtn.EnterpriseCode = this._enterpriseCode;

                // 対象年月
                Int32 iSMonth = 0;
                Int32 iEMonth = 0;

                // DateTimeに変換
                iSMonth = (this.tde_St_AddUpYearMonth.GetLongDate() / 10000) * 10000 + 1; // 月
                iEMonth = (this.tde_Ed_AddUpYearMonth.GetLongDate() / 10000) * 10000 + 1;
                iSMonth = (this.tde_St_AddUpYearMonth.GetLongDate() / 100) * 100 + 1; // 日
                iEMonth = (this.tde_Ed_AddUpYearMonth.GetLongDate() / 100) * 100 + 1;
                this.tde_St_AddUpYearMonth.SetLongDate(iSMonth);
                this.tde_Ed_AddUpYearMonth.SetLongDate(iEMonth);

                // 開始年度
                this._custFinancialListCndtn.St_Year = this.tde_St_AddUpYearMonth.GetDateTime();
                // 終了年度
                this._custFinancialListCndtn.Ed_Year = this.tde_Ed_AddUpYearMonth.GetDateTime();

                // 計上年月取得
                DateTime yearMonth;
                Int32 intMonthDay;
                this._dateGet.GetThisYearMonth(out yearMonth);

                // Datetime、LongeDate変換用TDateEdit
                TDateEdit tmpTDateEdit = new TDateEdit();
                tmpTDateEdit.SetDateTime(yearMonth);
                intMonthDay = tmpTDateEdit.GetLongDate() % 10000; // 期首月日を取得

                // 終了対象期間の年度 + 期首月を取得
                int edAddUpYearMonth = ((this.tde_Ed_AddUpYearMonth.GetLongDate() / 10000) * 10000) + intMonthDay;
                tmpTDateEdit.SetLongDate(edAddUpYearMonth);

                // 開始計上年月
                this._custFinancialListCndtn.St_AddUpYearMonth = tmpTDateEdit.GetDateTime();
                // 終了計上年月
                this._custFinancialListCndtn.Ed_AddUpYearMonth = tmpTDateEdit.GetDateTime().AddMonths(12);

                // 金額単位
                this._custFinancialListCndtn.MoneyUnit = (CustFinancialListCndtn.MoneyUnitState) this.uos_MoneyUnitDiv.CheckedItem.DataValue;
                // 改頁
                this._custFinancialListCndtn.NewPageDiv = (CustFinancialListCndtn.NewPageDivState) this.uos_NewPageDiv.CheckedItem.DataValue;
                // 発行タイプ
                this._custFinancialListCndtn.PrintDiv = (CustFinancialListCndtn.PrintDivState)this.tComboEditor_PrintType.SelectedItem.DataValue;
                // 印刷タイプ
                this._custFinancialListCndtn.PrintMoneyDiv = (CustFinancialListCndtn.PrintMoneyDivState)this.tComboEditor_PrintMoneyType.SelectedItem.DataValue;

                // 開始得意先コード
                this._custFinancialListCndtn.St_CustomerCode = this.tNedit_CustomerCode_St.GetInt();
                // 終了得意先コード
                this._custFinancialListCndtn.Ed_CustomerCode = this.tNedit_CustomerCode_Ed.GetInt();

            }
            catch (Exception)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }

            return status;
        }

        #region ◎ 改頁ValueList取得
        /// <summary>
        /// 改頁ValueList取得
        /// </summary>
        /// <returns></returns>
        private Infragistics.Win.ValueList GetNewPageDivValueList()
        {
            Infragistics.Win.ValueList valueList = new Infragistics.Win.ValueList();
            Infragistics.Win.ValueListItem valueListItem = new Infragistics.Win.ValueListItem();

            if ((CustFinancialListCndtn.PrintDivState)this.tComboEditor_PrintType.SelectedItem.DataValue
                == CustFinancialListCndtn.PrintDivState.CustomerSection)
            {
                valueListItem = new Infragistics.Win.ValueListItem();
                        valueListItem.Tag = 0;
                        valueListItem.DataValue = 2;
                        valueListItem.DisplayText = "得意先";
                        valueList.ValueListItems.Add(valueListItem);

                        valueListItem = new Infragistics.Win.ValueListItem();
                        valueListItem.Tag = 1;
                        valueListItem.DataValue = 0;
                        valueListItem.DisplayText = "しない";
                        valueList.ValueListItems.Add(valueListItem);
            }
            else
            {
                 valueListItem = new Infragistics.Win.ValueListItem();
                        valueListItem.Tag = 0;
                        valueListItem.DataValue = 1;
                        valueListItem.DisplayText = "拠点";
                        valueList.ValueListItems.Add(valueListItem);

                        valueListItem = new Infragistics.Win.ValueListItem();
                        valueListItem.Tag = 1;
                        valueListItem.DataValue = 0;
                        valueListItem.DisplayText = "しない";
                        valueList.ValueListItems.Add(valueListItem);
            }
            
            return valueList;
        }
        #endregion

        /// <summary>
        /// エラーメッセージ表示処理
        /// </summary>
        /// <param name="iLevel">エラーレベル</param>
        /// <param name="message">表示メッセージ</param>
        /// <param name="status">ステータス</param>
        /// <remarks>
        /// <br>Note       : エラーメッセージの表示を行います。</br>
        /// <br>Programmer	: 30452 上野 俊治</br>
        /// <br>Date		: 2008.10.31</br>
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
        /// PMHNB04130UA_Loadイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note		: フォーム読込イベント。</br>
        /// <br>Programmer	: 30452 上野 俊治</br>
        /// <br>Date		: 2008.10.31</br>
        /// </remarks>
        private void PMHNB04130UA_Load(object sender, EventArgs e)
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
        }

        /// <summary>
        /// リターンキー押下イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tRetKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
        }

        /// <summary>
        /// GroupCollapsing Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: UltraExplorerBarGroupが縮小される前に発生する。</br>
        /// <br>Programmer	: 30452 上野 俊治</br>
        /// <br>Date		: 2008.10.31</br>
        /// </remarks>
        private void ueb_MainExplorerBar_GroupCollapsing(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
        {
            if ((e.Group.Key == "ReportSelectGroup") ||
                (e.Group.Key == "ReportPrintDivGroup") ||
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
        /// <br>Date		: 2008.10.31</br>
        /// </remarks>
        private void ueb_MainExplorerBar_GroupExpanding(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
        {
            if ((e.Group.Key == "ReportSelectGroup") ||
                (e.Group.Key == "ReportPrintDivGroup") ||
                (e.Group.Key == "PrintConditionGroup"))
            {
                // グループの展開をキャンセル
                e.Cancel = true;
            }

        }

        /// <summary>
        /// 発行タイプ選択イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tComboEditor_PrintType_SelectionChanged(object sender, EventArgs e)
        {
            if (_initializeFinish)
            {
                // 選択項目保存
                CustFinancialListCndtn.NewPageDivState dataValue
                    = (CustFinancialListCndtn.NewPageDivState)this.uos_NewPageDiv.CheckedItem.DataValue;

                // 改頁
                Infragistics.Win.ValueList valueList1 = this.GetNewPageDivValueList();

                this.uos_NewPageDiv.ResetValueList();

                for (int i = 0; i < valueList1.ValueListItems.Count; i++)
                {
                    Infragistics.Win.ValueListItem vlltem = new Infragistics.Win.ValueListItem();
                    vlltem.Tag = valueList1.ValueListItems[i].Tag;
                    vlltem.DataValue = valueList1.ValueListItems[i].DataValue;
                    vlltem.DisplayText = valueList1.ValueListItems[i].DisplayText;
                    this.uos_NewPageDiv.Items.Add(vlltem);
                }

                if (dataValue == CustFinancialListCndtn.NewPageDivState.None)
                {
                    // しない
                    this.uos_NewPageDiv.Value = (int)CustFinancialListCndtn.NewPageDivState.None;
                }
                else
                {
                    if ((CustFinancialListCndtn.PrintDivState)this.tComboEditor_PrintType.SelectedItem.DataValue
                        == CustFinancialListCndtn.PrintDivState.CustomerSection)
                    {
                        // 得意先
                        this.uos_NewPageDiv.Value = (int)CustFinancialListCndtn.NewPageDivState.Customer;
                    }
                    else
                    {
                        // 拠点
                        this.uos_NewPageDiv.Value = (int)CustFinancialListCndtn.NewPageDivState.Section;
                    }
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
                    this.tde_St_AddUpYearMonth.Focus();
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
        #endregion
    }
}