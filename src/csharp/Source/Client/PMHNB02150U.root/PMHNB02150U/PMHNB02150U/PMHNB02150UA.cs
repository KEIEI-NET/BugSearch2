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
using Broadleaf.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Controller.Util;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 出荷商品優良対応表２UIフォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 出荷商品優良対応表２UIフォームクラス</br>
    /// <br>Programmer : 30452 上野 俊治</br>
    /// <br>Date       : 2008.11.25</br>
    /// <br>Update Note: 2009/02/27 30452 上野 俊治</br>
    /// <br>            ・障害対応12036</br>
    /// <br>           : 2009/03/05       照田 貴志　不具合対応[12191]</br>
    /// <br>Update Note: 2014/12/30 尹晶晶</br>
    /// <br>            ・明治産業　Seiken品番変更ＰＧ開発 帳票改良分対応</br>
    /// <br>Update Note: 2015/03/27 時シン</br>
    /// <br>管理番号   : 11070263-00</br>
    /// <br>           : Redmine#44209の#423品番集計区分の名称変更</br>
    /// </remarks>
    public partial class PMHNB02150UA : Form,
                                IPrintConditionInpType,					// 帳票共通（条件入力タイプ）
                                IPrintConditionInpTypeSelectedSection,	// 帳票業務（条件入力）拠点選択
                                IPrintConditionInpTypePdfCareer			// 帳票業務（条件入力）PDF出力履歴管理
    {
        #region ■ コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public PMHNB02150UA()
        {
            InitializeComponent();

            // 企業コード取得
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            // 拠点用のHashtable作成
            this._selectedSectionList = new Hashtable();

            // 日付取得部品
            this._dateGet = DateGetAcs.GetInstance();

            // ガイド
            // 純正メーカーガイド
            this._makerAcs = new MakerAcs();
            // ユーザマスタガイド（商品大分類用）
            this._userGuideAcs = new UserGuideAcs();
            // 商品中分類ガイド
            this._goodsGroupUAcs = new GoodsGroupUAcs();
            // グループコードガイド
            this._blGroupUAcs = new BLGroupUAcs();
            // BLコードガイド
            this._blGoodsCdAcs = new BLGoodsCdAcs();

            // 抽出条件クラス
            this._shipGdsPrimeListCndtn2 = new ShipGdsPrimeListCndtn2();

            // UI設定保存コンポーネント設定
            this.SetUIMemInputControl();
        }
        #endregion

        #region ■ private定数
        #region Interface関連
        //--IPrintConditionInpTypePdfCareerのプロパティ用変数 -------------------------
        // クラスID
        private const string ct_ClassID = "PMHNB02150UA";
        // プログラムID
        private const string ct_PGID = "PMHNB02150U";
        //// 帳票名称
        private string _printName = "出荷商品優良対応表Ⅱ";
        // 帳票キー	
        private string _printKey = "f3295b12-611c-4c4d-a017-5e8802014183";
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

        // メーカーガイド
        private MakerAcs _makerAcs;
        // ユーザマスタガイド（商品大分類用）
        private UserGuideAcs _userGuideAcs;
        // 商品中分類ガイド
        private GoodsGroupUAcs _goodsGroupUAcs;
        // グループコードガイド
        private BLGroupUAcs _blGroupUAcs;
        // BLコードガイド
        private BLGoodsCdAcs _blGoodsCdAcs;

        // 出荷商品優良対応表2 抽出条件データクラス
        private ShipGdsPrimeListCndtn2 _shipGdsPrimeListCndtn2;

        // 企業コード
        private string _enterpriseCode = "";

        /// <summary>改頁ラジオボタンのKeyPressイベントのヘルパ</summary>
        private readonly OptionSetKeyPressEventHelper _uos_NewPageDivRadioKeyPressHelper = new OptionSetKeyPressEventHelper();

        /// <summary>
        /// 改頁ラジオボタンのKeyPressイベントのヘルパを取得します。
        /// </summary>
        /// <value>改頁ラジオボタンのKeyPressイベントのヘルパ</value>
        public OptionSetKeyPressEventHelper Uos_NewPageDivRadioKeyPressHelper
        {
            get { return _uos_NewPageDivRadioKeyPressHelper; }
        }

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
        /// <br>Date		: 2008.11.25</br>
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
            printInfo.jyoken = this._shipGdsPrimeListCndtn2;
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
        /// <br>Date		: 2008.11.25</br>
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
        /// <br>Date		: 2008.11.25</br>
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
        /// <br>Date		: 2008.11.25</br>
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
        /// <br>Date		: 2008.11.25</br>
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
        /// <br>Date		: 2008.11.25</br>
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
        /// <br>Date		: 2008.11.25</br>
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
        /// <br>Date		: 2008.11.25</br>
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
        /// <br>Date		: 2008.11.25</br>
        /// <br>Update Note : 2014/12/30 尹晶晶</br>
        /// <br>             明治産業　Seiken品番変更ＰＧ開発 帳票改良分対応</br>
        /// </remarks>
        private int InitializeScreen(out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            errMsg = string.Empty;

            try
            {
                // ガイドボタン設定
                this.SetIconImage(this.ub_St_GoodsMakerCdGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_Ed_GoodsMakerCdGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_St_GoodsLGroupGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_Ed_GoodsLGroupGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_St_GoodsMGroupGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_Ed_GoodsMGroupGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_St_BLGloupCodeGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_Ed_BLGloupCodeGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_St_BLGoodsCodeGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_Ed_BLGoodsCodeGuide, Size16_Index.STAR1);

                // 対象期間取得
                /* ---DEL 2009/03/05 不具合対応[12191] -------------------------------->>>>>
                DateTime yearMonth;
                _dateGet.GetThisYearMonth(out yearMonth);

                tde_St_AddUpYearMonth.SetDateTime(yearMonth);
                tde_Ed_AddUpYearMonth.SetDateTime(yearMonth);
                   ---DEL 2009/03/05 不具合対応[12191] --------------------------------<<<<< */
                // ---ADD 2009/03/05 不具合対応[12191] -------------------------------->>>>>
                TotalDayCalculator totalDayCalculator = TotalDayCalculator.GetInstance();
                DateTime prevTotalDay;
                DateTime currentTotalDay;
                DateTime prevTotalMonth;
                DateTime currentTotalMonth;
                totalDayCalculator.InitializeHisMonthlyAccRec();
                totalDayCalculator.GetHisTotalDayMonthlyAccRec(LoginInfoAcquisition.Employee.BelongSectionCode, out prevTotalDay, out currentTotalDay, out prevTotalMonth, out currentTotalMonth);
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
                // ---ADD 2009/03/05 不具合対応[12191] --------------------------------<<<<<

                // 出力区分
                this.tComboEditor_OutputDiv.SelectedIndex = 0;

                // 出荷回数
                this.tNedit_ShipCount.SetInt(1);

                // 改頁
                this.uos_NewPageDiv.Value = 0;

                //------ ADD START 2014/12/30 尹晶晶 FOR Redmine#44209改良 ------>>>>>
                //品番集計区分
                this.tComboEditor_GoodsNoTtlDiv.SelectedIndex = 0;

                //品番表示区分
                this.tComboEditor_GoodsNoShowDiv.SelectedIndex = 0;
                //------ ADD END 2014/12/30 尹晶晶 FOR Redmine#44209改良 ------<<<<<

                // 印刷タイプ
                this.tComboEditor_PrintType.SelectedIndex = 0;

                // 抽出区分
                this.tComboEditor_ExtractDiv.SelectedIndex = 0;

                // 抽出条件
                this.tNedit_GoodsMakerCd_St.SetInt(0);
                this.tNedit_GoodsMakerCd_Ed.SetInt(0);
                this.tNedit_GoodsLGroup_St.SetInt(0);
                this.tNedit_GoodsLGroup_Ed.SetInt(0);
                this.tNedit_GoodsMGroup_St.SetInt(0);
                this.tNedit_GoodsMGroup_Ed.SetInt(0);
                this.tNedit_BLGloupCode_St.SetInt(0);
                this.tNedit_BLGloupCode_Ed.SetInt(0);
                this.tNedit_BLGoodsCode_St.SetInt(0);
                this.tNedit_BLGoodsCode_Ed.SetInt(0);

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
        /// <br>Date		: 2008.11.25</br>
        /// </remarks>
        private bool ScreenInputCheck(ref string errMessage, ref Control errComponent)
        {
            bool status = true;

            DateGetAcs.CheckDateRangeResult cdrResult;

            const string ct_NoInput = "を入力して下さい";
            const string ct_InputError = "の入力が不正です";
            const string ct_RangeError = "の範囲指定に誤りがあります";
            const string ct_RangeOverError = "は同一年度内で入力して下さい";

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
                            errMessage = string.Format("対象年月{0}", ct_RangeOverError);
                            errComponent = this.tde_St_AddUpYearMonth;
                        }
                        break;
                }
                status = false;
            }
            // 出荷回数
            else if (string.IsNullOrEmpty(this.tNedit_ShipCount.Text))
            {
                errMessage = string.Format("出荷回数{0}", ct_NoInput);
                errComponent = this.tNedit_ShipCount;
                status = false;
            }
            // 純正メーカー
            else if ((this.tNedit_GoodsMakerCd_St.GetInt() > this.tNedit_GoodsMakerCd_Ed.GetInt()) && (this.tNedit_GoodsMakerCd_Ed.GetInt() != 0))
            {
                errMessage = string.Format("メーカーコード{0}", ct_RangeError);
                errComponent = this.tNedit_GoodsMakerCd_St;
                status = false;
            }
            else if ((int)this.tComboEditor_ExtractDiv.SelectedItem.DataValue
                == (int)ShipGdsPrimeListCndtn2.ExtractDivState.Pure
                && this.tNedit_GoodsMakerCd_St.GetInt() > 99
                && (this.tNedit_GoodsMakerCd_St.GetInt() != 0))
            {
                errMessage = string.Format("抽出区分が純正の場合、メーカーコードは99以下で入力してください");
                errComponent = this.tNedit_GoodsMakerCd_St;
                status = false;
            }
            else if ((int)this.tComboEditor_ExtractDiv.SelectedItem.DataValue
                == (int)(ShipGdsPrimeListCndtn2.ExtractDivState.Pure)
                && this.tNedit_GoodsMakerCd_Ed.GetInt() > 99
           && (this.tNedit_GoodsMakerCd_Ed.GetInt() != 0))
            {
                errMessage = string.Format("抽出区分が純正の場合、メーカーコードは99以下で入力してください");
                errComponent = this.tNedit_GoodsMakerCd_Ed;
                status = false;
            }
            else if ((int)this.tComboEditor_ExtractDiv.SelectedItem.DataValue
                == (int)(ShipGdsPrimeListCndtn2.ExtractDivState.Superior)
                && this.tNedit_GoodsMakerCd_St.GetInt() < 100
                && (this.tNedit_GoodsMakerCd_St.GetInt() != 0))
            {
                errMessage = string.Format("抽出区分が優良の場合、メーカーコードは100以上で入力してください");
                errComponent = this.tNedit_GoodsMakerCd_St;
                status = false;
            }
            else if ((int)this.tComboEditor_ExtractDiv.SelectedItem.DataValue
                == (int)(ShipGdsPrimeListCndtn2.ExtractDivState.Superior)
                && this.tNedit_GoodsMakerCd_Ed.GetInt() < 100
                && (this.tNedit_GoodsMakerCd_Ed.GetInt() != 0))
            {
                errMessage = string.Format("抽出区分が優良の場合、メーカーコードは100以上で入力してください");
                errComponent = this.tNedit_GoodsMakerCd_Ed;
                status = false;
            }
            // 商品大分類
            else if ((this.tNedit_GoodsLGroup_St.GetInt() > this.tNedit_GoodsLGroup_Ed.GetInt()) && (this.tNedit_GoodsLGroup_Ed.GetInt() != 0))
            {
                errMessage = string.Format("商品大分類コード{0}", ct_RangeError);
                errComponent = this.tNedit_GoodsLGroup_St;
                status = false;
            }
            // 商品中分類
            else if ((this.tNedit_GoodsMGroup_St.GetInt() > this.tNedit_GoodsMGroup_Ed.GetInt()) && (this.tNedit_GoodsMGroup_Ed.GetInt() != 0))
            {
                errMessage = string.Format("商品中分類コード{0}", ct_RangeError);
                errComponent = this.tNedit_GoodsMGroup_St;
                status = false;
            }
            // グループコード
            else if ((this.tNedit_BLGloupCode_St.GetInt() > this.tNedit_BLGloupCode_Ed.GetInt()) && (this.tNedit_BLGloupCode_Ed.GetInt() != 0))
            {
                errMessage = string.Format("グループコード{0}", ct_RangeError);
                errComponent = this.tNedit_BLGloupCode_St;
                status = false;
            }
            // ＢＬコード
            else if ((this.tNedit_BLGoodsCode_St.GetInt() > this.tNedit_BLGoodsCode_Ed.GetInt()) && (this.tNedit_BLGoodsCode_Ed.GetInt() != 0))
            {
                errMessage = string.Format("ＢＬコード{0}", ct_RangeError);
                errComponent = this.tNedit_BLGoodsCode_St;
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
            cdrResult = _dateGet.CheckDateRange(DateGetAcs.YmdType.YearMonth, 12, ref tde_St_AddUpYearMonth, ref tde_Ed_AddUpYearMonth, false, true);
            return (cdrResult == DateGetAcs.CheckDateRangeResult.OK);
        }

        /// <summary>
        /// 抽出条件設定処理(画面→抽出条件)
        /// </summary>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note		: 画面→抽出条件へ設定する。</br>
        /// <br>Programmer	: 30452 上野 俊治</br>
        /// <br>Date		: 2008.11.25</br>
        /// <br>Update Note : 2014/12/30 尹晶晶</br>
        /// <br>             明治産業　Seiken品番変更ＰＧ開発 帳票改良分対応</br>
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
                this._shipGdsPrimeListCndtn2.IsOptSection = this._isOptSection;
                // 拠点コード
                this._shipGdsPrimeListCndtn2.SectionCodes = (string[])new ArrayList(this._selectedSectionList.Values).ToArray(typeof(string));
                // 企業コード
                this._shipGdsPrimeListCndtn2.EnterpriseCode = this._enterpriseCode;

                // 対象年月
                Int32 iSMonth = 0;
                Int32 iEMonth = 0;

                // DateTimeに変換
                iSMonth = (this.tde_St_AddUpYearMonth.GetLongDate() / 100) * 100 + 1; // 日
                iEMonth = (this.tde_Ed_AddUpYearMonth.GetLongDate() / 100) * 100 + 1;
                this.tde_St_AddUpYearMonth.SetLongDate(iSMonth);
                this.tde_Ed_AddUpYearMonth.SetLongDate(iEMonth);

                // 開始年度
                this._shipGdsPrimeListCndtn2.St_AddUpYearMonth = this.tde_St_AddUpYearMonth.GetDateTime();
                // 終了年度
                this._shipGdsPrimeListCndtn2.Ed_AddUpYearMonth = this.tde_Ed_AddUpYearMonth.GetDateTime();

                // 当期用
                // 開始月を含む年の情報を取得
                int year;
                int addYears;
                DateTime stYMonth;
                DateTime edYMonth;
                _dateGet.GetYearFromMonth(tde_Ed_AddUpYearMonth.GetDateTime(), out year, out addYears, out stYMonth, out edYMonth);
                // --- DEL 2009/02/27 -------------------------------->>>>>
                //int tmpStMonth = stYMonth.Month; // 期首月
                //int tmpEdMonth = this.tde_Ed_AddUpYearMonth.GetDateTime().Month; // 終了月は入力から取得

                //int annualStYMonth = this.tde_Ed_AddUpYearMonth.GetDateTime().Year * 10000 + tmpStMonth * 100 + 1;
                //int annualEdYMonth = this.tde_Ed_AddUpYearMonth.GetDateTime().Year * 10000 + tmpEdMonth * 100 + 1;

                //TDateEdit tmpTDateEdit = new TDateEdit();
                //tmpTDateEdit.SetLongDate(annualStYMonth);
                //// 開始年度(当期)
                //this._shipGdsPrimeListCndtn2.St_AnnualAddUpYearMonth = tmpTDateEdit.GetDateTime();

                //tmpTDateEdit.SetLongDate(annualEdYMonth);
                //this._shipGdsPrimeListCndtn2.Ed_AnnualAddUpYearMonth = tmpTDateEdit.GetDateTime();
                // --- DEL 2009/02/27 --------------------------------<<<<<
                // --- ADD 2009/02/27 -------------------------------->>>>>
                this._shipGdsPrimeListCndtn2.St_AnnualAddUpYearMonth = stYMonth;
                this._shipGdsPrimeListCndtn2.Ed_AnnualAddUpYearMonth = this.tde_Ed_AddUpYearMonth.GetDateTime();
                // --- ADD 2009/02/27 --------------------------------<<<<<

                // 出力区分
                this._shipGdsPrimeListCndtn2.OutputDiv = (ShipGdsPrimeListCndtn2.OutputDivState)this.tComboEditor_OutputDiv.SelectedItem.DataValue;

                // 出荷回数
                this._shipGdsPrimeListCndtn2.ShipCount = this.tNedit_ShipCount.GetInt();
                
                // 改頁
                this._shipGdsPrimeListCndtn2.NewPageDiv = (ShipGdsPrimeListCndtn2.NewPageDivState)this.uos_NewPageDiv.CheckedItem.DataValue;

                //------ ADD START 2014/12/30 尹晶晶 FOR Redmine#44209改良 ------>>>>>
                //品番集計区分
                this._shipGdsPrimeListCndtn2.GoodsNoTtlDiv = (ShipGdsPrimeListCndtn2.GoodsNoTtlDivState)this.tComboEditor_GoodsNoTtlDiv.SelectedItem.DataValue;

                //品番表示区分
                this._shipGdsPrimeListCndtn2.GoodsNoShowDiv = (ShipGdsPrimeListCndtn2.GoodsNoShowDivState)this.tComboEditor_GoodsNoShowDiv.SelectedItem.DataValue;
                //------ ADD END 2014/12/30 尹晶晶 FOR Redmine#44209改良 ------<<<<<

                // 印刷タイプ
                this._shipGdsPrimeListCndtn2.PrintType = (ShipGdsPrimeListCndtn2.PrintTypeState)this.tComboEditor_PrintType.SelectedItem.DataValue;

                // 抽出区分
                this._shipGdsPrimeListCndtn2.ExtractDiv = (ShipGdsPrimeListCndtn2.ExtractDivState)this.tComboEditor_ExtractDiv.SelectedItem.DataValue;

                // 開始メーカーコード
                this._shipGdsPrimeListCndtn2.St_GoodsMakerCd = this.tNedit_GoodsMakerCd_St.GetInt();
                // 終了メーカーコード
                this._shipGdsPrimeListCndtn2.Ed_GoodsMakerCd = this.tNedit_GoodsMakerCd_Ed.GetInt();
                // 開始商品大分類コード
                this._shipGdsPrimeListCndtn2.St_GoodsLGroup = this.tNedit_GoodsLGroup_St.GetInt();
                // 終了商品大分類コード
                this._shipGdsPrimeListCndtn2.Ed_GoodsLGroup = this.tNedit_GoodsLGroup_Ed.GetInt();
                // 開始商品中分類コード
                this._shipGdsPrimeListCndtn2.St_GoodsMGroup = this.tNedit_GoodsMGroup_St.GetInt();
                // 終了商品中分類コード
                this._shipGdsPrimeListCndtn2.Ed_GoodsMGroup = this.tNedit_GoodsMGroup_Ed.GetInt();
                // 開始グループコード
                this._shipGdsPrimeListCndtn2.St_BLGroupCode = this.tNedit_BLGloupCode_St.GetInt();
                // 終了グループコード
                this._shipGdsPrimeListCndtn2.Ed_BLGroupCode = this.tNedit_BLGloupCode_Ed.GetInt();
                // 開始ＢＬコード
                this._shipGdsPrimeListCndtn2.St_BLGoodsCode = this.tNedit_BLGoodsCode_St.GetInt();
                // 終了ＢＬコード
                this._shipGdsPrimeListCndtn2.Ed_BLGoodsCode = this.tNedit_BLGoodsCode_Ed.GetInt();
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

            //saveCtrAry.Add(this.tde_St_AddUpYearMonth);           //DEL 2009/03/05 不具合対応[12191]
            //saveCtrAry.Add(this.tde_Ed_AddUpYearMonth);           //DEL 2009/03/05 不具合対応[12191]
            saveCtrAry.Add(this.tComboEditor_OutputDiv);
            saveCtrAry.Add(this.tNedit_ShipCount);
            saveCtrAry.Add(this.uos_NewPageDiv);
            saveCtrAry.Add(this.tComboEditor_PrintType);
            saveCtrAry.Add(this.tComboEditor_ExtractDiv);
            //------ ADD START 2014/12/30 尹晶晶 FOR Redmine#44209改良 ------>>>>>
            // 品番集計区分
            saveCtrAry.Add(this.tComboEditor_GoodsNoTtlDiv);
            // 品番表示区分
            saveCtrAry.Add(this.tComboEditor_GoodsNoShowDiv); 
            //------ ADD END 2014/12/30 尹晶晶 FOR Redmine#44209改良 ------<<<<<
            saveCtrAry.Add(this.tNedit_GoodsMakerCd_St);
            saveCtrAry.Add(this.tNedit_GoodsMakerCd_Ed);
            saveCtrAry.Add(this.tNedit_GoodsLGroup_St);
            saveCtrAry.Add(this.tNedit_GoodsLGroup_Ed);
            saveCtrAry.Add(this.tNedit_GoodsMGroup_St);
            saveCtrAry.Add(this.tNedit_GoodsMGroup_Ed);
            saveCtrAry.Add(this.tNedit_BLGloupCode_St);
            saveCtrAry.Add(this.tNedit_BLGloupCode_Ed);
            saveCtrAry.Add(this.tNedit_BLGoodsCode_St);
            saveCtrAry.Add(this.tNedit_BLGoodsCode_Ed);

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
        /// <br>Date		: 2008.11.25</br>
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
        /// PMHNB02150UA_Loadイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PMHNB02150UA_Load(object sender, EventArgs e)
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

            Uos_NewPageDivRadioKeyPressHelper.ControlList.Add(this.uos_NewPageDiv);
            Uos_NewPageDivRadioKeyPressHelper.StartSpaceKeyControl();
        }

        /// <summary>
        /// GroupCollapsing Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: UltraExplorerBarGroupが縮小される前に発生する。</br>
        /// <br>Programmer	: 30452 上野 俊治</br>
        /// <br>Date		: 2008.11.25</br>
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
        /// <br>Date		: 2008.11.25</br>
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
            //------ ADD START 2014/12/30 尹晶晶 FOR Redmine#44209改良 ------>>>>>
            if ((e.PrevCtrl == this.tComboEditor_ExtractDiv) && (e.Key == Keys.Up))
            {
                if (tComboEditor_GoodsNoShowDiv.Enabled == true)
                {
                    e.NextCtrl = this.tComboEditor_GoodsNoShowDiv;
                }
                else
                {
                    e.NextCtrl = this.tComboEditor_GoodsNoTtlDiv;
                } 
            }
            else
            {
                //なし
            }
            //------ ADD END 2014/12/30 尹晶晶 FOR Redmine#44209改良 ------<<<<<
            // タブ、Enterキーでのガイド遷移不可
            if (e.PrevCtrl == this.tde_St_AddUpYearMonth)
            {
                if (e.NextCtrl == ub_Ed_BLGoodsCodeGuide && (e.Key == Keys.Tab || e.Key == Keys.Enter))
                {
                    e.NextCtrl = this.tNedit_BLGoodsCode_Ed;
                }
            }
            else if (e.PrevCtrl == this.tNedit_GoodsMakerCd_St)
            {
                if (e.NextCtrl == this.ub_St_GoodsMakerCdGuide && (e.Key == Keys.Tab || e.Key == Keys.Enter))
                {
                    e.NextCtrl = this.tNedit_GoodsMakerCd_Ed;
                }
            }
            else if (e.PrevCtrl == this.tNedit_GoodsMakerCd_Ed)
            {
                if (e.NextCtrl == this.ub_St_GoodsMakerCdGuide && (e.Key == Keys.Tab || e.Key == Keys.Enter))
                {
                    e.NextCtrl = this.tNedit_GoodsMakerCd_St;
                }
                else if (e.NextCtrl == this.ub_Ed_GoodsMakerCdGuide && (e.Key == Keys.Tab || e.Key == Keys.Enter))
                {
                    e.NextCtrl = this.tNedit_GoodsLGroup_St;
                }
            }
            else if (e.PrevCtrl == this.tNedit_GoodsLGroup_St)
            {
                if (e.NextCtrl == this.ub_Ed_GoodsMakerCdGuide && (e.Key == Keys.Tab || e.Key == Keys.Enter))
                {
                    e.NextCtrl = this.tNedit_GoodsMakerCd_Ed;
                }
                else if (e.NextCtrl == this.ub_St_GoodsLGroupGuide && (e.Key == Keys.Tab || e.Key == Keys.Enter))
                {
                    e.NextCtrl = this.tNedit_GoodsLGroup_Ed;
                }
            }
            else if (e.PrevCtrl == this.tNedit_GoodsLGroup_Ed)
            {
                if (e.NextCtrl == this.ub_St_GoodsLGroupGuide && (e.Key == Keys.Tab || e.Key == Keys.Enter))
                {
                    e.NextCtrl = this.tNedit_GoodsLGroup_St;
                }
                else if (e.NextCtrl == this.ub_Ed_GoodsLGroupGuide && (e.Key == Keys.Tab || e.Key == Keys.Enter))
                {
                    e.NextCtrl = this.tNedit_GoodsMGroup_St;
                }
            }
            else if (e.PrevCtrl == this.tNedit_GoodsMGroup_St)
            {
                if (e.NextCtrl == this.ub_Ed_GoodsLGroupGuide && (e.Key == Keys.Tab || e.Key == Keys.Enter))
                {
                    e.NextCtrl = this.tNedit_GoodsLGroup_Ed;
                }
                else if (e.NextCtrl == this.ub_St_GoodsMGroupGuide && (e.Key == Keys.Tab || e.Key == Keys.Enter))
                {
                    e.NextCtrl = this.tNedit_GoodsMGroup_Ed;
                }
            }
            else if (e.PrevCtrl == this.tNedit_GoodsMGroup_Ed)
            {
                if (e.NextCtrl == this.ub_St_GoodsMGroupGuide && (e.Key == Keys.Tab || e.Key == Keys.Enter))
                {
                    e.NextCtrl = this.tNedit_GoodsMGroup_St;
                }
                else if (e.NextCtrl == this.ub_Ed_GoodsMGroupGuide && (e.Key == Keys.Tab || e.Key == Keys.Enter))
                {
                    e.NextCtrl = this.tNedit_BLGloupCode_St;
                }
            }
            else if (e.PrevCtrl == this.tNedit_BLGloupCode_St)
            {
                if (e.NextCtrl == this.ub_Ed_GoodsMGroupGuide && (e.Key == Keys.Tab || e.Key == Keys.Enter))
                {
                    e.NextCtrl = this.tNedit_GoodsMGroup_Ed;
                }
                else if (e.NextCtrl == this.ub_St_BLGloupCodeGuide && (e.Key == Keys.Tab || e.Key == Keys.Enter))
                {
                    e.NextCtrl = this.tNedit_BLGloupCode_Ed;
                }
            }
            else if (e.PrevCtrl == this.tNedit_BLGloupCode_Ed)
            {
                if (e.NextCtrl == this.ub_St_BLGloupCodeGuide && (e.Key == Keys.Tab || e.Key == Keys.Enter))
                {
                    e.NextCtrl = this.tNedit_BLGloupCode_St;
                }
                else if (e.NextCtrl == this.ub_Ed_BLGloupCodeGuide && (e.Key == Keys.Tab || e.Key == Keys.Enter))
                {
                    e.NextCtrl = this.tNedit_BLGoodsCode_St;
                }
            }
            else if (e.PrevCtrl == this.tNedit_BLGoodsCode_St)
            {
                if (e.NextCtrl == this.ub_Ed_BLGloupCodeGuide && (e.Key == Keys.Tab || e.Key == Keys.Enter))
                {
                    e.NextCtrl = this.tNedit_BLGloupCode_Ed;
                }
                else if (e.NextCtrl == this.ub_St_BLGoodsCodeGuide && (e.Key == Keys.Tab || e.Key == Keys.Enter))
                {
                    e.NextCtrl = this.tNedit_BLGoodsCode_Ed;
                }
            }
            else if (e.PrevCtrl == this.tNedit_BLGoodsCode_Ed)
            {
                if (e.NextCtrl == this.ub_St_BLGoodsCodeGuide && (e.Key == Keys.Tab || e.Key == Keys.Enter))
                {
                    e.NextCtrl = this.tNedit_BLGoodsCode_St;
                }
                else if (e.NextCtrl == this.ub_Ed_BLGoodsCodeGuide && (e.Key == Keys.Tab || e.Key == Keys.Enter))
                {
                    e.NextCtrl = this.tde_St_AddUpYearMonth;
                }
            }
        }

        /// <summary>
        /// メーカーガイド
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ub_St_GoodsMakerCdGuide_Click(object sender, EventArgs e)
        {
            MakerUMnt makerUMnt;

            int status = _makerAcs.ExecuteGuid(this._enterpriseCode, out makerUMnt);
            if (status != 0) return;

            if (((UltraButton)sender).Tag.ToString().CompareTo("1") == 0)
            {
                this.tNedit_GoodsMakerCd_St.SetInt(makerUMnt.GoodsMakerCd);
                this.tNedit_GoodsMakerCd_Ed.Focus();
            }
            else if (((UltraButton)sender).Tag.ToString().CompareTo("2") == 0)
            {
                this.tNedit_GoodsMakerCd_Ed.SetInt(makerUMnt.GoodsMakerCd);
                this.tNedit_GoodsLGroup_St.Focus();
            }
            else
            {
                return;
            }
        }

        /// <summary>
        /// 商品大分類ガイド
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ub_St_GoodsLGroupGuide_Click(object sender, EventArgs e)
        {
            UserGdBd userGdBd;
            UserGdHd userGdHd;

            int status = this._userGuideAcs.ExecuteGuid(this._enterpriseCode, out userGdHd, out userGdBd, 70);
            if (status != 0) return;

            if (((UltraButton)sender).Tag.ToString().CompareTo("1") == 0)
            {
                this.tNedit_GoodsLGroup_St.SetInt(userGdBd.GuideCode);
                this.tNedit_GoodsLGroup_Ed.Focus();
            }
            else if (((UltraButton)sender).Tag.ToString().CompareTo("2") == 0)
            {
                this.tNedit_GoodsLGroup_Ed.SetInt(userGdBd.GuideCode);
                this.tNedit_GoodsMGroup_St.Focus();
            }
            else
            {
                return;
            }
        }

        /// <summary>
        /// 商品中分類ガイド
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ub_St_GoodsMGroupGuide_Click(object sender, EventArgs e)
        {
            GoodsGroupU goodgroupU;

            int status = this._goodsGroupUAcs.ExecuteGuid(this._enterpriseCode, out goodgroupU, true);
            if (status != 0) return;

            if (((UltraButton)sender).Tag.ToString().CompareTo("1") == 0)
            {
                this.tNedit_GoodsMGroup_St.SetInt(goodgroupU.GoodsMGroup);
                this.tNedit_GoodsMGroup_Ed.Focus();
            }
            else if (((UltraButton)sender).Tag.ToString().CompareTo("2") == 0)
            {
                this.tNedit_GoodsMGroup_Ed.SetInt(goodgroupU.GoodsMGroup);
                this.tNedit_BLGloupCode_St.Focus();
            }
            else
            {
                return;
            }
        }

        /// <summary>
        /// BLグループガイド
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ub_St_BLGloupCodeGuide_Click(object sender, EventArgs e)
        {
            // BLグループガイド起動
            BLGroupU blGroupU;

            int status = this._blGroupUAcs.ExecuteGuid(this._enterpriseCode, out blGroupU);
            if (status != 0) return;

            if (((UltraButton)sender).Tag.ToString().CompareTo("1") == 0)
            {
                this.tNedit_BLGloupCode_St.SetInt(blGroupU.BLGroupCode);
                this.tNedit_BLGloupCode_Ed.Focus();
            }
            else if (((UltraButton)sender).Tag.ToString().CompareTo("2") == 0)
            {
                this.tNedit_BLGloupCode_Ed.SetInt(blGroupU.BLGroupCode);
                this.tNedit_BLGoodsCode_St.Focus();
            }
            else
            {
                return;
            }
        }

        /// <summary>
        /// ＢＬコードガイド
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ub_St_BLGoodsCodeGuide_Click(object sender, EventArgs e)
        {
            BLGoodsCdUMnt bLGoodsCdUMnt;

            int status = _blGoodsCdAcs.ExecuteGuid(this._enterpriseCode, out bLGoodsCdUMnt);
            if (status != 0) return;

            if (((UltraButton)sender).Tag.ToString().CompareTo("1") == 0)
            {
                this.tNedit_BLGoodsCode_St.SetInt(bLGoodsCdUMnt.BLGoodsCode);
                this.tNedit_BLGoodsCode_Ed.Focus();
            }
            else if (((UltraButton)sender).Tag.ToString().CompareTo("2") == 0)
            {
                this.tNedit_BLGoodsCode_Ed.SetInt(bLGoodsCdUMnt.BLGoodsCode);
                this.tde_St_AddUpYearMonth.Focus();
            }
            else
            {
                return;
            }
        }

        //------ ADD START 2014/12/30 尹晶晶 FOR Redmine#44209改良 ------>>>>>
        /// <summary>
        /// 品番集計区分SelectionChangedイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tComboEditor_GoodsNoTtlDiv_ValueChanged(object sender, EventArgs e)
        {
            if (tComboEditor_GoodsNoTtlDiv.Value.Equals(0))
            {
                tComboEditor_GoodsNoShowDiv.Value = 0;
                tComboEditor_GoodsNoShowDiv.Enabled = false;
            }
            else
            {
                tComboEditor_GoodsNoShowDiv.Value = 0;
                tComboEditor_GoodsNoShowDiv.Enabled = true;
            }
        }
        //------ ADD END 2014/12/30 尹晶晶 FOR Redmine#44209改良 ------<<<<<
        #endregion

    }
}