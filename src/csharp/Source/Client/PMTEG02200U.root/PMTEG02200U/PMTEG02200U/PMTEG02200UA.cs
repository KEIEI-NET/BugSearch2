//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 手形決済一覧表
// プログラム概要   : 手形決済一覧表情報を抽出し、印刷・PDF出力する
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 葛軍
// 作 成 日  2010/04/28  修正内容 : 新規作成
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

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 手形決済一覧表 入力フォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 手形決済一覧表PDF出力操作を行うクラスです。</br>
    /// <br>Programmer : 葛軍</br>
    /// <br>Date       : 2010.05.05</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public partial class PMTEG02200UA : Form,
                                IPrintConditionInpType,					// 帳票共通（条件入力タイプ）
                                IPrintConditionInpTypePdfCareer			// 帳票業務（条件入力）PDF出力履歴管理
    {
        #region ■ Constructor
        /// <summary>
        /// 帳票共通(条件入力タイプ)フレームクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br>Programmer : 葛軍</br>
        /// <br>Date       : 2010.05.05</br>
        /// </remarks>
        public PMTEG02200UA()
        {
            InitializeComponent();
            // 企業コード取得
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            this._employeeAcs = new EmployeeAcs();
            //日付取得部品
            this._dateGet = DateGetAcs.GetInstance();

        }
        #endregion ■ Constructor

        #region ■ Const Memebers ■
        /// <summary>入金日</summary>
        private const string STR_DEPOSITDATE = "入金日";
        /// <summary>支払日</summary>
        private const string STR_PAYMENTDATE = "支払日";
        /// <summary>チェック時メッセージ「売上月次締日取得の初期処理でエラーが発生しました。」</summary>
        private const string MSG_TOTALDAYREC_INITIALIE_FAILED = "売上月次締日取得の初期処理でエラーが発生しました。";
        /// <summary>チェック時メッセージ「仕入月次締日取得の初期処理でエラーが発生しました。」</summary>
        private const string MSG_TOTALDAYPAY_INITIALIE_FAILED = "仕入月次締日取得の初期処理でエラーが発生しました。";
        #endregion ■ Const Memebers ■

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

        //// 選択手形種別リスト
        //private Hashtable _selectedDraftKindList = new Hashtable();
        #endregion ◆ Interface member

        // 企業コード
        private string _enterpriseCode = string.Empty;

        // 画面イメージコントロール部品
        private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();

        // 抽出条件クラス
        private TegataKessaiReport _tegataKessaiReport;

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

        #endregion ■ Private Member

        #region ■ Private Const
        #region ◆ Interface member
        //--IPrintConditionInpTypePdfCareerのプロパティ用変数 -------------------------
		// クラスID
        private const string ct_ClassID = "PMTEG02200UA";
		// プログラムID
        private const string ct_PGID = "PMTEG02200U";
		//// 帳票名称
        private const string PDF_PRINT_NAME1 = "受取手形決済一覧表";
        private const string PDF_PRINT_NAME2 = "支払手形決済一覧表";
		private string _printName = string.Empty;
        // 帳票キー	
        private const string PDF_PRINT_KEY = "bf814cb3-97d8-4836-a2bd-618e232b300f";
        
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
        /// <br>Programmer  : 葛軍</br>
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
        /// <br>Programmer  : 葛軍</br>
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
        /// <br>Programmer  : 葛軍</br>
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
                    "手形決済一覧表データ読み込みに失敗しました。",
                    (int)ConstantManagement.DB_Status.ctDB_OFFLINE, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                return -1;
            }
            // 帳票選択ガイド
            SFCMN06001U printDialog = new SFCMN06001U();
            // 印刷情報パラメータ
            SFCMN06002C printInfo = parameter as SFCMN06002C;	

            // 画面→抽出条件クラス
            int status = this.SetExtraInfoFromScreen();
            if (status != 0)
            {
                return -1;
            }

            // 企業コードをセット
            printInfo.enterpriseCode = this._enterpriseCode;
            // 起動PGID
            printInfo.kidopgid = ct_PGID;				

            // PDF出力履歴用
            printInfo.key = this._printKey;
            if (this._tegataKessaiReport.DraftDivide == 0)
                this._printName = PDF_PRINT_NAME1;
            else
                this._printName = PDF_PRINT_NAME2;
            printInfo.prpnm = this._printName;

            // 四つテンプレートの選択
            if (this._tegataKessaiReport.DraftDivide == 0)
            {
                if (this._tegataKessaiReport.SortOrder == 0)
                    printInfo.PrintPaperSetCd = 0;
                else
                    printInfo.PrintPaperSetCd = 1;
            }
            else
            {
                if (this._tegataKessaiReport.SortOrder == 0)
                    printInfo.PrintPaperSetCd = 3;
                else
                    printInfo.PrintPaperSetCd = 4;
            }

            // 抽出条件の設定
            printInfo.jyoken = this._tegataKessaiReport;
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
        /// <br>Programmer  : 葛軍</br>
        /// <br>Date        : 2010.05.05</br>
        /// </remarks>
        public void Show(object parameter)
        {
            this._tegataKessaiReport = new TegataKessaiReport();
            this.Show();

            return;
        }
        #endregion

        #endregion ◆ Public Method

        #endregion ■ IPrintConditionInpType メンバ

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
        #region ◆ PMTEG02200UA
        #region ◎ PMTEG02200UA_Load Event
        /// <summary>
        /// PMTEG02200UA_Load Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: ユーザーがﾌｫｰﾑを読み込むときに発生する</br>
        /// <br>Programmer  : 葛軍</br>
        /// <br>Date        : 2010.05.05</br>
        /// </remarks>
        private void PMTEG02200UA_Load(object sender, EventArgs e)
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
            // 買掛無の場合、初期フォーカスは 入金日とし、手形区分は入力不可（グレーアウト）とする。
            else
            {
                this.tDateEdit_DepositDate_St.Focus();
                _prevControl = tDateEdit_DepositDate_St;
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
        /// <br>Programmer  : 葛軍</br>
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
                        // 手形区分→入金日(開始)
                        e.NextCtrl = this.tDateEdit_DepositDate_St;
                    }
                    else if (e.PrevCtrl == this.tDateEdit_DepositDate_St)
                    {
                        // 入金日(開始)→入金日(終了)
                        e.NextCtrl = this.tDateEdit_DepositDate_Ed;
                    }
                    else if (e.PrevCtrl == this.tDateEdit_DepositDate_Ed)
                    {
                        // 入金日(終了)→満期日（開始）
                        e.NextCtrl = this.tDateEdit_MaturityDate_St;
                    }
                    else if (e.PrevCtrl == this.tDateEdit_MaturityDate_St)
                    {
                        // 満期日（開始）→満期日（終了）
                        e.NextCtrl = this.tDateEdit_MaturityDate_Ed;
                    }
                    else if (e.PrevCtrl == this.tDateEdit_MaturityDate_Ed)
                    {
                        // 満期日（終了）→出力順
                        e.NextCtrl = this.tComboEditor_Sort;
                    }
                    else if (e.PrevCtrl == this.tComboEditor_Sort)
                    {
                        // 出力順→銀行コード開始
                        e.NextCtrl = this.tNedit_BankCd_St;
                    }
                    else if (e.PrevCtrl == this.tNedit_BankCd_St)
                    {
                        // 銀行コード開始→支店コード開始
                        e.NextCtrl = this.tNedit_BranchCd_St;

                    }
                    else if (e.PrevCtrl == this.tNedit_BranchCd_St)
                    {
                        // 支店コード開始→銀行ガイド開始
                        e.NextCtrl = this.ub_St_BankBranchCd;

                    }
                    else if (e.PrevCtrl == this.ub_St_BankBranchCd)
                    {
                        // 支店コード開始→銀行コード終了
                        e.NextCtrl = this.tNedit_BankCd_Ed;

                    }
                    else if (e.PrevCtrl == this.tNedit_BankCd_Ed)
                    {
                        // 銀行コード終了→支店コード終了
                        e.NextCtrl = this.tNedit_BranchCd_Ed;

                    }
                    else if (e.PrevCtrl == this.tNedit_BranchCd_Ed)
                    {
                        // 支店コード終了→銀行ガイド終了
                        e.NextCtrl = this.ub_Ed_BankBranchCd;
                    }
                }
            }
            else
            {
                // SHIFTキー押下
                if (e.Key == Keys.Tab)
                {
                    if (e.PrevCtrl == this.ub_Ed_BankBranchCd)
                    {
                        // 銀行ガイド終了→支店コード終了
                        e.NextCtrl = this.tNedit_BranchCd_Ed;
                    }
                    else if (e.PrevCtrl == this.tNedit_BranchCd_Ed)
                    {
                        // 支店コード終了→銀行コード終了
                        e.NextCtrl = this.tNedit_BankCd_Ed;
                    }
                    else if (e.PrevCtrl == this.tNedit_BankCd_Ed)
                    {
                        // 銀行コード終了→銀行ガイド開始
                        e.NextCtrl = this.ub_St_BankBranchCd;
                    }
                    else if (e.PrevCtrl == this.ub_St_BankBranchCd)
                    {
                        // 銀行ガイド開始→支店コード開始
                        e.NextCtrl = this.tNedit_BranchCd_St;
                    }
                    else if (e.PrevCtrl == this.tNedit_BranchCd_St)
                    {
                        //支店コード開始→銀行コード開始
                        e.NextCtrl = this.tNedit_BankCd_St;
                    }
                    else if (e.PrevCtrl == this.tNedit_BankCd_St)
                    {
                        // 銀行コード開始→出力順
                        e.NextCtrl = this.tComboEditor_Sort;
                    }
                    else if (e.PrevCtrl == this.tComboEditor_Sort)
                    {
                        // 出力順→満期日（終了）
                        e.NextCtrl = this.tDateEdit_MaturityDate_Ed;
                    }
                    else if (e.PrevCtrl == this.tDateEdit_MaturityDate_Ed)
                    {
                        // 満期日（終了）→満期日（開始）
                        e.NextCtrl = this.tDateEdit_MaturityDate_St;
                    }
                    else if (e.PrevCtrl == this.tDateEdit_MaturityDate_St)
                    {
                        // 満期日（開始）→入金日(終了)
                        e.NextCtrl = this.tDateEdit_DepositDate_Ed;
                    }
                    else if (e.PrevCtrl == this.tDateEdit_DepositDate_Ed)
                    {
                        // 入金日(終了)→入金日(開始)
                        e.NextCtrl = this.tDateEdit_DepositDate_St;
                    }
                    else if (e.PrevCtrl == this.tDateEdit_DepositDate_St)
                    {
                        // 入金日(開始)→手形区分
                        e.NextCtrl = this.tComboEditor_DraftDivide;
                    }

                }
            }
        }
        #endregion

        #endregion ◆ PMTEG02200UA

        # region ■ ガイドボタンクリックイベント
        /// <summary>
        /// 銀行/支店ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks> 
        /// <br>Note       : 銀行/支店ガイドをクリックするときに発生する</br> 
        /// <br>Programmer : 葛軍</br>                                  
        /// <br>Date       : 2010.05.05</br> 
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
                    this.tNedit_BranchCd_Ed.Focus();
                }
            }
        }

        /// <summary>
        /// 仕入先ガイド選択イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <remarks> 
        /// <br>Note       : 仕入先ガイドをクリックするときに発生する</br> 
        /// <br>Programmer : 葛軍</br>                                  
        /// <br>Date       : 2010.05.05</br> 
        /// </remarks>
        private void SearchForm_BankBranchSelect(object sender)
        {
            // ガイド起動
            UserGdHd userGdHd;
            UserGdBd userGdBd;
            UserGuideAcs userGuideAcs = new UserGuideAcs();

            int status = userGuideAcs.ExecuteGuid(this._enterpriseCode, out userGdHd, out userGdBd, 46);

            if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL) return;
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

        /// <summary>
        /// tComboEditor_DraftDivide_ValueChanged イベント処理イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : 手形区分変更ときに発生します。</br>      
        /// <br>Programmer : 葛軍</br>                                  
        /// <br>Date       : 2010.05.05</br> 
        /// </remarks> 
        private void tComboEditor_DraftDivide_ValueChanged(object sender, EventArgs e)
        {

            // ・手形区分が「受取手形」の時　：　出力順の選択項目にある日付項目を「入金日」に変更する。
            if ((int)this.tComboEditor_DraftDivide.SelectedIndex == 0)
            {
                this.tComboEditor_Sort.Items.Clear();
                this.tComboEditor_Sort.Items.Add(0, "銀行/支店＋入金日＋満期日");
                this.tComboEditor_Sort.Items.Add(1, "満期日＋銀行/支店＋入金日");
                this.tComboEditor_Sort.SelectedIndex = 0;
                // 手形区分「受取手形」を選択時は、日付項目のタイトルを「入金日」に変更する。
                this.Lbl_DepositDate.Text = STR_DEPOSITDATE;
            }
            // ・手形区分が「支払手形」の時　：　出力順の選択項目にある日付項目を「支払日」に変更する。
            else
            {
                this.tComboEditor_Sort.Items.Clear();
                this.tComboEditor_Sort.Items.Add(0, "銀行/支店＋支払日＋満期日");
                this.tComboEditor_Sort.Items.Add(1, "満期日＋銀行/支店＋支払日");
                this.tComboEditor_Sort.SelectedIndex = 0;
                // 手形区分「支払手形」を選択時は、日付項目のタイトルを「支払日」に変更する。
                this.Lbl_DepositDate.Text = STR_PAYMENTDATE;
            }

            //開始入金日と開始満期日取得初期処理
            GetHisTotalDayProc();
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
        /// <br>Programmer  : 葛軍</br>
        /// <br>Date        : 2010.05.05</br>
        /// </remarks>
        private int InitializeScreen(out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            errMsg = string.Empty;
            
            try
            {
                // 手形区分
                this.tComboEditor_DraftDivide.Items.Clear();
                this.tComboEditor_DraftDivide.Items.Add(0, "受取手形");
                this.tComboEditor_DraftDivide.Items.Add(1, "支払手形");

                // 入金日
                TotalDayCalculator totalDayCalculator = TotalDayCalculator.GetInstance();

                // 入金日(開始)と満期日(開始)取得初期処理
                GetHisTotalDayProc();

                // 入金日(終了)を設定：システム日付
                this.tDateEdit_DepositDate_Ed.SetDateTime(DateTime.Now);
                // 満期日(終了)を設定：システム日付
                this.tDateEdit_MaturityDate_Ed.SetDateTime(DateTime.Now);

                // 出力順
                if (this.tComboEditor_Sort.Value == null)
                {
                    this.tComboEditor_Sort.Value = 0;   // DEF:0:「銀行/支店＋入金日＋満期日」
                }
                // 手形区分
                if (this.tComboEditor_DraftDivide.Value == null)
                {
                    this.tComboEditor_DraftDivide.Value = 0;   // DEF:0:受取手形
                }

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

        #region ■ 前回月次更新日取得初期処理 ■
        /// <summary>
        /// 開始入金日と開始満期日取得初期処理
        /// </summary>
        /// <returns>システム日付</returns>
        /// <remarks>
        /// <br>Note       : 入金日と満期日取得初期処理です。</br>
        /// <br>Programmer : 葛軍</br>
        /// <br>Date       : 2010.05.05</br>
        /// </remarks>
        private void GetHisTotalDayProc()
        {
            int status;

            TotalDayCalculator totalDayCalculator = TotalDayCalculator.GetInstance();
            DateTime prevTotalDay;
            DateTime currentTotalDay;
            //前回月次更新日
            DateTime prevTotalMonth;
            DateTime currentTotalMonth;

            // 前回月次更新日取得前初期処理
            status = totalDayCalculator.InitializeHisMonthlyAccRec();

            int billDivIndex = this.tComboEditor_DraftDivide.SelectedIndex;

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // 今回および前回の締め日/月を取得(月と日は異なる場合がある)
                //受取手形
                if (billDivIndex == 0)
                {
                    status = totalDayCalculator.GetHisTotalDayMonthlyAccRec(LoginInfoAcquisition.Employee.BelongSectionCode, out prevTotalDay, out currentTotalDay, out prevTotalMonth, out currentTotalMonth);
                }
                else
                {
                    status = totalDayCalculator.GetHisTotalDayMonthlyAccPay(LoginInfoAcquisition.Employee.BelongSectionCode, out prevTotalDay, out currentTotalDay, out prevTotalMonth, out currentTotalMonth);
                }

                if (prevTotalDay == DateTime.MinValue)
                {

                    // 入金日(開始)を設定：システム日付
                    this.tDateEdit_DepositDate_St.SetDateTime(DateTime.Now);
                    // 入金日(開始)を設定：システム日付
                    this.tDateEdit_MaturityDate_St.SetDateTime(DateTime.Now);
                }
                else
                {
                    // 売上今回月次更新日を設定
                    // 入金日(開始)を設定：前回月次更新日の翌日
                    this.tDateEdit_DepositDate_St.SetDateTime(prevTotalDay.AddDays(1));
                    // 満期日(開始)を設定：前回月次更新日の翌日
                    this.tDateEdit_MaturityDate_St.SetDateTime(prevTotalDay.AddDays(1));
                }
            }
            else
            {
                // 初期処理失敗
                // 受取手形
                if (billDivIndex == 0)
                {
                    TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Name,
                        MSG_TOTALDAYREC_INITIALIE_FAILED, -1, MessageBoxButtons.OK);
                }
                else
                {
                    TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Name,
                        MSG_TOTALDAYPAY_INITIALIE_FAILED, -1, MessageBoxButtons.OK);
                }
            }
        }
        #endregion
        #endregion

        #region ◎ ボタンアイコン設定処理
        /// <summary>
        /// ボタンアイコン設定処理
        /// </summary>
        /// <param name="settingControl">アイコンセットするコントロール</param>
        /// <param name="iconIndex">アイコンインデックス</param>
        /// <remarks>
        /// <br>Note		: ボタンアイコンを設定する</br>
        /// <br>Programmer  : 葛軍</br>
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
        /// <br>Programmer  : 葛軍</br>
        /// <br>Date        : 2010.05.05</br>
        /// </remarks>
        private bool ScreenInputCheck(ref string errMessage, ref Control errComponent)
        {
            const string ct_RangeError = "の範囲指定に誤りがあります。";
            const string ct_InputError = "の入力が不正です。";

            bool status = true;
            string dateStr = null;
            // 受取手形
            if (this.tComboEditor_DraftDivide.SelectedIndex == 0)
                dateStr = STR_DEPOSITDATE;
            // 支払手形
            else
                dateStr = STR_PAYMENTDATE;

            // 入金日/支払日
            if ((this.tDateEdit_DepositDate_St.LongDate != 0) && this.tDateEdit_DepositDate_St.GetDateTime() == DateTime.MinValue)
            {
                errMessage = string.Format("開始日{0}", ct_InputError);
                errComponent = this.tDateEdit_DepositDate_St;
                status = false;
            }
            else if ((this.tDateEdit_DepositDate_Ed.LongDate != 0) && this.tDateEdit_DepositDate_Ed.GetDateTime() == DateTime.MinValue)
            {
                errMessage = string.Format("終了日{0}", ct_InputError);
                errComponent = this.tDateEdit_DepositDate_Ed;
                status = false;
            }
            else if (this.tDateEdit_DepositDate_St.LongDate != 0 && this.tDateEdit_DepositDate_Ed.LongDate != 0 &&
                !DateGetAcs.CheckDateRangeResult.OK.Equals(this._dateGet.CheckDateRange(DateGetAcs.YmdType.YearMonthDay, 0, ref this.tDateEdit_DepositDate_St, ref this.tDateEdit_DepositDate_Ed, false)))
            {

                errMessage = string.Format(dateStr + "{0}", ct_RangeError);
                errComponent = this.tDateEdit_DepositDate_Ed;
                status = false;
            }
            // 満期日
            else if ((this.tDateEdit_MaturityDate_St.LongDate != 0) && this.tDateEdit_MaturityDate_St.GetDateTime() == DateTime.MinValue)
            {
                errMessage = string.Format("開始日{0}", ct_InputError);
                errComponent = this.tDateEdit_MaturityDate_St;
                status = false;
            }
            else if ((this.tDateEdit_MaturityDate_Ed.LongDate != 0) && this.tDateEdit_MaturityDate_Ed.GetDateTime() == DateTime.MinValue)
            {
                errMessage = string.Format("終了日{0}", ct_InputError);
                errComponent = this.tDateEdit_MaturityDate_Ed;
                status = false;
            }
            else if (
                this.tDateEdit_MaturityDate_St.LongDate != 0 &&
                this.tDateEdit_MaturityDate_Ed.LongDate != 0 &&
                !DateGetAcs.CheckDateRangeResult.OK.Equals(this._dateGet.CheckDateRange(DateGetAcs.YmdType.YearMonthDay, 0, ref this.tDateEdit_MaturityDate_St, ref this.tDateEdit_MaturityDate_Ed, false)))
            {
                errMessage = string.Format("満期日{0}", ct_RangeError);
                errComponent = this.tDateEdit_MaturityDate_Ed;
                status = false;
            }
            // 銀行/支店
            else
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
            return status;
        }

        #endregion

        #region ◎ 抽出条件設定処理(画面→抽出条件)
        /// <summary>
        /// 抽出条件設定処理(画面→抽出条件)
        /// </summary>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note		: 画面→抽出条件へ設定する。</br>
        /// <br>Programmer  : 葛軍</br>
        /// <br>Date        : 2010.05.05</br>
        /// </remarks>
        private int SetExtraInfoFromScreen()
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            try
            {
                // 企業コード
                this._tegataKessaiReport.EnterpriseCode = this._enterpriseCode;
                // 入金日
                this._tegataKessaiReport.DateSt = this.tDateEdit_DepositDate_St.GetDateTime();
                this._tegataKessaiReport.DateEd = this.tDateEdit_DepositDate_Ed.GetDateTime();

                // 満期日
                this._tegataKessaiReport.MaturityDateSt = this.tDateEdit_MaturityDate_St.GetDateTime();
                this._tegataKessaiReport.MaturityDateEd = this.tDateEdit_MaturityDate_Ed.GetDateTime();

                //手形区分
                this._tegataKessaiReport.DraftDivide = Convert.ToInt32(this.tComboEditor_DraftDivide.Value);

                // ソート順
                this._tegataKessaiReport.SortOrder = Convert.ToInt32(this.tComboEditor_Sort.Value);

                // 銀行/支店開始
                if (this.tNedit_BankCd_St.Text == "" && this.tNedit_BranchCd_St.Text == "")
                {
                    this._tegataKessaiReport.BankAndBranchCdSt = string.Empty;
                }
                else
                {
                    this._tegataKessaiReport.BankAndBranchCdSt = (this.tNedit_BankCd_St.GetInt() * 1000 + this.tNedit_BranchCd_St.GetInt()).ToString("D7");
                }

                // 銀行/支店終了
                if (this.tNedit_BankCd_Ed.Text == "" && this.tNedit_BranchCd_Ed.Text == "")
                    this._tegataKessaiReport.BankAndBranchCdEd = string.Empty;
                else if (this.tNedit_BankCd_Ed.Text != "" && this.tNedit_BranchCd_Ed.Text != "")
                    this._tegataKessaiReport.BankAndBranchCdEd = (this.tNedit_BankCd_Ed.GetInt() * 1000 + this.tNedit_BranchCd_Ed.GetInt()).ToString("D7");
                else if (this.tNedit_BankCd_Ed.Text != "")
                    this._tegataKessaiReport.BankAndBranchCdEd = (this.tNedit_BankCd_Ed.GetInt() * 1000 + 999).ToString("D7");
                else
                    this._tegataKessaiReport.BankAndBranchCdEd = (9999 * 1000 + this.tNedit_BranchCd_Ed.GetInt()).ToString("D7");

            }
            catch (Exception)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            return status;
            
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
        /// <br>Programmer : 葛軍</br>
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
        /// <br>Programmer : 葛軍</br>
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
        /// <br>Programmer : 葛軍</br>
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
        /// <br>Programmer	: 葛軍</br>
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
        /// <br>Programmer	: 葛軍</br>
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
        /// <br>Programmer : 葛軍</br>
        /// <br>Date       : 2010.05.05</br>
        /// </remarks>
        private void uiMemInput1_CustomizeRead(Control[] targetControls, string[] customizeData)
        {
            if (customizeData.Length > 0 && customizeData.Length == 5)
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
                // 出力順
                if (customizeData[1] == "0")
                {
                    this.tComboEditor_Sort.Value = 0;
                }
                else
                {
                    this.tComboEditor_Sort.Value = 1;
                }

                // 銀行/支店
                this.tNedit_BankCd_St.DataText = customizeData[2];
                this.tNedit_BranchCd_St.DataText = customizeData[3];
                this.tNedit_BankCd_Ed.DataText = customizeData[4];
                this.tNedit_BranchCd_Ed.DataText = customizeData[5];
            }
        }

        /// <summary>
        /// UI保存コンポーネント書込みイベント
        /// </summary>
        /// <param name="targetControls">対象Control</param>
        /// <param name="customizeData">customizeData</param>
        /// <remarks>
        /// <br>Note	　 : UI保存コンポーネント書込みイベントを行う</br>
        /// <br>Programmer : 葛軍</br>
        /// <br>Date       : 2010.05.05</br>
        /// </remarks>
        private void uiMemInput1_CustomizeWrite(Control[] targetControls, out string[] customizeData)
        {
            customizeData = new string[6];
            // 手形区分
            if (tComboEditor_DraftDivide.SelectedIndex == 0)
            {
                customizeData[0] = "0";
            }
            else if (tComboEditor_DraftDivide.SelectedIndex == 1)
            {
                customizeData[0] = "1";
            }   
            // 出力順
            if (tComboEditor_Sort.SelectedIndex == 0)
            {
               customizeData[1] = "0";
            }
            else
            {
                customizeData[1] = "1";
            }
            
　　　　　　// 銀行/支店
            customizeData[2] = this.tNedit_BankCd_St.DataText;
            customizeData[3] = this.tNedit_BranchCd_St.DataText;
            customizeData[4] = this.tNedit_BankCd_Ed.DataText;
            customizeData[5] = this.tNedit_BranchCd_Ed.DataText;
        }
        #endregion ■ Private Method

    }
}