using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 得意先マスタ(掛率グループ)UIクラス
    /// </summary>
    /// <remarks>
    /// <br>Note		: 得意先マスタ(掛率グループ)のUI設定を行います。</br>
    /// <br>Programmer	: 30414 忍　幸史</br>
    /// <br>Date		: 2008/10/03</br>
    /// <br>UpdateNote  : 2009/01/09 30414 忍 幸史 障害ID:9806対応</br>
    /// <br>UpdateNote  : 2009/03/10 30413 犬飼    障害ID:11417対応</br>
    /// <br>            :  変更点多数のため、詳細内容は省略します</br>
    /// <br>UpdateNote  : 2009/11/19 30434 工藤    3次分対応 得意先掛率グループ改良</br>
    /// <br>UpdateNote  : 2009/12/15 30434 工藤    3次分対応 得意先掛率グループ改良(追加):得意先掛率グループコード=-1をDB登録する</br>
    /// <br>UpdateNote  : 2010/07/15 22018 鈴木 正臣</br>
    /// <br>            :   成果物統合２</br>
    /// <br>            :     ①得意先掛率グループコード=-1をDB登録する条件を変更。</br>
    /// <br>            :     　　・純正ALLを設定する場合 ⇒ 純正ALL以外でCD=-1は登録しない。</br>
    /// <br>            :     　　・ﾒｰｶｰ別に設定する場合 ⇒ 純正ALLでCD=-1は登録しない。</br>
    /// <br>            :     　　　（※優良は優良ALLのみなので、変更なし）</br>
    /// <br>            :     ②純正ALLで設定された状態でＵＩ表示したとき、グリッドの入力可否状態が更新されない件の修正。</br>
    /// </remarks>
    public partial class PMKHN09170UA : Form, IMasterMaintenanceArrayType
    {
        #region ■ Constants

        // プログラムID
        private const string ASSEMBLY_ID = "PMKHN09170U";

        // テーブル名称
        private const string TABLE_MAIN = "MainTable";
        private const string TABLE_DETAIL = "DetailTable";

        // データビュータイトル
        private const string GRIDTITLE_CUSTOMER = "得意先";
        private const string GRIDTITLE_CUSTRATEGROUP = "得意先掛率ｸﾞﾙｰﾌﾟ";

        // データビュー表示用
        private const string VIEW_CUSTOMERCODE = "得意先";
        private const string VIEW_CUSTOMERNAME = "得意先名";
        private const string VIEW_DELETEDATE = "削除日";
        private const string VIEW_MAKERNAME = "メーカー";
        private const string VIEW_CUSTRATEGROUP = "得意先掛率ｸﾞﾙｰﾌﾟ";

        // グリッド列タイトル
        private const string COLUMN_MAKERCODE = "MakerCode";
        private const string COLUMN_MAKERNAME = "MakerName";
        private const string COLUMN_CUSTRATEGROUP = "CustRateGroup";
        private const string COLUMN_MAKERTITLE = "MakerTitle";
        private const string COLUMN_CUSTRATEGROUPTITLE = "CustRateGroupTitle";
        private const string COLUMN_CUSTRATEGROUPNAME = "CustRateGroupName";
        private const string COLUMN_CUSTRATEGROUPNAMETITLE = "CustRateGroupNameTitle";
        private const string COLUMN_CUSTRATEGROUPBUTTON = "CustRateGroupButton";
        private const string COLUMN_CUSTRATEGROUPBUTTONTITLE = "CustRateGroupButtonTitle";

        // 編集モード
        private const string INSERT_MODE = "新規モード";
        private const string UPDATE_MODE = "更新モード";
        private const string DELETE_MODE = "削除モード";

        // 各グリッド行数
        private const int ROWCOUNT = 18;

        #endregion ■ Constants


        #region ■ Private Members

        private bool _canClose;
        private bool _canDelete;
        private bool _canNew;
        private bool _canPrint;

        private MGridDisplayLayout _defaultGridDisplayLayout;

        private string _targetTableName;
        private int _mainDataIndex;
        private int _detailDataIndex;

        private string _enterpriseCode;

        private CustRateGroupAcs _custRateGroupAcs;
        private MakerAcs _makerAcs;
        private CustomerSearchAcs _customerSearchAcs;

        // --- ADD 2009/01/09 障害ID:9806対応------------------------------------------------------>>>>>
        private UserGuideAcs _userGuideAcs;
        private Dictionary<int, string> _custRateGrpDic;
        private bool _errFlg;
        private bool _cellUpdateFlg;
        // --- ADD 2009/01/09 障害ID:9806対応------------------------------------------------------<<<<<

        private Dictionary<int, MakerUMnt> _makerUMntDic;

        private ControlScreenSkin _controlScreenSkin;           // 画面デザイン変更クラス
        private List<CustRateGroup> _custRateGroupListClone;    // 得意先マスタ(掛率グループ)リストClone
        private Dictionary<int, CustRateGroup> _mainList;
        private List<CustRateGroup> _detailList;
        private UltraGrid[] _custRateGroup_Grid;                // グリッド用配列
        private Dictionary<int, CustomerSearchRet> _customerSearchRetDic;

        private bool _cusotmerGuideSelected;                    // 得意先ガイド選択フラグ

        // 2009.03.30 30413 犬飼 新規モードからモード変更対応 >>>>>>START
        // モードフラグ(true：コード、false：コード以外)
        private bool _modeFlg = false;
        // 2009.03.30 30413 犬飼 新規モードからモード変更対応 <<<<<<END

        #endregion ■ Private Members


        #region ■ Constructor
        /// <summary>
        /// 得意先マスタ(掛率グループ)クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 得意先マスタ(掛率グループ)UIクラスの新しいインスタンスを生成します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date	   : 2008/10/03</br>
        /// </remarks>
        public PMKHN09170UA()
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

            this._custRateGroupAcs = new CustRateGroupAcs();
            this._makerAcs = new MakerAcs();
            this._customerSearchAcs = new CustomerSearchAcs();

            // --- ADD 2009/01/09 障害ID:9806対応------------------------------------------------------>>>>>
            this._userGuideAcs = new UserGuideAcs();
            // --- ADD 2009/01/09 障害ID:9806対応------------------------------------------------------<<<<<

            this._controlScreenSkin = new ControlScreenSkin();

            // グリッドを配列にセット
            //this._custRateGroup_Grid = new UltraGrid[3];
            this._custRateGroup_Grid = new UltraGrid[2];
            this._custRateGroup_Grid[0] = this.uGrid_CustRateGroup1;
            // 純正のGrid数を２→１へ変更 >>>>>>START
            //this._custRateGroup_Grid[1] = this.uGrid_CustRateGroup2;
            //this._custRateGroup_Grid[2] = this.uGrid_CustRateGroup3;
            this._custRateGroup_Grid[1] = this.uGrid_CustRateGroup3;
            // 純正のGrid数を２→１へ変更 <<<<<<END
            
            // DataSet列情報構築
            this.Bind_DataSet = new DataSet();
            DataSetColumnConstruction();

            // 画面初期設定
            SetScreenInitialSetting();
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
        /// グリッド列外観情報取得処理
        /// </summary>
        /// <returns>グリッド列外観情報格納Hashtable</returns>
        /// <remarks>
        /// <br>Note       : 各列の外見を設定するクラスを格納したHashtableを取得します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/10/03</br>
        /// </remarks>
        public void GetAppearanceTable(out Hashtable[] appearanceTable)
        {
            //==============================
            // メイン
            //==============================
            Hashtable main = new Hashtable();

            main.Add(VIEW_DELETEDATE, new GridColAppearance(MGridColDispType.DeletionDataBoth, ContentAlignment.MiddleLeft, "", Color.Red));    // ADD 2008/03/23 不具合対応[7746]：「削除済データの表示」は最上位項目で制御
            main.Add(VIEW_CUSTOMERCODE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            main.Add(VIEW_CUSTOMERNAME, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));

            //==============================
            // 詳細
            //==============================
            Hashtable detail = new Hashtable();

            detail.Add(VIEW_DELETEDATE, new GridColAppearance(MGridColDispType.DeletionDataBoth, ContentAlignment.MiddleLeft, "", Color.Red));
            detail.Add(VIEW_MAKERNAME, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            detail.Add(VIEW_CUSTRATEGROUP, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));

            appearanceTable = new Hashtable[2];
            appearanceTable[0] = main;
            appearanceTable[1] = detail;
        }

        /// <summary>
        /// バインドデータセット取得処理
        /// </summary>
        /// <param name="bindDataSet">グリッド表示用データセット</param>
        /// <param name="tableName">テーブル名称</param>
        /// <remarks>
        /// <br>Note       : グリッドにバインドさせるデータセットを取得します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/10/03</br>
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
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/10/03</br>
        /// </remarks>
        public bool[] GetCanLogicalDeleteDataExtractionList()
        {
            bool[] logicalDeleteButton = { true, false };   // MOD 2009/03/23 不具合対応[7746]：「削除済データの表示」は最上位項目で制御 { false, true }→{ true, false }
            return logicalDeleteButton;
        }

        /// <summary>
        /// グリッド列のサイズの自動調整のデフォルト値リスト取得処理
        /// </summary>
        /// <returns>グリッド列のサイズの自動調整のデフォルト値リスト</returns>
        /// <remarks>
        /// <br>Note       : グリッド列のサイズの自動調整チェックボックスのチェック有無のデフォルト値を配列で取得します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/10/03</br>
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
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/10/03</br>
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
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/10/03</br>
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
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/10/03</br>
        /// </remarks>
        public string[] GetGridTitleList()
        {
            string[] gridTitle = { GRIDTITLE_CUSTOMER, GRIDTITLE_CUSTRATEGROUP };
            return gridTitle;
        }

        /// <summary>
        /// 修正ボタンの有効設定リスト取得処理
        /// </summary>
        /// <returns>修正ボタンの有効設定リスト</returns>
        /// <remarks>
        /// <br>Note       : 修正ボタンの有効設定リストを取得します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/10/03</br>
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
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/10/03</br>
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
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/10/03</br>
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
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/10/03</br>
        /// </remarks>
        public int Delete()
        {
            // 論理削除処理
            bool bStatus = LogicalDeleteProc();
            if (!bStatus)
            {
                return -1;
            }

            return 0;
        }

        /// <summary>
        /// 明細データ検索処理
        /// </summary>
        /// <param name="totalCount">全該当件数</param>
        /// <param name="readCount">抽出対象件数</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 先頭から指定件数分のデータを検索し、抽出結果を展開したDataSetと全該当件数を返します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/10/03</br>
        /// </remarks>
        public int DetailsDataSearch(ref int totalCount, int readCount)
        {
            ArrayList retList;

            // 現在保持しているデータをクリアする
            this.Bind_DataSet.Tables[TABLE_DETAIL].Rows.Clear();

            // ADD 2009/03/23 不具合対応[7746]：「削除済データの表示」は最上位項目で制御 ---------->>>>>
            // readCountが負の場合、強制終了
            if (readCount < 0) return 0;
            // ADD 2009/03/23 不具合対応[7746]：「削除済データの表示」は最上位項目で制御 ----------<<<<<

            // 選択されているデータを取得する
            int customerCode = int.Parse((string)this.Bind_DataSet.Tables[TABLE_MAIN].Rows[this._mainDataIndex][VIEW_CUSTOMERCODE]);

            // 検索処理（論理削除含む）
            int status = this._custRateGroupAcs.Search(out retList, this._enterpriseCode, customerCode, ConstantManagement.LogicalMode.GetData01);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    {
                        // 取得したクラスをデータセットへ展開する
                        int index = 0;
                        foreach (CustRateGroup custRateGroup in retList)
                        {
                            // DataSet展開処理
                            DetailToDataSet(custRateGroup, index);
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

            return 0;
        }

        /// <summary>
        /// データ検索処理
        /// </summary>
        /// <param name="totalCount">全該当件数</param>
        /// <param name="readCount">抽出対象件数</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 先頭から指定件数分のデータを検索し、抽出結果を展開したDataSetと全該当件数を返します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/10/03</br>
        /// </remarks>
        public int Search(ref int totalCount, int readCount)
        {
            // 現在保持しているデータをクリアする
            this.Bind_DataSet.Tables[TABLE_MAIN].Rows.Clear();

            this._mainList = new Dictionary<int, CustRateGroup>();
            this._detailList = new List<CustRateGroup>();

            ArrayList retList;

            int status = this._custRateGroupAcs.Search(out retList, this._enterpriseCode, ConstantManagement.LogicalMode.GetData01);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    {
                        // バッファ保持
                        int index = 0;
                        string customerSnm;
                        foreach (CustRateGroup custRateGroup in retList)
                        {
                            this._detailList.Add(custRateGroup);

                            if (!this._mainList.ContainsKey(custRateGroup.CustomerCode))
                            {
                                this._mainList.Add(custRateGroup.CustomerCode, custRateGroup);

                                // 得意先マスタから論理削除されているもの
                                customerSnm = GetCustomerName(custRateGroup.CustomerCode);
                                if (customerSnm == "")
                                {
                                    continue;
                                }

                                // DataSet展開処理
                                MainToDataSet(custRateGroup, index, customerSnm);
                                index++;
                            }
                        }
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

            //// 読み込んだインスタンスのそれぞれをデータセットに展開
            //int index = 0;
            //string customerSnm;
            //foreach (CustRateGroup cstRateGroup in this._mainList.Values)
            //{
            //    // 得意先マスタから論理削除されているもの
            //    customerSnm = GetCustomerName(cstRateGroup.CustomerCode);
            //    if (customerSnm == "")
            //    {
            //        continue;
            //    }

            //    // DataSet展開処理
            //    MainToDataSet(cstRateGroup, index, customerSnm);
            //    index++;
            //}

            totalCount = this._mainList.Count;

            return 0;
        }

        /// <summary>
        /// ネクストデータ検索処理
        /// </summary>
        /// <param name="readCount">抽出対象件数</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 指定した件数分のネクストデータを検索します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/10/03</br>
        /// </remarks>
        public int SearchNext(int readCount)
        {
            // 未実装
            return 0;
        }

        /// <summary>
        /// 明細ネクストデータ検索処理
        /// </summary>
        /// <param name="readCount">抽出対象件数</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 指定した件数分のネクストデータを検索します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/10/03</br>
        /// </remarks>
        public int DetailsDataSearchNext(int readCount)
        {
            // 未実装
            return 0;
        }

        /// <summary>
        /// 印刷処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 印刷処理を実行します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/10/03</br>
        /// </remarks>
        public int Print()
        {
            // 未実装
            return 0;
        }

        /// <summary>画面非表示イベント</summary>
        /// <remarks>画面が非表示状態になった際に発生します。</remarks>
        public event MasterMaintenanceArrayTypeUnDisplayingEventHandler UnDisplaying;

        #endregion ■ IMasterMaintenanceArrayType メンバ


        #region ■ Private Methods
        /// <summary>
        /// 得意先情報読込処理
        /// </summary>
        private void ReadCustomerSearchRet()
        {
            this._customerSearchRetDic = new Dictionary<int, CustomerSearchRet>();

            try
            {
                CustomerSearchRet[] retArray;

                CustomerSearchPara para = new CustomerSearchPara();
                para.EnterpriseCode = this._enterpriseCode;

                int status = this._customerSearchAcs.Serch(out retArray, para);
                if (status == 0)
                {
                    foreach (CustomerSearchRet ret in retArray)
                    {
                        if (ret.LogicalDeleteCode == 0)
                        {
                            this._customerSearchRetDic.Add(ret.CustomerCode, ret);
                        }
                    }
                }
            }
            catch
            {
                this._customerSearchRetDic = new Dictionary<int, CustomerSearchRet>();
            }
        }

        // --- ADD 2009/01/09 障害ID:9806対応------------------------------------------------------>>>>>
        /// <summary>
        /// 得意先掛率グループコード読込処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : ユーザーガイドマスタを読み込み、得意先掛率グループコードをバッファに保持します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2009/01/09</br>
        /// </remarks>
        private void ReadUserGuide()
        {
            this._custRateGrpDic = new Dictionary<int, string>();

            try
            {
                int status;
                ArrayList retList;
                
                status = this._userGuideAcs.SearchAllDivCodeBody(out retList, this._enterpriseCode,
                                                                 43, UserGuideAcsData.UserBodyData);
                if (status == 0)
                {
                    foreach (UserGdBd userGdBd in retList)
                    {
                        if (userGdBd.LogicalDeleteCode == 0)
                        {
                            // DEL 2009/11/19 3次分対応 得意先掛率グループ改良 ---------->>>>>
                            //this._custRateGrpDic.Add(userGdBd.GuideCode, userGdBd.GuideName.Trim());
                            // DEL 2009/11/19 3次分対応 得意先掛率グループ改良 ----------<<<<<
                            // ADD 2009/11/19 3次分対応 得意先掛率グループ改良 ---------->>>>>
                            // MEMO:得意先掛率グループコードは｢-1:未設定｣
                            string guideName = GetGuideNameIf(userGdBd);
                            this._custRateGrpDic.Add(userGdBd.GuideCode, guideName.Trim());
                            // ADD 2009/11/19 3次分対応 得意先掛率グループ改良 ----------<<<<<
                        }
                    }
                }
            }
            catch
            {
                this._custRateGrpDic = new Dictionary<int, string>();
            }
            // ADD 2009/11/19 3次分対応 得意先掛率グループ改良 ---------->>>>>
            // MEMO:得意先掛率グループコードは｢-1:未設定｣
            if (!this._custRateGrpDic.ContainsKey(NULL_CODE))
            {
                this._custRateGrpDic.Add(NULL_CODE, NULL_NAME);
            }
            // ADD 2009/11/19 3次分対応 得意先掛率グループ改良 ----------<<<<<
        }

        // ADD 2009/11/19 3次分対応 得意先掛率グループ改良 ---------->>>>>
        /// <summary>未設定コード</summary>
        private const int NULL_CODE = -1;
        /// <summary>未設定コード名称</summary>
        private const string NULL_NAME = "未設定";

        /// <summary>
        /// ガイド名称を取得します。
        /// </summary>
        /// <param name="userGuideBody">ユーザーガイド</param>
        /// <returns>
        /// ガイド名称<br/>
        /// ガイドコード=-1 … ガイド名称が<c>string.Empty</c>の場合、"未設定"を返します。
        /// </returns>
        private static string GetGuideNameIf(UserGdBd userGuideBody)
        {
            if (userGuideBody == null) return string.Empty;

            if (userGuideBody.GuideCode.Equals(NULL_CODE))
            {
                return string.IsNullOrEmpty(userGuideBody.GuideName) ? NULL_NAME : userGuideBody.GuideName;
            }
            return userGuideBody.GuideName;
        }
        // ADD 2009/11/19 3次分対応 得意先掛率グループ改良 ----------<<<<<

        /// <summary>
        /// 得意先掛率グループ名称取得処理
        /// </summary>
        /// <param name="custRateGrpCode">得意先掛率グループコード</param>
        /// <returns>得意先掛率グループ名称</returns>
        /// <remarks>
        /// <br>Note       : 得意先掛率グループコードに該当する得意先掛率グループ名称を取得します。。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2009/01/09</br>
        /// </remarks>
        private string GetCustRateGrpName(int custRateGrpCode)
        {
            string custRateGrpName = "";

            if (this._custRateGrpDic.ContainsKey(custRateGrpCode))
            {
                custRateGrpName = this._custRateGrpDic[custRateGrpCode];
            }

            return custRateGrpName;
        }
        // --- ADD 2009/01/09 障害ID:9806対応------------------------------------------------------<<<<<

        /// <summary>
        /// メーカーマスタ読込処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : メーカーマスタを読み込み、バッファに保持します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/10/03</br>
        /// </remarks>
        private void ReadMakerUMnt()
        {
            this._makerUMntDic = new Dictionary<int, MakerUMnt>();

            try
            {
                ArrayList retList;

                int status = this._makerAcs.SearchAll(out retList, this._enterpriseCode);
                if (status == 0)
                {
                    foreach (MakerUMnt makerUMnt in retList)
                    {
                        this._makerUMntDic.Add(makerUMnt.GoodsMakerCd, makerUMnt);
                    }
                }
            }
            catch
            {
                this._makerUMntDic = new Dictionary<int, MakerUMnt>();
            }
        }

        /// <summary>
        /// メーカー名取得処理
        /// </summary>
        /// <param name="makerCode">メーカーコード</param>
        /// <returns>メーカー名</returns>
        /// <remarks>
        /// <br>Note       : メーカー名を取得します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/10/03</br>
        /// </remarks>
        private string GetMakerName(int makerCode)
        {
            string makerName = "";

            if (this._makerUMntDic.ContainsKey(makerCode))
            {
                makerName = this._makerUMntDic[makerCode].MakerName.Trim();
            }

            return makerName;
        }

        /// <summary>
        /// 得意先名取得処理
        /// </summary>
        /// <param name="customerCode">得意先コード</param>
        /// <returns>得意先名</returns>
        /// <remarks>
        /// <br>Note       : 得意先名を取得します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/10/03</br>
        /// </remarks>
        private string GetCustomerName(int customerCode)
        {
            if (this._customerSearchRetDic.ContainsKey(customerCode))
            {
                return this._customerSearchRetDic[customerCode].Snm.Trim();
            }

            return "";
        }

        /// <summary>
        /// 画面初期化処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面情報を初期化します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date	   : 2008/10/03</br>
        /// </remarks>
        private void ScreenClear()
        {
            // 拠点
            this.tNedit_CustomerCode.Clear();
            this.tEdit_CustomerName.Clear();

            // グリッド
            for (int index = 0; index < this._custRateGroup_Grid.Length; index++)
            {
                for (int rowIndex = 0; rowIndex < this._custRateGroup_Grid[index].Rows.Count; rowIndex++)
                {
                    this._custRateGroup_Grid[index].AfterCellUpdate -= uGrid_CustRateGroup_AfterCellUpdate;
                    this._cellUpdateFlg = true;

                    // DEL 2009/11/19 3次分対応 得意先掛率グループ改良 ---------->>>>>
                    //this._custRateGroup_Grid[index].Rows[rowIndex].Cells[COLUMN_CUSTRATEGROUP].Value = "0000";
                    // DEL 2009/11/19 3次分対応 得意先掛率グループ改良 ----------<<<<<
                    // ADD 2009/11/19 3次分対応 得意先掛率グループ改良 ---------->>>>>
                    // MEMO:得意先掛率グループコードを初期化
                    this._custRateGroup_Grid[index].Rows[rowIndex].Cells[COLUMN_CUSTRATEGROUP].Value = string.Empty;
                    // ADD 2009/11/19 3次分対応 得意先掛率グループ改良 ----------<<<<<

                    this._custRateGroup_Grid[index].Rows[rowIndex].Cells[COLUMN_CUSTRATEGROUP].Activation = Activation.AllowEdit;

                    // DEL 2009/11/19 3次分対応 得意先掛率グループ改良 ---------->>>>>
                    //this._custRateGroup_Grid[index].Rows[rowIndex].Cells[COLUMN_CUSTRATEGROUPNAME].Value = GetCustRateGrpName(0);  // 掛率G名称
                    // DEL 2009/11/19 3次分対応 得意先掛率グループ改良 ----------<<<<<
                    // ADD 2009/11/19 3次分対応 得意先掛率グループ改良 ---------->>>>>
                    // MEMO:得意先掛率グループコード名称を初期化
                    this._custRateGroup_Grid[index].Rows[rowIndex].Cells[COLUMN_CUSTRATEGROUPNAME].Value = GetCustRateGrpName(NULL_CODE);
                    // ADD 2009/11/19 3次分対応 得意先掛率グループ改良 ----------<<<<<

                    this._custRateGroup_Grid[index].AfterCellUpdate += uGrid_CustRateGroup_AfterCellUpdate;
                    this._cellUpdateFlg = false;
                }

                this._custRateGroup_Grid[index].ActiveCell = null;
                this._custRateGroup_Grid[index].ActiveRow = null;
            }
        }

        /// <summary>
        /// 画面初期設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面の初期設定を行います。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date	   : 2008/10/03</br>
        /// </remarks>
        private void SetScreenInitialSetting()
        {
            // マスタ読込
            ReadMakerUMnt();
            ReadUserGuide();
            ReadCustomerSearchRet();
            
            // コントロールサイズ設定
            this.tNedit_CustomerCode.Size = new Size(76, 24);
            this.tEdit_CustomerName.Size = new Size(171, 24);

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
            this.CustomerGuide_Button.ImageList = imageList16;
            this.CustomerGuide_Button.Appearance.Image = Size16_Index.STAR1;
            this.Renewal_Button.ImageList = imageList16;
            this.Renewal_Button.Appearance.Image = Size16_Index.RENEWAL;

            // MEMO:グリッド構築
            int makerCode = 0;
            int rowCount;
            for (int index = 0; index < this._custRateGroup_Grid.Length; index++)
            {
                // 純正のGrid数を２→１へ変更
                // 掛率G名称とガイドボタンを追加
                DataTable dataTable = new DataTable();
                dataTable.Columns.Add(COLUMN_MAKERCODE, typeof(string));
                dataTable.Columns.Add(COLUMN_MAKERNAME, typeof(string));
                dataTable.Columns.Add(COLUMN_CUSTRATEGROUP, typeof(string));
                dataTable.Columns.Add(COLUMN_CUSTRATEGROUPNAME, typeof(string));
                dataTable.Columns.Add(COLUMN_CUSTRATEGROUPBUTTON, typeof(Button));
                dataTable.Columns.Add(COLUMN_MAKERTITLE, typeof(string));
                dataTable.Columns.Add(COLUMN_CUSTRATEGROUPTITLE, typeof(string));
                dataTable.Columns.Add(COLUMN_CUSTRATEGROUPNAMETITLE, typeof(string));
                dataTable.Columns.Add(COLUMN_CUSTRATEGROUPBUTTONTITLE, typeof(string));

                //if (index == 2)
                if (index == 1)
                {
                    // 優良
                    rowCount = 1;
                }
                else
                {
                    // 純正
                    //rowCount = 13;
                    rowCount = 26;
                }

                for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
                {
                    DataRow dataRow = dataTable.NewRow();
                    
                    //if (index == 2)
                    if (index == 1)
                    {
                        // 優良
                        dataRow[COLUMN_MAKERCODE] = "0000";
                        dataRow[COLUMN_MAKERNAME] = "優良ALL";
                    }
                    else
                    {
                        // 純正
                        dataRow[COLUMN_MAKERCODE] = makerCode.ToString("0000");

                        if (makerCode == 0)
                        {
                            dataRow[COLUMN_MAKERNAME] = "純正ALL";
                        }
                        else
                        {
                            dataRow[COLUMN_MAKERNAME] = GetMakerName(makerCode);
                        }
                    }
                    // DEL 2009/11/19 3次分対応 得意先掛率グループ改良 ---------->>>>>
                    //dataRow[COLUMN_CUSTRATEGROUP] = "0000";
                    //dataRow[COLUMN_CUSTRATEGROUPNAME] = GetCustRateGrpName(0);
                    // DEL 2009/11/19 3次分対応 得意先掛率グループ改良 ----------<<<<<
                    // ADD 2009/11/19 3次分対応 得意先掛率グループ改良 ---------->>>>>
                    // MEMO:得意先掛率グループコードは｢-1:未設定｣
                    dataRow[COLUMN_CUSTRATEGROUP] = string.Empty;
                    dataRow[COLUMN_CUSTRATEGROUPNAME] = GetCustRateGrpName(NULL_CODE);
                    // ADD 2009/11/19 3次分対応 得意先掛率グループ改良 ----------<<<<<

                    dataRow[COLUMN_CUSTRATEGROUPBUTTON] = DBNull.Value;
                    dataRow[COLUMN_MAKERTITLE] = DBNull.Value;
                    dataRow[COLUMN_CUSTRATEGROUPTITLE] = DBNull.Value;
                    dataRow[COLUMN_CUSTRATEGROUPNAMETITLE] = DBNull.Value;
                    dataRow[COLUMN_CUSTRATEGROUPBUTTONTITLE] = DBNull.Value;
                    dataTable.Rows.Add(dataRow);

                    makerCode++;
                }

                this._custRateGroup_Grid[index].DataSource = dataTable;

                this._custRateGroup_Grid[index].Tag = index;

                // 行レイアウトモード有効
                this._custRateGroup_Grid[index].DisplayLayout.Bands[0].UseRowLayout = true;
                
                ColumnsCollection columns = this._custRateGroup_Grid[index].DisplayLayout.Bands[0].Columns;
                
                // ラベルスタイル設定
                columns[COLUMN_MAKERCODE].RowLayoutColumnInfo.LabelPosition = LabelPosition.None;
                columns[COLUMN_MAKERNAME].RowLayoutColumnInfo.LabelPosition = LabelPosition.None;
                columns[COLUMN_CUSTRATEGROUP].RowLayoutColumnInfo.LabelPosition = LabelPosition.None;
                columns[COLUMN_CUSTRATEGROUPNAME].RowLayoutColumnInfo.LabelPosition = LabelPosition.None;
                columns[COLUMN_CUSTRATEGROUPBUTTON].RowLayoutColumnInfo.LabelPosition = LabelPosition.None;
                columns[COLUMN_MAKERTITLE].RowLayoutColumnInfo.LabelPosition = LabelPosition.LabelOnly;
                columns[COLUMN_CUSTRATEGROUPTITLE].RowLayoutColumnInfo.LabelPosition = LabelPosition.LabelOnly;
                columns[COLUMN_CUSTRATEGROUPNAMETITLE].RowLayoutColumnInfo.LabelPosition = LabelPosition.LabelOnly;
                columns[COLUMN_CUSTRATEGROUPBUTTONTITLE].RowLayoutColumnInfo.LabelPosition = LabelPosition.LabelOnly;
                // ラベル位置設定
                columns[COLUMN_MAKERCODE].RowLayoutColumnInfo.OriginX = 0;
                columns[COLUMN_MAKERNAME].RowLayoutColumnInfo.OriginX = 1;
                columns[COLUMN_CUSTRATEGROUP].RowLayoutColumnInfo.OriginX = 2;
                columns[COLUMN_CUSTRATEGROUPNAME].RowLayoutColumnInfo.OriginX = 3;
                columns[COLUMN_CUSTRATEGROUPBUTTON].RowLayoutColumnInfo.OriginX = 4;
                columns[COLUMN_MAKERTITLE].RowLayoutColumnInfo.OriginX = 0;
                columns[COLUMN_CUSTRATEGROUPTITLE].RowLayoutColumnInfo.OriginX = 2;
                columns[COLUMN_CUSTRATEGROUPNAMETITLE].RowLayoutColumnInfo.OriginX = 3;
                columns[COLUMN_CUSTRATEGROUPBUTTONTITLE].RowLayoutColumnInfo.OriginX = 4;
                // ラベルサイズ設定
                columns[COLUMN_MAKERTITLE].RowLayoutColumnInfo.LabelSpan = 2;
                columns[COLUMN_CUSTRATEGROUPTITLE].RowLayoutColumnInfo.LabelSpan = 1;
                columns[COLUMN_CUSTRATEGROUPNAMETITLE].RowLayoutColumnInfo.LabelSpan = 1;
                columns[COLUMN_CUSTRATEGROUPBUTTONTITLE].RowLayoutColumnInfo.LabelSpan = 1;
                // セルサイズ設定
                columns[COLUMN_MAKERCODE].RowLayoutColumnInfo.SpanX = 1;
                columns[COLUMN_MAKERNAME].RowLayoutColumnInfo.SpanX = 1;
                columns[COLUMN_CUSTRATEGROUP].RowLayoutColumnInfo.SpanX = 1;
                columns[COLUMN_CUSTRATEGROUPNAME].RowLayoutColumnInfo.SpanX = 1;
                columns[COLUMN_CUSTRATEGROUPBUTTON].RowLayoutColumnInfo.SpanX = 1;
                columns[COLUMN_MAKERTITLE].RowLayoutColumnInfo.SpanX = 2;
                columns[COLUMN_CUSTRATEGROUPTITLE].RowLayoutColumnInfo.SpanX = 1;
                columns[COLUMN_CUSTRATEGROUPNAMETITLE].RowLayoutColumnInfo.SpanX = 1;
                columns[COLUMN_CUSTRATEGROUPBUTTONTITLE].RowLayoutColumnInfo.SpanX = 1;
                // ヘッダーキャプション
                columns[COLUMN_MAKERTITLE].Header.Caption = "メーカー";
                columns[COLUMN_CUSTRATEGROUPTITLE].Header.Caption = "得意先掛率G";
                columns[COLUMN_CUSTRATEGROUPNAMETITLE].Header.Caption = "得意先掛率G名称";
                columns[COLUMN_CUSTRATEGROUPBUTTONTITLE].Header.Caption = "";
                // TextHAlign
                columns[COLUMN_MAKERCODE].CellAppearance.TextHAlign = HAlign.Right;
                columns[COLUMN_MAKERNAME].CellAppearance.TextHAlign = HAlign.Left;
                columns[COLUMN_CUSTRATEGROUP].CellAppearance.TextHAlign = HAlign.Right;
                columns[COLUMN_CUSTRATEGROUPNAME].CellAppearance.TextHAlign = HAlign.Left;
                // TextVAlign
                columns[COLUMN_MAKERCODE].CellAppearance.TextVAlign = VAlign.Middle;
                columns[COLUMN_MAKERNAME].CellAppearance.TextVAlign = VAlign.Middle;
                columns[COLUMN_CUSTRATEGROUP].CellAppearance.TextVAlign = VAlign.Middle;
                columns[COLUMN_CUSTRATEGROUPNAME].CellAppearance.TextVAlign = VAlign.Middle;
                // 入力制御
                columns[COLUMN_MAKERCODE].CellActivation = Activation.Disabled;
                columns[COLUMN_MAKERNAME].CellActivation = Activation.Disabled;
                columns[COLUMN_CUSTRATEGROUP].CellActivation = Activation.AllowEdit;
                columns[COLUMN_CUSTRATEGROUPNAME].CellActivation = Activation.Disabled;
                columns[COLUMN_CUSTRATEGROUPBUTTON].CellActivation = Activation.NoEdit;
                columns[COLUMN_MAKERTITLE].CellActivation = Activation.Disabled;
                columns[COLUMN_CUSTRATEGROUPTITLE].CellActivation = Activation.Disabled;
                columns[COLUMN_CUSTRATEGROUPNAMETITLE].CellActivation = Activation.Disabled;
                columns[COLUMN_CUSTRATEGROUPBUTTONTITLE].CellActivation = Activation.Disabled;
                // 列幅
                columns[COLUMN_MAKERCODE].Width = 40;
                columns[COLUMN_MAKERNAME].Width = 150;
                columns[COLUMN_CUSTRATEGROUP].Width = 90;
                columns[COLUMN_CUSTRATEGROUPNAME].Width = 150;
                columns[COLUMN_CUSTRATEGROUPBUTTON].Width = 20;
                // セルColor
                columns[COLUMN_MAKERCODE].CellAppearance.BackColor = Color.FromArgb(89, 135, 214);
                columns[COLUMN_MAKERCODE].CellAppearance.BackColorDisabled = Color.FromArgb(89, 135, 214);
                columns[COLUMN_MAKERCODE].CellAppearance.BackColor2 = Color.FromArgb(7, 59, 150);
                columns[COLUMN_MAKERCODE].CellAppearance.BackColorDisabled2 = Color.FromArgb(7, 59, 150);
                columns[COLUMN_MAKERCODE].CellAppearance.ForeColor = Color.White;
                columns[COLUMN_MAKERCODE].CellAppearance.ForeColorDisabled = Color.White;
                columns[COLUMN_MAKERCODE].CellAppearance.BackGradientStyle = GradientStyle.Vertical;
                columns[COLUMN_MAKERNAME].CellAppearance.BackColor = Color.Gainsboro;
                columns[COLUMN_MAKERNAME].CellAppearance.BackColorDisabled = Color.Gainsboro;
                columns[COLUMN_CUSTRATEGROUP].CellAppearance.BackColorDisabled = Color.FromKnownColor(KnownColor.Control);
                columns[COLUMN_CUSTRATEGROUPNAME].CellAppearance.BackColor = Color.Gainsboro;
                columns[COLUMN_CUSTRATEGROUPNAME].CellAppearance.BackColorDisabled = Color.Gainsboro;
                // MaxLength
                columns[COLUMN_CUSTRATEGROUP].MaxLength = this.uiSetControl1.GetSettingColumnCount(COLUMN_CUSTRATEGROUP);
                columns[COLUMN_MAKERNAME].MaxLength = 20;
                columns[COLUMN_CUSTRATEGROUPNAME].MaxLength = 20;
                // ガイドボタンの設定
                columns[COLUMN_CUSTRATEGROUPBUTTON].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;
                columns[COLUMN_CUSTRATEGROUPBUTTON].ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always;
                columns[COLUMN_CUSTRATEGROUPBUTTON].CellButtonAppearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
                columns[COLUMN_CUSTRATEGROUPBUTTON].TabStop = true;
                // 行の高さ
                for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
                {
                    this._custRateGroup_Grid[index].Rows[rowIndex].Height = 23;
                }
            }
        }

        /// <summary>
        /// DataSet展開処理(メインテーブル)
        /// </summary>
        /// <param name="custRateGroup">得意先マスタ(掛率グループ)</param>
        /// <param name="index">行インデックス</param>
        /// <param name="customerSnm">得意先略称</param>
        /// <remarks>
        /// <br>Note       : 得意先マスタ(掛率グループ)をDataSetに展開します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date	   : 2008/10/03</br>
        /// </remarks>
        private void MainToDataSet(CustRateGroup custRateGroup, int index, string customerSnm)
        {
            if ((index < 0) || (this.Bind_DataSet.Tables[TABLE_MAIN].Rows.Count <= index))
            {
                // 新規と判断して、行を追加する
                DataRow dataRow = this.Bind_DataSet.Tables[TABLE_MAIN].NewRow();
                this.Bind_DataSet.Tables[TABLE_MAIN].Rows.Add(dataRow);

                // indexを行の最終行番号する
                index = this.Bind_DataSet.Tables[TABLE_MAIN].Rows.Count - 1;
            }

            // 得意先コード
            this.Bind_DataSet.Tables[TABLE_MAIN].Rows[index][VIEW_CUSTOMERCODE] = custRateGroup.CustomerCode.ToString("00000000");
            // 得意先名称
            this.Bind_DataSet.Tables[TABLE_MAIN].Rows[index][VIEW_CUSTOMERNAME] = customerSnm;

            // ADD 2009/03/23 不具合対応[7746]：「削除済データの表示」は最上位項目で制御 ---------->>>>>
            // 削除日
            if (custRateGroup.LogicalDeleteCode == 0)
            {
                this.Bind_DataSet.Tables[TABLE_MAIN].Rows[index][VIEW_DELETEDATE] = "";
            }
            else
            {
                this.Bind_DataSet.Tables[TABLE_MAIN].Rows[index][VIEW_DELETEDATE] = custRateGroup.UpdateDateTimeJpInFormal;
            }
            // ADD 2009/03/23 不具合対応[7746]：「削除済データの表示」は最上位項目で制御 ----------<<<<<
        }

        /// <summary>
        /// DataSet展開処理(詳細テーブル)
        /// </summary>
        /// <param name="custRateGroup">得意先マスタ(掛率グループ)</param>
        /// <param name="index">行インデックス</param>
        /// <remarks>
        /// <br>Note       : 得意先マスタ(掛率グループ)をDataSetに展開します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date	   : 2008/10/03</br>
        /// </remarks>
        private void DetailToDataSet(CustRateGroup custRateGroup, int index)
        {
            // ADD 2009/12/15 3次分対応 得意先掛率グループ改良(追加):得意先掛率グループコード=-1をDB登録する ---------->>>>>
            // FIXME:未設定(得意先掛率グループコード=-1)はフレームに表示しない
            if (custRateGroup.CustRateGrpCode <= NULL_CODE) return;
            // ADD 2009/12/15 3次分対応 得意先掛率グループ改良(追加):得意先掛率グループコード=-1をDB登録する ----------<<<<<

            if ((index < 0) || (this.Bind_DataSet.Tables[TABLE_DETAIL].Rows.Count <= index))
            {
                // 新規と判断して、行を追加する
                DataRow dataRow = this.Bind_DataSet.Tables[TABLE_DETAIL].NewRow();
                this.Bind_DataSet.Tables[TABLE_DETAIL].Rows.Add(dataRow);

                // indexを行の最終行番号する
                index = this.Bind_DataSet.Tables[TABLE_DETAIL].Rows.Count - 1;
            }

            // メーカー
            if (custRateGroup.PureCode == 0)
            {
                // 純正
                if (custRateGroup.GoodsMakerCd == 0)
                {
                    this.Bind_DataSet.Tables[TABLE_DETAIL].Rows[index][VIEW_MAKERNAME] = "純正ALL";
                }
                else
                {
                    this.Bind_DataSet.Tables[TABLE_DETAIL].Rows[index][VIEW_MAKERNAME] = GetMakerName(custRateGroup.GoodsMakerCd);
                }
            }
            else
            {
                // 優良
                this.Bind_DataSet.Tables[TABLE_DETAIL].Rows[index][VIEW_MAKERNAME] = "優良ALL";
            }
            // 得意先掛率グループ
            this.Bind_DataSet.Tables[TABLE_DETAIL].Rows[index][VIEW_CUSTRATEGROUP] = custRateGroup.CustRateGrpCode.ToString("0000");
            // 削除日
            if (custRateGroup.LogicalDeleteCode == 0)
            {
                this.Bind_DataSet.Tables[TABLE_DETAIL].Rows[index][VIEW_DELETEDATE] = "";
            }
            else
            {
                this.Bind_DataSet.Tables[TABLE_DETAIL].Rows[index][VIEW_DELETEDATE] = custRateGroup.UpdateDateTimeJpInFormal;
            }
        }

        /// <summary>
        /// DataSet列情報構築処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : DataSet列情報を構築します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date	   : 2008/10/03</br>
        /// </remarks>
        private void DataSetColumnConstruction()
        {
            //==============================
            // メイン
            //==============================
            DataTable mainTable = new DataTable(TABLE_MAIN);

            mainTable.Columns.Add(VIEW_DELETEDATE, typeof(string)); // ADD 2008/03/23 不具合対応[7746]：「削除済データの表示」は最上位項目で制御
            mainTable.Columns.Add(VIEW_CUSTOMERCODE, typeof(string));
            mainTable.Columns.Add(VIEW_CUSTOMERNAME, typeof(string));

            //==============================
            // 詳細
            //==============================
            DataTable detailTable = new DataTable(TABLE_DETAIL);

            detailTable.Columns.Add(VIEW_DELETEDATE, typeof(string));
            detailTable.Columns.Add(VIEW_MAKERNAME, typeof(string));
            detailTable.Columns.Add(VIEW_CUSTRATEGROUP, typeof(string));

            this.Bind_DataSet.Tables.Add(mainTable);
            this.Bind_DataSet.Tables.Add(detailTable);
        }

        // ADD 2009/12/15 3次分対応 得意先掛率グループ改良(追加):得意先掛率グループコード=-1をDB登録する ---------->>>>>
        /// <summary>画面再構築中フラグ</summary>
        private bool _reconstructing;
        /// <summary>画面再構築中フラグを取得または設定します。</summary>
        private bool Reconstructing
        {
            get { return _reconstructing; }
            set { _reconstructing = value; }
        }
        // ADD 2009/12/15 3次分対応 得意先掛率グループ改良(追加):得意先掛率グループコード=-1をDB登録する ----------<<<<<

        /// <summary>
        /// 画面再構築処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面を再構築します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date	   : 2008/10/03</br>
        /// </remarks>
        private void ScreenReconstruction()
        {
            // ADD 2009/12/15 3次分対応 得意先掛率グループ改良(追加):得意先掛率グループコード=-1をDB登録する ---------->>>>>
            Reconstructing = true;
            try
            {
            // ADD 2009/12/15 3次分対応 得意先掛率グループ改良(追加):得意先掛率グループコード=-1をDB登録する ----------<<<<<
                if (this._mainDataIndex < 0)
                {
                    //------------------------------
                    // 新規モード
                    //------------------------------
                    this.Mode_Label.Text = INSERT_MODE;

                    // 画面入力許可制御
                    PermitScreenInput(INSERT_MODE);

                    this.Ok_Button.Visible = true;
                    this.Cancel_Button.Visible = true;
                    this.Delete_Button.Visible = false;
                    this.Revive_Button.Visible = false;
                    this.Renewal_Button.Visible = true;

                    // クローン作成
                    this._custRateGroupListClone = new List<CustRateGroup>();

                    // フォーカス設定
                    this.tNedit_CustomerCode.Focus();
                }
                else
                {
                    // DataSetから得意先コードを取得
                    int customerCode = int.Parse((string)this.Bind_DataSet.Tables[TABLE_MAIN].Rows[this._mainDataIndex][VIEW_CUSTOMERCODE]);

                    // 得意先コードでインスタンスリストから該当データを取得
                    List<CustRateGroup> custRateGroupList = this._detailList.FindAll(delegate(CustRateGroup x)
                    {
                        if (x.CustomerCode == customerCode)
                        {
                            return (true);
                        }
                        else
                        {
                            return (false);
                        }
                    });

                    this._custRateGroupListClone = new List<CustRateGroup>();

                    if (custRateGroupList.Count == 0)
                    {
                        CustRateGroup custRateGroup = new CustRateGroup();
                        custRateGroup.CustomerCode = customerCode;
                        custRateGroupList.Add(custRateGroup);
                    }
                    else
                    {
                        foreach (CustRateGroup custRateGroup in custRateGroupList)
                        {
                            this._custRateGroupListClone.Add(custRateGroup.Clone());
                        }
                    }

                    // 画面展開処理
                    CustRateGroupListToScreen(custRateGroupList);

                    if (custRateGroupList[0].LogicalDeleteCode == 0)
                    {
                        // 更新モード
                        this.Mode_Label.Text = UPDATE_MODE;

                        // 画面入力許可制御
                        PermitScreenInput(UPDATE_MODE);

                        this.Ok_Button.Visible = true;
                        this.Cancel_Button.Visible = true;
                        this.Delete_Button.Visible = false;
                        this.Revive_Button.Visible = false;
                        this.Renewal_Button.Visible = true;

                        // フォーカス設定
                        this._custRateGroup_Grid[0].Focus();
                        this._custRateGroup_Grid[0].Rows[0].Cells[COLUMN_CUSTRATEGROUP].Activate();
                        this._custRateGroup_Grid[0].PerformAction(UltraGridAction.EnterEditMode);
                    }
                    else
                    {
                        // 削除モード
                        this.Mode_Label.Text = DELETE_MODE;

                        // 画面入力許可制御
                        PermitScreenInput(DELETE_MODE);

                        this.Ok_Button.Visible = false;
                        this.Cancel_Button.Visible = true;
                        this.Delete_Button.Visible = true;
                        this.Revive_Button.Visible = true;
                        this.Renewal_Button.Visible = false;

                        // フォーカス設定
                        this.Delete_Button.Focus();
                    }
                }
            // ADD 2009/12/15 3次分対応 得意先掛率グループ改良(追加):得意先掛率グループコード=-1をDB登録する ---------->>>>>
            }
            finally
            {
                Reconstructing = false;
            }
            // ADD 2009/12/15 3次分対応 得意先掛率グループ改良(追加):得意先掛率グループコード=-1をDB登録する ----------<<<<<
        }

        /// <summary>
        /// 画面入力許可制御処理
        /// </summary>
        /// <param name="mode">編集モード</param>
        /// <remarks>
        /// <br>Note       : 編集モードによって画面の入力許可制御を行います。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date	   : 2008/10/03</br>
        /// </remarks>
        private void PermitScreenInput(string mode)
        {
            switch (mode)
            {
                case INSERT_MODE:
                    {
                        // MEMO:新規モード
                        this.tNedit_CustomerCode.Enabled = true;
                        this.CustomerGuide_Button.Enabled = true;

                        for (int index = 0; index < this._custRateGroup_Grid.Length; index++)
                        {
                            this._custRateGroup_Grid[index].Enabled = true;
                        }
                        break;
                    }
                case UPDATE_MODE:
                    {
                        // MEMO:更新モード
                        this.tNedit_CustomerCode.Enabled = false;
                        this.CustomerGuide_Button.Enabled = false;

                        for (int index = 0; index < this._custRateGroup_Grid.Length; index++)
                        {
                            this._custRateGroup_Grid[index].Enabled = true;
                        }
                        break;
                    }
                case DELETE_MODE:
                    {
                        // MEMO:削除モード
                        this.tNedit_CustomerCode.Enabled = false;
                        this.CustomerGuide_Button.Enabled = false;

                        for (int index = 0; index < this._custRateGroup_Grid.Length; index++)
                        {
                            this._custRateGroup_Grid[index].Enabled = false;
                        }
                        break;
                    }
            }
        }

        /// <summary>
        /// 得意先マスタ(掛率グループ)リスト画面展開処理
        /// </summary>
        /// <param name="custRateGroupList">得意先マスタ(掛率グループ)リスト</param>
        /// <remarks>
        /// <br>Note       : 得意先マスタ(掛率グループ)リストを画面展開します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date	   : 2008/10/03</br>
        /// </remarks>
        private void CustRateGroupListToScreen(List<CustRateGroup> custRateGroupList)
        {
            bool pureFlg = false;

            foreach (CustRateGroup custRateGroup in custRateGroupList)
            {
                // 得意先コード
                this.tNedit_CustomerCode.SetInt(custRateGroup.CustomerCode);
                // 得意先名
                this.tEdit_CustomerName.DataText = GetCustomerName(custRateGroup.CustomerCode);

                if (custRateGroup.PureCode == 0)
                {
                    // 純正
                    if ( custRateGroup.GoodsMakerCd == 0 )
                    {
                        pureFlg = true;
                    }
                    // --- ADD m.suzuki 2010/07/15 ---------->>>>>
                    else
                    {
                        // 不正データ(純正ALL=-1,純正ﾒｰｶｰ別設定あり)を呼び出した際に
                        // 正常表示出来るよう修正。
                        pureFlg = false;
                    }
                    // --- ADD m.suzuki 2010/07/15 ----------<<<<<

                    //if (custRateGroup.GoodsMakerCd <= 12)
                    if (custRateGroup.GoodsMakerCd <= 25)
                    {
                        this.uGrid_CustRateGroup1.AfterCellUpdate -= uGrid_CustRateGroup_AfterCellUpdate;
                        this._cellUpdateFlg = true;

                        // DEL 2009/11/19 3次分対応 得意先掛率グループ改良 ---------->>>>>
                        //this.uGrid_CustRateGroup1.Rows[custRateGroup.GoodsMakerCd].Cells[COLUMN_CUSTRATEGROUP].Value = custRateGroup.CustRateGrpCode.ToString("0000");
                        //this.uGrid_CustRateGroup1.Rows[custRateGroup.GoodsMakerCd].Cells[COLUMN_CUSTRATEGROUPNAME].Value = GetCustRateGrpName(custRateGroup.CustRateGrpCode);   // 掛率G名称
                        // DEL 2009/11/19 3次分対応 得意先掛率グループ改良 ----------<<<<<
                        // ADD 2009/11/19 3次分対応 得意先掛率グループ改良 ---------->>>>>
                        // MEMO:得意先掛率グループコードは｢-1:未設定｣
                        if (custRateGroup.CustRateGrpCode >= 0)
                        {
                            this.uGrid_CustRateGroup1.Rows[custRateGroup.GoodsMakerCd].Cells[COLUMN_CUSTRATEGROUP].Value = custRateGroup.CustRateGrpCode.ToString("0000");
                            this.uGrid_CustRateGroup1.Rows[custRateGroup.GoodsMakerCd].Cells[COLUMN_CUSTRATEGROUPNAME].Value = GetCustRateGrpName(custRateGroup.CustRateGrpCode);   // 掛率G名称
                        }
                        else
                        {
                            this.uGrid_CustRateGroup1.Rows[custRateGroup.GoodsMakerCd].Cells[COLUMN_CUSTRATEGROUP].Value = string.Empty;
                            this.uGrid_CustRateGroup1.Rows[custRateGroup.GoodsMakerCd].Cells[COLUMN_CUSTRATEGROUPNAME].Value = GetCustRateGrpName(NULL_CODE);
                        }
                        // ADD 2009/11/19 3次分対応 得意先掛率グループ改良 ----------<<<<<

                        this.uGrid_CustRateGroup1.AfterCellUpdate += uGrid_CustRateGroup_AfterCellUpdate;
                        this._cellUpdateFlg = false;
                    }
                    #region 削除コード
                    //else
                    //{
                    //    this.uGrid_CustRateGroup2.AfterCellUpdate -= uGrid_CustRateGroup_AfterCellUpdate;
                    //    this._cellUpdateFlg = true;
                    //    this.uGrid_CustRateGroup2.Rows[custRateGroup.GoodsMakerCd - 13].Cells[COLUMN_CUSTRATEGROUP].Value = custRateGroup.CustRateGrpCode.ToString("0000");
                    //    this.uGrid_CustRateGroup2.AfterCellUpdate += uGrid_CustRateGroup_AfterCellUpdate;
                    //    this._cellUpdateFlg = false;
                    //}
                    #endregion
                }
                else
                {
                    // 優良
                    this.uGrid_CustRateGroup3.AfterCellUpdate -= uGrid_CustRateGroup_AfterCellUpdate;
                    this._cellUpdateFlg = true;

                    // DEL 2009/11/19 3次分対応 得意先掛率グループ改良 ---------->>>>>
                    //this.uGrid_CustRateGroup3.Rows[0].Cells[COLUMN_CUSTRATEGROUP].Value = custRateGroup.CustRateGrpCode.ToString("0000");
                    //this.uGrid_CustRateGroup3.Rows[0].Cells[COLUMN_CUSTRATEGROUPNAME].Value = GetCustRateGrpName(custRateGroup.CustRateGrpCode);    // 掛率G名称
                    // DEL 2009/11/19 3次分対応 得意先掛率グループ改良 ----------<<<<<
                    // ADD 2009/11/19 3次分対応 得意先掛率グループ改良 ---------->>>>>
                    // MEMO:得意先掛率グループコードは｢-1:未設定｣
                    if (custRateGroup.CustRateGrpCode >= 0)
                    {
                        this.uGrid_CustRateGroup3.Rows[0].Cells[COLUMN_CUSTRATEGROUP].Value = custRateGroup.CustRateGrpCode.ToString("0000");
                        this.uGrid_CustRateGroup3.Rows[0].Cells[COLUMN_CUSTRATEGROUPNAME].Value = GetCustRateGrpName(custRateGroup.CustRateGrpCode);    // 掛率G名称
                    }
                    else
                    {
                        this.uGrid_CustRateGroup3.Rows[0].Cells[COLUMN_CUSTRATEGROUP].Value = string.Empty;
                        this.uGrid_CustRateGroup3.Rows[0].Cells[COLUMN_CUSTRATEGROUPNAME].Value = GetCustRateGrpName(NULL_CODE);
                    }
                    // ADD 2009/11/19 3次分対応 得意先掛率グループ改良 ----------<<<<<

                    this.uGrid_CustRateGroup3.AfterCellUpdate += uGrid_CustRateGroup_AfterCellUpdate;
                    this._cellUpdateFlg = false;
                }
            }

            // --- DEL m.suzuki 2010/07/15 ---------->>>>>
            //// FIXME:画面再構築時の表示はここで終了
            //if (Reconstructing) return;
            // --- DEL m.suzuki 2010/07/15 ----------<<<<<

            if (pureFlg == true)
            {
                ChangeGridEnabled(false);
            }
        }

        /// <summary>
        /// 保存データ取得処理
        /// </summary>
        /// <returns>保存データ</returns>
        /// <remarks>
        /// <br>Note       : 画面情報から、保存データを取得します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date	   : 2008/10/03</br>
        /// </remarks>
        private Dictionary<string, CustRateGroup> GetSaveCustRateGroupDicFromScreen()
        {
            // --- ADD m.suzuki 2010/07/15 ---------->>>>>
            // ※純正が全て未入力状態でないか、事前に確認する。
            bool pureSettingByMakerExists = false;

            # region [pureSettingByMakerExists]
            // rowIndex = 0 は純正ALLなので除外。
            for ( int rowIndex = 1; rowIndex < this._custRateGroup_Grid[0].Rows.Count; rowIndex++ )
            {
                CellsCollection cells = this._custRateGroup_Grid[0].Rows[rowIndex].Cells;

                if ( (cells[COLUMN_CUSTRATEGROUP].Value == DBNull.Value) ||
                    (((string)cells[COLUMN_CUSTRATEGROUP].Value).Trim() == "") )
                {
                }
                else
                {
                    // メーカー別設定が入力されている。
                    pureSettingByMakerExists = true;
                    break;
                }
            }
            # endregion
            // --- ADD m.suzuki 2010/07/15 ----------<<<<<

            Dictionary<string, CustRateGroup> custRateGroupDic = new Dictionary<string, CustRateGroup>();

            for (int index = 0; index < this._custRateGroup_Grid.Length; index++)
            {
                for (int rowIndex = 0; rowIndex < this._custRateGroup_Grid[index].Rows.Count; rowIndex++)
                {
                    CellsCollection cells = this._custRateGroup_Grid[index].Rows[rowIndex].Cells;

                    // DEL 2009/11/19 3次分対応 得意先掛率グループ改良 ---------->>>>>
                    // MEMO:得意先掛率グループコードが空白の場合
                    //if ((cells[COLUMN_CUSTRATEGROUP].Value == DBNull.Value) || 
                    //    (((string)cells[COLUMN_CUSTRATEGROUP].Value).Trim() == "") ||
                    //    (((string)cells[COLUMN_CUSTRATEGROUP].Value).Trim() == "0000"))
                    //{
                    //    continue;
                    //}
                    // DEL 2009/11/19 3次分対応 得意先掛率グループ改良 ----------<<<<<
                    // ADD 2009/11/19 3次分対応 得意先掛率グループ改良 ---------->>>>>
                    if ((cells[COLUMN_CUSTRATEGROUP].Value == DBNull.Value) ||
                        (((string)cells[COLUMN_CUSTRATEGROUP].Value).Trim() == ""))
                    {
                        // DEL 2009/12/15 3次分対応 得意先掛率グループ改良(追加):得意先掛率グループコード=-1をDB登録する ---------->>>>>
                        //continue;
                        // DEL 2009/12/15 3次分対応 得意先掛率グループ改良(追加):得意先掛率グループコード=-1をDB登録する ----------<<<<<
                        // ADD 2009/12/15 3次分対応 得意先掛率グループ改良(追加):得意先掛率グループコード=-1をDB登録する ---------->>>>>
                        // FIXME:未設定(得意先掛率グループコード=-1)もDB登録する
                        if ((cells[COLUMN_CUSTRATEGROUP].Value == DBNull.Value))
                        {
                            cells[COLUMN_CUSTRATEGROUP].Value = string.Empty;
                        }
                        // ADD 2009/12/15 3次分対応 得意先掛率グループ改良(追加):得意先掛率グループコード=-1をDB登録する ----------<<<<<
                    }
                    // ADD 2009/11/19 3次分対応 得意先掛率グループ改良 ----------<<<<<

                    CustRateGroup custRateGroup = new CustRateGroup();

                    // 企業コード
                    custRateGroup.EnterpriseCode = this._enterpriseCode;
                    // 得意先コード
                    custRateGroup.CustomerCode = this.tNedit_CustomerCode.GetInt();
                    // 純正区分
                    //if (index == 2)
                    if (index == 1)
                    {
                        // 優良
                        custRateGroup.PureCode = 1;
                    }
                    else
                    {
                        // 純正
                        custRateGroup.PureCode = 0;
                    }
                    // メーカーコード
                    custRateGroup.GoodsMakerCd = int.Parse((string)cells[COLUMN_MAKERCODE].Value);

                    // DEL 2009/11/19 3次分対応 得意先掛率グループ改良 ---------->>>>>
                    //custRateGroup.CustRateGrpCode = int.Parse((string)cells[COLUMN_CUSTRATEGROUP].Value);
                    // DEL 2009/11/19 3次分対応 得意先掛率グループ改良 ----------<<<<<
                    // ADD 2009/11/19 3次分対応 得意先掛率グループ改良 ---------->>>>>
                    // FIXME:登録する得意先掛率グループコードを設定　※未設定(得意先掛率グループコード=-1)もDB登録する
                    Debug.WriteLine(((string)cells[COLUMN_CUSTRATEGROUP].Value).Trim());
                    if (!string.IsNullOrEmpty(((string)cells[COLUMN_CUSTRATEGROUP].Value).Trim()))
                    {
                        custRateGroup.CustRateGrpCode = int.Parse((string)cells[COLUMN_CUSTRATEGROUP].Value);
                    }
                    else
                    {
                        // --- UPD m.suzuki 2010/07/15 ---------->>>>>
                        //custRateGroup.CustRateGrpCode = NULL_CODE;
                        if ( custRateGroup.PureCode == 0 )
                        {
                            // 純正
                            if ( pureSettingByMakerExists )
                            {
                                // メーカー別設定の場合
                                if ( rowIndex == 0 )
                                {
                                    // 純正ALLかつGRコード=-1のレコードを作成しない。
                                    continue;
                                }
                            }
                            else
                            {
                                // 純正ALLのみ
                                if ( rowIndex != 0 )
                                {
                                    // メーカー別設定かつGRコード=-1のレコードを作成しない。
                                    continue;
                                }
                            }
                            custRateGroup.CustRateGrpCode = NULL_CODE;
                        }
                        else
                        {
                            // 優良⇒優良ALLのみなので、-1のレコードも作成する。
                            custRateGroup.CustRateGrpCode = NULL_CODE;
                        }
                        // --- UPD m.suzuki 2010/07/15 ----------<<<<<
                    }
                    // ADD 2009/11/19 3次分対応 得意先掛率グループ改良 ----------<<<<<

                    custRateGroupDic.Add(GetKey(custRateGroup), custRateGroup);
                }
            }

            return custRateGroupDic;
        }

        /// <summary>
        /// 更新用リスト取得処理
        /// </summary>
        /// <param name="saveList">保存リスト</param>
        /// <param name="deleteList">削除リスト</param>
        /// <remarks>
        /// <br>Note       : 画面情報から、保存リスト・削除リストを取得します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date	   : 2008/10/03</br>
        /// </remarks>
        private void GetUpdateList(out ArrayList saveList, out ArrayList deleteList)
        {
            saveList = new ArrayList();
            deleteList = new ArrayList();

            // 保存用データ取得
            Dictionary<string, CustRateGroup> saveCustRateGroupDic = GetSaveCustRateGroupDicFromScreen();

            // 削除リスト作成
            foreach (CustRateGroup custRateGroup in this._custRateGroupListClone)
            {
                deleteList.Add(custRateGroup.Clone());
            }

            // 保存リスト作成
            foreach (CustRateGroup custRateGroup in saveCustRateGroupDic.Values)
            {
                saveList.Add(custRateGroup);
            }
        }

        /// <summary>
        /// Key取得処理
        /// </summary>
        /// <param name="custRateGroup">得意先マスタ(掛率グループ)マスタ</param>
        /// <returns>Key</returns>
        /// <remarks>
        /// <br>Note       : 得意先マスタ(掛率グループ)からKeyを取得します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date	   : 2008/10/03</br>
        /// </remarks>
        private string GetKey(CustRateGroup custRateGroup)
        {
            string key = "";

            // 得意先コード(8桁)＋メーカーコード(4桁)＋純正区分(2桁)
            key = custRateGroup.CustomerCode.ToString("00000000") + custRateGroup.GoodsMakerCd.ToString("0000") +
                  custRateGroup.PureCode.ToString("00");

            return key;
        }

        /// <summary>
        /// 保存処理
        /// </summary>
        /// <returns>ステータス(True:成功 False:失敗)</returns>
        /// <remarks>
        /// <br>Note       : 保存処理を行います。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date	   : 2008/10/03</br>
        /// </remarks>
        private bool SaveProc()
        {
            // 入力チェック
            bool bStatus = CheckScreenInput();
            if (!bStatus)
            {
                return (false);
            }

            bool allNullFlg = false;
            for (int index = 0; index < this._custRateGroup_Grid.Length; index++)
            {
                for (int rowIndex = 0; rowIndex < this._custRateGroup_Grid[index].Rows.Count; rowIndex++)
                {
                    CellsCollection cells = this._custRateGroup_Grid[index].Rows[rowIndex].Cells;

                    // DEL 2009/11/19 3次分対応 得意先掛率グループ改良 ---------->>>>>
                    //if ((cells[COLUMN_CUSTRATEGROUP].Value != DBNull.Value) &&
                    //    (((string)cells[COLUMN_CUSTRATEGROUP].Value).Trim() != ""))
                    // DEL 2009/11/19 3次分対応 得意先掛率グループ改良 ----------<<<<<
                    // ADD 2009/11/19 3次分対応 得意先掛率グループ改良 ---------->>>>>
                    // MEMO:全て未設定であるか判定
                    if (cells[COLUMN_CUSTRATEGROUP].Value != DBNull.Value)
                    // ADD 2009/11/19 3次分対応 得意先掛率グループ改良 ----------<<<<<
                    {
                        // DEL 2009/11/19 3次分対応 得意先掛率グループ改良 ---------->>>>>
                        //if (int.Parse((string)cells[COLUMN_CUSTRATEGROUP].Value) == 0)
                        // DEL 2009/11/19 3次分対応 得意先掛率グループ改良 ----------<<<<<
                        // ADD 2009/11/19 3次分対応 得意先掛率グループ改良 ---------->>>>>
                        if (string.IsNullOrEmpty((string)cells[COLUMN_CUSTRATEGROUP].Value))
                        // ADD 2009/11/19 3次分対応 得意先掛率グループ改良 ----------<<<<<
                        {
                            allNullFlg = true;
                        }
                        else
                        {
                            allNullFlg = false;
                            break;
                        }
                    }
                }

                if (!allNullFlg)
                {
                    break;
                }
            }

            ArrayList saveList;
            ArrayList deleteList;

            // 更新用データ取得
            GetUpdateList(out saveList, out deleteList);

            int status;

            if (deleteList.Count > 0)
            {
                // 削除処理
                status = this._custRateGroupAcs.Delete(deleteList);
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                        // 排他処理
                        ExclusiveTransaction(status);
                        return (false);
                    default:
                        ShowMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP,
                                       "SaveProc",
                                       "登録に失敗しました。",
                                       status,
                                       MessageBoxButtons.OK);
                        return (false);
                }
            }

            // TODO:保存処理
            if (!allNullFlg)
            {
                status = this._custRateGroupAcs.Write(ref saveList);
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        {
                            int totalCount = 0;

                            // 再検索
                            Search(ref totalCount, 0);
                            break;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE:
                        {
                            ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                                           "この拠点コードは既に使用されています。",
                                           status,
                                           MessageBoxButtons.OK,
                                           MessageBoxDefaultButton.Button1);

                            this.tNedit_CustomerCode.Focus();

                            return (false);
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
            else
            {
                int totalCount = 0;

                // 再検索
                Search(ref totalCount, 0);
            }

            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
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

            return (true);
        }

        /// <summary>
        /// 物理削除処理
        /// </summary>
        /// <returns>ステータス(True:成功 False:失敗)</returns>
        /// <remarks>
        /// <br>Note       : 物理削除処理を行います。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date	   : 2008/10/03</br>
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
            foreach (CustRateGroup custRateGroup in this._custRateGroupListClone)
            {
                deleteList.Add(custRateGroup.Clone());
            }

            // 削除処理
            int status = this._custRateGroupAcs.Delete(deleteList);
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
                        // 排他処理
                        ExclusiveTransaction(status);
                        return (false);
                    }
                default:
                    {
                        ShowMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP,
                                       "DeleteProc",
                                       "削除に失敗しました。",
                                       status,
                                       MessageBoxButtons.OK);
                        return (false);
                    }
            }

            return (true);
        }

        /// <summary>
        /// 論理削除処理
        /// </summary>
        /// <returns>ステータス(True:成功 False:失敗)</returns>
        /// <remarks>
        /// <br>Note       : 論理削除処理を行います。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date	   : 2008/10/03</br>
        /// </remarks>
        private bool LogicalDeleteProc()
        {
            // DataSetから拠点コードを取得
            int customerCode = int.Parse((string)this.Bind_DataSet.Tables[TABLE_MAIN].Rows[this._mainDataIndex][VIEW_CUSTOMERCODE]);

            // 拠点コードでインスタンスリストから該当データを取得
            List<CustRateGroup> custRateGroupList = this._detailList.FindAll(delegate(CustRateGroup x)
            {
                if (x.CustomerCode == customerCode)
                {
                    return (true);
                }
                else
                {
                    return (false);
                }
            });

            if (custRateGroupList.Count == 0)
            {
                ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                               "削除対象データが存在しません。",
                               0,
                               MessageBoxButtons.OK,
                               MessageBoxDefaultButton.Button1);

                return (true);
            }

            if (custRateGroupList[0].LogicalDeleteCode != 0)
            {
                ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                               "選択中のデータは既に削除されています。",
                               0,
                               MessageBoxButtons.OK,
                               MessageBoxDefaultButton.Button1);
                return (true);
            }

            ArrayList logicalList = new ArrayList();
            foreach (CustRateGroup custRateGroup in custRateGroupList)
            {
                logicalList.Add(custRateGroup.Clone());
            }

            // 論理削除処理
            int status = this._custRateGroupAcs.LogicalDelete(ref logicalList);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        //int index = 0;
                        //string key;

                        //foreach (CustRateGroup custRateGroup in logicalList)
                        //{
                        //    key = GetKey(custRateGroup);
                        //    int listIndex = this._detailList.FindIndex(delegate(CustRateGroup x)
                        //    {
                        //        string key2 = GetKey(x);

                        //        if (key == key2)
                        //        {
                        //            return (true);
                        //        }
                        //        else
                        //        {
                        //            return (false);
                        //        }
                        //    });

                        //    if (listIndex >= 0)
                        //    {
                        //        // バッファ更新
                        //        this._detailList[listIndex] = custRateGroup.Clone();
                        //    }

                        //    // DataSet展開
                        //    DetailToDataSet(custRateGroup, index);
                        //    index++;
                        //}

                        int totalCount = 0;

                        // 再検索
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
                        ShowMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP,
                                       "LogicalDeleteProc",
                                       "論理削除に失敗しました。",
                                       status,
                                       MessageBoxButtons.OK);
                        break;
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
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date	   : 2008/10/03</br>
        /// </remarks>
        private bool RevivalProc()
        {
            // 復活リスト取得
            ArrayList reviveList = new ArrayList();
            foreach (CustRateGroup custRateGroup in this._custRateGroupListClone)
            {
                reviveList.Add(custRateGroup.Clone());
            }

            // 復活処理
            int status = this._custRateGroupAcs.Revival(ref reviveList);
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
        /// 入力情報チェック処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 入力情報のチェックを行います。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date	   : 2008/10/03</br>
        /// </remarks>
        private bool CheckScreenInput()
        {
            string errMsg = "";

            try
            {
                // 得意先コード
                if (this.tNedit_CustomerCode.GetInt() == 0)
                {
                    errMsg = "得意先コードを入力してください。";
                    this.tNedit_CustomerCode.Focus();
                    return (false);
                }
                int customerCode = this.tNedit_CustomerCode.GetInt();
                if (GetCustomerName(customerCode) == "")
                {
                    errMsg = "マスタに登録されていません。";
                    this.tNedit_CustomerCode.Focus();
                    return (false);
                }
                if (this.Mode_Label.Text == INSERT_MODE)
                {
                    foreach (CustRateGroup custRateGroup in this._detailList)
                    {
                        if (custRateGroup.CustomerCode == customerCode)
                        {
                            errMsg = "この得意先コードは既に使用されています。";
                            this.tNedit_CustomerCode.Focus();
                            return (false);
                        }
                    }
                }

                // 得意先掛率グループコード
                bool inputFlg = false;

                for (int index = 0; index < this._custRateGroup_Grid.Length; index++)
                {
                    this._custRateGroup_Grid[index].AfterCellUpdate -= uGrid_CustRateGroup_AfterCellUpdate;
                    this._cellUpdateFlg = true;
                    this._custRateGroup_Grid[index].ActiveCell = null;
                    this._custRateGroup_Grid[index].AfterCellUpdate += uGrid_CustRateGroup_AfterCellUpdate;
                    this._cellUpdateFlg = false;

                    for (int rowIndex = 0; rowIndex < this._custRateGroup_Grid[index].Rows.Count; rowIndex++)
                    {
                        CellsCollection cells = this._custRateGroup_Grid[index].Rows[rowIndex].Cells;

                        // 得意先掛率グループコードが空白の場合
                        if ((cells[COLUMN_CUSTRATEGROUP].Value == DBNull.Value) ||
                            (((string)cells[COLUMN_CUSTRATEGROUP].Value).Trim() == ""))
                        {
                            continue;
                        }
                        
                        inputFlg = true;
                        break;
                    }
                }

                // 得意先掛率グループコードが1件も入力されていなかった場合
                if (inputFlg == false)
                {
                    errMsg = "得意先掛率ｸﾞﾙｰﾌﾟの登録がありません。";
                    this._custRateGroup_Grid[0].Focus();
                    this._custRateGroup_Grid[0].Rows[0].Cells[COLUMN_CUSTRATEGROUP].Activate();
                    this._custRateGroup_Grid[0].PerformAction(UltraGridAction.EnterEditMode);
                    return (false);
                }

                for (int index = 0; index < this._custRateGroup_Grid.Length; index++)
                {
                    for (int rowIndex = 0; rowIndex < this._custRateGroup_Grid[index].Rows.Count; rowIndex++)
                    {
                        CellsCollection cells = this._custRateGroup_Grid[index].Rows[rowIndex].Cells;

                        // 得意先掛率グループコードが空白の場合
                        if ((cells[COLUMN_CUSTRATEGROUP].Value == DBNull.Value) ||
                            (((string)cells[COLUMN_CUSTRATEGROUP].Value).Trim() == ""))
                        {
                            continue;
                        }

                        // DEL 2009/11/19 3次分対応 得意先掛率グループ改良 ---------->>>>>
                        // int custRateGrpCode = int.Parse((string)cells[COLUMN_CUSTRATEGROUP].Value);
                        // DEL 2009/11/19 3次分対応 得意先掛率グループ改良 ----------<<<<<
                        // ADD 2009/11/19 3次分対応 得意先掛率グループ改良 ---------->>>>>
                        int custRateGrpCode = NULL_CODE;
                        if (!string.IsNullOrEmpty((string)cells[COLUMN_CUSTRATEGROUP].Value))
                        {
                            custRateGrpCode = int.Parse((string)cells[COLUMN_CUSTRATEGROUP].Value);
                        }
                        // ADD 2009/11/19 3次分対応 得意先掛率グループ改良 ----------<<<<<

                        if (GetCustRateGrpName(custRateGrpCode) == "")
                        {
                            errMsg = "マスタに登録されていません。";
                            this._custRateGroup_Grid[index].AfterCellUpdate -= uGrid_CustRateGroup_AfterCellUpdate;
                            this._cellUpdateFlg = true;
                            this._custRateGroup_Grid[index].Rows[rowIndex].Cells[COLUMN_CUSTRATEGROUP].Value = DBNull.Value;
                            this._custRateGroup_Grid[index].Rows[rowIndex].Cells[COLUMN_CUSTRATEGROUP].Activate();
                            this._custRateGroup_Grid[index].PerformAction(UltraGridAction.EnterEditMode);
                            this._custRateGroup_Grid[index].AfterCellUpdate += uGrid_CustRateGroup_AfterCellUpdate;
                            this._cellUpdateFlg = false;
                            return (false);
                        }
                    }
                }
            }
            finally
            {
                if (errMsg.Length > 0)
                {
                    ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                                   errMsg,
                                   -1,
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
        /// <br>Note       : 画面読込時と画面終了時のデータを比較します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date	   : 2008/10/03</br>
        /// </remarks>
        private bool CompareOriginalScreen()
        {
            // 新規読込時に得意先コードが入力されていた場合
            if ((this._custRateGroupListClone.Count == 0) && (this.Mode_Label.Text == INSERT_MODE))
            {
                if (this.tNedit_CustomerCode.GetInt() != 0)
                {
                    return (false);
                }
            }

            // 保存データ取得
            Dictionary<string, CustRateGroup> saveCustRateGroupDic = GetSaveCustRateGroupDicFromScreen();

            // 画面読込時と保存データの件数が違う場合
            if (this._custRateGroupListClone.Count != saveCustRateGroupDic.Values.Count)
            {
                return (false);
            }

            string key;
            foreach (CustRateGroup custRateGroup in this._custRateGroupListClone)
            {
                // Key取得
                key = GetKey(custRateGroup);

                // 画面読込時のデータが無い場合
                if (!saveCustRateGroupDic.ContainsKey(key))
                {
                    return (false);
                }
            }

            return (true);
        }

        /// <summary>
        /// 排他処理
        /// </summary>
        /// <param name="status">STATUS</param>
        /// <remarks>
        /// <br>Note       : 排他処理を行います</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/10/03</br>
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
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/10/03</br>
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
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/10/03</br>
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
                                         this._custRateGroupAcs,			// エラーが発生したオブジェクト
                                         msgButton,         			  	// 表示するボタン
                                         MessageBoxDefaultButton.Button1);	// 初期表示ボタン

            return dialogResult;
        }

        /// <summary>
        /// NextFocus 設定処理
        /// </summary>
        /// <param name="uGrid">対象グリッド</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : グリッド内でEnterキーが押下された時のNextFocus設定を行います。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date	   : 2008/10/03</br>
        /// </remarks>
        private void SetNextFocus(UltraGrid uGrid, ref ChangeFocusEventArgs e)
        {
            int rowIndex;
            int columnIndex;

            if (uGrid.ActiveCell == null)
            {
                if (uGrid.ActiveRow == null)
                {
                    e.NextCtrl = null;
                    uGrid.Focus();
                    uGrid.Rows[0].Cells[COLUMN_CUSTRATEGROUP].Activate();
                    uGrid.PerformAction(UltraGridAction.EnterEditMode);
                    return;
                }
                else
                {
                    rowIndex = uGrid.ActiveRow.Index;
                    columnIndex = 2;
                }
            }
            else
            {
                rowIndex = uGrid.ActiveCell.Row.Index;
                columnIndex = uGrid.ActiveCell.Column.Index;
            }

            e.NextCtrl = null;

            int gridIndex = (int)uGrid.Tag;
            switch (gridIndex)
            {
                case 0:
                    {
                        if ((uGrid.ActiveCell.Column.Key == COLUMN_CUSTRATEGROUP) && (uGrid.ActiveCell.Text.Trim() == ""))
                        {
                            // 掛率Gコードが空白の場合、ガイドボタンへ遷移
                            uGrid.Focus();
                            uGrid.Rows[rowIndex].Cells[COLUMN_CUSTRATEGROUPBUTTON].Activate();
                        }
                        else
                        {
                            if (rowIndex == 0)
                            {
                                // DEL 2009/11/19 3次分対応 得意先掛率グループ改良 ---------->>>>>
                                //if ((uGrid.ActiveCell.Text.Trim() == "") || (int.Parse(uGrid.ActiveCell.Text.Trim()) == 0))
                                // DEL 2009/11/19 3次分対応 得意先掛率グループ改良 ----------<<<<<
                                // ADD 2009/11/19 3次分対応 得意先掛率グループ改良 ---------->>>>>
                                // MEMO:先頭行(純正ALL)が未設定時のフォーカス遷移
                                if ((uGrid.ActiveCell.Text.Trim() == ""))
                                // ADD 2009/11/19 3次分対応 得意先掛率グループ改良 ----------<<<<<
                                {
                                    uGrid.Focus();
                                    uGrid.Rows[rowIndex + 1].Cells[COLUMN_CUSTRATEGROUP].Activate();
                                    uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                }
                                else
                                {
                                    //this._custRateGroup_Grid[2].Focus();
                                    //this._custRateGroup_Grid[2].Rows[0].Cells[COLUMN_CUSTRATEGROUP].Activate();
                                    //this._custRateGroup_Grid[2].PerformAction(UltraGridAction.EnterEditMode);
                                    this._custRateGroup_Grid[1].Focus();
                                    this._custRateGroup_Grid[1].Rows[0].Cells[COLUMN_CUSTRATEGROUP].Activate();
                                    this._custRateGroup_Grid[1].PerformAction(UltraGridAction.EnterEditMode);
                                }
                            }
                            else if (rowIndex == 25)
                            {
                                this._custRateGroup_Grid[gridIndex + 1].Focus();
                                this._custRateGroup_Grid[gridIndex + 1].Rows[0].Cells[COLUMN_CUSTRATEGROUP].Activate();
                                this._custRateGroup_Grid[gridIndex + 1].PerformAction(UltraGridAction.EnterEditMode);
                            }
                            else
                            {
                                uGrid.Focus();
                                uGrid.Rows[rowIndex + 1].Cells[COLUMN_CUSTRATEGROUP].Activate();
                                uGrid.PerformAction(UltraGridAction.EnterEditMode);
                            }
                        }
                        break;
                    }
                //case 1:
                //    {
                //        if (rowIndex == 12)
                //        {
                //            this._custRateGroup_Grid[gridIndex + 1].Focus();
                //            this._custRateGroup_Grid[gridIndex + 1].Rows[0].Cells[COLUMN_CUSTRATEGROUP].Activate();
                //            this._custRateGroup_Grid[gridIndex + 1].PerformAction(UltraGridAction.EnterEditMode);
                //        }
                //        else
                //        {
                //            uGrid.Focus();
                //            uGrid.Rows[rowIndex + 1].Cells[COLUMN_CUSTRATEGROUP].Activate();
                //            uGrid.PerformAction(UltraGridAction.EnterEditMode);
                //        }
                //        break;
                //    }
                //case 2:
                case 1:
                    {
                        if ((uGrid.ActiveCell.Column.Key == COLUMN_CUSTRATEGROUP) && (uGrid.ActiveCell.Text.Trim() == ""))
                        {
                            // 掛率Gコードが空白の場合、ガイドボタンへ遷移
                            uGrid.Focus();
                            uGrid.Rows[rowIndex].Cells[COLUMN_CUSTRATEGROUPBUTTON].Activate();
                        }
                        else
                        {
                            // 優良
                            this.Renewal_Button.Focus();
                        }
                        break;
                    }
            }
        }

        /// <summary>
        /// BeforeFocus 設定処理
        /// </summary>
        /// <param name="uGrid">対象グリッド</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : グリッド内でShift + Tabキーが押下された時のNextFocus設定を行います。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date	   : 2008/10/03</br>
        /// </remarks>
        private void SetBeforeFocus(UltraGrid uGrid, ref ChangeFocusEventArgs e)
        {
            int rowIndex;
            int columnIndex;

            if (uGrid.ActiveCell == null)
            {
                if (uGrid.ActiveRow == null)
                {
                    return;
                }
                else
                {
                    rowIndex = uGrid.ActiveRow.Index;
                    columnIndex = 0;
                }
            }
            else
            {
                rowIndex = uGrid.ActiveCell.Row.Index;
                columnIndex = uGrid.ActiveCell.Column.Index;
            }

            e.NextCtrl = null;

            int gridIndex = (int)uGrid.Tag;
            switch (gridIndex)
            {
                case 0:
                    {
                        if (rowIndex == 0)
                        {
                            if ((this.CustomerGuide_Button.Enabled) && (this.tNedit_CustomerCode.Enabled))
                            {
                                if (this.tEdit_CustomerName.DataText.Trim() == "")
                                {
                                    this.CustomerGuide_Button.Focus();
                                }
                                else
                                {
                                    this.tNedit_CustomerCode.Focus();
                                }
                            }
                            else
                            {
                                // 得意先コードとガイドボタンが無効の場合は、閉じるボタンへ遷移
                                this.Cancel_Button.Focus();
                            }
                        }
                        else
                        {
                            if ((uGrid.ActiveCell.Column.Key == COLUMN_CUSTRATEGROUP) &&
                                (uGrid.Rows[rowIndex - 1].Cells[COLUMN_CUSTRATEGROUP].Text.Trim() == ""))
                            {
                                // 掛率Gコードが空白
                                uGrid.Focus();
                                uGrid.Rows[rowIndex - 1].Cells[COLUMN_CUSTRATEGROUPBUTTON].Activate();
                            }
                            else if (uGrid.ActiveCell.Column.Key == COLUMN_CUSTRATEGROUPBUTTON)
                            {
                                uGrid.Focus();
                                uGrid.Rows[rowIndex].Cells[COLUMN_CUSTRATEGROUP].Activate();
                                uGrid.PerformAction(UltraGridAction.EnterEditMode);
                            }
                            else
                            {
                                uGrid.Focus();
                                uGrid.Rows[rowIndex - 1].Cells[COLUMN_CUSTRATEGROUP].Activate();
                                uGrid.PerformAction(UltraGridAction.EnterEditMode);
                            }
                        }
                        break;
                    }
                //case 1:
                //    {
                //        if (rowIndex == 0)
                //        {
                //            this._custRateGroup_Grid[gridIndex - 1].Focus();
                //            this._custRateGroup_Grid[gridIndex - 1].Rows[12].Cells[COLUMN_CUSTRATEGROUP].Activate();
                //            this._custRateGroup_Grid[gridIndex - 1].PerformAction(UltraGridAction.EnterEditMode);
                //        }
                //        else
                //        {
                //            uGrid.Focus();
                //            uGrid.Rows[rowIndex - 1].Cells[COLUMN_CUSTRATEGROUP].Activate();
                //            uGrid.PerformAction(UltraGridAction.EnterEditMode);
                //        }
                //        break;
                //    }
                //case 2:
                case 1:
                    {
                        if (uGrid.ActiveCell.Column.Key == COLUMN_CUSTRATEGROUP)
                        {
                            if ((this._custRateGroup_Grid[0].Rows[0].Cells[COLUMN_CUSTRATEGROUP].Value == DBNull.Value) ||
                                ((string)this._custRateGroup_Grid[0].Rows[0].Cells[COLUMN_CUSTRATEGROUP].Value == "") ||
                                (int.Parse((string)this._custRateGroup_Grid[0].Rows[0].Cells[COLUMN_CUSTRATEGROUP].Value) == 0))
                            {
                                //this._custRateGroup_Grid[gridIndex - 1].Focus();
                                //this._custRateGroup_Grid[gridIndex - 1].Rows[12].Cells[COLUMN_CUSTRATEGROUP].Activate();
                                //this._custRateGroup_Grid[gridIndex - 1].Rows[25].Cells[COLUMN_CUSTRATEGROUP].Activate();
                                //this._custRateGroup_Grid[gridIndex - 1].PerformAction(UltraGridAction.EnterEditMode);
                                this._custRateGroup_Grid[0].Focus();
                                if (this._custRateGroup_Grid[0].Rows[25].Cells[COLUMN_CUSTRATEGROUP].Text != "")
                                {
                                    this._custRateGroup_Grid[0].Rows[25].Cells[COLUMN_CUSTRATEGROUP].Activate();
                                    this._custRateGroup_Grid[0].PerformAction(UltraGridAction.EnterEditMode);
                                }
                                else
                                {
                                    // 最終行の掛率Gが空白
                                    this._custRateGroup_Grid[0].Rows[25].Cells[COLUMN_CUSTRATEGROUPBUTTON].Activate();
                                }
                            }
                            else
                            {
                                this._custRateGroup_Grid[0].Focus();
                                this._custRateGroup_Grid[0].Rows[0].Cells[COLUMN_CUSTRATEGROUP].Activate();
                                this._custRateGroup_Grid[0].PerformAction(UltraGridAction.EnterEditMode);
                            }
                        }
                        else if (uGrid.ActiveCell.Column.Key == COLUMN_CUSTRATEGROUPBUTTON)
                        {
                            uGrid.Focus();
                            uGrid.Rows[rowIndex].Cells[COLUMN_CUSTRATEGROUP].Activate();
                            uGrid.PerformAction(UltraGridAction.EnterEditMode);
                        }
                        break;
                    }
            }
        }

        /// <summary>
        /// グリッドEnabled制御処理
        /// </summary>
        /// <param name="enabledFlg">入力フラグ</param>
        /// <remarks>
        /// <br>Note       : グリッドの入力制御を行います。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date	   : 2008/10/03</br>
        /// </remarks>
        private void ChangeGridEnabled(bool enabledFlg)
        {
            if (enabledFlg == true)
            {
                // メーカーコード0001～0025に値を入力可
                for (int rowIndex = 1; rowIndex < this.uGrid_CustRateGroup1.Rows.Count; rowIndex++)
                {
                    UltraGridCell cell = this.uGrid_CustRateGroup1.Rows[rowIndex].Cells[COLUMN_CUSTRATEGROUP];
                    UltraGridCell cell2 = this.uGrid_CustRateGroup1.Rows[rowIndex].Cells[COLUMN_CUSTRATEGROUPNAME];
                    UltraGridCell cell3 = this.uGrid_CustRateGroup1.Rows[rowIndex].Cells[COLUMN_CUSTRATEGROUPBUTTON];

                    this.uGrid_CustRateGroup1.AfterCellUpdate -= uGrid_CustRateGroup_AfterCellUpdate;
                    this._cellUpdateFlg = true;

                    // DEL 2009/11/19 3次分対応 得意先掛率グループ改良 ---------->>>>>
                    //cell.Value = "0000";
                    // DEL 2009/11/19 3次分対応 得意先掛率グループ改良 ----------<<<<<
                    // ADD 2009/11/19 3次分対応 得意先掛率グループ改良 ---------->>>>>
                    // MEMO:得意先掛率グループコードを強制クリア
                    cell.Value = string.Empty;
                    // ADD 2009/11/19 3次分対応 得意先掛率グループ改良 ----------<<<<<

                    cell.Activation = Activation.AllowEdit;
                    
                    // DEL 2009/11/19 3次分対応 得意先掛率グループ改良 ---------->>>>>
                    //cell2.Value = GetCustRateGrpName(0);    // 掛率G名称
                    // DEL 2009/11/19 3次分対応 得意先掛率グループ改良 ----------<<<<<
                    // ADD 2009/11/19 3次分対応 得意先掛率グループ改良 ---------->>>>>
                    // MEMO:得意先掛率グループコード名称を強制クリア
                    cell2.Value = GetCustRateGrpName(NULL_CODE);
                    // ADD 2009/11/19 3次分対応 得意先掛率グループ改良 ----------<<<<<

                    cell3.Activation = Activation.NoEdit;   // ガイドボタン
                    this.uGrid_CustRateGroup1.AfterCellUpdate += uGrid_CustRateGroup_AfterCellUpdate;
                    this._cellUpdateFlg = false;
                }
                #region 削除コード
                //for (int rowIndex = 0; rowIndex < this.uGrid_CustRateGroup2.Rows.Count; rowIndex++)
                //{
                //    UltraGridCell cell = this.uGrid_CustRateGroup2.Rows[rowIndex].Cells[COLUMN_CUSTRATEGROUP];

                //    this.uGrid_CustRateGroup2.AfterCellUpdate -= uGrid_CustRateGroup_AfterCellUpdate;
                //    this._cellUpdateFlg = true;
                //    cell.Value = "0000";
                //    cell.Activation = Activation.AllowEdit;
                //    this.uGrid_CustRateGroup2.AfterCellUpdate += uGrid_CustRateGroup_AfterCellUpdate;
                //    this._cellUpdateFlg = false;
                //}
                #endregion
            }
            else
            {
                // メーカーコード0001～0025に値を入力不可
                for (int rowIndex = 1; rowIndex < this.uGrid_CustRateGroup1.Rows.Count; rowIndex++)
                {
                    UltraGridCell cell = this.uGrid_CustRateGroup1.Rows[rowIndex].Cells[COLUMN_CUSTRATEGROUP];
                    UltraGridCell cell2 = this.uGrid_CustRateGroup1.Rows[rowIndex].Cells[COLUMN_CUSTRATEGROUPNAME];
                    UltraGridCell cell3 = this.uGrid_CustRateGroup1.Rows[rowIndex].Cells[COLUMN_CUSTRATEGROUPBUTTON];

                    this.uGrid_CustRateGroup1.AfterCellUpdate -= uGrid_CustRateGroup_AfterCellUpdate;
                    this._cellUpdateFlg = true;
                    cell.Value = "";
                    cell.Activation = Activation.Disabled;
                    cell2.Value = "";   // 掛率G名称
                    cell3.Activation = Activation.Disabled;     // ガイドボタン
                    this.uGrid_CustRateGroup1.AfterCellUpdate += uGrid_CustRateGroup_AfterCellUpdate;
                    this._cellUpdateFlg = false;
                }
                #region 削除コード
                //for (int rowIndex = 0; rowIndex < this.uGrid_CustRateGroup2.Rows.Count; rowIndex++)
                //{
                //    UltraGridCell cell = this.uGrid_CustRateGroup2.Rows[rowIndex].Cells[COLUMN_CUSTRATEGROUP];

                //    this.uGrid_CustRateGroup2.AfterCellUpdate -= uGrid_CustRateGroup_AfterCellUpdate;
                //    this._cellUpdateFlg = true;
                //    cell.Value = "";
                //    cell.Activation = Activation.Disabled;
                //    this.uGrid_CustRateGroup2.AfterCellUpdate += uGrid_CustRateGroup_AfterCellUpdate;
                //    this._cellUpdateFlg = false;
                //}
                #endregion
            }
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
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date	   : 2008/10/03</br>
        /// </remarks>
        private void PMKHN09170UA_Load(object sender, EventArgs e)
        {
            #region 削除コード
            //// 画面初期設定
            //SetScreenInitialSetting();

            //// 画面クリア
            //ScreenClear();
            #endregion
        }

        /// <summary>
        /// FormClosing イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : フォームを閉じる前に発生します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date	   : 2008/10/03</br>
        /// </remarks>
        private void PMKHN09170UA_FormClosing(object sender, FormClosingEventArgs e)
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
        /// VisibleChanged イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : フォームの表示状態が変更した時に発生します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date	   : 2008/10/03</br>
        /// </remarks>
        private void PMKHN09170UA_VisibleChanged(object sender, EventArgs e)
        {
            // 自分自身が非表示になった場合は以下の処理をキャンセルする。
            if (this.Visible == false)
            {
                this.Owner.Activate();
                return;
            }

            // 画面クリア
            ScreenClear();

            this.Initial_Timer.Enabled = true;
        }

        /// <summary>
        /// Button_Click イベント(得意先ガイドボタン)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : 得意先ガイドボタンがクリックされた時に発生します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date	   : 2008/10/03</br>
        /// </remarks>
        private void CustomerGuide_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                this._cusotmerGuideSelected = false;

                // 得意先ガイド
                PMKHN04005UA customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_CUSTOMER_ONLY, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY);

                customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.CustomerSearchForm_CustomerSelect);
                customerSearchForm.ShowDialog(this);

                // フォーカス設定
                if (this._cusotmerGuideSelected == true)
                {
                    this.uGrid_CustRateGroup1.Focus();
                    this.uGrid_CustRateGroup1.Rows[0].Cells[COLUMN_CUSTRATEGROUP].Activate();
                    this.uGrid_CustRateGroup1.PerformAction(UltraGridAction.EnterEditMode);
                }

                // 2009.03.30 30413 犬飼 新規モードからモード変更対応 >>>>>>START
                if (this._mainDataIndex < 0)
                {
                    if (ModeChangeProc())
                    {
                        ((Control)sender).Focus();
                    }
                }
                // 2009.03.30 30413 犬飼 新規モードからモード変更対応 <<<<<<END
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
        /// <br>Note       : 得意先選択時に発生します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/10/03</br>
        /// </remarks>
        private void CustomerSearchForm_CustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        {
            if (customerSearchRet == null)
            {
                this._cusotmerGuideSelected = false;
                return;
            }

            // 得意先コード
            this.tNedit_CustomerCode.SetInt(customerSearchRet.CustomerCode);

            // 得意先名称
            this.tEdit_CustomerName.DataText = customerSearchRet.Snm.Trim();

            this._cusotmerGuideSelected = true;
        }

        /// <summary>
        /// Button_Click イベント(保存ボタン)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : 保存ボタンがクリックされた時に発生します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date	   : 2008/10/03</br>
        /// </remarks>
        private void Ok_Button_Click(object sender, EventArgs e)
        {
            // 保存処理
            SaveProc();
        }

        /// <summary>
        /// Button_Click イベント(閉じるボタン)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : 閉じるボタンがクリックされた時に発生します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date	   : 2008/10/03</br>
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
                                // 2009.03.30 30413 犬飼 新規モードからモード変更対応 >>>>>>START
                                //this.Cancel_Button.Focus();
                                if (_modeFlg)
                                {
                                    tNedit_CustomerCode.Focus();
                                    _modeFlg = false;
                                }
                                else
                                {
                                    this.Cancel_Button.Focus();
                                }
                                // 2009.03.30 30413 犬飼 新規モードからモード変更対応 <<<<<<END
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
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date	   : 2008/10/03</br>
        /// </remarks>
        private void Delete_Button_Click(object sender, EventArgs e)
        {
            // 物理削除処理
            bool bStatus = DeleteProc();
            if (!bStatus)
            {
                return;
            }

            int totalCount = 0;

            // 再検索処理
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
        }

        /// <summary>
        /// Button_Click イベント(復活ボタン)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : 復活ボタンがクリックされた時に発生します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date	   : 2008/10/03</br>
        /// </remarks>
        private void Revive_Button_Click(object sender, EventArgs e)
        {
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
        /// KeyDown イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : グリッドアクティブ時にキーが押されたタイミングで発生します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date	   : 2008/10/03</br>
        /// </remarks>
        private void uGrid_CustRateGroup_KeyDown(object sender, KeyEventArgs e)
        {
            UltraGrid uGrid = (UltraGrid)sender;

            int rowIndex;

            if (uGrid.ActiveCell == null)
            {
                if (uGrid.ActiveRow == null)
                {
                    return;
                }
                else
                {
                    rowIndex = uGrid.ActiveRow.Index;
                }
            }
            else
            {
                rowIndex = uGrid.ActiveCell.Row.Index;
            }

            // ガイドボタンの追加により処理を変更
            switch (e.KeyCode)
            {
                case Keys.Up:
                    {
                        #region 削除コード
                        //uGrid.PerformAction(UltraGridAction.ExitEditMode);
                        //e.Handled = true;

                        //if (!this._errFlg)
                        //{
                        //    if (rowIndex == 0)
                        //    {
                        //        this.tNedit_CustomerCode.Focus();
                        //    }
                        //    else
                        //    {
                        //        uGrid.Rows[rowIndex - 1].Cells[COLUMN_CUSTRATEGROUP].Activate();
                        //        uGrid.PerformAction(UltraGridAction.EnterEditMode);
                        //    }
                        //}
                        //else
                        //{
                        //    uGrid.PerformAction(UltraGridAction.EnterEditMode);
                        //    this._errFlg = false;
                        //}
                        #endregion

                        if (uGrid.ActiveCell.Column.Key == COLUMN_CUSTRATEGROUP)
                        {
                            // 掛率Gコード
                            uGrid.PerformAction(UltraGridAction.ExitEditMode);
                            e.Handled = true;

                            if (!this._errFlg)
                            {
                                if (rowIndex == 0)
                                {
                                    // 得意先コードが有効の場合は遷移する
                                    if (this.tNedit_CustomerCode.Enabled)
                                    {
                                        this.tNedit_CustomerCode.Focus();
                                    }
                                    else
                                    {
                                        uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                    }
                                }
                                else
                                {
                                    // 上行へ遷移
                                    uGrid.Rows[rowIndex - 1].Cells[COLUMN_CUSTRATEGROUP].Activate();
                                    uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                }
                            }
                            else
                            {
                                uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                this._errFlg = false;
                            }
                        }
                        else if (uGrid.ActiveCell.Column.Key == COLUMN_CUSTRATEGROUPBUTTON)
                        {
                            // ガイドボタン
                            if (!this._errFlg)
                            {
                                if (rowIndex == 0)
                                {
                                    // 得意先コードが有効の場合は遷移する
                                    if (this.tNedit_CustomerCode.Enabled)
                                    {
                                        this.tNedit_CustomerCode.Focus();
                                    }
                                    else
                                    {
                                        uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                    }
                                }
                                else
                                {
                                    // 上行へ遷移
                                    uGrid.Rows[rowIndex - 1].Cells[COLUMN_CUSTRATEGROUPBUTTON].Activate();
                                }
                            }
                            else
                            {
                                uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                this._errFlg = false;
                            }
                        }
                        break;
                    }
                case Keys.Down:
                    {
                        #region 削除コード

                        //uGrid.PerformAction(UltraGridAction.ExitEditMode);
                        //e.Handled = true;

                        //if (!this._errFlg)
                        //{
                        //    if (rowIndex == uGrid.Rows.Count - 1)
                        //    {
                        //        this.Ok_Button.Focus();
                        //    }
                        //    else
                        //    {
                        //        if (uGrid.Rows[rowIndex + 1].Cells[COLUMN_CUSTRATEGROUP].Activation == Activation.AllowEdit)
                        //        {
                        //            uGrid.Rows[rowIndex + 1].Cells[COLUMN_CUSTRATEGROUP].Activate();
                        //            uGrid.PerformAction(UltraGridAction.EnterEditMode);
                        //        }
                        //        else
                        //        {
                        //            this.Ok_Button.Focus();
                        //        }
                        //    }
                        //}
                        //else
                        //{
                        //    uGrid.PerformAction(UltraGridAction.EnterEditMode);
                        //    this._errFlg = false;
                        //}
                        #endregion

                        if (uGrid.ActiveCell.Column.Key == COLUMN_CUSTRATEGROUP)
                        {
                            // 掛率Gコード
                            uGrid.PerformAction(UltraGridAction.ExitEditMode);
                            e.Handled = true;

                            if (!this._errFlg)
                            {
                                if (rowIndex == uGrid.Rows.Count - 1)
                                {
                                    // 最新情報ボタンへ遷移
                                    this.Renewal_Button.Focus();
                                }
                                else
                                {
                                    if (uGrid.Rows[rowIndex + 1].Cells[COLUMN_CUSTRATEGROUP].Activation == Activation.AllowEdit)
                                    {
                                        // 下行へ遷移
                                        uGrid.Rows[rowIndex + 1].Cells[COLUMN_CUSTRATEGROUP].Activate();
                                        uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                    }
                                    else
                                    {
                                        // 最新情報ボタンへ遷移
                                        this.Renewal_Button.Focus();
                                    }
                                }
                            }
                            else
                            {
                                uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                this._errFlg = false;
                            }
                        }
                        else if (uGrid.ActiveCell.Column.Key == COLUMN_CUSTRATEGROUPBUTTON)
                        {
                            // ガイドボタン
                            if (!this._errFlg)
                            {
                                if (rowIndex == uGrid.Rows.Count - 1)
                                {
                                    // 最新情報ボタンへ遷移
                                    this.Renewal_Button.Focus();
                                }
                                else
                                {
                                    if (uGrid.Rows[rowIndex + 1].Cells[COLUMN_CUSTRATEGROUP].Activation == Activation.AllowEdit)
                                    {
                                        // 下行へ遷移
                                        uGrid.Rows[rowIndex + 1].Cells[COLUMN_CUSTRATEGROUPBUTTON].Activate();
                                    }
                                    else
                                    {
                                        // 最新情報ボタンへ遷移
                                        this.Renewal_Button.Focus();
                                    }
                                }
                            }
                            else
                            {
                                uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                this._errFlg = false;
                            }
                        }
                        break;
                    }
                case Keys.Left:
                    {
                        #region 削除コード
                        //if (uGrid.ActiveCell.SelStart == 0)
                        //{
                        //    int gridIndex = (int)uGrid.Tag;

                        //    uGrid.PerformAction(UltraGridAction.ExitEditMode);
                        //    e.Handled = true;

                        //    if (!this._errFlg)
                        //    {
                        //        if (gridIndex != 0)
                        //        {
                        //            if (this._custRateGroup_Grid[gridIndex - 1].Rows[rowIndex].Cells[COLUMN_CUSTRATEGROUP].Activation == Activation.AllowEdit)
                        //            {
                        //                this._custRateGroup_Grid[gridIndex - 1].Focus();
                        //                this._custRateGroup_Grid[gridIndex - 1].Rows[rowIndex].Cells[COLUMN_CUSTRATEGROUP].Activate();
                        //                this._custRateGroup_Grid[gridIndex - 1].PerformAction(UltraGridAction.EnterEditMode);
                        //            }
                        //            else
                        //            {
                        //                this._custRateGroup_Grid[0].Focus();
                        //                this._custRateGroup_Grid[0].Rows[rowIndex].Cells[COLUMN_CUSTRATEGROUP].Activate();
                        //                this._custRateGroup_Grid[0].PerformAction(UltraGridAction.EnterEditMode);
                        //            }
                        //        }
                        //    }
                        //    else
                        //    {
                        //        uGrid.PerformAction(UltraGridAction.EnterEditMode);
                        //        this._errFlg = false;
                        //    }
                        //}
                        #endregion

                        if (uGrid.ActiveCell.Column.Key == COLUMN_CUSTRATEGROUP)
                        {
                            // 掛率Gコード
                            if (uGrid.ActiveCell.SelStart == 0)
                            {
                                int gridIndex = (int)uGrid.Tag;

                                uGrid.PerformAction(UltraGridAction.ExitEditMode);
                                e.Handled = true;

                                if (!this._errFlg)
                                {
                                    if (gridIndex != 0)
                                    {
                                        // 純正のガイドボタンへ遷移
                                        this._custRateGroup_Grid[gridIndex - 1].Focus();
                                        this._custRateGroup_Grid[gridIndex - 1].Rows[rowIndex].Cells[COLUMN_CUSTRATEGROUPBUTTON].Activate();
                                    }
                                    else
                                    {
                                        uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                    }
                                }
                                else
                                {
                                    uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                    this._errFlg = false;
                                }
                            }
                        }
                        else if (uGrid.ActiveCell.Column.Key == COLUMN_CUSTRATEGROUPBUTTON)
                        {
                            // ガイドボタン
                            int gridIndex = (int)uGrid.Tag;

                            if (!this._errFlg)
                            {
                                if (gridIndex != 0)
                                {
                                    if (this._custRateGroup_Grid[gridIndex].Rows[rowIndex].Cells[COLUMN_CUSTRATEGROUP].Activation == Activation.AllowEdit)
                                    {
                                        // 掛率Gコードへ遷移
                                        this._custRateGroup_Grid[gridIndex].Focus();
                                        this._custRateGroup_Grid[gridIndex].Rows[rowIndex].Cells[COLUMN_CUSTRATEGROUP].Activate();
                                        this._custRateGroup_Grid[gridIndex].PerformAction(UltraGridAction.EnterEditMode);
                                    }
                                    else
                                    {
                                        // 掛率Gコードへ遷移
                                        this._custRateGroup_Grid[0].Focus();
                                        this._custRateGroup_Grid[0].Rows[rowIndex].Cells[COLUMN_CUSTRATEGROUP].Activate();
                                        this._custRateGroup_Grid[0].PerformAction(UltraGridAction.EnterEditMode);
                                    }
                                }
                                else
                                {
                                    this._custRateGroup_Grid[0].Focus();
                                    this._custRateGroup_Grid[0].Rows[rowIndex].Cells[COLUMN_CUSTRATEGROUP].Activate();
                                    this._custRateGroup_Grid[0].PerformAction(UltraGridAction.EnterEditMode);
                                }
                            }
                            else
                            {
                                //uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                uGrid.ActiveCell.Activate();
                                this._errFlg = false;
                            }
                        }
                        break;
                    }
                case Keys.Right:
                    {
                        #region 削除コード
                        //if (uGrid.ActiveCell.SelStart >= uGrid.ActiveCell.Text.Length)
                        //{
                        //    int gridIndex = (int)uGrid.Tag;

                        //    uGrid.PerformAction(UltraGridAction.ExitEditMode);
                        //    e.Handled = true;

                        //    if (!this._errFlg)
                        //    {
                        //        switch (gridIndex)
                        //        {
                        //            case 0:
                        //                {
                        //                    if (this._custRateGroup_Grid[gridIndex + 1].Rows[rowIndex].Cells[COLUMN_CUSTRATEGROUP].Activation == Activation.AllowEdit)
                        //                    {
                        //                        this._custRateGroup_Grid[gridIndex + 1].Focus();
                        //                        this._custRateGroup_Grid[gridIndex + 1].Rows[rowIndex].Cells[COLUMN_CUSTRATEGROUP].Activate();
                        //                        this._custRateGroup_Grid[gridIndex + 1].PerformAction(UltraGridAction.EnterEditMode);
                        //                    }
                        //                    else
                        //                    {
                        //                        this._custRateGroup_Grid[2].Focus();
                        //                        this._custRateGroup_Grid[2].Rows[0].Cells[COLUMN_CUSTRATEGROUP].Activate();
                        //                        this._custRateGroup_Grid[2].PerformAction(UltraGridAction.EnterEditMode);
                        //                    }
                        //                    break;
                        //                }
                        //            case 1:
                        //                {
                        //                    this._custRateGroup_Grid[gridIndex + 1].Focus();
                        //                    this._custRateGroup_Grid[gridIndex + 1].Rows[0].Cells[COLUMN_CUSTRATEGROUP].Activate();
                        //                    this._custRateGroup_Grid[gridIndex + 1].PerformAction(UltraGridAction.EnterEditMode);
                        //                    break;
                        //                }
                        //            default:
                        //                {
                        //                    break;
                        //                }
                        //        }
                        //    }
                        //    else
                        //    {
                        //        uGrid.PerformAction(UltraGridAction.EnterEditMode);
                        //        this._errFlg = false;
                        //    }
                        //}
                        #endregion

                        if (uGrid.ActiveCell.Column.Key == COLUMN_CUSTRATEGROUP)
                        {
                            //　掛率Gコード
                            if (uGrid.ActiveCell.SelStart >= uGrid.ActiveCell.Text.Length)
                            {
                                int gridIndex = (int)uGrid.Tag;

                                uGrid.PerformAction(UltraGridAction.ExitEditMode);
                                e.Handled = true;

                                if (!this._errFlg)
                                {
                                    // ガイドボタンへ遷移
                                    this._custRateGroup_Grid[gridIndex].Focus();
                                    this._custRateGroup_Grid[gridIndex].Rows[rowIndex].Cells[COLUMN_CUSTRATEGROUPBUTTON].Activate();
                                }
                                else
                                {
                                    uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                }
                            }
                        }
                        else if (uGrid.ActiveCell.Column.Key == COLUMN_CUSTRATEGROUPBUTTON)
                        {
                            // ガイドボタン
                            int gridIndex = (int)uGrid.Tag;

                            if (!this._errFlg)
                            {
                                switch (gridIndex)
                                {
                                    case 0:
                                        {
                                            if (this._custRateGroup_Grid[gridIndex + 1].Rows[0].Cells[COLUMN_CUSTRATEGROUP].Activation == Activation.AllowEdit)
                                            {
                                                // 掛率Gコードへ遷移
                                                this._custRateGroup_Grid[gridIndex + 1].Focus();
                                                this._custRateGroup_Grid[gridIndex + 1].Rows[0].Cells[COLUMN_CUSTRATEGROUP].Activate();
                                                this._custRateGroup_Grid[gridIndex + 1].PerformAction(UltraGridAction.EnterEditMode);
                                            }
                                            break;
                                        }
                                    case 1:
                                        {
                                            // ガイドボタンへ遷移
                                            this._custRateGroup_Grid[gridIndex].Focus();
                                            this._custRateGroup_Grid[gridIndex].Rows[rowIndex].Cells[COLUMN_CUSTRATEGROUPBUTTON].Activate();
                                            break;
                                        }
                                    default:
                                        {
                                            break;
                                        }
                                }
                            }
                            else
                            {
                                //uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                this._custRateGroup_Grid[gridIndex].Focus();
                                this._custRateGroup_Grid[gridIndex].Rows[rowIndex].Cells[COLUMN_CUSTRATEGROUPBUTTON].Activate();
                                this._errFlg = false;
                            }
                        }
                        break;
                    }
                // ガイドボタンの押下
                case Keys.Space:
                    {
                        if (uGrid.ActiveCell.Column.Style == Infragistics.Win.UltraWinGrid.ColumnStyle.Button)
                        {
                            UltraGridCell ultraGridCell = uGrid.ActiveCell;
                            CellEventArgs cellEventArgs = new CellEventArgs(ultraGridCell);
                            uGrid_CustRateGroup1_ClickCellButton(sender, cellEventArgs);
                        }
                        break;
                    }
            }
        }

        /// <summary>
        /// KeyPress イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : グリッドアクティブ時にキーが押されたタイミングで発生します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date	   : 2008/10/03</br>
        /// </remarks>
        private void uGrid_CustRateGroup_KeyPress(object sender, KeyPressEventArgs e)
        {
            UltraGrid uGrid = (UltraGrid)sender;

            if (uGrid.ActiveCell == null)
            {
                return;
            }

            if (uGrid.ActiveCell.IsInEditMode)
            {
                // UI設定を参照
                if (this.uiSetControl1.CheckMatchingSet(uGrid.ActiveCell.Column.Key, e.KeyChar) == false)
                {
                    e.Handled = true;
                    return;
                }
            }
        }

        /// <summary>
        /// BeforeEnterEditMode イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : 編集モードに入る前に発生します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date	   : 2008/10/03</br>
        /// </remarks>
        private void uGrid_CustRateGroup_BeforeEnterEditMode(object sender, CancelEventArgs e)
        {
            UltraGrid uGrid = (UltraGrid)sender;

            if (uGrid.ActiveCell == null)
            {
                return;
            }

            if ((uGrid.ActiveCell.Value == DBNull.Value) || ((string)uGrid.ActiveCell.Value == ""))
            {
                // MEMO:得意先掛率グループコードのグリッドセルが""に編集された場合
                return;
            }

            int custRateGroup = int.Parse((string)uGrid.ActiveCell.Value);

            // ゼロ詰め解除
            uGrid.AfterCellUpdate -= uGrid_CustRateGroup_AfterCellUpdate;
            this._cellUpdateFlg = true;
            uGrid.ActiveCell.Value = custRateGroup.ToString();
            uGrid.AfterCellUpdate += uGrid_CustRateGroup_AfterCellUpdate;
            this._cellUpdateFlg = false;
        }

        /// <summary>
        /// AfterExitEditMode イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : 編集モードが終了した時に発生します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date	   : 2008/10/03</br>
        /// </remarks>
        private void uGrid_CustRateGroup_AfterExitEditMode(object sender, EventArgs e)
        {
            UltraGrid uGrid = (UltraGrid)sender;

            if (uGrid.ActiveCell == null)
            {
                return;
            }

            if ((uGrid.ActiveCell.Value == DBNull.Value) || ((string)uGrid.ActiveCell.Value == ""))
            {
                // MEMO:得意先掛率グループコードのグリッドセルが""に編集された場合
                return;
            }

            int custRateGroup = int.Parse((string)uGrid.ActiveCell.Value);

            // ゼロ詰め
            uGrid.AfterCellUpdate -= uGrid_CustRateGroup_AfterCellUpdate;
            this._cellUpdateFlg = true;
            uGrid.ActiveCell.Value = custRateGroup.ToString("0000");
            uGrid.ActiveCell.Row.Cells[COLUMN_CUSTRATEGROUPNAME].Value = GetCustRateGrpName(custRateGroup);     // 掛率G名称
            uGrid.AfterCellUpdate += uGrid_CustRateGroup_AfterCellUpdate;
            this._cellUpdateFlg = false;
        }

        /// <summary>
        /// AfterCellUpdate イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : セルの値が更新された時に発生します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date	   : 2008/10/03</br>
        /// </remarks>
        private void uGrid_CustRateGroup_AfterCellUpdate(object sender, CellEventArgs e)
        {
            if (this._cellUpdateFlg)
            {
                return;
            }

            UltraGrid uGrid = (UltraGrid)sender;

            if (uGrid.ActiveCell == null)
            {
                return;
            }

            if ((uGrid.ActiveCell.Value == DBNull.Value) || ((string)uGrid.ActiveCell.Value == ""))
            {
                // DEL 2009/11/19 3次分対応 得意先掛率グループ改良 ---------->>>>>
                //uGrid.ActiveCell.Row.Cells[COLUMN_CUSTRATEGROUPNAME].Value = "";
                // DEL 2009/11/19 3次分対応 得意先掛率グループ改良 ----------<<<<<
                // ADD 2009/11/19 3次分対応 得意先掛率グループ改良 ---------->>>>>
                // MEMO:得意先掛率グループコードのグリッドセルが""に編集された場合
                uGrid.ActiveCell.Row.Cells[COLUMN_CUSTRATEGROUPNAME].Value = GetCustRateGrpName(NULL_CODE);
                // ADD 2009/11/19 3次分対応 得意先掛率グループ改良 ----------<<<<<
                return;
            }

            int custRateGroup = int.Parse((string)uGrid.ActiveCell.Value);

            if (GetCustRateGrpName(custRateGroup) == "")
            {
                ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                               "マスタに登録されていません。",
                               -1,
                               MessageBoxButtons.OK,
                               MessageBoxDefaultButton.Button1);

                this._errFlg = true;

                uGrid.AfterCellUpdate -= uGrid_CustRateGroup_AfterCellUpdate;
                this._cellUpdateFlg = true;
                uGrid.ActiveCell.Value = DBNull.Value;
                uGrid.AfterCellUpdate += uGrid_CustRateGroup_AfterCellUpdate;
                this._cellUpdateFlg = false;
                return;
            }

            // ゼロ詰め
            uGrid.AfterCellUpdate -= uGrid_CustRateGroup_AfterCellUpdate;
            this._cellUpdateFlg = true;
            uGrid.ActiveCell.Value = custRateGroup.ToString("0000");
            uGrid.AfterCellUpdate += uGrid_CustRateGroup_AfterCellUpdate;
            this._cellUpdateFlg = false;
        }

        /// <summary>
        /// CellChange イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : セルの値が変更された時に発生します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date	   : 2008/10/03</br>
        /// </remarks>
        private void uGrid_CustRateGroup1_CellChange(object sender, CellEventArgs e)
        {
            UltraGrid uGrid = (UltraGrid)sender;

            if (uGrid.ActiveCell == null)
            {
                return;
            }

            if (uGrid.ActiveCell.Row.Index != 0)
            {
                return;
            }

            // DEL 2009/11/19 3次分対応 得意先掛率グループ改良 ---------->>>>>
            //if ((uGrid.ActiveCell.Text.Trim() == "") || (int.Parse(uGrid.ActiveCell.Text.Trim()) == 0))
            // DEL 2009/11/19 3次分対応 得意先掛率グループ改良 ----------<<<<<
            // ADD 2009/11/19 3次分対応 得意先掛率グループ改良 ---------->>>>>
            // MEMO:先頭行（純正ALL）の場合、全行に展開
            if (string.IsNullOrEmpty(uGrid.ActiveCell.Text))
            // ADD 2009/11/19 3次分対応 得意先掛率グループ改良 ----------<<<<<
            {
                ChangeGridEnabled(true);
            }
            else
            {
                ChangeGridEnabled(false);
            }
        }

        /// <summary>
        /// Leave イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : グリッドからフォーカスが離れた時に発生します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date	   : 2008/10/03</br>
        /// </remarks>
        private void uGrid_CustRateGroup_Leave(object sender, EventArgs e)
        {
            UltraGrid uGrid = (UltraGrid)sender;

            uGrid.ActiveCell = null;
            uGrid.ActiveRow = null;
        }

        /// <summary>
        /// Timer_Tick イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : 指定された間隔の時間が経過した時に発生します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date	   : 2008/10/03</br>
        /// </remarks>
        private void Initial_Timer_Tick(object sender, EventArgs e)
        {
            this.Initial_Timer.Enabled = false;

            // 画面再構築処理
            ScreenReconstruction();
        }

        /// <summary>
        /// ChangeFocus イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : アクティブコントロールが変わった時に発生します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date	   : 2008/10/03</br>
        /// </remarks>
        private void tRetKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null)
            {
                return;
            }

            // 2009.03.30 30413 犬飼 新規モードからモード変更対応 >>>>>>START
            _modeFlg = false;
            // 2009.03.30 30413 犬飼 新規モードからモード変更対応 <<<<<<END

            switch (e.PrevCtrl.Name)
            {
                case "tNedit_CustomerCode":
                    {
                        if (this.tNedit_CustomerCode.GetInt() == 0)
                        {
                            this.tEdit_CustomerName.Clear();

                            if (e.Key == Keys.Down)
                            {
                                e.NextCtrl = null;
                                this.uGrid_CustRateGroup1.Focus();
                                this.uGrid_CustRateGroup1.Rows[0].Cells[COLUMN_CUSTRATEGROUP].Activate();
                                this.uGrid_CustRateGroup1.PerformAction(UltraGridAction.EnterEditMode);
                            }

                            return;
                        }

                        // 得意先コード取得
                        int customerCode = this.tNedit_CustomerCode.GetInt();

                        // 得意先名取得
                        this.tEdit_CustomerName.DataText = GetCustomerName(customerCode);

                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                if (this.tEdit_CustomerName.DataText.Trim() != "")
                                {
                                    e.NextCtrl = null;
                                    this.uGrid_CustRateGroup1.Focus();
                                    this.uGrid_CustRateGroup1.Rows[0].Cells[COLUMN_CUSTRATEGROUP].Activate();
                                    this.uGrid_CustRateGroup1.PerformAction(UltraGridAction.EnterEditMode);
                                }
                            }
                            else if (e.Key == Keys.Down)
                            {
                                e.NextCtrl = null;
                                this.uGrid_CustRateGroup1.Focus();
                                this.uGrid_CustRateGroup1.Rows[0].Cells[COLUMN_CUSTRATEGROUP].Activate();
                                this.uGrid_CustRateGroup1.PerformAction(UltraGridAction.EnterEditMode);
                            }
                        }

                        // 2009.03.30 30413 犬飼 新規モードからモード変更対応 >>>>>>START
                        if ((e.NextCtrl != null) && (e.NextCtrl.Name == "Cancel_Button"))
                        {
                            // 遷移先が閉じるボタン
                            _modeFlg = true;
                        }
                        else if (this._mainDataIndex < 0)
                        {
                            if (ModeChangeProc())
                            {
                                e.NextCtrl = tNedit_CustomerCode;
                            }
                        }
                        // 2009.03.30 30413 犬飼 新規モードからモード変更対応 <<<<<<END

                        break;
                    }
                case "CustomerGuide_Button":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab) || (e.Key == Keys.Down))
                            {
                                e.NextCtrl = null;
                                this.uGrid_CustRateGroup1.Focus();
                                this.uGrid_CustRateGroup1.Rows[0].Cells[COLUMN_CUSTRATEGROUP].Activate();
                                this.uGrid_CustRateGroup1.PerformAction(UltraGridAction.EnterEditMode);
                            }
                            else if (e.Key == Keys.Right)
                            {
                                e.NextCtrl = this.Renewal_Button;
                            }
                        }
                        break;
                    }
                case "uGrid_CustRateGroup1":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                this.uGrid_CustRateGroup1.PerformAction(UltraGridAction.ExitEditMode);

                                if (!this._errFlg)
                                {
                                    SetNextFocus(this.uGrid_CustRateGroup1, ref e);
                                }
                                else
                                {
                                    e.NextCtrl = null;
                                    this.uGrid_CustRateGroup1.PerformAction(UltraGridAction.EnterEditMode);
                                    this._errFlg = false;
                                }
                            }
                        }
                        else
                        {
                            if (e.Key == Keys.Tab)
                            {
                                this.uGrid_CustRateGroup1.PerformAction(UltraGridAction.ExitEditMode);

                                if (!this._errFlg)
                                {
                                    SetBeforeFocus(this.uGrid_CustRateGroup1, ref e);
                                }
                                else
                                {
                                    e.NextCtrl = null;
                                    this.uGrid_CustRateGroup1.PerformAction(UltraGridAction.EnterEditMode);
                                    this._errFlg = false;
                                }
                            }
                        }
                        break;
                    }
                //case "uGrid_CustRateGroup2":
                //    {
                //        if (e.ShiftKey == false)
                //        {
                //            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                //            {
                //                this.uGrid_CustRateGroup2.PerformAction(UltraGridAction.ExitEditMode);

                //                if (!this._errFlg)
                //                {
                //                    SetNextFocus(this.uGrid_CustRateGroup2, ref e);
                //                }
                //                else
                //                {
                //                    e.NextCtrl = null;
                //                    this.uGrid_CustRateGroup2.PerformAction(UltraGridAction.EnterEditMode);
                //                    this._errFlg = false;
                //                }
                //            }
                //        }
                //        else
                //        {
                //            if (e.Key == Keys.Tab)
                //            {
                //                this.uGrid_CustRateGroup2.PerformAction(UltraGridAction.ExitEditMode);

                //                if (!this._errFlg)
                //                {
                //                    SetBeforeFocus(this.uGrid_CustRateGroup2, ref e);
                //                }
                //                else
                //                {
                //                    e.NextCtrl = null;
                //                    this.uGrid_CustRateGroup2.PerformAction(UltraGridAction.EnterEditMode);
                //                    this._errFlg = false;
                //                }
                //            }
                //        }
                //        break;
                //    }
                case "uGrid_CustRateGroup3":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                this.uGrid_CustRateGroup3.PerformAction(UltraGridAction.ExitEditMode);

                                if (!this._errFlg)
                                {
                                    SetNextFocus(this.uGrid_CustRateGroup3, ref e);
                                }
                                else
                                {
                                    e.NextCtrl = null;
                                    this.uGrid_CustRateGroup3.PerformAction(UltraGridAction.EnterEditMode);
                                    this._errFlg = false;
                                }
                            }
                        }
                        else
                        {
                            if (e.Key == Keys.Tab)
                            {
                                this.uGrid_CustRateGroup3.PerformAction(UltraGridAction.ExitEditMode);

                                if (!this._errFlg)
                                {
                                    SetBeforeFocus(this.uGrid_CustRateGroup3, ref e);
                                }
                                else
                                {
                                    e.NextCtrl = null;
                                    this.uGrid_CustRateGroup3.PerformAction(UltraGridAction.EnterEditMode);
                                    this._errFlg = false;
                                }
                            }
                        }
                        break;
                    }
                case "Ok_Button":
                case "Renewal_Button":
                    {
                        if (e.ShiftKey == false)
                        {
                            if (e.Key == Keys.Up)
                            {
                                e.NextCtrl = null;
                                this.uGrid_CustRateGroup3.Focus();
                                this.uGrid_CustRateGroup3.Rows[0].Cells[COLUMN_CUSTRATEGROUP].Activate();
                                this.uGrid_CustRateGroup3.PerformAction(UltraGridAction.EnterEditMode);
                            }
                            else if (e.Key == Keys.Left)
                            {
                                e.NextCtrl = this.CustomerGuide_Button;
                            }
                        }
                        else
                        {
                            if (e.Key == Keys.Tab)
                            {
                                e.NextCtrl = null;
                                this.uGrid_CustRateGroup3.Focus();
                                //this.uGrid_CustRateGroup3.Rows[0].Cells[COLUMN_CUSTRATEGROUP].Activate();
                                //this.uGrid_CustRateGroup3.PerformAction(UltraGridAction.EnterEditMode);
                                if (this.uGrid_CustRateGroup3.Rows[0].Cells[COLUMN_CUSTRATEGROUP].Text != "")
                                {
                                    // 掛率Gコードへ遷移
                                    this.uGrid_CustRateGroup3.Rows[0].Cells[COLUMN_CUSTRATEGROUP].Activate();
                                    this.uGrid_CustRateGroup3.PerformAction(UltraGridAction.EnterEditMode);
                                }
                                else
                                {
                                    // ガイドボタンへ遷移
                                    this.uGrid_CustRateGroup3.Rows[0].Cells[COLUMN_CUSTRATEGROUPBUTTON].Activate();
                                }
                            }
                        }
                        break;
                    }
                case "Cancel_Button":
                    {
                        if (e.ShiftKey == false)
                        {
                            if (e.Key == Keys.Up)
                            {
                                e.NextCtrl = null;
                                this.uGrid_CustRateGroup3.Focus();
                                this.uGrid_CustRateGroup3.Rows[0].Cells[COLUMN_CUSTRATEGROUP].Activate();
                                this.uGrid_CustRateGroup3.PerformAction(UltraGridAction.EnterEditMode);
                            }
                        }
                        break;
                    }
            }
        }
        #endregion ■ Control Events        

        /// <summary>
        /// ClickCellButton イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : セルのガイドボタンをクリックした際のイベント処理。</br>
        /// </remarks>
        private void uGrid_CustRateGroup1_ClickCellButton(object sender, CellEventArgs e)
        {
            UltraGrid uGrid = (UltraGrid)sender;

            if (uGrid.ActiveCell == null)
            {
                return;
            }

            int status = -1;

            // ガイド起動
            UserGdBd userGdBd = new UserGdBd();
            UserGdHd userGdHd = new UserGdHd();
            status = this._userGuideAcs.ExecuteGuid(this._enterpriseCode, out userGdHd, out userGdBd, 43);

            // 項目に展開
            if (status == 0)
            {
                uGrid.AfterCellUpdate -= uGrid_CustRateGroup_AfterCellUpdate;
                this._cellUpdateFlg = true;
                e.Cell.Row.Cells[COLUMN_CUSTRATEGROUP].Value = userGdBd.GuideCode.ToString("d04");      // 得意先掛率Ｇコード
                e.Cell.Row.Cells[COLUMN_CUSTRATEGROUPNAME].Value = userGdBd.GuideName;                  // 得意先掛率Ｇ名称
                uGrid.AfterCellUpdate += uGrid_CustRateGroup_AfterCellUpdate;
                this._cellUpdateFlg = false;

                int rowIndex = uGrid.ActiveCell.Row.Index;   

                switch (uGrid.Name)
                {
                    case "uGrid_CustRateGroup1":
                        {
                            if (rowIndex == 0)
                            {
                                string custRateGroup = e.Cell.Row.Cells[COLUMN_CUSTRATEGROUP].Text.Trim();
                                if ((custRateGroup == "") || (int.Parse(custRateGroup) == 0))
                                {
                                    ChangeGridEnabled(true);
                                    uGrid.Focus();
                                    uGrid.Rows[rowIndex + 1].Cells[COLUMN_CUSTRATEGROUP].Activate();
                                    uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                }
                                else
                                {
                                    ChangeGridEnabled(false);
                                    this._custRateGroup_Grid[1].Focus();
                                    this._custRateGroup_Grid[1].Rows[0].Cells[COLUMN_CUSTRATEGROUP].Activate();
                                    this._custRateGroup_Grid[1].PerformAction(UltraGridAction.EnterEditMode);
                                }
                            }
                            else if (rowIndex == 25)
                            {
                                this._custRateGroup_Grid[1].Focus();
                                this._custRateGroup_Grid[1].Rows[0].Cells[COLUMN_CUSTRATEGROUP].Activate();
                                this._custRateGroup_Grid[1].PerformAction(UltraGridAction.EnterEditMode);
                            }
                            else
                            {
                                uGrid.Focus();
                                uGrid.Rows[rowIndex + 1].Cells[COLUMN_CUSTRATEGROUP].Activate();
                                uGrid.PerformAction(UltraGridAction.EnterEditMode);
                            }
                            break;
                        }
                    case "uGrid_CustRateGroup3":
                        {
                            this.Renewal_Button.Focus();
                            break;
                        }
                }
            }
        }

        private void Renewal_Button_Click(object sender, EventArgs e)
        {
            ReadMakerUMnt();
            ReadUserGuide();
            ReadCustomerSearchRet();

            ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                           "最新情報を取得しました。",
                           0,
                           MessageBoxButtons.OK,
                           MessageBoxDefaultButton.Button1);
        }

        // 2009.03.30 30413 犬飼 新規モードからモード変更対応 >>>>>>START
        /// <summary>
        /// モード変更処理
        /// </summary>
        private bool ModeChangeProc()
        {
            // 得意先コード
            int customerCode = tNedit_CustomerCode.GetInt();

            for (int i = 0; i < this.Bind_DataSet.Tables[TABLE_MAIN].Rows.Count; i++)
            {
                // データセットと比較
                int dsCustomerCode = int.Parse((string)this.Bind_DataSet.Tables[TABLE_MAIN].Rows[i][VIEW_CUSTOMERCODE]);
                if (customerCode == dsCustomerCode)
                {
                    // 入力コードがデータセットに存在する場合
                    if ((string)this.Bind_DataSet.Tables[TABLE_MAIN].Rows[i][VIEW_DELETEDATE] != "")
                    {
                        // 論理削除
                        TMsgDisp.Show(this, 					// 親ウィンドウフォーム
                          emErrorLevel.ERR_LEVEL_INFO,          // エラーレベル
                          ASSEMBLY_ID,						    // アセンブリＩＤまたはクラスＩＤ
                          "入力されたコードの得意先掛率グループ情報は既に削除されています。", 			// 表示するメッセージ
                          0, 									// ステータス値
                          MessageBoxButtons.OK);				// 表示するボタン
                        // 得意先コードのクリア
                        tNedit_CustomerCode.Clear();
                        tEdit_CustomerName.Clear();
                        return true;
                    }

                    DialogResult res = TMsgDisp.Show(
                        this,                                   // 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_INFO,            // エラーレベル
                        ASSEMBLY_ID,                            // アセンブリＩＤまたはクラスＩＤ
                        "入力されたコードの得意先掛率グループ情報が既に登録されています。\n編集を行いますか？",   // 表示するメッセージ
                        0,                                      // ステータス値
                        MessageBoxButtons.YesNo);               // 表示するボタン
                    switch (res)
                    {
                        case DialogResult.Yes:
                            {
                                // 画面再描画
                                this._mainDataIndex = i;
                                ScreenClear();
                                ScreenReconstruction();
                                break;
                            }
                        case DialogResult.No:
                            {
                                // 得意先コードのクリア
                                tNedit_CustomerCode.Clear();
                                tEdit_CustomerName.Clear();
                                break;
                            }
                    }
                    return true;
                }
            }
            return false;
        }
        // 2009.03.30 30413 犬飼 新規モードからモード変更対応 <<<<<<END
    }
}