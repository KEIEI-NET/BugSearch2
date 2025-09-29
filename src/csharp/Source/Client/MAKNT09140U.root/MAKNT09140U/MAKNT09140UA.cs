using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

using Broadleaf.Application.Controller;
using Broadleaf.Application.Controller.Util;    // ADD 2009/03/30 不具合対応[12891]：スペースキーでの項目選択機能を実装
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 休業日設定画面
    /// </summary>
    /// <remarks>
    /// <br>Note		: 休業日設定を行います。</br>
    /// <br>Programmer	: NEPCO</br>
    /// <br>Date		: 2007.01.30</br>
    /// </remarks>
    public partial class MAKNT09140UA : System.Windows.Forms.Form, IMasterMaintenanceMultiType
    {
        #region Const

        // PG名称
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/00/00 DEL
        //private const string ctPGNM = "休業日設定";
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/00/00 DEL
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/00/00 ADD
        private const string ctPGNM = "営業日設定";
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/00/00 ADD

        // FrameのView用Grid列のKEY情報 (HeaderのTitle部となります)
        private const string VIEW_DELETE_DATE_TITLE = "削除日";
        private const string VIEW_SECTION_CODE_TITLE = "拠点コード";
        private const string VIEW_SECTION_NAME_TITLE = "拠点名称";
        private const string VIEW_GUID_KEY_TITLE = "Guid";

        // View用Gridに表示させるテーブル名
        private const string VIEW_TABLE = "VIEW_TABLE";
        // 編集モード
        private const string UPDATE_MODE = "更新モード";
        
        #endregion

        #region -- Private Members --

        private SortedList<DateTime, int> _applyDateList;
        private SortedList<DateTime, HolidaySetting> _prevHolidaySettingList;
        private HolidaySettingAcs _holidaySettingAcs;
        private SecInfoSetAcs _secInfoSetAcs;

        /// <summary>画面デザイン変更クラス</summary>
        private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();

        private int _totalCount;
        private string _enterpriseCode;

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

        // ADD 2009/03/30 不具合対応[12891]：スペースキーでの項目選択機能を実装 ---------->>>>>
        /// <summary>適用区分ラジオボタンのKeyPressイベントのヘルパ</summary>
        private readonly OptionSetKeyPressEventHelper _applyDateCdRadioKeyPressHelper = new OptionSetKeyPressEventHelper();
        /// <summary>
        /// 適用区分ラジオボタンのKeyPressイベントのヘルパを取得します。
        /// </summary>
        /// <value>小計印刷ラジオボタンのKeyPressイベントのヘルパ</value>
        public OptionSetKeyPressEventHelper ApplyDateCdRadioKeyPressHelper
        {
            get { return _applyDateCdRadioKeyPressHelper; }
        }
        // ADD 2009/03/30 不具合対応[12891]：スペースキーでの項目選択機能を実装 ----------<<<<<

        #endregion

        #region -- Constructor --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// 休業日設定設定フォームクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note		: 休業日設定設定フォームクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer	: NEPCO</br>
        /// <br>Date		: 2007.01.19</br>
        /// </remarks>
        public MAKNT09140UA()
        {
            InitializeComponent();

            // 拠点アクセスクラス初期化
            this._secInfoSetAcs = new SecInfoSetAcs();
            // 休業日設定マスタ初期化
            this._holidaySettingAcs = new HolidaySettingAcs();

            // データセット列情報構築処理
            DataSetColumnConstruction();

            // プロパティ初期値設定
            this._canPrint  = false;
            this._canClose  = true;
            this._canNew    = false;
            this._canDelete = false;
            this._defaultAutoFillToColumn = false;
            this._canSpecificationSearch  = false;
            this._canLogicalDeleteDataExtraction = false;

            //　企業コード取得
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            // フォーカス移動用コントロール設定
            this.calendar_Control.NextControl = this.Ok_Button;

            // 変数初期化
            this._dataIndex = -1;
            this._totalCount = 0;

            //_dataIndexバッファ（メインフレーム最小化対応）
            this._indexBuf = -2;

        }
        #endregion

        #region -- Events --
        /*----------------------------------------------------------------------------------*/
        /// <summary>画面非表示イベント</summary>
        /// <remarks>画面が非表示状態になった際に発生します。</remarks>
        public event MasterMaintenanceMultiTypeUnDisplayingEventHandler UnDisplaying;
        #endregion

        #region -- Properties --
        /*----------------------------------------------------------------------------------*/
        /// <summary>印刷可能設定プロパティ</summary>
        /// <value>印刷可能かどうかの設定を取得します。</value>
        public bool CanPrint
        {
            get
            {
                return this._canPrint;
            }
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>論理削除データ抽出可能設定プロパティ</summary>
        /// <value>論理削除データの抽出が可能かどうかの設定を取得します。</value>
        public bool CanLogicalDeleteDataExtraction
        {
            get
            {
                return this._canLogicalDeleteDataExtraction;
            }
        }

        /*----------------------------------------------------------------------------------*/
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

        /*----------------------------------------------------------------------------------*/
        /// <summary>新規登録可能設定プロパティ</summary>
        /// <value>新規登録が可能かどうかの設定を取得します。</value>
        public bool CanNew
        {
            get
            {
                return this._canNew;
            }
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>削除可能設定プロパティ</summary>
        /// <value>削除が可能かどうかの設定を取得します。</value>
        public bool CanDelete
        {
            get
            {
                return this._canDelete;
            }
        }

        /*----------------------------------------------------------------------------------*/
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

        /*----------------------------------------------------------------------------------*/
        /// <summary>列のサイズの自動調整のデフォルト値プロパティ</summary>
        /// <value>列のサイズの自動調整チェックボックスのチェック有無のデフォルト値を取得します。</value>
        public bool DefaultAutoFillToColumn
        {
            get
            {
                return this._defaultAutoFillToColumn;
            }
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>件数指定抽出可能設定プロパティ</summary>
        /// <value>件数指定抽出を可能とするかどうかの設定を取得または設定します。</value>
        public bool CanSpecificationSearch
        {
            get
            {
                return this._canSpecificationSearch;
            }
        }
        #endregion

        #region -- Public Methods --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// バインドデータセット取得処理
        /// </summary>
        /// <param name="bindDataSet">グリッド用データセット</param>
        /// <param name="tableName">テーブル名称</param>
        /// <remarks>
        /// <br>Note		: フレーム側のグリッドにバインドさせるデータセットを取得します。</br>
        /// <br>Programmer	: NEPCO</br>
        /// <br>Date		: 2007.01.19</br>
        /// </remarks>
        public void GetBindDataSet(ref System.Data.DataSet bindDataSet, ref string tableName)
        {
            bindDataSet = this.Bind_DataSet;
            tableName   = VIEW_TABLE;
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// データ検索処理(拠点マスタからデータを取得する)
        /// </summary>
        /// <param name="totalCount">全該当件数</param>
        /// <param name="readCount">抽出対象件数</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note		: 先頭から指定件数分のデータを検索し、</br>
        ///	<br>			  抽出結果を展開したDataSetと全該当件数を返します。</br>
        /// <br>Programmer	: NEPCO</br>
        /// <br>Date		: 2007.01.19</br>
        /// </remarks>
        public int Search(ref int totalCount, int readCount)
        {
            int status = 0;
            ArrayList secInfoSets = null;
            DataRow dataRow;

            // 拠点マスタからデータを取得
            //2007.05.28 NEPCO : 削除済み拠点が表示されていた
            //status = this._secInfoSetAcs.SearchAll(out secInfoSets, this._enterpriseCode);
            status = this._secInfoSetAcs.Search(out secInfoSets, this._enterpriseCode);
            this._totalCount = secInfoSets.Count;

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                {
                    this.Bind_DataSet.Tables[VIEW_TABLE].Clear();

                    foreach (SecInfoSet secInfoSetting in secInfoSets)
                    {
                        // 新規と判断して行を追加する
                        dataRow = this.Bind_DataSet.Tables[VIEW_TABLE].NewRow();

                        // 拠点コード、拠点名称
                        dataRow[VIEW_SECTION_CODE_TITLE] = secInfoSetting.SectionCode;
                        dataRow[VIEW_SECTION_NAME_TITLE] = secInfoSetting.SectionGuideNm;
                        dataRow[VIEW_GUID_KEY_TITLE] = secInfoSetting.FileHeaderGuid;

                        this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Add(dataRow);
                    }
                    break;
                }
                case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    break;
                default:
                    TMsgDisp.Show(this,                         // 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_STOP,			// エラーレベル
                        this.Name,							    // アセンブリID
                        ctPGNM,              　　               // プログラム名称
                        "Search",                               // 処理名称
                        TMsgDisp.OPE_GET,                       // オペレーション
                        "拠点マスタの読み込みに失敗しました",				// 表示するメッセージ
                        status,									// ステータス値
                        this._secInfoSetAcs,			        // エラーが発生したオブジェクト
                        MessageBoxButtons.OK,					// 表示するボタン
                        MessageBoxDefaultButton.Button1);		// 初期表示ボタン

                    break;
            }
            return status;
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// ネクストデータ検索処理
        /// </summary>
        /// <param name="readCount">抽出対象件数</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note		: 指定した件数分のネクストデータを検索します。</br>
        /// <br>Programmer	: NEPCO</br>
        /// <br>Date		: 2007.01.19</br>
        /// </remarks>
        public int SearchNext(int readCount)
        {
            return (0);
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// データ削除処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note        : 選択中のデータを削除します。(未実装)</br>
        /// <br>Programmer	: NEPCO</br>
        /// <br>Date		: 2007.01.19</br>
        /// </remarks>
        public int Delete()
        {
            return 0;
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// 印刷処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note        : 印刷処理を実行します。(未実装)</br>
        /// <br>Programmer	: NEPCO</br>
        /// <br>Date		: 2007.01.19</br>
        /// </remarks>
        public int Print()
        {
            return 0;
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// グリッド列外観情報取得処理
        /// </summary>
        /// <returns>グリッド列外観情報格納Hashtable</returns>
        /// <remarks>
        /// <br>Note        : 各列の外見を設定するクラスを格納したHashtableを取得します。</br>
        /// <br>Programmer	: NEPCO</br>
        /// <br>Date		: 2007.01.19</br>
        /// </remarks>
        public Hashtable GetAppearanceTable()
        {
            Hashtable appearanceTable = new Hashtable();

            appearanceTable.Add(VIEW_DELETE_DATE_TITLE,  new GridColAppearance(MGridColDispType.DeletionDataBoth, ContentAlignment.MiddleLeft, "", Color.Red));
            appearanceTable.Add(VIEW_SECTION_CODE_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(VIEW_SECTION_NAME_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));

            appearanceTable.Add(VIEW_GUID_KEY_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));

            return appearanceTable;
        }
        # endregion

        #region -- Private Methods --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// 画面再構築処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : モードに基づいて画面を再構築します。</br>
        /// <br>Programmer : NEPCO</br>
        /// <br>Date	   : 2007.01.19</br>
        /// </remarks>
        private void ScreenReconstruction()
        {
            int status;

            // 選択された拠点を取得
            string sectionCode = (string)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this._dataIndex][VIEW_SECTION_CODE_TITLE];
            // 拠点名称設定
            this.SectionName_tEdit.DataText = (string)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this._dataIndex][VIEW_SECTION_NAME_TITLE];

            // 休業日設定マスタ取得
            ArrayList retList;
            status = this._holidaySettingAcs.Search
                (out retList,
                this._enterpriseCode,
                sectionCode,
                DateTime.MinValue,
                DateTime.MaxValue);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    break;
                default:
                    TMsgDisp.Show(this,                         // 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_STOP,			// エラーレベル
                        this.Name,							    // アセンブリID
                        ctPGNM,              　　               // プログラム名称
                        "Search",                               // 処理名称
                        TMsgDisp.OPE_GET,                       // オペレーション
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/00/00 DEL
                        //"休業日設定マスタの読み込みに失敗しました",				// 表示するメッセージ
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/00/00 DEL
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/00/00 ADD
                        "営業日設定マスタの読み込みに失敗しました",				// 表示するメッセージ
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/00/00 ADD
                        status,									// ステータス値
                        this._secInfoSetAcs,			        // エラーが発生したオブジェクト
                        MessageBoxButtons.OK,					// 表示するボタン
                        MessageBoxDefaultButton.Button1);		// 初期表示ボタン
                    return;
            }

            // データ処理
            _applyDateList = new SortedList<DateTime, int>();
            _prevHolidaySettingList = new SortedList<DateTime, HolidaySetting>();
            foreach (HolidaySetting holidaySetting in retList)
            {
                _applyDateList.Add(holidaySetting.ApplyDate, holidaySetting.ApplyDateCd);
                _prevHolidaySettingList.Add(holidaySetting.ApplyDate, holidaySetting);
            }

            // カレンダーコントロール設定
            this.calendar_Control.ApplyDateList = _applyDateList;
            this.calendar_Control.DispScrean(DateTime.Now.Year);

            //_dataIndexバッファ保持
            this._indexBuf = this._dataIndex;
            this.ApplyDateCd_ultraOptionSet.CheckedIndex = 0;

            // 更新モード
            this.Mode_Label.Text                = UPDATE_MODE;
            this.Ok_Button.Visible              = true;
            this.Cancel_Button.Visible          = true;
            this.SectionName_tEdit.Enabled      = false;
            this.ApplyDateCd_ultraOptionSet.Enabled = true;
            // フォーカス設定
            this.ApplyDateCd_ultraOptionSet.Focus();

        }

//        /*----------------------------------------------------------------------------------*/
//        /// <summary>
//        /// 休業日設定オブジェクトデータセット展開処理
//        /// </summary>
//        /// <param name="holidaySetting">休業日設定オブジェクト</param>
//        /// <param name="index">データセットへ展開するインデックス</param>
//        /// <remarks>
//        /// <br>Note       : 休業日設定クラスをデータセットに格納します。</br>
        //        /// <br>Programmer : NEPCO</br>
//        /// <br>Date	   : 2007.01.19</br>
//        /// </remarks>
//        private void HolidaySettingToDataSet(HolidaySetting holidaySetting, int index) 
//        {
//            //if ((index < 0) || (this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Count <= index))
//            //{
//                // 新規と判断して行を追加する
//                DataRow dataRow = this.Bind_DataSet.Tables[VIEW_TABLE].NewRow();
//                this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Add(dataRow);
//                // indexを行の最終行番号にする
//                index = this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Count - 1;
//            //}

//            // 拠点コード、拠点名称
//// テスト用出力↓↓↓↓↓
//            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[0][VIEW_SECTION_CODE_TITLE] = "1";
//            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[0][VIEW_SECTION_NAME_TITLE] = "町田支店";
//            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[0][VIEW_GUID_KEY_TITLE] = holidaySetting.FileHeaderGuid;
//            if (this._holidaySettingTable.ContainsKey(holidaySetting.FileHeaderGuid) == true)
//            {
//                this._holidaySettingTable.Remove(holidaySetting.FileHeaderGuid);
//            }
//            this._holidaySettingTable.Add(holidaySetting.FileHeaderGuid, holidaySetting);

//            dataRow = this.Bind_DataSet.Tables[VIEW_TABLE].NewRow();
//            this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Add(dataRow);

//            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[1][VIEW_SECTION_CODE_TITLE] = "2";
//            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[1][VIEW_SECTION_NAME_TITLE] = "新宿支店";
//            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[1][VIEW_GUID_KEY_TITLE] = holidaySetting.FileHeaderGuid;
//            if (this._holidaySettingTable.ContainsKey(holidaySetting.FileHeaderGuid) == true)
//            {
//                this._holidaySettingTable.Remove(holidaySetting.FileHeaderGuid);
//            }
//            this._holidaySettingTable.Add(holidaySetting.FileHeaderGuid, holidaySetting);

//            dataRow = this.Bind_DataSet.Tables[VIEW_TABLE].NewRow();
//            this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Add(dataRow);
//            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[2][VIEW_SECTION_CODE_TITLE] = "3";
//            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[2][VIEW_SECTION_NAME_TITLE] = "渋谷支店";
//            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[2][VIEW_GUID_KEY_TITLE] = holidaySetting.FileHeaderGuid;
//            if (this._holidaySettingTable.ContainsKey(holidaySetting.FileHeaderGuid) == true)
//            {
//                this._holidaySettingTable.Remove(holidaySetting.FileHeaderGuid);
//            }
//            this._holidaySettingTable.Add(holidaySetting.FileHeaderGuid, holidaySetting);
//// テスト用出力↑↑↑↑↑

//            //this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SECTION_CODE_TITLE] = holidaySetting.SectionCode;
//            //this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SECTION_NAME_TITLE] = holidaySetting.SectionName;

//            //this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_GUID_KEY_TITLE] = holidaySetting.FileHeaderGuid; 

//            //if (this._holidaySettingTable.ContainsKey(holidaySetting.FileHeaderGuid) == true) 
//            //{
//            //    this._holidaySettingTable.Remove(holidaySetting.FileHeaderGuid);
//            //}
//            //this._holidaySettingTable.Add(holidaySetting.FileHeaderGuid, holidaySetting);
//        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// データセット列情報構築処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : データセットの列情報を構築します。
        ///					 データセットの列情報がフレームのビュー用グリッドの列になります</br>
        /// <br>Programmer : NEPCO</br>
        /// <br>Date	   : 2007.01.19</br>
        /// </remarks>
        private void DataSetColumnConstruction()
        {
            DataTable holidaySettingTable = new DataTable(VIEW_TABLE);

            // Addを行う順番が、列の表示順位となります。
            holidaySettingTable.Columns.Add(VIEW_DELETE_DATE_TITLE,  typeof(string));
            holidaySettingTable.Columns.Add(VIEW_SECTION_CODE_TITLE, typeof(string));
            holidaySettingTable.Columns.Add(VIEW_SECTION_NAME_TITLE, typeof(string));
            holidaySettingTable.Columns.Add(VIEW_GUID_KEY_TITLE, typeof(Guid));

            this.Bind_DataSet.Tables.Add(holidaySettingTable);
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// 画面初期設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面の初期設定を行います。</br>
        /// <br>Programmer : NEPCO</br>
        /// <br>Date	   : 2007.01.19</br>
        /// </remarks>
        private void ScreenInitialSetting()
        {
            // 適用区分
            this.ApplyDateCd_ultraOptionSet.CheckedIndex = -1;
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// 画面クリア処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : 画面をクリアします。</br>
        /// <br>Programmer	: NEPCO</br>
        /// <br>Date		: 2007.01.19</br>
        /// </remarks>
        private void ScreenClear()
        {
            this.SectionName_tEdit.DataText = "";
            this.ApplyDateCd_ultraOptionSet.CheckedIndex = -1;
            this.calendar_Control.ScreenClear();
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// 排他処理
        /// </summary>
        /// <param name="status">ステータス</param>
        /// <remarks>
        /// <br>Note       : データ更新時の排他処理を行います。</br>
        /// <br>Programmer : NEPCO</br>
        /// <br>Date	   : 2007.01.19</br>
        /// </remarks>
        private void ExclusiveTransaction(int status)
        {
            if (status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE)
            {
                TMsgDisp.Show(this,                         // 親ウィンドウフォーム
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,     // エラーレベル
                    this.Name,							    // アセンブリID
                    "既に他端末より更新されています",	    // 表示するメッセージ
                    status,									// ステータス値
                    MessageBoxButtons.OK);					// 表示するボタン
            }
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        ///	休業日設定画面入力チェック処理
        /// </summary>
        /// <param name="checkMessage">エラーメッセージ</param>
        /// <remarks>
        /// <br>Note	   : 休業日設定画面の入力チェックをします。</br>
        /// <br>Programmer : NEPCO</br>
        /// <br>Date	   : 2007.01.19</br>
        /// </remarks>
        private int CheckDisplay(ref string checkMessage)
        {
            int returnStatus = 0;

            try
            {
                // 適用区分
                if (this.ApplyDateCd_ultraOptionSet.CheckedIndex == -1)
                {
                    checkMessage = "適用区分を選択してください";
                    returnStatus = 10;
                    return returnStatus;
                }

                return returnStatus;
            }
            finally
            {
                if (returnStatus != 0)
                {
                    TMsgDisp.Show(this,                         // 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,     // エラーレベル
                        this.Name,							    // アセンブリID
                        checkMessage,	                        // 表示するメッセージ
                        0,									    // ステータス値
                        MessageBoxButtons.OK);					// 表示するボタン

                    //エラーステータスに合わせてフォーカスセット
                    switch (returnStatus)
                    {
                        case 10:
                            this.ApplyDateCd_ultraOptionSet.Focus();
                            break;
                    }
                }
            }
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        ///	削除済み休業日リスト取得処理
        /// </summary>
        /// <param name="deleteHolidaySettings">削除済み休業日リスト</param>
        /// <remarks>
        /// <br>Note	   : 削除済み休業日リストを取得します。</br>
        /// <br>Programmer : NEPCO</br>
        /// <br>Date	   : 2007.01.19</br>
        /// </remarks>
        private void GetDeleteHolidaySettings(out ArrayList deleteHolidaySettings)
        {
            deleteHolidaySettings = new ArrayList();
            foreach (HolidaySetting holidaySetting in _prevHolidaySettingList.Values)
            {
                if (!_applyDateList.ContainsKey(holidaySetting.ApplyDate))
                {
                    deleteHolidaySettings.Add(holidaySetting);
                }
            }
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        ///	休業日設定登録処理
        /// </summary>
        /// <param name="writeHolidaySettings">休業日リスト</param>
        /// <remarks>
        /// <br>Note	   : 休業日設定の登録を行います。</br>
        /// <br>Programmer : NEPCO</br>
        /// <br>Date	   : 2007.01.19</br>
        /// </remarks>
        private void GetWriteHolidaySettings(out ArrayList writeHolidaySettings)
        {
            writeHolidaySettings = new ArrayList();

            // 拠点コード取得
            string sectionCode = (string)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this._dataIndex][VIEW_SECTION_CODE_TITLE];

            HolidaySetting writeHolidaySetting;
            foreach (DateTime applyDate in _applyDateList.Keys)
            {
                if (!_prevHolidaySettingList.ContainsKey(applyDate))
                {
                    // 新規の場合
                    writeHolidaySetting = new HolidaySetting();
                    writeHolidaySetting.SectionCode = sectionCode;
                    writeHolidaySetting.ApplyDate = applyDate;
                    writeHolidaySetting.ApplyDateCd = _applyDateList[applyDate];

                    writeHolidaySettings.Add(writeHolidaySetting);
                }
                else 
                {
                    if (_applyDateList[applyDate] != _prevHolidaySettingList[applyDate].ApplyDateCd)
                    {
                        // 更新の場合
                        writeHolidaySetting = _prevHolidaySettingList[applyDate].Clone();
                        writeHolidaySetting.ApplyDateCd = _applyDateList[applyDate];

                        writeHolidaySettings.Add(writeHolidaySetting);
                    }
                }
            }
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        ///　保存処理(SaveHolidaySetting())
        /// </summary>
        /// <param name="deleteHolidaySettings">削除用休業日リスト</param>
        /// <param name="writeHolidaySettings">休業日リスト</param>
        /// <remarks>
        /// <br>Note　　　  : 保存処理を行います。</br>
        /// <br>Programmer	: NEPCO</br>
        /// <br>Date		: 2007.01.19</br>
        /// </remarks>
        private bool SaveHolidaySetting(ArrayList deleteHolidaySettings, ArrayList writeHolidaySettings)
        {
            int status;

            // 削除
            if (deleteHolidaySettings == null)
            {
                GetDeleteHolidaySettings(out deleteHolidaySettings);
            }
            if (deleteHolidaySettings.Count > 0)
            {
                status = this._holidaySettingAcs.Delete(deleteHolidaySettings);
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                        break;
                    default:
                        TMsgDisp.Show(this,                         // 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOP,			// エラーレベル
                            this.Name,							    // アセンブリID
                            ctPGNM,  　　                           // プログラム名称
                            "SaveHolidaySetting",                   // 処理名称 
                            TMsgDisp.OPE_DELETE,                    // オペレーション
                            "削除に失敗しました",				    // 表示するメッセージ
                            status,									// ステータス値
                            this._holidaySettingAcs,				// エラーが発生したオブジェクト
                            MessageBoxButtons.OK,			  		// 表示するボタン
                            MessageBoxDefaultButton.Button1);		// 初期表示ボタン

                        return (false);
                }
            }

            // データ書き込み
            if (writeHolidaySettings == null)
            {
                GetWriteHolidaySettings(out writeHolidaySettings);
            }
            if (writeHolidaySettings.Count > 0)
            {
                status = this._holidaySettingAcs.Write(ref writeHolidaySettings);
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        break;

                    case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                        ExclusiveTransaction(status);
                        return (false);

                    default:
                        TMsgDisp.Show(this,                         // 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOP,			// エラーレベル
                            this.Name,							    // アセンブリID
                            ctPGNM,  　　                           // プログラム名称
                            "SaveHolidaySetting",                   // 処理名称 
                            TMsgDisp.OPE_UPDATE,                    // オペレーション
                            "登録に失敗しました",				    // 表示するメッセージ
                            status,									// ステータス値
                            this._holidaySettingAcs,				// エラーが発生したオブジェクト
                            MessageBoxButtons.OK,			  		// 表示するボタン
                            MessageBoxDefaultButton.Button1);		// 初期表示ボタン

                        return (false);
                }
            }

            return (true);

        }

        # endregion

        # region -- Control Events --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        ///	Form.Load イベント(MAKNT09140UA)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: ユーザーがフォームを読み込むときに発生します。</br>
        /// <br>Programmer	: NEPCO</br>
        /// <br>Date		: 2007.01.19</br>
        /// </remarks>
        private void MAKNT09140UA_Load(object sender, EventArgs e)
        {
            // 画面スキンファイルの読込(デフォルトスキン指定)
            this._controlScreenSkin.LoadSkin();

            // 画面スキン変更
            this._controlScreenSkin.SettingScreenSkin(this);

            // アイコンリソース管理クラスを使用して、アイコンを表示する
            ImageList imageList24 = IconResourceManagement.ImageList24;

            this.Ok_Button.ImageList = imageList24;
            this.Cancel_Button.ImageList = imageList24;

            this.Ok_Button.Appearance.Image = Size24_Index.SAVE;
            this.Cancel_Button.Appearance.Image = Size24_Index.CLOSE;

            // 画面初期設定処理
            ScreenInitialSetting();

            // ADD 2009/03/30 不具合対応[12891]：スペースキーでの項目選択機能を実装 ---------->>>>>
            ApplyDateCdRadioKeyPressHelper.ControlList.Add(this.ApplyDateCd_ultraOptionSet);
            ApplyDateCdRadioKeyPressHelper.StartSpaceKeyControl();
            // ADD 2009/03/30 不具合対応[12891]：スペースキーでの項目選択機能を実装 ----------<<<<<
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        ///	Form.Closing イベント(MAKNT09140UA)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">キャンセルできるイベントのデータを提供するクラス</param>
        /// <remarks>
        /// <br>Note		: フォームを閉じる前に、ユーザーがフォームを閉じ
        ///					  ようとしたときに発生します。</br>
        /// <br>Programmer	: NEPCO</br>
        /// <br>Date		: 2007.01.19</br>
        /// </remarks>
        private void MAKNT09140UA_FormClosing(object sender, FormClosingEventArgs e)
        {
            this._indexBuf = -2;
            // CanCloseプロパティがfalseの場合は、クローズ処理をキャンセルして
            // フォームを非表示化する。
            //（フォームの「×」をクリックされた場合の対応です。）
            if (CanClose == false)
            {
                e.Cancel = true;
                this.Hide();
            }
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        ///	Form.VisibleChanged イベント(MAKNT09140UA)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: フォームの表示・非表示が切り替えられ
        ///					  たときに発生します。</br>
        /// <br>Programmer	: NEPCO</br>
        /// <br>Date		: 2007.01.19</br>
        /// </remarks>
        private void MAKNT09140UA_VisibleChanged(object sender, System.EventArgs e)
        {
            // 自分自身が非表示になった場合はメインフレームアクティブ化
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
            ScreenClear();
            ScreenReconstruction();
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// ultraOptionSet.ValueChanged イベント(ApplyDateCd_ultraOptionSet)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　  : ラジオボタンの選択されている値が変わったときに発生します。</br>
        /// <br>Programmer	: NEPCO</br>
        /// <br>Date		: 2007.01.24</br>
        /// </remarks>
        private void ApplyDateCd_ultraOptionSet_ValueChanged(object sender, EventArgs e)
        {
            this.calendar_Control.ApplyDateCd = this.ApplyDateCd_ultraOptionSet.CheckedIndex;
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// Control.Click イベント(Ok_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　  : 保存ボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer	: NEPCO</br>
        /// <br>Date		: 2007.01.19</br>
        /// </remarks>
        private void Ok_Button_Click(object sender, EventArgs e)
        {
            //画面データ入力チェック処理
            string checkMessage = "";
            int chkSt = CheckDisplay(ref checkMessage);
            if (chkSt != 0)
            {
                return;
            }

            // 保存
            bool status = SaveHolidaySetting(null, null);
            if (status)
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                this.DialogResult = DialogResult.Cancel;
            }

            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }

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

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// Control.Click イベント(Cancel_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　  : 閉じるボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer	: NEPCO</br>
        /// <br>Date		: 2007.01.19</br>
        /// </remarks>
        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            // 比較チェックフラグ初期化
            bool equalFlg = true;

            ArrayList deleteHolidaySettings = null;
            ArrayList writeHolidaySettings = null;

            // 削除データ取得
            GetDeleteHolidaySettings(out deleteHolidaySettings);
            if (deleteHolidaySettings.Count > 0)
            {
                equalFlg = false;
            }
            else
            {
                // 書き込みデータ取得
                GetWriteHolidaySettings(out writeHolidaySettings);
                if (writeHolidaySettings.Count > 0)
                {
                    equalFlg = false;
                }
            }

            // 画面情報と起動時のクローンを比較
            if (!equalFlg) 
            {
                // 画面情報が変更されていた場合は、保存確認メッセージを表示
                DialogResult res = TMsgDisp.Show(
                    this,                                                 // 親ウィンドウフォーム
                    emErrorLevel.ERR_LEVEL_SAVECONFIRM,                   // エラーレベル
                    this.Name, 			                                  // アセンブリＩＤ
                    null, 					                              // 表示するメッセージ
                    0, 					                                  // ステータス値
                    MessageBoxButtons.YesNoCancel);	                      // 表示するボタン

                switch (res)
                {
                    case DialogResult.Yes:
                    {
                        //画面データ入力チェック処理
                        string checkMessage = "";
                        int chkSt = CheckDisplay(ref checkMessage);
                        if (chkSt != 0)
                        {
                            return;
                        }

                        // 保存処理
                        bool status = SaveHolidaySetting(deleteHolidaySettings, writeHolidaySettings);
                        if (status)
                        {
                            this.DialogResult = DialogResult.OK;
                        }
                        else
                        {
                            this.DialogResult = DialogResult.Cancel;
                        }

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

            // 画面非表示イベント
            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.Cancel);
                UnDisplaying(this, me);
            }

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

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// Timer.Tick イベント(timer)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　  : 指定された間隔の時間が経過したときに発生します。
        ///					  この処理は、システムが提供するスレッド プール
        ///					  スレッドで実行されます。</br>
        /// <br>Programmer	: NEPCO</br>
        /// <br>Date		: 2007.01.19</br>
        /// </remarks>
        private void Timer_Tick(object sender, System.EventArgs e)
        {
            Initial_Timer.Enabled = false;
            ScreenReconstruction();
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// tArrowKeyControlChangeFocusイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note		: コントロールのフォーカスが変わるタイミングで発生します。</br>
        /// <br>Programmer	: NEPCO</br>
        /// <br>Date		: 2007.05.30</br>
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl != null)
            {
                if (e.PrevCtrl.Name == "PreviousYear_Button")
                {
                    if (e.Key == Keys.Up)
                    {
                        e.NextCtrl = this.ApplyDateCd_ultraOptionSet;
                    }
                    else if (e.Key == Keys.Down)
                    {
                        e.NextCtrl = this.calendar_Control.GetCalendarControl(2);
                    }
                }
                else if (e.PrevCtrl.Name == "NextYear_Button")
                {
                    if (e.Key == Keys.Up)
                    {
                        e.NextCtrl = this.ApplyDateCd_ultraOptionSet;
                    }
                    else if (e.Key == Keys.Down)
                    {
                        e.NextCtrl = this.calendar_Control.GetCalendarControl(3);
                    }
                }
            }
        }

        #endregion

    }
}