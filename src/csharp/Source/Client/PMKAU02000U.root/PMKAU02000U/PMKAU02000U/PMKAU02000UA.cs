//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 未入金一覧表
// プログラム概要   : 未入金一覧表情報を抽出し、印刷・PDF出力する
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 22018 鈴木正臣
// 作 成 日  2010/07/01  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 22018 鈴木正臣
// 作 成 日  2010/11/02  修正内容 : Adobe Reader9以降だと終了時エラー発生する件の対応。(WebBrowser解放処理の修正)
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
using Broadleaf.Application.Controller.Facade;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 未入金一覧表 入力フォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 未入金一覧表PDF出力操作を行うクラスです。</br>
    /// <br>Programmer : 22018 鈴木正臣</br>
    /// <br>Date       : 2010/07/01</br>
    /// <br></br>
    /// <br>Update Note: 2010/11/02  22018 鈴木 正臣</br>
    /// <br>           : Adobe Reader9以降だと終了時エラー発生する件の対応。(WebBrowser解放処理の修正)</br>
    /// </remarks>
    public partial class PMKAU02000UA : Form
    {
        # region [private enum]
        /// <summary>
        /// オペレーションコード
        /// </summary>
        private enum OperationCode : int
        {
            /// <summary>PDF出力</summary>
            PDFOut = 1,
            /// <summary>印刷</summary>
            PrintOut = 2,
        }
        # endregion

        #region [Private Const]
        /// <summary>クラスID</summary>
        private const string ct_ClassID = "PMKAU02000UA";
        /// <summary>プログラムID</summary>
        private const string ct_PGID = "PMKAU02000U";
        /// <summary>帳票名称</summary>
        private const string PDF_PRINT_NAME1 = "未入金一覧表";
        /// <summary>帳票キー	</summary>
        private const string PDF_PRINT_KEY = "ed734bd2-444a-4780-b3fc-237f642231fe";
        /// <summary>フッタボタン１左位置</summary>
        private const int ct_FooterButton1_Left = 194;
        /// <summary>フッタボタン２左位置</summary>
        private const int ct_FooterButton2_Left = 336;
        #endregion

        #region [Private Member]
        /// <summary>企業コード</summary>
        private string _enterpriseCode = string.Empty;
        /// <summary>画面イメージコントロール部品</summary>
        private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();
        /// <summary>抽出条件クラス</summary>
        private NoDepSalListCdtn _noDepSalListCdtn;
        /// <summary>ガイド系アクセスクラス</summary>
        private EmployeeAcs _employeeAcs;
        /// <summary>日付取得部品</summary>
        private DateGetAcs _dateGet;
        /// <summary>フォーカスControl</summary>
        private Control _prevControl = null;
        /// <summary>チェックエラー</summary>
        private Control _errorComponent = null;
        /// <summary>拠点アクセスクラス</summary>
        private SecInfoSetAcs _secInfoSetAcs;
        /// <summary>得意先検索結果</summary>
        private CustomerSearchRet _customerSearchRet;
        /// <summary>操作権限の制御オブジェクト</summary>
        private IOperationAuthority _operationAuthority;
        /// <summary>操作権限の制御リスト(直接参照すると遅いのでディクショナリ化)</summary>
        private Dictionary<OperationCode, bool> _operationAuthorityList;
        /// <summary></summary>
        private string _printName = string.Empty;
        /// <summary></summary>
        private string _printKey = PDF_PRINT_KEY;
        /// <summary>請求拠点(外部からの指定用)</summary>
        private string _paraDmdSectionCode;
        /// <summary>請求先(外部からの指定用)</summary>
        private int _paraClaimCode;
        #endregion

        # region [private プロパティ]
        /// <summary>
        /// 拠点アクセスクラス
        /// </summary>
        private SecInfoSetAcs SecInfoSetAcs
        {
            get
            {
                if ( _secInfoSetAcs == null )
                {
                    _secInfoSetAcs = new SecInfoSetAcs();
                }
                return _secInfoSetAcs;
            }
        }
        /// <summary>
        /// 操作権限の制御オブジェクト
        /// </summary>
        private IOperationAuthority MyOpeCtrl
        {
            get
            {
                if ( _operationAuthority == null )
                {
                    _operationAuthority = new OperationAuthorityImpl( Broadleaf.Application.Controller.Util.EntityUtil.CategoryCode.Report, "PMKAU02000U", this );
                }
                return _operationAuthority;
            }
        }
        /// <summary>
        /// 操作権限の制御リスト
        /// </summary>
        private Dictionary<OperationCode, bool> OpeAuthDictionary
        {
            get
            {
                if ( _operationAuthorityList == null )
                {
                    _operationAuthorityList = new Dictionary<OperationCode, bool>();
                    _operationAuthorityList.Add( OperationCode.PDFOut, !MyOpeCtrl.Disabled( (int)OperationCode.PDFOut ) );
                    _operationAuthorityList.Add( OperationCode.PrintOut, !MyOpeCtrl.Disabled( (int)OperationCode.PrintOut ) );
                }
                return _operationAuthorityList;
            }
        }
        # endregion

        #region [public プロパティ]
        /// <summary>
        /// 請求拠点(外部からの指定用)
        /// </summary>
        public string ParaDmdSectionCode
        {
            get { return _paraDmdSectionCode; }
            set { _paraDmdSectionCode = value; }
        }
        /// <summary>
        /// 請求先(外部からの指定用)
        /// </summary>
        public int ParaClaimCode
        {
            get { return _paraClaimCode; }
            set { _paraClaimCode = value; }
        }
        #endregion

        #region [コンストラクタ]
        /// <summary>
        /// 帳票共通(条件入力タイプ)フレームクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br>Programmer : 22018 鈴木正臣</br>
        /// <br>Date       : 2010/07/01</br>
        /// </remarks>
        public PMKAU02000UA()
        {
            InitializeComponent();

            // 企業コード取得
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            this._employeeAcs = new EmployeeAcs();

            //日付取得部品
            this._dateGet = DateGetAcs.GetInstance();

        }
        #endregion

        #region ■ IPrintConditionInpType メンバ

        #region ◆ Public Method

        #region ◎ 印刷前確認処理
        /// <summary>
        /// 印刷前確認処理
        /// </summary>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : 印刷前確認処理を行う。(入力チェックなど)</br>
        /// <br>Programmer : 22018 鈴木正臣</br>
        /// <br>Date       : 2010/07/01</br>
        /// </remarks>
        public bool PrintBeforeCheck()
        {
            bool status = true;
            string errMessage = "";
            _errorComponent = null;

            if ( !this.ScreenInputCheck( ref errMessage, ref _errorComponent ) )
            {
                // メッセージを表示
                this.MsgDispProc( emErrorLevel.ERR_LEVEL_EXCLAMATION, errMessage, 0 );

                // コントロールにフォーカスをセット
                if ( _errorComponent != null )
                {
                    _errorComponent.Focus();
                }

                // フォーカスアウト処理
                if ( this._prevControl != null )
                {
                    ChangeFocusEventArgs e = new ChangeFocusEventArgs( false, false, false, Keys.Return, this._prevControl, this._prevControl );
                    this.tArrowKeyControl1_ChangeFocus( this, e );
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
        /// <br>Note       : 印刷処理を行う。</br>
        /// <br>Programmer : 22018 鈴木正臣</br>
        /// <br>Date       : 2010/07/01</br>
        /// </remarks>
        public int Print( ref object parameter )
        {

            // オフライン状態チェック	
            if ( !CheckOnline() )
            {
                TMsgDisp.Show(
                    emErrorLevel.ERR_LEVEL_STOP,
                    this.Text,
                    "未入金一覧表データ読み込みに失敗しました。",
                    (int)ConstantManagement.DB_Status.ctDB_OFFLINE, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1 );
                return -1;
            }

            SFCMN06001U printDialog = new SFCMN06001U();		// 帳票選択ガイド
            SFCMN06002C printInfo = parameter as SFCMN06002C;	// 印刷情報パラメータ

            // 画面→抽出条件クラス
            int status = this.SetExtraInfoFromScreen();
            if ( status != 0 )
            {
                return -1;
            }

            // 企業コードをセット
            printInfo.enterpriseCode = this._enterpriseCode;
            printInfo.kidopgid = ct_PGID;				// 起動PGID

            // PDF出力履歴用
            printInfo.key = this._printKey;
            printInfo.prpnm = PDF_PRINT_NAME1;

            // テンプレートの選択
            printInfo.PrintPaperSetCd = 0;

            // 抽出条件の設定
            printInfo.jyoken = this._noDepSalListCdtn;
            printDialog.PrintInfo = printInfo;

            // 帳票選択ガイド
            DialogResult dialogResult = printDialog.ShowDialog();

            if ( printInfo.status == (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN )
            {
                MsgDispProc( emErrorLevel.ERR_LEVEL_INFO, "該当するデータがありません。", 0 );
            }

            parameter = printInfo;

            // ダイアログキャンセル判定
            if ( dialogResult == DialogResult.Cancel )
            {
                return (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }

            // STATUS返却
            return printInfo.status;
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
        #region ◆ PMKAU02000UA
        #region ◎ PMKAU02000UA_Load Event
        /// <summary>
        /// PMKAU02000UA_Load Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : ユーザーがﾌｫｰﾑを読み込むときに発生する</br>
        /// <br>Programmer : 22018 鈴木正臣</br>
        /// <br>Date       : 2010/07/01</br>
        /// </remarks>
        private void PMKAU02000UA_Load( object sender, EventArgs e )
        {
            string errMsg = string.Empty;

            // コントロール初期化
            int status = this.InitializeScreen( out errMsg );
            if ( status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL )
            {
                MsgDispProc( emErrorLevel.ERR_LEVEL_STOPDISP, errMsg, status );
                return;
            }

            // 画面イメージ統一
            # region [画面イメージ統一]
            // 画面スキンファイルの読込(デフォルトスキン指定)
            this._controlScreenSkin.LoadSkin();
            // 画面スキン変更		
            this._controlScreenSkin.SettingScreenSkin( this );
            // 表示スタイル補正
            ultraGroupBox1.ViewStyle = GroupBoxViewStyle.XP;
            # endregion

            // 抽出条件インスタンス生成
            this._noDepSalListCdtn = new NoDepSalListCdtn();


            // 初期化カーソル＞＞＞
            this.Cursor = Cursors.WaitCursor;

            # region [セキュリティ管理権限設定]
            // 権限設定.PDF出力
            if ( OpeAuthDictionary[OperationCode.PDFOut] )
            {
                this.ub_PDF.Visible = true;
                this.ub_Print.Left = ct_FooterButton1_Left;
            }
            else
            {
                this.ub_PDF.Visible = false;
                this.ub_Print.Left = ct_FooterButton2_Left;
            }

            // 権限設定.印刷
            if ( OpeAuthDictionary[OperationCode.PrintOut] )
            {
                this.ub_Print.Visible = true;
            }
            else
            {
                this.ub_Print.Visible = false;
            }
            # endregion

            // 初期フォーカス⇒日付区分
            this.tComboEditor_DateDiv.Focus();

            // カーソル戻す＜＜＜
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
        /// <br>Note       : なし</br>
        /// <br>Programmer : 22018 鈴木正臣</br>
        /// <br>Date       : 2010/07/01</br>
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus( object sender, ChangeFocusEventArgs e )
        {
            if ( e == null || e.PrevCtrl == null ) return;

            // 次項目の算定＋ボタンEnterキー対応
            # region [次項目の算定＋ボタンEnterキー対応]
            switch ( e.PrevCtrl.Name )
            {
                // 日付区分
                case "tComboEditor_DateDiv":
                    {
                        Control ctrl = EasyArrowKeyControl( e, null, tDateEdit_SalesDate_St, 
                                                            null, tComboEditor_DateDiv,
                                                            tComboEditor_DateDiv, tDateEdit_SalesDate_St );
                        if ( ctrl != null ) e.NextCtrl = ctrl;
                    }
                    break;
                // 対象日（開始）
                case "tDateEdit_SalesDate_St":
                    {
                        Control ctrl = EasyArrowKeyControl( e, tComboEditor_DateDiv, tEdit_SectionCode_St, 
                                                            null, null, 
                                                            tComboEditor_DateDiv, tDateEdit_SalesDate_Ed );
                        if ( ctrl != null ) e.NextCtrl = ctrl;
                    }
                    break;
                // 対象日（終了）
                case "tDateEdit_SalesDate_Ed":
                    {
                        Control ctrl = EasyArrowKeyControl( e, tComboEditor_DateDiv, tEdit_SectionCode_Ed, 
                                                            null, null, 
                                                            tDateEdit_SalesDate_St, tEdit_SectionCode_St );
                        if ( ctrl != null ) e.NextCtrl = ctrl;
                    }
                    break;
                // 請求拠点（開始）
                case "tEdit_SectionCode_St":
                    {
                        Control ctrl = EasyArrowKeyControl( e, tDateEdit_SalesDate_St, tNedit_ClaimCode_St, 
                                                            null, null, 
                                                            tDateEdit_SalesDate_Ed, tEdit_SectionCode_Ed );
                        if ( ctrl != null ) e.NextCtrl = ctrl;
                    }
                    break;
                case "ub_SectionCode_St_Guide":
                    {
                        Control ctrl = EasyArrowKeyControl( e, tDateEdit_SalesDate_St, tNedit_ClaimCode_St, 
                                                            null, null, 
                                                            tEdit_SectionCode_St, tEdit_SectionCode_Ed );
                        if ( ctrl != null ) e.NextCtrl = ctrl;
                    }
                    break;
                // 請求拠点（終了）
                case "tEdit_SectionCode_Ed":
                    {
                        Control ctrl = EasyArrowKeyControl( e, tDateEdit_SalesDate_Ed, tNedit_ClaimCode_Ed, 
                                                            null, ub_SectionCode_Ed_Guide, 
                                                            tEdit_SectionCode_St, tNedit_ClaimCode_St );
                        if ( ctrl != null ) e.NextCtrl = ctrl;
                    }
                    break;
                case "ub_SectionCode_Ed_Guide":
                    {
                        Control ctrl = EasyArrowKeyControl( e, tDateEdit_SalesDate_Ed, tNedit_ClaimCode_Ed, 
                                                            null, ub_SectionCode_Ed_Guide, 
                                                            tEdit_SectionCode_Ed, tNedit_ClaimCode_St );
                        if ( ctrl != null ) e.NextCtrl = ctrl;
                    }
                    break;
                // 請求先（開始）
                case "tNedit_ClaimCode_St":
                    {
                        Control ctrl = EasyArrowKeyControl( e, tEdit_SectionCode_St, GetFooterFirstButton(), 
                                                            null, null, 
                                                            tEdit_SectionCode_Ed, tNedit_ClaimCode_Ed );
                        if ( ctrl != null ) e.NextCtrl = ctrl;
                    }
                    break;
                case "ub_ClaimCode_St_Guide":
                    {
                        Control ctrl = EasyArrowKeyControl( e, tEdit_SectionCode_St, GetFooterFirstButton(), 
                                                            null, null, 
                                                            tNedit_ClaimCode_St, tNedit_ClaimCode_Ed );
                        if ( ctrl != null ) e.NextCtrl = ctrl;
                    }
                    break;
                // 請求先（終了）
                case "tNedit_ClaimCode_Ed":
                    {
                        Control ctrl = EasyArrowKeyControl( e, tEdit_SectionCode_Ed, GetFooterFirstButton(),
                                                            null, ub_ClaimCode_Ed_Guide,
                                                            tNedit_ClaimCode_St, GetFooterFirstButton() );
                        if ( ctrl != null ) e.NextCtrl = ctrl;
                    }
                    break;
                case "ub_ClaimCode_Ed_Guide":
                    {
                        Control ctrl = EasyArrowKeyControl( e, tEdit_SectionCode_Ed, GetFooterFirstButton(),
                                                            null, ub_ClaimCode_Ed_Guide,
                                                            tNedit_ClaimCode_Ed, GetFooterFirstButton() );
                        if ( ctrl != null ) e.NextCtrl = ctrl;
                    }
                    break;
                // 印刷ボタン
                case "ub_Print":
                    {
                        if ( e.Key == Keys.Return )
                        {
                            // Enterキーで実行
                            ub_Print_Click( ub_Print, new EventArgs() );
                            if ( _errorComponent != null )
                            {
                                e.NextCtrl = _errorComponent;
                            }
                            else
                            {
                                e.NextCtrl = e.PrevCtrl;
                            }
                        }
                        else
                        {
                            Control printNextCtrl;
                            if (ub_PDF.Visible )
                            {
                                printNextCtrl = ub_PDF;
                            }
                            else
                            {
                                printNextCtrl = ub_Cancel;
                            }
                            Control ctrl = EasyArrowKeyControl( e, tNedit_ClaimCode_St, null, 
                                                                ub_Print, null, 
                                                                tNedit_ClaimCode_Ed, printNextCtrl );
                            if ( ctrl != null ) e.NextCtrl = ctrl;
                        }
                    }
                    break;
                // PDF表示ボタン
                case "ub_PDF":
                    {
                        if ( e.Key == Keys.Return )
                        {
                            // Enterキーで実行
                            ub_PDF_Click( ub_PDF, new EventArgs() );
                            if ( _errorComponent != null )
                            {
                                e.NextCtrl = _errorComponent;
                            }
                            else
                            {
                                e.NextCtrl = e.PrevCtrl;
                            }
                        }
                        else
                        {
                            Control pdfPrevCtrl;
                            if ( ub_Print.Visible )
                            {
                                pdfPrevCtrl = ub_Print;
                            }
                            else
                            {
                                pdfPrevCtrl = tNedit_ClaimCode_Ed;
                            }
                            Control ctrl = EasyArrowKeyControl( e, tNedit_ClaimCode_St, null,
                                                                GetFooterFirstButton(), null,
                                                                pdfPrevCtrl, ub_Cancel );
                            if ( ctrl != null ) e.NextCtrl = ctrl;
                        }
                    }
                    break;
                // キャンセルボタン
                case "ub_Cancel":
                    {
                        if ( e.Key == Keys.Return )
                        {
                            // Enterキーで実行
                            ub_Cancel_Click( ub_Cancel, new EventArgs() );
                            if ( _errorComponent != null )
                            {
                                e.NextCtrl = _errorComponent;
                            }
                            else
                            {
                                e.NextCtrl = e.PrevCtrl;
                            }
                        }
                        else
                        {
                            Control cancelPrevCtrl;
                            if ( ub_PDF.Visible )
                            {
                                cancelPrevCtrl = ub_PDF;
                            }
                            else
                            {
                                cancelPrevCtrl = ub_Print;
                            }
                            Control ctrl = EasyArrowKeyControl( e, tNedit_ClaimCode_St, null,
                                                                null, null,
                                                                cancelPrevCtrl, ub_Cancel );
                            if ( ctrl != null ) e.NextCtrl = ctrl;
                        }
                    }
                    break;
                default:
                    break;
            }
            # endregion

        }
        /// <summary>
        /// フッタ部先頭ボタン取得
        /// </summary>
        /// <returns></returns>
        private Control GetFooterFirstButton()
        {
            if ( ub_Print.Visible )
            {
                return ub_Print;
            }
            else
            {
                return ub_PDF;
            }
        }
        /// <summary>
        /// 簡易アローキーコントロール
        /// </summary>
        /// <param name="e"></param>
        /// <param name="upCtrl"></param>
        /// <param name="downCtrl"></param>
        /// <param name="leftCtrl"></param>
        /// <param name="rightCtrl"></param>
        /// <returns></returns>
        private Control EasyArrowKeyControl( ChangeFocusEventArgs e, Control upCtrl, Control downCtrl, Control leftCtrl, Control rightCtrl, Control prevCtrl, Control nextCtrl )
        {
            switch ( e.Key )
            {
                case Keys.Up: return upCtrl;
                case Keys.Down: return downCtrl;
                case Keys.Left: return leftCtrl;
                case Keys.Right: return rightCtrl;

                case Keys.Return:
                case Keys.Tab:
                    {
                        if ( !e.ShiftKey )
                        {
                            return nextCtrl;
                        }
                        else
                        {
                            return prevCtrl;
                        }
                    }
                default: return null;
            }
        }
        #endregion

        #endregion ◆ PMKAU02000UA

        /// <summary>
        /// tComboEditor_DraftDivide_ValueChanged イベント処理イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : 手形区分変更ときに発生します。</br>      
        /// <br>Programmer : 22018 鈴木正臣</br>
        /// <br>Date       : 2010/07/01</br>
        /// </remarks> 
        private void tComboEditor_DraftDivide_ValueChanged( object sender, EventArgs e )
        {
        }

        #endregion ■ Control Event

        #region ■ Private Method
        #region ◆ 画面初期化関係
        #region ◎ 画面初期化処理
        /// <summary>
        /// 画面初期化処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 入力項目の初期化を行う</br>
        /// <br>Programmer : 22018 鈴木正臣</br>
        /// <br>Date       : 2010/07/01</br>
        /// </remarks>
        private int InitializeScreen( out string errMsg )
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            errMsg = string.Empty;

            try
            {
                # region [抽出条件の初期表示]
                // 日付区分
                this.tComboEditor_DateDiv.SelectedIndex = 0;

                // 対象日
                DateTime today = DateTime.Today;
                this.tDateEdit_SalesDate_St.SetDateTime( today.AddMonths( -1 ).AddDays( 1 ) );
                this.tDateEdit_SalesDate_Ed.SetDateTime( today );

                // 請求拠点
                if ( !string.IsNullOrEmpty( ParaDmdSectionCode ) )
                {
                    this.tEdit_SectionCode_St.Text = ParaDmdSectionCode.Trim();
                    this.tEdit_SectionCode_Ed.Text = ParaDmdSectionCode.Trim();
                }

                // 請求先
                if ( ParaClaimCode > 0 )
                {
                    this.tNedit_ClaimCode_St.SetInt( ParaClaimCode );
                    this.tNedit_ClaimCode_Ed.SetInt( ParaClaimCode );
                }
                # endregion

                # region [ボタンイメージ]
                // ガイドボタン
                SetIconImage( ub_SectionCode_St_Guide, Size16_Index.STAR1 );
                SetIconImage( ub_SectionCode_Ed_Guide, Size16_Index.STAR1 );
                SetIconImage( ub_ClaimCode_St_Guide, Size16_Index.STAR1 );
                SetIconImage( ub_ClaimCode_Ed_Guide, Size16_Index.STAR1 );

                // フッタ部ボタン
                SetIconImage( ub_Print, Size16_Index.PRINT );
                SetIconImage( ub_PDF, Size16_Index.VIEW );
                SetIconImage( ub_Cancel, Size16_Index.BEFORE );
                # endregion
            }
            catch ( Exception ex )
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
        /// <br>Note       : ボタンアイコンを設定する</br>
        /// <br>Programmer : 22018 鈴木正臣</br>
        /// <br>Date       : 2010/07/01</br>
        /// </remarks>
        private void SetIconImage( object settingControl, Size16_Index iconIndex )
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
        /// <br>Note       : 画面の入力チェックを行う。</br>
        /// <br>Programmer : 22018 鈴木正臣</br>
        /// <br>Date       : 2010/07/01</br>
        /// </remarks>
        private bool ScreenInputCheck( ref string errMessage, ref Control errComponent )
        {
            const string ct_RangeError = "の範囲指定に誤りがあります。";
            //const string ct_NoInputError = "が必須入力です。";
            const string ct_InputError = "の入力が不正です。";

            bool status = true;

            //--------------------------------------------------
            // 対象日（開始・終了）
            //--------------------------------------------------
            switch ( this._dateGet.CheckDateRange( DateGetAcs.YmdType.YearMonthDay, 0, ref this.tDateEdit_SalesDate_St, ref this.tDateEdit_SalesDate_Ed, true ) )
            {
                case DateGetAcs.CheckDateRangeResult.ErrorOfStartInvalid:
                    {
                        errMessage = string.Format( "開始対象日{0}", ct_InputError );
                        errComponent = this.tDateEdit_SalesDate_St;
                        status = false;
                    }
                    break;
                case DateGetAcs.CheckDateRangeResult.ErrorOfEndInvalid:
                    {
                        errMessage = string.Format( "終了対象日{0}", ct_InputError );
                        errComponent = this.tDateEdit_SalesDate_Ed;
                        status = false;
                    }
                    break;
                case DateGetAcs.CheckDateRangeResult.ErrorOfReverse:
                    {
                        errMessage = string.Format( "対象日{0}", ct_RangeError );
                        errComponent = this.tDateEdit_SalesDate_St;
                        status = false;
                    }
                    break;
            }
            if ( status == false )
            {
                return false;
            }
            //--------------------------------------------------
            // 請求拠点（開始・終了）
            //--------------------------------------------------
            else if ( !string.IsNullOrEmpty( tEdit_SectionCode_St.Text ) &&
                      !string.IsNullOrEmpty( tEdit_SectionCode_Ed.Text ) &&
                      (ToInt( tEdit_SectionCode_St.Text ) > ToInt( tEdit_SectionCode_Ed.Text )) )
            {
                errMessage = string.Format( "請求拠点{0}", ct_RangeError );
                errComponent = this.tEdit_SectionCode_St;
                status = false;
            }
            //--------------------------------------------------
            // 請求先（開始・終了）
            //--------------------------------------------------
            else if ( tNedit_ClaimCode_St.GetInt() != 0 &&
                      tNedit_ClaimCode_Ed.GetInt() != 0 &&
                      (tNedit_ClaimCode_St.GetInt() > tNedit_ClaimCode_Ed.GetInt()) )
            {
                errMessage = string.Format( "請求先{0}", ct_RangeError );
                errComponent = this.tNedit_ClaimCode_St;
                status = false;
            }

            return status;
        }

        /// <summary>
        /// 文字列⇒数値変換
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        private int ToInt( string text )
        {
            try
            {
                return Int32.Parse( text );
            }
            catch
            {
                return 0;
            }
        }

        #endregion

        #region ◎ 抽出条件設定処理(画面→抽出条件)
        /// <summary>
        /// 抽出条件設定処理(画面→抽出条件)
        /// </summary>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 画面→抽出条件へ設定する。</br>
        /// <br>Programmer : 22018 鈴木正臣</br>
        /// <br>Date       : 2010/07/01</br>
        /// </remarks>
        private int SetExtraInfoFromScreen()
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            try
            {
                // 企業コード
                this._noDepSalListCdtn.EnterpriseCode = this._enterpriseCode;

                // 日付区分
                this._noDepSalListCdtn.TargetDateDiv = (int)this.tComboEditor_DateDiv.Value;

                // 対象日
                this._noDepSalListCdtn.DateSt = this.tDateEdit_SalesDate_St.GetLongDate();
                this._noDepSalListCdtn.DateEd = this.tDateEdit_SalesDate_Ed.GetLongDate();

                // 請求拠点コード（開始・終了）
                this._noDepSalListCdtn.DemandAddUpSecCdSt = this.tEdit_SectionCode_St.Text.Trim();
                this._noDepSalListCdtn.DemandAddUpSecCdEd = this.tEdit_SectionCode_Ed.Text.Trim();

                // 請求得意先コード（開始・終了）
                this._noDepSalListCdtn.ClaimCodeSt = this.tNedit_ClaimCode_St.GetInt();
                this._noDepSalListCdtn.ClaimCodeEd = this.tNedit_ClaimCode_Ed.GetInt();

            }
            catch ( Exception )
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
        /// <br>Programmer : 22018 鈴木正臣</br>
        /// <br>Date       : 2010/07/01</br>
        /// </remarks>
        private void MsgDispProc( emErrorLevel iLevel, string message, int status )
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
                MessageBoxDefaultButton.Button1 );	// 初期表示ボタン
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
        /// <br>Programmer : 22018 鈴木正臣</br>
        /// <br>Date       : 2010/07/01</br>
        /// </remarks>
        private void Main_ultraExplorerBar_GroupCollapsing( object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e )
        {
        }

        /// <summary> 
        /// エクスプローラーバー グループ展開 イベント 
        /// </summary> 
        /// <param name="sender">イベントオブジェクト</param> 
        /// <param name="e">イベント情報</param> 
        /// <remarks> 
        /// <br>Note       : グループが展開される前に発生します。</br> 
        /// <br>Programmer : 22018 鈴木正臣</br>
        /// <br>Date       : 2010/07/01</br>
        /// </remarks>
        private void Main_ultraExplorerBar_GroupExpanding( object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e )
        {
        }

        #region ◎ オフライン状態チェック処理

        /// <summary>
        /// ログオン時オンライン状態チェック処理
        /// </summary>
        /// <returns>チェック処理結果</returns>
        /// <remarks>
        /// <br>Note       : ログオン時オンライン状態チェック処理を行い</br>
        /// <br>Programmer : 22018 鈴木正臣</br>
        /// <br>Date       : 2010/07/01</br>
        /// </remarks>
        private bool CheckOnline()
        {
            if ( Broadleaf.Application.Common.LoginInfoAcquisition.OnlineFlag == false )
            {
                return false;
            }
            else
            {
                // ローカルエリア接続状態によるオンライン判定
                if ( CheckRemoteOn() == false )
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
        /// <br>Note       : リモート接続可能判定を行い</br>
        /// <br>Programmer : 22018 鈴木正臣</br>
        /// <br>Date       : 2010/07/01</br>
        /// </remarks>
        private bool CheckRemoteOn()
        {
            bool isLocalAreaConnected = NetworkInterface.GetIsNetworkAvailable();

            if ( isLocalAreaConnected == false )
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

        # region [ボタンクリック]
        /// <summary>
        /// 印刷ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ub_Print_Click( object sender, EventArgs e )
        {
            if ( PrintBeforeCheck() )
            {
                object printInfo = CreatePrintParameter( 0 ); // 0:印刷
                int status = Print( ref printInfo );

                if ( status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL )
                {
                    this.Close();
                }
            }
        }
        /// <summary>
        /// PDF表示ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ub_PDF_Click( object sender, EventArgs e )
        {
            if ( PrintBeforeCheck() )
            {
                object printInfo = CreatePrintParameter( 1 ); // 1:PDF
                int status = Print( ref printInfo );

                if ( status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL )
                {
                    // PDF表示
                    # region [PDF表示]
                    PMKAU02000UB pdfForm = new PMKAU02000UB( (this.Owner as Form) );
                    try
                    {
                        pdfForm.PDFShow( (printInfo as SFCMN06002C).pdftemppath );
                    }
                    finally
                    {
                        // --- ADD m.suzuki 2010/11/02 ---------->>>>>
                        pdfForm.Close();
                        // --- ADD m.suzuki 2010/11/02 ----------<<<<<
                        pdfForm.Dispose();
                    }
                    # endregion

                    this.Close();
                }
            }
        }
        /// <summary>
        /// キャンセルボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ub_Cancel_Click( object sender, EventArgs e )
        {
            this.Close();
        }
        /// <summary>
        /// 印刷/PDF出力パラメータ生成
        /// </summary>
        /// <param name="mode">0:印刷,1:PDF</param>
        /// <returns></returns>
        private SFCMN06002C CreatePrintParameter( int mode )
        {
            SFCMN06002C printInfo = new SFCMN06002C();

            printInfo.enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            printInfo.kidopgid = "PMKAU02000U";
            printInfo.prpnm = "";
            printInfo.PrintPaperSetCd = 0;

            if ( mode == 0 )
            {
                // 印刷
                printInfo.printmode = 1; // 1：印刷のみ
            }
            else
            {
                // PDF
                printInfo.printmode = 2; // 2：PDF表示のみ
            }
            return printInfo;
        }
        # endregion

        # region [ガイドボタンクリック]
        /// <summary>
        /// 拠点ガイドボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ub_SectionCode_Guide_Click( object sender, EventArgs e )
        {
            // 拠点ガイド表示
            SecInfoSet sectionInfo;
            int status = this.SecInfoSetAcs.ExecuteGuid( this._enterpriseCode, false, out sectionInfo );

            // ステータスが正常時のみ情報をUIにセット
            if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
            {
                if ( sender == ub_SectionCode_St_Guide )
                {
                    tEdit_SectionCode_St.Text = sectionInfo.SectionCode.Trim();
                    tEdit_SectionCode_Ed.Focus();
                }
                else
                {
                    tEdit_SectionCode_Ed.Text = sectionInfo.SectionCode.Trim();
                    tNedit_ClaimCode_St.Focus();
                }
            }
        }
        /// <summary>
        /// 得意先ガイドボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ub_ClaimCode_Guide_Click( object sender, EventArgs e )
        {
            _customerSearchRet = null;

            PMKHN04005UA customerSearchForm = new PMKHN04005UA( PMKHN04005UA.SEARCHMODE_CUSTOMER_ONLY, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY );
            customerSearchForm.CustomerSelect += new Broadleaf.Windows.Forms.PMKHN04005UA.CustomerSelectEventHandler( this.CustomerSearchForm_CustomerSelect );

            DialogResult result = customerSearchForm.ShowDialog( this );
            if ( result == DialogResult.OK && _customerSearchRet != null )
            {
                if ( sender == ub_ClaimCode_St_Guide )
                {
                    tNedit_ClaimCode_St.SetInt( _customerSearchRet.CustomerCode );
                    tNedit_ClaimCode_Ed.Focus();
                }
                else
                {
                    tNedit_ClaimCode_Ed.SetInt( _customerSearchRet.CustomerCode );
                    GetFooterFirstButton().Focus();
                }
            }
        }
        /// <summary>
        /// 得意先ガイドで確定時の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="customerSearchRet"></param>
        private void CustomerSearchForm_CustomerSelect( object sender, CustomerSearchRet customerSearchRet )
        {
            // イベントハンドラを渡した相手から戻り値クラスを受け取れなければ終了
            if ( customerSearchRet == null ) return;

            // 結果を退避
            _customerSearchRet = customerSearchRet;
        }
        # endregion
    }
}