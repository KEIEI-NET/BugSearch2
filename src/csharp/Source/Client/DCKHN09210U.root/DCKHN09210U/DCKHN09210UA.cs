//**********************************************************************//
// システム         ：.NSシリーズ
// プログラム名称   ：売上全体設定マスタ
// プログラム概要   ：売上全体設定の登録・変更・削除を行う
// ---------------------------------------------------------------------//
//					Copyright(c) 2008 Broadleaf Co.,Ltd.				//
// =====================================================================//
// 履歴
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30415 柴田 倫幸
// 修正日    2008/06/09     修正内容：Partsman用に修正
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30415 柴田 倫幸
// 修正日    2008/07/22     修正内容：項目削除の為、修正
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30434 工藤 恵優
// 修正日    2008/09/18     修正内容：不具合対応[5404]
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30462 行澤 仁美
// 修正日    2008/10/09     修正内容：バグ修正
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30462 行澤 仁美
// 修正日    2008/11/13     修正内容：バグ修正
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30413 犬飼
// 修正日    2009/04/07     修正内容：Mantis【12587】最新情報取得と更新チェックの判定を修正
// ---------------------------------------------------------------------//
// 管理番号  10504551-00    作成担当：21024 佐々木
// 修正日    2009/09/29     修正内容：項目名の変更「ユーザー代替区分」→「代替区分」(MANTIS【0014347】)
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：朱俊成
// 修正日    2009/10/19     修正内容：PM.NS-3-A・保守依頼②
//                                    表示区分プロセスを追加
// ---------------------------------------------------------------------//
// 管理番号  10600008-00    作成担当：李侠
// 修正日    2010/01/29     修正内容：PM1003・四次改良
//                                    受注数入力を追加
// ---------------------------------------------------------------------//
// 管理番号  10600008-00    作成担当：姜凱
// 修正日    2010/04/30     修正内容：PM1007D・自由検索
//                                    自由検索部品自動登録区分を追加
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：王海立
// 修正日    2010/05/04     修正内容：PM1007・6次改良
//                                    発行者チェック区分、入力倉庫チェック区分を追加
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30434 工藤
// 修正日    2010/05/14     修正内容：品名表示対応：品名表示区分の詳細設定を追加
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：楊明俊
// 修正日    2010/08/04     修正内容：PM1012
//                                    小数点表示区分を追加
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：田建委
// 修正日    2010/12/03     修正内容：障害対応12月
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：22008 長内数馬
// 修正日    2011/06/07     修正内容：販売区分表示区分を追加
// ---------------------------------------------------------------------//
// 管理番号  10704766-00    作成担当：王飛３
// 修正日    2011/09/07     修正内容：障害報告 #24169　拠点設定を行おうと拠点ガイドをすると全社共通の編集を行おうとしてしまう。
//　　　　　　　　　　　　　　　　　　　　　　　　　　 拠点コードと拠点ガイドのフォーカス移動はメッセージ表示を行わないように修正
// ---------------------------------------------------------------------//
// 管理番号  10801804-00    作成担当：福田康夫
// 修正日    2012/04/23     修正内容：貸出仕入区分を追加
// ---------------------------------------------------------------------//
// 管理番号  10806792-00    作成担当：脇田 靖之
// 修正日    2012/12/27     修正内容：自社品番印字対応
// ---------------------------------------------------------------------//
// 管理番号  10806792-00    作成担当：西 毅 						
// 修 正 日  2013/01/09     修正内容：自社品番印字対応デフォルト値の変更
//----------------------------------------------------------------------//
// 管理番号  10806793-00    作成担当：FSI福原 一樹
// 修正日    2013/01/15     修正内容：仕入返品予定機能区分を追加
// ---------------------------------------------------------------------//					
// 管理番号  10806792-00    作成担当：脇田 靖之
// 修正日    2013/01/16     修正内容：自社品番印字対応仕様変更対応
// ---------------------------------------------------------------------//
// 管理番号  10801804-00    作成担当：脇田 靖之
// 修正日    2013/01/16     修正内容：削除済みデータの表示時に品名表示区分の詳細設定ボタンが活性になる不具合を修正
// ---------------------------------------------------------------------//
// 管理番号  10806793-00    作成担当：cheq
// 修正日    2013/01/21     修正内容：2013/03/13配信分 Redmine#33797
//                                    自動入金備考区分を追加
// ---------------------------------------------------------------------//
// 管理番号  10806793-00    作成担当：脇田 靖之
// 修正日    2013/02/05     修正内容：ＢＬコード０対応
// ---------------------------------------------------------------------//
// 管理番号  11370030-00    作成担当：譚洪
// 修正日    2017/04/13     修正内容：売上伝票入力画面の仕入担当者セット方法を変更
//                                    仕入担当参照区分の追加
// ---------------------------------------------------------------------//


using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Reflection;                        // ADD 2008/09/18 不具合対応[5404]
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;           // ADD 2012/12/27 Y.Wakita

using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Controller.Util;    // ADD 2008/09/18 不具合対応[5404]
using Broadleaf.Application.UIData;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;

using Infragistics.Win.Misc;                    // ADD 2008/09/18 不具合対応[5401]
using Infragistics.Win.UltraWinTabControl;      // ADD 2008/09/18 不具合対応[5401]

namespace Broadleaf.Windows.Forms
{
    using GuideUIControllerType = GuideUIController<TEdit, UltraButton, UltraTabControl>;   // ADD 2008/09/18 不具合対応[5401]

	/// <summary>
	/// 売上全体設定フォームクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 売上全体設定の設定を行います。</br>
	/// <br>Programmer : 30167 上野　弘貴</br>
	/// <br>Date       : 2007.12.06</br>
	/// <br>Update Note: 2008.02.18 30167 上野　弘貴</br>
	/// <br>			 自動入金関連項目追加（金額種別区分マスタデータ取得）</br>
	/// <br>Update Note: 2008.02.26 30167 上野　弘貴</br>
	/// <br>			 項目追加（入出荷数区分２, 値引名称）</br>
    /// <br>Programmer : 30415 柴田 倫幸</br>
    /// <br>Date       : 2008/06/09</br>
    /// <br>Programmer : 30415 柴田 倫幸</br>
    /// <br>Date       : 2008/07/22 項目削除の為、修正</br>
    /// <br>UpdateNote : 2008/10/09 30462 行澤 仁美　バグ修正</br>
    /// <br>UpdateNote : 2008/11/13 30462 行澤 仁美　バグ修正</br>
    /// <br>UpdateNote : 2009/09/29 21024 佐々木 健</br>
    /// <br>　　　　　 　項目名変更　ユーザー代替区分→代替区分(MANTIS【0014347】)</br>
    /// <br></br>
    /// <br>Update Note: 2009/10/19 朱俊成</br>
    /// <br>             PM.NS-3-A・保守依頼②</br>
    /// <br>             表示区分プロセスを追加</br>
    /// <br>Update Note: 2010/01/29 李侠</br>
    /// <br>             PM1003・四次改良</br>
    /// <br>             受注数入力を追加</br>																						
    /// <br>Update Note: 2010/05/04 王海立</br>
    /// <br>             PM1007・6次改良</br>
    /// <br>             発行者チェック区分、入力倉庫チェック区分を追加</br>
    /// <br>Update Note: 2010/04/30 姜凱</br>																						
    /// <br>             PM1007D・自由検索</br>																						
    /// <br>             自由検索部品自動登録区分を追加</br>
    /// <br>Update Note: 2010/08/04 楊明俊</br>
    /// <br>             PM1012</br>
    /// <br>             小数点表示区分を追加</br>
    /// <br>Update Note: 2010/12/03 田建委</br>
    /// <br>             障害対応12月</br>
    /// <br>Update Note: 2011/06/07 長内数馬</br>
    /// <br>             販売区分表示区分を追加</br>
    /// <br>UpdateNote : 2011/09/07 王飛３</br>
    /// <br>        	 ・障害報告 #24169</br>
    /// <br>Update Note: 2012/04/23 福田康夫
    /// <br>             貸出仕入区分を追加</br>
    /// <br>Update Note: 2013/01/15 FSI福原 一樹</br>
    /// <br>             仕入返品予定機能区分を追加</br>
    /// <br>Update Note: 2013/01/21 cheq</br>
    /// <br>管理番号   : 10806793-00 2013/03/13配信分</br>
    /// <br>             Redmine#33797 自動入金備考区分を追加</br>
    /// </remarks>
    public partial class DCKHN09210UA : Form, IMasterMaintenanceMultiType
	{
		#region << Constructor >>

		/// <summary>
		/// 全体項目表示設定フォームクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 全体項目表示設定フォームクラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.12.06</br>
		/// </remarks>
		public DCKHN09210UA()
		{
			InitializeComponent();

            // データセット列情報構築処理
            DataSetColumnConstruction();

			// 企業コード取得
			this._enterpriseCode  = LoginInfoAcquisition.EnterpriseCode;

			// 売上全体設定テーブルアクセスクラス
			this._salesTtlStAcs   = new SalesTtlStAcs();

            // 入金入力設定データ系アクセスクラス
            this.depositRelDataAcs = new DepositRelDataAcs();

			// 比較用クローン
			this._salesTtlStClone = null;

            // --- ADD 2008/06/09 -------------------------------->>>>>
            // プロパティ初期値
            this._canClose = false;	                      // 閉じる機能（デフォルトtrue固定）
            this._canDelete = true;		                  // 削除機能
            this._canLogicalDeleteDataExtraction = true;  // 論理削除データ表示機能
            this._canNew = true;		                  // 新規作成機能
            this._canPrint = false;	                      // 印刷機能
            this._canSpecificationSearch = false;	      // 件数指定検索機能
            this._defaultAutoFillToColumn = false;	      // 列サイズ自動調整機能

            // 初期化
            this._dataIndex = -1;
            this._salesTtlStAcs = new SalesTtlStAcs();
            this._secInfoAcs = new SecInfoAcs(1);
            this._logicalDeleteMode = 0;
            this._salesTtlStTable = new Hashtable();

            // _GridIndexバッファ（メインフレーム最小化対応）
            this._indexBuf = -2;
            // --- ADD 2008/06/09 --------------------------------<<<<< 

            // ADD 2008/09/18 不具合対応[5401] ---------->>>>>
            // 拠点ガイドのフォーカス制御
            _sectionGuideController = new GuideUIControllerType(
                this.tEdit_SectionCodeAllowZero2,
                this.SectionGd_ultraButton,
                this.MainTabControl
            );
            // ADD 2008/09/18 不具合対応[5401] ----------<<<<<
		}

		#endregion

		#region << Private Members >>

		private SalesTtlStAcs _salesTtlStAcs;     // 売上全体設定テーブルアクセスクラス
		//private SalesTtlSt    _salesTtlSt;        // 売上全体設定データクラス

		private string        _enterpriseCode;    // 企業コード

		// 比較用クローン
		private SalesTtlSt    _salesTtlStClone;   // 比較用売上全体設定クラス

        // --- ADD 2008/06/09 -------------------------------->>>>>
        private DepositRelDataAcs depositRelDataAcs;  // 入金入力設定データ系アクセスクラス

        private SecInfoAcs _secInfoAcs;           // 拠点マスタアクセスクラス
        private int _logicalDeleteMode;			  // モード
        private Hashtable _salesTtlStTable;		  // 売上全体設定テーブル

        // _GridIndexバッファ（メインフレーム最小化対応）
        private int _indexBuf;

        // プロパティ用
        private bool _canClose;
        private bool _canDelete;
        private bool _canLogicalDeleteDataExtraction;
        private bool _canNew;
        private bool _canPrint;
        private bool _canSpecificationSearch;
        private int _dataIndex;
        private bool _defaultAutoFillToColumn;

        private bool isError = false; // ADD 2011/09/07

        // 2009.03.25 30413 犬飼 新規モードからモード変更対応 >>>>>>START
        // モードフラグ(true：コード、false：コード以外)
        private bool _modeFlg = false;
        // 2009.03.25 30413 犬飼 新規モードからモード変更対応 <<<<<<END

        private const string GUID_TITLE       = "GUID";
        private const string SALESTTLST_TABLE = "SALESTTLST"; // テーブル名

        // 編集モード
        private const string INSERT_MODE = "新規モード";
        private const string UPDATE_MODE = "更新モード";
        private const string DELETE_MODE = "削除モード";

        private const string DELETE_DATE       = "削除日";
        private const string SECTIONCODE_TITLE = "コード";
        // DEL 2008/10/09 不具合対応[6473] ↓
        //private const string SECTIONNAME_TITLE = "拠点名称";
        private const string SECTIONNAME_TITLE = "拠点名";    // ADD 2008/10/09 不具合対応[6473]
        // --- ADD 2008/06/09 --------------------------------<<<<< 

		private const string  HTML_HEADER_TITLE = "設定項目";
		private const string  HTML_HEADER_VALUE = "設定値";
		private const string  HTML_UNREGISTER   = "未設定";

		private const string  CT_PGID			= "DCKHN09210U";
		private const string  CT_PGNM           = "売上全体設定マスタ";

        /// <summary>画面デザイン変更クラス</summary>
        private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();

		//----- ueno add---------- start 2008.02.18
		private int _autoDepoKindCode_tComboEditorValue = -1;	// 自動入金金種コードコンボボックスデータワーク
		//----- ueno add---------- end 2008.02.18

        // ADD 2008/09/26 不具合対応[5409]---------->>>>>
        /// <summary>入力粗利上限チェックの初期値</summary>
        private const double INITIAL_INP_GRS_PROF_CHK_UPPER_VALUE = 70.00;
        /// <summary>入力粗利下限チェックの初期値</summary>
        private const double INITIAL_INP_GRS_PROF_CHK_LOWER_VALUE = 10.00;
        // ADD 2008/09/26 不具合対応[5409]----------<<<<<

        // ADD 2008/09/18 不具合対応[5401] ---------->>>>>
        /// <summary>拠点ガイドの制御オブジェクト</summary>
        private readonly GuideUIControllerType _sectionGuideController;
        /// <summary>
        /// 拠点ガイドの制御オブジェクトを取得します。
        /// </summary>
        /// <value>拠点ガイドの制御オブジェクト</value>
        private GuideUIControllerType SectionGuideController
        {
            get { return _sectionGuideController; }
        }
        // ADD 2008/09/18 不具合対応[5401] ----------<<<<<

		#endregion

		#region << Events >>

        /* --- DEL 2008/06/09 -------------------------------->>>>>
		/// <summary>
		/// 画面非表示イベント
		/// </summary>
		/// <remarks>
		/// 画面が非表示状態になった際に発生します。
		/// </remarks>
		public event MasterMaintenanceSingleTypeUnDisplayingEventHandler UnDisplaying;
           --- DEL 2008/06/09 --------------------------------<<<<< */

        /// <summary>画面非表示イベント</summary>
        /// <remarks>画面が非表示状態になった時に発生します。</remarks>
        public event MasterMaintenanceMultiTypeUnDisplayingEventHandler UnDisplaying;
		# endregion

		#region << Properties >>

        /// <summary>件数指定抽出可能設定プロパティ</summary>
        /// <value>件数指定抽出が可能かどうかの設定を取得します。</value>
        public bool CanSpecificationSearch
        {
            get
            {
                return this._canSpecificationSearch;
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

		/// <summary>
		/// 印刷プロパティ
		/// </summary>
		/// <remarks>
		/// 印刷可能かどうかの設定を取得します。（false固定）
		/// </remarks>
		public bool CanPrint
		{
			get{ return _canPrint; }
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
		/// 画面クローズプロパティ
		/// </summary>
		/// <remarks>
		/// 画面クローズを許可するかどうかの設定を取得または設定します。
		/// falseの場合は、画面を閉じる際、CloseではなくHide(非表示)を実行します。
		/// </remarks>
		public bool CanClose
		{
			get{ return _canClose; }
			set{ _canClose = value; }
		}

		#endregion

		#region << Public Methods >>

        /// <summary>
        /// バインドデータセット取得処理
        /// </summary>
        /// <param name="bindDataSet">グリッド用データセット</param>
        /// <param name="tableName">テーブル名</param>
        /// <remarks>
        /// <br>Note       : グリッドにバインドさせるデータセットを取得します。</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/09</br>
        /// </remarks>
        public void GetBindDataSet(ref DataSet bindDataSet, ref string tableName)
        {
            bindDataSet = this.Bind_DataSet;
            tableName = SALESTTLST_TABLE;
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
        /// <br>Date       : 2008/06/09</br>
        /// </remarks>
        public int Search(ref int totalCnt, int readCnt)
        {
            return SearchSalesTtlSt(ref totalCnt, readCnt);
        }

        /// <summary>
        /// ネクストデータ検索処理
        /// </summary>
        /// <param name="readCnt">抽出対象件数</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 指定件数分のネクストデータを検索します。</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/09</br>
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
        /// <br>Date       : 2008/06/09</br>
        /// </remarks>
        public int Delete()
        {
            return LogicalDelete();
        }

		/// <summary>
		/// 印刷処理
		/// </summary>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 未実装</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.12.06</br>
		/// </remarks>
		public int Print()
		{
			// 印刷アセンブリをロードする（未実装）
			return 0;
		}

        /// <summary>
        /// グリッド列外観情報取得処理
        /// </summary>
        /// <returns>グリッド列外観情報格納Hashtable</returns>
        /// <remarks>
        /// <br>Note       : グリッドの各列の外見を設定するクラスを格納したHashtableを取得します。</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/09</br>
        /// <br>Update Note: 2009/10/19 朱俊成 表示区分プロセスを追加</br>
        /// <br>Update Note: 2010/01/29 李侠　受注数入力を追加</br>
        /// <br>Update Note: 2010/04/30 姜凱 自由検索部品自動登録区分を追加</br>
        /// <br>Update Note: 2010/05/04 王海立 発行者チェック区分、入力倉庫チェック区分を追加</br>
        /// <br>Update Note: 2010/08/04 楊明俊 小数点表示区分を追加</br>
        /// <br>Update Note: 2010/12/03 田建委 障害対応12月</br>
        /// <br>Update Note: 2011/06/07 22008 長内数馬 販売区分表示区分を追加</br>
        /// <br>Update Note: 2012/04/23 管理NO.611 福田康夫 貸出仕入区分を追加</br>
        /// <br>Update Note: 2013/01/15 FSI福原 一樹 仕入返品予定機能区分を追加</br>
        /// <br>Update Note: 2013/01/21 cheq</br>
        /// <br>管理番号   : 10806793-00 2013/03/13配信分</br>
        /// <br>             Redmine#33797 自動入金備考区分を追加</br>
        /// <br>管理番号   : 11370030-00 2017/04/13 譚洪</br>
        /// <br>             Redmine#49283 仕入担当参照区分を追加</br>
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

            // 売上伝票発行区分
            appearanceTable.Add(SalesSlipPrtDiv_Label.Text,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleLeft, "", Color.Black));

            // 出荷伝票発行区分
            appearanceTable.Add(ShipmSlipPrtDiv_Label.Text,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleLeft, "", Color.Black));

            // --- DEL 2008/07/22 -------------------------------->>>>>
            //// ゼロ円印刷区分
            //appearanceTable.Add(ZeroPrtDiv_Label.Text,
            //    new GridColAppearance(MGridColDispType.Both,
            //    ContentAlignment.MiddleLeft, "", Color.Black));
            // --- DEL 2008/07/22 --------------------------------<<<<< 

            // 出荷伝票単価印刷区分
            appearanceTable.Add(ShipmSlipUnPrcPrtDiv_Label.Text,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleLeft, "", Color.Black));

            // --- DEL 2008/07/22 -------------------------------->>>>>
            //// 入出荷数区分
            //appearanceTable.Add(IoGoodsCntDiv_Label.Text,
            //    new GridColAppearance(MGridColDispType.Both,
            //    ContentAlignment.MiddleLeft, "", Color.Black));

            //// 入出荷数区分２
            //appearanceTable.Add(IoGoodsCntDiv2_Label.Text,
            //    new GridColAppearance(MGridColDispType.Both,
            //    ContentAlignment.MiddleLeft, "", Color.Black));

            //// 売上形式初期値
            //appearanceTable.Add(SalesFormalIn_Label.Text,
            //    new GridColAppearance(MGridColDispType.Both,
            //    ContentAlignment.MiddleLeft, "", Color.Black));

            //// 仕入明細確認
            //appearanceTable.Add(StockDetailConf_Label.Text,
            //    new GridColAppearance(MGridColDispType.Both,
            //    ContentAlignment.MiddleLeft, "", Color.Black));
            // --- DEL 2008/07/22 --------------------------------<<<<< 

            // 粗利チェック下限
            appearanceTable.Add(GrsProfitCheckLower_Label.Text,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleRight, "", Color.Black));

            // 粗利チェック適正
            appearanceTable.Add(GrsProfitCheckBest_Label.Text,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleRight, "", Color.Black));

            // 粗利チェック上限
            appearanceTable.Add(GrsProfitCheckUpper_Label.Text,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleRight, "", Color.Black));

            // 粗利チェック下限記号
            appearanceTable.Add(GrsProfitChkLowSign_Label.Text,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleLeft, "", Color.Black));

            // 粗利チェック適正記号
            appearanceTable.Add(GrsProfitChkBestSign_Label.Text,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleLeft, "", Color.Black));

            // 粗利チェック上限記号
            appearanceTable.Add(GrsProfitChkUprSign_Label.Text,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleLeft, "", Color.Black));

            // 粗利チェック最大記号
            appearanceTable.Add(GrsProfitChkMaxSign_Label.Text,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleLeft, "", Color.Black));

            // 売上担当変更区分
            appearanceTable.Add(SalesAgentChngDiv_Label.Text,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleLeft, "", Color.Black));

            // 受注者表示区分
            appearanceTable.Add(AcpOdrAgentDispDiv_Label.Text,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleLeft, "", Color.Black));

            // 伝票備考２表示区分
            appearanceTable.Add(BrSlipNote2DispDiv_Label.Text,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleLeft, "", Color.Black));

            // 明細備考表示区分
            appearanceTable.Add(DtlNoteDispDiv_Label.Text,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleLeft, "", Color.Black));

            // 売価未設定時区分
            appearanceTable.Add(UnPrcNonSettingDiv_Label.Text,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleLeft, "", Color.Black));

            // 見積データ計上残区分
            appearanceTable.Add(EstmateAddUpRemDiv_Label.Text,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleLeft, "", Color.Black));

            // 受注データ計上残区分
            appearanceTable.Add(AcpOdrrAddUpRemDiv_Label.Text,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleLeft, "", Color.Black));

            //// 出荷データ計上残区分 // DEL 2010/12/03
            // 貸出データ計上残区分 // ADD 2010/12/03
            appearanceTable.Add(ShipmAddUpRemDiv_Label.Text,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleLeft, "", Color.Black));

            // 返品時在庫登録区分
            appearanceTable.Add(RetGoodsStockEtyDiv_Label.Text,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleLeft, "", Color.Black));

            // 定価選択区分
            // ----- UPD 2010/12/03 -------------------------->>>>>
            //appearanceTable.Add(ListPriceSelectDiv_Label.Text,
            //    new GridColAppearance(MGridColDispType.Both,
            //    ContentAlignment.MiddleLeft, "", Color.Black));
            // 価格選択区分は未使用のため、非表示とする。
            appearanceTable.Add(ListPriceSelectDiv_Label.Text,
                new GridColAppearance(MGridColDispType.None,
                ContentAlignment.MiddleLeft, "", Color.Black));
            // ----- UPD 2010/12/03 --------------------------<<<<<

            // メーカー入力区分
            appearanceTable.Add(MakerInpDiv_Label.Text,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleLeft, "", Color.Black));

            // BL商品コード入力区分
            appearanceTable.Add(BLGoodsCdInpDiv_Label.Text,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleLeft, "", Color.Black));

            // 仕入先入力区分
            appearanceTable.Add(SupplierInpDiv_Label.Text,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleLeft, "", Color.Black));

            // 仕入伝票削除区分
            appearanceTable.Add(SupplierSlipDelDiv_Label.Text,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleLeft, "", Color.Black));

            // 得意先ガイド初期表示区分
            appearanceTable.Add(CustGuideDispDiv_Label.Text,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleLeft, "", Color.Black));

            // 伝票修正区分（日付）
            appearanceTable.Add(SlipChngDivDate_Label.Text,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleLeft, "", Color.Black));

            // 伝票修正区分（原価）
            appearanceTable.Add(SlipChngDivCost_Label.Text,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleLeft, "", Color.Black));

            // 伝票修正区分（売価）
            appearanceTable.Add(SlipChngDivUnPrc_Label.Text,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleLeft, "", Color.Black));

            // 伝票修正区分（定価）
            appearanceTable.Add(SlipChngDivLPrice_Label.Text,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleLeft, "", Color.Black));

            // 2008.12.11 30413 犬飼 返品伝票修正区分を追加 >>>>>>START
            // 返品伝票修正区分（原価）
            appearanceTable.Add(RetSlipChngDivCost_Label.Text,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleLeft, "", Color.Black));

            // 返品伝票修正区分（売価）
            appearanceTable.Add(RetSlipChngDivUnPrc_Label.Text,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleLeft, "", Color.Black));
            // 2008.12.11 30413 犬飼 返品伝票修正区分を追加 <<<<<<END
            
            // 自動入金金種
            appearanceTable.Add(AutoDepoKindCode_Label.Text,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleLeft, "", Color.Black));

            // 自動入金金種区分
            appearanceTable.Add(AutoDepoKindDivCd_Label.Text,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleLeft, "", Color.Black));

            // 値引名称
            appearanceTable.Add(DiscountName_Label.Text,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleLeft, "", Color.Black));

            // 発行者表示区分
            appearanceTable.Add(InpAgentDispDiv_Label.Text,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleLeft, "", Color.Black));

            // 得意先注番表示区分
            appearanceTable.Add(CustOrderNoDispDiv_Label.Text,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleLeft, "", Color.Black));

            // 車輌管理番号表示区分
            appearanceTable.Add(CarMngNoDispDiv_Label.Text,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleLeft, "", Color.Black));

            // --- ADD 2009/10/19 ---------->>>>>
            // 表示区分プロセス
            appearanceTable.Add(PriceSelectDispDiv_Label.Text,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleLeft, "", Color.Black));
            // --- ADD 2009/10/19 ----------<<<<< 

            // --- ADD 2010/01/29 ---------->>>>>
            // 受注数入力
            appearanceTable.Add(AcpOdrInputDiv_Label.Text,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleLeft, "", Color.Black));
            // --- ADD 2010/01/29 ----------<<<<< 

            // --- ADD 2010/05/04 ---------->>>>>
            // 発行者チェック区分
            appearanceTable.Add(InpAgentChkDiv_Label.Text,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleLeft, "", Color.Black));

            // 入力倉庫チェック区分
            appearanceTable.Add(InpWarehChkDiv_Label.Text,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleLeft, "", Color.Black));
            // --- ADD 2010/05/04 ----------<<<<<

            // 伝票備考３表示区分
            appearanceTable.Add(BrSlipNote3DispDiv_Label.Text,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleLeft, "", Color.Black));

            // 伝票日付クリア区分
            appearanceTable.Add(SlipDateClrDivCd_Label.Text,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleLeft, "", Color.Black));

            // 商品自動登録
            appearanceTable.Add(AutoEntryGoodsDivCd_Label.Text,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleLeft, "", Color.Black));

            // 原価チェック区分
            appearanceTable.Add(CostCheckDivCd_Label.Text,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleLeft, "", Color.Black));

            // 結合初期表示区分
            appearanceTable.Add(JoinInitDispDiv_Label.Text,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleLeft, "", Color.Black));

            // 自動入金区分
            appearanceTable.Add(AutoDepositCd_Label.Text,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleLeft, "", Color.Black));

            // --- ADD cheq 2013/01/21 Redmine#33797 ----->>>>>
            // 自動入金備考区分
            appearanceTable.Add(AutoDepositNoteDiv_Label.Text,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleLeft, "", Color.Black));
            // --- ADD cheq 2013/01/21 Redmine#33797 -----<<<<<

            // 代替条件区分
            appearanceTable.Add(SubstCondDivCd_Label.Text,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleLeft, "", Color.Black));

            // 伝票作成方法
            appearanceTable.Add(SlipCreateProcess_Label.Text,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleLeft, "", Color.Black));

            // 倉庫チェック区分
            appearanceTable.Add(WarehouseChkDiv_Label.Text,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleLeft, "", Color.Black));

            // 部品検索区分
            appearanceTable.Add(PartsSearchDivCd_Label.Text,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleLeft, "", Color.Black));

            // 粗利表示区分
            appearanceTable.Add(GrsProfitDspCd_Label.Text,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleLeft, "", Color.Black));

            // 部品検索優先順区分
            appearanceTable.Add(PartsSearchPriDivCd_Label.Text,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleLeft, "", Color.Black));

            // 売上仕入区分
            appearanceTable.Add(SalesStockDiv_Label.Text,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleLeft, "", Color.Black));

            // 印刷用BL商品コード区分
            appearanceTable.Add(PrtBLGoodsCodeDiv_Label.Text,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleLeft, "", Color.Black));

            // 拠点表示区分
            appearanceTable.Add(SectDspDivCd_Label.Text,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleLeft, "", Color.Black));

            // 商品名再表示区分
            appearanceTable.Add(GoodsNmReDispDivCd_Label.Text,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleLeft, "", Color.Black));

            // 原価表示区分
            appearanceTable.Add(CostDspDivCd_Label.Text,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleLeft, "", Color.Black));

            // 入金伝票日付クリア区分
            appearanceTable.Add(DepoSlipDateClrDiv_Label.Text,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleLeft, "", Color.Black));

            // 入金伝票日付範囲区分
            appearanceTable.Add(DepoSlipDateAmbit_Label.Text,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleLeft, "", Color.Black));

            // --- ADD 2008/07/22 -------------------------------->>>>>
            // 入力粗利チェック上限区分
            appearanceTable.Add(InpGrsPrfChkUpp_Label.Text + "区分",
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleLeft, "", Color.Black));

            // 入力粗利チェック上限
            appearanceTable.Add(InpGrsPrfChkUpp_Label.Text,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleRight, "", Color.Black));

            // 入力粗利チェック下限区分
            appearanceTable.Add(InpGrsPrfChkLow_Label.Text + "区分",
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleLeft, "", Color.Black));

            // 入力粗利チェック下限
            appearanceTable.Add(InpGrsPrfChkLow_Label.Text,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleRight, "", Color.Black));
            // --- ADD 2008/07/22 --------------------------------<<<<< 

            // ADD 2008/09/29 不具合対応[5665]---------->>>>>
            // 優良代替条件区分
            appearanceTable.Add(
                this.PrmSubstCondDivCd_Label.Text,
                new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black)
            );

            // 代替適用区分（ユーザー代替適用区分）
            appearanceTable.Add(
                this.SubstApplyDivCd_Label.Text,
                new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black)
            );
            // ADD 2008/09/29 不具合対応[5665]----------<<<<<

            // ADD 2008/11/05 不具合対応[7101] 品名表示区分の追加 ---------->>>>>
            // 品名表示区分
            appearanceTable.Add(
                this.partsNameDspDivCdLabel.Text,
                new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black)
            );
            // ADD 2008/11/05 不具合対応[7101] 品名表示区分の追加 ----------<<<<<

            appearanceTable.Add(
                this.BLGoodsCdDerivNoDiv_Label.Text,
                new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black)
            );
            // --- ADD 2010/04/30-------------------------------->>>>>
            // 自由検索部品自動登録区分
            appearanceTable.Add(FrSrchPrtAutoEntDiv_Label.Text,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleLeft, "", Color.Black));
            // --- ADD 2010/04/30 --------------------------------<<<<<

            // --- ADD 2010/08/04 ---------->>>>>
            // 小数点表示区分
            appearanceTable.Add(DwnPLCdSpDivCd_Label.Text,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleLeft, "", Color.Black));
            // --- ADD 2010/08/04 ----------<<<<< 

            // --- ADD 2011/06/07 ---------->>>>>
            // 販売区分表示区分
            appearanceTable.Add(SalesCdDspDivCd_Label.Text,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleLeft, "", Color.Black));
            // --- ADD 2011/06/07 ----------<<<<< 

            // --- ADD 2012/04/23 ---------->>>>>
            // 貸出仕入区分
            appearanceTable.Add(RentStockDiv_Label.Text,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleLeft, "", Color.Black));
            // --- ADD 2012/04/23 ----------<<<<< 

            // --- ADD 2012/12/27 Y.Wakita ---------->>>>>
            // 自社品番印字区分
            appearanceTable.Add(EpPartsNoPrtCd_Label.Text,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleLeft, "", Color.Black));

            // 自社品番付加文字
            appearanceTable.Add(EpPartsNoAddChar_Label.Text,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleLeft, "", Color.Black));
            // --- ADD 2012/12/27 Y.Wakita ----------<<<<<
            // --- ADD 2013/01/16 Y.Wakita ---------->>>>>
            // 印字品番初期値
            appearanceTable.Add(PrintGoodsNoDef_Label.Text,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleLeft, "", Color.Black));
            // --- ADD 2013/01/16 Y.Wakita ----------<<<<<
            // --- ADD 2013/01/15 ---------->>>>>
            // 仕入返品予定機能区分
            appearanceTable.Add(StockRetGoodsPlnDiv_Label.Text,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleLeft, "", Color.Black));
            // --- ADD 2013/01/15 ----------<<<<<

            // --- ADD 2013/02/04 Y.Wakita ---------->>>>>
            // BLコード０対応
            appearanceTable.Add(BLGoodsCdZeroSuprt_Label.Text,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleLeft, "", Color.Black));

            // 変換コード
            appearanceTable.Add(BLGoodsCdChange_Label.Text,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleLeft, "", Color.Black));
            // --- ADD 2013/02/04 Y.Wakita ----------<<<<<


            // --- ADD 2017/04/13 譚洪 Redmine#49283---------->>>>>
            // 仕入担当参照区分
            appearanceTable.Add(StockEmpRefDiv_Label.Text,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleLeft, "", Color.Black));
            // --- ADD 2017/04/13 譚洪 Redmine#49283----------<<<<<


            // GUID
            appearanceTable.Add(GUID_TITLE,
                new GridColAppearance(MGridColDispType.None,
                ContentAlignment.MiddleLeft, "", Color.Black));

            return appearanceTable;
        }

        /* --- DEL 2008/06/09 -------------------------------->>>>>
		/// <summary>
		/// HTMLコード取得処理
		/// </summary>
		/// <returns>HTMLコード</returns>
		/// <remarks>
		/// <br>Note       : HTMLコードの取得を行います。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.12.06</br>
		/// </remarks>
		public string GetHtmlCode()
		{
			const string ctPROCNM = "GetHtmlCode";
			string outCode = "";

			// tHtmlGenerate部品の引数を生成する
			List<string> titleList = new List<string>();
			List<string> valueList = new List<string>();
			titleList.Add( HTML_HEADER_TITLE );						// 「設定項目」
			valueList.Add( HTML_HEADER_VALUE );						// 「設定値」

			// 設定項目タイトル設定
			titleList.Add(this.SalesSlipPrtDiv_Label.Text);			// 売上伝票発行区分
			titleList.Add(this.ShipmSlipPrtDiv_Label.Text);			// 出荷伝票発行区分
			titleList.Add(this.ZeroPrtDiv_Label.Text);				// ゼロ円印刷区分
			titleList.Add(this.ShipmSlipUnPrcPrtDiv_Label.Text);	// 出荷伝票単価印刷区分
			titleList.Add(this.IoGoodsCntDiv_Label.Text);			// 入出荷数区分
			//----- ueno add---------- start 2008.02.26
			titleList.Add(this.IoGoodsCntDiv2_Label.Text);			// 入出荷数区分２
			//----- ueno add---------- start 2008.02.26
			titleList.Add(this.SalesFormalIn_Label.Text);			// 売上形式初期値
			titleList.Add(this.StockDetailConf_Label.Text);			// 仕入明細確認

			titleList.Add(this.GrsProfitCheckLower_Label.Text);		// 粗利チェック下限
			titleList.Add(this.GrsProfitCheckBest_Label.Text);		// 粗利チェック適正
			titleList.Add(this.GrsProfitCheckUpper_Label.Text);		// 粗利チェック上限
			titleList.Add(this.GrsProfitChkLowSign_Label.Text);		// 粗利チェック下限記号
			titleList.Add(this.GrsProfitChkBestSign_Label.Text);	// 粗利チェック適正記号
			titleList.Add(this.GrsProfitChkUprSign_Label.Text);		// 粗利チェック上限記号
			titleList.Add(this.GrsProfitChkMaxSign_Label.Text);		// 粗利チェック最大記号

			titleList.Add(this.SalesAgentChngDiv_Label.Text);		// 売上担当変更区分
			titleList.Add(this.AcpOdrAgentDispDiv_Label.Text);		// 受注者表示区分
			titleList.Add(this.BrSlipNote2DispDiv_Label.Text);		// 伝票備考２表示区分
			titleList.Add(this.DtlNoteDispDiv_Label.Text);			// 明細備考表示区分
			titleList.Add(this.UnPrcNonSettingDiv_Label.Text);		// 売価未設定時区分
			titleList.Add(this.AcpOdrrAddUpRemDiv_Label.Text);		// 受注データ計上残区分
			titleList.Add(this.ShipmAddUpRemDiv_Label.Text);		// 出荷データ計上残区分
			titleList.Add(this.RetGoodsStockEtyDiv_Label.Text);		// 返品時在庫登録区分
			titleList.Add(this.ListPriceSelectDiv_Label.Text);		// 定価選択区分
			titleList.Add(this.MakerInpDiv_Label.Text);				// メーカー入力区分
			titleList.Add(this.BLGoodsCdInpDiv_Label.Text);			// BL商品コード入力区分
			titleList.Add(this.SupplierInpDiv_Label.Text);			// 仕入先入力区分
			titleList.Add(this.SupplierSlipDelDiv_Label.Text);		// 仕入伝票削除区分
			titleList.Add(this.CustGuideDispDiv_Label.Text);		// 得意先ガイド初期値表示区分

			titleList.Add(this.SlipChngDivDate_Label.Text);			// 伝票修正区分（日付）
			titleList.Add(this.SlipChngDivCost_Label.Text);			// 伝票修正区分（原価）
			titleList.Add(this.SlipChngDivUnPrc_Label.Text);		// 伝票修正区分（売価）
			titleList.Add(this.SlipChngDivLPrice_Label.Text);		// 伝票修正区分（定価）

			//----- ueno add---------- start 2008.02.18
			titleList.Add(this.AutoDepoKindCode_Label.Text);		// 自動入金金種
			titleList.Add(this.AutoDepoKindDivCd_Label.Text);		// 自動入金金種区分
			//----- ueno add---------- end 2008.02.18
			//----- ueno add---------- start 2008.02.26
			titleList.Add(this.DiscountName_Label.Text);			// 値引名称
			//----- ueno add---------- end 2008.02.26

			// 売上全体設定データ取得
			int status = 0;
			status = this._salesTtlStAcs.Read( out this._salesTtlSt, this._enterpriseCode );
			switch( status ) {
				case ( int )ConstantManagement.DB_Status.ctDB_NORMAL:
				{

					// 売上全体設定取得データ設定
					if (this._salesTtlSt != null)
					{
						// 売上伝票発行区分
						valueList.Add(SalesTtlSt.GetComboBoxNm(this._salesTtlSt.SalesSlipPrtDiv, SalesTtlSt._yesNoList));
						// 出荷伝票発行区分
						valueList.Add(SalesTtlSt.GetComboBoxNm(this._salesTtlSt.ShipmSlipPrtDiv, SalesTtlSt._yesNoList));
						// ゼロ円印刷区分
						valueList.Add(SalesTtlSt.GetComboBoxNm(this._salesTtlSt.ZeroPrtDiv, SalesTtlSt._yesNoList));
						// 出荷伝票単価印刷区分						
						valueList.Add(SalesTtlSt.GetComboBoxNm(this._salesTtlSt.ShipmSlipUnPrcPrtDiv, SalesTtlSt._noYesList));
						// 入出荷数区分
						valueList.Add(SalesTtlSt.GetComboBoxNm(this._salesTtlSt.IoGoodsCntDiv, SalesTtlSt._alarmList));
						//----- ueno add---------- start 2008.02.26
						// 入出荷数区分２
						valueList.Add(SalesTtlSt.GetComboBoxNm(this._salesTtlSt.IoGoodsCntDiv2, SalesTtlSt._alarmList));
						//----- ueno add---------- end 2008.02.26
						// 売上形式初期値
						valueList.Add(SalesTtlSt.GetComboBoxNm(this._salesTtlSt.SalesFormalIn, SalesTtlSt._salesShipmList));
						// 仕入明細確認
						valueList.Add(SalesTtlSt.GetComboBoxNm(this._salesTtlSt.StockDetailConf, SalesTtlSt._optNecessaryList));
						// 粗利チェック下限
						valueList.Add(GetHtmlDispData(this._salesTtlSt.GrsProfitCheckLower));
						// 粗利チェック適正
						valueList.Add(GetHtmlDispData(this._salesTtlSt.GrsProfitCheckBest));
						// 粗利チェック上限
						valueList.Add(GetHtmlDispData(this._salesTtlSt.GrsProfitCheckUpper));
						// 粗利チェック下限記号
						valueList.Add(GetHtmlDispData(this._salesTtlSt.GrsProfitChkLowSign));
						// 粗利チェック適正記号
						valueList.Add(GetHtmlDispData(this._salesTtlSt.GrsProfitChkBestSign));
						// 粗利チェック上限記号
						valueList.Add(GetHtmlDispData(this._salesTtlSt.GrsProfitChkUprSign));
						// 粗利チェック最大記号
						valueList.Add(GetHtmlDispData(this._salesTtlSt.GrsProfitChkMaxSign));
						// 売上担当変更区分
						valueList.Add(SalesTtlSt.GetComboBoxNm(this._salesTtlSt.SalesAgentChngDiv, SalesTtlSt._enableAlarmList));
						// 受注者表示区分
						valueList.Add(SalesTtlSt.GetComboBoxNm(this._salesTtlSt.AcpOdrAgentDispDiv, SalesTtlSt._onOffNecessaryList));
						// 伝票備考２表示区分
						valueList.Add(SalesTtlSt.GetComboBoxNm(this._salesTtlSt.BrSlipNote2DispDiv, SalesTtlSt._onOffList));
						// 明細備考表示区分
						valueList.Add(SalesTtlSt.GetComboBoxNm(this._salesTtlSt.DtlNoteDispDiv, SalesTtlSt._onOffList));
						// 売価未設定時区分
						valueList.Add(SalesTtlSt.GetComboBoxNm(this._salesTtlSt.UnPrcNonSettingDiv, SalesTtlSt._zeroLPriceList));
						// 受注データ計上残区分
						valueList.Add(SalesTtlSt.GetComboBoxNm(this._salesTtlSt.AcpOdrrAddUpRemDiv, SalesTtlSt._reserveList));
						// 出荷データ計上残区分
						valueList.Add(SalesTtlSt.GetComboBoxNm(this._salesTtlSt.ShipmAddUpRemDiv, SalesTtlSt._reserveList));
						// 返品時在庫登録区分
						valueList.Add(SalesTtlSt.GetComboBoxNm(this._salesTtlSt.RetGoodsStockEtyDiv, SalesTtlSt._yesNoList));
						// 定価選択区分
						valueList.Add(SalesTtlSt.GetComboBoxNm(this._salesTtlSt.ListPriceSelectDiv, SalesTtlSt._noYesList));
						// メーカー入力区分						
						valueList.Add(SalesTtlSt.GetComboBoxNm(this._salesTtlSt.MakerInpDiv, SalesTtlSt._optNecessaryList));
						// BL商品コード入力区分
						valueList.Add(SalesTtlSt.GetComboBoxNm(this._salesTtlSt.BLGoodsCdInpDiv, SalesTtlSt._optNecessaryList));
						// 仕入先入力区分
						valueList.Add(SalesTtlSt.GetComboBoxNm(this._salesTtlSt.SupplierInpDiv, SalesTtlSt._optNecessaryList));
						// 仕入伝票削除区分
						valueList.Add(SalesTtlSt.GetComboBoxNm(this._salesTtlSt.SupplierSlipDelDiv, SalesTtlSt._noConfYesList));
						// 得意先ガイド初期値表示区分
						valueList.Add(SalesTtlSt.GetComboBoxNm(this._salesTtlSt.CustGuideDispDiv, SalesTtlSt._dispList));
						// 伝票修正区分（日付）
						valueList.Add(SalesTtlSt.GetComboBoxNm(this._salesTtlSt.SlipChngDivDate, SalesTtlSt._slipChngDivList));
						// 伝票修正区分（原価）						
						valueList.Add(SalesTtlSt.GetComboBoxNm(this._salesTtlSt.SlipChngDivCost, SalesTtlSt._slipChngDivList));
						// 伝票修正区分（売価）
						valueList.Add(SalesTtlSt.GetComboBoxNm(this._salesTtlSt.SlipChngDivUnPrc, SalesTtlSt._slipChngDivList));
						// 伝票修正区分（定価）
						valueList.Add(SalesTtlSt.GetComboBoxNm(this._salesTtlSt.SlipChngDivLPrice, SalesTtlSt._slipChngDivStcList));

						//----- ueno add---------- start 2008.02.18
						// 自動入金金種名称
						valueList.Add(GetHtmlDispData(this._salesTtlSt.AutoDepoKindName));
						// 自動入金金種区分名称
						valueList.Add(SalesTtlSt.GetComboBoxNm(this._salesTtlSt.AutoDepoKindDivCd, SalesTtlSt._mnyKindDivList));
						//----- ueno add---------- end 2008.02.18
						//----- ueno add---------- start 2008.02.26
						// 値引名称
						valueList.Add(GetHtmlDispData(this._salesTtlSt.DiscountName));
						//----- ueno add---------- end 2008.02.26
					}
					else
					{
						// 未設定
						for (int ix = 0; ix < titleList.Count; ix++)
						{
							valueList.Add(HTML_UNREGISTER);
						}
					}
					break;
				}
				case ( int )ConstantManagement.DB_Status.ctDB_EOF:
				case ( int )ConstantManagement.DB_Status.ctDB_NOT_FOUND:
				{
					// 未設定
					for( int ix = 0; ix < titleList.Count; ix++ ) {
						valueList.Add( HTML_UNREGISTER );
					}
					break;
				}
				default:
				{
					// リード
					TMsgDisp.Show( 
						this,                                 // 親ウィンドウフォーム
						emErrorLevel.ERR_LEVEL_STOP,          // エラーレベル
						CT_PGID,                              // アセンブリＩＤまたはクラスＩＤ
						CT_PGNM,                              // プログラム名称
						ctPROCNM,                             // 処理名称
						TMsgDisp.OPE_READ,                    // オペレーション
						"読み込みに失敗しました。",           // 表示するメッセージ
						status,                               // ステータス値
						this._salesTtlStAcs,                  // エラーが発生したオブジェクト
						MessageBoxButtons.OK,                 // 表示するボタン
						MessageBoxDefaultButton.Button1 );    // 初期表示ボタン

					// 未設定
					for( int ix = 0; ix < titleList.Count; ix++ ) {
						valueList.Add( HTML_UNREGISTER );
					}
					break;
				}
			}

			this.tHtmlGenerate1.Coltypes = new int[ 2 ];
			this.tHtmlGenerate1.Coltypes[ 0 ] = this.tHtmlGenerate1.ColtypeString;
			this.tHtmlGenerate1.Coltypes[ 1 ] = this.tHtmlGenerate1.ColtypeString;

			// 配列にコピー
            string [,] array = new string[ titleList.Count, 2 ];
			for( int ix = 0; ix < array.GetLength( 0 ); ix++ ) {
				array[ ix, 0 ] = titleList[ ix ];
				array[ ix, 1 ] = valueList[ ix ];
			}
           
			this.tHtmlGenerate1.ShowArrayStringtoGridwithProperty( array, ref outCode );

			return outCode;
		}
           --- DEL 2008/06/09 --------------------------------<<<<< */
        #endregion

        #region << Private Methods >>

        /// <summary>
		/// 画面初期設定
		/// </summary>
		/// <remarks>
		/// <br>Note       : UI画面の初期設定を行います。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.12.06</br>
        /// <br>Update Note: 2010/12/03 田建委</br>
        /// <br>             障害対応12月</br>
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

            // ----- ADD 2010/12/03 ------------------------------------------------------->>>>>
            // 価格選択区分は未使用のため、非表示とする。
            this.ListPriceSelectDiv_Label.Visible = false;
            this.ListPriceSelectDiv_tComboEditor.Visible = false;

            // 商品自動登録
            this.AutoEntryGoodsDivCd_Label.Location = new System.Drawing.Point(394, 255);
            this.AutoEntryGoodsDivCd_tComboEditor.Location = new System.Drawing.Point(599, 255);
            this.AutoEntryGoodsDivCd_tComboEditor.TabIndex = 20;
            // 返品時在庫登録区分
            this.RetGoodsStockEtyDiv_Label.Location = new System.Drawing.Point(394, 285);
            this.RetGoodsStockEtyDiv_tComboEditor.Location = new System.Drawing.Point(599, 285);
            this.RetGoodsStockEtyDiv_tComboEditor.TabIndex = 22;
            // 見積データ計上残区分
            this.EstmateAddUpRemDiv_Label.Location = new System.Drawing.Point(394, 315);
            this.EstmateAddUpRemDiv_tComboEditor.Location = new System.Drawing.Point(599, 315);
            this.EstmateAddUpRemDiv_tComboEditor.TabIndex = 24;
            // 貸出データ計上残区分
            this.ShipmAddUpRemDiv_Label.Location = new System.Drawing.Point(394, 345);
            this.ShipmAddUpRemDiv_tComboEditor.Location = new System.Drawing.Point(599, 345);
            this.ShipmAddUpRemDiv_tComboEditor.TabIndex = 26;
            // 受注データ計上残区分
            this.AcpOdrrAddUpRemDiv_Label.Location = new System.Drawing.Point(394, 375);
            this.AcpOdrrAddUpRemDiv_tComboEditor.Location = new System.Drawing.Point(599, 375);
            this.AcpOdrrAddUpRemDiv_tComboEditor.TabIndex = 28;
            // 得意先ガイド初期表示区分
            this.CustGuideDispDiv_Label.Location = new System.Drawing.Point(394, 405);
            this.CustGuideDispDiv_tComboEditor.Location = new System.Drawing.Point(599, 405);
            this.CustGuideDispDiv_tComboEditor.TabIndex = 30;
            // 商品名再表示区分
            this.GoodsNmReDispDivCd_Label.Location = new System.Drawing.Point(394, 435);
            this.GoodsNmReDispDivCd_tComboEditor.Location = new System.Drawing.Point(599, 435);
            this.GoodsNmReDispDivCd_tComboEditor.TabIndex = 32;
            // ----- ADD 2010/12/03 -------------------------------------------------------<<<<<

            // --- ADD 2013/01/09 T.Nishi ---------->>>>>
            this.EpPartsNoAddChar_tEdit.CharacterCasing = CharacterCasing.Lower;
            // --- ADD 2013/01/09 T.Nishi ----------<<<<<
            // コンボボックス設定
            SetComboBox();
		}

        /// <summary>
        /// データセット列情報構築処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : データセットの列情報を構築します。
        ///                  データセットの列情報がフレームのビュー用グリッドの列になります。</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/09</br>
        /// <br>Update Note: 2009/10/19 朱俊成 表示区分プロセスを追加</br>
        /// <br>Update Note: 2010/01/29 李侠　受注数入力を追加</br>
        /// <br>Update Note: 2010/04/30 姜凱 自由検索部品自動登録区分を追加</br>
        /// <br>Update Note: 2010/05/04 王海立 発行者チェック区分、入力倉庫チェック区分を追加</br>
        /// <br>Update Note: 2010/08/04 楊明俊 小数点表示区分を追加</br>
        /// <br>Update Note: 2011/06/07 22008 長内数馬 販売区分表示区分を追加</br>
        /// <br>Update Note: 2012/04/23 管理NO.611 福田康夫 貸出仕入区分を追加</br>
        /// <br>Update Note: 2013/01/15 FSI福原 一樹 仕入返品予定機能区分を追加 </br>
        /// <br>Update Note: 2013/01/21 cheq</br>
        /// <br>管理番号   : 10806793-00 2013/03/13配信分</br>
        /// <br>             Redmine#33797 自動入金備考区分を追加</br>
        /// <br>管理番号   : 11370030-00 2017/04/13 譚洪</br>
        /// <br>             Redmine#49283 仕入担当参照区分を追加</br>
        /// </remarks>
        private void DataSetColumnConstruction()
        {
            DataTable salesTtlStTable = new DataTable(SALESTTLST_TABLE);
            salesTtlStTable.Columns.Add(DELETE_DATE, typeof(string));

            // 拠点コード
            salesTtlStTable.Columns.Add(SECTIONCODE_TITLE, typeof(string));

            // 拠点名称
            salesTtlStTable.Columns.Add(SECTIONNAME_TITLE, typeof(string));

            // 売上伝票発行区分
            salesTtlStTable.Columns.Add(SalesSlipPrtDiv_Label.Text, typeof(string));

            // 貸出伝票発行区分
            salesTtlStTable.Columns.Add(ShipmSlipPrtDiv_Label.Text, typeof(string));

            // --- DEL 2008/07/22 -------------------------------->>>>>
            //// ゼロ円印刷区分
            //salesTtlStTable.Columns.Add(ZeroPrtDiv_Label.Text, typeof(string));
            // --- DEL 2008/07/22 --------------------------------<<<<< 

            // DEL 2009/01/14 不具合対応[9947] ↓貸出伝票単価印刷区分は削除
            //// 貸出伝票単価印刷区分
            //salesTtlStTable.Columns.Add(ShipmSlipUnPrcPrtDiv_Label.Text, typeof(string));

            // --- DEL 2008/07/22 -------------------------------->>>>>
            //// 入出荷数区分
            //salesTtlStTable.Columns.Add(IoGoodsCntDiv_Label.Text, typeof(string));

            //// 入出荷数区分２
            //salesTtlStTable.Columns.Add(IoGoodsCntDiv2_Label.Text, typeof(string));

            //// 売上形式初期値
            //salesTtlStTable.Columns.Add(SalesFormalIn_Label.Text, typeof(string));

            //// 仕入明細確認
            //salesTtlStTable.Columns.Add(StockDetailConf_Label.Text, typeof(string));
            // --- DEL 2008/07/22 --------------------------------<<<<< 

            // 粗利チェック下限
            salesTtlStTable.Columns.Add(GrsProfitCheckLower_Label.Text, typeof(string));

            // 粗利チェック適正
            salesTtlStTable.Columns.Add(GrsProfitCheckBest_Label.Text, typeof(string));

            // 粗利チェック上限
            salesTtlStTable.Columns.Add(GrsProfitCheckUpper_Label.Text, typeof(string));

            // 粗利チェック下限記号
            salesTtlStTable.Columns.Add(GrsProfitChkLowSign_Label.Text, typeof(string));

            // 粗利チェック適正記号
            salesTtlStTable.Columns.Add(GrsProfitChkBestSign_Label.Text, typeof(string));

            // 粗利チェック上限記号
            salesTtlStTable.Columns.Add(GrsProfitChkUprSign_Label.Text, typeof(string));

            // 粗利チェック最大記号
            salesTtlStTable.Columns.Add(GrsProfitChkMaxSign_Label.Text, typeof(string));

            // 売上担当変更区分
            salesTtlStTable.Columns.Add(SalesAgentChngDiv_Label.Text, typeof(string));

            // 受注者表示区分
            salesTtlStTable.Columns.Add(AcpOdrAgentDispDiv_Label.Text, typeof(string));

            // 伝票備考２表示区分
            salesTtlStTable.Columns.Add(BrSlipNote2DispDiv_Label.Text, typeof(string));

            // 明細備考表示区分
            salesTtlStTable.Columns.Add(DtlNoteDispDiv_Label.Text, typeof(string));

            // 売価未設定時区分
            salesTtlStTable.Columns.Add(UnPrcNonSettingDiv_Label.Text, typeof(string));

            // 見積データ計上残区分
            salesTtlStTable.Columns.Add(EstmateAddUpRemDiv_Label.Text, typeof(string));

            // 受注データ計上残区分
            salesTtlStTable.Columns.Add(AcpOdrrAddUpRemDiv_Label.Text, typeof(string));

            //// 出荷データ計上残区分 // DEL 2010/12/03
            // 貸出データ計上残区分 // ADD 2010/12/03
            salesTtlStTable.Columns.Add(ShipmAddUpRemDiv_Label.Text, typeof(string));

            // 返品時在庫登録区分
            salesTtlStTable.Columns.Add(RetGoodsStockEtyDiv_Label.Text, typeof(string));

            // 定価選択区分
            salesTtlStTable.Columns.Add(ListPriceSelectDiv_Label.Text, typeof(string));

            // メーカー入力区分
            salesTtlStTable.Columns.Add(MakerInpDiv_Label.Text, typeof(string));

            // BL商品コード入力区分
            salesTtlStTable.Columns.Add(BLGoodsCdInpDiv_Label.Text, typeof(string));

            // 仕入先入力区分
            salesTtlStTable.Columns.Add(SupplierInpDiv_Label.Text, typeof(string));

            // 仕入伝票削除区分
            salesTtlStTable.Columns.Add(SupplierSlipDelDiv_Label.Text, typeof(string));

            // 得意先ガイド初期表示区分
            salesTtlStTable.Columns.Add(CustGuideDispDiv_Label.Text, typeof(string));

            // 伝票修正区分（日付）
            salesTtlStTable.Columns.Add(SlipChngDivDate_Label.Text, typeof(string));

            // 伝票修正区分（原価）
            salesTtlStTable.Columns.Add(SlipChngDivCost_Label.Text, typeof(string));

            // 伝票修正区分（売価）
            salesTtlStTable.Columns.Add(SlipChngDivUnPrc_Label.Text, typeof(string));

            // 伝票修正区分（定価）
            salesTtlStTable.Columns.Add(SlipChngDivLPrice_Label.Text, typeof(string));

            // 2008.12.11 30413 犬飼 返品伝票修正区分を追加 >>>>>>START
            // 返品伝票修正区分（原価）
            salesTtlStTable.Columns.Add(RetSlipChngDivCost_Label.Text, typeof(string));

            // 返品伝票修正区分（売価）
            salesTtlStTable.Columns.Add(RetSlipChngDivUnPrc_Label.Text, typeof(string));
            // 2008.12.11 30413 犬飼 返品伝票修正区分を追加 <<<<<<END
            
            // 自動入金金種
            salesTtlStTable.Columns.Add(AutoDepoKindCode_Label.Text, typeof(string));

            // 自動入金金種区分
            salesTtlStTable.Columns.Add(AutoDepoKindDivCd_Label.Text, typeof(string));

            // 値引名称
            salesTtlStTable.Columns.Add(DiscountName_Label.Text, typeof(string));

            // 発行者表示区分
            salesTtlStTable.Columns.Add(InpAgentDispDiv_Label.Text, typeof(string));

            // 得意先注番表示区分
            salesTtlStTable.Columns.Add(CustOrderNoDispDiv_Label.Text, typeof(string));

            // 車輌管理番号表示区分
            salesTtlStTable.Columns.Add(CarMngNoDispDiv_Label.Text, typeof(string));

            // --- ADD 2009/10/19 ---------->>>>> 
            // 表示区分プロセス
            salesTtlStTable.Columns.Add(PriceSelectDispDiv_Label.Text, typeof(string));
            // --- ADD 2009/10/19 ----------<<<<<

            // --- ADD 2010/01/29 ---------->>>>> 
            // 受注数入力
            salesTtlStTable.Columns.Add(AcpOdrInputDiv_Label.Text, typeof(string));
            // --- ADD 2010/01/29 ----------<<<<<

            // 伝票備考３表示区分
            salesTtlStTable.Columns.Add(BrSlipNote3DispDiv_Label.Text, typeof(string));

            // 伝票日付クリア区分
            salesTtlStTable.Columns.Add(SlipDateClrDivCd_Label.Text, typeof(string));

            // 商品自動登録
            salesTtlStTable.Columns.Add(AutoEntryGoodsDivCd_Label.Text, typeof(string));

            // 原価チェック区分
            salesTtlStTable.Columns.Add(CostCheckDivCd_Label.Text, typeof(string));

            // 結合初期表示区分
            salesTtlStTable.Columns.Add(JoinInitDispDiv_Label.Text, typeof(string));

            // 自動入金区分
            salesTtlStTable.Columns.Add(AutoDepositCd_Label.Text, typeof(string));

            // 代替条件区分
            salesTtlStTable.Columns.Add(SubstCondDivCd_Label.Text, typeof(string));

            // 伝票作成方法
            salesTtlStTable.Columns.Add(SlipCreateProcess_Label.Text, typeof(string));

            // 倉庫チェック区分
            salesTtlStTable.Columns.Add(WarehouseChkDiv_Label.Text, typeof(string));

            // 部品検索区分
            salesTtlStTable.Columns.Add(PartsSearchDivCd_Label.Text, typeof(string));

            // 粗利表示区分
            salesTtlStTable.Columns.Add(GrsProfitDspCd_Label.Text, typeof(string));

            // 部品検索優先順区分
            salesTtlStTable.Columns.Add(PartsSearchPriDivCd_Label.Text, typeof(string));

            // 売上仕入区分
            salesTtlStTable.Columns.Add(SalesStockDiv_Label.Text, typeof(string));

            // 印刷用BL商品コード区分
            salesTtlStTable.Columns.Add(PrtBLGoodsCodeDiv_Label.Text, typeof(string));

            // 拠点表示区分
            salesTtlStTable.Columns.Add(SectDspDivCd_Label.Text, typeof(string));

            // 商品名再表示区分
            salesTtlStTable.Columns.Add(GoodsNmReDispDivCd_Label.Text, typeof(string));

            // 原価表示区分
            salesTtlStTable.Columns.Add(CostDspDivCd_Label.Text, typeof(string));

            // 入金伝票日付クリア区分
            salesTtlStTable.Columns.Add(DepoSlipDateClrDiv_Label.Text, typeof(string));

            // 入金伝票日付範囲区分
            salesTtlStTable.Columns.Add(DepoSlipDateAmbit_Label.Text, typeof(string));

            // --- ADD 2008/07/22 -------------------------------->>>>>
            // 入力粗利チェック上限区分
            salesTtlStTable.Columns.Add(InpGrsPrfChkUpp_Label.Text + "区分", typeof(string));

            // 入力粗利チェック上限
            salesTtlStTable.Columns.Add(InpGrsPrfChkUpp_Label.Text, typeof(string));

            // 入力粗利チェック下限区分
            salesTtlStTable.Columns.Add(InpGrsPrfChkLow_Label.Text + "区分", typeof(string));

            // 入力粗利チェック下限
            salesTtlStTable.Columns.Add(InpGrsPrfChkLow_Label.Text, typeof(string));
            // --- ADD 2008/07/22 --------------------------------<<<<< 

            // ADD 2008/09/29 不具合対応[5665]---------->>>>>
            // 優良代替条件区分
            salesTtlStTable.Columns.Add(this.PrmSubstCondDivCd_Label.Text, typeof(string));

            // 代替適用区分
            salesTtlStTable.Columns.Add(this.SubstApplyDivCd_Label.Text, typeof(string));
            // ADD 2008/09/29 不具合対応[5665]----------<<<<<

            // ADD 2008/11/05 不具合対応[7101] 品名表示区分の追加 ---------->>>>>
            // 品名表示区分
            salesTtlStTable.Columns.Add(this.partsNameDspDivCdLabel.Text, typeof(string));
            // ADD 2008/11/05 不具合対応[7101] 品名表示区分の追加 ----------<<<<<

            // BLコード枝番区分
            salesTtlStTable.Columns.Add(BLGoodsCdDerivNoDiv_Label.Text, typeof(string));

            // --- ADD 2010/04/30-------------------------------->>>>>
            // 自由検索部品自動登録区分
            salesTtlStTable.Columns.Add(FrSrchPrtAutoEntDiv_Label.Text, typeof(string));
            // --- ADD 2010/04/30 --------------------------------<<<<<

            // --- ADD 2010/05/04 ---------->>>>> 
            // 発行者チェック区分
            salesTtlStTable.Columns.Add(InpAgentChkDiv_Label.Text, typeof(string));
            
            // 入力倉庫チェック区分
            salesTtlStTable.Columns.Add(InpWarehChkDiv_Label.Text, typeof(string));
            // --- ADD 2010/05/04 ----------<<<<<

            // --- ADD 2010/08/04 ---------->>>>> 
            // 小数点表示区分
            salesTtlStTable.Columns.Add(DwnPLCdSpDivCd_Label.Text, typeof(string));
            // --- ADD 2010/08/04 ----------<<<<<

            // --- ADD 2011/06/07 ---------->>>>> 
            // 販売区分表示区分
            salesTtlStTable.Columns.Add(SalesCdDspDivCd_Label.Text, typeof(string));
            // --- ADD 2011/06/07 ----------<<<<<

            // --- ADD 2012/04/23 ---------->>>>> 
            // 貸出仕入区分
            salesTtlStTable.Columns.Add(RentStockDiv_Label.Text, typeof(string));
            // --- ADD 2012/04/23 ----------<<<<<

            // --- ADD 2012/12/27 Y.Wakita ---------->>>>>
            // 自社品番印字区分
            salesTtlStTable.Columns.Add(EpPartsNoPrtCd_Label.Text, typeof(string));

            // 自社品番付加文字
            salesTtlStTable.Columns.Add(EpPartsNoAddChar_Label.Text, typeof(string));
            // --- ADD 2012/12/27 Y.Wakita ----------<<<<<
            // --- ADD 2013/01/16 Y.Wakita ---------->>>>>
            // 印字品番初期値
            salesTtlStTable.Columns.Add(PrintGoodsNoDef_Label.Text, typeof(string));
            // --- ADD 2013/01/16 Y.Wakita ----------<<<<<
            // --- ADD 2013/01/15 ---------->>>>>
            // 仕入返品予定区分
            salesTtlStTable.Columns.Add(StockRetGoodsPlnDiv_Label.Text, typeof(string));
            // --- ADD 2013/01/15 ----------<<<<<
            
            // --- ADD cheq 2013/01/21 Redmine#33797 ----->>>>>
            // 自動入金備考区分
            salesTtlStTable.Columns.Add(AutoDepositNoteDiv_Label.Text, typeof(string));
            // --- ADD cheq 2013/01/21 Redmine#33797 -----<<<<<

            // --- ADD 2013/02/05 Y.Wakita ---------->>>>>
            // BLコード０対応
            salesTtlStTable.Columns.Add(BLGoodsCdZeroSuprt_Label.Text, typeof(string));

            // 変換コード
            salesTtlStTable.Columns.Add(BLGoodsCdChange_Label.Text, typeof(string));
            // --- ADD 2013/02/05 Y.Wakita ----------<<<<<

            // --- ADD 2017/04/13 譚洪 Redmine#49283---------->>>>>
            // 仕入担当参照区分
            salesTtlStTable.Columns.Add(StockEmpRefDiv_Label.Text, typeof(string));
            // --- ADD 2017/04/13 譚洪 Redmine#49283----------<<<<<

            salesTtlStTable.Columns.Add(GUID_TITLE, typeof(Guid));

            this.Bind_DataSet.Tables.Add(salesTtlStTable);
        }

        // --- DEL 2008/07/22 -------------------------------->>>>>
        #region 削除コード
        ///// <summary>
        ///// 画面情報売上全体設定クラス格納処理
        ///// </summary>
        ///// <remarks>
        ///// <br>Note       : 画面情報から売上全体設定クラスにデータを格納します。</br>
        ///// <br>Programmer : 30167 上野　弘貴</br>
        ///// <br>Date       : 2007.12.06</br>
        ///// </remarks>
        //private void ScreenToSalesTtlSt()
        //{
        //    if( this._salesTtlSt == null ) {
        //        // 新規の場合
        //        this._salesTtlSt = new SalesTtlSt();
        //    }

        //    this._salesTtlSt.SalesSlipPrtDiv		= NullChgInt(this.SalesSlipPrtDiv_tComboEditor.Value);		// 売上伝票発行区分
        //    this._salesTtlSt.ShipmSlipPrtDiv		= NullChgInt(this.ShipmSlipPrtDiv_tComboEditor.Value);		// 出荷伝票発行区分
        //    //this._salesTtlSt.ZeroPrtDiv				= NullChgInt(this.ZeroPrtDiv_tComboEditor.Value);			// ゼロ円印刷区分    // DEL 2008/07/22
        //    this._salesTtlSt.ShipmSlipUnPrcPrtDiv	= NullChgInt(this.ShipmSlipUnPrcPrtDiv_tComboEditor.Value);	// 出荷伝票単価印刷区分

        //    // --- DEL 2008/07/22 -------------------------------->>>>>
        //    //this._salesTtlSt.IoGoodsCntDiv			= NullChgInt(this.IoGoodsCntDiv_tComboEditor.Value);		// 入出荷数区分
        //    ////----- ueno add---------- start 2008.02.26
        //    //this._salesTtlSt.IoGoodsCntDiv2			= NullChgInt(this.IoGoodsCntDiv2_tComboEditor.Value);		// 入出荷数区分２
        //    ////----- ueno add---------- end 2008.02.26
        //    //this._salesTtlSt.SalesFormalIn			= NullChgInt(this.SalesFormalIn_tComboEditor.Value);		// 売上形式初期値
        //    //this._salesTtlSt.StockDetailConf		= NullChgInt(this.StockDetailConf_tComboEditor.Value);		// 仕入明細確認
        //    // --- DEL 2008/07/22 --------------------------------<<<<< 

        //    this._salesTtlSt.GrsProfitCheckLower	= this.GrsProfitCheckLower_tNedit.GetValue();				// 粗利チェック下限
        //    this._salesTtlSt.GrsProfitCheckBest		= this.GrsProfitCheckBest_tNedit.GetValue();				// 粗利チェック適正
        //    this._salesTtlSt.GrsProfitCheckUpper	= this.GrsProfitCheckUpper_tNedit.GetValue();				// 粗利チェック上限
        //    this._salesTtlSt.GrsProfitChkLowSign	= this.GrsProfitChkLowSign_tEdit.Text;						// 粗利チェック下限記号
        //    this._salesTtlSt.GrsProfitChkBestSign	= this.GrsProfitChkBestSign_tEdit.Text;						// 粗利チェック適正記号
        //    this._salesTtlSt.GrsProfitChkUprSign	= this.GrsProfitChkUprSign_tEdit.Text;						// 粗利チェック上限記号
        //    this._salesTtlSt.GrsProfitChkMaxSign	= this.GrsProfitChkMaxSign_tEdit.Text;						// 粗利チェック最大記号

        //    this._salesTtlSt.SalesAgentChngDiv		= NullChgInt(this.SalesAgentChngDiv_tComboEditor.Value);	// 売上担当変更区分
        //    this._salesTtlSt.AcpOdrAgentDispDiv		= NullChgInt(this.AcpOdrAgentDispDiv_tComboEditor.Value);	// 受注者表示区分
        //    this._salesTtlSt.BrSlipNote2DispDiv		= NullChgInt(this.BrSlipNote2DispDiv_tComboEditor.Value);	// 伝票備考２表示区分
        //    this._salesTtlSt.DtlNoteDispDiv			= NullChgInt(this.DtlNoteDispDiv_tComboEditor.Value);		// 明細備考表示区分
        //    this._salesTtlSt.UnPrcNonSettingDiv		= NullChgInt(this.UnPrcNonSettingDiv_tComboEditor.Value);	// 売価未設定時区分
        //    this._salesTtlSt.AcpOdrrAddUpRemDiv		= NullChgInt(this.AcpOdrrAddUpRemDiv_tComboEditor.Value);	// 受注データ計上残区分
        //    this._salesTtlSt.ShipmAddUpRemDiv		= NullChgInt(this.ShipmAddUpRemDiv_tComboEditor.Value);		// 出荷データ計上残区分
        //    this._salesTtlSt.RetGoodsStockEtyDiv	= NullChgInt(this.RetGoodsStockEtyDiv_tComboEditor.Value);	// 返品時在庫登録区分
        //    this._salesTtlSt.ListPriceSelectDiv		= NullChgInt(this.ListPriceSelectDiv_tComboEditor.Value);	// 定価選択区分
        //    this._salesTtlSt.MakerInpDiv			= NullChgInt(this.MakerInpDiv_tComboEditor.Value);			// メーカー入力区分
        //    this._salesTtlSt.BLGoodsCdInpDiv		= NullChgInt(this.BLGoodsCdInpDiv_tComboEditor.Value);		// BL商品コード入力区分
        //    this._salesTtlSt.SupplierInpDiv			= NullChgInt(this.SupplierInpDiv_tComboEditor.Value);		// 仕入先入力区分
        //    this._salesTtlSt.SupplierSlipDelDiv		= NullChgInt(this.SupplierSlipDelDiv_tComboEditor.Value);	// 仕入伝票削除区分
        //    this._salesTtlSt.CustGuideDispDiv		= NullChgInt(this.CustGuideDispDiv_tComboEditor.Value);		// 得意先ガイド初期値表示区分

        //    this._salesTtlSt.SlipChngDivDate		= NullChgInt(this.SlipChngDivDate_tComboEditor.Value);		// 伝票修正区分（日付）
        //    this._salesTtlSt.SlipChngDivCost		= NullChgInt(this.SlipChngDivCost_tComboEditor.Value);		// 伝票修正区分（原価）
        //    this._salesTtlSt.SlipChngDivUnPrc		= NullChgInt(this.SlipChngDivUnPrc_tComboEditor.Value);		// 伝票修正区分（売価）
        //    this._salesTtlSt.SlipChngDivLPrice		= NullChgInt(this.SlipChngDivLPrice_tComboEditor.Value);	// 伝票修正区分（定価）

        //    //----- ueno add---------- start 2008.02.18
        //    this._salesTtlSt.AutoDepoKindCode		= NullChgInt(this.AutoDepoKindCode_tComboEditor.Value);		// 自動入金金種コード
        //    this._salesTtlSt.AutoDepoKindName		= this.AutoDepoKindCode_tComboEditor.Text;					// 自動入金金種名称
        //    this._salesTtlSt.AutoDepoKindDivCd		= this.AutoDepoKindDivCd_tNedit.GetInt();					// 自動入金金種区分（隠し項目）
        //    //----- ueno add---------- end 2008.02.18
        //    //----- ueno add---------- start 2008.02.26
        //    this._salesTtlSt.DiscountName			= this.DiscountName_tEdit.Text;								// 値引名称
        //    //----- ueno add---------- end 2008.02.26

        //    // --- ADD 2008/07/22 -------------------------------->>>>>
        //    this._salesTtlSt.InpGrsProfChkLower = this.InpGrsProfChkLower_tNedit.GetValue();                    // 入力粗利チェック下限
        //    this._salesTtlSt.InpGrsProfChkUpper = this.InpGrsProfChkUpper_tNedit.GetValue();                    // 入力粗利チェック上限
        //    this._salesTtlSt.InpGrsProfChkLowDiv = NullChgInt(this.InpGrsProfChkLowDiv_tComboEditor.Value);     // 入力粗利チェック下限区分
        //    this._salesTtlSt.InpGrsProfChkUppDiv = NullChgInt(this.InpGrsProfChkUppDiv_tComboEditor.Value);     // 入力粗利チェック上限区分
        //    // --- ADD 2008/07/22 --------------------------------<<<<< 
        //}
        #endregion  // 削除コード
        // --- DEL 2008/07/22 --------------------------------<<<<< 

		/// <summary>
		/// 画面情報売上全体設定クラス格納処理(チェック用)
		/// </summary>
		/// <param name="salesTtlSt">売上全体設定オブジェクト</param>
		/// <remarks>
		/// <br>Note       : 画面情報から売上全体設定クラスにデータを格納します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.12.06</br>
        /// <br>Update Note: 2009/10/19 朱俊成 表示区分プロセスを追加</br>
        /// <br>Update Note: 2010/01/29 李侠　受注数入力を追加</br>
        /// <br>Update Note: 2010/04/30 姜凱 自由検索部品自動登録区分を追加</br>        
        /// <br>Update Note: 2010/05/04 王海立 発行者チェック区分、入力倉庫チェック区分を追加</br>
        /// <br>Update Note: 2010/08/04 楊明俊 小数点表示区分を追加</br>
        /// <br>Update Note: 2011/06/07 22008 長内数馬 販売区分表示区分を追加</br>
        /// <br>Update Note: 2012/04/23 管理NO.611 福田康夫 貸出仕入区分を追加</br>
        /// <br>Update Note: 2013/01/15 FSI福原 一樹 仕入返品予定機能区分を追加</br>
        /// <br>Update Note: 2013/01/21 cheq</br>
        /// <br>管理番号   : 10806793-00 2013/03/13配信分</br>
        /// <br>             Redmine#33797 自動入金備考区分を追加</br>
        /// <br>管理番号   : 11370030-00 2017/04/13 譚洪</br>
        /// <br>             Redmine#49283 仕入担当参照区分を追加</br>
        /// </remarks>
		private void DispToSalesTtlSt(ref SalesTtlSt salesTtlSt)
		{
			if (salesTtlSt == null)
			{
				// 新規の場合
				salesTtlSt = new SalesTtlSt();
			}

			salesTtlSt.SalesSlipPrtDiv				= NullChgInt(this.SalesSlipPrtDiv_tComboEditor.Value);		// 売上伝票発行区分
			salesTtlSt.ShipmSlipPrtDiv				= NullChgInt(this.ShipmSlipPrtDiv_tComboEditor.Value);		// 出荷伝票発行区分
			//salesTtlSt.ZeroPrtDiv					= NullChgInt(this.ZeroPrtDiv_tComboEditor.Value);			// ゼロ円印刷区分        // DEL 2008/07/22
			salesTtlSt.ShipmSlipUnPrcPrtDiv			= NullChgInt(this.ShipmSlipUnPrcPrtDiv_tComboEditor.Value);	// 出荷伝票単価印刷区分

            // --- DEL 2008/07/22 -------------------------------->>>>>
            //salesTtlSt.IoGoodsCntDiv				= NullChgInt(this.IoGoodsCntDiv_tComboEditor.Value);		// 入出荷数区分
            ////----- ueno add---------- start 2008.02.26
            //salesTtlSt.IoGoodsCntDiv2				= NullChgInt(this.IoGoodsCntDiv2_tComboEditor.Value);		// 入出荷数区分２
            ////----- ueno add---------- end 2008.02.26
            //salesTtlSt.SalesFormalIn				= NullChgInt(this.SalesFormalIn_tComboEditor.Value);		// 売上形式初期値
            //salesTtlSt.StockDetailConf				= NullChgInt(this.StockDetailConf_tComboEditor.Value);		// 仕入明細確認
            // --- DEL 2008/07/22 --------------------------------<<<<< 

			salesTtlSt.GrsProfitCheckLower			= this.GrsProfitCheckLower_tNedit.GetValue();				// 粗利チェック下限
			salesTtlSt.GrsProfitCheckBest			= this.GrsProfitCheckBest_tNedit.GetValue();				// 粗利チェック適正
			salesTtlSt.GrsProfitCheckUpper			= this.GrsProfitCheckUpper_tNedit.GetValue();				// 粗利チェック上限
			salesTtlSt.GrsProfitChkLowSign			= this.GrsProfitChkLowSign_tEdit.Text;						// 粗利チェック下限記号
			salesTtlSt.GrsProfitChkBestSign			= this.GrsProfitChkBestSign_tEdit.Text;						// 粗利チェック適正記号
			salesTtlSt.GrsProfitChkUprSign			= this.GrsProfitChkUprSign_tEdit.Text;						// 粗利チェック上限記号
			salesTtlSt.GrsProfitChkMaxSign			= this.GrsProfitChkMaxSign_tEdit.Text;						// 粗利チェック最大記号

			salesTtlSt.SalesAgentChngDiv			= NullChgInt(this.SalesAgentChngDiv_tComboEditor.Value);	// 売上担当変更区分
			salesTtlSt.AcpOdrAgentDispDiv			= NullChgInt(this.AcpOdrAgentDispDiv_tComboEditor.Value);	// 受注者表示区分
			salesTtlSt.BrSlipNote2DispDiv			= NullChgInt(this.BrSlipNote2DispDiv_tComboEditor.Value);	// 伝票備考２表示区分
			salesTtlSt.DtlNoteDispDiv				= NullChgInt(this.DtlNoteDispDiv_tComboEditor.Value);		// 明細備考表示区分
			salesTtlSt.UnPrcNonSettingDiv			= NullChgInt(this.UnPrcNonSettingDiv_tComboEditor.Value);	// 売価未設定時区分
			salesTtlSt.AcpOdrrAddUpRemDiv			= NullChgInt(this.AcpOdrrAddUpRemDiv_tComboEditor.Value);	// 受注データ計上残区分
            salesTtlSt.ShipmAddUpRemDiv             = NullChgInt(this.ShipmAddUpRemDiv_tComboEditor.Value);		//// 出荷データ計上残区分 // DEL 2010/12/03 // 貸出データ計上残区分 // ADD 2010/12/03
			salesTtlSt.RetGoodsStockEtyDiv			= NullChgInt(this.RetGoodsStockEtyDiv_tComboEditor.Value);	// 返品時在庫登録区分
			salesTtlSt.ListPriceSelectDiv			= NullChgInt(this.ListPriceSelectDiv_tComboEditor.Value);	// 定価選択区分
			salesTtlSt.MakerInpDiv					= NullChgInt(this.MakerInpDiv_tComboEditor.Value);			// メーカー入力区分
			salesTtlSt.BLGoodsCdInpDiv				= NullChgInt(this.BLGoodsCdInpDiv_tComboEditor.Value);		// BL商品コード入力区分
			salesTtlSt.SupplierInpDiv				= NullChgInt(this.SupplierInpDiv_tComboEditor.Value);		// 仕入先入力区分
			salesTtlSt.SupplierSlipDelDiv			= NullChgInt(this.SupplierSlipDelDiv_tComboEditor.Value);	// 仕入伝票削除区分
			salesTtlSt.CustGuideDispDiv				= NullChgInt(this.CustGuideDispDiv_tComboEditor.Value);		// 得意先ガイド初期値表示区分

			salesTtlSt.SlipChngDivDate				= NullChgInt(this.SlipChngDivDate_tComboEditor.Value);		// 伝票修正区分（日付）
			salesTtlSt.SlipChngDivCost				= NullChgInt(this.SlipChngDivCost_tComboEditor.Value);		// 伝票修正区分（原価）
			salesTtlSt.SlipChngDivUnPrc				= NullChgInt(this.SlipChngDivUnPrc_tComboEditor.Value);		// 伝票修正区分（売価）
			salesTtlSt.SlipChngDivLPrice			= NullChgInt(this.SlipChngDivLPrice_tComboEditor.Value);	// 伝票修正区分（定価）

            // 2008.12.11 30413 犬飼 返品伝票修正区分を追加 >>>>>>START
            salesTtlSt.RetSlipChngDivCost = NullChgInt(this.RetSlipChngDivCost_tComboEditor.Value);             // 返品伝票修正区分（原価）
            salesTtlSt.RetSlipChngDivUnPrc = NullChgInt(this.RetSlipChngDivUnPrc_tComboEditor.Value);           // 返品伝票修正区分（売価）
            // 2008.12.11 30413 犬飼 返品伝票修正区分を追加 <<<<<<END

			//----- ueno add---------- start 2008.02.18
			salesTtlSt.AutoDepoKindCode				= NullChgInt(this.AutoDepoKindCode_tComboEditor.Value);		// 自動入金金種コード
			salesTtlSt.AutoDepoKindName				= this.AutoDepoKindCode_tComboEditor.Text;					// 自動入金金種名称
			salesTtlSt.AutoDepoKindDivCd			= this.AutoDepoKindDivCd_tNedit.GetInt();					// 自動入金金種区分（隠し項目）
			//----- ueno add---------- end 2008.02.18
			//----- ueno add---------- start 2008.02.26
			salesTtlSt.DiscountName					= this.DiscountName_tEdit.Text;								// 値引名称
			//----- ueno add---------- end 2008.02.26

            // --- ADD 2008/06/09 -------------------------------->>>>>
            salesTtlSt.EnterpriseCode               = this._enterpriseCode;					                    // 企業コード
            salesTtlSt.SectionCode                  = tEdit_SectionCodeAllowZero2.DataText.TrimEnd();            // 拠点コード
            // ADD 2008/09/18 不具合対応[5407] ---------->>>>>
            // uiSetControlが""のとき"00"を設定するので、デフォルト値は"00"とする
            if (string.IsNullOrEmpty(this.tEdit_SectionCodeAllowZero2.DataText.TrimEnd()))
            {
                salesTtlSt.SectionCode = SectionUtil.ALL_SECTION_CODE;
            }
            // ADD 2008/09/18 不具合対応[5407] ----------<<<<<

            salesTtlSt.EstmateAddUpRemDiv           = NullChgInt(this.EstmateAddUpRemDiv_tComboEditor.Value);   // 見積データ計上残区分
            salesTtlSt.InpAgentDispDiv              = NullChgInt(this.InpAgentDispDiv_tComboEditor.Value);      // 発行者表示区分
            salesTtlSt.CustOrderNoDispDiv           = NullChgInt(this.CustOrderNoDispDiv_tComboEditor.Value);   // 得意先注番表示区分
            salesTtlSt.CarMngNoDispDiv              = NullChgInt(this.CarMngNoDispDiv_tComboEditor.Value);      // 車輌管理番号表示区分
            // --- ADD 2009/10/19 ---------->>>>> 
            salesTtlSt.PriceSelectDispDiv           = NullChgInt(this.PriceSelectDispDiv_tComboEditor.Value);   //表示区分プロセス
            // --- ADD 2009/10/19 ----------<<<<<

            salesTtlSt.AcpOdrInputDiv               = NullChgInt(this.AcpOdrInputDiv_tComboEditor.Value);       // ADD 2010/01/29 受注数入力を追加
            salesTtlSt.InpAgentChkDiv               = NullChgInt(this.InpAgentChkDiv_tComboEditor.Value);       // ADD 2010/05/04 発行者チェック区分を追加
            salesTtlSt.InpWarehChkDiv               = NullChgInt(this.InpWarehChkDiv_tComboEditor.Value);       // ADD 2010/05/04 入力倉庫チェック区分を追加
            salesTtlSt.BrSlipNote3DispDiv           = NullChgInt(this.BrSlipNote3DispDiv_tComboEditor.Value);   // 伝票備考３表示区分
            salesTtlSt.SlipDateClrDivCd             = NullChgInt(this.SlipDateClrDivCd_tComboEditor.Value);     // 伝票日付クリア区分
            salesTtlSt.AutoEntryGoodsDivCd          = NullChgInt(this.AutoEntryGoodsDivCd_tComboEditor.Value);  // 商品自動登録
            salesTtlSt.CostCheckDivCd               = NullChgInt(this.CostCheckDivCd_tComboEditor.Value);       // 原価チェック区分
            salesTtlSt.JoinInitDispDiv              = NullChgInt(this.JoinInitDispDiv_tComboEditor.Value);      // 結合初期表示区分
            salesTtlSt.AutoDepositCd                = NullChgInt(this.AutoDepositCd_tComboEditor.Value);        // 自動入金区分
            salesTtlSt.SubstCondDivCd               = NullChgInt(this.SubstCondDivCd_tComboEditor.Value);       // 代替条件区分
            salesTtlSt.SlipCreateProcess            = NullChgInt(this.SlipCreateProcess_tComboEditor.Value);    // 伝票作成方法
            salesTtlSt.WarehouseChkDiv              = NullChgInt(this.WarehouseChkDiv_tComboEditor.Value);      // 倉庫チェック区分
            salesTtlSt.PartsSearchDivCd             = NullChgInt(this.PartsSearchDivCd_tComboEditor.Value);     // 部品検索区分
            salesTtlSt.GrsProfitDspCd               = NullChgInt(this.GrsProfitDspCd_tComboEditor.Value);       // 粗利表示区分
            salesTtlSt.PartsSearchPriDivCd          = NullChgInt(this.PartsSearchPriDivCd_tComboEditor.Value);  // 部品検索優先順区分
            salesTtlSt.SalesStockDiv                = NullChgInt(this.SalesStockDiv_tComboEditor.Value);        // 売上仕入区分
            salesTtlSt.PrtBLGoodsCodeDiv            = NullChgInt(this.PrtBLGoodsCodeDiv_tComboEditor.Value);    // 印刷用BL商品コード区分
            salesTtlSt.SectDspDivCd                 = NullChgInt(this.SectDspDivCd_tComboEditor.Value);         // 拠点表示区分
            salesTtlSt.GoodsNmReDispDivCd           = NullChgInt(this.GoodsNmReDispDivCd_tComboEditor.Value);   // 商品名再表示区分
            salesTtlSt.CostDspDivCd                 = NullChgInt(this.CostDspDivCd_tComboEditor.Value);         // 原価表示区分
            salesTtlSt.DepoSlipDateClrDiv           = NullChgInt(this.DepoSlipDateClrDiv_tComboEditor.Value);   // 入金伝票日付クリア区分
            salesTtlSt.DepoSlipDateAmbit            = NullChgInt(this.DepoSlipDateAmbit_tComboEditor.Value);    // 入金伝票日付範囲区分
            // --- ADD 2017/04/13 譚洪 Redmine#49283---------->>>>>
            salesTtlSt.StockEmpRefDiv               = NullChgInt(this.StockEmpRefDiv_tComboEditor.Value);    // 仕入担当参照区分
            // --- ADD 2017/04/13 譚洪 Redmine#49283----------<<<<<
            // --- ADD 2008/06/09 --------------------------------<<<<< 

            salesTtlSt.AutoDepositNoteDiv           = NullChgInt(this.AutoDepositNoteDiv_tComboEditor1.Value);  // 自動入金備考区分 // ADD cheq 2013/01/21 Redmine#33797 
            // --- ADD 2008/07/22 -------------------------------->>>>>
            salesTtlSt.InpGrsProfChkLower = this.InpGrsProfChkLower_tNedit.GetValue();                    // 入力粗利チェック下限
            salesTtlSt.InpGrsProfChkUpper = this.InpGrsProfChkUpper_tNedit.GetValue();                    // 入力粗利チェック上限
            salesTtlSt.InpGrsProfChkLowDiv = NullChgInt(this.InpGrsProfChkLowDiv_tComboEditor.Value);     // 入力粗利チェック下限区分
            salesTtlSt.InpGrsProfChkUppDiv = NullChgInt(this.InpGrsProfChkUppDiv_tComboEditor.Value);     // 入力粗利チェック上限区分
            // --- ADD 2008/07/22 --------------------------------<<<<<

            // ADD 2008/09/29 不具合対応[5665]---------->>>>>
            salesTtlSt.SubstApplyDivCd  = NullChgInt(this.SubstApplyDivCd_tComboEditor.Value);
            salesTtlSt.PrmSubstCondDivCd= NullChgInt(this.PrmSubstCondDivCd_tComboEditor.Value);
            // ADD 2008/09/29 不具合対応[5665]----------<<<<<

            // ADD 2008/11/05 不具合対応[7101] 品名表示区分の追加 ---------->>>>>
            salesTtlSt.PartsNameDspDivCd = NullChgInt(this.partsNameDspDivCdTComboEditor.Value);    // 品名表示区分
            // ADD 2008/11/05 不具合対応[7101] 品名表示区分の追加 ----------<<<<<
            salesTtlSt.BLGoodsCdDerivNoDiv = NullChgInt(this.BLGoodsCdDerivNoDiv_tComboEditor.Value);    // BLコード枝番

            // --- ADD 2010/04/30-------------------------------->>>>>
            salesTtlSt.FrSrchPrtAutoEntDiv = NullChgInt(this.FrSrchPrtAutoEntDiv_tComboEditor.Value);   // 自由検索部品自動登録区分
            // --- ADD 2010/04/30 --------------------------------<<<<<

            // ADD 2010/05/14 品名表示対応：品名表示区分の詳細設定を追加 ---------->>>>>
            // 品番表示パターン（BLコード検索品名表示区分、品番検索品名表示区分、優良部品検索品名使用区分）
            PartsNameDspPatternForm.SetToSalesTtlSt(salesTtlSt);
            // ADD 2010/05/14 品名表示対応：品名表示区分の詳細設定を追加 ----------<<<<<

            // --- ADD 2010/08/04 ---------->>>>> 
            salesTtlSt.DwnPLCdSpDivCd = NullChgInt(this.DwnPLCdSpDivCd_tComboEditor.Value);   //小数点表示区分
            // --- ADD 2010/08/04 ----------<<<<<

            // --- ADD 2011/06/07 ---------->>>>> 
            salesTtlSt.SalesCdDspDivCd = NullChgInt(this.SalesCdDspDivCd_tComboEditor.Value);   //販売区分表示区分
            // --- ADD 2011/06/07 ----------<<<<<

            // --- ADD 2012/04/23 ---------->>>>> 
            salesTtlSt.RentStockDiv = NullChgInt(this.RentStockDiv_tComboEditor.Value);   //貸出仕入区分
            // --- ADD 2012/04/23 ----------<<<<<
 
            // --- ADD 2012/12/27 Y.Wakita ---------->>>>>
            salesTtlSt.EpPartsNoPrtCd = NullChgInt(this.EpPartsNoPrtCd_tComboEditor.Value);     // 自社品番印字区分

            salesTtlSt.EpPartsNoAddChar = this.EpPartsNoAddChar_tEdit.Text;                     // 自社品番付加文字
            // --- ADD 2012/12/27 Y.Wakita ----------<<<<<
            // --- ADD 2013/01/16 Y.Wakita ---------->>>>>
            salesTtlSt.PrintGoodsNoDef = NullChgInt(this.PrintGoodsNoDef_tComboEditor.Value);   // 印字品番初期値
            // --- ADD 2013/01/16 Y.Wakita ----------<<<<<
            // --- ADD 2013/01/15 ---------->>>>>
            salesTtlSt.StockRetGoodsPlnDiv = NullChgInt(this.StockRetGoodsPlnDiv_tComboEditor.Value); // 仕入返品予定機能区分
            // --- ADD 2013/01/15 ----------<<<<<
            // --- ADD 2013/02/05 Y.Wakita ---------->>>>>
            salesTtlSt.BLGoodsCdZeroSuprt = NullChgInt(this.BLGoodsCdZeroSuprt_tComboEditor.Value);     // BLコード０対応

            salesTtlSt.BLGoodsCdChange = NullChgInt(BLGoodsCdChange_tNedit.GetInt());                     // 変換コード
            // --- ADD 2013/02/05 Y.Wakita ----------<<<<<
        }

		/// <summary>
		/// 画面展開処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : 売上全体設定クラスから画面にデータを展開します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.12.06</br>
        /// <br>Update Note: 2009/10/19 朱俊成 表示区分プロセスを追加</br>
        /// <br>Update Note: 2010/01/29 李侠 受注数入力を追加</br>
        /// <br>Update Note: 2010/04/30 姜凱 自由検索部品自動登録区分を追加</br>        
        /// <br>Update Note: 2010/05/04 王海立 発行者チェック区分、入力倉庫チェック区分を追加</br>
        /// <br>Update Note: 2010/08/04 楊明俊 小数点表示区分を追加</br>
        /// <br>Update Note: 2010/12/03 田建委 障害対応12月</br>
        /// <br>Update Note: 2011/06/07 22008 長内数馬 販売区分表示区分を追加</br>
        /// <br>Update Note: 2012/04/23 管理NO.611 福田康夫 貸出仕入区分を追加</br>
        /// <br>Update Note: 2013/01/15 FSI福原 一樹 仕入返品予定機能区分を追加</br>
        /// <br>Update Note: 2013/01/21 cheq</br>
        /// <br>管理番号   : 10806793-00 2013/03/13配信分</br>
        /// <br>             Redmine#33797 自動入金備考区分を追加</br>
        /// <br>管理番号   : 11370030-00 2017/04/13 譚洪</br>
        /// <br>             Redmine#49283 仕入担当参照区分を追加</br>
        /// </remarks>
        private void SalesTtlStToScreen(SalesTtlSt salesTtlSt)
		{
			this.SalesSlipPrtDiv_tComboEditor.Value		= salesTtlSt.SalesSlipPrtDiv;		// 売上伝票発行区分
			this.ShipmSlipPrtDiv_tComboEditor.Value		= salesTtlSt.ShipmSlipPrtDiv;		// 出荷伝票発行区分
			//this.ZeroPrtDiv_tComboEditor.Value			= salesTtlSt.ZeroPrtDiv;			// ゼロ円印刷区分    // DEL 2008/07/22
			this.ShipmSlipUnPrcPrtDiv_tComboEditor.Value = salesTtlSt.ShipmSlipUnPrcPrtDiv;	// 出荷伝票単価印刷区分

            // --- DEL 2008/07/22 -------------------------------->>>>>
            //this.IoGoodsCntDiv_tComboEditor.Value		= salesTtlSt.IoGoodsCntDiv;			// 入出荷数区分
            ////----- ueno add---------- start 2008.02.26
            //this.IoGoodsCntDiv2_tComboEditor.Value		= salesTtlSt.IoGoodsCntDiv2;		// 入出荷数区分２
            ////----- ueno add---------- end 2008.02.26
            //this.SalesFormalIn_tComboEditor.Value		= salesTtlSt.SalesFormalIn;			// 売上形式初期値
            //this.StockDetailConf_tComboEditor.Value		= salesTtlSt.StockDetailConf;		// 仕入明細確認
            // --- DEL 2008/07/22 --------------------------------<<<<< 

			this.GrsProfitCheckLower_tNedit.SetValue(salesTtlSt.GrsProfitCheckLower);		// 粗利チェック下限
			this.GrsProfitCheckBest_tNedit.SetValue(salesTtlSt.GrsProfitCheckBest);			// 粗利チェック適正
			this.GrsProfitCheckUpper_tNedit.SetValue(salesTtlSt.GrsProfitCheckUpper);		// 粗利チェック上限
			this.GrsProfitChkLowSign_tEdit.Text			= salesTtlSt.GrsProfitChkLowSign;	// 粗利チェック下限記号
			this.GrsProfitChkBestSign_tEdit.Text		= salesTtlSt.GrsProfitChkBestSign;	// 粗利チェック適正記号
			this.GrsProfitChkUprSign_tEdit.Text			= salesTtlSt.GrsProfitChkUprSign;	// 粗利チェック上限記号
			this.GrsProfitChkMaxSign_tEdit.Text			= salesTtlSt.GrsProfitChkMaxSign;	// 粗利チェック最大記号

			this.SalesAgentChngDiv_tComboEditor.Value	= salesTtlSt.SalesAgentChngDiv;		// 売上担当変更区分
			this.AcpOdrAgentDispDiv_tComboEditor.Value	= salesTtlSt.AcpOdrAgentDispDiv;	// 受注者表示区分
			this.BrSlipNote2DispDiv_tComboEditor.Value	= salesTtlSt.BrSlipNote2DispDiv;	// 伝票備考２表示区分
			this.DtlNoteDispDiv_tComboEditor.Value		= salesTtlSt.DtlNoteDispDiv;		// 明細備考表示区分
			this.UnPrcNonSettingDiv_tComboEditor.Value	= salesTtlSt.UnPrcNonSettingDiv;	// 売価未設定時区分
			this.AcpOdrrAddUpRemDiv_tComboEditor.Value	= salesTtlSt.AcpOdrrAddUpRemDiv;	// 受注データ計上残区分
            this.ShipmAddUpRemDiv_tComboEditor.Value    = salesTtlSt.ShipmAddUpRemDiv;		//// 出荷データ計上残区分 // DEL 2010/12/03 // 貸出データ計上残区分 // ADD 2010/12/03
			this.RetGoodsStockEtyDiv_tComboEditor.Value	= salesTtlSt.RetGoodsStockEtyDiv;	// 返品時在庫登録区分
			this.ListPriceSelectDiv_tComboEditor.Value	= salesTtlSt.ListPriceSelectDiv;	// 定価選択区分
			this.MakerInpDiv_tComboEditor.Value			= salesTtlSt.MakerInpDiv;			// メーカー入力区分
			this.BLGoodsCdInpDiv_tComboEditor.Value		= salesTtlSt.BLGoodsCdInpDiv;		// BL商品コード入力区分
			this.SupplierInpDiv_tComboEditor.Value		= salesTtlSt.SupplierInpDiv;		// 仕入先入力区分
			this.SupplierSlipDelDiv_tComboEditor.Value	= salesTtlSt.SupplierSlipDelDiv;	// 仕入伝票削除区分
			this.CustGuideDispDiv_tComboEditor.Value	= salesTtlSt.CustGuideDispDiv;		// 得意先ガイド初期値表示区分

			this.SlipChngDivDate_tComboEditor.Value		= salesTtlSt.SlipChngDivDate;		// 伝票修正区分（日付）
			this.SlipChngDivCost_tComboEditor.Value		= salesTtlSt.SlipChngDivCost;		// 伝票修正区分（原価）

            // ---------- ADD 2010/12/03 ------------------------------>>>>>
            if (salesTtlSt.SlipChngDivUnPrc == 3)
            {
                salesTtlSt.SlipChngDivUnPrc -= 1;
            }
            // ---------- ADD 2010/12/03 ------------------------------<<<<<
			this.SlipChngDivUnPrc_tComboEditor.Value	= salesTtlSt.SlipChngDivUnPrc;		// 伝票修正区分（売価）
			this.SlipChngDivLPrice_tComboEditor.Value	= salesTtlSt.SlipChngDivLPrice;		// 伝票修正区分（定価）

            // 2008.12.11 30413 犬飼 返品伝票修正区分を追加 >>>>>>START
            this.RetSlipChngDivCost_tComboEditor.Value = salesTtlSt.RetSlipChngDivCost;     // 返品伝票修正区分（原価）

            // ---------- ADD 2010/12/03 ------------------------------>>>>>
            if (salesTtlSt.RetSlipChngDivUnPrc == 3)
            {
                salesTtlSt.RetSlipChngDivUnPrc -= 1;
            }
            // ---------- ADD 2010/12/03 ------------------------------<<<<<
            this.RetSlipChngDivUnPrc_tComboEditor.Value = salesTtlSt.RetSlipChngDivUnPrc;   // 返品伝票修正区分（売価）
            // 2008.12.11 30413 犬飼 返品伝票修正区分を追加 <<<<<<END
            
			//----- ueno add---------- start 2008.02.18
			this.AutoDepoKindCode_tComboEditor.Value	= salesTtlSt.AutoDepoKindCode;		// 自動入金金種コード
			this.AutoDepoKindDivCd_tNedit.SetInt(salesTtlSt.AutoDepoKindDivCd);				// 自動入金金種区分（隠し項目）

			if (this.AutoDepoKindCode_tComboEditor.Value != null)
			{
				AutoDepoKindCodeVisibleChange((Int32)this.AutoDepoKindCode_tComboEditor.Value);		// 自動入金金種名称設定
			}
			//----- ueno add---------- end 2008.02.18

			//----- ueno add---------- start 2008.02.26
			this.DiscountName_tEdit.Text				= salesTtlSt.DiscountName;			// 値引名称
			//----- ueno add---------- end 2008.02.26

            // --- ADD 2008/06/09 -------------------------------->>>>>
            this.tEdit_SectionCodeAllowZero2.Value = salesTtlSt.SectionCode.TrimEnd();  // 拠点コード
            // 拠点名称
            foreach (SecInfoSet si in this._secInfoAcs.SecInfoSetList)
            {
                if (si.SectionCode.TrimEnd() == salesTtlSt.SectionCode.TrimEnd())
                {
                    this.SectionNm_tEdit.Value = si.SectionGuideNm;
                    break;
                }
            }
            // ADD 2008/11/13 不具合対応[7770]------------>>>>>
            if (salesTtlSt.SectionCode.TrimEnd().Equals("0") ||
                salesTtlSt.SectionCode.TrimEnd().Equals("00"))
            {
                this.SectionNm_tEdit.Value = "全社共通";
            }
            // ADD 2008/11/13 不具合対応[7770]------------<<<<<

            this.EstmateAddUpRemDiv_tComboEditor.Value = salesTtlSt.EstmateAddUpRemDiv;     // 見積データ計上残区分
            this.InpAgentDispDiv_tComboEditor.Value = salesTtlSt.InpAgentDispDiv;           // 発行者表示区分
            this.CustOrderNoDispDiv_tComboEditor.Value = salesTtlSt.CustOrderNoDispDiv;     // 得意先注番表示区分
            this.CarMngNoDispDiv_tComboEditor.Value = salesTtlSt.CarMngNoDispDiv;           // 車輌管理番号表示区分
            // --- ADD 2009/10/19 ---------->>>>> 
            this.PriceSelectDispDiv_tComboEditor.Value = salesTtlSt.PriceSelectDispDiv;      //表示区分プロセス
            // --- ADD 2009/10/19 ----------<<<<<
            this.AcpOdrInputDiv_tComboEditor.Value = salesTtlSt.AcpOdrInputDiv;             // ADD 2010/01/29 受注数入力を追加
            this.InpAgentChkDiv_tComboEditor.Value = salesTtlSt.InpAgentChkDiv;             // ADD 2010/05/04 発行者チェック区分を追加
            this.InpWarehChkDiv_tComboEditor.Value = salesTtlSt.InpWarehChkDiv;             // ADD 2010/05/04 入力倉庫チェック区分を追加
            this.BrSlipNote3DispDiv_tComboEditor.Value = salesTtlSt.BrSlipNote3DispDiv;     // 伝票備考３表示区分
            this.SlipDateClrDivCd_tComboEditor.Value = salesTtlSt.SlipDateClrDivCd;         // 伝票日付クリア区分
            this.AutoEntryGoodsDivCd_tComboEditor.Value = salesTtlSt.AutoEntryGoodsDivCd;   // 商品自動登録
            this.CostCheckDivCd_tComboEditor.Value = salesTtlSt.CostCheckDivCd;             // 原価チェック区分
            this.JoinInitDispDiv_tComboEditor.Value = salesTtlSt.JoinInitDispDiv;           // 結合初期表示区分
            this.AutoDepositCd_tComboEditor.Value = salesTtlSt.AutoDepositCd;               // 自動入金区分
            this.SubstCondDivCd_tComboEditor.Value = salesTtlSt.SubstCondDivCd;             // 代替条件区分
            this.AutoDepositNoteDiv_tComboEditor1.Value = salesTtlSt.AutoDepositNoteDiv;    // 自動入金備考区分 // ADD cheq 2013/01/21 Redmine#33797

            // ADD 2008/09/29 不具合対応[5665]---------->>>>>
            this.SubstApplyDivCd_tComboEditor.Value = salesTtlSt.SubstApplyDivCd;           // 代替適用区分（ユーザー代替適用区分）
            this.PrmSubstCondDivCd_tComboEditor.Value = salesTtlSt.PrmSubstCondDivCd;       // 優良代替条件区分
            // ADD 2008/09/29 不具合対応[5665]----------<<<<<

            this.partsNameDspDivCdTComboEditor.Value = salesTtlSt.PartsNameDspDivCd;        // ADD 2008/11/05 不具合対応[7101] 品名表示区分の追加

            this.SlipCreateProcess_tComboEditor.Value = salesTtlSt.SlipCreateProcess;       // 伝票作成方法
            this.WarehouseChkDiv_tComboEditor.Value = salesTtlSt.WarehouseChkDiv;           // 倉庫チェック区分
            this.PartsSearchDivCd_tComboEditor.Value = salesTtlSt.PartsSearchDivCd;         // 部品検索区分
            this.GrsProfitDspCd_tComboEditor.Value = salesTtlSt.GrsProfitDspCd;             // 粗利表示区分
            this.PartsSearchPriDivCd_tComboEditor.Value = salesTtlSt.PartsSearchPriDivCd;   // 部品検索優先順区分
            this.SalesStockDiv_tComboEditor.Value = salesTtlSt.SalesStockDiv;               // 売上仕入区分
            this.PrtBLGoodsCodeDiv_tComboEditor.Value = salesTtlSt.PrtBLGoodsCodeDiv;       // 印刷用BL商品コード区分
            this.SectDspDivCd_tComboEditor.Value = salesTtlSt.SectDspDivCd;                 // 拠点表示区分
            this.GoodsNmReDispDivCd_tComboEditor.Value = salesTtlSt.GoodsNmReDispDivCd;     // 商品名再表示区分
            this.CostDspDivCd_tComboEditor.Value = salesTtlSt.CostDspDivCd;                 // 原価表示区分
            this.DepoSlipDateClrDiv_tComboEditor.Value = salesTtlSt.DepoSlipDateClrDiv;     // 入金伝票日付クリア区分
            this.DepoSlipDateAmbit_tComboEditor.Value = salesTtlSt.DepoSlipDateAmbit;       // 入金伝票日付範囲区分
            // --- ADD 2008/06/09 --------------------------------<<<<< 
            // --- ADD 2017/04/13 譚洪 Redmine#49283---------->>>>>
            this.StockEmpRefDiv_tComboEditor.Value = salesTtlSt.StockEmpRefDiv;             // 仕入担当参照区分
            // --- ADD 2017/04/13 譚洪 Redmine#49283----------<<<<<
            // --- ADD 2008/07/22 -------------------------------->>>>>
            this.InpGrsProfChkLower_tNedit.SetValue(salesTtlSt.InpGrsProfChkLower);         // 入力粗利チェック下限
            this.InpGrsProfChkUpper_tNedit.SetValue(salesTtlSt.InpGrsProfChkUpper);         // 入力粗利チェック上限
            this.InpGrsProfChkLowDiv_tComboEditor.Value = salesTtlSt.InpGrsProfChkLowDiv;   // 入力粗利チェック下限区分
            this.InpGrsProfChkUppDiv_tComboEditor.Value = salesTtlSt.InpGrsProfChkUppDiv;   // 入力粗利チェック上限区分
            // --- ADD 2008/07/22 --------------------------------<<<<< 

            this.BLGoodsCdDerivNoDiv_tComboEditor.Value = salesTtlSt.BLGoodsCdDerivNoDiv;   // BLコード枝番区分

            // --- ADD 2010/04/30-------------------------------->>>>>
            this.FrSrchPrtAutoEntDiv_tComboEditor.Value = salesTtlSt.FrSrchPrtAutoEntDiv;     // 自由検索部品自動登録区分 
            // --- ADD 2010/04/30 --------------------------------<<<<<

            // ADD 2010/05/14 品名表示対応：品名表示区分の詳細設定を追加 ---------->>>>>
            // 品名表示パターン（BLコード検索品名表示区分、本番検索品名表示区分、優良部品検索品名使用区分）を設定
            PartsNameDspPatternForm.SetPatterns(salesTtlSt);
            // ADD 2010/05/14 品名表示対応：品名表示区分の詳細設定を追加 ----------<<<<<
            // --- ADD 2010/08/04 ---------->>>>> 
            this.DwnPLCdSpDivCd_tComboEditor.Value = salesTtlSt.DwnPLCdSpDivCd;      //小数点表示区分
            // --- ADD 2010/08/04 ----------<<<<<
            // --- ADD 2011/06/07 ---------->>>>> 
            this.SalesCdDspDivCd_tComboEditor.Value = salesTtlSt.SalesCdDspDivCd;      //販売区分表示区分
            // --- ADD 2011/06/07 ----------<<<<<
            // --- ADD 2012/04/23 ---------->>>>> 
            this.RentStockDiv_tComboEditor.Value = salesTtlSt.RentStockDiv;    //貸出仕入区分
            // --- ADD 2012/04/23 ----------<<<<<
            // --- ADD 2012/12/27 Y.Wakita ---------->>>>>
            this.EpPartsNoPrtCd_tComboEditor.Value = salesTtlSt.EpPartsNoPrtCd;     //優良番印刷品番代替
            this.EpPartsNoAddChar_tEdit.Text = salesTtlSt.EpPartsNoAddChar;         //自社品番付加文字
            // --- ADD 2012/12/27 Y.Wakita ----------<<<<<
            // --- ADD 2013/01/16 Y.Wakita ---------->>>>>
            this.PrintGoodsNoDef_tComboEditor.Value = salesTtlSt.PrintGoodsNoDef;   //印字品番初期値
            // --- ADD 2013/01/16 Y.Wakita ----------<<<<<
            // --- ADD 2013/01/15 ---------->>>>>
            this.StockRetGoodsPlnDiv_tComboEditor.Value = salesTtlSt.StockRetGoodsPlnDiv;// 仕入返品予定機能区分
            // --- ADD 2013/01/15 ----------<<<<<
            // --- ADD 2013/02/05 Y.Wakita ---------->>>>>
            this.BLGoodsCdZeroSuprt_tComboEditor.Value = salesTtlSt.BLGoodsCdZeroSuprt;     //BLコード０対応
            this.BLGoodsCdChange_tNedit.SetInt(salesTtlSt.BLGoodsCdChange);         //変換コード
            // --- ADD 2013/02/05 Y.Wakita ----------<<<<<
        }

        /// <summary>
        /// 売上全体設定オブジェクト展開処理
        /// </summary>
        /// <param name="estimateDefSet">売上全体設定オブジェクト</param>
        /// <param name="index">データセットへ展開するインデックス</param>
        /// <remarks>
        /// <br>Note       : 売上全体設定クラスをDataSetに格納します。</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/09</br>
        /// <br>Update Note: 2009/10/19 朱俊成 表示区分プロセスを追加</br>
        /// <br>Update Note: 2010/01/29 李侠　受注数入力を追加</br>
        /// <br>Update Note: 2010/04/30 姜凱 自由検索部品自動登録区分を追加</br>         
        /// <br>Update Note: 2010/05/04 王海立 発行者チェック区分、入力倉庫チェック区分を追加</br>
        /// <br>Update Note: 2010/08/04 楊明俊 小数点表示区分を追加</br>
        /// <br>Update Note: 2010/12/03 田建委 障害対応12月</br>
        /// <br>Update Note: 2011/06/07 22008 長内数馬 販売区分表示区分を追加</br>
        /// <br>Update Note: 2012/04/23 管理NO.611 福田康夫 貸出仕入区分を追加</br>
        /// <br>Update Note: 2013/01/15 FSI福原 一樹 仕入返品予定機能区分を追加</br>
        /// <br>Update Note: 2013/01/21 cheq</br>
        /// <br>管理番号   : 10806793-00 2013/03/13配信分</br>
        /// <br>             Redmine#33797 自動入金備考区分を追加</br>
        /// <br>管理番号   : 11370030-00 2017/04/13 譚洪</br>
        /// <br>             Redmine#49283 仕入担当参照区分を追加</br>
        /// </remarks>
        private void SalesTtlStToDataSet(SalesTtlSt salesTtlSt, int index)
        {
            if ((index < 0) || (index >= this.Bind_DataSet.Tables[SALESTTLST_TABLE].Rows.Count))
            {
                // 新規と判断し、行を追加する。
                DataRow dataRow = this.Bind_DataSet.Tables[SALESTTLST_TABLE].NewRow();
                this.Bind_DataSet.Tables[SALESTTLST_TABLE].Rows.Add(dataRow);

                // indexを最終行番号にする
                index = this.Bind_DataSet.Tables[SALESTTLST_TABLE].Rows.Count - 1;
            }

            // 削除日
            if (salesTtlSt.LogicalDeleteCode == 0)
            {
                this.Bind_DataSet.Tables[SALESTTLST_TABLE].Rows[index][DELETE_DATE] = "";
            }
            else
            {
                this.Bind_DataSet.Tables[SALESTTLST_TABLE].Rows[index][DELETE_DATE] = salesTtlSt.UpdateDateTime;
            }

            // 拠点コード
            this.Bind_DataSet.Tables[SALESTTLST_TABLE].Rows[index][SECTIONCODE_TITLE] = salesTtlSt.SectionCode.TrimEnd();
            // 拠点名称
            foreach (SecInfoSet si in this._secInfoAcs.SecInfoSetList)
            {
                if (si.SectionCode.TrimEnd() == salesTtlSt.SectionCode.TrimEnd())
                {
                    this.Bind_DataSet.Tables[SALESTTLST_TABLE].Rows[index][SECTIONNAME_TITLE] = si.SectionGuideNm;
                    break;
                }
            }

            // ADD 2008/11/13 不具合対応[7770]------------>>>>>
            if (salesTtlSt.SectionCode.TrimEnd().Equals("0") ||
                salesTtlSt.SectionCode.TrimEnd().Equals("00"))
            {
                this.Bind_DataSet.Tables[SALESTTLST_TABLE].Rows[index][SECTIONNAME_TITLE] = "全社共通";
            }
            // ADD 2008/11/13 不具合対応[7770]------------<<<<<

            // 売上伝票発行区分
            this.Bind_DataSet.Tables[SALESTTLST_TABLE].Rows[index][SalesSlipPrtDiv_Label.Text] = SalesTtlSt.GetComboBoxNm(salesTtlSt.SalesSlipPrtDiv, SalesTtlSt._yesNoList);

            // 出荷伝票発行区分
            this.Bind_DataSet.Tables[SALESTTLST_TABLE].Rows[index][ShipmSlipPrtDiv_Label.Text] = SalesTtlSt.GetComboBoxNm(salesTtlSt.ShipmSlipPrtDiv, SalesTtlSt._yesNoList);

            // --- DEL 2008/07/22 -------------------------------->>>>>
            //// ゼロ円印刷区分
            //this.Bind_DataSet.Tables[SALESTTLST_TABLE].Rows[index][ZeroPrtDiv_Label.Text] = SalesTtlSt.GetComboBoxNm(salesTtlSt.ZeroPrtDiv, SalesTtlSt._yesNoList);
            // --- DEL 2008/07/22 --------------------------------<<<<< 

            // DEL 2009/01/14 不具合対応[9947] ↓貸出伝票単価印刷区分は削除
            //// 貸出伝票単価印刷区分
            //this.Bind_DataSet.Tables[SALESTTLST_TABLE].Rows[index][ShipmSlipUnPrcPrtDiv_Label.Text] = SalesTtlSt.GetComboBoxNm(salesTtlSt.ShipmSlipUnPrcPrtDiv, SalesTtlSt._noYesList);

            // --- DEL 2008/07/22 -------------------------------->>>>>
            //// 入出荷数区分
            //this.Bind_DataSet.Tables[SALESTTLST_TABLE].Rows[index][IoGoodsCntDiv_Label.Text] = SalesTtlSt.GetComboBoxNm(salesTtlSt.IoGoodsCntDiv, SalesTtlSt._alarmList);

            //// 入出荷数区分２
            //this.Bind_DataSet.Tables[SALESTTLST_TABLE].Rows[index][IoGoodsCntDiv2_Label.Text] = SalesTtlSt.GetComboBoxNm(salesTtlSt.IoGoodsCntDiv2, SalesTtlSt._alarmList);

            //// 売上形式初期値
            //this.Bind_DataSet.Tables[SALESTTLST_TABLE].Rows[index][SalesFormalIn_Label.Text] = SalesTtlSt.GetComboBoxNm(salesTtlSt.SalesFormalIn, SalesTtlSt._salesShipmList);

            //// 仕入明細確認
            //this.Bind_DataSet.Tables[SALESTTLST_TABLE].Rows[index][StockDetailConf_Label.Text] = SalesTtlSt.GetComboBoxNm(salesTtlSt.StockDetailConf, SalesTtlSt._optNecessaryList);
            // --- DEL 2008/07/22 --------------------------------<<<<< 

            // 粗利チェック下限
            this.Bind_DataSet.Tables[SALESTTLST_TABLE].Rows[index][GrsProfitCheckLower_Label.Text] = salesTtlSt.GrsProfitCheckLower;

            // 粗利チェック適正
            this.Bind_DataSet.Tables[SALESTTLST_TABLE].Rows[index][GrsProfitCheckBest_Label.Text] = salesTtlSt.GrsProfitCheckBest;

            // 粗利チェック上限
            this.Bind_DataSet.Tables[SALESTTLST_TABLE].Rows[index][GrsProfitCheckUpper_Label.Text] = salesTtlSt.GrsProfitCheckUpper;

            // 粗利チェック下限記号
            this.Bind_DataSet.Tables[SALESTTLST_TABLE].Rows[index][GrsProfitChkLowSign_Label.Text] = salesTtlSt.GrsProfitChkLowSign;

            // 粗利チェック適正記号
            this.Bind_DataSet.Tables[SALESTTLST_TABLE].Rows[index][GrsProfitChkBestSign_Label.Text] = salesTtlSt.GrsProfitChkBestSign;

            // 粗利チェック上限記号
            this.Bind_DataSet.Tables[SALESTTLST_TABLE].Rows[index][GrsProfitChkUprSign_Label.Text] = salesTtlSt.GrsProfitChkUprSign;

            // 粗利チェック最大記号
            this.Bind_DataSet.Tables[SALESTTLST_TABLE].Rows[index][GrsProfitChkMaxSign_Label.Text] = salesTtlSt.GrsProfitChkMaxSign;

            // 売上担当変更区分
            this.Bind_DataSet.Tables[SALESTTLST_TABLE].Rows[index][SalesAgentChngDiv_Label.Text] = SalesTtlSt.GetComboBoxNm(salesTtlSt.SalesAgentChngDiv, SalesTtlSt._enableAlarmList);

            // 受注者表示区分
            // 2008.12.04 modify start [8598]
            //this.Bind_DataSet.Tables[SALESTTLST_TABLE].Rows[index][AcpOdrAgentDispDiv_Label.Text] = SalesTtlSt.GetComboBoxNm(salesTtlSt.AcpOdrAgentDispDiv, SalesTtlSt._onOffNecessaryList);
            // 2009.03.09 30413 犬飼 データビュー表示時のコンボボックスを修正 >>>>>>START
            //this.Bind_DataSet.Tables[SALESTTLST_TABLE].Rows[index][AcpOdrAgentDispDiv_Label.Text] = SalesTtlSt.GetComboBoxNm(salesTtlSt.AcpOdrAgentDispDiv, SalesTtlSt._yesNoList);
            this.Bind_DataSet.Tables[SALESTTLST_TABLE].Rows[index][AcpOdrAgentDispDiv_Label.Text] = SalesTtlSt.GetComboBoxNm(salesTtlSt.AcpOdrAgentDispDiv, SalesTtlSt._inpAgentDispDivList);
            // 2009.03.09 30413 犬飼 データビュー表示時のコンボボックスを修正 <<<<<<END
            
            // 伝票備考２表示区分
            //this.Bind_DataSet.Tables[SALESTTLST_TABLE].Rows[index][BrSlipNote2DispDiv_Label.Text] = SalesTtlSt.GetComboBoxNm(salesTtlSt.BrSlipNote2DispDiv, SalesTtlSt._onOffList);
            this.Bind_DataSet.Tables[SALESTTLST_TABLE].Rows[index][BrSlipNote2DispDiv_Label.Text] = SalesTtlSt.GetComboBoxNm(salesTtlSt.BrSlipNote2DispDiv, SalesTtlSt._yesNoList);

            // 明細備考表示区分
            //this.Bind_DataSet.Tables[SALESTTLST_TABLE].Rows[index][DtlNoteDispDiv_Label.Text] = SalesTtlSt.GetComboBoxNm(salesTtlSt.DtlNoteDispDiv, SalesTtlSt._onOffList);
            this.Bind_DataSet.Tables[SALESTTLST_TABLE].Rows[index][DtlNoteDispDiv_Label.Text] = SalesTtlSt.GetComboBoxNm(salesTtlSt.DtlNoteDispDiv, SalesTtlSt._yesNoList);
            // 2008.12.04 modify end [8598]

            // 売価未設定時区分
            this.Bind_DataSet.Tables[SALESTTLST_TABLE].Rows[index][UnPrcNonSettingDiv_Label.Text] = SalesTtlSt.GetComboBoxNm(salesTtlSt.UnPrcNonSettingDiv, SalesTtlSt._zeroLPriceList);

            // 見積データ計上残区分
            this.Bind_DataSet.Tables[SALESTTLST_TABLE].Rows[index][EstmateAddUpRemDiv_Label.Text] = SalesTtlSt.GetComboBoxNm(salesTtlSt.EstmateAddUpRemDiv, SalesTtlSt._reserveList);

            // 受注データ計上残区分
            this.Bind_DataSet.Tables[SALESTTLST_TABLE].Rows[index][AcpOdrrAddUpRemDiv_Label.Text] = SalesTtlSt.GetComboBoxNm(salesTtlSt.AcpOdrrAddUpRemDiv, SalesTtlSt._reserveList);

            //// 出荷データ計上残区分 // DEL 2010/12/03
            // 貸出データ計上残区分 // ADD 2010/12/03
            this.Bind_DataSet.Tables[SALESTTLST_TABLE].Rows[index][ShipmAddUpRemDiv_Label.Text] = SalesTtlSt.GetComboBoxNm(salesTtlSt.ShipmAddUpRemDiv, SalesTtlSt._reserveList);

            // 返品時在庫登録区分
            this.Bind_DataSet.Tables[SALESTTLST_TABLE].Rows[index][RetGoodsStockEtyDiv_Label.Text] = SalesTtlSt.GetComboBoxNm(salesTtlSt.RetGoodsStockEtyDiv, SalesTtlSt._yesNoList);

            // 定価選択区分
            this.Bind_DataSet.Tables[SALESTTLST_TABLE].Rows[index][ListPriceSelectDiv_Label.Text] = SalesTtlSt.GetComboBoxNm(salesTtlSt.ListPriceSelectDiv, SalesTtlSt._noYesList);

            // メーカー入力区分
            this.Bind_DataSet.Tables[SALESTTLST_TABLE].Rows[index][MakerInpDiv_Label.Text] = SalesTtlSt.GetComboBoxNm(salesTtlSt.MakerInpDiv, SalesTtlSt._optNecessaryList);

            // BL商品コード入力区分
            this.Bind_DataSet.Tables[SALESTTLST_TABLE].Rows[index][BLGoodsCdInpDiv_Label.Text] = SalesTtlSt.GetComboBoxNm(salesTtlSt.BLGoodsCdInpDiv, SalesTtlSt._optNecessaryList);

            // 仕入先入力区分
            this.Bind_DataSet.Tables[SALESTTLST_TABLE].Rows[index][SupplierInpDiv_Label.Text] = SalesTtlSt.GetComboBoxNm(salesTtlSt.SupplierInpDiv, SalesTtlSt._optNecessaryList);

            // 仕入伝票削除区分
            this.Bind_DataSet.Tables[SALESTTLST_TABLE].Rows[index][SupplierSlipDelDiv_Label.Text] = SalesTtlSt.GetComboBoxNm(salesTtlSt.SupplierSlipDelDiv, SalesTtlSt._noConfYesList);

            // 得意先ガイド初期表示区分
            this.Bind_DataSet.Tables[SALESTTLST_TABLE].Rows[index][CustGuideDispDiv_Label.Text] = SalesTtlSt.GetComboBoxNm(salesTtlSt.CustGuideDispDiv, SalesTtlSt._dispList);

            // 2008.12.11 30413 犬飼 コンボ名称の取得リストを変更 >>>>>>START
            // 伝票修正区分（日付）
            //this.Bind_DataSet.Tables[SALESTTLST_TABLE].Rows[index][SlipChngDivDate_Label.Text] = SalesTtlSt.GetComboBoxNm(salesTtlSt.SlipChngDivDate, SalesTtlSt._slipChngDivList);
            this.Bind_DataSet.Tables[SALESTTLST_TABLE].Rows[index][SlipChngDivDate_Label.Text] = SalesTtlSt.GetComboBoxNm(salesTtlSt.SlipChngDivDate, SalesTtlSt._slipChngDivStcList);
            // 2008.12.11 30413 犬飼 コンボ名称の取得リストを変更 <<<<<<END
            
            // 伝票修正区分（原価）
            this.Bind_DataSet.Tables[SALESTTLST_TABLE].Rows[index][SlipChngDivCost_Label.Text] = SalesTtlSt.GetComboBoxNm(salesTtlSt.SlipChngDivCost, SalesTtlSt._slipChngDivList);

            // 伝票修正区分（売価）
            // ---------- ADD 2010/12/03 ------------------------------>>>>>
            if (salesTtlSt.SlipChngDivUnPrc == 2)
            {
                salesTtlSt.SlipChngDivUnPrc += 1;
            }
            // ---------- ADD 2010/12/03 ------------------------------<<<<<
            this.Bind_DataSet.Tables[SALESTTLST_TABLE].Rows[index][SlipChngDivUnPrc_Label.Text] = SalesTtlSt.GetComboBoxNm(salesTtlSt.SlipChngDivUnPrc, SalesTtlSt._slipChngDivList);

            // 伝票修正区分（定価）
            this.Bind_DataSet.Tables[SALESTTLST_TABLE].Rows[index][SlipChngDivLPrice_Label.Text] = SalesTtlSt.GetComboBoxNm(salesTtlSt.SlipChngDivLPrice, SalesTtlSt._slipChngDivStcList);

            // 2008.12.11 30413 犬飼 返品伝票修正区分を追加 >>>>>>START
            // 返品伝票修正区分（原価）
            this.Bind_DataSet.Tables[SALESTTLST_TABLE].Rows[index][RetSlipChngDivCost_Label.Text] = SalesTtlSt.GetComboBoxNm(salesTtlSt.RetSlipChngDivCost, SalesTtlSt._slipChngDivList);

            // 返品伝票修正区分（売価）
            // ---------- ADD 2010/12/03 ------------------------------>>>>>
            if (salesTtlSt.RetSlipChngDivUnPrc == 2)
            {
                salesTtlSt.RetSlipChngDivUnPrc += 1;
            }
            // ---------- ADD 2010/12/03 ------------------------------<<<<<
            this.Bind_DataSet.Tables[SALESTTLST_TABLE].Rows[index][RetSlipChngDivUnPrc_Label.Text] = SalesTtlSt.GetComboBoxNm(salesTtlSt.RetSlipChngDivUnPrc, SalesTtlSt._slipChngDivList);
            // 2008.12.11 30413 犬飼 返品伝票修正区分を追加 <<<<<<END
            
            // 自動入金金種
            this.Bind_DataSet.Tables[SALESTTLST_TABLE].Rows[index][AutoDepoKindCode_Label.Text] = this._salesTtlStAcs.GetAutoDepoKindName(salesTtlSt.AutoDepoKindCode);

            // 自動入金金種区分
            this.Bind_DataSet.Tables[SALESTTLST_TABLE].Rows[index][AutoDepoKindDivCd_Label.Text] = SalesTtlSt.GetComboBoxNm(salesTtlSt.AutoDepoKindDivCd, SalesTtlSt._mnyKindDivList);

            // 値引名称
            this.Bind_DataSet.Tables[SALESTTLST_TABLE].Rows[index][DiscountName_Label.Text] = salesTtlSt.DiscountName;

            // 発行者表示区分
            // 2009.03.09 30413 犬飼 データビュー表示時のコンボボックスを修正 >>>>>>START
            //this.Bind_DataSet.Tables[SALESTTLST_TABLE].Rows[index][InpAgentDispDiv_Label.Text] = SalesTtlSt.GetComboBoxNm(salesTtlSt.InpAgentDispDiv, SalesTtlSt._yesNoList);
            this.Bind_DataSet.Tables[SALESTTLST_TABLE].Rows[index][InpAgentDispDiv_Label.Text] = SalesTtlSt.GetComboBoxNm(salesTtlSt.InpAgentDispDiv, SalesTtlSt._inpAgentDispDivList);
            // 2009.03.09 30413 犬飼 データビュー表示時のコンボボックスを修正 <<<<<<END
            //foreach (DictionaryEntry de in SalesTtlSt._yesNoList)
            //{
            //    if (Int32.Parse(de.Key.ToString()) == salesTtlSt.InpAgentDispDiv)
            //    {
            //        this.Bind_DataSet.Tables[SALESTTLST_TABLE].Rows[index][InpAgentDispDiv_Label.Text] = de.Value;
            //    }
            //}

            // 得意先注番表示区分
            this.Bind_DataSet.Tables[SALESTTLST_TABLE].Rows[index][CustOrderNoDispDiv_Label.Text] = SalesTtlSt.GetComboBoxNm(salesTtlSt.CustOrderNoDispDiv, SalesTtlSt._noYesList);

            // 車輌管理番号表示区分
            this.Bind_DataSet.Tables[SALESTTLST_TABLE].Rows[index][CarMngNoDispDiv_Label.Text] = SalesTtlSt.GetComboBoxNm(salesTtlSt.CarMngNoDispDiv, SalesTtlSt._noYesList);

            // --- ADD 2009/10/19 ---------->>>>>
            // 表示区分プロセス
            this.Bind_DataSet.Tables[SALESTTLST_TABLE].Rows[index][PriceSelectDispDiv_Label.Text] = SalesTtlSt.GetComboBoxNm(salesTtlSt.PriceSelectDispDiv, SalesTtlSt._noYesList);
            // --- ADD 2009/10/19 ----------<<<<<

            // --- ADD 2010/01/29 ---------->>>>>
            // 受注数入力を追加
            this.Bind_DataSet.Tables[SALESTTLST_TABLE].Rows[index][AcpOdrInputDiv_Label.Text] = SalesTtlSt.GetComboBoxNm(salesTtlSt.AcpOdrInputDiv, SalesTtlSt._noYesList);
            // --- ADD 2009/10/19 ----------<<<<<

            // 伝票備考３表示区分
            this.Bind_DataSet.Tables[SALESTTLST_TABLE].Rows[index][BrSlipNote3DispDiv_Label.Text] = SalesTtlSt.GetComboBoxNm(salesTtlSt.BrSlipNote3DispDiv, SalesTtlSt._yesNoList);

            // 伝票日付クリア区分
            this.Bind_DataSet.Tables[SALESTTLST_TABLE].Rows[index][SlipDateClrDivCd_Label.Text] = SalesTtlSt.GetComboBoxNm(salesTtlSt.SlipDateClrDivCd, SalesTtlSt._dateList);

            // 商品自動登録
            // 2008.12.04 modify start [8598]
            //this.Bind_DataSet.Tables[SALESTTLST_TABLE].Rows[index][AutoEntryGoodsDivCd_Label.Text] = SalesTtlSt.GetComboBoxNm(salesTtlSt.AutoEntryGoodsDivCd, SalesTtlSt._autoEntryGoodsDivCdList);
            this.Bind_DataSet.Tables[SALESTTLST_TABLE].Rows[index][AutoEntryGoodsDivCd_Label.Text] = SalesTtlSt.GetComboBoxNm(salesTtlSt.AutoEntryGoodsDivCd, SalesTtlSt._noYesList);
            // 2008.12.04 modify end [8598]

            // 原価チェック区分
            this.Bind_DataSet.Tables[SALESTTLST_TABLE].Rows[index][CostCheckDivCd_Label.Text] = SalesTtlSt.GetComboBoxNm(salesTtlSt.CostCheckDivCd, SalesTtlSt._costCheckDivCdList);

            // 結合初期表示区分
            this.Bind_DataSet.Tables[SALESTTLST_TABLE].Rows[index][JoinInitDispDiv_Label.Text] = SalesTtlSt.GetComboBoxNm(salesTtlSt.JoinInitDispDiv, SalesTtlSt._joinInitDispDivList);

            // 自動入金区分
            this.Bind_DataSet.Tables[SALESTTLST_TABLE].Rows[index][AutoDepositCd_Label.Text] = SalesTtlSt.GetComboBoxNm(salesTtlSt.AutoDepositCd, SalesTtlSt._noYesList);

            // 代替条件区分
            this.Bind_DataSet.Tables[SALESTTLST_TABLE].Rows[index][SubstCondDivCd_Label.Text] = SalesTtlSt.GetComboBoxNm(salesTtlSt.SubstCondDivCd, SalesTtlSt._substCondDivCdList);

            // 伝票作成方法
            this.Bind_DataSet.Tables[SALESTTLST_TABLE].Rows[index][SlipCreateProcess_Label.Text] = SalesTtlSt.GetComboBoxNm(salesTtlSt.SlipCreateProcess, SalesTtlSt._slipCreateProcessList);

            // 倉庫チェック区分
            this.Bind_DataSet.Tables[SALESTTLST_TABLE].Rows[index][WarehouseChkDiv_Label.Text] = SalesTtlSt.GetComboBoxNm(salesTtlSt.WarehouseChkDiv, SalesTtlSt._warehouseChkDivList);

            // 部品検索区分
            this.Bind_DataSet.Tables[SALESTTLST_TABLE].Rows[index][PartsSearchDivCd_Label.Text] = SalesTtlSt.GetComboBoxNm(salesTtlSt.PartsSearchDivCd, SalesTtlSt._partsSearchDivCdList);

            // 粗利表示区分
            this.Bind_DataSet.Tables[SALESTTLST_TABLE].Rows[index][GrsProfitDspCd_Label.Text] = SalesTtlSt.GetComboBoxNm(salesTtlSt.GrsProfitDspCd, SalesTtlSt._yesNoList);

            // 部品検索優先順区分
            this.Bind_DataSet.Tables[SALESTTLST_TABLE].Rows[index][PartsSearchPriDivCd_Label.Text] = SalesTtlSt.GetComboBoxNm(salesTtlSt.PartsSearchPriDivCd, SalesTtlSt._partsSearchPriDivCdList);

            // 売上仕入区分
            this.Bind_DataSet.Tables[SALESTTLST_TABLE].Rows[index][SalesStockDiv_Label.Text] = SalesTtlSt.GetComboBoxNm(salesTtlSt.SalesStockDiv, SalesTtlSt._salesStockDivList);

            // 印刷用BL商品コード区分
            this.Bind_DataSet.Tables[SALESTTLST_TABLE].Rows[index][PrtBLGoodsCodeDiv_Label.Text] = SalesTtlSt.GetComboBoxNm(salesTtlSt.PrtBLGoodsCodeDiv, SalesTtlSt._prtBLGoodsCodeDivList);

            // 拠点表示区分
            this.Bind_DataSet.Tables[SALESTTLST_TABLE].Rows[index][SectDspDivCd_Label.Text] = SalesTtlSt.GetComboBoxNm(salesTtlSt.SectDspDivCd, SalesTtlSt._sectDspDivCdList);

            // 商品名再表示区分
            this.Bind_DataSet.Tables[SALESTTLST_TABLE].Rows[index][GoodsNmReDispDivCd_Label.Text] = SalesTtlSt.GetComboBoxNm(salesTtlSt.GoodsNmReDispDivCd, SalesTtlSt._noYesList);

            // 原価表示区分
            this.Bind_DataSet.Tables[SALESTTLST_TABLE].Rows[index][CostDspDivCd_Label.Text] = SalesTtlSt.GetComboBoxNm(salesTtlSt.CostDspDivCd, SalesTtlSt._noYesList);

            // 入金伝票日付クリア区分
            this.Bind_DataSet.Tables[SALESTTLST_TABLE].Rows[index][DepoSlipDateClrDiv_Label.Text] = SalesTtlSt.GetComboBoxNm(salesTtlSt.DepoSlipDateClrDiv, SalesTtlSt._dateList);

            // 入金伝票日付範囲区分
            this.Bind_DataSet.Tables[SALESTTLST_TABLE].Rows[index][DepoSlipDateAmbit_Label.Text] = SalesTtlSt.GetComboBoxNm(salesTtlSt.DepoSlipDateAmbit, SalesTtlSt._depoSlipDateAmbitList);

            // --- ADD 2008/07/22 -------------------------------->>>>>
            // 入力粗利チェック下限
            this.Bind_DataSet.Tables[SALESTTLST_TABLE].Rows[index][InpGrsPrfChkLow_Label.Text] = salesTtlSt.InpGrsProfChkLower;

            // 入力粗利チェック上限
            this.Bind_DataSet.Tables[SALESTTLST_TABLE].Rows[index][InpGrsPrfChkUpp_Label.Text] = salesTtlSt.InpGrsProfChkUpper;

            // 入力粗利チェック下限区分
            this.Bind_DataSet.Tables[SALESTTLST_TABLE].Rows[index][InpGrsPrfChkLow_Label.Text + "区分"] = SalesTtlSt.GetComboBoxNm(salesTtlSt.InpGrsProfChkLowDiv, SalesTtlSt._inpGrsPrfChkList);

            // 入力粗利チェック上限区分
            this.Bind_DataSet.Tables[SALESTTLST_TABLE].Rows[index][InpGrsPrfChkUpp_Label.Text + "区分"] = SalesTtlSt.GetComboBoxNm(salesTtlSt.InpGrsProfChkUppDiv, SalesTtlSt._inpGrsPrfChkList);
            // --- ADD 2008/07/22 --------------------------------<<<<<

            // ADD 2008/09/29 不具合対応[5665]---------->>>>>
            // 優良代替条件区分
            this.Bind_DataSet.Tables[SALESTTLST_TABLE].Rows[index][this.PrmSubstCondDivCd_Label.Text] = SalesTtlSt.GetComboBoxNm(salesTtlSt.PrmSubstCondDivCd, SalesTtlSt._prmSubstCondDivCdList);

            // 代替適用区分
            this.Bind_DataSet.Tables[SALESTTLST_TABLE].Rows[index][this.SubstApplyDivCd_Label.Text] = SalesTtlSt.GetComboBoxNm(salesTtlSt.SubstApplyDivCd, SalesTtlSt._substApplyDivCdList);
            // ADD 2008/09/29 不具合対応[5665]----------<<<<<

            // ADD 2008/11/05 不具合対応[7101] 品名表示区分の追加 ---------->>>>>
            // 品名表示区分
            this.Bind_DataSet.Tables[SALESTTLST_TABLE].Rows[index][this.partsNameDspDivCdLabel.Text] = SalesTtlSt.GetComboBoxNm(salesTtlSt.PartsNameDspDivCd, SalesTtlSt._partsNameDspDivCdList);
            // ADD 2008/11/05 不具合対応[7101] 品名表示区分の追加 ----------<<<<<

            // BLコード枝番
            this.Bind_DataSet.Tables[SALESTTLST_TABLE].Rows[index][this.BLGoodsCdDerivNoDiv_Label.Text] = SalesTtlSt.GetComboBoxNm(salesTtlSt.BLGoodsCdDerivNoDiv, SalesTtlSt._bLGoodsCdDerivNoDivList);

            // --- ADD 2010/05/04 ---------->>>>>
            // 発行者チェック区分を追加
            this.Bind_DataSet.Tables[SALESTTLST_TABLE].Rows[index][InpAgentChkDiv_Label.Text] = SalesTtlSt.GetComboBoxNm(salesTtlSt.InpAgentChkDiv, SalesTtlSt._inpAgentChkDivList);
            
            // 入力倉庫チェック区分を追加
            this.Bind_DataSet.Tables[SALESTTLST_TABLE].Rows[index][InpWarehChkDiv_Label.Text] = SalesTtlSt.GetComboBoxNm(salesTtlSt.InpWarehChkDiv, SalesTtlSt._inpWarehChkDivList);
            // --- ADD 2010/05/04 ----------<<<<<

            // --- ADD 2010/04/30-------------------------------->>>>>
            // 自由検索部品自動登録区分
            this.Bind_DataSet.Tables[SALESTTLST_TABLE].Rows[index][FrSrchPrtAutoEntDiv_Label.Text] = SalesTtlSt.GetComboBoxNm(salesTtlSt.FrSrchPrtAutoEntDiv, SalesTtlSt._noYesList);
            // --- ADD 2010/04/30 --------------------------------<<<<<

            // --- ADD 2010/08/04 ---------->>>>>
            // 小数点表示区分
            this.Bind_DataSet.Tables[SALESTTLST_TABLE].Rows[index][DwnPLCdSpDivCd_Label.Text] = SalesTtlSt.GetComboBoxNm(salesTtlSt.DwnPLCdSpDivCd, SalesTtlSt._noYesList);
            // --- ADD 2010/08/04 ----------<<<<<

            // --- ADD 2011/06/07 ---------->>>>>
            // 販売区分表示区分
            this.Bind_DataSet.Tables[SALESTTLST_TABLE].Rows[index][SalesCdDspDivCd_Label.Text] = SalesTtlSt.GetComboBoxNm(salesTtlSt.SalesCdDspDivCd, SalesTtlSt._salesCdDspDivCdList);
            // --- ADD 2011/06/07 ----------<<<<<

            // --- ADD 2012/04/23 ---------->>>>>
            // 貸出仕入区分
            this.Bind_DataSet.Tables[SALESTTLST_TABLE].Rows[index][RentStockDiv_Label.Text] = SalesTtlSt.GetComboBoxNm(salesTtlSt.RentStockDiv, SalesTtlSt._rentStockDivList);
            // --- ADD 2012/04/23 ----------<<<<<
            
            // --- ADD 2012/12/27 Y.Wakita ---------->>>>>
            // 自社品番印字区分
            this.Bind_DataSet.Tables[SALESTTLST_TABLE].Rows[index][EpPartsNoPrtCd_Label.Text] = SalesTtlSt.GetComboBoxNm(salesTtlSt.EpPartsNoPrtCd, SalesTtlSt._EpPartsNoPrtCdList);
            
            // 自社品番付加文字
            this.Bind_DataSet.Tables[SALESTTLST_TABLE].Rows[index][EpPartsNoAddChar_Label.Text] = salesTtlSt.EpPartsNoAddChar;
            // --- ADD 2012/12/27 Y.Wakita ----------<<<<<
            // --- ADD 2013/01/16 Y.Wakita ---------->>>>>
            // 印字品番初期値
            this.Bind_DataSet.Tables[SALESTTLST_TABLE].Rows[index][PrintGoodsNoDef_Label.Text] = SalesTtlSt.GetComboBoxNm(salesTtlSt.PrintGoodsNoDef, SalesTtlSt._PrintGoodsNoDefList);
            // --- ADD 2013/01/16 Y.Wakita ----------<<<<<
            // --- ADD 2013/01/15 ---------->>>>>
            // 仕入返品予定機能区分
            this.Bind_DataSet.Tables[SALESTTLST_TABLE].Rows[index][StockRetGoodsPlnDiv_Label.Text] = SalesTtlSt.GetComboBoxNm(salesTtlSt.StockRetGoodsPlnDiv, SalesTtlSt._stockRetGoodsPlnDivList);
            // --- ADD 2013/01/15 ----------<<<<<
            // --- ADD cheq 2013/01/21 Redmine#33797 ----->>>>>
            // 自動入金備考区分
            this.Bind_DataSet.Tables[SALESTTLST_TABLE].Rows[index][AutoDepositNoteDiv_Label.Text] = SalesTtlSt.GetComboBoxNm(salesTtlSt.AutoDepositNoteDiv, SalesTtlSt._autoDepositNoteDivList);
            // --- ADD cheq 2013/01/21 Redmine#33797 -----<<<<<
            // --- ADD 2013/02/05 Y.Wakita ---------->>>>>
            // BLコード０対応
            this.Bind_DataSet.Tables[SALESTTLST_TABLE].Rows[index][BLGoodsCdZeroSuprt_Label.Text] = SalesTtlSt.GetComboBoxNm(salesTtlSt.BLGoodsCdZeroSuprt, SalesTtlSt._BLGoodsCdZeroSuprtList);

            // 変換コード
            int _BLGoodsCdChange = salesTtlSt.BLGoodsCdChange;
            this.Bind_DataSet.Tables[SALESTTLST_TABLE].Rows[index][BLGoodsCdChange_Label.Text] = _BLGoodsCdChange.ToString().Replace("0", "");
            // --- ADD 2013/02/05 Y.Wakita ----------<<<<<

            // --- ADD 2017/04/13 譚洪 Redmine#49283---------->>>>>
            // 仕入担当参照区分
            this.Bind_DataSet.Tables[SALESTTLST_TABLE].Rows[index][StockEmpRefDiv_Label.Text] = SalesTtlSt.GetComboBoxNm(salesTtlSt.StockEmpRefDiv, SalesTtlSt._stockEmpRefDivList);
            // --- ADD 2017/04/13 譚洪 Redmine#49283----------<<<<<

            // GUID
            this.Bind_DataSet.Tables[SALESTTLST_TABLE].Rows[index][GUID_TITLE] = salesTtlSt.FileHeaderGuid;

            if (this._salesTtlStTable.ContainsKey(salesTtlSt.FileHeaderGuid) == true)
            {
                this._salesTtlStTable.Remove(salesTtlSt.FileHeaderGuid);
            }
            this._salesTtlStTable.Add(salesTtlSt.FileHeaderGuid, salesTtlSt);

        }

		/// <summary>
		/// 画面クリア処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : 画面をクリアします。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.12.06</br>
        /// <br>Update Note: 2009/10/19 朱俊成 表示区分プロセスを追加</br>
        /// <br>Update Note: 2010/01/29 李侠　受注数入力を追加</br>
        /// <br>Update Note: 2010/04/30 姜凱 自由検索部品自動登録区分を追加</br>        
        /// <br>Update Note: 2010/05/04 王海立 発行者チェック区分、入力倉庫チェック区分を追加</br>
        /// <br>Update Note: 2010/08/04 楊明俊 小数点表示区分を追加</br>
        /// <br>Update Note: 2011/06/07 22008 長内数馬 販売区分表示区分を追加</br>
        /// <br>Update Note: 2012/04/23 管理NO.611 福田康夫 貸出仕入区分を追加</br>
        /// <br>Update Note: 2013/01/15 FSI福原 一樹 仕入返品予定機能区分を追加</br>
        /// <br>Update Note: 2013/01/21 cheq</br>
        /// <br>管理番号   : 10806793-00 2013/03/13配信分</br>
        /// <br>             Redmine#33797 自動入金備考区分を追加</br>
        /// <br>管理番号   : 11370030-00 2017/04/13 譚洪</br>
        /// <br>             Redmine#49283 仕入担当参照区分を追加</br>
        /// </remarks>
		private void ScreenClear()
		{
			this.SalesSlipPrtDiv_tComboEditor.Value = 0;		// 売上伝票発行区分
			this.ShipmSlipPrtDiv_tComboEditor.Value = 0;		// 出荷伝票発行区分
			//this.ZeroPrtDiv_tComboEditor.Value = 0;				// ゼロ円印刷区分    // DEL 2008/07/22
			this.ShipmSlipUnPrcPrtDiv_tComboEditor.Value = 0;	// 出荷伝票単価印刷区分

            // --- DEL 2008/07/22 -------------------------------->>>>>
            //this.IoGoodsCntDiv_tComboEditor.Value = 0;			// 入出荷数区分
            ////----- ueno add---------- start 2008.02.26
            //this.IoGoodsCntDiv2_tComboEditor.Value = 0;			// 入出荷数区分２
            ////----- ueno add---------- end 2008.02.26
            //this.SalesFormalIn_tComboEditor.Value = 0;			// 売上形式初期値
            //this.StockDetailConf_tComboEditor.Value = 0;		// 仕入明細確認
            // --- DEL 2008/07/22 --------------------------------<<<<< 

			this.GrsProfitCheckLower_tNedit.Clear();			// 粗利チェック下限
			this.GrsProfitCheckBest_tNedit.Clear();				// 粗利チェック適正
			this.GrsProfitCheckUpper_tNedit.Clear();			// 粗利チェック上限
			this.GrsProfitChkLowSign_tEdit.Clear();				// 粗利チェック下限記号
			this.GrsProfitChkBestSign_tEdit.Clear();			// 粗利チェック適正記号
			this.GrsProfitChkUprSign_tEdit.Clear();				// 粗利チェック上限記号
			this.GrsProfitChkMaxSign_tEdit.Clear();				// 粗利チェック最大記号

			this.SalesAgentChngDiv_tComboEditor.Value = 0;		// 売上担当変更区分
			this.AcpOdrAgentDispDiv_tComboEditor.Value = 0;		// 受注者表示区分
			this.BrSlipNote2DispDiv_tComboEditor.Value = 0;		// 伝票備考２表示区分
			this.DtlNoteDispDiv_tComboEditor.Value = 0;			// 明細備考表示区分
			this.UnPrcNonSettingDiv_tComboEditor.Value = 0;		// 売価未設定時区分
			this.AcpOdrrAddUpRemDiv_tComboEditor.Value = 0;		// 受注データ計上残区分
            this.ShipmAddUpRemDiv_tComboEditor.Value = 0;		//// 出荷データ計上残区分 // DEL 2010/12/03 // 貸出データ計上残区分 // ADD 2010/12/03
			this.RetGoodsStockEtyDiv_tComboEditor.Value = 0;	// 返品時在庫登録区分
			this.ListPriceSelectDiv_tComboEditor.Value = 0;		// 定価選択区分
			this.MakerInpDiv_tComboEditor.Value = 0;			// メーカー入力区分
			this.BLGoodsCdInpDiv_tComboEditor.Value = 0;		// BL商品コード入力区分
			this.SupplierInpDiv_tComboEditor.Value = 0;			// 仕入先入力区分
			this.SupplierSlipDelDiv_tComboEditor.Value = 0;		// 仕入伝票削除区分
			this.CustGuideDispDiv_tComboEditor.Value = 0;		// 得意先ガイド初期値表示区分

			this.SlipChngDivDate_tComboEditor.Value = 0;		// 伝票修正区分（日付）
			this.SlipChngDivCost_tComboEditor.Value = 0;		// 伝票修正区分（原価）
			this.SlipChngDivUnPrc_tComboEditor.Value = 0;		// 伝票修正区分（売価）
			this.SlipChngDivLPrice_tComboEditor.Value = 0;		// 伝票修正区分（定価）

            // 2008.12.11 30413 犬飼 返品伝票修正区分を追加 >>>>>>START
            this.RetSlipChngDivCost_tComboEditor.Value = 0;     // 返品伝票修正区分（原価）
            this.RetSlipChngDivUnPrc_tComboEditor.Value = 0;    // 返品伝票修正区分（売価）
            // 2008.12.11 30413 犬飼 返品伝票修正区分を追加 <<<<<<END
            
			//----- ueno add---------- start 2008.02.18
			// 自動入金金種初期値取得
			int autoDepoKindCodeFirst = 0;
			if((SalesTtlSt._autoDepoKindCodeList != null)&&(SalesTtlSt._autoDepoKindCodeList.Count > 0))
			{
				autoDepoKindCodeFirst = (int)SalesTtlSt._autoDepoKindCodeList.GetKey(0);
			}
			this.AutoDepoKindCode_tComboEditor.Value = autoDepoKindCodeFirst;	// 自動入金金種コード

			this.AutoDepoKindDivCdNm_tEdit.Clear();				// 自動入金金種区分名称
			this.AutoDepoKindDivCd_tNedit.Clear();				// 自動入金金種区分（隠し項目）
			
			this._autoDepoKindCode_tComboEditorValue = -1;	// 自動入金金種コードコンボボックスデータワーク
			//----- ueno add---------- end 2008.02.18

			//----- ueno add---------- start 2008.02.26
			this.DiscountName_tEdit.Clear();					// 値引名称
			//----- ueno add---------- end 2008.02.26

            // --- ADD 2008/06/09 -------------------------------->>>>>
            this.tEdit_SectionCodeAllowZero2.Clear();                           // 拠点コード
            this.SectionNm_tEdit.Clear();                             // 拠点ガイド名称

            this.EstmateAddUpRemDiv_tComboEditor.SelectedIndex = 0;   // 見積データ計上残区分
            this.InpAgentDispDiv_tComboEditor.SelectedIndex = 0;      // 発行者表示区分
            this.CustOrderNoDispDiv_tComboEditor.SelectedIndex = 0;   // 得意先注番表示区分
            this.CarMngNoDispDiv_tComboEditor.SelectedIndex = 0;      // 車輌管理番号表示区分
            // --- ADD 2009/10/19 ---------->>>>>
            this.PriceSelectDispDiv_tComboEditor.SelectedIndex = 0;   // 表示区分プロセス
            // --- ADD 2009/10/19 ----------<<<<<
            this.AcpOdrInputDiv_tComboEditor.SelectedIndex = 1;   　　// ADD 2010/01/29 受注数入力を追加
            this.InpAgentChkDiv_tComboEditor.SelectedIndex = 0;   　　// ADD 2010/05/04 発行者チェック区分を追加
            this.InpWarehChkDiv_tComboEditor.SelectedIndex = 0;   　　// ADD 2010/05/04 入力倉庫チェック区分を追加
            this.BrSlipNote3DispDiv_tComboEditor.SelectedIndex = 0;   // 伝票備考３表示区分
            this.SlipDateClrDivCd_tComboEditor.SelectedIndex = 0;     // 伝票日付クリア区分
            this.AutoEntryGoodsDivCd_tComboEditor.SelectedIndex = 0;  // 商品自動登録
            this.CostCheckDivCd_tComboEditor.SelectedIndex = 0;       // 原価チェック区分
            this.JoinInitDispDiv_tComboEditor.SelectedIndex = 0;      // 結合初期表示区分
            this.AutoDepositCd_tComboEditor.SelectedIndex = 0;        // 自動入金区分
            this.SubstCondDivCd_tComboEditor.SelectedIndex = 0;       // 代替条件区分
            this.SlipCreateProcess_tComboEditor.SelectedIndex = 0;    // 伝票作成方法
            this.WarehouseChkDiv_tComboEditor.SelectedIndex = 0;      // 倉庫チェック区分
            this.PartsSearchDivCd_tComboEditor.SelectedIndex = 0;     // 部品検索区分
            this.GrsProfitDspCd_tComboEditor.SelectedIndex = 0;       // 粗利表示区分
            this.PartsSearchPriDivCd_tComboEditor.SelectedIndex = 0;  // 部品検索優先順区分
            this.SalesStockDiv_tComboEditor.SelectedIndex = 0;        // 売上仕入区分
            this.PrtBLGoodsCodeDiv_tComboEditor.SelectedIndex = 0;    // 印刷用BL商品コード区分
            this.SectDspDivCd_tComboEditor.SelectedIndex = 0;         // 拠点表示区分
            this.GoodsNmReDispDivCd_tComboEditor.SelectedIndex = 0;   // 商品名再表示区分
            this.CostDspDivCd_tComboEditor.SelectedIndex = 0;         // 原価表示区分
            this.DepoSlipDateClrDiv_tComboEditor.SelectedIndex = 0;   // 入金伝票日付クリア区分
            this.DepoSlipDateAmbit_tComboEditor.SelectedIndex = 0;    // 入金伝票日付範囲区分
            // --- ADD 2017/04/13 譚洪 Redmine#49283---------->>>>>
            this.StockEmpRefDiv_tComboEditor.SelectedIndex = 0;    // 仕入担当参照区分
            // --- ADD 2017/04/13 譚洪 Redmine#49283----------<<<<<

            // --- ADD 2008/06/09 --------------------------------<<<<< 
            this.AutoDepositNoteDiv_tComboEditor1.SelectedIndex = 0;  // 自動入金備考区分 // ADD cheq 2013/01/21 Redmine#33797 

            // --- ADD 2008/07/22 -------------------------------->>>>>
            InpGrsProfChkUppDiv_tComboEditor.SelectedIndex = 0; // 入力粗利チェック上限区分
            InpGrsProfChkLowDiv_tComboEditor.SelectedIndex = 0; // 入力粗利チェック下限区分
            InpGrsProfChkUpper_tNedit.Clear();                  // 入力粗利チェック上限  
            InpGrsProfChkLower_tNedit.Clear();                  // 入力粗利チェック下限
            // --- ADD 2008/07/22 --------------------------------<<<<< 

            BLGoodsCdDerivNoDiv_tComboEditor.SelectedIndex = 0; // BLコード枝番区分

            // --- ADD 2010/04/30-------------------------------->>>>>
            this.FrSrchPrtAutoEntDiv_tComboEditor.SelectedIndex = 0;   // 自由検索部品自動登録区分
            // --- ADD 2010/04/30 --------------------------------<<<<<
            // --- ADD 2010/08/04 ---------->>>>>
            this.DwnPLCdSpDivCd_tComboEditor.SelectedIndex = 0;   // 小数点表示区分
            // --- ADD 2010/08/04 ----------<<<<<
            // --- ADD 2011/06/07 ---------->>>>>
            this.SalesCdDspDivCd_tComboEditor.SelectedIndex = 0;   // 販売区分表示区分
            // --- ADD 2011/06/07 ----------<<<<<
            // --- ADD 2012/04/23 ---------->>>>>
            this.RentStockDiv_tComboEditor.SelectedIndex = 0;   // 貸出仕入区分
            // --- ADD 2012/04/23 ----------<<<<<
            // --- ADD 2012/12/27 Y.Wakita ---------->>>>>
            this.EpPartsNoPrtCd_tComboEditor.SelectedIndex = 0;     // 自社品番印字区分
            this.EpPartsNoAddChar_tEdit.Clear();                    // 自社品番付加文字
            // --- ADD 2012/12/27 Y.Wakita ----------<<<<<
            // --- ADD 2013/01/16 Y.Wakita ---------->>>>>
            this.PrintGoodsNoDef_tComboEditor.SelectedIndex = 0;    // 印字品番初期値
            // --- ADD 2013/01/16 Y.Wakita ----------<<<<<
            // --- ADD 2013/01/15 ---------->>>>>
            this.StockRetGoodsPlnDiv_tComboEditor.SelectedIndex = 0; // 仕入返品予定機能区分
            // --- ADD 2013/01/15 ----------<<<<<
            // --- ADD 2013/02/05 Y.Wakita ---------->>>>>
            this.BLGoodsCdZeroSuprt_tComboEditor.SelectedIndex = 0;     // BLコード０対応
            this.BLGoodsCdChange_tNedit.Clear();                    // 変換コード
            // --- ADD 2013/02/05 Y.Wakita ----------<<<<<
        }

		/// <summary>
		/// 画面再構築処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : 画面を再構築します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.12.06</br>
        /// <br>Update Note: 2010/01/29 李侠　受注数入力を追加</br>
        /// <br>Update Note: 2010/04/30 姜凱 自由検索部品自動登録区分を追加</br>        
        /// <br>Update Note: 2010/05/04 王海立 発行者チェック区分、入力倉庫チェック区分を追加</br>
		/// </remarks>
		private void ScreenReconstruction()
		{
            /* --- DEL 2008/06/09 -------------------------------->>>>>
			const string ctPROCNM = "ScreenReconstruction";
			int status = 0;

			this._salesTtlSt = new SalesTtlSt();

			// 売上全体設定データ取得
			status = this._salesTtlStAcs.Read( out this._salesTtlSt, this._enterpriseCode );

			if( status == ( int )ConstantManagement.DB_Status.ctDB_NORMAL ) {
				if( this._salesTtlSt == null ) {
					this._salesTtlSt = new SalesTtlSt();
				}

				this.Mode_Label.Text = UPDATE_MODE;

				// 売上全体設定画面展開処理
				this.SalesTtlStToScreen();
				
				// 比較用クローン作成
				this._salesTtlStClone = this._salesTtlSt.Clone();
				
				// 画面情報を比較用クローンにコピー
				this.DispToSalesTtlSt( ref this._salesTtlStClone );

				// 初期フォーカスをセット
				this.SalesSlipPrtDiv_tComboEditor.Focus();
			}
			else {
				// リード
				TMsgDisp.Show( 
					this,                                 // 親ウィンドウフォーム
					emErrorLevel.ERR_LEVEL_STOP,          // エラーレベル
					CT_PGID,                              // アセンブリＩＤまたはクラスＩＤ
					CT_PGNM,                              // プログラム名称
					ctPROCNM,                             // 処理名称
					TMsgDisp.OPE_READ,                    // オペレーション
					"読み込みに失敗しました。",           // 表示するメッセージ
					status,                               // ステータス値
					this._salesTtlStAcs,                  // エラーが発生したオブジェクト
					MessageBoxButtons.OK,                 // 表示するボタン
					MessageBoxDefaultButton.Button1 );    // 初期表示ボタン

				this.Mode_Label.Text = UPDATE_MODE;

				this._salesTtlSt = new SalesTtlSt();

				// 売上全体設定画面展開処理
				this.SalesTtlStToScreen();
				
				// 比較用クローン作成
				this._salesTtlStClone = this._salesTtlSt.Clone();
				
				// 画面情報を比較用クローンにコピー
				this.DispToSalesTtlSt( ref this._salesTtlStClone );

				// 初期フォーカスをセット
				this.SalesSlipPrtDiv_tComboEditor.Focus();
			}
           --- DEL 2008/06/09 --------------------------------<<<<< */

            // --- ADD 2008/06/09 -------------------------------->>>>>
            MainTabControl.SelectedTab = this.MainTabControl.Tabs["Page1Tab"];

            if (this._dataIndex < 0)
            {
                // 新規モード
                this._logicalDeleteMode = -1;

                SalesTtlSt newSalesTtlSt = new SalesTtlSt();

                // 自動入金金種デフォルト設定
                newSalesTtlSt.AutoDepoKindCode = (int)SalesTtlSt._autoDepoKindCodeList.GetKey(0);

                // --- ADD 2010/01/29 ---------->>>>>
                // 受注数入力デフォルト設定
                newSalesTtlSt.AcpOdrInputDiv = 1;
                // --- ADD 2010/01/29 ----------<<<<<

                // --- ADD 2010/05/04 ---------->>>>>
                // 発行者チェック区分デフォルト設定
                newSalesTtlSt.InpAgentChkDiv = 0;

                // 入力倉庫チェック区分デフォルト設定
                newSalesTtlSt.InpWarehChkDiv = 0;
                // --- ADD 2010/05/04 ----------<<<<<
               
                // 売上全体設定オブジェクトを画面に展開
                SalesTtlStToScreen(newSalesTtlSt);

                // ADD 2008/09/26 不具合対応[5409]---------->>>>>
                this.InpGrsProfChkUpper_tNedit.SetValue(INITIAL_INP_GRS_PROF_CHK_UPPER_VALUE);
                this.InpGrsProfChkLower_tNedit.SetValue(INITIAL_INP_GRS_PROF_CHK_LOWER_VALUE);
                // ADD 2008/09/26 不具合対応[5409]----------<<<<<

                // クローン作成
                this._salesTtlStClone = newSalesTtlSt.Clone();
                DispToSalesTtlSt(ref this._salesTtlStClone);
            }
            else
            {
                Guid guid = (Guid)this.Bind_DataSet.Tables[SALESTTLST_TABLE].Rows[this._dataIndex][GUID_TITLE];
                SalesTtlSt salesTtlSt = (SalesTtlSt)this._salesTtlStTable[guid];

                // 売上全体設定オブジェクトを画面に展開
                SalesTtlStToScreen(salesTtlSt);

                if (salesTtlSt.LogicalDeleteCode == 0)
                {
                    // 更新モード
                    this._logicalDeleteMode = 0;

                    // クローン作成
                    this._salesTtlStClone = salesTtlSt.Clone();
                    DispToSalesTtlSt(ref this._salesTtlStClone);
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
            // --- ADD 2008/06/09 --------------------------------<<<<< 
		}

		/// <summary>
		/// 画面入力チェック処理
		/// </summary>
		/// <param name="control">対象コントロール</param>
		/// <param name="message">表示メッセージ</param>
		/// <returns>チェック結果(true: OK, false:NG)</returns>
		/// <remarks>
		/// <br>Note       : 画面の入力チェックを行います。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.12.06</br>
		/// </remarks>
		private bool ScreenDataCheck( ref Control control, ref string message )
		{
            // --- ADD 2008/06/09 -------------------------------->>>>>
            // 拠点コード
            if (this.tEdit_SectionCodeAllowZero2.DataText == "")
            {
                message = this.SectionCode_Title_Label.Text + "を設定して下さい。";
                control = this.tEdit_SectionCodeAllowZero2;
                return false;
            }
            // --- ADD 2008/06/09 --------------------------------<<<<< 

            // --- ADD 2011/09/07 -------------------------------->>>>>
            if (this.tEdit_SectionCodeAllowZero2.DataText != "")
                this.tEdit_SectionCodeAllowZero2.DataText = this.tEdit_SectionCodeAllowZero2.DataText.PadLeft(2, '0');
            // 拠点コードの存在チェック
            bool existCheck = false;

            // 全社共通は拠点マスタに登録されていないため、チェックの対象外
            if (!SectionUtil.IsAllSection(this.tEdit_SectionCodeAllowZero2.DataText))
            {
                foreach (SecInfoSet si in this._secInfoAcs.SecInfoSetList)
                {
                    if (si.SectionCode.TrimEnd() == this.tEdit_SectionCodeAllowZero2.DataText)
                    {
                        existCheck = true;
                        break;
                    }
                }
            }
            else
            {
                existCheck = true;
            }

            if (existCheck)
            {
                ;
            }
            else
            {
                message = "指定した拠点コードは存在しません。";

                control = this.tEdit_SectionCodeAllowZero2;

                return  false;
            }
            // --- ADD 2011/09/07 --------------------------------<<<<<

			// (粗利チェック下限値, 粗利チェック適正値がともに0より大きい場合)
			if ((this.GrsProfitCheckLower_tNedit.GetValue() > 0)&&(this.GrsProfitCheckBest_tNedit.GetValue() > 0))
			{
				// 粗利チェック下限値 >= 粗利チェック適正値の場合エラー
				if (this.GrsProfitCheckLower_tNedit.GetValue() >= this.GrsProfitCheckBest_tNedit.GetValue())
				{
					message = "粗利チェック下限値 < 粗利チェック適正値\nで設定してください。";
					control = this.GrsProfitCheckLower_tNedit;
					return false;
				}
			}

			// (粗利チェック適正値, 粗利チェック上限値がともに0より大きい場合)
			if ((this.GrsProfitCheckBest_tNedit.GetValue() > 0) && (this.GrsProfitCheckUpper_tNedit.GetValue() > 0))
			{
				// 粗利チェック適正値 >= 粗利チェック上限値の場合エラー
				if(this.GrsProfitCheckBest_tNedit.GetValue() >= this.GrsProfitCheckUpper_tNedit.GetValue())
				{
					message = "粗利チェック適正値 < 粗利チェック上限値\nで設定してください。";
					control = this.GrsProfitCheckBest_tNedit;
					return false;
				}
			}

			// (粗利チェック下限値, 粗利チェック上限値がともに0より大きい場合)
			if ((this.GrsProfitCheckLower_tNedit.GetValue() > 0)&&(this.GrsProfitCheckUpper_tNedit.GetValue() > 0))
			{
				// 粗利チェック下限値 >= 粗利チェック上限値の場合エラー
				if(this.GrsProfitCheckLower_tNedit.GetValue() >= this.GrsProfitCheckUpper_tNedit.GetValue())
				{
					message = "粗利チェック下限値 < 粗利チェック上限値\nで設定してください。";
					control = this.GrsProfitCheckLower_tNedit;
					return false;
				}
			}

            // --- ADD 2008/07/22 -------------------------------->>>>>
            // 入力粗利チェック下限 > 入力粗利チェック上限の場合エラー
            if (this.InpGrsProfChkLower_tNedit.GetValue() > this.InpGrsProfChkUpper_tNedit.GetValue())
            {
                message = "入力粗利下限チェック値 < 入力粗利上限チェック値\nで設定してください。";
                control = this.InpGrsProfChkLower_tNedit;
                return false;
            }
            // --- ADD 2008/07/22 --------------------------------<<<<< 

            // ADD 2010/05/14 品名表示対応：品名表示区分の詳細設定を追加 ---------->>>>>
            // UNDONE:品名表示パターン設定のチェック
            // (品名表示区分、BLコード検索品名表示区分1～4、品番検索品名表示区分1～4、優良部品検索品名使用区分)
            if (!PartsNameDspPatternForm.ValidateInput(this.partsNameDspDivCdTComboEditor))
            {
                control = this.ubtnPartsNameDspPattern;
                message = "品名表示区分の詳細設定に重複があります。";
                return false;
            }
            // ADD 2010/05/14 品名表示対応：品名表示区分の詳細設定を追加 ----------<<<<<

            // --- ADD 2012/12/27 Y.Wakita ---------->>>>>
            // 自社品番印字区分が「する」で自社品番付加文字が未設定の場合
            if (this.EpPartsNoPrtCd_tComboEditor.SelectedIndex == 1)
            {
                // 未入力チェック
                if (this.EpPartsNoAddChar_tEdit.DataText == "")
                {
                    message = this.EpPartsNoAddChar_Label.Text + "を設定して下さい。";
                    control = this.EpPartsNoAddChar_tEdit;
                    return false;
                }
                // 有効文字チェック
                else
                {
                    Match result = Regex.Match(this.EpPartsNoAddChar_tEdit.DataText, "^[a-z]+$");
                    if (result.ToString() != this.EpPartsNoAddChar_tEdit.DataText)
                    {
                        message = this.EpPartsNoAddChar_Label.Text + "は半角英字の小文字で設定して下さい。";
                        control = this.EpPartsNoAddChar_tEdit;
                        return false;
                    }
                }

            }
            // --- ADD 2012/12/27 Y.Wakita ----------<<<<<
            // --- ADD 2013/02/05 Y.Wakita ---------->>>>>
            // BLコード０対応が「する」で変換コードが未設定の場合
            if (this.BLGoodsCdZeroSuprt_tComboEditor.SelectedIndex == 1)
            {
                // 未入力チェック
                if (this.BLGoodsCdChange_tNedit.DataText == "")
                {
                    message = this.BLGoodsCdChange_Label.Text + "を設定して下さい。";
                    control = this.BLGoodsCdChange_tNedit;
                    return false;
                }
                // 有効文字チェック
                else
                {
                    Match result = Regex.Match(this.BLGoodsCdChange_tNedit.DataText, "^[0-9]+$");
                    if (result.ToString() != this.BLGoodsCdChange_tNedit.DataText)
                    {
                        message = this.BLGoodsCdChange_Label.Text + "は半角数字で設定して下さい。";
                        control = this.BLGoodsCdChange_Label;
                        return false;
                    }
                }
            }
            // --- ADD 2013/02/05 Y.Wakita ----------<<<<<
            return true;
		}

        /// <summary>
        /// 画面入力許可制御処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面の入力許可を制御します。</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/09</br>
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
                        // --- ADD 2009/03/19 残案件No.14対応------------------------------------------------------>>>>>
                        this.Renewal_Button.Visible = true;
                        // --- ADD 2009/03/19 残案件No.14対応------------------------------------------------------<<<<<

                        // コントロールの表示設定
                        ScreenInputPermissionControl(true);

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
                        // --- ADD 2009/03/19 残案件No.14対応------------------------------------------------------>>>>>
                        this.Renewal_Button.Visible = false;
                        // --- ADD 2009/03/19 残案件No.14対応------------------------------------------------------<<<<<

                        // コントロールの表示設定
                        ScreenInputPermissionControl(false);

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
                        // --- ADD 2009/03/19 残案件No.14対応------------------------------------------------------>>>>>
                        this.Renewal_Button.Visible = true;
                        // --- ADD 2009/03/19 残案件No.14対応------------------------------------------------------<<<<<

                        // コントロールの表示設定
                        ScreenInputPermissionControl(true);

                        // 拠点関係のコントロールを使用不可にする
                        tEdit_SectionCodeAllowZero2.Enabled = false;
                        SectionGd_ultraButton.Enabled = false;
                        SectionNm_tEdit.Enabled = false;

                        // 拠点コードのコメント非表示
                        SectionNm_Label.Visible = false;

                        // 初期フォーカスをセット
                        //this.SalesFormalIn_tComboEditor.Focus();    // DEL 2008/07/22
                        this.SlipCreateProcess_tComboEditor.Focus();  // ADD 2008/07/22

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
        /// <br>Date       : 2008/06/09</br>
        /// <br>Update Note: 2009/10/19 朱俊成 表示区分プロセスを追加</br>
        /// <br>Update Note: 2010/01/29 李侠　受注数入力を追加</br>
        /// <br>Update Note: 2010/05/04 王海立 発行者チェック区分、入力倉庫チェック区分を追加</br>
        /// <br>Update Note: 2010/08/04 楊明俊 小数点表示区分を追加</br>
        /// <br>Update Note: 2011/06/07 22008 長内数馬 販売区分表示区分を追加</br>
        /// <br>Update Note: 2012/04/23 管理NO.611 福田康夫 貸出仕入区分を追加</br>
        /// <br>Update Note: 2013/01/15 FSI福原 一樹 仕入返品予定機能区分を追加</br>
        /// <br>Update Note: 2013/01/21 cheq</br>
        /// <br>管理番号   : 10806793-00 2013/03/13配信分</br>
        /// <br>             Redmine#33797 自動入金備考区分を追加</br>
        /// <br>管理番号   : 11370030-00 2017/04/13 譚洪</br>
        /// <br>             Redmine#49283 仕入担当参照区分を追加</br>
        /// </remarks>
        void ScreenInputPermissionControl(bool enabled)
        {
            this.tEdit_SectionCodeAllowZero2.Enabled = enabled;                   // 拠点コード
            this.SectionGd_ultraButton.Enabled = enabled;               // ガイドボタン 
            this.SectionNm_tEdit.Enabled = enabled;                     // 拠点ガイド名称

            this.SalesSlipPrtDiv_tComboEditor.Enabled = enabled;		// 売上伝票発行区分
            this.ShipmSlipPrtDiv_tComboEditor.Enabled = enabled;		// 出荷伝票発行区分
            //this.ZeroPrtDiv_tComboEditor.Enabled = enabled;			// ゼロ円印刷区分        // DEL 2008/07/22
            this.ShipmSlipUnPrcPrtDiv_tComboEditor.Enabled = enabled;	// 出荷伝票単価印刷区分

            // --- DEL 2008/07/22 -------------------------------->>>>>
            //this.IoGoodsCntDiv_tComboEditor.Enabled = enabled;			// 入出荷数区分
            //this.IoGoodsCntDiv2_tComboEditor.Enabled = enabled;		// 入出荷数区分２
            //this.SalesFormalIn_tComboEditor.Enabled = enabled;			// 売上形式初期値
            //this.StockDetailConf_tComboEditor.Enabled = enabled;		// 仕入明細確認
            // --- DEL 2008/07/22 --------------------------------<<<<< 

            this.GrsProfitCheckLower_tNedit.Enabled = enabled;		// 粗利チェック下限
            this.GrsProfitCheckBest_tNedit.Enabled = enabled;			// 粗利チェック適正
            this.GrsProfitCheckUpper_tNedit.Enabled = enabled;		// 粗利チェック上限
            this.GrsProfitChkLowSign_tEdit.Enabled = enabled;	// 粗利チェック下限記号
            this.GrsProfitChkBestSign_tEdit.Enabled = enabled;	// 粗利チェック適正記号
            this.GrsProfitChkUprSign_tEdit.Enabled = enabled;	// 粗利チェック上限記号
            this.GrsProfitChkMaxSign_tEdit.Enabled = enabled;	// 粗利チェック最大記号

            this.SalesAgentChngDiv_tComboEditor.Enabled = enabled;		// 売上担当変更区分
            this.AcpOdrAgentDispDiv_tComboEditor.Enabled = enabled;	// 受注者表示区分
            this.BrSlipNote2DispDiv_tComboEditor.Enabled = enabled;	// 伝票備考２表示区分
            this.DtlNoteDispDiv_tComboEditor.Enabled = enabled;		// 明細備考表示区分
            this.UnPrcNonSettingDiv_tComboEditor.Enabled = enabled;	// 売価未設定時区分
            this.AcpOdrrAddUpRemDiv_tComboEditor.Enabled = enabled;	// 受注データ計上残区分
            this.ShipmAddUpRemDiv_tComboEditor.Enabled = enabled;		//// 出荷データ計上残区分 // DEL 2010/12/03 // 貸出データ計上残区分 // ADD 2010/12/03
            this.RetGoodsStockEtyDiv_tComboEditor.Enabled = enabled;	// 返品時在庫登録区分
            this.ListPriceSelectDiv_tComboEditor.Enabled = enabled;	// 定価選択区分
            this.MakerInpDiv_tComboEditor.Enabled = enabled;			// メーカー入力区分
            this.BLGoodsCdInpDiv_tComboEditor.Enabled = enabled;		// BL商品コード入力区分
            this.SupplierInpDiv_tComboEditor.Enabled = enabled;		// 仕入先入力区分
            this.SupplierSlipDelDiv_tComboEditor.Enabled = enabled;	// 仕入伝票削除区分
            this.CustGuideDispDiv_tComboEditor.Enabled = enabled;		// 得意先ガイド初期値表示区分

            this.SlipChngDivDate_tComboEditor.Enabled = enabled;		// 伝票修正区分（日付）
            this.SlipChngDivCost_tComboEditor.Enabled = enabled;		// 伝票修正区分（原価）
            this.SlipChngDivUnPrc_tComboEditor.Enabled = enabled;		// 伝票修正区分（売価）
            this.SlipChngDivLPrice_tComboEditor.Enabled = enabled;		// 伝票修正区分（定価）

            // 2008.12.11 30413 犬飼 返品伝票修正区分を追加 >>>>>>START
            this.RetSlipChngDivCost_tComboEditor.Enabled = enabled;     // 返品伝票修正区分（原価）
            this.RetSlipChngDivUnPrc_tComboEditor.Enabled = enabled;    // 返品伝票修正区分（売価）
            // 2008.12.11 30413 犬飼 返品伝票修正区分を追加 <<<<<<END
            
            this.AutoDepoKindCode_tComboEditor.Enabled = enabled;		// 自動入金金種コード
            this.AutoDepoKindDivCd_tNedit.Enabled = enabled;				// 自動入金金種区分（隠し項目）
            this.AutoDepoKindCode_tComboEditor.Enabled = enabled;		// 自動入金金種名称設定
            this.DiscountName_tEdit.Enabled = enabled;			// 値引名称

            this.tEdit_SectionCodeAllowZero2.Enabled = enabled;         // 拠点コード
            this.SectionNm_tEdit.Enabled = enabled;   // 拠点名称

            EstmateAddUpRemDiv_tComboEditor.Enabled = enabled;     // 見積データ計上残区分
            InpAgentDispDiv_tComboEditor.Enabled = enabled;      // 発行者表示区分
            CustOrderNoDispDiv_tComboEditor.Enabled = enabled;   // 得意先注番表示区分
            CarMngNoDispDiv_tComboEditor.Enabled = enabled;      // 車輌管理番号表示区分
            // --- ADD 2009/10/19 ---------->>>>>
            PriceSelectDispDiv_tComboEditor.Enabled = enabled;      //表示区分プロセス
            // --- ADD 2009/10/19 ----------<<<<<
            AcpOdrInputDiv_tComboEditor.Enabled = enabled;       // ADD 2010/01/29 受注数入力を追加
            InpAgentChkDiv_tComboEditor.Enabled = enabled;       // ADD 2010/05/04 発行者チェック区分を追加
            InpWarehChkDiv_tComboEditor.Enabled = enabled;       // ADD 2010/05/04 入力倉庫チェック区分を追加
            BrSlipNote3DispDiv_tComboEditor.Enabled = enabled;   // 伝票備考３表示区分
            SlipDateClrDivCd_tComboEditor.Enabled = enabled;     // 伝票日付クリア区分
            AutoEntryGoodsDivCd_tComboEditor.Enabled = enabled;  // 商品自動登録
            CostCheckDivCd_tComboEditor.Enabled = enabled;       // 原価チェック区分
            JoinInitDispDiv_tComboEditor.Enabled = enabled;      // 結合初期表示区分
            AutoDepositCd_tComboEditor.Enabled = enabled;        // 自動入金区分
            SubstCondDivCd_tComboEditor.Enabled = enabled;       // 代替条件区分
            AutoDepositNoteDiv_tComboEditor1.Enabled = enabled;  // 自動入金備考区分 // ADD cheq 2013/01/21 Redmine#33797
            // ADD 2008/09/29 不具合対応[5665]---------->>>>>
            this.SubstApplyDivCd_tComboEditor.Enabled   = enabled;  // 代替適用区分（ユーザー代替適用区分）
            this.PrmSubstCondDivCd_tComboEditor.Enabled = enabled;  // 優良代替条件区分
            // ADD 2008/09/29 不具合対応[5665]----------<<<<<

            // ADD 2008/11/05 不具合対応[7101] 品名表示区分の追加 ---------->>>>>
            this.partsNameDspDivCdTComboEditor.Enabled = enabled;   // 品名表示区分
            // ADD 2008/11/05 不具合対応[7101] 品名表示区分の追加 ----------<<<<<
            // --- ADD 2013/01/16 Y.Wakita ---------->>>>>
            this.ubtnPartsNameDspPattern.Enabled = enabled;         // 品名表示区分詳細設定ボタン
            // --- ADD 2013/01/16 Y.Wakita ----------<<<<<

            SlipCreateProcess_tComboEditor.Enabled = enabled;    // 伝票作成方法
            WarehouseChkDiv_tComboEditor.Enabled = enabled;      // 倉庫チェック区分
            PartsSearchDivCd_tComboEditor.Enabled = enabled;     // 部品検索区分
            GrsProfitDspCd_tComboEditor.Enabled = enabled;       // 粗利表示区分
            PartsSearchPriDivCd_tComboEditor.Enabled = enabled;  // 部品検索優先順区分
            SalesStockDiv_tComboEditor.Enabled = enabled;        // 売上仕入区分
            PrtBLGoodsCodeDiv_tComboEditor.Enabled = enabled;    // 印刷用BL商品コード区分
            SectDspDivCd_tComboEditor.Enabled = enabled;         // 拠点表示区分
            GoodsNmReDispDivCd_tComboEditor.Enabled = enabled;   // 商品名再表示区分
            CostDspDivCd_tComboEditor.Enabled = enabled;         // 原価表示区分
            DepoSlipDateClrDiv_tComboEditor.Enabled = enabled;   // 入金伝票日付クリア区分
            DepoSlipDateAmbit_tComboEditor.Enabled = enabled;    // 入金伝票日付範囲区分
            // --- ADD 2017/04/13 譚洪 Redmine#49283---------->>>>>
            StockEmpRefDiv_tComboEditor.Enabled = enabled;    // 仕入担当参照区分
            // --- ADD 2017/04/13 譚洪 Redmine#49283----------<<<<<
            // --- ADD 2008/07/22 -------------------------------->>>>>
            InpGrsProfChkUppDiv_tComboEditor.Enabled = enabled;  // 入力粗利チェック上限区分
            InpGrsProfChkLowDiv_tComboEditor.Enabled = enabled;   // 入力粗利チェック下限区分
            InpGrsProfChkUpper_tNedit.Enabled = enabled;         // 入力粗利チェック上限
            InpGrsProfChkLower_tNedit.Enabled = enabled;         // 入力粗利チェック下限
            // --- ADD 2008/07/22 --------------------------------<<<<< 

            BLGoodsCdDerivNoDiv_tComboEditor.Enabled = enabled; // BLコード枝番区分

            // --- ADD 2010/04/30-------------------------------->>>>>
            FrSrchPrtAutoEntDiv_tComboEditor.Enabled = enabled;   // 自由検索部品自動登録区分
            // --- ADD 2010/04/30 --------------------------------<<<<<
            // --- ADD 2010/08/04 ---------->>>>>
            DwnPLCdSpDivCd_tComboEditor.Enabled = enabled;      //小数点表示区分
            // --- ADD 2010/08/04 ----------<<<<<
            // --- ADD 2011/06/07 ---------->>>>>
            SalesCdDspDivCd_tComboEditor.Enabled = enabled;      //販売区分表示区分
            // --- ADD 2011/06/07 ----------<<<<<
            // --- ADD 2012/04/23 ---------->>>>>
            RentStockDiv_tComboEditor.Enabled = enabled;     //貸出仕入区分
            // --- ADD 2012/04/23 ----------<<<<<
            // --- ADD 2012/12/27 Y.Wakita ---------->>>>>
            this.EpPartsNoPrtCd_tComboEditor.Enabled = enabled;		// 自社品番印字区分
            this.EpPartsNoAddChar_tEdit.Enabled = enabled;		    // 自社品番付加文字
            // --- ADD 2013/01/16 Y.Wakita ---------->>>>>
            this.PrintGoodsNoDef_tComboEditor.Enabled = enabled;    // 印字品番初期値
            // --- ADD 2013/01/16 Y.Wakita ----------<<<<<
            // --- ADD 2013/02/05 Y.Wakita ---------->>>>>
            this.BLGoodsCdZeroSuprt_tComboEditor.Enabled = enabled;		// BLコード０対応
            this.BLGoodsCdChange_tNedit.Enabled = enabled;		    // 変換コード
            // --- ADD 2013/02/04 Y.Wakita ----------<<<<<
            if (enabled == true)
            {
                // --- UPD 2013/01/16 Y.Wakita ---------->>>>>
                //// --- UPD 2013/01/09 T.Nishi ---------->>>>>
                ////if (this.EpPartsNoPrtCd_tComboEditor.SelectedIndex == 0)
                //if ((this.EpPartsNoPrtCd_tComboEditor.SelectedIndex == 0)
                //|| (this.EpPartsNoPrtCd_tComboEditor.SelectedIndex == 2))
                //// --- UPD 2013/01/09 T.Nishi ---------->>>>>
                if (this.EpPartsNoPrtCd_tComboEditor.SelectedIndex == 0)
                // --- UPD 2013/01/16 Y.Wakita ----------<<<<<
                {
                    // 「しない」の場合、自社品番付加文字を使用不可
                    this.EpPartsNoAddChar_tEdit.Enabled = false;
                    // --- ADD 2013/01/16 Y.Wakita ---------->>>>>
                    // 印字品番初期値
                    this.PrintGoodsNoDef_tComboEditor.Enabled = false;
                    // --- ADD 2013/01/16 Y.Wakita ----------<<<<<
                }
                else
                {
                    // 「する」の場合、自社品番付加文字を使用可
                    this.EpPartsNoAddChar_tEdit.Enabled = true;
                    // --- ADD 2013/01/16 Y.Wakita ---------->>>>>
                    // 印字品番初期値
                    this.PrintGoodsNoDef_tComboEditor.Enabled = true;
                    // --- ADD 2013/01/16 Y.Wakita ----------<<<<<
                }

                // --- ADD 2013/02/05 Y.Wakita ---------->>>>>
                // BLコード０対応
                if (this.BLGoodsCdZeroSuprt_tComboEditor.SelectedIndex == 0)
                {
                    // 「しない」の場合、変換コードを使用不可
                    this.BLGoodsCdChange_tNedit.Enabled = false;
                }
                else
                {
                    // 「する」の場合、変換コードを使用可
                    this.BLGoodsCdChange_tNedit.Enabled = true;
                }
                // --- ADD 2013/02/05 Y.Wakita ----------<<<<<
            }
            // --- ADD 2012/12/27 Y.Wakita ----------<<<<<

            // --- ADD 2013/01/15 ---------->>>>>
            this.StockRetGoodsPlnDiv_tComboEditor.Enabled = enabled;// 仕入返品予定機能区分
            // --- ADD 2013/01/15 ----------<<<<<

            // ちらつき防止の為
            this.Enabled = true;
        }

		/// <summary>
		/// 保存処理
		/// </summary>
		/// <returns>結果</returns>
		/// <remarks>
		/// <br>Note       : 売上全体設定の保存を行います。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.12.06</br>
		/// </remarks>
		private bool SaveProc()
		{
            /* --- DEL 2008/06/09 -------------------------------->>>>>
			const string ctPROCNM = "SaveProc";
			bool result = false;

			Control control = null;
			string message = null;
			
			if( this.ScreenDataCheck( ref control, ref message ) == false )
			{
				// 入力チェック
				TMsgDisp.Show( 
					this,                                  // 親ウィンドウフォーム
					emErrorLevel.ERR_LEVEL_EXCLAMATION,    // エラーレベル
					CT_PGID,                               // アセンブリＩＤまたはクラスＩＤ
					message,                               // 表示するメッセージ
					0,                                     // ステータス値
					MessageBoxButtons.OK );                // 表示するボタン

				// コントロールを選択
				control.Focus();
				
				return result;
			}

			// 画面から売上全体設定のデータを取得
			this.ScreenToSalesTtlSt();

			int status = 0;
			status = this._salesTtlStAcs.Write( ref this._salesTtlSt );

			switch( status )
			{
				case ( int )ConstantManagement.DB_Status.ctDB_NORMAL:
				{
					result = true;
					break;
				}
				case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE:
				{
					// コード重複
					TMsgDisp.Show( 
						this,                                    // 親ウィンドウフォーム
						emErrorLevel.ERR_LEVEL_INFO,             // エラーレベル
						CT_PGID,                                 // アセンブリＩＤまたはクラスＩＤ
						"このコードは既に使用されています。",    // 表示するメッセージ
						0,                                       // ステータス値
						MessageBoxButtons.OK );                  // 表示するボタン

					return result;
				}
				// 排他制御
				case ( int )ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
				case ( int )ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
				{
					this.ExclusiveTransaction( status, true );
					return result;
				}
				default:
				{
					// 登録失敗
					TMsgDisp.Show( 
						this,                                 // 親ウィンドウフォーム
						emErrorLevel.ERR_LEVEL_STOP,          // エラーレベル
						CT_PGID,                              // アセンブリＩＤまたはクラスＩＤ
						CT_PGNM,                              // プログラム名称
						ctPROCNM,                             // 処理名称
						TMsgDisp.OPE_READ,                    // オペレーション
						"登録に失敗しました。",           // 表示するメッセージ
						status,                               // ステータス値
						this._salesTtlStAcs,                  // エラーが発生したオブジェクト
						MessageBoxButtons.OK,                 // 表示するボタン
						MessageBoxDefaultButton.Button1 );    // 初期表示ボタン

					this.CloseForm( DialogResult.Cancel );

					return result;
				}
			}

			return result;
           --- DEL 2008/06/09 --------------------------------<<<<< */

            // --- ADD 2008/06/09 -------------------------------->>>>>
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
                    "DCKHN09210U", 						// アセンブリＩＤまたはクラスＩＤ
                    message, 							// 表示するメッセージ
                    0, 									// ステータス値
                    MessageBoxButtons.OK);				// 表示するボタン
                // --- DEL 2011/09/07 -------------------------------->>>>>
                //control.Focus();
                //if( control is TNedit ) {
                //    ( ( TNedit )control ).SelectAll();
                //}
                //else if( control is TEdit ) {
                //    ( ( TEdit )control ).SelectAll();
                //}
                // --- DEL 2011/09/07 --------------------------------<<<<<
                // --- ADD 2011/09/07 -------------------------------->>>>>
                //this.tEdit_SectionCodeAllowZero2.Clear();   // DEL 2012/12/27 Y.Wakita
                this.tEdit_SectionCodeAllowZero2.Focus();
                // --- ADD 2011/09/07 --------------------------------<<<<<
                return result;
            }



            // ----- ADD 2011/09/07 ---------->>>>>
            // 拠点
            if (this.tEdit_SectionCodeAllowZero2.Focused)
            {
                ChangeFocusEventArgs eArgs = new ChangeFocusEventArgs(false, false, false, Keys.Enter, this.tEdit_SectionCodeAllowZero2, this.tEdit_SectionCodeAllowZero2);
                this.tEdit_SectionCodeAllowZero2.Text = this.tEdit_SectionCodeAllowZero2.Text.PadLeft(2, '0');
                tArrowKeyControl1_ChangeFocus(null, eArgs);
                if (isError == true)
                {
                    result = false;
                    return result;
                }
            }
            // ----- ADD 2011/09/07 ----------<<<<<

            SalesTtlSt salesTtlSt = null;
            if (this._dataIndex >= 0)
            {
                Guid guid = (Guid)this.Bind_DataSet.Tables[SALESTTLST_TABLE].Rows[this._dataIndex][GUID_TITLE];
                salesTtlSt = ((SalesTtlSt)this._salesTtlStTable[guid]).Clone();
            }
            DispToSalesTtlSt(ref salesTtlSt);

            // ADD 2008/09/18 不具合対応[5404] ---------->>>>>
            // 拠点コードが存在していない場合、登録しない。
            //if (!SectionUtil.ExistsCode(salesTtlSt.SectionCode))// DEL 2011/09/07
            if (!SectionUtil.ExistsCode(salesTtlSt.SectionCode) || salesTtlSt.SectionCode == "0")//ADD 2011/09/07
            {
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
                //this.tEdit_SectionCodeAllowZero2.Focus();    // ADD 2009/01/09 不具合対応[9112] エラー項目をフォーカスする //DEL 2011/09/07
                // --- ADD 2011/09/07 -------------------------------->>>>>
                this.tEdit_SectionCodeAllowZero2.Clear();
                this.tEdit_SectionCodeAllowZero2.Focus();
                // --- ADD 2011/09/07 --------------------------------<<<<<
                return false;
            }
            // ADD 2008/09/18 不具合対応[5404] ----------<<<<<

            int status = this._salesTtlStAcs.Write(ref salesTtlSt);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // VIEWのデータセットを更新
                        SalesTtlStToDataSet(salesTtlSt.Clone(), this._dataIndex);
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE:
                    {
                        // コード重複
                        TMsgDisp.Show(
                            this, 									// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_INFO, 			// エラーレベル
                            "DCKHN09210U", 							// アセンブリＩＤまたはクラスＩＤ
                            "このコードは既に使用されています。", 	// 表示するメッセージ
                            0, 										// ステータス値
                            MessageBoxButtons.OK);					// 表示するボタン
                        tEdit_SectionCodeAllowZero2.Focus();                  // ADD 2008/06/04
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
                            "DCKHN09210U", 						// アセンブリＩＤまたはクラスＩＤ
                            "売上全体設定", 					// プログラム名称
                            "SaveProc", 						// 処理名称
                            TMsgDisp.OPE_UPDATE, 				// オペレーション
                            "登録に失敗しました。", 			// 表示するメッセージ
                            status, 							// ステータス値
                            this._salesTtlStAcs,			    // エラーが発生したオブジェクト
                            MessageBoxButtons.OK, 				// 表示するボタン
                            MessageBoxDefaultButton.Button1);	// 初期表示ボタン
                        CloseForm(DialogResult.Cancel);
                        return result;
                    }
            }

            result = true;
            return result;
            // --- ADD 2008/06/09 --------------------------------<<<<< 
		}

		/// <summary>
		/// 排他処理
		/// </summary>
		/// <param name="status">STATUS</param>
		/// <param name="hide">非表示フラグ(true: 非表示にする, false: 非表示にしない)</param>
		/// <remarks>
		/// <br>Note       : 排他処理を行います</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.12.06</br>
		/// </remarks>
		private void ExclusiveTransaction( int status, bool hide )
		{
			switch( status )
			{
				case ( int )ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
				{
					// 他端末更新
					TMsgDisp.Show( 
						this,                                  // 親ウィンドウフォーム
						emErrorLevel.ERR_LEVEL_EXCLAMATION,    // エラーレベル
						CT_PGID,                               // アセンブリＩＤまたはクラスＩＤ
						"既に他端末より更新されています。",    // 表示するメッセージ
						0,                                     // ステータス値
						MessageBoxButtons.OK );                // 表示するボタン
					if( hide == true ) {
						this.CloseForm( DialogResult.Cancel );
					}
					break;
				}
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
				{
					// 他端末削除
					TMsgDisp.Show( 
						this,                                  // 親ウィンドウフォーム
						emErrorLevel.ERR_LEVEL_EXCLAMATION,    // エラーレベル
						CT_PGID,                               // アセンブリＩＤまたはクラスＩＤ
						"既に他端末より削除されています。",    // 表示するメッセージ
						0,                                     // ステータス値
						MessageBoxButtons.OK );                // 表示するボタン
					if( hide == true ) {
						this.CloseForm( DialogResult.Cancel );
					}
					break;
				}
			}
		}

		/// <summary>
		/// フォームクローズ処理
		/// </summary>
		/// <param name="dialogResult">ダイアログ結果</param>
		/// <remarks>
		/// <br>Note       : フォームを閉じます。その際画面クローズイベント等の発生を行います。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.12.06</br>
		/// </remarks>
		private void CloseForm( DialogResult dialogResult )
		{
			// 画面非表示イベント
			if ( this.UnDisplaying != null )
			{
				MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs( dialogResult );
				this.UnDisplaying( this, me );
			}

			this.DialogResult = dialogResult;

			// 比較用クローンクリア
			this._salesTtlStClone = null;

			// CanCloseプロパティがfalseの場合は、クローズ処理をキャンセルして
			// フォームを非表示化する。
			if( this._canClose == true )
			{
				this.Close();
			}
			else {
				this.Hide();
			}
		}

		/// <summary>
		/// コンボボックス設定
		/// </summary>
		/// <remarks>
		/// <br>Note       : コンボボックスの設定行います</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.12.06</br>
        /// <br>Update Note: 2009/10/19 朱俊成 表示区分プロセスを追加</br>
        /// <br>Update Note: 2010/01/29 李侠　受注数入力を追加</br>
        /// <br>Update Note: 2010/04/30 姜凱 自由検索部品自動登録区分を追加</br>        
        /// <br>Update Note: 2010/05/04 王海立 発行者チェック区分、入力倉庫チェック区分を追加</br>
        /// <br>Update Note: 2010/08/04 楊明俊 小数点表示区分を追加</br>
        /// <br>Update Note: 2010/12/03 田建委 障害対応12月</br>
        /// <br>Update Note: 2011/06/07 22008 長内数馬 販売区分表示区分を追加</br>
        /// <br>Update Note: 2012/04/23 管理NO.611 福田康夫 貸出仕入区分を追加</br>
        /// <br>Update Note: 2013/01/15 FSI福原 一樹 仕入返品予定機能区分を追加</br>
        /// <br>Update Note: 2013/01/21 cheq</br>
        /// <br>管理番号   : 10806793-00 2013/03/13配信分</br>
        /// <br>             Redmine#33797 自動入金備考区分を追加</br>
        /// <br>管理番号   : 11370030-00 2017/04/13 譚洪</br>
        /// <br>             Redmine#49283 仕入担当参照区分を追加</br>
        /// </remarks>
		private void SetComboBox()
		{
			//----------------------
			// コンボボックス初期化
			//----------------------
			this.SalesSlipPrtDiv_tComboEditor.Items.Clear();
			this.ShipmSlipPrtDiv_tComboEditor.Items.Clear();
			//this.ZeroPrtDiv_tComboEditor.Items.Clear();           // DEL 2008/07/22
			this.ShipmSlipUnPrcPrtDiv_tComboEditor.Items.Clear();

            // --- DEL 2008/07/22 -------------------------------->>>>>
            //this.IoGoodsCntDiv_tComboEditor.Items.Clear();
            ////----- ueno add---------- start 2008.02.26
            //this.IoGoodsCntDiv2_tComboEditor.Items.Clear();
            ////----- ueno add---------- end 2008.02.26			
            //this.SalesFormalIn_tComboEditor.Items.Clear();
            //this.StockDetailConf_tComboEditor.Items.Clear();
            // --- DEL 2008/07/22 --------------------------------<<<<< 

			this.SalesAgentChngDiv_tComboEditor.Items.Clear();
			this.AcpOdrAgentDispDiv_tComboEditor.Items.Clear();
			this.BrSlipNote2DispDiv_tComboEditor.Items.Clear();
			this.DtlNoteDispDiv_tComboEditor.Items.Clear();
			this.UnPrcNonSettingDiv_tComboEditor.Items.Clear();
			this.AcpOdrrAddUpRemDiv_tComboEditor.Items.Clear();
			this.ShipmAddUpRemDiv_tComboEditor.Items.Clear();
			this.RetGoodsStockEtyDiv_tComboEditor.Items.Clear();
			this.ListPriceSelectDiv_tComboEditor.Items.Clear();
			this.MakerInpDiv_tComboEditor.Items.Clear();
			this.BLGoodsCdInpDiv_tComboEditor.Items.Clear();
			this.SupplierInpDiv_tComboEditor.Items.Clear();
			this.SupplierSlipDelDiv_tComboEditor.Items.Clear();
			this.CustGuideDispDiv_tComboEditor.Items.Clear();
			this.SlipChngDivDate_tComboEditor.Items.Clear();
			this.SlipChngDivCost_tComboEditor.Items.Clear();
			this.SlipChngDivUnPrc_tComboEditor.Items.Clear();
			this.SlipChngDivLPrice_tComboEditor.Items.Clear();

            // 2008.12.11 30413 犬飼 返品伝票修正区分を追加 >>>>>>START
            this.RetSlipChngDivCost_tComboEditor.Items.Clear();
            this.RetSlipChngDivUnPrc_tComboEditor.Items.Clear();
            // 2008.12.11 30413 犬飼 返品伝票修正区分を追加 <<<<<<END
            
			//----- ueno add---------- start 2008.02.18
			this.AutoDepoKindCode_tComboEditor.Items.Clear();
			//----- ueno add---------- end 2008.02.18

            // --- ADD 2008/06/09 -------------------------------->>>>>
            this.EstmateAddUpRemDiv_tComboEditor.Items.Clear();  // 見積データ計上残区分
            this.InpAgentDispDiv_tComboEditor.Items.Clear();     // 発行者表示区分
            this.CustOrderNoDispDiv_tComboEditor.Items.Clear();  // 得意先注番表示区分
            this.CarMngNoDispDiv_tComboEditor.Items.Clear();     // 車輌管理番号表示区分
            // --- ADD 2009/10/19 ---------->>>>>
            this.PriceSelectDispDiv_tComboEditor.Items.Clear();  // 表示区分プロセス
            // --- ADD 2009/10/19 ----------<<<<<
            this.BrSlipNote3DispDiv_tComboEditor.Items.Clear();  // 伝票備考３表示区分
            this.SlipDateClrDivCd_tComboEditor.Items.Clear();    // 伝票日付クリア区分
            this.AutoEntryGoodsDivCd_tComboEditor.Items.Clear(); // 商品自動登録
            this.CostCheckDivCd_tComboEditor.Items.Clear();      // 原価チェック区分
            this.JoinInitDispDiv_tComboEditor.Items.Clear();     // 結合初期表示区分
            this.AutoDepositCd_tComboEditor.Items.Clear();       // 自動入金区分
            this.SubstCondDivCd_tComboEditor.Items.Clear();      // 代替条件区分
            this.AutoDepositNoteDiv_tComboEditor1.Items.Clear(); // 自動入金備考区分 // ADD cheq 2013/01/21 Redmine#33797

            // ADD 2008/09/29 不具合対応[5665]---------->>>>>
            this.SubstApplyDivCd_tComboEditor.Clear();          // 代替適用区分（ユーザー代替適用区分）
            this.PrmSubstCondDivCd_tComboEditor.Clear();        // 優良代替条件区分
            // ADD 2008/09/29 不具合対応[5665]----------<<<<<

            this.SlipCreateProcess_tComboEditor.Items.Clear();   // 伝票作成方法
            this.WarehouseChkDiv_tComboEditor.Items.Clear();     // 倉庫チェック区分
            this.PartsSearchDivCd_tComboEditor.Items.Clear();    // 部品検索区分
            this.GrsProfitDspCd_tComboEditor.Items.Clear();      // 粗利表示区分
            this.PartsSearchPriDivCd_tComboEditor.Items.Clear(); // 部品検索優先順区分
            this.SalesStockDiv_tComboEditor.Items.Clear();       // 売上仕入区分
            this.PrtBLGoodsCodeDiv_tComboEditor.Items.Clear();   // 印刷用BL商品コード区分
            this.SectDspDivCd_tComboEditor.Items.Clear();        // 拠点表示区分
            this.GoodsNmReDispDivCd_tComboEditor.Items.Clear();  // 商品名再表示区分
            this.CostDspDivCd_tComboEditor.Items.Clear();        // 原価表示区分
            this.DepoSlipDateClrDiv_tComboEditor.Items.Clear();  // 入金伝票日付クリア区分
            this.DepoSlipDateAmbit_tComboEditor.Items.Clear();   // 入金伝票日付範囲区分
            // --- ADD 2008/06/09 --------------------------------<<<<< 
            // --- ADD 2017/04/13 譚洪 Redmine#49283---------->>>>>
            this.DepoSlipDateAmbit_tComboEditor.Items.Clear();   // 仕入担当参照区分
            // --- ADD 2017/04/13 譚洪 Redmine#49283----------<<<<<
            // --- ADD 2008/07/22 -------------------------------->>>>>
            this.InpGrsProfChkLowDiv_tComboEditor.Items.Clear();  // 入力粗利チェック下限区分
            this.InpGrsProfChkUppDiv_tComboEditor.Items.Clear();  // 入力粗利チェック上限区分
            // --- ADD 2008/07/22 --------------------------------<<<<< 

            // --- ADD 2010/04/30-------------------------------->>>>>
            this.FrSrchPrtAutoEntDiv_tComboEditor.Items.Clear();  // 自由検索部品自動登録区分
            // --- ADD 2010/04/30 --------------------------------<<<<<
            // --- ADD 2010/08/04 ---------->>>>>
            this.DwnPLCdSpDivCd_tComboEditor.Items.Clear();  // 小数点表示区分
            // --- ADD 2010/08/04 ----------<<<<<
            // --- ADD 2011/06/07 ---------->>>>>
            this.SalesCdDspDivCd_tComboEditor.Items.Clear();  // 販売区分表示区分
            // --- ADD 2011/06/07 ----------<<<<<
            // --- ADD 2012/04/23 ---------->>>>>
            this.RentStockDiv_tComboEditor.Items.Clear();  // 貸出仕入区分
            // --- ADD 2012/04/23 ----------<<<<<
            // --- ADD 2012/12/27 Y.Wakita ---------->>>>>
            this.EpPartsNoPrtCd_tComboEditor.Items.Clear();  // 自社品番印字区分
            // --- ADD 2012/12/27 Y.Wakita ----------<<<<<

            // --- ADD 2013/01/15 ---------->>>>>
            this.StockRetGoodsPlnDiv_tComboEditor.Items.Clear(); // 仕入返品予定機能区分
            // --- ADD 2013/01/15 ----------<<<<<
            // --- ADD 2013/02/05 Y.Wakita ---------->>>>>
            this.BLGoodsCdZeroSuprt_tComboEditor.Items.Clear();  // BLコード０対応
            // --- ADD 2013/02/05 Y.Wakita ----------<<<<<

			//------------------------------
			// するしないコンボボックス設定
			//------------------------------
			if (SalesTtlSt._yesNoList.Count > 0)
			{
				foreach (DictionaryEntry de in SalesTtlSt._yesNoList)
				{
					// 売上伝票発行区分
					this.SalesSlipPrtDiv_tComboEditor.Items.Add(de.Key, de.Value.ToString());
					
					// 出荷伝票発行区分
					this.ShipmSlipPrtDiv_tComboEditor.Items.Add(de.Key, de.Value.ToString());

                    // --- DEL 2008/07/22 -------------------------------->>>>>
                    //// ゼロ円印刷区分
                    //this.ZeroPrtDiv_tComboEditor.Items.Add(de.Key, de.Value.ToString());
                    // --- DEL 2008/07/22 --------------------------------<<<<< 

					// 返品時在庫登録区分
					this.RetGoodsStockEtyDiv_tComboEditor.Items.Add(de.Key, de.Value.ToString());

                    // --- ADD 2008/06/09 -------------------------------->>>>>
                    // 伝票備考３表示区分
                    this.BrSlipNote3DispDiv_tComboEditor.Items.Add(de.Key, de.Value.ToString());

                    // 粗利表示区分
                    this.GrsProfitDspCd_tComboEditor.Items.Add(de.Key, de.Value.ToString());
                    // --- ADD 2008/06/09 --------------------------------<<<<< 

                    // 2008.12.04 add start [8598]
                    // 2009.03.09 30413 犬飼 コンボボックスの設定を変更 >>>>>>START
                    //// 受注者表示区分
                    //this.AcpOdrAgentDispDiv_tComboEditor.Items.Add(de.Key, de.Value.ToString());
                    // 2009.03.09 30413 犬飼 コンボボックスの設定を変更 <<<<<<END
                    
                    // 伝票備考２表示区分
                    this.BrSlipNote2DispDiv_tComboEditor.Items.Add(de.Key, de.Value.ToString());

                    // 明細備考表示区分
                    this.DtlNoteDispDiv_tComboEditor.Items.Add(de.Key, de.Value.ToString());
                    // 2008.12.04 add end [8598]

				}
			}
			//------------------------------
			// しないするコンボボックス設定
			//------------------------------
			if (SalesTtlSt._noYesList.Count > 0)
			{
				foreach (DictionaryEntry de in SalesTtlSt._noYesList)
				{
					// 出荷伝票単価印刷区分コンボボックス設定
					this.ShipmSlipUnPrcPrtDiv_tComboEditor.Items.Add(de.Key, de.Value.ToString());
					
					// 定価選択区分
					this.ListPriceSelectDiv_tComboEditor.Items.Add(de.Key, de.Value.ToString());

                    // --- ADD 2008/06/09 -------------------------------->>>>>
                    // 得意先注番表示区分
                    this.CustOrderNoDispDiv_tComboEditor.Items.Add(de.Key, de.Value.ToString());  

                    // 車輌管理番号表示区分
                    this.CarMngNoDispDiv_tComboEditor.Items.Add(de.Key, de.Value.ToString());

                    // --- ADD 2009/10/19 ---------->>>>>
                    // 表示区分プロセス
                    this.PriceSelectDispDiv_tComboEditor.Items.Add(de.Key, de.Value.ToString());
                    // --- ADD 2009/10/19 ----------<<<<<

                    // --- ADD 2010/01/29 ---------->>>>>
                    // 受注数入力
                    this.AcpOdrInputDiv_tComboEditor.Items.Add(de.Key, de.Value.ToString());
                    // --- ADD 2010/01/29 ----------<<<<<

                    // 自動入金区分
                    this.AutoDepositCd_tComboEditor.Items.Add(de.Key, de.Value.ToString());

                    // 商品名再表示区分
                    this.GoodsNmReDispDivCd_tComboEditor.Items.Add(de.Key, de.Value.ToString());

                    // 原価表示区分
                    this.CostDspDivCd_tComboEditor.Items.Add(de.Key, de.Value.ToString());
                    // --- ADD 2008/06/09 --------------------------------<<<<< 

                    // 2008.12.04 add start [8598]
                    // 商品自動登録
                    this.AutoEntryGoodsDivCd_tComboEditor.Items.Add(de.Key, de.Value.ToString());
                    // 2008.12.04 add end [8598]

                    // --- ADD 2010/04/30-------------------------------->>>>>
                    // 自由検索部品自動登録区分
                    this.FrSrchPrtAutoEntDiv_tComboEditor.Items.Add(de.Key, de.Value.ToString());
                    // --- ADD 2010/04/30 --------------------------------<<<<<

                    // --- ADD 2010/08/04 ---------->>>>>
                    // 小数点表示区分
                    this.DwnPLCdSpDivCd_tComboEditor.Items.Add(de.Key, de.Value.ToString());
                    // --- ADD 2010/08/04 ----------<<<<<

                    // --- DEL 2013/01/09 T.Nishi ---------->>>>>
                    //// --- ADD 2012/12/27 Y.Wakita ---------->>>>>
                    //// 自社品番印字区分
                    //this.EpPartsNoPrtCd_tComboEditor.Items.Add(de.Key, de.Value.ToString());
                    //// --- ADD 2012/12/27 Y.Wakita ----------<<<<<
                    // --- DEL 2013/01/09 T.Nishi ----------<<<<<
                    // --- ADD 2013/01/16 Y.Wakita ---------->>>>>
                    // 自社品番印字区分
                    this.EpPartsNoPrtCd_tComboEditor.Items.Add(de.Key, de.Value.ToString());
                    // --- ADD 2013/01/16 Y.Wakita ----------<<<<<
                    // --- ADD 2013/02/05 Y.Wakita ---------->>>>>
                    // BLコード０対応
                    this.BLGoodsCdZeroSuprt_tComboEditor.Items.Add(de.Key, de.Value.ToString());
                    // --- ADD 2013/02/05 Y.Wakita ----------<<<<<
                }
			}

            // --- DEL 2008/07/22 -------------------------------->>>>>
            ////------------------------
            //// 警告コンボボックス設定
            ////------------------------
            //if (SalesTtlSt._alarmList.Count > 0)
            //{
            //    foreach (DictionaryEntry de in SalesTtlSt._alarmList)
            //    {
            //        // 入出荷数区分コンボボックス設定
            //        this.IoGoodsCntDiv_tComboEditor.Items.Add(de.Key, de.Value.ToString());

            //        //----- ueno add---------- start 2008.02.26
            //        // 入出荷数区分２コンボボックス設定
            //        this.IoGoodsCntDiv2_tComboEditor.Items.Add(de.Key, de.Value.ToString());
            //        //----- ueno add---------- end 2008.02.26
            //    }
            //}
            ////----------------------------
            //// 売上出荷コンボボックス設定
            ////----------------------------
            //if (SalesTtlSt._salesShipmList.Count > 0)
            //{
            //    foreach (DictionaryEntry de in SalesTtlSt._salesShipmList)
            //    {
            //        // 売上形式初期値
            //        this.SalesFormalIn_tComboEditor.Items.Add(de.Key, de.Value.ToString());
            //    }
            //}
            // --- DEL 2008/07/22 --------------------------------<<<<< 

			//----------------------------
			// 任意必須コンボボックス設定
			//----------------------------
			if (SalesTtlSt._optNecessaryList.Count > 0)
			{
				foreach (DictionaryEntry de in SalesTtlSt._optNecessaryList)
				{
                    // --- DEL 2008/07/22 -------------------------------->>>>>
                    //// 仕入明細確認
                    //this.StockDetailConf_tComboEditor.Items.Add(de.Key, de.Value.ToString());
                    // --- DEL 2008/07/22 --------------------------------<<<<< 

					// メーカー入力区分
					this.MakerInpDiv_tComboEditor.Items.Add(de.Key, de.Value.ToString());
					
					// BL商品コード入力区分
					this.BLGoodsCdInpDiv_tComboEditor.Items.Add(de.Key, de.Value.ToString());

					// 仕入先入力区分
					this.SupplierInpDiv_tComboEditor.Items.Add(de.Key, de.Value.ToString());
				}
			}
			//-------------------------------
			// 可能警告不可コンボボックス設定
			//-------------------------------
			if (SalesTtlSt._enableAlarmList.Count > 0)
			{
				foreach (DictionaryEntry de in SalesTtlSt._enableAlarmList)
				{
					// 売上担当変更区分
					this.SalesAgentChngDiv_tComboEditor.Items.Add(de.Key, de.Value.ToString());
				}
			}
			//----------------------------
			// 有無必須コンボボックス設定
			//----------------------------
			if (SalesTtlSt._onOffNecessaryList.Count > 0)
			{
                foreach (DictionaryEntry de in SalesTtlSt._onOffNecessaryList)
				{
					// 受注者表示区分
                    // 2008.12.04 del start [8598]
					//this.AcpOdrAgentDispDiv_tComboEditor.Items.Add(de.Key, de.Value.ToString());
                    // 2008.12.04 del end [8598]
				}
			}
			//----------------------------
			// 有無コンボボックス設定
			//----------------------------
			if (SalesTtlSt._onOffList.Count > 0)
			{
				foreach (DictionaryEntry de in SalesTtlSt._onOffList)
				{
                    // 2008.12.04 del start [8598]
					// 伝票備考２表示区分
					//this.BrSlipNote2DispDiv_tComboEditor.Items.Add(de.Key, de.Value.ToString());
                    
    				// 明細備考表示区分
					//this.DtlNoteDispDiv_tComboEditor.Items.Add(de.Key, de.Value.ToString());
                    // 2008.12.04 del end [8598]
				}
			}
			//----------------------------
			// ゼロ定価コンボボックス設定
			//----------------------------
			if (SalesTtlSt._zeroLPriceList.Count > 0)
			{
				foreach (DictionaryEntry de in SalesTtlSt._zeroLPriceList)
				{
					// 売価未設定時区分
					this.UnPrcNonSettingDiv_tComboEditor.Items.Add(de.Key, de.Value.ToString());
				}
			}
			//--------------------------------
			// 残す残さないコンボボックス設定
			//--------------------------------
			if (SalesTtlSt._reserveList.Count > 0)
			{
				foreach (DictionaryEntry de in SalesTtlSt._reserveList)
				{
                    // 見積データ計上残区分
                    this.EstmateAddUpRemDiv_tComboEditor.Items.Add(de.Key, de.Value.ToString());

					// 受注データ計上残区分
					this.AcpOdrrAddUpRemDiv_tComboEditor.Items.Add(de.Key, de.Value.ToString());

                    //// 出荷データ計上残区分 // DEL 2010/12/03
                    // 貸出データ計上残区分 // ADD 2010/12/03
					this.ShipmAddUpRemDiv_tComboEditor.Items.Add(de.Key, de.Value.ToString());
				}
			}
			//--------------------------------
			// 確認コンボボックス設定
			//--------------------------------
			if (SalesTtlSt._noConfYesList.Count > 0)
			{
				foreach (DictionaryEntry de in SalesTtlSt._noConfYesList)
				{
					// 仕入伝票削除区分
					this.SupplierSlipDelDiv_tComboEditor.Items.Add(de.Key, de.Value.ToString());
				}
			}
			//--------------------------------
			// 表示区分コンボボックス設定
			//--------------------------------
			if (SalesTtlSt._dispList.Count > 0)
			{
				foreach (DictionaryEntry de in SalesTtlSt._dispList)
				{
					// 得意先ガイド初期値表示区分
					this.CustGuideDispDiv_tComboEditor.Items.Add(de.Key, de.Value.ToString());
				}
			}
			//--------------------------------
			// 伝票修正コンボボックス設定
			//--------------------------------
			if (SalesTtlSt._slipChngDivList.Count > 0)
			{
                // 2008.12.11 30413 犬飼 返品伝票修正区分を追加 >>>>>>START
				foreach (DictionaryEntry de in SalesTtlSt._slipChngDivList)
				{
                    //// 伝票修正区分（日付）	
                    //this.SlipChngDivDate_tComboEditor.Items.Add(de.Key, de.Value.ToString());

					// 伝票修正区分（原価）
					this.SlipChngDivCost_tComboEditor.Items.Add(de.Key, de.Value.ToString());

					// 伝票修正区分（売価）
                    // ---------- UPD 2010/12/03 --------------------------------------->>>>>
                    //this.SlipChngDivUnPrc_tComboEditor.Items.Add(de.Key, de.Value.ToString());
                    // 伝票修正区分（売価）のリストから「未使用」を削除する。「3:在庫時不可→2:在庫時不可」
                    if ((int)de.Key != 2)
                    {
                        if ((int)de.Key == 3)
                        {
                            DictionaryEntry de2 = new DictionaryEntry(2, de.Value.ToString());
                            this.SlipChngDivUnPrc_tComboEditor.Items.Add(de2.Key, de2.Value.ToString());
                        }
                        else
                        {
                            this.SlipChngDivUnPrc_tComboEditor.Items.Add(de.Key, de.Value.ToString());
                        }
                    }
                    // ---------- UPD 2010/12/03 ---------------------------------------<<<<<

                    // 返品伝票修正区分（原価）
                    this.RetSlipChngDivCost_tComboEditor.Items.Add(de.Key, de.Value.ToString());

                    // 返品伝票修正区分（売価）
                    // ---------- UPD 2010/12/03 --------------------------------------->>>>>
                    //this.RetSlipChngDivUnPrc_tComboEditor.Items.Add(de.Key, de.Value.ToString());
                    // 返品伝票修正区分（売価）のリストから「未使用」を削除する。「3:在庫時不可→2:在庫時不可」
                    if ((int)de.Key != 2)
                    {
                        if ((int)de.Key == 3)
                        {
                            DictionaryEntry de3 = new DictionaryEntry(2, de.Value.ToString());
                            this.RetSlipChngDivUnPrc_tComboEditor.Items.Add(de3.Key, de3.Value.ToString());
                        }
                        else
                        {
                            this.RetSlipChngDivUnPrc_tComboEditor.Items.Add(de.Key, de.Value.ToString());
                        } 
                    }
                    // ---------- UPD 2010/12/03 ---------------------------------------<<<<<
				}
                // 2008.12.11 30413 犬飼 返品伝票修正区分を追加 <<<<<<END
			}
			//--------------------------------
			// 伝票修正在庫コンボボックス設定
			//--------------------------------
			if (SalesTtlSt._slipChngDivStcList.Count > 0)
			{
                // 2008.12.11 30413 犬飼 伝票修正区分（日付）を追加 >>>>>>START
                foreach (DictionaryEntry de in SalesTtlSt._slipChngDivStcList)
				{
                    // 伝票修正区分（日付）	
                    this.SlipChngDivDate_tComboEditor.Items.Add(de.Key, de.Value.ToString());

					// 伝票修正区分（定価）
					this.SlipChngDivLPrice_tComboEditor.Items.Add(de.Key, de.Value.ToString());
				}
                // 2008.12.11 30413 犬飼 伝票修正区分（日付）を追加 <<<<<<END
			}

			//----- ueno add---------- start 2008.02.18
			//--------------------------------
			// 自動入金金種コードコンボボックス設定
			//--------------------------------
            if (SalesTtlSt._autoDepoKindCodeList.Count > 0)
            {
                string wkValue = "";

                foreach (DictionaryEntry de in SalesTtlSt._autoDepoKindCodeList)
                {
                    wkValue = this._salesTtlStAcs.GetAutoDepoKindName((int)de.Key);
                    this.AutoDepoKindCode_tComboEditor.Items.Add(de.Key, wkValue);
                }
            }
			//----- ueno add---------- end 2008.02.18

            // --- ADD 2008/06/09 -------------------------------->>>>>
            //--------------------------------
            // 発行者表示区分コンボボックス設定
            //--------------------------------
            if (SalesTtlSt._inpAgentDispDivList.Count > 0)
            {
                foreach (DictionaryEntry de in SalesTtlSt._inpAgentDispDivList)
                {
                    this.InpAgentDispDiv_tComboEditor.Items.Add(de.Key, de.Value.ToString());

                    // 2009.03.09 30413 犬飼 コンボボックスの設定を変更 >>>>>>START
                    // 受注者表示区分
                    this.AcpOdrAgentDispDiv_tComboEditor.Items.Add(de.Key, de.Value.ToString());
                    // 2009.03.09 30413 犬飼 コンボボックスの設定を変更 <<<<<<END
                }
            }

            //--------------------------------
            // 日付区分コンボボックス設定
            //--------------------------------
            if (SalesTtlSt._dateList.Count > 0)
            {
                foreach (DictionaryEntry de in SalesTtlSt._dateList)
                {
                    // 伝票日付クリア区分
                    this.SlipDateClrDivCd_tComboEditor.Items.Add(de.Key, de.Value.ToString());

                    // 入金伝票日付クリア区分
                    this.DepoSlipDateClrDiv_tComboEditor.Items.Add(de.Key, de.Value.ToString());
                }
            }

            //--------------------------------
            // 商品自動登録コンボボックス設定
            //--------------------------------
            if (SalesTtlSt._autoEntryGoodsDivCdList.Count > 0)
            {
                foreach (DictionaryEntry de in SalesTtlSt._autoEntryGoodsDivCdList)
                {
                    // 2008.12.04 del start [8598]
                    // 商品自動登録
                    //this.AutoEntryGoodsDivCd_tComboEditor.Items.Add(de.Key, de.Value.ToString());
                    // 2008.12.04 del end [8598]
                }
            }

            //--------------------------------
            // 原価チェック区分コンボボックス設定
            //--------------------------------
            if (SalesTtlSt._costCheckDivCdList.Count > 0)
            {
                foreach (DictionaryEntry de in SalesTtlSt._costCheckDivCdList)
                {
                    // 原価チェック区分
                    this.CostCheckDivCd_tComboEditor.Items.Add(de.Key, de.Value.ToString());
                }
            }

            //--------------------------------
            // 結合初期表示区分コンボボックス設定
            //--------------------------------
            if (SalesTtlSt._joinInitDispDivList.Count > 0)
            {
                foreach (DictionaryEntry de in SalesTtlSt._joinInitDispDivList)
                {
                    // 結合初期表示区分
                    this.JoinInitDispDiv_tComboEditor.Items.Add(de.Key, de.Value.ToString());
                }
            }

            //--------------------------------
            // 代替条件区分コンボボックス設定
            //--------------------------------
            if (SalesTtlSt._substCondDivCdList.Count > 0)
            {
                foreach (DictionaryEntry de in SalesTtlSt._substCondDivCdList)
                {
                    // 代替条件区分
                    this.SubstCondDivCd_tComboEditor.Items.Add(de.Key, de.Value.ToString());
                }
            }

            // ADD 2008/09/29 不具合対応[5665]---------->>>>>
            //--------------------------------
            // 代替適用区分（ユーザー代替適用区分）コンボボックス設定
            //--------------------------------
            if (SalesTtlSt._substApplyDivCdList.Count > 0)
            {
                foreach (DictionaryEntry de in SalesTtlSt._substApplyDivCdList)
                {
                    // 代替適用区分（ユーザー代替適用区分）
                    this.SubstApplyDivCd_tComboEditor.Items.Add(de.Key, de.Value.ToString());
                }
            }

            //--------------------------------
            // 優良代替条件区分コンボボックス設定
            //--------------------------------
            if (SalesTtlSt._prmSubstCondDivCdList.Count > 0)
            {
                foreach (DictionaryEntry de in SalesTtlSt._prmSubstCondDivCdList)
                {
                    // 優良代替条件区分
                    this.PrmSubstCondDivCd_tComboEditor.Items.Add(de.Key, de.Value.ToString());
                }
            }
            // ADD 2008/09/29 不具合対応[5665]----------<<<<<

            //--------------------------------
            // 伝票作成方法コンボボックス設定
            //--------------------------------
            if (SalesTtlSt._slipCreateProcessList.Count > 0)
            {
                foreach (DictionaryEntry de in SalesTtlSt._slipCreateProcessList)
                {
                    // 伝票作成方法
                    this.SlipCreateProcess_tComboEditor.Items.Add(de.Key, de.Value.ToString());
                }
            }

            //--------------------------------
            // 倉庫チェック区分コンボボックス設定
            //--------------------------------
            if (SalesTtlSt._warehouseChkDivList.Count > 0)
            {
                foreach (DictionaryEntry de in SalesTtlSt._warehouseChkDivList)
                {
                    // 倉庫チェック区分
                    this.WarehouseChkDiv_tComboEditor.Items.Add(de.Key, de.Value.ToString());
                }
            }

            //--------------------------------
            // 部品検索区分コンボボックス設定
            //--------------------------------
            if (SalesTtlSt._partsSearchDivCdList.Count > 0)
            {
                foreach (DictionaryEntry de in SalesTtlSt._partsSearchDivCdList)
                {
                    // 部品検索区分
                    this.PartsSearchDivCd_tComboEditor.Items.Add(de.Key, de.Value.ToString());
                }
            }

            //--------------------------------
            // 部品検索優先順区分コンボボックス設定
            //--------------------------------
            if (SalesTtlSt._partsSearchPriDivCdList.Count > 0)
            {
                foreach (DictionaryEntry de in SalesTtlSt._partsSearchPriDivCdList)
                {
                    // 部品検索優先順区分
                    this.PartsSearchPriDivCd_tComboEditor.Items.Add(de.Key, de.Value.ToString());
                }
            }

            //--------------------------------
            // 売上仕入区分コンボボックス設定
            //--------------------------------
            if (SalesTtlSt._salesStockDivList.Count > 0)
            {
                foreach (DictionaryEntry de in SalesTtlSt._salesStockDivList)
                {
                    // 売上仕入区分
                    this.SalesStockDiv_tComboEditor.Items.Add(de.Key, de.Value.ToString());
                }
            }

            //--------------------------------
            // 印刷用BL商品コード区分コンボボックス設定
            //--------------------------------
            if (SalesTtlSt._prtBLGoodsCodeDivList.Count > 0)
            {
                foreach (DictionaryEntry de in SalesTtlSt._prtBLGoodsCodeDivList)
                {
                    // 印刷用BL商品コード区分
                    this.PrtBLGoodsCodeDiv_tComboEditor.Items.Add(de.Key, de.Value.ToString());
                }
            }

            //--------------------------------
            // 拠点表示区分コンボボックス設定
            //--------------------------------
            if (SalesTtlSt._sectDspDivCdList.Count > 0)
            {
                foreach (DictionaryEntry de in SalesTtlSt._sectDspDivCdList)
                {
                    // 拠点表示区分
                    this.SectDspDivCd_tComboEditor.Items.Add(de.Key, de.Value.ToString());
                }
            }

            //--------------------------------
            // 入金伝票日付範囲区分コンボボックス設定
            //--------------------------------
            if (SalesTtlSt._depoSlipDateAmbitList.Count > 0)
            {
                foreach (DictionaryEntry de in SalesTtlSt._depoSlipDateAmbitList)
                {
                    // 入金伝票日付範囲区分
                    this.DepoSlipDateAmbit_tComboEditor.Items.Add(de.Key, de.Value.ToString());
                }
            }
            // --- ADD 2008/06/09 --------------------------------<<<<< 

            // --- ADD 2017/04/13 譚洪 Redmine#49283---------->>>>>
            //--------------------------------
            // 仕入担当参照区分コンボボックス設定
            //--------------------------------
            if (SalesTtlSt._stockEmpRefDivList.Count > 0)
            {
                foreach (DictionaryEntry de in SalesTtlSt._stockEmpRefDivList)
                {
                    // 入金伝票日付範囲区分
                    this.StockEmpRefDiv_tComboEditor.Items.Add(de.Key, de.Value.ToString());
                }
            }
            // --- ADD 2017/04/13 譚洪 Redmine#49283----------<<<<<

            // --- ADD 2008/07/22 -------------------------------->>>>>
            //--------------------------------
            // 入力粗利チェック区分コンボボックス設定
            //--------------------------------
            if (SalesTtlSt._inpGrsPrfChkList.Count > 0)
            {
                foreach (DictionaryEntry de in SalesTtlSt._inpGrsPrfChkList)
                {
                    // 入力粗利チェック上限区分
                    this.InpGrsProfChkUppDiv_tComboEditor.Items.Add(de.Key, de.Value.ToString());

                    // 入力粗利チェック下限区分
                    this.InpGrsProfChkLowDiv_tComboEditor.Items.Add(de.Key, de.Value.ToString());
                }
            }
            // --- ADD 2008/07/22 --------------------------------<<<<< 

            this.partsNameDspDivCdTComboEditor.SelectedIndex = 0;   // ADD 2008/11/05 不具合対応[7101] 品名表示区分の追加


            //--------------------------------
            // BLコード枝番区分コンボボックス設定
            //--------------------------------
            if (SalesTtlSt._bLGoodsCdDerivNoDivList.Count > 0)
            {
                foreach (DictionaryEntry de in SalesTtlSt._bLGoodsCdDerivNoDivList)
                {
                    // BLコード枝番区分
                    this.BLGoodsCdDerivNoDiv_tComboEditor.Items.Add(de.Key, de.Value.ToString());
                }
            }

            // --- ADD 2010/05/04 ---------->>>>>
            //--------------------------------
            // 発行者チェック区分コンボボックス設定
            //--------------------------------
            if (SalesTtlSt._inpAgentChkDivList.Count > 0)
            {
                foreach (DictionaryEntry de in SalesTtlSt._inpAgentChkDivList)
                {
                    // 発行者チェック区分
                    this.InpAgentChkDiv_tComboEditor.Items.Add(de.Key, de.Value.ToString());
                }
            }

            //--------------------------------
            // 入力倉庫チェック区分コンボボックス設定
            //--------------------------------
            if (SalesTtlSt._inpWarehChkDivList.Count > 0)
            {
                foreach (DictionaryEntry de in SalesTtlSt._inpWarehChkDivList)
                {
                    // 入力倉庫チェック区分
                    this.InpWarehChkDiv_tComboEditor.Items.Add(de.Key, de.Value.ToString());
                }
            }            
            // --- ADD 2010/05/04 ----------<<<<<

            // -- ADD 2011/06/07 ----------------->>>
            //--------------------------------
            // 販売区分表示区分コンボボックス設定
            //--------------------------------
            if (SalesTtlSt._salesCdDspDivCdList.Count > 0)
            {
                foreach (DictionaryEntry de in SalesTtlSt._salesCdDspDivCdList)
                {
                    // 販売区分表示区分
                    this.SalesCdDspDivCd_tComboEditor.Items.Add(de.Key, de.Value.ToString());
                }
            }
            // -- ADD 2011/06/07 -----------------<<<

            // -- ADD 2012/04/23 ----------------->>>
            //--------------------------------
            // 貸出仕入区分コンボボックス設定
            //--------------------------------
            if (SalesTtlSt._rentStockDivList.Count > 0)
            {
                foreach (DictionaryEntry de in SalesTtlSt._rentStockDivList)
                {
                    // 貸出仕入区分
                    this.RentStockDiv_tComboEditor.Items.Add(de.Key, de.Value.ToString());
                }
            }
            // -- ADD 2012/04/23 -----------------<<<
            // --- DEL 2013/01/16 Y.Wakita ---------->>>>>
            //// --- ADD 2013/01/09 T.Nishi ---------->>>>>
            ////--------------------------------
            //// 優良品番印字区分コンボボックス設定
            ////--------------------------------
            //if (SalesTtlSt._EpPartsNoPrtCdList.Count > 0)
            //{
            //    foreach (DictionaryEntry de in SalesTtlSt._EpPartsNoPrtCdList)
            //    {
            //        // 優良品番印字区分
            //        this.EpPartsNoPrtCd_tComboEditor.Items.Add(de.Key, de.Value.ToString());
            //    }
            //}
            //// --- ADD 2013/01/09 T.Nishi ----------<<<<<
            // --- DEL 2013/01/16 Y.Wakita ----------<<<<<
            // --- ADD 2013/01/16 Y.Wakita ---------->>>>>
            //--------------------------------
            // 印字品番初期値コンボボックス設定
            //--------------------------------
            if (SalesTtlSt._PrintGoodsNoDefList.Count > 0)
            {
                foreach (DictionaryEntry de in SalesTtlSt._PrintGoodsNoDefList)
                {
                    // 印字品番初期値
                    this.PrintGoodsNoDef_tComboEditor.Items.Add(de.Key, de.Value.ToString());
                }
            }
            // --- ADD 2013/01/16 Y.Wakita ----------<<<<<
            // -- ADD 2013/01/15 ----------------->>>
            //--------------------------------
            // 仕入返品予定機能区分コンボボックス設定
            //--------------------------------
            if (SalesTtlSt._stockRetGoodsPlnDivList.Count > 0)
            {
                foreach (DictionaryEntry de in SalesTtlSt._stockRetGoodsPlnDivList)
                {
                    // 仕入返品予定機能区分
                    this.StockRetGoodsPlnDiv_tComboEditor.Items.Add(de.Key, de.Value.ToString());
                }
            }
            // -- ADD 2013/01/15 -----------------<<<

            // --- ADD cheq 2013/01/21 Redmine#33797 ----->>>>>
            //--------------------------------
            // 自動入金備考区分コンボボックス設定
            //--------------------------------
            if (SalesTtlSt._autoDepositNoteDivList.Count > 0)
            {
                foreach (DictionaryEntry de in SalesTtlSt._autoDepositNoteDivList)
                {
                    // 自動入金備考区分
                    this.AutoDepositNoteDiv_tComboEditor1.Items.Add(de.Key, de.Value.ToString());
                }
            }
            // --- ADD cheq 2013/01/21 Redmine#33797 -----<<<<<
        }

		//----- ueno add---------- start 2008.02.18
		/// <summary>
		/// 自動入金金種区分表示変更
		/// </summary>
		/// <param name="autoDepoKindCode">自動入金金種コード</param>
		/// <remarks>
		/// <br>Note　     : 自動入金金種コードの選択を変更したときに発生します。</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2008.02.18</br>
		/// </remarks>
		private void AutoDepoKindCodeVisibleChange(int autoDepoKindCode)
		{
			try
			{
				if (this._autoDepoKindCode_tComboEditorValue == autoDepoKindCode) return;
				
				// 自動入金金種区分（隠し項目）
				int wkAutoDepoKindDivCd = this._salesTtlStAcs.GetAutoDepoKindDivCd(autoDepoKindCode);
				this.AutoDepoKindDivCd_tNedit.SetInt(wkAutoDepoKindDivCd);
				
				// 自動入金金種区分名称
				this.AutoDepoKindDivCdNm_tEdit.Text = SalesTtlSt.GetComboBoxNm(wkAutoDepoKindDivCd, SalesTtlSt._mnyKindDivList);
				
				// 選択した番号を保持
				this._autoDepoKindCode_tComboEditorValue = autoDepoKindCode;
			}
			catch
			{
			}
		}
		//----- ueno add---------- end 2008.02.18

        /// <summary>
        /// データ検索処理
        /// </summary>
        /// <param name="totalCnt">全該当件数</param>
        /// <param name="readCnt">抽出対象件数</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : データを検索し、抽出結果を展開したデータセットと全該当件数を返します。</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/09</br>
        /// </remarks>
        private int SearchSalesTtlSt(ref int totalCnt, int readCnt)
        {
            int status = 0;
            ArrayList salesTtlSts = null;

            // 抽出対象件数が0件の場合は全件抽出を実行する
            status = this._salesTtlStAcs.SearchAll(out salesTtlSts, this._enterpriseCode);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        int index = 0;
                        foreach (SalesTtlSt salesTtlSt in salesTtlSts)
                        {
                            if (this._salesTtlStTable.ContainsKey(salesTtlSt.FileHeaderGuid) == false)
                            {
                                SalesTtlStToDataSet(salesTtlSt.Clone(), index);
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
                            "DCKHN09210U", 						// アセンブリＩＤまたはクラスＩＤ
                            "売上全体設定", 					// プログラム名称
                            "SearchSalesTtlSt", 			    // 処理名称
                            TMsgDisp.OPE_GET, 					// オペレーション
                            "読み込みに失敗しました。", 		// 表示するメッセージ
                            status, 							// ステータス値
                            this._salesTtlStAcs, 			    // エラーが発生したオブジェクト
                            MessageBoxButtons.OK, 				// 表示するボタン
                            MessageBoxDefaultButton.Button1);	// 初期表示ボタン

                        break;
                    }
            }

            totalCnt = salesTtlSts.Count;

            return status;
        }

        /// <summary>
        /// 売上全体設定オブジェクト論理削除処理
        /// </summary>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 売上全体設定オブジェクトの論理削除を行います。</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/09</br>
        /// </remarks>
        private int LogicalDelete()
        {
            int status = 0;

            if ((this._dataIndex < 0) ||
                (this._dataIndex >= this.Bind_DataSet.Tables[SALESTTLST_TABLE].Rows.Count))
            {
                return -1;
            }

            // 情報取得
            Guid guid = (Guid)this.Bind_DataSet.Tables[SALESTTLST_TABLE].Rows[this._dataIndex][GUID_TITLE];
            SalesTtlSt salesTtlSt = ((SalesTtlSt)this._salesTtlStTable[guid]).Clone();

            // 売上全体設定が存在していない
            if (salesTtlSt == null)
            {
                return -1;
            }

            // ADD 2008/09/16 不具合対応[5287] ---------->>>>>
            // 拠点コードが全社共通の場合、削除不可
            if (IsAllSection(salesTtlSt))
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
            // ADD 2008/09/16 不具合対応[5287] ----------<<<<<

            status = this._salesTtlStAcs.LogicalDelete(ref salesTtlSt);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        SalesTtlStToDataSet(salesTtlSt.Clone(), this._dataIndex);
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
                            "DCKHN09210U", 						// アセンブリＩＤまたはクラスＩＤ
                            "売上全体設定", 					// プログラム名称
                            "LogicalDelete", 					// 処理名称
                            TMsgDisp.OPE_HIDE, 					// オペレーション
                            "削除に失敗しました。", 			// 表示するメッセージ
                            status, 							// ステータス値
                            this._salesTtlStAcs,			    // エラーが発生したオブジェクト
                            MessageBoxButtons.OK, 				// 表示するボタン
                            MessageBoxDefaultButton.Button1);	// 初期表示ボタン

                        return status;
                    }
            }
            return status;
        }

        // ADD 2008/09/16 不具合対応[5287] ---------->>>>>
        /// <summary>
        /// 全社共通か判定します。
        /// </summary>
        /// <param name="salesTtlSt">売上全体設定</param>
        /// <returns><c>true</c> :全社共通である。<br/><c>false</c>:全社共通ではない。</returns>
        /// <remarks>
        /// <br>Note       : 不具合対応[5287]にて追加</br>
        /// <br>Programmer : 30434 工藤 恵優</br>
        /// <br>Date       : 2008/09/16</br>
        /// </remarks>
        private static bool IsAllSection(SalesTtlSt salesTtlSt)
        {
            return SectionUtil.IsAllSection(salesTtlSt.SectionCode);
        }
        // ADD 2008/09/16 不具合対応[5287] ----------<<<<<

        /// <summary>
        /// 売上全体設定オブジェクト完全削除処理
        /// </summary>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 売上全体設定ブジェクトの完全削除を行います。</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/09</br>
        /// </remarks>
        private int PhysicalDelete()
        {
            int status = 0;

            if ((this._dataIndex < 0) ||
                (this._dataIndex >= this.Bind_DataSet.Tables[SALESTTLST_TABLE].Rows.Count))
            {
                return -1;
            }

            // 情報取得
            Guid guid = (Guid)this.Bind_DataSet.Tables[SALESTTLST_TABLE].Rows[this._dataIndex][GUID_TITLE];
            SalesTtlSt salesTtlSt = (SalesTtlSt)this._salesTtlStTable[guid];

            // 売上全体設定が存在していない
            if (salesTtlSt == null)
            {
                return -1;
            }

            // ADD 2008/09/16 不具合対応[5287] ---------->>>>>
            // 拠点コードが全社共通の場合、削除不可
            if (IsAllSection(salesTtlSt))
            {
                TMsgDisp.Show(
                    this, 							                        // 親ウィンドウフォーム
                    emErrorLevel.ERR_LEVEL_INFO, 	                        // エラーレベル
                    AssemblyUtil.GetName(Assembly.GetExecutingAssembly()),  // アセンブリＩＤまたはクラスＩＤ
                    this.Text, 				                                // プログラム名称
                    MethodBase.GetCurrentMethod().Name, 				    // 処理名称
                    TMsgDisp.OPE_DELETE, 			                        // TODO:オペレーション
                    SectionUtil.MSG_ALL_SECTION_CANNOT_BE_DELETED, 	        // 表示するメッセージ
                    status, 						                        // ステータス値
                    this,			                                        // エラーが発生したオブジェクト
                    MessageBoxButtons.OK, 			                        // 表示するボタン
                    MessageBoxDefaultButton.Button1                         // 初期表示ボタン
                );
                return status;
            }
            // ADD 2008/09/16 不具合対応[5287] ----------<<<<<

            status = this._salesTtlStAcs.Delete(salesTtlSt);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // ハッシュテーブルからデータを削除
                        this._salesTtlStTable.Remove((Guid)this.Bind_DataSet.Tables[SALESTTLST_TABLE].Rows[this._dataIndex][GUID_TITLE]);
                        // データセットからデータを削除
                        this.Bind_DataSet.Tables[SALESTTLST_TABLE].Rows[this._dataIndex].Delete();
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
                            "DCKHN09210U", 						// アセンブリＩＤまたはクラスＩＤ
                            "売上全体設定", 					// プログラム名称
                            "PhysicalDelete", 					// 処理名称
                            TMsgDisp.OPE_DELETE, 				// オペレーション
                            "削除に失敗しました。", 			// 表示するメッセージ
                            status, 							// ステータス値
                            this._salesTtlStAcs,			    // エラーが発生したオブジェクト
                            MessageBoxButtons.OK, 				// 表示するボタン
                            MessageBoxDefaultButton.Button1);	// 初期表示ボタン
                        CloseForm(DialogResult.Cancel);
                        return status;
                    }
            }
            return status;
        }

        /// <summary>
        /// 売上全体設定オブジェクト論理削除復活処理
        /// </summary>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 売上全体設定オブジェクトの論理削除復活を行います。</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/09</br>
        /// </remarks>
        private int Revival()
        {
            int status = 0;

            if ((this._dataIndex < 0) ||
                (this._dataIndex >= this.Bind_DataSet.Tables[SALESTTLST_TABLE].Rows.Count))
            {
                return -1;
            }

            // 情報取得
            Guid guid = (Guid)this.Bind_DataSet.Tables[SALESTTLST_TABLE].Rows[this._dataIndex][GUID_TITLE];
            SalesTtlSt salesTtlSt = ((SalesTtlSt)this._salesTtlStTable[guid]).Clone();

            // 売上全体設定が存在していない
            if (salesTtlSt == null)
            {
                return -1;
            }

            status = this._salesTtlStAcs.Revival(ref salesTtlSt);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        SalesTtlStToDataSet(salesTtlSt.Clone(), this._dataIndex);
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
                            "DCKHN09210", 						// アセンブリＩＤまたはクラスＩＤ
                            "売上全体設定", 					// プログラム名称
                            "Revival", 							// 処理名称
                            TMsgDisp.OPE_UPDATE, 				// オペレーション
                            "復活に失敗しました。", 			// 表示するメッセージ
                            status, 							// ステータス値
                            this._salesTtlStAcs, 				// エラーが発生したオブジェクト
                            MessageBoxButtons.OK, 				// 表示するボタン
                            MessageBoxDefaultButton.Button1);	// 初期表示ボタン
                        CloseForm(DialogResult.Cancel);
                        return status;
                    }
            }
            return status;
        }

		/// <summary>
		/// HTML表示項目設定処理（数値）
		/// </summary>
		/// <param name="num">項目名</param>
		/// <returns>表示項目名（データ有：データ名, データ無：未設定）</returns>
		/// <remarks>
		/// <br>Note       : HTML表示項目の設定を行います。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.12.12</br>
		/// </remarks>
		private string GetHtmlDispData(double num)
		{
			string retStr = HTML_UNREGISTER;	// 未設定
			try
			{
				if (num > 0)
				{
					retStr = num.ToString();
				}
			}
			catch
			{
			}
			return retStr;
		}

		/// <summary>
		/// HTML表示項目設定処理（文字列）
		/// </summary>
		/// <param name="str">項目名</param>
		/// <returns>表示項目名（データ有：データ名, データ無：未設定）</returns>
		/// <remarks>
		/// <br>Note       : HTML表示項目の設定を行います。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.12.12</br>
		/// </remarks>
		private string GetHtmlDispData(string str)
		{
			string retStr = HTML_UNREGISTER;	// 未設定

			if ((str != "")&&(str != null))
			{
				retStr = str;
			}
			return retStr;
		}

		/// <summary>
		/// NULL文字変換処理
		/// </summary>
		/// <param name="obj">オブジェクト</param>
		/// <returns>string型データ</returns>
		/// <remarks>
		/// <br>Note       : NULL文字が含まれている場合ダブルクォートへ変換する</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2007.12.06</br>
		/// </remarks>
		private string NullChgStr(object obj)
		{
			string ret;
			try
			{
				if (obj == null)
				{
					ret = "";
				}
				else
				{
					ret = obj.ToString();
				}
			}
			catch
			{
				ret = "";
			}
			return ret;
		}

		/// <summary>
		/// NULL文字変換処理
		/// </summary>
		/// <param name="obj">オブジェクト</param>
		/// <returns>int型データ</returns>
		/// <remarks>
		/// <br>Note       : NULL文字が含まれている場合「0」へ変換する</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2007.12.06</br>
		/// </remarks>
		private int NullChgInt(object obj)
		{
			int ret;
			try
			{
				if ((obj == null) || (string.Equals(obj.ToString(), "") == true))
				{
					ret = 0;
				}
				else
				{
					ret = Convert.ToInt32(obj);
				}
			}
			catch
			{
				ret = 0;
			}
			return ret;
		}

        /// <summary>
        /// 拠点名称取得処理
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <returns>拠点名称</returns>
        /// <remarks>
        /// <br>Note       : 拠点名称を取得します。</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/09</br>
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

		#endregion

		#region << Control Events >>

		/// <summary>
		/// Form.Load イベント (DCKHN09210UA)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : ユーザーがフォームを読み込むときに発生します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.12.06</br>
		/// </remarks>
		private void DCKHN09210UA_Load( object sender, EventArgs e )
		{
            // 画面スキンファイルの読込(デフォルトスキン指定)
            this._controlScreenSkin.LoadSkin();
            
            // 画面スキン変更
            this._controlScreenSkin.SettingScreenSkin(this);
			
			// アイコンリソース管理クラスを使用して、アイコンを表示する
			ImageList imageList24 = IconResourceManagement.ImageList24;
			ImageList imageList16 = IconResourceManagement.ImageList16;

			this.Ok_Button.ImageList            = imageList24;           // 保存ボタン
			this.Cancel_Button.ImageList        = imageList24;           // 閉じるボタン

			this.Ok_Button.Appearance.Image     = Size24_Index.SAVE;     // 保存ボタン
			this.Cancel_Button.Appearance.Image = Size24_Index.CLOSE;    // 閉じるボタン

            // --- ADD 2009/03/19 残案件No.14対応------------------------------------------------------>>>>>
            this.Renewal_Button.ImageList = imageList16;
            this.Renewal_Button.Appearance.Image = Size16_Index.RENEWAL;   
            // --- ADD 2009/03/19 残案件No.14対応------------------------------------------------------<<<<<

            // --- ADD 2008/06/09 -------------------------------->>>>>
            this.Revive_Button.ImageList = imageList24;
            this.Delete_Button.ImageList = imageList24;
            this.Revive_Button.Appearance.Image = Size24_Index.REVIVAL;	// 復活ボタン
            this.Delete_Button.Appearance.Image = Size24_Index.DELETE;	// 完全削除ボタン
            // --- ADD 2008/06/09 --------------------------------<<<<< 

            this.SectionGd_ultraButton.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1]; // ADD 2008/06/09
            
			// 画面初期化
			this.ScreenInitialSetting();

            // 拠点ガイドのフォーカス制御の開始
            SectionGuideController.StartControl();  // ADD 2008/09/18 不具合対応[5401]
		}

		/// <summary>
		/// Form.FormClosing イベント (DCKHN09210UA)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : ユーザーがフォームを閉じるたびに、フォームが閉じられる前、および閉じる理由を指定する前に発生します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.12.06</br>
		/// </remarks>
		private void DCKHN09210UA_FormClosing( object sender, FormClosingEventArgs e )
		{
			// チェック用クローン初期化
			this._salesTtlStClone = null;

            // _GridIndexバッファ初期化（メインフレーム最小化対応）
            this._indexBuf = -2;  // ADD 2008/06/09

			// ユーザーによって閉じられる場合
			if( e.CloseReason == CloseReason.UserClosing )
			{
				// CanCloseプロパティがfalseの場合は、クローズ処理をキャンセルしてフォームを非表示化する。
				if( this._canClose == false )
				{
					e.Cancel = true;
					this.Hide();
				}
			}
		}

		/// <summary>
		/// Form.VisibleChanged イベント (DCKHN09210UA)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : コントロールの表示状態が変わったときに発生します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.12.06</br>
		/// </remarks>
		private void DCKHN09210UA_VisibleChanged( object sender, EventArgs e )
		{
			if( this.Visible == false )
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
			this.ScreenClear();
		}

		/// <summary>
		/// Timer.Tick イベント (Initial_Timer)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : 指定された間隔の時間が経過したときに発生します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.12.06</br>
		/// </remarks>
		private void Initial_Timer_Tick( object sender, EventArgs e )
		{
			this.Initial_Timer.Enabled = false;

			this.ScreenReconstruction();
		}

		/// <summary>
		/// UltraButton.Click イベント (Ok_Button)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : コンポーネントがクリックされたときに発生します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.12.06</br>
        /// <br>Update Note: 2010/01/29 李侠 受注数入力を追加</br>
        /// <br>Update Note: 2010/05/04 王海立 発行者チェック区分、入力倉庫チェック区分を追加</br>
		/// </remarks>
		private void Ok_Button_Click( object sender, EventArgs e )
		{
            /* --- DEL 2008/06/09 -------------------------------->>>>>
			if( this.SaveProc() == false )
			{
				return;
			}

			// フォームを閉じる
			this.CloseForm( DialogResult.OK );
           --- DEL 2008/06/09 --------------------------------<<<<< */

            // --- ADD 2008/06/09 -------------------------------->>>>>
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

                // 最初のタブ設定
                MainTabControl.SelectedTab = this.MainTabControl.Tabs["Page1Tab"];

                // 新規モード
                this._logicalDeleteMode = -1;

                SalesTtlSt newSalesTtlSt = new SalesTtlSt();

                // 自動入金金種デフォルト設定
                newSalesTtlSt.AutoDepoKindCode = (int)SalesTtlSt._autoDepoKindCodeList.GetKey(0);

                // --- ADD 2010/01/29 ---------->>>>>
                // 受注数入力デフォルト設定
                newSalesTtlSt.AcpOdrInputDiv = 1;
                // --- ADD 2010/01/29 ----------<<<<<

                // --- ADD 2010/05/04 ---------->>>>>
                // 発行者チェック区分デフォルト設定
                newSalesTtlSt.InpAgentChkDiv = 0;

                // 入力倉庫チェック区分デフォルト設定
                newSalesTtlSt.InpWarehChkDiv = 0;
                // --- ADD 2010/05/04 ----------<<<<<

                // 売上全体設定オブジェクトを画面に展開
                SalesTtlStToScreen(newSalesTtlSt);

                // クローン作成
                this._salesTtlStClone = newSalesTtlSt.Clone();
                DispToSalesTtlSt(ref this._salesTtlStClone);

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
            // --- ADD 2008/06/09 --------------------------------<<<<< 
		}

		/// <summary>
		/// UltraButton.Click イベント (Cancel_Button)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : コンポーネントがクリックされたときに発生します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.12.06</br>
		/// </remarks>
		private void Cancel_Button_Click( object sender, EventArgs e )
		{
            /* --- DEL 2008/06/09 -------------------------------->>>>>
			DialogResult result = DialogResult.Cancel;

			SalesTtlSt compareSalesTtlSt = new SalesTtlSt();
			compareSalesTtlSt = this._salesTtlStClone.Clone();
			this.DispToSalesTtlSt( ref compareSalesTtlSt );

			if( compareSalesTtlSt.Equals( this._salesTtlStClone ) == false )
			{
				// 画面情報が変更されていた場合は、保存確認メッセージを表示する
				// 保存確認
				DialogResult res = TMsgDisp.Show( 
					this,                                  // 親ウィンドウフォーム
					emErrorLevel.ERR_LEVEL_SAVECONFIRM,    // エラーレベル
					CT_PGID,                               // アセンブリＩＤまたはクラスＩＤ
					null,                                  // 表示するメッセージ
					0,                                     // ステータス値
					MessageBoxButtons.YesNoCancel );       // 表示するボタン
				switch( res ) {
					case DialogResult.Yes:
					{
						if( this.SaveProc() == false )
						{
							return;
						}
						result = DialogResult.OK;
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
			this.CloseForm( result );
               --- DEL 2008/06/09 --------------------------------<<<<< */

            // --- ADD 2008/06/09 -------------------------------->>>>>
            // 削除モード・参照モード以外の場合は保存確認処理を行う
            if (this.Mode_Label.Text != DELETE_MODE)
            {
                // 現在の画面情報を取得する
                SalesTtlSt compareSalesTtlSt = new SalesTtlSt();
                compareSalesTtlSt = this._salesTtlStClone.Clone();
                DispToSalesTtlSt(ref compareSalesTtlSt);

                // 最初に取得した画面情報と比較
                if (!(this._salesTtlStClone.Equals(compareSalesTtlSt)))
                {
                    // 画面情報が変更されていた場合は、保存確認メッセージを表示する
                    // 保存確認
                    DialogResult res = TMsgDisp.Show(
                        this, 								// 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_SAVECONFIRM, // エラーレベル
                        "DCKHN09210U", 						// アセンブリＩＤまたはクラスＩＤ
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
            // --- ADD 2008/06/09 --------------------------------<<<<< 
		}

		//----- ueno add---------- start 2008.02.18
		/// <summary>
		/// tArrowKeyControl1_ChangeFocusイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
		{
			if ((e.PrevCtrl == null) || (e.NextCtrl == null)) return;

            // DEL 2008/09/19 不具合対応[5406] ---------->>>>>
            //switch(e.PrevCtrl.Name)
            //{
            //    case "AutoDepoKindCode_tComboEditor":
            //        {
            //            if (this.AutoDepoKindCode_tComboEditor.Value != null)
            //            {
            //                AutoDepoKindCodeVisibleChange((Int32)this.AutoDepoKindCode_tComboEditor.Value);
            //            }
            //            break;
            //        }
            //}
            // DEL 2008/09/19 不具合対応[5406] ----------<<<<<

            // 2009.03.25 30413 犬飼 新規モードからモード変更対応 >>>>>>START
            _modeFlg = false;
            
            switch (e.PrevCtrl.Name)
            {
                case "tEdit_SectionCodeAllowZero2":
                    {
                        // 拠点コード
                        if (e.NextCtrl.Name == "Cancel_Button")
                        {
                            // 遷移先が閉じるボタン
                            _modeFlg = true;
                        }
                        // ADD 2009/04/07 ------>>>
                        else if (e.NextCtrl.Name == "Renewal_Button")
                        {
                            // 最新情報ボタンは更新チェックから外す
                            ;
                        }
                        // ADD 2009/04/07 ------<<<
                        else if (this._dataIndex < 0)
                        {
                            if (ModeChangeProc())
                            {
                                e.NextCtrl = tEdit_SectionCodeAllowZero2;
                            }
                        }
                        break;
                    }
                // ADD 2009/04/07 ------>>>
                case "Renewal_Button":
                    {
                        // 最新情報ボタンからの遷移時、更新チェックを追加
                        if (e.NextCtrl.Name == "Cancel_Button")
                        {
                            // 遷移先が閉じるボタン
                            _modeFlg = true;
                        }
                        else if (e.NextCtrl.Name == "tEdit_SectionCodeAllowZero2")
                        {
                            ;
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
                // ADD 2009/04/07 ------<<<
            }
            // 2009.03.25 30413 犬飼 新規モードからモード変更対応 <<<<<<END
		}

        /// <summary>
        /// AutoDepoKindCode_tComboEditor_SelectionChangeCommitted イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　 : 自動入金金種コードが変化したときに発生します。</br>
        /// <br>Programmer : 30167 上野 弘貴</br>
        /// <br>Date       : 2008.02.18</br>
        /// </remarks>
        private void AutoDepoKindCode_tComboEditor_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (this.AutoDepoKindCode_tComboEditor.Value != null)
            {
                AutoDepoKindCodeVisibleChange((Int32)this.AutoDepoKindCode_tComboEditor.Value);
            }
        }
        //----- ueno add---------- end 2008.02.18

        /// <summary>
        /// 拠点コードガイドボタンクリック処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : ガイド表示処理</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/09</br>
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
                    ((Control)sender).Tag = GeneralGuideUIController.CAN_FOCUS; // ADD 2008/10/09 不具合対応[6226]
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
        /// Control.Click イベント(Delete_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 完全削除ボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/09</br>
        /// </remarks>
        private void Delete_Button_Click(object sender, EventArgs e)
        {
            // 完全削除確認
            DialogResult result = TMsgDisp.Show(
                this, 								// 親ウィンドウフォーム
                emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
                "DCKHN09210U", 						// アセンブリＩＤまたはクラスＩＤ
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
        /// Control.Click イベント(Revive_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 復活ボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/09</br>
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
        /// 拠点コードEdit Leave処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 拠点名称表示処理</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/09</br>
        /// </remarks>
        private void tEdit_SectionCode_Leave(object sender, EventArgs e)
        {
            // 拠点コード入力あり？
            //if (this.tEdit_SectionCodeAllowZero.Text != "") // DEL 2008/11/21 不具合対応[7770]
            if (this.tEdit_SectionCodeAllowZero2.Text != "" &&
                !this.tEdit_SectionCodeAllowZero2.Text.Trim().Equals("0") &&
                !this.tEdit_SectionCodeAllowZero2.Text.Trim().Equals("00")) // ADD 2008/11/21 不具合対応[7770]
            {
                // 拠点コード名称設定
                this.SectionNm_tEdit.Text = GetSectionName(this.tEdit_SectionCodeAllowZero2.Text.Trim());
            }
            else
            {
                // 拠点コード名称クリア
                //this.SectionNm_tEdit.Text = "";         // DEL 2008/11/13 不具合対応[7770]
                //this.SectionNm_tEdit.Value = "全社共通";// ADD 2008/11/13 不具合対応[7770]// DEL 2011/09/07
                // --- ADD 2011/09/07 -------------------------------->>>>>
                if (this.tEdit_SectionCodeAllowZero2.Text != "") 
                    this.SectionNm_tEdit.Value = "全社共通";
                else
                    this.SectionNm_tEdit.Value = "";
                // --- ADD 2011/09/07 --------------------------------<<<<<
            }
        }
        #endregion

        // --- ADD 2009/03/19 残案件No.14対応------------------------------------------------------>>>>>
        private void Renewal_Button_Click(object sender, EventArgs e)
        {
            SalesTtlSt._autoDepoKindCodeList = new SortedList();
            SalesTtlSt._mnyKindDivList = new SortedList();

            this._salesTtlStAcs.SetMoneyKindList(this._enterpriseCode);
            this._salesTtlStAcs.SetMnyKindDivList();

            if (SalesTtlSt._autoDepoKindCodeList.Count > 0)
            {
                int index = (int)AutoDepoKindCode_tComboEditor.Value;
                AutoDepoKindCode_tComboEditor.Items.Clear();

                string wkValue = "";

                foreach (DictionaryEntry de in SalesTtlSt._autoDepoKindCodeList)
                {
                    wkValue = this._salesTtlStAcs.GetAutoDepoKindName((int)de.Key);
                    this.AutoDepoKindCode_tComboEditor.Items.Add(de.Key, wkValue);
                }

                AutoDepoKindCode_tComboEditor.Value = index;
            }

            TMsgDisp.Show(this, 								// 親ウィンドウフォーム
                          emErrorLevel.ERR_LEVEL_INFO,          // エラーレベル
                          "DCKHN09210U",						    // アセンブリＩＤまたはクラスＩＤ
                          "最新情報を取得しました。", 			// 表示するメッセージ
                          0, 									// ステータス値
                          MessageBoxButtons.OK);				// 表示するボタン
        }
        // --- ADD 2009/03/19 残案件No.14対応------------------------------------------------------<<<<<

        // 2009.03.25 30413 犬飼 新規モードからモード変更対応 >>>>>>START
        /// <summary>
        /// モード変更処理
        /// </summary>
        private bool ModeChangeProc()
        {
            // --- ADD 2011/09/07 -------------------------------->>>>>
            isError = false;
            if (string.IsNullOrEmpty(tEdit_SectionCodeAllowZero2.Text.Trim()))
            {
                this.SectionNm_tEdit.Clear();
                return false;
            }
            this.tEdit_SectionCodeAllowZero2.DataText = this.tEdit_SectionCodeAllowZero2.DataText.PadLeft(2, '0');
            // --- ADD 2011/09/07 --------------------------------<<<<<
            string msg = "入力されたコードの売上全体設定情報が既に登録されています。\n編集を行いますか？";

            // 拠点コード
            string sectionCd = tEdit_SectionCodeAllowZero2.Text.TrimEnd().PadLeft(2, '0');

            for (int i = 0; i < this.Bind_DataSet.Tables[SALESTTLST_TABLE].Rows.Count; i++)
            {
                // データセットと比較
                string dsSecCd = (string)this.Bind_DataSet.Tables[SALESTTLST_TABLE].Rows[i][SECTIONCODE_TITLE];
                if (sectionCd.Equals(dsSecCd.TrimEnd()))
                {
                    // 入力コードがデータセットに存在する場合
                    if ((string)this.Bind_DataSet.Tables[SALESTTLST_TABLE].Rows[i][DELETE_DATE] != "")
                    {
                        // 論理削除
                        TMsgDisp.Show(this, 					// 親ウィンドウフォーム
                          emErrorLevel.ERR_LEVEL_INFO,          // エラーレベル
                          "DCKHN09210U",						// アセンブリＩＤまたはクラスＩＤ
                          "入力されたコードの売上全体設定情報は既に削除されています。", 			// 表示するメッセージ
                          0, 									// ステータス値
                          MessageBoxButtons.OK);				// 表示するボタン
                        isError = true; // ADD 2011/09/07
                        // 拠点コード、名称のクリア
                        tEdit_SectionCodeAllowZero2.Clear();
                        SectionNm_tEdit.Clear();
                        return true;
                    }

                    if (sectionCd == "00")
                    {
                        // 全社共通のメッセージ変更
                        msg = "入力されたコードの売上全体設定情報が既に登録されています。\n　【拠点名称：全社共通】\n編集を行いますか？";
                    }

                    DialogResult res = TMsgDisp.Show(
                        this,                                   // 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_INFO,            // エラーレベル
                        "DCKHN09210U",                          // アセンブリＩＤまたはクラスＩＤ
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

        // ADD 2010/05/14 品名表示対応：品名表示区分の詳細設定を追加 ---------->>>>>

        /// <summary>品名表示パターン設定設定画面</summary>
        private DCKHN09210UB _partsNameDspPatternForm;
        /// <summary>品名表示パターン設定設定画面を取得します。</summary>
        private DCKHN09210UB PartsNameDspPatternForm
        {
            get
            {
                if (_partsNameDspPatternForm == null) _partsNameDspPatternForm = new DCKHN09210UB();
                return _partsNameDspPatternForm;
            }
        }

        /// <summary>
        /// 品名表示区分：[詳細設定]ボタンのClickイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void ubtnPartsNameDspPattern_Click(object sender, EventArgs e)
        {
            PartsNameDspPatternForm.ShowDialog(this.partsNameDspDivCdTComboEditor);
        }
        // ADD 2010/05/14 品名表示対応：品名表示区分の詳細設定を追加 ----------<<<<<

        // --- ADD 2012/12/27 Y.Wakita ---------->>>>>
        /// <summary>
        /// [自社品番印字区分]プルダウンのValueChangeイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void EpPartsNoPrtCd_tComboEditor_ValueChanged(object sender, EventArgs e)
        {
            // --- UPD 2013/01/16 Y.Wakita ---------->>>>>
            //// --- UPD 2013/01/09 T.Nishi ---------->>>>>
            ////if (this.EpPartsNoPrtCd_tComboEditor.SelectedIndex == 0)
            //if ((this.EpPartsNoPrtCd_tComboEditor.SelectedIndex == 0)
            //|| (this.EpPartsNoPrtCd_tComboEditor.SelectedIndex == 2))
            //// --- UPD 2013/01/09 T.Nishi ----------<<<<<
            if (this.EpPartsNoPrtCd_tComboEditor.SelectedIndex == 0)
            // --- UPD 2013/01/16 Y.Wakita ---------->>>>>
            {
                // 「しない」の場合、自社品番付加文字を使用不可、値クリア
                this.EpPartsNoAddChar_tEdit.Enabled = false;
                this.EpPartsNoAddChar_tEdit.Clear();
                // --- ADD 2013/01/16 Y.Wakita ---------->>>>>
                // 印字品番初期値を「優良」
                this.PrintGoodsNoDef_tComboEditor.Enabled = false;
                this.PrintGoodsNoDef_tComboEditor.SelectedIndex = 0;
                // --- ADD 2013/01/16 Y.Wakita ----------<<<<<
            }
            else
            {
                // 「する」の場合、自社品番付加文字を使用可
                this.EpPartsNoAddChar_tEdit.Enabled = true;
                // --- ADD 2013/01/16 Y.Wakita ---------->>>>>
                // 「する」の場合、印字品番初期値を使用可
                this.PrintGoodsNoDef_tComboEditor.Enabled = true;
                // --- ADD 2013/01/16 Y.Wakita ----------<<<<<
            }
        }
        // --- ADD 2012/12/27 Y.Wakita ----------<<<<<

        // --- ADD 2013/02/05 Y.Wakita ---------->>>>>
        /// <summary>
        /// [BLコード０対応]プルダウンのValueChangeイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void BLGoodsCdZeroSuprt_tComboEditor_ValueChanged(object sender, EventArgs e)
        {
            if (this.BLGoodsCdZeroSuprt_tComboEditor.SelectedIndex == 0)
            {
                // 「しない」の場合、変換コードを使用不可、値クリア
                this.BLGoodsCdChange_tNedit.Enabled = false;
                this.BLGoodsCdChange_tNedit.Clear();
            }
            else
            {
                // 「する」の場合、変換コードを使用可
                this.BLGoodsCdChange_tNedit.Enabled = true;
            }
        }
        // --- ADD 2013/02/05 Y.Wakita ----------<<<<<
    }
}
