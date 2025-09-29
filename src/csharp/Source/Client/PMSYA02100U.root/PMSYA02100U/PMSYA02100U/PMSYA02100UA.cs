//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 当月車検車輌一覧表
// プログラム概要   : 当月車検車輌一覧表情報を抽出し、印刷・PDF出力する
//----------------------------------------------------------------------------//
//                (c)Copyright  2001 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 薛祺
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
    /// 当月車検車輌一覧表 入力フォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 当月車検車輌一覧表PDF出力操作を行うクラスです。</br>
    /// <br>Programmer : 薛祺</br>
    /// <br>Date       : 2010.04.21</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public partial class PMSYA02100UA : Form,
                                IPrintConditionInpType,					// 帳票共通（条件入力タイプ）
                                IPrintConditionInpTypeSelectedSection,	// 帳票業務（条件入力）拠点選択
                                IPrintConditionInpTypePdfCareer			// 帳票業務（条件入力）PDF出力履歴管理
    {
        #region ■ Constructor
        /// <summary>
        /// 帳票共通(条件入力タイプ)フレームクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br>Programmer : 薛祺</br>
        /// <br>Date       : 2010.04.21</br>
        /// </remarks>
        public PMSYA02100UA()
        {
            InitializeComponent();
            // 企業コード取得
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            this._employeeAcs = new EmployeeAcs();
            //日付取得部品
            this._dateGet = DateGetAcs.GetInstance();
            // 管理番号ガイド
            this._carMngInputAcs = CarMngInputAcs.GetInstance();
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

        //--IPrintConditionInpTypeSelectedSectionのプロパティ用変数 -------------------
        // 計上拠点選択表示取得プロパティ
        private bool _visibledSelectAddUpCd = false;
        // 拠点オプション有無
        private bool _isOptSection = false;
        // 本社機能有無
        private bool _isMainOfficeFunc = false;
        // 選択拠点リスト
        private Hashtable _selectedSectionList = new Hashtable();
        #endregion ◆ Interface member

        // 企業コード
        private string _enterpriseCode = string.Empty;

        // 画面イメージコントロール部品
        private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();

        // 抽出条件クラス
        private MonthCarInspectListPara _monthCarInspectListPara;

        // ガイド系アクセスクラス
        private EmployeeAcs _employeeAcs;

        // 日付取得部品
        private DateGetAcs _dateGet;
        
        // 管理番号ガイド
        private CarMngInputAcs _carMngInputAcs;

        // フォーカスControl
        private Control _prevControl = null;

        // チェックエラー
        private bool hasCheckError = false;

        // 得意先ガイド結果OKフラグ
        private bool _customerGuideOK;

        // 得意先ガイド用
        private UltraButton _customerGuideSender;


        #endregion ■ Private Member

        #region ■ Private Const
        #region ◆ Interface member
        //--IPrintConditionInpTypePdfCareerのプロパティ用変数 -------------------------
		// クラスID
        private const string ct_ClassID = "PMSYA02100UA";
		// プログラムID
        private const string ct_PGID = "PMSYA02100U";
		//// 帳票名称
        private const string PDF_PRINT_NAME = "当月車検車輌一覧表";
		private string _printName = PDF_PRINT_NAME;
        // 帳票キー	
        private const string PDF_PRINT_KEY = "e079661c-2117-4b46-a0fc-5118082d9456";
        //全社
        private const string ct_All = "00";
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
        /// <br>Programmer  : 薛祺</br>
        /// <br>Date        : 2010.04.21</br>
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
        /// <br>Programmer  : 薛祺</br>
        /// <br>Date        : 2010.04.21</br>
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
        /// <br>Programmer  : 薛祺</br>
        /// <br>Date        : 2010.04.21</br>
        /// </remarks>
        public int Print(ref object parameter)
        {

            // オフライン状態チェック	
            if (!CheckOnline())
            {
                TMsgDisp.Show(
                    emErrorLevel.ERR_LEVEL_STOP,
                    this.Text,
                    "当月車検車輌一覧表データ読み込みに失敗しました。",
                    (int)ConstantManagement.DB_Status.ctDB_OFFLINE, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                return -1;
            }

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
            printInfo.jyoken = this._monthCarInspectListPara;
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
        /// <br>Programmer  : 薛祺</br>
        /// <br>Date        : 2010.04.21</br>
        /// </remarks>
        public void Show(object parameter)
        {
            this._monthCarInspectListPara = new MonthCarInspectListPara();

            // 引数型チェック
            this.Show();

            return;
        }
        #endregion

        #endregion ◆ Public Method

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
        /// <br>Programmer  : 薛祺</br>
        /// <br>Date        : 2010.04.21</br>
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
                    this._selectedSectionList.Add(sectionCode, checkState);
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
        /// <br>Programmer  : 薛祺</br>
        /// <br>Date        : 2010.04.21</br>
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
        /// <br>Programmer  : 薛祺</br>
        /// <br>Date        : 2010.04.21</br>
        /// </remarks>
        public void InitSelectSection(string[] sectionCodeLst)
        {
            // 選択リスト初期化
            this._selectedSectionList.Clear();
            foreach (string wk in sectionCodeLst)
            {
                this._selectedSectionList.Add(wk, CheckState.Checked);
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
        /// <br>Programmer  : 薛祺</br>
        /// <br>Date        : 2010.04.21</br>
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
        /// <param name="addUpCd">addUpCd</param>
        /// <remarks>
        /// <br>Note		: 未実装</br>
        /// <br>Programmer  : 薛祺</br>
        /// <br>Date        : 2010.04.21</br>
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
        #region ◆ PMSYA02100UA
        #region ◎ PMSYA02100UA_Load Event
        /// <summary>
        /// PMSYA02100UA_Load Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: ユーザーがﾌｫｰﾑを読み込むときに発生する</br>
        /// <br>Programmer  : 薛祺</br>
        /// <br>Date        : 2010.04.21</br>
        /// </remarks>
        private void PMSYA02100UA_Load(object sender, EventArgs e)
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
            //this.Cursor = Cursors.WaitCursor;
            //this.tComboEditor_ChangePg.Focus();
            //_prevControl = tComboEditor_ChangePg;
            //this.Cursor = Cursors.Default;

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
        /// <br>Programmer  : 薛祺</br>
        /// <br>Date        : 2010.04.21</br>
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (!e.ShiftKey)
            {
                // SHIFTキー未押下
                if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                {
                    if (e.PrevCtrl == this.tDateEdit_YearMonth)
                    {
                        // 処理月→改行
                        e.NextCtrl = this.uos_NewRowDiv;
                    }
                    else if (e.PrevCtrl == this.uos_NewRowDiv)
                    {
                        // 改行→改頁
                        e.NextCtrl = this.uos_NewPageDiv;
                    }
                    else if (e.PrevCtrl == this.uos_NewPageDiv)
                    {
                        // 改頁→得意先(開始)
                        e.NextCtrl = this.tNedit_CustomerCode_St;
                    }
                    else if (e.PrevCtrl == this.tNedit_CustomerCode_St)
                    {
                        // 得意先(開始)→得意先(終了)
                        e.NextCtrl = this.tNedit_CustomerCode_Ed;
                    }
                    else if (e.PrevCtrl == this.tNedit_CustomerCode_Ed)
                    {
                        // 得意先(終了)→管理番号(開始)
                        e.NextCtrl = this.tEdit_CarMngCode_St;
                    }
                    else if (e.PrevCtrl == this.tEdit_CarMngCode_St)
                    {
                        // 管理番号(開始)→管理番号(終了)
                        e.NextCtrl = this.tEdit_CarMngCode_Ed;
                    }
                    else if (e.PrevCtrl == this.tEdit_CarMngCode_Ed)
                    {
                        // 管理番号(終了)→処理月
                        e.NextCtrl = this.tDateEdit_YearMonth;
                    }
                }
            }
            else
            {
                // SHIFTキー押下
                if (e.Key == Keys.Tab)
                {
                    if (e.PrevCtrl == this.tEdit_CarMngCode_Ed)
                    {
                        // 管理番号(終了)→管理番号(開始)
                        e.NextCtrl = this.tEdit_CarMngCode_St;
                    }
                    else if (e.PrevCtrl == this.tEdit_CarMngCode_St)
                    {
                        // 管理番号(開始)→得意先(終了)
                        e.NextCtrl = this.tNedit_CustomerCode_Ed;
                    }
                    else if (e.PrevCtrl == this.tNedit_CustomerCode_Ed)
                    {
                        // 得意先(終了)→得意先(開始)
                        e.NextCtrl = this.tNedit_CustomerCode_St;
                    }
                    else if (e.PrevCtrl == this.tNedit_CustomerCode_St)
                    {
                        // 得意先(開始)→改頁
                        e.NextCtrl = this.uos_NewPageDiv;
                    }
                    else if (e.PrevCtrl == this.uos_NewPageDiv)
                    {
                        // 改頁→改行
                        e.NextCtrl = this.uos_NewRowDiv;
                    }
                    if (e.PrevCtrl == this.uos_NewRowDiv)
                    {
                        // 改行→処理月
                        e.NextCtrl = this.tDateEdit_YearMonth;
                    }
                    if (e.PrevCtrl == this.tDateEdit_YearMonth)
                    {
                        // 処理月→管理番号(終了)
                        e.NextCtrl = this.tEdit_CarMngCode_Ed;
                    }
                }
            }
        }
        #endregion

        #endregion ◆ PMSYA02100UA

        # region ■ ガイドボタンクリックイベント
        /// <summary>
        /// 得意先ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks> 
        /// <br>Note       : 得意先ガイドをクリックするときに発生する</br> 
        /// <br>Programmer : 薛祺</br>                                  
        /// <br>Date       : 2010.04.21</br> 
        /// </remarks>
        private void ub_St_CustomerCode_Click(object sender, EventArgs e)
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
                if (sender == ub_St_CustomerCode)
                {
                    this.tNedit_CustomerCode_Ed.Focus();
                }
                else
                {
                    this.tEdit_CarMngCode_St.Focus();
                }
            }

        }

        /// <summary>
        /// 得意先ガイド選択イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="customerSearchRet">customerSearchRet</param>
        /// <remarks> 
        /// <br>Note       : 得意先ガイドをクリックするときに発生する</br> 
        /// <br>Programmer : 薛祺</br>                                  
        /// <br>Date       : 2010.04.21</br> 
        /// </remarks>
        void customerSearchForm_CustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        {
            if (customerSearchRet == null) return;

            // ガイド起動
            CustomerInfo customerInfo;
            CustomerInfoAcs customerInfoAcs = new CustomerInfoAcs();

            int status = customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, customerSearchRet.EnterpriseCode, customerSearchRet.CustomerCode, true, out customerInfo);
            if (status != 0) return;
            // 項目に展開
            if (_customerGuideSender == this.ub_St_CustomerCode)
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
        /// 管理番号ガイド イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : 管理番号ガイドボタンがクリックされた時に発生します。</br>
        /// <br>Programmer  : 薛祺</br>
        /// <br>Date        : 2010.04.21</br>
        /// </remarks>
        private void ub_St_CarMngNoGuide_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                CarMangInputExtraInfo selectedInfo = new CarMangInputExtraInfo();
                CarMngGuideParamInfo paramInfo = new CarMngGuideParamInfo();
                paramInfo.EnterpriseCode = this._enterpriseCode;
                // 「新規登録」行表示なし
                paramInfo.IsDispNewRow = false;
                // 得意先表示あり
                paramInfo.IsDispCustomerInfo = true;
                // 得意先コード絞り込み無し
                paramInfo.IsCheckCustomerCode = false;
                // 管理番号絞り込み無し
                paramInfo.IsCheckCarMngCode = false;
                paramInfo.IsGuideClick = true;

                int status = this._carMngInputAcs.ExecuteGuid(paramInfo, out selectedInfo);
                if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    if (selectedInfo.CarMngCode != "新規登録")
                    {
                        this.tEdit_CarMngCode_St.Text = selectedInfo.CarMngCode;
                        this.tEdit_CarMngCode_Ed.Focus();
                    }
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// 管理番号ガイド イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : 管理番号ガイドボタンがクリックされた時に発生します。</br>
        /// <br>Programmer  : 薛祺</br>
        /// <br>Date        : 2010.04.21</br>
        /// </remarks>
        private void ub_Ed_CarMngNoGuide_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                CarMangInputExtraInfo selectedInfo = new CarMangInputExtraInfo();
                CarMngGuideParamInfo paramInfo = new CarMngGuideParamInfo();
                paramInfo.EnterpriseCode = this._enterpriseCode;
                // 「新規登録」行表示なし
                paramInfo.IsDispNewRow = false;
                // 得意先表示あり
                paramInfo.IsDispCustomerInfo = true;
                // 得意先コード絞り込み無し
                paramInfo.IsCheckCustomerCode = false;
                // 管理番号絞り込み無し
                paramInfo.IsCheckCarMngCode = false;
                paramInfo.IsGuideClick = true;

                int status = this._carMngInputAcs.ExecuteGuid(paramInfo, out selectedInfo);
                if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    if (selectedInfo.CarMngCode != "新規登録")
                    {
                        this.tEdit_CarMngCode_Ed.Text = selectedInfo.CarMngCode;
                        this.tDateEdit_YearMonth.Focus();
                    }
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        #endregion ■ ガイドボタンクリックイベント

        #region ■ フォーカスアウト
        /// <summary>
        /// AfterExitEditMode イベント処理イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : 得意先コード開始フォーカスが離れたときに発生します。</br>      
        /// <br>Programmer : 薛祺</br>                                  
        /// <br>Date       : 2010.04.21</br> 
        /// </remarks> 
        private void tNedit_CustomerCode_St_AfterExitEditMode(object sender, EventArgs e)
        {
            // 得意先コード開始の値は数字ではない場合
            if (0 == this.tNedit_CustomerCode_St.GetInt())
            {
                this.tNedit_CustomerCode_St.Text = string.Empty;
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
        /// <br>Note       : 得意先コード終了フォーカスが離れたときに発生します。</br>      
        /// <br>Programmer : 薛祺</br>                                  
        /// <br>Date       : 2010.04.21</br> 
        /// </remarks> 
        private void tNedit_CustomerCode_Ed_AfterExitEditMode(object sender, EventArgs e)
        {
            // 得意先コード終了の値は数字ではない場合
            if (0 == this.tNedit_CustomerCode_Ed.GetInt())
            {
                this.tNedit_CustomerCode_Ed.Text = string.Empty;
                hasCheckError = false;
                return;
            }
        }

        #endregion ■ フォーカスアウト
        
        #endregion ■ Control Event

        #region ■ Private Method
        #region ◆ 画面初期化関係
        #region ◎ 画面初期化処理
        /// <summary>
        /// 画面初期化処理
        /// </summary>
        /// <remarks>
        /// <br>Note		: 入力項目の初期化を行う</br>
        /// <br>Programmer  : 薛祺</br>
        /// <br>Date        : 2010.04.21</br>
        /// </remarks>
        private int InitializeScreen(out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            errMsg = string.Empty;
            
            try
            {
                // 処理月
                this.tDateEdit_YearMonth.SetDateTime(DateTime.Today);
                
                // ボタン設定
                this.SetIconImage(this.ub_St_CustomerCode, Size16_Index.STAR1);
                this.SetIconImage(this.ub_Ed_CustomerCode, Size16_Index.STAR1);
                this.SetIconImage(this.ub_St_CarMngNoGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_Ed_CarMngNoGuide, Size16_Index.STAR1);

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
        /// <br>Programmer  : 薛祺</br>
        /// <br>Date        : 2010.04.21</br>
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
        /// <br>Programmer  : 薛祺</br>
        /// <br>Date        : 2010.04.21</br>
        /// </remarks>
        private bool ScreenInputCheck(ref string errMessage, ref Control errComponent)
        {
            const string ct_RangeError = "の範囲指定に誤りがあります。";
            const string ct_NoInputError = "を入力してください。";
            const string ct_InputError = "が不正です。";

            bool status = true;
            int longDate = this.tDateEdit_YearMonth.LongDate;
            longDate = (longDate / 100) * 100 + 1;
            this.tDateEdit_YearMonth.SetLongDate(longDate);
            if (this.tDateEdit_YearMonth.GetDateYear() == 0 && this.tDateEdit_YearMonth.GetDateMonth() == 0)
            {
                errMessage = string.Format("処理月{0}", ct_NoInputError);
                errComponent = this.tDateEdit_YearMonth;
                status = false;
            }
            else if ((this.tDateEdit_YearMonth.LongDate != 0) && this.tDateEdit_YearMonth.GetDateTime() == DateTime.MinValue)
            {
                errMessage = string.Format("処理月の入力{0}", ct_InputError);
                errComponent = this.tDateEdit_YearMonth;
                status = false;
            }
            else if (
                (this.tNedit_CustomerCode_St.DataText.TrimEnd() != string.Empty) &&
                (this.tNedit_CustomerCode_Ed.DataText.TrimEnd() != string.Empty) &&
                (this.tNedit_CustomerCode_St.DataText.TrimEnd().CompareTo(this.tNedit_CustomerCode_Ed.DataText.TrimEnd()) > 0))
            {
                errMessage = string.Format("得意先コード{0}", ct_RangeError);
                errComponent = this.tNedit_CustomerCode_St;
                status = false;
            }
            else if (
                (this.tEdit_CarMngCode_St.DataText.TrimEnd() != string.Empty) &&
                (this.tEdit_CarMngCode_Ed.DataText.TrimEnd() != string.Empty) &&
                (this.tEdit_CarMngCode_St.DataText.TrimEnd().CompareTo(this.tEdit_CarMngCode_Ed.DataText.TrimEnd()) > 0))
            {
                errMessage = string.Format("管理番号{0}", ct_RangeError);
                errComponent = this.tEdit_CarMngCode_Ed;
                status = false;
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
        /// <br>Programmer  : 薛祺</br>
        /// <br>Date        : 2010.04.21</br>
        /// </remarks>
        private int SetExtraInfoFromScreen()
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            try
            {
                // 企業コード
                this._monthCarInspectListPara.EnterpriseCode = this._enterpriseCode;
                // 拠点オプションありのとき
                if (IsOptSection)
                {
                    ArrayList secList = new ArrayList();
                    // 全社選択かどうか
                    if ((this._selectedSectionList.Count == 1) && (this._selectedSectionList.ContainsKey("0")))
                    {
                        _monthCarInspectListPara.SectionCodes = new string[0];
                    }
                    else
                    {
                        foreach (DictionaryEntry dicEntry in this._selectedSectionList)
                        {
                            if ((CheckState)dicEntry.Value == CheckState.Checked)
                            {
                                secList.Add(dicEntry.Key);
                            }
                        }
                        _monthCarInspectListPara.SectionCodes = (string[])secList.ToArray(typeof(string));
                    }
                }
                // 拠点オプションなしの時
                else
                {
                    _monthCarInspectListPara.SectionCodes = new string[0];
                }

                // 処理月
                this._monthCarInspectListPara.InspectMaturityDate = this.tDateEdit_YearMonth.GetDateTime();


                // 改行
                this._monthCarInspectListPara.ChangeRowDiv = (MonthCarInspectListPara.ChangeRowDivState)this.uos_NewRowDiv.Value;
                // 改頁
                this._monthCarInspectListPara.ChangePageDiv = (MonthCarInspectListPara.ChangePageDivState)this.uos_NewPageDiv.Value;

                // 得意先開始
                if (0 == this.tNedit_CustomerCode_St.GetInt())
                {
                    this._monthCarInspectListPara.StCustomerCode = string.Empty;
                }
                else
                {
                    this._monthCarInspectListPara.StCustomerCode = this.tNedit_CustomerCode_St.GetInt().ToString("D8");
                }
                // 得意先終了
                if (0 == this.tNedit_CustomerCode_Ed.GetInt())
                {
                    this._monthCarInspectListPara.EdCustomerCode = string.Empty;
                }
                else
                {
                    this._monthCarInspectListPara.EdCustomerCode = this.tNedit_CustomerCode_Ed.GetInt().ToString("D8");
                }

                // 管理番号開始
                if (String.IsNullOrEmpty(this.tEdit_CarMngCode_St.Text))
                {
                    this._monthCarInspectListPara.StCarMngCode = string.Empty;
                }
                else
                {
                    this._monthCarInspectListPara.StCarMngCode = this.tEdit_CarMngCode_St.Text;
                }
                // 管理番号終了
                if (String.IsNullOrEmpty(this.tEdit_CarMngCode_Ed.Text))
                {
                    this._monthCarInspectListPara.EdCarMngCode = string.Empty;
                }
                else
                {
                    this._monthCarInspectListPara.EdCarMngCode = this.tEdit_CarMngCode_Ed.Text;
                }


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
        /// <br>Programmer : 薛祺</br>
        /// <br>Date       : 2010.04.21</br>
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
        /// <br>Programmer : 薛祺</br>
        /// <br>Date       : 2010.04.21</br>
        /// </remarks>
        private void Main_ultraExplorerBar_GroupCollapsing(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
        {
            if ((e.Group.Key == "ReportOutputGroup") ||
                (e.Group.Key == "ReportExtractionGroup"))
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
        /// <br>Programmer : 薛祺</br>
        /// <br>Date       : 2010.04.21</br>
        /// </remarks>
        private void Main_ultraExplorerBar_GroupExpanding(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
        {
            if ((e.Group.Key == "ReportOutputGroup") ||
                (e.Group.Key == "ReportExtractionGroup"))
            {
                // グループの縮小をキャンセル
                e.Cancel = true;
            }
        }

        #region ■ 数字を判断処理
        /// <summary>
        /// 数字を判断処理
        /// </summary>
        /// <param name="s">文字列</param>
        /// <remarks>
        /// <br>Note		: 数字を判断処理を行い</br>
        /// <br>Programmer	: 薛祺</br>
        /// <br>Date		: 2010.04.21</br>
        /// </remarks>
        private static bool IsNumber(string s)
        {
            int Flag = 0;
            char[] str = s.ToCharArray();
            for (int i = 0; i < str.Length; i++)
            {
                if (Char.IsNumber(str[i]))
                {
                    Flag++;
                }
                else
                {
                    Flag = -1;
                    break;
                }
            }
            if (Flag > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region ■ 半角カナを判断処理
        /// <summary>
        /// 半角カナ数字を判断処理
        /// </summary>
        /// <param name="str">文字列</param>
        /// <remarks>
        /// <br>Note		: 半角カナ数字を判断処理を行い</br>
        /// <br>Programmer	: 薛祺</br>
        /// <br>Date		: 2010.04.21</br>
        /// </remarks>
        private static bool hkCheck(string str)
        {
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"^[\uFF61-\uFF9F-0-9]*$");
            bool flg = false;
            if (regex.Match(str).Success)
            {
                flg = true;
            }
            else
            {
                flg = false;
            }
            return flg;
        }

        #endregion

        #region ◎ オフライン状態チェック処理

        /// <summary>
        /// ログオン時オンライン状態チェック処理
        /// </summary>
        /// <returns>チェック処理結果</returns>
        /// <remarks>
        /// <br>Note		: ログオン時オンライン状態チェック処理を行い</br>
        /// <br>Programmer	: 薛祺</br>
        /// <br>Date		: 2010.04.21</br>
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
        /// <br>Programmer	: 薛祺</br>
        /// <br>Date		: 2010.04.21</br>
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

        #endregion ■ Private Method

    }
}