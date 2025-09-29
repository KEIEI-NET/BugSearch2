//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 売上連携テキスト出力
// プログラム概要   : 売上連携テキスト出力帳票を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2019 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11570219-00      作成担当 : 田建委
// 作 成 日  2019/12/02       修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号  11570219-00      作成担当 : 小原
// 作 成 日  2020/02/04       修正内容 : （修正内容一覧No.2）備考設定変更項目追加
//----------------------------------------------------------------------------//
// 管理番号  11675168-00      作成担当 : 陳永康
// 作 成 日  2021/07/29       修正内容 : PMKOBETSU-4115 売上データ連携送信文字不正対応
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Library.Windows.Forms;

using Broadleaf.Application.Controller;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using System.Collections;
using Broadleaf.Library.Resources;
using Infragistics.Win.Misc;
using Broadleaf.Library.Globarization;
using System.IO;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic.FileIO;
using Broadleaf.Application.Resources;
using System.Xml;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 売上連携テキスト出力クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 売上連携テキスト出力UIで、抽出条件を入力します。</br>
    /// <br>Programmer : 田建委</br>
    /// <br>Date       : 2019/12/02</br>
    /// <br>UpdateNote : PMKOBETSU-4115 売上データ連携送信文字不正対応</br>
    /// <br>Programmer : 陳永康</br>
    /// <br>Date       : 2021/07/29</br>
    /// </remarks>
    public partial class PMSDC02010UA : Form,
                                IPrintConditionInpType,					// 帳票共通（条件入力タイプ）
                                IPrintConditionInpTypePdfCareer,	    // 帳票業務（条件入力）PDF出力履歴管理
                                IPrintConditionInpTypeUpdate
    {
        #region ■ Constructor
        /// <summary>
        /// 売上連携テキスト出力UIクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 売上連携テキスト出力UI初期化およびインスタンスの生成を行う</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2019/12/02</br>
        /// </remarks>
        public PMSDC02010UA()
        {
            InitializeComponent();

            // 企業コード取得
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            // ログイン拠点を取得
            this._loginWorker = LoginInfoAcquisition.Employee.Clone();

            // 日付取得部品
            _dateGet = DateGetAcs.GetInstance();

            // UI設定保存コンポーネント設定
            this.SetUIMemInputControl();

            _salesCprtAcs = new SalesCprtAcs();

            _secInfoSetAcs = new SecInfoSetAcs();
            _customerInfoAcs = new CustomerInfoAcs();

        }

        #endregion ■ Constructor

        #region ■ Private Member
        #region ◆ Interface member

        // 確定ボタン状態取得プロパティ
        private bool _canUpdate = true;
        // 抽出ボタン状態取得プロパティ
        private bool _canExtract = false;
        // PDF出力ボタン状態取得プロパティ    
        private bool _canPdf = true;
        // 印刷ボタン状態取得プロパティ
        private bool _canPrint = false;
        // 抽出ボタン表示有無プロパティ
        private bool _visibledExtractButton = false;
        // PDF出力ボタン表示有無プロパティ	
        private bool _visibledPdfButton = true;
        // 印刷ボタン表示有無プロパティ
        private bool _visibledPrintButton = false;
        // 設定ボタン表示有無プロパティ
        private bool _visibledSetButton = true;
        #endregion ◆ Interface member

        // 企業コード
        private string _enterpriseCode = "";
        // ログイン情報
        private Employee _loginWorker = null;

        private bool _customerGuid;

        private int _mode = 0;

        // 画面イメージコントロール部品
        private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();

        // 抽出条件クラス
        private SalesCprtCndtnWork _salesCprtCndtnWork;

        private SalesCprtAcs _salesCprtAcs;
        //拠点アクセスクラス
        private SecInfoSetAcs _secInfoSetAcs;
        // 得意先
        private CustomerInfoAcs _customerInfoAcs;
        /// <summary>拠点コード</summary>
        private string _sectionCode = string.Empty;
        /// <summary>前回入力値</summary>
        private PrevInputValue _prevInputValue;
        //接続情報マスタ
        private SalCprtConnectInfoWorkAcs _connectInfoWorkAcs = null;

        //日付取得部品
        private DateGetAcs _dateGet;

        private SFCMN00299CA msgForm = null;

        #endregion ■ Private Member

        #region ■ Private Const
        #region ◆ Interface member
        // クラスID
        private const string ct_ClassID = "PMSDC02010UA";
        // プログラムID
        private const string ct_PGID = "PMSDC02010U";
        // 帳票名称
        private const string PDF_PRINT_NAME = "確認リスト";
        private string _printName = PDF_PRINT_NAME;
        // 帳票キー	
        private const string PDF_PRINT_KEY = "0DC0CAB9-9645-4a27-8B61-03F651EBA3EA";
        private string _printKey = PDF_PRINT_KEY;
        #endregion ◆ Interface member

        //エラー条件メッセージ
        private const string ct_InputError = "の入力が不正です。";
        private const string ct_NoInput = "を入力して下さい。";
        private const string ct_RangeError = "の範囲指定に誤りがあります。";
        private const string ct_NotOnYearError = "は１２ヶ月の範囲内で入力して下さい。";
        /// <summary>メッセージ 「得意先情報の取得に失敗しました。」</summary>
        private const string ct_CustNotFound = "得意先情報の取得に失敗しました。";
        /// <summary>エラーメッセージ：「が存在しません。」</summary>
        private const string ct_NotExists = "が存在しません。";
        /// <summary>拠点と得意先両方設定されていない場合エラー</summary>
        private const string ct_NotInput = "拠点、得意先のいずれかを入力してください。";

        /// <summary>ログメッセージ：送信準備エラー</summary>
        private const string LOGMSG_ERROR = "送信準備エラー";

        private char[] _fileCharArr = new char[9] { '\\', '/', ':', '*', '?', '"', '<', '>', '|' };

        #endregion

        # region 構造体
        /// <summary>
        /// 前回値保持
        /// </summary>
        private struct PrevInputValue
        {
            /// <summary>拠点コード</summary>
            private string _sectionCode;
            /// <summary>得意先コード</summary>
            private int _customerCode;

            /// <summary>
            /// 拠点コード
            /// </summary>
            public string SectionCode
            {
                get { return _sectionCode; }
                set { _sectionCode = value; }
            }
            /// <summary>
            /// 得意先コード
            /// </summary>
            public int CustomerCode
            {
                get { return _customerCode; }
                set { _customerCode = value; }
            }
        }
        # endregion

        #region ■ IPrintConditionInpType メンバ
        #region ◆ Public Event
        /// <summary> 親ツールバー設定イベント </summary>
        public event ParentToolbarSettingEventHandler ParentToolbarSettingEvent;
        #endregion ◆ Public Event

        #region ◆ Public Property

        /// <summary> 確定ボタン状態取得プロパティ </summary>
        public bool CanUpdate
        {
            get { return this._canUpdate; }
        }
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

        /// <summary> 設定ボタン表示プロパティ </summary>
        public bool VisibledSetButton
        {
            get { return this._visibledSetButton; }
        }

        #endregion ◆ Public Property

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

        /// <summary>
        /// ファイル名の正確性チェック
        /// </summary>
        /// <param name="fileName">ファイル名</param>
        /// <returns></returns>
        private bool CheckFileStr(string fileName)
        {
            bool errFlg = false;
            List<char> fileCharList = new List<char>(_fileCharArr);

            foreach (char c in fileName)
            {
                if (fileCharList.Contains(c))
                {
                    errFlg = true;
                    break;
                }
            }

            return errFlg;
        }

        #region ◎ 確定処理
        /// <summary>
        /// 確定処理
        /// </summary>
        /// <param name="parameter">パラメータ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note		: 印刷処理を行う。</br>
        /// <br>Programmer	: 田建委</br>
        /// <br>Date		: 2019/12/02</br>
        /// <br>Update Note : 2020/02/04 小原 卓也</br>
        /// <br>管理番号    : 11570219-00</br>
        /// <br>            : （修正内容一覧No.2）備考設定変更項目追加</br>
        /// </remarks>
        public int Update(ref object parameter)
        {
            int status = -1;
            string errMsg = "";

            int logStatus = 0;
            SalCprtSndLogListResultWork salCprtSndLogWork = null;

            // 確定処理確認
            DialogResult result = TMsgDisp.Show(
                this, 								// 親ウィンドウフォーム
                emErrorLevel.ERR_LEVEL_QUESTION,    // エラーレベル
                ct_ClassID,						// アセンブリＩＤまたはクラスＩＤ
                "実行してもよろしいですか？",       // 表示するメッセージ, 				
                0, 									// ステータス値
                MessageBoxButtons.YesNo,
                MessageBoxDefaultButton.Button2);    // 表示するボタン

            if (result != DialogResult.Yes)
            {
                return status;
            }

            // 画面→抽出条件クラス
            status = this.SetExtraInfoFromScreen();
            if (status != 0)
            {
                return -1;
            }

            // --- ADD 2020/02/04 T.Obara ---------- 修正内容一覧No.2 >>>>>
            SalCprtConnectInfoWork connectInfoWork = null;
            try
            {
                if (null == this._connectInfoWorkAcs)
                {
                    this._connectInfoWorkAcs = new SalCprtConnectInfoWorkAcs();
                }
                status = this._connectInfoWorkAcs.Read(out connectInfoWork, _salesCprtCndtnWork.EnterpriseCode, 0, _salesCprtCndtnWork.SectionCode, _salesCprtCndtnWork.CustomerCode);
            }
            catch (Exception ex)
            {
                ex.ToString();
                status = -1;
                this._salesCprtAcs.SendDateTimeEnd = Convert.ToInt64(DateTime.Now.ToString("yyyyMMddHHmmss"));
                logStatus = this._salesCprtAcs.WriteLogInfo(this._salesCprtCndtnWork, ref salCprtSndLogWork, status, LOGMSG_ERROR);
                return status;
            }
            if (connectInfoWork == null || status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                status = -1;
                this._salesCprtAcs.SendDateTimeEnd = Convert.ToInt64(DateTime.Now.ToString("yyyyMMddHHmmss"));
                logStatus = this._salesCprtAcs.WriteLogInfo(this._salesCprtCndtnWork, ref salCprtSndLogWork, status, LOGMSG_ERROR);
                msgForm.Close();
                return status;
            }
            // --- ADD 2020/02/04 T.Obara ---------- 修正内容一覧No.2 <<<<<

            try
            {
                //データ抽出処理
                // --- ADD 2020/02/04 T.Obara ---------- 修正内容一覧No.2 >>>>>
                //status = this._salesCprtAcs.SearchSalesHistoryProcMain(this._salesCprtCndtnWork, out errMsg);
                status = this._salesCprtAcs.SearchSalesHistoryProcMain(this._salesCprtCndtnWork, out errMsg, connectInfoWork);
                // --- ADD 2020/02/04 T.Obara ---------- 修正内容一覧No.2 <<<<<
            }
            catch (Exception)
            {
                MsgDispProc(emErrorLevel.ERR_LEVEL_STOP, errMsg, status);
            }

            if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                if (status == (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN)
                {
                    MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, errMsg, status);
                }
                else
                {
                    MsgDispProc(emErrorLevel.ERR_LEVEL_STOP, errMsg, status);
                }
                return status;
            }

            msgForm = new SFCMN00299CA();
            msgForm.Title = "送信中";
            msgForm.Message = "現在、データ送信中です。                  ￥nしばらくお待ちください";
            msgForm.Show();
            // --- DEL 2020/02/04 T.Obara ---------- 修正内容一覧No.2 >>>>>
            //SalCprtConnectInfoWork connectInfoWork = null;
            //try
            //{
            //    if (null == this._connectInfoWorkAcs)
            //    {
            //        this._connectInfoWorkAcs = new SalCprtConnectInfoWorkAcs();
            //    }
            //    status = this._connectInfoWorkAcs.Read(out connectInfoWork, _salesCprtCndtnWork.EnterpriseCode, 0, _salesCprtCndtnWork.SectionCode, _salesCprtCndtnWork.CustomerCode);
            //}
            //catch (Exception ex)
            //{
            //    ex.ToString();
            //    status = -1;
            //    this._salesCprtAcs.SendDateTimeEnd = Convert.ToInt64(DateTime.Now.ToString("yyyyMMddHHmmss"));
            //    logStatus = this._salesCprtAcs.WriteLogInfo(this._salesCprtCndtnWork, ref salCprtSndLogWork, status, LOGMSG_ERROR);
            //    return status;
            //}
            //if (connectInfoWork == null || status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            //{
            //    status = -1;
            //    this._salesCprtAcs.SendDateTimeEnd = Convert.ToInt64(DateTime.Now.ToString("yyyyMMddHHmmss"));
            //    logStatus = this._salesCprtAcs.WriteLogInfo(this._salesCprtCndtnWork, ref salCprtSndLogWork, status, LOGMSG_ERROR);
            //    msgForm.Close();
            //    return status;
            //}
            // --- DEL 2020/02/04 T.Obara ---------- 修正内容一覧No.2 <<<<<
            string fileName = string.Empty;
            if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                fileName = connectInfoWork.CnectFileId;
            }
            this.DeleteXmlFile(fileName);
            status = SaveNetSendSetting(fileName);
            if (status != (int)ConstantManagement.MethodResult.ctFNC_CANCEL)
            {
                status = this._salesCprtAcs.SendAndReceive(ref this._salesCprtCndtnWork, fileName, out salCprtSndLogWork, out logStatus);
            }
            else
            {
                msgForm.Close();
            }
            if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                msgForm.Close();
                MsgDispProc(emErrorLevel.ERR_LEVEL_STOP, "自動送信処理に失敗しました。", status);

                if (logStatus == (int)ConstantManagement.DB_Status.ctDB_DUPLICATE ||
                    logStatus == (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE ||
                    logStatus == (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE)
                {
                    MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, "送信ログは、既に他の端末で登録されています。", status);
                }
                return status;
            }
            else
            {
                msgForm.Close();
                if (this._salesCprtCndtnWork.ConFirmDiv != 0 && status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "手動送信を行いました。", status);
                }

                if (logStatus == (int)ConstantManagement.DB_Status.ctDB_DUPLICATE ||
                    logStatus == (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE ||
                    logStatus == (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE)
                {
                    MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, "送信ログは、既に他の端末で登録されています。", status);
                }
            }

            //売上抽出データ更新処理
            try
            {
                //データ抽出処理
                status = this._salesCprtAcs.Write(out errMsg);
            }
            catch (Exception)
            {
                MsgDispProc(emErrorLevel.ERR_LEVEL_STOP, errMsg, status);
            }

            if (this._salesCprtCndtnWork.ConFirmDiv == 0)
            {
                //印刷処理
                _mode = 1;

                this._salesCprtCndtnWork.Mode = 1;

                Print(ref parameter);

                MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "手動送信を行いました。", status);
            }
            //画面モードの初期化
            _mode = 0;

            this._salesCprtCndtnWork.Mode = 0;

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
        /// <br>Programmer	: 田建委</br>
        /// <br>Date		: 2019/12/02</br>
        /// </remarks>
        public int Print(ref object parameter)
        {
            int status = -1;

            if(1 == (int)this.tComboEditor_ConFirmDiv.Value && _mode == 0)
            {
                TMsgDisp.Show(
                this,
                emErrorLevel.ERR_LEVEL_EXCLAMATION,
                this.Name,
                "選択出来ない区分です。",
                status,
                MessageBoxButtons.OK);

                this.tComboEditor_ConFirmDiv.Focus();
                return status;
            }

            SFCMN06001U printDialog = new SFCMN06001U();		// 帳票選択ガイド
            SFCMN06002C printInfo = parameter as SFCMN06002C;	// 印刷情報パラメータ

            // 企業コードをセット
            printInfo.enterpriseCode = this._enterpriseCode;
            printInfo.kidopgid = ct_PGID;				// 起動PGID

            // PDF出力履歴用
            printInfo.key = this._printKey;
            printInfo.prpnm = this._printName;

            // 画面→抽出条件クラス
            status = this.SetExtraInfoFromScreen();
            if (status != 0)
            {
                return -1;
            }

            if (_mode == 1)
            {
                this._salesCprtCndtnWork.Mode = 1;
            }
            else
            {
                this._salesCprtCndtnWork.Mode = 0;

            }

            // 抽出条件の設定
            printInfo.jyoken = this._salesCprtCndtnWork;
            printDialog.PrintInfo = printInfo;

            printInfo.rdData = this._salesCprtAcs.GetprintdataTable();

            // 帳票選択ガイド
            DialogResult dialogResult = printDialog.ShowDialog();

            if (printInfo.status == (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN)
            {
                MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "該当するデータがありません。", printInfo.status);
            }

            if (printInfo.status == (int)ConstantManagement.MethodResult.ctFNC_ERROR)
            {
                MsgDispProc(emErrorLevel.ERR_LEVEL_STOP, "データ抽出処理に失敗しました。", printInfo.status);
            }

            parameter = printInfo;

            return printInfo.status;
        }
        #endregion

        #region ◆ 画面設定保存
        /// <summary>
        /// UIMemInputの保存項目設定
        /// </summary>
        /// <remarks>
        /// <br>Note		: 保存項目設定処理を行う。</br>
        /// <br>Programmer	: 田建委</br>
        /// <br>Date		: 2019/12/02</br>
        /// </remarks>
        private void SetUIMemInputControl()
        {
            // 入力保存項目をセット
            List<Control> saveCtrAry = new List<Control>();

            saveCtrAry.Add(this.tde_St_AddUpDate);
            saveCtrAry.Add(this.tde_Ed_AddUpDate);
            saveCtrAry.Add(this.tComboEditor_ConFirmDiv);
            saveCtrAry.Add(this.tNedit_CustomerCode);
            saveCtrAry.Add(this.tComboEditor_PdfOutDiv);
            saveCtrAry.Add(this.tEdit_SectionCode);
            saveCtrAry.Add(this.tEdit_SectionName);
            saveCtrAry.Add(this.uLabel_CustomerName);

            this.uiMemInput1.TargetControls = saveCtrAry;
            this.uiMemInput1.ReadOnLoad = false;
        }
        #endregion

        #region ◎ 印刷前確認処理
        /// <summary>
        /// 印刷前確認処理
        /// </summary>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note		: 印刷前確認処理を行う。(入力チェックなど)</br>
        /// <br>Programmer	: 田建委</br>
        /// <br>Date		: 2019/12/02</br>
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
        /// <br>Programmer	: 田建委</br>
        /// <br>Date		: 2019/12/02</br>
        /// </remarks>
        public void Show(object parameter)
        {
            this.Show();
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

        #region ■ Private Method
        #region ◆ 画面初期化関係
        #region ◎ 画面初期化処理
        /// <summary>
        /// 画面初期化処理
        /// </summary>
        /// <remarks>
        /// <br>Note		: 入力項目の初期化を行う</br>
        /// <br>Programmer	: 田建委</br>
        /// <br>Date		: 2019/12/02</br>
        /// </remarks>
        private int InitializeScreen(out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            errMsg = string.Empty;

            try
            {
                this.tComboEditor_ConFirmDiv.Value = 0;

                this.tComboEditor_PdfOutDiv.Value = 0;
                // 前回入力値保持用
                _prevInputValue = new PrevInputValue();

                // 前回表示状態が保存されていれば上書き
                this.uiMemInput1.ReadMemInput();

                // 初期フォーカスセット
                this.tde_St_AddUpDate.Focus();
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
        /// 日付入力チェック処理呼び出し
        /// </summary>
        /// <param name="cdrResult"></param>
        /// <param name="tde_OrderDataCreateDate"></param>
        /// <returns></returns>
        private bool CallCheckDate(out DateGetAcs.CheckDateResult cdrResult, ref TDateEdit tde_OrderDataCreateDate)
        {
            cdrResult = _dateGet.CheckDate(ref tde_OrderDataCreateDate, false);
            return (cdrResult == DateGetAcs.CheckDateResult.OK);
        }

        /// <summary>
        /// 日付範囲チェック処理呼び出し
        /// </summary>
        /// <param name="cdrResult"></param>
        /// <param name="tde_St_OrderDataCreateDate"></param>
        /// <param name="tde_Ed_OrderDataCreateDate"></param>
        /// <returns></returns>
        private bool CallCheckPeriod(out DateGetAcs.CheckPeriodResult cdrResult, ref TDateEdit tde_St_OrderDataCreateDate, ref TDateEdit tde_Ed_OrderDataCreateDate)
        {
            cdrResult = _dateGet.CheckPeriod(DateGetAcs.YmdType.Year, 1, DateGetAcs.YmdType.YearMonthDay, tde_St_OrderDataCreateDate.GetDateTime(), tde_Ed_OrderDataCreateDate.GetDateTime());
            return (cdrResult == DateGetAcs.CheckPeriodResult.OK);
        }

        /// <summary>
        /// 入力チェック処理
        /// </summary>
        /// <param name="errMessage">エラーメッセージ</param>
        /// <param name="errComponent">エラー発生コンポーネント</param>
        /// <returns>True:OK, False:NG</returns>
        /// <remarks>
        /// <br>Note		: 画面の入力チェックを行う。</br>
        /// <br>Programmer	: 田建委</br>
        /// <br>Date		: 2019/12/02</br>
        /// </remarks>
        private bool ScreenInputCheck(ref string errMessage, ref Control errComponent)
        {
            bool status = true;
            DateGetAcs.CheckDateResult cdrResultSt;
            DateGetAcs.CheckDateResult cdrResultEd;
            DateGetAcs.CheckPeriodResult cdrResultStEd;

            // 計上日（開始）
            if (CallCheckDate(out cdrResultSt, ref tde_St_AddUpDate) == false)
            {
                switch (cdrResultSt)
                {
                    case DateGetAcs.CheckDateResult.ErrorOfNoInput:
                        {
                            errMessage = string.Format("開始日{0}", ct_NoInput);
                            errComponent = this.tde_St_AddUpDate;
                        }
                        break;
                    case DateGetAcs.CheckDateResult.ErrorOfInvalid:
                        {
                            errMessage = string.Format("開始日{0}", ct_InputError);
                            errComponent = this.tde_St_AddUpDate;
                        }
                        break;
                }

                status = false;
                this.tde_St_AddUpDate.ResetText();
                return status;
            }

            // 計上日（終了）
            if (CallCheckDate(out cdrResultEd, ref tde_Ed_AddUpDate) == false)
            {
                switch (cdrResultEd)
                {
                    case DateGetAcs.CheckDateResult.ErrorOfNoInput:
                        {
                            errMessage = string.Format("終了日{0}", ct_NoInput);
                            errComponent = this.tde_Ed_AddUpDate;
                        }
                        break;
                    case DateGetAcs.CheckDateResult.ErrorOfInvalid:
                        {
                            errMessage = string.Format("終了日{0}", ct_InputError);
                            errComponent = this.tde_Ed_AddUpDate;
                        }
                        break;
                }

                status = false;
                this.tde_Ed_AddUpDate.ResetText();
                return status;
            }


            // 計上日（開始～終了）
            if (CallCheckPeriod(out cdrResultStEd, ref tde_St_AddUpDate, ref tde_Ed_AddUpDate) == false)
            {
                switch (cdrResultStEd)
                {
                    case DateGetAcs.CheckPeriodResult.ErrorOfReverse:
                        {
                            errMessage = string.Format("対象日{0}", ct_RangeError);
                            errComponent = this.tde_Ed_AddUpDate;
                        }
                        break;
                    case DateGetAcs.CheckPeriodResult.ErrorOfRangeOver:
                        {
                            errMessage = string.Format("対象日{0}", ct_NotOnYearError);
                            errComponent = this.tde_Ed_AddUpDate;
                        }
                        break;
                }
                status = false;
                this.tde_St_AddUpDate.ResetText();
                this.tde_Ed_AddUpDate.ResetText();
                return status;
            }

            if (string.IsNullOrEmpty(this.tNedit_CustomerCode.DataText.TrimEnd())
                && string.IsNullOrEmpty(this.tEdit_SectionCode.DataText.TrimEnd()))
            {
                errMessage = ct_NotInput;
                errComponent = this.tEdit_SectionCode;
                status = false;
                return status;
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
        /// <br>Programmer	: 田建委</br>
        /// <br>Date		: 2019/12/02</br>
        /// </remarks>
        private int SetExtraInfoFromScreen()
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            this._salesCprtCndtnWork = new SalesCprtCndtnWork();
            try
            {
                // 企業コード
                this._salesCprtCndtnWork.EnterpriseCode = this._enterpriseCode;

                // 拠点コード
                this._salesCprtCndtnWork.SectionCode = this.tEdit_SectionCode.Text;

                // 計上日(開始)
                this._salesCprtCndtnWork.AddUpADateSt = this.tde_St_AddUpDate.GetLongDate();

                // 計上日(終了)
                this._salesCprtCndtnWork.AddUpADateEd = this.tde_Ed_AddUpDate.GetLongDate();

                //確認リスト
                this._salesCprtCndtnWork.ConFirmDiv = (int)tComboEditor_ConFirmDiv.Value;

                // 得意先
                this._salesCprtCndtnWork.CustomerCode = this.tNedit_CustomerCode.GetInt();

                // 出力指定
                this._salesCprtCndtnWork.PdfOutDiv = (int)this.tComboEditor_PdfOutDiv.Value;
            }
            catch (Exception)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }

            return status;
        }

        /// <summary>
        /// 自動送信XML生成
        /// </summary>
        /// <remarks>
        /// <br>Note	   : 自動送信XMLを生成する。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2019/12/02</br>
        /// <br>UpdateNote : PMKOBETSU-4115 売上データ連携送信文字不正対応</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2021/07/29</br>
        /// </remarks>
        private int SaveNetSendSetting(string fileName)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            string resultMessageIn = string.Empty;
            string xmlFileName = string.Empty;
            try
            {
                int rowsCount = this._salesCprtAcs.SalesHistoryDt.Rows.Count;
                XmlNode root = null;
                XmlElement data = null;
                // 更新日時初期化
                XmlElement update = null;
                // 伝票区分初期化
                XmlElement kubun = null;
                // 得意先ｺｰﾄﾞ初期化
                XmlElement kjcd = null;
                // 売上日付初期化
                XmlElement dndt = null;
                // 売上伝票番号初期化
                XmlElement dnno = null;
                // 売上行番号初期化uButton_SectionGuide
                XmlElement dngyno = null;
                // 品名初期化
                XmlElement pmncd = null;
                // メーカー名初期化
                XmlElement mkname = null;
                // BL商品コード初期化
                XmlElement blcd = null;
                // 出荷数初期化
                XmlElement sksu = null;
                // 売上単価初期化
                XmlElement unprc = null;
                // 売上金額初期化
                XmlElement taxexc = null;
                // 備考１初期化
                XmlElement note = null;
                // 備考2初期化
                XmlElement note2 = null;
                // 備考3初期化
                XmlElement note3 = null;
                // 元黒伝票番号初期化
                XmlElement mtdnno = null;
                XmlDocument xmldoc = new XmlDocument();
                XmlElement xmlelem = xmldoc.CreateElement("", "NETSEND", "");
                xmldoc.AppendChild(xmlelem);
                for (int i = 0; i < rowsCount; i++)
                {
                    root = xmldoc.SelectSingleNode("NETSEND");
                    data = xmldoc.CreateElement("DATA");

                    // 更新日時
                    update = xmldoc.CreateElement("KOSINBI");
                    update.InnerText = this._salesCprtAcs.SalesHistoryDt.Rows[i]["UpdateDateTime"].ToString();
                    data.AppendChild(update);

                    // 計上日
                    dndt = xmldoc.CreateElement("KEIJOBI");
                    dndt.InnerText = this._salesCprtAcs.SalesHistoryDt.Rows[i]["AddUpADate"].ToString();
                    data.AppendChild(dndt);

                    // 売上伝票番号
                    dnno = xmldoc.CreateElement("DENNO");
                    dnno.InnerText = this._salesCprtAcs.SalesHistoryDt.Rows[i]["SalesSlipNum"].ToString();
                    data.AppendChild(dnno);

                    // 売上行番号
                    dngyno = xmldoc.CreateElement("ROWNO");
                    dngyno.InnerText = this._salesCprtAcs.SalesHistoryDt.Rows[i]["SalesRowNo"].ToString();
                    data.AppendChild(dngyno);

                    // 伝票区分
                    kubun = xmldoc.CreateElement("DENKUBUN");
                    kubun.InnerText = this._salesCprtAcs.SalesHistoryDt.Rows[i]["SalesSlipCd"].ToString();
                    data.AppendChild(kubun);

                    // 得意先ｺｰﾄﾞ
                    kjcd = xmldoc.CreateElement("TOKUCD");
                    kjcd.InnerText = this._salesCprtAcs.SalesHistoryDt.Rows[i]["CustomerCode"].ToString();
                    data.AppendChild(kjcd);

                    // BL商品コード
                    blcd = xmldoc.CreateElement("HINCD");
                    blcd.InnerText = this._salesCprtAcs.SalesHistoryDt.Rows[i]["BLGoodsCode"].ToString();
                    data.AppendChild(blcd);

                    // 品名
                    pmncd = xmldoc.CreateElement("HINMEI");
                    // --- UPD 2021/07/29 陳永康 PMKOBETSU-4115 売上データ連携送信文字不正対応 ----->>>>>
                    //pmncd.InnerText = this._salesCprtAcs.SalesHistoryDt.Rows[i]["GoodsNameKana"].ToString();
                    if (!string.IsNullOrEmpty(this._salesCprtAcs.SalesHistoryDt.Rows[i]["GoodsNameKana"].ToString()))
                    {
                        pmncd.InnerText = ChangeIllegalChar(this._salesCprtAcs.SalesHistoryDt.Rows[i]["GoodsNameKana"].ToString());
                    }
                    else
                    {
                        pmncd.InnerText = string.Empty;
                    }
                    // --- UPD 2021/07/29 陳永康 PMKOBETSU-4115 売上データ連携送信文字不正対応 -----<<<<<
                    data.AppendChild(pmncd);

                    // メーカー名
                    mkname = xmldoc.CreateElement("MAKERMEI");
                    // --- UPD 2021/07/29 陳永康 PMKOBETSU-4115 売上データ連携送信文字不正対応 ----->>>>>
                    //mkname.InnerText = this._salesCprtAcs.SalesHistoryDt.Rows[i]["MakerName"].ToString();
                    if (!string.IsNullOrEmpty(this._salesCprtAcs.SalesHistoryDt.Rows[i]["MakerName"].ToString()))
                    {
                        mkname.InnerText = ChangeIllegalChar(this._salesCprtAcs.SalesHistoryDt.Rows[i]["MakerName"].ToString());
                    }
                    else
                    {
                        mkname.InnerText = string.Empty;
                    }
                    // --- UPD 2021/07/29 陳永康 PMKOBETSU-4115 売上データ連携送信文字不正対応 -----<<<<<
                    data.AppendChild(mkname);

                    // 出荷数
                    sksu = xmldoc.CreateElement("SYUKKASU");
                    sksu.InnerText = this._salesCprtAcs.SalesHistoryDt.Rows[i]["ShipmentCnt"].ToString();
                    data.AppendChild(sksu);

                    // 売上単価
                    unprc = xmldoc.CreateElement("URITAN");
                    unprc.InnerText = this._salesCprtAcs.SalesHistoryDt.Rows[i]["SalesUnPrcTaxExcFl"].ToString();
                    data.AppendChild(unprc);

                    // 売上金額
                    taxexc = xmldoc.CreateElement("URIKIN");
                    taxexc.InnerText = this._salesCprtAcs.SalesHistoryDt.Rows[i]["SalesMoneyTaxExc"].ToString();
                    data.AppendChild(taxexc);

                    // 備考１
                    note = xmldoc.CreateElement("BIKO1");
                    // --- UPD 2021/07/29 陳永康 PMKOBETSU-4115 売上データ連携送信文字不正対応 ----->>>>>
                    //note.InnerText = this._salesCprtAcs.SalesHistoryDt.Rows[i]["SlipNote"].ToString();
                    if (!string.IsNullOrEmpty(this._salesCprtAcs.SalesHistoryDt.Rows[i]["SlipNote"].ToString()))
                    {
                        note.InnerText = ChangeIllegalChar(this._salesCprtAcs.SalesHistoryDt.Rows[i]["SlipNote"].ToString());
                    }
                    else
                    {
                        note.InnerText = string.Empty;
                    }
                    // --- UPD 2021/07/29 陳永康 PMKOBETSU-4115 売上データ連携送信文字不正対応 -----<<<<<
                    data.AppendChild(note);
                    // 備考２
                    note2 = xmldoc.CreateElement("BIKO2");
                    // --- UPD 2021/07/29 陳永康 PMKOBETSU-4115 売上データ連携送信文字不正対応 ----->>>>>
                    //note2.InnerText = this._salesCprtAcs.SalesHistoryDt.Rows[i]["SlipNote2"].ToString();
                    if (!string.IsNullOrEmpty(this._salesCprtAcs.SalesHistoryDt.Rows[i]["SlipNote2"].ToString()))
                    {
                        note2.InnerText = ChangeIllegalChar(this._salesCprtAcs.SalesHistoryDt.Rows[i]["SlipNote2"].ToString());
                    }
                    else
                    {
                        note2.InnerText = string.Empty;
                    }
                    // --- UPD 2021/07/29 陳永康 PMKOBETSU-4115 売上データ連携送信文字不正対応 -----<<<<<
                    data.AppendChild(note2);
                    // 備考３
                    note3 = xmldoc.CreateElement("BIKO3");
                    // --- UPD 2021/07/29 陳永康 PMKOBETSU-4115 売上データ連携送信文字不正対応 ----->>>>>
                    //note3.InnerText = this._salesCprtAcs.SalesHistoryDt.Rows[i]["SlipNote3"].ToString();
                    if (!string.IsNullOrEmpty(this._salesCprtAcs.SalesHistoryDt.Rows[i]["SlipNote3"].ToString()))
                    {
                        note3.InnerText = ChangeIllegalChar(this._salesCprtAcs.SalesHistoryDt.Rows[i]["SlipNote3"].ToString());
                    }
                    else
                    {
                        note3.InnerText = string.Empty;
                    }
                    // --- UPD 2021/07/29 陳永康 PMKOBETSU-4115 売上データ連携送信文字不正対応 -----<<<<<
                    data.AppendChild(note3);

                    // 元黒伝票番号
                    mtdnno = xmldoc.CreateElement("MOTODENNO");
                    mtdnno.InnerText = this._salesCprtAcs.SalesHistoryDt.Rows[i]["DebitNLnkSalesSlNum"].ToString();
                    data.AppendChild(mtdnno);

                    root.AppendChild(data);
                }

                //XML書き込み
                xmlFileName = this.GetXmlFileName(fileName);                
                xmldoc.Save(xmlFileName);
            }
            catch
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                resultMessageIn = "XMLファイルの書き込みに失敗しました。";
                MsgDispProc(emErrorLevel.ERR_LEVEL_STOP, resultMessageIn, (int)ConstantManagement.MethodResult.ctFNC_ERROR);
            }

            return status;
        }

        // --- ADD 2021/07/29 陳永康 PMKOBETSU-4115 売上データ連携送信文字不正対応 ----->>>>>
        /// <summary>
        /// 禁則文字変換処理
        /// </summary>
        /// <remarks>
        /// <br>Note	   : 禁則文字だけを抜く。</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2021/07/29</br>
        /// </remarks>
        private string ChangeIllegalChar(string bfString)
        {
            string afString = bfString;
            //NULL文字
            afString = afString.Replace("\0", string.Empty);
            //キャレッジリターン
            afString = afString.Replace("\r", string.Empty);
            //改行
            afString = afString.Replace("\n", string.Empty);
            //タブ文字
            afString = afString.Replace("\t", string.Empty);
            //アラート文字
            afString = afString.Replace("\a", string.Empty);
            //バックスペース
            afString = afString.Replace("\b", string.Empty);
            //改ページ
            afString = afString.Replace("\f", string.Empty);
            //垂直タブ
            afString = afString.Replace("\v", string.Empty);

            return afString;
        }
        // --- ADD 2021/07/29 陳永康 PMKOBETSU-4115 売上データ連携送信文字不正対応 -----<<<<<
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
        /// <br>Programmer	: 田建委</br>
        /// <br>Date		: 2019/12/02</br>
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

        #region ◎ エラーメッセージ表示処理
        /// <summary>
        /// エラーメッセージ表示処理
        /// </summary>
        /// <param name="message">表示メッセージ</param>
        /// <param name="status">ステータス</param>
        /// <param name="procnm">発生メソッドID</param>
        /// <param name="ex">例外情報</param>
        /// <remarks>
        /// <br>Note       : エラーメッセージの表示を行います。</br>
        /// <br>Programmer	: 田建委</br>
        /// <br>Date		: 2019/12/02</br>
        /// </remarks>
        private void MsgDispProc(string message, int status, string procnm, Exception ex)
        {
            string errMessage = message + "\r\n" + ex.Message;

            TMsgDisp.Show(
                this, 								// 親ウィンドウフォーム
                emErrorLevel.ERR_LEVEL_STOP, 		// エラーレベル
                ct_ClassID,							// アセンブリＩＤまたはクラスＩＤ
                this._printName,					// プログラム名称
                procnm, 							// 処理名称
                "",									// オペレーション
                errMessage,							// 表示するメッセージ
                status, 							// ステータス値
                null, 								// エラーが発生したオブジェクト
                MessageBoxButtons.OK, 				// 表示するボタン
                MessageBoxDefaultButton.Button1);	// 初期表示ボタン
        }
        #endregion
        #endregion ◆ エラーメッセージ表示処理 ( +1のオーバーロード )

        /// <summary>
        /// XMLの削除
        /// </summary>
        /// <param name="fileName">ファイル名</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note		: XMLの削除する。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2019/12/02</br>								
        /// </remarks>
        private int DeleteXmlFile(string fileName)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            string resultMessageDe = string.Empty;
            string xmlFileName = this.GetXmlFileName(fileName);
            try
            {
                // ファイルを削除
                FileInfo info = new FileInfo(xmlFileName);
                info.Delete();
            }
            catch
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                resultMessageDe = "XMLファイルの削除に失敗しました。";
                MsgDispProc(emErrorLevel.ERR_LEVEL_STOP, resultMessageDe, (int)ConstantManagement.MethodResult.ctFNC_ERROR);
            }
            return status;
        }

        /// <summary>
        /// 送信ファイル名を取る
        /// </summary>
        /// <param name="fileName">ファイル名</param>
        /// <remarks>
        /// <br>Note		: 送信ファイル名を取る</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2019/12/02</br>								
        /// </remarks>
        private String GetXmlFileName(string fileName) 
        {
            string xmlFileName = string.Empty;
            if (!String.IsNullOrEmpty(fileName))
            {
                if (fileName.Contains("."))
                {
                    int index = fileName.LastIndexOf(".");
                    fileName = fileName.Substring(0, index) + ".XML";
                }
                else
                {
                    fileName = fileName + ".XML";
                }
                xmlFileName = System.IO.Path.GetFullPath(ConstantManagement_ClientDirectory.PRTOUT) + "\\" + fileName;
            }
            return xmlFileName;
        }

        #endregion ■ Private Method

        # region Control Events

        /// <summary>
        /// PMSDC02010UA_Load Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: ユーザーがﾌｫｰﾑを読み込むときに発生する</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2019/12/02</br>
        /// </remarks>
        private void PMSDC02010UA_Load(object sender, EventArgs e)
        {
            string errMsg = string.Empty;

            // コントロール初期化
            int status = this.InitializeScreen(out errMsg);
            if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                MsgDispProc(emErrorLevel.ERR_LEVEL_STOPDISP, errMsg, status);
                return;
            }

            // ガイドボタンのアイコン設定
            this.SetIconImage(this.ub_CustomerCode_St, Size16_Index.STAR1);
            this.SetIconImage(this.uButton_SectionGuide, Size16_Index.STAR1);

            // 画面イメージ統一
            // 画面スキンファイルの読込(デフォルトスキン指定)
            this._controlScreenSkin.LoadSkin();

            // 画面スキン変更
            this._controlScreenSkin.SettingScreenSkin(this);

            // ツールバー設定イベント
            ParentToolbarSettingEvent(this);
        }

        /// <summary>
        /// 得意先ガイドクリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <br>Programmer  : 田建委</br>
        /// <br>Date        : 2019/12/02</br>
        private void ub_CustomerCode_St_Click(object sender, EventArgs e)
        {
            _customerGuid = false;
            // フォーカス制御用、ガイド呼出前の得意先コード
            PMKHN04005UA customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_CUSTOMER_ONLY, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY);
            customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.CustomerSearchForm_StCustomerSelect);
            customerSearchForm.ShowDialog(this);
            if (_customerGuid)
            {
                Control nextControl = null;
                nextControl = this.tComboEditor_PdfOutDiv;
                // フォーカス
                nextControl.Focus();
            }
        }

        /// <summary>
        /// 得意先選択時発生イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="customerSearchRet">得意先車両検索戻り値クラス</param>
        /// <remarks>
        /// <br>Note　　　  : 得意先コードガイドクリック時に発生イベント</br>
        /// <br>Programmer  : 田建委</br>
        /// <br>Date        : 2019/12/02</br>
        /// </remarks>
        private void CustomerSearchForm_StCustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        {
            // イベントハンドラを渡した相手から戻り値クラスを受け取れなければ終了
            if (customerSearchRet == null) return;

            // DBデータを読み出す(キャッシュを使用)
            CustomerInfo customerInfo;
            int status = this._customerInfoAcs.ReadDBData(customerSearchRet.EnterpriseCode, customerSearchRet.CustomerCode, true, out customerInfo);

            // ステータスによりエラーメッセージを出力
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && customerInfo != null)
            {
                // 得意先情報をUIに設定
                _prevInputValue.CustomerCode = customerInfo.CustomerCode;
                // 得意先コードのセット
                this.tNedit_CustomerCode.SetInt(customerInfo.CustomerCode);
                // 得意先名称のセット
                this.uLabel_CustomerName.Text = SubStringOfByte(customerInfo.CustomerSnm.TrimEnd(), 20);
            }
            // 得意先情報の取得に失敗
            else
            {
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_STOPDISP, ct_PGID,
                    ct_CustNotFound,
                    status, MessageBoxButtons.OK);

                this.tNedit_CustomerCode.SetInt(_prevInputValue.CustomerCode);
                return;
            }
        }

        /// <summary>
        /// 得意先コード
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note        : tNedit_CustomerCode_Leave イベント。</br>
        /// <br>Programmer  : 田建委</br>
        /// <br>Date        : 2019/12/02</br>
        /// </remarks>
        private void tNedit_CustomerCode_Leave(object sender, EventArgs e)
        {
            int customerCode = 0;
            // 得意先コード入力値不正
            if (!Int32.TryParse(this.tNedit_CustomerCode.Text.Trim(), out customerCode))
            {
                this.tNedit_CustomerCode.Clear();
                this.uLabel_CustomerName.Text = string.Empty;

                return;
            }
            // 画面に得意先コードの取得
            customerCode = this.tNedit_CustomerCode.GetInt();
            // 得意先コードが入力された場合
            if (customerCode > 0)
            {
                // 得意先名称の取得
                string customerName = string.Empty;
                int status = GetCustomerName(customerCode, out customerName);
                // 得意先名称取得成功
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // 画面に得意先名称のセット
                    this.uLabel_CustomerName.Text = SubStringOfByte(customerName, 20);
                }
                else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                {
                    TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, ct_PGID,
                                    "得意先" + ct_NotExists,
                                    0, MessageBoxButtons.OK);
                    // 前回値表示
                    // 前回値がある場合
                    if (_prevInputValue.CustomerCode != 0)
                    {
                        this.tNedit_CustomerCode.Text = _prevInputValue.CustomerCode.ToString();
                    }
                    // 前回値がない場合
                    else
                    {
                        this.tNedit_CustomerCode.Text = string.Empty;
                    }
                    this.tNedit_CustomerCode.SelectAll();
                    this.tNedit_CustomerCode.Focus();
                }
            }
        }

        /// <summary>
        /// 得意先名称取得処理
        /// </summary>
        /// <param name="customerCode">検索する得意先コード</param>
        /// <param name="customerName">得意先名称</param>
        /// <returns>得意先名称</returns>
        /// <remarks>
        /// <br>Note        : 得意先名称取得処理を行う。</br>
        /// <br>Programmer  : 田建委</br>
        /// <br>Date        : 2019/12/02</br>
        /// </remarks>
        private int GetCustomerName(int customerCode, out string customerName)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            // 得意先名称
            customerName = string.Empty;
            // 得意先情報
            CustomerInfo customerInfo;
            // 指定した得意先の情報の取得
            status = this._customerInfoAcs.ReadDBData(this._enterpriseCode, customerCode, out customerInfo);
            // 得意先情報取得成功場合
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && customerInfo.LogicalDeleteCode == 0 && customerInfo.IsCustomer)
            {
                // 得意先名称を戻す
                _prevInputValue.CustomerCode = customerCode;
                customerName = customerInfo.CustomerSnm.TrimEnd();
            }

            return status; 
        }

        #region[文字列　バイト数指定切り抜き]
        /// <summary>
        /// 文字列　バイト数指定切り抜き
        /// </summary>
        /// <param name="orgString">元の文字列</param>
        /// <param name="byteCount">バイト数</param>
        /// <returns>指定バイト数で切り抜いた文字列</returns>
        /// <remarks>
        /// <br>Note        : 文字列　バイト数指定切り抜きを行います。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2019/12/02</br>
        /// </remarks>
        private string SubStringOfByte(string orgString, int byteCount)
        {
            // 無効パラメータ
            if (byteCount <= 0)
            {
                return string.Empty;
            }

            Encoding encoding = Encoding.Default;
            // 戻り値
            string resultString = string.Empty;

            // あらかじめ「文字数」を指定して切り抜いておく
            // (この段階でbyte数は<文字数>～2*<文字数>の間になる)
            orgString = orgString.PadRight(byteCount).Substring(0, byteCount);
            // バイト数
            int count;

            for (int i = orgString.Length; i >= 0; i--)
            {
                // 「文字数」を減らす
                resultString = orgString.Substring(0, i);

                // バイト数を取得して判定
                count = encoding.GetByteCount(resultString);
                if (count <= byteCount) break;
            }

            // 終端の空白は削除
            return resultString;
        }
        #endregion

        /// <summary>
        /// エクスプローラーバー グループ縮小 イベント
        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント情報</param>
        /// <remarks>
        /// <br>Note       : グループが縮小される前に発生します。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2019/12/02</br>
        /// </remarks>
        private void ueb_MainExplorerBar_GroupCollapsing(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
        {
            if ((e.Group.Key == "ReportSelectGroup") ||
                (e.Group.Key == "FileTypeGroup"))
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
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2019/12/02</br>
        /// </remarks>
        private void ueb_MainExplorerBar_GroupExpanding(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
        {
            if ((e.Group.Key == "ReportSelectGroup") ||
                (e.Group.Key == "FileTypeGroup"))
            {
                // グループの縮小をキャンセル
                e.Cancel = true;
            }
        }
        # endregion

        #region 拠点
        /// <summary>
        /// 拠点ガイドボタン
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 拠点ガイドボタンのクリックを行う。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2019/12/02</br>
        /// </remarks>
        private void uButton_SectionGuide_Click(object sender, EventArgs e)
        {
            // 拠点ガイド表示
            SecInfoSet sectionInfo;
            // 拠点情報の取得
            int status = this._secInfoSetAcs.ExecuteGuid(this._enterpriseCode, true, out sectionInfo);

            // ステータスが正常時のみ情報をUIにセット
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                _prevInputValue.SectionCode = sectionInfo.SectionCode.Trim();
                this.tEdit_SectionCode.Text = sectionInfo.SectionCode.Trim();
                this.tEdit_SectionName.Text = sectionInfo.SectionGuideNm.Trim();

                this.tNedit_CustomerCode.Focus();
            }
            // ステータスが異常時、前回拠点情報を画面にセットする
            else if (status == (int)ConstantManagement.DB_Status.ctDB_ERROR ||
                status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                this.tEdit_SectionCode.Text = _prevInputValue.SectionCode;
            }
        }

        /// <summary>
        /// 拠点コード
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : tEdit_SectionCode_Leave イベント。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2019/12/02</br>
        /// </remarks>
        private void tEdit_SectionCode_Leave(object sender, EventArgs e)
        {
            int sectionCd = 0;
            // 拠点入力値不正
            if (!Int32.TryParse(this.tEdit_SectionCode.Text.Trim(), out sectionCd))
            {
                // 拠点初期値をセットする
                // 拠点コードは空白ではない場合
                if (!string.IsNullOrEmpty(this.tEdit_SectionCode.Text.Trim()))
                {
                    this.tEdit_SectionCode.Text = _prevInputValue.SectionCode.Trim();
                    if (("0").Equals(_prevInputValue.SectionCode.Trim()) || ("00").Equals(_prevInputValue.SectionCode.Trim()))
                    {
                        this.tEdit_SectionName.Text = string.Empty;
                    }
                    else
                    {
                        this.tEdit_SectionName.Text = this.GetSectionName(_prevInputValue.SectionCode.Trim());
                    }
                }
                // 拠点コードは空白の場合
                else
                {
                    this.tEdit_SectionCode.Text = string.Empty;
                    this.tEdit_SectionName.Text = string.Empty;
                }

                return;
            }

            // 名称変換
            this._sectionCode = this.tEdit_SectionCode.Text.Trim().PadLeft(2, '0');
            string sectionName = string.Empty;

            // 全社対応処理
            if (this._sectionCode.Equals("0") || this._sectionCode.Equals("00"))
            {
                // コードは規定の全体コードへ（検索時には規定の全体コードのとき空白にする）
                _prevInputValue.SectionCode = string.Empty;
                this._sectionCode = string.Empty;
                this.tEdit_SectionCode.Text = string.Empty;
                sectionName = string.Empty;
                this.tEdit_SectionName.Text = sectionName;
            }
            // 拠点コードが入力された場合
            else if (!String.IsNullOrEmpty(this._sectionCode))
            {
                // 拠点名称の取得
                sectionName = this.GetSectionName(this._sectionCode);
                if (!String.IsNullOrEmpty(sectionName))
                {
                    // 画面に拠点名称のセット
                    this.tEdit_SectionName.Text = sectionName;
                }
                // 拠点名称取得失敗場合
                else
                {
                    TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, ct_PGID,
                    "拠点" + ct_NotExists,
                    0, MessageBoxButtons.OK);
                    // 前回値表示
                    this.tEdit_SectionCode.Text = _prevInputValue.SectionCode;
                    this.tEdit_SectionCode.Focus();
                    this.tEdit_SectionCode.SelectAll();
                }
            }
        }

        /// <summary>
        /// 拠点名称取得処理
        /// </summary>
        /// <param name="sectionCd">検索する拠点コード</param>
        /// <returns>拠点名</returns>
        /// <remarks>
        /// <br>Note        : 拠点名称取得処理を行う。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2019/12/02</br>
        /// </remarks>
        private string GetSectionName(string sectionCd)
        {
            // 拠点名称
            string sectionName = string.Empty;
            // 拠点情報
            SecInfoSet sectionInfo;
            // 指定した拠点の情報の取得
            int status = this._secInfoSetAcs.Read(out sectionInfo, this._enterpriseCode, sectionCd);
            // 拠点情報取得成功場合
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && sectionInfo.LogicalDeleteCode == 0)
            {
                // 拠点名称を戻す
                _prevInputValue.SectionCode = sectionCd;
                sectionName = sectionInfo.SectionGuideNm;
            }

            return sectionName;
        }

        #endregion // 拠点
        
    }
}
