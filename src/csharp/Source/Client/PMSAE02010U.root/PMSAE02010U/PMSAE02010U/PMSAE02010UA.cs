//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : S&E売上データテキスト出力
// プログラム概要   : S&E売上データテキスト出力帳票を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張凱
// 作 成 日  2009/08/13  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : zhuhh
// 修 正 日  2012/12/07  修正内容 : Ｓ＆ＥブレーキＡＢ商品コードの桁数の改修
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : zhuhh
// 作 成 日  2013/02/25  修正内容 : Ｓ＆Ｅ(AB) テキスト出力のレイアウト変更
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : zhuhh
// 作 成 日  2013/03/06  修正内容 : Ｓ＆Ｅ(AB) テキスト出力自動送信の追加
//----------------------------------------------------------------------------//
// 管理番号 10901034-00  作成担当 : 田建委  
// 修 正 日  2013/06/26  修正内容 : 送信ログの登録
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
using System.Xml; // ADD zhuhh 2013/03/06 for Redmine#35011
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 売上データテキスト出力クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 売上データテキスト出力UIで、抽出条件を入力します。</br>
    /// <br>Programmer : 張凱</br>
    /// <br>Date       : 2009.08.13</br>
    /// <br>UpdateNote : 2012/12/07 zhuhh</br>
    /// <br>           : Ｓ＆ＥブレーキＡＢ商品コードの桁数の改修</br>
    /// <br>UpdateNote : 2013/02/25 zhuhh</br>
    /// <br>           : Ｓ＆Ｅ(AB) テキスト出力のレイアウト変更</br>
    /// <br>UpdateNote : 2013/03/06 zhuhh</br>
    /// <br>           : Ｓ＆Ｅ(AB) テキスト出力自動送信の追加</br>
    /// <br>UpdateNote  : 2013/06/26 田建委</br>
    /// <br>            : 送信ログの登録</br>
    /// </remarks>
    public partial class PMSAE02010UA : Form,
                                IPrintConditionInpType,					// 帳票共通（条件入力タイプ）
                                IPrintConditionInpTypeSelectedSection,	// 帳票業務（条件入力）拠点選択
                                IPrintConditionInpTypePdfCareer,	    // 帳票業務（条件入力）PDF出力履歴管理
                                IPrintConditionInpTypeUpdate
    {
        #region ■ Constructor
        /// <summary>
        /// 売上データテキスト出力UIクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 売上データテキスト出力UI初期化およびインスタンスの生成を行う</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009.08.13</br>
        /// </remarks>
        public PMSAE02010UA()
        {
            InitializeComponent();

            // 企業コード取得
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            // ログイン拠点を取得
            this._loginWorker = LoginInfoAcquisition.Employee.Clone();
            this._ownSectionCode = this._loginWorker.BelongSectionCode;

            // 拠点用のHashtable作成
            this._selectedSectionList = new Hashtable();

            // 日付取得部品
            _dateGet = DateGetAcs.GetInstance();

            // UI設定保存コンポーネント設定
            this.SetUIMemInputControl();

            _salesHistoryAcs = new SalesHistoryAcs();

            _formattedTextWriter = new FormattedTextWriter();
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
        // 計上拠点選択表示取得プロパティ
        private bool _visibledSelectAddUpCd = false;
        // 拠点オプション有無
        private bool _isOptSection = true;
        // 本社機能有無
        private bool _isMainOfficeFunc = true;
        // 選択拠点リスト
        private Hashtable _selectedSectionList = new Hashtable();
        #endregion ◆ Interface member

        // 企業コード
        private string _enterpriseCode = "";
        // ログイン情報
        private Employee _loginWorker = null;
        // 自拠点コード
        private string _ownSectionCode = "";

        private bool _customerGuid;

        private int _mode = 0;

        // 画面イメージコントロール部品
        private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();

        // 抽出条件クラス
        private SalesHistoryCndtn _salesHistoryCndtn;

        private SalesHistoryAcs _salesHistoryAcs;

        private FormattedTextWriter _formattedTextWriter;

        //日付取得部品
        private DateGetAcs _dateGet;

        private int _totalCount;

        private SFCMN00299CA msgForm = null;// ADD zhuhh 2013/03/06 for Redmine#35011

        #endregion ■ Private Member

        #region ■ Private Const
        #region ◆ Interface member
        // クラスID
        private const string ct_ClassID = "PMSAE02010UA";
        // プログラムID
        private const string ct_PGID = "PMSAE02010U";
        // 帳票名称
        private const string PDF_PRINT_NAME = "合計確認リスト";
        private string _printName = PDF_PRINT_NAME;
        // 帳票キー	
        private const string PDF_PRINT_KEY = "12a0cb5b-871f-4769-8fd8-1a671eedc610";
        private string _printKey = PDF_PRINT_KEY;
        #endregion ◆ Interface member

        //エラー条件メッセージ
        const string ct_InputError = "の入力が不正です。";
        const string ct_NoInput = "を入力して下さい。";
        const string ct_RangeError = "の範囲指定に誤りがあります。";
        const string ct_NotOnYearError = "は１２ヶ月の範囲内で入力して下さい。";

        // ----- ADD 田建委 2013/06/26 ----->>>>>
        /// <summary>ログメッセージ：送信準備エラー</summary>
        private const string LOGMSG_ERROR = "送信準備エラー";

        private char[] _fileCharArr = new char[9] { '\\', '/', ':', '*', '?', '"', '<', '>', '|' };
        // ----- ADD 田建委 2013/06/26 -----<<<<<

        #endregion

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

        // ----- ADD 田建委 2013/06/26 ----->>>>>
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
        // ----- ADD 田建委 2013/06/26 -----<<<<<

        #region ◎ 確定処理
        /// <summary>
        /// 確定処理
        /// </summary>
        /// <param name="parameter">パラメータ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note		: 印刷処理を行う。</br>
        /// <br>Programmer	: 張凱</br>
        /// <br>Date		: 2009.08.13</br>
        /// <br>UpdateNote  : 2013/03/06 zhuhh</br>
        /// <br>            : Ｓ＆Ｅ(AB) テキスト出力自動送信の追加</br>
        /// <br>UpdateNote  : 2013/06/26 田建委</br>
        /// <br>            : 送信ログの登録</br>
        /// </remarks>
        public int Update(ref object parameter)
        {
            int status = -1;
            string errMsg = "";

            // ----- ADD 田建委 2013/06/26 ----->>>>>
            int logStatus = 0;
            SAndESalSndLogListResultWork sAndESalSndLogWork = null;
            // ----- ADD 田建委 2013/06/26 -----<<<<<

            // テキストファイル名 
            string fileName = tEdit_FileName.Text.Trim();
            if (string.IsNullOrEmpty(fileName))
            {
                TMsgDisp.Show(
                this,
                emErrorLevel.ERR_LEVEL_EXCLAMATION,
                this.Name,
                 "ファイル名を入力して下さい。",
                status,
                MessageBoxButtons.OK);
                this.tEdit_FileName.Focus();
                return status;
            }

            // ----- DEL 田建委 2013/06/26 ----->>>>>
            //if (!Directory.Exists(System.IO.Path.GetDirectoryName(fileName)))
            //{
            //    TMsgDisp.Show(
            //    this,
            //    emErrorLevel.ERR_LEVEL_EXCLAMATION,
            //    this.Name,
            //     "指定したフォルダがありません。",
            //    status,
            //    MessageBoxButtons.OK);
            //    this.tEdit_FileName.Focus();
            //    return status;
            //}
            // ----- DEL 田建委 2013/06/26 -----<<<<<

            // ----- ADD 田建委 2013/06/26 ----->>>>>            
            bool fileNameErrFlg = true;
            // ファイル名判定(拡張子が'.TXT'のみ)
            string str = fileName.Substring(fileName.LastIndexOf("\\") + 1);
            int suffixIndex = str.LastIndexOf(".");
            if (suffixIndex > 0 && !str.Substring(0, 1).Equals(" "))
            {
                if (CheckFileStr(str))
                {
                    fileNameErrFlg = false;
                }
                else
                {
                    string suffixName = str.Substring(suffixIndex).ToUpper();
                    if (suffixName != ".TXT")
                    {
                        fileNameErrFlg = false;
                    }
                }
            }
            else
            {
                fileNameErrFlg = false;
            }

            if (!fileNameErrFlg)
            {
                TMsgDisp.Show(
                  this,
                  emErrorLevel.ERR_LEVEL_EXCLAMATION,
                  this.Name,
                   "指定されたファイル名が不正です。",
                  status,
                  MessageBoxButtons.OK);
                this.tEdit_FileName.Focus();
                return status;
            }

            bool directoryNameErrFlg = true;
            try
            {
                if (!Directory.Exists(System.IO.Path.GetDirectoryName(fileName)))
                {
                    directoryNameErrFlg = false;
                }
            }
            catch (ArgumentException)
            {
                directoryNameErrFlg = false;
            }

            if (!directoryNameErrFlg)
            {
                TMsgDisp.Show(
                this,
                emErrorLevel.ERR_LEVEL_EXCLAMATION,
                this.Name,
                 "指定したフォルダがありません。",
                status,
                MessageBoxButtons.OK);
                this.tEdit_FileName.Focus();
                return status;
            }
            // ----- ADD 田建委 2013/06/26 -----<<<<<

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

            try
            {
                //データ抽出処理
                status = this._salesHistoryAcs.SearchSalesHistoryProcMain(this._salesHistoryCndtn, out errMsg);
            }
            catch (Exception)
            {
                MsgDispProc(emErrorLevel.ERR_LEVEL_STOP, errMsg, 0);
            }

            if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                if (status == (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN)
                {
                    MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, errMsg, 0);
                }
                else
                {
                    MsgDispProc(emErrorLevel.ERR_LEVEL_STOP, errMsg, 0);
                }
                return status;
            }

            //テキスト出力処理
            try
            {
                _totalCount = 0;

                //FormattedTextWriterクラスのプロパティ
                SetFormattedTextWriter();

                status = _formattedTextWriter.TextOut(out _totalCount);
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                // ----- ADD 田建委 2013/06/26 --------------->>>>>
                if (this._salesHistoryCndtn.AutoDataSendDiv == 0)
                {
                    status = -1;
                    this._salesHistoryAcs.SendDateTimeEnd = Convert.ToInt64(DateTime.Now.ToString("yyyyMMddHHmmss"));
                    logStatus = this._salesHistoryAcs.WriteLogInfo(this._salesHistoryCndtn, ref sAndESalSndLogWork, status, LOGMSG_ERROR);
                }
                // ----- ADD 田建委 2013/06/26 ---------------<<<<<
            }

            if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                // ----- ADD 田建委 2013/06/26 --------------->>>>>
                if (this._salesHistoryCndtn.AutoDataSendDiv == 0)
                {
                    status = -1;
                    this._salesHistoryAcs.SendDateTimeEnd = Convert.ToInt64(DateTime.Now.ToString("yyyyMMddHHmmss"));
                    logStatus = this._salesHistoryAcs.WriteLogInfo(this._salesHistoryCndtn, ref sAndESalSndLogWork, status, LOGMSG_ERROR);
                }
                // ----- ADD 田建委 2013/06/26 ---------------<<<<<
                MsgDispProc(emErrorLevel.ERR_LEVEL_STOP, "テキスト出力に失敗しました。", 0);

                return status;
            }

            // ----- ADD zhuhh 2013/03/06 for Redmine#35011----- >>>>>
            if (this._salesHistoryCndtn.AutoDataSendDiv == 0)
            {
                msgForm = new SFCMN00299CA();
                msgForm.Title = "送信中";
                msgForm.Message = "現在、データ送信中です。                  ￥nしばらくお待ちください";
                msgForm.Show();
                this.DeleteXmlFile();
                status=SaveNetSendSetting();
                if (status != (int)ConstantManagement.MethodResult.ctFNC_CANCEL)
                {                    
                    //status = this._salesHistoryAcs.SendAndReceive(ref this._salesHistoryCndtn, fileName); // DEL 田建委 2013/06/26
                    // 0:自動送信;1:手動送信
                    status = this._salesHistoryAcs.SendAndReceive(ref this._salesHistoryCndtn, fileName, out sAndESalSndLogWork, out logStatus); // ADD 田建委 2013/06/26
                }
                else 
                {
                    //なし
                }
                if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    msgForm.Close();
                    MsgDispProc(emErrorLevel.ERR_LEVEL_STOP, "自動送信処理に失敗しました。", 0);
                    
                    // ----- ADD 田建委 2013/06/26 --------------->>>>>
                    if (logStatus == (int)ConstantManagement.DB_Status.ctDB_DUPLICATE ||
                        logStatus == (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE ||
                        logStatus == (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE)
                    {
                        MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, "送信ログは、既に他の端末で登録されています。", 0);
                    }
                    // ----- ADD 田建委 2013/06/26 ---------------<<<<<
                    return status;
                }
                else 
                {
                    msgForm.Close(); 

                    // ----- ADD 田建委 2013/06/26 --------------->>>>>
                    if (logStatus == (int)ConstantManagement.DB_Status.ctDB_DUPLICATE ||
                        logStatus == (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE ||
                        logStatus == (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE)
                    {
                        MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, "送信ログは、既に他の端末で登録されています。", 0);
                    }
                    // ----- ADD 田建委 2013/06/26 ---------------<<<<<
                }
            }
            else 
            {
                //なし
            }
            // ----- ADD zhuhh 2013/03/06 for Redmine#35011----- <<<<<

            //S&E売上抽出データ更新処理
            try
            {
                //データ抽出処理
                status = this._salesHistoryAcs.Write(out errMsg);
            }
            catch (Exception)
            {
                MsgDispProc(emErrorLevel.ERR_LEVEL_STOP, errMsg, 0);
            }

            if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                // ファイル削除
                status = this.DeleteFile();

                MsgDispProc(emErrorLevel.ERR_LEVEL_STOP, errMsg, 0);

                return status;
            }

            //印刷処理
            _mode = 1;

            this._salesHistoryCndtn.Mode = 1;

            Print(ref parameter);

            //画面モードの初期化
            _mode = 0;

            this._salesHistoryCndtn.Mode = 0;

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
        /// <br>Programmer	: 張凱</br>
        /// <br>Date		: 2009.08.13</br>
        /// </remarks>
        public int Print(ref object parameter)
        {
            int status = -1;
            if (1 == (int)this.tComboEditor_ConFirmDiv.Value && _mode == 1)
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    _totalCount.ToString() + "行のデータをファイルへ出力しました。",
                    status,
                    MessageBoxButtons.OK);

                return status;
            }

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
                this._salesHistoryCndtn.Mode = 1;
            }
            else
            {
                this._salesHistoryCndtn.Mode = 0;

            }

            // 抽出条件の設定
            printInfo.jyoken = this._salesHistoryCndtn;
            printDialog.PrintInfo = printInfo;

            printInfo.rdData = this._salesHistoryAcs.GetprintdataTable();

            // 帳票選択ガイド
            DialogResult dialogResult = printDialog.ShowDialog();

            if (printInfo.status == (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN)
            {
                MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "該当するデータがありません。", 0);
            }

            if (printInfo.status == (int)ConstantManagement.MethodResult.ctFNC_ERROR)
            {
                MsgDispProc(emErrorLevel.ERR_LEVEL_STOP, "データ抽出処理に失敗しました。", 0);
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
        /// <br>Programmer	: 張凱</br>
        /// <br>Date		: 2009.08.13</br>
        /// <br>UpdateNote  : 2013/03/06 zhuhh</br>
        /// <br>            : Ｓ＆Ｅ(AB) テキスト出力自動送信の追加</br>
        /// </remarks>
        private void SetUIMemInputControl()
        {
            // 入力保存項目をセット
            List<Control> saveCtrAry = new List<Control>();

            saveCtrAry.Add(this.tde_St_AddUpDate);
            saveCtrAry.Add(this.tde_Ed_AddUpDate);
            saveCtrAry.Add(this.tComboEditor_ConFirmDiv);
            saveCtrAry.Add(this.tNedit_CustomerCode_St);
            saveCtrAry.Add(this.tNedit_CustomerCode_Ed);
            saveCtrAry.Add(this.tComboEditor_PdfOutDiv);
            saveCtrAry.Add(this.tEdit_FileName);
            saveCtrAry.Add(this.uos_DataSendDiv);// ADD zhuhh 2013/03/06 for Redmine#35011

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
        /// <br>Programmer	: 張凱</br>
        /// <br>Date		: 2009.08.13</br>
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
        /// <br>Programmer	: 張凱</br>
        /// <br>Date		: 2009.08.13</br>
        /// </remarks>
        public void Show(object parameter)
        {
            this.Show();
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
        /// <br>Programmer	: 張凱</br>
        /// <br>Date		: 2009.08.13</br>
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
        /// <br>Programmer	: 張凱</br>
        /// <br>Date		: 2009.08.13</br>
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
        /// <br>Programmer	: 張凱</br>
        /// <br>Date		: 2009.08.13</br>
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
        /// <br>Programmer	: 張凱</br>
        /// <br>Date		: 2009.08.13</br>
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
        /// <br>Programmer	: 張凱</br>
        /// <br>Date		: 2009.08.13</br>
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

        #region ■ Private Method
        #region ◆ 画面初期化関係
        #region ◎ 画面初期化処理
        /// <summary>
        /// 画面初期化処理
        /// </summary>
        /// <remarks>
        /// <br>Note		: 入力項目の初期化を行う</br>
        /// <br>Programmer	: 張凱</br>
        /// <br>Date		: 2009.08.13</br>
        /// </remarks>
        private int InitializeScreen(out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            errMsg = string.Empty;

            try
            {
                this.tComboEditor_ConFirmDiv.Value = 0;

                this.tComboEditor_PdfOutDiv.Value = 2;

                this.tEdit_FileName.Text = System.IO.Path.GetFullPath(ConstantManagement_ClientDirectory.PRTOUT) + "\\URI.TXT";

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
        /// <br>Programmer	: 張凱</br>
        /// <br>Date		: 2009.08.13</br>
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

            // 得意先（開始～終了）
            if (!string.IsNullOrEmpty(this.tNedit_CustomerCode_St.DataText.TrimEnd())
                && !string.IsNullOrEmpty(this.tNedit_CustomerCode_Ed.DataText.TrimEnd()))
            {
                if (this.tNedit_CustomerCode_St.GetInt() > this.tNedit_CustomerCode_Ed.GetInt())
                {
                    errMessage = string.Format("得意先{0}", ct_RangeError);
                    errComponent = this.tNedit_CustomerCode_Ed;
                    status = false;
                    return status;
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
        /// <br>Programmer	: 張凱</br>
        /// <br>Date		: 2009.08.13</br>
        /// <br>UpdateNote  : 2013/03/06 zhuhh</br>
        /// <br>            : Ｓ＆Ｅ(AB) テキスト出力自動送信の追加</br>
        /// </remarks>
        private int SetExtraInfoFromScreen()
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            this._salesHistoryCndtn = new SalesHistoryCndtn();
            try
            {
                // 企業コード
                this._salesHistoryCndtn.EnterpriseCode = this._enterpriseCode;
                // 「全拠点」が選択されている場合はリストをクリア
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

                // 計上拠点コード（複数指定）
                ArrayList sectionList = new ArrayList(this._selectedSectionList.Values);
                this._salesHistoryCndtn.SectionCodeList = (string[])sectionList.ToArray(typeof(string));

                // 計上日(開始)
                this._salesHistoryCndtn.AddUpADateSt = this.tde_St_AddUpDate.GetLongDate();

                // 計上日(終了)
                this._salesHistoryCndtn.AddUpADateEd = this.tde_Ed_AddUpDate.GetLongDate();

                //確認リスト
                this._salesHistoryCndtn.ConFirmDiv = (int)tComboEditor_ConFirmDiv.Value;

                // ----- ADD zhuhh 2013/03/06 for Redmine#35011----->>>>>
                //自動送信区分
                this._salesHistoryCndtn.AutoDataSendDiv = (int)this.uos_DataSendDiv.CheckedIndex;
                // ----- ADD zhuhh 2013/03/06 for Redmine#35011-----<<<<<

                // 得意先(開始)
                this._salesHistoryCndtn.CustomerCodeSt = this.tNedit_CustomerCode_St.GetInt();

                // 得意先(開始)
                this._salesHistoryCndtn.CustomerCodeEd = this.tNedit_CustomerCode_Ed.GetInt();

                // 出力指定
                this._salesHistoryCndtn.PdfOutDiv = (int)this.tComboEditor_PdfOutDiv.Value;

                // ファイル名
                this._salesHistoryCndtn.FileName = this.tEdit_FileName.Text;
            }
            catch (Exception)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }

            return status;
        }

        /// <summary>
        ///FormattedTextWriterクラス設定処理FormattedTextWriterクラス条件)
        /// </summary>
        /// <remarks>
        /// <br>Note		: FormattedTextWriterクラス条件へ設定する。</br>
        /// <br>Programmer	: 張凱</br>
        /// <br>Date		: 2009.08.13</br>
        /// <br>UpdateNote  : 2012/12/07 zhuhh</br>
        /// <br>            : Ｓ＆ＥブレーキＡＢ商品コードの桁数の改修</br>
        /// <br>UpdateNote  : 2013/02/25 zhuhh</br>
        /// <br>            : Ｓ＆Ｅ(AB) テキスト出力のレイアウト変更</br>
        /// </remarks>
        private void SetFormattedTextWriter()
        {
            List<string> schemeList = new List<string>();
            schemeList.Add(PMSAE02014EA.ct_Col_SalesSlipNum);
            schemeList.Add(PMSAE02014EA.ct_Col_RequestDiv);
            schemeList.Add(PMSAE02014EA.ct_Col_AddresseeShopCd);
            schemeList.Add(PMSAE02014EA.ct_Col_AddUpADate);
            schemeList.Add(PMSAE02014EA.ct_Col_GoodDiv);
            schemeList.Add(PMSAE02014EA.ct_Col_TradCompCd);
            schemeList.Add(PMSAE02014EA.ct_Col_TradCompRate);
            schemeList.Add(PMSAE02014EA.ct_Col_AbSalesRate);
            schemeList.Add(PMSAE02014EA.ct_Col_SalesRowNo);
            schemeList.Add(PMSAE02014EA.ct_Col_AdministrationNo);
            schemeList.Add(PMSAE02014EA.ct_Col_GoodsNo);
            schemeList.Add(PMSAE02014EA.ct_Col_GoodsNameKana);
            schemeList.Add(PMSAE02014EA.ct_Col_AbGoodsNo);
            schemeList.Add(PMSAE02014EA.ct_Col_ShipmentCnt);
            schemeList.Add(PMSAE02014EA.ct_Col_SalesUnPrcTaxExcFl);
            schemeList.Add(PMSAE02014EA.ct_Col_SalesMoneyTaxExc);
            schemeList.Add(PMSAE02014EA.ct_Col_SupplierMoney);
            schemeList.Add(PMSAE02014EA.ct_Col_SalesMoney);
            // ----- ADD zhuhh 2013/02/25 Ｓ＆Ｅ(AB) テキスト出力のレイアウト変更----- >>>>>
            schemeList.Add(PMSAE02014EA.ct_Col_ShopMoney);
            schemeList.Add(PMSAE02014EA.ct_Col_PriceMoney);
            // ----- ADD zhuhh 2013/02/25 Ｓ＆Ｅ(AB) テキスト出力のレイアウト変更----- <<<<<
            schemeList.Add(PMSAE02014EA.ct_Col_TxtCustomerCode);
            schemeList.Add(PMSAE02014EA.ct_Col_AreaCd);
            schemeList.Add(PMSAE02014EA.ct_Col_SearchSlipDate);
            schemeList.Add(PMSAE02014EA.ct_Col_SupplierCd);
            schemeList.Add(PMSAE02014EA.ct_Col_ExpenseDivCd);
            schemeList.Add(PMSAE02014EA.ct_Col_GoodsMakerCd);
            schemeList.Add(PMSAE02014EA.ct_Col_OrderNum);// ADD zhuhh 2013/02/25
            schemeList.Add(PMSAE02014EA.ct_Col_Filler);

            List<Type> enclosingTypeList = new List<Type>();
            enclosingTypeList.Add("".GetType());

            Dictionary<string, int> maxLengthList = new Dictionary<string, int>();
            maxLengthList.Add(PMSAE02014EA.ct_Col_SalesSlipNum, 6);
            maxLengthList.Add(PMSAE02014EA.ct_Col_RequestDiv, 3);
            maxLengthList.Add(PMSAE02014EA.ct_Col_AddresseeShopCd, 6);
            maxLengthList.Add(PMSAE02014EA.ct_Col_AddUpADate, 8);
            maxLengthList.Add(PMSAE02014EA.ct_Col_GoodDiv, 1);
            maxLengthList.Add(PMSAE02014EA.ct_Col_TradCompCd, 6);
            maxLengthList.Add(PMSAE02014EA.ct_Col_TradCompRate, 4);
            maxLengthList.Add(PMSAE02014EA.ct_Col_AbSalesRate, 4);
            maxLengthList.Add(PMSAE02014EA.ct_Col_SalesRowNo, 2);
            maxLengthList.Add(PMSAE02014EA.ct_Col_AdministrationNo, 4);
            maxLengthList.Add(PMSAE02014EA.ct_Col_GoodsNo, 16);
            //maxLengthList.Add(PMSAE02014EA.ct_Col_GoodsNameKana, 16);// DEL zhuhh 2013/02/25 Ｓ＆Ｅ(AB) テキスト出力のレイアウト変更
            maxLengthList.Add(PMSAE02014EA.ct_Col_GoodsNameKana, 20);// ADD zhuhh 2013/02/25 Ｓ＆Ｅ(AB) テキスト出力のレイアウト変更
            //maxLengthList.Add(PMSAE02014EA.ct_Col_AbGoodsNo, 6);// DEL zhuhh 2012/12/07 ＡＢ商品コードの桁数の改修
            maxLengthList.Add(PMSAE02014EA.ct_Col_AbGoodsNo, 8);// ADD zhuhh 2012/12/07 ＡＢ商品コードの桁数の改修
            maxLengthList.Add(PMSAE02014EA.ct_Col_ShipmentCnt, 8);
            maxLengthList.Add(PMSAE02014EA.ct_Col_SalesUnPrcTaxExcFl, 8);
            maxLengthList.Add(PMSAE02014EA.ct_Col_SalesMoneyTaxExc, 8);
            // ----- ADD zhuhh 2013/02/25 Ｓ＆Ｅ(AB) テキスト出力のレイアウト変更----->>>>>
            maxLengthList.Add(PMSAE02014EA.ct_Col_ShopMoney, 8);
            maxLengthList.Add(PMSAE02014EA.ct_Col_PriceMoney, 8);
            // ----- ADD zhuhh 2013/02/25 Ｓ＆Ｅ(AB) テキスト出力のレイアウト変更-----<<<<<
            maxLengthList.Add(PMSAE02014EA.ct_Col_SupplierMoney, 8);
            maxLengthList.Add(PMSAE02014EA.ct_Col_SalesMoney, 8);
            maxLengthList.Add(PMSAE02014EA.ct_Col_TxtCustomerCode, 6);
            maxLengthList.Add(PMSAE02014EA.ct_Col_AreaCd, 1);
            maxLengthList.Add(PMSAE02014EA.ct_Col_SearchSlipDate, 8);
            maxLengthList.Add(PMSAE02014EA.ct_Col_SupplierCd, 8);
            maxLengthList.Add(PMSAE02014EA.ct_Col_ExpenseDivCd, 1);
            maxLengthList.Add(PMSAE02014EA.ct_Col_GoodsMakerCd, 4);
            maxLengthList.Add(PMSAE02014EA.ct_Col_OrderNum, 6);// Add zhuhh 2013/02/25 Ｓ＆Ｅ(AB) テキスト出力のレイアウト変更
            maxLengthList.Add(PMSAE02014EA.ct_Col_Filler, 1);

            _formattedTextWriter.DataSource = this._salesHistoryAcs.SalesHistoryDt;
            _formattedTextWriter.DataMember = String.Empty;
            _formattedTextWriter.OutputFileName = this.tEdit_FileName.Text.Trim();
            //テキスト出力する項目名のリスト
            _formattedTextWriter.SchemeList = schemeList;
            _formattedTextWriter.Splitter = String.Empty;
            _formattedTextWriter.Encloser = String.Empty;
            _formattedTextWriter.EnclosingTypeList = enclosingTypeList;
            _formattedTextWriter.FormatList = null;
            _formattedTextWriter.CaptionOutput = false;
            _formattedTextWriter.FixedLength = true;
            _formattedTextWriter.ReplaceList = null;
            _formattedTextWriter.MaxLengthList = maxLengthList;
        }

        // ----- ADD zhuhh 2013/03/06 for Redmine#35011----->>>>>
        /// <summary>
        /// 自動送信XML生成
        /// </summary>
        /// <remarks>
        /// <br>Note		: 自動送信XMLを生成する。</br>
        /// <br>Programmer	: zhuhh</br>
        /// <br>Date		: 2013/03/06</br>
        /// </remarks>
        private int SaveNetSendSetting()
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            string resultMessageIn = string.Empty;
            string xmlFileName = string.Empty;
            try
            {
                int rowsCount = this._salesHistoryAcs.SalesHistoryDt.Rows.Count;
                XmlNode root = null;
                XmlElement data = null;
                // データ区分初期化
                XmlElement dtkbn = null;
                // TMY-ID分初期化
                XmlElement pmwscd = null;
                // 得意先ｺｰﾄﾞ初期化
                XmlElement kjcd = null;
                // 売上日付初期化
                XmlElement dndt = null;
                // 売上伝票番号初期化
                XmlElement dnno = null;
                // 売上行番号初期化
                XmlElement dngyno = null;
                // 商品番号初期化
                XmlElement pmncd = null;
                // 商品メーカーコード初期化
                XmlElement mkcd = null;
                // BL商品コード初期化
                XmlElement blcd = null;
                // 出荷数初期化
                XmlElement sksu = null;
                // 仕入先コード初期化
                XmlElement psicd = null;
                XmlDocument xmldoc = new XmlDocument();
                XmlElement xmlelem = xmldoc.CreateElement("", "NETSEND", "");
                xmldoc.AppendChild(xmlelem);
                for (int i = 0; i < rowsCount; i++)
                {
                    root = xmldoc.SelectSingleNode("NETSEND");
                    data = xmldoc.CreateElement("DATA");

                    // データ区分
                    dtkbn = xmldoc.CreateElement("DTKBN");
                    dtkbn.InnerText = this._salesHistoryAcs.SalesHistoryDt.Rows[i]["DataDiv"].ToString();
                    data.AppendChild(dtkbn);

                    // パーツマン端末コード
                    pmwscd = xmldoc.CreateElement("PMWSCD");
                    if (!String.IsNullOrEmpty(this._salesHistoryAcs.SalesHistoryDt.Rows[i]["PartsManWSCD"].ToString()))
                    {
                        pmwscd.InnerText = this._salesHistoryAcs.SalesHistoryDt.Rows[i]["PartsManWSCD"].ToString();
                    }                     
                    data.AppendChild(pmwscd);

                    // 得意先ｺｰﾄﾞ
                    kjcd = xmldoc.CreateElement("KJCD");
                    kjcd.InnerText = this._salesHistoryAcs.SalesHistoryDt.Rows[i]["TxtCustomerCode"].ToString();
                    data.AppendChild(kjcd);

                    // 売上日付
                    dndt = xmldoc.CreateElement("DNDT");
                    dndt.InnerText = this._salesHistoryAcs.SalesHistoryDt.Rows[i]["AddUpADate"].ToString();
                    data.AppendChild(dndt);

                    // 売上伝票番号
                    dnno = xmldoc.CreateElement("DNNO");
                    dnno.InnerText = this._salesHistoryAcs.SalesHistoryDt.Rows[i]["SalesSlipNum"].ToString();
                    data.AppendChild(dnno);

                    // 売上行番号
                    dngyno = xmldoc.CreateElement("DNGYNO");
                    dngyno.InnerText = this._salesHistoryAcs.SalesHistoryDt.Rows[i]["SalesRowNo"].ToString();
                    data.AppendChild(dngyno);

                    // 商品番号
                    pmncd = xmldoc.CreateElement("PHNCD");
                    pmncd.InnerText = this._salesHistoryAcs.SalesHistoryDt.Rows[i]["GoodsNo"].ToString();
                    data.AppendChild(pmncd);

                    // 商品メーカーコード
                    mkcd = xmldoc.CreateElement("MKCD");
                    mkcd.InnerText = this._salesHistoryAcs.SalesHistoryDt.Rows[i]["GoodsMakerCd"].ToString();
                    data.AppendChild(mkcd);

                    // BL商品コード
                    blcd = xmldoc.CreateElement("BLCD");
                    if (this._salesHistoryAcs.SalesHistoryDt.Rows[i]["AdministrationNo"] == DBNull.Value || this._salesHistoryAcs.SalesHistoryDt.Rows[i]["AdministrationNo"].ToString() == "")
                    {
                        blcd.InnerText = "0000";
                    }
                    else
                    {
                        blcd.InnerText = this._salesHistoryAcs.SalesHistoryDt.Rows[i]["AdministrationNo"].ToString();
                    }
                    data.AppendChild(blcd);

                    // 出荷数
                    sksu = xmldoc.CreateElement("SKSU");
                    sksu.InnerText = this._salesHistoryAcs.SalesHistoryDt.Rows[i]["ShipmentCnt"].ToString();
                    data.AppendChild(sksu);

                    // 仕入先コード
                    psicd = xmldoc.CreateElement("PSICD");
                    psicd.InnerText = this._salesHistoryAcs.SalesHistoryDt.Rows[i]["SupplierCd"].ToString();
                    data.AppendChild(psicd);

                    root.AppendChild(data);
                }

                //XML書き込み
                xmlFileName = this.GetXmlFileName();                
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
        // ----- ADD zhuhh 2013/03/06 for Redmine#35011-----<<<<<
        #endregion

        #region ◎ ファイルの削除処理
        /// <summary>
        /// ファイルの削除処理
        /// </summary>
        /// <returns>チェック結果</returns>
        /// <remarks>
        /// <br>Note       : ファイルを削除します。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009.08.13</br>
        /// </remarks>
        private int DeleteFile()
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            ArrayList fileList = new ArrayList();

            try
            {
                // ファイルを削除
                FileInfo info = new FileInfo(this.tEdit_FileName.DataText);
                info.Delete();
            }
            catch
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
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
        /// <br>Programmer	: 張凱</br>
        /// <br>Date		: 2009.08.13</br>
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
        /// <br>Programmer	: 張凱</br>
        /// <br>Date		: 2009.08.13</br>
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

        // ----- ADD zhuhh 2013/03/06 for Redmine#35011 ----->>>>>
        /// <summary>
        /// XMLの削除
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note		: XMLの削除する。</br>
        /// <br>Programmer	: zhuhh</br>
        /// <br>Date		: 2013/03/06</br>										
        /// </remarks>
        private int DeleteXmlFile()
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            string resultMessageDe = string.Empty;
            string xmlFileName = this.GetXmlFileName();
            string xmlRecvName = this.GetXmlRecFileName();
            try
            {
                // ファイルを削除
                FileInfo info = new FileInfo(xmlFileName);
                info.Delete();

                info = new FileInfo(xmlRecvName);
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
        /// <remarks>
        /// <br>Note		: 送信ファイル名を取る</br>
        /// <br>Programmer	: zhuhh</br>
        /// <br>Date		: 2013/03/06</br>										
        /// </remarks>
        private String GetXmlFileName() 
        {
            string xmlFileName = tEdit_FileName.Text.Trim();
            if (!String.IsNullOrEmpty(xmlFileName))
            {
                if (xmlFileName.Contains("."))
                {
                    int index = xmlFileName.LastIndexOf(".");
                    xmlFileName = xmlFileName.Substring(0, index) + ".XML";
                }
                else
                {
                    xmlFileName = xmlFileName + ".XML";
                }
            }
            else 
            {
                xmlFileName = "R:\\SFNETASM\\PRTOUT\\URI.XML";
            }
            return xmlFileName;
        }

        /// <summary>
        /// 受信ファイル名を取る
        /// </summary>
        /// <remarks>
        /// <br>Note		: 受信ファイル名を取る</br>
        /// <br>Programmer	: zhuhh</br>
        /// <br>Date		: 2013/03/06</br>										
        /// </remarks>
        private String GetXmlRecFileName()
        {
            string xmlFileName = tEdit_FileName.Text.Trim();
            if (!String.IsNullOrEmpty(xmlFileName))
            {
                if (xmlFileName.Contains("."))
                {
                    int index = xmlFileName.LastIndexOf(".");
                    xmlFileName = xmlFileName.Substring(0, index) + "RECV.XML";
                }
                else
                {
                    xmlFileName = xmlFileName + "RECV.XML";
                }
            }
            else
            {
                xmlFileName = "R:\\SFNETASM\\PRTOUT\\URIRECV.XML";
            }
            return xmlFileName;
        }
        // ----- ADD zhuhh 2013/03/06 for Redmine#35011 -----<<<<<

        #endregion ■ Private Method

        # region Control Events

        /// <summary>
        /// PMSAE02010UA_Load Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: ユーザーがﾌｫｰﾑを読み込むときに発生する</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009.08.13</br>
        /// </remarks>
        private void PMSAE02010UA_Load(object sender, EventArgs e)
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
            this.SetIconImage(this.ultraButton_FileName, Size16_Index.STAR1);
            this.SetIconImage(this.ub_CustomerCode_St, Size16_Index.STAR1);
            this.SetIconImage(this.ub_CustomerCode_Ed, Size16_Index.STAR1);

            // 画面イメージ統一
            // 画面スキンファイルの読込(デフォルトスキン指定)
            this._controlScreenSkin.LoadSkin();

            // 画面スキン変更
            this._controlScreenSkin.SettingScreenSkin(this);

            // ツールバー設定イベント
            ParentToolbarSettingEvent(this);
        }
        # endregion

        /// <summary>
        /// Button_Click イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : 入力ファイル名ボタンをクリックした時に発生します。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009.08.13</br>
        /// </remarks>
        private void ultraButton_FileName_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    // タイトルバーの文字列
                    openFileDialog.Title = "出力ファイル選択";
                    openFileDialog.RestoreDirectory = true;
                    if (this.tEdit_FileName.Text.Trim() == string.Empty)
                    {
                        openFileDialog.InitialDirectory = ConstantManagement_ClientDirectory.PRTOUT;

                    }
                    else
                    {
                        openFileDialog.FileName = System.IO.Path.GetFileName(this.tEdit_FileName.Text);
                        openFileDialog.InitialDirectory = System.IO.Path.GetDirectoryName(this.tEdit_FileName.Text);
                    }

                    //「ファイルの種類」を指定
                    openFileDialog.Filter = "すべてのファイル (*.*)|*.*";

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        this.tEdit_FileName.Text = openFileDialog.FileName;
                    }
                }

            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// 得意先(開始)ガイドクリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <br>Programmer  : 張凱</br>
        /// <br>Date        : 2009.08.13</br>
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
                nextControl = this.tNedit_CustomerCode_Ed;
                // フォーカス
                nextControl.Focus();
            }
        }

        /// <summary>
        /// 得意先(開始)選択時発生イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="customerSearchRet">得意先車両検索戻り値クラス</param>
        /// <remarks>
        /// <br>Note　　　  : 得意先コード(開始)ガイドクリック時に発生イベント</br>
        /// <br>Programmer  : 張凱</br>
        /// <br>Date        : 2009.08.13</br>
        /// </remarks>
        private void CustomerSearchForm_StCustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        {
            if (customerSearchRet == null) return;
            this.tNedit_CustomerCode_St.SetInt(customerSearchRet.CustomerCode);
            _customerGuid = true;
        }

        /// <summary>
        /// 得意先コード(終了)ガイド起動ボタン起動イベント
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note　　　  : 得意先コード(終了)ガイドクリック時に発生します</br>
        /// <br>Programmer  : 張凱</br>
        /// <br>Date        : 2009.08.13</br>
        /// </remarks>
        private void ub_CustomerCode_Ed_Click(object sender, EventArgs e)
        {
            _customerGuid = false;
            // フォーカス制御用、ガイド呼出前の得意先コード
            PMKHN04005UA customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_CUSTOMER_ONLY, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY);
            customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.CustomerSearchForm_EdCustomerSelect);
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
        /// 得意先コード(終了)選択時発生イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="customerSearchRet">得意先車両検索戻り値クラス</param>
        /// <remarks>
        /// <br>Note　　　  : 得意先コード(開始)ガイドクリック時に発生イベント</br>
        /// <br>Programmer  : 張凱</br>
        /// <br>Date        : 2009.08.13</br>
        /// </remarks>
        private void CustomerSearchForm_EdCustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        {
            if (customerSearchRet == null) return;
            this.tNedit_CustomerCode_Ed.SetInt(customerSearchRet.CustomerCode);
            _customerGuid = true;
        }

        /// <summary>
        /// エクスプローラーバー グループ縮小 イベント
        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント情報</param>
        /// <remarks>
        /// <br>Note       : グループが縮小される前に発生します。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009.08.13</br>
        /// </remarks>
        private void ueb_MainExplorerBar_GroupCollapsing(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
        {
            if ((e.Group.Key == "ReportSelectGroup") ||
                (e.Group.Key == "FileTypeGroup") ||
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
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009.08.13</br>
        /// </remarks>
        private void ueb_MainExplorerBar_GroupExpanding(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
        {
            if ((e.Group.Key == "ReportSelectGroup") ||
                (e.Group.Key == "FileTypeGroup") ||
                (e.Group.Key == "PrintConditionGroup"))
            {
                // グループの縮小をキャンセル
                e.Cancel = true;
            }
        }
    }
}
