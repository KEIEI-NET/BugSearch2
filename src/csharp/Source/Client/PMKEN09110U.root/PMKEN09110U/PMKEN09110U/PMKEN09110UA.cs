//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : TBOマスタ
// プログラム概要   : TBOマスタの登録・更新・削除を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2007 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30414 忍　幸史
// 作 成 日  2008/11/28  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30452 上野 俊治
// 作 成 日  2009/03/16  修正内容 : 障害対応12344
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30413 犬飼
// 作 成 日  2009/04/09  修正内容 : 障害対応9264
//----------------------------------------------------------------------------//
// 管理番号  10806793-00 作成担当 : 田建委 2013/04/10配信分
// 作 成 日  2013/04/01  修正内容 : Redmine#34640 商品在庫マスタの仕様変更(#33231の残留分)
//----------------------------------------------------------------------------//
// 管理番号  10901273-00 作成担当 : 王君
// 作 成 日  2013/05/02  修正内容 : 2013/06/18配信分 Redmine#35434
//                                : 商品在庫マスタ起動区分の追加
//----------------------------------------------------------------------------//
// 管理番号  10901273-00 作成担当 : 王君
// 作 成 日  2013/06/03  修正内容 : 2013/06/18配信分 Redmine#35434
//                                : 商品在庫マスタ起動区分の追加
//----------------------------------------------------------------------------//
// 管理番号  10901273-00 作成担当 : 王君
// 作 成 日  2013/06/14  修正内容 : 2013/06/18配信分 Redmine#35434
//                                : 商品在庫マスタ起動区分の追加
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

using Infragistics.Win.UltraWinGrid;

using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Infragistics.Win;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// TBOマスタフォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note		: TBOマスタの設定を行います。</br>
    /// <br>Programmer	: 30414 忍　幸史</br>
    /// <br>Date		: 2008/11/28</br>
    /// <br>Update Note : 2009/03/16 30452 上野 俊治</br>
    /// <br>             ・障害対応12344</br>
    /// <br>Update Note : 2013/04/01 田建委</br>
    /// <br>管理番号    : 10806793-00 2013/04/10配信分</br>
    /// <br>              Redmine#34640 商品在庫マスタの仕様変更(#33231の残留分)</br>
    /// <br>Update Note : 王君</br>
    /// <br>Date        : 2013/05/02</br>
    /// <br>管理番号    : 10901273-00 2013/06/18配信分</br>
    /// <br>            : Redmine#35434の対応</br>
    /// <br>Update Note : 王君</br>
    /// <br>Date        : 2013/06/03</br>
    /// <br>管理番号    : 10901273-00 2013/06/18配信分</br>
    /// <br>            : Redmine#35434の対応</br>
    /// <br>Update Note : 王君</br>
    /// <br>Date        : 2013/06/14</br>
    /// <br>管理番号    : 10901273-00 2013/06/18配信分</br>
    /// <br>            : Redmine#35434の対応</br>
    /// </remarks>
    public partial class PMKEN09110UA : Form, IMasterMaintenanceMultiType
    {
        #region ■ Const

        // 編集モード
        private const string INSERT_MODE = "新規モード";
        private const string UPDATE_MODE = "更新モード";

        // テーブル名称
        private const string TBOSEARCHU_TABLE = "TBOSearchU";

        // FremのView用Grid列のKEY情報 (ヘッダのタイトル部となります)
        private const string PLURAL_TITLE = "複数";
        private const string EQUIPGANRECODE_TITLE = "装備分類";
        private const string EQUIPGANRENAME_TITLE = "装備名";
        private const string GOODSNO_TITLE = "品番";
        private const string GOODSNAME_TITLE = "品名";
        private const string MAKERCODE_TITLE = "メーカー";
        private const string MAKERNAME_TITLE = "メーカー名";
        private const string BLGOODSCODE_TITLE = "BLｺｰﾄﾞ";
        private const string BLGOODSNAME_TITLE = "BLｺｰﾄﾞ名";
        private const string QTY_TITLE = "QTY";
        private const string WAREHOUSECODE_TITLE = "倉庫";
        private const string WAREHOUSESHELFNO_TITLE = "棚番";
        private const string SUPPLIERSTOCK_TITLE = "現在庫";
        private const string STANDARD_TITLE = "規格/特記事項";
        private const string GUID_TITLE = "Guid";

        //子画面用Grid列のKEY情報
        private const string COLUMN_NO = "No";
        private const string COLUMN_RANK = "Rank";
        private const string COLUMN_GOODSNO = "GoodsNo";
        private const string COLUMN_GOODSNAME = "GoodsName";
        private const string COLUMN_MAKERCODE = "MakerCode";
        private const string COLUMN_MAKERNAME = "MakerName";
        private const string COLUMN_BLGOODSCODE = "BLGoodsCode";
        private const string COLUMN_BLGOODSNAME = "BLGoodsName";
        private const string COLUMN_QTY = "QTY";
        private const string COLUMN_WAREHOUSECODE = "WarehouseCode";
        private const string COLUMN_WAREHOUSESHELFNO = "WarehouseShelfNo";
        private const string COLUMN_SUPPLIERSTOCK = "SupplierStock";
        private const string COLUMN_STANDARD = "Standard";
        private const string COLUMN_DIVISIONCODE = "DivisionCode";
        private const string COLUMN_DIVISIONNAME = "DivisionName";
        private const string COLUMN_GOODSUNITDATA = "GoodsUnitData";

        // プログラムID
        private const string ASSEMBLY_ID = "PMKEN09110U";

        #endregion ■ Const


        #region ■ Private Members

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
        // 所属拠点コード
        private string _loginSectionCode;
        // 管理倉庫コード
        private string _secWarehouseCode;

        // TBOマスタアクセスクラス
        private TBOSearchUAcs _tboSearchAcs;

        private int _indexBuf;

        // 終了時の編集チェック用
        private List<GoodsUnitData> _goodsUnitDataListClone;

        private List<TBOSearchU> _allTBOSearchUList;
        private List<TBOSearchU> _userTBOSearchUList;
        private Dictionary<string, TBOSearchU> _dispTBOSearchUDic;

        private int _prevEquipGanreCode;
        private string _prevEquipName;
        private string _prevGoodsNo;
        private int _prevMakerCode;

        /// <summary>商品入力アクセスクラス</summary>
        GoodsAcs _goodsAcs; // ADD 2013/04/01 田建委 Redmine#34640

        private AllDefSet _allDefSet; // ADD 王君 2013/05/02 Redmine35434
        /// <summary>商品在庫マスタ重複起動Flag</summary>
        private int flag;// ADD 王君 2013/06/14 Redmine#35434

        #endregion ■ Private Members


        #region ■ Constructor
        /// <summary>
        /// TBOマスタ設定フォームクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note		: TBOマスタのコンストラクタです。</br>
        /// <br>Programmer	: 30414 忍　幸史</br>
        /// <br>Date		: 2008/11/28</br>
        /// <br>Update Note : 2013/04/01 田建委</br>
        /// <br>管理番号    : 10806793-00 2013/04/10配信分</br>
        /// <br>              Redmine#34640 商品在庫マスタの仕様変更(#33231の残留分)</br>
        /// <br>Update Note : 王君</br>
        /// <br>Date        : 2013/05/02</br>
        /// <br>管理番号    : 10901273-00 2013/06/18配信分</br>
        /// <br>            : Redmine#35434の対応</br>
        /// </remarks>
        public PMKEN09110UA()
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
            this._canLogicalDeleteDataExtraction = false;
            this._canSpecificationSearch = false;
            this._defaultAutoFillToColumn = false;

            // 変数初期化
            this._tboSearchAcs = new TBOSearchUAcs();

            this._goodsAcs = new GoodsAcs(); // ADD 2013/04/01 田建委 Redmine#34640

            // 企業コード取得
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            // 所属拠点コード取得
            this._loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode.Trim();
            // 管理倉庫コード
            this._secWarehouseCode = this._tboSearchAcs.GetSecInfoSet(this._loginSectionCode).SectWarehouseCd1.Trim();
            
            // 装備分類設定
            this.tComboEditor_EquipGenreCode.Items.Clear();
            this.tComboEditor_EquipGenreCode.Items.Add(1001, "バッテリー");
            this.tComboEditor_EquipGenreCode.Items.Add(1005, "タイヤ");
            this.tComboEditor_EquipGenreCode.Items.Add(1010, "オイル");
            this.tComboEditor_EquipGenreCode.Value = 1001;

            // GridIndexバッファ（メインフレーム最小化対応）
            this._indexBuf = -2;

            //全体初期値設定を取得処理
            GetDtlCalcStckCntDsp();// ADD 王君 2013/05/02 Redmine#35434
        }
        #endregion ■ Constructor


        #region ■ IMasterMaintenanceMultiType メンバ

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
        /// <br>Date       : 2008/11/28</br>
        /// </remarks>
        public Hashtable GetAppearanceTable()
        {
            Hashtable appearanceTable = new Hashtable();

            // 複数
            appearanceTable.Add(PLURAL_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleCenter, "", Color.Black));
            // 装備分類
            appearanceTable.Add(EQUIPGANRECODE_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 装備名
            appearanceTable.Add(EQUIPGANRENAME_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 品番
            appearanceTable.Add(GOODSNO_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 品名
            appearanceTable.Add(GOODSNAME_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // メーカーコード
            appearanceTable.Add(MAKERCODE_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            // メーカー名
            appearanceTable.Add(MAKERNAME_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // BLコード
            appearanceTable.Add(BLGOODSCODE_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            // BLコード名
            appearanceTable.Add(BLGOODSNAME_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // QTY
            appearanceTable.Add(QTY_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            // 倉庫コード
            appearanceTable.Add(WAREHOUSECODE_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 棚番
            appearanceTable.Add(WAREHOUSESHELFNO_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 現在庫
            appearanceTable.Add(SUPPLIERSTOCK_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.BottomRight, "", Color.Black));
            // 規格/特記事項
            appearanceTable.Add(STANDARD_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // GUID
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
        /// <br>Date       : 2008/11/28</br>
        /// </remarks>
        public void GetBindDataSet(ref DataSet bindDataSet, ref string tableName)
        {
            bindDataSet = this.Bind_DataSet;
            tableName = TBOSEARCHU_TABLE;
        }

        /// <summary>
        /// 印刷処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 印刷処理を実行します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/11/28</br>
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
        /// <br>Note       : 選択中のデータを物理削除します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/11/28</br>
        /// </remarks>
        public int Delete()
        {
            // 装備分類コード
            int equipGanreCode = (int)this.Bind_DataSet.Tables[TBOSEARCHU_TABLE].Rows[this._dataIndex][EQUIPGANRECODE_TITLE];
            // 装備名
            string equipName = (string)this.Bind_DataSet.Tables[TBOSEARCHU_TABLE].Rows[this._dataIndex][EQUIPGANRENAME_TITLE];

            // ユーザーデータ取得
            this._userTBOSearchUList = FindUserTBOSearchUList(equipGanreCode, equipName);

            // 削除リスト作成
            ArrayList deleteList = new ArrayList();
            foreach (TBOSearchU tboSearchU in this._userTBOSearchUList)
            {
                deleteList.Add(tboSearchU);
            }

            // 物理削除処理
            int status = this._tboSearchAcs.Delete(deleteList);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // 再検索
                        int totalCount = 0;
                        Search(ref totalCount, 0);
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        // 排他制御
                        ExclusiveTransaction(status);
                        break;
                    }
                default:
                    {
                        ShowMessageBox(emErrorLevel.ERR_LEVEL_STOP,
                                       "Delete",
                                       "削除に失敗しました。",
                                       status,
                                       MessageBoxButtons.OK);
                        break;
                    }
            }

            return status;
        }

        /// <summary>
        /// 検索処理
        /// </summary>
        /// <param name="totalCount">全該当件数</param>
        /// <param name="readCount">抽出対象件数</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 全データを検索し、抽出結果を展開したDataSetと全該当件数を返します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/11/28</br>
        /// </remarks>
        public int Search(ref int totalCount, int readCount)
        {
            int status = -1;
            totalCount = 0;

            try
            {
                // クリア
                this.Bind_DataSet.Tables[TBOSEARCHU_TABLE].Rows.Clear();
                this._allTBOSearchUList = new List<TBOSearchU>();
                this._dispTBOSearchUDic = new Dictionary<string, TBOSearchU>();

                ArrayList retList = new ArrayList();

                // 検索処理
                status = this._tboSearchAcs.SearchAll(out retList, this._enterpriseCode);
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:

                        foreach (TBOSearchU tboSearchU in retList)
                        {
                            // 検索結果リスト作成
                            this._allTBOSearchUList.Add(tboSearchU);
                            
                            // キー作成
                            string key = CreateHashKey(tboSearchU);

                            // DataView表示用リスト作成
                            if (this._dispTBOSearchUDic.ContainsKey(key) == false)
                            {
                                this._dispTBOSearchUDic.Add(key, tboSearchU);
                            }
                        }

                        int index = 0;
                        foreach (TBOSearchU tboSearchU in this._dispTBOSearchUDic.Values)
                        {
                            // データセット展開
                            TBOSearchUToDataSet(tboSearchU.Clone(), index);
                            ++index;
                        }

                        totalCount = retList.Count;

                        break;
                    default:
                        ShowMessageBox(emErrorLevel.ERR_LEVEL_STOP,
                                       "Search",
                                       "検索に失敗しました。",
                                       status,
                                       MessageBoxButtons.OK);
                        return (status);
                }
            }
            catch (Exception)
            {
                ShowMessageBox(emErrorLevel.ERR_LEVEL_STOP,
                                       "Search",
                                       "検索に失敗しました。",
                                       status,
                                       MessageBoxButtons.OK);
                status = -1;
                return (status);
            }

            return 0;
        }

        /// <summary>
        /// ネクストデータ検索処理
        /// </summary>
        /// <param name="readCount">抽出対象件数</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 指定した件数分のネクストデータを検索します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/11/28</br>
        /// </remarks>
        public int SearchNext(int readCount)
        {
            // 実装なし
            return 0;
        }

        /// <summary>画面非表示イベント</summary>
        /// <remarks>画面が非表示状態になった際に発生します。</remarks>
        public event MasterMaintenanceMultiTypeUnDisplayingEventHandler UnDisplaying;

        #endregion ■ IMasterMaintenanceMultiType メンバ


        #region ■ Private Methods
        /// <summary>
        /// TBOマスタリスト取得処理(ユーザー)
        /// </summary>
        /// <param name="equipGanreCode">装備分類</param>
        /// <param name="equipName">装備名</param>
        /// <returns>TBOマスタリスト(ユーザー)</returns>
        /// <remarks>
        /// <br>Note       : TBOマスタリスト(ユーザー)を取得します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/11/28</br>
        /// </remarks>
        private List<TBOSearchU> FindUserTBOSearchUList(int equipGanreCode, string equipName)
        {
            // ユーザーデータ取得
            List < TBOSearchU > userTBOSearchUList = this._allTBOSearchUList.FindAll(delegate(TBOSearchU target)
            {
                if ((target.EquipGenreCode == equipGanreCode) && (target.EquipName.Trim() == equipName.Trim()))
                {
                    return (true);
                }
                else
                {
                    return (false);
                }
            });

            if (userTBOSearchUList == null)
            {
                userTBOSearchUList = new List<TBOSearchU>();
            }

            return userTBOSearchUList;
        }

        /// <summary>
        /// HashTable用Key作成処理
        /// </summary>
        /// <param name="tboSearchU">TBOマスタオブジェクト</param>
        /// <returns>キー</returns>
        /// <remarks>
        /// <br>Note       : ハッシュテーブル用のキーを作成します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/11/28</br>
        /// </remarks>
        private string CreateHashKey(TBOSearchU tboSearchU)
        {
            return (tboSearchU.EquipGenreCode.ToString() + tboSearchU.EquipName.Trim());
        }

        /// <summary>
        /// データセット列情報構築処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : データセットの列情報を構築します。
        ///					 データセットの列情報がフレームのビュー用グリッドの列になります</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/11/28</br>
        /// </remarks>
        private void DataSetColumnConstruction()
        {
            DataTable dataTable = new DataTable(TBOSEARCHU_TABLE);

            //---------------------------------------------
            // Addを行う順番が、列の表示順位となります。
            //---------------------------------------------

            // 複数
            dataTable.Columns.Add(PLURAL_TITLE, typeof(string));
            // 装備分類
            dataTable.Columns.Add(EQUIPGANRECODE_TITLE, typeof(int));
            // 装備名
            dataTable.Columns.Add(EQUIPGANRENAME_TITLE, typeof(string));
            // 品番
            dataTable.Columns.Add(GOODSNO_TITLE, typeof(string));
            // 品名
            dataTable.Columns.Add(GOODSNAME_TITLE, typeof(string));
            // メーカーコード
            dataTable.Columns.Add(MAKERCODE_TITLE, typeof(string));
            // メーカー名
            dataTable.Columns.Add(MAKERNAME_TITLE, typeof(string));
            // BLコード
            dataTable.Columns.Add(BLGOODSCODE_TITLE, typeof(string));
            // BLコード名
            dataTable.Columns.Add(BLGOODSNAME_TITLE, typeof(string));
            // QTY
            dataTable.Columns.Add(QTY_TITLE, typeof(string));
            // 倉庫コード
            dataTable.Columns.Add(WAREHOUSECODE_TITLE, typeof(string));
            // 棚番
            dataTable.Columns.Add(WAREHOUSESHELFNO_TITLE, typeof(string));
            // 現在庫
            dataTable.Columns.Add(SUPPLIERSTOCK_TITLE, typeof(string));
            // 規格/特記事項
            dataTable.Columns.Add(STANDARD_TITLE, typeof(string));
            // GUID
            dataTable.Columns.Add(GUID_TITLE, typeof(Guid));

            this.Bind_DataSet.Tables.Add(dataTable);
        }

        /// <summary>
        /// グリッド作成処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : グリッドを作成します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/11/28</br>
        /// </remarks>
        private void CreateGrid()
        {
            DataTable dataTable = new DataTable();

            // No.
            dataTable.Columns.Add(COLUMN_NO, typeof(int));
            // 順位
            dataTable.Columns.Add(COLUMN_RANK, typeof(int));
            // 品番
            dataTable.Columns.Add(COLUMN_GOODSNO, typeof(string));
            // 品名
            dataTable.Columns.Add(COLUMN_GOODSNAME, typeof(string));
            // メーカーコード
            dataTable.Columns.Add(COLUMN_MAKERCODE, typeof(string));
            // メーカー名
            dataTable.Columns.Add(COLUMN_MAKERNAME, typeof(string));
            // BLコード
            dataTable.Columns.Add(COLUMN_BLGOODSCODE, typeof(string));
            // BLコード名
            dataTable.Columns.Add(COLUMN_BLGOODSNAME, typeof(string));
            // QTY
            dataTable.Columns.Add(COLUMN_QTY, typeof(string));
            // 倉庫コード
            dataTable.Columns.Add(COLUMN_WAREHOUSECODE, typeof(string));
            // 棚番
            dataTable.Columns.Add(COLUMN_WAREHOUSESHELFNO, typeof(string));
            // 現在庫
            dataTable.Columns.Add(COLUMN_SUPPLIERSTOCK, typeof(string));
            // 規格/特記事項
            dataTable.Columns.Add(COLUMN_STANDARD, typeof(string));
            // 提供区分
            dataTable.Columns.Add(COLUMN_DIVISIONCODE, typeof(int));
            // 提供区分名
            dataTable.Columns.Add(COLUMN_DIVISIONNAME, typeof(string));
            // 商品連結データ
            dataTable.Columns.Add(COLUMN_GOODSUNITDATA, typeof(GoodsUnitData));

            this.uGrid_Details.DataSource = dataTable;

            if (this.uGrid_Details.Rows.Count < 9999)
            {
                // 1行追加
                CreateNewRow(ref this.uGrid_Details);
            }

            this.uGrid_Details.DisplayLayout.ColScrollRegions.Clear();
        }

        /// <summary>
        /// グリッドレイアウト設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : グリッドレイアウトを設定します。</br>
        /// <br>Programmer : 30414 忍　幸史/br>
        /// <br>Date       : 2008/11/28</br>
        /// </remarks>
        private void SetGridLayout()
        {
            ColumnsCollection columns = this.uGrid_Details.DisplayLayout.Bands[0].Columns;

            //--------------------------------------
            // 入力不可
            //--------------------------------------
            columns[COLUMN_NO].CellActivation = Activation.Disabled;
            columns[COLUMN_RANK].CellActivation = Activation.Disabled;
            columns[COLUMN_GOODSNAME].CellActivation = Activation.Disabled;
            columns[COLUMN_MAKERNAME].CellActivation = Activation.Disabled;
            columns[COLUMN_BLGOODSCODE].CellActivation = Activation.Disabled;
            columns[COLUMN_BLGOODSNAME].CellActivation = Activation.Disabled;
            columns[COLUMN_WAREHOUSECODE].CellActivation = Activation.Disabled;
            columns[COLUMN_WAREHOUSESHELFNO].CellActivation = Activation.Disabled;
            columns[COLUMN_SUPPLIERSTOCK].CellActivation = Activation.Disabled;
            columns[COLUMN_DIVISIONCODE].CellActivation = Activation.Disabled;
            columns[COLUMN_DIVISIONNAME].CellActivation = Activation.Disabled;

            //--------------------------------------
            // セルカラー
            //--------------------------------------
            columns[COLUMN_NO].CellAppearance.BackColorDisabled = Color.FromArgb(89, 135, 214);
            columns[COLUMN_NO].CellAppearance.BackColorDisabled2 = Color.FromArgb(7, 59, 150);
            columns[COLUMN_NO].CellAppearance.BackGradientStyle = GradientStyle.Vertical;
            columns[COLUMN_NO].CellAppearance.ForeColor = Color.White;
            columns[COLUMN_NO].CellAppearance.ForeColorDisabled = Color.White;

            //--------------------------------------
            // 列固定
            //--------------------------------------
            columns[COLUMN_NO].Header.Fixed = true;
            columns[COLUMN_RANK].Header.Fixed = true;
            columns[COLUMN_GOODSNO].Header.Fixed = true;

            //--------------------------------------
            // 非表示
            //--------------------------------------
            columns[COLUMN_DIVISIONCODE].Hidden = true;
            columns[COLUMN_GOODSUNITDATA].Hidden = true;

            //--------------------------------------
            // キャプション
            //--------------------------------------
            columns[COLUMN_NO].Header.Caption = "No.";
            columns[COLUMN_RANK].Header.Caption = "順位";
            columns[COLUMN_GOODSNO].Header.Caption = "品番";
            columns[COLUMN_GOODSNAME].Header.Caption = "品名";
            columns[COLUMN_MAKERCODE].Header.Caption = "ﾒｰｶｰ";
            columns[COLUMN_MAKERNAME].Header.Caption = "ﾒｰｶｰ名";
            columns[COLUMN_BLGOODSCODE].Header.Caption = "BLｺｰﾄﾞ";
            columns[COLUMN_BLGOODSNAME].Header.Caption = "BLｺｰﾄﾞ名";
            columns[COLUMN_QTY].Header.Caption = "QTY";
            columns[COLUMN_WAREHOUSECODE].Header.Caption = "倉庫";
            columns[COLUMN_WAREHOUSESHELFNO].Header.Caption = "棚番";
            columns[COLUMN_SUPPLIERSTOCK].Header.Caption = "現在庫数";
            columns[COLUMN_STANDARD].Header.Caption = "規格/特記事項";
            columns[COLUMN_DIVISIONCODE].Header.Caption = "提供区分";
            columns[COLUMN_DIVISIONNAME].Header.Caption = "提供区分";

            //--------------------------------------
            // 列幅
            //--------------------------------------
            columns[COLUMN_NO].Width = 50;
            columns[COLUMN_RANK].Width = 50;
            columns[COLUMN_GOODSNO].Width = 210;
            columns[COLUMN_GOODSNAME].Width = 330;
            columns[COLUMN_MAKERCODE].Width = 50;
            columns[COLUMN_MAKERNAME].Width = 180;
            columns[COLUMN_BLGOODSCODE].Width = 60;
            columns[COLUMN_BLGOODSNAME].Width = 180;
            columns[COLUMN_QTY].Width = 100;
            columns[COLUMN_WAREHOUSECODE].Width = 50;
            columns[COLUMN_WAREHOUSESHELFNO].Width = 80;
            columns[COLUMN_SUPPLIERSTOCK].Width = 100;
            columns[COLUMN_STANDARD].Width = 330;
            columns[COLUMN_DIVISIONCODE].Width = 80;
            columns[COLUMN_DIVISIONNAME].Width = 80;

            //--------------------------------------
            // 入力桁数
            //--------------------------------------
            columns[COLUMN_NO].MaxLength = 4;
            columns[COLUMN_RANK].MaxLength = 4;
            columns[COLUMN_GOODSNO].MaxLength = 24;
            columns[COLUMN_GOODSNAME].MaxLength = 20;
            columns[COLUMN_MAKERCODE].MaxLength = 4;
            columns[COLUMN_MAKERNAME].MaxLength = 10;
            columns[COLUMN_BLGOODSCODE].MaxLength = 5;
            columns[COLUMN_BLGOODSNAME].MaxLength = 10;
            columns[COLUMN_QTY].MaxLength = 9;
            columns[COLUMN_WAREHOUSECODE].MaxLength = 4;
            columns[COLUMN_WAREHOUSESHELFNO].MaxLength = 9;
            columns[COLUMN_SUPPLIERSTOCK].MaxLength = 12;
            columns[COLUMN_STANDARD].MaxLength = 20;
            columns[COLUMN_DIVISIONCODE].MaxLength = 4;
            columns[COLUMN_DIVISIONNAME].MaxLength = 4;

            //--------------------------------------
            // テキスト位置(HAlign)
            //--------------------------------------
            columns[COLUMN_NO].CellAppearance.TextHAlign = HAlign.Right;
            columns[COLUMN_RANK].CellAppearance.TextHAlign = HAlign.Right;
            columns[COLUMN_GOODSNO].CellAppearance.TextHAlign = HAlign.Left;
            columns[COLUMN_GOODSNAME].CellAppearance.TextHAlign = HAlign.Left;
            columns[COLUMN_MAKERCODE].CellAppearance.TextHAlign = HAlign.Right;
            columns[COLUMN_MAKERNAME].CellAppearance.TextHAlign = HAlign.Left;
            columns[COLUMN_BLGOODSCODE].CellAppearance.TextHAlign = HAlign.Right;
            columns[COLUMN_BLGOODSNAME].CellAppearance.TextHAlign = HAlign.Left;
            columns[COLUMN_QTY].CellAppearance.TextHAlign = HAlign.Right;
            columns[COLUMN_WAREHOUSECODE].CellAppearance.TextHAlign = HAlign.Left;
            columns[COLUMN_WAREHOUSESHELFNO].CellAppearance.TextHAlign = HAlign.Left;
            columns[COLUMN_SUPPLIERSTOCK].CellAppearance.TextHAlign = HAlign.Right;
            columns[COLUMN_STANDARD].CellAppearance.TextHAlign = HAlign.Left;
            columns[COLUMN_DIVISIONCODE].CellAppearance.TextHAlign = HAlign.Right;
            columns[COLUMN_DIVISIONNAME].CellAppearance.TextHAlign = HAlign.Left;

            //--------------------------------------
            // テキスト位置(VAlign)
            //--------------------------------------
            for (int index = 0; index < columns.Count; index++)
            {
                columns[index].CellAppearance.TextVAlign = VAlign.Middle;
            }
        }

        /// <summary>
        /// 画面クリア処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面をクリアします。</br>
        /// <br>Programmer : 30414 忍　幸史/br>
        /// <br>Date       : 2008/11/28</br>
        /// </remarks>
        private void ClearScreen()
        {
            this.Mode_Label.Text = "";

            this.tComboEditor_EquipGenreCode.Value = 1001;
            this.tEdit_EquipGenreName.Clear();

            this._prevEquipGanreCode = 1001;
            this._prevEquipName = "";

            // グリッド初期化
            CreateGrid();
            SetGridLayout();
        }

        /// <summary>
        /// 画面入力許可制御処理
        /// </summary>
        /// <param name="editMode">編集モード(INSERT_MODE：新規　UPDATE_MODE：更新)</param>
        /// <remarks>
        /// <br>Note       : 画面の入力許可を制御します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/11/28</br>
        /// </remarks>
        private void ScreenInputPermissionControl(string editMode)
        {
            switch (editMode)
            {
                // 新規モード
                case INSERT_MODE:

                    this.tComboEditor_EquipGenreCode.Enabled = true;
                    this.tEdit_EquipGenreName.Enabled = true;
                    this.EquipGenreGuide_Button.Enabled = true;

                    this.RowDelete_Button.Enabled = false;
                    this.GoodsRegist_Button.Enabled = false;

                    break;
                // 更新モード
                case UPDATE_MODE:

                    this.tComboEditor_EquipGenreCode.Enabled = false;
                    this.tEdit_EquipGenreName.Enabled = false;
                    this.EquipGenreGuide_Button.Enabled = false;

                    this.RowDelete_Button.Enabled = true;
                    this.GoodsRegist_Button.Enabled = true;

                    break;
            }
        }

        /// <summary>
        /// 排他処理
        /// </summary>
        /// <param name="status">STATUS</param>
        /// <remarks>
        /// <br>Note       : 排他処理を行います</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/11/28</br>
        /// </remarks>
        private void ExclusiveTransaction(int status)
        {
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    {
                        // 他端末更新
                        ShowMessageBox(emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                       "ExclusiveTransaction",
                                       "既に他端末より更新されています。",
                                       status,
                                       MessageBoxButtons.OK);
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        // 他端末削除
                        ShowMessageBox(emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                       "ExclusiveTransaction",
                                       "既に他端末より削除されています。",
                                       status,
                                       MessageBoxButtons.OK);
                        break;
                    }
            }
        }

        /// <summary>
        /// 同一装備分類・装備名存在チェック
        /// </summary>
        /// <param name="key">キー</param>
        /// <returns>True:存在　False:非存在</returns>
        /// <remarks>
        /// <br>Note       : 同一の装備分類・装備名が存在するかどうかチェックします。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/11/28</br>
        /// </remarks>
        private bool CheckSameKey(string key)
        {
            int count = 0;

            foreach (TBOSearchU tboSearchU in this._allTBOSearchUList)
            {
                if (CreateHashKey(tboSearchU) == key)
                {
                    count++;
                }
            }

            if (count > 1)
            {
                return (true);
            }
            else
            {
                return (false);
            }
        }

        /// <summary>
        /// ユーザーデータチェック処理
        /// </summary>
        /// <param name="goodsUnitData">商品連結データ</param>
        /// <returns>ステータス(True:ユーザーデータ　False:提供データ)</returns>
        /// <remarks>
        /// <br>Note       : 対象の商品連結データがユーザーデータとして登録されているかどうかチェックします。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/11/28</br>
        /// </remarks>
        private bool CheckUserData(GoodsUnitData goodsUnitData)
        {
            foreach (TBOSearchU tboSearchU in this._userTBOSearchUList)
            {
                if ((goodsUnitData.GoodsMakerCd == tboSearchU.JoinDestMakerCd) &&
                    (goodsUnitData.GoodsNo.Trim() == tboSearchU.JoinDestPartsNo.Trim()))
                {
                    return (true);
                }
            }

            return (false);
        }

        /// <summary>
        /// 数値入力チェック処理
        /// </summary>
        /// <param name="keta">桁数(マイナス符号を含まず)</param>
        /// <param name="priod">小数点以下桁数</param>
        /// <param name="prevVal">現在の文字列</param>
        /// <param name="key">入力されたキー値</param>
        /// <param name="selstart">カーソル位置</param>
        /// <param name="sellength">選択文字長</param>
        /// <param name="minusFlg">マイナス入力可？</param>
        /// <returns>true=入力可,false=入力不可</returns>
        /// <remarks>
        /// <br>Note        : 数値の入力チェックを行います。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/11/28</br>
        /// </remarks>
        private bool KeyPressNumCheck(int keta, int priod, string prevVal, char key, int selstart, int sellength, Boolean minusFlg)
        {
            // 制御キーが押された？
            if (Char.IsControl(key))
            {
                return true;
            }
            // 数値以外は、ＮＧ
            if (!Char.IsDigit(key))
            {
                // 小数点または、マイナス以外
                if ((key != '.') && (key != '-'))
                {
                    return false;
                }
            }

            // キーが押されたと仮定した場合の文字列を生成する。
            string strResult = "";
            if (sellength > 0)
            {
                strResult = prevVal.Substring(0, selstart) + prevVal.Substring(selstart + sellength, prevVal.Length - (selstart + sellength));
            }
            else
            {
                strResult = prevVal;
            }

            // マイナスのチェック
            if (key == '-')
            {
                if ((minusFlg == false) || (selstart > 0) || (strResult.IndexOf('-') != -1))
                {
                    return false;
                }
            }

            // 小数点のチェック
            if (key == '.')
            {
                if ((priod <= 0) || (strResult.IndexOf('.') != -1))
                {
                    return false;
                }
            }
            // キーが押された結果の文字列を生成する。
            strResult = prevVal.Substring(0, selstart)
                + key
                + prevVal.Substring(selstart + sellength, prevVal.Length - (selstart + sellength));

            // 桁数チェック！
            if (strResult.Length > keta)
            {
                if (strResult[0] == '-')
                {
                    if (strResult.Length > (keta + 1))
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }

            // 小数点以下のチェック
            if (priod > 0)
            {
                // 小数点の位置決定
                int _pointPos = strResult.IndexOf('.');

                // 整数部に入力可能な桁数を決定！
                int _Rketa = (strResult[0] == '-') ? keta - priod : keta - priod - 1;
                // 整数部の桁数をチェック
                if (_pointPos != -1)
                {
                    if (_pointPos > _Rketa)
                    {
                        return false;
                    }
                }
                else
                {
                    if (strResult.Length > _Rketa)
                    {
                        return false;
                    }
                }

                // 小数部の桁数をチェック
                if (_pointPos != -1)
                {
                    // 小数部の桁数を計算
                    int _priketa = strResult.Length - _pointPos - 1;
                    if (priod < _priketa)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// 同一商品存在チェック処理
        /// </summary>
        /// <param name="goodsUnitData">商品連結データ</param>
        /// <param name="rowIndex">対象行インデックス</param>
        /// <returns>ステータス(True:非存在　False:存在)</returns>
        /// <remarks>
        /// <br>Note       : グリッド内に同一商品があるかどうかチェックします。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/11/28</br>
        /// </remarks>
        private bool CheckSameGoods(GoodsUnitData goodsUnitData, int rowIndex)
        {
            int makerCode;
            string goodsNo;

            for (int index = 0; index < this.uGrid_Details.Rows.Count; index++)
            {
                if (index == rowIndex)
                {
                    continue;
                }

                makerCode = StrObjToInt(this.uGrid_Details.Rows[index].Cells[COLUMN_MAKERCODE].Value);
                goodsNo = StrObjToString(this.uGrid_Details.Rows[index].Cells[COLUMN_GOODSNO].Value);

                if ((goodsUnitData.GoodsMakerCd == makerCode) &&
                    (goodsUnitData.GoodsNo.Trim() == goodsNo.Trim()))
                {
                    return (false);
                }
            }

            return (true);
        }

        /// <summary>
        /// TBOマスタオブジェクトデータセット展開処理
        /// </summary>
        /// <param name="tboSearchU">TBOマスタオブジェクト</param>
        /// <param name="index">データセットへ展開するインデックス</param>
        /// <remarks>
        /// <br>Note       : TBOマスタクラスをデータセットに格納します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/11/28</br>
        /// </remarks>
        private void TBOSearchUToDataSet(TBOSearchU tboSearchU, int index)
        {
            if ((index < 0) || (this.Bind_DataSet.Tables[TBOSEARCHU_TABLE].Rows.Count <= index))
            {
                // 新規と判断して、行を追加する
                DataRow dataRow = this.Bind_DataSet.Tables[TBOSEARCHU_TABLE].NewRow();
                this.Bind_DataSet.Tables[TBOSEARCHU_TABLE].Rows.Add(dataRow);

                // indexを行の最終行番号する
                index = this.Bind_DataSet.Tables[TBOSEARCHU_TABLE].Rows.Count - 1;
            }

            // 複数
            if (CheckSameKey(CreateHashKey(tboSearchU)) == true)
            {
                this.Bind_DataSet.Tables[TBOSEARCHU_TABLE].Rows[index][PLURAL_TITLE] = "※";
            }
            else
            {
                this.Bind_DataSet.Tables[TBOSEARCHU_TABLE].Rows[index][PLURAL_TITLE] = "";
            }
            // 装備分類
            this.Bind_DataSet.Tables[TBOSEARCHU_TABLE].Rows[index][EQUIPGANRECODE_TITLE] = tboSearchU.EquipGenreCode;
            // 装備名
            this.Bind_DataSet.Tables[TBOSEARCHU_TABLE].Rows[index][EQUIPGANRENAME_TITLE] = tboSearchU.EquipName.Trim();
            // 品番
            this.Bind_DataSet.Tables[TBOSEARCHU_TABLE].Rows[index][GOODSNO_TITLE] = tboSearchU.JoinDestPartsNo.Trim();
            // 品名
            this.Bind_DataSet.Tables[TBOSEARCHU_TABLE].Rows[index][GOODSNAME_TITLE] = tboSearchU.JoinDestGoodsName.Trim();
            // DEL 2009/04/09 ------>>>
            //// メーカーコード
            //this.Bind_DataSet.Tables[TBOSEARCHU_TABLE].Rows[index][MAKERCODE_TITLE] = tboSearchU.JoinDestMakerCd.ToString("0000");
            //// メーカー名
            //this.Bind_DataSet.Tables[TBOSEARCHU_TABLE].Rows[index][MAKERNAME_TITLE] = tboSearchU.JoinDestMakerName.Trim();
            // DEL 2009/04/09 ------<<<

            // ADD 2009/04/09 ------>>>
            if (tboSearchU.JoinDestMakerCd == 0)
            {
                // メーカーコード
                this.Bind_DataSet.Tables[TBOSEARCHU_TABLE].Rows[index][MAKERCODE_TITLE] = "";
                // メーカー名
                this.Bind_DataSet.Tables[TBOSEARCHU_TABLE].Rows[index][MAKERNAME_TITLE] = "";
            }
            else
            {
                // メーカーコード
                this.Bind_DataSet.Tables[TBOSEARCHU_TABLE].Rows[index][MAKERCODE_TITLE] = tboSearchU.JoinDestMakerCd.ToString("0000");
                // メーカー名
                this.Bind_DataSet.Tables[TBOSEARCHU_TABLE].Rows[index][MAKERNAME_TITLE] = tboSearchU.JoinDestMakerName.Trim();
            }
            // ADD 2009/04/09 ------<<<
            
            if (tboSearchU.BLGoodsCode == 0)
            {
                // BLコード
                this.Bind_DataSet.Tables[TBOSEARCHU_TABLE].Rows[index][BLGOODSCODE_TITLE] = "";
                // BLコード名
                this.Bind_DataSet.Tables[TBOSEARCHU_TABLE].Rows[index][BLGOODSNAME_TITLE] = "";
            }
            else
            {
                // BLコード
                this.Bind_DataSet.Tables[TBOSEARCHU_TABLE].Rows[index][BLGOODSCODE_TITLE] = tboSearchU.BLGoodsCode.ToString("00000");
                // BLコード名
                this.Bind_DataSet.Tables[TBOSEARCHU_TABLE].Rows[index][BLGOODSNAME_TITLE] = this._tboSearchAcs.GetBLGoodsCdName(tboSearchU.BLGoodsCode);
            }
            // QTY
            this.Bind_DataSet.Tables[TBOSEARCHU_TABLE].Rows[index][QTY_TITLE] = tboSearchU.JoinQty.ToString("N");

            Stock stock;
            int status = this._tboSearchAcs.GetStock(out stock, tboSearchU.JoinDestMakerCd, tboSearchU.JoinDestPartsNo, this._secWarehouseCode);
            if (status == 0)
            {
                // 倉庫コード
                this.Bind_DataSet.Tables[TBOSEARCHU_TABLE].Rows[index][WAREHOUSECODE_TITLE] = this._secWarehouseCode.PadLeft(4, '0');
                // 棚番
                this.Bind_DataSet.Tables[TBOSEARCHU_TABLE].Rows[index][WAREHOUSESHELFNO_TITLE] = stock.WarehouseShelfNo.Trim();
                // 現在庫
                this.Bind_DataSet.Tables[TBOSEARCHU_TABLE].Rows[index][SUPPLIERSTOCK_TITLE] = stock.SupplierStock.ToString("###,##0");
            }
            else
            {
                // 倉庫コード
                this.Bind_DataSet.Tables[TBOSEARCHU_TABLE].Rows[index][WAREHOUSECODE_TITLE] = "";
                // 棚番
                this.Bind_DataSet.Tables[TBOSEARCHU_TABLE].Rows[index][WAREHOUSESHELFNO_TITLE] = "";
                // 現在庫
                this.Bind_DataSet.Tables[TBOSEARCHU_TABLE].Rows[index][SUPPLIERSTOCK_TITLE] = "";
            }
            // 規格/特記事項
            this.Bind_DataSet.Tables[TBOSEARCHU_TABLE].Rows[index][STANDARD_TITLE] = tboSearchU.EquipSpecialNote.Trim();
            // GUID
            this.Bind_DataSet.Tables[TBOSEARCHU_TABLE].Rows[index][GUID_TITLE] = tboSearchU.FileHeaderGuid;
        }

        /// <summary>
        /// 画面再構築処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : モードに基づいて画面を再構築します。</br>
        /// <br>Programmer : 30414 忍　幸史/br>
        /// <br>Date       : 2008/11/28</br>
        /// </remarks>
        private void ScreenReconstruction()
        {
            TBOSearchU tboSearchU = new TBOSearchU();

            // 新規の場合
            if (this._dataIndex < 0)
            {
                // 新規モード
                this.Mode_Label.Text = INSERT_MODE;

                // 画面入力許可制御処理
                ScreenInputPermissionControl(INSERT_MODE);

                // クローン作成
                this._goodsUnitDataListClone = new List<GoodsUnitData>();

                this._userTBOSearchUList = new List<TBOSearchU>();

                // フォーカス設定
                this.tComboEditor_EquipGenreCode.Focus();
            }
            else
            {
                // 装備分類コード
                int equipGanreCode = (int)this.Bind_DataSet.Tables[TBOSEARCHU_TABLE].Rows[this._dataIndex][EQUIPGANRECODE_TITLE];
                // 装備名
                string equipName = (string)this.Bind_DataSet.Tables[TBOSEARCHU_TABLE].Rows[this._dataIndex][EQUIPGANRENAME_TITLE];

                this.tComboEditor_EquipGenreCode.Value = equipGanreCode;
                this.tEdit_EquipGenreName.DataText = equipName.Trim();

                // ユーザーデータ取得
                this._userTBOSearchUList = FindUserTBOSearchUList(equipGanreCode, equipName);

                List<GoodsUnitData> goodsUnitDataList;

                // 商品連結データ検索
                int status = SearchGoodsUnitDataList(out goodsUnitDataList, equipGanreCode, equipName);
                if (status == 0)
                {
                    // 商品連結データ検索後処理
                    AfterSearchGoodsUnitDataList(goodsUnitDataList);
                }
            }

            // _indexBufバッファ保持
            this._indexBuf = this._dataIndex;
        }

        /// <summary>
        /// 商品連結データ検索処理
        /// </summary>
        /// <param name="equipGanreCode">装備分類コード</param>
        /// <param name="equipName">装備名</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 装備分類・装備名に該当する商品連結データを取得します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/11/28</br>
        /// </remarks>
        private int SearchGoodsUnitDataList(out List<GoodsUnitData> goodsUnitDataList, int equipGanreCode, string equipName)
        {
            int status;
            goodsUnitDataList = new List<GoodsUnitData>();

            try
            {
                status = this._tboSearchAcs.Search(out goodsUnitDataList, this._enterpriseCode, this._loginSectionCode, equipGanreCode, equipName);
            }
            catch
            {
                status = -1;
            }

            return (status);
        }

        /// <summary>
        /// 商品連結データ検索後処理
        /// </summary>
        /// <param name="goodsUnitDataList">商品連結データリスト</param>
        /// <remarks>
        /// <br>Note       : 装備分類・装備名に該当する商品連結データが存在した場合の処理を行います。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/11/28</br>
        /// </remarks>
        private void AfterSearchGoodsUnitDataList(List<GoodsUnitData> goodsUnitDataList)
        {
            // 更新モード
            this.Mode_Label.Text = UPDATE_MODE;

            // 画面入力許可制御処理
            ScreenInputPermissionControl(UPDATE_MODE);

            // 2009.03.30 30413 犬飼 商品マスタ論理削除時の対応 >>>>>>START
            // 商品情報削除分TBO情報取得
            GetTBOSearchUOfDeletedGoodsInfo(ref goodsUnitDataList);
            // 2009.03.30 30413 犬飼 商品マスタ論理削除時の対応 <<<<<<END
            
            // ソート
            SortGoodsUnitDataList(ref goodsUnitDataList);

            this.uGrid_Details.BeginUpdate();

            // グリッド初期化
            CreateGrid();

            int rowIndex = 0;
            foreach (GoodsUnitData goodsUnitData in goodsUnitDataList)
            {
                // 商品連結データ画面展開
                GoodsUnitDataToScreen(goodsUnitData, rowIndex, false);
                // 新規行作成
                CreateNewRow(ref this.uGrid_Details);
                rowIndex++;
            }

            this.uGrid_Details.EndUpdate();

            // クローン作成
            this._goodsUnitDataListClone = new List<GoodsUnitData>();
            foreach (GoodsUnitData goodsUnitData in goodsUnitDataList)
            {
                this._goodsUnitDataListClone.Add(goodsUnitData);
            }

            for (int index = 0; index < this.uGrid_Details.Rows.Count - 1; index++)
            {
                // セルEnabled制御
                ChangeGridCellEnabled(index, false);
            }

            // フォーカス設定
            this.uGrid_Details.Focus();
            for (int index = 0; index < this.uGrid_Details.Rows.Count; index++)
            {
                if (this.uGrid_Details.Rows[index].Cells[COLUMN_GOODSNO].Activation == Activation.AllowEdit)
                {
                    this.uGrid_Details.Rows[index].Cells[COLUMN_GOODSNO].Activate();
                    this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                    break;
                }
            }
        }

        /// <summary>
        /// 商品連結データリストソート処理
        /// </summary>
        /// <param name="goodsUnitDataList">商品連結データリスト</param>
        /// <returns>ソート後の商品連結データリスト</returns>
        /// <remarks>
        /// <br>Note       : 商品連結データリストをソートします。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/11/28</br>
        /// </remarks>
        private void SortGoodsUnitDataList(ref List<GoodsUnitData> goodsUnitDataList)
        {
            // ソート順
            // ユーザー登録分、順位、メーカー、品番　→　提供分、順位、メーカー、品番

            if (this._userTBOSearchUList.Count == 0)
            {
                // 提供データのみ
                goodsUnitDataList.Sort(delegate(GoodsUnitData x, GoodsUnitData y)
                {
                    if (x.DisplayOrder != y.DisplayOrder)
                    {
                        return x.DisplayOrder - y.DisplayOrder;
                    }
                    else if (x.GoodsMakerCd != y.GoodsMakerCd)
                    {
                        return x.GoodsMakerCd - y.GoodsMakerCd;
                    }
                    else if (x.GoodsNo.Trim() != y.GoodsNo.Trim())
                    {
                        return x.GoodsNo.Trim().CompareTo(y.GoodsNo.Trim());
                    }
                    else
                    {
                        return 0;
                    }
                });
            }
            else
            {
                // ユーザーデータ、提供データ
                List<GoodsUnitData> userList = new List<GoodsUnitData>();
                List<GoodsUnitData> offerList = new List<GoodsUnitData>();

                bool userFlg = false;
                foreach (GoodsUnitData goodsUnitData in goodsUnitDataList)
                {
                    userFlg = false;

                    foreach (TBOSearchU tboSearchU in this._userTBOSearchUList)
                    {
                        if ((goodsUnitData.GoodsMakerCd == tboSearchU.JoinDestMakerCd) &&
                            (goodsUnitData.GoodsNo.Trim() == tboSearchU.JoinDestPartsNo.Trim()))
                        {
                            userFlg = true;
                            goodsUnitData.DisplayOrder = tboSearchU.CarInfoJoinDispOrder;
                            userList.Add(goodsUnitData.Clone());
                            break;
                        }
                    }

                    if (!userFlg)
                    {
                        offerList.Add(goodsUnitData.Clone());
                    }
                }

                userList.Sort(delegate(GoodsUnitData x, GoodsUnitData y)
                {
                    if (x.DisplayOrder != y.DisplayOrder)
                    {
                        return x.DisplayOrder - y.DisplayOrder;
                    }
                    else if (x.GoodsMakerCd != y.GoodsMakerCd)
                    {
                        return x.GoodsMakerCd - y.GoodsMakerCd;
                    }
                    else if (x.GoodsNo.Trim() != y.GoodsNo.Trim())
                    {
                        return x.GoodsNo.Trim().CompareTo(y.GoodsNo.Trim());
                    }
                    else
                    {
                        return 0;
                    }
                });

                offerList.Sort(delegate(GoodsUnitData x, GoodsUnitData y)
                {
                    if (x.DisplayOrder != y.DisplayOrder)
                    {
                        return x.DisplayOrder - y.DisplayOrder;
                    }
                    else if (x.GoodsMakerCd != y.GoodsMakerCd)
                    {
                        return x.GoodsMakerCd - y.GoodsMakerCd;
                    }
                    else if (x.GoodsNo.Trim() != y.GoodsNo.Trim())
                    {
                        return x.GoodsNo.Trim().CompareTo(y.GoodsNo.Trim());
                    }
                    else
                    {
                        return 0;
                    }
                });

                goodsUnitDataList = new List<GoodsUnitData>();

                foreach (GoodsUnitData goodsUnitData in userList)
                {
                    goodsUnitDataList.Add(goodsUnitData.Clone());
                }

                foreach (GoodsUnitData goodsUnitData in offerList)
                {
                    goodsUnitDataList.Add(goodsUnitData.Clone());
                }
            }
        }

        /// <summary>
        /// 順位取得処理
        /// </summary>
        /// <param name="goodsUnitData">商品連結データ</param>
        /// <returns>順位</returns>
        /// <remarks>
        /// <br>Note       : 順位を取得します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/11/28</br>
        /// </remarks>
        private int GetRank(GoodsUnitData goodsUnitData)
        {
            foreach (TBOSearchU tboSearchU in this._userTBOSearchUList)
            {
                if ((tboSearchU.JoinDestMakerCd == goodsUnitData.GoodsMakerCd) &&
                    (tboSearchU.JoinDestPartsNo.Trim() == goodsUnitData.GoodsNo.Trim()))
                {
                    return tboSearchU.CarInfoJoinDispOrder;
                }
            }

            return goodsUnitData.DisplayOrder;
        }

        /// <summary>
        /// 順位取得処理
        /// </summary>
        /// <param name="makerCode">メーカーコード</param>
        /// <param name="rowIndex">行インデックス</param>
        /// <returns>順位</returns>
        /// <remarks>
        /// <br>Note       : 順位を取得します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/11/28</br>
        /// </remarks>
        private int GetRank(int targetMakerCode, int rowIndex)
        {
            int makerCode;

            for (int index = 0; index < this.uGrid_Details.Rows.Count; index++)
            {
                if (index == rowIndex)
                {
                    continue;
                }

                makerCode = StrObjToInt(this.uGrid_Details.Rows[index].Cells[COLUMN_MAKERCODE].Value);

                // メーカーコードが一致する場合
                if (makerCode == targetMakerCode)
                {
                    return IntObjToInt(this.uGrid_Details.Rows[index].Cells[COLUMN_RANK].Value);
                }
            }

            bool sameFlg = false;
            for (int rank = 1; rank <= 9999; rank++)
            {
                sameFlg = false;

                for (int index = 0; index < this.uGrid_Details.Rows.Count; index++)
                {
                    if (rank == IntObjToInt(this.uGrid_Details.Rows[index].Cells[COLUMN_RANK].Value))
                    {
                        sameFlg = true;
                        break;
                    }
                }

                if (!sameFlg)
                {
                    return rank;
                }
            }

            return (0);
        }

        /// <summary>
        /// 商品連結データ画面展開処理
        /// </summary>
        /// <param name="goodsUnitData">商品連結データ</param>
        /// <param name="rowIndex">行インデックス</param>
        /// <param name="newFlg">新規フラグ(True:新規 False:更新)</param>
        /// <remarks>
        /// <br>Note       : オブジェクトから画面にデータを展開します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/11/28</br>
        /// </remarks>
        private void GoodsUnitDataToScreen(GoodsUnitData goodsUnitData, int rowIndex, bool newFlg)
        {
            this.uGrid_Details.AfterCellUpdate -= this.uGrid_Details_AfterCellUpdate;
            
            CellsCollection cells = this.uGrid_Details.Rows[rowIndex].Cells;

            // 順位
            if (cells[COLUMN_RANK].Value == DBNull.Value)
            {
                if (newFlg)
                {
                    cells[COLUMN_RANK].Value = GetRank(goodsUnitData.GoodsMakerCd, rowIndex);
                }
                else
                {
                    cells[COLUMN_RANK].Value = GetRank(goodsUnitData);
                }
            }
            // 品番
            cells[COLUMN_GOODSNO].Value = goodsUnitData.GoodsNo.Trim();
            // 品名
            cells[COLUMN_GOODSNAME].Value = goodsUnitData.GoodsName.Trim();
            // DEL 2009/04/09 ------>>>
            //// メーカーコード
            //cells[COLUMN_MAKERCODE].Value = goodsUnitData.GoodsMakerCd.ToString("0000");
            //// メーカー名
            //cells[COLUMN_MAKERNAME].Value = goodsUnitData.MakerName.Trim();
            // DEL 2009/04/09 ------<<<

            // ADD 2009/04/09 ------>>>
            if (goodsUnitData.GoodsMakerCd == 0)
            {
                // メーカーコード
                cells[COLUMN_MAKERCODE].Value = "";
                // メーカー名
                cells[COLUMN_MAKERNAME].Value = "";
            }
            else
            {
                // メーカーコード
                cells[COLUMN_MAKERCODE].Value = goodsUnitData.GoodsMakerCd.ToString("0000");
                // メーカー名
                cells[COLUMN_MAKERNAME].Value = goodsUnitData.MakerName.Trim();
            }
            // ADD 2009/04/09 ------<<<
            
            if (goodsUnitData.BLGoodsCode == 0)
            {
                // BLコード
                cells[COLUMN_BLGOODSCODE].Value = "";
                // BLコード名
                cells[COLUMN_BLGOODSNAME].Value = "";
            }
            else
            {
                // BLコード
                cells[COLUMN_BLGOODSCODE].Value = goodsUnitData.BLGoodsCode.ToString("00000");
                // BLコード名
                cells[COLUMN_BLGOODSNAME].Value = this._tboSearchAcs.GetBLGoodsCdName(goodsUnitData.BLGoodsCode);
            }
            // 倉庫コード
            cells[COLUMN_WAREHOUSECODE].Value = "";
            // 棚番
            cells[COLUMN_WAREHOUSESHELFNO].Value = "";
            // 現在庫
            cells[COLUMN_SUPPLIERSTOCK].Value = "0";

            foreach (Stock stock in goodsUnitData.StockList)
            {
                if (stock.WarehouseCode.Trim() == this._secWarehouseCode.Trim())
                {
                    // 倉庫コード
                    cells[COLUMN_WAREHOUSECODE].Value = this._secWarehouseCode.Trim();
                    // 棚番
                    cells[COLUMN_WAREHOUSESHELFNO].Value = stock.WarehouseShelfNo.Trim();
                    // 現在庫
                    cells[COLUMN_SUPPLIERSTOCK].Value = stock.SupplierStock.ToString("###,##0");
                }
            }

            if (newFlg)
            {
                // QTY
                cells[COLUMN_QTY].Value = DBNull.Value;
                // 規格/特記事項
                cells[COLUMN_STANDARD].Value = DBNull.Value;
                // 提供区分
                cells[COLUMN_DIVISIONCODE].Value = 0;
                // 提供区分名
                cells[COLUMN_DIVISIONNAME].Value = "ユーザー";
            }
            else
            {
                if (CheckUserData(goodsUnitData))
                {
                    cells[COLUMN_QTY].Value = "";
                    cells[COLUMN_STANDARD].Value = "";

                    foreach (TBOSearchU tboSearchU in this._userTBOSearchUList)
                    {
                        if ((tboSearchU.JoinDestMakerCd == goodsUnitData.GoodsMakerCd) &&
                            (tboSearchU.JoinDestPartsNo.Trim() == goodsUnitData.GoodsNo.Trim()))
                        {
                            // QTY
                            cells[COLUMN_QTY].Value = tboSearchU.JoinQty.ToString("N");
                            // 規格/特記事項
                            cells[COLUMN_STANDARD].Value = tboSearchU.EquipSpecialNote.Trim();
                            break;
                        }
                    }
                    // 提供区分
                    cells[COLUMN_DIVISIONCODE].Value = 0;
                    // 提供区分名
                    cells[COLUMN_DIVISIONNAME].Value = "ユーザー";
                }
                else
                {
                    // QTY
                    cells[COLUMN_QTY].Value = goodsUnitData.JoinQty.ToString("N");
                    // 規格/特記事項
                    cells[COLUMN_STANDARD].Value = goodsUnitData.JoinSpecialNote.Trim();
                    // 提供区分
                    cells[COLUMN_DIVISIONCODE].Value = 1;
                    // 提供区分名
                    cells[COLUMN_DIVISIONNAME].Value = "提供";
                }
            }
            
            // 商品連結データ
            cells[COLUMN_GOODSUNITDATA].Value = goodsUnitData.Clone();

            // セルEnabled制御
            ChangeGridCellEnabled(rowIndex, true);

            this.uGrid_Details.AfterCellUpdate += this.uGrid_Details_AfterCellUpdate;
        }

        /// <summary>
        /// 画面情報TBOマスタクラス格納処理
        /// </summary>
        /// <param name="tboSearchUList">TBOマスタリスト</param>
        /// <param name="goodsUnitDataList">商品連結データリスト</param>
        /// <remarks>
        /// <br>Note       : 画面情報からTBOマスタオブジェクトにデータを格納します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/11/28</br>
        /// </remarks>
        private void ScreenToTBOSearchUList(out ArrayList tboSearchUList, out ArrayList goodsUnitDataList)
        {
            tboSearchUList = new ArrayList();
            goodsUnitDataList = new ArrayList();

            TBOSearchU tboSearchU;

            for (int index = 0; index < this.uGrid_Details.Rows.Count; index++)
            {
                // 提供データ(TBOマスタ)は保存対象としない
                if (IntObjToInt(this.uGrid_Details.Rows[index].Cells[COLUMN_DIVISIONCODE].Value) == 1)
                {
                    continue;
                }

                // 品番・メーカー・QTYが未入力の場合
                if ((StrObjToString(this.uGrid_Details.Rows[index].Cells[COLUMN_GOODSNO].Value) == "") &&
                    (StrObjToInt(this.uGrid_Details.Rows[index].Cells[COLUMN_MAKERCODE].Value) == 0) &&
                    (StrObjToDouble(this.uGrid_Details.Rows[index].Cells[COLUMN_QTY].Value) == 0))
                {
                    continue;
                }

                tboSearchU = new TBOSearchU();

                // 企業コード
                tboSearchU.EnterpriseCode = this._enterpriseCode;
                // BLコード
                tboSearchU.BLGoodsCode = StrObjToInt(this.uGrid_Details.Rows[index].Cells[COLUMN_BLGOODSCODE].Value);
                // 装備分類
                tboSearchU.EquipGenreCode = (int)this.tComboEditor_EquipGenreCode.Value;
                // 装備名
                tboSearchU.EquipName = this.tEdit_EquipGenreName.DataText.Trim();
                // 順位
                tboSearchU.CarInfoJoinDispOrder = IntObjToInt(this.uGrid_Details.Rows[index].Cells[COLUMN_RANK].Value);
                // メーカーコード
                tboSearchU.JoinDestMakerCd = StrObjToInt(this.uGrid_Details.Rows[index].Cells[COLUMN_MAKERCODE].Value);
                // メーカー名
                tboSearchU.JoinDestMakerName = StrObjToString(this.uGrid_Details.Rows[index].Cells[COLUMN_MAKERNAME].Value);
                // 品番
                tboSearchU.JoinDestPartsNo = StrObjToString(this.uGrid_Details.Rows[index].Cells[COLUMN_GOODSNO].Value);
                // 品名
                tboSearchU.JoinDestGoodsName = StrObjToString(this.uGrid_Details.Rows[index].Cells[COLUMN_GOODSNAME].Value);
                // QTY
                tboSearchU.JoinQty = StrObjToDouble(this.uGrid_Details.Rows[index].Cells[COLUMN_QTY].Value);
                // 装備規格・特記事項
                tboSearchU.EquipSpecialNote = StrObjToString(this.uGrid_Details.Rows[index].Cells[COLUMN_STANDARD].Value);

                if (this.uGrid_Details.Rows[index].Cells[COLUMN_GOODSUNITDATA].Value != DBNull.Value)
                {
                    GoodsUnitData goodsUnitData = (GoodsUnitData)this.uGrid_Details.Rows[index].Cells[COLUMN_GOODSUNITDATA].Value;

                    // 提供データ(商品)
                    if (goodsUnitData.OfferKubun >= 3)
                    {
                        goodsUnitData.OfferDate = DateTime.MinValue;
                        if (goodsUnitData.GoodsPriceList != null)
                        {
                            foreach (GoodsPrice price in goodsUnitData.GoodsPriceList)
                            {
                                price.OfferDate = DateTime.MinValue;
                            }
                        }

                        goodsUnitDataList.Add(goodsUnitData.Clone());
                    }
                }

                tboSearchUList.Add(tboSearchU);
            }
        }

        /// <summary>
        /// TBOマスタマスタ保存処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : TBOマスタマスタを保存します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/11/28</br>
        /// </remarks>
        private bool SaveProc()
        {
            // 入力データチェック
            if (CheckScreenInput() != true)
            {
                return (false);
            }

            // 画面情報格納
            ArrayList saveTBOList;
            ArrayList saveGoodsList;
            ScreenToTBOSearchUList(out saveTBOList, out saveGoodsList);

            int status;

            //-------------------------------------
            // 保存処理
            //-------------------------------------
            if (saveTBOList.Count > 0)
            {
                status = this._tboSearchAcs.WriteRelation(saveTBOList, saveGoodsList);
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        {
                            // 登録完了ダイアログ表示
                            SaveCompletionDialog dialog = new SaveCompletionDialog();
                            dialog.ShowDialog(2);

                            // 再検索
                            int totalCount = 0;
                            Search(ref totalCount, 0);
                            break;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                        {
                            // 排他処理
                            ExclusiveTransaction(status);
                            return (false);
                        }
                    default:
                        {
                            // 登録失敗
                            ShowMessageBox(emErrorLevel.ERR_LEVEL_STOP,
                                           "SaveProc",
                                           "登録に失敗しました。",
                                           status,
                                           MessageBoxButtons.OK);
                            return (false);
                        }
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
        /// <br>Date       : 2008/11/28</br>
        /// </remarks>
        private bool CheckScreenInput()
        {
            string errMsg = "";

            try
            {
                if (this.tComboEditor_EquipGenreCode.Value == null)
                {
                    errMsg = "装備分類を選択してください。";
                    this.tComboEditor_EquipGenreCode.Focus();
                    return (false);
                }

                if (this.tEdit_EquipGenreName.DataText.Trim() == "")
                {
                    errMsg = "装備名を入力してください。";
                    this.tEdit_EquipGenreName.Focus();
                    return (false);
                }

                bool inputFlg = false;

                for (int index = 0; index < this.uGrid_Details.Rows.Count; index++)
                {
                    CellsCollection cells = this.uGrid_Details.Rows[index].Cells;

                    // 品番・メーカー・QTYが未入力の場合
                    if ((StrObjToString(cells[COLUMN_GOODSNO].Value) == "") &&
                        (StrObjToInt(cells[COLUMN_MAKERCODE].Value) == 0) &&
                        (StrObjToDouble(cells[COLUMN_QTY].Value) == 0))
                    {
                        continue;
                    }

                    inputFlg = true;

                    if (StrObjToString(cells[COLUMN_GOODSNO].Value) == "")
                    {
                        errMsg = "品番を入力してください。";
                        this.uGrid_Details.Rows[index].Cells[COLUMN_GOODSNO].Activate();
                        this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);

                        return (false);
                    }

                    //if (StrObjToInt(cells[COLUMN_MAKERCODE].Value) == 0)  // DEL 2009/04/09
                    // ADD 2009/04/09
                    if ((cells[COLUMN_MAKERCODE].Activation == Activation.AllowEdit) &&
                        (StrObjToInt(cells[COLUMN_MAKERCODE].Value) == 0))
                    {
                        errMsg = "メーカーコードを入力してください。";
                        //this.uGrid_Details.Rows[index].Cells[COLUMN_GOODSNO].Activate();  // DEL 2009/04/09
                        this.uGrid_Details.Rows[index].Cells[COLUMN_MAKERCODE].Activate();  // ADD 2009/04/09
                        this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);

                        return (false);
                    }

                    // ユーザーデータの場合のみ、存在チェックを行います
                    if (IntObjToInt(cells[COLUMN_DIVISIONCODE].Value) == 0)
                    {
                        if (StrObjToString(cells[COLUMN_GOODSNAME].Value) == "")
                        {
                            errMsg = "商品マスタに登録されていません。";
                            this.uGrid_Details.Rows[index].Cells[COLUMN_GOODSNO].Activate();
                            this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);

                            return (false);
                        }

                        if (StrObjToDouble(cells[COLUMN_QTY].Value) == 0)
                        {
                            errMsg = "QTYを入力してください。";
                            this.uGrid_Details.Rows[index].Cells[COLUMN_QTY].Activate();
                            this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);

                            return (false);
                        }
                    }
                }

                if (!inputFlg)
                {
                    errMsg = "装備名を入力してください。";
                    this.tEdit_EquipGenreName.Focus();
                    return (false);
                }
            }
            finally
            {
                if (errMsg.Length > 0)
                {
                    ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                                   errMsg,
                                   0,
                                   MessageBoxButtons.OK,
                                   MessageBoxDefaultButton.Button1);
                }
            }

            return (true);
        }

        /// <summary>
        /// 商品登録前チェック処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 商品登録前にチェックを行います。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/11/28</br>
        /// </remarks>
        private bool CheckBeforeGoodsRegist()
        {
            string errMsg = "";

            try
            {
                if ((this.uGrid_Details.ActiveCell == null) && (this.uGrid_Details.ActiveRow == null))
                {
                    errMsg = "商品登録を行う行を選択してください。";
                    return (false);
                }

                // 対象行取得
                int rowIndex;
                if (this.uGrid_Details.ActiveCell == null)
                {
                    rowIndex = this.uGrid_Details.ActiveRow.Index;
                }
                else
                {
                    rowIndex = this.uGrid_Details.ActiveCell.Row.Index;
                }

                string goodsNo = StrObjToString(this.uGrid_Details.Rows[rowIndex].Cells[COLUMN_GOODSNO].Value);
                int makerCode = StrObjToInt(this.uGrid_Details.Rows[rowIndex].Cells[COLUMN_MAKERCODE].Value);

                if (goodsNo == "")
                {
                    errMsg = "品番を入力してください。";
                    this.uGrid_Details.Focus();
                    this.uGrid_Details.Rows[rowIndex].Cells[COLUMN_GOODSNO].Activate();
                    this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                    return (false);
                }
                if (makerCode == 0)
                {
                    errMsg = "メーカーコードを入力してください。";
                    this.uGrid_Details.Focus();
                    this.uGrid_Details.Rows[rowIndex].Cells[COLUMN_MAKERCODE].Activate();
                    this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                    return (false);
                }
            }
            finally
            {
                if (errMsg.Length > 0)
                {
                    ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                                   errMsg,
                                   0,
                                   MessageBoxButtons.OK,
                                   MessageBoxDefaultButton.Button1);
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
        /// <br>Date       : 2008/11/28</br>
        /// </remarks>
        private bool CompareOriginalScreen()
        {
            // 画面情報取得(ユーザーデータ)
            ArrayList tboSearchUList;
            ArrayList goodsUnitDataList;
            ScreenToTBOSearchUList(out tboSearchUList, out goodsUnitDataList);

            if (tboSearchUList.Count != this._userTBOSearchUList.Count)
            {
                return (false);
            }

            bool sameFlg;
            foreach (TBOSearchU tboSearchU in this._userTBOSearchUList)
            {
                sameFlg = false;

                foreach (TBOSearchU newTBOSearchU in tboSearchUList)
                {
                    if ((tboSearchU.CarInfoJoinDispOrder == newTBOSearchU.CarInfoJoinDispOrder) &&
                        (tboSearchU.JoinDestMakerCd == newTBOSearchU.JoinDestMakerCd) &&
                        (tboSearchU.JoinDestPartsNo.Trim() == newTBOSearchU.JoinDestPartsNo.Trim()) &&
                        (tboSearchU.JoinQty == newTBOSearchU.JoinQty) &&
                        (tboSearchU.EquipSpecialNote.Trim() == newTBOSearchU.EquipSpecialNote.Trim()))
                    {
                        sameFlg = true;
                        break;
                    }
                }

                if (!sameFlg)
                {
                    return (false);
                }
            }

            return (true);
        }

        /// <summary>
        /// 新規行作成処理
        /// </summary>
        /// <param name="uGrid">グリッド</param>
        /// <remarks>
        /// <br>Note       : グリッドに行を追加します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/11/28</br>
        /// </remarks>
        private void CreateNewRow(ref UltraGrid uGrid)
        {
            this.uGrid_Details.AfterCellUpdate -= this.uGrid_Details_AfterCellUpdate;

            // 行追加
            uGrid.DisplayLayout.Bands[0].AddNew();

            // 行番号設定
            uGrid.Rows[uGrid.Rows.Count - 1].Cells[COLUMN_NO].Value = uGrid.Rows.Count;
            
            this.uGrid_Details.AfterCellUpdate += this.uGrid_Details_AfterCellUpdate;
        }

        /// <summary>
        /// グリッド行クリア処理
        /// </summary>
        /// <param name="rowIndex">対象行インデックス</param>
        /// <remarks>
        /// <br>Note       : グリッドの対象行をクリアします。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/11/28</br>
        /// </remarks>
        private void ClearRow(int rowIndex)
        {
            this.uGrid_Details.AfterCellUpdate -= this.uGrid_Details_AfterCellUpdate;

            this.uGrid_Details.Rows[rowIndex].Cells[COLUMN_RANK].Value = DBNull.Value;
            this.uGrid_Details.Rows[rowIndex].Cells[COLUMN_GOODSNO].Value = DBNull.Value;
            this.uGrid_Details.Rows[rowIndex].Cells[COLUMN_GOODSNAME].Value = DBNull.Value;
            this.uGrid_Details.Rows[rowIndex].Cells[COLUMN_MAKERCODE].Value = DBNull.Value;
            this.uGrid_Details.Rows[rowIndex].Cells[COLUMN_MAKERNAME].Value = DBNull.Value;
            this.uGrid_Details.Rows[rowIndex].Cells[COLUMN_BLGOODSCODE].Value = DBNull.Value;
            this.uGrid_Details.Rows[rowIndex].Cells[COLUMN_BLGOODSNAME].Value = DBNull.Value;
            this.uGrid_Details.Rows[rowIndex].Cells[COLUMN_QTY].Value = DBNull.Value;
            this.uGrid_Details.Rows[rowIndex].Cells[COLUMN_WAREHOUSECODE].Value = DBNull.Value;
            this.uGrid_Details.Rows[rowIndex].Cells[COLUMN_WAREHOUSESHELFNO].Value = DBNull.Value;
            this.uGrid_Details.Rows[rowIndex].Cells[COLUMN_SUPPLIERSTOCK].Value = DBNull.Value;
            this.uGrid_Details.Rows[rowIndex].Cells[COLUMN_STANDARD].Value = DBNull.Value;
            this.uGrid_Details.Rows[rowIndex].Cells[COLUMN_DIVISIONCODE].Value = DBNull.Value;
            this.uGrid_Details.Rows[rowIndex].Cells[COLUMN_DIVISIONNAME].Value = DBNull.Value;
            this.uGrid_Details.Rows[rowIndex].Cells[COLUMN_GOODSUNITDATA].Value = DBNull.Value;

            this.uGrid_Details.AfterCellUpdate += this.uGrid_Details_AfterCellUpdate;
        }

        /// <summary>
        /// グリッド操作ボタンEnabled制御処理
        /// </summary>
        /// <param name="enabled">パラメータ(True:押下可　False:押下不可)</param>
        /// <remarks>
        /// <br>Note       : グリッド操作ボタンの制御を行います。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/11/28</br>
        /// </remarks>
        private void ChangeButtonEnabled(bool enabled)
        {
            this.RowDelete_Button.Enabled = enabled;
            this.GoodsRegist_Button.Enabled = enabled;

            if (!enabled)
            {
                this.uGrid_Details.ActiveCell = null;
                this.uGrid_Details.ActiveRow = null;
            }
        }

        /// <summary>
        /// セルEnabled制御処理
        /// </summary>
        /// <param name="rowIndex">行インデックス</param>
        /// <param name="editFlg">編集フラグ(True:編集可　False:編集不可)</param>
        /// <remarks>
        /// <br>Note       : セルの入力制御を行います。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/11/28</br>
        /// </remarks>
        private void ChangeGridCellEnabled(int rowIndex, bool editFlg)
        {
            CellsCollection cells = this.uGrid_Details.Rows[rowIndex].Cells;

            // ユーザーデータ
            if (IntObjToInt(cells[COLUMN_DIVISIONCODE].Value) == 0)
            {
                if (editFlg)
                {
                    cells[COLUMN_GOODSNO].Activation = Activation.AllowEdit;
                    cells[COLUMN_MAKERCODE].Activation = Activation.AllowEdit;
                    cells[COLUMN_GOODSNO].Appearance.BackColor = Color.Empty;
                    cells[COLUMN_MAKERCODE].Appearance.BackColor = Color.Empty;
                }
                else
                {
                    cells[COLUMN_GOODSNO].Activation = Activation.NoEdit;
                    cells[COLUMN_MAKERCODE].Activation = Activation.NoEdit;
                    cells[COLUMN_GOODSNO].Appearance.BackColor = Color.Gainsboro;
                    cells[COLUMN_MAKERCODE].Appearance.BackColor = Color.Gainsboro;
                }

                cells[COLUMN_QTY].Activation = Activation.AllowEdit;
                cells[COLUMN_STANDARD].Activation = Activation.AllowEdit;
                cells[COLUMN_QTY].Appearance.BackColor = Color.Empty;
                cells[COLUMN_STANDARD].Appearance.BackColor = Color.Empty;
            }
            // 提供データ
            else
            {
                cells[COLUMN_GOODSNO].Activation = Activation.NoEdit;
                cells[COLUMN_MAKERCODE].Activation = Activation.NoEdit;
                cells[COLUMN_QTY].Activation = Activation.NoEdit;
                cells[COLUMN_STANDARD].Activation = Activation.NoEdit;

                cells[COLUMN_GOODSNO].Appearance.BackColor = Color.Gainsboro;
                cells[COLUMN_MAKERCODE].Appearance.BackColor = Color.Gainsboro;
                cells[COLUMN_QTY].Appearance.BackColor = Color.Gainsboro;
                cells[COLUMN_STANDARD].Appearance.BackColor = Color.Gainsboro;
            }
        }

        #region セル値変換
        /// <summary>
        /// セル値変換処理
        /// </summary>
        /// <param name="cellValue">セル値</param>
        /// <remarks>
        /// <br>Note        : セル値をInt型に変換します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/11/28</br>
        /// </remarks>
        private int IntObjToInt(object cellValue)
        {
            if ((cellValue == DBNull.Value) || (cellValue == null))
            {
                return 0;
            }

            return (int)cellValue;
        }

        /// <summary>
        /// セル値変換処理
        /// </summary>
        /// <param name="cellValue">セル値</param>
        /// <remarks>
        /// <br>Note        : セル値をString型に変換します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/11/28</br>
        /// </remarks>
        private string StrObjToString(object cellValue)
        {
            if ((cellValue == DBNull.Value) || (cellValue == null))
            {
                return "";
            }

            return (string)cellValue;
        }

        /// <summary>
        /// セル値変換処理
        /// </summary>
        /// <param name="cellValue">セル値</param>
        /// <remarks>
        /// <br>Note        : セル値をInt型に変換します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/11/28</br>
        /// </remarks>
        private int StrObjToInt(object cellValue)
        {
            if ((cellValue == DBNull.Value) || (cellValue == null) || ((string)cellValue == ""))
            {
                return 0;
            }

            return int.Parse((string)cellValue);
        }

        /// <summary>
        /// セル値変換処理
        /// </summary>
        /// <param name="cellValue">セル値</param>
        /// <remarks>
        /// <br>Note        : セル値をInt型に変換します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/11/28</br>
        /// </remarks>
        private double StrObjToDouble(object cellValue)
        {
            if ((cellValue == DBNull.Value) || (cellValue == null) || ((string)cellValue == ""))
            {
                return 0;
            }

            return double.Parse((string)cellValue);
        }
        #endregion セル値変換

        #region メッセージボックス表示
        /// <summary>
        /// メッセージボックス表示処理
        /// </summary>
        /// <param name="errLevel">エラーレベル</param>
        /// <param name="message">表示するメッセージ</param>
        /// <param name="status">ステータス値</param>
        /// <param name="msgButton">表示するボタン</param>
        /// <param name="defaultButton">初期表示ボタン</param>
        /// <returns>DialogResult</returns>
        /// <remarks>
        /// <br>Note       : メッセージボックスを表示します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/11/28</br>
        /// </remarks>
        private DialogResult ShowMessageBox(emErrorLevel errLevel, string message, int status, MessageBoxButtons msgButton, MessageBoxDefaultButton defaultButton)
        {
            DialogResult dialogResult;
            dialogResult = TMsgDisp.Show(this,                              // 親ウィンドウフォーム
                                         errLevel,                          // エラーレベル
                                         ASSEMBLY_ID,                        // アセンブリID
                                         message,                           // 表示するメッセージ
                                         status,                            // ステータス値
                                         msgButton,                         // 表示するボタン
                                         defaultButton);                    // 初期表示ボタン
            return dialogResult;
        }

        /// <summary>
        /// メッセージボックス表示処理
        /// </summary>
        /// <param name="errLevel">エラーレベル</param>
        /// <param name="methodName">処理名称</param>
        /// <param name="message">表示するメッセージ</param>
        /// <param name="status">ステータス値</param>
        /// <param name="msgButton">表示するボタン</param>
        /// <returns>DialogResult</returns>
        /// <remarks>
        /// <br>Note       : メッセージボックスを表示します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/11/28</br>
        /// </remarks>
        private DialogResult ShowMessageBox(emErrorLevel errLevel, string methodName, string message, int status, MessageBoxButtons msgButton)
        {
            DialogResult dialogResult;
            dialogResult = TMsgDisp.Show(this, 						        // 親ウィンドウフォーム
                                         errLevel,			                // エラーレベル
                                         this.Name,						    // プログラム名称
                                         ASSEMBLY_ID, 		  　　		    // アセンブリID
                                         methodName,						// 処理名称
                                         "",					            // オペレーション
                                         message,	                        // 表示するメッセージ
                                         status,							// ステータス値
                                         this._tboSearchAcs,	            // エラーが発生したオブジェクト
                                         msgButton,         			  	// 表示するボタン
                                         MessageBoxDefaultButton.Button1);	// 初期表示ボタン

            return dialogResult;
        }
        #endregion メッセージボックス表示

        /// <summary>
        /// 装備名ガイド表示処理
        /// </summary>
        /// <param name="equipName">装備名</param>
        /// <param name="equipGanreCode">装備分類</param>
        /// <param name="searchName">検索名(曖昧検索対応)</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 装備名ガイドを表示します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/11/28</br>
        /// </remarks>
        private int ShowEquipNameGuide(out string equipName, int equipGanreCode, string searchName)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            equipName = "";

            try
            {
                this.Cursor = Cursors.WaitCursor;

                status = this._tboSearchAcs.ExecuteGuid(this._enterpriseCode, equipGanreCode, searchName, out equipName);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }

            return (status);
        }

        /// <summary>
        /// 商品在庫マスタ起動処理
        /// </summary>
        /// <param name="goodsUnitData">商品連結データ</param>
        /// <param name="makerCode">メーカーコード</param>
        /// <param name="goodsNo">品番</param>
        /// <param name="newFlg">新規フラグ(True:新規モード　False:更新モード)</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 商品在庫マスタを起動します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/11/28</br>
        /// <br>Update Note: 王君</br>
        /// <br>Date       : 2013/05/02</br>
        /// <br>管理番号   : 10901273-00 2013/06/18配信分</br>
        /// <br>           : Redmine#35434の対応</br>
        /// <br>Update Note: 王君</br>
        /// <br>Date       : 2013/06/03</br>
        /// <br>管理番号   : 10901273-00 2013/06/18配信分</br>
        /// <br>           : Redmine#35434の対応</br>
        /// <br>Update Note: 王君</br>
        /// <br>Date       : 2013/06/14</br>
        /// <br>管理番号   : 10901273-00 2013/06/18配信分</br>
        /// <br>           : Redmine#35434の対応</br>
        /// </remarks>
        private int ShowGoodsStockMaster(ref GoodsUnitData goodsUnitData, int makerCode, string goodsNo, bool newFlg)
        {
            // ----- ADD 王君　2013/06/14 Redmine#35434 ----->>>>>
            if (this.flag == 1)
            {
                return (0);
            }
            // ----- ADD 王君　2013/06/14 Redmine#35434 -----<<<<<
            // ----- ADD 王君　2013/05/02 Redmine#35434 ----->>>>>
            if (this._allDefSet != null)
            {
                if (this._allDefSet.GoodsStockMSTBootDiv == 0)
                {
                    // ----- ADD 王君　2013/05/02 Redmine#35434 -----<<<<<
                    //PMKHN09380UA goodsStockMaster = new PMKHN09380UA(this._tboSearchAcs.GoodsAccess); // DEL  王君　2013/06/03 Redmine#35434
                    MAKHN09280UA goodsStockMaster = new MAKHN09280UA(this._tboSearchAcs.GoodsAccess); // ADD  王君　2013/06/03 Redmine#35434
                    // 新規モード
                    if (newFlg)
                    {
                        this.flag = 1;// ADD 王君 2013/06/14 Redmine#35434
                        goodsStockMaster.ShowDialog(this, ref goodsUnitData, makerCode, goodsNo);
                        this.flag = 0;// ADD 王君 2013/06/14 Redmine#35434
                    }
                    // 更新モード
                    else
                    {
                        // ユーザーデータ
                        if (goodsUnitData.OfferKubun < 3)
                        {
                            // 論理削除されている在庫がある場合は取得
                            List<Stock> stockList;
                            int status = this._tboSearchAcs.GetStockList(out stockList, goodsUnitData.Clone());
                            if (status == 0)
                            {
                                goodsUnitData.StockList = new List<Stock>();
                                goodsUnitData.StockList = stockList;
                            }
                        }
                        // 提供データ
                        else
                        {
                            goodsUnitData.CreateDateTime = DateTime.Now;// ADD 王君 2013/06/14 Redmine#35434
                            // 提供日付を削除
                            goodsUnitData.OfferDate = DateTime.MinValue;
                            if (goodsUnitData.GoodsPriceList != null)
                            {
                                foreach (GoodsPrice price in goodsUnitData.GoodsPriceList)
                                {
                                    price.OfferDate = DateTime.MinValue;
                                }
                            }
                        }
                        this.flag = 1;// ADD 王君 2013/06/14 Redmine#35434
                        goodsStockMaster.ShowDialog(this, ref goodsUnitData);
                        this.flag = 0;// ADD 王君 2013/06/14 Redmine#35434
                    }
                    // ----- ADD 王君　2013/05/02 Redmine#35434 ----->>>>>
                }
                else
                {
                    PMKHN09380UA goodsStockMaster = new PMKHN09380UA(this._tboSearchAcs.GoodsAccess);
                    // 新規モード
                    if (newFlg)
                    {
                        this.flag = 1;// ADD 王君 2013/06/14 Redmine#35434
                        goodsStockMaster.ShowDialog(this, ref goodsUnitData, makerCode, goodsNo);
                        this.flag = 0;// ADD 王君 2013/06/14 Redmine#35434
                    }
                    // 更新モード
                    else
                    {
                        // ユーザーデータ
                        if (goodsUnitData.OfferKubun < 3)
                        {
                            // 論理削除されている在庫がある場合は取得
                            List<Stock> stockList;
                            int status = this._tboSearchAcs.GetStockList(out stockList, goodsUnitData.Clone());
                            if (status == 0)
                            {
                                goodsUnitData.StockList = new List<Stock>();
                                goodsUnitData.StockList = stockList;
                            }
                        }
                        // 提供データ
                        else
                        {
                            goodsUnitData.CreateDateTime = DateTime.Now;// ADD 王君 2013/06/14 Redmine#35434
                            // 提供日付を削除
                            goodsUnitData.OfferDate = DateTime.MinValue;
                            if (goodsUnitData.GoodsPriceList != null)
                            {
                                foreach (GoodsPrice price in goodsUnitData.GoodsPriceList)
                                {
                                    price.OfferDate = DateTime.MinValue;
                                }
                            }
                        }
                        this.flag = 1;// ADD 王君 2013/06/14 Redmine#35434
                        goodsStockMaster.ShowDialog(this, ref goodsUnitData);
                        this.flag = 0;// ADD 王君 2013/06/14 Redmine#35434
                    }
                }
            }
            // ----- ADD 王君　2013/05/02 Redmine#35434 -----<<<<<
            return (0);
        }

        /// <summary>
        /// 商品在庫マスタ起動後処理
        /// </summary>
        /// <param name="goodsUnitData">商品連結データ</param>
        /// <param name="rowIndex">行インデックス</param>
        /// <remarks>
        /// <br>Note       : 商品在庫マスタを起動後の処理をします。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/11/28</br>
        /// </remarks>
        private void AfterShowGoodsStockMaster(GoodsUnitData goodsUnitData, int rowIndex)
        {
            // グリッドに反映
            this.uGrid_Details.AfterCellUpdate -= this.uGrid_Details_AfterCellUpdate;

            // 品番
            this.uGrid_Details.Rows[rowIndex].Cells[COLUMN_GOODSNO].Value = goodsUnitData.GoodsNo.Trim();

            // 品名
            this.uGrid_Details.Rows[rowIndex].Cells[COLUMN_GOODSNAME].Value = goodsUnitData.GoodsName.Trim();

            if (goodsUnitData.BLGoodsCode == 0)
            {
                // BLコード
                this.uGrid_Details.Rows[rowIndex].Cells[COLUMN_BLGOODSCODE].Value = DBNull.Value;
                // BLコード名
                this.uGrid_Details.Rows[rowIndex].Cells[COLUMN_BLGOODSNAME].Value = DBNull.Value;
            }
            else
            {
                // BLコード
                this.uGrid_Details.Rows[rowIndex].Cells[COLUMN_BLGOODSCODE].Value = goodsUnitData.BLGoodsCode.ToString("00000");
                // BLコード名
                this.uGrid_Details.Rows[rowIndex].Cells[COLUMN_BLGOODSNAME].Value = this._tboSearchAcs.GetBLGoodsCdName(goodsUnitData.BLGoodsCode);
            }

            // メーカーコード
            this.uGrid_Details.Rows[rowIndex].Cells[COLUMN_MAKERCODE].Value = goodsUnitData.GoodsMakerCd.ToString("0000");
            
            // メーカ名
            this.uGrid_Details.Rows[rowIndex].Cells[COLUMN_MAKERNAME].Value = goodsUnitData.MakerName.Trim();

            foreach (Stock stock in goodsUnitData.StockList)
            {
                if (stock.WarehouseCode.Trim() == this._secWarehouseCode.Trim())
                {
                    // 倉庫コード
                    this.uGrid_Details.Rows[rowIndex].Cells[COLUMN_WAREHOUSECODE].Value = this._secWarehouseCode.Trim();
                    // 棚番
                    this.uGrid_Details.Rows[rowIndex].Cells[COLUMN_WAREHOUSESHELFNO].Value = stock.WarehouseShelfNo.Trim();
                    // 現在庫数
                    this.uGrid_Details.Rows[rowIndex].Cells[COLUMN_SUPPLIERSTOCK].Value = stock.SupplierStock.ToString("###,##0");
                    break;
                }
                else
                {
                    // 倉庫コード
                    this.uGrid_Details.Rows[rowIndex].Cells[COLUMN_WAREHOUSECODE].Value = DBNull.Value;
                    // 棚番
                    this.uGrid_Details.Rows[rowIndex].Cells[COLUMN_WAREHOUSESHELFNO].Value = DBNull.Value;
                    // 現在庫数
                    this.uGrid_Details.Rows[rowIndex].Cells[COLUMN_SUPPLIERSTOCK].Value = DBNull.Value;
                }
            }

            // 提供区分
            this.uGrid_Details.Rows[rowIndex].Cells[COLUMN_DIVISIONCODE].Value = 0;
            // 提供区分名称
            this.uGrid_Details.Rows[rowIndex].Cells[COLUMN_DIVISIONNAME].Value = "ユーザー";

            if (IntObjToInt(this.uGrid_Details.Rows[rowIndex].Cells[COLUMN_RANK].Value) == 0)
            {
                // 順位
                this.uGrid_Details.Rows[rowIndex].Cells[COLUMN_RANK].Value = GetRank(goodsUnitData.GoodsMakerCd, rowIndex);
            }

            this.uGrid_Details.Rows[rowIndex].Cells[COLUMN_GOODSUNITDATA].Value = goodsUnitData.Clone();

            this.uGrid_Details.AfterCellUpdate += this.uGrid_Details_AfterCellUpdate;
        }

        #endregion ■ Private Methods


        #region ■ Control Events

        /// <summary>
        /// Load イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : フォームロード時に発生します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/11/28</br>
        /// </remarks>
        private void PMKEN09110UA_Load(object sender, EventArgs e)
        {
            // アイコンリソース管理クラスを使用して、アイコンを表示する
            ImageList imageList24 = IconResourceManagement.ImageList24;
            ImageList imageList16 = IconResourceManagement.ImageList16;

            this.Ok_Button.Appearance.Image = imageList24.Images[(int)Size24_Index.SAVE];
            this.Cancel_Button.Appearance.Image = imageList24.Images[(int)Size24_Index.CLOSE];
            this.EquipGenreGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];

            // コントロールサイズ設定
            this.tComboEditor_EquipGenreCode.Size = new Size(144, 24);
            this.tEdit_EquipGenreName.Size = new Size(496, 24);
        }

        /// <summary>
        /// FormClosing イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : 画面が閉じられる時に発生します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/11/28</br>
        /// </remarks>
        private void PMKEN09110UA_FormClosing(object sender, FormClosingEventArgs e)
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
        /// VisibleChanged イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : 画面の表示状態が変更された時に発生します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/11/28</br>
        /// </remarks>
        private void PMKEN09110UA_VisibleChanged(object sender, EventArgs e)
        {
            this.Owner.Activate();

            // 自分自身が非表示になった場合は以下の処理をキャンセルする。
            if (this.Visible == false)
            {
                return;
            }

            // 画面クリア処理
            ClearScreen();

            Initial_Timer.Enabled = true;
        }

        /// <summary>
        /// Button_Click イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : 装備名ガイドボタンがクリックされた時に発生します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/11/28</br>
        /// </remarks>
        private void EquipGenreGuide_Button_Click(object sender, EventArgs e)
        {
            string equipName;
            int equipGanreCode = (int)this.tComboEditor_EquipGenreCode.Value;

            int status = ShowEquipNameGuide(out equipName, equipGanreCode, "*");
            if (status == 0)
            {
                if (equipName != this._prevEquipName.Trim())
                {
                    // 装備名設定
                    this.tEdit_EquipGenreName.DataText = equipName.Trim();
                    this._prevEquipName = equipName.Trim();

                    List<GoodsUnitData> goodsUnitDataList;

                    // 2009.03.30 30413 犬飼 商品マスタ論理削除時の対応 >>>>>>START
                    // ユーザーデータ取得
                    this._userTBOSearchUList = FindUserTBOSearchUList(equipGanreCode, equipName);

                    // 商品連結データ検索処理
                    status = SearchGoodsUnitDataList(out goodsUnitDataList, equipGanreCode, equipName);
                    //if ((status == 0) && (goodsUnitDataList != null) && (goodsUnitDataList.Count > 0))
                    if ((status == 0) && ((goodsUnitDataList != null) && (goodsUnitDataList.Count > 0)) ||
                        ((this._userTBOSearchUList != null) && (this._userTBOSearchUList.Count > 0)))
                    {
                        //// ユーザーデータ取得
                        //this._userTBOSearchUList = FindUserTBOSearchUList(equipGanreCode, equipName);

                        // 商品連結データ検索後処理
                        AfterSearchGoodsUnitDataList(goodsUnitDataList);
                    }
                    else
                    {
                        this.uGrid_Details.Rows[0].Cells[COLUMN_GOODSNO].Activate();
                        this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                    }
                    // 2009.03.30 30413 犬飼 商品マスタ論理削除時の対応 <<<<<<END
                }
            }
        }

        /// <summary>
        /// Button_Click イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : 保存ボタンがクリックされた時に発生します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/11/28</br>
        /// </remarks>
        private void Ok_Button_Click(object sender, EventArgs e)
        {
            // 保存処理
            SaveProc();
        }

        /// <summary>
        /// Button_Click イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : 閉じるボタンがクリックされた時に発生します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/11/28</br>
        /// </remarks>
        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            // 画面情報比較
            if (!CompareOriginalScreen())
            {
                //画面情報が変更されていた場合は、保存確認メッセージを表示する
                DialogResult res = ShowMessageBox(emErrorLevel.ERR_LEVEL_SAVECONFIRM,
                                                  "",
                                                  0,
                                                  MessageBoxButtons.YesNoCancel,
                                                  MessageBoxDefaultButton.Button1);

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
                            this.Cancel_Button.Focus();
                            return;
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
        /// Button_Click イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : 行削除ボタンがクリックされた時に発生します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/11/28</br>
        /// </remarks>
        private void RowDelete_Button_Click(object sender, EventArgs e)
        {
            // アクティブ行チェック
            if ((this.uGrid_Details.ActiveRow == null) && (this.uGrid_Details.ActiveCell == null))
            {
                return;
            }

            // アクティブ行取得
            int activeRowIndex;
            if (this.uGrid_Details.ActiveRow != null)
            {
                activeRowIndex = this.uGrid_Details.ActiveRow.Index;
            }
            else
            {
                activeRowIndex = this.uGrid_Details.ActiveCell.Row.Index;
            }

            DialogResult res;

            // 提供データの場合
            if (IntObjToInt(this.uGrid_Details.Rows[activeRowIndex].Cells[COLUMN_DIVISIONCODE].Value) != 0)
            {
                res = ShowMessageBox(emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                     "提供データのため、削除できません。",
                                     0,
                                     MessageBoxButtons.OK,
                                     MessageBoxDefaultButton.Button1);
                return;
            }

            res = ShowMessageBox(emErrorLevel.ERR_LEVEL_QUESTION,
                                 "選択行を削除してもよろしいですか？",
                                 0,
                                 MessageBoxButtons.YesNo,
                                 MessageBoxDefaultButton.Button1);
            if (res == DialogResult.No)
            {
                return;
            }

            if (this.uGrid_Details.Rows.Count == 1)
            {
                // アクティブ行クリア
                ClearRow(activeRowIndex);
            }
            else
            {
                // アクティブ行削除
                this.uGrid_Details.Rows[activeRowIndex].Delete(false);
            }

            // No.再表示
            for (int index = 0; index < this.uGrid_Details.Rows.Count; index++)
            {
                this.uGrid_Details.Rows[index].Cells[COLUMN_NO].Value = index + 1;
            }
        }

        /// <summary>
        /// Button_Click イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : 商品登録ボタンがクリックされた時に発生します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/11/28</br>
        /// </remarks>
        private void GoodsRegist_Button_Click(object sender, EventArgs e)
        {
            // 商品登録前チェック
            bool bStatus = CheckBeforeGoodsRegist();
            if (!bStatus)
            {
                return;
            }

            // 対象行取得
            int rowIndex;
            if (this.uGrid_Details.ActiveCell == null)
            {
                rowIndex = this.uGrid_Details.ActiveRow.Index;
            }
            else
            {
                rowIndex = this.uGrid_Details.ActiveCell.Row.Index;
            }

            // 品番取得
            string goodsNo = StrObjToString(this.uGrid_Details.Rows[rowIndex].Cells[COLUMN_GOODSNO].Value);
            // メーカーコード取得
            int makerCode = StrObjToInt(this.uGrid_Details.Rows[rowIndex].Cells[COLUMN_MAKERCODE].Value);
            
            // 商品連結データ取得
            bool newFlg;
            GoodsUnitData goodsUnitData;
            if (this.uGrid_Details.Rows[rowIndex].Cells[COLUMN_GOODSUNITDATA].Value == DBNull.Value)
            {
                newFlg = true;
                goodsUnitData = new GoodsUnitData();
            }
            else
            {
                newFlg = false;
                goodsUnitData = (GoodsUnitData)this.uGrid_Details.Rows[rowIndex].Cells[COLUMN_GOODSUNITDATA].Value;
            }

            // 商品在庫マスタ表示
            int status = ShowGoodsStockMaster(ref goodsUnitData, makerCode, goodsNo, newFlg);
            if (goodsUnitData.FileHeaderGuid != Guid.Empty)
            {
                // グリッドに反映
                AfterShowGoodsStockMaster(goodsUnitData.Clone(), rowIndex);
            }
        }

        /// <summary>
        /// Button_Click イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : 引用登録ボタンがクリックされた時に発生します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/11/28</br>
        /// </remarks>
        private void QuotationRegist_Button_Click(object sender, EventArgs e)
        {
            // 引用登録画面表示
            PMKEN09110UB pmken09110UB = new PMKEN09110UB();

            if (this.tComboEditor_EquipGenreCode.Value != null)
            {
                // 装備分類
                pmken09110UB.EquipGanreCode = (int)this.tComboEditor_EquipGenreCode.Value;
            }
            // 装備名
            pmken09110UB.EquipGanreName = this.tEdit_EquipGenreName.DataText.Trim();
            // TBO検索結果リスト(全ユーザーデータ)
            pmken09110UB.AllTBOSearchUList = this._allTBOSearchUList;

            DialogResult res = pmken09110UB.ShowDialog();

            // 保存処理が行われた場合
            if (res == DialogResult.OK)
            {
                // 再検索
                int totalCount = 0;
                Search(ref totalCount, 0);

                // 装備分類コード
                int equipGanreCode = (int)this.tComboEditor_EquipGenreCode.Value;
                // 装備名
                string equipName = (string)this.tEdit_EquipGenreName.DataText.Trim();

                if ((equipGanreCode != pmken09110UB.EquipGanreCode) ||
                    (equipName.Trim() != pmken09110UB.EquipGanreName.Trim()))
                {
                    return;
                }

                ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                               "現在表示中の装備分類・装備名に対して引用登録が行われました。" + "\r\n" + "\r\n" + "編集中のデータは破棄されます。",
                               0,
                               MessageBoxButtons.OK,
                               MessageBoxDefaultButton.Button1);

                // ユーザーデータ取得
                this._userTBOSearchUList = FindUserTBOSearchUList(equipGanreCode, equipName);

                List<GoodsUnitData> goodsUnitDataList;

                // 商品連結データ検索
                int status = SearchGoodsUnitDataList(out goodsUnitDataList, equipGanreCode, equipName);
                if (status == 0)
                {
                    // 商品連結データ検索後処理
                    AfterSearchGoodsUnitDataList(goodsUnitDataList);
                }
            }
        }

        /// <summary>
        /// KeyDown イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : グリッドでキーが押された時に発生します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/11/28</br>
        /// <br>Update Note: 2013/06/14 王君</br>
        /// <br>           : Redmine#35434</br>
        /// </remarks>
        private void uGrid_Details_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.uGrid_Details.ActiveCell == null)
            {
                return;
            }

            int rowIndex = this.uGrid_Details.ActiveCell.Row.Index;
            int columnIndex = this.uGrid_Details.ActiveCell.Column.Index;

            switch (e.KeyCode)
            {
                case Keys.Up:
                    {
                        e.Handled = true;

                        if (rowIndex == 0)
                        {
                            // 引用登録ボタンにフォーカス
                            this.QuotationRegist_Button.Focus();
                        }
                        else
                        {
                            for (int index = rowIndex - 1; index >= 0; index--)
                            {
                                if (this.uGrid_Details.Rows[index].Cells[columnIndex].Activation == Activation.AllowEdit)
                                {
                                    this.uGrid_Details.Rows[index].Cells[columnIndex].Activate();
                                    this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                    return;
                                }
                            }

                            // 引用登録ボタンにフォーカス
                            this.QuotationRegist_Button.Focus();
                        }

                        break;
                    }
                case Keys.Down:
                    {
                        e.Handled = true;

                        if (rowIndex == this.uGrid_Details.Rows.Count - 1)
                        {
                            // 保存ボタンにフォーカス
                            this.Ok_Button.Focus();
                            ChangeButtonEnabled(false);
                        }
                        else
                        {
                            for (int index = rowIndex + 1; index < this.uGrid_Details.Rows.Count; index++)
                            {
                                if (this.uGrid_Details.Rows[index].Cells[columnIndex].Activation == Activation.AllowEdit)
                                {
                                    this.uGrid_Details.Rows[index].Cells[columnIndex].Activate();
                                    this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                    return;
                                }
                            }

                            // 保存ボタンにフォーカス
                            this.Ok_Button.Focus();
                            ChangeButtonEnabled(false);
                        }

                        break;
                    }
                case Keys.Left:
                    {
                        if (this.uGrid_Details.ActiveCell.IsInEditMode)
                        {
                            if (this.uGrid_Details.ActiveCell.SelStart == 0)
                            {
                                e.Handled = true;
                                this.uGrid_Details.PerformAction(UltraGridAction.PrevCellByTab);
                            }
                        }
                        break;
                    }
                case Keys.Right:
                    {
                        if (this.uGrid_Details.ActiveCell.IsInEditMode)
                        {
                            if (this.uGrid_Details.ActiveCell.SelStart >= this.uGrid_Details.ActiveCell.Text.Length)
                            {
                                e.Handled = true;
                                this.uGrid_Details.PerformAction(UltraGridAction.NextCellByTab);
                            }
                        }
                        break;
                    }
                // ----- ADD 王君 2013/06/14 Redmine#35434----->>>>>
                case Keys.I:
                    {
                        if (e.Alt)
                        {
                            if (this.uGrid_Details.ActiveCell.Column.Key == COLUMN_MAKERCODE)
                            {
                                this.GoodsRegist_Button.Focus();
                            }
                            else if (this.uGrid_Details.ActiveCell.Column.Key == COLUMN_GOODSNO)
                            {
                                this.GoodsRegist_Button.Focus();
                            }
                            else
                            {
                            }
                        }
                        break;
                    }
                // ----- ADD 王君 2013/06/14 Redmine#35434-----<<<<<
            }
        }

        /// <summary>
        /// KeyPress イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : グリッドでキーが押された時に発生します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/11/28</br>
        /// </remarks>
        private void uGrid_Details_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (this.uGrid_Details.ActiveCell == null)
            {
                return;
            }

            UltraGridCell cell = this.uGrid_Details.ActiveCell;

            if (cell.IsInEditMode)
            {
                // QTY
                if (cell.Column.Key == COLUMN_QTY)
                {
                    if (!KeyPressNumCheck(5, 2, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, true))
                    {
                        e.Handled = true;
                        return;
                    }
                }
                // UI設定を参照
                else if (this.uiSetControl1.CheckMatchingSet(cell.Column.Key, e.KeyChar) == false)
                {
                    e.Handled = true;
                    return;
                }
            }
        }

        /// <summary>
        /// BeforeCellActivate イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : セルがアクティブ化する前に発生します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/11/28</br>
        /// </remarks>
        private void uGrid_Details_BeforeCellActivate(object sender, CancelableCellEventArgs e)
        {
            // 項目に従いIMEモード設定
            this.uGrid_Details.ImeMode = this.uiSetControl1.GetSettingImeMode(e.Cell.Column.Key);

            // ゼロ詰め解除実行
            if (e.Cell.Column.DataType == typeof(string) &&
                e.Cell.StyleResolved == Infragistics.Win.UltraWinGrid.ColumnStyle.Edit)
            {
                if (e.Cell.Value != DBNull.Value)
                {
                    this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[e.Cell.Column.Key].Value =
                        this.uiSetControl1.GetZeroPadCanceledText(e.Cell.Column.Key,
                        (string)this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[e.Cell.Column.Key].Value);
                }
            }
        }

        /// <summary>
        /// AfterCellActivate イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : セルがアクティブ化した後に発生します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/11/28</br>
        /// </remarks>
        private void uGrid_Details_AfterCellActivate(object sender, EventArgs e)
        {
            // グリッド操作ボタン制御
            ChangeButtonEnabled(true);
        }

        /// <summary>
        /// AfterExitEditMode イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : セルの編集モードが終了した時に発生します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/11/28</br>
        /// </remarks>
        private void uGrid_Details_AfterExitEditMode(object sender, EventArgs e)
        {
            UltraGrid uGrid = (UltraGrid)sender;

            if (uGrid.ActiveCell == null)
            {
                return;
            }

            // メーカーコード
            if (uGrid.ActiveCell.Column.Key == COLUMN_MAKERCODE)
            {
                int makerCode = StrObjToInt(uGrid.ActiveCell.Value);

                if (makerCode != 0)
                {
                    this.uGrid_Details.AfterCellUpdate -= uGrid_Details_AfterCellUpdate;

                    // ゼロ詰め
                    uGrid.ActiveCell.Value = makerCode.ToString("0000");

                    this.uGrid_Details.AfterCellUpdate += uGrid_Details_AfterCellUpdate;
                }
            }
            // QTY
            else if (uGrid_Details.ActiveCell.Column.Key == COLUMN_QTY)
            {
                double qty = StrObjToDouble(uGrid.ActiveCell.Value);

                if (qty == 0)
                {
                    return;
                }

                this.uGrid_Details.AfterCellUpdate -= uGrid_Details_AfterCellUpdate;

                // カンマ詰め
                uGrid.ActiveCell.Value = qty.ToString("N");

                this.uGrid_Details.AfterCellUpdate += uGrid_Details_AfterCellUpdate;
            }
        }

        /// <summary>
        /// BeforeCellUpdate イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : セルの値が更新される時に発生します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/11/28</br>
        /// </remarks>
        private void uGrid_Details_BeforeCellUpdate(object sender, BeforeCellUpdateEventArgs e)
        {
            if (this.uGrid_Details.ActiveCell == null)
            {
                return;
            }

            string columnKey = this.uGrid_Details.ActiveCell.Column.Key;

            switch (columnKey)
            {
                case COLUMN_GOODSNO:
                    {
                        this._prevGoodsNo = StrObjToString(this.uGrid_Details.ActiveCell.Value);
                        break;
                    }
                case COLUMN_MAKERCODE:
                    {
                        this._prevMakerCode = StrObjToInt(this.uGrid_Details.ActiveCell.Value);
                        break;
                    }
            }
        }

        /// <summary>
        /// AfterCellUpdate イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : セルの値が更新された時に発生します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/11/28</br>
        /// <br>Update Note: 2013/04/01 田建委</br>
        /// <br>管理番号   : 10806793-00 2013/04/10配信分</br>
        /// <br>             Redmine#34640 商品在庫マスタの仕様変更(#33231の残留分)</br>
        /// <br>Update Note: 2013/06/14 王君</br>
        /// <br>管理番号   : 10901273-00 2013/04/10配信分</br>
        /// <br>             Redmine#35434 商品在庫マスタの復活</br>
        /// </remarks>
        private void uGrid_Details_AfterCellUpdate(object sender, CellEventArgs e)
        {
            if (this.uGrid_Details.ActiveCell == null)
            {
                return;
            }

            UltraGridCell activeCell = this.uGrid_Details.ActiveCell;

            int rowIndex = activeCell.Row.Index;
            string columnKey = activeCell.Column.Key;

            switch (columnKey)
            {
                case COLUMN_GOODSNO:
                    {
                        // 品番
                        string goodsNo = StrObjToString(this.uGrid_Details.Rows[rowIndex].Cells[COLUMN_GOODSNO].Value);

                        if (goodsNo == "")
                        {
                            // 行クリア
                            ClearRow(rowIndex);

                            return;
                        }
                        // ----- ADD 王君　2013/06/14　Redmine#35434 ----->>>>>
                        this.uGrid_Details.AfterCellUpdate -= this.uGrid_Details_AfterCellUpdate;
                        this.uGrid_Details.Rows[rowIndex].Cells[COLUMN_GOODSUNITDATA].Value = DBNull.Value;
                        this.uGrid_Details.AfterCellUpdate += this.uGrid_Details_AfterCellUpdate;
                        // ----- ADD 王君  2013/06/14 Redmine#35434 -----<<<<<
                        // メーカーコード
                        //int makerCode = StrObjToInt(this.uGrid_Details.Rows[rowIndex].Cells[COLUMN_MAKERCODE].Value); // DEL 2009/03/16
                        int makerCode = 0; // ADD 2009/03/16

                        // 商品検索
                        GoodsUnitData goodsUnitData;
                        int status = this._tboSearchAcs.SearchGoods(out goodsUnitData, makerCode, goodsNo);
                        if (status == 0)
                        {
                            // 同一商品存在チェック
                            bool bStatus = CheckSameGoods(goodsUnitData, rowIndex);
                            if (!bStatus)
                            {
                                ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                                               "同一商品が存在するため選択できません。",
                                               0,
                                               MessageBoxButtons.OK,
                                               MessageBoxDefaultButton.Button1);

                                // 行クリア
                                ClearRow(rowIndex);

                                return;
                            }

                            // グリッドに反映
                            this.uGrid_Details.AfterCellUpdate -= this.uGrid_Details_AfterCellUpdate;//  ADD 王君　2013/06/14　Redmine#35434
                            this.uGrid_Details.Rows[rowIndex].Cells[COLUMN_RANK].Value = DBNull.Value;
                            this.uGrid_Details.AfterCellUpdate += this.uGrid_Details_AfterCellUpdate;//  ADD 王君　2013/06/14　Redmine#35434
                            GoodsUnitDataToScreen(goodsUnitData, rowIndex, true);
                        }
                        else if (status == -1)
                        {
                            this.uGrid_Details.AfterCellUpdate -= this.uGrid_Details_AfterCellUpdate;

                            this.uGrid_Details.ActiveCell.Value = this._prevGoodsNo;

                            this.uGrid_Details.AfterCellUpdate += this.uGrid_Details_AfterCellUpdate;
                        }
                        else
                        {
                            // 品番・メーカーが入力されている場合
                            if ((goodsNo != "") && (makerCode != 0))
                            {
                                // 商品在庫マスタ起動
                                goodsUnitData = new GoodsUnitData();
                                status = ShowGoodsStockMaster(ref goodsUnitData, makerCode, goodsNo, true);
                                if (goodsUnitData.FileHeaderGuid != Guid.Empty)
                                {
                                    // グリッドに反映
                                    this.uGrid_Details.Rows[rowIndex].Cells[COLUMN_RANK].Value = DBNull.Value;
                                    AfterShowGoodsStockMaster(goodsUnitData.Clone(), rowIndex);
                                }
                                else
                                {
                                    this.uGrid_Details.AfterCellUpdate -= this.uGrid_Details_AfterCellUpdate;
                                    this.uGrid_Details.Rows[rowIndex].Cells[COLUMN_GOODSUNITDATA].Value = DBNull.Value;
                                    this.uGrid_Details.AfterCellUpdate += this.uGrid_Details_AfterCellUpdate;
                                }
                            }
                        }

                        break;
                    }
                case COLUMN_MAKERCODE:
                    {
                        // メーカーコード
                        int makerCode = StrObjToInt(this.uGrid_Details.Rows[rowIndex].Cells[COLUMN_MAKERCODE].Value);

                        if (makerCode == 0)
                        {
                            // 行クリア
                            ClearRow(rowIndex);

                            return;
                        }
                        //--- ADD 2013/04/01 田建委 Redmine#34640 --->>>>>
                        else
                        {
                            // ----- ADD 王君　2013/06/14　Redmine#35434 ----->>>>>
                            this.uGrid_Details.AfterCellUpdate -= this.uGrid_Details_AfterCellUpdate;
                            this.uGrid_Details.Rows[rowIndex].Cells[COLUMN_GOODSUNITDATA].Value = DBNull.Value;
                            this.uGrid_Details.AfterCellUpdate += this.uGrid_Details_AfterCellUpdate;
                            // ----- ADD 王君  2013/06/14 Redmine#35434 -----<<<<<
                            MakerUMnt makerUMnt;

                            // メーカー情報取得処理
                            int stus = this._goodsAcs.GetMaker(this._enterpriseCode, makerCode, out makerUMnt);
                            if (stus == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                            }
                            else
                            {
                                TMsgDisp.Show(
                                    this,
                                    emErrorLevel.ERR_LEVEL_INFO,
                                    this.Name,
                                    "メーカーコードが存在しません。",
                                    -1,
                                    MessageBoxButtons.OK);

                                this.uGrid_Details.BeforeCellUpdate -= this.uGrid_Details_BeforeCellUpdate;
                                this.uGrid_Details.AfterCellUpdate -= this.uGrid_Details_AfterCellUpdate;
                                if (this._prevMakerCode != 0)
                                {
                                    this.uGrid_Details.ActiveCell.Value = this._prevMakerCode;
                                }
                                else
                                {
                                    this.uGrid_Details.ActiveCell.Value = DBNull.Value;
                                }
                                this.uGrid_Details.BeforeCellUpdate += this.uGrid_Details_BeforeCellUpdate;
                                this.uGrid_Details.AfterCellUpdate += this.uGrid_Details_AfterCellUpdate;
                                return;
                            }
                        }
                        //--- ADD 2013/04/01 田建委 Redmine#34640 ---<<<<<

                        // 品番
                        string goodsNo = StrObjToString(this.uGrid_Details.Rows[rowIndex].Cells[COLUMN_GOODSNO].Value);

                        // 商品検索
                        GoodsUnitData goodsUnitData;
                        int status = this._tboSearchAcs.SearchGoods(out goodsUnitData, makerCode, goodsNo);
                        if (status == 0)
                        {
                            // 同一商品存在チェック
                            bool bStatus = CheckSameGoods(goodsUnitData, rowIndex);
                            if (!bStatus)
                            {
                                ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                                               "同一商品が存在するため選択できません。",
                                               0,
                                               MessageBoxButtons.OK,
                                               MessageBoxDefaultButton.Button1);

                                // 行クリア
                                ClearRow(rowIndex);

                                return;
                            }


                            // グリッドに反映
                            this.uGrid_Details.Rows[rowIndex].Cells[COLUMN_RANK].Value = DBNull.Value;
                            GoodsUnitDataToScreen(goodsUnitData, rowIndex, true);
                        }
                        else if (status == -1)
                        {
                            this.uGrid_Details.AfterCellUpdate -= this.uGrid_Details_AfterCellUpdate;

                            if (this._prevMakerCode != 0)
                            {
                                this.uGrid_Details.ActiveCell.Value = this._prevMakerCode;
                            }
                            else
                            {
                                this.uGrid_Details.ActiveCell.Value = "";
                            }

                            this.uGrid_Details.AfterCellUpdate += this.uGrid_Details_AfterCellUpdate;
                        }
                        else
                        {
                            // 品番・メーカーが入力されている場合
                            if ((goodsNo != "") && (makerCode != 0))
                            {
                                // 商品在庫マスタ起動
                                goodsUnitData = new GoodsUnitData();
                                status = ShowGoodsStockMaster(ref goodsUnitData, makerCode, goodsNo, true);
                                if (goodsUnitData.FileHeaderGuid != Guid.Empty)
                                {
                                    // グリッドに反映
                                    this.uGrid_Details.Rows[rowIndex].Cells[COLUMN_RANK].Value = DBNull.Value;
                                    AfterShowGoodsStockMaster(goodsUnitData.Clone(), rowIndex);
                                }
                                else
                                {
                                    this.uGrid_Details.AfterCellUpdate -= this.uGrid_Details_AfterCellUpdate;
                                    this.uGrid_Details.Rows[rowIndex].Cells[COLUMN_GOODSUNITDATA].Value = DBNull.Value;
                                    this.uGrid_Details.AfterCellUpdate += this.uGrid_Details_AfterCellUpdate;
                                }
                            }
                        }

                        break;
                    }
            }

            // 最終行の場合
            if ((this.uGrid_Details.Rows.Count != 9999) &&
                (rowIndex == this.uGrid_Details.Rows.Count - 1))
            {
                // 行追加
                CreateNewRow(ref this.uGrid_Details);

                this.uGrid_Details.ActiveCell = activeCell;
            }
        }

        /// <summary>
        /// ValueChanged イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : 装備分類の値が変更された時に発生します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/11/28</br>
        /// </remarks>
        private void tComboEditor_EquipGenreCode_ValueChanged(object sender, EventArgs e)
        {
            // 装備分類
            int equipGanreCode = (int)this.tComboEditor_EquipGenreCode.Value;
            if (equipGanreCode == this._prevEquipGanreCode)
            {
                return;
            }

            // 装備名
            string equipName = this.tEdit_EquipGenreName.DataText.Trim();
            if (equipName == "")
            {
                return;
            }

            List<GoodsUnitData> goodsUnitDataList;

            // 商品連結データ検索処理
            int status = SearchGoodsUnitDataList(out goodsUnitDataList, equipGanreCode, equipName);
            if ((status == 0) && (goodsUnitDataList != null) && (goodsUnitDataList.Count > 0))
            {
                if (this.uGrid_Details.Rows.Count > 1)
                {
                    DialogResult res = ShowMessageBox(emErrorLevel.ERR_LEVEL_QUESTION,
                                                      "装備分類を変更すると明細がリセットされます。" + "\r\n" + "\r\n" + "装備分類を変更しますか？",
                                                      0,
                                                      MessageBoxButtons.YesNo,
                                                      MessageBoxDefaultButton.Button1);
                    if (res != DialogResult.Yes)
                    {
                        this.tComboEditor_EquipGenreCode.ValueChanged -= tComboEditor_EquipGenreCode_ValueChanged;
                        this.tComboEditor_EquipGenreCode.Value = this._prevEquipGanreCode;
                        this.tComboEditor_EquipGenreCode.ValueChanged += tComboEditor_EquipGenreCode_ValueChanged;
                        this.tComboEditor_EquipGenreCode.Focus();
                        return;
                    }
                }

                // ユーザーデータ取得
                this._userTBOSearchUList = FindUserTBOSearchUList(equipGanreCode, equipName);

                // 商品連結データ検索後処理
                AfterSearchGoodsUnitDataList(goodsUnitDataList);
            }

            this._prevEquipGanreCode = equipGanreCode;
        }

        /// <summary>
        /// Tick イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note　　　 : 指定された間隔の時間が経過したときに発生します。
        ///					 この処理は、システムが提供するスレッド プール
        ///					 スレッドで実行されます。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/11/28</br>
        /// </remarks>
        private void Initial_Timer_Tick(object sender, EventArgs e)
        {
            Initial_Timer.Enabled = false;

            // 画面再構築処理
            ScreenReconstruction();
        }

        /// <summary>
        /// ChangeFocus イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : フォーカスが移った時に発生します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/11/28</br>
        /// </remarks>
        private void tRetKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null)
            {
                return;
            }

            switch (e.PrevCtrl.Name)
            {
                // 装備名
                case "tEdit_EquipGenreName":
                    {
                        string equipName = this.tEdit_EquipGenreName.DataText.Trim();

                        if (equipName != "")
                        {
                            if (equipName != this._prevEquipName.Trim())
                            {
                                // 装備分類コード取得
                                int equipGanreCode = (int)this.tComboEditor_EquipGenreCode.Value;

                                // 曖昧検索
                                if (equipName.Substring(equipName.Length - 1) == "*")
                                {
                                    string retName;

                                    // 装備分類ガイド表示
                                    int status = ShowEquipNameGuide(out retName, equipGanreCode, equipName);
                                    if (status == 0)
                                    {
                                        this.tEdit_EquipGenreName.DataText = retName.Trim();
                                        this._prevEquipName = retName.Trim();
                                    }
                                }
                                else
                                {
                                    List<GoodsUnitData> goodsUnitDataList;

                                    // 商品連結データ検索処理
                                    int status = SearchGoodsUnitDataList(out goodsUnitDataList, equipGanreCode, equipName);
                                    if ((status == 0) && (goodsUnitDataList != null) && (goodsUnitDataList.Count > 0))
                                    {
                                        if (this.uGrid_Details.Rows.Count > 1)
                                        {
                                            DialogResult res = ShowMessageBox(emErrorLevel.ERR_LEVEL_QUESTION,
                                                                              "装備名を変更すると明細がリセットされます。" + "\r\n" + "\r\n" + "装備名を変更しますか？",
                                                                              0,
                                                                              MessageBoxButtons.YesNo,
                                                                              MessageBoxDefaultButton.Button1);
                                            if (res != DialogResult.Yes)
                                            {
                                                this.tEdit_EquipGenreName.DataText = this._prevEquipName;
                                                e.NextCtrl = e.PrevCtrl;
                                                return;
                                            }
                                        }

                                        // ユーザーデータ取得
                                        this._userTBOSearchUList = FindUserTBOSearchUList(equipGanreCode, equipName);

                                        // 商品連結データ検索後処理
                                        AfterSearchGoodsUnitDataList(goodsUnitDataList);
                                    }

                                    this._prevEquipName = equipName;
                                }
                            }
                        }

                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                if (this.tEdit_EquipGenreName.DataText.Trim() != "")
                                {
                                    e.NextCtrl = null;
                                    this.uGrid_Details.Focus();
                                    this.uGrid_Details.Rows[0].Cells[COLUMN_GOODSNO].Activate();
                                    this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                }
                            }
                            else if (e.Key == Keys.Down)
                            {
                                e.NextCtrl = null;
                                this.uGrid_Details.Focus();
                                this.uGrid_Details.Rows[0].Cells[COLUMN_GOODSNO].Activate();
                                this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                            }
                        }
                        break;
                    }
                // 装備名ガイドボタン
                case "EquipGenreGuide_Button":
                    {
                        if (e.ShiftKey == false)
                        {
                            if (e.Key == Keys.Down)
                            {
                                e.NextCtrl = null;
                                this.uGrid_Details.Focus();
                                this.uGrid_Details.Rows[0].Cells[COLUMN_GOODSNO].Activate();
                                this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                            }
                        }
                        break;
                    }
                // グリッド
                case "uGrid_Details":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                if (this.uGrid_Details.ActiveCell == null)
                                {
                                    break;
                                }

                                int rowIndex = this.uGrid_Details.ActiveCell.Row.Index;
                                string columnKey = this.uGrid_Details.ActiveCell.Column.Key;

                                if ((rowIndex == this.uGrid_Details.Rows.Count - 1) &&
                                    (columnKey == COLUMN_STANDARD))
                                {
                                    // 保存ボタンにフォーカス
                                    e.NextCtrl = this.Ok_Button;
                                }
                                else
                                {
                                    // 次のセルにフォーカス
                                    e.NextCtrl = null;
                                    this.uGrid_Details.PerformAction(UltraGridAction.NextCellByTab);
                                }
                            }
                        }
                        else
                        {
                            if (e.Key == Keys.Tab)
                            {
                                if (this.uGrid_Details.ActiveCell == null)
                                {
                                    break;
                                }

                                int rowIndex = this.uGrid_Details.ActiveCell.Row.Index;
                                int columnIndex = this.uGrid_Details.ActiveCell.Column.Index;

                                if ((rowIndex == 0) && (columnIndex == 2))
                                {
                                    if (this.tEdit_EquipGenreName.DataText.Trim() != "")
                                    {
                                        // 装備名にフォーカス
                                        e.NextCtrl = this.tEdit_EquipGenreName;
                                    }
                                    else
                                    {
                                        // 装備名ガイドボタンにフォーカス
                                        e.NextCtrl = this.EquipGenreGuide_Button;
                                    }
                                }
                                else
                                {
                                    // 前のセルにフォーカス
                                    e.NextCtrl = null;
                                    this.uGrid_Details.PerformAction(UltraGridAction.PrevCellByTab);
                                }
                            }
                        }

                        break;
                    }
            }

            if (e.NextCtrl == null)
            {
                return;
            }

            switch (e.NextCtrl.Name)
            {
                case "tComboEditor_EquipGenreCode":
                case "tEdit_EquipGenreName":
                case "EquipGenreGuide_Button":
                case "Ok_Button":
                case "Cancel_Button":
                    {
                        // グリッド操作ボタン制御
                        ChangeButtonEnabled(false);
                        break;
                    }
                // グリッド
                case "uGrid_Details":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter) || (e.Key == Keys.Down))
                            {
                                e.NextCtrl = null;
                                this.uGrid_Details.Focus();
                                this.uGrid_Details.Rows[0].Cells[COLUMN_GOODSNO].Activate();
                                this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                            }
                            else if (e.Key == Keys.Up)
                            {
                                e.NextCtrl = null;
                                this.uGrid_Details.Focus();
                                this.uGrid_Details.Rows[this.uGrid_Details.Rows.Count - 1].Cells[COLUMN_GOODSNO].Activate();
                                this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                            }
                        }
                        else
                        {
                            if (e.Key == Keys.Tab)
                            {
                                e.NextCtrl = null;
                                this.uGrid_Details.Focus();
                                this.uGrid_Details.Rows[this.uGrid_Details.Rows.Count - 1].Cells[COLUMN_STANDARD].Activate();
                                this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                            }
                        }
                        break;
                    }
            }
        }

        #endregion ■ Control Events

        // 2009.03.30 30413 犬飼 商品マスタ論理削除時の対応 >>>>>>START
        /// <summary>
        /// 商品情報削除分TBO情報取得処理
        /// </summary>
        /// <param name="goodsUnitDataList"></param>
        private void GetTBOSearchUOfDeletedGoodsInfo(ref List<GoodsUnitData> goodsUnitDataList)
        {
            if ((goodsUnitDataList == null) || (this._userTBOSearchUList == null)) return;

            //-----------------------------------------------------------------------------
            // TBO情報のキャッシュに存在して、検索結果に存在しない場合、削除分として設定(削除分も表示対象とする為)
            //-----------------------------------------------------------------------------
            foreach (TBOSearchU workTBOSearchU in this._userTBOSearchUList)
            {
                GoodsUnitData goodsUnitData = goodsUnitDataList.Find(
                    delegate(GoodsUnitData goodsData)
                    {
                        if ((goodsData.GoodsMakerCd == workTBOSearchU.JoinDestMakerCd) &&
                            (goodsData.GoodsNo == workTBOSearchU.JoinDestPartsNo))
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                );

                if (goodsUnitData == null)
                {
                    GoodsUnitData addGoodsUnitData = new GoodsUnitData();
                    addGoodsUnitData.GoodsNo = workTBOSearchU.JoinDestPartsNo;
                    // DEL 2009/04/09 ------>>>
                    //addGoodsUnitData.GoodsMakerCd = workTBOSearchU.JoinDestMakerCd;
                    //addGoodsUnitData.BLGoodsCode = workTBOSearchU.BLGoodsCode;
                    // DEL 2009/04/09 ------<<<
                    addGoodsUnitData.StockList = new List<Stock>();
                    goodsUnitDataList.Add(addGoodsUnitData);
                }
            }
        }
        // 2009.03.30 30413 犬飼 商品マスタ論理削除時の対応 <<<<<<END

        // ----- ADD 王君 2013/05/02 Redmine#35434 ----->>>>>
        /// <summary>
        /// 全体初期値設定を取得処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 全体初期値設定を取得処理</br>
        /// <br>Programmer : 王君</br>
        /// <br>Date       : 2013/05/02</br>
        /// <br>管理番号   : 10901273-00 2013/06/18配信分</br>
        /// <br>           : Redmine#35434の対応</br>
        /// </remarks>
        private void GetDtlCalcStckCntDsp()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            AllDefSetAcs allDefSetAcs = new AllDefSetAcs();
            AllDefSetAcs.SearchMode allDefSetSearchMode = AllDefSetAcs.SearchMode.Remote;
            ArrayList retAllDefSetList;
            status = allDefSetAcs.Search(out retAllDefSetList, this._enterpriseCode, allDefSetSearchMode);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // ログイン担当者の所属拠点もしくは全社設定を取得
                this._allDefSet = this.GetAllDefSetFromList(LoginInfoAcquisition.Employee.BelongSectionCode, retAllDefSetList);
            }
            else
            {
                this._allDefSet = null;
            }
        }

        /// <summary>
        /// 全体初期値設定マスタのリスト中から、指定した拠点で使用する設定を取得します。(拠点コードが無ければ全社設定）
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="allDefSetArrayList">全体初期値設定マスタオブジェクトリスト</param>
        /// <returns>全体初期値設定マスタオブジェクト</returns>
        /// <remarks>
        /// <br>Programmer : 王君</br>
        /// <br>Date       : 2013/05/02</br>
        /// <br>管理番号   : 10901273-00 2013/06/18配信分</br>
        /// <br>           : Redmine#35434の対応</br>
        /// </remarks>
        private AllDefSet GetAllDefSetFromList(string sectionCode, ArrayList allDefSetArrayList)
        {
            AllDefSet allSecAllDefSet = null;

            foreach (AllDefSet allDefSet in allDefSetArrayList)
            {
                if (allDefSet.SectionCode.Trim() == sectionCode.Trim())
                {
                    return allDefSet;
                }
                else if (allDefSet.SectionCode.Trim() == "00")
                {
                    allSecAllDefSet = allDefSet;
                }
            }

            return allSecAllDefSet;
        }
        // ----- ADD 王君 2013/05/02 Redmine#35434 -----<<<<<

    }
}