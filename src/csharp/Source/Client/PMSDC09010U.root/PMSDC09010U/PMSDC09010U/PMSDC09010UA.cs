//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 接続先情報設定マスタメンテナンス
// プログラム概要   : 接続先情報設定マスタの登録・変更・削除を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2019 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11570219-00 作成担当 : 田建委
// 作 成 日  2019/12/03  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号  11570219-00 作成担当 : 小原
// 作 成 日  2020/02/04  修正内容 : （修正内容一覧No.2）備考設定変更項目追加
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Windows.Forms;
using System.Collections;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using System.Net.NetworkInformation;
using Broadleaf.Library.Globarization;
using Broadleaf.Application.Controller;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 接続先情報設定フォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note		: 接続先情報設定を行います。
    ///					  IMasterMaintenanceMultiTypeを実装しています。</br>
    /// <br>Programmer	: 田建委</br>
    /// <br>Date		: 2019/12/03</br>
    /// <br>管理番号    : 11570219-00</br>
    /// <br></br>
    /// <br>Update Note : 2020/02/04 小原 卓也</br>
    /// <br>管理番号    : 11570219-00</br>
    /// <br>            : （修正内容一覧No.2）備考設定変更項目追加</br>
    /// </remarks>
    public partial class PMSDC09010UA : Form,IMasterMaintenanceMultiType
    {
        #region コンストラクタ
        /// <summary>
        /// PMSDC09010Uコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note		: 接続先情報設定フォームクラスコンストラクタです</br>
        /// <br>Programer	: 田建委</br>
        /// <br>Date		: 2019/12/03</br>
        /// <br>管理番号    : 11570219-00</br>
        /// </remarks>
        public PMSDC09010UA()
        {
            InitializeComponent();

            // DataSet列情報構築処理
            DataSetColumnConstruction();

            // プロパティ初期値設定
            this._canPrint = false;
            this._canClose = true;
            this._canNew = true;
            this._canDelete = true;
            this._canLogicalDeleteDataExtraction = true;
            this._defaultAutoFillToColumn = false;
            this._canSpecificationSearch = false;

            // ConnectInfoWorkクラス
            this._connectInfoWork = new SalCprtConnectInfoWork();
            this._connectInfoWorkClone = new SalCprtConnectInfoWork();

            // connectInfoWorkAcsクラスアクセスクラス
            this._connectInfoWorkAcs = new SalCprtConnectInfoWorkAcs();

            this._customerInfoAcs = new CustomerInfoAcs();

            this._connectInfoWorkTable = new Hashtable();

            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            this._supplierAcs = new SupplierAcs();
            this._indexBuf = -2;
            this._supplierDic = new Dictionary<int, Supplier>();
            this._posTerminalMgAcs = new PosTerminalMgAcs();

            this._controlScreenSkin = new ControlScreenSkin();                                //スキンをロード
            this._controlScreenSkin.LoadSkin();
            this._controlScreenSkin.SettingScreenSkin(this);

            // 端末管理設定取得
            this.GetPosTerminalMgCache();

            // 得意先名称リスト取得
            this.GetCustomerNameList();
        }

        #endregion

        #region Private Member
        // プロパティ用
        private bool _canPrint;
        private bool _canLogicalDeleteDataExtraction;
        private bool _canClose;
        private bool _canNew;
        private bool _canDelete;
        private bool _canSpecificationSearch;
        private int _dataIndex;
        private bool _defaultAutoFillToColumn;

        private bool _isError = false;

        // 仕入先
        private SupplierAcs _supplierAcs;
        private Dictionary<int, Supplier> _supplierDic;

        private SalCprtConnectInfoWork _connectInfoWork;
        private SalCprtConnectInfoWorkAcs _connectInfoWorkAcs;
        private CustomerInfoAcs _customerInfoAcs;

        // 保存比較用Clone
        private SalCprtConnectInfoWork _connectInfoWorkClone;
        private ControlScreenSkin _controlScreenSkin;                           // スキン設定用クラス

        // HashTable
        private Hashtable _connectInfoWorkTable;

        // 端末管理情報キャッシュ
        private Dictionary<int, PosTerminalMg> _posTerminalMgDic;
        private PosTerminalMgAcs _posTerminalMgAcs = null;  // 端末管理設定アクセスクラス

        // 得意先情報キャッシュ
        private ArrayList _customerList;

        private int _indexBuf;
        private string _enterpriseCode;
        private bool _cusotmerGuideSelected;

        private const string ASSEMBLY_ID            = "PMSDC09010U";
        private const int SUPPLIERCODE              = 0;     
        private const string MAXHOUR                = "24";
        private const string MINMINUTE              = "00";

        // FrameのView用Grid列のKEY情報 (HeaderのTitle部となります)
        private const string DELETE_DATE            = "削除日";
        private const string VIEW_SECTIONCD         = "拠点";
        private const string VIEW_CUSTOMERCD        = "得意先";
        private const string VIEW_AUTOSENDDIV       = "自動送信区分";
        private const string VIEW_BOOTTIME          = "自動送信時間帯（起動）";
        private const string VIEW_ENDTIME           = "自動送信時間帯（終了）";
        private const string VIEW_EXECINTERVAL      = "実行間隔";
        private const string VIEW_CNECTSENDDIV      = "自動接続送信区分";
        private const string CASH_REGISTER_NO       = "自動送信起動端末";
        private const string VIEW_SENDMACHINENAME   = "自動送信起動端末名称";
        private const string VIEW_SENDMACHINEIPADDR = "IPアドレス";
        // --- ADD 2020/02/04 T.Obara ---------- 修正内容一覧No.2 >>>>>
        private const string VIEW_NOTE1SETDIV       = "備考１";
        private const string VIEW_NOTE2SETDIV       = "備考２";
        private const string VIEW_NOTE3SETDIV       = "備考３";
        // --- ADD 2020/02/04 T.Obara ---------- 修正内容一覧No.2 <<<<<
        private const string VIEW_CONNECTUSERID     = "ユーザーコード";
        private const string VIEW_CONNECTPASSWORD   = "パスワード";
        private const string VIEW_DOMAIN            = "ドメイン";
        private const string VIEW_CPRTURL           = "アドレス";
        private const string VIEW_TIMEOUT           = "タイムアウト";
        private const string VIEW_RETRYCNT          = "リトライ回数";
        private const string VIEW_CNECTFILEID       = "接続ファイルID";
        private const string VIEW_FRSTSENDDATE      = "初回送信基準日";
        private const string VIEW_LTATSADDATETIME   = "前回自動送信日時";
        //GUID
        private const string VIEW_FILEHEADERGUID    = "Guid";

        // View用Gridに表示させるテーブル名
        private const string VIEW_TABLE             = "VIEW_TABLE";

        // 編集モード
        private const string INSERT_MODE            = "新規モード";
        private const string UPDATE_MODE            = "更新モード";
        private const string DELETE_MODE            = "削除モード";
        #endregion

        #region Main Entry Point
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            System.Windows.Forms.Application.Run(new PMSDC09010UA());
        }
        #endregion

        #region IMasterMaintenanceMultiType メンバ
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
        /// <summary>件数指定抽出可能設定プロパティ</summary>
        /// <value>件数指定抽出を可能とするかどうかの設定を取得します。</value>
        public bool CanSpecificationSearch
        {
            get
            {
                return this._canSpecificationSearch;
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
        /// <summary>
        /// データ論理削除処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 選択中のデータを削除します。</br>
        /// <br>Programer  : 田建委</br>
        /// <br>Date	   : 2019/12/03</br>
        /// <br>管理番号   : 11570219-00</br>
        /// <br></br>
        /// </remarks>
        public int Delete()
        {
            // 保持しているデータセットより修正前情報取得
            Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this.DataIndex][VIEW_FILEHEADERGUID];

            SalCprtConnectInfoWork connectInfoWork = (SalCprtConnectInfoWork)this._connectInfoWorkTable[guid];

            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            // 接続先情報設定マスタ情報論理削除処理
            status = this._connectInfoWorkAcs.LogicalDelete(ref connectInfoWork);

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
                            ASSEMBLY_ID, 						// アセンブリＩＤまたはクラスＩＤ
                            this.Text, 				            // プログラム名称
                            "Delete", 							// 処理名称
                            TMsgDisp.OPE_HIDE, 					// オペレーション
                            "削除に失敗しました。", 			// 表示するメッセージ
                            status, 							// ステータス値
                            this._connectInfoWorkAcs, 				// エラーが発生したオブジェクト
                            MessageBoxButtons.YesNo, 				// 表示するボタン
                            MessageBoxDefaultButton.Button1);	// 初期表示ボタン
                        return status;
                    }
            }

            // 接続先情報設定マスタデータセット展開処理
            ConnectInfoWorkToDataSet(connectInfoWork, this.DataIndex);
            return 0;
        }


        /// <summary>
        /// 排他処理
        /// </summary>
        /// <param name="status">TATUS</param>
        /// <remarks>
        /// <br>Note       : 排他処理を行います</br>
        /// <br>Programer  : 田建委</br>
        /// <br>Date	   : 2019/12/03</br>
        /// <br>管理番号   : 11570219-00</br>
        /// <br></br>
        /// </remarks>
        private void ExclusiveTransaction(int status)
        {
            if (status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE
                || status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE)
            {
                TMsgDisp.Show(this,                         // 親ウィンドウフォーム
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,     // エラーレベル
                    ASSEMBLY_ID,							// アセンブリID
                    "既に他端末より更新されています。",	    // 表示するメッセージ
                    status,									// ステータス値
                    MessageBoxButtons.OK);					// 表示するボタン
            }
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// グリッド列外観情報取得処理
        /// </summary>
        /// <returns>グリッド列外観情報格納Hashtable</returns>
        /// <remarks>
        /// <br>Note       : 各列の外見を設定するクラスを格納したHashtableを取得します。</br>
        /// <br>Programer  : 田建委</br>
        /// <br>Date	   : 2019/12/03</br>
        /// <br>管理番号   : 11570219-00</br>
        /// <br></br>
        /// <br>Update Note : 2020/02/04 小原 卓也</br>
        /// <br>管理番号    : 11570219-00</br>
        /// <br>            : （修正内容一覧No.2）備考設定変更項目追加</br>
        /// </remarks>
        public System.Collections.Hashtable GetAppearanceTable()
        {
            Hashtable appearanceTable = new Hashtable();

            // 削除日
            appearanceTable.Add(DELETE_DATE, new GridColAppearance(MGridColDispType.DeletionDataBoth, ContentAlignment.MiddleCenter, "", Color.Red));
            // 拠点
            appearanceTable.Add(VIEW_SECTIONCD, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleCenter, "", Color.Black));
            // 得意先
            appearanceTable.Add(VIEW_CUSTOMERCD, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleCenter, "", Color.Black));
            // 自動送信時間帯（起動）
            appearanceTable.Add(VIEW_BOOTTIME, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 自動送信時間帯（終了）
            appearanceTable.Add(VIEW_ENDTIME, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 実行間隔
            appearanceTable.Add(VIEW_EXECINTERVAL, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            // 自動接続送信区分
            appearanceTable.Add(VIEW_CNECTSENDDIV, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 端末番号
            appearanceTable.Add(CASH_REGISTER_NO, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "00#", Color.Black));
            // 送信端末
            appearanceTable.Add(VIEW_SENDMACHINENAME, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 端末IPアドレス
            appearanceTable.Add(VIEW_SENDMACHINEIPADDR, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // --- ADD 2020/02/04 T.Obara ---------- 修正内容一覧No.2 >>>>>
            // 出力設定備考１
            appearanceTable.Add(VIEW_NOTE1SETDIV, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 出力設定備考２
            appearanceTable.Add(VIEW_NOTE2SETDIV, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 出力設定備考３
            appearanceTable.Add(VIEW_NOTE3SETDIV, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // --- ADD 2020/02/04 T.Obara ---------- 修正内容一覧No.2 <<<<<
            // ユーザーコード
            appearanceTable.Add(VIEW_CONNECTUSERID, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // パスワード
            appearanceTable.Add(VIEW_CONNECTPASSWORD, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // ドメイン
            appearanceTable.Add(VIEW_DOMAIN, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // アドレス
            appearanceTable.Add(VIEW_CPRTURL, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 自動送信区分
            appearanceTable.Add(VIEW_AUTOSENDDIV, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // タイムアウト
            appearanceTable.Add(VIEW_TIMEOUT, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            // リトライ回数
            appearanceTable.Add(VIEW_RETRYCNT, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            // 接続ファイルID
            appearanceTable.Add(VIEW_CNECTFILEID, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 初回送信基準日
            appearanceTable.Add(VIEW_FRSTSENDDATE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 前回自動送信日時
            appearanceTable.Add(VIEW_LTATSADDATETIME, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // GUID
            appearanceTable.Add(VIEW_FILEHEADERGUID, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));

            return appearanceTable;
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// バインドデータセット取得処理
        /// </summary>
        /// <param name="bindDataSet">グリッドリッド用データセット</param>
        /// <param name="tableName">テーブル名称</param>
        /// <remarks>
        /// <br>Note        : グリッドにバインドさせるデータセットを取得します。</br>
        /// <br>Programer	: 田建委</br>
        /// <br>Date		: 2019/12/03</br>
        /// <br>管理番号    : 11570219-00</br>
        /// </remarks>
        public void GetBindDataSet(ref DataSet bindDataSet, ref string tableName)
        {
            bindDataSet = this.Bind_DataSet;
            tableName = VIEW_TABLE;
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// 印刷処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 印刷処理を実行します。</br>
        /// <br>Programer  : 田建委</br>
        /// <br>Date	   : 2019/12/03</br>
        /// <br>管理番号   : 11570219-00</br>
        /// <br></br>
        /// </remarks>
        public int Print()
        {
            // 印刷用アセンブリをロードする（未実装）
            return 0;
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// データ検索処理
        /// </summary>
        /// <param name="totalCount">全該当件数</param>
        /// <param name="readCount">抽出対象件数</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 先頭から指定件数分のデータを検索し、抽出結果を展開したDataSetと全該当件数を返します。</br>
        /// <br>Programer  : 田建委</br>
        /// <br>Date	   : 2019/12/03</br>
        /// <br>管理番号   : 11570219-00</br>
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
            ArrayList connectInfoWorkAcsList = null;
      
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Clear();
            this._connectInfoWorkTable.Clear();
            // 全検索
            status = this._connectInfoWorkAcs.SearchAll(out connectInfoWorkAcsList, this._enterpriseCode);
            if (connectInfoWorkAcsList != null)
            {
                totalCount = connectInfoWorkAcsList.Count;
            }

            switch (status)
            {
                case (int)ConstantManagement.MethodResult.ctFNC_NORMAL:
                    {
                        int index = 0;

                        foreach (SalCprtConnectInfoWork connectInfoWork in connectInfoWorkAcsList)
                        {

                            // オートバックス設定オブジェクトデータセット展開処理
                            ConnectInfoWorkToDataSet(connectInfoWork, index);
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
                            "PMSDC09010UA",							// アセンブリID
                            "オートバックス設定",              　　   // プログラム名称
                            "Search",                               // 処理名称
                            TMsgDisp.OPE_GET,                       // オペレーション
                            "読み込みに失敗しました。",				// 表示するメッセージ
                            status,									// ステータス値
                            this._connectInfoWorkAcs,					    // エラーが発生したオブジェクト
                            MessageBoxButtons.OK,					// 表示するボタン
                            MessageBoxDefaultButton.Button1);		// 初期表示ボタン

                        break;
                    }
            }
            return status;
        }

        /// <summary>
        /// 接続先情報設定マスタオブジェクトデータセット展開処理
        /// </summary>
        /// <param name="connectInfoWork">接続先情報設定マスタオブジェクト</param>
        /// <param name="index">データセットへ展開するインデックス</param>
        /// <remarks>
        /// <br>Note       : 接続先情報設定マスタメンテナンスクラスをデータセットに格納します。</br>
        /// <br>Programer  : 田建委</br>
        /// <br>Date	   : 2019/12/03</br>
        /// <br>管理番号   : 11570219-00</br>
        /// <br></br>
        /// <br>Update Note : 2020/02/04 小原 卓也</br>
        /// <br>管理番号    : 11570219-00</br>
        /// <br>            : （修正内容一覧No.2）備考設定変更項目追加</br>
        /// </remarks>
        private void ConnectInfoWorkToDataSet(SalCprtConnectInfoWork connectInfoWork, int index)
        {
            // indexの値がDataSetの既存行をさしていなかったら
            if ((index < 0) || (this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Count <= index))
            {
                // 新規と判断して、行を追加する
                DataRow dataRow = this.Bind_DataSet.Tables[VIEW_TABLE].NewRow();
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Add(dataRow);

                // indexに行の最終行番号をセットする
                index = this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Count - 1;
            }
            // 削除日
            if (connectInfoWork.LogicalDeleteCode == 0)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][DELETE_DATE] = string.Empty;
            }
            else
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][DELETE_DATE] = TDateTime.DateTimeToString("ggYY/MM/DD", connectInfoWork.UpdateDateTime);
            }
            // 自動送信区分
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_AUTOSENDDIV] = (connectInfoWork.AutoSendDiv == 0) ? "する" : "しない";
            //拠点
            if (connectInfoWork.SectionCode == "0")
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SECTIONCD] = string.Empty;
            }
            else
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SECTIONCD] = connectInfoWork.SectionCode.PadLeft(2, '0');
            }
            //得意先
            if (connectInfoWork.CustomerCode == 0)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CUSTOMERCD] = string.Empty;
            }
            else
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CUSTOMERCD] = connectInfoWork.CustomerCode.ToString().PadLeft(8, '0');
            }

            //自動送信時間帯（起動）
            if (connectInfoWork.BootTime == 0)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_BOOTTIME] = string.Empty;
            }
            else
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_BOOTTIME] = connectInfoWork.BootTime.ToString().PadLeft(4, '0').Substring(0, 2) + ":" + connectInfoWork.BootTime.ToString().PadLeft(4, '0').Substring(2, 2);
            }
            //自動送信時間帯（終了）
            if (connectInfoWork.EndTime == 0)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_ENDTIME] = string.Empty;
            }
            else
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_ENDTIME] = connectInfoWork.EndTime.ToString().PadLeft(4, '0').Substring(0, 2) + ":" + connectInfoWork.EndTime.ToString().PadLeft(4, '0').Substring(2, 2);
            }

            //実行間隔
            if (connectInfoWork.ExecInterval == 0)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_EXECINTERVAL] = string.Empty;
            }
            else
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_EXECINTERVAL] = connectInfoWork.ExecInterval;
            }
            // 自動接続送信区分
            if (connectInfoWork.AutoSendDiv != 0)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CNECTSENDDIV] = string.Empty;
            }
            else
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CNECTSENDDIV] = (connectInfoWork.CnectSendDiv == 2) ? "全て" : "未送信";
            }
            //初回送信基準日
            if (connectInfoWork.FrstSendDate == 0)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_FRSTSENDDATE] = string.Empty;
            }
            else
            {
                DateTime dt = DateTime.ParseExact(connectInfoWork.FrstSendDate.ToString(), "yyyyMMdd", System.Globalization.CultureInfo.CurrentCulture);
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_FRSTSENDDATE] = dt.ToString("yyyy年M月d日");
 
            }
            //前回自動送信日時
            if (connectInfoWork.LtAtSadDateTime == DateTime.MinValue)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_LTATSADDATETIME] = string.Empty;
            }
            else
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_LTATSADDATETIME] = connectInfoWork.LtAtSadDateTime.ToString("yyyy年M月d日H時m分s秒");
            }

            // --- ADD 2020/02/04 T.Obara ---------- 修正内容一覧No.2 >>>>>
            // 出力設定備考１　デフォルト値備考１のためelseに配置
            if (connectInfoWork.Note1SetDiv == 1)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_NOTE1SETDIV] = "指示書番号";
            }
            else if (connectInfoWork.Note1SetDiv == 2)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_NOTE1SETDIV] = "送信しない";
            }
            else
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_NOTE1SETDIV] = "備考１";
            }

            // 出力設定備考２　デフォルト値備考２のためelseに配置
            if (connectInfoWork.Note2SetDiv == 1)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_NOTE2SETDIV] = "指示書番号";
            }
            else if (connectInfoWork.Note2SetDiv == 2)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_NOTE2SETDIV] = "送信しない";
            }
            else
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_NOTE2SETDIV] = "備考２";
            }

            // 出力設定備考３　デフォルト値備考３のためelseに配置
            if (connectInfoWork.Note3SetDiv == 1)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_NOTE3SETDIV] = "指示書番号";
            }
            else if (connectInfoWork.Note3SetDiv == 2)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_NOTE3SETDIV] = "送信しない";
            }
            else
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_NOTE3SETDIV] = "備考３";
            }
            // --- ADD 2020/02/04 T.Obara ---------- 修正内容一覧No.2 <<<<<

            // ユーザーコード
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CONNECTUSERID] = connectInfoWork.SendCcnctUserid;
            // パスワード
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CONNECTPASSWORD] = connectInfoWork.SendCcnctPass;
            // ドメイン
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_DOMAIN] = connectInfoWork.CprtDomain;
            // アドレス
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CPRTURL] = connectInfoWork.CprtUrl;
            // タイムアウト
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_TIMEOUT] = connectInfoWork.LoginTimeoutVal;
            // リトライ回数
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_RETRYCNT] = connectInfoWork.RetryCnt;
            // 接続ファイルID
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CNECTFILEID] = connectInfoWork.CnectFileId;
            // 端末番号
            if (connectInfoWork.AutoSendDiv != 0)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][CASH_REGISTER_NO] = string.Empty;
            }
            else
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][CASH_REGISTER_NO] = connectInfoWork.CashregiSterno;
            }
            // 端末名
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SENDMACHINENAME] = connectInfoWork.SendMachineName;
            // 端末IPアドレス
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SENDMACHINEIPADDR] = connectInfoWork.SendMachineIpAddr;
            // GUID
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_FILEHEADERGUID] = connectInfoWork.FileHeaderGuid;
            // インスタンステーブルにもセットする
            if (this._connectInfoWorkTable.ContainsKey(connectInfoWork.FileHeaderGuid) == true)
            {
                this._connectInfoWorkTable.Remove(connectInfoWork.FileHeaderGuid);
            }
            
            this._connectInfoWorkTable.Add(connectInfoWork.FileHeaderGuid, connectInfoWork);
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// ネクストデータ検索処理
        /// </summary>
        /// <param name="readCount">抽出対象件数</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 指定した件数分のネクストデータを検索します。</br>
        /// <br>Programer  : 田建委</br>
        /// <br>Date	   : 2019/12/03</br>
        /// <br>管理番号   : 11570219-00</br>
        /// <br></br>
        /// </remarks>
        public int SearchNext(int readCount)
        {
            int status = 0;
            return status;
        }
        #endregion

        #region ----- イベント -----
        /// <summary>
        /// UnDisplaying
        /// </summary>
        public event MasterMaintenanceMultiTypeUnDisplayingEventHandler UnDisplaying;
        #endregion ----- イベント -----

        #region ----- オフライン状態チェック処理 -----
        /// <summary>
        /// ログオン時オンライン状態チェック処理
        /// </summary>
        /// <returns>チェック処理結果</returns>
        /// <remarks>
        /// <br>Note       : ログオン時オンライン状態チェック処理を行う。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2019/12/03</br>
        /// <br>管理番号   : 11570219-00</br>
        /// <br></br>
        /// </remarks>
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
        /// <remarks>
        /// <br>Note       : リモート接続可能判定を行う。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2019/12/03</br>
        /// <br>管理番号   : 11570219-00</br>
        /// <br></br>
        /// </remarks>
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

        #region ----- Private Method -----
        /// <summary>
        /// 画面入力許可制御処理
        /// </summary>
        /// <param name="setType">設定タイプ 0:新規, 1:更新, 2:削除</param>
        /// <remarks>
        /// <br>Note       : 画面の入力許可を制御します。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2019/12/03</br>
        /// <br>管理番号   : 11570219-00</br>
        /// <br></br>
        /// <br>Update Note : 2020/02/04 小原 卓也</br>
        /// <br>管理番号    : 11570219-00</br>
        /// <br>            : （修正内容一覧No.2）備考設定変更項目追加</br>
        /// </remarks>
        private void ScreenInputPermissionControl(int setType)
        {
            switch (setType)
            {
                default:
                // 0:新規
                case 0:
                    // 画面初期化 と画面入力許可制御処理
                    ScreenClear();
                    break;

                // 1:更新
                case 1:

                    // ボタン
                    this.Ok_Button.Visible = true;
                    this.Cancel_Button.Visible = true;
                    this.Revive_Button.Visible = false;
                    this.Delete_Button.Visible = false;

                    // パネル
                    this.tEdit_SectionCode.Enabled = false;
                    this.SectionGuide_Button.Enabled = false;
                    this.tNedit_CustomerCode.Enabled = false;
                    this.CustomerGuide_Button.Enabled = false;
                    this.AutoSendDiv_tCmbEdit.Enabled = true;
                    this.HourSt_tNedit.Enabled = true;
                    this.MinuteSt_tNedit.Enabled = true;
                    this.HourEd_tNedit.Enabled = true;
                    this.MinuteEd_tNedit.Enabled = true;
                    this.tNedit_ExecInterval.Enabled = true;
                    this.CnectSendDiv_tCmbEdit.Enabled = true;
                    this.tNedit_CashRegisterNo.Enabled = true;
                    // --- ADD 2020/02/04 T.Obara ---------- 修正内容一覧No.2 >>>>>
                    this.Note1SetDiv_tCmbEdit.Enabled = true;
                    this.Note2SetDiv_tCmbEdit.Enabled = true;
                    this.Note3SetDiv_tCmbEdit.Enabled = true;
                    // --- ADD 2020/02/04 T.Obara ---------- 修正内容一覧No.2 <<<<<
                    this.ConnectUserId_tEdit.Enabled = true;
                    this.ConnectPassword_tEdit.Enabled = true;
                    this.Domain_tEdit.Enabled = true;
                    this.OrderAddress_tEdit.Enabled = true;
                    this.TimeOut_tNedit.Enabled = true;
                    this.RetryCnt_tNedit.Enabled = true;
                    this.CnectFileId_tEdit.Enabled = true;
                    this.tNedit_FrstSendDateYear.Enabled = true;
                    this.tNedit_FrstSendDateMonth.Enabled = true;
                    this.tNedit_FrstSendDateDay.Enabled = true;
                    this.tNedit_LtAtSadDateTimeYear.Enabled = false;
                    this.tNedit_LtAtSadDateTimeMonth.Enabled = false;
                    this.tNedit_LtAtSadDateTimeDay.Enabled = false;
                    this.tNedit_LtAtSadDateTimeHour.Enabled = false;
                    this.tNedit_LtAtSadDateTimeMinute.Enabled = false;
                    this.tNedit_LtAtSadDateTimeSecond.Enabled = false;

                    break;

                // 2:削除
                case 2:

                    // ボタン
                    this.Delete_Button.Visible = true;
                    this.Revive_Button.Visible = true;
                    this.Ok_Button.Visible = false;
                    this.Cancel_Button.Visible = true;

                    // パネル
                    this.tEdit_SectionCode.Enabled = false;
                    this.SectionGuide_Button.Enabled = false;
                    this.tNedit_CustomerCode.Enabled = false;
                    this.CustomerGuide_Button.Enabled = false;
                    this.AutoSendDiv_tCmbEdit.Enabled = false;
                    this.HourSt_tNedit.Enabled = false;
                    this.MinuteSt_tNedit.Enabled = false;
                    this.HourEd_tNedit.Enabled = false;
                    this.MinuteEd_tNedit.Enabled = false;
                    this.tNedit_ExecInterval.Enabled = false;
                    this.CnectSendDiv_tCmbEdit.Enabled = false;
                    this.tNedit_CashRegisterNo.Enabled = false;
                    // --- ADD 2020/02/04 T.Obara ---------- 修正内容一覧No.2 >>>>>
                    this.Note1SetDiv_tCmbEdit.Enabled = false;
                    this.Note2SetDiv_tCmbEdit.Enabled = false;
                    this.Note3SetDiv_tCmbEdit.Enabled = false;
                    // --- ADD 2020/02/04 T.Obara ---------- 修正内容一覧No.2 <<<<<
                    this.ConnectUserId_tEdit.Enabled = false;
                    this.ConnectPassword_tEdit.Enabled = false;
                    this.Domain_tEdit.Enabled = false;
                    this.OrderAddress_tEdit.Enabled = false;
                    this.TimeOut_tNedit.Enabled = false;
                    this.RetryCnt_tNedit.Enabled = false;
                    this.CnectFileId_tEdit.Enabled = false;
                    this.tNedit_FrstSendDateYear.Enabled = false;
                    this.tNedit_FrstSendDateMonth.Enabled = false;
                    this.tNedit_FrstSendDateDay.Enabled = false;
                    this.tNedit_LtAtSadDateTimeYear.Enabled = false;
                    this.tNedit_LtAtSadDateTimeMonth.Enabled = false;
                    this.tNedit_LtAtSadDateTimeDay.Enabled = false;
                    this.tNedit_LtAtSadDateTimeHour.Enabled = false;
                    this.tNedit_LtAtSadDateTimeMinute.Enabled = false;
                    this.tNedit_LtAtSadDateTimeSecond.Enabled = false;
                    break;
            }
        }

        /// <summary>
        /// データセット列情報構築処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : データセットの列情報を構築します。
        ///					 データセットの列情報がフレームのビュー用グリッドの列になります</br>
        /// <br>Programer  : 田建委</br>
        /// <br>Date	   : 2019/12/03</br>
        /// <br>管理番号   : 11570219-00</br>
        /// <br></br>
        /// <br>Update Note : 2020/02/04 小原 卓也</br>
        /// <br>管理番号    : 11570219-00</br>
        /// <br>            : （修正内容一覧No.2）備考設定変更項目追加</br>
        /// </remarks>
        private void DataSetColumnConstruction()
        {
            DataTable connectInfoWorkTable = new DataTable(VIEW_TABLE);

            // Addを行う順番が、列の表示順位となります。
            connectInfoWorkTable.Columns.Add(DELETE_DATE, typeof(string));                 //削除日
            connectInfoWorkTable.Columns.Add(VIEW_SECTIONCD, typeof(string));                //拠点
            connectInfoWorkTable.Columns.Add(VIEW_CUSTOMERCD, typeof(string));               //得意先
            connectInfoWorkTable.Columns.Add(VIEW_AUTOSENDDIV, typeof(string));            //自動送信区分
            connectInfoWorkTable.Columns.Add(VIEW_BOOTTIME, typeof(string));                 //自動送信時間帯（起動）
            connectInfoWorkTable.Columns.Add(VIEW_ENDTIME, typeof(string));                  //自動送信時間帯（終了）
            connectInfoWorkTable.Columns.Add(VIEW_EXECINTERVAL, typeof(string));             //実行間隔
            connectInfoWorkTable.Columns.Add(VIEW_CNECTSENDDIV, typeof(string));           //自動接続送信区分
            connectInfoWorkTable.Columns.Add(CASH_REGISTER_NO, typeof(string));            //端末番号
            connectInfoWorkTable.Columns.Add(VIEW_SENDMACHINENAME, typeof(string));        //送信端末
            connectInfoWorkTable.Columns.Add(VIEW_SENDMACHINEIPADDR, typeof(string));      //端末IPアドレス
            // --- ADD 2020/02/04 T.Obara ---------- 修正内容一覧No.2 >>>>>
            connectInfoWorkTable.Columns.Add(VIEW_NOTE1SETDIV, typeof(string));           //出力設定備考１
            connectInfoWorkTable.Columns.Add(VIEW_NOTE2SETDIV, typeof(string));           //出力設定備考２
            connectInfoWorkTable.Columns.Add(VIEW_NOTE3SETDIV, typeof(string));           //出力設定備考３
            // --- ADD 2020/02/04 T.Obara ---------- 修正内容一覧No.2 <<<<<
            connectInfoWorkTable.Columns.Add(VIEW_CONNECTUSERID, typeof(string));          //ユーザーコード
            connectInfoWorkTable.Columns.Add(VIEW_CONNECTPASSWORD, typeof(string));        //パスワード
            connectInfoWorkTable.Columns.Add(VIEW_DOMAIN, typeof(string));                 //ドメイン
            connectInfoWorkTable.Columns.Add(VIEW_CPRTURL, typeof(string));                 //アドレス
            connectInfoWorkTable.Columns.Add(VIEW_TIMEOUT, typeof(string));                //タイムアウト
            connectInfoWorkTable.Columns.Add(VIEW_RETRYCNT, typeof(string));               //リトライ回数
            connectInfoWorkTable.Columns.Add(VIEW_CNECTFILEID, typeof(string));            //接続ファイルID
            connectInfoWorkTable.Columns.Add(VIEW_FRSTSENDDATE, typeof(string));            //初回送信基準日
            connectInfoWorkTable.Columns.Add(VIEW_LTATSADDATETIME, typeof(string));         //前回自動送信日時
            connectInfoWorkTable.Columns.Add(VIEW_FILEHEADERGUID, typeof(Guid));           //GUID

            this.Bind_DataSet.Tables.Add(connectInfoWorkTable);
        }

        /// <summary>
        /// 画面再構築処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : モードに基づいて画面を再構築します。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2019/12/03</br>
        /// <br>管理番号   : 11570219-00</br>
        /// <br></br>
        /// </remarks>
        private void ScreenReconstruction()
        {
            // 新規の場合
            if (this.DataIndex < 0)
            {
                SalCprtConnectInfoWork connectInfoWork = new SalCprtConnectInfoWork();
                this._connectInfoWorkClone = connectInfoWork.Clone();
                this._indexBuf = this._dataIndex;
                // 画面情報を比較用クローンにコピーします
                ScreenToConnectInfoWork(ref this._connectInfoWorkClone);

                //　新規モード
                this.Mode_Label.Text = INSERT_MODE;
                this.tEdit_SectionCode.Focus();
            }
            else
            {
                Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this._dataIndex][VIEW_FILEHEADERGUID];
                SalCprtConnectInfoWork connectInfoWork = (SalCprtConnectInfoWork)this._connectInfoWorkTable[guid];
                // ワーク再構築処理
                WorkReconstruction(ref connectInfoWork);
                // 画面展開処理
                RecordToScreen(connectInfoWork);

                if (connectInfoWork.LogicalDeleteCode == 0)
                {
                    // 更新モード
                    this.Mode_Label.Text = UPDATE_MODE;

                    // 画面入力許可制御処理
                    ScreenInputPermissionControl(1);

                    // クローン作成
                    this._connectInfoWorkClone = connectInfoWork;

                    this.AutoSendDiv_tCmbEdit.Focus();
                    AutoSendDivtEditValueChanged(connectInfoWork);
                }
                else
                {
                    // 削除状態の時
                    this.Mode_Label.Text = DELETE_MODE;

                    // 画面入力許可制御処理
                    ScreenInputPermissionControl(2);

                    // フォーカス設定
                    this.Delete_Button.Focus();
                }
                
            }
        }

        /// <summary>
        /// ワーク再構築処理
        /// </summary>
        /// <param name="connectInfoWork">接続先情報設定オブジェクト</param>
        /// <remarks>
        /// <br>Note       : ワーク再構築処理</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2019/12/03</br>
        /// <br>管理番号   : 11570219-00</br>
        /// <br></br>
        /// </remarks>
        private void AutoSendDivtEditValueChanged(SalCprtConnectInfoWork connectInfoWork)
        {
            if (this.AutoSendDiv_tCmbEdit.SelectedIndex == 0)
            {
                this.HourSt_tNedit.Enabled = true;
                this.MinuteSt_tNedit.Enabled = true;
                this.HourEd_tNedit.Enabled = true;
                this.MinuteEd_tNedit.Enabled = true;
                this.tNedit_ExecInterval.Enabled = true;
                this.CnectSendDiv_tCmbEdit.Enabled = true;
                this.CnectObjectDiv_tCmbEdit.SelectedIndex = connectInfoWork.CnectObjectDiv;
                if (connectInfoWork.CnectSendDiv == 2)
                {
                    this.CnectSendDiv_tCmbEdit.SelectedIndex = 0;
                }
                else
                {
                    this.CnectSendDiv_tCmbEdit.SelectedIndex = 1;
                }

                this.tNedit_CashRegisterNo.Enabled = true;
            }
            else if (this.AutoSendDiv_tCmbEdit.SelectedIndex == 1)
            {
                // クリア
                this.CnectObjectDiv_tCmbEdit.SelectedIndex = -1;
                this.CnectSendDiv_tCmbEdit.SelectedIndex = -1;

                this.HourSt_tNedit.Enabled = false;
                this.MinuteSt_tNedit.Enabled = false;
                this.HourEd_tNedit.Enabled = false;
                this.MinuteEd_tNedit.Enabled = false;
                this.tNedit_ExecInterval.Enabled = false;
                this.CnectObjectDiv_tCmbEdit.Enabled = false;
                this.CnectSendDiv_tCmbEdit.Enabled = false;
                this.tNedit_CashRegisterNo.Enabled = false;
            }
        }

        /// <summary>
        /// ワーク再構築処理
        /// </summary>
        /// <param name="connectInfoWork">接続先情報設定オブジェクト</param>
        /// <remarks>
        /// <br>Note       : ワーク再構築処理</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2019/12/03</br>
        /// <br>管理番号   : 11570219-00</br>
        /// <br></br>
        /// </remarks>
        private void WorkReconstruction(ref SalCprtConnectInfoWork connectInfoWork)
        {
            connectInfoWork.CnectFileId = connectInfoWork.CnectFileId.Trim();
            connectInfoWork.SendMachineName = connectInfoWork.SendMachineName.Trim();
        }

        /// <summary>
        /// 画面クリア処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : 画面をクリアします。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2019/12/03</br>
        /// <br>管理番号   : 11570219-00</br>
        /// <br></br>
        /// <br>Update Note : 2020/02/04 小原 卓也</br>
        /// <br>管理番号    : 11570219-00</br>
        /// <br>            : （修正内容一覧No.2）備考設定変更項目追加</br>
        /// </remarks>
        private void ScreenClear()
        {
            this.tEdit_SectionCode.Text = string.Empty;
            this.tEdit_SectionName.Text = string.Empty;
            this.tNedit_CustomerCode.Text = string.Empty;
            this.CustomerName_tEdit.Text = string.Empty;
            this.AutoSendDiv_tCmbEdit.SelectedIndex = 0;
            this.CnectObjectDiv_tCmbEdit.SelectedIndex = 1;
            this.CnectSendDiv_tCmbEdit.SelectedIndex = 1;
            this.DaihatsuOrdreDiv_tCmbEdit.SelectedIndex = 1;
            this.HourSt_tNedit.Text = string.Empty;
            this.MinuteSt_tNedit.Text = string.Empty;
            this.HourEd_tNedit.Text = string.Empty;
            this.MinuteEd_tNedit.Text = string.Empty;
            this.tNedit_ExecInterval.Text = string.Empty;
            // --- ADD 2020/02/04 T.Obara ---------- 修正内容一覧No.2 >>>>>
            this.Note1SetDiv_tCmbEdit.SelectedIndex = 0;
            this.Note2SetDiv_tCmbEdit.SelectedIndex = 0;
            this.Note3SetDiv_tCmbEdit.SelectedIndex = 0;
            // --- ADD 2020/02/04 T.Obara ---------- 修正内容一覧No.2 <<<<<
            this.ConnectUserId_tEdit.Text = string.Empty;
            this.ConnectPassword_tEdit.Text = string.Empty;
            this.Domain_tEdit.Text = string.Empty;
            this.OrderAddress_tEdit.Text = string.Empty;
            this.TimeOut_tNedit.Text = string.Empty;
            this.RetryCnt_tNedit.Text = string.Empty;
            this.CnectFileId_tEdit.Text = string.Empty;
            this.tNedit_CashRegisterNo.Text = string.Empty;
            this.SendMachineName_tEdit.Text = string.Empty;
            this.tNedit_IPNO1.Text = string.Empty;
            this.tNedit_IPNO2.Text = string.Empty;
            this.tNedit_IPNO3.Text = string.Empty;
            this.tNedit_IPNO4.Text = string.Empty;

            //初回送信基準日
            String dateStr = DateTime.Now.ToString("yyyyMMddHHmmss");
            this.tNedit_FrstSendDateYear.Text = dateStr.Substring(0, 4);
            this.tNedit_FrstSendDateMonth.Text = dateStr.Substring(4, 2);
            this.tNedit_FrstSendDateDay.Text = dateStr.Substring(6, 2);

            this.tNedit_LtAtSadDateTimeYear.Text = string.Empty;
            this.tNedit_LtAtSadDateTimeMonth.Text = string.Empty;
            this.tNedit_LtAtSadDateTimeDay.Text = string.Empty;
            this.tNedit_LtAtSadDateTimeHour.Text = string.Empty;
            this.tNedit_LtAtSadDateTimeMinute.Text = string.Empty;
            this.tNedit_LtAtSadDateTimeSecond.Text = string.Empty;

            // ボタン
            this.Ok_Button.Visible = true;
            this.Cancel_Button.Visible = true;
            this.Revive_Button.Visible = false;
            this.Delete_Button.Visible = false;

            // パネル
            this.tEdit_SectionCode.Enabled = true;
            this.SectionGuide_Button.Enabled = true;
            this.tNedit_CustomerCode.Enabled = true;
            this.CustomerGuide_Button.Enabled = true;
            this.AutoSendDiv_tCmbEdit.Enabled = true;
            this.HourSt_tNedit.Enabled = true;
            this.MinuteSt_tNedit.Enabled = true;
            this.HourEd_tNedit.Enabled = true;
            this.MinuteEd_tNedit.Enabled = true;
            this.tNedit_ExecInterval.Enabled = true;
            this.CnectSendDiv_tCmbEdit.Enabled = true;
            this.tNedit_CashRegisterNo.Enabled = true;
            // --- ADD 2020/02/04 T.Obara ---------- 修正内容一覧No.2 >>>>>
            this.Note1SetDiv_tCmbEdit.Enabled = true;
            this.Note2SetDiv_tCmbEdit.Enabled = true;
            this.Note3SetDiv_tCmbEdit.Enabled = true;
            // --- ADD 2020/02/04 T.Obara ---------- 修正内容一覧No.2 <<<<<
            this.ConnectUserId_tEdit.Enabled = true;
            this.ConnectPassword_tEdit.Enabled = true;
            this.Domain_tEdit.Enabled = true;
            this.OrderAddress_tEdit.Enabled = true;
            this.TimeOut_tNedit.Enabled = true;
            this.RetryCnt_tNedit.Enabled = true;
            this.CnectFileId_tEdit.Enabled = true;
            this.tNedit_FrstSendDateYear.Enabled = true;
            this.tNedit_FrstSendDateMonth.Enabled = true;
            this.tNedit_FrstSendDateDay.Enabled = true;
            this.tNedit_LtAtSadDateTimeYear.Enabled = false;
            this.tNedit_LtAtSadDateTimeMonth.Enabled = false;
            this.tNedit_LtAtSadDateTimeDay.Enabled = false;
            this.tNedit_LtAtSadDateTimeHour.Enabled = false;
            this.tNedit_LtAtSadDateTimeMinute.Enabled = false;
            this.tNedit_LtAtSadDateTimeSecond.Enabled = false;
        }

        /// <summary>
        /// 接続先情報設定マスタ画面展開処理
        /// </summary>
        /// <param name="connectInfoWork">接続先情報設定オブジェクト</param>
        /// <remarks>
        /// <br>Note       : オブジェクトから画面にデータを展開します。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2019/12/03</br>
        /// <br>管理番号   : 11570219-00</br>
        /// <br></br>
        /// <br>Update Note : 2020/02/04 小原 卓也</br>
        /// <br>管理番号    : 11570219-00</br>
        /// <br>            : （修正内容一覧No.2）備考設定変更項目追加</br>
        /// </remarks>
        private void RecordToScreen(SalCprtConnectInfoWork connectInfoWork)
        {
            //拠点
            if (connectInfoWork.SectionCode == "0")
            {
                this.tEdit_SectionCode.Text = string.Empty;
                this.tEdit_SectionName.Text = string.Empty;
            }
            else
            {
                this.tEdit_SectionCode.Text = connectInfoWork.SectionCode.PadLeft(2, '0');
                this.tEdit_SectionName.Text = GetSectionName(connectInfoWork.SectionCode);
            }

            //得意先
            if (connectInfoWork.CustomerCode == 0)
            {
                this.tNedit_CustomerCode.Text = string.Empty;
                this.CustomerName_tEdit.Text = string.Empty;
            }
            else
            {
                this.tNedit_CustomerCode.Text = connectInfoWork.CustomerCode.ToString().PadLeft(8, '0');
                this.CustomerName_tEdit.Text = GetCustomerName(connectInfoWork.CustomerCode);
            }

            //自動送信区分
            this.AutoSendDiv_tCmbEdit.SelectedIndex = connectInfoWork.AutoSendDiv;

            //自動送信時間帯（起動）
            if (connectInfoWork.BootTime != 0)
            {
                this.HourSt_tNedit.Text = connectInfoWork.BootTime.ToString().PadLeft(4, '0').Substring(0, 2);
                this.MinuteSt_tNedit.Text = connectInfoWork.BootTime.ToString().PadLeft(4, '0').Substring(2, 2); ;
            }
            else
            {
                if (connectInfoWork.AutoSendDiv == 1)
                {
                    this.HourSt_tNedit.Text = string.Empty;
                    this.MinuteSt_tNedit.Text = string.Empty;
                }
                else
                {
                    this.HourSt_tNedit.Text = "00";
                    this.MinuteSt_tNedit.Text = "00";
                }
            }
            //自動送信時間帯（終了）
            if (connectInfoWork.EndTime != 0)
            {
                this.HourEd_tNedit.Text = connectInfoWork.EndTime.ToString().PadLeft(4, '0').Substring(0, 2);
                this.MinuteEd_tNedit.Text = connectInfoWork.EndTime.ToString().PadLeft(4, '0').Substring(2, 2); ;
            }
            else
            {
                if (connectInfoWork.AutoSendDiv == 1)
                {
                    this.HourEd_tNedit.Text = string.Empty;
                    this.MinuteEd_tNedit.Text = string.Empty;
                }
                else
                {
                    this.HourEd_tNedit.Text = "00";
                    this.MinuteEd_tNedit.Text = "00";
                }
            }
            //実行間隔
            if (connectInfoWork.ExecInterval != 0)
            {
                this.tNedit_ExecInterval.Text = connectInfoWork.ExecInterval.ToString();
            }
            //自動接続送信区分
            if (connectInfoWork.CnectSendDiv == 2)
            {
                this.CnectSendDiv_tCmbEdit.SelectedIndex = 0;
            }
            else
            {
                this.CnectSendDiv_tCmbEdit.SelectedIndex = 1;
            }
            //自動送信起動端末
            this.tNedit_CashRegisterNo.SetInt(connectInfoWork.CashregiSterno);
            // 端末名
            this.SendMachineName_tEdit.Text = connectInfoWork.SendMachineName;          
            // 端末IPアドレス
            if (!string.IsNullOrEmpty(connectInfoWork.SendMachineIpAddr))
            {
                string[] ipAddr = connectInfoWork.SendMachineIpAddr.ToString().Trim().Split('.');
                this.tNedit_IPNO1.Text = ipAddr[0];
                this.tNedit_IPNO2.Text = ipAddr[1];
                this.tNedit_IPNO3.Text = ipAddr[2];
                this.tNedit_IPNO4.Text = ipAddr[3];
            }
            // --- ADD 2020/02/04 T.Obara ---------- 修正内容一覧No.2 >>>>>
            //出力設定備考１
            this.Note1SetDiv_tCmbEdit.Text = connectInfoWork.Note1SetDiv.ToString().Trim();
            //出力設定備考２
            this.Note2SetDiv_tCmbEdit.Text = connectInfoWork.Note2SetDiv.ToString().Trim();
            //出力設定備考３
            this.Note3SetDiv_tCmbEdit.Text = connectInfoWork.Note3SetDiv.ToString().Trim();
            // --- ADD 2020/02/04 T.Obara ---------- 修正内容一覧No.2 <<<<<
            //ユーザーコード
            this.ConnectUserId_tEdit.Text = connectInfoWork.SendCcnctUserid.ToString().Trim();
            //パスワード
            this.ConnectPassword_tEdit.Text = connectInfoWork.SendCcnctPass.ToString().Trim();
            //ドメイン
            this.Domain_tEdit.Text = connectInfoWork.CprtDomain;
            //アドレス
            this.OrderAddress_tEdit.Text = connectInfoWork.CprtUrl;
            //タイムアウト
            this.TimeOut_tNedit.Text = connectInfoWork.LoginTimeoutVal.ToString();
            //リトライ回数
            this.RetryCnt_tNedit.Text = connectInfoWork.RetryCnt.ToString();
            //接続ファイルID
            this.CnectFileId_tEdit.Text = connectInfoWork.CnectFileId;
            //初回送信基準日
            if (connectInfoWork.FrstSendDate== 0)
            {
                this.tNedit_FrstSendDateYear.Text = string.Empty;
                this.tNedit_FrstSendDateMonth.Text = string.Empty;
                this.tNedit_FrstSendDateDay.Text = string.Empty;

            }
            else
            {
                this.tNedit_FrstSendDateYear.Text = connectInfoWork.FrstSendDate.ToString().PadLeft(6, '0').Substring(0, 4);
                this.tNedit_FrstSendDateMonth.Text = connectInfoWork.FrstSendDate.ToString().PadLeft(6, '0').Substring(4, 2);
                this.tNedit_FrstSendDateDay.Text = connectInfoWork.FrstSendDate.ToString().PadLeft(6, '0').Substring(6, 2);
 
            }
            //前回自動送信日時
            if (connectInfoWork.LtAtSadDateTime == DateTime.MinValue)
            {
                this.tNedit_LtAtSadDateTimeYear.Text = string.Empty;
                this.tNedit_LtAtSadDateTimeMonth.Text = string.Empty;
                this.tNedit_LtAtSadDateTimeDay.Text = string.Empty;
                this.tNedit_LtAtSadDateTimeHour.Text = string.Empty;
                this.tNedit_LtAtSadDateTimeMinute.Text = string.Empty;
                this.tNedit_LtAtSadDateTimeSecond.Text = string.Empty;
            }
            else
            {
                List<string> dateList = this.GetLtAtSadDateTimeList(connectInfoWork.LtAtSadDateTime);

                this.tNedit_LtAtSadDateTimeYear.Text = dateList[0];
                this.tNedit_LtAtSadDateTimeMonth.Text = dateList[1];
                this.tNedit_LtAtSadDateTimeDay.Text = dateList[2];
                this.tNedit_LtAtSadDateTimeHour.Text = dateList[3];
                this.tNedit_LtAtSadDateTimeMinute.Text = dateList[4];
                this.tNedit_LtAtSadDateTimeSecond.Text = dateList[5];
 
            }
        }

        /// <summary>
        /// 前回自動送信日時のConvert処理(ToArrayList)
        /// </summary>
        /// <param name="ltAtSadDateTime">前回自動送信日時</param>
        /// <remarks>
        /// <br>Note        : 前回自動送信日時のConvert処理を行う。</br>
        /// <br>Programmer  : 田建委</br>
        /// <br>Date        : 2019/12/03</br>
        /// </remarks>
        private List<string> GetLtAtSadDateTimeList(DateTime ltAtSadDateTime)
        {
            List<string> ltAtSadDateTimList = new List<string>();

            String dateStr = ltAtSadDateTime.ToString("yyyyMMddHHmmss");
            ltAtSadDateTimList.Add(dateStr.Substring(0, 4));
            ltAtSadDateTimList.Add(dateStr.Substring(4, 2));
            ltAtSadDateTimList.Add(dateStr.Substring(6, 2));
            ltAtSadDateTimList.Add(dateStr.Substring(8, 2));
            ltAtSadDateTimList.Add(dateStr.Substring(10, 2));
            ltAtSadDateTimList.Add(dateStr.Substring(12, 2));

            return ltAtSadDateTimList;
        }

        /// <summary>
        /// 保存処理(SaveSalCprtConnectInfoWork())
        /// </summary>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note　　　  : 保存処理を行います。</br>
        /// <br>Programmer  : 田建委</br>
        /// <br>Date        : 2019/12/03</br>
        /// <br>管理番号    : 11570219-00</br>
        /// </remarks>
        private bool SaveSalCprtConnectInfoWork()
        {
            bool result = false;

            if (this.tNedit_CashRegisterNo.Focused)
            {
                ChangeFocusEventArgs eArgs = new ChangeFocusEventArgs(false, false, false, Keys.Enter, this.tNedit_CashRegisterNo, this.tNedit_CashRegisterNo);
                this.tRetKeyControl1_ChangeFocus(this, eArgs);
                if (this._isError)
                {
                    this._isError = false;
                    return result;
                }
            }

            //画面データ入力チェック処理
            bool chkSt = ScreenDataCheck();
            if (!chkSt)
            {
                return chkSt;
            }

            SalCprtConnectInfoWork connectInfoWork = null;
            SalCprtConnectInfoWork connectInfoWorkPre = new SalCprtConnectInfoWork();

            if (this.DataIndex >= 0)
            {
                Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this._dataIndex][VIEW_FILEHEADERGUID];
                connectInfoWork = (SalCprtConnectInfoWork)this._connectInfoWorkTable[guid];
                connectInfoWorkPre = connectInfoWork.Clone();
            }

            // 画面にデータを取得
            ScreenToConnectInfoWork(ref connectInfoWork);


            // 起動時間、終了時間、実行間隔が変更するか
            int flag = 0;
            if (!((connectInfoWorkPre.BootTime == connectInfoWork.BootTime)
               && (connectInfoWorkPre.EndTime == connectInfoWork.EndTime)
               && (connectInfoWorkPre.ExecInterval == connectInfoWork.ExecInterval)))
            {
                flag = 1;
            }

            // 保存処理
            int status = this._connectInfoWorkAcs.Write(ref connectInfoWork, flag);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        this.ScreenClear();
                        this.Close();
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE:
                    {
                        TMsgDisp.Show(
                            this, 								       // 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,        // エラーレベル
                            ASSEMBLY_ID,						       // アセンブリＩＤまたはクラスＩＤ
                            "このコードは既に使用されています。",// 表示するメッセージ
                            0, 									       // ステータス値
                            MessageBoxButtons.OK);				       // 表示するボタン
                        this.AutoSendDiv_tCmbEdit.Focus();
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
                            ASSEMBLY_ID,							// アセンブリID
                            "PrcPrSt",  　　                        // プログラム名称
                            "SalCprtConnectInfoWork",               // 処理名称
                            TMsgDisp.OPE_UPDATE,                    // オペレーション
                            "登録に失敗しました。",				    // 表示するメッセージ
                            status,									// ステータス値
                            this._connectInfoWorkAcs,				    	// エラーが発生したオブジェクト
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

            // 画面データ更新

            int totalCount = 0;
            if (flag == 1)
            {
                Search(ref totalCount, 0);
            }
            else
            {
                ConnectInfoWorkToDataSet(connectInfoWork, this.DataIndex);
            }

            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }
            this.DialogResult = DialogResult.OK;
            this._indexBuf = -2;

            // 新規登録時がないの場合
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
            // 新規登録時
            if (this.Mode_Label.Text.Equals(INSERT_MODE))
            {
                this.ScreenClear();
            }
            result = true;
            return result;
        }

        /// <summary>
        /// 画面入力情報不正時のエラー処理
        /// </summary>
        /// <returns>チェック結果（true:OK／false:NG）</returns>
        /// <remarks>
        /// <br>Note　　　  : 画面入力情報不正時のエラー処理を行います。</br>
        /// <br>Programmer  : 田建委</br>
        /// <br>Date        : 2019/12/03</br>
        /// <br>管理番号    : 11570219-00</br>
        /// </remarks>
        private bool ScreenDataCheck()
        {
            Control control = null;
            string message = null;

            // 不正データ入力チェック
            if (!ScreenDataCheck(ref control, ref message))
            {
                if (!string.IsNullOrEmpty(message))
                {
                    TMsgDisp.Show(
                        this, 								// 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
                        ASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
                        message, 							// 表示するメッセージ
                        0, 									// ステータス値
                        MessageBoxButtons.OK);				// 表示するボタン
                    TimeOut_tNedit.Leave -= new EventHandler(TimeOut_tNedit_Leave);
                    RetryCnt_tNedit.Leave -= new EventHandler(RetryCnt_tNedit_Leave);
                    HourSt_tNedit.Leave -= new EventHandler(Hour_tNedit_Leave);
                    MinuteSt_tNedit.Leave -= new EventHandler(Minute_tNedit_Leave);
                    HourEd_tNedit.Leave -= new EventHandler(HourEd_tNedit_Leave);
                    MinuteEd_tNedit.Leave -= new EventHandler(MinuteEd_tNedit_Leave);
                    tNedit_FrstSendDateYear.Leave -= new EventHandler(tNedit_FrstSendDateYear_Leave);
                    tNedit_FrstSendDateMonth.Leave -= new EventHandler(tNedit_FrstSendDateMonth_Leave);
                    tNedit_FrstSendDateDay.Leave -= new EventHandler(tNedit_FrstSendDateDay_Leave);
                    control.Focus();
                    TimeOut_tNedit.Leave += new EventHandler(TimeOut_tNedit_Leave);
                    RetryCnt_tNedit.Leave += new EventHandler(RetryCnt_tNedit_Leave);
                    HourSt_tNedit.Leave += new EventHandler(Hour_tNedit_Leave);
                    MinuteSt_tNedit.Leave += new EventHandler(Minute_tNedit_Leave);
                    HourEd_tNedit.Leave += new EventHandler(HourEd_tNedit_Leave);
                    MinuteEd_tNedit.Leave += new EventHandler(MinuteEd_tNedit_Leave);
                    tNedit_FrstSendDateYear.Leave += new EventHandler(tNedit_FrstSendDateYear_Leave);
                    tNedit_FrstSendDateMonth.Leave += new EventHandler(tNedit_FrstSendDateMonth_Leave);
                    tNedit_FrstSendDateDay.Leave += new EventHandler(tNedit_FrstSendDateDay_Leave);

                }
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// 画面入力情報不正チェック処理
        /// </summary>
        /// <param name="control">不正対象コントロール</param>
        /// <param name="message">メッセージ</param>
        /// <returns>チェック結果（true:OK／false:NG）</returns>
        /// <remarks>
        /// <br>Note	　 : 画面入力情報の不正チェックを行います。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2019/12/03</br>
        /// <br>管理番号   : 11570219-00</br>
        /// <br></br>
        /// </remarks>
        private bool ScreenDataCheck(ref Control control, ref string message)
        {
            // 
            if (string.IsNullOrEmpty(this.tEdit_SectionCode.Text.Trim()) && string.IsNullOrEmpty(this.tNedit_CustomerCode.Text.Trim()))
            {
                control = this.tEdit_SectionCode;
                message = "拠点、得意先のいずれかを入力してください。";
                return (false);
            }

            if (this.AutoSendDiv_tCmbEdit.SelectedIndex == 0)
            {
                // 自動送信時間帯（起動） 時
                if (string.IsNullOrEmpty(this.HourSt_tNedit.Text.Trim()))
                {
                    control = this.HourSt_tNedit;
                    message = "自動送信時間帯を入力して下さい。";
                    return (false);
                }

                if (int.Parse(this.HourSt_tNedit.Text) < 0 || int.Parse(this.HourSt_tNedit.Text) > 23)
                {
                    control = this.HourSt_tNedit;
                    message = "時刻を入力してください。";
                    return (false);
                }

                // 自動送信時間帯（起動） 分
                if (string.IsNullOrEmpty(this.MinuteSt_tNedit.Text.Trim()))
                {
                    control = this.MinuteSt_tNedit;
                    message = "自動送信時間帯を入力して下さい。";
                    return (false);
                }

                if (int.Parse(this.MinuteSt_tNedit.Text) < 0 || int.Parse(this.MinuteSt_tNedit.Text) > 59)
                {
                    control = this.MinuteSt_tNedit;
                    message = "時刻を入力してください。";
                    return (false);
                }
                // 自動送信時間帯（終了） 時
                if (string.IsNullOrEmpty(this.HourEd_tNedit.Text.Trim()))
                {
                    control = this.HourEd_tNedit;
                    message = "自動送信時間帯を入力して下さい。";
                    return (false);
                }

                if (int.Parse(this.HourEd_tNedit.Text) < 0 || int.Parse(this.HourEd_tNedit.Text) > 23)
                {
                    control = this.HourEd_tNedit;
                    message = "時刻を入力してください。";
                    return (false);
                }

                // 自動送信時間帯（終了） 分
                if (string.IsNullOrEmpty(this.MinuteEd_tNedit.Text.Trim()))
                {
                    control = this.MinuteEd_tNedit;
                    message = "自動送信時間帯を入力して下さい。";
                    return (false);
                }

                if (int.Parse(this.MinuteEd_tNedit.Text) < 0 || int.Parse(this.MinuteEd_tNedit.Text) > 59)
                {
                    control = this.MinuteEd_tNedit;
                    message = "時刻を入力してください。";
                    return (false);
                }

                // 自動送信時間帯（起動） > 自動送信時間帯（終了）の場合、エラーとする
                if (this.HourSt_tNedit.GetInt() > this.HourEd_tNedit.GetInt())
                {
                    control = this.HourSt_tNedit;
                    message = "開始時間以降の時間を入力してください。";
                    return (false);
                }

                if ((this.HourSt_tNedit.GetInt() == this.HourEd_tNedit.GetInt()) &&
                    (this.MinuteSt_tNedit.GetInt() > this.MinuteEd_tNedit.GetInt()))
                {
                    control = this.MinuteSt_tNedit;
                    message = "開始時間以降の時間を入力してください。";
                    return (false);
                }

                // 実行間隔
                if (string.IsNullOrEmpty(this.tNedit_ExecInterval.Text.Trim()))
                {
                    control = this.tNedit_ExecInterval;
                    message = "実行間隔を設定して下さい。";
                    return (false);
                }

                if (int.Parse(this.tNedit_ExecInterval.Text) < 15)
                {
                    control = this.tNedit_ExecInterval;
                    message = "15分以上を入力してください。";
                    return (false);
                }


                // 端末番号マスタチェック
                if (this.tNedit_CashRegisterNo.GetInt() == 0)
                {
                    control = this.tNedit_CashRegisterNo;
                    message = "自動送信起動端末を設定して下さい。";
                    return false;
                }
            }

            // ユーザーコード
            if (string.IsNullOrEmpty(this.ConnectUserId_tEdit.Text.Trim()))
            {
                control = this.ConnectUserId_tEdit;
                message = "ユーザーコードを入力してください。";
                return (false);
            }

            // パスワード
            if (string.IsNullOrEmpty(this.ConnectPassword_tEdit.Text.Trim()))
            {
                control = this.ConnectPassword_tEdit;
                message = "パスワードを入力してください。";
                return (false);
            }

            // 発注用アドレス
            if (string.IsNullOrEmpty(this.OrderAddress_tEdit.Text.Trim()))
            {
                control = this.OrderAddress_tEdit;
                message = "発注用アドレスを入力してください。";
                return (false);
            }

            // タイムアウト
            if (string.IsNullOrEmpty(this.TimeOut_tNedit.Text.Trim()))
            {
                control = this.TimeOut_tNedit;
                message = "タイムアウトを入力してください。";
                return (false);
            }

            if (int.Parse(this.TimeOut_tNedit.Text) < 0 || int.Parse(this.TimeOut_tNedit.Text) > 3600)
            {
                control = this.TimeOut_tNedit;
                message = "3600秒以下を入力してください。";
                return (false);
            }
            this.TimeOut_tNedit.Text = int.Parse(this.TimeOut_tNedit.Text).ToString();

            // リトライ回数
            if (string.IsNullOrEmpty(this.RetryCnt_tNedit.Text.Trim()))
            {
                control = this.RetryCnt_tNedit;
                message = "リトライ回数を入力してください。";
                return (false);
            }


            if (int.Parse(this.RetryCnt_tNedit.Text) < 0 || int.Parse(this.RetryCnt_tNedit.Text) > 5)
            {
                control = this.RetryCnt_tNedit;
                message = "5回以下を入力してください。";
                return (false);
            }

            // 接続ファイルID
            if (string.IsNullOrEmpty(this.CnectFileId_tEdit.Text.Trim()))
            {
                control = this.CnectFileId_tEdit;
                message = "接続ファイルIDを入力してください。";
                return (false);
            }

            // 初回送信基準日
            if (this.tNedit_FrstSendDateYear.DataText.Trim() == string.Empty
                || this.tNedit_FrstSendDateMonth.DataText.Trim() == string.Empty
                || this.tNedit_FrstSendDateDay.DataText.Trim() == string.Empty)
            {
                control = this.tNedit_FrstSendDateYear;
                message = "初回送信基準日を設定して下さい。";
                return (false);
            }

            int frstSendDate = GetFrstSendDate();
            if (frstSendDate != 0)
            {
                try
                {
                    DateTime dt = DateTime.ParseExact(frstSendDate.ToString(), "yyyyMMdd", System.Globalization.CultureInfo.CurrentCulture);
                }
                catch
                {
                    control = this.tNedit_FrstSendDateYear;
                    message = "日付を入力してください。";
                    return (false);
                }
            }

            return true;
        }

        /// <summary>
        /// 接続先情報設定クラス格納処理
        /// </summary>
        /// <param name="connectInfoWork">接続先情報設定オブジェクト</param>
        /// <remarks>
        /// <br>Note       : 画面情報から接続先情報設定オブジェクトにデータを格納します。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2019/12/03</br>
        /// <br>管理番号   : 11570219-00</br>
        /// <br></br>
        /// <br>Update Note : 2020/02/04 小原 卓也</br>
        /// <br>管理番号    : 11570219-00</br>
        /// <br>            : （修正内容一覧No.2）備考設定変更項目追加</br>
        /// </remarks>
        private void ScreenToConnectInfoWork(ref SalCprtConnectInfoWork connectInfoWork)
        {
            if (connectInfoWork == null)
            {
                connectInfoWork = new SalCprtConnectInfoWork();
            }
            // 企業コード
            connectInfoWork.EnterpriseCode = this._enterpriseCode;
            // 仕入先コード    
            connectInfoWork.SupplierCd = SUPPLIERCODE;
            // 拠点
            if (tEdit_SectionCode.Text.Trim().Equals(""))
            {
                connectInfoWork.SectionCode = "0";
            }
            else
            {
                connectInfoWork.SectionCode = tEdit_SectionCode.Text.Trim().PadLeft(2, '0');
            }
            
            // 得意先
            connectInfoWork.CustomerCode = tNedit_CustomerCode.GetInt();
            //自動送信区分
            connectInfoWork.AutoSendDiv = AutoSendDiv_tCmbEdit.SelectedIndex;
            if (this.AutoSendDiv_tCmbEdit.SelectedIndex == 1)
            {
                // 自動送信対象
                connectInfoWork.CnectObjectDiv = -1;
                // 自動接続送信区分
                connectInfoWork.CnectSendDiv = -1;
            }
            else
            {
                // 自動送信対象
                connectInfoWork.CnectObjectDiv = this.CnectObjectDiv_tCmbEdit.SelectedIndex;
                // 自動接続送信区分
                if (this.CnectSendDiv_tCmbEdit.SelectedIndex == 0)
                {
                    // DBに、2：すべて
                    connectInfoWork.CnectSendDiv = 2;
                }
                else
                {
                    // DBに、0：未送信
                    connectInfoWork.CnectSendDiv = 0;
                }
            }

            // 自動送信時間帯（起動）
            if (!string.IsNullOrEmpty(this.HourSt_tNedit.Text) && !string.IsNullOrEmpty(this.MinuteSt_tNedit.Text))
            {
                connectInfoWork.BootTime = int.Parse(this.HourSt_tNedit.Text + this.MinuteSt_tNedit.Text);
            }
            // 自動送信時間帯（終了）
            if (!string.IsNullOrEmpty(this.HourEd_tNedit.Text) && !string.IsNullOrEmpty(this.MinuteEd_tNedit.Text))
            {
                connectInfoWork.EndTime = int.Parse(this.HourEd_tNedit.Text + this.MinuteEd_tNedit.Text);
            }
            //実行間隔
            connectInfoWork.ExecInterval = tNedit_ExecInterval.GetInt();
            // 端末番号
            connectInfoWork.CashregiSterno = this.tNedit_CashRegisterNo.GetInt();
            // 送信端末
            connectInfoWork.SendMachineName = this.SendMachineName_tEdit.Text.Trim();
            // 接続プログラムタイプ「1:S&E」固定でセット
            connectInfoWork.CnectProgramType = 1;
            // 初回送信基準日
            connectInfoWork.FrstSendDate = this.GetFrstSendDate();
            // 前回自動送信日時
            connectInfoWork.LtAtSadDateTime = this.GetLtAtSadDateTime();
            // 自動送信区分
            connectInfoWork.AutoSendDiv = this.AutoSendDiv_tCmbEdit.SelectedIndex;
            // --- ADD 2020/02/04 T.Obara ---------- 修正内容一覧No.2 >>>>>
            // 出力設定備考１
            connectInfoWork.Note1SetDiv = this.Note1SetDiv_tCmbEdit.SelectedIndex;
            // 出力設定備考２
            connectInfoWork.Note2SetDiv = this.Note2SetDiv_tCmbEdit.SelectedIndex;
            // 出力設定備考３
            connectInfoWork.Note3SetDiv = this.Note3SetDiv_tCmbEdit.SelectedIndex;
            // --- ADD 2020/02/04 T.Obara ---------- 修正内容一覧No.2 <<<<<
            // ユーザーコード
            connectInfoWork.SendCcnctUserid = this.ConnectUserId_tEdit.Text;
            // パスワード
            connectInfoWork.SendCcnctPass = this.ConnectPassword_tEdit.Text;
            // プロトコル
            connectInfoWork.Protocol = this.DaihatsuOrdreDiv_tCmbEdit.SelectedIndex;
            // ドメイン
            connectInfoWork.CprtDomain = this.Domain_tEdit.Text;
            // 発注用アドレス
            connectInfoWork.CprtUrl = this.OrderAddress_tEdit.Text;
            // 接続ファイルID
            connectInfoWork.CnectFileId = this.CnectFileId_tEdit.Text.Trim();
            // タイムアウト
            if (!string.IsNullOrEmpty(this.TimeOut_tNedit.Text))
            {
                connectInfoWork.LoginTimeoutVal = int.Parse(this.TimeOut_tNedit.Text);
            }
            // リトライ回数
            if (!string.IsNullOrEmpty(this.RetryCnt_tNedit.Text))
            {
                connectInfoWork.RetryCnt = int.Parse(this.RetryCnt_tNedit.Text); 
            }
            string ipst1 = this.tNedit_IPNO1.Text;
            string ipst2 = this.tNedit_IPNO2.Text;
            string ipst3 = this.tNedit_IPNO3.Text;
            string ipst4 = this.tNedit_IPNO4.Text;
            if (string.IsNullOrEmpty(ipst1) && string.IsNullOrEmpty(ipst2) && string.IsNullOrEmpty(ipst3) && string.IsNullOrEmpty(ipst4))
            {
                connectInfoWork.SendMachineIpAddr = string.Empty;
            }
            else
            {
                connectInfoWork.SendMachineIpAddr = this.tNedit_IPNO1.GetInt().ToString().Trim() + "." + this.tNedit_IPNO2.GetInt().ToString().Trim() + "." + this.tNedit_IPNO3.GetInt().ToString().Trim() + "." + this.tNedit_IPNO4.GetInt().ToString().Trim();
            }
        }

        /// <summary>
        /// 初回送信基準日のconver処理(ToDateTime)
        /// </summary>
        /// <remarks>
        /// <br>Note　　　  : 初回送信基準日のconver処理を行います。</br>
        /// <br>Programmer  : 田建委</br>
        /// <br>Date        : 2019/12/03</br>
        /// </remarks>
        private int GetFrstSendDate()
        {
            StringBuilder frstSendDateBuf = new StringBuilder();
            int frstSendDateInt = 0;
            frstSendDateBuf.Append(this.tNedit_FrstSendDateYear.Value);
            frstSendDateBuf.Append(this.tNedit_FrstSendDateMonth.Value);
            frstSendDateBuf.Append(this.tNedit_FrstSendDateDay.Value);
            if (!string.IsNullOrEmpty(frstSendDateBuf.ToString()))
            {
                frstSendDateInt = Convert.ToInt32(frstSendDateBuf.ToString());
            }

            return frstSendDateInt;
        }

        /// <summary>
        /// 前回自動送信日時のconver処理(ToDateTime)
        /// </summary>
        /// <remarks>
        /// <br>Note　　　  : 前回自動送信日時のconver処理を行います。</br>
        /// <br>Programmer  : 田建委</br>
        /// <br>Date        : 2019/12/03</br>
        /// </remarks>
        private DateTime GetLtAtSadDateTime()
        {
            StringBuilder syncExecDateBuf = new StringBuilder();
            syncExecDateBuf.Append(this.tNedit_LtAtSadDateTimeYear.Value);
            syncExecDateBuf.Append(this.tNedit_LtAtSadDateTimeMonth.Value);
            syncExecDateBuf.Append(this.tNedit_LtAtSadDateTimeDay.Value);
            syncExecDateBuf.Append(this.tNedit_LtAtSadDateTimeHour.Value);
            syncExecDateBuf.Append(this.tNedit_LtAtSadDateTimeMinute.Value);
            syncExecDateBuf.Append(this.tNedit_LtAtSadDateTimeSecond.Value);

            DateTime syncExecDate = new DateTime();
            try
            {
                syncExecDate = string.IsNullOrEmpty(syncExecDateBuf.ToString())
                    ? DateTime.MinValue
                    : new DateTime(
                    this.tNedit_LtAtSadDateTimeYear.GetInt(),
                    this.tNedit_LtAtSadDateTimeMonth.GetInt(),
                    this.tNedit_LtAtSadDateTimeDay.GetInt(),
                    Convert.ToInt32(this.tNedit_LtAtSadDateTimeHour.DataText),
                    Convert.ToInt32(this.tNedit_LtAtSadDateTimeMinute.DataText),
                    Convert.ToInt32(this.tNedit_LtAtSadDateTimeSecond.DataText),
                    0);
            }
            catch
            {
                syncExecDate = DateTime.MinValue;
            }

            return syncExecDate;
            
        }

        /// <summary>
        /// FormClose イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : FormClose イベント</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2019/12/03</br>
        /// <br>管理番号   : 11570219-00</br>
        /// <br></br>
        /// </remarks>
        private void PMSDC09010UA_FormClosing(object sender, FormClosingEventArgs e)
        {
            this._indexBuf = -2;

            if (CanClose == false)
            {
                e.Cancel = true;
                this.Hide();
            }
        }

        /// <summary>
        /// ChangeFocus イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : ChangeFocus イベント</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2019/12/03</br>
        /// <br>管理番号   : 11570219-00</br>
        /// <br></br>
        /// </remarks>
        private void tRetKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            this._isError = false;
            if (e.PrevCtrl == null)
            {
                return;
            }

            switch (e.PrevCtrl.Name)
            {
                case "tNedit_CashRegisterNo":
                    {
                        if (tNedit_CashRegisterNo.GetInt() == 0)
                        {
                            tNedit_CashRegisterNo.Clear();
                            SendMachineName_tEdit.Clear();
                            this.tNedit_IPNO1.Clear();
                            this.tNedit_IPNO2.Clear();
                            this.tNedit_IPNO3.Clear();
                            this.tNedit_IPNO4.Clear();
                            return;
                        }

                        // 端末管理設定マスタから名称を取得
                        PosTerminalMg posTerminalMg = GetPosTerminalMg(tNedit_CashRegisterNo.GetInt());
                        if ((posTerminalMg != null) &&
                            (posTerminalMg.LogicalDeleteCode == 0))
                        {
                            SendMachineName_tEdit.Text = posTerminalMg.MachineName;
                            if (!string.IsNullOrEmpty(posTerminalMg.MachineIpAddr))
                            {
                                string[] ipAddr = posTerminalMg.MachineIpAddr.Trim().Split('.');
                                this.tNedit_IPNO1.Text = ipAddr[0];
                                this.tNedit_IPNO2.Text = ipAddr[1];
                                this.tNedit_IPNO3.Text = ipAddr[2];
                                this.tNedit_IPNO4.Text = ipAddr[3];
                            }
                        }
                        else
                        {
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "該当する端末番号が存在しません。",
                                -1,
                                MessageBoxButtons.OK);

                            this._isError = true;
                            tNedit_CashRegisterNo.Clear();
                            SendMachineName_tEdit.Clear();
                            this.tNedit_IPNO1.Clear();
                            this.tNedit_IPNO2.Clear();
                            this.tNedit_IPNO3.Clear();
                            this.tNedit_IPNO4.Clear();

                            e.NextCtrl = e.PrevCtrl;
                        }

                        break;
                    }
                case "tEdit_SectionCode":
                    {
                        string sectionCode = this.tEdit_SectionCode.DataText;

                        if (sectionCode.Trim().Equals(""))
                        {
                            this.tEdit_SectionName.DataText = string.Empty;
                            return;
                        }

                        // 拠点名称取得
                        string sectionName = GetSectionName(sectionCode);

                        if (sectionName.Trim() != string.Empty)
                        {
                            this.tEdit_SectionName.DataText = sectionName;
                            if (e.ShiftKey == false)
                            {
                                if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                                {
                                    // フォーカス設定
                                    e.NextCtrl = this.tNedit_CustomerCode;
                                }
                            }
                                
                    
                        }
                        else
                        {
                            TMsgDisp.Show(this,                     // 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,     // エラーレベル
                            ASSEMBLY_ID,							// アセンブリID
                            "拠点が存在しません。",	                // 表示するメッセージ
                            0,									    // ステータス値
                            MessageBoxButtons.OK);					// 表示するボタン

                            this._isError = true;
                            this.tEdit_SectionName.Clear();
                            this.tEdit_SectionCode.Clear();
                            e.NextCtrl = e.PrevCtrl;
                        }

                        break;
                    }
                case "tNedit_CustomerCode":
                    {
                        if (this.ModeChangeProc())
                        {
                            return;
                        }

                        if (tNedit_CustomerCode.GetInt() == 0)
                        {
                            this.tNedit_CustomerCode.Clear();
                            this.CustomerName_tEdit.Clear();
                            return;
                        }

                        // 得意先コード取得
                        int customerCode = this.tNedit_CustomerCode.GetInt();

                        // 得意先名称取得
                        string customerName = GetCustomerName(customerCode);

                        if (customerName.Trim() != string.Empty)
                        {
                            this.CustomerName_tEdit.DataText = customerName;
                            if (e.ShiftKey == false)
                            {
                                if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                                {
                                    // フォーカス設定
                                    e.NextCtrl = this.AutoSendDiv_tCmbEdit;
                                }
                            }
                        }
                        else
                        {
                            TMsgDisp.Show(this,                     // 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,     // エラーレベル
                            ASSEMBLY_ID,							// アセンブリID
                            "得意先が存在しません。",	            // 表示するメッセージ
                            0,									    // ステータス値
                            MessageBoxButtons.OK);					// 表示するボタン

                            this._isError = true;
                            this.tNedit_CustomerCode.Clear();
                            this.CustomerName_tEdit.Clear();
                            e.NextCtrl = e.PrevCtrl;
                        }

                        break;
                    }
            }

            // 画面を閉じるの場合　仕入先名称取得しない
            if (e.PrevCtrl == null || e.NextCtrl.Name == "Cancel_Button")
            {
                return;
            }
            if (e.PrevCtrl.Name == this.AutoSendDiv_tCmbEdit.Name && e.Key == Keys.Down)
            {
                if (this.HourSt_tNedit.Enabled)
                {
                    e.NextCtrl = this.HourSt_tNedit;
                }
                else
                {
                    e.NextCtrl = this.ConnectUserId_tEdit;
                }
            }
            if ((e.PrevCtrl.Name == this.Delete_Button.Name || e.PrevCtrl.Name == this.Ok_Button.Name || e.PrevCtrl.Name == this.Revive_Button.Name || e.PrevCtrl.Name == this.Cancel_Button.Name) && (e.Key == Keys.Up))
            {
                e.NextCtrl = this.CnectFileId_tEdit;
            }
        }

        /// <summary>
        /// 得意先名称取得処理
        /// </summary>
        /// <param name="customerCode">得意先コード</param>
        /// <returns>得意先名称</returns>
        /// <remarks>
        /// <br>Note        : 得意先名称を取得します。</br>
        /// <br>Programmer  : 田建委</br>
        /// <br>Date        : 2019/12/03</br>
        /// </remarks>
        private string GetCustomerName(int customerCode)
        {
            string customerName = "";

            int status;
            CustomerInfo customerInfo = new CustomerInfo();

            try
            {
                foreach (CustomerSearchRet customerSearchRet in this._customerList)
                {
                    if (customerSearchRet.CustomerCode == customerCode)
                    {
                        customerName = customerSearchRet.Name.Trim() + customerSearchRet.Name2.Trim();
                        break;
                    }
                }

                if (customerName == "")
                {
                    status = this._customerInfoAcs.ReadDBData(this._enterpriseCode, customerCode, out customerInfo);
                    if (status == 0)
                    {
                        customerName = customerInfo.Name.Trim() + customerInfo.Name2.Trim();
                    }
                }
            }
            catch
            {
                customerName = "";
            }

            return customerName;
        }

        /// <summary>
        /// 拠点名称取得処理
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <returns>拠点名称</returns>
        /// <remarks>
        /// <br>Note        : 拠点名称を取得します。</br>
        /// <br>Programmer  : 田建委</br>
        /// <br>Date        : 2019/12/03</br>
        /// </remarks>
        private string GetSectionName(string sectionCode)
        {
            string sectionName = string.Empty;

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
            else
            {
                int status = this._posTerminalMgAcs.Read(out posTerminalMg, this._enterpriseCode, cashRegisterNo);
                if (status != 0)
                {
                    posTerminalMg = null;
                }
            }

            return posTerminalMg;
        }

        /// <summary>
        /// Control.Click イベント(SectionGuide_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　 : 拠点ガイドボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer  : 田建委</br>
        /// <br>Date        : 2019/12/03</br>
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
                    this.tEdit_SectionName.DataText = secInfoSet.SectionGuideNm.Trim();

                    this.tNedit_CustomerCode.Focus();
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Control.Click イベント(CustomerGuide_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　 : 得意先ガイドボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer  : 田建委</br>
        /// <br>Date        : 2019/12/03</br>
        /// </remarks>
        private void CustomerGuide_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                this._cusotmerGuideSelected = false;

                PMKHN04005UA customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_CUSTOMER_ONLY, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY);
                customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.CustomerSearchForm_CustomerSelect);
                customerSearchForm.ShowDialog(this);

                if (this._cusotmerGuideSelected == true)
                {
                    ModeChangeProc();
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
        /// <br>Note        : 得意先ガイドボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer  : 田建委</br>
        /// <br>Date        : 2019/12/03</br>
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
            this.CustomerName_tEdit.DataText = customerSearchRet.Name.Trim();

            this._cusotmerGuideSelected = true;
        }

        /// <summary>
        /// モード変更処理
        /// </summary>
        private bool ModeChangeProc()
        {
            string customerCode = string.Empty;
            string sectionCode = string.Empty;
            // 得意先
            if (tNedit_CustomerCode.Text!="")
            {
                customerCode = tNedit_CustomerCode.Text.PadLeft(8, '0');
            }
            // 拠点
            if (tEdit_SectionCode.Text != "")
            {
                sectionCode = tEdit_SectionCode.Text.PadLeft(2, '0');
            }

            for (int i = 0; i < this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Count; i++)
            {
                // データセットと比較
                string dsSectionCode = (string)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[i][VIEW_SECTIONCD];
                string dsCustomerCode = (string)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[i][VIEW_CUSTOMERCD];
                if ((dsSectionCode == sectionCode) && (dsCustomerCode == customerCode))
                {
                    // 入力コードがデータセットに存在する場合
                    if ((string)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[i][DELETE_DATE] != "")
                    {
                        // 論理削除
                        TMsgDisp.Show(this, 					// 親ウィンドウフォーム
                          emErrorLevel.ERR_LEVEL_INFO,          // エラーレベル
                          ASSEMBLY_ID,						    // アセンブリＩＤまたはクラスＩＤ
                          "入力されたコードの売上連携接続マスタ情報は既に削除されています。", 			// 表示するメッセージ
                          0, 									// ステータス値
                          MessageBoxButtons.OK);				// 表示するボタン
                        // グループコードのクリア
                        tNedit_CustomerCode.Clear();
                        return true;
                    }

                    DialogResult res = TMsgDisp.Show(
                        this,                                   // 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_INFO,            // エラーレベル
                        ASSEMBLY_ID,                            // アセンブリＩＤまたはクラスＩＤ
                        "入力されたコードの売上連携接続マスタ情報が既に登録されています。\n編集を行いますか？",   // 表示するメッセージ
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
                                // 得意先のクリア
                                tNedit_CustomerCode.Clear();
                                CustomerName_tEdit.Clear();
                                break;
                            }
                    }
                    return true;
                }
            }
            this.AutoSendDiv_tCmbEdit.Focus();
            return false;
        }

        /// <summary>
        /// 得意先名称リスト取得処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 得意先名称のリストを取得します。</br>
        /// </remarks>
        private void GetCustomerNameList()
        {
            int status;
            CustomerSearchAcs customerSearchAcs = new CustomerSearchAcs();

            CustomerSearchRet[] customerSearchRetArray;
            CustomerSearchPara customerSearchPara = new CustomerSearchPara();
            customerSearchPara.EnterpriseCode = this._enterpriseCode;

            this._customerList = new ArrayList();

            status = customerSearchAcs.Serch(out customerSearchRetArray, customerSearchPara);
            if (status == 0)
            {
                foreach (CustomerSearchRet customerSearchRet in customerSearchRetArray)
                {
                    // 論理削除データは読み込まない
                    if (customerSearchRet.LogicalDeleteCode != 1)
                    {
                        this._customerList.Add(customerSearchRet);
                    }
                }
            }
        }
        #endregion ----- Private Method -----

        #region ----- Control Events -----
        /// <summary>
        ///	Form.Load イベント(PMSDC09010UA)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: ユーザーがフォームを読み込むときに発生します。</br>
        /// <br>Programmer  : 田建委</br>
        /// <br>Date        : 2019/12/03</br>
        /// <br>管理番号    : 11570219-00</br>
        /// <br></br>
        /// </remarks>
        private void PMSDC09010UA_Load(object sender, EventArgs e)
        {
            // アイコンリソース管理クラスを使用して、アイコンを表示する
            ImageList imageList25 = IconResourceManagement.ImageList24;
            ImageList imageList16 = IconResourceManagement.ImageList16;

            this.Ok_Button.ImageList = imageList25;
            this.Cancel_Button.ImageList = imageList25;
            this.Revive_Button.ImageList = imageList25;
            this.Delete_Button.ImageList = imageList25;

            this.Ok_Button.Appearance.Image = Size24_Index.SAVE;
            this.Cancel_Button.Appearance.Image = Size24_Index.CLOSE;
            this.Revive_Button.Appearance.Image = Size24_Index.REVIVAL;
            this.Delete_Button.Appearance.Image = Size24_Index.DELETE;
            this.SectionGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.CustomerGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
        }

        /// <summary>
        /// Timer.Tick イベント イベント(Initial_Timer)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　 : 指定された間隔の時間が経過したときに発生します。
        ///					 この処理は、システムが提供するスレッド プール
        ///					 スレッドで実行されます。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2019/12/03</br>
        /// <br>管理番号   : 11570219-00</br>
        /// <br></br>
        /// </remarks>
        private void Initial_Timer_Tick(object sender, EventArgs e)
        {
            Initial_Timer.Enabled = false;
            ScreenReconstruction();
        }

        /// <summary>
        ///	Form.VisibleChanged イベント(PMSDC09010UA)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: フォームの表示・非表示が切り替えられ
        ///					  たときに発生します。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2019/12/03</br>
        /// <br>管理番号   : 11570219-00</br>
        /// <br></br>
        /// </remarks>
        private void PMSDC09010UA_VisibleChanged(object sender, EventArgs e)
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

            ScreenClear();

            Initial_Timer.Enabled = true;
        }

        /// <summary>
        /// Control.Click イベント(Ok_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　 : 保存ボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2019/12/03</br>
        /// <br>管理番号   : 11570219-00</br>
        /// <br></br>
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

            if (!SaveSalCprtConnectInfoWork())
            {
                return;
            }
            else
            {
                this.AutoSendDiv_tCmbEdit.Focus();
            }
        }

        /// <summary>
        /// Control.Click イベント(Revive_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　 : 復活ボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2019/12/03</br>
        /// <br>管理番号   : 11570219-00</br>
        /// <br></br>
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

            int status = 0;

            SalCprtConnectInfoWork connectInfoWork = null;
            // 復活対象データ取得
            Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this._dataIndex][VIEW_FILEHEADERGUID];
            connectInfoWork = (SalCprtConnectInfoWork)this._connectInfoWorkTable[guid];

            // 復活
            status = this._connectInfoWorkAcs.Revival(ref connectInfoWork);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // DataSet展開処理
                        ConnectInfoWorkToDataSet(connectInfoWork, this._dataIndex);
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
                            ASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
                            this.Text,							// プログラム名称
                            "Revive_Button_Click",				// 処理名称
                            TMsgDisp.OPE_UPDATE,				// オペレーション
                            "復活に失敗しました。",			    // 表示するメッセージ 
                            status,								// ステータス値
                            this._connectInfoWorkAcs,				// エラーが発生したオブジェクト
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
        /// Control.Click イベント(Delete_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　 : 完全削除ボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2019/12/03</br>
        /// <br>管理番号   : 11570219-00</br>
        /// <br></br>
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
                emErrorLevel.ERR_LEVEL_QUESTION, 　 // エラーレベル
                ASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
                "データを削除します。" + "\r\n" +
                "よろしいですか？", 				// 表示するメッセージ
                0, 									// ステータス値
                MessageBoxButtons.YesNo,
                MessageBoxDefaultButton.Button2);	// 表示するボタン

            if (result != DialogResult.Yes)
            {
                this.Delete_Button.Focus();
                return;
            }

            SalCprtConnectInfoWork connectInfoWork = null;
            // 保持しているデータセットより情報取得
            Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this._dataIndex][VIEW_FILEHEADERGUID];
            connectInfoWork = (SalCprtConnectInfoWork)this._connectInfoWorkTable[guid];


            // 仕入先情報論理削除処理
            int status = this._connectInfoWorkAcs.Delete(connectInfoWork);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this.DataIndex].Delete();
                        this._connectInfoWorkTable.Remove(connectInfoWork.FileHeaderGuid);
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
                            ASSEMBLY_ID, 						// アセンブリＩＤまたはクラスＩＤ
                            this.Text, 				            // プログラム名称
                            "Delete_Button_Click", 				// 処理名称
                            TMsgDisp.OPE_DELETE, 				// オペレーション
                            "削除に失敗しました。", 			// 表示するメッセージ
                            status, 							// ステータス値
                            this._connectInfoWorkAcs, 			// エラーが発生したオブジェクト
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
        /// Control.Click イベント(Cancel_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　 : 閉じるボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2019/12/03</br>
        /// <br>管理番号   : 11570219-00</br>
        /// <br></br>
        /// </remarks>
        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            // 削除モード・参照モード以外の場合は保存確認処理を行う
            if (this.Mode_Label.Text != DELETE_MODE)
            {
                // 画面のデータを取得する
                SalCprtConnectInfoWork connectInfoWork = new SalCprtConnectInfoWork();

                ScreenToConnectInfoWork(ref connectInfoWork);

                // 画面情報と起動時のクローンと比較し変更を監視する
                if (!((this._connectInfoWorkClone.SendCcnctUserid.Trim() == connectInfoWork.SendCcnctUserid.Trim())
                   && (this._connectInfoWorkClone.SendCcnctPass.Trim() == connectInfoWork.SendCcnctPass.Trim())
                   && (this._connectInfoWorkClone.CprtUrl == connectInfoWork.CprtUrl)
                   && (this._connectInfoWorkClone.LoginTimeoutVal == connectInfoWork.LoginTimeoutVal)
                   && (this._connectInfoWorkClone.AutoSendDiv == connectInfoWork.AutoSendDiv)
                   && (this._connectInfoWorkClone.BootTime == connectInfoWork.BootTime)
                   && (this._connectInfoWorkClone.CnectObjectDiv == connectInfoWork.CnectObjectDiv)
                   && (this._connectInfoWorkClone.CnectSendDiv == connectInfoWork.CnectSendDiv)
                   && (this._connectInfoWorkClone.CnectFileId == connectInfoWork.CnectFileId)
                   && (this._connectInfoWorkClone.CashregiSterno == connectInfoWork.CashregiSterno)
                   && (this._connectInfoWorkClone.RetryCnt == connectInfoWork.RetryCnt)
                   && (this._connectInfoWorkClone.SectionCode == connectInfoWork.SectionCode)
                   && (this._connectInfoWorkClone.CustomerCode == connectInfoWork.CustomerCode)
                   && (this._connectInfoWorkClone.EndTime == connectInfoWork.EndTime)
                   && (this._connectInfoWorkClone.ExecInterval == connectInfoWork.ExecInterval)
                    // --- ADD 2020/02/04 T.Obara ---------- 修正内容一覧No.2 >>>>>
                   && (this._connectInfoWorkClone.Note1SetDiv == connectInfoWork.Note1SetDiv)
                   && (this._connectInfoWorkClone.Note2SetDiv == connectInfoWork.Note2SetDiv)
                   && (this._connectInfoWorkClone.Note3SetDiv == connectInfoWork.Note3SetDiv)
                    // --- ADD 2020/02/04 T.Obara ---------- 修正内容一覧No.2 <<<<<
                   && (this._connectInfoWorkClone.FrstSendDate == connectInfoWork.FrstSendDate)
                   && (this._connectInfoWorkClone.LtAtSadDateTime.ToString("yyyyMMddhhmmss") == connectInfoWork.LtAtSadDateTime.ToString("yyyyMMddhhmmss"))
                   && (this._connectInfoWorkClone.SupplierCd == connectInfoWork.SupplierCd)))                  
                {
                    // 画面情報が変更されていた場合は、保存確認メッセージを表示
                    DialogResult res = TMsgDisp.Show(
                       this,
                       emErrorLevel.ERR_LEVEL_QUESTION,
                       this.Name,
                       "編集中のデータが存在します。" + "\r\n" + "\r\n" +
                       "登録してもよいですか？",
                       0,
                       MessageBoxButtons.YesNoCancel,
                       MessageBoxDefaultButton.Button1);

                    switch (res)
                    {
                        case DialogResult.Yes:
                            {
                                if (!SaveSalCprtConnectInfoWork())
                                {
                                    return;
                                }
                                else
                                {
                                    this.AutoSendDiv_tCmbEdit.Focus();
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

        /// <summary>
        /// 自動送信区分が変化時のイベント
        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント引数</param>
        /// <remarks>
        /// <br>Note		 : コントロールがの値が変更する場合に発生します。</br>
        /// <br>Programmer	 : 田建委</br>
        /// <br>Date		 : 2019/12/03</br>
        /// </remarks>
        private void AutoSendDiv_tEdit_ValueChanged(object sender, EventArgs e)
        {
            if (this.AutoSendDiv_tCmbEdit.SelectedIndex == 0)
            {
                this.HourSt_tNedit.Enabled = true;
                this.MinuteSt_tNedit.Enabled = true;
                this.HourEd_tNedit.Enabled = true;
                this.MinuteEd_tNedit.Enabled = true;
                this.tNedit_ExecInterval.Enabled = true;
                this.CnectObjectDiv_tCmbEdit.Enabled = true;
                this.CnectSendDiv_tCmbEdit.Enabled = true;

                this.CnectObjectDiv_tCmbEdit.SelectedIndex = 1;
                this.CnectSendDiv_tCmbEdit.SelectedIndex = 1;

                this.tNedit_CashRegisterNo.Enabled = true;
            }
            else if (this.AutoSendDiv_tCmbEdit.SelectedIndex == 1)
            {
                // クリア
                this.CnectObjectDiv_tCmbEdit.SelectedIndex = -1;
                this.CnectSendDiv_tCmbEdit.SelectedIndex = -1;

                this.HourSt_tNedit.Enabled = false;
                this.MinuteSt_tNedit.Enabled = false;
                this.HourEd_tNedit.Enabled = false;
                this.MinuteEd_tNedit.Enabled = false;
                this.tNedit_ExecInterval.Enabled = false;
                this.CnectObjectDiv_tCmbEdit.Enabled = false;
                this.CnectSendDiv_tCmbEdit.Enabled = false;

                this.tNedit_CashRegisterNo.Clear();
                this.tNedit_CashRegisterNo.Enabled = false;
                this.SendMachineName_tEdit.Clear();
                this.tNedit_IPNO1.Clear();
                this.tNedit_IPNO2.Clear();
                this.tNedit_IPNO3.Clear();
                this.tNedit_IPNO4.Clear();

            }
        }

        /// <summary>
        /// フォーカスがLeave時のイベント
        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント引数</param>
        /// <remarks>
        /// <br>Note		 : コントロールフォーカスが変更する場合に発生します。</br>
        /// <br>Programmer	 : 田建委</br>
        /// <br>Date		 : 2019/12/03</br>
        /// </remarks>
        private void Hour_tNedit_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.HourSt_tNedit.Text))
            {
                try
                {
                    int hour = int.Parse(this.HourSt_tNedit.Text.Trim());
                }
                catch
                {
                    this.HourSt_tNedit.Clear();
                    return;
                }

                ScreenSingleDataCheck(this.HourSt_tNedit);
            }
        }

        /// <summary>
        /// フォーカスがLeave時のイベント
        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント引数</param>
        /// <remarks>
        /// <br>Note		 : コントロールフォーカスが変更する場合に発生します。</br>
        /// <br>Programmer	 : 田建委</br>
        /// <br>Date		 : 2019/12/03</br>
        /// </remarks>
        private void Minute_tNedit_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.MinuteSt_tNedit.Text))
            {
                try
                {
                    int minite = int.Parse(this.MinuteSt_tNedit.Text.Trim());
                }
                catch
                {
                    this.MinuteSt_tNedit.Clear();
                    return;
                }
                ScreenSingleDataCheck(this.MinuteSt_tNedit);
            }
        }

        /// <summary>
        /// フォーカスがLeave時のイベント
        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント引数</param>
        /// <remarks>
        /// <br>Note		 : コントロールフォーカスが変更する場合に発生します。</br>
        /// <br>Programmer	 : 田建委</br>
        /// <br>Date		 : 2019/12/03</br>
        /// </remarks>
        private void TimeOut_tNedit_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.TimeOut_tNedit.Text))
            {
                try
                {
                    int retryCnt = int.Parse(this.TimeOut_tNedit.Text.Trim());
                }
                catch
                {
                    this.TimeOut_tNedit.Clear();
                    return;
                }
                ScreenSingleDataCheck(this.TimeOut_tNedit);
            }
        }

        /// <summary>
        /// フォーカスがLeave時のイベント
        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント引数</param>
        /// <remarks>
        /// <br>Note		 : コントロールフォーカスが変更する場合に発生します。</br>
        /// <br>Programmer	 : 田建委</br>
        /// <br>Date		 : 2019/12/03</br>
        /// </remarks>
        private void RetryCnt_tNedit_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.RetryCnt_tNedit.Text))
            {
                try
                {
                    int retryCnt = int.Parse(this.RetryCnt_tNedit.Text.Trim());
                }
                catch
                {
                    this.RetryCnt_tNedit.Clear();
                    return;
                }
                ScreenSingleDataCheck(this.RetryCnt_tNedit);
            }
        }

        /// <summary>
        /// 画面入力情報不正チェック処理
        /// </summary>
        /// <param name="control">不正対象コントロール</param>
        /// <remarks>
        /// <br>Note	　 : 画面入力情報の不正チェックを行います。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2019/12/03</br>
        /// <br>管理番号   : 11570219-00</br>
        /// <br></br>
        /// </remarks>
        private void ScreenSingleDataCheck(Control control)
        {
            string message = string.Empty;
            // 自動送信起動時間
            if (control.Name == this.HourSt_tNedit.Name)
            {
                if (int.Parse(this.HourSt_tNedit.Text) < 0 || int.Parse(this.HourSt_tNedit.Text) > 23)
                {
                    control = this.HourSt_tNedit;
                    message = "時刻を入力してください。";
                }
            }
            // 自動送信起動時間
            if (control.Name == this.MinuteSt_tNedit.Name)
            {
                if (int.Parse(this.MinuteSt_tNedit.Text) < 0 || int.Parse(this.MinuteSt_tNedit.Text) > 59)
                {
                    control = this.MinuteSt_tNedit;
                    message = "時刻を入力してください。";
                }
            }

            // 自動送信終了時間
            if (control.Name == this.HourEd_tNedit.Name)
            {
                if (int.Parse(this.HourEd_tNedit.Text) < 0 || int.Parse(this.HourEd_tNedit.Text) > 23)
                {
                    control = this.HourEd_tNedit;
                    message = "時刻を入力してください。";
                }
            }
            // 自動送信終了時間
            if (control.Name == this.MinuteEd_tNedit.Name)
            {
                if (int.Parse(this.MinuteEd_tNedit.Text) < 0 || int.Parse(this.MinuteEd_tNedit.Text) > 59)
                {
                    control = this.MinuteEd_tNedit;
                    message = "時刻を入力してください。";
                }
            }
            // タイムアウト
            if (control.Name == this.TimeOut_tNedit.Name)
            {
                if (int.Parse(this.TimeOut_tNedit.Text) < 0 || int.Parse(this.TimeOut_tNedit.Text) > 3600)
                {
                    control = this.TimeOut_tNedit;
                    message = "3600秒以下を入力してください。";
                }
                this.TimeOut_tNedit.Text = int.Parse(this.TimeOut_tNedit.Text).ToString();
            }
            // リトライ回数
            if (control.Name == this.RetryCnt_tNedit.Name)
            {
                if (int.Parse(this.RetryCnt_tNedit.Text) < 0 || int.Parse(this.RetryCnt_tNedit.Text) > 5)
                {
                    control = this.RetryCnt_tNedit;
                    message = "5回以下を入力してください。";
                }
            }

            // 初回送信基準日
            int frstSendDate = GetFrstSendDate();
            if (frstSendDate != 0)
            {
                try
                {
                    DateTime dt = DateTime.ParseExact(frstSendDate.ToString(), "yyyyMMdd", System.Globalization.CultureInfo.CurrentCulture);
                }
                catch
                {
                    control = this.tNedit_FrstSendDateYear;
                    message = "日付を入力してください。";
                }
            }

            if (!string.IsNullOrEmpty(message))
            {
                control.Focus();
                TMsgDisp.Show(
                        this, 								// 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
                        ASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
                        message, 							// 表示するメッセージ
                        0, 									// ステータス値
                        MessageBoxButtons.OK);				// 表示するボタン
            }
        }

        /// <summary>
        /// フォーカスがLeave時のイベント
        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント引数</param>
        /// <remarks>
        /// <br>Note		 : コントロールフォーカスが変更する場合に発生します。</br>
        /// <br>Programmer	 : 田建委</br>
        /// <br>Date		 : 2019/12/03</br>
        /// </remarks>
        private void HourEd_tNedit_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.HourEd_tNedit.Text))
            {
                try
                {
                    int hour = int.Parse(this.HourEd_tNedit.Text.Trim());
                }
                catch
                {
                    this.HourEd_tNedit.Clear();
                    return;
                }

                ScreenSingleDataCheck(this.HourEd_tNedit);
            }

        }

        /// <summary>
        /// フォーカスがLeave時のイベント
        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント引数</param>
        /// <remarks>
        /// <br>Note		 : コントロールフォーカスが変更する場合に発生します。</br>
        /// <br>Programmer	 : 田建委</br>
        /// <br>Date		 : 2019/12/03</br>
        /// </remarks>
        private void MinuteEd_tNedit_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.MinuteEd_tNedit.Text))
            {
                try
                {
                    int minute = int.Parse(this.MinuteEd_tNedit.Text.Trim());
                }
                catch
                {
                    this.MinuteEd_tNedit.Clear();
                    return;
                }

                ScreenSingleDataCheck(this.MinuteEd_tNedit);
            }
        }

        /// <summary>
        /// フォーカスがLeave時のイベント
        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント引数</param>
        /// <remarks>
        /// <br>Note		 : コントロールフォーカスが変更する場合に発生します。</br>
        /// <br>Programmer	 : 田建委</br>
        /// <br>Date		 : 2019/12/03</br>
        /// </remarks>
        private void tNedit_ExecInterval_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.tNedit_ExecInterval.Text))
            {
                try
                {
                    int execInterval = int.Parse(this.tNedit_ExecInterval.Text.Trim());
                }
                catch
                {
                    this.tNedit_ExecInterval.Clear();
                    return;
                }

                ScreenSingleDataCheck(this.tNedit_ExecInterval);
            }
        }

        /// <summary>
        /// フォーカスがLeave時のイベント
        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント引数</param>
        /// <remarks>
        /// <br>Note		 : コントロールフォーカスが変更する場合に発生します。</br>
        /// <br>Programmer	 : 田建委</br>
        /// <br>Date		 : 2019/12/03</br>
        /// </remarks>
        private void tNedit_FrstSendDateYear_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.tNedit_FrstSendDateYear.Text))
            {
                try
                {
                    int year = int.Parse(this.tNedit_FrstSendDateYear.Text.Trim());
                }
                catch
                {
                    this.tNedit_FrstSendDateYear.Clear();
                    return;
                }

                ScreenSingleDataCheck(this.tNedit_FrstSendDateYear);
            }
        }

        /// <summary>
        /// フォーカスがLeave時のイベント
        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント引数</param>
        /// <remarks>
        /// <br>Note		 : コントロールフォーカスが変更する場合に発生します。</br>
        /// <br>Programmer	 : 田建委</br>
        /// <br>Date		 : 2019/12/03</br>
        /// </remarks>
        private void tNedit_FrstSendDateMonth_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.tNedit_FrstSendDateMonth.Text))
            {
                try
                {
                    int mouth = int.Parse(this.tNedit_FrstSendDateMonth.Text.Trim());
                }
                catch
                {
                    this.tNedit_FrstSendDateMonth.Clear();
                    return;
                }

                ScreenSingleDataCheck(this.tNedit_FrstSendDateMonth);
            }
        }

        /// <summary>
        /// フォーカスがLeave時のイベント
        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント引数</param>
        /// <remarks>
        /// <br>Note		 : コントロールフォーカスが変更する場合に発生します。</br>
        /// <br>Programmer	 : 田建委</br>
        /// <br>Date		 : 2019/12/03</br>
        /// </remarks>
        private void tNedit_FrstSendDateDay_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.tNedit_FrstSendDateDay.Text))
            {
                try
                {
                    int day = int.Parse(this.tNedit_FrstSendDateDay.Text.Trim());
                }
                catch
                {
                    this.tNedit_FrstSendDateDay.Clear();
                    return;
                }

                ScreenSingleDataCheck(this.tNedit_FrstSendDateDay);
            }
        }

       #endregion ----- Control Events -----
        

    }
}

