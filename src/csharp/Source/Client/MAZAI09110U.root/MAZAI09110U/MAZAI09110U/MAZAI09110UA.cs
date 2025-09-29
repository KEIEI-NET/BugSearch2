//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : 在庫管理全体設定
// プログラム概要   : 在庫管理全体設定の設定を行います。
//----------------------------------------------------------------------------//
//                (c)Copyright  2007 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30005 木建　翼
// 作 成 日  2007/03/01  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 22022 段上　知子
// 修 正 日  2007/03/27  修正内容 : 1.フォーカス移動の障害対応
//                                  2.プルダウン項目色設定
//                                  3.ボタンアイコン設定
//                                  4.端数処理区分追加
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 20081 疋田　勇人
// 作 成 日  2007/08/20  修正内容 : DC.NS用に変更
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30415 柴田 倫幸
// 作 成 日  2008/06/04  修正内容 : データ項目の追加/削除による修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30415 柴田 倫幸
// 作 成 日  2008/07/03  修正内容 : 端数処理区分追加による修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30415 柴田 倫幸
// 作 成 日  2008/08/28  修正内容 : 棚卸印刷順初期設定区分にグループコード順追加
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 作 成 日  2008/09/29  修正内容 : バグ修正、仕様変更対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 上野 俊治
// 作 成 日  2008/12/01  修正内容 : 在庫移動確定区分を削除、グリッド列表示順を修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 徳永 俊詞
// 作 成 日  2008/12/04  修正内容 : TAB表示順を修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 宮津 銀次郎
// 作 成 日  2008/12/10  修正内容 : 拠点0の時の在庫評価方法を一時的に変更可→変更不可へ
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 作 成 日  2009/06/03  修正内容 : 在庫移動確定区分を追加(復活)
//----------------------------------------------------------------------------//
// 管理番号                 作成担当：朱俊成
// 修正日    2009/12/02     修正内容：PM.NS-4・保守依頼③
//                                    棚卸運用区分を追加
//----------------------------------------------------------------------------//
// 管理番号  10704766-00    作成担当：周雨
// 修正日    2011/08/29     修正内容：「現在庫表示区分」を画面に追加　
//----------------------------------------------------------------------------//
// 管理番号  10704766-00    作成担当：田建委
// 修正日    2011/09/08     修正内容：障害報告 #24169　拠点設定を行おうと拠点ガイドをすると全社共通の編集を行おうとしてしまう。
//　　　　　　　　　　　　　　　　　　　　　　　　　　 拠点コードと拠点ガイドのフォーカス移動はメッセージ表示を行わないように修正
//----------------------------------------------------------------------------//
// 管理番号  10801804-00    作成担当：lanl
// 修正日    2012/06/08     修正内容：2012/06/27配信分、Redmine#30282
//                                   「棚卸データ削除区分」を画面に追加
//----------------------------------------------------------------------------//
// 管理番号  10801804-00    作成担当：三戸　伸悟
// 修正日    2012/07/02     修正内容：「移動時在庫自動登録区分」を画面に追加
//----------------------------------------------------------------------------//
// 管理番号  11070149-00    作成担当: wangf
// 作 成 日  2014/10/27     修正内容: Redmine#43854画面に列「移動伝票出力先区分」追加
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Reflection;                        // ADD 2008/09/19 不具合対応による共通仕様の展開
using System.Text;
using System.Windows.Forms;

using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Controller.Util;    // ADD 2008/09/19 不具合対応による共通仕様の展開
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 在庫管理全体設定フォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 在庫管理全体設定の設定を行います。</br>
    /// <br>Programmer : 30005 木建　翼</br>
    /// <br>Date       : 2007.03.01</br>
    /// <br>Update Note: 2007.03.27 22022 段上　知子</br>
    /// <br>                        1.フォーカス移動の障害対応</br>
    /// <br>                        2.プルダウン項目色設定</br>
    /// <br>                        3.ボタンアイコン設定</br>
    /// <br>                        4.端数処理区分追加</br>
    ///-----------------------------------------------------------------
    /// <br>Update Note: 2007.08.20 20081 疋田　勇人</br>
    /// <br>                        1.DC.NS用に変更</br>
    /// <br>UpdateNote : 2008/06/04 30415 柴田 倫幸</br>
    /// <br>        	 ・データ項目の追加/削除による修正</br>
    /// <br>UpdateNote : 2008/07/03 30415 柴田 倫幸</br>
    /// <br>        	 ・端数処理区分追加による修正</br>   
    /// <br>UpdateNote : 2008/08/28 30415 柴田 倫幸</br>
    /// <br>        	 ・棚卸印刷順初期設定区分にグループコード順追加</br>   
    /// <br>UpdateNote : 2008/09/29       照田 貴志</br>
    /// <br>        	 ・バグ修正、仕様変更対応</br>   
    /// <br>UpdateNote : 2008/12/01       上野 俊治</br>
    /// <br>        	 ・在庫移動確定区分を削除、グリッド列表示順を修正</br>   
    /// <br>UpdateNote : 2008/12/04       徳永 俊詞</br>
    /// <br>        	 ・TAB表示順を修正</br>   
    /// <br>UpdateNote : 2008/12/10       宮津 銀次郎</br>
    /// <br>        	 ・拠点0の時の在庫評価方法を一時的に変更可→変更不可へ</br>   
    /// <br>UpdateNote : 2009/06/03       照田 貴志</br>
    /// <br>        	 ・在庫移動確定区分を追加(復活)</br>
    /// <br>Update Note: 2009/12/02 朱俊成</br>
    /// <br>             PM.NS-4・保守依頼③</br>
    /// <br>             棚卸運用区分を追加</br>
    /// <br>Update Note: 2011/08/29 周雨</br>
    /// <br>             連番 1016 「現在庫表示区分」を画面に追加　</br>
    /// <br>Update Note: 2011/09/08 田建委</br>
    /// <br>             障害報告 #24169 全社共通の編集　</br>
    /// <br>Update Note: 2012/06/08 lanl</br>
    /// <br>             Redmine#30282 「棚卸データ削除区分」を画面に追加　</br>
    /// <br>Update Note: 2012/07/02 三戸　伸悟</br>
    /// <br>             「移動時在庫自動登録区分」を画面に追加　</br>
    /// <br>Update Note: 2014/10/27 wangf </br>
    /// <br>           : Redmine#43854画面に列「移動伝票出力先区分」追加</br>
    /// </remarks>
    public partial class MAZAI09110UA : System.Windows.Forms.Form, IMasterMaintenanceMultiType
    {
        #region Private Members

        // --- ADD 2008/06/04 -------------------------------->>>>>
        private const string GUID_TITLE = "GUID";
        private const string STOCKMNGTTLST_TABLE = "STOCKMNGTTLST"; // テーブル名

        // FrameのView用Grid列のKEY情報（ヘッダのタイトル部となります。）
        private const string DELETE_DATE       = "削除日";
        /* ---DEL 2008/09/29 タイトル変更の為 ---------->>>>>
        private const string SECTIONCODE_TITLE = "コード";
        private const string SECTIONNAME_TITLE = "拠点名称";
           ---DEL 2008/09/29 ---------------------------<<<<< */
        // ---ADD 2008/09/29 --------------------------->>>>>
        private const string SECTIONCODE_TITLE = "拠点";
        private const string SECTIONNAME_TITLE = "拠点名";
        // ---ADD 2008/09/29 ---------------------------<<<<<
        // --- DEL 2008/12/01 -------------------------------->>>>>
        //private const string STOCKMOVEFIXCODE_TITLE     = "在庫移動確定区分";
        // --- DEL 2008/12/01 --------------------------------<<<<<
        private const string STOCKMOVEFIXCODE_TITLE = "在庫移動確定区分";       //ADD(復活) 2009/06/03
        // DEL 2009/01/16 不具合対応[10151]↓
        //private const string STOCKTOLERNCSHIPMDIV_TITLE = "在庫切れ出荷区分";
        private const string INVNTRYPRTODRINIDIV_TITLE  = "棚卸印刷順初期設定区分";
        private const string STOCKPOINTWAY_TITLE        = "在庫評価方法";
        private const string MAXSTKCNTOVERODERDIV_TITLE = "最高在庫数超え発注区分";
        private const string SHELFNODUPLDIV_TITLE       = "棚番重複区分";
        private const string LOTUSEDIVCD_TITLE          = "ロット使用区分";
        private const string SECTDSPDIVCD_TITLE         = "拠点表示区分";
        private const string FRACTIONPROCCD_TITLE       = "端数処理区分";  // ADD 2008/07/03
        // --- ADD 2009/12/02 ---------->>>>>
        // 棚卸運用区分
        private const string INVENTORYMNGDIV_TITLE = "棚卸運用区分";
        // --- ADD 2009/12/02 ----------<<<<<
        // ------------- ADD 2011/08/29 ---------------- >>>>>
        // 現在庫表示区分
        private const string STOCKDISPLAYDIV_TITLE = "現在庫表示区分";
        // ------------- ADD 2011/08/29 ---------------- <<<<<
        // ------------- ADD lanl 2012/06/08 Redmine#30282 ---------------- >>>>>
        // 棚卸データ削除区分
        private const string INVNTRYDTDELDIV_TITLE = "棚卸データ削除区分";
        // ------------- ADD lanl 2012/06/08 Redmine#30282 ---------------- <<<<<
        // --- ADD 三戸 2012/07/02 ---------->>>>>
        // 移動時在庫自動登録区分
        private const string MOVESTOCKAUTOINSDIV_TITLE = "移動時在庫自動登録区分";
        // --- ADD 三戸 2012/07/02 ----------<<<<<
        // ------------ADD wangf 2014/10/27 FOR Redmine#43854 列「移動伝票出力先区分」追加 列「移動伝票出力先区分」追加--------->>>>
        // 移動伝票出力先区分
        private const string MOVESLIPOUTPUTDIV_TITLE = "移動伝票出力先区分";
        // ------------ADD wangf 2014/10/27 FOR Redmine#43854 列「移動伝票出力先区分」追加 列「移動伝票出力先区分」追加---------<<<<

        // 未設定時に使用
        private const string UNREGISTER = "";

        // 在庫移動確定区分
        // ---DEL 2009/06/03 ---------->>>>>
        //// ADD 2008/09/16 不具合対応[5130] ---------->>>>>
        ///// <summary>
        ///// 在庫移動確定区分の列挙体
        ///// </summary>
        //private enum StockMoveFixCode : int
        //{
        //    /// <summary>なし</summary>
        //    None = 0,
        //    /// <summary>出荷確定あり</summary>
        //    Yes = 1,
        //    /// <summary>出荷確定なし</summary>
        //    No = 2
        //}
        //// ADD 2008/09/16 不具合対応[5130] ----------<<<<<
        //private const string STOCKMOVEFIXCODE_YES = "出荷確定あり";
        //private const string STOCKMOVEFIXCODE_NO  = "出荷確定なし";
        // ---DEL 2009/06/03 ----------<<<<<
        // ---ADD 2009/06/03 ---------->>>>>
        /// <summary>
        /// 在庫移動確定区分の列挙体
        /// </summary>
        private enum StockMoveFixCode : int
        {
            /// <summary>なし</summary>
            None = 0,
            /// <summary>入荷確定あり</summary>
            Yes = 1,
            /// <summary>入荷確定なし</summary>
            No = 2
        }
        private const string STOCKMOVEFIXCODE_YES = "入荷確定あり";
        private const string STOCKMOVEFIXCODE_NO = "入荷確定なし";
        // ---ADD 2009/06/03 ----------<<<<<

        // 在庫切れ出荷区分
        private const string STOCKTOLERNCSHIPMDIV_NONE    = "無し";
        private const string STOCKTOLERNCSHIPMDIV_WARNING = "警告";
        private const string STOCKTOLERNCSHIPMDIV_BOTH    = "警告＋再入力";
        private const string STOCKTOLERNCSHIPMDIV_AGAIN   = "再入力";

        // 棚卸印刷順初期設定区分
        private const string INVNTRYPRTODRINIDIV_SHELF      = "棚番順";
        private const string INVNTRYPRTODRINIDIV_STOCKING   = "仕入先順";
        private const string INVNTRYPRTODRINIDIV_BL         = "BLコード順";
        private const string INVNTRYPRTODRINIDIV_GROUP      = "グループコード順";  // ADD 2008/08/28 
        private const string INVNTRYPRTODRINIDIV_MAKER      = "メーカー順";
        private const string INVNTRYPRTODRINIDIV_STOCKBL    = "仕入先・棚番順";
        private const string INVNTRYPRTODRINIDIV_STOCKMAKER = "仕入先・メーカー順";

        // 在庫評価方法
        // ADD 2008/09/16 不具合対応[5130] ---------->>>>>
        /// <summary>
        /// 在庫評価方法の列挙体
        /// </summary>
        private enum StockPointWay : int
        {
            /// <summary>なし</summary>
            None = 0,
            /// <summary>最終仕入原価法</summary>
            Last = 1,
            /// <summary>移動平均法</summary>
            Move = 2
        }
        // ADD 2008/09/16 不具合対応[5130] ----------<<<<<
        private const string STOCKPOINTWAY_LAST = "最終仕入原価法";
        private const string STOCKPOINTWAY_MOVE = "移動平均法";

        // 最高在庫数超え発注区分
        private const string MAXSTKCNTOVERODERDIV_NO = "しない";
        private const string MAXSTKCNTOVERODERDIV_YES = "する";

        // 棚番重複区分
        private const string SHELFNODUPLDIV_POSS   = "可能";
        private const string SHELFNODUPLDIV_IMPOSS = "不可";

        // ロット使用区分
        private const string LOTUSEDIVCD_ORDER     = "発注ロット";
        private const string LOTUSEDIVCD_CIRCULATE = "流通ロット";

        // 拠点表示区分
        private const string SECTDSPDIVCD_STORAGE  = "倉庫マスタ";
        private const string SECTDSPDIVCD_OWN      = "自社マスタ";
        private const string SECTDSPDIVCD_NONE     = "表示無し";

        // --- ADD 2008/07/03 -------------------------------->>>>>
        // 端数処理区分
        // ADD 2008/09/16 不具合対応[5130] ---------->>>>>
        /// <summary>
        /// 端数処理区分の列挙体
        /// </summary>
        private enum FractionProcCd : int
        {
            /// <summary>なし</summary>
            None = 0,
            /// <summary>切捨て</summary>
            Cut = 1,
            /// <summary>四捨五入</summary>
            Round = 2,
            /// <summary>切上げ</summary>
            Revaluation = 3
        }
        // ADD 2008/09/16 不具合対応[5130] ----------<<<<<
        private const string FRACTIONPROCCD_CUT         = "切捨て";
        private const string FRACTIONPROCCD_ROUND       = "四捨五入";
        private const string FRACTIONPROCCD_REVALUATION = "切上げ";
        // --- ADD 2008/07/03 --------------------------------<<<<< 


        // --- ADD 2009/12/02 ---------->>>>>
        /// <summary>
        /// 棚卸運用区分の列挙体
        /// </summary>
        private enum InventoryMngDiv : int
        {
            /// <summary>ＰＭ．ＮＳ</summary>
            Pmns = 0,
            /// <summary>ＰＭ７</summary>
            Pm7 = 1,
        }
        private const string INVENTORYMNGDIV_PMNS = "ＰＭ．ＮＳ";
        private const string INVENTORYMNGDIV_PM7 = "ＰＭ７";
        // --- ADD 2009/12/02 ----------<<<<<

        // -------------- ADD 2011/08/29 ----------------- >>>>>
        /// <summary>
        /// 現在庫表示区分の列挙体
        /// </summary>
        private enum StockDisplayDiv : int
        {
            /// <summary>受注分含む</summary>
            Yes = 0,
            /// <summary>受注分含まない</summary>
            No = 1,
        }
        private const string STOCKDISPLAYDIV_YES = "受注分含む";
        private const string STOCKDISPLAYDIV_NO = "受注分含まない";
        // -------------- ADD 2011/08/29 ----------------- <<<<<
        // -------------- ADD lanl 2012/06/08 Redmine#30282 ----------------- >>>>>
        /// <summary>
        /// 棚卸データ削除区分の列挙体
        /// </summary>
        private enum InvntryDtDelDiv : int
        {
            /// <summary>可能</summary>
            Pos = 0,
            /// <summary>可能(拠点指定可能)</summary>
            PosSec = 1,
            /// <summary>不可</summary>
            ImPos = 2
        }
        private const string INVNTRYDTDELDIV_POS = "可能";
        private const string INVNTRYDTDELDIV_POSSEC = "可能(拠点指定可能)";
        private const string INVNTRYDTDELDIV_IMPOS = "不可";
        // -------------- ADD lanl 2012/06/08 Redmine#30282 ----------------- <<<<<
        // --- ADD 三戸 2012/07/02 ---------->>>>>
        /// <summary>
        /// 移動時在庫自動登録区分
        /// </summary>
        private enum MoveStockAutoInsDiv : int
        {
            /// <summary>する</summary>
            Yes = 0,
            /// <summary>しない</summary>
            No = 1
        }
        private const string MOVESTOCKAUTOINSDIV_YES = "する";
        private const string MOVESTOCKAUTOINSDIV_NO = "しない";
        // --- ADD 三戸 2012/07/02 ----------<<<<<
        // ------------ADD wangf 2014/10/27 FOR Redmine#43854 列「移動伝票出力先区分」追加--------->>>>
        /// <summary>
        /// 移動伝票出力先区分
        /// </summary>
        private enum MoveSlipOutPutDiv : int
        {
            /// <summary>入庫倉庫</summary>
            In = 0,
            /// <summary>出庫倉庫</summary>
            Out = 1
        }
        private const string MOVESLIPOUTPUTDIV_IN = "入庫倉庫";
        private const string MOVESLIPOUTPUTDIV_OUT = "出庫倉庫";
        // ------------ADD wangf 2014/10/27 FOR Redmine#43854 列「移動伝票出力先区分」追加---------<<<<
        // 編集モード
        private const string INSERT_MODE = "新規モード";
        private const string UPDATE_MODE = "更新モード";
        private const string DELETE_MODE = "削除モード";

        private Hashtable _stockMngTtlStTable;				        // 在庫管理全体設定テーブル

        // プロパティ用
        private bool _canDelete;
        private bool _canLogicalDeleteDataExtraction;
        private bool _canNew;
        private bool _canSpecificationSearch;
        private int _dataIndex;
        private bool _defaultAutoFillToColumn;

        // _GridIndexバッファ（メインフレーム最小化対応）
        private int _indexBuf;

        private int _logicalDeleteMode;					// モード
        // --- ADD 2008/06/04 --------------------------------<<<<< 

        private string _enterpriseCode;

        // 2009.03.25 30413 犬飼 新規モードからモード変更対応 >>>>>>START
        // モードフラグ(true：コード、false：コード以外)
        private bool _modeFlg = false;
        // 2009.03.25 30413 犬飼 新規モードからモード変更対応 <<<<<<END

        private StockMngTtlStAcs _stockMngTtlStAcs;				    // 在庫管理全体設定アクセスクラス
        private SecInfoAcs _secInfoAcs;                             // 拠点マスタアクセスクラス
        //private StockMngTtlSt _stockMngTtlSt;					    // 在庫管理全体設定データクラス
        private StockMngTtlSt _stockMngTtlStClone;				    // 比較用在庫管理全体設定クローンクラス

        /// <summary>全社設定の在庫管理全体設定オブジェクト</summary>
        /// <remarks>Search時に初期化されます。</remarks>
        private StockMngTtlSt _stockMngTtlStOfAllSection;           // ADD 2008/09/16 不具合対応[5130]

        // コード参照変更フラグ
        //private bool _changeFlg;

        // プロパティ用
        private bool _canPrint;
        private bool _canClose;

        // 編集モード
        //private const string UPDATE_MODE = "更新モード";  // DEL 2008/06/04

        private const string HTML_HEADER_TITLE = "設定項目";
        private const string HTML_HEADER_VALUE = "設定値";
        private const string HTML_UNREGISTER = "未設定";

        // 表示項目数
        // 2007.08.20 upd start ---------------->>
        //private const int DisplayCount = 7;  // DEL 2008/06/04
        // 2007.03.27 DANJO CHG START
        //private const int DisplayCount = 9;
        // 2007.08.20 upd end ------------------<<
        //private const int DisplayCount = 8;
        // 2007.03.27 DANJO CHG END

        private bool isError = false; // ADD 2011/09/08

        private const int DisplayCount = 11;  // ADD 2008/06/04

        // 在庫管理全体設定管理コードデフォルト値
        private const int STOCKMNGTTLSTCODE_DEFAULT = 0;

        // ADD 2008/09/19 不具合対応による共通仕様の展開 ---------->>>>>
        /// <summary>拠点ガイドの制御オブジェクト</summary>
        private readonly GeneralGuideUIController _sectionGuideController;
        /// <summary>
        /// 拠点ガイドの制御オブジェクトを取得します。
        /// </summary>
        /// <value>拠点ガイドの制御オブジェクト</value>
        private GeneralGuideUIController SectionGuideController
        {
            get { return _sectionGuideController; }
        }
        // ADD 2008/09/19 不具合対応による共通仕様の展開 ----------<<<<<

        #endregion

        #region Constructor

        /// <summary>
        /// 在庫管理全体設定フォームクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 在庫管理全体設定フォームクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 30005 木建　翼</br>
        /// <br>Date       : 2007.03.01</br>
        /// </remarks>
        public MAZAI09110UA()
        {
            InitializeComponent();

            // データセット列情報構築処理
            DataSetColumnConstruction();  // ADD 2008/06/04

            // 企業コード取得
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            // 伝票初期値設定アクセスクラスインスタンス化
            this._stockMngTtlStAcs = new StockMngTtlStAcs();

            // 比較用クローン
            this._stockMngTtlStClone = null;
      
            // コード参照変更フラグ
            //this._changeFlg = false;

            // プロパティの初期設定
            this._canPrint = false;
            this._canClose = false;

            // --- ADD 2008/06/04 -------------------------------->>>>>
            this._canDelete = true;		                     // 削除機能
            this._canLogicalDeleteDataExtraction = true;	 // 論理削除データ表示機能
            this._canNew = true;		                     // 新規作成機能
            this._canSpecificationSearch = false;	         // 件数指定検索機能
            this._defaultAutoFillToColumn = false;	         // 列サイズ自動調整機能

            this._dataIndex = -1;
            this._logicalDeleteMode = 0;
            this._stockMngTtlStAcs = new StockMngTtlStAcs();
            this._stockMngTtlStTable = new Hashtable();
            this._secInfoAcs         = new SecInfoAcs(1);

            // _GridIndexバッファ（メインフレーム最小化対応）
            this._indexBuf = -2;
            // --- ADD 2008/06/04 --------------------------------<<<<<

            // ADD 2008/09/19 不具合対応による共通仕様の展開 ---------->>>>>
            // 拠点ガイドのフォーカス制御     
            _sectionGuideController = new GeneralGuideUIController(
                this.tEdit_SectionCodeAllowZero2,
                this.SectionGd_ultraButton,
                this.ShelfNoDuplDiv_tComboEditor
            );
            // ADD 2008/09/19 不具合対応による共通仕様の展開 ----------<<<<<
        }

        #endregion

        #region Main
        
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            System.Windows.Forms.Application.Run(new MAZAI09110UA());
        }
        
        #endregion

        /* --- DEL 2008/06/04 -------------------------------->>>>>
        # region Events
        
        /// <summary>
        /// 画面非表示イベント
        /// </summary>
        /// <remarks>
        /// 画面が非表示状態になった際に発生します。
        /// </remarks>
        public event MasterMaintenanceSingleTypeUnDisplayingEventHandler UnDisplaying;
        
        # endregion
           --- DEL 2008/06/04 --------------------------------<<<<< */

        #region Events
        /// <summary>画面非表示イベント</summary>
        /// <remarks>画面が非表示状態になった時に発生します。</remarks>
        public event MasterMaintenanceMultiTypeUnDisplayingEventHandler UnDisplaying;
        #endregion

        #region Properties

        /// <summary>論理削除データ抽出可能設定プロパティ</summary>
        /// <value>論理削除データの抽出が可能かどうかの設定を取得します。</value>
        public bool CanLogicalDeleteDataExtraction
        {
            get
            {
                return this._canLogicalDeleteDataExtraction;
            }
        }

        /// <summary>新規作成可能設定プロパティ</summary>
        /// <value>新規作成が可能かどうかの設定を取得します。</value>
        public bool CanNew
        {
            get
            {
                return this._canNew;
            }
        }

        /// <summary>削除可能設定プロパティ</summary>
        /// <value>削除が可能かどうかの設定を取得します。</value>
        public bool CanDelete
        {
            get
            {
                return this._canDelete;
            }
        }

        /// <summary>件数指定抽出可能設定プロパティ</summary>
        /// <value>件数指定抽出が可能かどうかの設定を取得します。</value>
        public bool CanSpecificationSearch
        {
            get
            {
                return this._canSpecificationSearch;
            }
        }

        /// <summary>列のサイズの自動調整のデフォルト値プロパティ</summary>
        /// <value>列のサイズの自動調整チェックボックスのチェック有無のデフォルト値を取得します。</value>
        public bool DefaultAutoFillToColumn
        {
            get
            {
                return this._defaultAutoFillToColumn;
            }
        }

        /// <summary>データセットの選択データインデックスプロパティ</summary>
        /// <value>データセットの選択データインデックスを取得または設定します。</value>
        public int DataIndex
        {
            get
            {
                return this._dataIndex;
            }
            set
            {
                this._dataIndex = value;
            }
        }

        /// <summary>
        /// 印刷プロパティ
        /// </summary>
        /// <remarks>
        /// 印刷可能かどうかの設定を取得します。（false固定）
        /// </remarks>
        public bool CanPrint
        {
            get { return _canPrint; }
        }

        /// <summary>
        /// 画面クローズプロパティ
        /// </summary>
        /// <remarks>
        /// 画面クローズを許可するかどうかの設定を取得または設定します。
        /// falseの場合は、画面を閉じる際、CloseではなくHide(非表示)を実行します。
        /// </remarks>
        public bool CanClose
        {
            get { return _canClose; }
            set { _canClose = value; }
        }

        // ADD 2008/09/16 不具合対応[5130] ---------->>>>>
        /// <summary>
        /// 全社設定の在庫管理全体設定オブジェクトを取得します。
        /// </summary>
        /// <value>全社設定の在庫管理全体設定オブジェクト</value>
        /// <remarks>
        /// <br>Note       : 不具合対応[5130]にて追加</br>
        /// <br>Programmer : 30434 工藤 恵優</br>
        /// <br>Date       : 2008/09/16</br>
        /// </remarks>
        private StockMngTtlSt StockMngTtlStOfAllSection
        {
            get { return _stockMngTtlStOfAllSection ?? new StockMngTtlSt(); }
            set { _stockMngTtlStOfAllSection = value; }
        }
        // ADD 2008/09/16 不具合対応[5130] ----------<<<<<

        #endregion

        #region Public Methods
        
        /// <summary>
        /// 印刷処理
        /// </summary>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 未実装</br>
        /// <br>Programmer : 23001 秋山　亮介</br>
        /// <br>Date       : 2005.12.22</br>
        /// </remarks>
        public int Print()
        {
            // 印刷アセンブリをロードする（未実装）
            return 0;
        }

        /// <summary>
        /// バインドデータセット取得処理
        /// </summary>
        /// <param name="bindDataSet">グリッド用データセット</param>
        /// <param name="tableName">テーブル名</param>
        /// <remarks>
        /// <br>Note       : グリッドにバインドさせるデータセットを取得します。</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/04</br>
        /// </remarks>
        public void GetBindDataSet(ref DataSet bindDataSet, ref string tableName)
        {
            bindDataSet = this.Bind_DataSet;
            tableName = STOCKMNGTTLST_TABLE;
        }

        /// <summary>
        /// データ検索処理
        /// </summary>
        /// <param name="totalCnt">全該当件数</param>
        /// <param name="readCnt">抽出対象件数</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : データを検索し、抽出結果を展開したデータセットと全該当件数を返します。</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/04</br>
        /// </remarks>
        public int Search(ref int totalCnt, int readCnt)
        {
            return SearchStockMngTtlSt(ref totalCnt, readCnt);
        }

        /// <summary>
        /// ネクストデータ検索処理
        /// </summary>
        /// <param name="readCnt">抽出対象件数</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 指定件数分のネクストデータを検索します。</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/04</br>
        /// </remarks>
        public int SearchNext(int readCnt)
        {
            // 未実装
            return (int)ConstantManagement.DB_Status.ctDB_EOF;
        }

        /// <summary>
        /// データ削除処理
        /// </summary>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 選択中のデータを削除します。</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/04</br>
        /// </remarks>
        public int Delete()
        {
            return LogicalDelete();
        }

        /// <summary>
        /// グリッド列外観情報取得処理
        /// </summary>
        /// <returns>グリッド列外観情報格納Hashtable</returns>
        /// <remarks>
        /// <br>Note       : グリッドの各列の外見を設定するクラスを格納したHashtableを取得します。</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/04</br>
        /// <br>Update Note: 2009/12/02 朱俊成 棚卸運用区分の追加</br>
        /// <br>Update Note: 2012/06/08 lanl</br>
        /// <br>             Redmine#30282「棚卸データ削除区分」を画面に追加</br>
        /// <br>Update Note: 2012/07/02 三戸　伸悟</br>
        /// <br>             「移動時在庫自動登録区分」を画面に追加　</br>
        /// <br>Update Note: 2014/10/27 wangf </br>
        /// <br>           : Redmine#43854画面に列「移動伝票出力先区分」追加</br>
        /// </remarks>
        public Hashtable GetAppearanceTable()
        {
            Hashtable appearanceTable = new Hashtable();

            // 削除日
            appearanceTable.Add(DELETE_DATE,
                new GridColAppearance(MGridColDispType.DeletionDataBoth,
                ContentAlignment.MiddleLeft, "", Color.Red));
            // 拠点コード
            appearanceTable.Add(SECTIONCODE_TITLE,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleLeft, "", Color.Black));
            // 拠点名称
            appearanceTable.Add(SECTIONNAME_TITLE,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleLeft, "", Color.Black));

            // --- DEL 2008/12/01 -------------------------------->>>>>
            //// 在庫移動確定区分
            //appearanceTable.Add(STOCKMOVEFIXCODE_TITLE,
            //    new GridColAppearance(MGridColDispType.Both,
            //    ContentAlignment.MiddleLeft, "", Color.Black));
            // --- DEL 2008/12/01 --------------------------------<<<<<

            // 在庫切れ出荷区分
            // DEL 2009/01/16 不具合対応[10151]↓
            //appearanceTable.Add(STOCKTOLERNCSHIPMDIV_TITLE,
            //    new GridColAppearance(MGridColDispType.Both,
            //    ContentAlignment.MiddleLeft, "", Color.Black));


            // 棚卸印刷順初期設定区分
            appearanceTable.Add(INVNTRYPRTODRINIDIV_TITLE,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleLeft, "", Color.Black));

            // 在庫評価方法
            appearanceTable.Add(STOCKPOINTWAY_TITLE,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleLeft, "", Color.Black));

            // 最高在庫数超え発注区分
            appearanceTable.Add(MAXSTKCNTOVERODERDIV_TITLE,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleLeft, "", Color.Black));

            // 棚番重複区分
            appearanceTable.Add(SHELFNODUPLDIV_TITLE,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleLeft, "", Color.Black));

            // ロット使用区分
            appearanceTable.Add(LOTUSEDIVCD_TITLE,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleLeft, "", Color.Black));

            // 拠点表示区分
            appearanceTable.Add(SECTDSPDIVCD_TITLE,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleLeft, "", Color.Black));

            // --- ADD 2008/07/03 -------------------------------->>>>>
            // 端数処理区分
            appearanceTable.Add(FRACTIONPROCCD_TITLE,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleLeft, "", Color.Black));
            // --- ADD 2008/07/03 --------------------------------<<<<< 

            // --- ADD 2009/12/02 ---------->>>>>
            // 棚卸運用区分
            appearanceTable.Add(INVENTORYMNGDIV_TITLE,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleLeft, "", Color.Black));
            // --- ADD 2009/12/02 ----------<<<<<

            // ------------- ADD 2011/08/29 -------------- >>>>>
            // 現在庫表示区分
            appearanceTable.Add(STOCKDISPLAYDIV_TITLE,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleLeft, "", Color.Black));
            // ------------- ADD 2011/08/29 -------------- <<<<<


            // ------------- ADD lanl 2012/06/08 Redmine#30282 -------------- >>>>>
            // 棚卸データ削除区分
            appearanceTable.Add(INVNTRYDTDELDIV_TITLE,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleLeft, "", Color.Black));
            // ------------- ADD lanl 2012/06/08 Redmine#30282 -------------- <<<<<

            // --- ADD 三戸 2012/07/02 ---------->>>>>
            // 移動時在庫自動登録区分
            appearanceTable.Add(MOVESTOCKAUTOINSDIV_TITLE,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleLeft, "", Color.Black));
            // --- ADD 三戸 2012/07/02 ----------<<<<<
            // ------------ADD wangf 2014/10/27 FOR Redmine#43854 列「移動伝票出力先区分」追加--------->>>>
            // 移動伝票出力先区分
            appearanceTable.Add(MOVESLIPOUTPUTDIV_TITLE,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleLeft, "", Color.Black));
            // ------------ADD wangf 2014/10/27 FOR Redmine#43854 列「移動伝票出力先区分」追加---------<<<<

            // ---ADD(復活) 2009/06/03 -------------------------------->>>>>
            // 在庫移動確定区分
            appearanceTable.Add(STOCKMOVEFIXCODE_TITLE,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleLeft, "", Color.Black));
            // ---ADD(復活) 2009/06/03 --------------------------------<<<<<

            // GUID
            appearanceTable.Add(GUID_TITLE,
                new GridColAppearance(MGridColDispType.None,
                ContentAlignment.MiddleLeft, "", Color.Black));


            return appearanceTable;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// フォームクローズ処理
        /// </summary>
        /// <param name="dialogResult">ダイアログ結果</param>
        /// <remarks>
        /// <br>Note       : フォームを閉じます。その際画面クローズイベント等の発生を行います。</br>
        /// <br>Programmer : 30005 木建　翼</br>
        /// <br>Date       : 2007.03.01</br>
        /// </remarks>
        private void CloseForm(DialogResult dialogResult)
        {
            // 画面非表示イベント
            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(dialogResult);
                UnDisplaying(this, me);
            }

            this.DialogResult = dialogResult;

            // _GridIndexバッファ初期化（メインフレーム最小化対応）
            this._indexBuf = -2;  // ADD 2008/06/04

            // 比較用クローンクリア
            this._stockMngTtlStClone = null;
            // フォームを非表示化する。
            if (this._canClose == true)
            {
                this.Close();
            }
            else
            {
                this.Hide();
            }
        }

        /// <summary>
        /// 排他処理
        /// </summary>
        /// <param name="status">STATUS</param>
        /// <param name="hide">非表示フラグ(true: 非表示にする, false: 非表示にしない)</param>
        /// <remarks>
        /// <br>Note       : 排他処理を行います</br>
        /// <br>Programmer : 30005 木建　翼</br>
        /// <br>Date       : 2007.03.01</br>
        /// </remarks>
        private void ExclusiveTransaction(int status, bool hide)
        {
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    {
                        // 他端末更新
                        TMsgDisp.Show(
                            this, 								// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
                            "MAZAI09110U", 						// アセンブリＩＤまたはクラスＩＤ
                            "既に他端末より更新されています。", // 表示するメッセージ
                            0, 									// ステータス値
                            MessageBoxButtons.OK);				// 表示するボタン
                        if (hide == true)
                        {
                            CloseForm(DialogResult.Cancel);
                        }
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        // 他端末削除
                        TMsgDisp.Show(
                            this, 								// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
                            "MAZAI09110U", 						// アセンブリＩＤまたはクラスＩＤ
                            "既に他端末より削除されています。", // 表示するメッセージ
                            0, 									// ステータス値
                            MessageBoxButtons.OK);				// 表示するボタン
                        if (hide == true)
                        {
                            CloseForm(DialogResult.Cancel);
                        }
                        break;
                    }
            }
        }

        /// <summary>
        /// データセット列情報構築処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : データセットの列情報を構築します。
        ///                  データセットの列情報がフレームのビュー用グリッドの列になります。</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/04</br>
        /// <br>Update Note: 2009/12/02 朱俊成 棚卸運用区分の追加</br>
        /// <br>Update Note: 2012/06/08 lanl</br>
        /// <br>             Redmine#30282「棚卸データ削除区分」を画面に追加</br>
        /// <br>Update Note: 2012/07/02 三戸　伸悟</br>
        /// <br>             「移動時在庫自動登録区分」を画面に追加　</br>
        /// <br>Update Note: 2014/10/27 wangf </br>
        /// <br>           : Redmine#43854画面に列「移動伝票出力先区分」追加</br>
        /// </remarks>
        private void DataSetColumnConstruction()
        {
            DataTable stockMngTtlStTable = new DataTable(STOCKMNGTTLST_TABLE);
            stockMngTtlStTable.Columns.Add(DELETE_DATE, typeof(string));

            stockMngTtlStTable.Columns.Add(SECTIONCODE_TITLE, typeof(string));
            stockMngTtlStTable.Columns.Add(SECTIONNAME_TITLE, typeof(string));

            // --- DEL 2008/12/01 -------------------------------->>>>>
            //stockMngTtlStTable.Columns.Add(STOCKMOVEFIXCODE_TITLE, typeof(string));      // 在庫移動確定区分
            // --- DEL 2008/12/01 --------------------------------<<<<<
            // --- DEL 2008/12/01 -------------------------------->>>>>
            //stockMngTtlStTable.Columns.Add(STOCKTOLERNCSHIPMDIV_TITLE, typeof(string));  // 在庫切れ出荷区分
            //stockMngTtlStTable.Columns.Add(INVNTRYPRTODRINIDIV_TITLE, typeof(string));   // 棚卸印刷順初期設定区分
            //stockMngTtlStTable.Columns.Add(STOCKPOINTWAY_TITLE, typeof(string));         // 在庫評価方法
            //stockMngTtlStTable.Columns.Add(MAXSTKCNTOVERODERDIV_TITLE, typeof(string));  // 最高在庫数超え発注区分
            //stockMngTtlStTable.Columns.Add(SHELFNODUPLDIV_TITLE, typeof(string));        // 棚番重複区分
            //stockMngTtlStTable.Columns.Add(LOTUSEDIVCD_TITLE, typeof(string));           // ロット使用区分
            //stockMngTtlStTable.Columns.Add(SECTDSPDIVCD_TITLE, typeof(string));          // 拠点表示区分
            //stockMngTtlStTable.Columns.Add(FRACTIONPROCCD_TITLE, typeof(string));        // 端数処理区分  // ADD 2008/07/03
            // --- DEL 2008/12/01 --------------------------------<<<<<
            // --- ADD 2008/12/01 -------------------------------->>>>>
            stockMngTtlStTable.Columns.Add(STOCKPOINTWAY_TITLE, typeof(string));         // 在庫評価方法
            stockMngTtlStTable.Columns.Add(SHELFNODUPLDIV_TITLE, typeof(string));        // 棚番重複区分
            stockMngTtlStTable.Columns.Add(SECTDSPDIVCD_TITLE, typeof(string));          // 拠点表示区分
            stockMngTtlStTable.Columns.Add(FRACTIONPROCCD_TITLE, typeof(string));        // 端数処理区分  // ADD 2008/07/03
            // --- ADD 2009/12/02 ---------->>>>>
            stockMngTtlStTable.Columns.Add(INVENTORYMNGDIV_TITLE, typeof(string));       // 棚卸運用区分
            // --- ADD 2009/12/02 ----------<<<<<
            // DEL 2009/01/16 不具合対応[10151]↓
            //stockMngTtlStTable.Columns.Add(STOCKTOLERNCSHIPMDIV_TITLE, typeof(string));  // 在庫切れ出荷区分
            stockMngTtlStTable.Columns.Add(INVNTRYPRTODRINIDIV_TITLE, typeof(string));   // 棚卸印刷順初期設定区分

            stockMngTtlStTable.Columns.Add(MAXSTKCNTOVERODERDIV_TITLE, typeof(string));  // 最高在庫数超え発注区分
            stockMngTtlStTable.Columns.Add(LOTUSEDIVCD_TITLE, typeof(string));           // ロット使用区分
            // --- ADD 2008/12/01 --------------------------------<<<<<
            // ---ADD(復活) 2009/06/03 -------------------------------->>>>>
            stockMngTtlStTable.Columns.Add(STOCKMOVEFIXCODE_TITLE, typeof(string));      // 在庫移動確定区分
            // ---ADD(復活) 2009/06/03 --------------------------------<<<<<
            stockMngTtlStTable.Columns.Add(STOCKDISPLAYDIV_TITLE, typeof(string));       // 現在庫表示区分  // ADD 2011/08/29
            stockMngTtlStTable.Columns.Add(INVNTRYDTDELDIV_TITLE, typeof(string));   // 棚卸データ削除区分 // ADD lanl 2012/06/08 Redmine#30282
            // --- ADD 三戸 2012/07/02 ---------->>>>>
            stockMngTtlStTable.Columns.Add(MOVESTOCKAUTOINSDIV_TITLE, typeof(string));   // 移動時在庫自動登録区分
            // --- ADD 三戸 2012/07/02 ----------<<<<<
            stockMngTtlStTable.Columns.Add(MOVESLIPOUTPUTDIV_TITLE, typeof(string));   // 移動伝票出力先区分 // ADD wangf 2014/10/27 FOR Redmine#43854 列「移動伝票出力先区分」追加

            stockMngTtlStTable.Columns.Add(GUID_TITLE, typeof(Guid));

            this.Bind_DataSet.Tables.Add(stockMngTtlStTable);
        }

        /// <summary>
        /// 画面初期設定
        /// </summary>
        /// <remarks>
        /// <br>Note       : UI画面の初期設定を行います。</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/04</br>
        /// <br>Update Note: 2009/12/02 朱俊成 棚卸運用区分を追加</br>
        /// <br>Update Note: 2012/06/08 lanl</br>
        /// <br>             Redmine#30282「棚卸データ削除区分」を画面に追加</br>
        /// <br>Update Note: 2012/07/02 三戸　伸悟</br>
        /// <br>             「移動時在庫自動登録区分」を画面に追加　</br>
        /// <br>Update Note: 2014/10/27 wangf </br>
        /// <br>           : Redmine#43854画面に列「移動伝票出力先区分」追加</br>
        /// </remarks>
        private void ScreenInitialSetting()
        {
            // ボタン配置
            int CANCELBUTTONLOCATION_X = this.Cancel_Button.Location.X;
            int OKBUTTONLOCATION_X = this.Ok_Button.Location.X;
            int DELETEBUTTONLOCATION_X = this.Revive_Button.Location.X;
            int BUTTONLOCATION_Y = this.Cancel_Button.Location.Y;
            this.Cancel_Button.Location = new System.Drawing.Point(CANCELBUTTONLOCATION_X, BUTTONLOCATION_Y);
            this.Ok_Button.Location = new System.Drawing.Point(OKBUTTONLOCATION_X, BUTTONLOCATION_Y);
            this.Revive_Button.Location = new System.Drawing.Point(OKBUTTONLOCATION_X, BUTTONLOCATION_Y);
            this.Delete_Button.Location = new System.Drawing.Point(DELETEBUTTONLOCATION_X, BUTTONLOCATION_Y);

            // --- DEL 2008/12/01 -------------------------------->>>>>
            //// 在庫移動確定区分
            //this.StockMoveFixCode_tComboEditor.Items.Clear();
            //this.StockMoveFixCode_tComboEditor.Items.Add(((int)StockMoveFixCode.Yes - 1), STOCKMOVEFIXCODE_YES);    // MOD 2008/09/16 不具合対応[5130] 0→((int)StockMoveFixCode.Yes-1)
            //this.StockMoveFixCode_tComboEditor.Items.Add(((int)StockMoveFixCode.No - 1), STOCKMOVEFIXCODE_NO);      // MOD 2008/09/16 不具合対応[5130] 1→((int)StockMoveFixCode.No-1)
            //this.StockMoveFixCode_tComboEditor.MaxDropDownItems = this.StockMoveFixCode_tComboEditor.Items.Count;
            // --- DEL 2008/12/01 --------------------------------<<<<<
            // ---ADD(復活) 2009/06/03 -------------------------------->>>>>
            // 在庫移動確定区分
            this.StockMoveFixCode_tComboEditor.Items.Clear();
            this.StockMoveFixCode_tComboEditor.Items.Add(((int)StockMoveFixCode.Yes - 1), STOCKMOVEFIXCODE_YES);
            this.StockMoveFixCode_tComboEditor.Items.Add(((int)StockMoveFixCode.No - 1), STOCKMOVEFIXCODE_NO);
            this.StockMoveFixCode_tComboEditor.MaxDropDownItems = this.StockMoveFixCode_tComboEditor.Items.Count;
            // ---ADD(復活) 2009/06/03 --------------------------------<<<<<
            // 在庫切れ出荷区分
            this.StockTolerncShipmDiv_tComboEditor.Items.Clear();
            this.StockTolerncShipmDiv_tComboEditor.Items.Add(0, STOCKTOLERNCSHIPMDIV_NONE);
            this.StockTolerncShipmDiv_tComboEditor.Items.Add(1, STOCKTOLERNCSHIPMDIV_WARNING);
            this.StockTolerncShipmDiv_tComboEditor.Items.Add(2, STOCKTOLERNCSHIPMDIV_BOTH);
            this.StockTolerncShipmDiv_tComboEditor.Items.Add(3, STOCKTOLERNCSHIPMDIV_AGAIN);
            this.StockTolerncShipmDiv_tComboEditor.MaxDropDownItems = this.StockTolerncShipmDiv_tComboEditor.Items.Count;

            // 棚卸印刷順初期設定区分
            this.InvntryPrtOdrIniDiv_tComboEditor.Items.Clear();
            this.InvntryPrtOdrIniDiv_tComboEditor.Items.Add(0, INVNTRYPRTODRINIDIV_SHELF);
            this.InvntryPrtOdrIniDiv_tComboEditor.Items.Add(1, INVNTRYPRTODRINIDIV_STOCKING);
            this.InvntryPrtOdrIniDiv_tComboEditor.Items.Add(2, INVNTRYPRTODRINIDIV_BL);
            this.InvntryPrtOdrIniDiv_tComboEditor.Items.Add(3, INVNTRYPRTODRINIDIV_GROUP);  // ADD 2008/08/28
            this.InvntryPrtOdrIniDiv_tComboEditor.Items.Add(4, INVNTRYPRTODRINIDIV_MAKER);
            this.InvntryPrtOdrIniDiv_tComboEditor.Items.Add(5, INVNTRYPRTODRINIDIV_STOCKBL);
            this.InvntryPrtOdrIniDiv_tComboEditor.Items.Add(6, INVNTRYPRTODRINIDIV_STOCKMAKER);
            this.InvntryPrtOdrIniDiv_tComboEditor.MaxDropDownItems = this.InvntryPrtOdrIniDiv_tComboEditor.Items.Count;

            // 在庫評価方法
            this.StockPointWay_tComboEditor.Items.Clear();
            this.StockPointWay_tComboEditor.Items.Add(((int)StockPointWay.Last - 1), STOCKPOINTWAY_LAST);   // MOD 2008/09/16 不具合対応[5130] 0→((int)StockPointWay.Last - 1)
            this.StockPointWay_tComboEditor.Items.Add(((int)StockPointWay.Move - 1), STOCKPOINTWAY_MOVE);   // MOD 2008/09/16 不具合対応[5130] 1→((int)StockPointWay.Last - 1)
            this.StockPointWay_tComboEditor.MaxDropDownItems = this.StockPointWay_tComboEditor.Items.Count;

            // 最高在庫数超え発注区分
            this.MaxStkCntOverOderDiv_tComboEditor.Items.Clear();
            this.MaxStkCntOverOderDiv_tComboEditor.Items.Add(0, MAXSTKCNTOVERODERDIV_NO);
            this.MaxStkCntOverOderDiv_tComboEditor.Items.Add(1, MAXSTKCNTOVERODERDIV_YES);
            this.MaxStkCntOverOderDiv_tComboEditor.MaxDropDownItems = this.MaxStkCntOverOderDiv_tComboEditor.Items.Count;

            // 棚番重複区分
            this.ShelfNoDuplDiv_tComboEditor.Items.Clear();
            this.ShelfNoDuplDiv_tComboEditor.Items.Add(0, SHELFNODUPLDIV_POSS);
            this.ShelfNoDuplDiv_tComboEditor.Items.Add(1, SHELFNODUPLDIV_IMPOSS);
            this.ShelfNoDuplDiv_tComboEditor.MaxDropDownItems = this.ShelfNoDuplDiv_tComboEditor.Items.Count;

            // ロット使用区分
            this.LotUseDivCd_tComboEditor.Items.Clear();
            this.LotUseDivCd_tComboEditor.Items.Add(0, LOTUSEDIVCD_ORDER);
            this.LotUseDivCd_tComboEditor.Items.Add(1, LOTUSEDIVCD_CIRCULATE);
            this.LotUseDivCd_tComboEditor.MaxDropDownItems = this.LotUseDivCd_tComboEditor.Items.Count;

            // 拠点表示区分
            this.SectDspDivCd_tComboEditor.Items.Clear();
            this.SectDspDivCd_tComboEditor.Items.Add(0, SECTDSPDIVCD_STORAGE);
            this.SectDspDivCd_tComboEditor.Items.Add(1, SECTDSPDIVCD_OWN);
            this.SectDspDivCd_tComboEditor.Items.Add(2, SECTDSPDIVCD_NONE);
            this.SectDspDivCd_tComboEditor.MaxDropDownItems = this.SectDspDivCd_tComboEditor.Items.Count;

            // --- ADD 2008/07/03 -------------------------------->>>>>
            // 端数処理区分
            this.FractionProcCd_tComboEditor.Items.Clear();
            this.FractionProcCd_tComboEditor.Items.Add(((int)FractionProcCd.Cut - 1), FRACTIONPROCCD_CUT);                  // MOD 2008/09/16 不具合対応[5130] 0→((int)FractionProcCd.Cut - 1)
            this.FractionProcCd_tComboEditor.Items.Add(((int)FractionProcCd.Round - 1), FRACTIONPROCCD_ROUND);              // MOD 2008/09/16 不具合対応[5130] 1→((int)FractionProcCd.Round - 1)
            this.FractionProcCd_tComboEditor.Items.Add(((int)FractionProcCd.Revaluation - 1), FRACTIONPROCCD_REVALUATION);  // MOD 2008/09/16 不具合対応[5130] 2→((int)FractionProcCd.Revaluation - 1)
            this.FractionProcCd_tComboEditor.MaxDropDownItems = this.FractionProcCd_tComboEditor.Items.Count;
            // --- ADD 2008/07/03 --------------------------------<<<<< 

            // --- ADD 2009/12/02 ---------->>>>>
            // 棚卸運用区分
            this.InventoryMngDiv_tComboEditor.Items.Clear();
            this.InventoryMngDiv_tComboEditor.Items.Add(0, INVENTORYMNGDIV_PMNS);
            this.InventoryMngDiv_tComboEditor.Items.Add(1, INVENTORYMNGDIV_PM7);
            this.InventoryMngDiv_tComboEditor.MaxDropDownItems = this.InventoryMngDiv_tComboEditor.Items.Count;
            // --- ADD 2009/12/02 ----------<<<<<

            // -------------- ADD 2011/08/29 ----------------- >>>>>
            // 現在庫表示区分
            this.PreStckCntDspDiv_tComboEditor.Items.Clear();
            this.PreStckCntDspDiv_tComboEditor.Items.Add(0, STOCKDISPLAYDIV_YES);
            this.PreStckCntDspDiv_tComboEditor.Items.Add(1, STOCKDISPLAYDIV_NO);
            this.PreStckCntDspDiv_tComboEditor.MaxDropDownItems = this.PreStckCntDspDiv_tComboEditor.Items.Count;
            // -------------- ADD 2011/08/29 ----------------- <<<<<

            // -------------- ADD lanl 2012/06/08 Redmine#30282 ----------------- >>>>>
            // 棚卸データ削除区分
            this.InvntryDtDelDiv_tComboEditor.Items.Clear();
            this.InvntryDtDelDiv_tComboEditor.Items.Add(0, INVNTRYDTDELDIV_POS);
            this.InvntryDtDelDiv_tComboEditor.Items.Add(1, INVNTRYDTDELDIV_POSSEC);
            this.InvntryDtDelDiv_tComboEditor.Items.Add(2, INVNTRYDTDELDIV_IMPOS);
            this.InvntryDtDelDiv_tComboEditor.MaxDropDownItems = this.InvntryDtDelDiv_tComboEditor.Items.Count;
            // -------------- ADD lanl 2012/06/08 Redmine#30282 ----------------- <<<<<

            // --- ADD 三戸 2012/07/02 ---------->>>>>
            // 移動時在庫自動登録区分
            this.MoveStockAutoInsDiv_tComboEditor.Items.Clear();
            this.MoveStockAutoInsDiv_tComboEditor.Items.Add(0, MOVESTOCKAUTOINSDIV_YES);
            this.MoveStockAutoInsDiv_tComboEditor.Items.Add(1, MOVESTOCKAUTOINSDIV_NO);
            this.MoveStockAutoInsDiv_tComboEditor.MaxDropDownItems = this.MoveStockAutoInsDiv_tComboEditor.Items.Count;
            // --- ADD 三戸 2012/07/02 ----------<<<<<

            // ------------ADD wangf 2014/10/27 FOR Redmine#43854 列「移動伝票出力先区分」追加--------->>>>
            // 移動伝票出力先区分
            this.MoveSlipOutPutDiv_tComboEditor.Items.Clear();
            this.MoveSlipOutPutDiv_tComboEditor.Items.Add(0, MOVESLIPOUTPUTDIV_IN);
            this.MoveSlipOutPutDiv_tComboEditor.Items.Add(1, MOVESLIPOUTPUTDIV_OUT);
            this.MoveSlipOutPutDiv_tComboEditor.MaxDropDownItems = this.MoveSlipOutPutDiv_tComboEditor.Items.Count;
            // ------------ADD wangf 2014/10/27 FOR Redmine#43854 列「移動伝票出力先区分」追加---------<<<<
        }

        /// <summary>
        /// 画面再構築処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面を再構築します。</br>
        /// <br>Programmer : 30005 木建　翼</br>
        /// <br>Date       : 2007.03.01</br>
        /// </remarks>
        private void ScreenReconstruction()
        {
            // --- DEL 2008/06/04 -------------------------------->>>>>
            //int status = 0;

            //// 在庫管理全体設定マスタクラスのインスタンス化
            //this._stockMngTtlSt = new StockMngTtlSt();
            
            //// 在庫管理全体設定データ取得
            //status = this._stockMngTtlStAcs.Read(out _stockMngTtlSt, this._enterpriseCode, STOCKMNGTTLSTCODE_DEFAULT);
     
            //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            //{
            //    if (this._stockMngTtlSt == null)
            //    {
            //        this._stockMngTtlSt = new StockMngTtlSt();
            //    }

            //    // 在庫管理設定画面展開処理
            //    StockMngTtlStToScreen();

            //    // 比較用クローン作成
            //    this._stockMngTtlStClone = this._stockMngTtlSt.Clone();
  
            //    // クローンに取得したデータをコピー
            //    this._stockMngTtlStClone = this._stockMngTtlSt;
      
            //    // 初期フォーカスをセット
            //    this.StockMoveFixCode_tComboEditor.Focus();
            //}
            //else
            //{
            //    // リード
            //    TMsgDisp.Show(
            //        this, 								// 親ウィンドウフォーム
            //        emErrorLevel.ERR_LEVEL_STOP, 		// エラーレベル
            //        "MAZAI09110U", 						// アセンブリＩＤまたはクラスＩＤ
            //        "在庫管理全体設定", 				// プログラム名称
            //        "ScreenReconstruction", 			// 処理名称
            //        TMsgDisp.OPE_READ, 					// オペレーション
            //        "読み込みに失敗しました。", 		// 表示するメッセージ
            //        status, 							// ステータス値
            //        this._stockMngTtlStAcs, 			// エラーが発生したオブジェクト
            //        MessageBoxButtons.OK, 				// 表示するボタン
            //        MessageBoxDefaultButton.Button1);	// 初期表示ボタン

            //    this._stockMngTtlSt = new StockMngTtlSt();
            //    // 伝票初期値設定画面展開処理
            //    StockMngTtlStToScreen();
            //    // 比較用クローン作成
            //    this._stockMngTtlStClone = this._stockMngTtlSt.Clone();
            //    // 画面情報を比較用クローンにコピー
            //    DispToStockMngTtlSt(ref this._stockMngTtlStClone);
            //    // 初期フォーカスをセット
            //    this.StockMoveFixCode_tComboEditor.Focus();
            //}
            // --- DEL 2008/06/04 --------------------------------<<<<< 

            if (this._dataIndex < 0)
            {
                // 新規モード
                this._logicalDeleteMode = -1;

                StockMngTtlSt newStockMngTtlSt = new StockMngTtlSt();
                // 在庫管理全体設定オブジェクトを画面に展開
                StockMngTtlStToScreen(newStockMngTtlSt);

                // クローン作成
                this._stockMngTtlStClone = newStockMngTtlSt.Clone();
                DispToStockMngTtlSt(ref this._stockMngTtlStClone);
            }
            else
            {
                Guid guid = (Guid)this.Bind_DataSet.Tables[STOCKMNGTTLST_TABLE].Rows[this._dataIndex][GUID_TITLE];
                StockMngTtlSt stockMngTtlSt = (StockMngTtlSt)this._stockMngTtlStTable[guid];

                // 在庫管理全体設定オブジェクトを画面に展開
                StockMngTtlStToScreen(stockMngTtlSt);

                if (stockMngTtlSt.LogicalDeleteCode == 0)
                {
                    // 更新モード
                    this._logicalDeleteMode = 0;

                    // クローン作成
                    this._stockMngTtlStClone = stockMngTtlSt.Clone();
                    DispToStockMngTtlSt(ref this._stockMngTtlStClone);
                }
                else
                {
                    // 削除モード
                    this._logicalDeleteMode = 1;
                }
            }
            // _GridIndexバッファ保持（メインフレーム最小化対応）
            this._indexBuf = this._dataIndex;

            ScreenInputPermissionControl();
        }

        // --- DEL 2008/06/04 -------------------------------->>>>>
        /// <summary>
        /// 画面展開処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 伝票初期値設定クラスから画面にデータを展開します。</br>
        /// <br>Programmer : 30005 木建　翼</br>
        /// <br>Date       : 2007.03.01</br>
        /// <br>Update Note: 2009/12/02 朱俊成 棚卸運用区分の追加</br>
        /// <br>Update Note: 2012/06/08 lanl</br>
        /// <br>             Redmine#30282「棚卸データ削除区分」を画面に追加</br>
        /// <br>Update Note: 2012/07/02 三戸　伸悟</br>
        /// <br>             「移動時在庫自動登録区分」を画面に追加　</br>
        /// <br>Update Note: 2014/10/27 wangf </br>
        /// <br>           : Redmine#43854画面に列「移動伝票出力先区分」追加</br>
        /// </remarks>
        //private void StockMngTtlStToScreen()
        //{
        //    /************** 注意 ************
        //     * デフォルト値が1からの区分は  *
        //     * インデックスにマイナス１する *
        //     *******************************/
        //    // 在庫移動確定区分
        //    // 未設定時のSelectIndexが０以下になるのを防ぐ
        //    if (this._stockMngTtlSt.StockMoveFixCode == 0)
        //    {
        //        this.StockMoveFixCode_tComboEditor.SelectedIndex = 0;
        //    }
        //    else
        //    {
        //        this.StockMoveFixCode_tComboEditor.SelectedIndex = this._stockMngTtlSt.StockMoveFixCode - 1;
        //    }

        //    // 在庫管理有無区分初期表示値
        //    //this.StockMngExistCdDisp_tComboEditor.SelectedIndex = this._stockMngTtlSt.StockMngExistCdDisp;  // DEL 2008/06/04

        //    // 製番管理区分初期表示値
        //    //this.PrdNumMngDivDisp_tComboEditor.SelectedIndex = this._stockMngTtlSt.PrdNumMngDivDisp;  // 2007.08.20 del

        //    // 在庫自動登録区分
        //    this.AutoEntryStockCd_tComboEditor.SelectedIndex = this._stockMngTtlSt.AutoEntryStockCd;

        //    /****************************
        //     * 最適在庫条件区分は非表示 *
        //     ****************************/

        //    // 在庫評価方法
        //    if (this._stockMngTtlSt.StockPointWay == 0)
        //    {
        //        this.StockPointWay_tComboEditor.SelectedIndex = 0;
        //    }
        //    else
        //    {
        //        this.StockPointWay_tComboEditor.SelectedIndex = this._stockMngTtlSt.StockPointWay - 1;
        //    }

        //    // 2007.03.27 DANJO ADD START
        //    // 端数処理区分
        //    //this.FractionProcCd_tComboEditor.Value = this._stockMngTtlSt.FractionProcCd; // 2007.08.20 del
        //    // 2007.03.27 DANJO ADD END

        //    // 2007.08.20 add start --------------------------------------------------->>
        //    // 在庫切れ出荷区分
        //    this.StockTolerncShipmDiv_tComboEditor.SelectedIndex = this._stockMngTtlSt.StockTolerncShipmDiv;
        //    // 棚卸印刷順初期設定区分
        //    this.InvntryPrtOdrIniDiv_tComboEditor.SelectedIndex = this._stockMngTtlSt.InvntryPrtOdrIniDiv;
        //    // 最高在庫数超え発注区分
        //    this.MaxStkCntOverOderDiv_tComboEditor.SelectedIndex = this._stockMngTtlSt.MaxStkCntOverOderDiv;
        //    // 2007.08.20 add end -----------------------------------------------------<<

        //    // --- ADD 2008/06/04 -------------------------------->>>>>
        //    this.SectionCd_tEdit.Value = this._stockMngTtlSt.SectionCode;                         // 拠点コード
        //    this.ShelfNoDuplDiv_tComboEditor.SelectedIndex = this._stockMngTtlSt.ShelfNoDuplDiv;  // 棚番重複区分
        //    this.LotUseDivCd_tComboEditor.SelectedIndex = this._stockMngTtlSt.LotUseDivCd;        // ロット使用区分
        //    this.SectDspDivCd_tComboEditor.SelectedIndex = this._stockMngTtlSt.SectDspDivCd;      // 拠点表示区分
        //    // --- ADD 2008/06/04 --------------------------------<<<<< 
        //}
        // --- DEL 2008/06/04 --------------------------------<<<<< 

        // --- ADD 2008/06/05 -------------------------------->>>>>
        private void StockMngTtlStToScreen(StockMngTtlSt stockMngTtlSt)
        {
            // 拠点コード
            this.tEdit_SectionCodeAllowZero2.Value = stockMngTtlSt.SectionCode.TrimEnd();
            // 拠点名称
            // --- ADD 2008/09/29 ------------------------------------------->>>>>
            if (this.tEdit_SectionCodeAllowZero2.Text == "00")
            {
                this.SectionNm_tEdit.Value = "全社共通";
            }
            else
            {
                // --- ADD 2008/09/29 -------------------------------------------<<<<<
                foreach (SecInfoSet si in this._secInfoAcs.SecInfoSetList)
                {
                    if (si.SectionCode.TrimEnd() == stockMngTtlSt.SectionCode.TrimEnd())
                    {
                        this.SectionNm_tEdit.Value = si.SectionGuideNm;
                        break;
                    }
                }
            }      //ADD 2008/09/29

            // --- DEL 2008/12/01 -------------------------------->>>>>
            //// 在庫移動確定区分
            //// DEL 2008/09/16 不具合対応[5130] ---------->>>>>
            ////if (stockMngTtlSt.StockMoveFixCode == 0)
            ////{
            ////    this.StockMoveFixCode_tComboEditor.SelectedIndex = 0;
            ////}
            ////else
            ////{
            ////    this.StockMoveFixCode_tComboEditor.SelectedIndex = stockMngTtlSt.StockMoveFixCode - 1;
            ////}
            //// DEL 2008/09/16 不具合対応[5130] ----------<<<<<
            //// ADD 2008/09/16 不具合対応[5130] ---------->>>>>
            //if (!StockMngTtlStOfAllSection.StockMoveFixCode.Equals((int)StockMoveFixCode.None))
            //{
            //    this.StockMoveFixCode_tComboEditor.SelectedIndex = StockMngTtlStOfAllSection.StockMoveFixCode - 1;
            //}
            //else
            //{
            //    if (stockMngTtlSt.StockMoveFixCode.Equals((int)StockMoveFixCode.None))
            //    {
            //        this.StockMoveFixCode_tComboEditor.SelectedIndex = 0;
            //    }
            //    else
            //    {
            //        this.StockMoveFixCode_tComboEditor.SelectedIndex = stockMngTtlSt.StockMoveFixCode - 1;
            //    }
            //}
            //// ADD 2008/09/16 不具合対応[5130] ----------<<<<<
            // --- DEL 2008/12/01 --------------------------------<<<<<
            // ---ADD(復活) 2009/06/03 -------------------->>>>>
            if (!StockMngTtlStOfAllSection.StockMoveFixCode.Equals((int)StockMoveFixCode.None))
            {
                this.StockMoveFixCode_tComboEditor.SelectedIndex = StockMngTtlStOfAllSection.StockMoveFixCode - 1;
            }
            else
            {
                if (stockMngTtlSt.StockMoveFixCode.Equals((int)StockMoveFixCode.None))
                {
                    this.StockMoveFixCode_tComboEditor.SelectedIndex = 0;
                }
                else
                {
                    this.StockMoveFixCode_tComboEditor.SelectedIndex = stockMngTtlSt.StockMoveFixCode - 1;
                }
            }
            // ---ADD(復活) 2009/06/03 --------------------<<<<<

            // 在庫切れ出荷区分
            this.StockTolerncShipmDiv_tComboEditor.SelectedIndex = stockMngTtlSt.StockTolerncShipmDiv;

            // 棚卸印刷順初期設定区分
            this.InvntryPrtOdrIniDiv_tComboEditor.SelectedIndex  = stockMngTtlSt.InvntryPrtOdrIniDiv;
            // ---ADD lanl 2012/06/08 Redmine#30282 --------------------------<<<<<
            //棚卸データ削除区分
            this.InvntryDtDelDiv_tComboEditor.SelectedIndex = StockMngTtlStOfAllSection.InvntryDtDelDiv;
            // ---ADD lanl 2012/06/08 Redmine#30282 -------------------------->>>>>
            // --- ADD 三戸 2012/07/02 ---------->>>>>
            // 移動時在庫自動登録区分
            this.MoveStockAutoInsDiv_tComboEditor.SelectedIndex = StockMngTtlStOfAllSection.MoveStockAutoInsDiv;
            // --- ADD 三戸 2012/07/02 ----------<<<<<
            // ------------ADD wangf 2014/10/27 FOR Redmine#43854 列「移動伝票出力先区分」追加--------->>>>
            // 移動伝票出力先区分
            this.MoveSlipOutPutDiv_tComboEditor.SelectedIndex = stockMngTtlSt.MoveSlipOutPutDiv;
            // ------------ADD wangf 2014/10/27 FOR Redmine#43854 列「移動伝票出力先区分」追加---------<<<<

            // 在庫評価方法
            // DEL 2008/09/16 不具合対応[5130] ---------->>>>>
            //if (stockMngTtlSt.StockPointWay == 0)
            //{
            //    this.StockPointWay_tComboEditor.SelectedIndex = 0;    
            //}
            //else
            //{
            //    this.StockPointWay_tComboEditor.SelectedIndex = stockMngTtlSt.StockPointWay - 1;
            //}
            // DEL 2008/09/16 不具合対応[5130] ----------<<<<<
            // ADD 2008/09/16 不具合対応[5130] ---------->>>>>
            if (!StockMngTtlStOfAllSection.StockPointWay.Equals((int)StockPointWay.None))
            {
                this.StockPointWay_tComboEditor.SelectedIndex = StockMngTtlStOfAllSection.StockPointWay - 1;
            }
            else
            {
                if (stockMngTtlSt.StockPointWay.Equals((int)StockPointWay.None))
                {
                    this.StockPointWay_tComboEditor.SelectedIndex = 0;
                }
                else
                {
                    this.StockPointWay_tComboEditor.SelectedIndex = stockMngTtlSt.StockPointWay - 1;
                }
            }
            // ADD 2008/09/16 不具合対応[5130] ----------<<<<<

            // 最高在庫数超え発注区分
            this.MaxStkCntOverOderDiv_tComboEditor.SelectedIndex = stockMngTtlSt.MaxStkCntOverOderDiv;

            // 棚番重複区分
            this.ShelfNoDuplDiv_tComboEditor.SelectedIndex = stockMngTtlSt.ShelfNoDuplDiv;

            // ロット使用区分
            this.LotUseDivCd_tComboEditor.SelectedIndex = stockMngTtlSt.LotUseDivCd;

            // 拠点表示区分
            this.SectDspDivCd_tComboEditor.SelectedIndex = stockMngTtlSt.SectDspDivCd;

            // --- ADD 2008/07/03 -------------------------------->>>>>
            // DEL 2008/09/16 不具合対応[5130] ---------->>>>>
            // 端数処理区分
            //if(stockMngTtlSt.FractionProcCd == 0)
            //{
            //    this.FractionProcCd_tComboEditor.SelectedIndex = 2;
            //}
            //else
            //{
            //    this.FractionProcCd_tComboEditor.SelectedIndex = stockMngTtlSt.FractionProcCd - 1;
            //}
            // DEL 2008/09/16 不具合対応[5130] ----------<<<<<
            // --- ADD 2008/07/03 --------------------------------<<<<<
            // ADD 2008/09/16 不具合対応[5130] ---------->>>>>
            if (!StockMngTtlStOfAllSection.FractionProcCd.Equals((int)FractionProcCd.None))
            {
                this.FractionProcCd_tComboEditor.SelectedIndex = StockMngTtlStOfAllSection.FractionProcCd - 1;
            }
            else
            {
                if (stockMngTtlSt.FractionProcCd.Equals((int)FractionProcCd.None))
                {
                    this.FractionProcCd_tComboEditor.SelectedIndex = 2;
                }
                else
                {
                    this.FractionProcCd_tComboEditor.SelectedIndex = stockMngTtlSt.FractionProcCd - 1;
                }
            }
            // ADD 2008/09/16 不具合対応[5130] ----------<<<<<
            // --- ADD 2009/12/02 ---------->>>>>
            // 棚卸運用区分
            if (StockMngTtlStOfAllSection.InventoryMngDiv != 0 && StockMngTtlStOfAllSection.InventoryMngDiv != 1)
            {
                this.InventoryMngDiv_tComboEditor.SelectedIndex = 1;
            }
            else
            {
                this.InventoryMngDiv_tComboEditor.SelectedIndex = StockMngTtlStOfAllSection.InventoryMngDiv;
            }
            // --- ADD 2009/12/02 ----------<<<<<
            // ----------------- ADD 2011/08/29 ------------------ >>>>>
            if (this.tEdit_SectionCodeAllowZero2.Text == "00" && this.InventoryMngDiv_tComboEditor.SelectedIndex == 0)
            {
                this.PreStckCntDspDiv_tComboEditor.SelectedIndex = 0;
            }
            else
            {
                this.PreStckCntDspDiv_tComboEditor.SelectedIndex = StockMngTtlStOfAllSection.PreStckCntDspDiv;
            }
            // ----------------- ADD 2011/08/29 ------------------ <<<<<
        }
        // --- ADD 2008/06/05 --------------------------------<<<<< 

        // --- DEL 2008/07/03 -------------------------------->>>>>
        ///// <summary>
        ///// 画面情報を在庫管理全体設定クラス格納処理
        ///// </summary>
        ///// <br paramname="stockMngTtlSt">保存するデータクラス</br>
        ///// <remarks>
        ///// <br>Note       : 画面情報から在庫管理全体設定クラスにデータを格納します。</br>
        ///// <br>Programmer : 30005 木建　翼</br>
        ///// <br>Date       : 2007.03.01</br>
        ///// </remarks>
        //private void ScreenToStockMngTtlSt(ref StockMngTtlSt stockMngTtlSt)
        //{
        //        /************* 注意 ************
        //         * デフォルト値が1からの区分は *
        //         * インデックスにプラス１する  *
        //         *******************************/
        //     // 在庫移動確定区分
        //    if (this.StockMoveFixCode_tComboEditor.SelectedIndex < 0)
        //    {
        //        stockMngTtlSt.StockMoveFixCode = 1;
        //    }
        //    else
        //    {
        //        stockMngTtlSt.StockMoveFixCode = this.StockMoveFixCode_tComboEditor.SelectedIndex + 1;
        //    }

        //    /* --- DEL 2008/06/04 -------------------------------->>>>>
        //    // 在庫管理有無区分初期表示値
        //    if (this.StockMngExistCdDisp_tComboEditor.SelectedIndex < 0)
        //    {
        //        stockMngTtlSt.StockMngExistCdDisp = 0;
        //    }
        //    else
        //    {
        //        stockMngTtlSt.StockMngExistCdDisp = this.StockMngExistCdDisp_tComboEditor.SelectedIndex;
        //    }
        //       --- DEL 2008/06/04 --------------------------------<<<<< */

        //    // 製番管理区分初期表示値
        //    // 2007.08.20 hikita del start ----------------------------------------->>
        //    //if (this.PrdNumMngDivDisp_tComboEditor.SelectedIndex < 0)
        //    //{
        //    //    stockMngTtlSt.PrdNumMngDivDisp = 0;
        //    //}
        //    //else
        //    //{
        //    //    stockMngTtlSt.PrdNumMngDivDisp = this.PrdNumMngDivDisp_tComboEditor.SelectedIndex;
        //    //}
        //    // 2007.08.20 hikita del end -------------------------------------------<<

        //    // 在庫自動登録区分
        //    if (this.AutoEntryStockCd_tComboEditor.SelectedIndex < 0)
        //    {
        //        stockMngTtlSt.AutoEntryStockCd = 0;
        //    }
        //    else
        //    {
        //        stockMngTtlSt.AutoEntryStockCd = this.AutoEntryStockCd_tComboEditor.SelectedIndex;
        //    }

        //    /****************************
        //     * 最適在庫条件区分は非表示 *
        //     ****************************/
        //    // 最適在庫条件区分



        //    // 在庫評価方法
        //    if (this.StockPointWay_tComboEditor.SelectedIndex < 0)
        //    {
        //        stockMngTtlSt.StockPointWay = 1;
        //    }
        //    else
        //    {
        //        stockMngTtlSt.StockPointWay = this.StockPointWay_tComboEditor.SelectedIndex + 1;
        //    }

        //    // 端数処理区分
        //    if (this.FractionProcCd_tComboEditor.SelectedIndex < 0)
        //    {
        //        stockMngTtlSt.FractionProcCd = 0;
        //    }
        //    else
        //    {
        //        stockMngTtlSt.FractionProcCd = (int)this.FractionProcCd_tComboEditor.Value + 1;
        //    }

        //    // 2007.08.20 add start ------------------------------------->>
        //    // 在庫切れ出荷区分
        //    if (this.StockTolerncShipmDiv_tComboEditor.SelectedIndex < 0)
        //    {
        //        stockMngTtlSt.StockTolerncShipmDiv = 0;
        //    }
        //    else
        //    {
        //        stockMngTtlSt.StockTolerncShipmDiv = this.StockTolerncShipmDiv_tComboEditor.SelectedIndex;
        //    }
        //    // 棚卸印刷順初期設定区分
        //    if (this.InvntryPrtOdrIniDiv_tComboEditor.SelectedIndex < 0)
        //    {
        //        stockMngTtlSt.InvntryPrtOdrIniDiv = 0;
        //    }
        //    else
        //    {
        //        stockMngTtlSt.InvntryPrtOdrIniDiv = this.InvntryPrtOdrIniDiv_tComboEditor.SelectedIndex;
        //    }
        //    // 最高在庫数超え発注区分
        //    if (this.MaxStkCntOverOderDiv_tComboEditor.SelectedIndex < 0)
        //    {
        //        stockMngTtlSt.MaxStkCntOverOderDiv = 0;
        //    }
        //    else
        //    {
        //        stockMngTtlSt.MaxStkCntOverOderDiv = this.MaxStkCntOverOderDiv_tComboEditor.SelectedIndex;
        //    }
        //    // 2007.08.20 add end ---------------------------------------<<

        //    // --- ADD 2008/06/04 -------------------------------->>>>>
        //    // 拠点コード
        //    stockMngTtlSt.SectionCode = tEdit_SectionCodeAllowZero.DataText.TrimEnd();

        //    // 棚番重複区分
        //    if (this.ShelfNoDuplDiv_tComboEditor.SelectedIndex < 0)
        //    {
        //        stockMngTtlSt.ShelfNoDuplDiv = 0;
        //    }
        //    else
        //    {
        //        stockMngTtlSt.ShelfNoDuplDiv = this.ShelfNoDuplDiv_tComboEditor.SelectedIndex;
        //    }

        //    // ロット使用区分
        //    if (this.LotUseDivCd_tComboEditor.SelectedIndex < 0)
        //    {
        //        stockMngTtlSt.LotUseDivCd = 0;
        //    }
        //    else
        //    {
        //        stockMngTtlSt.LotUseDivCd = this.LotUseDivCd_tComboEditor.SelectedIndex;
        //    }

        //    // 拠点表示区分
        //    if (this.SectDspDivCd_tComboEditor.SelectedIndex < 0)
        //    {
        //        stockMngTtlSt.SectDspDivCd = 0;
        //    }
        //    else
        //    {
        //        stockMngTtlSt.SectDspDivCd = this.SectDspDivCd_tComboEditor.SelectedIndex;
        //    }
        //    // --- ADD 2008/06/04 --------------------------------<<<<< 
        //}
        // --- DEL 2008/07/03 --------------------------------<<<<<

        /// <summary>
        /// 画面情報を在庫管理全体設定クラス格納処理(チェック用)
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面情報から在庫管理全体設定クラスにデータを格納します。</br>
        /// <br>Programmer : 30005 木建　翼</br>
        /// <br>Date       : 2007.03.01</br>
        /// <br>Update Note: 2009/12/02 朱俊成 棚卸運用区分の追加</br>
        /// <br>Update Note: 2012/06/08 lanl</br>
        /// <br>             Redmine#30282「棚卸データ削除区分」を画面に追加</br>
        /// <br>Update Note: 2012/07/02 三戸　伸悟</br>
        /// <br>             「移動時在庫自動登録区分」を画面に追加　</br>
        /// <br>Update Note: 2014/10/27 wangf </br>
        /// <br>           : Redmine#43854画面に列「移動伝票出力先区分」追加</br>
        /// </remarks>
        private void DispToStockMngTtlSt(ref StockMngTtlSt stockMngTtlSt)
        {
            if (stockMngTtlSt == null)
            {
                // 新規の時
                stockMngTtlSt = new StockMngTtlSt();
            }

            /************* 注意 ************
             * デフォルト値が1からの区分は *
             * インデックスにプラス１する  *
             *******************************/
            
            stockMngTtlSt.EnterpriseCode = this._enterpriseCode;

            // --- DEL 2008/12/01 -------------------------------->>>>>
            //// 在庫移動確定区分
            //if (this.StockMoveFixCode_tComboEditor.SelectedIndex < 0)
            //{
            //    stockMngTtlSt.StockMoveFixCode = 1;
            //}
            //else
            //{
            //    stockMngTtlSt.StockMoveFixCode = this.StockMoveFixCode_tComboEditor.SelectedIndex + 1;
            //}
            // --- DEL 2008/12/01 --------------------------------<<<<<
            // ---ADD(復活) 2009/06/03 -------------------------------->>>>>
            // 在庫移動確定区分
            if (this.StockMoveFixCode_tComboEditor.SelectedIndex < 0)
            {
                stockMngTtlSt.StockMoveFixCode = 1;
            }
            else
            {
                stockMngTtlSt.StockMoveFixCode = this.StockMoveFixCode_tComboEditor.SelectedIndex + 1;
            }
            // ---ADD(復活) 2009/06/03 --------------------------------<<<<<

            /* --- DEL 2008/06/04 -------------------------------->>>>>
            // 在庫管理有無区分初期表示値
            if (this.StockMngExistCdDisp_tComboEditor.SelectedIndex < 0)
            {
                stockMngTtlSt.StockMngExistCdDisp = 0;
            }
            else
            {
                stockMngTtlSt.StockMngExistCdDisp = this.StockMngExistCdDisp_tComboEditor.SelectedIndex;
            }
               --- DEL 2008/06/04 --------------------------------<<<<< */

            // 製番管理区分初期表示値
            // 2007.08.20 hikita del start ------------------------------------->>
            //if (this.PrdNumMngDivDisp_tComboEditor.SelectedIndex < 0)
            //{
            //    stockMngTtlSt.PrdNumMngDivDisp = 0;
            //}
            //else
            //{
            //    stockMngTtlSt.PrdNumMngDivDisp = this.PrdNumMngDivDisp_tComboEditor.SelectedIndex;
            //}
            // 2007.08.20 hikita dek end-----------------------------------------<<


            /****************************
             * 最適在庫条件区分は非表示 *
             ****************************/
            // 最適在庫条件区分

            // 在庫評価方法
            if (this.StockPointWay_tComboEditor.SelectedIndex < 0)
            {
                stockMngTtlSt.StockPointWay = 1;
            }
            else
            {
                stockMngTtlSt.StockPointWay = this.StockPointWay_tComboEditor.SelectedIndex + 1;
            }

            // --- ADD 2008/07/03 -------------------------------->>>>>
            // 端数処理区分
            if (this.FractionProcCd_tComboEditor.SelectedIndex < 0)
            {
                stockMngTtlSt.FractionProcCd = 1;
            }
            else
            {
                stockMngTtlSt.FractionProcCd = (int)this.FractionProcCd_tComboEditor.Value + 1;
            }
            // --- ADD 2008/07/03 --------------------------------<<<<< 

            // --- ADD 2009/12/02 ---------->>>>>
            // 棚卸運用区分
            if (this.InventoryMngDiv_tComboEditor.SelectedIndex < 0)
            {
                stockMngTtlSt.InventoryMngDiv = 0;
            }
            else
            {
                stockMngTtlSt.InventoryMngDiv = (int)this.InventoryMngDiv_tComboEditor.Value;
            }
            // --- ADD 2009/12/02 ----------<<<<<
            // --------------- ADD 2011/08/29 ------------------- >>>>>
            // 現在庫表示区分
            if (this.PreStckCntDspDiv_tComboEditor.SelectedIndex < 0)
            {
                stockMngTtlSt.PreStckCntDspDiv = 0;
            }
            else
            {
                stockMngTtlSt.PreStckCntDspDiv = (int)this.PreStckCntDspDiv_tComboEditor.Value;
            }
            // --------------- ADD 2011/08/29 ------------------- <<<<<
            // --------------- ADD lanl 2012/06/08 Redmine#30282 ------------------- >>>>>
            // 棚卸データ削除区分
            if (this.InvntryDtDelDiv_tComboEditor.SelectedIndex < 0)
            {
                stockMngTtlSt.InvntryDtDelDiv = 0;
            }
            else
            {
                stockMngTtlSt.InvntryDtDelDiv = (int)this.InvntryDtDelDiv_tComboEditor.Value;
            }
            // --------------- ADD lanl 2012/06/08 Redmine#30282 ------------------- <<<<<
            // --- ADD 三戸 2012/07/02 ---------->>>>>
            // 移動時在庫自動登録区分
            if (this.MoveStockAutoInsDiv_tComboEditor.SelectedIndex < 0)
            {
                stockMngTtlSt.MoveStockAutoInsDiv = 0;
            }
            else
            {
                stockMngTtlSt.MoveStockAutoInsDiv = (int)this.MoveStockAutoInsDiv_tComboEditor.Value;
            }
            // --- ADD 三戸 2012/07/02 ----------<<<<<
            // ------------ADD wangf 2014/10/27 FOR Redmine#43854 列「移動伝票出力先区分」追加--------->>>>
            // 移動伝票出力先区分
            if (this.MoveSlipOutPutDiv_tComboEditor.SelectedIndex < 0)
            {
                stockMngTtlSt.MoveSlipOutPutDiv = 0;
            }
            else
            {
                stockMngTtlSt.MoveSlipOutPutDiv = (int)this.MoveSlipOutPutDiv_tComboEditor.Value;
            }
            // ------------ADD wangf 2014/10/27 FOR Redmine#43854 列「移動伝票出力先区分」追加---------<<<<
            // 2007.08.20 add start ------------------------------------->>
            // 在庫切れ出荷区分
            if (this.StockTolerncShipmDiv_tComboEditor.SelectedIndex < 0)
            {
                stockMngTtlSt.StockTolerncShipmDiv = 0;
            }
            else
            {
                stockMngTtlSt.StockTolerncShipmDiv = this.StockTolerncShipmDiv_tComboEditor.SelectedIndex;
            }
            // 棚卸印刷順初期設定区分
            if (this.InvntryPrtOdrIniDiv_tComboEditor.SelectedIndex < 0)
            {
                stockMngTtlSt.InvntryPrtOdrIniDiv = 0;
            }
            else
            {
                stockMngTtlSt.InvntryPrtOdrIniDiv = this.InvntryPrtOdrIniDiv_tComboEditor.SelectedIndex;
            }
            // 最高在庫数超え発注区分
            if (this.MaxStkCntOverOderDiv_tComboEditor.SelectedIndex < 0)
            {
                stockMngTtlSt.MaxStkCntOverOderDiv = 0;
            }
            else
            {
                stockMngTtlSt.MaxStkCntOverOderDiv = this.MaxStkCntOverOderDiv_tComboEditor.SelectedIndex;
            }
            // 2007.08.20 add end ---------------------------------------<<

            // --- ADD 2008/06/04 -------------------------------->>>>>
            // 拠点コード
            stockMngTtlSt.SectionCode = this.tEdit_SectionCodeAllowZero2.DataText.TrimEnd();
            // ADD 2008/09/19 不具合対応による共通仕様の展開 ---------->>>>>
            // uiSetControlが""のとき"00"を設定するので、デフォルト値は"00"とする
            if (string.IsNullOrEmpty(this.tEdit_SectionCodeAllowZero2.DataText.TrimEnd()))
            {
                stockMngTtlSt.SectionCode = SectionUtil.ALL_SECTION_CODE;
            }
            // ADD 2008/09/19 不具合対応による共通仕様の展開 ----------<<<<<

            // 棚番重複区分
            if (this.ShelfNoDuplDiv_tComboEditor.SelectedIndex < 0)
            {
                stockMngTtlSt.ShelfNoDuplDiv = 0;
            }
            else
            {
                stockMngTtlSt.ShelfNoDuplDiv = this.ShelfNoDuplDiv_tComboEditor.SelectedIndex;
            }

            // ロット使用区分
            if (this.LotUseDivCd_tComboEditor.SelectedIndex < 0)
            {
                stockMngTtlSt.LotUseDivCd = 0;
            }
            else
            {
                stockMngTtlSt.LotUseDivCd = this.LotUseDivCd_tComboEditor.SelectedIndex;
            }

            // 拠点表示区分
            if (this.SectDspDivCd_tComboEditor.SelectedIndex < 0)
            {
                stockMngTtlSt.SectDspDivCd = 0;
            }
            else
            {
                stockMngTtlSt.SectDspDivCd = this.SectDspDivCd_tComboEditor.SelectedIndex;
            }
            // --- ADD 2008/06/04 --------------------------------<<<<< 

            // --- ADD 2008/07/03 -------------------------------->>>>>
            if (tEdit_SectionCodeAllowZero2.Text != "")
            {
                // 拠点コードが0以外の場合、以下の項目は選択されない為、0にする
                if (Int32.Parse(tEdit_SectionCodeAllowZero2.Text) != 0)
                {
                    stockMngTtlSt.StockMoveFixCode = 0; // 在庫移動確定区分
                    stockMngTtlSt.StockPointWay = 0;    // 在庫評価方法
                    stockMngTtlSt.FractionProcCd = 0;   // 端数処理区分
                    // --- ADD 2009/12/02 ---------->>>>>
                    // 棚卸運用区分
                    stockMngTtlSt.InventoryMngDiv = 0;
                    // --- ADD 2009/12/02 ----------<<<<<
                    // ADD yangyi 2012/06/08 Redmine#30282 ------------->>>>>
                    stockMngTtlSt.PreStckCntDspDiv = 0;   // 現在庫表示区分
                    stockMngTtlSt.InvntryDtDelDiv = 0;    // 棚卸データ削除区分
                    // ADD yangyi 2012/06/08 Redmine#30282 -------------<<<<<
                    // --- ADD 三戸 2012/07/02 ---------->>>>>
                    // 移動時在庫自動登録区分
                    stockMngTtlSt.MoveStockAutoInsDiv = 0;
                    // --- ADD 三戸 2012/07/02 ----------<<<<<
                }
            }
            // --- ADD 2008/07/03 --------------------------------<<<<< 
        }

        /// <summary>
        /// 画面クリア処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面に一定の値を設定します。</br>
        /// <br>Programmer : 30005 木建　翼</br>
        /// <br>Date       : 2007.03.01</br>
        /// <br>Update Note: 2009/12/02 朱俊成 棚卸運用区分の追加</br>
        /// <br>Update Note: 2012/06/08 lanl</br>
        /// <br>             Redmine#30282「棚卸データ削除区分」を画面に追加</br>
        /// <br>Update Note: 2012/07/02 三戸　伸悟</br>
        /// <br>             「移動時在庫自動登録区分」を画面に追加　</br>
        /// <br>Update Note: 2014/10/27 wangf </br>
        /// <br>           : Redmine#43854画面に列「移動伝票出力先区分」追加</br>
        /// </remarks>
        private void ScreenClear()
        {
            // 在庫切れ出荷区分
            this.StockTolerncShipmDiv_tComboEditor.SelectedIndex = 0;

            // 棚卸印刷順初期設定区分
            this.InvntryPrtOdrIniDiv_tComboEditor.SelectedIndex = 0;

            // 最高在庫数超え発注区分
            this.MaxStkCntOverOderDiv_tComboEditor.SelectedIndex = 0;

            // --- DEL 2008/12/01 -------------------------------->>>>>
            //// 在庫移動確定区分
            //this.StockMoveFixCode_tComboEditor.SelectedIndex = 0;
            // --- DEL 2008/12/01 --------------------------------<<<<<
            // ---ADD(復活) 2009/06/03 -------------------------------->>>>>
            // 在庫移動確定区分
            this.StockMoveFixCode_tComboEditor.SelectedIndex = 0;
            // ---ADD(復活) 2009/06/03 --------------------------------<<<<<
            
            // 在庫管理有無区分初期表示値
            //this.StockMngExistCdDisp_tComboEditor.SelectedIndex = 0;  // DEL 2008/06/04

            // 製番管理区分初期表示値
            //this.PrdNumMngDivDisp_tComboEditor.SelectedIndex = 0;  // 2007.08.20 hikita del


            /****************************
             * 最適在庫条件区分は非表示 *
             ****************************/
            // 最適在庫条件区分


            // 在庫評価方法
            this.StockPointWay_tComboEditor.SelectedIndex = 0;

            // 端数処理区分
            this.FractionProcCd_tComboEditor.SelectedIndex = 0;  // ADD 2008/07/03

            // --- ADD 2009/12/02 ---------->>>>>
            // 棚卸運用区分
            this.InventoryMngDiv_tComboEditor.SelectedIndex = 0;
            // --- ADD 2009/12/02 ----------<<<<<
            // ---------------- ADD 2011/08/29 ---------------- >>>>>
            // 現在庫表示区分
            this.PreStckCntDspDiv_tComboEditor.SelectedIndex = 0;
            // ---------------- ADD 2011/08/29 ---------------- <<<<<

            // ---------------- ADD lanl 2012/06/08 Redmine#30282 ---------------- >>>>>
            // 棚卸データ削除区分
            this.InvntryDtDelDiv_tComboEditor.SelectedIndex = 0;
            // ---------------- ADD lanl 2012/06/08 Redmine#30282 ---------------- <<<<<

            // --- ADD 三戸 2012/07/02 ---------->>>>>
            // 移動時在庫自動登録区分
            this.MoveStockAutoInsDiv_tComboEditor.SelectedIndex = 0;
            // --- ADD 三戸 2012/07/02 ----------<<<<<
            // ------------ADD wangf 2014/10/27 FOR Redmine#43854 列「移動伝票出力先区分」追加--------->>>>
            // 移動伝票出力先区分
            this.MoveSlipOutPutDiv_tComboEditor.SelectedIndex = 0;
            // ------------ADD wangf 2014/10/27 FOR Redmine#43854 列「移動伝票出力先区分」追加---------<<<<

            // コード参照入力変更フラグ初期化
            //this._changeFlg = false;

            // --- ADD 2008/06/04 -------------------------------->>>>>
            this.tEdit_SectionCodeAllowZero2.Clear();                  // 拠点コード
            this.SectionNm_tEdit.Clear();                             // 拠点ガイド名称
            this.ShelfNoDuplDiv_tComboEditor.SelectedIndex = 0;       // 棚番重複区分
            this.LotUseDivCd_tComboEditor.SelectedIndex = 0;          // ロット使用区分
            this.SectDspDivCd_tComboEditor.SelectedIndex = 0;         // 拠点表示区分
            // --- ADD 2008/06/04 --------------------------------<<<<< 
        }

        // DEL 2008/06/04 -------------------------------->>>>>
        ///// <summary>
        ///// 保存処理
        ///// </summary>
        ///// <returns>結果</returns>
        ///// <remarks>
        ///// <br>Note       : 在庫管理全体選択の保存を行います。</br>
        ///// <br>Programmer : 30005 木建　翼</br>
        ///// <br>Date       : 2007.03.01</br>
        ///// </remarks>
        //private bool SaveProc()
        //{
        //    bool result = false;

        //    // 検索用パラメータクラス初期化
        //    this._stockMngTtlSt = new StockMngTtlSt();
        //    // 保存パラメータ用リスト
        //    ArrayList stockMngTtlStList = new ArrayList();

        //    // Read時に取得したデータを検索用クラスに格納
        //    this._stockMngTtlSt = this._stockMngTtlStClone;

        //    // 画面から在庫管理全体設定のデータを取得し、検索用パラメータにセット(上書き)
        //    ScreenToStockMngTtlSt(ref this._stockMngTtlSt);

        //    // 保存用リストにそのまま格納
        //    stockMngTtlStList.Add(this._stockMngTtlSt.Clone());

        //    int status = 0;
        //    status = this._stockMngTtlStAcs.Write(ref stockMngTtlStList);

        //    switch (status)
        //    {
        //        case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
        //            {
        //                break;
        //            }

        //        // * 1件しかないものなので常に更新処理が行なわれる *
        //        case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE:
        //            {
        //                //コード重複
        //                TMsgDisp.Show(
        //                    this, 									// 親ウィンドウフォーム
        //                    emErrorLevel.ERR_LEVEL_INFO, 			// エラーレベル
        //                    "MAZAI09110U", 							// アセンブリＩＤまたはクラスＩＤ
        //                    "このコードは既に使用されています。", 	// 表示するメッセージ
        //                    0, 										// ステータス値
        //                    MessageBoxButtons.OK);					// 表示するボタン
        //                return result;
        //            }

        //        // 排他制御
        //        case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
        //        case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
        //            {
        //                ExclusiveTransaction(status, true);
        //                return result;
        //            }
        //        default:
        //            {
        //                // 登録失敗
        //                TMsgDisp.Show(
        //                    this, 								// 親ウィンドウフォーム
        //                    emErrorLevel.ERR_LEVEL_STOP, 		// エラーレベル
        //                    "MAKHN09110U", 						// アセンブリＩＤまたはクラスＩＤ
        //                    "在庫管理全体設定",					// プログラム名称
        //                    "SaveProc",							// 処理名称
        //                    TMsgDisp.OPE_UPDATE, 				// オペレーション
        //                    "登録に失敗しました。", 			// 表示するメッセージ
        //                    status, 							// ステータス値
        //                    this._stockMngTtlStAcs, 				// エラーが発生したオブジェクト
        //                    MessageBoxButtons.OK, 				// 表示するボタン
        //                    MessageBoxDefaultButton.Button1);	// 初期表示ボタン
        //                CloseForm(DialogResult.Cancel);
        //                return result;
        //            }
        //    }

        //    result = true;
        //    return result;
        //}

        ///// <summary>
        ///// フレーム表示項目変換処理
        ///// </summary>
        ///// <returns>結果</returns>
        ///// <remarks>
        ///// <br>Note       : 取得したデータをHTMLに表示する名称に変換を行います。</br>
        ///// <br>Programmer : 30005 木建　翼</br>
        ///// <br>Date       : 2007.03.01</br>
        ///// </remarks>
        //private string[] ConvertParamIntoString()
        //{
        //    string[] strParamList = new string[DisplayCount];

        //    // 在庫移動確定区分
        //    switch(this._stockMngTtlSt.StockMoveFixCode)
        //    {
        //        case 1:
        //            strParamList[0] = "出荷確定あり";
        //            break;
        //        case 2:
        //            strParamList[0] = "出荷確定なし";
        //            break;
        //    }

        //    // 在庫管理有無区分初期表示値
        //    switch(this._stockMngTtlSt.StockMngExistCdDisp)
        //    {
        //        case 0:
        //            strParamList[1] = "在庫管理する";
        //            break;
        //        case 1:
        //            strParamList[1] = "在庫管理しない";
        //            break;
        //    }

        //    // 製番管理区分初期表示値
        //    // 2007.08.20 hikita del start ------------------------------->>
        //    //switch(this._stockMngTtlSt.PrdNumMngDivDisp)
        //    //{
        //    //    case 0:
        //    //        strParamList[5] = "有";
        //    //        break;
        //    //    case 1:
        //    //        strParamList[5] = "無";
        //    //        break;
        //    //}
        //    // 2007.08.20 hikita del end ---------------------------------<<

        //    // 在庫自動登録区分
        //    switch(this._stockMngTtlSt.AutoEntryStockCd)
        //    {
        //        case 0:
        //            // 2007.08.20 hikita upd start ------------------------------->>
        //            //strParamList[6] = "自動登録する";
        //            strParamList[2] = "自動登録する";
        //            // 2007.08.20 hikita upd end ---------------------------------<<
        //            break;
        //        case 1:
        //            // 2007.08.20 hikita upd start ------------------------------->>
        //            //strParamList[6] = "自動登録しない";
        //            strParamList[2] = "自動登録しない";
        //            // 2007.08.20 hikita upd end ---------------------------------<<
        //            break;
        //    }

        //    /*** 2007.03.02 deleted by T-Kidate *** 
        //    // 最適在庫条件区分(使用しない)
        //    switch(this._stockMngTtlSt.BeatStockCondCd)
        //    {
        //        case 1:
        //            strParamList[7] = "";
        //            break;
        //        case 2:
        //            strParamList[7] = "";
        //            break;
        //    }
        //    **************************************/

        //    // 在庫評価方法
        //    switch(this._stockMngTtlSt.StockPointWay)
        //    {
        //        /*** 2007.03.02 modified by T-Kidate ***
        //        case 1:
        //            strParamList[8] = "最終仕入原価法";
        //            break;
        //        case 2:
        //            strParamList[8] = "移動平均法";
        //            break;
        //        case 3:
        //            strParamList[0] = "個別単価法";
        //            break;
        //         */
        //        case 1:
        //            // 2007.08.20 hikita upd start ------------------------------->>
        //            //strParamList[7] = "最終仕入原価法";
        //            strParamList[3] = "最終仕入原価法";
        //            // 2007.08.20 hikita upd end ---------------------------------<<
        //            break;
        //        case 2:
        //            // 2007.08.20 hikita upd start ------------------------------->>
        //            //strParamList[7] = "移動平均法";
        //            strParamList[3] = "移動平均法";
        //            // 2007.08.20 hikita upd end ---------------------------------<<
        //            break;
        //        case 3:
        //            // 2007.08.20 hikita upd start ------------------------------->>
        //            //strParamList[7] = "個別単価法";
        //            strParamList[3] = "個別単価法";
        //            // 2007.08.20 hikita upd end ---------------------------------<<
        //            break;
        //    }
        //    // 在庫切れ出荷区分　　　　
        //    switch (this._stockMngTtlSt.StockTolerncShipmDiv)
        //    {
        //        case 0:
        //            strParamList[4] = "なし";
        //            break;
        //        case 1:
        //            strParamList[4] = "警告";
        //            break;
        //        case 2:
        //            strParamList[4] = "警告+再入力";
        //            break;
        //        case 3:
        //            strParamList[4] = "再入力";
        //            break;
        //    }
        //    // 棚卸印刷順初期設定区分   
        //    switch (this._stockMngTtlSt.InvntryPrtOdrIniDiv)
        //    {
        //        case 0:
        //            strParamList[5] = "棚番順";
        //            break;
        //        case 1:
        //            strParamList[5] = "仕入先順";
        //            break;
        //        case 2:
        //            strParamList[5] = "BLコード順";
        //            break;
        //        case 3:
        //            strParamList[5] = "ﾒｰｶｰｺｰﾄﾞ順";
        //            break;
        //        case 4:
        //            strParamList[5] = "仕入先・棚番順";
        //            break;
        //        case 5:
        //            strParamList[5] = "仕入先・ﾒｰｶｰ順";
        //            break;
        //    }
        //    // 最高在庫数超え発注区分
        //    switch(this._stockMngTtlSt.MaxStkCntOverOderDiv)
        //    {
        //        case 0:
        //            strParamList[6] = "しない";
        //            break;
        //        case 1:
        //            strParamList[6] = "する";
        //            break;
        //    }

        //    // 2007.03.27 DANJO ADD START
        //    // 端数処理区分
        //    //switch (this._stockMngTtlSt.FractionProcCd)
        //    //{
        //    //    case 0:
        //    //        // 2007.08.20 hikita upd start ------------------------------->>
        //    //        //strParamList[8] = "処理しない";
        //    //        strParamList[7] = "処理しない";
        //    //        // 2007.08.20 hikita upd end ---------------------------------<<
        //    //        break;
        //    //    case 11:
        //    //        // 2007.08.20 hikita upd start ------------------------------->>
        //    //        //strParamList[8] = "下一桁切り捨て";
        //    //        strParamList[7] = "下一桁切り捨て";
        //    //        // 2007.08.20 hikita upd end ---------------------------------<<
        //    //        break;
        //    //    case 12:
        //    //        // 2007.08.20 hikita upd start ------------------------------->>
        //    //        //strParamList[8] = "下一桁四捨五入";
        //    //        strParamList[7] = "下一桁四捨五入";
        //    //        // 2007.08.20 hikita upd end ---------------------------------<<
        //    //        break;
        //    //    case 13:
        //    //        // 2007.08.20 hikita upd start ------------------------------->>
        //    //        //strParamList[8] = "下一桁切り上げ";
        //    //        strParamList[7] = "下一桁切り上げ";
        //    //        // 2007.08.20 hikita upd end ---------------------------------<<
        //    //        break;
        //    //    case 21:
        //    //        // 2007.08.20 hikita upd start ------------------------------->>
        //    //        //strParamList[8] = "下二桁切り捨て";
        //    //        strParamList[7] = "下二桁切り捨て";
        //    //        // 2007.08.20 hikita upd end ---------------------------------<<
        //    //        break;
        //    //    case 22:
        //    //        // 2007.08.20 hikita upd start ------------------------------->>
        //    //        //strParamList[8] = "下二桁四捨五入";
        //    //        strParamList[7] = "下二桁四捨五入";
        //    //        // 2007.08.20 hikita upd end ---------------------------------<<
        //    //        break;
        //    //    case 23:
        //    //        // 2007.08.20 hikita upd start ------------------------------->>
        //    //        //strParamList[8] = "下二桁切り上げ";
        //    //        strParamList[7] = "下二桁切り上げ";
        //    //        // 2007.08.20 hikita upd end ---------------------------------<<
        //    //        break;
        //    //    case 31:
        //    //        // 2007.08.20 hikita upd start ------------------------------->>
        //    //        //strParamList[8] = "下三桁切り捨て";
        //    //        strParamList[7] = "下三桁切り捨て";
        //    //        // 2007.08.20 hikita upd end ---------------------------------<<
        //    //        break;
        //    //    case 32:
        //    //        // 2007.08.20 hikita upd start ------------------------------->>
        //    //        //strParamList[8] = "下三桁四捨五入";
        //    //        strParamList[7] = "下三桁四捨五入";
        //    //        // 2007.08.20 hikita upd end ---------------------------------<<
        //    //        break;
        //    //    case 33:
        //    //        // 2007.08.20 hikita upd start ------------------------------->>
        //    //        //strParamList[8] = "下三桁切り上げ";
        //    //        strParamList[7] = "下三桁切り上げ";
        //    //        // 2007.08.20 hikita upd end ---------------------------------<<
        //    //        break;
        //    //    case -11:
        //    //        // 2007.08.20 hikita upd start ------------------------------->>
        //    //        //strParamList[8] = "円未満切り捨て";
        //    //        strParamList[7] = "円未満切り捨て";
        //    //        // 2007.08.20 hikita upd end ---------------------------------<<
        //    //        break;
        //    //    case -12:
        //    //        // 2007.08.20 hikita upd start ------------------------------->>
        //    //        //strParamList[8] = "円未満四捨五入";
        //    //        strParamList[7] = "円未満四捨五入";
        //    //        // 2007.08.20 hikita upd end ---------------------------------<<
        //    //        break;
        //    //    case -13:
        //    //        // 2007.08.20 hikita upd start ------------------------------->>
        //    //        //strParamList[8] = "円未満切り上げ";
        //    //        strParamList[7] = "円未満切り上げ";
        //    //        // 2007.08.20 hikita upd end ---------------------------------<<
        //    //        break;
        //    //}
        //    // 2007.03.27 DANJO ADD END

        //    return strParamList;
        //}
        // DEL 2008/06/04 --------------------------------<<<<< 

        /// <summary>
        /// 在庫管理全体設定保存処理
        /// </summary>
        /// <returns>結果</returns>
        /// <remarks>
        /// <br>Note       : 在庫管理全体設定の保存を行います。</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/04</br>
        /// <br>Update Note : 2011/09/08 田建委</br>
        /// <br>              障害報告 #24169 全社共通の編集　</br>   
        /// </remarks>
        private bool SaveProc()
        {
            bool result = false;

            // 入力チェック
            Control control = null;
            string message = null;
            if (!ScreenDataCheck(ref control, ref message))
            {
                // 入力チェック
                TMsgDisp.Show(
                    this, 								// 親ウィンドウフォーム
                    emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
                    "MAZAI09110U", 						// アセンブリＩＤまたはクラスＩＤ
                    message, 							// 表示するメッセージ
                    0, 									// ステータス値
                    MessageBoxButtons.OK);				// 表示するボタン
                control.Focus();
                if (control is TNedit)
                {
                    ((TNedit)control).SelectAll();
                }
                else if (control is TEdit)
                {
                    ((TEdit)control).SelectAll();
                }
                return result;
            }

            // ----- ADD 2011/09/08 ---------->>>>>
            // 拠点
            if (this.tEdit_SectionCodeAllowZero2.Focused)
            {
                ChangeFocusEventArgs eArgs = new ChangeFocusEventArgs(false, false, false, Keys.Enter, this.tEdit_SectionCodeAllowZero2, this.tEdit_SectionCodeAllowZero2);
                this.tEdit_SectionCodeAllowZero2.Text = this.tEdit_SectionCodeAllowZero2.Text.PadLeft(2, '0');
                tRetKeyControl1_ChangeFocus(null, eArgs);
                if (isError == true)
                {
                    result = false;
                    return result;
                }
            }
            // ----- ADD 2011/09/08 ----------<<<<<

            StockMngTtlSt stockMngTtlSt = null;
            if (this._dataIndex >= 0)
            {
                Guid guid = (Guid)this.Bind_DataSet.Tables[STOCKMNGTTLST_TABLE].Rows[this._dataIndex][GUID_TITLE];
                stockMngTtlSt = ((StockMngTtlSt)this._stockMngTtlStTable[guid]).Clone();
            }
            DispToStockMngTtlSt(ref stockMngTtlSt);

            // ----- DEL 2011/09/08 ----------------------->>>>>
            // ADD 2008/09/19 不具合対応による共通仕様の展開 ---------->>>>>
            //// 拠点コードが存在していない場合、登録しない。
            //if (!SectionUtil.ExistsCode(stockMngTtlSt.SectionCode))
            //{
            //    TMsgDisp.Show(
            //        this, 								                    // 親ウィンドウフォーム
            //        emErrorLevel.ERR_LEVEL_EXCLAMATION,                     // エラーレベル
            //        AssemblyUtil.GetName(Assembly.GetExecutingAssembly()),  // アセンブリＩＤまたはクラスＩＤ
            //        this.Text, 		                                        // プログラム名称
            //        MethodBase.GetCurrentMethod().Name, 					// 処理名称
            //        TMsgDisp.OPE_UPDATE, 				                    // オペレーション
            //        SectionUtil.MSG_SECTION_CODE_IS_NOT_FOUND,              // 表示するメッセージ
            //        (int)ConstantManagement.MethodResult.ctFNC_NORMAL, 		// ステータス値
            //        this,			                                        // エラーが発生したオブジェクト
            //        MessageBoxButtons.OK, 				                    // 表示するボタン
            //        MessageBoxDefaultButton.Button1                         // 初期表示ボタン
            //    );
            //    return false;
            //}
            // ADD 2008/09/19 不具合対応による共通仕様の展開 ----------<<<<<
            // ----- DEL 2011/09/08 -----------------------<<<<<

            int status = this._stockMngTtlStAcs.Write(ref stockMngTtlSt);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // VIEWのデータセットを更新
                        // ADD 2008/10/14 不具合対応[6408]---------->>>>>
                        if (IsAllSection(stockMngTtlSt))
                        {
                            this.Bind_DataSet.Tables[STOCKMNGTTLST_TABLE].Clear();
                            this._stockMngTtlStTable.Clear();
                            int totalCount = 0;
                            const int READ_COUNT = 0;
                            SearchStockMngTtlSt(ref totalCount, READ_COUNT);
                            break;
                        }
                        // ADD 2008/10/14 不具合対応[6408]----------<<<<<

                        StockMngTtlStToDataSet(stockMngTtlSt.Clone(), this._dataIndex);
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE:
                    {
                        // コード重複
                        TMsgDisp.Show(
                            this, 									// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_INFO, 			// エラーレベル
                            "MAZAI09110U", 							// アセンブリＩＤまたはクラスＩＤ
                            "このコードは既に使用されています。", 	// 表示するメッセージ
                            0, 										// ステータス値
                            MessageBoxButtons.OK);					// 表示するボタン
                        tEdit_SectionCodeAllowZero2.Focus();                  
                        return result;
                    }
                // 排他制御
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        ExclusiveTransaction(status, true);
                        return result;
                    }
                default:
                    {
                        // 登録失敗
                        TMsgDisp.Show(
                            this, 								// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOP, 		// エラーレベル
                            "MAZAI09110U", 						// アセンブリＩＤまたはクラスＩＤ
                            "在庫管理全体設定", 				// プログラム名称
                            "SaveProc", 						// 処理名称
                            TMsgDisp.OPE_UPDATE, 				// オペレーション
                            "登録に失敗しました。", 			// 表示するメッセージ
                            status, 							// ステータス値
                            this._stockMngTtlStAcs,			    // エラーが発生したオブジェクト
                            MessageBoxButtons.OK, 				// 表示するボタン
                            MessageBoxDefaultButton.Button1);	// 初期表示ボタン
                        CloseForm(DialogResult.Cancel);
                        return result;
                    }
            }

            result = true;
            return result;
        }

        /// <summary>
        /// 画面入力情報不正チェック処理
        /// </summary>
        /// <param name="control">不正対象コントロール</param>
        /// <param name="message">メッセージ</param>
        /// <returns>チェック結果(true:OK／false:NG)</returns>
        /// <remarks>
        /// <br>Note       : 画面入力の不正チェックを行います。</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/04</br>
        /// </remarks>
        private bool ScreenDataCheck(ref Control control, ref string message)
        {
            bool result = true;

            // 拠点コード
            if (this.tEdit_SectionCodeAllowZero2.DataText == "")
            {
                message = this.SectionCode_Title_Label.Text + "を設定して下さい。";
                control = this.tEdit_SectionCodeAllowZero2;
                result = false;
            }

            return result;
        }

        /// <summary>
        /// 在庫管理全体設定オブジェクト論理削除復活処理
        /// </summary>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 在庫管理全体設定オブジェクトの論理削除復活を行います</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/04</br>
        /// </remarks>
        private int Revival()
        {
            int status = 0;

            if ((this._dataIndex < 0) ||
                (this._dataIndex >= this.Bind_DataSet.Tables[STOCKMNGTTLST_TABLE].Rows.Count))
            {
                return -1;
            }

            // 情報取得
            Guid guid = (Guid)this.Bind_DataSet.Tables[STOCKMNGTTLST_TABLE].Rows[this._dataIndex][GUID_TITLE];
            StockMngTtlSt stockMngTtlSt = ((StockMngTtlSt)this._stockMngTtlStTable[guid]).Clone();

            // 在庫管理全体設定が存在していない
            if (stockMngTtlSt == null)
            {
                return -1;
            }

            status = this._stockMngTtlStAcs.Revival(ref stockMngTtlSt);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        StockMngTtlStToDataSet(stockMngTtlSt.Clone(), this._dataIndex);
                        break;
                    }
                // 排他制御
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        ExclusiveTransaction(status, true);
                        return status;
                    }
                default:
                    {
                        // 復活失敗
                        TMsgDisp.Show(
                            this, 								// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOP, 		// エラーレベル
                            "MAZAI09110U", 						// アセンブリＩＤまたはクラスＩＤ
                            "在庫管理全体設定", 				// プログラム名称
                            "Revival", 							// 処理名称
                            TMsgDisp.OPE_UPDATE, 				// オペレーション
                            "復活に失敗しました。", 			// 表示するメッセージ
                            status, 							// ステータス値
                            this._stockMngTtlStAcs, 			// エラーが発生したオブジェクト
                            MessageBoxButtons.OK, 				// 表示するボタン
                            MessageBoxDefaultButton.Button1);	// 初期表示ボタン
                        CloseForm(DialogResult.Cancel);
                        return status;
                    }
            }
            return status;
        }

        /// <summary>
        /// 在庫管理全体設定オブジェクト完全削除処理
        /// </summary>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 在庫管理全体設定ブジェクトの完全削除を行います</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/04</br>
        /// </remarks>
        private int PhysicalDelete()
        {
            int status = 0;

            if ((this._dataIndex < 0) ||
                (this._dataIndex >= this.Bind_DataSet.Tables[STOCKMNGTTLST_TABLE].Rows.Count))
            {
                return -1;
            }

            // 情報取得
            Guid guid = (Guid)this.Bind_DataSet.Tables[STOCKMNGTTLST_TABLE].Rows[this._dataIndex][GUID_TITLE];
            StockMngTtlSt stockMngTtlSt = (StockMngTtlSt)this._stockMngTtlStTable[guid];

            // 在庫管理全体設定が存在していない
            if (stockMngTtlSt == null)
            {
                return -1;
            }

            // ADD 2008/09/12 不具合対応[5290] ---------->>>>>
            // 拠点コードが全社共通の場合、削除不可
            if (IsAllSection(stockMngTtlSt))
            {
                TMsgDisp.Show(
                    this, 							                        // 親ウィンドウフォーム
                    emErrorLevel.ERR_LEVEL_INFO, 	                        // エラーレベル
                    AssemblyUtil.GetName(Assembly.GetExecutingAssembly()),  // アセンブリＩＤまたはクラスＩＤ
                    this.Text, 				                                // プログラム名称
                    MethodBase.GetCurrentMethod().Name,                     // 処理名称
                    TMsgDisp.OPE_DELETE, 				                    // TODO:オペレーション
                    SectionUtil.MSG_ALL_SECTION_CANNOT_BE_DELETED, 	        // 表示するメッセージ
                    status, 						                        // ステータス値
                    this,			                                        // エラーが発生したオブジェクト
                    MessageBoxButtons.OK, 			                        // 表示するボタン
                    MessageBoxDefaultButton.Button1                         // 初期表示ボタン
                );
                return status;
            }
            // ADD 2008/09/12 不具合対応[5290] ----------<<<<<

            status = this._stockMngTtlStAcs.Delete(stockMngTtlSt);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // ハッシュテーブルからデータを削除
                        this._stockMngTtlStTable.Remove((Guid)this.Bind_DataSet.Tables[STOCKMNGTTLST_TABLE].Rows[this._dataIndex][GUID_TITLE]);
                        // データセットからデータを削除
                        this.Bind_DataSet.Tables[STOCKMNGTTLST_TABLE].Rows[this._dataIndex].Delete();
                        break;
                    }
                // 排他制御
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        ExclusiveTransaction(status, true);
                        return status;
                    }
                default:
                    {
                        // 物理削除
                        TMsgDisp.Show(
                            this, 								// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOP, 		// エラーレベル
                            "MAZAI09110U", 						// アセンブリＩＤまたはクラスＩＤ
                            "在庫管理全体設定", 				// プログラム名称
                            "PhysicalDelete", 					// 処理名称
                            TMsgDisp.OPE_DELETE, 				// オペレーション
                            "削除に失敗しました。", 			// 表示するメッセージ
                            status, 							// ステータス値
                            this._stockMngTtlStAcs,			    // エラーが発生したオブジェクト
                            MessageBoxButtons.OK, 				// 表示するボタン
                            MessageBoxDefaultButton.Button1);	// 初期表示ボタン
                        CloseForm(DialogResult.Cancel);
                        return status;
                    }
            }
            return status;
        }

        /// <summary>
        /// 画面入力許可制御処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面の入力許可を制御します。</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/04</br>
        /// <br>Update Note: 2009/12/02 朱俊成 棚卸運用区分の追加</br>
        /// <br>Update Note: 2012/06/08 lanl</br>
        /// <br>             Redmine#30282「棚卸データ削除区分」を画面に追加</br>
        /// <br>Update Note: 2012/07/02 三戸　伸悟</br>
        /// <br>             「移動時在庫自動登録区分」を画面に追加　</br>
        /// <br>Update Note: 2014/10/27 wangf </br>
        /// <br>           : Redmine#43854画面に列「移動伝票出力先区分」追加</br>
        /// </remarks>
        private void ScreenInputPermissionControl()
        {
            switch (this._logicalDeleteMode)
            {
                case -1:
                    {
                        // 新規モード
                        this.Mode_Label.Text = INSERT_MODE;

                        // ボタンの表示
                        this.Ok_Button.Visible = true;
                        this.Cancel_Button.Visible = true;
                        this.Revive_Button.Visible = false;
                        this.Delete_Button.Visible = false;

                        // コントロールの表示設定
                        ScreenInputPermissionControl(true);

                        // --- ADD 2008/07/03 -------------------------------->>>>>
                        // --- DEL 2008/12/01 -------------------------------->>>>>
                        //this.StockMoveFixCode_tComboEditor.Enabled = false; // 在庫移動確定区分
                        // --- DEL 2008/12/01 --------------------------------<<<<<
                        // ---ADD(復活) 2009/06/03 -------------------------------->>>>>
                        this.StockMoveFixCode_tComboEditor.Enabled = false; // 在庫移動確定区分
                        // ---ADD(復活) 2009/06/03 --------------------------------<<<<<
                        this.StockPointWay_tComboEditor.Enabled = false;    // 在庫評価方法
                        this.FractionProcCd_tComboEditor.Enabled = false;   // 端数処理区分
                        // --- ADD 2009/12/02 ---------->>>>>
                        // 棚卸運用区分
                        this.InventoryMngDiv_tComboEditor.Enabled = false;
                        // --- ADD 2009/12/02 ----------<<<<<
                        // -------------- ADD 2011/08/29 ----------------- >>>>>
                        // 現在庫表示区分
                        this.PreStckCntDspDiv_tComboEditor.Enabled = false;
                        // -------------- ADD 2011/08/29 ----------------- <<<<<
                        // -------------- ADD lanl 2012/06/08 Redmine#30282 ----------------- >>>>>
                        // 棚卸データ削除区分
                        this.InvntryDtDelDiv_tComboEditor.Enabled = false;
                        // -------------- ADD lanl 2012/06/08 Redmine#30282 ----------------- <<<<<
                        // --- ADD 三戸 2012/07/02 ---------->>>>>
                        // 移動時在庫自動登録区分
                        this.MoveStockAutoInsDiv_tComboEditor.Enabled = false;
                        // --- ADD 三戸 2012/07/02 ----------<<<<<
                        // ちらつき防止の為
                        this.Enabled = true;
                        // --- ADD 2008/07/03 --------------------------------<<<<< 

                        // 初期フォーカスをセット
                        this.tEdit_SectionCodeAllowZero2.Focus();

                        // 拠点コードのコメント表示
                        SectionNm_Label.Visible = true;

                        break;
                    }
                case 1:
                    {
                        // 削除モード
                        this.Mode_Label.Text = DELETE_MODE;

                        // ボタンの表示
                        this.Ok_Button.Visible = false;
                        this.Cancel_Button.Visible = true;
                        this.Revive_Button.Visible = true;
                        this.Delete_Button.Visible = true;

                        // コントロールの表示設定
                        ScreenInputPermissionControl(false);

                        // ちらつき防止の為
                        this.Enabled = true;

                        // 初期フォーカスをセット
                        this.Delete_Button.Focus();

                        // 拠点コードのコメント非表示
                        SectionNm_Label.Visible = false;

                        break;
                    }
                default:
                    {
                        // 更新モード
                        this.Mode_Label.Text = UPDATE_MODE;

                        // ボタンの表示
                        this.Ok_Button.Visible = true;
                        this.Cancel_Button.Visible = true;
                        this.Revive_Button.Visible = false;
                        this.Delete_Button.Visible = false;

                        // コントロールの表示設定
                        ScreenInputPermissionControl(true);

                        // 拠点関係のコントロールを使用不可にする
                        this.tEdit_SectionCodeAllowZero2.Enabled = false;
                        this.SectionGd_ultraButton.Enabled = false;
                        this.SectionNm_tEdit.Enabled = false;

                        // ------------ADD wangf 2014/10/27 FOR Redmine#43854 列「移動伝票出力先区分」追加--------->>>>
                        // 移動伝票出力先区分
                        this.MoveSlipOutPutDiv_tComboEditor.Enabled = true;
                        // ------------ADD wangf 2014/10/27 FOR Redmine#43854 列「移動伝票出力先区分」追加---------<<<<

                        // --- ADD 2008/07/03 -------------------------------->>>>>
                        if (Int32.Parse(this.tEdit_SectionCodeAllowZero2.Text) == 0)
                        {
                            // --- DEL 2008/12/01 -------------------------------->>>>>
                            //this.StockMoveFixCode_tComboEditor.Enabled = true;  // 在庫移動確定区分
                            // --- DEL 2008/12/01 --------------------------------<<<<<
                            // ---ADD(復活) 2009/06/03 -------------------------------->>>>>
                            this.StockMoveFixCode_tComboEditor.Enabled = true;  // 在庫移動確定区分
                            // ---ADD(復活) 2009/06/03 --------------------------------<<<<<
                            // DEL 2009/01/16 不具合対応[9609]↓
                            //this.StockPointWay_tComboEditor.Enabled = true;     // 在庫評価方法
                            this.FractionProcCd_tComboEditor.Enabled = true;    // 端数処理区分
                            // --- ADD 2009/12/02 ---------->>>>>
                            // 棚卸運用区分
                            this.InventoryMngDiv_tComboEditor.Enabled = true;
                            // --- ADD 2009/12/02 ----------<<<<<
                            // -------------------- ADD 2011/08/29 ------------------- >>>>>
                            // 現在庫表示区分
                            if (this.InventoryMngDiv_tComboEditor.SelectedIndex == 0)
                            {
                                this.PreStckCntDspDiv_tComboEditor.Enabled = false;
                            }
                            else if (this.InventoryMngDiv_tComboEditor.SelectedIndex == 1)
                            {
                                this.PreStckCntDspDiv_tComboEditor.Enabled = true;
                            }
                            // -------------------- ADD 2011/08/29 ------------------- <<<<<
                            // -------------------- ADD lanl 2012/06/08 Redmine#30282 ------------------- >>>>>
                            // 棚卸データ削除区分
                            this.InvntryDtDelDiv_tComboEditor.Enabled = true;
                            // -------------------- ADD lanl 2012/06/08 Redmine#30282 ------------------- <<<<<
                            // --- ADD 三戸 2012/07/02 ---------->>>>>
                            // 移動時在庫自動登録区分
                            this.MoveStockAutoInsDiv_tComboEditor.Enabled = true;
                            // --- ADD 三戸 2012/07/02 ----------<<<<<
                        }
                        else
                        {
                            // --- DEL 2008/12/01 -------------------------------->>>>>
                            //this.StockMoveFixCode_tComboEditor.Enabled = false; // 在庫移動確定区分
                            // --- DEL 2008/12/01 --------------------------------<<<<<
                            // ---ADD(復活) 2009/06/03 -------------------------------->>>>>
                            this.StockMoveFixCode_tComboEditor.Enabled = false; // 在庫移動確定区分
                            // ---ADD(復活) 2009/06/03 --------------------------------<<<<<
                            this.StockPointWay_tComboEditor.Enabled = false;    // 在庫評価方法
                            this.FractionProcCd_tComboEditor.Enabled = false;   // 端数処理区分
                            // --- ADD 2009/12/02 ---------->>>>>
                            // 棚卸運用区分
                            this.InventoryMngDiv_tComboEditor.Enabled = false;
                            // --- ADD 2009/12/02 ----------<<<<<
                            // ---------------- ADD 2011/08/29 -------------------- >>>>>
                            // 現在庫表示区分
                            this.PreStckCntDspDiv_tComboEditor.Enabled = false;
                            // ---------------- ADD 2011/08/29 -------------------- <<<<<
                            // ---------------- ADD lanl 2012/06/08 Redmine#30282 -------------------- >>>>>
                            // 棚卸データ削除区分
                            this.InvntryDtDelDiv_tComboEditor.Enabled = false;
                            // ---------------- ADD lanl 2012/06/08 Redmine#30282 -------------------- <<<<<
                            // --- ADD 三戸 2012/07/02 ---------->>>>>
                            // 移動時在庫自動登録区分
                            this.MoveStockAutoInsDiv_tComboEditor.Enabled = false;
                            // --- ADD 三戸 2012/07/02 ----------<<<<<
                        }

                        // ちらつき防止の為
                        this.Enabled = true;
                        // --- ADD 2008/07/03 --------------------------------<<<<< 

                        // 拠点コードのコメント非表示
                        SectionNm_Label.Visible = false;

                        // --- DEL 2008/12/01 -------------------------------->>>>>
                        //if (this.StockMoveFixCode_tComboEditor.Enabled == true)
                        //{
                        //    // 初期フォーカスをセット
                        //    this.StockMoveFixCode_tComboEditor.Focus();
                        //}
                        // --- DEL 2008/12/01 --------------------------------<<<<<
                        // --- ADD 2008/12/01 -------------------------------->>>>>
                        if (this.StockPointWay_tComboEditor.Enabled == true)
                        {
                            // 初期フォーカスをセット
                            this.StockPointWay_tComboEditor.Focus();
                        }
                        // --- ADD 2008/12/01 --------------------------------<<<<<
                        else
                        {
                            this.StockTolerncShipmDiv_tComboEditor.Focus();
                        }
                        

                        break;
                    }
            }
        }

        /// <summary>
        /// 画面入力許可制御処理
        /// </summary>
        /// <param name="enabled">入力許可設定値</param>
        /// <remarks>
        /// <br>Note       : 画面の入力許可を制御します。</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/04</br>
        /// <br>Update Note: 2009/12/02 朱俊成 棚卸運用区分の追加</br>
        /// <br>Update Note: 2012/06/08 lanl</br>
        /// <br>             Redmine#30282「棚卸データ削除区分」を画面に追加</br>
        /// <br>Update Note: 2012/07/02 三戸　伸悟</br>
        /// <br>             「移動時在庫自動登録区分」を画面に追加　</br>
        /// <br>Update Note: 2014/10/27 wangf </br>
        /// <br>           : Redmine#43854画面に列「移動伝票出力先区分」追加</br>
        /// </remarks>
        void ScreenInputPermissionControl(bool enabled)
        {
            this.tEdit_SectionCodeAllowZero2.Enabled = enabled;          // 拠点コード
            this.SectionGd_ultraButton.Enabled = enabled;               // ガイドボタン 
            this.SectionNm_tEdit.Enabled = enabled;                     // 拠点ガイド名称
            // --- DEL 2008/12/01 -------------------------------->>>>>
            //this.StockMoveFixCode_tComboEditor.Enabled = enabled;       // 在庫移動確定区分
            // --- DEL 2008/12/01 --------------------------------<<<<<
            // ---ADD(復活) 2009/06/03 -------------------------------->>>>>
            this.StockMoveFixCode_tComboEditor.Enabled = enabled;       // 在庫移動確定区分
            // ---ADD(復活) 2009/06/03 --------------------------------<<<<<
            this.StockTolerncShipmDiv_tComboEditor.Enabled = enabled;   // 在庫切れ出荷区分
            this.InvntryPrtOdrIniDiv_tComboEditor.Enabled = enabled;    // 棚卸印刷順初期設定区分
            // DEL 2009/01/19 不具合対応[9609]
            //this.StockPointWay_tComboEditor.Enabled = enabled;          // 在庫評価方法
            this.MaxStkCntOverOderDiv_tComboEditor.Enabled = enabled;   // 最高在庫数超え発注区分
            this.ShelfNoDuplDiv_tComboEditor.Enabled = enabled;         // 棚番重複区分
            this.LotUseDivCd_tComboEditor.Enabled = enabled;            // ロット使用区分
            this.SectDspDivCd_tComboEditor.Enabled = enabled;           // 拠点表示区分
            this.FractionProcCd_tComboEditor.Enabled = enabled;         // 端数処理区分  // ADD 2008/07/03
            // --- ADD 2009/12/02 ---------->>>>>
            // 棚卸運用区分
            this.InventoryMngDiv_tComboEditor.Enabled = enabled;
            // --- ADD 2009/12/02 ----------<<<<<
            // ------------- ADD 2011/08/29 ------------ >>>>>
            // 現在庫表示区分
            this.PreStckCntDspDiv_tComboEditor.Enabled = enabled;
            // ------------- ADD 2011/08/29 ------------ <<<<<
            // ------------- ADD lanl 2012/06/08 Redmine#30282 ------------ >>>>>
            // 棚卸データ削除区分 
            this.InvntryDtDelDiv_tComboEditor.Enabled = enabled;
            // ------------- ADD lanl 2012/06/08 Redmine#30282 ------------ <<<<<
            // --- ADD 三戸 2012/07/02 ---------->>>>>
            // 移動時在庫自動登録区分
            this.MoveStockAutoInsDiv_tComboEditor.Enabled = enabled;
            // --- ADD 三戸 2012/07/02 ----------<<<<<
            // ------------ADD wangf 2014/10/27 FOR Redmine#43854 列「移動伝票出力先区分」追加--------->>>>
            // 移動伝票出力先区分
            this.MoveSlipOutPutDiv_tComboEditor.Enabled = enabled;
            // ------------ADD wangf 2014/10/27 FOR Redmine#43854 列「移動伝票出力先区分」追加---------<<<<
        }

        /// <summary>
        /// 拠点名称取得処理
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <returns>拠点名称</returns>
        /// <remarks>
        /// <br>Note       : 拠点名称を取得します。</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/04</br>
        /// </remarks>
        /// 
        private string GetSectionName(string sectionCode)
        {
            string sectionName = "";

            ArrayList retList = new ArrayList();
            SecInfoAcs secInfoAcs = new SecInfoAcs();
            secInfoAcs.ResetSectionInfo();

            try
            {
                foreach (SecInfoSet secInfoSet in secInfoAcs.SecInfoSetList)
                {
                    if (secInfoSet.SectionCode.Trim() == sectionCode.Trim().PadLeft(2, '0'))
                    {
                        sectionName = secInfoSet.SectionGuideNm.Trim();
                        return sectionName;
                    }
                }
            }
            catch
            {
                sectionName = "";
            }

            return sectionName;
        }

        /// <summary>
        /// データ検索処理
        /// </summary>
        /// <param name="totalCnt">全該当件数</param>
        /// <param name="readCnt">抽出対象件数</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : データを検索し、抽出結果を展開したデータセットと全該当件数を返します。</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/04</br>
        /// </remarks>
        private int SearchStockMngTtlSt(ref int totalCnt, int readCnt)
        {
            int status = 0;
            ArrayList stockMngTtlSts = null;

            // 抽出対象件数が0件の場合は全件抽出を実行する
            status = this._stockMngTtlStAcs.SearchAll(out stockMngTtlSts, this._enterpriseCode);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        int index = 0;
                        foreach (StockMngTtlSt stockMngTtlSt in stockMngTtlSts)
                        {
                            // ADD 2008/09/16 不具合対応[5130] ---------->>>>>
                            // 全社設定の値を保持
                            if (IsAllSection(stockMngTtlSt))
                            {
                                StockMngTtlStOfAllSection = stockMngTtlSt;
                            }
                            // ADD 2008/09/16 不具合対応[5130] ----------<<<<<

                            if (this._stockMngTtlStTable.ContainsKey(stockMngTtlSt.FileHeaderGuid) == false)
                            {
                                StockMngTtlStToDataSet(stockMngTtlSt.Clone(), index);
                                index++;
                            }
                        }

                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    {
                        break;
                    }
                default:
                    {
                        // サーチ
                        TMsgDisp.Show(
                            this, 								// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOP, 		// エラーレベル
                            "MAZAI09110U", 						// アセンブリＩＤまたはクラスＩＤ
                            "在庫管理全体設定", 			    // プログラム名称
                            "SearchStockMngTtlSt", 			    // 処理名称
                            TMsgDisp.OPE_GET, 					// オペレーション
                            "読み込みに失敗しました。", 		// 表示するメッセージ
                            status, 							// ステータス値
                            this._stockMngTtlStAcs, 			// エラーが発生したオブジェクト
                            MessageBoxButtons.OK, 				// 表示するボタン
                            MessageBoxDefaultButton.Button1);	// 初期表示ボタン

                        break;
                    }
            }

            totalCnt = stockMngTtlSts.Count;

            return status;
        }

        /// <summary>
        /// 在庫管理全体設定オブジェクト展開処理
        /// </summary>
        /// <param name="stockMngTtlSt">在庫管理全体設定オブジェクト</param>
        /// <param name="index">データセットへ展開するインデックス</param>
        /// <remarks>
        /// <br>Note       : 在庫管理全体設定クラスをDataSetに格納します。</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/04</br>
        /// <br>Update Note: 2009/12/02 朱俊成 棚卸運用区分の追加</br>
        /// <br>Update Note: 2012/06/08 lanl</br>
        /// <br>             Redmine#30282「棚卸データ削除区分」を画面に追加</br>
        /// <br>Update Note: 2012/07/02 三戸　伸悟</br>
        /// <br>             「移動時在庫自動登録区分」を画面に追加　</br>
        /// <br>Update Note: 2014/10/27 wangf </br>
        /// <br>           : Redmine#43854画面に列「移動伝票出力先区分」追加</br>
        /// </remarks>
        private void StockMngTtlStToDataSet(StockMngTtlSt stockMngTtlSt, int index)
        {
            string wrkstr;

            if ((index < 0) || (index >= this.Bind_DataSet.Tables[STOCKMNGTTLST_TABLE].Rows.Count))
            {
                // 新規と判断し、行を追加する。
                DataRow dataRow = this.Bind_DataSet.Tables[STOCKMNGTTLST_TABLE].NewRow();
                this.Bind_DataSet.Tables[STOCKMNGTTLST_TABLE].Rows.Add(dataRow);

                // indexを最終行番号にする
                index = this.Bind_DataSet.Tables[STOCKMNGTTLST_TABLE].Rows.Count - 1;
            }

            // 削除日
            if (stockMngTtlSt.LogicalDeleteCode == 0)
            {
                this.Bind_DataSet.Tables[STOCKMNGTTLST_TABLE].Rows[index][DELETE_DATE] = "";
            }
            else
            {
                this.Bind_DataSet.Tables[STOCKMNGTTLST_TABLE].Rows[index][DELETE_DATE] = stockMngTtlSt.UpdateDateTime;
            }

            // 拠点コード
            this.Bind_DataSet.Tables[STOCKMNGTTLST_TABLE].Rows[index][SECTIONCODE_TITLE] = stockMngTtlSt.SectionCode.TrimEnd();
            // 拠点名称
            foreach (SecInfoSet si in this._secInfoAcs.SecInfoSetList)
            {
                if (si.SectionCode.TrimEnd() == stockMngTtlSt.SectionCode.TrimEnd())
                {
                    this.Bind_DataSet.Tables[STOCKMNGTTLST_TABLE].Rows[index][SECTIONNAME_TITLE] = si.SectionGuideNm;
                    break;
                }
            }
            // ADD 2008/10/08 不具合対応[6407] ---------->>>>>
            if (stockMngTtlSt.SectionCode.Trim().Equals("00"))
            {
                this.Bind_DataSet.Tables[STOCKMNGTTLST_TABLE].Rows[index][SECTIONNAME_TITLE] = "全社共通";
            }
            // ADD 2008/10/08 不具合対応[6407] ----------<<<<<
            

            // 在庫移動確定区分
            // DEL 2008/09/16 不具合対応[5130] ---------->>>>>
            //switch (stockMngTtlSt.StockMoveFixCode)
            //{
            //    case 1:
            //        wrkstr = STOCKMOVEFIXCODE_YES;     // 出荷確定あり
            //        break;
            //    case 2:
            //        wrkstr = STOCKMOVEFIXCODE_NO;       // 出荷確定なし
            //        break;
            //    default:
            //        wrkstr = UNREGISTER;
            //        break;
            //}
            // DEL 2008/09/16 不具合対応[5130] ----------<<<<<
            wrkstr = GetStockMoveFixName(stockMngTtlSt.StockMoveFixCode);   // ADD 2008/09/16 不具合対応[5130]
            // --- DEL 2008/12/01 -------------------------------->>>>>
            //this.Bind_DataSet.Tables[STOCKMNGTTLST_TABLE].Rows[index][STOCKMOVEFIXCODE_TITLE] = wrkstr;
            // --- DEL 2008/12/01 --------------------------------<<<<<
            // ---ADD(復活) 2009/06/03 -------------------------------->>>>>
            this.Bind_DataSet.Tables[STOCKMNGTTLST_TABLE].Rows[index][STOCKMOVEFIXCODE_TITLE] = wrkstr;
            // ---ADD(復活) 2009/06/03 --------------------------------<<<<<

            // 在庫切れ出荷区分
            switch (stockMngTtlSt.StockTolerncShipmDiv)
            {
                case 0:
                    wrkstr = STOCKTOLERNCSHIPMDIV_NONE;       // 無し
                    break;
                case 1:
                    wrkstr = STOCKTOLERNCSHIPMDIV_WARNING;    // 警告
                    break;
                case 2:
                    wrkstr = STOCKTOLERNCSHIPMDIV_BOTH;       // 警告＋再入力
                    break;
                case 3:
                    wrkstr = STOCKTOLERNCSHIPMDIV_AGAIN;      // 再入力
                    break;
                default:
                    wrkstr = UNREGISTER;
                    break;
            }
            // DEL 2009/01/16 不具合対応[10151]↓
            //this.Bind_DataSet.Tables[STOCKMNGTTLST_TABLE].Rows[index][STOCKTOLERNCSHIPMDIV_TITLE] = wrkstr;


            // 棚卸印刷順初期設定区分
            switch (stockMngTtlSt.InvntryPrtOdrIniDiv)
            {
                case 0:
                    wrkstr = INVNTRYPRTODRINIDIV_SHELF;       // 棚番順
                    break;
                case 1:
                    wrkstr = INVNTRYPRTODRINIDIV_STOCKING;    // 仕入先順
                    break;
                case 2:
                    wrkstr = INVNTRYPRTODRINIDIV_BL;          // BLコード順
                    break;
                // --- ADD 2008/08/28 -------------------------------->>>>>
                case 3:
                    wrkstr = INVNTRYPRTODRINIDIV_GROUP;       // グループコード順
                    break;
                // --- ADD 2008/08/28 --------------------------------<<<<< 
                case 4:
                    wrkstr = INVNTRYPRTODRINIDIV_MAKER;       // メーカーコード順
                    break;
                case 5:
                    wrkstr = INVNTRYPRTODRINIDIV_STOCKBL;     // 仕入先・棚番順
                    break;
                case 6:
                    wrkstr = INVNTRYPRTODRINIDIV_STOCKMAKER;  // 仕入先・メーカー順
                    break;
                default:
                    wrkstr = UNREGISTER;
                    break;
            }
            this.Bind_DataSet.Tables[STOCKMNGTTLST_TABLE].Rows[index][INVNTRYPRTODRINIDIV_TITLE] = wrkstr;

            // 在庫評価方法
            // DEL 2008/09/16 不具合対応[5130] ---------->>>>>
            //switch (stockMngTtlSt.StockPointWay)
            //{
            //    case 1:
            //        wrkstr = STOCKPOINTWAY_LAST;       // 最終仕入原価法
            //        break;
            //    case 2:
            //        wrkstr = STOCKPOINTWAY_MOVE;       // 移動平均法
            //        break;
            //    default:
            //        wrkstr = UNREGISTER;
            //        break;
            //}
            // DEL 2008/09/16 不具合対応[5130] ----------<<<<<
            wrkstr = GetStockPointWayName(stockMngTtlSt.StockPointWay); // ADD 2008/09/16 不具合対応[5130]
            this.Bind_DataSet.Tables[STOCKMNGTTLST_TABLE].Rows[index][STOCKPOINTWAY_TITLE] = wrkstr;

            // 最高在庫数超え発注区分
            switch (stockMngTtlSt.MaxStkCntOverOderDiv)
            {
                case 0:
                    wrkstr = MAXSTKCNTOVERODERDIV_NO;       // しない
                    break;
                case 1:
                    wrkstr = MAXSTKCNTOVERODERDIV_YES;      // する
                    break;
                default:
                    wrkstr = UNREGISTER;
                    break;
            }
            this.Bind_DataSet.Tables[STOCKMNGTTLST_TABLE].Rows[index][MAXSTKCNTOVERODERDIV_TITLE] = wrkstr;

            // 棚番重複区分
            switch (stockMngTtlSt.ShelfNoDuplDiv)
            {
                case 0:
                    wrkstr = SHELFNODUPLDIV_POSS;         // 可能
                    break;
                case 1:
                    wrkstr = SHELFNODUPLDIV_IMPOSS;       // 不可
                    break;
                default:
                    wrkstr = UNREGISTER;
                    break;
            }
            this.Bind_DataSet.Tables[STOCKMNGTTLST_TABLE].Rows[index][SHELFNODUPLDIV_TITLE] = wrkstr;

            // ロット使用区分
            switch (stockMngTtlSt.LotUseDivCd)
            {
                case 0:
                    wrkstr = LOTUSEDIVCD_ORDER;         // 発注ロット
                    break;
                case 1:
                    wrkstr = LOTUSEDIVCD_CIRCULATE;     // 流通ロット
                    break;
                default:
                    wrkstr = UNREGISTER;
                    break;
            }
            this.Bind_DataSet.Tables[STOCKMNGTTLST_TABLE].Rows[index][LOTUSEDIVCD_TITLE] = wrkstr;

            // 拠点表示区分
            switch (stockMngTtlSt.SectDspDivCd)
            {
                case 0:
                    wrkstr = SECTDSPDIVCD_STORAGE;     // 倉庫マスタ
                    break;
                case 1:
                    wrkstr = SECTDSPDIVCD_OWN;         // 自社マスタ
                    break;
                case 2:
                    wrkstr = SECTDSPDIVCD_NONE;        // 表示無し
                    break;
                default:
                    wrkstr = UNREGISTER;
                    break;
            }
            this.Bind_DataSet.Tables[STOCKMNGTTLST_TABLE].Rows[index][SECTDSPDIVCD_TITLE] = wrkstr;

            // --- ADD 2008/07/03 -------------------------------->>>>>
            // DEL 2008/09/16 不具合対応[5130] ---------->>>>>
            // 端数処理区分
            //switch (stockMngTtlSt.FractionProcCd)
            //{
            //    case 1:
            //        wrkstr = FRACTIONPROCCD_CUT;          // 切捨て
            //        break;
            //    case 2:
            //        wrkstr = FRACTIONPROCCD_ROUND;        // 四捨五入
            //        break;
            //    case 3:
            //        wrkstr = FRACTIONPROCCD_REVALUATION;  // 切上げ
            //        break;
            //    default:
            //        wrkstr = UNREGISTER;
            //        break;
            //}
            // DEL 2008/09/16 不具合対応[5130] ----------<<<<<
            wrkstr = GetFractionProcName(stockMngTtlSt.FractionProcCd); // ADD 2008/09/16 不具合対応[5130]
            this.Bind_DataSet.Tables[STOCKMNGTTLST_TABLE].Rows[index][FRACTIONPROCCD_TITLE] = wrkstr;
            // --- ADD 2008/07/03 --------------------------------<<<<< 

            // --- ADD 2009/12/02 ---------->>>>>
            // 棚卸運用区分
            wrkstr = GetInventoryMngDivName(stockMngTtlSt.InventoryMngDiv);
            this.Bind_DataSet.Tables[STOCKMNGTTLST_TABLE].Rows[index][INVENTORYMNGDIV_TITLE] = wrkstr;
            // --- ADD 2009/12/02 ----------<<<<<

            // ---------------- ADD 2011/08/29 --------------------- >>>>>
            // 現在庫表示区分
            switch (StockMngTtlStOfAllSection.PreStckCntDspDiv)  
            {
                case (int)StockDisplayDiv.Yes:
                    wrkstr = STOCKDISPLAYDIV_YES;
                    break;
                case (int)StockDisplayDiv.No:
                    wrkstr = STOCKDISPLAYDIV_NO;
                    break;
                default:
                    wrkstr = UNREGISTER;
                    break;
            }
            this.Bind_DataSet.Tables[STOCKMNGTTLST_TABLE].Rows[index][STOCKDISPLAYDIV_TITLE] = wrkstr;
            // ---------------- ADD 2011/08/29 --------------------- <<<<<

            // ---------------- ADD lanl 2012/06/08 Redmine#30282 --------------------- >>>>>
            // 棚卸データ削除区分
            switch (StockMngTtlStOfAllSection.InvntryDtDelDiv)
            {
                case (int)InvntryDtDelDiv.Pos:
                    wrkstr = INVNTRYDTDELDIV_POS;
                    break;
                case (int)InvntryDtDelDiv.PosSec:
                    wrkstr = INVNTRYDTDELDIV_POSSEC;
                    break;
                case (int)InvntryDtDelDiv.ImPos:
                    wrkstr = INVNTRYDTDELDIV_IMPOS;
                    break;
                default:
                    wrkstr = UNREGISTER;
                    break;
            }
            this.Bind_DataSet.Tables[STOCKMNGTTLST_TABLE].Rows[index][INVNTRYDTDELDIV_TITLE] = wrkstr;
            // ---------------- ADD lanl 2012/06/08 Redmine#30282 --------------------- <<<<<
            // --- ADD 三戸 2012/07/02 ---------->>>>>
            // 移動時在庫自動登録区分
            switch (StockMngTtlStOfAllSection.MoveStockAutoInsDiv)
            {
                case (int)MoveStockAutoInsDiv.Yes:
                    wrkstr = MOVESTOCKAUTOINSDIV_YES;
                    break;
                case (int)MoveStockAutoInsDiv.No:
                    wrkstr = MOVESTOCKAUTOINSDIV_NO;
                    break;
                default:
                    wrkstr = UNREGISTER;
                    break;
            }
            this.Bind_DataSet.Tables[STOCKMNGTTLST_TABLE].Rows[index][MOVESTOCKAUTOINSDIV_TITLE] = wrkstr;
            // --- ADD 三戸 2012/07/02 ----------<<<<<
            // ------------ADD wangf 2014/10/27 FOR Redmine#43854 列「移動伝票出力先区分」追加--------->>>>
            // 移動伝票出力先区分
            switch (stockMngTtlSt.MoveSlipOutPutDiv)
            {
                case (int)MoveSlipOutPutDiv.In:
                    wrkstr = MOVESLIPOUTPUTDIV_IN;
                    break;
                case (int)MoveSlipOutPutDiv.Out:
                    wrkstr = MOVESLIPOUTPUTDIV_OUT;
                    break;
                default:
                    wrkstr = UNREGISTER;
                    break;
            }
            this.Bind_DataSet.Tables[STOCKMNGTTLST_TABLE].Rows[index][MOVESLIPOUTPUTDIV_TITLE] = wrkstr;
            // ------------ADD wangf 2014/10/27 FOR Redmine#43854 列「移動伝票出力先区分」追加---------<<<<
            // GUID
            this.Bind_DataSet.Tables[STOCKMNGTTLST_TABLE].Rows[index][GUID_TITLE] = stockMngTtlSt.FileHeaderGuid;

            if (this._stockMngTtlStTable.ContainsKey(stockMngTtlSt.FileHeaderGuid) == true)
            {
                this._stockMngTtlStTable.Remove(stockMngTtlSt.FileHeaderGuid);
            }
            this._stockMngTtlStTable.Add(stockMngTtlSt.FileHeaderGuid, stockMngTtlSt);

        }

        // ADD 2008/09/16 不具合対応[5130] ---------->>>>>
        /// <summary>
        /// 在庫移動確定区分の名称を取得します。
        /// （設定がない場合は全社設定と同じ値を返します）
        /// </summary>
        /// <param name="stockMoveFixCode">在庫移動確定区分</param>
        /// <returns>在庫移動確定区分の名称</returns>
        /// <remarks>
        /// <br>Note       : 不具合対応[5130]にて追加</br>
        /// <br>Programmer : 30434 工藤 恵優</br>
        /// <br>Date       : 2008/09/16</br>
        /// </remarks>
        private string GetStockMoveFixName(int stockMoveFixCode)
        {
            switch (stockMoveFixCode)
            {
                case (int)StockMoveFixCode.Yes: // 入荷確定あり
                    return STOCKMOVEFIXCODE_YES;

                case (int)StockMoveFixCode.No:  // 入荷確定なし
                    return STOCKMOVEFIXCODE_NO;

                default:    // 設定がない場合は全社設定と同じ
                    switch (StockMngTtlStOfAllSection.StockMoveFixCode)
                    {
                        case (int)StockMoveFixCode.Yes: // 入荷確定あり
                            return STOCKMOVEFIXCODE_YES;

                        case (int)StockMoveFixCode.No:  // 入荷確定なし
                            return STOCKMOVEFIXCODE_NO;

                        default:
                            return UNREGISTER;
                    }
            }
        }

        /// <summary>
        /// 在庫評価方法の名称を取得します。
        /// （設定がない場合は全社設定と同じ値を返します）
        /// </summary>
        /// <param name="stockPointWay">在庫評価方法</param>
        /// <returns>在庫評価方法の名称</returns>
        /// <remarks>
        /// <br>Note       : 不具合対応[5130]にて追加</br>
        /// <br>Programmer : 30434 工藤 恵優</br>
        /// <br>Date       : 2008/09/16</br>
        /// </remarks>
        private string GetStockPointWayName(int stockPointWay)
        {
            switch (stockPointWay)
            {
                case (int)StockPointWay.Last:   // 最終仕入原価法
                    return STOCKPOINTWAY_LAST;

                case (int)StockPointWay.Move:   // 移動平均法
                    return STOCKPOINTWAY_MOVE;

                default:    // 設定がない場合は全社設定と同じ
                    switch (StockMngTtlStOfAllSection.StockPointWay)
                    {
                        case (int)StockPointWay.Last:   // 最終仕入原価法
                            return STOCKPOINTWAY_LAST;

                        case (int)StockPointWay.Move:   // 移動平均法
                            return STOCKPOINTWAY_MOVE;

                        default:
                            return UNREGISTER;
                    }
            }
        }

        /// <summary>
        /// 端数処理区分の名称を取得します。
        /// （設定がない場合は全社設定と同じ値を返します）
        /// </summary>
        /// <param name="fractionProcCd">端数処理区分</param>
        /// <returns>端数処理区分の名称</returns>
        /// <remarks>
        /// <br>Note       : 不具合対応[5130]にて追加</br>
        /// <br>Programmer : 30434 工藤 恵優</br>
        /// <br>Date       : 2008/09/16</br>
        /// </remarks>
        private string GetFractionProcName(int fractionProcCd)
        {
            switch (fractionProcCd)
            {
                case (int)FractionProcCd.Cut:           // 切捨て
                    return FRACTIONPROCCD_CUT;

                case (int)FractionProcCd.Round:         // 四捨五入
                    return FRACTIONPROCCD_ROUND;

                case (int)FractionProcCd.Revaluation:   // 切上げ
                    return FRACTIONPROCCD_REVALUATION;

                default:    // 設定がない場合は全社設定と同じ
                    switch (StockMngTtlStOfAllSection.FractionProcCd)
                    {
                        case (int)FractionProcCd.Cut:           // 切捨て
                            return FRACTIONPROCCD_CUT;

                        case (int)FractionProcCd.Round:         // 四捨五入
                            return FRACTIONPROCCD_ROUND;

                        case (int)FractionProcCd.Revaluation:   // 切上げ
                            return FRACTIONPROCCD_REVALUATION;

                        default:
                            return UNREGISTER;
                    }
            }
        }
        // ADD 2008/09/16 不具合対応[5130] ----------<<<<<

        // --- ADD 2009/12/02 ---------->>>>>
        /// <summary>
        /// 棚卸運用区分の名称を取得します。
        /// （設定がない場合は全社設定と同じ値を返します）
        /// </summary>
        /// <param name="inventoryMngDiv">棚卸運用区分</param>
        /// <returns>棚卸運用区分の名称</returns>
        /// <remarks>
        /// <br>Note       : 棚卸運用区分を追加</br>
        /// <br>Programmer : 朱俊成</br>
        /// <br>Date       : 2008/12/02</br>
        /// </remarks>
        private string GetInventoryMngDivName(int inventoryMngDiv)
        {
            // 設定がない場合は全社設定と同じ
            switch (StockMngTtlStOfAllSection.InventoryMngDiv)
            {
                case (int)InventoryMngDiv.Pmns:        // PM.NS
                    return INVENTORYMNGDIV_PMNS;

                case (int)InventoryMngDiv.Pm7:         // PM7
                    return INVENTORYMNGDIV_PM7;

                default:
                    return INVENTORYMNGDIV_PM7;
             }
        }
        // --- ADD 2009/12/02 ----------<<<<<

        /// <summary>
        /// 在庫管理全体設定オブジェクト論理削除処理
        /// </summary>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 在庫管理全体設定オブジェクトの論理削除を行います。</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/04</br>
        /// </remarks>
        private int LogicalDelete()
        {
            int status = 0;

            if ((this._dataIndex < 0) ||
                (this._dataIndex >= this.Bind_DataSet.Tables[STOCKMNGTTLST_TABLE].Rows.Count))
            {
                return -1;
            }

            // 情報取得
            Guid guid = (Guid)this.Bind_DataSet.Tables[STOCKMNGTTLST_TABLE].Rows[this._dataIndex][GUID_TITLE];
            StockMngTtlSt stockMngTtlSt = ((StockMngTtlSt)this._stockMngTtlStTable[guid]).Clone();

            // 在庫管理全体設定が存在していない
            if (stockMngTtlSt == null)
            {
                return -1;
            }

            // ADD 2008/09/12 不具合対応[5290] ---------->>>>>
            // 拠点コードが全社共通の場合、削除不可
            if (IsAllSection(stockMngTtlSt))
            {
                TMsgDisp.Show(
                    this, 							                        // 親ウィンドウフォーム
                    emErrorLevel.ERR_LEVEL_INFO, 	                        // エラーレベル
                    AssemblyUtil.GetName(Assembly.GetExecutingAssembly()),  // アセンブリＩＤまたはクラスＩＤ
                    this.Text, 				                                // プログラム名称
                    MethodBase.GetCurrentMethod().Name,                     // 処理名称
                    TMsgDisp.OPE_HIDE, 				                        // TODO:オペレーション
                    SectionUtil.MSG_ALL_SECTION_CANNOT_BE_DELETED, 	        // 表示するメッセージ
                    status, 						                        // ステータス値
                    this,			                                        // エラーが発生したオブジェクト
                    MessageBoxButtons.OK, 			                        // 表示するボタン
                    MessageBoxDefaultButton.Button1                         // 初期表示ボタン
                );
                return status;
            }
            // ADD 2008/09/12 不具合対応[5290] ----------<<<<<

            status = this._stockMngTtlStAcs.LogicalDelete(ref stockMngTtlSt);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        StockMngTtlStToDataSet(stockMngTtlSt.Clone(), this._dataIndex);
                        break;
                    }
                // 排他制御
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        ExclusiveTransaction(status, false);
                        return status;
                    }
                default:
                    {
                        // 論理削除
                        TMsgDisp.Show(
                            this, 								// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOP, 		// エラーレベル
                            "MAZAI09110U", 						// アセンブリＩＤまたはクラスＩＤ
                            "在庫管理全体設定", 				// プログラム名称
                            "LogicalDelete", 					// 処理名称
                            TMsgDisp.OPE_HIDE, 					// オペレーション
                            "削除に失敗しました。", 			// 表示するメッセージ
                            status, 							// ステータス値
                            this._stockMngTtlStAcs,			    // エラーが発生したオブジェクト
                            MessageBoxButtons.OK, 				// 表示するボタン
                            MessageBoxDefaultButton.Button1);	// 初期表示ボタン

                        return status;
                    }
            }
            return status;
        }

        // ADD 2008/09/12 不具合対応[5290] ---------->>>>>
        /// <summary>
        /// 全社設定か判定します。
        /// </summary>
        /// <param name="stockMngTtlSt">在庫管理全体設定</param>
        /// <returns><c>true</c> :全社設定である。<br/><c>false</c>:全社設定ではない。</returns>
        /// <remarks>
        /// <br>Note       : 不具合対応[5290]にて追加</br>
        /// <br>Programmer : 30434 工藤 恵優</br>
        /// <br>Date       : 2008/09/12</br>
        /// </remarks>
        private static bool IsAllSection(StockMngTtlSt stockMngTtlSt)
        {
            return SectionUtil.IsAllSection(stockMngTtlSt.SectionCode);
        }
        // ADD 2008/09/12 不具合対応[5290] ----------<<<<<

        #endregion

        #region Control Event
        
        /// <summary>
        /// Form.Load イベント()
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : フォームがロードされた時に発生します。</br>
        /// <br>Programmer : 30005 木建　翼</br>
        /// <br>Date       : 2007.03.01</br>
        /// <br>Update Note: 2012/06/08 lanl</br>
        /// <br>             Redmine#30282「棚卸データ削除区分」を画面に追加</br>
        /// <br>Update Note: 2012/07/02 三戸　伸悟</br>
        /// <br>             「移動時在庫自動登録区分」を画面に追加　</br>
        /// <br>Update Note: 2014/10/27 wangf </br>
        /// <br>           : Redmine#43854画面に列「移動伝票出力先区分」追加</br>
        /// </remarks>
        private void MAZAI09110UA_Load(object sender, EventArgs e)
        {
            // 2007.03.27 DANJO ADD START
            // アイコンリソース管理クラスを使用して、アイコンを表示する
            ImageList imageList24 = IconResourceManagement.ImageList24;
            ImageList imageList16 = IconResourceManagement.ImageList16;

            this.Ok_Button.ImageList        = imageList24;   // 保存ボタン
            this.Cancel_Button.ImageList    = imageList24;   // 閉じるボタン

            this.Ok_Button.Appearance.Image     = Size24_Index.SAVE;      // 保存ボタン
            this.Cancel_Button.Appearance.Image = Size24_Index.CLOSE;     // 閉じるボタン
            // 2007.03.27 DANJO ADD END

            // --- ADD 2008/06/05 -------------------------------->>>>>
            this.Revive_Button.ImageList = imageList24;
            this.Delete_Button.ImageList = imageList24;
            this.Revive_Button.Appearance.Image = Size24_Index.REVIVAL;	// 復活ボタン
            this.Delete_Button.Appearance.Image = Size24_Index.DELETE;	// 完全削除ボタン

            this.SectionGd_ultraButton.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            // --- ADD 2008/06/05 --------------------------------<<<<< 

            // 画面初期化
            ScreenInitialSetting();

            // --- ADD 2008/09/29 -------------------------------->>>>>
            // --- DEL 2008/12/01 -------------------------------->>>>>
            //StockMoveFixCode_tComboEditor.Appearance.BackColor = Color.FromArgb(179, 219, 231);         // 在庫移動確定区分
            // --- DEL 2008/12/01 --------------------------------<<<<<
            // ---ADD(復活) 2009/06/03 -------------------------------->>>>>
            StockMoveFixCode_tComboEditor.Appearance.BackColor = Color.FromArgb(179, 219, 231);         // 在庫移動確定区分
            // ---ADD(復活) 2009/06/03 --------------------------------<<<<<
            StockPointWay_tComboEditor.Appearance.BackColor = Color.FromArgb(179, 219, 231);            // 在庫評価方法
            ShelfNoDuplDiv_tComboEditor.Appearance.BackColor = Color.FromArgb(179, 219, 231);           // 棚番重複区分
            SectDspDivCd_tComboEditor.Appearance.BackColor = Color.FromArgb(179, 219, 231);             // 拠点表示区分
            FractionProcCd_tComboEditor.Appearance.BackColor = Color.FromArgb(179, 219, 231);           // 端数処理区分
            // --- ADD 2009/12/04 ---------->>>>>
            // 棚卸運用区分
            InventoryMngDiv_tComboEditor.Appearance.BackColor = Color.FromArgb(179, 219, 231);
            // --- ADD 2009/12/04 ----------<<<<<
            // --------------------- ADD 2011/08/29 ------------------- >>>>>
            // 現在庫表示区分
            PreStckCntDspDiv_tComboEditor.Appearance.BackColor = Color.FromArgb(179, 219, 231);
            // --------------------- ADD 2011/08/29 ------------------- <<<<<
            // --------------------- ADD lanl 2012/06/08 Redmine#30282 ------------------- >>>>>
            // 棚卸データ削除区分
            InvntryDtDelDiv_tComboEditor.Appearance.BackColor = Color.FromArgb(179, 219, 231);
            // --------------------- ADD lanl 2012/06/08 Redmine#30282 ------------------- <<<<<
            // --- ADD 三戸 2012/07/02 ---------->>>>>
            // 移動時在庫自動登録区分
            MoveStockAutoInsDiv_tComboEditor.Appearance.BackColor = Color.FromArgb(179, 219, 231);
            // --- ADD 三戸 2012/07/02 ----------<<<<<
            // ------------ADD wangf 2014/10/27 FOR Redmine#43854 列「移動伝票出力先区分」追加--------->>>>
            // 移動伝票出力先区分
            MoveSlipOutPutDiv_tComboEditor.Appearance.BackColor = Color.FromArgb(179, 219, 231);
            // ------------ADD wangf 2014/10/27 FOR Redmine#43854 列「移動伝票出力先区分」追加---------<<<<
            StockTolerncShipmDiv_tComboEditor.Appearance.BackColor = Color.FromArgb(179, 219, 231);     // 在庫切れ出荷区分
            InvntryPrtOdrIniDiv_tComboEditor.Appearance.BackColor = Color.FromArgb(179, 219, 231);      // 棚卸印刷順初期設定区分
            MaxStkCntOverOderDiv_tComboEditor.Appearance.BackColor = Color.FromArgb(179, 219, 231);     // 最高在庫数超え発注区分
            LotUseDivCd_tComboEditor.Appearance.BackColor = Color.FromArgb(179, 219, 231);              // ロット使用区分
            // --- ADD 2008/09/29 --------------------------------<<<<<
      
            // 拠点ガイドのフォーカス制御の開始
            SectionGuideController.StartControl();  // ADD 2008/09/19 不具合対応による共通仕様の展開
        }

        /// <summary>
        /// Form.Closing イベント(MAZAI09110UA)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">キャンセルできるイベントのデータを提供するクラス</param>
        /// <remarks>
        /// <br>Note       : フォームを閉じる前に、ユーザーがフォームを閉じようとしたときに発生します。</br>
        /// <br>Programmer : 30005 木建　翼</br>
        /// <br>Date       : 2007.03.01</br>
        /// </remarks>
        private void MAZAI09110UA_FormClosing(object sender, FormClosingEventArgs e)
        {
            // チェック用クローン初期化
            this._stockMngTtlStClone = null;

            // _GridIndexバッファ初期化（メインフレーム最小化対応）
            this._indexBuf = -2;

            // CanCloseプロパティがfalseの場合は、クローズ処理をキャンセルしてフォームを非表示化する。
            if (this._canClose == false)
            {
                e.Cancel = true;
                this.Hide();
            }
        }

        /// <summary>
        /// Form.VisibleChanged イベント(MAZAI09110UA)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : フォームの表示状態が変わったときに発生します。</br>
        /// <br>Programmer : 30005 木建　翼</br>
        /// <br>Date       : 2007.03.01</br>
        /// </remarks>
        private void MAZAI09110UA_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible == false)
            {
                this.Owner.Activate();
                return;
            }

            /* --- DEL 2008/06/05 -------------------------------->>>>>
                // データがセットされていたら抜ける
                if (this._stockMngTtlStClone != null)
                {
                    return;
                }
               --- DEL 2008/06/05 --------------------------------<<<<< */

            // --- ADD 2008/06/04 -------------------------------->>>>>
            // _GridIndexバッファ（メインフレーム最小化対応）
            // ターゲットレコード(Index)が変わっていなかった場合以下の処理をキャンセルする
            if (this._indexBuf == this._dataIndex)
            {
                return;
            }
            // --- ADD 2008/06/04 --------------------------------<<<<< 

            // ちらつき防止の為
            this.Enabled = false;

            this.Initial_Timer.Enabled = true;
            
            // 画面クリア
            ScreenClear();
        }


        /// <summary>
        /// Timer.Tick イベント(Initial_Timer)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note        : 指定された間隔の時間が経過したときに発生します。
        ///                   この処理は、システムが提供するスレッド プール
        ///	                  スレッドで実行されます。</br>
        /// <br>Programmer : 30005 木建　翼</br>
        /// <br>Date       : 2007.03.01</br>
        /// </remarks>
        private void Initial_Timer_Tick(object sender, EventArgs e)
        {
            this.Initial_Timer.Enabled = false;

            // 画面構築
            ScreenReconstruction();
        }

        /// <summary>
        /// Control.Click イベント(Ok_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 保存ボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer : 30005 木建　翼</br>
        /// <br>Date       : 2007.03.01</br>
        /// </remarks>
        private void Ok_Button_Click(object sender, System.EventArgs e)
        {
            if (!SaveProc())
            {
                return;
            }

            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }

            // 新規モードの場合は画面を終了せずに連続入力を可能とする
            if (this.Mode_Label.Text == INSERT_MODE)
            {
                ScreenClear();

                // 新規モード
                this._logicalDeleteMode = -1;

                StockMngTtlSt newStockMngTtlSt = new StockMngTtlSt();
                // 見積初期値設定オブジェクトを画面に展開
                StockMngTtlStToScreen(newStockMngTtlSt);

                // クローン作成
                this._stockMngTtlStClone = newStockMngTtlSt.Clone();
                DispToStockMngTtlSt(ref this._stockMngTtlStClone);

                // _GridIndexバッファ保持
                this._indexBuf = this._dataIndex;

                ScreenInputPermissionControl();
            }
            else
            {
                this.DialogResult = DialogResult.OK;

                // _GridIndexバッファ初期化（メインフレーム最小化対応）
                this._indexBuf = -2;

                if (this._canClose == true)
                {
                    this.Close();
                }
                else
                {
                    this.Hide();
                }
            }

            //CloseForm(DialogResult.OK);  // DEL 2008/06/04
        }

        /// <summary>
        /// Control.Click イベント(Cancel_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 閉じるボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer : 30005 木建　翼</br>
        /// <br>Date       : 2007.03.01</br>
        /// </remarks>
        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            /* --- DEL 2008/06/04 -------------------------------->>>>>
            bool checkResult = false;

            // 在庫管理全体設定
            StockMngTtlSt compareStockMngTtlSt = new StockMngTtlSt();

            // 現在の画面情報のクローンを取得する
            compareStockMngTtlSt = this._stockMngTtlStClone.Clone();
            
            // 現在の画面情報を取得する
            DispToStockMngTtlSt(ref compareStockMngTtlSt);
            
            // 最初に取得した画面情報と比較
            if (this._stockMngTtlStClone.Equals(compareStockMngTtlSt) == false)
            {
                checkResult = true;
            }

            if (checkResult)
            {
                // 画面情報が変更されていた場合は、保存確認メッセージを表示する
                // 保存確認
                DialogResult res = TMsgDisp.Show(
                    this, 								// 親ウィンドウフォーム
                    emErrorLevel.ERR_LEVEL_SAVECONFIRM, // エラーレベル
                    "MAZAI09110U", 						// アセンブリＩＤまたはクラスＩＤ
                    null, 								// 表示するメッセージ
                    0, 									// ステータス値
                    MessageBoxButtons.YesNoCancel);	// 表示するボタン
                switch (res)
                {
                    case DialogResult.Yes:
                        {
                            if (!SaveProc())
                            {
                                return;
                            }
                            break;
                        }
                    case DialogResult.No:
                        {
                            break;
                        }
                    default:
                        {
                            this.Cancel_Button.Focus();
                            return;
                        }
                }
            }

            // 画面を閉じる
            CloseForm(DialogResult.Cancel);
               --- DEL 2008/06/04 --------------------------------<<<<< */

            // 削除モード・参照モード以外の場合は保存確認処理を行う
            if (this.Mode_Label.Text != DELETE_MODE)
            {
                // 現在の画面情報を取得する
                StockMngTtlSt compareStockMngTtlSt = new StockMngTtlSt();
                compareStockMngTtlSt = this._stockMngTtlStClone.Clone();
                DispToStockMngTtlSt(ref compareStockMngTtlSt);

                // 最初に取得した画面情報と比較
                if (!(this._stockMngTtlStClone.Equals(compareStockMngTtlSt)))
                {
                    // 画面情報が変更されていた場合は、保存確認メッセージを表示する
                    // 保存確認
                    DialogResult res = TMsgDisp.Show(
                        this, 								// 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_SAVECONFIRM, // エラーレベル
                        "MAZAI09110U", 						// アセンブリＩＤまたはクラスＩＤ
                        null, 								// 表示するメッセージ
                        0, 									// ステータス値
                        MessageBoxButtons.YesNoCancel);	// 表示するボタン
                    switch (res)
                    {
                        case DialogResult.Yes:
                            {
                                if (!SaveProc())
                                {
                                    return;
                                }
                                break;
                            }
                        case DialogResult.No:
                            {
                                break;
                            }
                        default:
                            {
                                // 2009.03.25 30413 犬飼 新規モードからモード変更対応 >>>>>>START
                                //this.Cancel_Button.Focus();
                                if (_modeFlg)
                                {
                                    tEdit_SectionCodeAllowZero2.Focus();
                                    _modeFlg = false;
                                }
                                else
                                {
                                    this.Cancel_Button.Focus();
                                }
                                // 2009.03.25 30413 犬飼 新規モードからモード変更対応 <<<<<<END
                                return;
                            }
                    }
                }
            }

            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.Cancel);
                UnDisplaying(this, me);
            }

            this.DialogResult = DialogResult.Cancel;

            // _GridIndexバッファ初期化（メインフレーム最小化対応）
            this._indexBuf = -2;

            if (this._canClose)
            {
                this.Close();
            }
            else
            {
                this.Hide();
            }
        }

        /// <summary>
        /// tRetKeyControl イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : Returnキーが押されたときに発生します。</br>
        /// <br>Programmer : 30005 木建　翼</br>
        /// <br>Date       : 2007.03.01</br>
        /// <br>Update Note : 2011/09/08 田建委</br>
        /// <br>              障害報告 #24169 全社共通の編集　</br>   
        /// </remarks>
        private void tRetKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            // 2007.03.27 DANJO CHG START
            if (e.PrevCtrl == null)
            {
                return;
            }
            //if (e.NextCtrl == Ok_Button && e.PrevCtrl == StockMoveFixCode_tComboEditor)
            //{
            //    e.NextCtrl = this.StockMngExistCdDisp_tComboEditor;
            //}

            //if (e.NextCtrl == Cancel_Button && e.PrevCtrl == this.StockPointWay_tComboEditor)
            //{
            //    e.NextCtrl = this.Ok_Button;
            //}

            //if (e.PrevCtrl == this.Ok_Button)
            //{
            //    e.NextCtrl = this.Cancel_Button;
            //}
            // 2007.03.27 DANJO CHG END

            // 2009.03.25 30413 犬飼 新規モードからモード変更対応 >>>>>>START
            _modeFlg = false;
            
            switch (e.PrevCtrl.Name)
            {
                // ----- UPD 2011/09/08 ----->>>>>
                //case "tEdit_SectionCodeAllowZero":
                case "tEdit_SectionCodeAllowZero2":
                // ----- UPD 2011/09/08 -----<<<<<
                    {
                        // ----- ADD 2011/09/08 --------------------------------->>>>>
                        // 拠点コードが存在していない場合、登録しない。
                        if (!string.IsNullOrEmpty(this.tEdit_SectionCodeAllowZero2.Text) && !SectionUtil.ExistsCode(this.tEdit_SectionCodeAllowZero2.Text))
                        {
                            this.tEdit_SectionCodeAllowZero2.Text = this.tEdit_SectionCodeAllowZero2.Text.PadLeft(2, '0');
                            TMsgDisp.Show(
                                this, 								                    // 親ウィンドウフォーム
                                emErrorLevel.ERR_LEVEL_EXCLAMATION,                     // エラーレベル
                                AssemblyUtil.GetName(Assembly.GetExecutingAssembly()),  // アセンブリＩＤまたはクラスＩＤ
                                this.Text, 		                                        // プログラム名称
                                MethodBase.GetCurrentMethod().Name, 					// 処理名称
                                TMsgDisp.OPE_UPDATE, 				                    // オペレーション
                                SectionUtil.MSG_SECTION_CODE_IS_NOT_FOUND,              // 表示するメッセージ
                                (int)ConstantManagement.MethodResult.ctFNC_NORMAL, 		// ステータス値
                                this,			                                        // エラーが発生したオブジェクト
                                MessageBoxButtons.OK, 				                    // 表示するボタン
                                MessageBoxDefaultButton.Button1                         // 初期表示ボタン
                            );
                            // 拠点コード、名称のクリア
                            tEdit_SectionCodeAllowZero2.Clear();
                            SectionNm_tEdit.Clear();
                            e.NextCtrl = tEdit_SectionCodeAllowZero2;
                            break;
                        }
                        // ----- ADD 2011/09/08 ---------------------------------<<<<<
                        // 拠点コード
                        if (e.NextCtrl.Name == "Cancel_Button")
                        {
                            // 遷移先が閉じるボタン
                            _modeFlg = true;
                        }
                        else if (this._dataIndex < 0)
                        {
                            if (ModeChangeProc())
                            {
                                e.NextCtrl = tEdit_SectionCodeAllowZero2;
                            }
                        }
                        break;
                    }
            }
            // 2009.03.25 30413 犬飼 新規モードからモード変更対応 <<<<<<END
        }

        /// <summary>
        /// 拠点コードガイドボタンクリック処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : ガイド表示処理</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/04</br>
        /// </remarks>
        private void SectionGd_ultraButton_Click(object sender, EventArgs e)
        {
            SecInfoSetAcs secInfoSetAcs = new SecInfoSetAcs();
            SecInfoSet secInfoSet = new SecInfoSet();
            this._secInfoAcs.ResetSectionInfo();

            try
            {
                this.Cursor = Cursors.WaitCursor;

                int status = secInfoSetAcs.ExecuteGuid(this._enterpriseCode, false, out secInfoSet);
                if (status != 0)
                {
                    ((Control)sender).Tag = GeneralGuideUIController.CAN_FOCUS; // ADD 2008/10/08 不具合対応[6405]
                    return;
                }

                // 取得データ表示
                this.tEdit_SectionCodeAllowZero2.DataText = secInfoSet.SectionCode.Trim();
                this.SectionNm_tEdit.DataText = secInfoSet.SectionGuideNm;

                // 2009.03.25 30413 犬飼 新規モードからモード変更対応 >>>>>>START
                if (this._dataIndex < 0)
                {
                    if (ModeChangeProc())
                    {
                        ((Control)sender).Tag = GeneralGuideUIController.CAN_FOCUS;
                        ((Control)sender).Focus();
                    }
                }
                // 2009.03.25 30413 犬飼 新規モードからモード変更対応 <<<<<<END
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// 復活ボタンクリック処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 復活ボタンコントロールがクリックされたときに発生します</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/04</br>
        /// </remarks>
        private void Revive_Button_Click(object sender, EventArgs e)
        {
            if (Revival() != 0)
            {
                return;
            }

            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }

            this.DialogResult = DialogResult.OK;

            // _GridIndexバッファ初期化（メインフレーム最小化対応）
            this._indexBuf = -2;

            if (this._canClose == true)
            {
                this.Close();
            }
            else
            {
                this.Hide();
            }
        }

        /// <summary>
        /// 完全削除ボタンクリック処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 完全削除ボタンコントロールがクリックされたときに発生します</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/04</br>
        /// </remarks>
        private void Delete_Button_Click(object sender, EventArgs e)
        {
            // 完全削除確認
            DialogResult result = TMsgDisp.Show(
                this, 								// 親ウィンドウフォーム
                emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
                "MAZAI09110U", 						// アセンブリＩＤまたはクラスＩＤ
                "データを削除します。" + "\r\n" +
                "よろしいですか？", 				// 表示するメッセージ
                0, 									// ステータス値
                MessageBoxButtons.OKCancel, 		// 表示するボタン
                MessageBoxDefaultButton.Button2);	// 初期表示ボタン

            if (result == DialogResult.OK)
            {
                if (PhysicalDelete() != 0)
                {
                    return;
                }
            }
            else
            {
                this.Delete_Button.Focus();
                return;
            }

            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }

            this.DialogResult = DialogResult.OK;

            // _GridIndexバッファ初期化（メインフレーム最小化対応）
            this._indexBuf = -2;

            if (this._canClose == true)
            {
                this.Close();
            }
            else
            {
                this.Hide();
            }
        }

        /// <summary>
        /// 拠点コードEdit Leave処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 拠点名称表示処理</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/04</br>
        /// <br>Update Note : 2011/09/08 田建委</br>
        /// <br>              障害報告 #24169 全社共通の編集　</br>   
        /// </remarks>
        private void tEdit_SectionCode_Leave(object sender, EventArgs e)
        {
            // --- ADD 2008/09/29 --------------------------------->>>>>
            // ----- UPD 2011/09/08 -------------------->>>>>
            //if ((this.tEdit_SectionCodeAllowZero2.Text == string.Empty) ||
            //    (this.tEdit_SectionCodeAllowZero2.Text == "0") ||
            //    (this.tEdit_SectionCodeAllowZero2.Text == "00"))
            if ((this.tEdit_SectionCodeAllowZero2.Text == "0") ||
                (this.tEdit_SectionCodeAllowZero2.Text == "00"))
            // ----- UPD 2011/09/08 --------------------<<<<<
            {
                // DEL 2008/10/08 不具合対応[6407] ↓
                //this.SectionNm_tEdit.Text = "全社設定";
                this.SectionNm_tEdit.Text = "全社共通";     // ADD 2008/10/08 不具合対応[6407]
                this.tEdit_SectionCodeAllowZero2.Text = "00"; // ADD 2011/09/08
                return;
            }
            // --- ADD 2008/09/29 ---------------------------------<<<<<

            // 拠点コード入力あり？
            if (this.tEdit_SectionCodeAllowZero2.Text != "")
            {                
                // 拠点コード名称設定
                this.SectionNm_tEdit.Text = GetSectionName(this.tEdit_SectionCodeAllowZero2.Text.Trim());
            }
            else
            {
                // 拠点コード名称クリア
                this.SectionNm_tEdit.Text = "";
            }

            // --- ADD 2011/09/08 --------------------------------->>>>>
            if (!string.IsNullOrEmpty(this.tEdit_SectionCodeAllowZero2.Text))
            {
                this.tEdit_SectionCodeAllowZero2.Text = this.tEdit_SectionCodeAllowZero2.Text.PadLeft(2, '0');
            }
            // --- ADD 2011/09/08 ---------------------------------<<<<<
        }

        // --- ADD 2008/07/03 -------------------------------->>>>>
        /// <summary>
        /// 拠点コードEdit Change処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 拠点コード変更時処理</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/07/03</br>
        /// <br>Update Note: 2009/12/02 朱俊成 棚卸運用区分の追加</br>
        /// <br>Update Note: 2012/06/08 lanl</br>
        /// <br>             Redmine#30282「棚卸データ削除区分」を画面に追加</br>
        /// <br>Update Note: 2012/07/02 三戸　伸悟</br>
        /// <br>             「移動時在庫自動登録区分」を画面に追加　</br>
        /// <br>Update Note: 2014/10/27 wangf </br>
        /// <br>           : Redmine#43854画面に列「移動伝票出力先区分」追加</br>
        /// </remarks>
        private void tEdit_SectionCodeAllowZero_TextChanged(object sender, EventArgs e)
        {
            if (this.tEdit_SectionCodeAllowZero2.Text != "")
            {
                // 拠点コードが0のときのみ入力可能
                if (Int32.Parse(this.tEdit_SectionCodeAllowZero2.Text) == 0)
                {
                    // --- DEL 2008/12/01 -------------------------------->>>>>
                    //this.StockMoveFixCode_tComboEditor.Enabled = true;  // 在庫移動確定区分
                    // --- DEL 2008/12/01 --------------------------------<<<<<
                    // ---ADD(復活) 2009/06/03 -------------------------------->>>>>
                    this.StockMoveFixCode_tComboEditor.Enabled = true;  // 在庫移動確定区分
                    // ---ADD(復活) 2009/06/03 --------------------------------<<<<<
                    // --- ADD 2009/12/02 ---------->>>>>
                    // 棚卸運用区分
                    this.InventoryMngDiv_tComboEditor.Enabled = true;
                    // --- ADD 2009/12/02 ----------<<<<<
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>> 2008/12/10 G.Miyatsu 一時的にコメントアウト
                    //this.StockPointWay_tComboEditor.Enabled = true;     // 在庫評価方法
                    //this.FractionProcCd_tComboEditor.Enabled = true;    // 端数処理区分
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<< 2008/12/10 G.Miyatsu 一時的にコメントアウト
                    // ------------ ADD 2011/08/29 --------------- >>>>>
                    // 現在庫表示区分
                    if (this.InventoryMngDiv_tComboEditor.SelectedIndex == 1)
                    {
                        this.PreStckCntDspDiv_tComboEditor.Enabled = true;
                    }
                    else if (this.InventoryMngDiv_tComboEditor.SelectedIndex == 0)
                    {
                        this.PreStckCntDspDiv_tComboEditor.SelectedIndex = 0;
                        this.PreStckCntDspDiv_tComboEditor.Enabled = false;
                    }
                    // ------------ ADD 2011/08/29 --------------- <<<<<
                    // ------------ ADD lanl 2012/06/08 Redmine#30282 --------------- >>>>>
                    // 棚卸データ削除区分
                    this.InvntryDtDelDiv_tComboEditor.Enabled = true;
                    // ------------ ADD lanl 2012/06/08 Redmine#30282 --------------- <<<<<
                    // --- ADD 三戸 2012/07/02 ---------->>>>>
                    // 移動時在庫自動登録区分
                    this.MoveStockAutoInsDiv_tComboEditor.Enabled = true;
                    // --- ADD 三戸 2012/07/02 ----------<<<<<
                }
                else
                {
                    // --- DEL 2008/12/01 -------------------------------->>>>>
                    //this.StockMoveFixCode_tComboEditor.Enabled = false; // 在庫移動確定区分
                    // --- DEL 2008/12/01 --------------------------------<<<<<
                    // ---ADD(復活) 2009/06/03 -------------------------------->>>>>
                    this.StockMoveFixCode_tComboEditor.Enabled = false; // 在庫移動確定区分
                    // ---ADD(復活) 2009/06/03 --------------------------------<<<<<
                    this.StockPointWay_tComboEditor.Enabled = false;    // 在庫評価方法
                    this.FractionProcCd_tComboEditor.Enabled = false;   // 端数処理区分
                    // --- ADD 2009/12/02 ---------->>>>>
                    // 棚卸運用区分
                    this.InventoryMngDiv_tComboEditor.Enabled = false;
                    // --- ADD 2009/12/02 ----------<<<<<
                    // ------------ ADD 2011/08/29 --------------- >>>>>
                    // 現在庫表示区分
                    this.PreStckCntDspDiv_tComboEditor.Enabled = false;
                    // ------------ ADD 2011/08/29 --------------- <<<<<
                    // ------------ ADD lanl 2012/06/08 Redmine#30282 --------------- >>>>>
                    // 棚卸データ削除区分
                    this.InvntryDtDelDiv_tComboEditor.Enabled = false;
                    // ------------ ADD lanl 2012/06/08 Redmine#30282 --------------- <<<<<
                    // --- ADD 三戸 2012/07/02 ---------->>>>>
                    // 移動時在庫自動登録区分
                    this.MoveStockAutoInsDiv_tComboEditor.Enabled = false;
                    // --- ADD 三戸 2012/07/02 ----------<<<<<
                }
            }
            else
            {
                // --- DEL 2008/12/01 -------------------------------->>>>>
                //this.StockMoveFixCode_tComboEditor.Enabled = false; // 在庫移動確定区分
                // --- DEL 2008/12/01 --------------------------------<<<<<
                // ---ADD(復活) 2009/06/03 -------------------------------->>>>>
                this.StockMoveFixCode_tComboEditor.Enabled = false; // 在庫移動確定区分
                // ---ADD(復活) 2009/06/03 --------------------------------<<<<<
                this.StockPointWay_tComboEditor.Enabled = false;    // 在庫評価方法
                this.FractionProcCd_tComboEditor.Enabled = false;   // 端数処理区分
                // --- ADD 2009/12/02 ---------->>>>>
                // 棚卸運用区分
                this.InventoryMngDiv_tComboEditor.Enabled = false;
                // --- ADD 2009/12/02 ----------<<<<<
                // ADD yangyi 2012/06/08 Redmine#30282 ------------->>>>>
                // 現在庫表示区分
                this.PreStckCntDspDiv_tComboEditor.Enabled = false;
                // 棚卸データ削除区分
                this.InvntryDtDelDiv_tComboEditor.Enabled = false;
                // ADD yangyi 2012/06/08 Redmine#30282 -------------<<<<<
                // --- ADD 三戸 2012/07/02 ---------->>>>>
                // 移動時在庫自動登録区分
                this.MoveStockAutoInsDiv_tComboEditor.Enabled = false;
                // --- ADD 三戸 2012/07/02 ----------<<<<<
            }
        }
        // --- ADD 2008/07/03 --------------------------------<<<<< 
        #endregion

        // 2009.03.25 30413 犬飼 新規モードからモード変更対応 >>>>>>START
        /// <summary>
        /// モード変更処理
        /// </summary>
        /// <br>Update Note : 2011/09/08 田建委</br>
        /// <br>              障害報告 #24169 全社共通の編集　</br>   
        private bool ModeChangeProc()
        {
            // --- ADD 2011/09/08 -------------------------------->>>>>
            isError = false;
            EventArgs e = new EventArgs();
            tEdit_SectionCode_Leave(null, e);

            if (string.IsNullOrEmpty(tEdit_SectionCodeAllowZero2.Text.Trim()))
            {
                this.SectionNm_tEdit.Clear();
                return false;
            }
            // --- ADD 2011/09/08 --------------------------------<<<<<

            string msg = "入力されたコードの在庫管理全体設定情報が既に登録されています。\n編集を行いますか？";
            
            // 拠点コード
            string sectionCd = tEdit_SectionCodeAllowZero2.Text.TrimEnd().PadLeft(2, '0');

            for (int i = 0; i < this.Bind_DataSet.Tables[STOCKMNGTTLST_TABLE].Rows.Count; i++)
            {
                // データセットと比較
                string dsSecCd = (string)this.Bind_DataSet.Tables[STOCKMNGTTLST_TABLE].Rows[i][SECTIONCODE_TITLE];
                if (sectionCd.Equals(dsSecCd.TrimEnd()))
                {
                    // 入力コードがデータセットに存在する場合
                    if ((string)this.Bind_DataSet.Tables[STOCKMNGTTLST_TABLE].Rows[i][DELETE_DATE] != "")
                    {
                        // 論理削除
                        TMsgDisp.Show(this, 					// 親ウィンドウフォーム
                          emErrorLevel.ERR_LEVEL_INFO,          // エラーレベル
                          "MAZAI09110U",						// アセンブリＩＤまたはクラスＩＤ
                          "入力されたコードの在庫管理全体設定情報は既に削除されています。", 			// 表示するメッセージ
                          0, 									// ステータス値
                          MessageBoxButtons.OK);				// 表示するボタン
                        isError = true; // ADD 2011/09/08
                        // 拠点コード、名称のクリア
                        tEdit_SectionCodeAllowZero2.Clear();
                        SectionNm_tEdit.Clear();
                        return true;
                    }

                    if (sectionCd == "00")
                    {
                        // 全社共通のメッセージ変更
                        msg = "入力されたコードの在庫管理全体設定情報が既に登録されています。\n　【拠点名称：全社共通】\n編集を行いますか？";
                    }

                    DialogResult res = TMsgDisp.Show(
                        this,                                   // 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_INFO,            // エラーレベル
                        "MAZAI09110U",                          // アセンブリＩＤまたはクラスＩＤ
                        msg,                                    // 表示するメッセージ
                        0,                                      // ステータス値
                        MessageBoxButtons.YesNo);               // 表示するボタン

                    isError = true; // ADD 2011/09/08
                    switch (res)
                    {
                        case DialogResult.Yes:
                            {
                                // 画面再描画
                                this._dataIndex = i;
                                ScreenClear();
                                ScreenReconstruction();
                                break;
                            }
                        case DialogResult.No:
                            {
                                // 拠点コード、名称のクリア
                                tEdit_SectionCodeAllowZero2.Clear();
                                SectionNm_tEdit.Clear();
                                break;
                            }
                    }
                    return true;
                }
            }
            return false;
        }
        // 2009.03.25 30413 犬飼 新規モードからモード変更対応 <<<<<<END

        // -------------------- ADD 2011/08/29 ------------------- >>>>>
        /// <summary>
        /// 棚卸運用区分 Change処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 棚卸運用区分変更時処理</br>
        /// <br>Programmer : 周雨</br>
        /// <br>Date       : 2011/08/29</br>
        /// </remarks>
        private void InventoryMngDiv_tComboEditor_SelectionChanged(object sender, EventArgs e)
        {
            if (this.InventoryMngDiv_tComboEditor.SelectedIndex == 0 && this.tEdit_SectionCodeAllowZero2.Text == "00")
            {
                this.PreStckCntDspDiv_tComboEditor.SelectedIndex = 0;
                this.PreStckCntDspDiv_tComboEditor.Enabled = false;
            }
            else if (this.InventoryMngDiv_tComboEditor.SelectedIndex == 1 && this.tEdit_SectionCodeAllowZero2.Text == "00")
            {
                this.PreStckCntDspDiv_tComboEditor.Enabled = true;
            }
            else if (this.tEdit_SectionCodeAllowZero2.Text != "00")
            {
                this.PreStckCntDspDiv_tComboEditor.Enabled = false;
            }
        }
        // -------------------- ADD 2011/08/29 ------------------- >>>>>

        // -------------------- ADD 2011/09/08 ------------------- >>>>>
        /// <summary>
        /// tEdit_SectionCodeAllowZero2_Enter イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : tEdit_SectionCodeAllowZero2_Enter イベント</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2011/09/08</br>
        /// </remarks>
        private void tEdit_SectionCodeAllowZero2_Enter(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tEdit_SectionCodeAllowZero2.Text))
            {
                tEdit_SectionCodeAllowZero2.Text = Convert.ToInt32(tEdit_SectionCodeAllowZero2.Text).ToString();
            }
        }
        // -------------------- ADD 2011/09/08 ------------------- <<<<<
    }
}