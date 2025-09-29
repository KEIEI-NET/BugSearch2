//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 問合せ一覧/受注検索ウィンドウ
// プログラム概要   : SCM受注データ、SCM受注明細データの照会を行う。
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 上野 俊治
// 作 成 日  2009/05/27  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤
// 作 成 日  2009/09/10  修正内容 : 画面レイアウト変更および初期表示内容の変更
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 佐々木 健
// 作 成 日  2010/02/09  修正内容 : 既存不具合修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 長内 数馬
// 作 成 日  2010/03/02  修正内容 : 確定時の戻り値に問合せ元企業、拠点コード追加
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 對馬 大輔
// 作 成 日  2010/03/10  修正内容 : ①明細部ダブルクリックで売伝起動
//                                : ②明細情報表示ボタン追加
//                                : ③売伝起動時の回答区分初期値変更
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤
// 作 成 日  2010/03/31  修正内容 : 検索条件に一部回答を含む場合、未回答の明細データが表示されない
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤
// 作 成 日  2010/04/16  修正内容 : キャンセル対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤
// 作 成 日  2010/04/16  修正内容 : レイアウト変更(伝票番号、伝票区分、受注ステータスを撤去)
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 佐々木 健
// 作 成 日  2010/05/20  修正内容 : 手動受信対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 佐々木 健
// 作 成 日  2010/05/27  修正内容 : ①明細のセット元データを判別できるように修正
//                                 ②キャンセル不可機能を追加
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤
// 作 成 日  2010/06/17  修正内容 : キャンセル追加対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 對馬 大輔
// 作 成 日  2010/06/17  修正内容 : Delphi売伝を起動するように変更
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 對馬 大輔
// 作 成 日  2010/07/30  修正内容 : クライアントアセンブリの受信処理を起動するように変更
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 佐々木 健
// 作 成 日  2011/01/24  修正内容 : ・明細単位で回答状況を表示するように修正
//                                 ・問合/発注を別明細で表示するように修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 佐々木 健
// 作 成 日  2011/02/07  修正内容 : ・売上伝票入力用のメソッドのパラメータ変更
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 佐々木 健
// 作 成 日  2011/02/17  修正内容 : ・全明細回答済み時のメッセージ修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 佐々木 健
// 作 成 日  2011/02/18  修正内容 : ・売伝とのインターフェース変更
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 佐々木 健
// 作 成 日  2011/03/07  修正内容 : ・年式を表示するように修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 久保田 誠
// 作 成 日  2011/05/26  修正内容 : 
//----------------------------------------------------------------------------//
// 管理番号  10703242-00 作成担当 : 20056 對馬 大輔
// 作 成 日  2011/06/09  修正内容 : 名称変更対応[SCM→PCC]
//----------------------------------------------------------------------------//
// 管理番号  10703242-00 作成担当 : 22018 鈴木 正臣
// 作 成 日  2011/06/13  修正内容 : ①抽出条件を問合せ日⇒更新日に変更
//                                 ②グリッドに「更新日」を追加
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : duzg
// 作 成 日  2011/07/18  修正内容 : 「自動回答」の列をクリックすると
// 　　　　　　　　　　　　　　   : 「PCC問い合わせ一覧」を起動します
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 鄧潘ハン
// 作 成 日  2011/09/16  修正内容 : Redmine 25196 PM側　問合せ一覧→売上入力の修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 葛中華
// 作 成 日  2011/11/12  修正内容 : Redmine 26534 受発注種別を追加し、PCCforNSとBLパーツオーダーシステムの判断を可能とする
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 30747 三戸 伸悟
// 作 成 日  2012/10/10  修正内容 : 2012/11/14配信分 SCM障害№32 一覧に「車台番号」追加
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 30744 湯上 千加子
// 作 成 日  2013/03/29  修正内容 : SCM障害№10503対応
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : qijh
// 作 成 日  2013/04/24  修正内容 : 2013/06/18配信 No.234 Redmine#35272
//                                  売上伝票入力へ遷移前のチェックを追加
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 湯上 千加子
// 作 成 日  2013/05/09  修正内容 : 2013/06/18配信　SCM障害№10384対応
//----------------------------------------------------------------------------//
// 管理番号  10902175-00 作成担当 : 宮本 利明
// 作 成 日  2013/06/26  修正内容 : 2013/06/18配信 システムテスト障害対応 №30
//----------------------------------------------------------------------------//
// 管理番号  10902175-00 作成担当 : 脇田 靖之
// 作 成 日  2013/10/18  修正内容 : 2013/06/18配信 システムテスト障害対応 №84、94
//----------------------------------------------------------------------------//
// 管理番号  11070184-00 作成担当 : 陳艶丹
// 作 成 日  2014/09/22  修正内容 : PM-SCM仕掛一覧No.10661とNo.85
//                                  複数端末で同時に発注できるので、過剰出荷、過剰売上のリスクの対応
//----------------------------------------------------------------------------//
// 管理番号  11070221-00 作成担当 : 陳艶丹
// 作 成 日  2014/11/17  修正内容 : PM-SCM仕掛一覧№85 RedMine#43973
//                                  新着一覧から削除に表示されるタイミングが端末毎に違うことの対応(社内SCM№55)
//----------------------------------------------------------------------------//
// 管理番号  11175298-00 作成担当 : 陳艶丹
// 作 成 日  2015/09/16  修正内容 : Redmine#47295【SCM仕掛No10691】SCM問合せ一覧で未回答を選択しても回答できないの対応
//----------------------------------------------------------------------------//

using System;
using System.IO;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;

using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Library.Resources;

using Infragistics.Win.Misc;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 問合せ一覧/受注検索ウィンドウ検索フォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : SCM受注データ、SCM受注明細データの照会を行う</br>
    /// <br>Programmer : 30452 上野 俊治</br>
    /// <br>Date       : 2009.05.27</br>
    /// <br>Update Note: 2011/09/16 鄧潘ハン　PM側　問合せ一覧→売上入力の修正</br>
    /// <br>Update Note: 2014/11/17 陳艶丹</br>
    /// <br>管理番号   : 11070221-00　PM-SCM仕掛一覧No.85　RedMine#43973</br>
    /// <br>2014/11/26配信 社内SCM№55の対応</br>
    /// <br>RedMine#43973新着一覧に表示されるタイミングが端末毎に違う</br>
    /// </remarks>
    public partial class PMSCM04001UA : Form
    {
        #region ■private定数
        // 画面状態保存用ファイル名
        private const string XML_FILE_INITIAL_DATA = "PMSCM04001U.dat";
        
        // 売上伝票入力の実行exe
        //>>>2010/06/17
        //private const string SALESSLIPINPUT_EXE_NAME = "MAHNB01000U.exe";
        private const string SALESSLIPINPUT_EXE_NAME = "MAHNB01001U.exe";
        //<<<2010/06/17

        //エラー条件メッセージ
        private const string ct_InputError = "の入力が不正です";
        private const string ct_NoInput = "を入力して下さい";
        private const string ct_RangeError = "の範囲指定に誤りがあります";

        // WebSync通知モード
        private const int CT_WebSync_NoticeMode = 100;// Add 2014/09/22 chenyd For PM-SCM仕掛一覧No.10661とNo.85対応
        #endregion

        #region ■private変数
        // 共通スキン
        private ControlScreenSkin _controlScreenSkin;

        // 企業コード
        private string _enterpriseCode;
        // 自拠点コード
        private string _sectionCode;

        // 起動モード(0:メニュー起動、1:ポップアップ起動、2:売上伝票入力起動)
        private Mode _mode;

        // コマンドライン引数
        private string[] _commandLineArgs;

        private readonly Infragistics.Win.UltraWinToolbars.LabelTool _loginSectionTitleLabel;   // ログイン拠点タイトル
        private readonly Infragistics.Win.UltraWinToolbars.LabelTool _loginSectionNameLabel;	// ログイン拠点名称
        private readonly Infragistics.Win.UltraWinToolbars.LabelTool _loginTitleLabel;		    // ログイン担当者タイトル
        private readonly Infragistics.Win.UltraWinToolbars.LabelTool _loginNameLabel;			// ログイン担当者名称

        // グリッド状態保存
        private GridStateController _gridStateController;

        // 旧システム連携あり拠点リスト
        private List<string> _legacySystemSecList;

        //private UIElement _lastElementEntered = null; // 2010/03/08

        // 前回検索条件を格納
        private SCMInquiryOrder _scmInquiryOrderBackup = null; // ADD 2013/04/24 qijh #35272

        // --- DEL 2014/11/17 chenyd For PM-SCM仕掛一覧No.85 社内SCM№55の対応 ---------------------->>>>>
        //// Pushクライアントオブジェクト
        //private SFCMN01501CA _scmPushClient;   // ADD 2014/09/22 chenyd For PM-SCM仕掛一覧No.10661とNo.85対応
        // --- DEL 2014/11/17 chenyd For PM-SCM仕掛一覧No.85 社内SCM№55の対応 ----------------------<<<<<

        #region アクセスクラス
        // 日付部品
        private DateGetAcs _dateGet;
        // 問合せ一覧表アクセスクラス
        private SCMInquiryOrderAcs _scmInquiryOrderAcs;
        // 拠点ガイド
        private SecInfoSetAcs _secInfoSetAcs;
        // SCM全体設定マスタ
        private SCMTtlStAcs _scmTtlStAcs;

        private SCMDtRcveExecAcs _scmDtRcveExecAcs;
        #endregion

        #region 前回入力値の保存
        // 拠点コードの前回入力値
        private string _beforeSectionCode;
        #endregion

        #region 得意先ガイド用
        // 押下ガイドボタン
        private UltraButton _customerGuideSender;
        #endregion

        #region 売上伝票入力からの起動関連
        // 売上伝票入力からの起動時用の処理結果
        private DialogResult _dialogResult = DialogResult.Cancel;

        // 引数
        // 起動時に渡される得意先コード
        private int _defaultCustomerCode;
        // 起動時に渡される得意先名称
        private string _defaultCustomerNm;
        // 起動時に渡される拠点コード
        private string _defaultSectionCd;
        // 起動時に渡される拠点名称
        private string _defaultSectionNm;
        /// <summary>起動時に渡される拠点名称を取得します。</summary>
        private string DefaultSectionName
        {
            get
            {
                if (string.IsNullOrEmpty(_defaultSectionNm))
                {
                    _defaultSectionNm = GetSectionName(_defaultSectionCd);
                }
                return _defaultSectionNm;
            }
            set { _defaultSectionNm = value; }
        }

        // 戻り値
        // 確定時に返す問合せ番号
        private Int64 _retInquiryNum;
        // 確定時に返す受注ステータス
        private Int32 _retAcptAnOdrStatus;
        // 確定時に返す売上伝票番号
        private string _retSalesSlipNum;

        // -- ADD 2010/03/02 ------------------>>>
        // 確定時に返す問合せ元企業コード
        private string _inqOriginalEpCd;
        // 確定時に返す問合せ元拠点コード
        private string _inqOriginalSecCd;
        // -- ADD 2010/03/02 ------------------<<<
        // ADD 2010/04/16 キャンセル対応 ---------->>>>>
        /// <summary>回答区分 ※売伝とのI/Fとして使用</summary>
        private int _answerDivCd;
        /// <summary>回答区分を取得または設定します。</summary>
        private int AnswerDivCode
        {
            get { return _answerDivCd; }
            set { _answerDivCd = value; }
        }
        // ADD 2010/04/16 キャンセル対応 ----------<<<<<

        // 2011/01/24 Add >>>
        // 確定時に返す問合せ・発注種別
        private int _inqOrdDivCd;
        // 2011/01/24 Add <<<

        //>>>2010/07/30
        /// <summary>起動パラメータ</summary>
        public string[] CommandLineArgs
        {
            get { return this._commandLineArgs; }
            set { this._commandLineArgs = value; }
        }
        //<<<2010/07/30

        #endregion
        #endregion

        #region ■コンストラクタ
        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public PMSCM04001UA()
        {
            InitializeComponent();

            #region ログイン情報

            // メンバに保持
            _loginSectionTitleLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)this.tToolbarsManager1.Tools["LabelTool_LoginSectionTitle"];
            _loginSectionNameLabel  = (Infragistics.Win.UltraWinToolbars.LabelTool)this.tToolbarsManager1.Tools["LabelTool_LoginSectionName"];
            _loginTitleLabel        = (Infragistics.Win.UltraWinToolbars.LabelTool)this.tToolbarsManager1.Tools["LabelTool_LoginTitle"];
            _loginNameLabel         = (Infragistics.Win.UltraWinToolbars.LabelTool)this.tToolbarsManager1.Tools["LabelTool_LoginName"];
            
            // アイコンを設定
            _loginSectionTitleLabel.SharedProps.AppearancesSmall.Appearance.Image   = Size16_Index.BASE;
            _loginTitleLabel.SharedProps.AppearancesSmall.Appearance.Image          = Size16_Index.EMPLOYEE;

            // ログイン情報を設定
            string loginSectionName = string.Empty;
            string loginEmployeeName= string.Empty;
            if (LoginInfoAcquisition.Employee != null)
            {
                loginSectionName = LoginInfoAcquisition.Employee.BelongSectionName;
                loginEmployeeName= LoginInfoAcquisition.Employee.Name;
            }
            _loginSectionNameLabel.SharedProps.Caption  = loginSectionName;
            _loginNameLabel.SharedProps.Caption         = loginEmployeeName;

            #endregion // ログイン情報
        }

        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="commandLineArgs">コマンドライン引数</param>
        public PMSCM04001UA(string[] commandLineArgs) : this()
        {
            if (commandLineArgs.Length > 2)
            {
                this._mode = Mode.Popup;

            }
            else
            {
                this._mode = Mode.Menu;
            }

            this._commandLineArgs = commandLineArgs;
        }

        /// <summary>
        /// 売上伝票入力からの起動用
        /// </summary>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="customerNm">得意先名称</param>
        public PMSCM04001UA(string sectionCode, string sectionNm, int customerCode , string customerNm) :this()
        {
            this._mode = Mode.SalesSlip;

            this._defaultSectionCd = sectionCode.Trim().PadLeft(2, '0');
            DefaultSectionName = sectionNm;
            this._defaultCustomerCode = customerCode;
            this._defaultCustomerNm = customerNm;

            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;　// 自企業コード
        }
        #endregion

        #region ■publicメソッド

        /// <summary>
        /// 売上伝票入力画面から渡される条件での該当件数を取得する。
        /// </summary>
        /// <returns></returns>
        public int SearchInquiryCountForSalesSlip()
        {
            // 抽出条件取得
            SCMInquiryOrder scmInquiryOrder = this.SetExtraInfoFromSalesSlip();

            int count;
            SCMInquiryOrderAcs scmInquiryOrderAcs = SCMInquiryOrderAcs.GetInstance();
            int status = scmInquiryOrderAcs.SearchCnt(scmInquiryOrder, out count);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                return count;
            }
            else
            {
                return -1;
            }
        }

        // 2011/02/07 Del >>>
#if False
        // ADD 2010/04/16 キャンセル対応 ---------->>>>>
        // HACK:売伝の対応が完了したら撤去すること
        #region 撤去予定コード

        /// <summary>
        /// 問合せ一覧画面を起動します。(売上伝票入力用) ※旧インターフェース
        /// </summary>
        /// <param name="owner">トップレベルウィンドウ</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="inquiryNum">問合せ番号</param>
        /// <<param name="acptAnOdrStatus">受注ステータス</param>
        /// <param name="salesSlipNum">売上伝票番号</param>
        /// <param name="inqOriginalEpCd">問合せ元企業コード</param>
        /// <param name="inqOriginalSecCd">問合せ元拠点コード</param>
        /// <param name="answerDivCd">回答区分</param>
        /// <returns>ダイアログボックスの戻り値</returns>
        [Obsolete("旧インターフェースです。ShowGuideForSalesSlip(IWin32Window, out Int64, out Int32, out string, out string, out string,out int)を使用して下さい。")]
        public DialogResult ShowGuideForSalesSlip(
            IWin32Window owner,
            out Int64 inquiryNum,
            out Int32 acptAnOdrStatus,
            out string salesSlipNum,
            out string inqOriginalEpCd,
            out string inqOriginalSecCd
        )
        {
            int answerDivCd = 0;
            return ShowGuideForSalesSlip(
                owner,
                out inquiryNum,
                out acptAnOdrStatus,
                out salesSlipNum,
                out inqOriginalEpCd.Trim(),//@@@@20230303
                out inqOriginalSecCd,
                out answerDivCd
            );
        }

        #endregion // 撤去予定コード
        // ADD 2010/04/16 キャンセル対応 ----------<<<<<
#endif
        // 2011/02/07 Del <<<

        /// <summary>
        /// 問合せ一覧画面を起動します。(売上伝票入力用)
        /// </summary>
        /// <param name="owner">トップレベルウィンドウ</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="inquiryNum">問合せ番号</param>
        /// <<param name="acptAnOdrStatus">受注ステータス</param>
        /// <param name="salesSlipNum">売上伝票番号</param>
        /// <param name="inqOriginalEpCd">問合せ元企業コード</param>
        /// <param name="inqOriginalSecCd">問合せ元拠点コード</param>
        /// <param name="answerDivCd">回答区分</param>
        /// <returns>ダイアログボックスの戻り値</returns>
        // -- ADD 2010/03/02 --------------------->>>
        //public DialogResult ShowGuideForSalesSlip(IWin32Window owner, out Int64 inquiryNum, out Int32 acptAnOdrStatus, out string salesSlipNum)
        // DEL 2010/04/16 キャンセル対応 ---------->>>>>
        //public DialogResult ShowGuideForSalesSlip(IWin32Window owner, out Int64 inquiryNum, out Int32 acptAnOdrStatus, out string salesSlipNum, out string inqOriginalEpCd, out string inqOriginalSecCd)    // UNDONE:回答区分を追加
        // DEL 2010/04/16 キャンセル対応 ----------<<<<<
        // ADD 2010/04/16 キャンセル対応 ---------->>>>>
        public DialogResult ShowGuideForSalesSlip(
            IWin32Window owner,
            out Int64 inquiryNum,
            out Int32 acptAnOdrStatus,
            out string salesSlipNum,
            out string inqOriginalEpCd,
            out string inqOriginalSecCd,
            // 2011/02/07 >>>
            //out int answerDivCd
            // 2011/02/18 >>>
            //out int answerDivCd,
            out short cancelDiv,
            // 2011/02/18 <<<
            out int inqOrdDivCd
            // 2011/02/07 <<<
        )
        // ADD 2010/04/16 キャンセル対応 ----------<<<<<
        // -- ADD 2010/03/02 ---------------------<<<
        {
            inquiryNum = 0;
            acptAnOdrStatus = 0;
            salesSlipNum = string.Empty;
            // -- ADD 2010/03/02 -------------->>>
            inqOriginalEpCd = string.Empty;
            inqOriginalSecCd = string.Empty;
            // -- ADD 2010/03/02 --------------<<<
            // 2011/02/18 >>>
            //// ADD 2010/04/16 キャンセル対応 ---------->>>>>
            //answerDivCd = 0;
            //// ADD 2010/04/16 キャンセル対応 ----------<<<<<
            cancelDiv = 0;
            // 2011/02/18 <<<
            inqOrdDivCd = 0;    // 2011/02/027 Add

            DialogResult dialogResult = this.ShowDialog(owner);

            if (dialogResult == DialogResult.OK)
            {
                inquiryNum = this._retInquiryNum;
                acptAnOdrStatus = this._retAcptAnOdrStatus;
                salesSlipNum = this._retSalesSlipNum;
                // -- ADD 2010/03/02 -------------->>>
                inqOriginalEpCd = this._inqOriginalEpCd.Trim();//@@@@20230303
                inqOriginalSecCd = this._inqOriginalSecCd;
                // -- ADD 2010/03/02 --------------<<<

                // 2011/02/18 >>>
                //// ADD 2010/04/16 キャンセル対応 ---------->>>>>
                //answerDivCd = AnswerDivCode;
                //// ADD 2010/04/16 キャンセル対応 ----------<<<<<
                cancelDiv = ( AnswerDivCode == 99 ) ? (short)1 : (short)0;
                // 2011/02/18 <<<
                inqOrdDivCd = this._inqOrdDivCd;      // 2011/02/07 Add
            }

            return dialogResult;
        }
        #endregion

        #region ■privateメソッド
        #region 初期設定
        /// <summary>
        /// ガイドアクセス初期化
        /// </summary>
        private void GetGuideInstance()
        {
            this._dateGet = DateGetAcs.GetInstance();
            this._scmInquiryOrderAcs = SCMInquiryOrderAcs.GetInstance();
            this._secInfoSetAcs = new SecInfoSetAcs();
            this._scmTtlStAcs = new SCMTtlStAcs();
        }

        /// <summary>
        /// 初期化を行う
        /// </summary>
        private void SetInitialSetting()
        {
            // タイトル
            if (this._mode == Mode.SalesSlip)
            {
                this.Text = "受注検索ウィンドウ";
            }
            else
            {
                //>>>2011/06/09
                //this.Text = "SCM問合せ一覧";
                this.Text = "PCC問合せ一覧";
                //<<<2011/06/09
            }

            // ガイドアクセス初期化
            this.GetGuideInstance();

            this._gridStateController = new GridStateController();

            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;　// 自企業コード
            this._sectionCode = LoginInfoAcquisition.Employee.BelongSectionCode.Trim().PadLeft(2, '0'); // 自拠点コード

            this._controlScreenSkin = new ControlScreenSkin();

            // スキン変更除外設定
            List<string> excCtrlNm = new List<string>();
            excCtrlNm.Add(this.uGroupBox_ExtractInfo.Name);
            excCtrlNm.Add(this.ultraExpandableGroupBox1.Name);  // ADD 2009/09/10 画面レイアウト変更および初期表示内容の変更
            this._controlScreenSkin.SetExceptionCtrl(excCtrlNm);

            this._controlScreenSkin.LoadSkin();
            this._controlScreenSkin.SettingScreenSkin(this);

            // ツールバーアイコン設定
            tToolbarsManager1.ImageListSmall = IconResourceManagement.ImageList16;
            this.tToolbarsManager1.Tools["ButtonTool_Close"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
            this.tToolbarsManager1.Tools["ButtonTool_SalesSlip"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SLIP;
            this.tToolbarsManager1.Tools["ButtonTool_Select"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DECISION;
            this.tToolbarsManager1.Tools["ButtonTool_Search"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SEARCH;
            this.tToolbarsManager1.Tools["ButtonTool_Clear"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.ALLCANCEL;
            this.tToolbarsManager1.Tools["ButtonTool_Receive"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DOWNLOAD;    // 2010/05/20 Add

            if (this._mode == Mode.SalesSlip)
            {
                this.tToolbarsManager1.Tools["ButtonTool_SalesSlip"].SharedProps.Visible = false;
                this.tToolbarsManager1.Tools["ButtonTool_Select"].SharedProps.Visible = true;
            }
            else
            {
                this.tToolbarsManager1.Tools["ButtonTool_SalesSlip"].SharedProps.Visible = true;
                this.tToolbarsManager1.Tools["ButtonTool_Select"].SharedProps.Visible = false;
            }

            // ガイドボタン設定
            ImageList imageList16 = IconResourceManagement.ImageList16;
            this.uButton_SectionCdGuide.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.uButton_CustomerCdGuideSt.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.uButton_CustomerCdGuideEd.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];

            // グリッド設定
            this.SetGridSetting();
        }

        /// <summary>
        /// 初期項目設定(起動モードにより異なる)
        /// </summary>
        private void ClearScreenByMode()
        {
            // 前回入力値のクリア
            this._beforeSectionCode = string.Empty;

            // 回答区分
            if (this._mode == Mode.Popup)
            {
                uCheckEditor_AnswerDivNon.Checked = true;
                uCheckEditor_AnswerDivPart.Checked = true;
                uCheckEditor_AnswerDivComplate.Checked = false;
                uCheckEditor_AnswerDivCancel.Checked = false;
            }
            else if (this._mode == Mode.SalesSlip)
            {
                uCheckEditor_AnswerDivNon.Checked = true;
                uCheckEditor_AnswerDivPart.Checked = true;
                //>>>2010/03/10
                //uCheckEditor_AnswerDivComplate.Checked = true;
                //uCheckEditor_AnswerDivCancel.Checked = true;
                uCheckEditor_AnswerDivComplate.Checked = false;
                uCheckEditor_AnswerDivCancel.Checked = false;
                //<<<2010/03/10
                // ADD 2010/04/16 キャンセル対応 ---------->>>>>
            #if DEBUG
                // デバッグ用に[回答完了]チェックボックスは操作可能
            #else
                // 売伝から呼び出されたときは[回答完了]チェックボックスは操作不可
                this.uCheckEditor_AnswerDivComplate.Visible = false;
            #endif
                // ADD 2010/04/16 キャンセル対応 ----------<<<<<
            }
            else
            {
                // DEL 2009/09/10 画面レイアウト変更および初期表示内容の変更 ---------->>>>>
                //uCheckEditor_AnswerDivNon.Checked = false;
                //uCheckEditor_AnswerDivPart.Checked = false;
                //uCheckEditor_AnswerDivComplate.Checked = false;
                //uCheckEditor_AnswerDivCancel.Checked = false;
                // DEL 2009/09/10 画面レイアウト変更および初期表示内容の変更 ----------<<<<<
                // ADD 2009/09/10 画面レイアウト変更および初期表示内容の変更 ---------->>>>>
                uCheckEditor_AnswerDivNon.Checked = true;
                uCheckEditor_AnswerDivPart.Checked = true;
                uCheckEditor_AnswerDivComplate.Checked = true;
                uCheckEditor_AnswerDivCancel.Checked = true;
                // ADD 2009/09/10 画面レイアウト変更および初期表示内容の変更 ----------<<<<<
            }

            // 問合せ日
            tde_InquiryDateSt.SetDateTime(DateTime.Today);
            tde_InquiryDateEd.SetDateTime(DateTime.Today);

            // 拠点
            if (this._mode == Mode.Popup)
            {
                // ログイン拠点を設定
                this.tEdit_SectionCodeAllowZero.Text = this._sectionCode;
                this.uLabel_SectionName.Text = this.GetSectionName(this._sectionCode);
            }
            else if (this._mode == Mode.SalesSlip)
            {
                this.tEdit_SectionCodeAllowZero.Text = this._defaultSectionCd;
                this.uLabel_SectionName.Text = DefaultSectionName;
            }
            else
            {
                // DEL 2009/09/10 画面レイアウト変更および初期表示内容の変更 ---------->>>>>
                //this.tEdit_SectionCodeAllowZero.Text = string.Empty;
                //this.uLabel_SectionName.Text = string.Empty;
                // DEL 2009/09/10 画面レイアウト変更および初期表示内容の変更 ----------<<<<<
                // ADD 2009/09/10 画面レイアウト変更および初期表示内容の変更 ---------->>>>>
                this.tEdit_SectionCodeAllowZero.Text = this._sectionCode;
                this.uLabel_SectionName.Text = this.GetSectionName(this._sectionCode);
                // ADD 2009/09/10 画面レイアウト変更および初期表示内容の変更 ----------<<<<<
            }

            // 得意先
            if (this._mode == Mode.SalesSlip)
            {
                this.tNedit_CustomerCode_St.SetInt(this._defaultCustomerCode);
                this.tNedit_CustomerCode_Ed.SetInt(this._defaultCustomerCode);
            }
            else
            {
                this.tNedit_CustomerCode_St.SetInt(0);
                this.tNedit_CustomerCode_Ed.SetInt(0);
            }

            // 回答方法
            this.uCheckEditor_AnswerMethodAll.Checked = true; // 全て
            this.uCheckEditor_AnswerMethodAuto.Checked = false; // 自動
            this.uCheckEditor_AnswerMethodManual.Checked = false; // 手動

            // 伝票番号(受注ステータス)
            this.uCheckEditor_AcptAnOdrStatusAll.Checked = true; // 全て
            this.uCheckEditor_AcptAnOdrStatusSales.Checked = false; // 売上
            this.uCheckEditor_AcptAnOdrStatusAccept.Checked = false; // 受注
            this.uCheckEditor_AcptAnOdrStatusEstimate.Checked = false; // 見積

            // 伝票番号
            this.tEdit_SalesSlipNum_St.Text = string.Empty;
            this.tEdit_SalesSlipNum_Ed.Text = string.Empty;

            // 問合せ番号(問合せ・発注種別)
            this.uCheckEditor_InqOrdDivAll.Checked = true; // 全て
            this.uCheckEditor_InqOrdDivAccept.Checked = false; // 受注
            this.uCheckEditor_InqOrdDivEstimate.Checked = false; // 見積

            // 問合せ番号
            this.tNedit_InquiryNumber_St.SetInt(0);
            this.tNedit_InquiryNumber_Ed.SetInt(0);

            // 手動回答件数、自動回答件数
            this.uLabel_AutoNum.Text = string.Empty;
            this.uLabel_ManualNum.Text = string.Empty;
            // ---- ADD gezh 2011/11/12 ---------->>>>>
            //連携対象区分
            this.uCheckEditor_CooperationOptionDivAll.Checked = true; // 全て
            this.uCheckEditor_CooperationOptionDivPcc.Checked = false; // PCCforNS
            this.uCheckEditor_CooperationOptionDivBL.Checked = false; // BLﾊﾟｰﾂｵｰﾀﾞｰ分
            // ---- ADD gezh 2011/11/12 ----------<<<<<
            
            // ADD 2013/05/09 SCM障害№10384対応 ----------------------------------->>>>>
            // 入庫予定日
            this.tde_ExpectedCeDateSt.SetDateTime(DateTime.MinValue);
            this.tde_ExpectedCeDateEd.SetDateTime(DateTime.MinValue);
            // ADD 2013/05/09 SCM障害№10384対応 -----------------------------------<<<<<
        }

        /// <summary>
        /// グリッド設定
        /// </summary>
        private void SetGridSetting()
        {
            // データソース設定
            this.uGrid_Details.DataSource = this._scmInquiryOrderAcs.SCMInquiryResultDataTable;

            // 外観表示設定
            this.uGrid_Details.BeginUpdate();

            try
            {
                ColumnsCollection columns = this.uGrid_Details.DisplayLayout.Bands[0].Columns;

                foreach (UltraGridColumn col in columns)
                {
                    // 全列共通設定
                    // 表示位置(vertical)
                    col.CellAppearance.TextVAlign = VAlign.Middle;

                    // クリック時は行セレクト
                    col.CellClickAction = CellClickAction.RowSelect;

                    // 編集不可
                    col.CellActivation = Activation.Disabled;

                    // 全ての列をいったん非表示にする。
                    col.Hidden = true;
                }

                SCMAcOdrDataDataSet.SCMInquiryResultDataTable table = this._scmInquiryOrderAcs.SCMInquiryResultDataTable;

                // 固定列設定(行番号列のみ)
                columns[table.RowNumberColumn.ColumnName].Header.Fixed = true;
                
                // 行番号列のセル表示色変更
                columns[table.RowNumberColumn.ColumnName].CellAppearance.BackColorDisabled = Color.FromArgb(89, 135, 214);
                columns[table.RowNumberColumn.ColumnName].CellAppearance.BackColorDisabled2 = Color.FromArgb(7, 59, 150);
                columns[table.RowNumberColumn.ColumnName].CellAppearance.BackGradientStyle = GradientStyle.Vertical;
                columns[table.RowNumberColumn.ColumnName].CellAppearance.ForeColor = Color.White;
                columns[table.RowNumberColumn.ColumnName].CellAppearance.ForeColorDisabled = Color.White;

                int visiblePosition = 0;

                #region 各カラム設定
                // No.列
                columns[table.RowNumberColumn.ColumnName].Hidden = false; // 表示設定
                columns[table.RowNumberColumn.ColumnName].Header.Caption = "No."; // 列キャプション
                columns[table.RowNumberColumn.ColumnName].Width = 50; // 表示幅
                columns[table.RowNumberColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right;// 表示位置
                columns[table.RowNumberColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                // ADD 2010/04/16 キャンセル対応 ---------->>>>>
                // 回答区分列
                columns[table.AnswerDivCdNameColumn.ColumnName].Hidden = false;             // 表示設定
                columns[table.AnswerDivCdNameColumn.ColumnName].Header.Caption = "回答区分";// 列キャプション
                columns[table.AnswerDivCdNameColumn.ColumnName].Width = 70;                 // 表示幅
                columns[table.AnswerDivCdNameColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;// 表示位置
                columns[table.AnswerDivCdNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
                // ADD 2010/04/16 キャンセル対応 ----------<<<<<

                // 回答列
                columns[table.AnswerMethodNmColumn.ColumnName].Hidden = false; // 表示設定
                columns[table.AnswerMethodNmColumn.ColumnName].Header.Caption = "回答"; // 列キャプション
                columns[table.AnswerMethodNmColumn.ColumnName].Width = 70; // 表示幅
                columns[table.AnswerMethodNmColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;// 表示位置
                columns[table.AnswerMethodNmColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                // 回答時刻列
                columns[table.UpdateDateTimeForDispColumn.ColumnName].Hidden = false; // 表示設定
                columns[table.UpdateDateTimeForDispColumn.ColumnName].Header.Caption = "回答時刻"; // 列キャプション
                columns[table.UpdateDateTimeForDispColumn.ColumnName].Width = 200; // 表示幅
                columns[table.UpdateDateTimeForDispColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;// 表示位置
                columns[table.UpdateDateTimeForDispColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                // 問合せ・発注区分列
                columns[table.InqOrdDivNameColumn.ColumnName].Hidden = false; // 表示設定
                columns[table.InqOrdDivNameColumn.ColumnName].Header.Caption = "問合せ・発注区分"; // 列キャプション
                columns[table.InqOrdDivNameColumn.ColumnName].Width = 70; // 表示幅
                columns[table.InqOrdDivNameColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;// 表示位置
                columns[table.InqOrdDivNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                // 問合せ番号列
                columns[table.InquiryNumberColumn.ColumnName].Hidden = false; // 表示設定
                columns[table.InquiryNumberColumn.ColumnName].Header.Caption = "問合せ番号"; // 列キャプション
                columns[table.InquiryNumberColumn.ColumnName].Width = 100; // 表示幅
                columns[table.InquiryNumberColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right;// 表示位置
                columns[table.InquiryNumberColumn.ColumnName].Format = "0000000000";// 表示位置
                columns[table.InquiryNumberColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                // 問合せ日列
                columns[table.FormatedInquiryDateColumn.ColumnName].Hidden = false; // 表示設定
                columns[table.FormatedInquiryDateColumn.ColumnName].Header.Caption = "問合せ日"; // 列キャプション
                columns[table.FormatedInquiryDateColumn.ColumnName].Width = 100; // 表示幅
                columns[table.FormatedInquiryDateColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;// 表示位置
                columns[table.FormatedInquiryDateColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                // --- ADD m.suzuki 2011/06/13 ---------->>>>>
                // 更新日
                columns[table.UpdateDateColumn.ColumnName].Hidden = false; // 表示設定
                columns[table.UpdateDateColumn.ColumnName].Header.Caption = "更新日"; // 列キャプション
                columns[table.UpdateDateColumn.ColumnName].Width = 150; // 表示幅
                columns[table.UpdateDateColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;// 表示位置
                columns[table.UpdateDateColumn.ColumnName].Format = "yyyy/MM/dd";
                columns[table.UpdateDateColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
                // --- ADD m.suzuki 2011/06/13 ----------<<<<<

                // 得意先列
                columns[table.CustomerNameColumn.ColumnName].Hidden = false; // 表示設定
                columns[table.CustomerNameColumn.ColumnName].Header.Caption = "得意先"; // 列キャプション
                columns[table.CustomerNameColumn.ColumnName].Width = 150; // 表示幅
                columns[table.CustomerNameColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;// 表示位置
                columns[table.CustomerNameColumn.ColumnName].Format = "00000000";// 表示位置
                columns[table.CustomerNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                // 担当者列
                columns[table.AnsEmployeeNmColumn.ColumnName].Hidden = false; // 表示設定
                columns[table.AnsEmployeeNmColumn.ColumnName].Header.Caption = "担当者"; // 列キャプション
                columns[table.AnsEmployeeNmColumn.ColumnName].Width = 150; // 表示幅
                columns[table.AnsEmployeeNmColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;// 表示位置
                columns[table.AnsEmployeeNmColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                // 伝票区分列
                // DEL 2010/04/16 レイアウト変更(伝票番号、伝票区分、受注ステータスを撤去) ---------->>>>>
                //columns[table.AcptAnOdrStatusNmColumn.ColumnName].Hidden = false; // 表示設定
                // DEL 2010/04/16 レイアウト変更(伝票番号、伝票区分、受注ステータスを撤去) ----------<<<<<
                // ADD 2010/04/16 レイアウト変更(伝票番号、伝票区分、受注ステータスを撤去) ---------->>>>>
                columns[table.AcptAnOdrStatusNmColumn.ColumnName].Hidden = true; // 表示設定
                // ADD 2010/04/16 レイアウト変更(伝票番号、伝票区分、受注ステータスを撤去) ----------<<<<<
                columns[table.AcptAnOdrStatusNmColumn.ColumnName].Header.Caption = "伝票区分"; // 列キャプション
                columns[table.AcptAnOdrStatusNmColumn.ColumnName].Width = 100; // 表示幅
                columns[table.AcptAnOdrStatusNmColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;// 表示位置
                columns[table.AcptAnOdrStatusNmColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                // 伝票番号列
                // DEL 2010/04/16 レイアウト変更(伝票番号、伝票区分、受注ステータスを撤去) ---------->>>>>
                //columns[table.SalesSlipNumColumn.ColumnName].Hidden = false; // 表示設定
                // DEL 2010/04/16 レイアウト変更(伝票番号、伝票区分、受注ステータスを撤去) ----------<<<<<
                // ADD 2010/04/16 レイアウト変更(伝票番号、伝票区分、受注ステータスを撤去) ---------->>>>>
                columns[table.SalesSlipNumColumn.ColumnName].Hidden = true; // 表示設定
                // ADD 2010/04/16 レイアウト変更(伝票番号、伝票区分、受注ステータスを撤去) ----------<<<<<
                columns[table.SalesSlipNumColumn.ColumnName].Header.Caption = "伝票番号"; // 列キャプション
                columns[table.SalesSlipNumColumn.ColumnName].Width = 150; // 表示幅
                columns[table.SalesSlipNumColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right;// 表示位置
                columns[table.SalesSlipNumColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                // 類別列
                columns[table.ModelCategoryColumn.ColumnName].Hidden = false; // 表示設定
                columns[table.ModelCategoryColumn.ColumnName].Header.Caption = "類別"; // 列キャプション
                columns[table.ModelCategoryColumn.ColumnName].Width = 100; // 表示幅
                columns[table.ModelCategoryColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;// 表示位置
                columns[table.ModelCategoryColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                // 車種列
                columns[table.ModelNameColumn.ColumnName].Hidden = false; // 表示設定
                columns[table.ModelNameColumn.ColumnName].Header.Caption = "車種"; // 列キャプション
                columns[table.ModelNameColumn.ColumnName].Width = 150; // 表示幅
                columns[table.ModelNameColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;// 表示位置
                columns[table.ModelNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                // 型式列
                columns[table.FullModelColumn.ColumnName].Hidden = false; // 表示設定
                columns[table.FullModelColumn.ColumnName].Header.Caption = "型式"; // 列キャプション
                columns[table.FullModelColumn.ColumnName].Width = 100; // 表示幅
                columns[table.FullModelColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;// 表示位置
                columns[table.FullModelColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                // 2011/03/07 Add >>>
                // 型式列
                columns[table.ProduceTypeOfYearStringColumn.ColumnName].Hidden = false; // 表示設定
                columns[table.ProduceTypeOfYearStringColumn.ColumnName].Header.Caption = "年式"; // 列キャプション
                columns[table.ProduceTypeOfYearStringColumn.ColumnName].Width = 100; // 表示幅
                columns[table.ProduceTypeOfYearStringColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;// 表示位置
                columns[table.ProduceTypeOfYearStringColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                // 2011/03/07 Add <<<

                // --- ADD 2012/10/10 三戸 2012/11/14配信分 SCM障害№32 --------->>>>>>>>>>>>>>>>>>>>>>>>
                // 車台番号
                columns[table.FrameNoColumn.ColumnName].Hidden = false; // 表示設定
                columns[table.FrameNoColumn.ColumnName].Header.Caption = "車台番号"; // 列キャプション
                columns[table.FrameNoColumn.ColumnName].Width = 100; // 表示幅
                columns[table.FrameNoColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;// 表示位置
                columns[table.FrameNoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
                // --- ADD 2012/10/10 三戸 2012/11/14配信分 SCM障害№32 ---------<<<<<<<<<<<<<<<<<<<<<<<<

                // プレートNo列
                columns[table.PlateNoColumn.ColumnName].Hidden = false; // 表示設定
                columns[table.PlateNoColumn.ColumnName].Header.Caption = "プレートNo"; // 列キャプション
                columns[table.PlateNoColumn.ColumnName].Width = 150; // 表示幅
                columns[table.PlateNoColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right;// 表示位置
                columns[table.PlateNoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
                
                //--- ADD 2011/05/26 --------------------------------------->>>
                //　備考
                columns[table.InqOrdNoteColumn.ColumnName].Hidden = false; // 表示設定
                columns[table.InqOrdNoteColumn.ColumnName].Header.Caption = "備考"; // 列キャプション
                columns[table.InqOrdNoteColumn.ColumnName].Width = 150; // 表示幅
                columns[table.InqOrdNoteColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;// 表示位置
                columns[table.InqOrdNoteColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                //　指示書番号
                columns[table.SfPmCprtInstSlipNoColumn.ColumnName].Hidden = false; // 表示設定
                columns[table.SfPmCprtInstSlipNoColumn.ColumnName].Header.Caption = "指示書番号"; // 列キャプション
                columns[table.SfPmCprtInstSlipNoColumn.ColumnName].Width = 150; // 表示幅
                columns[table.SfPmCprtInstSlipNoColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;// 表示位置
                columns[table.SfPmCprtInstSlipNoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
                //--- ADD 2011/05/26 ---------------------------------------<<<

                //--- ADD  gezh 2011/11/12 --------------------------------------->>>>>
                // 連携対象区分列
                columns[table.CooperationOptionDivColumn.ColumnName].Hidden = false; // 表示設定
                columns[table.CooperationOptionDivColumn.ColumnName].Header.Caption = "連携対象区分"; // 列キャプション
                columns[table.CooperationOptionDivColumn.ColumnName].Width = 150; // 表示幅
                columns[table.CooperationOptionDivColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;// 表示位置
                columns[table.CooperationOptionDivColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
                //--- ADD  gezh 2011/11/12 ---------------------------------------<<<<<

                // ADD 2013/05/09 SCM障害№10384対応 ----------------------------------->>>>>
                // 入庫予定日列
                columns[table.FormatedExpectedCeDateColumn.ColumnName].Hidden = false; // 表示設定
                columns[table.FormatedExpectedCeDateColumn.ColumnName].Header.Caption = "入庫予定日"; // 列キャプション
                columns[table.FormatedExpectedCeDateColumn.ColumnName].Width = 150; // 表示幅
                columns[table.FormatedExpectedCeDateColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;// 表示位置
                columns[table.FormatedExpectedCeDateColumn.ColumnName].Format = "yyyy/MM/dd";
                columns[table.FormatedExpectedCeDateColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
                // ADD 2013/05/09 SCM障害№10384対応 -----------------------------------<<<<<
                #endregion
            }
            finally
            {
                this.uGrid_Details.EndUpdate();
            }
        }

        /// <summary>
        /// 拠点名称取得処理
        /// </summary>
        /// <param name="sectionCode"></param>
        /// <returns></returns>
        private string GetSectionName(string sectionCode)
        {
            if (_secInfoSetAcs == null)
            {
                _secInfoSetAcs = new SecInfoSetAcs();
            }
            SecInfoSet sectionInfo;
            int status = this._secInfoSetAcs.Read(out sectionInfo, this._enterpriseCode, sectionCode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                return sectionInfo.SectionGuideNm;
            }
            else
            {
                return string.Empty;
            }
        }
        #endregion

        #region XML操作
        /// <summary>
        /// ＸＭＬデータの読込処理
        /// </summary>
        private void LoadStateXmlData()
        {
            // ADD 2010/04/16 レイアウト変更(伝票番号、伝票区分、受注ステータスを撤去) ---------->>>>>
            // グリッドのレイアウト変更を 2010/04/16 に実施したので、それより以前の保持データを無効にする
            string savedDataPathName = Path.Combine(".", _gridStateController.GetGridInfoPath(XML_FILE_INITIAL_DATA));
            if (File.Exists(savedDataPathName))
            {
                if (File.GetCreationTime(savedDataPathName) < new DateTime(2010, 4, 16))
                {
                    File.Delete(savedDataPathName);
                    return;
                }
            }
            // ADD 2010/04/16 レイアウト変更(伝票番号、伝票区分、受注ステータスを撤去) ----------<<<<<

            int status = this._gridStateController.LoadGridState(XML_FILE_INITIAL_DATA, ref this.uGrid_Details);

            // --- ADD 2012/10/10 三戸 2012/11/14配信分 SCM障害№32 --------->>>>>>>>>>>>>>>>>>>>>>>>
            // 車台番号
            ColumnsCollection columns = this.uGrid_Details.DisplayLayout.Bands[0].Columns;
            SCMAcOdrDataDataSet.SCMInquiryResultDataTable table = this._scmInquiryOrderAcs.SCMInquiryResultDataTable;
            columns[table.FrameNoColumn.ColumnName].Hidden = false; // 表示設定
            // --- ADD 2012/10/10 三戸 2012/11/14配信分 SCM障害№32 ---------<<<<<<<<<<<<<<<<<<<<<<<<
        }

        /// <summary>
        /// ＸＭＬデータの保存処理
        /// </summary>
        public void SaveStateXmlData()
        {
            // グリッド情報を保存
            this._gridStateController.SaveGridState(XML_FILE_INITIAL_DATA, ref this.uGrid_Details);
        }
        #endregion

        #region 確定処理
        /// <summary>
        /// TODO:確定処理
        /// </summary>
        // 2010/05/27 >>>
        //private void ReturnSalesSlipInput()
        private bool ReturnSalesSlipInput()
        // 2010/05/27 <<<
        {
            if (this.uGrid_Details.ActiveRow == null)
            {
                // 選択行がない場合はなにもしない
                // 2010/05/27 >>>
                //return;
                return true;
                // 2010/05/27 <<<
            }

            string sectionCd = this.uGrid_Details.
                Rows[this.uGrid_Details.ActiveRow.Index].
                Cells[this._scmInquiryOrderAcs.SCMInquiryResultDataTable.InqOtherSecCdColumn.ColumnName].Value.ToString();

            if (this.CheckLegarySystemSection(sectionCd))
            {
                // 旧システム連携拠点は売上伝票入力に戻さない
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "選択行はPM.NS環境のデータではないため、売上伝票入力はできません",
                    0,
                    MessageBoxButtons.OK);

                // 2010/05/27 >>>
                //return;
                return false;
                // 2010/05/27 <<<
            }

            // 戻り値の設定
            this._retInquiryNum = (Int64)this.uGrid_Details.ActiveRow.Cells[
                                        this._scmInquiryOrderAcs.SCMInquiryResultDataTable.InquiryNumberColumn.ColumnName].Value;
            this._retAcptAnOdrStatus = (Int32)this.uGrid_Details.ActiveRow.Cells[
                                        this._scmInquiryOrderAcs.SCMInquiryResultDataTable.AcptAnOdrStatusColumn.ColumnName].Value;
            this._retSalesSlipNum = this.uGrid_Details.ActiveRow.Cells[
                                        this._scmInquiryOrderAcs.SCMInquiryResultDataTable.SalesSlipNumColumn.ColumnName].Value.ToString();
            // -- ADD 2010/03/02 ----------------->>>
            this._inqOriginalEpCd = this.uGrid_Details.ActiveRow.Cells[
                                        this._scmInquiryOrderAcs.SCMInquiryResultDataTable.InqOriginalEpCdColumn.ColumnName].Value.ToString().Trim();//@@@@20230303
            this._inqOriginalSecCd = this.uGrid_Details.ActiveRow.Cells[
                                        this._scmInquiryOrderAcs.SCMInquiryResultDataTable.InqOriginalSecCdColumn.ColumnName].Value.ToString();
            // -- ADD 2010/03/02 -----------------<<<
            // 2011/01/24 Add >>>
            this._inqOrdDivCd = (int)this.uGrid_Details.ActiveRow.Cells[
                                        this._scmInquiryOrderAcs.SCMInquiryResultDataTable.InqOrdDivCdColumn.ColumnName].Value;
            // 2011/01/24 Add <<<
            // ADD 2010/03/31 検索条件に一部回答を含む場合、未回答の明細データが表示されない ---------->>>>>
            // 売上伝票番号
            this._retSalesSlipNum = GetSelectedSalesSlipNumIf();
            // ADD 2010/03/31 検索条件に一部回答を含む場合、未回答の明細データが表示されない ----------<<<<<
            // ADD 2010/04/16 キャンセル対応 ---------->>>>>
            // 回答区分
            AnswerDivCode = int.Parse(this.uGrid_Details.ActiveRow.Cells[
                this._scmInquiryOrderAcs.SCMInquiryResultDataTable.AnswerDivCdColumn.ColumnName
            ].Value.ToString());

            // 回答区分が｢回答完了｣の場合、何もしない
            if (AnswerDivCode.Equals((int)AnswerDivCd.AnswerCompletion))
            {
                Debug.WriteLine("回答完了のため、売伝に戻りません。");
                // 2010/05/27 >>>
                //return;
                return false;
                // 2010/05/27 <<<
            }

            // FIXME:全ての明細がキャンセルまたは返品されている場合、メッセージ出力
            // 2011/02/14 >>>
            //if (!_scmInquiryOrderAcs.CanInputSalesSlip(_retInquiryNum, AnswerDivCode))

            Guid dtlGuid = (Guid)this.uGrid_Details.ActiveRow.Cells[this._scmInquiryOrderAcs.SCMInquiryResultDataTable.DetailGuidColumn.ColumnName].Value;
            if (!_scmInquiryOrderAcs.CanInputSalesSlip(dtlGuid))
            // 2011/02/14 <<<
            {
                // 2011/02/17 >>>
                //MessageBox.Show("全てキャンセルされています。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                MessageBox.Show("全て処理済みです。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                // 2011/02/17 <<<
                // 2010/05/27 >>>
                //return;
                return false;
                // 2010/05/27 <<<
            }

            // 2010/05/27 Add >>>
            // キャンセル且つ未回答データが含まれるデータを選択した場合は、
            // ユーザーにキャンセルを受け付けるか確認する
            if (AnswerDivCode.Equals((int)AnswerDivCd.Cancel))
            {
                // DEL 2010/06/17 キャンセル追加対応 ---------->>>>>
                //int returnCheckResult = this.ReturnCheck(this.uGrid_Details.ActiveRow.Index, true);
                // DEL 2010/06/17 キャンセル追加対応 ----------<<<<<
                // ADD 2010/06/17 キャンセル追加対応 ---------->>>>>
                int returnCheckResult = this.ReturnCheck(this.uGrid_Details.ActiveRow.Index, true, AnswerDivCode);
                // ADD 2010/06/17 キャンセル追加対応 ----------<<<<<

                // 戻り値 = 1 は、キャンセル拒否したので再検索
                if (returnCheckResult == 1)
                {
                    this.ExecuteSearch(false);
                }
                if (returnCheckResult != 0) return false;
            }
            // 2010/05/27 Add <<<

            // ADD 2010/06/17 キャンセル追加対応 ---------->>>>>
            // FIXME:回答区分が「未回答」の場合、キャンセルデータのチェック処理を行う
            if (AnswerDivCode.Equals((int)AnswerDivCd.NoAction))
            {
                int returnCheckResult = this.ReturnCheck(this.uGrid_Details.ActiveRow.Index, true, AnswerDivCode);

                // 戻り値 = 1 は、売伝に戻る必要がないので、再検索
                if (returnCheckResult == 1)
                {
                    this.ExecuteSearch(false);
                }
                if (returnCheckResult != 0) return false;
            }
            // ADD 2010/06/17 キャンセル追加対応 ----------<<<<<

        #if DEBUG
            //const string FORMAT = "売伝へ戻ります。問合せ番号[{0}] : 回答区分={1}, 売上伝票番号={2}, 受注ステータス={3}";
            //Debug.WriteLine(string.Format(FORMAT, _retInquiryNum, AnswerDivCode, _retSalesSlipNum, _retAcptAnOdrStatus));
            //MessageBox.Show(string.Format(FORMAT, _retInquiryNum, AnswerDivCode, _retSalesSlipNum, _retAcptAnOdrStatus));
        #endif

            // --- ADD 2014/09/22 chenyd For PM-SCM仕掛一覧No.10661とNo.85対応 ---------------------->>>>>
            // 問合せ番号取得
            long inqNumber = 0;
            long.TryParse(this._retInquiryNum.ToString(), out inqNumber);
            // SCM伝票回答の場合、自拠点の端末へ送信
            if (inqNumber != 0)
            {
                this.NotifyPmByPublish(inqNumber);
            }
            // --- ADD 2014/09/22 chenyd For PM-SCM仕掛一覧No.10661とNo.85対応 ------------------------<<<<<

            // 売上伝票からの起動ではない場合、フォームを閉じない
            if (this._mode != Mode.SalesSlip)
            {
                // 2010/05/27 >>>
                //return;
                return true;
                // 2010/05/27 <<<
            }
            // ADD 2010/04/16 キャンセル対応 ----------<<<<<

            this._dialogResult = DialogResult.OK;

            this.Close();

            return true;    // 2010/05/27 Add
        }

        // ADD 2010/03/31 検索条件に一部回答を含む場合、未回答の明細データが表示されない ---------->>>>>
        /// <summary>
        /// 選択しているSCM受注データの売上伝票番号を取得します。（回答区分が｢一部回答｣の場合、"000000000"を返します。）
        /// </summary>
        /// <returns>SCM受注データ.売上伝票番号</returns>
        private string GetSelectedSalesSlipNumIf()
        {
            // 選択しているSCM受注データグリッド行から回答区分を取得
            int answerDivCd = (int)this.uGrid_Details.ActiveRow.Cells[
                this._scmInquiryOrderAcs.SCMInquiryResultDataTable.AnswerDivCdColumn.ColumnName
            ].Value;

            // 選択しているSCM受注データの売上伝票番号
            string salesSlipNum = this.uGrid_Details.ActiveRow.Cells[
                this._scmInquiryOrderAcs.SCMInquiryResultDataTable.SalesSlipNumColumn.ColumnName
            ].Value.ToString();

            // UPD 2013/03/29 SCM障害№10503対応 ------------------------------------>>>>>
            //// 回答区分が｢一部回答｣の場合、"000000000"を返す
            //return SCMInquiryOrderAcs.IsPartAnswer(answerDivCd) ? SCMInquiryOrderAcs.NullSalesSlipNum : salesSlipNum;
            // 回答区分が「キャンセル」または「一部回答」の時、"000000000"を返す
            // 一部回答の場合
            if (SCMInquiryOrderAcs.IsPartAnswer(answerDivCd) || SCMInquiryOrderAcs.IsCancelAnswer(answerDivCd))
            {
                return SCMInquiryOrderAcs.NullSalesSlipNum;
            }
            else
            {
                return salesSlipNum;
            }
            // UPD 2013/03/29 SCM障害№10503対応 ------------------------------------<<<<<
        }
        // ADD 2010/03/31 検索条件に一部回答を含む場合、未回答の明細データが表示されない ----------<<<<<

        #endregion

        #region 検索処理

        /// <summary>
        /// 検索処理
        /// </summary>
        private void Search()
        {
            if (this.SeachBeforeCheck())
            {
                //this.ExecuteSearch();
                this.ExecuteSearch(false); // 2010/03/10
            }
        }

        //>>>2010/03/10
        /// <summary>
        /// 検索処理
        /// </summary>
        private void Search(bool firstflg)
        {
            if (this.SeachBeforeCheck())
            {
                this.ExecuteSearch(firstflg);
            }
        }
        //<<<2010/03/10

        /// <summary>
        /// 検索前確認処理
        /// </summary>
        /// <returns>status</returns>
        private bool SeachBeforeCheck()
        {
            bool status = true;

            string errMessage = "";
            Control errComponent = null;

            if (!this.ScreenInputCheck(ref errMessage, ref errComponent))
            {
                // メッセージを表示
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    errMessage,
                    0,
                    MessageBoxButtons.OK);

                // コントロールにフォーカスをセット
                if (errComponent != null)
                {
                    errComponent.Focus();
                }

                status = false;
            }

            return status;
        }

        /// <summary>
        /// 画面入力チェック
        /// </summary>
        /// <param name="errMessage"></param>
        /// <param name="errComponent"></param>
        /// <returns></returns>
        private bool ScreenInputCheck(ref string errMessage, ref Control errComponent)
        {
            // 回答区分
            if (this.uCheckEditor_AnswerDivNon.Checked == false
                && this.uCheckEditor_AnswerDivPart.Checked == false
                && this.uCheckEditor_AnswerDivComplate.Checked == false
                && this.uCheckEditor_AnswerDivCancel.Checked == false)
            {
                errMessage = "回答区分を選択してください。";
                errComponent = this.uCheckEditor_AnswerDivNon;
                return false;
            }

            // 問合せ日
            DateGetAcs.CheckDateResult cdResult;

            if (tde_InquiryDateSt.GetLongDate() != 0)
            {
                cdResult = this._dateGet.CheckDate(ref tde_InquiryDateSt, true);
                if (cdResult == DateGetAcs.CheckDateResult.ErrorOfInvalid)
                {
                    // --- UPD m.suzuki 2011/06/13 ---------->>>>>
                    //errMessage = string.Format("開始問合せ日{0}", ct_InputError);
                    errMessage = string.Format( "開始更新日{0}", ct_InputError );
                    // --- UPD m.suzuki 2011/06/13 ----------<<<<<
                    errComponent = this.tde_InquiryDateSt;
                    return false;
                }
            }

            if (tde_InquiryDateEd.GetLongDate() != 0)
            {
                cdResult = this._dateGet.CheckDate(ref tde_InquiryDateEd, true);
                if (cdResult == DateGetAcs.CheckDateResult.ErrorOfInvalid)
                {
                    // --- UPD m.suzuki 2011/06/13 ---------->>>>>
                    //errMessage = string.Format("終了問合せ日{0}", ct_InputError);
                    errMessage = string.Format( "終了更新日{0}", ct_InputError );
                    // --- UPD m.suzuki 2011/06/13 ----------<<<<<
                    errComponent = this.tde_InquiryDateEd;
                    return false;
                }
            }

            // 大小チェック
            if (tde_InquiryDateSt.GetLongDate() != 0
                && tde_InquiryDateEd.GetLongDate() != 0)
            {
                if (tde_InquiryDateSt.GetLongDate() > tde_InquiryDateEd.GetLongDate())
                {
                    // --- UPD m.suzuki 2011/06/13 ---------->>>>>
                    //errMessage = string.Format("問合せ日{0}", ct_RangeError);
                    errMessage = string.Format( "更新日{0}", ct_RangeError );
                    // --- UPD m.suzuki 2011/06/13 ----------<<<<<
                    errComponent = this.tde_InquiryDateSt;
                    return false;
                }
            }

            // 拠点の未入力チェック
            if (this.tEdit_SectionCodeAllowZero.Text == string.Empty)
            {
                errMessage = string.Format("拠点{0}", ct_NoInput);
                errComponent = this.tEdit_SectionCodeAllowZero;
                return false;
            }

            // 得意先大小チェック
            if (!this.CheckInputRange(this.tNedit_CustomerCode_St, this.tNedit_CustomerCode_Ed))
            {
                errMessage = string.Format("得意先{0}", ct_RangeError);
                errComponent = this.tNedit_CustomerCode_St;
                return false;
            }

            // 回答方法
            if (!this.uCheckEditor_AnswerMethodAll.Checked
                && !this.uCheckEditor_AnswerMethodAuto.Checked
                && !this.uCheckEditor_AnswerMethodManual.Checked)
            {
                errMessage = "回答方法を選択してください。";
                errComponent = this.uCheckEditor_AnswerMethodAll;
                return false;
            }

            // 伝票番号(受注ステータス)
            if (!this.uCheckEditor_AcptAnOdrStatusAll.Checked
                && !this.uCheckEditor_AcptAnOdrStatusEstimate.Checked
                && !this.uCheckEditor_AcptAnOdrStatusAccept.Checked
                && !this.uCheckEditor_AcptAnOdrStatusSales.Checked)
            {
                errMessage = "受注ステータスを選択してください。";
                errComponent = this.uCheckEditor_AcptAnOdrStatusAll;
                return false;
            }

            // 伝票番号大小チェック
            if (this.tEdit_SalesSlipNum_St.Text != string.Empty
                && this.tEdit_SalesSlipNum_Ed.Text != string.Empty)
            {
                int salesSlipNumSt;
                int salesSlipNumEd;

                Int32.TryParse(this.tEdit_SalesSlipNum_St.Text, out salesSlipNumSt);
                Int32.TryParse(this.tEdit_SalesSlipNum_Ed.Text, out salesSlipNumEd);

                if (salesSlipNumSt > salesSlipNumEd)
                {
                    errMessage = string.Format("伝票番号{0}", ct_RangeError);
                    errComponent = this.tEdit_SalesSlipNum_St;
                    return false;
                }
            }

            // 問合わせ番号(問合せ・発注種別)
            if (!this.uCheckEditor_InqOrdDivAll.Checked
                && !this.uCheckEditor_InqOrdDivEstimate.Checked
                && !this.uCheckEditor_InqOrdDivAccept.Checked)
            {
                errMessage = "問合せ・発注種別を選択してください。";
                errComponent = this.uCheckEditor_InqOrdDivAll;
                return false;
            }

            // 問合せ番号大小チェック
            if (!this.CheckInputRange(this.tNedit_InquiryNumber_St, this.tNedit_InquiryNumber_Ed))
            {
                errMessage = string.Format("問合せ番号{0}", ct_RangeError);
                errComponent = this.tNedit_InquiryNumber_St;
                return false;
            }
            // ----ADD gezh 2011/11/12 -------------------------->>>>>
            // 連携対象区分
            if (!this.uCheckEditor_CooperationOptionDivAll.Checked
                && !this.uCheckEditor_CooperationOptionDivPcc.Checked
                && !this.uCheckEditor_CooperationOptionDivBL.Checked)
            {
                errMessage = "連携対象区分を選択してください。";
                errComponent = this.uCheckEditor_AnswerMethodAll;
                return false;
            }
            // ----ADD gezh 2011/11/12 --------------------------<<<<<

            // ADD 2013/05/09 SCM障害№10384対応 ----------------------------------->>>>>
            // 入庫予定日
            DateGetAcs.CheckDateResult cdResult2;

            if (tde_ExpectedCeDateSt.GetLongDate() != 0)
            {
                cdResult2 = this._dateGet.CheckDate(ref tde_ExpectedCeDateSt, true);
                if (cdResult2 == DateGetAcs.CheckDateResult.ErrorOfInvalid)
                {
                    errMessage = string.Format("開始入庫予定日{0}", ct_InputError);
                    errComponent = this.tde_ExpectedCeDateSt;
                    return false;
                }
            }

            if (tde_ExpectedCeDateEd.GetLongDate() != 0)
            {
                cdResult = this._dateGet.CheckDate(ref tde_ExpectedCeDateEd, true);
                if (cdResult == DateGetAcs.CheckDateResult.ErrorOfInvalid)
                {
                    errMessage = string.Format("終了入庫予定日{0}", ct_InputError);
                    errComponent = this.tde_ExpectedCeDateEd;
                    return false;
                }
            }

            // 大小チェック
            if (tde_ExpectedCeDateSt.GetLongDate() != 0
                && tde_ExpectedCeDateEd.GetLongDate() != 0)
            {
                if (tde_ExpectedCeDateSt.GetLongDate() > tde_ExpectedCeDateEd.GetLongDate())
                {
                    errMessage = string.Format("入庫予定日{0}", ct_RangeError);
                    errComponent = this.tde_ExpectedCeDateSt;
                    return false;
                }
            }
            // ADD 2013/05/09 SCM障害№10384対応 -----------------------------------<<<<<

            return true;
        }

        /// <summary>
        /// 数値項目の大小比較
        /// </summary>
        /// <param name="stEdit"></param>
        /// <param name="edEdit"></param>
        /// <returns></returns>
        private bool CheckInputRange(TNedit stEdit, TNedit edEdit)
        {
            int stCode = stEdit.GetInt();
            int edCode = edEdit.GetInt();

            if (stCode != 0 &&
                 edCode != 0 &&
                 stCode > edCode)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// 検索処理
        /// </summary>
        //private void ExecuteSearch() // 2010/03/10
        private void ExecuteSearch(bool firstflg) // 2010/03/10
        {
            // 画面→抽出条件クラス
            SCMInquiryOrder scmInquiryOrder = this.SetExtraInfoFromScreen();

            string errMsg;
            int status = this._scmInquiryOrderAcs.Search(scmInquiryOrder, out errMsg);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // 自動回答数と手動回答数の取得
                int allRowCount;
                int autoRowCount;
                int manualRowCount;

                this._scmInquiryOrderAcs.GetResultRowCount(out allRowCount, out autoRowCount, out manualRowCount);

                this.uLabel_AutoNum.Text = Convert.ToString(autoRowCount);
                this.uLabel_ManualNum.Text = Convert.ToString(manualRowCount);

                // グリッドフォーカス
                this.uGrid_Details.Rows[0].Activate();
                this.uGrid_Details.Rows[0].Selected = true;

                this._scmInquiryOrderBackup = scmInquiryOrder; // ADD 2013/04/24 qijh #35272
            }
            else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                //>>>2010/03/10
                //// 該当なし
                //TMsgDisp.Show(this, 												// 親ウィンドウフォーム
                //                emErrorLevel.ERR_LEVEL_INFO, 						// エラーレベル
                //                this.Name,											// アセンブリID
                //                errMsg, // 表示するメッセージ
                //                -1,													// ステータス値
                //                MessageBoxButtons.OK);

                if (!firstflg)
                {
                    // 該当なし
                    TMsgDisp.Show(this, 												// 親ウィンドウフォーム
                                    emErrorLevel.ERR_LEVEL_INFO, 						// エラーレベル
                                    this.Name,											// アセンブリID
                                    errMsg, // 表示するメッセージ
                                    -1,													// ステータス値
                                    MessageBoxButtons.OK);
                }
                //<<<2010/03/10
                this.uLabel_AutoNum.Text = string.Empty;
                this.uLabel_ManualNum.Text = string.Empty;
            }
            else
            {
                // エラー
                TMsgDisp.Show(this, 												// 親ウィンドウフォーム
                                emErrorLevel.ERR_LEVEL_STOP, 						// エラーレベル
                                this.Name,											// アセンブリID
                                errMsg, // 表示するメッセージ
                                status,													// ステータス値
                                MessageBoxButtons.OK);

                this.uLabel_AutoNum.Text = string.Empty;
                this.uLabel_ManualNum.Text = string.Empty;
            }
        }

        /// <summary>
        /// 画面情報取得
        /// </summary>
        /// <returns></returns>
        private SCMInquiryOrder SetExtraInfoFromScreen()
        {
            SCMInquiryOrder scmInquiryOrder = new SCMInquiryOrder();

            scmInquiryOrder.EnterpriseCode = this._enterpriseCode; // 共通ヘッダの企業コード

            // 回答区分
            List<Int32> answerDivList = new List<int>();
            if (this.uCheckEditor_AnswerDivNon.Checked)
            {
                answerDivList.Add((int)SCMInquiryOrder.AnswerDivState.Non);
            }
            if (uCheckEditor_AnswerDivPart.Checked)
            {
                answerDivList.Add((int)SCMInquiryOrder.AnswerDivState.Part);
            }
            if (uCheckEditor_AnswerDivComplate.Checked)
            {
                answerDivList.Add((int)SCMInquiryOrder.AnswerDivState.Complete);
            }
            if (uCheckEditor_AnswerDivCancel.Checked)
            {
                answerDivList.Add((int)SCMInquiryOrder.AnswerDivState.Cancel);
            }

            scmInquiryOrder.AnswerDivCd = answerDivList.ToArray();

            scmInquiryOrder.St_InquiryDate = this.tde_InquiryDateSt.GetLongDate(); // 問合せ日(開始)
            scmInquiryOrder.Ed_InquiryDate = this.tde_InquiryDateEd.GetLongDate(); // 問合せ日(終了)

            scmInquiryOrder.InqOtherEpCd = this._enterpriseCode; // 問合せ先企業コード
            scmInquiryOrder.InqOtherSecCd = this.tEdit_SectionCodeAllowZero.DataText; // 問合せ先拠点コード

            scmInquiryOrder.St_CustomerCode = this.tNedit_CustomerCode_St.GetInt(); // 得意先(開始)
            scmInquiryOrder.Ed_CustomerCode = this.tNedit_CustomerCode_Ed.GetInt(); // 得意先(終了)

            // 回答方法
            List<Int32> answerMethodList = new List<int>();
            if (this.uCheckEditor_AnswerMethodAll.Checked)
            {
                answerMethodList.AddRange(new Int32[] {(int)SCMInquiryOrder.AnswerMethodState.Auto ,
                                                        (int)SCMInquiryOrder.AnswerMethodState.ManualWeb ,
                                                        (int)SCMInquiryOrder.AnswerMethodState.ManualOther});
            }
            else
            {
                if (this.uCheckEditor_AnswerMethodAuto.Checked)
                {
                    answerMethodList.Add((int)SCMInquiryOrder.AnswerMethodState.Auto);
                }
                if (this.uCheckEditor_AnswerMethodManual.Checked)
                {
                    answerMethodList.Add((int)SCMInquiryOrder.AnswerMethodState.ManualWeb);
                    answerMethodList.Add((int)SCMInquiryOrder.AnswerMethodState.ManualOther);
                }
            }

            scmInquiryOrder.AwnserMethod = answerMethodList.ToArray();

            // 伝票番号(受注ステータス)
            List<Int32> acptAnOdrStatusList = new List<int>();
            if (this.uCheckEditor_AcptAnOdrStatusAll.Checked)
            {
                acptAnOdrStatusList.AddRange(new Int32[] { (int)SCMInquiryOrder.AcptAnOdrStatusState.NotSet ,
                                                        (int)SCMInquiryOrder.AcptAnOdrStatusState.Estimate ,
                                                        (int)SCMInquiryOrder.AcptAnOdrStatusState.Accept ,
                                                        (int)SCMInquiryOrder.AcptAnOdrStatusState.Sales});
            }
            else
            {
                if (this.uCheckEditor_AcptAnOdrStatusEstimate.Checked)
                {
                    acptAnOdrStatusList.Add((int)SCMInquiryOrder.AcptAnOdrStatusState.Estimate);
                }
                if (this.uCheckEditor_AcptAnOdrStatusAccept.Checked)
                {
                    acptAnOdrStatusList.Add((int)SCMInquiryOrder.AcptAnOdrStatusState.Accept);
                }
                if (this.uCheckEditor_AcptAnOdrStatusSales.Checked)
                {
                    acptAnOdrStatusList.Add((int)SCMInquiryOrder.AcptAnOdrStatusState.Sales);
                }
            }

            scmInquiryOrder.AcptAnOdrStatus = acptAnOdrStatusList.ToArray();

            // 伝票番号
            scmInquiryOrder.St_SalesSlipNum = this.tEdit_SalesSlipNum_St.DataText; // 伝票番号(開始)
            scmInquiryOrder.Ed_SalesSlipNum = this.tEdit_SalesSlipNum_Ed.DataText; // 伝票番号(終了) 

            // 問合せ番号(問合せ・発注種別)
            List<Int32> inqOrdDivList = new List<int>();
            if (this.uCheckEditor_InqOrdDivAll.Checked)
            {
                inqOrdDivList.AddRange(new Int32[] {(int)SCMInquiryOrder.InqOrdDivState.Estimate ,
                                                        (int)SCMInquiryOrder.InqOrdDivState.Accept});
            }
            else
            {
                if (this.uCheckEditor_InqOrdDivEstimate.Checked)
                {
                    inqOrdDivList.Add((int)SCMInquiryOrder.InqOrdDivState.Estimate);
                }
                if (this.uCheckEditor_InqOrdDivAccept.Checked)
                {
                    inqOrdDivList.Add((int)SCMInquiryOrder.InqOrdDivState.Accept);
                }
            }

            scmInquiryOrder.InqOrdDivCd = inqOrdDivList.ToArray();
            
            // 問合せ番号
            scmInquiryOrder.St_InquiryNumber = this.tNedit_InquiryNumber_St.GetInt(); // 問合せ番号(開始)
            scmInquiryOrder.Ed_InquiryNumber = this.tNedit_InquiryNumber_Ed.GetInt(); // 問合せ番号(終了)
            // ------ADD gezh 2011/11/12 -------------------------------------------------------------->>>>>
            // 連携対象区分
            List<Int16> cooperationOptionDivList = new List<Int16>();
            if (this.uCheckEditor_CooperationOptionDivAll.Checked)
            {
                cooperationOptionDivList.AddRange(new Int16[] {(int)SCMInquiryOrder.CooperationOptionDivState.PCCNS ,
                                                        (int)SCMInquiryOrder.CooperationOptionDivState.BL});
            }
            else
            {
                if (this.uCheckEditor_CooperationOptionDivPcc.Checked)
                {
                    cooperationOptionDivList.Add((int)SCMInquiryOrder.CooperationOptionDivState.PCCNS);
                }
                if (this.uCheckEditor_CooperationOptionDivBL.Checked)
                {
                    cooperationOptionDivList.Add((int)SCMInquiryOrder.CooperationOptionDivState.BL);
                }
            }

            scmInquiryOrder.CooperationOptionDiv = cooperationOptionDivList.ToArray();
            // ------ADD gezh 2011/11/12 --------------------------------------------------------------<<<<<
            // ADD 2013/05/09 SCM障害№10384対応 ----------------------------------->>>>>
            scmInquiryOrder.St_ExpectedCeDate = this.tde_ExpectedCeDateSt.GetLongDate();  // 入庫予定日（開始）
            scmInquiryOrder.Ed_ExpectedCeDate = this.tde_ExpectedCeDateEd.GetLongDate();  // 入庫予定日（終了）
            // ADD 2013/05/09 SCM障害№10384対応 -----------------------------------<<<<<
            return scmInquiryOrder;
        }

        /// <summary>
        /// 検索条件取得(売上伝票入力からの該当件数検索用)
        /// </summary>
        /// <returns></returns>
        private SCMInquiryOrder SetExtraInfoFromSalesSlip()
        {
            SCMInquiryOrder scmInquiryOrder = new SCMInquiryOrder();

            scmInquiryOrder.EnterpriseCode = this._enterpriseCode; // 共通ヘッダの企業コード

            // 回答区分「全て」
            List<Int32> answerDivList = new List<int>();
            answerDivList.Add((int)SCMInquiryOrder.AnswerDivState.Non);
            answerDivList.Add((int)SCMInquiryOrder.AnswerDivState.Part);
            answerDivList.Add((int)SCMInquiryOrder.AnswerDivState.Complete);
            answerDivList.Add((int)SCMInquiryOrder.AnswerDivState.Cancel);

            scmInquiryOrder.AnswerDivCd = answerDivList.ToArray();

            // 問合せ拠点
            scmInquiryOrder.InqOtherEpCd = this._enterpriseCode; // 問合せ先企業コード
            scmInquiryOrder.InqOtherSecCd = this._defaultSectionCd; // 問合せ先拠点コード

            // 得意先
            scmInquiryOrder.St_CustomerCode = this._defaultCustomerCode; // 得意先コード
            scmInquiryOrder.Ed_CustomerCode = this._defaultCustomerCode; // 得意先コード

            // 回答方法「全て」
            List<Int32> answerMethodList = new List<Int32>();

            answerMethodList.AddRange(new Int32[] {(int)SCMInquiryOrder.AnswerMethodState.Auto ,
                                                        (int)SCMInquiryOrder.AnswerMethodState.ManualWeb ,
                                                        (int)SCMInquiryOrder.AnswerMethodState.ManualOther});

            scmInquiryOrder.AwnserMethod = answerMethodList.ToArray();


            // 伝票番号(受注ステータス)「全て」
            List<Int32> acptAnOdrStatusList = new List<int>();

            acptAnOdrStatusList.AddRange(new Int32[] {(int)SCMInquiryOrder.AcptAnOdrStatusState.NotSet ,
                                                    (int)SCMInquiryOrder.AcptAnOdrStatusState.Estimate ,
                                                    (int)SCMInquiryOrder.AcptAnOdrStatusState.Accept ,
                                                    (int)SCMInquiryOrder.AcptAnOdrStatusState.Sales});

            scmInquiryOrder.AcptAnOdrStatus = acptAnOdrStatusList.ToArray();

            // 問合せ番号(問合せ・発注種別)「全て」
            List<Int32> inqOrdDivList = new List<int>();

            inqOrdDivList.AddRange(new Int32[] {(int)SCMInquiryOrder.InqOrdDivState.Estimate ,
                                                    (int)SCMInquiryOrder.InqOrdDivState.Accept});

            scmInquiryOrder.InqOrdDivCd = inqOrdDivList.ToArray();


            // 以下設定なし
            // 問合せ日
            scmInquiryOrder.St_InquiryDate = 0;
            scmInquiryOrder.Ed_InquiryDate = 0;
            // 伝票番号
            scmInquiryOrder.St_SalesSlipNum = string.Empty;
            scmInquiryOrder.Ed_SalesSlipNum = string.Empty;
            // 問合せ番号
            scmInquiryOrder.St_InquiryNumber = 0;
            scmInquiryOrder.Ed_InquiryNumber = 0;
            // ------ ADD gezh 2011/11/12 --------------------------------------------------------------------->>>>>
            // 連携対象区分「全て」
            List<Int16> cooperationOptionDivList = new List<Int16>();

            cooperationOptionDivList.AddRange(new Int16[] {(int)SCMInquiryOrder.CooperationOptionDivState.PCCNS ,
                                                        (int)SCMInquiryOrder.CooperationOptionDivState.BL});

            scmInquiryOrder.CooperationOptionDiv = cooperationOptionDivList.ToArray();
            // ------ ADD gezh 2011/11/12 ---------------------------------------------------------------------<<<<<

            return scmInquiryOrder;
        }
        #endregion

        #region 売上伝票入力処理
        // ----------------- ADD 2013/04/24 qijh #35272 --------------- >>>>>
        /// <summary>
        /// 選択された問合せ回答済みかをチェック
        /// </summary>
        /// <returns>true:未回答、false:回答済</returns>
        private bool CheckAnsStatus()
        {
            bool result = true;
            try
            {
                result = CheckAnsStatusProc();
            }
            catch
            {
                result = true;
            }
            return result;
        }

        /// <summary>
        /// 選択された問合せ回答済みかをチェック
        /// </summary>
        /// <returns>true:未回答、false:回答済</returns>
        private bool CheckAnsStatusProc()
        {
            if (this.uGrid_Details.ActiveRow == null || this._scmInquiryOrderBackup == null)
                return true; // 選択されない場合、或いは検索できない場合、本メソッドを無視

            // 問合せ番号取得
            string tempInquiryNumber = this.uGrid_Details.Rows[this.uGrid_Details.ActiveRow.Index].Cells[
                this._scmInquiryOrderAcs.SCMInquiryResultDataTable.InquiryNumberColumn.ColumnName].Value.ToString();
            // ADD 2015/09/16 陳艶丹 For Redmine #47295---------------------->>>>>>
            // 問合せ・発注区分
            int tempInqOrdDivCd = (int)this.uGrid_Details.Rows[this.uGrid_Details.ActiveRow.Index].Cells[
               this._scmInquiryOrderAcs.SCMInquiryResultDataTable.InqOrdDivCdColumn.ColumnName].Value;
            // 回答区分
            int tempAnswerDivCd = (int)this.uGrid_Details.Rows[this.uGrid_Details.ActiveRow.Index].Cells[
               this._scmInquiryOrderAcs.SCMInquiryResultDataTable.AnswerDivCdColumn.ColumnName].Value;
            // ADD 2015/09/16 陳艶丹 For Redmine #47295----------------------<<<<<<

            // 検索処理
            string errMsg;
            int status = this._scmInquiryOrderAcs.Search(this._scmInquiryOrderBackup, out errMsg);

            this.uLabel_AutoNum.Text = string.Empty;
            this.uLabel_ManualNum.Text = string.Empty;

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // 自動回答数と手動回答数の取得
                int allRowCount;
                int autoRowCount;
                int manualRowCount;
                this._scmInquiryOrderAcs.GetResultRowCount(out allRowCount, out autoRowCount, out manualRowCount);

                this.uLabel_AutoNum.Text = Convert.ToString(autoRowCount);
                this.uLabel_ManualNum.Text = Convert.ToString(manualRowCount);

                foreach (UltraGridRow row in this.uGrid_Details.Rows)
                {
                    // 前回選択された問合せを探す
                    //if (row.Cells[this._scmInquiryOrderAcs.SCMInquiryResultDataTable.InquiryNumberColumn.ColumnName].Value.ToString().Equals(tempInquiryNumber))// DEL 2015/09/16 陳艶丹 For Redmine #47295
                    // ADD 2015/09/16 陳艶丹 For Redmine #47295---------------------->>>>>>
                    if (row.Cells[this._scmInquiryOrderAcs.SCMInquiryResultDataTable.InquiryNumberColumn.ColumnName].Value.ToString().Equals(tempInquiryNumber)
                        && (int)row.Cells[this._scmInquiryOrderAcs.SCMInquiryResultDataTable.InqOrdDivCdColumn.ColumnName].Value == tempInqOrdDivCd
                        && (int)row.Cells[this._scmInquiryOrderAcs.SCMInquiryResultDataTable.AnswerDivCdColumn.ColumnName].Value == tempAnswerDivCd)
                    // ADD 2015/09/16 陳艶丹 For Redmine #47295----------------------<<<<<<
                    {
                        row.Activate();
                        row.Selected = true;

                        if (!"回答完了".Equals(row.Cells[this._scmInquiryOrderAcs.SCMInquiryResultDataTable.AnswerDivCdNameColumn.ColumnName].Value.ToString()))
                        {
                            // 「回答完了」以外の場合
                            return true;
                        }
                        else
                        {
                            // 「回答完了」の場合
                            TMsgDisp.Show(
                                       this,
                                       emErrorLevel.ERR_LEVEL_INFO,
                                       this.Name,
                                       "すでに回答が完了しています",
                                       0,
                                       MessageBoxButtons.OK);

                            return false;
                        }
                    }
                }

                // 前回選択された問合せが見つからなければ
                this.uGrid_Details.Rows[0].Activate();
                this.uGrid_Details.Rows[0].Selected = true;
            }

            // 当該問合せデータがなくなる
            TMsgDisp.Show(
                       this,
                       emErrorLevel.ERR_LEVEL_INFO,
                       this.Name,
                       "当該データがもう存在しませんでした",
                       0,
                       MessageBoxButtons.OK);

            return false;
        }
        // ----------------- ADD 2013/04/24 qijh #35272 --------------- <<<<<

        /// <summary>
        /// TODO:売上伝票入力画面起動
        /// </summary>
        /// <br>Update Note: 2011/09/16 鄧潘ハン　PM側　問合せ一覧→売上入力の修正</br>
        private void DispSalesSlipInput()
        {
//#if DEBUG
//            string programPath = Path.Combine(Directory.GetCurrentDirectory(), SALESSLIPINPUT_EXE_NAME);
//            if (!File.Exists(programPath)) return;

//            // ログインパラメータ情報を設定
//            // ポップアップからの起動の場合、引数が追加されているので使用しない。
//            StringBuilder loginArguments = new StringBuilder();
//            {
//                for (int i = 0; i < this._commandLineArgs.Length && i < 2; i++)
//                {
//                    string argument = this._commandLineArgs[i];

//                    if (!string.IsNullOrEmpty(argument.Trim()))
//                    {
//                        loginArguments.Append(argument + " ");
//                    }
//                }
//            }

//            // 問合せ番号を追加
//            loginArguments.Append("1000000036" + " ");

//            // 受注ステータスを追加
//            loginArguments.Append("0" + " ");

//            // 伝票番号を追加
//            loginArguments.Append("000000000" + " ");
//#else
            if (this.uGrid_Details.ActiveRow == null)
            {
                return;
            }

            string sectionCd = this.uGrid_Details.
                Rows[this.uGrid_Details.ActiveRow.Index].
                Cells[this._scmInquiryOrderAcs.SCMInquiryResultDataTable.InqOtherSecCdColumn.ColumnName].Value.ToString();

            if (this.CheckLegarySystemSection(sectionCd))
            {
                // 旧システム連携拠点は売上伝票入力に戻さない
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "選択行はPM.NS環境のデータではないため、売上伝票入力はできません",
                    0,
                    MessageBoxButtons.OK);

                return;
            }

            string programPath = Path.Combine(Directory.GetCurrentDirectory(), SALESSLIPINPUT_EXE_NAME);
            if (!File.Exists(programPath)) return;

            // ログインパラメータ情報を設定
            // ポップアップからの起動の場合、引数が追加されているので使用しない。
            StringBuilder loginArguments = new StringBuilder();
            {
                for (int i = 0; i < this._commandLineArgs.Length && i < 2; i++)
                {
                    string argument = this._commandLineArgs[i];

                    if (!string.IsNullOrEmpty(argument.Trim()))
                    {
                        loginArguments.Append(argument + " ");
                    }
                }
            }

            // 2010/05/27 >>>
            //// ADD 2010/04/16 キャンセル対応 ---------->>>>>
            //// 確定処理を実行
            //ReturnSalesSlipInput();
            //// ADD 2010/04/16 キャンセル対応 ----------<<<<<


            // 確定処理を実行（戻り値=falseの場合はEXE起動しない）
            if (!ReturnSalesSlipInput()) return;
            // 2010/05/27 <<<

            // -- ADD 2010/03/02 ------------------>>>
            //// 問合せ番号を追加
            //loginArguments.Append(this.uGrid_Details.ActiveRow.Cells[
            //                            this._scmInquiryOrderAcs.SCMInquiryResultDataTable.InquiryNumberColumn.ColumnName].Value.ToString() + " ");

            //// 受注ステータスを追加
            //loginArguments.Append(this.uGrid_Details.ActiveRow.Cells[
            //                            this._scmInquiryOrderAcs.SCMInquiryResultDataTable.AcptAnOdrStatusColumn.ColumnName].Value.ToString() + " ");

            //// 伝票番号を追加
            //loginArguments.Append(this.uGrid_Details.ActiveRow.Cells[
            //                            this._scmInquiryOrderAcs.SCMInquiryResultDataTable.SalesSlipNumColumn.ColumnName].Value.ToString() + " ");

            //売伝起動モード
            loginArguments.Append("/INQ ");

            // 問合せ番号を追加
            loginArguments.Append(this.uGrid_Details.ActiveRow.Cells[
                                        this._scmInquiryOrderAcs.SCMInquiryResultDataTable.InquiryNumberColumn.ColumnName].Value.ToString() + ",");

            // 受注ステータスを追加
            loginArguments.Append(this.uGrid_Details.ActiveRow.Cells[
                                        this._scmInquiryOrderAcs.SCMInquiryResultDataTable.AcptAnOdrStatusColumn.ColumnName].Value.ToString() + ",");
            
            // 伝票番号を追加
            // DEL 2010/04/16 キャンセル対応 ---------->>>>>
            //loginArguments.Append(this.uGrid_Details.ActiveRow.Cells[
            //                            this._scmInquiryOrderAcs.SCMInquiryResultDataTable.SalesSlipNumColumn.ColumnName].Value.ToString() + ",");
            // DEL 2010/04/16 キャンセル対応 ----------<<<<<
            // ADD 2010/04/16 キャンセル対応 ---------->>>>>
            loginArguments.Append(this._retSalesSlipNum).Append(",");
            // ADD 2010/04/16 キャンセル対応 ----------<<<<<

            // 問合せ元企業コードを追加
            loginArguments.Append(this.uGrid_Details.ActiveRow.Cells[
                                        this._scmInquiryOrderAcs.SCMInquiryResultDataTable.InqOriginalEpCdColumn.ColumnName].Value.ToString().Trim() + ",");//@@@@20230303_

            //---UPD 2011/09/16 -------------------------------------->>>>>
            // 問合せ元拠点コードを追加
            loginArguments.Append(this.uGrid_Details.ActiveRow.Cells[
                                        //this._scmInquiryOrderAcs.SCMInquiryResultDataTable.InqOriginalSecCdColumn.ColumnName].Value.ToString() + ""); // DEL 2011/09/16
                                        this._scmInquiryOrderAcs.SCMInquiryResultDataTable.InqOriginalSecCdColumn.ColumnName].Value.ToString().TrimEnd() + "");
            //---UPD 2011/09/16 --------------------------------------<<<<<
            // -- ADD 2010/03/02 ------------------<<<

            // ADD 2010/04/16 キャンセル対応 ---------->>>>>
            // 問合せ・発注種別を追加
            loginArguments.Append(",").Append(this.uGrid_Details.ActiveRow.Cells[
                                        this._scmInquiryOrderAcs.SCMInquiryResultDataTable.InqOrdDivCdColumn.ColumnName].Value.ToString());
            // 2011/02/18 >>>
            //// 回答区分を追加
            //loginArguments.Append(",").Append(AnswerDivCode);
            //// ADD 2010/04/16 キャンセル対応 ----------<<<<<

            loginArguments.Append(",").Append(( AnswerDivCode == 99 ) ? 1 : 0);
            // 2011/02/18 <<<

            //#endif
            // SCM問合せ一覧を起動
            Process.Start(programPath, loginArguments.ToString());

            // --- ADD 2014/09/22 chenyd For PM-SCM仕掛一覧No.10661とNo.85対応 ---------------------->>>>>
            // 問合せ番号取得
            string tmpInqNumber = this.uGrid_Details.ActiveRow.Cells[
                                        this._scmInquiryOrderAcs.SCMInquiryResultDataTable.InquiryNumberColumn.ColumnName].Value.ToString();
            long inqNumber = 0;
            long.TryParse(tmpInqNumber, out inqNumber);
            // SCM伝票回答の場合、自拠点の端末へ送信
            if (inqNumber != 0)
            {
                this.NotifyPmByPublish(inqNumber);
            }
            // --- ADD 2014/09/22 chenyd For PM-SCM仕掛一覧No.10661とNo.85対応 ------------------------<<<<<
        }

        // --- ADD 2014/09/22 chenyd For PM-SCM仕掛一覧No.10661とNo.85対応 ------------------------------>>>>>
        /// <summary>
        /// 指定或いは関連のPM端末への返答送信処理
        /// </summary>
        /// <param name="inquiryNumber">問い合わせ番号</param>
        /// <remarks>
        /// <br>Update Note: 2014/11/17 陳艶丹</br>
        /// <br>管理番号   : 11070221-00　PM-SCM仕掛一覧No.85　RedMine#43973</br>
        /// <br>2014/11/26配信 社内SCM№55の対応</br>
        /// <br>RedMine#43973新着一覧に表示されるタイミングが端末毎に違う</br>
        /// </remarks>
        private void NotifyPmByPublish(long inquiryNumber)
        {
            // --- ADD 2014/11/17 chenyd For PM-SCM仕掛一覧No.85 社内SCM№55の対応 ---------------------->>>>>
            // Pushクライアントオブジェクト初期化
            SFCMN01501CA scmPushClient = InitPushMode();
            // --- ADD 2014/11/17 chenyd For PM-SCM仕掛一覧No.85 社内SCM№55の対応 ----------------------<<<<<
            
            // 指定のPM端末への返答送信処理
            if (LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_PM_SCM) >= PurchaseStatus.Contract)
            {
                ScmPushData payload = new ScmPushData();
                payload.NoticeMode = CT_WebSync_NoticeMode;// 新着一覧で回答済みデータを削除する判断モードです
                payload.InquiryNumber = inquiryNumber;
                payload.IsReply = false;

                PublishArgs publishArgs = new PublishArgs();
                publishArgs.Payload = payload;
                // --- DEL 2014/11/17 chenyd For PM-SCM仕掛一覧No.85 社内SCM№55の対応 ---------------------->>>>>
                //publishArgs.Channel = string.Format("/{0}/PMNS/{1}/{2}", _scmPushClient.WEBSYNC_CHANNEL_SFPMSCM, LoginInfoAcquisition.EnterpriseCode, LoginInfoAcquisition.Employee.BelongSectionCode.Trim());
                //_scmPushClient.Publish(publishArgs);
                // --- DEL 2014/11/17 chenyd For PM-SCM仕掛一覧No.85 社内SCM№55の対応 ----------------------<<<<<
                // --- ADD 2014/11/17 chenyd For PM-SCM仕掛一覧No.85 社内SCM№55の対応 ---------------------->>>>>
                publishArgs.Channel = string.Format("/{0}/PMNS/{1}/{2}", scmPushClient.WEBSYNC_CHANNEL_SFPMSCM, LoginInfoAcquisition.EnterpriseCode, LoginInfoAcquisition.Employee.BelongSectionCode.Trim());

                publishArgs.PublishSuccess += new PushClientEventHandler<PublishSuccessEventArgs>(
                    delegate(IScmPushClient client2, PublishSuccessEventArgs args2)
                    {                       
                        scmPushClient.Disconnect();
                    }
                );
                scmPushClient.Publish(publishArgs);
                // --- ADD 2014/11/17 chenyd For PM-SCM仕掛一覧No.85 社内SCM№55の対応 ----------------------<<<<<
            }
            else if (LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_PM_PCCUOE) >= PurchaseStatus.Contract)
            {
                ScmPushData payload = new ScmPushData();
                payload.NoticeMode = CT_WebSync_NoticeMode;// 新着一覧で回答済みデータを削除する判断モードです
                payload.InquiryNumber = inquiryNumber;
                payload.IsReply = false;

                PublishArgs publishArgs = new PublishArgs();
                publishArgs.Payload = payload;
                // --- DEL 2014/11/17 chenyd For PM-SCM仕掛一覧No.85 社内SCM№55の対応 ---------------------->>>>>
                //publishArgs.Channel = string.Format("/{0}/PMNS/{1}/{2}", _scmPushClient.WEBSYNC_CHANNEL_PCCUOE, LoginInfoAcquisition.EnterpriseCode, LoginInfoAcquisition.Employee.BelongSectionCode.Trim());
                //_scmPushClient.Publish(publishArgs);
                // --- DEL 2014/11/17 chenyd For PM-SCM仕掛一覧No.85 社内SCM№55の対応 ----------------------<<<<<
                // --- ADD 2014/11/17 chenyd For PM-SCM仕掛一覧No.85 社内SCM№55の対応 ---------------------->>>>>
                publishArgs.Channel = string.Format("/{0}/PMNS/{1}/{2}", scmPushClient.WEBSYNC_CHANNEL_PCCUOE, LoginInfoAcquisition.EnterpriseCode, LoginInfoAcquisition.Employee.BelongSectionCode.Trim());

                publishArgs.PublishSuccess += new PushClientEventHandler<PublishSuccessEventArgs>(
                    delegate(IScmPushClient client2, PublishSuccessEventArgs args2)
                    {
                        scmPushClient.Disconnect();
                    }
                );
                scmPushClient.Publish(publishArgs);
                // --- ADD 2014/11/17 chenyd For PM-SCM仕掛一覧No.85 社内SCM№55の対応 ----------------------<<<<<
            }
        }

        /// <summary>
        /// WebSync初期化処理
        /// </summary>
		// --- UPD 2014/11/17 chenyd For PM-SCM仕掛一覧No.85 社内SCM№55の対応 ---------------------->>>>>
        //private void InitPushMode()
        private SFCMN01501CA InitPushMode()
		// --- UPD 2014/11/17 chenyd For PM-SCM仕掛一覧No.85 社内SCM№55の対応 ----------------------<<<<<
        {
            ClientArgs clientArgs = new ClientArgs();

            // PushサーバーURLの設定
            string wkStr1 = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_WEBSYNCAP);
            string wkStr2 = LoginInfoAcquisition.GetConnectionInfo(ConstantManagement_SF_PRO.ServerCode_WEBSYNCAP, ConstantManagement_SF_PRO.IndexCode_WebSync_WebPath);
            string webSyncUrl = wkStr1 + wkStr2;
            clientArgs.Url = webSyncUrl;

			// --- UPD 2014/11/17 chenyd For PM-SCM仕掛一覧No.85 社内SCM№55の対応 ---------------------->>>>>
            //_scmPushClient = new SFCMN01501CA(clientArgs);
            SFCMN01501CA scmPushClient = new SFCMN01501CA(clientArgs);
			// --- UPD 2014/11/17 chenyd For PM-SCM仕掛一覧No.85 社内SCM№55の対応 ----------------------<<<<<

            ConnectArgs connectArgs = new ConnectArgs();
            connectArgs.StayConnected = true; // 接続が切断場合、自動的に再接続する
            connectArgs.ReconnectInterval = 5000; // 5秒　接続失敗場合、再接続間隔を指定する
            connectArgs.ConnectFailure += new PushClientEventHandler<ConnectFailureEventArgs>(
                delegate(IScmPushClient client, ConnectFailureEventArgs args)
                {
                    // 新着チェッカーが起動する時、Pushサーバーを接続できなければ、このメソッドを呼びられる
                    // 接続した後、Pushサーバーと通信エラー場合、OnStreamFailureイベントだけを呼びられる

                    // 接続が失敗すれば、Pushサーバーへ再接続
                    args.Reconnect = true;
                }
            );
			// --- UPD 2014/11/17 chenyd For PM-SCM仕掛一覧No.85 社内SCM№55の対応 ---------------------->>>>>
            //_scmPushClient.Connect(connectArgs);
            scmPushClient.Connect(connectArgs);
            return scmPushClient;
			// --- UPD 2014/11/17 chenyd For PM-SCM仕掛一覧No.85 社内SCM№55の対応 ----------------------<<<<<
        }
        // --- ADD 2014/09/22 chenyd For PM-SCM仕掛一覧No.10661とNo.85対応 ------------------------------<<<<<
        #endregion

        #region 旧システム連携拠点確認
        /// <summary>
        /// 旧システム連携確認
        /// </summary>
        /// <returns>true:旧システム連携あり false：なし</returns>
        private bool CheckLegarySystemSection(string sectionCd)
        {
            if (this._legacySystemSecList == null)
            {
                this._legacySystemSecList = new List<string>();

                ArrayList retList;
                int status = this._scmTtlStAcs.SearchAll(out retList, this._enterpriseCode);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    foreach (SCMTtlSt scmTtlSt in retList)
                    {
                        // 旧システム連携有りの場合、拠点コードをリストに保存
                        if (scmTtlSt.OldSysCooperatDiv == 1)
                        {
                            this._legacySystemSecList.Add(scmTtlSt.SectionCode.Trim().PadLeft(2, '0'));
                        }
                    }
                }
            }

            if (this._legacySystemSecList.Contains(sectionCd.Trim().PadLeft(2, '0')))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #endregion

        #region ■イベント
        /// <summary>
        /// PMSCM04001UA_Loadイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Update Note: 2014/11/17 陳艶丹</br>
        /// <br>管理番号   : 11070221-00　PM-SCM仕掛一覧No.85　RedMine#43973</br>
        /// <br>2014/11/26配信 社内SCM№55の対応</br>
        /// <br>RedMine#43973新着一覧に表示されるタイミングが端末毎に違う</br>
        /// </remarks>
        private void PMSCM04001UA_Load(object sender, EventArgs e)
        {
            // 画面初期設定
            this.SetInitialSetting();

            // 画面クリア(モード毎の初期設定)
            ClearScreenByMode();

            this.uGrid_Details.ActiveRow = null;

            this.Initial_Timer.Enabled = true;
            // --- Add 2011/07/18 duzg for 「自動回答」の列をクリックする対応　--->>>
            string[] compara = CommandLineArgs;
            bool autoStrtFlg = false;
            if (null != compara && compara.Length > 0)
            {
                foreach (string par in compara)
                {
                    if (par.Equals("AutoAnswerDiv"))
                    {
                        autoStrtFlg = true;
                        break;
                    }
                }
            }
            if (autoStrtFlg)
            {
                SetInquiryDate(DateTime.Today);
                uCheckEditor_AnswerMethodAll.Checked = false;
                uCheckEditor_AnswerMethodAuto.Checked = true;
                uCheckEditor_AnswerMethodManual.Checked = false;
                uCheckEditor_AnswerDivComplate.Checked = true;
                uCheckEditor_AnswerDivCancel.Checked = true;
            }
            // --- Add 2011/07/18 duzg for 「自動回答」の列をクリックする対応　---<<<

            // DEL 2009/09/10 画面レイアウト変更および初期表示内容の変更 ---------->>>>>
            //// メニュー起動以外は検索を実行
            //if (this._mode != Mode.Menu)
            //{
            //    this.Search();
            //}
            // DEL 2009/09/10 画面レイアウト変更および初期表示内容の変更 ----------<<<<<
            //>>>2010/03/10
            //// ADD 2009/09/10 画面レイアウト変更および初期表示内容の変更 ---------->>>>>
            //this.Search();
            //// ADD 2009/09/10 画面レイアウト変更および初期表示内容の変更 ----------<<<<<
            this.Search(true);
            //<<<2010/03/10

            // --- DEL 2014/11/17 chenyd For PM-SCM仕掛一覧No.85 社内SCM№55の対応 ---------------------->>>>>
            //// Pushクライアントオブジェクト初期化
            //InitPushMode(); // ADD 2014/09/22 chenyd For PM-SCM仕掛一覧No.10661とNo.85対応
            // --- DEL 2014/11/17 chenyd For PM-SCM仕掛一覧No.85 社内SCM№55の対応 ----------------------<<<<<
        }

        /// <summary>
        /// 初期化タイマー
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Initial_Timer_Tick(object sender, EventArgs e)
        {
            // フォーカス設定
            //this.uCheckEditor_AnswerDivNon.Focus();   // DEL 2009/09/10 画面レイアウト変更および初期表示内容の変更
            this.tde_InquiryDateSt.Focus();             // ADD 2009/09/10 画面レイアウト変更および初期表示内容の変更

            // XMLデータ読込
            LoadStateXmlData();

            // グリッドのアクティブ行をクリア
            this.uGrid_Details.ActiveRow = null;

            this.Initial_Timer.Enabled = false;

            //>>>2010/03/10
            if (this.uGrid_Details.Rows.Count != 0)
            {
                this.uGrid_Details.Rows[0].Activate();
            }
            //<<<2010/03/10
        }

        /// <summary>
        /// PMSCM04001UA_FormClosingイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PMSCM04001UA_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult = this._dialogResult;
        }

        /// <summary>
        /// tRetKeyControl1_ChangeFocusイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tRetKeyControl1_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null)
            {
                return;
            }

            switch (e.PrevCtrl.Name)
            {
                case "tNedit_CustomerCode_St":
                    {
                        #region 得意先コード(開始)
                        if (e.NextCtrl == this.uButton_CustomerCdGuideSt)
                        {
                            if (e.Key == Keys.Return || e.Key == Keys.Tab || e.Key == Keys.Right)
                            {
                                e.NextCtrl = this.tNedit_CustomerCode_Ed;
                            }
                        }

                        break;
                        #endregion
                    }
                case "tNedit_CustomerCode_Ed":
                    {
                        #region 得意先コード(終了)
                        if (e.NextCtrl == this.uButton_CustomerCdGuideEd)
                        {
                            if (e.Key == Keys.Return || e.Key == Keys.Tab || e.Key == Keys.Right)
                            {
                                // UPD 2013/06/26 T.Miyamoto ------------------------------>>>>>
                                ////e.NextCtrl = this.uCheckEditor_AnswerMethodAll;   // DEL 2009/09/10 画面レイアウト変更および初期表示内容の変更
                                //e.NextCtrl = this.tEdit_SalesSlipNum_St;            // ADD 2009/09/10 画面レイアウト変更および初期表示内容の変更
                                e.NextCtrl = this.tNedit_InquiryNumber_St;
                                // UPD 2013/06/26 T.Miyamoto ------------------------------<<<<<
                            }
                        }

                        break;
                        #endregion
                    }
                case "tNedit_InquiryNumber_St":
                case "tNedit_InquiryNumber_Ed":
                    {
                        #region 問合せ番号
                        if ((e.Key == Keys.Tab || e.Key == Keys.Right || e.Key == Keys.Down)
                            && e.NextCtrl == this.uGrid_Details)
                        {
                            if (this.uGrid_Details.DisplayLayout.Rows.Count != 0)
                            {
                                this.uGrid_Details.DisplayLayout.Rows[0].Activate();
                                this.uGrid_Details.DisplayLayout.Rows[0].Selected = true;
                            }
                            else
                            {
                                e.NextCtrl = this.uCheckEditor_AnswerDivNon;
                            }
                        }
                        break;
                        #endregion
                    }
                case "tEdit_SectionCodeAllowZero":
                    {
                        #region 拠点コード
                        // 入力無し
                        if (this.tEdit_SectionCodeAllowZero.DataText == string.Empty
                            || this.tEdit_SectionCodeAllowZero.Text.Trim().PadLeft(2, '0') == "00")
                        {
                            this.tEdit_SectionCodeAllowZero.Text = "00";
                            this.uLabel_SectionName.Text = "全社";

                            // 設定値保存
                            this._beforeSectionCode = "00";

                            if (e.NextCtrl == this.uButton_SectionCdGuide
                                && (e.Key == Keys.Return || e.Key == Keys.Tab || e.Key == Keys.Right))
                            {
                                // 入力あり＆Tab遷移＆次がガイドボタンの場合、ガイドボタンは飛ばす
                                //e.NextCtrl = this.tNedit_CustomerCode_St; // DEL 2009/09/10 画面レイアウト変更および初期表示内容の変更
                                e.NextCtrl = this.uCheckEditor_AnswerDivNon;// ADD 2009/09/10 画面レイアウト変更および初期表示内容の変更
                            }

                            break;
                        }

                        // 入力変更なし
                        if (this.tEdit_SectionCodeAllowZero.Text.Trim().PadLeft(2, '0') == this._beforeSectionCode)
                        {
                            if (e.NextCtrl == this.uButton_SectionCdGuide
                                && (e.Key == Keys.Return || e.Key == Keys.Tab || e.Key == Keys.Right))
                            {
                                // 入力あり＆Tab遷移＆次がガイドボタンの場合、ガイドボタンは飛ばす
                                //e.NextCtrl = this.tNedit_CustomerCode_St; // DEL 2009/09/10 画面レイアウト変更および初期表示内容の変更
                                e.NextCtrl = this.uCheckEditor_AnswerDivNon;// ADD 2009/09/10 画面レイアウト変更および初期表示内容の変更
                            }

                            break;
                        }

                        // 入力値チェック
                        SecInfoSet secInfoSet;

                        int status = this._secInfoSetAcs.Read(out secInfoSet, this._enterpriseCode, this.tEdit_SectionCodeAllowZero.DataText);

                        if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                        {
                            // 結果を画面に設定
                            this.tEdit_SectionCodeAllowZero.Text = secInfoSet.SectionCode.Trim().PadLeft(2, '0');
                            this.uLabel_SectionName.Text = secInfoSet.SectionGuideNm;

                            // 設定値を保存
                            this._beforeSectionCode = secInfoSet.SectionCode.Trim().PadLeft(2, '0');
                        }
                        else
                        {
                            // 前回入力値を設定
                            this.tEdit_SectionCodeAllowZero.DataText = this._beforeSectionCode;

                            // 該当なし
                            TMsgDisp.Show(this, 												// 親ウィンドウフォーム
                                            emErrorLevel.ERR_LEVEL_INFO, 						// エラーレベル
                                            this.Name,											// アセンブリID
                                            "指定された条件で拠点コードは存在しませんでした。", // 表示するメッセージ
                                            -1,													// ステータス値
                                            MessageBoxButtons.OK);								// 表示するボタン
                            return;
                        }

                        if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL
                            && e.NextCtrl == this.uButton_SectionCdGuide
                            && (e.Key == Keys.Return || e.Key == Keys.Tab || e.Key == Keys.Right))
                        {
                            // 入力あり＆Tab遷移＆次がガイドボタンの場合、ガイドボタンは飛ばす
                            //e.NextCtrl = this.tNedit_CustomerCode_St; // DEL 2009/09/10 画面レイアウト変更および初期表示内容の変更
                            e.NextCtrl = this.uCheckEditor_AnswerDivNon;// ADD 2009/09/10 画面レイアウト変更および初期表示内容の変更
                        }

                        break;
                        #endregion
                    }
                case "uCheckEditor_AnswerDivNon":
                    {
                        #region 回答区分 未アクション
                        if ((e.Key == Keys.Tab || e.Key == Keys.Left)
                            && e.NextCtrl == this.uGrid_Details)
                        {
                            if (this.uGrid_Details.DisplayLayout.Rows.Count != 0)
                            {
                                this.uGrid_Details.DisplayLayout.Rows[this.uGrid_Details.DisplayLayout.Rows.Count - 1].Activate();
                                this.uGrid_Details.DisplayLayout.Rows[this.uGrid_Details.DisplayLayout.Rows.Count - 1].Selected = true;
                            }
                            else
                            {
                                e.NextCtrl = this.tNedit_InquiryNumber_Ed;
                            }
                        }
                        break;
                        #endregion
                    }
                case "uGrid_Details":
                    {
                        #region グリッド
                        if (e.Key == Keys.Tab)
                        {
                            if (this.uGrid_Details.Rows.Count == 0 || this.uGrid_Details.ActiveRow == null)
                            {
                                if (e.ShiftKey)
                                {
                                    //e.NextCtrl = this.tNedit_InquiryNumber_Ed;        // DEL 2009/09/10 画面レイアウト変更および初期表示内容の変更
                                    e.NextCtrl = this.uCheckEditor_AnswerMethodManual;  // ADD 2009/09/10 画面レイアウト変更および初期表示内容の変更
                                }
                                else
                                {
                                    //e.NextCtrl = this.uCheckEditor_AnswerDivNon;  // DEL 2009/09/10 画面レイアウト変更および初期表示内容の変更
                                    e.NextCtrl = this.tde_InquiryDateSt;            // ADD 2009/09/10 画面レイアウト変更および初期表示内容の変更
                                }
                            }
                            else
                            {
                                if (e.ShiftKey)
                                {
                                    if (this.uGrid_Details.DisplayLayout.ActiveRow.Index == 0)
                                    {
                                        //e.NextCtrl = this.tNedit_InquiryNumber_Ed;        // DEL 2009/09/10 画面レイアウト変更および初期表示内容の変更
                                        e.NextCtrl = this.uCheckEditor_AnswerMethodManual;  // ADD 2009/09/10 画面レイアウト変更および初期表示内容の変更
                                    }
                                    else
                                    {
                                        e.NextCtrl = this.uGrid_Details;
                                        this.uGrid_Details.PerformAction(UltraGridAction.AboveRow);
                                    }
                                }
                                else
                                {
                                    if (this.uGrid_Details.DisplayLayout.ActiveRow.Index
                                        == this.uGrid_Details.DisplayLayout.Rows.Count - 1)
                                    {
                                        //e.NextCtrl = this.uCheckEditor_AnswerDivNon;  // DEL 2009/09/10 画面レイアウト変更および初期表示内容の変更
                                        e.NextCtrl = this.tde_InquiryDateSt;            // ADD 2009/09/10 画面レイアウト変更および初期表示内容の変更
                                    }
                                    else
                                    {
                                        e.NextCtrl = this.uGrid_Details;
                                        this.uGrid_Details.PerformAction(UltraGridAction.BelowRow);
                                    }
                                }
                            }
                        }
                        break;
                        #endregion
                    }
            }
        }

        #region ガイドボタン押下イベント
        /// <summary>
        /// 拠点ガイドボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_SectionCdGuide_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                SecInfoSet secInfoSet;

                int status = this._secInfoSetAcs.ExecuteGuid(this._enterpriseCode, true, out secInfoSet);
                if (status == 0)
                {
                    this.tEdit_SectionCodeAllowZero.Text = secInfoSet.SectionCode.Trim().PadLeft(2, '0');
                    this.uLabel_SectionName.Text = secInfoSet.SectionGuideNm.Trim();

                    this._beforeSectionCode = secInfoSet.SectionCode.Trim().PadLeft(2, '0');

                    // 次フォーカス
                    tNedit_CustomerCode_St.Focus();
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// 得意先ガイドボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_CustomerCdGuideSt_Click(object sender, EventArgs e)
        {
            // 押下されたボタンを退避
            if (sender is UltraButton)
            {
                _customerGuideSender = (UltraButton)sender;
            }

            // 得意先ガイド用ライブラリ名変更
            PMKHN04005UA customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_CUSTOMER_ONLY, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY);	// 得意先検索アクセスクラス
            customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.CustomerSearchForm_CustomerSelect);
            DialogResult ret = customerSearchForm.ShowDialog(this);
            if (ret == DialogResult.OK)
            {
                // 次フォーカス
                if ( sender == this.uButton_CustomerCdGuideSt)
                {
                    this.tNedit_CustomerCode_Ed.Focus();
                }
                else
                {
                    this.uCheckEditor_AnswerMethodAll.Focus();
                }

            }
        }

        /// <summary>
        /// 得意先選択時発生イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="customerSearchRet">得意先車両検索戻り値クラス</param>
        private void CustomerSearchForm_CustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        {
            if (customerSearchRet == null) return;

            CustomerInfoAcs customerInfoAcs = new CustomerInfoAcs();
            CustomerInfo customerInfo = new CustomerInfo();

            int status = customerInfoAcs.ReadDBData(this._enterpriseCode, customerSearchRet.CustomerCode, out customerInfo);
            if (status != 0) return;

            if (_customerGuideSender == this.uButton_CustomerCdGuideSt)
            {
                this.tNedit_CustomerCode_St.SetInt(customerInfo.CustomerCode);
            }
            else
            {
                this.tNedit_CustomerCode_Ed.SetInt(customerInfo.CustomerCode);
            }

        }
        #endregion

        #region 回答区分制御
        /// <summary>
        /// 回答区分「全て」
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uCheckEditor_AnswerMethodAll_CheckedChanged(object sender, EventArgs e)
        {
            if (this.uCheckEditor_AnswerMethodAll.Checked)
            {
                this.uCheckEditor_AnswerMethodAuto.Checked = false;
                this.uCheckEditor_AnswerMethodManual.Checked = false;
            }
        }

        /// <summary>
        /// 回答区分「自動」
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uCheckEditor_AnswerMethodAuto_CheckedChanged(object sender, EventArgs e)
        {
            if (this.uCheckEditor_AnswerMethodAuto.Checked)
            {
                this.uCheckEditor_AnswerMethodAll.Checked = false;
            }
        }

        /// <summary>
        /// 回答区分「手動」
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uCheckEditor_AnswerMethodManual_CheckedChanged(object sender, EventArgs e)
        {
            if (this.uCheckEditor_AnswerMethodManual.Checked)
            {
                this.uCheckEditor_AnswerMethodAll.Checked = false;
            }
        }
        #endregion

        #region 伝票番号(受注ステータス)制御
        /// <summary>
        /// 伝票番号 受注ステータス「全て」
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uCheckEditor_AcptAnOdrStatusAll_CheckedChanged(object sender, EventArgs e)
        {
            if (this.uCheckEditor_AcptAnOdrStatusAll.Checked)
            {
                this.uCheckEditor_AcptAnOdrStatusSales.Checked = false;
                this.uCheckEditor_AcptAnOdrStatusAccept.Checked = false;
                this.uCheckEditor_AcptAnOdrStatusEstimate.Checked = false;
            }
        }

        /// <summary>
        /// 伝票番号 受注ステータス「売上」
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uCheckEditor_AcptAnOdrStatusSales_CheckedChanged(object sender, EventArgs e)
        {
            if (this.uCheckEditor_AcptAnOdrStatusSales.Checked)
            {
                this.uCheckEditor_AcptAnOdrStatusAll.Checked = false;
            }
        }

        /// <summary>
        /// 伝票番号 受注ステータス「受注」
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uCheckEditor_AcptAnOdrStatusAccept_CheckedChanged(object sender, EventArgs e)
        {
            if (this.uCheckEditor_AcptAnOdrStatusAccept.Checked)
            {
                this.uCheckEditor_AcptAnOdrStatusAll.Checked = false;
            }
        }

        /// <summary>
        /// 伝票番号 受注ステータス「見積」
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uCheckEditor_AcptAnOdrStatusEstimate_CheckedChanged(object sender, EventArgs e)
        {
            if (this.uCheckEditor_AcptAnOdrStatusEstimate.Checked)
            {
                this.uCheckEditor_AcptAnOdrStatusAll.Checked = false;
            }
        }
        #endregion

        #region 問合せ番号(問合せ発注種別)制御
        /// <summary>
        /// 問合せ番号 問合せ発注種別「全て」
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uCheckEditor_InqOrdDivAll_CheckedChanged(object sender, EventArgs e)
        {
            if (this.uCheckEditor_InqOrdDivAll.Checked)
            {
                this.uCheckEditor_InqOrdDivAccept.Checked = false;
                this.uCheckEditor_InqOrdDivEstimate.Checked = false;
            }
        }

        /// <summary>
        /// 問合せ番号 問合せ発注種別「受注」
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uCheckEditor_InqOrdDivAccept_CheckedChanged(object sender, EventArgs e)
        {
            if (this.uCheckEditor_InqOrdDivAccept.Checked)
            {
                this.uCheckEditor_InqOrdDivAll.Checked = false;
            }
        }

        /// <summary>
        /// 問合せ番号 問合せ発注種別「見積」
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uCheckEditor_InqOrdDivEstimate_CheckedChanged(object sender, EventArgs e)
        {
            if (this.uCheckEditor_InqOrdDivEstimate.Checked)
            {
                this.uCheckEditor_InqOrdDivAll.Checked = false;
            }
        }
        #endregion

        #region ツールクリック
        /// <summary>
        /// tToolbarsManager1_ToolClickイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tToolbarsManager1_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                switch (e.Tool.Key)
                {
                    case "ButtonTool_Close":
                        {
                            // 閉じる
                            this._dialogResult = DialogResult.Cancel;
                            this.Close();
                            break;
                        }
                    case "ButtonTool_Select":
                        {
                            // 確定
                            this.ReturnSalesSlipInput();
                            break;
                        }
                    case "ButtonTool_Search":
                        {
                            // 検索
                            this.Search();
                            break;
                        }
                    case "ButtonTool_SalesSlip":
                        {
                            // 売上伝票入力
                            //this.DispSalesSlipInput(); // DEL 2013/04/24 qijh #35272

                            // --- ADD 2013/04/24 qijh #35272 -- >>>>>
                            if (CheckAnsStatus())
                                this.DispSalesSlipInput();
                            // --- ADD 2013/04/24 qijh #35272 -- <<<<<
                            break;
                        }
                    case "ButtonTool_Clear":
                        {
                            // クリア
                            this.ClearScreenByMode();

                            this._scmInquiryOrderAcs.SCMInquiryResultDataTable.Clear();
                            this._scmInquiryOrderAcs.SCMInquiryDetailResultDataTable.Clear();

                            this.Initial_Timer.Enabled = true;

                            break;
                        }
                    // 2010/05/20 Add >>>
                    case "ButtonTool_Receive":
                        {
                            PMSCM01104UA rcvform = new PMSCM01104UA();
                            rcvform.Title = "受信処理";
                            rcvform.Message = "データを受信しています";
                            try
                            {
                                rcvform.Show();
                                if (this._scmDtRcveExecAcs == null) this._scmDtRcveExecAcs = new SCMDtRcveExecAcs();
                                //>>>2010/07/30
                                this._scmDtRcveExecAcs.GetStartParameterEvent += new SCMDtRcveExecAcs.GetStartParameterEventHandler(this.GetStartParameter);
                                //<<<2010/07/30
                                string msg;
                                int status = this._scmDtRcveExecAcs.DataReceive(true, out msg);
                            }
                            finally
                            {
                                rcvform.Close();
                                rcvform.Dispose();
                            }
                            this.Search(false);
                          
                            break;
                        }   
                    // 2010/05/20 Add <<<
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        #endregion

        #region グリッド関連
        /// <summary>
        /// uGrid_Details_DoubleClickイベント(明細画面表示)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_Details_DoubleClick(object sender, EventArgs e)
        {
            //>>>2010/03/10
            #region 削除コード
            //if (this.uGrid_Details.ActiveRow == null) return;

            //// ヘッダをダブルクリックした場合は明細に遷移しない
            //UltraGrid grid = (UltraGrid)sender;
            //UIElement lastElementEntered = grid.DisplayLayout.UIElement.LastElementEntered;
            //RowUIElement rowElement;
            //if (lastElementEntered is RowUIElement)
            //    rowElement = (RowUIElement)lastElementEntered;
            //else
            //{
            //    rowElement = (RowUIElement)lastElementEntered.GetAncestor(typeof(RowUIElement));
            //}

            //if (rowElement == null) return;

            //UltraGridRow row = (UltraGridRow)rowElement.GetContext(typeof(UltraGridRow));

            //if (row == null) return;
            
            //// 旧システム連携の確認
            //string sectionCd = this.uGrid_Details.
            //    Rows[this.uGrid_Details.ActiveRow.Index].
            //    Cells[this._scmInquiryOrderAcs.SCMInquiryResultDataTable.InqOtherSecCdColumn.ColumnName].Value.ToString();

            //bool isLegacySection;

            //if (this.CheckLegarySystemSection(sectionCd))
            //{
            //    // 旧システム連携拠点は売上伝票入力に戻さない
            //    isLegacySection = true;
            //}
            //else
            //{
            //    isLegacySection = false;
            //}

            //// メイン画面Indexを明細画面表示前に退避
            //int index = this.uGrid_Details.ActiveRow.Index;

            //// -- UPD 2010/02/09 ---------------------->>>
            ////PMSCM04001UB detail = new PMSCM04001UB((int)this._mode, this._commandLineArgs, this.uGrid_Details.ActiveRow, isLegacySection);
            //PMSCM04001UB detail = new PMSCM04001UB((int)this._mode, this._commandLineArgs, this.uGrid_Details.Rows[index], isLegacySection);
            //// -- UPD 2010/02/09 ----------------------<<<

            //detail.SetScreen += new PMSCM04001UB.SetExtraInfoFromScreen(SetExtraInfoFromScreen);
            //detail.ShowDialog(this);

            //// 明細画面表示後、前回フォーカス位置を設定
            //this.uGrid_Details.Rows[index].Selected = true;
            //this.uGrid_Details.ActiveRow = this.uGrid_Details.Rows[index];
            #endregion // 削除コード

            if (this._mode == Mode.SalesSlip)
            {
                this.ReturnSalesSlipInput();
            }
            // ADD 2010/04/16 キャンセル対応 ---------->>>>>
            // 開発用の処置
        #if DEBUG
            else
            {
                ReturnSalesSlipInput();
            }
        #endif
            // ADD 2010/04/16 キャンセル対応 ----------<<<<<
            //<<<2010/03/10
        }

        /// <summary>
        /// uGrid_Details_Leaveイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_Details_Leave(object sender, EventArgs e)
        {
            //>>>2010/03/10
            //// アクティブ行の解除
            //if (this.uGrid_Details.ActiveRow != null)
            //{
            //    this.uGrid_Details.ActiveRow.Selected = false;
            //    this.uGrid_Details.ActiveRow = null;
            //}
            //<<<2010/03/10
        }

        /// <summary>
        /// uGrid_Details_InitializeLayoutイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_Details_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            // ヘッダクリックアクションの設定(ソート処理)
            e.Layout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            // 行フィルター設定
            e.Layout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
            // 列移動可
            e.Layout.Override.AllowColMoving = AllowColMoving.WithinBand;
        }

        /// <summary>
        /// uGrid_Details_KeyDownイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_Details_KeyDown(object sender, KeyEventArgs e)
        {
            UltraGrid uGrid = (UltraGrid)sender;

            if (uGrid.Rows.Count == 0 ||
                ((uGrid.ActiveCell == null) && (uGrid.ActiveRow == null)))
            {
                switch (e.KeyCode)
                {
                    case Keys.Up:
                        {
                            e.Handled = true;
                            this.tNedit_InquiryNumber_St.Focus();
                            break;
                        }
                    case Keys.Down:
                    case Keys.Right:
                        {
                            e.Handled = true;
                            this.uCheckEditor_AnswerDivNon.Focus();
                            break;
                        }
                    case Keys.Left:
                        {
                            e.Handled = true;
                            this.tNedit_InquiryNumber_Ed.Focus();

                            break;
                        }
                }

                return;
            }

            switch (e.KeyCode)
            {
                case Keys.Up:
                case Keys.Left:
                    {
                        e.Handled = true;
                        if (uGrid.DisplayLayout.ActiveRow.Index != 0)
                        {
                            uGrid.PerformAction(UltraGridAction.AboveRow);
                        }
                        else
                        {
                            if (e.KeyCode == Keys.Up)
                            {
                                this.tNedit_InquiryNumber_St.Focus();
                            }
                            else
                            {
                                this.tNedit_InquiryNumber_Ed.Focus();
                            }
                        }
                        break;
                    }
                case Keys.Down:
                case Keys.Right:
                    {
                        e.Handled = true;
                        if (uGrid.DisplayLayout.ActiveRow.Index != uGrid.DisplayLayout.Rows.Count - 1)
                        {
                            uGrid.PerformAction(UltraGridAction.BelowRow);
                        }
                        else
                        {
                            this.uCheckEditor_AnswerDivNon.Focus();
                        }
                        break;
                    }
            }
        }

        // ADD 2010/04/16 キャンセル対応 ---------->>>>>
        /// <summary>
        /// SCM受注データグリッドのAfterRowActivateイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void uGrid_Details_AfterRowActivate(object sender, EventArgs e)
        {
            // 問合せ番号
            string inquiryNumberCellName = _scmInquiryOrderAcs.SCMInquiryResultDataTable.InquiryNumberColumn.ColumnName;
            string strInquiryNumber = this.uGrid_Details.ActiveRow.Cells[inquiryNumberCellName].Value.ToString();
            long inquiryNumber = 0;
            long.TryParse(strInquiryNumber, out inquiryNumber);

            // 回答区分
            string answerDivCdCellName = _scmInquiryOrderAcs.SCMInquiryResultDataTable.AnswerDivCdColumn.ColumnName;
            string strAnswerDivCd = this.uGrid_Details.ActiveRow.Cells[answerDivCdCellName].Value.ToString();
            int answerDivCd = 0;
            int.TryParse(strAnswerDivCd, out answerDivCd);

            // 2011/01/24 Add >>>
            int inqOrdDivCd = (int)this.uGrid_Details.ActiveRow.Cells[_scmInquiryOrderAcs.SCMInquiryResultDataTable.InqOrdDivCdColumn.ColumnName].Value;
            // 2011/01/24 Add <<<

            // 2011/02/09 Add >>>
            Guid dtlGuid = (Guid)this.uGrid_Details.ActiveRow.Cells[_scmInquiryOrderAcs.SCMInquiryResultDataTable.DetailGuidColumn.ColumnName].Value;
            // 2011/02/09 Add <<<

            // 2011/02/14 >>>
            //// 以下の場合、売上伝票入力を行えません。
            //// ①回答区分が｢回答完了｣
            //// ②回答区分が｢キャンセル｣で『未回答データが全てキャンセル』または『全て返品済み』
            //this.tToolbarsManager1.Tools["ButtonTool_SalesSlip"].SharedProps.Enabled = _scmInquiryOrderAcs.CanInputSalesSlip(inquiryNumber, answerDivCd);

            this.tToolbarsManager1.Tools["ButtonTool_SalesSlip"].SharedProps.Enabled = _scmInquiryOrderAcs.CanInputSalesSlip(dtlGuid);

            // 2011/02/14 <<<
        }
        // ADD 2010/04/16 キャンセル対応 ----------<<<<<

        #endregion // グリッド関連

        // ADD 2009/09/10 画面レイアウト変更および初期表示内容の変更 ---------->>>>>
        #region 問合せ日

        /// <summary>
        /// 本日ボタンのClickイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void ubtnToday_Click(object sender, EventArgs e)
        {
            SetInquiryDate(DateTime.Today);
        }

        /// <summary>
        /// 問合せ日（開始と終了）を設定します。
        /// </summary>
        /// <param name="dateTime">日時</param>
        private void SetInquiryDate(DateTime dateTime)
        {
            this.tde_InquiryDateSt.SetDateTime(dateTime);
            this.tde_InquiryDateEd.SetDateTime(dateTime);
        }

        /// <summary>
        /// 前日ボタンのイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void ubtnPreviousDate_Click(object sender, EventArgs e)
        {
            if (this.tde_InquiryDateSt.GetDateTime().Equals(this.tde_InquiryDateEd.GetDateTime()))
            {
                DateTime currentInquiryDate = this.tde_InquiryDateSt.GetDateTime();
                if (currentInquiryDate > DateTime.MinValue)
                {
                    DateTime previousDate = currentInquiryDate.AddDays(-1.0);
                    SetInquiryDate(previousDate);
                }
            }
            else
            {
                DateTime yesterday = DateTime.Today.AddDays(-1.0);
                SetInquiryDate(yesterday);
            }
        }

        #endregion // 問合せ日
        // ADD 2009/09/10 画面レイアウト変更および初期表示内容の変更 ----------<<<<<

        // ADD 2013/05/09 SCM障害№10384対応 ----------------------------------->>>>>
        #region 入庫予定日
        /// <summary>
        /// 本日ボタンのClickイベントハンドラ（入庫予定日）
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void ubtnToday2_Click(object sender, EventArgs e)
        {
            this.tde_ExpectedCeDateSt.SetDateTime(DateTime.Today);
            this.tde_ExpectedCeDateEd.SetDateTime(DateTime.Today);
        }

        /// <summary>
        /// 前日ボタンのイベントハンドラ（入庫予定日）
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void ubtnPreviousDate2_Click(object sender, EventArgs e)
        {
            if (this.tde_ExpectedCeDateSt.GetDateTime().Equals(this.tde_ExpectedCeDateEd.GetDateTime()))
            {
                DateTime currentInquiryDate = this.tde_ExpectedCeDateSt.GetDateTime();
                if (currentInquiryDate > DateTime.MinValue)
                {
                    DateTime previousDate = currentInquiryDate.AddDays(-1.0);
                    this.tde_ExpectedCeDateSt.SetDateTime(previousDate);
                    this.tde_ExpectedCeDateEd.SetDateTime(previousDate);
                }
            }
            else
            {
                DateTime yesterday = DateTime.Today.AddDays(-1.0);
                this.tde_ExpectedCeDateSt.SetDateTime(yesterday);
                this.tde_ExpectedCeDateEd.SetDateTime(yesterday);
            }
        }
        #endregion // 入庫予定日
        // ADD 2013/05/09 SCM障害№10384対応 -----------------------------------<<<<<
        #endregion

        #region 起動タイプ区分列挙
        /// <summary>起動タイプ列挙</summary>
        private enum Mode
        {
            ///<summary>メニュー</summary>
            Menu = 0,
            ///<summary>ポップアップ</summary>
            Popup = 1,
            /// <summary>売上伝票入力</summary>
            SalesSlip = 2
        }
        #endregion

        //>>>2010/03/10
        private void ultraButton1_Click(object sender, EventArgs e)
        {
            if (this.uGrid_Details.ActiveRow == null) return;

            UltraGridRow row = this.uGrid_Details.ActiveRow;

            if (row == null) return;

            // 旧システム連携の確認
            string sectionCd = this.uGrid_Details.
                Rows[this.uGrid_Details.ActiveRow.Index].
                Cells[this._scmInquiryOrderAcs.SCMInquiryResultDataTable.InqOtherSecCdColumn.ColumnName].Value.ToString();

            bool isLegacySection;

            if (this.CheckLegarySystemSection(sectionCd))
            {
                // 旧システム連携拠点は売上伝票入力に戻さない
                isLegacySection = true;
            }
            else
            {
                isLegacySection = false;
            }

            // メイン画面Indexを明細画面表示前に退避
            int index = this.uGrid_Details.ActiveRow.Index;

            // -- UPD 2010/02/09 ---------------------->>>
            //PMSCM04001UB detail = new PMSCM04001UB((int)this._mode, this._commandLineArgs, this.uGrid_Details.ActiveRow, isLegacySection);
            // DEL 2010/04/16 キャンセル対応 ---------->>>>>
            //PMSCM04001UB detail = new PMSCM04001UB((int)this._mode, this._commandLineArgs, this.uGrid_Details.Rows[index], isLegacySection);
            // DEL 2010/04/16 キャンセル対応 ----------<<<<<
            // ADD 2010/04/16 キャンセル対応 ---------->>>>>
            PMSCM04001UB detail = new PMSCM04001UB(
                (int)this._mode,
                this._commandLineArgs,
                this.uGrid_Details.Rows[index],
                isLegacySection,
                this.tToolbarsManager1.Tools["ButtonTool_SalesSlip"].SharedProps.Enabled
            );
            // ADD 2010/04/16 キャンセル対応 ----------<<<<<
            // -- UPD 2010/02/09 ----------------------<<<

            detail.SetScreen += new PMSCM04001UB.SetExtraInfoFromScreen(SetExtraInfoFromScreen);
            detail.ShowDialog(this);

            // 明細画面表示後、前回フォーカス位置を設定
            this.uGrid_Details.Rows[index].Selected = true;
            this.uGrid_Details.ActiveRow = this.uGrid_Details.Rows[index];
        }
        //<<<2010/03/10


        // 2010/05/27 Add >>>
        /// <summary>
        /// TODO:売伝へ返す前のチェック
        /// </summary>
        /// <param name="cndtn"></param>
        /// <param name="detailSearch"></param>
        /// <param name="selectedAnswerDivCd"></param>
        /// <returns></returns>
        // DEL 2010/06/17 キャンセル追加対応 ---------->>>>>
        //private int ReturnCheck(SCMInquiryOrder cndtn, bool detailSearch)
        // DEL 2010/06/17 キャンセル追加対応 ----------<<<<<
        // ADD 2010/06/17 キャンセル追加対応 ---------->>>>>
        private int ReturnCheck(SCMInquiryOrder cndtn, bool detailSearch, int selectedAnswerDivCd)
        // ADD 2010/06/17 キャンセル追加対応 ----------<<<<<
        {
            int status = 0;
            if (detailSearch) status = this.SearchDetail(cndtn);

            // DEL 2010/06/17 キャンセル追加対応 ---------->>>>>
            //if (status == 0)
            // DEL 2010/06/17 キャンセル追加対応 ----------<<<<<
            // ADD 2010/06/17 キャンセル追加対応 ---------->>>>>
            if (status == 0 && selectedAnswerDivCd == (int)AnswerDivCd.Cancel)  // 回答区分「キャンセル」を選択
            // ADD 2010/06/17 キャンセル追加対応 ----------<<<<<
            {
                if (this._scmInquiryOrderAcs.DetailExistsNonAnswer())
                {
                    DialogResult dr =
                        // 該当なし
                        TMsgDisp.Show(
                        this, 												// 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_INFO, 						// エラーレベル
                        this.Name,											// アセンブリID
                        // DEL 2010/06/17 キャンセル追加対応 ---------->>>>>
                        //"キャンセルデータを選択しました。" + Environment.NewLine +
                        //"キャンセルを受付けますか？"
                        // DEL 2010/06/17 キャンセル追加対応 ----------<<<<<
                        // ADD 2010/06/17 キャンセル追加対応 ---------->>>>>
                        "返品要求があります。" + Environment.NewLine +
                        "返品を受付けますか？"
                        // ADD 2010/06/17 キャンセル追加対応 ----------<<<<<
                        ,
                        -1,													// ステータス値
                        // DEL 2010/06/17 キャンセル追加対応 ---------->>>>>
                        //MessageBoxButtons.YesNoCancel, MessageBoxDefaultButton.Button1
                        // DEL 2010/06/17 キャンセル追加対応 ----------<<<<<
                        // ADD 2010/06/17 キャンセル追加対応 ---------->>>>>
                        MessageBoxButtons.YesNoCancel, MessageBoxDefaultButton.Button3
                        // ADD 2010/06/17 キャンセル追加対応 ---------->>>>>
                    );

                    if (dr == DialogResult.No)
                    {
                        // 返品拒否
                        // DEL 2010/06/17 キャンセル追加対応 ---------->>>>>
                        //this._scmInquiryOrderAcs.ReturnedGoodsRefusal(cndtn);
                        // DEL 2010/06/17 キャンセル追加対応 ----------<<<<<
                        // ADD 2010/06/17 キャンセル追加対応 ---------->>>>>
                        this._scmInquiryOrderAcs.ReturnedGoodsRefusal(cndtn, (short)CancelCndtinDiv.Rejected);
                        // ADD 2010/06/17 キャンセル追加対応 ----------<<<<<
                        return 1;
                    }
                    else if (dr == DialogResult.Cancel)
                    {
                        return -1;
                    }
                    // ADD 2010/06/17 キャンセル追加対応 ---------->>>>>
                    else if (dr == DialogResult.Yes)
                    {
                        // 2011/02/18 >>>
                        //// 返品確定
                        //int result = this._scmInquiryOrderAcs.ReturnedGoodsRefusal(cndtn, (short)CancelCndtinDiv.Cancelled);
                        //return result == 0 ? 0 : -1;
                        return 0;
                        // 2011/02/18 <<<
                    }
                    // ADD 2010/06/17 キャンセル追加対応 ----------<<<<<
                }
            }
            // ADD 2010/06/17 キャンセル追加対応 ---------->>>>>
            else if (status == 0 && selectedAnswerDivCd == (int)AnswerDivCd.NoAction)   // 回答区分「未回答」を選択
            {
                if (this._scmInquiryOrderAcs.ExistsCancellingDetails())
                {
                    DialogResult dr = TMsgDisp.Show(
                        this, 							// 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_INFO,    // エラーレベル
                        this.Name,						// アセンブリID
                        "キャンセル要求の明細があります。" + Environment.NewLine +
                        "キャンセルを受付けますか？"
                        ,
                        -1, // ステータス値
                        MessageBoxButtons.YesNoCancel, MessageBoxDefaultButton.Button3
                    );
                    if (dr == DialogResult.Yes)
                    {
                        // キャンセル確定
                        int result = this._scmInquiryOrderAcs.UpdateCancelCndtinDivOfNotAnswered(
                            cndtn,
                            (short)CancelCndtinDiv.Cancelled
                        );
                        return result == 0 ? 0 : -1;
                    }
                    else if (dr == DialogResult.No)
                    {
                        // キャンセル拒否
                        int result = this._scmInquiryOrderAcs.UpdateCancelCndtinDivOfNotAnswered(
                            cndtn,
                            (short)CancelCndtinDiv.Rejected
                        );
                        return result == 0 ? 0 : -1;
                    }
                    else if (dr == DialogResult.Cancel)
                    {
                        return -1;
                    }
                }
            }
            // ADD 2010/06/17 キャンセル追加対応 ----------<<<<<

            return 0;
        }

        /// <summary>
        /// 返品可否チェック
        /// </summary>
        /// <param name="rowIndex"></param>
        /// <param name="detailSearch"></param>
        /// <param name="selectedAnswerDivCd"></param>
        /// <returns></returns>
        // DEL 2010/06/17 キャンセル追加対応 ---------->>>>>
        //private int ReturnCheck(int rowIndex, bool detailSearch)
        // DEL 2010/06/17 キャンセル追加対応 ----------<<<<<
        // ADD 2010/06/17 キャンセル追加対応 ---------->>>>>
        private int ReturnCheck(int rowIndex, bool detailSearch, int selectedAnswerDivCd)
        // ADD 2010/06/17 キャンセル追加対応 ----------<<<<<
        {
            SCMInquiryOrder cndtn = this.GetSearchCndtn(rowIndex);

            // DEL 2010/06/17 キャンセル追加対応 ---------->>>>>
            //return this.ReturnCheck(cndtn, detailSearch);
            // DEL 2010/06/17 キャンセル追加対応 ----------<<<<<
            // ADD 2010/06/17 キャンセル追加対応 ---------->>>>>
            return this.ReturnCheck(cndtn, detailSearch, selectedAnswerDivCd);
            // ADD 2010/06/17 キャンセル追加対応 ----------<<<<<
        }

        /// <summary>
        /// 明細検索処理
        /// </summary>
        /// <param name="rowIndex"></param>
        /// <returns></returns>
        private int SearchDetail(SCMInquiryOrder cndtn)
        {
            int status = 0;

            string errMsg;

            if (cndtn != null)
            {
                status = this._scmInquiryOrderAcs.SearchDetail(cndtn, out errMsg);
            }

            return status;
        }

        /// <summary>
        /// 検索条件取得
        /// </summary>
        /// <param name="rowIndex"></param>
        /// <returns></returns>
        private SCMInquiryOrder GetSearchCndtn(int rowIndex)
        {
            SCMInquiryOrder cndtn = new SCMInquiryOrder();
            UltraGridRow row = uGrid_Details.Rows[rowIndex];

            cndtn.EnterpriseCode = this._enterpriseCode;

            cndtn.AcptAnOdrStatus = new int[1] { (int)row.Cells[this._scmInquiryOrderAcs.SCMInquiryResultDataTable.AcptAnOdrStatusColumn.ColumnName].Value };

            cndtn.AnswerDivCd = new int[1] { (int)row.Cells[this._scmInquiryOrderAcs.SCMInquiryResultDataTable.AnswerDivCdColumn.ColumnName].Value };

            cndtn.InqOrdDivCd = new int[1] { (int)row.Cells[this._scmInquiryOrderAcs.SCMInquiryResultDataTable.InqOrdDivCdColumn.ColumnName].Value };

            cndtn.InqOriginalEpCd = ((string)row.Cells[this._scmInquiryOrderAcs.SCMInquiryResultDataTable.InqOriginalEpCdColumn.ColumnName].Value).Trim();//@@@@20230303
            cndtn.InqOriginalSecCd = (string)row.Cells[this._scmInquiryOrderAcs.SCMInquiryResultDataTable.InqOriginalSecCdColumn.ColumnName].Value;
            cndtn.InqOtherEpCd = (string)row.Cells[this._scmInquiryOrderAcs.SCMInquiryResultDataTable.InqOtherEpCdColumn.ColumnName].Value;
            cndtn.InqOtherSecCd = (string)row.Cells[this._scmInquiryOrderAcs.SCMInquiryResultDataTable.InqOtherSecCdColumn.ColumnName].Value;
            cndtn.St_InquiryNumber = (long)row.Cells[this._scmInquiryOrderAcs.SCMInquiryResultDataTable.InquiryNumberColumn.ColumnName].Value;

            cndtn.SalesSlipNum = (string)row.Cells[this._scmInquiryOrderAcs.SCMInquiryResultDataTable.SalesSlipNumColumn.ColumnName].Value;
            cndtn.UpdateDate = (DateTime)row.Cells[this._scmInquiryOrderAcs.SCMInquiryResultDataTable.UpdateDateColumn.ColumnName].Value;
            cndtn.UpdateTime = (int)row.Cells[this._scmInquiryOrderAcs.SCMInquiryResultDataTable.UpdateTimeColumn.ColumnName].Value;
            return cndtn;
        }

        // DEL 2010/06/17 キャンセル追加対応 ---------->>>>>
        // 呼出されていないので封印
        ///// <summary>
        ///// 明細返品チェック処理
        ///// </summary>
        ///// <returns></returns>
        //private int DetailReturnCheck(SCMInquiryOrder cndtn)
        //{
        //    int returnCheckResult = this.ReturnCheck(cndtn, false);

        //    if (returnCheckResult == 1)
        //    {
        //        this.ExecuteSearch(false);
        //    }

        //    return returnCheckResult;
        //}
        // DEL 2010/06/17 キャンセル追加対応 ----------<<<<<
        // 2010/05/27 Add <<<

        //>>>2010/07/30
        /// <summary>
        /// 起動パラメータ取得処理(エントリメイン画面でデリゲートで使用)
        /// </summary>
        /// <param name="param"></param>
        private void GetStartParameter(out string param)
        {
            if (this._commandLineArgs.Length != 0)
            {
                param = this._commandLineArgs[0] + " " + this._commandLineArgs[1];
            }
            else
            {
                param = string.Empty;
            }
        }
        //<<<2010/07/30
    }
}