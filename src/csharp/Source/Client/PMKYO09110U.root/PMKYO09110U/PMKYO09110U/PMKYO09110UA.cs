//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 拠点管理企業設定マスタメンテナンス
// プログラム概要   : 拠点管理設定の登録・変更・削除を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張凱
// 作 成 日  2009/03/27  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 芦珊
// 修 正 日  2011/08/02  修正内容 : SCM対応‐拠点管理（10704767-00）
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Application.Controller;
using System.Collections;
using Broadleaf.Application.Common;
using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Windows.Forms;
using System.Net.NetworkInformation;
using System.Text.RegularExpressions;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 企業コード設定フォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note		: 企業コード設定を行います。
    ///					  IMasterMaintenanceMultiTypeを実装しています。</br>   
    /// <br>Programmer	: 張凱</br>
    /// <br>Date		: 2009.03.25</br>
    /// <br></br>
    /// </remarks>
    public partial class PMKYO09110UA : System.Windows.Forms.Form, IMasterMaintenanceMultiType
    {

        #region -- Constructor --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// 企業コード設定フォームクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note		: 企業コード設定フォームクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer	: 張凱</br>
        /// <br>Date		: 2009.03.25</br>
        /// </remarks>
        public PMKYO09110UA()
        {
            InitializeComponent();

            // データセット列情報構築処理
            DataSetColumnConstruction();

            // プロパティ初期値設定
            this._canPrint = false;
            this._canClose = false;
            this._canNew = true;
            this._canDelete = true;
            this._canClose = true;
            this._defaultAutoFillToColumn = false;
            this._canSpecificationSearch = false;
            this._canLogicalDeleteDataExtraction = true;

            //　企業コード取得
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            // 変数初期化
            this._dataIndex = -1;
            this._enterpriseSetAcs = new EnterpriseSetAcs();
            this._totalCount = 0;
            this._enterpriseSetTable = new Hashtable();

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

        #region -- Private Members --
        /*----------------------------------------------------------------------------------*/
        private EnterpriseSetAcs _enterpriseSetAcs;
        private int _totalCount;
        private string _enterpriseCode;
        private Hashtable _enterpriseSetTable;

        /// <summary>画面デザイン変更クラス</summary>
        private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();

        // 保存比較用Clone
        private EnterpriseSet _enterpriseSetClone;

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

        // View用Gridに表示させるテーブル名
        private const string VIEW_TABLE = "VIEW_TABLE";

        // 編集モード
        private const string INSERT_MODE = "新規モード";
        private const string UPDATE_MODE = "更新モード";
        private const string DELETE_MODE = "削除モード";

        private const string ALL_SECTIONCODE = "00";

        // FrameのView用Grid列のKEY情報 (HeaderのTitle部となります)
        private const string DELETE_DATE = "削除日";
        private const string VIEW_SECTION_CODE_TITLE = "拠点コード";
        private const string VIEW_SECTION_NAME_TITLE = "拠点名";
        private const string VIEW_ENTERPRISECODE_TITLE = "企業コード";
        private const string VIEW_GUID_KEY_TITLE = "Guid";

        // 抽出条件前回入力値(更新有無チェック用)
        private string _tmpSectionCode;

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
        # endregion

        #region -- Public Methods --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// バインドデータセット取得処理
        /// </summary>
        /// <param name="bindDataSet">グリッドリッド用データセット</param>
        /// <param name="tableName">テーブル名称</param>
        /// <remarks>
        /// <br>Note		: フレーム側のグリッドにバインドさせるデータセットを取得します。</br>
        /// <br>Programmer	: 張凱</br>
        /// <br>Date		: 2009.03.25</br>
        /// </remarks>
        public void GetBindDataSet(ref System.Data.DataSet bindDataSet, ref string tableName)
        {
            bindDataSet = this.Bind_DataSet;
            tableName = VIEW_TABLE;
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// データ検索処理
        /// </summary>
        /// <param name="totalCount">全該当件数</param>
        /// <param name="readCount">抽出対象件数</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note		: 先頭から指定件数分のデータを検索し、</br>
        ///	<br>			  抽出結果を展開したDataSetと全該当件数を返します。</br>
        /// <br>Programmer	: 張凱</br>
        /// <br>Date		: 2009.03.25</br>
        /// </remarks>
        public int Search(ref int totalCount, int readCount)
        {
            // オフライン状態チェック
            if (!CheckOnline())
            {
                TMsgDisp.Show(
                    emErrorLevel.ERR_LEVEL_STOP,
                    this.Text,
                    this.Text + "画面検索処理に失敗しました。",
                    (int)ConstantManagement.DB_Status.ctDB_OFFLINE, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                return 0;
            }

            int status = 0;
            ArrayList enterpriseSets = null;

            this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Clear();
            this._enterpriseSetTable.Clear();

            status = this._enterpriseSetAcs.SearchAll(out enterpriseSets, this._enterpriseCode);
            this._totalCount = enterpriseSets.Count;

            switch (status)
            {
                case (int)ConstantManagement.MethodResult.ctFNC_NORMAL:
                    {
                        int index = 0;

                        foreach (EnterpriseSet enterpriseSet in enterpriseSets)
                        {
                            EnterpriseSetToDataSet(enterpriseSet.Clone(), index);
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
                            "PMKYO09110U",							// アセンブリID
                            "企業設定",              　　   // プログラム名称
                            "Search",                               // 処理名称
                            TMsgDisp.OPE_GET,                       // オペレーション
                            "読み込みに失敗しました。",				// 表示するメッセージ
                            status,									// ステータス値
                            this._enterpriseSetAcs,					    // エラーが発生したオブジェクト
                            MessageBoxButtons.OK,					// 表示するボタン
                            MessageBoxDefaultButton.Button1);		// 初期表示ボタン

                        break;
                    }
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
        /// <br>Programmer	: 張凱</br>
        /// <br>Date		: 2009.03.25</br>
        /// </remarks>
        public int SearchNext(int readCount)
        {
            return 0;
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// データ削除処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note        : 選択中のデータを削除します。(未実装)</br>
        /// <br>Programmer	: 張凱</br>
        /// <br>Date		: 2009.03.25</br>
        /// </remarks>
        public int Delete()
        {
            // オフライン状態チェック
            if (!CheckOnline())
            {
                TMsgDisp.Show(
                    emErrorLevel.ERR_LEVEL_STOP,
                    this.Text,
                    this.Text + "画面削除処理に失敗しました。",
                    (int)ConstantManagement.DB_Status.ctDB_OFFLINE, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                return 0;
            }

            // 保持しているデータセットより修正前情報取得
            Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this.DataIndex][VIEW_GUID_KEY_TITLE];
            EnterpriseSet enterpriseSet = (EnterpriseSet)this._enterpriseSetTable[guid];

            int status;

            // 企業コード設定情報論理削除処理
            status = this._enterpriseSetAcs.LogicalDelete(ref enterpriseSet);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        ExclusiveTransaction(status);
                        return status;
                    }
                default:
                    {
                        // 論理削除
                        TMsgDisp.Show(
                            this, 								// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOP, 		// エラーレベル
                            "PMKYO09110U", 						// アセンブリＩＤまたはクラスＩＤ
                            this.Text, 				            // プログラム名称
                            "Delete", 							// 処理名称
                            TMsgDisp.OPE_HIDE, 					// オペレーション
                            "削除に失敗しました。", 			// 表示するメッセージ
                            status, 							// ステータス値
                            this._enterpriseSetAcs, 				// エラーが発生したオブジェクト
                            MessageBoxButtons.OK, 				// 表示するボタン
                            MessageBoxDefaultButton.Button1);	// 初期表示ボタン
                        return status;
                    }
            }

            // 企業コード設定情報クラスデータセット展開処理
            EnterpriseSetToDataSet(enterpriseSet.Clone(), this.DataIndex);

            return status;
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// 印刷処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note        : 印刷処理を実行します。(未実装)</br>
        /// <br>Programmer	: 張凱</br>
        /// <br>Date		: 2009.03.25</br>
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
        /// <br>Programmer	: 張凱</br>
        /// <br>Date		: 2009.03.25</br>
        /// </remarks>
        public Hashtable GetAppearanceTable()
        {
            Hashtable appearanceTable = new Hashtable();
            // 削除日
            appearanceTable.Add(DELETE_DATE, new GridColAppearance(MGridColDispType.DeletionDataBoth, ContentAlignment.MiddleLeft, "", Color.Red));
            appearanceTable.Add(VIEW_SECTION_CODE_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(VIEW_SECTION_NAME_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(VIEW_ENTERPRISECODE_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));

            appearanceTable.Add(VIEW_GUID_KEY_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            return appearanceTable;
        }
        # endregion

        #region -- Private Methods --
        /// <summary>
        /// 画面再構築処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : モードに基づいて画面の再構築を行います。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009.03.25</br>
        /// </remarks>
        private void ScreenReconstruction()
        {
            if (this.DataIndex < 0)
            {
                EnterpriseSet enterpriseSet = new EnterpriseSet();
                //クローン作成
                this._enterpriseSetClone = enterpriseSet.Clone();

                this._indexBuf = this._dataIndex;

                this._tmpSectionCode = string.Empty;

                // 画面情報を比較用クローンにコピーします
                ScreenToEnterpriseSet(ref this._enterpriseSetClone);

                // 新規モード
                this.Mode_Label.Text = INSERT_MODE;

                // 画面入力許可制御処理
                ScreenInputPermissionControl(INSERT_MODE);

                // フォーカス設定
                this.tEdit_SectionCode.Focus();
            }
            else
            {
                // 保持しているデータセットより修正前情報取得
                Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this.DataIndex][VIEW_GUID_KEY_TITLE];
                EnterpriseSet enterpriseSet = (EnterpriseSet)this._enterpriseSetTable[guid];

                // 企業コード情報クラス画面展開処理
                EnterpriseSetToScreen(enterpriseSet);

                if (enterpriseSet.LogicalDeleteCode == 0)
                {
                    // 更新可能状態の時
                    this.Mode_Label.Text = UPDATE_MODE;

                    // 画面入力許可制御処理
                    ScreenInputPermissionControl(UPDATE_MODE);

                    // フォーカス設定
                    this.tEdit_PmEnterpriseCode.Focus();

                    // クローン作成
                    this._enterpriseSetClone = enterpriseSet.Clone();

                    // 画面情報を比較用クローンにコピーします　   
                    ScreenToEnterpriseSet(ref this._enterpriseSetClone);
                }
                else
                {
                    // 削除状態の時
                    this.Mode_Label.Text = DELETE_MODE;

                    this.Ok_Button.Visible = false;
                    this.Cancel_Button.Visible = true;
                    this.Delete_Button.Visible = true;
                    this.Revive_Button.Visible = true;

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
        /// <br>Note       : 画面の入力許可を制御します。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009.03.25</br>
        /// </remarks>
        private void ScreenInputPermissionControl(string mode)
        {
            switch (mode)
            {
                case INSERT_MODE:
                case UPDATE_MODE:
                    this.Ok_Button.Visible = true;
                    this.Cancel_Button.Visible = true;
                    this.Delete_Button.Visible = false;
                    this.Revive_Button.Visible = false;
                    this.SectionName_tEdit.Enabled = false;

                    if (mode == INSERT_MODE)
                    {
                        // 新規モード
                        this.tEdit_SectionCode.Enabled = true;
                        this.SectionGuide_Button.Enabled = true;
                        this.tEdit_PmEnterpriseCode.Enabled = true;
                    }
                    else
                    {
                        // 更新モード
                        this.tEdit_SectionCode.Enabled = false;
                        this.SectionGuide_Button.Enabled = false;
                        this.tEdit_PmEnterpriseCode.Enabled = true;
                    }

                    break;
                case DELETE_MODE:
                    this.Ok_Button.Visible = false;
                    this.Cancel_Button.Visible = true;
                    this.Delete_Button.Visible = true;
                    this.Revive_Button.Visible = true;
                    this.tEdit_SectionCode.Enabled = false;
                    this.SectionGuide_Button.Enabled = false;
                    this.SectionName_tEdit.Enabled = false;
                    this.tEdit_PmEnterpriseCode.Enabled = false;
                    break;
            }
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// 画面情報企業コード設定クラス格納処理
        /// </summary>
        /// <param name="enterpriseSet">企業コード設定オブジェクト</param>
        /// <remarks>
        /// <br>Note       : 画面情報から企業コード設定オブジェクトにデータを格納します。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date	   : 2009.03.25</br>
        /// </remarks>
        private void ScreenToEnterpriseSet(ref EnterpriseSet enterpriseSet)
        {
            if (enterpriseSet == null)
            {
                // 新規の場合
                enterpriseSet = new EnterpriseSet();
            }

            //企業コード
            enterpriseSet.EnterpriseCode = this._enterpriseCode;
            // 拠点コード
            enterpriseSet.SectionCode = this.tEdit_SectionCode.DataText;
            //PM企業コード
            enterpriseSet.PmEnterpriseCode = this.tEdit_PmEnterpriseCode.DataText;
        }



        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// データセット列情報構築処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : データセットの列情報を構築します。
        ///					 データセットの列情報がフレームのビュー用グリッドの列になります</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date	   : 2009.03.25</br>
        /// </remarks>
        private void DataSetColumnConstruction()
        {
            DataTable allDefSetTable = new DataTable(VIEW_TABLE);

            // Addを行う順番が、列の表示順位となります。
            allDefSetTable.Columns.Add(DELETE_DATE, typeof(string));			// 削除日
            allDefSetTable.Columns.Add(VIEW_SECTION_CODE_TITLE, typeof(string));
            allDefSetTable.Columns.Add(VIEW_SECTION_NAME_TITLE, typeof(string));
            allDefSetTable.Columns.Add(VIEW_ENTERPRISECODE_TITLE, typeof(string));

            allDefSetTable.Columns.Add(VIEW_GUID_KEY_TITLE, typeof(Guid));

            this.Bind_DataSet.Tables.Add(allDefSetTable);

        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// 画面クリア処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : 画面をクリアします。</br>
        /// <br>Programmer	: 張凱</br>
        /// <br>Date		: 2009.03.25</br>
        /// </remarks>
        private void ScreenClear()
        {
            this.tEdit_SectionCode.DataText = "";
            this.SectionName_tEdit.DataText = "";
            this.tEdit_PmEnterpriseCode.DataText = "";
            this._tmpSectionCode = string.Empty;
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// 企業コード設定クラス画面展開処理
        /// </summary>
        /// <param name="enterpriseSet">企業コード設定オブジェクト</param>
        /// <remarks>
        /// <br>Note       : 企業コード設定オブジェクトから画面にデータを展開します。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date	   : 2009.03.25</br>
        /// </remarks>
        private void EnterpriseSetToScreen(EnterpriseSet enterpriseSet)
        {
            // 拠点コード
            this.tEdit_SectionCode.Text = enterpriseSet.SectionCode.Trim();
            // 拠点名称
            string sectionName = string.Empty;
            if (enterpriseSet.SectionCode.Trim().Equals(ALL_SECTIONCODE))
            {
                sectionName = "全社共通";
            }
            else
            {
                sectionName = this._enterpriseSetAcs.GetSectionName(enterpriseSet.EnterpriseCode, enterpriseSet.SectionCode);
            }
            this.SectionName_tEdit.DataText = sectionName;
            //PM企業コード
            this.tEdit_PmEnterpriseCode.DataText = enterpriseSet.PmEnterpriseCode.Trim();
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        ///	企業コード設定画面入力チェック処理
        /// </summary>
        /// <remarks>
        /// <br>Note	   : 企業コード設定画面の入力チェックをします。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date	   : 2009.03.25</br>
        /// <br>Update Note : 芦珊 2011.08.02</br>
        /// <br>            : SCM対応‐拠点管理</br>
        /// </remarks>
        private int CheckDisplay(ref string checkMessage)
        {
            int returnStatus = 0;

            try
            {
                // 拠点コード
                if (this.tEdit_SectionCode.DataText.Trim() == "")
                {
                    checkMessage = "拠点コードが設定されていません。";
                    returnStatus = 10;
                    return returnStatus;
                }

                // PM企業コード
                if (this.tEdit_PmEnterpriseCode.DataText.Trim() == "")
                {
                    checkMessage = "企業コードが設定されていません。";
                    returnStatus = 20;
                    return returnStatus;
                }

                string reg = "^[0-9]*$";
                Regex regex = new Regex(reg);
                if (!regex.IsMatch(this.tEdit_PmEnterpriseCode.DataText.Trim()))
                {
                    checkMessage = "企業コードの設定が不正です。";
                    returnStatus = 20;
                    return returnStatus;

                }

                // 2010/08/02 lushan Del ＠チェック削除対応 ------------------------------- <<<<
                //if (this._enterpriseCode.Trim().Equals(this.tEdit_PmEnterpriseCode.DataText.Trim()))
                //{
                //    checkMessage = "自社の企業コードは設定できません。";
                //    returnStatus = 20;
                //    return returnStatus;
                //}
                // 2010/08/02 lushan Del ＠チェック削除対応 ------------------------------- <<<<

                return returnStatus;
            }
            finally
            {
                if (returnStatus != 0)
                {
                    TMsgDisp.Show(this,                         // 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,     // エラーレベル
                        "PMKYO09110U",							// アセンブリID
                        checkMessage,	                        // 表示するメッセージ
                        0,									    // ステータス値
                        MessageBoxButtons.OK);					// 表示するボタン
                }

                //エラーステータスに合わせてフォーカスセット
                switch (returnStatus)
                {
                    case 10:
                        {
                            this.tEdit_SectionCode.Focus();
                            break;
                        }
                    case 20:
                        {
                            this.tEdit_PmEnterpriseCode.Focus();
                            break;
                        }
                }
            }
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        ///　保存処理(SaveEnterpriseSet())
        /// </summary>
        /// <remarks>
        /// <br>Note　　　  : 保存処理を行います。</br>
        /// <br>Programmer	: 張凱</br>
        /// <br>Date		: 2009.03.25</br>
        /// </remarks>
        private bool SaveEnterpriseSet()
        {
            bool result = false;
            Control control = null;
            //画面データ入力チェック処理
            string checkMessage = "";
            int chkSt = CheckDisplay(ref checkMessage);
            if (chkSt != 0)
            {
                return result;
            }

            string enterprisetemp = this.tEdit_PmEnterpriseCode.DataText.Trim().PadRight(16, '0');

            if (!this._enterpriseCode.Substring(0, 14).Equals(enterprisetemp.Substring(0, 14)))
            {
                DialogResult resultConfirm = TMsgDisp.Show(
                    this, 								// 親ウィンドウフォーム
                    emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
                    "PMKYO09110U",						// アセンブリＩＤまたはクラスＩＤ
                    "ユーザーコードが異なります。" + "\r\n" +
                    "よろしいですか？", 				// 表示するメッセージ
                    0, 									// ステータス値
                    MessageBoxButtons.OKCancel,
                    MessageBoxDefaultButton.Button2);		// 表示するボタン

                if (resultConfirm != DialogResult.OK)
                {
                    this.tEdit_PmEnterpriseCode.Focus();
                    return false;
                }
            }

            EnterpriseSet enterpriseSet = null;

            if (this.DataIndex >= 0)
            {
                Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this._dataIndex][VIEW_GUID_KEY_TITLE];
                enterpriseSet = ((EnterpriseSet)this._enterpriseSetTable[guid]).Clone();
            }

            ScreenToEnterpriseSet(ref enterpriseSet);

            int status = this._enterpriseSetAcs.Write(ref enterpriseSet);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        this.ScreenClear();
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE:
                    {
                        RepeatTransaction(status, ref control);
                        control.Focus();
                        return false;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        ExclusiveTransaction(status);

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
                            "PMKYO09110U",							// アセンブリID
                            "企業設定",  　　                 // プログラム名称
                            "SaveEnterpriseSet",                       // 処理名称
                            TMsgDisp.OPE_UPDATE,                    // オペレーション
                            "登録に失敗しました。",				    // 表示するメッセージ
                            status,									// ステータス値
                            this._enterpriseSetAcs,				    	// エラーが発生したオブジェクト
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

            EnterpriseSetToDataSet(enterpriseSet, this.DataIndex);

            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }
            this.DialogResult = DialogResult.OK;
            this._indexBuf = -2;

            // 新規登録時
            if (this.Mode_Label.Text.Equals(UPDATE_MODE))
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

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// 企業コード設定オブジェクトデータセット展開処理
        /// </summary>
        /// <param name="allDefSet">企業コード設定オブジェクト</param>
        /// <param name="index">データセットへ展開するインデックス</param>
        /// <remarks>
        /// <br>Note       : 企業コード設定クラスをデータセットに格納します。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date	   : 2009.03.25</br>
        /// </remarks>
        private void EnterpriseSetToDataSet(EnterpriseSet enterpriseSet, int index)
        {
            if ((index < 0) || (this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Count <= index))
            {
                // 新規と判断して、行を追加する
                DataRow dataRow = this.Bind_DataSet.Tables[VIEW_TABLE].NewRow();
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Add(dataRow);
                // indexを行の最終行番号する
                index = this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Count - 1;
            }

            if (enterpriseSet.LogicalDeleteCode == 0)
            {
                // 更新可能状態の時
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][DELETE_DATE] = "";
            }
            else
            {
                // 削除状態の時
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][DELETE_DATE] = enterpriseSet.UpdateDateTimeJpInFormal;
            }

            // 拠点コード
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SECTION_CODE_TITLE] = enterpriseSet.SectionCode;

            string sectionName = GetSectionName(enterpriseSet.SectionCode);
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SECTION_NAME_TITLE] = sectionName;

            //PM企業コード
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_ENTERPRISECODE_TITLE] = enterpriseSet.PmEnterpriseCode;

            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_GUID_KEY_TITLE] = enterpriseSet.FileHeaderGuid;

            if (this._enterpriseSetTable.ContainsKey(enterpriseSet.FileHeaderGuid) == true)
            {
                this._enterpriseSetTable.Remove(enterpriseSet.FileHeaderGuid);
            }
            this._enterpriseSetTable.Add(enterpriseSet.FileHeaderGuid, enterpriseSet);
        }

        /// <summary>
        /// 同一データのメッセージ
        /// </summary>
        /// <remarks>
        /// <br>Note　　　  : 既に拠点管理設定マスタに同一データある場合、メッセージがある。</br>
        /// <br>Programmer  : 張凱</br>
        /// <br>Date        : 2009/03/30</br>
        /// </remarks>
        private void RepeatTransaction(int status, ref Control control)
        {
            TMsgDisp.Show(
                this, 								// 親ウィンドウフォーム
                emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
                "PMKYO09110U",						// アセンブリＩＤまたはクラスＩＤ
                "データが既に存在しています。", 	// 表示するメッセージ
                0, 									// ステータス値
                MessageBoxButtons.OK);				// 表示するボタン
            tEdit_SectionCode.Focus();

            control = tEdit_SectionCode;
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// 排他処理
        /// </summary>
        /// <param name="status">ステータス</param>
        /// <remarks>
        /// <br>Note       : データ更新時の排他処理を行います。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date	   : 2009.03.25</br>
        /// </remarks>
        private void ExclusiveTransaction(int status)
        {
            if (status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE
                || status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE)
            {
                TMsgDisp.Show(this,                         // 親ウィンドウフォーム
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,     // エラーレベル
                    "PMKYO09110U",							// アセンブリID
                    "既に他端末より更新されています。",	    // 表示するメッセージ
                    status,									// ステータス値
                    MessageBoxButtons.OK);					// 表示するボタン
            }
        }

        #endregion

        # region -- Control Events --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        ///	Form.Load イベント(SFCMN9080UA)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: ユーザーがフォームを読み込むときに発生します。</br>
        /// <br>Programmer	: 張凱</br>
        /// <br>Date		: 2009.03.26</br>
        /// </remarks>
        private void Form1_Load(object sender, EventArgs e)
        {
            // 画面スキンファイルの読込(デフォルトスキン指定)
            this._controlScreenSkin.LoadSkin();

            // 画面スキン変更
            this._controlScreenSkin.SettingScreenSkin(this);

            // アイコンリソース管理クラスを使用して、アイコンを表示する
            ImageList imageList24 = IconResourceManagement.ImageList24;
            ImageList imageList16 = IconResourceManagement.ImageList16;

            this.Ok_Button.ImageList = imageList24;
            this.Cancel_Button.ImageList = imageList24;

            this.Ok_Button.Appearance.Image = Size24_Index.SAVE;
            this.Cancel_Button.Appearance.Image = Size24_Index.CLOSE;

            this.SectionGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.Delete_Button.ImageList = imageList24;
            this.Revive_Button.ImageList = imageList24;
            this.Delete_Button.Appearance.Image = Size24_Index.DELETE;
            this.Revive_Button.Appearance.Image = Size24_Index.REVIVAL;

        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        ///	Form.Closing イベント(SFCMN09080UA)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">キャンセルできるイベントのデータを提供するクラス</param>
        /// <remarks>
        /// <br>Note		: フォームを閉じる前に、ユーザーがフォームを閉じ
        ///					  ようとしたときに発生します。</br>
        /// <br>Programmer	: 張凱</br>
        /// <br>Date		: 2009.03.26</br>
        /// </remarks>
        private void Form1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
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
        ///	Form.VisibleChanged イベント(SFCMN09080UA)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: フォームの表示・非表示が切り替えられ
        ///					  たときに発生します。</br>
        /// <br>Programmer	: 張凱</br>
        /// <br>Date		: 2009.03.26</br>
        /// </remarks>
        private void Form1_VisibleChanged(object sender, EventArgs e)
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

            ScreenClear();

            Timer.Enabled = true;

        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// Control.Click イベント(Ok_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　  : 保存ボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer	: 張凱</br>
        /// <br>Date		: 2009.03.26</br>
        /// </remarks>
        private void Ok_Button_Click(object sender, EventArgs e)
        {
            // オフライン状態チェック
            if (!CheckOnline())
            {
                TMsgDisp.Show(
                    emErrorLevel.ERR_LEVEL_STOP,
                    this.Text,
                    this.Text + "画面保存処理に失敗しました。",
                    (int)ConstantManagement.DB_Status.ctDB_OFFLINE, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                return;
            }

            if (!SaveEnterpriseSet())
            {
                return;
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
        /// <br>Programmer	: 張凱</br>
        /// <br>Date		: 2009.03.26</br>
        /// </remarks>
        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            // 削除モード・参照モード以外の場合は保存確認処理を行う
            if (this.Mode_Label.Text != DELETE_MODE)
            {
                // 画面のデータを取得する
                EnterpriseSet compareEnterpriseSet = new EnterpriseSet();

                compareEnterpriseSet = this._enterpriseSetClone.Clone();
                ScreenToEnterpriseSet(ref compareEnterpriseSet);

                // 画面情報と起動時のクローンと比較し変更を監視する
                if ((!(this._enterpriseSetClone.Equals(compareEnterpriseSet))))
                {
                    // 画面情報が変更されていた場合は、保存確認メッセージを表示
                    DialogResult res = TMsgDisp.Show(this,                    // 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_SAVECONFIRM,                   // エラーレベル
                        "PMKYO09110U", 			                              // アセンブリＩＤまたはクラスＩＤ
                        null, 					                              // 表示するメッセージ
                        0, 					                                  // ステータス値
                        MessageBoxButtons.YesNoCancel);	                      // 表示するボタン

                    switch (res)
                    {
                        case DialogResult.Yes:
                            {
                                if (!SaveEnterpriseSet())
                                {
                                    return;
                                }
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
        /// <br>Programmer	: 張凱</br>
        /// <br>Date		: 2009.03.26</br>
        /// </remarks>
        private void Timer_Tick(object sender, EventArgs e)
        {
            Timer.Enabled = false;

            ScreenReconstruction();
        }

        /// <summary>
        /// Control.Click イベント(SectionGuide_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　 : 拠点ガイドボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009.03.26</br>
        /// </remarks>
        private void SectionGuide_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                int status;
                SecInfoSetAcs secInfoSetAcs = new SecInfoSetAcs();
                SecInfoSet secInfoSet = new SecInfoSet();

                status = secInfoSetAcs.ExecuteGuid(this._enterpriseCode, false, out secInfoSet);
                if (status == 0)
                {
                    this.tEdit_SectionCode.DataText = secInfoSet.SectionCode.Trim();
                    this.SectionName_tEdit.DataText = secInfoSet.SectionGuideNm.Trim();
                    // 設定値を保存
                    this._tmpSectionCode = secInfoSet.SectionCode.Trim();

                    if (this.ModeChangeProc())
                    {
                        this.tEdit_PmEnterpriseCode.Focus();
                    }
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
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009.03.26</br>
        /// </remarks>
        private void Delete_Button_Click(object sender, EventArgs e)
        {
            // オフライン状態チェック
            if (!CheckOnline())
            {
                TMsgDisp.Show(
                    emErrorLevel.ERR_LEVEL_STOP,
                    this.Text,
                    this.Text + "画面完全削除処理に失敗しました。",
                    (int)ConstantManagement.DB_Status.ctDB_OFFLINE, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                return;
            }

            // 完全削除確認
            DialogResult result = TMsgDisp.Show(
                this, 								// 親ウィンドウフォーム
                emErrorLevel.ERR_LEVEL_QUESTION, // エラーレベル
                "PMKYO09110U",						// アセンブリＩＤまたはクラスＩＤ
                "データを削除します。" + "\r\n" +
                "よろしいですか？", 				// 表示するメッセージ
                0, 									// ステータス値
                MessageBoxButtons.OKCancel,
                MessageBoxDefaultButton.Button2);		// 表示するボタン

            if (result != DialogResult.OK)
            {
                this.Delete_Button.Focus();
                return;
            }

            // 保持しているデータセットより情報取得
            Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this.DataIndex][VIEW_GUID_KEY_TITLE];
            EnterpriseSet enterpriseSet = (EnterpriseSet)this._enterpriseSetTable[guid];

            // 拠点情報論理削除処理
            int status = this._enterpriseSetAcs.Delete(enterpriseSet);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this.DataIndex].Delete();
                        this._enterpriseSetTable.Remove(enterpriseSet.FileHeaderGuid);

                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        ExclusiveTransaction(status);
                        return;
                    }
                default:
                    {
                        // 物理削除
                        TMsgDisp.Show(
                            this, 								// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOP, 		// エラーレベル
                            "PMKYO09110U", 						// アセンブリＩＤまたはクラスＩＤ
                            this.Text, 				            // プログラム名称
                            "Delete_Button_Click", 				// 処理名称
                            TMsgDisp.OPE_DELETE, 				// オペレーション
                            "削除に失敗しました。", 			// 表示するメッセージ
                            status, 							// ステータス値
                            this._enterpriseSetAcs, 				// エラーが発生したオブジェクト
                            MessageBoxButtons.OK, 				// 表示するボタン
                            MessageBoxDefaultButton.Button1);	// 初期表示ボタン
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
        /// Control.Click イベント(Revive_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　 : 復活ボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009.03.26</br>
        /// </remarks>
        private void Revive_Button_Click(object sender, EventArgs e)
        {
            // オフライン状態チェック
            if (!CheckOnline())
            {
                TMsgDisp.Show(
                    emErrorLevel.ERR_LEVEL_STOP,
                    this.Text,
                    this.Text + "画面復活処理に失敗しました。",
                    (int)ConstantManagement.DB_Status.ctDB_OFFLINE, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                return;
            }

            // 復活処理確認
            DialogResult result = TMsgDisp.Show(
                this, 								// 親ウィンドウフォーム
                emErrorLevel.ERR_LEVEL_QUESTION, // エラーレベル
                "PMKYO09110U",						// アセンブリＩＤまたはクラスＩＤ
                "現在表示中の企業設定マスタを復活します。" + "\r\n" +
                "よろしいですか？", 				// 表示するメッセージ
                0, 									// ステータス値
                MessageBoxButtons.OKCancel,
                MessageBoxDefaultButton.Button2);		// 表示するボタン

            if (result != DialogResult.OK)
            {
                this.Revive_Button.Focus();
                return;
            }

            int status = 0;
            Guid guid;

            // 復活対象データ取得
            guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this._dataIndex][VIEW_GUID_KEY_TITLE];
            EnterpriseSet enterpriseSet = ((EnterpriseSet)this._enterpriseSetTable[guid]).Clone();

            // 復活
            status = this._enterpriseSetAcs.Revival(ref enterpriseSet);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // DataSet展開処理
                        EnterpriseSetToDataSet(enterpriseSet, this._dataIndex);
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        // 排他処理
                        ExclusiveTransaction(status);
                        return;
                    }
                default:
                    {
                        TMsgDisp.Show(
                            this,								// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOPDISP,    // エラーレベル
                            "PMKYO09110U",						// アセンブリＩＤまたはクラスＩＤ
                            this.Text,							// プログラム名称
                            "ReviveWarehouse",				    // 処理名称
                            TMsgDisp.OPE_UPDATE,				// オペレーション
                            "復活に失敗しました。",			    // 表示するメッセージ 
                            status,								// ステータス値
                            this._enterpriseSetAcs,				// エラーが発生したオブジェクト
                            MessageBoxButtons.OK,				// 表示するボタン
                            MessageBoxDefaultButton.Button1);	// 初期表示ボタン
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
        /// ChangeFocus イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        private void tRetKeyControl1_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null)
            {
                return;
            }

            switch (e.PrevCtrl.Name)
            {
                // 拠点コード
                case "tEdit_SectionCode":
                    {
                        // 入力無し
                        if (string.IsNullOrEmpty(this.tEdit_SectionCode.DataText.Trim()))
                        {
                            _tmpSectionCode = string.Empty;
                            this.SectionName_tEdit.DataText = string.Empty;

                            break;
                        }

                        // 入力変更なし
                        if (this.tEdit_SectionCode.DataText.Trim().Equals(_tmpSectionCode))
                        {
                            if (e.Key == Keys.Return || e.Key == Keys.Tab || e.Key == Keys.Right)
                            {
                                // 入力あり＆Tab遷移＆次がガイドボタンの場合、ガイドボタンは飛ばす
                                e.NextCtrl = this.tEdit_PmEnterpriseCode;
                            }

                            break;

                        }
                        else
                        {
                            // 拠点コード取得
                            string sectionCode = this.tEdit_SectionCode.DataText.Trim();

                            if (!string.IsNullOrEmpty(GetSectionName(sectionCode)))
                            {
                                // 結果を画面に設定
                                this.tEdit_SectionCode.Text = sectionCode;
                                this.SectionName_tEdit.DataText = GetSectionName(sectionCode);

                                // 設定値を保存
                                this._tmpSectionCode = sectionCode;
                            }
                            else
                            {
                                // 前回入力値を設定
                                this.tEdit_SectionCode.Text = this._tmpSectionCode;

                                TMsgDisp.Show(this,                         // 親ウィンドウフォーム
                                    emErrorLevel.ERR_LEVEL_EXCLAMATION,     // エラーレベル
                                    "PMKYO09110U",							// アセンブリID
                                    "指定した拠点コードは存在しません。",	    // 表示するメッセージ
                                    0,									    // ステータス値
                                    MessageBoxButtons.OK);					// 表示するボタン

                                return;
                            }

                            if (ModeChangeProc())
                            {
                                if (e.Key == Keys.Return || e.Key == Keys.Tab || e.Key == Keys.Right)
                                {
                                    // 入力あり＆Tab遷移＆次がガイドボタンの場合、ガイドボタンは飛ばす
                                    e.NextCtrl = this.tEdit_PmEnterpriseCode;
                                }
                            }
                            else
                            {
                                if (e.Key == Keys.Return || e.Key == Keys.Tab || e.Key == Keys.Right)
                                {
                                    // 入力あり＆Tab遷移＆次がガイドボタンの場合、ガイドボタンは飛ばす
                                    e.NextCtrl = this.tEdit_SectionCode;
                                }

                            }
                            break;
                        }
                    }
            }
        }

        /// <summary>
        /// 拠点名称取得処理
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <returns>拠点名称</returns>
        /// <remarks>
        /// <br>Note       : 拠点名称を取得します。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009.03.26</br>
        /// </remarks>
        private string GetSectionName(string sectionCode)
        {
            string sectionName = "";

            //if (sectionCode.Trim().PadLeft(2, '0') == ALL_SECTIONCODE)
            //{
            //    sectionName = "全社共通";
            //    return sectionName;
            //}

            ArrayList retList = new ArrayList();
            SecInfoAcs secInfoAcs = new SecInfoAcs();

            try
            {
                foreach (SecInfoSet secInfoSet in secInfoAcs.SecInfoSetList)
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
                sectionName = "";
            }

            return sectionName;
        }

        /// <summary>
        /// 拠点コードの存在チェック処理
        /// </summary>
        /// <returns>存在の判断</returns>
        /// <remarks>
        /// <br>Note       : 拠点コードの存在チェック処理します。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009.05.21</br>
        /// </remarks>
        private bool ModeChangeProc()
        {
            string iMsg = "入力されたコードの企業設定情報が既に登録されています。\n編集を行いますか？";
            string str2 = this.tEdit_SectionCode.Text.TrimEnd(new char[0]).PadLeft(2, '0');
            for (int i = 0; i < this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Count; i++)
            {
                string str3 = (string)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[i][VIEW_SECTION_CODE_TITLE];
                if (str2.Equals(str3.TrimEnd(new char[0])))
                {
                    if (((string)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[i][DELETE_DATE]) != "")
                    {
                        TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, "PMKYO09110U", "入力されたコードの企業設定情報は既に削除されています。", 0, MessageBoxButtons.OK);
                        this.tEdit_SectionCode.Clear();
                        this.SectionName_tEdit.Clear();
                        _tmpSectionCode = string.Empty;
                        return false;
                    }
                    if (str2 == "00")
                    {
                        iMsg = "入力されたコードの企業設定情報が既に登録されています。\n　【拠点名称：全社共通】\n編集を行いますか？";
                    }
                    switch (TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, "PMKYO09110U", iMsg, 0, MessageBoxButtons.YesNo))
                    {
                        case DialogResult.Yes:
                            this._dataIndex = i;
                            this.ScreenClear();
                            this.ScreenReconstruction();
                            return true;

                        case DialogResult.No:
                            this.tEdit_SectionCode.Clear();
                            this.SectionName_tEdit.Clear();
                            _tmpSectionCode = string.Empty;
                            return false;
                    }
                    return true;
                }
            }
            return true;
        }

        #endregion

        #region ◎ オフライン状態チェック処理
        /// <summary>				
        /// ログオン時オンライン状態チェック処理				
        /// </summary>				
        /// <returns>チェック処理結果</returns>				
        public static bool CheckOnline()
        {
            if (Broadleaf.Application.Common.LoginInfoAcquisition.OnlineFlag == false)
            {
                return false;
            }
            else
            {
                // ローカルエリア接続状態によるオンライン判定				
                if (CheckRemoteOn() == false)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>				
        /// リモート接続可能判定				
        /// </summary>				
        /// <returns>判定結果</returns>				
        private static bool CheckRemoteOn()
        {
            bool isLocalAreaConnected = NetworkInterface.GetIsNetworkAvailable();

            if (isLocalAreaConnected == false)
            {
                // インターネット接続不能状態				
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion
    }
}