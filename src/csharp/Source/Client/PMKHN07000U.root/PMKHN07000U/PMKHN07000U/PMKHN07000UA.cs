//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 葉書・封筒・ＤＭテキスト出力
// プログラム概要   : 葉書・封筒・ＤＭテキスト出力を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 朱宝軍
// 作 成 日  2009/04/01  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日               修正内容 : 
//----------------------------------------------------------------------------//
// 管理番号  10704766-00 作成担当 : zhouyu   連番 967､975
// 修 正 日  2011/07/21  修正内容 : 締日・対象日付(開始/終了)を入力
//----------------------------------------------------------------------------//
// 管理番号  10704766-00 作成担当 : zhouyu   redmine #23381 FOR 8月納品
// 修 正 日  2011/08/03  修正内容 : 使用マスタ：得意先、出力区分：全てに変更の後、
//                                : エンターを押した後で抽出条件に進む
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Net.NetworkInformation;
using System.Text.RegularExpressions;

using Broadleaf.Application.Controller;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Text;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Windows.Forms;
using Broadleaf.Application.Resources;
using Infragistics.Win.Misc;
using Infragistics.Win.UltraWinEditors;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 葉書・封筒・ＤＭテキスト出力フォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 葉書・封筒・ＤＭテキスト出力フォームクラスのインスタンスの作成を行う。</br>
    /// <br>Programmer : 朱宝軍</br>
    /// <br>Date       : 2009.04.01</br>
    /// </remarks>
    public partial class PMKHN07000UA : Form,
                                IPrintConditionInpType,					// 帳票共通（条件入力タイプ）
                                IPrintConditionInpTypeSelectedSection,	// 帳票業務（条件入力）拠点選択
                                IPrintConditionInpTypeTextOutPut        // CSV出力
    {
        #region ■ Constructor
        /// <summary>
        /// クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : クラスの初期化およびインスタンスの生成を行う</br>
        /// <br>Programmer	: 朱宝軍</br>
        /// <br>Date		: 2009.04.01</br>
        /// <br></br>
        /// </remarks>
        public PMKHN07000UA()
        {
            InitializeComponent();
            // 企業コード取得
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            // 仕入先ガイド
            this._supplierAcs = new SupplierAcs();
            // 取得DATA
            this._dateGet = DateGetAcs.GetInstance();
            this._stockSlipInputInitDataAcs = StockSlipInputInitDataAcs.GetInstance();
            this._postEnvelDMInstsMainAcs = PostEnvelDMInstsMainAcs.GetInstance();
        }
        #endregion

        #region  ■ Private member

        #region ■ Interface member

        //--IPrintConditionInpTypeSelectedSectionのプロパティ用変数 -------------------
        // 計上拠点選択表示取得プロパティ
        private bool _visibledSelectAddUpCd = false;
        // 拠点オプション有無
        private bool _isOptSection = false;
        // 本社機能有無
        private bool _isMainOfficeFunc = false;

        //--IPrintConditionInpTypeのプロパティ用変数 ----------------------------------
        // 抽出ボタン状態取得プロパティ
        private bool _canExtract = true;
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

        // --IPrintConditionInpTypeTextOutPutのプロパティ用変数 -------------------
        // テキスト出力表示有無プロパティ
        private bool _canTextOutPut = true;

        #endregion ◆ Interface member

        //日付取得部品
        private DateGetAcs _dateGet;

        // 仕入先ガイドアクセスクラス
        private StockSlipInputInitDataAcs _stockSlipInputInitDataAcs;

        // 葉書・封筒・ＤＭテキスト出力アクセスクラス
        private PostEnvelDMInstsMainAcs _postEnvelDMInstsMainAcs;

        // 企業コード
        private string _enterpriseCode;

        // SFCMN00391Uのテキスト出力モード
        private int _outPutMode;

        // ガイド系アクセスクラス
        private SupplierAcs _supplierAcs;

        // 得意先ガイドFLAG
        private bool _customerGuid;

        //ADD START ZHOUYU 2011/07/21 連番 967､975
        private bool useMast = false;
        private bool outPutCD = false;
        //ADD END ZHOUYU 2011/07/21 連番 967､975

        #endregion

        #region  ■ Private cost
        //エラー条件メッセージ
        private const string ct_INPUTERROR = "が不正です。";
        private const string ct_NOINPUT = "を入力してください。";
        private const string ct_RANGEERROR = "の範囲に誤りがあります。";
        // クラスID
        private const string ct_CLASSID = "PMKHN07000UA";
        // クラス名
        private string ct_PRINTNAME = "葉書・封筒・ＤＭテキスト出力";
        // プログラムID
        private const string ct_PGID = "PMKHN07000U";
        // ExporerBar グループ名称
        private const string ct_EXBARGROUPNM_REPORTSELECTGROUP = "ReportSelectGroup";
        private const string ct_EXBARGROUPNM_PRINTCONDITIONGROUP = "PrintConditionGroup";
        private const string ct_EXBARGROUPNM_PRINTODERGROUP = "PrintOderGroup";

        #endregion

        #region ■IPrintConditionInpTypeTextOutPut メンバ

        #region ◆ Public Property
        /// public propaty name  :  CanTextOutPut
        /// <summary>テキスト出力プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>Note             :   テキスト出力プロパティを行います。</br>
        /// <br>Programer        :   朱宝軍</br>
        /// </remarks>
        public bool CanTextOutPut
        {
            get { return this._canTextOutPut; }
        }
        #endregion ◆ Public Method

        #region ◆ Public Method

        #region ◎ 印刷処理
        /// <summary>
        /// 印刷処理
        /// </summary>
        /// <param name="parameter">パラメータ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note		: 印刷処理を行う。</br>
        /// <br>Programmer	: 朱宝軍</br>
        /// <br>Date		: 2009.03.26</br>
        /// </remarks>
        public int OutPutText(ref object parameter)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            // オフライン状態チェック	
            if (!CheckOnline())
            {
                TMsgDisp.Show(
                    emErrorLevel.ERR_LEVEL_STOP,
                    this.Text,
                    "葉書・封筒・ＤＭテキスト出力" + "データ読み込みに失敗しました。",
                    (int)ConstantManagement.DB_Status.ctDB_OFFLINE, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                return status;
            }
            // 抽出条件クラス
            PostcardEnvelopeDMTextCndtn condtionWork = new PostcardEnvelopeDMTextCndtn();
            // 画面→抽出条件クラス
            SetCondtionWork(ref condtionWork);
            // 検索結果List
            ArrayList retList;
            SFCMN00299CA form = new Broadleaf.Windows.Forms.SFCMN00299CA();
            // 表示文字を設定
            form.Title = "抽出中";
            form.Message = "現在、データを抽出中です。";
            try
            {
                // ダイアログ表示
                form.Show();
                this.Cursor = Cursors.WaitCursor;
                // 検索
                status = _postEnvelDMInstsMainAcs.Search(condtionWork, out retList);
                this.Cursor = Cursors.Default;
            }
            finally
            {
                // ダイアログを閉じる
                form.Close();
            }
            if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                status = 0;
            }
            else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "検索条件に該当するデータは存在しません。", 0);
                return status;
            }
            else
            {
                TMsgDisp.Show(						    // 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOP, 		// エラーレベル
                            "PMKHN07000U", 						// アセンブリＩＤまたはクラスＩＤ
                            ct_PRINTNAME, 			// プログラム名称
                            "Extract", 							// 処理名称
                            TMsgDisp.OPE_GET, 					// オペレーション
                            "読み込みに失敗しました。", 		// 表示するメッセージ
                            status, 							// ステータス値
                            this._postEnvelDMInstsMainAcs, 				// エラーが発生したオブジェクト
                            MessageBoxButtons.OK, 				// 表示するボタン
                            MessageBoxDefaultButton.Button1);	// 初期表示ボタン
                return status;
            }

            // テキスト出力用ダイアログに必要な情報をセットする
            SFCMN06002C printInfo;
            status = this.GetPrintInfo(out printInfo);
            if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                return -1;
            }
            CustomTextProviderInfo customTextProviderInfo = CustomTextProviderInfo.GetDefaultInfo();
            CustomTextWriter customTextWriter = new CustomTextWriter();
            customTextProviderInfo.OutPutFileName = printInfo.outPutFilePathName;
            // 上書き／追加フラグをセット(true:追加する、false:上書きする)
            customTextProviderInfo.AppendMode = printInfo.overWriteFlag;
            // スキーマ取得
            customTextProviderInfo.SchemaFileName = System.IO.Path.Combine(ConstantManagement_ClientDirectory.TextOutSchema, printInfo.prpid);
            DataSet dsOutData = new DataSet();
            dsOutData = _postEnvelDMInstsMainAcs.UseMastDs;
            // CSV出力
            status = customTextWriter.WriteText(dsOutData, customTextProviderInfo.SchemaFileName, customTextProviderInfo.OutPutFileName, customTextProviderInfo);
            dsOutData.Tables.Clear();
            string resultMessage = "";
            switch (status)
            {
                case 0:    // 処理成功
                    resultMessage = "CSV出力が完了しました。";
                    break;
                case -9:    // 出力対象外のデータが指定された
                    resultMessage = "出力対象外のデータが指定されました。";
                    break;
                default:    // その他エラー
                    resultMessage = "その他のエラーが発生しました。ステータス(" + status.ToString() + ")";
                    break;
            }

            if (!string.IsNullOrEmpty(resultMessage))
            {
                MsgDispProc(emErrorLevel.ERR_LEVEL_INFO
                            , resultMessage
                            , status
                            , MessageBoxButtons.OK
                            , MessageBoxDefaultButton.Button1);
            }

            return status;
        }
        #endregion

        #endregion ◆ Public Method

        #endregion ■IPrintConditionInpTypeTextOutPut メンバ

        #region ■ IPrintConditionInpType メンバ

        #region ◆ Public Event
        /// <summary> 親ツールバー設定イベント </summary>
        public event ParentToolbarSettingEventHandler ParentToolbarSettingEvent;
        #endregion ◆ Public Event

        #region ◆ Public Property
        /// public propaty name  :  CanExtract
        /// <summary>抽出ボタン状態取得プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>Note             :   抽出ボタン状態取得プロパティを行います。</br>
        /// <br>Programer        :   朱宝軍</br>
        /// </remarks>
        public bool CanExtract
        {
            get { return this._canExtract; }
        }

        /// public propaty name  :  CanPdf
        /// <summary>PDF出力ボタン状態取得プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>Note             :   PDF出力ボタン状態取得プロパティを行います。</br>
        /// <br>Programer        :   朱宝軍</br>
        /// </remarks>
        public bool CanPdf
        {
            get { return this._canPdf; }
        }

        /// public propaty name  :  CanPrint
        /// <summary>印刷ボタン状態取得プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>Note             :   印刷ボタン状態取得プロパティを行います。</br>
        /// <br>Programer        :   朱宝軍</br>
        /// </remarks>
        public bool CanPrint
        {
            get { return this._canPrint; }
        }

        /// public propaty name  :  VisibledExtractButton
        /// <summary>抽出ボタン表示有無取得プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>Note             :   抽出ボタン表示有無取得プロパティを行います。</br>
        /// <br>Programer        :   朱宝軍</br>
        /// </remarks>
        public bool VisibledExtractButton
        {
            get { return this._visibledExtractButton; }
        }

        /// public propaty name  :  VisibledPdfButton
        /// <summary>PDF出力ボタン表示有無プロパティ取得プロパティ </summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>Note             :   PDF出力ボタン表示有無プロパティ取得プロパティ を行います。</br>
        /// <br>Programer        :   朱宝軍</br>
        /// </remarks>
        public bool VisibledPdfButton
        {
            get { return this._visibledPdfButton; }
        }

        /// public propaty name  :  VisibledPrintButton
        /// <summary>印刷ボタン表示取得プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>Note             :   印刷ボタン表示取得プロパティを行います。</br>
        /// <br>Programer        :   朱宝軍</br>
        /// </remarks>
        public bool VisibledPrintButton
        {
            get { return this._visibledPrintButton; }
        }
        #endregion ◆ Public Property

        #region ◆ Public Method
        #region ◎ 画面表示処理
        /// <summary>
        /// 画面表示処理
        /// </summary>
        /// <param name="parameter">起動パラメータ</param>
        /// <remarks>
        /// <br>Note		: 画面表示を行う。</br>
        /// <br>Programmer	: 朱宝軍</br>
        /// <br>Date		: 2009.04.01</br>
        /// </remarks>
        public void Show(object parameter)
        {
            this.Show();
            InitMenuButton();
            return;
        }

        /// <summary>
        /// 画面表示モードボタン制御処理
        /// </summary>
        /// <remarks>
        /// <br>Note		: 画面表示モードボタン制御処理を行う。</br>
        /// <br>Programmer	: 朱宝軍</br>
        /// <br>Date		: 2009.04.01</br>
        /// </remarks>
        private void InitMenuButton()
        {
            // CSV
            // 抽出ボタン状態取得プロパティ
            _canExtract = true;
            // PDF出力ボタン状態取得プロパティ  
            _canPdf = false;
            // 印刷ボタン状態取得プロパティ
            _canPrint = false;
            // 抽出ボタン表示有無プロパティ
            _visibledExtractButton = false;
            // PDF出力ボタン表示有無プロパティ	
            _visibledPdfButton = false;
            // 印刷ボタン表示有無プロパティ
            _visibledPrintButton = false;
            //--IPrintConditionInpTypeTextOutPutのプロパティ
            _canTextOutPut = true;

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
        /// <br>Programmer	: 朱宝軍</br>
        /// <br>Date		: 2009.04.01</br>
        /// </remarks>
        public int Extract(ref object parameter)
        {
            return 0;
        }
        #endregion

        #region ◎ 印刷処理
        /// <summary>
        /// 印刷処理
        /// </summary>
        /// <param name="parameter">パラメータ</param>
        /// <returns>0( 固定 )</returns>
        /// <remarks>
        /// <br>Note		: 印刷処理を行う。</br>
        /// <br>Programmer	: 朱宝軍</br>
        /// <br>Date		: 2009.04.01</br>
        /// </remarks>
        public int Print(ref object parameter)
        {
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
        /// <br>Programmer	: 朱宝軍</br>
        /// <br>Date		: 2009.04.01</br>
        /// </remarks>
        public bool PrintBeforeCheck()
        {
            string errMessage = "";
            Control errComponent = null;
            if (ScreenInputCheck(ref errMessage, ref errComponent))
            {
                return true;
            }
            else
            {
                // メッセージを表示
                this.MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, errMessage, 0);

                // コントロールにフォーカスをセット
                if (errComponent != null)
                {
                    errComponent.Focus();
                }

                return false;
            }

        }

        #endregion

        #endregion ◆ Public Method

        #endregion ■ IPrintConditionInpType メンバ

        #region ■ IPrintConditionInpTypeSelectedSection メンバ

        #region ◆ Public Property

        /// public propaty name  :  IsMainOfficeFunc
        /// <summary>本社機能プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>Note             :   本社機能プロパティを行います。</br>
        /// <br>Programer        :   朱宝軍</br>
        /// </remarks>
        public bool IsMainOfficeFunc
        {
            get { return _isMainOfficeFunc; }
            set { _isMainOfficeFunc = value; }
        }

        /// public propaty name  :  IsOptSection
        /// <summary>拠点オプションプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>Note             :   拠点オプションプロパティを行います。</br>
        /// <br>Programer        :   朱宝軍</br>
        /// </remarks>
        public bool IsOptSection
        {
            get { return _isOptSection; }
            set { _isOptSection = value; }
        }

        /// public propaty name  :  VisibledSelectAddUpCd
        /// <summary>計上拠点選択表示取得プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>Note             :   計上拠点選択表示取得プロパティを行います。</br>
        /// <br>Programer        :   朱宝軍</br>
        /// </remarks>
        public bool VisibledSelectAddUpCd
        {
            get { return _visibledSelectAddUpCd; }
        }

        #endregion ◆ Public Property

        #region ◆ Public Method
        #region ◎ 拠点選択処理( 未実装 )
        /// <summary>
        /// 拠点選択処理
        /// </summary>
        /// <param name="sectionCode">選択拠点コード</param>
        /// <param name="checkState">選択状態</param>
        /// <remarks>
        /// <br>Note		: 拠点選択処理を行う。</br>
        /// <br>Programmer	: 朱宝軍</br>
        /// <br>Date		: 2009.04.01</br>
        /// </remarks>
        public void CheckedSection(string sectionCode, CheckState checkState)
        {
            // 拠点選択がないので未実装
        }
        #endregion

        #region ◎ 初期選択計上拠点設定処理( 未実装 )
        /// <summary>
        /// 初期選択計上拠点設定処理( 未実装 )
        /// </summary>
        /// <param name="addUpCd"></param>
        /// <remarks>
        /// <br>Note		: 未実装</br>
        /// <br>Programmer	: 朱宝軍</br>
        /// <br>Date		: 2009.04.01</br>
        /// </remarks>
        public void InitSelectAddUpCd(int addUpCd)
        {
            // 計上拠点選択がないので未実装
        }
        #endregion

        #region ◎ 初期選択拠点設定処理( 未実装 )
        /// <summary>
        /// 初期選択拠点設定処理
        /// </summary>
        /// <param name="sectionCodeLst">選択拠点コードリスト</param>
        /// <remarks>
        /// <br>Note		: 拠点リストの初期化を行う。</br>
        /// <br>Programmer	: 朱宝軍</br>
        /// <br>Date		: 2009.04.01</br>
        /// </remarks>
        public void InitSelectSection(string[] sectionCodeLst)
        {
            // 拠点選択がないので未実装
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
        /// <br>Programmer	: 朱宝軍</br>
        /// <br>Date		: 2009.04.01</br>
        /// </remarks>
        public bool InitVisibleCheckSection(bool isDefaultState)
        {
            return false;
        }
        #endregion

        #region ◎ 計上拠点選択処理( 未実装 )
        /// <summary>
        /// 計上拠点選択処理( 未実装 )
        /// </summary>
        /// <param name="addUpCd"></param>
        /// <remarks>
        /// <br>Note		: 未実装</br>
        /// <br>Programmer	: 朱宝軍</br>
        /// <br>Date		: 2009.04.01</br>
        /// </remarks>
        public void SelectedAddUpCd(int addUpCd)
        {
            // 計上拠点選択がないので未実装
        }
        #endregion
        #endregion ◆ Public Method

        #endregion ■ IPrintConditionInpTypeSelectedSection メンバ

        #region ■ Private Event

        #region ◆ ChangeFocus
        /// <summary>
        /// 矢印キーでのフォーカス移動イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note　　　  : 矢印キーでのフォーカス移動時に発生します</br>                 
        /// <br>Programmer  : 朱宝軍</br>                                   
        /// <br>Date        : 2009.04.01</br>                                       
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (!e.ShiftKey)
            {
                // SHIFTキー未押下
                if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                {
                    if (e.PrevCtrl == this.Mast_tComboEditor)
                    {
                        switch (this.Mast_tComboEditor.SelectedIndex)
                        {
                            case (0):
                                {
                                    // 使用マスタ→出力区分
                                    e.NextCtrl = this.OutputDiv_tComboEditor;
                                }
                                break;
                            case (1):
                                {
                                    // 使用マスタ→拠点(開始)
                                    e.NextCtrl = this.tEdit_SectionCode_St;
                                }
                                break;
                            case (3):
                                {
                                    // 使用マスタ→拠点(開始)
                                    e.NextCtrl = this.tEdit_SectionCode_St;
                                }
                                break;
                        }
                    }
                    else if (e.PrevCtrl == this.OutputDiv_tComboEditor)
                    {
                        switch (this.OutputDiv_tComboEditor.SelectedIndex)
                        {
                            case (0):
                                {
                                    /*DEL START 2011/08/03 redmine #23381 FOR 8月納品----------------
                                    // 出力区分→締日
                                    e.NextCtrl = this.tDateEdit_TotalDay;
                                    ----------------DEL END 2011/08/03 redmine #23381 FOR 8月納品*/
                                    //ADD START 2011/08/03 redmine #23381 FOR 8月納品
                                    //出力区分→拠点
                                    e.NextCtrl = this.tEdit_SectionCode_St;
                                    //ADD END 2011/08/03 redmine #23381 FOR 8月納品
                                }
                                break;
                            case (1):
                                {
                                    // 出力区分→締日
                                    e.NextCtrl = this.tDateEdit_TotalDay;
                                }
                                break;
                            case (2):
                                {
                                    // 出力区分→対象日付(開始)
                                    e.NextCtrl = this.tDateEdit_St_AddUpDay;
                                }
                                break;
                        }
                    }
                    else if (e.PrevCtrl == this.tDateEdit_TotalDay)
                    {
                        switch (this.OutputDiv_tComboEditor.SelectedIndex)
                        {
                            case (0):
                                {

                                    // 締日→対象日付(開始)
                                    e.NextCtrl = this.tDateEdit_St_AddUpDay;
                                }
                                break;
                            case (1):
                                {
                                    // 締日→拠点(開始)
                                    e.NextCtrl = this.tEdit_SectionCode_St;
                                }
                                break;
                        }
                    }
                    else if (e.PrevCtrl == this.tDateEdit_St_AddUpDay)
                    {
                        // 対象日付(開始)→対象日付(終了)
                        e.NextCtrl = this.tDateEdit_Ed_AddUpDay;
                    }
                    else if (e.PrevCtrl == this.tDateEdit_Ed_AddUpDay)
                    {
                        // 対象日付(終了)→拠点(開始)
                        e.NextCtrl = this.tEdit_SectionCode_St;
                    }
                    else if (e.PrevCtrl == this.tEdit_SectionCode_St)
                    {
                        // 拠点(開始)→拠点(終了)
                        e.NextCtrl = this.tEdit_SectionCode_Ed;
                    }
                    else if (e.PrevCtrl == this.tEdit_SectionCode_Ed)
                    {
                        if (this.Mast_tComboEditor.SelectedIndex == 0)
                        {
                            // 拠点(終了)→得意先(開始)
                            e.NextCtrl = this.tNedit_CustomerCode_St;
                        }
                        else if (this.Mast_tComboEditor.SelectedIndex == 1)
                        {
                            // 拠点(終了)→仕入先(開始)
                            e.NextCtrl = this.tNedit_SupplierCd_St;
                        }
                        else if (this.Mast_tComboEditor.SelectedIndex == 3)
                        {
                            // 拠点(終了)→使用マスタ
                            e.NextCtrl = this.Mast_tComboEditor;
                        }

                    }
                    else if (e.PrevCtrl == this.tNedit_CustomerCode_St)
                    {
                        // 得意先(開始)→得意先(終了)
                        e.NextCtrl = this.tNedit_CustomerCode_Ed;
                    }
                    else if (e.PrevCtrl == this.tNedit_CustomerCode_Ed)
                    {
                        // 得意先(終了)→使用マスタ
                        e.NextCtrl = this.Mast_tComboEditor;
                    }
                    else if (e.PrevCtrl == this.tNedit_SupplierCd_St)
                    {
                        // 仕入先(開始)→仕入先(終了)
                        e.NextCtrl = this.tNedit_SupplierCd_Ed;
                    }
                    else if (e.PrevCtrl == this.tNedit_SupplierCd_Ed)
                    {
                        // 仕入先(終了)→使用マスタ
                        e.NextCtrl = this.Mast_tComboEditor;
                    }
                }
            }
            else
            {
                // SHIFTキー押下
                if (e.Key == Keys.Tab)
                {
                    if (e.PrevCtrl == this.Mast_tComboEditor)
                    {
                        switch (this.Mast_tComboEditor.SelectedIndex)
                        {
                            case (0):
                                {
                                    // 使用マスタ→得意先(終了)
                                    e.NextCtrl = this.tNedit_CustomerCode_Ed;
                                }
                                break;
                            case (1):
                                {
                                    // 使用マスタ→仕入先(終了)
                                    e.NextCtrl = this.tNedit_SupplierCd_Ed;
                                }
                                break;
                            case (3):
                                {
                                    // 使用マスタ→拠点(終了)
                                    e.NextCtrl = this.tEdit_SectionCode_Ed;
                                }
                                break;
                        }
                    }
                    else if (e.PrevCtrl == this.OutputDiv_tComboEditor)
                    {
                        // 出力区分→使用マスタ
                        e.NextCtrl = this.Mast_tComboEditor;
                    }
                    else if (e.PrevCtrl == this.tDateEdit_TotalDay)
                    {
                        // 締日→出力区分
                        e.NextCtrl = this.OutputDiv_tComboEditor;
                    }
                    else if (e.PrevCtrl == this.tDateEdit_St_AddUpDay)
                    {
                        switch (this.OutputDiv_tComboEditor.SelectedIndex)
                        {
                            case (0):
                                {
                                    // 対象日付(開始)→締日
                                    e.NextCtrl = this.tDateEdit_TotalDay;
                                }
                                break;
                            case (1):
                                {
                                    // 対象日付(開始)→出力区分
                                    e.NextCtrl = this.OutputDiv_tComboEditor;
                                }
                                break;
                            case (2):
                                {
                                    // 対象日付(開始)→出力区分
                                    e.NextCtrl = this.OutputDiv_tComboEditor;
                                }
                                break;
                        }
                    }
                    else if (e.PrevCtrl == this.tDateEdit_Ed_AddUpDay)
                    {
                        // 対象日付(終了)→対象日付(開始)
                        e.NextCtrl = this.tDateEdit_St_AddUpDay;
                    }
                    else if (e.PrevCtrl == this.tEdit_SectionCode_St)
                    {
                        if (this.Mast_tComboEditor.SelectedIndex == 0)
                        {
                            switch (this.OutputDiv_tComboEditor.SelectedIndex)
                            {
                                case (0):
                                    {
                                       /*DEL START 2011/08/03 redmine #23381 FOR 8月納品----------------
                                       // 拠点(開始)→対象日付(終了)
                                       e.NextCtrl = this.tDateEdit_Ed_AddUpDay;
                                       ----------------DEL END 2011/08/03 redmine #23381 FOR 8月納品*/
                                        //ADD START 2011/08/03 redmine #23381 FOR 8月納品
                                        //拠点→出力区分
                                        e.NextCtrl = this.OutputDiv_tComboEditor;
                                        //ADD END 2011/08/03 redmine #23381 FOR 8月納品
                                    }
                                    break;
                                case (1):
                                    {
                                        // 拠点(開始)→締日
                                        e.NextCtrl = this.tDateEdit_TotalDay;
                                    }
                                    break;
                                case (2):
                                    {
                                        // 拠点(開始)→対象日付(終了)
                                        e.NextCtrl = this.tDateEdit_Ed_AddUpDay;
                                    }
                                    break;
                            }
                        }
                        else
                        {
                            // 拠点(開始)→使用マスタ
                            e.NextCtrl = this.Mast_tComboEditor;
                        }

                    }
                    else if (e.PrevCtrl == this.tEdit_SectionCode_Ed)
                    {
                        // 拠点(終了)→拠点(開始)
                        e.NextCtrl = this.tEdit_SectionCode_St;
                    }
                    else if (e.PrevCtrl == this.tNedit_CustomerCode_St)
                    {
                        // 得意先(開始)→拠点(終了)
                        e.NextCtrl = this.tEdit_SectionCode_Ed;
                    }
                    else if (e.PrevCtrl == this.tNedit_CustomerCode_Ed)
                    {
                        // 得意先(終了)→得意先(開始)
                        e.NextCtrl = this.tNedit_CustomerCode_St;
                    }
                    else if (e.PrevCtrl == this.tNedit_SupplierCd_St)
                    {
                        // 仕入先(開始)→拠点(終了)
                        e.NextCtrl = this.tEdit_SectionCode_Ed;
                    }
                    else if (e.PrevCtrl == this.tNedit_SupplierCd_Ed)
                    {
                        // 仕入先(終了)→仕入先(開始)
                        e.NextCtrl = this.tNedit_SupplierCd_St;
                    }
                }
            }
            // Coopyチェック
            WordCoopyCheck();
        }
        #endregion


        #region ◆ ガイド検索
        /// <summary>
        /// 得意先コード(開始)ガイド起動ボタン起動イベント                                               
        /// </summary>
        /// <param name="sender">イベントソース</param>                              
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note　　　  : 得意先コード(開始)ガイドクリック時に発生します</br>                  
        /// <br>Programmer  : 朱宝軍</br>                                    
        /// <br>Date        : 2009.04.01</br>                                        
        /// </remarks>
        private void ultraButton_St_CustomerCode_Click(object sender, EventArgs e)
        {
            _customerGuid = false;
            // フォーカス制御用、ガイド呼出前の得意先コード
            int beCustCd = this.tNedit_CustomerCode_St.GetInt();
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
        /// <br>Programmer  : 朱宝軍</br>                                    
        /// <br>Date        : 2009.04.01</br>                                        
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
        /// <br>Programmer  : 朱宝軍</br>                                    
        /// <br>Date        : 2009.04.01</br>                                        
        /// </remarks>
        private void ultraButton_Ed_CustomerCode_Click(object sender, EventArgs e)
        {
            _customerGuid = false;
            // フォーカス制御用、ガイド呼出前の得意先コード
            int beCustCd = this.tNedit_CustomerCode_Ed.GetInt();
            PMKHN04005UA customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_CUSTOMER_ONLY, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY);
            customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.CustomerSearchForm_EdCustomerSelect);
            customerSearchForm.ShowDialog(this);
            if (_customerGuid)
            {
                Control nextControl = null;
                nextControl = this.Mast_tComboEditor;
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
        /// <br>Programmer  : 朱宝軍</br>                                    
        /// <br>Date        : 2009.04.01</br>                                        
        /// </remarks>
        private void CustomerSearchForm_EdCustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        {
            if (customerSearchRet == null) return;
            this.tNedit_CustomerCode_Ed.SetInt(customerSearchRet.CustomerCode);
            _customerGuid = true;
        }

        /// <summary>
        /// 仕入先コード(開始)ガイド起動ボタン起動イベント                                               
        /// </summary>
        /// <param name="sender">イベントソース</param>                              
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note　　　  : 仕入先コード(開始)ガイドクリック時に発生します</br>                  
        /// <br>Programmer  : 朱宝軍</br>                                    
        /// <br>Date        : 2009.04.01</br>                                        
        /// </remarks>
        private void ultraButton_St_SupplierCode_Click(object sender, EventArgs e)
        {
            Supplier retSupplier;
            if (this._supplierAcs == null)
            {
                this._supplierAcs = new SupplierAcs();
            }
            int status = this._supplierAcs.ExecuteGuid(out retSupplier, this._enterpriseCode, this._stockSlipInputInitDataAcs.OwnSectionCode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this.tNedit_SupplierCd_St.DataText = retSupplier.SupplierCd.ToString();
                Control nextControl = null;
                nextControl = this.tNedit_SupplierCd_Ed;
                // フォーカス
                nextControl.Focus();
            }

        }

        /// <summary>
        /// 仕入先コード(終了)ガイド起動ボタン起動イベント                                               
        /// </summary>
        /// <param name="sender">イベントソース</param>                              
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note　　　  : 仕入先コード(終了)ガイドクリック時に発生します</br>                  
        /// <br>Programmer  : 朱宝軍</br>                                    
        /// <br>Date        : 2009.04.01</br>                                        
        /// </remarks>
        private void ultraButton_Ed_SupplierCode_Click(object sender, EventArgs e)
        {
            Supplier retSupplier;
            if (this._supplierAcs == null)
            {
                this._supplierAcs = new SupplierAcs();
            }
            int status = this._supplierAcs.ExecuteGuid(out retSupplier, this._enterpriseCode, this._stockSlipInputInitDataAcs.OwnSectionCode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                //this.SettingSupplier(false, retSupplier);
                this.tNedit_SupplierCd_Ed.DataText = retSupplier.SupplierCd.ToString();
                Control nextControl = null;
                nextControl = this.Mast_tComboEditor;
                // フォーカス
                nextControl.Focus();
            }

        }

        /// <summary>
        /// 拠点コードガイド起動ボタン起動イベント                                               
        /// </summary>
        /// <param name="sender">イベントソース</param>                              
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note　　　  : 拠点コードガイドクリック時に発生します</br>                  
        /// <br>Programmer  : 朱宝軍</br>                                    
        /// <br>Date        : 2009.04.01</br>                                        
        /// </remarks>
        private void ub_St_SectionCode_Click(object sender, EventArgs e)
        {
            int status = 0;

            SecInfoSet secInfoSet;

            // 拠点ガイド表示
            SecInfoSetAcs secInfoSetAcs = new SecInfoSetAcs();
            status = secInfoSetAcs.ExecuteGuid(this._enterpriseCode, false, out secInfoSet);
            TEdit targetControl = null;
            Control nextControl = null;
            string tag = (string)((UltraButton)sender).Tag;
            if (status == 0)
            {
                
                
                if (((UltraButton)sender).Tag.ToString().CompareTo("1") == 0)
                {
                    targetControl = this.tEdit_SectionCode_St;
                    nextControl = this.tEdit_SectionCode_Ed;
                }
                else if (((UltraButton)sender).Tag.ToString().CompareTo("2") == 0)
                {
                    targetControl = this.tEdit_SectionCode_Ed;
                    // 得意先の場合
                    if (this.Mast_tComboEditor.SelectedIndex == (int)PostcardEnvelopeDMTextCndtn.UseMastDivState.Customer)
                    {
                        nextControl = this.tNedit_CustomerCode_St;
                    }
                    // 仕入先の場合
                    else if (this.Mast_tComboEditor.SelectedIndex == (int)PostcardEnvelopeDMTextCndtn.UseMastDivState.Supplier)
                    {
                        nextControl = this.tNedit_SupplierCd_St;
                    }
                    //  拠点の場合
                    else if (this.Mast_tComboEditor.SelectedIndex == (int)PostcardEnvelopeDMTextCndtn.UseMastDivState.SecInfo)
                    {
                        nextControl = this.Mast_tComboEditor;
                    }
                }
                else
                {
                    return;
                }
                // コード展開
                targetControl.DataText = secInfoSet.SectionCode.Trim();
                // フォーカス
                nextControl.Focus();
            }
            else
            {
                if (((UltraButton)sender).Tag.ToString().CompareTo("1") == 0)
                {
                    nextControl = this.ub_SectionCodeStGuid;
                }
                else if (((UltraButton)sender).Tag.ToString().CompareTo("2") == 0)
                {
                    nextControl = this.ub_SectionCodeEdGuid;
                }
                nextControl.Focus();
            }
            

        }
        #endregion

        #region ◆ 使用マスタ選択
        /// <summary>
        /// 使用マスタComboxを選択する                                             
        /// </summary>
        /// <param name="sender">イベントソース</param>                              
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note　　　  : 使用マスタCombox選択時に発生します</br>                  
        /// <br>Programmer  : 朱宝軍</br>                                   
        /// <br>Date        : 2009.04.01</br>
        /// </remarks>
        private void tComboEditor_MastRF_ValueChanged(object sender, EventArgs e)
        {
            // 設置コンポーネントState
            ToolBackState();
            // 使用マスタ = 得意先マスタ時
            if (this.Mast_tComboEditor.SelectedIndex == (int)PostcardEnvelopeDMTextCndtn.UseMastDivState.Customer)
            {
                this._outPutMode = 0;
                // 仕入先(開始)は操作不可
                this.tNedit_SupplierCd_St.Enabled = false;
                // 仕入先(開始)ガイドは操作不可
                this.tNedit_SupplierCd_Ed.Enabled = false;
                // 仕入先(終了)は操作不可
                this.ub_SupplierCodeStGuid.Enabled = false;
                // 仕入先(終了)ガイドは操作不可
                this.ub_SupplierCodeEdGuid.Enabled = false;

                // その他は操作できる
                this.OutputDiv_tComboEditor.Enabled = true;
                this.OutputDiv_tComboEditor.SelectedIndex = 0;
                /*DEL START ZHOUYU 2011/07/21 連番 967､975----------------
                this.tDateEdit_TotalDay.Enabled = true;
                this.tDateEdit_St_AddUpDay.Enabled = true;
                this.tDateEdit_Ed_AddUpDay.Enabled = true;
                ----------------DEL START ZHOUYU 2011/07/21 連番 967､975*/
                this.tNedit_CustomerCode_St.Enabled = true;
                this.ub_CustomerCodeStGuid.Enabled = true;
                this.tNedit_CustomerCode_Ed.Enabled = true;
                this.ub_CustomerCodeEdGuid.Enabled = true;
                this.tEdit_SectionCode_Ed.Enabled = true;
                this.ub_SectionCodeStGuid.Enabled = true;
                this.tEdit_SectionCode_St.Enabled = true;
                this.ub_SectionCodeEdGuid.Enabled = true;
                //ADD START ZHOUYU 2011/07/21 連番 967､975
                this.useMast = true;
                if (useMast && outPutCD)
                {
                    this.tDateEdit_TotalDay.Clear();
                    this.tDateEdit_St_AddUpDay.Clear();
                    this.tDateEdit_Ed_AddUpDay.Clear();
                    this.tDateEdit_TotalDay.Enabled = false;
                    this.tDateEdit_St_AddUpDay.Enabled = false;
                    this.tDateEdit_Ed_AddUpDay.Enabled = false;
                }
                //ADD END ZHOUYU 2011/07/21 連番 967､975

            }
            // 使用マスタ = 仕入先マスタ時
            else if (this.Mast_tComboEditor.SelectedIndex == (int)PostcardEnvelopeDMTextCndtn.UseMastDivState.Supplier)
            {
                this._outPutMode = 1;
                // 出力区分は操作不可  
                this.OutputDiv_tComboEditor.SelectedIndex = -1;
                this.OutputDiv_tComboEditor.Enabled = false;
                // 締日は操作不可
                this.tDateEdit_TotalDay.Enabled = false;
                // 対象日付(開始)は操作不可
                this.tDateEdit_St_AddUpDay.Enabled = false;
                // 対象日付(終了)は操作不可
                this.tDateEdit_Ed_AddUpDay.Enabled = false;
                // 得意先(開始)は操作不可
                this.tNedit_CustomerCode_St.Enabled = false;
                // 得意先(開始)ガイドは操作不可
                this.ub_CustomerCodeStGuid.Enabled = false;
                // 得意先(終了)は操作不可
                this.tNedit_CustomerCode_Ed.Enabled = false;
                // 得意先(終了)ガイドは操作不可
                this.ub_CustomerCodeEdGuid.Enabled = false;

                // その他は操作できる
                this.tNedit_SupplierCd_St.Enabled = true;
                this.ub_SupplierCodeStGuid.Enabled = true;
                this.tNedit_SupplierCd_Ed.Enabled = true;
                this.ub_SupplierCodeEdGuid.Enabled = true;
                this.tEdit_SectionCode_Ed.Enabled = true;
                this.ub_SectionCodeStGuid.Enabled = true;
                this.tEdit_SectionCode_St.Enabled = true;
                this.ub_SectionCodeEdGuid.Enabled = true;
                //ADD START ZHOUYU 2011/07/21 連番 967､975
                this.useMast = false;
                //ADD END ZHOUYU 2011/07/21 連番 967､975
            }
            // 使用マスタ = 自社マスタ時
            else if (this.Mast_tComboEditor.SelectedIndex == (int)PostcardEnvelopeDMTextCndtn.UseMastDivState.Company)
            {
                this._outPutMode = 2;
                // 全ては操作不可
                this.OutputDiv_tComboEditor.SelectedIndex = -1;
                this.OutputDiv_tComboEditor.Enabled = false;
                this.tDateEdit_TotalDay.Enabled = false;
                this.tDateEdit_St_AddUpDay.Enabled = false;
                this.tDateEdit_Ed_AddUpDay.Enabled = false;
                this.tNedit_SupplierCd_St.Enabled = false;
                this.ub_SupplierCodeStGuid.Enabled = false;
                this.tNedit_SupplierCd_Ed.Enabled = false;
                this.ub_SupplierCodeEdGuid.Enabled = false;
                this.tNedit_CustomerCode_St.Enabled = false;
                this.ub_CustomerCodeStGuid.Enabled = false;
                this.tNedit_CustomerCode_Ed.Enabled = false;
                this.ub_CustomerCodeEdGuid.Enabled = false;
                this.tEdit_SectionCode_Ed.Enabled = false;
                this.ub_SectionCodeStGuid.Enabled = false;
                this.tEdit_SectionCode_St.Enabled = false;
                this.ub_SectionCodeEdGuid.Enabled = false;
                //ADD START ZHOUYU 2011/07/21 連番 967､975
                this.useMast = false;
                //ADD END ZHOUYU 2011/07/21 連番 967､975
            }
            // 使用マスタ = 拠点マスタ時
            else if (this.Mast_tComboEditor.SelectedIndex == (int)PostcardEnvelopeDMTextCndtn.UseMastDivState.SecInfo)
            {
                this._outPutMode = 3;
                // 拠点は操作可
                this.tEdit_SectionCode_Ed.Enabled = true;
                this.ub_SectionCodeStGuid.Enabled = true;
                this.tEdit_SectionCode_St.Enabled = true;
                this.ub_SectionCodeEdGuid.Enabled = true;
                // その他は操作不可
                this.OutputDiv_tComboEditor.SelectedIndex = -1;
                this.OutputDiv_tComboEditor.Enabled = false;
                this.tDateEdit_TotalDay.Enabled = false;
                this.tDateEdit_St_AddUpDay.Enabled = false;
                this.tDateEdit_Ed_AddUpDay.Enabled = false;
                this.tNedit_SupplierCd_St.Enabled = false;
                this.ub_SupplierCodeStGuid.Enabled = false;
                this.tNedit_SupplierCd_Ed.Enabled = false;
                this.ub_SupplierCodeEdGuid.Enabled = false;
                this.tNedit_CustomerCode_St.Enabled = false;
                this.ub_CustomerCodeStGuid.Enabled = false;
                this.tNedit_CustomerCode_Ed.Enabled = false;
                this.ub_CustomerCodeEdGuid.Enabled = false;
                //ADD START ZHOUYU 2011/07/21 連番 967､975
                this.useMast = false;
                //ADD END ZHOUYU 2011/07/21 連番 967､975

            }

        }
        #endregion

        #region ◆ 出力区分選択
        /// <summary>
        /// 出力区分Comboxを選択する                                             
        /// </summary>
        /// <param name="sender">イベントソース</param>                              
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note　　　  : 出力区分Combox選択時に発生します</br>                  
        /// <br>Programmer  : 朱宝軍</br>                                   
        /// <br>Date        : 2009.04.01</br>                                        
        /// </remarks>
        private void tComboEditor_OutputDiv_ValueChanged(object sender, EventArgs e)
        {
            // 出力区分は「請求有り」時
            if (OutputDiv_tComboEditor.SelectedIndex == (int)PostcardEnvelopeDMTextCndtn.OutShipDivState.Claim)
            {
                // 締日は操作できる
                this.tDateEdit_TotalDay.Enabled = true;
                // 対象日付(開始)は操作不可
                this.tDateEdit_St_AddUpDay.Enabled = false;
                // 対象日付(終了)は操作不可
                this.tDateEdit_Ed_AddUpDay.Enabled = false;
                this.outPutCD = false;
            }
            // 出力区分は「伝票有り」時
            else if (OutputDiv_tComboEditor.SelectedIndex == (int)PostcardEnvelopeDMTextCndtn.OutShipDivState.Slip)
            {
                // 締日は操作不可
                this.tDateEdit_TotalDay.Enabled = false;
                // 対象日付(開始)は操作できる
                this.tDateEdit_St_AddUpDay.Enabled = true;
                // 対象日付(終了)は操作できる
                this.tDateEdit_Ed_AddUpDay.Enabled = true;
                this.outPutCD = false;
            }
            // 出力区分は「全て」時
            else if (OutputDiv_tComboEditor.SelectedIndex == (int)PostcardEnvelopeDMTextCndtn.OutShipDivState.All)
            {
                // 全ては操作できる
                /*DEL START ZHOUYU 2011/07/21 連番 967､975----------------
                this.tDateEdit_TotalDay.Enabled = true;
                this.tDateEdit_St_AddUpDay.Enabled = true;
                this.tDateEdit_Ed_AddUpDay.Enabled = true;
                ----------------DEL START ZHOUYU 2011/07/21 連番 967､975*/
                //ADD START ZHOUYU 2011/07/21 連番 967､975
                this.outPutCD = true;
                if (outPutCD && useMast)
                {
                    this.tDateEdit_TotalDay.Enabled = false;
                    this.tDateEdit_St_AddUpDay.Enabled = false;
                    this.tDateEdit_Ed_AddUpDay.Enabled = false;
                    this.tDateEdit_TotalDay.Clear();
                    this.tDateEdit_St_AddUpDay.Clear();
                    this.tDateEdit_Ed_AddUpDay.Clear();
                }
                //ADD START ZHOUYU 2011/07/21 連番 967､975
            }
            ToolBackState();
        }
        #endregion

        /// <summary> 
        /// エクスプローラーバー グループ縮小 イベント 
        /// </summary> 
        /// <param name="sender">イベントオブジェクト</param> 
        /// <param name="e">イベント情報</param> 
        /// <remarks> 
        /// <br>Note : グループが縮小される前に発生します。</br> 
        /// <br>Programer : 朱宝軍</br> 
        /// <br>Date : 2009.04.01</br> 
        /// </remarks> 
        private void Main_ultraExplorerBar_GroupCollapsing(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
        {
            if ((e.Group.Key == ct_EXBARGROUPNM_REPORTSELECTGROUP) ||
                (e.Group.Key == ct_EXBARGROUPNM_PRINTODERGROUP) ||
                (e.Group.Key == ct_EXBARGROUPNM_PRINTCONDITIONGROUP))
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
        /// <br>Note : グループが展開される前に発生します。</br> 
        /// <br>Programer : 朱宝軍</br> 
        /// <br>Date : 2009.04.01</br> 
        /// </remarks> 
        private void Main_ultraExplorerBar_GroupExpanding(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
        {
            if ((e.Group.Key == ct_EXBARGROUPNM_REPORTSELECTGROUP) ||
               (e.Group.Key == ct_EXBARGROUPNM_PRINTODERGROUP) ||
               (e.Group.Key == ct_EXBARGROUPNM_PRINTCONDITIONGROUP))
            {
                // グループの展開をキャンセル
                e.Cancel = true;
            }

        }

        #endregion　■ Private Event

        #region ■ Control Event
        /// <summary>
        /// PMKHN07000U_Load Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: ユーザーがﾌｫｰﾑを読み込むときに発生する</br>
        /// <br>Programmer	: 朱宝軍</br>
        /// <br>Date		: 2009.04.01</br>
        /// </remarks>
        private void PMKHN07000U_Load(object sender, EventArgs e)
        {
            string errMsg = string.Empty;
            // コントロール初期化
            this.InitializeScreen();
            ParentToolbarSettingEvent(this);						// ツールバーボタン設定イベント起動 
        }
        #endregion

        #region ■ Private Method

        #region ◎ 入力チェック処理

        /// <summary>
        /// 日付チェック処理呼び出し
        /// </summary>
        /// <param name="cdrResult"></param>
        /// <param name="tde_St_OrderDataCreateDate">開始日付</param>
        /// <param name="tde_Ed_OrderDataCreateDate">終了日付</param>
        /// <returns>True:OK, False:NG</returns>
        /// <remarks>
        /// <br>Note		: 画面の入力チェックを行う。</br>
        /// <br>Programmer	: 朱宝軍</br>
        /// <br>Date		: 2009.04.01</br>
        /// </remarks>
        private bool CallCheckDateRange(out DateGetAcs.CheckDateRangeResult cdrResult, ref TDateEdit tde_St_OrderDataCreateDate, ref TDateEdit tde_Ed_OrderDataCreateDate)
        {
            cdrResult = _dateGet.CheckDateRange(DateGetAcs.YmdType.YearMonth, 1, ref tde_St_OrderDataCreateDate, ref tde_Ed_OrderDataCreateDate, false, false, true);
            return (cdrResult == DateGetAcs.CheckDateRangeResult.OK);
        }

        /// <summary>
        /// Coopyチェック処理                                              
        /// </summary>
        /// <remarks>
        /// <br>Note　　　  : Copy文字時に発生します</br>                  
        /// <br>Programmer  : 朱宝軍</br>                                    
        /// <br>Date        : 2009.04.01</br>                                        
        /// </remarks>
        private void WordCoopyCheck()
        {
            // 得意先コード
            int customerStCode = this.tNedit_CustomerCode_St.GetInt();
            int customerEdCode = this.tNedit_CustomerCode_Ed.GetInt();
            if (customerStCode == 0 && this.tNedit_CustomerCode_St.Text.Trim().Length > 0)
            {
                this.tNedit_CustomerCode_St.Text = String.Empty;
            }
            if (customerEdCode == 0 && this.tNedit_CustomerCode_Ed.Text.Trim().Length > 0)
            {
                this.tNedit_CustomerCode_Ed.Text = String.Empty;
            }
            // 仕入先コード
            int supplierStCode = this.tNedit_SupplierCd_St.GetInt();
            int supplierEdCode = this.tNedit_SupplierCd_Ed.GetInt();
            if (supplierStCode == 0 && this.tNedit_SupplierCd_St.Text.Trim().Length > 0)
            {
                this.tNedit_SupplierCd_St.Text = String.Empty;
            }
            if (supplierEdCode == 0 && this.tNedit_SupplierCd_Ed.Text.Trim().Length > 0)
            {
                this.tNedit_SupplierCd_Ed.Text = String.Empty;
            }

            // 拠点コード
            Regex r = new Regex(@"^\d+(\.)?\d*$");
            if (this.tEdit_SectionCode_St.DataText.TrimEnd() != String.Empty && !r.IsMatch(this.tEdit_SectionCode_St.DataText))
            {
                this.tEdit_SectionCode_St.Text = String.Empty;
            }
            if (this.tEdit_SectionCode_Ed.DataText.TrimEnd() != String.Empty && !r.IsMatch(this.tEdit_SectionCode_Ed.DataText))
            {
                this.tEdit_SectionCode_Ed.Text = String.Empty;
            }
        }

        /// <summary>
        /// 入力チェック処理
        /// </summary>
        /// <param name="errMessage">エラーメッセージ</param>
        /// <param name="errComponent">エラー発生コンポーネント</param>
        /// <returns>True:OK, False:NG</returns>
        /// <remarks>
        /// <br>Note		: 画面の入力チェックを行う。</br>
        /// <br>Programmer	: 朱宝軍</br>
        /// <br>Date		: 2009.04.01</br>
        /// </remarks>
        private bool ScreenInputCheck(ref string errMessage, ref Control errComponent)
        {
            bool status = true;

            DateGetAcs.CheckDateRangeResult cdrResult;
            // Copyチェック
            WordCoopyCheck();

            // 使用マスタ
            if (this.Mast_tComboEditor.SelectedIndex == -1)
            {
                errMessage = string.Format("使用マスタ{0}", ct_NOINPUT);
                errComponent = this.Mast_tComboEditor;
                status = false;
            }
            // 締日
            if (status != false && tDateEdit_TotalDay.GetLongDate() != 0)
            {
                if (this.tDateEdit_TotalDay.GetDateTime() == DateTime.MinValue)
                {
                    errMessage = string.Format("締日{0}", ct_INPUTERROR);
                    errComponent = tDateEdit_TotalDay;
                    status = false;
                }
            }
            //else if (status != false && tDateEdit_TotalDay.GetLongDate() == 0)  //DEL ZHOUYU 2011/07/21 連番 967､975
            else if (status != false && tDateEdit_TotalDay.GetLongDate() == 0 && (!useMast || !outPutCD))  //ADD ZHOUYU 2011/07/21 連番 967､975
            {
                if (this.OutputDiv_tComboEditor.SelectedIndex == 0 || this.OutputDiv_tComboEditor.SelectedIndex == 1)
                {
                    errMessage = string.Format("締日{0}", ct_NOINPUT);
                    errComponent = tDateEdit_TotalDay;
                    status = false;
                }
            }
            // 対象日付（開始～終了）
            //if (this.OutputDiv_tComboEditor.SelectedIndex == 0 || this.OutputDiv_tComboEditor.SelectedIndex == 2)  //DEL ZHOUYU 2011/07/21 連番 967､975
            if ((this.OutputDiv_tComboEditor.SelectedIndex == 0 || this.OutputDiv_tComboEditor.SelectedIndex == 2) && (!useMast || !outPutCD))   //ADD ZHOUYU 2011/07/21 連番 967､975
            {
                if (status != false && CallCheckDateRange(out cdrResult, ref tDateEdit_St_AddUpDay, ref tDateEdit_Ed_AddUpDay) == false)
                {
                    switch (cdrResult)
                    {
                        case DateGetAcs.CheckDateRangeResult.ErrorOfStartInvalid:
                            {
                                errMessage = string.Format("対象日付(開始){0}", ct_INPUTERROR);
                                errComponent = this.tDateEdit_St_AddUpDay;
                            }
                            status = false;
                            break;
                        case DateGetAcs.CheckDateRangeResult.ErrorOfStartNoInput:
                            {
                                errMessage = string.Format("対象日付(開始){0}", ct_NOINPUT);
                                errComponent = this.tDateEdit_St_AddUpDay;
                            }
                            status = false;
                            break;
                        case DateGetAcs.CheckDateRangeResult.ErrorOfEndInvalid:
                            {
                                errMessage = string.Format("対象日付(終了){0}", ct_INPUTERROR);
                                errComponent = this.tDateEdit_Ed_AddUpDay;
                            }
                            status = false;
                            break;
                        case DateGetAcs.CheckDateRangeResult.ErrorOfEndNoInput:
                            {
                                errMessage = string.Format("対象日付(終了){0}", ct_NOINPUT);
                                errComponent = this.tDateEdit_Ed_AddUpDay;
                            }
                            status = false;
                            break;
                        case DateGetAcs.CheckDateRangeResult.ErrorOfReverse:
                            {
                                errMessage = string.Format("対象日付{0}", ct_RANGEERROR);
                                errComponent = this.tDateEdit_St_AddUpDay;
                            }
                            status = false;
                            break;
                    }
                }
            }
            // 拠点（開始～終了）
            if (status != false && !string.IsNullOrEmpty(this.tEdit_SectionCode_St.DataText.TrimEnd()) &&
                !string.IsNullOrEmpty(this.tEdit_SectionCode_Ed.DataText.TrimEnd()) &&
                Int32.Parse(this.tEdit_SectionCode_St.DataText.TrimEnd()) > Int32.Parse(this.tEdit_SectionCode_Ed.DataText.TrimEnd()))
            {
                errMessage = string.Format("拠点{0}", ct_RANGEERROR);
                errComponent = this.tEdit_SectionCode_St;
                status = false;

            }

            // 得意先（開始～終了）
            if (status != false && !string.IsNullOrEmpty(this.tNedit_CustomerCode_St.DataText)
                && !string.IsNullOrEmpty(this.tNedit_CustomerCode_Ed.DataText))
            {
                if (this.tNedit_CustomerCode_St.GetInt() > this.tNedit_CustomerCode_Ed.GetInt())
                {
                    errMessage = string.Format("得意先{0}", ct_RANGEERROR);
                    errComponent = this.tNedit_CustomerCode_St;
                    status = false;
                }
            }
            // 仕入先（開始～終了）
            if (status != false && !string.IsNullOrEmpty(this.tNedit_SupplierCd_St.DataText)
                && !string.IsNullOrEmpty(this.tNedit_SupplierCd_Ed.DataText))
            {
                if (this.tNedit_SupplierCd_St.GetInt() > this.tNedit_SupplierCd_Ed.GetInt())
                {
                    errMessage = string.Format("仕入先{0}", ct_RANGEERROR);
                    errComponent = this.tNedit_SupplierCd_St;
                    status = false;
                }
            }


            return status;
        }
        #endregion

        #region ◎ エラーメッセージ表示処理 ( +1のオーバーロード )
        /// <summary>エラーメッセージ表示処理</summary>
        /// <param name="iLevel">エラーレベル</param>
        /// <param name="message">エラーメッセージ</param>
        /// <param name="status">エラーステータス</param>
        /// <param name="iButton">表示ボタン</param>
        /// <param name="iDefButton">初期フォーカスボタン</param>
        /// <returns>DialogResult</returns>
        /// <remarks>エラーメッセージを表示します。
        /// <br>Programmer	: 朱宝軍</br>
        /// <br>Date		: 2009.04.01</br>
        /// </remarks>
        private DialogResult MsgDispProc(emErrorLevel iLevel, string message, int status, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
        {
            return TMsgDisp.Show(iLevel
                                , this.Name
                                , message
                                , status
                                , iButton
                                , iDefButton);
        }
        /// <summary>エラーメッセージ表示処理</summary>
        /// <param name="iLevel">エラーレベル</param>
        /// <param name="message">エラーメッセージ</param>
        /// <param name="status">エラーステータス</param>
        /// <remarks>
        /// <br>Programmer	: 朱宝軍</br>
        /// <br>Date		: 2009.04.01</br>
        /// </remarks>
        private void MsgDispProc(emErrorLevel iLevel, string message, int status)
        {
            TMsgDisp.Show(
                iLevel, 							// エラーレベル
                ct_CLASSID,							// アセンブリＩＤまたはクラスＩＤ
                this.ct_PRINTNAME,					// プログラム名称
                "", 								// 処理名称
                "",									// オペレーション
                message,							// 表示するメッセージ
                status, 							// ステータス値
                null, 								// エラーが発生したオブジェクト
                MessageBoxButtons.OK, 				// 表示するボタン
                MessageBoxDefaultButton.Button1);	// 初期表示ボタン
        }
        #endregion ◆ エラーメッセージ表示処理 ( +1のオーバーロード )

        #region ◎ オフライン状態チェック処理
        /// <summary>
        /// ログオン時オンライン状態チェック処理
        /// </summary>
        /// <returns>チェック処理結果</returns>
        /// <remarks>
        /// <br>Note		: ログオン時オンライン状態チェック処理を行う。</br>
        /// <br>Programmer	: 朱宝軍</br>
        /// <br>Date		: 2009.04.01</br>
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
        /// <returns>チェック処理結果</returns>
        /// <remarks>
        /// <br>Note		: リモート接続可能判定を行う。</br>
        /// <br>Programmer	: 朱宝軍</br>
        /// <br>Date		: 2009.04.01</br>
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

        #region ◎ 画面初期化処理
        /// <summary>
        /// 画面初期化処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note		: 画面初期化処理を行う</br>
        /// <br>Programmer	: 朱宝軍</br>
        /// <br>Date		: 2009.04.01</br>
        /// </remarks>
        private void InitializeScreen()
        {

            Infragistics.Win.ValueListItem listItemMast = new Infragistics.Win.ValueListItem();
            // 使用マスタCombox
            // 得意先マスタ
            listItemMast.DataValue = 0;
            listItemMast.DisplayText = "得意先マスタ";
            this.Mast_tComboEditor.Items.Add(listItemMast);
            // 仕入先マスタ
            listItemMast = new Infragistics.Win.ValueListItem();
            listItemMast.DataValue = 1;
            listItemMast.DisplayText = "仕入先マスタ";
            this.Mast_tComboEditor.Items.Add(listItemMast);
            // 自社マスタ
            listItemMast = new Infragistics.Win.ValueListItem();
            listItemMast.DataValue = 2;
            listItemMast.DisplayText = "自社マスタ";
            this.Mast_tComboEditor.Items.Add(listItemMast);
            // 拠点マスタ
            listItemMast = new Infragistics.Win.ValueListItem();
            listItemMast.DataValue = 3;
            listItemMast.DisplayText = "拠点マスタ";
            this.Mast_tComboEditor.Items.Add(listItemMast);

            Infragistics.Win.ValueListItem listItemDiv = new Infragistics.Win.ValueListItem();
            // 出力区分Combox
            // 全て
            listItemDiv.DataValue = 0;
            listItemDiv.DisplayText = "全て";
            this.OutputDiv_tComboEditor.Items.Add(listItemDiv);
            // 請求有り
            listItemDiv = new Infragistics.Win.ValueListItem();
            listItemDiv.DataValue = 1;
            listItemDiv.DisplayText = "請求有り";
            this.OutputDiv_tComboEditor.Items.Add(listItemDiv);
            // 伝票有り
            listItemDiv = new Infragistics.Win.ValueListItem();
            listItemDiv.DataValue = 2;
            listItemDiv.DisplayText = "伝票有り";
            this.OutputDiv_tComboEditor.Items.Add(listItemDiv);
            this.OutputDiv_tComboEditor.Enabled = false;

            ToolBackState();

            this.Mast_tComboEditor.SelectedIndex = 0;

            this.Mast_tComboEditor.Focus();

        }
        #endregion

        #region ◎ ボタンアイコン設定処理
        /// <summary>
        /// ボタンアイコン設定処理
        /// </summary>
        /// <param name="settingControl">アイコンセットするコントロール</param>
        /// <param name="iconIndex">アイコンインデックス</param>
        /// <remarks>
        /// <br>Note		: ボタンアイコン設定処理を行う。</br>
        /// <br>Programmer	: 朱宝軍</br>
        /// <br>Date		: 2009.04.01</br>
        /// </remarks>
        private void SetIconImage(object settingControl, Size16_Index iconIndex)
        {
            ((UltraButton)settingControl).ImageList = IconResourceManagement.ImageList16;
            ((UltraButton)settingControl).Appearance.Image = iconIndex;
        }
        #endregion

        #region ◎ 印刷情報取得処理
        /// <summary>
        /// 印刷情報取得処理
        /// </summary>
        /// <param name="printInfo">印刷情報</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note		: 印刷情報を取得します。</br>
        /// <br>Programmer	: 朱宝軍</br>
        /// <br>Date		: 2009.03.26</br>
        /// </remarks>
        private int GetPrintInfo(out SFCMN06002C printInfo)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            // 印刷情報パラメータ
            printInfo = new SFCMN06002C();
            // 帳票選択ガイド
            SFCMN00391U printDialog = new SFCMN00391U();

            printInfo.enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            // 起動ＰＧＩＤ
            printInfo.kidopgid = ct_PGID;
            printInfo.selectInfoCode = 1;
            printInfo.PrintPaperSetCd = this._outPutMode;
            // 帳票選択ガイド
            printDialog.PrintMode = 1;
            printDialog.PrintInfo = printInfo;
            DialogResult dialogResult = printDialog.ShowDialog();
            switch (dialogResult)
            {
                case DialogResult.OK:
                    if (File.Exists(printInfo.outPutFilePathName) == false)
                    {
                        // ファイルなし
                        status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                    }
                    else
                    {
                        // ファイルが存在する場合は、オープンチェック
                        try
                        {
                            // 仮に名称を変更
                            string tempFileName = printInfo.outPutFilePathName
                                                + DateTime.Now.Ticks.ToString();
                            FileInfo fi = new FileInfo(printInfo.outPutFilePathName);
                            fi.MoveTo(tempFileName);
                            // 名称の変更が正しく行えたので、名称を元に戻す
                            fi.MoveTo(printInfo.outPutFilePathName);

                            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                        }
                        catch (Exception)
                        {
                            // 名称変更失敗 -> 他のアプリケーションが排他で使用中
                            MsgDispProc(emErrorLevel.ERR_LEVEL_INFO
                                        , "指定されたファイルは使用できません。\r\n"
                                        + "Excel等が使用していないか確認して、\r\n"
                                        + "使用しているときはファイルを閉じて下さい。"
                                        , 0
                                        , MessageBoxButtons.OK
                                        , MessageBoxDefaultButton.Button1);
                            status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                        }
                    }
                    break;
                case DialogResult.Cancel:
                    status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                    break;
                default:
                    // 例外が発生
                    status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                    break;
            }

            return status;
        }
        #endregion

        #region ◎ 検索情報処理
        /// <summary>
        /// 検索情報処理
        /// </summary>
        /// <param name="condtionWork">検索情報</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note		: 検索情報処理を行う。</br>
        /// <br>Programmer	: 朱宝軍</br>
        /// <br>Date		: 2009.03.26</br>
        /// </remarks>
        private void SetCondtionWork(ref PostcardEnvelopeDMTextCndtn condtionWork)
        {
            // 企業コード
            condtionWork.EnterpriseCode = this._enterpriseCode;

            // 拠点コード開始
            condtionWork.St_SectionCode = this.tEdit_SectionCode_St.DataText.TrimEnd();

            // 拠点コード終了
            condtionWork.Ed_SectionCode = this.tEdit_SectionCode_Ed.DataText.TrimEnd();

            // 使用マスタ
            condtionWork.UseMast = this.Mast_tComboEditor.SelectedIndex;

            // 出力区分
            if (this.Mast_tComboEditor.SelectedIndex != -1)
            {
                condtionWork.OutShipDiv = this.OutputDiv_tComboEditor.SelectedIndex;
            }
            else
            {
                condtionWork.OutShipDiv = 0;
            }
            // 締日
            condtionWork.TotalDay = this.tDateEdit_TotalDay.GetDateTime();

            // 対象日付開始日
            condtionWork.St_AddUpDay = this.tDateEdit_St_AddUpDay.GetDateTime();

            // 対象日付終了日
            condtionWork.Ed_AddUpDay = this.tDateEdit_Ed_AddUpDay.GetDateTime();

            // 得意先コード開始
            condtionWork.St_CustomerCode = this.tNedit_CustomerCode_St.GetInt();

            // 得意先コード終了
            condtionWork.Ed_CustomerCode = this.tNedit_CustomerCode_Ed.GetInt();

            // 仕入先コード開始
            condtionWork.St_SupplierCode = this.tNedit_SupplierCd_St.GetInt();

            // 仕入先コード終了
            condtionWork.Ed_SupplierCode = this.tNedit_SupplierCd_Ed.GetInt();

        }
        #endregion

        /// <summary>
        /// 設置コンポーネントState
        /// </summary>
        /// <remarks>
        /// <br>Note		: コンポーネントState設置を行う。</br>
        /// <br>Programmer	: 朱宝軍</br>
        /// <br>Date		: 2009.03.26</br>
        /// </remarks>
        private void ToolBackState()
        {
            //ADD START ZHOUYU 2011/07/21 連番 967､975
            if (!useMast || !outPutCD)
            {
            //ADD END ZHOUYU 2011/07/21 連番 967､975
                // 対象日付
                if (this.Mast_tComboEditor.SelectedIndex == 0)
                {
                    if (this.OutputDiv_tComboEditor.SelectedIndex == 1)
                    {
                        this.tDateEdit_St_AddUpDay.SetDateTime(DateTime.MinValue);
                        this.tDateEdit_Ed_AddUpDay.SetDateTime(DateTime.MinValue);
                    }
                    else
                    {
                        this.tDateEdit_St_AddUpDay.SetDateTime(DateTime.Now);
                        this.tDateEdit_Ed_AddUpDay.SetDateTime(DateTime.Now);
                    }
                }
                else
                {
                    this.tDateEdit_St_AddUpDay.SetDateTime(DateTime.MinValue);
                    this.tDateEdit_Ed_AddUpDay.SetDateTime(DateTime.MinValue);
                }

                // 締日
                this.tDateEdit_TotalDay.SetDateTime(DateTime.MinValue);
            }   //ADD ZHOUYU 2011/07/21 連番 967､975
            // 拠点
            this.tEdit_SectionCode_Ed.Clear();
            this.tEdit_SectionCode_St.Clear();
            // 得意先
            this.tNedit_CustomerCode_St.Clear();
            this.tNedit_CustomerCode_Ed.Clear();
            //仕入先
            this.tNedit_SupplierCd_St.Clear();
            this.tNedit_SupplierCd_Ed.Clear();
            // ボタン設定
            this.SetIconImage(this.ub_CustomerCodeStGuid, Size16_Index.STAR1);
            this.SetIconImage(this.ub_CustomerCodeEdGuid, Size16_Index.STAR1);
            this.SetIconImage(this.ub_SupplierCodeStGuid, Size16_Index.STAR1);
            this.SetIconImage(this.ub_SupplierCodeEdGuid, Size16_Index.STAR1);
            this.SetIconImage(this.ub_SectionCodeStGuid, Size16_Index.STAR1);
            this.SetIconImage(this.ub_SectionCodeEdGuid, Size16_Index.STAR1);
        }

        #endregion　■ Private Method


    }
}