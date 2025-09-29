//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 同期状態表示端末設定マスタメンテナンス
// プログラム概要   : 同期状態表示端末設定の登録・変更・削除を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2014 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 劉超
// 作 成 日  2014/08/18  修正内容 : 新規作成
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using System.Net.NetworkInformation;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Controller.Util;
using System.Reflection;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 同期状態表示端末設定マスタメンテナンスフォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 同期状態表示端末設定マスタメンテナンスを行います。</br>
    /// <br>             IMasterMaintenanceMultiTypeを実装しています。</br>
    /// <br>Programmer : 劉超</br> 
    /// <br>Date       : 2014/08/18</br>
    /// <br></br>
    /// </remarks>
    public partial class PMSCM09110UA : System.Windows.Forms.Form, IMasterMaintenanceMultiType
    {
        # region -- Constructor --
        /// <summary>
        /// 同期状態表示端末設定マスタフォームクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note		: 同期状態表示端末設定マスタフォームクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer	: 劉超</br>
        /// <br>Date		: 2014/08/18</br>
        /// </remarks>
        public PMSCM09110UA()
        {
            InitializeComponent();

            // データセット列情報構築処理
            DataSetColumnConstruction();

            // プロパティ初期値設定
            this._canPrint = false;
            this._canClose = false;
            this._canNew = true;
            this._canDelete = true;
            this._defaultAutoFillToColumn = false;
            this._canSpecificationSearch = false;
            this._canLogicalDeleteDataExtraction = true;
 
            //　企業コード取得
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            // 変数初期化
            this._dataIndex = -1;
            this._checkFlag = true;
            this._secInfoAcs = new SecInfoAcs(1);
            this._syncStateDspTermStAcs = new SyncStateDspTermStAcs();
            this._posTerminalMgAcs = new PosTerminalMgAcs();
            this._syncStSetTable = new Hashtable();
            this._posList = new ArrayList();
            // 前回入力値
            this._tmpSectionCode = ALL_SECTIONCODE;
            this._tmpSectionName = ALL_SECTIONNAME;
            this._tmpCashRegisterNo = string.Empty;
            this._tmpMachineName = string.Empty;
            this._tmpMachineIpAddr = string.Empty;

            //_dataIndexバッファ（メインフレーム最小化対応）
            this._indexBuf = -2;

            // 拠点ガイドのフォーカス制御
            _sectionGuideController = new GeneralGuideUIController(
                this.tNEdit_SectionCode,
                this.SectionGuide_Button,
                this.tNedit_CashRegisterNo
            );
            // 端末管理設定取得
            this.GetPosTerminalMgCache();
        }
        # endregion

        # region -- Private Members --
        private SyncStateDspTermStAcs _syncStateDspTermStAcs;
        private SecInfoAcs _secInfoAcs;                     // 拠点マスタアクセスクラス
        private PosTerminalMgAcs _posTerminalMgAcs;  // 端末管理設定アクセスクラス
        private string _enterpriseCode;
        private Hashtable _syncStSetTable;
        private ArrayList _posList;
        // 前回入力値
        private string _tmpSectionCode;
        private string _tmpSectionName;
        private string _tmpCashRegisterNo;
        private string _tmpMachineName;
        private string _tmpMachineIpAddr;
        private bool _checkFlag;

        // 保存比較用Clone
        private SyncStateDspTermStWork _syncStateStClone;

        // 端末管理情報キャッシュ
        private Dictionary<int, PosTerminalMg> _posTerminalMgDic;

        /// <summary>画面デザイン変更クラス</summary>
        private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();

        // プロパティ用
        private bool _canPrint;
        private bool _canLogicalDeleteDataExtraction;
        private bool _canClose;
        private bool _canNew;
        private bool _canDelete;
        private int _dataIndex;
        private bool _defaultAutoFillToColumn;
        private bool _canSpecificationSearch;

        //_dataIndexバッファ（メインフレーム最小化対応）
        private int _indexBuf;

        private const string ASSEMBLY_ID = "PMSCM09110U";

        private const string DELETE_DATE = "削除日";
        private const string VIEW_SECTIONCODE_TITLE = "拠点コード";
        private const string VIEW_SECTION_NAME_TITLE = "拠点名";
        private const string VIEW_CASHREGISTERNO_TITLE = "端末番号";
        private const string VIEW_MACHINE_NAME_TITLE = "端末名";
        private const string VIEW_MACHINEIPADDR_TITLE = "端末IPアドレス";

        // View用Gridに表示させるテーブル名
        private const string VIEW_TABLE = "SyncStateDspTermSt";
        private const string VIEW_GUID_KEY_TITLE = "Guid";
        private const string VIEW_SECTION_CODE_TITLE = "SectionCode";
        // 編集モード
        private const string INSERT_MODE = "新規モード";
        private const string UPDATE_MODE = "更新モード";
        private const string DELETE_MODE = "削除モード";

        private const string ALL_SECTIONCODE = "00";
        private const string ALL_SECTIONNAME = "全社共通";
        /// <summary>拠点ガイドの制御オブジェクト</summary>
        private readonly GeneralGuideUIController _sectionGuideController;
        /// <summary>
        /// 拠点ガイドの制御オブジェクトを取得します。
        /// </summary>
        /// <value>拠点ガイドの制御オブジェクト</value>
        private GeneralGuideUIController SectionGuideController
        {
            get { return _sectionGuideController; }
        }
        # endregion

        # region -- Events --
        /// <summary>画面非表示イベント</summary>
        /// <remarks>画面が非表示状態になった際に発生します。</remarks>
        public event MasterMaintenanceMultiTypeUnDisplayingEventHandler UnDisplaying;
        # endregion

        # region -- Properties --
        /// <summary>印刷可能設定プロパティ</summary>
        /// <value>印刷可能かどうかの設定を取得します。</value>
        public bool CanPrint
        {
            get
            {
                return this._canPrint;
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

        /// <summary>件数指定抽出可能設定プロパティ</summary>
        /// <value>件数指定抽出を可能とするかどうかの設定を取得または設定します。</value>
        public bool CanSpecificationSearch
        {
            get
            {
                return this._canSpecificationSearch;
            }
        }
        # endregion

        # region -- Public Methods --
        /// <summary>
        /// バインドデータセット取得処理
        /// </summary>
        /// <param name="bindDataSet">グリッドリッド用データセット</param>
        /// <param name="tableName">テーブル名称</param>
        /// <remarks>
        /// <br>Note		: フレーム側のグリッドにバインドさせるデータセットを取得します。</br>
        /// <br>Programmer  : 劉超</br>
        /// <br>Date        : 2014/08/18</br>
        /// </remarks>
        public void GetBindDataSet(ref System.Data.DataSet bindDataSet, ref string tableName)
        {
            bindDataSet = this.Bind_DataSet;
            tableName = VIEW_TABLE;
        }

        /// <summary>
        /// データ検索処理
        /// </summary>
        /// <param name="totalCount">全該当件数</param>
        /// <param name="readCount">抽出対象件数</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note		: 先頭から指定件数分のデータを検索し、</br>
        ///	<br>			  抽出結果を展開したDataSetと全該当件数を返します。</br>
        /// <br>Programmer  : 劉超</br>
        /// <br>Date        : 2014/08/18</br>
        /// </remarks>
        public int Search(ref int totalCount, int readCount)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            ArrayList syncStSetList = new ArrayList();

            this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Clear();
            this._syncStSetTable.Clear();

            status = this._syncStateDspTermStAcs.SearchAll(out syncStSetList, this._enterpriseCode);
            switch (status)
            {
                case (int)ConstantManagement.MethodResult.ctFNC_NORMAL:
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    {
                        int index = 0;

                        foreach (SyncStateDspTermStWork syncStateSt in syncStSetList)
                        {
                            // DataSet展開処理
                            SyncStSetToDataSet(syncStateSt, index);
                            ++index;
                        }
                        break;
                    }
                case (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN:
                    {
                        status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                        break;
                    }
                default:
                    {
                        TMsgDisp.Show(this,                         // 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOP,			// エラーレベル
                            ASSEMBLY_ID,							// アセンブリID
                            this.Text,                              // プログラム名称
                            "Search",                               // 処理名称
                            TMsgDisp.OPE_GET,                       // オペレーション
                            "読み込みに失敗しました。",				// 表示するメッセージ
                            status,									// ステータス値
                            this._syncStateDspTermStAcs,					    // エラーが発生したオブジェクト
                            MessageBoxButtons.OK,					// 表示するボタン
                            MessageBoxDefaultButton.Button1);		// 初期表示ボタン

                        break;
                    }
            }
            return status;
        }

        /// <summary>
        /// ネクストデータ検索処理
        /// </summary>
        /// <param name="readCount">抽出対象件数</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note	    : 指定した件数分のネクストデータを検索します。</br>
        /// <br>Programmer  : 劉超</br>
        /// <br>Date        : 2014/03/25</br>
        /// </remarks>
        public int SearchNext(int readCount)
        {
            // 実装なし
            return 0;
        }

        /// <summary>
        /// データ削除処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note        : 選択中のデータを削除します。(未実装)</br>
        /// <br>Programmer  : 劉超</br>
        /// <br>Date        : 2014/08/18</br>
        /// </remarks>
        public int Delete()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            if ((this.DataIndex < 0) ||
                (this.DataIndex >= this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Count))
            {
                return -1;
            }

            // 保持しているデータセットより修正前情報取得
            Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this.DataIndex][VIEW_GUID_KEY_TITLE];
            SyncStateDspTermStWork syncStateSt = ((SyncStateDspTermStWork)this._syncStSetTable[guid]).Clone();

            // 同期状態表示端末設定が存在していない
            if (syncStateSt == null)
            {
                return -1;
            }

            // 全体初期表示設定情報論理削除処理
            status = this._syncStateDspTermStAcs.LogicalDelete(ref syncStateSt);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        SyncStSetToDataSet(syncStateSt.Clone(), this.DataIndex);
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        ExclusiveTransaction(status, true);
                        return status;
                    }
                default:
                    {
                        // 論理削除
                        TMsgDisp.Show(
                            this, 								// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOP, 		// エラーレベル
                            ASSEMBLY_ID, 						// アセンブリＩＤまたはクラスＩＤ
                            this.Text, 				            // プログラム名称
                            "Delete", 							// 処理名称
                            TMsgDisp.OPE_HIDE, 					// オペレーション
                            "削除に失敗しました。", 			// 表示するメッセージ
                            status, 							// ステータス値
                            this._syncStateDspTermStAcs, 				// エラーが発生したオブジェクト
                            MessageBoxButtons.OK, 				// 表示するボタン
                            MessageBoxDefaultButton.Button1);	// 初期表示ボタン
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
        /// <br>Note        : 印刷処理を実行します。(未実装)</br>
        /// <br>Programmer  : 劉超</br>
        /// <br>Date        : 2014/08/18</br>
        /// </remarks>
        public int Print()
        {
            return 0;
        }

        /// <summary>
        /// グリッド列外観情報取得処理
        /// </summary>
        /// <returns>グリッド列外観情報格納Hashtable</returns>
        /// <remarks>
        /// <br>Note        : 各列の外見を設定するクラスを格納したHashtableを取得します。</br>
        /// <br>Programmer  : 劉超</br>
        /// <br>Date        : 2014/08/18</br>
        /// </remarks>
        public Hashtable GetAppearanceTable()
        {
            Hashtable appearanceTable = new Hashtable();

            // 削除日
            appearanceTable.Add(DELETE_DATE, new GridColAppearance(MGridColDispType.DeletionDataBoth, ContentAlignment.MiddleLeft, "", Color.Red));
            // 拠点コード
            appearanceTable.Add(VIEW_SECTIONCODE_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 拠点名
            appearanceTable.Add(VIEW_SECTION_NAME_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 端末番号
            appearanceTable.Add(VIEW_CASHREGISTERNO_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "00#", Color.Black));
            // 端末名
            appearanceTable.Add(VIEW_MACHINE_NAME_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 端末IDアドレス
            appearanceTable.Add(VIEW_MACHINEIPADDR_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));

            appearanceTable.Add(VIEW_GUID_KEY_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));

            return appearanceTable;
        }
        # endregion

        # region -- Private Methods --
        /// <summary>
        /// 同期状態表示端末設定マスタオブジェクトデータセット展開処理
        /// </summary>
        /// <param name="syncStateSt">同期状態表示端末設定マスタオブジェクト</param>
        /// <param name="index">データセットへ展開するインデックス</param>
        /// <remarks>
        /// <br>Note       : 同期状態表示端末設定マスタクラスをデータセットに格納します。</br>
        /// <br>Programmer : 劉超</br>
        /// <br>Date	   : 2014.03.27</br>
        /// </remarks>
        private void SyncStSetToDataSet(SyncStateDspTermStWork syncStateSt, int index)
        {
            if ((index < 0) || (this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Count <= index))
            {
                // 新規と判断して、行を追加する
                DataRow dataRow = this.Bind_DataSet.Tables[VIEW_TABLE].NewRow();
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Add(dataRow);
                // indexを行の最終行番号する
                index = this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Count - 1;
            }

            if (syncStateSt.LogicalDeleteCode == 0)
            {
                // 更新可能状態の時
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][DELETE_DATE] = "";
            }
            else
            {
                // 削除状態の時
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][DELETE_DATE] = syncStateSt.UpdateDateTime;
            }

            // 拠点コード
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SECTIONCODE_TITLE] = syncStateSt.SectionCode.Trim().PadLeft(2, '0');

            // 拠点名称
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SECTION_NAME_TITLE] = GetSectionName(syncStateSt.SectionCode);

            // 端末番号
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CASHREGISTERNO_TITLE] = syncStateSt.CashRegisterNo;

            PosTerminalMg posTerMg = GetPosTerminalMg(syncStateSt.CashRegisterNo);
            if (posTerMg != null && posTerMg.LogicalDeleteCode == 0)
            {
                // 端末名
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_MACHINE_NAME_TITLE] = posTerMg.MachineName;

                // 端末IDアドレス
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_MACHINEIPADDR_TITLE] = posTerMg.MachineIpAddr;
            }
            else
            {
                // 端末名
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_MACHINE_NAME_TITLE] = "";

                // 端末IDアドレス
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_MACHINEIPADDR_TITLE] = "";
            }

            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_GUID_KEY_TITLE] = syncStateSt.FileHeaderGuid;

            if (this._syncStSetTable.ContainsKey(syncStateSt.FileHeaderGuid) == true)
            {
                this._syncStSetTable.Remove(syncStateSt.FileHeaderGuid);
            }
            this._syncStSetTable.Add(syncStateSt.FileHeaderGuid, syncStateSt);
        }

        /// <summary>
        /// データセット列情報構築処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : データセットの列情報を構築します。
        ///					 データセットの列情報がフレームのビュー用グリッドの列になります</br>
        /// <br>Programmer  : 劉超</br>
        /// <br>Date        : 2014/08/18</br>
        /// </remarks>
        private void DataSetColumnConstruction()
        {
            DataTable syncStSetTable = new DataTable(VIEW_TABLE);

            // 削除日
            syncStSetTable.Columns.Add(DELETE_DATE, typeof(string));
            syncStSetTable.Columns.Add(VIEW_SECTIONCODE_TITLE, typeof(string));
            syncStSetTable.Columns.Add(VIEW_SECTION_NAME_TITLE, typeof(string));
            syncStSetTable.Columns.Add(VIEW_CASHREGISTERNO_TITLE, typeof(int));
            syncStSetTable.Columns.Add(VIEW_MACHINE_NAME_TITLE, typeof(string));
            syncStSetTable.Columns.Add(VIEW_MACHINEIPADDR_TITLE, typeof(string));
            syncStSetTable.Columns.Add(VIEW_GUID_KEY_TITLE, typeof(Guid)); 

            this.Bind_DataSet.Tables.Add(syncStSetTable);
        }

        /// <summary>
        /// 画面初期設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面の初期設定を行います。</br>
        /// <br>Programmer  : 劉超</br>
        /// <br>Date        : 2014/08/18</br>
        /// </remarks>
        private void ScreenInitialSetting()
        {
            // 新規の場合
            if (this.DataIndex < 0)
            {
                ScreenInputPermissionControl(INSERT_MODE);                        // 画面入力許可制御
            }
            else
            {
                // 削除の場合
                if ((string)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this._dataIndex][DELETE_DATE] != "")
                {
                    ScreenInputPermissionControl(DELETE_MODE);                        // 画面入力許可制御
                }
                // 更新の場合
                else
                {
                    ScreenInputPermissionControl(UPDATE_MODE);                        // 画面入力許可制御
                }
            }

        }

        /// <summary>
        /// 画面クリア処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : 画面をクリアします。</br>
        /// <br>Programmer  : 劉超</br>
        /// <br>Date        : 2014/08/18</br>
        /// </remarks>
        private void ScreenClear()
        {
            this.tEdit_SectionName.Text = string.Empty;
            this.tNEdit_SectionCode.Text = string.Empty;
            this.tNedit_CashRegisterNo.Text = string.Empty;
            this.tEdit_MachineName.Text = string.Empty;
            this.tEdit_MachineIpAddr.Text = string.Empty;
            this._tmpCashRegisterNo = string.Empty;
            this._tmpMachineName = string.Empty;
            this._tmpMachineIpAddr = string.Empty;
        }

        /// <summary>
        /// 同期状態表示端末設定マスタクラス画面展開処理
        /// </summary>
        /// <param name="syncStateSt">同期状態表示端末設定マスタオブジェクト</param>
        /// <remarks>
        /// <br>Note        : 同期状態表示端末設定マスタオブジェクトから画面にデータを展開します。</br>
        /// <br>Programmer  : 劉超</br>
        /// <br>Date        : 2014/08/18</br>
        /// </remarks>
        private void SyncStSetToScreen(SyncStateDspTermStWork syncStateSt)
        {
            // 拠点コード
            this.tNEdit_SectionCode.Text = syncStateSt.SectionCode.TrimEnd();
            // 拠点名
            this.tEdit_SectionName.Text = this.GetSectionName(syncStateSt.SectionCode);
            // 端末番号
            this.tNedit_CashRegisterNo.SetInt(syncStateSt.CashRegisterNo);
            PosTerminalMg posTerminalMg = GetPosTerminalMg(syncStateSt.CashRegisterNo);
            if (posTerminalMg == null)
            {
                // 端末名
                this.tEdit_MachineName.Text = "";
                // 端末IDアドレス
                this.tEdit_MachineIpAddr.Text = "";
            }
            else
            {
                // 端末名
                this.tEdit_MachineName.Text = posTerminalMg.MachineName;
                // 端末IDアドレス
                this.tEdit_MachineIpAddr.Text = posTerminalMg.MachineIpAddr;
            }
        }

        /// <summary>
        /// 画面情報同期状態表示端末設定マスタクラス格納処理
        /// </summary>
        /// <param name="syncStateSt">同期状態表示端末設定マスタオブジェクト</param>
        /// <remarks>
        /// <br>Note        : 画面情報から同期状態表示端末設定マスタオブジェクトにデータを格納します。</br>
        /// <br>Programmer  : 劉超</br>
        /// <br>Date        : 2014/08/18</br>
        /// </remarks>
        private void ScreenToSyncStSet(ref SyncStateDspTermStWork syncStateSt)
        {
            if (syncStateSt == null)
            {
                // 新規の場合
                syncStateSt = new SyncStateDspTermStWork();
            }
            // 企業コード
            syncStateSt.EnterpriseCode = this._enterpriseCode;

            // 拠点コード
            syncStateSt.SectionCode = this.tNEdit_SectionCode.Text;

            // 端末番号
            if (this.tNedit_CashRegisterNo.GetInt() != 0)
            {
                syncStateSt.CashRegisterNo = Convert.ToInt32(this.tNedit_CashRegisterNo.Value);
            }
        }

        /// <summary>
        /// 画面再構築処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : モードに基づいて画面の再構築を行います。</br>
        /// <br>Programmer  : 劉超</br>
        /// <br>Date        : 2014/08/18</br>
        /// </remarks>
        private void ScreenReconstruction()
        {
            if (this.DataIndex < 0)
            {
                SyncStateDspTermStWork syncStateSt = new SyncStateDspTermStWork();
                // 全体初期表示情報クラス画面展開処理
                SyncStSetToScreen(syncStateSt);
                //クローン作成
                this._syncStateStClone = syncStateSt.Clone();
                this._indexBuf = this._dataIndex;

                //// 画面情報を比較用クローンにコピーします
                ScreenToSyncStSet(ref this._syncStateStClone);

                // 新規モード
                this.Mode_Label.Text = INSERT_MODE;

                // 画面入力許可制御処理
                ScreenInputPermissionControl(INSERT_MODE);

                //// フォーカス設定
                this.tNEdit_SectionCode.Focus();
            }
            else
            {
                // 保持しているデータセットより修正前情報取得
                Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this.DataIndex][VIEW_GUID_KEY_TITLE];
                SyncStateDspTermStWork syncStateSt = (SyncStateDspTermStWork)this._syncStSetTable[guid];

                // 全体初期表示情報クラス画面展開処理
                SyncStSetToScreen(syncStateSt);

                if (syncStateSt.LogicalDeleteCode == 0)
                {
                    // 更新可能状態の時
                    this.Mode_Label.Text = UPDATE_MODE;

                    // 画面入力許可制御処理
                    ScreenInputPermissionControl(UPDATE_MODE);

                    // フォーカス設定
                    this.Cancel_Button.Focus();

                    // クローン作成
                    this._syncStateStClone = syncStateSt.Clone();

                    // 画面情報を比較用クローンにコピーします　   
                    ScreenToSyncStSet(ref this._syncStateStClone);
                }
                else
                {
                    // 削除状態の時
                    this.Mode_Label.Text = DELETE_MODE;

                    // 画面入力許可制御処理
                    ScreenInputPermissionControl(DELETE_MODE);

                    // フォーカス設定
                    this.Delete_Button.Focus();
                }

                this._indexBuf = this._dataIndex;
            }
        }

        /// <summary>
        /// 画面入力許可制御処理
        /// </summary>
        /// <param name="mode">モード(新規・更新・削除)</param>
        /// <remarks>
        /// <br>Note        : 画面の入力許可を制御します。</br>
        /// <br>Programmer  : 劉超</br>
        /// <br>Date        : 2014/08/18</br>
        /// </remarks>
        private void ScreenInputPermissionControl(string mode)
        {
            switch (mode)
            {
                case INSERT_MODE:
                    // ボタン
                    this.Save_Button.Visible = true;
                    this.Cancel_Button.Visible = true;
                    this.Renewal_Button.Visible = true;
                    this.Delete_Button.Visible = false;
                    this.Revive_Button.Visible = false;

                    // 入力項目
                    this.tNEdit_SectionCode.Enabled = true;
                    this.SectionGuide_Button.Enabled = true;
                    this.tNedit_CashRegisterNo.Enabled = true;
                    this.tEdit_MachineIpAddr.Enabled = false;

                    this.comment_label.Visible = true;
                    break;
                case UPDATE_MODE:
                    // ボタン
                    this.Save_Button.Visible = false;
                    this.Cancel_Button.Visible = true;
                    this.Renewal_Button.Visible = false;
                    this.Delete_Button.Visible = false;
                    this.Revive_Button.Visible = false;

                    // 入力項目
                    this.tNEdit_SectionCode.Enabled = false;
                    this.SectionGuide_Button.Enabled = false;
                    this.tNedit_CashRegisterNo.Enabled = false;
                    this.tEdit_MachineIpAddr.Enabled = false;

                    this.comment_label.Visible = false;
                    break;
                case DELETE_MODE:
                    // ボタン
                    this.Save_Button.Visible = false;
                    this.Cancel_Button.Visible = true;
                    this.Renewal_Button.Visible = false;
                    this.Delete_Button.Visible = true;
                    this.Revive_Button.Visible = true;

                    // 入力項目
                    this.tNEdit_SectionCode.Enabled = false;
                    this.SectionGuide_Button.Enabled = false;
                    this.tNedit_CashRegisterNo.Enabled = false;
                    this.tEdit_MachineIpAddr.Enabled = false;

                    this.comment_label.Visible = false;
                    break;
            }
        }

        /// <summary>
        /// 排他処理
        /// </summary>
        /// <param name="status">ステータス</param>
        /// <param name="hide">非表示フラグ(true: 非表示にする, false: 非表示にしない)</param>
        /// <remarks>
        /// <br>Note        : データ更新時の排他処理を行います。</br>
        /// <br>Programmer  : 劉超</br>
        /// <br>Date        : 2014/08/18</br>
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
                            "既に他端末より更新されています。", // 表示するメッセージ
                            0, 									// ステータス値
                            MessageBoxButtons.OK);				// 表示するボタン
                        if (hide == true)
                        {
                            CloseForm(DialogResult.Cancel);
                        }
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        // 他端末削除
                        TMsgDisp.Show(
                            this, 								// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
                            ASSEMBLY_ID, 						// アセンブリＩＤまたはクラスＩＤ
                            "既に他端末より削除されています。", // 表示するメッセージ
                            0, 									// ステータス値
                            MessageBoxButtons.OK);				// 表示するボタン
                        if (hide == true)
                        {
                            CloseForm(DialogResult.Cancel);
                        }
                        break;
                    }
            }
        }

        /// <summary>
        ///　保存処理(SaveSyncStSet())
        /// </summary>
        /// <remarks>
        /// <br>Note　　　  : 保存処理を行います。</br>
        /// <br>Programmer  : 劉超</br>
        /// <br>Date        : 2014/08/18</br>
        /// </remarks>
        private bool SaveSyncStSet()
        {
            bool result = false;
            // 入力チェック
            Control control = null;
            if (!ScreenDataCheck(ref control))
            {
                control.Focus();
                if (control is TNedit)
                {
                    ((TNedit)control).SelectAll();
                }
                else if (control is TEdit)
                {
                    ((TEdit)control).SelectAll();
                }
                return result;
            }

            SyncStateDspTermStWork syncStateSt = null;

            if (this.DataIndex >= 0)
            {
                Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this._dataIndex][VIEW_GUID_KEY_TITLE];
                syncStateSt = ((SyncStateDspTermStWork)this._syncStSetTable[guid]).Clone();
            }

            ScreenToSyncStSet(ref syncStateSt);

            // 端末番号が存在していない場合、登録しない。
            PosTerminalMg posTerminalMg = GetPosTerminalMg(tNedit_CashRegisterNo.GetInt());
            if ((posTerminalMg != null) &&
                (posTerminalMg.LogicalDeleteCode == 0))
            { }
            else
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                    this.Name,
                    "該当する端末番号が存在しません。",
                    -1,
                    MessageBoxButtons.OK);

                tNedit_CashRegisterNo.Text = _tmpCashRegisterNo;
                tEdit_MachineName.Text = _tmpMachineName;
                tEdit_MachineIpAddr.Text = _tmpMachineIpAddr;
                _tmpCashRegisterNo = tNedit_CashRegisterNo.Text;
                tNedit_CashRegisterNo.Focus();
                return false;
            }

            int status = this._syncStateDspTermStAcs.Write(ref syncStateSt);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        this.ScreenClear();
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE:
                    {
                        // コード重複
                        TMsgDisp.Show(
                            this, 									// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_EXCLAMATION, 			// エラーレベル
                            ASSEMBLY_ID, 						    // アセンブリＩＤまたはクラスＩＤ
                            "このコードは既に使用されています。", 	// 表示するメッセージ
                            0, 										// ステータス値
                            MessageBoxButtons.OK);					// 表示するボタン
                        this.tNEdit_SectionCode.Text = _tmpSectionCode;
                        this.tNEdit_SectionCode.Focus();
                        return false;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        ExclusiveTransaction(status, true);


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
                        TMsgDisp.Show(this,                         // 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOP,			// エラーレベル
                            ASSEMBLY_ID,							// アセンブリID
                            this.Text,  　　                        // プログラム名称
                            "SaveSyncStSet",                        // 処理名称
                            TMsgDisp.OPE_UPDATE,                    // オペレーション
                            "保存に失敗しました。",				    // 表示するメッセージ
                            status,									// ステータス値
                            this._syncStateDspTermStAcs,				    	// エラーが発生したオブジェクト
                            MessageBoxButtons.OK,			  		// 表示するボタン
                            MessageBoxDefaultButton.Button1);		// 初期表示ボタン

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

            this.SyncStSetToDataSet(syncStateSt, this.DataIndex);

            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }
            this.DialogResult = DialogResult.OK;
            this._indexBuf = -2;

            // 新規登録時
            if (this.Mode_Label.Text.Equals(INSERT_MODE))
            {
                if (CanClose == true)
                {
                    this.Close();
                }
                else
                {
                    this.Hide();
                }
            }

            result = true;

            return result;
        }

        /// <summary>
        /// フォームクローズ処理
        /// </summary>
        /// <param name="dialogResult">ダイアログ結果</param>
        /// <remarks>
        /// <br>Note       : フォームを閉じます。その際画面クローズイベント等の発生を行います。</br>
        /// <br></br>
        /// </remarks>
        private void CloseForm(DialogResult dialogResult)
        {
            // 画面非表示イベント
            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(dialogResult);
                UnDisplaying(this, me);
            }

            this.DialogResult = dialogResult;

            // _GridIndexバッファ初期化（メインフレーム最小化対応）
            this._indexBuf = -2;

            // 比較用クローンクリア
            this._syncStateStClone = null;

            // フォームを非表示化する。
            if (this._canClose == true)
            {
                this.Close();
            }
            else
            {
                this.Hide();
            }
        }

        /// <summary>
        /// 拠点コードが存在するか判定します。
        /// </summary>
        /// <returns><c>true</c> :存在する。<br/><c>false</c>:存在しない。</returns>
        /// <remarks>
        /// <br>Note        : 拠点コードが存在するか判定します。</br>
        /// <br>Programmer  : 劉超</br>
        /// <br>Date        : 2014/08/18</br>
        /// </remarks>
        private bool ExistsCode()
        {
            // 全社共通は拠点マスタに登録されていないため、チェックの対象外
            if (SectionUtil.IsAllSection(this.tNEdit_SectionCode.Text))
            {
                return true;
            }

            bool existsSectionCode = SectionUtil.ExistsCode(this.tNEdit_SectionCode.Text);
            if (!existsSectionCode)
            {
                this.tNEdit_SectionCode.Focus();
            }
            return existsSectionCode;
        }

        /// <summary>
        /// 画面入力情報不正チェック処理
        /// </summary>
        /// <param name="control">不正対象コントロール</param>
        /// <returns>チェック結果(true:OK／false:NG)</returns>
        /// <remarks>
        /// <br>Note       : 画面入力の不正チェックを行います。</br>
        /// <br></br>
        /// </remarks>
        private bool ScreenDataCheck(ref Control control)
        {
            // 拠点コードが存在していない場合、登録しない。
            if (!ExistsCode())
            {
                TMsgDisp.Show(
                    this, 								                    // 親ウィンドウフォーム
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,                     // エラーレベル
                    AssemblyUtil.GetName(Assembly.GetExecutingAssembly()),  // アセンブリＩＤまたはクラスＩＤ
                    this.Text, 		                                        // プログラム名称
                    MethodBase.GetCurrentMethod().Name, 					// 処理名称
                    TMsgDisp.OPE_UPDATE, 				                    // オペレーション
                    "拠点コードが存在しません。",                           // LITERAL:表示するメッセージ
                    (int)ConstantManagement.MethodResult.ctFNC_NORMAL, 		// ステータス値
                    this,			                                        // エラーが発生したオブジェクト
                    MessageBoxButtons.OK, 				                    // 表示するボタン
                    MessageBoxDefaultButton.Button1                         // 初期表示ボタン
                );
                this.tNEdit_SectionCode.Text = _tmpSectionCode;
                this.tEdit_SectionName.Text = _tmpSectionName;
                control = this.tNEdit_SectionCode;
                return false;
            }

            // 端末番号マスタチェック
            if (string.IsNullOrEmpty(this.tNedit_CashRegisterNo.Text))
            {
                TMsgDisp.Show(
                    this, 								                    // 親ウィンドウフォーム
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,                     // エラーレベル
                    AssemblyUtil.GetName(Assembly.GetExecutingAssembly()),  // アセンブリＩＤまたはクラスＩＤ
                    this.Text, 		                                        // プログラム名称
                    MethodBase.GetCurrentMethod().Name, 					// 処理名称
                    TMsgDisp.OPE_UPDATE, 				                    // オペレーション
                    "端末番号を設定して下さい。",                           // LITERAL:表示するメッセージ
                    (int)ConstantManagement.MethodResult.ctFNC_NORMAL, 		// ステータス値
                    this,			                                        // エラーが発生したオブジェクト
                    MessageBoxButtons.OK, 				                    // 表示するボタン
                    MessageBoxDefaultButton.Button1                         // 初期表示ボタン
                );
                control = this.tNedit_CashRegisterNo;
                return false;
            }

            return true;
        }

        /// <summary>
        /// 拠点名称取得処理
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <returns>拠点名称</returns>
        /// <remarks>
        /// <br>Note        : 拠点名称を取得します。</br>
        /// <br>Programmer  : 劉超</br>
        /// <br>Date        : 2014/08/18</br>
        /// </remarks>
        private string GetSectionName(string sectionCode)
        {
            string sectionName = string.Empty;

            if (sectionCode.Trim().PadLeft(2, '0') == ALL_SECTIONCODE)
            {
                this.tNEdit_SectionCode.Text = ALL_SECTIONCODE;
                sectionName = ALL_SECTIONNAME;
                return sectionName;
            }

            try
            {
                foreach (SecInfoSet secInfoSet in this._secInfoAcs.SecInfoSetList)
                {
                    if (secInfoSet.SectionCode.Trim() == sectionCode.Trim().PadLeft(2, '0'))
                    {
                        sectionName = secInfoSet.SectionGuideNm.Trim();
                        return sectionName;
                    }
                }
            }
            catch
            {
                sectionName = string.Empty;
            }

            return sectionName;
        }

        /// <summary>
        /// 端末管理設定のローカルキャッシュ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 端末管理設定のローカルキャッシュを作成します。</br>
        /// <br></br>
        /// </remarks>
        private void GetPosTerminalMgCache()
        {
            int status;
            ArrayList retList;

            // 端末管理設定のローカルキャッシュをクリア
            _posTerminalMgDic = new Dictionary<int, PosTerminalMg>();

            // 端末管理設定の取得
            status = this._posTerminalMgAcs.SearchServer(out retList, LoginInfoAcquisition.EnterpriseCode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                foreach (PosTerminalMg wkPosTerminalMg in retList)
                {
                    if (wkPosTerminalMg.LogicalDeleteCode == 0)
                    {
                        int key = wkPosTerminalMg.CashRegisterNo;
                        if (_posTerminalMgDic.ContainsKey(key))
                        {
                            // 既にキャッシュに存在している場合は削除
                            _posTerminalMgDic.Remove(key);
                        }
                        _posTerminalMgDic.Add(key, wkPosTerminalMg);
                    }
                }
            }
        }

        /// <summary>
        /// 端末管理設定を取得します。
        /// </summary>
        /// <param name="cashRegisterNo">端末番号</param>
        /// <returns>端末管理設定データクラス</returns>
        /// <remarks>
        /// <br>Note       : 端末番号から端末管理設定データクラスを取得します。</br>
        /// <br></br>
        /// </remarks>
        private PosTerminalMg GetPosTerminalMg(int cashRegisterNo)
        {
            PosTerminalMg posTerminalMg = null;

            if (_posTerminalMgDic.ContainsKey(cashRegisterNo))
            {
                posTerminalMg = _posTerminalMgDic[cashRegisterNo];
            }

            return posTerminalMg;
        }
        # endregion

        # region -- Control Events --
        /// <summary>
        ///	Form.Load イベント(PMSCM09110UA)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: ユーザーがフォームを読み込むときに発生します。</br>
        /// <br>Programmer : 劉超</br>
        /// <br>Date       : 2014/08/18</br>
        /// </remarks>
        private void PMSCM09110UA_Load(object sender, EventArgs e)
        {
            // 画面スキンファイルの読込(デフォルトスキン指定)
            this._controlScreenSkin.LoadSkin();

            // 画面スキン変更
            this._controlScreenSkin.SettingScreenSkin(this);

            // アイコンリソース管理クラスを使用して、アイコンを表示する
            ImageList imageList24 = IconResourceManagement.ImageList24;
            ImageList imageList16 = IconResourceManagement.ImageList16;

            this.Delete_Button.ImageList = imageList24;
            this.Revive_Button.ImageList = imageList24;
            this.Renewal_Button.ImageList = imageList16;
            this.Save_Button.ImageList = imageList24;
            this.Cancel_Button.ImageList = imageList24;

            this.Delete_Button.Appearance.Image = Size24_Index.DELETE;
            this.Revive_Button.Appearance.Image = Size24_Index.REVIVAL;
            this.Renewal_Button.Appearance.Image = Size16_Index.RENEWAL;
            this.Save_Button.Appearance.Image = Size24_Index.SAVE;
            this.Cancel_Button.Appearance.Image = Size24_Index.CLOSE;

            this.SectionGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];

            // 画面初期設定処理
            ScreenInitialSetting();

            // 拠点ガイドのフォーカス制御の開始
            SectionGuideController.StartControl();
        }

        /// <summary>
        /// Control.Click イベント(SectionGuide_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　 : 拠点ガイドボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer : 劉超</br>
        /// <br>Date       : 2014/08/18</br>
        /// </remarks>
        private void SectionGuide_Button_Click(object sender, EventArgs e)
        {
            SecInfoSetAcs secInfoSetAcs = new SecInfoSetAcs();
            SecInfoSet secInfoSet = new SecInfoSet();
            try
            {
                this.Cursor = Cursors.WaitCursor;

                int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

                status = secInfoSetAcs.ExecuteGuid(this._enterpriseCode, false, out secInfoSet);
                if (status == 0)
                {
                    this.tNEdit_SectionCode.DataText = secInfoSet.SectionCode.Trim();
                    this._tmpSectionCode = secInfoSet.SectionCode.Trim();
                    this.tEdit_SectionName.DataText = secInfoSet.SectionGuideNm.Trim();
                    this._tmpSectionName = secInfoSet.SectionGuideNm.Trim();
                }
                else
                {
                    ((Control)sender).Tag = GeneralGuideUIController.CAN_FOCUS;
                    return;
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Control.Click イベント(Delete_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　 : 完全削除ボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer : 劉超</br>
        /// <br>Date       : 2014/08/18</br>
        /// </remarks>
        private void Delete_Button_Click(object sender, EventArgs e)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            // 完全削除確認
            DialogResult result = TMsgDisp.Show(
                this, 								// 親ウィンドウフォーム
                emErrorLevel.ERR_LEVEL_QUESTION,    // エラーレベル
                ASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
                "データを削除します。" + "\r\n" +
                "よろしいですか？", 				// 表示するメッセージ
                0, 									// ステータス値
                MessageBoxButtons.OKCancel,
                MessageBoxDefaultButton.Button2);	// 表示するボタン

            if (result != DialogResult.OK)
            {
                this.Delete_Button.Focus();
                return;
            }

            // 保持しているデータセットより情報取得
            Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this.DataIndex][VIEW_GUID_KEY_TITLE];
            SyncStateDspTermStWork syncStateSt = (SyncStateDspTermStWork)this._syncStSetTable[guid];

            // 拠点情報論理削除処理
            status = this._syncStateDspTermStAcs.Delete(syncStateSt);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this.DataIndex].Delete();
                        this._syncStSetTable.Remove(syncStateSt.FileHeaderGuid);

                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        ExclusiveTransaction(status, true);

                        if (CanClose == true)
                        {
                            this.Close();
                        }
                        else
                        {
                            this.Hide();
                        }

                        return;
                    }
                default:
                    {
                        // 物理削除
                        TMsgDisp.Show(
                            this, 								// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOP, 		// エラーレベル
                            ASSEMBLY_ID, 						// アセンブリＩＤまたはクラスＩＤ
                            this.Text, 				            // プログラム名称
                            "Delete_Button_Click", 				// 処理名称
                            TMsgDisp.OPE_DELETE, 				// オペレーション
                            "削除に失敗しました。", 			// 表示するメッセージ
                            status, 							// ステータス値
                            this._syncStateDspTermStAcs, 				// エラーが発生したオブジェクト
                            MessageBoxButtons.OK, 				// 表示するボタン
                            MessageBoxDefaultButton.Button1);	// 初期表示ボタン

                        if (CanClose == true)
                        {
                            this.Close();
                        }
                        else
                        {
                            this.Hide();
                        }

                        return;
                    }
            }

            // 画面非表示イベント
            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }

            this.DialogResult = DialogResult.OK;

            this._indexBuf = -2;

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
        /// Control.Click イベント(Save_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　  : 保存ボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer  : 劉超</br>
        /// <br>Date        : 2014/08/18</br>
        /// </remarks>
        private void Save_Button_Click(object sender, EventArgs e)
        {
            if (!_checkFlag)
            {
                _checkFlag = true;
                return;
            }

            if (!SaveSyncStSet())
            {
                return;
            }
        }

        /// <summary>
        /// Control.Click イベント(Revive_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　 : 復活ボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer : 劉超</br>
        /// <br>Date       : 2014/08/18</br>
        /// </remarks>
        private void Revive_Button_Click(object sender, EventArgs e)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            Guid guid;

            // 復活対象データ取得
            guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this._dataIndex][VIEW_GUID_KEY_TITLE];
            SyncStateDspTermStWork syncStateSt = ((SyncStateDspTermStWork)this._syncStSetTable[guid]).Clone();


            //  同期状態表示端末設定マスタ論理削除復活処理
            status = this._syncStateDspTermStAcs.Revival(ref syncStateSt);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // DataSet展開処理
                        SyncStSetToDataSet(syncStateSt, this._dataIndex);
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        // 排他処理
                        ExclusiveTransaction(status, true);

                        if (CanClose == true)
                        {
                            this.Close();
                        }
                        else
                        {
                            this.Hide();
                        }

                        return;
                    }
                default:
                    {
                        TMsgDisp.Show(
                            this,								// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOPDISP,    // エラーレベル
                            ASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
                            this.Text,							// プログラム名称
                            "ReviveWarehouse",				    // 処理名称
                            TMsgDisp.OPE_UPDATE,				// オペレーション
                            "復活に失敗しました。",			    // 表示するメッセージ 
                            status,								// ステータス値
                            this._syncStateDspTermStAcs,					// エラーが発生したオブジェクト
                            MessageBoxButtons.OK,				// 表示するボタン
                            MessageBoxDefaultButton.Button1);	// 初期表示ボタン

                        if (CanClose == true)
                        {
                            this.Close();
                        }
                        else
                        {
                            this.Hide();
                        }

                        return;
                    }
            }

            // 画面非表示イベント
            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }

            this.DialogResult = DialogResult.OK;

            this._indexBuf = -2;

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
        /// 最新情報ボタンクリック
        /// </summary>
        private void Renewal_Button_Click(object sender, EventArgs e)
        {
            this._secInfoAcs.ResetSectionInfo();
            this.GetPosTerminalMgCache();

            TMsgDisp.Show(this, 								// 親ウィンドウフォーム
                          emErrorLevel.ERR_LEVEL_INFO,          // エラーレベル
                          ASSEMBLY_ID,						    // アセンブリＩＤまたはクラスＩＤ
                          "最新情報を取得しました。", 			// 表示するメッセージ
                          0, 									// ステータス値
                          MessageBoxButtons.OK);				// 表示するボタン
            
        }

        /// <summary>
        /// Control.Click イベント(Cancel_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　  : 閉じるボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer  : 劉超</br>
        /// <br>Date        : 2014/08/18</br>
        /// </remarks>
        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            // 削除モード・参照モード以外の場合は保存確認処理を行う
            if (this.Mode_Label.Text != DELETE_MODE)
            {
                // 画面のデータを取得する
                SyncStateDspTermStWork compareSyncStSet = new SyncStateDspTermStWork();

                compareSyncStSet = this._syncStateStClone.Clone();
                ScreenToSyncStSet(ref compareSyncStSet);

                // 画面情報と起動時のクローンと比較し変更を監視する
                if ((!(this._syncStateStClone.Equals(compareSyncStSet))))
                {
                    // 画面情報が変更されていた場合は、保存確認メッセージを表示
                    DialogResult res = TMsgDisp.Show(this,                    // 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_SAVECONFIRM,                   // エラーレベル
                        ASSEMBLY_ID, 			                              // アセンブリＩＤまたはクラスＩＤ
                        null, 					                              // 表示するメッセージ
                        0, 					                                  // ステータス値
                        MessageBoxButtons.YesNoCancel);	                      // 表示するボタン

                    switch (res)
                    {
                        case DialogResult.Yes:
                            {
                                SaveSyncStSet();

                                return;
                            }

                        case DialogResult.No:
                            {
                                // 画面非表示イベント
                                if (UnDisplaying != null)
                                {
                                    MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.Cancel);
                                    UnDisplaying(this, me);
                                }

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
            this.DialogResult = DialogResult.Cancel;
            this._indexBuf = -2;
            this._tmpSectionCode = ALL_SECTIONCODE;
            this._tmpCashRegisterNo = string.Empty;

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
        /// ChangeFocus イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note　　　  : フォーカスローストときに発生します。</br>
        /// <br>Programmer  : 劉超</br>
        /// <br>Date        : 2014/08/18</br>
        /// </remarks>
        private void tRetKeyControl_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null)
            {
                return;
            }

            switch (e.PrevCtrl.Name)
            {
                case "tNedit_CashRegisterNo":
                    {
                        if (this.DataIndex < 0)
                        {
                            if (ModeChangeProc())
                            {
                                e.NextCtrl = this.tNedit_CashRegisterNo;
                            }
                        }
                        break;
                    }
                case "tNEdit_SectionCode":
                    if (e.Key == Keys.Right)
                    {
                        e.NextCtrl = this.SectionGuide_Button;
                        break;
                    }
                    else
                    {
                        if (this.DataIndex < 0)
                        {
                            if (ModeChangeProc())
                            {
                                e.NextCtrl = this.tNEdit_SectionCode;
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
            string msg = "入力されたコードの同期状態表示端末設定情報が既に登録されています。\n編集を行いますか？";

            // 拠点コード
            string sectionCd = this.tNEdit_SectionCode.Text.TrimEnd().PadLeft(2, '0');
            // 端末番号
            int cashRegisterNo = this.tNedit_CashRegisterNo.GetInt();

            for (int i = 0; i < this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Count; i++)
            {

                // データセットと比較
                string dsSecCd = (string)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[i][VIEW_SECTIONCODE_TITLE];
                int dsCashRegisterNo = (int)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[i][VIEW_CASHREGISTERNO_TITLE];
                if ((sectionCd.Equals(dsSecCd.TrimEnd().PadLeft(2, '0'))) &&
                    (cashRegisterNo == dsCashRegisterNo))
                {
                    // 入力コードがデータセットに存在する場合
                    if ((string)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[i][DELETE_DATE] != "")
                    {
                        // 論理削除
                        TMsgDisp.Show(this, 					// 親ウィンドウフォーム
                          emErrorLevel.ERR_LEVEL_INFO,          // エラーレベル
                          ASSEMBLY_ID,						    // アセンブリＩＤまたはクラスＩＤ
                          "入力されたコードの同期状態表示端末設定情報は既に削除されています。", 			// 表示するメッセージ
                          0, 									// ステータス値
                          MessageBoxButtons.OK);				// 表示するボタン
                        // 画面情報のクリア
                        ScreenClear();
                        this.tNEdit_SectionCode.Text = ALL_SECTIONCODE;
                        this.tEdit_SectionName.Text = ALL_SECTIONNAME;
                        this._tmpSectionCode = ALL_SECTIONCODE;
                        this._tmpSectionName = ALL_SECTIONNAME;
                        return true;
                    }

                    if (sectionCd == "00")
                    {
                        // 全社共通のメッセージ変更
                        msg = "入力されたコードの同期状態表示端末設定情報が既に登録されています。\n　【拠点名称：全社共通】\n編集を行いますか？";
                    }

                    DialogResult res = TMsgDisp.Show(
                        this,                                   // 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_INFO,            // エラーレベル
                        ASSEMBLY_ID,                             // アセンブリＩＤまたはクラスＩＤ
                        msg,                                    // 表示するメッセージ
                        0,                                      // ステータス値
                        MessageBoxButtons.YesNo);               // 表示するボタン
                    switch (res)
                    {
                        case DialogResult.Yes:
                            {
                                // 画面再描画
                                this.DataIndex = i;
                                ScreenClear();
                                ScreenReconstruction();
                                break;
                            }
                        case DialogResult.No:
                            {
                                // 画面情報のクリア
                                ScreenClear();
                                this.tNEdit_SectionCode.Text = ALL_SECTIONCODE;
                                this.tEdit_SectionName.Text = ALL_SECTIONNAME;
                                this._tmpSectionCode = ALL_SECTIONCODE;
                                this._tmpSectionName = ALL_SECTIONNAME;
                                break;
                            }
                    }
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 拠点コードEdit Leave処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 拠点名称表示処理</br>
        /// <br></br>
        /// </remarks>
        private void tNEdit_SectionCode_Leave(object sender, EventArgs e)
        {
            if (tNEdit_SectionCode.Text == "")
            {
                // uiSetControlが"00"に補正するので、拠点名称は全社共通を設定
                this.tNEdit_SectionCode.Text = "00";
                this.tEdit_SectionName.Text = SectionUtil.ALL_SECTION_NAME;
                _tmpSectionCode = "00";
                _tmpSectionName = SectionUtil.ALL_SECTION_NAME;
            }
            else if (tNEdit_SectionCode.GetInt() == 0)
            {
                tNEdit_SectionCode.Text = _tmpSectionCode;
                _checkFlag = false;
            }
            else
            {
                SyncStateDspTermStWork syncStateSt = null;

                if (this.DataIndex >= 0)
                {
                    Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this._dataIndex][VIEW_GUID_KEY_TITLE];
                    syncStateSt = ((SyncStateDspTermStWork)this._syncStSetTable[guid]).Clone();
                }

                ScreenToSyncStSet(ref syncStateSt);

                // 拠点コードまたが存在していない場合、登録しない。
                if (!ExistsCode())
                {
                    TMsgDisp.Show(
                        this, 								                    // 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,                     // エラーレベル
                        AssemblyUtil.GetName(Assembly.GetExecutingAssembly()),  // アセンブリＩＤまたはクラスＩＤ
                        this.Text, 		                                        // プログラム名称
                        MethodBase.GetCurrentMethod().Name, 					// 処理名称
                        TMsgDisp.OPE_UPDATE, 				                    // オペレーション
                        "拠点コードが存在しません。",                           // LITERAL:表示するメッセージ
                        (int)ConstantManagement.MethodResult.ctFNC_NORMAL, 		// ステータス値
                        this,			                                        // エラーが発生したオブジェクト
                        MessageBoxButtons.OK, 				                    // 表示するボタン
                        MessageBoxDefaultButton.Button1                         // 初期表示ボタン
                    );
                    this.tNEdit_SectionCode.Text = _tmpSectionCode;
                    this.tEdit_SectionName.Text = _tmpSectionName;
                    this.tNEdit_SectionCode.Focus();

                }
            }
            // 拠点コード入力あり？
            if (this.tNEdit_SectionCode.Text != "")
            {
                // 拠点コード名称設定
                this.tEdit_SectionName.Text = GetSectionName(this.tNEdit_SectionCode.Text.Trim());

                if (SectionUtil.IsAllSection(this.tNEdit_SectionCode.Text))
                {
                    this.tEdit_SectionName.Text = SectionUtil.ALL_SECTION_NAME;
                }
                _tmpSectionCode = this.tNEdit_SectionCode.Text;
                _tmpSectionName = this.tEdit_SectionName.Text;
            }          
        }

        /// <summary>
        /// 端末番号Edit Leave処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 端末番号表示処理</br>
        /// <br></br>
        /// </remarks>
        private void tNedit_CashRegisterNo_Leave(object sender, EventArgs e)
        {
            if (tNedit_CashRegisterNo.Text == "")
            {
                tEdit_MachineName.Text = string.Empty;
                tEdit_MachineIpAddr.Text = string.Empty;
            }
            else if (tNedit_CashRegisterNo.GetInt() == 0)
            {
                tEdit_MachineName.Text = _tmpMachineName;
                tEdit_MachineIpAddr.Text = _tmpMachineIpAddr;
                tNedit_CashRegisterNo.Text = _tmpCashRegisterNo;
                _tmpCashRegisterNo = tNedit_CashRegisterNo.Text;
                _checkFlag = false;
            }
            else
            {
                // 端末管理設定マスタから名称を取得
                PosTerminalMg posTerminalMg = GetPosTerminalMg(tNedit_CashRegisterNo.GetInt());
                if ((posTerminalMg != null) &&
                    (posTerminalMg.LogicalDeleteCode == 0))
                {
                    tEdit_MachineName.Text = posTerminalMg.MachineName;
                    tEdit_MachineIpAddr.Text = posTerminalMg.MachineIpAddr;
                    _tmpCashRegisterNo = tNedit_CashRegisterNo.Text;
                    _tmpMachineName = tEdit_MachineName.Text;
                    _tmpMachineIpAddr = tEdit_MachineIpAddr.Text;
                }
                else
                {
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                        this.Name,
                        "該当する端末番号が存在しません。",
                        -1,
                        MessageBoxButtons.OK);
                    tNedit_CashRegisterNo.Text = _tmpCashRegisterNo;
                    tEdit_MachineName.Text = _tmpMachineName;
                    tEdit_MachineIpAddr.Text = _tmpMachineIpAddr;
                    _tmpCashRegisterNo = tNedit_CashRegisterNo.Text;
                    tNedit_CashRegisterNo.Focus();
                }
            }
        }

        /// <summary>
        /// Timer.Tick イベント(timer)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　  : 指定された間隔の時間が経過したときに発生します。
        ///					  この処理は、システムが提供するスレッド プール
        ///					  スレッドで実行されます。</br>
        /// <br>Programmer  : 劉超</br>
        /// <br>Date        : 2014/08/18</br>
        /// </remarks>
        private void Timer_Tick(object sender, EventArgs e)
        {
            Timer.Enabled = false;

            // 画面再構築処理
            ScreenReconstruction();
        }

        /// <summary>
        ///	Form.VisibleChanged イベント(PMSCM09110UA)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: フォームの表示・非表示が切り替えられ
        ///					  たときに発生します。</br>
        /// <br>Programmer  : 劉超</br>
        /// <br>Date        : 2014/08/18</br>
        /// </remarks>
        private void PMSCM09110UA_VisibleChanged(object sender, EventArgs e)
        {
            // 自分自身が非表示になった場合は以下の処理をキャンセルする。
            if (this.Visible == false)
            {
                // メインフレームアクティブ化
                this.Owner.Activate();

                return;
            }

            // 自分自身が非表示になった場合、
            // またはターゲットレコード(Index)が変わっていない場合は以下の処理をキャンセルする
            if (this._indexBuf == this._dataIndex)
            {
                return;
            }

            // 画面クリア処理
            ScreenClear();

            Timer.Enabled = true;
        }

        /// <summary>
        ///	Form.Closing イベント(PMSCM09110UA)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">キャンセルできるイベントのデータを提供するクラス</param>
        /// <remarks>
        /// <br>Note		: フォームを閉じる前に、ユーザーがフォームを閉じ
        ///					  ようとしたときに発生します。</br>
        /// <br>Programmer  : 劉超</br>
        /// <br>Date        : 2014/08/18</br>
        /// </remarks>
        private void PMSCM09110UA_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this._indexBuf = -2;
            this._tmpSectionCode = ALL_SECTIONCODE;
            this._tmpCashRegisterNo = string.Empty;
            // CanCloseプロパティがfalseの場合は、クローズ処理をキャンセルして
            // フォームを非表示化する。
            //（フォームの「×」をクリックされた場合の対応です。）
            if (CanClose == false)
            {
                e.Cancel = true;
                this.Hide();
            }
        }
        # endregion


        
    }
}