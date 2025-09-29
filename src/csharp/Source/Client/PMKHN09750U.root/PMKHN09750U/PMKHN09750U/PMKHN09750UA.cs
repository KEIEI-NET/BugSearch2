//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : 優先倉庫マスタ
// プログラム概要   : 優先倉庫の登録・変更・削除を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2013 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10902160-00  作成担当 : huangt
// 作 成 日  K2013/09/10  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号  10902160-00  作成担当 : huangt
// 修 正 日  K2013/10/08  修正内容 : #40626 フタバ_システム障害について
//                                   No.82 初期フォーカスの改修
//                                   No.83 行削除チェックの改修
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;

using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Common;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using System.Collections;
using Infragistics.Win.Misc;
using System.Text.RegularExpressions;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 優先倉庫マスタUIクラス
    /// </summary>
    /// <remarks>
    /// <br>Note		: 優先倉庫マスタのUI設定を行います。</br>
    /// <br>Programmer	: huangt</br>
    /// <br>Date		: K2013/09/10</br>
    /// </remarks>
    public partial class PMKHN09750UA : Form, IMasterMaintenanceArrayType
    {
        #region ■ Constants

        // プログラムID
        private const string ASSEMBLY_ID = "PMKHN09750U";

        // テーブル名称
        private const string TABLE_MAIN = "MainTable";
        private const string TABLE_DETAIL = "DetailTable";

        // データビュータイトル
        private const string GRIDTITLE_SECTION = "拠点";
        private const string GRIDTITLE_WAREHOUSE = "倉庫";

        // データビュー表示用
        private const string MAIN_DELETEDATE = "削除日";
        private const string MAIN_SECTIONCODE = "拠点コード";
        private const string MAIN_SECTIONGUID = "拠点情報GUID";
        private const string MAIN_SECTIONNAME = "拠点名称";

        private const string DETAIL_DELETEDATE = "削除日";
        private const string DETAIL_WAREHOUSECODE = "倉庫コード";
        private const string DETAIL_WAREHOUSENAME = "倉庫名称";
        private const string DETAIL_WAREHOUSEGUID = "倉庫情報GUID";
        private const string DETAIL_UPDATETIME = "更新日時";
        private const string DETAIL_WAREHPROTYODR = "優先順位";

        // グリッド用データテーブル
        private const string TABLE_WAREHOUSEGRID = "WarehouseGrid";

        // グリッド列タイトル
        private const string COLUMN_WAREHPROTYODR = "WarehProtyOdr";
        private const string COLUMN_WAREHOUSECODE = "WarehouseCode";
        private const string COLUMN_WAREHOUSEGUIDE = "WarehouseGuide";
        private const string COLUMN_WAREHOUSENAME = "WarehouseName";
        private const string COLUMN_UPDATETIME = "UpdateTime";
        private const string COLUMN_SCREENID = "ScreenId";

        // 編集モード
        private const string INSERT_MODE = "新規モード";
        private const string UPDATE_MODE = "更新モード";
        private const string DELETE_MODE = "削除モード";

        #endregion ■ Constants

        #region ■ Private Members

        // プロパティ用
        private bool _canClose;
        private bool _canDelete;
        private bool _canNew;
        private bool _canPrint;
        private MGridDisplayLayout _defaultGridDisplayLayout;

        // 選択データインデックス
        private string _targetTableName;
        private int _mainDataIndex;
        private int _detailDataIndex;

        // UIグリッド用データテーブル
        private DataTable _bindTable;

        // GridのIndexBuffer格納用変数
        private int _mainIndexBuffer;
        private int _detailsIndexBuffer;
        private string _targetTableBuffer;

        // Grid変更フラグ
        private bool _gridUpdFlg = true;

        // 企業コード
        private string _enterpriseCode;
        private Hashtable _mainTable;
        private Hashtable _detailTable;
        private Hashtable _detailCloneTable;

        // 拠点情報取得アクセスクラス
        private SecInfoAcs _secInfoAcs;
        private SecInfoSetAcs _secInfoSetAcs;
        // 倉庫ガイド
        private WarehouseAcs _warehouseGuideAcs = null;

        // 優先倉庫マスタ　アクセスクラス
        private ProtyWarehouseAcs _protyWarehouseAcs;

        private Dictionary<string , SecInfoSet> _secInfoSetDic;
        private Dictionary<string, Warehouse> _warehouseInfoDic;

        private ControlScreenSkin _controlScreenSkin;            // 画面デザイン変更クラス
        private ProtyWarehouse[] _protyWarehouseListClone;       // 優先倉庫マスタリストClone

        private bool _canChangeMode = false;

        #endregion ■ Private Members

        #region ■ Constructor
        /// <summary>
        /// 優先倉庫マスタクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 優先倉庫マスタUIクラスの新しいインスタンスを生成します。</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date	   : K2013/09/10</br>
        /// </remarks>
        public PMKHN09750UA()
        {
            InitializeComponent();

            this._canClose = true;
            this._canDelete = true;
            this._canNew = true;
            this._canPrint = false;
            this._defaultGridDisplayLayout = MGridDisplayLayout.Vertical;

            // 各種インデックス初期化
            this._mainDataIndex = -1;
            this._detailDataIndex = -1;

            // 企業コード取得
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            this._secInfoAcs = new SecInfoAcs();
            this._secInfoSetAcs = new SecInfoSetAcs();
            this._warehouseGuideAcs = new WarehouseAcs();

            this._protyWarehouseAcs = new ProtyWarehouseAcs();

            this._controlScreenSkin = new ControlScreenSkin();
            this._protyWarehouseListClone = new ProtyWarehouse[1];

            // DataSet列情報構築
            this.Bind_DataSet = new DataSet();
            DataSetColumnConstruction();

            this._mainTable = new Hashtable();
            this._detailTable = new Hashtable();
            this._detailCloneTable = new Hashtable();

            this._bindTable = new DataTable(TABLE_WAREHOUSEGRID);

            // GridのIndexBuffer格納用変数初期化
            this._mainIndexBuffer = -2;
            this._detailsIndexBuffer = -2;
            this._targetTableBuffer = "";

        }
        #endregion ■ Constructor

        #region ■ IMasterMaintenanceArrayType メンバ

        /// <summary>画面終了設定プロパティ</summary>
        /// <value>画面クローズを許可するかどうかの設定を取得または設定します。</value>
        /// <remarks>falseの場合は、画面を閉じる際、CloseではなくHide(非表示)を実行します。</remarks>
        public bool CanClose
        {
            get
            {
                return _canClose;
            }
            set
            {
                _canClose = value;
            }
        }

        /// <summary>削除可能設定プロパティ</summary>
        /// <value>削除が可能かどうかの設定を取得します。</value>
        public bool CanDelete
        {
            get { return _canDelete; }
        }

        /// <summary>新規登録可能設定プロパティ</summary>
        /// <value>新規登録が可能かどうかの設定を取得します。</value>
        public bool CanNew
        {
            get { return _canNew; }
        }

        /// <summary>印刷可能設定プロパティ</summary>
        /// <value>印刷可能かどうかの設定を取得します。</value>
        public bool CanPrint
        {
            get { return _canPrint; }
        }

        /// <summary>グリッドのデフォルト表示位置プロパティ</summary>
        /// <value>グリッドのデフォルト表示位置を取得します。</value>
        public MGridDisplayLayout DefaultGridDisplayLayout
        {
            get { return _defaultGridDisplayLayout; }
        }

        /// <summary>操作対象データテーブル名称プロパティ</summary>
        /// <value>操作対象データのテーブル名称を取得または設定します。</value>
        public string TargetTableName
        {
            get
            {
                return _targetTableName;
            }
            set
            {
                _targetTableName = value;
            }
        }

        /// <summary>
        /// バインドデータセット取得処理
        /// </summary>
        /// <param name="bindDataSet">グリッド表示用データセット</param>
        /// <param name="tableName">テーブル名称</param>
        /// <remarks>
        /// <br>Note       : グリッドにバインドさせるデータセットを取得します。</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : K2013/09/10</br>
        /// </remarks>
        public void GetBindDataSet(ref DataSet bindDataSet, ref string[] tableName)
        {
            // グリッド表示用データセットを設定
            bindDataSet = this.Bind_DataSet;

            // ２つのテーブル名称の設定
            string[] strRet = { TABLE_MAIN, TABLE_DETAIL };
            tableName = strRet;
        }

        /// <summary>
        /// 論理削除データ抽出可能設定リスト取得処理
        /// </summary>
        /// <returns>論理削除データ抽出可能設定リスト</returns>
        /// <remarks>
        /// <br>Note       : 論理削除データの抽出が可能かどうかの設定を配列で取得します。</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : K2013/09/10</br>
        /// </remarks>
        public bool[] GetCanLogicalDeleteDataExtractionList()
        {
            bool[] logicalDeleteButton = { true, false };
            return logicalDeleteButton;
        }

        /// <summary>
        /// グリッド列のサイズの自動調整のデフォルト値リスト取得処理
        /// </summary>
        /// <returns>グリッド列のサイズの自動調整のデフォルト値リスト</returns>
        /// <remarks>
        /// <br>Note       : グリッド列のサイズの自動調整チェックボックスのチェック有無のデフォルト値を配列で取得します。</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : K2013/09/10</br>
        /// </remarks>
        public bool[] GetDefaultAutoFillToGridColumnList()
        {
            bool[] defaultAutoFill = { true, true };
            return defaultAutoFill;
        }

        /// <summary>
        /// 削除ボタンの有効設定リスト取得処理
        /// </summary>
        /// <returns>削除ボタンの有効設定リスト</returns>
        /// <remarks>
        /// <br>Note       : 削除ボタンの有効設定リストを取得します。</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : K2013/09/10</br>
        /// </remarks>
        public bool[] GetDeleteButtonEnabledList()
        {
            bool[] deleteButton = { true, false };
            return deleteButton;
        }

        /// <summary>
        /// グリッドアイコンリスト取得処理
        /// </summary>
        /// <returns>グリッドアイコンリスト</returns>
        /// <remarks>
        /// <br>Note       : グリッドのアイコンを配列で取得します。</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : K2013/09/10</br>
        /// </remarks>
        public Image[] GetGridIconList()
        {
            Image[] gridIcon = { null, null };
            return gridIcon;
        }

        /// <summary>
        /// グリッドタイトルリスト取得処理
        /// </summary>
        /// <returns>グリッドタイトルリスト</returns>
        /// <remarks>
        /// <br>Note       : グリッドのタイトルを配列で取得します。</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : K2013/09/10</br>
        /// </remarks>
        public string[] GetGridTitleList()
        {
            string[] gridTitle = { GRIDTITLE_SECTION, GRIDTITLE_WAREHOUSE };
            return gridTitle;
        }

        /// <summary>
        /// 修正ボタンの有効設定リスト取得処理
        /// </summary>
        /// <returns>修正ボタンの有効設定リスト</returns>
        /// <remarks>
        /// <br>Note       : 修正ボタンの有効設定リストを取得します。</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : K2013/09/10</br>
        /// </remarks>
        public bool[] GetModifyButtonEnabledList()
        {
            bool[] modifyButton = { true, false };
            return modifyButton;
        }

        /// <summary>
        /// 新規ボタンの有効設定リスト取得処理
        /// </summary>
        /// <returns>新規ボタンの有効設定リスト</returns>
        /// <remarks>
        /// <br>Note       : 新規ボタンの有効設定リストを取得します。</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : K2013/09/10</br>
        /// </remarks>
        public bool[] GetNewButtonEnabledList()
        {
            bool[] newButton = { true, false };
            return newButton;
        }

        /// <summary>
        /// データテーブルの選択データインデックスリスト設定処理
        /// </summary>
        /// <param name="indexList">データテーブルの選択データインデックスリスト</param>
        /// <remarks>
        /// <br>Note       : データテーブルの選択データインデックスリストを設定します。</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : K2013/09/10</br>
        /// </remarks>
        public void SetDataIndexList(int[] indexList)
        {
            int[] intVal = indexList;
            this._mainDataIndex = intVal[0];
            this._detailDataIndex = intVal[1];
        }

        /// <summary>
        /// データ削除処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 選択中のデータを削除します。</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : K2013/09/10</br>
        /// </remarks>
        public int Delete()
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            ArrayList logDelList = new ArrayList();
            ProtyWarehouse protyWarehouse = new ProtyWarehouse();

            int maxRow = this.Bind_DataSet.Tables[TABLE_DETAIL].Rows.Count;
            for (int i = 0; i < maxRow; i++)
            {
                Guid guid = (Guid)this.Bind_DataSet.Tables[TABLE_DETAIL].Rows[i][DETAIL_WAREHOUSEGUID];
                protyWarehouse = ((ProtyWarehouse)this._detailTable[guid]).Clone();
                logDelList.Add(protyWarehouse);
            }

            status = this._protyWarehouseAcs.LogicalDelete(ref logDelList);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        // 排他処理
                        ExclusiveTransaction(status);
                        int totalCount = 0;

                        // 再検索
                        Search(ref totalCount, 0);
                        return status;
                    }
                case -2:
                    {
                        //主作業設定で使用中
                        TMsgDisp.Show(this,
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,
                            ASSEMBLY_ID,
                            "このレコードは主作業設定で使用されているため削除できません",
                            status,
                            MessageBoxButtons.OK);
                        this.Hide();

                        return status;
                    }
                default:
                    {
                        // 論理削除処理の失敗
                        ShowMessageBox(emErrorLevel.ERR_LEVEL_STOP,
                                       "Delete",
                                       "論理削除失敗しました。",
                                       status,
                                       MessageBoxButtons.OK);

                        return status;
                    }
            }

            // データセット展開処理
            int index = 0;
            int logDelCnt = 0;         // 0はメインGrid情報、0以外は詳細Grid情報
            // 論理削除レコードをDataSetに反映
            foreach (ProtyWarehouse wkPartsPosCodeU in logDelList)
            {
                if (logDelCnt == 0)
                {
                    index = this._mainDataIndex;
                    MainToDataSet(wkPartsPosCodeU.Clone(), index);
                }

                DetailToDataSet(wkPartsPosCodeU.Clone(), logDelCnt++);
            }
            return status;
        }

        /// <summary>
        /// グリッド列外観情報取得処理
        /// </summary>
        /// <returns>グリッド列外観情報格納Hashtable</returns>
        /// <remarks>
        /// <br>Note       : 各列の外見を設定するクラスを格納したHashtableを取得します。</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : K2013/09/10</br>
        /// </remarks>
        public void GetAppearanceTable(out Hashtable[] appearanceTable)
        {
            //==============================
            // メイン
            //==============================
            Hashtable main = new Hashtable();
            // 削除日
            main.Add(MAIN_DELETEDATE, new GridColAppearance(MGridColDispType.DeletionDataBoth, ContentAlignment.MiddleLeft, "", Color.Red));
            // 拠点コード
            main.Add(MAIN_SECTIONCODE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 拠点名称
            main.Add(MAIN_SECTIONNAME, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 拠点情報GUID
            main.Add(MAIN_SECTIONGUID, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));

            //==============================
            // 詳細
            //==============================
            Hashtable detail = new Hashtable();

            // 削除日
            detail.Add(DETAIL_DELETEDATE, new GridColAppearance(MGridColDispType.DeletionDataBoth, ContentAlignment.MiddleLeft, "", Color.Red));
            // 優先順位
            detail.Add(DETAIL_WAREHPROTYODR, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            // 倉庫コード
            detail.Add(DETAIL_WAREHOUSECODE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 倉庫名称
            detail.Add(DETAIL_WAREHOUSENAME, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 倉庫情報GUID
            detail.Add(DETAIL_WAREHOUSEGUID, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
            // 更新日時
            detail.Add(DETAIL_UPDATETIME, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));

            appearanceTable = new Hashtable[2];
            appearanceTable[0] = main;
            appearanceTable[1] = detail;
        }

        /// <summary>
        /// 明細データ検索処理
        /// </summary>
        /// <param name="totalCount">全該当件数</param>
        /// <param name="readCount">抽出対象件数</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 先頭から指定件数分のデータを検索し、抽出結果を展開したDataSetと全該当件数を返します。</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : K2013/09/10</br>
        /// </remarks>
        public int DetailsDataSearch(ref int totalCount, int readCount)
        {
            ArrayList retList;

            // 現在保持しているデータをクリアする
            this.Bind_DataSet.Tables[TABLE_DETAIL].Rows.Clear();
            this._detailTable.Clear();

            // readCountが負の場合、強制終了
            if (readCount < 0) return 0;

            // 選択されているデータを取得する
            string sectionCode = (string)this.Bind_DataSet.Tables[TABLE_MAIN].Rows[this._mainDataIndex][MAIN_SECTIONCODE];

            // 検索処理（論理削除含む）
            int status = this._protyWarehouseAcs.Read(out retList, this._enterpriseCode, sectionCode, ConstantManagement.LogicalMode.GetData01);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    {
                        // 取得したクラスをデータセットへ展開する
                        int index = 0;
                        foreach (ProtyWarehouse protyWarehouse in retList)
                        {
                            // DataSet展開処理
                            DetailToDataSet(protyWarehouse, index);
                            index++;
                        }

                        totalCount = retList.Count;

                        break;
                    }
                default:
                    {
                        ShowMessageBox(emErrorLevel.ERR_LEVEL_STOP,
                                       "DetailsDataSearch",
                                       "読み込みに失敗しました。",
                                       status,
                                       MessageBoxButtons.OK);

                        totalCount = 0;

                        break;
                    }
            }

            return (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
        }

        /// <summary>
        /// データ検索処理
        /// </summary>
        /// <param name="totalCount">全該当件数</param>
        /// <param name="readCount">抽出対象件数</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 先頭から指定件数分のデータを検索し、抽出結果を展開したDataSetと全該当件数を返します。</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : K2013/09/10</br>
        /// </remarks>
        public int Search(ref int totalCount, int readCount)
        {
            // 現在保持しているデータをクリアする
            this.Bind_DataSet.Tables[TABLE_MAIN].Rows.Clear();

            ArrayList protyWarehouseList;

            int status = this._protyWarehouseAcs.Search(out protyWarehouseList, this._enterpriseCode);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    {
                        List<string> sectionCodeList = new List<string>();
                        int index = 0;

                        // バッファ保持
                        foreach (ProtyWarehouse protyWarehouse in protyWarehouseList)
                        {
                            if (!sectionCodeList.Contains(protyWarehouse.SectionCode.Trim()))
                            {
                                sectionCodeList.Add(protyWarehouse.SectionCode.Trim());
                                // 優先倉庫設定情報クラスのデータセット展開処理
                                MainToDataSet(protyWarehouse.Clone(), index);
                                ++index;
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
                        ShowMessageBox(emErrorLevel.ERR_LEVEL_STOP,
                                       "Search",
                                       "読み込みに失敗しました。",
                                       status,
                                       MessageBoxButtons.OK);

                        totalCount = 0;

                        break;
                    }
            }

            totalCount = this._mainTable.Count;

            return (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
        }

        /// <summary>
        /// ネクストデータ検索処理
        /// </summary>
        /// <param name="readCount">抽出対象件数</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 指定した件数分のネクストデータを検索します。</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : K2013/09/10</br>
        /// </remarks>
        public int SearchNext(int readCount)
        {
            // 未実装
            return (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
        }

        /// <summary>
        /// 明細ネクストデータ検索処理
        /// </summary>
        /// <param name="readCount">抽出対象件数</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 指定した件数分のネクストデータを検索します。</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : K2013/09/10</br>
        /// </remarks>
        public int DetailsDataSearchNext(int readCount)
        {
            // 未実装
            return (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
        }

        /// <summary>
        /// 印刷処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 印刷処理を実行します。</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : K2013/09/10</br>
        /// </remarks>
        public int Print()
        {
            // 未実装
            return (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
        }

        /// <summary>画面非表示イベント</summary>
        /// <remarks>画面が非表示状態になった際に発生します。</remarks>
        public event MasterMaintenanceArrayTypeUnDisplayingEventHandler UnDisplaying;

        #endregion ■ IMasterMaintenanceArrayType メンバ

        #region ■ Private Methods
        /// <summary>
        /// 拠点マスタ読込処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 拠点マスタを読込、バッファに保持します。</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : K2013/09/10</br>
        /// </remarks>
        private void ReadSecInfoSet()
        {
            this._secInfoSetDic = new Dictionary<string, SecInfoSet>();
            ArrayList secInfoList;

            if (this._secInfoSetAcs == null)
            {
                this._secInfoSetAcs = new SecInfoSetAcs();
            }

            // 拠点情報を取得
            int status = this._secInfoSetAcs.SearchAll(out secInfoList, this._enterpriseCode);

            if (status == 0)
            {
                foreach (SecInfoSet secInfoSet in secInfoList)
                {
                    if (secInfoSet.LogicalDeleteCode == 0)
                    {
                        this._secInfoSetDic.Add(secInfoSet.SectionCode.Trim(), secInfoSet);
                    }
                }
            }
            else
            {

                TMsgDisp.Show(
                this,
                emErrorLevel.ERR_LEVEL_STOPDISP,
                this.Name,
                "拠点情報取得に失敗しました。",
                status,
                MessageBoxButtons.OK);
   
            }
        }

        /// <summary>
        /// 拠点名称取得処理
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <returns>拠点名称</returns>
        /// <remarks>
        /// <br>Note       : 拠点名を取得します。</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : K2013/09/10</br>
        /// </remarks>
        private string GetSectionName(string sectionCode)
        {
            string sectionName = "";

            if (this._secInfoSetDic.ContainsKey(sectionCode.Trim()))
            {
                sectionName = this._secInfoSetDic[sectionCode.Trim()].SectionGuideNm.Trim();
            }

            return sectionName;
        }

        /// <summary>
        /// 倉庫名称取得処理
        /// </summary>
        /// <param name="warehousecode">倉庫コード</param>
        /// <returns>倉庫名称</returns>
        /// <remarks>
        /// <br>Note       : 倉庫名称を取得します。</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : K2013/09/10</br>
        /// </remarks>
        private void ReadWarehouseInfo()
        {
            this._warehouseInfoDic = new Dictionary<string, Warehouse>();

            ArrayList warehouseList;

            if (this._warehouseGuideAcs == null)
            {
                this._warehouseGuideAcs = new WarehouseAcs();
            }

            // 倉庫情報取得
            int status = this._warehouseGuideAcs.Search(out warehouseList, this._enterpriseCode);
            if (status == 0)
            {
                foreach (Warehouse warehouse in warehouseList)
                {
                    if (warehouse.LogicalDeleteCode == 0)
                    {
                        this._warehouseInfoDic.Add(warehouse.WarehouseCode.Trim(), warehouse);
                    }
                }
            }
            else
            {

                TMsgDisp.Show(
                this,
                emErrorLevel.ERR_LEVEL_STOPDISP,
                this.Name,
                "倉庫情報取得に失敗しました。",
                status,
                MessageBoxButtons.OK);
   
            }
        }

        /// <summary>
        /// 倉庫名取得処理
        /// </summary>
        /// <param name="customerCode">倉庫コード</param>
        /// <returns>倉庫名</returns>
        /// <remarks>
        /// <br>Note       : 倉庫名を取得します。</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : K2013/09/10</br>
        /// </remarks>
        private string GetWarehouseName(string warehouseCode)
        {
            string warehouseName = "";

            if (this._warehouseInfoDic.ContainsKey(warehouseCode.PadLeft(4, '0')))
            {
                warehouseName = this._warehouseInfoDic[warehouseCode.PadLeft(4, '0')].WarehouseName.Trim();
            }

            return warehouseName;
        }

        /// <summary>
        /// 倉庫優先順が設定されたの場合
        /// </summary>
        /// <returns>チェック結果</returns>
        /// <br>Note       : チェックを実行します。</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : K2013/09/10</br>
        private bool CheckMainIndex()
        { 
            bool checkFlg = false;

            int totalCount = 0;
            // 再検索
            Search(ref totalCount, 0);

            if (this.Bind_DataSet.Tables[TABLE_MAIN].Rows.Count > 0)
            {
                int count = this.Bind_DataSet.Tables[TABLE_MAIN].Rows.Count;
                for (int index = 0; index < count; index++)
                {
                    // 倉庫優先順が設定されたの場合、新規ボタンクリック不可
                    string deleteDate = (string)this.Bind_DataSet.Tables[TABLE_MAIN].Rows[index][MAIN_DELETEDATE];
                    string sectionCode = (string)this.Bind_DataSet.Tables[TABLE_MAIN].Rows[index][MAIN_SECTIONCODE];
                    if (string.IsNullOrEmpty(deleteDate))
                    {
                        checkFlg = true;
                        if (this.tEdit_SectionCode.DataText.Trim() != "" && this.tEdit_SectionCode.DataText.Trim().Equals(sectionCode))
                        {
                            checkFlg = false;
                        }
                    }
                }
            }

            if (checkFlg)
            {
                ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                                  "複数登録できません。修正又は、削除後に登録して下さい。",
                                  0,
                                  MessageBoxButtons.OK,
                                  MessageBoxDefaultButton.Button1);

                if (UnDisplaying != null)
                {
                    MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                    UnDisplaying(this, me);
                }

                this.DialogResult = DialogResult.Cancel;

                // GridのIndexBuffer格納用変数初期化
                this._mainIndexBuffer = -2;
                this._detailsIndexBuffer = -2;
                this._targetTableBuffer = "";

                if (CanClose == true)
                {
                    this.Close();
                }
                else
                {
                    this.Hide();
                }

                return false;
            }

            return true;
        }

        /// <summary>
        /// 画面初期化処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面情報を初期化します。</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date	   : K2013/09/10</br>
        /// </remarks>
        private void ScreenClear()
        {
            // 拠点
            this.tEdit_SectionCode.Clear();
            this.tEdit_SectionName.Clear();

            // Grid行のクリア
            this._bindTable.Rows.Clear();
        }

        /// <summary>
        /// 画面初期設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面の初期設定を行います。</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date	   : K2013/09/10</br>
        /// </remarks>
        private void ScreenInitialSetting()
        {
            // マスタ読込
            ReadSecInfoSet();

            ReadWarehouseInfo();

            // スキーマの設定 
            DataTableSchemaSetting();

            // GRIDの初期設定
            GridInitialSetting();
        }

        /// <summary>
        /// グリッドバインド処理
        /// </summary>
        /// <remarks>
        /// <br>Note	   : 配列項目をグリッドへバインドします。</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : K2013/09/11</br>
        /// </remarks>
        private void DataTableSchemaSetting()
        {
            _bindTable.Columns.Clear();

            // スキーマの設定
            _bindTable.Columns.Add(COLUMN_SCREENID, typeof(int));
            _bindTable.Columns.Add(COLUMN_WAREHPROTYODR, typeof(string));
            _bindTable.Columns.Add(COLUMN_WAREHOUSECODE, typeof(string));
            _bindTable.Columns.Add(COLUMN_WAREHOUSEGUIDE, typeof(Guid));
            _bindTable.Columns.Add(COLUMN_WAREHOUSENAME, typeof(string));
            _bindTable.Columns[COLUMN_WAREHOUSEGUIDE].Caption = "";

        }

        /// <summary>
        ///	UI画面のGRID初期設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note	   : GRIDの初期設定を行います。</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : K2013/09/11</br>
        /// </remarks>
        private void GridInitialSetting()
        {
            // データソースへ追加
            this.uGrid_ProtyWarehouse.DataSource = _bindTable;

            // GRID属性
            // グリッドの背景
            AppearanceBase appearance = this.uGrid_ProtyWarehouse.DisplayLayout.Appearance;
            // タイトルの外観
            AppearanceBase headerAppearance = this.uGrid_ProtyWarehouse.DisplayLayout.Override.HeaderAppearance;
            // 選択行の外観
            AppearanceBase selectedRowAppearance = this.uGrid_ProtyWarehouse.DisplayLayout.Override.SelectedRowAppearance;
            // アクティブ行の外観
            AppearanceBase activeRowAppearance = this.uGrid_ProtyWarehouse.DisplayLayout.Override.ActiveRowAppearance;
            // 行セレクタの外観
            AppearanceBase rowSelectorAppearance = this.uGrid_ProtyWarehouse.DisplayLayout.Override.RowSelectorAppearance;
            // 特別属性
            UltraGridOverride ultraGridOverride = this.uGrid_ProtyWarehouse.DisplayLayout.Override;
            // グリッド列
            ColumnsCollection columns = this.uGrid_ProtyWarehouse.DisplayLayout.Bands[0].Columns;
            
            // グリッドの背景色
            appearance.BackColor = Color.White;
            appearance.BackColor2 = Color.FromArgb(198, 219, 255);
            appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            // 罫線の色を変更
            appearance.BorderColor = Color.FromArgb(1, 68, 208);

            // 行の追加不可
            ultraGridOverride.AllowAddNew = AllowAddNew.No;
            // 行のサイズ変更不可
            ultraGridOverride.RowSizing = RowSizing.Fixed;
            // 行の削除可
            ultraGridOverride.AllowDelete = DefaultableBoolean.True;
            // 列の移動不可
            ultraGridOverride.AllowColMoving = AllowColMoving.NotAllowed;
            // 列のサイズ変更不可
            ultraGridOverride.AllowColSizing = AllowColSizing.None;
            // 列の交換不可
            ultraGridOverride.AllowColSwapping = AllowColSwapping.NotAllowed;
            // フィルタの使用不可
            ultraGridOverride.AllowRowFiltering = DefaultableBoolean.False;

            // タイトルの外観設定
            headerAppearance.BackColor = Color.FromArgb(89, 135, 214);
            headerAppearance.BackColor2 = Color.FromArgb(7, 59, 150);
            headerAppearance.BackGradientStyle = GradientStyle.Vertical;
            headerAppearance.ForeColor = Color.White;
            headerAppearance.ThemedElementAlpha = Alpha.Transparent;

            // グリッドの選択方法を設定（セル単体の選択のみ許可）
            ultraGridOverride.SelectTypeCol = SelectType.None;
            ultraGridOverride.SelectTypeRow = SelectType.Single;
            // 互い違いの行の色を変更
            ultraGridOverride.RowAlternateAppearance.BackColor = Color.Lavender;
            // 行セレクタ表示無し
            ultraGridOverride.RowSelectors = DefaultableBoolean.True;

            ultraGridOverride.EditCellAppearance.BackColor = Color.FromArgb(247, 227, 156);
            ultraGridOverride.ActiveCellAppearance.TextVAlign = VAlign.Middle;
            ultraGridOverride.EditCellAppearance.TextVAlign = VAlign.Middle;
            ultraGridOverride.CellAppearance.TextVAlign = VAlign.Middle;

            // 選択行の外観設定
            selectedRowAppearance.BackColor = Color.FromArgb(251, 230, 148);
            selectedRowAppearance.BackColor2 = Color.FromArgb(238, 149, 21);
            selectedRowAppearance.BackGradientStyle = GradientStyle.Vertical;
            selectedRowAppearance.ForeColor = Color.Black;
            selectedRowAppearance.BackColorDisabled = Color.FromArgb(251, 230, 148);
            selectedRowAppearance.BackColorDisabled2 = Color.FromArgb(238, 149, 21);
            // アクティブ行の外観設定
            activeRowAppearance.BackColor = Color.FromArgb(251, 230, 148);
            activeRowAppearance.BackColor2 = Color.FromArgb(238, 149, 21);
            activeRowAppearance.BackGradientStyle = GradientStyle.Vertical;
            activeRowAppearance.ForeColor = Color.Black;
            activeRowAppearance.BackColorDisabled = Color.FromArgb(251, 230, 148);
            activeRowAppearance.BackColorDisabled2 = Color.FromArgb(238, 149, 21);

            // 行セレクタの外観設定
            rowSelectorAppearance.BackColor = Color.FromArgb(((System.Byte)(89)), ((System.Byte)(135)), ((System.Byte)(214)));
            rowSelectorAppearance.BackColor2 = Color.FromArgb(((System.Byte)(7)), ((System.Byte)(59)), ((System.Byte)(150)));
            rowSelectorAppearance.BackGradientStyle = GradientStyle.Vertical;

            // ヘッダーキャプション
            columns[COLUMN_WAREHPROTYODR].Header.Caption = "優先順位";
            columns[COLUMN_WAREHOUSECODE].Header.Caption = "倉庫コード";
            columns[COLUMN_WAREHOUSEGUIDE].Header.Caption = "";
            columns[COLUMN_WAREHOUSENAME].Header.Caption = "倉庫名称";

            // 倉庫優先順位列の設定
            columns[COLUMN_WAREHPROTYODR].CellActivation = Activation.AllowEdit;
            columns[COLUMN_WAREHPROTYODR].CellAppearance.TextHAlign = HAlign.Right;
            columns[COLUMN_WAREHPROTYODR].TabStop = true;

            // 倉庫コード列の設定
            columns[COLUMN_WAREHOUSECODE].CellActivation = Activation.AllowEdit;
            columns[COLUMN_WAREHOUSECODE].TabStop = true;

            // ガイドボタンの設定
            columns[COLUMN_WAREHOUSEGUIDE].CellActivation = Activation.NoEdit;
            columns[COLUMN_WAREHOUSEGUIDE].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;
            columns[COLUMN_WAREHOUSEGUIDE].ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always;
            columns[COLUMN_WAREHOUSEGUIDE].CellButtonAppearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
            columns[COLUMN_WAREHOUSEGUIDE].TabStop = true;

            // 倉庫名称列の設定
            columns[COLUMN_WAREHOUSENAME].CellActivation = Activation.NoEdit;
            columns[COLUMN_WAREHOUSENAME].TabStop = false;

            //特定列を非表示に
            columns[COLUMN_SCREENID].Hidden = true;

            // セルの幅の設定
            columns[COLUMN_WAREHPROTYODR].Width = 60;
            columns[COLUMN_WAREHOUSECODE].Width = 100;
            columns[COLUMN_WAREHOUSEGUIDE].Width = 20;
            columns[COLUMN_WAREHOUSENAME].Width = 370;

            // MaxLength
            columns[COLUMN_WAREHPROTYODR].MaxLength = 2;
            columns[COLUMN_WAREHOUSECODE].MaxLength = 4;
            columns[COLUMN_WAREHOUSENAME].MaxLength = 20;

        }

        /// <summary>
        ///	Grid 新規行の追加
        /// </summary>
        /// <remarks>
        /// <br>Note	   : GRIDに新規行を追加します。</br>
        /// <br></br>
        /// </remarks>
        private void AddBindTableRow()
        {
            if (this._bindTable.Rows.Count == 99)
            {
                // MAX99行とする
                return;
            }

            // ガイドで選択した倉庫コードを追加
            DataRow bindRow;

            bindRow = this._bindTable.NewRow();

            // 倉庫情報をGridに追加
            bindRow[COLUMN_SCREENID] = this._bindTable.Rows.Count + 1;
            bindRow[COLUMN_WAREHPROTYODR] = "";
            bindRow[COLUMN_WAREHOUSECODE] = "";
            bindRow[COLUMN_WAREHOUSENAME] = "";

            this._bindTable.Rows.Add(bindRow);
        }

        /// <summary>
        /// DataSet展開処理(メインテーブル)
        /// </summary>
        /// <param name="protyWarehouse">優先倉庫マスタ</param>
        /// <param name="index">行インデックス</param>
        /// <remarks>
        /// <br>Note       : 優先倉庫マスタをDataSetに展開します。</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date	   : K2013/09/10</br>
        /// </remarks>
        private void MainToDataSet(ProtyWarehouse protyWarehouse, int index)
        {
            if ((index < 0) || (this.Bind_DataSet.Tables[TABLE_MAIN].Rows.Count <= index))
            {
                // 新規と判断して、行を追加する
                DataRow dataRow = this.Bind_DataSet.Tables[TABLE_MAIN].NewRow();
                this.Bind_DataSet.Tables[TABLE_MAIN].Rows.Add(dataRow);

                // indexを行の最終行番号する
                index = this.Bind_DataSet.Tables[TABLE_MAIN].Rows.Count - 1;
            }

            // 削除日
            if (protyWarehouse.LogicalDeleteCode == 0)
            {
                this.Bind_DataSet.Tables[TABLE_MAIN].Rows[index][MAIN_DELETEDATE] = "";
            }
            else
            {
                this.Bind_DataSet.Tables[TABLE_MAIN].Rows[index][MAIN_DELETEDATE] = protyWarehouse.UpdateDateTimeJpInFormal;
            }

            // 拠点コード
            this.Bind_DataSet.Tables[TABLE_MAIN].Rows[index][MAIN_SECTIONCODE] = protyWarehouse.SectionCode.Trim();
            // 拠点名称
            this.Bind_DataSet.Tables[TABLE_MAIN].Rows[index][MAIN_SECTIONNAME] = protyWarehouse.SectionName.Trim();

            // 拠点情報GUID
            this.Bind_DataSet.Tables[TABLE_MAIN].Rows[index][MAIN_SECTIONGUID] = protyWarehouse.SectionCode.Trim();

            if (this._mainTable.ContainsKey(protyWarehouse.SectionCode.Trim()))
            {
                this._mainTable.Remove(protyWarehouse.SectionCode.Trim());
            }
            this._mainTable.Add(protyWarehouse.SectionCode.Trim(), protyWarehouse);
        }

        /// <summary>
        /// DataSet展開処理(詳細テーブル)
        /// </summary>
        /// <param name="protyWarehouse">優先倉庫マスタ</param>
        /// <param name="index">行インデックス</param>
        /// <remarks>
        /// <br>Note       : 優先倉庫マスタをDataSetに展開します。</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date	   : K2013/09/10</br>
        /// </remarks>
        private void DetailToDataSet(ProtyWarehouse protyWarehouse, int index)
        {
            if ((index < 0) || (this.Bind_DataSet.Tables[TABLE_DETAIL].Rows.Count <= index))
            {
                // 新規と判断して、行を追加する
                DataRow dataRow = this.Bind_DataSet.Tables[TABLE_DETAIL].NewRow();
                this.Bind_DataSet.Tables[TABLE_DETAIL].Rows.Add(dataRow);

                // indexを行の最終行番号する
                index = this.Bind_DataSet.Tables[TABLE_DETAIL].Rows.Count - 1;
            }

            // 更新日時
            this.Bind_DataSet.Tables[TABLE_DETAIL].Rows[index][DETAIL_UPDATETIME] = DateTime.MinValue;
            // 削除日
            if (protyWarehouse.LogicalDeleteCode == 0)
            {
                this.Bind_DataSet.Tables[TABLE_DETAIL].Rows[index][DETAIL_DELETEDATE] = "";
                // 更新日時
                this.Bind_DataSet.Tables[TABLE_DETAIL].Rows[index][DETAIL_UPDATETIME] = protyWarehouse.UpdateDateTime;
            }
            else
            {
                this.Bind_DataSet.Tables[TABLE_DETAIL].Rows[index][DETAIL_DELETEDATE] = protyWarehouse.UpdateDateTimeJpInFormal;
            }

            // 優先順位
            this.Bind_DataSet.Tables[TABLE_DETAIL].Rows[index][DETAIL_WAREHPROTYODR] = protyWarehouse.WarehProtyOdr.ToString();
            // 倉庫コード
            this.Bind_DataSet.Tables[TABLE_DETAIL].Rows[index][DETAIL_WAREHOUSECODE] = protyWarehouse.WarehouseCode;
            // 倉庫名称
            this.Bind_DataSet.Tables[TABLE_DETAIL].Rows[index][DETAIL_WAREHOUSENAME] = protyWarehouse.WarehouseName;
            // 倉庫情報GUID
            this.Bind_DataSet.Tables[TABLE_DETAIL].Rows[index][DETAIL_WAREHOUSEGUID] = protyWarehouse.FileHeaderGuid;

            // ハッシュ検索用にGUIDセット
            if (this._detailTable.ContainsKey(protyWarehouse.FileHeaderGuid) == true)
            {
                this._detailTable.Remove(protyWarehouse.FileHeaderGuid);
            }

            this._detailTable.Add(protyWarehouse.FileHeaderGuid, protyWarehouse);
        }

        /// <summary>
        /// 優先倉庫マスタ クラス画面展開処理
        /// </summary>
        /// <param name="protyWarehouse">対象倉庫設定 オブジェクト</param>
        /// <remarks>
        /// <br>Note       : 優先倉庫マスタ オブジェクトから画面にデータを展開します。</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date	   : K2013/09/10</br>
        /// <br></br>
        /// </remarks>
        private void ProtyWarehouseToScreen(ProtyWarehouse[] protyWarehouse)
        {
            int i = 0;
            int maxRow = protyWarehouse.Length;
            DataRow bindRow;

            // 拠点コード
            this.tEdit_SectionCode.Text = protyWarehouse[i].SectionCode;
            // 拠点名称
            this.tEdit_SectionName.Text = GetSectionName(protyWarehouse[i].SectionCode.Trim());

            // 倉庫情報
            for (; i < maxRow; i++)
            {
                bindRow = this._bindTable.NewRow();

                bindRow[COLUMN_SCREENID] = i + 1;                                                                              // GridのID(非表示)
                bindRow[COLUMN_WAREHPROTYODR] = protyWarehouse[i].WarehProtyOdr.ToString().Trim();      // 表示順位
                bindRow[COLUMN_WAREHOUSECODE] = protyWarehouse[i].WarehouseCode.Trim();                                   // 倉庫コード
                bindRow[COLUMN_WAREHOUSENAME] = GetWarehouseName(protyWarehouse[i].WarehouseCode.Trim());                 // 倉庫名

                this._bindTable.Rows.Add(bindRow);
            }
        }

        /// <summary>
        /// DataSet列情報構築処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : DataSet列情報を構築します。</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date	   : K2013/09/10</br>
        /// </remarks>
        private void DataSetColumnConstruction()
        {
            //==============================
            // メイン
            //==============================
            DataTable mainTable = new DataTable(TABLE_MAIN);
            mainTable.Columns.Add(MAIN_DELETEDATE, typeof(string));       // 削除日
            mainTable.Columns.Add(MAIN_SECTIONCODE, typeof(string));      // 拠点コード
            mainTable.Columns.Add(MAIN_SECTIONNAME, typeof(string));      // 拠点名称
            mainTable.Columns.Add(MAIN_SECTIONGUID, typeof(string));      // 拠点情報GUID

            //==============================
            // 詳細
            //==============================
            DataTable detailTable = new DataTable(TABLE_DETAIL);

            detailTable.Columns.Add(DETAIL_DELETEDATE, typeof(string));             // 削除日
            detailTable.Columns.Add(DETAIL_WAREHPROTYODR, typeof(string)); // 優先順位
            detailTable.Columns.Add(DETAIL_WAREHOUSECODE, typeof(string));          // 倉庫コード
            detailTable.Columns.Add(DETAIL_WAREHOUSENAME, typeof(string));          // 倉庫名称
            detailTable.Columns.Add(DETAIL_WAREHOUSEGUID, typeof(Guid));            // 倉庫情報GUID
            detailTable.Columns.Add(DETAIL_UPDATETIME, typeof(DateTime));           // 更新日時

            this.Bind_DataSet.Tables.Add(mainTable);
            this.Bind_DataSet.Tables.Add(detailTable);
        }

        /// <summary>
        /// 画面再構築処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面を再構築します。</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date	   : K2013/09/10</br>
        /// </remarks>
        private void ScreenReconstruction()
        {
            if (this._mainDataIndex < 0)
            {
                //------------------------------
                // 新規モード
                //------------------------------
                this.Mode_Label.Text = INSERT_MODE;

                // 画面入力許可制御
                ScreenPermissionControl(INSERT_MODE);

                // FreamのIndex/Tableバッファ保持
                this._mainIndexBuffer = -2;
                this._detailsIndexBuffer = this._detailDataIndex;
                this._targetTableBuffer = this._targetTableName;

                // クローン作成
                ProtyWarehouse protyWarehouse = new ProtyWarehouse();
                this._protyWarehouseListClone = new ProtyWarehouse[1];
                this._protyWarehouseListClone[0] = protyWarehouse.Clone();

                // グリッド行を追加
                this.AddBindTableRow();

                // 新規可能性チェック 
                if (!CheckMainIndex())
                {
                    return;
                }

                // フォーカス設定
                this.tEdit_SectionCode.Focus();
            }
            else
            {
                 // 詳細Gridの行数を取得
                int rowCnt = 0;         // 行数カウンタ
                int maxRow = this.Bind_DataSet.Tables[TABLE_DETAIL].Rows.Count;
                ProtyWarehouse[] protyWarehouseList = new ProtyWarehouse[maxRow];

                // 選択拠点の倉庫情報を取得
                for (; rowCnt < maxRow; rowCnt++)
                {
                    Guid guid = (Guid)this.Bind_DataSet.Tables[TABLE_DETAIL].Rows[rowCnt][DETAIL_WAREHOUSEGUID];
                    protyWarehouseList[rowCnt] = (ProtyWarehouse)this._detailTable[guid];
                }

                if (protyWarehouseList[0].LogicalDeleteCode == 0)
                {
                        // 更新モード
                        this.Mode_Label.Text = UPDATE_MODE;

                        // 画面入力許可制御処理
                        ScreenPermissionControl(UPDATE_MODE);

                        // 画面展開処理
                        ProtyWarehouseToScreen(protyWarehouseList);

                        AddBindTableRow();

                        //クローン作成
                        this._protyWarehouseListClone = new ProtyWarehouse[maxRow];
                        for (int i = 0; i < maxRow; i++)
                        {
                            this._protyWarehouseListClone[i] = protyWarehouseList[i].Clone();
                        }
                        
                        // フォーカス設定
                        //this.Cancel_Button.Focus();      // DEL huangt K2013/10/08 No.82 初期フォーカスの改修
                        // --- ADD huangt K2013/10/08 No.82 初期フォーカスの改修 ---------- >>>>>
                        this.uGrid_ProtyWarehouse.Focus();
                        this.uGrid_ProtyWarehouse.Rows[0].Cells[COLUMN_WAREHPROTYODR].Activate();
                        this.uGrid_ProtyWarehouse.PerformAction(UltraGridAction.EnterEditMode);
                        // --- ADD huangt K2013/10/08 No.82 初期フォーカスの改修 ---------- <<<<<
                }
                else
                {
                    // 削除モード
                    this.Mode_Label.Text = DELETE_MODE;

                    // 画面入力許可制御処理
                    ScreenPermissionControl(DELETE_MODE);

                    // 画面展開処理
                    ProtyWarehouseToScreen(protyWarehouseList);

                    this.uGrid_ProtyWarehouse.Rows[0].Selected = false;
                    this.uGrid_ProtyWarehouse.ActiveCell = null;
                    this.uGrid_ProtyWarehouse.ActiveRow = null;
                    
                    //クローン作成
                    this._protyWarehouseListClone = new ProtyWarehouse[maxRow];
                    for (int i = 0; i < maxRow; i++)
                    {
                        this._protyWarehouseListClone[i] = protyWarehouseList[i].Clone();
                    }

                    // フォーカス設定
                    this.Delete_Button.Focus();
                }

                // FreamのIndex/Tableバッファ保持
                this._mainIndexBuffer = this._mainDataIndex;
                this._detailsIndexBuffer = this._detailDataIndex;
                this._targetTableBuffer = this._targetTableName;
            }
        }

        /// <summary>
        /// 画面入力許可制御処理
        /// </summary>
        /// <param name="mode">編集モード</param>
        /// <remarks>
        /// <br>Note       : 編集モードによって画面の入力許可制御を行います。</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date	   : K2013/09/10</br>
        /// </remarks>
        private void ScreenPermissionControl(string screenMode)
        {
            // 新規
            if (screenMode.Equals(INSERT_MODE))
            {
                // ボタン設定
                this.Ok_Button.Visible = true;
                this.Delete_Button.Visible = false;
                this.Revive_Button.Visible = false;
                this.Renewal_Button.Visible = true;
                this.ultraButton_SectionGuide.Visible = true;
                this.ultraButton_SectionGuide.Enabled = true;
                this.DeleteRow_Button.Enabled = true;
                this.uGrid_ProtyWarehouse.Enabled = true;

                // 入力設定
                this.tEdit_SectionCode.Enabled = true;
                this.tEdit_SectionName.Enabled = false;
            }
            // 更新
            else if (screenMode.Equals(UPDATE_MODE))
            {
                // ボタン設定
                this.Ok_Button.Visible = true;
                this.Delete_Button.Visible = false;
                this.Revive_Button.Visible = false;
                this.Renewal_Button.Visible = true;
                this.ultraButton_SectionGuide.Visible = true;
                this.ultraButton_SectionGuide.Enabled = false;
                this.DeleteRow_Button.Enabled = true;
                this.uGrid_ProtyWarehouse.Enabled = true;

                // 入力設定
                this.tEdit_SectionCode.Enabled = false;
                this.tEdit_SectionName.Enabled = false;
            }
            // 削除
            else if (screenMode.Equals(DELETE_MODE))
            {
                // ボタン設定
                this.Ok_Button.Visible = false;
                this.Delete_Button.Visible = true;
                this.Revive_Button.Visible = true;
                this.Renewal_Button.Visible = false;
                this.ultraButton_SectionGuide.Visible = true;
                this.ultraButton_SectionGuide.Enabled = false;

                // 入力設定
                this.tEdit_SectionCode.Enabled = false;
                this.tEdit_SectionName.Enabled = false;
                this.DeleteRow_Button.Enabled = false;
                this.uGrid_ProtyWarehouse.Enabled = false;

            }
        }

        /// <summary>
        /// 画面情報優先倉庫 クラス格納処理
        /// </summary>
        /// <param name="protyWarehouseList">優先倉庫 オブジェクト</param>
        /// <remarks>
        /// <br>Note       : 画面情報から優先倉庫 オブジェクトにデータを格納します。</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date	   : K2013/09/10</br>
        /// <br></br>
        /// </remarks>
        private void DispToProtyWarehouse(ref ArrayList protyWarehouseList)
        {
            int index;
            int rowCnt = this._bindTable.Rows.Count;

            ProtyWarehouse protyWarehouse;
            protyWarehouseList = new ArrayList();

            for (index = 0; index < rowCnt; index++)
            {
                protyWarehouse = new ProtyWarehouse();

                protyWarehouse.EnterpriseCode = this._enterpriseCode;                                 // 企業コード
                protyWarehouse.SectionCode = this.tEdit_SectionCode.Text;                             // 拠点コード

                // 未入力の倉庫はSKIP
                string warehouseCode = (string)this._bindTable.Rows[index][COLUMN_WAREHOUSECODE];
                string warehProtyOdr = (string)this._bindTable.Rows[index][COLUMN_WAREHPROTYODR];
                if (string.IsNullOrEmpty(warehouseCode) && string.IsNullOrEmpty(warehProtyOdr))
                {
                    continue;
                }

                // 明細Grid用の情報取得
                protyWarehouse.WarehouseCode = warehouseCode;                                      // 拠点コード
                if (!string.IsNullOrEmpty(warehProtyOdr))
                {
                    protyWarehouse.WarehProtyOdr = Int32.Parse(warehProtyOdr);                     // 優先順位
                }

                protyWarehouseList.Add(protyWarehouse);
            }
        }

        /// <summary>
        /// 新規モードであるか判断します。
        /// </summary>
        /// <returns>
        /// <c>true</c> :新規モードです。<br/>
        /// <c>false</c>:新規モードではありません。
        /// </returns>
        private bool IsInsertMode()
        {
            return this.Mode_Label.Text.Equals(INSERT_MODE);
        }

        /// <summary>
        /// 保存処理
        /// </summary>
        /// <returns>ステータス(True:成功 False:失敗)</returns>
        /// <remarks>
        /// <br>Note       : 保存処理を行います。</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date	   : K2013/09/10</br>
        /// </remarks>
        private bool SaveProc()
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            string message = string.Empty;
            string loginID = string.Empty;

            ArrayList updateList = new ArrayList();
            ArrayList deleteList = new ArrayList();

            if (this._mainDataIndex < 0)
            {
                if (!CheckMainIndex())
                    return false;
            }

            // 画面入力チェック
            if (!ScreenDataCheck())
            {
                return false;
            }

            if (this._mainDataIndex >= 0)
            {
                // 更新時は、更新対象と削除対象を取得
                this.UpdateCompare(out updateList, out deleteList);

                // 削除対象があれば該当レコードを削除
                if (deleteList.Count != 0)
                {
                    status = this._protyWarehouseAcs.Delete(deleteList);
                    switch (status)
                    {
                        case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                        case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                            {
                                // 排他処理
                                ExclusiveTransaction(status);
                                return false;
                            }
                    }
                }
            }
            else
            {
                //新規の場合、画面情報を条件クラスに設定
                this.DispToProtyWarehouse(ref updateList);
            }

            // 登録／更新処理
            if (updateList.Count != 0 && status == 0)
            {
                status = this._protyWarehouseAcs.Write(ref updateList);
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        {
                            break;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE:
                        {
                            ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                                           "この拠点コードは既に使用されています。",
                                           status,
                                           MessageBoxButtons.OK,
                                           MessageBoxDefaultButton.Button1);

                            this.tEdit_SectionCode.Focus();

                            return false;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                        {
                            // 排他処理
                            ExclusiveTransaction(status);
                            break;
                        }
                    default:
                        {
                            // 登録失敗
                            ShowMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP,
                                           "SaveProc",
                                           "登録に失敗しました。",
                                           status,
                                           MessageBoxButtons.OK);
                            break;
                        }
                }
            }

            int totalCount = 0;

            // 再検索
            Search(ref totalCount, 0);

            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }

            this.DialogResult = DialogResult.Cancel;

            // GridのIndexBuffer格納用変数初期化
            this._mainIndexBuffer = -2;
            this._detailsIndexBuffer = -2;
            this._targetTableBuffer = "";

            if (CanClose == true)
            {
                this.Close();
            }
            else
            {
                this.Hide();
            }

            return true;
        }

        /// <summary>
        /// 物理削除処理
        /// </summary>
        /// <returns>ステータス(True:成功 False:失敗)</returns>
        /// <remarks>
        /// <br>Note       : 物理削除処理を行います。</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date	   : K2013/09/10</br>
        /// </remarks>
        private bool DeleteProc()
        {
            DialogResult result = ShowMessageBox(emErrorLevel.ERR_LEVEL_QUESTION,
                                                 "データを削除します。" + "\r\n" + "よろしいですか？",
                                                 0,
                                                 MessageBoxButtons.OKCancel,
                                                 MessageBoxDefaultButton.Button2);


            if (result != DialogResult.OK)
            {
                this.Delete_Button.Focus();
                return (false);
            }

            // 削除リスト取得
            ArrayList deleteList = new ArrayList();
            ProtyWarehouse protyWarehouse = new ProtyWarehouse();

            // Form 明細Gridの情報を取得
            int maxRow = this.Bind_DataSet.Tables[TABLE_DETAIL].Rows.Count;
            for (int i = 0; i < maxRow; i++)
            {
                Guid guid = (Guid)this.Bind_DataSet.Tables[TABLE_DETAIL].Rows[i][DETAIL_WAREHOUSEGUID];
                protyWarehouse = ((ProtyWarehouse)this._detailTable[guid]).Clone();
                deleteList.Add(protyWarehouse);
            }

            // 削除処理
            int status = this._protyWarehouseAcs.Delete(deleteList);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        this.Bind_DataSet.Tables[TABLE_MAIN].Rows[this._mainDataIndex].Delete();
                        this.Bind_DataSet.Tables[TABLE_DETAIL].Rows.Clear();

                        // メインGridと明細Gridのテーブルを削除
                        int delCnt = 0;
                        foreach (ProtyWarehouse wkProtyWarehouse in deleteList)
                        {
                            if (delCnt == 0)
                            {
                                // メインGridのテーブル
                                this._mainTable.Remove(wkProtyWarehouse.SectionCode.Trim());
                                delCnt++;
                            }

                            // 明細Gridのテーブル
                            this._detailTable.Remove(wkProtyWarehouse.FileHeaderGuid);
                        }

                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        // 排他処理
                        ExclusiveTransaction(status);
                        int totalCount = 0;

                        // 再検索
                        Search(ref totalCount, 0);

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

                        return false;
                    }
                default:
                    {
                        ShowMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP,
                                       "DeleteProc",
                                       "削除に失敗しました。",
                                       status,
                                       MessageBoxButtons.OK);
                        return false;
                    }
            }

            return (true);
        }

        /// <summary>
        /// 復活処理
        /// </summary>
        /// <returns>ステータス(True:成功 False:失敗)</returns>
        /// <remarks>
        /// <br>Note       : 復活処理を行います。</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date	   : K2013/09/10</br>
        /// </remarks>
        private bool RevivalProc()
        {
            // 復活リスト取得
            ArrayList reviveList = new ArrayList();
            foreach (ProtyWarehouse protyWarehouse in this._protyWarehouseListClone)
            {
                reviveList.Add(protyWarehouse.Clone());
            }

            // 復活処理
            int status = this._protyWarehouseAcs.Revival(ref reviveList);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        int totalCount = 0;

                        // 再検索
                        Search(ref totalCount, 0);

                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        // 排他
                        ExclusiveTransaction(status);
                        
                        int totalCount = 0;
                        // 再検索
                        Search(ref totalCount, 0);

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

                        return (false);
                    }
                default:
                    {
                        ShowMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP,
                                       "RevivalProc",
                                       "復活に失敗しました。",
                                       status,
                                       MessageBoxButtons.OK);
                        return (false);
                    }
            }

            return (true);
        }

        /// <summary>
        /// 画面入力情報不正チェック処理
        /// </summary>
        /// <param name="control">不正対象コントロール</param>
        /// <param name="message">メッセージ</param>
        /// <returns>チェック結果（true:OK／false:NG）</returns>
        /// <remarks>
        /// <br>Note       : 画面入力情報の不正チェックを行います。</br>
        /// <br></br>
        /// </remarks>
        private bool ScreenDataCheck()
        {
            // 入力Flag
            bool inputFlg = false;
            string message = string.Empty;

            // 拠点コード
            if (this.tEdit_SectionCode.Text.Trim() == "" || this.tEdit_SectionName.Text.Trim() == "")
            {
                message = this.section_ultraLabel.Text + "コードを入力して下さい。";
                ShowCheckMsg(message);
                this.tEdit_SectionCode.Focus();
                return false;
            }
            else if (GetSectionName(this.tEdit_SectionCode.Text.Trim()) == "")
            {
                message = "拠点コードが登録されていません。";
                ShowCheckMsg(message);
                this.tEdit_SectionCode.Focus();
                return false;
            }

            // Grid
            if (this._bindTable.Rows.Count == 0)
            {
                message = "倉庫コードを１件以上登録して下さい。";
                ShowCheckMsg(message);
                this.uGrid_ProtyWarehouse.Focus();
                return false;
            }
            else if (this._bindTable.Rows.Count > 0)
            {
                for (int i = 0; i < this._bindTable.Rows.Count; i++)
                {
                    string code = (string)this._bindTable.Rows[i][COLUMN_WAREHOUSECODE];
                    string order = (string)this._bindTable.Rows[i][COLUMN_WAREHPROTYODR];

                    // 未入力の行はSKIP
                    if (string.IsNullOrEmpty(code) && string.IsNullOrEmpty(order))
                    {
                        continue;
                    }

                    inputFlg = true;

                    if (string.IsNullOrEmpty(order) && !string.IsNullOrEmpty(code))
                    {
                        message = "優先順位を入力して下さい。";
                        ShowCheckMsg(message);
                        this.uGrid_ProtyWarehouse.Focus();
                        this.uGrid_ProtyWarehouse.Rows[i].Cells[COLUMN_WAREHPROTYODR].Activate();
                        this.uGrid_ProtyWarehouse.PerformAction(UltraGridAction.EnterEditMode);

                        return false;
                    }
                    else if (!string.IsNullOrEmpty(order) && string.IsNullOrEmpty(code))
                    {
                        message = "倉庫コードを入力して下さい。";
                        ShowCheckMsg(message);
                        this.uGrid_ProtyWarehouse.Focus();
                        this.uGrid_ProtyWarehouse.Rows[i].Cells[COLUMN_WAREHOUSECODE].Activate();
                        this.uGrid_ProtyWarehouse.PerformAction(UltraGridAction.EnterEditMode);

                        return false;
                    }

                    if (GetWarehouseName(code.Trim()) == "")
                    {
                        message = "倉庫コードが登録されていません。";
                        ShowCheckMsg(message);
                        this.uGrid_ProtyWarehouse.Focus();
                        this.uGrid_ProtyWarehouse.Rows[i].Cells[COLUMN_WAREHOUSECODE].Activate();
                        this.uGrid_ProtyWarehouse.PerformAction(UltraGridAction.EnterEditMode);
                        return false;
                    }
                }
            }

            if (!inputFlg)
            {
                message = "倉庫コードを１件以上登録して下さい。";
                ShowCheckMsg(message);
                this.uGrid_ProtyWarehouse.Focus();
                // --- ADD huangt K2013/10/08 No.82 初期フォーカスの改修 ---------- >>>>>
                this.uGrid_ProtyWarehouse.Rows[0].Cells[COLUMN_WAREHPROTYODR].Activate();
                this.uGrid_ProtyWarehouse.PerformAction(UltraGridAction.EnterEditMode);
                // --- ADD huangt K2013/10/08 No.82 初期フォーカスの改修 ---------- <<<<<
                return false;
            }

            return true;
        }

        /// <summary>
        /// メッセージ表示処理
        /// </summary>
        /// <param name="message">メッセージ</param>
        /// <remarks>
        /// <br>Note       : メッセージを表示します</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : K2013/09/10</br>
        /// </remarks>
        private void ShowCheckMsg(string message)
        {
            if (message.Length > 0)
            {
                ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                               message,
                               -1,
                               MessageBoxButtons.OK,
                               MessageBoxDefaultButton.Button1);
            }
        }

        /// <summary>
        /// 排他処理
        /// </summary>
        /// <param name="status">STATUS</param>
        /// <remarks>
        /// <br>Note       : 排他処理を行います</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : K2013/09/10</br>
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
        /// <br>Programmer : huangt</br>
        /// <br>Date       : K2013/09/10</br>
        /// </remarks>
        private DialogResult ShowMessageBox(emErrorLevel errLevel, string message, int status, MessageBoxButtons msgButton, MessageBoxDefaultButton defaultButton)
        {
            DialogResult dialogResult;
            dialogResult = TMsgDisp.Show(this,                              // 親ウィンドウフォーム
                                         errLevel,                          // エラーレベル
                                         ASSEMBLY_ID,                       // アセンブリID
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
        /// <br>Programmer : huangt</br>
        /// <br>Date       : K2013/09/10</br>
        /// </remarks>
        private DialogResult ShowMessageBox(emErrorLevel errLevel, string methodName, string message, int status, MessageBoxButtons msgButton)
        {
            DialogResult dialogResult;
            dialogResult = TMsgDisp.Show(this, 						        // 親ウィンドウフォーム
                                         errLevel,			                // エラーレベル
                                         this.Name,						    // プログラム名称
                                         ASSEMBLY_ID, 		  　　			// アセンブリID
                                         methodName,						// 処理名称
                                         "",					            // オペレーション
                                         message,	                        // 表示するメッセージ
                                         status,							// ステータス値
                                         this._protyWarehouseAcs,		// エラーが発生したオブジェクト
                                         msgButton,         			  	// 表示するボタン
                                         MessageBoxDefaultButton.Button1);	// 初期表示ボタン

            return dialogResult;
        }

        /// <summary>
        /// モード変更処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : モード変更処理を行います。</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : K2013/09/10</br>
        /// </remarks>
        private bool ModeChangeProc()
        {
            // 拠点コード
            string sectionCode = this.tEdit_SectionCode.Text.Trim();

            for (int i = 0; i < this.Bind_DataSet.Tables[TABLE_MAIN].Rows.Count; i++)
            {
                // データセットと比較
                string dsSectionCode = (string)this.Bind_DataSet.Tables[TABLE_MAIN].Rows[i][MAIN_SECTIONCODE];
                if (sectionCode.Equals(dsSectionCode))
                {
                    // 入力コードがデータセットに存在する場合
                    if ((string)this.Bind_DataSet.Tables[TABLE_MAIN].Rows[i][MAIN_DELETEDATE] != "")
                    {
                        // 論理削除
                        TMsgDisp.Show(this, 					// 親ウィンドウフォーム
                          emErrorLevel.ERR_LEVEL_INFO,          // エラーレベル
                          ASSEMBLY_ID,						        // アセンブリＩＤまたはクラスＩＤ
                          "入力されたコードの優先倉庫マスタ情報は既に削除されています。", 			// 表示するメッセージ
                          0, 									// ステータス値
                          MessageBoxButtons.OK);				// 表示するボタン
                        // 拠点コード、名称のクリア
                        this.tEdit_SectionCode.Clear();
                        this.tEdit_SectionName.Clear();
                        return true;
                    }

                    DialogResult res = TMsgDisp.Show(
                        this,                                   // 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_INFO,            // エラーレベル
                        ASSEMBLY_ID,                                  // アセンブリＩＤまたはクラスＩＤ
                        "入力されたコードの優先倉庫マスタ情報が既に登録されています。\n編集を行いますか？",   // 表示するメッセージ
                        0,                                      // ステータス値
                        MessageBoxButtons.YesNo);               // 表示するボタン
                    switch (res)
                    {
                        case DialogResult.Yes:
                            {
                                // 一時的に詳細テーブルを更新
                                int selectedMainDataIndex = GetSelectedMainDataIndex();

                                this._mainDataIndex = i;
                                this._detailDataIndex = 0;
                                int dummy = 0;
                                DetailsDataSearch(ref dummy, 0);

                                // 画面再描画
                                ScreenClear();
                                ScreenReconstruction();

                                // 詳細テーブルを元に戻す
                                this._mainDataIndex = selectedMainDataIndex;
                                dummy = 0;
                                DetailsDataSearch(ref dummy, 0);

                                // モード変更可能フラグを落とす
                                CanChangeMode = false;
                                break;
                            }
                        case DialogResult.No:
                            {
                                // 拠点コード、名称のクリア
                                this.tEdit_SectionCode.Clear();
                                this.tEdit_SectionName.Clear();
                                break;
                            }
                    }
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 現在、選択されているメインデータのインデックスを取得します。
        /// </summary>
        /// <returns>現在、選択されているメインデータのインデックス</returns>
        /// <remarks>
        /// <br>Note       : 現在、選択されているメインデータのインデックスを取得します。</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date	   : K2013/09/10</br>
        /// </remarks>
        private int GetSelectedMainDataIndex()
        {
            // メインデータの数量は0の場合
            if (this.Bind_DataSet.Tables[TABLE_DETAIL].Rows.Count.Equals(0))
            {
                return (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            }

            Guid guid = (Guid)this.Bind_DataSet.Tables[TABLE_DETAIL].Rows[0][DETAIL_WAREHOUSEGUID];
            ProtyWarehouse protyWarehouse = (ProtyWarehouse)this._detailTable[guid];

            for (int i = 0; i < this.Bind_DataSet.Tables[TABLE_MAIN].Rows.Count; i++)
            {
                string sectionCode = this.Bind_DataSet.Tables[TABLE_MAIN].Rows[i][MAIN_SECTIONCODE].ToString();
                if (protyWarehouse.SectionCode.Equals(sectionCode.Trim()))
                {
                    return i;
                }
            }
            return (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
        }

        /// <summary>
        /// 更新前後のデータ比較と更新対象格納処理
        /// </summary>
        /// <param name="updateList">更新対象レコードを格納</param>
        /// <param name="deleteList">削除対象レコードを格納</param>
        /// <remarks>
        /// <br>Note       : 更新前後のデータを比較して更新／削除対象データを格納します。</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date	   : K2013/09/10</br>
        /// </remarks>
        private void UpdateCompare(out ArrayList updateList, out ArrayList deleteList)
        {
            updateList = new ArrayList();
            deleteList = new ArrayList();
            ArrayList tempList = new ArrayList();
            // 更新日時(排他用)
            Dictionary<string, DateTime> maxUpdateDic = new Dictionary<string,DateTime>();

            // 変更flag
            bool deleteFlg;
            bool insertFlg;

            // 最新更新日時
            DateTime maxUpdateDateTime = DateTime.MinValue;

            ProtyWarehouse protyWarehouse;

            // Form 明細Grid情報とUI画面のGridを取得して比較
            int detailRowCnt = this._detailTable.Count;             // 明細Gridの行数
            int uiGridRowCnt = this._bindTable.Rows.Count;          // UI画面のGrid行数

            // 最新更新日時を取得
            for (int detailIndex = 0; detailIndex < detailRowCnt; detailIndex++)
            {
                // 明細Grid情報を取得
                Guid guid = (Guid)this.Bind_DataSet.Tables[TABLE_DETAIL].Rows[detailIndex][DETAIL_WAREHOUSEGUID];
                protyWarehouse = ((ProtyWarehouse)this._detailTable[guid]).Clone();
 
                if (protyWarehouse.UpdateDateTime > maxUpdateDateTime)
                {
                    maxUpdateDateTime = protyWarehouse.UpdateDateTime;
                }

                if (!maxUpdateDic.ContainsKey(protyWarehouse.WarehouseCode.Trim()))
                {
                    maxUpdateDic.Add(protyWarehouse.WarehouseCode.Trim(), protyWarehouse.UpdateDateTime);
                }

            }

            // 明細Grid情報の行数分を比較
            for (int detailIndex = 0; detailIndex < detailRowCnt; detailIndex++)
            {
                deleteFlg = true;
                // 明細Grid情報を取得
                Guid guid = (Guid)this.Bind_DataSet.Tables[TABLE_DETAIL].Rows[detailIndex][DETAIL_WAREHOUSEGUID];
                protyWarehouse = ((ProtyWarehouse)this._detailTable[guid]).Clone();

                for (int gridIndex = 0; gridIndex < uiGridRowCnt; gridIndex++)
                {
                    // UI画面のGridから情報を取得
                    string warehouseCode = (string)this._bindTable.Rows[gridIndex][COLUMN_WAREHOUSECODE];
                    string warehProtyOdr = (string)this._bindTable.Rows[gridIndex][COLUMN_WAREHPROTYODR];

                    // 未入力の行はSKIP
                    if (string.IsNullOrEmpty(warehouseCode) && string.IsNullOrEmpty(warehProtyOdr))
                    {
                        continue;
                    }

                    if (warehouseCode.Equals(protyWarehouse.WarehouseCode.Trim()))
                    {
                        deleteFlg = false;
                        // 優先順位未変更
                        if (warehProtyOdr.Equals(protyWarehouse.WarehProtyOdr.ToString()))
                        {
                            continue;
                        }
                        else
                        {
                            //優先順位が変わるので、UI画面のGrid情報は新規追加となる
                            ProtyWarehouse updateProtyWarehouse = new ProtyWarehouse();
                            updateProtyWarehouse.EnterpriseCode = this._enterpriseCode;                            // 企業コード
                            updateProtyWarehouse.SectionCode = this.tEdit_SectionCode.Text;                        // 拠点コード
                            updateProtyWarehouse.WarehouseCode = warehouseCode;                                    // 倉庫コード
                            updateProtyWarehouse.UpdateDateTime = protyWarehouse.UpdateDateTime;                   // 更新日時
                            updateProtyWarehouse.FileHeaderGuid = protyWarehouse.FileHeaderGuid;                   // GUID
                            if (!string.IsNullOrEmpty(warehProtyOdr))
                            {
                                updateProtyWarehouse.WarehProtyOdr = int.Parse(warehProtyOdr);                         // 優先順位
                            }
                            tempList.Add(updateProtyWarehouse);
                        }
                    }
                }

                if (deleteFlg)
                {
                    protyWarehouse.MaxUpdateDateTime = maxUpdateDateTime;
                    maxUpdateDic.Remove(protyWarehouse.WarehouseCode.Trim());
                    deleteList.Add(protyWarehouse);
                }
            }

            // 新規追加データを取得
            for (int gridIndex = 0; gridIndex < uiGridRowCnt; gridIndex++)
            {
                insertFlg = true;
                // UI画面のGridから情報を取得
                string warehouseCode = (string)this._bindTable.Rows[gridIndex][COLUMN_WAREHOUSECODE];
                string warehProtyOdr = (string)this._bindTable.Rows[gridIndex][COLUMN_WAREHPROTYODR];

                // 未入力の行はSKIP
                if (string.IsNullOrEmpty(warehouseCode) && string.IsNullOrEmpty(warehProtyOdr))
                {
                    continue;
                }

                for (int detailIndex = 0; detailIndex < detailRowCnt; detailIndex++)
                {
                    // 明細Grid情報を取得
                    Guid guid = (Guid)this.Bind_DataSet.Tables[TABLE_DETAIL].Rows[detailIndex][DETAIL_WAREHOUSEGUID];
                    protyWarehouse = ((ProtyWarehouse)this._detailTable[guid]).Clone();

                    if (protyWarehouse.WarehouseCode.Trim().Equals(warehouseCode.Trim()))
                    {
                        insertFlg = false;
                    }
                }

                // 倉庫コードが不一致の場合、新規追加として更新対象に追加
                if (insertFlg)
                {
                    ProtyWarehouse insertProtyWarehouse = new ProtyWarehouse();
                    insertProtyWarehouse.EnterpriseCode = this._enterpriseCode;                            // 企業コード
                    insertProtyWarehouse.SectionCode = this.tEdit_SectionCode.Text;                        // 拠点コード
                    insertProtyWarehouse.WarehouseCode = warehouseCode;                                    // 倉庫コード
                    if (!string.IsNullOrEmpty(warehProtyOdr))
                    {
                        insertProtyWarehouse.WarehProtyOdr = int.Parse(warehProtyOdr);                         // 優先順位
                    }
                    tempList.Add(insertProtyWarehouse);
                }
            }
 
            if (tempList.Count != 0)
            {
                DateTime maxUpdate = DateTime.MinValue;
                foreach (DateTime updateTime in maxUpdateDic.Values)
                {
                    // 最新更新日時を取得
                    if (updateTime > maxUpdate)
                    {
                        maxUpdate = updateTime;
                    }
                }

                foreach (ProtyWarehouse writeProtyWarehouse in tempList)
                {
                    writeProtyWarehouse.MaxUpdateDateTime = maxUpdate;
                    updateList.Add(writeProtyWarehouse);
                }
            }
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
        /// <param name="NumberFlg">数値入力可？</param>
        /// <returns>true=入力可,false=入力不可</returns>
        /// <remarks>
        /// Note			:	押されたキーが数値のみ有効にする処理を行います。<br />
        /// <br>Programmer : huangt</br>
        /// <br>Date	   : K2013/09/10</br>
        /// </remarks>
        private bool KeyPressNumCheck(int keta, int priod, string prevVal, char key, int selstart, int sellength, Boolean minusFlg, Boolean NumberFlg)
        {
            // 制御キーが押された？
            if (Char.IsControl(key))
            {
                return true;
            }

            // 押されたキーが数値以外、かつ数値以外入力不可
            if (!Char.IsDigit(key) && !NumberFlg)
            {
                return false;
            }

            // キーが押されたと仮定した場合の文字列を生成する。
            string _strResult = "";
            if (sellength > 0)
            {
                _strResult = prevVal.Substring(0, selstart) + prevVal.Substring(selstart + sellength, prevVal.Length - (selstart + sellength));
            }
            else
            {
                _strResult = prevVal;
            }

            // マイナスのチェック
            if (key == '-')
            {
                // マイナス(小数点)が入力可能か？
                if (minusFlg == false)
                {
                    return false;
                }
            }

            // 小数点のチェック
            if (key == '.')
            {
                // 小数点以下桁数が0か？
                if (priod == 0)
                {
                    return false;
                }
                else
                {
                    // 小数点が既に存在するか？
                    if (_strResult.Contains("."))
                    {
                        return false;
                    }
                }
            }
            else
            {
                // 小数点が既に存在するか？
                if (_strResult.Contains("."))
                {
                    int index = _strResult.IndexOf('.');
                    string strDecimal = _strResult.Substring(index + 1);

                    if ((strDecimal.Length >= priod) && (selstart > index))
                    {
                        // 小数桁が入力可能桁数以上で、カーソル位置が小数点以降
                        return false;
                    }
                    else if (((keta - priod) < index))
                    {
                        // 整数部の桁数が入力可能桁数を超えた
                        return false;
                    }
                }
                else
                {
                    // 小数点桁数を前提に整数部の桁数を決定
                    if (((keta - priod) <= _strResult.Length))
                    {
                        return false;
                    }
                }
            }

            // キーが押された結果の文字列を生成する。
            _strResult = prevVal.Substring(0, selstart) + key
                       + prevVal.Substring(selstart + sellength, prevVal.Length - (selstart + sellength));

            // 桁数チェック！
            if (_strResult.Length > keta)
            {
                if (_strResult[0] == '-')
                {
                    if (_strResult.Length > (keta + 1))
                    {
                        return false;
                    }
                }
                else if (_strResult.Contains("."))
                {
                    if (_strResult.Length > (keta + 1))
                    {
                        return false;
                    }
                }
                else if ((_strResult[0] == '-') && (_strResult.Contains(".")))
                {
                    if (_strResult.Length > (keta + 2))
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }

            return true;
        }

        #endregion ■ Private Methods

        #region ■ Control Events
        /// <summary>
        /// Load イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : フォームのLoad時に発生します。</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date	   : K2013/09/10</br>
        /// </remarks>
        private void PMKHN09750UA_Load(object sender, EventArgs e)
        {
            // 画面スキンファイルの読込(デフォルトスキン指定)
            this._controlScreenSkin.LoadSkin();

            // 画面スキン変更
            this._controlScreenSkin.SettingScreenSkin(this);

            // アイコンリソース管理クラスを使用して、アイコンを表示する
            ImageList imageList16 = IconResourceManagement.ImageList16;
            ImageList imageList24 = IconResourceManagement.ImageList24;

            this.Ok_Button.ImageList = imageList24;
            this.Ok_Button.Appearance.Image = Size24_Index.SAVE;
            this.Cancel_Button.ImageList = imageList24;
            this.Cancel_Button.Appearance.Image = Size24_Index.CLOSE;
            this.Delete_Button.ImageList = imageList24;
            this.Delete_Button.Appearance.Image = Size24_Index.DELETE;
            this.Revive_Button.ImageList = imageList24;
            this.Revive_Button.Appearance.Image = Size24_Index.REVIVAL;
            this.Renewal_Button.ImageList = imageList16;
            this.Renewal_Button.Appearance.Image = Size16_Index.RENEWAL;
            this.ultraButton_SectionGuide.ImageList = imageList16;
            this.ultraButton_SectionGuide.Appearance.Image = Size16_Index.STAR1;

            // 画面初期設定
            ScreenInitialSetting();
        }

        /// <summary>
        /// FormClosing イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : フォームを閉じる前に発生します。</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date	   : K2013/09/10</br>
        /// </remarks>
        private void PMKHN09750UA_FormClosing(object sender, FormClosingEventArgs e)
        {
            // GridのIndexBuffer格納用変数初期化
            this._mainIndexBuffer = -2;
            this._detailsIndexBuffer = -2;
            this._targetTableBuffer = "";

            // フォームの「×」をクリックされた場合の対応です。
            if (CanClose == false)
            {
                e.Cancel = true;
                this.Hide();
                return;
            }
        }

        /// <summary>
        /// VisibleChanged イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : フォームの表示状態が変更した時に発生します。</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date	   : K2013/09/10</br>
        /// </remarks>
        private void PMKHN09750UA_VisibleChanged(object sender, EventArgs e)
        {
            // 自分自身が非表示になった場合は以下の処理をキャンセルする。
            if (this.Visible == false)
            {
                this.Owner.Activate();
                return;
            }

            if (this._targetTableName == TABLE_DETAIL)
            {
                if (this._detailsIndexBuffer == this._detailDataIndex)
                {
                    return;
                }
            }
            else
            {
                if (this._mainIndexBuffer == this._mainDataIndex)
                {
                    return;
                }
            }

            // 画面クリア
            ScreenClear();

            this.Initial_Timer.Enabled = true;
        }

        /// <summary>
        /// Button_Click イベント(保存ボタン)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : 保存ボタンがクリックされた時に発生します。</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date	   : K2013/09/10</br>
        /// </remarks>
        private void Ok_Button_Click(object sender, EventArgs e)
        {
            // 保存処理
            SaveProc();
        }

        /// <summary>
        /// 閉じるボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note　　　  : 閉じるボタンコントロールがクリックされた時に発生します。</br>
        /// <br></br>
        /// </remarks>
        private void Cancel_Button_Click(object sender, System.EventArgs e)
        {
            // 更新有無フラグ
            bool isUpdate = false;

            // UI画面のGrid行数を取得
            int maxRow = this._bindTable.Rows.Count;

            //保存確認
            if (this._mainDataIndex >= 0)
            {
                // 更新モード
                if (maxRow > 0)
                {
                    // UI画面のGridに1件以上登録されていること
                    ArrayList updateList = new ArrayList();
                    ArrayList deleteList = new ArrayList();

                    // 更新データの有無を確認
                    UpdateCompare(out updateList, out deleteList);

                    if ((updateList.Count != 0) || (deleteList.Count != 0))
                    {
                        // 更新／削除レコードが有り
                        isUpdate = true;
                    }
                }
            }
            else
            {
                // 新規モード
                ArrayList partsList = new ArrayList();
                // 画面情報を取得
                this.DispToProtyWarehouse(ref partsList);
                if (partsList.Count > 0)
                {
                    // 倉庫の設定有
                    isUpdate = true;
                }
                else
                {
                    if (!string.IsNullOrEmpty(this.tEdit_SectionCode.Text))
                    {
                        isUpdate = true;
                    }
                }
            }

            //最初に取得した画面情報と比較
            if (isUpdate)
            {
                // 画面情報が変更されていた場合は、保存確認メッセージを表示する
                // 保存確認
                DialogResult res = TMsgDisp.Show(
                    this, 								// 親ウィンドウフォーム
                    emErrorLevel.ERR_LEVEL_SAVECONFIRM, // エラーレベル
                    ASSEMBLY_ID,       					// アセンブリＩＤまたはクラスＩＤ
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

            int totalCount = 0;

            // 再検索
            Search(ref totalCount, 0);

            // 画面非表示イベント
            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult);
                UnDisplaying(this, me);
            }

            this.DialogResult = DialogResult.Cancel;

            // GridのIndexBuffer格納用変数初期化
            this._mainIndexBuffer = -2;
            this._detailsIndexBuffer = -2;
            this._targetTableBuffer = "";
            
            // CanCloseプロパティがfalseの場合は、クローズ処理をキャンセルして
            // フォームを非表示化する。
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
        /// Button_Click イベント(削除ボタン)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : 削除ボタンがクリックされた時に発生します。</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date	   : K2013/09/10</br>
        /// </remarks>
        private void Delete_Button_Click(object sender, EventArgs e)
        {
            // 物理削除処理
            bool bStatus = DeleteProc();
            if (!bStatus)
            {
                return;
            }

            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }

            this.DialogResult = DialogResult.Cancel;
            this._detailsIndexBuffer = -2;

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
        /// Button_Click イベント(復活ボタン)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : 復活ボタンがクリックされた時に発生します。</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date	   : K2013/09/10</br>
        /// </remarks>
        private void Revive_Button_Click(object sender, EventArgs e)
        {
            // 復活可能性チェック
            if (!CheckMainIndex())
            {
                return;
            }

            // 復活処理
            bool bStatus = RevivalProc();
            if (!bStatus)
            {
                return;
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
        }

        /// <summary>
        /// 最新情報処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : 最新情報ボタンがクリックされた時に発生します。</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date	   : K2013/09/10</br>
        /// </remarks>
        private void Renewal_Button_Click(object sender, EventArgs e)
        {
            // 最新情報取得
            ReadSecInfoSet();
            ReadWarehouseInfo();

            TMsgDisp.Show(this, 								// 親ウィンドウフォーム
                          emErrorLevel.ERR_LEVEL_INFO,          // エラーレベル
                          ASSEMBLY_ID,						    // アセンブリＩＤまたはクラスＩＤ
                          "最新情報を取得しました。", 			// 表示するメッセージ
                          0, 									// ステータス値
                          MessageBoxButtons.OK);				// 表示するボタン
        }

        /// <summary>
        /// 拠点コードガイド起動ボタン起動イベント                                               
        /// </summary>
        /// <param name="sender">イベントソース</param>                              
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note　　　  : 拠点コードガイドクリック時に発生します</br>                  
        /// <br>Programmer  : huangt</br>                                    
        /// <br>Date        : K2013/09/11</br>                                        
        /// </remarks>
        private void ultraButton_SectionGuide_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                SecInfoSet secInfoSet = null;

                // ガイド起動
                int status = _secInfoSetAcs.ExecuteGuid(this._enterpriseCode, false, out secInfoSet);
                if (status == 0)
                {
                    // 結果セット
                    this.tEdit_SectionCode.Text = secInfoSet.SectionCode.Trim();
                    this.tEdit_SectionName.Text = secInfoSet.SectionGuideNm.Trim();

                    if (ModeChangeProc())
                    {
                        this.tEdit_SectionCode.Focus();
                    }
                    else
                    {
                        // 次フォーカス
                        this.SelectNextControl((Control)sender, true, true, true, true);
                    }
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        /// <summary>
        /// Control.VisibleChange イベント(UI_UltraGrid)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : コントロールの表示状態が変わったときに発生します。</br>
        /// <br>Programmer  : huangt</br>                                    
        /// <br>Date        : K2013/09/11</br>       
        /// </remarks>
        private void uGrid_ProtyWarehouse_VisibleChanged(object sender, System.EventArgs e)
        {
            // アクティブセル・アクティブ行を無効
            this.uGrid_ProtyWarehouse.ActiveCell = null;
        }

        /// <summary>
        /// Control.KeyDown イベント (UI_UltraGrid)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : キーが押されたときに発生します。</br>
        /// <br>Programmer  : huangt</br>                                    
        /// <br>Date        : K2013/09/11</br>       
        /// </remarks>
        private void uGrid_ProtyWarehouse_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {

            // アクティブセルがnullの時は処理を行わず終了
            if (this.uGrid_ProtyWarehouse.ActiveCell == null)
            {
                if (this.uGrid_ProtyWarehouse.ActiveRow != null)
                {
                    this.uGrid_ProtyWarehouse.Rows[this.uGrid_ProtyWarehouse.ActiveRow.Index].Cells[COLUMN_WAREHOUSECODE].Activate();
                    this.uGrid_ProtyWarehouse.PerformAction(UltraGridAction.EnterEditMode);
                }
                return;
            }

            // グリッド状態取得()
            UltraGridState status = this.uGrid_ProtyWarehouse.CurrentState;

            //ドロップダウン状態の時は処理しない(UltraGridのデフォルトの動きにする)
            Control nextControl = null;
            if ((e.Control == false) && (e.Shift == false) && (e.Alt == false) &&
                ((status & UltraGridState.IsDroppedDown) != Infragistics.Win.UltraWinGrid.UltraGridState.IsDroppedDown))
            {

                switch (e.KeyCode)
                {
                    // ↑キー
                    case Keys.Up:
                        {
                            // 上のセルへ移動
                            nextControl = MoveAboveCell();
                            e.Handled = true;
                            break;
                        }
                    // ↓キー
                    case Keys.Down:
                        {
                            // 下のセルへ移動
                            nextControl = MoveBelowCell();
                            e.Handled = true;
                            break;
                        }
                    // ←キー
                    case Keys.Left:
                        {
                            // 上のセルへ移動
                            nextControl = MovePreCell();
                            e.Handled = true;

                            break;
                        }
                    // →キー
                    case Keys.Right:
                        {
                            // 下のセルへ移動
                            nextControl = MoveNextCell();
                            e.Handled = true;

                            break;
                        }
                    case Keys.Space:
                        {
                            if (this.uGrid_ProtyWarehouse.ActiveCell.Column.Style == Infragistics.Win.UltraWinGrid.ColumnStyle.Button)
                            {
                                UltraGridCell ultraGridCell = this.uGrid_ProtyWarehouse.ActiveCell;
                                CellEventArgs cellEventArgs = new CellEventArgs(ultraGridCell);
                                uGrid_ProtyWarehouse_ClickCellButton(sender, cellEventArgs);
                            }
                            break;
                        }
                }

                if (nextControl != null)
                {
                    nextControl.Focus();
                }
            }
        }

        /// <summary>
        ///	ultraGrid.KeyPress イベント(Cell)
        /// </summary>
        /// <remarks>
        /// <br>Note	   : GRIDのキー押下イベント処理。</br>
        /// <br>Programmer  : huangt</br>                                    
        /// <br>Date        : K2013/09/11</br>       
        /// </remarks>
        private void uGrid_ProtyWarehouse_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (this.uGrid_ProtyWarehouse.ActiveCell == null) return;
            UltraGridCell cell = this.uGrid_ProtyWarehouse.ActiveCell;

            // 優先順位の入力桁数チェック
            if (cell.Column.Key == COLUMN_WAREHOUSECODE)
            {
                // 編集モード中？
                if (cell.IsInEditMode)
                {
                    if (!this.KeyPressNumCheck(4, 0, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false, false))
                    {
                        e.Handled = true;
                        return;
                    }
                }
            }
            else if (cell.Column.Key == COLUMN_WAREHPROTYODR)
            {
                // 編集モード中？
                if (cell.IsInEditMode)
                {
                    if (!this.KeyPressNumCheck(2, 0, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false, false))
                    {
                        e.Handled = true;
                        return;
                    }
                }
            }
        }

        /// <summary>
        /// 下のセルへ移動処理
        /// </summary>
        /// <returns>次のコントロール</returns>
        /// <remarks>
        /// <br>Note       : グリッドのアクティブセルを下のセルに移動します。</br>
        /// <br>Programmer  : huangt</br>                                    
        /// <br>Date        : K2013/09/11</br>       
        /// </remarks>
        private Control MoveBelowCell()
        {
            bool performActionResult;

            // アクティブセルがnull
            if (this.uGrid_ProtyWarehouse.ActiveCell == null)
            {
                return null;
            }

            // グリッド状態取得
            UltraGridState status = this.uGrid_ProtyWarehouse.CurrentState;

            // 最下段セルの時
            if ((status & UltraGridState.RowLast) == UltraGridState.RowLast)
            {
                // 保存ボタンへ移動
                return this.Renewal_Button;
            }
            // 最下段セルでない時
            else
            {
                // セル移動前アクティブセルのインデックス
                int prevCol = this.uGrid_ProtyWarehouse.ActiveCell.Column.Index;
                int prevRow = this.uGrid_ProtyWarehouse.ActiveCell.Row.Index;

                // 下のセルに移動
                performActionResult = this.uGrid_ProtyWarehouse.PerformAction(UltraGridAction.BelowCell);

                // セルが移動していない時
                if ((prevCol == this.uGrid_ProtyWarehouse.ActiveCell.Column.Index) &&
                    (prevRow == this.uGrid_ProtyWarehouse.ActiveCell.Row.Index))
                {
                    // 保存ボタンへ移動
                    return this.Renewal_Button;
                }
                // セルが移動してる
                else
                {
                    if (performActionResult)
                    {
                        if ((this.uGrid_ProtyWarehouse.ActiveCell.Activation == Activation.AllowEdit) &&
                            (this.uGrid_ProtyWarehouse.ActiveCell.Column.CellActivation == Activation.AllowEdit))
                        {
                            this.uGrid_ProtyWarehouse.PerformAction(UltraGridAction.EnterEditMode);
                        }
                    }
                    return null;
                }
            }
        }

        /// <summary>
        /// 上のセルへ移動処理
        /// </summary>
        /// <returns>次のコントロール</returns>
        /// <remarks>
        /// <br>Note       : グリッドのアクティブセルを上のセルに移動します。</br>
        /// <br>Programmer  : huangt</br>
        /// <br>Date        : K2013/09/11</br>
        /// </remarks>
        private Control MoveAboveCell()
        {
            bool performActionResult;

            // アクティブセルがnull
            if (this.uGrid_ProtyWarehouse.ActiveCell == null)
            {
                return null;
            }

            // グリッド状態取得
            UltraGridState status = this.uGrid_ProtyWarehouse.CurrentState;

            // 最上段セルの時
            if ((status & UltraGridState.RowFirst) == UltraGridState.RowFirst)
            {
                return this.DeleteRow_Button;
            }
            // 最前セルでない時
            else
            {
                // 上のセルに移動
                performActionResult = this.uGrid_ProtyWarehouse.PerformAction(UltraGridAction.AboveCell);
                if (performActionResult)
                {
                    if ((this.uGrid_ProtyWarehouse.ActiveCell.Activation == Activation.AllowEdit) &&
                        (this.uGrid_ProtyWarehouse.ActiveCell.Column.CellActivation == Activation.AllowEdit))
                    {
                        this.uGrid_ProtyWarehouse.PerformAction(UltraGridAction.EnterEditMode);
                    }
                }
                return null;

            }
        }

        /// <summary>
        /// 左のセルへ移動処理
        /// </summary>
        /// <returns>次のコントロール</returns>
        /// <remarks>
        /// <br>Note       : グリッドのアクティブセルをのセルに移動します。</br>
        /// <br>Programmer  : huangt</br>
        /// <br>Date        : K2013/09/11</br>
        /// </remarks>
        private Control MovePreCell()
        {
            bool performActionResult;

            // アクティブセルがnull
            if (this.uGrid_ProtyWarehouse.ActiveCell == null)
            {
                return null;
            }

            // グリッド状態取得
            UltraGridState status = this.uGrid_ProtyWarehouse.CurrentState;

            // 最上段セルの時
            if (((status & UltraGridState.RowFirst) == UltraGridState.RowFirst) && ((status & UltraGridState.CellFirst) == UltraGridState.CellFirst))
            {
                return this.Delete_Button;
            }
            // 最前セルでない時
            else
            {
                // 上のセルに移動
                performActionResult = this.uGrid_ProtyWarehouse.PerformAction(UltraGridAction.PrevCell);
                if (performActionResult)
                {
                    if ((this.uGrid_ProtyWarehouse.ActiveCell.Activation == Activation.AllowEdit) &&
                        (this.uGrid_ProtyWarehouse.ActiveCell.Column.CellActivation == Activation.AllowEdit))
                    {
                        this.uGrid_ProtyWarehouse.PerformAction(UltraGridAction.EnterEditMode);
                    }
                }
                return null;

            }
        }

        /// <summary>
        /// 右のセルへ移動処理
        /// </summary>
        /// <returns>次のコントロール</returns>
        /// <remarks>
        /// <br>Note       : グリッドのアクティブセルを右のセルに移動します。</br>
        /// <br>Programmer  : huangt</br>
        /// <br>Date        : K2013/09/11</br>
        /// </remarks>
        private Control MoveNextCell()
        {
            bool performActionResult;

            // アクティブセルがnull
            if (this.uGrid_ProtyWarehouse.ActiveCell == null)
            {
                return null;
            }

            // グリッド状態取得
            UltraGridState status = this.uGrid_ProtyWarehouse.CurrentState;

            // 最下段セルの時
            if (((status & UltraGridState.RowLast) == UltraGridState.RowLast) && ((status & UltraGridState.CellLast) == UltraGridState.CellLast))
            {
                // 保存ボタンへ移動
                return this.Renewal_Button;
            }
            // 最下段セルでない時
            else
            {
                // セル移動前アクティブセルのインデックス
                int prevCol = this.uGrid_ProtyWarehouse.ActiveCell.Column.Index;
                int prevRow = this.uGrid_ProtyWarehouse.ActiveCell.Row.Index;

                // 右のセルに移動
                performActionResult = this.uGrid_ProtyWarehouse.PerformAction(UltraGridAction.NextCell);

                // セルが移動していない時
                if ((prevCol == this.uGrid_ProtyWarehouse.ActiveCell.Column.Index) &&
                    (prevRow == this.uGrid_ProtyWarehouse.ActiveCell.Row.Index))
                {
                    // 保存ボタンへ移動
                    return this.Renewal_Button;
                }
                // セルが移動してる
                else
                {
                    if (performActionResult)
                    {
                        if ((this.uGrid_ProtyWarehouse.ActiveCell.Activation == Activation.AllowEdit) &&
                            (this.uGrid_ProtyWarehouse.ActiveCell.Column.CellActivation == Activation.AllowEdit))
                        {
                            this.uGrid_ProtyWarehouse.PerformAction(UltraGridAction.EnterEditMode);
                        }
                    }
                    return null;
                }
            }
        }

        /// <summary>
        /// 次入力可能セル移動処理
        /// </summary>
        /// <param name="activeCellCheck">true:ActiveCellが入力可能の場合はNextに移動させない false:ActiveCellに関係なくNextに移動させる</param>
        /// <returns>true:セル移動完了 false:セル移動失敗</returns>
        /// <remarks>
        /// Note			:	次の入力可能なセルにフォーカスを移動する処理を行います。<br />
        /// <br>Programmer  : huangt</br>
        /// <br>Date        : K2013/09/11</br>
        /// </remarks>
        private bool MoveNextAllowEditCell(bool activeCellCheck)
        {
            bool moved = false;
            bool performActionResult = false;

            if ((activeCellCheck) && (this.uGrid_ProtyWarehouse.ActiveCell != null))
            {
                if ((this.uGrid_ProtyWarehouse.ActiveCell.Activation == Activation.AllowEdit) &&
                    (this.uGrid_ProtyWarehouse.ActiveCell.Column.CellActivation == Activation.AllowEdit))
                {
                    moved = true;
                }
            }
            else
            {
                while (!moved)
                {
                    performActionResult = this.uGrid_ProtyWarehouse.PerformAction(UltraGridAction.NextCell);

                    if (performActionResult)
                    {
                        if ((this.uGrid_ProtyWarehouse.ActiveCell.Activation == Activation.AllowEdit) &&
                            (this.uGrid_ProtyWarehouse.ActiveCell.Column.CellActivation == Activation.AllowEdit))
                        {
                            moved = true;
                        }
                        else if (this.uGrid_ProtyWarehouse.ActiveCell.Column.Style == Infragistics.Win.UltraWinGrid.ColumnStyle.Button)
                        {
                            // アクティブセルがボタン
                            moved = false;
                        }
                        else
                        {
                            moved = false;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }

            if (moved)
            {
                this.uGrid_ProtyWarehouse.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
            }

            return performActionResult;
        }

        /// <summary>
        /// 前入力可能セル移動処理
        /// </summary>
        /// <param name="activeCellCheck">true:ActiveCellが入力可能の場合はPrevに移動させない false:ActiveCellに関係なくPrevに移動させる</param>
        /// <returns>true:セル移動完了 false:セル移動失敗</returns>
        /// <remarks>
        /// Note			:	前の入力可能なセルにフォーカスを移動する処理を行います。<br />
        /// <br>Programmer  : huangt</br>
        /// <br>Date        : K2013/09/11</br>
        /// </remarks>
        private bool MovePrevAllowEditCell(bool activeCellCheck)
        {
            bool moved = false;
            bool performActionResult = false;

            if ((activeCellCheck) && (this.uGrid_ProtyWarehouse.ActiveCell != null))
            {
                if ((this.uGrid_ProtyWarehouse.ActiveCell.Activation == Activation.AllowEdit) &&
                    (this.uGrid_ProtyWarehouse.ActiveCell.Column.CellActivation == Activation.AllowEdit))
                {
                    moved = true;
                }
            }
            else
            {
                while (!moved)
                {
                    performActionResult = this.uGrid_ProtyWarehouse.PerformAction(UltraGridAction.PrevCell);

                    if (performActionResult)
                    {
                        if ((this.uGrid_ProtyWarehouse.ActiveCell.Activation == Activation.AllowEdit) &&
                            (this.uGrid_ProtyWarehouse.ActiveCell.Column.CellActivation == Activation.AllowEdit))
                        {
                            moved = true;
                        }
                        else if (this.uGrid_ProtyWarehouse.ActiveCell.Column.Style == Infragistics.Win.UltraWinGrid.ColumnStyle.Button)
                        {
                            // アクティブセルがボタン
                            moved = false;
                        }
                        else
                        {
                            moved = false;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }

            if (moved)
            {
                this.uGrid_ProtyWarehouse.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
            }

            return performActionResult;
        }

        /// <summary>
        ///	ultraGrid.Click イベント(Cell Button)
        /// </summary>
        /// <remarks>
        /// <br>Note	   : GRIDのCell Buttonをクリックイベント処理。</br>
        /// <br>Programmer  : huangt</br>
        /// <br>Date        : K2013/09/11</br>
        /// </remarks>
        private void uGrid_ProtyWarehouse_ClickCellButton(object sender, CellEventArgs e)
        {
            int status = 0;

            Warehouse warehouseData = null;

            // 倉庫ガイド起動
            status = this._warehouseGuideAcs.ExecuteGuid(out warehouseData, this._enterpriseCode);

            if (status == 0)
            {
                bool AddFlg = true;     // 追加フラグ
                int maxRow = this._bindTable.Rows.Count;

                // 倉庫コードの重複チェック
                for (int i = 0; i < maxRow; i++)
                {
                    string warehouseCode = (string)this._bindTable.Rows[i][COLUMN_WAREHOUSECODE];
                    if (warehouseCode == "")
                    {
                        continue;
                    }
                    if (warehouseCode.Equals(warehouseData.WarehouseCode.Trim()))
                    {
                        // 重複コード有
                        AddFlg = false;
                        break;
                    }
                }

                if (AddFlg)
                {
                    // 選択した情報をCellに設定
                    e.Cell.Row.Cells[COLUMN_WAREHOUSECODE].Value = warehouseData.WarehouseCode.Trim();                    // 倉庫コード
                    e.Cell.Row.Cells[COLUMN_WAREHOUSENAME].Value = warehouseData.WarehouseName.Trim();                    // 倉庫名

                    if ((int)e.Cell.Row.Cells[COLUMN_SCREENID].Value == this._bindTable.Rows.Count)
                    {
                        // 最終行の場合、行を追加
                        this.AddBindTableRow();
                    }

                    // 次のコントロールへフォーカスを移動
                    this.MoveNextAllowEditCell(false);
                }
                else
                {
                    // 重複エラーを表示
                    TMsgDisp.Show(
                        this,								    // 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,	    // エラーレベル
                        ASSEMBLY_ID,      						    // アセンブリＩＤまたはクラスＩＤ
                        "選択した倉庫コードが重複しています。",	// 表示するメッセージ 
                        0,									    // ステータス値
                        MessageBoxButtons.OK);				    // 表示するボタン

                    ((Control)sender).Focus();
                }
            }
            else
            {
                ((Control)sender).Focus();
            }
        }

        /// <summary>
        /// AfterExitEditMode イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : 編集モードが終了した時に発生します。</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date	   : K2013/09/10</br>
        /// </remarks>
        private void uGrid_ProtyWarehouse_AfterExitEditMode(object sender, EventArgs e)
        {
            if (this.uGrid_ProtyWarehouse.ActiveCell == null) return;

            UltraGridCell cell = this.uGrid_ProtyWarehouse.ActiveCell;

            switch (cell.Column.Key)
            {
                // 倉庫コード
                case COLUMN_WAREHOUSECODE:
                    {
                        string warehouseCode = cell.Value != null ? cell.Value.ToString() : string.Empty;
                        this._gridUpdFlg = true;

                        if (warehouseCode != "")
                        {
                            // 入力有
                            string warehouseName = GetWarehouseName(warehouseCode);

                            if (warehouseName != "")
                            {
                                bool AddFlg = true;     // 追加フラグ
                                int maxRow = this._bindTable.Rows.Count;

                                // 倉庫コードの重複チェック
                                for (int i = 0; i < maxRow; i++)
                                {
                                    if (cell.Row.Index == i)
                                    {
                                        // 同じ行数はSKIP
                                        continue;
                                    }

                                    string wkWarehouseCode = this._bindTable.Rows[i][COLUMN_WAREHOUSECODE].ToString();
                                    if ((!string.IsNullOrEmpty(wkWarehouseCode)) && (wkWarehouseCode.Trim().Equals(warehouseCode.Trim().PadLeft(4, '0'))))
                                    {
                                        // 重複コード有
                                        AddFlg = false;
                                        break;
                                    }
                                }

                                if (AddFlg)
                                {
                                    // 倉庫コードの追加
                                    // 選択した情報をCellに設定
                                    cell.Row.Cells[COLUMN_WAREHOUSECODE].Value = warehouseCode.PadLeft(4, '0');     // 倉庫コード
                                    cell.Row.Cells[COLUMN_WAREHOUSENAME].Value = warehouseName;                     // 倉庫名

                                    if ((int)cell.Row.Cells[COLUMN_SCREENID].Value == this._bindTable.Rows.Count)
                                    {
                                        // 最終行の場合、行を追加
                                        this.AddBindTableRow();
                                    }
                                }
                                else
                                {
                                    // 重複エラーを表示
                                    TMsgDisp.Show(
                                        this,								    // 親ウィンドウフォーム
                                        emErrorLevel.ERR_LEVEL_EXCLAMATION,	    // エラーレベル
                                        ASSEMBLY_ID,      						// アセンブリＩＤまたはクラスＩＤ
                                        "入力した倉庫コードが重複しています。",	// 表示するメッセージ 
                                        0,									    // ステータス値
                                        MessageBoxButtons.OK);				    // 表示するボタン

                                    // 倉庫コード、倉庫名をクリア
                                    cell.Row.Cells[COLUMN_WAREHOUSECODE].Value = "";     // 倉庫コード
                                    cell.Row.Cells[COLUMN_WAREHOUSENAME].Value = "";     // 倉庫名

                                    // Grid変更なし
                                    this._gridUpdFlg = false;
                                }
                            }
                            else
                            {
                                // 論理削除データは設定不可
                                TMsgDisp.Show(
                                    this,
                                    emErrorLevel.ERR_LEVEL_INFO,
                                    this.Name,
                                    "倉庫コードが登録されていません。",
                                    -1,
                                    MessageBoxButtons.OK);

                                // 倉庫コード、倉庫名をクリア
                                cell.Row.Cells[COLUMN_WAREHOUSECODE].Value = "";     // 倉庫コード
                                cell.Row.Cells[COLUMN_WAREHOUSENAME].Value = "";     // 倉庫名

                                // Grid変更なし
                                this._gridUpdFlg = false;
                            }
                        }
                        else
                        {
                            // 未入力
                            // 倉庫コード、倉庫名をクリア
                            cell.Row.Cells[COLUMN_WAREHOUSECODE].Value = "";     // 倉庫コード
                            cell.Row.Cells[COLUMN_WAREHOUSENAME].Value = "";     // 倉庫名
                        }
                    }
                    break;
                case COLUMN_WAREHPROTYODR:
                    {
                        string priorityOrder = cell.Value != null ? cell.Value.ToString() : string.Empty;
                        this._gridUpdFlg = true;

                        Regex r = new Regex(@"^[0-9]*$");
                        // 拠点
                        if (!String.IsNullOrEmpty(priorityOrder) && !r.IsMatch(priorityOrder))
                        {
                            cell.Row.Cells[COLUMN_WAREHPROTYODR].Value = "";    // 優先順位
                            return;
                        }

                        if ((!string.IsNullOrEmpty(priorityOrder)) && (int.Parse(priorityOrder) != 0))
                        {
                            int warehProtyOdr = int.Parse(priorityOrder);
                            int maxRow = this._bindTable.Rows.Count;   // GRIDの行数

                            for (int i = 0; i < maxRow; i++)
                            {
                                if (cell.Row.Index == i)
                                {
                                    // 同じ行数はSKIP
                                    continue;
                                }

                                string wkPriorityOrder = (string)this._bindTable.Rows[i][COLUMN_WAREHPROTYODR];
                                if ((!string.IsNullOrEmpty(wkPriorityOrder)) && (int.Parse(wkPriorityOrder) == warehProtyOdr))
                                {
                                    // 重複順位有

                                    // 重複エラーを表示
                                    TMsgDisp.Show(
                                        this,								    // 親ウィンドウフォーム
                                        emErrorLevel.ERR_LEVEL_EXCLAMATION,	    // エラーレベル
                                        ASSEMBLY_ID,      						// アセンブリＩＤまたはクラスＩＤ
                                        "入力した倉庫優先順が重複しています。",	// 表示するメッセージ 
                                        0,									    // ステータス値
                                        MessageBoxButtons.OK);				    // 表示するボタン

                                    // 優先順位をクリア
                                    cell.Row.Cells[COLUMN_WAREHPROTYODR].Value = "";    // 優先順位

                                    // Grid変更なし
                                    this._gridUpdFlg = false;
                                    break;
                                }
                                else if (string.IsNullOrEmpty(priorityOrder))
                                {
                                    cell.Row.Cells[COLUMN_WAREHPROTYODR].Value = "";    // 優先順位
                                }
                                cell.Row.Cells[COLUMN_WAREHPROTYODR].Value = warehProtyOdr.ToString();
                            }
                        }
                        else
                        {
                            // 未入力
                            cell.Row.Cells[COLUMN_WAREHPROTYODR].Value = "";    // 優先順位
                        }
                    }
                    break;
            }
        }

        /// <summary>
        /// Control.Click イベント(DeleteRow_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note 　　  : 削除ボタンコントロールがクリックされたときに発生します。</br>
        /// <br></br>
        /// </remarks>
        private void DeleteRow_Button_Click(object sender, EventArgs e)
        {
            string message = "";

            if (this.uGrid_ProtyWarehouse.Rows.Count < 1)
            {
                // デバッグ用
                this.AddBindTableRow();
            }

            if (this.uGrid_ProtyWarehouse.ActiveRow == null)
            {
                // 削除する行が未選択
                message = "削除する倉庫コードを選択して下さい。";

                TMsgDisp.Show(
                    this,								// 親ウィンドウフォーム
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,	// エラーレベル
                    ASSEMBLY_ID,      					// アセンブリＩＤまたはクラスＩＤ
                    message,							// 表示するメッセージ 
                    0,									// ステータス値
                    MessageBoxButtons.OK);				// 表示するボタン

                this.uGrid_ProtyWarehouse.Focus();
            }
            //else if (this.uGrid_ProtyWarehouse.Rows.Count == 1)  // DEL huangt K2013/10/08 No.83 行削除チェックの改修
            else if (!CheckDeleteRow())    // ADD huangt K2013/10/08 No.83 行削除チェックの改修
            {
                // Gridの行数が1行の場合は削除不可
                message = "全ての倉庫を削除はできません";

                TMsgDisp.Show(
                    this,								// 親ウィンドウフォーム
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,	// エラーレベル
                    ASSEMBLY_ID,      						// アセンブリＩＤまたはクラスＩＤ
                    message,							// 表示するメッセージ 
                    0,									// ステータス値
                    MessageBoxButtons.OK);				// 表示するボタン

                this.uGrid_ProtyWarehouse.Focus();
            }
            else
            {
                // UI画面のGridから選択行を削除
                // 選択行のindexを取得
                int delIndex = (int)this.uGrid_ProtyWarehouse.ActiveRow.Cells[COLUMN_SCREENID].Value - 1;

                // 選択行の削除
                this.uGrid_ProtyWarehouse.ActiveRow.Delete();

                // 削除後のGrid行数を取得
                int maxRow = this._bindTable.Rows.Count;

                for (int index = delIndex; index < maxRow; index++)
                {
                    // 削除した行以降の表示順位を更新する
                    this._bindTable.Rows[index][COLUMN_SCREENID] = index + 1;
                }
            }
        }

        // --- ADD huangt K2013/10/08 No.83 行削除チェックの改修 ----- >>>>>
        /// <summary>
        /// Gridの行削除チェック
        /// </summary>
        /// <remarks>
        /// <br>Note : Gridの行削除チェックを行う。</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date	   : K2013/10/08</br>
        /// </remarks>
        private bool CheckDeleteRow()
        {
            bool checkFlg = true;
            // UI画面のGrid行数
            int uiGridRowCnt = this._bindTable.Rows.Count;
            // 有効行数
            int validRowCnt = 0;
            int activeRowIndex = this.uGrid_ProtyWarehouse.ActiveRow.Index;
            // Active行の倉庫コード
            string activeRowWarehouseCode = (string)this._bindTable.Rows[activeRowIndex][COLUMN_WAREHOUSECODE];
            // Active行の倉庫優先順位
            string activeRowWarehProtyOdr = (string)this._bindTable.Rows[activeRowIndex][COLUMN_WAREHPROTYODR];

            for (int index = 0; index < uiGridRowCnt; index++)
            {
                if (index == activeRowIndex) continue;

                // UI画面のGridから情報を取得
                string warehouseCode = (string)this._bindTable.Rows[index][COLUMN_WAREHOUSECODE];
                string warehProtyOdr = (string)this._bindTable.Rows[index][COLUMN_WAREHPROTYODR];

                // 未入力の行はSKIP
                if (string.IsNullOrEmpty(warehouseCode) && string.IsNullOrEmpty(warehProtyOdr))
                {
                    continue;
                }
                else
                {
                    validRowCnt++;
                }
            }

            // 有効行数が0行の場合は削除不可
            if (validRowCnt == 0 && this.uGrid_ProtyWarehouse.Rows.Count > 0)
            {
                checkFlg = false;
                if (string.IsNullOrEmpty(activeRowWarehouseCode) && string.IsNullOrEmpty(activeRowWarehProtyOdr) && (this.uGrid_ProtyWarehouse.Rows.Count) > 1)
                {
                    checkFlg = true;
                }
            }

            return checkFlg;
        }
        // --- ADD huangt K2013/10/08 No.83 行削除チェックの改修 ----- <<<<<

        /// <summary>
        /// Timer_Tick イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : 指定された間隔の時間が経過した時に発生します。</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date	   : K2013/09/10</br>
        /// </remarks>
        private void Initial_Timer_Tick(object sender, EventArgs e)
        {
            this.Initial_Timer.Enabled = false;

            // 画面再構築処理
            ScreenReconstruction();

            // モード変更可能フラグを設定
            CanChangeMode = IsInsertMode();
        }

        /// <summary>モード変更可能フラグを取得または設定します。</summary>
        private bool CanChangeMode
        {
            get { return _canChangeMode; }
            set { _canChangeMode = value; }
        }

        /// <summary>
        /// ChangeFocus イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : アクティブコントロールが変わった時に発生します。</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date	   : K2013/09/10</br>
        /// </remarks>
        private void tRetKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null) return;

            switch (e.PrevCtrl.Name)
            {
                case "tEdit_SectionCode":         // 拠点コード
                    {
                        string wkSectionCode = this.tEdit_SectionCode.Text.Trim();
                        string sectionName = "";

                        if (!string.IsNullOrEmpty(wkSectionCode))
                        {
                            string sectionCode = wkSectionCode.PadLeft(2, '0');
                            // 拠点名称の取得
                            sectionName = GetSectionName(sectionCode);

                            if (!string.IsNullOrEmpty(sectionName))
                            {
                                this.tEdit_SectionName.Text = sectionName;

                                if (e.ShiftKey == false)
                                {
                                    if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter) || (e.Key == Keys.Down))
                                    {
                                        // カーソル制御
                                        // GRIDの優先順位へフォーカス制御
                                        this.uGrid_ProtyWarehouse.Rows[0].Cells[COLUMN_WAREHPROTYODR].Activate();
                                        this.uGrid_ProtyWarehouse.PerformAction(UltraGridAction.EnterEditMode);
                                        e.NextCtrl = null;
                                    }
                                }
                            }
                            else
                            {
                                TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "拠点コードが登録されていません。",
                                -1,
                                MessageBoxButtons.OK);

                                // 拠点のクリア
                                this.tEdit_SectionCode.Text = "";
                                this.tEdit_SectionName.Text = "";

                                // カーソル制御
                                e.NextCtrl = e.PrevCtrl;
                            }
                        }
                        else
                        {
                            // 未入力
                            // 拠点のクリア
                            this.tEdit_SectionCode.Text = "";
                            this.tEdit_SectionName.Text = "";
                        }

                        break;
                    }
                case "DeleteRow_Button":            // GRID削除ボタン
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Return:
                                case Keys.Tab:
                                    {
                                        // GRIDの優先順位へフォーカス制御
                                        this.uGrid_ProtyWarehouse.Rows[0].Cells[COLUMN_WAREHPROTYODR].Activate();
                                        this.uGrid_ProtyWarehouse.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                                        e.NextCtrl = null;
                                        break;
                                    }
                            }
                        }
                        break;
                    }
                case "uGrid_ProtyWarehouse":      // グリッド
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Return:
                                case Keys.Tab:
                                    {
                                        // ガイドボタンにフォーカスがある
                                        if (this.uGrid_ProtyWarehouse.ActiveCell != null)
                                        {
                                            UltraGridState status = this.uGrid_ProtyWarehouse.CurrentState;

                                            if ((this.uGrid_ProtyWarehouse.ActiveCell.Column.Style == Infragistics.Win.UltraWinGrid.ColumnStyle.Button) &&
                                                (status & Infragistics.Win.UltraWinGrid.UltraGridState.RowLast) == Infragistics.Win.UltraWinGrid.UltraGridState.RowLast)
                                            {
                                                // セルのスタイルがボタンで、セルの最終行の場合
                                                if (((int)this.uGrid_ProtyWarehouse.ActiveCell.Row.Cells[COLUMN_SCREENID].Value == this._bindTable.Rows.Count)
                                                    && (!string.IsNullOrEmpty((string)this.uGrid_ProtyWarehouse.ActiveCell.Row.Cells[COLUMN_WAREHOUSECODE].Value)))
                                                {
                                                    // 最終行の場合、行を追加
                                                    this.AddBindTableRow();
                                                }
                                            }
                                        }

                                        // 次のセルへ移動
                                        bool moveFlg = this.MoveNextAllowEditCell(false);
                                        if (moveFlg)
                                        {
                                            e.NextCtrl = null;
                                        }
                                        if (!this._gridUpdFlg)
                                        {
                                            this.MovePrevAllowEditCell(false);
                                            e.NextCtrl = null;
                                        }
                                        break;
                                    }
                            }
                        }
                        else
                        {
                            switch (e.Key)
                            {
                                case Keys.Return:
                                case Keys.Tab:
                                    {
                                        if (this.MovePrevAllowEditCell(false))
                                        {
                                            // グリッド内のフォーカス制御
                                            e.NextCtrl = null;
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.DeleteRow_Button;
                                        }

                                        break;
                                    }
                            }
                        }
                        break;
                    }
                case "Renewal_Button":
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Up:
                                    {
                                        // GRIDの優先順位へフォーカス制御
                                        int rowIdx = this.uGrid_ProtyWarehouse.Rows.Count - 1;
                                        // アクティブ行を最終行に設定
                                        this.uGrid_ProtyWarehouse.ActiveRow = this.uGrid_ProtyWarehouse.Rows[rowIdx];
                                        // アクティブセルを優先順位に設定(フォーカス遷移のため)
                                        this.uGrid_ProtyWarehouse.ActiveCell = this.uGrid_ProtyWarehouse.Rows[rowIdx].Cells[COLUMN_WAREHPROTYODR];
                                        // 優先順位を編集モードにしてフォーカスを移動
                                        this.uGrid_ProtyWarehouse.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                                        if (this._bindTable.Rows[rowIdx][COLUMN_WAREHPROTYODR].ToString() == "")
                                        {
                                            // ガイドボタンへフォーカス移動
                                            this.uGrid_ProtyWarehouse.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCell);
                                        }
                                        e.NextCtrl = null;
                                        break;
                                    }
                            }
                        }
                        else
                        {
                            switch (e.Key)
                            {
                                case Keys.Return:
                                case Keys.Tab:
                                    {
                                        // GRIDの優先順位へフォーカス制御
                                        int rowIdx = this.uGrid_ProtyWarehouse.Rows.Count - 1;
                                        // アクティブ行を最終行に設定
                                        this.uGrid_ProtyWarehouse.ActiveRow = this.uGrid_ProtyWarehouse.Rows[rowIdx];
                                        // アクティブセルを優先順位に設定(フォーカス遷移のため)
                                        this.uGrid_ProtyWarehouse.ActiveCell = this.uGrid_ProtyWarehouse.Rows[rowIdx].Cells[COLUMN_WAREHOUSECODE];
                                        // 優先順位を編集モードにしてフォーカスを移動
                                        this.uGrid_ProtyWarehouse.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                                        if (this._bindTable.Rows[rowIdx][COLUMN_WAREHPROTYODR].ToString() == "")
                                        {
                                            // ガイドボタンへフォーカス移動
                                            this.uGrid_ProtyWarehouse.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCell);
                                        }
                                        e.NextCtrl = null;
                                        break;
                                    }
                            }
                        }
                        break;
                    }
            }

            if (e.NextCtrl != null)
            {
                switch (e.NextCtrl.Name)
                {
                    case "uGrid_ProtyWarehouse":      // グリッド
                        {
                            if ((this._mainDataIndex < 0) || (this._detailDataIndex < 0))
                            {
                                if (ModeChangeProc())
                                {
                                    e.NextCtrl = this.tEdit_SectionCode;
                                }
                            }
                            break;
                        }
                }
            }

            string currentCampaignCode = this.tEdit_SectionCode.Text.Trim();

            if (CanChangeMode)
            {
                // 新規モードの場合のみ
                if ((this._mainDataIndex < 0) || (this._detailDataIndex < 0))
                {
                    if (ModeChangeProc())
                    {
                        e.NextCtrl = this.tEdit_SectionCode;
                    }
                }
            }
        }
        #endregion ■ Control Events
    }
}