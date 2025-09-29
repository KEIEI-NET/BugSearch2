using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.Collections;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;

using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Microsoft.VisualBasic;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// BLグループマスタ設定フォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note		: BLグループマスタの設定を行います。
    ///					  IMasterMaintenanceMultiTypeを実装しています。</br>
    /// <br>Programmer	: 30414 忍　幸史</br>
    /// <br>Date		: 2008/06/11</br>
    /// <br>UpdateNote   : 2008/10/07 30462 行澤 仁美　バグ修正</br>
    /// <br>UpdateNote   : 2008/10/20       照田 貴志　バグ修正、仕様変更対応</br>
    /// </remarks>
    public partial class PMKHN09060UA : Form, IMasterMaintenanceMultiType
    {
        #region Constants

        // 編集モード
        private const string INSERT_MODE = "新規モード";
        private const string UPDATE_MODE = "更新モード";
        private const string DELETE_MODE = "削除モード";

        // テーブル名称
        private const string BLGROUPU_TABLE = "BLGroupU";

        // FremのView用Grid列のKEY情報 (ヘッダのタイトル部となります)
        private const string DELETE_DATE_TITLE      = "削除日";
        private const string BLGROUPCODE_TITLE      = "ｸﾞﾙｰﾌﾟｺｰﾄﾞ";
        private const string BLGROUPNAME_TITLE      = "ｸﾞﾙｰﾌﾟｺｰﾄﾞ名";
        private const string BLGROUPHALFNAME_TITLE  = "ｸﾞﾙｰﾌﾟｺｰﾄﾞ名(ｶﾅ)";
        private const string GOODSLGROUPCODE_TITLE  = "商品大分類コード";
        private const string GOODSLGROUPNAME_TITLE  = "商品大分類名";
        private const string GOODSMGROUPCODE_TITLE  = "商品中分類コード";
        private const string GOODSMGROUPNAME_TITLE  = "商品中分類名";
        private const string SALESCODE_TITLE        = "販売区分コード";
        private const string SALESCODENAME_TITLE    = "販売区分名";
        private const string DIVISION_TITLE         = "データ区分コード";
        private const string DIVISIONNAME_TITLE     = "データ区分";
        private const string GUID_TITLE             = "Guid";

        // プログラムID
        private const string ASSEMBLY_ID = "PMKHN09060U";

        //データ区分
        private const int DIVISION_USR = 0;
        private const int DIVISION_OFR = 1;

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

        // BLグループマスタアクセスクラス
        private BLGroupUAcs _bLGroupUAcs;

        // ユーザーガイドマスタアクセスクラス
        private UserGuideAcs _userGuideAcs;

        private Hashtable _bLGroupUTable;

        private int _indexBuf;

        // データ区分(0:ユーザー 1:提供)
        private int _offerDataDiv;

        // 終了時の編集チェック用
        private BLGroupU _bLGroupUClone;

        private GoodsGroupUAcs _goodsGroupUAcs;

        private Dictionary<int, UserGdBd> _goodsLGroupDic;
        private Dictionary<int, GoodsGroupU> _goodsGroupDic;
        private Dictionary<int, UserGdBd> _salesCodeDic;

        // 2009.03.27 30413 犬飼 新規モードからモード変更対応 >>>>>>START
        // モードフラグ(true：コード、false：コード以外)
        private bool _modeFlg = false;
        // 2009.03.27 30413 犬飼 新規モードからモード変更対応 <<<<<<END
		
        #endregion Private Members

        #region Constructor

        /// <summary>
        /// BLグループマスタ設定フォームクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : フォームクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date	   : 2008/06/11</br>
        /// </remarks>
        public PMKHN09060UA()
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
            this._bLGroupUAcs = new BLGroupUAcs();
            this._userGuideAcs = new UserGuideAcs();
            this._bLGroupUTable = new Hashtable();

            // GridIndexバッファ（メインフレーム最小化対応）
            this._indexBuf = -2;

            this._goodsGroupUAcs = new GoodsGroupUAcs();

            // 各種マスタ読込
            ReadGoodsLGroup();
            ReadGoodsMGroup();
            ReadSalesCode();
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
            appearanceTable.Add(BLGROUPCODE_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            appearanceTable.Add(BLGROUPNAME_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(BLGROUPHALFNAME_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(GOODSLGROUPCODE_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            appearanceTable.Add(GOODSLGROUPNAME_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(GOODSMGROUPCODE_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            appearanceTable.Add(GOODSMGROUPNAME_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(SALESCODE_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            appearanceTable.Add(SALESCODENAME_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
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
            tableName = BLGROUPU_TABLE;
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
        /// </remarks>
        public int Delete()
        {
            // DEL 2008/10/07 不具合対応[6307] ---------->>>>>
            //if (this._offerDataDiv == DIVISION_OFR)
            //{
            //    // 提供データ削除不可
            //    TMsgDisp.Show(
            //        this, 								// 親ウィンドウフォーム
            //        emErrorLevel.ERR_LEVEL_INFO, 		// エラーレベル
            //        ASSEMBLY_ID, 						// アセンブリＩＤまたはクラスＩＤ
            //        "提供データは削除できません。", 	// 表示するメッセージ
            //        0, 									// ステータス値
            //        MessageBoxButtons.OK);				// 表示するボタン
            //    return 0;
            //}
            // DEL 2008/10/07 不具合対応[6307] ----------<<<<<

            // ハッシュキー作成
            string hashKey = CreateHashKey(this._dataIndex);

            BLGroupU blGroupU = new BLGroupU();
            blGroupU = (BLGroupU)this._bLGroupUTable[hashKey];

            //--- ADD 2008/10/20 ※不具合[6307]の戻り対応----------------------------->>>>>
            // 提供データの削除は不可
            if (blGroupU.OfferDataDiv == DIVISION_OFR)
            {
                TMsgDisp.Show(
                    this, 								// 親ウィンドウフォーム
                    emErrorLevel.ERR_LEVEL_INFO, 		// エラーレベル
                    ASSEMBLY_ID, 						// アセンブリＩＤまたはクラスＩＤ
                    "提供データは削除できません。", 	// 表示するメッセージ
                    0, 									// ステータス値
                    MessageBoxButtons.OK);				// 表示するボタン
                return 0;
            }
            //--- ADD 2008/10/20 -----------------------------------------------------<<<<<

            // 論理削除処理
            int status = this._bLGroupUAcs.LogicalDelete(ref blGroupU);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // データセット展開
                        BLGroupUToDataSet(blGroupU.Clone(), this._dataIndex);
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
                            this._bLGroupUAcs, 				    // エラーが発生したオブジェクト
                            MessageBoxButtons.OK, 				// 表示するボタン
                            MessageBoxDefaultButton.Button1);	// 初期表示ボタン
                        break;
                    }
            }

            return status;
        }

        /// <summary>
        /// BLグループ検索処理
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
                this.Bind_DataSet.Tables[BLGROUPU_TABLE].Rows.Clear();
                this._bLGroupUTable.Clear();

                ArrayList retList = new ArrayList();

                // 検索処理
                status = this._bLGroupUAcs.SearchAll(out retList, this._enterpriseCode);
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:

                        int index = 0;
                        foreach (BLGroupU bLGroupU in retList)
                        {
                            // ハッシュキー作成
                            string hashKey = CreateHashKey(bLGroupU);

                            if (this._bLGroupUTable.ContainsKey(hashKey) == false)
                            {
                                // データセット展開
                                BLGroupUToDataSet(bLGroupU.Clone(), index);
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
                            this._bLGroupUAcs, 				    // エラーが発生したオブジェクト
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
                    this._bLGroupUAcs,				      // エラーが発生したオブジェクト
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
        /// <param name="blGroupU">BLグループマスタオブジェクト</param>
        /// <returns>キー</returns>
        /// <remarks>
        /// <br>Note       : ハッシュテーブル用のキーを作成します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/06/11</br>
        /// </remarks>
        private string CreateHashKey(BLGroupU blGroupU)
        {
            string hashKey = blGroupU.BLGroupCode.ToString().PadLeft(5, '0') + blGroupU.OfferDataDiv.ToString();

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
        /// </remarks>
        private string CreateHashKey(int dataIndex)
        {
            int bLGroupCode = int.Parse((string)this.Bind_DataSet.Tables[BLGROUPU_TABLE].Rows[dataIndex][BLGROUPCODE_TITLE]);
            int divisionCode = (int)this.Bind_DataSet.Tables[BLGROUPU_TABLE].Rows[dataIndex][DIVISION_TITLE];
            string hashKey = bLGroupCode.ToString().PadLeft(5, '0') + divisionCode.ToString();

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
            DataTable dataTable = new DataTable(BLGROUPU_TABLE);

            // Addを行う順番が、列の表示順位となります。
            dataTable.Columns.Add(DELETE_DATE_TITLE, typeof(string));
            dataTable.Columns.Add(BLGROUPCODE_TITLE, typeof(string));
            dataTable.Columns.Add(BLGROUPNAME_TITLE, typeof(string));
            dataTable.Columns.Add(BLGROUPHALFNAME_TITLE, typeof(string));
            dataTable.Columns.Add(GOODSLGROUPCODE_TITLE, typeof(string));
            dataTable.Columns.Add(GOODSLGROUPNAME_TITLE, typeof(string));
            dataTable.Columns.Add(GOODSMGROUPCODE_TITLE, typeof(string));
            dataTable.Columns.Add(GOODSMGROUPNAME_TITLE, typeof(string));
            dataTable.Columns.Add(SALESCODE_TITLE, typeof(string));
            dataTable.Columns.Add(SALESCODENAME_TITLE, typeof(string));
            dataTable.Columns.Add(DIVISION_TITLE, typeof(int));
            dataTable.Columns.Add(DIVISIONNAME_TITLE, typeof(string));
            dataTable.Columns.Add(GUID_TITLE, typeof(Guid));

            this.Bind_DataSet.Tables.Add(dataTable);
        }

        /// <summary>
        /// ユーザーガイド表示処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : ユーザーガイドを表示します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/06/11</br>
        /// </remarks>
        private int ShowUserGuide(out UserGdBd userGdBd, int userGuideDivCd)
        {
            int status;
            UserGdHd userGdHd = new UserGdHd();

            userGdBd = new UserGdBd();

            status = this._userGuideAcs.ExecuteGuid(this._enterpriseCode, out userGdHd, out userGdBd, userGuideDivCd);

            return status;
        }

        /// <summary>
        /// ユーザーガイドデータ取得処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : ユーザーガイドデータを取得します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/06/11</br>
        /// </remarks>
        private int GetUserGuideBd(out ArrayList retList, int userGuideDivCd)
        {
            int status;
            retList = new ArrayList();

            status = this._userGuideAcs.SearchAllDivCodeBody(out retList, this._enterpriseCode, 
                                                             userGuideDivCd, UserGuideAcsData.UserBodyData);

            return status;
        }

        /// <summary>
        /// 商品大分類読込処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 商品大分類一覧を読み込みます。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/06/11</br>
        /// </remarks>
        private void ReadGoodsLGroup()
        {
            this._goodsLGroupDic = new Dictionary<int, UserGdBd>();

            ArrayList retList;

            // ユーザーガイドデータ取得(商品大分類)
            int status = GetUserGuideBd(out retList, 70);
            if (status == 0)
            {
                foreach (UserGdBd userGdBd in retList)
                {
                    if (userGdBd.LogicalDeleteCode == 0)
                    {
                        this._goodsLGroupDic.Add(userGdBd.GuideCode, userGdBd);
                    }
                }
            }

            return;
        }

        /// <summary>
        /// 商品大分類名称取得処理
        /// </summary>
        /// <param name="goodsLGroupCode">商品大分類コード</param>
        /// <remarks>
        /// <br>Note       : 商品大分類名称を取得します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/06/11</br>
        /// </remarks>
        private string GetGoodsLGroupName(int goodsLGroupCode)
        {
            string goodsLGroupName = "";

            if (this._goodsLGroupDic.ContainsKey(goodsLGroupCode))
            {
                goodsLGroupName = this._goodsLGroupDic[goodsLGroupCode].GuideName.Trim();
            }

            return goodsLGroupName;
        }

        /// <summary>
        /// 商品中分類読込処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 商品中分類一覧を読み込みます。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/06/11</br>
        /// </remarks>
        private void ReadGoodsMGroup()
        {
            this._goodsGroupDic = new Dictionary<int, GoodsGroupU>();

            ArrayList retList;

            int status = this._goodsGroupUAcs.SearchAll(out retList, this._enterpriseCode);
            if (status == 0)
            {
                foreach (GoodsGroupU goodsGroupU in retList)
                {
                    if (goodsGroupU.LogicalDeleteCode == 0)
                    {
                        this._goodsGroupDic.Add(goodsGroupU.GoodsMGroup, goodsGroupU);
                    }
                }
            }

            return;
        }

        /// <summary>
        /// 商品中分類名称取得処理
        /// </summary>
        /// <param name="goodsMGroupCode">商品中分類コード</param>
        /// <remarks>
        /// <br>Note       : 商品中分類名称を取得します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/06/11</br>
        /// </remarks>
        private string GetGoodsMGroupName(int goodsMGroupCode)
        {
            string goodsMGroupName = "";

            if (this._goodsGroupDic.ContainsKey(goodsMGroupCode))
            {
                goodsMGroupName = this._goodsGroupDic[goodsMGroupCode].GoodsMGroupName.Trim();
            }

            return goodsMGroupName;
        }

        /// <summary>
        /// 販売区分読込処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 販売区分一覧を読み込みます。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/06/11</br>
        /// </remarks>
        private void ReadSalesCode()
        {
            this._salesCodeDic = new Dictionary<int, UserGdBd>();

            ArrayList retList;

            // ユーザーガイドデータ取得(販売区分)
            int status = GetUserGuideBd(out retList, 71);
            if (status == 0)
            {
                foreach (UserGdBd userGdBd in retList)
                {
                    if (userGdBd.LogicalDeleteCode == 0)
                    {
                        this._salesCodeDic.Add(userGdBd.GuideCode, userGdBd);
                    }
                }
            }

            return;
        }

        /// <summary>
        /// 販売区分名称取得処理
        /// </summary>
        /// <param name="salesCode">販売区分コード</param>
        /// <remarks>
        /// <br>Note       : 販売区分名称を取得します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/06/11</br>
        /// </remarks>
        private string GetSalesCodeName(int salesCode)
        {
            string salesCodeName = "";

            if (this._salesCodeDic.ContainsKey(salesCode))
            {
                salesCodeName = this._salesCodeDic[salesCode].GuideName.Trim();
            }

            return salesCodeName;
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
            this.tNedit_BLGloupCode.Size = new Size(52, 24);
            this.BLGroupName_tEdit.Size = new Size(337, 24);
            this.BLGroupHalfName_tEdit.Size = new Size(337, 24);
            this.tNedit_GoodsLGroup.Size = new Size(52, 24);
            this.GoodsLGroupName_tEdit.Size = new Size(337, 24);
            this.tNedit_GoodsMGroup.Size = new Size(52, 24);
            this.GoodsMGroupName_tEdit.Size = new Size(337, 24);
            this.tNedit_SalesCode.Size = new Size(52, 24);
            this.SalesCodeName_tEdit.Size = new Size(337, 24);
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

            this.tNedit_BLGloupCode.Clear();
            this.BLGroupName_tEdit.Clear();
            this.tNedit_GoodsLGroup.Clear();
            this.GoodsLGroupName_tEdit.Clear();
            this.tNedit_GoodsMGroup.Clear();
            this.GoodsMGroupName_tEdit.Clear();
            this.tNedit_SalesCode.Clear();
            this.SalesCodeName_tEdit.Clear();
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

                    this.tNedit_BLGloupCode.Enabled = true;
                    this.BLGroupName_tEdit.Enabled = true;
                    this.BLGroupHalfName_tEdit.Enabled = true;      // ADD 2008/10/07 不具合対応[6306]
                    this.tNedit_GoodsLGroup.Enabled = true;
                    this.tNedit_GoodsMGroup.Enabled = true;
                    this.tNedit_SalesCode.Enabled = true;

                    this.GoodsLGroupGuide_Button.Enabled = true;
                    this.GoodsMGroupGuide_Button.Enabled = true;
                    this.SalesCodeGuide_Button.Enabled = true;

                    this.Ok_Button.Enabled = true;
                    this.Renewal_Button.Enabled = true;
                    this.Cancel_Button.Enabled = true;
                    this.Revive_Button.Enabled = false;
                    this.Delete_Button.Enabled = false;

                    this.Ok_Button.Visible = true;
                    this.Renewal_Button.Visible = true;
                    this.Cancel_Button.Visible = true;
                    this.Revive_Button.Visible = false;
                    this.Delete_Button.Visible = false;

                    break;
                // 更新モード
                case UPDATE_MODE:

                    this.tNedit_BLGloupCode.Enabled = false;
                    this.BLGroupName_tEdit.Enabled = true;
                    this.BLGroupHalfName_tEdit.Enabled = true;      // ADD 2008/10/07 不具合対応[6306]
                    this.tNedit_GoodsLGroup.Enabled = true;
                    this.tNedit_GoodsMGroup.Enabled = true;
                    this.tNedit_SalesCode.Enabled = true;

                    this.GoodsLGroupGuide_Button.Enabled = true;
                    this.GoodsMGroupGuide_Button.Enabled = true;
                    this.SalesCodeGuide_Button.Enabled = true;

                    this.Ok_Button.Enabled = true;
                    this.Renewal_Button.Enabled = true;
                    this.Cancel_Button.Enabled = true;
                    this.Revive_Button.Enabled = false;
                    this.Delete_Button.Enabled = false;

                    this.Ok_Button.Visible = true;
                    this.Renewal_Button.Visible = true;
                    this.Cancel_Button.Visible = true;
                    this.Revive_Button.Visible = false;
                    this.Delete_Button.Visible = false;

                    break;
                // 削除モード
                case DELETE_MODE:

                    this.tNedit_BLGloupCode.Enabled = false;
                    this.BLGroupName_tEdit.Enabled = false;
                    this.BLGroupHalfName_tEdit.Enabled = false;      // ADD 2008/10/07 不具合対応[6306]
                    this.tNedit_GoodsLGroup.Enabled = false;
                    this.tNedit_GoodsMGroup.Enabled = false;
                    this.tNedit_SalesCode.Enabled = false;

                    this.GoodsLGroupGuide_Button.Enabled = false;
                    this.GoodsMGroupGuide_Button.Enabled = false;
                    this.SalesCodeGuide_Button.Enabled = false;

                    this.Ok_Button.Enabled = false;
                    this.Renewal_Button.Enabled = false;
                    this.Cancel_Button.Enabled = true;
                    this.Revive_Button.Enabled = true;
                    this.Delete_Button.Enabled = true;

                    this.Ok_Button.Visible = false;
                    this.Renewal_Button.Visible = false;
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
                            this._bLGroupUAcs, 				    // エラーが発生したオブジェクト
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
                            this._bLGroupUAcs, 				    // エラーが発生したオブジェクト
                            MessageBoxButtons.OK, 				// 表示するボタン
                            MessageBoxDefaultButton.Button1);	// 初期表示ボタン
                        break;
                    }
            }
        }

        /// <summary>
        /// BLグループ設定オブジェクトデータセット展開処理
        /// </summary>
        /// <param name="bLGroupU">BLグループ設定オブジェクト</param>
        /// <param name="index">データセットへ展開するインデックス</param>
        /// <remarks>
        /// <br>Note       : BLグループ設定クラスをデータセットに格納します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/06/11</br>
        /// </remarks>
        private void BLGroupUToDataSet(BLGroupU bLGroupU, int index)
        {
            if ((index < 0) || (this.Bind_DataSet.Tables[BLGROUPU_TABLE].Rows.Count <= index))
            {
                // 新規と判断して、行を追加する
                DataRow dataRow = this.Bind_DataSet.Tables[BLGROUPU_TABLE].NewRow();
                this.Bind_DataSet.Tables[BLGROUPU_TABLE].Rows.Add(dataRow);

                // indexを行の最終行番号する
                index = this.Bind_DataSet.Tables[BLGROUPU_TABLE].Rows.Count - 1;
            }

            // 論理削除区分
            if (bLGroupU.LogicalDeleteCode == 0)
            {
                this.Bind_DataSet.Tables[BLGROUPU_TABLE].Rows[index][DELETE_DATE_TITLE] = "";
            }
            else
            {
                this.Bind_DataSet.Tables[BLGROUPU_TABLE].Rows[index][DELETE_DATE_TITLE] = bLGroupU.UpdateDateTimeJpInFormal;
            }

            // BLｸﾞﾙｰﾌﾟｺｰﾄﾞ
            this.Bind_DataSet.Tables[BLGROUPU_TABLE].Rows[index][BLGROUPCODE_TITLE] = bLGroupU.BLGroupCode.ToString("00000");

            // BLグループ名称
            this.Bind_DataSet.Tables[BLGROUPU_TABLE].Rows[index][BLGROUPNAME_TITLE] = bLGroupU.BLGroupName;

            // BLグループ名称(カナ)
            this.Bind_DataSet.Tables[BLGROUPU_TABLE].Rows[index][BLGROUPHALFNAME_TITLE] = bLGroupU.BLGroupKanaName;

            // 商品大分類コード
            if (bLGroupU.GoodsLGroup == 0)
            {
                this.Bind_DataSet.Tables[BLGROUPU_TABLE].Rows[index][GOODSLGROUPCODE_TITLE] = DBNull.Value;
            }
            else
            {
                this.Bind_DataSet.Tables[BLGROUPU_TABLE].Rows[index][GOODSLGROUPCODE_TITLE] = bLGroupU.GoodsLGroup.ToString("0000");
            }

            // 商品大分類名称
            this.Bind_DataSet.Tables[BLGROUPU_TABLE].Rows[index][GOODSLGROUPNAME_TITLE] = GetGoodsLGroupName(bLGroupU.GoodsLGroup);

            // 商品中分類コード
            if (bLGroupU.GoodsMGroup == 0)
            {
                this.Bind_DataSet.Tables[BLGROUPU_TABLE].Rows[index][GOODSMGROUPCODE_TITLE] = DBNull.Value;
            }
            else
            {
                this.Bind_DataSet.Tables[BLGROUPU_TABLE].Rows[index][GOODSMGROUPCODE_TITLE] = bLGroupU.GoodsMGroup.ToString("0000");
            }

            // 商品中分類名称
            this.Bind_DataSet.Tables[BLGROUPU_TABLE].Rows[index][GOODSMGROUPNAME_TITLE] = GetGoodsMGroupName(bLGroupU.GoodsMGroup);

            // 販売区分コード
            if (bLGroupU.SalesCode == 0)
            {
                this.Bind_DataSet.Tables[BLGROUPU_TABLE].Rows[index][SALESCODE_TITLE] = DBNull.Value;
            }
            else
            {
                this.Bind_DataSet.Tables[BLGROUPU_TABLE].Rows[index][SALESCODE_TITLE] = bLGroupU.SalesCode.ToString("0000");
            }

            // 販売区分名称
            this.Bind_DataSet.Tables[BLGROUPU_TABLE].Rows[index][SALESCODENAME_TITLE] = GetSalesCodeName(bLGroupU.SalesCode);
            // データ区分コード
            this.Bind_DataSet.Tables[BLGROUPU_TABLE].Rows[index][DIVISION_TITLE] = bLGroupU.OfferDataDiv;

            // データ区分名称
            this.Bind_DataSet.Tables[BLGROUPU_TABLE].Rows[index][DIVISIONNAME_TITLE] = bLGroupU.OfferDataDivName;
            
            // GUID
            this.Bind_DataSet.Tables[BLGROUPU_TABLE].Rows[index][GUID_TITLE] = bLGroupU.FileHeaderGuid;

            // ハッシュキー作成
            string hashKey = CreateHashKey(bLGroupU);

            // ハッシュテーブル更新
            if (this._bLGroupUTable.ContainsKey(hashKey) == true)
            {
                this._bLGroupUTable.Remove(hashKey);
            }
            this._bLGroupUTable.Add(hashKey, bLGroupU);
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
            BLGroupU blGroupU = new BLGroupU();

            // 新規の場合
            if (this._dataIndex < 0)
            {
                // 新規モード
                this.Mode_Label.Text = INSERT_MODE;

                // データ区分
                this._offerDataDiv = DIVISION_USR;

                // 画面入力許可制御処理
                ScreenInputPermissionControl(INSERT_MODE);

                // 画面展開処理
                BLGroupUToScreen(blGroupU);

                // クローン作成
                this._bLGroupUClone = blGroupU.Clone();

                // 画面情報格納処理
                ScreenToBLGroupU(ref this._bLGroupUClone);

                // フォーカス設定
                this.tNedit_BLGloupCode.Focus();
            }
            else
            {
                // ハッシュキー作成
                string hashKey = CreateHashKey(this._dataIndex);

                blGroupU = (BLGroupU)this._bLGroupUTable[hashKey];

                // データ区分
                this._offerDataDiv = blGroupU.OfferDataDiv;

                // 削除の場合
                if ((string)this.Bind_DataSet.Tables[BLGROUPU_TABLE].Rows[this._dataIndex][DELETE_DATE_TITLE] != "")
                {
                    // 削除モード
                    this.Mode_Label.Text = DELETE_MODE;

                    // 画面入力許可制御処理
                    ScreenInputPermissionControl(DELETE_MODE);

                    // 画面展開処理
                    BLGroupUToScreen(blGroupU);

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
                    BLGroupUToScreen(blGroupU);

                    // クローン作成
                    this._bLGroupUClone = blGroupU.Clone();

                    // 画面情報格納処理
                    ScreenToBLGroupU(ref this._bLGroupUClone);

                    // フォーカス設定
                    this.BLGroupName_tEdit.Focus();
                }
            }

            // _indexBufバッファ保持
            this._indexBuf = this._dataIndex;
        }

        /// <summary>
        /// BLグループ設定クラス画面展開処理
        /// </summary>
        /// <param name="blGroupU">BLグループ設定オブジェクト</param>
        /// <remarks>
        /// <br>Note       : オブジェクトから画面にデータを展開します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/06/11</br>
        /// </remarks>
        private void BLGroupUToScreen(BLGroupU blGroupU)
        {
            // BLｸﾞﾙｰﾌﾟｺｰﾄﾞ
            if (blGroupU.BLGroupCode == 0)
            {
                this.tNedit_BLGloupCode.Clear();
            }
            else
            {
                this.tNedit_BLGloupCode.SetInt(blGroupU.BLGroupCode);
            }

            // BLグループ名称
            this.BLGroupName_tEdit.DataText = blGroupU.BLGroupName.Trim();

            // BLグループ名称(カナ)
            this.BLGroupHalfName_tEdit.DataText = blGroupU.BLGroupKanaName.Trim();

            // 商品大分類コード
            if (blGroupU.GoodsLGroup == 0)
            {
                this.tNedit_GoodsLGroup.Clear();
            }
            else
            {
                this.tNedit_GoodsLGroup.SetInt(blGroupU.GoodsLGroup);
            }

            // 商品大分類名称
            this.GoodsLGroupName_tEdit.DataText = GetGoodsLGroupName(blGroupU.GoodsLGroup);

            // 商品中分類コード
            if (blGroupU.GoodsMGroup == 0)
            {
                this.tNedit_GoodsMGroup.Clear();
            }
            else
            {
                this.tNedit_GoodsMGroup.SetInt(blGroupU.GoodsMGroup);
            }

            // 商品中分類名称
            this.GoodsMGroupName_tEdit.DataText = GetGoodsMGroupName(blGroupU.GoodsMGroup);

            // 販売区分コード
            if (blGroupU.SalesCode == 0)
            {
                this.tNedit_SalesCode.Clear();
            }
            else
            {
                this.tNedit_SalesCode.SetInt(blGroupU.SalesCode);
            }

            // 販売区分名称
            this.SalesCodeName_tEdit.DataText = GetSalesCodeName(blGroupU.SalesCode);
        }

        /// <summary>
        /// 画面情報BLグループ設定クラス格納処理
        /// </summary>
        /// <param name="blGroupU">BLグループ設定オブジェクト</param>
        /// <remarks>
        /// <br>Note       : 画面情報からBLグループ設定オブジェクトにデータを格納します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/06/11</br>
        /// </remarks>
        private void ScreenToBLGroupU(ref BLGroupU blGroupU)
        {
            // 企業コード
            blGroupU.EnterpriseCode = this._enterpriseCode;

            // BLｸﾞﾙｰﾌﾟｺｰﾄﾞ
            blGroupU.BLGroupCode = this.tNedit_BLGloupCode.GetInt();

            // BLグループ名称
            blGroupU.BLGroupName = this.BLGroupName_tEdit.DataText.Trim();

            // BLグループ名称(カナ)
            blGroupU.BLGroupKanaName = this.BLGroupHalfName_tEdit.DataText.Trim();

            // 商品大分類コード
            blGroupU.GoodsLGroup = this.tNedit_GoodsLGroup.GetInt();

            // 商品中分類コード
            blGroupU.GoodsMGroup = this.tNedit_GoodsMGroup.GetInt();

            // 販売区分コード
            blGroupU.SalesCode = this.tNedit_SalesCode.GetInt();
        }

        /// <summary>
        /// BLグループ設定マスタ保存処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : BLグループ設定マスタを保存します。</br>
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

            BLGroupU bLGroupU = new BLGroupU();

            // 登録レコード情報取得
            if (this._indexBuf >= 0)
            {
                // ハッシュキー作成
                string hashKey = CreateHashKey(this._dataIndex);

                bLGroupU = ((BLGroupU)this._bLGroupUTable[hashKey]).Clone();
            }

            // 画面情報格納
            ScreenToBLGroupU(ref bLGroupU);

            // 保存処理
            int status = this._bLGroupUAcs.Write(ref bLGroupU);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // DataSet/Hash更新処理
                        BLGroupUToDataSet(bLGroupU, this._indexBuf);

                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE:
                    {
                        TMsgDisp.Show(
                        this, 										        // 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_INFO, 				        // エラーレベル
                        ASSEMBLY_ID, 								        // アセンブリＩＤまたはクラスＩＤ
                        "このｸﾞﾙｰﾌﾟｺｰﾄﾞは既に使用されています。", 	// 表示するメッセージ
                        0, 											        // ステータス値
                        MessageBoxButtons.OK);						        // 表示するボタン

                        this.tNedit_BLGloupCode.Focus();

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
                            this._bLGroupUAcs,				    // エラーが発生したオブジェクト
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
                // BLｸﾞﾙｰﾌﾟｺｰﾄﾞ
                if ((this.tNedit_BLGloupCode.DataText == "") || (this.tNedit_BLGloupCode.GetInt() == 0))
                {
                    errMsg = "ｸﾞﾙｰﾌﾟｺｰﾄﾞを入力してください。";
                    this.tNedit_BLGloupCode.Focus();
                    return (false);
                }
                if (this._offerDataDiv == DIVISION_USR)
                {
                    // ユーザーデータの場合のみ9000以上かどうかチェック
                    if (this.tNedit_BLGloupCode.GetInt() < 9000)
                    {
                        errMsg = "ｸﾞﾙｰﾌﾟｺｰﾄﾞは9000以上の数値を入力してください。";
                        this.tNedit_BLGloupCode.Focus();
                        return (false);
                    }
                }

                // BLグループ名称
                if (this.BLGroupName_tEdit.DataText.Trim() == "")
                {
                    errMsg = "ｸﾞﾙｰﾌﾟｺｰﾄﾞ名を入力してください。";
                    this.BLGroupName_tEdit.Focus();
                    return (false);
                }

                // BLグループ名称(カナ)
                if (this.BLGroupHalfName_tEdit.DataText.Trim() == "")
                {
                    errMsg = "ｸﾞﾙｰﾌﾟｺｰﾄﾞ名(ｶﾅ)を入力してください。";
                    this.BLGroupHalfName_tEdit.Focus();
                    return (false);
                }

                // 商品大分類
                if (this.tNedit_GoodsLGroup.DataText != "")
                {
                    if (GetGoodsLGroupName(this.tNedit_GoodsLGroup.GetInt()) == "")
                    {
                        errMsg = "マスタに登録されていません。";
                        this.tNedit_GoodsLGroup.Focus();
                        return (false);
                    }
                }

                // 商品中分類
                if (this.tNedit_GoodsMGroup.DataText != "")
                {
                    if (GetGoodsMGroupName(this.tNedit_GoodsMGroup.GetInt()) == "")
                    {
                        errMsg = "マスタに登録されていません。";
                        this.tNedit_GoodsMGroup.Focus();
                        return (false);
                    }
                }

                // 販売区分
                if (this.tNedit_SalesCode.DataText != "")
                {
                    if (GetSalesCodeName(this.tNedit_SalesCode.GetInt()) == "")
                    {
                        errMsg = "マスタに登録されていません。";
                        this.tNedit_SalesCode.Focus();
                        return (false);
                    }
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
            BLGroupU bLGroupU = new BLGroupU();
            bLGroupU = this._bLGroupUClone.Clone();

            // 画面情報取得
            ScreenToBLGroupU(ref bLGroupU);

            // 最初に取得した画面情報と比較
            if (!(this._bLGroupUClone.Equals(bLGroupU)))
            {
                //画面情報が変更されていた場合
                return (false);
            }

            return (true);
        }

        #endregion Private Methods

        #region Control Events

        /// <summary>
        /// Form.Load イベント(PMKHN09060UA)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　 : ユーザーがフォームを読み込むときに発生します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/06/11</br>
        /// </remarks>
        private void PMKHN09060UA_Load(object sender, EventArgs e)
        {
            // アイコンリソース管理クラスを使用して、アイコンを表示する
            ImageList imageList24 = IconResourceManagement.ImageList24;
            ImageList imageList16 = IconResourceManagement.ImageList16;

            this.Ok_Button.Appearance.Image = imageList24.Images[(int)Size24_Index.SAVE];
            this.Cancel_Button.Appearance.Image = imageList24.Images[(int)Size24_Index.CLOSE];
            this.Revive_Button.Appearance.Image = imageList24.Images[(int)Size24_Index.REVIVAL];
            this.Delete_Button.Appearance.Image = imageList24.Images[(int)Size24_Index.DELETE];
            this.GoodsLGroupGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.GoodsMGroupGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.SalesCodeGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.Renewal_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.RENEWAL];

            // コントロールサイズ設定
            SetControlSize();
        }

        /// <summary>
        /// Control.VisibleChanged イベント(PMKHN09060UA)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　 : フォームの表示状態が変わったときに発生します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/06/11</br>
        /// </remarks>
        private void PMKHN09060UA_VisibleChanged(object sender, EventArgs e)
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
        /// Form.Closing イベント(PMKHN09060UA)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">キャンセルできるイベントのデータを提供するクラス</param>
        /// <remarks>
        /// <br>Note       : フォームを閉じる前に、ユーザーがフォームを閉じようとしたときに発生します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/06/11</br>
        /// </remarks>
        private void PMKHN09060UA_FormClosing(object sender, FormClosingEventArgs e)
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

            // 各種マスタ読込
            ReadGoodsLGroup();
            ReadGoodsMGroup();
            ReadSalesCode();

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
            if ((this._offerDataDiv == DIVISION_OFR) && (CompareOriginalScreen() == true))
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
                                    tNedit_BLGloupCode.Focus();
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

            BLGroupU bLGroupU = ((BLGroupU)this._bLGroupUTable[hashKey]).Clone();

            // 復活処理
            status = this._bLGroupUAcs.Revival(ref bLGroupU);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // DataSet展開処理
                        BLGroupUToDataSet(bLGroupU, this._dataIndex);

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
                            this._bLGroupUAcs,					  // エラーが発生したオブジェクト
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

            BLGroupU bLGroupU = ((BLGroupU)this._bLGroupUTable[hashKey]).Clone();

            // 物理削除処理
            status = this._bLGroupUAcs.Delete(bLGroupU);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        this.Bind_DataSet.Tables[BLGROUPU_TABLE].Rows[this._dataIndex].Delete();

                        this._bLGroupUTable.Remove(hashKey);

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
                            this._bLGroupUAcs,					  // エラーが発生したオブジェクト
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
        /// Control.Click イベント(GoodsLGroupGuide_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　 : 大分類ガイドボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/06/11</br>
        /// </remarks>
        private void GoodsLGroupGuide_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                int status;
                UserGdBd userGdBd = new UserGdBd();

                status = ShowUserGuide(out userGdBd, 70);
                if (status == 0)
                {
                    this.tNedit_GoodsLGroup.SetInt(userGdBd.GuideCode);
                    this.GoodsLGroupName_tEdit.DataText = userGdBd.GuideName.Trim();

                    // フォーカス設定
                    this.tNedit_GoodsMGroup.Focus();
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Control.Click イベント(GoodsMGroupGuide_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　 : 中分類ガイドボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/06/11</br>
        /// </remarks>
        private void GoodsMGroupGuide_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                int status;
                GoodsGroupU goodsGroupU = new GoodsGroupU();
                GoodsGroupUAcs goodsGroupUAcs = new GoodsGroupUAcs();

                status = goodsGroupUAcs.ExecuteGuid(this._enterpriseCode, out goodsGroupU);
                if (status == 0)
                {
                    this.tNedit_GoodsMGroup.SetInt(goodsGroupU.GoodsMGroup);
                    this.GoodsMGroupName_tEdit.DataText = goodsGroupU.GoodsMGroupName.Trim();

                    // フォーカス設定
                    this.tNedit_SalesCode.Focus();
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Control.Click イベント(SalesCodeGuide_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　 : 販売区分ガイドボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/06/11</br>
        /// </remarks>
        private void SalesCodeGuide_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                int status;
                UserGdBd userGdBd = new UserGdBd();

                status = ShowUserGuide(out userGdBd, 71);
                if (status == 0)
                {
                    this.tNedit_SalesCode.SetInt(userGdBd.GuideCode);
                    this.SalesCodeName_tEdit.DataText = userGdBd.GuideName.Trim();

                    // フォーカス設定
                    //this.Ok_Button.Focus();
                    this.Renewal_Button.Focus();
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// tArrowKeyControlChangeFocusイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note		: コントロールのフォーカスが変わるタイミングで発生します。</br>
        /// <br>Programmer	: 30414　忍　幸史</br>
        /// <br>Date		: 2008/06/11</br>
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null)
            {
                return;
            }

            switch (e.PrevCtrl.Name)
            {
                case "BLGroupHalfName_tEdit":
                    // BLグループ名称にフォーカスがある場合
                    if (e.Key == Keys.Down)
                    {
                        // 商品大分類コードにフォーカスを移します
                        e.NextCtrl = tNedit_GoodsLGroup;
                    }
                    break;
                case "Ok_Button":
                case "Cancel_Button":
                    // 保存ボタン、閉じるボタンにフォーカスがある場合
                    if (e.Key == Keys.Up)
                    {
                        // 販売区分ガイドボタンにフォーカスを移します
                        e.NextCtrl = SalesCodeGuide_Button;
                    }
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// ValueChanged イベント(ｸﾞﾙｰﾌﾟｺｰﾄﾞ名称)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note		: コントロールの値が変わるタイミングで発生します。</br>
        /// <br>Programmer	: 30414　忍　幸史</br>
        /// <br>Date		: 2008/06/11</br>
        /// </remarks>
        private void BLGroupName_tEdit_ValueChanged(object sender, EventArgs e)
        {
            if (this.BLGroupName_tEdit.DataText.Equals(""))
            {
                this.BLGroupHalfName_tEdit.Clear();
                return;
            }
        }

        /// <summary>
        /// ValueChanged イベント(ｸﾞﾙｰﾌﾟｺｰﾄﾞ名称(ｶﾅ))
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note		: コントロールの値が変わるタイミングで発生します。</br>
        /// <br>Programmer	: 30414　忍　幸史</br>
        /// <br>Date		: 2008/06/11</br>
        /// </remarks>
        private void BLGroupHalfName_tEdit_ValueChanged(object sender, EventArgs e)
        {
            // 既存のｸﾞﾙｰﾌﾟｺｰﾄﾞ名称(ｶﾅ)取得
            TEdit tEdit = (TEdit)sender;

            // 半角に変換
            tEdit.Text = Strings.StrConv(tEdit.Text.Trim(), VbStrConv.Narrow, 0);
        }

        /// <summary>
        /// ChangeFocus イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note		: コントロールのフォーカスが変わるタイミングで発生します。</br>
        /// <br>Programmer	: 30414　忍　幸史</br>
        /// <br>Date		: 2008/06/11</br>
        /// </remarks>
        private void tRetKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null)
            {
                return;
            }

            // 2009.03.27 30413 犬飼 新規モードからモード変更対応 >>>>>>START
            _modeFlg = false;
            // 2009.03.27 30413 犬飼 新規モードからモード変更対応 <<<<<<END

            switch (e.PrevCtrl.Name)
            {
                // 2009.03.27 30413 犬飼 新規モードからモード変更対応 >>>>>>START
                case "tNedit_BLGloupCode":
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
                                e.NextCtrl = tNedit_BLGloupCode;
                            }
                        }
                        break;
                    }
                // 2009.03.27 30413 犬飼 新規モードからモード変更対応 <<<<<<END
                case "tNedit_GoodsLGroup":
                    if ((this.tNedit_GoodsLGroup.DataText == "") || (this.tNedit_GoodsLGroup.GetInt() == 0))
                    {
                        this.GoodsLGroupName_tEdit.DataText = "";
                        return;
                    }

                    // 商品大分類コード取得
                    int goodsLGroupCode = this.tNedit_GoodsLGroup.GetInt();

                    // 商品大分類名称取得
                    this.GoodsLGroupName_tEdit.DataText = GetGoodsLGroupName(goodsLGroupCode);

                    if (e.Key == Keys.Enter)
                    {
                        // フォーカス設定
                        if (this.GoodsLGroupName_tEdit.DataText.Trim() != "")
                        {
                            e.NextCtrl = this.tNedit_GoodsMGroup;
                        }
                    }
                    break;
                case "tNedit_GoodsMGroup":
                    if ((this.tNedit_GoodsMGroup.DataText == "") || (this.tNedit_GoodsMGroup.GetInt() == 0))
                    {
                        this.GoodsMGroupName_tEdit.DataText = "";
                        return;
                    }

                    // 商品中分類コード取得
                    int goodsMGroupCode = this.tNedit_GoodsMGroup.GetInt();

                    // 商品中分類名称取得
                    this.GoodsMGroupName_tEdit.DataText = GetGoodsMGroupName(goodsMGroupCode);

                    if (e.Key == Keys.Enter)
                    {
                        // フォーカス設定
                        if (this.GoodsMGroupName_tEdit.DataText.Trim() != "")
                        {
                            e.NextCtrl = this.tNedit_SalesCode;
                        }
                    }
                    break;
                case "tNedit_SalesCode":
                    if ((this.tNedit_SalesCode.DataText == "") || (this.tNedit_SalesCode.GetInt() == 0))
                    {
                        this.SalesCodeName_tEdit.DataText = "";
                        return;
                    }

                    // 販売区分コード取得
                    int salesCode = this.tNedit_SalesCode.GetInt();

                    // 販売区分名称取得
                    this.SalesCodeName_tEdit.DataText = GetSalesCodeName(salesCode);

                    if (e.Key == Keys.Enter)
                    {
                        // フォーカス設定
                        if (this.SalesCodeName_tEdit.DataText.Trim() != "")
                        {
                            //e.NextCtrl = this.Ok_Button;
                            e.NextCtrl = this.Renewal_Button;
                        }
                    }
                    break;
                case "BLGroupHalfName_tEdit":
                    // BLグループ名称にフォーカスがある場合
                    if (e.Key == Keys.Down)
                    {
                        // 商品大分類コードにフォーカスを移します
                        e.NextCtrl = tNedit_GoodsLGroup;
                    }
                    break;
                case "Ok_Button":
                case "Cancel_Button":
                    // 保存ボタン、閉じるボタンにフォーカスがある場合
                    if (e.Key == Keys.Up)
                    {
                        // 販売区分ガイドボタンにフォーカスを移します
                        e.NextCtrl = SalesCodeGuide_Button;
                    }
                    break;
                default:
                    break;
            }
        }

        #endregion Control Events

        private void ultraButton1_Click(object sender, EventArgs e)
        {
            ReadGoodsLGroup();
            ReadGoodsMGroup();
            ReadSalesCode();

            TMsgDisp.Show(this, 								// 親ウィンドウフォーム
                          emErrorLevel.ERR_LEVEL_INFO,          // エラーレベル
                          "PMKHN09060U",						    // アセンブリＩＤまたはクラスＩＤ
                          "最新情報を取得しました。", 			// 表示するメッセージ
                          0, 									// ステータス値
                          MessageBoxButtons.OK);				// 表示するボタン
        }

        // 2009.03.27 30413 犬飼 新規モードからモード変更対応 >>>>>>START
        /// <summary>
        /// モード変更処理
        /// </summary>
        private bool ModeChangeProc()
        {
            // グループコード
            int blGloupCode = tNedit_BLGloupCode.GetInt();

            for (int i = 0; i < this.Bind_DataSet.Tables[BLGROUPU_TABLE].Rows.Count; i++)
            {
                // データセットと比較
                int dsBLGloupCode = int.Parse((string)this.Bind_DataSet.Tables[BLGROUPU_TABLE].Rows[i][BLGROUPCODE_TITLE]);
                if (blGloupCode == dsBLGloupCode)
                {
                    // 入力コードがデータセットに存在する場合
                    if ((string)this.Bind_DataSet.Tables[BLGROUPU_TABLE].Rows[i][DELETE_DATE_TITLE] != "")
                    {
                        // 論理削除
                        TMsgDisp.Show(this, 					// 親ウィンドウフォーム
                          emErrorLevel.ERR_LEVEL_INFO,          // エラーレベル
                          ASSEMBLY_ID,						    // アセンブリＩＤまたはクラスＩＤ
                          "入力されたコードのグループコードマスタ情報は既に削除されています。", 			// 表示するメッセージ
                          0, 									// ステータス値
                          MessageBoxButtons.OK);				// 表示するボタン
                        // グループコードのクリア
                        tNedit_BLGloupCode.Clear();
                        return true;
                    }

                    DialogResult res = TMsgDisp.Show(
                        this,                                   // 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_INFO,            // エラーレベル
                        ASSEMBLY_ID,                            // アセンブリＩＤまたはクラスＩＤ
                        "入力されたコードのグループコードマスタ情報が既に登録されています。\n編集を行いますか？",   // 表示するメッセージ
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
                                // グループコードのクリア
                                tNedit_BLGloupCode.Clear();
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