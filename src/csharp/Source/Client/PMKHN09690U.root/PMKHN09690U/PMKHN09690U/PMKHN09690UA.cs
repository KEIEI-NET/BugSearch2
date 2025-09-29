//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : BLコード変換マスタ 入力フォームクラス
// プログラム概要   : BLコード変換マスタの登録・変更・削除を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 吉岡 孝憲 30745
// 作 成 日  2012/08/01  修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Windows.Forms;
using System.Collections;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// BLコード変換マスタ表示設定フォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : BLコード変換マスタ名称設定の設定を行います。</br>
    /// <br>Programmer : 吉岡 孝憲 30745</br>
    /// <br>Date       : 2012/08/01</br>
    /// <br></br>
    /// </remarks>
    public partial class PMKHN09690UA : Form, IMasterMaintenanceMultiType
    {
        #region Constructor

        /// <summary>
        /// BLコード変換マスタフォームクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : BLコード変換マスタフォームクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 吉岡 孝憲 30745</br>
        /// <br>Date       : 2012/08/01</br>
        /// <br></br>
        /// </remarks>
        public PMKHN09690UA()
        {
            InitializeComponent();

            // データセット列情報構築処理
            DataSetColumnConstruction();

            // 企業コード取得
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            // 拠点コード 00：全社固定
            this._sectionCode = "00";
            _blCodeChangeAcs = new BLGoodsCdChgUAcs();
            this._blCodeChangeTable = new Hashtable();

            // プロパティー変数初期化
            this._canPrint = false;
            this._canNew = true;
            this._canDelete = true;
            this._canLogicalDeleteDataExtraction = true;
            this._canClose = true;
            this._defaultAutoFillToColumn = true;
            this._dataIndex = -1;
            this._canSpecificationSearch = false;
            this.totalCount = 0;
            this._blGoodsCdAcs = new BLGoodsCdAcs();
            this._customerInfoAcs = new CustomerInfoAcs();
        }

        #endregion

        #region Private Members
        private const string BLGOODSCDCHGU_TABLE = "BLGOODSCDCHGU";
        private Hashtable _blCodeChangeTable;
        private bool _modeFlg = false;
        // FremのView用Grid列のKEY情報 (ヘッダのタイトル部となります)
        private const string UPDATEDATETIME_DATE = "更新日";
        private const string DELETE_DATE = "削除日";
        private const string CUSTOMER_CODE_TITLE = "得意先コード";
        private const string CUSTOMER_NAME_TITLE = "得意先名称";
        private const string PMBL_CODE_TITLE = "PM側BLコード";
        private const string SFBL_CODE_TITLE = "SF側BLコード";
        private const string GUID_TITLE = "GUID";

        // 編集モード
        private const string UPDATE_MODE = "更新モード";
        private const string INSERT_MODE = "新規モード";
        private const string DELETE_MODE = "削除モード";

        // Message関連定義
        private const string CT_PGID = "PMKHN09690U";
        private const string CT_PGNM = "自社設定";
        private const string ASSEMBLY_ID = "PMKHN09690U";
        private const string ERR_SEAR_TIME_MSG = "検索中にタイムアウトが発生しました。\r\nしばらく時間を置いて再度検索を行なってください。";
        private const string ERR_WRITE_TIME_MSG = "更新中にタイムアウトが発生しました。\r\nしばらく時間を置いて再度更新してください。";
        private const string ERR_DEL_TIME_MSG = "削除中にタイムアウトが発生しました。\r\nしばらく時間を置いて再度更新してください。";
        private const string SECTION_00_MES = "全体";
        private const string CUSTOMEMPTY_BASE = "ベース設定";


        /// <summary>画面デザイン変更クラス</summary>
        private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();
        /// <summary>
        /// BLコード変換マスタ アクセスクラス
        /// </summary>
        private BLGoodsCdChgUAcs _blCodeChangeAcs = null;
        private BLGoodsCdChgU _blCodeChangeU = null;

        /// <summary>
        /// 得意先情報アクセスクラス
        /// </summary>
        private CustomerInfoAcs _customerInfoAcs;

        /// <summary>
        /// BL商品コードアクセスクラス
        /// </summary>
        private BLGoodsCdAcs _blGoodsCdAcs;

        // 比較用クローン
        private BLGoodsCdChgU _blGoodsCdChgUClone;   // 比較用全体項目表示名称クラス
        private int totalCount;
        // プロパティ用
        private bool _canPrint;
        private bool _canClose;
        private bool _canLogicalDeleteDataExtraction;
        private bool _canNew;
        private bool _canDelete;
        private int _dataIndex;
        private bool _defaultAutoFillToColumn;
        private bool _canSpecificationSearch;
        private int _detailsIndexBuf;

        // ガイド系アクセスクラス
        private Hashtable _customerTb = null;

        /// <summary>
        /// 前PM側BLコード
        /// </summary>
        private int _pmBLCdPre = 0;
        /// <summary>
        /// 前SF側BLコード
        /// </summary>
        private int _sfBLCdPre = 0;
        /// <summary>
        /// 前得意先コード
        /// </summary>
        private int _customerCodePre = -1;
        /// <summary>
        /// 前得意先名称
        /// </summary>
        private string _customerNamePre = string.Empty;
        /// <summary>
        /// 企業コード
        /// </summary>
        private string _enterpriseCode = string.Empty;
        /// <summary>
        /// 拠点コード
        /// </summary>
        private string _sectionCode = string.Empty;
        /// <summary>
        /// BL商品コード名称（全角）（保存前のチェックに使用）
        /// </summary>
        private string _pmBLCdGoodsFullName = string.Empty;

        /// <summary>
        /// SF側BLコード　編集回数（保存前のチェックに使用）
        /// </summary>
        private int _sfBLCdEditCnt = 0;
        /// <summary>
        /// SF側BLコード　BL商品コード名称（保存前のチェックに使用）
        /// </summary>
        private string _sfBLCdGoodsFullName = string.Empty;

        #endregion

        #region  Events

        /// <summary>
        /// 画面非表示イベント
        /// </summary>
        /// <remarks>
        /// 画面が非表示状態になった際に発生します。
        /// </remarks>
        public event MasterMaintenanceMultiTypeUnDisplayingEventHandler UnDisplaying;

        # endregion

        #region Properties

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

        /// <summary>画面終了設定プロパティ</summary>
        /// <value>画面クローズを許可するかどうかの設定を取得または設定します。</value>
        /// <remarks>falseの場合は、画面を閉じる際、CloseではなくHide(非表示)を実行します。</remarks>
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
            get { return this._canSpecificationSearch; }
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
            get { return this._defaultAutoFillToColumn; }
        }


        #endregion

        #region Public Methods

        /// <summary>
        /// 画面情報全体項目表示名称クラス格納処理(チェック用)
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面情報から全体項目表示名称クラスにデータを格納します。</br>
        /// <br>Programmer : 吉岡 孝憲 30745</br>
        /// <br>Date       : 2012/08/01</br>
        /// </remarks>
        public System.Collections.Hashtable GetAppearanceTable()
        {
            Hashtable appearanceTable = new Hashtable();
            // 削除日
            appearanceTable.Add(DELETE_DATE, new GridColAppearance(MGridColDispType.DeletionDataBoth, ContentAlignment.MiddleLeft, "", Color.Red));
            // 得意先コード
            appearanceTable.Add(CUSTOMER_CODE_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 得意先名称
            appearanceTable.Add(CUSTOMER_NAME_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // PM側BLコード
            appearanceTable.Add(PMBL_CODE_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // SF側BLコード
            appearanceTable.Add(SFBL_CODE_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //GUID_TITLE
            appearanceTable.Add(GUID_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));

            return appearanceTable;
        }

        /// <summary>
        /// 画面情報全体項目表示名称クラス格納処理(チェック用)
        /// </summary>
        /// <param name="tableName">全体項目表示名称オブジェクト</param>
        /// <param name="bindDataSet">全体項目表示名称オブジェクト</param>
        /// <remarks>
        /// <br>Note       : 画面情報から全体項目表示名称クラスにデータを格納します。</br>
        /// <br>Programmer : 吉岡 孝憲 30745</br>
        /// <br>Date       : 2012/08/01</br>
        /// </remarks>
        public void GetBindDataSet(ref DataSet bindDataSet, ref string tableName)
        {
            bindDataSet = this.Bind_DataSet;
            tableName = BLGOODSCDCHGU_TABLE;
        }

        /// <summary>
        ///  Print
        /// </summary>
        /// <returns></returns>
        public int Print()
        {
            // 印刷アセンブリをロードする（未実装）
            return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        }

        /// <summary>
        /// ネクストデータ検索処理
        /// </summary>
        /// <param name="readCount">抽出対象件数</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 指定した件数分のネクストデータを検索します。</br>
        /// <br>Programmer : 30745 吉岡</br>
        /// <br>Date       : 2012/08/01 </br>
        /// </remarks>
        public int SearchNext(int readCount)
        {
            // 実装なし
            return (int)ConstantManagement.DB_Status.ctDB_EOF;
        }


        /// <summary>
        /// 検索処理
        /// </summary>
        /// <param name="totalCount">全該当件数</param>
        /// <param name="readCount">抽出対象件数</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 全データを検索し、抽出結果を展開したDataSetと全該当件数を返します。</br>
        /// <br>Programmer : 吉岡 孝憲 30745</br>
        /// <br>Date       : 2012/08/01</br>
        /// </remarks>
        public int Search(ref int totalCount, int readCount)
        {
            int status = 0;
            const string ctPROCNM = "Search";
            BLGoodsCdChgU parseblCodeChange = newBLGoodsCdChgU();
            List<BLGoodsCdChgU> blCodeChangeList = null;

            if (this._blCodeChangeTable.Count == 0)
            {
                status = this._blCodeChangeAcs.Search(ref blCodeChangeList, parseblCodeChange, out totalCount, 0, 0, ConstantManagement.LogicalMode.GetData0);
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        {
                            this.totalCount = blCodeChangeList.Count;
                            this.Bind_DataSet.Tables[BLGOODSCDCHGU_TABLE].Rows.Clear();
                            this._blCodeChangeTable.Clear();

                            //BLコード変換マスタクラスをデータセットへ展開する
                            int index = 0;
                            foreach (BLGoodsCdChgU blCodeChange in blCodeChangeList)
                            {
                                if (this._blCodeChangeTable.ContainsKey(blCodeChange.FileHeaderGuid) == false)
                                {
                                    BLGoodsCdChgUToDataSet(blCodeChange.Clone(), index);
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
                            // サーチ
                            TMsgDisp.Show(
                                this,                               // 親ウィンドウフォーム
                                emErrorLevel.ERR_LEVEL_STOP,        // エラーレベル
                                CT_PGID,                            // アセンブリＩＤまたはクラスＩＤ
                                this.Name,                          // プログラム名称
                                ctPROCNM,                           // 処理名称
                                TMsgDisp.OPE_GET,                   // オペレーション
                                ERR_SEAR_TIME_MSG,                  // 表示するメッセージ
                                status,                             // ステータス値
                                this._blCodeChangeAcs,                // エラーが発生したオブジェクト
                                MessageBoxButtons.OK,               // 表示するボタン
                                MessageBoxDefaultButton.Button1);   // 初期表示ボタン
                            break;
                        }
                    default:
                        {
                            TMsgDisp.Show(
                           this,
                           emErrorLevel.ERR_LEVEL_STOPDISP,
                           this.Name,
                           "読み込みに失敗しました。",
                           status,
                           MessageBoxButtons.OK);
                            break;
                        }
                }
            }
            else
            {
                this.totalCount = this._blCodeChangeTable.Count;
                SortedList sortedList = new SortedList();

                //BLコード変換マスタクラスをデータセットへ展開する
                int index = 0;
                foreach (BLGoodsCdChgU blCodeChange in sortedList.Values)
                {
                    BLGoodsCdChgUToDataSet(blCodeChange.Clone(), index);
                    ++index;
                }
            }
            // 戻り値セット
            totalCount = this.totalCount;

            return status;
        }

        /// <summary>
        /// データ削除処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 選択中のデータを削除します。</br>
        /// <br>Programmer : 吉岡 孝憲 30745</br>
        /// <br>Date       : 2012/08/01</br>
        /// </remarks>
        public int Delete()
        {

            const string ctPROCNM = "LogicalDelete";
            BLGoodsCdChgU blCodeChange = null;

            // 保持しているデータセットより修正前情報取得
            Guid guid = (Guid)this.Bind_DataSet.Tables[BLGOODSCDCHGU_TABLE].Rows[this.DataIndex][GUID_TITLE];
            blCodeChange = (BLGoodsCdChgU)this._blCodeChangeTable[guid];

            int status;
            int dummy = 0;
            //BLコード変換マスタ論理削除処理
            status = this._blCodeChangeAcs.LogicalDelete(ref blCodeChange);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        BLGoodsCdChgUToDataSet(blCodeChange.Clone(), this.DataIndex);

                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        ExclusiveTransaction(status, true);

                        //BLコード変換マスタクラスデータセット展開処理
                        this._blCodeChangeTable.Clear();
                        this.Search(ref dummy, 0);
                        return status;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT:
                    {
                        // TIMEOUT
                        TMsgDisp.Show(
                            this,                               // 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOP,        // エラーレベル
                            CT_PGID,                            // アセンブリＩＤまたはクラスＩＤ
                            this.Name,                          // プログラム名称
                            ctPROCNM,                           // 処理名称
                            TMsgDisp.OPE_UPDATE,                // オペレーション
                            ERR_DEL_TIME_MSG,                   // 表示するメッセージ
                            status,                             // ステータス値
                            this._blCodeChangeAcs,                // エラーが発生したオブジェクト
                            MessageBoxButtons.OK,               // 表示するボタン
                            MessageBoxDefaultButton.Button1);   // 初期表示ボタン
                        return status;
                    }
                default:
                    {
                        // 論理削除
                        TMsgDisp.Show(
                            this, 								// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOP, 		// エラーレベル
                            CT_PGID, 						    // アセンブリＩＤまたはクラスＩＤ
                            CT_PGNM, 				            // プログラム名称
                            "Delete", 							// 処理名称
                            TMsgDisp.OPE_HIDE, 					// オペレーション
                            "削除に失敗しました。", 			// 表示するメッセージ
                            status, 							// ステータス値
                            this._blCodeChangeAcs, 				// エラーが発生したオブジェクト
                            MessageBoxButtons.OK, 				// 表示するボタン
                            MessageBoxDefaultButton.Button1);	// 初期表示ボタン

                        //BLコード変換マスタクラスデータセット展開処理
                        this._blCodeChangeTable.Clear();
                        this.Search(ref dummy, 0);

                        return status;
                    }
            }

            return status;
        }

        # endregion Public Methods

        #region  Control Events

        /// <summary>
        /// フォームロードイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note		: フォームが読み込まれた時に発生します。</br>
        /// <br>Programmer	: 吉岡 孝憲 30745</br>
        /// <br>Date		: 2012/08/01</br>
        /// </remarks>
        private void PMKHN09690UA_Load(object sender, EventArgs e)
        {
            // 画面スキンファイルの読込(デフォルトスキン指定)
            this._controlScreenSkin.LoadSkin();

            // 画面スキン変更
            this._controlScreenSkin.SettingScreenSkin(this);
            // プロパティの初期設定
            this._canPrint = false;
            this._canClose = false;
            // アイコンリソース管理クラスを使用して、アイコンを表示する
            ImageList imageList24 = IconResourceManagement.ImageList24;
            ImageList imageList16 = IconResourceManagement.ImageList16;

            this.Ok_Button.ImageList = imageList24;           // 保存ボタン
            this.Cancel_Button.ImageList = imageList24;           // 閉じるボタン
            this.Revive_Button.ImageList = imageList24;           //復活ボタン
            this.Delete_Button.ImageList = imageList24;           //完全削除ボタン

            this.uButton_CustomerGuide.ImageList = imageList16;
            this.uButton_PMBLCdGuid.ImageList = imageList16;
            this.uButton_SFBLCdGuid.ImageList = imageList16;
            this.Ok_Button.Appearance.Image = Size24_Index.SAVE;     // 保存ボタン
            this.Cancel_Button.Appearance.Image = Size24_Index.CLOSE;    // 閉じるボタン
            this.Revive_Button.Appearance.Image = Size24_Index.REVIVAL;  //復活ボタン
            this.Delete_Button.Appearance.Image = Size24_Index.DELETE;   //完全削除ボタン
            this.uButton_CustomerGuide.Appearance.Image = Size16_Index.STAR1;//ガイドボタン
            this.uButton_PMBLCdGuid.Appearance.Image = Size16_Index.STAR1;//ガイドボタン
            this.uButton_SFBLCdGuid.Appearance.Image = Size16_Index.STAR1;//ガイドボタン

            this.Initial_Timer.Enabled = true;
        }

        /// <summary>
        /// Form.FormClosing イベント (PMKHN09690UA)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : ユーザーがフォームを閉じるたびに、フォームが閉じられる前、および閉じる理由を指定する前に発生します。</br>
        /// <br>Programmer : 吉岡 孝憲 30745</br>
        /// <br>Date       : 2012/08/01</br>
        /// </remarks>
        private void PMKHN09690UA_FormClosing(object sender, FormClosingEventArgs e)
        {
            this._detailsIndexBuf = -2;
            // チェック用クローン初期化
            this._blGoodsCdChgUClone = null;

            // ユーザーによって閉じられる場合
            if (e.CloseReason == CloseReason.UserClosing)
            {
                // CanCloseプロパティがfalseの場合は、クローズ処理をキャンセルしてフォームを非表示化する。
                if (this._canClose == false)
                {
                    e.Cancel = true;
                    this.Hide();
                }
            }
        }

        /// <summary>
        /// Form.VisibleChanged イベント (PMKHN09690UA)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : コントロールの表示状態が変わったときに発生します。</br>
        /// <br>Programmer : 吉岡 孝憲 30745</br>
        /// <br>Date       : 2012/08/01</br>
        /// </remarks>
        private void PMKHN09690UA_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible == false)
            {
                this.Owner.Activate();
                return;
            }

            // 画面クリア処理
            ScreenClear();

            this.Initial_Timer.Enabled = true;

        }

        /// <summary>
        /// Timer.Tick イベント (Initial_Timer)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 指定された間隔の時間が経過したときに発生します。</br>
        /// <br>Programmer : 吉岡 孝憲 30745</br>
        /// <br>Date       : 2012/08/01</br>
        /// </remarks>
        private void Initial_Timer_Tick(object sender, EventArgs e)
        {
            this.Initial_Timer.Enabled = false;

            this.ScreenReconstruction();
        }

        /// <summary>
        /// Ok_Button_Click イベント (Ok_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : コンポーネントがクリックされたときに発生します。</br>
        /// <br>Programmer : 吉岡 孝憲 30745</br>
        /// <br>Date       : 2012/08/01</br>
        /// </remarks>
        private void Ok_Button_Click(object sender, EventArgs e)
        {
            if (this.SaveProc() == false)
            {
                return;
            }

            // フォームを閉じる
            this.CloseForm(DialogResult.OK);

            // フォームを非表示化する。
            if (CanClose == true)
            {
                this.Close();
            }
            else
            {
                this.Hide();
            }

            // GridのIndexBuffer格納用変数の初期化
            this._detailsIndexBuf = -2;

        }

        /// <summary>
        /// Cancel_Button_Click イベント (Cancel_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : コンポーネントがクリックされたときに発生します。</br>
        /// <br>Programmer : 吉岡 孝憲 30745</br>
        /// <br>Date       : 2012/08/01</br>
        /// </remarks>
        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            // 削除モード・参照モード以外の場合は保存確認処理を行う
            if (this.Mode_Label.Text != DELETE_MODE)
            {
                //保存確認
                BLGoodsCdChgU compareBLGoodsCdChgU = new BLGoodsCdChgU();
                compareBLGoodsCdChgU = this._blGoodsCdChgUClone.Clone();
                this._detailsIndexBuf = this._dataIndex;

                //現在の画面情報を取得する
                DispToBLGoodsCdChgU(ref compareBLGoodsCdChgU);
                //最初に取得した画面情報と比較
                if (!(this._blGoodsCdChgUClone.Equals(compareBLGoodsCdChgU)))
                {
                    //画面情報が変更されていた場合は、保存確認メッセージを表示する
                    // 保存確認
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
                                // 登録処理
                                if (SaveProc() == false)
                                {
                                    return;
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
                                if (_modeFlg)
                                {
                                    this.tNedit_CustomerCd.Focus();
                                    _modeFlg = false;
                                }
                                else
                                {
                                    this.Cancel_Button.Focus();
                                }
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

            // GridのIndexBuffer格納用変数の初期化
            this._detailsIndexBuf = -2;

            this.DialogResult = DialogResult.Cancel;

            this.Close();
        }

        /// <summary>
        /// uButtonFrontEmployeeCdGuid_Click
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: 抽出する範囲を指定する。</br>
        /// <br>Programmer	: 吉岡 孝憲 30745</br>
        /// <br>Date		: 2012/08/01</br>
        /// </remarks>
        private void uButtonCustomerGuid_Click(object sender, EventArgs e)
        {
            // 得意先ガイド表示
            PMKHN04005UA customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_CUSTOMER_ONLY, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY, PMKHN04005UA.PCCUOE_MASTER_ONLY);
            customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.CustomerSearchForm_CustomerSelect);

            DialogResult result = customerSearchForm.ShowDialog(this);

            //-----------------------------------------------------------------------------
            //if (this._customerInfoAcs == null)
            //{
            //    this._customerInfoAcs = new EmployeeAcs();
            //}

            //Employee employee;
            //int status = this._customerInfoAcs.ExecuteGuid(this._enterpriseCode, true, out employee);

            //if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            //{
            //    tNedit_CustomerCd.Value = employee.EmployeeCode.TrimEnd();
            //    uLabel_CustomerName.Text = employee.Name;
            //    _prePMBLCd = tNedit_CustomerCd.GetInt(); //ADD by huanghx for Redmine24889 on 20110914
            //}

        }

        #region 得意先選択ガイドボタンクリック時イベント

        /// <summary>
        /// 得意先選択ガイドボタンクリック時発生イベント
        /// </summary>
        /// <param name="sender">PMKHN4002Eフォームオブジェクト</param>
        /// <param name="customerSearchRet">得意先情報戻り値クラス(PMKHN4002E)</param>
        /// <remarks>
        /// <br>Note       : 得意先ガイドボタンクリックイベントを行います。</br>
        /// <br>Programmer : 吉岡 孝憲 </br>
        /// <br>Date       : 2012/08/01 </br>
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

            // 得意先情報をUIに設定
            this.tNedit_CustomerCd.SetInt(customerInfo.CustomerCode);
            this.uLabel_CustomerNm.Text = customerInfo.CustomerSnm.TrimEnd();
            this.tNedit_CustomerCd.Enabled = true;
            this.uButton_CustomerGuide.Enabled = true;
        }
        #endregion


        /// <summary>
        /// ChangeFocus イベント(tArrowKeyControl1)
        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント情報</param>
        /// <remarks>
        /// <br>Note		: 各コントロールからフォーカスが離れたときに発生します。</br>
        /// <br>Programmer  : 吉岡 孝憲 30745</br>
        /// <br>Date        : 2012/08/01</br>
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null)
            {
                return;
            }

            _modeFlg = false;

            switch (e.PrevCtrl.Name)
            {

                case "tNedit_CustomerCd":   // 得意先コード
                    #region 得意先コードからのフォーカス遷移
                    int customerCode = this.tNedit_CustomerCd.GetInt();
                    if (_customerCodePre != customerCode)
                    {
                        if (customerCode != 0)
                        {
                            #region 得意先コード入力有り
                            if (e.NextCtrl.Name == "Cancel_Button")
                            {
                                // 遷移先が閉じるボタン
                                _modeFlg = true;
                            }
                            else
                            {
                                //得意先情報を取得
                                CustomerInfo customerInfo;
                                int status = this._customerInfoAcs.ReadStaticMemoryData(out customerInfo, this._enterpriseCode, customerCode);

                                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && customerInfo.IsCustomer)
                                {
                                    // モード変更　すでに登録済み（論理削除、編集）か否かを判定
                                    if (ModeChangeProc(customerInfo.CustomerCode, tNedit_PMBLCd.GetInt()))
                                    {
                                        if (this._dataIndex < 0)
                                        {
                                            e.NextCtrl = tNedit_CustomerCd;
                                        }
                                    }
                                    else
                                    {
                                        this.uLabel_CustomerNm.Text = customerInfo.CustomerSnm.TrimEnd();
                                        //前得意先コード
                                        this._customerCodePre = customerCode;
                                        //前得意先名称
                                        this._customerNamePre = customerInfo.CustomerSnm.TrimEnd();
                                    }
                                }
                                else
                                {
                                    TMsgDisp.Show(
                                         this, 								    // 親ウィンドウフォーム
                                         emErrorLevel.ERR_LEVEL_EXCLAMATION,    // エラーレベル
                                         ASSEMBLY_ID,						    // アセンブリＩＤまたはクラスＩＤ
                                         "得意先マスタに登録されていません。", 	// 表示するメッセージ
                                         0, 									// ステータス値
                                         MessageBoxButtons.OK);				    // 表示するボタン
                                    e.NextCtrl = tNedit_CustomerCd;
                                }

                            }
                            #endregion
                        }
                        else
                        {
                            #region 得意先コード入力無し
                            //得意先名称クリア
                            this.uLabel_CustomerNm.Text = string.Empty;
                            //得意先情報を取得
                            CustomerInfo customerInfo = new CustomerInfo();
                            customerInfo.CustomerSnm = CUSTOMEMPTY_BASE;
                            customerInfo.CustomerEpCode = string.Empty;
                            customerInfo.CustomerSecCode = string.Empty;
                            customerInfo.CustomerCode = 0;

                            // モード変更　すでに登録済み（論理削除、編集）か否かを判定
                            if (ModeChangeProc(customerInfo.CustomerCode, tNedit_PMBLCd.GetInt()))
                            {
                                if (this._dataIndex < 0)
                                {
                                    e.NextCtrl = tNedit_CustomerCd;
                                }
                            }
                            else
                            {
                                //前得意先コード
                                this._customerCodePre = customerCode;
                                //前得意先名称
                                this._customerNamePre = customerInfo.CustomerSnm.TrimEnd();
                            }
                            #endregion
                        }
                    }
                    break;
                    #endregion
                case "tNedit_PMBLCd":           // PM側BLコード
                    FocusMoveBLGoodsCode(tNedit_PMBLCd,e);
                    break;
                case "tNedit_SFBLCd":           // SF側BLコード
                    FocusMoveBLGoodsCode(tNedit_SFBLCd, e);

                    // SF側BLコードの変更をカウント
                    if (isBLCodeChange(tNedit_SFBLCd.Name, tNedit_SFBLCd.GetInt()))
                    {
                        _sfBLCdEditCnt++;
                    }
                    break;
                case "uButton_CustomerGuide":   // 得意先ガイド
                    if (e.Key == Keys.Right)
                    {
                        e.NextCtrl = uButton_CustomerGuide;
                    }
                    break;
                case "uButton_PMBLCdGuid":      // PM側BLコードガイド
                    if (e.Key == Keys.Right)
                    {
                        e.NextCtrl = uButton_PMBLCdGuid;
                    }
                    break;
                case "uButton_SFBLCdGuid":      // SF側BLコードガイド
                    if (e.Key == Keys.Right)
                    {
                        e.NextCtrl = uButton_SFBLCdGuid;
                    }
                    break;
            }
        }

        /// <summary>
        /// PM側BLコード、SF側BLコード用
        /// フォーカス遷移時処理
        /// </summary>
        /// <param name="target">対象コントロール</param>
        private void FocusMoveBLGoodsCode(TNedit target, ChangeFocusEventArgs e)
        {
            int blCode = target.GetInt();
            // BLコードが変更されているか
            if (isBLCodeChange(target.Name,blCode))
            {
                if (blCode != 0)
                {
                    #region PM側BL商品コード入力有り
                    if (e.NextCtrl.Name == "Cancel_Button")
                    {
                        // 遷移先が閉じるボタン
                        _modeFlg = true;
                    }
                    else
                    {
                        //BL商品情報を取得
                        BLGoodsCdUMnt bLGoodsCdUMnt;
                        int status = this._blGoodsCdAcs.Read(out bLGoodsCdUMnt, this._enterpriseCode, blCode);

                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            // モード変更　すでに登録済み（論理削除、編集）か否かを判定
                            if (target.Name == tNedit_PMBLCd.Name && ModeChangeProc(tNedit_CustomerCd.GetInt(), blCode))
                            {
                                if (this._dataIndex < 0)
                                {
                                    e.NextCtrl = tNedit_CustomerCd;
                                }
                            }
                            else
                            {
                                if (target.Name == tNedit_PMBLCd.Name)
                                {
                                    //前PM側BL商品コード
                                    this._pmBLCdPre = blCode;
                                    //BL商品コード名称
                                    this._pmBLCdGoodsFullName = bLGoodsCdUMnt.BLGoodsFullName;
                                }
                                else
                                {
                                    //SF側BLコード　BL商品コード名称
                                    this._sfBLCdGoodsFullName = bLGoodsCdUMnt.BLGoodsFullName;
                                }
                            }
                        }
                        else
                        {
                            string msg = string.Empty;
                            if (target.Name == tNedit_PMBLCd.Name)
                            {
                                msg = "PM側BLコードがマスタに登録されていません。";
                            }
                            else
                            {
                                msg = "SF側BLコードがマスタに登録されていません。";
                            }

                            TMsgDisp.Show(
                                 this, 								    // 親ウィンドウフォーム
                                 emErrorLevel.ERR_LEVEL_EXCLAMATION,    // エラーレベル
                                 ASSEMBLY_ID,						    // アセンブリＩＤまたはクラスＩＤ
                                 msg, 		                            // 表示するメッセージ
                                 0, 									// ステータス値
                                 MessageBoxButtons.OK);				    // 表示するボタン
                            e.NextCtrl = target;
                        }
                    }
                    #endregion
                }
                else
                {
                    #region BLコード入力無し
                    if (target.Name == tNedit_PMBLCd.Name)
                    {
                        this._pmBLCdGoodsFullName = string.Empty;
                        //前PM側BL商品コード
                        this._pmBLCdPre = blCode;
                    }
                    else
                    {
                        this._sfBLCdGoodsFullName = string.Empty;
                    }

                    //// モード変更　すでに登録済み（論理削除、編集）か否かを判定
                    //if (ModeChangeProc(tNedit_CustomerCd.GetInt(), blCode))
                    //{
                    //    if (this._dataIndex < 0)
                    //    {
                    //        e.NextCtrl = tNedit_CustomerCd;
                    //    }
                    //}
                    //else
                    //{
                    //    //前PM側BL商品コード
                    //    this._pmBLCdPre = blCode;
                    //}
                    #endregion
                }
            }

        }

        /// <summary>
        /// BLコードが変更になっているか否か
        /// </summary>
        /// <param name="name">オブジェクト名称</param>
        /// <param name="blCode">BLコード</param>
        /// <returns>
        /// true:変更された　false:変更されていない
        /// </returns>
        private bool isBLCodeChange(string name, int blCode)
        {
            if (name == tNedit_PMBLCd.Name)
            {
                // PM側BLコード
                return !blCode.Equals(this._pmBLCdPre);
            }
            else
            {
                // SF側BLコード
                return !blCode.Equals(this._sfBLCdPre);
            }
        }

        /// <summary>
        /// Delete_Button_Click
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: 削除ボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer	: 吉岡 孝憲 30745</br>
        /// <br>Date		: 2012/08/01</br>
        /// </remarks>
        private void Delete_Button_Click(object sender, EventArgs e)
        {
            const string ctPROCNM = "Delete";
            BLGoodsCdChgU blCodeChange = newBLGoodsCdChgU();

            // 完全削除確認
            DialogResult result = TMsgDisp.Show(
                this, 								// 親ウィンドウフォーム
                emErrorLevel.ERR_LEVEL_QUESTION, // エラーレベル
                CT_PGID, 						    // アセンブリＩＤまたはクラスＩＤ
                "データを削除します。" + "\r\n" +
                "よろしいですか？", 				// 表示するメッセージ
                 0, 									// ステータス値
                 MessageBoxButtons.OKCancel, 		// 表示するボタン
                 MessageBoxDefaultButton.Button2);	// 初期表示ボタン
            if (result == DialogResult.OK)
            {
                // 保持しているデータセットより情報取得
                Guid guid = (Guid)this.Bind_DataSet.Tables[BLGOODSCDCHGU_TABLE].Rows[this.DataIndex][GUID_TITLE];
                blCodeChange = (BLGoodsCdChgU)this._blCodeChangeTable[guid];
                //BLコード変換マスタ論理削除処理
                int status = this._blCodeChangeAcs.Delete(ref blCodeChange);

                int dummy = 0;

                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        {
                            this.Bind_DataSet.Tables[BLGOODSCDCHGU_TABLE].Rows[this.DataIndex].Delete();
                            this._blCodeChangeTable.Remove(blCodeChange.FileHeaderGuid);
                            break;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                        {
                            ExclusiveTransaction(status, true);

                            //BLコード変換マスタクラスデータセット展開処理
                            this._blCodeChangeTable.Clear();
                            this.Search(ref dummy, 0);
                            this.Close();

                            return;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT:
                        {
                            // TIMEOUT
                            TMsgDisp.Show(
                               this, 								// 親ウィンドウフォーム
                               emErrorLevel.ERR_LEVEL_STOP, 		// エラーレベル
                               CT_PGID, 						    // アセンブリＩＤまたはクラスＩＤ
                               this.Name,                           // プログラム名称
                               ctPROCNM,                            // 処理名称
                               TMsgDisp.OPE_UPDATE,                 // オペレーション
                               ERR_DEL_TIME_MSG,                    // 表示するメッセージ
                               status,            					// ステータス値
                               this._blCodeChangeAcs, 				// エラーが発生したオブジェクト
                               MessageBoxButtons.OK, 				// 表示するボタン
                               MessageBoxDefaultButton.Button1);	// 初期表示ボタン
                            return;
                        }
                    default:
                        {
                            // 物理削除
                            TMsgDisp.Show(
                                this, 								// 親ウィンドウフォーム
                                emErrorLevel.ERR_LEVEL_STOP, 		// エラーレベル
                                CT_PGID, 						    // アセンブリＩＤまたはクラスＩＤ
                                CT_PGNM, 				            // プログラム名称
                                "Delete_Button_Click", 				// 処理名称
                                TMsgDisp.OPE_DELETE, 				// オペレーション
                                "削除に失敗しました。", 			// 表示するメッセージ
                                status, 							// ステータス値
                                this._blCodeChangeAcs, 				// エラーが発生したオブジェクト
                                MessageBoxButtons.OK, 				// 表示するボタン
                                MessageBoxDefaultButton.Button1);	// 初期表示ボタン

                            // BLコード変換マスタクラスデータセット展開処理
                            this._blCodeChangeTable.Clear();
                            this.Search(ref dummy, 0);
                            this.Close();

                            return;
                        }
                }

            }
            else
            {
                this.Delete_Button.Focus();
                return;
            }

            // 画面非表示イベント
            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }

            this.DialogResult = DialogResult.OK;


            // GridのIndexBuffer格納用変数の初期化
            this._detailsIndexBuf = -2;

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
        /// Revive_Button_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note		: 復活ボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer	: 吉岡 孝憲 30745</br>
        /// <br>Date		: 2012/08/01</br>
        /// </remarks> 
        private void Revive_Button_Click(object sender, EventArgs e)
        {
            const string ctPROCNM = "RevivalProc";
            BLGoodsCdChgU blCodeChange = null;

            DialogResult res = TMsgDisp.Show(this,
                                             emErrorLevel.ERR_LEVEL_QUESTION,
                                             CT_PGID,
                                             "現在表示中のマスタを復活します。" + "\r\n" + "よろしいですか？",
                                             0,
                                             MessageBoxButtons.YesNo,
                                             MessageBoxDefaultButton.Button1);

            if (res != DialogResult.Yes)
            {
                return;
            }

            // 保持しているデータセットより情報取得
            Guid guid = (Guid)this.Bind_DataSet.Tables[BLGOODSCDCHGU_TABLE].Rows[this.DataIndex][GUID_TITLE];
            blCodeChange = (BLGoodsCdChgU)this._blCodeChangeTable[guid];

            // BLコード変換マスタ登録・更新処理
            int status = this._blCodeChangeAcs.RevivalLogicalDelete(ref blCodeChange);
            int dummy = 0;
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        //クラスデータセット展開処理
                        BLGoodsCdChgUToDataSet(blCodeChange, this._dataIndex);
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        ExclusiveTransaction(status, true);

                        // クラスデータセット展開処理
                        this._blCodeChangeTable.Clear();
                        this.Search(ref dummy, 0);
                        this.Close();

                        return;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT:
                    {
                        // TIMEOUT
                        TMsgDisp.Show(
                            this,                               // 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOP,        // エラーレベル
                            CT_PGID,                            // アセンブリＩＤまたはクラスＩＤ
                            this.Name,                          // プログラム名称
                            ctPROCNM,                           // 処理名称
                            TMsgDisp.OPE_UPDATE,                // オペレーション
                            ERR_WRITE_TIME_MSG,                 // 表示するメッセージ
                            status,                             // ステータス値
                            this._blCodeChangeAcs,              // エラーが発生したオブジェクト
                            MessageBoxButtons.OK,               // 表示するボタン
                            MessageBoxDefaultButton.Button1);   // 初期表示ボタン
                        return;

                    }
                default:
                    {
                        // 復活失敗
                        TMsgDisp.Show(
                            this, 								// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOP, 		// エラーレベル
                            CT_PGID, 						    // アセンブリＩＤまたはクラスＩＤ
                            CT_PGNM, 				            // プログラム名称
                            "Revive_Button_Click", 				// 処理名称
                            TMsgDisp.OPE_UPDATE, 				// オペレーション
                            "復活に失敗しました。", 			// 表示するメッセージ
                            status, 							// ステータス値
                            this._blCodeChangeAcs, 				// エラーが発生したオブジェクト
                            MessageBoxButtons.OK, 				// 表示するボタン
                            MessageBoxDefaultButton.Button1);	// 初期表示ボタン                      
                        // クラスデータセット展開処理
                        this._blCodeChangeTable.Clear();
                        this.Search(ref dummy, 0);
                        this.Close();
                        break;
                    }
            }
            // 画面非表示イベント
            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }
            this.DialogResult = DialogResult.OK;

            this._detailsIndexBuf = -2;

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
        /// モード変更処理
        /// </summary>
        /// <param name="sectionCd">拠点コード</param>
        /// <remarks>
        /// <br>Note		: モード変更処理</br>
        /// <br>Programmer	: 吉岡 孝憲 30745</br>
        /// <br>Date		: 2012/08/01</br>
        /// </remarks>  
        private bool ModeChangeProc(int customerCd, int pMBLGoodsCode)
        {
            for (int i = 0; i < this.Bind_DataSet.Tables[BLGOODSCDCHGU_TABLE].Rows.Count; i++)
            {
                // データセットと比較
                int dsCustomerCd = 0;
                int dsPMBLGoodsCode = 0;
                int.TryParse(this.Bind_DataSet.Tables[BLGOODSCDCHGU_TABLE].Rows[i][CUSTOMER_CODE_TITLE].ToString().Trim(), out dsCustomerCd);
                int.TryParse(this.Bind_DataSet.Tables[BLGOODSCDCHGU_TABLE].Rows[i][PMBL_CODE_TITLE].ToString().Trim(), out dsPMBLGoodsCode);

                if (customerCd.Equals(dsCustomerCd) && pMBLGoodsCode.Equals(dsPMBLGoodsCode))
                {
                    // 得意先コード、PM側BL商品コードが、データセット一致した場合
                    if ((string)this.Bind_DataSet.Tables[BLGOODSCDCHGU_TABLE].Rows[i][DELETE_DATE] != "")
                    {
                        // 論理削除
                        TMsgDisp.Show(this, 					// 親ウィンドウフォーム
                          emErrorLevel.ERR_LEVEL_INFO,          // エラーレベル
                          ASSEMBLY_ID,						    // アセンブリＩＤまたはクラスＩＤ
                          "入力されたコードのBLコード変換マスタ情報は既に削除されています。", 			// 表示するメッセージ
                          0, 									// ステータス値
                          MessageBoxButtons.OK);				// 表示するボタン
                        // 得意先コードのクリア
                        tNedit_CustomerCd.Clear();
                        uLabel_CustomerNm.Text = string.Empty;
                        return true;
                    }

                    DialogResult res = TMsgDisp.Show(
                        this,                                   // 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_INFO,            // エラーレベル
                        ASSEMBLY_ID,                            // アセンブリＩＤまたはクラスＩＤ
                        "入力されたコードのBLコード変換マスタ情報が既に登録されています。\n編集を行いますか？",   // 表示するメッセージ
                        0,                                      // ステータス値
                        MessageBoxButtons.YesNo);               // 表示するボタン

                    switch (res)
                    {
                        case DialogResult.Yes:
                            {
                                // 画面再描画
                                this._dataIndex = i;
                                ScreenClear();
                                ScreenReconstruction();
                                break;
                            }
                        case DialogResult.No:
                            {
                                // 各項目クリア
                                tNedit_CustomerCd.Clear();
                                uLabel_CustomerNm.Text = string.Empty;
                                tNedit_PMBLCd.Clear();
                                tNedit_SFBLCd.Clear();
                                this._customerCodePre = 0;
                                break;
                            }
                    }
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region  Private Methods

        /// <summary>
        /// 画面入力許可制御処理
        /// </summary>
        /// <param name="setType">設定タイプ 新規, 更新, 削除</param>
        /// <remarks>
        /// <br>Note       : 画面の入力許可を制御します。</br>
        /// <br>Programmer : 吉岡 孝憲 30745</br>
        /// <br>Date       : 2012/08/01</br>
        /// </remarks>
        private void ScreenInputPermissionControl(string setType)
        {
            switch (setType)
            {

                // 新規
                case INSERT_MODE:

                    this.tNedit_CustomerCd.Enabled = true;
                    this.uButton_CustomerGuide.Enabled = true;

                    // ボタン
                    this.Delete_Button.Visible = false;
                    this.Revive_Button.Visible = false;
                    this.Ok_Button.Visible = true;
                    this.Cancel_Button.Visible = true;

                    break;
                // 更新
                case UPDATE_MODE:
                    // 表示項目
                    this.tNedit_CustomerCd.Enabled = false;
                    this.uButton_CustomerGuide.Enabled = false;
                    this.tNedit_PMBLCd.Enabled = false;
                    this.uButton_PMBLCdGuid.Enabled = false;

                    // ボタン
                    this.Ok_Button.Visible = true;
                    this.Cancel_Button.Visible = true;
                    this.Revive_Button.Visible = false;
                    this.Delete_Button.Visible = false;

                    break;
                // 削除
                case DELETE_MODE:
                    // 表示項目
                    this.uButton_CustomerGuide.Enabled = false;
                    this.tNedit_CustomerCd.Enabled = false;
                    this.tNedit_PMBLCd.Enabled = false;
                    this.uButton_PMBLCdGuid.Enabled = false;
                    this.tNedit_SFBLCd.Enabled = false;
                    this.uButton_SFBLCdGuid.Enabled = false;

                    // ボタン
                    this.Delete_Button.Visible = true;
                    this.Revive_Button.Visible = true;
                    this.Ok_Button.Visible = false;
                    this.Cancel_Button.Visible = true;
                    break;
            }
        }

        /// <summary>
        /// 画面情報格納処理
        /// </summary>
        /// <param name="blCodeChange">BLコード変換マスタオブジェクト</param>
        /// <remarks>
        /// <br>Note       : 画面情報からBLコード変換マスタオブジェクトにデータを格納します。</br>
        /// <br>Programmer : 吉岡 孝憲 30745</br>
        /// <br>Date       : 2012/08/01</br>
        /// <br></br>
        /// </remarks>
        private void DispToBLGoodsCdChgU(ref BLGoodsCdChgU blCodeChange)
        {
            if (blCodeChange == null)
            {
                // 新規の場合
                blCodeChange = newBLGoodsCdChgU();
            }

            blCodeChange.CustomerCode = tNedit_CustomerCd.GetInt();
            blCodeChange.PMBLGoodsCode = tNedit_PMBLCd.GetInt();
            blCodeChange.SFBLGoodsCode = tNedit_SFBLCd.GetInt();
            // 現状、名称の設定は不要（新規作成時）
            blCodeChange.BLGoodsFullName = string.Empty;
            blCodeChange.BLGoodsHalfName = string.Empty;
        }

        /// <summary>
        /// 画面展開処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 全体項目表示名称クラスから画面にデータを展開します。</br>
        /// <br>Programmer : 吉岡 孝憲 30745</br>
        /// <br>Date       : 2012/08/01</br>
        /// </remarks>
        private void AlItmDspNmToScreen()
        {
            this.tNedit_CustomerCd.Text = _blCodeChangeU.CustomerCode.ToString();
            this.tNedit_PMBLCd.Text = _blCodeChangeU.PMBLGoodsCode.ToString();
            this.tNedit_SFBLCd.Text = _blCodeChangeU.SFBLGoodsCode.ToString();
        }

        /// <summary>
        /// 画面クリア処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面をクリアします。</br>
        /// <br>Programmer : 吉岡 孝憲 30745</br>
        /// <br>Date       : 2012/08/01</br>
        /// </remarks>
        private void ScreenClear()
        {

            // モードラベル
            this.Mode_Label.Text = INSERT_MODE;

            // ボタン
            this.Delete_Button.Visible = false;  // 完全削除ボタン
            this.Revive_Button.Visible = false;  // 復活ボタン
            this.Ok_Button.Visible = true;  // 保存ボタン
            this.Cancel_Button.Visible = true;  // 閉じるボタン

            // 得意先
            this.tNedit_CustomerCd.Clear();
            this.uLabel_CustomerNm.Text = "";
            this.tNedit_CustomerCd.Enabled = true;
            this.uButton_CustomerGuide.Enabled = true;
            this._customerCodePre = -1;
            this._customerNamePre = string.Empty;

            // PM側BL商品コード
            this.tNedit_PMBLCd.Clear();
            this.tNedit_PMBLCd.Enabled = true;
            this.uButton_PMBLCdGuid.Enabled = true;
            this._pmBLCdPre = -1;
            this._pmBLCdGoodsFullName = string.Empty;

            // SF側BL商品コード
            this.tNedit_SFBLCd.Clear();
            this.tNedit_SFBLCd.Enabled = true;
            this.uButton_SFBLCdGuid.Enabled = true;
            this._sfBLCdPre = -1;
            this._sfBLCdEditCnt = 0;
            this._sfBLCdGoodsFullName = string.Empty;
        }

        /// <summary>
        /// 画面再構築処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面を再構築します。</br>
        /// <br>Programmer : 吉岡 孝憲 30745</br>
        /// <br>Date       : 2012/08/01</br>
        /// </remarks>
        private void ScreenReconstruction()
        {
            this._blCodeChangeU = newBLGoodsCdChgU();
            BLGoodsCdChgU blCodeChange = newBLGoodsCdChgU();

            // 新規の場合
            if (this._dataIndex < 0)
            {
                // 画面展開処理
                BLGoodsCdChgUToScreen(blCodeChange);
                // 画面クリア
                this.ScreenClear();
                // クローン作成
                this._blGoodsCdChgUClone = blCodeChange.Clone();

                // フォーカス設定
                this.tNedit_CustomerCd.Focus();
                // 画面入力許可制御処理
                ScreenInputPermissionControl(INSERT_MODE);
                // 画面展開処理
                DispToBLGoodsCdChgU(ref this._blGoodsCdChgUClone);
            }
            // 削除　又は　更新　の場合
            else
            {
                // 表示情報取得
                Guid guid = (Guid)this.Bind_DataSet.Tables[BLGOODSCDCHGU_TABLE].Rows[this._dataIndex][GUID_TITLE];
                blCodeChange = (BLGoodsCdChgU)this._blCodeChangeTable[guid];

                // 画面展開処理
                BLGoodsCdChgUToScreen(blCodeChange);
                // 更新の場合
                if (blCodeChange.LogicalDeleteCode == 0)
                {
                    // 更新可能状態の時
                    this.Mode_Label.Text = UPDATE_MODE;

                    //クローン作成
                    this._blGoodsCdChgUClone = blCodeChange.Clone();

                    // 画面展開処理
                    DispToBLGoodsCdChgU(ref this._blGoodsCdChgUClone);
                    // 画面入力許可制御処理
                    ScreenInputPermissionControl(UPDATE_MODE);

                    this.tNedit_SFBLCd.SelectAll();

                    this._pmBLCdPre = blCodeChange.PMBLGoodsCode;
                    this._sfBLCdPre = blCodeChange.PMBLGoodsCode;
                    this._pmBLCdGoodsFullName = blCodeChange.BLGoodsFullName;
                }
                // 削除の場合
                else
                {
                    // 削除モード
                    this.Mode_Label.Text = DELETE_MODE;

                    // 画面展開処理
                    BLGoodsCdChgUToScreen(blCodeChange);
                    // 画面入力許可制御処理
                    ScreenInputPermissionControl(DELETE_MODE);
                    this.Delete_Button.Focus();
                }

                this._detailsIndexBuf = this._dataIndex;
            }
        }

        /// <summary>
        ///  BLコード変換マスタ（ユーザー登録）の初期化　
        /// （固定値を設定）
        /// </summary>
        /// <returns></returns>
        private BLGoodsCdChgU newBLGoodsCdChgU()
        {
            BLGoodsCdChgU work = new BLGoodsCdChgU();
            work.EnterpriseCode = this._enterpriseCode;
            work.SectionCode = this._sectionCode;
            work.PMBLGoodsCodeDerivNo = 0;
            work.SFBLGoodsCodeDerivNo = 0;
            return work;
        }


        /// <summary>
        /// 画面入力チェック処理
        /// </summary>
        /// <returns>チェック結果(true: OK, false:NG)</returns>
        /// <remarks>
        /// <br>Note       : 画面の入力チェックを行います。</br>
        /// <br>Programmer : 吉岡 孝憲 30745</br>
        /// <br>Date       : 2012/08/01</br>
        /// </remarks>
        private bool SaveProc()
        {
            const string ctPROCNM = "SaveProc";
            bool result = false;

            Control control = null;
            string message = null;

            if (this.ScreenDataCheck(ref control, ref message) == false)
            {
                // 入力チェック
                TMsgDisp.Show(
                    this,                                  // 親ウィンドウフォーム
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,    // エラーレベル
                    CT_PGID,                               // アセンブリＩＤまたはクラスＩＤ
                    message,                               // 表示するメッセージ
                    0,                                     // ステータス値
                    MessageBoxButtons.OK);                // 表示するボタン

                // コントロールを選択
                control.Focus();

                if (control is TNedit)
                {
                    ((TNedit)control).SelectAll();
                }
                return false;
            }

            // 表示情報取得
            if (this.DataIndex >= 0)
            {
                Guid guid = (Guid)this.Bind_DataSet.Tables[BLGOODSCDCHGU_TABLE].Rows[this._dataIndex][GUID_TITLE];
                _blCodeChangeU = (BLGoodsCdChgU)this._blCodeChangeTable[guid];
            }
            // 画面から全体項目表示名称のデータを取得
            DispToBLGoodsCdChgU(ref this._blCodeChangeU);

            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            status = this._blCodeChangeAcs.Write(ref this._blCodeChangeU);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        BLGoodsCdChgUToDataSet(_blCodeChangeU.Clone(), this.DataIndex);
                        result = true;
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE:
                    {
                        // コード重複
                        TMsgDisp.Show(
                            this,                                    // 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_INFO,             // エラーレベル
                            CT_PGID,                                 // アセンブリＩＤまたはクラスＩＤ
                            "このコードは既に使用されています。",    // 表示するメッセージ
                            0,                                       // ステータス値
                            MessageBoxButtons.OK);                   // 表示するボタン

                        return result;
                    }
                // 排他制御
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        this.ExclusiveTransaction(status, true);
                        return result;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT:
                    {
                        // TIMEOUT
                        TMsgDisp.Show(
                            this,                               // 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOP,        // エラーレベル
                            CT_PGID,                            // アセンブリＩＤまたはクラスＩＤ
                            this.Name,                          // プログラム名称
                            ctPROCNM,                           // 処理名称
                            TMsgDisp.OPE_UPDATE,                // オペレーション
                            ERR_WRITE_TIME_MSG,                 // 表示するメッセージ
                            status,                             // ステータス値
                            this._blCodeChangeAcs,                // エラーが発生したオブジェクト
                            MessageBoxButtons.OK,               // 表示するボタン
                            MessageBoxDefaultButton.Button1);   // 初期表示ボタン
                        this.CloseForm(DialogResult.Cancel);
                        return result;
                    }
                default:
                    {
                        // 登録失敗
                        TMsgDisp.Show(
                            this,                                 // 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOP,          // エラーレベル
                            CT_PGID,                              // アセンブリＩＤまたはクラスＩＤ
                            CT_PGNM,                              // プログラム名称
                            ctPROCNM,                             // 処理名称
                            TMsgDisp.OPE_READ,                    // オペレーション
                            "登録に失敗しました。",               // 表示するメッセージ
                            status,                               // ステータス値
                            this._blCodeChangeAcs,                    // エラーが発生したオブジェクト
                            MessageBoxButtons.OK,                 // 表示するボタン
                            MessageBoxDefaultButton.Button1);     // 初期表示ボタン
                        this.CloseForm(DialogResult.Cancel);
                        return result;
                    }
            }

            return result;
        }

        /// <summary>
        /// 画面Check
        /// </summary>
        /// <param name="control">STATUS</param>
        /// <param name="message">非表示フラグ(true: 非表示にする, false: 非表示にしない)</param>
        /// <remarks>
        /// <br>Note       : 画面Checkを行います</br>
        /// <br>Programmer : 吉岡 孝憲 30745</br>
        /// <br>Date       : 2012/08/01</br>
        /// </remarks>
        private bool ScreenDataCheck(ref Control control, ref string message)
        {
            bool result = true;
            // 得意先
            if (this.tNedit_CustomerCd.Text == string.Empty)
            {
                control = this.tNedit_CustomerCd;
                message = "得意先コードを入力して下さい。";
                result = false;
            }
            else if (this.uLabel_CustomerNm.Text.Trim() == string.Empty)
            {
                control = this.tNedit_CustomerCd;
                message = "得意先コードがマスタに登録されていません。";
                result = false;
            }

            // PM側BLコード
            else if (this.tNedit_PMBLCd.Text == string.Empty)
            {
                control = this.tNedit_PMBLCd;
                message = "PM側BLコードを入力して下さい。";
                result = false;
            }
            else if (this._pmBLCdGoodsFullName.Trim() == string.Empty)
            {
                control = this.tNedit_PMBLCd;
                message = "PM側BLコードマスタに登録されていません。";
                result = false;
            }

            // SF側BLコード
            else if (this.tNedit_SFBLCd.Text == string.Empty)
            {
                control = this.tNedit_SFBLCd;
                message = "SF側BLコードを入力して下さい。";
                result = false;
            }
            else if (this._sfBLCdGoodsFullName.Trim() == string.Empty)
            {
                // 更新モードで、編集回数が０回の場合は除く
                if (!(this.Mode_Label.Text.Trim() == UPDATE_MODE && this._sfBLCdEditCnt.Equals(0)))
                {
                    control = this.tNedit_SFBLCd;
                    message = "SF側BLコードマスタに登録されていません。";
                    result = false;
                }
            }

            return result;
        }

        /// <summary>
        /// 排他処理
        /// </summary>
        /// <param name="status">STATUS</param>
        /// <param name="hide">非表示フラグ(true: 非表示にする, false: 非表示にしない)</param>
        /// <remarks>
        /// <br>Note       : 排他処理を行います</br>
        /// <br>Programmer : 吉岡 孝憲 30745</br>
        /// <br>Date       : 2012/08/01</br>
        /// </remarks>
        private void ExclusiveTransaction(int status, bool hide)
        {
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    {
                        // 他端末更新
                        TMsgDisp.Show(
                            this,                                  // 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,    // エラーレベル
                            CT_PGID,                               // アセンブリＩＤまたはクラスＩＤ
                            "既に他端末より更新されています。",    // 表示するメッセージ
                            0,                                     // ステータス値
                            MessageBoxButtons.OK);                 // 表示するボタン
                        if (hide == true)
                        {
                            this.CloseForm(DialogResult.Cancel);
                        }
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        // 他端末削除
                        TMsgDisp.Show(
                            this,                                  // 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,    // エラーレベル
                            CT_PGID,                               // アセンブリＩＤまたはクラスＩＤ
                            "既に他端末より削除されています。",    // 表示するメッセージ
                            0,                                     // ステータス値
                            MessageBoxButtons.OK);                 // 表示するボタン
                        if (hide == true)
                        {
                            this.CloseForm(DialogResult.Cancel);
                        }
                        break;
                    }
            }
        }

        /// <summary>
        /// フォームクローズ処理
        /// </summary>
        /// <param name="dialogResult">ダイアログ結果</param>
        /// <remarks>
        /// <br>Note       : フォームを閉じます。その際画面クローズイベント等の発生を行います。</br>
        /// <br>Programmer : 吉岡 孝憲 30745</br>
        /// <br>Date       : 2012/08/01</br>
        /// </remarks>
        private void CloseForm(DialogResult dialogResult)
        {
            // 画面非表示イベント
            if (this.UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(dialogResult);
                this.UnDisplaying(this, me);
            }

            this.DialogResult = dialogResult;

            // 比較用クローンクリア
            this._blGoodsCdChgUClone = null;

            // CanCloseプロパティがfalseの場合は、クローズ処理をキャンセルして
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
        /// 得意先名称の取得
        /// </summary>
        /// <param name="customerCode"> 得意先コード</param>
        /// <returns>得意先名称</returns>
        /// <remarks>
        /// <br>Note       : 拠点名称の取得を行います。</br>
        /// <br>Programmer : 吉岡 孝憲 30745</br>
        /// <br>Date       : 2012/08/01</br>
        /// </remarks>
        private string GetCustomerNm(int customerCode)
        {

            string customerNm = string.Empty;
            if (_customerTb == null)
            {
                GetAllCustomerNm();
            }
            if (_customerTb != null && _customerTb.ContainsKey(customerCode))
            {
                customerNm = (string)_customerTb[customerCode];
            }
            return customerNm;
        }

        /// <summary>
        /// 得意先名称の取得
        /// </summary>
        /// <remarks>
        /// <br>Note       : 得意先名称の取得を行います。</br>
        /// <br>Programmer : 吉岡 孝憲 30745</br>
        /// <br>Date       : 2012/08/01</br>
        /// </remarks>
        private void GetAllCustomerNm()
        {
            if (this._customerInfoAcs == null)
            {
                this._customerInfoAcs = new CustomerInfoAcs();
            }
            if (this._customerTb == null)
            {
                _customerTb = new Hashtable();
            }
            else
            {
                _customerTb.Clear();
            }


            List<CustomerInfo> customerList;

            int status = this._customerInfoAcs.Search(this._enterpriseCode, true, true, out customerList);
            if (status == (int)(int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                foreach (CustomerInfo customer in customerList)
                {
                    if (customer.LogicalDeleteCode == 0)
                    {
                        _customerTb.Add(customer.CustomerCode, customer.CustomerSnm);
                    }
                }
            }
        }

        /// <summary>
        /// BLコード変換マスタ展開処理
        /// </summary>
        /// <param name="blCodeChange">BLコード変換マスタ</param>
        /// <param name="index">データセットへ展開するインデックス</param>
        /// <remarks>
        /// <br>Note       : BLコード変換マスタクラスをデータセットに格納します。</br>
        /// <br>Programmer : 吉岡 孝憲 30745</br>
        /// <br>Date       : 2012/08/01</br>
        /// </remarks>
        private void BLGoodsCdChgUToDataSet(BLGoodsCdChgU blCodeChange, int index)
        {

            if ((index < 0) || (this.Bind_DataSet.Tables[BLGOODSCDCHGU_TABLE].Rows.Count <= index))
            {
                // 新規と判断して、行を追加する
                DataRow dataRow = this.Bind_DataSet.Tables[BLGOODSCDCHGU_TABLE].NewRow();
                this.Bind_DataSet.Tables[BLGOODSCDCHGU_TABLE].Rows.Add(dataRow);

                // indexを行の最終行番号する
                index = this.Bind_DataSet.Tables[BLGOODSCDCHGU_TABLE].Rows.Count - 1;
            }

            // 論理削除区分
            if (blCodeChange.LogicalDeleteCode == 0)
            {
                // 更新可能状態の時
                this.Bind_DataSet.Tables[BLGOODSCDCHGU_TABLE].Rows[index][DELETE_DATE] = "";
            }
            else
            {
                // 削除状態の時
                this.Bind_DataSet.Tables[BLGOODSCDCHGU_TABLE].Rows[index][DELETE_DATE] = blCodeChange.UpdateDateTimeJpInFormal;
            }

            // 得意先コード
            this.Bind_DataSet.Tables[BLGOODSCDCHGU_TABLE].Rows[index][CUSTOMER_CODE_TITLE] = blCodeChange.CustomerCode;
            // 得意先名称
            this.Bind_DataSet.Tables[BLGOODSCDCHGU_TABLE].Rows[index][CUSTOMER_NAME_TITLE] = GetCustomerNm(blCodeChange.CustomerCode);
            // PM側BLコード
            this.Bind_DataSet.Tables[BLGOODSCDCHGU_TABLE].Rows[index][PMBL_CODE_TITLE] = blCodeChange.PMBLGoodsCode;
            // SF側BLコード
            this.Bind_DataSet.Tables[BLGOODSCDCHGU_TABLE].Rows[index][SFBL_CODE_TITLE] = blCodeChange.SFBLGoodsCode;

            // GUID
            this.Bind_DataSet.Tables[BLGOODSCDCHGU_TABLE].Rows[index][GUID_TITLE] = blCodeChange.FileHeaderGuid;

            if (this._blCodeChangeTable.ContainsKey(blCodeChange.FileHeaderGuid))
            {
                this._blCodeChangeTable.Remove(blCodeChange.FileHeaderGuid);
            }
            this._blCodeChangeTable.Add(blCodeChange.FileHeaderGuid, blCodeChange);
        }

        /// <summary>
        /// データセット列情報構築処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : データセットの列情報を構築します。
        ///					 データセットの列情報がフレームのビュー用グリッドの列になります</br>
        /// <br>Programmer : 吉岡 孝憲 30745</br>
        /// <br>Date       : 2012/08/01</br>
        /// </remarks>
        private void DataSetColumnConstruction()
        {
            DataTable blCodeChangeTable = new DataTable(BLGOODSCDCHGU_TABLE);

            // Addを行う順番が、列の表示順位となります。
            blCodeChangeTable.Columns.Add(DELETE_DATE, typeof(string));                     // 削除日       
            blCodeChangeTable.Columns.Add(CUSTOMER_CODE_TITLE, typeof(int));			    // 得意先コード
            blCodeChangeTable.Columns.Add(CUSTOMER_NAME_TITLE, typeof(string));            // 得意先名称
            blCodeChangeTable.Columns.Add(PMBL_CODE_TITLE, typeof(int));			    // PM側BLコード
            blCodeChangeTable.Columns.Add(SFBL_CODE_TITLE, typeof(int));			    // SF側BLコード

            blCodeChangeTable.Columns.Add(GUID_TITLE, typeof(Guid));
            this.Bind_DataSet.Tables.Add(blCodeChangeTable);
        }

        /// <summary>
        /// BLコード変換マスタ（ユーザー登録）ヘッダファイルクラス画面展開処理
        /// </summary>
        /// <param name="blCodeChange">BLコード変換マスタ（ユーザー登録）ヘッダファイルオブジェクト</param>
        /// <remarks>
        /// <br>Note       : オブジェクトから画面にデータを展開します。</br>
        /// <br>Programmer : 吉岡 孝憲 30745</br>
        /// <br>Date       : 2012/08/01</br>
        /// </remarks>
        private void BLGoodsCdChgUToScreen(BLGoodsCdChgU blCodeChange)
        {
            //得意先コード
            this.tNedit_CustomerCd.Text = blCodeChange.CustomerCode.ToString();
            //得意先名称
            this.uLabel_CustomerNm.Text = GetCustomerNm(blCodeChange.CustomerCode);
            //PM側BLコード
            this.tNedit_PMBLCd.Text = blCodeChange.PMBLGoodsCode.ToString();
            //SF側BLコード
            this.tNedit_SFBLCd.Text = blCodeChange.SFBLGoodsCode.ToString();
        }

        #endregion

        /// <summary>
        /// PM側BLコード　ガイドボタンクリック
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <br>Note        : </br>
        /// <br>Programmer  : 30745 吉岡 孝憲</br>
        /// <br>Date        : 2012/08/01</br>
        /// </remarks>
        private void uButton_PMBLCdGuid_Click(object sender, EventArgs e)
        {
            BLGoodsCdUMnt bLGoodsCdUMnt;

            // ガイド起動
            int status = _blGoodsCdAcs.ExecuteGuid(this._enterpriseCode, out bLGoodsCdUMnt);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                tNedit_PMBLCd.SetInt(bLGoodsCdUMnt.BLGoodsCode);
                this._pmBLCdGoodsFullName = bLGoodsCdUMnt.BLGoodsFullName;

                // 次フォーカス
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        /// <summary>
        /// SF側BLコード　ガイドボタンクリック
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <br>Note        : </br>
        /// <br>Programmer  : 30745 吉岡 孝憲</br>
        /// <br>Date        : 2012/08/01</br>
        /// </remarks>
        private void uButton_SFBLCdGuid_Click(object sender, EventArgs e)
        {
            BLGoodsCdUMnt bLGoodsCdUMnt;

            // ガイド起動
            int status = _blGoodsCdAcs.ExecuteGuid(this._enterpriseCode, out bLGoodsCdUMnt);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // 開始
                tNedit_SFBLCd.SetInt(bLGoodsCdUMnt.BLGoodsCode);
                this._sfBLCdGoodsFullName = bLGoodsCdUMnt.BLGoodsFullName;

                // 次フォーカス
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }

    }
}

