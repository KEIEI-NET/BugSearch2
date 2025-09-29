//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 接続先情報設定マスタメンテナンス
// プログラム概要   : 接続先情報設定マスタの登録・変更・削除を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2012 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10805731-00 作成担当 : 黄興貴
// 作 成 日  2012/12/15  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
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
    /// <br>Programmer	: 黄興貴</br>
    /// <br>Date		: 2012/12/15</br>
    /// <br>管理番号    : 10805731-00</br>
    /// <br></br>
    /// </remarks>
    public partial class PMKHN09711UA : Form,IMasterMaintenanceMultiType
    {
        #region コンストラクタ
        /// <summary>
        /// PMKHN09711Uコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note		: 接続先情報設定フォームクラスコンストラクタです</br>
        /// <br>Programer	: 黄興貴</br>
        /// <br>Date		: 2012/12/15</br>
        /// <br>管理番号    : 10805731-00</br>
        /// </remarks>
        public PMKHN09711UA()
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
            this._connectInfoWorkCheckClone = new ConnectInfoWork();
            this._connectInfoWorkClone = new ConnectInfoWork();

            // connectInfoWorkAcsクラスアクセスクラス
            this._connectInfoWorkAcs = new ConnectInfoWorkAcs();

            this._connectInfoWorkTable = new Hashtable();

            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            this._supplierAcs = new SupplierAcs();
            this._indexBuf = -2;
            this._supplierDic = new Dictionary<int, Supplier>();
            ReadSupplierName();

            this._controlScreenSkin = new ControlScreenSkin();                                //スキンをロード
            this._controlScreenSkin.LoadSkin();
            this._controlScreenSkin.SettingScreenSkin(this);
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

        // 仕入先
        private SupplierAcs _supplierAcs;
        private Dictionary<int, Supplier> _supplierDic;

        private ConnectInfoWork _connectInfoWork;
        private ConnectInfoWorkAcs _connectInfoWorkAcs;

        // 比較用Clone
        private ConnectInfoWork _connectInfoWorkCheckClone;
        // 保存比較用Clone
        private ConnectInfoWork _connectInfoWorkClone;
        private ControlScreenSkin _controlScreenSkin;                           // スキン設定用クラス

        // HashTable
        private Hashtable _connectInfoWorkTable;

        private int _indexBuf;
        private string _enterpriseCode;

        private const string ASSEMBLY_ID = "PMKHN09711U";

        // FrameのView用Grid列のKEY情報 (HeaderのTitle部となります)
        private const string DELETE_DATE = "削除日";
        private const string VIEW_SUPPLIERCD = "仕入先コード";
        private const string VIEW_SUPPLIERSNM = "仕入先略称";
        private const string VIEW_CONNECTUSERID = "ユーザーコード";
        private const string VIEW_CONNECTPASSWORD = "パスワード";
        private const string VIEW_DOMAIN = "ドメイン";
        private const string VIEW_DAIHATSUORDREDIV = "発注用アドレス";
        private const string VIEW_PROTOCOL = "プロトコル";
        private const string VIEW_TIMEOUT = "タイムアウト";

        //GUID
        private const string VIEW_FILEHEADERGUID = "Guid";

        // View用Gridに表示させるテーブル名
        private const string VIEW_TABLE = "VIEW_TABLE";

        // 編集モード
        private const string INSERT_MODE = "新規モード";
        private const string UPDATE_MODE = "更新モード";
        private const string DELETE_MODE = "削除モード";
        #endregion

        #region Main Entry Point
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            System.Windows.Forms.Application.Run(new PMKHN09711UA());
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
        /// <br>Programer  : 黄興貴</br>
        /// <br>Date	   : 2012/12/15</br>
        /// <br>管理番号   : 10805731-00</br>
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
            connectInfoWorkToDataSet(connectInfoWork, this.DataIndex);
            return 0;
        }


        /// <summary>
        /// 排他処理
        /// </summary>
        /// <param name="status">TATUS</param>
        /// <remarks>
        /// <br>Note       : 排他処理を行います</br>
        /// <br>Programer  : 黄興貴</br>
        /// <br>Date	   : 2012/12/15</br>
        /// <br>管理番号   : 10805731-00</br>
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
            else
            { 
                // なし
            }
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// グリッド列外観情報取得処理
        /// </summary>
        /// <returns>グリッド列外観情報格納Hashtable</returns>
        /// <remarks>
        /// <br>Note       : 各列の外見を設定するクラスを格納したHashtableを取得します。</br>
        /// <br>Programer  : 黄興貴</br>
        /// <br>Date	   : 2012/12/15</br>
        /// <br>管理番号   : 10805731-00</br>
        /// <br></br>
        /// </remarks>
        public System.Collections.Hashtable GetAppearanceTable()
        {
            Hashtable appearanceTable = new Hashtable();

            // 削除日
            appearanceTable.Add(DELETE_DATE, new GridColAppearance(MGridColDispType.DeletionDataBoth, ContentAlignment.MiddleCenter, "", Color.Red));
            // GUID
            appearanceTable.Add(VIEW_FILEHEADERGUID, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
            // 仕入先コード
            appearanceTable.Add(VIEW_SUPPLIERCD, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            // 仕入先略称
            appearanceTable.Add(VIEW_SUPPLIERSNM, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // ユーザーコード
            appearanceTable.Add(VIEW_CONNECTUSERID, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // パスワード
            appearanceTable.Add(VIEW_CONNECTPASSWORD, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // ドメイン
            appearanceTable.Add(VIEW_DOMAIN, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // プロトコル
            appearanceTable.Add(VIEW_PROTOCOL, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 発注用アドレス
            appearanceTable.Add(VIEW_DAIHATSUORDREDIV, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // タイムアウト
            appearanceTable.Add(VIEW_TIMEOUT, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));          

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
        /// <br>Programer	: 黄興貴</br>
        /// <br>Date		: 2012/12/15</br>
        /// <br>管理番号    : 10805731-00</br>
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
        /// <br>Programer  : 黄興貴</br>
        /// <br>Date	   : 2012/12/15</br>
        /// <br>管理番号   : 10805731-00</br>
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
        /// <br>Programer  : 黄興貴</br>
        /// <br>Date	   : 2012/12/15</br>
        /// <br>管理番号   : 10805731-00</br>
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
            else
            {
                // なし
            }

            int status = 0;
            ArrayList connectInfoWorkAcsList = null;
      
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Clear();
            this._connectInfoWorkTable.Clear();
            // 全検索
            status = this._connectInfoWorkAcs.SearchAll(out connectInfoWorkAcsList, this._enterpriseCode);
            totalCount = connectInfoWorkAcsList.Count;

            switch (status)
            {
                case (int)ConstantManagement.MethodResult.ctFNC_NORMAL:
                    {
                        int index = 0;

                        foreach (ConnectInfoWork connectInfoWork in connectInfoWorkAcsList)
                        {

                            // オートバックス設定オブジェクトデータセット展開処理
                            connectInfoWorkToDataSet(connectInfoWork, index);
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
                            "PMKHN09711UA",							// アセンブリID
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
        /// <br>Programer  : 黄興貴</br>
        /// <br>Date	   : 2012/12/15</br>
        /// <br>管理番号   : 10805731-00</br>
        /// <br></br>
        /// </remarks>
        private void connectInfoWorkToDataSet(ConnectInfoWork connectInfoWork, int index)
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
            else
            {
                // なし
            }
            if (connectInfoWork.LogicalDeleteCode == 0)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][DELETE_DATE] = "";
            }
            else
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][DELETE_DATE] = TDateTime.DateTimeToString("ggYY/MM/DD", connectInfoWork.UpdateDateTime);
            }

            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_FILEHEADERGUID] = connectInfoWork.FileHeaderGuid;
            string supplierCdStr = Convert.ToString(connectInfoWork.SupplierCd);
            supplierCdStr = supplierCdStr.PadLeft(6,'0');
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SUPPLIERCD] = supplierCdStr;
            string supplierSnm = string.Empty;
            if (ReadSupplierName(connectInfoWork.SupplierCd, out supplierSnm))
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SUPPLIERSNM] = supplierSnm;
            }
            else
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SUPPLIERSNM] = string.Empty;
            }
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CONNECTUSERID] = connectInfoWork.ConnectUserId;
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CONNECTPASSWORD] = connectInfoWork.ConnectPassword;
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_DOMAIN] = connectInfoWork.OrderUrl;
            if (connectInfoWork.DaihatsuOrdreDiv == 0)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PROTOCOL] = "HTTP";
            }
            else if (connectInfoWork.DaihatsuOrdreDiv == 1)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PROTOCOL] = "HTTPS";
            }
            else
            {
                // なし
            }
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_DAIHATSUORDREDIV] = connectInfoWork.StockCheckUrl;
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_TIMEOUT] = connectInfoWork.LoginTimeoutVal;

            // インスタンステーブルにもセットする
            if (this._connectInfoWorkTable.ContainsKey(connectInfoWork.FileHeaderGuid) == true)
            {
                this._connectInfoWorkTable.Remove(connectInfoWork.FileHeaderGuid);
            }
            else
            {
                // なし
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
        /// <br>Programer  : 黄興貴</br>
        /// <br>Date	   : 2012/12/15</br>
        /// <br>管理番号   : 10805731-00</br>
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
        /// <br>Programmer : 黄興貴</br>
        /// <br>Date       : 2012/12/15</br>
        /// <br>管理番号   : 10805731-00</br>
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
                else
                {
                    // なし
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
        /// <br>Programmer : 黄興貴</br>
        /// <br>Date       : 2012/12/15</br>
        /// <br>管理番号   : 10805731-00</br>
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
        /// <br>Programmer : 黄興貴</br>
        /// <br>Date       : 2012/12/15</br>
        /// <br>管理番号   : 10805731-00</br>
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
                    this.tNedit_SupplierCd.Enabled = false;

                    // パネル
                    this.tNedit_SupplierCd.Enabled = false;
                    this.uButton_SupplierGuide.Enabled = false;
                    this.ConnectUserId_tEdit.Enabled = true;
                    this.ConnectPassword_tEdit.Enabled = true;
                    this.Protocol_tComboEditor.Enabled = true;
                    this.TimeOut_tEdit.Enabled = true;
                    this.Domain_tEdit.Enabled = true;
                    this.OrderAddress_tEdit.Enabled = true;
                    this.tEdit_SupplierSnm.Enabled = false;
                    break;

                // 2:削除
                case 2:

                    // ボタン
                    this.Delete_Button.Visible = true;
                    this.Revive_Button.Visible = true;
                    this.Ok_Button.Visible = false;
                    this.Cancel_Button.Visible = true;

                    // パネル
                    this.tNedit_SupplierCd.Enabled = false;
                    this.uButton_SupplierGuide.Enabled = false;
                    this.ConnectUserId_tEdit.Enabled = false;
                    this.ConnectPassword_tEdit.Enabled = false;
                    this.Protocol_tComboEditor.Enabled = false;
                    this.TimeOut_tEdit.Enabled = false;
                    this.Domain_tEdit.Enabled = false;
                    this.OrderAddress_tEdit.Enabled = false;
                    this.tEdit_SupplierSnm.Enabled = false;
                    break;
            }
        }

        /// <summary>
        /// データセット列情報構築処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : データセットの列情報を構築します。
        ///					 データセットの列情報がフレームのビュー用グリッドの列になります</br>
        /// <br>Programer  : 黄興貴</br>
        /// <br>Date	   : 2012/12/15</br>
        /// <br>管理番号   : 10805731-00</br>
        /// <br></br>
        /// </remarks>
        private void DataSetColumnConstruction()
        {
            DataTable connectInfoWorkTable = new DataTable(VIEW_TABLE);

            // Addを行う順番が、列の表示順位となります。
            connectInfoWorkTable.Columns.Add(DELETE_DATE, typeof(string));                 //削除日
            connectInfoWorkTable.Columns.Add(VIEW_SUPPLIERCD, typeof(string));             //仕入先コード
            connectInfoWorkTable.Columns.Add(VIEW_SUPPLIERSNM, typeof(string));            //仕入先略称
            connectInfoWorkTable.Columns.Add(VIEW_CONNECTPASSWORD, typeof(string));        //パスワード
            connectInfoWorkTable.Columns.Add(VIEW_CONNECTUSERID, typeof(string));        　//ユーザーコード
            connectInfoWorkTable.Columns.Add(VIEW_PROTOCOL, typeof(string));               //プロトコル
            connectInfoWorkTable.Columns.Add(VIEW_TIMEOUT, typeof(string));                //タイムアウト
            connectInfoWorkTable.Columns.Add(VIEW_DOMAIN, typeof(string));                 //ドメイン
            connectInfoWorkTable.Columns.Add(VIEW_DAIHATSUORDREDIV, typeof(string));       //発注用アドレス

            connectInfoWorkTable.Columns.Add(VIEW_FILEHEADERGUID, typeof(Guid));           //GUID

            this.Bind_DataSet.Tables.Add(connectInfoWorkTable);
        }

        /// <summary>
        /// 画面再構築処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : モードに基づいて画面を再構築します。</br>
        /// <br>Programmer : 黄興貴</br>
        /// <br>Date       : 2012/12/15</br>
        /// <br>管理番号   : 10805731-00</br>
        /// <br></br>
        /// </remarks>
        private void ScreenReconstruction()
        {
            if (this.DataIndex < 0)
            {
                ConnectInfoWork connectInfoWork = new ConnectInfoWork();
                this._connectInfoWorkClone = connectInfoWork.Clone();
                this._indexBuf = this._dataIndex;
                // 画面情報を比較用クローンにコピーします
                ScreenToconnectInfoWork(ref this._connectInfoWorkClone);

                //　新規モード
                this.Mode_Label.Text = INSERT_MODE;
                this.tNedit_SupplierCd.Focus();
            }
            else
            {
                Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this._dataIndex][VIEW_FILEHEADERGUID];
                ConnectInfoWork connectInfoWork = (ConnectInfoWork)this._connectInfoWorkTable[guid];
                //画面展開処理
                RecordToScreen(connectInfoWork);

                if (connectInfoWork.LogicalDeleteCode == 0)
                {
                    // 更新モード
                    this.Mode_Label.Text = UPDATE_MODE;

                    // 画面入力許可制御処理
                    ScreenInputPermissionControl(1);

                    // クローン作成
                    this._connectInfoWorkClone = connectInfoWork;

                    this.ConnectPassword_tEdit.Focus();
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
        /// 画面クリア処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : 画面をクリアします。</br>
        /// <br>Programmer : 黄興貴</br>
        /// <br>Date       : 2012/12/15</br>
        /// <br>管理番号   : 10805731-00</br>
        /// <br></br>
        /// </remarks>
        private void ScreenClear()
        {
            this.tNedit_SupplierCd.Text = "";
            this.tEdit_SupplierSnm.Text = "";
            this.ConnectUserId_tEdit.Text = "";
            this.ConnectPassword_tEdit.Text = "";
            this.Protocol_tComboEditor.SelectedIndex = 0;
            this.TimeOut_tEdit.Text = "";
            this.Domain_tEdit.Text = "";
            this.OrderAddress_tEdit.Text = "";
            this.tNedit_SupplierCd.Focus();

            // ボタン
            this.Ok_Button.Visible = true;
            this.Cancel_Button.Visible = true;
            this.Revive_Button.Visible = false;
            this.Delete_Button.Visible = false;

            // パネル
            this.tNedit_SupplierCd.Enabled = true;
            this.uButton_SupplierGuide.Enabled = true;
            this.ConnectUserId_tEdit.Enabled = true;
            this.ConnectPassword_tEdit.Enabled = true;
            this.Protocol_tComboEditor.Enabled = true;
            this.TimeOut_tEdit.Enabled = true;
            this.Domain_tEdit.Enabled = true;
            this.OrderAddress_tEdit.Enabled = true;
            this.tEdit_SupplierSnm.Enabled = false;
        }

        /// <summary>
        /// 接続先情報設定マスタ画面展開処理
        /// </summary>
        /// <param name="connectInfoWork">接続先情報設定オブジェクト</param>
        /// <remarks>
        /// <br>Note       : オブジェクトから画面にデータを展開します。</br>
        /// <br>Programmer : 黄興貴</br>
        /// <br>Date       : 2012/12/15</br>
        /// <br>管理番号   : 10805731-00</br>
        /// <br></br>
        /// </remarks>
        private void RecordToScreen(ConnectInfoWork connectInfoWork)
        {
            string supplierCd = string.Empty;
            string supplierSnm = string.Empty;
            this.tNedit_SupplierCd.Text = Convert.ToString(connectInfoWork.SupplierCd);
            supplierCd = this.tNedit_SupplierCd.Text;
            if (!string.IsNullOrEmpty(supplierCd))
            {
                // 仕入先名称を取得
                if (ReadSupplierName(connectInfoWork.SupplierCd,out supplierSnm))
                {
                    this.tEdit_SupplierSnm.Text = supplierSnm;
                    this.ConnectPassword_tEdit.Focus();
                }
                else
                {
                    this.tNedit_SupplierCd.Text = string.Empty;
                    this.tEdit_SupplierSnm.Text = supplierSnm;
                    this.tNedit_SupplierCd.Focus();
                }
            }
            else
            { 
                //なし
            }
            this.ConnectUserId_tEdit.Text = connectInfoWork.ConnectUserId;
            this.ConnectPassword_tEdit.Value = connectInfoWork.ConnectPassword;
            this.Protocol_tComboEditor.SelectedIndex = connectInfoWork.DaihatsuOrdreDiv;
            this.TimeOut_tEdit.Value = connectInfoWork.LoginTimeoutVal;
            this.Domain_tEdit.Value = connectInfoWork.OrderUrl;
            this.OrderAddress_tEdit.Value = connectInfoWork.StockCheckUrl;
        }

        /// <summary>
        /// 保存処理(SaveconnectInfoWork())
        /// </summary>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note　　　  : 保存処理を行います。</br>
        /// <br>Programmer  : 黄興貴</br>
        /// <br>Date        : 2012/12/15</br>
        /// <br>管理番号    : 10805731-00</br>
        /// </remarks>
        private bool SaveconnectInfoWork()
        {
            bool result = false;

            //画面データ入力チェック処理
            bool chkSt = ScreenDataCheck();
            if (!chkSt)
            {
                return chkSt;
            }
            else
            {
                // なし
            }

            ConnectInfoWork connectInfoWork = null;

            if (this.DataIndex >= 0)
            {
                Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this._dataIndex][VIEW_FILEHEADERGUID];
                connectInfoWork = (ConnectInfoWork)this._connectInfoWorkTable[guid];
            }
            else
            {
                // なし
            }

            // 画面にデータを取得
            ScreenToconnectInfoWork(ref connectInfoWork);
            // 保存処理
            int status = this._connectInfoWorkAcs.Write(ref connectInfoWork);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        this.ScreenClear();
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE:
                    {
                        TMsgDisp.Show(
                            this, 								 // 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,  // エラーレベル
                            ASSEMBLY_ID,						 // アセンブリＩＤまたはクラスＩＤ
                            "このコードは既に使用されています。",// 表示するメッセージ
                            0, 									 // ステータス値
                            MessageBoxButtons.OK);				 // 表示するボタン
                        this.tNedit_SupplierCd.Focus();
                        this.tNedit_SupplierCd.Clear();
                        this.tEdit_SupplierSnm.Clear();
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
                        else
                        {
                            // なし
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
                        else
                        {
                            // なし
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
            connectInfoWorkToDataSet(connectInfoWork, this.DataIndex);

            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }
            else
            {
                // なし
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
            else
            {
                // なし
            }
            // 新規登録時
            if (this.Mode_Label.Text.Equals(INSERT_MODE))
            {
                this.ScreenClear();
            }
            else
            {
                // なし
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
        /// <br>Programmer  : 黄興貴</br>
        /// <br>Date        : 2012/12/15</br>
        /// <br>管理番号    : 10805731-00</br>
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

                    control.Focus();
                }
                else
                { 
                    // なし
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
        /// <br>Programmer : 黄興貴</br>
        /// <br>Date       : 2012/12/15</br>
        /// <br>管理番号   : 10805731-00</br>
        /// <br></br>
        /// </remarks>
        private bool ScreenDataCheck(ref Control control, ref string message)
        {
            // 仕入先コード
            if (string.IsNullOrEmpty(this.tNedit_SupplierCd.Text.Trim()))
            {
                control = this.tNedit_SupplierCd;
                message = "仕入先コードを入力してください。";
                return (false);
            }
            else
            {
                int supplierCd = this.tNedit_SupplierCd.GetInt();
                string supplierSnm = string.Empty;
                if (ReadSupplierName(supplierCd, out supplierSnm))
                {
                    this.tEdit_SupplierSnm.Text = supplierSnm;
                }
                else
                {
                    this.tNedit_SupplierCd.Clear();
                    this.tEdit_SupplierSnm.Clear();
                    this.tNedit_SupplierCd.Focus();
                    TMsgDisp.Show(
                        this, 								    // 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_INFO,            // エラーレベル
                        ASSEMBLY_ID,						    // アセンブリＩＤまたはクラスＩＤ
                        "該当する仕入先コードが存在しません。", // 表示するメッセージ
                        0, 									    // ステータス値
                        MessageBoxButtons.OK);				    // 表示するボタン
                    return (false);
                }
            }
            // パスワード
            if (string.IsNullOrEmpty(this.ConnectPassword_tEdit.Text.Trim()))
            {
                control = this.ConnectPassword_tEdit;
                message = "パスワードを入力してください。";
                return (false);
            }
            else
            {
                // なし
            }
            // ユーザーコード
            if (string.IsNullOrEmpty(this.ConnectUserId_tEdit.Text.Trim()))
            {
                control = this.ConnectUserId_tEdit;
                message = "ユーザーコードを入力してください。";
                return (false);
            }
            else
            {
                // なし
            }
            // タイムアウト
            if (string.IsNullOrEmpty(this.TimeOut_tEdit.Text.Trim()))
            {
                control = this.TimeOut_tEdit;
                message = "タイムアウトを入力してください。";
                return (false);
            }
            else
            {
                // なし
            }
            // ドメイン
            if (string.IsNullOrEmpty(this.Domain_tEdit.Text.Trim()))
            {
                control = this.Domain_tEdit;
                message = "ドメインを入力してください。";
                return (false);
            }
            else
            {
                // なし
            }
            // 発注用アドレス
            if (string.IsNullOrEmpty(this.OrderAddress_tEdit.Text.Trim()))
            {
                control = this.OrderAddress_tEdit;
                message = "発注用アドレスを入力してください。";
                return (false);
            }
            else
            {
                // なし
            }
            return true;
        }

        /// <summary>
        /// 接続先情報設定クラス格納処理
        /// </summary>
        /// <param name="connectInfoWork">接続先情報設定オブジェクト</param>
        /// <remarks>
        /// <br>Note       : 画面情報から接続先情報設定オブジェクトにデータを格納します。</br>
        /// <br>Programmer : 黄興貴</br>
        /// <br>Date       : 2012/12/15</br>
        /// <br>管理番号   : 10805731-00</br>
        /// <br></br>
        /// </remarks>
        private void ScreenToconnectInfoWork(ref ConnectInfoWork connectInfoWork)
        {
            if (connectInfoWork == null)
            {
                // 新規の場合
                connectInfoWork = new ConnectInfoWork();
            }
            else
            {
                // なし
            }

            // 企業コード
            connectInfoWork.EnterpriseCode = this._enterpriseCode;

            connectInfoWork.SupplierCd = this.tNedit_SupplierCd.GetInt();
            connectInfoWork.ConnectUserId = this.ConnectUserId_tEdit.Text;
            connectInfoWork.ConnectPassword = this.ConnectPassword_tEdit.Text;
            connectInfoWork.OrderUrl = this.Domain_tEdit.Text;
            connectInfoWork.DaihatsuOrdreDiv = this.Protocol_tComboEditor.SelectedIndex;
            connectInfoWork.StockCheckUrl = this.OrderAddress_tEdit.Text;
            // タイムアウト 
            int timeOut_tEdit = 0;
            int.TryParse(this.TimeOut_tEdit.Text.Trim(), out timeOut_tEdit);
            connectInfoWork.LoginTimeoutVal = timeOut_tEdit;
        }

        /// <summary>
        /// FormClose イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : FormClose イベント</br>
        /// <br>Programmer : 黄興貴</br>
        /// <br>Date       : 2012/12/15</br>
        /// <br>管理番号   : 10805731-00</br>
        /// <br></br>
        /// </remarks>
        private void PMKHN09711UA_FormClosing(object sender, FormClosingEventArgs e)
        {
            this._indexBuf = -2;

            if (CanClose == false)
            {
                e.Cancel = true;
                this.Hide();
            }
            else
            {
                // なし
            }
        }

        /// <summary>
        /// ChangeFocus イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : ChangeFocus イベント</br>
        /// <br>Programmer : 黄興貴</br>
        /// <br>Date       : 2012/12/15</br>
        /// <br>管理番号   : 10805731-00</br>
        /// <br></br>
        /// </remarks>
        private void tRetKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            // 画面を閉じるの場合　仕入先名称取得しない
            if (e.PrevCtrl == null || e.NextCtrl.Name == "Cancel_Button")
            {
                return;
            }
            else if (e.PrevCtrl.Name == "tNedit_SupplierCd")
            {
                string supplierCd = this.tNedit_SupplierCd.Text.Trim();
                if (string.IsNullOrEmpty(supplierCd))
                {
                    this.tEdit_SupplierSnm.Clear();
                }
                else
                {
                    // 新規
                    if (this._dataIndex < 0)
                    {
                        // モード変更について
                        if (!this.ModeChangeProc(supplierCd))
                        {
                            this.tNedit_SupplierCd.Text = "";
                            e.NextCtrl = this.tNedit_SupplierCd;
                        }
                        else
                        {
                            int supplierCdFN = this.tNedit_SupplierCd.GetInt();
                            string supplierSnm = string.Empty;

                            // 仕入先名称を取得
                            if (ReadSupplierName(supplierCdFN, out supplierSnm))
                            {
                                this.tEdit_SupplierSnm.Text = supplierSnm;
                                e.NextCtrl = this.ConnectPassword_tEdit;
                            }
                            else
                            {
                                TMsgDisp.Show(
                                    this, 								    // 親ウィンドウフォーム
                                    emErrorLevel.ERR_LEVEL_INFO,            // エラーレベル
                                    ASSEMBLY_ID,						    // アセンブリＩＤまたはクラスＩＤ
                                    "該当する仕入先コードが存在しません。", // 表示するメッセージ
                                    0, 									    // ステータス値
                                    MessageBoxButtons.OK);				    // 表示するボタン
                                this.tNedit_SupplierCd.Text = string.Empty;
                                this.tEdit_SupplierSnm.Text = supplierSnm;
                                e.NextCtrl = this.tNedit_SupplierCd;
                            }
                        }
                    }
                    else
                    {
                        // なし
                    }
                }
                return;
            }
            else if (e.PrevCtrl.Name == "TimeOut_tEdit")
            {
                if (!string.IsNullOrEmpty(this.TimeOut_tEdit.Text))
                {
                    int timeOutInt = Convert.ToInt32(this.TimeOut_tEdit.Text);
                    this.TimeOut_tEdit.Text = Convert.ToString(timeOutInt);
                }
                else
                { 
                    //　なし
                }
            }
            else
            {
                return;
            }
        }

        /// <summary>
        /// 仕入先名称ディクショナリ取得
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 仕入先名称ディクショナリ取得</br>
        /// <br>Programmer : 黄興貴</br>
        /// <br>Date       : 2012/12/15</br>
        /// <br>管理番号   : 10805731-00</br>
        /// <br></br>
        /// </remarks>
        private void ReadSupplierName()
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            ArrayList supplierLt = null;
            status = this._supplierAcs.SearchAll(out supplierLt, this._enterpriseCode);
            if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                foreach (Supplier supplierInfo in supplierLt)
                {
                    if (supplierInfo.LogicalDeleteCode == 0)
                    {
                        this._supplierDic.Add(supplierInfo.SupplierCd, supplierInfo);
                    }
                }
            }
            else
            {
                // なし
            }
        }

        /// <summary>
        /// 仕入先名称取得
        /// </summary>
        /// <param name="supplierCd">仕入先コード</param>
        /// <param name="supplierSnm">仕入先名称</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 仕入先名称取得</br>
        /// <br>Programmer : 黄興貴</br>
        /// <br>Date       : 2012/12/15</br>
        /// <br>管理番号   : 10805731-00</br>
        /// <br></br>
        /// </remarks>
        private bool ReadSupplierName(int supplierCd, out string supplierSnm)
        {
            if (_supplierDic.ContainsKey(supplierCd))
            {
                supplierSnm = _supplierDic[supplierCd].SupplierSnm.Trim();
                return true;
            }
            else
            {
                supplierSnm = string.Empty;
                return false;
            }
        }
       
        /// <summary>
        /// 売価優先設定チェックリスト
        /// </summary>
        /// <remarks>
        /// <br>Note        : 売価優先設定チェックリスト</br>
        /// <br>Programmer  : 黄興貴</br>
        /// <br>Date        : 2012/12/15</br>
        /// <br>管理番号    : 10805731-00</br>
        /// </remarks>
        private void PrcPrStADDValue()
        {
            this._connectInfoWorkCheckClone.SupplierCd = this.tNedit_SupplierCd.GetInt();
            this._connectInfoWorkCheckClone.ConnectPassword = this.ConnectPassword_tEdit.Text;
            this._connectInfoWorkCheckClone.ConnectUserId = this.ConnectUserId_tEdit.Text;
            this._connectInfoWorkCheckClone.OrderUrl = this.Domain_tEdit.Text;
            this._connectInfoWorkCheckClone.DaihatsuOrdreDiv = this.Protocol_tComboEditor.SelectedIndex;
            this._connectInfoWorkCheckClone.StockCheckUrl = this.OrderAddress_tEdit.Text;
            // タイムアウト 
            int timeOut_tEdit = 0;
            int.TryParse(this.TimeOut_tEdit.Text.Trim(), out timeOut_tEdit);
            this._connectInfoWorkCheckClone.LoginTimeoutVal = timeOut_tEdit;
        }

        /// <summary>
        /// モード変更処理
        /// </summary>
        /// <param name="theSupplierCd">仕入先コード</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note        : モード変更処理</br>
        /// <br>Programmer  : 黄興貴</br>
        /// <br>Date        : 2012/12/15</br>
        /// <br>管理番号    : 10805731-00</br>
        /// </remarks>
        private bool ModeChangeProc(string theSupplierCd)
        {
            string msg = "入力された接続先情報は既に登録されています。\n編集を行いますか？";        
           
            // 仕入先コード
            int supplierCd = Convert.ToInt32(theSupplierCd.ToString());

            for (int i = 0; i < this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Count; i++)
            {
                // データセットと比較
                int dsSupplierCd = Convert.ToInt32(this.Bind_DataSet.Tables[VIEW_TABLE].Rows[i][VIEW_SUPPLIERCD]);
                if (supplierCd == dsSupplierCd)
                {
                    // 入力コードがデータセットに存在する場合
                    if (!string.IsNullOrEmpty((string)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[i][DELETE_DATE]))
                    {
                        // 論理削除
                        TMsgDisp.Show(this, 					    // 親ウィンドウフォーム
                              emErrorLevel.ERR_LEVEL_INFO,          // エラーレベル
                              ASSEMBLY_ID,						    // アセンブリＩＤまたはクラスＩＤ
                              "入力されたコードの接続先設定情報は既に削除されています。",// 表示するメッセージ
                              0, 									// ステータス値
                              MessageBoxButtons.OK);				// 表示するボタン
                        this.tEdit_SupplierSnm.Text = string.Empty;
                        return false;
                    }
                    else
                    {
                        // なし
                    }

                    DialogResult res = TMsgDisp.Show(
                        this,                                   // 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_INFO,            // エラーレベル
                        ASSEMBLY_ID,                            // アセンブリＩＤまたはクラスＩＤ
                        msg,                                    // 表示するメッセージ
                        0,                                      // ステータス値
                        MessageBoxButtons.YesNo);               // 表示するボタン
                    switch (res)
                    {
                        case DialogResult.Yes:
                            {
                                // 画面再描画
                                this._dataIndex = i;
                                ScreenReconstruction();
                                break;
                            }
                        case DialogResult.No:
                            {
                                // キャンペーンコードのクリア
                                this.tNedit_SupplierCd.Clear();
                                this.tEdit_SupplierSnm.Text = string.Empty;
                                this.tNedit_SupplierCd.Focus();
                                return false;
                            }
                    }
                    return true;
                }
            }
            return true;
        }
        #endregion ----- Private Method -----

        #region ----- Control Events -----
        /// <summary>
        ///	Form.Load イベント(PMKHN09711UA)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: ユーザーがフォームを読み込むときに発生します。</br>
        /// <br>Programmer  : 黄興貴</br>
        /// <br>Date        : 2012/12/15</br>
        /// <br>管理番号    : 10805731-00</br>
        /// <br></br>
        /// </remarks>
        private void PMKHN09711UA_Load(object sender, EventArgs e)
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

            // ガイドボタンのアイコン設定
            this.uButton_SupplierGuide.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
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
        /// <br>Programmer : 黄興貴</br>
        /// <br>Date       : 2012/12/15</br>
        /// <br>管理番号   : 10805731-00</br>
        /// <br></br>
        /// </remarks>
        private void Initial_Timer_Tick(object sender, EventArgs e)
        {
            Initial_Timer.Enabled = false;
            ScreenReconstruction();
            PrcPrStADDValue();
        }

        /// <summary>
        ///	Form.VisibleChanged イベント(PMKHN09711UA)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: フォームの表示・非表示が切り替えられ
        ///					  たときに発生します。</br>
        /// <br>Programmer : 黄興貴</br>
        /// <br>Date       : 2012/12/15</br>
        /// <br>管理番号   : 10805731-00</br>
        /// <br></br>
        /// </remarks>
        private void PMKHN09711UA_VisibleChanged(object sender, EventArgs e)
        {
            // 自分自身が非表示になった場合は以下の処理をキャンセルする。
            if (this.Visible == false)
            {
                this.Owner.Activate();
                return;
            }
            else
            {
                // なし
            }

            // 自分自身が非表示になった場合、
            // またはターゲットレコード(Index)が変わっていない場合は以下の処理をキャンセルする
            if (this._indexBuf == this._dataIndex)
            {
                return;
            }
            else
            {
                // なし
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
        /// <br>Programmer : 黄興貴</br>
        /// <br>Date       : 2012/12/15</br>
        /// <br>管理番号   : 10805731-00</br>
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
            else
            {
                // なし
            }

            if (!SaveconnectInfoWork())
            {
                return;
            }
            else
            {
                this.tNedit_SupplierCd.Focus();
            }
        }

        /// <summary>
        /// Control.Click イベント(Revive_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　 : 復活ボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer : 黄興貴</br>
        /// <br>Date       : 2012/12/15</br>
        /// <br>管理番号   : 10805731-00</br>
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
            else
            {
                // なし
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
                        connectInfoWorkToDataSet(connectInfoWork, this._dataIndex);
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
            else
            {
                // なし
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
        /// <br>Programmer : 黄興貴</br>
        /// <br>Date       : 2012/12/15</br>
        /// <br>管理番号   : 10805731-00</br>
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
            else
            {
                // なし
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
            else
            {
                // なし
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
        /// <br>Programmer : 黄興貴</br>
        /// <br>Date       : 2012/12/15</br>
        /// <br>管理番号   : 10805731-00</br>
        /// <br></br>
        /// </remarks>
        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            // 削除モード・参照モード以外の場合は保存確認処理を行う
            if (this.Mode_Label.Text != DELETE_MODE)
            {
                // 画面のデータを取得する
                ConnectInfoWork connectInfoWork = new ConnectInfoWork();

                ScreenToconnectInfoWork(ref connectInfoWork);

                // 画面情報と起動時のクローンと比較し変更を監視する
                if (!((this._connectInfoWorkClone.ConnectPassword == connectInfoWork.ConnectPassword)
                   && (this._connectInfoWorkClone.ConnectUserId == connectInfoWork.ConnectUserId)
                   && (this._connectInfoWorkClone.OrderUrl == connectInfoWork.OrderUrl)
                   && (this._connectInfoWorkClone.DaihatsuOrdreDiv == connectInfoWork.DaihatsuOrdreDiv)
                   && (this._connectInfoWorkClone.StockCheckUrl == connectInfoWork.StockCheckUrl)
                   && (this._connectInfoWorkClone.LoginTimeoutVal == connectInfoWork.LoginTimeoutVal)
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
                                if (!SaveconnectInfoWork())
                                {
                                    return;
                                }
                                else
                                {
                                    this.tNedit_SupplierCd.Focus();
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
        /// GuideClick イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　 : GuideClick イベント</br>
        /// <br>Programmer : 黄興貴</br>
        /// <br>Date       : 2012/12/15</br>
        /// <br>管理番号   : 10805731-00</br>
        /// <br></br>
        /// </remarks>
        private void uButton_SupplierGuide_Click(object sender, EventArgs e)
        {
            // 仕入先ガイド表示
            int status = 0;
            Supplier supplierInfo;
            string sectionCd = string.Empty;
            string supplierCdBak = this.tNedit_SupplierCd.Text;
            string supplierNmBak = this.tEdit_SupplierSnm.Text;

            // ガイド表示
            status = this._supplierAcs.ExecuteGuid(out supplierInfo, this._enterpriseCode, sectionCd);
            if (status == 0)
            {
                string supplierCdStr = string.Empty;
                supplierCdStr = Convert.ToString(supplierInfo.SupplierCd);
                // モード変更について
                if (!this.ModeChangeProc(supplierCdStr))
                {
                    this.tNedit_SupplierCd.Text = "";
                    this.tNedit_SupplierCd.Focus();
                }
                else
                {
                    this.tEdit_SupplierSnm.Text = supplierInfo.SupplierSnm;
                    this.tNedit_SupplierCd.Text = Convert.ToString(supplierInfo.SupplierCd);
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(supplierCdBak))
                {
                    this.tNedit_SupplierCd.Text = supplierCdBak;
                    this.tEdit_SupplierSnm.Text = supplierNmBak;
                }
                else
                {
                    this.tNedit_SupplierCd.Text = "";
                    this.tEdit_SupplierSnm.Text = "";
                }
                return;
            }
        }
       #endregion ----- Control Events -----
    }
}

