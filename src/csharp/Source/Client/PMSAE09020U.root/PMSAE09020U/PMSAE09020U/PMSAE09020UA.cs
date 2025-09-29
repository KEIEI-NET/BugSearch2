//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 商品コード変換マスタメンテナンス
// プログラム概要   : 商品コード変換マスタの登録・変更・削除を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張凱
// 作 成 日  2009/08/04  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張凱
// 修 正 日  2009/09/02  修正内容 : PVCS#425 グリッド表示の変更
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : zhuhh
// 修 正 日  2012/12/07  修正内容 : Ｓ＆ＥブレーキＡＢ商品コードの桁数の改修
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
    /// 商品コード変換マスタ
    /// </summary>
    /// <remarks>
    /// <br>Note		: 商品コード変換設定を行います。
    ///					  IMasterMaintenanceMultiTypeを実装しています。</br>   
    /// <br>Programmer	: 張凱</br>
    /// <br>Date		: 2009.08.05</br>
    /// <br>UpdateNote  : 2012/12/07 zhuhh</br>
    /// <br>            : Ｓ＆ＥブレーキＡＢ商品コードの桁数の改修</br>
    /// <br></br>
    /// </remarks>
    public partial class PMSAE09020UA : System.Windows.Forms.Form, IMasterMaintenanceMultiType
    {

        #region -- Constructor --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// 商品コード変換フォームクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note		: 商品コード変換フォームクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer	: 張凱</br>
        /// <br>Date		: 2009.08.05</br>
        /// </remarks>
        public PMSAE09020UA()
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
            this.flag = true;

            //　企業コード取得
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            this._blGoodsCdAcs = new BLGoodsCdAcs();

            // 変数初期化
            this._dataIndex = -1;
            this._bLGoodsCodeSetAcs = new BLGoodsCodeSetAcs();
            this._totalCount = 0;
            this._bLGoodsCodeSetTable = new Hashtable();

            //_dataIndexバッファ（メインフレーム最小化対応）
            this._indexBuf = -2;

            // 各種マスタ読込
            LoadBLGoodsCdUMnt();
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
        private BLGoodsCodeSetAcs _bLGoodsCodeSetAcs;
        private BLGoodsCdAcs _blGoodsCdAcs = null;			// BLアクセスクラス
        private int _totalCount;
        private string _enterpriseCode;
        private Hashtable _bLGoodsCodeSetTable;

        /// <summary>画面デザイン変更クラス</summary>
        private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();

        // 保存比較用Clone
        private SAndEGoodsCdChg _sAndEGoodsCdChgClone;

        private Dictionary<int, BLGoodsCdUMnt> _blGoodsCdUMntDic;

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

        // FrameのView用Grid列のKEY情報 (HeaderのTitle部となります)
        private const string DELETE_DATE = "削除日";
        private const string VIEW_BLGOODS_CODE_TITLE = "BLｺｰﾄﾞ";
        private const string VIEW_BLGOODS_NAME_TITLE = "BLｺｰﾄﾞ名";
        private const string VIEW_ABGOODSCODE_TITLE = "商品ｺｰﾄﾞ";
        private const string VIEW_GUID_KEY_TITLE = "Guid";

        // 抽出条件前回入力値(更新有無チェック用)
        private string _tmpBLCode;

        private Control _prevControl = null;

        private bool flag = false;

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
        /// <br>Date		: 2009.08.05</br>
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
        /// <br>Date		: 2009.08.05</br>
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
            ArrayList bLCodeList = null;

            this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Clear();
            this._bLGoodsCodeSetTable.Clear();

            // 全検索
            status = this._bLGoodsCodeSetAcs.SearchAll(out bLCodeList, this._enterpriseCode);

            //検索数
            this._totalCount = bLCodeList.Count;

            switch (status)
            {
                case (int)ConstantManagement.MethodResult.ctFNC_NORMAL:
                    {
                        int index = 0;

                        foreach (SAndEGoodsCdChg sAndEGoodsCdSet in bLCodeList)
                        {
                            SAndEGoodsCdSetToDataSet(sAndEGoodsCdSet.Clone(), index);
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
                            "PMSAE09020U",							// アセンブリID
                            "商品コード変換",              　　   // プログラム名称
                            "Search",                               // 処理名称
                            TMsgDisp.OPE_GET,                       // オペレーション
                            "読み込みに失敗しました。",				// 表示するメッセージ
                            status,									// ステータス値
                            this._bLGoodsCodeSetAcs,					    // エラーが発生したオブジェクト
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
        /// <br>Date		: 2009.08.05</br>
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
        /// <br>Note        : 選択中のデータを削除します。</br>
        /// <br>Programmer	: 張凱</br>
        /// <br>Date		: 2009.08.05</br>
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
            SAndEGoodsCdChg sAndEGoodsCdChg = (SAndEGoodsCdChg)this._bLGoodsCodeSetTable[guid];

            int status;

            // 商品コード変換マスタ情報論理削除処理
            status = this._bLGoodsCodeSetAcs.LogicalDelete(ref sAndEGoodsCdChg);

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
                            "PMSAE09020U", 						// アセンブリＩＤまたはクラスＩＤ
                            this.Text, 				            // プログラム名称
                            "Delete", 							// 処理名称
                            TMsgDisp.OPE_HIDE, 					// オペレーション
                            "オートバックス商品コード変換マスタ削除処理に失敗しました。", 			// 表示するメッセージ
                            status, 							// ステータス値
                            this._bLGoodsCodeSetAcs, 				// エラーが発生したオブジェクト
                            MessageBoxButtons.OK, 				// 表示するボタン
                            MessageBoxDefaultButton.Button1);	// 初期表示ボタン
                        return status;
                    }
            }

            // 商品コード変換マスタ情報クラスデータセット展開処理
            SAndEGoodsCdSetToDataSet(sAndEGoodsCdChg.Clone(), this.DataIndex);

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
        /// <br>Date		: 2009.08.05</br>
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
        /// <br>Date		: 2009.08.05</br>
        /// </remarks>
        public Hashtable GetAppearanceTable()
        {
            Hashtable appearanceTable = new Hashtable();
            // 削除日
            appearanceTable.Add(DELETE_DATE, new GridColAppearance(MGridColDispType.DeletionDataBoth, ContentAlignment.MiddleLeft, "", Color.Red));
            appearanceTable.Add(VIEW_BLGOODS_CODE_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));// ADD 2009/09/02
            appearanceTable.Add(VIEW_BLGOODS_NAME_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(VIEW_ABGOODSCODE_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));// ADD 2009/09/02

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
        /// <br>Date       : 2009.08.05</br>
        /// </remarks>
        private void ScreenReconstruction()
        {
            if (this.DataIndex < 0)
            {
                SAndEGoodsCdChg sAndEGoodsCdChg = new SAndEGoodsCdChg();
                //クローン作成
                this._sAndEGoodsCdChgClone = sAndEGoodsCdChg.Clone();

                this._indexBuf = this._dataIndex;

                this._tmpBLCode = string.Empty;

                // 画面情報を比較用クローンにコピーします
                ScreenToSAndEGoodsCdChg(ref this._sAndEGoodsCdChgClone);

                // 新規モード
                this.Mode_Label.Text = INSERT_MODE;

                // 画面入力許可制御処理
                ScreenInputPermissionControl(INSERT_MODE);

                // フォーカス設定
                this.tNedit_BLGoodsCode.Focus();
            }
            else
            {
                // 保持しているデータセットより修正前情報取得
                Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this.DataIndex][VIEW_GUID_KEY_TITLE];
                SAndEGoodsCdChg sAndEGoodsCdChgSet = (SAndEGoodsCdChg)this._bLGoodsCodeSetTable[guid];

                if (sAndEGoodsCdChgSet.LogicalDeleteCode == 0)
                {
                    // 更新可能状態の時
                    this.Mode_Label.Text = UPDATE_MODE;

                    // 画面入力許可制御処理
                    ScreenInputPermissionControl(UPDATE_MODE);

                    // フォーカス設定
                    this.tEdit_ABGoodsCode.Focus();

                    // 商品コード変換情報クラス画面展開処理
                    SAndEGoodsCdChgToScreen(sAndEGoodsCdChgSet);

                    // クローン作成
                    this._sAndEGoodsCdChgClone = sAndEGoodsCdChgSet.Clone();

                    // 画面情報を比較用クローンにコピーします　   
                    ScreenToSAndEGoodsCdChg(ref this._sAndEGoodsCdChgClone);
                }
                else
                {
                    // 削除状態の時
                    this.Mode_Label.Text = DELETE_MODE;

                    // 画面入力許可制御処理
                    ScreenInputPermissionControl(DELETE_MODE);

                    // フォーカス設定
                    this.Delete_Button.Focus();

                    // 商品コード変換情報クラス画面展開処理
                    SAndEGoodsCdChgToScreen(sAndEGoodsCdChgSet);
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
        /// <br>Date       : 2009.08.05</br>
        /// </remarks>
        private void ScreenInputPermissionControl(string mode)
        {
            switch (mode)
            {
                case INSERT_MODE:
                case UPDATE_MODE:
                    this.Renewal_Button.Visible = true;
                    this.Ok_Button.Visible = true;
                    this.Cancel_Button.Visible = true;
                    this.Delete_Button.Visible = false;
                    this.Revive_Button.Visible = false;
                    this.tEdit_BLGoodsHalfName.Enabled = false;

                    if (mode == INSERT_MODE)
                    {
                        // 新規モード
                        this.tNedit_BLGoodsCode.Enabled = true;
                        this.BLGoodsGuide_Button.Enabled = true;
                        this.tEdit_ABGoodsCode.Enabled = true;
                    }
                    else
                    {
                        // 更新モード
                        this.tNedit_BLGoodsCode.Enabled = false;
                        this.BLGoodsGuide_Button.Enabled = false;
                        this.tEdit_ABGoodsCode.Enabled = true;
                    }

                    break;
                case DELETE_MODE:
                    this.Ok_Button.Visible = false;
                    this.Renewal_Button.Visible = false;
                    this.Cancel_Button.Visible = true;
                    this.Delete_Button.Visible = true;
                    this.Revive_Button.Visible = true;
                    this.tNedit_BLGoodsCode.Enabled = false;
                    this.BLGoodsGuide_Button.Enabled = false;
                    this.tEdit_BLGoodsHalfName.Enabled = false;
                    this.tEdit_ABGoodsCode.Enabled = false;
                    break;
            }
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// 画面情報商品コード変換クラス格納処理
        /// </summary>
        /// <param name="sAndEGoodsCdChg">商品コード変換オブジェクト</param>
        /// <remarks>
        /// <br>Note       : 画面情報から商品コード変換オブジェクトにデータを格納します。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date	   : 2009.08.05</br>
        /// <br>UpdateNote : 2012/12/07 zhuhh</br>
        /// <br>           : Ｓ＆ＥブレーキＡＢ商品コードの桁数の改修</br>
        /// </remarks>
        private void ScreenToSAndEGoodsCdChg(ref SAndEGoodsCdChg sAndEGoodsCdChg)
        {
            if (sAndEGoodsCdChg == null)
            {
                // 新規の場合
                sAndEGoodsCdChg = new SAndEGoodsCdChg();
            }

            //企業コード
            sAndEGoodsCdChg.EnterpriseCode = this._enterpriseCode;
            //BLｺｰﾄﾞ
            sAndEGoodsCdChg.BLGoodsCode = this.tNedit_BLGoodsCode.GetInt();
            //商品ｺｰﾄﾞ
            //sAndEGoodsCdChg.ABGoodsCode = this.tEdit_ABGoodsCode.Text.PadLeft(6, '0');// DEL zhuhh 2012/12/07 ＡＢ商品コードの桁数の改修
            sAndEGoodsCdChg.ABGoodsCode = this.tEdit_ABGoodsCode.Text.PadLeft(8, '0');// ADD zhuhh 2012/12/07 ＡＢ商品コードの桁数の改修
            //BLｺｰﾄﾞ名
            sAndEGoodsCdChg.BLGoodsHalfName = this.tEdit_BLGoodsHalfName.DataText;
        }

        /// <summary>
        /// BLコードマスタ読込処理
        /// </summary>
        private void LoadBLGoodsCdUMnt()
        {
            this._blGoodsCdUMntDic = new Dictionary<int, BLGoodsCdUMnt>();

            try
            {
                ArrayList retList;

                int status = this._blGoodsCdAcs.SearchAll(out retList, this._enterpriseCode);
                if (status == 0)
                {
                    foreach (BLGoodsCdUMnt blGoodsCdUMnt in retList)
                    {
                        if (blGoodsCdUMnt.LogicalDeleteCode == 0)
                        {
                            this._blGoodsCdUMntDic.Add(blGoodsCdUMnt.BLGoodsCode, blGoodsCdUMnt);
                        }
                    }
                }
            }
            catch
            {
                this._blGoodsCdUMntDic = new Dictionary<int, BLGoodsCdUMnt>();
            }
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// データセット列情報構築処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : データセットの列情報を構築します。
        ///					 データセットの列情報がフレームのビュー用グリッドの列になります</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date	   : 2009.08.05</br>
        /// </remarks>
        private void DataSetColumnConstruction()
        {
            DataTable allDefSetTable = new DataTable(VIEW_TABLE);

            // Addを行う順番が、列の表示順位となります。
            allDefSetTable.Columns.Add(DELETE_DATE, typeof(string));			// 削除日
            allDefSetTable.Columns.Add(VIEW_BLGOODS_CODE_TITLE, typeof(string));
            allDefSetTable.Columns.Add(VIEW_BLGOODS_NAME_TITLE, typeof(string));
            allDefSetTable.Columns.Add(VIEW_ABGOODSCODE_TITLE, typeof(string));

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
        /// <br>Date		: 2009.08.05</br>
        /// </remarks>
        private void ScreenClear()
        {
            this.tNedit_BLGoodsCode.DataText = "";
            this.tEdit_BLGoodsHalfName.DataText = "";
            this.tEdit_ABGoodsCode.DataText = "";
            this._tmpBLCode = string.Empty;
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// 商品コード変換クラス画面展開処理
        /// </summary>
        /// <param name="sAndEGoodsCdChg">商品コード変換オブジェクト</param>
        /// <remarks>
        /// <br>Note       : 商品コード変換オブジェクトから画面にデータを展開します。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date	   : 2009.08.05</br>
        /// <br>UpdateNote : 2012/12/07 zhuhh</br>
        /// <br>           : Ｓ＆ＥブレーキＡＢ商品コードの桁数の改修</br>
        /// </remarks>
        private void SAndEGoodsCdChgToScreen(SAndEGoodsCdChg sAndEGoodsCdChg)
        {
            // BLｺｰﾄﾞ
            this.tNedit_BLGoodsCode.Text = sAndEGoodsCdChg.BLGoodsCode.ToString().PadLeft(5, '0');
            // BLｺｰﾄﾞ名
            this.tEdit_BLGoodsHalfName.Text = sAndEGoodsCdChg.BLGoodsHalfName.Trim();
            // 商品ｺｰﾄﾞ
            //this.tEdit_ABGoodsCode.DataText = sAndEGoodsCdChg.ABGoodsCode;// DEL zhuhh 2012/12/07 ＡＢ商品コードの桁数の改修
            this.tEdit_ABGoodsCode.DataText = sAndEGoodsCdChg.ABGoodsCode.PadLeft(8, '0');// ADD zhuhh 2012/12/07 ＡＢ商品コードの桁数の改修
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        ///	商品コード変換画面入力チェック処理
        /// </summary>
        /// <remarks>
        /// <br>Note	   : 商品コード変換画面の入力チェックをします。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date	   : 2009.08.05</br>
        /// </remarks>
        private int CheckDisplay(ref string checkMessage)
        {
            int returnStatus = 0;

            try
            {
                // BLｺｰﾄﾞ
                if (this.tNedit_BLGoodsCode.DataText.Trim() == "")
                {
                    checkMessage = "BLｺｰﾄﾞを設定して下さい。";
                    returnStatus = 10;
                    return returnStatus;
                }

                // 商品ｺｰﾄﾞ
                if (this.tEdit_ABGoodsCode.DataText.Trim() == "")
                {
                    checkMessage = "商品ｺｰﾄﾞを設定して下さい。";
                    returnStatus = 20;
                    return returnStatus;
                }

                string reg = "^[0-9]*$";
                Regex regex = new Regex(reg);
                if (!regex.IsMatch(this.tEdit_ABGoodsCode.DataText.Trim()))
                {
                    checkMessage = "商品ｺｰﾄﾞの設定が不正です。";
                    returnStatus = 20;
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
                        "PMSAE09020U",							// アセンブリID
                        checkMessage,	                        // 表示するメッセージ
                        0,									    // ステータス値
                        MessageBoxButtons.OK);					// 表示するボタン
                }

                //エラーステータスに合わせてフォーカスセット
                switch (returnStatus)
                {
                    case 10:
                        {
                            this.tNedit_BLGoodsCode.Focus();
                            break;
                        }
                    case 20:
                        {
                            this.tEdit_ABGoodsCode.Focus();
                            break;
                        }
                }
            }
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        ///　保存処理(SaveSAndEGoodsCdChg())
        /// </summary>
        /// <remarks>
        /// <br>Note　　　  : 保存処理を行います。</br>
        /// <br>Programmer	: 張凱</br>
        /// <br>Date		: 2009.08.05</br>
        /// </remarks>
        private bool SaveSAndEGoodsCdChg()
        {
            if (this._prevControl != null)
            {
                ChangeFocusEventArgs e2 = new ChangeFocusEventArgs(false, false, false, Keys.Return, this._prevControl, this._prevControl);
                this.tRetKeyControl1_ChangeFocus(this, e2);
            }

            if (this.flag == false)
            {
                return false;
            }

            bool result = false;
            Control control = null;
            //画面データ入力チェック処理
            string checkMessage = "";
            int chkSt = CheckDisplay(ref checkMessage);
            if (chkSt != 0)
            {
                return result;
            }

            SAndEGoodsCdChg sAndEGoodsCdChg = null;

            if (this.DataIndex >= 0)
            {
                Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this._dataIndex][VIEW_GUID_KEY_TITLE];
                sAndEGoodsCdChg = ((SAndEGoodsCdChg)this._bLGoodsCodeSetTable[guid]).Clone();
            }

            //画面データセット
            ScreenToSAndEGoodsCdChg(ref sAndEGoodsCdChg);

            //保存処理
            int status = this._bLGoodsCodeSetAcs.Write(ref sAndEGoodsCdChg);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        this.ScreenClear();
                        tNedit_BLGoodsCode.Focus();
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
                            "PMSAE09020U",							// アセンブリID
                            "商品コード変換マスタ",  　　                 // プログラム名称
                            "SaveSAndEGoodsCdChg",                       // 処理名称
                            TMsgDisp.OPE_UPDATE,                    // オペレーション
                            "オートバックス商品コード変換マスタ登録処理に失敗しました。",				    // 表示するメッセージ
                            status,									// ステータス値
                            this._bLGoodsCodeSetAcs,				    	// エラーが発生したオブジェクト
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

            //商品コード変換オブジェクトデータセット展開処理
            SAndEGoodsCdSetToDataSet(sAndEGoodsCdChg, this.DataIndex);

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
        ///商品コード変換オブジェクトデータセット展開処理
        /// </summary>
        /// <param name="sAndEGoodsCdChg">商品コード変換オブジェクト</param>
        /// <param name="index">データセットへ展開するインデックス</param>
        /// <remarks>
        /// <br>Note       : 商品コード変換クラスをデータセットに格納します。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date	   : 2009.08.05</br>
        /// <br>UpdateNote : 2012/12/07 zhuhh</br>
        /// <br>           : Ｓ＆ＥブレーキＡＢ商品コードの桁数の改修</br>
        /// </remarks>
        private void SAndEGoodsCdSetToDataSet(SAndEGoodsCdChg sAndEGoodsCdChg, int index)
        {
            if ((index < 0) || (this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Count <= index))
            {
                // 新規と判断して、行を追加する
                DataRow dataRow = this.Bind_DataSet.Tables[VIEW_TABLE].NewRow();
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Add(dataRow);
                // indexを行の最終行番号する
                index = this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Count - 1;
            }

            if (sAndEGoodsCdChg.LogicalDeleteCode == 0)
            {
                // 更新可能状態の時
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][DELETE_DATE] = "";
            }
            else
            {
                // 削除状態の時
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][DELETE_DATE] = sAndEGoodsCdChg.UpdateDateTimeJpInFormal;
            }

            // BLｺｰﾄﾞ
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_BLGOODS_CODE_TITLE] = sAndEGoodsCdChg.BLGoodsCode.ToString().PadLeft(5, '0');

            //BLｺｰﾄﾞ名
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_BLGOODS_NAME_TITLE] = sAndEGoodsCdChg.BLGoodsHalfName;

            //商品ｺｰﾄﾞ
            //this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_ABGOODSCODE_TITLE] = sAndEGoodsCdChg.ABGoodsCode;// DEL zhuhh 2012/12/07 ＡＢ商品コードの桁数の改修
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_ABGOODSCODE_TITLE] = sAndEGoodsCdChg.ABGoodsCode.PadLeft(8, '0');// ADD zhuhh 2012/12/07 ＡＢ商品コードの桁数の改修
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_GUID_KEY_TITLE] = sAndEGoodsCdChg.FileHeaderGuid;

            if (this._bLGoodsCodeSetTable.ContainsKey(sAndEGoodsCdChg.FileHeaderGuid) == true)
            {
                this._bLGoodsCodeSetTable.Remove(sAndEGoodsCdChg.FileHeaderGuid);
            }
            this._bLGoodsCodeSetTable.Add(sAndEGoodsCdChg.FileHeaderGuid, sAndEGoodsCdChg);
        }

        /// <summary>
        /// 同一データのメッセージ
        /// </summary>
        /// <param name="status">スデータス</param>
        /// <param name="control">コントロール</param>
        /// <remarks>
        /// <br>Note　　　  : 既に商品コード変換マスタに同一データある場合、メッセージがある。</br>
        /// <br>Programmer  : 張凱</br>
        /// <br>Date        : 2009/08/05</br>
        /// </remarks>
        private void RepeatTransaction(int status, ref Control control)
        {
            TMsgDisp.Show(
                this, 								// 親ウィンドウフォーム
                emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
                "PMSAE09020U",						// アセンブリＩＤまたはクラスＩＤ
                "データが既に存在しています。", 	// 表示するメッセージ
                0, 									// ステータス値
                MessageBoxButtons.OK);				// 表示するボタン
            tNedit_BLGoodsCode.Focus();

            control = tNedit_BLGoodsCode;
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// 排他処理
        /// </summary>
        /// <param name="status">ステータス</param>
        /// <remarks>
        /// <br>Note       : データ更新時の排他処理を行います。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date	   : 2009.08.05</br>
        /// </remarks>
        private void ExclusiveTransaction(int status)
        {
            if (status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE
                || status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE)
            {
                TMsgDisp.Show(this,                         // 親ウィンドウフォーム
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,     // エラーレベル
                    "PMSAE09020U",							// アセンブリID
                    "既に他端末より更新されています。",	    // 表示するメッセージ
                    status,									// ステータス値
                    MessageBoxButtons.OK);					// 表示するボタン
            }
        }

        #endregion

        # region -- Control Events --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        ///	Form.Load イベント(PMSAE09020UA)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: ユーザーがフォームを読み込むときに発生します。</br>
        /// <br>Programmer	: 張凱</br>
        /// <br>Date		: 2009.08.06</br>
        /// </remarks>
        private void PMSAE09020U_Load(object sender, EventArgs e)
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
            this.Renewal_Button.ImageList = imageList16;

            this.Ok_Button.Appearance.Image = Size24_Index.SAVE;
            this.Cancel_Button.Appearance.Image = Size24_Index.CLOSE;

            this.BLGoodsGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.Delete_Button.ImageList = imageList24;
            this.Revive_Button.ImageList = imageList24;
            this.Delete_Button.Appearance.Image = Size24_Index.DELETE;
            this.Revive_Button.Appearance.Image = Size24_Index.REVIVAL;
            this.Renewal_Button.Appearance.Image = Size16_Index.RENEWAL;

        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        ///	Form.Closing イベント(PMSAE09020U)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">キャンセルできるイベントのデータを提供するクラス</param>
        /// <remarks>
        /// <br>Note		: フォームを閉じる前に、ユーザーがフォームを閉じ
        ///					  ようとしたときに発生します。</br>
        /// <br>Programmer	: 張凱</br>
        /// <br>Date		: 2009.08.06</br>
        /// </remarks>
        private void PMSAE09020U_Closing(object sender, System.ComponentModel.CancelEventArgs e)
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
        ///	Form.VisibleChanged イベント(PMSAE09020U)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: フォームの表示・非表示が切り替えられ
        ///					  たときに発生します。</br>
        /// <br>Programmer	: 張凱</br>
        /// <br>Date		: 2009.08.06</br>
        /// </remarks>
        private void PMSAE09020U_VisibleChanged(object sender, EventArgs e)
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
        /// <br>Date		: 2009.08.06</br>
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

            if (!SaveSAndEGoodsCdChg())
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
        /// <br>Date		: 2009.08.06</br>
        /// </remarks>
        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            // 削除モード・参照モード以外の場合は保存確認処理を行う
            if (this.Mode_Label.Text != DELETE_MODE)
            {
                // 画面のデータを取得する
                SAndEGoodsCdChg compareSAndEGoodsCdChg = new SAndEGoodsCdChg();

                compareSAndEGoodsCdChg = this._sAndEGoodsCdChgClone.Clone();
                ScreenToSAndEGoodsCdChg(ref compareSAndEGoodsCdChg);

                // 画面情報と起動時のクローンと比較し変更を監視する
                if ((!(this._sAndEGoodsCdChgClone.Equals(compareSAndEGoodsCdChg))))
                {
                    // 画面情報が変更されていた場合は、保存確認メッセージを表示
                    DialogResult res = TMsgDisp.Show(this,                    // 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_SAVECONFIRM,                   // エラーレベル
                        "PMSAE09020U", 			                              // アセンブリＩＤまたはクラスＩＤ
                        null, 					                              // 表示するメッセージ
                        0, 					                                  // ステータス値
                        MessageBoxButtons.YesNoCancel);	                      // 表示するボタン

                    switch (res)
                    {
                        case DialogResult.Yes:
                            {
                                if (!SaveSAndEGoodsCdChg())
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
        /// <br>Date		: 2009.08.06</br>
        /// </remarks>
        private void Timer_Tick(object sender, EventArgs e)
        {
            Timer.Enabled = false;

            ScreenReconstruction();
        }

        /// <summary>
        /// Control.Click イベント(BLGoodsGuide_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　 : BLガイドボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009.08.06</br>
        /// </remarks>
        private void BLGoodsGuide_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                int status;
                BLGoodsCdUMnt blGoodsCdUMnt = new BLGoodsCdUMnt();

                // BLコードガイド表示
                status = this._blGoodsCdAcs.ExecuteGuid(this._enterpriseCode, out blGoodsCdUMnt);
                if (status == 0)
                {
                    this.tNedit_BLGoodsCode.DataText = blGoodsCdUMnt.BLGoodsCode.ToString();
                    this.tEdit_BLGoodsHalfName.DataText = blGoodsCdUMnt.BLGoodsHalfName.Trim();
                    // 設定値を保存
                    this._tmpBLCode = blGoodsCdUMnt.BLGoodsCode.ToString().Trim();

                    if (this.ModeChangeProc())
                    {
                        this.tEdit_ABGoodsCode.Focus();
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
        /// <br>Date       : 2009.08.06</br>
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
                "PMSAE09020U",						// アセンブリＩＤまたはクラスＩＤ
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
            SAndEGoodsCdChg sAndEGoodsCdChg = (SAndEGoodsCdChg)this._bLGoodsCodeSetTable[guid];

            //商品コード変換論理削除処理
            int status = this._bLGoodsCodeSetAcs.Delete(sAndEGoodsCdChg);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this.DataIndex].Delete();
                        this._bLGoodsCodeSetTable.Remove(sAndEGoodsCdChg.FileHeaderGuid);

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
                            "PMSAE09020U", 						// アセンブリＩＤまたはクラスＩＤ
                            this.Text, 				            // プログラム名称
                            "Delete_Button_Click", 				// 処理名称
                            TMsgDisp.OPE_DELETE, 				// オペレーション
                            "オートバックス商品コード変換マスタ完全削除処理失敗しました。", 			// 表示するメッセージ
                            status, 							// ステータス値
                            this._bLGoodsCodeSetAcs, 				// エラーが発生したオブジェクト
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
        /// <br>Date       : 2009.08.06</br>
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
                "PMSAE09020U",						// アセンブリＩＤまたはクラスＩＤ
                "現在表示中のオートバックス商品コード変換マスタを復活します。" + "\r\n" +
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
            SAndEGoodsCdChg sAndEGoodsCdChg = ((SAndEGoodsCdChg)this._bLGoodsCodeSetTable[guid]).Clone();

            // 復活
            status = this._bLGoodsCodeSetAcs.Revival(ref sAndEGoodsCdChg);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // DataSet展開処理
                        SAndEGoodsCdSetToDataSet(sAndEGoodsCdChg, this._dataIndex);
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
                            "PMSAE09020U",						// アセンブリＩＤまたはクラスＩＤ
                            this.Text,							// プログラム名称
                            "Revival",				    // 処理名称
                            TMsgDisp.OPE_UPDATE,				// オペレーション
                            "オートバックス商品コード変換マスタ復活処理に失敗しました。",			    // 表示するメッセージ 
                            status,								// ステータス値
                            this._bLGoodsCodeSetAcs,				// エラーが発生したオブジェクト
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
        /// Control.Click イベント(Renewal_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　 : 最新情報ボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009.08.06</br>
        /// </remarks>
        private void Renewal_Button_Click(object sender, EventArgs e)
        {
            this.LoadBLGoodsCdUMnt();
            TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, "PMSAE09020U", "最新情報を取得しました。", 0, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
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

            this._prevControl = e.NextCtrl;

            this.flag = true;

            switch (e.PrevCtrl.Name)
            {
                // BLコード
                case "tNedit_BLGoodsCode":
                    {
                        // 入力無し
                        if (string.IsNullOrEmpty(this.tNedit_BLGoodsCode.DataText.Trim()))
                        {
                            _tmpBLCode = string.Empty;
                            this.tEdit_BLGoodsHalfName.DataText = string.Empty;

                            break;
                        }

                        // 入力変更なし
                        if (this.tNedit_BLGoodsCode.DataText.Trim().Equals(_tmpBLCode))
                        {
                            // 入力あり＆Tab遷移＆次がガイドボタンの場合、ガイドボタンは飛ばす
                            e.NextCtrl = this.tEdit_ABGoodsCode;

                            break;

                        }
                        else
                        {
                            // BLコード取得
                            int blGoodsCode = this.tNedit_BLGoodsCode.GetInt();

                            if (!string.IsNullOrEmpty(GetBLGoodsName(blGoodsCode)))
                            {
                                // 結果を画面に設定
                                this.tNedit_BLGoodsCode.Text = blGoodsCode.ToString();
                                this.tEdit_BLGoodsHalfName.DataText = GetBLGoodsName(blGoodsCode);

                                // 設定値を保存
                                this._tmpBLCode = blGoodsCode.ToString();
                            }
                            else
                            {
                                // 前回入力値を設定
                                this.tNedit_BLGoodsCode.Text = this._tmpBLCode;

                                TMsgDisp.Show(this,                         // 親ウィンドウフォーム
                                    emErrorLevel.ERR_LEVEL_INFO,     // エラーレベル
                                    "PMSAE09020U",							// アセンブリID
                                    "BLｺｰﾄﾞが存在しません。",	    // 表示するメッセージ
                                    0,									    // ステータス値
                                    MessageBoxButtons.OK);					// 表示するボタン

                                e.NextCtrl = this.tNedit_BLGoodsCode;

                                this.flag = false;
                                return;
                            }

                            if (ModeChangeProc())
                            {
                                if (e.ShiftKey == false)
                                {
                                    if (e.Key == Keys.Return || e.Key == Keys.Tab || e.Key == Keys.Down)
                                    {
                                        // 入力あり＆Tab遷移＆次がガイドボタンの場合、ガイドボタンは飛ばす
                                        e.NextCtrl = this.tEdit_ABGoodsCode;
                                    }
                                }
                                // [Shift+Tab]
                                else if (e.ShiftKey == true)
                                {
                                    if (e.Key == Keys.Tab)
                                    {
                                        // 入力あり＆Tab遷移＆次がガイドボタンの場合、ガイドボタンは飛ばす
                                        e.NextCtrl = this.Cancel_Button;
                                    }
                                }

                            }
                            else
                            {
                                // 入力あり＆Tab遷移＆次がガイドボタンの場合、ガイドボタンは飛ばす
                                e.NextCtrl = this.tNedit_BLGoodsCode;
                            }

                            break;
                        }
                    }
            }
        }

        /// <summary>
        /// BLコード名称取得処理
        /// </summary>
        /// <param name="blGoodsCode">BLコード</param>
        /// <returns>BLコード名称</returns>
        /// <remarks>
        /// <br>Note       : BLコード名称を取得します。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009.08.06</br>
        /// </remarks>
        private string GetBLGoodsName(int blGoodsCode)
        {
            string blGoodsName = "";

            try
            {
                if (this._blGoodsCdUMntDic.ContainsKey(blGoodsCode))
                {
                    blGoodsName = this._blGoodsCdUMntDic[blGoodsCode].BLGoodsHalfName.Trim();
                }
            }
            catch
            {
                blGoodsName = "";
            }

            return blGoodsName;
        }

        /// <summary>
        /// BLコードの存在チェック処理
        /// </summary>
        /// <returns>存在の判断</returns>
        /// <remarks>
        /// <br>Note       : BLコードの存在チェック処理します。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009.08.06</br>
        /// </remarks>
        private bool ModeChangeProc()
        {
            string iMsg = "入力されたコードのオートバックス商品コード変換マスタ情報が既に登録されています。\n編集を行いますか？";
            string str2 = this.tNedit_BLGoodsCode.Text.TrimEnd(new char[0]).PadLeft(5, '0');
            for (int i = 0; i < this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Count; i++)
            {
                string str3 = (string)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[i][VIEW_BLGOODS_CODE_TITLE];
                if (str2.Equals(str3.TrimEnd(new char[0])))
                {
                    if (((string)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[i][DELETE_DATE]) != "")
                    {
                        TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, "PMSAE09020U", "入力されたコードのオートバックス商品コード変換マスタ情報は既に削除されています。", 0, MessageBoxButtons.OK);
                        this.tNedit_BLGoodsCode.Clear();
                        this.tEdit_BLGoodsHalfName.Clear();
                        _tmpBLCode = string.Empty;
                        return false;
                    }

                    switch (TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, "PMSAE09020U", iMsg, 0, MessageBoxButtons.YesNo))
                    {
                        case DialogResult.Yes:
                            this._dataIndex = i;
                            this.ScreenClear();
                            this.ScreenReconstruction();
                            return true;

                        case DialogResult.No:
                            this.tNedit_BLGoodsCode.Clear();
                            this.tEdit_BLGoodsHalfName.Clear();
                            _tmpBLCode = string.Empty;
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