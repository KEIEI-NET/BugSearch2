//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 返品理由一覧表
// プログラム概要   : 返品理由一覧表情報を抽出し、印刷・PDF出力する
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 呉元嘯
// 作 成 日  2009/05/14  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : caowj
// 修 正 日  2010/08/12  修正内容 : 売上月報年報対応
//----------------------------------------------------------------------------//
// 管理番号  10806793-00 作成担当 : cheq                                
// 修 正 日  2013/01/25  修正内容 : 2013/03/13配信分                    
//                                  Redmine#34098 罫線印字制御の追加対応
//----------------------------------------------------------------------------//
// 管理番号  10806793-00 作成担当 : 王君                                
// 修 正 日  2013/02/27  修正内容 : 2013/03/13配信分                    
//                                  Redmine#34098 罫線印字制御の追加対応
//----------------------------------------------------------------------------//
// 管理番号  10900690-00 作成担当 : cheq                                
// 修 正 日  2013/03/11  修正内容 : 2013/03/26配信分                    
//                                  Redmine#34987 フォーカス遷移の追加対応
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
    /// 返品理由一覧表 入力フォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 返品理由一覧表PDF出力操作を行うクラスです。</br>
    /// <br>Programmer : 呉元嘯</br>
    /// <br>Date       : 2009.05.14</br>
    /// <br></br>
    /// <br>Update Note : 2010/08/12  caowj</br>
    /// <br>              ・ PM.NS1012対応</br>
    /// <br>Update Note : 2013/01/25 cheq</br>
    /// <br>管理番号    : 10806793-00 2013/03/13配信分</br>
    /// <br>              Redmine#34098 罫線印字制御の追加対応</br>
    /// <br>Update Note : 2013/02/27 王君</br>
    /// <br>管理番号    : 10806793-00 2013/03/13配信分</br>
    /// <br>              Redmine#34098 罫線印字制御の追加対応</br>
    /// <br>Update Note : 2013/03/11 cheq</br>
    /// <br>管理番号    : 10900690-00 2013/03/26配信分</br>
    /// <br>              Redmine#34987 フォーカス遷移の対応</br>
    /// </remarks>
    public partial class PMHNB02210UA : Form,
                                IPrintConditionInpType,					// 帳票共通（条件入力タイプ）
                                IPrintConditionInpTypeSelectedSection,	// 帳票業務（条件入力）拠点選択
                                IPrintConditionInpTypePdfCareer,		// 帳票業務（条件入力）PDF出力履歴管理
                                IPrintConditionInpTypeGuidExecuter      // F5：ガイドの表示非表示  // ADD 2010/08/12
    {
        #region ■ Constructor
        /// <summary>
        /// 帳票共通(条件入力タイプ)フレームクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        public PMHNB02210UA()
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
        private HenbiRiyuListReport _henbiRiyuListReport;

        // ガイド系アクセスクラス
        private EmployeeAcs _employeeAcs;

        //日付取得部品
        private DateGetAcs _dateGet;

        // フォーカスControl
        private Control _prevControl = null;

        // チェックエラー
        private bool hasCheckError = false;

        // 得意先ガイド結果OKフラグ
        private bool _customerGuideOK;

        // 得意先ガイド用
        private UltraButton _customerGuideSender;

        // --- ADD 2010/08/12 ---------------------------------->>>>>
        private bool _customerCodeSt = false;
        // --- ADD 2010/08/12 ----------------------------------<<<<<

        // ADD 2007/07/13 PVCS326
        // 対象年月Clone
        private string _thisYearMonthClone;

        // --- ADD 2010/08/12 ---------------------------------->>>>>
        private object _preComboEditorValue = null;

        /// <summary>
        /// ガイド用イベント
        /// </summary>
        public event ParentToolbarGuideSettingEventHandler ParentToolbarGuideSettingEvent;
        // --- ADD 2010/08/12 ----------------------------------<<<<<

        // --- ADD 2010/08/26 ---------->>>>>
        private Control _preControl = null;
        public event ParentPrint ParentPrintCall;
        // --- ADD 2010/08/26 ----------<<<<<

        #endregion ■ Private Member

        #region ■ Private Const
        #region ◆ Interface member
        //--IPrintConditionInpTypePdfCareerのプロパティ用変数 -------------------------
		// クラスID
        private const string ct_ClassID = "PMHNB02210UA";
		// プログラムID
        private const string ct_PGID = "PMHNB02210U";
		//// 帳票名称
        private const string PDF_PRINT_NAME = "返品理由一覧表";
		private string _printName = PDF_PRINT_NAME;
        // 帳票キー	
        private const string PDF_PRINT_KEY = "e51401e3-8545-4e50-85f2-baad3992d818";
        //全社
        private const string ct_All = "00";
		private string _printKey = PDF_PRINT_KEY;
		#endregion ◆ Interface member

        /// <summary>ユーザーガイド区分コード（返品理由）</summary>
        public static readonly int DIVCODE_UserGuideDivCd_RetGoodsReason = 91;
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
        /// <br>Programmer  : 呉元嘯</br>
        /// <br>Date        : 2009.05.14</br>
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
        /// <br>Programmer  : 呉元嘯</br>
        /// <br>Date        : 2009.05.14</br>
        /// </remarks>
        public bool PrintBeforeCheck()
        {
            bool status = true;
            string errMessage = "";
            Control errComponent = null;

            // --- ADD 2010/08/26 ---------->>>>>
            ChangeFocusEventArgs evt = new ChangeFocusEventArgs(false, false, false, Keys.Space, this._preControl, this._preControl);
            this.tArrowKeyControl1_ChangeFocus(this, evt);
            // --- ADD 2010/08/26 ----------<<<<<
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
        /// <br>Programmer  : 呉元嘯</br>
        /// <br>Date        : 2009.05.14</br>
        /// </remarks>
        public int Print(ref object parameter)
        {

            // オフライン状態チェック	
            if (!CheckOnline())
            {
                TMsgDisp.Show(
                    emErrorLevel.ERR_LEVEL_STOP,
                    this.Text,
                    "返品理由一覧表データ読み込みに失敗しました。",
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
            printInfo.jyoken = this._henbiRiyuListReport;
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
        /// <br>Programmer  : 呉元嘯</br>
        /// <br>Date        : 2009.05.14</br>
        /// </remarks>
        public void Show(object parameter)
        {
            this._henbiRiyuListReport = new HenbiRiyuListReport();

            // 引数型チェック
            //int result = 0;
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
        /// <br>Programmer  : 呉元嘯</br>
        /// <br>Date        : 2009.05.14</br>
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
        /// <br>Programmer  : 呉元嘯</br>
        /// <br>Date        : 2009.05.14</br>
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
        /// <br>Programmer  : 呉元嘯</br>
        /// <br>Date        : 2009.05.14</br>
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
        /// <br>Programmer  : 呉元嘯</br>
        /// <br>Date        : 2009.05.14</br>
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
        /// <br>Programmer  : 呉元嘯</br>
        /// <br>Date        : 2009.05.14</br>
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
        #region ◆ PMHNB02210UA
        #region ◎ PMHNB02210UA_Load Event
        /// <summary>
        /// PMHNB02210UA_Load Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: ユーザーがﾌｫｰﾑを読み込むときに発生する</br>
        /// <br>Programmer  : 呉元嘯</br>
        /// <br>Date        : 2009.05.14</br>
        /// <br>Update Note : 2010/08/12 caowj</br>
        /// <br>              PM.NS1012対応</br>
        /// </remarks>
        private void PMHNB02210UA_Load(object sender, EventArgs e)
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
            this.tComboEditor_ChangePg.Focus();
            _prevControl = tComboEditor_ChangePg;
            this.Cursor = Cursors.Default;

            // --- ADD 2010/08/12 ---------------------------------->>>>>
            ParentToolbarGuideSettingEvent(true);
            // --- ADD 2010/08/12 ----------------------------------<<<<<
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
        /// <br>Programmer  : 呉元嘯</br>
        /// <br>Date        : 2009.05.14</br>
        /// <br>Update Note : 2010/08/12 caowj</br>
        /// <br>              PM.NS1012対応</br>
        /// <br>Update Note : 2013/01/25 cheq</br>
        /// <br>管理番号    : 10806793-00 2013/03/13配信分</br>
        /// <br>              Redmine#34098 罫線印字制御の追加対応</br>
        /// <br>Update Note : 2013/03/11 cheq</br>
        /// <br>管理番号    : 10900690-00 2013/03/26配信分</br>
        /// <br>              Redmine#34987 フォーカス遷移の対応</br>
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            // --- ADD 2010/08/12 ---------------------------------->>>>>
            #region 項目処理
            if (e.PrevCtrl != null)
            {
                switch (e.PrevCtrl.Name)
                {
                    case "tComboEditor_SlipKind":
                    case "tComboEditor_PrintType":
                    case "tComboEditor_ChangePg":
                    case "tComboEditor_LinePrintDiv": // ADD cheq 2013/01/25 Redmine#34098 
                        {
                            this.setTComboEditorByName(e.PrevCtrl.Name);
                            break;
                        }
                }
            }

            if (e.NextCtrl != null)
            {
                if (e.NextCtrl.GetType().Name == "TComboEditor")
                {
                    this._preComboEditorValue = ((TComboEditor)e.NextCtrl).Value;
                }
            }
            // --- ADD 2010/08/26 --- >>>>>
            this._preControl = e.NextCtrl;
            // --- ADD 2010/08/26 --- <<<<<
            #endregion
            // --- ADD 2010/08/12 ----------------------------------<<<<<

            if (!e.ShiftKey)
            {
                // SHIFTキー未押下
                // --- DEL 2010/08/12 ---------------------------------->>>>>
                //if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                // --- DEL 2010/08/12 ----------------------------------<<<<<
                // --- ADD 2010/08/12 ---------------------------------->>>>>
                if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab) || (e.Key == Keys.Right))
                // --- ADD 2010/08/12 ----------------------------------<<<<<
                {
                    /*----- DEL 2013/01/25 cheq Redmine#34098 ----->>>>>
                    if (e.PrevCtrl == this.tComboEditor_ChangePg)
                    {
                        // 改頁→出力順
                        e.NextCtrl = this.tComboEditor_PrintType;
                    }
                    ----- DEL 2013/01/25 cheq Redmine#34098 -----<<<<<*/
                    /*----- DEL 2013/01/25 cheq Redmine#34098 ----->>>>>
                    //----- ADD 2013/01/25 cheq Redmine#34098 ----->>>>>
                    if (e.PrevCtrl == this.tComboEditor_ChangePg)
                    {
                        // 改頁→罫線印字
                        e.NextCtrl = this.tComboEditor_LinePrintDiv;
                    }
                    else if (e.PrevCtrl == this.tComboEditor_LinePrintDiv)
                    {
                        // 罫線印字→出力順
                        e.NextCtrl = this.tComboEditor_PrintType;
                    }
                    //----- ADD 2013/01/25 cheq Redmine#34098 -----<<<<<
                    ----- DEL 2013/01/25 cheq Redmine#34098 -----<<<<<*/
                    //----- ADD 2013/03/11 cheq Redmine#34987 ----->>>>>
                    if (e.PrevCtrl == this.tComboEditor_LinePrintDiv)
                    {
                        // 罫線印字→改頁
                        e.NextCtrl = this.tComboEditor_ChangePg;
                    }
                    else if (e.PrevCtrl == this.tComboEditor_ChangePg)
                    {
                        // 改頁→出力順
                        e.NextCtrl = this.tComboEditor_PrintType;
                    }
                    //----- ADD 2013/03/11 cheq Redmine#34987 -----<<<<<
                    else if (e.PrevCtrl == this.tComboEditor_PrintType)
                    {
                        // 出力順→得意先(開始)
                        e.NextCtrl = this.tNedit_CustomerCode_St;
                    }
                    else if (e.PrevCtrl == this.tNedit_CustomerCode_St)
                    {
                        tNedit_CustomerCode_St_AfterExitEditMode(e.PrevCtrl, null);
                        // 得意先(開始)→得意先(終了)
                        e.NextCtrl = this.tNedit_CustomerCode_Ed;
                    }
                    else if (e.PrevCtrl == this.tNedit_CustomerCode_Ed)
                    {
                        tNedit_CustomerCode_Ed_AfterExitEditMode(e.PrevCtrl, null);
                        // 得意先(終了)→担当者(開始)
                        e.NextCtrl = this.tEdit_SalesEmployeeCd_St;
                    }
                    else if (e.PrevCtrl == this.tEdit_SalesEmployeeCd_St)
                    {
                        tEdit_SalesEmployeeCd_St_AfterExitEditMode(e.PrevCtrl, null);
                        // 担当者(開始)→担当者(終了)
                        e.NextCtrl = this.tEdit_SalesEmployeeCd_Ed;
                    }
                    else if (e.PrevCtrl == this.tEdit_SalesEmployeeCd_Ed)
                    {
                        tEdit_SalesEmployeeCd_Ed_AfterExitEditMode(e.PrevCtrl, null);
                        // 担当者(終了)→受注者(開始)
                        e.NextCtrl = this.tEdit_FrontEmployeeCd_St;
                    }
                    else if (e.PrevCtrl == this.tEdit_FrontEmployeeCd_St)
                    {
                        tEdit_FrontEmployeeCd_St_AfterExitEditMode(e.PrevCtrl, null);
                        // 受注者(開始)→受注者(終了)
                        e.NextCtrl = this.tEdit_FrontEmployeeCd_Ed;
                    }
                    else if (e.PrevCtrl == this.tEdit_FrontEmployeeCd_Ed)
                    {
                        tEdit_FrontEmployeeCd_Ed_AfterExitEditMode(e.PrevCtrl, null);
                        // 受注者(終了)→発行者(開始)
                        e.NextCtrl = this.tEdit_SalesInputCode_St;
                    }
                    else if (e.PrevCtrl == this.tEdit_SalesInputCode_St)
                    {
                        tEdit_SalesInputCode_St_AfterExitEditMode(e.PrevCtrl, null);
                        // 発行者(開始)→発行者(終了)
                        e.NextCtrl = this.tEdit_SalesInputCode_Ed;
                    }
                    else if (e.PrevCtrl == this.tEdit_SalesInputCode_Ed)
                    {
                        tEdit_SalesInputCode_Ed_AfterExitEditMode(e.PrevCtrl, null);
                        // 発行者(終了)→返品理由(開始)
                        e.NextCtrl = this.tNedit_RetGoodsReasonDiv_St;
                    }
                    else if (e.PrevCtrl == this.tNedit_RetGoodsReasonDiv_St)
                    {
                        tNedit_RetGoodsReasonDiv_St_AfterExitEditMode(e.PrevCtrl, null);
                        // 返品理由(開始)→返品理由(終了)
                        e.NextCtrl = this.tNedit_RetGoodsReasonDiv_Ed;
                    }
                    else if (e.PrevCtrl == this.tNedit_RetGoodsReasonDiv_Ed)
                    {
                        tNedit_RetGoodsReasonDiv_Ed_AfterExitEditMode(e.PrevCtrl, null);
                        // 返品理由(終了)→伝票種別
                        e.NextCtrl = this.tComboEditor_SlipKind;
                    }
                    // --- ADD 2010/08/12 ---------------------------------->>>>>
                    else if (e.PrevCtrl == this.tComboEditor_SlipKind)
                    {
                        this.tComboEditor_SlipKind.SelectAll();
                        if (this.tComboEditor_SlipKind.Text.Equals("0") || this.tComboEditor_SlipKind.Text.Equals("1"))
                        {
                            int index = Convert.ToInt32(this.tComboEditor_SlipKind.Text);
                            this.tComboEditor_SlipKind.SelectedText = this.tComboEditor_SlipKind.Items[index].DisplayText;
                        }

                        // --- ADD 2010/08/26 ---------->>>>>
                        if (this.ParentPrintCall != null)
                        {
                            this.ParentPrintCall();
                        }
                        // --- ADD 2010/08/26 ----------<<<<<

                        e.NextCtrl = null;
                    }
                    /*----- DEL 2013/03/11 cheq Redmine#34987 ----->>>>>
                    else if (e.PrevCtrl == this.tDateEdit_YearMonth)
                    {
                        // 対象年月→改頁
                        e.NextCtrl = this.tComboEditor_ChangePg;
                    }
                     ----- DEL 2013/03/11 cheq Redmine#34987 -----<<<<<*/
                    //----- ADD 2013/03/11 cheq Redmine#34987 ----->>>>>
                    else if (e.PrevCtrl == this.tDateEdit_YearMonth)
                    {
                        // 対象年月→罫線印字
                        e.NextCtrl = this.tComboEditor_LinePrintDiv;
                    }
                    //----- ADD 2013/03/11 cheq Redmine#34987 -----<<<<<
                    // --- ADD 2010/08/12 ----------------------------------<<<<<
                }
                // --- ADD 2010/08/12 ---------------------------------->>>>>
                else if (e.Key == Keys.Left)
                {

                    /*----- DEL 2013/01/25 cheq Redmine#34098 ----->>>>>
                    if (e.PrevCtrl == this.tComboEditor_PrintType)
                    {
                        // 出力順→改頁
                        e.NextCtrl = this.tComboEditor_ChangePg;
                    }
                    ----- DEL 2013/01/25 cheq Redmine#34098 -----<<<<<*/
                    /*----- DEL 2013/03/11 cheq Redmine#34987 ----->>>>>
                    //----- ADD 2013/01/25 cheq Redmine#34098 ----->>>>>
                    if (e.PrevCtrl == this.tComboEditor_PrintType)
                    {
                        // 出力順→罫線印字
                        e.NextCtrl = this.tComboEditor_LinePrintDiv;
                    }
                    else if (e.PrevCtrl == this.tComboEditor_LinePrintDiv)
                    {
                        // 罫線印字→改頁
                        e.NextCtrl = this.tComboEditor_ChangePg;
                    }
                    //----- ADD 2013/01/25 cheq Redmine#34098 -----<<<<<
                    ----- DEL 2013/03/11 cheq Redmine#34987 -----<<<<<*/
                    //----- ADD 2013/03/11 cheq Redmine#34987 ----->>>>>
                    if (e.PrevCtrl == this.tComboEditor_PrintType)
                    {
                        // 出力順→改頁
                        e.NextCtrl = this.tComboEditor_ChangePg;
                    }
                    else if (e.PrevCtrl == this.tComboEditor_ChangePg)
                    {
                        // 改頁→罫線印字
                        e.NextCtrl = this.tComboEditor_LinePrintDiv;
                    }
                    //----- ADD 2013/03/11 cheq Redmine#34987 -----<<<<<
                    else if (e.PrevCtrl == this.tNedit_CustomerCode_St)
                    {
                        // 得意先(開始)→出力順
                        e.NextCtrl = this.tComboEditor_PrintType;
                    }
                    else if (e.PrevCtrl == this.tNedit_CustomerCode_Ed)
                    {
                        // 得意先(終了)→得意先(開始)
                        e.NextCtrl = this.tNedit_CustomerCode_St;
                    }
                    else if (e.PrevCtrl == this.tEdit_SalesEmployeeCd_St)
                    {
                        // 担当者(開始)→得意先(終了)
                        e.NextCtrl = this.tNedit_CustomerCode_Ed;
                    }
                    else if (e.PrevCtrl == this.tEdit_SalesEmployeeCd_Ed)
                    {
                        // 担当者(終了)→担当者(開始)
                        e.NextCtrl = this.tEdit_SalesEmployeeCd_St;
                    }
                    else if (e.PrevCtrl == this.tEdit_FrontEmployeeCd_St)
                    {
                        // 受注者(開始)→担当者(終了)
                        e.NextCtrl = this.tEdit_SalesEmployeeCd_Ed;
                    }
                    else if (e.PrevCtrl == this.tEdit_FrontEmployeeCd_Ed)
                    {
                        // 受注者(終了)→受注者(開始)
                        e.NextCtrl = this.tEdit_FrontEmployeeCd_St;
                    }
                    else if (e.PrevCtrl == this.tEdit_SalesInputCode_St)
                    {
                        // 発行者(開始)→受注者(終了)
                        e.NextCtrl = this.tEdit_FrontEmployeeCd_Ed;
                    }
                    else if (e.PrevCtrl == this.tEdit_SalesInputCode_Ed)
                    {
                        // 発行者(終了)→発行者(開始)
                        e.NextCtrl = this.tEdit_SalesInputCode_St;
                    }
                    else if (e.PrevCtrl == this.tNedit_RetGoodsReasonDiv_St)
                    {
                        // 返品理由(開始)→発行者(終了)
                        e.NextCtrl = this.tEdit_SalesInputCode_Ed;
                    }
                    else if (e.PrevCtrl == this.tNedit_RetGoodsReasonDiv_Ed)
                    {
                        // 返品理由(終了)→返品理由(開始)
                        e.NextCtrl = this.tNedit_RetGoodsReasonDiv_St;
                    }
                    else if (e.PrevCtrl == this.tComboEditor_SlipKind)
                    {
                        // 伝票種別→返品理由(終了)
                        e.NextCtrl = this.tNedit_RetGoodsReasonDiv_Ed;
                    }
                    else if (e.PrevCtrl == this.tDateEdit_YearMonth)
                    {
                        // 対象年月→対象年月
                        e.NextCtrl = null;
                    }
                    /*----- DEL 2013/03/11 cheq Redmine#34987 ----->>>>>
                    else if (e.PrevCtrl == this.tComboEditor_ChangePg)
                    {
                        // 改頁→対象年月
                        e.NextCtrl = this.tDateEdit_YearMonth.Controls[4];
                    }
                    ----- DEL 2013/03/11 cheq Redmine#34987 -----<<<<<*/
                    //----- ADD 2013/03/11 cheq Redmine#34987 ----->>>>>
                    else if (e.PrevCtrl == this.tComboEditor_ChangePg)
                    {
                        // 改頁→罫線印字
                        e.NextCtrl = this.tComboEditor_LinePrintDiv;
                    }
                    else if (e.PrevCtrl == this.tComboEditor_LinePrintDiv)
                    {
                        // 罫線印字→対象年月
                        e.NextCtrl = this.tDateEdit_YearMonth.Controls[4];
                    }
                    //----- ADD 2013/03/11 cheq Redmine#34987 -----<<<<<
                }
                    // --- ADD 2010/08/12 ----------------------------------<<<<<
            }
            else
            {
                // SHIFTキー押下
                if (e.Key == Keys.Tab)
                {
                    // 伝票種別
                    if (e.PrevCtrl == this.tComboEditor_SlipKind)
                    {
                        // 伝票種別→返品理由(終了)
                        e.NextCtrl = this.tNedit_RetGoodsReasonDiv_Ed;
                    }
                    else if (e.PrevCtrl == this.tNedit_RetGoodsReasonDiv_Ed)
                    {
                        tNedit_RetGoodsReasonDiv_Ed_AfterExitEditMode(e.PrevCtrl, null);
                        // 返品理由(終了)→ 返品理由(開始)
                        e.NextCtrl = this.tNedit_RetGoodsReasonDiv_St;
                    }
                    else if (e.PrevCtrl == this.tNedit_RetGoodsReasonDiv_St)
                    {
                        tNedit_RetGoodsReasonDiv_St_AfterExitEditMode(e.PrevCtrl, null);
                        //返品理由(開始)→ 発行者(終了)
                        e.NextCtrl = this.tEdit_SalesInputCode_Ed;
                    }
                    else if (e.PrevCtrl == this.tEdit_SalesInputCode_Ed)
                    {
                        tEdit_SalesInputCode_Ed_AfterExitEditMode(e.PrevCtrl, null);
                        // 発行者(終了)→発行者(開始)
                        e.NextCtrl = this.tEdit_SalesInputCode_St;
                    }
                    else if (e.PrevCtrl == this.tEdit_SalesInputCode_St)
                    {
                        tEdit_SalesInputCode_St_AfterExitEditMode(e.PrevCtrl, null);
                        // 発行者(開始)→受注者(終了)
                        e.NextCtrl = this.tEdit_FrontEmployeeCd_Ed;
                    }
                    else if (e.PrevCtrl == this.tEdit_FrontEmployeeCd_Ed)
                    {
                        tEdit_FrontEmployeeCd_Ed_AfterExitEditMode(e.PrevCtrl, null);
                        // 受注者(終了)→受注者(開始)
                        e.NextCtrl = this.tEdit_FrontEmployeeCd_St;
                    }
                    else if (e.PrevCtrl == this.tEdit_FrontEmployeeCd_St)
                    {
                        tEdit_FrontEmployeeCd_St_AfterExitEditMode(e.PrevCtrl, null);
                        // 受注者(開始)→担当者(終了)
                        e.NextCtrl = this.tEdit_SalesEmployeeCd_Ed;
                    }
                    else if (e.PrevCtrl == this.tEdit_SalesEmployeeCd_Ed)
                    {
                        tEdit_SalesEmployeeCd_Ed_AfterExitEditMode(e.PrevCtrl, null);
                        // 担当者(終了)→担当者(開始)
                        e.NextCtrl = this.tEdit_SalesEmployeeCd_St;
                    }
                    else if (e.PrevCtrl == this.tEdit_SalesEmployeeCd_St)
                    {
                        tEdit_SalesEmployeeCd_St_AfterExitEditMode(e.PrevCtrl, null);
                        // 担当者(開始)→得意先(終了)
                        e.NextCtrl = this.tNedit_CustomerCode_Ed;
                    }
                    else if (e.PrevCtrl == this.tNedit_CustomerCode_Ed)
                    {
                        tNedit_CustomerCode_Ed_AfterExitEditMode(e.PrevCtrl, null);
                        // 得意先(終了)→得意先(開始)
                        e.NextCtrl = this.tNedit_CustomerCode_St;
                    }
                    else if (e.PrevCtrl == this.tNedit_CustomerCode_St)
                    {
                        tNedit_CustomerCode_St_AfterExitEditMode(e.PrevCtrl, null);
                        // 得意先(開始)→出力順
                        e.NextCtrl = this.tComboEditor_PrintType;
                    }
                    /*----- DEL 2013/01/25 cheq Redmine#34098 ----->>>>> 
                    else if (e.PrevCtrl == this.tComboEditor_PrintType)
                    {
                        // 出力順→改頁
                        e.NextCtrl = this.tComboEditor_ChangePg;
                    }
                     ----- DEL 2013/01/25 cheq Redmine#34098 -----<<<<<*/
                    /*----- DEL 2013/03/11 cheq Redmine#34987 ----->>>>>
                    //----- ADD 2013/01/25 cheq Redmine#34098 ----->>>>>
                    else if (e.PrevCtrl == this.tComboEditor_PrintType)
                    {
                        // 出力順→罫線印字
                        e.NextCtrl = this.tComboEditor_LinePrintDiv;
                    }
                    else if (e.PrevCtrl == this.tComboEditor_LinePrintDiv)
                    {
                        // 罫線印字→改頁
                        e.NextCtrl = this.tComboEditor_ChangePg;
                    }
                    //----- ADD 2013/01/25 cheq Redmine#34098 -----<<<<<
                    else if (e.PrevCtrl == this.tComboEditor_ChangePg)
                    {
                        // 改頁→伝票種別
                        e.NextCtrl = this.tDateEdit_YearMonth;
                    }
                    ----- DEL 2013/03/11 cheq Redmine#34987 -----<<<<<*/
                    //----- ADD 2013/03/11 cheq Redmine#34987 ----->>>>>
                    else if (e.PrevCtrl == this.tComboEditor_PrintType)
                    {
                        // 出力順→改頁
                        e.NextCtrl = this.tComboEditor_ChangePg;
                    }
                    else if (e.PrevCtrl == this.tComboEditor_ChangePg)
                    {
                        // 改頁→罫線印字
                        e.NextCtrl = this.tComboEditor_LinePrintDiv;
                    }
                    else if (e.PrevCtrl == this.tComboEditor_LinePrintDiv)
                    {
                        // 罫線印字→対象年月
                        e.NextCtrl = this.tDateEdit_YearMonth;
                    }
                    //----- ADD 2013/03/11 cheq Redmine#34987 -----<<<<<
                    else if (e.PrevCtrl == this.tDateEdit_YearMonth)
                    {
                        // 対象年月→対象年月
                        e.NextCtrl = null;
                    }
                }
                else if (e.Key == Keys.Enter)
                {
                    //----- ADD 2013/03/11 cheq Redmine#34987 ----->>>>>
                    if (e.PrevCtrl == this.tComboEditor_PrintType)
                    {
                        // 出力順→改頁
                        e.NextCtrl = this.tComboEditor_ChangePg;
                    }
                    else if (e.PrevCtrl == this.tComboEditor_ChangePg)
                    {
                        // 改頁→罫線印字
                        e.NextCtrl = this.tComboEditor_LinePrintDiv;
                    }
                    else if (e.PrevCtrl == this.tComboEditor_LinePrintDiv)
                    {
                        // 罫線印字→対象年月
                        e.NextCtrl = this.tDateEdit_YearMonth;
                    }
                    //----- ADD 2013/03/11 cheq Redmine#34987 -----<<<<<
                    if (e.PrevCtrl == this.tDateEdit_YearMonth)
                    {
                        // 対象年月→対象年月
                        e.NextCtrl = null;
                    }
                }
            }
            // --- ADD 2010/08/12 ---------------------------------->>>>>
            if (e.NextCtrl != null)
            {
                switch (e.NextCtrl.Name)
                {
                    case "tNedit_CustomerCode_St":
                    case "tNedit_CustomerCode_Ed":
                    case "tEdit_SalesEmployeeCd_St":
                    case "tEdit_SalesEmployeeCd_Ed":
                    case "tEdit_FrontEmployeeCd_St":
                    case "tEdit_FrontEmployeeCd_Ed":
                    case "tEdit_SalesInputCode_St":
                    case "tEdit_SalesInputCode_Ed":
                    case "tNedit_RetGoodsReasonDiv_St":
                    case "tNedit_RetGoodsReasonDiv_Ed":
                        {
                            ParentToolbarGuideSettingEvent(true);
                            break;
                        }
                    default:
                        {
                            if (e.NextCtrl.CanSelect || e.NextCtrl is TEdit || e.NextCtrl is TNedit || e.NextCtrl is TComboEditor
                                || e.NextCtrl is TDateEdit || e.NextCtrl is UltraButton)
                            {
                                ParentToolbarGuideSettingEvent(false);
                            }
                            break;
                        }
                }
            }
            // --- ADD 2010/08/12 ----------------------------------<<<<<
        }
        #endregion

        #endregion ◆ PMHNB02210UA

        # region ■ ガイドボタンクリックイベント
        /// <summary>
        /// 得意先ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks> 
        /// <br>Note       : 得意先ガイドをクリックするときに発生する</br> 
        /// <br>Programmer : 呉元嘯</br>                                  
        /// <br>Date       : 2009.05.11</br> 
        /// <br>Update Note: 2010/08/12 caowj</br>
        /// <br>             PM.NS1012対応</br>
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
                // --- DEL 2010/08/12 ---------------------------------->>>>>
                //if (sender == ub_St_CustomerCode)
                //{
                //    this.tNedit_CustomerCode_Ed.Focus();
                //}
                //else
                //{
                //    this.tEdit_SalesEmployeeCd_St.Focus();
                //}
                // --- DEL 2010/08/12 ----------------------------------<<<<<
                // --- ADD 2010/08/12 ---------------------------------->>>>>
                if (sender == ub_St_CustomerCode)
                {
                    this.tNedit_CustomerCode_Ed.Focus();
                    ParentToolbarGuideSettingEvent(true);
                }
                else if (sender == ub_Ed_CustomerCode)
                {
                    this.tEdit_SalesEmployeeCd_St.Focus();
                    ParentToolbarGuideSettingEvent(true);
                }
                else if (sender == tNedit_CustomerCode_St)
                {
                    this.tNedit_CustomerCode_Ed.Focus();
                    ParentToolbarGuideSettingEvent(true);
                }
                else if (sender == tNedit_CustomerCode_Ed)
                {
                    this.tEdit_SalesEmployeeCd_St.Focus();
                    ParentToolbarGuideSettingEvent(true);
                }
                // --- ADD 2010/08/12 ----------------------------------<<<<<
            }

        }

        /// <summary>
        /// 得意先ガイド選択イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="customerSearchRet">customerSearchRet</param>
        /// <remarks> 
        /// <br>Note       : 得意先ガイドをクリックするときに発生する</br> 
        /// <br>Programmer : 呉元嘯</br>                                  
        /// <br>Date       : 2009.05.11</br> 
        /// <br>Update Note: 2010/08/12 caowj</br>
        /// <br>             PM.NS1012対応</br>
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
            // --- DEL 2010/08/12 ---------------------------------->>>>>
            //if (_customerGuideSender == this.ub_St_CustomerCode)
            //{
            //    this.tNedit_CustomerCode_St.SetInt(customerInfo.CustomerCode);
            //}
            //else
            //{
            //    this.tNedit_CustomerCode_Ed.SetInt(customerInfo.CustomerCode);
            //}
            // --- DEL 2010/08/12 ----------------------------------<<<<<
            // --- ADD 2010/08/12 ---------------------------------->>>>>
            if (_customerGuideSender != null)
            {
                if (_customerGuideSender == this.ub_St_CustomerCode)
                {
                    this.tNedit_CustomerCode_St.SetInt(customerInfo.CustomerCode);
                }
                else
                {
                    this.tNedit_CustomerCode_Ed.SetInt(customerInfo.CustomerCode);
                }
            }
            else
            {
                if (this._customerCodeSt)
                {
                    this.tNedit_CustomerCode_St.SetInt(customerInfo.CustomerCode);
                }
                else
                {
                    this.tNedit_CustomerCode_Ed.SetInt(customerInfo.CustomerCode);
                }
            }
            // --- ADD 2010/08/12 ----------------------------------<<<<<
            _customerGuideOK = true;
        }

        /// <summary>
        /// 担当者ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks> 
        /// <br>Note       : 担当者ガイドをクリックするときに発生する</br> 
        /// <br>Programmer : 呉元嘯</br>                                  
        /// <br>Date       : 2009.05.11</br> 
        /// <br>Update Note: 2010/08/12 caowj</br>
        /// <br>             PM.NS1012対応</br>
        /// </remarks>
        private void ub_St_SalesEmployeeCd_Click(object sender, EventArgs e)
        {
            if (this._employeeAcs == null)
            {
                this._employeeAcs = new EmployeeAcs();
            }
            // ガイド起動
            Employee employee;
            int status = this._employeeAcs.ExecuteGuid(this._enterpriseCode, true, out employee);
            // 項目に展開
            // --- DEL 2010/08/12 ---------------------------------->>>>>
            //if (status == 0)
            //{
            //    if (sender == this.ub_St_SalesEmployeeCd)
            //    {
            //        this.tEdit_SalesEmployeeCd_St.DataText = employee.EmployeeCode.TrimEnd();
            //        this.tEdit_SalesEmployeeCd_Ed.Focus();
            //    }
            //    else
            //    {
            //        this.tEdit_SalesEmployeeCd_Ed.DataText = employee.EmployeeCode.TrimEnd();
            //        this.tEdit_FrontEmployeeCd_St.Focus();
            //    }
            //}
            // --- DEL 2010/08/12 ----------------------------------<<<<<
            // --- ADD 2010/08/12 ---------------------------------->>>>>
            if (sender is Infragistics.Win.Misc.UltraButton)
            {
                if (status == 0)
                {
                    if (sender == this.ub_St_SalesEmployeeCd)
                    {
                        this.tEdit_SalesEmployeeCd_St.DataText = employee.EmployeeCode.TrimEnd();
                        this.tEdit_SalesEmployeeCd_Ed.Focus();
                        ParentToolbarGuideSettingEvent(true);
                    }
                    else
                    {
                        this.tEdit_SalesEmployeeCd_Ed.DataText = employee.EmployeeCode.TrimEnd();
                        this.tEdit_FrontEmployeeCd_St.Focus();
                        ParentToolbarGuideSettingEvent(true);
                    }
                }
            }
            else
            {
                if (tEdit_SalesEmployeeCd_St.Focused)
                {
                    this.tEdit_SalesEmployeeCd_St.DataText = employee.EmployeeCode.TrimEnd();
                    this.tEdit_SalesEmployeeCd_Ed.Focus();
                    ParentToolbarGuideSettingEvent(true);
                }
                else
                {
                    this.tEdit_SalesEmployeeCd_Ed.DataText = employee.EmployeeCode.TrimEnd();
                    this.tEdit_FrontEmployeeCd_St.Focus();
                    ParentToolbarGuideSettingEvent(true);
                }
            }
            // --- ADD 2010/08/12 ----------------------------------<<<<<
        }

        /// <summary>
        /// 受注者ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks> 
        /// <br>Note       : 受注者ガイドをクリックするときに発生する</br> 
        /// <br>Programmer : 呉元嘯</br>                                  
        /// <br>Date       : 2009.05.11</br> 
        /// <br>Update Note: 2010/08/12 caowj</br>
        /// <br>             PM.NS1012対応</br>
        /// </remarks>
        private void ub_St_FrontEmployeeCd_Click(object sender, EventArgs e)
        {
            if (this._employeeAcs == null)
            {
                this._employeeAcs = new EmployeeAcs();
            }
            // ガイド起動
            Employee employee;
            int status = this._employeeAcs.ExecuteGuid(this._enterpriseCode, true, out employee);

            // 項目に展開
            // --- DEL 2010/08/12 ---------------------------------->>>>>
            //if (status == 0)
            //{
            //    if (sender == this.ub_St_FrontEmployeeCd)
            //    {
            //        this.tEdit_FrontEmployeeCd_St.DataText = employee.EmployeeCode.TrimEnd();
            //        this.tEdit_FrontEmployeeCd_Ed.Focus();
            //    }
            //    else
            //    {
            //        this.tEdit_FrontEmployeeCd_Ed.DataText = employee.EmployeeCode.TrimEnd();
            //        this.tEdit_SalesInputCode_St.Focus();
            //    }
            //}
            // --- DEL 2010/08/12 ----------------------------------<<<<<
            // --- ADD 2010/08/12 ---------------------------------->>>>>
            if (sender is Infragistics.Win.Misc.UltraButton)
            {
                if (status == 0)
                {
                    if (sender == this.ub_St_FrontEmployeeCd)
                    {
                        this.tEdit_FrontEmployeeCd_St.DataText = employee.EmployeeCode.TrimEnd();
                        this.tEdit_FrontEmployeeCd_Ed.Focus();
                        ParentToolbarGuideSettingEvent(true);
                    }
                    else
                    {
                        this.tEdit_FrontEmployeeCd_Ed.DataText = employee.EmployeeCode.TrimEnd();
                        this.tEdit_SalesInputCode_St.Focus();
                        ParentToolbarGuideSettingEvent(true);
                    }
                }
            }
            else
            {
                if (tEdit_FrontEmployeeCd_St.Focused)
                {
                    this.tEdit_FrontEmployeeCd_St.DataText = employee.EmployeeCode.TrimEnd();
                    this.tEdit_FrontEmployeeCd_Ed.Focus();
                    ParentToolbarGuideSettingEvent(true);
                }
                else
                {
                    this.tEdit_FrontEmployeeCd_Ed.DataText = employee.EmployeeCode.TrimEnd();
                    this.tEdit_SalesInputCode_St.Focus();
                    ParentToolbarGuideSettingEvent(true);
                }
            }
            // --- ADD 2010/08/12 ----------------------------------<<<<<

        }

        /// <summary>
        /// 発行者ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks> 
        /// <br>Note       : 発行者ガイドをクリックするときに発生する</br> 
        /// <br>Programmer : 呉元嘯</br>                                  
        /// <br>Date       : 2009.05.11</br>
        /// <br>Update Note: 2010/08/12 caowj</br>
        /// <br>             PM.NS1012対応</br>
        /// </remarks>
        private void ub_St_SalesInputCode_Click(object sender, EventArgs e)
        {
            if (this._employeeAcs == null)
            {
                this._employeeAcs = new EmployeeAcs();
            }
            // ガイド起動
            Employee employee;
            int status = this._employeeAcs.ExecuteGuid(this._enterpriseCode, true, out employee);

            // 項目に展開
            // --- DEL 2010/08/12 ---------------------------------->>>>>
            //if (status == 0)
            //{
            //    if (sender == this.ub_St_SalesInputCode)
            //    {
            //        this.tEdit_SalesInputCode_St.DataText = employee.EmployeeCode.TrimEnd();
            //        this.tEdit_SalesInputCode_Ed.Focus();
            //    }
            //    else
            //    {
            //        this.tEdit_SalesInputCode_Ed.DataText = employee.EmployeeCode.TrimEnd();
            //        this.tNedit_RetGoodsReasonDiv_St.Focus();
            //    }
            //}
            // --- DEL 2010/08/12 ----------------------------------<<<<<
            // --- ADD 2010/08/12 ---------------------------------->>>>>
            if (sender is Infragistics.Win.Misc.UltraButton)
            {
                if (status == 0)
                {
                    if (sender == this.ub_St_SalesInputCode)
                    {
                        this.tEdit_SalesInputCode_St.DataText = employee.EmployeeCode.TrimEnd();
                        this.tEdit_SalesInputCode_Ed.Focus();
                        ParentToolbarGuideSettingEvent(true);
                    }
                    else
                    {
                        this.tEdit_SalesInputCode_Ed.DataText = employee.EmployeeCode.TrimEnd();
                        this.tNedit_RetGoodsReasonDiv_St.Focus();
                        ParentToolbarGuideSettingEvent(true);
                    }
                }
            }
            else
            {
                if (tEdit_SalesInputCode_St.Focused)
                {
                    this.tEdit_SalesInputCode_St.DataText = employee.EmployeeCode.TrimEnd();
                    this.tEdit_SalesInputCode_Ed.Focus();
                    ParentToolbarGuideSettingEvent(true);
                }
                else
                {
                    this.tEdit_SalesInputCode_Ed.DataText = employee.EmployeeCode.TrimEnd();
                    this.tNedit_RetGoodsReasonDiv_St.Focus();
                    ParentToolbarGuideSettingEvent(true);
                }
            }
            // --- ADD 2010/08/12 ----------------------------------<<<<<

        }

        /// <summary>
        /// 返品理由ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks> 
        /// <br>Note       : 返品理由ガイドをクリックするときに発生する</br> 
        /// <br>Programmer : 呉元嘯</br>                                  
        /// <br>Date       : 2009.05.11</br> 
        /// <br>Update Note: 2010/08/12 caowj</br>
        /// <br>             PM.NS1012対応</br>
        /// </remarks>
        private void ub_St_RetGoodsReasonDiv_Click(object sender, EventArgs e)
        {
            // ガイド起動
            UserGuideAcs userGuideAcs = new UserGuideAcs();
            UserGdHd userGdHd;
            UserGdBd userGdBd;


            if (userGuideAcs.ExecuteGuid(this._enterpriseCode, out userGdHd, out userGdBd, PMHNB02210UA.DIVCODE_UserGuideDivCd_RetGoodsReason) == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // 項目に展開
                // --- DEL 2010/08/12 ---------------------------------->>>>>
                //if (sender == this.ub_St_RetGoodsReasonDiv)
                //{
                //    this.tNedit_RetGoodsReasonDiv_St.DataText = userGdBd.GuideCode.ToString().TrimEnd().PadLeft(4, '0');
                //    this.tNedit_RetGoodsReasonDiv_Ed.Focus();
                //}
                //else
                //{
                //    this.tNedit_RetGoodsReasonDiv_Ed.DataText = userGdBd.GuideCode.ToString().TrimEnd().PadLeft(4, '0');
                //    this.tComboEditor_SlipKind.Focus();
                //}
                // --- DEL 2010/08/12 ----------------------------------<<<<<
                // --- ADD 2010/08/12 ---------------------------------->>>>>
                if (sender is Infragistics.Win.Misc.UltraButton)
                {
                    if (sender == this.ub_St_RetGoodsReasonDiv)
                    {
                        this.tNedit_RetGoodsReasonDiv_St.DataText = userGdBd.GuideCode.ToString().TrimEnd().PadLeft(4, '0');
                        this.tNedit_RetGoodsReasonDiv_Ed.Focus();
                        ParentToolbarGuideSettingEvent(true);
                    }
                    else
                    {
                        this.tNedit_RetGoodsReasonDiv_Ed.DataText = userGdBd.GuideCode.ToString().TrimEnd().PadLeft(4, '0');
                        this.tComboEditor_SlipKind.Focus();
                        ParentToolbarGuideSettingEvent(false);
                    }
                }
                else
                {
                    if (tNedit_RetGoodsReasonDiv_St.Focused)
                    {
                        this.tNedit_RetGoodsReasonDiv_St.DataText = userGdBd.GuideCode.ToString().TrimEnd().PadLeft(4, '0');
                        this.tNedit_RetGoodsReasonDiv_Ed.Focus();
                        ParentToolbarGuideSettingEvent(true);
                    }
                    else
                    {
                        this.tNedit_RetGoodsReasonDiv_Ed.DataText = userGdBd.GuideCode.ToString().TrimEnd().PadLeft(4, '0');
                        this.tComboEditor_SlipKind.Focus();
                        ParentToolbarGuideSettingEvent(false);
                    }
                }
                // --- ADD 2010/08/12 ----------------------------------<<<<<
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
        /// <br>Programmer : 呉元嘯</br>                                  
        /// <br>Date       : 2009.05.11</br> 
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
        /// <br>Programmer : 呉元嘯</br>                                  
        /// <br>Date       : 2009.05.11</br> 
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

        /// <summary>
        /// AfterExitEditMode イベント処理イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : 担当者コード開始フォーカスが離れたときに発生します。</br>      
        /// <br>Programmer : 呉元嘯</br>                                  
        /// <br>Date       : 2009.05.11</br> 
        /// </remarks> 
        private void tEdit_SalesEmployeeCd_St_AfterExitEditMode(object sender, EventArgs e)
        {
            // 担当者コード開始の値は数字ではない場合
            if (!hkCheck(this.tEdit_SalesEmployeeCd_St.Text))
            {
                this.tEdit_SalesEmployeeCd_St.Text = string.Empty;
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
        /// <br>Note       : 担当者コード終了フォーカスが離れたときに発生します。</br>      
        /// <br>Programmer : 呉元嘯</br>                                  
        /// <br>Date       : 2009.05.11</br> 
        /// </remarks> 
        private void tEdit_SalesEmployeeCd_Ed_AfterExitEditMode(object sender, EventArgs e)
        {
            // 担当者コード終了の値は数字ではない場合

            if (!hkCheck(this.tEdit_SalesEmployeeCd_Ed.Text))
            {
                this.tEdit_SalesEmployeeCd_Ed.Text = string.Empty;
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
        /// <br>Note       : 受注者コード開始フォーカスが離れたときに発生します。</br>      
        /// <br>Programmer : 呉元嘯</br>                                  
        /// <br>Date       : 2009.05.11</br> 
        /// </remarks> 
        private void tEdit_FrontEmployeeCd_St_AfterExitEditMode(object sender, EventArgs e)
        {
            // 受注者コード開始の値は数字ではない場合
            if (!hkCheck(this.tEdit_FrontEmployeeCd_St.Text))
            {
                this.tEdit_FrontEmployeeCd_St.Text = string.Empty;
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
        /// <br>Note       : 受注者コード終了フォーカスが離れたときに発生します。</br>      
        /// <br>Programmer : 呉元嘯</br>                                  
        /// <br>Date       : 2009.05.11</br> 
        /// </remarks> 
        private void tEdit_FrontEmployeeCd_Ed_AfterExitEditMode(object sender, EventArgs e)
        {
            // 受注者コード終了の値は数字ではない場合
            if (!hkCheck(this.tEdit_FrontEmployeeCd_Ed.Text))
            {
                this.tEdit_FrontEmployeeCd_Ed.Text = string.Empty;
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
        /// <br>Note       : 発行者コード開始フォーカスが離れたときに発生します。</br>      
        /// <br>Programmer : 呉元嘯</br>                                  
        /// <br>Date       : 2009.05.11</br> 
        /// </remarks> 
        private void tEdit_SalesInputCode_St_AfterExitEditMode(object sender, EventArgs e)
        {
            // 発行者コード開始の値は数字ではない場合
            if (!hkCheck(this.tEdit_SalesInputCode_St.Text))
            {
                this.tEdit_SalesInputCode_St.Text = string.Empty;
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
        /// <br>Note       : 発行者コード終了フォーカスが離れたときに発生します。</br>      
        /// <br>Programmer : 呉元嘯</br>                                  
        /// <br>Date       : 2009.05.11</br> 
        /// </remarks> 
        private void tEdit_SalesInputCode_Ed_AfterExitEditMode(object sender, EventArgs e)
        {
            // 発行者コード終了の値は数字ではない場合
            if (!hkCheck(this.tEdit_SalesInputCode_Ed.Text))
            {
                this.tEdit_SalesInputCode_Ed.Text = string.Empty;
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
        /// <br>Note       : 返品理由コード開始フォーカスが離れたときに発生します。</br>      
        /// <br>Programmer : 呉元嘯</br>                                  
        /// <br>Date       : 2009.05.11</br> 
        /// </remarks> 
        private void tNedit_RetGoodsReasonDiv_St_AfterExitEditMode(object sender, EventArgs e)
        {
            // 返品理由コード開始の値は数字ではない場合
            if (0 == this.tNedit_RetGoodsReasonDiv_St.GetInt())
            {
                this.tNedit_RetGoodsReasonDiv_St.Text = string.Empty;
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
        /// <br>Note       : 返品理由コード終了フォーカスが離れたときに発生します。</br>      
        /// <br>Programmer : 呉元嘯</br>                                  
        /// <br>Date       : 2009.05.11</br> 
        /// </remarks> 
        private void tNedit_RetGoodsReasonDiv_Ed_AfterExitEditMode(object sender, EventArgs e)
        {
            // 返品理由コード終了の値は数字ではない場合
            if (0 == this.tNedit_RetGoodsReasonDiv_Ed.GetInt())
            {
                this.tNedit_RetGoodsReasonDiv_Ed.Text = string.Empty;
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
        /// <br>Programmer  : 呉元嘯</br>
        /// <br>Date        : 2009.05.14</br>
        /// <br>Update Note : 2013/01/25 cheq</br>
        /// <br>管理番号    : 10806793-00 2013/03/13配信分</br>
        /// <br>              Redmine#34098 罫線印字制御の追加対応</br>
        /// </remarks>
        private int InitializeScreen(out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            errMsg = string.Empty;
            
            try
            {
                // 対象年月
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
                totalDayCalculator.InitializeHisMonthlyAccRec();
                totalDayCalculator.GetHisTotalDayMonthlyAccRec(string.Empty, out prevTotalDay, out currentTotalDay, out prevTotalMonth, out currentTotalMonth, out convertProcessDivCd);

                if (currentTotalDay != DateTime.MinValue)
                {
                    // 対象年月を設定
                    this.tDateEdit_YearMonth.SetDateTime(currentTotalMonth);
                    // 前回締処理日を設定
                    // this._henbiRiyuListReport.StartYearDate = prevTotalDay;// DEL 2007/07/13
                    this._henbiRiyuListReport.StartYearDate = prevTotalDay.AddDays(1.0);// ADD 2007/07/13
                    // 今回締処理日を設定
                    this._henbiRiyuListReport.EndYearDate = currentTotalDay;
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
                    // 年月度開始日を設定
                    // this._henbiRiyuListReport.StartYearDate = startYearDate;// DEL 2009/07/13
                    this._henbiRiyuListReport.StartYearDate = startMonthDate;// ADD 2009/07/15
                    // 年月度開始日を設定
                    // this._henbiRiyuListReport.EndYearDate = endYearDate;// DEL 2009/07/15 WUYX PVCS337
                    this._henbiRiyuListReport.EndYearDate = endMonthDate;// ADD 2009/07/15 WUYX PVCS337
                }

                /*---------DEL 2009/07/13 PVCS326-------->>>>>
                // 対象年月:入力不可
                this.tDateEdit_YearMonth.Enabled = false;
                ---------DEL 2009/07/13 PVCS326--------<<<<<*/

                // ------ADD 2007/07/13 PVCS326----->>>>>
                // 保存初期化した対象年月
                _thisYearMonthClone = tDateEdit_YearMonth.GetDateTime().ToString("yyyyMM");
                // ------ADD 2007/07/13 PVCS326-----<<<<<

                // 改ページ
                if (this.tComboEditor_ChangePg.Value == null)
                {
                    this.tComboEditor_ChangePg.Value = 0;  // DEF：拠点
                }
                // 出力順
                if (this.tComboEditor_PrintType.Value == null)
                {
                    this.tComboEditor_PrintType.Value = 0;   // DEF:0:返品理由別
                }
                // 伝票種別
                if (this.tComboEditor_SlipKind.Value == null)
                {
                    this.tComboEditor_SlipKind.Value = 0;   // DEF:0:売上
                }
                //----- ADD 2013/01/25 cheq Redmine#34098 ----->>>>>
                //罫線印字
                if (this.tComboEditor_LinePrintDiv.Value == null)
                {
                    this.tComboEditor_LinePrintDiv.Value = 0;   // DEF:0:印字する
                }
                //----- ADD 2013/01/25 cheq Redmine#34098 -----<<<<<
                // ボタン設定
                this.SetIconImage(this.ub_St_CustomerCode, Size16_Index.STAR1);
                this.SetIconImage(this.ub_St_FrontEmployeeCd, Size16_Index.STAR1);
                this.SetIconImage(this.ub_St_RetGoodsReasonDiv, Size16_Index.STAR1);
                this.SetIconImage(this.ub_St_SalesEmployeeCd, Size16_Index.STAR1);
                this.SetIconImage(this.ub_St_SalesInputCode, Size16_Index.STAR1);
                this.SetIconImage(this.ub_Ed_CustomerCode, Size16_Index.STAR1);
                this.SetIconImage(this.ub_Ed_FrontEmployeeCd, Size16_Index.STAR1);
                this.SetIconImage(this.ub_Ed_RetGoodsReasonDiv, Size16_Index.STAR1);
                this.SetIconImage(this.ub_Ed_SalesEmployeeCd, Size16_Index.STAR1);
                this.SetIconImage(this.ub_Ed_SalesInputCode, Size16_Index.STAR1);

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
        /// <br>Programmer  : 呉元嘯</br>
        /// <br>Date        : 2009.05.14</br>
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
        /// <br>Programmer  : 呉元嘯</br>
        /// <br>Date        : 2009.05.14</br>
        /// </remarks>
        private bool ScreenInputCheck(ref string errMessage, ref Control errComponent)
        {
            const string ct_RangeError = "の範囲に誤りがあります。";
            const string ct_NoInputError = "を入力してください。"; // ADD 2007/07/13 PVCS326
            const string ct_InputError = "が不正です。";// ADD 2007/07/13 PVCS326

            bool status = true;
            //--------ADD ADD 2007/07/13 PVCS326------>>>>>
            int longDate = this.tDateEdit_YearMonth.LongDate;
            longDate = (longDate / 100) * 100 + 1;
            this.tDateEdit_YearMonth.SetLongDate(longDate);
            if (this.tDateEdit_YearMonth.GetDateYear() == 0 && this.tDateEdit_YearMonth.GetDateMonth() == 0)
            {
                errMessage = string.Format("対象年月{0}", ct_NoInputError);
                errComponent = this.tDateEdit_YearMonth;
                status = false;
            }
            else if ((this.tDateEdit_YearMonth.LongDate != 0) && this.tDateEdit_YearMonth.GetDateTime() == DateTime.MinValue)
            {
                errMessage = string.Format("対象年月{0}", ct_InputError);
                errComponent = this.tDateEdit_YearMonth;
                status = false;
            }
            //-------ADD ADD 2007/07/13 PVCS326------<<<<<
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
                (this.tEdit_SalesEmployeeCd_St.DataText.TrimEnd() != string.Empty) &&
                (this.tEdit_SalesEmployeeCd_Ed.DataText.TrimEnd() != string.Empty) &&
                (this.tEdit_SalesEmployeeCd_St.DataText.TrimEnd().CompareTo(this.tEdit_SalesEmployeeCd_Ed.DataText.TrimEnd()) > 0))
            {
                errMessage = string.Format("担当者コード{0}", ct_RangeError);
                errComponent = this.tEdit_SalesEmployeeCd_St;
                status = false;
            }
            else if (
                (this.tEdit_FrontEmployeeCd_St.DataText.TrimEnd() != string.Empty) &&
                (this.tEdit_FrontEmployeeCd_Ed.DataText.TrimEnd() != string.Empty) &&
      (this.tEdit_FrontEmployeeCd_St.DataText.TrimEnd().CompareTo(this.tEdit_FrontEmployeeCd_Ed.DataText.TrimEnd()) > 0))
            {
                errMessage = string.Format("受注者コード{0}", ct_RangeError);
                errComponent = this.tEdit_FrontEmployeeCd_St;
                status = false;
            }
            else if (
                (this.tEdit_SalesInputCode_St.DataText.TrimEnd() != string.Empty) &&
                (this.tEdit_SalesInputCode_Ed.DataText.TrimEnd() != string.Empty) &&
      (this.tEdit_SalesInputCode_St.DataText.TrimEnd().CompareTo(this.tEdit_SalesInputCode_Ed.DataText.TrimEnd()) > 0))
            {
                errMessage = string.Format("発行者コード{0}", ct_RangeError);
                errComponent = this.tEdit_SalesInputCode_St;
                status = false;
            }
            else if (
                (this.tNedit_RetGoodsReasonDiv_St.DataText.TrimEnd() != string.Empty) &&
                (this.tNedit_RetGoodsReasonDiv_Ed.DataText.TrimEnd() != string.Empty) &&
      (this.tNedit_RetGoodsReasonDiv_St.DataText.TrimEnd().CompareTo(this.tNedit_RetGoodsReasonDiv_Ed.DataText.TrimEnd()) > 0))
            {
                errMessage = string.Format("返品理由コード{0}", ct_RangeError);
                errComponent = this.tNedit_RetGoodsReasonDiv_St;
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
        /// <br>Programmer  : 呉元嘯</br>
        /// <br>Date        : 2009.05.14</br>
        /// <br>Update Note : 2013/01/25 cheq</br>
        /// <br>管理番号    : 10806793-00 2013/03/13配信分</br>
        /// <br>              Redmine#34098 罫線印字制御の追加対応</br>
        /// </remarks>
        private int SetExtraInfoFromScreen()
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            try
            {
                // 企業コード
                this._henbiRiyuListReport.EnterpriseCode = this._enterpriseCode;
                // 拠点オプションありのとき
                if (IsOptSection)
                {
                    ArrayList secList = new ArrayList();
                    // 全社選択かどうか
                    if ((this._selectedSectionList.Count == 1) && (this._selectedSectionList.ContainsKey("0")))
                    {
                        _henbiRiyuListReport.SectionCodes = new string[0];
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
                        _henbiRiyuListReport.SectionCodes = (string[])secList.ToArray(typeof(string));
                    }
                }
                // 拠点オプションなしの時
                else
                {
                    _henbiRiyuListReport.SectionCodes = new string[0];
                }
                // 対象年月
                int longDate = this.tDateEdit_YearMonth.LongDate;
                longDate = (longDate / 100) * 100 + 1;
                this.tDateEdit_YearMonth.SetLongDate(longDate);
                this._henbiRiyuListReport.SalesDate = this.tDateEdit_YearMonth.GetDateTime();

                //---------ADD 2007/07/13 PVCS326-------->>>>>
                if (this.tDateEdit_YearMonth.GetDateTime().ToString("yyyyMM") != _thisYearMonthClone)
                {
                    DateTime startMonthDate, endMonthDate;
                    this._dateGet.GetDaysFromMonth(this._henbiRiyuListReport.SalesDate, out startMonthDate, out endMonthDate);
                    // 年度開始日を設定
                    this._henbiRiyuListReport.StartYearDate = startMonthDate;
                    // 年度終了日を設定
                    this._henbiRiyuListReport.EndYearDate = endMonthDate;

                }
                //---------ADD 2007/07/13 PVCS326--------<<<<<

                //改頁
                this._henbiRiyuListReport.ChangePageDiv = Convert.ToInt32(this.tComboEditor_ChangePg.Value);
                // 出力順
                this._henbiRiyuListReport.PrintType = Convert.ToInt32(this.tComboEditor_PrintType.Value);
                //----- ADD 2013/01/25 cheq Redmine#34098 ----->>>>>
                // 罫線印字
                this._henbiRiyuListReport.LinePrintDiv = Convert.ToInt32(this.tComboEditor_LinePrintDiv.Value);
                //----- ADD 2013/01/25 cheq Redmine#34098 -----<<<<<

                // 得意先開始
                if (0 == this.tNedit_CustomerCode_St.GetInt())
                {
                    this._henbiRiyuListReport.CustomerCodeSt = string.Empty;
                }
                else
                {
                    this._henbiRiyuListReport.CustomerCodeSt = this.tNedit_CustomerCode_St.GetInt().ToString("D8");
                }
                // 得意先終了
                if (0 == this.tNedit_CustomerCode_Ed.GetInt())
                {
                    this._henbiRiyuListReport.CustomerCodeEd = string.Empty;
                }
                else
                {
                    this._henbiRiyuListReport.CustomerCodeEd = this.tNedit_CustomerCode_Ed.GetInt().ToString("D8");
                }

                // 担当者開始
                this._henbiRiyuListReport.SalesEmployeeCdRFSt = this.tEdit_SalesEmployeeCd_St.DataText;
                // 担当者終了   
                this._henbiRiyuListReport.SalesEmployeeCdRFEd = this.tEdit_SalesEmployeeCd_Ed.DataText;
                // 受注者開始
                this._henbiRiyuListReport.FrontEmployeeCdRFSt = this.tEdit_FrontEmployeeCd_St.DataText;
                // 受注者終了
                this._henbiRiyuListReport.FrontEmployeeCdRFEd = this.tEdit_FrontEmployeeCd_Ed.DataText;
                // 発行者開始
                this._henbiRiyuListReport.SalesInputCdRFSt = this.tEdit_SalesInputCode_St.DataText;
                // 発行者終了
                this._henbiRiyuListReport.SalesInputCdRFEd = this.tEdit_SalesInputCode_Ed.DataText;
                // 返品理由開始
                if (0 == this.tNedit_RetGoodsReasonDiv_St.GetInt())
                {
                    this._henbiRiyuListReport.RetGoodsReasonDivSt = string.Empty;
                }
                else
                {
                    this._henbiRiyuListReport.RetGoodsReasonDivSt = this.tNedit_RetGoodsReasonDiv_St.GetInt().ToString("D4");
                }
                // 返品理由終了
                if (0 == this.tNedit_RetGoodsReasonDiv_Ed.GetInt())
                {
                    this._henbiRiyuListReport.RetGoodsReasonDivEd = string.Empty;
                }
                else
                {
                    this._henbiRiyuListReport.RetGoodsReasonDivEd = this.tNedit_RetGoodsReasonDiv_Ed.GetInt().ToString("D4");
                }

                // 伝票種別
                this._henbiRiyuListReport.SlipKindCd = Convert.ToInt32(this.tComboEditor_SlipKind.Value);

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
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.05.14</br>
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
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        private void Main_ultraExplorerBar_GroupCollapsing(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
        {
            if ((e.Group.Key == "ReportSelectGroup") ||
                (e.Group.Key == "ReportType") ||
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
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        private void Main_ultraExplorerBar_GroupExpanding(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
        {
            if ((e.Group.Key == "ReportSelectGroup") ||
                (e.Group.Key == "ReportType") ||
                (e.Group.Key == "PrintConditionGroup"))
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
        /// <br>Programmer	: 呉元嘯</br>
        /// <br>Date		: 2009.05.11</br>
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
        /// <br>Programmer	: 呉元嘯</br>
        /// <br>Date		: 2009.05.11</br>
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
        /// <br>Programmer	: 呉元嘯</br>
        /// <br>Date		: 2009.05.11</br>
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
        /// <br>Programmer	: 呉元嘯</br>
        /// <br>Date		: 2009.05.11</br>
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
        /// <br>Note	　 : UI保存コンポーネント読込みイベント</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.05.25</br>
        /// <br>Update Note: 2013/01/25 cheq</br>
        /// <br>管理番号   : 10806793-00 2013/03/13配信分</br>
        /// <br>              Redmine#34098 罫線印字制御の追加対応</br>
        /// </remarks>
        private void uiMemInput1_CustomizeRead(Control[] targetControls, string[] customizeData)
        {
            //if (customizeData.Length > 0 && customizeData.Length == 13) // DEL cheq 2013/01/25 Redmine#34098 
            if (customizeData.Length > 0 && customizeData.Length == 14) // ADD cheq 2013/01/25 Redmine#34098 
            {
                // 改頁
                if (customizeData[0] == "0")
                {
                    this.tComboEditor_ChangePg.Value = 0;

                }
                else if (customizeData[0] == "1")
                {
                    this.tComboEditor_ChangePg.Value = 1;
                }
                else if (customizeData[0] == "2")
                {
                    this.tComboEditor_ChangePg.Value = 2;
                }
                // 出力順
                if (customizeData[1] == "0")
                {
                    this.tComboEditor_PrintType.Value = 0;

                }
                else if (customizeData[1] == "1")
                {
                    this.tComboEditor_PrintType.Value = 1;
                }
                else if (customizeData[1] == "2")
                {
                    this.tComboEditor_PrintType.Value = 2;
                }
                else if (customizeData[1] == "3")
                {
                    this.tComboEditor_PrintType.Value = 3;
                }
                else if (customizeData[1] == "4")
                {
                    this.tComboEditor_PrintType.Value = 4;
                }
                // 得意先
                this.tNedit_CustomerCode_St.DataText = customizeData[2];
                this.tNedit_CustomerCode_Ed.DataText = customizeData[3];
                // 担当者
                this.tEdit_SalesEmployeeCd_St.DataText = customizeData[4];
                this.tEdit_SalesEmployeeCd_Ed.DataText = customizeData[5];
                // 受注者
                this.tEdit_FrontEmployeeCd_St.DataText = customizeData[6];
                this.tEdit_FrontEmployeeCd_Ed.DataText = customizeData[7];
                // 発行者
                this.tEdit_SalesInputCode_St.DataText = customizeData[8];
                this.tEdit_SalesInputCode_Ed.DataText = customizeData[9];
                // 返品理由
                this.tNedit_RetGoodsReasonDiv_St.DataText = customizeData[10];
                this.tNedit_RetGoodsReasonDiv_Ed.DataText = customizeData[11];
                // 伝票種別
                if (customizeData[12] == "0")
                {
                    this.tComboEditor_SlipKind.Value = 0;

                }
                else if (customizeData[12] == "1")
                {
                    this.tComboEditor_SlipKind.Value = 1;
                }
                //----- ADD 2013/01/25 cheq Redmine#34098 ----->>>>> 
                //罫線印字
                if (customizeData[13] == "0")
                {
                    this.tComboEditor_LinePrintDiv.Value = 0;
                }
                else if (customizeData[13] == "1")
                {
                    this.tComboEditor_LinePrintDiv.Value = 1;
                }
                else if (customizeData[13] == "2")
                {
                    this.tComboEditor_LinePrintDiv.Value = 2;
                }
                else
                { }
                //----- ADD 2013/01/25 cheq Redmine#34098 -----<<<<<
            }
        }

        /// <remarks>
        /// <br>Update Note: 2013/01/25 cheq</br>
        /// <br>管理番号   : 10806793-00 2013/03/13配信分</br>
        /// <br>              Redmine#34098 罫線印字制御の追加対応</br>
        /// </remarks>
        private void uiMemInput1_CustomizeWrite(Control[] targetControls, out string[] customizeData)
        {
            //customizeData = new string[13]; // DEL cheq 2013/01/25 Redmine#34098 
            customizeData = new string[14]; // ADD cheq 2013/01/25 Redmine#34098 

            // 改頁
            if (tComboEditor_ChangePg.SelectedIndex == 0)
            {
               customizeData[0] = "0";
            }
            else if (tComboEditor_ChangePg.SelectedIndex == 1)
            {
                customizeData[0] = "1";
            }
            else if (tComboEditor_ChangePg.SelectedIndex == 2)
            {
                customizeData[0] = "2";
            }
            // 出力順
            if (tComboEditor_PrintType.SelectedIndex == 0)
            {
               customizeData[1] = "0";
            }
            else if (tComboEditor_PrintType.SelectedIndex == 1)
            {
                customizeData[1] = "1";
            }
            else if (tComboEditor_PrintType.SelectedIndex == 2)
            {
                customizeData[1] = "2";
            }
            else if (tComboEditor_PrintType.SelectedIndex == 3)
            {
                customizeData[1] = "3";
            }
            else if (tComboEditor_PrintType.SelectedIndex == 4)
            {
                customizeData[1] = "4";
            }
　　　　　　// 得意先
            customizeData[2] = this.tNedit_CustomerCode_St.DataText;
            customizeData[3] = this.tNedit_CustomerCode_Ed.DataText;
            // 担当者
            customizeData[4] = this.tEdit_SalesEmployeeCd_St.DataText;
            customizeData[5] = this.tEdit_SalesEmployeeCd_Ed.DataText;
            // 受注者
            customizeData[6] = this.tEdit_FrontEmployeeCd_St.DataText;
            customizeData[7] = this.tEdit_FrontEmployeeCd_Ed.DataText;
            // 発行者
            customizeData[8] = this.tEdit_SalesInputCode_St.DataText;
            customizeData[9] = this.tEdit_SalesInputCode_Ed.DataText;
            // 返品理由
            customizeData[10] = this.tNedit_RetGoodsReasonDiv_St.DataText;
            customizeData[11] = this.tNedit_RetGoodsReasonDiv_Ed.DataText;
            // 伝票種別
            if (tComboEditor_SlipKind.SelectedIndex == 0)
            {
                customizeData[12] = "0";
            }
            else if (tComboEditor_SlipKind.SelectedIndex == 1)
            {
                customizeData[12] = "1";
            }
            //----- ADD 2013/01/25 cheq Redmine#34098 ----->>>>> 
            // 罫線印字
            if (tComboEditor_LinePrintDiv.SelectedIndex == 0)
            {
                customizeData[13] = "0";
            }
            else if (tComboEditor_LinePrintDiv.SelectedIndex == 1)
            {
                customizeData[13] = "1";
            }
            else if (tComboEditor_LinePrintDiv.SelectedIndex == 2)
            {
                customizeData[13] = "2";
            }
            else
            { }
            //----- ADD 2013/01/25 cheq Redmine#34098 -----<<<<<
        }

        // --- ADD 2010/08/12 ---------------------------------->>>>>
        /// <summary>
        /// コードからの選択を可能へ変更する
        /// </summary>
        /// <param name="name"></param>
        /// <remarks>
        /// <br>Note		: コードからの選択を可能へ変更する</br>
        /// <br>Programmer  : caowj</br>
        /// <br>Date        : 2010/08/12</br>
        /// </remarks>
        private void setTComboEditorByName(string name)
        {
            TComboEditor control = (TComboEditor)(this.GetType().GetField(name, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.IgnoreCase).GetValue(this));

            bool inputErrorFlg = true;
            foreach (Infragistics.Win.ValueListItem item in control.Items)
            {
                if (item.DataValue == control.Value)
                {
                    inputErrorFlg = false;
                    break;
                }
            }

            if (inputErrorFlg)
            {
                control.Value = this._preComboEditorValue;
            }
            else
            {
                this._preComboEditorValue = control.Value;
            }
        }
        // --- ADD 2010/08/12 ----------------------------------<<<<<
        #endregion ■ Private Method

        // --- ADD 2010/08/12 ---------------------------------->>>>>
        #region ◎ F5：ガイドの実行
        /// <summary>
        /// F5：ガイドの実行
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: F5：ガイドの実行</br>
        /// <br>Programmer  : caowj</br>
        /// <br>Date        : 2010/08/12</br>
        /// </remarks>
        public void ExcuteGuide(object sender, EventArgs e)
        {
            if (this.tNedit_CustomerCode_St.Focused)
            {
                this._customerCodeSt = true;
                ub_St_CustomerCode_Click(tNedit_CustomerCode_St, e);
            }
            else if (this.tNedit_CustomerCode_Ed.Focused)
            {
                this._customerCodeSt = false;
                ub_St_CustomerCode_Click(tNedit_CustomerCode_Ed, e);
            }
            else if (this.tEdit_SalesEmployeeCd_St.Focused)
            {
                ub_St_SalesEmployeeCd_Click(tEdit_SalesEmployeeCd_St, e);
            }
            else if (this.tEdit_SalesEmployeeCd_Ed.Focused)
            {
                ub_St_SalesEmployeeCd_Click(tEdit_SalesEmployeeCd_Ed, e);
            }
            else if (this.tEdit_FrontEmployeeCd_St.Focused)
            {
                ub_St_FrontEmployeeCd_Click(tEdit_FrontEmployeeCd_St, e);
            }
            else if (this.tEdit_FrontEmployeeCd_Ed.Focused)
            {
                ub_St_FrontEmployeeCd_Click(tEdit_FrontEmployeeCd_Ed, e);
            }
            else if (this.tEdit_SalesInputCode_St.Focused)
            {
                ub_St_SalesInputCode_Click(tEdit_SalesInputCode_St, e);
            }
            else if (this.tEdit_SalesInputCode_Ed.Focused)
            {
                ub_St_SalesInputCode_Click(tEdit_SalesInputCode_Ed, e);
            }
            else if (this.tNedit_RetGoodsReasonDiv_St.Focused)
            {
                ub_St_RetGoodsReasonDiv_Click(tNedit_RetGoodsReasonDiv_St, e);
            }
            else if (this.tNedit_RetGoodsReasonDiv_Ed.Focused)
            {
                ub_St_RetGoodsReasonDiv_Click(tNedit_RetGoodsReasonDiv_Ed, e);
            }
        }
        #endregion
        // --- ADD 2010/08/12 ----------------------------------<<<<<


    }
}