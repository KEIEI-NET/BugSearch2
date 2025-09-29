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
using Broadleaf.Application.Resources;   // ADD 尹鶴凝 2014/02/25

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 得意先マスタ(総括設定)UIクラス
    /// </summary>
    /// <remarks>
    /// <br>Note		: 得意先マスタ(総括設定)のUI設定を行います。</br>
    /// <br>Programmer	: 30414 忍　幸史</br>
    /// <br>Date		: 2008/10/29</br>
    /// <br></br>
    /// <br>Update Note: 2010/03/12  22018 鈴木 正臣</br>
    /// <br>           : (MANTIS:15154)得意先マスタの設定と同じ請求拠点コード以外入力出来ないよう変更。</br>
    /// <br>Update Note: 2014/02/25  尹鶴凝</br>
    /// <br>管理番号   : 10970685-00</br>
    /// <br>           : 総括得意先、請求得意先に子の得意先を入力できるようにする。</br>
    /// <br></br>
    /// </remarks>
    public partial class PMKHN09241UA : Form, IMasterMaintenanceArrayType
    {
        #region ■ Constants

        // プログラムID
        private const string ASSEMBLY_ID = "PMKHN09241U";

        // テーブル名称
        private const string TABLE_MAIN = "MainTable";
        private const string TABLE_DETAIL = "DetailTable";

        // データビュータイトル
        private const string GRIDTITLE_SUMCLAIMCUST = "総括得意先";
        private const string GRIDTITLE_CUSTOMER = "請求得意先";

        // データビュー表示用
        private const string VIEW_SUMCLAIMCUSTCODE = "総括得意先";
        private const string VIEW_SUMCLAIMCUSTNAME = "総括得意先名";
        private const string VIEW_DELETEDATE = "削除日";
        private const string VIEW_DEMANDADDUPSECCD = "請求拠点";
        private const string VIEW_DEMANDADDUPSECNM = "請求拠点名";
        private const string VIEW_CUSTCODE = "請求得意先";
        private const string VIEW_CUSTNAME = "請求得意先名";

        // グリッド列タイトル
        private const string COLUMN_NO = "No";
        private const string COLUMN_DEMANDADDUPSECCD = "DemandAddUpSecCd";
        private const string COLUMN_DEMANDADDUPSECNM = "DemandAddUpSecNm";
        private const string COLUMN_SECTIONGUIDE = "SectionGuide";
        private const string COLUMN_CUSTOMERCD = "CustomerCd";
        private const string COLUMN_CUSTOMERNM = "CustomerNm";
        private const string COLUMN_CUSTOMERGUIDE = "CustomerGuide";

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

        private SumCustStAcs _sumCustStAcs;
        private SecInfoAcs _secInfoAcs;
        private SecInfoSetAcs _secInfoSetAcs;
        private CustomerInfoAcs _customerInfoAcs;
        private CustomerSearchAcs _customerSearchAcs;

        private Dictionary<string , SecInfoSet> _secInfoSetDic;
        private Dictionary<int, CustomerSearchRet> _customerSearchRetDic;

        private ControlScreenSkin _controlScreenSkin;           // 画面デザイン変更クラス
        private List<SumCustSt> _sumCustStListClone;            // 得意先マスタ(総括設定)リストClone
        private Dictionary<int, SumCustSt> _mainList;
        private List<SumCustSt> _detailList;

        private int _sumCustTotalDay;

        private bool _cusotmerGuideSelected;                    // 得意先ガイド選択フラグ
        private bool _gridCustomerGuideFlg;
        private bool _checkSectionFlg;
        private bool _checkCustomerFlg;

        // --- ADD m.suzuki 2010/03/12 ---------->>>>>
        // セル変更前値backup
        private string _beforeCellText;
        // --- ADD m.suzuki 2010/03/12 ----------<<<<<
        private int _opt_KonMan;      // ADD 尹鶴凝 2014/02/25
        
        #endregion ■ Private Members


        #region ■ Constructor
        /// <summary>
        /// 得意先マスタ(総括設定)クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 得意先マスタ(総括設定)UIクラスの新しいインスタンスを生成します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date	   : 2008/10/29</br>
        /// </remarks>
        public PMKHN09241UA()
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

            this._sumCustStAcs = new SumCustStAcs();
            this._secInfoAcs = new SecInfoAcs();
            this._secInfoSetAcs = new SecInfoSetAcs();
            this._customerInfoAcs = new CustomerInfoAcs();
            this._customerSearchAcs = new CustomerSearchAcs();

            this._controlScreenSkin = new ControlScreenSkin();

            // マスタ読込
            ReadSecInfoSet();
            ReadCustomerSearchRet();

            // DataSet列情報構築
            this.Bind_DataSet = new DataSet();
            DataSetColumnConstruction();

            //オプションキーの取得とチェック
            CheckOptionKey();  　　//ADD 尹鶴凝 2014/02/25
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
        /// <br>Date       : 2008/10/29</br>
        /// </remarks>
        public void GetAppearanceTable(out Hashtable[] appearanceTable)
        {
            //==============================
            // メイン
            //==============================
            Hashtable main = new Hashtable();

            main.Add(VIEW_SUMCLAIMCUSTCODE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            main.Add(VIEW_SUMCLAIMCUSTNAME, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));

            //==============================
            // 詳細
            //==============================
            Hashtable detail = new Hashtable();

            detail.Add(VIEW_DELETEDATE, new GridColAppearance(MGridColDispType.DeletionDataBoth, ContentAlignment.MiddleLeft, "", Color.Red));
            detail.Add(VIEW_DEMANDADDUPSECCD, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            detail.Add(VIEW_DEMANDADDUPSECNM, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            detail.Add(VIEW_CUSTCODE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            detail.Add(VIEW_CUSTNAME, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));

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
        /// <br>Date       : 2008/10/29</br>
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
        /// <br>Date       : 2008/10/29</br>
        /// </remarks>
        public bool[] GetCanLogicalDeleteDataExtractionList()
        {
            bool[] logicalDeleteButton = { false, true };
            return logicalDeleteButton;
        }

        /// <summary>
        /// グリッド列のサイズの自動調整のデフォルト値リスト取得処理
        /// </summary>
        /// <returns>グリッド列のサイズの自動調整のデフォルト値リスト</returns>
        /// <remarks>
        /// <br>Note       : グリッド列のサイズの自動調整チェックボックスのチェック有無のデフォルト値を配列で取得します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/10/29</br>
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
        /// <br>Date       : 2008/10/29</br>
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
        /// <br>Date       : 2008/10/29</br>
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
        /// <br>Date       : 2008/10/29</br>
        /// </remarks>
        public string[] GetGridTitleList()
        {
            string[] gridTitle = { GRIDTITLE_SUMCLAIMCUST, GRIDTITLE_CUSTOMER };
            return gridTitle;
        }

        /// <summary>
        /// 修正ボタンの有効設定リスト取得処理
        /// </summary>
        /// <returns>修正ボタンの有効設定リスト</returns>
        /// <remarks>
        /// <br>Note       : 修正ボタンの有効設定リストを取得します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/10/29</br>
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
        /// <br>Date       : 2008/10/29</br>
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
        /// <br>Date       : 2008/10/29</br>
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
        /// <br>Date       : 2008/10/29</br>
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
        /// <br>Date       : 2008/10/29</br>
        /// </remarks>
        public int DetailsDataSearch(ref int totalCount, int readCount)
        {
            ArrayList retList;

            // 現在保持しているデータをクリアする
            this.Bind_DataSet.Tables[TABLE_DETAIL].Rows.Clear();

            // 選択されているデータを取得する
            int sumClaimCustCode = int.Parse((string)this.Bind_DataSet.Tables[TABLE_MAIN].Rows[this._mainDataIndex][VIEW_SUMCLAIMCUSTCODE]);

            // 検索処理（論理削除含む）
            int status = this._sumCustStAcs.Search(out retList, this._enterpriseCode, sumClaimCustCode, ConstantManagement.LogicalMode.GetDataAll);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    {
                        // 取得したクラスをデータセットへ展開する
                        int index = 0;
                        foreach (SumCustSt sumCustSt in retList)
                        {
                            // DataSet展開処理
                            DetailToDataSet(sumCustSt, index);
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
        /// <br>Date       : 2008/10/29</br>
        /// </remarks>
        public int Search(ref int totalCount, int readCount)
        {
            // 現在保持しているデータをクリアする
            this.Bind_DataSet.Tables[TABLE_MAIN].Rows.Clear();

            this._mainList = new Dictionary<int, SumCustSt>();
            this._detailList = new List<SumCustSt>();

            ArrayList retList;

            int status = this._sumCustStAcs.Search(out retList, this._enterpriseCode, ConstantManagement.LogicalMode.GetDataAll);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    {
                        // バッファ保持
                        foreach (SumCustSt sumCustSt in retList)
                        {
                            if (!this._mainList.ContainsKey(sumCustSt.SumClaimCustCode))
                            {
                                this._mainList.Add(sumCustSt.SumClaimCustCode, sumCustSt);
                            }

                            this._detailList.Add(sumCustSt);
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

            // 読み込んだインスタンスのそれぞれをデータセットに展開
            int index = 0;
            foreach (SumCustSt sumCustSt in this._mainList.Values)
            {
                // DataSet展開処理
                MainToDataSet(sumCustSt, index);
                index++;
            }

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
        /// <br>Date       : 2008/10/29</br>
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
        /// <br>Date       : 2008/10/29</br>
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
        /// <br>Date       : 2008/10/29</br>
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
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/10/29</br>
        /// </remarks>
        private void ReadSecInfoSet()
        {
            this._secInfoSetDic = new Dictionary<string, SecInfoSet>();

            foreach (SecInfoSet secInfoSet in this._secInfoAcs.SecInfoSetList)
            {
                if (secInfoSet.LogicalDeleteCode == 0)
                {
                    this._secInfoSetDic.Add(secInfoSet.SectionCode.Trim(), secInfoSet);
                }
            }
        }

        /// <summary>
        /// 拠点名取得処理
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <returns>拠点名</returns>
        /// <remarks>
        /// <br>Note       : 拠点名を取得します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/10/29</br>
        /// </remarks>
        private string GetSectionName(string sectionCode)
        {
            string sectionName = "";

            if (this._secInfoSetDic.ContainsKey(sectionCode.Trim()))
            {
                sectionName = this._secInfoSetDic[sectionCode.Trim()].SectionGuideSnm.Trim();
            }

            return sectionName;
        }

        /// <summary>
        /// 得意先情報取得処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 得意先情報を取得し、バッファに保持します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/10/29</br>
        /// </remarks>
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
                    foreach (CustomerSearchRet customerSearchRet in retArray)
                    {
                        if (customerSearchRet.LogicalDeleteCode == 0)
                        {
                            this._customerSearchRetDic.Add(customerSearchRet.CustomerCode, customerSearchRet);
                        }
                    }
                }
            }
            catch
            {
                this._customerSearchRetDic = new Dictionary<int, CustomerSearchRet>();
            }
        }

        /// <summary>
        /// 得意先名取得処理
        /// </summary>
        /// <param name="customerCode">得意先コード</param>
        /// <returns>得意先名</returns>
        /// <remarks>
        /// <br>Note       : 得意先名を取得します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/10/29</br>
        /// </remarks>
        private string GetCustomerName(int customerCode)
        {
            string customerName = "";

            if (this._customerSearchRetDic.ContainsKey(customerCode))
            {
                customerName = this._customerSearchRetDic[customerCode].Snm.Trim();
            }

            return customerName;
        }

        /// <summary>
        /// 締日取得処理
        /// </summary>
        /// <param name="customerCode">得意先コード</param>
        /// <returns>締日</returns>
        /// <remarks>
        /// <br>Note       : 締日を取得します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/10/29</br>
        /// </remarks>
        private int GetTotalDay(int customerCode)
        {
            int totalDay = 0;

            if (this._customerSearchRetDic.ContainsKey(customerCode))
            {
                totalDay = this._customerSearchRetDic[customerCode].TotalDay;
            }

            return totalDay;
        }

        /// <summary>
        /// 得意先情報取得処理
        /// </summary>
        /// <param name="customerCode">得意先コード</param>
        /// <returns>得意先情報</returns>
        /// <remarks>
        /// <br>Note       : 得意先情報を取得します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/10/29</br>
        /// </remarks>
        private int GetCustomerInfo(int customerCode, out CustomerInfo customerInfo)
        {
            customerInfo = null;
            int status;

            try
            {
                status = this._customerInfoAcs.ReadDBData(this._enterpriseCode, customerCode, out customerInfo);
                if (status != 0)
                {
                    customerInfo = null;
                }
            }
            catch
            {
                status = -1;
                customerInfo = null;
            }

            return status;
        }

        /// <summary>
        /// 画面初期化処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面情報を初期化します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date	   : 2008/10/29</br>
        /// </remarks>
        private void ScreenClear()
        {
            // 拠点
            this.tNedit_CustomerCode.Clear();
            this.tEdit_CustomerName.Clear();

            // グリッド
            for (int rowIndex = 0; rowIndex < this.uGrid_SumCustSt.Rows.Count; rowIndex++)
            {
                this.uGrid_SumCustSt.Rows[rowIndex].Cells[COLUMN_DEMANDADDUPSECCD].Value = "";
                this.uGrid_SumCustSt.Rows[rowIndex].Cells[COLUMN_DEMANDADDUPSECNM].Value = "";
                this.uGrid_SumCustSt.Rows[rowIndex].Cells[COLUMN_CUSTOMERCD].Value = "";
                this.uGrid_SumCustSt.Rows[rowIndex].Cells[COLUMN_CUSTOMERNM].Value = "";
                this.uGrid_SumCustSt.Rows[rowIndex].Cells[COLUMN_DEMANDADDUPSECCD].Activation = Activation.AllowEdit;
                this.uGrid_SumCustSt.Rows[rowIndex].Cells[COLUMN_CUSTOMERCD].Activation = Activation.AllowEdit;
            }

            this.uGrid_SumCustSt.ActiveCell = null;
            this.uGrid_SumCustSt.ActiveRow = null;
        }

        /// <summary>
        /// 画面初期設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面の初期設定を行います。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date	   : 2008/10/29</br>
        /// </remarks>
        private void SetScreenInitialSetting()
        {
            // マスタ読込
            ReadSecInfoSet();
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

            // グリッド構築
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add(COLUMN_NO, typeof(int));
            dataTable.Columns.Add(COLUMN_DEMANDADDUPSECCD, typeof(string));
            dataTable.Columns.Add(COLUMN_DEMANDADDUPSECNM, typeof(string));
            dataTable.Columns.Add(COLUMN_SECTIONGUIDE, typeof(string));
            dataTable.Columns.Add(COLUMN_CUSTOMERCD, typeof(string));
            dataTable.Columns.Add(COLUMN_CUSTOMERNM, typeof(string));
            dataTable.Columns.Add(COLUMN_CUSTOMERGUIDE, typeof(string));

            for (int rowIndex = 0; rowIndex < 25; rowIndex++)
            {
                DataRow dataRow = dataTable.NewRow();

                dataRow[COLUMN_NO] = rowIndex + 1;
                dataRow[COLUMN_DEMANDADDUPSECCD] = "";
                dataRow[COLUMN_DEMANDADDUPSECNM] = "";
                dataRow[COLUMN_SECTIONGUIDE] = "";
                dataRow[COLUMN_CUSTOMERCD] = "";
                dataRow[COLUMN_CUSTOMERNM] = "";
                dataRow[COLUMN_CUSTOMERGUIDE] = "";

                dataTable.Rows.Add(dataRow);
            }

            this.uGrid_SumCustSt.DataSource = dataTable;

            for (int rowIndex = 0; rowIndex < 25; rowIndex++)
            {
                this.uGrid_SumCustSt.Rows[rowIndex].Cells[COLUMN_DEMANDADDUPSECCD].Tag = "";
                this.uGrid_SumCustSt.Rows[rowIndex].Cells[COLUMN_CUSTOMERCD].Tag = "";
            }

            ColumnsCollection columns = this.uGrid_SumCustSt.DisplayLayout.Bands[0].Columns;

            // ヘッダーキャプション
            columns[COLUMN_NO].Header.Caption = "No.";
            columns[COLUMN_DEMANDADDUPSECCD].Header.Caption = "請求拠点";
            columns[COLUMN_DEMANDADDUPSECNM].Header.Caption = "請求拠点名";
            columns[COLUMN_SECTIONGUIDE].Header.Caption = "";
            columns[COLUMN_CUSTOMERCD].Header.Caption = "請求得意先";
            columns[COLUMN_CUSTOMERNM].Header.Caption = "請求得意先名";
            columns[COLUMN_CUSTOMERGUIDE].Header.Caption = "";
            // TextHAlign
            columns[COLUMN_NO].CellAppearance.TextHAlign = HAlign.Right;
            columns[COLUMN_DEMANDADDUPSECCD].CellAppearance.TextHAlign = HAlign.Left;
            columns[COLUMN_DEMANDADDUPSECNM].CellAppearance.TextHAlign = HAlign.Left;
            columns[COLUMN_SECTIONGUIDE].CellAppearance.TextHAlign = HAlign.Center;
            columns[COLUMN_CUSTOMERCD].CellAppearance.TextHAlign = HAlign.Right;
            columns[COLUMN_CUSTOMERNM].CellAppearance.TextHAlign = HAlign.Left;
            columns[COLUMN_CUSTOMERGUIDE].CellAppearance.TextHAlign = HAlign.Center;
            // TextVAlign
            columns[COLUMN_NO].CellAppearance.TextVAlign = VAlign.Middle;
            columns[COLUMN_DEMANDADDUPSECCD].CellAppearance.TextVAlign = VAlign.Middle;
            columns[COLUMN_DEMANDADDUPSECNM].CellAppearance.TextVAlign = VAlign.Middle;
            columns[COLUMN_SECTIONGUIDE].CellAppearance.TextVAlign = VAlign.Middle;
            columns[COLUMN_CUSTOMERCD].CellAppearance.TextVAlign = VAlign.Middle;
            columns[COLUMN_CUSTOMERNM].CellAppearance.TextVAlign = VAlign.Middle;
            columns[COLUMN_CUSTOMERGUIDE].CellAppearance.TextVAlign = VAlign.Middle;
            // 入力制御
            columns[COLUMN_NO].CellActivation = Activation.Disabled;
            columns[COLUMN_DEMANDADDUPSECCD].CellActivation = Activation.AllowEdit;
            columns[COLUMN_DEMANDADDUPSECNM].CellActivation = Activation.Disabled;
            columns[COLUMN_SECTIONGUIDE].CellActivation = Activation.AllowEdit;
            columns[COLUMN_CUSTOMERCD].CellActivation = Activation.AllowEdit;
            columns[COLUMN_CUSTOMERNM].CellActivation = Activation.Disabled;
            columns[COLUMN_CUSTOMERGUIDE].CellActivation = Activation.AllowEdit;
            // 列幅
            columns[COLUMN_NO].Width = 45;
            columns[COLUMN_DEMANDADDUPSECCD].Width = 90;
            columns[COLUMN_DEMANDADDUPSECNM].Width = 175;
            columns[COLUMN_SECTIONGUIDE].Width = 24;
            columns[COLUMN_CUSTOMERCD].Width = 100;
            columns[COLUMN_CUSTOMERNM].Width = 175;
            columns[COLUMN_CUSTOMERGUIDE].Width = 24;
            // セルColor
            columns[COLUMN_NO].CellAppearance.BackColor = Color.FromArgb(89, 135, 214);
            columns[COLUMN_NO].CellAppearance.BackColorDisabled = Color.FromArgb(89, 135, 214);
            columns[COLUMN_NO].CellAppearance.BackColor2 = Color.FromArgb(7, 59, 150);
            columns[COLUMN_NO].CellAppearance.BackColorDisabled2 = Color.FromArgb(7, 59, 150);
            columns[COLUMN_NO].CellAppearance.ForeColor = Color.White;
            columns[COLUMN_NO].CellAppearance.ForeColorDisabled = Color.White;
            columns[COLUMN_NO].CellAppearance.BackGradientStyle = GradientStyle.Vertical;
            columns[COLUMN_DEMANDADDUPSECNM].CellAppearance.BackColor = Color.Gainsboro;
            columns[COLUMN_DEMANDADDUPSECNM].CellAppearance.BackColorDisabled = Color.Gainsboro;
            columns[COLUMN_CUSTOMERNM].CellAppearance.BackColor = Color.Gainsboro;
            columns[COLUMN_CUSTOMERNM].CellAppearance.BackColorDisabled = Color.Gainsboro;
            columns[COLUMN_DEMANDADDUPSECCD].CellAppearance.BackColorDisabled = Color.FromKnownColor(KnownColor.Control);
            columns[COLUMN_CUSTOMERCD].CellAppearance.BackColorDisabled = Color.FromKnownColor(KnownColor.Control);
            // MaxLength
            columns[COLUMN_DEMANDADDUPSECCD].MaxLength = this.uiSetControl1.GetSettingColumnCount(COLUMN_DEMANDADDUPSECCD);
            columns[COLUMN_CUSTOMERCD].MaxLength = this.uiSetControl1.GetSettingColumnCount(COLUMN_CUSTOMERCD);
            columns[COLUMN_DEMANDADDUPSECNM].MaxLength = 10;
            columns[COLUMN_CUSTOMERNM].MaxLength = 10;
            // セルボタン
            columns[COLUMN_SECTIONGUIDE].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;
            columns[COLUMN_SECTIONGUIDE].ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always;
            columns[COLUMN_SECTIONGUIDE].CellButtonAppearance.ImageHAlign = HAlign.Center;
            columns[COLUMN_SECTIONGUIDE].CellButtonAppearance.ImageVAlign = VAlign.Middle;
            columns[COLUMN_SECTIONGUIDE].CellButtonAppearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
            columns[COLUMN_SECTIONGUIDE].CellAppearance.Cursor = Cursors.Hand;
            columns[COLUMN_CUSTOMERGUIDE].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;
            columns[COLUMN_CUSTOMERGUIDE].ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always;
            columns[COLUMN_CUSTOMERGUIDE].CellButtonAppearance.ImageHAlign = HAlign.Center;
            columns[COLUMN_CUSTOMERGUIDE].CellButtonAppearance.ImageVAlign = VAlign.Middle;
            columns[COLUMN_CUSTOMERGUIDE].CellButtonAppearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
            columns[COLUMN_CUSTOMERGUIDE].CellAppearance.Cursor = Cursors.Hand;
        }

        /// <summary>
        /// DataSet展開処理(メインテーブル)
        /// </summary>
        /// <param name="sumCustSt">得意先マスタ(総括設定)</param>
        /// <param name="index">行インデックス</param>
        /// <remarks>
        /// <br>Note       : 得意先マスタ(総括設定)をDataSetに展開します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date	   : 2008/10/29</br>
        /// </remarks>
        private void MainToDataSet(SumCustSt sumCustSt, int index)
        {
            if ((index < 0) || (this.Bind_DataSet.Tables[TABLE_MAIN].Rows.Count <= index))
            {
                // 新規と判断して、行を追加する
                DataRow dataRow = this.Bind_DataSet.Tables[TABLE_MAIN].NewRow();
                this.Bind_DataSet.Tables[TABLE_MAIN].Rows.Add(dataRow);

                // indexを行の最終行番号する
                index = this.Bind_DataSet.Tables[TABLE_MAIN].Rows.Count - 1;
            }

            // 総括得意先
            this.Bind_DataSet.Tables[TABLE_MAIN].Rows[index][VIEW_SUMCLAIMCUSTCODE] = sumCustSt.SumClaimCustCode.ToString("00000000");
            // 総括得意先名
            this.Bind_DataSet.Tables[TABLE_MAIN].Rows[index][VIEW_SUMCLAIMCUSTNAME] = GetCustomerName(sumCustSt.SumClaimCustCode);
        }

        /// <summary>
        /// DataSet展開処理(詳細テーブル)
        /// </summary>
        /// <param name="sumCustSt">得意先マスタ(総括設定)</param>
        /// <param name="index">行インデックス</param>
        /// <remarks>
        /// <br>Note       : 得意先マスタ(総括設定)をDataSetに展開します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date	   : 2008/10/29</br>
        /// </remarks>
        private void DetailToDataSet(SumCustSt sumCustSt, int index)
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
            if (sumCustSt.LogicalDeleteCode == 0)
            {
                this.Bind_DataSet.Tables[TABLE_DETAIL].Rows[index][VIEW_DELETEDATE] = "";
            }
            else
            {
                this.Bind_DataSet.Tables[TABLE_DETAIL].Rows[index][VIEW_DELETEDATE] = sumCustSt.UpdateDateTimeJpInFormal;
            }
            // 請求拠点
            this.Bind_DataSet.Tables[TABLE_DETAIL].Rows[index][VIEW_DEMANDADDUPSECCD] = sumCustSt.DemandAddUpSecCd.Trim();
            // 請求拠点名
            this.Bind_DataSet.Tables[TABLE_DETAIL].Rows[index][VIEW_DEMANDADDUPSECNM] = GetSectionName(sumCustSt.DemandAddUpSecCd.Trim());
            // 請求得意先
            this.Bind_DataSet.Tables[TABLE_DETAIL].Rows[index][VIEW_CUSTCODE] = sumCustSt.CustomerCode.ToString("00000000");
            // 請求得意先名
            this.Bind_DataSet.Tables[TABLE_DETAIL].Rows[index][VIEW_CUSTNAME] = GetCustomerName(sumCustSt.CustomerCode);
        }

        /// <summary>
        /// DataSet列情報構築処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : DataSet列情報を構築します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date	   : 2008/10/29</br>
        /// </remarks>
        private void DataSetColumnConstruction()
        {
            //==============================
            // メイン
            //==============================
            DataTable mainTable = new DataTable(TABLE_MAIN);

            mainTable.Columns.Add(VIEW_SUMCLAIMCUSTCODE, typeof(string));
            mainTable.Columns.Add(VIEW_SUMCLAIMCUSTNAME, typeof(string));

            //==============================
            // 詳細
            //==============================
            DataTable detailTable = new DataTable(TABLE_DETAIL);

            detailTable.Columns.Add(VIEW_DELETEDATE, typeof(string));
            detailTable.Columns.Add(VIEW_DEMANDADDUPSECCD, typeof(string));
            detailTable.Columns.Add(VIEW_DEMANDADDUPSECNM, typeof(string));
            detailTable.Columns.Add(VIEW_CUSTCODE, typeof(string));
            detailTable.Columns.Add(VIEW_CUSTNAME, typeof(string));

            this.Bind_DataSet.Tables.Add(mainTable);
            this.Bind_DataSet.Tables.Add(detailTable);
        }

        /// <summary>
        /// 画面再構築処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面を再構築します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date	   : 2008/10/29</br>
        /// </remarks>
        private void ScreenReconstruction()
        {
            if (this.uGrid_SumCustSt.Rows.Count > 25)
            {
                for (int index = this.uGrid_SumCustSt.Rows.Count - 1; index >= 25; index--)
                {
                    this.uGrid_SumCustSt.Rows[index].Delete(false);
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
                this._sumCustStListClone = new List<SumCustSt>();

                // フォーカス設定
                this.tNedit_CustomerCode.Focus();
            }
            else
            {
                // DataSetから得意先コードを取得
                int sumClaimCustCode = int.Parse((string)this.Bind_DataSet.Tables[TABLE_MAIN].Rows[this._mainDataIndex][VIEW_SUMCLAIMCUSTCODE]);

                // 得意先コードでインスタンスリストから該当データを取得
                List<SumCustSt> sumCustStList = this._detailList.FindAll(delegate(SumCustSt x)
                {
                    if (x.SumClaimCustCode == sumClaimCustCode)
                    {
                        return (true);
                    }
                    else
                    {
                        return (false);
                    }
                });

                // 総括得意先の締日取得
                this._sumCustTotalDay = GetTotalDay(sumClaimCustCode);

                this._sumCustStListClone = new List<SumCustSt>();

                if (sumCustStList.Count == 0)
                {
                    SumCustSt sumCustSt = new SumCustSt();
                    sumCustSt.SumClaimCustCode = sumClaimCustCode;
                    sumCustStList.Add(sumCustSt);
                }
                else
                {
                    foreach (SumCustSt sumCustSt in sumCustStList)
                    {
                        this._sumCustStListClone.Add(sumCustSt.Clone());
                    }
                }

                // 画面展開処理
                SumCustStListToScreen(sumCustStList);

                if (sumCustStList[0].LogicalDeleteCode == 0)
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
                    this.uGrid_SumCustSt.Focus();
                    this.uGrid_SumCustSt.Rows[0].Cells[COLUMN_DEMANDADDUPSECCD].Activate();
                    this.uGrid_SumCustSt.PerformAction(UltraGridAction.EnterEditMode);
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
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date	   : 2008/10/29</br>
        /// </remarks>
        private void PermitScreenInput(string mode)
        {
            switch (mode)
            {
                case INSERT_MODE:
                    {
                        // 新規モード
                        this.tNedit_CustomerCode.Enabled = true;
                        this.CustomerGuide_Button.Enabled = true;

                        this.uGrid_SumCustSt.Enabled = true;
                        break;
                    }
                case UPDATE_MODE:
                    {
                        // 更新モード
                        this.tNedit_CustomerCode.Enabled = false;
                        this.CustomerGuide_Button.Enabled = false;

                        this.uGrid_SumCustSt.Enabled = true;
                        break;
                    }
                case DELETE_MODE:
                    {
                        // 削除モード
                        this.tNedit_CustomerCode.Enabled = false;
                        this.CustomerGuide_Button.Enabled = false;

                        this.uGrid_SumCustSt.Enabled = false;
                        break;
                    }
            }
        }

        /// <summary>
        /// 得意先マスタ(総括設定)リスト画面展開処理
        /// </summary>
        /// <param name="sumCustStList">得意先マスタ(総括設定)リスト</param>
        /// <remarks>
        /// <br>Note       : 得意先マスタ(総括設定)リストを画面展開します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date	   : 2008/10/29</br>
        /// </remarks>
        private void SumCustStListToScreen(List<SumCustSt> sumCustStList)
        {
            int rowIndex = 0;
            foreach (SumCustSt sumCustSt in sumCustStList)
            {
                // 総括得意先
                this.tNedit_CustomerCode.SetInt(sumCustSt.SumClaimCustCode);
                // 総括得意先名
                this.tEdit_CustomerName.DataText = GetCustomerName(sumCustSt.SumClaimCustCode);

                if (rowIndex == this.uGrid_SumCustSt.Rows.Count)
                {
                    // グリッド行追加
                    CreateNewRow(ref this.uGrid_SumCustSt);
                }

                // 請求拠点
                this.uGrid_SumCustSt.Rows[rowIndex].Cells[COLUMN_DEMANDADDUPSECCD].Value = sumCustSt.DemandAddUpSecCd.Trim();
                // --- ADD m.suzuki 2010/03/12 ---------->>>>>
                this.uGrid_SumCustSt.Rows[rowIndex].Cells[COLUMN_DEMANDADDUPSECCD].Tag = sumCustSt.DemandAddUpSecCd.Trim();
                // --- ADD m.suzuki 2010/03/12 ----------<<<<<
                // 請求拠点名
                this.uGrid_SumCustSt.Rows[rowIndex].Cells[COLUMN_DEMANDADDUPSECNM].Value = GetSectionName(sumCustSt.DemandAddUpSecCd.Trim());
                // 請求得意先
                this.uGrid_SumCustSt.Rows[rowIndex].Cells[COLUMN_CUSTOMERCD].Value = sumCustSt.CustomerCode.ToString("00000000");
                // 請求得意先名
                this.uGrid_SumCustSt.Rows[rowIndex].Cells[COLUMN_CUSTOMERNM].Value = GetCustomerName(sumCustSt.CustomerCode);

                rowIndex++;
            }
        }

        /// <summary>
        /// 保存データ取得処理
        /// </summary>
        /// <returns>保存データ</returns>
        /// <remarks>
        /// <br>Note       : 画面情報から、保存データを取得します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date	   : 2008/10/29</br>
        /// </remarks>
        private List<SumCustSt> GetSaveSumCustStListFromScreen()
        {
            List<SumCustSt> sumCustStList = new List<SumCustSt>();

            for (int rowIndex = 0; rowIndex < this.uGrid_SumCustSt.Rows.Count; rowIndex++)
            {
                CellsCollection cells = this.uGrid_SumCustSt.Rows[rowIndex].Cells;

                // 請求拠点・請求得意先が空白の場合
                if ((CellTextToString(cells[COLUMN_DEMANDADDUPSECCD].Text) == "") &&
                    (CellTextToInt(cells[COLUMN_CUSTOMERCD].Text) == 0))
                {
                    continue;
                }
                //if ((cells[COLUMN_DEMANDADDUPSECCD].Value == DBNull.Value) ||
                //    (((string)cells[COLUMN_DEMANDADDUPSECCD].Value).Trim() == ""))
                //{
                //    continue;
                //}

                //// 請求得意先が空白もしくは０の場合
                //if (CellTextToInt(cells[COLUMN_CUSTOMERCD].Text) == 0)
                //{
                //    continue;
                //}
                //if ((cells[COLUMN_CUSTOMERCD].Value == DBNull.Value) ||
                //    (((string)cells[COLUMN_CUSTOMERCD].Value).Trim() == "") ||
                //    (int.Parse(((string)cells[COLUMN_CUSTOMERCD].Value).Trim()) == 0))
                //{
                //    continue;
                //}

                SumCustSt SumCustSt = new SumCustSt();

                // 企業コード
                SumCustSt.EnterpriseCode = this._enterpriseCode;
                // 総括請求得意先コード
                SumCustSt.SumClaimCustCode= this.tNedit_CustomerCode.GetInt();
                // 請求計上拠点コード
                SumCustSt.DemandAddUpSecCd = CellTextToString(cells[COLUMN_DEMANDADDUPSECCD].Text);
                // 得意先コード
                SumCustSt.CustomerCode = CellTextToInt(cells[COLUMN_CUSTOMERCD].Text);

                sumCustStList.Add(SumCustSt);
            }

            return sumCustStList;
        }

        /// <summary>
        /// 更新用リスト取得処理
        /// </summary>
        /// <param name="saveList">保存リスト</param>
        /// <param name="deleteList">削除リスト</param>
        /// <remarks>
        /// <br>Note       : 画面情報から、保存リスト・削除リストを取得します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date	   : 2008/10/29</br>
        /// </remarks>
        private void GetUpdateList(out ArrayList saveList, out ArrayList deleteList)
        {
            saveList = new ArrayList();
            deleteList = new ArrayList();

            // 保存用データ取得
            List<SumCustSt> saveSumCustStList = GetSaveSumCustStListFromScreen();

            // 削除リスト作成
            foreach (SumCustSt sumCustSt in this._sumCustStListClone)
            {
                deleteList.Add(sumCustSt.Clone());
            }

            // 保存リスト作成
            foreach (SumCustSt sumCustSt in saveSumCustStList)
            {
                saveList.Add(sumCustSt);
            }
        }

        /// <summary>
        /// Key取得処理
        /// </summary>
        /// <param name="sumCustSt">得意先マスタ(総括設定)マスタ</param>
        /// <returns>Key</returns>
        /// <remarks>
        /// <br>Note       : 得意先マスタ(総括設定)からKeyを取得します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date	   : 2008/10/29</br>
        /// </remarks>
        private string GetKey(SumCustSt sumCustSt)
        {
            string key = "";

            // 総括請求得意先コード(8桁)＋請求拠点コード(2桁)＋得意先コード(8桁)
            key = sumCustSt.SumClaimCustCode.ToString("00000000") + sumCustSt.DemandAddUpSecCd.Trim() +
                  sumCustSt.CustomerCode.ToString("00000000");

            return key;
        }

        /// <summary>
        /// 保存処理
        /// </summary>
        /// <returns>ステータス(True:成功 False:失敗)</returns>
        /// <remarks>
        /// <br>Note       : 保存処理を行います。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date	   : 2008/10/29</br>
        /// </remarks>
        private bool SaveProc()
        {
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
                status = this._sumCustStAcs.Delete(deleteList);
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
            status = this._sumCustStAcs.Write(ref saveList);
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
        /// <br>Date	   : 2008/10/29</br>
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
            foreach (SumCustSt sumCustSt in this._sumCustStListClone)
            {
                deleteList.Add(sumCustSt.Clone());
            }

            // 削除処理
            int status = this._sumCustStAcs.Delete(deleteList);
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
        /// <br>Date	   : 2008/10/29</br>
        /// </remarks>
        private bool LogicalDeleteProc()
        {
            // DataSetから総括請求得意先コードを取得
            int sumClaimCustCode = int.Parse((string)this.Bind_DataSet.Tables[TABLE_MAIN].Rows[this._mainDataIndex][VIEW_SUMCLAIMCUSTCODE]);

            // 総括請求得意先コードでインスタンスリストから該当データを取得
            List<SumCustSt> sumCustStList = this._detailList.FindAll(delegate(SumCustSt x)
            {
                if (x.SumClaimCustCode == sumClaimCustCode)
                {
                    return (true);
                }
                else
                {
                    return (false);
                }
            });

            if (sumCustStList.Count == 0)
            {
                ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                               "削除対象データが存在しません。",
                               0,
                               MessageBoxButtons.OK,
                               MessageBoxDefaultButton.Button1);

                return (true);
            }

            if (sumCustStList[0].LogicalDeleteCode != 0)
            {
                ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                               "選択中のデータは既に削除されています。",
                               0,
                               MessageBoxButtons.OK,
                               MessageBoxDefaultButton.Button1);
                return (true);
            }

            ArrayList logicalList = new ArrayList();
            foreach (SumCustSt sumCustSt in sumCustStList)
            {
                logicalList.Add(sumCustSt.Clone());
            }

            // 論理削除処理
            int status = this._sumCustStAcs.LogicalDelete(ref logicalList);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        int index = 0;
                        string key;

                        foreach (SumCustSt sumCustSt in logicalList)
                        {
                            key = GetKey(sumCustSt);
                            int listIndex = this._detailList.FindIndex(delegate(SumCustSt x)
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
                                this._detailList[listIndex] = sumCustSt.Clone();
                            }

                            // DataSet展開
                            DetailToDataSet(sumCustSt, index);
                            index++;
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
        /// 復活処理
        /// </summary>
        /// <returns>ステータス(True:成功 False:失敗)</returns>
        /// <remarks>
        /// <br>Note       : 復活処理を行います。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date	   : 2008/10/29</br>
        /// </remarks>
        private bool RevivalProc()
        {
            // 復活リスト取得
            ArrayList reviveList = new ArrayList();
            foreach (SumCustSt sumCustSt in this._sumCustStListClone)
            {
                reviveList.Add(sumCustSt.Clone());
            }

            // 復活処理
            int status = this._sumCustStAcs.Revival(ref reviveList);
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
        /// <br>Date	   : 2008/10/29</br>
        /// <br>Update Note: 2014/02/25  尹鶴凝</br>
        /// <br>管理番号   : 10970685-00</br>
        /// <br>           : 総括得意先、請求得意先に子の得意先を入力できるようにする。</br>
        /// </remarks>
        private bool CheckScreenInput()
        {
            string errMsg = "";

            try
            {
                // 総括請求得意先コード
                if (this.tNedit_CustomerCode.GetInt() == 0)
                {
                    errMsg = "総括得意先コードを入力してください。";
                    this.tNedit_CustomerCode.Focus();
                    return (false);
                }
                int customerCode = this.tNedit_CustomerCode.GetInt();

                if (CheckSumClaimCustCode(customerCode) == false)
                {
                    this.tNedit_CustomerCode.Focus();
                    return (false);
                }

                // 請求計上拠点コード
                bool inputFlg = false;

                for (int rowIndex = 0; rowIndex < this.uGrid_SumCustSt.Rows.Count; rowIndex++)
                {
                    CellsCollection cells = this.uGrid_SumCustSt.Rows[rowIndex].Cells;

                    // 拠点コード取得
                    string sectionCode = CellTextToString(cells[COLUMN_DEMANDADDUPSECCD].Text);

                    if (sectionCode != "")
                    {
                        if (CheckSectionCode(sectionCode) == false)
                        {
                            this.uGrid_SumCustSt.AfterExitEditMode -= uGrid_SumCustSt_AfterExitEditMode;

                            this.uGrid_SumCustSt.Focus();
                            this.uGrid_SumCustSt.Rows[rowIndex].Cells[COLUMN_DEMANDADDUPSECCD].Activate();
                            this.uGrid_SumCustSt.PerformAction(UltraGridAction.EnterEditMode);

                            this.uGrid_SumCustSt.AfterExitEditMode += uGrid_SumCustSt_AfterExitEditMode;
                            return (false);
                        }
                    }

                    // 得意先コード取得
                    int custCode = CellTextToInt(cells[COLUMN_CUSTOMERCD].Text);

                    if (custCode != 0)
                    {
                        if (CheckCustomerCode(custCode, rowIndex) == false)
                        {
                            this.uGrid_SumCustSt.AfterExitEditMode -= uGrid_SumCustSt_AfterExitEditMode;

                            this.uGrid_SumCustSt.Focus();
                            this.uGrid_SumCustSt.Rows[rowIndex].Cells[COLUMN_CUSTOMERCD].Activate();
                            this.uGrid_SumCustSt.PerformAction(UltraGridAction.EnterEditMode);

                            this.uGrid_SumCustSt.AfterExitEditMode += uGrid_SumCustSt_AfterExitEditMode;
                            return (false);
                        }
                    }

                    if ((sectionCode == "") && (custCode == 0))
                    {
                        continue;
                    }

                    if (sectionCode == "")
                    {
                        this.uGrid_SumCustSt.AfterExitEditMode -= uGrid_SumCustSt_AfterExitEditMode;

                        errMsg = "請求計上拠点コードを入力してください。"; 

                        this.uGrid_SumCustSt.Focus();
                        this.uGrid_SumCustSt.Rows[rowIndex].Cells[COLUMN_DEMANDADDUPSECCD].Activate();
                        this.uGrid_SumCustSt.PerformAction(UltraGridAction.EnterEditMode);

                        this.uGrid_SumCustSt.AfterExitEditMode += uGrid_SumCustSt_AfterExitEditMode;
                        return (false);
                    }

                    if (custCode == 0)
                    {
                        this.uGrid_SumCustSt.AfterExitEditMode -= uGrid_SumCustSt_AfterExitEditMode;

                        errMsg = "得意先コードを入力してください。";
                        this.uGrid_SumCustSt.Focus();
                        this.uGrid_SumCustSt.Rows[rowIndex].Cells[COLUMN_CUSTOMERCD].Activate();
                        this.uGrid_SumCustSt.PerformAction(UltraGridAction.EnterEditMode);

                        this.uGrid_SumCustSt.AfterExitEditMode += uGrid_SumCustSt_AfterExitEditMode;
                        return (false);
                    }

                    // --- ADD m.suzuki 2010/03/12 ---------->>>>>
                    // 請求拠点の整合性チェック
                    CustomerInfo customerInfo;
                    GetCustomerInfo( custCode, out customerInfo );


                    if (customerInfo != null)
                    {
                        // --- DEL 尹鶴凝 2014/02/25 ---------->>>>>
                        //string claimSectionCode = customerInfo.ClaimSectionCode.Trim();
                                                   
                        //// 請求拠点チェック
                        //if (sectionCode != claimSectionCode)
                        //{
                        //    this.uGrid_SumCustSt.AfterExitEditMode -= uGrid_SumCustSt_AfterExitEditMode;

                        //    errMsg = "子得意先は登録できません。";

                        //    this.uGrid_SumCustSt.Focus();
                        //    this.uGrid_SumCustSt.Rows[rowIndex].Cells[COLUMN_CUSTOMERCD].Activate();
                        //    this.uGrid_SumCustSt.PerformAction(UltraGridAction.EnterEditMode);

                        //    this.uGrid_SumCustSt.AfterExitEditMode += uGrid_SumCustSt_AfterExitEditMode;
                        //    return (false);
                        //}
                        // --- DEL 尹鶴凝 2014/02/25 ----------<<<<<
                        
                        // --- ADD 尹鶴凝 2014/02/25 ---------->>>>>
                        if (this._opt_KonMan == (int)Option.ON)
                        {
                            // 請求拠点チェック
                            string tempSectionCode;
                            string errMsgT;

                            if (customerInfo.CustomerCode != customerInfo.ClaimCode)
                            {
                                // 子得意先
                                tempSectionCode = customerInfo.MngSectionCode.Trim();
                                errMsgT = "入力した拠点は得意先の管理拠点ではありません。";
                            }
                            else
                            {
                                // 親得意先
                                tempSectionCode = customerInfo.ClaimSectionCode.Trim();
                                errMsgT = "入力した拠点は請求先の請求拠点ではありません。";
                            }

                            if (sectionCode != tempSectionCode)
                            {
                                this.uGrid_SumCustSt.AfterExitEditMode -= uGrid_SumCustSt_AfterExitEditMode;                              
                                
                                this.uGrid_SumCustSt.Focus();
                                this.uGrid_SumCustSt.Rows[rowIndex].Cells[COLUMN_CUSTOMERCD].Activate();
                                this.uGrid_SumCustSt.PerformAction(UltraGridAction.EnterEditMode);

                                this.uGrid_SumCustSt.AfterExitEditMode += uGrid_SumCustSt_AfterExitEditMode;
                                
                                errMsg = errMsgT;
                                return (false);
                            }
 
                        }
                        else
                        {
                            string claimSectionCode = customerInfo.ClaimSectionCode.Trim();

                            // 請求拠点チェック
                            if (sectionCode != claimSectionCode)
                            {
                                this.uGrid_SumCustSt.AfterExitEditMode -= uGrid_SumCustSt_AfterExitEditMode;

                                errMsg = "子得意先は登録できません。";

                                this.uGrid_SumCustSt.Focus();
                                this.uGrid_SumCustSt.Rows[rowIndex].Cells[COLUMN_CUSTOMERCD].Activate();
                                this.uGrid_SumCustSt.PerformAction(UltraGridAction.EnterEditMode);

                                this.uGrid_SumCustSt.AfterExitEditMode += uGrid_SumCustSt_AfterExitEditMode;
                                return (false);
                            }
                        }
                        // --- ADD 尹鶴凝 2014/02/25 ----------<<<<<

                    }
                    else
                    {
                        // 得意先マスタ未登録
                        this.uGrid_SumCustSt.AfterExitEditMode -= uGrid_SumCustSt_AfterExitEditMode;

                        errMsg = "得意先が未登録です。";
                        this.uGrid_SumCustSt.Focus();
                        this.uGrid_SumCustSt.Rows[rowIndex].Cells[COLUMN_CUSTOMERCD].Activate();
                        this.uGrid_SumCustSt.PerformAction( UltraGridAction.EnterEditMode );

                        this.uGrid_SumCustSt.AfterExitEditMode += uGrid_SumCustSt_AfterExitEditMode;
                        return (false);
                    }
                    // --- ADD m.suzuki 2010/03/12 ----------<<<<<

                    inputFlg = true;
                }

                // 請求計上拠点コード・得意先コードが1件も入力されていなかった場合
                if (inputFlg == false)
                {
                    this.uGrid_SumCustSt.AfterExitEditMode -= uGrid_SumCustSt_AfterExitEditMode;

                    //errMsg = "請求計上拠点コード、得意先コードの登録がありません。";  // DEL 尹鶴凝 2014/02/25
                    // --- ADD 尹鶴凝 2014/02/25 ---------->>>>>
                    if (_opt_KonMan == (int)Option.ON)
                    {
                        errMsg = "拠点コード、得意先コードの登録がありません。";
                    }
                    else
                    {
                        errMsg = "請求計上拠点コード、得意先コードの登録がありません。";
                    }
                    // --- ADD 尹鶴凝 2014/02/25 ----------<<<<<
                    this.uGrid_SumCustSt.Focus();
                    this.uGrid_SumCustSt.Rows[0].Cells[COLUMN_DEMANDADDUPSECCD].Activate();
                    this.uGrid_SumCustSt.PerformAction(UltraGridAction.EnterEditMode);

                    this.uGrid_SumCustSt.AfterExitEditMode += uGrid_SumCustSt_AfterExitEditMode;
                    return (false);
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
        /// <br>Date	   : 2008/10/29</br>
        /// </remarks>
        private bool CompareOriginalScreen()
        {
            // 新規読込時に総括請求得意先コードが入力されていた場合
            if ((this._sumCustStListClone.Count == 0) && (this.Mode_Label.Text == INSERT_MODE))
            {
                if (this.tNedit_CustomerCode.GetInt() != 0)
                {
                    return (false);
                }
            }

            // 保存データ取得
            List<SumCustSt> saveSumCustStList = new List<SumCustSt>();
            try
            {
                saveSumCustStList = GetSaveSumCustStListFromScreen();
            }
            catch
            {
                return (false);
            }

            // 画面読込時と保存データの件数が違う場合
            if (this._sumCustStListClone.Count != saveSumCustStList.Count)
            {
                return (false);
            }

            string key;
            bool sameFlg = false;
            foreach (SumCustSt sumCustSt in this._sumCustStListClone)
            {
                // Key取得
                key = GetKey(sumCustSt);

                // 画面読込時のデータが無い場合
                foreach (SumCustSt saveSumCust in saveSumCustStList)
                {
                    string saveKey = GetKey(saveSumCust);
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
        /// 総括得意先コードチェック処理
        /// </summary>
        /// <param name="customerCode">得意先コード</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 総括得意先コードとして入力できるかチェックします。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date	   : 2008/10/29</br>
        /// <br>Update Note: 2014/02/25  尹鶴凝</br>
        /// <br>管理番号   : 10970685-00</br>
        /// <br>           : 総括得意先、請求得意先に子の得意先を入力できるようにする。</br>
        /// </remarks>
        private bool CheckSumClaimCustCode(int customerCode)
        {
            string errMsg = "";

            try
            {
                //if (this.Mode_Label.Text == INSERT_MODE)
                //{
                //    if (this._mainList.ContainsKey(customerCode))
                //    {
                //        errMsg = "総括得意先として登録されています。";
                //        return (false);
                //    }
                //}

                SumCustSt sumCustSt = this._detailList.Find(delegate(SumCustSt x)
                {
                    if (x.SumClaimCustCode != customerCode)
                    {
                        if (x.CustomerCode == customerCode)
                        {
                            return (true);
                        }
                        else
                        {
                            return (false);
                        }
                    }
                    else
                    {
                        return (false);
                    }
                });
                if (sumCustSt != null)
                {
                    errMsg = "別の総括得意先に請求得意先として登録されています。";
                    return (false);
                }

                CustomerInfo customerInfo;
                int status = GetCustomerInfo(customerCode, out customerInfo);
                if (status != 0)
                {
                    errMsg = "マスタに登録されていません。";
                    return (false);
                }
                else
                {
                    // --- ADD 尹鶴凝 2014/02/25 ---------->>>>>
                    if (_opt_KonMan == (int)Option.OFF)
                    {
                    // --- ADD 尹鶴凝 2014/02/25 ----------<<<<<
                        if (customerInfo.CustomerCode != customerInfo.ClaimCode)
                        {
                            errMsg = "請求得意先ではありません。";
                            return (false);
                        }
                    }// ADD 尹鶴凝 2014/02/25

                    if (customerInfo.AcceptWholeSale == 2)
                    {
                        errMsg = "請求得意先ではありません。";
                        return (false);
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
        /// 請求得意先コードチェック処理
        /// </summary>
        /// <param name="customerCode">得意先コード</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 請求得意先コードとして入力できるかチェックします。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date	   : 2008/10/29</br>
        /// <br>Update Note: 2014/02/25  尹鶴凝</br>
        /// <br>管理番号   : 10970685-00</br>
        /// <br>           : 総括得意先、請求得意先に子の得意先を入力できるようにする。</br>
        /// </remarks>
        private bool CheckCustomerCode(int customerCode, int rowIndex)
        {
            string errMsg = "";

            try
            {
                //if (this.tNedit_CustomerCode.GetInt() == customerCode)
                //{
                //    errMsg = "総括得意先は登録できません。";
                //    return (false);
                //}

                //if (this._mainList.ContainsKey(customerCode))
                //{
                //    errMsg = "総括得意先として登録されています。";
                //    return (false);
                //}

                // 総括得意先コード取得
                int sumClaimCustCode = this.tNedit_CustomerCode.GetInt();

                // --- ADD 尹鶴凝 2014/02/25 ---------->>>>>
                if (_opt_KonMan == (int)Option.ON)
                {
                    SumCustSt custSt = this._detailList.Find(delegate(SumCustSt x)
                    {
                        // 入力した得意先コードが総括得意先場合
                        if (x.SumClaimCustCode == customerCode)
                        {
                            // 総括得意先が自分場合、登録可にする
                            if (sumClaimCustCode == customerCode)
                            {
                                return (false);
                            }
                            // 総括得意先が他の得意先場合、登録不可にする
                            else
                            {
                                return (true);
                            }
                        }
                        // 入力した得意先コードが総括得意先ではない場合、登録可になる
                        else
                        {
                            return (false);
                        }
                    });
                    if (custSt != null)
                    {
                        errMsg = "別の総括得意先に総括得意先として登録されています。";
                        return (false);
                    }
                }
                // --- ADD 尹鶴凝 2014/02/25 ----------<<<<<

                SumCustSt sumCustSt = this._detailList.Find(delegate(SumCustSt x)
                {
                    if (x.SumClaimCustCode == sumClaimCustCode)
                    {
                        return (false);
                    }
                    else
                    {
                        if (x.CustomerCode == customerCode)
                        {
                            return (true);
                        }
                        else
                        {
                            return (false);
                        }
                    }
                });
                if (sumCustSt != null)
                {
                    errMsg = "別の総括得意先に請求得意先として登録されています。";
                    return (false);
                }

                for (int index = 0; index < this.uGrid_SumCustSt.Rows.Count; index++)
                {
                    if (index == rowIndex)
                    {
                        continue;
                    }

                    // 得意先コード取得
                    int customerCd = StrObjectToInt(this.uGrid_SumCustSt.Rows[index].Cells[COLUMN_CUSTOMERCD].Value);

                    if (customerCd == customerCode)
                    {
                        errMsg = "別の行に請求得意先として登録されています。";
                        return (false);
                    }
                }

                CustomerInfo customerInfo;
                int status = GetCustomerInfo(customerCode, out customerInfo);
                if (status != 0)
                {
                    errMsg = "マスタに登録されていません。";
                    return (false);
                }
                else
                {
                    if (this.tNedit_CustomerCode.GetInt() != 0)
                    {
                        if (customerInfo.TotalDay != this._sumCustTotalDay)
                        {
                            errMsg = "総括得意先と締日が異なります。";
                            return (false);
                        }
                    }


                    if (customerInfo.CustomerCode != customerInfo.ClaimCode)
                    {
                        // --- DEL 尹鶴凝 2014/02/25 ---------->>>>>
                        //errMsg = "請求得意先ではありません。";
                        //return (false);
                        // --- DEL 尹鶴凝 2014/02/25 ----------<<<<<

                        // --- ADD 尹鶴凝 2014/02/25 ---------->>>>>
                        if (_opt_KonMan == (int)Option.ON)
                        {
                            string sectionCd = StrObjectToString(this.uGrid_SumCustSt.Rows[rowIndex].Cells[COLUMN_DEMANDADDUPSECCD].Value);
                            if (!string.IsNullOrEmpty(sectionCd) && !customerInfo.MngSectionCode.Trim().Equals(sectionCd))
                            {
                                errMsg = "入力した拠点は得意先の管理拠点ではありません。";
                                return (false);
                            }
                        }
                        else
                        {
                            errMsg = "請求得意先ではありません。";
                            return (false);
                        }
                        // --- ADD 尹鶴凝 2014/02/25 ----------<<<<<
                    }


                    if (customerInfo.AcceptWholeSale == 2)
                    {
                        errMsg = "請求得意先ではありません。";
                        return (false);
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
        /// 拠点コードチェック処理
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 拠点コードがマスタに存在するかチェックします。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date	   : 2008/10/29</br>
        /// </remarks>
        private bool CheckSectionCode(string sectionCode)
        {
            string errMsg = "";

            try
            {
                if (this._secInfoSetDic.ContainsKey(sectionCode.Trim()) == false)
                {
                    errMsg = "拠点情報設定マスタに登録されていません。";
                    return (false);
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
        /// 排他処理
        /// </summary>
        /// <param name="status">STATUS</param>
        /// <remarks>
        /// <br>Note       : 排他処理を行います</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/10/29</br>
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
        /// <br>Date       : 2008/10/29</br>
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
        /// <br>Date       : 2008/10/29</br>
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
                                         this._sumCustStAcs,			    // エラーが発生したオブジェクト
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
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/10/29</br>
        /// </remarks>
        private void ClearRow(int rowIndex)
        {
            this.uGrid_SumCustSt.Rows[rowIndex].Cells[COLUMN_DEMANDADDUPSECCD].Value = "";
            this.uGrid_SumCustSt.Rows[rowIndex].Cells[COLUMN_DEMANDADDUPSECNM].Value = "";
            this.uGrid_SumCustSt.Rows[rowIndex].Cells[COLUMN_CUSTOMERCD].Value = "";
            this.uGrid_SumCustSt.Rows[rowIndex].Cells[COLUMN_CUSTOMERNM].Value = "";
            this.uGrid_SumCustSt.Rows[rowIndex].Cells[COLUMN_DEMANDADDUPSECCD].Tag = "";
            this.uGrid_SumCustSt.Rows[rowIndex].Cells[COLUMN_CUSTOMERCD].Tag = "";
        }

        /// <summary>
        /// 新規行作成処理
        /// </summary>
        /// <param name="uGrid">グリッド</param>
        /// <remarks>
        /// <br>Note       : グリッドに行を追加します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/10/29</br>
        /// </remarks>
        private void CreateNewRow(ref UltraGrid uGrid)
        {
            // 行追加
            uGrid.DisplayLayout.Bands[0].AddNew();

            // 行番号設定
            uGrid.Rows[uGrid.Rows.Count - 1].Cells[COLUMN_NO].Value = uGrid.Rows.Count;

            uGrid.Rows[uGrid.Rows.Count - 1].Cells[COLUMN_DEMANDADDUPSECCD].Tag = "";
            uGrid.Rows[uGrid.Rows.Count - 1].Cells[COLUMN_CUSTOMERCD].Tag = "";
        }

        /// <summary>
        /// 変換処理(object→string)
        /// </summary>
        /// <param name="targetValue">変換対象object</param>
        /// <returns>文字列</returns>
        /// <remarks>
        /// <br>Note       : object型をstringに変換します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/10/29</br>
        /// </remarks>
        private string StrObjectToString(object targetValue)
        {
            if ((targetValue == DBNull.Value) || (targetValue == null) || ((string)targetValue == ""))
            {
                return "";
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
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/10/29</br>
        /// </remarks>
        private int StrObjectToInt(object targetValue)
        {
            if ((targetValue == DBNull.Value) || (targetValue == null) || ((string)targetValue == "") || (int.Parse((string)targetValue) == 0))
            {
                return 0;
            }

            return int.Parse((string)targetValue);
        }

        private string CellTextToString(string cellText)
        {
            if ((cellText == null) || (cellText.Trim() == ""))
            {
                return "";
            }

            return cellText.Trim().PadLeft(2, '0');
        }

        private int CellTextToInt(string cellText)
        {
            if ((cellText == null) || (cellText.Trim() == ""))
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
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date	   : 2008/10/29</br>
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
                    uGrid.Rows[0].Cells[COLUMN_DEMANDADDUPSECCD].Activate();
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
                            uGrid.Rows[rowIndex].Cells[COLUMN_DEMANDADDUPSECCD].Activate();
                            uGrid.PerformAction(UltraGridAction.EnterEditMode);
                            return;
                        }

                        // 拠点名取得
                        string sectionName = StrObjectToString(uGrid.Rows[rowIndex].Cells[COLUMN_DEMANDADDUPSECNM].Value);

                        if (sectionName == "")
                        {
                            // 拠点ガイドにフォーカス
                            uGrid.Rows[rowIndex].Cells[COLUMN_SECTIONGUIDE].Activate();
                        }
                        else
                        {
                            // 得意先コードにフォーカス
                            uGrid.Rows[rowIndex].Cells[COLUMN_CUSTOMERCD].Activate();
                        }

                        uGrid.PerformAction(UltraGridAction.EnterEditMode);
                        return;
                    }
                case 3:       // 拠点ガイド
                    {
                        // 得意先コードにフォーカス
                        uGrid.Rows[rowIndex].Cells[COLUMN_CUSTOMERCD].Activate();
                        uGrid.PerformAction(UltraGridAction.EnterEditMode);
                        return;
                    }
                case 4:         // 得意先コード
                    {
                        if (!this._checkCustomerFlg)
                        {
                            // 得意先コードにフォーカス
                            uGrid.Rows[rowIndex].Cells[COLUMN_CUSTOMERCD].Activate();
                            uGrid.PerformAction(UltraGridAction.EnterEditMode);
                            return;
                        }

                        // 得意先名取得
                        string customerName = StrObjectToString(uGrid.Rows[rowIndex].Cells[COLUMN_CUSTOMERNM].Value);

                        if (customerName == "")
                        {
                            // 得意先ガイドにフォーカス
                            uGrid.Rows[rowIndex].Cells[COLUMN_CUSTOMERGUIDE].Activate();
                        }
                        else
                        {
                            if (rowIndex == uGrid.Rows.Count - 1)
                            {
                                // 保存ボタンにフォーカス
                                e.NextCtrl = this.Ok_Button;
                            }
                            else
                            {
                                // 拠点コードにフォーカス
                                uGrid.Rows[rowIndex + 1].Cells[COLUMN_DEMANDADDUPSECCD].Activate();
                                uGrid.PerformAction(UltraGridAction.EnterEditMode);
                            }
                        }

                        return;
                    }
                case 6:      // 得意先ガイド
                    {
                        if (rowIndex == uGrid.Rows.Count - 1)
                        {
                            // 保存ボタンにフォーカス
                            e.NextCtrl = this.Ok_Button;
                        }
                        else
                        {
                            // 拠点コードにフォーカス
                            uGrid.Rows[rowIndex + 1].Cells[COLUMN_DEMANDADDUPSECCD].Activate();
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
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date	   : 2008/10/29</br>
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
                            uGrid.Rows[rowIndex].Cells[COLUMN_DEMANDADDUPSECCD].Activate();
                            uGrid.PerformAction(UltraGridAction.EnterEditMode);
                            return;
                        }

                        string customerName;

                        if (rowIndex == 0)
                        {
                            // 得意先名取得
                            customerName = this.tEdit_CustomerName.DataText.Trim();

                            if (customerName == "")
                            {
                                // 得意先ガイドにフォーカス
                                e.NextCtrl = this.CustomerGuide_Button;
                            }
                            else
                            {
                                // 得意先コードにフォーカス
                                e.NextCtrl = this.tNedit_CustomerCode;
                            }
                        }
                        else
                        {
                            // 得意先名取得
                            customerName = StrObjectToString(uGrid.Rows[rowIndex - 1].Cells[COLUMN_CUSTOMERNM].Value);

                            if (customerName == "")
                            {
                                // 得意先ガイドにフォーカス
                                uGrid.Rows[rowIndex - 1].Cells[COLUMN_CUSTOMERGUIDE].Activate();
                            }
                            else
                            {
                                // 得意先コードにフォーカス
                                uGrid.Rows[rowIndex - 1].Cells[COLUMN_CUSTOMERCD].Activate();
                            }

                            uGrid.PerformAction(UltraGridAction.EnterEditMode);
                        }

                        return;
                    }
                case 3:       // 拠点ガイド
                    {
                        // 拠点コードにフォーカス
                        uGrid.Rows[rowIndex].Cells[COLUMN_DEMANDADDUPSECCD].Activate();
                        uGrid.PerformAction(UltraGridAction.EnterEditMode);
                        return;
                    }
                case 4:         // 得意先コード
                    {
                        if (!this._checkCustomerFlg)
                        {
                            // 得意先コードにフォーカス
                            uGrid.Rows[rowIndex].Cells[COLUMN_CUSTOMERCD].Activate();
                            uGrid.PerformAction(UltraGridAction.EnterEditMode);
                            return;
                        }

                        // 拠点名取得
                        string sectionName = StrObjectToString(uGrid.Rows[rowIndex].Cells[COLUMN_DEMANDADDUPSECNM].Value);

                        if (sectionName == "")
                        {
                            // 拠点ガイドにフォーカス
                            uGrid.Rows[rowIndex].Cells[COLUMN_SECTIONGUIDE].Activate();
                        }
                        else
                        {
                            // 拠点コードにフォーカス
                            uGrid.Rows[rowIndex].Cells[COLUMN_DEMANDADDUPSECCD].Activate();
                        }

                        uGrid.PerformAction(UltraGridAction.EnterEditMode);
                        return;
                    }
                case 6:      // 得意先ガイド
                    {
                        // 得意先コードにフォーカス
                        uGrid.Rows[rowIndex].Cells[COLUMN_CUSTOMERCD].Activate();
                        uGrid.PerformAction(UltraGridAction.EnterEditMode);
                        return;
                    }
            }
        }

        // ADD 尹鶴凝 2014/02/25 ------------------------------------->>>>>
        /// <summary>
        /// オプション有効有無
        /// </summary>
        public enum Option : int
        {
            /// <summary>無効</summary>
            OFF = 0,
            /// <summary>有効</summary>
            ON = 1,
        }

        /// <summary>
        /// オプションキーをチェックする
        /// </summary>
        private void CheckOptionKey()
        {
            Broadleaf.Application.Remoting.ParamData.PurchaseStatus ps;
            #region
            ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CPM_KonmanGoodsMstCtl);
            if (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                this._opt_KonMan = (int)Option.ON;
            }
            else
            {
                this._opt_KonMan = (int)Option.OFF;
            }
            #endregion
        }
        // ADD 尹鶴凝 2014/02/25 -------------------------------------<<<<<
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
        /// <br>Date	   : 2008/10/29</br>
        /// </remarks>
        private void PMKHN09241UA_Load(object sender, EventArgs e)
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
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date	   : 2008/10/29</br>
        /// </remarks>
        private void PMKHN09241UA_FormClosing(object sender, FormClosingEventArgs e)
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
        /// <br>Date	   : 2008/10/29</br>
        /// </remarks>
        private void PMKHN09241UA_VisibleChanged(object sender, EventArgs e)
        {
            // 自分自身が非表示になった場合は以下の処理をキャンセルする。
            if (this.Visible == false)
            {
                this.Owner.Activate();
                
                // --- ADD 尹鶴凝 2014/02/25 ----------<<<<<
                // 画面クリア
                ScreenClear();
                // --- ADD 尹鶴凝 2014/02/25 ---------->>>>>
                
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
        /// <br>Date	   : 2008/10/29</br>
        /// </remarks>
        private void CustomerGuide_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                this._cusotmerGuideSelected = false;
                this._gridCustomerGuideFlg = false;

                // 得意先ガイド
                PMKHN04005UA customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_CUSTOMER_ONLY, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY);

                customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.CustomerSearchForm_CustomerSelect);
                customerSearchForm.ShowDialog(this);

                // フォーカス設定
                if (this._cusotmerGuideSelected == true)
                {
                    this.uGrid_SumCustSt.Focus();
                    this.uGrid_SumCustSt.Rows[0].Cells[COLUMN_DEMANDADDUPSECCD].Activate();
                    this.uGrid_SumCustSt.PerformAction(UltraGridAction.EnterEditMode);
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
        /// <br>Note       : 得意先選択時に発生します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/10/29</br>
        /// <br>Update Note: 2014/02/25  尹鶴凝</br>
        /// <br>管理番号   : 10970685-00</br>
        /// <br>           : 総括得意先、請求得意先に子の得意先を入力できるようにする。</br>
        /// </remarks>
        private void CustomerSearchForm_CustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        {
            if (customerSearchRet == null)
            {
                this._cusotmerGuideSelected = false;
                return;
            }

            if (!this._gridCustomerGuideFlg)
            {
                bool bStatus = CheckSumClaimCustCode(customerSearchRet.CustomerCode);
                if (!bStatus)
                {
                    this._sumCustTotalDay = 0;
                    return;
                }

                // 得意先コード
                this.tNedit_CustomerCode.SetInt(customerSearchRet.CustomerCode);
                // 得意先名称
                this.tEdit_CustomerName.DataText = customerSearchRet.Snm.Trim();
                // 締日
                this._sumCustTotalDay = customerSearchRet.TotalDay;
            }
            else
            {
                bool bStatus = CheckCustomerCode(customerSearchRet.CustomerCode, this.uGrid_SumCustSt.ActiveCell.Row.Index);
                if (!bStatus)
                {
                    return;
                }

                int rowIndex = this.uGrid_SumCustSt.ActiveCell.Row.Index;

                // --- ADD m.suzuki 2010/03/12 ---------->>>>>
                string sectionCode = string.Empty;

                // 請求拠点コード取得
                CustomerInfo customerInfo;
                GetCustomerInfo( customerSearchRet.CustomerCode, out customerInfo );
                if ( customerInfo != null )
                {
                    // sectionCode = customerInfo.ClaimSectionCode.Trim();  // DEL 尹鶴凝 2014/02/25
                    
                    // --- ADD 尹鶴凝 2014/02/25 ---------->>>>>
                    if (_opt_KonMan == (int)Option.ON)
                    {
                        if (customerInfo.CustomerCode != customerInfo.ClaimCode)
                        {
                            sectionCode = customerInfo.MngSectionCode.Trim();
                        }
                        else
                        {
                            sectionCode = customerInfo.ClaimSectionCode.Trim();
                        }
                    }
                    else
                    {
                        sectionCode = customerInfo.ClaimSectionCode.Trim();
                    }
                    // --- ADD 尹鶴凝 2014/02/25 ----------<<<<<
                }

                string inputSectionCode = StrObjectToString( this.uGrid_SumCustSt.Rows[this.uGrid_SumCustSt.ActiveCell.Row.Index].Cells[COLUMN_DEMANDADDUPSECCD].Value );
                if ( string.IsNullOrEmpty( inputSectionCode ) )
                {
                    // 拠点未入力ならば請求拠点セット
                    this.uGrid_SumCustSt.Rows[rowIndex].Cells[COLUMN_DEMANDADDUPSECCD].Value = sectionCode;
                    this.uGrid_SumCustSt.Rows[rowIndex].Cells[COLUMN_DEMANDADDUPSECCD].Tag = sectionCode;
                    this.uGrid_SumCustSt.Rows[rowIndex].Cells[COLUMN_DEMANDADDUPSECNM].Value = GetSectionName( sectionCode );
                }
                else if ( sectionCode != inputSectionCode )
                {
                    // --- DEL 尹鶴凝 2014/02/25 ---------->>>>>
                    // 拠点入力済みで得意先マスタの請求拠点と異なるならば、エラー表示(得意先をエラー扱いする)
                    //ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                    //               "子得意先は登録できません。",
                    //               -1,
                    //               MessageBoxButtons.OK,
                    //               MessageBoxDefaultButton.Button1);
                    // --- DEL 尹鶴凝 2014/02/25 ----------<<<<<

                    // --- ADD 尹鶴凝 2014/02/25 ---------->>>>>
                    if (_opt_KonMan == (int)Option.ON)
                    {
                        if (customerInfo.CustomerCode == customerInfo.ClaimCode)
                        {
                            ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                                           "入力した拠点は請求先の請求拠点ではありません。",
                                           -1,
                                           MessageBoxButtons.OK,
                                           MessageBoxDefaultButton.Button1);
                        }
                        else
                        {
                            ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                                           "入力した拠点は得意先の管理拠点ではありません。",
                                           -1,
                                           MessageBoxButtons.OK,
                                           MessageBoxDefaultButton.Button1);
                        }
                    }
                    else
                    {
                        //拠点入力済みで得意先マスタの請求拠点と異なるならば、エラー表示(得意先をエラー扱いする)
                        ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                                       "子得意先は登録できません。",
                                       -1,
                                       MessageBoxButtons.OK,
                                       MessageBoxDefaultButton.Button1);
                    }
                    // --- ADD 尹鶴凝 2014/02/25 ----------<<<<<
                    return;
                }
                // --- ADD m.suzuki 2010/03/12 ----------<<<<<

                // 得意先コード
                this.uGrid_SumCustSt.Rows[rowIndex].Cells[COLUMN_CUSTOMERCD].Value = customerSearchRet.CustomerCode.ToString("00000000");
                // --- ADD m.suzuki 2010/03/12 ---------->>>>>
                this.uGrid_SumCustSt.Rows[rowIndex].Cells[COLUMN_CUSTOMERCD].Tag = customerSearchRet.CustomerCode.ToString( "00000000" );
                // --- ADD m.suzuki 2010/03/12 ----------<<<<<
                // 得意先名称
                this.uGrid_SumCustSt.Rows[rowIndex].Cells[COLUMN_CUSTOMERNM].Value = customerSearchRet.Snm.Trim();
            }

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
        /// <br>Date	   : 2008/10/29</br>
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
        /// <br>Date	   : 2008/10/29</br>
        /// </remarks>
        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            // 削除モード以外の場合は保存確認処理を行う
            if (this.Mode_Label.Text != DELETE_MODE)
            {
                //if (this.uGrid_SumCustSt.ActiveCell != null)
                //{
                //    UltraGridCell uGrid = this.uGrid_SumCustSt.ActiveCell;

                //    this.uGrid_SumCustSt.PerformAction(UltraGridAction.ExitEditMode);
                //    if (uGrid.Column.Key == COLUMN_DEMANDADDUPSECCD)
                //    {
                //        if (this._checkSectionFlg == false)
                //        {
                //            this.uGrid_SumCustSt.ActiveCell = uGrid;
                //            this.uGrid_SumCustSt.PerformAction(UltraGridAction.EnterEditMode);
                //            return;
                //        }
                //    }
                //    else if (uGrid.Column.Key == COLUMN_CUSTOMERCD)
                //    {
                //        if (this._checkCustomerFlg == false)
                //        {
                //            this.uGrid_SumCustSt.ActiveCell = uGrid;
                //            this.uGrid_SumCustSt.PerformAction(UltraGridAction.EnterEditMode);
                //            return;
                //        }
                //    }
                //}

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
        /// <br>Date	   : 2008/10/29</br>
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
        /// <br>Date	   : 2008/10/29</br>
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
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date	   : 2008/10/29</br>
        /// </remarks>
        private void uGrid_SumCustSt_BeforeEnterEditMode(object sender, CancelEventArgs e)
        {
            // --- ADD m.suzuki 2010/03/12 ---------->>>>>
            _beforeCellText = string.Empty;
            // --- ADD m.suzuki 2010/03/12 ----------<<<<<

            UltraGrid uGrid = (UltraGrid)sender;

            if (uGrid.ActiveCell == null)
            {
                return;
            }

            if ((uGrid.ActiveCell.Value == DBNull.Value) || ((string)uGrid.ActiveCell.Value == ""))
            {
                return;
            }
            // --- ADD m.suzuki 2010/03/12 ---------->>>>>
            // 前回値退避
            _beforeCellText = StrObjectToString( uGrid.ActiveCell.Value );
            // --- ADD m.suzuki 2010/03/12 ----------<<<<<

            int custRateGroup = int.Parse((string)uGrid.ActiveCell.Value);

            // ゼロ詰め解除
            uGrid.ActiveCell.Value = custRateGroup.ToString();
        }

        /// <summary>
        /// AfterExitEditMode イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : 編集モードが終了した時に発生します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date	   : 2008/10/29</br>
        /// <br>Update Note: 2014/02/25  尹鶴凝</br>
        /// <br>管理番号   : 10970685-00</br>
        /// <br>           : 総括得意先、請求得意先に子の得意先を入力できるようにする。</br>
        /// </remarks>
        private void uGrid_SumCustSt_AfterExitEditMode(object sender, EventArgs e)
        {
            UltraGrid uGrid = (UltraGrid)sender;

            if (uGrid.ActiveCell == null)
            {
                return;
            }

            switch (uGrid.ActiveCell.Column.Key)
            {
                case COLUMN_DEMANDADDUPSECCD:
                    {
                        this._checkSectionFlg = true;

                        // ゼロ詰め
                        uGrid.ActiveCell.Value = this.uiSetControl1.GetZeroPaddedText(uGrid.ActiveCell.Column.Key, uGrid.ActiveCell.Value.ToString());

                        // 拠点コード取得
                        string sectionCode = StrObjectToString(uGrid.ActiveCell.Value);

                        if (sectionCode == "")
                        {
                            if (StrObjectToString(uGrid.ActiveCell.Tag) != "")
                            {
                                // 行クリア
                                ClearRow(uGrid_SumCustSt.ActiveCell.Row.Index);
                            }
                        }
                        else
                        {
                            // --- ADD m.suzuki 2010/03/12 ---------->>>>>
                            // 前回入力ありで、かつ変更された場合
                            if ( !string.IsNullOrEmpty( _beforeCellText ) && _beforeCellText != sectionCode )
                            {
                                // 請求得意先クリア
                                uGrid.Rows[uGrid.ActiveCell.Row.Index].Cells[COLUMN_CUSTOMERCD].Value = "";
                                uGrid.Rows[uGrid.ActiveCell.Row.Index].Cells[COLUMN_CUSTOMERNM].Value = "";
                                uGrid.Rows[uGrid.ActiveCell.Row.Index].Cells[COLUMN_CUSTOMERCD].Tag = "";
                            }
                            // --- ADD m.suzuki 2010/03/12 ----------<<<<<


                            bool bStatus = CheckSectionCode(sectionCode);
                            if (!bStatus)
                            {
                                this._checkSectionFlg = false;
                                return;
                            }

                            // 拠点名取得
                            uGrid.Rows[uGrid.ActiveCell.Row.Index].Cells[COLUMN_DEMANDADDUPSECNM].Value = GetSectionName(sectionCode);

                            uGrid.Rows[uGrid.ActiveCell.Row.Index].Cells[COLUMN_DEMANDADDUPSECCD].Tag = sectionCode;

                            if (uGrid.ActiveCell.Row.Index == uGrid.Rows.Count - 1)
                            {
                                // 最終行だった場合、行追加
                                CreateNewRow(ref uGrid);
                            }
                        }

                        break;
                    }
                case COLUMN_CUSTOMERCD:
                    {
                        this._checkCustomerFlg = true;
                        
                        // ゼロ詰め
                        uGrid.ActiveCell.Value = this.uiSetControl1.GetZeroPaddedText(uGrid.ActiveCell.Column.Key, uGrid.ActiveCell.Value.ToString());

                        int customerCode = StrObjectToInt(uGrid.ActiveCell.Value);

                        if (customerCode == 0)
                        {
                            if (StrObjectToInt(uGrid.ActiveCell.Tag) != 0)
                            {
                                // 行クリア
                                ClearRow(uGrid_SumCustSt.ActiveCell.Row.Index);
                            }
                        }
                        else
                        {
                            bool bStatus = CheckCustomerCode(customerCode, uGrid.ActiveCell.Row.Index);
                            if (!bStatus)
                            {
                                this._checkCustomerFlg = false;
                                return;
                            }

                            // 得意先名取得
                            uGrid.Rows[uGrid.ActiveCell.Row.Index].Cells[COLUMN_CUSTOMERNM].Value = GetCustomerName(customerCode);

                            uGrid.Rows[uGrid.ActiveCell.Row.Index].Cells[COLUMN_CUSTOMERCD].Tag = customerCode.ToString("00000000");

                            // --- ADD m.suzuki 2010/03/12 ---------->>>>>
                            if ( _beforeCellText != customerCode.ToString( "00000000" ) )
                            {
                                string sectionCode = string.Empty;

                                // 請求拠点コード取得
                                CustomerInfo customerInfo;
                                GetCustomerInfo( customerCode, out customerInfo );
                                if ( customerInfo != null )
                                {
                                    // sectionCode = customerInfo.ClaimSectionCode.Trim();  // DEL 尹鶴凝 2014/02/25

                                    // --- ADD 尹鶴凝 2014/02/25 ---------->>>>>
                                    if (_opt_KonMan == (int)Option.ON)
                                    {
                                        if (customerInfo.CustomerCode != customerInfo.ClaimCode)
                                        {
                                            sectionCode = customerInfo.MngSectionCode.Trim();
                                        }
                                        else
                                        {
                                            sectionCode = customerInfo.ClaimSectionCode.Trim();
                                        }
                                    }
                                    else
                                    {
                                        sectionCode = customerInfo.ClaimSectionCode.Trim();
                                    }
                                    // --- ADD 尹鶴凝 2014/02/25 ----------<<<<<
                                }

                                string inputSectionCode = StrObjectToString( uGrid.Rows[uGrid.ActiveCell.Row.Index].Cells[COLUMN_DEMANDADDUPSECCD].Value );
                                if ( string.IsNullOrEmpty( inputSectionCode ) )
                                {
                                    // 拠点未入力ならば請求拠点セット
                                    uGrid.Rows[uGrid.ActiveCell.Row.Index].Cells[COLUMN_DEMANDADDUPSECCD].Value = sectionCode;
                                    uGrid.Rows[uGrid.ActiveCell.Row.Index].Cells[COLUMN_DEMANDADDUPSECCD].Tag = sectionCode;
                                    uGrid.Rows[uGrid.ActiveCell.Row.Index].Cells[COLUMN_DEMANDADDUPSECNM].Value = GetSectionName( sectionCode );
                                }
                                else if (sectionCode != inputSectionCode)
                                {
                                    // --- DEL 尹鶴凝 2014/02/25 ---------->>>>>
                                    // 拠点入力済みで得意先マスタの請求拠点と異なるならば、エラー表示(得意先をエラー扱いする)
                                    //ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                                    //               "子得意先は登録できません。",
                                    //               -1,
                                    //               MessageBoxButtons.OK,
                                    //               MessageBoxDefaultButton.Button1);
                                    // --- DEL 尹鶴凝 2014/02/25 ----------<<<<<


                                    // --- ADD 尹鶴凝 2014/02/25 ---------->>>>>
                                    if (_opt_KonMan == (int)Option.ON)
                                    {
                                        if (customerInfo.CustomerCode == customerInfo.ClaimCode)
                                        {
                                            ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                                                           "入力した拠点は請求先の請求拠点ではありません。",
                                                           -1,
                                                           MessageBoxButtons.OK,
                                                           MessageBoxDefaultButton.Button1);
                                        }
                                        else
                                        {
                                            ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                                                           "入力した拠点は得意先の管理拠点ではありません。",
                                                           -1,
                                                           MessageBoxButtons.OK,
                                                           MessageBoxDefaultButton.Button1);
                                        }
                                    }
                                    else
                                    {
                                        //拠点入力済みで得意先マスタの請求拠点と異なるならば、エラー表示(得意先をエラー扱いする)
                                        ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                                                       "子得意先は登録できません。",
                                                       -1,
                                                       MessageBoxButtons.OK,
                                                       MessageBoxDefaultButton.Button1);
                                    }
                                    // --- ADD 尹鶴凝 2014/02/25 ----------<<<<<

                                    // 得意先クリア
                                    uGrid.Rows[uGrid.ActiveCell.Row.Index].Cells[COLUMN_CUSTOMERCD].Value = string.Empty;
                                    uGrid.Rows[uGrid.ActiveCell.Row.Index].Cells[COLUMN_CUSTOMERCD].Tag = string.Empty;
                                    uGrid.Rows[uGrid.ActiveCell.Row.Index].Cells[COLUMN_CUSTOMERNM].Value = string.Empty;

                                    // エラーモード
                                    this._checkCustomerFlg = false;
                                }
                            }
                            // --- ADD m.suzuki 2010/03/12 ----------<<<<<

                            if (uGrid.ActiveCell.Row.Index == uGrid.Rows.Count - 1)
                            {
                                // 最終行だった場合、行追加
                                CreateNewRow(ref uGrid);
                            }
                        }

                        break;
                    }
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
        /// <br>Date	   : 2008/10/29</br>
        /// </remarks>
        private void uGrid_SumCustSt_KeyDown(object sender, KeyEventArgs e)
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
                        else if ((columnIndex == 4) && (this._checkCustomerFlg == false))
                        {
                            uGrid.PerformAction(UltraGridAction.EnterEditMode);
                            return;
                        }

                        if (rowIndex == 0)
                        {
                            // 得意先コードにフォーカス
                            this.tNedit_CustomerCode.Focus();
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
                        else if ((columnIndex == 4) && (this._checkCustomerFlg == false))
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
                                else if ((columnIndex == 4) && (this._checkCustomerFlg == false))
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
                                else if ((columnIndex == 4) && (this._checkCustomerFlg == false))
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

                        uGrid_SumCustSt_ClickCellButton(uGrid, new CellEventArgs(uGrid.ActiveCell));
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
        /// <br>Date	   : 2008/10/29</br>
        /// </remarks>
        private void uGrid_SumCustSt_KeyPress(object sender, KeyPressEventArgs e)
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
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date	   : 2008/10/29</br>
        /// </remarks>
        private void uGrid_SumCustSt_Leave(object sender, EventArgs e)
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
        /// <br>Note       : セルボタンをクリックされた時に発生します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date	   : 2008/10/29</br>
        /// </remarks>
        private void uGrid_SumCustSt_ClickCellButton(object sender, CellEventArgs e)
        {
            UltraGrid uGrid = (UltraGrid)sender;

            int status;

            switch (e.Cell.Column.Key)
            {
                case COLUMN_SECTIONGUIDE:   // 拠点ガイドボタン
                    {
                        // --- ADD m.suzuki 2010/03/12 ---------->>>>>
                        // ガイド前の値を退避
                        string beforeSectionCode = StrObjectToString( uGrid.Rows[e.Cell.Row.Index].Cells[COLUMN_DEMANDADDUPSECCD].Value );
                        // --- ADD m.suzuki 2010/03/12 ----------<<<<<

                        SecInfoSet secInfoSet;

                        status = this._secInfoSetAcs.ExecuteGuid(this._enterpriseCode, false, out secInfoSet);
                        if (status == 0)
                        {
                            // 拠点コード
                            uGrid.Rows[e.Cell.Row.Index].Cells[COLUMN_DEMANDADDUPSECCD].Value = secInfoSet.SectionCode.Trim();
                            // --- ADD m.suzuki 2010/03/12 ---------->>>>>
                            uGrid.Rows[e.Cell.Row.Index].Cells[COLUMN_DEMANDADDUPSECCD].Tag = secInfoSet.SectionCode.Trim();
                            // --- ADD m.suzuki 2010/03/12 ----------<<<<<
                            // 拠点名
                            uGrid.Rows[e.Cell.Row.Index].Cells[COLUMN_DEMANDADDUPSECNM].Value = GetSectionName(secInfoSet.SectionCode.Trim());

                            // --- ADD m.suzuki 2010/03/12 ---------->>>>>
                            // 前回入力ありで、かつ変更された場合
                            if ( !string.IsNullOrEmpty( beforeSectionCode ) && beforeSectionCode != secInfoSet.SectionCode.Trim() )
                            {
                                // 請求得意先クリア
                                uGrid.Rows[uGrid.ActiveCell.Row.Index].Cells[COLUMN_CUSTOMERCD].Value = "";
                                uGrid.Rows[uGrid.ActiveCell.Row.Index].Cells[COLUMN_CUSTOMERNM].Value = "";
                                uGrid.Rows[uGrid.ActiveCell.Row.Index].Cells[COLUMN_CUSTOMERCD].Tag = "";
                            }
                            // --- ADD m.suzuki 2010/03/12 ----------<<<<<

                            if (e.Cell.Row.Index == uGrid.Rows.Count - 1)
                            {
                                // 最終行だった場合、行を追加
                                CreateNewRow(ref uGrid);
                            }

                            // フォーカス設定
                            uGrid.Rows[e.Cell.Row.Index].Cells[COLUMN_CUSTOMERCD].Activate();
                            uGrid.PerformAction(UltraGridAction.EnterEditMode);
                        }
                        break;
                    }
                case COLUMN_CUSTOMERGUIDE:  // 得意先ガイドボタン
                    {
                        this._cusotmerGuideSelected = false;
                        this._gridCustomerGuideFlg = true;

                        // 得意先ガイド
                        PMKHN04005UA customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_CUSTOMER_ONLY, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY);

                        customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.CustomerSearchForm_CustomerSelect);
                        customerSearchForm.ShowDialog(this);

                        // フォーカス設定
                        if (this._cusotmerGuideSelected == true)
                        {
                            if (e.Cell.Row.Index == uGrid.Rows.Count - 1)
                            {
                                // 最終行だった場合、行を追加
                                CreateNewRow(ref uGrid);
                            }

                            uGrid.Rows[e.Cell.Row.Index + 1].Cells[COLUMN_DEMANDADDUPSECCD].Activate();
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
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date	   : 2008/10/29</br>
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
        /// <br>Date	   : 2008/10/29</br>
        /// </remarks>
        private void tRetKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null)
            {
                return;
            }

            if (e.NextCtrl == this.Cancel_Button)
            {
                Cancel_Button_Click(this.Cancel_Button, new EventArgs());
                return;
            }

            switch (e.PrevCtrl.Name)
            {
                case "tNedit_CustomerCode":
                    {
                        if (this.tNedit_CustomerCode.GetInt() == 0)
                        {
                            this.tEdit_CustomerName.Clear();
                            this._sumCustTotalDay = 0;
                            break;
                        }

                        // 得意先コード取得
                        int customerCode = this.tNedit_CustomerCode.GetInt();

                        bool bStatus = CheckSumClaimCustCode(customerCode);
                        if (!bStatus)
                        {
                            e.NextCtrl = e.PrevCtrl;
                            this._sumCustTotalDay = 0;
                            this.tNedit_CustomerCode.SelectAll();
                            return;
                        }

                        // 締日取得
                        this._sumCustTotalDay = this._customerSearchRetDic[customerCode].TotalDay;

                        // 得意先名取得
                        this.tEdit_CustomerName.DataText = this._customerSearchRetDic[customerCode].Snm.Trim();

                        if (this.tEdit_CustomerName.DataText.Trim() != "")
                        {
                            if (e.ShiftKey == false)
                            {
                                if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter) || (e.Key == Keys.Down))
                                {
                                    e.NextCtrl = null;
                                    this.uGrid_SumCustSt.Rows[0].Cells[COLUMN_DEMANDADDUPSECCD].Activate();
                                    this.uGrid_SumCustSt.PerformAction(UltraGridAction.EnterEditMode);
                                    return;
                                }
                            }
                        }

                        break;
                    }
                case "uGrid_SumCustSt":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                SetNextFocus(this.uGrid_SumCustSt, ref e);
                            }
                        }
                        else
                        {
                            if (e.Key == Keys.Tab)
                            {
                                SetBeforeFocus(this.uGrid_SumCustSt, ref e);
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
                case "uGrid_SumCustSt":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter) || (e.Key == Keys.Down))
                            {
                                e.NextCtrl = null;
                                this.uGrid_SumCustSt.Rows[0].Cells[COLUMN_DEMANDADDUPSECCD].Activate();
                                this.uGrid_SumCustSt.PerformAction(UltraGridAction.EnterEditMode);
                                return;
                            }
                            else if (e.Key == Keys.Up)
                            {
                                e.NextCtrl = null;
                                this.uGrid_SumCustSt.Rows[this.uGrid_SumCustSt.Rows.Count - 1].Cells[COLUMN_CUSTOMERCD].Activate();
                                this.uGrid_SumCustSt.PerformAction(UltraGridAction.EnterEditMode);
                                return;
                            }
                        }
                        else
                        {
                            if (e.Key == Keys.Tab)
                            {
                                e.NextCtrl = null;
                                this.uGrid_SumCustSt.Rows[this.uGrid_SumCustSt.Rows.Count - 1].Cells[COLUMN_CUSTOMERCD].Activate();
                                this.uGrid_SumCustSt.PerformAction(UltraGridAction.EnterEditMode);
                                return;
                            }
                        }
                        break;
                    }
            }
        }
        #endregion ■ Control Events
    }
}