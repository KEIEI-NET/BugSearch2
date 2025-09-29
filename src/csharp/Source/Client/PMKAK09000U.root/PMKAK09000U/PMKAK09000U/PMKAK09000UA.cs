//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : 仕入先マスタ(総括設定)
// プログラム概要   : 仕入先マスタ(総括設定)のUI設定を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2012 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : FSI斎藤 和宏
// 作 成 日  2012/09/04  修正内容 : 新規作成
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

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 仕入先マスタ(総括設定)UIクラス
    /// </summary>
    /// <remarks>
    /// <br>Note		: 仕入先マスタ(総括設定)のUI設定を行います。</br>
    /// <br>Programmer	: FSI斎藤 和宏</br>
    /// <br>Date        : 2012/08/27</br>
    /// </remarks>
    public partial class PMKAK09000UA : Form, IMasterMaintenanceArrayType
    {
        #region ■ Constants

        // プログラムID
        private const string ASSEMBLY_ID = "PMKAK09000U";

        // テーブル名称
        private const string TABLE_MAIN = "MainTable";
        private const string TABLE_DETAIL = "DetailTable";

        //// データビュータイトル
        private const string GRIDTITLE_SUMSUPPLIER = "総括仕入先";
        private const string GRIDTITLE_SUPPLIER = "仕入先";

        //// データビュー表示用
        private const string VIEW_SUMSECTIONCODE = "総括拠点コード";
        private const string VIEW_SUMSECTIONNAME = "総括拠点名称";
        private const string VIEW_SUMSUPPLIERCODE = "総括仕入先コード";
        private const string VIEW_SUMSUPPLIERNAME = "総括仕入先名称";

        private const string VIEW_DELETEDATE = "削除日";
        private const string VIEW_SECTIONCODE = "拠点コード";
        private const string VIEW_SECTIONNAME = "拠点名称";
        private const string VIEW_SUPPLIERCODE = "仕入先コード";
        private const string VIEW_SUPPLIERNAME = "仕入先名称";

        // グリッド列タイトル
        private const string COLUMN_NO = "No";
        private const string COLUMN_SECTIONCODE = "SectionCode";
        private const string COLUMN_SECTIONNAME = "DemandAddUpSecNm";
        private const string COLUMN_SECTIONGUIDE = "SectionGuide";
        private const string COLUMN_SUPPLIERCD = "SupplierCd";
        private const string COLUMN_SUPPLIERNM = "SupplierNm";
        private const string COLUMN_SUPPLIERGUIDE = "SupplierGuide";

        // 編集モード
        private const string INSERT_MODE = "新規モード";
        private const string UPDATE_MODE = "更新モード";
        private const string DELETE_MODE = "削除モード";

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

        private SumSuppStAcs _sumSuppStAcs;
        private SecInfoSetAcs _secInfoSetAcs;

        private Dictionary<string , SecInfoSet> _secInfoSetDic;
        private Dictionary<int, Supplier> _supplierDic;

        private SupplierAcs _supplierAcs;

        private ControlScreenSkin _controlScreenSkin;       // 画面デザイン変更クラス
        private List<SumSuppSt> _sumSuppStListClone;        // 仕入先マスタ(総括設定)リストClone

        private Dictionary<string, List<int>> _mainList;    // メイングリッド(左側に表示)されるもののリスト
        private List<SumSuppSt> _detailList;

        private string _sumSectionCode;                     // 総括拠点コード
        private int    _sumSupplierCode;                    // 総括仕入先コード
        private int    _sumSuppTotalDay;                    // 総括仕入先の締日            

        private bool _checkSectionFlg;
        private bool _checkSupplierFlg;
        
        // 保存処理中かどうかのフラグ(PU二重表示対応)
        private bool _isSaveProcess;

        // セル変更前値backup
        private string _beforeCellText;

        #endregion ■ Private Members

        #region ■ Constructor
        /// <summary>
        /// 仕入先マスタ(総括設定)クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 仕入先マスタ(総括設定)UIクラスの新しいインスタンスを生成します。</br>
        /// <br>Programmer	: FSI斎藤 和宏</br>
        /// <br>Date        : 2012/08/27</br>
        /// </remarks>
        public PMKAK09000UA()
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

            // 各マスタへのアクセスクラス
            this._sumSuppStAcs = new SumSuppStAcs();
            this._secInfoSetAcs = new SecInfoSetAcs();
            this._supplierAcs = new SupplierAcs();

            this._controlScreenSkin = new ControlScreenSkin();

            // マスタ読込
            ReadSecInfoSet();
            ReadSupplier();

            // DataSet列情報構築
            this.Bind_DataSet = new DataSet();
            DataSetColumnConstruction();

            this._isSaveProcess  = false;
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
        /// <br>Programmer : FSI斎藤 和宏</br>
        /// <br>Date       : 2012/08/27</br>
        /// </remarks>
        public void GetAppearanceTable(out Hashtable[] appearanceTable)
        {
            //==============================
            // メイン
            //==============================
            Hashtable main = new Hashtable();

            main.Add(VIEW_DELETEDATE, new GridColAppearance(MGridColDispType.DeletionDataBoth, ContentAlignment.MiddleLeft, string.Empty, Color.Red));
            main.Add(VIEW_SUMSECTIONCODE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, string.Empty, Color.Black));
            main.Add(VIEW_SUMSECTIONNAME, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, string.Empty, Color.Black));
            main.Add(VIEW_SUMSUPPLIERCODE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, string.Empty, Color.Black));
            main.Add(VIEW_SUMSUPPLIERNAME, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, string.Empty, Color.Black));
            
            //==============================
            // 詳細
            //==============================
            Hashtable detail = new Hashtable();

            detail.Add(VIEW_DELETEDATE, new GridColAppearance(MGridColDispType.DeletionDataBoth, ContentAlignment.MiddleLeft, string.Empty, Color.Red));
            detail.Add(VIEW_SECTIONCODE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, string.Empty, Color.Black));
            detail.Add(VIEW_SECTIONNAME, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, string.Empty, Color.Black));
            detail.Add(VIEW_SUPPLIERCODE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, string.Empty, Color.Black));
            detail.Add(VIEW_SUPPLIERNAME, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, string.Empty, Color.Black));

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
        /// <br>Programmer : FSI斎藤 和宏</br>
        /// <br>Date       : 2012/08/27</br>
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
        /// <br>Programmer	: FSI斎藤 和宏</br>
        /// <br>Date        : 2012/08/27</br>
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
        /// <br>Programmer	: FSI斎藤 和宏</br>
        /// <br>Date        : 2012/08/27</br>
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
        /// <br>Programmer	: FSI斎藤 和宏</br>
        /// <br>Date        : 2012/08/27</br>
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
        /// <br>Programmer	: FSI斎藤 和宏</br>
        /// <br>Date        : 2012/08/27</br>
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
        /// <br>Programmer	: FSI斎藤 和宏</br>
        /// <br>Date        : 2012/08/27</br>
        /// </remarks>
        public string[] GetGridTitleList()
        {
            string[] gridTitle = { GRIDTITLE_SUMSUPPLIER, GRIDTITLE_SUPPLIER };
            return gridTitle;
        }

        /// <summary>
        /// 修正ボタンの有効設定リスト取得処理
        /// </summary>
        /// <returns>修正ボタンの有効設定リスト</returns>
        /// <remarks>
        /// <br>Note       : 修正ボタンの有効設定リストを取得します。</br>
        /// <br>Programmer	: FSI斎藤 和宏</br>
        /// <br>Date        : 2012/08/27</br>
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
        /// <br>Programmer	: FSI斎藤 和宏</br>
        /// <br>Date        : 2012/08/27</br>
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
        /// <br>Programmer	: FSI斎藤 和宏</br>
        /// <br>Date        : 2012/08/27</br>
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
        /// <br>Programmer	: FSI斎藤 和宏</br>
        /// <br>Date        : 2012/08/27</br>
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
        /// <br>Programmer : FSI斎藤 和宏</br>
        /// <br>Date       : 2012/08/27</br>
        /// </remarks>
        public int DetailsDataSearch(ref int totalCount, int readCount)
        {
            ArrayList retList;

            // 現在保持しているデータをクリアする
            this.Bind_DataSet.Tables[TABLE_DETAIL].Rows.Clear();

            // メインデータが選択されている場合
            if (this._mainDataIndex > -1)
            {
                // 選択されているメインテーブルの拠点コード・仕入先コードを取得
                string sumSecCode = this.Bind_DataSet.Tables[TABLE_MAIN].Rows[this._mainDataIndex][VIEW_SUMSECTIONCODE].ToString().Trim();
                int sumSuppCode = int.Parse((string)this.Bind_DataSet.Tables[TABLE_MAIN].Rows[this._mainDataIndex][VIEW_SUMSUPPLIERCODE]);

                int status = -1;
                try
                {
                    // 検索処理（論理削除含む）
                    status = this._sumSuppStAcs.Search(out retList, this._enterpriseCode, sumSuppCode, sumSecCode, ConstantManagement.LogicalMode.GetDataAll);
                    switch (status)
                    {
                        case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                        case (int)ConstantManagement.DB_Status.ctDB_EOF:
                            {
                                // 取得したクラスをデータセットへ展開する
                                int index = 0;
                                foreach (SumSuppSt sumSuppSt in retList)
                                {
                                    // DataSet展開処理
                                    DetailToDataSet(sumSuppSt, index);
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
                }
                catch
                {

                    ShowMessageBox(emErrorLevel.ERR_LEVEL_STOP,
                    "DetailsDataSearch",
                    "読み込みに失敗しました。",
                    status,
                    MessageBoxButtons.OK);

                    totalCount = 0;
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
        /// <br>Programmer : FSI斎藤 和宏</br>
        /// <br>Date       : 2012/08/27</br>
        /// </remarks>
        public int Search(ref int totalCount, int readCount)
        {
            // 現在保持しているデータをクリアする
            this.Bind_DataSet.Tables[TABLE_MAIN].Rows.Clear();

            this._mainList = new Dictionary<string, List<int>>();
            this._detailList = new List<SumSuppSt>();

            ArrayList retList;

            int index = 0;

            int status = this._sumSuppStAcs.Search(out retList, this._enterpriseCode, ConstantManagement.LogicalMode.GetDataAll);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    {
                        // バッファ保持
                        foreach (SumSuppSt sumSuppSt in retList)
                        {
                            // 総括拠点コードがディクショナリのキーに含まれてるか
                            if (this._mainList.ContainsKey(sumSuppSt.SumSectionCd.Trim()))
                            {
                                if (!this._mainList[sumSuppSt.SumSectionCd.Trim()].Contains(sumSuppSt.SumSupplierCd))
                                {
                                    // 総括仕入先コードが含まれていない場合
                                    // 総括拠点コードに対する総括仕入先コードを追加
                                    this._mainList[sumSuppSt.SumSectionCd.Trim()].Add(sumSuppSt.SumSupplierCd);
                                    MainToDataSet(sumSuppSt, index);
                                    index++;
                                }
                            }
                            else
                            {
                                // 総括拠点コードが新しいコード
                                List<int> templist = new List<int>();
                                templist.Add(sumSuppSt.SumSupplierCd);
                                this._mainList.Add(sumSuppSt.SumSectionCd.Trim(), templist);
                                MainToDataSet(sumSuppSt, index);
                                index++;
                            }

                            // 拠点コードはTrimしてからdetailリストにAdd
                            sumSuppSt.SumSectionCd = sumSuppSt.SumSectionCd.Trim();
                            sumSuppSt.SectionCode  = sumSuppSt.SectionCode.Trim();
                            this._detailList.Add(sumSuppSt);
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

            totalCount = index;

            return 0;
        }

        /// <summary>
        /// ネクストデータ検索処理
        /// </summary>
        /// <param name="readCount">抽出対象件数</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 指定した件数分のネクストデータを検索します。</br>
        /// <br>Programmer : FSI斎藤 和宏</br>
        /// <br>Date       : 2012/08/27</br>
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
        /// <br>Programmer : FSI斎藤 和宏</br>
        /// <br>Date       : 2012/08/27</br>
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
        /// <br>Programmer : FSI斎藤 和宏</br>
        /// <br>Date       : 2012/08/27</br>
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
        /// 拠点マスタ読込処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 拠点マスタを読込、バッファに保持します。</br>
        /// <br>Programmer : FSI斎藤 和宏</br>
        /// <br>Date       : 2012/08/27</br>
        /// </remarks>
        private void ReadSecInfoSet()
        {
            this._secInfoSetDic = new Dictionary<string, SecInfoSet>();

            int status = -1;
            ArrayList retArray;

            try
            {
                status = this._secInfoSetAcs.Search(out retArray, this._enterpriseCode);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    foreach (SecInfoSet retSecInfo in retArray)
                    {
                        this._secInfoSetDic.Add(retSecInfo.SectionCode.Trim(), retSecInfo);
                    }
                }
            }
            catch
            {
            }
        }

        /// <summary>
        /// 拠点名取得処理
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <returns>拠点名</returns>
        /// <remarks>
        /// <br>Note       : 拠点名を取得します。</br>
        /// <br>Programmer : FSI斎藤 和宏</br>
        /// <br>Date       : 2012/08/27</br>
        /// </remarks>
        private string GetSectionName(string sectionCode)
        {
            string sectionName = string.Empty;

            if (this._secInfoSetDic.ContainsKey(sectionCode.Trim()))
            {
                sectionName = this._secInfoSetDic[sectionCode.Trim()].SectionGuideSnm.Trim();
            }

            return sectionName;
        }

        /// <summary>
        /// 仕入先情報取得処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 仕入先情報を取得し、キャッシュに保持します。</br>
        /// <br>Programmer : FSI斎藤 和宏</br>
        /// <br>Date       : 2012/08/27</br>
        /// </remarks>
        private void ReadSupplier()
        {
            this._supplierDic = new Dictionary<int, Supplier>();

            int status = -1;
            try
            {
                ArrayList retArray;

                status = this._supplierAcs.Search(out retArray, this._enterpriseCode);
                if (status == 0)
                {
                    foreach (Supplier retSupplierInfo in retArray)
                    {
                        this._supplierDic.Add(retSupplierInfo.SupplierCd, retSupplierInfo);
                    }
                }
            }
            catch
            {
                this._supplierDic = new Dictionary<int, Supplier>();
            }

            return;

        }

        /// <summary>
        /// 仕入先名取得処理
        /// </summary>
        /// <param name="suppliercode">仕入先コード</param>
        /// <returns>仕入先略称</returns>
        /// <remarks>
        /// <br>Note       : 仕入先略称を取得します。</br>
        /// <br>Programmer : FSI斎藤 和宏</br>
        /// <br>Date       : 2012/08/27</br>
        /// </remarks>
        private string GetSupplierSnm(int suppliercode)
        {
            string supplierSnm = string.Empty;

            if (this._supplierDic.ContainsKey(suppliercode))
            {
                supplierSnm = this._supplierDic[suppliercode].SupplierSnm.Trim();
            }

            return supplierSnm;
        }

        /// <summary>
        /// 締日取得処理
        /// </summary>
        /// <param name="suppliercode">仕入先コード</param>
        /// <returns>締日</returns>
        /// <remarks>
        /// <br>Note       : 締日を取得します。</br>
        /// <br>Programmer : FSI斎藤 和宏</br>
        /// <br>Date       : 2012/08/27</br>
        /// </remarks>
        private int GetTotalDay(int suppliercode)
        {
            int totalDay = 0;

            if (this._supplierDic.ContainsKey(suppliercode))
            {
                totalDay = this._supplierDic[suppliercode].PaymentTotalDay;
            }

            return totalDay;
        }

        /// <summary>
        /// 画面初期化処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面情報を初期化します。</br>
        /// <br>Programmer : FSI斎藤 和宏</br>
        /// <br>Date       : 2012/08/27</br>
        /// </remarks>
        private void ScreenClear()
        {
            // 総括拠点
            this.tEdit_SectionCode.Clear();
            this.tEdit_SectionName.Clear();

            // 総括仕入先
            this.tNedit_SupplierCd.Clear();
            this.tEdit_SupplierSnm.Clear();

            // グリッド
            for (int rowIndex = 0; rowIndex < this.uGrid_SumSuppSt.Rows.Count; rowIndex++)
            {
                this.uGrid_SumSuppSt.Rows[rowIndex].Cells[COLUMN_SECTIONCODE].Value = string.Empty;
                this.uGrid_SumSuppSt.Rows[rowIndex].Cells[COLUMN_SECTIONNAME].Value = string.Empty;
                this.uGrid_SumSuppSt.Rows[rowIndex].Cells[COLUMN_SUPPLIERCD].Value = string.Empty;
                this.uGrid_SumSuppSt.Rows[rowIndex].Cells[COLUMN_SUPPLIERNM].Value = string.Empty;
                this.uGrid_SumSuppSt.Rows[rowIndex].Cells[COLUMN_SECTIONCODE].Activation = Activation.AllowEdit;
                this.uGrid_SumSuppSt.Rows[rowIndex].Cells[COLUMN_SUPPLIERCD].Activation = Activation.AllowEdit;
            }

            this.uGrid_SumSuppSt.ActiveCell = null;
            this.uGrid_SumSuppSt.ActiveRow = null;
        }

        /// <summary>
        /// 画面初期設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面の初期設定を行います。</br>
        /// <br>Programmer : FSI斎藤 和宏</br>
        /// <br>Date       : 2012/08/27</br>
        /// </remarks>
        private void SetScreenInitialSetting()
        {
            // マスタ読込
            ReadSecInfoSet();
            ReadSupplier();

            // コントロールサイズ設定
            this.tEdit_SectionCode.Size = new Size(35, 24);
            this.tEdit_SectionName.Size = new Size(179, 24);

            this.tNedit_SupplierCd.Size = new Size(60, 24);
            this.tEdit_SupplierSnm.Size = new Size(179, 24);

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
            this.SumSectionGuide_Button.ImageList = imageList16;
            this.SumSectionGuide_Button.Appearance.Image = Size16_Index.STAR1;
            this.SumSuppGuide_Button.ImageList = imageList16;
            this.SumSuppGuide_Button.Appearance.Image = Size16_Index.STAR1;

            // グリッド構築
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add(COLUMN_NO, typeof(int));
            dataTable.Columns.Add(COLUMN_SECTIONCODE, typeof(string));
            dataTable.Columns.Add(COLUMN_SECTIONNAME, typeof(string));
            dataTable.Columns.Add(COLUMN_SECTIONGUIDE, typeof(string));
            dataTable.Columns.Add(COLUMN_SUPPLIERCD, typeof(string));
            dataTable.Columns.Add(COLUMN_SUPPLIERNM, typeof(string));
            dataTable.Columns.Add(COLUMN_SUPPLIERGUIDE, typeof(string));

            for (int rowIndex = 0; rowIndex < 25; rowIndex++)
            {
                DataRow dataRow = dataTable.NewRow();

                dataRow[COLUMN_NO] = rowIndex + 1;
                dataRow[COLUMN_SECTIONCODE] = string.Empty;
                dataRow[COLUMN_SECTIONNAME] = string.Empty;
                dataRow[COLUMN_SECTIONGUIDE] = string.Empty;
                dataRow[COLUMN_SUPPLIERCD] = string.Empty;
                dataRow[COLUMN_SUPPLIERNM] = string.Empty;
                dataRow[COLUMN_SUPPLIERGUIDE] = string.Empty;

                dataTable.Rows.Add(dataRow);
            }

            this.uGrid_SumSuppSt.DataSource = dataTable;

            for (int rowIndex = 0; rowIndex < 25; rowIndex++)
            {
                this.uGrid_SumSuppSt.Rows[rowIndex].Cells[COLUMN_SECTIONCODE].Tag = string.Empty;
                this.uGrid_SumSuppSt.Rows[rowIndex].Cells[COLUMN_SUPPLIERCD].Tag = string.Empty;
            }

            ColumnsCollection columns = this.uGrid_SumSuppSt.DisplayLayout.Bands[0].Columns;

            // ヘッダーキャプション
            columns[COLUMN_NO].Header.Caption = "No.";
            columns[COLUMN_SECTIONCODE].Header.Caption = "拠点";
            columns[COLUMN_SECTIONNAME].Header.Caption = "拠点名";
            columns[COLUMN_SECTIONGUIDE].Header.Caption = string.Empty;
            columns[COLUMN_SUPPLIERCD].Header.Caption = "仕入先";
            columns[COLUMN_SUPPLIERNM].Header.Caption = "仕入先名";
            columns[COLUMN_SUPPLIERGUIDE].Header.Caption = string.Empty;
            // TextHAlign
            columns[COLUMN_NO].CellAppearance.TextHAlign = HAlign.Right;
            columns[COLUMN_SECTIONCODE].CellAppearance.TextHAlign = HAlign.Left;
            columns[COLUMN_SECTIONNAME].CellAppearance.TextHAlign = HAlign.Left;
            columns[COLUMN_SECTIONGUIDE].CellAppearance.TextHAlign = HAlign.Center;
            columns[COLUMN_SUPPLIERCD].CellAppearance.TextHAlign = HAlign.Right;
            columns[COLUMN_SUPPLIERNM].CellAppearance.TextHAlign = HAlign.Left;
            columns[COLUMN_SUPPLIERGUIDE].CellAppearance.TextHAlign = HAlign.Center;
            // TextVAlign
            columns[COLUMN_NO].CellAppearance.TextVAlign = VAlign.Middle;
            columns[COLUMN_SECTIONCODE].CellAppearance.TextVAlign = VAlign.Middle;
            columns[COLUMN_SECTIONNAME].CellAppearance.TextVAlign = VAlign.Middle;
            columns[COLUMN_SECTIONGUIDE].CellAppearance.TextVAlign = VAlign.Middle;
            columns[COLUMN_SUPPLIERCD].CellAppearance.TextVAlign = VAlign.Middle;
            columns[COLUMN_SUPPLIERNM].CellAppearance.TextVAlign = VAlign.Middle;
            columns[COLUMN_SUPPLIERGUIDE].CellAppearance.TextVAlign = VAlign.Middle;
            // 入力制御
            columns[COLUMN_NO].CellActivation = Activation.Disabled;
            columns[COLUMN_SECTIONCODE].CellActivation = Activation.AllowEdit;
            columns[COLUMN_SECTIONNAME].CellActivation = Activation.Disabled;
            columns[COLUMN_SECTIONGUIDE].CellActivation = Activation.AllowEdit;
            columns[COLUMN_SUPPLIERCD].CellActivation = Activation.AllowEdit;
            columns[COLUMN_SUPPLIERNM].CellActivation = Activation.Disabled;
            columns[COLUMN_SUPPLIERGUIDE].CellActivation = Activation.AllowEdit;
            // 列幅
            columns[COLUMN_NO].Width = 45;
            columns[COLUMN_SECTIONCODE].Width = 90;
            columns[COLUMN_SECTIONNAME].Width = 175;
            columns[COLUMN_SECTIONGUIDE].Width = 24;
            columns[COLUMN_SUPPLIERCD].Width = 100;
            columns[COLUMN_SUPPLIERNM].Width = 175;
            columns[COLUMN_SUPPLIERGUIDE].Width = 24;
            // セルColor
            columns[COLUMN_NO].CellAppearance.BackColor = Color.FromArgb(89, 135, 214);
            columns[COLUMN_NO].CellAppearance.BackColorDisabled = Color.FromArgb(89, 135, 214);
            columns[COLUMN_NO].CellAppearance.BackColor2 = Color.FromArgb(7, 59, 150);
            columns[COLUMN_NO].CellAppearance.BackColorDisabled2 = Color.FromArgb(7, 59, 150);
            columns[COLUMN_NO].CellAppearance.ForeColor = Color.White;
            columns[COLUMN_NO].CellAppearance.ForeColorDisabled = Color.White;
            columns[COLUMN_NO].CellAppearance.BackGradientStyle = GradientStyle.Vertical;
            columns[COLUMN_SECTIONNAME].CellAppearance.BackColor = Color.Gainsboro;
            columns[COLUMN_SECTIONNAME].CellAppearance.BackColorDisabled = Color.Gainsboro;
            columns[COLUMN_SUPPLIERNM].CellAppearance.BackColor = Color.Gainsboro;
            columns[COLUMN_SUPPLIERNM].CellAppearance.BackColorDisabled = Color.Gainsboro;
            columns[COLUMN_SECTIONCODE].CellAppearance.BackColorDisabled = Color.FromKnownColor(KnownColor.Control);
            columns[COLUMN_SUPPLIERCD].CellAppearance.BackColorDisabled = Color.FromKnownColor(KnownColor.Control);
            // MaxLength
            columns[COLUMN_SECTIONCODE].MaxLength = this.uiSetControl1.GetSettingColumnCount(COLUMN_SECTIONCODE);
            columns[COLUMN_SUPPLIERCD].MaxLength = this.uiSetControl1.GetSettingColumnCount(COLUMN_SUPPLIERCD);
            columns[COLUMN_SECTIONNAME].MaxLength = 10;
            columns[COLUMN_SUPPLIERNM].MaxLength = 10;
            // セルボタン
            columns[COLUMN_SECTIONGUIDE].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;
            columns[COLUMN_SECTIONGUIDE].ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always;
            columns[COLUMN_SECTIONGUIDE].CellButtonAppearance.ImageHAlign = HAlign.Center;
            columns[COLUMN_SECTIONGUIDE].CellButtonAppearance.ImageVAlign = VAlign.Middle;
            columns[COLUMN_SECTIONGUIDE].CellButtonAppearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
            columns[COLUMN_SECTIONGUIDE].CellAppearance.Cursor = Cursors.Hand;
            columns[COLUMN_SUPPLIERGUIDE].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;
            columns[COLUMN_SUPPLIERGUIDE].ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always;
            columns[COLUMN_SUPPLIERGUIDE].CellButtonAppearance.ImageHAlign = HAlign.Center;
            columns[COLUMN_SUPPLIERGUIDE].CellButtonAppearance.ImageVAlign = VAlign.Middle;
            columns[COLUMN_SUPPLIERGUIDE].CellButtonAppearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
            columns[COLUMN_SUPPLIERGUIDE].CellAppearance.Cursor = Cursors.Hand;
        }

        /// <summary>
        /// DataSet展開処理(メインテーブル)
        /// </summary>
        /// <param name="sumSuppSt">仕入先総括設定コード</param>
        /// <param name="index">行インデックス</param>
        /// <remarks>
        /// <br>Note       : 仕入先マスタ(総括設定)をDataSetに展開します。</br>
        /// <br>Programmer : FSI斎藤 和宏</br>
        /// <br>Date       : 2012/08/27</br>
        /// </remarks>
        private void MainToDataSet(SumSuppSt sumSuppSt, int index)
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
            if (sumSuppSt.LogicalDeleteCode == 0)
            {
                this.Bind_DataSet.Tables[TABLE_MAIN].Rows[index][VIEW_DELETEDATE] = string.Empty;
            }
            else
            {
                this.Bind_DataSet.Tables[TABLE_MAIN].Rows[index][VIEW_DELETEDATE] = sumSuppSt.UpdateDateTimeJpInFormal;
            }

            // 総括拠点コード
            this.Bind_DataSet.Tables[TABLE_MAIN].Rows[index][VIEW_SUMSECTIONCODE] = sumSuppSt.SumSectionCd;
            // 総括拠点名称
            this.Bind_DataSet.Tables[TABLE_MAIN].Rows[index][VIEW_SUMSECTIONNAME] = GetSectionName(sumSuppSt.SumSectionCd);
            // 総括仕入先コード
            this.Bind_DataSet.Tables[TABLE_MAIN].Rows[index][VIEW_SUMSUPPLIERCODE] = sumSuppSt.SumSupplierCd.ToString("000000");
            // 総括仕入先名称
            this.Bind_DataSet.Tables[TABLE_MAIN].Rows[index][VIEW_SUMSUPPLIERNAME] = GetSupplierSnm(sumSuppSt.SumSupplierCd);

        }

        /// <summary>
        /// DataSet展開処理(詳細テーブル)
        /// </summary>
        /// <param name="sumSuppSt">仕入先マスタ(総括設定)</param>
        /// <param name="index">行インデックス</param>
        /// <remarks>
        /// <br>Note       : 仕入先マスタ(総括設定)をDataSetに展開します。</br>
        /// <br>Programmer : FSI斎藤 和宏</br>
        /// <br>Date       : 2012/08/27</br>
        /// </remarks>
        private void DetailToDataSet(SumSuppSt sumSuppSt, int index)
        {
            if ((index < 0) || (this.Bind_DataSet.Tables[TABLE_DETAIL].Rows.Count <= index))
            {
                // 新規と判断して、行を追加する
                DataRow dataRow = this.Bind_DataSet.Tables[TABLE_DETAIL].NewRow();
                this.Bind_DataSet.Tables[TABLE_DETAIL].Rows.Add(dataRow);

                // indexを行の最終行番号する
                index = this.Bind_DataSet.Tables[TABLE_DETAIL].Rows.Count - 1;
            }

            // 削除日
            if (sumSuppSt.LogicalDeleteCode == 0)
            {
                this.Bind_DataSet.Tables[TABLE_DETAIL].Rows[index][VIEW_DELETEDATE] = string.Empty;
            }
            else
            {
                this.Bind_DataSet.Tables[TABLE_DETAIL].Rows[index][VIEW_DELETEDATE] = sumSuppSt.UpdateDateTimeJpInFormal;
            }

            // 拠点
            this.Bind_DataSet.Tables[TABLE_DETAIL].Rows[index][VIEW_SECTIONCODE] = sumSuppSt.SectionCode.Trim();
            // 拠点名
            this.Bind_DataSet.Tables[TABLE_DETAIL].Rows[index][VIEW_SECTIONNAME] = GetSectionName(sumSuppSt.SectionCode.Trim());
            // 仕入先
            this.Bind_DataSet.Tables[TABLE_DETAIL].Rows[index][VIEW_SUPPLIERCODE] = sumSuppSt.SupplierCode.ToString("000000");
            // 仕入先名
            this.Bind_DataSet.Tables[TABLE_DETAIL].Rows[index][VIEW_SUPPLIERNAME] = GetSupplierSnm(sumSuppSt.SupplierCode);
        }

        /// <summary>
        /// DataSet列情報構築処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : DataSet列情報を構築します。</br>
        /// <br>Programmer : FSI斎藤 和宏</br>
        /// <br>Date       : 2012/08/27</br>
        /// </remarks>
        private void DataSetColumnConstruction()
        {
            //==============================
            // メイン
            //==============================
            DataTable mainTable = new DataTable(TABLE_MAIN);

            mainTable.Columns.Add(VIEW_DELETEDATE, typeof(string));
            mainTable.Columns.Add(VIEW_SUMSECTIONCODE, typeof(string));
            mainTable.Columns.Add(VIEW_SUMSECTIONNAME, typeof(string));
            mainTable.Columns.Add(VIEW_SUMSUPPLIERCODE, typeof(string));
            mainTable.Columns.Add(VIEW_SUMSUPPLIERNAME, typeof(string));
            
            //==============================
            // 詳細
            //==============================
            DataTable detailTable = new DataTable(TABLE_DETAIL);

            detailTable.Columns.Add(VIEW_DELETEDATE, typeof(string));
            detailTable.Columns.Add(VIEW_SECTIONCODE, typeof(string));
            detailTable.Columns.Add(VIEW_SECTIONNAME, typeof(string));
            detailTable.Columns.Add(VIEW_SUPPLIERCODE, typeof(string));
            detailTable.Columns.Add(VIEW_SUPPLIERNAME, typeof(string));

            this.Bind_DataSet.Tables.Add(mainTable);
            this.Bind_DataSet.Tables.Add(detailTable);
        }

        /// <summary>
        /// 画面再構築処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面を再構築します。</br>
        /// <br>Programmer : FSI斎藤 和宏</br>
        /// <br>Date       : 2012/08/27</br>
        /// </remarks>
        private void ScreenReconstruction()
        {
            if (this.uGrid_SumSuppSt.Rows.Count > 25)
            {
                for (int index = this.uGrid_SumSuppSt.Rows.Count - 1; index >= 25; index--)
                {
                    this.uGrid_SumSuppSt.Rows[index].Delete(false);
                }
            }

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

                // クローン作成
                this._sumSuppStListClone = new List<SumSuppSt>();

                // フォーカス設定
                this.tEdit_SectionCode.Focus();

                // 総括情報を初期化
                this._sumSectionCode = string.Empty;
                this._sumSupplierCode = 0;
                this._sumSuppTotalDay = 0;
            }
            else
            {
                //------------------------------
                // 更新モードor削除モード
                //------------------------------
                // DataSetから総括情報を取得
                this._sumSectionCode  = this.Bind_DataSet.Tables[TABLE_MAIN].Rows[this._mainDataIndex][VIEW_SUMSECTIONCODE].ToString().Trim();
                this._sumSupplierCode = int.Parse((string)this.Bind_DataSet.Tables[TABLE_MAIN].Rows[this._mainDataIndex][VIEW_SUMSUPPLIERCODE]);
                this._sumSuppTotalDay = GetTotalDay(this._sumSupplierCode);

                // 総括拠点コードと総括仕入先コードでインスタンスリストから該当データを取得
                List<SumSuppSt> sumSuppStList = SearchDetailListFromSumCode(this._sumSectionCode, this._sumSupplierCode);

                this._sumSuppStListClone = new List<SumSuppSt>();

                if (sumSuppStList.Count == 0)
                {
                    // ここに来ることはないはず(親が存在して子が0件の場合)
                    SumSuppSt sumSuppSt = new SumSuppSt();
                    sumSuppSt.SumSectionCd = this._sumSectionCode;
                    sumSuppSt.SumSupplierCd = this._sumSupplierCode;
                    sumSuppStList.Add(sumSuppSt);
                }
                else
                {
                    foreach (SumSuppSt sumSuppSt in sumSuppStList)
                    {
                        this._sumSuppStListClone.Add(sumSuppSt.Clone());
                    }
                }

                // 画面展開処理
                SumSuppStListToScreen(sumSuppStList);

                if (sumSuppStList[0].LogicalDeleteCode == 0)
                {
                    // 更新モード
                    this.Mode_Label.Text = UPDATE_MODE;

                    // 画面入力許可制御
                    PermitScreenInput(UPDATE_MODE);

                    this.Ok_Button.Visible = true;
                    this.Cancel_Button.Visible = true;
                    this.Delete_Button.Visible = false;
                    this.Revive_Button.Visible = false;

                    // フォーカス設定
                    this.uGrid_SumSuppSt.Focus();
                    this.uGrid_SumSuppSt.Rows[0].Cells[COLUMN_SECTIONCODE].Activate();
                    this.uGrid_SumSuppSt.PerformAction(UltraGridAction.EnterEditMode);
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

                    // フォーカス設定
                    this.Delete_Button.Focus();
                }
            }
        }

        /// <summary>
        /// 画面入力許可制御処理
        /// </summary>
        /// <param name="mode">編集モード</param>
        /// <remarks>
        /// <br>Note       : 編集モードによって画面の入力許可制御を行います。</br>
        /// <br>Programmer : FSI斎藤 和宏</br>
        /// <br>Date       : 2012/08/27</br>
        /// </remarks>
        private void PermitScreenInput(string mode)
        {
            switch (mode)
            {
                case INSERT_MODE:
                    {
                        // 新規モード
                        this.tEdit_SectionCode.Enabled = true;
                        this.SumSectionGuide_Button.Enabled = true;
                        this.tNedit_SupplierCd.Enabled = true;
                        this.SumSuppGuide_Button.Enabled = true;

                        this.uGrid_SumSuppSt.Enabled = true;
                        break;
                    }
                case UPDATE_MODE:
                    {
                        // 更新モード
                        this.tEdit_SectionCode.Enabled = false;
                        this.SumSectionGuide_Button.Enabled = false;
                        this.tNedit_SupplierCd.Enabled = false;
                        this.SumSuppGuide_Button.Enabled = false;

                        this.uGrid_SumSuppSt.Enabled = true;
                        break;
                    }
                case DELETE_MODE:
                    {
                        // 削除モード
                        this.tEdit_SectionCode.Enabled = false;
                        this.SumSectionGuide_Button.Enabled = false;
                        this.tNedit_SupplierCd.Enabled = false;
                        this.SumSuppGuide_Button.Enabled = false;

                        this.uGrid_SumSuppSt.Enabled = false;
                        break;
                    }
            }
        }

        /// <summary>
        /// 仕入先マスタ(総括設定)リスト画面展開処理
        /// </summary>
        /// <param name="sumSuppStList">仕入先マスタ(総括設定)リスト</param>
        /// <remarks>
        /// <br>Note       : 仕入先マスタ(総括設定)リストを画面展開します。</br>
        /// <br>Programmer : FSI斎藤 和宏</br>
        /// <br>Date       : 2012/08/27</br>
        /// </remarks>
        private void SumSuppStListToScreen(List<SumSuppSt> sumSuppStList)
        {
            int rowIndex = 0;

            // 総括拠点・総括仕入先は同じ値が入っているのでループ前に格納
            this.tEdit_SectionCode.Value = sumSuppStList[0].SumSectionCd.Trim();
            this.tEdit_SectionName.DataText = GetSectionName(sumSuppStList[0].SumSectionCd.Trim());
            this.tNedit_SupplierCd.Value = sumSuppStList[0].SumSupplierCd.ToString("000000");
            this.tEdit_SupplierSnm.DataText = GetSupplierSnm(sumSuppStList[0].SumSupplierCd);

            foreach (SumSuppSt sumSuppSt in sumSuppStList)
            {
                if (rowIndex == this.uGrid_SumSuppSt.Rows.Count)
                {
                    // グリッド行追加
                    CreateNewRow(ref this.uGrid_SumSuppSt);
                }

                // 拠点コード
                this.uGrid_SumSuppSt.Rows[rowIndex].Cells[COLUMN_SECTIONCODE].Value = sumSuppSt.SectionCode.Trim();
                this.uGrid_SumSuppSt.Rows[rowIndex].Cells[COLUMN_SECTIONCODE].Tag = sumSuppSt.SectionCode.Trim();
                // 拠点名
                this.uGrid_SumSuppSt.Rows[rowIndex].Cells[COLUMN_SECTIONNAME].Value = GetSectionName(sumSuppSt.SectionCode.Trim());
                // 仕入先
                this.uGrid_SumSuppSt.Rows[rowIndex].Cells[COLUMN_SUPPLIERCD].Value = sumSuppSt.SupplierCode.ToString("000000");
                // 仕入先名
                this.uGrid_SumSuppSt.Rows[rowIndex].Cells[COLUMN_SUPPLIERNM].Value = GetSupplierSnm(sumSuppSt.SupplierCode);

                rowIndex++;
            }
        }

        /// <summary>
        /// 保存データ取得処理
        /// </summary>
        /// <returns>保存データ</returns>
        /// <remarks>
        /// <br>Note       : 画面情報から、保存データを取得します。</br>
        /// <br>Programmer : FSI斎藤 和宏</br>
        /// <br>Date       : 2012/08/27</br>
        /// </remarks>
        private List<SumSuppSt> GetSaveSumSuppStListFromScreen()
        {
            List<SumSuppSt> sumSuppStList = new List<SumSuppSt>();

            for (int rowIndex = 0; rowIndex < this.uGrid_SumSuppSt.Rows.Count; rowIndex++)
            {
                CellsCollection cells = this.uGrid_SumSuppSt.Rows[rowIndex].Cells;

                // 拠点コード・仕入先コードが空白の場合
                if ((CellTextToString(cells[COLUMN_SECTIONCODE].Text) == string.Empty) &&
                    (CellTextToInt(cells[COLUMN_SUPPLIERCD].Text) == 0))
                {
                    continue;
                }
                else
                {
                    SumSuppSt SumSuppSt = new SumSuppSt();

                    // 企業コード
                    SumSuppSt.EnterpriseCode = this._enterpriseCode;
                    // 総括拠点コード
                    SumSuppSt.SumSectionCd = this._sumSectionCode;
                    // 総括仕入先コード
                    SumSuppSt.SumSupplierCd = this._sumSupplierCode;
                    // 拠点コード
                    SumSuppSt.SectionCode = CellTextToString(cells[COLUMN_SECTIONCODE].Text);
                    // 仕入先コード
                    SumSuppSt.SupplierCode = CellTextToInt(cells[COLUMN_SUPPLIERCD].Text);

                    sumSuppStList.Add(SumSuppSt);
                }
            }

            return sumSuppStList;
        }

        /// <summary>
        /// 更新用リスト取得処理
        /// </summary>
        /// <param name="saveList">保存リスト</param>
        /// <param name="deleteList">削除リスト</param>
        /// <remarks>
        /// <br>Note       : 画面情報から、保存リスト・削除リストを取得します。</br>
        /// <br>Programmer : FSI斎藤 和宏</br>
        /// <br>Date       : 2012/08/27</br>
        /// </remarks>
        private void GetUpdateList(out ArrayList saveList, out ArrayList deleteList)
        {
            saveList = new ArrayList();
            deleteList = new ArrayList();

            // 保存用データ取得
            List<SumSuppSt> saveSumSuppStList = GetSaveSumSuppStListFromScreen();

            // 削除リスト作成
            foreach (SumSuppSt sumSuppSt in this._sumSuppStListClone)
            {
                deleteList.Add(sumSuppSt.Clone());
            }

            // 保存リスト作成
            foreach (SumSuppSt sumSuppSt in saveSumSuppStList)
            {
                saveList.Add(sumSuppSt);
            }
        }

        /// <summary>
        /// Key取得処理
        /// </summary>
        /// <param name="sumSuppSt">仕入先マスタ(総括設定)マスタ</param>
        /// <returns>Key</returns>
        /// <remarks>
        /// <br>Note       : 仕入先マスタ(総括設定)からKeyを取得します。</br>
        /// <br>Programmer : FSI斎藤 和宏</br>
        /// <br>Date       : 2012/08/27</br>
        /// </remarks>
        private string GetKey(SumSuppSt sumSuppSt)
        {
            string key = string.Empty;

            // 総括拠点コード(2桁)＋総括仕入先コード(6桁)＋拠点コード(2桁)＋仕入先コード(6桁)
            key = sumSuppSt.SumSectionCd.Trim() +
                  sumSuppSt.SumSupplierCd.ToString("000000") +
                  sumSuppSt.SectionCode.Trim() +
                  sumSuppSt.SupplierCode.ToString("000000");

            return key;
        }

        /// <summary>
        /// 保存処理
        /// </summary>
        /// <returns>ステータス(True:成功 False:失敗)</returns>
        /// <remarks>
        /// <br>Note       : 保存処理を行います。</br>
        /// <br>Programmer : FSI斎藤 和宏</br>
        /// <br>Date       : 2012/08/27</br>
        /// </remarks>
        private bool SaveProc()
        {
            this._isSaveProcess = true;

            // 入力チェック
            bool bStatus = CheckScreenInput();
            if (!bStatus)
            {
                return (false);
            }

            ArrayList saveList;
            ArrayList deleteList;

            // 更新用データ取得
            GetUpdateList(out saveList, out deleteList);

            int status;

            if (deleteList.Count > 0)
            {
                // 削除処理
                status = this._sumSuppStAcs.Delete(deleteList);
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

            // 保存処理
            status = this._sumSuppStAcs.Write(ref saveList);
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

                        this.tEdit_SectionCode.Focus();

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
        /// <br>Programmer	: FSI斎藤 和宏</br>
        /// <br>Date        : 2012/08/27</br>
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
            foreach (SumSuppSt sumSuppSt in this._sumSuppStListClone)
            {
                deleteList.Add(sumSuppSt.Clone());
            }

            // 削除処理
            int status = this._sumSuppStAcs.Delete(deleteList);
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
        /// <br>Programmer	: FSI斎藤 和宏</br>
        /// <br>Date        : 2012/08/27</br>
        /// </remarks>
        private bool LogicalDeleteProc()
        {
            // DataSetから総括拠点・仕入先コードを取得
            string sumSecCode  = ((string)this.Bind_DataSet.Tables[TABLE_MAIN].Rows[this._mainDataIndex][VIEW_SUMSECTIONCODE]).Trim();
            int    sumSuppCode = int.Parse((string)this.Bind_DataSet.Tables[TABLE_MAIN].Rows[this._mainDataIndex][VIEW_SUMSUPPLIERCODE]);

            // 総括拠点コードと総括仕入先コードでインスタンスリストから該当データを取得
            List<SumSuppSt> sumSuppStList = SearchDetailListFromSumCode(sumSecCode, sumSuppCode);

            if (sumSuppStList.Count == 0)
            {
                ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                               "削除対象データが存在しません。",
                               0,
                               MessageBoxButtons.OK,
                               MessageBoxDefaultButton.Button1);

                return (true);
            }
            else if (sumSuppStList[0].LogicalDeleteCode != 0)
            {
                ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                               "選択中のデータは既に削除されています。",
                               0,
                               MessageBoxButtons.OK,
                               MessageBoxDefaultButton.Button1);
                return (true);
            }

            ArrayList logicalList = new ArrayList();
            foreach (SumSuppSt sumSuppSt in sumSuppStList)
            {
                logicalList.Add(sumSuppSt.Clone());
            }

            // 論理削除処理
            int status = this._sumSuppStAcs.LogicalDelete(ref logicalList);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        string key = string.Empty;

                        // mainDataSetに展開
                        SumSuppSt _sumSuppSt = logicalList[0] as SumSuppSt;
                        int mainListIndex = FindMainListIndex(_sumSuppSt);

                        MainToDataSet(_sumSuppSt, mainListIndex);

                        // detailListに展開
                        foreach (SumSuppSt sumSuppSt in logicalList)
                        {
                            key = GetKey(sumSuppSt);
                            int listIndex = this._detailList.FindIndex(delegate(SumSuppSt x)
                            {
                                string key2 = GetKey(x);
                                if (key == key2)
                                {
                                    return (true);
                                }
                                else
                                {
                                    return (false);
                                }
                            });

                            if (listIndex >= 0)
                            {
                                // バッファ更新
                                this._detailList[listIndex] = sumSuppSt.Clone();
                            }
                        }

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
        /// 総括設定情報からMainListのIndexを取得します
        /// </summary>
        /// <param name="sumSuppSt">仕入先マスタ（総括設定）</param>
        /// <returns>MainListのIndex</returns>
        /// <remarks>
        /// <br>Note        : 総括設定情報からMainListのIndexを取得します。</br>
        /// <br>Programmer	: FSI斎藤 和宏</br>
        /// <br>Date        : 2012/08/27</br>
        /// </remarks>
        private int FindMainListIndex(SumSuppSt sumSuppSt)
        {
            int index = 0;

            // mainListからsumSuppStに合致する総括条件を検索
            foreach (KeyValuePair<string, List<int>> mainListInfo in this._mainList)
            {
                foreach (int sumSuppCode in mainListInfo.Value)
                {
                    if (mainListInfo.Key.Trim() == sumSuppSt.SumSectionCd.Trim() &&
                        sumSuppCode == sumSuppSt.SumSupplierCd)
                    {
                        return index;
                    }
                    else
                    {
                        index++;
                    }
                }
            }

            return -1;
        }

        /// <summary>
        /// 総括設定情報からMainListのIndexを取得します(ラッパー)
        /// </summary>
        /// <param name="sumSecCode">総括拠点コード</param>
        /// <param name="sumSuppCode">総括仕入先コード</param>
        /// <returns>MainListのIndex</returns>
        /// <remarks>
        /// <br>Note        : 総括設定情報からMainListのIndexを取得します。</br>
        /// <br>Programmer	: FSI斎藤 和宏</br>
        /// <br>Date        : 2012/08/27</br>
        /// </remarks>
        private int FindMainListIndex(string sumSecCode, int sumSuppCode)
        {
            SumSuppSt sumSuppSt = new SumSuppSt();

            sumSuppSt.SumSectionCd  = sumSecCode.Trim();
            sumSuppSt.SumSupplierCd = sumSuppCode;

            return FindMainListIndex(sumSuppSt);
        }

        /// <summary>
        /// 総括設定情報に紐づくDetailListを取得します
        /// </summary>
        /// <param name="sumSecCode">総括拠点コード</param>
        /// <param name="sumSuppCode">総括仕入先コード</param>
        /// <returns>総括拠点・総括仕入先の子SumSuppStのList</returns>
        /// <remarks>
        /// <br>Note        : 総括設定情報に紐づくDetailListを取得します。</br>
        /// <br>Programmer	: FSI斎藤 和宏</br>
        /// <br>Date        : 2012/08/27</br>
        /// </remarks>
        private List<SumSuppSt> SearchDetailListFromSumCode(string sumSecCode, int sumSuppCode)
        {
            List<SumSuppSt> sumSuppStList = this._detailList.FindAll(delegate(SumSuppSt x)
            {
                if (x.SumSectionCd == sumSecCode &&
                    x.SumSupplierCd == sumSuppCode)
                {
                    return (true);
                }
                else
                {
                    return (false);
                }
            });

            return sumSuppStList;
        }

        /// <summary>
        /// 子情報に紐づくDetailListを取得します
        /// </summary>
        /// <param name="SecCode">子拠点コード</param>
        /// <param name="SuppCode">子仕入先コード</param>
        /// <returns>子拠点・子仕入先のSumSuppStのList</returns>
        /// <remarks>
        /// <br>Note        : 子の設定情報に紐づくDetailListを取得します。</br>
        /// <br>Programmer	: FSI斎藤 和宏</br>
        /// <br>Date        : 2012/08/27</br>
        /// </remarks>
        private List<SumSuppSt> SearchDetailListFromChildCode(string SecCode, int SuppCode)
        {
            List<SumSuppSt> sumSuppStList = this._detailList.FindAll(delegate(SumSuppSt x)
            {
                if (x.SectionCode == SecCode &&
                    x.SupplierCode == SuppCode)
                {
                    return (true);
                }
                else
                {
                    return (false);
                }
            });

            return sumSuppStList;
        }


        /// <summary>
        /// 復活処理
        /// </summary>
        /// <returns>ステータス(True:成功 False:失敗)</returns>
        /// <remarks>
        /// <br>Note       : 復活処理を行います。</br>
        /// <br>Programmer : FSI斎藤 和宏</br>
        /// <br>Date	   : 2012/8/27</br>
        /// </remarks>
        private bool RevivalProc()
        {
            // 復活リスト取得
            ArrayList reviveList = new ArrayList();
            foreach (SumSuppSt sumSuppSt in this._sumSuppStListClone)
            {
                reviveList.Add(sumSuppSt.Clone());
            }

            // 復活処理
            int status = this._sumSuppStAcs.Revival(ref reviveList);
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
        /// <br>Programmer : FSI斎藤 和宏</br>
        /// <br>Date	   : 2012/08/27</br>
        /// </remarks>
        private bool CheckScreenInput()
        {
            string errMsg = string.Empty;
            bool errFlg = false;

            // グリッド内登録可データがあるかフラグ
            bool inputFlg = false;

            // 画面から総括拠点・仕入先コード取得
            string sumSecCd = (string)this.tEdit_SectionCode.GetInt().ToString("00");
            int sumSuppCd = this.tNedit_SupplierCd.GetInt();

            if (sumSecCd == "00") // 総括拠点コード
            {
                errMsg = "総括拠点コードを入力してください。";
                errFlg = true;
                this.tEdit_SectionCode.Focus();
            }
            else if (CheckSectionCode(sumSecCd) == false)
            {
                errMsg = "拠点情報設定マスタに登録されていません。";
                errFlg = true;
                this.tEdit_SectionCode.Focus();
            }
            else if (this.tEdit_SectionName.Text == string.Empty)
            {
                errMsg = "総括拠点コードを入力してください。";
                errFlg = true;
                this.tEdit_SectionCode.Focus();
            }
            else if (sumSuppCd == 0) // 総括仕入先コード
            {
                errMsg = "総括仕入先コードを入力してください。";
                errFlg = true;
                this.tNedit_SupplierCd.Focus();
            }
            else if (this._supplierDic.ContainsKey(sumSuppCd) == false)
            {
                errMsg = "仕入先マスタに登録されていません。";
                errFlg = true;
                this.tNedit_SupplierCd.Focus();
            }
            else // 総括拠点・仕入先問題なし
            {
                for (int rowIndex = 0; rowIndex < this.uGrid_SumSuppSt.Rows.Count; rowIndex++)
                {
                    CellsCollection cells = this.uGrid_SumSuppSt.Rows[rowIndex].Cells;

                    // チェック行の拠点・仕入先コード取得
                    string sectionCode = CellTextToString(cells[COLUMN_SECTIONCODE].Text);
                    int supplierCode = CellTextToInt(cells[COLUMN_SUPPLIERCD].Text);

                    if ((sectionCode == string.Empty) && (supplierCode == 0))
                    {
                        // 共に空白の行はチェックなし
                        continue;
                    }
                    else if (sectionCode == string.Empty)
                    {
                        CheckError(rowIndex, COLUMN_SECTIONCODE);
                        errMsg = "拠点コードを入力してください。";
                        errFlg = true;
                        break;
                    }
                    else if (CheckSectionCode(sectionCode) == false)
                    {
                        CheckError(rowIndex, COLUMN_SECTIONCODE);
                        errMsg = "拠点情報設定マスタに登録されていません。";
                        errFlg = true;
                        break;
                    }
                    else if (supplierCode == 0)
                    {
                        CheckError(rowIndex, COLUMN_SUPPLIERCD);
                        errMsg = "仕入先コードを入力してください。";
                        errFlg = true;
                        break;
                    }
                    else if (CheckSupplierCode(supplierCode, rowIndex, ref errMsg) == false)
                    {
                        // 仕入先コードチェック
                        CheckError(rowIndex, COLUMN_SUPPLIERCD);
                        errFlg = true;
                        break;
                    }
                    else
                    {
                        // エラー無
                        inputFlg = true; // 入力データありにセット
                    }
                }
                if (!inputFlg && !errFlg)
                {
                    // 1件も入力されていなかった場合
                    CheckError(0, COLUMN_SECTIONCODE);
                    errMsg = "拠点コード、仕入先コードの登録がありません。";
                    errFlg = true;
                }
            }

            if (errFlg)
            {
                ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                               errMsg,
                               -1,
                               MessageBoxButtons.OK,
                               MessageBoxDefaultButton.Button1);
                return false;
            }
            else
            {
                this._isSaveProcess = false;
                return true;
            }
        }

        /// <summary>
        /// グリッド入力情報エラー時処理
        /// </summary>
        /// <param name="index">エラー発生行番号</param>
        /// <param name="columnName">エラー発生列名</param>
        /// <remarks>
        /// <br>Note       : グリッド入力情報にエラーがあった場合の処理。</br>
        /// <br>Programmer : FSI斎藤 和宏</br>
        /// <br>Date	   : 2012/08/27</br>
        /// </remarks>
        private void CheckError(int index, string columnName)
        {
            this.uGrid_SumSuppSt.AfterExitEditMode -= uGrid_SumSuppSt_AfterExitEditMode;
            this.uGrid_SumSuppSt.Focus();
            this.uGrid_SumSuppSt.Rows[index].Cells[columnName].Activate();
            this.uGrid_SumSuppSt.PerformAction(UltraGridAction.EnterEditMode);
            this.uGrid_SumSuppSt.AfterExitEditMode += uGrid_SumSuppSt_AfterExitEditMode;
        }

        /// <summary>
        /// 画面情報比較処理
        /// </summary>
        /// <returns>ステータス(True:変更なし False:変更あり)</returns>
        /// <remarks>
        /// <br>Note       : 画面読込時と画面終了時のデータを比較します。</br>
        /// <br>Programmer : FSI斎藤 和宏</br>
        /// <br>Date	   : 2012/08/27</br>
        /// </remarks>
        private bool CompareOriginalScreen()
        {
            // 新規モードで起動し最初から入力した場合
            if ((this._sumSuppStListClone.Count == 0) && (this.Mode_Label.Text == INSERT_MODE))
            {
                if (this._sumSectionCode != string.Empty &&
                    this._sumSupplierCode != 0)
                {
                    return (false);
                }
            }

            // 保存データ取得
            List<SumSuppSt> saveSumSuppStList = new List<SumSuppSt>();
            try
            {
                saveSumSuppStList = GetSaveSumSuppStListFromScreen();
            }
            catch
            {
                return (false);
            }

            // 画面読込時と保存データの件数が違う場合
            if (this._sumSuppStListClone.Count != saveSumSuppStList.Count)
            {
                return (false);
            }

            string key;
            bool sameFlg = false;
            foreach (SumSuppSt sumSuppSt in this._sumSuppStListClone)
            {
                // Key取得
                key = GetKey(sumSuppSt);

                // 画面読込時のデータが無い場合
                foreach (SumSuppSt saveSumSupp in saveSumSuppStList)
                {
                    string saveKey = GetKey(saveSumSupp);
                    if (key == saveKey)
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
        /// 仕入先コードチェック処理
        /// </summary>
        /// <param name="supplierCode">仕入先コード</param>
        /// <param name="rowIndex">グリッド内行番号</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 仕入先コードとして入力できるかチェックします。</br>
        /// <br>Programmer : FSI斎藤 和宏</br>
        /// <br>Date	   : 2012/08/27</br>
        /// </remarks>
        private bool CheckSupplierCode(int supplierCode, int rowIndex, ref string errMsg)
        {
            // 入力した仕入先コードがマスタに存在するか
            if (!this._supplierDic.ContainsKey(supplierCode))
            {
                errMsg = "仕入先マスタに登録されていません。";
                return false;
            }

            // 同じ行の拠点コードを取得
            string SectionCode = StrObjectToString(this.uGrid_SumSuppSt.Rows[rowIndex].Cells[COLUMN_SECTIONCODE].Value);
            
            // 編集中画面に同じ行のデータが存在しないか
            for (int index = 0; index < this.uGrid_SumSuppSt.Rows.Count; index++)
            {
                if (index == rowIndex)
                {
                    continue;
                }

                // 拠点コード・仕入先コード取得
                string _checkSecCode = StrObjectToString(this.uGrid_SumSuppSt.Rows[index].Cells[COLUMN_SECTIONCODE].Value);
                int _checkSuppCd = StrObjectToInt(this.uGrid_SumSuppSt.Rows[index].Cells[COLUMN_SUPPLIERCD].Value);

                if (SectionCode  == _checkSecCode &&
                    supplierCode == _checkSuppCd)
                {
                    errMsg = "既に登録されています。";
                    return (false);
                }
            }

            // 同じ行の拠点コード-入力した仕入先コードのペアが存在していないか
            // 総括拠点コード仕入先を取得
            string sumSecCode = (string)this.tEdit_SectionCode.GetInt().ToString("00");
            int sumSuppCode   = this.tNedit_SupplierCd.GetInt();
            this._sumSuppTotalDay = GetTotalDay(sumSuppCode);

            // ①チェックする拠点-仕入先が総括拠点-仕入先と一致しているかチェック
            if (!(sumSecCode == SectionCode && sumSuppCode == supplierCode))
            {
                // 親と同一で無い場合は
                // ②チェックする値が子のデータに存在するかチェック
                List<SumSuppSt> sumSuppStList = SearchDetailListFromChildCode(SectionCode, supplierCode);

                if (sumSuppStList.Count > 1)
                {
                    // 2件以上存在することはあり得ないが一応エラーハンドリングする
                    errMsg = "既に登録されています。";
                    return (false);
                }
                else if (sumSuppStList.Count == 1)
                {
                    // 子のデータに存在する
                    // ③HITしたデータの親とチェック値の親を比較
                    if ( !(sumSuppStList[0].SumSectionCd == sumSecCode &&
                        sumSuppStList[0].SumSupplierCd == sumSuppCode))
                    {
                        // 一致しなければ別の子として登録されている
                        errMsg = "既に登録されています。";
                        return (false);
                    }
                }
                else
                {
                    // 子には同じデータ無し 親を検索
                    int mainListIndex = FindMainListIndex(SectionCode, supplierCode);

                    if (mainListIndex != -1)
                    {
                        // 親として登録されている
                        errMsg = "既に登録されています。";
                        return (false);
                    }
                }
            }

            // 仕入先締日が総括仕入先締日と一致しているか
            int suppTotalDay = GetTotalDay(supplierCode);

            if (this._sumSuppTotalDay != 0 &&
                suppTotalDay != this._sumSuppTotalDay)
                {
                    errMsg = "総括仕入先と締日が異なります。";
                    return false;
                }

            return (true);
        }

        /// <summary>
        /// グリッドの編集前処理
        /// </summary>
        /// <returns>true:グリッドへ移動可 false:グリッドへ移動不可</returns>
        /// <remarks>
        /// <br>Note       : グリッドの編集前準備処理を行います。</br>
        /// <br>             総括仕入先コードからのフォーカス移動時、 </br>
        /// <br>             総括仕入先コードのガイド入力時に呼ばれます </br>
        /// <br>Programmer : FSI斎藤 和宏</br>
        /// <br>Date	   : 2012/08/27</br>
        /// </remarks>
        private bool CheckBeforeEnterGrid()
        {
            bool ret = false;

            // 画面から総括拠点・総括仕入先コード取得
            string sumSectionCode = (string)this.tEdit_SectionCode.GetInt().ToString("00");
            int sumSupplierCode = this.tNedit_SupplierCd.GetInt();

            // 総括拠点が入力済でありかつ既存の総括拠点である場合
            if (this.tEdit_SectionName.Text != string.Empty &&
                this._mainList.ContainsKey(sumSectionCode) &&
                this._mainList[sumSectionCode].Contains(sumSupplierCode))
            {
                // 既存の総括拠点・総括仕入先が入力された場合は、編集確認メッセージを表示する
                DialogResult res = ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                                                  "入力されたコードの仕入先総括情報が既に登録されています" + Environment.NewLine +
                                                  "編集を行いますか？",
                                                  0,
                                                  MessageBoxButtons.YesNo,
                                                  MessageBoxDefaultButton.Button1);

                if (res == DialogResult.Yes)
                {
                    // 画面から総括拠点コード仕入先コードを取得
                    this._sumSectionCode = sumSectionCode;
                    this._sumSupplierCode = sumSupplierCode;
                    this._sumSuppTotalDay = GetTotalDay(sumSupplierCode);

                    // 編集モードにする
                    this._mainDataIndex = FindMainListIndex(sumSectionCode, sumSupplierCode);
                    ScreenReconstruction();

                    ret = true;
                }
                else
                {
                    this.tNedit_SupplierCd.Clear();
                    this.tEdit_SupplierSnm.Clear();
                    ret = false;
                }
            }
            else
            {
                // 既存の総括拠点-仕入先以外が入力された場合
                List<SumSuppSt> sumSuppStList = SearchDetailListFromChildCode(sumSectionCode, sumSupplierCode);

                if (sumSuppStList.Count > 0)
                {
                    // 親に入力した情報が子に登録されている場合
                    ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                                   "既に登録されています。",
                                   -1,
                                   MessageBoxButtons.OK,
                                   MessageBoxDefaultButton.Button1);

                    this.tNedit_SupplierCd.Clear();
                    this.tEdit_SupplierSnm.Clear();
                    ret = false;
                }
                else
                {
                    // 新規モード
                    this._sumSectionCode = sumSectionCode;
                    this._sumSupplierCode = sumSupplierCode;
                    this._sumSuppTotalDay = GetTotalDay(sumSupplierCode);

                    // 総括拠点・総括仕入先が全て入力済みで
                    // グリッドの1行目が空の場合
                    if ( !string.IsNullOrEmpty((string)this.tEdit_SectionCode.Value) &&
                         !string.IsNullOrEmpty((string)this.tEdit_SectionName.Value) &&
                         this._secInfoSetDic.ContainsKey((string)this.tEdit_SectionCode.Value) &&
                         !string.IsNullOrEmpty((string)this.tNedit_SupplierCd.Value) &&
                         this._supplierDic.ContainsKey(this.tNedit_SupplierCd.GetInt()) &&
                         string.IsNullOrEmpty((string)this.uGrid_SumSuppSt.Rows[0].Cells[COLUMN_SECTIONCODE].Value) &&
                         string.IsNullOrEmpty((string)this.uGrid_SumSuppSt.Rows[0].Cells[COLUMN_SECTIONNAME].Value) &&
                         string.IsNullOrEmpty((string)this.uGrid_SumSuppSt.Rows[0].Cells[COLUMN_SUPPLIERCD].Value) &&
                         string.IsNullOrEmpty((string)this.uGrid_SumSuppSt.Rows[0].Cells[COLUMN_SUPPLIERNM].Value))
                    {

                        // 1行目に総括拠点・総括仕入先と同じコードを入れる
                        this.uGrid_SumSuppSt.Rows[0].Cells[COLUMN_SECTIONCODE].Value = sumSectionCode;
                        this.uGrid_SumSuppSt.Rows[0].Cells[COLUMN_SECTIONCODE].Tag   = sumSectionCode;
                        this.uGrid_SumSuppSt.Rows[0].Cells[COLUMN_SECTIONNAME].Value = GetSectionName(sumSectionCode);
                        this.uGrid_SumSuppSt.Rows[0].Cells[COLUMN_SUPPLIERCD].Value  = sumSupplierCode.ToString("000000");
                        this.uGrid_SumSuppSt.Rows[0].Cells[COLUMN_SUPPLIERCD].Tag    = sumSupplierCode.ToString("000000");
                        this.uGrid_SumSuppSt.Rows[0].Cells[COLUMN_SUPPLIERNM].Value  = GetSupplierSnm(sumSupplierCode);
                    }
                    ret = true;
                }
            }

            return ret;
        }

        /// <summary>
        /// 拠点コードチェック処理
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 拠点コードがマスタに存在するかチェックします。</br>
        /// <br>Programmer : FSI斎藤 和宏</br>
        /// <br>Date       : 2012/08/27</br>
        /// </remarks>
        private bool CheckSectionCode(string sectionCode)
        {
            if (this._secInfoSetDic.ContainsKey(sectionCode.Trim()) == false)
            {
                return (false);
            }
            else
            {
                return (true);
            }
        }

        /// <summary>
        /// 排他処理
        /// </summary>
        /// <param name="status">STATUS</param>
        /// <remarks>
        /// <br>Note       : 排他処理を行います</br>
        /// <br>Programmer : FSI斎藤 和宏</br>
        /// <br>Date       : 2012/08/27</br>
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
        /// <br>Programmer : FSI斎藤 和宏</br>
        /// <br>Date       : 2012/08/27</br>
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
        /// <br>Programmer : FSI斎藤 和宏</br>
        /// <br>Date       : 2012/08/27</br>
        /// </remarks>
        private DialogResult ShowMessageBox(emErrorLevel errLevel, string methodName, string message, int status, MessageBoxButtons msgButton)
        {
            DialogResult dialogResult;
            dialogResult = TMsgDisp.Show(this, 						        // 親ウィンドウフォーム
                                         errLevel,			                // エラーレベル
                                         this.Name,						    // プログラム名称
                                         ASSEMBLY_ID, 		  　　			// アセンブリID
                                         methodName,						// 処理名称
                                         string.Empty,					            // オペレーション
                                         message,	                        // 表示するメッセージ
                                         status,							// ステータス値
                                         this._sumSuppStAcs,			    // エラーが発生したオブジェクト
                                         msgButton,         			  	// 表示するボタン
                                         MessageBoxDefaultButton.Button1);	// 初期表示ボタン

            return dialogResult;
        }

        /// <summary>
        /// 行クリア処理
        /// </summary>
        /// <param name="rowIndex">行インデックス</param>
        /// <remarks>
        /// <br>Note       : 対象行のデータをクリアします。</br>
        /// <br>Programmer : FSI斎藤 和宏</br>
        /// <br>Date       : 2012/08/27</br>
        /// </remarks>
        private void ClearRow(int rowIndex)
        {
            this.uGrid_SumSuppSt.Rows[rowIndex].Cells[COLUMN_SECTIONCODE].Value = string.Empty;
            this.uGrid_SumSuppSt.Rows[rowIndex].Cells[COLUMN_SECTIONNAME].Value = string.Empty;
            this.uGrid_SumSuppSt.Rows[rowIndex].Cells[COLUMN_SUPPLIERCD].Value = string.Empty;
            this.uGrid_SumSuppSt.Rows[rowIndex].Cells[COLUMN_SUPPLIERNM].Value = string.Empty;
            this.uGrid_SumSuppSt.Rows[rowIndex].Cells[COLUMN_SECTIONCODE].Tag = string.Empty;
            this.uGrid_SumSuppSt.Rows[rowIndex].Cells[COLUMN_SUPPLIERCD].Tag = string.Empty;
        }

        /// <summary>
        /// 新規行作成処理
        /// </summary>
        /// <param name="uGrid">グリッド</param>
        /// <remarks>
        /// <br>Note       : グリッドに行を追加します。</br>
        /// <br>Programmer : FSI斎藤 和宏</br>
        /// <br>Date       : 2012/08/27</br>
        /// </remarks>
        private void CreateNewRow(ref UltraGrid uGrid)
        {
            // 行追加
            uGrid.DisplayLayout.Bands[0].AddNew();

            // 行番号設定
            uGrid.Rows[uGrid.Rows.Count - 1].Cells[COLUMN_NO].Value = uGrid.Rows.Count;

            uGrid.Rows[uGrid.Rows.Count - 1].Cells[COLUMN_SECTIONCODE].Tag = string.Empty;
            uGrid.Rows[uGrid.Rows.Count - 1].Cells[COLUMN_SUPPLIERCD].Tag = string.Empty;
        }

        /// <summary>
        /// 変換処理(object→string)
        /// </summary>
        /// <param name="targetValue">変換対象object</param>
        /// <returns>文字列</returns>
        /// <remarks>
        /// <br>Note       : object型をstringに変換します。</br>
        /// <br>Programmer : FSI斎藤 和宏</br>
        /// <br>Date       : 2012/08/27</br>
        /// </remarks>
        private string StrObjectToString(object targetValue)
        {
            if ((targetValue == DBNull.Value) || (targetValue == null) || ((string)targetValue == string.Empty))
            {
                return string.Empty;
            }

            return (string)targetValue;
        }

        /// <summary>
        /// 変換処理(object→int)
        /// </summary>
        /// <param name="targetValue">変換対象object</param>
        /// <returns>数値</returns>
        /// <remarks>
        /// <br>Note       : object型をintに変換します。</br>
        /// <br>Programmer : FSI斎藤 和宏</br>
        /// <br>Date       : 2012/08/27</br>
        /// </remarks>
        private int StrObjectToInt(object targetValue)
        {
            if ((targetValue == DBNull.Value) || (targetValue == null) || ((string)targetValue == string.Empty) || (int.Parse((string)targetValue) == 0))
            {
                return 0;
            }

            return int.Parse((string)targetValue);
        }

        private string CellTextToString(string cellText)
        {
            if ((cellText == null) || (cellText.Trim() == string.Empty))
            {
                return string.Empty;
            }

            return cellText.Trim().PadLeft(2, '0');
        }

        private int CellTextToInt(string cellText)
        {
            if ((cellText == null) || (cellText.Trim() == string.Empty))
            {
                return 0;
            }

            return int.Parse(cellText.Trim());
        }

        /// <summary>
        /// NextFocus 設定処理
        /// </summary>
        /// <param name="uGrid">対象グリッド</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : グリッド内でEnterキーが押下された時のNextFocus設定を行います。</br>
        /// <br>Programmer : FSI斎藤 和宏</br>
        /// <br>Date	   : 2012/08/27</br>
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
                    uGrid.Rows[0].Cells[COLUMN_SECTIONCODE].Activate();
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

            // 編集モード終了
            uGrid.PerformAction(UltraGridAction.ExitEditMode);

            e.NextCtrl = null;

            switch (columnIndex)
            {
                case 1:   // 拠点コード
                    {
                        if (!this._checkSectionFlg)
                        {
                            // 拠点コードにフォーカス
                            uGrid.Rows[rowIndex].Cells[COLUMN_SECTIONNAME].Value = (string)string.Empty;
                            uGrid.Rows[rowIndex].Cells[COLUMN_SECTIONCODE].Activate();
                            uGrid.PerformAction(UltraGridAction.EnterEditMode);
                        }
                        else
                        {
                            // 拠点名取得
                            string sectionName = StrObjectToString(uGrid.Rows[rowIndex].Cells[COLUMN_SECTIONNAME].Value);

                            if (sectionName == string.Empty)
                            {
                                // 拠点ガイドにフォーカス
                                uGrid.Rows[rowIndex].Cells[COLUMN_SECTIONGUIDE].Activate();
                            }
                            else
                            {
                                // 仕入先コードにフォーカス
                                uGrid.Rows[rowIndex].Cells[COLUMN_SUPPLIERCD].Activate();
                            }
                            uGrid.PerformAction(UltraGridAction.EnterEditMode);
                        }
                        return;
                    }
                case 3:       // 拠点ガイド
                    {
                        // 仕入先コードにフォーカス
                        uGrid.Rows[rowIndex].Cells[COLUMN_SUPPLIERCD].Activate();
                        uGrid.PerformAction(UltraGridAction.EnterEditMode);
                        return;
                    }
                case 4:         // 仕入先コード
                    {
                        if (!this._checkSupplierFlg)
                        {
                            // 仕入先コードにフォーカス
                            uGrid.Rows[rowIndex].Cells[COLUMN_SUPPLIERNM].Value = (string)string.Empty;
                            uGrid.Rows[rowIndex].Cells[COLUMN_SUPPLIERCD].Activate();
                            uGrid.PerformAction(UltraGridAction.EnterEditMode);
                        }
                        else
                        {
                            // 仕入先コード取得
                            int supplierCd = StrObjectToInt(uGrid.Rows[rowIndex].Cells[COLUMN_SUPPLIERCD].Value);

                            if (supplierCd == 0 || !this._supplierDic.ContainsKey(supplierCd))
                            {
                                // 仕入先ガイドにフォーカス
                                uGrid.Rows[rowIndex].Cells[COLUMN_SUPPLIERGUIDE].Activate();
                            }
                            else
                            {

                                if (rowIndex == uGrid.Rows.Count - 1)
                                {
                                    // 最終行なら保存ボタンにフォーカス
                                    e.NextCtrl = this.Ok_Button;
                                }
                                else
                                {
                                    // 拠点コードにフォーカス
                                    uGrid.Rows[rowIndex + 1].Cells[COLUMN_SECTIONCODE].Activate();
                                    uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                }
                            }
                        }

                        return;
                    }
                case 6:      // 仕入先ガイド
                    {
                        if (rowIndex == uGrid.Rows.Count - 1)
                        {
                            // 保存ボタンにフォーカス
                            e.NextCtrl = this.Ok_Button;
                        }
                        else
                        {
                            // 拠点コードにフォーカス
                            uGrid.Rows[rowIndex + 1].Cells[COLUMN_SECTIONCODE].Activate();
                            uGrid.PerformAction(UltraGridAction.EnterEditMode);
                        }
                        return;
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
        /// <br>Programmer : FSI斎藤 和宏</br>
        /// <br>Date	   : 2012/08/27</br>
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

            // 編集モード終了
            uGrid.PerformAction(UltraGridAction.ExitEditMode);

            e.NextCtrl = null;

            switch (columnIndex)
            {
                case 1:   // 拠点コード
                    {
                        if (!this._checkSectionFlg)
                        {
                            // 拠点コードにフォーカス
                            uGrid.Rows[rowIndex].Cells[COLUMN_SECTIONCODE].Activate();
                            uGrid.PerformAction(UltraGridAction.EnterEditMode);
                        }
                        else
                        {
                            if (rowIndex == 0)
                            {
                                if (this.Mode_Label.Text == INSERT_MODE)
                                {
                                    // 新規モード時は総括仕入先コードにフォーカスセット
                                    e.NextCtrl = this.tNedit_SupplierCd;
                                }
                                else
                                {
                                    // 更新モード時は閉じるボタンにフォーカスセット
                                    e.NextCtrl = this.Cancel_Button;
                                }
                            }
                            else
                            {
                                // 仕入先コード取得
                                int supplierCd = StrObjectToInt(uGrid.Rows[rowIndex - 1].Cells[COLUMN_SUPPLIERCD].Value);

                                if (supplierCd == 0 || !this._supplierDic.ContainsKey(supplierCd))
                                {
                                    // 仕入先ガイドにフォーカス
                                    uGrid.Rows[rowIndex - 1].Cells[COLUMN_SUPPLIERGUIDE].Activate();
                                }
                                else
                                {
                                    // 仕入先コードにフォーカス
                                    uGrid.Rows[rowIndex - 1].Cells[COLUMN_SUPPLIERCD].Activate();
                                }

                                uGrid.PerformAction(UltraGridAction.EnterEditMode);
                            }
                        }

                        return;
                    }
                case 3:       // 拠点ガイド
                    {
                        // 拠点コードにフォーカス
                        uGrid.Rows[rowIndex].Cells[COLUMN_SECTIONCODE].Activate();
                        uGrid.PerformAction(UltraGridAction.EnterEditMode);
                        return;
                    }
                case 4:         // 仕入先コード
                    {
                        if (!this._checkSupplierFlg)
                        {
                            // 仕入先コードにフォーカス
                            uGrid.Rows[rowIndex].Cells[COLUMN_SUPPLIERCD].Activate();
                        }
                        else
                        {
                            // 拠点名取得
                            string sectionName = StrObjectToString(uGrid.Rows[rowIndex].Cells[COLUMN_SECTIONCODE].Value);

                            if (sectionName == string.Empty)
                            {
                                // 拠点ガイドにフォーカス
                                uGrid.Rows[rowIndex].Cells[COLUMN_SECTIONGUIDE].Activate();
                            }
                            else
                            {
                                // 拠点コードにフォーカス
                                uGrid.Rows[rowIndex].Cells[COLUMN_SECTIONCODE].Activate();
                            }
                        }

                        uGrid.PerformAction(UltraGridAction.EnterEditMode);
                        return;
                    }
                case 6:      // 仕入先ガイド
                    {
                        // 仕入先コードにフォーカス
                        uGrid.Rows[rowIndex].Cells[COLUMN_SUPPLIERCD].Activate();
                        uGrid.PerformAction(UltraGridAction.EnterEditMode);
                        return;
                    }
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
        /// <br>Programmer : FSI斎藤 和宏</br>
        /// <br>Date	   : 2012/08/27</br>
        /// </remarks>
        private void PMKAK09000UA_Load(object sender, EventArgs e)
        {
            // 画面初期設定
            SetScreenInitialSetting();

            // 画面クリア
            ScreenClear();
        }

        /// <summary>
        /// FormClosing イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : フォームを閉じる前に発生します。</br>
        /// <br>Programmer : FSI斎藤 和宏</br>
        /// <br>Date	   : 2012/08/27</br>
        /// </remarks>
        private void PMKAK09000UA_FormClosing(object sender, FormClosingEventArgs e)
        {
            // クローズ時にグリッド情報が残っているので消去
            this.ScreenClear();

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
        /// <br>Programmer : FSI斎藤 和宏</br>
        /// <br>Date	   : 2012/08/27</br>
        /// </remarks>
        private void PMKAK09000UA_VisibleChanged(object sender, EventArgs e)
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
        /// Button_Click イベント(総括拠点ガイドボタン)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : 総括拠点ガイドボタンがクリックされた時に発生します。</br>
        /// <br>Programmer : FSI斎藤 和宏</br>
        /// <br>Date	   : 2012/08/27</br>
        /// </remarks>
        private void SumSectionGuide_Button_Click(object sender, EventArgs e)
        {
            int status = -1;

            SecInfoSet secInfoSet;

            status = this._secInfoSetAcs.ExecuteGuid(this._enterpriseCode, false, out secInfoSet);
            if (status == 0)
            {
                // 拠点コード
                this.tEdit_SectionCode.Value = secInfoSet.SectionCode.Trim();
                // 拠点名
                this.tEdit_SectionName.Value = GetSectionName(secInfoSet.SectionCode.Trim());
            }

            this.tNedit_SupplierCd.Focus();
        }

        /// <summary>
        /// Button_Click イベント(総括仕入先ガイドボタン)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : 総括仕入先ガイドボタンがクリックされた時に発生します。</br>
        /// <br>Programmer : FSI斎藤 和宏</br>
        /// <br>Date	   : 2012/08/27</br>
        /// </remarks>
        private void SumSuppGuide_Button_Click(object sender, EventArgs e)
        {
            int status = -1;

            // 仕入先のオブジェクト
            Supplier SupplierInfo = new Supplier();

            // 仕入先ガイド起動
            status = this._supplierAcs.ExecuteGuid(out SupplierInfo, this._enterpriseCode, string.Empty);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // 総括仕入先コード
                this.tNedit_SupplierCd.Value = (string)SupplierInfo.SupplierCd.ToString("000000");
                this.tEdit_SupplierSnm.Value = SupplierInfo.SupplierSnm.ToString();

                if (!CheckBeforeEnterGrid())
                {
                    this.tNedit_SupplierCd.Focus();
                }
                else
                {
                    // フォーカス設定
                    this.uGrid_SumSuppSt.Focus();
                    this.uGrid_SumSuppSt.Rows[0].Cells[COLUMN_SECTIONCODE].Activate();
                    this.uGrid_SumSuppSt.PerformAction(UltraGridAction.EnterEditMode);
                }
            }
        }

        /// <summary>
        /// Button_Click イベント(保存ボタン)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : 保存ボタンがクリックされた時に発生します。</br>
        /// <br>Programmer : FSI斎藤 和宏</br>
        /// <br>Date	   : 2012/08/27</br>
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
        /// <br>Programmer : FSI斎藤 和宏</br>
        /// <br>Date	   : 2012/08/27</br>
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
                                                      string.Empty,
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
        /// <br>Programmer	: FSI斎藤 和宏</br>
        /// <br>Date        : 2012/08/27</br>
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
        /// <br>Programmer : FSI斎藤 和宏</br>
        /// <br>Date	   : 2012/08/27</br>
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
        /// BeforeEnterEditMode イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : 編集モードに入る前に発生します。</br>
        /// <br>Programmer : FSI斎藤 和宏</br>
        /// <br>Date       : 2012/08/27</br>
        /// </remarks>
        private void uGrid_SumSuppSt_BeforeEnterEditMode(object sender, CancelEventArgs e)
        {
            _beforeCellText = string.Empty;

            UltraGrid uGrid = (UltraGrid)sender;

            if (uGrid.ActiveCell == null)
            {
                return;
            }

            if ((uGrid.ActiveCell.Value == DBNull.Value) || ((string)uGrid.ActiveCell.Value == string.Empty))
            {
                return;
            }

            // 前回値退避
            _beforeCellText = StrObjectToString(uGrid.ActiveCell.Value);
            
            int suppValue = int.Parse((string)uGrid.ActiveCell.Value);

            // ゼロ詰め解除
            uGrid.ActiveCell.Value = suppValue.ToString();

        }

        /// <summary>
        /// AfterExitEditMode イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : 編集モードが終了した時に発生します。</br>
        /// <br>Programmer : FSI斎藤 和宏</br>
        /// <br>Date	   : 2012/08/27</br>
        /// </remarks>
        private void uGrid_SumSuppSt_AfterExitEditMode(object sender, EventArgs e)
        {
            UltraGrid uGrid = (UltraGrid)sender;

            if (uGrid.ActiveCell == null)
            {
                return;
            }

            bool errFlg = false;
            string errMsg = string.Empty;

            switch (uGrid.ActiveCell.Column.Key)
            {
                case COLUMN_SECTIONCODE:
                    {
                        this._checkSectionFlg = true;

                        // ゼロ詰め
                        uGrid.ActiveCell.Value = this.uiSetControl1.GetZeroPaddedText(uGrid.ActiveCell.Column.Key, uGrid.ActiveCell.Value.ToString());

                        // 拠点コード取得
                        string sectionCode = StrObjectToString(uGrid.ActiveCell.Value);

                        if (sectionCode == string.Empty)
                        {
                            if (StrObjectToString(uGrid.ActiveCell.Tag) != string.Empty)
                            {
                                // 行クリア
                                ClearRow(uGrid_SumSuppSt.ActiveCell.Row.Index);
                            }
                        }
                        else
                        {
                            // 前回入力ありで、かつ変更された場合
                            if (!string.IsNullOrEmpty(_beforeCellText) && _beforeCellText != sectionCode)
                            {
                                // 仕入先クリア
                                uGrid.Rows[uGrid.ActiveCell.Row.Index].Cells[COLUMN_SUPPLIERCD].Value = string.Empty;
                                uGrid.Rows[uGrid.ActiveCell.Row.Index].Cells[COLUMN_SUPPLIERNM].Value = string.Empty;
                                uGrid.Rows[uGrid.ActiveCell.Row.Index].Cells[COLUMN_SUPPLIERCD].Tag = string.Empty;
                            }

                            bool bStatus = CheckSectionCode(sectionCode);
                            if (!bStatus)
                            {
                                this._checkSectionFlg = false;
                                errFlg = true;
                                errMsg = "拠点情報設定マスタに登録されていません。";
                            }

                            // 拠点名取得
                            uGrid.Rows[uGrid.ActiveCell.Row.Index].Cells[COLUMN_SECTIONNAME].Value = GetSectionName(sectionCode);

                            uGrid.Rows[uGrid.ActiveCell.Row.Index].Cells[COLUMN_SECTIONCODE].Tag = sectionCode;

                            if (uGrid.ActiveCell.Row.Index == uGrid.Rows.Count - 1)
                            {
                                // 最終行だった場合、行追加
                                CreateNewRow(ref uGrid);
                            }
                        }

                        break;
                    }
                case COLUMN_SUPPLIERCD:
                    {
                        this._checkSupplierFlg = true;

                        // ゼロ詰め
                        uGrid.ActiveCell.Value = this.uiSetControl1.GetZeroPaddedText(uGrid.ActiveCell.Column.Key, uGrid.ActiveCell.Value.ToString());

                        int supplierCode = StrObjectToInt(uGrid.ActiveCell.Value);

                        if (supplierCode == 0)
                        {
                            if (StrObjectToInt(uGrid.ActiveCell.Tag) != 0)
                            {
                                // 行クリア
                                ClearRow(uGrid_SumSuppSt.ActiveCell.Row.Index);
                            }
                        }
                        else
                        {
                            bool bStatus = CheckSupplierCode(supplierCode, uGrid.ActiveCell.Row.Index, ref errMsg);

                            if (!bStatus)
                            {
                                this._checkSupplierFlg = false;
                                errFlg = true;
                            }
                            else
                            {

                                // 仕入先名取得
                                uGrid.Rows[uGrid.ActiveCell.Row.Index].Cells[COLUMN_SUPPLIERNM].Value = GetSupplierSnm(supplierCode);

                                uGrid.Rows[uGrid.ActiveCell.Row.Index].Cells[COLUMN_SUPPLIERCD].Tag = supplierCode.ToString("000000");

                                if (uGrid.ActiveCell.Row.Index == uGrid.Rows.Count - 1)
                                {
                                    // 最終行だった場合、行追加
                                    CreateNewRow(ref uGrid);
                                }
                            }
                        }

                        break;
                    }
            }

            if (errFlg)
            {
                if (!this._isSaveProcess)
                {
                    ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                                   errMsg,
                                   -1,
                                   MessageBoxButtons.OK,
                                   MessageBoxDefaultButton.Button1);
                }
            }

            this._isSaveProcess = false;
        }

        /// <summary>
        /// KeyDown イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : グリッドアクティブ時にキーが押されたタイミングで発生します。</br>
        /// <br>Programmer : FSI斎藤 和宏</br>
        /// <br>Date	   : 2012/08/27</br>
        /// </remarks>
        private void uGrid_SumSuppSt_KeyDown(object sender, KeyEventArgs e)
        {
            UltraGrid uGrid = (UltraGrid)sender;

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

            switch (e.KeyCode)
            {
                case Keys.Up:
                    {
                        e.Handled = true;
                        
                        // 編集モード終了
                        uGrid.PerformAction(UltraGridAction.ExitEditMode);

                        if ((columnIndex == 1) && (this._checkSectionFlg == false))
                        {
                            uGrid.PerformAction(UltraGridAction.EnterEditMode);
                            return;
                        }
                        else if ((columnIndex == 4) && (this._checkSupplierFlg == false))
                        {
                            uGrid.PerformAction(UltraGridAction.EnterEditMode);
                            return;
                        }

                        if (rowIndex == 0)
                        {
                            // 総括仕入先コードにフォーカス
                            this.tNedit_SupplierCd.Focus();
                        }
                        else
                        {
                            uGrid.Rows[rowIndex - 1].Cells[columnIndex].Activate();
                            uGrid.PerformAction(UltraGridAction.EnterEditMode);
                        }
                        break;
                    }
                case Keys.Down:
                    {
                        e.Handled = true;

                        // 編集モード終了
                        uGrid.PerformAction(UltraGridAction.ExitEditMode);

                        if ((columnIndex == 1) && (this._checkSectionFlg == false))
                        {
                            uGrid.PerformAction(UltraGridAction.EnterEditMode);
                            return;
                        }
                        else if ((columnIndex == 4) && (this._checkSupplierFlg == false))
                        {
                            uGrid.PerformAction(UltraGridAction.EnterEditMode);
                            return;
                        }

                        if (rowIndex == uGrid.Rows.Count - 1)
                        {
                            // 保存ボタンにフォーカス
                            this.Ok_Button.Focus();
                        }
                        else
                        {
                            uGrid.Rows[rowIndex + 1].Cells[columnIndex].Activate();
                            uGrid.PerformAction(UltraGridAction.EnterEditMode);
                        }
                        break;
                    }
                case Keys.Left:
                    {
                        if (uGrid.ActiveCell.IsInEditMode)
                        {
                            if (uGrid.ActiveCell.SelStart == 0)
                            {
                                e.Handled = true;

                                // 編集モード終了
                                uGrid.PerformAction(UltraGridAction.ExitEditMode);

                                if ((columnIndex == 1) && (this._checkSectionFlg == false))
                                {
                                    uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                    return;
                                }
                                else if ((columnIndex == 4) && (this._checkSupplierFlg == false))
                                {
                                    uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                    return;
                                }

                                if ((columnIndex == 1) && (rowIndex == 0))
                                {
                                    uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                    return;
                                }
                                else
                                {
                                    uGrid.PerformAction(UltraGridAction.PrevCellByTab);
                                }
                            }
                        }
                        else
                        {
                            uGrid.PerformAction(UltraGridAction.PrevCellByTab);
                            e.Handled = true;
                        }
                        return;
                    }
                case Keys.Right:
                    {
                        if (uGrid.ActiveCell.IsInEditMode)
                        {
                            if (uGrid.ActiveCell.SelStart >= uGrid.ActiveCell.Text.Length)
                            {
                                e.Handled = true;

                                // 編集モード終了
                                uGrid.PerformAction(UltraGridAction.ExitEditMode);

                                if ((columnIndex == 1) && (this._checkSectionFlg == false))
                                {
                                    uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                    return;
                                }
                                else if ((columnIndex == 4) && (this._checkSupplierFlg == false))
                                {
                                    uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                    return;
                                }

                                uGrid.PerformAction(UltraGridAction.NextCellByTab);
                            }
                        }
                        else
                        {
                            uGrid.PerformAction(UltraGridAction.NextCellByTab);
                            e.Handled = true;
                        }
                        return;
                    }
                case Keys.Space:
                    {
                        e.Handled = true;

                        uGrid_SumSuppSt_ClickCellButton(uGrid, new CellEventArgs(uGrid.ActiveCell));
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
        /// <br>Programmer : FSI斎藤 和宏</br>
        /// <br>Date	   : 2012/08/27</br>
        /// </remarks>
        private void uGrid_SumSuppSt_KeyPress(object sender, KeyPressEventArgs e)
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
        /// Leave イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : グリッドからフォーカスが離れた時に発生します。</br>
        /// <br>Programmer : FSI斎藤 和宏</br>
        /// <br>Date	   : 2012/08/27</br>
        /// </remarks>
        private void uGrid_SumSuppSt_Leave(object sender, EventArgs e)
        {
            UltraGrid uGrid = (UltraGrid)sender;

            uGrid.ActiveCell = null;
            uGrid.ActiveRow = null;

        }

        /// <summary>
        /// ClickCellButton イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : グリッド内ガイドボタンをクリックされた時に発生します。</br>
        /// <br>Programmer : FSI斎藤 和宏</br>
        /// <br>Date	   : 2012/08/27</br>
        /// </remarks>
        private void uGrid_SumSuppSt_ClickCellButton(object sender, CellEventArgs e)
        {
            UltraGrid uGrid = (UltraGrid)sender;

            int status;

            switch (e.Cell.Column.Key)
            {
                case COLUMN_SECTIONGUIDE:   // 拠点ガイドボタン
                    {
                        // ガイド前の値を退避
                        string beforeSectionCode = StrObjectToString(uGrid.Rows[e.Cell.Row.Index].Cells[COLUMN_SECTIONCODE].Value);

                        SecInfoSet secInfoSet;

                        status = this._secInfoSetAcs.ExecuteGuid(this._enterpriseCode, false, out secInfoSet);
                        if (status == 0)
                        {
                            // 拠点コード
                            uGrid.Rows[e.Cell.Row.Index].Cells[COLUMN_SECTIONCODE].Value = secInfoSet.SectionCode.Trim();
                            uGrid.Rows[e.Cell.Row.Index].Cells[COLUMN_SECTIONCODE].Tag = secInfoSet.SectionCode.Trim();
                            
                            // 拠点名
                            uGrid.Rows[e.Cell.Row.Index].Cells[COLUMN_SECTIONNAME].Value = GetSectionName(secInfoSet.SectionCode.Trim());

                            // 前回入力ありで、かつ変更された場合
                            if (!string.IsNullOrEmpty(beforeSectionCode) && beforeSectionCode != secInfoSet.SectionCode.Trim())
                            {
                                // 仕入先クリア
                                uGrid.Rows[uGrid.ActiveCell.Row.Index].Cells[COLUMN_SUPPLIERCD].Value = string.Empty;
                                uGrid.Rows[uGrid.ActiveCell.Row.Index].Cells[COLUMN_SUPPLIERNM].Value = string.Empty;
                                uGrid.Rows[uGrid.ActiveCell.Row.Index].Cells[COLUMN_SUPPLIERCD].Tag = string.Empty;
                            }

                            if (e.Cell.Row.Index == uGrid.Rows.Count - 1)
                            {
                                // 最終行だった場合、行を追加
                                CreateNewRow(ref uGrid);
                            }

                            // フォーカスを右隣の仕入先へ移動
                            uGrid.Rows[e.Cell.Row.Index].Cells[COLUMN_SUPPLIERCD].Activate();
                            uGrid.PerformAction(UltraGridAction.EnterEditMode);
                        }
                        break;
                    }
                case COLUMN_SUPPLIERGUIDE:  // 仕入先ガイドボタン
                    {
                        // 仕入先のオブジェクト
                        Supplier SupplierInfo = new Supplier();

                        // 仕入先ガイド起動
                        status = this._supplierAcs.ExecuteGuid(out SupplierInfo, this._enterpriseCode, string.Empty);

                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            // 仕入先コード
                            uGrid.Rows[e.Cell.Row.Index].Cells[COLUMN_SUPPLIERCD].Value = SupplierInfo.SupplierCd.ToString("000000");
                            uGrid.Rows[e.Cell.Row.Index].Cells[COLUMN_SECTIONCODE].Tag = SupplierInfo.SupplierCd.ToString("000000");
                            
                            // 仕入先略称
                            uGrid.Rows[e.Cell.Row.Index].Cells[COLUMN_SUPPLIERNM].Value = SupplierInfo.SupplierSnm.ToString();

                            if (e.Cell.Row.Index == uGrid.Rows.Count - 1)
                            {
                                // 最終行だった場合、行を追加
                                CreateNewRow(ref uGrid);
                            }

                            // フォーカスを次行の拠点コードへ移動
                            uGrid.Rows[e.Cell.Row.Index + 1].Cells[COLUMN_SECTIONCODE].Activate();
                            uGrid.PerformAction(UltraGridAction.EnterEditMode);
                        }

                        break;
                    }
            }
        }

        /// <summary>
        /// Timer_Tick イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : 指定された間隔の時間が経過した時に発生します。</br>
        /// <br>Programmer : FSI斎藤 和宏</br>
        /// <br>Date	   : 2012/08/27</br>
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
        /// <br>Programmer : FSI斎藤 和宏</br>
        /// <br>Date	   : 2012/08/27</br>
        /// </remarks>
        private void tRetKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null)
            {
                return;
            }

            if (e.NextCtrl == this.Cancel_Button &&
                e.Key != Keys.Tab &&
                e.Key != Keys.Enter &&
                e.Key != Keys.Up &&
                e.Key != Keys.Down &&
                e.Key != Keys.Left &&
                e.Key != Keys.Right)
            {
                e.NextCtrl = null;
                Cancel_Button_Click(this.Cancel_Button, new EventArgs());
                return;
            }

            // 画面から総括拠点・総括仕入先コード取得
            string sumSectionCode = (string)this.tEdit_SectionCode.GetInt().ToString("00");
            int sumSupplierCode = this.tNedit_SupplierCd.GetInt();

            switch (e.PrevCtrl.Name)
            {
                #region ■総括拠点コード
                case "tEdit_SectionCode":
                    {
                        if ( sumSectionCode != "00" &&
                            !this._secInfoSetDic.ContainsKey(sumSectionCode))
                        {
                            // 入力ありでマスタ登録なし
                            ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                                           "拠点情報設定マスタに登録されていません。",
                                           -1,
                                           MessageBoxButtons.OK,
                                           MessageBoxDefaultButton.Button1);

                            this.tEdit_SectionCode.Clear();
                            this.tEdit_SectionName.Clear();
                            e.NextCtrl = this.tEdit_SectionCode;
                            break;
                        }
                        else if (this._secInfoSetDic.ContainsKey(sumSectionCode))
                        {
                            // キャッシュに存在する場合は名称をセット
                            this.tEdit_SectionName.Value = this._secInfoSetDic[sumSectionCode].SectionGuideSnm.ToString();
                        }

                        // フォーカス制御
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                if (sumSectionCode == "00")
                                {
                                    this.tEdit_SectionCode.Clear();
                                    this.tEdit_SectionName.Clear();
                                    e.NextCtrl = this.SumSectionGuide_Button;
                                }
                                else
                                {
                                    e.NextCtrl = this.tNedit_SupplierCd;
                                }
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                if (sumSectionCode == "00")
                                {
                                    this.tEdit_SectionCode.Clear();
                                    this.tEdit_SectionName.Clear();
                                }

                                // シフトキー押下時は閉じるボタンへフォーカス移動
                                e.NextCtrl = this.Cancel_Button;
                            }
                        }
                        break;
                    }
                #endregion

                #region ■総括仕入先コード
                case "tNedit_SupplierCd":
                    {
                        if ( sumSupplierCode != 0 &&
                            !this._supplierDic.ContainsKey(sumSupplierCode))
                        {
                            ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                                           "仕入先マスタに登録されていません。",
                                           -1,
                                           MessageBoxButtons.OK,
                                           MessageBoxDefaultButton.Button1);

                            this.tNedit_SupplierCd.Clear();
                            this.tEdit_SupplierSnm.Clear();
                            e.NextCtrl = this.tNedit_SupplierCd;
                            break;
                        }
                        else if (this._supplierDic.ContainsKey(sumSupplierCode))
                        {
                            // キャッシュに存在する場合は名称をセット
                            this.tEdit_SupplierSnm.Value = this._supplierDic[sumSupplierCode].SupplierSnm.ToString();

                            // グリッド入力するための準備処理
                            // グリッドへ遷移不可の場合はフォーカスを総括仕入先コードに戻す
                            if (!CheckBeforeEnterGrid())
                            {
                                e.NextCtrl = this.tNedit_SupplierCd;
                                break;
                            }
                        }
                        // フォーカスを移動
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                if (sumSupplierCode == 0)
                                {
                                    this.tNedit_SupplierCd.Clear();
                                    this.tEdit_SupplierSnm.Clear();
                                    e.NextCtrl = this.SumSuppGuide_Button;
                                }
                                else
                                {
                                    e.NextCtrl = null;
                                    this.uGrid_SumSuppSt.Focus();
                                    this.uGrid_SumSuppSt.Rows[0].Cells[COLUMN_SECTIONCODE].Activate();
                                    this.uGrid_SumSuppSt.PerformAction(UltraGridAction.EnterEditMode);
                                }
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                if (sumSupplierCode == 0)
                                {
                                    this.tNedit_SupplierCd.Clear();
                                    this.tEdit_SupplierSnm.Clear();
                                }

                                if (sumSectionCode == "00")
                                {
                                    e.NextCtrl = this.SumSectionGuide_Button;
                                }
                                else
                                {
                                    e.NextCtrl = this.tEdit_SectionCode;
                                }
                            }
                        }
                        break;
                    }
                #endregion

                #region ■グリッド内
                case "uGrid_SumSuppSt":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                SetNextFocus(this.uGrid_SumSuppSt, ref e);
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                SetBeforeFocus(this.uGrid_SumSuppSt, ref e);
                            }
                        }
                        break;
                    }
                #endregion

                #region ■保存ボタン
                case "Ok_Button":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                e.NextCtrl = Cancel_Button;
                            }
                        }
                        else
                        {
                            e.NextCtrl = null;
                            this.uGrid_SumSuppSt.Focus();
                            this.uGrid_SumSuppSt.Rows[this.uGrid_SumSuppSt.Rows.Count - 1].Cells[COLUMN_SUPPLIERCD].Activate();
                            this.uGrid_SumSuppSt.PerformAction(UltraGridAction.EnterEditMode);
                        }
                        break;
                    }
                #endregion

                #region ■閉じるボタン
                case "Cancel_Button":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                if (this.Mode_Label.Text == INSERT_MODE)
                                {
                                    e.NextCtrl = tEdit_SectionCode;
                                }
                                else if (this.Mode_Label.Text == UPDATE_MODE)
                                {
                                    // 更新モード時はグリッド最上段の拠点コードにフォーカスセット
                                    e.NextCtrl = null;
                                    this.uGrid_SumSuppSt.Focus();
                                    this.uGrid_SumSuppSt.Rows[0].Cells[COLUMN_SECTIONCODE].Activate();
                                    this.uGrid_SumSuppSt.PerformAction(UltraGridAction.EnterEditMode);
                                }
                                else if (this.Mode_Label.Text == DELETE_MODE)
                                {
                                    e.NextCtrl = Delete_Button;
                                }
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                if (this.Mode_Label.Text == DELETE_MODE)
                                {
                                    e.NextCtrl = Revive_Button;
                                }
                                else
                                {
                                    e.NextCtrl = Ok_Button;
                                }
                            }
                        }
                        break;
                    }
                #endregion

                #region ■完全削除ボタン
                case "Delete_Button":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                e.NextCtrl = Revive_Button;
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                e.NextCtrl = Cancel_Button;
                            }
                        }
                        break;
                    }
                #endregion
                
                #region ■復活ボタン
                case "Revive_Button":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                e.NextCtrl = Cancel_Button;
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                e.NextCtrl = Delete_Button;
                            }
                        }
                        break;
                    }
                #endregion
            }

            if (e.NextCtrl == null)
            {
                return;
            }

            #region ■NextCtrl
            switch (e.NextCtrl.Name)
            {
                case "uGrid_SumSuppSt":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter) || (e.Key == Keys.Down))
                            {
                                e.NextCtrl = null;
                                this.uGrid_SumSuppSt.Rows[0].Cells[COLUMN_SECTIONCODE].Activate();
                                this.uGrid_SumSuppSt.PerformAction(UltraGridAction.EnterEditMode);
                                return;
                            }
                            else if (e.Key == Keys.Up)
                            {
                                e.NextCtrl = null;
                                this.uGrid_SumSuppSt.Rows[this.uGrid_SumSuppSt.Rows.Count - 1].Cells[COLUMN_SUPPLIERCD].Activate();
                                this.uGrid_SumSuppSt.PerformAction(UltraGridAction.EnterEditMode);
                                return;
                            }
                        }
                        else
                        {
                            if (e.Key == Keys.Tab)
                            {
                                e.NextCtrl = null;
                                this.uGrid_SumSuppSt.Rows[this.uGrid_SumSuppSt.Rows.Count - 1].Cells[COLUMN_SUPPLIERCD].Activate();
                                this.uGrid_SumSuppSt.PerformAction(UltraGridAction.EnterEditMode);
                                return;
                            }
                        }
                        break;
                    }
            }
            #endregion
        }
        
        #endregion ■ Control Events

    }
}