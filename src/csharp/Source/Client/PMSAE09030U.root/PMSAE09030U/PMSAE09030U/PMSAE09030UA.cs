//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 接続先情報設定マスタメンテナンス
// プログラム概要   : 接続先情報設定マスタの登録・変更・削除を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2013 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10901034-00 作成担当 : lyc
// 作 成 日  2013/06/26  修正内容 : 新規作成
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
    /// <br>Programmer	: lyc</br>
    /// <br>Date		: 2013/06/26</br>
    /// <br>管理番号    : 10901034-00</br>
    /// <br></br>
    /// </remarks>
    public partial class PMSAE09030UA : Form,IMasterMaintenanceMultiType
    {
        #region コンストラクタ
        /// <summary>
        /// PMSAE09030Uコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note		: 接続先情報設定フォームクラスコンストラクタです</br>
        /// <br>Programer	: lyc</br>
        /// <br>Date		: 2013/06/26</br>
        /// <br>管理番号    : 10901034-00</br>
        /// </remarks>
        public PMSAE09030UA()
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
            this._connectInfoWork = new ConnectInfoWork();
            this._connectInfoWorkClone = new ConnectInfoWork();

            // connectInfoWorkAcsクラスアクセスクラス
            this._connectInfoWorkAcs = new ConnectInfoWorkAcs();

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

        private ConnectInfoWork _connectInfoWork;
        private ConnectInfoWorkAcs _connectInfoWorkAcs;

        // 保存比較用Clone
        private ConnectInfoWork _connectInfoWorkClone;
        private ControlScreenSkin _controlScreenSkin;                           // スキン設定用クラス

        // HashTable
        private Hashtable _connectInfoWorkTable;

        // 端末管理情報キャッシュ
        private Dictionary<int, PosTerminalMg> _posTerminalMgDic;
        private PosTerminalMgAcs _posTerminalMgAcs = null;  // 端末管理設定アクセスクラス

        private int _indexBuf;
        private string _enterpriseCode;

        private const string ASSEMBLY_ID            = "PMSAE09030U";
        private const int SUPPLIERCODE              = 0;     
        private const string MAXHOUR                = "24";
        private const string MINMINUTE              = "00";

        // FrameのView用Grid列のKEY情報 (HeaderのTitle部となります)
        private const string DELETE_DATE            = "削除日";
        private const string VIEW_SUPPLIERCD        = "仕入先コード";
        private const string VIEW_AUTOSENDDIV       = "自動送信区分";
        private const string VIEW_HOURANDMINUTE     = "自動送信起動時間";
        private const string VIEW_CNECTOBJECTDIV    = "自動送信対象";
        private const string VIEW_CNECTSENDDIV      = "自動接続送信区分";
        private const string VIEW_CONNECTUSERID     = "ユーザーコード";
        private const string VIEW_CONNECTPASSWORD   = "パスワード";
        private const string VIEW_DAIHATSUORDREDIV  = "プロトコル";
        private const string VIEW_DOMAIN            = "ドメイン";
        private const string VIEW_ORDERURL          = "発注用アドレス";
        private const string VIEW_TIMEOUT           = "タイムアウト";
        private const string VIEW_RETRYCNT          = "リトライ回数";
        private const string VIEW_CNECTFILEID       = "接続ファイルID";
        private const string CASH_REGISTER_NO       = "端末番号";
        private const string VIEW_SENDMACHINENAME   = "送信端末";
        private const string VIEW_SENDMACHINEIPADDR = "IPアドレス";
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
            System.Windows.Forms.Application.Run(new PMSAE09030UA());
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
        /// <br>Programer  : lyc</br>
        /// <br>Date	   : 2013/06/26</br>
        /// <br>管理番号   : 10901034-00</br>
        /// <br></br>
        /// </remarks>
        public int Delete()
        {
            // 保持しているデータセットより修正前情報取得
            Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this.DataIndex][VIEW_FILEHEADERGUID];

            ConnectInfoWork connectInfoWork = (ConnectInfoWork)this._connectInfoWorkTable[guid];

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
        /// <br>Programer  : lyc</br>
        /// <br>Date	   : 2013/06/26</br>
        /// <br>管理番号   : 10901034-00</br>
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
        /// <br>Programer  : lyc</br>
        /// <br>Date	   : 2013/06/26</br>
        /// <br>管理番号   : 10901034-00</br>
        /// <br></br>
        /// </remarks>
        public System.Collections.Hashtable GetAppearanceTable()
        {
            Hashtable appearanceTable = new Hashtable();

            // 削除日
            appearanceTable.Add(DELETE_DATE, new GridColAppearance(MGridColDispType.DeletionDataBoth, ContentAlignment.MiddleCenter, "", Color.Red));
            // 仕入先コード
            appearanceTable.Add(VIEW_SUPPLIERCD, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleCenter, "", Color.Black));
            // 自動送信区分
            appearanceTable.Add(VIEW_AUTOSENDDIV, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 自動送信起動時間
            appearanceTable.Add(VIEW_HOURANDMINUTE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            // 自動送信対象
            appearanceTable.Add(VIEW_CNECTOBJECTDIV, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 自動接続送信区分
            appearanceTable.Add(VIEW_CNECTSENDDIV, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // ユーザーコード
            appearanceTable.Add(VIEW_CONNECTUSERID, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // パスワード
            appearanceTable.Add(VIEW_CONNECTPASSWORD, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // プロトコル
            appearanceTable.Add(VIEW_DAIHATSUORDREDIV, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // ドメイン
            appearanceTable.Add(VIEW_DOMAIN, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 発注用アドレス
            appearanceTable.Add(VIEW_ORDERURL, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // タイムアウト
            appearanceTable.Add(VIEW_TIMEOUT, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            // リトライ回数
            appearanceTable.Add(VIEW_RETRYCNT, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            // 接続ファイルID
            appearanceTable.Add(VIEW_CNECTFILEID, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 端末番号
            appearanceTable.Add(CASH_REGISTER_NO, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "00#", Color.Black));
            // 送信端末
            appearanceTable.Add(VIEW_SENDMACHINENAME, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 端末IPアドレス
            appearanceTable.Add(VIEW_SENDMACHINEIPADDR, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
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
        /// <br>Programer	: lyc</br>
        /// <br>Date		: 2013/06/26</br>
        /// <br>管理番号    : 10901034-00</br>
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
        /// <br>Programer  : lyc</br>
        /// <br>Date	   : 2013/06/26</br>
        /// <br>管理番号   : 10901034-00</br>
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
        /// <br>Programer  : lyc</br>
        /// <br>Date	   : 2013/06/26</br>
        /// <br>管理番号   : 10901034-00</br>
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

                        foreach (ConnectInfoWork connectInfoWork in connectInfoWorkAcsList)
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
                            "PMSAE09030UA",							// アセンブリID
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
        /// <br>Programer  : lyc</br>
        /// <br>Date	   : 2013/06/26</br>
        /// <br>管理番号   : 10901034-00</br>
        /// <br></br>
        /// </remarks>
        private void ConnectInfoWorkToDataSet(ConnectInfoWork connectInfoWork, int index)
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
            // 仕入先コード
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SUPPLIERCD] = SUPPLIERCODE.ToString();
            // 自動送信区分
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_AUTOSENDDIV] = (connectInfoWork.AutoSendDiv == 0) ? "する" : "しない";
            // 自動送信起動時間 
            if (connectInfoWork.AutoSendDiv != 0)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_HOURANDMINUTE] = string.Empty;
            }
            else
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_HOURANDMINUTE] = connectInfoWork.BootTime.ToString().PadLeft(4, '0').Substring(0, 2) + ":" + connectInfoWork.BootTime.ToString().PadLeft(4, '0').Substring(2, 2);
            }
            // 自動送信対象
            if (connectInfoWork.AutoSendDiv != 0)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CNECTOBJECTDIV] = string.Empty;
            }
            else
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CNECTOBJECTDIV] = (connectInfoWork.CnectObjectDiv == 0) ? "当日" : "前日";

            }
            // 自動接続送信区分
            if (connectInfoWork.AutoSendDiv != 0)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CNECTSENDDIV] = string.Empty;
            }
            else
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CNECTSENDDIV] = (connectInfoWork.CnectSendDiv == 0) ? "全て" : "未送信";
            }
            // ユーザーコード
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CONNECTUSERID] = connectInfoWork.SAndECnctUserId;
            // パスワード
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CONNECTPASSWORD] = connectInfoWork.SAndECnctPass;
            // プロトコル
            if (connectInfoWork.DaihatsuOrdreDiv == 0)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_DAIHATSUORDREDIV] = "HTTP";
            }
            else if (connectInfoWork.DaihatsuOrdreDiv == 1)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_DAIHATSUORDREDIV] = "HTTPS";
            }
            // ドメイン
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_DOMAIN] = connectInfoWork.OrderUrl;
            // 発注用アドレス
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_ORDERURL] = connectInfoWork.StockCheckUrl;
            // タイムアウト
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_TIMEOUT] = connectInfoWork.LoginTimeoutVal;
            // リトライ回数
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_RETRYCNT] = connectInfoWork.RetryCnt;
            // 接続ファイルID
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CNECTFILEID] = connectInfoWork.CnectFileId;
            // 端末番号
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][CASH_REGISTER_NO] = connectInfoWork.CashRegisterNo;
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
        /// <br>Programer  : lyc</br>
        /// <br>Date	   : 2013/06/26</br>
        /// <br>管理番号   : 10901034-00</br>
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
        /// <br>Programmer : lyc</br>
        /// <br>Date       : 2013/06/26</br>
        /// <br>管理番号   : 10901034-00</br>
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
        /// <br>Programmer : lyc</br>
        /// <br>Date       : 2013/06/26</br>
        /// <br>管理番号   : 10901034-00</br>
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
        /// <br>Programmer : lyc</br>
        /// <br>Date       : 2013/06/26</br>
        /// <br>管理番号   : 10901034-00</br>
        /// <br></br>
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
                    this.AutoSendDiv_tCmbEdit.Enabled = true;
                    this.Hour_tNedit.Enabled = true;
                    this.Minute_tNedit.Enabled = true;
                    this.CnectObjectDiv_tCmbEdit.Enabled = true;
                    this.CnectSendDiv_tCmbEdit.Enabled = true;
                    this.ConnectUserId_tEdit.Enabled = true;
                    this.ConnectPassword_tEdit.Enabled = true;
                    this.DaihatsuOrdreDiv_tCmbEdit.Enabled = true;
                    this.Domain_tEdit.Enabled = true;
                    this.OrderAddress_tEdit.Enabled = true;
                    this.TimeOut_tNedit.Enabled = true;
                    this.RetryCnt_tNedit.Enabled = true;
                    this.CnectFileId_tEdit.Enabled = true;
                    this.tNedit_CashRegisterNo.Enabled = true;
                    break;

                // 2:削除
                case 2:

                    // ボタン
                    this.Delete_Button.Visible = true;
                    this.Revive_Button.Visible = true;
                    this.Ok_Button.Visible = false;
                    this.Cancel_Button.Visible = true;

                    // パネル
                    this.AutoSendDiv_tCmbEdit.Enabled = false;
                    this.Hour_tNedit.Enabled = false;
                    this.Minute_tNedit.Enabled = false;
                    this.CnectObjectDiv_tCmbEdit.Enabled = false;
                    this.CnectSendDiv_tCmbEdit.Enabled = false;
                    this.ConnectUserId_tEdit.Enabled = false;
                    this.ConnectPassword_tEdit.Enabled = false;
                    this.DaihatsuOrdreDiv_tCmbEdit.Enabled = false;
                    this.Domain_tEdit.Enabled = false;
                    this.OrderAddress_tEdit.Enabled = false;
                    this.TimeOut_tNedit.Enabled = false;
                    this.RetryCnt_tNedit.Enabled = false;
                    this.CnectFileId_tEdit.Enabled = false;
                    this.tNedit_CashRegisterNo.Enabled = false;
                    break;
            }
        }

        /// <summary>
        /// データセット列情報構築処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : データセットの列情報を構築します。
        ///					 データセットの列情報がフレームのビュー用グリッドの列になります</br>
        /// <br>Programer  : lyc</br>
        /// <br>Date	   : 2013/06/26</br>
        /// <br>管理番号   : 10901034-00</br>
        /// <br></br>
        /// </remarks>
        private void DataSetColumnConstruction()
        {
            DataTable connectInfoWorkTable = new DataTable(VIEW_TABLE);

            // Addを行う順番が、列の表示順位となります。
            connectInfoWorkTable.Columns.Add(DELETE_DATE, typeof(string));                 //削除日
            connectInfoWorkTable.Columns.Add(VIEW_SUPPLIERCD, typeof(string));             //仕入先コード
            connectInfoWorkTable.Columns.Add(VIEW_AUTOSENDDIV, typeof(string));            //自動送信区分
            connectInfoWorkTable.Columns.Add(VIEW_HOURANDMINUTE, typeof(string));          //自動送信起動時間
            connectInfoWorkTable.Columns.Add(VIEW_CNECTOBJECTDIV, typeof(string));         //自動送信対象
            connectInfoWorkTable.Columns.Add(VIEW_CNECTSENDDIV, typeof(string));           //自動接続送信区分
            connectInfoWorkTable.Columns.Add(VIEW_CONNECTUSERID, typeof(string));          //ユーザーコード
            connectInfoWorkTable.Columns.Add(VIEW_CONNECTPASSWORD, typeof(string));        //パスワード
            connectInfoWorkTable.Columns.Add(VIEW_DAIHATSUORDREDIV, typeof(string));       //プロトコル
            connectInfoWorkTable.Columns.Add(VIEW_DOMAIN, typeof(string));                 //ドメイン
            connectInfoWorkTable.Columns.Add(VIEW_ORDERURL, typeof(string));               //発注用アドレス
            connectInfoWorkTable.Columns.Add(VIEW_TIMEOUT, typeof(string));                //タイムアウト
            connectInfoWorkTable.Columns.Add(VIEW_RETRYCNT, typeof(string));               //リトライ回数
            connectInfoWorkTable.Columns.Add(VIEW_CNECTFILEID, typeof(string));            //接続ファイルID
            connectInfoWorkTable.Columns.Add(CASH_REGISTER_NO, typeof(string));            //端末番号
            connectInfoWorkTable.Columns.Add(VIEW_SENDMACHINENAME, typeof(string));        //送信端末
            connectInfoWorkTable.Columns.Add(VIEW_SENDMACHINEIPADDR, typeof(string));      //端末IPアドレス
            connectInfoWorkTable.Columns.Add(VIEW_FILEHEADERGUID, typeof(Guid));           //GUID

            this.Bind_DataSet.Tables.Add(connectInfoWorkTable);
        }

        /// <summary>
        /// 画面再構築処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : モードに基づいて画面を再構築します。</br>
        /// <br>Programmer : lyc</br>
        /// <br>Date       : 2013/06/26</br>
        /// <br>管理番号   : 10901034-00</br>
        /// <br></br>
        /// </remarks>
        private void ScreenReconstruction()
        {
            if (this.DataIndex < 0)
            {
                if (this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Count > 0)
                {
                    TMsgDisp.Show(
                         this,
                         emErrorLevel.ERR_LEVEL_INFO,
                         this.Name,
                         "複数登録できません。修正又は、削除後に登録して下さい。",
                         -1,
                         MessageBoxButtons.OK);
                    this.Hide();
                    this._indexBuf = -2;
                    return;
                }
                ConnectInfoWork connectInfoWork = new ConnectInfoWork();
                this._connectInfoWorkClone = connectInfoWork.Clone();
                this._indexBuf = this._dataIndex;
                // 画面情報を比較用クローンにコピーします
                ScreenToConnectInfoWork(ref this._connectInfoWorkClone);

                //　新規モード
                this.Mode_Label.Text = INSERT_MODE;
                this.AutoSendDiv_tCmbEdit.Focus();
            }
            else
            {
                Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this._dataIndex][VIEW_FILEHEADERGUID];
                ConnectInfoWork connectInfoWork = (ConnectInfoWork)this._connectInfoWorkTable[guid];
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
        /// <br>Programmer : lyc</br>
        /// <br>Date       : 2013/06/26</br>
        /// <br>管理番号   : 10901034-00</br>
        /// <br></br>
        /// </remarks>
        private void AutoSendDivtEditValueChanged(ConnectInfoWork connectInfoWork)
        {
            if (this.AutoSendDiv_tCmbEdit.SelectedIndex == 0)
            {
                this.Hour_tNedit.Enabled = true;
                this.Minute_tNedit.Enabled = true;
                this.CnectObjectDiv_tCmbEdit.Enabled = true;
                this.CnectSendDiv_tCmbEdit.Enabled = true;

                this.CnectObjectDiv_tCmbEdit.SelectedIndex = connectInfoWork.CnectObjectDiv;
                this.CnectSendDiv_tCmbEdit.SelectedIndex = connectInfoWork.CnectSendDiv;

                this.tNedit_CashRegisterNo.Enabled = true;
            }
            else if (this.AutoSendDiv_tCmbEdit.SelectedIndex == 1)
            {
                // クリア
                this.Hour_tNedit.Text = string.Empty;
                this.Minute_tNedit.Text = string.Empty;
                this.CnectObjectDiv_tCmbEdit.SelectedIndex = -1;
                this.CnectSendDiv_tCmbEdit.SelectedIndex = -1;

                this.Hour_tNedit.Enabled = false;
                this.Minute_tNedit.Enabled = false;
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
        /// <br>Programmer : lyc</br>
        /// <br>Date       : 2013/06/26</br>
        /// <br>管理番号   : 10901034-00</br>
        /// <br></br>
        /// </remarks>
        private void WorkReconstruction(ref ConnectInfoWork connectInfoWork)
        {
            connectInfoWork.CnectFileId = connectInfoWork.CnectFileId.Trim();
            connectInfoWork.SendMachineName = connectInfoWork.SendMachineName.Trim();
        }

        /// <summary>
        /// 画面クリア処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : 画面をクリアします。</br>
        /// <br>Programmer : lyc</br>
        /// <br>Date       : 2013/06/26</br>
        /// <br>管理番号   : 10901034-00</br>
        /// <br></br>
        /// </remarks>
        private void ScreenClear()
        {
            this.AutoSendDiv_tCmbEdit.SelectedIndex = 0;
            this.CnectObjectDiv_tCmbEdit.SelectedIndex = 1;
            this.CnectSendDiv_tCmbEdit.SelectedIndex = 1;
            this.DaihatsuOrdreDiv_tCmbEdit.SelectedIndex = 0;
            this.Hour_tNedit.Text = string.Empty;
            this.Minute_tNedit.Text = string.Empty;
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
            this.AutoSendDiv_tCmbEdit.Focus();

            // ボタン
            this.Ok_Button.Visible = true;
            this.Cancel_Button.Visible = true;
            this.Revive_Button.Visible = false;
            this.Delete_Button.Visible = false;

            // パネル
            this.AutoSendDiv_tCmbEdit.Enabled = true;
            this.CnectObjectDiv_tCmbEdit.Enabled = true;
            this.CnectSendDiv_tCmbEdit.Enabled = true;
            this.DaihatsuOrdreDiv_tCmbEdit.Enabled = true;
            this.Hour_tNedit.Enabled = true;
            this.Minute_tNedit.Enabled = true;
            this.ConnectUserId_tEdit.Enabled = true;
            this.ConnectPassword_tEdit.Enabled = true;
            this.Domain_tEdit.Enabled = true;
            this.OrderAddress_tEdit.Enabled = true;
            this.TimeOut_tNedit.Enabled = true;
            this.RetryCnt_tNedit.Enabled = true;
            this.CnectFileId_tEdit.Enabled = true;
            this.tNedit_CashRegisterNo.Enabled = true;
        }

        /// <summary>
        /// 接続先情報設定マスタ画面展開処理
        /// </summary>
        /// <param name="connectInfoWork">接続先情報設定オブジェクト</param>
        /// <remarks>
        /// <br>Note       : オブジェクトから画面にデータを展開します。</br>
        /// <br>Programmer : lyc</br>
        /// <br>Date       : 2013/06/26</br>
        /// <br>管理番号   : 10901034-00</br>
        /// <br></br>
        /// </remarks>
        private void RecordToScreen(ConnectInfoWork connectInfoWork)
        {
            this.AutoSendDiv_tCmbEdit.SelectedIndex = connectInfoWork.AutoSendDiv;
            if (connectInfoWork.BootTime != 0)
            {
                this.Hour_tNedit.Text = connectInfoWork.BootTime.ToString().PadLeft(4, '0').Substring(0, 2);
                this.Minute_tNedit.Text = connectInfoWork.BootTime.ToString().PadLeft(4, '0').Substring(2, 2); ;
            }
            else
            {
                if (connectInfoWork.AutoSendDiv == 1)
                {
                    this.Hour_tNedit.Text = string.Empty;
                    this.Minute_tNedit.Text = string.Empty;
                }
                else
                {
                    this.Hour_tNedit.Text = "00";
                    this.Minute_tNedit.Text = "00";
                }
            }
            this.CnectObjectDiv_tCmbEdit.SelectedIndex = connectInfoWork.CnectObjectDiv;
            this.CnectSendDiv_tCmbEdit.SelectedIndex = connectInfoWork.CnectSendDiv;
            this.ConnectUserId_tEdit.Text = connectInfoWork.SAndECnctUserId.ToString().Trim();
            this.ConnectPassword_tEdit.Text = connectInfoWork.SAndECnctPass.ToString().Trim();
            this.DaihatsuOrdreDiv_tCmbEdit.SelectedIndex = connectInfoWork.DaihatsuOrdreDiv;
            this.Domain_tEdit.Text = connectInfoWork.OrderUrl;
            this.OrderAddress_tEdit.Text = connectInfoWork.StockCheckUrl; 
            this.TimeOut_tNedit.Text = connectInfoWork.LoginTimeoutVal.ToString();
            this.RetryCnt_tNedit.Text = connectInfoWork.RetryCnt.ToString();
            this.CnectFileId_tEdit.Text = connectInfoWork.CnectFileId;
            this.tNedit_CashRegisterNo.SetInt(connectInfoWork.CashRegisterNo);

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
        }

        /// <summary>
        /// 保存処理(SaveconnectInfoWork())
        /// </summary>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note　　　  : 保存処理を行います。</br>
        /// <br>Programmer  : lyc</br>
        /// <br>Date        : 2013/06/26</br>
        /// <br>管理番号    : 10901034-00</br>
        /// </remarks>
        private bool SaveConnectInfoWork()
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

            ConnectInfoWork connectInfoWork = null;

            if (this.DataIndex >= 0)
            {
                Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this._dataIndex][VIEW_FILEHEADERGUID];
                connectInfoWork = (ConnectInfoWork)this._connectInfoWorkTable[guid];
            }

            // 画面にデータを取得
            ScreenToConnectInfoWork(ref connectInfoWork);
            // 保存処理
            int status = this._connectInfoWorkAcs.Write(ref connectInfoWork);

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
                            "この仕入先コードは既に使用されています。",// 表示するメッセージ
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
                            "PrcPrSt",  　　                 // プログラム名称
                            "ConnectInfoWork",                       // 処理名称
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
            ConnectInfoWorkToDataSet(connectInfoWork, this.DataIndex);

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
        /// <br>Programmer  : lyc</br>
        /// <br>Date        : 2013/06/26</br>
        /// <br>管理番号    : 10901034-00</br>
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
                    Hour_tNedit.Leave -= new EventHandler(Hour_tNedit_Leave);
                    Minute_tNedit.Leave -= new EventHandler(Minute_tNedit_Leave);
                    control.Focus();
                    TimeOut_tNedit.Leave += new EventHandler(TimeOut_tNedit_Leave);
                    RetryCnt_tNedit.Leave += new EventHandler(RetryCnt_tNedit_Leave);
                    Hour_tNedit.Leave += new EventHandler(Hour_tNedit_Leave);
                    Minute_tNedit.Leave += new EventHandler(Minute_tNedit_Leave);
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
        /// <br>Programmer : lyc</br>
        /// <br>Date       : 2013/06/26</br>
        /// <br>管理番号   : 10901034-00</br>
        /// <br></br>
        /// </remarks>
        private bool ScreenDataCheck(ref Control control, ref string message)
        {
            if (this.AutoSendDiv_tCmbEdit.SelectedIndex == 0)
            {
                // 自動送信起動時間 時
                if (string.IsNullOrEmpty(this.Hour_tNedit.Text.Trim()))
                {
                    control = this.Hour_tNedit;
                    message = "自動送信起動時間を入力してください。";
                    return (false);
                }

                if (int.Parse(this.Hour_tNedit.Text) < 0 || int.Parse(this.Hour_tNedit.Text) > 23)
                {
                    control = this.Hour_tNedit;
                    message = "起動時間を正確入力してください。";
                    return (false);
                }

                // 自動送信起動時間 分
                if (string.IsNullOrEmpty(this.Minute_tNedit.Text.Trim()))
                {
                    control = this.Minute_tNedit;
                    message = "自動送信起動時間を入力してください。";
                    return (false);
                }

                if (int.Parse(this.Minute_tNedit.Text) < 0 || int.Parse(this.Minute_tNedit.Text) > 59)
                {
                    control = this.Minute_tNedit;
                    message = "起動時間を正確入力してください。";
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
                message = "タイムアウトは3600以下を入力してください。";
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
                message = "リトライ回数は6以下を入力してください。";
                return (false);
            }

            // 接続ファイルID
            if (string.IsNullOrEmpty(this.CnectFileId_tEdit.Text.Trim()))
            {
                control = this.CnectFileId_tEdit;
                message = "接続ファイルIDを入力してください。";
                return (false);
            }

            return true;
        }

        /// <summary>
        /// 接続先情報設定クラス格納処理
        /// </summary>
        /// <param name="connectInfoWork">接続先情報設定オブジェクト</param>
        /// <remarks>
        /// <br>Note       : 画面情報から接続先情報設定オブジェクトにデータを格納します。</br>
        /// <br>Programmer : lyc</br>
        /// <br>Date       : 2013/06/26</br>
        /// <br>管理番号   : 10901034-00</br>
        /// <br></br>
        /// </remarks>
        private void ScreenToConnectInfoWork(ref ConnectInfoWork connectInfoWork)
        {
            if (connectInfoWork == null)
            {
                connectInfoWork = new ConnectInfoWork();
            }
            // 企業コード
            connectInfoWork.EnterpriseCode = this._enterpriseCode;
            // 仕入先コード    
            connectInfoWork.SupplierCd = SUPPLIERCODE;
            if (this.AutoSendDiv_tCmbEdit.SelectedIndex == 1)
            {
                // 自動送信対象
                connectInfoWork.CnectObjectDiv = -1;
                // 自動接続送信区分
                connectInfoWork.CnectSendDiv = -1;
                connectInfoWork.BootTime = 0;
            }
            else
            {
                // 自動送信対象
                connectInfoWork.CnectObjectDiv = this.CnectObjectDiv_tCmbEdit.SelectedIndex;
                // 自動接続送信区分
                connectInfoWork.CnectSendDiv = this.CnectSendDiv_tCmbEdit.SelectedIndex;
                // 自動送信起動時間
                if (!string.IsNullOrEmpty(this.Hour_tNedit.Text) && !string.IsNullOrEmpty(this.Minute_tNedit.Text))
                {
                    connectInfoWork.BootTime = int.Parse(this.Hour_tNedit.Text + this.Minute_tNedit.Text);
                }
            }
            //----- ADD 2013/07/04 田建委 ----->>>>>
            // 接続プログラムタイプ「1:S&E」固定でセット
            connectInfoWork.CnectProgramType = 1;
            //----- ADD 2013/07/04 田建委 -----<<<<<
            // 自動送信区分
            connectInfoWork.AutoSendDiv = this.AutoSendDiv_tCmbEdit.SelectedIndex;
            // ユーザーコード
            connectInfoWork.SAndECnctUserId = this.ConnectUserId_tEdit.Text;
            // パスワード
            connectInfoWork.SAndECnctPass = this.ConnectPassword_tEdit.Text;
            // プロトコル
            connectInfoWork.DaihatsuOrdreDiv = this.DaihatsuOrdreDiv_tCmbEdit.SelectedIndex;
            // ドメイン
            connectInfoWork.OrderUrl = this.Domain_tEdit.Text;
            // 発注用アドレス
            connectInfoWork.StockCheckUrl = this.OrderAddress_tEdit.Text;
            // 接続ファイルID
            connectInfoWork.CnectFileId = this.CnectFileId_tEdit.Text.Trim();
            // 端末番号
            connectInfoWork.CashRegisterNo = this.tNedit_CashRegisterNo.GetInt();
            // 送信端末
            connectInfoWork.SendMachineName = this.SendMachineName_tEdit.Text.Trim();
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
        /// FormClose イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : FormClose イベント</br>
        /// <br>Programmer : lyc</br>
        /// <br>Date       : 2013/06/26</br>
        /// <br>管理番号   : 10901034-00</br>
        /// <br></br>
        /// </remarks>
        private void PMSAE09030UA_FormClosing(object sender, FormClosingEventArgs e)
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
        /// <br>Programmer : lyc</br>
        /// <br>Date       : 2013/06/26</br>
        /// <br>管理番号   : 10901034-00</br>
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
            }

            // 画面を閉じるの場合　仕入先名称取得しない
            if (e.PrevCtrl == null || e.NextCtrl.Name == "Cancel_Button")
            {
                return;
            }
            if (e.PrevCtrl.Name == this.AutoSendDiv_tCmbEdit.Name && e.Key == Keys.Down)
            {
                if (this.Hour_tNedit.Enabled)
                {
                    e.NextCtrl = this.Hour_tNedit;
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
        #endregion ----- Private Method -----

        #region ----- Control Events -----
        /// <summary>
        ///	Form.Load イベント(PMSAE09030UA)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: ユーザーがフォームを読み込むときに発生します。</br>
        /// <br>Programmer  : lyc</br>
        /// <br>Date        : 2013/06/26</br>
        /// <br>管理番号    : 10901034-00</br>
        /// <br></br>
        /// </remarks>
        private void PMSAE09030UA_Load(object sender, EventArgs e)
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
        /// <br>Programmer : lyc</br>
        /// <br>Date       : 2013/06/26</br>
        /// <br>管理番号   : 10901034-00</br>
        /// <br></br>
        /// </remarks>
        private void Initial_Timer_Tick(object sender, EventArgs e)
        {
            Initial_Timer.Enabled = false;
            ScreenReconstruction();
        }

        /// <summary>
        ///	Form.VisibleChanged イベント(PMSAE09030UA)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: フォームの表示・非表示が切り替えられ
        ///					  たときに発生します。</br>
        /// <br>Programmer : lyc</br>
        /// <br>Date       : 2013/06/26</br>
        /// <br>管理番号   : 10901034-00</br>
        /// <br></br>
        /// </remarks>
        private void PMSAE09030UA_VisibleChanged(object sender, EventArgs e)
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
        /// <br>Programmer : lyc</br>
        /// <br>Date       : 2013/06/26</br>
        /// <br>管理番号   : 10901034-00</br>
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

            if (!SaveConnectInfoWork())
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
        /// <br>Programmer : lyc</br>
        /// <br>Date       : 2013/06/26</br>
        /// <br>管理番号   : 10901034-00</br>
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

            ConnectInfoWork connectInfoWork = null;
            // 復活対象データ取得
            Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this._dataIndex][VIEW_FILEHEADERGUID];
            connectInfoWork = (ConnectInfoWork)this._connectInfoWorkTable[guid];

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
        /// <br>Programmer : lyc</br>
        /// <br>Date       : 2013/06/26</br>
        /// <br>管理番号   : 10901034-00</br>
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

            ConnectInfoWork connectInfoWork = null;
            // 保持しているデータセットより情報取得
            Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this._dataIndex][VIEW_FILEHEADERGUID];
            connectInfoWork = (ConnectInfoWork)this._connectInfoWorkTable[guid];


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
        /// <br>Programmer : lyc</br>
        /// <br>Date       : 2013/06/26</br>
        /// <br>管理番号   : 10901034-00</br>
        /// <br></br>
        /// </remarks>
        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            // 削除モード・参照モード以外の場合は保存確認処理を行う
            if (this.Mode_Label.Text != DELETE_MODE)
            {
                // 画面のデータを取得する
                ConnectInfoWork connectInfoWork = new ConnectInfoWork();

                ScreenToConnectInfoWork(ref connectInfoWork);

                // 画面情報と起動時のクローンと比較し変更を監視する
                if (!((this._connectInfoWorkClone.SAndECnctUserId.Trim() == connectInfoWork.SAndECnctUserId.Trim())
                   && (this._connectInfoWorkClone.SAndECnctPass.Trim() == connectInfoWork.SAndECnctPass.Trim())
                   && (this._connectInfoWorkClone.OrderUrl == connectInfoWork.OrderUrl)
                   && (this._connectInfoWorkClone.DaihatsuOrdreDiv == connectInfoWork.DaihatsuOrdreDiv)
                   && (this._connectInfoWorkClone.StockCheckUrl == connectInfoWork.StockCheckUrl)
                   && (this._connectInfoWorkClone.LoginTimeoutVal == connectInfoWork.LoginTimeoutVal)
                   && (this._connectInfoWorkClone.AutoSendDiv == connectInfoWork.AutoSendDiv)
                   && (this._connectInfoWorkClone.BootTime == connectInfoWork.BootTime)
                   && (this._connectInfoWorkClone.CnectObjectDiv == connectInfoWork.CnectObjectDiv)
                   && (this._connectInfoWorkClone.CnectSendDiv == connectInfoWork.CnectSendDiv)
                   && (this._connectInfoWorkClone.CnectFileId == connectInfoWork.CnectFileId)
                   && (this._connectInfoWorkClone.CashRegisterNo == connectInfoWork.CashRegisterNo)
                   && (this._connectInfoWorkClone.RetryCnt == connectInfoWork.RetryCnt)
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
                                if (!SaveConnectInfoWork())
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
        /// <br>Programmer	 : lyc</br>
        /// <br>Date		 : 2013.06.26</br>
        /// </remarks>
        private void AutoSendDiv_tEdit_ValueChanged(object sender, EventArgs e)
        {
            if (this.AutoSendDiv_tCmbEdit.SelectedIndex == 0)
            {
                this.Hour_tNedit.Enabled = true;
                this.Minute_tNedit.Enabled = true;
                this.CnectObjectDiv_tCmbEdit.Enabled = true;
                this.CnectSendDiv_tCmbEdit.Enabled = true;

                this.CnectObjectDiv_tCmbEdit.SelectedIndex = 1;
                this.CnectSendDiv_tCmbEdit.SelectedIndex = 1;

                this.tNedit_CashRegisterNo.Enabled = true;
            }
            else if (this.AutoSendDiv_tCmbEdit.SelectedIndex == 1)
            {
                // クリア
                this.Hour_tNedit.Text = string.Empty;
                this.Minute_tNedit.Text = string.Empty;
                this.CnectObjectDiv_tCmbEdit.SelectedIndex = -1;
                this.CnectSendDiv_tCmbEdit.SelectedIndex = -1;

                this.Hour_tNedit.Enabled = false;
                this.Minute_tNedit.Enabled = false;
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
        /// <br>Programmer	 : lyc</br>
        /// <br>Date		 : 2013.06.26</br>
        /// </remarks>
        private void Hour_tNedit_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.Hour_tNedit.Text))
            {
                try
                {
                    int hour = int.Parse(this.Hour_tNedit.Text.Trim());
                }
                catch
                {
                    this.Hour_tNedit.Clear();
                    return;
                }

                ScreenSingleDataCheck(this.Hour_tNedit);
            }
        }

        /// <summary>
        /// フォーカスがLeave時のイベント
        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント引数</param>
        /// <remarks>
        /// <br>Note		 : コントロールフォーカスが変更する場合に発生します。</br>
        /// <br>Programmer	 : lyc</br>
        /// <br>Date		 : 2013.06.26</br>
        /// </remarks>
        private void Minute_tNedit_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.Minute_tNedit.Text))
            {
                try
                {
                    int minite = int.Parse(this.Minute_tNedit.Text.Trim());
                }
                catch
                {
                    this.Minute_tNedit.Clear();
                    return;
                }
                ScreenSingleDataCheck(this.Minute_tNedit);
            }
        }

        /// <summary>
        /// フォーカスがLeave時のイベント
        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント引数</param>
        /// <remarks>
        /// <br>Note		 : コントロールフォーカスが変更する場合に発生します。</br>
        /// <br>Programmer	 : lyc</br>
        /// <br>Date		 : 2013.06.26</br>
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
        /// <br>Programmer	 : lyc</br>
        /// <br>Date		 : 2013.06.26</br>
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
        /// <br>Programmer : lyc</br>
        /// <br>Date       : 2013/06/26</br>
        /// <br>管理番号   : 10901034-00</br>
        /// <br></br>
        /// </remarks>
        private void ScreenSingleDataCheck(Control control)
        {
            string message = string.Empty;
            // 自動送信起動時間
            if (control.Name == this.Hour_tNedit.Name)
            {
                if (int.Parse(this.Hour_tNedit.Text) < 0 || int.Parse(this.Hour_tNedit.Text) > 23)
                {
                    control = this.Hour_tNedit;
                    message = "起動時間は正確入力してください。";
                }
            }
            // 自動送信起動時間
            if (control.Name == this.Minute_tNedit.Name)
            {
                if (int.Parse(this.Minute_tNedit.Text) < 0 || int.Parse(this.Minute_tNedit.Text) > 59)
                {
                    control = this.Minute_tNedit;
                    message = "起動時間は正確入力してください。";
                }
            }
            // タイムアウト
            if (control.Name == this.TimeOut_tNedit.Name)
            {
                if (int.Parse(this.TimeOut_tNedit.Text) < 0 || int.Parse(this.TimeOut_tNedit.Text) > 3600)
                {
                    control = this.TimeOut_tNedit;
                    message = "タイムアウトは3600以下を入力してください。";
                }
                this.TimeOut_tNedit.Text = int.Parse(this.TimeOut_tNedit.Text).ToString();
            }
            // リトライ回数
            if (control.Name == this.RetryCnt_tNedit.Name)
            {
                if (int.Parse(this.RetryCnt_tNedit.Text) < 0 || int.Parse(this.RetryCnt_tNedit.Text) > 5)
                {
                    control = this.RetryCnt_tNedit;
                    message = "リトライ回数は5以下を入力してください。";
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
       #endregion ----- Control Events -----

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
    }
}

