using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 商品中分類設定フォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note		: 商品中分類の設定を行います。
    ///					  IMasterMaintenanceMultiTypeを実装しています。</br>
    /// <br>Programmer	: 30414 忍　幸史</br>
    /// <br>Date		: 2008/06/11</br>
    /// <br>UpdateNote   : 2008/10/07 30462 行澤 仁美　バグ修正</br>
    /// <br>Update Note : 2012/11/08 田建委</br>
    /// <br>管理番号    : 10801804-00 20130116配信分</br>
    /// <br>              Redmine#33228 提供分データ「2000」「3000」「4000」などが表示されない修正</br>
    /// </remarks>
    public partial class PMKHN09070UA : Form, IMasterMaintenanceMultiType
    {
        #region Constants

        // 編集モード
        private const string INSERT_MODE = "新規モード";
        private const string UPDATE_MODE = "更新モード";
        private const string DELETE_MODE = "削除モード";

        // テーブル名称
        private const string GOODSGROUPU_TABLE = "GoodsGroupU";

        // FremのView用Grid列のKEY情報 (ヘッダのタイトル部となります)
        private const string DELETE_DATE_TITLE      = "削除日";
        private const string GOODSMGROUPCODE_TITLE  = "商品中分類コード";
        // DEL 2008/10/07 不具合対応[6314] ↓
        //private const string GOODSMGROUPNAME_TITLE  = "商品中分類名称";
        private const string GOODSMGROUPNAME_TITLE  = "商品中分類名";     // ADD 2008/10/07 不具合対応[6314]
        private const string DIVISION_TITLE         = "データ区分コード";
        private const string DIVISIONNAME_TITLE     = "データ区分";
        private const string GUID_TITLE             = "Guid";

        // プログラムID
        private const string ASSEMBLY_ID = "PMKHN09070U";

        //データ区分
        private const int DIVISION_USR = 0;         // ユーザーデータ
        private const int DIVISION_OFR = 1;         // 提供データ

        #endregion Constants

        #region Private Members

        // プロパティ用
        private int _dataIndex;
        private bool _canClose;
        private bool _canDelete;
        private bool _canNew;
        private bool _canPrint;
        private bool _canLogicalDeleteDataExtraction;
        private bool _canSpecificationSearch;
        private bool _defaultAutoFillToColumn;

        // 企業コード
        private string _enterpriseCode;

        // 商品中分類マスタアクセスクラス
        private GoodsGroupUAcs _goodsGroupUAcs;

        // ユーザーガイドマスタアクセスクラス
        private UserGuideAcs _userGuideAcs;

        private Hashtable _goodsGroupUTable;

        private int _indexBuf;

        // データ区分(0:ユーザー 1:提供)
        private int _divisionCode;

        // 終了時の編集チェック用
        private GoodsGroupU _goodsGroupUClone;

        // 2009.03.27 30413 犬飼 新規モードからモード変更対応 >>>>>>START
        // モードフラグ(true：コード、false：コード以外)
        private bool _modeFlg = false;
        // 2009.03.27 30413 犬飼 新規モードからモード変更対応 <<<<<<END
		
        #endregion Private Members

        #region Constructor

        /// <summary>
        /// 商品中分類設定フォームクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : フォームクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date	   : 2008/06/11</br>
        /// </remarks>
        public PMKHN09070UA()
        {
            InitializeComponent();

            // データセット列情報構築処理
            DataSetColumnConstruction();

            // プロパティ初期値設定
            this._dataIndex = -1;
            this._canClose = false;
            this._canDelete = true;
            this._canNew = true;
            this._canPrint = false;
            this._canLogicalDeleteDataExtraction = true;
            this._canSpecificationSearch = false;
            this._defaultAutoFillToColumn = false;

            // 企業コード取得
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            // 変数初期化
            this._goodsGroupUAcs = new GoodsGroupUAcs();
            this._userGuideAcs = new UserGuideAcs();
            this._goodsGroupUTable = new Hashtable();

            // GridIndexバッファ（メインフレーム最小化対応）
            this._indexBuf = -2;
        }

        #endregion Constructor

        #region IMasterMaintenanceMultiType メンバ

        /// <summary>画面終了設定プロパティ</summary>
        /// <value>画面クローズを許可するかどうかの設定を取得または設定します。</value>
        /// <remarks>falseの場合は、画面を閉じる際、CloseではなくHide(非表示)を実行します。</remarks>
        public bool CanClose
        {
            get
            {
                return this._canClose;
            }
            set
            {
                this._canClose = value;
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

        /// <summary>新規登録可能設定プロパティ</summary>
        /// <value>新規登録が可能かどうかの設定を取得します。</value>
        public bool CanNew
        {
            get
            {
                return this._canNew;
            }
        }

        /// <summary>印刷可能設定プロパティ</summary>
        /// <value>印刷可能かどうかの設定を取得します。</value>
        public bool CanPrint
        {
            get
            {
                return this._canPrint;
            }
        }

        /// <summary>件数指定抽出可能設定プロパティ</summary>
        /// <value>件数指定抽出を可能とするかどうかの設定を取得または設定します。</value>
        public bool CanSpecificationSearch
        {
            get
            {
                return this._canSpecificationSearch;
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

        /// <summary>列のサイズの自動調整のデフォルト値プロパティ</summary>
        /// <value>列のサイズの自動調整チェックボックスのチェック有無のデフォルト値を取得します。</value>
        public bool DefaultAutoFillToColumn
        {
            get
            {
                return this._defaultAutoFillToColumn;
            }
        }

        /// <summary>
        /// グリッド列外観情報取得処理
        /// </summary>
        /// <returns>グリッド列外観情報格納Hashtable</returns>
        /// <remarks>
        /// <br>Note       : 各列の外見を設定するクラスを格納したHashtableを取得します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/06/11</br>
        /// </remarks>
        public Hashtable GetAppearanceTable()
        {
            Hashtable appearanceTable = new Hashtable();

            appearanceTable.Add(DELETE_DATE_TITLE, new GridColAppearance(MGridColDispType.DeletionDataBoth, ContentAlignment.MiddleLeft, "", Color.Red));
            // DEL 2008/10/07 不具合対応[6311] ↓
            //appearanceTable.Add(GOODSMGROUPCODE_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            appearanceTable.Add(GOODSMGROUPCODE_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "0000", Color.Black));    // ADD 2008/10/07 不具合対応[6311]
            appearanceTable.Add(GOODSMGROUPNAME_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black)); 
            appearanceTable.Add(DIVISION_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            appearanceTable.Add(DIVISIONNAME_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(GUID_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));

            return appearanceTable;
        }

        /// <summary>
        /// バインドデータセット取得処理
        /// </summary>
        /// <param name="bindDataSet">グリッド用データセット</param>
        /// <param name="tableName">テーブル名称</param>
        /// <remarks>
        /// <br>Note       : グリッドにバインドさせるデータセットを取得します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/06/11</br>
        /// </remarks>
        public void GetBindDataSet(ref DataSet bindDataSet, ref string tableName)
        {
            bindDataSet = this.Bind_DataSet;
            tableName = GOODSGROUPU_TABLE;
        }

        /// <summary>
        /// 印刷処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 印刷処理を実行します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/06/11</br>
        /// </remarks>
        public int Print()
        {
            // 印刷機能無しのため未実装
            return 0;
        }

        /// <summary>
        /// データ削除処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 選択中のデータを論理削除します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/06/11</br>
        /// <br>Update Note: 2012/11/08 田建委</br>
        /// <br>管理番号   : 10801804-00 20130116配信分</br>
        /// <br>             Redmine#33228の#3 提供データが削除できたり、ユーザー分データが削除できなかったりする現象の修正</br>
        /// </remarks>
        public int Delete()
        {
            //----- ADD 2012/11/08 田建委 Redmine#33228 ---------------------------->>>>>
            // ハッシュキー作成
            string hashKey = CreateHashKey(this._dataIndex);

            GoodsGroupU goodsGroupU = new GoodsGroupU();
            goodsGroupU = (GoodsGroupU)this._goodsGroupUTable[hashKey];
            //----- ADD 2012/11/08 田建委 Redmine#33228 ----------------------------<<<<<

            //if (this._divisionCode == DIVISION_OFR) // DEL 2012/11/08 田建委 Redmine#33228
            if (goodsGroupU.DivisionCode == DIVISION_OFR) // ADD 2012/11/08 田建委 Redmine#33228
            {
                // 提供データ削除不可
                TMsgDisp.Show(
                    this, 								// 親ウィンドウフォーム
                    emErrorLevel.ERR_LEVEL_INFO, 		// エラーレベル
                    ASSEMBLY_ID, 						// アセンブリＩＤまたはクラスＩＤ
                    "提供データは削除できません。", 	// 表示するメッセージ
                    0, 									// ステータス値
                    MessageBoxButtons.OK);				// 表示するボタン
                return 0;
            }

            //----- DEL 2012/11/08 田建委 Redmine#33228 ---------------------------->>>>>
            //// ハッシュキー作成
            //string hashKey = CreateHashKey(this._dataIndex);

            //GoodsGroupU goodsGroupU = new GoodsGroupU();
            //goodsGroupU = (GoodsGroupU)this._goodsGroupUTable[hashKey];
            //----- DEL 2012/11/08 田建委 Redmine#33228 ----------------------------<<<<<

            // 論理削除処理
            int status = this._goodsGroupUAcs.LogicalDelete(ref goodsGroupU);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // データセット展開
                        GoodsGroupUToDataSet(goodsGroupU.Clone(), this._dataIndex);
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        // 排他制御
                        ExclusiveTransaction(status, false);
                        break;
                    }
                default:
                    {
                        TMsgDisp.Show(
                            this, 								// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOP, 		// エラーレベル
                            ASSEMBLY_ID, 						// アセンブリＩＤまたはクラスＩＤ
                            this.Text,				            // プログラム名称
                            "Delete", 							// 処理名称
                            TMsgDisp.OPE_HIDE, 					// オペレーション
                            "論理削除に失敗しました。", 		// 表示するメッセージ
                            status, 							// ステータス値
                            this._goodsGroupUAcs, 				// エラーが発生したオブジェクト
                            MessageBoxButtons.OK, 				// 表示するボタン
                            MessageBoxDefaultButton.Button1);	// 初期表示ボタン
                        break;
                    }
            }

            return status;
        }

        /// <summary>
        /// 商品中分類検索処理
        /// </summary>
        /// <param name="totalCount">全該当件数</param>
        /// <param name="readCount">抽出対象件数</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 全データを検索し、抽出結果を展開したDataSetと全該当件数を返します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/06/11</br>
        /// </remarks>
        public int Search(ref int totalCount, int readCount)
        {
            int status = -1;
            totalCount = 0;

            try
            {
                // クリア
                this.Bind_DataSet.Tables[GOODSGROUPU_TABLE].Rows.Clear();
                this._goodsGroupUTable.Clear();

                ArrayList retList = new ArrayList();

                // 検索処理
                status = this._goodsGroupUAcs.SearchAll(out retList, this._enterpriseCode);
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:

                        int index = 0;
                        foreach (GoodsGroupU goodsGroupU in retList)
                        {
                            // ハッシュキー作成
                            string hashKey = CreateHashKey(goodsGroupU);

                            if (this._goodsGroupUTable.ContainsKey(hashKey) == false)
                            {
                                // データセット展開
                                GoodsGroupUToDataSet(goodsGroupU.Clone(), index);
                                ++index;
                            }
                        }

                        totalCount = retList.Count;

                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        break;
                    default:
                        TMsgDisp.Show(
                            this, 								// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOP, 		// エラーレベル
                            ASSEMBLY_ID, 						// アセンブリＩＤまたはクラスＩＤ
                            this.Text, 					        // プログラム名称
                            "Search", 					        // 処理名称
                            TMsgDisp.OPE_GET, 					// オペレーション
                            "読み込みに失敗しました。", 		// 表示するメッセージ
                            status, 							// ステータス値
                            this._goodsGroupUAcs, 				// エラーが発生したオブジェクト
                            MessageBoxButtons.OK, 				// 表示するボタン
                            MessageBoxDefaultButton.Button1);	// 初期表示ボタン

                        break;
                }
            }
            catch (Exception)
            {
                // サーチ
                TMsgDisp.Show(
                    this,								  // 親ウィンドウフォーム
                    emErrorLevel.ERR_LEVEL_STOPDISP,	  // エラーレベル
                    ASSEMBLY_ID,						  // アセンブリＩＤまたはクラスＩＤ
                    this.Text,							  // プログラム名称
                    "Search",							  // 処理名称
                    TMsgDisp.OPE_GET,					  // オペレーション
                    "読み込みに失敗しました。",			  // 表示するメッセージ 
                    status,								  // ステータス値
                    this._goodsGroupUAcs,				  // エラーが発生したオブジェクト
                    MessageBoxButtons.OK,				  // 表示するボタン
                    MessageBoxDefaultButton.Button1);	  // 初期表示ボタン

                status = -1;
                return status;
            }

            return status;
        }

        /// <summary>
        /// ネクストデータ検索処理
        /// </summary>
        /// <param name="readCount">抽出対象件数</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 指定した件数分のネクストデータを検索します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/06/11</br>
        /// </remarks>
        public int SearchNext(int readCount)
        {
            // 実装なし
            return 0;
        }

        /// <summary>画面非表示イベント</summary>
        /// <remarks>画面が非表示状態になった際に発生します。</remarks>
        public event MasterMaintenanceMultiTypeUnDisplayingEventHandler UnDisplaying;

        #endregion

        #region Private Methods

        /// <summary>
        /// HashTable用Key作成処理
        /// </summary>
        /// <param name="goodsGroupU">商品中分類マスタオブジェクト</param>
        /// <returns>キー</returns>
        /// <remarks>
        /// <br>Note       : ハッシュテーブル用のキーを作成します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/06/11</br>
        /// <br>Update Note: 2012/11/08 田建委</br>
        /// <br>管理番号   : 10801804-00 20130116配信分</br>
        /// <br>             Redmine#33228 提供分データ「2000」「3000」「4000」などが表示されない修正</br>
        /// </remarks>
        private string CreateHashKey(GoodsGroupU goodsGroupU)
        {
            //string hashKey = goodsGroupU.GoodsMGroup.ToString().PadRight(4, '0') + goodsGroupU.DivisionCode.ToString(); // DEL 2012/11/08 田建委 Redmine#33228
            string hashKey = goodsGroupU.GoodsMGroup.ToString().PadLeft(4, '0') + goodsGroupU.DivisionCode.ToString(); // ADD 2012/11/08 田建委 Redmine#33228

            return hashKey;
        }

        /// <summary>
        /// HashTable用Key作成処理
        /// </summary>
        /// <param name="dataIndex">グリッドインデックス</param>
        /// <returns>キー</returns>
        /// <remarks>
        /// <br>Note       : ハッシュテーブル用のキーを作成します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/06/11</br>
        /// <br>Update Note: 2012/11/08 田建委</br>
        /// <br>管理番号   : 10801804-00 20130116配信分</br>
        /// <br>             Redmine#33228 提供分データ「2000」「3000」「4000」などが表示されない修正</br>
        /// </remarks>
        private string CreateHashKey(int dataIndex)
        {
            int goodsGroupCode = (int)this.Bind_DataSet.Tables[GOODSGROUPU_TABLE].Rows[dataIndex][GOODSMGROUPCODE_TITLE];
            int divisionCode = (int)this.Bind_DataSet.Tables[GOODSGROUPU_TABLE].Rows[dataIndex][DIVISION_TITLE];
            //string hashKey = goodsGroupCode.ToString().PadRight(4, '0') + divisionCode.ToString(); // DEL 2012/11/08 田建委 Redmine#33228
            string hashKey = goodsGroupCode.ToString().PadLeft(4, '0') + divisionCode.ToString(); // ADD 2012/11/08 田建委 Redmine#33228

            return hashKey;
        }

        /// <summary>
        /// データセット列情報構築処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : データセットの列情報を構築します。
        ///					 データセットの列情報がフレームのビュー用グリッドの列になります</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/06/11</br>
        /// </remarks>
        private void DataSetColumnConstruction()
        {
            DataTable dataTable = new DataTable(GOODSGROUPU_TABLE);

            // Addを行う順番が、列の表示順位となります。
            dataTable.Columns.Add(DELETE_DATE_TITLE, typeof(string));
            dataTable.Columns.Add(GOODSMGROUPCODE_TITLE, typeof(int));
            dataTable.Columns.Add(GOODSMGROUPNAME_TITLE, typeof(string));
            dataTable.Columns.Add(DIVISION_TITLE, typeof(int));
            dataTable.Columns.Add(DIVISIONNAME_TITLE, typeof(string));
            dataTable.Columns.Add(GUID_TITLE, typeof(Guid));

            this.Bind_DataSet.Tables.Add(dataTable);
        }

        /// <summary>
        /// コントロールサイズ設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : コントロールのサイズ設定処理を行います。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/06/11</br>
        /// </remarks>
        private void SetControlSize()
        {
            this.tNedit_GoodsMGroup.Size = new Size(52, 24);
            this.GoodsMGroupName_tEdit.Size = new Size(330, 24);
        }

        /// <summary>
        /// 画面クリア処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面をクリアします。</br>
        /// <br>Programmer : 30414 忍　幸史/br>
        /// <br>Date       : 2008/06/11</br>
        /// </remarks>
        private void ScreenClear()
        {
            this.Mode_Label.Text = "";

            this.tNedit_GoodsMGroup.Clear();
            this.GoodsMGroupName_tEdit.Clear();
        }

        /// <summary>
        /// 画面入力許可制御処理
        /// </summary>
        /// <param name="editMode">編集モード(INSERT_MODE：新規　UPDATE_MODE：更新　REFER_MODE：参照　DELETE_MODE：削除)</param>
        /// <remarks>
        /// <br>Note       : 画面の入力許可を制御します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/06/11</br>
        /// </remarks>
        private void ScreenInputPermissionControl(string editMode)
        {
            switch (editMode)
            {
                // 新規モード
                case INSERT_MODE:

                    this.tNedit_GoodsMGroup.Enabled = true;
                    this.GoodsMGroupName_tEdit.Enabled = true;

                    this.Ok_Button.Enabled = true;
                    this.Cancel_Button.Enabled = true;
                    this.Revive_Button.Enabled = false;
                    this.Delete_Button.Enabled = false;

                    this.Ok_Button.Visible = true;
                    this.Cancel_Button.Visible = true;
                    this.Revive_Button.Visible = false;
                    this.Delete_Button.Visible = false;

                    break;
                // 更新モード
                case UPDATE_MODE:

                    this.tNedit_GoodsMGroup.Enabled = false;
                    this.GoodsMGroupName_tEdit.Enabled = true;

                    this.Ok_Button.Enabled = true;
                    this.Cancel_Button.Enabled = true;
                    this.Revive_Button.Enabled = false;
                    this.Delete_Button.Enabled = false;

                    this.Ok_Button.Visible = true;
                    this.Cancel_Button.Visible = true;
                    this.Revive_Button.Visible = false;
                    this.Delete_Button.Visible = false;

                    break;
                // 削除モード
                case DELETE_MODE:

                    this.tNedit_GoodsMGroup.Enabled = false;
                    this.GoodsMGroupName_tEdit.Enabled = false;

                    this.Ok_Button.Enabled = false;
                    this.Cancel_Button.Enabled = true;
                    this.Revive_Button.Enabled = true;
                    this.Delete_Button.Enabled = true;

                    this.Ok_Button.Visible = false;
                    this.Cancel_Button.Visible = true;
                    this.Revive_Button.Visible = true;
                    this.Delete_Button.Visible = true;

                    break;
            }
        }

        /// <summary>
        /// 排他処理
        /// </summary>
        /// <param name="status">STATUS</param>
        /// <param name="hide">非表示フラグ(true: 非表示にする, false: 非表示にしない)</param>
        /// <remarks>
        /// <br>Note       : 排他処理を行います</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/06/11</br>
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
                            ASSEMBLY_ID, 						// アセンブリＩＤまたはクラスＩＤ
                            this.Text,				            // プログラム名称
                            "ExclusiveTransaction", 			// 処理名称
                            TMsgDisp.OPE_HIDE, 					// オペレーション
                            "既に他端末より更新されています。", // 表示するメッセージ
                            status, 							// ステータス値
                            this._goodsGroupUAcs, 				// エラーが発生したオブジェクト
                            MessageBoxButtons.OK, 				// 表示するボタン
                            MessageBoxDefaultButton.Button1);	// 初期表示ボタン
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        // 他端末削除
                        TMsgDisp.Show(
                            this, 								// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
                            ASSEMBLY_ID, 						// アセンブリＩＤまたはクラスＩＤ
                            this.Text,				            // プログラム名称
                            "ExclusiveTransaction", 			// 処理名称
                            TMsgDisp.OPE_HIDE, 					// オペレーション
                            "既に他端末より削除されています。", // 表示するメッセージ
                            status, 							// ステータス値
                            this._goodsGroupUAcs, 				// エラーが発生したオブジェクト
                            MessageBoxButtons.OK, 				// 表示するボタン
                            MessageBoxDefaultButton.Button1);	// 初期表示ボタン
                        break;
                    }
            }
        }

        /// <summary>
        /// 商品中分類設定オブジェクトデータセット展開処理
        /// </summary>
        /// <param name="goodsGroupU">商品中分類設定オブジェクト</param>
        /// <param name="index">データセットへ展開するインデックス</param>
        /// <remarks>
        /// <br>Note       : 商品中分類設定クラスをデータセットに格納します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/06/11</br>
        /// </remarks>
        private void GoodsGroupUToDataSet(GoodsGroupU goodsGroupU, int index)
        {
            if ((index < 0) || (this.Bind_DataSet.Tables[GOODSGROUPU_TABLE].Rows.Count <= index))
            {
                // 新規と判断して、行を追加する
                DataRow dataRow = this.Bind_DataSet.Tables[GOODSGROUPU_TABLE].NewRow();
                this.Bind_DataSet.Tables[GOODSGROUPU_TABLE].Rows.Add(dataRow);

                // indexを行の最終行番号する
                index = this.Bind_DataSet.Tables[GOODSGROUPU_TABLE].Rows.Count - 1;
            }

            // 論理削除区分
            if (goodsGroupU.LogicalDeleteCode == 0)
            {
                this.Bind_DataSet.Tables[GOODSGROUPU_TABLE].Rows[index][DELETE_DATE_TITLE] = "";
            }
            else
            {
                this.Bind_DataSet.Tables[GOODSGROUPU_TABLE].Rows[index][DELETE_DATE_TITLE] = goodsGroupU.UpdateDateTimeJpInFormal;
            }

            // 商品中分類コード
            this.Bind_DataSet.Tables[GOODSGROUPU_TABLE].Rows[index][GOODSMGROUPCODE_TITLE] = goodsGroupU.GoodsMGroup;

            // 商品中分類名称
            this.Bind_DataSet.Tables[GOODSGROUPU_TABLE].Rows[index][GOODSMGROUPNAME_TITLE] = goodsGroupU.GoodsMGroupName.Trim();

            // データ区分コード
            this.Bind_DataSet.Tables[GOODSGROUPU_TABLE].Rows[index][DIVISION_TITLE] = goodsGroupU.DivisionCode;

            // データ区分名称
            this.Bind_DataSet.Tables[GOODSGROUPU_TABLE].Rows[index][DIVISIONNAME_TITLE] = goodsGroupU.DivisionName;

            // GUID
            this.Bind_DataSet.Tables[GOODSGROUPU_TABLE].Rows[index][GUID_TITLE] = goodsGroupU.FileHeaderGuid;

            // ハッシュキー作成
            string hashKey = CreateHashKey(goodsGroupU);

            // ハッシュテーブル更新
            if (this._goodsGroupUTable.ContainsKey(hashKey) == true)
            {
                this._goodsGroupUTable.Remove(hashKey);
            }
            this._goodsGroupUTable.Add(hashKey, goodsGroupU);
        }

        /// <summary>
        /// 画面再構築処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : モードに基づいて画面を再構築します。</br>
        /// <br>Programmer : 30414 忍　幸史/br>
        /// <br>Date       : 2008/06/11</br>
        /// </remarks>
        private void ScreenReconstruction()
        {
            GoodsGroupU goodsGroupU = new GoodsGroupU();

            // 新規の場合
            if (this._dataIndex < 0)
            {
                // 新規モード
                this.Mode_Label.Text = INSERT_MODE;

                // データ区分
                this._divisionCode = DIVISION_USR;

                // 画面入力許可制御処理
                ScreenInputPermissionControl(INSERT_MODE);

                // 画面展開処理
                GoodsGroupUToScreen(goodsGroupU);

                // クローン作成
                this._goodsGroupUClone = goodsGroupU.Clone();

                // 画面情報格納処理
                ScreenToGoodsGroupU(ref this._goodsGroupUClone);

                // フォーカス設定
                this.tNedit_GoodsMGroup.Focus();
            }
            else
            {
                // ハッシュキー作成
                string hashKey = CreateHashKey(this._dataIndex);

                goodsGroupU = (GoodsGroupU)this._goodsGroupUTable[hashKey];

                // データ区分
                this._divisionCode = goodsGroupU.DivisionCode;

                // 削除の場合
                if ((string)this.Bind_DataSet.Tables[GOODSGROUPU_TABLE].Rows[this._dataIndex][DELETE_DATE_TITLE] != "")
                {
                    // 削除モード
                    this.Mode_Label.Text = DELETE_MODE;

                    // 画面入力許可制御処理
                    ScreenInputPermissionControl(DELETE_MODE);

                    // 画面展開処理
                    GoodsGroupUToScreen(goodsGroupU);

                    // フォーカス設定
                    this.Delete_Button.Focus();
                }
                // 更新の場合
                else
                {
                    // 更新モード
                    this.Mode_Label.Text = UPDATE_MODE;

                    // 画面入力許可制御処理
                    ScreenInputPermissionControl(UPDATE_MODE);

                    // 画面展開処理
                    GoodsGroupUToScreen(goodsGroupU);

                    // クローン作成
                    this._goodsGroupUClone = goodsGroupU.Clone();

                    // 画面情報格納処理
                    ScreenToGoodsGroupU(ref this._goodsGroupUClone);

                    // フォーカス設定
                    this.GoodsMGroupName_tEdit.Focus();
                }
            }

            // _indexBufバッファ保持
            this._indexBuf = this._dataIndex;
        }

        /// <summary>
        /// 商品中分類設定クラス画面展開処理
        /// </summary>
        /// <param name="goodsGroupU">商品中分類設定オブジェクト</param>
        /// <remarks>
        /// <br>Note       : オブジェクトから画面にデータを展開します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/06/11</br>
        /// </remarks>
        private void GoodsGroupUToScreen(GoodsGroupU goodsGroupU)
        {
            // 商品中分類コード
            if (goodsGroupU.GoodsMGroup == 0)
            {
                this.tNedit_GoodsMGroup.Clear();
            }
            else
            {
                this.tNedit_GoodsMGroup.SetInt(goodsGroupU.GoodsMGroup);
            }

            // 商品中分類名称
            this.GoodsMGroupName_tEdit.DataText = goodsGroupU.GoodsMGroupName.Trim();
        }

        /// <summary>
        /// 画面情報商品中分類設定クラス格納処理
        /// </summary>
        /// <param name="goodsGroupU">商品中分類設定オブジェクト</param>
        /// <remarks>
        /// <br>Note       : 画面情報から商品中分類設定オブジェクトにデータを格納します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/06/11</br>
        /// </remarks>
        private void ScreenToGoodsGroupU(ref GoodsGroupU goodsGroupU)
        {
            // 企業コード
            goodsGroupU.EnterpriseCode = this._enterpriseCode;

            // 商品中分類コード
            goodsGroupU.GoodsMGroup = this.tNedit_GoodsMGroup.GetInt();

            // 商品中分類名称
            goodsGroupU.GoodsMGroupName = this.GoodsMGroupName_tEdit.DataText.Trim();
        }

        /// <summary>
        /// 商品中分類設定マスタ保存処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 商品中分類設定マスタを保存します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/06/11</br>
        /// </remarks>
        private bool SaveProc()
        {
            // 入力データチェック
            if (CheckScreenInput() != true)
            {
                return (false);
            }

            GoodsGroupU goodsGroupU = new GoodsGroupU();

            // 登録レコード情報取得
            if (this._indexBuf >= 0)
            {
                // ハッシュキー作成
                string hashKey = CreateHashKey(this._dataIndex);

                goodsGroupU = ((GoodsGroupU)this._goodsGroupUTable[hashKey]).Clone();
            }

            // 画面情報格納
            ScreenToGoodsGroupU(ref goodsGroupU);

            // 保存処理
            int status = this._goodsGroupUAcs.Write(ref goodsGroupU);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // DataSet/Hash更新処理
                        GoodsGroupUToDataSet(goodsGroupU, this._indexBuf);

                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE:
                    {
                        TMsgDisp.Show(
                        this, 										        // 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_INFO, 				        // エラーレベル
                        ASSEMBLY_ID, 								        // アセンブリＩＤまたはクラスＩＤ
                        "この商品中分類コードは既に使用されています。", 	// 表示するメッセージ
                        0, 											        // ステータス値
                        MessageBoxButtons.OK);						        // 表示するボタン

                        this.tNedit_GoodsMGroup.Focus();

                        return (false);
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        // 排他処理
                        ExclusiveTransaction(status, false);

                        break;
                    }
                default:
                    {
                        // 登録失敗
                        TMsgDisp.Show(
                            this,								// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOPDISP,	// エラーレベル
                            ASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
                            this.Text,							// プログラム名称
                            "SaveWarehouse",				    // 処理名称
                            TMsgDisp.OPE_UPDATE,				// オペレーション
                            "登録に失敗しました。",				// 表示するメッセージ 
                            status,								// ステータス値
                            this._goodsGroupUAcs,				// エラーが発生したオブジェクト
                            MessageBoxButtons.OK,				// 表示するボタン
                            MessageBoxDefaultButton.Button1);	// 初期表示ボタン

                        break;
                    }
            }

            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }

            this.DialogResult = DialogResult.Cancel;
            this._indexBuf = -2;

            if (CanClose == true)
            {
                this.Close();
            }
            else
            {
                this.Hide();
            }

            return (true);
        }

        /// <summary>
        /// 画面情報入力チェック処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面情報の入力チェックを行います。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/06/11</br>
        /// </remarks>
        private bool CheckScreenInput()
        {
            string errMsg = "";

            try
            {
                // 商品中分類コード
                if (this.tNedit_GoodsMGroup.DataText == "")
                {
                    errMsg = "商品中分類コードを入力してください。";
                    this.tNedit_GoodsMGroup.Focus();
                    return (false);
                }
                if (this._divisionCode == DIVISION_USR)
                {
                    // ユーザーデータの場合のみ9000以上かどうかチェック
                    if (this.tNedit_GoodsMGroup.GetInt() < 9000)
                    {
                        errMsg = "商品中分類コードは9000以上の数値を入力してください。";
                        this.tNedit_GoodsMGroup.Focus();
                        return (false);
                    }
                }

                //  商品中分類名称
                if (this.GoodsMGroupName_tEdit.DataText == "")
                {
                    errMsg = "商品中分類名称を入力してください。";
                    this.GoodsMGroupName_tEdit.Focus();
                    return (false);
                }
            }
            finally
            {
                if (errMsg.Length > 0)
                {
                    TMsgDisp.Show(
                    this, 								// 親ウィンドウフォーム
                    emErrorLevel.ERR_LEVEL_INFO, 		// エラーレベル
                    ASSEMBLY_ID, 						// アセンブリＩＤまたはクラスＩＤ
                    errMsg, 	                        // 表示するメッセージ
                    0, 									// ステータス値
                    MessageBoxButtons.OK);				// 表示するボタン
                }
            }

            return (true);
        }

        /// <summary>
        /// 画面情報比較処理
        /// </summary>
        /// <returns>ステータス(True:変更なし False:変更あり)</returns>
        /// <remarks>
        /// <br>Note       : 画面情報の比較を行います。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/06/11</br>
        /// </remarks>
        private bool CompareOriginalScreen()
        {
            GoodsGroupU goodsGroupU = new GoodsGroupU();
            goodsGroupU = this._goodsGroupUClone.Clone();

            // 画面情報取得
            ScreenToGoodsGroupU(ref goodsGroupU);

            // 最初に取得した画面情報と比較
            if (!(this._goodsGroupUClone.Equals(goodsGroupU)))
            {
                //画面情報が変更されていた場合
                return (false);
            }

            return (true);
        }

        #endregion Private Methods

        #region Control Events

        /// <summary>
        /// Form.Load イベント(PMKHN09070UA)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　 : ユーザーがフォームを読み込むときに発生します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/06/11</br>
        /// </remarks>
        private void PMKHN09070UA_Load(object sender, EventArgs e)
        {
            // アイコンリソース管理クラスを使用して、アイコンを表示する
            ImageList imageList24 = IconResourceManagement.ImageList24;
            ImageList imageList16 = IconResourceManagement.ImageList16;

            this.Ok_Button.Appearance.Image = imageList24.Images[(int)Size24_Index.SAVE];
            this.Cancel_Button.Appearance.Image = imageList24.Images[(int)Size24_Index.CLOSE];
            this.Revive_Button.Appearance.Image = imageList24.Images[(int)Size24_Index.REVIVAL];
            this.Delete_Button.Appearance.Image = imageList24.Images[(int)Size24_Index.DELETE];

            // コントロールサイズ設定
            SetControlSize();
        }

        /// <summary>
        /// Control.VisibleChanged イベント(PMKHN09070UA)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　 : フォームの表示状態が変わったときに発生します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/06/11</br>
        /// </remarks>
        private void PMKHN09070UA_VisibleChanged(object sender, EventArgs e)
        {
            this.Owner.Activate();

            // 自分自身が非表示になった場合は以下の処理をキャンセルする。
            if (this.Visible == false)
            {
                return;
            }

            // 画面クリア処理
            ScreenClear();

            Initial_Timer.Enabled = true;
        }

        /// <summary>
        /// Form.Closing イベント(PMKHN09070UA)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">キャンセルできるイベントのデータを提供するクラス</param>
        /// <remarks>
        /// <br>Note       : フォームを閉じる前に、ユーザーがフォームを閉じようとしたときに発生します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/06/11</br>
        /// </remarks>
        private void PMKHN09070UA_FormClosing(object sender, FormClosingEventArgs e)
        {
            this._indexBuf = -2;

            // フォームの「×」をクリックされた場合の対応です。
            if (CanClose == false)
            {
                e.Cancel = true;
                this.Hide();
            }
        }

        /// <summary>
        /// Timer.Tick イベント イベント(Initial_Timer)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　 : 指定された間隔の時間が経過したときに発生します。
        ///					 この処理は、システムが提供するスレッド プール
        ///					 スレッドで実行されます。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/06/11</br>
        /// </remarks>
        private void Initial_Timer_Tick(object sender, EventArgs e)
        {
            Initial_Timer.Enabled = false;

            // 画面再構築処理
            ScreenReconstruction();
        }

        /// <summary>
        /// Control.Click イベント(Ok_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　 : 保存ボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/06/11</br>
        /// </remarks>
        private void Ok_Button_Click(object sender, EventArgs e)
        {
            if ((this._divisionCode == DIVISION_OFR) && (CompareOriginalScreen() == true))
            {
                // 提供データ　かつ　画面情報未変更の場合
                if (UnDisplaying != null)
                {
                    MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                    UnDisplaying(this, me);
                }

                this.DialogResult = DialogResult.Cancel;
                this._indexBuf = -2;

                if (CanClose == true)
                {
                    this.Close();
                }
                else
                {
                    this.Hide();
                }
            }
            else
            {
                // 保存処理
                SaveProc();
            }
        }

        /// <summary>
        /// Control.Click イベント(Cancel_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　 : 閉じるボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/06/11</br>
        /// </remarks>
        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            // 削除モード以外の場合は保存確認処理を行う
            if (this.Mode_Label.Text != DELETE_MODE)
            {
                // 画面情報比較
                if (!CompareOriginalScreen())
                {
                    //画面情報が変更されていた場合は、保存確認メッセージを表示する
                    DialogResult res = TMsgDisp.Show(
                        this,								// 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_SAVECONFIRM,	// エラーレベル
                        ASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
                        "",									// 表示するメッセージ 
                        0,									// ステータス値
                        MessageBoxButtons.YesNoCancel);		// 表示するボタン

                    switch (res)
                    {
                        case DialogResult.Yes:
                            {
                                // 保存処理
                                if (SaveProc() != true)
                                {
                                    return;
                                }

                                this.DialogResult = DialogResult.OK;

                                break;
                            }
                        case DialogResult.No:
                            {
                                this.DialogResult = DialogResult.Cancel;

                                break;
                            }
                        default:
                            {
                                // 2009.03.27 30413 犬飼 新規モードからモード変更対応 >>>>>>START
                                //this.Cancel_Button.Focus();
                                if (_modeFlg)
                                {
                                    tNedit_GoodsMGroup.Focus();
                                    _modeFlg = false;
                                }
                                else
                                {
                                    this.Cancel_Button.Focus();
                                }
                                // 2009.03.27 30413 犬飼 新規モードからモード変更対応 <<<<<<END
                                return;
                            }
                    }
                }
            }

            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult);
                UnDisplaying(this, me);
            }

            this.DialogResult = DialogResult.Cancel;
            this._indexBuf = -2;

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
        /// Control.Click イベント(Delete_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　 : 完全削除ボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/06/11</br>
        /// </remarks>
        private void Delete_Button_Click(object sender, EventArgs e)
        {
            int status = 0;
            DialogResult result = TMsgDisp.Show(
                this,													// 親ウィンドウフォーム
                emErrorLevel.ERR_LEVEL_QUESTION,						// エラーレベル
                ASSEMBLY_ID,											// アセンブリＩＤまたはクラスＩＤ
                "データを削除します。" + "\r\n" + "よろしいですか？",	// 表示するメッセージ 
                0,														// ステータス値
                MessageBoxButtons.OKCancel,								// 表示するボタン
                MessageBoxDefaultButton.Button2);						// 初期表示ボタン


            if (result != DialogResult.OK)
            {
                this.Delete_Button.Focus();
                return;
            }

            // ハッシュキー作成
            string hashKey = CreateHashKey(this._dataIndex);

            GoodsGroupU goodsGroupU = ((GoodsGroupU)this._goodsGroupUTable[hashKey]).Clone();

            // 物理削除処理
            status = this._goodsGroupUAcs.Delete(goodsGroupU);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        this.Bind_DataSet.Tables[GOODSGROUPU_TABLE].Rows[this._dataIndex].Delete();

                        this._goodsGroupUTable.Remove(hashKey);

                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        // 排他処理
                        ExclusiveTransaction(status, false);

                        return;
                    }
                default:
                    {
                        TMsgDisp.Show(
                            this,								  // 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOPDISP,	  // エラーレベル
                            ASSEMBLY_ID,						  // アセンブリＩＤまたはクラスＩＤ
                            this.Text,							  // プログラム名称
                            "Delete_Button_Click",				  // 処理名称
                            TMsgDisp.OPE_DELETE,				  // オペレーション
                            "削除に失敗しました。",				  // 表示するメッセージ 
                            status,								  // ステータス値
                            this._goodsGroupUAcs,				  // エラーが発生したオブジェクト
                            MessageBoxButtons.OK,				  // 表示するボタン
                            MessageBoxDefaultButton.Button1);	  // 初期表示ボタン

                        return;
                    }
            }

            int totalCount = 0;

            // 再検索処理
            status = Search(ref totalCount, 0);

            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }

            this.DialogResult = DialogResult.OK;
            this._indexBuf = -2;

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
        /// Control.Click イベント(Revive_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　 : 復活ボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/06/11</br>
        /// </remarks>
        private void Revive_Button_Click(object sender, EventArgs e)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            // ハッシュキー作成
            string hashKey = CreateHashKey(this._dataIndex);

            GoodsGroupU goodsGroupU = ((GoodsGroupU)this._goodsGroupUTable[hashKey]).Clone();

            // 復活処理
            status = this._goodsGroupUAcs.Revival(ref goodsGroupU);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // DataSet展開処理
                        GoodsGroupUToDataSet(goodsGroupU, this._dataIndex);

                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        // 排他
                        ExclusiveTransaction(status, false);

                        return;
                    }
                default:
                    {
                        TMsgDisp.Show(
                            this,								  // 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOPDISP,	  // エラーレベル
                            ASSEMBLY_ID,						  // アセンブリＩＤまたはクラスＩＤ
                            this.Text,							  // プログラム名称
                            "Revive_Button_Click",				  // 処理名称
                            TMsgDisp.OPE_UPDATE,				  // オペレーション
                            "復活に失敗しました。",				　// 表示するメッセージ 
                            status,								  // ステータス値
                            this._goodsGroupUAcs,				  // エラーが発生したオブジェクト
                            MessageBoxButtons.OK,				  // 表示するボタン
                            MessageBoxDefaultButton.Button1);	  // 初期表示ボタン

                        return;
                    }
            }

            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }

            this.DialogResult = DialogResult.OK;
            this._indexBuf = -2;

            if (CanClose == true)
            {
                this.Close();
            }
            else
            {
                this.Hide();
            }
        }

        #endregion Control Events

        // 2009.03.27 30413 犬飼 新規モードからモード変更対応 >>>>>>START
        /// <summary>
        /// tRetKeyControl1_ChangeFocus イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        private void tRetKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null)
            {
                return;
            }

            _modeFlg = false;

            switch (e.PrevCtrl.Name)
            {
                case "tNedit_GoodsMGroup":
                    {
                        if (e.NextCtrl.Name == "Cancel_Button")
                        {
                            // 遷移先が閉じるボタン
                            _modeFlg = true;
                        }
                        else if (this._dataIndex < 0)
                        {
                            if (ModeChangeProc())
                            {
                                e.NextCtrl = tNedit_GoodsMGroup;
                            }
                        }
                        break;
                    }
            }
        }

        /// <summary>
        /// モード変更処理
        /// </summary>
        private bool ModeChangeProc()
        {
            // 商品中分類コード
            int goodsMGroup = tNedit_GoodsMGroup.GetInt();

            for (int i = 0; i < this.Bind_DataSet.Tables[GOODSGROUPU_TABLE].Rows.Count; i++)
            {
                // データセットと比較
                int dsGoodsMGroup = (int)this.Bind_DataSet.Tables[GOODSGROUPU_TABLE].Rows[i][GOODSMGROUPCODE_TITLE];
                if (goodsMGroup == dsGoodsMGroup)
                {
                    // 入力コードがデータセットに存在する場合
                    if ((string)this.Bind_DataSet.Tables[GOODSGROUPU_TABLE].Rows[i][DELETE_DATE_TITLE] != "")
                    {
                        // 論理削除
                        TMsgDisp.Show(this, 					// 親ウィンドウフォーム
                          emErrorLevel.ERR_LEVEL_INFO,          // エラーレベル
                          ASSEMBLY_ID,						    // アセンブリＩＤまたはクラスＩＤ
                          "入力されたコードの商品中分類マスタ情報は既に削除されています。", 			// 表示するメッセージ
                          0, 									// ステータス値
                          MessageBoxButtons.OK);				// 表示するボタン
                        // 商品中分類コードのクリア
                        tNedit_GoodsMGroup.Clear();
                        return true;
                    }

                    DialogResult res = TMsgDisp.Show(
                        this,                                   // 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_INFO,            // エラーレベル
                        ASSEMBLY_ID,                            // アセンブリＩＤまたはクラスＩＤ
                        "入力されたコードの商品中分類マスタ情報が既に登録されています。\n編集を行いますか？",   // 表示するメッセージ
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
                                // 商品中分類コードのクリア
                                tNedit_GoodsMGroup.Clear();
                                break;
                            }
                    }
                    return true;
                }
            }
            return false;
        }
        // 2009.03.27 30413 犬飼 新規モードからモード変更対応 <<<<<<END
    }
}