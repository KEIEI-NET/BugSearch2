//****************************************************************************//
// システム         : PMTAB 自動回答処理(データ登録)
// プログラム名称   : PMTAB 自動回答処理(データ登録)アクセス
// プログラム概要   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2013 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10902622-01 作成担当 : qijh
// 作 成 日  2013/05/29  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// Update Note     : ソースチェック確認事項一覧NO.8の対応                     //
// 管理番号        : 10902622-01                                              //
// Programmer      : wangl2                                                   //
// Date            : 2013/06/10                                               //
//----------------------------------------------------------------------------//
// Update Note     : Redmine#37330 全体設定取得できない場合終了せずように変更 //
// 管理番号        : 10902622-01                                              //
// Programmer      : qijh                                                     //
// Date            : 2013/06/26                                               //
//----------------------------------------------------------------------------//
// Update Note     : Redmine#37389 明細追加情報の作成を補足                   //
// 管理番号        : 10902622-01                                              //
// Programmer      : qijh                                                     //
// Date            : 2013/06/27                                               //
//----------------------------------------------------------------------------//
// Update Note     : Redmine#37389 受注マスタ(車両)の代わりに車両管理データを作成//
// 管理番号        : 10902622-01                                              //
// Programmer      : qijh                                                     //
// Date            : 2013/06/28                                               //
//----------------------------------------------------------------------------//
// Update Note     : Redmine#37474 伝票印刷処理の追加                         //
// 管理番号        : 10902622-01                                              //
// Programmer      : qijh                                                     //
// Date            : 2013/06/29                                               //
//----------------------------------------------------------------------------//
// Update Note     : Redmine#37692 【自動回答処理(データ登録)】SCM連携        //
// 管理番号        : 10902622-01                                              //
// Programmer      : songg                                                    //
// Date            : 2013/07/02                                               //
//----------------------------------------------------------------------------//
// Update Note     : Redmine#37585 自動入金データを作成                       //
// 管理番号        : 10902622-01                                              //
// Programmer      : wangl2                                                   //
// Date            : 2013/07/02                                               //
//----------------------------------------------------------------------------//
// Update Note     : Redmine#37586 伝票分割処理追加                           //
// 管理番号        : 10902622-01                                              //
// Programmer      : qijh                                                     //
// Date            : 2013/07/03                                               //
//----------------------------------------------------------------------------//
// Update Note     : Redmine#37980 SCM明細回答の行番号を仮採番に修正          //
// 管理番号        : 10902622-01                                              //
// Programmer      : qijh                                                     //
// Date            : 2013/07/08                                               //
//----------------------------------------------------------------------------//
// Update Note     : Redmine#38015 売上登録後、SCM受注データ（SCMACODRDATARF）//
//                   のタブレット使用区分に「1」がセットされていません        //
// 管理番号        : 10902622-01                                              //
// Programmer      : songg                                                    //
// Date            : 2013/07/09                                               //
//----------------------------------------------------------------------------//
// Update Note     : Redmine#38014 SCM連携された得意先で売上時、              //
//                   車種と型式がSF側で表示されない                           //
// 管理番号        : 10902622-01                                              //
// Programmer      : wangl2                                                   //
// Date            : 2013/07/09                                               //
//----------------------------------------------------------------------------//
// Update Note     : Redmine#37586 明細追加情報のデータ登録順を修正           //
// 管理番号        : 10902622-01                                              //
// Programmer      : qijh                                                     //
// Date            : 2013/07/09                                               //
//----------------------------------------------------------------------------//
// Update Note     : Redmine#38128 タブレット売上データの判断区分を修正       //
// 管理番号        : 10902622-01                                              //
// Programmer      : qijh                                                     //
// Date            : 2013/07/10                                               //
//----------------------------------------------------------------------------//
// Update Note     : Redmine#38220 不必要なログ出力の削除                     //
// 管理番号        : 10902622-01                                              //
// Programmer      : qijh                                                     //
// Date            : 2013/07/11                                               //
//----------------------------------------------------------------------------//
// Update Note     : Redmine#38246 【自動回答処理(データ登録)】締チェック     //
// 管理番号        : 10902622-01                                              //
// Programmer      : wangl2                                                   //
// Date            : 2013/07/12                                               //
//----------------------------------------------------------------------------//
// Update Note     : Redmine#38277【自動回答処理(データ登録)】与信チェック追加//
// 管理番号        : 10902622-01                                              //
// Programmer      : wangl2                                                   //
// Date            : 2013/07/12                                               //
//----------------------------------------------------------------------------//
// Update Note     : Redmine#38166 印刷用品番の制御に関しての改修             //
// 管理番号        : 10902622-01                                              //
// Programmer      : qijh                                                     //
// Date            : 2013/07/12                                               //
//----------------------------------------------------------------------------//
// Update Note     : Redmine#38166 印刷用品番のディフォルト値を設定           //
// 管理番号        : 10902622-01                                              //
// Programmer      : qijh                                                     //
// Date            : 2013/07/17                                               //
//----------------------------------------------------------------------------//
// Update Note     : Redmine#38541 【自動回答処理(データ登録)】与信チェック   //
// 管理番号        : 10902622-01                                              //
// Programmer      : wangl2                                                   //
// Date            : 2013/07/17                                               //
//----------------------------------------------------------------------------//
// Update Note     : Redmine#38565 売上、売上明細、入金データセット内容を変更 //
// 管理番号        : 10902622-01                                              //
// Programmer      : qijh                                                     //
// Date            : 2013/07/18                                               //
//----------------------------------------------------------------------------//
// Update Note     : Redmine#38510 BL商品コード名称掛率をBLコード名称半角に設定//
// 管理番号        : 10902622-01                                              //
// Programmer      : qijh                                                     //
// Date            : 2013/07/19                                               //
//----------------------------------------------------------------------------//
// Update Note     : Redmine#38783 【自動回答処理(データ登録)】型式のセット仕様変更//
// 管理番号        : 10902622-01                                              //
// Programmer      : qijh                                                     //
// Date            : 2013/07/19                                               //
//----------------------------------------------------------------------------//
// Update Note     : 指摘確認事項一覧№373対応　　　　　　　　　　　　　　　　//
// 管理番号        : 10902622-01                                              //
// Programmer      : 吉岡                                                     //
// Date            : 2013/07/19                                               //
//----------------------------------------------------------------------------//
// Update Note     : Redmine#38198 消費税転嫁方式が非課税の場合、合計金額が「0」//
// 管理番号        : 10902622-01                                              //
// Programmer      : 吉岡                                                     //
// Date            : 2013/07/19                                               //
//----------------------------------------------------------------------------//
// Update Note     : Redmine#38811 【自動回答処理(データ登録)】SCM関連項目のデータセット変更//
// 管理番号        : 10902622-01                                              //
// Programmer      : wangl2                                                   //
// Date            : 2013/07/20                                               //
//----------------------------------------------------------------------------//
// Update Note     : 指摘・確認事項一覧_社内確認用№354～356 Redmine38565     //
// 管理番号        : 10902622-01                                              //
// Programmer      : 吉岡                                                     //
// Date            : 2013/07/22                                               //
//----------------------------------------------------------------------------//
// Update Note     : Redmine#38979  行値引きのデータセットが正しくない        //
// 管理番号        : 10902622-01                                              //
// Programmer      : wangl2                                                   //
// Date            : 2013/07/23                                               //
//----------------------------------------------------------------------------//
// Update Note     : Redmine#38980 粗利率の端数処理を追加する                 //
// 管理番号        : 10902622-01                                              //
// Programmer      : qijh                                                     //
// Date            : 2013/07/23                                               //
//----------------------------------------------------------------------------//
// Update Note     : Redmine#39024 行値引きの売上部品合計（税込） 売上部品合計（税抜き）の設定   //
// 管理番号        : 10902622-01                                              //
// Programmer      : 鄭慕鈞					                                  //
// Date            : 2013/07/23                                               //
//----------------------------------------------------------------------------//
// Update Note     : Redmine#39027 行値引きの消費税端数処理が正しくありません //
// 管理番号        : 10902622-01                                              //
// Programmer      : wangl2					                                  //
// Date            : 2013/07/24                                               //
//----------------------------------------------------------------------------//
// Update Note     : Redmine#39028 行値引きの値引き率が正しくありません       //
// 管理番号        : 10902622-01                                              //
// Programmer      : wangl2					                                  //
// Date            : 2013/07/24                                               //
//----------------------------------------------------------------------------//
// Update Note     : Redmine#39026 行値引きの売上部品小計(税込)を修正         //
// 管理番号        : 10902622-01                                              //
// Programmer      : qijh                                                     //
// Date            : 2013/07/24                                               //
//----------------------------------------------------------------------------//
// Update Note     : Redmine#39166 値引行の金額が計算されていません           //
// 管理番号        : 10902622-01                                              //
// Programmer      : wangl2                                                   //
// Date            : 2013/07/25                                               //
//----------------------------------------------------------------------------//
// Update Note     : 社内指摘一覧№431 回答作成区分が初期値で設定されています //
// 管理番号        :                                                          //
// Programmer      : 湯上                                                     //
// Date            : 2013/07/26                                               //
//----------------------------------------------------------------------------//
// Update Note     : 社内指摘一覧№433 受注の時にもSCM受注データが作成されています //
// 管理番号        :                                                          //
// Programmer      : 湯上                                                     //
// Date            : 2013/07/26                                               //
//----------------------------------------------------------------------------//
// Update Note     : ログ見直し
// 管理番号        : 
// Programmer      : 吉岡
// Date            : 2013/07/29
//----------------------------------------------------------------------------//
// Update Note     : Redmine#39686 
// 管理番号        : 
// Programmer      : 吉岡
// Date            : 2013/08/07
//----------------------------------------------------------------------------//
// Update Note     : Redmine#39780
// 管理番号        : 
// Programmer      : 吉岡
// Date            : 2013/08/08
//----------------------------------------------------------------------------//
// Update Note     : Redmine#39649 データ登録時に操作履歴ログを出力する
// 管理番号        : 10902622-01
// Programmer      : 湯上
// Date            : 2013/08/08
//----------------------------------------------------------------------------//
// Update Note     : Redmine#39649 データ登録時に操作履歴ログを出力する
// 管理番号        : 10902622-01
// Programmer      : 湯上
// Date            : 2013/08/09
//----------------------------------------------------------------------------//
// Update Note     : Redmine#39780 対応の戻し
// 管理番号        : 10902622-01
// Programmer      : 吉岡
// Date            : 2013/08/09
//----------------------------------------------------------------------------//
// Update Note     : Redmine#39820
// 管理番号        : 10902622-01
// Programmer      : 吉岡
// Date            : 2013/08/09
//----------------------------------------------------------------------------//
// Update Note     : Redmine#39942 売上全体設定．伝票作成方法の反映と伝票分割
// 管理番号        : 10902622-01
// Programmer      : 吉岡
// Date            : 2013/08/14
//----------------------------------------------------------------------------//
// Update Note     : Redmine#39979 回答純正商品番号の設定
// 管理番号        : 10902622-01
// Programmer      : 吉岡
// Date            : 2013/08/16
//----------------------------------------------------------------------------//
// Update Note     : Redmine#39972 データ登録、SCM送信後、タブレットへ通知を返す
// 管理番号        : 10902622-01
// Programmer      : 吉岡
// Date            : 2013/08/16
//----------------------------------------------------------------------------//
// Update Note     : Redmine#39992 売上金額処理区分の取得方法の変更に伴う修正
// 管理番号        : 10902622-01
// Programmer      : 吉岡
// Date            : 2013/08/19
//----------------------------------------------------------------------------//
// Update Note     : タブレットからの売上登録時、"送信中"ウィンドウを非表示にする
// 管理番号        : 10902622-01
// Programmer      : 吉岡
// Date            : 2013/08/28
//----------------------------------------------------------------------------//
// Update Note     : Redmine#40121 通知送信修正　通知モード追加
// 管理番号        : 10902622-01
// Programmer      : 湯上
// Date            : 2013/08/26
//----------------------------------------------------------------------------//
// Update Note     : Redmine#40121 30秒タイマーは常駐処理で行うので削除
// 管理番号        : 10902622-01
// Programmer      : 三戸
// Date            : 2013/08/30
//----------------------------------------------------------------------------//
// Update Note     : Redmine#40183 純正商品メーカーコードの設定
// 管理番号        : 10902622-01
// Programmer      : 湯上
// Date            : 2013/08/29
//----------------------------------------------------------------------------//
// Update Note     : Redmine#39979 回答純正商品番号の設定
// 管理番号        : 10902622-01
// Programmer      : 吉岡
// Date            : 2013/08/30
//----------------------------------------------------------------------------//
// Update Note     : 伝票分割不具合対応
// 管理番号        : 10902622-01
// Programmer      : 吉岡
// Date            : 2013/09/11
//----------------------------------------------------------------------------//
// Update Note     : Redmine #40342 リモート伝票発行時エラー対応
// 管理番号        : 
// Programmer      : 30744 湯上
// Date            : 2013/09/19
//----------------------------------------------------------------------------//
// Update Note     : Redmine #49164 伝票重複登録対応
// 管理番号        : 11370016-00
// Programmer      : 陳艶丹
// Date            : 2017/03/30
//----------------------------------------------------------------------------//

using System;
using System.Diagnostics;
using System.Collections;
using System.Threading;
using System.Collections.Generic;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Library.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Globarization;
using Broadleaf.Windows.Forms;
using Broadleaf.Application.Common;
using Broadleaf.Application.Controller.Other;
using Broadleaf.Application.Controller.Util;
using Broadleaf.Application.Controller.Agent;
// ADD 2013/08/08 Redmine#39649 ---------------------------------->>>>>
using Broadleaf.Application.Controller.Facade;
// ADD 2013/08/08 Redmine#39649 ----------------------------------<<<<<


namespace Broadleaf.Application.Controller
{
    using SlipPrtSetServer = SingletonInstance<SlipPrtSetAgent>;   // 伝票印刷設定マスタ // ADD 2013/07/03 qijh Redmine#37586

    /// <summary>
    /// PMTAB 自動回答処理(データ登録)アクセスクラス
    /// </summary>
    public partial class TabSCMSalesDataMaker
    {
        #region ■ プライベートメンバー
        /// <summary>
        /// オンライン種別区分(SCM)
        /// </summary>
        private const int ONLINEKINDDIV_SCM = 10;

        /// <summary>
        /// BLP送信区分(送信)
        /// </summary>
        private const int BLPSENDDIVRF_1 = 1;

        /// <summary>
        /// 起動パラメータ
        /// </summary>
        private string _startParam;

        /// <summary>
        /// 得意先情報取得用アクセス
        /// </summary>
        private CustomerInfoAcs _customerInfoAcs;

        /// <summary>
        /// SCMDBのPMTAB売上情報取得用リモート
        /// </summary>
        private IPmTabSalesSlipDB _iPmTabSalesSlipDB;

        /// <summary>
        /// ユーザーDBのPMTAB受注マスタ(車両)取得用リモート
        /// </summary>
        private IPmTabAcpOdrCarDB _iPmTabAcpOdrCarDB;

        /// <summary>
        /// 売上情報登録用リモート
        /// </summary>
        private IIOWriteControlDB _iIOWriteControlDB;

        /// <summary>
        /// PMTAB全体設定マスタリモート
        /// </summary>
        private IPmTabTtlStCustDB _iPmTabTtlStCustDB;

        // ---------------- ADD 2013/06/29 qijh Redmine#37474 ------------>>>>>
        /// <summary>
        /// 印刷中フラグ
        /// </summary>
        private bool _printThreadOverFlag = true;

        /// <summary>
        /// 印刷中フラグ
        /// </summary>
        public void GetPrintThreadOverFlag(out bool printThreadOverFlag)
        {
            printThreadOverFlag = this._printThreadOverFlag;
        }

        /// <summary>
        /// 伝票印刷フラグ
        /// </summary>
        private bool _printSlipFlag = true;

        /// <summary>
        /// 企業コード
        /// </summary>
        private string _enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

        /// <summary>
        /// 拠点コード
        /// </summary>
        private string _loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;

        /// <summary>
        /// 拠点コード(全体)
        /// </summary>
        private const string ctSectionCode = "00";

        /// <summary>
        /// 売上伝票番号初期値
        /// </summary>
        private static readonly string ctDefaultSalesSlipNum = string.Empty.PadLeft(9, '0');

        /// <summary>
        /// 売上伝票印刷キー情報(key:伝票番号 value:受注ステータス,保存前伝票番号)
        /// </summary>
        private Dictionary<string, SlipPrintInfoValue> _printSalesKeyInfo;
        
        /// <summary>
        /// 受注伝票印刷キー情報(key:伝票番号 value:受注ステータス,保存前伝票番号)
        /// </summary>
        private Dictionary<string, SlipPrintInfoValue> _printAcptKeyInfo;

        /// <summary>
        /// SCM送信フラグ
        /// </summary>
        private bool _isConnScm;

        /// <summary>
        /// QR生成条件
        /// </summary>
        private SalesQRSendCtrlCndtn _qrMakeCndtn;

        /// <summary>
        /// 見積初期値設定マスタ
        /// </summary>
        private EstimateDefSet _estimateDefSet;

        /// <summary>
        /// 見積初期値設定マスタ
        /// </summary>
        private EstimateDefSet EstimateDefSet
        {
            get
            {
                if (null == this._estimateDefSet) GetEstimateDefSet();
                return this._estimateDefSet;
            }
        }

        /// <summary>
        /// 売上全体設定
        /// </summary>
        private SalesTtlSt _salesTtlSt;

        /// <summary>
        /// 売上全体設定
        /// </summary>
        private SalesTtlSt SalesTtlSt
        {
            get
            {
                if (null == this._salesTtlSt) GetSalesTtlSt();
                return _salesTtlSt;
            }
        }

        /// <summary>
        /// 受発注全体設定マスタ
        /// </summary>
        private AcptAnOdrTtlSt _acptAnOdrTtlSt;

        /// <summary>
        /// 受発注全体設定マスタ
        /// </summary>
        private AcptAnOdrTtlSt AcptAnOdrTtlSt
        {
            get
            {
                if (null == this._acptAnOdrTtlSt) GetAcptAnOdrTtlSt();
                return _acptAnOdrTtlSt;
            }
        }
        // ---------------- ADD 2013/06/29 qijh Redmine#37474 ------------<<<<<

        // -------------- ADD 2013/07/12 qijh Redmine#38166 ----------- >>>>>
        /// <summary>
        /// PMタブレット部品検索DBリモート
        /// </summary>
        private IPmtPartsSearchDB _iPmtPartsSearchDB;

        /// <summary>
        /// PMタブレット部品検索DBリモート
        /// </summary>
        private IPmtPartsSearchDB IPmtPartsSearchDB
        {
            get
            {
                if (null == this._iPmtPartsSearchDB)
                    this._iPmtPartsSearchDB = MediationPmtPartsSearchDB.GetPmtPartsSearchDB();
                return this._iPmtPartsSearchDB;
            }
        }

        /// <summary>
        /// PMTAB全体設定（拠点別）アクセス
        /// </summary>
        private PmTabTtlStSecAcs _pmTabTtlStSecAcs;

        /// <summary>
        /// PMTAB全体設定（拠点別）アクセス
        /// </summary>
        private PmTabTtlStSecAcs PmTabTtlStSecAcs
        {
            get
            {
                if (null == this._pmTabTtlStSecAcs)
                    this._pmTabTtlStSecAcs = new PmTabTtlStSecAcs();
                return this._pmTabTtlStSecAcs;
            }
        }

        /// <summary>
        /// PMTAB全体設定（拠点別）マスタ
        /// </summary>
        private PmTabTtlStSec _pmTabTtlStSec;

        /// <summary>
        /// PMTAB全体設定（拠点別）マスタ
        /// </summary>
        private PmTabTtlStSec PmTabTtlStSec
        {
            get
            {
                if (null == this._pmTabTtlStSec) GetPmTabTtlStSec(out this._pmTabTtlStSec);
                return this._pmTabTtlStSec;

            }
        }
        // -------------- ADD 2013/07/12 qijh Redmine#38166 ----------- <<<<<

        // タブレットログ対応　--------------------------------->>>>>
        private const string CLASS_NAME = "TabSCMSalesDataMaker";
        // タブレットログ対応　---------------------------------<<<<<
        private SalesPriceCalculate _salesPriceCalculate;//ADD  2013/07/24 wangl2 FOR Redmine#39028
        // -------------- ADD 2013/07/24 qijh Redmine#39026 ----------- >>>>>
        private List<SalesProcMoney> _salesProcMoneyList;

        /// <summary>
        /// // 売上金額処理区分設定マスタ
        /// </summary>
        private List<SalesProcMoney> SalesProcMoneyList
        {
            get
            {
                if (null == this._salesProcMoneyList) this.ReadInitDataNinth(this._enterpriseCode, this._loginSectionCode, out this._salesProcMoneyList);
                return this._salesProcMoneyList;

            }
        }
        // -------------- ADD 2013/07/24 qijh Redmine#39026 ----------- <<<<<

        // ADD 2013/08/08 Redmine#39649 ----------------------------------------------->>>>>
        private IOperationAuthority _operationAuthority;    // 操作権限の制御オブジェクト

        /// <summary>
        /// 操作権限の制御オブジェクトを取得します。
        /// </summary>
        /// <value>操作権限の制御オブジェクト</value>
        private IOperationAuthority MyOpeCtrl
        {
            get
            {
                if (_operationAuthority == null)
                {
                    _operationAuthority = OpeAuthCtrlFacade.CreateEntryOperationAuthority("PMTAB00152A", this);
                }
                return _operationAuthority;
            }
        }

        // ADD 2013/08/08 Redmine#39649 -----------------------------------------------<<<<<

        // ADD 2013/08/28 吉岡 タブレット 送信中ウィンドウ非表示 ---------->>>>>>>>>>
        /// <summary>
        /// 回答送信処理起動時に、タブレットからの起動を伝える為の引数
        /// </summary>
        private const string CMD_LINE_FOR_PMSCM01100_TABLET = "TABLET";
        // ADD 2013/08/28 吉岡 タブレット 送信中ウィンドウ非表示 ----------<<<<<<<<<<

        #region DEL 2013/08/30 30秒タイマーは常駐処理で行うので削除
        // DEL 2013/08/30 30秒タイマーは常駐処理で行うので削除 --------------------------------->>>>>
        //// ADD 2013/08/26 Redmine#40121 -------------------------------------------------------->>>>>
        //private string _sectionCode;    // 拠点コード
        //private string _sessionId;      // セッションID
        //// ADD 2013/08/26 Redmine#40121 --------------------------------------------------------<<<<<
        // DEL 2013/08/30 30秒タイマーは常駐処理で行うので削除 ---------------------------------<<<<<
        #endregion

        #endregion

        #region ■ コンストラクター
        /// <summary>
        /// コンストラクター
        /// </summary>
        public TabSCMSalesDataMaker(string startParam)
        {
            this._startParam = startParam;
            this._customerInfoAcs = new CustomerInfoAcs();
            this._customerInfoAcs.IsLocalDBRead = false; // サーバー参照
            _salesPriceCalculate = new SalesPriceCalculate();//ADD  2013/07/24 wangl2 FOR Redmine#39028
            this._iPmTabSalesSlipDB = MediationPmTabSalesSlipDB.GetPmTabSalesSlipDB();
            //this._iPmTabAcpOdrCarDB = MediationAcceptOdrCarDB.GetAcceptOdrCarDB();// DEL 2013/06/10 wangl2 FOR ソースチェック確認事項一覧NO.8の対応
            this._iPmTabAcpOdrCarDB = MediationPmTabAcpOdrCarDB.GetPmTabAcpOdrCarDB();// ADD 2013/06/10 wangl2 FOR ソースチェック確認事項一覧NO.8の対応
            this._iIOWriteControlDB = MediationIOWriteControlDB.GetIOWriteControlDB();
            this._iPmTabTtlStCustDB = MediationPmTabTtlStCustDB.GetPmTabTtlStCustDB();

            // タブレットログ対応　--------------------------------->>>>>
            // コンストラクタでログ出力用ディレクトリを作成
            System.IO.Directory.CreateDirectory(EasyLogger.OutPutPath);
            // タブレットログ対応　---------------------------------<<<<<
        }
        #endregion

        #region ■ インターフェース
        /// <summary>
        /// 回答を行う
        /// </summary>
        /// <param name="psEnterpriseCode">企業コード</param>
        /// <param name="psSectionCode">拠点コード</param>
        /// <param name="psBusinessSessionId">業務セッションID</param>
        /// <param name="outErrorMessage">エラーメッセージ</param>
        /// <param name="outCustomerInfo">得意先情報</param>
        /// <returns>ステータス</returns>
        public ConstantManagement.MethodResult Reply(string psEnterpriseCode, string psSectionCode, string psBusinessSessionId, out string outErrorMessage, out CustomerInfo outCustomerInfo)
        {
            // タブレットログ対応　--------------------------------->>>>>
            const string methodName = "Reply";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 開始");
            // UPD 2013/07/29 吉岡 ログ見直し----------------------->>>>>>>>>>>>>>>>>>>>>>>>>>>>
            // EasyLogger.Write(CLASS_NAME, methodName, "▼▼▼▼▼自動回答処理(データ登録)処理　開始▼▼▼▼▼");
            EasyLogger.Write(CLASS_NAME, methodName, "▼自動回答処理(データ登録)処理　開始▼");
            // UPD 2013/07/29 吉岡 ログ見直し-----------------------<<<<<<<<<<<<<<<<<<<<<<<<<<<<

            EasyLogger.Write(CLASS_NAME, methodName,
                "企業コード：" + psEnterpriseCode
                + "　拠点コード：" + psSectionCode
                + "　業務セッションID：" + psBusinessSessionId
                );
            // タブレットログ対応　---------------------------------<<<<<

            #region DEL 2013/08/30 30秒タイマーは常駐処理で行うので削除
            // DEL 2013/08/30 30秒タイマーは常駐処理で行うので削除 --------------------------------->>>>>
            //// ADD 2013/08/26 Redmine#40121 -------------------------------------------->>>>>
            //// タイマー起動
            //this._sectionCode = psSectionCode;
            //this._sessionId = psBusinessSessionId;
            //TimerCallback timerDelegate = new TimerCallback(NotifyTabletByPublish);
            //Timer timer = new Timer(timerDelegate, null, 0, 30000);
            //// ADD 2013/08/26 Redmine#40121 --------------------------------------------<<<<<
            // DEL 2013/08/30 30秒タイマーは常駐処理で行うので削除 ---------------------------------<<<<<
            #endregion

            outErrorMessage = string.Empty;
            outCustomerInfo = null;
            ConstantManagement.MethodResult status = ConstantManagement.MethodResult.ctFNC_NORMAL;
            try
            {
                status = ReplyProc(psEnterpriseCode, psSectionCode, psBusinessSessionId, out outErrorMessage, out outCustomerInfo);
            }
            catch(Exception ex)
            {
                status = ConstantManagement.MethodResult.ctFNC_ERROR;
                outErrorMessage = ex.Message;
                // タブレットログ対応　--------------------------------->>>>>
                EasyLogger.Write(CLASS_NAME, methodName, ex.Message);
                // タブレットログ対応　---------------------------------<<<<<
            }

            // ADD 2013/08/16 吉岡 Redmine#39972 ------------>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            // エラーの場合はここで通知
            if((int)status != 0)
            {
                this.NotifyTabletByPublish((int)status, outErrorMessage, psBusinessSessionId, psSectionCode);
            }
            // ADD 2013/08/16 吉岡 Redmine#39972 ------------<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

            #region DEL 2013/08/30 30秒タイマーは常駐処理で行うので削除
            // DEL 2013/08/30 30秒タイマーは常駐処理で行うので削除 --------------------------------->>>>>
            //// ADD 2013/08/26 Redmine#40121 -------------------------------------------->>>>>
            //// タイマースレッド終了
            //timer.Dispose();
            //// ADD 2013/08/26 Redmine#40121 --------------------------------------------<<<<<
            // DEL 2013/08/30 30秒タイマーは常駐処理で行うので削除 ---------------------------------<<<<<
            #endregion

            // タブレットログ対応　--------------------------------->>>>>
            // UPD 2013/07/29 吉岡 ログ見直し----------------------->>>>>>>>>>>>>>>>>>>>>>>>>>>>
            // EasyLogger.Write(CLASS_NAME, methodName, "▲▲▲▲▲自動回答処理(データ登録)処理　終了▲▲▲▲▲");
            EasyLogger.Write(CLASS_NAME, methodName, "▲自動回答処理(データ登録)処理　終了▲");
            // UPD 2013/07/29 吉岡 ログ見直し-----------------------<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了 status：" + status.ToString());
            // タブレットログ対応　---------------------------------<<<<<
            return status;
        }

        #region DEL 2013/07/03 qijh Redmine#37586
        // ------------- DEL 2013/07/03 qijh Redmine#37586 ---------- >>>>>
        ///// <summary>
        ///// 回答を行う
        ///// </summary>
        ///// <param name="psEnterpriseCode">企業コード</param>
        ///// <param name="psSectionCode">拠点コード</param>
        ///// <param name="psBusinessSessionId">業務セッションID</param>
        ///// <param name="outErrorMessage">エラーメッセージ</param>
        ///// <param name="outCustomerInfo">得意先情報</param>
        ///// <returns>ステータス</returns>
        //private ConstantManagement.MethodResult ReplyProc(string psEnterpriseCode, string psSectionCode, string psBusinessSessionId, out string outErrorMessage, out CustomerInfo outCustomerInfo)
        //{
        //    // タブレットログ対応　--------------------------------->>>>>
        //    const string methodName = "ReplyProc";
        //    EasyLogger.Write(CLASS_NAME, methodName, methodName + " 開始");
        //    // タブレットログ対応　---------------------------------<<<<<

        //    outErrorMessage = string.Empty;
        //    outCustomerInfo = null;

        //    // パラメータチェック
        //    // タブレットログ対応　--------------------------------->>>>>
        //    //if (!IsCheckParamOK(psEnterpriseCode, psSectionCode, psBusinessSessionId, out outErrorMessage))
        //    //    return ConstantManagement.MethodResult.ctFNC_ERROR;
        //    if (!IsCheckParamOK(psEnterpriseCode, psSectionCode, psBusinessSessionId, out outErrorMessage))
        //    {
        //        EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了 パラメータチェック ConstantManagement.MethodResult.ctFNC_ERROR");
        //        return ConstantManagement.MethodResult.ctFNC_ERROR;
        //    }
        //    // タブレットログ対応　---------------------------------<<<<<


        //    // SCM_DBのPMTAB売上データ、PMTAB売上明細データを取得
        //    PmTabSalesSlipWork pmTabSalesSlip;
        //    PmTabSalesDtCarWork pmTabSalesDtCar;
        //    List<PmTabSaleDetailWork> pmTabSaleDetailList;
        //    ConstantManagement.MethodResult status = GetPmTabSalesSlip(psEnterpriseCode, psSectionCode, psBusinessSessionId,
        //        out pmTabSalesSlip, out pmTabSaleDetailList, out pmTabSalesDtCar, out outErrorMessage);
        //    // タブレットログ対応　--------------------------------->>>>>
        //    //if (ConstantManagement.MethodResult.ctFNC_NORMAL != status)
        //    //    return status;
        //    if (ConstantManagement.MethodResult.ctFNC_NORMAL != status)
        //    {
        //        EasyLogger.Write(CLASS_NAME, methodName, "SCM_DBのPMTAB売上データ、PMTAB売上明細データ取得処理でエラーが発生しました ConstantManagement.MethodResult：" + status.ToString());
        //        EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了");
        //        return status;
        //    }
        //    // タブレットログ対応　---------------------------------<<<<<


        //    // USER_DBのPMTAB受注マスタ（車両）を取得
        //    PmTabAcpOdrCarWork pmTabAcpOdrCar;
        //    status = GetPmTabAcpOdrCar(psEnterpriseCode, psSectionCode, psBusinessSessionId, out pmTabAcpOdrCar, out outErrorMessage);
        //    // タブレットログ対応　--------------------------------->>>>>
        //    //if (ConstantManagement.MethodResult.ctFNC_NORMAL != status)
        //    //    return status;
        //    if (ConstantManagement.MethodResult.ctFNC_NORMAL != status)
        //    {
        //        EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了 USER_DBのPMTAB受注マスタ（車両）取得処理でエラーが発生しました ConstantManagement.MethodResult：" + status.ToString());
        //        return status;
        //    }
        //    if (pmTabAcpOdrCar != null)
        //    {
        //        EasyLogger.Write(CLASS_NAME, methodName, "USER_DB PMTAB受注マスタ（車両）"
        //            + "　メーカーコード：" + pmTabAcpOdrCar.MakerCode.ToString()
        //            + "　車種コード：" + pmTabAcpOdrCar.ModelCode.ToString()
        //            + "　車種サブコード：" + pmTabAcpOdrCar.ModelSubCode.ToString()
        //            + "　型式指定番号：" + pmTabAcpOdrCar.ModelDesignationNo.ToString()
        //            + "　類別番号：" + pmTabAcpOdrCar.CategoryNo.ToString()
        //            + "　型式（フル型）：" + pmTabAcpOdrCar.FullModel
        //            );
        //    }
        //    // タブレットログ対応　---------------------------------<<<<<

            
        //    // 得意先情報を取得
        //    CustomerInfo customerInfo = null;
        //    status = GetCustomerInfo(pmTabSalesSlip.EnterpriseCode, pmTabSalesSlip.CustomerCode, out customerInfo, out outErrorMessage);
        //    // タブレットログ対応　--------------------------------->>>>>
        //    //if (ConstantManagement.MethodResult.ctFNC_NORMAL != status)
        //    //    return status;
        //    if (ConstantManagement.MethodResult.ctFNC_NORMAL != status)
        //    {
        //        EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了 得意先情報を取得 ConstantManagement.MethodResult：" + status.ToString());
        //        return status;
        //    }
        //    if (customerInfo != null)
        //    {
        //        EasyLogger.Write(CLASS_NAME, methodName, "得意先情報"
        //            + "　得意先コード：" + customerInfo.CustomerCode
        //            + "　得意先名：" + customerInfo.Name
        //            );
        //    }
        //    // タブレットログ対応　---------------------------------<<<<<
        //    outCustomerInfo = customerInfo;


        //    // BLP送信区分を取得
        //    int sendingDiv = 0;
        //    status = GetBLPSendingDiv(psEnterpriseCode, customerInfo.CustomerCode, out sendingDiv, out outErrorMessage);
        //    // タブレットログ対応　--------------------------------->>>>>
        //    //if (ConstantManagement.MethodResult.ctFNC_NORMAL != status)
        //    //    return status;
        //    if (ConstantManagement.MethodResult.ctFNC_NORMAL != status)
        //    {
        //        EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了 BLP送信区分を取得 ConstantManagement.MethodResult：" + status.ToString());
        //        return status;
        //    }
        //    EasyLogger.Write(CLASS_NAME, methodName, "BLP送信区分：" + sendingDiv.ToString());
        //    // タブレットログ対応　---------------------------------<<<<<


        //    CustomSerializeArrayList salesScmCustArrayList = new CustomSerializeArrayList(); // 登録リモート用のパラメータ
        //    // 売上データを作成
        //    SalesSlipWork updSalesSlip = GetUpdSalesSlip(pmTabSalesSlip);
        //    salesScmCustArrayList.Add(updSalesSlip);
        //    // 売上データ補正
        //    ReviseSalesSlip(updSalesSlip, customerInfo);


        //    // 売上明細データを作成
        //    ArrayList updSalesDetailList = new ArrayList();
        //    foreach (PmTabSaleDetailWork pmTabSalesDetail in pmTabSaleDetailList)
        //        updSalesDetailList.Add(GetUpdSalesDetail(pmTabSalesDetail, ONLINEKINDDIV_SCM == customerInfo.OnlineKindDiv));
        //    salesScmCustArrayList.Add(updSalesDetailList);
        //    // 売上明細データ補正
        //    foreach (SalesDetailWork salesDetail in updSalesDetailList)
        //        ReviseSalesDetail(updSalesSlip, salesDetail);

            
        //    // 車両管理データを作成
        //    ArrayList updAcceptOdrCarList = new ArrayList();
        //    //AcceptOdrCarWork updAcceptOdrCar = GetUpdAcceptOdrCar(pmTabAcpOdrCar); // DEL 2013/06/28 qijh Redmine#37389
        //    CarManagementWork updAcceptOdrCar = GetUpdCarManagement(pmTabAcpOdrCar, pmTabSalesSlip, customerInfo); // ADD 2013/06/28 qijh Redmine#37389
        //    updAcceptOdrCarList.Add(updAcceptOdrCar);
        //    salesScmCustArrayList.Add(updAcceptOdrCarList);


        //    // 明細追加情報を作成
        //    salesScmCustArrayList.Add(GetSlipDetailAddInfoWorkList(updSalesDetailList
        //        , updAcceptOdrCar  // ADD 2013/06/28 qijh Redmine#37389
        //        )); // ADD 2013/06/27 qijh Redmine#37389

        //    this._isConnScm = false; // ADD 2013/06/29 qijh Redmine#37474

        //    // SCM回答情報を作成
        //    if (ONLINEKINDDIV_SCM == customerInfo.OnlineKindDiv && BLPSENDDIVRF_1 == sendingDiv)
        //    {
        //        // オンライン区分が10（SCM）且つBLP送信区分が「１：送信する」の場合
        //        this._isConnScm = true; // ADD 2013/06/29 qijh Redmine#37474

        //        // SCM受注データを作成
        //        SCMAcOdrDataWork updSCMAcOdrData = GetUpdSCMAcOdrData(updSalesSlip, customerInfo);
        //        salesScmCustArrayList.Add(updSCMAcOdrData);


        //        // SCM受注明細データ（回答）を作成
        //        ArrayList updSCMAcOdrDtlAsList = new ArrayList();
        //        foreach (SalesDetailWork salesDetail in updSalesDetailList)
        //            updSCMAcOdrDtlAsList.Add(GetUpdSCMAcOdrDtlAs(salesDetail, customerInfo));
        //        salesScmCustArrayList.Add(updSCMAcOdrDtlAsList);
        //        // SCM受注明細データ（回答）補正
        //        for (int index = 0; index < updSalesDetailList.Count; index++)
        //            ((SCMAcOdrDtlAsWork)updSCMAcOdrDtlAsList[index]).PmPrsntCount = GetPmPrsntCount(updSalesSlip, (SalesDetailWork)updSalesDetailList[index]);// PM現在庫数

                
        //        // SCM受注データ（車両情報）を作成
        //        SCMAcOdrDtCarWork updSCMAcOdrDtCar = GetUpdSCMAcOdrDtCar(updAcceptOdrCar, updSalesSlip, pmTabSalesDtCar, customerInfo
        //            , pmTabAcpOdrCar       // ADD 2013/06/28 qijh Redmine#37389
        //            );
        //        salesScmCustArrayList.Add(updSCMAcOdrDtCar);
        //    }

        //    // --------------- ADD START 2013/07/02 wangl2 FOR Redmine#37585------>>>>
        //    SearchDepsitMain depsitMain = null;                             // 入金データオブジェクト
        //    SearchDepositAlw depositAlw = null;                             // 入金引当データオブジェクト
        //    if ((updSalesDetailList != null) && (updSalesDetailList.Count != 0))
        //    {
        //        this.GetCurrentDepsitMain(ref updSalesSlip, out depsitMain, out depositAlw);
        //    }
        //    if (updSalesSlip.AccRecDivCd == 0)
        //    {
        //        salesScmCustArrayList.Add(ParamDataFromUIData(depsitMain)); // 入金データ追加
        //        salesScmCustArrayList.Add((DepositAlwWork)DBAndXMLDataMergeParts.CopyPropertyInClass(depositAlw, typeof(DepositAlwWork)));
        //    }
        //    // --------------- ADD END 2013/07/02 wangl2 FOR Redmine#37585--------<<<<

        //    // データ登録
        //    status = Write(ref salesScmCustArrayList, out outErrorMessage);
        //    // タブレットログ対応　--------------------------------->>>>>
        //    //if (ConstantManagement.MethodResult.ctFNC_NORMAL != status)
        //    //    return status;
        //    if (ConstantManagement.MethodResult.ctFNC_NORMAL != status)
        //    {
        //        EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了 データ登録処理でエラーが発生しました ConstantManagement.MethodResult：" + status.ToString());
        //        return status;
        //    }
        //    // タブレットログ対応　---------------------------------<<<<<


        //    // SCMへ送信
        //    SendScmData(GetSCMAcOdrDtlAsFromApRet(salesScmCustArrayList));
        //    // タブレットログ対応　--------------------------------->>>>>
        //    EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了 ConstantManagement.MethodResult.ctFNC_NORMAL");
        //    // タブレットログ対応　---------------------------------<<<<<

        //    // 伝票印刷
        //    PrintSlipMain(salesScmCustArrayList, customerInfo); // ADD 2013/06/29 qijh Redmine#37474

        //    return ConstantManagement.MethodResult.ctFNC_NORMAL;
        //}
        // ------------- DEL 2013/07/03 qijh Redmine#37586 ---------- <<<<<
        #endregion DEL 2013/07/03 qijh Redmine#37586

        /// <summary>
        /// 回答を行う
        /// </summary>
        /// <param name="psEnterpriseCode">企業コード</param>
        /// <param name="psSectionCode">拠点コード</param>
        /// <param name="psBusinessSessionId">業務セッションID</param>
        /// <param name="outErrorMessage">エラーメッセージ</param>
        /// <param name="outCustomerInfo">得意先情報</param>
        /// <returns>ステータス</returns>
        private ConstantManagement.MethodResult ReplyProc(string psEnterpriseCode, string psSectionCode, string psBusinessSessionId, out string outErrorMessage, out CustomerInfo outCustomerInfo)
        {
            const string methodName = "ReplyProc";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 開始");

            outErrorMessage = string.Empty;
            outCustomerInfo = null;

            // パラメータチェック
            if (!IsCheckParamOK(psEnterpriseCode, psSectionCode, psBusinessSessionId, out outErrorMessage))
            {
                EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了 パラメータチェック ConstantManagement.MethodResult.ctFNC_ERROR");
                return ConstantManagement.MethodResult.ctFNC_ERROR;
            }

            // ADD 2013/08/01 三戸 Redmine#39486 --------->>>>>>>>>>>>>>>>>>>>>>>>
            // メーカーリスト取得
            InitMaker(psEnterpriseCode);
            // ADD 2013/08/01 三戸 Redmine#39486 ---------<<<<<<<<<<<<<<<<<<<<<<<<

            // SCM_DBのPMTAB売上データ、PMTAB売上明細データを取得
            PmTabSalesSlipWork pmTabSalesSlip;
            PmTabSalesDtCarWork pmTabSalesDtCar;
            List<PmTabSaleDetailWork> pmTabSaleDetailList;
            ConstantManagement.MethodResult status = GetPmTabSalesSlip(psEnterpriseCode, psSectionCode, psBusinessSessionId,
                out pmTabSalesSlip, out pmTabSaleDetailList, out pmTabSalesDtCar, out outErrorMessage);
            if (ConstantManagement.MethodResult.ctFNC_NORMAL != status)
            {
                EasyLogger.Write(CLASS_NAME, methodName, "SCM_DBのPMTAB売上データ、PMTAB売上明細データ取得処理でエラーが発生しました ConstantManagement.MethodResult：" + status.ToString());
                EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了");
                return status;
            }


            // USER_DBのPMTAB受注マスタ（車両）を取得
            PmTabAcpOdrCarWork pmTabAcpOdrCar;
            status = GetPmTabAcpOdrCar(psEnterpriseCode, psSectionCode, psBusinessSessionId, out pmTabAcpOdrCar, out outErrorMessage);
            if (ConstantManagement.MethodResult.ctFNC_NORMAL != status)
            {
                EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了 USER_DBのPMTAB受注マスタ（車両）取得処理でエラーが発生しました ConstantManagement.MethodResult：" + status.ToString());
                return status;
            }
            if (pmTabAcpOdrCar != null)
            {
                EasyLogger.Write(CLASS_NAME, methodName, "USER_DB PMTAB受注マスタ（車両）"
                    + "　メーカーコード：" + pmTabAcpOdrCar.MakerCode.ToString()
                    + "　車種コード：" + pmTabAcpOdrCar.ModelCode.ToString()
                    + "　車種サブコード：" + pmTabAcpOdrCar.ModelSubCode.ToString()
                    + "　型式指定番号：" + pmTabAcpOdrCar.ModelDesignationNo.ToString()
                    + "　類別番号：" + pmTabAcpOdrCar.CategoryNo.ToString()
                    + "　型式（フル型）：" + pmTabAcpOdrCar.FullModel
                    );
            }
           
            // --------------- ADD START 2013/07/12 wangl2 FOR Redmine#38277------>>>>
            if (pmTabSalesSlip.AcptAnOdrStatus == (int)AcptAnOdrStatusState.Sales)
            {
                if (CheckCredit(pmTabSalesSlip))
                {
                    status = ConstantManagement.MethodResult.ctFNC_ERROR;
                    outErrorMessage = "与信限度額を超えている為、登録できません。";
                    EasyLogger.Write(CLASS_NAME, methodName, methodName + outErrorMessage + status.ToString());
                    return status;

                }
            }
            // --------------- ADD END 2013/07/12 wangl2 FOR Redmine#38277--------<<<<
            // 得意先情報を取得
            CustomerInfo customerInfo = null;
            status = GetCustomerInfo(pmTabSalesSlip.EnterpriseCode, pmTabSalesSlip.CustomerCode, out customerInfo, out outErrorMessage);
            if (ConstantManagement.MethodResult.ctFNC_NORMAL != status)
            {
                EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了 得意先情報を取得 ConstantManagement.MethodResult：" + status.ToString());
                return status;
            }
            if (customerInfo != null)
            {
                EasyLogger.Write(CLASS_NAME, methodName, "得意先情報"
                    + "　得意先コード：" + customerInfo.CustomerCode
                    + "　得意先名：" + customerInfo.Name
                    );
            }
            outCustomerInfo = customerInfo;


            // BLP送信区分を取得
            int sendingDiv = 0;
            // UPD 吉岡 2013/08/09 Redmine#39820 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            #region 旧ソース
            //status = GetBLPSendingDiv(psEnterpriseCode, customerInfo.CustomerCode, out sendingDiv, out outErrorMessage);
            //if (ConstantManagement.MethodResult.ctFNC_NORMAL != status)
            //{
            //    EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了 BLP送信区分を取得 ConstantManagement.MethodResult：" + status.ToString());
            //    return status;
            //}
            //EasyLogger.Write(CLASS_NAME, methodName, "BLP送信区分：" + sendingDiv.ToString());
            #endregion
            if (pmTabSaleDetailList != null && pmTabSaleDetailList.Count > 0)
            {
                // 全明細に同じ値が設定されているので、1行目を設定
                sendingDiv = pmTabSaleDetailList[0].AutoAnswerDivSCM;
            }
            // UPD 吉岡 2013/08/09 Redmine#39820 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

            // SCM連携か
            this._isConnScm = false;
            // UPD 2013/07/26 yugami 社内指摘一覧№433対応 ---------------------------------------------->>>>>
            //if (ONLINEKINDDIV_SCM == customerInfo.OnlineKindDiv && BLPSENDDIVRF_1 == sendingDiv)
            if (ONLINEKINDDIV_SCM == customerInfo.OnlineKindDiv && BLPSENDDIVRF_1 == sendingDiv && pmTabSalesSlip.AcptAnOdrStatus == (int)AcptAnOdrStatus.Sales)
            // UPD 2013/07/26 yugami 社内指摘一覧№433対応 ----------------------------------------------<<<<<
                this._isConnScm = true;


            // 売上データを作成
            SalesSlip updSalesSlip = GetUpdSalesSlip(pmTabSalesSlip);
            // 売上データ補正
            ReviseSalesSlip(updSalesSlip, customerInfo);
            // --------------- ADD START 2013/07/12 wangl2 FOR Redmine#38246------>>>>
            if (!this.CheckAddUp(psSectionCode, pmTabSalesSlip.CustomerCode, updSalesSlip.AddUpADate, out outErrorMessage))
            {
                status = ConstantManagement.MethodResult.ctFNC_ERROR;
                EasyLogger.Write(CLASS_NAME, methodName, methodName + outErrorMessage + status.ToString());
                return status;
            }
            // --------------- ADD END 2013/07/12 wangl2 FOR Redmine#38246--------<<<<

            // 売上明細データを作成
            List<SalesDetail> updSalesDetailList = new List<SalesDetail>();
            for (int i = 0; i < pmTabSaleDetailList.Count; i++)
                //updSalesDetailList.Add(GetUpdSalesDetail(pmTabSaleDetailList[i], ONLINEKINDDIV_SCM == customerInfo.OnlineKindDiv));// DEL 2013/07/20 wangl2 FOR Redmine#38811
                updSalesDetailList.Add(GetUpdSalesDetail(pmTabSaleDetailList[i], this._isConnScm));// ADD 2013/07/20 wangl2 FOR Redmine#38811
            // 売上明細データ補正
            // --------------- DEL START 2013/07/23 wangl2 FOR Redmine#38979------>>>>
            //foreach (SalesDetail salesDetail in updSalesDetailList)
            //    ReviseSalesDetail(updSalesSlip, salesDetail);
            // --------------- DEL END 2013/07/23 wangl2 FOR Redmine#38979--------<<<<
            // --------------- ADD START 2013/07/23 wangl2 FOR Redmine#38979------>>>>
            foreach (SalesDetail salesDetail in updSalesDetailList)
            {
                // 売上伝票区分（明細）は 値引場合
                if (salesDetail.SalesSlipCdDtl != 2)
                {
                    ReviseSalesDetail(updSalesSlip, salesDetail);
                }  
            }
            // --------------- ADD END 2013/07/23 wangl2 FOR Redmine#38979--------<<<<

            // 車両管理データを作成
            CarManagementWork carManagement = GetUpdCarManagement(pmTabAcpOdrCar, pmTabSalesSlip, customerInfo);


            // --------------------- UPD 2017/03/30 陳艶丹 Redmine#49164 ---------------- >>>>
            // 同一セッションIDが存在フラグ
            bool sameSessionIdFlg = false;
            // PMTABセッション管理データを作成
            ArrayList pmtabSeesionMngList = GetSessionMngWork(pmTabSalesSlip);
            
            // 伝票分割を行う
            //CustomSerializeArrayList salesScmCustArrayList = SplitSlipData(updSalesSlip, updSalesDetailList, carManagement, pmTabSalesDtCar, pmTabAcpOdrCar, customerInfo);
            CustomSerializeArrayList salesScmCustArrayList = SplitSlipData(updSalesSlip, updSalesDetailList, carManagement, pmTabSalesDtCar, pmTabAcpOdrCar, customerInfo, pmtabSeesionMngList);
            // データ登録
            //status = Write(ref salesScmCustArrayList, out outErrorMessage);
            status = Write(ref salesScmCustArrayList, out sameSessionIdFlg, out outErrorMessage);

            if (sameSessionIdFlg)
            {
                EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了 ConstantManagement.MethodResult.ctFNC_NORMAL");
                // タブレットへ通知
                this.NotifyTabletByPublish((int)status, outErrorMessage, psBusinessSessionId, psSectionCode);
                return ConstantManagement.MethodResult.ctFNC_NORMAL;
            }
            // --------------------- ADD 2017/03/30 陳艶丹 Redmine#49164 ---------------- <<<<
            if (ConstantManagement.MethodResult.ctFNC_NORMAL != status)
            {
                EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了 データ登録処理でエラーが発生しました ConstantManagement.MethodResult：" + status.ToString());
                return status;
            }

            // SCMへ送信
            SendScmData(salesScmCustArrayList);
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了 ConstantManagement.MethodResult.ctFNC_NORMAL");

            // ADD 2013/08/16 吉岡 Redmine#39972 ------------>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            // タブレットへ通知
            this.NotifyTabletByPublish((int)status, outErrorMessage, psBusinessSessionId, psSectionCode);
            // ADD 2013/08/16 吉岡 Redmine#39972 ------------<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

            // 伝票印刷
            PrintSlipMain(salesScmCustArrayList, customerInfo);

            return ConstantManagement.MethodResult.ctFNC_NORMAL;
        }
        #endregion ■ インターフェース

        #region ■ チェック処理
        /// <summary>
        /// 入力チェックを行う
        /// </summary>
        /// <param name="psEnterpriseCode">企業コード</param>
        /// <param name="psSectionCode">拠点コード</param>
        /// <param name="psBusinessSessionId">業務セッションID</param>
        /// <param name="outErrorMessage">エラーメッセージ</param>
        /// <returns>true:チェックOK　false:チェックNG</returns>
        private bool IsCheckParamOK(string psEnterpriseCode, string psSectionCode, string psBusinessSessionId, out string outErrorMessage)
        {
            // タブレットログ対応　--------------------------------->>>>>
            const string methodName = "IsCheckParamOK";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 開始");
            // タブレットログ対応　---------------------------------<<<<<

            outErrorMessage = "Not Found";
            // タブレットログ対応　--------------------------------->>>>>
            //if (null == psEnterpriseCode || null == psSectionCode || null == psBusinessSessionId)
            //    return false;
            //if (string.IsNullOrEmpty(psEnterpriseCode.Trim()) || string.IsNullOrEmpty(psSectionCode.Trim()) || string.IsNullOrEmpty(psBusinessSessionId.Trim()))
            //    return false;
            if (null == psEnterpriseCode || null == psSectionCode || null == psBusinessSessionId)
            {
                EasyLogger.Write(CLASS_NAME, methodName, "パラメータチェック　エラー"
                    + " psEnterpriseCode：" + psEnterpriseCode
                    + " psSectionCode：" + psSectionCode
                    + " psBusinessSessionId：" + psBusinessSessionId
                );
                EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了");
                return false;
            }
            if (string.IsNullOrEmpty(psEnterpriseCode.Trim()) || string.IsNullOrEmpty(psSectionCode.Trim()) || string.IsNullOrEmpty(psBusinessSessionId.Trim()))
            {
                EasyLogger.Write(CLASS_NAME, methodName, "パラメータチェック　エラー"
                    + " psEnterpriseCode：" + psEnterpriseCode
                    + " psSectionCode：" + psSectionCode
                    + " psBusinessSessionId：" + psBusinessSessionId
                );
                EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了");
                return false;
            }
            // タブレットログ対応　---------------------------------<<<<<

            outErrorMessage = string.Empty;
            // タブレットログ対応　--------------------------------->>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了");
            // タブレットログ対応　---------------------------------<<<<<
            return true;
        }

        // --------------- ADD START 2013/07/12 wangl2 FOR Redmine#38246------>>>>
        /// <summary>
        /// 月次更新、締更新チェック
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="prevTotalDay">売上日</param>
        /// <param name="outErrorMessage">エラーメッセージ</param>
        /// <returns></returns>
        private bool CheckAddUp(string sectionCode, int customerCode, DateTime prevTotalDay, out string outErrorMessage)
        {
            outErrorMessage = string.Empty;
            // 締日算出モジュール
            TotalDayCalculator _totalDayCalculator = TotalDayCalculator.GetInstance();
            // 月次更新チェック(締済みであればtrueが返ってくる)
            if (_totalDayCalculator.CheckMonthlyAccRec(sectionCode, customerCode, prevTotalDay))
            {
                outErrorMessage = "前回月次更新日以前の為、登録できません。";
                return false;
            }
            // 締更新チェック(締済みであればtrueが返ってくる)
            if (_totalDayCalculator.CheckDmdC(sectionCode, customerCode, prevTotalDay))
            {
                outErrorMessage = "前回請求締日以前の為、登録できません。";
                return false;
            }
            return true;
        }
        // --------------- ADD END 2013/07/12 wangl2 FOR Redmine#38246--------<<<<

        // --------------- ADD START 2013/07/12 wangl2 FOR Redmine#38277------>>>>
        /// <summary>
        /// 与信額チェック
        /// </summary>
        /// <param name="pmTabSalesSlipWork"></param>
        /// <returns>true:処理中止 false:処理続行</returns>
        private bool CheckCredit(PmTabSalesSlipWork pmTabSalesSlipWork)
        {
            // 与信額チェックフラグ
            bool Flag = false;
            CustomerChange customerChange;
            CustomerChangeAcs customerChangeAcs = new CustomerChangeAcs();
            int status = customerChangeAcs.Read(out customerChange, this._enterpriseCode, pmTabSalesSlipWork.ClaimCode);
            if (status != 0)
                //return true;// DEL 2013/07/17 wangl2 FOR Redmine#38541
                return Flag;// ADD 2013/07/17 wangl2 FOR Redmine#38541
            CustomerInfo claim;
            status = this._customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, this._enterpriseCode, pmTabSalesSlipWork.ClaimCode, true, false, out claim);
            if (status != 0)
                return true;
            if ((customerChange != null) &&
                (customerChange.CustomerCode != 0) &&
                (claim.CreditMngCode != 0))
            {
                // 合計金額 + 現在売掛残高
                long salesTotalTaxInc = 0;
                if (pmTabSalesSlipWork.SalesSlipNum == ctDefaultSalesSlipNum)
                {
                    salesTotalTaxInc = pmTabSalesSlipWork.SalesTotalTaxInc + customerChange.PrsntAccRecBalance;
                }
                else
                {
                    salesTotalTaxInc = customerChange.PrsntAccRecBalance;
                }

                // 与信限度額チェック
                if ((salesTotalTaxInc > customerChange.CreditMoney) &&
                    (customerChange.CreditMoney != 0))
                {
                    Flag = true;
                }
            }
            return Flag;
        }
        // --------------- ADD END 2013/07/12 wangl2 FOR Redmine#38277--------<<<<
        #endregion ■ チェック処理

        #region ■ 売上データ作成
        /// <summary>
        /// 売上データを作成
        /// </summary>
        /// <param name="pmTabSalesSlip">PMTAB売上データ</param>
        /// <returns>売上データ</returns>
        //private SalesSlipWork GetUpdSalesSlip(PmTabSalesSlipWork pmTabSalesSlip) // DEL 2013/07/03 qijh Redmine#37586
        private SalesSlip GetUpdSalesSlip(PmTabSalesSlipWork pmTabSalesSlip) // ADD 2013/07/03 qijh Redmine#37586
        {
            // タブレットログ対応　--------------------------------->>>>>
            const string methodName = "GetUpdSalesSlip";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 開始");
            // タブレットログ対応　---------------------------------<<<<<

            // SalesSlipWork retSalesSlip = new SalesSlipWork(); // DEL 2013/07/03 qijh Redmine#37586
            SalesSlip retSalesSlip = new SalesSlip(); // ADD 2013/07/03 qijh Redmine#37586
            retSalesSlip.EnterpriseCode = pmTabSalesSlip.EnterpriseCode; // 企業コード
            retSalesSlip.UpdEmployeeCode = pmTabSalesSlip.UpdEmployeeCode; // 更新従業員コード
            retSalesSlip.UpdAssemblyId1 = pmTabSalesSlip.UpdAssemblyId1; // 更新アセンブリID1
            retSalesSlip.UpdAssemblyId2 = pmTabSalesSlip.UpdAssemblyId2; // 更新アセンブリID2
            retSalesSlip.LogicalDeleteCode = pmTabSalesSlip.LogicalDeleteCode; // 論理削除区分
            retSalesSlip.AcptAnOdrStatus = pmTabSalesSlip.AcptAnOdrStatus; // 受注ステータス
            retSalesSlip.SalesSlipNum = pmTabSalesSlip.SalesSlipNum; // 売上伝票番号
            retSalesSlip.SectionCode = pmTabSalesSlip.SectionCode; // 拠点コード
            retSalesSlip.SubSectionCode = pmTabSalesSlip.SubSectionCode; // 部門コード
            retSalesSlip.DebitNoteDiv = pmTabSalesSlip.DebitNoteDiv; // 赤伝区分
            retSalesSlip.DebitNLnkSalesSlNum = pmTabSalesSlip.DebitNLnkSalesSlNum; // 赤黒連結売上伝票番号
            retSalesSlip.SalesSlipCd = pmTabSalesSlip.SalesSlipCd; // 売上伝票区分
            retSalesSlip.SalesGoodsCd = pmTabSalesSlip.SalesGoodsCd; // 売上商品区分
            retSalesSlip.AccRecDivCd = pmTabSalesSlip.AccRecDivCd; // 売掛区分
            retSalesSlip.SalesInpSecCd = pmTabSalesSlip.SalesInpSecCd; // 売上入力拠点コード
            retSalesSlip.DemandAddUpSecCd = pmTabSalesSlip.DemandAddUpSecCd; // 請求計上拠点コード
            retSalesSlip.ResultsAddUpSecCd = pmTabSalesSlip.ResultsAddUpSecCd; // 実績計上拠点コード
            retSalesSlip.UpdateSecCd = pmTabSalesSlip.UpdateSecCd; // 更新拠点コード
            retSalesSlip.SalesSlipUpdateCd = pmTabSalesSlip.SalesSlipUpdateCd; // 売上伝票更新区分
            retSalesSlip.SearchSlipDate = pmTabSalesSlip.SearchSlipDate; // 伝票検索日付
            retSalesSlip.ShipmentDay = TDateTime.LongDateToDateTime("yyyymmdd", pmTabSalesSlip.ShipmentDay); // 出荷日付
            retSalesSlip.SalesDate = TDateTime.LongDateToDateTime("yyyymmdd", pmTabSalesSlip.SalesDate); // 売上日付
            retSalesSlip.AddUpADate = pmTabSalesSlip.AddUpADate; // 計上日付
            retSalesSlip.DelayPaymentDiv = pmTabSalesSlip.DelayPaymentDiv; // 来勘区分
            retSalesSlip.EstimateFormNo = pmTabSalesSlip.EstimateFormNo; // 見積書番号
            retSalesSlip.EstimateDivide = pmTabSalesSlip.EstimateDivide; // 見積区分
            retSalesSlip.InputAgenCd = pmTabSalesSlip.InputAgenCd; // 入力担当者コード
            retSalesSlip.InputAgenNm = pmTabSalesSlip.InputAgenNm; // 入力担当者名称
            retSalesSlip.SalesInputCode = pmTabSalesSlip.SalesInputCode; // 売上入力者コード
            retSalesSlip.SalesInputName = pmTabSalesSlip.SalesInputName; // 売上入力者名称
            retSalesSlip.FrontEmployeeCd = pmTabSalesSlip.FrontEmployeeCd; // 受付従業員コード
            retSalesSlip.FrontEmployeeNm = pmTabSalesSlip.FrontEmployeeNm; // 受付従業員名称
            retSalesSlip.SalesEmployeeCd = pmTabSalesSlip.SalesEmployeeCd; // 販売従業員コード
            retSalesSlip.SalesEmployeeNm = pmTabSalesSlip.SalesEmployeeNm; // 販売従業員名称
            retSalesSlip.TotalAmountDispWayCd = pmTabSalesSlip.TotalAmountDispWayCd; // 総額表示方法区分
            retSalesSlip.TtlAmntDispRateApy = pmTabSalesSlip.TtlAmntDispRateApy; // 総額表示掛率適用区分
            retSalesSlip.SalesTotalTaxInc = pmTabSalesSlip.SalesTotalTaxInc; // 売上伝票合計（税込み）
            retSalesSlip.SalesTotalTaxExc = pmTabSalesSlip.SalesTotalTaxExc; // 売上伝票合計（税抜き）
            retSalesSlip.SalesPrtTotalTaxInc = pmTabSalesSlip.SalesPrtTotalTaxInc; // 売上部品合計（税込み）
            retSalesSlip.SalesPrtTotalTaxExc = pmTabSalesSlip.SalesPrtTotalTaxExc; // 売上部品合計（税抜き）
            retSalesSlip.SalesWorkTotalTaxInc = pmTabSalesSlip.SalesWorkTotalTaxInc; // 売上作業合計（税込み）
            retSalesSlip.SalesWorkTotalTaxExc = pmTabSalesSlip.SalesWorkTotalTaxExc; // 売上作業合計（税抜き）
            retSalesSlip.SalesSubtotalTaxInc = pmTabSalesSlip.SalesSubtotalTaxInc; // 売上小計（税込み）
            retSalesSlip.SalesSubtotalTaxExc = pmTabSalesSlip.SalesSubtotalTaxExc; // 売上小計（税抜き）
            retSalesSlip.SalesPrtSubttlInc = pmTabSalesSlip.SalesPrtSubttlInc; // 売上部品小計（税込み）
            retSalesSlip.SalesPrtSubttlExc = pmTabSalesSlip.SalesPrtSubttlExc; // 売上部品小計（税抜き）
            retSalesSlip.SalesWorkSubttlInc = pmTabSalesSlip.SalesWorkSubttlInc; // 売上作業小計（税込み）
            retSalesSlip.SalesWorkSubttlExc = pmTabSalesSlip.SalesWorkSubttlExc; // 売上作業小計（税抜き）
            retSalesSlip.SalesNetPrice = pmTabSalesSlip.SalesNetPrice; // 売上正価金額
            retSalesSlip.SalesSubtotalTax = pmTabSalesSlip.SalesSubtotalTax; // 売上小計（税）
            retSalesSlip.ItdedSalesOutTax = pmTabSalesSlip.ItdedSalesOutTax; // 売上外税対象額
            retSalesSlip.ItdedSalesInTax = pmTabSalesSlip.ItdedSalesInTax; // 売上内税対象額
            retSalesSlip.SalSubttlSubToTaxFre = pmTabSalesSlip.SalSubttlSubToTaxFre; // 売上小計非課税対象額
            retSalesSlip.SalesOutTax = pmTabSalesSlip.SalesOutTax; // 売上金額消費税額（外税）
            retSalesSlip.SalAmntConsTaxInclu = pmTabSalesSlip.SalAmntConsTaxInclu; // 売上金額消費税額（内税）
            retSalesSlip.SalesDisTtlTaxExc = pmTabSalesSlip.SalesDisTtlTaxExc; // 売上値引金額計（税抜き）
            retSalesSlip.ItdedSalesDisOutTax = pmTabSalesSlip.ItdedSalesDisOutTax; // 売上値引外税対象額合計
            retSalesSlip.ItdedSalesDisInTax = pmTabSalesSlip.ItdedSalesDisInTax; // 売上値引内税対象額合計
            retSalesSlip.ItdedPartsDisOutTax = pmTabSalesSlip.ItdedPartsDisOutTax; // 部品値引対象額合計（税抜き）
            retSalesSlip.ItdedPartsDisInTax = pmTabSalesSlip.ItdedPartsDisInTax; // 部品値引対象額合計（税込み）
            retSalesSlip.ItdedWorkDisOutTax = pmTabSalesSlip.ItdedWorkDisOutTax; // 作業値引対象額合計（税抜き）
            retSalesSlip.ItdedWorkDisInTax = pmTabSalesSlip.ItdedWorkDisInTax; // 作業値引対象額合計（税込み）
            retSalesSlip.ItdedSalesDisTaxFre = pmTabSalesSlip.ItdedSalesDisTaxFre; // 売上値引非課税対象額合計
            retSalesSlip.SalesDisOutTax = pmTabSalesSlip.SalesDisOutTax; // 売上値引消費税額（外税）
            retSalesSlip.SalesDisTtlTaxInclu = pmTabSalesSlip.SalesDisTtlTaxInclu; // 売上値引消費税額（内税）
            retSalesSlip.PartsDiscountRate = pmTabSalesSlip.PartsDiscountRate; // 部品値引率
            retSalesSlip.RavorDiscountRate = pmTabSalesSlip.RavorDiscountRate; // 工賃値引率
            retSalesSlip.TotalCost = pmTabSalesSlip.TotalCost; // 原価金額計
            retSalesSlip.ConsTaxLayMethod = pmTabSalesSlip.ConsTaxLayMethod; // 消費税転嫁方式
            retSalesSlip.ConsTaxRate = pmTabSalesSlip.ConsTaxRate; // 消費税税率
            retSalesSlip.FractionProcCd = pmTabSalesSlip.FractionProcCd; // 端数処理区分
            retSalesSlip.AccRecConsTax = pmTabSalesSlip.AccRecConsTax; // 売掛消費税
            retSalesSlip.AutoDepositCd = pmTabSalesSlip.AutoDepositCd; // 自動入金区分
            retSalesSlip.AutoDepositSlipNo = pmTabSalesSlip.AutoDepositSlipNo; // 自動入金伝票番号
            retSalesSlip.DepositAllowanceTtl = pmTabSalesSlip.DepositAllowanceTtl; // 入金引当合計額
            retSalesSlip.DepositAlwcBlnce = pmTabSalesSlip.DepositAlwcBlnce; // 入金引当残高
            retSalesSlip.ClaimCode = pmTabSalesSlip.ClaimCode; // 請求先コード
            retSalesSlip.ClaimSnm = pmTabSalesSlip.ClaimSnm; // 請求先略称
            retSalesSlip.CustomerCode = pmTabSalesSlip.CustomerCode; // 得意先コード
            retSalesSlip.CustomerName = pmTabSalesSlip.CustomerName; // 得意先名称
            retSalesSlip.CustomerName2 = pmTabSalesSlip.CustomerName2; // 得意先名称2
            retSalesSlip.CustomerSnm = pmTabSalesSlip.CustomerSnm; // 得意先略称
            retSalesSlip.HonorificTitle = pmTabSalesSlip.HonorificTitle; // 敬称
            retSalesSlip.OutputNameCode = pmTabSalesSlip.OutputNameCode; // 諸口コード
            retSalesSlip.OutputName = pmTabSalesSlip.OutputName; // 諸口名称
            retSalesSlip.CustSlipNo = pmTabSalesSlip.CustSlipNo; // 得意先伝票番号
            retSalesSlip.SlipAddressDiv = pmTabSalesSlip.SlipAddressDiv; // 伝票住所区分
            retSalesSlip.AddresseeCode = pmTabSalesSlip.AddresseeCode; // 納品先コード
            retSalesSlip.AddresseeName = pmTabSalesSlip.AddresseeName; // 納品先名称
            retSalesSlip.AddresseeName2 = pmTabSalesSlip.AddresseeName2; // 納品先名称2
            retSalesSlip.AddresseePostNo = pmTabSalesSlip.AddresseePostNo; // 納品先郵便番号
            retSalesSlip.AddresseeAddr1 = pmTabSalesSlip.AddresseeAddr1; // 納品先住所1(都道府県市区郡・町村・字)
            retSalesSlip.AddresseeAddr3 = pmTabSalesSlip.AddresseeAddr3; // 納品先住所3(番地)
            retSalesSlip.AddresseeAddr4 = pmTabSalesSlip.AddresseeAddr4; // 納品先住所4(アパート名称)
            retSalesSlip.AddresseeTelNo = pmTabSalesSlip.AddresseeTelNo; // 納品先電話番号
            retSalesSlip.AddresseeFaxNo = pmTabSalesSlip.AddresseeFaxNo; // 納品先FAX番号
            retSalesSlip.PartySaleSlipNum = pmTabSalesSlip.PartySaleSlipNum; // 相手先伝票番号
            retSalesSlip.SlipNote = pmTabSalesSlip.SlipNote; // 伝票備考
            retSalesSlip.SlipNote2 = pmTabSalesSlip.SlipNote2; // 伝票備考２
            retSalesSlip.SlipNote3 = pmTabSalesSlip.SlipNote3; // 伝票備考３
            retSalesSlip.RetGoodsReasonDiv = pmTabSalesSlip.RetGoodsReasonDiv; // 返品理由コード
            retSalesSlip.RetGoodsReason = pmTabSalesSlip.RetGoodsReason; // 返品理由
            retSalesSlip.RegiProcDate = TDateTime.LongDateToDateTime("yyyymmdd", pmTabSalesSlip.RegiProcDate); // レジ処理日
            retSalesSlip.CashRegisterNo = pmTabSalesSlip.CashRegisterNo; // レジ番号
            retSalesSlip.PosReceiptNo = pmTabSalesSlip.PosReceiptNo; // POSレシート番号
            retSalesSlip.DetailRowCount = pmTabSalesSlip.DetailRowCount; // 明細行数
            retSalesSlip.EdiSendDate = TDateTime.LongDateToDateTime("yyyymmdd", pmTabSalesSlip.EdiSendDate); // ＥＤＩ送信日
            retSalesSlip.EdiTakeInDate = TDateTime.LongDateToDateTime("yyyymmdd", pmTabSalesSlip.EdiTakeInDate); // ＥＤＩ取込日
            retSalesSlip.UoeRemark1 = pmTabSalesSlip.UoeRemark1; // ＵＯＥリマーク１
            retSalesSlip.UoeRemark2 = pmTabSalesSlip.UoeRemark2; // ＵＯＥリマーク２
            retSalesSlip.SlipPrintDivCd = pmTabSalesSlip.SlipPrintDivCd; // 伝票発行区分
            retSalesSlip.SlipPrintFinishCd = pmTabSalesSlip.SlipPrintFinishCd; // 伝票発行済区分
            retSalesSlip.SalesSlipPrintDate = TDateTime.LongDateToDateTime("yyyymmdd", pmTabSalesSlip.SalesSlipPrintDate); // 売上伝票発行日
            retSalesSlip.BusinessTypeCode = pmTabSalesSlip.BusinessTypeCode; // 業種コード
            retSalesSlip.BusinessTypeName = pmTabSalesSlip.BusinessTypeName; // 業種名称
            retSalesSlip.OrderNumber = pmTabSalesSlip.OrderNumber; // 発注番号
            retSalesSlip.DeliveredGoodsDiv = pmTabSalesSlip.DeliveredGoodsDiv; // 納品区分
            retSalesSlip.DeliveredGoodsDivNm = pmTabSalesSlip.DeliveredGoodsDivNm; // 納品区分名称
            retSalesSlip.SalesAreaCode = pmTabSalesSlip.SalesAreaCode; // 販売エリアコード
            retSalesSlip.SalesAreaName = pmTabSalesSlip.SalesAreaName; // 販売エリア名称
            retSalesSlip.ReconcileFlag = pmTabSalesSlip.ReconcileFlag; // 消込フラグ
            retSalesSlip.SlipPrtSetPaperId = pmTabSalesSlip.SlipPrtSetPaperId; // 伝票印刷設定用帳票ID
            //retSalesSlip.CompleteCd = pmTabSalesSlip.CompleteCd; // 一式伝票区分  // DEL 2013/07/10 qijh Redmine#38128
            retSalesSlip.CompleteCd = 10; // 一式伝票区分(10:タブレット)  // ADD 2013/07/10 qijh Redmine#38128
            retSalesSlip.SalesPriceFracProcCd = pmTabSalesSlip.SalesPriceFracProcCd; // 売上金額端数処理区分
            retSalesSlip.StockGoodsTtlTaxExc = pmTabSalesSlip.StockGoodsTtlTaxExc; // 在庫商品合計金額（税抜）
            retSalesSlip.PureGoodsTtlTaxExc = pmTabSalesSlip.PureGoodsTtlTaxExc; // 純正商品合計金額（税抜）
            // UPD 2013/07/22 吉岡 指摘・確認事項一覧_社内確認用№354～356 Redmine38565 ------------>>>>>>>>>>>>
            // retSalesSlip.ListPricePrintDiv = pmTabSalesSlip.ListPricePrintDiv; // 定価印刷区分
            retSalesSlip.ListPricePrintDiv = EstimateDefSet.ListPricePrintDiv; // 定価印刷区分
            // UPD 2013/07/22 吉岡 指摘・確認事項一覧_社内確認用№354～356 Redmine38565 ------------<<<<<<<<<<<<
            retSalesSlip.EraNameDispCd1 = pmTabSalesSlip.EraNameDispCd1; // 元号表示区分１
            // UPD 2013/07/22 吉岡 指摘・確認事項一覧_社内確認用№354～356 Redmine38565 ------------>>>>>>>>>>>>
            // retSalesSlip.EstimaTaxDivCd = pmTabSalesSlip.EstimaTaxDivCd; // 見積消費税区分
            retSalesSlip.EstimaTaxDivCd = EstimateDefSet.ConsTaxPrintDiv; // 見積消費税区分
            // UPD 2013/07/22 吉岡 指摘・確認事項一覧_社内確認用№354～356 Redmine38565 ------------<<<<<<<<<<<<
            retSalesSlip.EstimateFormPrtCd = pmTabSalesSlip.EstimateFormPrtCd; // 見積書印刷区分
            retSalesSlip.EstimateSubject = pmTabSalesSlip.EstimateSubject; // 見積件名
            retSalesSlip.Footnotes1 = pmTabSalesSlip.Footnotes1; // 脚注１
            retSalesSlip.Footnotes2 = pmTabSalesSlip.Footnotes2; // 脚注２
            // UPD 2013/07/22 吉岡 指摘・確認事項一覧_社内確認用№354～356 Redmine38565 ------------>>>>>>>>>>>>
            // retSalesSlip.EstimateTitle1 = pmTabSalesSlip.EstimateTitle1; // 見積タイトル１
            retSalesSlip.EstimateTitle1 = EstimateDefSet.EstimateTitle1; // 見積タイトル１
            // UPD 2013/07/22 吉岡 指摘・確認事項一覧_社内確認用№354～356 Redmine38565 ------------<<<<<<<<<<<<
            retSalesSlip.EstimateTitle2 = pmTabSalesSlip.EstimateTitle2; // 見積タイトル２
            retSalesSlip.EstimateTitle3 = pmTabSalesSlip.EstimateTitle3; // 見積タイトル３
            retSalesSlip.EstimateTitle4 = pmTabSalesSlip.EstimateTitle4; // 見積タイトル４
            retSalesSlip.EstimateTitle5 = pmTabSalesSlip.EstimateTitle5; // 見積タイトル５
            // UPD 2013/07/22 吉岡 指摘・確認事項一覧_社内確認用№354～356 Redmine38565 ------------>>>>>>>>>>>>
            // retSalesSlip.EstimateNote1 = pmTabSalesSlip.EstimateNote1; // 見積備考１
            // retSalesSlip.EstimateNote2 = pmTabSalesSlip.EstimateNote2; // 見積備考２
            // retSalesSlip.EstimateNote3 = pmTabSalesSlip.EstimateNote3; // 見積備考３
            retSalesSlip.EstimateNote1 = EstimateDefSet.EstimateNote1; // 見積備考１
            retSalesSlip.EstimateNote2 = EstimateDefSet.EstimateNote2; // 見積備考２
            retSalesSlip.EstimateNote3 = EstimateDefSet.EstimateNote3; // 見積備考３
            // UPD 2013/07/22 吉岡 指摘・確認事項一覧_社内確認用№354～356 Redmine38565 ------------<<<<<<<<<<<<
            retSalesSlip.EstimateNote4 = pmTabSalesSlip.EstimateNote4; // 見積備考４
            retSalesSlip.EstimateNote5 = pmTabSalesSlip.EstimateNote5; // 見積備考５
            // UPD 2013/07/22 吉岡 指摘・確認事項一覧_社内確認用№354～356 Redmine38565 ------------>>>>>>>>>>>>
            // retSalesSlip.EstimateValidityDate = pmTabSalesSlip.EstimateValidityDate; // 見積有効期限
            // retSalesSlip.PartsNoPrtCd = pmTabSalesSlip.PartsNoPrtCd; // 品番印字区分
            retSalesSlip.EstimateValidityDate = DateTime.Today; // 見積有効期限
            retSalesSlip.PartsNoPrtCd = EstimateDefSet.PartsNoPrtCd; // 品番印字区分
            // UPD 2013/07/22 吉岡 指摘・確認事項一覧_社内確認用№354～356 Redmine38565 ------------<<<<<<<<<<<<
            retSalesSlip.OptionPringDivCd = pmTabSalesSlip.OptionPringDivCd; // オプション印字区分
            retSalesSlip.RateUseCode = pmTabSalesSlip.RateUseCode; // 掛率使用区分

            // タブレットログ対応　--------------------------------->>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了");
            // タブレットログ対応　---------------------------------<<<<<
            return retSalesSlip;
        }

        /// <summary>
        /// 売上明細データを作成
        /// </summary>
        /// <param name="pmTabSalesDetail">PMTAB売上明細データ</param>
        /// <param name="isScmConn">SCM連携か(true:連携)</param>
        /// <returns>売上明細データ</returns>
        //private SalesDetailWork GetUpdSalesDetail(PmTabSaleDetailWork pmTabSalesDetail, bool isScmConn) // DEL 2013/07/03 qijh Redmine#37586
        private SalesDetail GetUpdSalesDetail(PmTabSaleDetailWork pmTabSalesDetail, bool isScmConn) // ADD 2013/07/03 qijh Redmine#37586
        {
            // -------------- DEL 2013/07/11 qijh Redmine#38220 ----------- >>>>>
            //// タブレットログ対応　--------------------------------->>>>>
            //const string methodName = "GetUpdSalesDetail";
            //EasyLogger.Write(CLASS_NAME, methodName, methodName + " 開始");
            //// タブレットログ対応　---------------------------------<<<<<
            // -------------- DEL 2013/07/11 qijh Redmine#38220 ----------- <<<<<

            //SalesDetailWork retSalesDetail = new SalesDetailWork(); // DEL 2013/07/03 qijh Redmine#37586
            SalesDetail retSalesDetail = new SalesDetail(); // ADD 2013/07/03 qijh Redmine#37586
            retSalesDetail.EnterpriseCode = pmTabSalesDetail.EnterpriseCode; // 企業コード
            retSalesDetail.UpdEmployeeCode = pmTabSalesDetail.UpdEmployeeCode; // 更新従業員コード
            retSalesDetail.UpdAssemblyId1 = pmTabSalesDetail.UpdAssemblyId1; // 更新アセンブリID1
            retSalesDetail.UpdAssemblyId2 = pmTabSalesDetail.UpdAssemblyId2; // 更新アセンブリID2
            retSalesDetail.LogicalDeleteCode = pmTabSalesDetail.LogicalDeleteCode; // 論理削除区分
            retSalesDetail.AcceptAnOrderNo = pmTabSalesDetail.AcceptAnOrderNo; // 受注番号
            retSalesDetail.AcptAnOdrStatus = pmTabSalesDetail.AcptAnOdrStatus; // 受注ステータス
            retSalesDetail.SalesSlipNum = pmTabSalesDetail.SalesSlipNum; // 売上伝票番号
            retSalesDetail.SalesRowNo = pmTabSalesDetail.SalesRowNo; // 売上行番号
            retSalesDetail.SalesRowDerivNo = pmTabSalesDetail.SalesRowDerivNo; // 売上行番号枝番
            retSalesDetail.SectionCode = pmTabSalesDetail.SectionCode; // 拠点コード
            retSalesDetail.SubSectionCode = pmTabSalesDetail.SubSectionCode; // 部門コード
            retSalesDetail.SalesDate = TDateTime.LongDateToDateTime("yyyymmdd", pmTabSalesDetail.SalesDate); // 売上日付
            retSalesDetail.CommonSeqNo = pmTabSalesDetail.CommonSeqNo; // 共通通番
            retSalesDetail.SalesSlipDtlNum = pmTabSalesDetail.SalesSlipDtlNum; // 売上明細通番
            retSalesDetail.AcptAnOdrStatusSrc = pmTabSalesDetail.AcptAnOdrStatusSrc; // 受注ステータス（元）
            retSalesDetail.SalesSlipDtlNumSrc = pmTabSalesDetail.SalesSlipDtlNumSrc; // 売上明細通番（元）
            retSalesDetail.SupplierFormalSync = pmTabSalesDetail.SupplierFormalSync; // 仕入形式（同時）
            retSalesDetail.StockSlipDtlNumSync = pmTabSalesDetail.StockSlipDtlNumSync; // 仕入明細通番（同時）
            retSalesDetail.SalesSlipCdDtl = pmTabSalesDetail.SalesSlipCdDtl; // 売上伝票区分（明細）
            retSalesDetail.DeliGdsCmpltDueDate = pmTabSalesDetail.DeliGdsCmpltDueDate; // 納品完了予定日
            retSalesDetail.GoodsKindCode = pmTabSalesDetail.GoodsKindCode; // 商品属性
            retSalesDetail.GoodsSearchDivCd = pmTabSalesDetail.GoodsSearchDivCd; // 商品検索区分
            retSalesDetail.GoodsMakerCd = pmTabSalesDetail.GoodsMakerCd; // 商品メーカーコード
            retSalesDetail.MakerName = pmTabSalesDetail.MakerName; // メーカー名称
            retSalesDetail.MakerKanaName = pmTabSalesDetail.MakerKanaName; // メーカーカナ名称
            retSalesDetail.GoodsNo = pmTabSalesDetail.GoodsNo; // 商品番号
            retSalesDetail.GoodsName = pmTabSalesDetail.GoodsName; // 商品名称
            retSalesDetail.GoodsNameKana = pmTabSalesDetail.GoodsNameKana; // 商品名称カナ
            retSalesDetail.GoodsLGroup = pmTabSalesDetail.GoodsLGroup; // 商品大分類コード
            retSalesDetail.GoodsLGroupName = pmTabSalesDetail.GoodsLGroupName; // 商品大分類名称
            retSalesDetail.GoodsMGroup = pmTabSalesDetail.GoodsMGroup; // 商品中分類コード
            retSalesDetail.GoodsMGroupName = pmTabSalesDetail.GoodsMGroupName; // 商品中分類名称
            retSalesDetail.BLGroupCode = pmTabSalesDetail.BLGroupCode; // BLグループコード
            retSalesDetail.BLGroupName = pmTabSalesDetail.BLGroupName; // BLグループコード名称
            retSalesDetail.BLGoodsCode = pmTabSalesDetail.BLGoodsCode; // BL商品コード
            retSalesDetail.BLGoodsFullName = pmTabSalesDetail.BLGoodsFullName; // BL商品コード名称（全角）
            retSalesDetail.EnterpriseGanreCode = pmTabSalesDetail.EnterpriseGanreCode; // 自社分類コード
            retSalesDetail.EnterpriseGanreName = pmTabSalesDetail.EnterpriseGanreName; // 自社分類名称
            retSalesDetail.WarehouseCode = pmTabSalesDetail.WarehouseCode; // 倉庫コード
            retSalesDetail.WarehouseName = pmTabSalesDetail.WarehouseName; // 倉庫名称
            retSalesDetail.WarehouseShelfNo = pmTabSalesDetail.WarehouseShelfNo; // 倉庫棚番
            retSalesDetail.SalesOrderDivCd = pmTabSalesDetail.SalesOrderDivCd; // 売上在庫取寄せ区分
            retSalesDetail.OpenPriceDiv = pmTabSalesDetail.OpenPriceDiv; // オープン価格区分
            retSalesDetail.GoodsRateRank = pmTabSalesDetail.GoodsRateRank; // 商品掛率ランク
            retSalesDetail.CustRateGrpCode = pmTabSalesDetail.CustRateGrpCode; // 得意先掛率グループコード
            retSalesDetail.ListPriceRate = pmTabSalesDetail.ListPriceRate; // 定価率
            retSalesDetail.RateSectPriceUnPrc = pmTabSalesDetail.RateSectPriceUnPrc; // 掛率設定拠点（定価）
            retSalesDetail.RateDivLPrice = pmTabSalesDetail.RateDivLPrice; // 掛率設定区分（定価）
            retSalesDetail.UnPrcCalcCdLPrice = pmTabSalesDetail.UnPrcCalcCdLPrice; // 単価算出区分（定価）
            retSalesDetail.PriceCdLPrice = pmTabSalesDetail.PriceCdLPrice; // 価格区分（定価）
            retSalesDetail.StdUnPrcLPrice = pmTabSalesDetail.StdUnPrcLPrice; // 基準単価（定価）
            retSalesDetail.FracProcUnitLPrice = pmTabSalesDetail.FracProcUnitLPrice; // 端数処理単位（定価）
            retSalesDetail.FracProcLPrice = pmTabSalesDetail.FracProcLPrice; // 端数処理（定価）
            retSalesDetail.ListPriceTaxIncFl = pmTabSalesDetail.ListPriceTaxIncFl; // 定価（税込，浮動）
            retSalesDetail.ListPriceTaxExcFl = pmTabSalesDetail.ListPriceTaxExcFl; // 定価（税抜，浮動）
            retSalesDetail.ListPriceChngCd = pmTabSalesDetail.ListPriceChngCd; // 定価変更区分
            retSalesDetail.SalesRate = pmTabSalesDetail.SalesRate; // 売価率
            retSalesDetail.RateSectSalUnPrc = pmTabSalesDetail.RateSectSalUnPrc; // 掛率設定拠点（売上単価）
            retSalesDetail.RateDivSalUnPrc = pmTabSalesDetail.RateDivSalUnPrc; // 掛率設定区分（売上単価）
            retSalesDetail.UnPrcCalcCdSalUnPrc = pmTabSalesDetail.UnPrcCalcCdSalUnPrc; // 単価算出区分（売上単価）
            retSalesDetail.PriceCdSalUnPrc = pmTabSalesDetail.PriceCdSalUnPrc; // 価格区分（売上単価）
            retSalesDetail.StdUnPrcSalUnPrc = pmTabSalesDetail.StdUnPrcSalUnPrc; // 基準単価（売上単価）
            retSalesDetail.FracProcUnitSalUnPrc = pmTabSalesDetail.FracProcUnitSalUnPrc; // 端数処理単位（売上単価）
            retSalesDetail.FracProcSalUnPrc = pmTabSalesDetail.FracProcSalUnPrc; // 端数処理（売上単価）
            retSalesDetail.SalesUnPrcTaxIncFl = pmTabSalesDetail.SalesUnPrcTaxIncFl; // 売上単価（税込，浮動）
            retSalesDetail.SalesUnPrcTaxExcFl = pmTabSalesDetail.SalesUnPrcTaxExcFl; // 売上単価（税抜，浮動）
            retSalesDetail.SalesUnPrcChngCd = pmTabSalesDetail.SalesUnPrcChngCd; // 売上単価変更区分
            retSalesDetail.CostRate = pmTabSalesDetail.CostRate; // 原価率
            retSalesDetail.RateSectCstUnPrc = pmTabSalesDetail.RateSectCstUnPrc; // 掛率設定拠点（原価単価）
            retSalesDetail.RateDivUnCst = pmTabSalesDetail.RateDivUnCst; // 掛率設定区分（原価単価）
            retSalesDetail.UnPrcCalcCdUnCst = pmTabSalesDetail.UnPrcCalcCdUnCst; // 単価算出区分（原価単価）
            retSalesDetail.PriceCdUnCst = pmTabSalesDetail.PriceCdUnCst; // 価格区分（原価単価）
            retSalesDetail.StdUnPrcUnCst = pmTabSalesDetail.StdUnPrcUnCst; // 基準単価（原価単価）
            retSalesDetail.FracProcUnitUnCst = pmTabSalesDetail.FracProcUnitUnCst; // 端数処理単位（原価単価）
            retSalesDetail.FracProcUnCst = pmTabSalesDetail.FracProcUnCst; // 端数処理（原価単価）
            retSalesDetail.SalesUnitCost = pmTabSalesDetail.SalesUnitCost; // 原価単価
            retSalesDetail.SalesUnitCostChngDiv = pmTabSalesDetail.SalesUnitCostChngDiv; // 原価単価変更区分
            retSalesDetail.RateBLGoodsCode = pmTabSalesDetail.RateBLGoodsCode; // BL商品コード（掛率）
            retSalesDetail.RateBLGoodsName = pmTabSalesDetail.RateBLGoodsName; // BL商品コード名称（掛率）
            retSalesDetail.RateGoodsRateGrpCd = pmTabSalesDetail.RateGoodsRateGrpCd; // 商品掛率グループコード（掛率）
            retSalesDetail.RateGoodsRateGrpNm = pmTabSalesDetail.RateGoodsRateGrpNm; // 商品掛率グループ名称（掛率）
            retSalesDetail.RateBLGroupCode = pmTabSalesDetail.RateBLGroupCode; // BLグループコード（掛率）
            retSalesDetail.RateBLGroupName = pmTabSalesDetail.RateBLGroupName; // BLグループ名称（掛率）
            retSalesDetail.PrtBLGoodsCode = pmTabSalesDetail.PrtBLGoodsCode; // BL商品コード（印刷）
            retSalesDetail.PrtBLGoodsName = pmTabSalesDetail.PrtBLGoodsName; // BL商品コード名称（印刷）
            retSalesDetail.SalesCode = pmTabSalesDetail.SalesCode; // 販売区分コード
            retSalesDetail.SalesCdNm = pmTabSalesDetail.SalesCdNm; // 販売区分名称
            retSalesDetail.WorkManHour = pmTabSalesDetail.WorkManHour; // 作業工数
            retSalesDetail.ShipmentCnt = pmTabSalesDetail.ShipmentCnt; // 出荷数
            retSalesDetail.AcceptAnOrderCnt = pmTabSalesDetail.AcceptAnOrderCnt; // 受注数量
            retSalesDetail.AcptAnOdrAdjustCnt = pmTabSalesDetail.AcptAnOdrAdjustCnt; // 受注調整数
            retSalesDetail.AcptAnOdrRemainCnt = pmTabSalesDetail.AcptAnOdrRemainCnt; // 受注残数
            retSalesDetail.RemainCntUpdDate = TDateTime.LongDateToDateTime("yyyymmdd", pmTabSalesDetail.RemainCntUpdDate); // 残数更新日
            retSalesDetail.SalesMoneyTaxInc = pmTabSalesDetail.SalesMoneyTaxInc; // 売上金額（税込み）
            retSalesDetail.SalesMoneyTaxExc = pmTabSalesDetail.SalesMoneyTaxExc; // 売上金額（税抜き）
            retSalesDetail.Cost = pmTabSalesDetail.Cost; // 原価
            retSalesDetail.GrsProfitChkDiv = pmTabSalesDetail.GrsProfitChkDiv; // 粗利チェック区分
            retSalesDetail.SalesGoodsCd = pmTabSalesDetail.SalesGoodsCd; // 売上商品区分
            retSalesDetail.SalesPriceConsTax = pmTabSalesDetail.SalesPriceConsTax; // 売上金額消費税額
            retSalesDetail.TaxationDivCd = pmTabSalesDetail.TaxationDivCd; // 課税区分
            retSalesDetail.PartySlipNumDtl = pmTabSalesDetail.PartySlipNumDtl; // 相手先伝票番号（明細）
            retSalesDetail.DtlNote = pmTabSalesDetail.DtlNote; // 明細備考
            retSalesDetail.SupplierCd = pmTabSalesDetail.SupplierCd; // 仕入先コード
            retSalesDetail.SupplierSnm = pmTabSalesDetail.SupplierSnm; // 仕入先略称
            retSalesDetail.OrderNumber = pmTabSalesDetail.OrderNumber; // 発注番号
            retSalesDetail.WayToOrder = pmTabSalesDetail.WayToOrder; // 注文方法
            retSalesDetail.SlipMemo1 = pmTabSalesDetail.SlipMemo1; // 伝票メモ１
            retSalesDetail.SlipMemo2 = pmTabSalesDetail.SlipMemo2; // 伝票メモ２
            retSalesDetail.SlipMemo3 = pmTabSalesDetail.SlipMemo3; // 伝票メモ３
            retSalesDetail.InsideMemo1 = pmTabSalesDetail.InsideMemo1; // 社内メモ１
            retSalesDetail.InsideMemo2 = pmTabSalesDetail.InsideMemo2; // 社内メモ２
            retSalesDetail.InsideMemo3 = pmTabSalesDetail.InsideMemo3; // 社内メモ３
            retSalesDetail.BfListPrice = pmTabSalesDetail.BfListPrice; // 変更前定価
            retSalesDetail.BfSalesUnitPrice = pmTabSalesDetail.BfSalesUnitPrice; // 変更前売価
            retSalesDetail.BfUnitCost = pmTabSalesDetail.BfUnitCost; // 変更前原価
            retSalesDetail.CmpltSalesRowNo = pmTabSalesDetail.CmpltSalesRowNo; // 一式明細番号
            retSalesDetail.CmpltGoodsMakerCd = pmTabSalesDetail.CmpltGoodsMakerCd; // メーカーコード（一式）
            retSalesDetail.CmpltMakerName = pmTabSalesDetail.CmpltMakerName; // メーカー名称（一式）
            retSalesDetail.CmpltMakerKanaName = pmTabSalesDetail.CmpltMakerKanaName; // メーカーカナ名称（一式）
            retSalesDetail.CmpltGoodsName = pmTabSalesDetail.CmpltGoodsName; // 商品名称（一式）
            retSalesDetail.CmpltShipmentCnt = pmTabSalesDetail.CmpltShipmentCnt; // 数量（一式）
            retSalesDetail.CmpltSalesUnPrcFl = pmTabSalesDetail.CmpltSalesUnPrcFl; // 売上単価（一式）
            retSalesDetail.CmpltSalesMoney = pmTabSalesDetail.CmpltSalesMoney; // 売上金額（一式）
            retSalesDetail.CmpltSalesUnitCost = pmTabSalesDetail.CmpltSalesUnitCost; // 原価単価（一式）
            retSalesDetail.CmpltCost = pmTabSalesDetail.CmpltCost; // 原価金額（一式）
            retSalesDetail.CmpltPartySalSlNum = pmTabSalesDetail.CmpltPartySalSlNum; // 相手先伝票番号（一式）
            retSalesDetail.CmpltNote = pmTabSalesDetail.CmpltNote; // 一式備考
            retSalesDetail.PrtGoodsNo = pmTabSalesDetail.PrtGoodsNo; // 印刷用品番
            retSalesDetail.PrtMakerCode = pmTabSalesDetail.PrtMakerCode; // 印刷用メーカーコード
            retSalesDetail.PrtMakerName = pmTabSalesDetail.PrtMakerName; // 印刷用メーカー名称
            retSalesDetail.CampaignCode = pmTabSalesDetail.CampaignCode; // キャンペーンコード
            retSalesDetail.CampaignName = pmTabSalesDetail.CampaignName; // キャンペーン名称
            retSalesDetail.GoodsDivCd = pmTabSalesDetail.GoodsDivCd; // 商品種別
            retSalesDetail.AnswerDelivDate = pmTabSalesDetail.AnswerDelivDate; // 回答納期
            retSalesDetail.RecycleDiv = pmTabSalesDetail.RecycleDiv; // リサイクル区分
            retSalesDetail.RecycleDivNm = pmTabSalesDetail.RecycleDivNm; // リサイクル区分名称
            retSalesDetail.WayToAcptOdr = pmTabSalesDetail.WayToAcptOdr; // 受注方法
            retSalesDetail.AutoAnswerDivSCM = pmTabSalesDetail.AutoAnswerDivSCM; // 自動回答区分(SCM)
            retSalesDetail.AcceptOrOrderKind = pmTabSalesDetail.AcceptOrOrderKind; // 受発注種別
            retSalesDetail.InquiryNumber = pmTabSalesDetail.InquiryNumber; // 問合せ番号
            retSalesDetail.InqRowNumber = pmTabSalesDetail.InqRowNumber; // 問合せ行番号
            retSalesDetail.GoodsSpecialNote = pmTabSalesDetail.GoodsSpecialNote; // 商品規格・特記事項
            retSalesDetail.RentSyncSupplier = pmTabSalesDetail.RentSyncSupplier; // 貸出同時仕入先
            retSalesDetail.RentSyncStockDate = TDateTime.LongDateToDateTime("yyyymmdd", pmTabSalesDetail.RentSyncStockDate); // 貸出同時仕入日
            retSalesDetail.RentSyncSupSlipNo = pmTabSalesDetail.RentSyncSupSlipNo; // 貸出同時仕入伝票番号

            retSalesDetail.DtlRelationGuid = Guid.NewGuid(); // 明細関連付けGUID // ADD 2013/06/27 qijh Redmine#37389
            
            // SCMに関連する項目をセット
            retSalesDetail.WayToAcptOdr = 0; // 受注方法
            retSalesDetail.AutoAnswerDivSCM = 0; // 自動回答区分(SCM)
            retSalesDetail.AcceptOrOrderKind = 0; // 受発注種別
            retSalesDetail.InquiryNumber = 0; // 問合せ番号
            retSalesDetail.InqRowNumber = 0; // 問合せ行番号
            if (isScmConn)
            {
                // SCM連携
                retSalesDetail.WayToAcptOdr = 1; // 受注方法
                retSalesDetail.AutoAnswerDivSCM = 1; // 自動回答区分(SCM)
                retSalesDetail.AcceptOrOrderKind = 1; // 受発注種別
                // retSalesDetail.InquiryNumber = -1; // 問合せ番号  // DEL 2013/07/02 songg Redmine#37692
                retSalesDetail.InquiryNumber = 0; // 問合せ番号     // ADD 2013/07/02 songg Redmine#37692
                retSalesDetail.InqRowNumber = -1; // 問合せ行番号
            }

            // -------------- DEL 2013/07/11 qijh Redmine#38220 ----------- >>>>>
            //// タブレットログ対応　--------------------------------->>>>>
            //EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了");
            //// タブレットログ対応　---------------------------------<<<<<
            // -------------- DEL 2013/07/11 qijh Redmine#38220 ----------- <<<<<

            // 印刷用品番を設定
            retSalesDetail.PrtGoodsNo = pmTabSalesDetail.GoodsNo; // ディフォルト値を設定 // ADD 2013/07/17 qijh Redmine#38166
            SetPrtGoodsNo(retSalesDetail, pmTabSalesDetail); // ADD 2013/07/12 qijh Redmine#38166

            return retSalesDetail;
        }

        // --------------------- ADD 2013/06/27 qijh Redmine#37389 ---------------- >>>>>
        /// <summary>
        /// 売上明細リストより明細追加情報リストを取得
        /// </summary>
        /// <param name="updSalesDetailList">売上明細データリスト</param>
        /// <param name="carManagementWork">車両管理データ</param>
        /// <param name="slipDtlRegOrder">伝票登録順制御用変数</param>
        /// <returns>明細追加情報リスト</returns>
        private ArrayList GetSlipDetailAddInfoWorkList(ArrayList updSalesDetailList
            , CarManagementWork carManagementWork  // ADD 2013/06/28 qijh Redmine#37389
            , ref int slipDtlRegOrder     // ADD 2013/07/09 qijh Redmine#37586
            )
        {
            // 売上明細リストより明細追加情報リストを取得
            ArrayList retList = new ArrayList();

            //Guid carRelationGuid = Guid.NewGuid();
            Guid carRelationGuid = carManagementWork.CarRelationGuid;
            for (int i = 1; i <= updSalesDetailList.Count; i++)
            {
                SalesDetailWork updSalesDetailWork = (SalesDetailWork)updSalesDetailList[i - 1];
                //retList.Add(GetSlipDetailAddInfo(updSalesDetailWork, carRelationGuid, i)); // DEL 2013/07/09 qijh Redmine#37586
                retList.Add(GetSlipDetailAddInfo(updSalesDetailWork, carRelationGuid, ref slipDtlRegOrder)); // ADD 2013/07/09 qijh Redmine#37586
            }

            return retList;
        }

        /// <summary>
        /// 売上明細より明細追加情報を取得
        /// </summary>
        /// <param name="updSalesDetailWork">売上明細データ</param>
        /// <param name="carRelationGuid">車両情報共通GUID</param>
        /// <param name="salesSort">売上データ順</param>
        /// <returns>明細追加情報</returns>
        //private SlipDetailAddInfoWork GetSlipDetailAddInfo(SalesDetailWork updSalesDetailWork, Guid carRelationGuid, int salesSort) // DEL 2013/07/09 qijh Redmine#37586
        private SlipDetailAddInfoWork GetSlipDetailAddInfo(SalesDetailWork updSalesDetailWork, Guid carRelationGuid, ref int salesSort) // ADD 2013/07/09 qijh Redmine#37586
        {
            SlipDetailAddInfoWork addInfo = new SlipDetailAddInfoWork();

            addInfo.GoodsEntryDiv = 0;  // 商品登録区分(0:登録しない/1:登録する)
            addInfo.PriceUpdateDiv = 0; // 価格登録区分(0:登録しない/1:登録する)
            addInfo.DtlRelationGuid = updSalesDetailWork.DtlRelationGuid;     // 明細共通GUID
            addInfo.CarRelationGuid = carRelationGuid;        // 車両情報共通GUID
            //addInfo.SlipDtlRegOrder = salesSort;         //売上データ順  // DEL 2013/07/09 qijh Redmine#37586
            addInfo.SlipDtlRegOrder = ++salesSort;    //データ登録順   // ADD 2013/07/09 qijh Redmine#37586
            addInfo.AddUpRemDiv = 0;    // 受注データ計上残区分(0:伝票追加情報参照/1:残す/2:残さない)

            return addInfo;
        }
        // --------------------- ADD 2013/06/27 qijh Redmine#37389 ---------------- <<<<<

        #region DEL 2013/06/28 qijh Redmine#37389
        // --------------------- DEL 2013/06/28 qijh Redmine#37389 ---------------- >>>>>
        ///// <summary>
        ///// 受注マスタ(車両)を作成
        ///// </summary>
        ///// <param name="pmTabAcceptOdrCar">PMTAB受注マスタ(車両)</param>
        ///// <returns>受注マスタ(車両)</returns>
        //private AcceptOdrCarWork GetUpdAcceptOdrCar(PmTabAcpOdrCarWork pmTabAcceptOdrCar)
        //{
        //    // タブレットログ対応　--------------------------------->>>>>
        //    const string methodName = "GetUpdAcceptOdrCar";
        //    EasyLogger.Write(CLASS_NAME, methodName, methodName + " 開始");
        //    // タブレットログ対応　---------------------------------<<<<<

        //    AcceptOdrCarWork retAcceptOdrCar = new AcceptOdrCarWork();
        //    retAcceptOdrCar.EnterpriseCode = pmTabAcceptOdrCar.EnterpriseCode; // 企業コード
        //    retAcceptOdrCar.UpdEmployeeCode = pmTabAcceptOdrCar.UpdEmployeeCode; // 更新従業員コード
        //    retAcceptOdrCar.UpdAssemblyId1 = pmTabAcceptOdrCar.UpdAssemblyId1; // 更新アセンブリID1
        //    retAcceptOdrCar.UpdAssemblyId2 = pmTabAcceptOdrCar.UpdAssemblyId2; // 更新アセンブリID2
        //    retAcceptOdrCar.LogicalDeleteCode = pmTabAcceptOdrCar.LogicalDeleteCode; // 論理削除区分
        //    retAcceptOdrCar.AcceptAnOrderNo = pmTabAcceptOdrCar.AcceptAnOrderNo; // 受注番号
        //    retAcceptOdrCar.AcptAnOdrStatus = pmTabAcceptOdrCar.AcptAnOdrStatus; // 受注ステータス
        //    retAcceptOdrCar.DataInputSystem = pmTabAcceptOdrCar.DataInputSystem; // データ入力システム
        //    retAcceptOdrCar.CarMngNo = pmTabAcceptOdrCar.CarMngNo; // 車両管理番号
        //    retAcceptOdrCar.CarMngCode = pmTabAcceptOdrCar.CarMngCode; // 車輌管理コード
        //    retAcceptOdrCar.NumberPlate1Code = pmTabAcceptOdrCar.NumberPlate1Code; // 陸運事務所番号
        //    retAcceptOdrCar.NumberPlate1Name = pmTabAcceptOdrCar.NumberPlate1Name; // 陸運事務局名称
        //    retAcceptOdrCar.NumberPlate2 = pmTabAcceptOdrCar.NumberPlate2; // 車両登録番号（種別）
        //    retAcceptOdrCar.NumberPlate3 = pmTabAcceptOdrCar.NumberPlate3; // 車両登録番号（カナ）
        //    retAcceptOdrCar.NumberPlate4 = pmTabAcceptOdrCar.NumberPlate4; // 車両登録番号（プレート番号）
        //    retAcceptOdrCar.FirstEntryDate = pmTabAcceptOdrCar.FirstEntryDate; // 初年度
        //    retAcceptOdrCar.MakerCode = pmTabAcceptOdrCar.MakerCode; // メーカーコード
        //    retAcceptOdrCar.MakerFullName = pmTabAcceptOdrCar.MakerFullName; // メーカー全角名称
        //    retAcceptOdrCar.MakerHalfName = pmTabAcceptOdrCar.MakerHalfName; // メーカー半角名称
        //    retAcceptOdrCar.ModelCode = pmTabAcceptOdrCar.ModelCode; // 車種コード
        //    retAcceptOdrCar.ModelSubCode = pmTabAcceptOdrCar.ModelSubCode; // 車種サブコード
        //    retAcceptOdrCar.ModelFullName = pmTabAcceptOdrCar.ModelFullName; // 車種全角名称
        //    retAcceptOdrCar.ModelHalfName = pmTabAcceptOdrCar.ModelHalfName; // 車種半角名称
        //    retAcceptOdrCar.ExhaustGasSign = pmTabAcceptOdrCar.ExhaustGasSign; // 排ガス記号
        //    retAcceptOdrCar.SeriesModel = pmTabAcceptOdrCar.SeriesModel; // シリーズ型式
        //    retAcceptOdrCar.CategorySignModel = pmTabAcceptOdrCar.CategorySignModel; // 型式（類別記号）
        //    retAcceptOdrCar.FullModel = pmTabAcceptOdrCar.FullModel; // 型式（フル型）
        //    retAcceptOdrCar.ModelDesignationNo = pmTabAcceptOdrCar.ModelDesignationNo; // 型式指定番号
        //    retAcceptOdrCar.CategoryNo = pmTabAcceptOdrCar.CategoryNo; // 類別番号
        //    retAcceptOdrCar.FrameModel = pmTabAcceptOdrCar.FrameModel; // 車台型式
        //    retAcceptOdrCar.FrameNo = pmTabAcceptOdrCar.FrameNo; // 車台番号
        //    retAcceptOdrCar.SearchFrameNo = pmTabAcceptOdrCar.SearchFrameNo; // 車台番号（検索用）
        //    retAcceptOdrCar.EngineModelNm = pmTabAcceptOdrCar.EngineModelNm; // エンジン型式名称
        //    retAcceptOdrCar.RelevanceModel = pmTabAcceptOdrCar.RelevanceModel; // 関連型式
        //    retAcceptOdrCar.SubCarNmCd = pmTabAcceptOdrCar.SubCarNmCd; // サブ車名コード
        //    retAcceptOdrCar.ModelGradeSname = pmTabAcceptOdrCar.ModelGradeSname; // 型式グレード略称
        //    retAcceptOdrCar.ColorCode = pmTabAcceptOdrCar.ColorCode; // カラーコード
        //    retAcceptOdrCar.ColorName1 = pmTabAcceptOdrCar.ColorName1; // カラー名称1
        //    retAcceptOdrCar.TrimCode = pmTabAcceptOdrCar.TrimCode; // トリムコード
        //    retAcceptOdrCar.TrimName = pmTabAcceptOdrCar.TrimName; // トリム名称
        //    retAcceptOdrCar.Mileage = pmTabAcceptOdrCar.Mileage; // 車両走行距離
        //    retAcceptOdrCar.FullModelFixedNoAry = pmTabAcceptOdrCar.FullModelFixedNoAry; // フル型式固定番号配列
        //    retAcceptOdrCar.CategoryObjAry = pmTabAcceptOdrCar.CategoryObjAry; // 装備オブジェクト配列
        //    retAcceptOdrCar.CarNote = pmTabAcceptOdrCar.CarNote; // 車輌備考
        //    retAcceptOdrCar.FreeSrchMdlFxdNoAry = pmTabAcceptOdrCar.FreeSrchMdlFxdNoAry; // 自由検索型式固定番号配列
        //    retAcceptOdrCar.DomesticForeignCode = pmTabAcceptOdrCar.DomesticForeignCode; // 国産／外車区分

        //    if (null == retAcceptOdrCar.FullModelFixedNoAry)
        //        retAcceptOdrCar.FullModelFixedNoAry = new int[0];
        //    if (null == retAcceptOdrCar.CategoryObjAry)
        //        retAcceptOdrCar.CategoryObjAry = new byte[0];
        //    if (null == retAcceptOdrCar.FreeSrchMdlFxdNoAry)
        //        retAcceptOdrCar.FreeSrchMdlFxdNoAry = new byte[0];

        //    // タブレットログ対応　--------------------------------->>>>>
        //    EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了");
        //    // タブレットログ対応　---------------------------------<<<<<
        //    return retAcceptOdrCar;
        //}
        // --------------------- DEL 2013/06/28 qijh Redmine#37389 ---------------- <<<<<
        #endregion DEL 2013/06/28 qijh Redmine#37389

        // --------------------- ADD 2013/06/28 qijh Redmine#37389 ---------------- >>>>>
        /// <summary>
        /// 車両管理データを作成
        /// </summary>
        /// <param name="pmTabAcceptOdrCar">PMTAB受注マスタ(車両)</param>
        /// <param name="pmTabSalesSlip">PMTAB売上データ</param>
        /// <param name="customerInfo">得意先情報</param>
        /// <returns>車両管理データ</returns>
        private CarManagementWork GetUpdCarManagement(PmTabAcpOdrCarWork pmTabAcceptOdrCar, PmTabSalesSlipWork pmTabSalesSlip, CustomerInfo customerInfo)
        {
            const string methodName = "GetUpdCarManagement";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 開始");

            CarManagementWork retAcceptOdrCar = new CarManagementWork();
            retAcceptOdrCar.EnterpriseCode = pmTabAcceptOdrCar.EnterpriseCode; // 企業コード
            retAcceptOdrCar.UpdEmployeeCode = pmTabSalesSlip.UpdEmployeeCode; // 更新従業員コード
            retAcceptOdrCar.UpdAssemblyId1 = pmTabAcceptOdrCar.UpdAssemblyId1; // 更新アセンブリID1
            retAcceptOdrCar.UpdAssemblyId2 = pmTabAcceptOdrCar.UpdAssemblyId2; // 更新アセンブリID2
            retAcceptOdrCar.LogicalDeleteCode = pmTabAcceptOdrCar.LogicalDeleteCode; // 論理削除区分
            retAcceptOdrCar.CustomerCode = customerInfo.CustomerCode; // 得意先コード
            retAcceptOdrCar.CarMngNo = pmTabAcceptOdrCar.CarMngNo; // 車両管理番号
            retAcceptOdrCar.CarMngCode = pmTabAcceptOdrCar.CarMngCode; // 車輌管理コード
            retAcceptOdrCar.NumberPlate1Code = pmTabAcceptOdrCar.NumberPlate1Code; // 陸運事務所番号
            retAcceptOdrCar.NumberPlate1Name = pmTabAcceptOdrCar.NumberPlate1Name; // 陸運事務局名称
            retAcceptOdrCar.NumberPlate2 = pmTabAcceptOdrCar.NumberPlate2; // 車両登録番号（種別）
            retAcceptOdrCar.NumberPlate3 = pmTabAcceptOdrCar.NumberPlate3; // 車両登録番号（カナ）
            retAcceptOdrCar.NumberPlate4 = pmTabAcceptOdrCar.NumberPlate4; // 車両登録番号（プレート番号）
            retAcceptOdrCar.FirstEntryDate = pmTabAcceptOdrCar.FirstEntryDate; // 初年度
            retAcceptOdrCar.MakerCode = pmTabAcceptOdrCar.MakerCode; // メーカーコード
            retAcceptOdrCar.MakerFullName = pmTabAcceptOdrCar.MakerFullName; // メーカー全角名称
            retAcceptOdrCar.MakerHalfName = pmTabAcceptOdrCar.MakerHalfName; // メーカー半角名称
            retAcceptOdrCar.ModelCode = pmTabAcceptOdrCar.ModelCode; // 車種コード
            retAcceptOdrCar.ModelSubCode = pmTabAcceptOdrCar.ModelSubCode; // 車種サブコード
            retAcceptOdrCar.ModelFullName = pmTabAcceptOdrCar.ModelFullName; // 車種全角名称
            retAcceptOdrCar.ModelHalfName = pmTabAcceptOdrCar.ModelHalfName; // 車種半角名称
            retAcceptOdrCar.ExhaustGasSign = pmTabAcceptOdrCar.ExhaustGasSign; // 排ガス記号
            retAcceptOdrCar.SeriesModel = pmTabAcceptOdrCar.SeriesModel; // シリーズ型式
            retAcceptOdrCar.CategorySignModel = pmTabAcceptOdrCar.CategorySignModel; // 型式（類別記号）
            retAcceptOdrCar.FullModel = pmTabAcceptOdrCar.FullModel; // 型式（フル型）
            retAcceptOdrCar.ModelDesignationNo = pmTabAcceptOdrCar.ModelDesignationNo; // 型式指定番号
            retAcceptOdrCar.CategoryNo = pmTabAcceptOdrCar.CategoryNo; // 類別番号
            retAcceptOdrCar.FrameModel = pmTabAcceptOdrCar.FrameModel; // 車台型式
            retAcceptOdrCar.FrameNo = pmTabAcceptOdrCar.FrameNo; // 車台番号
            retAcceptOdrCar.SearchFrameNo = pmTabAcceptOdrCar.SearchFrameNo; // 車台番号（検索用）
            retAcceptOdrCar.EngineModelNm = pmTabAcceptOdrCar.EngineModelNm; // エンジン型式名称
            retAcceptOdrCar.RelevanceModel = pmTabAcceptOdrCar.RelevanceModel; // 関連型式
            retAcceptOdrCar.SubCarNmCd = pmTabAcceptOdrCar.SubCarNmCd; // サブ車名コード
            retAcceptOdrCar.ModelGradeSname = pmTabAcceptOdrCar.ModelGradeSname; // 型式グレード略称
            retAcceptOdrCar.ColorCode = pmTabAcceptOdrCar.ColorCode; // カラーコード
            retAcceptOdrCar.ColorName1 = pmTabAcceptOdrCar.ColorName1; // カラー名称1
            retAcceptOdrCar.TrimCode = pmTabAcceptOdrCar.TrimCode; // トリムコード
            retAcceptOdrCar.TrimName = pmTabAcceptOdrCar.TrimName; // トリム名称
            retAcceptOdrCar.Mileage = pmTabAcceptOdrCar.Mileage; // 車両走行距離
            retAcceptOdrCar.FullModelFixedNoAry = pmTabAcceptOdrCar.FullModelFixedNoAry; // フル型式固定番号配列
            retAcceptOdrCar.CategoryObjAry = pmTabAcceptOdrCar.CategoryObjAry; // 装備オブジェクト配列
            retAcceptOdrCar.CarNote = pmTabAcceptOdrCar.CarNote; // 車輌備考
            retAcceptOdrCar.FreeSrchMdlFxdNoAry = pmTabAcceptOdrCar.FreeSrchMdlFxdNoAry; // 自由検索型式固定番号配列
            retAcceptOdrCar.DomesticForeignCode = pmTabAcceptOdrCar.DomesticForeignCode; // 国産／外車区分
            retAcceptOdrCar.CarRelationGuid = Guid.NewGuid(); // 車両情報共通GUID

            if (null == retAcceptOdrCar.FullModelFixedNoAry)
                retAcceptOdrCar.FullModelFixedNoAry = new int[0];
            if (null == retAcceptOdrCar.CategoryObjAry)
                retAcceptOdrCar.CategoryObjAry = new byte[0];
            if (null == retAcceptOdrCar.FreeSrchMdlFxdNoAry)
                retAcceptOdrCar.FreeSrchMdlFxdNoAry = new byte[0];

            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了");

            return retAcceptOdrCar;
        }
        // --------------------- ADD 2013/06/28 qijh Redmine#37389 ---------------- <<<<<

        // --------------------- ADD 2017/03/30 陳艶丹 Redmine#49164 ---------------- >>>>
        /// <summary>
        /// PMTABセッション管理データを作成
        /// </summary>
        /// <param name="pmTabSalesSlipWork">PMTAB売上データ</param>
        /// <returns>PMTABセッション管理データ</returns>
        /// <remarks>
        /// <br>Note       : PMTABセッション管理データを作成する。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/03/30</br>
        /// </remarks>
        private ArrayList GetSessionMngWork(PmTabSalesSlipWork pmTabSalesSlipWork)
        {
            const string methodName = "GetSessionMngWork";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 開始");

            ArrayList PmTabSessionMngList = new ArrayList();

            PmTabSessionMngWork pmTabSessionMngWork = new PmTabSessionMngWork();
            pmTabSessionMngWork.EnterpriseCode = pmTabSalesSlipWork.EnterpriseCode;
            pmTabSessionMngWork.UpdEmployeeCode = pmTabSalesSlipWork.UpdEmployeeCode;
            pmTabSessionMngWork.UpdAssemblyId1 = pmTabSalesSlipWork.UpdAssemblyId1;
            pmTabSessionMngWork.UpdAssemblyId2 = pmTabSalesSlipWork.UpdAssemblyId2;
            pmTabSessionMngWork.LogicalDeleteCode = pmTabSalesSlipWork.LogicalDeleteCode;
            pmTabSessionMngWork.BusinessSessionId = pmTabSalesSlipWork.BusinessSessionId;
            pmTabSessionMngWork.AcptAnOdrStatus = pmTabSalesSlipWork.AcptAnOdrStatus;
            pmTabSessionMngWork.SalesSlipNum = pmTabSalesSlipWork.SalesSlipNum;

            PmTabSessionMngList.Add(pmTabSessionMngWork);

            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了");

            return PmTabSessionMngList;
        }
        // --------------------- ADD 2017/03/30 陳艶丹 Redmine#49164 ---------------- <<<<

        // --------------- ADD START 2013/07/02 wangl2 FOR Redmine#37585------>>>>
        /// <summary>
        /// 現在の売上データオブジェクトから入金データオブジェクトを取得します。
        /// </summary>
        /// <param name="salesSlip">売上データオブジェクト</param>
        /// <param name="depsitMain">入金データオブジェクト</param>
        /// <param name="depositAlw">入金引当データオブジェクト</param>
        //private void GetCurrentDepsitMain(ref SalesSlipWork salesSlip, out SearchDepsitMain depsitMain, out SearchDepositAlw depositAlw) // DEL 2013/07/03 qijh Redmine#37586
        private void GetCurrentDepsitMain(ref SalesSlip salesSlip, out SearchDepsitMain depsitMain, out SearchDepositAlw depositAlw) // ADD 2013/07/03 qijh Redmine#37586
        {
            const string methodName = "GetCurrentDepsitMain";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 開始");
            depsitMain = new SearchDepsitMain();
            SalesTtlStAcs salesTtlStAcs = new SalesTtlStAcs();// 売上全体設定マスタ
            ArrayList aList = new ArrayList();
            int status = salesTtlStAcs.SearchOnlySalesTtlInfo(out aList, this._enterpriseCode);
            if (status == 0)
            {
                if (aList != null) this.CacheSalesTtlSt(aList, this._enterpriseCode, this._loginSectionCode);
            }
            //-----------------------------------------------------------------------------
            // 対象金額算出
            //-----------------------------------------------------------------------------
            long totalPrice = salesSlip.SalesTotalTaxInc;
            if (salesSlip.TotalAmountDispWayCd == (int)TotalAmountDispWayCd.NoTotalAmount)
            {
                // 総額表示しない
                switch (salesSlip.ConsTaxLayMethod)
                {
                    case 0: // 伝票転嫁
                    case 1: // 明細転嫁
                        break;
                    case 2: // 請求親
                    case 3: // 請求子
                    case 9: // 非課税
                        // 総合計
                        totalPrice = salesSlip.ItdedSalesInTax + salesSlip.ItdedSalesOutTax + salesSlip.SalSubttlSubToTaxFre +
                                     salesSlip.ItdedSalesDisOutTax + salesSlip.ItdedSalesDisInTax + salesSlip.ItdedSalesDisTaxFre +
                                     salesSlip.SalAmntConsTaxInclu + salesSlip.SalesDisTtlTaxInclu;
                        break;
                }
            }

            //-----------------------------------------------------------------------------
            // 売上形式「売上荷」、「売掛無し」、商品区分「商品」、自動入金区分「する」の場合は自動入金作成
            //-----------------------------------------------------------------------------
            if ((salesSlip.AcptAnOdrStatus == (int)AcptAnOdrStatusState.Sales) &&
                (salesSlip.AccRecDivCd == (int)AccRecDivCd.NonAccRec) &&
                (salesSlip.SalesGoodsCd == (int)SalesGoodsCd.Goods) &&
                (this._salesTtlSt.AutoDepositCd == (int)AutoDepositCd.Write))
            {
                // 新規
                depsitMain = new SearchDepsitMain();
                depositAlw = new SearchDepositAlw();
                depsitMain.DepositRowNo[0] = 1; // 入金行番号
                depsitMain.MoneyKindCode[0] = this._salesTtlSt.AutoDepoKindCode; // 入金金種コード
                depsitMain.MoneyKindName[0] = this._salesTtlSt.AutoDepoKindName; // 入金金種名称
                depsitMain.MoneyKindDiv[0] = this._salesTtlSt.AutoDepoKindDivCd; // 入金金種区分

                // ------------- DEL 2013/07/18 qijh Redmine#38565 ---------- >>>>>
                //CustomerInfo claim;
                //status = this._customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, this._enterpriseCode, salesSlip.ClaimCode, true, false, out claim);
                //if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                //{
                //    depsitMain.ClaimName = claim.ClaimName; // 請求先名称
                //    depsitMain.ClaimName2 = claim.ClaimName2; // 請求先名称２
                //}
                // ------------- DEL 2013/07/18 qijh Redmine#38565 ---------- <<<<<

                salesSlip.AutoDepositCd = 1; // 自動入金区分(1:自動入金)
                salesSlip.AutoDepositNoteDiv = this._salesTtlSt.AutoDepositNoteDiv; // 自動入金備考区分(0:売上伝票番号 1:売上伝票備考 2:無し)
                salesSlip.DepositAlwcBlnce = totalPrice; // 入金引当残高
                salesSlip.DepositAllowanceTtl = 0; // 入金引当合計額
            }
            else
            {
                depsitMain = new SearchDepsitMain();
                depositAlw = new SearchDepositAlw();
                salesSlip.DepositAlwcBlnce = totalPrice - salesSlip.DepositAllowanceTtl; // 入金引当残高:売上伝票合計（税込み） - 入金引当合計額
            }
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了");
        }

        /// <summary>
        /// PramData→UIData移項処理
        /// </summary>
        /// <param name="searchDepsitMain">入金データオブジェクト</param>
        /// <returns>入金ワークオブジェクト</returns>
        private DepsitDataWork ParamDataFromUIData(SearchDepsitMain searchDepsitMain)
        {
            return ParamDataFromUIDataProc(searchDepsitMain);
        }

        /// <summary>
        /// PramData→UIData移項処理
        /// </summary>
        /// <param name="searchDepsitMain">入金データオブジェクト</param>
        /// <returns>入金ワークオブジェクト</returns>
        /// <remarks>
        /// </remarks>
        private static DepsitDataWork ParamDataFromUIDataProc(SearchDepsitMain searchDepsitMain)
        {
            const string methodName = "ParamDataFromUIDataProc";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 開始");

            DepsitDataWork depsitDataWork = new DepsitDataWork();
            DepsitMainWork depsitMainWork = new DepsitMainWork();
            DepsitDtlWork[] depsitDtlWorkArray = new DepsitDtlWork[searchDepsitMain.DepositRowNo.Length];

            depsitMainWork.CreateDateTime = searchDepsitMain.CreateDateTime; // 作成日時
            depsitMainWork.UpdateDateTime = searchDepsitMain.UpdateDateTime; // 更新日時
            depsitMainWork.EnterpriseCode = searchDepsitMain.EnterpriseCode; // 企業コード
            depsitMainWork.FileHeaderGuid = searchDepsitMain.FileHeaderGuid; // GUID
            depsitMainWork.UpdEmployeeCode = searchDepsitMain.UpdEmployeeCode; // 更新従業員コード
            depsitMainWork.UpdAssemblyId1 = searchDepsitMain.UpdAssemblyId1; // 更新アセンブリID1
            depsitMainWork.UpdAssemblyId2 = searchDepsitMain.UpdAssemblyId2; // 更新アセンブリID2
            depsitMainWork.LogicalDeleteCode = searchDepsitMain.LogicalDeleteCode; // 論理削除区分
            depsitMainWork.AcptAnOdrStatus = searchDepsitMain.AcptAnOdrStatus; // 受注ステータス
            depsitMainWork.DepositDebitNoteCd = searchDepsitMain.DepositDebitNoteCd; // 入金赤黒区分
            depsitMainWork.DepositSlipNo = searchDepsitMain.DepositSlipNo; // 入金伝票番号
            depsitMainWork.SalesSlipNum = searchDepsitMain.SalesSlipNum; // 売上伝票番号
            depsitMainWork.InputDepositSecCd = searchDepsitMain.InputDepositSecCd; // 入金入力拠点コード
            depsitMainWork.AddUpSecCode = searchDepsitMain.AddUpSecCode; // 計上拠点コード
            depsitMainWork.UpdateSecCd = searchDepsitMain.UpdateSecCd; // 更新拠点コード
            depsitMainWork.SubSectionCode = searchDepsitMain.SubSectionCode; // 部門コード
            depsitMainWork.DepositDate = searchDepsitMain.DepositDate; // 入金日付
            depsitMainWork.PreDepositDate = searchDepsitMain.DepositDate; // 前回入金日付
            depsitMainWork.AddUpADate = searchDepsitMain.AddUpADate; // 計上日付
            depsitMainWork.DepositTotal = searchDepsitMain.DepositTotal; // 入金計
            depsitMainWork.Deposit = searchDepsitMain.Deposit; // 入金金額
            depsitMainWork.FeeDeposit = searchDepsitMain.FeeDeposit; // 手数料入金額
            depsitMainWork.DiscountDeposit = searchDepsitMain.DiscountDeposit; // 値引入金額
            depsitMainWork.AutoDepositCd = searchDepsitMain.AutoDepositCd; // 自動入金区分
            depsitMainWork.DraftDrawingDate = searchDepsitMain.DraftDrawingDate; // 手形振出日
            depsitMainWork.DraftKind = searchDepsitMain.DraftKind; // 手形種類
            depsitMainWork.DraftKindName = searchDepsitMain.DraftKindName; // 手形種類名称
            depsitMainWork.DraftDivide = searchDepsitMain.DraftDivide; // 手形区分
            depsitMainWork.DraftDivideName = searchDepsitMain.DraftDivideName; // 手形区分名称
            depsitMainWork.DraftNo = searchDepsitMain.DraftNo; // 手形番号
            depsitMainWork.DepositAllowance = searchDepsitMain.DepositAllowance; // 入金引当額
            depsitMainWork.DepositAlwcBlnce = searchDepsitMain.DepositAlwcBlnce; // 入金引当残高
            depsitMainWork.DebitNoteLinkDepoNo = searchDepsitMain.DebitNoteLinkDepoNo; // 赤黒入金連結番号
            depsitMainWork.LastReconcileAddUpDt = searchDepsitMain.LastReconcileAddUpDt; // 最終消し込み計上日
            depsitMainWork.DepositAgentCode = searchDepsitMain.DepositAgentCode; // 入金担当者コード
            depsitMainWork.DepositAgentNm = searchDepsitMain.DepositAgentNm; // 入金担当者名称
            depsitMainWork.DepositInputAgentCd = searchDepsitMain.DepositInputAgentCd; // 入金入力者コード
            depsitMainWork.DepositInputAgentNm = searchDepsitMain.DepositInputAgentNm; // 入金入力者名称
            depsitMainWork.CustomerCode = searchDepsitMain.CustomerCode; // 得意先コード
            depsitMainWork.CustomerName = searchDepsitMain.CustomerName; // 得意先名称
            depsitMainWork.CustomerName2 = searchDepsitMain.CustomerName2; // 得意先名称2
            depsitMainWork.CustomerSnm = searchDepsitMain.CustomerSnm; // 得意先略称
            depsitMainWork.ClaimCode = searchDepsitMain.ClaimCode; // 請求先コード
            depsitMainWork.ClaimName = searchDepsitMain.ClaimName; // 請求先名称
            depsitMainWork.ClaimName2 = searchDepsitMain.ClaimName2; // 請求先名称2
            depsitMainWork.ClaimSnm = searchDepsitMain.ClaimSnm; // 請求先略称
            depsitMainWork.Outline = searchDepsitMain.Outline; // 伝票摘要
            depsitMainWork.BankCode = searchDepsitMain.BankCode; // 銀行コード
            depsitMainWork.BankName = searchDepsitMain.BankName; // 銀行名称

            for (int i = 0; i < searchDepsitMain.DepositRowNo.Length; i++)
            {
                DepsitDtlWork depsitDtlWork = new DepsitDtlWork();
                depsitDtlWork.DepositRowNo = searchDepsitMain.DepositRowNo[i]; // 入金行番号
                depsitDtlWork.MoneyKindCode = searchDepsitMain.MoneyKindCode[i]; // 金種コード
                depsitDtlWork.MoneyKindName = searchDepsitMain.MoneyKindName[i]; // 金種名称
                depsitDtlWork.MoneyKindDiv = searchDepsitMain.MoneyKindDiv[i]; // 金種区分
                depsitDtlWork.Deposit = searchDepsitMain.DepositDtl[i]; // 入金金額
                depsitDtlWork.ValidityTerm = searchDepsitMain.ValidityTerm[i]; // 有効期限
                depsitDtlWorkArray[i] = depsitDtlWork;
            }

            DepsitDataUtil.Union(out depsitDataWork, depsitMainWork, depsitDtlWorkArray);
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了");
            return depsitDataWork;
        }
        // --------------- ADD END 2013/07/02 wangl2 FOR Redmine#37585--------<<<<        
        #endregion ■ 売上データ作成

        #region ■ SCMデータ作成
        /// <summary>
        /// SCM受注データを作成
        /// </summary>
        /// <param name="salesSlip">売上データ</param>
        /// <param name="customerInfo">得意先情報</param>
        /// <returns>SCM受注データ</returns>
        //private SCMAcOdrDataWork GetUpdSCMAcOdrData(SalesSlipWork salesSlip, CustomerInfo customerInfo) // DEL 2013/07/03 qijh Redmine#37586
        private SCMAcOdrDataWork GetUpdSCMAcOdrData(SalesSlip salesSlip, CustomerInfo customerInfo) // ADD 2013/07/03 qijh Redmine#37586
        {
            // タブレットログ対応　--------------------------------->>>>>
            const string methodName = "GetUpdSCMAcOdrData";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 開始");
            // タブレットログ対応　---------------------------------<<<<<

            SCMAcOdrDataWork retSCMAcOdrData = new SCMAcOdrDataWork();

            retSCMAcOdrData.EnterpriseCode = salesSlip.EnterpriseCode; // 企業コード : 売上データより同項目
            retSCMAcOdrData.UpdEmployeeCode = salesSlip.UpdEmployeeCode; // 更新従業員コード : 売上データより同項目
            retSCMAcOdrData.UpdAssemblyId1 = salesSlip.UpdAssemblyId1; // 更新アセンブリID1 : 売上データより同項目
            retSCMAcOdrData.UpdAssemblyId2 = salesSlip.UpdAssemblyId2; // 更新アセンブリID2 : 売上データより同項目
            retSCMAcOdrData.LogicalDeleteCode = salesSlip.LogicalDeleteCode; // 論理削除区分 : 売上データより同項目
            retSCMAcOdrData.InqOriginalEpCd = customerInfo.CustomerEpCode.Trim(); // 問合せ元企業コード : 得意先マスタより得意先企業コード//@@@@20230303
            retSCMAcOdrData.InqOriginalSecCd = customerInfo.CustomerSecCode; // 問合せ元拠点コード : 得意先マスタより得意先拠点コード
            retSCMAcOdrData.InqOtherEpCd = salesSlip.EnterpriseCode; // 問合せ先企業コード : 売上データより企業コード
            retSCMAcOdrData.InqOtherSecCd = salesSlip.SectionCode; // 問合せ先拠点コード : 売上データより拠点コード
            //retSCMAcOdrData.InquiryNumber = -1; // 問合せ番号 : -1を固定でセット// DEL 2013/07/02 songg Redmine#37692
            retSCMAcOdrData.InquiryNumber = 0; // 問合せ番号                      // ADD 2013/07/02 songg Redmine#37692
            retSCMAcOdrData.CustomerCode = salesSlip.CustomerCode; // 得意先コード : 売上データより同項目
            retSCMAcOdrData.AnswerDivCd = 20; // 回答区分 : 20を固定でセット
            retSCMAcOdrData.InqOrdNote = salesSlip.SlipNote; // 問合せ・発注備考 : 売上データより伝票備考
            retSCMAcOdrData.AnsEmployeeCd = salesSlip.SalesEmployeeCd; // 回答従業員コード : 売上データより販売従業員コード
            retSCMAcOdrData.AnsEmployeeNm = salesSlip.SalesEmployeeNm; // 回答従業員名称 : 売上データより販売従業員名称
            retSCMAcOdrData.InquiryDate = salesSlip.SalesDate; // 問合せ日 : 売上データより売上日付
            retSCMAcOdrData.AcptAnOdrStatus = salesSlip.AcptAnOdrStatus; // 受注ステータス : 売上データより同項目
            retSCMAcOdrData.SalesSlipNum = salesSlip.SalesSlipNum; // 売上伝票番号 : 売上データより同項目
            retSCMAcOdrData.SalesTotalTaxInc = salesSlip.SalesTotalTaxInc; // 売上伝票合計（税込み） : 売上データより同項目
            retSCMAcOdrData.SalesSubtotalTax = salesSlip.SalesSubtotalTax; // 売上小計（税） : 売上データより同項目
            retSCMAcOdrData.InqOrdDivCd = 2; // 問合せ・発注種別 : 2を固定でセット
            retSCMAcOdrData.InqOrdAnsDivCd = 2; // 問発・回答種別 : 2を固定でセット
            retSCMAcOdrData.SfPmCprtInstSlipNo = salesSlip.PartySaleSlipNum; // SF-PM連携指示書番号 : 売上データより相手先伝票番号
            retSCMAcOdrData.AcceptOrOrderKind = 1; // 受発注種別 : 1を固定でセット
            retSCMAcOdrData.TabUseDiv = 1; //タブレット使用区分: 0：使用しない,1：使用する // ADD 2013/07/09 songg Redmine#38015
            // ADD 2013/07/26 yugami 社内指摘一覧№431対応 -------------------------------------------->>>>>
            retSCMAcOdrData.AnswerCreateDiv = 2; // 回答作成区分: 2を固定でセット
            // ADD 2013/07/26 yugami 社内指摘一覧№431対応 --------------------------------------------<<<<<

            // タブレットログ対応　--------------------------------->>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了");
            // タブレットログ対応　---------------------------------<<<<<
            return retSCMAcOdrData;
        }

        /// <summary>
        /// SCM受注データ（車両情報）を作成
        /// </summary>
        /// <param name="acceptOdrCar">車両管理データ</param>
        /// <param name="salesSlip">売上データ</param>
        /// <param name="pmTabSalesDtCar">PMTAB受注マスタ（車両）</param>
        /// <param name="customerInfo">得意先情報</param>
        /// <param name="pmTabAcpOdrCar">PMTAB受注マスタ(車両)</param>
        /// <returns>SCM受注データ（車両情報）</returns>
        //private SCMAcOdrDtCarWork GetUpdSCMAcOdrDtCar(AcceptOdrCarWork acceptOdrCar, SalesSlipWork salesSlip, PmTabSalesDtCarWork pmTabSalesDtCar, CustomerInfo customerInfo) // DEL 2013/06/28 qijh Redmine#37389
        //private SCMAcOdrDtCarWork GetUpdSCMAcOdrDtCar(CarManagementWork acceptOdrCar, SalesSlipWork salesSlip, PmTabSalesDtCarWork pmTabSalesDtCar, CustomerInfo customerInfo, PmTabAcpOdrCarWork pmTabAcpOdrCar) // ADD 2013/06/28 qijh Redmine#37389 // DEL 2013/07/03 qijh Redmine#37586
        private SCMAcOdrDtCarWork GetUpdSCMAcOdrDtCar(CarManagementWork acceptOdrCar, SalesSlip salesSlip, PmTabSalesDtCarWork pmTabSalesDtCar, CustomerInfo customerInfo, PmTabAcpOdrCarWork pmTabAcpOdrCar) // ADD 2013/07/03 qijh Redmine#37586
        {
            // タブレットログ対応　--------------------------------->>>>>
            const string methodName = "GetUpdSCMAcOdrDtCar";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 開始");
            // タブレットログ対応　---------------------------------<<<<<

            SCMAcOdrDtCarWork retSCMAcOdrDtCar = new SCMAcOdrDtCarWork();

            retSCMAcOdrDtCar.EnterpriseCode = acceptOdrCar.EnterpriseCode; // 企業コード : 受注マスタ（車両）より同項目
            retSCMAcOdrDtCar.UpdEmployeeCode = acceptOdrCar.UpdEmployeeCode; // 更新従業員コード : 受注マスタ（車両）より同項目
            retSCMAcOdrDtCar.UpdAssemblyId1 = acceptOdrCar.UpdAssemblyId1; // 更新アセンブリID1 : 受注マスタ（車両）より同項目
            retSCMAcOdrDtCar.UpdAssemblyId2 = acceptOdrCar.UpdAssemblyId2; // 更新アセンブリID2 : 受注マスタ（車両）より同項目
            retSCMAcOdrDtCar.LogicalDeleteCode = acceptOdrCar.LogicalDeleteCode; // 論理削除区分 : 受注マスタ（車両）より同項目
            retSCMAcOdrDtCar.InqOriginalEpCd = customerInfo.CustomerEpCode.Trim(); // 問合せ元企業コード : 得意先マスタより得意先企業コード//@@@@20230303
            retSCMAcOdrDtCar.InqOriginalSecCd = customerInfo.CustomerSecCode; // 問合せ元拠点コード : 得意先マスタより得意先拠点コード
            // retSCMAcOdrDtCar.InquiryNumber = -1; // 問合せ番号 : -1を固定でセット // DEL 2013/07/02 songg Redmine#37692
            retSCMAcOdrDtCar.InquiryNumber = 0; // 問合せ番号                        // ADD 2013/07/02 songg Redmine#37692
            retSCMAcOdrDtCar.NumberPlate1Code = acceptOdrCar.NumberPlate1Code; // 陸運事務所番号 : 受注マスタ（車両）より同項目
            retSCMAcOdrDtCar.NumberPlate1Name = acceptOdrCar.NumberPlate1Name; // 陸運事務局名称 : 受注マスタ（車両）より同項目
            retSCMAcOdrDtCar.NumberPlate2 = acceptOdrCar.NumberPlate2; // 車両登録番号（種別） : 受注マスタ（車両）より同項目
            retSCMAcOdrDtCar.NumberPlate3 = acceptOdrCar.NumberPlate3; // 車両登録番号（カナ） : 受注マスタ（車両）より同項目
            retSCMAcOdrDtCar.NumberPlate4 = acceptOdrCar.NumberPlate4; // 車両登録番号（プレート番号） : 受注マスタ（車両）より同項目
            retSCMAcOdrDtCar.ModelDesignationNo = acceptOdrCar.ModelDesignationNo; // 型式指定番号 : 受注マスタ（車両）より同項目
            retSCMAcOdrDtCar.CategoryNo = acceptOdrCar.CategoryNo; // 類別番号 : 受注マスタ（車両）より同項目
            retSCMAcOdrDtCar.MakerCode = acceptOdrCar.MakerCode; // メーカーコード : 受注マスタ（車両）より同項目
            retSCMAcOdrDtCar.ModelCode = acceptOdrCar.ModelCode; // 車種コード : 受注マスタ（車両）より同項目
            retSCMAcOdrDtCar.ModelSubCode = acceptOdrCar.ModelSubCode; // 車種サブコード : 受注マスタ（車両）より同項目
            retSCMAcOdrDtCar.FullModel = acceptOdrCar.FullModel; // 型式（フル型） : 受注マスタ（車両）より同項目
            retSCMAcOdrDtCar.FrameNo = acceptOdrCar.FrameNo; // 車台番号 : 受注マスタ（車両）より同項目
            retSCMAcOdrDtCar.FrameModel = acceptOdrCar.FrameModel; // 車台型式 : 受注マスタ（車両）より同項目
            retSCMAcOdrDtCar.RpColorCode = acceptOdrCar.ColorCode; // リペアカラーコード : 受注マスタ（車両）よりカラーコード
            retSCMAcOdrDtCar.ColorName1 = acceptOdrCar.ColorName1; // カラー名称1 : 受注マスタ（車両）より同項目
            retSCMAcOdrDtCar.TrimCode = acceptOdrCar.TrimCode; // トリムコード : 受注マスタ（車両）より同項目
            retSCMAcOdrDtCar.TrimName = acceptOdrCar.TrimName; // トリム名称 : 受注マスタ（車両）より同項目
            //retSCMAcOdrDtCar.AcptAnOdrStatus = acceptOdrCar.AcptAnOdrStatus; // 受注ステータス : 受注マスタ（車両）より同項目
            //retSCMAcOdrDtCar.AcptAnOdrStatus = pmTabAcpOdrCar.AcptAnOdrStatus; // 受注ステータス : 受注マスタ（車両）より同項目  // DEL 2013/07/02 songg Redmine#37692
            retSCMAcOdrDtCar.AcptAnOdrStatus = pmTabSalesDtCar.AcptAnOdrStatus;  // 受注ステータス                                 // ADD 2013/07/02 songg Redmine#37692
            retSCMAcOdrDtCar.EngineModelNm = acceptOdrCar.EngineModelNm; // エンジン型式名称 : 受注マスタ（車両）より同項目
            retSCMAcOdrDtCar.FirstEntryDateNumTyp = acceptOdrCar.FirstEntryDate; // 初年度（NUMタイプ） : 受注マスタ（車両）より同項目
            // UPD 2013/07/19 吉岡 指摘確認事項一覧№373対応 -------->>>>>>>>>>>>>>>>>>>>>
            // retSCMAcOdrDtCar.EquipPrtsObj = acceptOdrCar.CategoryObjAry; // 装備部品オブジェクト : 受注マスタ（車両）より同項目
            retSCMAcOdrDtCar.EquipPrtsObj = new byte[0];  // 装備部品オブジェクト : 設定無し（売伝からいきなり回答の場合は設定無し）
            // UPD 2013/07/19 吉岡 指摘確認事項一覧№373対応 --------<<<<<<<<<<<<<<<<<<<<<<
            retSCMAcOdrDtCar.SalesSlipNum = salesSlip.SalesSlipNum; // 売上伝票番号 : 受注マスタ（車両）より同項目
            retSCMAcOdrDtCar.ProduceTypeOfYearNum = pmTabSalesDtCar.ProduceTypeOfYearNum; // 生産年式（NUMタイプ） : 受注マスタ（車両）より同項目
            retSCMAcOdrDtCar.CarNo = pmTabSalesDtCar.CarNo; // 号車 : 受注マスタ（車両）より同項目
            retSCMAcOdrDtCar.MakerName = pmTabSalesDtCar.MakerName; // メーカー名称 : 受注マスタ（車両）より同項目
            retSCMAcOdrDtCar.GradeName = pmTabSalesDtCar.GradeName; // グレード名称 : 受注マスタ（車両）より同項目
            retSCMAcOdrDtCar.BodyName = pmTabSalesDtCar.BodyName; // ボディー名称 : 受注マスタ（車両）より同項目
            retSCMAcOdrDtCar.DoorCount = pmTabSalesDtCar.DoorCount; // ドア数 : 受注マスタ（車両）より同項目
            retSCMAcOdrDtCar.CmnNmEngineDisPlace = pmTabSalesDtCar.CmnNmEngineDisPlace; // 通称排気量 : 受注マスタ（車両）より同項目
            retSCMAcOdrDtCar.EngineModel = pmTabSalesDtCar.EngineModel; // 原動機型式（エンジン） : 受注マスタ（車両）より同項目
            retSCMAcOdrDtCar.NumberOfGear = pmTabSalesDtCar.NumberOfGear; // 変速段数 : 受注マスタ（車両）より同項目
            retSCMAcOdrDtCar.GearNm = pmTabSalesDtCar.GearNm; // 変速機名称 : 受注マスタ（車両）より同項目
            retSCMAcOdrDtCar.EDivNm = pmTabSalesDtCar.EDivNm; // E区分名称 : 受注マスタ（車両）より同項目
            retSCMAcOdrDtCar.TransmissionNm = pmTabSalesDtCar.TransmissionNm; // ミッション名称 : 受注マスタ（車両）より同項目
            retSCMAcOdrDtCar.ShiftNm = pmTabSalesDtCar.ShiftNm; // シフト名称 : 受注マスタ（車両）より同項目
            // --------------- ADD START 2013/07/09 wangl2 FOR Redmine#38014------>>>>
            retSCMAcOdrDtCar.ModelName = pmTabSalesDtCar.ModelName; // 車種名：PMTAB売上データ（車両情報）より同項目
            //retSCMAcOdrDtCar.CarInspectCertModel = acceptOdrCar.FullModel;// 型式（フル型） : 受注マスタ（車両）より同項目// DEL 2013/07/19 qijh FOR Redmine#38783
            // --------------- ADD END 2013/07/09 wangl2 FOR Redmine#38014--------<<<<
            // --------------- ADD START 2013/07/19 qijh FOR Redmine#38783------>>>>
            // 車検証型式　: 受注マスタ（車両）より設定
            string carInspectCertModel = string.Empty;
            if (acceptOdrCar.ExhaustGasSign != string.Empty)
            {
                carInspectCertModel = acceptOdrCar.ExhaustGasSign;
                if (acceptOdrCar.SeriesModel != string.Empty) carInspectCertModel = carInspectCertModel + '-' + acceptOdrCar.SeriesModel;
            }
            else
            {
                if (acceptOdrCar.SeriesModel != string.Empty) carInspectCertModel = acceptOdrCar.SeriesModel;
            }
            retSCMAcOdrDtCar.CarInspectCertModel = carInspectCertModel;
            // --------------- ADD END 2013/07/19 qijh FOR Redmine#38783--------<<<<
            // UPD 2013/07/19 吉岡 指摘確認事項一覧№373対応 -------->>>>>>>>>>>>>>>>>>>>>
            #region 旧ソース
            //if (retSCMAcOdrDtCar.EquipPrtsObj == null)
            //    retSCMAcOdrDtCar.EquipPrtsObj = new byte[0];
            //if (retSCMAcOdrDtCar.CarAddInf == null)
            //    retSCMAcOdrDtCar.CarAddInf = new byte[0];
            //if (retSCMAcOdrDtCar.EquipObj == null)
            //    retSCMAcOdrDtCar.EquipObj = new byte[0];
            #endregion
            // 売伝からいきなり回答の場合はも設定無し
            retSCMAcOdrDtCar.CarAddInf = new byte[0];
            retSCMAcOdrDtCar.EquipObj = new byte[0];
            // UPD 2013/07/19 吉岡 指摘確認事項一覧№373対応 --------<<<<<<<<<<<<<<<<<<<<<<

            // タブレットログ対応　--------------------------------->>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了");
            // タブレットログ対応　---------------------------------<<<<<
            return retSCMAcOdrDtCar;
        }

        /// <summary>
        /// SCM受注明細データ（回答）を作成
        /// </summary>
        /// <param name="salesDetail">売上明細データ</param>
        /// <param name="customerInfo">得意先情報</param>
        /// <returns>SCM受注明細データ（回答）</returns>
        //private SCMAcOdrDtlAsWork GetUpdSCMAcOdrDtlAs(SalesDetailWork salesDetail, CustomerInfo customerInfo) // DEL 2013/07/03 qijh Redmine#37586
        private SCMAcOdrDtlAsWork GetUpdSCMAcOdrDtlAs(SalesDetail salesDetail, CustomerInfo customerInfo) // ADD 2013/07/03 qijh Redmine#37586
        {
            // タブレットログ対応　--------------------------------->>>>>
            const string methodName = "GetUpdSCMAcOdrDtlAs";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 開始");
            // タブレットログ対応　---------------------------------<<<<<

            SCMAcOdrDtlAsWork retSCMAcOdrDtlAs = new SCMAcOdrDtlAsWork();

            retSCMAcOdrDtlAs.EnterpriseCode = salesDetail.EnterpriseCode; // 企業コード : 売上明細データより同項目
            retSCMAcOdrDtlAs.UpdEmployeeCode = salesDetail.UpdEmployeeCode; // 更新従業員コード : 売上明細データより同項目
            retSCMAcOdrDtlAs.UpdAssemblyId1 = salesDetail.UpdAssemblyId1; // 更新アセンブリID1 : 売上明細データより同項目
            retSCMAcOdrDtlAs.UpdAssemblyId2 = salesDetail.UpdAssemblyId2; // 更新アセンブリID2 : 売上明細データより同項目
            retSCMAcOdrDtlAs.LogicalDeleteCode = salesDetail.LogicalDeleteCode; // 論理削除区分 : 売上明細データより同項目
            retSCMAcOdrDtlAs.InqOriginalEpCd = customerInfo.CustomerEpCode.Trim(); // 問合せ元企業コード : 得意先マスタより得意先企業コード//@@@@20230303
            retSCMAcOdrDtlAs.InqOriginalSecCd = customerInfo.CustomerSecCode; // 問合せ元拠点コード : 得意先マスタより得意先拠点コード
            retSCMAcOdrDtlAs.InqOtherEpCd = salesDetail.EnterpriseCode; // 問合せ先企業コード : 売上明細データより企業コード
            retSCMAcOdrDtlAs.InqOtherSecCd = salesDetail.SectionCode; // 問合せ先拠点コード : 売上明細データより拠点コード
            // retSCMAcOdrDtlAs.InquiryNumber = -1; // 問合せ番号 : -1を固定でセット // DEL 2013/07/02 songg Redmine#37692
            retSCMAcOdrDtlAs.InquiryNumber = 0; // 問合せ番号                        // ADD 2013/07/02 songg Redmine#37692
            retSCMAcOdrDtlAs.InqRowNumber = -1; // 問合せ行番号 : -1を固定でセット
            retSCMAcOdrDtlAs.InqRowNumDerivedNo = -1; // 問合せ行番号枝番 : -1を固定でセット
            retSCMAcOdrDtlAs.RecyclePrtKindCode = salesDetail.RecycleDiv; // リサイクル部品種別 : 売上明細データよりリサイクル区分
            retSCMAcOdrDtlAs.RecyclePrtKindName = salesDetail.RecycleDivNm; // リサイクル部品種別名称 : 売上明細データよりリサイクル区分名称
            retSCMAcOdrDtlAs.AnswerDeliveryDate = salesDetail.AnswerDelivDate; // 回答納期 : 売上明細データより同項目
            retSCMAcOdrDtlAs.BLGoodsCode = salesDetail.BLGoodsCode; // BL商品コード : 売上明細データより同項目
            retSCMAcOdrDtlAs.AnsGoodsName = salesDetail.GoodsName; // 回答商品名 : 売上明細データより同項目
            retSCMAcOdrDtlAs.SalesOrderCount = salesDetail.ShipmentCnt; // 発注数 : 売上明細データより出荷数
            retSCMAcOdrDtlAs.DeliveredGoodsCount = salesDetail.ShipmentCnt; // 納品数 : 売上明細データより出荷数
            retSCMAcOdrDtlAs.GoodsNo = salesDetail.GoodsNo; // 商品番号 : 売上明細データより同項目
            retSCMAcOdrDtlAs.GoodsMakerCd = salesDetail.GoodsMakerCd; // 商品メーカーコード : 売上明細データより同項目
            retSCMAcOdrDtlAs.GoodsMakerNm = salesDetail.MakerName; // 商品メーカー名称 : 売上明細データより同項目
            retSCMAcOdrDtlAs.ListPrice = (long)salesDetail.ListPriceTaxExcFl; // 定価 : 売上明細データより定価（税抜，浮動）
            retSCMAcOdrDtlAs.UnitPrice = (long)salesDetail.SalesUnPrcTaxExcFl; // 単価 : 売上明細データより売上単価（税抜，浮動）
            retSCMAcOdrDtlAs.RoughRrofit = (long)(salesDetail.ListPriceTaxExcFl - salesDetail.SalesUnitCost); // 粗利額 : 売上明細データより定価（税抜，浮動）－原価単価

            // 粗利率 : 売上明細データより（売上単価（税抜，浮動）－原価単価）÷売上単価（税抜，浮動）
            retSCMAcOdrDtlAs.RoughRate = 0.0;
            #region DEL 2013/07/23 qijh Redmine#38980 - #5
            //if (salesDetail.ListPriceTaxExcFl > 0.0)
            //{
            //    retSCMAcOdrDtlAs.RoughRate = (salesDetail.ListPriceTaxExcFl - salesDetail.SalesUnitCost) / salesDetail.ListPriceTaxExcFl;
            //    retSCMAcOdrDtlAs.RoughRate = CalculatorAgent.RoundOff(retSCMAcOdrDtlAs.RoughRate, 3); // ADD 2013/07/23 qijh Redmine#38980
            //}
            #endregion  DEL 2013/07/23 qijh Redmine#38980 - #5
            // ------------- ADD 2013/07/23 qijh Redmine#38980 - #5 ---------- >>>>>
            if (salesDetail.SalesUnPrcTaxExcFl > 0.0)
            {
                retSCMAcOdrDtlAs.RoughRate = (salesDetail.SalesUnPrcTaxExcFl - salesDetail.SalesUnitCost) / salesDetail.SalesUnPrcTaxExcFl * 100;
                retSCMAcOdrDtlAs.RoughRate = CalculatorAgent.RoundOff(retSCMAcOdrDtlAs.RoughRate, 3);
            }
            // ------------- ADD 2013/07/23 qijh Redmine#38980 - #5 ---------- <<<<<

            retSCMAcOdrDtlAs.CommentDtl = salesDetail.DtlNote; // 備考(明細) : 売上明細データより明細備考
            retSCMAcOdrDtlAs.ShelfNo = salesDetail.WarehouseShelfNo; // 棚番 : 売上明細データより倉庫棚番
            retSCMAcOdrDtlAs.AcptAnOdrStatus = salesDetail.AcptAnOdrStatus; // 受注ステータス : 売上明細データより同項目
            retSCMAcOdrDtlAs.SalesSlipNum = salesDetail.SalesSlipNum; // 売上伝票番号 : 売上明細データより同項目
            retSCMAcOdrDtlAs.SalesRowNo = salesDetail.SalesRowNo; // 売上行番号 : 売上明細データより同項目
            retSCMAcOdrDtlAs.CampaignCode = salesDetail.CampaignCode; // キャンペーンコード : 売上明細データより同項目
            retSCMAcOdrDtlAs.InqOrdDivCd = 2; // 問合せ・発注種別 : 2を固定でセット
            retSCMAcOdrDtlAs.DisplayOrder = salesDetail.InqRowNumber; // 表示順位 : 売上明細データより問合せ行番号
            retSCMAcOdrDtlAs.WarehouseCode = salesDetail.WarehouseCode; // 倉庫コード : 売上明細データより同項目
            retSCMAcOdrDtlAs.WarehouseName = salesDetail.WarehouseName; // 倉庫名称 : 売上明細データより同項目
            retSCMAcOdrDtlAs.WarehouseShelfNo = salesDetail.WarehouseShelfNo; // 倉庫棚番 : 売上明細データより同項目
            retSCMAcOdrDtlAs.PmPrsntCount = 0; // PM現在庫数 続けの補正処理でセット 
            retSCMAcOdrDtlAs.GoodsSpecialNote = salesDetail.GoodsSpecialNote; // 商品規格・特記事項 : 売上明細データより同項目
            // ADD 吉岡 2013/08/07 Redmine#39686 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            retSCMAcOdrDtlAs.InqOrgDtlDiscGuid = Guid.NewGuid();  // 問合せ元明細識別GUID
            // ADD 吉岡 2013/08/07 Redmine#39686 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

            // ADD 2013/08/29 Redmine#40183対応 ------------------------------------------->>>>>
            retSCMAcOdrDtlAs.PureGoodsMakerCd = salesDetail.CmpltGoodsMakerCd;  // 純正商品メーカーコード：売上明細データよりメーカーコード（一式）
            // ADD 2013/08/29 Redmine#40183対応 -------------------------------------------<<<<<

            // タブレットログ対応　--------------------------------->>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了");
            // タブレットログ対応　---------------------------------<<<<<
            return retSCMAcOdrDtlAs;
        }
        #endregion ■ SCMデータ作成

        #region ■ 情報取得処理
        // -------------- ADD 2013/07/12 qijh Redmine#38166 ----------- >>>>>
        /// <summary>
        /// PMTAB全体設定マスタ（拠点別）を取得
        /// </summary>
        /// <param name="pmTabTtlStSec">PMTAB全体設定マスタ（拠点別）情報</param>
        private void GetPmTabTtlStSec(out PmTabTtlStSec pmTabTtlStSec)
        {
            pmTabTtlStSec = new PmTabTtlStSec(); // ディフォルト値(検索できない場合利用)
            ArrayList searchResultList = null;
            // ログイン拠点
            int status = this.PmTabTtlStSecAcs.Search(out searchResultList, this._enterpriseCode, this._loginSectionCode);
            if ((int)ConstantManagement.DB_Status.ctDB_NORMAL == status && null != searchResultList && searchResultList.Count > 0)
            {
                pmTabTtlStSec = searchResultList[0] as PmTabTtlStSec;
                return;
            }
            // 全社
            status = this.PmTabTtlStSecAcs.Search(out searchResultList, this._enterpriseCode, ctSectionCode);
            if ((int)ConstantManagement.DB_Status.ctDB_NORMAL == status && null != searchResultList && searchResultList.Count > 0)
            {
                pmTabTtlStSec = searchResultList[0] as PmTabTtlStSec;
                return;
            }
            // 上記取得できない場合、ディフォルト値を戻す
        }
        // -------------- ADD 2013/07/12 qijh Redmine#38166 ----------- <<<<<

        // ---------------- ADD 2013/06/29 qijh Redmine#37474 ------------ >>>>>
        /// <summary>
        /// 見積初期値設定マスタを取得
        /// </summary>
        private void GetEstimateDefSet()
        {
            ArrayList aList;
            int status = new EstimateDefSetAcs().Search(out aList, this._enterpriseCode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (aList != null) CacheEstimateDefSet(aList, this._enterpriseCode, this._loginSectionCode);
            }
        }

        /// <summary>
        /// 見積初期値設定マスタキャッシュ
        /// </summary>
        /// <param name="estimateDefSetList">見積初期値設定リスト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        private void CacheEstimateDefSet(ArrayList estimateDefSetList, string enterpriseCode, string sectionCode)
        {
            if (estimateDefSetList != null)
            {
                List<EstimateDefSet> list = new List<EstimateDefSet>((EstimateDefSet[])estimateDefSetList.ToArray(typeof(EstimateDefSet)));

                this._estimateDefSet = list.Find(
                    delegate(EstimateDefSet estimatedef)
                    {
                        if ((estimatedef.SectionCode.Trim() == sectionCode.Trim()) &&
                            (estimatedef.EnterpriseCode.Trim() == enterpriseCode.Trim()))
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                );
                if (this._estimateDefSet != null) return;

                this._estimateDefSet = list.Find(
                    delegate(EstimateDefSet estimatedef)
                    {
                        if ((estimatedef.SectionCode.Trim() == ctSectionCode.Trim()) &&
                            (estimatedef.EnterpriseCode.Trim() == enterpriseCode.Trim()))
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                );

            }
        }

        /// <summary>
        /// 売上全体設定マスタを取得
        /// </summary>
        private void GetSalesTtlSt()
        {
            ArrayList aList;
            SalesTtlStAcs salesTtlStAcs = new SalesTtlStAcs();
            salesTtlStAcs.IsLocalDBRead = false;
            int status = salesTtlStAcs.SearchOnlySalesTtlInfo(out aList, this._enterpriseCode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (aList != null) this.CacheSalesTtlSt(aList, this._enterpriseCode, this._loginSectionCode);
            }
        }

        /// <summary>
        /// 売上全体設定マスタキャッシュ
        /// </summary>
        /// <param name="salesTtlStList">売上全体設定リスト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        private void CacheSalesTtlSt(ArrayList salesTtlStList, string enterpriseCode, string sectionCode)
        {
            if (salesTtlStList != null)
            {
                List<SalesTtlSt> list = new List<SalesTtlSt>((SalesTtlSt[])salesTtlStList.ToArray(typeof(SalesTtlSt)));

                this._salesTtlSt = list.Find(
                    delegate(SalesTtlSt salesttl)
                    {
                        if ((salesttl.SectionCode.Trim() == sectionCode.Trim()) &&
                            (salesttl.EnterpriseCode.Trim() == enterpriseCode.Trim()))
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                );

                if (this._salesTtlSt != null) return;

                this._salesTtlSt = list.Find(
                    delegate(SalesTtlSt salesttl)
                    {
                        if ((salesttl.SectionCode.Trim() == ctSectionCode.Trim()) &&
                            (salesttl.EnterpriseCode.Trim() == enterpriseCode.Trim()))
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                );
            }
        }

        /// <summary>
        /// 受発注全体設定を取得
        /// </summary>
        private void GetAcptAnOdrTtlSt()
        {
            ArrayList aList;
            AcptAnOdrTtlStAcs acptAnOdrTtlStAcs = new AcptAnOdrTtlStAcs();  // 受発注全体設定マスタ
            acptAnOdrTtlStAcs.IsLocalDBRead = false;
            int status = acptAnOdrTtlStAcs.Search(out aList, this._enterpriseCode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (aList != null) this.CacheAcptAnOdrTtlSt(aList, this._enterpriseCode, this._loginSectionCode);
            }

        }

        /// <summary>
        /// 受発注管理全体設定マスタキャッシュ
        /// </summary>
        /// <param name="acptAnOdrTtlStList">受発注管理全体設定マスタリスト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        private void CacheAcptAnOdrTtlSt(ArrayList acptAnOdrTtlStList, string enterpriseCode, string sectionCode)
        {
            if (acptAnOdrTtlStList != null)
            {
                List<AcptAnOdrTtlSt> list = new List<AcptAnOdrTtlSt>((AcptAnOdrTtlSt[])acptAnOdrTtlStList.ToArray(typeof(AcptAnOdrTtlSt)));

                this._acptAnOdrTtlSt = list.Find(
                    delegate(AcptAnOdrTtlSt acptttl)
                    {
                        if ((acptttl.SectionCode.Trim() == sectionCode.Trim()) &&
                            (acptttl.EnterpriseCode.Trim() == enterpriseCode.Trim()))
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                );

                if (this._acptAnOdrTtlSt != null) return;

                this._acptAnOdrTtlSt = list.Find(
                    delegate(AcptAnOdrTtlSt acptttl)
                    {
                        if ((acptttl.SectionCode.Trim() == ctSectionCode.Trim()) &&
                            (acptttl.EnterpriseCode.Trim() == enterpriseCode.Trim()))
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                );
            }
        }
        // ---------------- ADD 2013/06/29 qijh Redmine#37474 ------------ <<<<<

        // DEL 吉岡 2013/08/09 Redmine#39820 --------->>>>>>>>>>>>>>>>>>>>>>>>>
        #region 旧ソース
        ///// <summary>
        ///// BLP送信区分を取得
        ///// </summary>
        ///// <param name="psEnterpriseCode">企業コード</param>
        ///// <param name="customerCode">得意先コード</param>
        ///// <param name="blpSendingDiv">BLP送信区分</param>
        ///// <param name="errorMessage">エラーメッセージ</param>
        ///// <returns>ステータス</returns>
        //private ConstantManagement.MethodResult GetBLPSendingDiv(string psEnterpriseCode, int customerCode,
        //    out int blpSendingDiv, out string errorMessage)
        //{
        //    // タブレットログ対応　--------------------------------->>>>>
        //    const string methodName = "GetBLPSendingDiv";
        //    EasyLogger.Write(CLASS_NAME, methodName, methodName + " 開始");
        //    // タブレットログ対応　---------------------------------<<<<<

        //    errorMessage = string.Empty;
        //    blpSendingDiv = 0;

        //    PmTabTtlStCustWork pmTabTtlStCustWork = new PmTabTtlStCustWork();
        //    pmTabTtlStCustWork.EnterpriseCode = psEnterpriseCode;
        //    pmTabTtlStCustWork.CustomerCode = customerCode;

        //    object objSearchCond = pmTabTtlStCustWork;
        //    object objRetList;
        //    int status = this._iPmTabTtlStCustDB.Search(out objRetList, objSearchCond, 0, ConstantManagement.LogicalMode.GetData0);
        //    ArrayList resultList = objRetList as ArrayList;

        //    if ((int)ConstantManagement.DB_Status.ctDB_NORMAL != status || null == resultList || 0 == resultList.Count)
        //    {
        //        errorMessage = "Not Found";
        //        // タブレットログ対応　--------------------------------->>>>>
        //        EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了 ConstantManagement.MethodResult.ctFNC_ERROR");
        //        // タブレットログ対応　---------------------------------<<<<<
        //        //return ConstantManagement.MethodResult.ctFNC_ERROR; // DEL 2013/06/26 qijh Redmine#37330
        //        // -------- ADD 2013/06/26 qijh Redmine#37330 --------- >>>>>
        //        // 処理は終了せず、sendingDiv = 0 として処理を続行
        //        errorMessage = string.Empty;
        //        blpSendingDiv = 0;
        //        return ConstantManagement.MethodResult.ctFNC_NORMAL;
        //        // -------- ADD 2013/06/26 qijh Redmine#37330 --------- <<<<<
        //    }

        //    blpSendingDiv = ((PmTabTtlStCustWork)resultList[0]).BlpSendDiv;
        //    // タブレットログ対応　--------------------------------->>>>>
        //    EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了 ConstantManagement.MethodResult.ctFNC_NORMAL");
        //    // タブレットログ対応　---------------------------------<<<<<
        //    return ConstantManagement.MethodResult.ctFNC_NORMAL;
        //}
        #endregion
        // DEL 吉岡 2013/08/09 Redmine#39820 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

        /// <summary>
        /// 得意先情報を取得
        /// </summary>
        /// <param name="psEnterpriseCode">企業コード</param>
        /// <param name="piCustomerCode">得意先コード</param>
        /// <param name="outCustomerInfo">得意先情報</param>
        /// <param name="errorMessage">エラーメッセージ</param>
        /// <returns>ステータス</returns>
        private ConstantManagement.MethodResult GetCustomerInfo(string psEnterpriseCode, int piCustomerCode, out CustomerInfo outCustomerInfo, out string errorMessage)
        {
            // タブレットログ対応　--------------------------------->>>>>
            const string methodName = "GetCustomerInfo";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 開始");
            // タブレットログ対応　---------------------------------<<<<<

            errorMessage = string.Empty;
            int status = this._customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, psEnterpriseCode, piCustomerCode, true, false, out outCustomerInfo);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // タブレットログ対応　--------------------------------->>>>>
                EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了 ConstantManagement.MethodResult.ctFNC_NORMAL");
                // タブレットログ対応　---------------------------------<<<<<
                return ConstantManagement.MethodResult.ctFNC_NORMAL;
            }
            else
            {
                errorMessage = "Not Found";
                // タブレットログ対応　--------------------------------->>>>>
                EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了 ConstantManagement.MethodResult.ctFNC_ERROR");
                // タブレットログ対応　---------------------------------<<<<<
                return ConstantManagement.MethodResult.ctFNC_ERROR;
            }
        }

        /// <summary>
        /// 売上・仕入制御オプションワークを取得
        /// </summary>
        /// <returns>売上・仕入制御オプションワーク</returns>
        private IOWriteCtrlOptWork GetIOWriteCtrlOpt()
        {
            // タブレットログ対応　--------------------------------->>>>>
            const string methodName = "GetIOWriteCtrlOpt";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 開始");
            // タブレットログ対応　---------------------------------<<<<<

            IOWriteCtrlOptWork ioWriteCtrlOpt = new IOWriteCtrlOptWork();
            {
                // 企業コード…共通ヘッダ リモート取得
                ioWriteCtrlOpt.EnterpriseCode = this._enterpriseCode; // ADD 2013/07/09 qijh Redmine#37586

                ioWriteCtrlOpt.CtrlStartingPoint = 0;   // 制御起点(0:売上/1:仕入/2:仕入売上同時計上)

                ioWriteCtrlOpt.AcpOdrrAddUpRemDiv = 0;  // 受注データ計上残区分(0:残す/1:残さない)
                ioWriteCtrlOpt.ShipmAddUpRemDiv = 0;    // 出荷データ計上残区分(0:残す/1:残さない)
                ioWriteCtrlOpt.EstimateAddUpRemDiv = 0; // 見積データ計上残区分(0:残す/1:残さない)

                ioWriteCtrlOpt.RetGoodsStockEtyDiv = 1; // 返品時在庫登録区分(0:する/1:しない)
                ioWriteCtrlOpt.RemainCntMngDiv = 0;     // 残数管理区分(0:する ※固定)

                ioWriteCtrlOpt.SupplierSlipDelDiv = 0;  // 仕入伝票削除区分(0:削除しない/1:削除する)
                ioWriteCtrlOpt.CarMngDivCd = 0;    // 車両管理マスタ登録区分(0:削除しない/1:削除する)
            }
            // タブレットログ対応　--------------------------------->>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了");
            // タブレットログ対応　---------------------------------<<<<<
            return ioWriteCtrlOpt;
        }

        /// <summary>
        /// ユーザーDBのPMTAB受注マスタ(車両)を取得
        /// </summary>
        /// <param name="psEnterpriseCode">企業コード</param>
        /// <param name="psSectionCode">拠点コード</param>
        /// <param name="psBusinessSessionId">業務セッションID</param>
        /// <param name="pmTabAcpOdrCar">PMTAB受注マスタ(車両)</param>
        /// <param name="errorMessage">エラーメッセージ</param>
        /// <returns>ステータス</returns>
        private ConstantManagement.MethodResult GetPmTabAcpOdrCar(string psEnterpriseCode, string psSectionCode, string psBusinessSessionId, 
            out PmTabAcpOdrCarWork pmTabAcpOdrCar, out string errorMessage)
        {
            // タブレットログ対応　--------------------------------->>>>>
            const string methodName = "GetPmTabAcpOdrCar";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 開始");
            // タブレットログ対応　---------------------------------<<<<<

            pmTabAcpOdrCar = null;
            errorMessage = string.Empty;

            // 検索用のパラメータ
            PmTabAcpOdrCarWork pmTabAcpOdrCarWork = new PmTabAcpOdrCarWork();
            pmTabAcpOdrCarWork.EnterpriseCode = psEnterpriseCode;
            pmTabAcpOdrCarWork.SearchSectionCode = psSectionCode;
            pmTabAcpOdrCarWork.BusinessSessionId = psBusinessSessionId;

            object refObj = pmTabAcpOdrCarWork;
            int status = this._iPmTabAcpOdrCarDB.Read(ref refObj, 0);
            pmTabAcpOdrCar = refObj as PmTabAcpOdrCarWork;

            if ((int)ConstantManagement.DB_Status.ctDB_NORMAL != status || null == pmTabAcpOdrCar)
            {
                errorMessage = "Not Found";
                // タブレットログ対応　--------------------------------->>>>>
                EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了 ConstantManagement.MethodResult.ctFNC_ERROR");
                // タブレットログ対応　---------------------------------<<<<<
                return ConstantManagement.MethodResult.ctFNC_ERROR;
            }

            // タブレットログ対応　--------------------------------->>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了 return ConstantManagement.MethodResult.ctFNC_NORMAL");
            // タブレットログ対応　---------------------------------<<<<<
            return ConstantManagement.MethodResult.ctFNC_NORMAL;
        }

        /// <summary>
        /// SCMDBのPMTAB売上情報を取得
        /// </summary>
        /// <param name="psEnterpriseCode">企業コード</param>
        /// <param name="psSectionCode">拠点コード</param>
        /// <param name="psBusinessSessionId">業務セッションID</param>
        /// <param name="pmTabSalesSlip">PMTAB売上データ</param>
        /// <param name="pmTabSaleDetailList">PMTAB売上明細データリスト</param>
        /// <param name="pmTabSalesDtCar">PMTAB売上データ（車両情報）</param>
        /// <param name="errorMessage">エラーメッセージ</param>
        /// <returns>ステータス</returns>
        private ConstantManagement.MethodResult GetPmTabSalesSlip(string psEnterpriseCode, string psSectionCode, string psBusinessSessionId,
            out PmTabSalesSlipWork pmTabSalesSlip, out List<PmTabSaleDetailWork> pmTabSaleDetailList, out PmTabSalesDtCarWork pmTabSalesDtCar, out string errorMessage)
        {
            // タブレットログ対応　--------------------------------->>>>>
            const string methodName = "GetPmTabSalesSlip";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 開始");
            // タブレットログ対応　---------------------------------<<<<<

            pmTabSalesSlip = null;
            pmTabSaleDetailList = null;
            pmTabSalesDtCar = null;
            errorMessage = string.Empty;

            // 検索用のパラメータ
            PmTabSalesSlipParaWork pmTabSalesSlipPara = new PmTabSalesSlipParaWork();
            pmTabSalesSlipPara.EnterpriseCode = psEnterpriseCode;
            pmTabSalesSlipPara.SearchSectionCode = psSectionCode;
            pmTabSalesSlipPara.BusinessSessionId = psBusinessSessionId;

            // SCMDBのPMTAB売上情報を取得
            object retObj;
            bool msgDiv;
            int status = this._iPmTabSalesSlipDB.Search(pmTabSalesSlipPara, out retObj, out msgDiv, out errorMessage);
            CustomSerializeArrayList retArrayList = retObj as CustomSerializeArrayList;

            if ((int)ConstantManagement.DB_Status.ctDB_NORMAL != status || null == retArrayList || 0 == retArrayList.Count)
            {
                errorMessage = "Not Found";
                // タブレットログ対応　--------------------------------->>>>>
                EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了 ConstantManagement.MethodResult.ctFNC_ERROR");
                // タブレットログ対応　---------------------------------<<<<<
                return ConstantManagement.MethodResult.ctFNC_ERROR;
            }

            foreach (object objItem in retArrayList)
            {
                // 取得した情報を戻すパラメータにセット
                if (objItem is PmTabSalesSlipWork)
                {
                    // PMTAB売上データ
                    pmTabSalesSlip = objItem as PmTabSalesSlipWork;
                }
                else if (objItem is PmTabSalesDtCarWork)
                {
                    // PMTAB売上データ(車両)
                    pmTabSalesDtCar = objItem as PmTabSalesDtCarWork;
                }
                else if (objItem is ArrayList)
                {
                    ArrayList tempList = objItem as ArrayList;
                    if (0 == tempList.Count) continue;

                    if (tempList[0] is PmTabSaleDetailWork)
                        // PMTAB売上明細データリスト
                        pmTabSaleDetailList = new List<PmTabSaleDetailWork>((PmTabSaleDetailWork[])tempList.ToArray(typeof(PmTabSaleDetailWork)));
                    else
                        continue;
                }
                else
                {
                    continue;
                }
            }

            // タブレットログ対応　--------------------------------->>>>>
            //if (null != pmTabSalesSlip && null != pmTabSaleDetailList && pmTabSaleDetailList.Count > 0)
            //    return ConstantManagement.MethodResult.ctFNC_NORMAL;
            if (null != pmTabSalesSlip && null != pmTabSaleDetailList && pmTabSaleDetailList.Count > 0)
            {
                EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了 ConstantManagement.MethodResult.ctFNC_NORMAL");
                return ConstantManagement.MethodResult.ctFNC_NORMAL;
            }
            // タブレットログ対応　---------------------------------<<<<<

            errorMessage = "Not Found";
            // タブレットログ対応　--------------------------------->>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了 ConstantManagement.MethodResult.ctFNC_ERROR");
            // タブレットログ対応　---------------------------------<<<<<
            return ConstantManagement.MethodResult.ctFNC_ERROR;
        }
        #endregion  ■ 情報取得処理

        #region ■ 伝票分割処理
        // --------------------- ADD 2013/07/03 qijh Redmine#37586 ------------------- >>>>>
        /// <summary>
        /// SCM情報取得
        /// </summary>
        /// <param name="salesSlip">売上データ</param>
        /// <param name="salesDetailList">売上明細リスト</param>
        /// <param name="carManagement">車両管理データ</param>
        /// <param name="pmTabSalesDtCar">PMTAB売上データ(車両)</param>
        /// <param name="pmTabAcpOdrCar">PMTAB受注マスタ（車両）</param>
        /// <param name="customerInfo">得意先情報</param>
        /// <param name="scmAcOdrDataWork">SCM受注データ</param>
        /// <param name="scmAcOdrDtlAsList">SCM受注明細データ（回答）</param>
        /// <param name="scmAcOdrDtCar">SCM受注データ（車両情報）</param>
        /// <param name="beforeSalesRowNum">変更前売上行番号</param>
        // UPD 2013/08/16 吉岡 Redmine#39979 ------------>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        //private void GetScmDataInfo(SalesSlip salesSlip, List<SalesDetail> salesDetailList, CarManagementWork carManagement, PmTabSalesDtCarWork pmTabSalesDtCar, PmTabAcpOdrCarWork pmTabAcpOdrCar,
        //    CustomerInfo customerInfo, out SCMAcOdrDataWork scmAcOdrDataWork, out List<SCMAcOdrDtlAsWork> scmAcOdrDtlAsList, out SCMAcOdrDtCarWork scmAcOdrDtCar)
        private void GetScmDataInfo(SalesSlip salesSlip, List<SalesDetail> salesDetailList, CarManagementWork carManagement, PmTabSalesDtCarWork pmTabSalesDtCar, PmTabAcpOdrCarWork pmTabAcpOdrCar,
            CustomerInfo customerInfo, out SCMAcOdrDataWork scmAcOdrDataWork, out List<SCMAcOdrDtlAsWork> scmAcOdrDtlAsList, out SCMAcOdrDtCarWork scmAcOdrDtCar
            ,List<int> beforeSalesRowNum
            )
        // UPD 2013/08/16 吉岡 Redmine#39979 ------------<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
        {
            const string methodName = "GetScmDataInfo";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 開始");

            // SCM受注データを作成
            scmAcOdrDataWork = GetUpdSCMAcOdrData(salesSlip, customerInfo);

            // SCM受注明細データ（回答）を作成
            scmAcOdrDtlAsList = new List<SCMAcOdrDtlAsWork>();
            for (int i = 0; i < salesDetailList.Count; i++)
            {
                SCMAcOdrDtlAsWork scmAcOdrDtlAsWork = GetUpdSCMAcOdrDtlAs(salesDetailList[i], customerInfo);
                // -------------- ADD 2013/07/25 wangl2 Redmine#39166 ----------- >>>>>
                scmAcOdrDtlAsWork.GoodsDivCd = (scmAcOdrDtlAsWork.RecyclePrtKindCode != 0) ? 2 : salesDetailList[i].GoodsKindCode;
                if (salesDetailList[i].SalesSlipCdDtl == (int)SalesSlipInputAcs.SalesSlipCdDtl.Discount)
                {
                    scmAcOdrDtlAsWork.GoodsDivCd = 99; // 値引き
                    scmAcOdrDtlAsWork.UnitPrice = (long)salesDetailList[i].SalesMoneyTaxExc;// 売上金額（税抜）
                }
                // -------------- ADD 2013/07/25 wangl2 Redmine#39166 ----------- <<<<<
                scmAcOdrDtlAsWork.InqRowNumber = (i + 1) * -1; // 問合せ行番号を仮採番(-1 -2 -3....)  // ADD 2013/07/08 qijh Redmine#37980
                scmAcOdrDtlAsWork.PmPrsntCount = GetPmPrsntCount(salesSlip, salesDetailList[i]); // PM現在庫数
                // ADD 2013/08/16 吉岡 Redmine#39979 ------------>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                // 回答純正商品番号
                // ADD 2013/08/30 吉岡 Redmine#39979 ------------>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                if (salesDetailList[i].GoodsSearchDivCd.Equals(1) && salesDetailList[i].GoodsMakerCd >= 1000)
                {
                    // 品番検索 かつ 優良メーカー(純正品番点付き検索の場合)
                    foreach (SCMAcOdrDtlAsWork wk in sCMAcOdrDtlAsWorkForAnsPureGoodsNo)
                    {
                        if (wk.SalesRowNo.Equals(beforeSalesRowNum[i]))
                        {
                            if (wk.AnsPureGoodsNo.Trim().Equals(string.Empty))
                            {
                                scmAcOdrDtlAsWork.AnsPureGoodsNo = scmAcOdrDtlAsWork.GoodsNo;
                            }
                            else
                            {
                                scmAcOdrDtlAsWork.AnsPureGoodsNo = wk.AnsPureGoodsNo;
                            }
                            scmAcOdrDtlAsWork.BLGoodsCode = wk.BLGoodsCode;
                            break;
                        }
                    }
                }
                else
                // ADD 2013/08/30 吉岡 Redmine#39979 ------------<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                if (salesDetailList[i].GoodsSearchDivCd.Equals(1))
                {
                    // 品番検索の場合
                    scmAcOdrDtlAsWork.AnsPureGoodsNo = salesDetailList[i].GoodsNo;
                }
                else if (salesDetailList[i].GoodsSearchDivCd.Equals(0))
                {
                    // BL検索の場合
                    foreach (SCMAcOdrDtlAsWork wk in sCMAcOdrDtlAsWorkForAnsPureGoodsNo)
                    {
                        if (wk.SalesRowNo.Equals(beforeSalesRowNum[i]))
                        {
                            if (wk.AnsPureGoodsNo.Trim().Equals(string.Empty))
                            {
                                scmAcOdrDtlAsWork.AnsPureGoodsNo = scmAcOdrDtlAsWork.GoodsNo;
                            }
                            else
                            {
                                scmAcOdrDtlAsWork.AnsPureGoodsNo = wk.AnsPureGoodsNo;
                            }
                            scmAcOdrDtlAsWork.BLGoodsCode = wk.BLGoodsCode;
                            break;
                        }
                    }
                }
                // ADD 2013/08/16 吉岡 Redmine#39979 ------------<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                scmAcOdrDtlAsList.Add(scmAcOdrDtlAsWork);
            }

            // SCM受注データ（車両情報）を作成
            scmAcOdrDtCar = GetUpdSCMAcOdrDtCar(carManagement, salesSlip, pmTabSalesDtCar, customerInfo, pmTabAcpOdrCar);

            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了");
        }

        /// <summary>
        /// 伝票分割
        /// </summary>
        /// <param name="paramSalesSlip">売上データ</param>
        /// <param name="paramSalesDetailList">売上明細リスト</param>
        /// <param name="paramCarManagement">車両管理データ</param>
        /// <param name="pmTabSalesDtCar">PMTAB売上データ(車両)</param>
        /// <param name="pmTabAcpOdrCar">PMTAB受注マスタ（車両）</param>
        /// <param name="customerInfo">得意先情報</param>
        /// <param name="pmtabSessionList">PMTABセッション管理データリスト</param>
        /// <returns>分割された登録用伝票リスト</returns>
        // ------ UPD 2017/03/30 陳艶丹 Redmine#49164 ---------------- >>>>
        //private CustomSerializeArrayList SplitSlipData(SalesSlip SplitSlipData, List<SalesDetail> paramSalesDetailList, CarManagementWork paramCarManagement, 
        //    PmTabSalesDtCarWork pmTabSalesDtCar, PmTabAcpOdrCarWork pmTabAcpOdrCar, CustomerInfo customerInfo)
        private CustomSerializeArrayList SplitSlipData(SalesSlip paramSalesSlip, List<SalesDetail> paramSalesDetailList, CarManagementWork paramCarManagement, 
            PmTabSalesDtCarWork pmTabSalesDtCar, PmTabAcpOdrCarWork pmTabAcpOdrCar, CustomerInfo customerInfo, ArrayList pmtabSessionList)
        // ----- UPD 2017/03/30 陳艶丹 Redmine#49164 ---------------- <<<<
        {
            const string methodName = "SplitSlipData";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 開始");

            // 登録用の伝票リスト
            CustomSerializeArrayList retList = new CustomSerializeArrayList();

            // 明細分割
            List<List<SalesDetail>> slipDetailList = SplitDetailData(paramSalesSlip, paramSalesDetailList);
            int slipDtlRegOrder = 0; // 分割された伝票の登録順を制御 // ADD 2013/07/09 qijh Redmine#37586

            // 伝票分割
            foreach (List<SalesDetail> detailList in slipDetailList)
            {
                // 伝票リスト
                CustomSerializeArrayList slipList = new CustomSerializeArrayList();
                retList.Add(slipList);

                // 売上データ
                SalesSlip updSalesSlip = paramSalesSlip.Clone();

                // 売上明細データを集計
                AddItUpSalesDetailData(updSalesSlip, detailList);

                // 明細集計の補正
                ReviseAddItUpSalesDetailData(updSalesSlip, detailList); // ADD 2013/07/24 qijh Redmine#39026

                // 売上明細リスト
                ArrayList updSalesDetailList = new ArrayList();
                // ADD 2013/08/16 吉岡 Redmine#39979 ------------>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                List<int> beforeSalesRowNo = new List<int>();
                // ADD 2013/08/16 吉岡 Redmine#39979 ------------<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                for (int i = 0; i < detailList.Count; i++)
                {
                    SalesDetail updSalesDetail = detailList[i];
                    // ADD 2013/08/16 吉岡 Redmine#39979 ------------>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                    // 修正前の売上行番号を保管
                    beforeSalesRowNo.Add(updSalesDetail.SalesRowNo);
                    // ADD 2013/08/16 吉岡 Redmine#39979 ------------<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                    updSalesDetail.SalesRowNo = i + 1;
                    updSalesDetailList.Add(CreateSalesDetailWork(updSalesDetail));
                }

                // 受注ステータスが売上 && 売掛区分が商品 の場合に設定
                if (updSalesSlip.AcptAnOdrStatus.Equals((int)AcptAnOdrStatus.Sales) && updSalesSlip.AccRecDivCd.Equals(0))
                {
                    // 入金データ
                    SearchDepsitMain depsitMain = null;                             // 入金データオブジェクト
                    SearchDepositAlw depositAlw = null;                             // 入金引当データオブジェクト
                    this.GetCurrentDepsitMain(ref updSalesSlip, out depsitMain, out depositAlw);

                    if (updSalesSlip.AccRecDivCd == 0)
                    {
                        slipList.Add(ParamDataFromUIData(depsitMain)); // 入金データ追加
                        slipList.Add((DepositAlwWork)DBAndXMLDataMergeParts.CopyPropertyInClass(depositAlw, typeof(DepositAlwWork)));
                    }
                }

                slipList.Add(CreateSalesSlipWork(updSalesSlip)); // 売上データ
                slipList.Add(updSalesDetailList); // 売上明細リスト

                // 車両管理データ
                ArrayList updCarManagementList = new ArrayList();
                slipList.Add(updCarManagementList);
                updCarManagementList.Add(paramCarManagement);
                
                // リモート参照用明細パラメータ
                //slipList.Add(GetSlipDetailAddInfoWorkList(updSalesDetailList, paramCarManagement)); // DEL 2013/07/09 qijh Redmine#37586
                slipList.Add(GetSlipDetailAddInfoWorkList(updSalesDetailList, paramCarManagement, ref slipDtlRegOrder)); // ADD 2013/07/09 qijh Redmine#37586

                // SCMデータ取得
                if (this._isConnScm)
                {
                    // SCM連携
                    SCMAcOdrDataWork scmAcOdrDataWork;
                    List<SCMAcOdrDtlAsWork> scmAcOdrDtlAsList;
                    SCMAcOdrDtCarWork scmAcOdrDtCar;
                    // UPD 2013/08/16 吉岡 Redmine#39979 ------------>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                    // GetScmDataInfo(updSalesSlip, detailList, paramCarManagement, pmTabSalesDtCar, pmTabAcpOdrCar, customerInfo,
                    //    out  scmAcOdrDataWork, out scmAcOdrDtlAsList, out scmAcOdrDtCar);
                    GetScmDataInfo(updSalesSlip, detailList, paramCarManagement, pmTabSalesDtCar, pmTabAcpOdrCar, customerInfo,
                        out  scmAcOdrDataWork, out scmAcOdrDtlAsList, out scmAcOdrDtCar, beforeSalesRowNo);
                    // UPD 2013/08/16 吉岡 Redmine#39979 ------------<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

                    // SCM受注データ
                    slipList.Add(scmAcOdrDataWork);

                    // SCM受注明細データ(回答)
                    ArrayList updScmAcOdrDtlAsList = new ArrayList();
                    updScmAcOdrDtlAsList.AddRange(scmAcOdrDtlAsList);
                    slipList.Add(updScmAcOdrDtlAsList);
                    
                    // SCM受注データ(車両情報)
                    slipList.Add(scmAcOdrDtCar);
                }
                // PMTABセッション管理情報追加
                slipList.Add(pmtabSessionList);// ADD 2017/03/30 陳艶丹 Redmine#49164
            }

            // 制御オプションワーク
            retList.Add(GetIOWriteCtrlOpt());

            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了");
            return retList;
        }

        /// <summary>
        /// 売上明細を分割
        /// </summary>
        /// <param name="updSalesSlip">売上データ</param>
        /// <param name="updSalesDetailList">売上明細リスト</param>
        /// <returns>分割された売上明細リスト</returns>
        private List<List<SalesDetail>> SplitDetailData(SalesSlip updSalesSlip, List<SalesDetail> updSalesDetailList)
        {
            const string methodName = "SplitDetailData";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 開始");

            int maxRowCount = GetMaxRowCount(updSalesSlip); // 明細最大行数

            // UPD 2013/08/14 吉岡 Redmine#39942 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            // IList<SalesDetail> sortedSalesDetailList = SortedSalesDetailListFactory.CreateSortedSalesDetailList(updSalesSlip, updSalesDetailList); // ソート済み売上明細データリスト
            IList<SalesDetail> sortedSalesDetailList = CreateSortedSalesDetailList(updSalesSlip, updSalesDetailList); // ソート済み売上明細データリスト
            // UPD 2013/08/14 吉岡 Redmine#39942 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

            List<List<SalesDetail>> retList = new List<List<SalesDetail>>();
            List<SalesDetail> detailList = null;
            // UPD 2013/08/14 吉岡 Redmine#39942 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            #region 旧ソース
            //for (int i = 0; i < sortedSalesDetailList.Count; i++)
            //{
            //    if (i % maxRowCount == 0)
            //    {
            //        detailList = new List<SalesDetail>();
            //        retList.Add(detailList);
            //    }
            //    detailList.Add(sortedSalesDetailList[i]);
            //}
            #endregion
            SlipKey slipKey = new SlipKey();
            SlipKey saveSlipKey = new SlipKey();
            // ループ開始前初期値設定
            if (sortedSalesDetailList != null && sortedSalesDetailList.Count > 0)
            {
                saveSlipKey = MakeSlipKey(sortedSalesDetailList[0].SalesOrderDivCd, sortedSalesDetailList[0].WarehouseCode);
            }
            int rowCount = 0;
            detailList = new List<SalesDetail>();
            retList.Add(detailList);

            foreach (SalesDetail row in sortedSalesDetailList)
            {
                rowCount++;

                // 今回ブレイクキー取得
                slipKey = MakeSlipKey(row.SalesOrderDivCd, row.WarehouseCode);

                // 最大行 または 売上全体設定．伝票作成方法に沿ったキーブレイク
                if (rowCount > maxRowCount || !slipKey.Equals(saveSlipKey))
                {
                    // UPD 2013/09/11 吉岡  --------->>>>>>>>>>>>>>>>>>>>>>>>>
                    // rowCount = 0;
                    rowCount = 1;
                    // UPD 2013/09/11 吉岡  ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                    saveSlipKey = new SlipKey();
                    detailList = new List<SalesDetail>();
                    retList.Add(detailList);
                }

                detailList.Add(row);
                saveSlipKey = slipKey;
            }
            // UPD 2013/08/14 吉岡 Redmine#39942 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了");
            return retList;
        }

        // ADD 2013/08/14 吉岡 Redmine#39942 --------->>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// 売上データ作成ブレイクキー構造体
        /// </summary>
        internal struct SlipKey
        {
            /// <summary> 在庫・取寄区分 </summary>
            int _salesOrderDivCd;
            /// <summary> 倉庫コード </summary>
            string _warehouseCode;
            /// <summary>
            /// コンストラクタ
            /// </summary>
            /// <param name="salesOrderDivCd">在庫・取寄区分</param>
            /// <param name="warehouseCode">倉庫コード</param>
            internal SlipKey(int salesOrderDivCd, string warehouseCode)
            {
                this._salesOrderDivCd = salesOrderDivCd;
                this._warehouseCode = warehouseCode;
            }
            /// <summary>
            /// 在庫・取寄区分
            /// </summary>
            internal int SalesOrderDivCd
            {
                get { return this._salesOrderDivCd; }
                set { this._salesOrderDivCd = value; }
            }
            /// <summary>
            /// 倉庫コード
            /// </summary>
            internal string WarehouseCode
            {
                get { return this._warehouseCode; }
                set { this._warehouseCode = value; }
            }
        }

        /// <summary>
        /// データ作成ブレイクキー作成処理
        /// </summary>
        /// <param name="salesOrderDivCd"></param>
        /// <param name="warehouseCode"></param>
        /// <returns></returns>
        private SlipKey MakeSlipKey(int salesOrderDivCd, string warehouseCode)
        {
            SlipKey slipKey = new SlipKey();
            switch (this.SalesTtlSt.SlipCreateProcess)
            {
                case 0:
                    // 入力順(行番号順)
                    slipKey = new SlipKey();
                    break;
                case 1:
                    // 在庫・取寄順(在庫取寄区分(0:取寄 1:在庫)・行番号順)
                    slipKey = new SlipKey(salesOrderDivCd, string.Empty);
                    break;
                case 2:
                    // 倉庫順(倉庫・行番号順)
                    slipKey = new SlipKey(0, warehouseCode);
                    break;
                case 3:
                    // 出力先別(倉庫・行番号順)
                    slipKey = new SlipKey(0, warehouseCode);
                    break;
            }
            return slipKey;
        }
        // ADD 2013/08/14 吉岡 Redmine#39942 ---------<<<<<<<<<<<<<<<<<<<<<<<<<



        /// <summary>
        /// 売上明細データを集計
        /// </summary>
        /// <param name="salesSlip">売上データ</param>
        /// <param name="salesDetailList">売上明細リスト</param>
        /// <remarks>PMSCM01012AのAddItUpSalesDetailDataより移植</remarks>
        private void AddItUpSalesDetailData(SalesSlip salesSlip, List<SalesDetail> salesDetailList)
        {
            const string methodName = "AddItUpSalesDetailData";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 開始");

            SalesSlip SalesSlipData = salesSlip;
            List<SalesDetail> SalesDetailDataList = salesDetailList;

            SalesSlipData.DetailRowCount = SalesDetailDataList.Count;   // 109.明細行数

            OtherAppComponent otherComponent = new OtherAppComponent(
                SalesSlipData.EnterpriseCode,
                SalesSlipData.SectionCode
            );
            int salesTaxFrcProcCd = this._customerInfoAcs.GetSalesFractionProcCd(this._enterpriseCode, salesSlip.CustomerCode, CustomerInfoAcs.FracProcMoneyDiv.CnsTaxFrcProcCd);		// 消費税端数処理コード // ADD  2013/07/24 wangl2 FOR Redmine#39027
            #region <戻り値の宣言>

            // --- DEL 2013/08/09 吉岡 Redmine#39780 戻し ---------->>>>>
            #region 旧ソース
            //// ADD 吉岡 2013/08/08 Redmine#39780 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            //int taxFracProcCd;          // 端数処理区部 
            //// ADD 吉岡 2013/08/08 Redmine#39780 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
            #endregion
            // --- DEL 2013/08/09 吉岡 Redmine#39780 戻し ----------<<<<<

            long salesTotalTaxInc;      // 売上伝票合計（税込）
            long salesTotalTaxExc;      // 売上伝票合計（税抜）
            long salesSubtotalTax;      // 売上小計（税）
            long itdedSalesOutTax;      // 売上外税対象額
            long itdedSalesInTax;       // 売上内税対象額
            long salSubttlSubToTaxFre;  // 売上小計非課税対象額
            long salesOutTax;           // 売上金額消費税額（外税）
            long salAmntConsTaxInclu;   // 売上金額消費税額（内税）
            long salesDisTtlTaxExc;     // 売上値引金額計（税抜）
            long itdedSalesDisOutTax;   // 売上値引外税対象額合計
            long itdedSalesDisInTax;    // 売上値引内税対象額合計
            long itdedSalesDisTaxFre;   // 売上値引非課税対象額合計
            long salesDisOutTax;        // 売上値引消費税額（外税）
            long salesDisTtlTaxInclu;   // 売上値引消費税額（内税）
            long totalCost;             // 原価金額計

            long stockGoodsTtlTaxExc;   // 在庫商品合計金額(税抜)   …売上データに無い？
            long pureGoodsTtlTaxExc;    // 純正商品合計金額(税抜)   …売上データに無い？
            long balanceAdjust;         // 消費税調整額             …売上データに無い？
            long taxAdjust;             // 残高調整額               …売上データに無い？

            long salesPrtSubttlInc;     // 売上部品小計（税込）
            long salesPrtSubttlExc;     // 売上部品小計（税抜）
            long salesWorkSubttlInc;    // 売上作業小計（税込）
            long salesWorkSubttlExc;    // 売上作業小計（税抜）
            long itdedPartsDisInTax;    // 部品値引対象額合計（税込）
            long itdedPartsDisOutTax;   // 部品値引対象額合計（税抜）
            long itdedWorkDisInTax;     // 作業値引対象額合計（税込）
            long itdedWorkDisOutTax;    // 作業値引対象額合計（税抜）

            long totalMoneyForGrossProfit;  // 粗利計算用売上金額   …売上データに無い？

            #endregion // </戻り値の宣言>

            #region <呼出し>

            otherComponent.CalculationSalesTotalPrice(
                SalesDetailDataList, // 売上明細データリスト
                SalesSlipData.ConsTaxRate,              // 消費税税率
                //SalesSlipData.FractionProcCd,           // 消費税端数処理コード// DEL  2013/07/24 wangl2 FOR Redmine#39027
                salesTaxFrcProcCd,                         // 消費税端数処理コード// ADD  2013/07/24 wangl2 FOR Redmine#39027
                SalesSlipData.TotalAmountDispWayCd,     // 総額表示方法区分
                SalesSlipData.ConsTaxLayMethod,         // 消費税転嫁方式

                // --- DEL 2013/08/09 吉岡 Redmine#39780 戻し ---------->>>>>
                #region 旧ソース
                //// ADD 吉岡 2013/08/08 Redmine#39780 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                //this._enterpriseCode,
                //this._customerInfo.CustomerCode,

                //out taxFracProcCd,          // 端数処理区分 （出力値は未使用）
                //// ADD 吉岡 2013/08/08 Redmine#39780 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                #endregion
                // --- DEL 2013/08/09 吉岡 Redmine#39780 戻し ----------<<<<<

                out salesTotalTaxInc,       // 売上伝票合計（税込）
                out salesTotalTaxExc,       // 売上伝票合計（税抜）
                out salesSubtotalTax,       // 売上小計（税）
                out itdedSalesOutTax,       // 売上外税対象額
                out itdedSalesInTax,        // 売上内税対象額
                out salSubttlSubToTaxFre,   // 売上小計非課税対象額
                out salesOutTax,            // 売上金額消費税額（外税）
                out salAmntConsTaxInclu,    // 売上金額消費税額（内税）
                out salesDisTtlTaxExc,      // 売上値引金額計（税抜）
                out itdedSalesDisOutTax,    // 売上値引外税対象額合計
                out itdedSalesDisInTax,     // 売上値引内税対象額合計
                out itdedSalesDisTaxFre,    // 売上値引非課税対象額合計
                out salesDisOutTax,         // 売上値引消費税額（外税）
                out salesDisTtlTaxInclu,    // 売上値引消費税額（内税）
                out totalCost,              // 原価金額計

                out stockGoodsTtlTaxExc,    // 在庫商品合計金額(税抜)   …売上データに無い？
                out pureGoodsTtlTaxExc,     // 純正商品合計金額(税抜)   …売上データに無い？
                out balanceAdjust,          // 消費税調整額             …売上データに無い？
                out taxAdjust,              // 残高調整額               …売上データに無い？

                out salesPrtSubttlInc,      // 売上部品小計（税込）
                out salesPrtSubttlExc,      // 売上部品小計（税抜）
                out salesWorkSubttlInc,     // 売上作業小計（税込）
                out salesWorkSubttlExc,     // 売上作業小計（税抜）
                out itdedPartsDisInTax,     // 部品値引対象額合計（税込）
                out itdedPartsDisOutTax,    // 部品値引対象額合計（税抜）
                out itdedWorkDisInTax,      // 作業値引対象額合計（税込）
                out itdedWorkDisOutTax,     // 作業値引対象額合計（税抜）

                out totalMoneyForGrossProfit    // 粗利計算用売上金額   …売上データに無い？
            );

            #endregion // </呼出し>

            #region <戻り値を代入>
            // -----DEL 2013/07/18 Redmine#38198 消費税転嫁方式が非課税の場合、合計金額が「0」の対応----->>>>>
            //SalesSlipData.SalesTotalTaxInc = salesTotalTaxInc;          // 040.売上伝票合計（税込）
            //SalesSlipData.SalesTotalTaxExc = salesTotalTaxExc;          // 041.売上伝票合計（税抜）
            // -----DEL 2013/07/18  Redmine#38198 消費税転嫁方式が非課税の場合、合計金額が「0」の対応-----<<<<<
            // -----ADD 2013/07/18  Redmine#38198 消費税転嫁方式が非課税の場合、合計金額が「0」の対応----->>>>>
            SalesSlipData.SalesTotalTaxInc = salesTotalTaxInc + salSubttlSubToTaxFre;          // 040.売上伝票合計（税込）
            SalesSlipData.SalesTotalTaxExc = salesTotalTaxExc + salSubttlSubToTaxFre;          // 041.売上伝票合計（税抜）
            // -----ADD 2013/07/18  Redmine#38198 消費税転嫁方式が非課税の場合、合計金額が「0」の対応-----<<<<<
            SalesSlipData.SalesSubtotalTax = salesSubtotalTax;          // 046.売上小計（税）
            SalesSlipData.ItdedSalesOutTax = itdedSalesOutTax;          // 054.売上外税対象額
            SalesSlipData.ItdedSalesInTax = itdedSalesInTax;            // 055.売上内税対象額
            SalesSlipData.SalSubttlSubToTaxFre = salSubttlSubToTaxFre;  // 056.売上小計非課税対象額
            SalesSlipData.SalesOutTax = salesOutTax;                    // 057.売上金額消費税額（外税）
            SalesSlipData.SalAmntConsTaxInclu = salAmntConsTaxInclu;    // 058.売上金額消費税額（内税）
            SalesSlipData.SalesDisTtlTaxExc = salesDisTtlTaxExc;        // 059.売上値引金額計（税抜）
            SalesSlipData.ItdedSalesDisOutTax = itdedSalesDisOutTax;    // 060.売上値引外税対象額合計
            SalesSlipData.ItdedSalesDisInTax = itdedSalesDisInTax;      // 061.売上値引内税対象額合計
            SalesSlipData.ItdedSalesDisTaxFre = itdedSalesDisTaxFre;    // 066.売上値引非課税対象額合計
            SalesSlipData.SalesDisOutTax = salesDisOutTax;              // 067.売上値引消費税額（外税）
            SalesSlipData.SalesDisTtlTaxInclu = salesDisTtlTaxInclu;    // 068.売上値引消費税額（内税）
            SalesSlipData.TotalCost = totalCost;                        // 071.原価金額計
            SalesSlipData.SalesPrtSubttlInc = salesPrtSubttlInc;        // 048.売上部品小計（税込）
            SalesSlipData.SalesPrtSubttlExc = salesPrtSubttlExc;        // 049.売上部品小計（税抜）
            SalesSlipData.SalesWorkSubttlInc = salesWorkSubttlInc;      // 050.売上作業小計（税込）
            SalesSlipData.SalesWorkSubttlExc = salesWorkSubttlExc;      // 051.売上作業小計（税抜）
            SalesSlipData.ItdedPartsDisInTax = itdedPartsDisInTax;      // 063.部品値引対象額合計（税込）
            SalesSlipData.ItdedPartsDisOutTax = itdedPartsDisOutTax;    // 062.部品値引対象額合計（税抜）
            SalesSlipData.ItdedWorkDisInTax = itdedWorkDisInTax;        // 065.作業値引対象額合計（税込）
            SalesSlipData.ItdedWorkDisOutTax = itdedWorkDisOutTax;      // 064.作業値引対象額合計（税抜）

            #endregion // </戻り値を代入>

            // 042.売上部品合計(税込み)…売上部品小計(税込み) + 部品値引対象額合計(税込み)
            //SalesSlipData.SalesPrtTotalTaxInc = SCMSlipDataFactory.GetSalesPrtTotalTaxInc(SalesSlipData);//DEL 鄭慕鈞 2013/07/23 Redmine#39024 行値引きの売上部品合計（税込） 売上部品合計（税抜き）の設定
            SalesSlipData.SalesPrtTotalTaxInc = SalesSlipData.SalesPrtTotalTaxInc; //ADD 鄭慕鈞 2013/07/23 Redmine#39024 行値引きの売上部品合計（税込） 売上部品合計（税抜き）の設定
            // 043.売上部品合計(税抜き)…売上部品小計(税抜き) + 部品値引対象額合計(税抜き)
            //SalesSlipData.SalesPrtTotalTaxExc = SCMSlipDataFactory.GetSalesPrtTotalTaxExc(SalesSlipData);//DEL 鄭慕鈞 2013/07/23 Redmine#39024 行値引きの売上部品合計（税込） 売上部品合計（税抜き）の設定
            SalesSlipData.SalesPrtTotalTaxExc = SalesSlipData.SalesPrtTotalTaxExc;//ADD 鄭慕鈞 2013/07/23 Redmine#39024 行値引きの売上部品合計（税込） 売上部品合計（税抜き）の設定
            // 044.売上作業合計(税込み)…売上作業小計(税込み) + 作業値引対象額合計(税込み)
            SalesSlipData.SalesWorkTotalTaxInc = SCMSlipDataFactory.GetSalesWorkTotalTaxInc(SalesSlipData);
            // 045.売上作業合計(税抜き)…売上作業小計(税抜き) + 作業値引対象額合計(税抜き)
            SalesSlipData.SalesWorkTotalTaxExc = SCMSlipDataFactory.GetSalesWorkTotalTaxExc(SalesSlipData);

            // 046.売上小計(税込み)…値引き後の明細金額の合計(非課税含まず)
            // ∴売上伝票合計(税込み) - 売上小計非課税対象額 + 売上値引非課税対象額合計
            SalesSlipData.SalesSubtotalTaxInc = SCMSlipDataFactory.GetSalesSubtotalTaxInc(SalesSlipData);
            // 047.売上小計(税抜き)…値引き後の明細金額の合計(非課税含まず)
            // ∴売上伝票合計(税抜き) - 売上小計非課税対象額 + 売上値引非課税対象額合計
            SalesSlipData.SalesSubtotalTaxExc = SCMSlipDataFactory.GetSalesSubtotalTaxExc(SalesSlipData);

            // 052.売上正価金額…売上伝票合計(税抜き) - 売上値引金額計(税抜き)
            SalesSlipData.SalesNetPrice = SCMSlipDataFactory.GetSalesNetPrice(SalesSlipData);

            // 069.部品値引率…小計に対しての部品値引率
            // ∴部品値引対象額合計(税込み) / 売上部品小計(税込み)
            //SalesSlipData.PartsDiscountRate = SCMSlipDataFactory.GetPartsDiscountRate(SalesSlipData);//DEL  2013/07/24 wangl2 FOR Redmine#39028
            // --------------- ADD START 2013/07/24 wangl2 FOR Redmine#39028------>>>>
            double rate;
            this.GetRate(itdedPartsDisOutTax, salesPrtSubttlExc, out rate);
            salesSlip.PartsDiscountRate = rate;                                                     // 部品値引率
            // --------------- ADD END 2013/07/24 wangl2 FOR Redmine#39028--------<<<<
            // UNDONE:070.工賃値引率…小計に対しての工賃値引率
            // ∴作業値引対象額合計(税込み) / 売上作業小計(税込み)
            SalesSlipData.RavorDiscountRate = SCMSlipDataFactory.GetRavorDiscountRate(SalesSlipData);

            // UNDONE:075.売掛消費税…算出

            // 079.入金引当残高…売上伝票合計(税込) 消費税転嫁方式が「請求転嫁、非課税」の場合は税抜金額
            SalesSlipData.DepositAlwcBlnce = SCMSlipDataFactory.GetConsTaxLayMethod(SalesSlipData);

            // 128.在庫商品合計金額(税抜)…算出
            SalesSlipData.StockGoodsTtlTaxExc = SCMSlipDataFactory.GetStockGoodsTtlTaxExc(SalesDetailDataList);
            // 129.在庫商品合計金額(税込)…算出
            SalesSlipData.PureGoodsTtlTaxExc = SCMSlipDataFactory.GetPureGoodsTtlTaxExc(SalesDetailDataList);

            SalesSlipData.AccRecConsTax = salesSubtotalTax;

            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了");
        }

        // ------------- ADD 2013/07/24 qijh Redmine#39026 ---------- >>>>>
        /// <summary>
        /// 売上明細集計の補正処理
        /// </summary>
        /// <param name="salesSlip">売上データ</param>
        /// <param name="salesDetailList">売上明細リスト</param>
        private void ReviseAddItUpSalesDetailData(SalesSlip salesSlip, List<SalesDetail> salesDetailList)
        {
            long salesPrtSubttlInc = 0;     // 売上部品小計（税込）
            long salesPrtSubttlExc = 0;     // 売上部品小計（税抜）
            // 消費税端数処理単位、端数処理区分を取得
            int taxFracProcCd = 0;
            double taxFracProcUnit = 0;
            int salesTaxFrcProcCd = this._customerInfoAcs.GetSalesFractionProcCd(this._enterpriseCode, salesSlip.CustomerCode, CustomerInfoAcs.FracProcMoneyDiv.CnsTaxFrcProcCd);		// 消費税端数処理コード // ADD  2013/07/24 wangl2 FOR Redmine#39027
            this.GetSalesFractionProcInfo(SalesSlipInputInitDataAcs.ctFracProcMoneyDiv_Tax, salesTaxFrcProcCd, 0, out taxFracProcUnit, out taxFracProcCd);
            foreach (SalesDetail salesDetail in salesDetailList)
            {
                // 売上部品小計集計
                if (salesDetail.SalesSlipCdDtl == (int)SalesSlipInputAcs.SalesSlipCdDtl.Sales || salesDetail.SalesSlipCdDtl == (int)SalesSlipInputAcs.SalesSlipCdDtl.RetGoods)
                {
                    salesPrtSubttlInc += salesDetail.SalesMoneyTaxInc; // 売上部品小計（税込）
                    salesPrtSubttlExc += salesDetail.SalesMoneyTaxExc; // 売上部品小計（税抜）
                }
            }

            switch ((SalesGoodsCd)salesSlip.SalesGoodsCd)
            {
                case SalesGoodsCd.ConsTaxAdjust:
                case SalesGoodsCd.AccRecConsTaxAdjust:
                    {
                        salesSlip.SalesPrtSubttlInc = 0;  // 売上部品小計（税込）
                        break;
                    }
                case SalesGoodsCd.BalanceAdjust:
                case SalesGoodsCd.AccRecBalanceAdjust:
                    {
                        salesSlip.SalesPrtSubttlInc = 0;  // 売上部品小計（税込）
                        break;
                    }
                case SalesGoodsCd.Goods:
                    {
                        // 明細転嫁以外
                        if (salesSlip.ConsTaxLayMethod != (int)ConsTaxLayMethod.DetailLay)
                            // 売上部品小計（税込）：売上部品小計（税抜） × 税率
                            salesPrtSubttlInc = salesPrtSubttlExc + CalculateTax.GetTaxFromPriceExc(salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, salesPrtSubttlExc);

                        salesSlip.SalesPrtSubttlInc = salesPrtSubttlInc;   // 売上部品小計（税込）
                        break;
                    }
            }
        }
        // ------------- ADD 2013/07/24 qijh Redmine#39026 ---------- <<<<<

        /// <summary>
        /// 伝票印刷設定マスタを取得
        /// </summary>
        private static SlipPrtSetAgent SlipPrtSetDB
        {
            get { return SlipPrtSetServer.Singleton.Instance; }
        }

        /// <summary>
        /// 明細最大行数を取得
        /// </summary>
        /// <param name="salesSlip">売上データ</param>
        /// <returns>明細最大行数</returns>
        /// <remarks>
        /// PMSCM01012AのGetMaxRowCountより移植
        /// </remarks>
        private int GetMaxRowCount(SalesSlip salesSlip)
        {
            const string methodName = "GetMaxRowCount";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 開始");

            int maxRowCount = SCMSalesListEssence.DEFAULT_MAX_ROW_COUNT;
            {
                SlipPrtSet slipPrtSet = null;
                switch ((AcptAnOdrStatus)salesSlip.AcptAnOdrStatus)
                {
                    case AcptAnOdrStatus.Estimate:  // 見積
                        slipPrtSet = SlipPrtSetDB.GetPrtSlipSet(SlipTypeController.SlipKind.EstimateSlip, salesSlip);
                        break;
                    case AcptAnOdrStatus.Order:     // 受注
                        slipPrtSet = SlipPrtSetDB.GetPrtSlipSet(SlipTypeController.SlipKind.AcceptSlip, salesSlip);
                        break;
                    case AcptAnOdrStatus.Sales:     // 売上
                        slipPrtSet = SlipPrtSetDB.GetPrtSlipSet(SlipTypeController.SlipKind.SalesSlip, salesSlip);
                        break;
                }
                if ((slipPrtSet != null) && (slipPrtSet.DetailRowCount > 0)) maxRowCount = slipPrtSet.DetailRowCount;
            }

            EasyLogger.Write(CLASS_NAME, methodName, "伝票分割 明細最大行数 = " + maxRowCount);
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了");
            return maxRowCount;
        }
        // --------------------- ADD 2013/07/03 qijh Redmine#37586 ------------------- <<<<<
        // --------------- ADD START 2013/07/24 wangl2 FOR Redmine#39028------>>>>
        /// <summary>
        /// 率算定処理
        /// </summary>
        /// <param name="numerator">数値(分子)</param>
        /// <param name="denominator">数値(分母)</param>
        /// <param name="rate">率</param>
        public void GetRate(double numerator, double denominator, out double rate)
        {
            if (this._salesPriceCalculate == null)
                this._salesPriceCalculate = new SalesPriceCalculate();
            rate = this._salesPriceCalculate.CalculateMarginRate(numerator, denominator);
        }
        // --------------- ADD END 2013/07/24 wangl2 FOR Redmine#39028--------<<<<
        #endregion  ■ 伝票分割処理

        #region ■ データ登録
        /// <summary>
        /// 売上情報とSCM回答をUSERDBに登録
        /// </summary>
        /// <param name="paramSalesScmCustList">売上、SCM回答情報リスト</param>
        /// <param name="errorMessage">エラーメッセージ</param>
        /// <param name="sameSessionIdFlg">同一セッションIDフラグ</param>
        /// <returns>ステータス</returns>
        // --------------------- ADD 2017/03/30 陳艶丹 Redmine#49164 ---------------- >>>>
        //private ConstantManagement.MethodResult Write(ref CustomSerializeArrayList paramSalesScmCustList, out string errorMessage)
        private ConstantManagement.MethodResult Write(ref CustomSerializeArrayList paramSalesScmCustList, out bool sameSessionIdFlg, out string errorMessage)
        // --------------------- ADD 2017/03/30 陳艶丹 Redmine#49164 ---------------- <<<<<
        {
            // タブレットログ対応　--------------------------------->>>>>
            const string methodName = "Write";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 開始");
            // タブレットログ対応　---------------------------------<<<<<

            // 登録リモート用のパラメータを構成
            // DEL 2013/07/03 qijh Redmine#37586 ------------------- >>>>>
            //CustomSerializeArrayList custTopArrayList = new CustomSerializeArrayList();
            //custTopArrayList.Add(paramSalesScmCustList);
            //custTopArrayList.Add(GetIOWriteCtrlOpt());

            //object paraList = custTopArrayList;
            // DEL 2013/07/03 qijh Redmine#37586 ------------------- <<<<<

            object paraList = paramSalesScmCustList; // ADD 2013/07/03 qijh Redmine#37586
            string itemInfo = string.Empty;
            sameSessionIdFlg = false;

            int status = this._iIOWriteControlDB.Write(ref paraList, out errorMessage, out itemInfo);
            // タブレットログ対応　--------------------------------->>>>>
            //if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            //    return ConstantManagement.MethodResult.ctFNC_ERROR;

            // --------------------- ADD 2017/03/30 陳艶丹 Redmine#49164 ---------------- >>>>
            string acptAnOdrStatusName = string.Empty;

            if (errorMessage.Contains("同一セッションIDが存在します。"))
            {
                sameSessionIdFlg = true;
                ArrayList pmTabletWorkList = new ArrayList(); // PMTABセッション管理データリスト

                DivisionCustomSerializeArrayListForTabWrite(paraList as CustomSerializeArrayList, out pmTabletWorkList);

                foreach (PmTabSessionMngWork pmTabSessionMngWork in pmTabletWorkList)
                {
                    EasyLogger.Write(CLASS_NAME, methodName, "同一セッションIDが存在しました。"
                       + "　企業コード：" + pmTabSessionMngWork.EnterpriseCode
                       + "　セッションＩＤ：" + pmTabSessionMngWork.BusinessSessionId
                       + "　伝票番号：" + pmTabSessionMngWork.SalesSlipNum
                       + "　受注ステータス：" + pmTabSessionMngWork.AcptAnOdrStatus
                        );
                    if (pmTabSessionMngWork.AcptAnOdrStatus == (int)AcptAnOdrStatusState.Sales)
                        acptAnOdrStatusName = "売上";
                    else
                        acptAnOdrStatusName = "受注";
                    MyOpeCtrl.Logger.WriteOperationLog(
                                            "",
                                            1,
                                            0,
                                            string.Format("{0}伝票、売上伝票番号:{1}、同一セッションの伝票が既に存在する為、登録処理を終了しました。", acptAnOdrStatusName, pmTabSessionMngWork.SalesSlipNum));
                }

                EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了　ConstantManagement.MethodResult.ctFNC_NORMAL");
                return ConstantManagement.MethodResult.ctFNC_NORMAL;
            }
            // --------------------- ADD 2017/03/30 陳艶丹 Redmine#49164 ---------------- <<<<<

            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了 ConstantManagement.MethodResult.ctFNC_ERROR " + errorMessage);
                return ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            // タブレットログ対応　---------------------------------<<<<<

            paramSalesScmCustList = paraList as CustomSerializeArrayList;

            // タブレットログ対応　--------------------------------->>>>>
            ArrayList salesDataList = new ArrayList(); // 売上データ(伝票リスト情報)
            // ADD 2013/08/09 Redmine#39649 ----------------------------------------->>>>>
            //string acptAnOdrStatusName = string.Empty; // DEL 2017/03/30 陳艶丹 Redmine#49164
            acptAnOdrStatusName = string.Empty;   // ADD 2017/03/30 陳艶丹 Redmine#49164
            // ADD 2013/08/09 Redmine#39649 -----------------------------------------<<<<<
            DivisionCustomSerializeArrayListForWritingProc(paramSalesScmCustList, out salesDataList);
            foreach (SalesSlipWork salesData in salesDataList)
            {
                EasyLogger.Write(CLASS_NAME, methodName, "伝票を登録しました" 
                   + "　企業コード：" + salesData.EnterpriseCode
                   + "　拠点コード：" + salesData.SectionCode
                   + "　伝票番号：" + salesData.SalesSlipNum
                   + "　受注ステータス：" + salesData.AcptAnOdrStatus
                    );
                // ADD 2013/08/08 Redmine#39649 ----------------------------------------->>>>>
                // UPD 2013/08/09 Redmine#39649 ----------------------------------------->>>>>
                //MyOpeCtrl.Logger.WriteOperationLog(
                //                        "",
                //                        1,
                //                        0,
                //                        string.Format("売上伝票、売上伝票番号:{0}で登録", salesData.SalesSlipNum));
                if (salesData.AcptAnOdrStatus == (int)AcptAnOdrStatusState.Sales)
                    acptAnOdrStatusName = "売上";
                else
                    acptAnOdrStatusName = "受注";
                MyOpeCtrl.Logger.WriteOperationLog(
                                        "",
                                        1,
                                        0,
                                        string.Format("{0}伝票、売上伝票番号:{1}で登録", acptAnOdrStatusName, salesData.SalesSlipNum));
                // UPD 2013/08/09 Redmine#39649 -----------------------------------------<<<<<
                // ADD 2013/08/08 Redmine#39649 -----------------------------------------<<<<<
            }
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了 ConstantManagement.MethodResult.ctFNC_NORMAL");
            // タブレットログ対応　---------------------------------<<<<<
            return ConstantManagement.MethodResult.ctFNC_NORMAL;
        }
        // タブレットログ対応　--------------------------------->>>>>
        private static void DivisionCustomSerializeArrayListForWritingProc(CustomSerializeArrayList paraList, out ArrayList salesDataList)
        {
            salesDataList = new ArrayList();
            for (int i = 0; i < paraList.Count; i++)
            {
                if (paraList[i] is CustomSerializeArrayList)
                {
                    CustomSerializeArrayList tempList = (CustomSerializeArrayList)paraList[i];
                    foreach (object tempObj in tempList)
                    {
                        //---------------------------------------
                        // 売上情報
                        //---------------------------------------
                        if (tempObj is SalesSlipWork)
                        {
                            salesDataList.Add(tempObj);
                        }
                    }
                }
            }
        }
        // --------------------- ADD 2017/03/30 陳艶丹 Redmine#49164 ---------------- >>>>
        /// <summary>
        /// PMTABセッション管理データ情報リストを取得する。
        /// </summary>
        /// <param name="paraList">伝票リスト</param>
        /// <param name="pmTabSessionMngList">PMTABセッション管理データリスト</param>
        /// <returns>なし</returns>
        private static void DivisionCustomSerializeArrayListForTabWrite(CustomSerializeArrayList paraList, out ArrayList pmTabSessionMngList)
        {
            pmTabSessionMngList = new ArrayList();
            for (int i = 0; i < paraList.Count; i++)
            {
                if (paraList[i] is CustomSerializeArrayList)
                {
                    CustomSerializeArrayList tempList = (CustomSerializeArrayList)paraList[i];
                    foreach (object tempObj in tempList)
                    {
                        if (tempObj is ArrayList)
                        {
                            //---------------------------------------
                            // PMTABセッション管理データ情報
                            //---------------------------------------
                            foreach (object subTempObj in tempObj as ArrayList)
                            {
                                if (subTempObj is PmTabSessionMngWork)
                                {
                                    pmTabSessionMngList.Add(subTempObj);
                                }
                            }
                        }
                    }
                    if (pmTabSessionMngList.Count > 0)
                    {
                        break;
                    }
                }
            }
        }
        // --------------------- ADD 2017/03/30 陳艶丹 Redmine#49164 ---------------- <<<<
        // タブレットログ対応　---------------------------------<<<<<
        #endregion  ■ データ登録

        #region ■ 送信処理
        /// <summary>
        /// 伝票番号リストを取得
        /// </summary>
        /// <param name="paraList">伝票リスト</param>
        /// <returns>伝票番号リスト</returns>
        private List<string> GetSalesSlipNumList(CustomSerializeArrayList paraList)
        {
            ArrayList salesDataList; // 売上データリスト
            ArrayList acptDataList;  // 受注データリスト
            ArrayList stockSlipInfoList; // 仕入データリスト
            ArrayList uoeOrderDataList; // UOE発注データリスト

            DivisionCustomSerializeArrayListForWriting(paraList, out salesDataList, out acptDataList, out stockSlipInfoList, out uoeOrderDataList);

            List<string> retList = new List<string>();
            if (null != salesDataList && salesDataList.Count > 0)
            {
                for (int i = 0; i < salesDataList.Count; i++)
                {
                    CustomSerializeArrayList list = (CustomSerializeArrayList)salesDataList[i];
                    foreach (object obj in list)
                    {
                        if (obj is SalesSlipWork)
                        {
                            SalesSlipWork salesSlipWork = (SalesSlipWork)obj;
                            retList.Add(salesSlipWork.SalesSlipNum);
                        }
                    }
                }
            }
            if (null != acptDataList && acptDataList.Count > 0)
            {
                for (int i = 0; i < acptDataList.Count; i++)
                {
                    CustomSerializeArrayList list = (CustomSerializeArrayList)acptDataList[i];
                    foreach (object obj in list)
                    {
                        if (obj is SalesSlipWork)
                        {
                            SalesSlipWork salesSlipWork = (SalesSlipWork)obj;
                            retList.Add(salesSlipWork.SalesSlipNum);
                        }
                    }
                }
            }
            return retList;
        }

        /// <summary>
        /// 伝票番号リストを取得
        /// </summary>
        /// <param name="paraList">伝票リスト</param>
        /// <returns>伝票番号リスト</returns>
        private string GetSalesSlipNumStrs(CustomSerializeArrayList paraList)
        {
            List<string> slipNumList = GetSalesSlipNumList(paraList);

            string retString = string.Empty;
            foreach (string slipNumStr in slipNumList)
            {
                if (!string.IsNullOrEmpty(retString))
                    retString += ",";
                retString += slipNumStr;
            }
            return retString;
        }

        /// <summary>
        /// 更新後のSCM受注明細データ（回答）を取得
        /// </summary>
        /// <param name="paramSalesScmCustList">更新後売上SCM回答リスト</param>
        /// <returns>SCM受注明細データ（回答）データ</returns>
        private SCMAcOdrDtlAsWork GetSCMAcOdrDtlAsFromApRet(ArrayList paramSalesScmCustList)
        {
            // タブレットログ対応　--------------------------------->>>>>
            const string methodName = "GetSCMAcOdrDtlAsFromApRet";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 開始");
            // タブレットログ対応　---------------------------------<<<<<

            if (null == paramSalesScmCustList || paramSalesScmCustList.Count == 0)
                return null;

            foreach (object obj in paramSalesScmCustList)
            {
                if (obj is ArrayList)
                {
                    SCMAcOdrDtlAsWork tempSCMAcOdrDtlAs = GetSCMAcOdrDtlAsFromApRet(obj as ArrayList);
                    if (null != tempSCMAcOdrDtlAs) return tempSCMAcOdrDtlAs;
                }
                else if (obj is SCMAcOdrDtlAsWork)
                {
                    return obj as SCMAcOdrDtlAsWork;
                }
                else
                {
                    continue;
                }
            }
            // タブレットログ対応　--------------------------------->>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了");
            // タブレットログ対応　---------------------------------<<<<<
            return null;
        }

        /// <summary>
        /// 送信を行う
        /// </summary>
        /// <param name="paraList">更新後伝票リスト</param>
        //private void SendScmData(SCMAcOdrDtlAsWork updSCMAcOdrDtlAs) // DEL 2013/07/03 qijh Redmine#37586
        private void SendScmData(CustomSerializeArrayList paraList) // ADD 2013/07/03 qijh Redmine#37586
        {
            // タブレットログ対応　--------------------------------->>>>>
            const string methodName = "SendScmData";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 開始");
            // タブレットログ対応　---------------------------------<<<<<

            SCMAcOdrDtlAsWork updSCMAcOdrDtlAs = GetSCMAcOdrDtlAsFromApRet(paraList); // ADD 2013/07/03 qijh Redmine#37586
            if (null == updSCMAcOdrDtlAs)
                return;

            string strSalesSlipNumbers = GetSalesSlipNumStrs(paraList); // ADD 2013/07/03 qijh Redmine#37586

            // タブレットログ対応　--------------------------------->>>>>
            EasyLogger.Write(CLASS_NAME, methodName, "送信処理開始"
                + "　問合せ番号：" + updSCMAcOdrDtlAs.InquiryNumber
                + "　問合せ・発注種別：" + updSCMAcOdrDtlAs.InqOrdDivCd
                //+ "　伝票番号：" + updSCMAcOdrDtlAs.SalesSlipNum // DEL 2013/07/03 qijh Redmine#37586
                + "　伝票番号：" + strSalesSlipNumbers // ADD 2013/07/03 qijh Redmine#37586
                );
            // タブレットログ対応　---------------------------------<<<<<
            // UPD 2013/08/28 吉岡 タブレット 送信中ウィンドウ非表示 ---------->>>>>>>>>>
            #region 旧ソース
            //Process p = Process.Start("PMSCM01100U.EXE", this._startParam + " /A" + " " + updSCMAcOdrDtlAs.InquiryNumber + ":" + updSCMAcOdrDtlAs.InqOrdDivCd + ":" + updSCMAcOdrDtlAs.SalesSlipNum); // DEL 2013/07/03 qijh Redmine#37586
            //Process p = Process.Start("PMSCM01100U.EXE", this._startParam + " /A" + " " + updSCMAcOdrDtlAs.InquiryNumber + ":" + updSCMAcOdrDtlAs.InqOrdDivCd + ":" + strSalesSlipNumbers); // ADD 2013/07/03 qijh Redmine#37586
            #endregion
            Process p = Process.Start("PMSCM01100U.EXE", this._startParam + " /A" + " " + updSCMAcOdrDtlAs.InquiryNumber + ":" + updSCMAcOdrDtlAs.InqOrdDivCd + ":" + strSalesSlipNumbers + " " + CMD_LINE_FOR_PMSCM01100_TABLET); 
            // UPD 2013/08/28 吉岡 タブレット 送信中ウィンドウ非表示 ----------<<<<<<<<<<

            p.WaitForExit();
            // タブレットログ対応　--------------------------------->>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了");
            // タブレットログ対応　---------------------------------<<<<<
        }
        #endregion  ■ 送信処理

        #region ■ 伝票印刷処理
        // --------------------- ADD 2013/06/29 qijh Redmine#37474 ------------- >>>>>
        /// <summary>
        /// 伝票印刷マイン処理
        /// </summary>
        /// <param name="salesScmCustArrayList">DBに登録後の伝票リスト</param>
        /// <param name="customer">得意先情報</param>
        private void PrintSlipMain(CustomSerializeArrayList salesScmCustArrayList, CustomerInfo customer)
        {
            const string methodName = "PrintSlipMain";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 開始");

            ArrayList salesDataList; // 売上データリスト
            ArrayList acptDataList;  // 受注データリスト
            ArrayList stockSlipInfoList; // 仕入データリスト
            ArrayList uoeOrderDataList; // UOE発注データリスト

            // CustomSerializeArrayListを各種データオブジェクトに分割します
            DivisionCustomSerializeArrayListForWriting(salesScmCustArrayList, out salesDataList, out acptDataList, out stockSlipInfoList, out uoeOrderDataList);

            // 印刷用のキー情報を取得
            GetPrintKeyInfo(salesDataList, acptDataList, customer);

            EasyLogger.Write(CLASS_NAME, methodName, methodName + "●印刷処理　開始");
            if (this._printSlipFlag == true)
            {
                // 伝票印刷処理
                Thread printSlipThread = new Thread(PrintSlipThread);
                printSlipThread.Start();
            }
            else
            {
                this._printSlipFlag = true;
            }
            EasyLogger.Write(CLASS_NAME, methodName, methodName + "○印刷処理　終了");

            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了");
        }

        /// <summary>
        /// CustomSerializeArrayListを各種データオブジェクトに分割します
        /// </summary>
        /// <param name="paraList">データ結合リスト</param>
        /// <param name="salesDataList">売上データリスト</param>
        /// <param name="acptDataList">受注データリスト</param>
        /// <param name="stockSlipInfoList">仕入データリスト</param>
        /// <param name="uoeOrderDataList">UOE発注データリスト</param>
        private void DivisionCustomSerializeArrayListForWriting(CustomSerializeArrayList paraList, out ArrayList salesDataList, out ArrayList acptDataList, out ArrayList stockSlipInfoList, out ArrayList uoeOrderDataList)
        {
            const string methodName = "DivisionCustomSerializeArrayListForWriting";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 開始");

            DivisionSalesSlipCustomSerializeArrayList.DivisionCustomSerializeArrayListForWriting(paraList, out salesDataList, out acptDataList, out stockSlipInfoList, out uoeOrderDataList);

            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了");
        }

        /// <summary>
        /// 印刷用のキー情報を取得
        /// </summary>
        /// <param name="salesDataList">売上伝票リスト</param>
        /// <param name="acptDataList">受注伝票リスト</param>
        /// <param name="customer">得意先情報</param>
        private void GetPrintKeyInfo(ArrayList salesDataList, ArrayList acptDataList, CustomerInfo customer)
        {
            const string methodName = "GetPrintKeyInfo";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 開始");

            this._qrMakeCndtn = new SalesQRSendCtrlCndtn();
            this._qrMakeCndtn.EnterpriseCode = this._enterpriseCode;

            EasyLogger.Write(CLASS_NAME, methodName, "●印刷用売上キー取得　開始");
            #region 売上データ取得
            //------------------------------------------------------
            // 売上データ取得
            //------------------------------------------------------
            this._printSalesKeyInfo = new Dictionary<string, SlipPrintInfoValue>();

            if (null != salesDataList && salesDataList.Count > 0)
            {
                for (int i = 0; i < salesDataList.Count; i++)
                {
                    CustomSerializeArrayList list = (CustomSerializeArrayList)salesDataList[i];

                    foreach (object obj in list)
                    {
                        if (obj is SalesSlipWork)
                        {
                            SalesSlipWork salesSlipWork = (SalesSlipWork)obj;
                            SlipPrintInfoValue slipPrintInfoValue = new SlipPrintInfoValue(salesSlipWork.AcptAnOdrStatus, ctDefaultSalesSlipNum, 0);

                            bool printKeyAddFlag = false;
                            switch ((SalesSlipInputAcs.AcptAnOdrStatusState)salesSlipWork.AcptAnOdrStatus)
                            {
                                case SalesSlipInputAcs.AcptAnOdrStatusState.Estimate:
                                case SalesSlipInputAcs.AcptAnOdrStatusState.UnitPriceEstimate:
                                    switch (customer.EstimatePrtDiv)
                                    {
                                        // 0:標準 ← 見積全体設定
                                        default:
                                        case 0:
                                            printKeyAddFlag = (this.EstimateDefSet.EstimatePrtDiv == 0);
                                            break;
                                        // 1:未使用 ← 0:しない
                                        case 1:
                                            printKeyAddFlag = false;
                                            break;
                                        // 2:使用 ← 1:する
                                        case 2:
                                            printKeyAddFlag = true;
                                            break;
                                    }
                                    if (printKeyAddFlag) this._printSalesKeyInfo.Add(salesSlipWork.SalesSlipNum, slipPrintInfoValue);
                                    break;

                                case SalesSlipInputAcs.AcptAnOdrStatusState.Sales:
                                    this._qrMakeCndtn.SalesSlipKeyList.Add(new SalesQRSendCtrlCndtn.QRSendCtrlSalesSlipKey(salesSlipWork.AcptAnOdrStatus, salesSlipWork.SalesSlipNum));

                                    switch (customer.SalesSlipPrtDiv)
                                    {
                                        // 0:標準 ← 売上全体設定
                                        default:
                                        case 0:
                                            printKeyAddFlag = (this.SalesTtlSt.SalesSlipPrtDiv == 0);
                                            break;
                                        // 1:未使用 ← 0:しない
                                        case 1:
                                            printKeyAddFlag = false;
                                            break;
                                        // 2:使用 ← 1:する
                                        case 2:
                                            printKeyAddFlag = true;
                                            break;
                                    }
                                    if (printKeyAddFlag)
                                    {
                                        //印刷する
                                        slipPrintInfoValue.NomalSalesSlipPrintFlag = 0;
                                    }
                                    else
                                    {
                                        //印刷しない
                                        slipPrintInfoValue.NomalSalesSlipPrintFlag = 1;
                                    }
                                    this._printSalesKeyInfo.Add(salesSlipWork.SalesSlipNum, slipPrintInfoValue);
                                    break;

                                case SalesSlipInputAcs.AcptAnOdrStatusState.Shipment:
                                    switch (customer.ShipmSlipPrtDiv)
                                    {
                                        // 0:標準 ← 売上全体設定
                                        default:
                                        case 0:
                                            printKeyAddFlag = (this.SalesTtlSt.ShipmSlipPrtDiv == 0);
                                            break;
                                        // 1:未使用 ← 0:しない
                                        case 1:
                                            printKeyAddFlag = false;
                                            break;
                                        // 2:使用 ← 1:する
                                        case 2:
                                            printKeyAddFlag = true;
                                            break;
                                    }
                                    if (printKeyAddFlag) this._printSalesKeyInfo.Add(salesSlipWork.SalesSlipNum, slipPrintInfoValue);
                                    break;

                                case SalesSlipInputAcs.AcptAnOdrStatusState.AcceptAnOrder:
                                    switch (customer.AcpOdrrSlipPrtDiv)
                                    {
                                        // 0:標準 ← 受注全体設定
                                        default:
                                        case 0:
                                            printKeyAddFlag = (this.AcptAnOdrTtlSt.AcpOdrrSlipPrtDiv == 1);
                                            break;
                                        // 1:未使用 ← 0:しない
                                        case 1:
                                            printKeyAddFlag = false;
                                            break;
                                        // 2:使用 ← 1:する
                                        case 2:
                                            printKeyAddFlag = true;
                                            break;
                                    }
                                    if (printKeyAddFlag) this._printSalesKeyInfo.Add(salesSlipWork.SalesSlipNum, slipPrintInfoValue);
                                    break;

                                default:
                                    break;
                            }
                        }
                    }
                }
            }
            #endregion
            EasyLogger.Write(CLASS_NAME, methodName, "○印刷用売上キー取得　終了");

            EasyLogger.Write(CLASS_NAME, methodName, "●印刷用受注キー取得　開始");
            #region 受注データ取得
            //------------------------------------------------------
            // 受注データ取得
            //------------------------------------------------------
            this._printAcptKeyInfo = new Dictionary<string, SlipPrintInfoValue>();

            if (acptDataList.Count != 0)
            {
                for (int i = 0; i < acptDataList.Count; i++)
                {
                    CustomSerializeArrayList list = (CustomSerializeArrayList)acptDataList[i];

                    ArrayList SalesDetailWorkList = list[1] as ArrayList;
                    SalesDetailWork salesDetailWork = null;
                    foreach (SalesDetailWork detailWork in SalesDetailWorkList)
                    {
                        salesDetailWork = detailWork;
                        if (detailWork.WayToOrder != 2)
                        {
                            break;
                        }
                        else
                        {
                            continue;
                        }
                    }

                    foreach (object obj in list)
                    {
                        if (obj is SalesSlipWork)
                        {
                            SalesSlipWork acptSlipWork = (SalesSlipWork)obj;
                            SlipPrintInfoValue slipPrintInfoValue = new SlipPrintInfoValue(acptSlipWork.AcptAnOdrStatus, ctDefaultSalesSlipNum, 0);

                            bool printKeyAddFlag = false;

                            switch ((SalesSlipInputAcs.AcptAnOdrStatusState)acptSlipWork.AcptAnOdrStatus)
                            {
                                case SalesSlipInputAcs.AcptAnOdrStatusState.Estimate:
                                case SalesSlipInputAcs.AcptAnOdrStatusState.UnitPriceEstimate:
                                case SalesSlipInputAcs.AcptAnOdrStatusState.Sales:
                                case SalesSlipInputAcs.AcptAnOdrStatusState.Shipment:
                                    break;
                                case SalesSlipInputAcs.AcptAnOdrStatusState.AcceptAnOrder:
                                    switch (customer.AcpOdrrSlipPrtDiv)
                                    {
                                        // 0:標準 ← 受注全体設定
                                        default:
                                        case 0:
                                            printKeyAddFlag = (this.AcptAnOdrTtlSt.AcpOdrrSlipPrtDiv == 1);
                                            break;
                                        // 1:未使用 ← 0:しない
                                        case 1:
                                            printKeyAddFlag = false;
                                            break;
                                        // 2:使用 ← 1:する
                                        case 2:
                                            printKeyAddFlag = true;
                                            break;
                                    }
                                    if (salesDetailWork.WayToOrder != 2)
                                    {
                                        if (printKeyAddFlag) this._printAcptKeyInfo.Add(acptSlipWork.SalesSlipNum, slipPrintInfoValue);
                                    }
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                }
            }
            #endregion
            EasyLogger.Write(CLASS_NAME, methodName, "○印刷用受注キー取得　終了");
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了");
        }

        /// <summary>
        /// 伝票印刷スレッド
        /// </summary>
        public void PrintSlipThread()
        {
            // DEL 2013/07/29 吉岡 ログ見直し----------------------->>>>>>>>>>>>>>>>>>>>>>>>>>>>
            // const string methodName = "PrintSlipThread";
            // EasyLogger.Write(CLASS_NAME, methodName, methodName + " 開始");
            // DEL 2013/07/29 吉岡 ログ見直し-----------------------<<<<<<<<<<<<<<<<<<<<<<<<<<<<

            // 印刷処理
            this._printThreadOverFlag = false;
            this.PrintSlip(true);
            this._printThreadOverFlag = true;

            // DEL 2013/07/29 吉岡 ログ見直し----------------------->>>>>>>>>>>>>>>>>>>>>>>>>>>>
            // EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了");
            // DEL 2013/07/29 吉岡 ログ見直し-----------------------<<<<<<<<<<<<<<<<<<<<<<<<<<<<
        }

        /// <summary>
        /// 伝票印刷処理
        /// </summary>
        /// <param name="printWithoutDialog">印刷ダイアローグフラグ</param>
        public void PrintSlip(bool printWithoutDialog)
        {
            // DEL 2013/07/29 吉岡 ログ見直し----------------------->>>>>>>>>>>>>>>>>>>>>>>>>>>>
            // const string methodName = "PrintSlip";
            // EasyLogger.Write(CLASS_NAME, methodName, methodName + " 開始");
            // DEL 2013/07/29 吉岡 ログ見直し-----------------------<<<<<<<<<<<<<<<<<<<<<<<<<<<<

            #region ●初期処理
            DCCMN02000UA printDisp = new DCCMN02000UA(); // 伝票印刷情報設定画面インスタンス生成
            SalesSlipPrintCndtn.SalesSlipKey key = new SalesSlipPrintCndtn.SalesSlipKey(); // 伝票印刷用Keyインスタンス生成
            List<SalesSlipPrintCndtn.SalesSlipKey> keyList = new List<SalesSlipPrintCndtn.SalesSlipKey>(); // 伝票印刷用KeyListインスタンス生成
            bool reissueDiv = false;
            int nomalSalesSlipPrintFlag = 0;
            #endregion

            #region ●売上伝票Key情報セット
            foreach (string salesSlipNum in this._printSalesKeyInfo.Keys)
            {
                SlipPrintInfoValue slipPrintInfoValue = this._printSalesKeyInfo[salesSlipNum];
                if (slipPrintInfoValue.AcptAnOdrStatus != (int)SalesSlipInputAcs.AcptAnOdrStatusState.AcceptAnOrder)
                {
                    key = new SalesSlipPrintCndtn.SalesSlipKey();
                    key.AcptAnOdrStatus = slipPrintInfoValue.AcptAnOdrStatus;
                    key.SalesSlipNum = salesSlipNum;
                    keyList.Add(key);
                    nomalSalesSlipPrintFlag = slipPrintInfoValue.NomalSalesSlipPrintFlag;
                }
                if (slipPrintInfoValue.SalesSlipNum != ctDefaultSalesSlipNum) reissueDiv = true;
            }
            this._printSalesKeyInfo.Clear();
            #endregion

            #region ●受注伝票Key情報セット
            foreach (string salesSlipNum in this._printAcptKeyInfo.Keys)
            {
                SlipPrintInfoValue slipPrintInfoValue = this._printAcptKeyInfo[salesSlipNum];
                if (slipPrintInfoValue.AcptAnOdrStatus == (int)SalesSlipInputAcs.AcptAnOdrStatusState.AcceptAnOrder)
                {
                    key = new SalesSlipPrintCndtn.SalesSlipKey();
                    key.AcptAnOdrStatus = slipPrintInfoValue.AcptAnOdrStatus;
                    key.SalesSlipNum = salesSlipNum;
                    keyList.Add(key);
                }
                if (slipPrintInfoValue.SalesSlipNum != ctDefaultSalesSlipNum) reissueDiv = true;
            }
            this._printAcptKeyInfo.Clear();
            #endregion

            #region ●印刷情報パラメータセット
            SalesSlipPrintCndtn salesSlipPrintCndtn = new SalesSlipPrintCndtn();
            salesSlipPrintCndtn.EnterpriseCode = this._enterpriseCode;
            salesSlipPrintCndtn.SalesSlipKeyList = keyList;
            salesSlipPrintCndtn.ReissueDiv = reissueDiv;
            salesSlipPrintCndtn.MakeQRDiv = false;

            salesSlipPrintCndtn.NomalSalesSlipPrintFlag = nomalSalesSlipPrintFlag;
            salesSlipPrintCndtn.ScmFlg = this._isConnScm;
            // ADD 2013/09/19 Redmine#40342対応 --------------------------------------------------->>>>>
            // タブレット起動区分設定
            printDisp.IsTablet = true;
            // ADD 2013/09/19 Redmine#40342対応 ---------------------------------------------------<<<<<
            #endregion

            #region ●印刷処理
            if (salesSlipPrintCndtn.SalesSlipKeyList.Count != 0) printDisp.ShowDialog(salesSlipPrintCndtn, printWithoutDialog);
            #endregion

            // DEL 2013/07/29 吉岡 ログ見直し----------------------->>>>>>>>>>>>>>>>>>>>>>>>>>>>
            // EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了");
            // DEL 2013/07/29 吉岡 ログ見直し-----------------------<<<<<<<<<<<<<<<<<<<<<<<<<<<<
        }
        // --------------------- ADD 2013/06/29 qijh Redmine#37474 ------------- <<<<<
        #endregion ■ 伝票印刷処理  

        // ADD 2013/08/14 吉岡 Redmine#39942 --------->>>>>>>>>>>>>>>>>>>>>>>>>
        #region 伝票作成方法によるソート処理
                /// <summary>
        /// ソート済み売上明細データリストを生成します。
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="salesSlip">売上データ</param>
        /// <param name="sourceSalesDetailList">元となる売上明細データのリスト</param>
        /// <returns>ソート済み売上明細データリスト</returns>
        private IList<SalesDetail> CreateSortedSalesDetailList(
            SalesSlip salesSlip,
            IList<SalesDetail> sourceSalesDetailList
        )
        {
            if (SalesTtlSt == null) return sourceSalesDetailList;

            switch (SalesTtlSt.SlipCreateProcess)
            {
                case 0: // 入力順(行番号順)
                    return sourceSalesDetailList;

                case 1: // 在庫・取寄順(在庫取寄区分(0:取寄 1:在庫)・行番号順)
                    return OrderBySalesOrderDivCd(sourceSalesDetailList);

                case 2: // 倉庫順(倉庫・行番号順)
                case 3: // 出力先別(倉庫・行番号順)
                    return OrderByWarehouseCode(sourceSalesDetailList);
            }

            return sourceSalesDetailList;
        }

        #region <在庫・取寄順(在庫取寄区分(0:取寄 1:在庫)・行番号順)>

        /// <summary>
        /// 在庫・取寄順(在庫取寄区分(0:取寄 1:在庫)・行番号順)でソートします。
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="sourceSalesDetailList">元となる売上明細データのリスト</param>
        /// <returns>
        /// 在庫・取寄順(在庫取寄区分(0:取寄 1:在庫)・行番号順)でソートした売上明細データのリスト
        /// </returns>
        private IList<SalesDetail> OrderBySalesOrderDivCd(IList<SalesDetail> sourceSalesDetailList)
        {
            SortedList<string, SalesDetail> sortedList = new SortedList<string, SalesDetail>();
            for (int i = 0; i < sourceSalesDetailList.Count; i++)
            {
                string sortKey = GetKeyOfOrderBySalesOrderDivCd(sourceSalesDetailList[i], i);
                sortedList.Add(sortKey, sourceSalesDetailList[i]);
            }

            IList<SalesDetail> orderBySalesOrderDivCdList = ConvertSalesDetailList(sortedList);
            return orderBySalesOrderDivCdList.Count > 0 ? orderBySalesOrderDivCdList : sourceSalesDetailList;
        }

        /// <summary>
        /// 在庫・取寄順(在庫取寄区分(0:取寄 1:在庫)・行番号順)のソートキーを取得します。
        /// </summary>
        /// <param name="salesDetail">売上明細データ</param>
        /// <param name="salesRowNo">行番号</param>
        /// <returns></returns>
        private string GetKeyOfOrderBySalesOrderDivCd(
            SalesDetail salesDetail,
            int salesRowNo
        )
        {
            return Math.Abs(salesDetail.SalesOrderDivCd - 1).ToString() + salesRowNo.ToString("0000");
        }

        #endregion // </在庫・取寄順(在庫取寄区分(0:取寄 1:在庫)・行番号順)>

        #region <倉庫順(倉庫・行番号順)／出力先別(倉庫・行番号順)>

        /// <summary>
        /// 倉庫順(倉庫・行番号順)でソートします。
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="sourceSalesDetailList">元となる売上明細データのリスト</param>
        /// <returns>
        /// 倉庫順(倉庫・行番号順)でソートした売上明細データのリスト
        /// </returns>
        private IList<SalesDetail> OrderByWarehouseCode(IList<SalesDetail> sourceSalesDetailList)
        {
            SortedList<string, SalesDetail> sortedList = new SortedList<string, SalesDetail>();
            for (int i = 0; i < sourceSalesDetailList.Count; i++)
            {
                string sortKey = GetKeyOfOrderByWarehouseCode(sourceSalesDetailList[i], i);
                sortedList.Add(sortKey, sourceSalesDetailList[i]);
            }

            IList<SalesDetail> orderByWarehouseCodeList = ConvertSalesDetailList(sortedList);
            return orderByWarehouseCodeList.Count > 0 ? orderByWarehouseCodeList : sourceSalesDetailList;
        }

        /// <summary>
        /// 倉庫順(倉庫・行番号順)のソートキーを取得します。
        /// </summary>
        /// <param name="salesDetail">売上明細データ</param>
        /// <param name="salesRowNo">行番号</param>
        /// <returns></returns>
        private string GetKeyOfOrderByWarehouseCode(
            SalesDetail salesDetail,
            int salesRowNo
        )
        {
            return ConvertNumber(salesDetail.WarehouseCode).ToString("000000") + salesRowNo.ToString("0000");
        }
        /// <summary>
        /// 数値に変換します。
        /// </summary>
        /// <param name="target">対象文字列</param>
        /// <returns>数値に変換できない場合、<c>0</c>を返します。</returns>
        private int ConvertNumber(string target)
        {
            if (string.IsNullOrEmpty(target.Trim())) return 0;

            int number = 0;
            return int.TryParse(target.Trim(), out number) ? number : 0;
        }
        #endregion // </倉庫順(倉庫・行番号順)／出力先別(倉庫・行番号順)>

        /// <summary>
        /// 売上明細データリストに変換します。
        /// </summary>
        /// <param name="sortedList">あるソートキーでソートされた売上明細データリスト</param>
        /// <returns>売上明細データリスト</returns>
        private IList<SalesDetail> ConvertSalesDetailList(SortedList<string, SalesDetail> sortedList)
        {
            IList<SalesDetail> sortedSalesDetailList = new List<SalesDetail>();
            {
                foreach (KeyValuePair<string, SalesDetail> sortedSalesDetail in sortedList)
                {
                    sortedSalesDetailList.Add(sortedSalesDetail.Value);
                }
            }
            return sortedSalesDetailList;
        }

        #endregion
        // ADD 2013/08/14 吉岡 Redmine#39942 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

        // ADD 2013/08/16 吉岡 Redmine#39972 ------------>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        #region WebSync通知
        /// <summary>
        /// 指定或いは関連のTablet端末への返答送信処理
        /// </summary>
        /// <param name="destEnterpriseCode">企業コード</param>
        /// <param name="destSectionCode">拠点コード</param>
        /// <param name="inquiryNumber">問い合わせ番号</param>
        private void NotifyTabletByPublish(int status, string message, string sessionId,string sectionCode)
        {
            const string methodName = "NotifyTabletByPublish";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 開始");

            ClientArgs clientArgs = new ClientArgs();
            // PushサーバーURLの設定
            string wkStr1 = LoginInfoAcquisition.GetAPServiceTargetDomain(Broadleaf.Application.Resources.ConstantManagement_SF_PRO.ServerCode_WEBSYNCAP);
            string wkStr2 = LoginInfoAcquisition.GetConnectionInfo(Broadleaf.Application.Resources.ConstantManagement_SF_PRO.ServerCode_WEBSYNCAP, Broadleaf.Application.Resources.ConstantManagement_SF_PRO.IndexCode_WebSync_WebPath);
            string webSyncUrl = wkStr1 + wkStr2;
            clientArgs.Url = webSyncUrl;

            SFCMN01501CA _tabletPushClient = new SFCMN01501CA(clientArgs);    // Pushクライアントオブジェクト

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
            _tabletPushClient.Connect(connectArgs);

            TabletPullData payload = new TabletPullData();
            payload.Status = status;
            payload.Message = message;
            // ADD 2013/08/26 Redmine#40121 -------------------------------------->>>>>
            payload.NoticeMode = (int)ScmPushDataConstMode.PROCESSFINISHED;
            payload.SessionId = sessionId;
            // ADD 2013/08/26 Redmine#40121 --------------------------------------<<<<<

            PublishArgs publishArgs = new PublishArgs();
            publishArgs.Payload = payload;
            // 指定のTablet端末への返答送信処理
            publishArgs.Channel = string.Format("/{0}/PMNS/{1}/{2}/{3}", _tabletPushClient.WEBSYNC_CHANNEL_PMTAB, _enterpriseCode, sectionCode.Trim(), sessionId);
            _tabletPushClient.Publish(publishArgs);

            EasyLogger.Write(CLASS_NAME, methodName,
                "通知内容 Status：" + payload.Status.ToString()
                + "  Message：" + payload.Message
                // ADD 2013/08/26 Redmine#40121 -------------------------------------->>>>>
                + "  NoticeMode：" + payload.NoticeMode
                // ADD 2013/08/26 Redmine#40121 --------------------------------------<<<<<
                + "  Channel：" + publishArgs.Channel
                );
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了");
        }

        #region DEL 2013/08/30 30秒タイマーは常駐処理で行うので削除
        // DEL 2013/08/30 30秒タイマーは常駐処理で行うので削除 --------------------------------->>>>>
        //// ADD 2013/08/26 Redmine#40121 -------------------------------------------->>>>>
        ///// <summary>
        ///// 指定或いは関連のTablet端末への返答送信処理（通知モード）
        ///// </summary>
        ///// <param name="sectionCode">拠点コード</param>
        ///// <param name="sessionId">セッションID</param>
        //private void NotifyTabletByPublish(object o)
        //{
        //    const string methodName = "NotifyTabletByPublish(NoticeMode)";
        //    EasyLogger.Write(CLASS_NAME, methodName, methodName + " 開始");

        //    ClientArgs clientArgs = new ClientArgs();
        //    // PushサーバーURLの設定
        //    string wkStr1 = LoginInfoAcquisition.GetAPServiceTargetDomain(Broadleaf.Application.Resources.ConstantManagement_SF_PRO.ServerCode_WEBSYNCAP);
        //    string wkStr2 = LoginInfoAcquisition.GetConnectionInfo(Broadleaf.Application.Resources.ConstantManagement_SF_PRO.ServerCode_WEBSYNCAP, Broadleaf.Application.Resources.ConstantManagement_SF_PRO.IndexCode_WebSync_WebPath);
        //    string webSyncUrl = wkStr1 + wkStr2;
        //    clientArgs.Url = webSyncUrl;

        //    SFCMN01501CA _tabletPushClient = new SFCMN01501CA(clientArgs);    // Pushクライアントオブジェクト

        //    ConnectArgs connectArgs = new ConnectArgs();
        //    connectArgs.StayConnected = true; // 接続が切断場合、自動的に再接続する
        //    connectArgs.ReconnectInterval = 5000; // 5秒　接続失敗場合、再接続間隔を指定する
        //    connectArgs.ConnectFailure += new PushClientEventHandler<ConnectFailureEventArgs>(
        //        delegate(IScmPushClient client, ConnectFailureEventArgs args)
        //        {
        //            // 新着チェッカーが起動する時、Pushサーバーを接続できなければ、このメソッドを呼びられる
        //            // 接続した後、Pushサーバーと通信エラー場合、OnStreamFailureイベントだけを呼びられる

        //            // 接続が失敗すれば、Pushサーバーへ再接続
        //            args.Reconnect = true;
        //        }
        //    );
        //    _tabletPushClient.Connect(connectArgs);

        //    TabletPullData payload = new TabletPullData();
        //    payload.SessionId = this._sessionId;
        //    payload.NoticeMode = (int)ScmPushDataConstMode.WAITETIMERESET;

        //    PublishArgs publishArgs = new PublishArgs();
        //    publishArgs.Payload = payload;
        //    // 指定のTablet端末への返答送信処理
        //    publishArgs.Channel = string.Format("/{0}/PMNS/{1}/{2}/{3}", _tabletPushClient.WEBSYNC_CHANNEL_PMTAB, _enterpriseCode, this._sectionCode.Trim(), this._sessionId);
        //    _tabletPushClient.Publish(publishArgs);

        //    EasyLogger.Write(CLASS_NAME, methodName,
        //        "通知内容 Status：" + payload.Status.ToString()
        //        + "  Message：" + payload.Message
        //        + "  NoticeMode：" + payload.NoticeMode
        //        + "  Channel：" + publishArgs.Channel
        //        );
        //    EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了");
        //}
        //// ADD 2013/08/26 Redmine#40121 --------------------------------------------<<<<<
        // DEL 2013/08/30 30秒タイマーは常駐処理で行うので削除 ---------------------------------<<<<<
        #endregion

        #endregion
        // ADD 2013/08/16 吉岡 Redmine#39972 ------------<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

    }
    // ADD 2013/08/19 吉岡  Redmine#39992 --------->>>>>>>>>>>>>>>>>>>>>>>>>
    /// <summary>
    /// 売上伝票入力、検索見積発行からの移植クラス
    /// </summary>
    public class OtherAppComponent
    {
        private const string CLASS_NAME = "OtherAppComponent";
        #region <企業コード>

        /// <summary>企業コード</summary>
        private readonly string _enterpriseCode;
        /// <summary>企業コード取得します。</summary>
        private string EnterpriseCode { get { return _enterpriseCode; } }

        #endregion // </企業コード>

        #region <拠点コード>

        /// <summary>拠点コード</summary>
        private readonly string _sectionCode;
        /// <summary>拠点コードを取得します。</summary>
        private string SectionCode { get { return _sectionCode; } }

        #endregion // </拠点コード>

        #region <Constructor>

        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        public OtherAppComponent(
            string enterpriseCode,
            string sectionCode
        )
        {
            _enterpriseCode = enterpriseCode;
            _sectionCode = sectionCode;
        }

        #endregion // </Constructor>

        #region <売上データの算出関連>

        /// <summary>
        /// 検索見積用初期値取得アクセスクラスのレプリカ
        /// </summary>
        private class EstimateInputInitDataAcs
        {
            private const string CLASS_NAME = "EstimateInputInitDataAcs";
            #region <企業コード>

            /// <summary>企業コード</summary>
            private readonly string _enterpriseCode;
            /// <summary>企業コードを取得します。</summary>
            private string EnterpriseCode { get { return _enterpriseCode; } }

            #endregion // </企業コード>

            #region <拠点コード>

            /// <summary>拠点コード</summary>
            private readonly string _sectionCode;
            /// <summary>拠点コードを取得します。</summary>
            public string SectionCode { get { return _sectionCode; } }

            #endregion // </拠点コード>

            #region <Constructor>

            /// <summary>
            /// カスタムコンストラクタ
            /// </summary>
            /// <param name="enterpriseCode">企業コード</param>
            /// <param name="sectionCode">拠点コード</param>
            public EstimateInputInitDataAcs(
                string enterpriseCode,
                string sectionCode
            )
            {
                _enterpriseCode = enterpriseCode;
                _sectionCode = sectionCode;
            }

            #endregion // </Constructor>

            /// <summary>端数処理対象金額区分（消費税）</summary>
            public const int ctFracProcMoneyDiv_Tax = 1;
            /// <summary>端数処理対象金額区分（単価）</summary>
            public const int ctFracProcMoneyDiv_UnitPrice = 2;

            /// <summary>売上金額処理区分設定リスト</summary>
            private List<SalesProcMoney> _salesProcMoneyList;
            /// <summary>売上金額処理区分設定リストのレプリカを取得します。</summary>
            private List<SalesProcMoney> SalesProcMoneyList
            {
                get
                {
                    if (_salesProcMoneyList == null)
                    {
                        ArrayList recordList = new ArrayList();
                        int status = SalesProcMoneyFind(EnterpriseCode, out recordList);
                        if (status == (int)ResultUtil.ResultCode.Normal)
                        {
                            _salesProcMoneyList = new List<SalesProcMoney>((SalesProcMoney[])recordList.ToArray(typeof(SalesProcMoney)));
                        }
                    }
                    return _salesProcMoneyList;
                }
            }

            /// <summary>
            /// 検索します。
            /// </summary>
            /// <param name="enterpriseCode">企業コード</param>
            /// <returns>該当する売上金額処理区分</returns>
            public int SalesProcMoneyFind(string enterpriseCode, out ArrayList foundRecordList)
            {
                const string methodName = "SalesProcMoneyFind";
                EasyLogger.Write(CLASS_NAME, methodName, methodName + " 開始");

                SalesProcMoneyAcs salesProcMoneyAcs = new SalesProcMoneyAcs();

                foundRecordList = null;
                int status = salesProcMoneyAcs.Search(out foundRecordList, enterpriseCode);

                EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了 売上金額処理区分設定マスタ 検索結果status：" + status.ToString());
                return status;
            }

            #region ■売上金額処理区分設定マスタ データ取得処理関連

            /// <summary>
            /// 売上金額処理区分設定マスタより、対象金額に該当する端数処理単位、端数処理コードを取得します。
            /// </summary>
            /// <param name="fracProcMoneyDiv">端数処理対象金額区分</param>
            /// <param name="fractionProcCode">端数処理コード</param>
            /// <param name="price">対象金額</param>
            /// <param name="fractionProcUnit">端数処理単位</param>
            /// <param name="fractionProcCd">端数処理区分</param>
            public void GetSalesFractionProcInfo(
                int fracProcMoneyDiv,
                int fractionProcCode,
                double price,
                out double fractionProcUnit,
                out int fractionProcCd
            )
            {
                const string methodName = "GetSalesFractionProcInfo";
                EasyLogger.Write(CLASS_NAME, methodName, methodName + " 開始");
                //デフォルト
                switch (fracProcMoneyDiv)
                {
                    case ctFracProcMoneyDiv_UnitPrice:	// 単価
                        fractionProcUnit = 0.01;
                        break;
                    default:
                        fractionProcUnit = 1;			// 単価以外は1円単位
                        break;
                }
                fractionProcCd = 1;     // 切捨て

                if (SalesProcMoneyList == null || SalesProcMoneyList.Count == 0) return;

                List<SalesProcMoney> salesProcMoneyList = SalesProcMoneyList.FindAll(
                                            delegate(SalesProcMoney salesProcMoney)
                                            {
                                                if ((salesProcMoney.FracProcMoneyDiv == fracProcMoneyDiv) &&
                                                    (salesProcMoney.FractionProcCode == fractionProcCode) &&
                                                    (salesProcMoney.UpperLimitPrice >= price))
                                                {
                                                    return true;
                                                }
                                                else
                                                {
                                                    return false;
                                                }
                                            });
                if (salesProcMoneyList != null && salesProcMoneyList.Count > 0)
                {
                    fractionProcUnit = salesProcMoneyList[0].FractionProcUnit;
                    fractionProcCd = salesProcMoneyList[0].FractionProcCd;
                }

                EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了");
            }

            #endregion
        }

        /// <summary>検索見積用初期値取得アクセスクラス</summary>
        private EstimateInputInitDataAcs _estimateInputInitDataAcs;
        /// <summary>検索見積用初期値取得アクセスクラスのレプリカを取得します。</summary>
        private EstimateInputInitDataAcs EstimateInputInitDataAcsReplica
        {
            get
            {
                if (_estimateInputInitDataAcs == null)
                {
                    _estimateInputInitDataAcs = new EstimateInputInitDataAcs(EnterpriseCode, SectionCode);
                }
                return _estimateInputInitDataAcs;
            }
        }

        /// <summary>
        /// 売上金額の合計を計算します。
        /// </summary>
        /// <param name="salesDetailList">売上明細データリスト</param>
        /// <param name="consTaxRate">消費税税率</param>
        /// <param name="fractionProcCd">消費税端数処理コード</param>
        /// <param name="totalAmountDispWayCd">総額表示方法区分</param>
        /// <param name="consTaxLayMethod">消費税転嫁方式</param>
        /// 
        /// <param name="salesTotalTaxInc">売上伝票合計（税込）</param>
        /// <param name="salesTotalTaxExc">売上伝票合計（税抜）</param>
        /// <param name="salesSubtotalTax">売上小計（税）</param>
        /// <param name="itdedSalesOutTax">売上外税対象額</param>
        /// <param name="itdedSalesInTax">売上内税対象額</param>
        /// <param name="salSubttlSubToTaxFre">売上小計非課税対象額</param>
        /// <param name="salesOutTax">売上金額消費税額（外税）</param>
        /// <param name="salAmntConsTaxInclu">売上金額消費税額（内税）</param>
        /// <param name="salesDisTtlTaxExc">売上値引金額計（税抜）</param>
        /// <param name="itdedSalesDisOutTax">売上値引外税対象額合計</param>
        /// <param name="itdedSalesDisInTax">売上値引内税対象額合計</param>
        /// <param name="itdedSalesDisTaxFre">売上値引非課税対象額合計</param>
        /// <param name="salesDisOutTax">売上値引消費税額（外税）</param>
        /// <param name="salesDisTtlTaxInclu">売上値引消費税額（内税）</param>
        /// <param name="totalCost">原価金額計</param>
        /// 
        /// <param name="stockGoodsTtlTaxExc">在庫商品合計金額(税抜)</param>
        /// <param name="pureGoodsTtlTaxExc">純正商品合計金額(税抜)</param>
        /// <param name="balanceAdjust">消費税調整額</param>
        /// <param name="taxAdjust">残高調整額</param>
        /// 
        /// <param name="salesPrtSubttlInc">売上部品小計（税込）</param>
        /// <param name="salesPrtSubttlExc">売上部品小計（税抜）</param>
        /// <param name="salesWorkSubttlInc">売上作業小計（税込）</param>
        /// <param name="salesWorkSubttlExc">売上作業小計（税抜）</param>
        /// <param name="itdedPartsDisInTax">部品値引対象額合計（税込）</param>
        /// <param name="itdedPartsDisOutTax">部品値引対象額合計（税抜）</param>
        /// <param name="itdedWorkDisInTax">作業値引対象額合計（税込）</param>
        /// <param name="itdedWorkDisOutTax">作業値引対象額合計（税抜）</param>
        /// 
        /// <param name="totalMoneyForGrossProfit">粗利計算用売上金額</param>
        public void CalculationSalesTotalPrice(
            List<SalesDetail> salesDetailList,
            double consTaxRate,
            int fractionProcCd,
            int totalAmountDispWayCd,
            int consTaxLayMethod,
            out long salesTotalTaxInc,
            out long salesTotalTaxExc,
            out long salesSubtotalTax,
            out long itdedSalesOutTax,
            out long itdedSalesInTax,
            out long salSubttlSubToTaxFre,
            out long salesOutTax,
            out long salAmntConsTaxInclu,
            out long salesDisTtlTaxExc,
            out long itdedSalesDisOutTax,
            out long itdedSalesDisInTax,
            out long itdedSalesDisTaxFre,
            out long salesDisOutTax,
            out long salesDisTtlTaxInclu,
            out long totalCost,

            out long stockGoodsTtlTaxExc,
            out long pureGoodsTtlTaxExc,
            out long balanceAdjust,
            out long taxAdjust,

            out long salesPrtSubttlInc,
            out long salesPrtSubttlExc,
            out long salesWorkSubttlInc,
            out long salesWorkSubttlExc,
            out long itdedPartsDisInTax,
            out long itdedPartsDisOutTax,
            out long itdedWorkDisInTax,
            out long itdedWorkDisOutTax,

            out long totalMoneyForGrossProfit
        )
        {
            const string methodName = "CalculationSalesTotalPrice";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 開始");

            int taxFracProcCd = 0;
            double taxFracProcUnit = 0;
            EstimateInputInitDataAcsReplica.GetSalesFractionProcInfo(
                EstimateInputInitDataAcs.ctFracProcMoneyDiv_Tax,
                fractionProcCd,
                0,
                out taxFracProcUnit,
                out taxFracProcCd
            );

            salesTotalTaxInc = 0;       // 売上伝票合計（税込）
            salesTotalTaxExc = 0;       // 売上伝票合計（税抜）
            salesSubtotalTax = 0;       // 売上小計（税）
            itdedSalesOutTax = 0;       // 売上外税対象額
            itdedSalesInTax = 0;        // 売上内税対象額
            salSubttlSubToTaxFre = 0;   // 売上小計非課税対象額
            salesOutTax = 0;            // 売上金額消費税額（外税）
            salAmntConsTaxInclu = 0;    // 売上金額消費税額（内税）
            salesDisTtlTaxExc = 0;      // 売上値引金額計（税抜）
            itdedSalesDisOutTax = 0;    // 売上値引外税対象額合計
            itdedSalesDisInTax = 0;     // 売上値引内税対象額合計
            itdedSalesDisTaxFre = 0;    // 売上値引非課税対象額合計
            salesDisOutTax = 0;         // 売上値引消費税額（外税）
            salesDisTtlTaxInclu = 0;    // 売上値引消費税額（内税）
            stockGoodsTtlTaxExc = 0;    // 在庫商品合計金額（税抜）
            pureGoodsTtlTaxExc = 0;     // 純正商品合計金額（税抜）
            totalCost = 0;              // 原価金額計
            taxAdjust = 0;              // 消費税調整額
            balanceAdjust = 0;          // 残高調整額
            salesPrtSubttlInc = 0;      // 売上部品小計（税込）
            salesPrtSubttlExc = 0;      // 売上部品小計（税抜）
            salesWorkSubttlInc = 0;     // 売上作業小計（税込）
            salesWorkSubttlExc = 0;     // 売上作業小計（税抜）
            itdedPartsDisInTax = 0;     // 部品値引対象額合計（税込）
            itdedPartsDisOutTax = 0;    // 部品値引対象額合計（税抜）
            itdedWorkDisInTax = 0;      // 作業値引対象額合計（税込）
            itdedWorkDisOutTax = 0;     // 作業値引対象額合計（税抜）
            totalMoneyForGrossProfit = 0; // 粗利計算用売上金額

            long itdedSalesInTax_TaxInc = 0;    // 売上内税対象額（税込）
            long itdedSalesDisInTax_TaxInc = 0; // 売上値引内税対象額合計（税込）
            long totalMoney_TaxInc_ForGrossProfitMoney = 0;     // 粗利計算用売上金額計（内税商品分）
            long totalMoney_TaxExc_ForGrossProfitMoney = 0;     // 粗利計算用売上金額計（外税商品分）
            long totalMoney_TaxNone_ForGrossProfitMoney = 0;    // 粗利計算用売上金額計（非課税商品分）
            long stockGoodsTtlTaxExc_TaxInc = 0;                // 在庫商品合計金額（税抜）（内税商品分）
            long stockGoodsTtlTaxExc_TaxExc = 0;                // 在庫商品合計金額（税抜）（外税商品分）
            long stockGoodsTtlTaxExc_TaxNone = 0;               // 在庫商品合計金額（税抜）（非課税商品分）
            long pureGoodsTtlTaxExc_TaxInc = 0;                 // 純正商品合計金額（税抜）（内税商品分）
            long pureGoodsTtlTaxExc_TaxExc = 0;                 // 純正商品合計金額（税抜）（外税商品分）
            long pureGoodsTtlTaxExc_TaxNone = 0;                // 純正商品合計金額（税抜）（非課税商品分）

            //-----------------------------------------------------------------------------
            // 計算に必要な金額の計算
            //-----------------------------------------------------------------------------
            #region ●計算に必要な金額の計算

            foreach (SalesDetail salesDetail in salesDetailList)
            {
                // 売上伝票区分（明細）によって集計方法が変わる分
                switch (salesDetail.SalesSlipCdDtl)
                {
                    // 売上、返品
                    case (int)SalesSlipInputAcs.SalesSlipCdDtl.Sales:
                    case (int)SalesSlipInputAcs.SalesSlipCdDtl.RetGoods:
                        {
                            // 税区分：外税
                            if (salesDetail.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxExc)
                            {
                                // 売上外税対象額
                                itdedSalesOutTax += salesDetail.SalesMoneyTaxExc;

                                // 売上金額消費税額（外税）
                                salesOutTax += salesDetail.SalesPriceConsTax;

                                // 在庫商品合計金額（税抜）（外税商品分）
                                if (salesDetail.SalesOrderDivCd == (int)SalesSlipInputAcs.SalesOrderDivCd.Stock)
                                    stockGoodsTtlTaxExc_TaxExc += salesDetail.SalesMoneyTaxExc;

                                // 純正商品合計金額（税抜）（外税商品分）
                                if (salesDetail.GoodsKindCode == 0)
                                    pureGoodsTtlTaxExc_TaxExc += salesDetail.SalesMoneyTaxExc;
                            }
                            // 税区分：内税
                            if (salesDetail.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxInc)
                            {
                                // 売上内税対象額
                                itdedSalesInTax += salesDetail.SalesMoneyTaxExc;

                                // 売上内税対象額（税込）
                                itdedSalesInTax_TaxInc += salesDetail.SalesMoneyTaxInc;

                                // 売上金額消費税額（内税）
                                salAmntConsTaxInclu += salesDetail.SalesPriceConsTax;

                                // 在庫商品合計金額（税抜）（内税商品分）
                                if (salesDetail.SalesOrderDivCd == (int)SalesSlipInputAcs.SalesOrderDivCd.Stock)
                                    stockGoodsTtlTaxExc_TaxInc += salesDetail.SalesMoneyTaxExc;

                                // 純正商品合計金額（税抜）（内税商品分）
                                if (salesDetail.GoodsKindCode == 0)
                                    pureGoodsTtlTaxExc_TaxInc += salesDetail.SalesMoneyTaxExc;

                            }
                            // 税区分：非課税
                            if (salesDetail.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxNone)
                            {
                                // 売上小計非課税対象額
                                salSubttlSubToTaxFre += salesDetail.SalesMoneyTaxInc;

                                // 在庫商品合計金額（税抜）（非課税商品分）
                                if (salesDetail.SalesOrderDivCd == (int)SalesSlipInputAcs.SalesOrderDivCd.Stock)
                                    stockGoodsTtlTaxExc_TaxNone += salesDetail.SalesMoneyTaxExc;

                                // 純正商品合計金額（税抜）（非課税商品分）
                                if (salesDetail.GoodsKindCode == 0)
                                    pureGoodsTtlTaxExc_TaxNone += salesDetail.SalesMoneyTaxExc;
                            }

                            // 売上部品小計（税込）
                            salesPrtSubttlInc += salesDetail.SalesMoneyTaxInc;
                            // 売上部品小計（税抜）
                            salesPrtSubttlExc += salesDetail.SalesMoneyTaxExc;

                            // 原価金額計
                            totalCost += salesDetail.Cost;

                            // 粗利計算用売上金額計（内税商品分）
                            if (salesDetail.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxInc)
                            {
                                totalMoney_TaxInc_ForGrossProfitMoney += salesDetail.SalesMoneyTaxInc;
                            }

                            // 粗利計算用売上金額計（外税商品分）
                            if (salesDetail.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxExc)
                            {
                                totalMoney_TaxExc_ForGrossProfitMoney += salesDetail.SalesMoneyTaxExc;
                            }

                            // 粗利計算用売上金額計（非課税商品分）
                            if (salesDetail.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxNone)
                            {
                                totalMoney_TaxNone_ForGrossProfitMoney += salesDetail.SalesMoneyTaxExc;
                            }

                            break;
                        }
                    // 値引き
                    case (int)SalesSlipInputAcs.SalesSlipCdDtl.Discount:
                        {
                            // 税区分：外税
                            if (salesDetail.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxExc)
                            {
                                // 売上値引外税対象額合計
                                itdedSalesDisOutTax += salesDetail.SalesMoneyTaxExc;
                                // 売上値引消費税額（外税）
                                salesDisOutTax += salesDetail.SalesPriceConsTax;

                                // 商品値引きの場合
                                if (salesDetail.ShipmentCnt != 0)
                                {
                                    // 在庫商品合計金額（税抜）（外税商品分）
                                    if (salesDetail.SalesOrderDivCd == (int)SalesSlipInputAcs.SalesOrderDivCd.Stock)
                                        stockGoodsTtlTaxExc_TaxExc += salesDetail.SalesMoneyTaxExc;

                                    // 純正商品合計金額（税抜）（外税商品分）
                                    if (salesDetail.GoodsKindCode == 0)
                                        pureGoodsTtlTaxExc_TaxExc += salesDetail.SalesMoneyTaxExc;
                                }
                            }
                            // 税区分：内税
                            if (salesDetail.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxInc)
                            {
                                // 売上値引内税対象額合計
                                itdedSalesDisInTax += salesDetail.SalesMoneyTaxExc;
                                // 売上値引内税対象額合計（税込）
                                itdedSalesDisInTax_TaxInc += salesDetail.SalesMoneyTaxInc;
                                // 売上値引消費税額（内税）
                                salesDisTtlTaxInclu += salesDetail.SalesPriceConsTax;

                                // 商品値引きの場合
                                if (salesDetail.ShipmentCnt != 0)
                                {
                                    // 在庫商品合計金額（税抜）（内税商品分）
                                    if (salesDetail.SalesOrderDivCd == (int)SalesSlipInputAcs.SalesOrderDivCd.Stock)
                                        stockGoodsTtlTaxExc_TaxInc += salesDetail.SalesMoneyTaxExc;

                                    // 純正商品合計金額（税抜）（内税商品分）
                                    if (salesDetail.GoodsKindCode == 0)
                                        pureGoodsTtlTaxExc_TaxInc += salesDetail.SalesMoneyTaxExc;
                                }
                            }
                            // 税区分：非課税
                            if (salesDetail.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxNone)
                            {
                                // 売上値引非課税対象額合計
                                itdedSalesDisTaxFre += salesDetail.SalesMoneyTaxInc;

                                // 商品値引きの場合
                                if (salesDetail.ShipmentCnt != 0)
                                {
                                    // 在庫商品合計金額（税抜）（非課税商品分）
                                    if (salesDetail.SalesOrderDivCd == (int)SalesSlipInputAcs.SalesOrderDivCd.Stock)
                                        stockGoodsTtlTaxExc_TaxNone += salesDetail.SalesMoneyTaxExc;

                                    // 純正商品合計金額（税抜）（非課税商品分）
                                    if (salesDetail.GoodsKindCode == 0)
                                        pureGoodsTtlTaxExc_TaxNone += salesDetail.SalesMoneyTaxExc;

                                }
                            }

                            // 部品値引対象額合計（税込）
                            itdedPartsDisInTax += salesDetail.SalesMoneyTaxInc;

                            // 部品値引対象額合計（税抜）
                            itdedPartsDisOutTax += salesDetail.SalesMoneyTaxExc;

                            // 原価金額計
                            totalCost += salesDetail.Cost;

                            // 粗利計算用売上金額計（内税商品分）
                            if (salesDetail.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxInc)
                            {
                                totalMoney_TaxInc_ForGrossProfitMoney += salesDetail.SalesMoneyTaxInc;
                            }

                            // 粗利計算用売上金額計（外税商品分）
                            if (salesDetail.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxExc)
                            {
                                totalMoney_TaxExc_ForGrossProfitMoney += salesDetail.SalesMoneyTaxExc;
                            }

                            // 粗利計算用売上金額計（非課税商品分）
                            if (salesDetail.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxNone)
                            {
                                totalMoney_TaxNone_ForGrossProfitMoney += salesDetail.SalesMoneyTaxExc;
                            }

                            break;
                        }
                    // 注釈
                    case (int)SalesSlipInputAcs.SalesSlipCdDtl.Annotation:
                        {
                            break;
                        }
                    // 作業
                    case (int)SalesSlipInputAcs.SalesSlipCdDtl.Work:
                        {
                            // 原価金額計
                            totalCost += salesDetail.Cost;

                            // 粗利計算用売上金額計（内税商品分）
                            if (salesDetail.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxInc)
                            {
                                totalMoney_TaxInc_ForGrossProfitMoney += salesDetail.SalesMoneyTaxInc;
                            }

                            // 粗利計算用売上金額計（外税商品分）
                            if (salesDetail.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxExc)
                            {
                                totalMoney_TaxExc_ForGrossProfitMoney += salesDetail.SalesMoneyTaxExc;
                            }

                            // 粗利計算用売上金額計（非課税商品分）
                            if (salesDetail.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxNone)
                            {
                                totalMoney_TaxNone_ForGrossProfitMoney += salesDetail.SalesMoneyTaxExc;
                            }
                            break;
                        }
                    // 小計
                    case (int)SalesSlipInputAcs.SalesSlipCdDtl.Subtotal:
                        {
                            break;
                        }
                }

                if (salesDetail.SalesSlipCdDtl != (int)SalesSlipInputAcs.SalesSlipCdDtl.Subtotal)
                {
                    // 残高調整額
                    if ((salesDetail.SalesGoodsCd == (int)SalesSlipInputAcs.SalesGoodsCd.BalanceAdjust) ||
                        (salesDetail.SalesGoodsCd == (int)SalesSlipInputAcs.SalesGoodsCd.AccRecBalanceAdjust))
                    {
                        balanceAdjust += salesDetail.SalesMoneyTaxInc;
                    }

                    // 消費税調整額
                    if ((salesDetail.SalesGoodsCd == (int)SalesSlipInputAcs.SalesGoodsCd.ConsTaxAdjust) ||
                        (salesDetail.SalesGoodsCd == (int)SalesSlipInputAcs.SalesGoodsCd.AccRecConsTaxAdjust))
                    {
                        taxAdjust += salesDetail.SalesPriceConsTax;
                    }
                }
            }

            // 売上値引金額計（税抜）
            salesDisTtlTaxExc = itdedSalesDisOutTax + itdedSalesDisInTax + itdedSalesDisTaxFre;

            // 粗利計算用売上金額計
            totalMoneyForGrossProfit = totalMoney_TaxExc_ForGrossProfitMoney + totalMoney_TaxInc_ForGrossProfitMoney + totalMoney_TaxNone_ForGrossProfitMoney;

            // 在庫商品合計金額（税抜）
            stockGoodsTtlTaxExc = stockGoodsTtlTaxExc_TaxInc + stockGoodsTtlTaxExc_TaxExc + stockGoodsTtlTaxExc_TaxNone;

            // 純正商品合計金額（税抜）
            pureGoodsTtlTaxExc = pureGoodsTtlTaxExc_TaxInc + pureGoodsTtlTaxExc_TaxExc + pureGoodsTtlTaxExc_TaxNone;

            #endregion

            #region ●転嫁方式：非課税の場合に金額を調整する
            //-----------------------------------------------------------------------------
            // 転嫁方式：非課税の場合に金額を調整する
            //-----------------------------------------------------------------------------
            if (consTaxLayMethod == 9)
            {
                // 売上金額消費税額（外税）
                salesOutTax = 0;

                // 売上金額消費税額（内税）
                salAmntConsTaxInclu = 0;

                // 売上小計非課税対象額
                salSubttlSubToTaxFre += itdedSalesOutTax + itdedSalesInTax;

                // 売上外税対象額
                itdedSalesOutTax = 0;

                // 売上内税対象額
                itdedSalesInTax = 0;

                // 売上内税対象額（税込）
                itdedSalesInTax_TaxInc = 0;

                // 売上値引消費税額（外税）
                salesDisOutTax = 0;

                // 売上値引消費税額（内税）
                salesDisTtlTaxInclu = 0;

                // 売上値引非課税対象額合計
                itdedSalesDisTaxFre += itdedSalesDisOutTax + itdedSalesDisInTax;

                // 売上値引外税対象額合計
                itdedSalesDisOutTax = 0;

                // 売上値引内税対象額合計
                itdedSalesDisInTax = 0;

                // 売上値引内税対象額合計（税込）
                itdedSalesDisInTax_TaxInc = 0;

                // 売上値引金額計（税抜）
                salesDisTtlTaxExc = itdedSalesDisOutTax + itdedSalesDisInTax + itdedSalesDisTaxFre;
            }
            #endregion

            #region ●各種金額算出
            //-----------------------------------------------------------------------------
            // 各種金額算出
            //-----------------------------------------------------------------------------

            // 明細転嫁以外
            if (consTaxLayMethod != 1)
            {
                //-----------------------------------------------------------------------------
                // ① 売上伝票合計（税抜）：売上外税対象額 + 売上内税対象額 + 売上値引外税対象額合計 + 売上値引内税対象額合計 + 売上値引非課税対象額合計
                //-----------------------------------------------------------------------------
                salesTotalTaxExc = itdedSalesOutTax + itdedSalesInTax + itdedSalesDisOutTax + itdedSalesDisInTax + itdedSalesDisTaxFre;

                //-----------------------------------------------------------------------------
                // ② 売上伝票合計（税込）： 売上内税対象額（税込） + 売上外税対象額 + 売上値引内税対象額合計（税込） + 売上値引外税対象額合計 + 売上値引非課税対象額合計 + (売上外税対象額 + 売上値引外税対象額合計)×税率)
                //-----------------------------------------------------------------------------
                salesTotalTaxInc = itdedSalesInTax_TaxInc + itdedSalesOutTax + itdedSalesDisInTax_TaxInc + itdedSalesDisOutTax + itdedSalesDisTaxFre + CalculateTax.GetTaxFromPriceExc(consTaxRate, taxFracProcUnit, taxFracProcCd, itdedSalesOutTax + itdedSalesDisOutTax);

                //-----------------------------------------------------------------------------
                // ③ 売上小計（税）：② - ①
                //-----------------------------------------------------------------------------
                salesSubtotalTax = salesTotalTaxInc - salesTotalTaxExc;

                //-----------------------------------------------------------------------------
                // ④ 売上金額消費税額（外税）：売上外税対象額 × 税率
                //-----------------------------------------------------------------------------
                salesOutTax = CalculateTax.GetTaxFromPriceExc(consTaxRate, taxFracProcUnit, taxFracProcCd, itdedSalesOutTax);

                //-----------------------------------------------------------------------------
                // ⑤ 売上金額消費税額（外税）(税抜、値引き含む) ：(売上外税対象額 + 売上値引外税対象額合計) × 税率
                //-----------------------------------------------------------------------------
                long salesOutTax_All = CalculateTax.GetTaxFromPriceExc(consTaxRate, taxFracProcUnit, taxFracProcCd, itdedSalesOutTax + itdedSalesDisOutTax);

                //-----------------------------------------------------------------------------
                // ⑥ 売上値引消費税額（外税）：④ - ⑤
                //-----------------------------------------------------------------------------
                salesDisOutTax = salesOutTax_All - salesOutTax;

                // 2009.03.25 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                //-----------------------------------------------------------------------------
                // ⑦ 売上部品小計（税込）：(売上部品小計（税抜）+ 部品値引対象額合計（税抜）) × 税率
                //-----------------------------------------------------------------------------
                salesPrtSubttlInc = salesPrtSubttlExc + itdedPartsDisOutTax + CalculateTax.GetTaxFromPriceExc(consTaxRate, taxFracProcUnit, taxFracProcCd, salesPrtSubttlExc + itdedPartsDisOutTax);

                //-----------------------------------------------------------------------------
                // ⑧ 部品値引対象額合計（税込）：部品値引対象額合計（税抜）× 税率
                //-----------------------------------------------------------------------------
                itdedPartsDisInTax = itdedPartsDisOutTax + CalculateTax.GetTaxFromPriceExc(consTaxRate, taxFracProcUnit, taxFracProcCd, itdedPartsDisOutTax);
                // 2009.03.25 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            }
            // 明細転嫁
            else
            {
                //-----------------------------------------------------------------------------
                // ① 売上小計（税）：売上金額消費税額（外税） + 売上金額消費税額（内税） +  売上値引消費税額（外税） + 売上値引消費税額（内税）
                //-----------------------------------------------------------------------------
                salesSubtotalTax = salesOutTax + salAmntConsTaxInclu + salesDisOutTax + salesDisTtlTaxInclu;

                //-----------------------------------------------------------------------------
                // ② 売上伝票合計（税抜）：売上外税対象額 + 売上内税対象額 + 売上値引外税対象額合計 + 売上値引内税対象額合計
                //-----------------------------------------------------------------------------
                salesTotalTaxExc = itdedSalesOutTax + itdedSalesInTax + itdedSalesDisOutTax + itdedSalesDisInTax;

                //-----------------------------------------------------------------------------
                // ③ 売上伝票合計（税込）：① + ②
                //-----------------------------------------------------------------------------
                salesTotalTaxInc = salesTotalTaxExc + salesSubtotalTax;
            }
            #endregion

            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了");
        }

        #endregion // </売上データの算出関連>
    }
    // ADD 2013/08/19 吉岡  Redmine#39992 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
}
