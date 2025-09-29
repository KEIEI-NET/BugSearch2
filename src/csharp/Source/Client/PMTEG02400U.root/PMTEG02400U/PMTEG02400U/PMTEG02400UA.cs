//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 手形月別予定表
// プログラム概要   : 手形月別予定表情報を抽出し、印刷・PDF出力する
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 姜凱
// 作 成 日  2010/04/21  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.UIData;
using Infragistics.Win.Misc;
using Broadleaf.Application.Controller;
using Broadleaf.Library.Globarization;
using System.Net.NetworkInformation;
using System.Text.RegularExpressions;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 手形月別予定表 入力フォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 手形月別予定表PDF出力操作を行うクラスです。</br>
    /// <br>Programmer : 姜凱</br>
    /// <br>Date       : 2010.05.05</br>
    /// </remarks>
    public partial class PMTEG02400UA : Form,
                                IPrintConditionInpType,					// 帳票共通（条件入力タイプ）
                                IPrintConditionInpTypePdfCareer			// 帳票業務（条件入力）PDF出力履歴管理
    {
        #region ■ Constructor
        /// <summary>
        /// 帳票共通(条件入力タイプ)フレームクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br>Programmer : 姜凱</br>
        /// <br>Date       : 2010.05.05</br>
        /// </remarks>
        public PMTEG02400UA()
        {
            InitializeComponent();
            // 企業コード取得
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            this._employeeAcs = new EmployeeAcs();
            //日付取得部品
            this._dateGet = DateGetAcs.GetInstance();

        }
        #endregion ■ Constructor

        #region ■ Private Member
        #region ◆ Interface member

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

		// 選択手形種別リスト
		private SortedList _selectedDraftKindList = new SortedList();
        #endregion ◆ Interface member

        // 企業コード
        private string _enterpriseCode = string.Empty;

        // 画面イメージコントロール部品
        private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();

        // 抽出条件クラス
        private TegataTsukibetsuYoteListReport _tegataTsukibetsuYoteListReport;

        // ガイド系アクセスクラス
        private EmployeeAcs _employeeAcs;

        //日付取得部品
        private DateGetAcs _dateGet;

        // フォーカスControl
        private Control _prevControl = null;

        // チェックエラー
        private bool hasCheckError = false;

		// 銀行/支店ガイド結果OKフラグ
		private bool _bankBranchGuideOK;

		// 銀行/支店ガイド用
		private UltraButton _bankBranchGuideSender;

		// 手形種別チェック判断用
		private bool _checkFlag = false;

        // 印刷範囲年月Clone
        private string _thisYearMonthClone;

        #endregion ■ Private Member

        #region ■ Private Const
        #region ◆ Interface member
        //--IPrintConditionInpTypePdfCareerのプロパティ用変数 -------------------------
		// クラスID
        private const string ct_ClassID = "PMTEG02400UA";
		// プログラムID
        private const string ct_PGID = "PMTEG02400U";
		//// 帳票名称
        private const string PDF_PRINT_NAME1 = "受取手形月別予定表";
        private const string PDF_PRINT_NAME2 = "支払手形月別予定表";
		private string _printName = string.Empty;
        // 帳票キー	
		private const string PDF_PRINT_KEY = "1edbf5b6-78b7-436c-852d-65aec83d680e";
        
		private string _printKey = PDF_PRINT_KEY;
		#endregion ◆ Interface member
        #endregion Private Const

        #region ■ IPrintConditionInpType メンバ

        #region ◆ Public Event
        /// <summary> 親ツールバー設定イベント </summary>
        public event ParentToolbarSettingEventHandler ParentToolbarSettingEvent;
        #endregion ◆ Public Event

        #region ◆ Public Property
        /// <summary> 抽出ボタン状態</summary>
        /// <value>CanExtract</value>               
        /// <remarks>抽出ボタン状態取得プロパティ </remarks> 
        public bool CanExtract
        {
            get { return this._canExtract; }
        }

        /// <summary> PDF出力ボタン状態</summary>
        /// <value>CanPdf</value>               
        /// <remarks>PDF出力ボタン状態取得プロパティ </remarks> 
        public bool CanPdf
        {
            get { return this._canPdf; }
        }

        /// <summary> 印刷ボタン状態</summary>
        /// <value>CanPrint</value>               
        /// <remarks>印刷ボタン状態取得プロパティ </remarks> 
        public bool CanPrint
        {
            get { return this._canPrint; }
        }

        /// <summary> 抽出ボタン表示有無プロパティ</summary>
        /// <value>VisibledExtractButton</value>               
        /// <remarks>抽出ボタン表示有無取得プロパティ </remarks> 
        public bool VisibledExtractButton
        {
            get { return this._visibledExtractButton; }
        }

        /// <summary> PDF出力ボタン表示有無</summary>
        /// <value>CanPrint</value>               
        /// <remarks>PDF出力ボタン表示有無プロパティ取得プロパティ </remarks> 
        public bool VisibledPdfButton
        {
            get { return this._visibledPdfButton; }
        }

        /// <summary> 印刷ボタン表示</summary>
        /// <value>VisibledPrintButton</value>               
        /// <remarks>印刷ボタン表示取得プロパティ </remarks> 
        public bool VisibledPrintButton
        {
            get { return this._visibledPrintButton; }
        }
        
        #endregion ◆ Public Property

        #region ◆ Public Method

        #region ◎ 抽出処理
        /// <summary>
        /// 抽出処理
        /// </summary>
        /// <param name="parameter">パラメータ</param>
        /// <returns>0( 固定 )</returns>
        /// <remarks>
        /// <br>Note		: 抽出処理を行う。</br>
        /// <br>Programmer  : 姜凱</br>
        /// <br>Date        : 2010.05.05</br>
        /// </remarks>
        public int Extract(ref object parameter)
        {
            // 抽出処理は無いので処理終了
            return 0;
        }
        #endregion

        #region ◎ 印刷前確認処理
        /// <summary>
        /// 印刷前確認処理
        /// </summary>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note		: 印刷前確認処理を行う。(入力チェックなど)</br>
        /// <br>Programmer  : 姜凱</br>
        /// <br>Date        : 2010.05.05</br>
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

                // フォーカスアウト処理
                if (this._prevControl != null)
                {
                    hasCheckError = false;
                    ChangeFocusEventArgs e = new ChangeFocusEventArgs(false, false, false, Keys.Return, this._prevControl, this._prevControl);
                    this.tArrowKeyControl1_ChangeFocus(this, e);
                }
                if (hasCheckError)
                {
                    status = false;
                }

                status = false;
            }
            return status;
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
        /// <br>Programmer  : 姜凱</br>
        /// <br>Date        : 2010.05.05</br>
        /// </remarks>
        public int Print(ref object parameter)
        {

            // オフライン状態チェック	
            if (!CheckOnline())
            {
                TMsgDisp.Show(
                    emErrorLevel.ERR_LEVEL_STOP,
                    this.Text,
                    "手形月別予定表データ読み込みに失敗しました。",
                    (int)ConstantManagement.DB_Status.ctDB_OFFLINE, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                return -1;
            }

            SFCMN06001U printDialog = new SFCMN06001U();		// 帳票選択ガイド
            SFCMN06002C printInfo = parameter as SFCMN06002C;	// 印刷情報パラメータ

            // 画面→抽出条件クラス
            int status = this.SetExtraInfoFromScreen();
            if (status != 0)
            {
                return -1;
            }

			// 企業コードをセット
			printInfo.enterpriseCode = this._enterpriseCode;
			printInfo.kidopgid = ct_PGID;				// 起動PGID

			// PDF出力履歴用
			printInfo.key = this._printKey;
			if (this._tegataTsukibetsuYoteListReport.DraftDivide == 0)
			{
				this._printName = PDF_PRINT_NAME1;
				if (this._tegataTsukibetsuYoteListReport.SortOrder == 0)
				{
					printInfo.PrintPaperSetCd = 0;
				}
				else
				{
					printInfo.PrintPaperSetCd = 2;
				}
			}
			else
			{
				this._printName = PDF_PRINT_NAME2;
				if (this._tegataTsukibetsuYoteListReport.SortOrder == 0)
				{
					printInfo.PrintPaperSetCd = 1;
				}
				else
				{
					printInfo.PrintPaperSetCd = 3;
				}
			}
			printInfo.prpnm = this._printName;
			// 抽出条件の設定
			printInfo.jyoken = this._tegataTsukibetsuYoteListReport;
			printDialog.PrintInfo = printInfo;

            // 帳票選択ガイド
            DialogResult dialogResult = printDialog.ShowDialog();

            if (printInfo.status == (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN)
            {
                MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "該当するデータがありません。", 0);
            }
            
            parameter = printInfo;
            return printInfo.status;
        }
        #endregion

        #region ◎ 画面表示処理
        /// <summary>
        /// 画面表示処理
        /// </summary>
        /// <param name="parameter">起動パラメータ</param>
        /// <remarks>
        /// <br>Note		: 画面表示を行う。</br>
        /// <br>Programmer  : 姜凱</br>
        /// <br>Date        : 2010.05.05</br>
        /// </remarks>
        public void Show(object parameter)
        {
            this._tegataTsukibetsuYoteListReport = new TegataTsukibetsuYoteListReport();

            // 引数型チェック
            //int result = 0;
            this.Show();

            return;
        }
        #endregion

        #region ◎ 初期選択計上拠点設定処理( 未実装 )
        /// <summary>
        /// 初期選択計上拠点設定処理( 未実装 )
        /// </summary>
        /// <param name="addUpCd"></param>
        /// <remarks>
        /// <br>Note		: 未実装</br>
        /// <br>Programmer  : 姜凱</br>
        /// <br>Date        : 2010.05.05</br>
        /// </remarks>
        public void InitSelectAddUpCd(int addUpCd)
        {
            // 計上拠点選択がないので未実装
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
        /// <br>Programmer  : 姜凱</br>
        /// <br>Date        : 2010.05.05</br>
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
        /// <br>Programmer  : 姜凱</br>
        /// <br>Date        : 2010.05.05</br>
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
            get { return _printName; }
        }

        #endregion ◆ Public Method
        #endregion ■ IPrintConditionInpTypePdfCareer メンバ

        #region ■ Control Event
        #region ◆ PMTEG02400UA
        #region ◎ PMTEG02400UA_Load Event
        /// <summary>
        /// PMTEG02400UA_Load Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: ユーザーがﾌｫｰﾑを読み込むときに発生する</br>
        /// <br>Programmer  : 姜凱</br>
        /// <br>Date        : 2010.05.05</br>
        /// </remarks>
        private void PMTEG02400UA_Load(object sender, EventArgs e)
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
            // 画面スキンファイルの読込(デフォルトスキン指定)
            this._controlScreenSkin.LoadSkin();
            // 画面スキン変更		
            this._controlScreenSkin.SettingScreenSkin(this);		
            // ツールバーボタン設定イベント起動 
            ParentToolbarSettingEvent(this);						    
            // 初期化フォーカス
            this.Cursor = Cursors.WaitCursor;
            // 仕入支払管理オプション(*1)により、初期フォーカス位置を変更する
            int option = (int)LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(Broadleaf.Application.Resources.ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_StockingPayment);
            // 買掛有の場合、初期フォーカスは 手形区分とする。
            if (0 < option)
            {
                this.tComboEditor_DraftDivide.Focus();
                _prevControl = tComboEditor_DraftDivide;
            }
            // 買掛無の場合、初期フォーカスは 印刷範囲年月とし、手形区分は入力不可（グレーアウト）とする。
            else
            {
                this.tDateEdit_YearMonth.Focus();
                _prevControl = tDateEdit_YearMonth;
                this.tComboEditor_DraftDivide.Enabled = false;
            }

            this.Cursor = Cursors.Default;

        }
        #endregion

        #region ◎ tArrowKeyControl1
        /// <summary>
        /// 矢印キーでのフォーカス移動イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note		: なし</br>
        /// <br>Programmer  : 姜凱</br>
        /// <br>Date        : 2010.05.05</br>
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (!e.ShiftKey)
            {
                // SHIFTキー未押下
                if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                {
                    if (e.PrevCtrl == this.tComboEditor_DraftDivide)
                    {
                        // 手形区分→印刷範囲年月
                        e.NextCtrl = this.tDateEdit_YearMonth;
                    }
                    else if (e.PrevCtrl == this.tDateEdit_YearMonth)
                    {
						// 印刷範囲年月→改頁
						e.NextCtrl = this.tComboEditor_ChangePg;
                    }
					else if (e.PrevCtrl == this.tComboEditor_ChangePg)
					{
						// 改頁→出力順
						e.NextCtrl = this.tComboEditor_Sort;
					}
					else if (e.PrevCtrl == this.tComboEditor_Sort)
					{
						// 出力順→銀行コード開始
						e.NextCtrl = this.tNedit_BankCd_St;
					}
					else if (e.PrevCtrl == this.tNedit_BankCd_St)
					{
						tNedit_BankCd_St_AfterExitEditMode(e.PrevCtrl, null);
						// 銀行コード開始→支店コード開始
						e.NextCtrl = this.tNedit_BranchCd_St;

					}
					else if (e.PrevCtrl == this.tNedit_BranchCd_St)
					{
						tNedit_BranchCd_St_AfterExitEditMode(e.PrevCtrl, null);
						// 支店コード開始→銀行/支店コード開始ガイドボタン
						e.NextCtrl = this.ub_St_BankBranchCd;
					}
					else if (e.PrevCtrl == this.ub_St_BankBranchCd)
					{
						// 銀行/支店コード開始ガイドボタン→銀行コード終了
						e.NextCtrl = this.tNedit_BankCd_Ed;

					}
					else if (e.PrevCtrl == this.tNedit_BankCd_Ed)
					{
						tNedit_BankCd_Ed_AfterExitEditMode(e.PrevCtrl, null);
						// 銀行コード終了→支店コード終了
						e.NextCtrl = this.tNedit_BranchCd_Ed;

					}
					else if (e.PrevCtrl == this.tNedit_BranchCd_Ed)
					{
						tNedit_BranchCd_Ed_AfterExitEditMode(e.PrevCtrl, null);
						// 支店コード終了→銀行/支店コード終了ガイドボタン
						e.NextCtrl = this.ub_Ed_BankBranchCd;
					}
					else if (e.PrevCtrl == this.ub_Ed_BankBranchCd)
					{
						// 銀行/支店コード終了ガイドボタン→手形種別
						e.NextCtrl = this.DraftKindCd_ultraTree;

					}
					else if (e.PrevCtrl == this.DraftKindCd_ultraTree)
					{
						// 手形種別→手形区分
						e.NextCtrl = this.tComboEditor_DraftDivide;

					}
                }
            }
            else
            {
                // SHIFTキー押下
                if (e.Key == Keys.Tab)
                {
					if (e.PrevCtrl == this.DraftKindCd_ultraTree)
					{
						// 手形種別→銀行/支店コード終了ガイドボタン
						e.NextCtrl = this.ub_Ed_BankBranchCd;
					}
					else if (e.PrevCtrl == this.ub_Ed_BankBranchCd)
					{
						// 銀行/支店コード終了ガイドボタン→支店コード終了
						e.NextCtrl = this.tNedit_BranchCd_Ed;
					}
					else if (e.PrevCtrl == this.tNedit_BranchCd_Ed)
					{
						tNedit_BranchCd_Ed_AfterExitEditMode(e.PrevCtrl, null);
						// 支店コード終了→銀行コード終了
						e.NextCtrl = this.tNedit_BankCd_Ed;
					}
					else if (e.PrevCtrl == this.tNedit_BankCd_Ed)
					{
						tNedit_BankCd_Ed_AfterExitEditMode(e.PrevCtrl, null);
						// 銀行コード終了→銀行/支店コード開始ガイドボタン
						e.NextCtrl = this.ub_St_BankBranchCd;
					}
					else if (e.PrevCtrl == this.ub_St_BankBranchCd)
					{
						// 銀行/支店コード開始ガイドボタン→支店コード開始
						e.NextCtrl = this.tNedit_BranchCd_St;
					}
					else if (e.PrevCtrl == this.tNedit_BranchCd_St)
					{
						tNedit_BranchCd_St_AfterExitEditMode(e.PrevCtrl, null);
						//支店コード開始→銀行コード開始
						e.NextCtrl = this.tNedit_BankCd_St;
					}
					else if (e.PrevCtrl == this.tNedit_BankCd_St)
					{
						tNedit_BankCd_St_AfterExitEditMode(e.PrevCtrl, null);
						// 銀行コード開始→出力順
						e.NextCtrl = this.tComboEditor_Sort;
					}
					else if (e.PrevCtrl == this.tComboEditor_Sort)
					{
						// 出力順→改頁
						e.NextCtrl = this.tComboEditor_ChangePg;
					}
					else if (e.PrevCtrl == this.tComboEditor_ChangePg)
                    {
						// 改頁→印刷範囲年月
                        e.NextCtrl = this.tDateEdit_YearMonth;
                    }
                    else if (e.PrevCtrl == this.tDateEdit_YearMonth)
                    {
                        // 印刷範囲年月→手形区分
                        e.NextCtrl = this.tComboEditor_DraftDivide;
                    }
					else if (e.PrevCtrl == this.tComboEditor_DraftDivide)
					{
						// 手形区分→手形種別
						e.NextCtrl = this.DraftKindCd_ultraTree;
					}

                }
            }
        }
        #endregion

        #endregion ◆ PMTEG02400UA

        # region ■ ガイドボタンクリックイベント
		/// <summary>
		/// 銀行/支店ガイドボタンクリックイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks> 
		/// <br>Note       : 銀行/支店ガイドをクリックするときに発生する</br> 
		/// <br>Programmer  : 姜凱</br>
		/// <br>Date        : 2010.05.05</br>
		/// </remarks>
		private void ub_St_BankBranchCd_Click(object sender, EventArgs e)
		{
			_bankBranchGuideOK = false;

			// 押下されたボタンを退避
			if (sender is UltraButton)
			{
				_bankBranchGuideSender = (UltraButton)sender;
			}

			this.SearchForm_BankBranchSelect(_bankBranchGuideSender);

			if (_bankBranchGuideOK)
			{
				if (sender == ub_St_BankBranchCd)
				{
					this.ub_St_BankBranchCd.Focus();
				}
				else if (sender == ub_Ed_BankBranchCd)
				{
					this.ub_Ed_BankBranchCd.Focus();
				}
			}
		}

		/// <summary>
		/// 銀行/支店ガイド選択イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <remarks> 
		/// <br>Note       : 銀行/支店ガイドをクリックするときに発生する</br> 
		/// <br>Programmer  : 姜凱</br>
		/// <br>Date        : 2010.05.05</br>
		/// </remarks>
		private void SearchForm_BankBranchSelect(object sender)
		{
			// ガイド起動
			UserGdHd userGdHd;
			UserGdBd userGdBd;
			UserGuideAcs userGuideAcs = new UserGuideAcs();

			int status = userGuideAcs.ExecuteGuid(this._enterpriseCode, out userGdHd, out userGdBd, 46);

			if (status != 0) return;
			// 項目に展開
			if (_bankBranchGuideSender == this.ub_St_BankBranchCd)
			{
				this.tNedit_BankCd_St.SetInt(userGdBd.GuideCode / 1000);
				this.tNedit_BranchCd_St.SetInt(userGdBd.GuideCode % 1000);
			}
			else
			{
				this.tNedit_BankCd_Ed.SetInt(userGdBd.GuideCode / 1000);
				this.tNedit_BranchCd_Ed.SetInt(userGdBd.GuideCode % 1000);
			}

			_bankBranchGuideOK = true;
		}
        #endregion ■ ガイドボタンクリックイベント

		#region ■ フォーカスアウト
		/// <summary>
		/// AfterExitEditMode イベント処理イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		/// <remarks>
		/// <br>Note       : 銀行コード開始フォーカスが離れたときに発生します。</br>      
		/// <br>Programmer : 姜凱</br>                                  
		/// <br>Date       : 2010.05.05</br>  
		/// </remarks> 
		private void tNedit_BankCd_St_AfterExitEditMode(object sender, EventArgs e)
		{
			// 銀行/支店コード開始の値は数字ではない場合
			if (!this.IsInteger(this.tNedit_BankCd_St.Text))
			{
				this.tNedit_BankCd_St.Text = string.Empty;
				hasCheckError = false;
				return;
			}
		}

		/// <summary>
		/// AfterExitEditMode イベント処理イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		/// <remarks>
		/// <br>Note       : 銀行コード終了フォーカスが離れたときに発生します。</br>      
		/// <br>Programmer : 姜凱</br>                                  
		/// <br>Date       : 2010.05.05</br> 
		/// </remarks> 
		private void tNedit_BankCd_Ed_AfterExitEditMode(object sender, EventArgs e)
		{
			// 銀行/支店コード終了の値は数字ではない場合
			if (!this.IsInteger(this.tNedit_BankCd_Ed.Text))
			{
				this.tNedit_BankCd_Ed.Text = string.Empty;
				hasCheckError = false;
				return;
			}
		}

		/// <summary>
		/// AfterExitEditMode イベント処理イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		/// <remarks>
		/// <br>Note       : 支店コード開始フォーカスが離れたときに発生します。</br>      
		/// <br>Programmer : 姜凱</br>                                  
		/// <br>Date       : 2010.05.05</br> 
		/// </remarks> 
		private void tNedit_BranchCd_St_AfterExitEditMode(object sender, EventArgs e)
		{
			// 銀行/支店コード開始の値は数字ではない場合
			if (!this.IsInteger(this.tNedit_BranchCd_St.Text))
			{
				this.tNedit_BranchCd_St.Text = string.Empty;
				hasCheckError = false;
				return;
			}
		}

		/// <summary>
		/// AfterExitEditMode イベント処理イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		/// <remarks>
		/// <br>Note       : 支店コード終了フォーカスが離れたときに発生します。</br>      
		/// <br>Programmer : 姜凱</br>                                  
		/// <br>Date       : 2010.05.05</br> 
		/// </remarks> 
		private void tNedit_BranchCd_Ed_AfterExitEditMode(object sender, EventArgs e)
		{
			// 銀行/支店コード終了の値は数字ではない場合
			if (!this.IsInteger(this.tNedit_BranchCd_Ed.Text))
			{
				this.tNedit_BranchCd_Ed.Text = string.Empty;
				hasCheckError = false;
				return;
			}
		}
		#endregion ■ フォーカスアウト

		/// <summary>
		/// AfterCheck イベント処理イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		/// <remarks>
		/// <br>Note       : 手形種別をチェックされたときに発生します。</br>      
		/// <br>Programmer : 姜凱</br>                                  
		/// <br>Date       : 2010.05.05</br> 
		/// </remarks> 
		private void DraftKindCd_ultraTree_AfterCheck(object sender, Infragistics.Win.UltraWinTree.NodeEventArgs e)
		{
			// 「全て」をクリックされたとき
			if (e.TreeNode.Index == 0)
			{
				if (this.DraftKindCd_ultraTree.Nodes[0].CheckedState == CheckState.Checked)
				{
					for (int i = 1; i <= 9; i++)
					{
						if (this.DraftKindCd_ultraTree.Nodes[i].CheckedState == CheckState.Checked)
						{
							_checkFlag = true;
							this.DraftKindCd_ultraTree.Nodes[i].CheckedState = CheckState.Unchecked;
						}
					}
					return;
				}
			}
			else
			{
				if (!_checkFlag && this.DraftKindCd_ultraTree.Nodes[0].CheckedState == CheckState.Checked)
				{
					for (int i = 1; i <= 9; i++)
					{
						if (this.DraftKindCd_ultraTree.Nodes[i].CheckedState == CheckState.Checked)
						{
							this.DraftKindCd_ultraTree.Nodes[0].CheckedState = CheckState.Unchecked;
							break;
						}
					}
					return;
				}
				_checkFlag = false;
			}
		}
        
        #endregion ■ Control Event

        #region ■ Private Method
        #region ◆ 画面初期化関係
        #region ◎ 画面初期化処理
        /// <summary>
        /// 画面初期化処理
        /// </summary>
        /// <remarks>
        /// <br>Note		: 入力項目の初期化を行う</br>
        /// <br>Programmer  : 姜凱</br>
        /// <br>Date        : 2010.05.05</br>
        /// </remarks>
        private int InitializeScreen(out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            errMsg = string.Empty;
            
            try
            {
                // 印刷範囲年月
                TotalDayCalculator totalDayCalculator = TotalDayCalculator.GetInstance();
                //年月度 ( 日は01 )
                DateTime thisYearMonth;
                //年度
                Int32 thisYear;
                //年月度開始日
                DateTime startMonthDate;
                //年月度終了日
                DateTime endMonthDate;
                //年度開始日
                DateTime startYearDate;
                //年度終了日
                DateTime endYearDate;
                this._dateGet.GetThisYearMonth(out thisYearMonth, out thisYear, out startMonthDate, out endMonthDate, out startYearDate, out endYearDate);
                // 印刷範囲年月を設定
                this.tDateEdit_YearMonth.SetDateTime(thisYearMonth);
                // 保存初期化した印刷範囲年月
                _thisYearMonthClone = tDateEdit_YearMonth.GetDateTime().ToString("yyyyMM");
                // 改ページ
                if (this.tComboEditor_ChangePg.Value == null)
                {
					this.tComboEditor_ChangePg.Value = 0;  // DEF：小計
                }
				// 出力順
				if (this.tComboEditor_Sort.Value == null)
				{
					this.tComboEditor_Sort.Value = 0;   // DEF:手形種別順
				}
                // 手形区分
                if (this.tComboEditor_DraftDivide.Value == null)
                {
                    this.tComboEditor_DraftDivide.Value = 0;   // DEF:受取手形
                }
				// 「全て」にチェック
				this.DraftKindCd_ultraTree.Nodes[0].CheckedState = CheckState.Checked;
				// ボタン設定
				this.SetIconImage(this.ub_St_BankBranchCd, Size16_Index.STAR1);
				this.SetIconImage(this.ub_Ed_BankBranchCd, Size16_Index.STAR1);

                // 前回表示状態が保存されていれば上書き
                this.uiMemInput1.ReadMemInput(); 

            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
           
            return status;
        }
        #endregion

        #region ◎ ボタンアイコン設定処理
        /// <summary>
        /// ボタンアイコン設定処理
        /// </summary>
        /// <param name="settingControl">アイコンセットするコントロール</param>
        /// <param name="iconIndex">アイコンインデックス</param>
        /// <remarks>
        /// <br>Note		: ボタンアイコンを設定する</br>
        /// <br>Programmer  : 姜凱</br>
        /// <br>Date        : 2010.05.05</br>
        /// </remarks>
        private void SetIconImage(object settingControl, Size16_Index iconIndex)
        {
            ((UltraButton)settingControl).ImageList = IconResourceManagement.ImageList16;
            ((UltraButton)settingControl).Appearance.Image = iconIndex;
        }
        #endregion
        #endregion ◆ 画面初期化関係

        #region ◆ 印刷前処理
        #region ◎ 入力チェック処理
        /// <summary>
        /// 入力チェック処理
        /// </summary>
        /// <param name="errMessage">エラーメッセージ</param>
        /// <param name="errComponent">エラー発生コンポーネント</param>
        /// <returns>True:OK, False:NG</returns>
        /// <remarks>
        /// <br>Note		: 画面の入力チェックを行う。</br>
        /// <br>Programmer  : 姜凱</br>
        /// <br>Date        : 2010.05.05</br>
        /// </remarks>
		private bool ScreenInputCheck(ref string errMessage, ref Control errComponent)
		{
			const string ct_RangeError = "の範囲指定に誤りがあります。";
			const string ct_NoInputError = "を入力してください。";
			const string ct_InputError = "の入力が不正です。";

			bool status = true;
			int longDate = this.tDateEdit_YearMonth.LongDate;
			longDate = (longDate / 100) * 100 + 1;
			this.tDateEdit_YearMonth.SetLongDate(longDate);
			if (this.tDateEdit_YearMonth.GetDateYear() == 0 && this.tDateEdit_YearMonth.GetDateMonth() == 0)
			{
				errMessage = string.Format("印刷範囲年月{0}", ct_NoInputError);
				errComponent = this.tDateEdit_YearMonth;
				status = false;
			}
			else if ((this.tDateEdit_YearMonth.LongDate != 0) && this.tDateEdit_YearMonth.GetDateTime() == DateTime.MinValue)
			{
				errMessage = string.Format("印刷範囲年月{0}", ct_InputError);
				errComponent = this.tDateEdit_YearMonth;
				status = false;
			}
			// 銀行/支店
			else if (this.tNedit_BankCd_St.DataText.TrimEnd() != string.Empty
				|| this.tNedit_BankCd_Ed.DataText.TrimEnd() != string.Empty
				|| this.tNedit_BranchCd_St.DataText.TrimEnd() != string.Empty
				|| this.tNedit_BranchCd_Ed.DataText.TrimEnd() != string.Empty)
			{
				int bankCdSt = this.tNedit_BankCd_St.GetInt() * 1000;
				int branchCdSt = this.tNedit_BranchCd_St.GetInt();
				int bankCdEnd;
				int branchCdEnd;
				if (this.tNedit_BankCd_Ed.DataText.TrimEnd() != string.Empty)
					bankCdEnd = this.tNedit_BankCd_Ed.GetInt() * 1000;
				else
					bankCdEnd = 9999000;

				if (this.tNedit_BranchCd_Ed.DataText.TrimEnd() != string.Empty)
					branchCdEnd = this.tNedit_BranchCd_Ed.GetInt();
				else
					branchCdEnd = 999;

				if (bankCdSt + branchCdSt > bankCdEnd + branchCdEnd)
				{
					errMessage = string.Format("銀行/支店{0}", ct_RangeError);
					if (bankCdSt > bankCdEnd)
						errComponent = this.tNedit_BankCd_Ed;
					else
						errComponent = this.tNedit_BranchCd_Ed;
					status = false;
				}
			}
			else if (!IsDraftKindCdSelected())
			{
				errMessage = string.Format("手形種別{0}", ct_NoInputError);
				errComponent = this.DraftKindCd_ultraTree;
				status = false;
			}
			return status;
		}

		/// <summary>
		/// 手形種別のいずれかを選択されるか
		/// </summary>
		/// <remarks>
		/// <br>Note       : 手形種別のいずれかを選択されるかを判定する</br>
		/// <br>Programmer  : 姜凱</br>
		/// <br>Date        : 2010.05.05</br>
		/// </remarks>
		private bool IsDraftKindCdSelected()
		{
			for (int i = 0; i < this.DraftKindCd_ultraTree.Nodes.Count; i++)
			{
				if (this.DraftKindCd_ultraTree.Nodes[i].CheckedState == CheckState.Checked)
				{
					return true;
				}
			}
			return false;
		}
		#endregion

		#region ◎ 抽出条件設定処理(画面→抽出条件)
		/// <summary>
		/// 抽出条件設定処理(画面→抽出条件)
		/// </summary>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note		: 画面→抽出条件へ設定する。</br>
		/// <br>Programmer  : 姜凱</br>
		/// <br>Date        : 2010.05.05</br>
		/// </remarks>
		private int SetExtraInfoFromScreen()
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
			try
			{
				// 企業コード
				this._tegataTsukibetsuYoteListReport.EnterpriseCode = this._enterpriseCode;
				//手形区分
				this._tegataTsukibetsuYoteListReport.DraftDivide = Convert.ToInt32(this.tComboEditor_DraftDivide.Value);
				// 印刷範囲年月
				int longDate = this.tDateEdit_YearMonth.LongDate;
				longDate = (longDate / 100) * 100 + 1;
				this.tDateEdit_YearMonth.SetLongDate(longDate);
				this._tegataTsukibetsuYoteListReport.SalesDate = this.tDateEdit_YearMonth.GetDateTime();
				//改頁
				this._tegataTsukibetsuYoteListReport.ChangePageDiv = Convert.ToInt32(this.tComboEditor_ChangePg.Value);
				// ソート順
				this._tegataTsukibetsuYoteListReport.SortOrder = Convert.ToInt32(this.tComboEditor_Sort.Value);
				// 銀行/支店開始
				if (this.tNedit_BankCd_St.Text == "" && this.tNedit_BranchCd_St.Text == "")
				{
					this._tegataTsukibetsuYoteListReport.BankAndBranchCdSt = string.Empty;
				}
				else
				{
					this._tegataTsukibetsuYoteListReport.BankAndBranchCdSt = (this.tNedit_BankCd_St.GetInt() * 1000 + this.tNedit_BranchCd_St.GetInt()).ToString("D7");
				}
				// 銀行/支店終了
				if (this.tNedit_BankCd_Ed.Text == "" && this.tNedit_BranchCd_Ed.Text == "")
					this._tegataTsukibetsuYoteListReport.BankAndBranchCdEd = string.Empty;
				else if (this.tNedit_BankCd_Ed.Text != "" && this.tNedit_BranchCd_Ed.Text != "")
					this._tegataTsukibetsuYoteListReport.BankAndBranchCdEd = (this.tNedit_BankCd_Ed.GetInt() * 1000 + this.tNedit_BranchCd_Ed.GetInt()).ToString("D7");
				else if (this.tNedit_BankCd_Ed.Text != "")
					this._tegataTsukibetsuYoteListReport.BankAndBranchCdEd = (this.tNedit_BankCd_Ed.GetInt() * 1000 + 999).ToString("D7");
				else
					this._tegataTsukibetsuYoteListReport.BankAndBranchCdEd = (9999 * 1000 + this.tNedit_BranchCd_Ed.GetInt()).ToString("D7");
				// 手形種別
				// 手形種別ツリー設定 
				SetDraftKindCdList(ref _selectedDraftKindList);
				ArrayList secList = new ArrayList();
				if (this.DraftKindCd_ultraTree.Nodes[0].CheckedState == CheckState.Checked)
				{
					_tegataTsukibetsuYoteListReport.DraftKindCds = new string[0];
				}
				else
				{
					foreach (DictionaryEntry dicEntry in this._selectedDraftKindList)
					{
						if ((CheckState)dicEntry.Value == CheckState.Checked)
						{
							secList.Add(dicEntry.Key);
						}
					}
					_tegataTsukibetsuYoteListReport.DraftKindCds = (string[])secList.ToArray(typeof(string));
				}
				// 手形種別名称の設定
				_tegataTsukibetsuYoteListReport.DraftKindCdsHt = new Hashtable();
				_tegataTsukibetsuYoteListReport.DraftKindCdsHt.Add(0, "手持手形");
				_tegataTsukibetsuYoteListReport.DraftKindCdsHt.Add(1, "取立手形");
				_tegataTsukibetsuYoteListReport.DraftKindCdsHt.Add(2, "割引手形");
				_tegataTsukibetsuYoteListReport.DraftKindCdsHt.Add(3, "譲渡手形");
				_tegataTsukibetsuYoteListReport.DraftKindCdsHt.Add(4, "担保手形");
				_tegataTsukibetsuYoteListReport.DraftKindCdsHt.Add(5, "不渡手形");
				_tegataTsukibetsuYoteListReport.DraftKindCdsHt.Add(6, "支払手形");
				_tegataTsukibetsuYoteListReport.DraftKindCdsHt.Add(7, "先付手形");
				_tegataTsukibetsuYoteListReport.DraftKindCdsHt.Add(9, "決済手形");


			}
			catch (Exception)
			{
				status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
			}
			return status;

		}

		/// <summary>
		/// 手形種別リストの設定
		/// </summary>
		/// <param name="_selectedDraftKindList">手形種別リスト</param>
		/// <remarks>
		/// <br>Note       : 手形種別リストの設定を行う</br>
		/// <br>Programmer : 姜凱</br>
		/// <br>Date       : 2010.05.05</br>
		/// </remarks>
		private void SetDraftKindCdList(ref SortedList _selectedDraftKindList)
		{
			_selectedDraftKindList.Clear();
			for (int i = 0; i < this.DraftKindCd_ultraTree.Nodes.Count; i++)
			{
				if (this.DraftKindCd_ultraTree.Nodes[i].CheckedState == CheckState.Checked)
				{
					_selectedDraftKindList.Add(DraftKindCd_ultraTree.Nodes[i].Key, CheckState.Checked);
				}

			}
		}
		#endregion
		#endregion ◆ 印刷前処理

		#region ◆ エラーメッセージ表示処理 ( +1のオーバーロード )
		#region ◎ エラーメッセージ表示処理
        /// <summary>
        /// エラーメッセージ表示処理
        /// </summary>
        /// <param name="iLevel">エラーレベル</param>
        /// <param name="message">表示メッセージ</param>
        /// <param name="status">ステータス</param>
        /// <remarks>
        /// <br>Note       : エラーメッセージの表示を行います。</br>
        /// <br>Programmer : 姜凱</br>
        /// <br>Date       : 2010.05.05</br>
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
        #endregion ◆ エラーメッセージ表示処理 ( +1のオーバーロード )

        /// <summary>
        /// グループが縮小イベント
        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント情報</param> 
        /// <remarks> 
        /// <br>Note       : グループが縮小される前に発生します。</br> 
        /// <br>Programmer : 姜凱</br>
        /// <br>Date       : 2010.05.05</br>
        /// </remarks>
        private void Main_ultraExplorerBar_GroupCollapsing(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
        {
            if ((e.Group.Key == "ReportSelectGroup") ||
				(e.Group.Key == "SortGroup") || 
                (e.Group.Key == "PrintConditionGroup"))
            {
                // グループの縮小をキャンセル 
                e.Cancel = true;
            }

        }
        
        /// <summary> 
        /// エクスプローラーバー グループ展開 イベント 
        /// </summary> 
        /// <param name="sender">イベントオブジェクト</param> 
        /// <param name="e">イベント情報</param> 
        /// <remarks> 
        /// <br>Note       : グループが展開される前に発生します。</br> 
        /// <br>Programmer : 姜凱</br>
        /// <br>Date       : 2010.05.05</br>
        /// </remarks>
        private void Main_ultraExplorerBar_GroupExpanding(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
        {
            if ((e.Group.Key == "ReportSelectGroup") ||
				(e.Group.Key == "SortGroup") || 
                (e.Group.Key == "PrintConditionGroup"))
            {
                // グループの縮小をキャンセル
                e.Cancel = true;
            }
        }

        #region ◎ オフライン状態チェック処理

        /// <summary>
        /// ログオン時オンライン状態チェック処理
        /// </summary>
        /// <returns>チェック処理結果</returns>
        /// <remarks>
        /// <br>Note		: ログオン時オンライン状態チェック処理を行い</br>
        /// <br>Programmer	: 姜凱</br>
        /// <br>Date		: 2010.05.05</br>
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
        /// <br>Note		: リモート接続可能判定を行い</br>
        /// <br>Programmer	: 姜凱</br>
        /// <br>Date		: 2010.05.05</br>
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

        /// <summary>
        /// UI保存コンポーネント読込みイベント
        /// </summary>
        /// <param name="targetControls">対象Control</param>
        /// <param name="customizeData">customizeData</param>
        /// <remarks>
        /// <br>Note	　 : UI保存コンポーネント読込みイベントを行う</br>
        /// <br>Programmer : 姜凱</br>
        /// <br>Date       : 2010.05.05</br>
        /// </remarks>
        private void uiMemInput1_CustomizeRead(Control[] targetControls, string[] customizeData)
        {
            if (customizeData.Length > 0 && customizeData.Length == 7)
            {
				// 手形区分
				if (customizeData[0] == "0")
				{
					this.tComboEditor_DraftDivide.Value = 0;

				}
				else if (customizeData[0] == "1")
				{
					this.tComboEditor_DraftDivide.Value = 1;
				}
				// 改頁
				if (customizeData[1] == "0")
				{
					this.tComboEditor_ChangePg.Value = 0;

				}
				else if (customizeData[1] == "1")
				{
					this.tComboEditor_ChangePg.Value = 1;
				}
				// 出力順
				if (customizeData[2] == "0")
				{
					this.tComboEditor_Sort.Value = 0;

				}
				else if (customizeData[2] == "1")
				{
					this.tComboEditor_Sort.Value = 1;
				}
				// 銀行/支店
				this.tNedit_BankCd_St.DataText = customizeData[3];
				this.tNedit_BranchCd_St.DataText = customizeData[4];
				this.tNedit_BankCd_Ed.DataText = customizeData[5];
				this.tNedit_BranchCd_Ed.DataText = customizeData[6];

            }
        }

        /// <summary>
        /// UI保存コンポーネント書込みイベント
        /// </summary>
        /// <param name="targetControls">対象Control</param>
        /// <param name="customizeData">customizeData</param>
        /// <remarks>
        /// <br>Note	　 : UI保存コンポーネント書込みイベントを行う</br>
        /// <br>Programmer : 姜凱</br>
        /// <br>Date       : 2010.05.05</br>
        /// </remarks>
        private void uiMemInput1_CustomizeWrite(Control[] targetControls, out string[] customizeData)
        {
			customizeData = new string[7];
			// 手形区分
			if (tComboEditor_DraftDivide.SelectedIndex == 0)
			{
				customizeData[0] = "0";
			}
			else if (tComboEditor_DraftDivide.SelectedIndex == 1)
			{
				customizeData[0] = "1";
			}
			// 改頁
			if (tComboEditor_ChangePg.SelectedIndex == 0)
			{
				customizeData[1] = "0";
			}
			else if (tComboEditor_ChangePg.SelectedIndex == 1)
			{
				customizeData[1] = "1";
			}

			// 出力順
			if (tComboEditor_Sort.SelectedIndex == 0)
			{
				customizeData[2] = "0";
			}
			else if (tComboEditor_Sort.SelectedIndex == 1)
			{
				customizeData[2] = "1";
			}
			// 銀行/支店
			customizeData[3] = this.tNedit_BankCd_St.DataText;
			customizeData[4] = this.tNedit_BranchCd_St.DataText;
			customizeData[5] = this.tNedit_BankCd_Ed.DataText;
			customizeData[6] = this.tNedit_BranchCd_Ed.DataText;
        }

		/// <summary>
		/// 整数値かどうかという判断
		/// </summary>
		/// <param name="num">string</param>
		/// <returns>整数値かどうか</returns>
		/// <remarks>
		/// <br>Note       : 整数値かどうかという判断</br>
		/// <br>Programmer : 姜凱</br>
		/// <br>Date       : 2010.05.05</br>
		/// </remarks>
		private bool IsInteger(string str)
		{
			if (string.IsNullOrEmpty(str) || str.Trim().Length == 0)
			{
				return false;
			}
			return Regex.IsMatch(str, @"^-?\d+$");
		}
        #endregion ■ Private Method

	}
}