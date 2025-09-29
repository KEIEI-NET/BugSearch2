//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 仕入不整合確認表
// プログラム概要   : 仕入不整合確認表帳票を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 汪千来
// 作 成 日  2009/04/13  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日               修正内容 : 
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
using Broadleaf.Application.Controller;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Globarization;
using System.IO;
using System.Net.NetworkInformation;

namespace Broadleaf.Windows.Forms
{

    /// <summary>
    /// 仕入不整合確認表フォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 仕入不整合確認表フォームクラスのインスタンスの作成を行う。</br>
    /// <br>Programmer : 汪千来</br>
    /// <br>Date       : 2009.04.13</br>
    /// </remarks>
    public partial class PMKOU02040UA : Form,
                                IPrintConditionInpType,					// 帳票共通（条件入力タイプ）
                                IPrintConditionInpTypeSelectedSection,	// 帳票業務（条件入力）拠点選択
                                IPrintConditionInpTypePdfCareer			// 帳票業務（条件入力）PDF出力履歴管理
    {

        #region ■ Constructor

        /// <summary>
        /// 仕入不整合確認表UIクラス
        /// </summary>
        /// <remarks>
        /// <br>Note       : 仕入不整合確認表UIクラスの作成を行う。</br>
        /// <br>Programmer : 汪千来</br>
        /// <br>Date       : 2009.04.13</br>
        /// <br></br>
        /// </remarks>
        public PMKOU02040UA()
        {
            InitializeComponent();

            // 企業コード取得
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            //日付取得部品
            this._dateGet = DateGetAcs.GetInstance();

            // 拠点用のHashtable作成
            this._selectedSectionList = new Hashtable();

            // 仕入売上情報一覧表アクセスクラス
            this._stockSalesInfoMainAcs = new StockSalesInfoMainAcs();

            //_loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;

            //拠点情報設定アクセスクラス
            this._mSecInfoAcs = new SecInfoAcs();

            // UI設定保存コンポーネント設定
            this.SetUIMemInputControl();

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


        #endregion ◆ Interface member

        #region
        // 企業コード
        private string _enterpriseCode = string.Empty;

        //拠点アクセス
        private SecInfoAcs _mSecInfoAcs = null;

        // 仕入売上情報一覧表アクセスクラス
        private StockSalesInfoMainAcs _stockSalesInfoMainAcs;

        // 画面イメージコントロール部品
        private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();

        // 選択拠点リスト
        private Hashtable _selectedSectionList = new Hashtable();

        //日付取得部品
        private DateGetAcs _dateGet;

        //拠点コード
        private string _loginSectionCode = string.Empty;

        #endregion

        #endregion ■ Private Member

        #region ■ Private Const
        #region ◆ Interface member
        //--IPrintConditionInpTypePdfCareerのプロパティ用変数 -------------------------
        // クラスID
        private const string ct_ClassID = "PMKOU02040UA";
        // プログラムID
        private const string ct_PGID = "PMKOU02040U";
        // 帳票名称
        private const string ct_PrintName = "仕入不整合確認表";
        // 帳票キー	
        private const string ct_PrintKey = "a1521de4-9264-48d5-af87-ea5ad569213b";
        //全社
        private const string ct_All = "00";

        #endregion ◆ Interface member

        // ExporerBar グループ名称
        private const string ct_ExBarGroupNm_ReportSelectGroup = "ReportSelectGroup";		// 出力条件

        #endregion

        #region ■ IPrintConditionInpTypePdfCareer メンバ
        #region ◆ Public Property

        /// <summary> 帳票キー</summary>
        /// <value>PrintKey</value>               
        /// <remarks>帳票キー取得プロパティ </remarks>  
        public string PrintKey
        {
            get { return ct_PrintKey; }
        }

        /// <summary> 帳票名</summary>
        /// <value>PrintName</value>               
        /// <remarks>帳票名取得ププロパティ </remarks>  
        public string PrintName
        {
            get { return ct_PrintName; }
        }

        /// <summary> 計上拠点選択表示</summary>
        /// <value>VisibledSelectAddUpCd</value>               
        /// <remarks>計上拠点選択表示取得又はセットププロパティ</remarks>  
        public bool VisibledSelectAddUpCd
        {
            get { return _visibledSelectAddUpCd; }
            set { _visibledSelectAddUpCd = value; }
        }

        /// <summary> 拠点オプションプ</summary>
        /// <value>IsOptSection</value>               
        /// <remarks>拠点オプションプ取得又はセットププロパティ</remarks>  
        public bool IsOptSection
        {
            get { return _isOptSection; }
            set { _isOptSection = value; }
        }

        /// <summary> 本社機能</summary>
        /// <value>IsMainOfficeFunc</value>               
        /// <remarks>本社機能取得又はセットプロパティ</remarks>  
        public bool IsMainOfficeFunc
        {
            get { return _isMainOfficeFunc; }
            set { _isMainOfficeFunc = value; }
        }

        #endregion ◆ Public Method
        #endregion ■ IPrintConditionInpTypePdfCareer メンバ

        #region ■ IPrintConditionInpType メンバ

        #region ◆ Public Event
        /// <summary> 親ツールバー設定イベント </summary>
        /// <remarks>親ツールバー設定イベントを実行します。</remarks>   
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

        #region ◆ 画面設定保存
        /// <summary>
        /// UIMemInputの保存項目設定
        /// </summary>
        /// <remarks>
        /// <br>Note		: UIMemInputの保存項目設定を行う。</br>
        /// <br>Programmer	: 汪千来</br>
        /// <br>Date		: 2009.04.13</br>
        /// </remarks>
        private void SetUIMemInputControl()
        {
            // 入力保存項目をセット
            List<Control> saveCtrAry = new List<Control>();

            saveCtrAry.Add(this.tDateEdit_YearMonth);
            saveCtrAry.Add(this.tDateEdit_LastCAddUpUpdDate);
            saveCtrAry.Add(this.tDateEdit_CAddUpUpdDate);

            this.uiMemInput1.TargetControls = saveCtrAry;
            this.uiMemInput1.ReadOnLoad = false;
        }
        #endregion

        #region ◎ 抽出処理
        /// <summary>
        /// 抽出処理
        /// </summary>
        /// <param name="parameter">パラメータ</param>
        /// <returns>0( 固定 )</returns>
        /// <remarks>
        /// <br>Note		: 抽出処理を行う。</br>
        /// <br>Programmer	: 汪千来</br>
        /// <br>Date		: 2009.04.13</br>
        /// </remarks>
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
        /// <br>Programmer	: 汪千来</br>
        /// <br>Date		: 2009.04.13</br>
        /// </remarks>
        public int Print(ref object parameter)
        {
            // オフライン状態チェック	
            if (!CheckOnline())
            {
                TMsgDisp.Show(
                    emErrorLevel.ERR_LEVEL_STOP,
                    this.Text,
                    "仕入不整合確認表データ読み込みに失敗しました。",
                    (int)ConstantManagement.DB_Status.ctDB_OFFLINE, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                return -1;
            }

            SFCMN06001U printDialog = new SFCMN06001U();		// 帳票選択ガイド
            SFCMN06002C printInfo = parameter as SFCMN06002C;	// 印刷情報パラメータ

            // 企業コードをセット
            printInfo.enterpriseCode = this._enterpriseCode;
            printInfo.kidopgid = ct_PGID;				// 起動PGID

            // PDF出力履歴用
            printInfo.key = ct_PrintKey;
            printInfo.prpnm = ct_PrintName;
            printInfo.PrintPaperSetCd = 0;

            // 抽出条件クラス
            StockSalesInfoMainCndtn extrInfo = new StockSalesInfoMainCndtn();

            // 画面→抽出条件クラス
            int status = this.SetExtraInfoFromScreen(extrInfo);
            if (status != 0)
            {
                return -1;
            }
            // 抽出条件の設定
            printInfo.jyoken = extrInfo;
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
        /// <br>Programmer	: 汪千来</br>
        /// <br>Date		: 2009.04.13</br>
        /// </remarks>
        public void Show(object parameter)
        {
            this.Show();

            // UI設定保存コンポーネント設定
            this.uiMemInput1.OptionCode = "0";

            return;
        }

        #endregion

        #region ◎ 印刷前確認処理
        /// <summary>
        /// 印刷前確認処理
        /// </summary>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note		: 印刷前確認処理を行う。(入力チェックなど)</br>
        /// <br>Programmer	: 汪千来</br>
        /// <br>Date		: 2009.04.13</br>
        /// </remarks>
        public bool PrintBeforeCheck()
        {
            return true;
        }
        #endregion
        #endregion

        #region ■ IPrintConditionInpTypeSelectedSection メンバ
        #region ◎ 拠点選択処理
        /// <summary>
        /// 拠点選択処理
        /// </summary>
        /// <param name="sectionCode">選択拠点コード</param>
        /// <param name="checkState">選択状態</param>
        /// <remarks>
        /// <br>Note		: 拠点選択処理を行う。</br>
        /// <br>Programmer	: 汪千来</br>
        /// <br>Date		: 2009.04.13</br>
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

        #region ◎ 初期選択計上拠点設定処理（実装の必要がない）
        /// <summary>
        /// 初期選択計上拠点設定処理
        /// </summary>
        /// <param name="addUpCd"></param>
        /// <remarks>
        /// <br>Note		: 実装の必要がない</br>
        /// <br>Programmer	: 汪千来</br>
        /// <br>Date		: 2009.04.13</br>
        /// </remarks>
        public void InitSelectAddUpCd(int addUpCd)
        {
            // 計上拠点選択がないので、実装の必要がない
        }
        #endregion

        #region ◎ 初期選択拠点設定処理
        /// <summary>
        /// 初期選択拠点設定処理
        /// </summary>
        /// <param name="sectionCodeLst">選択拠点コードリスト</param>
        /// <remarks>
        /// <br>Note		: 拠点リストの初期化を行う。</br>
        /// <br>Programmer	: 汪千来</br>
        /// <br>Date		: 2009.04.13</br>
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
        /// <br>Programmer	: 汪千来</br>
        /// <br>Date		: 2009.04.13</br>
        /// </remarks>
        public bool InitVisibleCheckSection(bool isDefaultState)
        {
            return isDefaultState;
        }
        #endregion

        #region ◎ 計上拠点選択処理( 実装の必要がない )
        /// <summary>
        /// 計上拠点選択処理( 未実装 )
        /// </summary>
        /// <param name="addUpCd"></param>
        /// <remarks>
        /// <br>Note		: 実装の必要がない</br>
        /// <br>Programmer	: 汪千来</br>
        /// <br>Date		: 2009.04.13</br>
        /// </remarks>
        public void SelectedAddUpCd(int addUpCd)
        {
            // 計上拠点選択がないので実装の必要がない
        }
        #endregion
        #endregion

        #region ■ Control Event
        #region ◆ PMKOU02040UA
        #region ◎ PMKOU02040UA_Load Event
        /// <summary>
        /// PMKOU02040UA_Load Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: ユーザーがﾌｫｰﾑを読み込むときに発生するを行う。</br>
        /// <br>Programmer	: 汪千来</br>
        /// <br>Date		: 2009.04.13</br>
        /// </remarks>
        private void PMKOU02040UA_Load(object sender, EventArgs e)
        {
            string errMsg = string.Empty;

            // 初期化タイマー起動
            Initialize_Timer.Enabled = true;

            // 画面イメージ統一
            // 画面スキンファイルの読込(デフォルトスキン指定)
            this._controlScreenSkin.LoadSkin();

            // 画面スキン変更
            this._controlScreenSkin.SettingScreenSkin(this);
        }
        #endregion
        #endregion ◆ PMKOU02040UA

        #region ◆ Initialize_Timer
        #region ◎ Tick Event
        /// <summary>
        /// Tick イベント                                               
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>                             
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　  : timer tick時に発生しますを行う。</br>                  
        /// <br>Programmer	: 汪千来</br>
        /// <br>Date		: 2009.04.13</br>
        /// </remarks>
        private void Initialize_Timer_Tick(object sender, EventArgs e)
        {
            Initialize_Timer.Enabled = false;
            string errMsg = string.Empty;

            try
            {
                this.Cursor = Cursors.WaitCursor;

                // コントロール初期化
                int status = this.InitializeScreen(out errMsg);
                if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    MsgDispProc(emErrorLevel.ERR_LEVEL_STOPDISP, errMsg, status);
                    return;
                }

                ParentToolbarSettingEvent(this);	// ツールバー設定イベント
            }
            finally
            {
                this.tDateEdit_YearMonth.Focus();
                this.Cursor = Cursors.Default;
            }
        }
        #endregion
        #endregion ◆ Initialize_Timer

        /// <summary>
        /// エクスプローラーバー グループ縮小 イベント
        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント情報</param>
        /// <remarks>
        /// <br>Note       : グループが縮小される前に発生します。</br>
        /// <br>Programer  : 汪千来</br>
        /// <br>Date       : 2009/04/13</br>
        /// </remarks>
        private void ultraExplorerBar1_GroupCollapsing(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
        {
            if ((e.Group.Key == ct_ExBarGroupNm_ReportSelectGroup))
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
        /// <br>Programer  : 汪千来</br>
        /// <br>Date       : 2009/04/13</br>
        /// </remarks>
        private void ultraExplorerBar1_GroupExpanding(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
        {
            if ((e.Group.Key == ct_ExBarGroupNm_ReportSelectGroup))
            {
                // グループの縮小をキャンセル
                e.Cancel = true;
            }
        }

        /// <summary> 
        /// UI保存コンポーネント読込みイベント 
        /// </summary> 
        /// <param name="targetControls">コンポーネント</param> 
        /// <param name="customizeData">保存データ</param> 
        /// <remarks> 
        /// <br>Programmer : 汪千来 </br> 
        /// <br>Date       : 2009.04.13</br> 
        /// <br>改行条件チェックボックスの状態を復元する。</br> 
        /// </remarks> 
        private void uiMemInput1_CustomizeRead(Control[] targetControls, string[] customizeData)
        {
            if (customizeData.Length > 0)
            {
                this.tDateEdit_YearMonth.LongDate = int.Parse(customizeData[0]);
                this.tDateEdit_LastCAddUpUpdDate.LongDate = int.Parse(customizeData[1]);
                this.tDateEdit_CAddUpUpdDate.LongDate = int.Parse(customizeData[2]);
            }
        }

        /// <summary> 
        /// UI保存コンポーネント書込みイベント 
        /// </summary> 
        /// <param name="targetControls">コンポーネント</param> 
        /// <param name="customizeData">保存データ</param> 
        /// <remarks> 
        /// <br>Programmer : 汪千来</br> 
        /// <br>Date       : 2009.04.13</br> 
        /// <br>改行条件チェックボックスの状態を保存する。</br> 
        /// </remarks> 
        private void uiMemInput1_CustomizeWrite(Control[] targetControls, out string[] customizeData)
        {
            customizeData = new string[3];
            customizeData[0] = this.tDateEdit_YearMonth.LongDate.ToString();
            customizeData[1] = this.tDateEdit_LastCAddUpUpdDate.LongDate.ToString();
            customizeData[2] = this.tDateEdit_CAddUpUpdDate.LongDate.ToString();
        }
        #endregion

        #region ■ Private Method
        #region ◆ 画面初期化関係
        #region ◎ 画面初期化処理
        /// <summary>
        /// 画面初期化処理
        /// </summary>
        /// <remarks>
        /// <br>Note		: 入力項目の初期化を行う</br>
        /// <br>Programmer	: 汪千来</br>
        /// <br>Date		: 2009.04.13</br>
        /// </remarks>
        private int InitializeScreen(out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            errMsg = string.Empty;

            try
            {
                TotalDayCalculator totalDayCalculator = TotalDayCalculator.GetInstance();
                //前回締処理日
                DateTime prevTotalDay = DateTime.MinValue;
                //今回締処理日
                DateTime currentTotalDay = DateTime.MinValue;
                //前回締処理月
                DateTime prevTotalMonth = DateTime.MinValue;
                //今回締処理月
                DateTime currentTotalMonth = DateTime.MinValue;

                int convertProcessDivCd = 0;

                // 締処理日を取得する
                totalDayCalculator.InitializeHisMonthlyAccPay();
                //ct_All
                totalDayCalculator.GetHisTotalDayMonthlyAccPay(string.Empty, out prevTotalDay, out currentTotalDay, out prevTotalMonth, out currentTotalMonth, out convertProcessDivCd);

                if (currentTotalMonth != DateTime.MinValue)
                {
                    // 対象年月を設定
                    this.tDateEdit_YearMonth.SetDateTime(currentTotalMonth);
                    // 前回締処理日を設定
                    //this.tDateEdit_LastCAddUpUpdDate.SetDateTime(prevTotalDay);
                    this.tDateEdit_LastCAddUpUpdDate.SetDateTime(prevTotalDay.AddDays(1.0));
                    // 今回締処理日を設定
                    this.tDateEdit_CAddUpUpdDate.SetDateTime(currentTotalDay);
                }
                else
                {
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
                    // 対象年月を設定
                    this.tDateEdit_YearMonth.SetDateTime(thisYearMonth);
                    // 年度開始日を設定
                    this.tDateEdit_LastCAddUpUpdDate.SetDateTime(startYearDate);
                    // 年度終了日を設定
                    this.tDateEdit_CAddUpUpdDate.SetDateTime(endYearDate);
                }

                // 前回表示状態が保存されていれば上書き
                //this.uiMemInput1.ReadMemInput();

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
        /// <br>Note		: ボタンアイコン設定処理を行う</br>
        /// <br>Programmer	: 汪千来</br>
        /// <br>Date		: 2009.04.13</br>
        /// </remarks>
        private void SetIconImage(object settingControl, Size16_Index iconIndex)
        {
            ((Infragistics.Win.Misc.UltraButton)settingControl).ImageList = IconResourceManagement.ImageList16;
            ((Infragistics.Win.Misc.UltraButton)settingControl).Appearance.Image = iconIndex;
        }
        #endregion
        #endregion ◆ 画面初期化関係

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
        /// <br>Programmer : 汪千来</br>
        /// <br>Date	   : 2009.04.13</br>
        /// </remarks>
        private void MsgDispProc(emErrorLevel iLevel, string message, int status)
        {
            TMsgDisp.Show(
                iLevel, 							// エラーレベル
                ct_ClassID,							// アセンブリＩＤまたはクラスＩＤ
                ct_PrintName,						// プログラム名称
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

        #region ◎ 抽出条件設定処理(画面→抽出条件)
        /// <summary>
        /// 抽出条件設定処理(画面→抽出条件)
        /// </summary>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note		: 画面→抽出条件へ設定する。</br>
        /// <br>Programmer	: 汪千来</br>
        /// <br>Date		: 2009.04.13</br>
        /// </remarks>
        private int SetExtraInfoFromScreen(StockSalesInfoMainCndtn extraInfo)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            try
            {
                // 拠点オプション
                extraInfo.IsOptSection = this._isOptSection;
                // 企業コード
                extraInfo.EnterpriseCode = this._enterpriseCode;

                // 選択拠点
                extraInfo.CollectAddupSecCodeList = (string[])new ArrayList(this._selectedSectionList.Values).ToArray(typeof(string));

                //対象年月
                int longDate = this.tDateEdit_YearMonth.LongDate;
                longDate = (longDate / 100) * 100 + 1;
                this.tDateEdit_YearMonth.SetLongDate(longDate);
                extraInfo.YearMonth = this.tDateEdit_YearMonth.GetDateTime();

                //前回締処理日
                extraInfo.PrevTotalDay = this.tDateEdit_LastCAddUpUpdDate.GetDateTime();
                //今回締処理日
                extraInfo.CurrentTotalDay = this.tDateEdit_CAddUpUpdDate.GetDateTime();

            }
            catch (Exception)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }

            return status;
        }
        #endregion

        #region ◎ オフライン状態チェック処理

        /// <summary>
        /// ログオン時オンライン状態チェック処理
        /// </summary>
        /// <returns>チェック処理結果</returns>
        /// <remarks>
        /// <br>Note		: ログオン時オンライン状態チェック処理を行い</br>
        /// <br>Programmer	: 汪千来</br>
        /// <br>Date		: 2009.04.13</br>
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
        /// <br>Programmer	: 汪千来</br>
        /// <br>Date		: 2009.04.13</br>
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

        #endregion

    }
}