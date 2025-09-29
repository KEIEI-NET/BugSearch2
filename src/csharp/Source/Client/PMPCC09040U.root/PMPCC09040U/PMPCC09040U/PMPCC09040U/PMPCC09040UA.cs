//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : PCC品目設定
// プログラム概要   : PCC品目設定 フォームクラス
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 黄海霞
// 作 成 日  2011/07/20  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 徐飛
// 作 成 日  2013/02/17  修正内容 : 2013/03/13配信分 SCM障害№10276対応 
//                                  SCM_DBに登録する際、SF側の企業コード・拠点コードの取得元を得意先マスタに変更する       
// --------------------------------------------------------------------------//
// 管理番号              作成担当 : 30747 三戸 伸悟
// 作 成 日  2013/05/30  修正内容 : 2013/99/99配信 SCM障害№10541対応 
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Application.Common;
using Infragistics.Win.UltraWinTabControl;
using Infragistics.Win;
using System.Collections;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Infragistics.Win.UltraWinToolbars;
using Infragistics.Win.UltraWinGrid;
using System.Threading;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// PCC品目設定 フォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : PCC品目設定のフォームクラスです。</br>
    /// <br>Programmer : 黄海霞</br>
    /// <br>Date       : 2011.07.20</br>
    /// <br>Update Note: 2013/02/17 徐飛</br>
    /// <br>管理番号   : 2013/03/13配信分</br>
    /// <br>           : SCM障害№10276対応 SCM_DBに登録する際、SF側の企業コード・拠点コードの取得元を得意先マスタに変更する</br> 
    /// </remarks>
    public partial class PMPCC09040UA : Form, IMasterMaintenanceArrayType
    {
        #region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public PMPCC09040UA()
        {
            InitializeComponent();
            // プロパティ初期値設定
            this._canPrint = false;
            this._canNew = true;
            this._canDelete = true;
            this._canLogicalDeleteDataExtraction = true;
            this._canClose = true;		// デフォルト:true固定
            this._defaultAutoFillToColumn = true;
            this._canSpecificationSearch = false;
            // 変数初期化
            this._dataIndex = -1;
            this._detailsDataIndex = -1;
            this._totalCount = 0;
            this._detailTable = new Hashtable();
            this._pccItemGrpTable = new Hashtable();
            this._pccItemGrpAcs = new PccItemGrpAcs();
            _customerInfoAcs = new CustomerInfoAcs();
            // 企業コード
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            this._enterpriseName = LoginInfoAcquisition.EnterpriseName;
            //
            this._inqOtherEpCd = this._enterpriseCode;
            this._inqOtherSecCd = LoginInfoAcquisition.Employee.BelongSectionCode;

            //this._mainGridTitle = "PCC品目";//DEL by huanghx for #25173 各種マスタの名称変更対応 on 20110914
            this._mainGridTitle = "得意先";//ADD by huanghx for #25173 各種マスタの名称変更対応 on 20110914
            //this._detailsGridTitle = "PCCグループ";//DEL by huanghx for #25173 各種マスタの名称変更対応 on 20110914
            this._detailsGridTitle = "品目グループ";//ADD by huanghx for #25173 各種マスタの名称変更対応 on 20110914
            this._defaultGridDisplayLayout = MGridDisplayLayout.Vertical;
            this._targetTableName = "";
            this._mainGridIcon = null;
            this._detailsGridIcon = null;

            // データセット列情報構築処理
            DataSetColumnConstruction();
            GetCustomerHTable();
            //ツールバーアイコン設定
            this.SetToolIcon();
        }
        #endregion

        #region private 変数
        /// <summary>
        /// 企業コード
        /// </summary>
        private string _enterpriseCode = string.Empty;
        private string _enterpriseName = string.Empty;
        //問合せ元企業コード
        private string _inqOriginalEpCd = string.Empty;
        //問合せ元拠点コード
        private string _inqOriginalSecCd = string.Empty;
        //前問合せ元企業コード
        private string _inqOriginalEpCdPre = string.Empty;
        //前問合せ元拠点コード
        private string _inqOriginalSecCdPre = string.Empty;
        //問合せ先企業コード
        private string _inqOtherEpCd = string.Empty;
        //問合せ先拠点コード
        private string _inqOtherSecCd = string.Empty;
        private CustomerInfoAcs _customerInfoAcs;
        
        private PccItemGrid _pccItemGridClone = null;
        private Dictionary<int, PccItemGrp> _pccItemGrpDicClone = null;
        private Dictionary<int, Dictionary<int, PccItemSt>> _pccItemStDicDicClone = null;
        private int _prevCustomerCode = -1;
        private int _firstCustomerCode;
        /// <summary>画面起動完了フラグ</summary>
        private bool _isLoaded = false;
        // プロパティ用
        private bool _canPrint;
        private bool _canLogicalDeleteDataExtraction;
        private bool _canClose;
        private bool _canNew;
        private bool _canDelete;
        private bool _canSpecificationSearch;
        private int _dataIndex;
        private bool _defaultAutoFillToColumn;
        private PccItemGrpAcs _pccItemGrpAcs = null;
        private Hashtable _pccItemGrpTable;
        private Hashtable _detailTable = null;
        private int _totalCount;
        private int _indexBuf;
        private ButtonTool _closeButtonTool = null;
        private ButtonTool _saveButtonTool = null;
        private ButtonTool _newTabButtonTool = null;
        private ButtonTool _deleteTabButtonTool = null;
        private ButtonTool _clearButtonTool = null;
        private ButtonTool _allDeleteButtonTool = null;
        private ButtonTool _reviveButtonTool = null;
        private ButtonTool _reButtonNameButtonTool = null;
        private ButtonTool _quoteButtonTool = null;
        private int _startMode;                 //起動モード
        private PMPCC09040UC _pMPCC09040UC;
        //引用ガイド画面
        private PMPCC09040UD _pMPCC09040UD;
        /// <summary>
        /// PCC品目グループディクショナリー
        /// </summary>
        private Dictionary<string, List<PccItemGrp>> _pccItemGrpDict = null;
        /// <summary>
        /// PCC品目設定ディクショナリー
        /// </summary>
        Dictionary<string, Dictionary<int, List<PccItemSt>>> _pccItemStDictDict = null;
        private MGridDisplayLayout _defaultGridDisplayLayout;
        private string _targetTableName;
        private int _detailsDataIndex;
        private Image _mainGridIcon;
        private Image _detailsGridIcon;
        private string _mainGridTitle;
        private string _detailsGridTitle;
        // 得意先テープル
        private Dictionary<int, PccCmpnySt> _customerHTable;
        private PccCmpnyStAcs _pccCmpnyStAcs = null;
        //-----ADD by huanghx for #25387 BLパーツオーダー品目設定のチェックボックス制御 on 20110921 ----->>>>>
        //品目選択区分Hashtable
        private Hashtable _blCheckedInfoTb = null;
        //-----ADD by huanghx for #25387 BLパーツオーダー品目設定のチェックボックス制御 on 20110921 -----<<<<<
        #region //列挙型定義

        /// <summary>画面の起動モード</summary>
        /// <remarks>0:新規、1:修正</remarks>
        public enum StartMode
        {
            /// <summary>
            /// 新規
            /// </summary>
            MODE_NEW = 0,
            /// <summary>
            /// 編集
            /// </summary>
            MODE_EDIT = 1,
            /// <summary>
            /// 削除
            /// </summary>
            MODE_EDITLOGICDELETE = 2
        }

        /// <summary>
        /// 画面品目グループの数量
        /// </summary>
        private int _tabCount = 0;

        #endregion

        #endregion

        # region ■Consts
        // 編集モード
        private const string INSERT_MODE = "新規モード";
        private const string UPDATE_MODE = "更新モード";
        private const string DELETE_MODE = "削除モード";
        private const string ASSEMBLY_ID = "PMPCC09040U";
        private const string PCCITEM_TABLE = "PCCITEM";
        private const string PCCITEMDETIAL_TABLE = "PCCITEMDETIAL";
        private const string DELETE_DATE = "削除日";
        private const string S_DELETEDATE = "削除日";
        //問合せ元企業コード
        private const string INQORIGINALEPCD_TITLE = "問合せ元企業コード";
        //問合せ元拠点コード
        private const string INQORIGINALSECCD_TITLE = "問合せ元拠点コード";
        //問合せ先企業コード
        private const string INQOTHEREPCD_TITLE = "問合せ先企業コード";
        //問合せ先拠点コード
        private const string INQOTHERSECCD_TITLE = "問合せ先拠点コード";
        //PCC自社コード
        private const string PCCCOMPANYCODE_TITLE = "得意先コード";
        //得意先名
        private const string PCCCOMPANYNAME_TITLE = "得意先名";
        //品目グループコード
        private const string ITEMGROUPCODE_TITLE1 = "品目グループコード";
        //品目グループ名称
        private const string ITEMGROUPNAME_TITLE1 = "品目グループ名称";
        //品目グループ表示順位
        private const string ITEMGRPDSPODR_TITLE1 = "品目グループ表示順位";
        // --- ADD 2013/05/30 三戸 2013/99/99配信分 SCM障害№10541 --------->>>>>>>>>>>>>>>>>>>>>>>>
        //品目グループ画像コード
        private const string ITEMGRPIMGCODE_TITLE1 = "品目グループ画像コード";
        // --- ADD 2013/05/30 三戸 2013/99/99配信分 SCM障害№10541 ---------<<<<<<<<<<<<<<<<<<<<<<<<
        //問合せ条件
        private const string INQCONDITION_TITLE = "GUID";
        //問合せ条件
        private const string S_INQCONDITION_TITLE = "GUID";
        private const string INF_NOT_FOUND = "該当するデータがありません。";
        private const string ERR_READ_MSG = "読み込みに失敗しました。";
        private const string ERR_DPR_MSG = "このコードは既に使用されています。";
        private const string ERR_RDEL_MSG = "削除に失敗しました。";
        private const string ERR_UPDT_MSG = "登録に失敗しました。";
        private const string ERR_RVV_MSG = "復活に失敗しました。";
        private const string ERR_800_MSG = "既に他端末より更新されています";
        private const string ERR_801_MSG = "既に他端末より削除されています";
        private const string SDC_RDEL_MSG = "マスタから削除されています";
        private const string ERR_TIMEOUT_MSG = "削除中にタイムアウトが発生しました。\r\nしばらく時間を置いて再度更新してください。";
        private const int MAX_TABCOUNT = 5;
        private const int MAXROW = 8;
        private const int MAXALLROW = 64;
        private const int GRIDCOUNT = 8;
        private const string CUSTOMEMPTY_BASE = "ベース設定";
        //PCCオンライン種別区分
        private const int ONLINEKINDDIV = 10;
        private const string TODELKEY = "tab_toDelete";
        #endregion

        # region ※Main
        /// <summary>アプリケーションのメイン エントリ ポイントです。</summary>
        [STAThread]
        static void Main()
        {
            System.Windows.Forms.Application.Run(new PMPCC09040UA());
        }
        # endregion

        #region ■IMasterMaintenanceInputStart Members
        /// <summary>
        /// 
        /// </summary>
        /// <param name="paraTable"></param>
        /// <returns></returns>
        public DialogResult ShowDialog(Hashtable paraTable)
        {
            this.ShowDialog();
            return this.DialogResult;
        }
        #endregion

        # region ■IMasterMaintenanceArrayTypeメンバー

        # region ▼Events
        /// <summary>画面非表示イベント</summary>
        /// <remarks>画面が非表示状態になった際に発生します。</remarks>
        public event MasterMaintenanceArrayTypeUnDisplayingEventHandler UnDisplaying;
        # endregion

        # region ▼Properties
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

        /// <summary>論理削除データ抽出可能設定プロパティ</summary>
        /// <value>論理削除データの抽出が可能かどうかの設定を取得します。</value>
        public bool CanLogicalDeleteDataExtraction
        {
            get
            {
                return this._canLogicalDeleteDataExtraction;
            }
        }

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

        /// <summary>新規登録可能設定プロパティ</summary>
        /// <value>新規登録が可能かどうかの設定を取得します。</value>
        public bool CanNew
        {
            get
            {
                return this._canNew;
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
        # endregion

        # region ▼Public Methods
        /// <summary>
        /// バインドデータセット取得処理
        /// </summary>
        /// <param name="bindDataSet">グリッドリッド用データセット</param>
        /// <param name="tableName">テーブル名称</param>
        /// <remarks>
        /// <br>Note       : グリッドにバインドさせるデータセットを取得します。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        public void GetBindDataSet(ref System.Data.DataSet bindDataSet, ref string tableName)
        {
            bindDataSet = this.Bind_DataSet;
            tableName = PCCITEM_TABLE;
        }

        /// <summary>
        /// データ検索処理
        /// </summary>
        /// <param name="totalCount">全該当件数</param>
        /// <param name="readCount">抽出対象件数</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 先頭から指定件数分のデータを検索し、抽出結果を展開したDataSetと全該当件数を返します。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        public int Search(ref int totalCount, int readCount)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            List<PccItemGrid> pccItemGridList = null;
            PccItemGrid parsePccItemGrid = new PccItemGrid();
            parsePccItemGrid.EnterpriseCode = this._enterpriseCode;
            parsePccItemGrid.InqOtherEpCd = this._inqOtherEpCd;
            parsePccItemGrid.InqOtherSecCd = this._inqOtherSecCd;
            int index = 0;

            if (readCount == 0)
            {
                status = this._pccItemGrpAcs.Search(
                            out pccItemGridList,
                            out _pccItemGrpDict,
                            out _pccItemStDictDict,
                            parsePccItemGrid, 0, ConstantManagement.LogicalMode.GetData01);
            }
            
            switch (status)
            {
                  
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        this._totalCount = pccItemGridList.Count;
                        this.Bind_DataSet.Tables[PCCITEM_TABLE].Rows.Clear();
                        this._pccItemGrpTable.Clear();
                        foreach (PccItemGrid pccItemGridShow in pccItemGridList)
                        {
                            if (this._pccItemGrpTable.ContainsKey(pccItemGridShow.InqCondition) == false)
                            {
                                PccItemGridToDataSet(pccItemGridShow.Clone(), index);
                                ++index;
                            }
                        }
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    {
                        
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                         break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    {
                        
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT:
                    {
                        TMsgDisp.Show(
                            this,								  // 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOPDISP,	  // エラーレベル
                            ASSEMBLY_ID,						  // アセンブリＩＤまたはクラスＩＤ
                            this.Text,							  // プログラム名称
                            "Search",							  // 処理名称
                            TMsgDisp.OPE_GET,					  // オペレーション
                            ERR_TIMEOUT_MSG,						  // 表示するメッセージ 
                            status,								  // ステータス値
                            this._pccItemGrpAcs,					  // エラーが発生したオブジェクト
                            MessageBoxButtons.OK,				  // 表示するボタン
                            MessageBoxDefaultButton.Button1);	  // 初期表示ボタン
                        break;
                    }
                default:
                    {
                        TMsgDisp.Show(
                            this,								  // 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOPDISP,	  // エラーレベル
                            ASSEMBLY_ID,						  // アセンブリＩＤまたはクラスＩＤ
                            this.Text,							  // プログラム名称
                            "Search",							  // 処理名称
                            TMsgDisp.OPE_GET,					  // オペレーション
                            ERR_READ_MSG,						  // 表示するメッセージ 
                            status,								  // ステータス値
                            this._pccItemGrpAcs,					  // エラーが発生したオブジェクト
                            MessageBoxButtons.OK,				  // 表示するボタン
                            MessageBoxDefaultButton.Button1);	  // 初期表示ボタン

                        break;
                    }
            }
            totalCount = this._totalCount;
            return status;
        }

        /// <summary>
        /// ネクストデータ検索処理
        /// </summary>
        /// <param name="readCount">抽出対象件数</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 指定した件数分のネクストデータを検索します。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        public int SearchNext(int readCount)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            
            return status;
        }

        /// <summary>
        /// データ削除処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 選択中のデータを削除します。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        public int Delete()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            string inqCondition = (string)this.Bind_DataSet.Tables[PCCITEM_TABLE].Rows[this._dataIndex][INQCONDITION_TITLE];
            PccItemGrid pccItemGrid = ((PccItemGrid)this._pccItemGrpTable[inqCondition]).Clone();
            List<PccItemGrp> pccItemGrpList = null;
            Dictionary<int, List<PccItemSt>> pccItemStDict = null; 
            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }
            if (pccItemGrid != null && this._pccItemGrpDict != null 
                && this._pccItemGrpDict.ContainsKey(pccItemGrid.InqCondition))
            {
                pccItemGrpList = this._pccItemGrpDict[pccItemGrid.InqCondition];
            }

            if (pccItemGrid != null && this._pccItemStDictDict != null
                && this._pccItemStDictDict.ContainsKey(pccItemGrid.InqCondition))
            {
                pccItemStDict = this._pccItemStDictDict[pccItemGrid.InqCondition];
            }

            int dummy = 0;
            status = this._pccItemGrpAcs.LogicalDelete(ref pccItemGrid,ref pccItemGrpList, ref pccItemStDict);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        if (pccItemGrid != null && this._pccItemGrpDict != null
                            && this._pccItemGrpDict.ContainsKey(pccItemGrid.InqCondition))
                        {
                            this._pccItemGrpDict.Remove(pccItemGrid.InqCondition);
                            this._pccItemGrpDict.Add(pccItemGrid.InqCondition, pccItemGrpList);
                        }

                        if (pccItemGrid != null && this._pccItemStDictDict != null
                            && this._pccItemStDictDict.ContainsKey(pccItemGrid.InqCondition))
                        {
                            this._pccItemStDictDict.Remove(pccItemGrid.InqCondition);
                            this._pccItemStDictDict.Add(pccItemGrid.InqCondition, pccItemStDict);
                        }
                        // クラスデータセット展開処理
                        PccItemGridToDataSet(pccItemGrid.Clone(), this._dataIndex);
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        // 排他処理
                        ExclusiveTransaction(status, TMsgDisp.OPE_DELETE, this._pccItemGrpAcs);
                        // クラスデータセット展開処理
                        this._pccItemGrpTable.Clear();
                        this.Search(ref dummy, 0);
                        return status;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT:
                    {
                        TMsgDisp.Show(
                            this,								  // 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOPDISP,	  // エラーレベル
                            ASSEMBLY_ID,						  // アセンブリＩＤまたはクラスＩＤ
                            this.Text,							  // プログラム名称
                            "Delete",							  // 処理名称
                            TMsgDisp.OPE_GET,					  // オペレーション
                            ERR_TIMEOUT_MSG,						  // 表示するメッセージ 
                            status,								  // ステータス値
                            this._pccItemGrpAcs,					  // エラーが発生したオブジェクト
                            MessageBoxButtons.OK,				  // 表示するボタン
                            MessageBoxDefaultButton.Button1);	  // 初期表示ボタン
                        break;
                    }
                default:
                    {
                        TMsgDisp.Show(
                            this,								// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOPDISP,	// エラーレベル
                            ASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
                            this.Text,							// プログラム名称
                            "Delete",							// 処理名称
                            TMsgDisp.OPE_HIDE,					// オペレーション
                            ERR_RDEL_MSG,						// 表示するメッセージ 
                            status,								// ステータス値
                            this._pccItemGrpAcs,					// エラーが発生したオブジェクト
                            MessageBoxButtons.OK,				// 表示するボタン
                            MessageBoxDefaultButton.Button1);	// 初期表示ボタン
                        // クラスデータセット展開処理
                        this._pccItemGrpTable.Clear();
                        this.Search(ref dummy, 0);
                        return status;
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
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        public int Print()
        {
            // 印刷用アセンブリをロードする（未実装）
            return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        }

        /// <summary>グリッドのデフォルト表示位置プロパティ</summary>
        /// <value>グリッドのデフォルト表示位置を取得します。</value>
        public MGridDisplayLayout DefaultGridDisplayLayout
        {
            get { return this._defaultGridDisplayLayout; }
        }

        /// <summary>
        /// 明細データ検索処理
        /// </summary>
        /// <param name="totalCount">全該当件数</param>
        /// <param name="readCount">抽出対象件数</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 先頭から指定件数分のデータを検索し、抽出結果を展開したDataSetと全該当件数を返します。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        public int DetailsDataSearch(ref int totalCount, int readCount)
        {
            int status = 0;
            ArrayList arrModelNameU = new ArrayList();

            // 現在保持している品目設定データをクリアする
            this.Bind_DataSet.Tables[PCCITEMDETIAL_TABLE].Rows.Clear();
            this._detailTable.Clear();

            if (readCount < 0) return 0;

            // 選択されているメーカーデータを取得する
            string guid = (string)this.Bind_DataSet.Tables[PCCITEM_TABLE].Rows[this._dataIndex][INQCONDITION_TITLE];
            PccItemGrid pccItemGrid = (PccItemGrid)this._pccItemGrpTable[guid];
            List<PccItemGrp> pccItemGrpList = this._pccItemGrpDict[pccItemGrid.InqCondition];

            this._totalCount = 0;
            if (pccItemGrpList != null && pccItemGrpList.Count > 0)
            {
                int index = 0;
                this._totalCount = pccItemGrpList.Count;
                foreach (PccItemGrp wkPccItemGrp in pccItemGrpList)
                {
                    // 品目設定クラスデータセット展開処理
                    PccItemGrpToDataSet(wkPccItemGrp.Clone(), index);
                    ++index;
                }
            }
            else
            {
                // 明細データ検索処理
                TMsgDisp.Show(
                            this,								  // 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOPDISP,	  // エラーレベル
                            ASSEMBLY_ID,						  // アセンブリＩＤまたはクラスＩＤ
                            this.Text,							  // プログラム名称
                            "DetailsDataSearch",							  // 処理名称
                            TMsgDisp.OPE_GET,					  // オペレーション
                            "PCC品目設定マスタ情報の読み込みに失敗しました。",						  // 表示するメッセージ 
                            status,								  // ステータス値
                            this._pccItemGrpAcs,					  // エラーが発生したオブジェクト
                            MessageBoxButtons.OK,				  // 表示するボタン
                            MessageBoxDefaultButton.Button1);	  // 初期表示ボタン

            }


            totalCount = this._totalCount;

            return status;
        }

        /// <summary>
        /// 明細ネクストデータ検索処理
        /// </summary>
        /// <param name="readCount">抽出対象件数</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 指定した件数分のネクストデータを検索します。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        public int DetailsDataSearchNext(int readCount)
        {
            return 9;
        }

        /// <summary>
        /// グリッド列外観情報取得処理
        /// </summary>
        /// <param name="appearanceTable">グリッド外観</param>
        /// <returns>グリッド列外観情報格納Hashtable</returns>
        /// <remarks>
        /// <br>Note       : 各列の外見を設定するクラスを格納したHashtableを取得します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.12</br>
        /// </remarks>
        public void GetAppearanceTable(out Hashtable[] appearanceTable)
        {
            // メイングリッド
            Hashtable mainAppearanceTable = new Hashtable();

            // 削除日
            //削除日
            mainAppearanceTable.Add(DELETE_DATE, new GridColAppearance(MGridColDispType.DeletionDataBoth, ContentAlignment.MiddleLeft, "", Color.Red));

            //問合せ元企業コード
            mainAppearanceTable.Add(INQORIGINALEPCD_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));

            //問合せ元拠点コード
            mainAppearanceTable.Add(INQORIGINALSECCD_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));

            //問合せ先企業コード
            mainAppearanceTable.Add(INQOTHEREPCD_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));

            //問合せ先拠点コード
            mainAppearanceTable.Add(INQOTHERSECCD_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
            //PCC自社コード
            mainAppearanceTable.Add(PCCCOMPANYCODE_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            //得意先名
            mainAppearanceTable.Add(PCCCOMPANYNAME_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //PCC自社コード
            mainAppearanceTable.Add(INQCONDITION_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));

            // サブグリッド
            Hashtable detailsAppearanceTable = new Hashtable();

            // 削除日
            detailsAppearanceTable.Add(S_DELETEDATE, new GridColAppearance(MGridColDispType.DeletionDataBoth, ContentAlignment.MiddleLeft, "", Color.Red));
            //品目グループコード1
            detailsAppearanceTable.Add(ITEMGROUPCODE_TITLE1, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //品目グループ名称1
            detailsAppearanceTable.Add(ITEMGROUPNAME_TITLE1, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //品目グループ表示順位1
            detailsAppearanceTable.Add(ITEMGRPDSPODR_TITLE1, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //品目グループ表示順位1
            detailsAppearanceTable.Add(S_INQCONDITION_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
            // --- ADD 2013/05/30 三戸 2013/99/99配信分 SCM障害№10541 --------->>>>>>>>>>>>>>>>>>>>>>>>
            //品目グループ画像コード
            detailsAppearanceTable.Add(ITEMGRPIMGCODE_TITLE1, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // --- ADD 2013/05/30 三戸 2013/99/99配信分 SCM障害№10541 ---------<<<<<<<<<<<<<<<<<<<<<<<<

            appearanceTable = new Hashtable[2];
            appearanceTable[0] = mainAppearanceTable;
            appearanceTable[1] = detailsAppearanceTable;
        }

        /// <summary>
        /// バインドデータセット取得処理
        /// </summary>
        /// <param name="bindDataSet">グリッド表示用データセット</param>
        /// <param name="tableName">テーブル名称</param>
        /// <remarks>
        /// <br>Note       : グリッドにバインドさせるデータセットを取得します。</br>
        /// <br></br>
        /// </remarks>
        /// 
        public void GetBindDataSet(ref DataSet bindDataSet, ref string[] tableName)
        {
            // グリッド表示用データセットを設定
            bindDataSet = this.Bind_DataSet;

            // ２つのテーブル名称の設定
            string[] strRet = new string[2];
            strRet[0] = PCCITEM_TABLE;
            strRet[1] = PCCITEMDETIAL_TABLE;
            tableName = strRet;
        }

        /// <summary>
        /// 論理削除データ抽出可能設定リスト取得処理
        /// </summary>
        /// <returns>論理削除データ抽出可能設定リスト</returns>
        /// <remarks>
        /// <br>Note       : 論理削除データの抽出が可能かどうかの設定を配列で取得します。</br>
        /// <br></br>
        /// </remarks>
        public bool[] GetCanLogicalDeleteDataExtractionList()
        {
            bool[] blRet = new bool[2];
            blRet[0] = true;
            blRet[1] = false;
            return blRet;
        }

        /// <summary>
        /// グリッド列のサイズの自動調整のデフォルト値リスト取得処理
        /// </summary>
        /// <returns>グリッド列のサイズの自動調整のデフォルト値リスト</returns>
        /// <remarks>
        /// <br>Note       : グリッド列のサイズの自動調整チェックボックスのチェック有無のデフォルト値を配列で取得します。</br>
        /// <br></br>
        /// </remarks>
        public bool[] GetDefaultAutoFillToGridColumnList()
        {
            bool[] blRet = new bool[2];
            blRet[0] = true;
            blRet[1] = true;
            return blRet;
        }

        /// <summary>
        /// 削除ボタンの有効設定リスト取得処理
        /// </summary>
        /// <returns>削除ボタンの有効設定リスト</returns>
        /// <remarks>
        /// <br>Note       : 削除ボタンの有効設定リストを取得します。</br>
        /// <br></br>
        /// </remarks>
        public bool[] GetDeleteButtonEnabledList()
        {
            bool[] blRet = new bool[2];
            blRet[0] = true;
            blRet[1] = false;
            return blRet;
        }

        /// <summary>
        /// グリッドアイコンリスト取得処理
        /// </summary>
        /// <returns>グリッドアイコンリスト</returns>
        /// <remarks>
        /// <br>Note       : グリッドのアイコンを配列で取得します。</br>
        /// <br></br>
        /// </remarks>
        public Image[] GetGridIconList()
        {
            Image[] objRet = new Image[2];
            objRet[0] = this._mainGridIcon;
            objRet[1] = this._detailsGridIcon;
            return objRet;
        }

        /// <summary>
        /// グリッドタイトルリスト取得処理
        /// </summary>
        /// <returns>グリッドタイトルリスト</returns>
        /// <remarks>
        /// <br>Note       : グリッドのタイトルを配列で取得します。</br>
        /// <br></br>
        /// </remarks>
        public string[] GetGridTitleList()
        {
            string[] strRet = new string[2];
            strRet[0] = this._mainGridTitle;
            strRet[1] = this._detailsGridTitle;
            return strRet;
        }

        /// <summary>
        /// 修正ボタンの有効設定リスト取得処理
        /// </summary>
        /// <returns>修正ボタンの有効設定リスト</returns>
        /// <remarks>
        /// <br>Note       : 修正ボタンの有効設定リストを取得します。</br>
        /// <br></br>
        /// </remarks>
        public bool[] GetModifyButtonEnabledList()
        {
            bool[] blRet = new bool[2];
            blRet[0] = true;
            blRet[1] = false;
            return blRet;
        }

        /// <summary>
        /// 新規ボタンの有効設定リスト取得処理
        /// </summary>
        /// <returns>新規ボタンの有効設定リスト</returns>
        /// <remarks>
        /// <br>Note       : 新規ボタンの有効設定リストを取得します。</br>
        /// <br></br>
        /// </remarks>
        public bool[] GetNewButtonEnabledList()
        {
            bool[] blRet = new bool[2];
            blRet[0] = true;
            blRet[1] = false;
            return blRet;
        }

        /// <summary>
        /// データテーブルの選択データインデックスリスト設定処理
        /// </summary>
        /// <param name="indexList">データテーブルの選択データインデックスリスト</param>
        /// <remarks>
        /// <br>Note       : データテーブルの選択データインデックスリストを設定します。</br>
        /// <br></br>
        /// </remarks>
        public void SetDataIndexList(int[] indexList)
        {
            int[] intVal = indexList;
            this._dataIndex = intVal[0];
            this._detailsDataIndex = intVal[1];
        }

        /// <summary>操作対象データテーブル名称プロパティ</summary>
        /// <value>捜査対象データのテーブル名称を取得または設定します。</value>
        public string TargetTableName
        {
            get { return this._targetTableName; }
            set { this._targetTableName = value; }
        }   

        # endregion

        # endregion

        #region イベント
        /// <summary>Form.Load イベント</summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : フォーム読み込み時の設定を取得します。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        private void PMPCC09040UA_Load(object sender, EventArgs e)
        {
            // 起動完了フラグ
            this._isLoaded = false;
            // 起動モードで画面データ表示処理
            this.InitializeDisply();
            this._blCheckedInfoTb = new Hashtable();
            // 起動完了フラグ
            this._isLoaded = true;
            Initial_Timer.Enabled = true;
            // IPCサーバーの生成・イベント登録
           
        }

        /// <summary>
        /// Form.Closing イベント(PMPCC09040UA)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">キャンセルできるイベントのデータを提供するクラス</param>
        /// <remarks>
        /// <br>Note　　　  : フォームを閉じる前に、ユーザーがフォームを閉じようとしたときに発生します。</br>
        /// <br>Programmer  : 黄海霞</br>
        /// <br>Date        : 2011.07.20</br>
        /// </remarks>
        private void PMPCC09040UA_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this._indexBuf = -2;

            // フォームの「×」をクリックされた場合の対応です。
            if (CanClose == false)
            {
                ClearProc();
                e.Cancel = true;
                this.Hide();
                return;
            }
        }

        /// <summary>
        /// Control.VisibleChanged イベント(PMPCC09040UA)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　  : フォームの表示状態が変わったときに発生します。</br>
        /// <br>Programmer  : 黄海霞</br>
        /// <br>Date        : 2011.07.20</br>
        /// </remarks>
        private void PMPCC09040UA_VisibleChanged(object sender, System.EventArgs e)
        {
            // 自分自身が非表示になった場合は以下の処理をキャンセルする。
            if (this.Visible == false)
            {
                this.Owner.Activate();
                return;
            }

            // 自分自身が非表示になった場合、
            // またはターゲットレコード(Index)が変わっていない場合は以下の処理をキャンセルする
            if (this._indexBuf == this._dataIndex)
            {
                return;
            }

            Initial_Timer.Enabled = true;
        }

        /// <summary>
        /// Timer.Tick イベント イベント(Initial_Timer)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　  : 指定された間隔の時間が経過したときに発生します。
        ///					  この処理は、システムが提供するスレッド プール
        ///					  スレッドで実行されます。</br>
        /// <br>Programmer  : 黄海霞</br>
        /// <br>Date        : 2011.07.20</br>
        /// </remarks>
        private void Initial_Timer_Tick(object sender, System.EventArgs e)
        {
            Initial_Timer.Enabled = false;
            // 画面再構築処理
            ScreenReconstruction();
        }

        #region MainToolbarsManager
        /// <summary>メインツールバーマネージャーToolClick</summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// Note       : メインツールバーマネージャーのToolClick処理です。<br />
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        private void MainToolbarsManager_ToolClick(object sender, ToolClickEventArgs e)
        {
             //アクティブ状態になっているツールのフォーカスをクリアする
            e.Tool.IsActiveTool = false;
            switch (e.Tool.Key)
            {
                // 閉じるボタン
                case "ButtonTool_Close":
                    {
                        this.CloseForm();
                        break;
                    }
                //保存ボタン
                case "ButtonTool_Save":
                    {
                        this.SaveProc();
                        break;
                    }
                //新規TABボタン
                case "ButtonTool_NewTab":
                    {
                        this.NewTabProc();
                        break;
                    }
                //削除TABボタン
                case "ButtonTool_DeleteTab":
                    {
                        UltraTab selectedTab = UTabControl_StayInfo.SelectedTab;
                        this.DeleteTabProc(selectedTab);
                        break;
                    }
                //クリアボタン
                case "ButtonTool_Clear":
                    {
                        this._dataIndex = -1;
            
                        this.ClearProc();
                        _pccItemStDicDicClone = new Dictionary<int, Dictionary<int, PccItemSt>>();
                        _pccItemGrpDicClone = new Dictionary<int, PccItemGrp>();
                        this._pccItemGridClone = new PccItemGrid();
                        GetListFromTabs(ref _pccItemStDicDicClone, out _pccItemGrpDicClone, ref  this._pccItemGridClone);
                        break;
                    }
                //完全削除ボタン
                case "ButtonTool_AllDelete":
                    {
                        this.AllDeleteProc();
                        break;
                    }
                //復活ボタン
                case "ButtonTool_Revive":
                    {
                        this.ReviveProc();
                        break;
                    }
                //TAB名変更ボタン
                case "ButtonTool_ReButtonName":
                    {
                        this.ReButtonProc(1);
                        break;
                    }
                //引用ボタン
                    case "ButtonTool_Quote":
                    {
                        this.QuoteButtonProc();
                        break;
                    }
            }
        }
        #endregion

        /// <summary>
        /// 得意先ガイドボタンクリックイベント（オーバーロード）
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : 得意先ガイドボタンクリックイベントを行います。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        private void UButton_CustomerGuide_Click(object sender, EventArgs e)
        {
            // 得意先ガイド表示
            PMKHN04005UA customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_CUSTOMER_ONLY, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY, PMKHN04005UA.PCCUOE_MASTER_ONLY);
            customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.CustomerSearchForm_CustomerSelect);
           
            DialogResult result = customerSearchForm.ShowDialog(this);
        }

        #region 得意先選択ガイドボタンクリック時イベント

        /// <summary>
        /// 得意先選択ガイドボタンクリック時発生イベント
        /// </summary>
        /// <param name="sender">PMKHN4002Eフォームオブジェクト</param>
        /// <param name="customerSearchRet">得意先情報戻り値クラス(PMKHN4002E)</param>
        /// <remarks>
        /// <br>Note       : 得意先選択ガイドボタンクリック時発生イベントを行います。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        private void CustomerSearchForm_CustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        {
            // イベントハンドラを渡した相手から戻り値クラスを受け取れなければ終了
            if (customerSearchRet == null) return;

            // DBデータを読み出す(キャッシュを使用)
            CustomerInfo customerInfo;
            int status = this._customerInfoAcs.ReadStaticMemoryData(out customerInfo, customerSearchRet.EnterpriseCode, customerSearchRet.CustomerCode);

            // ステータスによりエラーメッセージを出力
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (customerInfo == null)
                {
                    TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Name,
                        "選択した得意先は得意先情報入力が行われていない為、使用出来ません。",
                        status, MessageBoxButtons.OK);
                    return;
                }
                else
                {
                     //オンライン種別区分 0:なし 10:SCM、20:TSP.NS、30:TSP.NSインライン、40:TSPメール
                    if (customerInfo.OnlineKindDiv == ONLINEKINDDIV)
                    {
                        //前問合せ元企業コード
                        this._inqOriginalEpCdPre = this._inqOriginalEpCd.Trim();//@@@@20230303
                        //前問合せ元拠点コード
                        this._inqOriginalSecCdPre = this._inqOriginalSecCd;
                        //問合せ元企業コード
                        this._inqOriginalEpCd = customerInfo.CustomerEpCode.Trim();//@@@@20230303
                        //問合せ元拠点コード
                        this._inqOriginalSecCd = customerInfo.CustomerSecCode;

                        string pccInqCondition = this._inqOriginalEpCd.Trim() + this._inqOriginalSecCd.TrimEnd() + this._inqOtherEpCd.TrimEnd() + this._inqOtherSecCd.TrimEnd();//@@@@20230303
                        PccCmpnySt pccCmpnySt;
                        if (_customerHTable != null && _customerHTable.Count > 0 && _customerHTable.ContainsKey(customerInfo.CustomerCode))
                        {
                            pccCmpnySt = _customerHTable[customerInfo.CustomerCode];
                            if (ModeChangeProc(pccInqCondition, pccCmpnySt))
                            {
                                return;
                            }
                            else
                            {
                                //得意先情報をUIに設定
                                tNedit_CustomerCode.SetInt(customerInfo.CustomerCode);
                                uLabel_CustomerName.Text = customerInfo.CustomerSnm.TrimEnd();
                                _prevCustomerCode = customerInfo.CustomerCode;
                                //問合せ元企業コード
                                this._inqOriginalEpCdPre = this._inqOriginalEpCd.Trim();//@@@@20230303
                                //問合せ元拠点コード
                                this._inqOriginalSecCdPre = this._inqOriginalSecCd;
                                //画面入力許可制御処理
                                ScreenInputPermissionControl((int)StartMode.MODE_EDIT);
                                UTabControl_StayInfo.Tabs[0].Selected = true;
                                PMPCC09040UB pMPCC09040UB = (PMPCC09040UB)UTabControl_StayInfo.Tabs[0].Tag;
                                pMPCC09040UB.SetInitFocus(this._startMode);
                                this._inqOriginalEpCd = customerInfo.CustomerEpCode.Trim();//@@@@20230303
                                this._inqOriginalSecCd = customerInfo.CustomerSecCode.TrimEnd();
                                return;
                            }
                        }
                    }
                    else
                    {
                        // エラー時
                        TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_INFO,
                            this.Name,
                            "得意先コード [" + customerSearchRet.CustomerCode + "]は設定できません。\r\nオンライン情報を確認して下さい。",
                            -1,
                            MessageBoxButtons.OK);
                    }
                    return;
                }
            }
            else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Name,
                    "選択した得意先は既に削除されています。",
                    status, MessageBoxButtons.OK);
                return;
            }
            else
            {
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_STOPDISP, this.Name,
                    "得意先情報の取得に失敗しました。",
                    status, MessageBoxButtons.OK);
                return;
            }
        }
        #endregion

        /// <summary>
        /// フォーカスコントロールイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 得意先ガイドボタンクリックイベントを行います。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.07.20</br>
        /// <br>Update Note: 2013/02/17 徐飛</br>
        /// <br>管理番号   : 2013/03/13配信分</br>
        /// <br>           : 得意先入力した後、得意先情報再検索処理を追加する</br> 
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null) return;
            // PrevCtrl設定
            Control prevCtrl = new Control();
            if (e.PrevCtrl is Control)
            {
                prevCtrl = (Control)e.PrevCtrl;
            }
            int gridNo = 0;
            // 名前により分岐
            switch (prevCtrl.Name)
            {
                #region 得意先コード
                // 得意先コード
                case "tNedit_CustomerCode":
                    {
                        int inputValue = tNedit_CustomerCode.GetInt();
                        string pccInqCondition = string.Empty;
                        if (e.NextCtrl.Name == "MainToolbarsManager")
                        {
                            // 遷移先が閉じるボタン

                        }
                        else
                        {

                            if (_prevCustomerCode != inputValue)
                            {
                                PccCmpnySt pccCmpnySt;
                                if (_customerHTable == null || !_customerHTable.ContainsKey(inputValue))
                                {
                                    this.GetCustomerHTable();
                                }
                                if (_customerHTable != null && _customerHTable.Count > 0 && _customerHTable.ContainsKey(inputValue))
                                {
                                    pccCmpnySt = _customerHTable[inputValue];
                                    // ----ADD 2013/02/17 徐飛--------->>>>>
                                    CustomerInfo customerInfo;
                                    int status = this._customerInfoAcs.ReadStaticMemoryData(out customerInfo, _enterpriseCode, inputValue);
                                    if ((status != (int)ConstantManagement.DB_Status.ctDB_NORMAL || customerInfo == null) && inputValue != 0)
                                    {
                                        // エラー時
                                        TMsgDisp.Show(this,
                                            emErrorLevel.ERR_LEVEL_INFO,
                                            this.Name,
                                             "得意先マスタに未登録の為、この得意先は設定できません。\r\n [" + inputValue + "] ",
                                            -1,
                                            MessageBoxButtons.OK);
                                        if (_prevCustomerCode == -1)
                                        {
                                            this.tNedit_CustomerCode.SetInt(0);
                                        }
                                        else
                                        {
                                            this.tNedit_CustomerCode.SetInt(_prevCustomerCode);
                                        }
                                        e.NextCtrl = e.PrevCtrl;
                                        if (_prevCustomerCode == 0)
                                        {
                                            ScreenInputPermissionControl((int)StartMode.MODE_NEW);
                                        }
                                        else
                                        {
                                            ScreenInputPermissionControl((int)StartMode.MODE_EDIT);
                                        }
                                        return;
                                    }
                                    // ----ADD 2013/02/17 徐飛---------<<<<<
                                    //前問合せ元企業コード
                                    this._inqOriginalEpCdPre = this._inqOriginalEpCd.Trim();//@@@@20230303
                                    //前問合せ元拠点コード
                                    this._inqOriginalSecCdPre = this._inqOriginalSecCd;
                                    // ----DEL 2013/02/17 徐飛--------->>>>>
                                    ////問合せ元企業コード
                                    //this._inqOriginalEpCd = pccCmpnySt.InqOriginalEpCd;
                                    ////問合せ元拠点コード
                                    //this._inqOriginalSecCd = pccCmpnySt.InqOriginalSecCd;
                                    // ----DEL 2013/02/17 徐飛---------<<<<<

                                    // ----ADD 2013/02/17 徐飛--------->>>>>
                                    if (customerInfo != null)
                                    {
                                        //問合せ元企業コード
                                        this._inqOriginalEpCd = customerInfo.CustomerEpCode.Trim();//@@@@20230303
                                        //問合せ元拠点コード
                                        this._inqOriginalSecCd = customerInfo.CustomerSecCode.TrimEnd();
                                    }
                                    else
                                    {
                                        //問合せ元企業コード
                                        this._inqOriginalEpCd = pccCmpnySt.InqOriginalEpCd.Trim();//@@@@20230303
                                        //問合せ元拠点コード
                                        this._inqOriginalSecCd = pccCmpnySt.InqOriginalSecCd;
                                    }
                                    // ----ADD 2013/02/17 徐飛---------<<<<<
                                    pccInqCondition = this._inqOriginalEpCd.Trim() + this._inqOriginalSecCd.TrimEnd() //@@@@20230303
                                        + this._inqOtherEpCd.TrimEnd() + this._inqOtherSecCd.TrimEnd();
                                    if (ModeChangeProc(pccInqCondition, pccCmpnySt))
                                    {
                                        return;
                                    }
                                    this.uLabel_CustomerName.Text = pccCmpnySt.PccCompanyName.TrimEnd();
                                    _prevCustomerCode = inputValue;
                                    //問合せ元企業コード
                                    this._inqOriginalEpCdPre = this._inqOriginalEpCd.Trim();//@@@@20230303
                                    //問合せ元拠点コード
                                    this._inqOriginalSecCdPre = this._inqOriginalSecCd;
                                    ScreenInputPermissionControl((int)StartMode.MODE_EDIT);
                                    UTabControl_StayInfo.Tabs[0].Selected = true;
                                    PMPCC09040UB pMPCC09040UB = (PMPCC09040UB)UTabControl_StayInfo.Tabs[0].Tag;
                                    pMPCC09040UB.SetInitFocus(this._startMode);

                                }
                                else
                                {
                                    // エラー時
                                    TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_INFO,
                                        this.Name,
                                        //"PCC自社設定マスタに未登録の為、この得意先は設定できません。\r\n [" + inputValue + "] ",  //DEL BY wujun FOR Redmine#25173 ON 2011.09.15
                                         "BLﾊﾟｰﾂｵｰﾀﾞｰ自社設定マスタに未登録の為、この得意先は設定できません。\r\n [" + inputValue + "] ",  //ADD BY wujun FOR Redmine#25173 ON 2011.09.15　
                                        -1,
                                        MessageBoxButtons.OK);
                                    if (_prevCustomerCode == -1)
                                    {
                                        this.tNedit_CustomerCode.SetInt(0);
                                    }
                                    else
                                    {
                                        this.tNedit_CustomerCode.SetInt(_prevCustomerCode);
                                    }
                                    e.NextCtrl = e.PrevCtrl;
                                    if (_prevCustomerCode == 0)
                                    {
                                        ScreenInputPermissionControl((int)StartMode.MODE_NEW);
                                    }
                                    else
                                    {
                                        ScreenInputPermissionControl((int)StartMode.MODE_EDIT);
                                    }
                                    return;
                                }
                            }
                        }
                        
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Return:
                                case Keys.Tab:
                                    {
                                        e.NextCtrl = this.UButton_CustomerGuide;
                                        break;
                                    }
                            }

                        }

                        break;
                    }
                #endregion

                case "PMPCC09040UB":
                    {
                        PMPCC09040UB pMPCC09040UB = (PMPCC09040UB)UTabControl_StayInfo.SelectedTab.Tag;
                        pMPCC09040UB.SetInitFocus(this._startMode);
                        //-----ADD by huanghx for #25387 BLパーツオーダー品目設定のチェックボックス制御 on 20110921 ----->>>>>
                        foreach (UltraTab eachTab in this.UTabControl_StayInfo.Tabs)
                        {
                            PMPCC09040UB pMPCC09040UEach = (PMPCC09040UB)eachTab.Tag;
                            if (this.UTabControl_StayInfo.SelectedTab.Key.Equals(eachTab.Key))
                            {
                                continue;
                            }
                            pMPCC09040UEach.SetBlChecked();
                        }
                        //-----ADD by huanghx for #25387 BLパーツオーダー品目設定のチェックボックス制御 on 20110921 -----<<<<<
                        break;
                    }
                // PCC品目設定グリッド1
                case "PccItemSt_UltraGrid1":
                    {
                        gridNo = 0;
                        UltraGrid ultraGrid = (UltraGrid)e.PrevCtrl;
                        PMPCC09040UB pMPCC09040UB = (PMPCC09040UB)UTabControl_StayInfo.SelectedTab.Tag;
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                pMPCC09040UB.ReturnKeyDown(ref e, 0, ref ultraGrid, gridNo);
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                pMPCC09040UB.ShiftKeyDown(ref e, 0, ref ultraGrid, gridNo);
                            }
                        }

                        break;
                    }
                // PCC品目設定グリッド2
                case "PccItemSt_UltraGrid2":
                    {
                        gridNo = 1;
                        UltraGrid ultraGrid = (UltraGrid)e.PrevCtrl;
                        PMPCC09040UB pMPCC09040UB = (PMPCC09040UB)UTabControl_StayInfo.SelectedTab.Tag;
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                pMPCC09040UB.ReturnKeyDown(ref e, 0, ref ultraGrid, gridNo);
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                pMPCC09040UB.ShiftKeyDown(ref e, 0, ref ultraGrid, gridNo);
                            }
                        }

                        break;
                    }
                // PCC品目設定グリッド3
                case "PccItemSt_UltraGrid3":
                    {
                        gridNo = 2;
                        UltraGrid ultraGrid = (UltraGrid)e.PrevCtrl;
                        PMPCC09040UB pMPCC09040UB = (PMPCC09040UB)UTabControl_StayInfo.SelectedTab.Tag;
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                pMPCC09040UB.ReturnKeyDown(ref e, 0, ref ultraGrid, gridNo);
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                pMPCC09040UB.ShiftKeyDown(ref e, 0, ref ultraGrid, gridNo);
                            }
                        }

                        break;
                    }
                // PCC品目設定グリッド4
                case "PccItemSt_UltraGrid4":
                    {
                        gridNo = 3;
                        UltraGrid ultraGrid = (UltraGrid)e.PrevCtrl;
                        PMPCC09040UB pMPCC09040UB = (PMPCC09040UB)UTabControl_StayInfo.SelectedTab.Tag;
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                pMPCC09040UB.ReturnKeyDown(ref e, 0, ref ultraGrid, gridNo);
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                pMPCC09040UB.ShiftKeyDown(ref e, 0, ref ultraGrid, gridNo);
                            }
                        }

                        break;
                    }
                case "PccItemSt_UltraGrid5":
                    {
                        gridNo = 4;
                        UltraGrid ultraGrid = (UltraGrid)e.PrevCtrl;
                        PMPCC09040UB pMPCC09040UB = (PMPCC09040UB)UTabControl_StayInfo.SelectedTab.Tag;
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                pMPCC09040UB.ReturnKeyDown(ref e, 0, ref ultraGrid, gridNo);
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                pMPCC09040UB.ShiftKeyDown(ref e, 0, ref ultraGrid, gridNo);
                            }
                        }

                        break;
                    }
                case "PccItemSt_UltraGrid6":
                    {
                        gridNo = 5;
                        UltraGrid ultraGrid = (UltraGrid)e.PrevCtrl;
                        PMPCC09040UB pMPCC09040UB = (PMPCC09040UB)UTabControl_StayInfo.SelectedTab.Tag;
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                pMPCC09040UB.ReturnKeyDown(ref e, 0, ref ultraGrid, gridNo);
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                pMPCC09040UB.ShiftKeyDown(ref e, 0, ref ultraGrid, gridNo);
                            }
                        }

                        break;
                    }
                case "PccItemSt_UltraGrid7":
                    {
                        gridNo = 6;
                        UltraGrid ultraGrid = (UltraGrid)e.PrevCtrl;
                        PMPCC09040UB pMPCC09040UB = (PMPCC09040UB)UTabControl_StayInfo.SelectedTab.Tag;
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                pMPCC09040UB.ReturnKeyDown(ref e, 0, ref ultraGrid, gridNo);
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                pMPCC09040UB.ShiftKeyDown(ref e, 0, ref ultraGrid, gridNo);
                            }
                        }

                        break;
                    }
                case "PccItemSt_UltraGrid8":
                    {
                        gridNo = 7;
                        UltraGrid ultraGrid = (UltraGrid)e.PrevCtrl;
                        PMPCC09040UB pMPCC09040UB = (PMPCC09040UB)UTabControl_StayInfo.SelectedTab.Tag;
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                pMPCC09040UB.ReturnKeyDown(ref e, 0, ref ultraGrid, gridNo);
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                pMPCC09040UB.ShiftKeyDown(ref e, 0, ref ultraGrid, gridNo);
                            }
                        }

                        break;
                    }
            }
        }

        //-----DEL by huanghx for #25387 BLパーツオーダー品目設定のチェックボックス制御 on 20110921 ----->>>>>
        ///// <summary>
        ///// Tab変更イベント
        ///// </summary>
        ///// <param name="sender">対象オブジェクト</param>
        ///// <param name="e">イベントパラメータ</param>
        ///// <remarks>
        ///// <br>Note       : Tab変更イベントを行います。</br>
        ///// <br>Programmer : 黄海霞</br>
        ///// <br>Date       : 2011.07.20</br>
        ///// </remarks>
        //private void UTabControl_StayInfo_SelectedTabChanged(object sender, SelectedTabChangedEventArgs e)
        //{
        //    if (UTabControl_StayInfo.SelectedTab != null)
        //    {
        //        PMPCC09040UB pMPCC09040UB = (PMPCC09040UB)UTabControl_StayInfo.SelectedTab.Tag;
        //        if (pMPCC09040UB != null)
        //        {
        //            pMPCC09040UB.InitBlCheckedTb(ref _blCheckedInfoTb);
        //        }
        //    }
        //}
        //-----DEL by huanghx for #25387 BLパーツオーダー品目設定のチェックボックス制御 on 20110921 -----<<<<<

        #endregion

        #region private Methods
        /// <summary>
        /// モード変更処理
        /// </summary>
        /// <param name="pccInqCondition">問せ条件</param>
        /// <param name="pccCmpnySt">PCC自社情報</param>
        /// <remarks>
        /// <br>Note       : モード変更処理を行います。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.07.20</br>
        /// <br>Update Note: 2013/02/17 徐飛</br>
        /// <br>管理番号   : 2013/03/13配信分</br>
        /// <br>           : 得意先入力した後、得意先情報再検索処理を追加する</br>   
        /// </remarks>
        private bool ModeChangeProc(string pccInqCondition, PccCmpnySt pccCmpnySt)
        {
            // メーカー別提供取得設定マスタメンテコード
            bool exsit = false;
            int customerCode = this.tNedit_CustomerCode.GetInt();

            for (int i = 0; i < this.Bind_DataSet.Tables[PCCITEM_TABLE].Rows.Count; i++)
            {
                // データセットと比較
                string pccInqConditionPre = (string)this.Bind_DataSet.Tables[PCCITEM_TABLE].Rows[i][INQCONDITION_TITLE];
                if (pccInqConditionPre.Equals(pccInqCondition))
                {
                    // 入力コードがデータセットに存在する場合
                    if ((string)this.Bind_DataSet.Tables[PCCITEM_TABLE].Rows[i][DELETE_DATE] != "")
                    {
                        // 論理削除
                        if (pccCmpnySt.PccCompanyCode == 0)
                        {
                            TMsgDisp.Show(this, 					// 親ウィンドウフォーム
                              emErrorLevel.ERR_LEVEL_INFO,          // エラーレベル
                              ASSEMBLY_ID,						    // アセンブリＩＤまたはクラスＩＤ
                                //"ベース設定のPCC品目設定マスタ情報は既に削除されています。", 	// 表示するメッセージ　//DEL BY wujun FOR Redmine#25173 ON 2011.09.15 
                              "ベース設定のBLﾊﾟｰﾂｵｰﾀﾞｰ品目設定マスタ情報は既に削除されています。", 　//ADD BY wujun FOR Redmine#25173 ON 2011.09.15　
                              0, 									// ステータス値
                              MessageBoxButtons.OK);				// 表示するボタン
                        }
                        else
                        {
                            TMsgDisp.Show(this, 					// 親ウィンドウフォーム
                              emErrorLevel.ERR_LEVEL_INFO,          // エラーレベル
                              ASSEMBLY_ID,						    // アセンブリＩＤまたはクラスＩＤ
                                //"入力されたコードのPCC品目設定マスタ情報は既に削除されています。", 	// 表示するメッセージ　　//DEL BY wujun FOR Redmine#25173 ON 2011.09.15 
                              "入力されたコードのBLﾊﾟｰﾂｵｰﾀﾞｰ品目設定マスタ情報は既に削除されています。", 　//ADD BY wujun FOR Redmine#25173 ON 2011.09.15
                              0, 									// ステータス値
                              MessageBoxButtons.OK);				// 表示するボタン
                        }
                        // PCC品目設定マスタメンテコードのクリア
                        if (_prevCustomerCode == -1)
                        {
                            this.tNedit_CustomerCode.SetInt(0);
                        }
                        else
                        {
                            this.tNedit_CustomerCode.SetInt(_prevCustomerCode);
                        }
                        //問合せ元企業コード
                        this._inqOriginalEpCd = this._inqOriginalEpCdPre.Trim();//@@@@20230303
                        //問合せ元拠点コード
                        this._inqOriginalSecCd = this._inqOriginalSecCdPre;
                        UTabControl_StayInfo.Tabs[0].Selected = true;
                        PMPCC09040UB pMPCC09040UB = (PMPCC09040UB)UTabControl_StayInfo.Tabs[0].Tag;
                        pMPCC09040UB.SetInitFocus(this._startMode);

                        return true;
                    }
                    exsit = true;
                    DialogResult res = DialogResult.No;
                    if (pccCmpnySt.PccCompanyCode == 0)
                    {
                        res = TMsgDisp.Show(
                           this,                                   // 親ウィンドウフォーム
                           emErrorLevel.ERR_LEVEL_QUESTION,            // エラーレベル
                           ASSEMBLY_ID,                            // アセンブリＩＤまたはクラスＩＤ
                            //"ベース設定のPCC品目設定マスタ情報情報が既に登録されています。\n編集を行いますか？",   // 表示するメッセージ　//DEL BY wujun FOR Redmine#25173 ON 2011.09.15 
                           "ベース設定のBLﾊﾟｰﾂｵｰﾀﾞｰ品目設定マスタ情報情報が既に登録されています。\n編集を行いますか？", 　//ADD BY wujun FOR Redmine#25173 ON 2011.09.15
                           0,                                      // ステータス値
                           MessageBoxButtons.YesNo);               // 表示するボタン
                    }
                    else
                    {
                        res = TMsgDisp.Show(
                            this,                                   // 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_QUESTION,            // エラーレベル
                            ASSEMBLY_ID,                            // アセンブリＩＤまたはクラスＩＤ
                            //"入力されたコードのPCC品目設定マスタ情報情報が既に登録されています。\n編集を行いますか？",   // 表示するメッセージ　//DEL BY wujun FOR Redmine#25173 ON 2011.09.15 
                            "入力されたコードのBLﾊﾟｰﾂｵｰﾀﾞｰ品目設定マスタ情報情報が既に登録されています。\n編集を行いますか？", //ADD BY wujun FOR Redmine#25173 ON 2011.09.15
                            0,                                      // ステータス値
                            MessageBoxButtons.YesNo);               // 表示するボタン
                    }
                    switch (res)
                    {
                        case DialogResult.Yes:
                            {
                                // 画面再描画
                                this._dataIndex = i;
                                this.ClearProc();
                                ScreenReconstruction();
                                this.tNedit_CustomerCode.SetInt(pccCmpnySt.PccCompanyCode);
                                uLabel_CustomerName.Text = pccCmpnySt.PccCompanyName.TrimEnd();
                                //問合せ元企業コード
                                this._inqOriginalEpCdPre = this._inqOriginalEpCd.Trim();//@@@@20230303
                                //問合せ元拠点コード
                                this._inqOriginalSecCdPre = this._inqOriginalSecCd;
                                break;
                            }
                        case DialogResult.No:
                            {
                                // コードのクリア
                                if (_prevCustomerCode == -1)
                                {
                                    this.tNedit_CustomerCode.SetInt(0);
                                }
                                else
                                {
                                    this.tNedit_CustomerCode.SetInt(_prevCustomerCode);
                                }
                                //問合せ元企業コード
                                this._inqOriginalEpCd = this._inqOriginalEpCdPre.Trim();//@@@@20230303
                                //問合せ元拠点コード
                                this._inqOriginalSecCd = this._inqOriginalSecCdPre;
                                UTabControl_StayInfo.Tabs[0].Selected = true;
                                PMPCC09040UB pMPCC09040UB = (PMPCC09040UB)UTabControl_StayInfo.Tabs[0].Tag;
                                pMPCC09040UB.SetInitFocus(this._startMode);

                                break;
                            }
                    }
                    return true;
                }
               
            }
            if (!exsit && this._dataIndex >= 0)
            {
                DialogResult res = DialogResult.No;
                if (pccCmpnySt.PccCompanyCode == 0)
                {
                    res = TMsgDisp.Show(
                        this,                                   // 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_QUESTION,            // エラーレベル
                        ASSEMBLY_ID,                            // アセンブリＩＤまたはクラスＩＤ
                        //"ベース設定のＰＣＣ自社設定マスタ情報は存在しません。\n新規登録を行いますか？",   // 表示するメッセージ　//DEL BY wujun FOR Redmine#25173 ON 2011.09.15 
                        "ベース設定のBLﾊﾟｰﾂｵｰﾀﾞｰ自社設定マスタ情報は存在しません。\n新規登録を行いますか？", //ADD BY wujun FOR Redmine#25173 ON 2011.09.15
                        0,                                      // ステータス値
                        MessageBoxButtons.YesNo);               // 表示するボタン
                }
                else
                {
                    res = TMsgDisp.Show(
                        this,                                   // 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_QUESTION,            // エラーレベル
                        ASSEMBLY_ID,                            // アセンブリＩＤまたはクラスＩＤ
                        //"入力されたコードのＰＣＣ自社設定マスタ情報は存在しません。\n新規登録を行いますか？",   // 表示するメッセージ　//DEL BY wujun FOR Redmine#25173 ON 2011.09.15 
                        "入力されたコードのBLﾊﾟｰﾂｵｰﾀﾞｰ自社設定マスタ情報は存在しません。\n新規登録を行いますか？",  　//ADD BY wujun FOR Redmine#25173 ON 2011.09.15
                        0,                                      // ステータス値
                        MessageBoxButtons.YesNo);               // 表示するボタン
                }
                switch (res)
                {
                    case DialogResult.Yes:
                        {
                            // 画面再描画
                            this._dataIndex = -1;
                            ClearProc();
                            _pccItemStDicDicClone = new Dictionary<int, Dictionary<int, PccItemSt>>();
                            _pccItemGrpDicClone = new Dictionary<int, PccItemGrp>();
                            this._pccItemGridClone = new PccItemGrid();
                            GetListFromTabs(ref _pccItemStDicDicClone, out _pccItemGrpDicClone, ref  this._pccItemGridClone);
                            // 新規モード
                            this.Mode_Label.Text = INSERT_MODE;
                            this.tNedit_CustomerCode.SetInt(pccCmpnySt.PccCompanyCode);
                            this.uLabel_CustomerName.Text = pccCmpnySt.PccCompanyName;
                            this._prevCustomerCode = pccCmpnySt.PccCompanyCode;
                            // ----DEL 2013/02/17 徐飛--------->>>>>
                            ////問合せ元企業コード
                            //this._inqOriginalEpCd = pccCmpnySt.InqOriginalEpCd;
                            ////問合せ元拠点コード
                            //this._inqOriginalSecCd = pccCmpnySt.InqOriginalSecCd;
                            ////問合せ元企業コード
                            //this._inqOriginalEpCdPre = pccCmpnySt.InqOriginalEpCd;
                            ////問合せ元拠点コード
                            //this._inqOriginalSecCdPre = pccCmpnySt.InqOriginalSecCd;
                            // ----DEL 2013/02/17 徐飛---------<<<<<
                            // ----ADD 2013/02/17 徐飛--------->>>>>
                            CustomerInfo customerInfo;
                            int status = this._customerInfoAcs.ReadStaticMemoryData(out customerInfo, _enterpriseCode, pccCmpnySt.PccCompanyCode);
                            if (customerInfo != null)
                            {
                                //問合せ元企業コード
                                this._inqOriginalEpCd = customerInfo.CustomerEpCode.Trim();//@@@@20230303
                                //問合せ元拠点コード
                                this._inqOriginalSecCd = customerInfo.CustomerSecCode.TrimEnd();
                            }
                            else
                            {
                                //問合せ元企業コード
                                this._inqOriginalEpCd = pccCmpnySt.InqOriginalEpCd.Trim();//@@@@20230303
                                //問合せ元拠点コード
                                this._inqOriginalSecCd = pccCmpnySt.InqOriginalSecCd;
                            }
                            //問合せ元企業コード
                            this._inqOriginalEpCdPre = this._inqOriginalEpCd.Trim();//@@@@20230303
                            //問合せ元拠点コード
                            this._inqOriginalSecCdPre = this._inqOriginalSecCd;
                            // ----ADD 2013/02/17 徐飛---------<<<<<
                            ScreenInputPermissionControl((int)StartMode.MODE_EDIT);
                            UTabControl_StayInfo.Tabs[0].Selected = true;
                            PMPCC09040UB pMPCC09040UB = (PMPCC09040UB)UTabControl_StayInfo.Tabs[0].Tag;
                            pMPCC09040UB.SetInitFocus(this._startMode);
                            break;
                        }
                    case DialogResult.No:
                        {
                            // コードのクリア
                            if (_prevCustomerCode == -1)
                            {
                                this.tNedit_CustomerCode.SetInt(0);
                            }
                            else
                            {
                                this.tNedit_CustomerCode.SetInt(_prevCustomerCode);
                            }
                            //問合せ元企業コード
                            this._inqOriginalEpCd = this._inqOriginalEpCdPre.Trim();//@@@@20230303
                            //問合せ元拠点コード
                            this._inqOriginalSecCd = this._inqOriginalSecCdPre;
                            break;
                        }
                }
                return true;


            }
           
            return false;
        }

        /// <summary>
        /// データセット列情報構築処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : データセットの列情報を構築します。
        ///					 データセットの列情報がフレームのビュー用グリッドの列になります</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        private void DataSetColumnConstruction()
        {
            DataTable pccItemTable = new DataTable(PCCITEM_TABLE);

            // Addを行う順番が、列の表示順位となります。
            pccItemTable.Columns.Add(DELETE_DATE, typeof(string));
            pccItemTable.Columns.Add(INQORIGINALEPCD_TITLE, typeof(string));
            pccItemTable.Columns.Add(INQORIGINALSECCD_TITLE, typeof(string));
            pccItemTable.Columns.Add(INQOTHEREPCD_TITLE, typeof(string));
            pccItemTable.Columns.Add(INQOTHERSECCD_TITLE, typeof(string));
            pccItemTable.Columns.Add(PCCCOMPANYCODE_TITLE, typeof(int));
            pccItemTable.Columns.Add(PCCCOMPANYNAME_TITLE, typeof(string));
            pccItemTable.Columns.Add(INQCONDITION_TITLE, typeof(string));
            this.Bind_DataSet.Tables.Add(pccItemTable);

            // 明細テーブルの列定義
            DataTable detailDt = new DataTable(PCCITEMDETIAL_TABLE);
            // Addを行う順番が、列の表示順位となります。
            detailDt.Columns.Add(S_DELETEDATE, typeof(string));                 // 削除日
            detailDt.Columns.Add(ITEMGROUPCODE_TITLE1, typeof(int));			// 品目グループコード
            detailDt.Columns.Add(ITEMGROUPNAME_TITLE1, typeof(string));			// 品目グループ名称
            detailDt.Columns.Add(ITEMGRPDSPODR_TITLE1, typeof(int));		    // 品目グループ表示順位
            detailDt.Columns.Add(S_INQCONDITION_TITLE, typeof(string));           // 品目グループGUID
            // --- ADD 2013/05/30 三戸 2013/99/99配信分 SCM障害№10541 --------->>>>>>>>>>>>>>>>>>>>>>>>
            detailDt.Columns.Add(ITEMGRPIMGCODE_TITLE1, typeof(short));			// 品目グループ画像コード
            // --- ADD 2013/05/30 三戸 2013/99/99配信分 SCM障害№10541 ---------<<<<<<<<<<<<<<<<<<<<<<<<

            this.Bind_DataSet.Tables.Add(detailDt);
        }

        /// <summary>
        /// 画面初期表示
        /// </summary>
        /// <remarks>
        /// <br> Note       : 画面初期表示を行います。</br>
        /// <br> Programmer : 黄海霞</br> 
        /// <br> Date       : 2011.07.20</br>
        /// </remarks>
        private void InitializeDisply()
        {
            // タブ内容を表示する
            NewTabProc();
        }

        /// <summary>
        /// 画面構成を初期化する
        /// </summary>
        /// <remarks>
        ///<br> Note       : 画面構成を初期化します。</br>
        ///<br> Programmer : 黄海霞</br> 
        ///<br> Date       : 2011.07.20</br>
        /// </remarks>
        private void NewTabProc()
        {
            PMPCC09040UB  pMPCC09040UB = new PMPCC09040UB(this._enterpriseCode, this._startMode);
            pMPCC09040UB.Dock = DockStyle.Fill;
            pMPCC09040UB.BlCheckedInfoTb = this._blCheckedInfoTb;
            _tabCount = _tabCount + 1;
            // タブページコントロールをインスタンス
            UltraTabPageControl uTabPageControl = new UltraTabPageControl();
            // タブキー
            string tabKey = "tabKey" + this._tabCount.ToString();
            // タブ名称
            string tabName = string.Empty;
           
            // 追加タブ設定位置
            int newIdex = 0;
            newIdex = this.UTabControl_StayInfo.Tabs.Count;
            this.UTabControl_StayInfo.Tabs.Insert(newIdex, tabKey, tabName);

             // タブの外観を設定し、タブコントロールにタブを追加する
             UltraTab uTab = this.UTabControl_StayInfo.Tabs[newIdex];
             uTab.TabPage = uTabPageControl;
             uTab.Tag = pMPCC09040UB;
             uTab.Appearance.BackColor = Color.White;
             uTab.Appearance.BackColor2 = Color.Lavender;
             uTab.Appearance.BackGradientStyle = GradientStyle.Vertical;
             uTab.ActiveAppearance.BackColor = Color.White;
             uTab.ActiveAppearance.BackColor2 = Color.LightPink;
             uTab.ActiveAppearance.BackGradientStyle = GradientStyle.Vertical;
             uTab.VisibleIndex = newIdex;

             uTabPageControl.Controls.Add(pMPCC09040UB);
             this.UTabControl_StayInfo.Controls.Add(uTabPageControl);
             this.UTabControl_StayInfo.SelectedTab = uTab;
             
             // 新規タブを選択
             UltraTab uTabDel = this.UTabControl_StayInfo.Tabs[0];
             if (TODELKEY.Equals(uTabDel.Key) && !_isLoaded)
             {
                 this.UTabControl_StayInfo.Tabs.Remove(uTabDel);
             }
             int tabCount = this.UTabControl_StayInfo.Tabs.Count;
             if (tabCount >= MAX_TABCOUNT)
             {
                 this._newTabButtonTool.SharedProps.Enabled = false;
             }
             else
             {
                 this._newTabButtonTool.SharedProps.Enabled = true;
             }
            if (tabCount == 1)
            {
                this._deleteTabButtonTool.SharedProps.Enabled = false;
            }
            else
            {
                this._deleteTabButtonTool.SharedProps.Enabled = true;
            }
        }

      
        /// <summary>
        /// 画面再構築処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : モードに基づいて画面を再構築します。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        private void ScreenReconstruction()
        {
            //自社設定マスタ取得処理
            GetCustomerHTable();
            if (this.DataIndex < 0)
            {
                
                // 新規モード
                this.Mode_Label.Text = INSERT_MODE;
                this._startMode = (int)StartMode.MODE_NEW;
                //_dataIndexバッファ保持
                this._indexBuf = this._dataIndex;

                // 画面入力許可制御処理
                ScreenInputPermissionControl(this._startMode);
                // フォーカス設定
                UTabControl_StayInfo.Tabs[0].Selected = true;
                PMPCC09040UB pMPCC09040UB = (PMPCC09040UB)UTabControl_StayInfo.Tabs[0].Tag;
                pMPCC09040UB.SetInitFocus(this._startMode);
                 this.tNedit_CustomerCode.Focus();
                 //現在の画面情報を取得する
                 if (this._pccItemGridClone != null)
                 {
                     this._pccItemGridClone = new PccItemGrid();
                 }
                 _pccItemStDicDicClone = new Dictionary<int, Dictionary<int, PccItemSt>>();
                 _pccItemGrpDicClone = new Dictionary<int, PccItemGrp>();
                 this._pccItemGridClone = new PccItemGrid();
                 GetListFromTabs(ref _pccItemStDicDicClone, out _pccItemGrpDicClone, ref  this._pccItemGridClone);
                _firstCustomerCode = 0;
                //-----ADD by huanghx for #25387 BLパーツオーダー品目設定のチェックボックス制御 on 20110921 ----->>>>>
                // BLコードチェックテプッル取得処理
                this._blCheckedInfoTb = new Hashtable();
                foreach (UltraTab eachTab in this.UTabControl_StayInfo.Tabs)
                {
                    PMPCC09040UB pMPCC09040UBEach = (PMPCC09040UB)eachTab.Tag;
                    pMPCC09040UB.BlCheckedInfoTb = this._blCheckedInfoTb;
                    pMPCC09040UB.InitBlCheckedTb();
                    this._blCheckedInfoTb = pMPCC09040UB.BlCheckedInfoTb;
                }
                //-----ADD by huanghx for #25387 BLパーツオーダー品目設定のチェックボックス制御 on 20110921 -----<<<<<
                
            }
            else
            {
                string guid = (string)this.Bind_DataSet.Tables[PCCITEM_TABLE].Rows[this._dataIndex][INQCONDITION_TITLE];
                this._startMode = (int)StartMode.MODE_EDIT;
                PccItemGrid pccItemGrid = (PccItemGrid)this._pccItemGrpTable[guid];
                List<PccItemGrp> pccItemGrpList = this._pccItemGrpDict[pccItemGrid.InqCondition];
                Dictionary<int, List<PccItemSt>> pccItemStDict = null;
                if (pccItemGrpList != null)
                {
                    if (this._pccItemStDictDict != null && this._pccItemStDictDict.Count > 0
                        && this._pccItemStDictDict.ContainsKey(pccItemGrid.InqCondition))
                    {
                        pccItemStDict = this._pccItemStDictDict[pccItemGrid.InqCondition];
                    }
                }
                // 画面展開処理
                tNedit_CustomerCode.SetInt(pccItemGrid.PccCompanyCode);
                _firstCustomerCode = pccItemGrid.PccCompanyCode;
                _prevCustomerCode = pccItemGrid.PccCompanyCode;
                //得意先初期化
               
                //得意先名称
                uLabel_CustomerName.Text = pccItemGrid.PccCompanyName;
                //問合せ元企業コード
                this._inqOriginalEpCd = pccItemGrid.InqOriginalEpCd.Trim();//@@@@20230303
                //問合せ元拠点コード
                this._inqOriginalSecCd = pccItemGrid.InqOriginalSecCd;
                //前問合せ元企業コード
                this._inqOriginalEpCdPre = this._inqOriginalEpCd.Trim();//@@@@20230303
                //前問合せ元拠点コード
                this._inqOriginalSecCdPre = this._inqOriginalSecCd;
                this._prevCustomerCode = pccItemGrid.PccCompanyCode;
                PccItemToScreen(pccItemGrpList, pccItemStDict);
                UltraTab selectedTab = UTabControl_StayInfo.Tabs[0];
                this.DeleteTabProc(selectedTab);

                if (pccItemGrid.LogicalDeleteCode == 0)
                {
                    // 更新モード
                    this.Mode_Label.Text = UPDATE_MODE;
                    this._startMode = (int)StartMode.MODE_EDIT;
                   
                    
                    // 画面入力許可制御処理
                    ScreenInputPermissionControl(this._startMode);

                    // ボタン設定
                    this._deleteTabButtonTool.SharedProps.Enabled = true;
                    if (pccItemGrpList.Count == MAX_TABCOUNT)
                    {
                        this._newTabButtonTool.SharedProps.Enabled = false;
                    }
                    else
                    {
                        this._newTabButtonTool.SharedProps.Enabled = true;
                    }


                    //クローン作成
                    //現在の画面情報を取得する
                    this._pccItemGridClone = pccItemGrid;
                    _pccItemStDicDicClone = new Dictionary<int, Dictionary<int, PccItemSt>>();
                    _pccItemGrpDicClone = new Dictionary<int, PccItemGrp>();
                    GetListFromTabs(ref _pccItemStDicDicClone, out _pccItemGrpDicClone, ref  this._pccItemGridClone);
                    UTabControl_StayInfo.Tabs[0].Selected = true;
                    //-----DEL by huanghx for #25387 BLパーツオーダー品目設定のチェックボックス制御 on 20110921 ----->>>>>
                    //PMPCC09040UB pMPCC09040UB = (PMPCC09040UB)UTabControl_StayInfo.Tabs[0].Tag;
                    //pMPCC09040UB.InitBlCheckedTb();
                    //-----DEL by huanghx for #25387 BLパーツオーダー品目設定のチェックボックス制御 on 20110921 -----<<<<<
                    //-----ADD by huanghx for #25387 BLパーツオーダー品目設定のチェックボックス制御 on 20110921 ----->>>>>
                    // BLコードチェックテプッル取得処理
                    this._blCheckedInfoTb = new Hashtable();
                    foreach (UltraTab eachTab in this.UTabControl_StayInfo.Tabs)
                    {
                        PMPCC09040UB pMPCC09040UB = (PMPCC09040UB)eachTab.Tag;
                        pMPCC09040UB.BlCheckedInfoTb = this._blCheckedInfoTb;
                        pMPCC09040UB.InitBlCheckedTb();
                        this._blCheckedInfoTb = pMPCC09040UB.BlCheckedInfoTb;
                    }
                    //-----ADD by huanghx for #25387 BLパーツオーダー品目設定のチェックボックス制御 on 20110921 -----<<<<<
                    //_dataIndexバッファ保持
                    this._indexBuf = this._dataIndex;
                    this.tNedit_CustomerCode.Focus();
                }
                else
                {
                    // 削除モード
                    this.Mode_Label.Text = DELETE_MODE;
                    
                    this._startMode = (int)StartMode.MODE_EDITLOGICDELETE;
                    //_dataIndexバッファ保持
                    this._indexBuf = this._dataIndex;

                   
                    // 画面入力許可制御処理
                    ScreenInputPermissionControl(this._startMode);
                    UTabControl_StayInfo.Tabs[0].Selected = true; ;
                }

            }
        }

        /// <summary>
        /// PCC品目画面展開処理
        /// </summary>
        /// <param name="pccItemGrpList">PCC品目グループリスト</param>
        /// <param name="pccItemStDict">PCC品目設定ディクショナリー</param>
        /// <remarks>
        /// <br>Note       : 画面展開処理。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        private void PccItemToScreen(List<PccItemGrp> pccItemGrpList, Dictionary<int, List<PccItemSt>> pccItemStDict)
        {
            foreach (PccItemGrp pccItemGrp in pccItemGrpList)
            {
                NewTabProc();
                UltraTab newtab = this.UTabControl_StayInfo.SelectedTab;
                newtab.Text = pccItemGrp.ItemGroupName;
                PMPCC09040UB pMPCC09040UB = (PMPCC09040UB)newtab.Tag;
                if (pccItemStDict != null && pccItemStDict .Count > 0 
                    && pccItemStDict.ContainsKey(pccItemGrp.ItemGroupCode))
                {
                    pMPCC09040UB.PccItemToGrid(pccItemStDict[pccItemGrp.ItemGroupCode]);
                }
                // --- ADD 2013/05/30 三戸 2013/99/99配信分 SCM障害№10541 --------->>>>>>>>>>>>>>>>>>>>>>>>
                //品目グループ画像表示
                pMPCC09040UB.ImageComboSet(pccItemGrp.ItemGrpImgCode);
                // --- ADD 2013/05/30 三戸 2013/99/99配信分 SCM障害№10541 ---------<<<<<<<<<<<<<<<<<<<<<<<<
            }
        }

        /// <summary>
		/// 画面入力許可制御処理
		/// </summary>
        /// <param name="modifyFiag">入力許可設定値</param>
		/// <remarks>
		/// <br>Note       : 画面の入力許可を制御します。</br>
        /// <br>Programmer : 黄海霞</br>
		/// <br>Date       : 2011.07.20</br>
		/// </remarks>
        private void ScreenInputPermissionControl(int modifyFiag)
        {
            switch (modifyFiag)
            {
                case (int)StartMode.MODE_NEW:
                    {
                        tNedit_CustomerCode.Enabled = true;
                        UButton_CustomerGuide.Enabled = true;
                        GridsPermissionControl(false);
                        // ボタン設定
                        this._saveButtonTool.SharedProps.Enabled = false;
                        this._reviveButtonTool.SharedProps.Enabled = false;
                        this._allDeleteButtonTool.SharedProps.Enabled = false;
                        this._deleteTabButtonTool.SharedProps.Enabled = false;
                        this._newTabButtonTool.SharedProps.Enabled = false;
                        this._clearButtonTool.SharedProps.Enabled = false;
                        this._reButtonNameButtonTool.SharedProps.Enabled = false;
                        this._quoteButtonTool.SharedProps.Enabled = false;
                        break;
                    }
                case (int)StartMode.MODE_EDIT:
                    {
                        tNedit_CustomerCode.Enabled = true;
                        UButton_CustomerGuide.Enabled = true;
                        GridsPermissionControl(true);
                        // ボタン設定
                        this._saveButtonTool.SharedProps.Enabled = true;
                        this._reviveButtonTool.SharedProps.Enabled = false;
                        this._allDeleteButtonTool.SharedProps.Enabled = false;
                        this._clearButtonTool.SharedProps.Enabled = true;
                        this._reButtonNameButtonTool.SharedProps.Enabled = true;
                        this._quoteButtonTool.SharedProps.Enabled = true;

                        if (UTabControl_StayInfo.Tabs.Count == 1)
                        {
                            this._deleteTabButtonTool.SharedProps.Enabled = false;
                        }
                        else
                        {
                            this._deleteTabButtonTool.SharedProps.Enabled = true;
                        }
                        if (UTabControl_StayInfo.Tabs.Count == MAX_TABCOUNT)
                        {
                            this._newTabButtonTool.SharedProps.Enabled = false;
                        }
                        else
                        {
                            this._newTabButtonTool.SharedProps.Enabled = true;
                        }
                        break;
                    }
                case (int)StartMode.MODE_EDITLOGICDELETE:
                    {
                        tNedit_CustomerCode.Enabled = false;
                        UButton_CustomerGuide.Enabled = false;
                        GridsPermissionControl(false);
                        // ボタン設定
                        this._saveButtonTool.SharedProps.Enabled = false;
                        this._reviveButtonTool.SharedProps.Enabled = true;
                        this._allDeleteButtonTool.SharedProps.Enabled = true;
                        this._deleteTabButtonTool.SharedProps.Enabled = false;
                        this._newTabButtonTool.SharedProps.Enabled = false;
                        this._clearButtonTool.SharedProps.Enabled = false;
                        this._reButtonNameButtonTool.SharedProps.Enabled = false;
                        this._quoteButtonTool.SharedProps.Enabled = false;
                        break;
                    }
            }
           
        }

        /// <summary>
        /// 画面グリッド編集許可制御処理
        /// </summary>
        /// <param name="enabled">入力許可設定値</param>
        /// <remarks>
        /// <br>Note       : 画面のグリッド編集を制御します。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        private void GridsPermissionControl(bool enabled)
        {
            if (UTabControl_StayInfo.Tabs != null && UTabControl_StayInfo.Tabs.Count > 0)
            {
                foreach (UltraTab uTab in UTabControl_StayInfo.Tabs)
                {
                    PMPCC09040UB pMPCC09040UB = (PMPCC09040UB)uTab.Tag;
                    if (pMPCC09040UB != null)
                    {
                        pMPCC09040UB.PermissionControl(enabled);
                    }
                }
            }
        }

        /// <summary>
        /// PCC品目グループデータセット展開処理
        /// </summary>
        /// <param name="pccItemGrid">PCC品目グループオブジェクト</param>
        /// <param name="index">データセットへ展開するインデックス</param>
        /// <remarks>
        /// <br>Note       : PCC品目グループをデータセットに格納します。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        private void PccItemGridToDataSet(PccItemGrid pccItemGrid, int index)
        {
            if ((index < 0) || (this.Bind_DataSet.Tables[PCCITEM_TABLE].Rows.Count <= index))
            {
                // 新規と判断して、行を追加する
                DataRow dataRow = this.Bind_DataSet.Tables[PCCITEM_TABLE].NewRow();
                this.Bind_DataSet.Tables[PCCITEM_TABLE].Rows.Add(dataRow);

                // indexを行の最終行番号する
                index = this.Bind_DataSet.Tables[PCCITEM_TABLE].Rows.Count - 1;
            }

            if (pccItemGrid.LogicalDeleteCode == 0)
            {
                this.Bind_DataSet.Tables[PCCITEM_TABLE].Rows[index][DELETE_DATE] = "";
            }
            else
            {
                this.Bind_DataSet.Tables[PCCITEM_TABLE].Rows[index][DELETE_DATE] = pccItemGrid.UpdateDateTimeJpInFormal;
            }
            this.Bind_DataSet.Tables[PCCITEM_TABLE].Rows[index][INQORIGINALEPCD_TITLE] = pccItemGrid.InqOriginalEpCd.Trim();//@@@@20230303
            this.Bind_DataSet.Tables[PCCITEM_TABLE].Rows[index][INQORIGINALSECCD_TITLE] = pccItemGrid.InqOriginalSecCd;
            this.Bind_DataSet.Tables[PCCITEM_TABLE].Rows[index][INQOTHEREPCD_TITLE] = pccItemGrid.InqOtherEpCd;
            this.Bind_DataSet.Tables[PCCITEM_TABLE].Rows[index][INQOTHERSECCD_TITLE] = pccItemGrid.InqOtherSecCd;

            this.Bind_DataSet.Tables[PCCITEM_TABLE].Rows[index][PCCCOMPANYCODE_TITLE] = pccItemGrid.PccCompanyCode;
            this.Bind_DataSet.Tables[PCCITEM_TABLE].Rows[index][PCCCOMPANYNAME_TITLE] = pccItemGrid.PccCompanyName;
            // GUID
            this.Bind_DataSet.Tables[PCCITEM_TABLE].Rows[index][INQCONDITION_TITLE] = pccItemGrid.InqCondition;

            if (this._pccItemGrpTable.ContainsKey(pccItemGrid.InqCondition))
            {
                this._pccItemGrpTable.Remove(pccItemGrid.InqCondition);
            }
            this._pccItemGrpTable.Add(pccItemGrid.InqCondition, pccItemGrid);

        }

        /// <summary>
        /// PCC品目設定データセット展開処理
        /// </summary>
        /// <param name="pccItemGrp">PCC品目設定オブジェクト</param>
        /// <param name="index">データセットへ展開するインデックス</param>
        /// <remarks>
        /// <br>Note       : PCC品目設定をデータセットに格納します。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        private void PccItemGrpToDataSet(PccItemGrp pccItemGrp, int index)
        {
            if ((index < 0) || (this.Bind_DataSet.Tables[PCCITEMDETIAL_TABLE].Rows.Count <= index))
            {
                // 新規と判断して、行を追加する
                DataRow dataRow = this.Bind_DataSet.Tables[PCCITEMDETIAL_TABLE].NewRow();
                this.Bind_DataSet.Tables[PCCITEMDETIAL_TABLE].Rows.Add(dataRow);

                // indexを行の最終行番号する
                index = this.Bind_DataSet.Tables[PCCITEMDETIAL_TABLE].Rows.Count - 1;
            }

            if (pccItemGrp.LogicalDeleteCode == 0)
            {
                this.Bind_DataSet.Tables[PCCITEMDETIAL_TABLE].Rows[index][S_DELETEDATE] = "";
            }
            else
            {
                this.Bind_DataSet.Tables[PCCITEMDETIAL_TABLE].Rows[index][S_DELETEDATE] = pccItemGrp.UpdateDateTimeJpInFormal;
            }
            this.Bind_DataSet.Tables[PCCITEMDETIAL_TABLE].Rows[index][ITEMGROUPCODE_TITLE1] = pccItemGrp.ItemGroupCode;
            this.Bind_DataSet.Tables[PCCITEMDETIAL_TABLE].Rows[index][ITEMGROUPNAME_TITLE1] = pccItemGrp.ItemGroupName;
            this.Bind_DataSet.Tables[PCCITEMDETIAL_TABLE].Rows[index][ITEMGRPDSPODR_TITLE1] = pccItemGrp.ItemGrpDspOdr;
            // GUID
            this.Bind_DataSet.Tables[PCCITEMDETIAL_TABLE].Rows[index][S_INQCONDITION_TITLE] = pccItemGrp.InqCondition;
            // --- ADD 2013/05/30 三戸 2013/99/99配信分 SCM障害№10541 --------->>>>>>>>>>>>>>>>>>>>>>>>
            this.Bind_DataSet.Tables[PCCITEMDETIAL_TABLE].Rows[index][ITEMGRPIMGCODE_TITLE1] = pccItemGrp.ItemGrpImgCode;
            // --- ADD 2013/05/30 三戸 2013/99/99配信分 SCM障害№10541 ---------<<<<<<<<<<<<<<<<<<<<<<<<
            if (this._detailTable.ContainsKey(pccItemGrp.InqCondition))
            {
                this._detailTable.Remove(pccItemGrp.InqCondition);
            }
            this._detailTable.Add(pccItemGrp.InqCondition, pccItemGrp);

        }

        /// <summary>アイコンの設定</summary>
        /// <remarks>
        /// Note       : フレームのアイコンの設定を行います。<br />
        /// Programmer : 黄海霞
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        private void SetToolIcon()
        {
            //ツールバー
            _closeButtonTool = (ButtonTool)this.MainToolbarsManager.Tools["ButtonTool_Close"];
            _saveButtonTool = (ButtonTool)this.MainToolbarsManager.Tools["ButtonTool_Save"];
            _newTabButtonTool = (ButtonTool)this.MainToolbarsManager.Tools["ButtonTool_NewTab"];
            _deleteTabButtonTool = (ButtonTool)this.MainToolbarsManager.Tools["ButtonTool_DeleteTab"];
            _clearButtonTool = (ButtonTool)this.MainToolbarsManager.Tools["ButtonTool_Clear"];
            _allDeleteButtonTool = (ButtonTool)this.MainToolbarsManager.Tools["ButtonTool_AllDelete"];
            _reviveButtonTool = (ButtonTool)this.MainToolbarsManager.Tools["ButtonTool_Revive"];
            _reButtonNameButtonTool = (ButtonTool)this.MainToolbarsManager.Tools["ButtonTool_ReButtonName"];

            _quoteButtonTool = (ButtonTool)this.MainToolbarsManager.Tools["ButtonTool_Quote"];
            this.MainToolbarsManager.ImageListSmall = IconResourceManagement.ImageList24;
            _closeButtonTool.SharedProps.AppearancesSmall.Appearance.Image = Size24_Index.CLOSE;
            _saveButtonTool.SharedProps.AppearancesSmall.Appearance.Image = Size24_Index.SAVE;
            _newTabButtonTool.SharedProps.AppearancesSmall.Appearance.Image = Size24_Index.NEW;
            _deleteTabButtonTool.SharedProps.AppearancesSmall.Appearance.Image = Size24_Index.DELETE;
            _allDeleteButtonTool.SharedProps.AppearancesSmall.Appearance.Image = Size24_Index.DELETE;
            _reviveButtonTool.SharedProps.AppearancesSmall.Appearance.Image = Size24_Index.REVIVAL;
            _reButtonNameButtonTool.SharedProps.AppearancesSmall.Appearance.Image = Size24_Index.SETUP1;
            _quoteButtonTool.SharedProps.AppearancesSmall.Appearance.Image = Size24_Index.ADJUST;
            _clearButtonTool.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.ALLCANCEL;
            
            ImageList imageList16 = IconResourceManagement.ImageList16;
            
            // ガイドボタンのアイコン設定
            this.UButton_CustomerGuide.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
        }

        /// <summary>
        /// 画面の閉める
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// Note       : フレームのアイコンの設定を行います。<br />
        /// Programmer : 黄海霞<br />
        /// Date       : 2011.7.20<br />
        /// </remarks>
        private void CloseForm()
        {
            // 削除モード以外の場合は保存確認処理を行う
            if (this.Mode_Label.Text != DELETE_MODE)
            {
                //保存確認
                Dictionary<int, PccItemGrp> pccItemGrpDic = new Dictionary<int,PccItemGrp>();
                Dictionary<int, Dictionary<int, PccItemSt>> pccItemStDictPs = new Dictionary<int,Dictionary<int,PccItemSt>>();
                PccItemGrid pccItemGrid = new PccItemGrid();
                pccItemGrid = this._pccItemGridClone.Clone();
                //現在の画面情報を取得する
                GetListFromTabs(ref pccItemStDictPs, out pccItemGrpDic, ref  pccItemGrid);
                //最初に取得した画面情報と比較
                bool isEquals = ListCompare(pccItemGrpDic, pccItemStDictPs);
                if (!isEquals)
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
                                if (SaveProc() == false)
                                {
                                    return;
                                }

                                if (UnDisplaying != null)
                                {
                                    MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                                    UnDisplaying(this, me);
                                }

                                break;
                            }
                        case DialogResult.No:
                            {
                                if (UnDisplaying != null)
                                {
                                    MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.Cancel);
                                    UnDisplaying(this, me);
                                }

                                break;
                            }
                        default:
                            {
								 tNedit_CustomerCode.Focus();
                                UTabControl_StayInfo.Tabs[0].Selected = true;
                                PMPCC09040UB pMPCC09040UB = (PMPCC09040UB)UTabControl_StayInfo.Tabs[0].Tag;
                                pMPCC09040UB.SetInitFocus(this._startMode);
                                
                                return;
                            }
                    }
                }
            }

            this.DialogResult = DialogResult.Cancel;
            this._indexBuf = -2;

            ClearProc();
            
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
        /// 画面PCC品目グループクラス比較
        /// </summary>
        /// <param name="pccItemGrpList">画面PCC品目グループリスト</param>
        /// <param name="pccItemStDict">画面PCC品目設定</param>
        /// <remarks>
        /// <br>Note       : 画面PCC品目グループクラスを比較します。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        private bool ListCompare(Dictionary<int, PccItemGrp> pccItemGrpList, Dictionary<int, Dictionary<int, PccItemSt>> pccItemStDict)
        {
            bool isEqualsValue = true;
            if (_firstCustomerCode != tNedit_CustomerCode.GetInt())
            {
                isEqualsValue = false;
                return isEqualsValue;
            }
            if (pccItemGrpList.Count != this._pccItemGrpDicClone.Count || pccItemStDict.Count != this._pccItemStDicDicClone.Count)
            {
                isEqualsValue = false;
                return isEqualsValue;
            }
            //PCC品目グループ比較
            foreach (KeyValuePair<int, PccItemGrp> pairPccItemGrp in pccItemGrpList)
             {
                if (!this._pccItemGrpDicClone.ContainsKey(pairPccItemGrp.Key) || !pairPccItemGrp.Value.Equals(this._pccItemGrpDicClone[pairPccItemGrp.Key]))
                {
                    isEqualsValue = false;
                    return isEqualsValue;
                }
            }
            //PCC品目設定比較
            foreach (KeyValuePair<int, Dictionary<int, PccItemSt>> pccItemStPair in pccItemStDict)
            {

                if (pccItemStPair.Value.Count != (this._pccItemStDicDicClone[pccItemStPair.Key].Count))
                {
                    isEqualsValue = false;
                    return isEqualsValue;
                }
                if (!this._pccItemStDicDicClone.ContainsKey(pccItemStPair.Key))
                {
                    isEqualsValue = false;
                    return isEqualsValue;
                }
                foreach (KeyValuePair<int, PccItemSt> pccItemStPairPair in pccItemStPair.Value)
                {
                    if (!this._pccItemStDicDicClone[pccItemStPair.Key].ContainsKey(pccItemStPairPair.Key))
                    {
                        isEqualsValue = false;
                        return isEqualsValue;
                    }
                    if (!pccItemStPairPair.Value.Equals((this._pccItemStDicDicClone[pccItemStPair.Key][pccItemStPairPair.Key])))
                    {
                        isEqualsValue = false;
                        return isEqualsValue;
                    }
                }
            }
            return isEqualsValue;
        }

        /// <summary>
        /// 画面PCC品目グループクラス格納処理
        /// </summary>
        /// <param name="pccItemGrpList">画面PCC品目グループリスト</param>
        /// <param name="pccItemStDict">画面PCC品目設定リスト</param>
        /// <param name="pccItemGrid">画面PCC品目グリッド</param>
        /// <remarks>
        /// <br>Note       : 画面PCC品目グループクラス格納を格納します。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        private void DispToPccItemGrp(ref List<PccItemGrp> pccItemGrpList, ref Dictionary<int, List<PccItemSt>> pccItemStDict, ref PccItemGrid pccItemGrid)
        {
            //更新前のPCC品目グループリスト
            List<PccItemGrp> pccItemGrpListOld = null;
            //PCC品目グループディクショナリー
            Dictionary<int, PccItemGrp> pccItemGrpDic = null;
            Dictionary<int, Dictionary<int, PccItemSt>> pccItemStDictPs = null;
            //更新後のPCC品目グループリスト
            pccItemGrpList = null;
            //PCC品目グリッドマスタ
            if (pccItemGrid == null)
            {
                pccItemGrid = new PccItemGrid();
                //PCC自社コード
                pccItemGrid.PccCompanyCode = this.tNedit_CustomerCode.GetInt();
                //企業コード
                pccItemGrid.EnterpriseCode = this._enterpriseCode;
                pccItemGrid.InqOriginalEpCd = this._inqOriginalEpCd.Trim();//@@@@20230303
                pccItemGrid.InqOriginalSecCd = this._inqOriginalSecCd;
                pccItemGrid.InqOtherEpCd = this._inqOtherEpCd;
                pccItemGrid.InqOtherSecCd = this._inqOtherSecCd;
            }
            GetListFromTabs(ref pccItemStDictPs, out pccItemGrpDic, ref pccItemGrid);
            if (this._pccItemGrpDict != null && this._pccItemGrpDict.ContainsKey(pccItemGrid.InqCondition))
            {
                //PCC品目グループリスト存在場合
                pccItemGrpListOld = this._pccItemGrpDict[pccItemGrid.InqCondition];
                //PCC品目グループリストを更新
                foreach (PccItemGrp pccItemGrp in pccItemGrpListOld)
                {
                    PccItemGrp pccItemGrpNew = null;
                    if (pccItemGrpDic != null && pccItemGrpDic.ContainsKey(pccItemGrp.ItemGroupCode))
                    {
                        pccItemGrpNew = new PccItemGrp();
                        pccItemGrpNew = pccItemGrpDic[pccItemGrp.ItemGroupCode];
                        pccItemGrpNew.CreateDateTime = pccItemGrp.CreateDateTime;
                        pccItemGrpNew.UpdateDateTime = pccItemGrp.UpdateDateTime;
                        pccItemGrpNew.InqOriginalEpCd = pccItemGrid.InqOriginalEpCd.Trim();//@@@@20230303
                        pccItemGrpNew.InqOriginalSecCd = pccItemGrid.InqOriginalSecCd;
                        pccItemGrpNew.InqOtherEpCd = pccItemGrid.InqOtherEpCd;
                        pccItemGrpNew.InqOtherSecCd = pccItemGrid.InqOtherSecCd;
                        pccItemGrpNew.InqCondition = pccItemGrid.InqCondition;
                        pccItemGrpNew.LogicalDeleteCode = pccItemGrp.LogicalDeleteCode;
                        //更新区分= 1:更新
                        pccItemGrpNew.UpdateFlag = pccItemGrp.UpdateFlag;
                        pccItemGrpDic.Remove(pccItemGrp.ItemGroupCode);

                    }
                    else
                    {
                        pccItemGrpNew = pccItemGrp;
                        //更新区分= 2:削除
                        pccItemGrpNew.UpdateFlag = 2;
                    }
                    pccItemGrpDic.Add(pccItemGrpNew.ItemGroupCode, pccItemGrpNew);
                }
            }
            //更新後のPCC品目グループリストを作成
            if (pccItemGrpDic != null && pccItemGrpDic.Count > 0)
            {
                pccItemGrpList = new List<PccItemGrp>();
                pccItemGrpList.AddRange(pccItemGrpDic.Values);
                
            }

            //更新前のPCC品目設定ディクショナリー
            Dictionary<int, List<PccItemSt>> pccItemStDictOld = null;
            if (this._pccItemStDictDict != null && this._pccItemStDictDict.ContainsKey(pccItemGrid.InqCondition))
            {
                //PCC品目グループリスト存在場合
                pccItemStDictOld = this._pccItemStDictDict[pccItemGrid.InqCondition];
                foreach (KeyValuePair<int, List<PccItemSt>> pccItemStListPair in pccItemStDictOld)
                {
                    Dictionary<int, PccItemSt> pccItemStListNew = new Dictionary<int, PccItemSt>();
                    if (pccItemStDictPs != null && pccItemStDictPs.Count > 0 && pccItemStDictPs.ContainsKey(pccItemStListPair.Key))
                    {
                        pccItemStListNew = new Dictionary<int, PccItemSt>();
                        pccItemStListNew = pccItemStDictPs[pccItemStListPair.Key];
                        foreach (PccItemSt pccItemSt in pccItemStListPair.Value)
                        {
                            int  listDiv = 0;
                            if (pccItemSt.ItemDspPos2 >= MAXROW)
                            {
                                listDiv = (pccItemSt.ItemDspPos1 + (GRIDCOUNT / 2) -1) * MAXROW + pccItemSt.ItemDspPos2;
                            }
                            else
                            {
                                listDiv = pccItemSt.ItemDspPos1 * MAXROW + pccItemSt.ItemDspPos2;
                            }
                            if (pccItemStListNew != null && pccItemStListNew.Count > 0 && pccItemStListNew.ContainsKey(listDiv))
                            {
                                PccItemSt pccItemStNew = pccItemStDictPs[pccItemStListPair.Key][listDiv];
                                pccItemStNew.CreateDateTime = pccItemSt.CreateDateTime;
                                pccItemStNew.UpdateDateTime = pccItemSt.UpdateDateTime;
                                pccItemStNew.InqOtherEpCd = pccItemSt.InqOtherEpCd;
                                pccItemStNew.InqOtherSecCd = pccItemSt.InqOtherSecCd;

                                pccItemStNew.LogicalDeleteCode = pccItemSt.LogicalDeleteCode;
                                //更新区分= 1:更新
                                pccItemStNew.UpdateFlag = pccItemSt.UpdateFlag;
                            }
                            else
                            {
                                //更新区分= 2:削除
                                pccItemSt.UpdateFlag = 2;
                                pccItemStListNew.Add(listDiv, pccItemSt);
                            }
                        }
                        pccItemStDictPs.Remove(pccItemStListPair.Key);
                        pccItemStDictPs.Add(pccItemStListPair.Key, pccItemStListNew);
                    }
                    else
                    {
                        if (pccItemStDictPs != null && pccItemStDictPs.Count > 0)
                        {
                            pccItemStDictPs.Remove(pccItemStListPair.Key);
                        }
                        else
                        {
                            pccItemStDictPs = new Dictionary<int, Dictionary<int, PccItemSt>>();
                        }
                        foreach (PccItemSt pccItemSt in pccItemStListPair.Value)
                        {
                            int listDiv = 0;
                            if (pccItemSt.ItemDspPos2 >= MAXROW)
                            {
                                listDiv = (pccItemSt.ItemDspPos1 + (GRIDCOUNT / 2) - 1) * MAXROW + pccItemSt.ItemDspPos2;
                            }
                            else
                            {
                                listDiv = pccItemSt.ItemDspPos1 * MAXROW + pccItemSt.ItemDspPos2;
                            }
                            //更新区分= 2:削除
                            pccItemSt.UpdateFlag = 2;
                            pccItemStListNew.Add(listDiv, pccItemSt);
                        }
                        pccItemStDictPs.Add(pccItemStListPair.Key, pccItemStListNew);

                    }
                   
                }
            }
            
            pccItemStDict = new Dictionary<int, List<PccItemSt>>();
            if (pccItemStDictPs != null && pccItemStDictPs.Count > 0)
            {
                foreach (KeyValuePair<int, Dictionary<int, PccItemSt>> pccItemStListPair in pccItemStDictPs)
                {
                    List<PccItemSt> pccItemStNewList = new List<PccItemSt>();
                    pccItemStNewList.AddRange(pccItemStListPair.Value.Values);
                    pccItemStDict.Add(pccItemStListPair.Key, pccItemStNewList);
                }
            }
           
        }

        /// <summary>
        /// 画面PCC品目設定ラス格納処理
        /// </summary>
        /// <param name="pccItemStDict">画面PCC品目設定リスト</param>
        /// <param name="pccItemGrpDic">画面PCC品目グループリスト</param>
        /// <param name="pccItemGrid">画面PCC品目グリッド</param>
        /// <remarks>
        /// <br>Note       : 画面PCC品目設定クラス格納を格納します。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        private void GetListFromTabs(ref Dictionary<int, Dictionary<int,PccItemSt>> pccItemStDict, out Dictionary<int, PccItemGrp> pccItemGrpDic, ref PccItemGrid pccItemGrid)
        {
            //画面のTabs情報を取得
            int i = 1;
            pccItemGrpDic = null;
            PccItemGrp pccItemGrp = null;
            foreach (UltraTab eachTab in this.UTabControl_StayInfo.Tabs)
            {
                PMPCC09040UB pMPCC09040U = (PMPCC09040UB)eachTab.Tag;
                //PCC品目グループクラス
                pccItemGrp = new PccItemGrp();
                //PCC自社コード
                pccItemGrp.PccCompanyCode = pccItemGrid.PccCompanyCode;
                //企業コード
                pccItemGrp.InqCondition = pccItemGrid.InqCondition;
                pccItemGrp.InqOriginalEpCd = pccItemGrid.InqOriginalEpCd.Trim();//@@@@20230303
                pccItemGrp.InqOriginalSecCd = pccItemGrid.InqOriginalSecCd;
                pccItemGrp.InqOtherEpCd = pccItemGrid.InqOtherEpCd;
                pccItemGrp.InqOtherSecCd = pccItemGrid.InqOtherSecCd;
                //品目グループコード
                pccItemGrp.ItemGroupCode = i;
                //品目グループ名称
                pccItemGrp.ItemGroupName = eachTab.Text;
                //品目グループ表示順位
                pccItemGrp.ItemGrpDspOdr = i;
                //更新区分= 0:新規
                pccItemGrp.UpdateFlag = 0;
                // --- ADD 2013/05/30 三戸 2013/99/99配信分 SCM障害№10541 --------->>>>>>>>>>>>>>>>>>>>>>>>
                pccItemGrp.ItemGrpImgCode = pMPCC09040U.GetItemGrpImgCode();
                // --- ADD 2013/05/30 三戸 2013/99/99配信分 SCM障害№10541 ---------<<<<<<<<<<<<<<<<<<<<<<<<
                //PCC品目設定マスタリスト
                Dictionary<int, PccItemSt> pccItemStList = null;
                //画面のグリッドからPCC品目設定マスタリストを取得
                pMPCC09040U.GridToPccItem(out pccItemStList, pccItemGrid, i);
                if (pccItemStList != null && pccItemStList.Count > 0)
                {
                    if (pccItemStDict == null)
                    {
                        pccItemStDict = new Dictionary<int, Dictionary<int, PccItemSt>>();
                    }
                    //PCC品目設定ディクショナリーを追加
                    pccItemStDict.Add(i, pccItemStList);
                }

                //画面TABの表示順位
                switch (i)
                {
                    case 1:
                        {
                            pccItemGrid.ItemGroupCode1 = i;
                            //画面TAB1の表示名称
                            pccItemGrid.ItemGroupName1 = eachTab.Text;
                            pccItemGrid.ItemGrpDspOdr1 = i;
                            // --- ADD 2013/05/30 三戸 2013/99/99配信分 SCM障害№10541 --------->>>>>>>>>>>>>>>>>>>>>>>>
                            pccItemGrid.ItemGrpImgCode1 = pMPCC09040U.GetItemGrpImgCode();
                            // --- ADD 2013/05/30 三戸 2013/99/99配信分 SCM障害№10541 ---------<<<<<<<<<<<<<<<<<<<<<<<<
                            break;
                        }
                    case 2:
                        {
                            pccItemGrid.ItemGroupCode2 = i;
                            pccItemGrid.ItemGroupName2 = eachTab.Text;
                            pccItemGrid.ItemGrpDspOdr2 = i;
                            // --- ADD 2013/05/30 三戸 2013/99/99配信分 SCM障害№10541 --------->>>>>>>>>>>>>>>>>>>>>>>>
                            pccItemGrid.ItemGrpImgCode2 = pMPCC09040U.GetItemGrpImgCode();
                            // --- ADD 2013/05/30 三戸 2013/99/99配信分 SCM障害№10541 ---------<<<<<<<<<<<<<<<<<<<<<<<<
                            break;
                        }
                    case 3:
                        {
                            pccItemGrid.ItemGroupCode3 = i;
                            pccItemGrid.ItemGroupName3 = eachTab.Text;
                            pccItemGrid.ItemGrpDspOdr3 = i;
                            // --- ADD 2013/05/30 三戸 2013/99/99配信分 SCM障害№10541 --------->>>>>>>>>>>>>>>>>>>>>>>>
                            pccItemGrid.ItemGrpImgCode3 = pMPCC09040U.GetItemGrpImgCode();
                            // --- ADD 2013/05/30 三戸 2013/99/99配信分 SCM障害№10541 ---------<<<<<<<<<<<<<<<<<<<<<<<<
                            break;
                        }
                    case 4:
                        {
                            pccItemGrid.ItemGroupCode4 = i;
                            pccItemGrid.ItemGroupName4 = eachTab.Text;
                            pccItemGrid.ItemGrpDspOdr4 = i;
                            // --- ADD 2013/05/30 三戸 2013/99/99配信分 SCM障害№10541 --------->>>>>>>>>>>>>>>>>>>>>>>>
                            pccItemGrid.ItemGrpImgCode4 = pMPCC09040U.GetItemGrpImgCode();
                            // --- ADD 2013/05/30 三戸 2013/99/99配信分 SCM障害№10541 ---------<<<<<<<<<<<<<<<<<<<<<<<<
                            break;
                        }
                    case 5:
                        {
                            pccItemGrid.ItemGroupCode5 = i;
                            pccItemGrid.ItemGroupName5 = eachTab.Text;
                            pccItemGrid.ItemGrpDspOdr5 = i;
                            // --- ADD 2013/05/30 三戸 2013/99/99配信分 SCM障害№10541 --------->>>>>>>>>>>>>>>>>>>>>>>>
                            pccItemGrid.ItemGrpImgCode5 = pMPCC09040U.GetItemGrpImgCode();
                            // --- ADD 2013/05/30 三戸 2013/99/99配信分 SCM障害№10541 ---------<<<<<<<<<<<<<<<<<<<<<<<<
                            break;
                        }
                }
                //画面PCC品目グループリストを追加
                if (pccItemGrpDic == null)
                {
                    pccItemGrpDic = new Dictionary<int, PccItemGrp>();
                }
                pccItemGrpDic.Add(pccItemGrp.ItemGroupCode, pccItemGrp);
                i++;
            }
        }

        /// <summary>
        /// PCC品目登録処理
        /// </summary>
        /// <returns>登録結果（true:OK／false:NG）</returns>
        /// <remarks>
        /// <br>Note       : PCC品目登録を行います。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        private bool SaveProc()
        {
            int dummy = 0;
            Control control = null;
            string message = null;
            int pccCompanyCode = 0;
            UltraTab selectedTab = this.UTabControl_StayInfo.Tabs[0];
            PccItemGrid pccItemGrid = null;
            List<PccItemGrp> pccItemGrpList = null;
            Dictionary<int, List<PccItemSt>> pccItemStDict = null;
            if (this.DataIndex >= 0)
            {
                string guid = (string)this.Bind_DataSet.Tables[PCCITEM_TABLE].Rows[this._dataIndex][INQCONDITION_TITLE];
                pccItemGrid = ((PccItemGrid)this._pccItemGrpTable[guid]).Clone();
            }
            else
            {
                pccItemGrid = new PccItemGrid();
                pccItemGrid.InqOtherEpCd = this._inqOtherEpCd;
                pccItemGrid.InqOtherSecCd = this._inqOtherSecCd;
            
            }

            // ログインID重複チェック用変数セット
            if (pccItemGrid != null)
            {
                pccCompanyCode = this.tNedit_CustomerCode.GetInt();
              
            }
            pccItemGrid.PccCompanyCode = pccCompanyCode;
            pccItemGrid.InqOriginalEpCd = this._inqOriginalEpCd.Trim();//@@@@20230303
            pccItemGrid.InqOriginalSecCd = this._inqOriginalSecCd;
            pccItemGrid.InqCondition = this._inqOriginalEpCd.Trim() + this._inqOriginalSecCd.TrimEnd() + this._inqOtherEpCd.TrimEnd() + this._inqOtherSecCd.TrimEnd();//@@@@20230303
            if (!ScreenDataCheck(ref control, ref message, ref selectedTab, pccCompanyCode))
            {
                TMsgDisp.Show(
                    this,								// 親ウィンドウフォーム
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,	// エラーレベル
                    ASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
                    message,							// 表示するメッセージ 
                    0,									// ステータス値
                    MessageBoxButtons.OK);				// 表示するボタン

                this.UTabControl_StayInfo.SelectedTab = selectedTab;
                control.Focus();
                if (control == this.UTabControl_StayInfo)
                {
                    ReButtonProc(0);
                }
                    
                return false;
            }

            //品目グループクラス設定
            DispToPccItemGrp(ref pccItemGrpList, ref pccItemStDict, ref pccItemGrid);
           
            int status = this._pccItemGrpAcs.Write(ref pccItemGrid, ref pccItemGrpList, ref pccItemStDict);
            this.ClearProc();
                        
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        this.Search(ref dummy, 0);
                       
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE:
                    {
                        TMsgDisp.Show(
                            this,								// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,	// エラーレベル
                            ASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
                            ERR_DPR_MSG,						// 表示するメッセージ 
                            status,								// ステータス値
                            MessageBoxButtons.OK);				// 表示するボタン
                        UTabControl_StayInfo.Tabs[0].Selected = true;
                        PMPCC09040UB pMPCC09040UB = (PMPCC09040UB)UTabControl_StayInfo.Tabs[0].Tag;
                        pMPCC09040UB.SetInitFocus(this._startMode);
                        this.tNedit_CustomerCode.Focus();
                        return false;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        ExclusiveTransaction(status, TMsgDisp.OPE_UPDATE, this._pccItemGrpAcs);

                        // PCC品目クラスデータセット展開処理
                        this._pccItemGrpTable.Clear();
                        this.Search(ref dummy, 0);

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

                        return false;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT:
                    {
                        TMsgDisp.Show(
                            this,								  // 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOPDISP,	  // エラーレベル
                            ASSEMBLY_ID,						  // アセンブリＩＤまたはクラスＩＤ
                            this.Text,							  // プログラム名称
                            "SaveProc",							  // 処理名称
                            TMsgDisp.OPE_GET,					  // オペレーション
                            ERR_TIMEOUT_MSG,						  // 表示するメッセージ 
                            status,								  // ステータス値
                            this._pccItemGrpAcs,					  // エラーが発生したオブジェクト
                            MessageBoxButtons.OK,				  // 表示するボタン
                            MessageBoxDefaultButton.Button1);	  // 初期表示ボタン
                        // PCC品目クラスデータセット展開処理
                        this._pccItemGrpTable.Clear();
                        this.Search(ref dummy, 0);

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

                        return false;
                    }
                default:
                    {
                        TMsgDisp.Show(
                            this,								// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOPDISP,	// エラーレベル
                            ASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
                            this.Text,							// プログラム名称
                            "SaveProc",							// 処理名称
                            TMsgDisp.OPE_UPDATE,				// オペレーション
                            ERR_UPDT_MSG,						// 表示するメッセージ 
                            status,								// ステータス値
                            this._pccItemGrpAcs,					// エラーが発生したオブジェクト
                            MessageBoxButtons.OK,				// 表示するボタン
                            MessageBoxDefaultButton.Button1);	// 初期表示ボタン
                        // PCC品目クラスデータセット展開処理
                        this._pccItemGrpTable.Clear();
                        this.Search(ref dummy, 0);

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

                        return false;
                    }
            }
            NewEntryTransaction();
            return true;
        }

        /// <summary>
        /// 画面入力情報不正チェック処理
        /// </summary>
        /// <param name="control">不正対象コントロール</param>
        /// <param name="message">メッセージ</param>
        /// <param name="selectedTab">選択したＴａｂ</param>
        /// <param name="pccCompanyCode">得意先コード</param>
        /// <returns>チェック結果（true:OK／false:NG）</returns>
        /// <remarks>
        /// <br>Note       : 画面入力情報の不正チェックを行います。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        private bool ScreenDataCheck(ref Control control, ref string message, ref UltraTab selectedTab, int pccCompanyCode)
        {


            string pccInqCondition = this._inqOriginalEpCd.Trim() + this._inqOriginalSecCd.TrimEnd() + this._inqOtherEpCd.TrimEnd() + this._inqOtherSecCd.TrimEnd();//@@@@20230303
            if (_pccItemGrpDict != null && _pccItemGrpDict.Count > 0)
            {
                if (this._pccItemGrpDict.ContainsKey(pccInqCondition) && this.Mode_Label.Text.Equals(INSERT_MODE))
                {
                    // 得意先コード
                    control = this.tNedit_CustomerCode;
                    message = this.uLabel_CustomerTitle.Text + "は存在しました。他の値を入力して下さい。";
                    this.tNedit_CustomerCode.Enabled = true;
                    this.UButton_CustomerGuide.Enabled = true;
                    this.tNedit_CustomerCode.SetInt(0);
                    this.uLabel_CustomerTitle.Text = string.Empty;
                    selectedTab = this.UTabControl_StayInfo.Tabs[0];
                    return (false);
                }
            }
            int i = 1;
            foreach (UltraTab eachTab in this.UTabControl_StayInfo.Tabs)
            { 
                if(String.IsNullOrEmpty(eachTab.Text.TrimEnd()))
                {
                    // Tab名
                    control = this.UTabControl_StayInfo;
                    message = "タブ名を入力してください。";
                    selectedTab = eachTab;
                    return (false);
                }
                i++;
            }
            if (string.IsNullOrEmpty(this._inqOriginalSecCd) && tNedit_CustomerCode.GetInt() != 0)
            {
                // 得意先コード
                control = this.tNedit_CustomerCode;
                message = this.uLabel_CustomerTitle.Text + "の得意先企業コードは存在しません。他の値を入力して下さい。";
                this.tNedit_CustomerCode.Enabled = true;
                this.UButton_CustomerGuide.Enabled = true;
                this.tNedit_CustomerCode.SetInt(0);
                this.uLabel_CustomerTitle.Text = string.Empty;
                return (false);
            }
            if (string.IsNullOrEmpty(this._inqOriginalSecCd) && tNedit_CustomerCode.GetInt() != 0)
            {
                // 得意先コード
                control = this.tNedit_CustomerCode;
                message = this.uLabel_CustomerTitle.Text + "の得意先拠点コードは存在しません。他の値を入力して下さい。";
                this.tNedit_CustomerCode.Enabled = true;
                this.UButton_CustomerGuide.Enabled = true;
                this.tNedit_CustomerCode.SetInt(0);
                this.uLabel_CustomerTitle.Text = string.Empty;
                return (false);
            }
            return true;
        }

        /// <summary>
        /// 排他処理
        /// </summary>
        /// <param name="operation">オペレーション</param>
        /// <param name="erObject">エラーオブジェクト</param>
        /// <param name="status">ステータス</param>
        /// <remarks>
        /// <br>Note       : データ更新時の排他処理を行います。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.07.20</br>
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
        /// PCC品目Tab削除
        /// </summary>
        /// <param name="selectedTab">Tab</param>
        /// <remarks>
        /// <br>Note       : PCC品目Tab削除を行います。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        private void DeleteTabProc(UltraTab selectedTab)
        {
            int tabCount = this.UTabControl_StayInfo.Tabs.Count;  
            if (tabCount == 1)
            {
                if (selectedTab != null && selectedTab.Tag != null)
                {
                    PMPCC09040UB pMPCC09040UB = (PMPCC09040UB)selectedTab.Tag;
                    pMPCC09040UB.ClearTable();
                    selectedTab.Text = string.Empty;
                    this._deleteTabButtonTool.SharedProps.Enabled = false;
                }
            }
            else
            {
                UTabControl_StayInfo.Tabs.Remove(selectedTab);
                
            }
            tabCount = this.UTabControl_StayInfo.Tabs.Count;
            //-----ADD by huanghx for #25387 BLパーツオーダー品目設定のチェックボックス制御 on 20110921 ----->>>>>
            // BLコードチェックテプッル取得処理
            this._blCheckedInfoTb = new Hashtable();
            foreach (UltraTab eachTab in this.UTabControl_StayInfo.Tabs)
            {
                PMPCC09040UB pMPCC09040UB = (PMPCC09040UB)eachTab.Tag;
                pMPCC09040UB.BlCheckedInfoTb = this._blCheckedInfoTb;
                pMPCC09040UB.InitBlCheckedTb();
                this._blCheckedInfoTb = pMPCC09040UB.BlCheckedInfoTb;
            }
            //-----ADD by huanghx for #25387 BLパーツオーダー品目設定のチェックボックス制御 on 20110921 -----<<<<<
            if (tabCount >= MAX_TABCOUNT)
            {
                this._newTabButtonTool.SharedProps.Enabled = false;
            }
            else
            {
                this._newTabButtonTool.SharedProps.Enabled = true;
            }
        }

        /// <summary>
        /// PCC品目クリア
        /// </summary>
        /// <remarks>
        /// <br>Note       : PCC品目クリアを行います。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        private void ClearProc()
        {
            tNedit_CustomerCode.SetInt(0);
            UltraTab selectedTab = null;
            uLabel_CustomerName.Text = string.Empty;
            int count = UTabControl_StayInfo.Tabs.Count;
            for (int i = count - 1; i > 0; i--)
            {
                selectedTab = UTabControl_StayInfo.Tabs[i];
                this.DeleteTabProc(selectedTab);
            }
            selectedTab = UTabControl_StayInfo.Tabs[0];
            
            selectedTab.Text = string.Empty;
            //問合せ元企業コード
            _inqOriginalEpCd = string.Empty;
            //問合せ元拠点コード
            _inqOriginalSecCd = string.Empty;
            //前問合せ元企業コード
           _inqOriginalEpCdPre = string.Empty;
            //前問合せ元拠点コード
            _inqOriginalSecCdPre = string.Empty;
            if (selectedTab != null && selectedTab.Tag != null)
            {
                PMPCC09040UB pMPCC09040UB = (PMPCC09040UB)selectedTab.Tag;
                pMPCC09040UB.ClearTable();
                selectedTab.Key = TODELKEY;
                selectedTab.Text = string.Empty;
            }
            this._startMode = (int)StartMode.MODE_NEW;
            // 画面入力許可制御処理
            ScreenInputPermissionControl(this._startMode);
            this.tNedit_CustomerCode.Focus();
            this.Mode_Label.Text = INSERT_MODE;
            _prevCustomerCode = -1;
            _firstCustomerCode = 0;
            //-----ADD by huanghx for #25387 BLパーツオーダー品目設定のチェックボックス制御 on 20110921 ----->>>>>
            // BLコードチェックテプッル取得処理
            this._blCheckedInfoTb = new Hashtable();
            foreach (UltraTab eachTab in this.UTabControl_StayInfo.Tabs)
            {
                PMPCC09040UB pMPCC09040UB = (PMPCC09040UB)eachTab.Tag;
                pMPCC09040UB.BlCheckedInfoTb = this._blCheckedInfoTb;
                pMPCC09040UB.InitBlCheckedTb();
                this._blCheckedInfoTb = pMPCC09040UB.BlCheckedInfoTb;
            }
            //-----ADD by huanghx for #25387 BLパーツオーダー品目設定のチェックボックス制御 on 20110921 -----<<<<<
        }

        /// <summary>
        /// PCC品目物理削除
        /// </summary>
        /// <remarks>
        /// <br>Note       : PCC品目完全削除を行います。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        private void AllDeleteProc()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            // 完全削除確認
            DialogResult result = TMsgDisp.Show(
                this, 								// 親ウィンドウフォーム
                emErrorLevel.ERR_LEVEL_QUESTION, // エラーレベル
                ASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
                "データを削除します。" + "\r\n" +
                "よろしいですか？", 				// 表示するメッセージ
                0, 									// ステータス値
                MessageBoxButtons.YesNo,
                MessageBoxDefaultButton.Button2);	// 表示するボタン

            if (result != DialogResult.Yes)
            {
                return;
            }
            string guid = (string)this.Bind_DataSet.Tables[PCCITEM_TABLE].Rows[this._dataIndex][INQCONDITION_TITLE];
            PccItemGrid pccItemGrid = ((PccItemGrid)this._pccItemGrpTable[guid]).Clone();
            List<PccItemGrp> pccItemGrpList = null;
            Dictionary<int, List<PccItemSt>> pccItemStDict = null;
            if (pccItemGrid != null && this._pccItemGrpDict != null
                && this._pccItemGrpDict.ContainsKey(pccItemGrid.InqCondition))
            {
                pccItemGrpList = this._pccItemGrpDict[pccItemGrid.InqCondition];
            }

            if (pccItemGrid != null && this._pccItemStDictDict != null
                && this._pccItemStDictDict.ContainsKey(pccItemGrid.InqCondition))
            {
                pccItemStDict = this._pccItemStDictDict[pccItemGrid.InqCondition];
            }

            int dummy = 0;
            status = this._pccItemGrpAcs.Delete(ref pccItemGrid, ref pccItemGrpList, ref pccItemStDict);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        if (pccItemGrid != null && this._pccItemGrpDict != null
                            && this._pccItemGrpDict.ContainsKey(pccItemGrid.InqCondition))
                        {
                            this._pccItemGrpDict.Remove(pccItemGrid.InqCondition);
                        }

                        if (pccItemGrid != null && this._pccItemStDictDict != null
                            && this._pccItemStDictDict.ContainsKey(pccItemGrid.InqCondition))
                        {
                            this._pccItemStDictDict.Remove(pccItemGrid.InqCondition);
                        }
                        // DataSet更新
                        this.Bind_DataSet.Tables[PCCITEM_TABLE].Rows[this._dataIndex].Delete();
                        // ハッシュテーブルから削除します
                        if (this._pccItemGrpTable.ContainsKey(pccItemGrid.FileHeaderGuid) == true)
                        {
                            this._pccItemGrpTable.Remove(pccItemGrid.FileHeaderGuid);
                        }
                        this.ClearProc();
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE:
                    {
                        TMsgDisp.Show(
                            this,								// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,	// エラーレベル
                            ASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
                            ERR_DPR_MSG,						// 表示するメッセージ 
                            status,								// ステータス値
                            MessageBoxButtons.OK);				// 表示するボタン
                        this.UTabControl_StayInfo.SelectedTab = this.UTabControl_StayInfo.Tabs[0];
                        UTabControl_StayInfo.Tabs[0].Selected = true;
                        PMPCC09040UB pMPCC09040UB = (PMPCC09040UB)UTabControl_StayInfo.Tabs[0].Tag;
                        pMPCC09040UB.SetInitFocus(this._startMode);
                        this.tNedit_CustomerCode.Focus();
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        ExclusiveTransaction(status, TMsgDisp.OPE_UPDATE, this._pccItemGrpAcs);

                        // PCC品目クラスデータセット展開処理
                        this._pccItemGrpTable.Clear();
                        this.Search(ref dummy, 0);
                       
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT:
                    {
                        TMsgDisp.Show(
                            this,								  // 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOPDISP,	  // エラーレベル
                            ASSEMBLY_ID,						  // アセンブリＩＤまたはクラスＩＤ
                            this.Text,							  // プログラム名称
                            "Delete",							  // 処理名称
                            TMsgDisp.OPE_GET,					  // オペレーション
                            ERR_TIMEOUT_MSG,						  // 表示するメッセージ 
                            status,								  // ステータス値
                            this._pccItemGrpAcs,					  // エラーが発生したオブジェクト
                            MessageBoxButtons.OK,				  // 表示するボタン
                            MessageBoxDefaultButton.Button1);	  // 初期表示ボタン
                        // PCC品目クラスデータセット展開処理
                        this._pccItemGrpTable.Clear();
                        this.Search(ref dummy, 0);

                        break;
                    }
                default:
                    {
                        TMsgDisp.Show(
                            this,								// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOPDISP,	// エラーレベル
                            ASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
                            this.Text,							// プログラム名称
                            "Delete",							// 処理名称
                            TMsgDisp.OPE_UPDATE,				// オペレーション
                            ERR_UPDT_MSG,						// 表示するメッセージ 
                            status,								// ステータス値
                            this._pccItemGrpAcs,					// エラーが発生したオブジェクト
                            MessageBoxButtons.OK,				// 表示するボタン
                            MessageBoxDefaultButton.Button1);	// 初期表示ボタン
                        // PCC品目クラスデータセット展開処理
                        this._pccItemGrpTable.Clear();
                        this.Search(ref dummy, 0);
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
        }

        /// <summary>
        /// PCC品目TAB名変更
        /// </summary>
        /// <param name="newTabFalg">AB名新規FLAF</param>
        /// <remarks>
        /// <br>Note       : PCC品目TAB名変更を行います。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        private void ReButtonProc(int newTabFalg)
        {
            UltraTab selectedTab = UTabControl_StayInfo.SelectedTab;
            
            _pMPCC09040UC = new PMPCC09040UC();
            _pMPCC09040UC.TabName = selectedTab.Text.TrimEnd();
            this._pMPCC09040UC.ShowDialog();
            DialogResult dialogResult = this._pMPCC09040UC.DialogResult;
            if (DialogResult.OK == dialogResult)
            {
                selectedTab.Text = _pMPCC09040UC.TabName;
            }
            else if (DialogResult.No == dialogResult)
            {
                selectedTab.Text = string.Empty;
                PMPCC09040UB pMPCC09040UB = (PMPCC09040UB)selectedTab.Tag;
                pMPCC09040UB.ClearTable();
                //-----ADD by huanghx for #25387 BLパーツオーダー品目設定のチェックボックス制御 on 20110921 ----->>>>>
                // BLコードチェックテプッル取得処理
                this._blCheckedInfoTb = new Hashtable();
                foreach (UltraTab eachTab in this.UTabControl_StayInfo.Tabs)
                {
                    PMPCC09040UB pMPCC09040UBEach = (PMPCC09040UB)eachTab.Tag;
                    pMPCC09040UB.BlCheckedInfoTb = this._blCheckedInfoTb;
                    pMPCC09040UB.InitBlCheckedTb();
                    this._blCheckedInfoTb = pMPCC09040UB.BlCheckedInfoTb;
                }
                //-----ADD by huanghx for #25387 BLパーツオーダー品目設定のチェックボックス制御 on 20110921 -----<<<<<

            }
        }

        /// <summary>
        /// PCC品目完全復活
        /// </summary>
        /// <remarks>
        /// <br>Note       : PCC品目完全復活を行います。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        private void ReviveProc()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            // 復活確認
            DialogResult result = TMsgDisp.Show(
                this, 								// 親ウィンドウフォーム
                emErrorLevel.ERR_LEVEL_QUESTION, // エラーレベル
                ASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
                "現在表示中の品目設定マスタを復活します。" + "\r\n" +
                "よろしいですか？", 				// 表示するメッセージ
                0, 									// ステータス値
                MessageBoxButtons.YesNo,
                MessageBoxDefaultButton.Button2);	// 表示するボタン

            if (result != DialogResult.Yes)
            {
                return;
            }
            string guid = (string)this.Bind_DataSet.Tables[PCCITEM_TABLE].Rows[this._dataIndex][INQCONDITION_TITLE];
            PccItemGrid pccItemGrid = ((PccItemGrid)this._pccItemGrpTable[guid]).Clone();
            List<PccItemGrp> pccItemGrpList = null;
            Dictionary<int, List<PccItemSt>> pccItemStDict = null;
            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }
            if (pccItemGrid != null && this._pccItemGrpDict != null
                && this._pccItemGrpDict.ContainsKey(pccItemGrid.InqCondition))
            {
                pccItemGrpList = this._pccItemGrpDict[pccItemGrid.InqCondition];
            }

            if (pccItemGrid != null && this._pccItemStDictDict != null
                && this._pccItemStDictDict.ContainsKey(pccItemGrid.InqCondition))
            {
                pccItemStDict = this._pccItemStDictDict[pccItemGrid.InqCondition];
            }


            int dummy = 0;
            status = this._pccItemGrpAcs.RevivalLogicalDelete(ref pccItemGrid, ref pccItemGrpList, ref pccItemStDict);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        if (pccItemGrid != null && this._pccItemGrpDict != null
                            && this._pccItemGrpDict.ContainsKey(pccItemGrid.InqCondition))
                        {
                            this._pccItemGrpDict.Remove(pccItemGrid.InqCondition);
                            this._pccItemGrpDict.Add(pccItemGrid.InqCondition, pccItemGrpList);
                        }

                        if (pccItemGrid != null && this._pccItemStDictDict != null
                            && this._pccItemStDictDict.ContainsKey(pccItemGrid.InqCondition))
                        {
                            this._pccItemStDictDict.Remove(pccItemGrid.InqCondition);
                            this._pccItemStDictDict.Add(pccItemGrid.InqCondition, pccItemStDict);
                        }
                        //  データセット展開処理
                        PccItemGridToDataSet(pccItemGrid.Clone(), this._dataIndex);
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        // 排他処理
                        ExclusiveTransaction(status, TMsgDisp.OPE_DELETE, this._pccItemGrpAcs);
                        // クラスデータセット展開処理
                        this._pccItemGrpTable.Clear();
                        this.Search(ref dummy, 0);
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT:
                    {
                        TMsgDisp.Show(
                            this,								  // 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOPDISP,	  // エラーレベル
                            ASSEMBLY_ID,						  // アセンブリＩＤまたはクラスＩＤ
                            this.Text,							  // プログラム名称
                            "ReviveProc",							  // 処理名称
                            TMsgDisp.OPE_GET,					  // オペレーション
                            ERR_TIMEOUT_MSG,						  // 表示するメッセージ 
                            status,								  // ステータス値
                            this._pccItemGrpAcs,					  // エラーが発生したオブジェクト
                            MessageBoxButtons.OK,				  // 表示するボタン
                            MessageBoxDefaultButton.Button1);	  // 初期表示ボタン
                        // PCC品目クラスデータセット展開処理
                        this._pccItemGrpTable.Clear();
                        this.Search(ref dummy, 0);

                        break;
                    }

                default:
                    {
                        TMsgDisp.Show(
                            this,								// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOPDISP,	// エラーレベル
                            ASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
                            this.Text,							// プログラム名称
                            "ReviveProc",							// 処理名称
                            TMsgDisp.OPE_HIDE,					// オペレーション
                            ERR_RDEL_MSG,						// 表示するメッセージ 
                            status,								// ステータス値
                            this._pccItemGrpAcs,					// エラーが発生したオブジェクト
                            MessageBoxButtons.OK,				// 表示するボタン
                            MessageBoxDefaultButton.Button1);	// 初期表示ボタン
                        // クラスデータセット展開処理
                        this._pccItemGrpTable.Clear();
                        this.Search(ref dummy, 0);
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
            this.ClearProc();
        }

        /// <summary>
        /// 新規登録時処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 新規登録時の処理を行います。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011/07/20</br>
        /// </remarks>
        private void NewEntryTransaction()
        {
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
        /// 引用ボタン処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 引用ボタン処理を行います。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        private void QuoteButtonProc()
        {

            _pMPCC09040UD = new PMPCC09040UD(this._pccItemGrpDict);
            string inqCondition = string.Empty;
            int customerCode = 0;
            this._pMPCC09040UD.ShowDialog();
            DialogResult dialogResult = this._pMPCC09040UD.DialogResult;
            if (DialogResult.OK == dialogResult)
            {
                inqCondition = this._pMPCC09040UD.PccInqCondition;
                customerCode = this._pMPCC09040UD.CustomCode;
                int count = UTabControl_StayInfo.Tabs.Count;
                UltraTab selectedTab = null;
                UTabControl_StayInfo.Tabs[0].Selected = true;
                for (int i = count - 1; i > 0; i--)
                {
                    selectedTab = UTabControl_StayInfo.Tabs[i];
                    this.DeleteTabProc(selectedTab);
                }
                List<PccItemGrp> pccItemGrpList = null;
                if(this._pccItemGrpDict != null && this._pccItemGrpDict.ContainsKey(inqCondition))
                {
                    pccItemGrpList = this._pccItemGrpDict[inqCondition];
                }
                Dictionary<int, List<PccItemSt>> pccItemStDict = null;
                if (pccItemGrpList != null)
                {
                    if (this._pccItemStDictDict != null && this._pccItemStDictDict.Count > 0
                        && this._pccItemStDictDict.ContainsKey(inqCondition))
                    {
                        pccItemStDict = this._pccItemStDictDict[inqCondition];
                    }
                    PccItemToScreen(pccItemGrpList, pccItemStDict);
                
                }
                selectedTab = UTabControl_StayInfo.Tabs[0];
                this.DeleteTabProc(selectedTab);
                // 画面入力許可制御処理
                ScreenInputPermissionControl((int)StartMode.MODE_EDIT);
                UTabControl_StayInfo.Tabs[0].Selected = true;
                // ボタン設定
                if (pccItemGrpList.Count == 1)
                {
                    this._deleteTabButtonTool.SharedProps.Enabled = false;
                }
                else
                {
                    this._deleteTabButtonTool.SharedProps.Enabled = true;
                }
                if (pccItemGrpList.Count == MAX_TABCOUNT)
                {
                    this._newTabButtonTool.SharedProps.Enabled = false;
                }
                else
                {
                    this._newTabButtonTool.SharedProps.Enabled = true;
                }
            }
           
        }

        #region 自社設定得意先設定マスタ取得処理
        /// <summary>
        /// 自社設定得意先設定マスタ取得処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 自社設定得意先設定マスタを取得します。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.11</br>
        /// </remarks>
        public void GetCustomerHTable()
        {
            if (this._pccCmpnyStAcs == null)
            {
                _pccCmpnyStAcs = new PccCmpnyStAcs();
            }
            PccCmpnySt parsePccCmpnySt = new PccCmpnySt();
            parsePccCmpnySt.InqOtherEpCd = this._enterpriseCode;
            parsePccCmpnySt.InqOtherSecCd = this._inqOtherSecCd;
            List<PccCmpnySt> pccCmpnyStList = null;
            if (this._customerHTable == null)
            {
                this._customerHTable = new Dictionary<int, PccCmpnySt>();
            }
            else
            {
                this._customerHTable.Clear();
            }
            PccCmpnySt pccCmpnySt0 = new PccCmpnySt();
            pccCmpnySt0.PccCompanyCode = 0;
            pccCmpnySt0.PccCompanyName = CUSTOMEMPTY_BASE;
            pccCmpnySt0.InqOtherEpCd = this._enterpriseCode;
            pccCmpnySt0.InqOtherSecCd = this._inqOtherSecCd;
            pccCmpnySt0.InqOriginalEpCd = string.Empty;
            pccCmpnySt0.InqOriginalSecCd = string.Empty;
            this._customerHTable.Add(pccCmpnySt0.PccCompanyCode, pccCmpnySt0);
            int status = this._pccCmpnyStAcs.Search(out pccCmpnyStList, parsePccCmpnySt, 0, ConstantManagement.LogicalMode.GetData0);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                foreach (PccCmpnySt pccCmpnySt in pccCmpnyStList)
                {
                    if (!this._customerHTable.ContainsKey(pccCmpnySt.PccCompanyCode))
                    {
                        this._customerHTable.Add(pccCmpnySt.PccCompanyCode, pccCmpnySt);
                    }
                }
            }

        }
        #endregion

        #endregion
       
    }
}