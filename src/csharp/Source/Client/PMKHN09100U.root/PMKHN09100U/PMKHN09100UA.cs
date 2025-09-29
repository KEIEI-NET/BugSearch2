//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 得意先設定(伝票設定)
// プログラム概要   : 得意先設定(伝票設定)マスタの登録・修正・削除を行います。
//----------------------------------------------------------------------------//
//                (c)Copyright  2007 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 長沼 賢二
// 作 成 日  2008/06/25  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 忍 幸史
// 修 正 日  2008/09/11  修正内容 : データビューの列幅の自動調整チェックボックスのデフォルト値変更
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 上野 俊治
// 修 正 日  2008/09/22  修正内容 : 得意先伝票番号ヘッダ、得意先伝票番号フッタを削除
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 行澤 仁美
// 修 正 日  2008/10/06  修正内容 : バグ修正、画面レイアウト変更
//----------------------------------------------------------------------------//
// 管理番号  12695       作成担当 : 工藤 恵優
// 修 正 日  2009/03/24  修正内容 : 「削除済データの表示」は最上位項目で制御
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30413 犬飼
// 修 正 日  2009/04/28  修正内容 : MANTIS【13218】データ０件の正常動作対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30413 犬飼
// 修 正 日  2009/06/19  修正内容 : MANTIS【13561】抽出区分リストの不具合修正
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 宋剛
// 修 正 日  2013/02/08  修正内容 : 2013/03/13配信分 
//                                  Redmine#34616   No.1641得意先伝票番号チェックの不具合修正
//----------------------------------------------------------------------------//
using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Diagnostics;
using System.Text;

using Broadleaf.Library.Text;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Common;
using Infragistics.Win.Misc;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 得意先設定(伝票設定)
    /// </summary>
    /// <remarks>
    /// <br>Note       : 得意先設定(伝票設定)マスタの登録・修正・削除を行います。</br>
    /// <br>				IMasterMaintenanceArrayTypeを実装しています。</br>
    /// <br>Programmer : 30416 長沼 賢二</br>
    /// <br>Date       : 2008.06.25</br>
    /// <br>Update Note: 2007/19/11  30414 忍 幸史</br>
    /// <br>     		 データビューの列幅の自動調整チェックボックスのデフォルト値変更</br>
    /// <br>Update Note: 2008/09/22 30452 上野 俊治</br>
    /// <br>             PM.NS対応</br>
    /// <br>             ・得意先伝票番号ヘッダ、得意先伝票番号フッタを削除</br>
    /// <br>UpdateNote : 2008/10/06 30462 行澤 仁美　バグ修正、画面レイアウト変更</br>
    /// <br>UpdateNote : 2009/03/24 30434 工藤 恵優　「削除済データの表示」は最上位項目で制御</br>
    /// <br>Update Note: 2013/02/08 宋剛</br>
    /// <br>管理番号   : 10801804-00 2013/03/13配信分</br>
    /// <br>             Redmine#34616 No.1641得意先伝票番号チェックの不具合修正</br>
    /// </remarks>
    public partial class PMKHN09100UA : Form, IMasterMaintenanceArrayType
    {
        /// <summary>メイン</summary>
        public const string MAIN_TABLE = "CashRegisterNo";
        /// <summary>詳細</summary>
        public const string DETAILS_TABLE = "SlipPrt";

        // グリッドタイトル
        /// <summary>名称</summary>
        public const string CUSTSLIPNOSET_GRID_TITLE = "得意先コード";
        /// <summary>名称</summary>
        public const string ADDUPYEARMONTH_GRID_TITLE = "計上年月";

        private enum SlipOutputSetSearchMode
        {
            ///<summary>ローカルＤＢ</summary>
            LocalDB = 0,
            ///<summary>リモートＤＢ</summary>
            RemoteDB = 1
        }

        #region Private Members

        // プロパティ用
        private bool _canPrint;
        private bool _canClose;
        private bool _canNew;
        private bool _canDelete;
        private MGridDisplayLayout _defaultGridDisplayLayout;
        private string _targetTableName;

        // タイトル
        private string _mainGridTitle;
        private string _secondGridTitle;

        // アイコン
        private Image _mainGridIcon;
        private Image _secondGridIcon;

        // 選択データインデックス
        private int _mainDataIndex;
        private int _detailsDataIndex;

        // アプリケーション
        // 企業コード
        private string _enterpriseCode = "";

        // 得意先設定(伝票設定)マスタアクセスクラス
        private CustSlipNoSetAcs _custSlipNoSetAcs = null;

        private CustomerInfoAcs _customerInfoAcs = null;

        // データセット
        private DataSet _bindDataSet = null;

        private DateGetAcs _dateGetAcs = null; //ADD 2008/09/22

        // 従業員
        private Employee _employee = null;

        // 画面デザイン変更クラス
        private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();

        // 終了時のチェック用
        private DataTable _dataTableClone = null;

        // 文字列結合用
        private StringBuilder _stringBuilder = null;

        //------------------
        // コンボボックス用
        //------------------

        // コンボボックス用
        private const string COMBO_CODE = "COMBO_CODE";
        private const string COMBO_NAME = "COMBO_NAME";

        // 編集モード
        private const string INSERT_MODE = "新規モード";
        private const string UPDATE_MODE = "更新モード";
        private const string DELETE_MODE = "削除モード";

        private const int BUTTON_LOCATION1_X = 132;     // 完全削除ボタン位置X
        private const int BUTTON_LOCATION2_X = 261;     // 保存/復活ボタン位置X
        private const int BUTTON_LOCATION3_X = 392;     // 閉じるボタン位置X
        private const int BUTTON_LOCATION_Y = 5;        // ボタン位置Y(共通)

        // Message関連定義
        private const string ASSEMBLY_ID = "PMKHN09100U";
        private const string ERR_READ_MSG = "読み込みに失敗しました。";
        private const string ERR_DPR_MSG = "このコードは既に使用されています。";
        private const string ERR_RDEL_MSG = "削除に失敗しました。";
        private const string ERR_UPDT_MSG = "登録に失敗しました。";
        private const string ERR_RVV_MSG = "復活に失敗しました。";
        private const string ERR_800_MSG = "既に他端末より更新されています";
        private const string ERR_801_MSG = "既に他端末より削除されています";
        private const string SDC_RDEL_MSG = "マスタから削除されています";

        // 抽出区分
        private const string EXTRACTION_DIVISION1 = "連番";
        private const string EXTRACTION_DIVISION2 = "締毎";
        private const string EXTRACTION_DIVISION3 = "期末";

        #endregion

        #region Constructor
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : コンストラクタ</br>
        /// <br>Programmer : 30416 長沼 賢二</br>
        /// <br>Date       : 2008.06.26</br>
        /// </remarks>
        public PMKHN09100UA()
        {
            InitializeComponent();

            //====================================
            // プロパティ初期値設定
            //====================================
            this._canPrint = false;
            this._canClose = true;
            this._canNew = true;
            this._canDelete = true;

            this._mainGridTitle = CUSTSLIPNOSET_GRID_TITLE;
            this._secondGridTitle = ADDUPYEARMONTH_GRID_TITLE;
            this._defaultGridDisplayLayout = MGridDisplayLayout.Vertical;

            //====================================
            // 変数初期化
            //====================================
            // 企業コード
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            // 従業員
            this._employee = LoginInfoAcquisition.Employee;

            // 得意先設定(伝票設定)マスタアクセスクラス
            this._custSlipNoSetAcs = new CustSlipNoSetAcs();

            this._customerInfoAcs = new CustomerInfoAcs();

            this._dateGetAcs = DateGetAcs.GetInstance(); //ADD 2008/09/22

            // 終了時のチェック用
            this._dataTableClone = new DataTable();

            // 各種インデックス初期化
            this._mainDataIndex = -1;
            this._detailsDataIndex = -1;

            // アイコン用
            this._mainGridIcon = null;
            this._secondGridIcon = null;

            // データセット列情報構築処理
            this._bindDataSet = new DataSet();
            DataSetColumnConstruction(ref this._bindDataSet);

            // 文字列結合用
            this._stringBuilder = new StringBuilder();
        }
        #endregion

        # region Events（定義）
        /// <summary>画面非表示イベント</summary>
        /// <remarks>画面が非表示状態になった際に発生します。</remarks>
        public event MasterMaintenanceArrayTypeUnDisplayingEventHandler UnDisplaying;
        # endregion

        # region Main
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            System.Windows.Forms.Application.Run(new PMKHN09100UA());
        }
        # endregion

        # region インターフェース定義 Properties
        /// <summary>印刷可能設定プロパティ</summary>
        /// <value>印刷可能かどうかの設定を取得します。</value>
        public bool CanPrint
        {
            get { return this._canPrint; }
        }

        /// <summary>画面終了設定プロパティ</summary>
        /// <value>画面クローズを許可するかどうかの設定を取得または設定します。</value>
        /// <remarks>falseの場合は、画面を閉じる際、CloseではなくHide(非表示)を実行します。</remarks>
        public bool CanClose
        {
            get { return this._canClose; }
            set { this._canClose = value; }
        }

        /// <summary>新規登録可能設定プロパティ</summary>
        /// <value>新規登録が可能かどうかの設定を取得します。</value>
        public bool CanNew
        {
            get { return this._canNew; }
        }

        /// <summary>削除可能設定プロパティ</summary>
        /// <value>削除が可能かどうかの設定を取得します。</value>
        public bool CanDelete
        {
            get { return this._canDelete; }
        }

        /// <summary>グリッドのデフォルト表示位置プロパティ</summary>
        /// <value>グリッドのデフォルト表示位置を取得します。</value>
        public MGridDisplayLayout DefaultGridDisplayLayout
        {
            get { return this._defaultGridDisplayLayout; }
        }

        /// <summary>操作対象データテーブル名称プロパティ</summary>
        /// <value>捜査対象データのテーブル名称を取得または設定します。</value>
        public string TargetTableName
        {
            get { return this._targetTableName; }
            set { this._targetTableName = value; }
        }
        #endregion

        #region インターフェース定義 Public Methods
        /// <summary>
        /// 論理削除データ抽出可能設定リスト取得処理
        /// </summary>
        /// <returns>論理削除データ抽出可能設定リスト</returns>
        /// <remarks>
        /// <br>Note       : 論理削除データの抽出が可能かどうかの設定を配列で取得します。</br>
        /// <br>Programmer : 30416 長沼 賢二</br>
        /// <br>Date       : 2008.06.25</br>
        /// </remarks>
        public bool[] GetCanLogicalDeleteDataExtractionList()
        {
            bool[] logicalDelete = { true, false }; // MOD 2008/03/24 不具合対応[12695]：「削除済データの表示」は最上位項目で制御 { false, true }→{ true, false }
            return logicalDelete;
        }

        /// <summary>
        /// グリッドタイトルリスト取得処理
        /// </summary>
        /// <returns>グリッドタイトルリスト</returns>
        /// <remarks>
        /// <br>Note       : グリッドのタイトルを配列で取得します。</br>
        /// <br>Programmer : 30416 長沼 賢二</br>
        /// <br>Date       : 2008.06.26</br>
        /// </remarks>
        public string[] GetGridTitleList()
        {
            string[] gridTitle = { _mainGridTitle, _secondGridTitle };
            return gridTitle;
        }

        /// <summary>
        /// グリッドアイコンリスト取得処理
        /// </summary>
        /// <returns>グリッドアイコンリスト</returns>
        /// <remarks>
        /// <br>Note       : グリッドのアイコンを配列で取得します。</br>
        /// <br>Programmer : 30416 長沼 賢二</br>
        /// <br>Date       : 2008.06.26</br>
        /// </remarks>
        public System.Drawing.Image[] GetGridIconList()
        {
            System.Drawing.Image[] gridIcon = { _mainGridIcon, _secondGridIcon };
            return gridIcon;
        }

        /// <summary>
        /// グリッド列のサイズの自動調整のデフォルト値リスト取得処理
        /// </summary>
        /// <returns>グリッド列のサイズの自動調整のデフォルト値リスト</returns>
        /// <remarks>
        /// <br>Note       : グリッド列のサイズの自動調整チェックボックスのチェック有無のデフォルト値を配列で取得します。</br>
        /// <br>Programmer : 30416 長沼 賢二</br>
        /// <br>Date       : 2008.06.26</br>
        /// </remarks>
        public bool[] GetDefaultAutoFillToGridColumnList()
        {
            // --- CHG 2008/09/10 --------------------------------------------------------------------->>>>>
            //bool[] defaultAutoFill = { true, true };
            bool[] defaultAutoFill = { false, false };
            // --- CHG 2008/09/10 ---------------------------------------------------------------------<<<<<
            return defaultAutoFill;
        }

        /// <summary>
        /// データテーブルの選択データインデックスリスト設定処理
        /// </summary>
        /// <param name="indexList">データテーブルの選択データインデックスリスト</param>
        /// <remarks>
        /// <br>Note       : データテーブルの選択データインデックスリストを設定します。</br>
        /// <br>Programmer : 30416 長沼 賢二</br>
        /// <br>Date       : 2008.06.26</br>
        /// </remarks>
        public void SetDataIndexList(int[] indexList)
        {
            int[] intVal = indexList;

            this._mainDataIndex = intVal[0];
            this._detailsDataIndex = intVal[1];
        }

        /// <summary>
        /// 新規ボタンの有効設定リスト取得処理
        /// </summary>
        /// <returns>新規ボタンの有効設定リスト</returns>
        /// <remarks>
        /// <br>Note       : 新規ボタンの有効設定リストを取得します。</br>
        /// <br>Programmer : 30416 長沼 賢二</br>
        /// <br>Date       : 2008.06.26</br>
        /// </remarks>
        public bool[] GetNewButtonEnabledList()
        {
            bool[] newButtonEnabled = { false, true };

            // 親データがない場合は、無効
            if (this._mainDataIndex < 0)
            {
                newButtonEnabled[1] = false;
            }
            return newButtonEnabled;
        }

        /// <summary>
        /// 修正ボタンの有効設定リスト取得処理
        /// </summary>
        /// <returns>修正ボタンの有効設定リスト</returns>
        /// <remarks>
        /// <br>Note       : 修正ボタンの有効設定リストを取得します。</br>
        /// <br>Programmer : 30416 長沼 賢二</br>
        /// <br>Date       : 2008.06.26</br>
        /// </remarks>
        public bool[] GetModifyButtonEnabledList()
        {
            bool[] modifyButtonEnabled = { false, true };

            // 親データがない場合は、無効
            if (this._mainDataIndex < 0)
            {
                modifyButtonEnabled[1] = false;
            }
            return modifyButtonEnabled;
        }

        /// <summary>
        /// 削除ボタンの有効設定リスト取得処理
        /// </summary>
        /// <returns>削除ボタンの有効設定リスト</returns>
        /// <remarks>
        /// <br>Note       : 削除ボタンの有効設定リストを取得します。</br>
        /// <br>Programmer : 30416 長沼 賢二</br>
        /// <br>Date       : 2008.06.26</br>
        /// </remarks>
        public bool[] GetDeleteButtonEnabledList()
        {
            bool[] deleteButtonEnabled = { false, true };

            // 親データがない場合は、無効
            if (this._mainDataIndex < 0)
            {
                deleteButtonEnabled[1] = false;
            }
            return deleteButtonEnabled;
        }

        /// <summary>
        /// バインドデータセット取得処理
        /// </summary>
        /// <param name="bindDataSet">グリッドリッド用データセット</param>
        /// <param name="tableName">テーブル名称</param>
        /// <remarks>
        /// <br>Note       : グリッドにバインドさせるデータセットを取得します。</br>
        /// <br>Programmer : 30416 長沼 賢二</br>
        /// <br>Date       : 2008.06.26</br>
        /// </remarks>
        public void GetBindDataSet(ref System.Data.DataSet bindDataSet, ref string[] tableName)
        {
            bindDataSet = this._bindDataSet;
            tableName[0] = MAIN_TABLE;
            tableName[1] = DETAILS_TABLE;
        }

        /// <summary>
        /// データ検索処理
        /// </summary>
        /// <param name="totalCount">全該当件数</param>
        /// <param name="readCount">抽出対象件数</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 先頭からキャリアの全データを検索し、抽出結果を展開したDataSetと全該当件数を返します。</br>
        /// <br>Programmer : 30416 長沼 賢二</br>
        /// <br>Date       : 2008.06.26</br>
        /// </remarks>
        public int Search(ref int totalCount, int readCount)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            string message;
            bool nextData;
            DataSet ds;

            //-------------------------------------------------------------------
            // 得意先設定(伝票設定)マスタから抽出
            //-------------------------------------------------------------------
            status = this._custSlipNoSetAcs.SearchAll(out ds
                                                    , out totalCount
                                                    , out nextData
                                                    , this._enterpriseCode
                                                    , this._employee.BelongSectionCode
                                                    , out message);
            //if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)      // DEL 2009/04/28
            if ((status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) &&    // ADD 2009/04/28
                (status != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND))
            {
                emErrorLevel emErrLvl = emErrorLevel.ERR_LEVEL_INFO;
                if (status == (int)ConstantManagement.DB_Status.ctDB_ERROR)
                {
                    emErrLvl = emErrorLevel.ERR_LEVEL_STOP;
                }

                // サーチ
                TMsgDisp.Show(
                        this, 								// 親ウィンドウフォーム
                        emErrLvl,                           // エラーレベル
                        ASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
                        //"端末別伝票出力先設定",             // プログラム名称     // DEL 2009/04/28
                        "得意先設定(伝票設定)",             // プログラム名称       // ADD 2009/04/28
                        "Search", 							// 処理名称
                        TMsgDisp.OPE_GET,                   // オペレーション
                        "読み込みに失敗しました。\r\n" + message,  // 表示するメッセージ
                        status,                             // ステータス値
                        this._custSlipNoSetAcs,    	        // エラーが発生したオブジェクト
                        MessageBoxButtons.OK,               // 表示するボタン
                        MessageBoxDefaultButton.Button1);   // 初期表示ボタン

                return status;
            }
            // ADD 2009/04/28 ------>>>
            else
            {
                // テーブルに１レコードも存在しない場合も正常動作とする
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            // ADD 2009/04/28 ------<<<
            
            this._bindDataSet.Tables[MAIN_TABLE].Rows.Clear();
            this._bindDataSet.Tables[DETAILS_TABLE].Rows.Clear();

            foreach (DataRow dr in ds.Tables[CustSlipNoSetAcs.MAIN_TABLE].Rows)
            {
                DataRow check = this._bindDataSet.Tables[MAIN_TABLE].Rows.Find(new object[] { dr[CustSlipNoSetAcs.CUSTOMERCODE_TITLE] });

                if (check != null)
                {
                    // 登録済みなので次へ
                    continue;
                }

                // データ未登録
                    
                // メインテーブルへの登録
                DataRow drMain = this._bindDataSet.Tables[MAIN_TABLE].NewRow();

                // 得意先コード
                drMain[CustSlipNoSetAcs.CUSTOMERCODE_TITLE] = dr[CustSlipNoSetAcs.CUSTOMERCODE_TITLE];
                // 得意先略称（内部保持用）
                drMain[CustSlipNoSetAcs.CUSTOMERNAME_TITLE] = dr[CustSlipNoSetAcs.CUSTOMERNAME_TITLE];

                // 削除日
                // ADD 2008/03/24 不具合対応[12695]↓：「削除済データの表示」は最上位項目で制御
                drMain[CustSlipNoSetAcs.DELETE_DATE_TITLE] = GetDelateDate((int)drMain[CustSlipNoSetAcs.CUSTOMERCODE_TITLE]);

                this._bindDataSet.Tables[MAIN_TABLE].Rows.Add(drMain);
            }

            return status;
        }

        // ADD 2009/03/24 不具合対応[12695]：「削除済データの表示」は最上位項目で制御 ---------->>>>>
        /// <summary>
        /// メインテーブルの削除日を取得します。
        /// </summary>
        /// <param name="customerCode">得意先コード</param>
        /// <returns>メインテーブルの削除日（削除されてない場合、<c>string.Empty</c>を返します。）</returns>
        private string GetDelateDate(int customerCode)
        {
            DataRow[] foundDataRows = this._custSlipNoSetAcs.DtDetailsTable.Select(
                CustSlipNoSetAcs.CUSTOMERCODE_TITLE + "=" + customerCode.ToString()
            );
            if (foundDataRows.Length.Equals(0)) return string.Empty;

            // 削除日を収集
            IList<DataRow> deletedRowList = new List<DataRow>();
            foreach (DataRow foundRow in foundDataRows)
            {
                if (!string.IsNullOrEmpty((string)foundRow[CustSlipNoSetAcs.DELETE_DATE_TITLE]))
                {
                    deletedRowList.Add(foundRow);
                }
            }

            // サブテーブルのレコードが全て削除の場合、削除日を返す
            if (deletedRowList.Count.Equals(foundDataRows.Length))
            {
                return (string)deletedRowList[0][CustSlipNoSetAcs.DELETE_DATE_TITLE];
            }
            else
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// メインテーブルの削除日を設定します。
        /// </summary>
        private void SetMainTableDeleteDate()
        {
            foreach (DataRow mainRow in this._bindDataSet.Tables[MAIN_TABLE].Rows)
            {
                int customerCode = (int)mainRow[CustSlipNoSetAcs.CUSTOMERCODE_TITLE];
                mainRow[CustSlipNoSetAcs.DELETE_DATE_TITLE] = GetDelateDate(customerCode);
            }
        }
        // ADD 2009/03/24 不具合対応[12695]：「削除済データの表示」は最上位項目で制御 ----------<<<<<

        /// <summary>
        /// ネクストデータ検索処理
        /// </summary>
        /// <param name="readCount">抽出対象件数</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : ArrayTypeでは未実装</br>
        /// <br>Programmer : 30416 長沼 賢二</br>
        /// <br>Date       : 2008.06.26</br>
        /// </remarks>
        public int SearchNext(int readCount)
        {
            // EOF
            return (int)ConstantManagement.DB_Status.ctDB_EOF;
        }

        /// <summary>
        /// 詳細検索処理
        /// </summary>
        /// <param name="totalCount">全該当件数</param>
        /// <param name="readCount">抽出対象件数</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 先頭から指定件数分のデータを検索し、抽出結果を展開したDataSetと全該当件数を返します。</br>
        /// <br>Programmer : 30416 長沼 賢二</br>
        /// <br>Date       : 2008.06.26</br>
        /// </remarks>
        public int DetailsDataSearch(ref int totalCount, int readCount)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            if ((this._bindDataSet == null) || (this._mainDataIndex < 0))
            {
                return status;
            }

            this._bindDataSet.Tables[DETAILS_TABLE].Rows.Clear();

            // ADD 2009/03/24 不具合対応[12695]：「削除済データの表示」は最上位項目で制御 ---------->>>>>
            // readCountが負の場合、強制終了
            if (readCount < 0) return 0;
            // ADD 2009/03/24 不具合対応[12695]：「削除済データの表示」は最上位項目で制御 ----------<<<<<

            int customerCode = int.Parse(this._bindDataSet.Tables[MAIN_TABLE].Rows[this._mainDataIndex][CustSlipNoSetAcs.CUSTOMERCODE_TITLE].ToString());

            DataTable sortTable = new DataTable();
            sortTable = this._custSlipNoSetAcs.DtDetailsTable.Clone();	// 詳細テーブルのカラムコピー

            // ビューデータ取得
            DataView dView = this._custSlipNoSetAcs.DtDetailsTable.DefaultView;

            // レコードをワークテーブルに詰め替え
            foreach (DataRowView drv in dView)
            {
                sortTable.ImportRow(drv.Row);
            }

            // 第１グリッド抽出時に既に抽出済みのテーブルから表示
            foreach (DataRow dr in sortTable.Rows)
            {
                if (customerCode != (int)dr[CustSlipNoSetAcs.CUSTOMERCODE_TITLE])
                {
                    // 端末番号が不一致のデータは除外
                    continue;
                }

                DataRow check = this._bindDataSet.Tables[DETAILS_TABLE].Rows.Find(new object[] {	dr[CustSlipNoSetAcs.CUSTOMERCODE_TITLE],
				                                                                                    dr[CustSlipNoSetAcs.ADDUPYEARMONTH_TITLE] });
                if (check != null)
                {
                    // 登録済みなので次へ
                    continue;
                }

                // 伝票印刷テーブルへの登録
                DataRow drDetails = this._bindDataSet.Tables[DETAILS_TABLE].NewRow();

                // 得意先コード
                drDetails[CustSlipNoSetAcs.CUSTOMERCODE_TITLE] = dr[CustSlipNoSetAcs.CUSTOMERCODE_TITLE];
                // 計上年月
                // DEL 2008/10/06 不具合対応[6262]↓
                //drDetails[CustSlipNoSetAcs.ADDUPYEARMONTH_TITLE] = dr[CustSlipNoSetAcs.ADDUPYEARMONTH_TITLE];
                // ---ADD 2008/10/06 不具合対応[6262] ------------------------------------------->>>>>
                if (dr[CustSlipNoSetAcs.ADDUPYEARMONTH_TITLE].Equals(0))
                {
                    drDetails[CustSlipNoSetAcs.ADDUPYEARMONTH_TITLE] = " ";
                }
                else
                {
                    drDetails[CustSlipNoSetAcs.ADDUPYEARMONTH_TITLE] = dr[CustSlipNoSetAcs.ADDUPYEARMONTH_TITLE];
                }
                // ---ADD 2008/10/06 不具合対応[6262] -------------------------------------------<<<<<

                // 現在得意先伝票番号
                drDetails[CustSlipNoSetAcs.PRESENTCUSTSLIPNO_TITLE] = dr[CustSlipNoSetAcs.PRESENTCUSTSLIPNO_TITLE];
                // 開始得意先伝票番号
                drDetails[CustSlipNoSetAcs.STARTCUSTSLIPNO_TITLE] = dr[CustSlipNoSetAcs.STARTCUSTSLIPNO_TITLE];
                // 終了得意先伝票番号
                drDetails[CustSlipNoSetAcs.ENDCUSTSLIPNO_TITLE] = dr[CustSlipNoSetAcs.ENDCUSTSLIPNO_TITLE];

                // --- DEL 2008/09/22 -------------------------------->>>>>
                //// 得意先伝票番号ヘッダ
                //drDetails[CustSlipNoSetAcs.CUSTSLIPNOHEADER_TITLE] = dr[CustSlipNoSetAcs.CUSTSLIPNOHEADER_TITLE];
                //// 得意先伝票番号フッタ
                //drDetails[CustSlipNoSetAcs.CUSTSLIPNOFOOTER_TITLE] = dr[CustSlipNoSetAcs.CUSTSLIPNOFOOTER_TITLE];
                // --- DEL 2008/09/22 --------------------------------<<<<<

                // 削除日
                drDetails[CustSlipNoSetAcs.DELETE_DATE_TITLE] = dr[CustSlipNoSetAcs.DELETE_DATE_TITLE];

                this._bindDataSet.Tables[DETAILS_TABLE].Rows.Add(drDetails);
            }

            totalCount = this._bindDataSet.Tables[DETAILS_TABLE].Rows.Count;
            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            // メインテーブルの削除日を設定
            SetMainTableDeleteDate();   // ADD 2008/03/24 不具合対応[12695]↓：「削除済データの表示」は最上位項目で制御

            return status;
        }

        /// <summary>
        /// ネクストデータ検索処理
        /// </summary>
        /// <param name="readCount">抽出対象件数</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note		: ArrayTypeでは未実装</br>
        /// <br>Programmer : 30416 長沼 賢二</br>
        /// <br>Date       : 2008.06.26</br>
        /// </remarks>
        public int DetailsDataSearchNext(int readCount)
        {
            // EOF
            return (int)ConstantManagement.DB_Status.ctDB_EOF;
        }

        /// <summary>
        /// データ論理削除処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 選択中のデータを論理削除します。</br>
        /// <br>Programmer : 30416 長沼 賢二</br>
        /// <br>Date       : 2008.06.26</br>
        /// </remarks>
        public int Delete()
        {
            int status = 0;

            switch (this._targetTableName)
            {
                // 端末別伝票出力先テーブルの場合
                case DETAILS_TABLE:
                    {
                        // 端末別伝票出力先論理削除処理
                        status = LogicalDeleteSlipOutputSet();
                        break;
                    }
            }

            return status;
        }

        /// <summary>
        /// 印刷処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 印刷処理を実行します。</br>
        /// <br>Programmer : 30416 長沼 賢二</br>
        /// <br>Date       : 2008.06.26</br>
        /// </remarks>
        public int Print()
        {
            // 印刷用アセンブリをロードする（未実装）
            return 0;
        }

        /// <summary>
        /// グリッド列外観情報取得処理
        /// </summary>
        /// <returns>グリッド列外観情報格納Hashtable</returns>
        /// <remarks>
        /// <br>Note       : 各列の外見を設定するクラスを格納したHashtableを取得します。</br>
        /// <br>Programmer : 30416 長沼 賢二</br>
        /// <br>Date       : 2008.06.26</br>
        /// </remarks>
        public void GetAppearanceTable(out Hashtable[] _hashtable)
        {
            // メイン
            Hashtable main = new Hashtable();

            // ADD 2008/03/24 不具合対応[12695]↓：「削除済データの表示」は最上位項目で制御
            main.Add(CustSlipNoSetAcs.DELETE_DATE_TITLE, new GridColAppearance(MGridColDispType.DeletionDataListOnly, ContentAlignment.MiddleLeft, "", Color.Red));

            //main.Add(CustSlipNoSetAcs.CUSTOMERCODE_TITLE, new GridColAppearance(MGridColDispType.ListOnly, ContentAlignment.MiddleRight, "", Color.Black)); //DEL 2008/09/22
            main.Add(CustSlipNoSetAcs.CUSTOMERCODE_TITLE, new GridColAppearance(MGridColDispType.ListOnly, ContentAlignment.MiddleRight, "00000000", Color.Black)); //ADD 2008/09/22
            main.Add(CustSlipNoSetAcs.CUSTOMERNAME_TITLE, new GridColAppearance(MGridColDispType.ListOnly, ContentAlignment.MiddleLeft, "", Color.Black));

            // 詳細
            Hashtable details = new Hashtable();

            details.Add(CustSlipNoSetAcs.DELETE_DATE_TITLE, new GridColAppearance(MGridColDispType.DeletionDataListOnly, ContentAlignment.MiddleLeft, "", Color.Red));

            details.Add(CustSlipNoSetAcs.CUSTOMERCODE_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
            details.Add(CustSlipNoSetAcs.ADDUPYEARMONTH_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));

            // DEL 2008/12/02 不具合対応[8654] ---------->>>>>
            //details.Add(CustSlipNoSetAcs.PRESENTCUSTSLIPNO_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            //details.Add(CustSlipNoSetAcs.STARTCUSTSLIPNO_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            //details.Add(CustSlipNoSetAcs.ENDCUSTSLIPNO_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            // DEL 2008/12/02 不具合対応[8654] ----------<<<<<

            // ADD 2008/12/02 不具合対応[8654] ---------->>>>>
            details.Add(CustSlipNoSetAcs.PRESENTCUSTSLIPNO_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "000000000", Color.Black));
            details.Add(CustSlipNoSetAcs.STARTCUSTSLIPNO_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "000000000", Color.Black));
            details.Add(CustSlipNoSetAcs.ENDCUSTSLIPNO_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "000000000", Color.Black));
            // ADD 2008/12/02 不具合対応[8654] ----------<<<<<

            // --- DEL 2008/09/22 -------------------------------->>>>>
            //details.Add(CustSlipNoSetAcs.CUSTSLIPNOHEADER_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //details.Add(CustSlipNoSetAcs.CUSTSLIPNOFOOTER_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // --- DEL 2008/09/22 --------------------------------<<<<<

            _hashtable = new Hashtable[2];
            _hashtable[0] = main;
            _hashtable[1] = details;
        }
        #endregion

        #region データセット列情報構築処理
        /// <summary>
        /// データセット列情報構築処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : データセットの列情報を構築します。</br>
        /// <br>Programmer : 30416 長沼 賢二</br>
        /// <br>Date       : 2008.06.26</br>
        /// </remarks>
        private void DataSetColumnConstruction(ref DataSet ds)
        {
            //===============================
            // メインテーブル定義（端末番号）
            //===============================
            DataTable mainTable = new DataTable(MAIN_TABLE);

            // 削除日
            mainTable.Columns.Add(CustSlipNoSetAcs.DELETE_DATE_TITLE, typeof(string));  // ADD 2008/03/24 不具合対応[12695]：「削除済データの表示」は最上位項目で制御

            // 得意先コード
            //mainTable.Columns.Add(CustSlipNoSetAcs.CUSTOMERCODE_TITLE, typeof(string)); //DEL 2008/09/22
            mainTable.Columns.Add(CustSlipNoSetAcs.CUSTOMERCODE_TITLE, typeof(Int32)); //ADD 2008/09/22
            // 得意先略称（内部保持用）
            mainTable.Columns.Add(CustSlipNoSetAcs.CUSTOMERNAME_TITLE, typeof(string));


            DataColumn[] primaryKey1 = { mainTable.Columns[CustSlipNoSetAcs.CUSTOMERCODE_TITLE] };
            mainTable.PrimaryKey = primaryKey1;

            this._bindDataSet.Tables.Add(mainTable);

            //============================
            // 詳細テーブル定義（伝票印刷）
            //============================
            DataTable detailsTable = new DataTable(DETAILS_TABLE);

            // 削除日
            detailsTable.Columns.Add(CustSlipNoSetAcs.DELETE_DATE_TITLE, typeof(string));

            // 得意先コード
            detailsTable.Columns.Add(CustSlipNoSetAcs.CUSTOMERCODE_TITLE, typeof(Int32));
            // 計上年月
            // DEL 2008/10/06 不具合対応[6262]↓
            //detailsTable.Columns.Add(CustSlipNoSetAcs.ADDUPYEARMONTH_TITLE, typeof(Int32));
            detailsTable.Columns.Add(CustSlipNoSetAcs.ADDUPYEARMONTH_TITLE, typeof(string));    // ADD 2008/10/06 不具合対応[6262]

            // 現在得意先伝票番号
            detailsTable.Columns.Add(CustSlipNoSetAcs.PRESENTCUSTSLIPNO_TITLE, typeof(Int64));
            // 開始得意先伝票番号
            detailsTable.Columns.Add(CustSlipNoSetAcs.STARTCUSTSLIPNO_TITLE, typeof(Int64));
            // 終了得意先伝票番号
            detailsTable.Columns.Add(CustSlipNoSetAcs.ENDCUSTSLIPNO_TITLE, typeof(Int64));

            // --- DEL 2008/09/22 -------------------------------->>>>>
            //// 得意先伝票番号ヘッダ
            //detailsTable.Columns.Add(CustSlipNoSetAcs.CUSTSLIPNOHEADER_TITLE, typeof(string));
            //// 得意先伝票番号フッタ
            //detailsTable.Columns.Add(CustSlipNoSetAcs.CUSTSLIPNOFOOTER_TITLE, typeof(string));
            // --- DEL 2008/09/22 --------------------------------<<<<<

            DataColumn[] primaryKey2 = { detailsTable.Columns[CustSlipNoSetAcs.CUSTOMERCODE_TITLE],
										 detailsTable.Columns[CustSlipNoSetAcs.ADDUPYEARMONTH_TITLE] };
            detailsTable.PrimaryKey = primaryKey2;

            this._bindDataSet.Tables.Add(detailsTable);
        }
        #endregion

        #region 画面初期設定処理
        /// <summary>
        /// 画面初期設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面の初期設定を行います。</br>
        /// <br>Programmer : 30416 長沼 賢二</br>
        /// <br>Date       : 2008.06.26</br>
        /// </remarks>
        private void ScreenInitialSetting()
        {
            // UI画面表示時のチラつきを抑える為に、ここでサイズ等変更
            switch (this._targetTableName)
            {
                // 端末番号テーブルの場合
                case MAIN_TABLE:
                    {
                        break;
                    }
                // 伝票印刷テーブルの場合
                case DETAILS_TABLE:
                    {
                        // 新規の場合
                        if (this._detailsDataIndex < 0)
                        {
                            ScreenInputPermissionControl(3);                        // 画面入力許可制御
                            break;
                        }
                        // 削除の場合
                        if ((string)this._bindDataSet.Tables[DETAILS_TABLE].Rows[this._detailsDataIndex][CustSlipNoSetAcs.DELETE_DATE_TITLE] != "")
                        {
                            ScreenInputPermissionControl(5);                        // 画面入力許可制御
                            break;
                        }
                        // 更新の場合
                        else
                        {
                            ScreenInputPermissionControl(4);                        // 画面入力許可制御
                            break;
                        }
                    }
            }
        }
        /// <summary>
        /// 画面入力許可制御処理
        /// </summary>
        /// <param name="setType">設定タイプ 0:親-新規, 1:親-更新, 2:親-削除, 3:子-新規, 4:子-更新, 5:子-削除</param>
        /// <remarks>
        /// <br>Note       : 画面の入力許可を制御します。</br>
        /// <br>Programmer : 30416 長沼 賢二</br>
        /// <br>Date       : 2008.06.26</br>
        /// </remarks>
        private void ScreenInputPermissionControl(int setType)
        {
            switch (setType)
            {
                // 0:レジ-新規
                case 0:
                    {
                        break;
                    }
                // 1:レジ-更新
                case 1:
                    {
                        break;
                    }
                // 2:レジ-削除
                case 2:
                    {
                        break;
                    }
                // 3:伝票-新規
                case 3:
                    {
                        // 項目
                        this.tComboEditor1.Enabled = true;

                        // --- ADD 2008/09/22 -------------------------------->>>>>
                        this.PresentCustSlipNo_tNedit.Enabled = true;
                        this.StartCustSlipNo_tNedit.Enabled = true;
                        this.EndCustSlipNo_tNedit.Enabled = true;
                        // --- ADD 2008/09/22 --------------------------------<<<<< 
                        
                        // ボタン
                        this.Ok_Button.Visible = true;
                        this.Cancel_Button.Visible = true;
                        this.Delete_Button.Visible = false;
                        this.Revive_Button.Visible = false;

                        break;
                    }
                // 4:伝票-更新
                case 4:
                    {
                        // 項目
                        this.tComboEditor1.Enabled = false;

                        this.tDateEdit1.Enabled = false;

                        // --- ADD 2008/09/22 -------------------------------->>>>>
                        this.PresentCustSlipNo_tNedit.Enabled = true;
                        this.StartCustSlipNo_tNedit.Enabled = true;
                        this.EndCustSlipNo_tNedit.Enabled = true;
                        // --- ADD 2008/09/22 --------------------------------<<<<< 

                        // ボタン
                        this.Ok_Button.Visible = true;
                        this.Cancel_Button.Visible = true;
                        this.Revive_Button.Visible = false;
                        this.Delete_Button.Visible = false;

                        break;
                    }
                // 5:伝票-削除
                case 5:
                    {
                        // 項目
                        this.tComboEditor1.Enabled = false;

                        this.tDateEdit1.Enabled = false;

                        // --- ADD 2008/09/22 -------------------------------->>>>>
                        this.PresentCustSlipNo_tNedit.Enabled = false;
                        this.StartCustSlipNo_tNedit.Enabled = false;
                        this.EndCustSlipNo_tNedit.Enabled = false;
                        // --- ADD 2008/09/22 --------------------------------<<<<< 

                        // ボタン
                        this.Ok_Button.Visible = false;
                        this.Cancel_Button.Visible = true;
                        this.Delete_Button.Visible = true;
                        this.Revive_Button.Visible = true;

                        break;
                    }
            }
        }
        /// <summary>
        /// 画面クリア処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面をクリアします。</br>
        /// <br>Programmer : 30416 長沼 賢二</br>
        /// <br>Date       : 2008.06.26</br>
        /// </remarks>
        private void ScreenClear()
        {
            // モードラベル
            this.Mode_Label.Text = INSERT_MODE;

            // ボタン
            this.Ok_Button.Visible = true;  // 保存ボタン
            this.Cancel_Button.Visible = true;  // 閉じるボタン
            this.Delete_Button.Visible = true;  // 完全削除ボタン
            this.Revive_Button.Visible = true;  // 復活ボタン
            this.Delete_Button.Location = new Point(BUTTON_LOCATION1_X, BUTTON_LOCATION_Y); // 完全削除ボタン位置
            this.Revive_Button.Location = new Point(BUTTON_LOCATION2_X, BUTTON_LOCATION_Y); // 復活ボタン位置
            this.Ok_Button.Location = new Point(BUTTON_LOCATION2_X, BUTTON_LOCATION_Y); // 保存ボタン位置
            this.Cancel_Button.Location = new Point(BUTTON_LOCATION3_X, BUTTON_LOCATION_Y); // 閉じるボタン位置

            // 項目
            this.tDateEdit1.Clear();            // 計上年月
        }
        #endregion

        #region 画面再構築処理
        /// <summary>
        /// 画面再構築処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : モードに基づいて画面を再構築します。</br>
        /// <br>Programmer : 30416 長沼 賢二</br>
        /// <br>Date       : 2008.06.26</br>
        /// </remarks>
        private void ScreenReconstruction()
        {
            switch (this._targetTableName)
            {
                // 端末番号テーブルの場合
                case MAIN_TABLE:
                    {
                        break;
                    }
                // 伝票印刷テーブルの場合
                case DETAILS_TABLE:
                    {
                        DataRow dr;

                        // 新規の場合
                        if (this._detailsDataIndex < 0)
                        {
                            //---------------------------------------------------
                            // キー項目設定（以下は全てキーなので必ず設定が必要）
                            //---------------------------------------------------
                            dr = this._bindDataSet.Tables[DETAILS_TABLE].NewRow();


                            // 得意先コード
                            dr[CustSlipNoSetAcs.CUSTOMERCODE_TITLE] = this._bindDataSet.Tables[MAIN_TABLE].Rows[this._mainDataIndex][CustSlipNoSetAcs.CUSTOMERCODE_TITLE];

                            // 計上年月
                            dr[CustSlipNoSetAcs.ADDUPYEARMONTH_TITLE] = CustSlipNoSetAcs.NullChgInt(this.tDateEdit1.GetDateTime());

                            // 画面展開処理
                            DataRowToScreen(dr);

                            //--------------------------------
                            // コンボボックスデフォルト値設定
                            //--------------------------------
                            this.tComboEditor1.SelectedIndex = 0;

                            //--------------------
                            // 比較用クローン作成
                            //--------------------
                            this._dataTableClone = this._bindDataSet.Tables[DETAILS_TABLE].Clone();
                            DataRow drClone = this._dataTableClone.NewRow();

                            // アイテムコピー
                            for (int i = 0; i < dr.ItemArray.Length; i++)
                            {
                                drClone[i] = dr[i];
                            }
                            this._dataTableClone.Rows.Add(drClone);

                            // フォーカス設定
                            this.tComboEditor1.Focus();

                            break;
                        }

                        //----- 更新データ取得 -----
                        dr = this._bindDataSet.Tables[DETAILS_TABLE].Rows[this._detailsDataIndex];

                        // 削除の場合
                        if ((string)dr[CustSlipNoSetAcs.DELETE_DATE_TITLE] != "")
                        {
                            // 削除モード
                            this.Mode_Label.Text = DELETE_MODE;

                            // 画面展開処理
                            DataRowToScreen(dr);
                        }
                        // 更新の場合
                        else
                        {
                            // 更新モード
                            this.Mode_Label.Text = UPDATE_MODE;

                            // 画面展開処理
                            DataRowToScreen(dr);

                            //--------------------
                            // 比較用クローン作成
                            //--------------------
                            this._dataTableClone = this._bindDataSet.Tables[DETAILS_TABLE].Clone();
                            DataRow drClone = this._dataTableClone.NewRow();

                            // アイテムコピー
                            for (int i = 0; i < dr.ItemArray.Length; i++)
                            {
                                drClone[i] = dr[i];
                            }
                            this._dataTableClone.Rows.Add(drClone);

                            // フォーカス設定
                            //this.SlipPrtKind_tComboEditor.Focus();
                        }
                    }
                    break;
            }
        }
        #endregion

        #region 画面情報保存処理
        /// <summary>
        /// 保存処理
        /// </summary>
        /// <param name="saveTarget">保存マスタ (PrdExchPNU/PrdExchPPU)</param>
        /// <returns>チェック結果</returns>
        /// <remarks>
        /// <br>Note　　　 : 保存処理を行います。</br>
        /// <br>Programmer : 30416 長沼 賢二</br>
        /// <br>Date       : 2008.06.26</br>
        /// </remarks>
        private bool SaveProc(string saveTarget)
        {
            Control control = null;
            string message = null;

            // 不正データ入力チェック
            if (!ScreenDataCheck(ref control, ref message))
            {
                TMsgDisp.Show(
                    this, 								// 親ウィンドウフォーム
                    emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
                    ASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
                    message, 							// 表示するメッセージ
                    0, 									// ステータス値
                    MessageBoxButtons.OK);				// 表示するボタン

                control.Focus();
                return false;
            }

            switch (saveTarget)
            {
                // 伝票印刷テーブルの場合
                case DETAILS_TABLE:
                    {
                        // 更新
                        if (!SaveCustSlipNoSet())
                        {
                            return false;
                        }
                        break;
                    }
            }
            return true;
        }

        /// <summary>
        /// 画面入力情報不正チェック処理
        /// </summary>
        /// <param name="control">不正対象コントロール</param>
        /// <param name="message">メッセージ</param>
        /// <returns>チェック結果（true:OK／false:NG）</returns>
        /// <remarks>
        /// <br>Note	　 : 画面入力情報の不正チェックを行います。</br>
        /// <br>Programmer : 30416 長沼 賢二</br>
        /// <br>Date       : 2008.06.26</br>
        /// <br>Update Note: 2013/02/08 宋剛</br>
        /// <br>管理番号   : 10801804-00 2013/03/13配信分</br>
        /// <br>             Redmine#34616 No.1641得意先伝票番号チェックの不具合修正</br>
        /// </remarks>
        private bool 
            ScreenDataCheck(ref Control control, ref string message)
        {
            bool result = true;

            // 得意先コード
            if (this.tNedit_CustomerCode.Text.Trim() == "")
            {
                message = this.CustomerCode_Title_Label.Text + "を入力してください。";
                control = this.tNedit_CustomerCode;
                result = false;

                return result; // ADD 2008/09/26
            }

            // 現在得意伝票番号
            //if ((this.StartCustSlipNo_tNedit.GetInt() <= this.PresentCustSlipNo_tNedit.GetInt()) && (this.PresentCustSlipNo_tNedit.GetInt() <= this.EndCustSlipNo_tNedit.GetInt()))   // DEL 宋剛 2013/02/08 FOR Redmine#34616
            if ((this.StartCustSlipNo_tNedit.GetInt() <= this.PresentCustSlipNo_tNedit.GetInt() + 1) && (this.PresentCustSlipNo_tNedit.GetInt() <= this.EndCustSlipNo_tNedit.GetInt())) // ADD 宋剛 2013/02/08 FOR Redmine#34616
            {
                // --------------- ADD 宋剛 2013/02/08 FOR Redmine#34616-------->>>> 
                if (this.StartCustSlipNo_tNedit.GetInt() > this.EndCustSlipNo_tNedit.GetInt())
                {
                    message = "現在得意先伝票番号より大きい番号を入力してください。";
                    control = this.EndCustSlipNo_tNedit;
                    result = false;

                    return result;
                }
                // --------------- ADD 宋剛 2013/02/08 FOR Redmine#34616--------<<<< 

                // OK
            }
            else
            {
                // ADD 2008/12/02 不具合対応[8566] ---------->>>>>
                if (this.PresentCustSlipNo_tNedit.GetInt() > this.EndCustSlipNo_tNedit.GetInt())
                {
                    //message = this.EndCustSlipNo_Title_Label.Text + "を範囲内で入力してください。"; // DEL 2008/12/03 不具合対応[8566] 
                    message = "現在得意先伝票番号より大きい番号を入力してください。";   // ADD 2008/12/03 不具合対応[8566] 
                    control = this.EndCustSlipNo_tNedit;
                    result = false;

                    return result; // ADD 2008/09/26
                }
                // ADD 2008/12/02 不具合対応[8566] ----------<<<<<
                message = this.PresentCustSlipNo_Title_Label.Text + "を範囲内で入力してください。";
                control = this.PresentCustSlipNo_tNedit;
                result = false;

                return result; // ADD 2008/09/26
            }

            // 連番以外の場合
            if (tComboEditor1.SelectedIndex != 0)
            {
                // --- DEL 2008/09/22 -------------------------------->>>>>
                //if (this.tDateEdit1.GetDateTime() == DateTime.MinValue)
                //{
                //    message = this.AddUpYearMonth_Title_Label.Text + "を入力してください。"; ;
                //    control = this.tDateEdit1;
                //    result = false;
                //}
                // --- DEL 2008/09/22 -------------------------------->>>>>
                // --- ADD 2008/09/22 -------------------------------->>>>>

                DateGetAcs.CheckDateResult checkDateResult = this._dateGetAcs.CheckDate(ref this.tDateEdit1, false);

                // --- ADD 2008/09/26 -------------------------------->>>>>
                if (checkDateResult == DateGetAcs.CheckDateResult.OK)
                {
                    // OK
                }
                else if (checkDateResult == DateGetAcs.CheckDateResult.ErrorOfNoInput)
                {
                    message = "計上年月が未入力です。";
                    control = this.tDateEdit1;
                    result = false;

                    return result;
                }
                else
                {
                    message = "計上年月が不正です。";
                    control = this.tDateEdit1;
                    result = false;

                    return result;
                }
                // --- ADD 2008/09/26 --------------------------------<<<<<

                // --- DEL 2008/09/24 -------------------------------->>>>>
                //if (checkDateResult != DateGetAcs.CheckDateResult.OK)
                //{
                //    message = "計上年月が不正です。";
                //    control = this.tDateEdit1;
                //    result = false;
                //}
                // --- DEL 2008/09/24 --------------------------------<<<<<
                // --- ADD 2008/09/22 --------------------------------<<<<<
            }

            return result;
        }

        /// <summary>
        /// 画面情報伝票出力先設定クラス格納処理
        /// </summary>
        /// <param name="custSlipNoSet">伝票出力先設定オブジェクト</param>
        /// <remarks>
        /// <br>Note       : 画面情報から伝票出力先設定オブジェクトにデータを格納します。</br>
        /// <br>Programmer : 30416 長沼 賢二</br>
        /// <br>Date       : 2008.06.26</br>
        /// </remarks>
        private void DispToCustSlipNoSet(ref CustSlipNoSet custSlipNoSet)
        {
            // 企業コード
            custSlipNoSet.EnterpriseCode = this._enterpriseCode;

            switch (this._targetTableName)
            {
                // レジテーブルの場合
                case MAIN_TABLE:
                    {
                        break;
                    }
                // 伝票印刷テーブルの場合
                case DETAILS_TABLE:
                    {
                        custSlipNoSet.CustomerCode = this.tNedit_CustomerCode.GetInt();

                        if (tComboEditor1.SelectedIndex == 0)
                        {
                            custSlipNoSet.AddUpYearMonth = 0;
                        }
                        else if (tComboEditor1.SelectedIndex == 1)
                        {
                            DateTime AddUpDate = this.tDateEdit1.GetDateTime();
                            string AddYear = AddUpDate.Year.ToString();
                            string AddMonth = AddUpDate.Month.ToString().PadLeft(2,'0');

                            custSlipNoSet.AddUpYearMonth = int.Parse(AddYear + AddMonth);
                        }
                        else
                        {
                            DateTime AddUpDate = this.tDateEdit1.GetDateTime();
                            string AddYear = AddUpDate.Year.ToString();

                            custSlipNoSet.AddUpYearMonth = int.Parse(AddYear);
                        }

                        custSlipNoSet.PresentCustSlipNo = CustSlipNoSetAcs.NullChgInt(this.PresentCustSlipNo_tNedit.Value);
                        custSlipNoSet.StartCustSlipNo = CustSlipNoSetAcs.NullChgInt(this.StartCustSlipNo_tNedit.Value);
                        custSlipNoSet.EndCustSlipNo = CustSlipNoSetAcs.NullChgInt(this.EndCustSlipNo_tNedit.Value);

                        //custSlipNoSet.CustSlipNoHeader = this.CustSlipNoHeader_tEdit.Text; //DEL 2008/09/22
                        //custSlipNoSet.CustSlipNoFooter = this.CustSlipNoFooter_tEdit.Text; //DEL 2008/09/22

                        break;
                    }
            }
        }

        /// <summary>
        /// 新規登録時処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 新規登録時の処理を行います。</br>
        /// <br>Programmer : 30416 長沼 賢二</br>
        /// <br>Date       : 2008.06.26</br>
        /// </remarks>
        private void NewEntryTransaction()
        {
            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }
            // 新規モードの場合は画面を終了せずに連続入力を可能とする
            if (this.Mode_Label.Text == INSERT_MODE)
            {
                if (TargetTableName == MAIN_TABLE)
                {
                    // データインデックスを初期化する
                    this._mainDataIndex = -1;
                }

                // フレーム更新（読み込みせず、ソートのみ）
                int dataCnt = 0;
                DetailsDataSearch(ref dataCnt, 0);

                // 画面クリア処理
                ScreenClear();
                // 画面初期設定処理
                ScreenInitialSetting();
                // 画面再構築処理
                ScreenReconstruction();
            }
            else
            {
                this.DialogResult = DialogResult.OK;

                if (CanClose == true)
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
        /// UI子画面強制終了処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : データ更新エラー時のUI子画面強制終了処理を行います。</br>
        /// <br>Programmer : 30416 長沼 賢二</br>
        /// <br>Date       : 2008.06.26</br>
        /// </remarks>
        private void EnforcedEndTransaction()
        {
            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }

            this.DialogResult = DialogResult.Cancel;
            this._mainDataIndex = -2;
            this._detailsDataIndex = -2;

            this._targetTableName = "";

            if (CanClose == true)
            {
                this.Close();
            }
            else
            {
                this.Hide();
            }
        }

        /// <summary>
        /// 重複処理
        /// </summary>
        /// <param name="status">ステータス</param>
        /// <param name="control">コントロール</param>
        /// <remarks>
        /// <br>Note       : データ更新時の重複処理を行います。</br>
        /// <br>Programmer : 30416 長沼 賢二</br>
        /// <br>Date       : 2008.06.26</br>
        /// </remarks>
        private void RepeatTransaction(int status, ref Control control)
        {
            TMsgDisp.Show(
                this, 								// 親ウィンドウフォーム
                emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
                ASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
                ERR_DPR_MSG, 	                    // 表示するメッセージ
                0, 									// ステータス値
                MessageBoxButtons.OK);				// 表示するボタン

            switch (TargetTableName)
            {
                // 端末番号テーブルの場合
                case MAIN_TABLE:
                    {
                        break;
                    }
                // 伝票印刷テーブルの場合
                case DETAILS_TABLE:
                    {
                        control = this.tComboEditor1;
                        break;
                    }
            }
        }

        /// <summary>
        /// 排他処理
        /// </summary>
        /// <param name="operation">オペレーション</param>
        /// <param name="erObject">エラーオブジェクト</param>
        /// <param name="status">ステータス</param>
        /// <remarks>
        /// <br>Note       : データ更新時の排他処理を行います。</br>
        /// <br>Programmer : 30416 長沼 賢二</br>
        /// <br>Date       : 2008.06.26</br>
        /// </remarks>
        private void ExclusiveTransaction(int status, string operation, object erObject)
        {
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    {
                        TMsgDisp.Show(
                            this,								// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,	// エラーレベル
                            ASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
                            this.Text,							// プログラム名称
                            "ExclusiveTransaction",				// 処理名称
                            operation,							// オペレーション
                            ERR_800_MSG,						// 表示するメッセージ 
                            status,								// ステータス値
                            erObject,							// エラーが発生したオブジェクト
                            MessageBoxButtons.OK,				// 表示するボタン
                            MessageBoxDefaultButton.Button1);	// 初期表示ボタン
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        TMsgDisp.Show(
                            this,								// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,	// エラーレベル
                            ASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
                            this.Text,							// プログラム名称
                            "ExclusiveTransaction",				// 処理名称
                            operation,							// オペレーション
                            ERR_801_MSG,						// 表示するメッセージ 
                            status,								// ステータス値
                            erObject,							// エラーが発生したオブジェクト
                            MessageBoxButtons.OK,				// 表示するボタン
                            MessageBoxDefaultButton.Button1);	// 初期表示ボタン
                        break;
                    }
            }
        }

        /// <summary>
        /// 画面入力情報保存処理
        /// </summary>
        /// <returns></returns>
        private bool SaveCustSlipNoSet()
        {
            //==========================
            // 書き込み処理
            //==========================
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            CustSlipNoSet custSlipNoSet = new CustSlipNoSet();
            Control control = null;

            // 明細項目
            DispToCustSlipNoSet(ref custSlipNoSet);

            // 書き込み
            string message;

            // 更新の場合作成日付設定
            if (this.Mode_Label.Text == UPDATE_MODE)
            {
                // 変更前更新データ取得
                DataRow dr = this._bindDataSet.Tables[DETAILS_TABLE].Rows[this._detailsDataIndex];
                CustSlipNoSet custSlipNoSetPre = null;

                status = this._custSlipNoSetAcs.GetSlipOutputSet(CustSlipNoSetAcs.NullChgInt(dr[CustSlipNoSetAcs.CUSTOMERCODE_TITLE]),
                                                                 CustSlipNoSetAcs.NullChgInt(dr[CustSlipNoSetAcs.ADDUPYEARMONTH_TITLE]),
                                                                 out custSlipNoSetPre,
                                                                 out message);

                // 更新に必要な情報をDataTableから再セット
                custSlipNoSet.CreateDateTime = custSlipNoSetPre.CreateDateTime;
                custSlipNoSet.UpdateDateTime = custSlipNoSetPre.UpdateDateTime;
                custSlipNoSet.FileHeaderGuid = custSlipNoSetPre.FileHeaderGuid;
            }

            status = this._custSlipNoSetAcs.Write(ref custSlipNoSet, out message);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // DataSet/Hash更新処理
                        DetailsToDataSet(custSlipNoSet, this._detailsDataIndex);

                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE:
                    {
                        // 重複処理
                        RepeatTransaction(status, ref control);
                        control.Focus();
                        return false;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        // 排他処理
                        ExclusiveTransaction(status, TMsgDisp.OPE_UPDATE, this._custSlipNoSetAcs);
                        // UI子画面強制終了処理
                        EnforcedEndTransaction();
                        return false;
                    }
                default:
                    {
                        emErrorLevel emErrLvl = emErrorLevel.ERR_LEVEL_INFO;
                        if (status == (int)ConstantManagement.DB_Status.ctDB_ERROR)
                        {
                            emErrLvl = emErrorLevel.ERR_LEVEL_STOP;
                        }

                        TMsgDisp.Show(this,                                // 親ウィンドウフォーム
                                       emErrLvl,                            // エラーレベル
                                       ASSEMBLY_ID,                       // アセンブリＩＤまたはクラスＩＤ
                                       //"端末別伝票出力先設定", 	            		    // プログラム名称   // DEL 2009/04/28
                                       "得意先設定(伝票設定)",             // プログラム名称       // ADD 2009/04/28
                                       "SaveDispData", 	                    // 処理名称
                                       TMsgDisp.OPE_UPDATE, 				// オペレーション
                                       message,                             // 表示するメッセージ
                                       status,  							// ステータス値
                                       this._custSlipNoSetAcs,               // エラーが発生したオブジェクト
                                       MessageBoxButtons.OK,                // 表示するボタン
                                       MessageBoxDefaultButton.Button1);	// 初期選択ボタン

                        // UI子画面強制終了処理
                        EnforcedEndTransaction();

                        return false;
                    }
            }
            // 新規登録時処理
            NewEntryTransaction();

            return true;
        }

        /// <summary>
        /// データ変更チェック処理
        /// </summary>
        /// <returns>チェック結果（true:変更有り, false:変更無し）</returns>
        /// <remarks>
        /// <br>Note       : データ変更チェックを行います。</br>
        /// <br>Programmer : 30416 長沼 賢二</br>
        /// <br>Date       : 2008.06.26</br>
        /// </remarks>
        private bool CompareData()
        {
            bool retBool = false;
            int chkCnt = 0;
            DataRow dr = this._dataTableClone.Rows[0];

            chkCnt += CustSlipNoSetAcs.NullChgInt(this.PresentCustSlipNo_tNedit.Value)
                        == CustSlipNoSetAcs.NullChgInt(dr[CustSlipNoSetAcs.PRESENTCUSTSLIPNO_TITLE]) ? 0 : 1;

            chkCnt += CustSlipNoSetAcs.NullChgInt(this.StartCustSlipNo_tNedit.Value)
                        == CustSlipNoSetAcs.NullChgInt(dr[CustSlipNoSetAcs.STARTCUSTSLIPNO_TITLE]) ? 0 : 1;

            chkCnt += CustSlipNoSetAcs.NullChgInt(this.EndCustSlipNo_tNedit.Value)
                        == CustSlipNoSetAcs.NullChgInt(dr[CustSlipNoSetAcs.ENDCUSTSLIPNO_TITLE]) ? 0 : 1;
            
            // --- DEL 2008/09/22 -------------------------------->>>>>
            //chkCnt += CustSlipNoSetAcs.NullChgStr(this.CustSlipNoHeader_tEdit.Value)
            //            == CustSlipNoSetAcs.NullChgStr(dr[CustSlipNoSetAcs.CUSTSLIPNOHEADER_TITLE]) ? 0 : 1;

            //chkCnt += CustSlipNoSetAcs.NullChgStr(this.CustSlipNoFooter_tEdit.Value)
            //            == CustSlipNoSetAcs.NullChgStr(dr[CustSlipNoSetAcs.CUSTSLIPNOFOOTER_TITLE]) ? 0 : 1;
            // --- DEL 2008/09/22 --------------------------------<<<<<

            // 変更有り
            if (chkCnt > 0)
            {
                retBool = true;
            }
            return retBool;
        }

        /// <summary>
        /// コンボボックス用データセット列情報構築処理
        /// </summary>
        /// <remarks>
        /// <param name="wkTable">データテーブル</param>
        /// <br>Note       : コンボボックス用データセットの列情報を構築します。</br>
        /// <br>Programmer : 30416 長沼 賢二</br>
        /// <br>Date       : 2008.06.26</br>
        /// </remarks>
        private void DataTblColumnComboInt(ref DataTable wkTable)
        {
            wkTable.Columns.Add(COMBO_CODE, typeof(Int32));		// コード
            wkTable.Columns.Add(COMBO_NAME, typeof(string));	// 名称

            // プライマリキー設定
            wkTable.PrimaryKey = new DataColumn[] { wkTable.Columns[COMBO_CODE] };
        }


        /// <summary>
        /// コンボボックス用データセット列情報構築処理
        /// </summary>
        /// <remarks>
        /// <param name="wkTable">データテーブル</param>
        /// <br>Note       : コンボボックス用データセットの列情報を構築します。</br>
        /// <br>Programmer : 30416 長沼 賢二</br>
        /// <br>Date       : 2008.06.26</br>
        /// </remarks>
        private void DataTblColumnComboStr(ref DataTable wkTable)
        {
            // コンボボックス表示項目
            wkTable.Columns.Add(COMBO_CODE, typeof(string));	// コード
            wkTable.Columns.Add(COMBO_NAME, typeof(string));	// 名称

            // プライマリキー設定
            wkTable.PrimaryKey = new DataColumn[] { wkTable.Columns[COMBO_CODE] };
        }

        /// <summary>
        /// コンボボックスデータ設定
        /// </summary>
        /// <remarks>
        /// <param name="sList">ソートリスト</param>
        /// <param name="dataTable">データテーブル</param>
        /// <br>Note       : コンボボックスデータを設定します。</br>
        /// <br>Programmer : 30416 長沼 賢二</br>
        /// <br>Date       : 2008.06.26</br>
        /// </remarks>
        private void SetComboDataInt(ref SortedList sList, ref DataTable dataTable)
        {
            try
            {
                foreach (DictionaryEntry de in sList)
                {
                    DataRow dr = dataTable.NewRow();

                    dr[COMBO_CODE] = (Int32)de.Key;
                    dr[COMBO_NAME] = de.Value.ToString();

                    dataTable.Rows.Add(dr);
                }
            }
            catch
            {
            }
        }

        /// <summary>
        /// コンボボックスバインド
        /// </summary>
        /// <remarks>
        /// <param name="tCombo">TComboEditor</param>
        /// <param name="dataTable">データテーブル</param>
        /// <br>Note       : コンボボックスにバインドします。</br>
        /// <br>Programmer : 30416 長沼 賢二</br>
        /// <br>Date       : 2008.06.26</br>
        /// </remarks>
        private void BindCombo(ref TComboEditor tCombo, ref DataTable dataTable)
        {
            tCombo.DisplayMember = COMBO_NAME;
            tCombo.DataSource = dataTable.DefaultView;
        }

        #endregion

        #region Events
        /// <summary>
        /// フォームロード・イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        private void PMKHN09100UA_Load(object sender, EventArgs e)
        {
            // 画面スキンファイルの読込(デフォルトスキン指定)
            this._controlScreenSkin.LoadSkin();

            // 画面スキン変更
            this._controlScreenSkin.SettingScreenSkin(this);

            // アイコンリソース管理クラスを使用して、アイコンを表示する
            ImageList imageList25 = IconResourceManagement.ImageList24;
            ImageList imageList16 = IconResourceManagement.ImageList16;

            this.Delete_Button.ImageList = imageList25;
            this.Ok_Button.ImageList = imageList25;
            this.Revive_Button.ImageList = imageList25;
            this.Cancel_Button.ImageList = imageList25;

            this.Delete_Button.Appearance.Image = Size24_Index.DELETE;
            this.Ok_Button.Appearance.Image = Size24_Index.SAVE;
            this.Revive_Button.Appearance.Image = Size24_Index.REVIVAL;
            this.Cancel_Button.Appearance.Image = Size24_Index.CLOSE;

            this.tComboEditor1.Items.Clear();   // ADD 2009/06/19
            this.tComboEditor1.Items.Add(0, EXTRACTION_DIVISION1);
            this.tComboEditor1.Items.Add(0, EXTRACTION_DIVISION2);
            this.tComboEditor1.Items.Add(0, EXTRACTION_DIVISION3);
            this.tComboEditor1.SelectedIndex = 0;
        }

        /// <summary>
        /// Timer.Tick イベント イベント(Initial_Timer)(SF100%流用)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 指定された間隔の時間が経過したときに発生します。</br>
        ///	<br>             この処理は、システムが提供するスレッド プール</br>
        ///	<br>             スレッドで実行されます。</br>
        /// <br>Programmer : 30416 長沼 賢二</br>
        /// <br>Date       : 2008.06.26</br>
        /// </remarks>
        private void Initial_Timer_Tick(object sender, EventArgs e)
        {
            Initial_Timer.Enabled = false;
            ScreenReconstruction();
        }

        /// <summary>
        /// Control.VisibleChanged イベント(MAKHN09810UA)(SF100%流用)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note 　　  : フォームの表示状態が変わったときに発生します。</br>
        /// <br>Programmer : 30416 長沼 賢二</br>
        /// <br>Date       : 2008.06.26</br>
        /// </remarks>
        private void PMKHN09100UA_VisibleChanged(object sender, EventArgs e)
        {
            // 自分自身が非表示になった場合は以下の処理をキャンセルする。
            if (this.Visible == false)
            {
                this.Owner.Activate();
                return;
            }

            // 画面クリア
            ScreenClear();

            // 画面初期設定処理
            ScreenInitialSetting();

            Initial_Timer.Enabled = true;
        }

        /// <summary>
        /// Control.Click イベント(Delete_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 完全削除ボタンがクリックされたときに発生します。</br>
        /// <br>Programmer : 30416 長沼 賢二</br>
        /// <br>Date       : 2008.06.26</br>
        /// </remarks>
        private void Delete_Button_Click(object sender, EventArgs e)
        {
            // 削除確認
            DialogResult result = TMsgDisp.Show(
                                       this,                                // 親ウィンドウフォーム
                                       emErrorLevel.ERR_LEVEL_EXCLAMATION,  // エラーレベル
                                       ASSEMBLY_ID,                       // アセンブリＩＤまたはクラスＩＤ
                                       "データを削除します。" + "\r\n" +
                                       "よろしいですか？",                  // 表示するメッセージ
                                       0, 									// ステータス値
                                       MessageBoxButtons.OKCancel,
                                       MessageBoxDefaultButton.Button2);	// 表示するボタン
            if (result != DialogResult.OK)
            {
                // OK以外の時は終了
                this.Delete_Button.Focus();
                return;
            }

            //==========================
            // 以降削除処理
            //==========================
            if (result == DialogResult.OK)
            {
                switch (this._targetTableName)
                {
                    // 部門テーブルの場合
                    case MAIN_TABLE:
                        {
                            break;
                        }
                    // 端末別伝票出力先テーブルの場合
                    case DETAILS_TABLE:
                        {
                            // 部門物理削除
                            PhysicalDeleteSlipOutputSet();
                            break;
                        }
                }
            }
        }
        /// <summary>
        /// Control.Click イベント(Revive_Button)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : 復活ボタンがクリックされたときに発生します。</br>
        /// <br>Programmer : 30416 長沼 賢二</br>
        /// <br>Date       : 2008.06.26</br>
        /// </remarks>
        private void Revive_Button_Click(object sender, EventArgs e)
        {
            // ADD 2008/12/02 不具合対応[8565] ---------->>>>>
            // 復活
            DialogResult result = TMsgDisp.Show(
                                       this,                                // 親ウィンドウフォーム
                                       emErrorLevel.ERR_LEVEL_EXCLAMATION,  // エラーレベル
                                       ASSEMBLY_ID,                       // アセンブリＩＤまたはクラスＩＤ
                                       "現在表示中の得意先を復活します。" + "\r\n" +
                                       "よろしいですか？",
                                       0, 									// ステータス値
                                       MessageBoxButtons.OKCancel,
                                       MessageBoxDefaultButton.Button2);	// 表示するボタン
            if (result != DialogResult.OK)
            {
                // OK以外の時は終了
                this.Revive_Button.Focus();
                return;
            }
            // ADD 2008/12/02 不具合対応[8565] ----------<<<<<

            ReviveCustSlipNoSet();
        }

        /// <summary>
        /// Control.Click イベント(OK_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 保存ボタンがクリックされたときに発生します。</br>
        /// <br>Programmer : 30416 長沼 賢二</br>
        /// <br>Date       : 2008.06.26</br>
        /// </remarks>
        private void Ok_Button_Click(object sender, EventArgs e)
        {
            bool flag = false;

            if (this.Mode_Label.Text == INSERT_MODE)
            {
                // 新規は必ず保存処理を行う
                flag = true;
            }
            else
            {
                // 更新時は変更点があれば保存処理を行う
                flag = CompareData();
            }

            if (flag == true)
            {
                SaveProc(this._targetTableName);
            }
            else
            {
                this.DialogResult = DialogResult.OK;

                if (CanClose == true)
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
        /// <br>Note       : 閉じるボタンがクリックされたときに発生します。</br>
        /// <br>Programmer : 30416 長沼 賢二</br>
        /// <br>Date       : 2008.06.26</br>
        /// </remarks>
        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            //============================
            // 保存確認
            //============================
            if (this.Mode_Label.Text != DELETE_MODE)
            {
                bool change = false;

                // 削除モード以外の時は、保存確認
                if (_targetTableName == MAIN_TABLE)
                {
                    // ※MAIN_TABLEの更新は未実装
                }
                else
                {
                    // 変更点比較
                    change = CompareData();
                }

                if (change)
                {
                    // 変更あり -> 保存確認
                    DialogResult res = TMsgDisp.Show(
                                           this, 								// 親ウィンドウフォーム
                                           emErrorLevel.ERR_LEVEL_SAVECONFIRM,  // エラーレベル
                                           ASSEMBLY_ID, 						// アセンブリＩＤまたはクラスＩＤ
                                           null, 								// 表示するメッセージ
                                           0, 									// ステータス値
                                           MessageBoxButtons.YesNoCancel);	    // 表示するボタン
                    switch (res)
                    {
                        case DialogResult.Yes:
                            {
                                if (SaveProc(this._targetTableName))
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
                                Cancel_Button.Focus();
                                return;
                            }
                    }
                }
            }

            //============================
            // 画面クローズ(非表示)
            //============================
            // 画面非表示イベント
            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.Cancel);
                UnDisplaying(this, me);
            }

            this.DialogResult = DialogResult.Cancel;

            if (CanClose == true)
            {
                this.Close();
            }
            else
            {
                this.Hide();
            }
        }

        /// <summary>
        /// Form.Closing イベント(PMKHN09100UA)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">キャンセルできるイベントのデータを提供するクラス</param>
        /// <remarks>
        /// <br>Note       : フォームを閉じる前に、ユーザーがフォームを閉じようとしたときに発生します。</br>
        /// <br>Programmer : 30416 長沼 賢二</br>
        /// <br>Date       : 2008.06.26</br>
        /// </remarks>
        private void PMKHN09100UA_Closing(object sender, FormClosingEventArgs e)
        {
            // フォームの「×」をクリックされた場合の対応です。
            if (CanClose == false)
            {
                e.Cancel = true;
                this.Hide();
                return;
            }
        }

        #endregion

        #region 得意先設定(伝票設定)クラス画面展開処理
        /// <summary>
        /// 得意先設定(伝票設定)クラス画面展開処理
        /// </summary>
        /// <param name="row">データロウ</param>
        /// <remarks>
        /// <br>Note       : オブジェクトから画面にデータを展開します。</br>
        /// <br>Programmer : 30416 長沼 賢二</br>
        /// <br>Date       : 2008.06.26</br>
        /// </remarks>
        private void DataRowToScreen(DataRow row)
        {
            //-----------------------------------------------
            // MainおよびSecondグリッドから取得
            //-----------------------------------------------
            // 得意先コード
            //this.tNedit_CustomerCode.Text = this._bindDataSet.Tables[MAIN_TABLE].Rows[this._mainDataIndex][CustSlipNoSetAcs.CUSTOMERCODE_TITLE].ToString(); //DEL 2008/09/22
            this.tNedit_CustomerCode.SetInt((int)this._bindDataSet.Tables[MAIN_TABLE].Rows[this._mainDataIndex][CustSlipNoSetAcs.CUSTOMERCODE_TITLE]); //ADD 2008/09/22 
            // 得意先略称
            this.uLabel_CustomerName.Text = this._bindDataSet.Tables[MAIN_TABLE].Rows[this._mainDataIndex][CustSlipNoSetAcs.CUSTOMERNAME_TITLE].ToString();

            //-----------------------------------------------
            // 画面入力から取得
            //-----------------------------------------------

            if (CustSlipNoSetAcs.NullChgInt(row[CustSlipNoSetAcs.ADDUPYEARMONTH_TITLE]) == 0)
            {
                this.tComboEditor1.Text = EXTRACTION_DIVISION1;
            }
            else if (CustSlipNoSetAcs.NullChgInt(row[CustSlipNoSetAcs.ADDUPYEARMONTH_TITLE]) > 0 && CustSlipNoSetAcs.NullChgInt(row[CustSlipNoSetAcs.ADDUPYEARMONTH_TITLE]) < 10000)
            {
                this.tComboEditor1.Text = EXTRACTION_DIVISION3;

                this.tDateEdit1.LongDate = int.Parse(row[CustSlipNoSetAcs.ADDUPYEARMONTH_TITLE].ToString().PadRight(8,'0'));
            }
            else
            {
                this.tComboEditor1.Text = EXTRACTION_DIVISION2;

                tDateEdit1.LongDate = int.Parse(row[CustSlipNoSetAcs.ADDUPYEARMONTH_TITLE].ToString().PadRight(8,'0'));

            }
            // DEL 2008/12/02 不具合対応[8654] ---------->>>>>
            //// 現在得意先伝票番号
            //this.PresentCustSlipNo_tNedit.Value = CustSlipNoSetAcs.NullChgInt(row[CustSlipNoSetAcs.PRESENTCUSTSLIPNO_TITLE]);
            //// 開始得意先伝票番号
            //this.StartCustSlipNo_tNedit.Value = CustSlipNoSetAcs.NullChgInt(row[CustSlipNoSetAcs.STARTCUSTSLIPNO_TITLE]);
            //// 終了得意先伝票番号
            //this.EndCustSlipNo_tNedit.Value = CustSlipNoSetAcs.NullChgInt(row[CustSlipNoSetAcs.ENDCUSTSLIPNO_TITLE]);
            // DEL 2008/12/02 不具合対応[8654] ----------<<<<<

            // ADD 2008/12/02 不具合対応[8654] ---------->>>>>
            // 現在得意先伝票番号
            this.PresentCustSlipNo_tNedit.SetInt(CustSlipNoSetAcs.NullChgInt(row[CustSlipNoSetAcs.PRESENTCUSTSLIPNO_TITLE]));
            // 開始得意先伝票番号
            this.StartCustSlipNo_tNedit.SetInt(CustSlipNoSetAcs.NullChgInt(row[CustSlipNoSetAcs.STARTCUSTSLIPNO_TITLE]));
            // 終了得意先伝票番号
            this.EndCustSlipNo_tNedit.SetInt(CustSlipNoSetAcs.NullChgInt(row[CustSlipNoSetAcs.ENDCUSTSLIPNO_TITLE]));
            // ADD 2008/12/02 不具合対応[8654] ----------<<<<<

            // --- DEL 2008/09/22 -------------------------------->>>>>
            //// 得意先伝票番号ヘッダ
            //this.CustSlipNoHeader_tEdit.Value = CustSlipNoSetAcs.NullChgStr(row[CustSlipNoSetAcs.CUSTSLIPNOHEADER_TITLE]);
            //// 得意先伝票番号フッタ
            //this.CustSlipNoFooter_tEdit.Value = CustSlipNoSetAcs.NullChgStr(row[CustSlipNoSetAcs.CUSTSLIPNOFOOTER_TITLE]);
            // --- DEL 2008/09/22 --------------------------------<<<<<

        }
        #endregion

        #region データセット更新
        /// <summary>
        /// データセット更新処理（ＤＢ更新を表示内容に反映させる）
        /// </summary>
        /// <param name="slipOutputSet">伝票印刷設定クラス</param>
        /// <param name="index">インデックス</param>
        private void DetailsToDataSet(CustSlipNoSet custSlipNoSet, int index)
        {
            if ((index < 0) || (this._bindDataSet.Tables[DETAILS_TABLE].Rows.Count <= index))
            {
                // 新規と判断して、行を追加する
                DataRow dataRow = this._bindDataSet.Tables[DETAILS_TABLE].NewRow();

                //--------------
                // キー項目設定
                //--------------
                // 端末番号
                dataRow[CustSlipNoSetAcs.CUSTOMERCODE_TITLE] = custSlipNoSet.CustomerCode;
                // データ入力システム
                dataRow[CustSlipNoSetAcs.ADDUPYEARMONTH_TITLE] = custSlipNoSet.AddUpYearMonth;

                this._bindDataSet.Tables[DETAILS_TABLE].Rows.Add(dataRow);

                // indexを行の最終行番号する
                index = this._bindDataSet.Tables[DETAILS_TABLE].Rows.Count - 1;
            }

            // 論理削除区分
            if (custSlipNoSet.LogicalDeleteCode == 0)
            {
                this._bindDataSet.Tables[DETAILS_TABLE].Rows[index][CustSlipNoSetAcs.DELETE_DATE_TITLE] = "";
            }
            else
            {
                this._bindDataSet.Tables[DETAILS_TABLE].Rows[index][CustSlipNoSetAcs.DELETE_DATE_TITLE] = custSlipNoSet.UpdateDateTimeJpInFormal;
            }


            // 端末番号
            this._bindDataSet.Tables[DETAILS_TABLE].Rows[index][CustSlipNoSetAcs.ADDUPYEARMONTH_TITLE] = custSlipNoSet.AddUpYearMonth;

            // 倉庫コード
            this._bindDataSet.Tables[DETAILS_TABLE].Rows[index][CustSlipNoSetAcs.PRESENTCUSTSLIPNO_TITLE] = custSlipNoSet.PresentCustSlipNo;
            // 倉庫名称
            this._bindDataSet.Tables[DETAILS_TABLE].Rows[index][CustSlipNoSetAcs.STARTCUSTSLIPNO_TITLE] = custSlipNoSet.StartCustSlipNo;
            // 伝票印刷種別
            this._bindDataSet.Tables[DETAILS_TABLE].Rows[index][CustSlipNoSetAcs.ENDCUSTSLIPNO_TITLE] = custSlipNoSet.EndCustSlipNo;

            // --- DEL 2008/09/22 -------------------------------->>>>>
            //// 伝票印刷設定用帳票ID
            //this._bindDataSet.Tables[DETAILS_TABLE].Rows[index][CustSlipNoSetAcs.CUSTSLIPNOHEADER_TITLE] = custSlipNoSet.CustSlipNoHeader;
            //// プリンタ管理No
            //this._bindDataSet.Tables[DETAILS_TABLE].Rows[index][CustSlipNoSetAcs.CUSTSLIPNOFOOTER_TITLE] = custSlipNoSet.CustSlipNoFooter;
            // --- DEL 2008/09/22 --------------------------------<<<<<

        }

        /// <summary>
        /// データセット削除処理（ＤＢ更新を表示内容に反映させる）
        /// </summary>
        /// <param name="slipOutputSet">伝票印刷設定クラス</param>
        /// <param name="index">インデックス</param>
        private void DeleteFromDataSet(CustSlipNoSet custSlipNoSet, int index)
        {
            // データセットから行削除します
            this._bindDataSet.Tables[DETAILS_TABLE].Rows[index].Delete();
        }
        #endregion

        #region LogicalDelete
        /// <summary>
        /// 論理削除処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 対象レコードをマスタから論理削除します。</br>
        /// <br>Programmer : 30416 長沼 賢二</br>
        /// <br>Date       : 2008.06.26</br>
        /// </remarks>
        private int LogicalDeleteSlipOutputSet()
        {
            CustSlipNoSet custSlipNoSet;
            string message;

            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            //================================
            // 削除が可能か最終確認
            //================================
            if (this._detailsDataIndex < 0)
            {
                // 未選択
                return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }

            // 削除予定データ取得
            DataRow dr = this._bindDataSet.Tables[DETAILS_TABLE].Rows[this._detailsDataIndex];

            status = this._custSlipNoSetAcs.GetSlipOutputSet(   CustSlipNoSetAcs.NullChgInt(dr[CustSlipNoSetAcs.CUSTOMERCODE_TITLE]),
                                                                CustSlipNoSetAcs.NullChgInt(dr[CustSlipNoSetAcs.ADDUPYEARMONTH_TITLE]),
                                                                out custSlipNoSet,
                                                                out message);

            if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                // PGミス
                TMsgDisp.Show(this, 								// 親ウィンドウフォーム
                               emErrorLevel.ERR_LEVEL_INFO,     	// エラーレベル
                               ASSEMBLY_ID, 						// アセンブリＩＤまたはクラスＩＤ
                               "明細項目がヒットしません。",        // 表示するメッセージ
                               0, 		                            // ステータス値
                               MessageBoxButtons.OK, 				// 表示するボタン
                               MessageBoxDefaultButton.Button1);	// 初期表示ボタン

                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            //==========================
            // 選択データを削除
            //==========================
            status = this._custSlipNoSetAcs.LogicalDelete(ref custSlipNoSet, out message);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // データテーブル再構築
                DetailsToDataSet(custSlipNoSet, this._detailsDataIndex);
            }

            return status;
        }
        #endregion

        #region PhysicalDelete
        /// <summary>
        /// 物理削除処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 対象レコードをマスタから物理削除します。</br>
        /// <br>Programmer : 30416 長沼 賢二</br>
        /// <br>Date       : 2008.06.26</br>
        /// </remarks>
        private int PhysicalDeleteSlipOutputSet()
        {
            CustSlipNoSet custSlipNoSet;
            string message;

            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            //================================
            // 削除が可能か最終確認
            //================================
            if (this._detailsDataIndex < 0)
            {
                // 未選択
                return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }

            // 削除予定データ取得
            DataRow dr = this._bindDataSet.Tables[DETAILS_TABLE].Rows[this._detailsDataIndex];

            status = this._custSlipNoSetAcs.GetSlipOutputSet(   CustSlipNoSetAcs.NullChgInt(dr[CustSlipNoSetAcs.CUSTOMERCODE_TITLE]),
                                                                CustSlipNoSetAcs.NullChgInt(dr[CustSlipNoSetAcs.ADDUPYEARMONTH_TITLE]),
                                                                out custSlipNoSet,
                                                                out message);

            if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                // PGミス
                TMsgDisp.Show(this, 								// 親ウィンドウフォーム
                               emErrorLevel.ERR_LEVEL_INFO,     	// エラーレベル
                               ASSEMBLY_ID, 						// アセンブリＩＤまたはクラスＩＤ
                               "明細項目がヒットしません。",        // 表示するメッセージ
                               0, 		                            // ステータス値
                               MessageBoxButtons.OK, 				// 表示するボタン
                               MessageBoxDefaultButton.Button1);	// 初期表示ボタン

                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            //==========================
            // 選択データを削除
            //==========================
            status = this._custSlipNoSetAcs.Delete(ref custSlipNoSet, out message);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // データテーブル再構築
                DeleteFromDataSet(custSlipNoSet, this._detailsDataIndex);
            }

            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }

            this.DialogResult = DialogResult.OK;

            if (CanClose == true)
            {
                this.Close();
            }
            else
            {
                this.Hide();
            }
            return status;
        }
        #endregion

        #region Revive
        /// <summary>
        /// 復活処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 対象レコードを復活します。</br>
        /// <br>Programmer : 30416 長沼 賢二</br>
        /// <br>Date       : 2008.06.26</br>
        /// </remarks>
        private int ReviveCustSlipNoSet()
        {
            int status = 0;
            CustSlipNoSet custSlipNoSet;
            string message;

            // 復活対象取得
            DataRow dr = this._bindDataSet.Tables[DETAILS_TABLE].Rows[this._detailsDataIndex];

            status = this._custSlipNoSetAcs.GetSlipOutputSet(   CustSlipNoSetAcs.NullChgInt(dr[CustSlipNoSetAcs.CUSTOMERCODE_TITLE]),
                                                                CustSlipNoSetAcs.NullChgInt(dr[CustSlipNoSetAcs.ADDUPYEARMONTH_TITLE]),
                                                                out custSlipNoSet,
                                                                out message);
            // 復活
            status = this._custSlipNoSetAcs.Revival(ref custSlipNoSet, out message);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // DataSet展開処理
                        DetailsToDataSet(custSlipNoSet, this._detailsDataIndex);
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        // 排他処理
                        ExclusiveTransaction(status, TMsgDisp.OPE_UPDATE, this._detailsDataIndex);
                        return status;
                    }
                default:
                    {
                        TMsgDisp.Show(
                            this,								// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOPDISP,    // エラーレベル
                            ASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
                            this.Text,							// プログラム名称
                            "ReviveSlipOutputSet",				// 処理名称
                            TMsgDisp.OPE_UPDATE,				// オペレーション
                            ERR_RVV_MSG,						// 表示するメッセージ 
                            status,								// ステータス値
                            this._custSlipNoSetAcs,    			// エラーが発生したオブジェクト
                            MessageBoxButtons.OK,				// 表示するボタン
                            MessageBoxDefaultButton.Button1);	// 初期表示ボタン
                        return status;
                    }
            }

            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }
            this.DialogResult = DialogResult.OK;

            if (CanClose == true)
            {
                this.Close();
            }
            else
            {
                this.Hide();
            }
            return status;
        }
        #endregion

        /// <summary>
        /// リターンキー移動イベント
        /// </summary>
        /// <remarks>
        /// <br>Note	   : リターンキー押下時の制御を行います。</br>
        /// <br>Programmer : 30416 長沼 賢二</br>
        /// <br>Date       : 2008.06.24</br>
        /// </remarks>
        private void tRetKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null)
            {
                return;
            }

            switch (e.PrevCtrl.Name)
            {

                case "tNedit_CustomerCode":
                    {
                        if (tNedit_CustomerCode.GetInt() == 0) return;

                        CustomerInfo customerInfo;

                        int status = this._customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, this._enterpriseCode, tNedit_CustomerCode.GetInt(), true, out customerInfo);

                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            // 親かを判定し、子の場合は与信額・警告与信額・現在売掛残高は入力不可
                            if (customerInfo.ClaimCode != tNedit_CustomerCode.GetInt())
                            {
                                this.PresentCustSlipNo_tNedit.Enabled = false;
                                this.StartCustSlipNo_tNedit.Enabled = false;
                                this.EndCustSlipNo_tNedit.Enabled = false;
                            }
                            else
                            {
                                this.PresentCustSlipNo_tNedit.Enabled = true;
                                this.StartCustSlipNo_tNedit.Enabled = true;
                                this.EndCustSlipNo_tNedit.Enabled = true;
                            }
                            this.PresentCustSlipNo_tNedit.Text = "0";
                            this.StartCustSlipNo_tNedit.Text = "0";
                            this.EndCustSlipNo_tNedit.Text = "0";
                        }
                        else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                        {
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                this.Name,
                                "選択した得意先は既に削除されています。",
                                status,
                                MessageBoxButtons.OK);
                            this.tNedit_CustomerCode.Text = string.Empty;
                            this.uLabel_CustomerName.Text = string.Empty;

                            return;
                        }
                        else
                        {
                            TMsgDisp.Show(this,
                                          emErrorLevel.ERR_LEVEL_STOPDISP,
                                          this.Name,
                                          "得意先情報の取得に失敗しました。",
                                          status,
                                          MessageBoxButtons.OK);
                            this.tNedit_CustomerCode.Text = string.Empty;
                            this.uLabel_CustomerName.Text = string.Empty;

                            return;
                        }

                        this.tNedit_CustomerCode.Text = customerInfo.CustomerCode.ToString().Trim();
                        this.uLabel_CustomerName.Text = customerInfo.CustomerSnm; // 略称
                        break;
                    }
            }

            // 2009.03.30 30413 犬飼 新規モードからモード変更対応 >>>>>>START
            switch (e.NextCtrl.Name)
            {
                case "PresentCustSlipNo_tNedit":    // 現在得意先伝票番号
                case "StartCustSlipNo_tNedit":      // 開始得意先伝票番号
                case "EndCustSlipNo_tNedit":        // 終了得意先伝票番号
                    {
                        if (this._detailsDataIndex < 0)
                        {
                            if (ModeChangeProc())
                            {
                                e.NextCtrl = tComboEditor1;

                            }
                        }
                        break;
                    }
            }
            // 2009.03.30 30413 犬飼 新規モードからモード変更対応 <<<<<<END
        }

        /// <summary>
        /// 抽出区分選択変更時イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note	   : 抽出区分を変更時に発生します。</br>
        /// <br>Programmer : 30416 長沼 賢二</br>
        /// <br>Date       : 2008.06.24</br>
        /// </remarks>
        private void tComboEditor1_SelectionChanged(object sender, EventArgs e)
        {
            if (tComboEditor1.SelectedIndex == 0)
            {
                this.tDateEdit1.Clear();

                this.tDateEdit1.Enabled = false;
            }
            else if (tComboEditor1.SelectedIndex == 1)
            {
                this.tDateEdit1.Clear();

                this.tDateEdit1.DateFormat = emDateFormat.df4Y2M;

                if (this.tComboEditor1.Enabled == true)
                {
                    this.tDateEdit1.Enabled = true;
                }
            }
            else if (tComboEditor1.SelectedIndex == 2)
            {
                this.tDateEdit1.Clear();

                this.tDateEdit1.DateFormat = emDateFormat.df4Y;

                if (this.tComboEditor1.Enabled == true)
                {
                    this.tDateEdit1.Enabled = true;
                }
            }
        }

        /// <summary>
        /// 計上年月Leave時イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : 計上年月からフォーカスが離れたときに発生します。</br>
        /// <br>Programmer : 30416 長沼 賢二</br>
        /// <br>Date       : 2008.06.26</br>
        /// </remarks>
        private void tDateEdit1_Leave(object sender, EventArgs e)
        {
            if (tDateEdit1.DateFormat == emDateFormat.df4Y2M)
            {
                this.tDateEdit1.LongDate += 1;
            }
            else if (tDateEdit1.DateFormat == emDateFormat.df4Y)
            {
                this.tDateEdit1.LongDate += 101; 
            }
        }

        // 2009.03.30 30413 犬飼 新規モードからモード変更対応 >>>>>>START
        /// <summary>
        /// モード変更処理(得意先別)
        /// </summary>
        private bool ModeChangeProc()
        {
            // 抽出区分
            int selIdx = tComboEditor1.SelectedIndex;
            // 得意先コード
            int customerCode = tNedit_CustomerCode.GetInt();
            // 計上年月
            int addUpDate = 0;
            if (selIdx != 0)
            {
                if (selIdx == 1)
                {
                    addUpDate = (tDateEdit1.GetDateYear() * 100) + tDateEdit1.GetDateMonth();
                }
                else if (selIdx == 2)
                {
                    addUpDate = tDateEdit1.GetDateYear();
                }

                if (addUpDate == 0)
                {
                    // 計上年月が未入力
                    return false;
                }
            }

            for (int i = 0; i < this._bindDataSet.Tables[DETAILS_TABLE].Rows.Count; i++)
            {
                // データセットと比較
                int dsCustomerCode = (int)this._bindDataSet.Tables[DETAILS_TABLE].Rows[i][CustSlipNoSetAcs.CUSTOMERCODE_TITLE];
                int dsAddUpDate = 0;
                string strAddUpDate = this._bindDataSet.Tables[DETAILS_TABLE].Rows[i][CustSlipNoSetAcs.ADDUPYEARMONTH_TITLE].ToString().Trim();
                if (strAddUpDate != string.Empty)
                {
                    dsAddUpDate = int.Parse(strAddUpDate);
                }
                if ((customerCode == dsCustomerCode) &&
                    (addUpDate == dsAddUpDate))
                {
                    // 入力コードがデータセットに存在する場合
                    if ((string)this._bindDataSet.Tables[DETAILS_TABLE].Rows[i][CustSlipNoSetAcs.DELETE_DATE_TITLE] != "")
                    {
                        // 論理削除
                        TMsgDisp.Show(this, 					// 親ウィンドウフォーム
                          emErrorLevel.ERR_LEVEL_INFO,          // エラーレベル
                          ASSEMBLY_ID,						    // アセンブリＩＤまたはクラスＩＤ
                          "入力されたコードの得意先伝票番号情報は既に削除されています。", 			// 表示するメッセージ
                          0, 									// ステータス値
                          MessageBoxButtons.OK);				// 表示するボタン
                        // 抽出区分、計上年月のクリア
                        tComboEditor1.SelectedIndex = 0;
                        tDateEdit1.DateFormat = emDateFormat.df4Y2M;
                        tDateEdit1.Clear();
                        return true;
                    }

                    DialogResult res = TMsgDisp.Show(
                        this,                                   // 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_INFO,            // エラーレベル
                        ASSEMBLY_ID,                            // アセンブリＩＤまたはクラスＩＤ
                        "入力されたコードの得意先伝票番号情報が既に登録されています。\n編集を行いますか？",   // 表示するメッセージ
                        0,                                      // ステータス値
                        MessageBoxButtons.YesNo);               // 表示するボタン
                    switch (res)
                    {
                        case DialogResult.Yes:
                            {
                                // 画面再描画
                                this._detailsDataIndex = i;
                                ScreenClear();
                                ScreenInitialSetting();
                                ScreenReconstruction();
                                break;
                            }
                        case DialogResult.No:
                            {
                                // 抽出区分、計上年月のクリア
                                tComboEditor1.SelectedIndex = 0;
                                tDateEdit1.DateFormat = emDateFormat.df4Y2M;
                                tDateEdit1.Clear();
                                break;
                            }
                    }
                    return true;
                }
            }
            return false;
        }
        // 2009.03.30 30413 犬飼 新規モードからモード変更対応 <<<<<<END

        // DEL 2008/12/03 不具合対応[8563] ---------->>>>>
        //// ADD 2008/12/02 不具合対応[8563] ---------->>>>>
        //private void tDateEdit1_ValueChanged(object sender, EventArgs e)
        //{
        //    //if (this.tDateEdit1.GetDateDay() != 0)
        //    //{
        //    //    //this.tDateEdit1.SetLongDate(Int32.Parse(this.tDateEdit1.GetLongDate().ToString().Substring(0, 6) + "00"));
        //    //    this.PresentCustSlipNo_tNedit.Focus();
        //    //}
        //}
        //// ADD 2008/12/02 不具合対応[8563] ----------<<<<<
        // DEL 2008/12/03 不具合対応[8563] ----------<<<<<

    }
}