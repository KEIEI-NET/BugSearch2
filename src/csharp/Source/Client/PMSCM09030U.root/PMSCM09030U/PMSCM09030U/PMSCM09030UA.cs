//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : SCM納期設定マスタ
// プログラム概要   : SCM納期設定の登録・変更・削除を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30413 犬飼
// 作 成 日  2009/05/01  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号  10704766-00    作成担当：王飛３
// 修正日    2011/09/07     修正内容：障害報告 #24169　拠点設定を行おうと拠点ガイドをすると全社共通の編集を行おうとしてしまう。
//　　　　　　　　　　　　　　　　　　　　　　　　　　 拠点コードと拠点ガイドのフォーカス移動はメッセージ表示を行わないように修正
// ---------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 湯上 千加子
// 作 成 日  2012/06/28  修正内容 : SCM障害№10292対応 ヘッダタイトル部の変更       
// ---------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 湯上 千加子
// 作 成 日  2012/07/05  修正内容 : システムテスト障害№42対応 参照在庫設定選択項目の名称変更       
// ---------------------------------------------------------------------//
// 管理番号              作成担当 : 30746 高川 悟
// 作 成 日  2012/08/30  修正内容 : 2012/10月配信予定 SCM障害№10345
// ---------------------------------------------------------------------//
// 管理番号              作成担当 : 30746 高川 悟
// 作 成 日  2012/10/03  修正内容 : 2012/10/17配信システムテスト障害No3,No32
// ---------------------------------------------------------------------//
// 管理番号              作成担当 : 30745 吉岡 孝憲
// 作 成 日  2012/10/31  修正内容 : 2012/11/14配信システムテスト障害No17
// ---------------------------------------------------------------------//
// 管理番号  11070266-00 作成担当 : 31065 豊沢
// 作 成 日  2015/02/10  修正内容 : SCM高速化 回答納期区分対応
// ---------------------------------------------------------------------//
// 管理番号  11070266-00 作成担当 : 31065 豊沢
// 作 成 日  2015/02/16  修正内容 : SCM高速化 システムテスト障害224対応
// ---------------------------------------------------------------------//
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Controller.Util;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// SCM納期設定フォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : SCM納期設定を行います。</br>
    /// <br>-----------------------------------------------------------------------------------------</br>
    /// <br>UpdateNote : 2011/01/06 30517 夏野 駿希</br>
    /// <br>           : SCM検証結果対応No.7　納期設定を取寄品・在庫品で別に設定出来る様に修正</br>
    /// <br>-----------------------------------------------------------------------------------------</br>
    /// <br>UpdateNote : 2011/05/27 30517 夏野 駿希</br>
    /// <br>           : 委託在庫設定区分から棚番を返すを削除（委託用に設定は2でデータを作成する）</br>
    /// <br>-----------------------------------------------------------------------------------------</br>
    /// <br>UpdateNote : 2011/10/11  呉軍</br>
    /// <br>Note       : Redmine #25765</br>
    /// <br>           : 優先在庫回答納期区分、優先在庫回答納期の追加</br>
    /// </remarks>
    public partial class PMSCM09030UA : System.Windows.Forms.Form, IMasterMaintenanceMultiType
    {
        #region -- Private Members --

        // プロパティ用
        private bool _canNew;
        private bool _canClose;
        private bool _canPrint;
        private bool _canDelete;
        private bool _canLogicalDeleteDataExtraction;
        private bool _canSpecificationSearch;
        private int _dataIndex;
        private bool _defaultAutoFillToColumn;

        private int _logicalDeleteMode;		      // モード
        private string _enterpriseCode;           // 企業コード

        private SCMDeliDateStAcs _scmDeliDateStAcs;	        // SCM納期設定アクセスクラス
        private SecInfoAcs _secInfoAcs;                     // 拠点マスタアクセスクラス
        private CustomerInfoAcs _customerInfoAcs = null;    // 得意先情報アクセスクラス

        private SCMDeliDateSt _scmDeliDateStClone;	        // 比較用SCM納期設定クローンクラス
        private Hashtable _scmDeliDateStTable;	            // SCM納期設定テーブル
        
        // 得意先情報キャッシュ
        private ArrayList _customerList;

        // 新規モードからモード変更対応
        // モードフラグ(true：コード、false：コード以外)
        private bool _modeFlg = false;

        private const string PROGRAM_ID = "PMSCM09030U";    // プログラムID

        private const string VIEW_TABLE = "VIEW_TABLE";     // テーブル名

        // 編集モード
        private const string INSERT_MODE = "新規モード";
        private const string UPDATE_MODE = "更新モード";
        private const string DELETE_MODE = "削除モード";

        // FrameのView用Grid列のKEY情報（ヘッダのタイトル部となります。）
        private const string DELETE_DATE        = "削除日";
        private const string SECTIONCODE_TITLE  = "拠点コード";
        private const string SECTIONNAME_TITLE  = "拠点名";
        private const string CUSTOMERCODE_TITLE = "得意先コード";
        private const string CUSTOMERNAME_TITLE = "得意先名";

        // 2011/01/06 Del >>>
        //private const string ANSWER_DEAD_TIME_1 = "回答締切時刻１";
        //private const string ANSWER_DEAD_TIME_2 = "回答締切時刻２";
        //private const string ANSWER_DEAD_TIME_3 = "回答締切時刻３";
        //private const string ANSWER_DEAD_TIME_4 = "回答締切時刻４";
        //private const string ANSWER_DEAD_TIME_5 = "回答締切時刻５";
        //private const string ANSWER_DEAD_TIME_6 = "回答締切時刻６";
        //private const string ANSWER_DELIV_DATE_1 = "回答納期１";
        //private const string ANSWER_DELIV_DATE_2 = "回答納期２";
        //private const string ANSWER_DELIV_DATE_3 = "回答納期３";
        //private const string ANSWER_DELIV_DATE_4 = "回答納期４";
        //private const string ANSWER_DELIV_DATE_5 = "回答納期５";
        //private const string ANSWER_DELIV_DATE_6 = "回答納期６";
        // 2011/01/06 Del <<<

        // 2011/01/06 Add >>>
        private const string ANSWER_DEAD_TIME_1 = "回答締切時刻１（取寄）";
        private const string ANSWER_DEAD_TIME_2 = "回答締切時刻２（取寄）";
        private const string ANSWER_DEAD_TIME_3 = "回答締切時刻３（取寄）";
        private const string ANSWER_DEAD_TIME_4 = "回答締切時刻４（取寄）";
        private const string ANSWER_DEAD_TIME_5 = "回答締切時刻５（取寄）";
        private const string ANSWER_DEAD_TIME_6 = "回答締切時刻６（取寄）";
        private const string ANSWER_DELIV_DATE_1 = "回答納期１（取寄）";
        private const string ANSWER_DELIV_DATE_2 = "回答納期２（取寄）";
        private const string ANSWER_DELIV_DATE_3 = "回答納期３（取寄）";
        private const string ANSWER_DELIV_DATE_4 = "回答納期４（取寄）";
        private const string ANSWER_DELIV_DATE_5 = "回答納期５（取寄）";
        private const string ANSWER_DELIV_DATE_6 = "回答納期６（取寄）";
        private const string ANSWER_DEAD_TIME_1_STC = "回答締切時刻１（在庫）";
        private const string ANSWER_DEAD_TIME_2_STC = "回答締切時刻２（在庫）";
        private const string ANSWER_DEAD_TIME_3_STC = "回答締切時刻３（在庫）";
        private const string ANSWER_DEAD_TIME_4_STC = "回答締切時刻４（在庫）";
        private const string ANSWER_DEAD_TIME_5_STC = "回答締切時刻５（在庫）";
        private const string ANSWER_DEAD_TIME_6_STC = "回答締切時刻６（在庫）";
        private const string ANSWER_DELIV_DATE_1_STC = "回答納期１（在庫）";
        private const string ANSWER_DELIV_DATE_2_STC = "回答納期２（在庫）";
        private const string ANSWER_DELIV_DATE_3_STC = "回答納期３（在庫）";
        private const string ANSWER_DELIV_DATE_4_STC = "回答納期４（在庫）";
        private const string ANSWER_DELIV_DATE_5_STC = "回答納期５（在庫）";
        private const string ANSWER_DELIV_DATE_6_STC = "回答納期６（在庫）";
        private const string ENTSTCKANSDELIDTDIV = "委託在庫回答納期区分";
        private const string ENTSTCKANSDELIDATE = "委託在庫回答納期";
        // 2011/01/06 Add <<<

        // 2011/10/11 Add >>>
        // UPD 2012/06/28 湯上 No.10292 -------------------------------------------->>>>>
        //private const string PRISTCKANSDELIDTDIV = "優先在庫回答納期区分";
        //private const string PRISTCKANSDELIDATE = "優先在庫回答納期";
        private const string PRISTCKANSDELIDTDIV = "参照在庫回答納期区分";
        private const string PRISTCKANSDELIDATE = "参照在庫回答納期";
        // UPD 2012/06/28 湯上 No.10292 --------------------------------------------<<<<<
        // 2011/10/11 Add <<<

        // 2012/08/30 ADD TAKAGAWA 2012/10月配信予定 SCM障害№10345 --------->>>>>>>>>>>>>>>>>>>>>>>>>
        private const string ANSDELDATSHORTOFSTC = "回答納期（在庫不足）";
        private const string ANSDELDATWITHOUTSTC = "回答納期（在庫数無し）";
        private const string ENTSTCANSDELDATSHORT = "委託在庫回答納期（在庫不足）";
        private const string ENTSTCANSDELDATWIOUT = "委託在庫回答納期（在庫数無し）";
        private const string PRISTCANSDELDATSHORT = "参照在庫回答納期（在庫不足）";
        private const string PRISTCANSDELDATWIOUT = "参照在庫回答納期（在庫数無し）";
        // 2012/08/30 ADD TAKAGAWA 2012/10月配信予定 SCM障害№10345 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

        // ADD 2015/02/10 豊沢 SCM高速化 回答納期区分対応 ------------------------------------------>>>>>
        private const string ANSWER_DELIV_DATE_DIV_1 = "回答納期区分１（取寄）";
        private const string ANSWER_DELIV_DATE_DIV_2 = "回答納期区分２（取寄）";
        private const string ANSWER_DELIV_DATE_DIV_3 = "回答納期区分３（取寄）";
        private const string ANSWER_DELIV_DATE_DIV_4 = "回答納期区分４（取寄）";
        private const string ANSWER_DELIV_DATE_DIV_5 = "回答納期区分５（取寄）";
        private const string ANSWER_DELIV_DATE_DIV_6 = "回答納期区分６（取寄）";
        private const string ANSWER_DELIV_DATE_DIV_1_STC = "回答納期区分１（在庫）";
        private const string ANSWER_DELIV_DATE_DIV_2_STC = "回答納期区分２（在庫）";
        private const string ANSWER_DELIV_DATE_DIV_3_STC = "回答納期区分３（在庫）";
        private const string ANSWER_DELIV_DATE_DIV_4_STC = "回答納期区分４（在庫）";
        private const string ANSWER_DELIV_DATE_DIV_5_STC = "回答納期区分５（在庫）";
        private const string ANSWER_DELIV_DATE_DIV_6_STC = "回答納期区分６（在庫）";
        private const string ANSDELDATSHORTOFSTC_DIV = "回答納期区分（在庫不足）";
        private const string ANSDELDATWITHOUTSTC_DIV = "回答納期区分（在庫数無し）";
        private const string ENTSTCKANSDELIDATE_DIV = "委託在庫回答納期区分（在庫）";
        private const string ENTSTCANSDELDATSHORT_DIV = "委託在庫回答納期区分（在庫不足）";
        private const string ENTSTCANSDELDATWIOUT_DIV = "委託在庫回答納期区分（在庫数無し）";
        private const string PRISTCKANSDELIDATE_DIV = "参照在庫回答納期区分（在庫）";
        private const string PRISTCANSDELDATSHORT_DIV = "参照在庫回答納期区分（在庫不足）";
        private const string PRISTCANSDELDATWIOUT_DIV = "参照在庫回答納期区分（在庫数無し）";
        // ADD 2015/02/10 豊沢 SCM高速化 回答納期区分対応 ------------------------------------------<<<<<
        private const string GUID_TITLE = "GUID";

        // 未設定時に使用
        private const string UNREGISTER = "";

        // 設定種別
        private const string SETKIND_SECTION  = "拠点単位";
        private const string SETKIND_CUSTOMER = "得意先単位";
        private const int SETKIND_SECTION_VALUE = 0;
        private const int SETKIND_CUSTOMER_VALUE = 1;
        // 2011/01/06 Add >>>
        private const string ENTSTCKANSDELIDTDIVNAME0 = "在庫設定に従う";
        private const string ENTSTCKANSDELIDTDIVNAME1 = "棚番を返す";
        private const string ENTSTCKANSDELIDTDIVNAME2 = "委託用に設定";
        // 2011/01/06 Add <<<
        // 2011/10/11 Add >>>
        private const string PRISTCKANSDELIDTDIVNAME0 = "在庫設定に従う";
        // UPD 2012/07/05 湯上 システムテスト障害№42 -------------------------------------------->>>>>
        //private const string PRISTCKANSDELIDTDIVNAME1 = "優先用に設定";
        private const string PRISTCKANSDELIDTDIVNAME1 = "参照用に設定";
        // UPD 2012/07/05 湯上 システムテスト障害№42 --------------------------------------------<<<<<
        // 2011/10/11 Add <<<

        // ADD 2015/02/10 豊沢 SCM高速化 回答納期区分対応 ------------------------------------------>>>>>
        // 納期区分種別
        // 表示値
        private const string ANSDELIDATEDIV_NAME_NONE = "未設定";
        private const string ANSDELIDATEDIV_NAME_TODAY = "当日";
        private const string ANSDELIDATEDIV_NAME_1DAY = "1日";
        private const string ANSDELIDATEDIV_NAME_2DAY = "2～3日";
        private const string ANSDELIDATEDIV_NAME_WEEK = "1週間";
        private const string ANSDELIDATEDIV_NAME_CONFIRM = "要確認";

        // 設定値
        private const Int16 ANSDELIDATEDIV_VALUE_NONE = 0;
        private const Int16 ANSDELIDATEDIV_VALUE_TODAY = 1;
        private const Int16 ANSDELIDATEDIV_VALUE_1DAY = 2;
        private const Int16 ANSDELIDATEDIV_VALUE_2DAY = 3;
        private const Int16 ANSDELIDATEDIV_VALUE_WEEK = 4;
        private const Int16 ANSDELIDATEDIV_VALUE_CONFIRM = 5;
        // ADD 2015/02/10 豊沢 SCM高速化 回答納期区分対応 ------------------------------------------<<<<<

        // 全社共通
        private const string ALL_SECTIONCODE = "00";

        // 回答締切時刻と回答期限の最大入力数
        // 2011/01/06 >>>
        //private const int MAX_ANSWER_COUNT = 6;
        private const int MAX_ANSWER_COUNT = 12;
        // 2011/01/06 <<<

        // 回答締切時刻の0時変換値
        private const int HOUR_24 = 24;

        // _GridIndexバッファ（メインフレーム最小化対応）
        private int _indexBuf;

        private bool isError = false; // ADD 2011/09/07

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

        /// <summary>得意先ガイドの制御オブジェクト</summary>
        private readonly GeneralGuideUIController _customerGuideController;
        /// <summary>
        /// 得意先ガイドの制御オブジェクトを取得します。
        /// </summary>
        /// <value>得意先ガイドの制御オブジェクト</value>
        private GeneralGuideUIController CustomerGuideController
        {
            get { return _customerGuideController; }
        }
        
        #endregion

        #region -- Constructor --
        /// <summary>
        /// SCM納期設定フォームクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : SCM納期設定フォームクラスの新しいインスタンスを初期化します。</br>
        /// <br></br>
        /// </remarks>
        public PMSCM09030UA()
        {
            InitializeComponent();

            // データセット列情報構築処理
            DataSetColumnConstruction();

            // 企業コード取得
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            // SCM納期設定アクセスクラスインスタンス化
            this._scmDeliDateStAcs = new SCMDeliDateStAcs();

            // 比較用クローン
            this._scmDeliDateStClone = null;
      
            // プロパティの初期設定
            this._canPrint = false;
            this._canClose = false;
            this._canDelete = true;		                     // 削除機能
            this._canLogicalDeleteDataExtraction = true;	 // 論理削除データ表示機能
            this._canNew = true;		                     // 新規作成機能
            this._canSpecificationSearch = false;	         // 件数指定検索機能
            this._defaultAutoFillToColumn = false;	         // 列サイズ自動調整機能

            this._dataIndex = -1;
            this._logicalDeleteMode = 0;
            this._scmDeliDateStTable   = new Hashtable();
            this._secInfoAcs        = new SecInfoAcs(1);
            this._customerInfoAcs   = new CustomerInfoAcs();

            // _GridIndexバッファ（メインフレーム最小化対応）
            this._indexBuf = -2;

            // 拠点ガイドのフォーカス制御
            _sectionGuideController = new GeneralGuideUIController(
                this.tEdit_SectionCodeAllowZero2,
                this.SectionGd_ultraButton,
                this.tNedit_AnswerDeadTime1_HH
            );

            // 得意先ガイドのフォーカス制御
            _customerGuideController = new GeneralGuideUIController(
                this.tNedit_CustomerCode,
                this.CustomerGd_ultraButton,
                this.tNedit_AnswerDeadTime1_HH
            );
            
            // キャッシュ情報取得
            this.GetCacheData();
        }
        #endregion

        #region -- Main --
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            System.Windows.Forms.Application.Run(new PMSCM09030UA());
        }        
        #endregion

        #region -- Events --
        /// <summary>画面非表示イベント</summary>
        /// <remarks>画面が非表示状態になった時に発生します。</remarks>
        public event MasterMaintenanceMultiTypeUnDisplayingEventHandler UnDisplaying;
        #endregion

        #region -- Properties --
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
        #endregion

        #region -- Public Methods --

        /// <summary>
        /// 印刷処理
        /// </summary>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 未実装</br>
        /// <br></br>
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
        /// <br></br>
        /// </remarks>
        public void GetBindDataSet(ref DataSet bindDataSet, ref string tableName)
        {
            bindDataSet = this.Bind_DataSet;
            tableName = VIEW_TABLE;
        }

        /// <summary>
        /// データ検索処理
        /// </summary>
        /// <param name="totalCnt">全該当件数</param>
        /// <param name="readCnt">抽出対象件数</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : データを検索し、抽出結果を展開したデータセットと全該当件数を返します。</br>
        /// <br></br>
        /// </remarks>
        public int Search(ref int totalCnt, int readCnt)
        {
            return SearchSCMDeliDateSt(ref totalCnt, readCnt);
        }

        /// <summary>
        /// ネクストデータ検索処理
        /// </summary>
        /// <param name="readCnt">抽出対象件数</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 指定件数分のネクストデータを検索します。</br>
        /// <br></br>
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
        /// <br></br>
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
        /// <br></br>
        /// </remarks>
        public Hashtable GetAppearanceTable()
        {
            Hashtable appearanceTable = new Hashtable();

            // 削除日
            appearanceTable.Add(DELETE_DATE, new GridColAppearance(MGridColDispType.DeletionDataBoth, ContentAlignment.MiddleLeft, "", Color.Red));
            // 拠点コード
            appearanceTable.Add(SECTIONCODE_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 拠点名称
            appearanceTable.Add(SECTIONNAME_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 得意先コード
            appearanceTable.Add(CUSTOMERCODE_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            // 得意先名称
            appearanceTable.Add(CUSTOMERNAME_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            
            // 回答締切時刻１
            appearanceTable.Add(ANSWER_DEAD_TIME_1, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 回答納期１
            appearanceTable.Add(ANSWER_DELIV_DATE_1, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 回答締切時刻２
            appearanceTable.Add(ANSWER_DEAD_TIME_2, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 回答納期２
            appearanceTable.Add(ANSWER_DELIV_DATE_2, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 回答締切時刻３
            appearanceTable.Add(ANSWER_DEAD_TIME_3, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 回答納期３
            appearanceTable.Add(ANSWER_DELIV_DATE_3, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 回答締切時刻４
            appearanceTable.Add(ANSWER_DEAD_TIME_4, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 回答納期４
            appearanceTable.Add(ANSWER_DELIV_DATE_4, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 回答締切時刻５
            appearanceTable.Add(ANSWER_DEAD_TIME_5, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 回答納期５
            appearanceTable.Add(ANSWER_DELIV_DATE_5, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 回答締切時刻６
            appearanceTable.Add(ANSWER_DEAD_TIME_6, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 回答納期６
            appearanceTable.Add(ANSWER_DELIV_DATE_6, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));

            // 2011/01/06 Add >>>
            // 回答締切時刻１（在庫）
            appearanceTable.Add(ANSWER_DEAD_TIME_1_STC, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 回答納期１（在庫）
            appearanceTable.Add(ANSWER_DELIV_DATE_1_STC, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 回答締切時刻２（在庫）
            appearanceTable.Add(ANSWER_DEAD_TIME_2_STC, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 回答納期２（在庫）
            appearanceTable.Add(ANSWER_DELIV_DATE_2_STC, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 回答締切時刻３（在庫）
            appearanceTable.Add(ANSWER_DEAD_TIME_3_STC, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 回答納期３（在庫）
            appearanceTable.Add(ANSWER_DELIV_DATE_3_STC, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 回答締切時刻４（在庫）
            appearanceTable.Add(ANSWER_DEAD_TIME_4_STC, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 回答納期４（在庫）
            appearanceTable.Add(ANSWER_DELIV_DATE_4_STC, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 回答締切時刻５（在庫）
            appearanceTable.Add(ANSWER_DEAD_TIME_5_STC, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 回答納期５（在庫）
            appearanceTable.Add(ANSWER_DELIV_DATE_5_STC, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 回答締切時刻６（在庫）
            appearanceTable.Add(ANSWER_DEAD_TIME_6_STC, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 回答納期６（在庫）
            appearanceTable.Add(ANSWER_DELIV_DATE_6_STC, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 委託在庫回答納期区分
            appearanceTable.Add(ENTSTCKANSDELIDTDIV, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 委託在庫回答納期
            appearanceTable.Add(ENTSTCKANSDELIDATE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 2011/01/06 Add <<<
            // 2011/10/11 Add >>>
            // 優先在庫回答納期区分
            appearanceTable.Add(PRISTCKANSDELIDTDIV, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 優先在庫回答納期
            appearanceTable.Add(PRISTCKANSDELIDATE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 2011/10/11 Add <<<
            // 2012/08/30 ADD TAKAGAWA 2012/10月配信予定 SCM障害№10345 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            // 回答納期（在庫不足）
            appearanceTable.Add(ANSDELDATSHORTOFSTC, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 回答納期（在庫数無し）
            appearanceTable.Add(ANSDELDATWITHOUTSTC, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 委託在庫回答納期（在庫不足）
            appearanceTable.Add(ENTSTCANSDELDATSHORT, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 委託在庫回答納期（在庫数無し）
            appearanceTable.Add(ENTSTCANSDELDATWIOUT, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 参照在庫回答納期（在庫不足）
            appearanceTable.Add(PRISTCANSDELDATSHORT, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 参照在庫回答納期（在庫数無し）
            appearanceTable.Add(PRISTCANSDELDATWIOUT, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 2012/08/30 ADD TAKAGAWA 2012/10月配信予定 SCM障害№10345 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

            // ADD 2015/02/10 豊沢 SCM高速化 回答納期区分対応 ------------------------------------------>>>>>
            //回答納期区分１（取寄）
            appearanceTable.Add(ANSWER_DELIV_DATE_DIV_1, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //回答納期区分２（取寄）
            appearanceTable.Add(ANSWER_DELIV_DATE_DIV_2, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //回答納期区分３（取寄）
            appearanceTable.Add(ANSWER_DELIV_DATE_DIV_3, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //回答納期区分４（取寄）
            appearanceTable.Add(ANSWER_DELIV_DATE_DIV_4, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //回答納期区分５（取寄）
            appearanceTable.Add(ANSWER_DELIV_DATE_DIV_5, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //回答納期区分６（取寄）
            appearanceTable.Add(ANSWER_DELIV_DATE_DIV_6, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //回答納期区分１（在庫）
            appearanceTable.Add(ANSWER_DELIV_DATE_DIV_1_STC, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //回答納期区分２（在庫）
            appearanceTable.Add(ANSWER_DELIV_DATE_DIV_2_STC, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //回答納期区分３（在庫）
            appearanceTable.Add(ANSWER_DELIV_DATE_DIV_3_STC, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //回答納期区分４（在庫）
            appearanceTable.Add(ANSWER_DELIV_DATE_DIV_4_STC, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //回答納期区分５（在庫）
            appearanceTable.Add(ANSWER_DELIV_DATE_DIV_5_STC, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //回答納期区分６（在庫）
            appearanceTable.Add(ANSWER_DELIV_DATE_DIV_6_STC, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //回答納期区分（在庫不足）
            appearanceTable.Add(ANSDELDATSHORTOFSTC_DIV, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //回答納期区分（在庫数無し）
            appearanceTable.Add(ANSDELDATWITHOUTSTC_DIV, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //委託在庫回答納期区分（在庫）
            appearanceTable.Add(ENTSTCKANSDELIDATE_DIV, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //委託在庫回答納期区分（在庫不足）
            appearanceTable.Add(ENTSTCANSDELDATSHORT_DIV, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //委託在庫回答納期区分（在庫数無し）
            appearanceTable.Add(ENTSTCANSDELDATWIOUT_DIV, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //参照在庫回答納期区分（在庫）
            appearanceTable.Add(PRISTCKANSDELIDATE_DIV, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //参照在庫回答納期区分（在庫不足）
            appearanceTable.Add(PRISTCANSDELDATSHORT_DIV, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //参照在庫回答納期区分（在庫数無し）
            appearanceTable.Add(PRISTCANSDELDATWIOUT_DIV, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // ADD 2015/02/10 豊沢 SCM高速化 回答納期区分対応 ------------------------------------------<<<<<

            // GUID
            appearanceTable.Add(GUID_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));

            return appearanceTable;
        }
        #endregion

        #region -- Private Methods --

        /// <summary>
        /// フォームクローズ処理
        /// </summary>
        /// <param name="dialogResult">ダイアログ結果</param>
        /// <remarks>
        /// <br>Note       : フォームを閉じます。その際画面クローズイベント等の発生を行います。</br>
        /// <br></br>
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
            this._indexBuf = -2;

            // 比較用クローンクリア
            this._scmDeliDateStClone = null;

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
        /// <br></br>
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
                            PROGRAM_ID, 						// アセンブリＩＤまたはクラスＩＤ
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
                            PROGRAM_ID, 						// アセンブリＩＤまたはクラスＩＤ
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
        /// <br></br>
        /// </remarks>
        private void DataSetColumnConstruction()
        {
            DataTable scmDeliDateStTable = new DataTable(VIEW_TABLE);
            scmDeliDateStTable.Columns.Add(DELETE_DATE, typeof(string));

            scmDeliDateStTable.Columns.Add(SECTIONCODE_TITLE, typeof(string));      // 拠点コード
            scmDeliDateStTable.Columns.Add(SECTIONNAME_TITLE, typeof(string));      // 拠点名称
            scmDeliDateStTable.Columns.Add(CUSTOMERCODE_TITLE, typeof(string));     // 得意先コード
            scmDeliDateStTable.Columns.Add(CUSTOMERNAME_TITLE, typeof(string));     // 得意先名称

            scmDeliDateStTable.Columns.Add(ANSWER_DEAD_TIME_1, typeof(string));     // 回答締切時刻１
            scmDeliDateStTable.Columns.Add(ANSWER_DELIV_DATE_1, typeof(string));    // 回答納期１
            // ADD 2015/02/10 豊沢 SCM高速化 回答納期区分対応 ------------------------------------------>>>>>
            scmDeliDateStTable.Columns.Add(ANSWER_DELIV_DATE_DIV_1, typeof(string));    // 回答納期区分１
            // ADD 2015/02/10 豊沢 SCM高速化 回答納期区分対応 ------------------------------------------<<<<<
            scmDeliDateStTable.Columns.Add(ANSWER_DEAD_TIME_2, typeof(string));     // 回答締切時刻２
            scmDeliDateStTable.Columns.Add(ANSWER_DELIV_DATE_2, typeof(string));    // 回答納期２
            // ADD 2015/02/10 豊沢 SCM高速化 回答納期区分対応 ------------------------------------------>>>>>
            scmDeliDateStTable.Columns.Add(ANSWER_DELIV_DATE_DIV_2, typeof(string));    // 回答納期区分２
            // ADD 2015/02/10 豊沢 SCM高速化 回答納期区分対応 ------------------------------------------<<<<<
            scmDeliDateStTable.Columns.Add(ANSWER_DEAD_TIME_3, typeof(string));     // 回答締切時刻３
            scmDeliDateStTable.Columns.Add(ANSWER_DELIV_DATE_3, typeof(string));    // 回答納期３
            // ADD 2015/02/10 豊沢 SCM高速化 回答納期区分対応 ------------------------------------------>>>>>
            scmDeliDateStTable.Columns.Add(ANSWER_DELIV_DATE_DIV_3, typeof(string));    // 回答納期区分３
            // ADD 2015/02/10 豊沢 SCM高速化 回答納期区分対応 ------------------------------------------<<<<<
            scmDeliDateStTable.Columns.Add(ANSWER_DEAD_TIME_4, typeof(string));     // 回答締切時刻４
            scmDeliDateStTable.Columns.Add(ANSWER_DELIV_DATE_4, typeof(string));    // 回答納期４
            // ADD 2015/02/10 豊沢 SCM高速化 回答納期区分対応 ------------------------------------------>>>>>
            scmDeliDateStTable.Columns.Add(ANSWER_DELIV_DATE_DIV_4, typeof(string));    // 回答納期区分４
            // ADD 2015/02/10 豊沢 SCM高速化 回答納期区分対応 ------------------------------------------<<<<<
            scmDeliDateStTable.Columns.Add(ANSWER_DEAD_TIME_5, typeof(string));     // 回答締切時刻５
            scmDeliDateStTable.Columns.Add(ANSWER_DELIV_DATE_5, typeof(string));    // 回答納期５
            // ADD 2015/02/10 豊沢 SCM高速化 回答納期区分対応 ------------------------------------------>>>>>
            scmDeliDateStTable.Columns.Add(ANSWER_DELIV_DATE_DIV_5, typeof(string));    // 回答納期区分５
            // ADD 2015/02/10 豊沢 SCM高速化 回答納期区分対応 ------------------------------------------<<<<<
            scmDeliDateStTable.Columns.Add(ANSWER_DEAD_TIME_6, typeof(string));     // 回答締切時刻６
            scmDeliDateStTable.Columns.Add(ANSWER_DELIV_DATE_6, typeof(string));    // 回答納期６
            // ADD 2015/02/10 豊沢 SCM高速化 回答納期区分対応 ------------------------------------------>>>>>
            scmDeliDateStTable.Columns.Add(ANSWER_DELIV_DATE_DIV_6, typeof(string));    // 回答納期区分６
            // ADD 2015/02/10 豊沢 SCM高速化 回答納期区分対応 ------------------------------------------<<<<<

            // 2011/01/06 Add >>>
            scmDeliDateStTable.Columns.Add(ANSWER_DEAD_TIME_1_STC, typeof(string));     // 回答締切時刻１（在庫）
            scmDeliDateStTable.Columns.Add(ANSWER_DELIV_DATE_1_STC, typeof(string));    // 回答納期１（在庫）
            // ADD 2015/02/10 豊沢 SCM高速化 回答納期区分対応 ------------------------------------------>>>>>
            scmDeliDateStTable.Columns.Add(ANSWER_DELIV_DATE_DIV_1_STC, typeof(string));    // 回答納期区分１（在庫）
            // ADD 2015/02/10 豊沢 SCM高速化 回答納期区分対応 ------------------------------------------<<<<<
            // 2012/10/03 ADD TAKAGAWA 2012/10/17配信システムテスト障害No32 ----->>>>>>>>>>>>>
            scmDeliDateStTable.Columns.Add(ANSDELDATSHORTOFSTC, typeof(string));        // 回答納期（在庫不足）
            // ADD 2015/02/10 豊沢 SCM高速化 回答納期区分対応 ------------------------------------------>>>>>
            scmDeliDateStTable.Columns.Add(ANSDELDATSHORTOFSTC_DIV, typeof(string));    // 回答納期区分（在庫不足）
            // ADD 2015/02/10 豊沢 SCM高速化 回答納期区分対応 ------------------------------------------<<<<<
            scmDeliDateStTable.Columns.Add(ANSDELDATWITHOUTSTC, typeof(string));        // 回答納期（在庫数無し）
            // ADD 2015/02/10 豊沢 SCM高速化 回答納期区分対応 ------------------------------------------>>>>>
            scmDeliDateStTable.Columns.Add(ANSDELDATWITHOUTSTC_DIV, typeof(string));    // 回答納期区分（在庫数無し）
            // ADD 2015/02/10 豊沢 SCM高速化 回答納期区分対応 ------------------------------------------<<<<<
            // 2012/10/03 ADD TAKAGAWA 2012/10/17配信システムテスト障害No32 -----<<<<<<<<<<<<<
            scmDeliDateStTable.Columns.Add(ANSWER_DEAD_TIME_2_STC, typeof(string));     // 回答締切時刻２（在庫）
            scmDeliDateStTable.Columns.Add(ANSWER_DELIV_DATE_2_STC, typeof(string));    // 回答納期２（在庫）
            // ADD 2015/02/10 豊沢 SCM高速化 回答納期区分対応 ------------------------------------------>>>>>
            scmDeliDateStTable.Columns.Add(ANSWER_DELIV_DATE_DIV_2_STC, typeof(string));    // 回答納期区分２（在庫）
            // ADD 2015/02/10 豊沢 SCM高速化 回答納期区分対応 ------------------------------------------<<<<<
            scmDeliDateStTable.Columns.Add(ANSWER_DEAD_TIME_3_STC, typeof(string));     // 回答締切時刻３（在庫）
            scmDeliDateStTable.Columns.Add(ANSWER_DELIV_DATE_3_STC, typeof(string));    // 回答納期３（在庫）
            // ADD 2015/02/10 豊沢 SCM高速化 回答納期区分対応 ------------------------------------------>>>>>
            scmDeliDateStTable.Columns.Add(ANSWER_DELIV_DATE_DIV_3_STC, typeof(string));    // 回答納期区分３（在庫）
            // ADD 2015/02/10 豊沢 SCM高速化 回答納期区分対応 ------------------------------------------<<<<<
            scmDeliDateStTable.Columns.Add(ANSWER_DEAD_TIME_4_STC, typeof(string));     // 回答締切時刻４（在庫）
            scmDeliDateStTable.Columns.Add(ANSWER_DELIV_DATE_4_STC, typeof(string));    // 回答納期４（在庫）
            // ADD 2015/02/10 豊沢 SCM高速化 回答納期区分対応 ------------------------------------------>>>>>
            scmDeliDateStTable.Columns.Add(ANSWER_DELIV_DATE_DIV_4_STC, typeof(string));    // 回答納期区分４（在庫）
            // ADD 2015/02/10 豊沢 SCM高速化 回答納期区分対応 ------------------------------------------<<<<<
            scmDeliDateStTable.Columns.Add(ANSWER_DEAD_TIME_5_STC, typeof(string));     // 回答締切時刻５（在庫）
            scmDeliDateStTable.Columns.Add(ANSWER_DELIV_DATE_5_STC, typeof(string));    // 回答納期５（在庫）
            // ADD 2015/02/10 豊沢 SCM高速化 回答納期区分対応 ------------------------------------------>>>>>
            scmDeliDateStTable.Columns.Add(ANSWER_DELIV_DATE_DIV_5_STC, typeof(string));    // 回答納期区分５（在庫）
            // ADD 2015/02/10 豊沢 SCM高速化 回答納期区分対応 ------------------------------------------<<<<<
            scmDeliDateStTable.Columns.Add(ANSWER_DEAD_TIME_6_STC, typeof(string));     // 回答締切時刻６（在庫）
            scmDeliDateStTable.Columns.Add(ANSWER_DELIV_DATE_6_STC, typeof(string));    // 回答納期６（在庫）
            // ADD 2015/02/10 豊沢 SCM高速化 回答納期区分対応 ------------------------------------------>>>>>
            scmDeliDateStTable.Columns.Add(ANSWER_DELIV_DATE_DIV_6_STC, typeof(string));    // 回答納期区分６（在庫）
            // ADD 2015/02/10 豊沢 SCM高速化 回答納期区分対応 ------------------------------------------<<<<<
            scmDeliDateStTable.Columns.Add(ENTSTCKANSDELIDTDIV, typeof(string));    // 委託在庫回答納期区分
            scmDeliDateStTable.Columns.Add(ENTSTCKANSDELIDATE, typeof(string));    // 委託在庫回答納期
            // ADD 2015/02/10 豊沢 SCM高速化 回答納期区分対応 ------------------------------------------>>>>>
            scmDeliDateStTable.Columns.Add(ENTSTCKANSDELIDATE_DIV, typeof(string));    // 委託在庫回答納期区分（在庫）
            // ADD 2015/02/10 豊沢 SCM高速化 回答納期区分対応 ------------------------------------------<<<<<
            // 2011/01/06 Add <<<
            // 2012/10/03 ADD TAKAGAWA 2012/10/17配信システムテスト障害No32 ----->>>>>>>>>>>>>
            scmDeliDateStTable.Columns.Add(ENTSTCANSDELDATSHORT, typeof(string));       // 委託在庫回答納期（在庫不足）
            // ADD 2015/02/10 豊沢 SCM高速化 回答納期区分対応 ------------------------------------------>>>>>
            scmDeliDateStTable.Columns.Add(ENTSTCANSDELDATSHORT_DIV, typeof(string));    // 委託在庫回答納期区分（在庫不足）
            // ADD 2015/02/10 豊沢 SCM高速化 回答納期区分対応 ------------------------------------------<<<<<
            scmDeliDateStTable.Columns.Add(ENTSTCANSDELDATWIOUT, typeof(string));       // 委託在庫回答納期（在庫数無し）
            // ADD 2015/02/10 豊沢 SCM高速化 回答納期区分対応 ------------------------------------------>>>>>
            scmDeliDateStTable.Columns.Add(ENTSTCANSDELDATWIOUT_DIV, typeof(string));    // 委託在庫回答納期区分（在庫数無し）
            // ADD 2015/02/10 豊沢 SCM高速化 回答納期区分対応 ------------------------------------------<<<<<
            // 2012/10/03 ADD TAKAGAWA 2012/10/17配信システムテスト障害No32 -----<<<<<<<<<<<<<
            // 2011/10/11 Add >>>
            scmDeliDateStTable.Columns.Add(PRISTCKANSDELIDTDIV, typeof(string));    // 優先在庫回答納期区分
            scmDeliDateStTable.Columns.Add(PRISTCKANSDELIDATE, typeof(string));    // 優先在庫回答納期
            // ADD 2015/02/10 豊沢 SCM高速化 回答納期区分対応 ------------------------------------------>>>>>
            scmDeliDateStTable.Columns.Add(PRISTCKANSDELIDATE_DIV, typeof(string));    // 委託在庫回答納期区分（在庫）
            // ADD 2015/02/10 豊沢 SCM高速化 回答納期区分対応 ------------------------------------------<<<<<
            // 2011/10/11 Add <<<
            // 2012/08/30 ADD TAKAGAWA 2012/10月配信予定 SCM障害№10345 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            // 2012/10/03 DEL TAKAGAWA 2012/10/17配信システムテスト障害No32 ----->>>>>>>>>>>>>
            //scmDeliDateStTable.Columns.Add(ANSDELDATSHORTOFSTC, typeof(string));    // 回答納期（在庫不足）
            //scmDeliDateStTable.Columns.Add(ANSDELDATWITHOUTSTC, typeof(string));    // 回答納期（在庫数無し）
            //scmDeliDateStTable.Columns.Add(ENTSTCANSDELDATSHORT, typeof(string));   // 委託在庫回答納期（在庫不足）
            //scmDeliDateStTable.Columns.Add(ENTSTCANSDELDATWIOUT, typeof(string));   // 委託在庫回答納期（在庫数無し）
            // 2012/10/03 DEL TAKAGAWA 2012/10/17配信システムテスト障害No32 -----<<<<<<<<<<<<<
            scmDeliDateStTable.Columns.Add(PRISTCANSDELDATSHORT, typeof(string));   // 参照在庫回答納期（在庫不足）
            // ADD 2015/02/10 豊沢 SCM高速化 回答納期区分対応 ------------------------------------------>>>>>
            scmDeliDateStTable.Columns.Add(PRISTCANSDELDATSHORT_DIV, typeof(string));    // 委託在庫回答納期区分（在庫不足）
            // ADD 2015/02/10 豊沢 SCM高速化 回答納期区分対応 ------------------------------------------<<<<<
            scmDeliDateStTable.Columns.Add(PRISTCANSDELDATWIOUT, typeof(string));   // 参照在庫回答納期（在庫数無し）
            // ADD 2015/02/10 豊沢 SCM高速化 回答納期区分対応 ------------------------------------------>>>>>
            scmDeliDateStTable.Columns.Add(PRISTCANSDELDATWIOUT_DIV, typeof(string));    // 委託在庫回答納期区分（在庫数無し）
            // ADD 2015/02/10 豊沢 SCM高速化 回答納期区分対応 ------------------------------------------<<<<<
            // 2012/08/30 ADD TAKAGAWA 2012/10月配信予定 SCM障害№10345 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
            scmDeliDateStTable.Columns.Add(GUID_TITLE, typeof(Guid));

            this.Bind_DataSet.Tables.Add(scmDeliDateStTable);
        }

        /// <summary>
        /// 画面初期設定
        /// </summary>
        /// <remarks>
        /// <br>Note       : UI画面の初期設定を行います。</br>
        /// <br></br>
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

            // 設定種別
            this.SetKind_tComboEditor.Items.Clear();
            this.SetKind_tComboEditor.Items.Add(SETKIND_SECTION_VALUE, SETKIND_SECTION);
            this.SetKind_tComboEditor.Items.Add(SETKIND_CUSTOMER_VALUE,SETKIND_CUSTOMER);
            this.SetKind_tComboEditor.MaxDropDownItems = this.SetKind_tComboEditor.Items.Count;
        }

        /// <summary>
        /// 画面再構築処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面を再構築します。</br>
        /// <br></br>
        /// </remarks>
        private void ScreenReconstruction()
        {
            if (this._dataIndex < 0)
            {
                // 新規モード
                this._logicalDeleteMode = -1;

                SCMDeliDateSt newSCMDeliDateSt = new SCMDeliDateSt();
                
                // クローン作成
                this._scmDeliDateStClone = newSCMDeliDateSt.Clone();
                ScreenToSCMDeliDateSt(ref this._scmDeliDateStClone);
            }
            else
            {
                Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this._dataIndex][GUID_TITLE];
                SCMDeliDateSt scmDeliDateSt = (SCMDeliDateSt)this._scmDeliDateStTable[guid];

                // SCM納期設定オブジェクトを画面に展開
                SCMDeliDateStToScreen(scmDeliDateSt);

                if (scmDeliDateSt.LogicalDeleteCode == 0)
                {
                    // 更新モード
                    this._logicalDeleteMode = 0;

                    // クローン作成
                    this._scmDeliDateStClone = scmDeliDateSt.Clone();
                    ScreenToSCMDeliDateSt(ref this._scmDeliDateStClone);
                }
                else
                {
                    // 削除モード
                    this._logicalDeleteMode = 1;
                }
            }
            // _GridIndexバッファ保持（メインフレーム最小化対応）
            this._indexBuf = this._dataIndex;

            // 画面入力許可制御処理
            ScreenInputPermissionControl();
        }

        /// <summary>
        /// SCM納期設定オブジェクト画面展開処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : SCM納期設定オブジェクトから画面にデータを展開します。</br>
        /// <br></br>
        /// </remarks>
        private void SCMDeliDateStToScreen(SCMDeliDateSt scmDeliDateSt)
        {
            // 拠点コードは空？
            if ((scmDeliDateSt.SectionCode.Trim() == "") && (this._dataIndex >= 0))
            {
                SetKind_tComboEditor.SelectedIndex = 1;

                // 得意先コード
                tNedit_CustomerCode.DataText = scmDeliDateSt.CustomerCode.ToString();

                // 得意先名称
                CustomerName_tEdit.DataText = GetCustomerName(scmDeliDateSt.CustomerCode);

                // 拠点非表示
                this.SectionCode_Title_Label.Visible = false;
                this.tEdit_SectionCodeAllowZero2.Visible = false;
                this.SectionGd_ultraButton.Visible = false;
                this.SectionNm_tEdit.Visible = false;
                this.SectionNm_Label.Visible = false;

                // 得意先表示
                this.Customer_Label.Top = this.SectionCode_Title_Label.Top;
                this.tNedit_CustomerCode.Top = this.Customer_Label.Top;
                this.CustomerGd_ultraButton.Top = this.Customer_Label.Top;
                this.CustomerName_tEdit.Top = this.Customer_Label.Top;
                this.Customer_Label.Visible = true;
                this.tNedit_CustomerCode.Visible = true;
                this.CustomerGd_ultraButton.Visible = true;
                this.CustomerName_tEdit.Visible = true;
            }
            else
            {
                SetKind_tComboEditor.SelectedIndex = 0;

                this.tEdit_SectionCodeAllowZero2.Value = scmDeliDateSt.SectionCode.TrimEnd();  // 拠点コード
                this.SectionNm_tEdit.Value = GetSectionName(scmDeliDateSt.SectionCode);// 拠点名称
                
                // 拠点表示
                this.SectionCode_Title_Label.Visible = true;
                this.tEdit_SectionCodeAllowZero2.Visible = true;
                this.SectionGd_ultraButton.Visible = true;
                this.SectionNm_tEdit.Visible = true;
                this.SectionNm_Label.Visible = true;

                // 得意先非表示
                this.Customer_Label.Visible = false;
                this.tNedit_CustomerCode.Visible = false;
                this.CustomerGd_ultraButton.Visible = false;
                this.CustomerName_tEdit.Visible = false;
            }

            int hour;
            int min;

            // 回答締切時刻１
            // 回答納期１            
            if (scmDeliDateSt.AnswerDeadTime1 > 0)
            {
                hour = (scmDeliDateSt.AnswerDeadTime1 / 10000) % HOUR_24;
                min = (scmDeliDateSt.AnswerDeadTime1 % 10000) / 100;
                this.tNedit_AnswerDeadTime1_HH.SetInt(hour);
                this.tNedit_AnswerDeadTime1_MM.SetInt(min);
                this.tEdit_AnswerDelivDate1.Value = scmDeliDateSt.AnswerDelivDate1;
            }

            // 回答締切時刻２
            if (scmDeliDateSt.AnswerDeadTime2 > 0)
            {
                hour = (scmDeliDateSt.AnswerDeadTime2 / 10000) % HOUR_24;
                min = (scmDeliDateSt.AnswerDeadTime2 % 10000) / 100;
                this.tNedit_AnswerDeadTime2_HH.SetInt(hour);
                this.tNedit_AnswerDeadTime2_MM.SetInt(min);
                // 回答納期２
                this.tEdit_AnswerDelivDate2.Value = scmDeliDateSt.AnswerDelivDate2;
            }

            // 回答締切時刻３
            if (scmDeliDateSt.AnswerDeadTime3 > 0)
            {
                hour = (scmDeliDateSt.AnswerDeadTime3 / 10000) % HOUR_24;
                min = (scmDeliDateSt.AnswerDeadTime3 % 10000) / 100;
                this.tNedit_AnswerDeadTime3_HH.SetInt(hour);
                this.tNedit_AnswerDeadTime3_MM.SetInt(min);
                // 回答納期３
                this.tEdit_AnswerDelivDate3.Value = scmDeliDateSt.AnswerDelivDate3;
            }

            // 回答締切時刻４
            if (scmDeliDateSt.AnswerDeadTime4 > 0)
            {
                hour = (scmDeliDateSt.AnswerDeadTime4 / 10000) % HOUR_24;
                min = (scmDeliDateSt.AnswerDeadTime4 % 10000) / 100;
                this.tNedit_AnswerDeadTime4_HH.SetInt(hour);
                this.tNedit_AnswerDeadTime4_MM.SetInt(min);
                // 回答納期４
                this.tEdit_AnswerDelivDate4.Value = scmDeliDateSt.AnswerDelivDate4;
            }

            // 回答締切時刻５
            if (scmDeliDateSt.AnswerDeadTime5 > 0)
            {
                hour = (scmDeliDateSt.AnswerDeadTime5 / 10000) % HOUR_24;
                min = (scmDeliDateSt.AnswerDeadTime5 % 10000) / 100;
                this.tNedit_AnswerDeadTime5_HH.SetInt(hour);
                this.tNedit_AnswerDeadTime5_MM.SetInt(min);
                // 回答納期５
                this.tEdit_AnswerDelivDate5.Value = scmDeliDateSt.AnswerDelivDate5;
            }

            // 回答締切時刻６
            if (scmDeliDateSt.AnswerDeadTime6 > 0)
            {
                hour = (scmDeliDateSt.AnswerDeadTime6 / 10000) % HOUR_24;
                min = (scmDeliDateSt.AnswerDeadTime6 % 10000) / 100;
                this.tNedit_AnswerDeadTime6_HH.SetInt(hour);
                this.tNedit_AnswerDeadTime6_MM.SetInt(min);
                // 回答納期６
                this.tEdit_AnswerDelivDate6.Value = scmDeliDateSt.AnswerDelivDate6;
            }

            // 2011/01/06 Add >>>
            // 回答締切時刻１（在庫）
            // 回答納期１（在庫）
            if (scmDeliDateSt.AnswerDeadTime1Stc > 0)
            {
                hour = (scmDeliDateSt.AnswerDeadTime1Stc / 10000) % HOUR_24;
                min = (scmDeliDateSt.AnswerDeadTime1Stc % 10000) / 100;
                this.tNedit_AnswerDeadTime1Stc_HH.SetInt(hour);
                this.tNedit_AnswerDeadTime1Stc_MM.SetInt(min);
                this.tEdit_AnswerDelivDate1Stc.Value = scmDeliDateSt.AnswerDelivDate1Stc;
            }

            // 回答締切時刻２（在庫）
            if (scmDeliDateSt.AnswerDeadTime2Stc > 0)
            {
                hour = (scmDeliDateSt.AnswerDeadTime2Stc / 10000) % HOUR_24;
                min = (scmDeliDateSt.AnswerDeadTime2Stc % 10000) / 100;
                this.tNedit_AnswerDeadTime2Stc_HH.SetInt(hour);
                this.tNedit_AnswerDeadTime2Stc_MM.SetInt(min);
                // 回答納期２（在庫）
                this.tEdit_AnswerDelivDate2Stc.Value = scmDeliDateSt.AnswerDelivDate2Stc;
            }

            // 回答締切時刻３（在庫）
            if (scmDeliDateSt.AnswerDeadTime3Stc > 0)
            {
                hour = (scmDeliDateSt.AnswerDeadTime3Stc / 10000) % HOUR_24;
                min = (scmDeliDateSt.AnswerDeadTime3Stc % 10000) / 100;
                this.tNedit_AnswerDeadTime3Stc_HH.SetInt(hour);
                this.tNedit_AnswerDeadTime3Stc_MM.SetInt(min);
                // 回答納期３（在庫）
                this.tEdit_AnswerDelivDate3Stc.Value = scmDeliDateSt.AnswerDelivDate3Stc;
            }

            // 回答締切時刻４（在庫）
            if (scmDeliDateSt.AnswerDeadTime4Stc > 0)
            {
                hour = (scmDeliDateSt.AnswerDeadTime4Stc / 10000) % HOUR_24;
                min = (scmDeliDateSt.AnswerDeadTime4Stc % 10000) / 100;
                this.tNedit_AnswerDeadTime4Stc_HH.SetInt(hour);
                this.tNedit_AnswerDeadTime4Stc_MM.SetInt(min);
                // 回答納期４（在庫）
                this.tEdit_AnswerDelivDate4Stc.Value = scmDeliDateSt.AnswerDelivDate4Stc;
            }

            // 回答締切時刻５（在庫）
            if (scmDeliDateSt.AnswerDeadTime5Stc > 0)
            {
                hour = (scmDeliDateSt.AnswerDeadTime5Stc / 10000) % HOUR_24;
                min = (scmDeliDateSt.AnswerDeadTime5Stc % 10000) / 100;
                this.tNedit_AnswerDeadTime5Stc_HH.SetInt(hour);
                this.tNedit_AnswerDeadTime5Stc_MM.SetInt(min);
                // 回答納期５（在庫）
                this.tEdit_AnswerDelivDate5Stc.Value = scmDeliDateSt.AnswerDelivDate5Stc;
            }

            // 回答締切時刻６（在庫）
            if (scmDeliDateSt.AnswerDeadTime6Stc > 0)
            {
                hour = (scmDeliDateSt.AnswerDeadTime6Stc / 10000) % HOUR_24;
                min = (scmDeliDateSt.AnswerDeadTime6Stc % 10000) / 100;
                this.tNedit_AnswerDeadTime6Stc_HH.SetInt(hour);
                this.tNedit_AnswerDeadTime6Stc_MM.SetInt(min);
                // 回答納期６（在庫）
                this.tEdit_AnswerDelivDate6Stc.Value = scmDeliDateSt.AnswerDelivDate6Stc;
            }

            // 委託在庫回答納期区分
            // 2011/05/27 >>>
            //this.tComboEditor_EntStckAnsDeliDtDiv.SelectedIndex = scmDeliDateSt.EntStckAnsDeliDtDiv;
            int select = 0;
            switch (scmDeliDateSt.EntStckAnsDeliDtDiv)
            {
                case 0:
                    select = 0;
                    break;
                case 2:
                    select = 1;
                    break;
                default:
                    select = 0;
                    break;
            }
            this.tComboEditor_EntStckAnsDeliDtDiv.SelectedIndex = select;
            // 2011/05/27 <<<

            // 委託在庫回答納期
            this.tEdit_EntStckAnsDeliDate.Value = scmDeliDateSt.EntStckAnsDeliDate;
            // 2011/01/06 Add <<<

            // 2011/10/11 Add >>>
            // 優先在庫回答納期区分
            int select2 = 0;
            switch (scmDeliDateSt.PriStckAnsDeliDtDiv)
            {
                case 0:
                    select2 = 0;
                    break;
                case 1:
                    select2 = 1;
                    break;
                default:
                    select2 = 0;
                    break;
            }
            this.tComboEditor_PriStckAnsDeliDtDiv.SelectedIndex = select2;
            // 優先在庫回答納期
            this.tEdit_PriStckAnsDeliDate.Value = scmDeliDateSt.PriStckAnsDeliDate;
            // 2011/10/11 Add <<<
            // 2012/08/30 ADD TAKAGAWA 2012/10月配信予定 SCM障害№10345 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            // 回答納期（在庫不足）
            this.tEdit_AnswerDelivDate1StcShortage.Value = scmDeliDateSt.AnsDelDatShortOfStc;
            // 回答納期（在庫数無し）
            this.tEdit_AnswerDelivDate1StcNotStc.Value = scmDeliDateSt.AnsDelDatWithoutStc;
            // 委託在庫回答納期（在庫不足）
            this.tEdit_EntStckAnsDeliDateShortage.Value = scmDeliDateSt.EntStcAnsDelDatShort;
            // 委託在庫回答納期（在庫数無し）
            this.tEdit_EntStckAnsDeliDateNoStc.Value = scmDeliDateSt.EntStcAnsDelDatWiout;
            // 参照在庫回答納期（在庫不足）
            this.tEdit_PriStckAnsDeliDateShortage.Value = scmDeliDateSt.PriStcAnsDelDatShort;
            // 参照在庫回答納期（在庫数無し）
            this.tEdit_PriStckAnsDeliDateNoStc.Value = scmDeliDateSt.PriStcAnsDelDatWiout;
            // 2012/08/30 ADD TAKAGAWA 2012/10月配信予定 SCM障害№10345 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
            // ADD 2015/02/10 豊沢 SCM高速化 回答納期区分対応 ------------------------------------------>>>>>
            // 回答納期区分１（取寄）
            this.tComboEditor_AnsDelivDateDiv1.SelectedIndex = scmDeliDateSt.AnsDelDtDiv1;
            // 回答納期区分２（取寄）
            this.tComboEditor_AnsDelivDateDiv2.SelectedIndex = scmDeliDateSt.AnsDelDtDiv2;
            // 回答納期区分３（取寄）
            this.tComboEditor_AnsDelivDateDiv3.SelectedIndex = scmDeliDateSt.AnsDelDtDiv3;
            // 回答納期区分４（取寄）
            this.tComboEditor_AnsDelivDateDiv4.SelectedIndex = scmDeliDateSt.AnsDelDtDiv4;
            // 回答納期区分５（取寄）
            this.tComboEditor_AnsDelivDateDiv5.SelectedIndex = scmDeliDateSt.AnsDelDtDiv5;
            // 回答納期区分６（取寄）
            this.tComboEditor_AnsDelivDateDiv6.SelectedIndex = scmDeliDateSt.AnsDelDtDiv6;
            // 回答納期区分１（在庫）
            this.tComboEditor_AnsDelivDtDiv1Stc.SelectedIndex = scmDeliDateSt.AnsDelDtDiv1Stc;
            // 回答納期区分２（在庫）
            this.tComboEditor_AnsDelivDtDiv2Stc.SelectedIndex = scmDeliDateSt.AnsDelDtDiv2Stc;
            // 回答納期区分３（在庫）
            this.tComboEditor_AnsDelivDtDiv3Stc.SelectedIndex = scmDeliDateSt.AnsDelDtDiv3Stc;
            // 回答納期区分４（在庫）
            this.tComboEditor_AnsDelivDtDiv4Stc.SelectedIndex = scmDeliDateSt.AnsDelDtDiv4Stc;
            // 回答納期区分５（在庫）
            this.tComboEditor_AnsDelivDtDiv5Stc.SelectedIndex = scmDeliDateSt.AnsDelDtDiv5Stc;
            // 回答納期区分６（在庫）
            this.tComboEditor_AnsDelivDtDiv6Stc.SelectedIndex = scmDeliDateSt.AnsDelDtDiv6Stc;
            // 回答納期区分（在庫不足）
            this.tComboEditor_AnsDelDtShoStcDiv.SelectedIndex = scmDeliDateSt.AnsDelDtShoStcDiv;
            // 回答納期区分（在庫数無し）
            this.tComboEditor_AnsDelDtWioStcDiv.SelectedIndex = scmDeliDateSt.AnsDelDtWioStcDiv;
            // 委託在庫回答納期区分（在庫）
            this.tComboEditor_EntStcAnsDelDtStcDiv.SelectedIndex = scmDeliDateSt.EntAnsDelDtStcDiv;
            // 委託在庫回答納期区分（在庫不足）
            this.tComboEditor_EntStcAnsDelDtShoDiv.SelectedIndex = scmDeliDateSt.EntAnsDelDtShoDiv;
            // 委託在庫回答納期区分（在庫数無し）
            this.tComboEditor_EntStcAnsDelDtWioDiv.SelectedIndex = scmDeliDateSt.EntAnsDelDtWioDiv;
            // 参照在庫回答納期区分（在庫）
            this.tComboEditor_PriStcAnsDelDtStcDiv.SelectedIndex = scmDeliDateSt.PriAnsDelDtStcDiv;
            // 参照在庫回答納期区分（在庫不足）
            this.tComboEditor_PriStcAnsDelDtShoDiv.SelectedIndex = scmDeliDateSt.PriAnsDelDtShoDiv;
            // 参照在庫回答納期区分（在庫数無し）
            this.tComboEditor_PriStcAnsDelDtWioDiv.SelectedIndex = scmDeliDateSt.PriAnsDelDtWioDiv;
            // ADD 2015/02/10 豊沢 SCM高速化 回答納期区分対応 ------------------------------------------<<<<<
        }

        /// <summary>
        /// 画面情報をSCM納期設定クラス格納処理
        /// </summary>
        /// <br paramname="stockMngTtlSt">保存するデータクラス</br>
        /// <remarks>
        /// <br>Note       : 画面情報からSCM納期設定クラスにデータを格納します。</br>
        /// <br></br>
        /// </remarks>
        private void ScreenToSCMDeliDateSt(ref SCMDeliDateSt scmDeliDateSt)
        {
            if (scmDeliDateSt == null)
            {
                // 新規の時
                scmDeliDateSt = new SCMDeliDateSt();
            }

            // 企業コード
            scmDeliDateSt.EnterpriseCode = this._enterpriseCode;

            // 拠点単位？
            if (this.SetKind_tComboEditor.Text == SETKIND_SECTION)
            {
                // 拠点コード
                scmDeliDateSt.SectionCode = this.tEdit_SectionCodeAllowZero2.DataText.TrimEnd();

                // 得意先コード
                scmDeliDateSt.CustomerCode = 0;
            }
            else
            {
                // 拠点コード
                scmDeliDateSt.SectionCode = "";

                // 得意先コード
                if (this.tNedit_CustomerCode.DataText != "")
                {
                    scmDeliDateSt.CustomerCode = Int32.Parse(this.tNedit_CustomerCode.DataText.TrimEnd());
                }
                else
                {
                    scmDeliDateSt.CustomerCode = 0;
                }
            }

            int inputCnt = 0;
            for (int no = 0; no < MAX_ANSWER_COUNT; no++)
            {
                // 回答締切時刻と回答納期の設定
                SetAnswerDeadTime(no, ref scmDeliDateSt, ref inputCnt);
            }

            // 2011/01/06 Add >>>
            inputCnt = 0;
            for (int no = 0; no < MAX_ANSWER_COUNT; no++)
            {
                // 回答締切時刻（在庫）と回答納期の設定（在庫）
                SetAnswerDeadTimeStc(no, ref scmDeliDateSt, ref inputCnt);
            }

            // 委託在庫回答納期区分
            // 2011/05/27 >>>
            //scmDeliDateSt.EntStckAnsDeliDtDiv = this.tComboEditor_EntStckAnsDeliDtDiv.SelectedIndex;
            scmDeliDateSt.EntStckAnsDeliDtDiv = Convert.ToInt32(this.tComboEditor_EntStckAnsDeliDtDiv.SelectedItem.DataValue);
            // 2011/05/27 <<<

            // 委託在庫回答納期
            scmDeliDateSt.EntStckAnsDeliDate = this.tEdit_EntStckAnsDeliDate.DataText;
            // 2011/01/06 Add <<<

            // 2011/10/11 Add >>>
            // 優先在庫回答納期区分
            scmDeliDateSt.PriStckAnsDeliDtDiv = Convert.ToInt32(this.tComboEditor_PriStckAnsDeliDtDiv.SelectedItem.DataValue);

            // 優先在庫回答納期
            scmDeliDateSt.PriStckAnsDeliDate = this.tEdit_PriStckAnsDeliDate.DataText;
            // 2011/10/11 Add <<<
            // 2012/08/30 ADD TAKAGAWA 2012/10月配信予定 SCM障害№10345 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            // 回答納期（在庫不足）
            scmDeliDateSt.AnsDelDatShortOfStc = this.tEdit_AnswerDelivDate1StcShortage.DataText;
            // 回答納期（在庫数無し）
            scmDeliDateSt.AnsDelDatWithoutStc = this.tEdit_AnswerDelivDate1StcNotStc.DataText;
            // 委託在庫回答納期（在庫不足）
            scmDeliDateSt.EntStcAnsDelDatShort = this.tEdit_EntStckAnsDeliDateShortage.DataText;
            // 委託在庫回答納期（在庫数無し）
            scmDeliDateSt.EntStcAnsDelDatWiout = this.tEdit_EntStckAnsDeliDateNoStc.DataText;
            // 参照在庫回答納期（在庫不足）
            scmDeliDateSt.PriStcAnsDelDatShort = this.tEdit_PriStckAnsDeliDateShortage.DataText;
            // 参照在庫回答納期（在庫数無し）
            scmDeliDateSt.PriStcAnsDelDatWiout = this.tEdit_PriStckAnsDeliDateNoStc.DataText;
            // 2012/08/30 ADD TAKAGAWA 2012/10月配信予定 SCM障害№10345 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
            // ADD 2015/02/10 豊沢 SCM高速化 回答納期区分対応 ------------------------------------------>>>>>
            // 回答納期区分１（取寄）
            scmDeliDateSt.AnsDelDtDiv1 = Convert.ToInt16(this.tComboEditor_AnsDelivDateDiv1.SelectedItem.DataValue);
            // 回答納期区分２（取寄）
            scmDeliDateSt.AnsDelDtDiv2 = Convert.ToInt16(this.tComboEditor_AnsDelivDateDiv2.SelectedItem.DataValue);
            // 回答納期区分３（取寄）
            scmDeliDateSt.AnsDelDtDiv3 = Convert.ToInt16(this.tComboEditor_AnsDelivDateDiv3.SelectedItem.DataValue);
            // 回答納期区分４（取寄）
            scmDeliDateSt.AnsDelDtDiv4 = Convert.ToInt16(this.tComboEditor_AnsDelivDateDiv4.SelectedItem.DataValue);
            // 回答納期区分５（取寄）
            scmDeliDateSt.AnsDelDtDiv5 = Convert.ToInt16(this.tComboEditor_AnsDelivDateDiv5.SelectedItem.DataValue);
            // 回答納期区分６（取寄）
            scmDeliDateSt.AnsDelDtDiv6 = Convert.ToInt16(this.tComboEditor_AnsDelivDateDiv6.SelectedItem.DataValue);
            // 回答納期区分１（在庫）
            scmDeliDateSt.AnsDelDtDiv1Stc = Convert.ToInt16(this.tComboEditor_AnsDelivDtDiv1Stc.SelectedItem.DataValue);
            // 回答納期区分２（在庫）
            scmDeliDateSt.AnsDelDtDiv2Stc = Convert.ToInt16(this.tComboEditor_AnsDelivDtDiv2Stc.SelectedItem.DataValue);
            // 回答納期区分３（在庫）
            scmDeliDateSt.AnsDelDtDiv3Stc = Convert.ToInt16(this.tComboEditor_AnsDelivDtDiv3Stc.SelectedItem.DataValue);
            // 回答納期区分４（在庫）
            scmDeliDateSt.AnsDelDtDiv4Stc = Convert.ToInt16(this.tComboEditor_AnsDelivDtDiv4Stc.SelectedItem.DataValue);
            // 回答納期区分５（在庫）
            scmDeliDateSt.AnsDelDtDiv5Stc = Convert.ToInt16(this.tComboEditor_AnsDelivDtDiv5Stc.SelectedItem.DataValue);
            // 回答納期区分６（在庫）
            scmDeliDateSt.AnsDelDtDiv6Stc = Convert.ToInt16(this.tComboEditor_AnsDelivDtDiv6Stc.SelectedItem.DataValue);
             // 回答納期区分（在庫不足）
            scmDeliDateSt.AnsDelDtShoStcDiv = Convert.ToInt16(this.tComboEditor_AnsDelDtShoStcDiv.SelectedItem.DataValue);
            // 回答納期区分（在庫数無し）
            scmDeliDateSt.AnsDelDtWioStcDiv = Convert.ToInt16(this.tComboEditor_AnsDelDtWioStcDiv.SelectedItem.DataValue);
            // 委託在庫回答納期区分（在庫）
            scmDeliDateSt.EntAnsDelDtStcDiv = Convert.ToInt16(this.tComboEditor_EntStcAnsDelDtStcDiv.SelectedItem.DataValue);
            // 委託在庫回答納期区分（在庫不足）
            scmDeliDateSt.EntAnsDelDtShoDiv = Convert.ToInt16(this.tComboEditor_EntStcAnsDelDtShoDiv.SelectedItem.DataValue);
            // 委託在庫回答納期区分（在庫数無し）
            scmDeliDateSt.EntAnsDelDtWioDiv = Convert.ToInt16(this.tComboEditor_EntStcAnsDelDtWioDiv.SelectedItem.DataValue);
            // 参照在庫回答納期区分（在庫）
            scmDeliDateSt.PriAnsDelDtStcDiv = Convert.ToInt16(this.tComboEditor_PriStcAnsDelDtStcDiv.SelectedItem.DataValue);
            // 参照在庫回答納期区分（在庫不足）
            scmDeliDateSt.PriAnsDelDtShoDiv = Convert.ToInt16(this.tComboEditor_PriStcAnsDelDtShoDiv.SelectedItem.DataValue);
            // 参照在庫回答納期区分（在庫数無し）
            scmDeliDateSt.PriAnsDelDtWioDiv = Convert.ToInt16(this.tComboEditor_PriStcAnsDelDtWioDiv.SelectedItem.DataValue);
            // ADD 2015/02/10 豊沢 SCM高速化 回答納期区分対応 ------------------------------------------<<<<<

        }

        /// <summary>
        /// 画面情報をSCM納期設定クラス格納処理
        /// </summary>
        /// <br paramname="setNo">設定対象の回答締切時刻と回答納期の番号</br>
        /// <br paramname="stockMngTtlSt">保存するデータクラス</br>
        /// <br paramname="inputCnt">画面読込開始のカウント数</br>
        /// <remarks>
        /// <br>Note       : 画面情報からSCM納期設定クラスにデータを格納します。</br>
        /// <br></br>
        /// </remarks>
        private void SetAnswerDeadTime(int setNo, ref SCMDeliDateSt scmDeliDateSt, ref int inputCnt)
        {
            int answerDeadTime = 0;
            string answerDelivDate = "";

            int i;
            // 2011/01/06 >>>
            //for (i = inputCnt; i < MAX_ANSWER_COUNT; i++)
            for (i = inputCnt; i < MAX_ANSWER_COUNT / 2; i++)
            // 2011/01/06 <<<
            {
                // 画面の締切時刻と回答納期
                switch (i)
                {
                    case 0:
                        {
                            if ((this.tNedit_AnswerDeadTime1_HH.DataText != "") && (this.tNedit_AnswerDeadTime1_MM.DataText != ""))
                            {
                                // 締切時刻が入力されている
                                if (this.tNedit_AnswerDeadTime1_HH.GetInt() == 0)
                                {
                                    // 0時→24時対応
                                    answerDeadTime = (240000) + (this.tNedit_AnswerDeadTime1_MM.GetInt() * 100);
                                }
                                else
                                {
                                    answerDeadTime = (this.tNedit_AnswerDeadTime1_HH.GetInt() * 10000) + (this.tNedit_AnswerDeadTime1_MM.GetInt() * 100);
                                }
                                answerDelivDate = this.tEdit_AnswerDelivDate1.DataText;
                            }
                            break;
                        }
                    case 1:
                        {
                            if ((this.tNedit_AnswerDeadTime2_HH.DataText != "") && (this.tNedit_AnswerDeadTime2_MM.DataText != ""))
                            {
                                // 締切時刻が入力されている
                                if (this.tNedit_AnswerDeadTime2_HH.GetInt() == 0)
                                {
                                    // 0時→24時対応
                                    answerDeadTime = (240000) + (this.tNedit_AnswerDeadTime2_MM.GetInt() * 100);
                                }
                                else
                                {
                                    answerDeadTime = (this.tNedit_AnswerDeadTime2_HH.GetInt() * 10000) + (this.tNedit_AnswerDeadTime2_MM.GetInt() * 100);
                                }
                                answerDelivDate = this.tEdit_AnswerDelivDate2.DataText;
                            }
                            break;
                        }
                    case 2:
                        {
                            if ((this.tNedit_AnswerDeadTime3_HH.DataText != "") && (this.tNedit_AnswerDeadTime3_MM.DataText != ""))
                            {
                                // 締切時刻が入力されている
                                if (this.tNedit_AnswerDeadTime3_HH.GetInt() == 0)
                                {
                                    // 0時→24時対応
                                    answerDeadTime = (240000) + (this.tNedit_AnswerDeadTime3_MM.GetInt() * 100);
                                }
                                else
                                {
                                    answerDeadTime = (this.tNedit_AnswerDeadTime3_HH.GetInt() * 10000) + (this.tNedit_AnswerDeadTime3_MM.GetInt() * 100);
                                }
                                answerDelivDate = this.tEdit_AnswerDelivDate3.DataText;
                            }
                            break;
                        }
                    case 3:
                        {
                            if ((this.tNedit_AnswerDeadTime4_HH.DataText != "") && (this.tNedit_AnswerDeadTime4_MM.DataText != ""))
                            {
                                // 締切時刻が入力されている
                                if (this.tNedit_AnswerDeadTime4_HH.GetInt() == 0)
                                {
                                    // 0時→24時対応
                                    answerDeadTime = (240000) + (this.tNedit_AnswerDeadTime4_MM.GetInt() * 100);
                                }
                                else
                                {
                                    answerDeadTime = (this.tNedit_AnswerDeadTime4_HH.GetInt() * 10000) + (this.tNedit_AnswerDeadTime4_MM.GetInt() * 100);
                                }
                                answerDelivDate = this.tEdit_AnswerDelivDate4.DataText;
                            }
                            break;
                        }
                    case 4:
                        {
                            if ((this.tNedit_AnswerDeadTime5_HH.DataText != "") && (this.tNedit_AnswerDeadTime5_MM.DataText != ""))
                            {
                                // 締切時刻が入力されている
                                if (this.tNedit_AnswerDeadTime5_HH.GetInt() == 0)
                                {
                                    // 0時→24時対応
                                    answerDeadTime = (240000) + (this.tNedit_AnswerDeadTime5_MM.GetInt() * 100);
                                }
                                else
                                {
                                    answerDeadTime = (this.tNedit_AnswerDeadTime5_HH.GetInt() * 10000) + (this.tNedit_AnswerDeadTime5_MM.GetInt() * 100);
                                }
                                answerDelivDate = this.tEdit_AnswerDelivDate5.DataText;
                            }
                            break;
                        }
                    case 5:
                        {
                            if ((this.tNedit_AnswerDeadTime6_HH.DataText != "") && (this.tNedit_AnswerDeadTime6_MM.DataText != ""))
                            {
                                // 締切時刻が入力されている
                                if (this.tNedit_AnswerDeadTime6_HH.GetInt() == 0)
                                {
                                    // 0時→24時対応
                                    answerDeadTime = (240000) + (this.tNedit_AnswerDeadTime6_MM.GetInt() * 100);
                                }
                                else
                                {
                                    answerDeadTime = (this.tNedit_AnswerDeadTime6_HH.GetInt() * 10000) + (this.tNedit_AnswerDeadTime6_MM.GetInt() * 100);
                                }
                                answerDelivDate = this.tEdit_AnswerDelivDate6.DataText;
                            }
                            break;
                        }
                }

                if (answerDeadTime != 0)
                {
                    // 締切時刻を取得済の場合、取得処理終了
                    break;
                }
            }

            // 次回読込開始のカウントを更新
            inputCnt = ++i;

            // データクラスの回答締切時刻と回答納期に設定
            switch (setNo)
            {
                case 0:
                    {
                        scmDeliDateSt.AnswerDeadTime1 = answerDeadTime;         // 回答締切時刻１
                        scmDeliDateSt.AnswerDelivDate1 = answerDelivDate;       // 回答納期１
                        break;
                    }
                case 1:
                    {
                        scmDeliDateSt.AnswerDeadTime2 = answerDeadTime;         // 回答締切時刻２
                        scmDeliDateSt.AnswerDelivDate2 = answerDelivDate;       // 回答納期２
                        break;
                    }
                case 2:
                    {
                        scmDeliDateSt.AnswerDeadTime3 = answerDeadTime;         // 回答締切時刻３
                        scmDeliDateSt.AnswerDelivDate3 = answerDelivDate;       // 回答納期３
                        break;
                    }
                case 3:
                    {
                        scmDeliDateSt.AnswerDeadTime4 = answerDeadTime;         // 回答締切時刻４
                        scmDeliDateSt.AnswerDelivDate4 = answerDelivDate;       // 回答納期４
                        break;
                    }
                case 4:
                    {
                        scmDeliDateSt.AnswerDeadTime5 = answerDeadTime;         // 回答締切時刻５
                        scmDeliDateSt.AnswerDelivDate5 = answerDelivDate;       // 回答納期５
                        break;
                    }
                case 5:
                    {
                        scmDeliDateSt.AnswerDeadTime6 = answerDeadTime;         // 回答締切時刻６
                        scmDeliDateSt.AnswerDelivDate6 = answerDelivDate;       // 回答納期６
                        break;
                    }
            }
        }

        // 2011/01/06 Add >>>
        /// <summary>
        /// 画面情報をSCM納期設定クラス格納処理（在庫分）
        /// </summary>
        /// <br paramname="setNo">設定対象の回答締切時刻と回答納期の番号</br>
        /// <br paramname="stockMngTtlSt">保存するデータクラス</br>
        /// <br paramname="inputCnt">画面読込開始のカウント数</br>
        /// <remarks>
        /// <br>Note       : 画面情報からSCM納期設定クラスにデータを格納します。</br>
        /// <br></br>
        /// </remarks>
        private void SetAnswerDeadTimeStc(int setNo, ref SCMDeliDateSt scmDeliDateSt, ref int inputCnt)
        {
            int answerDeadTime = 0;
            string answerDelivDate = "";

            int i;
            for (i = inputCnt; i < MAX_ANSWER_COUNT / 2; i++)
            {
                // 画面の締切時刻と回答納期
                switch (i)
                {
                    case 0:
                        {
                            if ((this.tNedit_AnswerDeadTime1Stc_HH.DataText != "") && (this.tNedit_AnswerDeadTime1Stc_MM.DataText != ""))
                            {
                                // 締切時刻が入力されている
                                if (this.tNedit_AnswerDeadTime1Stc_HH.GetInt() == 0)
                                {
                                    // 0時→24時対応
                                    answerDeadTime = (240000) + (this.tNedit_AnswerDeadTime1Stc_MM.GetInt() * 100);
                                }
                                else
                                {
                                    answerDeadTime = (this.tNedit_AnswerDeadTime1Stc_HH.GetInt() * 10000) + (this.tNedit_AnswerDeadTime1Stc_MM.GetInt() * 100);
                                }
                                answerDelivDate = this.tEdit_AnswerDelivDate1Stc.DataText;
                            }
                            break;
                        }
                    case 1:
                        {
                            if ((this.tNedit_AnswerDeadTime2Stc_HH.DataText != "") && (this.tNedit_AnswerDeadTime2Stc_MM.DataText != ""))
                            {
                                // 締切時刻が入力されている
                                if (this.tNedit_AnswerDeadTime2Stc_HH.GetInt() == 0)
                                {
                                    // 0時→24時対応
                                    answerDeadTime = (240000) + (this.tNedit_AnswerDeadTime2Stc_MM.GetInt() * 100);
                                }
                                else
                                {
                                    answerDeadTime = (this.tNedit_AnswerDeadTime2Stc_HH.GetInt() * 10000) + (this.tNedit_AnswerDeadTime2Stc_MM.GetInt() * 100);
                                }
                                answerDelivDate = this.tEdit_AnswerDelivDate2Stc.DataText;
                            }
                            break;
                        }
                    case 2:
                        {
                            if ((this.tNedit_AnswerDeadTime3Stc_HH.DataText != "") && (this.tNedit_AnswerDeadTime3Stc_MM.DataText != ""))
                            {
                                // 締切時刻が入力されている
                                if (this.tNedit_AnswerDeadTime3Stc_HH.GetInt() == 0)
                                {
                                    // 0時→24時対応
                                    answerDeadTime = (240000) + (this.tNedit_AnswerDeadTime3Stc_MM.GetInt() * 100);
                                }
                                else
                                {
                                    answerDeadTime = (this.tNedit_AnswerDeadTime3Stc_HH.GetInt() * 10000) + (this.tNedit_AnswerDeadTime3Stc_MM.GetInt() * 100);
                                }
                                answerDelivDate = this.tEdit_AnswerDelivDate3Stc.DataText;
                            }
                            break;
                        }
                    case 3:
                        {
                            if ((this.tNedit_AnswerDeadTime4Stc_HH.DataText != "") && (this.tNedit_AnswerDeadTime4Stc_MM.DataText != ""))
                            {
                                // 締切時刻が入力されている
                                if (this.tNedit_AnswerDeadTime4Stc_HH.GetInt() == 0)
                                {
                                    // 0時→24時対応
                                    answerDeadTime = (240000) + (this.tNedit_AnswerDeadTime4Stc_MM.GetInt() * 100);
                                }
                                else
                                {
                                    answerDeadTime = (this.tNedit_AnswerDeadTime4Stc_HH.GetInt() * 10000) + (this.tNedit_AnswerDeadTime4Stc_MM.GetInt() * 100);
                                }
                                answerDelivDate = this.tEdit_AnswerDelivDate4Stc.DataText;
                            }
                            break;
                        }
                    case 4:
                        {
                            if ((this.tNedit_AnswerDeadTime5Stc_HH.DataText != "") && (this.tNedit_AnswerDeadTime5Stc_MM.DataText != ""))
                            {
                                // 締切時刻が入力されている
                                if (this.tNedit_AnswerDeadTime5Stc_HH.GetInt() == 0)
                                {
                                    // 0時→24時対応
                                    answerDeadTime = (240000) + (this.tNedit_AnswerDeadTime5Stc_MM.GetInt() * 100);
                                }
                                else
                                {
                                    answerDeadTime = (this.tNedit_AnswerDeadTime5Stc_HH.GetInt() * 10000) + (this.tNedit_AnswerDeadTime5Stc_MM.GetInt() * 100);
                                }
                                answerDelivDate = this.tEdit_AnswerDelivDate5Stc.DataText;
                            }
                            break;
                        }
                    case 5:
                        {
                            if ((this.tNedit_AnswerDeadTime6Stc_HH.DataText != "") && (this.tNedit_AnswerDeadTime6Stc_MM.DataText != ""))
                            {
                                // 締切時刻が入力されている
                                if (this.tNedit_AnswerDeadTime6Stc_HH.GetInt() == 0)
                                {
                                    // 0時→24時対応
                                    answerDeadTime = (240000) + (this.tNedit_AnswerDeadTime6Stc_MM.GetInt() * 100);
                                }
                                else
                                {
                                    answerDeadTime = (this.tNedit_AnswerDeadTime6Stc_HH.GetInt() * 10000) + (this.tNedit_AnswerDeadTime6Stc_MM.GetInt() * 100);
                                }
                                answerDelivDate = this.tEdit_AnswerDelivDate6Stc.DataText;
                            }
                            break;
                        }
                }

                if (answerDeadTime != 0)
                {
                    // 締切時刻を取得済の場合、取得処理終了
                    break;
                }
            }

            // 次回読込開始のカウントを更新
            inputCnt = ++i;

            // データクラスの回答締切時刻と回答納期に設定
            switch (setNo)
            {
                case 0:
                    {
                        scmDeliDateSt.AnswerDeadTime1Stc = answerDeadTime;         // 回答締切時刻１
                        scmDeliDateSt.AnswerDelivDate1Stc = answerDelivDate;       // 回答納期１
                        break;
                    }
                case 1:
                    {
                        scmDeliDateSt.AnswerDeadTime2Stc = answerDeadTime;         // 回答締切時刻２
                        scmDeliDateSt.AnswerDelivDate2Stc = answerDelivDate;       // 回答納期２
                        break;
                    }
                case 2:
                    {
                        scmDeliDateSt.AnswerDeadTime3Stc = answerDeadTime;         // 回答締切時刻３
                        scmDeliDateSt.AnswerDelivDate3Stc = answerDelivDate;       // 回答納期３
                        break;
                    }
                case 3:
                    {
                        scmDeliDateSt.AnswerDeadTime4Stc = answerDeadTime;         // 回答締切時刻４
                        scmDeliDateSt.AnswerDelivDate4Stc = answerDelivDate;       // 回答納期４
                        break;
                    }
                case 4:
                    {
                        scmDeliDateSt.AnswerDeadTime5Stc = answerDeadTime;         // 回答締切時刻５
                        scmDeliDateSt.AnswerDelivDate5Stc = answerDelivDate;       // 回答納期５
                        break;
                    }
                case 5:
                    {
                        scmDeliDateSt.AnswerDeadTime6Stc = answerDeadTime;         // 回答締切時刻６
                        scmDeliDateSt.AnswerDelivDate6Stc = answerDelivDate;       // 回答納期６
                        break;
                    }
            }
        }
        // 2011/01/06 Add <<<
        
        /// <summary>
        /// 画面クリア処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面をクリアします。</br>
        /// <br></br>
        /// </remarks>
        private void ScreenClear()
        {
            this.SetKind_tComboEditor.SelectedIndex = 0;      // 設定種別
            this.tEdit_SectionCodeAllowZero2.Clear();          // 拠点コード
            this.SectionNm_tEdit.Clear();                     // 拠点ガイド名称
            this.tNedit_CustomerCode.Clear();                 // 得意先コード
            this.CustomerName_tEdit.Clear();                  // 得意先名称

            // 回答締切時刻１
            this.tNedit_AnswerDeadTime1_HH.Clear();
            this.tNedit_AnswerDeadTime1_MM.Clear();
            // 回答納期１
            this.tEdit_AnswerDelivDate1.Clear();
            // 回答締切時刻２
            this.tNedit_AnswerDeadTime2_HH.Clear();
            this.tNedit_AnswerDeadTime2_MM.Clear();
            // 回答納期２
            this.tEdit_AnswerDelivDate2.Clear();
            // 回答締切時刻３
            this.tNedit_AnswerDeadTime3_HH.Clear();
            this.tNedit_AnswerDeadTime3_MM.Clear();
            // 回答納期３
            this.tEdit_AnswerDelivDate3.Clear();
            // 回答締切時刻４
            this.tNedit_AnswerDeadTime4_HH.Clear();
            this.tNedit_AnswerDeadTime4_MM.Clear();
            // 回答納期４
            this.tEdit_AnswerDelivDate4.Clear();
            // 回答締切時刻５
            this.tNedit_AnswerDeadTime5_HH.Clear();
            this.tNedit_AnswerDeadTime5_MM.Clear();
            // 回答納期５
            this.tEdit_AnswerDelivDate5.Clear();
            // 回答締切時刻６
            this.tNedit_AnswerDeadTime6_HH.Clear();
            this.tNedit_AnswerDeadTime6_MM.Clear();
            // 回答納期６
            this.tEdit_AnswerDelivDate6.Clear();

            // 2011/01/06 Add >>>
            // 回答締切時刻１（在庫）
            this.tNedit_AnswerDeadTime1Stc_HH.Clear();
            this.tNedit_AnswerDeadTime1Stc_MM.Clear();
            // 回答納期１（在庫）
            this.tEdit_AnswerDelivDate1Stc.Clear();
            // 回答締切時刻２（在庫）
            this.tNedit_AnswerDeadTime2Stc_HH.Clear();
            this.tNedit_AnswerDeadTime2Stc_MM.Clear();
            // 回答納期２（在庫）
            this.tEdit_AnswerDelivDate2Stc.Clear();
            // 回答締切時刻３（在庫）
            this.tNedit_AnswerDeadTime3Stc_HH.Clear();
            this.tNedit_AnswerDeadTime3Stc_MM.Clear();
            // 回答納期３（在庫）
            this.tEdit_AnswerDelivDate3Stc.Clear();
            // 回答締切時刻４（在庫）
            this.tNedit_AnswerDeadTime4Stc_HH.Clear();
            this.tNedit_AnswerDeadTime4Stc_MM.Clear();
            // 回答納期４（在庫）
            this.tEdit_AnswerDelivDate4Stc.Clear();
            // 回答締切時刻５（在庫）
            this.tNedit_AnswerDeadTime5Stc_HH.Clear();
            this.tNedit_AnswerDeadTime5Stc_MM.Clear();
            // 回答納期５（在庫）
            this.tEdit_AnswerDelivDate5Stc.Clear();
            // 回答締切時刻６（在庫）
            this.tNedit_AnswerDeadTime6Stc_HH.Clear();
            this.tNedit_AnswerDeadTime6Stc_MM.Clear();
            // 回答納期６（在庫）
            this.tEdit_AnswerDelivDate6Stc.Clear();

            // 委託在庫回答納期区分
            this.tComboEditor_EntStckAnsDeliDtDiv.SelectedIndex = 0;

            // 委託在庫回答納期
            this.tEdit_EntStckAnsDeliDate.Clear();

            // 2011/10/11 Add >>>
            // 優先在庫回答納期区分
            this.tComboEditor_PriStckAnsDeliDtDiv.SelectedIndex = 0;

            // 優先在庫回答納期
            this.tEdit_PriStckAnsDeliDate.Clear();
            // 2011/10/11 Add <<<

            // 2012/08/30 ADD TAKAGAWA 2012/10月配信予定 SCM障害№10345 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            // 回答納期（在庫不足）
            this.tEdit_AnswerDelivDate1StcShortage.Clear();
            // 回答納期（在庫数無し）
            this.tEdit_AnswerDelivDate1StcNotStc.Clear();
            // 委託在庫回答納期（在庫不足）
            this.tEdit_EntStckAnsDeliDateShortage.Clear();
            // 委託在庫回答納期（在庫数無し）
            this.tEdit_EntStckAnsDeliDateNoStc.Clear();
            // 参照在庫回答納期（在庫不足）
            this.tEdit_PriStckAnsDeliDateShortage.Clear();
            // 参照在庫回答納期（在庫数無し）
            this.tEdit_PriStckAnsDeliDateNoStc.Clear();
            // 2012/08/30 ADD TAKAGAWA 2012/10月配信予定 SCM障害№10345 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

            // ADD 2015/02/10 豊沢 SCM高速化 回答納期区分対応 ------------------------------------------>>>>>
            // 選択位置を初期(未設定に変更)
            this.tComboEditor_AnsDelivDateDiv1.SelectedIndex = 0; // 回答納期区分１（取寄）
            this.tComboEditor_AnsDelivDateDiv2.SelectedIndex = 0; // 回答納期区分２（取寄）
            this.tComboEditor_AnsDelivDateDiv3.SelectedIndex = 0; // 回答納期区分３（取寄）
            this.tComboEditor_AnsDelivDateDiv4.SelectedIndex = 0; // 回答納期区分４（取寄）
            this.tComboEditor_AnsDelivDateDiv5.SelectedIndex = 0; // 回答納期区分５（取寄）
            this.tComboEditor_AnsDelivDateDiv6.SelectedIndex = 0; // 回答納期区分６（取寄）
            this.tComboEditor_AnsDelivDtDiv1Stc.SelectedIndex = 0; // 回答納期区分１（在庫）
            this.tComboEditor_AnsDelivDtDiv2Stc.SelectedIndex = 0; // 回答納期区分２（在庫）
            this.tComboEditor_AnsDelivDtDiv3Stc.SelectedIndex = 0; // 回答納期区分３（在庫）
            this.tComboEditor_AnsDelivDtDiv4Stc.SelectedIndex = 0; // 回答納期区分４（在庫）
            this.tComboEditor_AnsDelivDtDiv5Stc.SelectedIndex = 0; // 回答納期区分５（在庫）
            this.tComboEditor_AnsDelivDtDiv6Stc.SelectedIndex = 0; // 回答納期区分６（在庫）
            this.tComboEditor_AnsDelDtShoStcDiv.SelectedIndex = 0; // 回答納期区分（在庫不足）
            this.tComboEditor_AnsDelDtWioStcDiv.SelectedIndex = 0; // 回答納期区分（在庫数無し）
            this.tComboEditor_EntStcAnsDelDtStcDiv.SelectedIndex = 0; // 委託在庫回答納期区分（在庫）
            this.tComboEditor_EntStcAnsDelDtShoDiv.SelectedIndex = 0; // 委託在庫回答納期区分（在庫不足）
            this.tComboEditor_EntStcAnsDelDtWioDiv.SelectedIndex = 0; // 委託在庫回答納期区分（在庫数無し）
            this.tComboEditor_PriStcAnsDelDtStcDiv.SelectedIndex = 0; // 参照在庫回答納期区分（在庫）
            this.tComboEditor_PriStcAnsDelDtShoDiv.SelectedIndex = 0; // 参照在庫回答納期区分（在庫不足）
            this.tComboEditor_PriStcAnsDelDtWioDiv.SelectedIndex = 0; // 参照在庫回答納期区分（在庫数無し）

            // 
            this.tComboEditor_EntStcAnsDelDtStcDiv.SelectedIndex = 0; // 委託在庫回答納期区分（在庫）
            this.tComboEditor_EntStcAnsDelDtShoDiv.SelectedIndex = 0; // 委託在庫回答納期区分（在庫不足）
            this.tComboEditor_EntStcAnsDelDtWioDiv.SelectedIndex = 0; // 委託在庫回答納期区分（在庫数無し）
            this.tComboEditor_PriStcAnsDelDtStcDiv.SelectedIndex = 0; // 参照在庫回答納期区分（在庫）
            this.tComboEditor_PriStcAnsDelDtShoDiv.SelectedIndex = 0; // 参照在庫回答納期区分（在庫不足）
            this.tComboEditor_PriStcAnsDelDtWioDiv.SelectedIndex = 0; // 参照在庫回答納期区分（在庫数無し）
            // ADD 2015/02/10 豊沢 SCM高速化 回答納期区分対応 ------------------------------------------<<<<<

            // タブを取寄へ切り替える
            this.ultraTabControl1.ActiveTab = this.ultraTabControl1.Tabs["Order"];
            this.ultraTabControl1.SelectedTab = this.ultraTabControl1.ActiveTab;
            // 2011/01/06 Add <<<
        }

        /// <summary>
        /// SCM納期設定保存処理
        /// </summary>
        /// <returns>結果</returns>
        /// <remarks>
        /// <br>Note       : SCM納期設定の保存を行います。</br>
        /// <br></br>
        /// </remarks>
        private bool SaveProc()
        {
            bool result = false;

            // ----- ADD 2011/09/07 ---------->>>>>
            // 拠点
            if (this.tEdit_SectionCodeAllowZero2.Focused)
            {
                ChangeFocusEventArgs eArgs = new ChangeFocusEventArgs(false, false, false, Keys.Enter, this.tEdit_SectionCodeAllowZero2, this.tEdit_SectionCodeAllowZero2);
                if (!string.IsNullOrEmpty(this.tEdit_SectionCodeAllowZero2.Text))
                {
                    this.tEdit_SectionCodeAllowZero2.Text = this.tEdit_SectionCodeAllowZero2.Text.PadLeft(2, '0');
                }
                tRetKeyControl1_ChangeFocus(null, eArgs);
                if (isError == true)
                {
                    result = false;
                    return result;
                }
            }
            // ----- ADD 2011/09/07 ----------<<<<<

            // 入力チェック
            Control control = null;
            string message = null;
            if (!ScreenDataCheck(ref control, ref message))
            {
                // 入力チェック
                TMsgDisp.Show(
                    this, 								// 親ウィンドウフォーム
                    emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
                    PROGRAM_ID, 						// アセンブリＩＤまたはクラスＩＤ
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

            SCMDeliDateSt scmDeliDateSt = null;
            if (this._dataIndex >= 0)
            {
                Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this._dataIndex][GUID_TITLE];
                scmDeliDateSt = ((SCMDeliDateSt)this._scmDeliDateStTable[guid]).Clone();
            }
            ScreenToSCMDeliDateSt(ref scmDeliDateSt);

            // 拠点コードまたは得意先コードが存在していない場合、登録しない。
            if (!ExistsCodeBySetKind(scmDeliDateSt))
            {
                TMsgDisp.Show(
                    this, 								                    // 親ウィンドウフォーム
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,                     // エラーレベル
                    AssemblyUtil.GetName(Assembly.GetExecutingAssembly()),  // アセンブリＩＤまたはクラスＩＤ
                    this.Text, 		                                        // プログラム名称
                    MethodBase.GetCurrentMethod().Name, 					// 処理名称
                    TMsgDisp.OPE_UPDATE, 				                    // オペレーション
                    "拠点コードまたは得意先コードが存在しません。",         // LITERAL:表示するメッセージ
                    (int)ConstantManagement.MethodResult.ctFNC_NORMAL, 		// ステータス値
                    this,			                                        // エラーが発生したオブジェクト
                    MessageBoxButtons.OK, 				                    // 表示するボタン
                    MessageBoxDefaultButton.Button1                         // 初期表示ボタン
                );
                // --- ADD 2011/09/07 -------------------------------->>>>>
                this.tEdit_SectionCodeAllowZero2.Clear();
                this.SectionNm_tEdit.Clear();
                // --- ADD 2011/09/07 --------------------------------<<<<<
                return false;
            }
            
            int status = this._scmDeliDateStAcs.Write(ref scmDeliDateSt);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // VIEWのデータセットを更新
                        SCMDeliDateStToDataSet(scmDeliDateSt.Clone(), this._dataIndex);
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE:
                    {
                        // コード重複
                        TMsgDisp.Show(
                            this, 									// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_INFO, 			// エラーレベル
                            PROGRAM_ID, 							// アセンブリＩＤまたはクラスＩＤ
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
                            PROGRAM_ID, 						// アセンブリＩＤまたはクラスＩＤ
                            this.Text, 		                    // プログラム名称
                            "SaveProc", 						// 処理名称
                            TMsgDisp.OPE_UPDATE, 				// オペレーション
                            "登録に失敗しました。", 			// 表示するメッセージ
                            status, 							// ステータス値
                            this._scmDeliDateStAcs,			    // エラーが発生したオブジェクト
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
        /// 設定種別に応じて、拠点コードまたは得意先コードが存在するか判定します。
        /// </summary>
        /// <param name="scmDeliDateSt">SCM納期設定</param>
        /// <returns><c>true</c> :存在する。<br/><c>false</c>:存在しない。</returns>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br></br>
        /// </remarks>
        private bool ExistsCodeBySetKind(SCMDeliDateSt scmDeliDateSt)
        {
            // 拠点単位
            if (((int)this.SetKind_tComboEditor.SelectedItem.DataValue).Equals(SETKIND_SECTION_VALUE))
            {
                if (scmDeliDateSt.SectionCode.TrimEnd().Length == 1) return false; // ADD 2011/09/07
                // 全社共通は拠点マスタに登録されていないため、チェックの対象外
                if (SectionUtil.IsAllSection(scmDeliDateSt.SectionCode)) return true;

                
                bool existsSectionCode = SectionUtil.ExistsCode(scmDeliDateSt.SectionCode);
                if (!existsSectionCode) this.tEdit_SectionCodeAllowZero2.Focus();
                return existsSectionCode;
            }

            // 得意先単位
            if (((int)this.SetKind_tComboEditor.SelectedItem.DataValue).Equals(SETKIND_CUSTOMER_VALUE))
            {
                try
                {
                    string name = GetCustomerName(scmDeliDateSt.CustomerCode, true);
                    return true;
                }
                catch (ArgumentException)
                {
                    this.tNedit_CustomerCode.Focus();
                    return false;
                }
            }

            return false;
        }

        /// <summary>
        /// 画面入力情報不正チェック処理
        /// </summary>
        /// <param name="control">不正対象コントロール</param>
        /// <param name="message">メッセージ</param>
        /// <returns>チェック結果(true:OK／false:NG)</returns>
        /// <remarks>
        /// <br>Note       : 画面入力の不正チェックを行います。</br>
        /// <br></br>
        /// </remarks>
        private bool ScreenDataCheck(ref Control control, ref string message)
        {
            if (this.SetKind_tComboEditor.Text == SETKIND_SECTION)
            {
                // 拠点コード
                if (this.tEdit_SectionCodeAllowZero2.DataText == "")
                {
                    message = this.SectionCode_Title_Label.Text + "を設定して下さい。";
                    control = this.tEdit_SectionCodeAllowZero2;
                    return false;
                }
            }
            else
            {
                // 得意先コード
                if (this.tNedit_CustomerCode.DataText == "")
                {
                    message = this.Customer_Label.Text + "を設定して下さい。";
                    control = this.tNedit_CustomerCode;
                    return false;
                }
            }
            
            int noInput = 0;
            List<int> answerDeadTimeList = new List<int>();
            // 回答締切時刻１
            // 回答納期１
            if (!AnswerDeadTimeCheck(tNedit_AnswerDeadTime1_HH, tNedit_AnswerDeadTime1_MM, tEdit_AnswerDelivDate1, ref noInput, ref control, ref message, ref answerDeadTimeList))
            {
                // 2011/01/06 Add >>>
                this.ultraTabControl1.ActiveTab = this.ultraTabControl1.Tabs["Order"];
                this.ultraTabControl1.SelectedTab = this.ultraTabControl1.ActiveTab;
                // 2011/01/06 Add <<<
                return false;
            }
            // 回答締切時刻２
            // 回答納期２
            else if (!AnswerDeadTimeCheck(tNedit_AnswerDeadTime2_HH, tNedit_AnswerDeadTime2_MM, tEdit_AnswerDelivDate2, ref noInput, ref control, ref message, ref answerDeadTimeList))
            {
                // 2011/01/06 Add >>>
                this.ultraTabControl1.ActiveTab = this.ultraTabControl1.Tabs["Order"];
                this.ultraTabControl1.SelectedTab = this.ultraTabControl1.ActiveTab;
                // 2011/01/06 Add <<<
                return false;
            }
            // 回答締切時刻３
            // 回答納期３
            else if (!AnswerDeadTimeCheck(tNedit_AnswerDeadTime3_HH, tNedit_AnswerDeadTime3_MM, tEdit_AnswerDelivDate3, ref noInput, ref control, ref message, ref answerDeadTimeList))
            {
                // 2011/01/06 Add >>>
                this.ultraTabControl1.ActiveTab = this.ultraTabControl1.Tabs["Order"];
                this.ultraTabControl1.SelectedTab = this.ultraTabControl1.ActiveTab;
                // 2011/01/06 Add <<<
                return false;
            }
            // 回答締切時刻４
            // 回答納期４
            else if (!AnswerDeadTimeCheck(tNedit_AnswerDeadTime4_HH, tNedit_AnswerDeadTime4_MM, tEdit_AnswerDelivDate4, ref noInput, ref control, ref message, ref answerDeadTimeList))
            {
                // 2011/01/06 Add >>>
                this.ultraTabControl1.ActiveTab = this.ultraTabControl1.Tabs["Order"];
                this.ultraTabControl1.SelectedTab = this.ultraTabControl1.ActiveTab;
                // 2011/01/06 Add <<<
                return false;
            }
            // 回答締切時刻５
            // 回答納期５
            else if (!AnswerDeadTimeCheck(tNedit_AnswerDeadTime5_HH, tNedit_AnswerDeadTime5_MM, tEdit_AnswerDelivDate5, ref noInput, ref control, ref message, ref answerDeadTimeList))
            {
                // 2011/01/06 Add >>>
                this.ultraTabControl1.ActiveTab = this.ultraTabControl1.Tabs["Order"];
                this.ultraTabControl1.SelectedTab = this.ultraTabControl1.ActiveTab;
                // 2011/01/06 Add <<<
                return false;
            }
            // 回答締切時刻６
            // 回答納期６
            else if (!AnswerDeadTimeCheck(tNedit_AnswerDeadTime6_HH, tNedit_AnswerDeadTime6_MM, tEdit_AnswerDelivDate6, ref noInput, ref control, ref message, ref answerDeadTimeList))
            {
                // 2011/01/06 Add >>>
                this.ultraTabControl1.ActiveTab = this.ultraTabControl1.Tabs["Order"];
                this.ultraTabControl1.SelectedTab = this.ultraTabControl1.ActiveTab;
                // 2011/01/06 Add <<<
                return false;
            }

            // 2011/01/06 >>>
            //if (noInput == MAX_ANSWER_COUNT)
            //{
            //    message = "締切時刻と回答納期を設定して下さい。";
            //    control = this.tNedit_AnswerDeadTime1_HH;
            //    return false;
            //}
            if (noInput == MAX_ANSWER_COUNT / 2)
            {
                // 2011/01/06 Add >>>
                this.ultraTabControl1.ActiveTab = this.ultraTabControl1.Tabs["Order"];
                this.ultraTabControl1.SelectedTab = this.ultraTabControl1.ActiveTab;
                // 2011/01/06 Add <<<
                message = "締切時刻と回答納期を設定して下さい。（取寄品）";
                control = this.tNedit_AnswerDeadTime1_HH;
                return false;
            }
            // 2011/01/06 <<<

            // 2011/01/06 Add >>>
            noInput = 0;
            answerDeadTimeList = new List<int>();
            // 回答締切時刻１（在庫）
            // 回答納期１（在庫）
            if (!AnswerDeadTimeCheck(tNedit_AnswerDeadTime1Stc_HH, tNedit_AnswerDeadTime1Stc_MM, tEdit_AnswerDelivDate1Stc, ref noInput, ref control, ref message, ref answerDeadTimeList))
            {
                this.ultraTabControl1.ActiveTab = this.ultraTabControl1.Tabs["Stock"];
                this.ultraTabControl1.SelectedTab = this.ultraTabControl1.ActiveTab;
                return false;
            }
            // 回答締切時刻２（在庫）
            // 回答納期２（在庫）
            else if (!AnswerDeadTimeCheck(tNedit_AnswerDeadTime2Stc_HH, tNedit_AnswerDeadTime2Stc_MM, tEdit_AnswerDelivDate2Stc, ref noInput, ref control, ref message, ref answerDeadTimeList))
            {
                this.ultraTabControl1.ActiveTab = this.ultraTabControl1.Tabs["Stock"];
                this.ultraTabControl1.SelectedTab = this.ultraTabControl1.ActiveTab;
                return false;
            }
            // 回答締切時刻３（在庫）
            // 回答納期３（在庫）
            else if (!AnswerDeadTimeCheck(tNedit_AnswerDeadTime3Stc_HH, tNedit_AnswerDeadTime3Stc_MM, tEdit_AnswerDelivDate3Stc, ref noInput, ref control, ref message, ref answerDeadTimeList))
            {
                this.ultraTabControl1.ActiveTab = this.ultraTabControl1.Tabs["Stock"];
                this.ultraTabControl1.SelectedTab = this.ultraTabControl1.ActiveTab;
                return false;
            }
            // 回答締切時刻４（在庫）
            // 回答納期４（在庫）
            else if (!AnswerDeadTimeCheck(tNedit_AnswerDeadTime4Stc_HH, tNedit_AnswerDeadTime4Stc_MM, tEdit_AnswerDelivDate4Stc, ref noInput, ref control, ref message, ref answerDeadTimeList))
            {
                this.ultraTabControl1.ActiveTab = this.ultraTabControl1.Tabs["Stock"];
                this.ultraTabControl1.SelectedTab = this.ultraTabControl1.ActiveTab;
                return false;
            }
            // 回答締切時刻５（在庫）
            // 回答納期５（在庫）
            else if (!AnswerDeadTimeCheck(tNedit_AnswerDeadTime5Stc_HH, tNedit_AnswerDeadTime5Stc_MM, tEdit_AnswerDelivDate5Stc, ref noInput, ref control, ref message, ref answerDeadTimeList))
            {
                this.ultraTabControl1.ActiveTab = this.ultraTabControl1.Tabs["Stock"];
                this.ultraTabControl1.SelectedTab = this.ultraTabControl1.ActiveTab;
                return false;
            }
            // 回答締切時刻６（在庫）
            // 回答納期６（在庫）
            else if (!AnswerDeadTimeCheck(tNedit_AnswerDeadTime6Stc_HH, tNedit_AnswerDeadTime6Stc_MM, tEdit_AnswerDelivDate6Stc, ref noInput, ref control, ref message, ref answerDeadTimeList))
            {
                this.ultraTabControl1.ActiveTab = this.ultraTabControl1.Tabs["Stock"];
                this.ultraTabControl1.SelectedTab = this.ultraTabControl1.ActiveTab;
                return false;
            }

            if (noInput == MAX_ANSWER_COUNT / 2)
            {
                this.ultraTabControl1.ActiveTab = this.ultraTabControl1.Tabs["Stock"];
                this.ultraTabControl1.SelectedTab = this.ultraTabControl1.ActiveTab;
                message = "締切時刻と回答納期を設定して下さい。（在庫品）";
                control = this.tNedit_AnswerDeadTime1Stc_HH;
                return false;
            }

            // 2011/05/27 >>>
            //if (this.tComboEditor_EntStckAnsDeliDtDiv.SelectedIndex == 2)
            if (Convert.ToInt32(this.tComboEditor_EntStckAnsDeliDtDiv.SelectedItem.DataValue) == 2)
            // 2011/05/27 <<<
            {
                if (this.tEdit_EntStckAnsDeliDate.DataText.TrimEnd() == "")
                {
                    this.ultraTabControl1.ActiveTab = this.ultraTabControl1.Tabs["Stock"];
                    this.ultraTabControl1.SelectedTab = this.ultraTabControl1.ActiveTab;
                    message = "委託在庫回答納期を設定して下さい。";
                    control = this.tEdit_EntStckAnsDeliDate;
                    return false;
                }
            }
            // 2011/01/06 Add <<<

            // 2011/10/11 Add >>>
            //優先在庫回答納期
            if (Convert.ToInt32(this.tComboEditor_PriStckAnsDeliDtDiv.SelectedItem.DataValue) == 1)
            {
                if (this.tEdit_PriStckAnsDeliDate.DataText.TrimEnd() == "")
                {
                    this.ultraTabControl1.ActiveTab = this.ultraTabControl1.Tabs["Stock"];
                    this.ultraTabControl1.SelectedTab = this.ultraTabControl1.ActiveTab;
                    message = "優先在庫回答納期を設定して下さい。";
                    control = this.tEdit_PriStckAnsDeliDate;
                    return false;
                }
            // 2011/10/11 Add <<<
            }

            return true;
        }

        /// <summary>
        /// 締切時刻と回答納期の入力チェック処理
        /// </summary>
        /// <param name="tNedit_HH">締切時刻(時)</param>
        /// <param name="tNedit_MM">締切時刻(分)</param>
        /// <param name="tEdit_Deliv">回答納期</param>
        /// <param name="noInput">未入力数</param>
        /// <param name="control">不正対象コントロール</param>
        /// <param name="message">メッセージ</param>
        /// <param name="answerDeadTimeList">入力締切時刻リスト</param>
        /// <returns>チェック結果(true:OK／false:NG)</returns>
        /// <remarks>
        /// <br>Note       : 締切時刻と回答納期の入力チェックを行います。</br>
        /// <br></br>
        /// </remarks>
        private bool AnswerDeadTimeCheck(TNedit tNedit_HH, TNedit tNedit_MM, TEdit tEdit_Deliv, ref int noInput, ref Control control, ref string message, ref List<int> answerDeadTimeList)
        {
            int hh = tNedit_HH.GetInt();
            int mm = tNedit_MM.GetInt();

            if ((tNedit_HH.DataText == "") && (tNedit_MM.DataText == "") && (tEdit_Deliv.DataText.TrimEnd() == ""))
            {
                // 未入力時
                noInput++;
                return true;
            }
            else
            {
                // いずれかは、入力されている
                if (tNedit_HH.DataText == "")
                {
                    message = "締切時刻を入力して下さい。";
                    control = tNedit_HH;
                    return false;
                }
                else if (hh >= 24)
                {
                    message = "締切時刻が不正です。";
                    control = tNedit_HH;
                    return false;
                }
                else if (tNedit_MM.DataText == "")
                {
                    message = "締切時刻を入力して下さい。";
                    control = tNedit_MM;
                    return false;
                }
                else if (mm > 59)
                {
                    message = "締切時刻が不正です。";
                    control = tNedit_MM;
                    return false;
                }
                else if (tEdit_Deliv.DataText.TrimEnd() == "")
                {
                    message = "回答納期を入力して下さい。";
                    control = tEdit_Deliv;
                    return false;
                }
                else
                {
                    int answerDeadTime = (hh * 10000) + (mm * 100);
                    // 回答締切時刻の重複チェック
                    if (answerDeadTimeList.Contains(answerDeadTime))
                    {
                        message = "締切時刻が重複しています。";
                        control = tNedit_HH;
                        return false;
                    }
                    else
                    {
                        answerDeadTimeList.Add(answerDeadTime);
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// SCM納期設定オブジェクト論理削除復活処理
        /// </summary>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : SCM納期設定オブジェクトの論理削除復活を行います</br>
        /// <br></br>
        /// </remarks>
        private int Revival()
        {
            int status = 0;

            if ((this._dataIndex < 0) ||
                (this._dataIndex >= this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Count))
            {
                return -1;
            }

            // 情報取得
            Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this._dataIndex][GUID_TITLE];
            SCMDeliDateSt scmDeliDateSt = ((SCMDeliDateSt)this._scmDeliDateStTable[guid]).Clone();

            // SCM納期設定が存在していない
            if (scmDeliDateSt == null)
            {
                return -1;
            }

            status = this._scmDeliDateStAcs.Revival(ref scmDeliDateSt);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        SCMDeliDateStToDataSet(scmDeliDateSt.Clone(), this._dataIndex);
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
                            PROGRAM_ID, 						// アセンブリＩＤまたはクラスＩＤ
                            this.Text, 		                    // プログラム名称
                            "Revival", 							// 処理名称
                            TMsgDisp.OPE_UPDATE, 				// オペレーション
                            "復活に失敗しました。", 			// 表示するメッセージ
                            status, 							// ステータス値
                            this._scmDeliDateStAcs, 			// エラーが発生したオブジェクト
                            MessageBoxButtons.OK, 				// 表示するボタン
                            MessageBoxDefaultButton.Button1);	// 初期表示ボタン
                        CloseForm(DialogResult.Cancel);
                        return status;
                    }
            }
            return status;
        }

        /// <summary>
        /// SCM納期設定オブジェクト完全削除処理
        /// </summary>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : SCM納期設定ブジェクトの完全削除を行います</br>
        /// <br></br>
        /// </remarks>
        private int PhysicalDelete()
        {
            int status = 0;

            if ((this._dataIndex < 0) ||
                (this._dataIndex >= this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Count))
            {
                return -1;
            }

            // 情報取得
            Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this._dataIndex][GUID_TITLE];
            SCMDeliDateSt scmDeliDateSt = (SCMDeliDateSt)this._scmDeliDateStTable[guid];

            // SCM納期設定が存在していない
            if (scmDeliDateSt == null)
            {
                return -1;
            }

            // 設定種別が「拠点単位」の時に全社設定の場合には削除不可
            if (!IsDeletableCondition(scmDeliDateSt))
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

            status = this._scmDeliDateStAcs.Delete(scmDeliDateSt);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // ハッシュテーブルからデータを削除
                        this._scmDeliDateStTable.Remove((Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this._dataIndex][GUID_TITLE]);
                        // データセットからデータを削除
                        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this._dataIndex].Delete();
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
                            PROGRAM_ID, 						// アセンブリＩＤまたはクラスＩＤ
                            this.Text, 				            // プログラム名称
                            "PhysicalDelete", 					// 処理名称
                            TMsgDisp.OPE_DELETE, 				// オペレーション
                            "削除に失敗しました。", 			// 表示するメッセージ
                            status, 							// ステータス値
                            this._scmDeliDateStAcs,			    // エラーが発生したオブジェクト
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
        /// <br></br>
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
                        this.Renewal_Button.Visible = true;
                        this.Cancel_Button.Visible = true;
                        this.Revive_Button.Visible = false;
                        this.Delete_Button.Visible = false;

                        // コントロールの表示設定
                        ScreenInputPermissionControl(true, false);

                        // 初期フォーカスをセット
                        this.SetKind_tComboEditor.Focus();

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
                        this.Renewal_Button.Visible = false;
                        this.Cancel_Button.Visible = true;
                        this.Revive_Button.Visible = true;
                        this.Delete_Button.Visible = true;

                        // コントロールの表示設定
                        ScreenInputPermissionControl(false, false);

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
                        this.Renewal_Button.Visible = true;
                        this.Cancel_Button.Visible = true;
                        this.Revive_Button.Visible = false;
                        this.Delete_Button.Visible = false;

                        // コントロールの表示設定
                        ScreenInputPermissionControl(true, true);

                        // 拠点コードのコメント非表示
                        SectionNm_Label.Visible = false;

                        // 初期フォーカスをセット
                        this.tNedit_AnswerDeadTime1_HH.Focus();

                        break;
                    }
            }
        }

        /// <summary>
        /// 画面入力許可制御処理
        /// </summary>
        /// <param name="enabled">入力許可設定値</param>
        /// <param name="update">更新フラグ</param>        
        /// <remarks>
        /// <br>Note       : 画面の入力許可を制御します。</br>
        /// <br></br>
        /// </remarks>
        void ScreenInputPermissionControl(bool enabled, bool update)
        {
            this.SetKind_tComboEditor.Enabled = enabled;            // 設定種別
            this.tEdit_SectionCodeAllowZero2.Enabled = enabled;      // 拠点コード
            this.SectionGd_ultraButton.Enabled = enabled;           // 拠点ガイドボタン 
            this.SectionNm_tEdit.Enabled = enabled;                 // 拠点ガイド名称
            this.tNedit_CustomerCode.Enabled = enabled;             // 得意先コード
            this.CustomerGd_ultraButton.Enabled = enabled;          // 得意先ガイドボタン
            this.CustomerName_tEdit.Enabled = enabled;              // 得意先名称

            this.tNedit_AnswerDeadTime1_HH.Enabled = enabled;       // 回答締切時刻１
            this.tNedit_AnswerDeadTime1_MM.Enabled = enabled;
            this.tEdit_AnswerDelivDate1.Enabled = enabled;          // 回答納期１
            this.tNedit_AnswerDeadTime2_HH.Enabled = enabled;       // 回答締切時刻２
            this.tNedit_AnswerDeadTime2_MM.Enabled = enabled;
            this.tEdit_AnswerDelivDate2.Enabled = enabled;          // 回答納期２
            this.tNedit_AnswerDeadTime3_HH.Enabled = enabled;       // 回答締切時刻３
            this.tNedit_AnswerDeadTime3_MM.Enabled = enabled;
            this.tEdit_AnswerDelivDate3.Enabled = enabled;          // 回答納期３
            this.tNedit_AnswerDeadTime4_HH.Enabled = enabled;       // 回答締切時刻４
            this.tNedit_AnswerDeadTime4_MM.Enabled = enabled;
            this.tEdit_AnswerDelivDate4.Enabled = enabled;          // 回答納期４
            this.tNedit_AnswerDeadTime5_HH.Enabled = enabled;       // 回答締切時刻５
            this.tNedit_AnswerDeadTime5_MM.Enabled = enabled;
            this.tEdit_AnswerDelivDate5.Enabled = enabled;          // 回答納期５
            this.tNedit_AnswerDeadTime6_HH.Enabled = enabled;       // 回答締切時刻６
            this.tNedit_AnswerDeadTime6_MM.Enabled = enabled;
            this.tEdit_AnswerDelivDate6.Enabled = enabled;          // 回答納期６

            // 2011/01/06 Add >>>
            this.tNedit_AnswerDeadTime1Stc_HH.Enabled = enabled;       // 回答締切時刻１（在庫）
            this.tNedit_AnswerDeadTime1Stc_MM.Enabled = enabled;
            this.tEdit_AnswerDelivDate1Stc.Enabled = enabled;          // 回答納期１（在庫）
            this.tNedit_AnswerDeadTime2Stc_HH.Enabled = enabled;       // 回答締切時刻２（在庫）
            this.tNedit_AnswerDeadTime2Stc_MM.Enabled = enabled;
            this.tEdit_AnswerDelivDate2Stc.Enabled = enabled;          // 回答納期２（在庫）
            this.tNedit_AnswerDeadTime3Stc_HH.Enabled = enabled;       // 回答締切時刻３（在庫）
            this.tNedit_AnswerDeadTime3Stc_MM.Enabled = enabled;
            this.tEdit_AnswerDelivDate3Stc.Enabled = enabled;          // 回答納期３（在庫）
            this.tNedit_AnswerDeadTime4Stc_HH.Enabled = enabled;       // 回答締切時刻４（在庫）
            this.tNedit_AnswerDeadTime4Stc_MM.Enabled = enabled;
            this.tEdit_AnswerDelivDate4Stc.Enabled = enabled;          // 回答納期４（在庫）
            this.tNedit_AnswerDeadTime5Stc_HH.Enabled = enabled;       // 回答締切時刻５（在庫）
            this.tNedit_AnswerDeadTime5Stc_MM.Enabled = enabled;
            this.tEdit_AnswerDelivDate5Stc.Enabled = enabled;          // 回答納期５（在庫）
            this.tNedit_AnswerDeadTime6Stc_HH.Enabled = enabled;       // 回答締切時刻６（在庫）
            this.tNedit_AnswerDeadTime6Stc_MM.Enabled = enabled;
            this.tEdit_AnswerDelivDate6Stc.Enabled = enabled;          // 回答納期６（在庫）

            this.tComboEditor_EntStckAnsDeliDtDiv.Enabled = enabled;          // 委託在庫回答納期区分

            if (enabled == false)
            {
                this.tEdit_EntStckAnsDeliDate.Enabled = enabled;        // 委託在庫回答納期
                // ADD 2012/10/31 T.Yoshioka 2012/11/14配信 システムテスト障害№17 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                this.tEdit_EntStckAnsDeliDateShortage.Enabled = enabled;    // 委託在庫回答納期（在庫不足）
                this.tEdit_EntStckAnsDeliDateNoStc.Enabled = enabled;       // 委託在庫回答納期（在庫数無し）
                // ADD 2012/10/31 T.Yoshioka 2012/11/14配信 システムテスト障害№17 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                // ADD 2015/02/10 豊沢 SCM高速化 回答納期区分対応 ------------------------------------------>>>>>
                this.tComboEditor_EntStcAnsDelDtStcDiv.Enabled = enabled; // 委託在庫回答納期区分（在庫）
                this.tComboEditor_EntStcAnsDelDtShoDiv.Enabled = enabled; // 委託在庫回答納期区分（在庫不足）
                this.tComboEditor_EntStcAnsDelDtWioDiv.Enabled = enabled; // 委託在庫回答納期区分（在庫数無し）
                // ADD 2015/02/10 豊沢 SCM高速化 回答納期区分対応 ------------------------------------------<<<<<
            }
            // 2011/01/06 Add <<<

            // 2011/10/11 Add >>>
            this.tComboEditor_PriStckAnsDeliDtDiv.Enabled = enabled;          // 優先在庫回答納期区分

            if (enabled == false)
            {
                this.tEdit_PriStckAnsDeliDate.Enabled = enabled;        // 優先在庫回答納期
                // ADD 2012/10/31 T.Yoshioka 2012/11/14配信 システムテスト障害№17 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                this.tEdit_PriStckAnsDeliDateShortage.Enabled = enabled;    // 参照在庫回答納期（在庫不足）
                this.tEdit_PriStckAnsDeliDateNoStc.Enabled = enabled;       // 参照在庫回答納期（在庫数無し）
                // ADD 2012/10/31 T.Yoshioka 2012/11/14配信 システムテスト障害№17 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                // ADD 2015/02/10 豊沢 SCM高速化 回答納期区分対応 ------------------------------------------>>>>>
                this.tComboEditor_PriStcAnsDelDtStcDiv.Enabled = enabled; // 参照在庫回答納期区分（在庫）
                this.tComboEditor_PriStcAnsDelDtShoDiv.Enabled = enabled; // 参照在庫回答納期区分（在庫不足）
                this.tComboEditor_PriStcAnsDelDtWioDiv.Enabled = enabled; // 参照在庫回答納期区分（在庫数無し）
                // ADD 2015/02/10 豊沢 SCM高速化 回答納期区分対応 ------------------------------------------<<<<<
            }
            // 2011/10/11 Add <<<
            // 2012/08/30 ADD TAKAGAWA 2012/10月配信予定 SCM障害№10345 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            this.tEdit_AnswerDelivDate1StcShortage.Enabled = enabled;   // 回答納期（在庫不足）
            this.tEdit_AnswerDelivDate1StcNotStc.Enabled = enabled;     // 回答納期（在庫数無し）
            // DEL 2012/10/31 T.Yoshioka 2012/11/14配信 システムテスト障害№17 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            //this.tEdit_EntStckAnsDeliDateShortage.Enabled = enabled;    // 委託在庫回答納期（在庫不足）
            //this.tEdit_EntStckAnsDeliDateNoStc.Enabled = enabled;       // 委託在庫回答納期（在庫数無し）
            //this.tEdit_PriStckAnsDeliDateShortage.Enabled = enabled;    // 参照在庫回答納期（在庫不足）
            //this.tEdit_PriStckAnsDeliDateNoStc.Enabled = enabled;       // 参照在庫回答納期（在庫数無し）
            // DEL 2012/10/31 T.Yoshioka 2012/11/14配信 システムテスト障害№17 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
            // 2012/08/30 ADD TAKAGAWA 2012/10月配信予定 SCM障害№10345 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

            // 更新時処理？
            if (update == true)
            {
                SetKind_tComboEditor.Enabled = false;
                tEdit_SectionCodeAllowZero2.Enabled = false;
                SectionGd_ultraButton.Enabled = false;
                SectionNm_tEdit.Enabled = false;
                tNedit_CustomerCode.Enabled = false;
                CustomerGd_ultraButton.Enabled = false;
                CustomerName_tEdit.Enabled = false;
            }

            // ADD 2015/02/10 豊沢 SCM高速化 回答納期区分対応 ------------------------------------------>>>>>
            this.tComboEditor_AnsDelivDateDiv1.Enabled = enabled; // 回答納期区分１（取寄）
            this.tComboEditor_AnsDelivDateDiv2.Enabled = enabled; // 回答納期区分２（取寄）
            this.tComboEditor_AnsDelivDateDiv3.Enabled = enabled; // 回答納期区分３（取寄）
            this.tComboEditor_AnsDelivDateDiv4.Enabled = enabled; // 回答納期区分４（取寄）
            this.tComboEditor_AnsDelivDateDiv5.Enabled = enabled; // 回答納期区分５（取寄）
            this.tComboEditor_AnsDelivDateDiv6.Enabled = enabled; // 回答納期区分６（取寄）
            this.tComboEditor_AnsDelivDtDiv1Stc.Enabled = enabled; // 回答納期区分１（在庫）
            this.tComboEditor_AnsDelivDtDiv2Stc.Enabled = enabled; // 回答納期区分２（在庫）
            this.tComboEditor_AnsDelivDtDiv3Stc.Enabled = enabled; // 回答納期区分３（在庫）
            this.tComboEditor_AnsDelivDtDiv4Stc.Enabled = enabled; // 回答納期区分４（在庫）
            this.tComboEditor_AnsDelivDtDiv5Stc.Enabled = enabled; // 回答納期区分５（在庫）
            this.tComboEditor_AnsDelivDtDiv6Stc.Enabled = enabled; // 回答納期区分６（在庫）
            this.tComboEditor_AnsDelDtShoStcDiv.Enabled = enabled; // 回答納期区分（在庫不足）
            this.tComboEditor_AnsDelDtWioStcDiv.Enabled = enabled; // 回答納期区分（在庫数無し）
            // ADD 2015/02/10 豊沢 SCM高速化 回答納期区分対応 ------------------------------------------<<<<<

            // ちらつき防止の為
            this.Enabled = true;
        }

        /// <summary>
        /// データ検索処理
        /// </summary>
        /// <param name="totalCnt">全該当件数</param>
        /// <param name="readCnt">抽出対象件数</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : データを検索し、抽出結果を展開したデータセットと全該当件数を返します。</br>
        /// <br></br>
        /// </remarks>
        private int SearchSCMDeliDateSt(ref int totalCnt, int readCnt)
        {
            int status = 0;
            ArrayList retList = null;

            // 抽出対象件数が0件の場合は全件抽出を実行する
            status = this._scmDeliDateStAcs.SearchAll(out retList, this._enterpriseCode);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        int index = 0;
                        foreach (SCMDeliDateSt wkSCMDeliDateSt in retList)
                        {
                            if (this._scmDeliDateStTable.ContainsKey(wkSCMDeliDateSt.FileHeaderGuid) == false)
                            {
                                SCMDeliDateStToDataSet(wkSCMDeliDateSt.Clone(), index);
                                index++;
                            }
                        }
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    {
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ERROR:
                    {
                        // サーチ
                        TMsgDisp.Show(
                            this, 								// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOP, 		// エラーレベル
                            PROGRAM_ID, 						// アセンブリＩＤまたはクラスＩＤ
                            this.Text, 			                // プログラム名称
                            "SearchStockMngTtlSt", 			    // 処理名称
                            TMsgDisp.OPE_GET, 					// オペレーション
                            "読み込みに失敗しました。", 		// 表示するメッセージ
                            status, 							// ステータス値
                            this._scmDeliDateStAcs, 		    // エラーが発生したオブジェクト
                            MessageBoxButtons.OK, 				// 表示するボタン
                            MessageBoxDefaultButton.Button1);	// 初期表示ボタン

                        break;
                    }
            }

            if (retList == null)
            {
                retList = new ArrayList();
            }
            // マスメンフレーム側でエラーとして扱ってしまうため、正常値に改算
            //if (!status.Equals((int)ConstantManagement.DB_Status.ctDB_ERROR)) status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            totalCnt = retList.Count;

            return status;
        }

        /// <summary>
        /// SCM納期設定オブジェクト展開処理
        /// </summary>
        /// <param name="scmDeliDateSt">SCM納期設定オブジェクト</param>
        /// <param name="index">データセットへ展開するインデックス</param>
        /// <remarks>
        /// <br>Note       : SCM納期設定クラスをDataSetに格納します。</br>
        /// <br></br>
        /// </remarks>
        private void SCMDeliDateStToDataSet(SCMDeliDateSt scmDeliDateSt, int index)
        {
            if ((index < 0) || (index >= this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Count))
            {
                // 新規と判断し、行を追加する。
                DataRow dataRow = this.Bind_DataSet.Tables[VIEW_TABLE].NewRow();
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Add(dataRow);

                // indexを最終行番号にする
                index = this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Count - 1;
            }

            // 削除日
            if (scmDeliDateSt.LogicalDeleteCode == 0)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][DELETE_DATE] = "";
            }
            else
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][DELETE_DATE] = scmDeliDateSt.UpdateDateTime;
            }

            if (scmDeliDateSt.CustomerCode == 0)
            {
                // 拠点コード
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][SECTIONCODE_TITLE] = scmDeliDateSt.SectionCode.TrimEnd();
                // 拠点名称
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][SECTIONNAME_TITLE] = GetSectionName(scmDeliDateSt.SectionCode);
                
                // 得意先コード
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][CUSTOMERCODE_TITLE] = "";
            }
            else
            {
                // 得意先コード
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][CUSTOMERCODE_TITLE] = scmDeliDateSt.CustomerCode.ToString("d08");
                // 得意先名称
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][CUSTOMERNAME_TITLE] = GetCustomerName(scmDeliDateSt.CustomerCode);

                // 拠点コード
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][SECTIONCODE_TITLE] = "";
            }
            
            // 回答締切時刻と回答納期
            for (int setNo = 0; setNo < MAX_ANSWER_COUNT; setNo++)
            {
                SetAnswerDataSet(setNo, index, scmDeliDateSt);
            }

            // 2011/01/06 Add >>>
            // 委託在庫回答納期区分
            string entStckAnsDeliDtDivNm = "";
            switch (scmDeliDateSt.EntStckAnsDeliDtDiv)
            {
                case 0:
                    entStckAnsDeliDtDivNm = ENTSTCKANSDELIDTDIVNAME0;
                    break;
                case 1:
                    entStckAnsDeliDtDivNm = ENTSTCKANSDELIDTDIVNAME1;
                    break;
                case 2:
                    entStckAnsDeliDtDivNm = ENTSTCKANSDELIDTDIVNAME2;
                    break;
            }
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][ENTSTCKANSDELIDTDIV] = entStckAnsDeliDtDivNm;

            // 委託在庫回答納期
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][ENTSTCKANSDELIDATE] = scmDeliDateSt.EntStckAnsDeliDate;
            // 2011/01/06 Add <<<

            // 2011/10/11 Add >>>
            // 優先在庫回答納期区分
            string priStckAnsDeliDtDivNm = "";
            switch (scmDeliDateSt.PriStckAnsDeliDtDiv)
            {
                case 0:
                    priStckAnsDeliDtDivNm = PRISTCKANSDELIDTDIVNAME0;
                    break;
                case 1:
                    priStckAnsDeliDtDivNm = PRISTCKANSDELIDTDIVNAME1;
                    break;
            }
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][PRISTCKANSDELIDTDIV] = priStckAnsDeliDtDivNm;

            // 優先在庫回答納期
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][PRISTCKANSDELIDATE] = scmDeliDateSt.PriStckAnsDeliDate;
            // 2011/10/11 Add <<<
            // 2012/08/30 ADD TAKAGAWA 2012/10月配信予定 SCM障害№10345 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            // 回答納期（在庫不足）
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][ANSDELDATSHORTOFSTC] = scmDeliDateSt.AnsDelDatShortOfStc;
            // 回答納期（在庫数無し）
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][ANSDELDATWITHOUTSTC] = scmDeliDateSt.AnsDelDatWithoutStc;
            // 委託在庫回答納期（在庫不足）
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][ENTSTCANSDELDATSHORT] = scmDeliDateSt.EntStcAnsDelDatShort;
            // 委託在庫回答納期（在庫数無し）
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][ENTSTCANSDELDATWIOUT] = scmDeliDateSt.EntStcAnsDelDatWiout;
            // 参照在庫回答納期（在庫不足）
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][PRISTCANSDELDATSHORT] =scmDeliDateSt.PriStcAnsDelDatShort;
            // 参照在庫回答納期（在庫数無し）
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][PRISTCANSDELDATWIOUT] = scmDeliDateSt.PriStcAnsDelDatWiout;
            // 2012/08/30 ADD TAKAGAWA 2012/10月配信予定 SCM障害№10345 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

            // ADD 2015/02/10 豊沢 SCM高速化 回答納期区分対応 ------------------------------------------>>>>>
            // 回答納期区分１（取寄）
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][ANSWER_DELIV_DATE_DIV_1] = this.GetAnsDeliDateDivName(scmDeliDateSt.AnsDelDtDiv1);
            // 回答納期区分２（取寄）
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][ANSWER_DELIV_DATE_DIV_2] = this.GetAnsDeliDateDivName(scmDeliDateSt.AnsDelDtDiv2);
            // 回答納期区分３（取寄）
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][ANSWER_DELIV_DATE_DIV_3] = this.GetAnsDeliDateDivName(scmDeliDateSt.AnsDelDtDiv3);
            // 回答納期区分４（取寄）
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][ANSWER_DELIV_DATE_DIV_4] = this.GetAnsDeliDateDivName(scmDeliDateSt.AnsDelDtDiv4);
            // 回答納期区分５（取寄）
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][ANSWER_DELIV_DATE_DIV_5] = this.GetAnsDeliDateDivName(scmDeliDateSt.AnsDelDtDiv5);
            // 回答納期区分６（取寄）
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][ANSWER_DELIV_DATE_DIV_6] = this.GetAnsDeliDateDivName(scmDeliDateSt.AnsDelDtDiv6);
            // 回答納期区分１（在庫）
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][ANSWER_DELIV_DATE_DIV_1_STC] = this.GetAnsDeliDateDivName(scmDeliDateSt.AnsDelDtDiv1Stc);
            // 回答納期区分２（在庫）
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][ANSWER_DELIV_DATE_DIV_2_STC] = this.GetAnsDeliDateDivName(scmDeliDateSt.AnsDelDtDiv2Stc);
            // 回答納期区分３（在庫）
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][ANSWER_DELIV_DATE_DIV_3_STC] = this.GetAnsDeliDateDivName(scmDeliDateSt.AnsDelDtDiv3Stc);
            // 回答納期区分４（在庫）
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][ANSWER_DELIV_DATE_DIV_4_STC] = this.GetAnsDeliDateDivName(scmDeliDateSt.AnsDelDtDiv4Stc);
            // 回答納期区分５（在庫）
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][ANSWER_DELIV_DATE_DIV_5_STC] = this.GetAnsDeliDateDivName(scmDeliDateSt.AnsDelDtDiv5Stc);
            // 回答納期区分６（在庫）
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][ANSWER_DELIV_DATE_DIV_6_STC] = this.GetAnsDeliDateDivName(scmDeliDateSt.AnsDelDtDiv6Stc);
            // 回答納期区分（在庫不足）
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][ANSDELDATSHORTOFSTC_DIV] = this.GetAnsDeliDateDivName(scmDeliDateSt.AnsDelDtShoStcDiv);
            // 回答納期区分（在庫数無し）
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][ANSDELDATWITHOUTSTC_DIV] = this.GetAnsDeliDateDivName(scmDeliDateSt.AnsDelDtWioStcDiv);
            // 委託在庫回答納期区分（在庫）
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][ENTSTCKANSDELIDATE_DIV] = this.GetAnsDeliDateDivName(scmDeliDateSt.EntAnsDelDtStcDiv);
            // 委託在庫回答納期区分（在庫不足）
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][ENTSTCANSDELDATSHORT_DIV] = this.GetAnsDeliDateDivName(scmDeliDateSt.EntAnsDelDtShoDiv);
            // 委託在庫回答納期区分（在庫数無し）
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][ENTSTCANSDELDATWIOUT_DIV] = this.GetAnsDeliDateDivName(scmDeliDateSt.EntAnsDelDtWioDiv);
            // 参照在庫回答納期区分（在庫）
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][PRISTCKANSDELIDATE_DIV] = this.GetAnsDeliDateDivName(scmDeliDateSt.PriAnsDelDtStcDiv);
            // 参照在庫回答納期区分（在庫不足）
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][PRISTCANSDELDATSHORT_DIV] = this.GetAnsDeliDateDivName(scmDeliDateSt.PriAnsDelDtShoDiv);
            // 参照在庫回答納期区分（在庫数無し）
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][PRISTCANSDELDATWIOUT_DIV] = this.GetAnsDeliDateDivName(scmDeliDateSt.PriAnsDelDtWioDiv);
            // ADD 2015/02/10 豊沢 SCM高速化 回答納期区分対応 ------------------------------------------<<<<<

            // GUID
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][GUID_TITLE] = scmDeliDateSt.FileHeaderGuid;

            if (this._scmDeliDateStTable.ContainsKey(scmDeliDateSt.FileHeaderGuid) == true)
            {
                this._scmDeliDateStTable.Remove(scmDeliDateSt.FileHeaderGuid);
            }
            this._scmDeliDateStTable.Add(scmDeliDateSt.FileHeaderGuid, scmDeliDateSt);

        }

        /// <summary>
        /// 回答締切時刻、回答納期展開処理
        /// </summary>
        /// <param name="setNo">設定対象の回答締切時刻と回答納期の番号</param>
        /// <param name="index">データセットへ展開するインデックス</param>
        /// <param name="scmDeliDateSt">SCM納期設定オブジェクト</param>
        /// <remarks>
        /// <br>Note       : 回答締切時刻、回答納期をDataSetに格納します。</br>
        /// <br></br>
        /// </remarks>
        private void SetAnswerDataSet(int setNo, int index, SCMDeliDateSt scmDeliDateSt)
        {
            int hour;
            int min;
            
            switch (setNo)
            {
                case 0:     // 回答締切時刻１、回答納期１
                    {
                        if (scmDeliDateSt.AnswerDeadTime1 > 0)
                        {
                            hour = (scmDeliDateSt.AnswerDeadTime1 / 10000) % HOUR_24;
                            min = (scmDeliDateSt.AnswerDeadTime1 % 10000) / 100;
                            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][ANSWER_DEAD_TIME_1] = string.Format("{0}時{1}分", hour.ToString("00"), min.ToString("00"));
                            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][ANSWER_DELIV_DATE_1] = scmDeliDateSt.AnswerDelivDate1;
                        }
                        else
                        {
                            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][ANSWER_DEAD_TIME_1] = string.Empty;
                            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][ANSWER_DELIV_DATE_1] = string.Empty;
                        }
                        break;
                    }
                case 1:     // 回答締切時刻２、回答納期２
                    {
                        if (scmDeliDateSt.AnswerDeadTime2 > 0)
                        {
                            hour = (scmDeliDateSt.AnswerDeadTime2 / 10000) % HOUR_24;
                            min = (scmDeliDateSt.AnswerDeadTime2 % 10000) / 100;
                            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][ANSWER_DEAD_TIME_2] = string.Format("{0}時{1}分", hour.ToString("00"), min.ToString("00"));
                            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][ANSWER_DELIV_DATE_2] = scmDeliDateSt.AnswerDelivDate2;
                        }
                        else
                        {
                            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][ANSWER_DEAD_TIME_2] = string.Empty;
                            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][ANSWER_DELIV_DATE_2] = string.Empty;
                        }
                        break;
                    }
                case 2:     // 回答締切時刻３、回答納期３
                    {
                        if (scmDeliDateSt.AnswerDeadTime3 > 0)
                        {
                            hour = (scmDeliDateSt.AnswerDeadTime3 / 10000) % HOUR_24;
                            min = (scmDeliDateSt.AnswerDeadTime3 % 10000) / 100;
                            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][ANSWER_DEAD_TIME_3] = string.Format("{0}時{1}分", hour.ToString("00"), min.ToString("00"));
                            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][ANSWER_DELIV_DATE_3] = scmDeliDateSt.AnswerDelivDate3;
                        }
                        else
                        {
                            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][ANSWER_DEAD_TIME_3] = string.Empty;
                            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][ANSWER_DELIV_DATE_3] = string.Empty;
                        }
                        break;
                    }
                case 3:     // 回答締切時刻４、回答納期４
                    {
                        if (scmDeliDateSt.AnswerDeadTime4 > 0)
                        {
                            hour = (scmDeliDateSt.AnswerDeadTime4 / 10000) % HOUR_24;
                            min = (scmDeliDateSt.AnswerDeadTime4 % 10000) / 100;
                            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][ANSWER_DEAD_TIME_4] = string.Format("{0}時{1}分", hour.ToString("00"), min.ToString("00"));
                            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][ANSWER_DELIV_DATE_4] = scmDeliDateSt.AnswerDelivDate4;
                        }
                        else
                        {
                            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][ANSWER_DEAD_TIME_4] = string.Empty;
                            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][ANSWER_DELIV_DATE_4] = string.Empty;
                        }
                        break;
                    }
                case 4:     // 回答締切時刻５、回答納期５
                    {
                        if (scmDeliDateSt.AnswerDeadTime5 > 0)
                        {
                            hour = (scmDeliDateSt.AnswerDeadTime5 / 10000) % HOUR_24;
                            min = (scmDeliDateSt.AnswerDeadTime5 % 10000) / 100;
                            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][ANSWER_DEAD_TIME_5] = string.Format("{0}時{1}分", hour.ToString("00"), min.ToString("00"));
                            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][ANSWER_DELIV_DATE_5] = scmDeliDateSt.AnswerDelivDate5;
                        }
                        else
                        {
                            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][ANSWER_DEAD_TIME_5] = string.Empty;
                            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][ANSWER_DELIV_DATE_5] = string.Empty;
                        }
                        break;
                    }
                case 5:     // 回答締切時刻６、回答納期６
                    {
                        if (scmDeliDateSt.AnswerDeadTime6 > 0)
                        {
                            hour = (scmDeliDateSt.AnswerDeadTime6 / 10000) % HOUR_24;
                            min = (scmDeliDateSt.AnswerDeadTime6 % 10000) / 100;
                            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][ANSWER_DEAD_TIME_6] = string.Format("{0}時{1}分", hour.ToString("00"), min.ToString("00"));
                            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][ANSWER_DELIV_DATE_6] = scmDeliDateSt.AnswerDelivDate6;
                        }
                        else
                        {
                            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][ANSWER_DEAD_TIME_6] = string.Empty;
                            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][ANSWER_DELIV_DATE_6] = string.Empty;
                        }
                        break;
                    }
                // 2011/01/06 Add >>>
                case 6:     // 回答締切時刻１（在庫）、回答納期１（在庫）
                    {
                        if (scmDeliDateSt.AnswerDeadTime1Stc > 0)
                        {
                            hour = (scmDeliDateSt.AnswerDeadTime1Stc / 10000) % HOUR_24;
                            min = (scmDeliDateSt.AnswerDeadTime1Stc % 10000) / 100;
                            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][ANSWER_DEAD_TIME_1_STC] = string.Format("{0}時{1}分", hour.ToString("00"), min.ToString("00"));
                            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][ANSWER_DELIV_DATE_1_STC] = scmDeliDateSt.AnswerDelivDate1Stc;
                        }
                        else
                        {
                            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][ANSWER_DEAD_TIME_1_STC] = string.Empty;
                            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][ANSWER_DELIV_DATE_1_STC] = string.Empty;
                        }
                        break;
                    }
                case 7:     // 回答締切時刻２（在庫）、回答納期２（在庫）
                    {
                        if (scmDeliDateSt.AnswerDeadTime2Stc > 0)
                        {
                            hour = (scmDeliDateSt.AnswerDeadTime2Stc / 10000) % HOUR_24;
                            min = (scmDeliDateSt.AnswerDeadTime2Stc % 10000) / 100;
                            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][ANSWER_DEAD_TIME_2_STC] = string.Format("{0}時{1}分", hour.ToString("00"), min.ToString("00"));
                            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][ANSWER_DELIV_DATE_2_STC] = scmDeliDateSt.AnswerDelivDate2Stc;
                        }
                        else
                        {
                            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][ANSWER_DEAD_TIME_2_STC] = string.Empty;
                            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][ANSWER_DELIV_DATE_2_STC] = string.Empty;
                        }
                        break;
                    }
                case 8:     // 回答締切時刻３（在庫）、回答納期３（在庫）
                    {
                        if (scmDeliDateSt.AnswerDeadTime3Stc > 0)
                        {
                            hour = (scmDeliDateSt.AnswerDeadTime3Stc / 10000) % HOUR_24;
                            min = (scmDeliDateSt.AnswerDeadTime3Stc % 10000) / 100;
                            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][ANSWER_DEAD_TIME_3_STC] = string.Format("{0}時{1}分", hour.ToString("00"), min.ToString("00"));
                            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][ANSWER_DELIV_DATE_3_STC] = scmDeliDateSt.AnswerDelivDate3Stc;
                        }
                        else
                        {
                            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][ANSWER_DEAD_TIME_3_STC] = string.Empty;
                            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][ANSWER_DELIV_DATE_3_STC] = string.Empty;
                        }
                        break;
                    }
                case 9:     // 回答締切時刻４（在庫）、回答納期４（在庫）
                    {
                        if (scmDeliDateSt.AnswerDeadTime4Stc > 0)
                        {
                            hour = (scmDeliDateSt.AnswerDeadTime4Stc / 10000) % HOUR_24;
                            min = (scmDeliDateSt.AnswerDeadTime4Stc % 10000) / 100;
                            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][ANSWER_DEAD_TIME_4_STC] = string.Format("{0}時{1}分", hour.ToString("00"), min.ToString("00"));
                            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][ANSWER_DELIV_DATE_4_STC] = scmDeliDateSt.AnswerDelivDate4Stc;
                        }
                        else
                        {
                            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][ANSWER_DEAD_TIME_4_STC] = string.Empty;
                            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][ANSWER_DELIV_DATE_4_STC] = string.Empty;
                        }
                        break;
                    }
                case 10:     // 回答締切時刻５（在庫）、回答納期５（在庫）
                    {
                        if (scmDeliDateSt.AnswerDeadTime5Stc > 0)
                        {
                            hour = (scmDeliDateSt.AnswerDeadTime5Stc / 10000) % HOUR_24;
                            min = (scmDeliDateSt.AnswerDeadTime5Stc % 10000) / 100;
                            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][ANSWER_DEAD_TIME_5_STC] = string.Format("{0}時{1}分", hour.ToString("00"), min.ToString("00"));
                            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][ANSWER_DELIV_DATE_5_STC] = scmDeliDateSt.AnswerDelivDate5Stc;
                        }
                        else
                        {
                            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][ANSWER_DEAD_TIME_5_STC] = string.Empty;
                            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][ANSWER_DELIV_DATE_5_STC] = string.Empty;
                        }
                        break;
                    }
                case 11:     // 回答締切時刻６（在庫）、回答納期６（在庫）
                    {
                        if (scmDeliDateSt.AnswerDeadTime6Stc > 0)
                        {
                            hour = (scmDeliDateSt.AnswerDeadTime6Stc / 10000) % HOUR_24;
                            min = (scmDeliDateSt.AnswerDeadTime6Stc % 10000) / 100;
                            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][ANSWER_DEAD_TIME_6_STC] = string.Format("{0}時{1}分", hour.ToString("00"), min.ToString("00"));
                            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][ANSWER_DELIV_DATE_6_STC] = scmDeliDateSt.AnswerDelivDate6Stc;
                        }
                        else
                        {
                            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][ANSWER_DEAD_TIME_6_STC] = string.Empty;
                            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][ANSWER_DELIV_DATE_6_STC] = string.Empty;
                        }
                        break;
                    }
                // 2011/01/06 Add <<<
            }
        }

        /// <summary>
        /// SCM納期設定オブジェクト論理削除処理
        /// </summary>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : SCM納期設定オブジェクトの論理削除を行います。</br>
        /// <br></br>
        /// </remarks>
        private int LogicalDelete()
        {
            int status = 0;

            if ((this._dataIndex < 0) ||
                (this._dataIndex >= this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Count))
            {
                return -1;
            }

            // 情報取得
            Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this._dataIndex][GUID_TITLE];
            SCMDeliDateSt scmDeliDateSt = ((SCMDeliDateSt)this._scmDeliDateStTable[guid]).Clone();

            // SCM納期設定が存在していない
            if (scmDeliDateSt == null)
            {
                return -1;
            }

            // 設定種別が「拠点単位」の時に全社設定の場合には削除不可
            if (!IsDeletableCondition(scmDeliDateSt))
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
            
            status = this._scmDeliDateStAcs.LogicalDelete(ref scmDeliDateSt);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        SCMDeliDateStToDataSet(scmDeliDateSt.Clone(), this._dataIndex);
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
                            PROGRAM_ID, 						// アセンブリＩＤまたはクラスＩＤ
                            this.Text, 				            // プログラム名称
                            "LogicalDelete", 					// 処理名称
                            TMsgDisp.OPE_HIDE, 					// オペレーション
                            "削除に失敗しました。", 			// 表示するメッセージ
                            status, 							// ステータス値
                            this._scmDeliDateStAcs,			    // エラーが発生したオブジェクト
                            MessageBoxButtons.OK, 				// 表示するボタン
                            MessageBoxDefaultButton.Button1);	// 初期表示ボタン

                        return status;
                    }
            }
            return status;
        }

        /// <summary>
        /// 削除できる条件か判定します。
        /// </summary>
        /// <param name="scmDeliDateSt">SCM納期設定</param>
        /// <returns><c>true</c> :削除可<br/><c>false</c>:削除不可</returns>
        /// <remarks>
        /// <br>Note       :</br>
        /// <br></br>
        /// </remarks>
        private static bool IsDeletableCondition(SCMDeliDateSt scmDeliDateSt)
        {
            return !SectionUtil.IsAllSection(scmDeliDateSt.SectionCode);
        }
        
        /// <summary>
        /// 拠点名称取得処理
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <returns>拠点名称</returns>
        /// <remarks>
        /// <br>Note       : 拠点名称を取得します。</br>
        /// <br></br>
        /// </remarks>
        private string GetSectionName(string sectionCode)
        {
            string sectionName = "";

            if (sectionCode.Trim().PadLeft(2, '0') == ALL_SECTIONCODE)
            {
                sectionName = "全社共通";
                return sectionName;
            }

            try
            {
                foreach (SecInfoSet secInfoSet in this._secInfoAcs.SecInfoSetList)
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
        /// 得意先名称取得処理
        /// </summary>
        /// <param name="customerCode">得意先コード</param>
        /// <returns>得意先名称</returns>
        /// <remarks>
        /// <br>Note       : 得意先名称を取得します。</br>
        /// <br></br>
        /// </remarks>
        private string GetCustomerName(int customerCode)
        {
            return GetCustomerName(customerCode, false);
        }

        /// <summary>
        /// 得意先名称を取得します。
        /// </summary>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="throwsExceptionWhenCodeIsNotFound">該当する得意先コードがない場合、例外を投入するフラグ</param>
        /// <returns>得意先名称</returns>
        /// <exception cref="ArgumentException">
        /// <c>throwsExceptionWhenCodeIsNotFound</c>が<c>true</c>のとき、
        /// 得意先マスタに該当する得意先コードが存在しない場合、投入されます。
        /// </exception>
        /// <remarks>
        /// <br>Note       :</br>
        /// <br></br>
        /// </remarks>
        private string GetCustomerName(
            int customerCode,
            bool throwsExceptionWhenCodeIsNotFound
        )
        {
            string customerName = string.Empty;
            CustomerInfo customerInfo = new CustomerInfo();

            bool codeIsFound = false;
            try
            {
                foreach (CustomerSearchRet customerSearchRet in this._customerList)
                {
                    if (customerSearchRet.CustomerCode == customerCode)
                    {
                        codeIsFound = true;
                        customerName = customerSearchRet.Snm.Trim();
                        break;
                    }
                }

                if (customerName == "")
                {
                    int status = this._customerInfoAcs.ReadDBData(this._enterpriseCode, customerCode, out customerInfo);
                    if (status == 0)
                    {
                        codeIsFound = true;
                        customerName = customerInfo.CustomerSnm.Trim();
                    }
                }
            }
            catch
            {
                customerName = string.Empty;
            }

            if (!codeIsFound && throwsExceptionWhenCodeIsNotFound)
            {
                throw new ArgumentException("customerCode(=" + customerCode.ToString() + ") is not found.");
            }

            return customerName;
        }
        
        /// <summary>
        /// キャッシュ情報取得処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 得意先の名称をキャッシュ化。</br>
        /// </remarks>
        private void GetCacheData()
        {
            // 得意先名称リスト取得
            this.GetCustomerNameList();
            
        }

        /// <summary>
        /// 得意先名称リスト取得処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 得意先名称のリストを取得します。</br>
        /// </remarks>
        private void GetCustomerNameList()
        {
            int status;
            CustomerSearchAcs customerSearchAcs = new CustomerSearchAcs();

            CustomerSearchRet[] customerSearchRetArray;
            CustomerSearchPara customerSearchPara = new CustomerSearchPara();
            customerSearchPara.EnterpriseCode = this._enterpriseCode;

            this._customerList = new ArrayList();

            status = customerSearchAcs.Serch(out customerSearchRetArray, customerSearchPara);
            if (status == 0)
            {
                foreach (CustomerSearchRet customerSearchRet in customerSearchRetArray)
                {
                    // 論理削除データは読み込まない
                    if (customerSearchRet.LogicalDeleteCode != 1)
                    {
                        this._customerList.Add(customerSearchRet);
                    }
                }
            }
        }

        /// <summary>
        /// モード変更処理(拠点別)
        /// </summary>
        private bool ModeChangeProcSection()
        {
            // --- ADD 2011/09/07 -------------------------------->>>>>
            isError = false;
            EventArgs e = new EventArgs();
            tEdit_SectionCode_Leave(null, e);

            if (string.IsNullOrEmpty(tEdit_SectionCodeAllowZero2.Text.Trim()))
            {
                this.SectionNm_tEdit.Clear();
                return false;
            }
            // --- ADD 2011/09/07 --------------------------------<<<<<
            string msg = "入力されたコードのSCM納期設定情報が既に登録されています。\n編集を行いますか？";

            // 拠点コード
            string sectionCd = tEdit_SectionCodeAllowZero2.Text.TrimEnd().PadLeft(2, '0');

            for (int i = 0; i < this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Count; i++)
            {
                int dsCustomerCode;
                if (!int.TryParse((string)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[i][CUSTOMERCODE_TITLE], out dsCustomerCode))
                {
                    dsCustomerCode = 0;
                }

                // データセットと比較
                string dsSecCd = (string)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[i][SECTIONCODE_TITLE];
                if ((sectionCd.Equals(dsSecCd.TrimEnd().PadLeft(2, '0'))) &&
                    (dsCustomerCode == 0))
                {
                    // 入力コードがデータセットに存在する場合
                    if ((string)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[i][DELETE_DATE] != "")
                    {
                        // 論理削除
                        TMsgDisp.Show(this, 					// 親ウィンドウフォーム
                          emErrorLevel.ERR_LEVEL_INFO,          // エラーレベル
                          PROGRAM_ID,						    // アセンブリＩＤまたはクラスＩＤ
                          "入力されたコードのSCM納期設定情報は既に削除されています。", 			// 表示するメッセージ
                          0, 									// ステータス値
                          MessageBoxButtons.OK);				// 表示するボタン
                        isError = true; // ADD 2011/09/07
                        // 拠点コードのクリア
                        tEdit_SectionCodeAllowZero2.Clear();
                        SectionNm_tEdit.Clear();
                        return true;
                    }

                    if (sectionCd == "00")
                    {
                        // 全社共通のメッセージ変更
                        msg = "入力されたコードのSCM納期設定情報が既に登録されています。\n　【拠点名称：全社共通】\n編集を行いますか？";
                    }

                    DialogResult res = TMsgDisp.Show(
                        this,                                   // 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_INFO,            // エラーレベル
                        PROGRAM_ID,                             // アセンブリＩＤまたはクラスＩＤ
                        msg,                                    // 表示するメッセージ
                        0,                                      // ステータス値
                        MessageBoxButtons.YesNo);               // 表示するボタン
                    isError = true; // ADD 2011/09/07
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
                                // 拠点コードのクリア
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

        /// <summary>
        /// モード変更処理(得意先別)
        /// </summary>
        private bool ModeChangeProcCustomer()
        {
            // 得意先コード
            int customerCode = tNedit_CustomerCode.GetInt();

            for (int i = 0; i < this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Count; i++)
            {
                if ((string)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[i][CUSTOMERCODE_TITLE] == "")
                {
                    // 空白はSkip
                    continue;
                }

                // データセットと比較
                int dsCustomerCode = int.Parse((string)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[i][CUSTOMERCODE_TITLE]);
                if (customerCode == dsCustomerCode)
                {
                    // 入力コードがデータセットに存在する場合
                    if ((string)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[i][DELETE_DATE] != "")
                    {
                        // 論理削除
                        TMsgDisp.Show(this, 					// 親ウィンドウフォーム
                          emErrorLevel.ERR_LEVEL_INFO,          // エラーレベル
                          PROGRAM_ID,						    // アセンブリＩＤまたはクラスＩＤ
                          "入力されたコードのSCM納期設定情報は既に削除されています。", 			// 表示するメッセージ
                          0, 									// ステータス値
                          MessageBoxButtons.OK);				// 表示するボタン
                        // 得意先コードのクリア
                        tNedit_CustomerCode.Clear();
                        CustomerName_tEdit.Clear();
                        return true;
                    }

                    DialogResult res = TMsgDisp.Show(
                        this,                                   // 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_INFO,            // エラーレベル
                        PROGRAM_ID,                             // アセンブリＩＤまたはクラスＩＤ
                        "入力されたコードのSCM納期設定情報が既に登録されています。\n編集を行いますか？",   // 表示するメッセージ
                        0,                                      // ステータス値
                        MessageBoxButtons.YesNo);               // 表示するボタン
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
                                // 得意先コードのクリア
                                tNedit_CustomerCode.Clear();
                                CustomerName_tEdit.Clear();
                                break;
                            }
                    }
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region -- Control Event --

        /// <summary>
        /// Timer.Tick イベント(Initial_Timer)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note        : 指定された間隔の時間が経過したときに発生します。
        ///                   この処理は、システムが提供するスレッド プール
        ///	                  スレッドで実行されます。</br>
        /// <br></br>
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
        /// <br></br>
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

                SCMDeliDateSt newSCMDeliDateSt = new SCMDeliDateSt();

                // クローン作成
                this._scmDeliDateStClone = newSCMDeliDateSt.Clone();
                ScreenToSCMDeliDateSt(ref this._scmDeliDateStClone);

                // _GridIndexバッファ保持
                this._indexBuf = this._dataIndex;

                // 画面入力許可制御処理
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
        }

        /// <summary>
        /// Control.Click イベント(Cancel_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 閉じるボタンコントロールがクリックされたときに発生します。</br>
        /// <br></br>
        /// </remarks>
        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            // 削除モード・参照モード以外の場合は保存確認処理を行う
            if (this.Mode_Label.Text != DELETE_MODE)
            {
                // 現在の画面情報を取得する
                SCMDeliDateSt compareSCMDeliDateSt = new SCMDeliDateSt();
                compareSCMDeliDateSt = this._scmDeliDateStClone.Clone();
                ScreenToSCMDeliDateSt(ref compareSCMDeliDateSt);

                // 最初に取得した画面情報と比較
                if (!(this._scmDeliDateStClone.Equals(compareSCMDeliDateSt)))
                {
                    // 画面情報が変更されていた場合は、保存確認メッセージを表示する
                    // 保存確認
                    DialogResult res = TMsgDisp.Show(
                        this, 								// 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_SAVECONFIRM, // エラーレベル
                        PROGRAM_ID, 						// アセンブリＩＤまたはクラスＩＤ
                        null, 								// 表示するメッセージ
                        0, 									// ステータス値
                        MessageBoxButtons.YesNoCancel);	    // 表示するボタン
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
                                // 新規モードからモード変更対応
                                if (_modeFlg)
                                {
                                    tEdit_SectionCodeAllowZero2.Focus();
                                    _modeFlg = false;
                                }
                                else
                                {
                                    this.Cancel_Button.Focus();
                                }
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
        /// <br></br>
        /// </remarks>
        private void tRetKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null)
            {
                return;
            }

            // 新規モードからモード変更対応
            _modeFlg = false;

            switch (e.PrevCtrl.Name)
            {
                //case "tEdit_SectionCodeAllowZero": //DEL 2011/09/07
                case "tEdit_SectionCodeAllowZero2": //ADD 2011/09/07
                    {
                        if (e.NextCtrl.Name == "Cancel_Button")
                        {
                            // 遷移先が閉じるボタン
                            _modeFlg = true;
                        }
                        else if (e.NextCtrl.Name == "Renewal_Button")
                        {
                            // 最新情報ボタンは更新チェックから外す
                            ;
                        }
                        else if (this.DataIndex < 0)
                        {
                            if (ModeChangeProcSection())
                            {
                                e.NextCtrl = tEdit_SectionCodeAllowZero2;
                            }
                        }
                        break;
                    }
                case "tNedit_CustomerCode":
                    {
                        if (e.NextCtrl.Name == "Cancel_Button")
                        {
                            // 遷移先が閉じるボタン
                            _modeFlg = true;
                        }
                        else if (e.NextCtrl.Name == "Renewal_Button")
                        {
                            // 最新情報ボタンは更新チェックから外す
                            ;
                        }
                        else if (this.DataIndex < 0)
                        {
                            if (ModeChangeProcCustomer())
                            {
                                e.NextCtrl = tNedit_CustomerCode;
                            }
                        }
                        break;
                    }
                case "Renewal_Button":
                    {
                        // 最新情報ボタンからの遷移時、更新チェックを追加
                        if (e.NextCtrl.Name == "Cancel_Button")
                        {
                            // 遷移先が閉じるボタン
                            _modeFlg = true;
                        }
                        //else if (e.NextCtrl.Name == "tEdit_SectionCodeAllowZero") // DEL 2011/09/07
                        else if (e.NextCtrl.Name == "tEdit_SectionCodeAllowZero2") // ADD 2011/09/07
                        {
                            ;
                        }
                        else if (e.NextCtrl.Name == "tNedit_CustomerCode")
                        {
                            ;
                        }
                        else if (this._dataIndex < 0)
                        {
                            if ((SetKind_tComboEditor.SelectedIndex == 0) && (ModeChangeProcSection()))
                            {
                                e.NextCtrl = tEdit_SectionCodeAllowZero2;
                            }
                            else if ((SetKind_tComboEditor.SelectedIndex == 1) && (ModeChangeProcCustomer()))
                            {
                                e.NextCtrl = tNedit_CustomerCode;
                            }
                        }
                        break;
                    }
                // 2011/01/06 Add >>>
                // UPD 2015/02/10 豊沢 SCM高速化 回答納期区分対応 ------------------------------------------>>>>>
                //case "tEdit_AnswerDelivDate6":
                case "tComboEditor_AnsDelivDateDiv6":
                    // UPD 2015/02/10 豊沢 SCM高速化 回答納期区分対応 ------------------------------------------<<<<<
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Enter:
                                    {
                                        // タブの切替
                                        this.ultraTabControl1.ActiveTab = this.ultraTabControl1.Tabs["Stock"];
                                        this.ultraTabControl1.SelectedTab = this.ultraTabControl1.ActiveTab;
                                        e.NextCtrl = tNedit_AnswerDeadTime1Stc_HH;
                                        this.tNedit_AnswerDeadTime1Stc_HH.SelectAll();
                                    }
                                    break;
                            }
                        }
                        break;
                    }
                case "tNedit_AnswerDeadTime1Stc_HH":
                    {
                        if (e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Enter:
                                    {
                                        // タブの切替
                                        this.ultraTabControl1.ActiveTab = this.ultraTabControl1.Tabs["Order"];
                                        this.ultraTabControl1.SelectedTab = this.ultraTabControl1.ActiveTab;
                                        // UPD 2015/02/16 豊沢 SCM高速化 システム障害No224対応 ------------------------------------------>>>>>
                                        //e.NextCtrl = tEdit_AnswerDelivDate6;
                                        e.NextCtrl = tComboEditor_AnsDelivDateDiv6;
                                        // UPD 2015/02/16 豊沢 SCM高速化 システム障害No224対応 ------------------------------------------<<<<<
                                    }
                                    break;
                            }
                        }
                        break;
                    }
                // ----- ADD 2011/09/07 ---------->>>>>
                case "SetKind_tComboEditor":
                    {
                        switch (e.Key)
                        {
                            case Keys.Down:
                                {
                                    e.NextCtrl = tEdit_SectionCodeAllowZero2;
                                }
                                break;
                        }
                        break;
                    }
                // ----- ADD 2011/09/07 ----------<<<<<
                // 2011/01/06 Add <<<
            }
        }

        /// <summary>
        /// 拠点コードガイドボタンクリック処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : ガイド表示処理</br>
        /// <br></br>
        /// </remarks>
        private void SectionGd_ultraButton_Click(object sender, EventArgs e)
        {
            SecInfoSetAcs secInfoSetAcs = new SecInfoSetAcs();
            SecInfoSet secInfoSet = new SecInfoSet();

            try
            {
                this.Cursor = Cursors.WaitCursor;

                int status = secInfoSetAcs.ExecuteGuid(this._enterpriseCode, false, out secInfoSet);
                if (status != 0)
                {
                    ((Control)sender).Tag = GeneralGuideUIController.CAN_FOCUS;
                    return;
                }

                // 取得データ表示
                this.tEdit_SectionCodeAllowZero2.DataText = secInfoSet.SectionCode.Trim();
                this.SectionNm_tEdit.DataText = secInfoSet.SectionGuideNm;

                // 新規モードからモード変更対応
                if (this.DataIndex < 0)
                {
                    if (ModeChangeProcSection())
                    {
                        ((Control)sender).Tag = GeneralGuideUIController.CAN_FOCUS;
                    }
                }
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
        /// <br></br>
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
        /// <br></br>
        /// </remarks>
        private void Delete_Button_Click(object sender, EventArgs e)
        {
            // 完全削除確認
            DialogResult result = TMsgDisp.Show(
                this, 								// 親ウィンドウフォーム
                emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
                PROGRAM_ID, 						// アセンブリＩＤまたはクラスＩＤ
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
        /// <br></br>
        /// </remarks>
        private void tEdit_SectionCode_Leave(object sender, EventArgs e)
        {
            // 拠点コード入力あり？
            if (this.tEdit_SectionCodeAllowZero2.Text != "")
            {
                // 拠点コード名称設定
                this.SectionNm_tEdit.Text = GetSectionName(this.tEdit_SectionCodeAllowZero2.Text.Trim());

                if (SectionUtil.IsAllSection(this.tEdit_SectionCodeAllowZero2.Text))
                {
                    this.SectionNm_tEdit.Text = SectionUtil.ALL_SECTION_NAME;
                }
                this.tEdit_SectionCodeAllowZero2.Text = tEdit_SectionCodeAllowZero2.Text.PadLeft(2, '0'); // ADD 2011/09/07
                
            }
            else
            {
                // uiSetControlが"00"に補正するので、拠点名称は全社共通を設定
                //this.SectionNm_tEdit.Text = SectionUtil.ALL_SECTION_NAME; // DEL 2011/09/07
            }
        }

        /// <summary>
        /// Form.Load イベント()
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : フォームがロードされた時に発生します。</br>
        /// <br></br>
        /// </remarks>
        private void PMSCM09030UA_Load(object sender, EventArgs e)
        {
            // アイコンリソース管理クラスを使用して、アイコンを表示する
            ImageList imageList24 = IconResourceManagement.ImageList24;
            ImageList imageList16 = IconResourceManagement.ImageList16;

            this.Ok_Button.ImageList = imageList24;
            this.Renewal_Button.ImageList = imageList16;
            this.Cancel_Button.ImageList = imageList24;   
            this.Revive_Button.ImageList = imageList24;
            this.Delete_Button.ImageList = imageList24;
            this.Ok_Button.Appearance.Image = Size24_Index.SAVE;         // 保存ボタン
            this.Renewal_Button.Appearance.Image = Size16_Index.RENEWAL;
            this.Cancel_Button.Appearance.Image = Size24_Index.CLOSE;    // 閉じるボタン
            this.Revive_Button.Appearance.Image = Size24_Index.REVIVAL;	 // 復活ボタン
            this.Delete_Button.Appearance.Image = Size24_Index.DELETE;	 // 完全削除ボタン

            this.SectionGd_ultraButton.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.CustomerGd_ultraButton.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];

            // 2011/05/27 Del >>>
            //// 2011/01/06 Add >>>
            //this.tComboEditor_EntStckAnsDeliDtDiv.Items.Clear();
            //this.tComboEditor_EntStckAnsDeliDtDiv.Items.Add(ENTSTCKANSDELIDTDIVNAME0);
            //this.tComboEditor_EntStckAnsDeliDtDiv.Items.Add(ENTSTCKANSDELIDTDIVNAME1);
            //this.tComboEditor_EntStckAnsDeliDtDiv.Items.Add(ENTSTCKANSDELIDTDIVNAME2);
            //this.tComboEditor_EntStckAnsDeliDtDiv.SelectedIndex = 0;
            //this.tEdit_EntStckAnsDeliDate.Enabled = false;
            //// 2011/01/06 Add <<<
            // 2011/05/27 Del <<<

            // 2011/05/27 Add >>>
            this.tComboEditor_EntStckAnsDeliDtDiv.Items.Clear();
            Infragistics.Win.ValueListItem itemList = new Infragistics.Win.ValueListItem();
            itemList.DisplayText = ENTSTCKANSDELIDTDIVNAME0;
            itemList.DataValue = 0;
            this.tComboEditor_EntStckAnsDeliDtDiv.Items.Add(itemList);

            itemList = new Infragistics.Win.ValueListItem();
            itemList.DisplayText = ENTSTCKANSDELIDTDIVNAME2;
            itemList.DataValue = 2;
            this.tComboEditor_EntStckAnsDeliDtDiv.Items.Add(itemList);

            this.tComboEditor_EntStckAnsDeliDtDiv.SelectedIndex = 0;
            this.tEdit_EntStckAnsDeliDate.Enabled = false;
            // 2011/05/27 Add <<<

            // 2011/10/11 Add >>>
            this.tComboEditor_PriStckAnsDeliDtDiv.Items.Clear();
            Infragistics.Win.ValueListItem itemList2 = new Infragistics.Win.ValueListItem();
            itemList2.DisplayText = PRISTCKANSDELIDTDIVNAME0;
            itemList2.DataValue = 0;
            this.tComboEditor_PriStckAnsDeliDtDiv.Items.Add(itemList2);

            itemList2 = new Infragistics.Win.ValueListItem();
            itemList2.DisplayText = PRISTCKANSDELIDTDIVNAME1;
            itemList2.DataValue = 1;
            this.tComboEditor_PriStckAnsDeliDtDiv.Items.Add(itemList2);

            this.tComboEditor_PriStckAnsDeliDtDiv.SelectedIndex = 0;
            this.tEdit_PriStckAnsDeliDate.Enabled = false;
            // 2011/10/11 Add <<<

            // ADD 2015/02/10 豊沢 SCM高速化 回答納期区分対応 ------------------------------------------>>>>>
            // 起動時の初期値は未設定を選択状態で変更不可にする
            // 委託在庫回答納期区分（在庫）
            this.tComboEditor_EntStcAnsDelDtStcDiv.SelectedIndex = 0;
            this.tComboEditor_EntStcAnsDelDtStcDiv.Enabled = false;
            // 委託在庫回答納期区分（在庫不足）
            this.tComboEditor_EntStcAnsDelDtWioDiv.SelectedIndex = 0;
            this.tComboEditor_EntStcAnsDelDtWioDiv.Enabled = false;
            // 委託在庫回答納期区分（在庫数無し）
            this.tComboEditor_EntStcAnsDelDtShoDiv.SelectedIndex = 0;
            this.tComboEditor_EntStcAnsDelDtShoDiv.Enabled = false;
            // 参照在庫回答納期区分（在庫）
            this.tComboEditor_PriStcAnsDelDtStcDiv.SelectedIndex = 0;
            this.tComboEditor_PriStcAnsDelDtStcDiv.Enabled = false;
            // 参照在庫回答納期区分（在庫不足）
            this.tComboEditor_PriStcAnsDelDtWioDiv.SelectedIndex = 0;
            this.tComboEditor_PriStcAnsDelDtWioDiv.Enabled = false;
            // 参照在庫回答納期区分（在庫数無し）
            this.tComboEditor_PriStcAnsDelDtShoDiv.SelectedIndex = 0;
            this.tComboEditor_PriStcAnsDelDtShoDiv.Enabled = false;
            // ADD 2015/02/10 豊沢 SCM高速化 回答納期区分対応 ------------------------------------------<<<<<

            // 画面初期化
            ScreenInitialSetting();

            // 拠点ガイドのフォーカス制御の開始
            SectionGuideController.StartControl();

            // 得意先ガイドのフォーカス制御の開始
            CustomerGuideController.StartControl();
        }

        /// <summary>
        /// Form.Closing イベント(PMSCM09030UA)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">キャンセルできるイベントのデータを提供するクラス</param>
        /// <remarks>
        /// <br>Note       : フォームを閉じる前に、ユーザーがフォームを閉じようとしたときに発生します。</br>
        /// <br></br>
        /// </remarks>
        private void PMSCM09030UA_FormClosing(object sender, FormClosingEventArgs e)
        {
            // チェック用クローン初期化
            this._scmDeliDateStClone = null;

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
        /// Form.VisibleChanged イベント(PMSCM09030UA)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : フォームの表示状態が変わったときに発生します。</br>
        /// <br></br>
        /// </remarks>
        private void PMSCM09030UA_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible == false)
            {
                this.Owner.Activate();
                return;
            }

            // _GridIndexバッファ（メインフレーム最小化対応）
            // ターゲットレコード(Index)が変わっていなかった場合以下の処理をキャンセルする
            if (this._indexBuf == this._dataIndex)
            {
                return;
            }

            // ちらつき防止の為
            this.Enabled = false;

            this.Initial_Timer.Enabled = true;

            // 画面クリア
            ScreenClear();
        }

        /// <summary>
        /// 得意先コードガイドボタンクリック処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : ガイド表示処理</br>
        /// <br></br>
        /// </remarks>
        private void CustomerGd_ultraButton_Click(object sender, EventArgs e)
        {
            string previousText = this.tNedit_CustomerCode.Text.Trim();
            try
            {
                this.Cursor = Cursors.WaitCursor;

                PMKHN04005UA customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_CUSTOMER_ONLY, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY);
                customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.CustomerSearchForm_CustomerSelect);
                customerSearchForm.ShowDialog(this);

                if (this.tNedit_CustomerCode.Text.Trim().Equals(previousText))
                {
                    ((Control)sender).Tag = GeneralGuideUIController.CAN_FOCUS;
                }

                // 新規モードからモード変更対応
                if (this.DataIndex < 0)
                {
                    if (ModeChangeProcCustomer())
                    {
                        ((Control)sender).Tag = GeneralGuideUIController.CAN_FOCUS;
                    }
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// 得意先選択時発生イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="customerSearchRet">得意先検索戻り値クラス</param>
        /// <remarks>
        /// <br>Note　　　 : 得意先ガイドボタンコントロールがクリックされたときに発生します。</br>
        /// <br></br>
        /// </remarks>
        private void CustomerSearchForm_CustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        {
            if (customerSearchRet == null)
            {
                return;
            }

            // 得意先コード
            this.tNedit_CustomerCode.DataText = customerSearchRet.CustomerCode.ToString();
            
            // 得意先名称
            this.CustomerName_tEdit.DataText = customerSearchRet.Snm.Trim();
        }

        /// <summary>
        /// 設定種別変更イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　 : 設定種別が変更されたときに発生します。</br>
        /// <br></br>
        /// </remarks>
        private void SetKind_tComboEditor_ValueChanged(object sender, EventArgs e)
        {
            // 拠点単位？
            if (this.SetKind_tComboEditor.Text == SETKIND_SECTION)
            {
                // 拠点表示
                this.SectionCode_Title_Label.Visible = true;
                this.tEdit_SectionCodeAllowZero2.Visible = true;
                this.SectionGd_ultraButton.Visible = true;
                this.SectionNm_tEdit.Visible = true;
                this.SectionNm_Label.Visible = true;

                // 得意先非表示
                this.Customer_Label.Visible = false;
                this.tNedit_CustomerCode.Visible = false;
                this.CustomerGd_ultraButton.Visible = false;
                this.CustomerName_tEdit.Visible = false;
            }
            else
            {
                // 拠点非表示
                this.SectionCode_Title_Label.Visible = false;
                this.tEdit_SectionCodeAllowZero2.Visible = false;
                this.SectionGd_ultraButton.Visible = false;
                this.SectionNm_tEdit.Visible = false;
                this.SectionNm_Label.Visible = false;

                // 得意先非表示
                this.Customer_Label.Visible = true;
                this.tNedit_CustomerCode.Visible = true;
                this.CustomerGd_ultraButton.Visible = true;
                this.CustomerName_tEdit.Visible = true;
                this.Customer_Label.Top = this.SectionCode_Title_Label.Top;
                this.tNedit_CustomerCode.Top = this.SectionCode_Title_Label.Top;
                this.CustomerGd_ultraButton.Top = this.SectionCode_Title_Label.Top;
                this.CustomerName_tEdit.Top = this.SectionCode_Title_Label.Top;
            }
        }

        /// <summary>
        /// Leave イベント(tNedit_CustomerCode)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　  : 得意先コードからフォーカスが離れたときに発生します。</br>
        /// <br></br>
        /// </remarks>
        private void tNedit_CustomerCode_Leave(object sender, EventArgs e)
        {
            // 得意先コードが未入力の場合
            if (this.tNedit_CustomerCode.DataText.Trim() == "")
            {
                this.CustomerName_tEdit.DataText = "";
                return;
            }

            // 得意先コード取得
            int customerCode = this.tNedit_CustomerCode.GetInt();

            // 得意先名称取得
            this.CustomerName_tEdit.DataText = GetCustomerName(customerCode);
        }

        /// <summary>
        /// 最新情報ボタンクリック
        /// </summary>
        private void Renewal_Button_Click(object sender, EventArgs e)
        {
            this._secInfoAcs.ResetSectionInfo();
            this.GetCacheData();

            TMsgDisp.Show(this, 								// 親ウィンドウフォーム
                          emErrorLevel.ERR_LEVEL_INFO,          // エラーレベル
                          PROGRAM_ID,						    // アセンブリＩＤまたはクラスＩＤ
                          "最新情報を取得しました。", 			// 表示するメッセージ
                          0, 									// ステータス値
                          MessageBoxButtons.OK);				// 表示するボタン
        }

        /// <summary>
        /// AfterEnterEditMode イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　 : コントロールが編集モードに入った後に発生します。</br>
        /// <br></br>
        /// </remarks>
        private void tNedit_AnswerDeadTime_AfterEnterEditMode(object sender, EventArgs e)
        {
            TNedit tNedit = sender as TNedit;
            int time = tNedit.GetInt();

            // ゼロ詰め削除
            if (time != 0)
            {
                tNedit.DataText = time.ToString();
            }
            else if (tNedit.DataText == "00")
            {
                tNedit.DataText = "0";
            }
        }
        #endregion

        // 2011/01/06 Add >>>
        /// <summary>
        /// ValueChanged イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　 : 委託在庫回答納期区分の値が変更された時に発生します。</br>
        /// <br></br>
        /// </remarks>
        private void tComboEditor_EntStckAnsDeliDtDiv_ValueChanged(object sender, EventArgs e)
        {
            // 2011/05/27 >>>
            //if (this.tComboEditor_EntStckAnsDeliDtDiv.SelectedIndex == 2)
            if (Convert.ToInt32(this.tComboEditor_EntStckAnsDeliDtDiv.SelectedItem.DataValue) == 2)
            // 2011/05/27 <<<
            {
                this.tEdit_EntStckAnsDeliDate.Enabled = true;
                // ADD 2012/10/31 T.Yoshioka 2012/11/14配信 システムテスト障害№17 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                this.tEdit_EntStckAnsDeliDateShortage.Enabled = true;
                this.tEdit_EntStckAnsDeliDateNoStc.Enabled = true;
                // ADD 2012/10/31 T.Yoshioka 2012/11/14配信 システムテスト障害№17 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                // ADD 2015/02/10 豊沢 SCM高速化 回答納期区分対応 ------------------------------------------>>>>>
                // 委託在庫回答納期区分（在庫）を変更可にする
                this.tComboEditor_EntStcAnsDelDtStcDiv.Enabled = true;
                // 委託在庫回答納期区分（在庫不足）を変更可にする
                this.tComboEditor_EntStcAnsDelDtWioDiv.Enabled = true;
                // 委託在庫回答納期区分（在庫数無し）を変更可にする
                this.tComboEditor_EntStcAnsDelDtShoDiv.Enabled = true;
                // ADD 2015/02/10 豊沢 SCM高速化 回答納期区分対応 ------------------------------------------<<<<<
            }
            else
            {
                this.tEdit_EntStckAnsDeliDate.Enabled = false;
                // ADD 2012/10/31 T.Yoshioka 2012/11/14配信 システムテスト障害№17 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                this.tEdit_EntStckAnsDeliDateShortage.Enabled = false;
                this.tEdit_EntStckAnsDeliDateNoStc.Enabled = false;
                // ADD 2012/10/31 T.Yoshioka 2012/11/14配信 システムテスト障害№17 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                // ADD 2015/02/10 豊沢 SCM高速化 回答納期区分対応 ------------------------------------------>>>>>
                // 委託在庫回答納期区分（在庫）を変更不可にする
                this.tComboEditor_EntStcAnsDelDtStcDiv.Enabled = false;
                // 委託在庫回答納期区分（在庫不足）を変更不可にする
                this.tComboEditor_EntStcAnsDelDtWioDiv.Enabled = false;
                // 委託在庫回答納期区分（在庫数無し）を変更不可にする
                this.tComboEditor_EntStcAnsDelDtShoDiv.Enabled = false;
                // ADD 2015/02/10 豊沢 SCM高速化 回答納期区分対応 ------------------------------------------<<<<<
            }
        }
        // 2011/01/06 Add <<<

        /// <summary>
        /// ValueChanged イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　 : 優先在庫回答納期区分の値が変更された時に発生します。</br>
        /// <br></br>
        /// </remarks>
        private void tComboEditor_PriStckAnsDeliDtDiv_ValueChanged_1(object sender, EventArgs e)
        {
            if (Convert.ToInt32(this.tComboEditor_PriStckAnsDeliDtDiv.SelectedItem.DataValue) == 1)
            {
                this.tEdit_PriStckAnsDeliDate.Enabled = true;
                // ADD 2012/10/31 T.Yoshioka 2012/11/14配信 システムテスト障害№17 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                tEdit_PriStckAnsDeliDateShortage.Enabled = true;
                tEdit_PriStckAnsDeliDateNoStc.Enabled = true;
                // ADD 2012/10/31 T.Yoshioka 2012/11/14配信 システムテスト障害№17 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                // ADD 2015/02/10 豊沢 SCM高速化 回答納期区分対応 ------------------------------------------>>>>>
                // 参照在庫回答納期区分（在庫）を変更可にする
                this.tComboEditor_PriStcAnsDelDtStcDiv.Enabled = true;
                // 参照在庫回答納期区分（在庫不足）を変更可にする
                this.tComboEditor_PriStcAnsDelDtWioDiv.Enabled = true;
                // 参照在庫回答納期区分（在庫数無し）を変更可にする
                this.tComboEditor_PriStcAnsDelDtShoDiv.Enabled = true;
                // ADD 2015/02/10 豊沢 SCM高速化 回答納期区分対応 ------------------------------------------<<<<<
            }
            else
            {
                this.tEdit_PriStckAnsDeliDate.Enabled = false;
                // ADD 2012/10/31 T.Yoshioka 2012/11/14配信 システムテスト障害№17 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                tEdit_PriStckAnsDeliDateShortage.Enabled = false;
                tEdit_PriStckAnsDeliDateNoStc.Enabled = false;
                // ADD 2012/10/31 T.Yoshioka 2012/11/14配信 システムテスト障害№17 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                // ADD 2015/02/10 豊沢 SCM高速化 回答納期区分対応 ------------------------------------------>>>>>
                // 参照在庫回答納期区分（在庫）を変更不可にする
                this.tComboEditor_PriStcAnsDelDtStcDiv.Enabled = false;
                // 参照在庫回答納期区分（在庫不足）を変更不可にする
                this.tComboEditor_PriStcAnsDelDtWioDiv.Enabled = false;
                // 参照在庫回答納期区分（在庫数無し）を変更不可にする
                this.tComboEditor_PriStcAnsDelDtShoDiv.Enabled = false;
                // ADD 2015/02/10 豊沢 SCM高速化 回答納期区分対応 ------------------------------------------<<<<<
            }
        }

        // ADD 2015/02/10 豊沢 SCM高速化 回答納期区分対応 ------------------------------------------>>>>>
        /// <summary>
        /// 納品区分表示名取得
        /// </summary>
        /// <param name="andDeliDateDiv">納品区分設定値</param>
        /// <remarks>
        /// <br>Note　　　 : 納品区分表示名を取得します。</br>
        /// <br></br>
        /// </remarks>
        private string GetAnsDeliDateDivName(Int16 andDeliDateDiv)
        {
            string retValue = string.Empty;
            switch (andDeliDateDiv)
            {
                case ANSDELIDATEDIV_VALUE_NONE:
                    retValue = ANSDELIDATEDIV_NAME_NONE;
                    break;
                case ANSDELIDATEDIV_VALUE_TODAY:
                    retValue = ANSDELIDATEDIV_NAME_TODAY;
                    break;
                case ANSDELIDATEDIV_VALUE_1DAY:
                    retValue = ANSDELIDATEDIV_NAME_1DAY;
                    break;
                case ANSDELIDATEDIV_VALUE_2DAY:
                    retValue = ANSDELIDATEDIV_NAME_2DAY;
                    break;
                case ANSDELIDATEDIV_VALUE_WEEK:
                    retValue = ANSDELIDATEDIV_NAME_WEEK;
                    break;
                case ANSDELIDATEDIV_VALUE_CONFIRM:
                    retValue = ANSDELIDATEDIV_NAME_CONFIRM;
                    break;
                default:
                    break;
            }
            return retValue;
        }
        // ADD 2015/02/10 豊沢 SCM高速化 回答納期区分対応 ------------------------------------------<<<<<
    }
}