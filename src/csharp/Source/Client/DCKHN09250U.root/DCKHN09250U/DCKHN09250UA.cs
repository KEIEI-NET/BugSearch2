//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : 端末別伝票出力先設定
// プログラム概要   : 端末別伝票出力先マスタの登録・修正・削除を行います。
//----------------------------------------------------------------------------//
//                (c)Copyright  2007 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 上野　弘貴
// 作 成 日  2007/12/10  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 上野　弘貴
// 修 正 日  2007/12/19  修正内容 : 伝票印刷設定マスタ紐づけ対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 上野　弘貴
// 修 正 日  2008/03/17  修正内容 : 
// ・データ入力システムを非表示
// ・伝票印刷種別ワークシート, ボディ寸法図削除
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 忍 幸史
// 修 正 日  2008/09/11  修正内容 : データビューの列幅自動調整チェックボックスのデフォルト値変更
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2008/10/03  修正内容 : バグ修正、仕様変更対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 行澤 仁美
// 修 正 日  2008/10/09  修正内容 : バグ修正
//----------------------------------------------------------------------------//
// 管理番号  10304       作成担当 : 照田 貴志
// 修 正 日  2009/01/21  修正内容 : バグ修正
//----------------------------------------------------------------------------//
// 管理番号  10657       作成担当 : 照田 貴志
// 修 正 日  2009/01/29  修正内容 : バグ修正
//----------------------------------------------------------------------------//
// 管理番号  11798       作成担当 : 照田 貴志
// 修 正 日  2009/02/25  修正内容 : バグ修正
//----------------------------------------------------------------------------//
// 管理番号  12698       作成担当 : 工藤　恵優
// 修 正 日  2009/03/24  修正内容 : バグ修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30413 犬飼
// 修正日    2009/04/07  修正内容 : Mantis【12605】プリンタ情報の最新情報取得対応
// ---------------------------------------------------------------------------//
// 管理番号              作成担当 : 30517 夏野 駿希
// 修正日    2010/06/29  修正内容 : Mantis【15669】エラーメッセージの変更
// ---------------------------------------------------------------------------//
// 管理番号              作成担当 : 22018 鈴木 正臣
// 修正日    2010/09/27  修正内容 : 一般帳票も設定可能に変更。
// ---------------------------------------------------------------------------//
// 管理番号              作成担当 : 22018 鈴木 正臣
// 修正日    2010/10/12  修正内容 : データビューのソート順を変更。(帳票が最後にまとまるように)
// ---------------------------------------------------------------------------//
// 管理番号  10900691-00 作成担当 : chenw
// 修正日    2013/03/01  修正内容 : 2013/05/15配信分 Redmine#34828 №746 端末別伝票出力先設定 
// ---------------------------------------------------------------------------//

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
    /// 端末別伝票出力先設定
    /// </summary>
    /// <remarks>
    /// <br>Note       : 端末別伝票出力先マスタの登録・修正・削除を行います。</br>
	/// <br>				IMasterMaintenanceMultiTypeを実装しています。</br>
    /// <br>Programmer : 30167 上野　弘貴</br>
    /// <br>Date       : 2007.12.10</br>
	/// <br>Update Note: 2007/12/19  30167 上野　弘貴</br>
	/// <br>     		 伝票印刷設定マスタ紐づけ対応</br>
	/// <br>Update Note: 2008.03.17  30167 上野　弘貴</br>
	/// <br>             ・データ入力システムを非表示
	///					 ・伝票印刷種別ワークシート, ボディ寸法図削除</br>
    /// <br>Update Note: 2008/09/11  30414 忍 幸史</br>
	/// <br>     		 データビューの列幅自動調整チェックボックスのデフォルト値変更</br>
    /// <br>Update Note: 2008/10/03        照田 貴志</br>
    /// <br>     		 バグ修正、仕様変更対応</br>
    /// <br>UpdateNote : 2008/10/09 30462 行澤 仁美　バグ修正</br>
    /// <br>           : 2009/01/21       照田 貴志　不具合対応[10304]</br>
    /// <br>           : 2009/01/29       照田 貴志　不具合対応[10657]</br>
    /// <br>           : 2009/02/25       照田 貴志　不具合対応[11798]</br>
    /// <br>           : 2009/03/24       工藤 恵優　不具合対応[12692]</br>
    /// <br>Update Note: 2010/09/27 22018 鈴木 正臣  一般帳票も設定可能に変更。</br>
    /// <br>Update Note: 2010/10/12 22018 鈴木 正臣  データビューのソート順を変更。(帳票が最後にまとまるように)</br>
    /// </remarks>
	public partial class DCKHN09250UA : Form, IMasterMaintenanceArrayType
    {
        /// <summary>メイン</summary>
        public const string MAIN_TABLE		= "CashRegisterNo";
        /// <summary>詳細</summary>
        public const string DETAILS_TABLE	= "SlipPrt";

        // グリッドタイトル
        /// <summary>端末番号名称</summary>
        public const string CASHREGISTERNO_GRID_TITLE  = "端末番号";
        /// <summary>伝票印刷名称</summary>
		public const string SLIPPRT_GRID_TITLE = "伝票印刷";

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
        private string  _enterpriseCode = "";
        
        // 端末別伝票出力先マスタアクセスクラス
        private SlipOutputSetAcs _slipOutputSetAcs = null;
		
        // データセット
        private DataSet _bindDataSet = null;

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
		//----- h.ueno add---------- start 2007.12.19
		private int _dataInputSystem_tComboEditorValue = -1;	// データ入力システムデータワーク
		//----- h.ueno add---------- end   2007.12.19
		private int  _slipPrtKind_tComboEditorValue = -1;	    // 伝票印刷種別コンボボックスデータワーク
		private int _printerMngNo_tComboEditorValue = -1;	    // プリンタ管理Noコンボボックスデータワーク
		
		//----- h.ueno add---------- start 2007.12.19
		private DataTable _dataTableDataInputSystem = null;		// データ入力システム
		//----- h.ueno add---------- end   2007.12.19
		private DataTable _dataTableSlipPrtKind = null;			// 伝票印刷種別
		private DataTable _dataTableSlipPrtSetPaperId = null;	// 伝票印刷設定用帳票ID
		private DataTable _dataTablePrinterMngNo = null;		// プリンタ管理No

		// コンボボックス用
		private const string COMBO_CODE = "COMBO_CODE";
		private const string COMBO_NAME = "COMBO_NAME";
		
        // 編集モード
        private const string INSERT_MODE = "新規モード";
        private const string UPDATE_MODE = "更新モード";
        private const string DELETE_MODE = "削除モード";

        private const int BUTTON_LOCATION1_X = 132;     // 完全削除ボタン位置X
        private const int BUTTON_LOCATION2_X = 261;     // 保存/復活ボタン位置X
        // --- UPD m.suzuki 2010/09/27 ---------->>>>>
        //private const int BUTTON_LOCATION3_X = 392;     // 閉じるボタン位置X
        private const int BUTTON_LOCATION3_X = 390;     // 閉じるボタン位置X
        // --- UPD m.suzuki 2010/09/27 ----------<<<<<
        private const int BUTTON_LOCATION_Y = 5;        // ボタン位置Y(共通)

        // Message関連定義
		private const string ASSEMBLY_ID = "DCKHN09250U";
        private const string ERR_READ_MSG = "読み込みに失敗しました。";
        private const string ERR_DPR_MSG = "このコードは既に使用されています。";
        private const string ERR_RDEL_MSG = "削除に失敗しました。";
        private const string ERR_UPDT_MSG = "登録に失敗しました。";
        private const string ERR_RVV_MSG = "復活に失敗しました。";
        private const string ERR_800_MSG = "既に他端末より更新されています";
        private const string ERR_801_MSG = "既に他端末より削除されています";
        private const string SDC_RDEL_MSG = "マスタから削除されています";

        //--- ADD 2008/06/20 ---------->>>>>
        // 倉庫名称
        private const string WAREHOUSECODE_ZERO = "0000";
        private const string WAREHOUSENAME_ZERO = "共通";
        //--- ADD 2008/06/20 ----------<<<<<

        #endregion

        #region Constructor
		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : コンストラクタ</br>
        /// <br>Programmer : 30167 上野　弘貴</br>
        /// <br>Date       : 2007.12.10</br>
        /// </remarks>
        public DCKHN09250UA()
        {
            InitializeComponent();

            //====================================
            // プロパティ初期値設定
            //====================================
            this._canPrint  = false;
            this._canClose  = true;
            this._canNew    = true;
            this._canDelete = true;

			this._mainGridTitle = CASHREGISTERNO_GRID_TITLE;
			this._secondGridTitle = SLIPPRT_GRID_TITLE;
			this._defaultGridDisplayLayout = MGridDisplayLayout.Vertical;

            //====================================
            // 変数初期化
            //====================================
            // 企業コード
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

			// 従業員
			this._employee = LoginInfoAcquisition.Employee;

            // 端末別伝票出力先マスタアクセスクラス
            this._slipOutputSetAcs = new SlipOutputSetAcs();

			// 終了時のチェック用
			this._dataTableClone = new DataTable();
			
			//------------------
			// コンボボックス用
			//------------------
			//----- h.ueno add---------- start 2007.12.19
			this._dataTableDataInputSystem = new DataTable();	// データ入力システム
			//----- h.ueno add---------- end   2007.12.19
			this._dataTableSlipPrtKind = new DataTable();		// 伝票印刷種別
			this._dataTableSlipPrtSetPaperId = new DataTable();	// 伝票印刷設定用帳票ID
			this._dataTablePrinterMngNo = new DataTable();		// プリンタ管理No

			//----- h.ueno add---------- start 2007.12.19
			DataTblColumnComboInt(ref this._dataTableDataInputSystem);
			//----- h.ueno add---------- end   2007.12.19
			DataTblColumnComboInt(ref this._dataTableSlipPrtKind);
			DataTblColumnComboStr(ref this._dataTableSlipPrtSetPaperId);
			DataTblColumnComboInt(ref this._dataTablePrinterMngNo);

            // 各種インデックス初期化
            this._mainDataIndex   = -1;
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
            System.Windows.Forms.Application.Run(new DCKHN09250UA());
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
        /// <br>Programmer : 30167 上野　弘貴</br>
        /// <br>Date       : 2007.12.10</br>
        /// </remarks>
        public bool[] GetCanLogicalDeleteDataExtractionList()
        {
            bool[] logicalDelete = { true, false }; // MOD 2008/03/24 不具合対応[12692]：「削除済データの表示」は最上位項目で制御 { false, true }→{ true, false }
            return logicalDelete;
        }

        /// <summary>
        /// グリッドタイトルリスト取得処理
        /// </summary>
        /// <returns>グリッドタイトルリスト</returns>
        /// <remarks>
        /// <br>Note       : グリッドのタイトルを配列で取得します。</br>
        /// <br>Programmer : 30167 上野　弘貴</br>
        /// <br>Date       : 2007.12.10</br>
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
        /// <br>Programmer : 30167 上野　弘貴</br>
        /// <br>Date       : 2007.12.10</br>
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
        /// <br>Programmer : 30167 上野　弘貴</br>
        /// <br>Date       : 2007.12.10</br>
        /// </remarks>
        public bool[] GetDefaultAutoFillToGridColumnList()
        {
            // --- CHG 2008/09/11 --------------------------------------------------------------------->>>>>
            //bool[] defaultAutoFill = { true, true };
            bool[] defaultAutoFill = { false, false };
            // --- CHG 2008/09/11 ---------------------------------------------------------------------<<<<<
            return defaultAutoFill;
        }

        /// <summary>
        /// データテーブルの選択データインデックスリスト設定処理
        /// </summary>
        /// <param name="indexList">データテーブルの選択データインデックスリスト</param>
        /// <remarks>
        /// <br>Note       : データテーブルの選択データインデックスリストを設定します。</br>
        /// <br>Programmer : 30167 上野　弘貴</br>
        /// <br>Date       : 2007.12.10</br>
        /// </remarks>
        public void SetDataIndexList(int[] indexList)
        {
            int[] intVal = indexList;

            this._mainDataIndex   = intVal[0];
            this._detailsDataIndex = intVal[1];
        }

        /// <summary>
        /// 新規ボタンの有効設定リスト取得処理
        /// </summary>
        /// <returns>新規ボタンの有効設定リスト</returns>
        /// <remarks>
        /// <br>Note       : 新規ボタンの有効設定リストを取得します。</br>
        /// <br>Programmer : 30167 上野　弘貴</br>
        /// <br>Date       : 2007.12.10</br>
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
        /// <br>Programmer : 30167 上野　弘貴</br>
        /// <br>Date       : 2007.12.10</br>
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
        /// <br>Programmer : 30167 上野　弘貴</br>
        /// <br>Date       : 2007.12.10</br>
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
        /// <br>Programmer : 30167 上野　弘貴</br>
        /// <br>Date       : 2007.12.10</br>
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
        /// <br>Programmer : 30167 上野　弘貴</br>
        /// <br>Date       : 2007.12.10</br>
        /// </remarks>
        public int Search(ref int totalCount, int readCount)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            string  message;
            bool    nextData;
            DataSet ds;

            // ADD 2009/03/23 不具合対応[12692]：「削除済データの表示」は最上位項目で制御 ---------->>>>>
            // readCountが負の場合、強制終了
            if (readCount < 0)
            {
                this._bindDataSet.Tables[MAIN_TABLE].Rows.Clear();
                this._bindDataSet.Tables[DETAILS_TABLE].Rows.Clear();
                return 0;
            }
            // ADD 2009/03/23 不具合対応[12692]：「削除済データの表示」は最上位項目で制御 ----------<<<<<

            //-------------------------------------------------------------------
            // 端末別伝票出力先マスタから抽出
            //-------------------------------------------------------------------
            status = this._slipOutputSetAcs.SearchAll(out ds
                                                    ,out totalCount
                                                    ,out nextData
                                                    ,this._enterpriseCode
                                                    ,this._employee.BelongSectionCode
                                                    ,out message);
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                emErrorLevel emErrLvl = emErrorLevel.ERR_LEVEL_INFO;
                if (status == (int)ConstantManagement.DB_Status.ctDB_ERROR)
                {
                    emErrLvl = emErrorLevel.ERR_LEVEL_STOP;
                }
                // 2010/06/29 Add >>>
                string baseMssage = "";
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                        baseMssage = "端末管理マスタの登録を行って下さい。";
                        emErrLvl = emErrorLevel.ERR_LEVEL_EXCLAMATION;
                        break;
                    default:
                        baseMssage = "読み込みに失敗しました。";
                        break;
                }
                // 2010/06/29 Add <<<
                // サーチ
                TMsgDisp.Show(
                        this, 								// 親ウィンドウフォーム
                        emErrLvl,                           // エラーレベル
                        ASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
                        "端末別伝票出力先設定",             // プログラム名称
                        "Search", 							// 処理名称
                        TMsgDisp.OPE_GET,                   // オペレーション
                    // 2010/06/29 >>>
                    //"読み込みに失敗しました。\r\n" + message,  // 表示するメッセージ
                        baseMssage + "\r\n" + message,  // 表示するメッセージ
                    // 2010/06/29 <<<
                        status,                             // ステータス値
                        this._slipOutputSetAcs,    	        // エラーが発生したオブジェクト
                        MessageBoxButtons.OK,               // 表示するボタン
                        MessageBoxDefaultButton.Button1);   // 初期表示ボタン

                return status;
            }

            this._bindDataSet.Tables[MAIN_TABLE].Rows.Clear();
            this._bindDataSet.Tables[DETAILS_TABLE ].Rows.Clear();

			foreach (DataRow dr in ds.Tables[SlipOutputSetAcs.MAIN_TABLE].Rows)
            {
                //--- DEL 2008/06/20 ---------->>>>>
                //DataRow check = this._bindDataSet.Tables[MAIN_TABLE].Rows.Find(new object[] {dr[SlipOutputSetAcs.SECTIONCODE_TITLE], dr[SlipOutputSetAcs.CASHREGISTERNO_TITLE] });
                //--- DEL 2008/06/20 ----------<<<<<
                //--- ADD 2008/06/20 ---------->>>>>
                DataRow check = this._bindDataSet.Tables[MAIN_TABLE].Rows.Find(new object[] { dr[SlipOutputSetAcs.CASHREGISTERNO_TITLE] });
                //--- ADD 2008/06/20 ----------<<<<<
                
                if (check != null)
                {
                    // 登録済みなので次へ
                    continue;
                }

                // データ未登録

                // メインテーブルへの登録
                DataRow drMain = this._bindDataSet.Tables[MAIN_TABLE].NewRow();
                
                // 削除日
                // ADD 2008/03/24 不具合対応[12692]↓：「削除済データの表示」は最上位項目で制御
                drMain[SlipOutputSetAcs.DELETE_DATE_TITLE] = GetDelateDate((int)dr[SlipOutputSetAcs.CASHREGISTERNO_TITLE]);

                // 拠点コード
                //drMain[SlipOutputSetAcs.SECTIONCODE_TITLE] = dr[SlipOutputSetAcs.SECTIONCODE_TITLE];      // DEL 2008/06/20
                
                // 拠点名称（内部保持用）
                //drMain[SlipOutputSetAcs.SECTIONNAME_TITLE] = dr[SlipOutputSetAcs.SECTIONNAME_TITLE];      // DEL 2008/06/20
                
                // 端末番号
				drMain[SlipOutputSetAcs.CASHREGISTERNO_TITLE] = dr[SlipOutputSetAcs.CASHREGISTERNO_TITLE];

                this._bindDataSet.Tables[MAIN_TABLE].Rows.Add(drMain);
            }

            return status;
        }

        // ADD 2009/03/24 不具合対応[12692]：「削除済データの表示」は最上位項目で制御 ---------->>>>>
        /// <summary>
        /// メインテーブルの削除日を取得します。
        /// </summary>
        /// <param name="cashRegisterNo">端末番号</param>
        /// <returns>メインテーブルの削除日（削除されてない場合、<c>string.Empty</c>を返します。）</returns>
        private string GetDelateDate(int cashRegisterNo)
        {
            DataRow[] foundDataRows = this._slipOutputSetAcs.DtDetailsTable.Select(
                SlipOutputSetAcs.CASHREGISTERNO_TITLE + "=" + cashRegisterNo.ToString()
            );
            if (foundDataRows.Length.Equals(0)) return string.Empty;

            // 削除日を収集
            IList<DataRow> deletedRowList = new List<DataRow>();
            foreach (DataRow foundRow in foundDataRows)
            {
                if (!string.IsNullOrEmpty((string)foundRow[SlipOutputSetAcs.DELETE_DATE_TITLE]))
                {
                    deletedRowList.Add(foundRow);
                }
            }

            // サブテーブルのレコードが全て削除の場合、削除日を返す
            if (deletedRowList.Count.Equals(foundDataRows.Length))
            {
                return (string)deletedRowList[0][SlipOutputSetAcs.DELETE_DATE_TITLE];
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
                int cashRegisterNo = (int)mainRow[SlipOutputSetAcs.CASHREGISTERNO_TITLE];
                mainRow[SlipOutputSetAcs.DELETE_DATE_TITLE] = GetDelateDate(cashRegisterNo);
            }
        }
        // ADD 2009/03/24 不具合対応[12692]：「削除済データの表示」は最上位項目で制御 ----------<<<<<

        /// <summary>
        /// ネクストデータ検索処理
        /// </summary>
        /// <param name="readCount">抽出対象件数</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : ArrayTypeでは未実装</br>
        /// <br>Programmer : 30167 上野　弘貴</br>
        /// <br>Date       : 2007.12.10</br>
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
        /// <br>Programmer : 30167 上野　弘貴</br>
        /// <br>Date       : 2007.12.10</br>
        /// </remarks>
		public int DetailsDataSearch(ref int totalCount, int readCount)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            if ( ( this._bindDataSet == null ) || ( this._mainDataIndex < 0 ) )
            {
                return status;
            }

			this._bindDataSet.Tables[DETAILS_TABLE].Rows.Clear();

            // ADD 2009/03/23 不具合対応[12692]：「削除済データの表示」は最上位項目で制御 ---------->>>>>
            // readCountが負の場合、強制終了
            if (readCount < 0) return 0;
            // ADD 2009/03/23 不具合対応[12692]：「削除済データの表示」は最上位項目で制御 ----------<<<<<

			int cashRegisterNo = (int)this._bindDataSet.Tables[MAIN_TABLE].Rows[this._mainDataIndex][SlipOutputSetAcs.CASHREGISTERNO_TITLE];
            
			//---------------------------------------------------------------------------------
			// 詳細テーブルソート（データ入力システム, 伝票印刷種別, 伝票印刷設定用帳票ID昇順）
			//---------------------------------------------------------------------------------
			DataTable sortTable = new DataTable();
			sortTable = this._slipOutputSetAcs.DtDetailsTable.Clone();	// 詳細テーブルのカラムコピー
			
			// ビューデータ取得
			DataView dView = this._slipOutputSetAcs.DtDetailsTable.DefaultView;
			
			this._stringBuilder.Remove(0, this._stringBuilder.Length);
			//----- h.ueno add---------- start 2007.12.19
			this._stringBuilder.Append(SlipOutputSetAcs.DATAINPUTSYSTEM_TITLE);
			this._stringBuilder.Append(" ASC, ");
			//----- h.ueno add---------- end   2007.12.19
            // --- UPD m.suzuki 2010/10/12 ---------->>>>>
            //this._stringBuilder.Append(SlipOutputSetAcs.SLIPPRTKIND_TITLE);
            //this._stringBuilder.Append(" ASC, ");
            //this._stringBuilder.Append(SlipOutputSetAcs.SLIPPRTSETPAPERID_TITLE);
            //this._stringBuilder.Append(" ASC");
            this._stringBuilder.Append( SlipOutputSetAcs.SLIPPRTKIND_SORT_TITLE );
            this._stringBuilder.Append( " ASC, " );
            this._stringBuilder.Append( SlipOutputSetAcs.SLIPPRTSETPAPERID_DISP_TITLE );
            this._stringBuilder.Append( " ASC, " );
            this._stringBuilder.Append( SlipOutputSetAcs.SLIPCOMMENT_TITLE );
            this._stringBuilder.Append( " ASC" );
            // --- UPD m.suzuki 2010/10/12 ----------<<<<<
			
			dView.Sort = this._stringBuilder.ToString();
			
			// ソートしたレコードをワークテーブルに詰め替え
			foreach(DataRowView drv in dView)
			{
				sortTable.ImportRow(drv.Row);
			}
            
            // 第１グリッド抽出時に既に抽出済みのテーブルから表示
			foreach (DataRow dr in sortTable.Rows)
			{
				if (cashRegisterNo != (int)dr[SlipOutputSetAcs.CASHREGISTERNO_TITLE])
				{
                    // 端末番号が不一致のデータは除外
                    continue;
                }

				DataRow check = this._bindDataSet.Tables[DETAILS_TABLE].Rows.Find(new object[] {	//dr[SlipOutputSetAcs.SECTIONCODE_TITLE],       // DEL 2008/06/20
				                                                                                    dr[SlipOutputSetAcs.CASHREGISTERNO_TITLE],
                                                                                                    //--- ADD 2008/06/20 ---------->>>>>
                                                                                                    dr[SlipOutputSetAcs.WAREHOUSECODE_TITLE],
                                                                                                    //--- ADD 2008/06/20 ----------<<<<<
																									//----- h.ueno add---------- start 2007.12.19
																									dr[SlipOutputSetAcs.DATAINPUTSYSTEM_TITLE],
																									//----- h.ueno add---------- end   2007.12.19
				                                                                                    dr[SlipOutputSetAcs.SLIPPRTKIND_TITLE],
				                                                                                    dr[SlipOutputSetAcs.SLIPPRTSETPAPERID_TITLE] });
				if (check != null)
				{
					// 登録済みなので次へ
					continue;
				}

                // 伝票印刷テーブルへの登録
                DataRow drDetails = this._bindDataSet.Tables[DETAILS_TABLE].NewRow();
				
                // 拠点コード
                //drDetails[SlipOutputSetAcs.SECTIONCODE_TITLE] = dr[SlipOutputSetAcs.SECTIONCODE_TITLE];   // DEL 2008/06/20
				// 端末番号
				drDetails[SlipOutputSetAcs.CASHREGISTERNO_TITLE] = dr[SlipOutputSetAcs.CASHREGISTERNO_TITLE];
				
				//----- h.ueno add---------- start 2007.12.19
				// データ入力システム
				drDetails[SlipOutputSetAcs.DATAINPUTSYSTEM_TITLE] = dr[SlipOutputSetAcs.DATAINPUTSYSTEM_TITLE];
				// データ入力システム名称（グリッド表示用）
				drDetails[SlipOutputSetAcs.DATAINPUTSYSTEMNM_TITLE] = dr[SlipOutputSetAcs.DATAINPUTSYSTEMNM_TITLE];
				//----- h.ueno add---------- end   2007.12.19

                //--- ADD 2008/06/19 ---------->>>>>
                // 倉庫コード
                drDetails[SlipOutputSetAcs.WAREHOUSECODE_TITLE] = dr[SlipOutputSetAcs.WAREHOUSECODE_TITLE];
                // 倉庫名称
                drDetails[SlipOutputSetAcs.WAREHOUSENAME_TITLE] = GetWarehouseName(dr[SlipOutputSetAcs.WAREHOUSECODE_TITLE].ToString());
                //--- ADD 2008/06/19 ----------<<<<<

				// 伝票印刷種別
				drDetails[SlipOutputSetAcs.SLIPPRTKIND_TITLE] = dr[SlipOutputSetAcs.SLIPPRTKIND_TITLE];
				// 伝票印刷種別名称（グリッド表示用）
				drDetails[SlipOutputSetAcs.SLIPPRTKINDNM_TITLE] = dr[SlipOutputSetAcs.SLIPPRTKINDNM_TITLE];
				// 伝票印刷設定用帳票ID
				drDetails[SlipOutputSetAcs.SLIPPRTSETPAPERID_TITLE] = dr[SlipOutputSetAcs.SLIPPRTSETPAPERID_TITLE];
                // --- ADD m.suzuki 2010/09/27 ---------->>>>>
                // 伝票印刷設定用帳票ID（表示用）
                drDetails[SlipOutputSetAcs.SLIPPRTSETPAPERID_DISP_TITLE] = dr[SlipOutputSetAcs.SLIPPRTSETPAPERID_DISP_TITLE];
                // --- ADD m.suzuki 2010/09/27 ----------<<<<<
				// プリンタ管理No
				drDetails[SlipOutputSetAcs.PRINTERMNGNO_TITLE] = dr[SlipOutputSetAcs.PRINTERMNGNO_TITLE];

				// 伝票コメント（伝票印刷設定用帳票名称）
				drDetails[SlipOutputSetAcs.SLIPCOMMENT_TITLE] = dr[SlipOutputSetAcs.SLIPCOMMENT_TITLE];
				// プリンタ名
				drDetails[SlipOutputSetAcs.PRINTERNAME_TITLE] = dr[SlipOutputSetAcs.PRINTERNAME_TITLE];
				// プリンタポート（パス）
				drDetails[SlipOutputSetAcs.PRINTERPORT_TITLE] = dr[SlipOutputSetAcs.PRINTERPORT_TITLE];
				
				// 削除日
                drDetails[SlipOutputSetAcs.DELETE_DATE_TITLE] = dr[SlipOutputSetAcs.DELETE_DATE_TITLE];

				this._bindDataSet.Tables[DETAILS_TABLE].Rows.Add(drDetails);
            }

            totalCount = this._bindDataSet.Tables[DETAILS_TABLE].Rows.Count;
            status = ( int ) ConstantManagement.DB_Status.ctDB_NORMAL;

            // メインテーブルの削除日を設定
            SetMainTableDeleteDate();   // ADD 2008/03/24 不具合対応[12692]：「削除済データの表示」は最上位項目で制御

            return status;
        }

		/// <summary>
		/// ネクストデータ検索処理
		/// </summary>
		/// <param name="readCount">抽出対象件数</param>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note		: ArrayTypeでは未実装</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.12.10</br>
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
        /// <br>Programmer : 30167 上野　弘貴</br>
        /// <br>Date       : 2007.12.10</br>
        /// </remarks>
        public int Delete()
        {
            int status = 0;

            switch ( this._targetTableName )
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
        /// <br>Programmer : 30167 上野　弘貴</br>
        /// <br>Date       : 2007.12.10</br>
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
        /// <br>Programmer : 30167 上野　弘貴</br>
        /// <br>Date       : 2007.12.10</br>
        /// </remarks>
        public void GetAppearanceTable(out Hashtable[] _hashtable)
        {
            // メイン
            Hashtable main = new Hashtable();

            // ADD 2008/03/24 不具合対応[12692]↓：「削除済データの表示」は最上位項目で制御
            main.Add(SlipOutputSetAcs.DELETE_DATE_TITLE, new GridColAppearance(MGridColDispType.DeletionDataListOnly, ContentAlignment.MiddleLeft, "", Color.Red));

            //--- DEL 2008/06/20 ---------->>>>>
            //main.Add(SlipOutputSetAcs.SECTIONCODE_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
            //main.Add(SlipOutputSetAcs.SECTIONNAME_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
            //--- DEL 2008/06/20 ----------<<<<<
            main.Add(SlipOutputSetAcs.CASHREGISTERNO_TITLE, new GridColAppearance(MGridColDispType.ListOnly, ContentAlignment.MiddleRight, "", Color.Black));
			
			// 詳細
			Hashtable details = new Hashtable();

			details.Add(SlipOutputSetAcs.DELETE_DATE_TITLE, new GridColAppearance(MGridColDispType.DeletionDataListOnly, ContentAlignment.MiddleLeft, "", Color.Red));
			details.Add(SlipOutputSetAcs.CREATEDATETIME, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
			details.Add(SlipOutputSetAcs.UPDATEDATETIME, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
			details.Add(SlipOutputSetAcs.UPDASSEMBLYID1, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
			details.Add(SlipOutputSetAcs.UPDASSEMBLYID2, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
			details.Add(SlipOutputSetAcs.ENTERPRISECODE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
			details.Add(SlipOutputSetAcs.UPDEMPLOYEECODE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
			details.Add(SlipOutputSetAcs.FILEHEADERGUID, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
			details.Add(SlipOutputSetAcs.LOGICALDELETECODE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));

            //details.Add(SlipOutputSetAcs.SECTIONCODE_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));      // DEL 2008/06/20
			details.Add(SlipOutputSetAcs.CASHREGISTERNO_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));

            //--- ADD 2008/06/19 ---------->>>>>
            details.Add(SlipOutputSetAcs.WAREHOUSECODE_TITLE, new GridColAppearance(MGridColDispType.ListOnly, ContentAlignment.MiddleLeft, "", Color.Black));
            details.Add(SlipOutputSetAcs.WAREHOUSENAME_TITLE, new GridColAppearance(MGridColDispType.ListOnly, ContentAlignment.MiddleLeft, "", Color.Black));
            //--- ADD 2008/06/19 ----------<<<<<

			//----- h.ueno add---------- start 2007.12.19
			details.Add(SlipOutputSetAcs.DATAINPUTSYSTEM_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));

			//----- h.ueno upd ---------- start 2008.03.17 非表示にする
			details.Add(SlipOutputSetAcs.DATAINPUTSYSTEMNM_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
			//----- h.ueno upd ---------- end 2008.03.17

			//----- h.ueno add---------- end   2007.12.19
			details.Add(SlipOutputSetAcs.SLIPPRTKIND_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
			details.Add(SlipOutputSetAcs.SLIPPRTKINDNM_TITLE, new GridColAppearance(MGridColDispType.ListOnly, ContentAlignment.MiddleLeft, "", Color.Black));
			// --- UPD m.suzuki 2010/09/27 ---------->>>>> // 非表示にする
            //details.Add(SlipOutputSetAcs.SLIPPRTSETPAPERID_TITLE, new GridColAppearance(MGridColDispType.ListOnly, ContentAlignment.MiddleLeft, "", Color.Black));
            details.Add( SlipOutputSetAcs.SLIPPRTSETPAPERID_TITLE, new GridColAppearance( MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black ) );
            // --- UPD m.suzuki 2010/09/27 ----------<<<<<
            // --- ADD m.suzuki 2010/09/27 ---------->>>>>
            details.Add(SlipOutputSetAcs.SLIPPRTSETPAPERID_DISP_TITLE, new GridColAppearance(MGridColDispType.ListOnly, ContentAlignment.MiddleLeft, "", Color.Black));
            // --- ADD m.suzuki 2010/09/27 ----------<<<<<
            details.Add(SlipOutputSetAcs.PRINTERMNGNO_TITLE, new GridColAppearance(MGridColDispType.ListOnly, ContentAlignment.MiddleRight, "", Color.Black));

			details.Add(SlipOutputSetAcs.SLIPCOMMENT_TITLE, new GridColAppearance(MGridColDispType.ListOnly, ContentAlignment.MiddleLeft, "", Color.Black));
			details.Add(SlipOutputSetAcs.PRINTERNAME_TITLE, new GridColAppearance(MGridColDispType.ListOnly, ContentAlignment.MiddleLeft, "", Color.Black));
			details.Add(SlipOutputSetAcs.PRINTERPORT_TITLE, new GridColAppearance(MGridColDispType.ListOnly, ContentAlignment.MiddleLeft, "", Color.Black));

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
        /// <br>Programmer : 30167 上野　弘貴</br>
        /// <br>Date       : 2007.12.10</br>
        /// </remarks>
        private void DataSetColumnConstruction(ref DataSet ds)
        {
            //===============================
            // メインテーブル定義（端末番号）
            //===============================
            DataTable mainTable = new DataTable(MAIN_TABLE);

            // 削除日
            mainTable.Columns.Add(SlipOutputSetAcs.DELETE_DATE_TITLE, typeof(string));   // ADD 2008/03/24 不具合対応[12692]：「削除済データの表示」は最上位項目で制御

            // 拠点コード
            //mainTable.Columns.Add(SlipOutputSetAcs.SECTIONCODE_TITLE, typeof(string));                // DEL 2008/06/20

			// 拠点名称（内部保持用）
            //mainTable.Columns.Add(SlipOutputSetAcs.SECTIONNAME_TITLE, typeof(string));                // DEL 2008/06/20

			// 端末番号
			mainTable.Columns.Add(SlipOutputSetAcs.CASHREGISTERNO_TITLE, typeof(Int32));

			DataColumn[] primaryKey1 = { //mainTable.Columns[SlipOutputSetAcs.SECTIONCODE_TITLE],       // DEL 2008/06/20
										 mainTable.Columns[SlipOutputSetAcs.CASHREGISTERNO_TITLE] };
            mainTable.PrimaryKey = primaryKey1;

            this._bindDataSet.Tables.Add(mainTable);

            //============================
            // 詳細テーブル定義（伝票印刷）
            //============================
            DataTable detailsTable = new DataTable(DETAILS_TABLE);

            // 削除日
            detailsTable.Columns.Add(SlipOutputSetAcs.DELETE_DATE_TITLE, typeof(string));

            // 拠点コード
            //detailsTable.Columns.Add(SlipOutputSetAcs.SECTIONCODE_TITLE, typeof(string));             // DEL 2008/06/20
			// 端末番号
			detailsTable.Columns.Add(SlipOutputSetAcs.CASHREGISTERNO_TITLE, typeof(Int32));

            //--- ADD 2008/06/19 --------->>>>>
            // 倉庫コード
            detailsTable.Columns.Add(SlipOutputSetAcs.WAREHOUSECODE_TITLE, typeof(string));
            // 倉庫名称
            detailsTable.Columns.Add(SlipOutputSetAcs.WAREHOUSENAME_TITLE, typeof(string));
            //--- ADD 2008/06/19 ---------<<<<<

			//----- h.ueno add---------- start 2007.12.19
			// データ入力システム
			detailsTable.Columns.Add(SlipOutputSetAcs.DATAINPUTSYSTEM_TITLE, typeof(Int32));
			// データ入力システム名称（グリッド表示用）
			detailsTable.Columns.Add(SlipOutputSetAcs.DATAINPUTSYSTEMNM_TITLE, typeof(string));
			//----- h.ueno add---------- end   2007.12.19

			// 伝票印刷種別
			detailsTable.Columns.Add(SlipOutputSetAcs.SLIPPRTKIND_TITLE, typeof(Int32));
			// 伝票印刷種別名称（グリッド表示用）
			detailsTable.Columns.Add(SlipOutputSetAcs.SLIPPRTKINDNM_TITLE, typeof(string));
			// 伝票印刷設定用帳票ID
			detailsTable.Columns.Add(SlipOutputSetAcs.SLIPPRTSETPAPERID_TITLE, typeof(string));
            // --- ADD m.suzuki 2010/09/27 ---------->>>>>
            // 伝票印刷設定用帳票ID（表示用）
            detailsTable.Columns.Add( SlipOutputSetAcs.SLIPPRTSETPAPERID_DISP_TITLE, typeof( string ) );
            // --- ADD m.suzuki 2010/09/27 ----------<<<<<
			// 伝票コメント（伝票印刷設定用帳票名称）
			detailsTable.Columns.Add(SlipOutputSetAcs.SLIPCOMMENT_TITLE, typeof(string));
			// プリンタ管理No
			detailsTable.Columns.Add(SlipOutputSetAcs.PRINTERMNGNO_TITLE, typeof(Int32));
			// プリンタ名
			detailsTable.Columns.Add(SlipOutputSetAcs.PRINTERNAME_TITLE, typeof(string));
			// プリンタポート（パス）
			detailsTable.Columns.Add(SlipOutputSetAcs.PRINTERPORT_TITLE, typeof(string));

            DataColumn[] primaryKey2 = { //detailsTable.Columns[SlipOutputSetAcs.SECTIONCODE_TITLE],    // DEL 2008/06/20
										 detailsTable.Columns[SlipOutputSetAcs.CASHREGISTERNO_TITLE],
                                         //--- ADD 2008/06/20 ---------->>>>>
										 detailsTable.Columns[SlipOutputSetAcs.WAREHOUSECODE_TITLE],
                                         //--- ADD 2008/06/20 ----------<<<<<
										 //----- h.ueno add---------- start 2007.12.19
										 detailsTable.Columns[SlipOutputSetAcs.DATAINPUTSYSTEM_TITLE],
										 //----- h.ueno add---------- end   2007.12.19
										 detailsTable.Columns[SlipOutputSetAcs.SLIPPRTKIND_TITLE],
										 detailsTable.Columns[SlipOutputSetAcs.SLIPPRTSETPAPERID_TITLE] };
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
        /// <br>Programmer : 30167 上野　弘貴</br>
        /// <br>Date       : 2007.12.10</br>
        /// </remarks>
        private void ScreenInitialSetting()
        {
            // UI画面表示時のチラつきを抑える為に、ここでサイズ等変更
            switch ( this._targetTableName )
            {
                // 端末番号テーブルの場合
                case MAIN_TABLE:
					{
                        break;
                    }
                // 伝票印刷テーブルの場合
                case DETAILS_TABLE:
					{
						//--------------------
						// コンボボックス設定
						//--------------------
						// コンボボックス初期化
						//----- h.ueno add---------- start 2007.12.19
						this.DataInputSystem_tComboEditor.Items.Clear();
						//----- h.ueno add---------- end   2007.12.19
						this.SlipPrtKind_tComboEditor.Items.Clear();
						this.SlipPrtSetPaperId_tComboEditor.Items.Clear();
						this.PrinterMngNo_tComboEditor.Items.Clear();
						
						// コンボボックスデータテーブル初期化（再バインドで必要）
						//----- h.ueno add---------- start 2007.12.19
						this._dataTableDataInputSystem.Rows.Clear();
						//----- h.ueno add---------- end   2007.12.19
						this._dataTableSlipPrtKind.Rows.Clear();
						this._dataTableSlipPrtSetPaperId.Rows.Clear();
						this._dataTablePrinterMngNo.Rows.Clear();
						
						// 伝票印刷種別コンボボックスワーク初期設定
						this._slipPrtKind_tComboEditorValue = -1;
						// プリンタ管理Noコンボボックスワーク初期設定
						_printerMngNo_tComboEditorValue = -1;
						
						//----------------------------
						// コンボボックス用データ設定
						//----------------------------
						//----- h.ueno add---------- start 2007.12.19
						// データ入力システム
						SetComboDataInt(ref SlipOutputSet._dataInputSystemComboList, ref this._dataTableDataInputSystem);
						//----- h.ueno add---------- end   2007.12.19

						// 伝票印刷種別
						SetComboDataInt(ref SlipOutputSet._slipPrtKindList, ref this._dataTableSlipPrtKind);
						
						// 伝票印刷設定用帳票ID
						SetComboDataSlipPrtSet(ref SlipOutputSet._slipPrtSetPaperIdList, ref this._dataTableSlipPrtSetPaperId);
						
						// プリンタ管理No
						SetComboDataPrtManage(ref SlipOutputSet._printerMngNoList, ref this._dataTablePrinterMngNo);

						//--------------------
						// コンボボックス設定
						//--------------------
						//----- h.ueno add---------- start 2007.12.19
						BindCombo(ref this.DataInputSystem_tComboEditor, ref this._dataTableDataInputSystem);
						//----- h.ueno add---------- end   2007.12.19
						BindCombo(ref this.SlipPrtKind_tComboEditor, ref this._dataTableSlipPrtKind);
						BindCombo(ref this.SlipPrtSetPaperId_tComboEditor, ref this._dataTableSlipPrtSetPaperId);
						BindCombo(ref this.PrinterMngNo_tComboEditor, ref this._dataTablePrinterMngNo);

                        //--- ADD 2008/06/20 ---------->>>>>
                        this.tEdit_WarehouseCodeAllowZero.Text = "";
                        this.WarehouseName_tNedit.Text = "";
                        //--- ADD 2008/06/20 ----------<<<<<

                        // 新規の場合
                        if (this._detailsDataIndex < 0)
                        {
							// コンボボックスフィルター設定

                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008/12/08 G.Miyatsu DEL
                            //SlipPrtKindVisibleChange((int)SlipOutputSet._slipPrtKindList.GetKey(0));

                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008/12/08 G.Miyatsu ADD
                            int[] arry = new int[512];  //TODO:定数使用
                            SlipOutputSet._slipPrtKindList.Keys.CopyTo(arry, 0);
							SlipPrtKindVisibleChange(arry[0]);
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008/12/08 G.Miyatsu ADD

                            ScreenInputPermissionControl(3);                        // 画面入力許可制御
                            break;
                        }
                        // 削除の場合
						if ((string)this._bindDataSet.Tables[DETAILS_TABLE].Rows[this._detailsDataIndex][SlipOutputSetAcs.DELETE_DATE_TITLE] != "")
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
        /// <br>Programmer : 30167 上野　弘貴</br>
        /// <br>Date       : 2007.12.10</br>
        /// </remarks>
        private void ScreenInputPermissionControl ( int setType )
        {
            switch ( setType ) {
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
						//----- h.ueno add---------- start 2007.12.19
						this.DataInputSystem_tComboEditor.Enabled	= true;
						//----- h.ueno add---------- end   2007.12.19
						this.SlipPrtKind_tComboEditor.Enabled		= true;
						this.SlipPrtSetPaperId_tComboEditor.Enabled = true;
						this.PrinterMngNo_tComboEditor.Enabled		= true;

                        //--- ADD 2008/06/19 ---------->>>>>
                        this.tEdit_WarehouseCodeAllowZero.Enabled = true;

                        this.WarehouseCodeMsg_Label.Visible = true;
                        //--- ADD 2008/06/19 ----------<<<<<
                        this.ub_WarehouseGuide.Enabled = true;          //ADD 2008/10/03

                        // ボタン
						this.Ok_Button.Visible		= true;
						this.Cancel_Button.Visible	= true;
						this.Delete_Button.Visible	= false;
						this.Revive_Button.Visible	= false;
                        // --- ADD 2009/03/30 残案件No.14対応------------------------------------------------------>>>>>
                        this.Renewal_Button.Visible = true;
                        // --- ADD 2009/03/30 残案件No.14対応------------------------------------------------------<<<<<

                        break;
                    }
				// 4:伝票-更新
                case 4:
					{
                        // 項目
						//----- h.ueno add---------- start 2007.12.19
						this.DataInputSystem_tComboEditor.Enabled	= false;
						//----- h.ueno add---------- end   2007.12.19
						this.SlipPrtKind_tComboEditor.Enabled		= false;
						this.SlipPrtSetPaperId_tComboEditor.Enabled = false;
						this.PrinterMngNo_tComboEditor.Enabled		= true;

                        //--- ADD 2008/06/19 ---------->>>>>
                        this.tEdit_WarehouseCodeAllowZero.Enabled = false;

                        this.WarehouseCodeMsg_Label.Visible = false;
                        //--- ADD 2008/06/19 ----------<<<<<
                        this.ub_WarehouseGuide.Enabled = false;         //ADD 2008/10/03

                        // ボタン
                        this.Ok_Button.Visible		= true;
                        this.Cancel_Button.Visible	= true;
                        this.Revive_Button.Visible	= false;
                        this.Delete_Button.Visible	= false;
                        // --- ADD 2009/03/30 残案件No.14対応------------------------------------------------------>>>>>
                        this.Renewal_Button.Visible = true;
                        // --- ADD 2009/03/30 残案件No.14対応------------------------------------------------------<<<<<

                        break;
                    }
				// 5:伝票-削除
                case 5:
					{
                        // 項目
						//----- h.ueno add---------- start 2007.12.19
						this.DataInputSystem_tComboEditor.Enabled	= false;
						//----- h.ueno add---------- end   2007.12.19
						this.SlipPrtKind_tComboEditor.Enabled		= false;
						this.SlipPrtSetPaperId_tComboEditor.Enabled = false;
						this.PrinterMngNo_tComboEditor.Enabled		= false;

                        //--- ADD 2008/06/19 ---------->>>>>
                        this.tEdit_WarehouseCodeAllowZero.Enabled = false;

                        this.WarehouseCodeMsg_Label.Visible = false;
                        //--- ADD 2008/06/19 ----------<<<<<
                        this.ub_WarehouseGuide.Enabled = false;         //ADD 2008/10/03

                        // ボタン
						this.Ok_Button.Visible		= false;
						this.Cancel_Button.Visible	= true;
						this.Delete_Button.Visible	= true;
						this.Revive_Button.Visible	= true;
                        // --- ADD 2009/03/30 残案件No.14対応------------------------------------------------------>>>>>
                        this.Renewal_Button.Visible = false;
                        // --- ADD 2009/03/30 残案件No.14対応------------------------------------------------------<<<<<
						
						this.Delete_Button.Location = new Point(BUTTON_LOCATION1_X, BUTTON_LOCATION_Y); // 完全削除ボタン位置
						this.Revive_Button.Location = new Point(BUTTON_LOCATION2_X, BUTTON_LOCATION_Y); // 復活ボタン位置
						this.Cancel_Button.Location = new Point(BUTTON_LOCATION3_X, BUTTON_LOCATION_Y); // 閉じるボタン位置
						
                        break;
                    }
            }
        }
        /// <summary>
        /// 画面クリア処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面をクリアします。</br>
        /// <br>Programmer : 30167 上野　弘貴</br>
        /// <br>Date       : 2007.12.10</br>
        /// </remarks>
        private void ScreenClear()
        {
            // モードラベル
            this.Mode_Label.Text = INSERT_MODE;

            // ボタン
			this.Ok_Button.Visible		= true;  // 保存ボタン
			this.Cancel_Button.Visible	= true;  // 閉じるボタン
			this.Delete_Button.Visible	= true;  // 完全削除ボタン
			this.Revive_Button.Visible	= true;  // 復活ボタン
			this.Delete_Button.Location = new Point(BUTTON_LOCATION1_X, BUTTON_LOCATION_Y); // 完全削除ボタン位置
			this.Revive_Button.Location = new Point(BUTTON_LOCATION2_X, BUTTON_LOCATION_Y); // 復活ボタン位置
			this.Ok_Button.Location		= new Point(BUTTON_LOCATION2_X, BUTTON_LOCATION_Y); // 保存ボタン位置
			this.Cancel_Button.Location = new Point(BUTTON_LOCATION3_X, BUTTON_LOCATION_Y); // 閉じるボタン位置
            // --- ADD 2009/03/30 残案件No.14対応------------------------------------------------------>>>>>
            this.Renewal_Button.Visible = true;
            // --- ADD 2009/03/30 残案件No.14対応------------------------------------------------------<<<<<
            // --- ADD m.suzuki 2010/09/27 ---------->>>>>
            this.Renewal_Button.Location = new Point( BUTTON_LOCATION1_X, BUTTON_LOCATION_Y ); // 最新情報ボタン位置
            // --- ADD m.suzuki 2010/09/27 ----------<<<<<

			// 入力制御
			//----- h.ueno add---------- start 2007.12.19
			this.DataInputSystem_tComboEditor.Enabled	= true;	// データ入力システム
			//----- h.ueno add---------- end   2007.12.19
			this.SlipPrtKind_tComboEditor.Enabled		= true;	// 伝票印刷種別
			this.SlipPrtSetPaperId_tComboEditor.Enabled = true;	// 伝票印刷設定用帳票ID
			this.PrinterMngNo_tComboEditor.Enabled		= true;	// プリンタ管理No
			
			// 項目
            //this.SectionCode_tEdit.Clear();		    // 拠点コード       // DEL 2008/06/20
            //this.SectionName_tEdit.Clear();		    // 拠点名称         // DEL 2008/06/20
			this.CashRegisterNo_tNedit.Clear();	        // 端末番号
			this.PrinterPort_tEdit.Clear();		        // プリンタポート名称
            //--- ADD 2008/06/20 ---------->>>>>
            this.tEdit_WarehouseCodeAllowZero.Clear();  // 倉庫コード
            this.WarehouseName_tNedit.Clear();          // 倉庫名称
            //--- ADD 2008/06/20 ----------<<<<<
        }
        #endregion

        #region 画面再構築処理
        /// <summary>
        /// 画面再構築処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : モードに基づいて画面を再構築します。</br>
        /// <br>Programmer : 30167 上野　弘貴</br>
        /// <br>Date       : 2007.12.10</br>
        /// </remarks>
        private void ScreenReconstruction()
        {
            switch ( this._targetTableName )
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
							//--------------------------------
							// コンボボックスデフォルト値設定
							//--------------------------------
							//----- h.ueno add---------- start 2007.12.19
							// データ入力システム

                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008/12/08 G.Miyatsu DEL
                            //this.DataInputSystem_tComboEditor.Value
                            //    = (SlipOutputSet._dataInputSystemComboList.Count > 0) ? SlipOutputSet._dataInputSystemComboList.GetKey(0) : 0;

                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008/12/08 G.Miyatsu ADD
                            int[] arry = new int[512];   //定数だが伝票印刷種別は512個も無いからオバフロはしない。
                            SlipOutputSet._dataInputSystemComboList.Keys.CopyTo(arry,0);
                            this.DataInputSystem_tComboEditor.Value
                                = (SlipOutputSet._dataInputSystemComboList.Count > 0) ? arry[0] : 0;
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008/12/08 G.Miyatsu ADD

							//----- h.ueno add---------- end   2007.12.19

                            // 伝票印刷種別

                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008/12/08 G.Miyatsu DEL
                            //this.SlipPrtKind_tComboEditor.Value
                            //    = (SlipOutputSet._slipPrtKindList.Count > 0) ? SlipOutputSet._slipPrtKindList.GetKey(0) : 0;

                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008/12/08 G.Miyatsu ADD
                            SlipOutputSet._slipPrtKindList.Keys.CopyTo(arry,0);
							this.SlipPrtKind_tComboEditor.Value
								= (SlipOutputSet._slipPrtKindList.Count > 0) ? arry[0] : 0;
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008/12/08 G.Miyatsu ADD

							// プリンタ管理No
							this.PrinterMngNo_tComboEditor.Value
								= (SlipOutputSet._printerMngNoList.Count > 0) ? SlipOutputSet._printerMngNoList.GetKey(0) : 0;

							// コンボボックスフィルター設定（伝票印刷設定用帳票ID設定）
							SlipPrtKindVisibleChange(SlipOutputSetAcs.NullChgInt(this.SlipPrtKind_tComboEditor.Value));
							
							//---------------------------------------------------
							// キー項目設定（以下は全てキーなので必ず設定が必要）
							//---------------------------------------------------
							dr = this._bindDataSet.Tables[DETAILS_TABLE].NewRow();

							// 拠点コード（表示項目）
                            //dr[SlipOutputSetAcs.SECTIONCODE_TITLE] = this._bindDataSet.Tables[MAIN_TABLE].Rows[this._mainDataIndex][SlipOutputSetAcs.SECTIONCODE_TITLE];      // DEL 2008/06/20
							
							// 端末番号（表示項目）
                            dr[SlipOutputSetAcs.CASHREGISTERNO_TITLE] = this._bindDataSet.Tables[MAIN_TABLE].Rows[this._mainDataIndex][SlipOutputSetAcs.CASHREGISTERNO_TITLE];

                            //--- ADD 2008/06/20 ---------->>>>>
                            // 倉庫コード
                            dr[SlipOutputSetAcs.WAREHOUSECODE_TITLE] = SlipOutputSetAcs.NullChgStr(this.tEdit_WarehouseCodeAllowZero.Value);
                            //--- ADD 2008/06/20 ----------<<<<<

							//----- h.ueno add---------- start 2007.12.19
							// データ入力システム（コンボボックス初期値）
							dr[SlipOutputSetAcs.DATAINPUTSYSTEM_TITLE] = SlipOutputSetAcs.NullChgInt(this.DataInputSystem_tComboEditor.Value);
							//----- h.ueno add---------- end   2007.12.19
							
							// 伝票印刷種別（コンボボックス初期値）
							dr[SlipOutputSetAcs.SLIPPRTKIND_TITLE] = SlipOutputSetAcs.NullChgInt(this.SlipPrtKind_tComboEditor.Value);
							
							// プリンタ管理No（コンボボックス初期値）
							dr[SlipOutputSetAcs.PRINTERMNGNO_TITLE] = SlipOutputSetAcs.NullChgInt(this.PrinterMngNo_tComboEditor.Value);

							// 伝票印刷設定用帳票ID（コンボボックス初期値）
							if (this.SlipPrtSetPaperId_tComboEditor.Items.Count > 0)
							{
								// コンボボックス先頭の値を設定
								dr[SlipOutputSetAcs.SLIPPRTSETPAPERID_TITLE] = this.SlipPrtSetPaperId_tComboEditor.Items[0].DataValue;
                                // --- ADD m.suzuki 2010/09/27 ---------->>>>>
                                if ( SlipOutputSetAcs.NullChgInt( this.SlipPrtKind_tComboEditor.Value ) == 99 )
                                {
                                    dr[SlipOutputSetAcs.SLIPPRTSETPAPERID_DISP_TITLE] = string.Empty;
                                }
                                else
                                {
                                    dr[SlipOutputSetAcs.SLIPPRTSETPAPERID_DISP_TITLE] = this.SlipPrtSetPaperId_tComboEditor.Items[0].DataValue;
                                }
                                // --- ADD m.suzuki 2010/09/27 ----------<<<<<
							}
							else
							{
								dr[SlipOutputSetAcs.SLIPPRTSETPAPERID_TITLE] = "";
                                // --- ADD m.suzuki 2010/09/27 ---------->>>>>
                                dr[SlipOutputSetAcs.SLIPPRTSETPAPERID_DISP_TITLE] = "";
                                // --- ADD m.suzuki 2010/09/27 ----------<<<<<
							}

                            // 倉庫名称
                            dr[SlipOutputSetAcs.WAREHOUSENAME_TITLE] = SlipOutputSetAcs.NullChgStr(this.WarehouseName_tNedit.Value);        //ADD 2009/02/25 不具合対応[11798]
							
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

							//----- h.ueno upd---------- start 2007.12.19
							// フォーカス設定
							this.DataInputSystem_tComboEditor.Focus();
							//----- h.ueno upd---------- end   2007.12.19

							break;
						}
						
						//----- 更新データ取得 -----
						dr = this._bindDataSet.Tables[DETAILS_TABLE].Rows[this._detailsDataIndex];
						
						// 削除の場合
						if ((string)dr[SlipOutputSetAcs.DELETE_DATE_TITLE] != "")
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
							this.SlipPrtKind_tComboEditor.Focus();
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
        /// <br>Note　　　 : 拠点・部門の保存処理を行います。</br>
        /// <br>Programmer : 30167 上野　弘貴</br>
        /// <br>Date       : 2007.12.10</br>
        /// </remarks>
        private bool SaveProc ( string saveTarget )
        {
            Control control = null;
            string message = null;

            // 不正データ入力チェック
            if ( !ScreenDataCheck(ref control, ref message) )
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

            switch ( saveTarget )
            {
                // 伝票印刷テーブルの場合
                case DETAILS_TABLE:
					{
                        // 更新
                        if (!SaveSlipOutputSet())
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
        /// <br>Note		: 画面入力情報の不正チェックを行います。</br>
        /// <br>Programmer : 30167 上野　弘貴</br>
        /// <br>Date       : 2007.12.10</br>
        /// </remarks>
        private bool ScreenDataCheck ( ref Control control, ref string message )
        {
			//----- h.ueno add---------- start 2007.12.19
			// データ入力システムは「0」もデータなので、未設定はあり得ない
			//----- h.ueno add---------- end   2007.12.19

			// 伝票印刷種別チェック
			if(SlipOutputSetAcs.NullChgInt(this.SlipPrtKind_tComboEditor.Value) == 0)
			{
				control = this.SlipPrtKind_tComboEditor;
				message = "伝票印刷種別が選択されていません";
				return false;
			}
			
			// 伝票印刷設定用帳票IDチェック
			if(SlipOutputSetAcs.NullChgStr(this.SlipPrtSetPaperId_tComboEditor.Value) == "")
			{
				control = this.SlipPrtSetPaperId_tComboEditor;
				message = "伝票印刷設定用帳票IDが選択されていません";
				return false;
			}
			
			// プリンタ管理Noチェック
			if(SlipOutputSetAcs.NullChgInt(this.PrinterMngNo_tComboEditor.Value) == 0)
			{
				control = this.PrinterMngNo_tComboEditor;
				message = "プリンタ管理Noが選択されていません";
				return false;
			}

            // --- ADD 2008/10/03 ------------------------------>>>>>
            // 倉庫存在チェック
            if (this.WarehouseIsExists(tEdit_WarehouseCodeAllowZero.Text) == false)
            {
                
                control = this.tEdit_WarehouseCodeAllowZero;
                // DEL 2008/10/09 不具合対応[6430] ↓
                //message = "指定された倉庫は存在しません";
                message = "マスタに登録されていません";     // ADD 2008/10/09 不具合対応[6430]
                this.tEdit_WarehouseCodeAllowZero.Clear();
                return false;

            }
            // --- ADD 2008/10/03 ------------------------------<<<<<

			return true;
        }

        /// <summary>
        /// 画面情報伝票出力先設定クラス格納処理
        /// </summary>
		/// <param name="slipOutputSet">伝票出力先設定オブジェクト</param>
        /// <remarks>
		/// <br>Note       : 画面情報から伝票出力先設定オブジェクトにデータを格納します。</br>
        /// <br>Programmer : 30167 上野　弘貴</br>
        /// <br>Date       : 2007.12.10</br>
        /// </remarks>
        private void DispToSlipOutputSet ( ref SlipOutputSet slipOutputSet )
        {
            // 拠点コード
            //slipOutputSet.SectionCode = (string)this._bindDataSet.Tables[MAIN_TABLE].Rows[this._mainDataIndex][SlipOutputSetAcs.SECTIONCODE_TITLE];   // DEL 2008/06/20
			 
            // 企業コード
            slipOutputSet.EnterpriseCode = this._enterpriseCode;

            switch ( this._targetTableName )
            {
				// レジテーブルの場合
				case MAIN_TABLE:
					{
						break;
					}
				// 伝票印刷テーブルの場合
				case DETAILS_TABLE :
					{
                        //slipOutputSet.SectionCode		= this.SectionCode_tEdit.Text;                  // DEL 2008/06/20
						slipOutputSet.CashRegisterNo	= this.CashRegisterNo_tNedit.GetInt();
						//----- h.ueno add---------- start 2007.12.19
						slipOutputSet.DataInputSystem	= SlipOutputSetAcs.NullChgInt(this.DataInputSystem_tComboEditor.Value);
						//----- h.ueno add---------- end   2007.12.19
						slipOutputSet.SlipPrtKind		= SlipOutputSetAcs.NullChgInt(this.SlipPrtKind_tComboEditor.Value);
						slipOutputSet.SlipPrtSetPaperId = SlipOutputSetAcs.NullChgStr(this.SlipPrtSetPaperId_tComboEditor.Value);
						slipOutputSet.PrinterMngNo		= SlipOutputSetAcs.NullChgInt(this.PrinterMngNo_tComboEditor.Value);
						
                        //--- ADD 2008/06/19 ---------->>>>>
                        slipOutputSet.WarehouseCode     = this.tEdit_WarehouseCodeAllowZero.Text;
                        //--- ADD 2008/06/19 ----------<<<<<
						break;
					}
            }
        }

        /// <summary>
        /// 新規登録時処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 新規登録時の処理を行います。</br>
        /// <br>Programmer : 30167 上野　弘貴</br>
        /// <br>Date       : 2007.12.10</br>
        /// </remarks>
        private void NewEntryTransaction ()
        {
            string warehouseCode = string.Empty;        //ADD 2009/02/25 不具合対応[11798]
            string warehouseName = string.Empty;        //ADD 2009/02/25 不具合対応[11798]

            if ( UnDisplaying != null )
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }
            // 新規モードの場合は画面を終了せずに連続入力を可能とする
            if ( this.Mode_Label.Text == INSERT_MODE )
            {
                if ( TargetTableName == MAIN_TABLE )
                {
                    // データインデックスを初期化する
                    this._mainDataIndex = -1;
                }

				// フレーム更新（読み込みせず、ソートのみ）
				int dataCnt = 0;
				DetailsDataSearch(ref dataCnt, 0);

                warehouseCode = this.tEdit_WarehouseCodeAllowZero.Text;     //ADD 2009/02/25 不具合対応[11798]
                warehouseName = this.WarehouseName_tNedit.Text;             //ADD 2009/02/25 不具合対応[11798]

				// 画面クリア処理
				ScreenClear();
				// 画面初期設定処理
				ScreenInitialSetting();

                this.tEdit_WarehouseCodeAllowZero.Text = warehouseCode;     //ADD 2009/02/25 不具合対応[11798]
                this.WarehouseName_tNedit.Text = warehouseName;             //ADD 2009/02/25 不具合対応[11798]

				// 画面再構築処理
				ScreenReconstruction();
            }
            else
            {
                this.DialogResult = DialogResult.OK;

                if ( CanClose == true )
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
        /// <br>Programmer : 30167 上野　弘貴</br>
        /// <br>Date       : 2007.12.10</br>
        /// </remarks>
        private void EnforcedEndTransaction ()
        {
            if ( UnDisplaying != null )
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }

            this.DialogResult = DialogResult.Cancel;
            this._mainDataIndex = -2;
            this._detailsDataIndex = -2;

            this._targetTableName = "";

            if ( CanClose == true )
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
        /// <br>Programmer : 30167 上野　弘貴</br>
        /// <br>Date       : 2007.12.10</br>
        /// </remarks>
        private void RepeatTransaction ( int status, ref Control control )
        {
            TMsgDisp.Show(
                this, 								// 親ウィンドウフォーム
                emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
                ASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
                ERR_DPR_MSG, 	                    // 表示するメッセージ
                0, 									// ステータス値
                MessageBoxButtons.OK);				// 表示するボタン

            switch ( TargetTableName )
            {
                // 端末番号テーブルの場合
                case MAIN_TABLE:
					{
                        break;
                    }
                // 伝票印刷テーブルの場合
                case DETAILS_TABLE:
					{
                        control = this.SlipPrtKind_tComboEditor;
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
        /// <br>Programmer : 30167 上野　弘貴</br>
        /// <br>Date       : 2007.12.10</br>
        /// </remarks>
        private void ExclusiveTransaction ( int status, string operation, object erObject )
        {
            switch ( status )
            {
                case ( int ) ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
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
                case ( int ) ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
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
        private bool SaveSlipOutputSet()
        {
            //==========================
            // 書き込み処理
            //==========================
            int status = ( int ) ConstantManagement.DB_Status.ctDB_NORMAL;
            SlipOutputSet slipOutputSet = new SlipOutputSet();
            Control control = null;

            // 明細項目
            DispToSlipOutputSet( ref slipOutputSet );
            
            // 書き込み
            string message;

			// 更新の場合作成日付設定
			if (this.Mode_Label.Text == UPDATE_MODE)
			{
				// 変更前更新データ取得
				DataRow dr = this._bindDataSet.Tables[DETAILS_TABLE].Rows[this._detailsDataIndex];
				SlipOutputSet slipOutputSetPre = null;
				
				status = this._slipOutputSetAcs.GetSlipOutputSet(//SlipOutputSetAcs.NullChgStr(dr[SlipOutputSetAcs.SECTIONCODE_TITLE]),     // DEL 2008/06/20
																SlipOutputSetAcs.NullChgInt(dr[SlipOutputSetAcs.CASHREGISTERNO_TITLE]),
                                                                //--- ADD 2008/06/20 ---------->>>>>
                                                                SlipOutputSetAcs.NullChgStr(dr[SlipOutputSetAcs.WAREHOUSECODE_TITLE]),
                                                                //--- ADD 2008/06/20 ---------->>>>>
                                                                //----- h.ueno add---------- start 2007.12.19
																SlipOutputSetAcs.NullChgInt(dr[SlipOutputSetAcs.DATAINPUTSYSTEM_TITLE]),
																//----- h.ueno add---------- end   2007.12.19
																SlipOutputSetAcs.NullChgInt(dr[SlipOutputSetAcs.SLIPPRTKIND_TITLE]),
																SlipOutputSetAcs.NullChgStr(dr[SlipOutputSetAcs.SLIPPRTSETPAPERID_TITLE]),
																out slipOutputSetPre,
																out message);
				
				// 更新に必要な情報をDataTableから再セット
				slipOutputSet.CreateDateTime = slipOutputSetPre.CreateDateTime;
				slipOutputSet.UpdateDateTime = slipOutputSetPre.UpdateDateTime;
				slipOutputSet.FileHeaderGuid = slipOutputSetPre.FileHeaderGuid;
            }
            
            status = this._slipOutputSetAcs.Write(ref slipOutputSet, out message);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // DataSet/Hash更新処理
                        DetailsToDataSet(slipOutputSet, this._detailsDataIndex);
                        
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
                        ExclusiveTransaction(status, TMsgDisp.OPE_UPDATE, this._slipOutputSetAcs);
                        // UI子画面強制終了処理
                        EnforcedEndTransaction();
                        return false;
                    }
                default:
                    {
                        emErrorLevel emErrLvl = emErrorLevel.ERR_LEVEL_INFO;
                        if ( status == ( int ) ConstantManagement.DB_Status.ctDB_ERROR )
                        {
                            emErrLvl = emErrorLevel.ERR_LEVEL_STOP;
                        }

                        TMsgDisp.Show(this,                                // 親ウィンドウフォーム
                                       emErrLvl,                            // エラーレベル
                                       ASSEMBLY_ID,                       // アセンブリＩＤまたはクラスＩＤ
                                       "端末別伝票出力先設定", 	            		    // プログラム名称
                                       "SaveDispData", 	                    // 処理名称
                                       TMsgDisp.OPE_UPDATE, 				// オペレーション
                                       message,                             // 表示するメッセージ
                                       status,  							// ステータス値
                                       this._slipOutputSetAcs,               // エラーが発生したオブジェクト
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
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2007.12.10</br>
		/// </remarks>
		private bool CompareData()
		{
			bool retBool = false;
			int chkCnt = 0;
			DataRow dr = this._dataTableClone.Rows[0];

//----- h.ueno add---------- start 2007.12.19
			chkCnt += SlipOutputSetAcs.NullChgInt(this.DataInputSystem_tComboEditor.Value)
						== SlipOutputSetAcs.NullChgInt(dr[SlipOutputSetAcs.DATAINPUTSYSTEM_TITLE]) ? 0 : 1;
//----- h.ueno add---------- end   2007.12.19

			chkCnt += SlipOutputSetAcs.NullChgInt(this.SlipPrtKind_tComboEditor.Value)
						== SlipOutputSetAcs.NullChgInt(dr[SlipOutputSetAcs.SLIPPRTKIND_TITLE]) ? 0 : 1;
			
			chkCnt += string.Equals(SlipOutputSetAcs.NullChgStr(this.SlipPrtSetPaperId_tComboEditor.Value).TrimEnd(),
									SlipOutputSetAcs.NullChgStr(dr[SlipOutputSetAcs.SLIPPRTSETPAPERID_TITLE]).TrimEnd()) ? 0 : 1;

			chkCnt += SlipOutputSetAcs.NullChgInt(this.PrinterMngNo_tComboEditor.Value)
						== SlipOutputSetAcs.NullChgInt(dr[SlipOutputSetAcs.PRINTERMNGNO_TITLE]) ? 0 : 1;
			
			// 変更有り
			if(chkCnt > 0)
			{
				retBool = true;
			}
			return retBool;
		}

//----- h.ueno add---------- start 2007.12.19

		/// <summary>
		/// データ入力システム表示変更
		/// </summary>
		/// <param name="dataInputSystem">データ入力システム</param>
		/// <remarks>
		/// <br>Note　     : データ入力システム選択を変更したときに発生します。</br>
		/// <br>			 データ入力システムの値によって伝票印刷種別コンボボックス表示を制御します。</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2007.12.19</br>
		/// </remarks>
		private void DataInputSystemVisibleChange(int dataInputSystem)
		{
			try
			{
				if (this._dataInputSystem_tComboEditorValue == dataInputSystem) return;
				
				//----------------------------------------------
				// データ入力システムに紐づく伝票印刷種別の設定
				//----------------------------------------------
				this.SlipPrtKind_tComboEditor.BeginUpdate();

				// コンボボックスアイテムクリア
				this.SlipPrtKind_tComboEditor.Items.Clear();	// 一度クリアする

				// コンボボックス伝票印刷種別クリア
				this._dataTableSlipPrtKind.Rows.Clear();
				
				// 伝票印刷種別コンボボックス再設定
				foreach (KeyValuePair<int,object> de in SlipOutputSet._slipPrtKindList)
				{
					if (SlipOutputSet.DataInputSystemSlipPrtKindCheck(dataInputSystem, (int)de.Key) == true)
					{
					    DataRow dr = this._dataTableSlipPrtKind.NewRow();
						dr[COMBO_CODE] = (int)de.Key;
					    dr[COMBO_NAME] = (string)de.Value;
						
					    this._dataTableSlipPrtKind.Rows.Add(dr);
					}
				}
				
				// 先頭データを表示する
				if (this.SlipPrtKind_tComboEditor.Items.Count > 0)
				{
					this.SlipPrtKind_tComboEditor.Value = this.SlipPrtKind_tComboEditor.Items[0].DataValue;
				}
				this.SlipPrtKind_tComboEditor.EndUpdate();
				
				// 選択した番号を保持
				this._dataInputSystem_tComboEditorValue = dataInputSystem;
				
				//------------------------------------------------
				// 伝票印刷種別に紐づく伝票印刷設定用帳票IDの設定
				//------------------------------------------------
				if (this.SlipPrtKind_tComboEditor.Value != null)
				{
					SlipPrtKindVisibleChange((Int32)this.SlipPrtKind_tComboEditor.Value);
				}
			}
			catch
			{
			}
		}

//----- h.ueno add---------- end   2007.12.19
		
		/// <summary>
		/// 伝票印刷種別表示変更
		/// </summary>
		/// <param name="slipPrtKind">伝票印刷種別</param>
		/// <remarks>
		/// <br>Note　     : 伝票印刷種別の選択を変更したときに発生します。</br>
		/// <br>			 伝票印刷種別の値によって伝票印刷設定用帳票IDコンボボックス表示を制御します。</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2007.12.10</br>
		/// </remarks>
		private void SlipPrtKindVisibleChange(int slipPrtKind)
		{
			try
			{
				if (this._slipPrtKind_tComboEditorValue == slipPrtKind) return;

				this.SlipPrtSetPaperId_tComboEditor.BeginUpdate();
				
				// コンボボックスアイテムクリア
				this.SlipPrtSetPaperId_tComboEditor.Items.Clear();	// 一度クリアする
				
				// コンボボックス伝票印刷設定用帳票IDクリア
				this._dataTableSlipPrtSetPaperId.Rows.Clear();
				
				// 伝票印刷設定用帳票ID再設定
				foreach (DictionaryEntry de in SlipOutputSet._slipPrtSetPaperIdList)
				{
					SlipPrtSet slipPrtSetWk = (SlipPrtSet)de.Value;

					if (slipPrtSetWk.SlipPrtKind == slipPrtKind)
					{
						DataRow dr = this._dataTableSlipPrtSetPaperId.NewRow();

						dr[COMBO_CODE] = slipPrtSetWk.SlipPrtSetPaperId;
						dr[COMBO_NAME] = slipPrtSetWk.SlipComment;

						this._dataTableSlipPrtSetPaperId.Rows.Add(dr);
					}
				}
				
				// 先頭データを表示する
				if (this.SlipPrtSetPaperId_tComboEditor.Items.Count > 0)
				{
					this.SlipPrtSetPaperId_tComboEditor.Value = this.SlipPrtSetPaperId_tComboEditor.Items[0].DataValue;
				}
				this.SlipPrtSetPaperId_tComboEditor.EndUpdate();
					
				// 選択した番号を保持
				this._slipPrtKind_tComboEditorValue = slipPrtKind;
			}
			catch
			{
			}
		}

		/// <summary>
		/// プリンタ管理No表示変更
		/// </summary>
		/// <param name="printerMngNo">プリンタ管理No</param>
		/// <remarks>
		/// <br>Note　     : プリンタ管理Noの選択を変更したときに発生します。</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2007.12.10</br>
		/// </remarks>
		private void PrinterMngNoVisibleChange(int printerMngNo)
		{
			try
			{
				if (this._printerMngNo_tComboEditorValue == printerMngNo) return;
				
				// プリンタポート（パス）
				this.PrinterPort_tEdit.Text = this._slipOutputSetAcs.GetPrinterPort(SlipOutputSetAcs.NullChgInt(this.PrinterMngNo_tComboEditor.Value));
				
				// 選択した番号を保持
				this._printerMngNo_tComboEditorValue = printerMngNo;
			}
			catch
			{
			}
		}

		/// <summary>
		/// コンボボックス用データセット列情報構築処理
		/// </summary>
		/// <remarks>
		/// <param name="wkTable">データテーブル</param>
		/// <br>Note       : コンボボックス用データセットの列情報を構築します。</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2007.12.10</br>
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
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2007.12.10</br>
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
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2007.12.10</br>
		/// </remarks>
        private void SetComboDataInt(ref SortedList sList, ref DataTable dataTable)
		{
			try
			{
				//foreach (KeyValuePair<int, object> de in sList)
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
        /// コンボボックスデータ設定(非ソート)
        /// </summary>
        /// <remarks>
        /// <param name="sList">ソートリスト</param>
        /// <param name="dataTable">データテーブル</param>
        /// <br>Note       : 非ソートのDictionaryでコンボボックスデータを設定します。</br>
        /// <br>Programmer : 30365 宮津　銀次郎</br>
        /// <br>Date       : 2008.12.08</br>
        /// </remarks>
        private void SetComboDataInt(ref DictionaryList sList, ref DataTable dataTable)
        {
            try
            {
                foreach (KeyValuePair<int, object> de in sList)
                
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
		/// コンボボックスデータ設定（伝票印刷設定用）
		/// </summary>
		/// <remarks>
		/// <param name="sList">ソートリスト</param>
		/// <param name="dataTable">データテーブル</param>
		/// <br>Note       : コンボボックスデータ（伝票印刷設定用）を設定します。</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2007.12.10</br>
		/// </remarks>
		private void SetComboDataSlipPrtSet(ref SortedList sList, ref DataTable dataTable)
		{
			try
			{
				foreach (DictionaryEntry de in sList)
				{
					SlipPrtSet slipPrtSet = (SlipPrtSet)de.Value;
					DataRow dr = dataTable.NewRow();
					
					dr[COMBO_CODE] = slipPrtSet.SlipPrtSetPaperId;
					dr[COMBO_NAME] = slipPrtSet.SlipComment;
					
					dataTable.Rows.Add(dr);
				}
			}
			catch
			{
			}
		}

		/// <summary>
		/// コンボボックスデータ設定（プリンタ管理No用）
		/// </summary>
		/// <remarks>
		/// <param name="sList">ソートリスト</param>
		/// <param name="dataTable">データテーブル</param>
		/// <br>Note       : コンボボックスデータ（プリンタ管理No用）を設定します。</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2007.12.10</br>
		/// </remarks>
		private void SetComboDataPrtManage(ref SortedList sList, ref DataTable dataTable)
		{
			try
			{
				foreach (DictionaryEntry de in sList)
				{
					PrtManage prtManage = (PrtManage)de.Value;
					DataRow dr = dataTable.NewRow();

					dr[COMBO_CODE] = prtManage.PrinterMngNo;
					dr[COMBO_NAME] = prtManage.PrinterName;

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
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2007.12.10</br>
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
        private void DCKHN09250UA_Load(object sender, EventArgs e)
        {
            // 画面スキンファイルの読込(デフォルトスキン指定)
            this._controlScreenSkin.LoadSkin();

            // 画面スキン変更
            this._controlScreenSkin.SettingScreenSkin(this);

            // アイコンリソース管理クラスを使用して、アイコンを表示する
            ImageList imageList25 = IconResourceManagement.ImageList24;
            ImageList imageList16 = IconResourceManagement.ImageList16;

            this.Delete_Button.ImageList = imageList25;
            this.Ok_Button.ImageList     = imageList25;
            this.Cancel_Button.ImageList = imageList25;

            this.Delete_Button.Appearance.Image = Size24_Index.DELETE;
            this.Ok_Button.Appearance.Image     = Size24_Index.SAVE;
            this.Cancel_Button.Appearance.Image = Size24_Index.CLOSE;

            this.ub_WarehouseGuide.Appearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];       // 倉庫ガイド

            // --- ADD 2009/03/30 残案件No.14対応------------------------------------------------------>>>>>
            this.Renewal_Button.ImageList = imageList16;
            this.Renewal_Button.Appearance.Image = Size16_Index.RENEWAL;
            // --- ADD 2009/03/30 残案件No.14対応------------------------------------------------------<<<<<

            // --- ADD m.suzuki 2010/09/27 ---------->>>>>
            this.Revive_Button.ImageList = imageList25;
            this.Revive_Button.Appearance.Image = Size24_Index.REVIVAL;
            // --- ADD m.suzuki 2010/09/27 ----------<<<<<
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
        /// <br>Programmer : 30167 上野　弘貴</br>
        /// <br>Date       : 2007.12.10</br>
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
        /// <br>Programmer : 30167 上野　弘貴</br>
        /// <br>Date       : 2007.12.10</br>
        /// </remarks>
        private void DCKHN09250UA_VisibleChanged(object sender, EventArgs e)
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
        /// <br>Programmer : 30167 上野　弘貴</br>
        /// <br>Date       : 2007.12.10</br>
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
            if ( result == DialogResult.OK )
            {
                switch ( this._targetTableName )
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
        /// <br>Programmer : 30167 上野　弘貴</br>
        /// <br>Date       : 2007.12.10</br>
        /// </remarks>
        private void Revive_Button_Click ( object sender, EventArgs e )
        {
            ReviveSlipOutputSet();
        }

        /// <summary>
        /// Control.Click イベント(OK_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 保存ボタンがクリックされたときに発生します。</br>
        /// <br>Programmer : 30167 上野　弘貴</br>
        /// <br>Date       : 2007.12.10</br>
        /// </remarks>
        private void Ok_Button_Click(object sender, EventArgs e)
        {
			bool flag = false;

			if(this.Mode_Label.Text == INSERT_MODE)
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
            //--- ADD 2008/06/20 ---------->>>>>
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
            //--- ADD 2008/06/20 ----------<<<<<
        }

        /// <summary>
        /// Control.Click イベント(Cancel_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 閉じるボタンがクリックされたときに発生します。</br>
        /// <br>Programmer : 30167 上野　弘貴</br>
        /// <br>Date       : 2007.12.10</br>
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
                                if ( SaveProc(this._targetTableName) )
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
        /// Form.Closing イベント(DCKHN09250UA)(SF100%流用)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">キャンセルできるイベントのデータを提供するクラス</param>
        /// <remarks>
        /// <br>Note       : フォームを閉じる前に、ユーザーがフォームを閉じようとしたときに発生します。</br>
        /// <br>Programmer : 30167 上野　弘貴</br>
        /// <br>Date       : 2007.12.10</br>
        /// </remarks>
        private void DCKHN09250UA_Closing(object sender, FormClosingEventArgs e)
        {
            // フォームの「×」をクリックされた場合の対応です。
            if (CanClose == false)
            {
                e.Cancel = true;
                this.Hide();
                return;
            }
        }

		/// <summary>
		/// tArrowKeyControl1_ChangeFocusイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
		{
			if ((e.PrevCtrl == null) || (e.NextCtrl == null)) return;

            // --- ADD 2008/10/03 ------------------------------------------------------->>>>>
            // 倉庫(コード未入力は"0000:共通"とみなす)
            if (e.PrevCtrl == this.tEdit_WarehouseCodeAllowZero)
            {
                // コードが入力されている
                if (string.IsNullOrEmpty(this.tEdit_WarehouseCodeAllowZero.Text.Trim()) == false)
                {
                    // 名称が無い
                    if (string.IsNullOrEmpty(WarehouseName_tNedit.Text.Trim()))
                    {
                        //return;   // DEL 2009/04/09
                    }
                }
                else
                {
                    // Enter/Tabキー押下
                    if ((e.ShiftKey == false) && ((e.Key == Keys.Enter) || (e.Key == Keys.Tab)))
                    {
                        e.NextCtrl = SlipPrtKind_tComboEditor;
                    }
                }

                // DEL 2009/04/09 ------>>>
                //// Enter/Tabキー押下
                //if ((e.ShiftKey == false) && ((e.Key == Keys.Enter) || (e.Key == Keys.Tab)))
                //{
                //    e.NextCtrl = SlipPrtKind_tComboEditor;
                //}
                //return;
                // DEL 2009/04/09 ------<<<
            }
            // --- ADD 2008/10/03 -------------------------------------------------------<<<<<

			switch(e.PrevCtrl.Name)
			{
				//----- h.ueno add---------- start 2007.12.19
				case "DataInputSystem_tComboEditor":
					{
						if(this.DataInputSystem_tComboEditor.Value != null)
						{
							DataInputSystemVisibleChange((Int32)this.DataInputSystem_tComboEditor.Value);
						}
						break;
					}
				//----- h.ueno add---------- end   2007.12.19
				case "SlipPrtKind_tComboEditor":
					{
						if (this.SlipPrtKind_tComboEditor.Value != null)
						{
							SlipPrtKindVisibleChange((Int32)this.SlipPrtKind_tComboEditor.Value);
						}
						break;
					}
				case "PrinterMngNo_tComboEditor":
					{
						if (this.PrinterMngNo_tComboEditor.Value != null)
						{
							PrinterMngNoVisibleChange((Int32)this.PrinterMngNo_tComboEditor.Value);
						}
						break;
					}
			}

            // 2009.03.25 30413 犬飼 新規モードからモード変更対応 >>>>>>START
            switch (e.NextCtrl.Name)
            {
                case "PrinterMngNo_tComboEditor":
                    {
                        if (this._detailsDataIndex < 0)
                        {
                            if (ModeChangeProc())
                            {
                                e.NextCtrl = tEdit_WarehouseCodeAllowZero;
                            }
                        }
                        break;
                    }
            }
            // 2009.03.25 30413 犬飼 新規モードからモード変更対応 <<<<<<END
		}

//----- h.ueno add---------- start 2007.12.19
		/// <summary>
		/// DataInputSystem_tComboEditor_SelectionChangeCommitted イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note　　　 : データ入力システムが変化したときに発生します。</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2007.12.19</br>
		/// </remarks>
		private void DataInputSystem_tComboEditor_SelectionChangeCommitted(object sender, EventArgs e)
		{
			if(this.DataInputSystem_tComboEditor.Value != null)
			{
				DataInputSystemVisibleChange((Int32)this.DataInputSystem_tComboEditor.Value);
			}
		}

//----- h.ueno add---------- end   2007.12.19

		/// <summary>
		/// SlipPrtKind_tComboEditor_SelectionChangeCommitted イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note　　　  : 伝票印刷種別が変化したときに発生します。</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2007.12.10</br>
		/// </remarks>
		private void SlipPrtKind_tComboEditor_SelectionChangeCommitted(object sender, EventArgs e)
		{
			if (this.SlipPrtKind_tComboEditor.Value != null)
			{
				SlipPrtKindVisibleChange((Int32)this.SlipPrtKind_tComboEditor.Value);
			}
		}

		/// <summary>
		/// PrinterMngNo_tComboEditor_SelectionChangeCommitted イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note　　　  : プリンタ管理Noがが変化したときに発生します。</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2007.12.10</br>
		/// </remarks>
		private void PrinterMngNo_tComboEditor_SelectionChangeCommitted(object sender, EventArgs e)
		{
			if(this.PrinterMngNo_tComboEditor.Value != null)
			{
				PrinterMngNoVisibleChange((Int32)this.PrinterMngNo_tComboEditor.Value);
			}
		}
        #endregion

		#region 端末別伝票出力先クラス画面展開処理
		/// <summary>
        /// 端末別伝票出力先クラス画面展開処理
        /// </summary>
		/// <param name="row">データロウ</param>
        /// <remarks>
        /// <br>Note       : オブジェクトから画面にデータを展開します。</br>
        /// <br>Programmer : 30167 上野　弘貴</br>
        /// <br>Date       : 2007.12.10</br>
        /// </remarks>
        private void DataRowToScreen (DataRow row)
        {
            //-----------------------------------------------
            // MainおよびSecondグリッドから取得
            //-----------------------------------------------
            // 拠点コード
            //this.SectionCode_tEdit.Text = this._bindDataSet.Tables[MAIN_TABLE].Rows[this._mainDataIndex][SlipOutputSetAcs.SECTIONCODE_TITLE].ToString();  // DEL 2008/06/20
			
			// 拠点名称
            //this.SectionName_tEdit.Text = this._bindDataSet.Tables[MAIN_TABLE].Rows[this._mainDataIndex][SlipOutputSetAcs.SECTIONNAME_TITLE].ToString();  // DEL 2008/06/20

			// 端末番号
			this.CashRegisterNo_tNedit.SetInt((int)this._bindDataSet.Tables[MAIN_TABLE].Rows[this._mainDataIndex][SlipOutputSetAcs.CASHREGISTERNO_TITLE]);
			
            //-----------------------------------------------
            // 画面入力から取得
            //-----------------------------------------------
            
            //--- ADD 2008/06/19 ----------->>>>>
            // 倉庫コード
            this.tEdit_WarehouseCodeAllowZero.Value = SlipOutputSetAcs.NullChgStr(row[SlipOutputSetAcs.WAREHOUSECODE_TITLE]);
            // 倉庫名称
            this.WarehouseName_tNedit.Value = SlipOutputSetAcs.NullChgStr(row[SlipOutputSetAcs.WAREHOUSENAME_TITLE]);
            //--- ADD 2008/06/19 -----------<<<<<
            
            //----- h.ueno add---------- start 2007.12.19
			// データ入力システム
			this.DataInputSystem_tComboEditor.Value = SlipOutputSetAcs.NullChgInt(row[SlipOutputSetAcs.DATAINPUTSYSTEM_TITLE]);
			//----- h.ueno add---------- end   2007.12.19

			// 伝票印刷種別
			this.SlipPrtKind_tComboEditor.Value = SlipOutputSetAcs.NullChgInt(row[SlipOutputSetAcs.SLIPPRTKIND_TITLE]);

            // ---ADD 2009/01/29 不具合対応[10657] ----------------------------------------------------------------->>>>>
            // 伝票印刷種別設定に対応する伝票印刷設定用帳票IDリストを作成
            SlipPrtKindVisibleChange(SlipOutputSetAcs.NullChgInt(this.SlipPrtKind_tComboEditor.Value));
            // ---ADD 2009/01/29 不具合対応[10657] -----------------------------------------------------------------<<<<<

			// 伝票印刷設定用帳票ID
			this.SlipPrtSetPaperId_tComboEditor.Value = SlipOutputSetAcs.NullChgStr(row[SlipOutputSetAcs.SLIPPRTSETPAPERID_TITLE]);
			
			// プリンタ管理No
			this.PrinterMngNo_tComboEditor.Value = SlipOutputSetAcs.NullChgInt(row[SlipOutputSetAcs.PRINTERMNGNO_TITLE]);
			
			// プリンタポート
			PrinterMngNoVisibleChange((Int32)SlipOutputSetAcs.NullChgInt(row[SlipOutputSetAcs.PRINTERMNGNO_TITLE]));
        }
        #endregion

        #region データセット更新
        /// <summary>
        /// データセット更新処理（ＤＢ更新を表示内容に反映させる）
        /// </summary>
		/// <param name="slipOutputSet">伝票印刷設定クラス</param>
        /// <param name="index">インデックス</param>
        private void DetailsToDataSet ( SlipOutputSet slipOutputSet, int index )
        {
            if ((index < 0)||(this._bindDataSet.Tables[DETAILS_TABLE].Rows.Count <= index))
            {
                // 新規と判断して、行を追加する
                DataRow dataRow = this._bindDataSet.Tables[DETAILS_TABLE].NewRow();
				
				//--------------
				// キー項目設定
				//--------------
				// 拠点コード
                //dataRow[SlipOutputSetAcs.SECTIONCODE_TITLE] = slipOutputSet.SectionCode;          // DEL 2008/06/20
				// 端末番号
				dataRow[SlipOutputSetAcs.CASHREGISTERNO_TITLE] = slipOutputSet.CashRegisterNo;
				//----- h.ueno add---------- start 2007.12.19
				// データ入力システム
				dataRow[SlipOutputSetAcs.DATAINPUTSYSTEM_TITLE] = slipOutputSet.DataInputSystem;
				//----- h.ueno add---------- end   2007.12.19
				// 伝票印刷種別
				dataRow[SlipOutputSetAcs.SLIPPRTKIND_TITLE] = slipOutputSet.SlipPrtKind;
				// 伝票印刷設定用帳票ID
				dataRow[SlipOutputSetAcs.SLIPPRTSETPAPERID_TITLE] = slipOutputSet.SlipPrtSetPaperId;
				
                // --- ADD m.suzuki 2010/09/27 ---------->>>>>
                // 伝票印刷設定用帳票ID（表示用）
                if ( slipOutputSet.SlipPrtKind == 99 )
                {
                    // 一般帳票
                    dataRow[SlipOutputSetAcs.SLIPPRTSETPAPERID_DISP_TITLE] = string.Empty;
                }
                else
                {
                    // 伝票・請求書
                    dataRow[SlipOutputSetAcs.SLIPPRTSETPAPERID_DISP_TITLE] = slipOutputSet.SlipPrtSetPaperId;
                }
                // --- ADD m.suzuki 2010/09/27 ----------<<<<<

                //--- ADD 2008/06/19 --------->>>>>
                // 倉庫コード
                dataRow[SlipOutputSetAcs.WAREHOUSECODE_TITLE] = slipOutputSet.WarehouseCode;
                //--- ADD 2008/06/19 ---------<<<<<

				this._bindDataSet.Tables[DETAILS_TABLE].Rows.Add(dataRow);

                // indexを行の最終行番号する
                index = this._bindDataSet.Tables[DETAILS_TABLE].Rows.Count - 1;
            }

            // 論理削除区分
            if ( slipOutputSet.LogicalDeleteCode == 0 )
            {
                this._bindDataSet.Tables[DETAILS_TABLE].Rows[index][SlipOutputSetAcs.DELETE_DATE_TITLE] = "";
            }
            else
            {
                this._bindDataSet.Tables[DETAILS_TABLE].Rows[index][SlipOutputSetAcs.DELETE_DATE_TITLE] = slipOutputSet.UpdateDateTimeJpInFormal;
            }
			
            // 拠点コード
            //this._bindDataSet.Tables[DETAILS_TABLE].Rows[index][SlipOutputSetAcs.SECTIONCODE_TITLE] = slipOutputSet.SectionCode;  // DEL 2008/06/20

			// 端末番号
			this._bindDataSet.Tables[DETAILS_TABLE].Rows[index][SlipOutputSetAcs.CASHREGISTERNO_TITLE] = slipOutputSet.CashRegisterNo;

			//----- h.ueno add---------- start 2007.12.19
			// システムデータ入力
			this._bindDataSet.Tables[DETAILS_TABLE].Rows[index][SlipOutputSetAcs.DATAINPUTSYSTEM_TITLE] = slipOutputSet.DataInputSystem;

			// システムデータ入力名称（グリッド表示用）
			this._bindDataSet.Tables[DETAILS_TABLE].Rows[index][SlipOutputSetAcs.DATAINPUTSYSTEMNM_TITLE]
				= SlipOutputSet.GetSortedListNm(slipOutputSet.DataInputSystem, SlipOutputSet._dataInputSystemList);
			//----- h.ueno add---------- end   2007.12.19

            //--- ADD 2008/06/19 ---------->>>>>
            // 倉庫コード
            this._bindDataSet.Tables[DETAILS_TABLE].Rows[index][SlipOutputSetAcs.WAREHOUSECODE_TITLE] = slipOutputSet.WarehouseCode;
            // 倉庫名称
            this._bindDataSet.Tables[DETAILS_TABLE].Rows[index][SlipOutputSetAcs.WAREHOUSENAME_TITLE] = GetWarehouseName(slipOutputSet.WarehouseCode);
            //--- ADD 2008/06/19 ---------->>>>>
            
            // 伝票印刷種別
			this._bindDataSet.Tables[DETAILS_TABLE].Rows[index][SlipOutputSetAcs.SLIPPRTKIND_TITLE] = slipOutputSet.SlipPrtKind;

			// 伝票印刷種別名称（グリッド表示用）
			this._bindDataSet.Tables[DETAILS_TABLE].Rows[index][SlipOutputSetAcs.SLIPPRTKINDNM_TITLE] = SlipOutputSet.GetSortedListNm(slipOutputSet.SlipPrtKind, SlipOutputSet._slipPrtKindList);

			// 伝票印刷設定用帳票ID
			this._bindDataSet.Tables[DETAILS_TABLE].Rows[index][SlipOutputSetAcs.SLIPPRTSETPAPERID_TITLE] = slipOutputSet.SlipPrtSetPaperId;
            // --- ADD m.suzuki 2010/09/27 ---------->>>>>
            // 伝票印刷設定用帳票ID（表示用）
            if ( slipOutputSet.SlipPrtKind == 99 )
            {
                // 一般帳票
                this._bindDataSet.Tables[DETAILS_TABLE].Rows[index][SlipOutputSetAcs.SLIPPRTSETPAPERID_DISP_TITLE] = string.Empty;
            }
            else
            {
                // 伝票・請求書
                this._bindDataSet.Tables[DETAILS_TABLE].Rows[index][SlipOutputSetAcs.SLIPPRTSETPAPERID_DISP_TITLE] = slipOutputSet.SlipPrtSetPaperId;
            }
            // --- ADD m.suzuki 2010/09/27 ----------<<<<<

			// プリンタ管理No
			this._bindDataSet.Tables[DETAILS_TABLE].Rows[index][SlipOutputSetAcs.PRINTERMNGNO_TITLE] = slipOutputSet.PrinterMngNo;

			// 伝票コメント（伝票印刷設定用帳票名称）
            string wkStr = this._slipOutputSetAcs.GetSlipComment( slipOutputSet.DataInputSystem, slipOutputSet.SlipPrtKind, slipOutputSet.SlipPrtSetPaperId );
            this._bindDataSet.Tables[DETAILS_TABLE].Rows[index][SlipOutputSetAcs.SLIPCOMMENT_TITLE] = wkStr;

			// プリンタ名
			this._bindDataSet.Tables[DETAILS_TABLE].Rows[index][SlipOutputSetAcs.PRINTERNAME_TITLE] = this._slipOutputSetAcs.GetPrinterName(slipOutputSet.PrinterMngNo);
			
			// プリンタポート（パス）
			this._bindDataSet.Tables[DETAILS_TABLE].Rows[index][SlipOutputSetAcs.PRINTERPORT_TITLE] = this._slipOutputSetAcs.GetPrinterPort(slipOutputSet.PrinterMngNo);
        }

        /// <summary>
        /// データセット削除処理（ＤＢ更新を表示内容に反映させる）
        /// </summary>
		/// <param name="slipOutputSet">伝票印刷設定クラス</param>
        /// <param name="index">インデックス</param>
        private void DeleteFromDataSet ( SlipOutputSet slipOutputSet, int index )
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
        /// <br>Programmer : 30167 上野　弘貴</br>
        /// <br>Date       : 2007.12.10</br>
        /// </remarks>
        private int LogicalDeleteSlipOutputSet ()
        {
            SlipOutputSet slipOutputSet;
            string message;

            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            //================================
            // 削除が可能か最終確認
            //================================
			if (this._detailsDataIndex < 0)
			{
                // 未選択
                return ( int ) ConstantManagement.DB_Status.ctDB_NORMAL;
            }

            // 削除予定データ取得
			DataRow dr = this._bindDataSet.Tables[DETAILS_TABLE].Rows[this._detailsDataIndex];

			status = this._slipOutputSetAcs.GetSlipOutputSet(	//SlipOutputSetAcs.NullChgStr(dr[SlipOutputSetAcs.SECTIONCODE_TITLE]),      // DEL 2008/06/20
																SlipOutputSetAcs.NullChgInt(dr[SlipOutputSetAcs.CASHREGISTERNO_TITLE]),
                                                                //--- ADD 2008/06/20 ---------->>>>>
                                                                SlipOutputSetAcs.NullChgStr(dr[SlipOutputSetAcs.WAREHOUSECODE_TITLE]),
                                                                //--- ADD 2008/06/20 ---------->>>>>
                                                                //----- h.ueno add---------- start 2007.12.19
																SlipOutputSetAcs.NullChgInt(dr[SlipOutputSetAcs.DATAINPUTSYSTEM_TITLE]),
																//----- h.ueno add---------- end   2007.12.19
																SlipOutputSetAcs.NullChgInt(dr[SlipOutputSetAcs.SLIPPRTKIND_TITLE]),
																SlipOutputSetAcs.NullChgStr(dr[SlipOutputSetAcs.SLIPPRTSETPAPERID_TITLE]),
																out slipOutputSet,
																out message);

            if ( status != ( int ) ConstantManagement.MethodResult.ctFNC_NORMAL )
            {
                // PGミス
                TMsgDisp.Show(this, 								// 親ウィンドウフォーム
                               emErrorLevel.ERR_LEVEL_INFO,     	// エラーレベル
                               ASSEMBLY_ID, 						// アセンブリＩＤまたはクラスＩＤ
                               "明細項目がヒットしません。",        // 表示するメッセージ
                               0, 		                            // ステータス値
                               MessageBoxButtons.OK, 				// 表示するボタン
                               MessageBoxDefaultButton.Button1);	// 初期表示ボタン

                return ( int ) ConstantManagement.DB_Status.ctDB_ERROR;
            }

            //==========================
            // 選択データを削除
            //==========================
            status = this._slipOutputSetAcs.LogicalDelete(ref slipOutputSet, out message); 

            if ( status == ( int ) ConstantManagement.DB_Status.ctDB_NORMAL )
            {
                // データテーブル再構築
				DetailsToDataSet(slipOutputSet, this._detailsDataIndex);
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
        /// <br>Programmer : 30167 上野　弘貴</br>
        /// <br>Date       : 2007.12.10</br>
        /// </remarks>
        private int PhysicalDeleteSlipOutputSet ()
        {
            SlipOutputSet slipOutputSet;
            string message;

            int status = ( int ) ConstantManagement.DB_Status.ctDB_NORMAL;

            //================================
            // 削除が可能か最終確認
            //================================
			if (this._detailsDataIndex < 0)
			{
                // 未選択
                return ( int ) ConstantManagement.DB_Status.ctDB_NORMAL;
            }

            // 削除予定データ取得
			DataRow dr = this._bindDataSet.Tables[DETAILS_TABLE].Rows[this._detailsDataIndex];

			status = this._slipOutputSetAcs.GetSlipOutputSet(	//SlipOutputSetAcs.NullChgStr(dr[SlipOutputSetAcs.SECTIONCODE_TITLE]),      // DEL 2008/06/20
																SlipOutputSetAcs.NullChgInt(dr[SlipOutputSetAcs.CASHREGISTERNO_TITLE]),
                                                                //--- ADD 2008/06/20 ---------->>>>>
                                                                SlipOutputSetAcs.NullChgStr(dr[SlipOutputSetAcs.WAREHOUSECODE_TITLE]),
                                                                //--- ADD 2008/06/20 ---------->>>>>
                                                                //----- h.ueno add---------- start 2007.12.19
																SlipOutputSetAcs.NullChgInt(dr[SlipOutputSetAcs.DATAINPUTSYSTEM_TITLE]),
																//----- h.ueno add---------- end   2007.12.19
																SlipOutputSetAcs.NullChgInt(dr[SlipOutputSetAcs.SLIPPRTKIND_TITLE]),
																SlipOutputSetAcs.NullChgStr(dr[SlipOutputSetAcs.SLIPPRTSETPAPERID_TITLE]),
																out slipOutputSet,
																out message);

            if ( status != ( int ) ConstantManagement.MethodResult.ctFNC_NORMAL )
            {
                // PGミス
                TMsgDisp.Show(this, 								// 親ウィンドウフォーム
                               emErrorLevel.ERR_LEVEL_INFO,     	// エラーレベル
                               ASSEMBLY_ID, 						// アセンブリＩＤまたはクラスＩＤ
                               "明細項目がヒットしません。",        // 表示するメッセージ
                               0, 		                            // ステータス値
                               MessageBoxButtons.OK, 				// 表示するボタン
                               MessageBoxDefaultButton.Button1);	// 初期表示ボタン

                return ( int ) ConstantManagement.DB_Status.ctDB_ERROR;
            }

            //==========================
            // 選択データを削除
            //==========================
            status = this._slipOutputSetAcs.Delete(ref slipOutputSet, out message); 

            if ( status == ( int ) ConstantManagement.DB_Status.ctDB_NORMAL )
            {
                // データテーブル再構築
				DeleteFromDataSet(slipOutputSet, this._detailsDataIndex);
            }

            if ( UnDisplaying != null )
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }

            this.DialogResult = DialogResult.OK;

            if ( CanClose == true )
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
        /// <br>Programmer : 30167 上野　弘貴</br>
        /// <br>Date       : 2007.12.10</br>
        /// </remarks>
        private int ReviveSlipOutputSet ()
        {
            int status = 0;
            SlipOutputSet slipOutputSet;
            string message;

            // 復活対象取得
			DataRow dr = this._bindDataSet.Tables[DETAILS_TABLE].Rows[this._detailsDataIndex];
            
            status = this._slipOutputSetAcs.GetSlipOutputSet(	//SlipOutputSetAcs.NullChgStr(dr[SlipOutputSetAcs.SECTIONCODE_TITLE]),      // DEL 2008/06/20
																SlipOutputSetAcs.NullChgInt(dr[SlipOutputSetAcs.CASHREGISTERNO_TITLE]),
                                                                //--- ADD 2008/06/20 ---------->>>>>
                                                                SlipOutputSetAcs.NullChgStr(dr[SlipOutputSetAcs.WAREHOUSECODE_TITLE]),
                                                                //--- ADD 2008/06/20 ---------->>>>>
                                                                //----- h.ueno add---------- start 2007.12.19
																SlipOutputSetAcs.NullChgInt(dr[SlipOutputSetAcs.DATAINPUTSYSTEM_TITLE]),
																//----- h.ueno add---------- end   2007.12.19
																SlipOutputSetAcs.NullChgInt(dr[SlipOutputSetAcs.SLIPPRTKIND_TITLE]),
																SlipOutputSetAcs.NullChgStr(dr[SlipOutputSetAcs.SLIPPRTSETPAPERID_TITLE]),
																out slipOutputSet,
																out message);
            // 復活
            status = this._slipOutputSetAcs.Revival(ref slipOutputSet, out message);

            switch(status)
			{
                case ( int ) ConstantManagement.DB_Status.ctDB_NORMAL:
					{
                        // DataSet展開処理
						DetailsToDataSet(slipOutputSet, this._detailsDataIndex);
                        break;
                    }
                case ( int ) ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case ( int ) ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
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
                            this._slipOutputSetAcs,    			// エラーが発生したオブジェクト
                            MessageBoxButtons.OK,				// 表示するボタン
                            MessageBoxDefaultButton.Button1);	// 初期表示ボタン
                        return status;
                    }
            }

            if ( UnDisplaying != null )
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }
            this.DialogResult = DialogResult.OK;

            if ( CanClose == true )
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
        /// 倉庫名称取得処理
        /// </summary>
        /// <param name="warehouseCode">倉庫コード</param>
        /// <returns>倉庫名称</returns>
        /// <remarks>
        /// <br>Note       : 倉庫名称を取得します。</br>
        /// <br>Programmer : 30416　長沼　賢二</br>
        /// <br>Date       : 2008/06/04</br>
        /// </remarks>
        private string GetWarehouseName(string warehouseCode)
        {
            string warehouseName = "";

            int status;
            WarehouseAcs warehouseAcs = new WarehouseAcs();
            ArrayList retList = new ArrayList();

            try
            {
                if (warehouseCode.Trim().PadLeft(4, '0') == WAREHOUSECODE_ZERO)
                {
                    warehouseName = WAREHOUSENAME_ZERO;
                }
                else
                {
                    status = warehouseAcs.SearchAll(out retList, this._enterpriseCode);
                    if (status == 0)
                    {
                        foreach (Warehouse warehouse in retList)
                        {
                            if (warehouse.LogicalDeleteCode == 0)
                            {
                                if (warehouse.WarehouseCode.Trim() == warehouseCode.Trim().PadLeft(4, '0'))
                                {
                                    warehouseName = warehouse.WarehouseName.Trim();
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            catch
            {
                warehouseName = "";
            }

            return warehouseName;
        }

        /// <summary>
        /// ValueChanged イベント(tEdit_WarehouseCodeAllowZero)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　  : 倉庫コードが変更された時に発生します。</br>
        /// <br>Programmer  : 30416　長沼　賢二</br>
        /// <br>Date        : 2008/06/20</br>
        /// </remarks>
        private void tEdit_WarehouseCodeAllowZero_ValueChanged(object sender, EventArgs e)
        {
            // 倉庫コードが未入力の場合
            if (this.tEdit_WarehouseCodeAllowZero.DataText.Trim() == "")
            {
                this.tEdit_WarehouseCodeAllowZero.DataText = "";
                return;
            }

            // 倉庫コードを取得
            string warehouseCode = this.tEdit_WarehouseCodeAllowZero.DataText;

            // 倉庫名称を設定
            this.WarehouseName_tNedit.DataText = GetWarehouseName(warehouseCode);
        }

        // --- ADD 2008/10/03 ------------------------------------------------------------->>>>>
        /// <summary>
        /// 倉庫ガイドクリックイベント
        /// </summary>
        /// <param name="sender">UltraButton型</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　  : 倉庫ガイドボタンがクリックされた時に発生します。</br>
        /// <br>Programmer  : 照田 貴志</br>
        /// <br>Date        : 2008/10/03</br>
        /// </remarks>
        private void ub_WarehouseCodeGuide_Click(object sender, EventArgs e)
        {
            WarehouseAcs warehouseAcs = new WarehouseAcs();
            Warehouse warehouse = null;

            // 倉庫ガイド用の拠点コードを取得
            int status = warehouseAcs.ExecuteGuid(out warehouse, this._enterpriseCode);
            if (status != 0)
            {
                return;
            }

            // コード展開
            tEdit_WarehouseCodeAllowZero.Value = warehouse.WarehouseCode.TrimEnd();
            WarehouseName_tNedit.Text = warehouse.WarehouseName;

            // 次フォーカス
            SlipPrtKind_tComboEditor.Focus();
        }

        /// <summary>
        /// 倉庫チェック
        /// </summary>
        /// <param name="warehouseCode">倉庫コード</param>
        /// <remarks>
        /// <br>Note　　　  : 入力された倉庫コードの有無判定を行います。</br>
        /// <br>Programmer  : 照田 貴志</br>
        /// <br>Date        : 2008/10/03</br>
        /// </remarks>
        private bool WarehouseIsExists(string warehouseCode)
        {
            // 共通はスルー
            //if (warehouseCode == "0000")              //DEL 2009/01/21 不具合対応[10304]
            if (warehouseCode.TrimEnd() == "0000")      //ADD 2009/01/21 不具合対応[10304]
            {
                return true;
            }

            WarehouseAcs warehouseAcs = new WarehouseAcs();
            ArrayList warehouseList = null;
            int status = warehouseAcs.Search(out warehouseList, this._enterpriseCode);
            if ((status != 0) || (warehouseList.Count == 0))
            {
                return false;
            }

            foreach (Warehouse warehouse in warehouseList)
            {
                //if (warehouseCode == warehouse.WarehouseCode.TrimEnd())           //DEL 2009/01/21 不具合対応[10304]
                if (warehouseCode.TrimEnd() == warehouse.WarehouseCode.TrimEnd())   //ADD 2009/01/21 不具合対応[10304]
                {
                    return true;
                }
            }
            return false;
        }
        // --- ADD 2008/10/03 -------------------------------------------------------------<<<<<

        // 2009.03.25 30413 犬飼 新規モードからモード変更対応 >>>>>>START
        /// <summary>
        /// モード変更処理
        /// </summary>
        private bool ModeChangeProc()
        {
            string msg = "入力されたコードの端末別伝票出力先設定情報が既に登録されています。\n編集を行いますか？";
            
            // 倉庫コード
            string warehouseCode = tEdit_WarehouseCodeAllowZero.Text.TrimEnd().PadLeft(4, '0');
            // 伝票印刷種別
            int slipPrtKind = (int)SlipPrtKind_tComboEditor.SelectedItem.DataValue;
            // 伝票印刷設定用帳票ID
            string slipPrtSetPaperId = (string)SlipPrtSetPaperId_tComboEditor.SelectedItem.DataValue;
            
            for (int i = 0; i < this._bindDataSet.Tables[DETAILS_TABLE].Rows.Count; i++)
            {
                // データセットと比較
                string dsWarehouseCode = (string)this._bindDataSet.Tables[DETAILS_TABLE].Rows[i][SlipOutputSetAcs.WAREHOUSECODE_TITLE];
                int dsSlipPrtKind = (int)this._bindDataSet.Tables[DETAILS_TABLE].Rows[i][SlipOutputSetAcs.SLIPPRTKIND_TITLE];
                string dsSlipPrtSetPaperId = (string)this._bindDataSet.Tables[DETAILS_TABLE].Rows[i][SlipOutputSetAcs.SLIPPRTSETPAPERID_TITLE];
                if ((warehouseCode.Equals(dsWarehouseCode.TrimEnd())) &&
                    (slipPrtKind == dsSlipPrtKind) &&
                    (slipPrtSetPaperId.Equals(dsSlipPrtSetPaperId.TrimEnd())))
                {
                    // 入力コードがデータセットに存在する場合
                    if ((string)this._bindDataSet.Tables[DETAILS_TABLE].Rows[i][SlipOutputSetAcs.DELETE_DATE_TITLE] != "")
                    {
                        // 論理削除
                        TMsgDisp.Show(this, 					// 親ウィンドウフォーム
                          emErrorLevel.ERR_LEVEL_INFO,          // エラーレベル
                          "DCKHN09250U",						// アセンブリＩＤまたはクラスＩＤ
                          "入力されたコードの端末別伝票出力先設定情報は既に削除されています。", 			// 表示するメッセージ
                          0, 									// ステータス値
                          MessageBoxButtons.OK);				// 表示するボタン
                        // 倉庫コード、名称のクリア
                        tEdit_WarehouseCodeAllowZero.Clear();
                        WarehouseName_tNedit.Clear();
                        return true;
                    }

                    if (warehouseCode == "0000")
                    {
                        // 全社共通のメッセージ変更
                        msg = "入力されたコードの全体初期表示設定情報が既に登録されています。\n　【倉庫名称：共通】\n編集を行いますか？";
                    }

                    DialogResult res = TMsgDisp.Show(
                        this,                                   // 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_INFO,            // エラーレベル
                        "DCKHN09250U",                          // アセンブリＩＤまたはクラスＩＤ
                        msg,                                    // 表示するメッセージ
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
                                // 倉庫コード、名称のクリア
                                tEdit_WarehouseCodeAllowZero.Clear();
                                WarehouseName_tNedit.Clear();
                                break;
                            }
                    }
                    return true;
                }
            }
            return false;
        }

        // --- ADD 2009/03/30 残案件No.14対応------------------------------------------------------>>>>>
        private void Renewal_Button_Click(object sender, EventArgs e)
        {
            int status = this._slipOutputSetAcs.Renewal(this._enterpriseCode);
            if (status == 0)
            {
                // ---  ADD chenw 2013/03/01 Redmine#34828 ---------------->>>>>
                // 一覧画面の伝票印刷グリッドから編集中データの伝票印刷設定用帳票ID（コード）を取得する
                string slipPrtSetPaperIdValue = string.Empty;
                if (this._detailsDataIndex >= 0)
                {
                    DataRow row = this._bindDataSet.Tables[DETAILS_TABLE].Rows[this._detailsDataIndex];
                    if (row != null)
                    {
                        slipPrtSetPaperIdValue = SlipOutputSetAcs.NullChgStr(row[SlipOutputSetAcs.SLIPPRTSETPAPERID_TITLE]);
                    }
                }
                // ---  ADD chenw 2013/03/01 Redmine#34828 ------------------<<<<<

                this.SlipPrtSetPaperId_tComboEditor.Items.Clear();
                
                // 伝票印刷設定用帳票ID
                SetComboDataSlipPrtSet(ref SlipOutputSet._slipPrtSetPaperIdList, ref this._dataTableSlipPrtSetPaperId);
                BindCombo(ref this.SlipPrtSetPaperId_tComboEditor, ref this._dataTableSlipPrtSetPaperId);

                if (this.SlipPrtKind_tComboEditor.Value != null)
                {
                    this._slipPrtKind_tComboEditorValue = -1;
                    SlipPrtKindVisibleChange((Int32)this.SlipPrtKind_tComboEditor.Value);
                    // ---  ADD chenw 2013/03/01 Redmine#34828 ---------------->>>>>
                    if (this._detailsDataIndex >= 0 && this.SlipPrtSetPaperId_tComboEditor.Value != null)
                    {
                        //伝票印刷設定用帳票IDテキストに「null」をセットする
                        this.SlipPrtSetPaperId_tComboEditor.Value = null;
                        //コントロールへの反映後に元々の設定値をコントロールにセットする
                        foreach (DataRow dr in this._dataTableSlipPrtSetPaperId.Rows)
                        {

                            if (dr[COMBO_CODE].Equals(slipPrtSetPaperIdValue))
                            {
                                this.SlipPrtSetPaperId_tComboEditor.Value = slipPrtSetPaperIdValue;
                                break;
                            }
                        }
                    }
                    // ---  ADD chenw 2013/03/01 Redmine#34828 ------------------<<<<<
                }

                // ADD 2009/04/07 ------>>>
                // プリンタ管理No
                // 最新情報設定前のクリア
                this._dataTablePrinterMngNo.Rows.Clear();
                this.PrinterMngNo_tComboEditor.Items.Clear();
                // 最新情報設定
                SetComboDataPrtManage(ref SlipOutputSet._printerMngNoList, ref this._dataTablePrinterMngNo);
                BindCombo(ref this.PrinterMngNo_tComboEditor, ref this._dataTablePrinterMngNo);

                this.PrinterMngNo_tComboEditor.Value = this._printerMngNo_tComboEditorValue;
                if (this.PrinterMngNo_tComboEditor.Value != null)
                {
                    // 最新情報取得前の項目が存在する
                    this._printerMngNo_tComboEditorValue = -1;
                }
                else
                {
                    // 最新情報取得前の項目が存在しない
                    this.PrinterMngNo_tComboEditor.SelectedIndex = 0;
                }
                PrinterMngNoVisibleChange((Int32)this.PrinterMngNo_tComboEditor.Value);
                // ADD 2009/04/07 ------<<<

                TMsgDisp.Show(this, 								// 親ウィンドウフォーム
                              emErrorLevel.ERR_LEVEL_INFO,          // エラーレベル
                              ASSEMBLY_ID,						    // アセンブリＩＤまたはクラスＩＤ
                              "最新情報を取得しました。", 			// 表示するメッセージ
                              0, 									// ステータス値
                              MessageBoxButtons.OK);				// 表示するボタン
            }
        }
        // --- ADD 2009/03/30 残案件No.14対応------------------------------------------------------<<<<<
        // 2009.03.25 30413 犬飼 新規モードからモード変更対応 <<<<<<END
    }
}