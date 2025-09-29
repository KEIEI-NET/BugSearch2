//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : Tablet常駐処理
// プログラム概要   : Tablet常駐処理を行います。
//----------------------------------------------------------------------------//
//                (c)Copyright  2013 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10902622-01 作成担当 : 高峰
// 作 成 日  2013/05/29  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 修正内容　障害報告 #37530の対応　               　      
// 管理番号  10902622-01 作成担当 : songg                                    
// 作 成 日  2013/07/01  作成内容 : 【ポップアップ】売上登録後のポップアップ画面下部に、何も表示されていない空白部分が表示されています
//----------------------------------------------------------------------//
// 修正内容　障害報告 #39489の対応　               　      
// 管理番号  10902622-01 作成担当 : 吉岡
// 作 成 日  2013/08/01  作成内容 : 障害報告 #39489の対応
//----------------------------------------------------------------------//
// 管理番号  10902622-01 作成担当 : 吉岡
// 作 成 日  2013/08/07  修正内容 : 再起動対応
//----------------------------------------------------------------------------//
// Update Note     : Redmine#39972 
// 管理番号        : 10902622-01
// Programmer      : 吉岡
// Date            : 2013/08/16
//----------------------------------------------------------------------------//
// 管理番号  10902622-01 作成担当 : 三戸
// 作 成 日  2013/08/23  修正内容 : 各処理非同期対応
//----------------------------------------------------------------------------//
// 管理番号  10902622-01 作成担当 : 湯上
// 作 成 日  2013/08/26  修正内容 : Redmine#40121 データ登録時WebSync通知対応
//----------------------------------------------------------------------------//
// 管理番号  10902622-01 作成担当 : 湯上
// 作 成 日  2013/08/30  修正内容 : Redmine#40121 データ登録時WebSync通知対応
//----------------------------------------------------------------------------//
// 管理番号  10902622-01 作成担当 : 湯上
// 作 成 日  2013/09/02  修正内容 : Redmine#40121 得意先検索時WebSync通知対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 吉岡
// 作 成 日  2013/10/08  修正内容 : 山形部品速度遅延対応 SCM仕掛一覧№10579
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 湯上
// 作 成 日  2013/10/08  修正内容 : 山形部品速度遅延対応 SCM仕掛一覧№10579
//----------------------------------------------------------------------------//
// 管理番号  11070091-00 作成担当 : zhujw
// 作 成 日  2014/06/11  修正内容 : RedMine#42648 Windows8.1動作検証結果_常駐ポップアップ背景が白抜き表示される場合がある 修正
//----------------------------------------------------------------------------//

using System.Windows.Forms;
using Broadleaf.Application.Common;
using System.Collections.Generic;
using Broadleaf.Application.Controller;
using System.Data;
using System;
using Broadleaf.Application.UIData;
using System.Configuration;
using Broadleaf.Application.Controller.Util;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using Broadleaf.Library.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using System.Collections;
// ADD 2013/10/08 SCM仕掛一覧№10579対応 ------------------------------->>>>>
using System.Threading;
// ADD 2013/10/08 SCM仕掛一覧№10579対応 -------------------------------<<<<<



namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// Tablet常駐処理UIクラス
    /// </summary>
    /// <remarks>
    /// <br>Note		: ポップアップ受信処理を行います。</br>
    /// <br>Programmer	: 高峰</br>
    /// <br>Date		: 2013/05/29</br>
    /// <br>Update Note : ソースチェック確認事項一覧NO.1の対応</br>
    /// <br>管理番号    : 10902622-01</br>
    /// <br>Programmer  : wangl2</br>
    /// <br>Date        : 2013/06/10</br>
    /// <br>Update Note : ソースチェック確認事項一覧NO.5の対応</br>
    /// <br>管理番号    : 10902622-01</br>
    /// <br>Programmer  : wangl2</br>
    /// <br>Date        : 2013/06/10</br>
    /// <br>Update Note : ソースチェック確認事項一覧NO.6の対応</br>
    /// <br>管理番号    : 10902622-01</br>
    /// <br>Programmer  : wangl2</br>
    /// <br>Date        : 2013/06/10</br>
    /// <br>Update Note : ソースチェック確認事項一覧タブレットログ対応</br>
    /// <br>管理番号    : 10902622-01</br>
    /// <br>Programmer  : wangl2</br>
    /// <br>Date        : 2013/06/19</br>
    /// <br>Update Note : ソースチェック確認事項一覧NO.49の対応</br>
    /// <br>管理番号    : 10902622-01</br>
    /// <br>Programmer  : wangl2</br>
    /// <br>Date        : 2013/06/20</br>
    /// <br>Update Note : Redmine#37163</br>
    /// <br>管理番号    : 10902622-01</br>
    /// <br>Programmer  : wangl2</br>
    /// <br>Date        : 2013/06/25</br>
    /// <br>Update Note : Redmine#37412</br>
    /// <br>管理番号    : 10902622-01</br>
    /// <br>Programmer  : wangl2</br>
    /// <br>Date        : 2013/06/27</br>
    /// <br>Update Note : Redmine#38118</br>
    /// <br>管理番号    : 10902622-01</br>
    /// <br>Programmer  : wangl2</br>
    /// <br>Date        : 2013/07/10</br>
    /// <br>Update Note : ログ見直し</br>
    /// <br>管理番号    : 10902622-01</br>
    /// <br>Programmer  : 吉岡</br>
    /// <br>Date        : 2013/07/29</br>
    /// <br>Update Note : Redmine#39398</br>
    /// <br>管理番号    : 10902622-01</br>
    /// <br>Programmer  : wangl2</br>
    /// <br>Date        : 2013/07/30</br>
    /// <br></br>
    /// </remarks>
    public partial class TabletPopupForm : Form
    {
        // --- ADD 2013/08/23 三戸 各処理非同期対応 --------->>>>>>>>>>>>>>>>>>>>>>>>
        #region public変数
        public object setMastUpLoadLock = new object();         // 排他ロック用（設定マスタアップロード）
        public object autoAnswerCustInfoLock = new object();    // 排他ロック用（自動回答処理（得意先情報））
        public object autoAnswerSearchLock = new object();      // 排他ロック用（自動回答処理（検索））
        public object autoAnswerDataCreateLock = new object();  // 排他ロック用（自動回答処理（データ登録））
        public object autoAnswerSlipListLock = new object();    // 排他ロック用（自動回答処理（得意先電子元帳））
        public ConstantManagement.MethodResult resultReply;
        public CustomerInfo customerInfo;
        // ADD 2013/08/30 Remine#40121 yugami -------------------------------->>>>>
        public object sessionIdDicLock = new object();             // 排他ロック用（セッションIDDictionary）
        // ADD 2013/08/30 Remine#40121 yugami --------------------------------<<<<<
        // ADD 2013/10/08 SCM仕掛一覧№10579対応 ------------------------------->>>>>
        public object searchInitialLock = new object();         // 排他ロック用（商品検索アクセスクラスキャッシュ）
        // ADD 2013/10/08 SCM仕掛一覧№10579対応 -------------------------------<<<<<
        #endregion
        // --- ADD 2013/08/23 三戸 各処理非同期対応 ---------<<<<<<<<<<<<<<<<<<<<<<<<

        #region private定数
        private const int SET_MAST_UP_LOAD = 1; // 設定マスタアップロード
        private const int AUTO_ANSWER_CUST_INFO = 2; // 自動回答処理（得意先情報）
        private const int AUTO_ANSWER_SEARCH = 3; // 自動回答処理（検索）
        private const int AUTO_ANSWER_DATA_CREATE = 4; // 自動回答処理（データ登録）
        private const int AUTO_ANSWER_SLIP_LIST = 5; // 自動回答処理（得意先電子元帳）

        private const string CT_Conf_PortNumber = "PortNumber"; // 通信用ポート番号
        private const double ctFormOpacity = 0.92;
        //private const int ctDefaultFormHeight = 158;//-----DEL songg 2013/07/01 障害報告 #37530の対応
        private const int ctDefaultFormHeight = 126;//-----ADD songg 2013/07/01 障害報告 #37530の対応
        
        /// <summary>売上情報登録の提示を表示するかどうか定数</summary>
        private const string CT_Conf_SaleSlipCreateView = "SaleSlipCreateView";
        /// <summary>「config」ファイル</summary>
        private const string Exe_Conf_Filename = "PMTAB00100U.exe.config";
        /// <summary>appSettings</summary>
        private const string App_Set_Section = "appSettings";
        /// <summary>自動回答の情報を表示するかどうかフラグ</summary>
        private bool _visbleFlg = false;

        private const string ctColumnName_CustomerCdName = "CustomerCdName";
        private const string BLANK = "     ";
        private const string CT_Conf_ExeFileName = "PMTAB00100U.exe";

        #endregion

        #region private変数
        private List<string> _settingList; // ログイン情報、App.config情報設定リスト

        /// <summary>自動回答の情報を表示するかどうかの設定画面</summary>
        private PMTAB00100UC _form = null;

        private CustomerInfoAcs _customerInfoAcs;
        private DataTable _dataTable;

        private SFCMN01501CA _tabletPushClient;    // Pushクライアントオブジェクト
        private string _enterpriseCode;         // ログイン従業員の企業コード
        private string _sectionCode;            // ログイン従業員の拠点コード

        // タブレットログ対応　--------------------------------->>>>>
        private const string CLASS_NAME = "TabletPopupForm";
        private const string DEFAULT_NAME = "PMTAB00100U_";
        // タブレットログ対応　---------------------------------<<<<<

        // ADD 2013/08/30 Remine#40121 yugami -------------------------------->>>>>
        // 処理中のセッションＩＤを保存
        private Dictionary<string, object> _sessionIdDic = new Dictionary<string, object>();
        // ADD 2013/08/30 Remine#40121 yugami --------------------------------<<<<<

        /// <summary>
        /// 常駐情報
        /// </summary>
        private ResidentController _residentController;// ADD 2013/07/10 wangl2 FOR Redmine#38118

        // ADD 2013/10/08 SCM仕掛一覧№10579対応 ------------------------------->>>>>
        private GoodsAcs _goodsAccesser1;
        private GoodsAcs _goodsAccesser2;
        private CampaignPrcPrStAcs _campaignPrcPrStAcs;
        private ArrayList _campaignPrcPrStList;
        private int _cacheInitType = 0;
        private int _cacheInUsedType = 0;

        /// <summary>
        /// 定刻キャッシュ用タイマー
        /// </summary>
        private System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        /// <summary>
        /// 定刻
        /// </summary>
        private DateTime punctual;
        // ADD 2013/10/08 SCM仕掛一覧№10579対応 -------------------------------<<<<<

        #endregion

        #region <コマンドライン引数>

        /// <summary>コマンドライン引数</summary>
        private readonly string[] _commandLineArgs;
        /// <summary>コマンドライン引数を取得します。</summary>
        private string[] CommandLineArgs { get { return _commandLineArgs; } }

        #endregion // </コマンドライン引数>

        #region <フォームを閉じる判定>

        /// <summary>フォームを閉じる判定フラグ</summary>
        private bool _canClose;
        /// <summary>フォームを閉じる判定フラグのアクセサ</summary>
        private bool CanClose
        {
            get { return _canClose; }
            set { _canClose = value; }
        }

        #endregion // </フォームを閉じる判定>

        #region <初期情報の取得>
        /// <summary>
        /// 初期情報取得処理
        /// </summary>
        private void GetInitialSettings()
        {
            // タブレットログ対応　--------------------------------->>>>>
            const string methodName = "GetInitialSettings";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 開始");
            // タブレットログ対応　---------------------------------<<<<<

            this._settingList = new List<string>();
            // --------------- DEL START 2013/06/10 wangl2 FOR ソースチェック確認事項一覧NO.6の対応 ------>>>>
            //if (Program.PM7Mode)
            //{
            //    // 企業コード取得
            //    this._settingList.Add("0000000000000000");

            //    // ログイン情報より自拠点を取得
            //    this._settingList.Add("00");

            //    // ポップアップ命令送受信用のポート番号
            //    this._settingList.Add(ConfigurationManager.AppSettings[CT_Conf_PortNumber]);

            //    // PM7連携コード
            //    this._settingList.Add("0");
            //}
            //else
            //{
            //    // 企業コード取得
            //    this._settingList.Add(LoginInfoAcquisition.EnterpriseCode);

            //    // ログイン情報より自拠点を取得
            //    this._settingList.Add(LoginInfoAcquisition.Employee.BelongSectionCode.Trim().PadLeft(2, '0'));

            //    // ポップアップ命令送受信用のポート番号
            //    this._settingList.Add(ConfigurationManager.AppSettings[CT_Conf_PortNumber]);

            //    // PM7連携コード
            //    this._settingList.Add("1");

            //}
            // --------------- DEL END 2013/06/10 wangl2 FOR ソースチェック確認事項一覧NO.6の対応 --------<<<<
            // --------------- ADD START 2013/06/10 wangl2 FOR ソースチェック確認事項一覧NO.6の対応 ------>>>>
            //企業コード取得
            this._settingList.Add(LoginInfoAcquisition.EnterpriseCode);

            // ログイン情報より自拠点を取得
            this._settingList.Add(LoginInfoAcquisition.Employee.BelongSectionCode.Trim().PadLeft(2, '0'));

            // ポップアップ命令送受信用のポート番号
            this._settingList.Add(ConfigurationManager.AppSettings[CT_Conf_PortNumber]);

            // PM7連携コード
            this._settingList.Add("1");
            // --------------- ADD END 2013/06/10 wangl2 FOR ソースチェック確認事項一覧NO.6の対応 --------<<<<

            // タブレットログ対応　--------------------------------->>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了");
            // タブレットログ対応　---------------------------------<<<<<
        }

        /// <summary>
        /// 初期情報の設定内容チェック
        /// </summary>
        /// <returns></returns>
        private bool CheckInitialSettings()
        {
            // タブレットログ対応　--------------------------------->>>>>
            const string methodName = "CheckInitialSettings";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 開始");
            // タブレットログ対応　---------------------------------<<<<<

            Int32 portNumber;
            if (!Int32.TryParse(ConfigurationManager.AppSettings[CT_Conf_PortNumber], out portNumber))
            {
                LogWriter.LogWrite("configファイルのポート番号の設定が正しくありません。");
                return false;
            }
            else
            {
                if (portNumber < 0 || portNumber > 65535)
                {
                    LogWriter.LogWrite("configファイルのポート番号の設定が正しくありません。");
                    // タブレットログ対応　--------------------------------->>>>>
                    EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了");
                    // タブレットログ対応　---------------------------------<<<<<
                    return false;
                }
            }

            // タブレットログ対応　--------------------------------->>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了");
            // タブレットログ対応　---------------------------------<<<<<
            return true;
        }
        #endregion

        #region <Constructor>

        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        private TabletPopupForm()
            : base()
        {
            #region <Designer Code>

            InitializeComponent();

            #endregion // </Designer Code>

            _enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            _sectionCode = LoginInfoAcquisition.Employee.BelongSectionCode.Trim();
            this._dataTable = new DataTable();
            this._dataTable.Columns.Add(new DataColumn(ctColumnName_CustomerCdName, typeof(string)));
            this.dataGridView_Data.DataSource = this._dataTable.DefaultView;
            // タブレットログ対応　--------------------------------->>>>>
            // コンストラクタでログ出力用ディレクトリを作成
            System.IO.Directory.CreateDirectory(EasyLogger.OutPutPath);
            // タブレットログ対応　---------------------------------<<<<<
        }

        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="commandLineArgs">コマンドライン引数</param>
        public TabletPopupForm(string[] commandLineArgs)
            : this()
        {
            _commandLineArgs = commandLineArgs;

            // タブレットログ対応　--------------------------------->>>>>
            // コンストラクタでログ出力用ディレクトリを作成
            System.IO.Directory.CreateDirectory(EasyLogger.OutPutPath);
            // タブレットログ対応　---------------------------------<<<<<
        }

        #endregion // </Constructor>

        #region <フォーム>

        /// <summary>デフォルトx座標</summary>
        private const int DEFAULT_X = 100000;
        /// <summary>デフォルトy座標</summary>
        private const int DEFAULT_Y = 100000;



        // ADD 吉岡 2013/08/07 常駐処理再起動対応 --------->>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// メッセージ受信（再起動）
        /// </summary>
        /// <param name="m">受信メッセージ</param>
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case Program.WM_COPYDATA:
                    //文字が送信されて来た

                    Program.COPYDATASTRUCT mystr = new Program.COPYDATASTRUCT();
                    Type mytype = mystr.GetType();
                    mystr = (Program.COPYDATASTRUCT)m.GetLParam(mytype);
                    if (mystr.lpData.Trim().Equals(Program.RESTART))
                    {
                        // 終了処理
                        CanClose = true;
                        Close();
                    }
                    break; 
            }
            base.WndProc(ref m);
        }
        // ADD 吉岡 2013/08/07 常駐処理再起動対応 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

        /// <summary>
        /// フォームのLoadイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void TabletPopupForm_Load(object sender, EventArgs e)
        {
            // タブレットログ対応　--------------------------------->>>>>
            const string methodName = "TabletPopupForm_Load";
            EasyLogger.Name = DEFAULT_NAME;
            EasyLogger.Write(CLASS_NAME,methodName,methodName + " 開始");
            // タブレットログ対応　---------------------------------<<<<<

            // --------------- ADD START 2013/07/10 wangl2 FOR Redmine#38118------>>>>
            if (_residentController == null)
                _residentController = new ResidentController();
            this._residentController.SearchSetting(LoginInfoAcquisition.EnterpriseCode, LoginInfoAcquisition.Employee.BelongSectionCode.Trim());
            // --------------- ADD END 2013/07/10 wangl2 FOR Redmine#38118--------<<<<
            this.dataGridView_Data.Columns[ctColumnName_CustomerCdName].Visible = false;

            this.Height = ctDefaultFormHeight;
            //this.SetNewestData();

            // 初期表示は隠し
            SetVisibleState(false);

            // 初期位置を設定（ちらつき防止の為、10000にしています）
            SetDesktopBounds(DEFAULT_X, DEFAULT_Y, Width, Height);

            // App.Config情報取得
            GetInitialSettings();

            // App.Config情報チェック
            if (!this.CheckInitialSettings())
            {
                // 初期設定がエラーの場合は終了
                CanClose = true;
                Close();
                return;
            }

            // ADD 2013/08/23 三戸 各処理非同期対応------>>>>>>>>
            this._dataTable.Clear();
            DataRow dr = this._dataTable.NewRow();
            this._dataTable.Rows.Add(dr);
            // ADD 2013/08/23 三戸 各処理非同期対応------<<<<<<<<

            this.SetStyle(ControlStyles.ResizeRedraw, true);

            // ADD 2013/08/30 Redmine#40121 yugami ----------------------------------->>>>>
            // タイマー起動
            waitTimeReset.Enabled = true;
            // ADD 2013/08/30 Redmine#40121 yugami -----------------------------------<<<<<

            // ADD 2013/10/08 SCM仕掛一覧№10579対応 ------------------------------->>>>>
            _goodsAccesser1 = new GoodsAcs(LoginInfoAcquisition.Employee.BelongSectionCode);
            string msg = string.Empty;
            _goodsAccesser1.SearchInitial(LoginInfoAcquisition.EnterpriseCode, LoginInfoAcquisition.Employee.BelongSectionCode, out msg);
            _cacheInitType = 1;
            _campaignPrcPrStAcs = new CampaignPrcPrStAcs();
            _campaignPrcPrStAcs.SearchAll(out _campaignPrcPrStList, LoginInfoAcquisition.EnterpriseCode);
            // ADD 2013/10/08 SCM仕掛一覧№10579対応 -------------------------------<<<<<

            InitPushMode();
            DelLogFile();// ADD 2013/07/30 wangl2 FOR Redmine#39398

            // ADD 2013/10/08 SCM仕掛一覧№10579対応 ------------------------------->>>>>
            CachePunctualTimerSet();
            // ADD 2013/10/08 SCM仕掛一覧№10579対応 -------------------------------<<<<<

            // タブレットログ対応　--------------------------------->>>>>
            EasyLogger.Name = DEFAULT_NAME;
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了");
            // タブレットログ対応　---------------------------------<<<<<
        }

        // --------------- ADD START 2013/07/30 wangl2 FOR Redmine#39398------>>>>
        /// <summary>
        /// ログファイルを削除する
        /// </summary>
        private void DelLogFile()
        {
            const string methodName = "DelLogFile";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 開始");
            // ログパス
            string path = System.IO.Directory.GetCurrentDirectory() + @"\Log\PmTablet";
            // 削除日付
            string dateTimeNow = DateTime.Now.AddMonths(-6).ToString("yyyyMMdd");
            try
            {
                if (System.IO.Directory.Exists(path))
                {
                    // 結果リスト
                    List<string> results = new List<string>();
                    // ファイルリスト検索処理
                    List<string> importList = this.GetFileList(path);
                    foreach (string paths in importList)
                    {
                        FileInfo file = new FileInfo(paths);
                        DateTime filetime = file.LastWriteTime;
                        string time = filetime.ToString("yyyyMMdd");
                        if (Convert.ToInt64(time) <= Convert.ToInt64(dateTimeNow))
                        {
                            // リストに追加
                            results.Add(paths);
                        }
                    }
                    if (results != null && results.Count > 0)
                    {
                        foreach (string delpath in results)
                        {
                            File.Delete(delpath);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                EasyLogger.Write(CLASS_NAME, methodName, ex.Message);
            }
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了");
        }

        /// <summary>
        /// ファイルリスト検索処理
        /// </summary>
        /// <param name="folderPath">検索フォルダパス</param>
        /// <returns>ファイルリスト</returns>
        /// <remarks>
        /// <br>Note	   : 指定されたフォルダ直下のファイルリストを返します。</br>
        /// <br>Programmer : wangl2</br>
        /// <br>Date       : 2013.07.30</br>
        /// </remarks>
        private List<string> GetFileList(string folderPath)
        {
            const string methodName = "GetFileList";
            EasyLogger.Name = DEFAULT_NAME;
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 開始");
            string[] fileExtension ={"*.log"};
            List<string> fileLsit = new List<string>();
            for (int i = 0; i < fileExtension.Length; i++)
            {
                string[] Lsit = new string[0];
                Lsit = Directory.GetFiles(folderPath, fileExtension[i]);
                if (Lsit != null && Lsit.Length > 0)
                {
                    foreach (string dir in Lsit)
                    {
                        // リストに追加
                        fileLsit.Add(dir);
                    }
                }
            }
            EasyLogger.Name = DEFAULT_NAME;
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了");
            return fileLsit;
        }
        // --------------- ADD END 2013/07/30 wangl2 FOR Redmine#39398--------<<<<

        /// <summary>
        /// Pushモードの初期化
        /// </summary>
        private void InitPushMode()
        {
            // タブレットログ対応　--------------------------------->>>>>
            const string methodName = "InitPushMode";
            EasyLogger.Name = DEFAULT_NAME;
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 開始");
            // タブレットログ対応　---------------------------------<<<<<

            ClientArgs clientArgs = new ClientArgs();

            // PushサーバーURLの設定
            string wkStr1 = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_WEBSYNCAP);
            string wkStr2 = LoginInfoAcquisition.GetConnectionInfo(ConstantManagement_SF_PRO.ServerCode_WEBSYNCAP, ConstantManagement_SF_PRO.IndexCode_WebSync_WebPath);
            string webSyncUrl = wkStr1 + wkStr2;
            clientArgs.Url = webSyncUrl;

            _tabletPushClient = new SFCMN01501CA(clientArgs);

            ConnectArgs connectArgs = new ConnectArgs();
            connectArgs.StayConnected = true; // 接続が切断場合、自動的に再接続する
            connectArgs.ReconnectInterval = 5000; // 5秒　接続失敗場合、再接続間隔を指定する
            connectArgs.ConnectFailure += new PushClientEventHandler<ConnectFailureEventArgs>(
                delegate(IScmPushClient client, ConnectFailureEventArgs args)
                {
                    // 新着チェッカーが起動する時、Pushサーバーを接続できなければ、このメソッドを呼びられる
                    // 接続した後、Pushサーバーと通信エラー場合、OnStreamFailureイベントだけを呼びられる

                    // 接続が失敗すれば、Pushサーバーへ再接続
                    args.Reconnect = true;
                }
            );
            _tabletPushClient.Connect(connectArgs);

            // SCM問い合わせ或いはテストメッセージを受け取れるために、チャンネルを予約する            
            //if (LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_PM_SCM) >= PurchaseStatus.Contract)// DEL 2013/06/10 wangl2 FOR ソースチェック確認事項一覧NO.1の対応
            //if (LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_BasicTablet) >= PurchaseStatus.Contract)// ADD 2013/06/10 wangl2 FOR ソースチェック確認事項一覧NO.1の対応   // DEL 2013/06/27 wangl2 FOR Redmine#37412
            //{ // DEL 2013/06/27 wangl2 FOR Redmine#37412
                SubscribeArgs<TabletPushData> subscribeArgs = new SubscribeArgs<TabletPushData>();
                subscribeArgs.Channel = string.Format("/{0}/PMNS/{1}/{2}", _tabletPushClient.WEBSYNC_CHANNEL_PMTAB, _enterpriseCode, _sectionCode.Trim());
                subscribeArgs.SubscribeSuccess += new PushClientEventHandler<SubscribeSuccessEventArgs>(
                    delegate(IScmPushClient client, SubscribeSuccessEventArgs args)
                    {
                        // 接続あるいは再接続が成功するとき、このメソッドを呼びられる
                        Invoke(new MethodInvoker(delegate()
                        {
                            if (args.IsResubscribe)
                            {
                                
                            }
                        }));
                    }
                );
                subscribeArgs.SubscribeReceive += new PushClientEventHandler<SubscribeReceiveEventArgs<TabletPushData>>(
                    delegate(IScmPushClient client, SubscribeReceiveEventArgs<TabletPushData> args)
                    {
                        // --------------- ADD START 2013/07/10 wangl2 FOR Redmine#38118------>>>>
                        // UPD 2013/08/01 吉岡 Redmine#39489 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                        //if (this._residentController.Match() == false)
                        if (this._residentController.Match(_enterpriseCode,_sectionCode) == false)
                        // UPD 2013/08/01 吉岡 Redmine#39489 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                        {
                            return;
                        }
                        // --------------- ADD END 2013/07/10 wangl2 FOR Redmine#38118--------<<<<
                        // UPD 2013/07/29 吉岡 ログ見直し----------------------->>>>>>>>>>>>>>>>>>>>>>>>>>>>
                        //// タブレットログ対応　--------------------------------->>>>>
                        //EasyLogger.Write(CLASS_NAME, methodName, "▼▼▼▼▼常駐自動回答処理　開始▼▼▼▼▼");
                        //// タブレットログ対応　---------------------------------<<<<<
                        EasyLogger.Name = DEFAULT_NAME;
                        EasyLogger.Write(CLASS_NAME, methodName, "▼常駐自動回答処理　開始▼");
                        // UPD 2013/07/29 吉岡 ログ見直し-----------------------<<<<<<<<<<<<<<<<<<<<<<<<<<<<

                        // SF.NSから問い合わせ或いはテストメッセージが受け取れたら、このメソッドを呼びられる
                        Invoke(new MethodInvoker(delegate()
                        {
                            // PushサーバーからPushデータ取得の後処理
                            TabletPushData data = args.Payload;

                            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                            string message = string.Empty;
                            string enterpriseCode = string.Empty;
                            string sectionCode = string.Empty;
                            string sessionid = string.Empty;
                            switch (data.ProcKind)
                            {
                                // 処理種別 = 「設定マスタアップロード」の場合
                                case SET_MAST_UP_LOAD:
                                    {
                                        //# region <TODO：一時コメントとする>// DEL 2013/06/10 wangl2 FOR ソースチェック確認事項一覧NO.5の対応
                                        # region// ADD 2013/06/10 wangl2 FOR ソースチェック確認事項一覧NO.5の対応
                                        // --- DEL 2013/08/23 三戸 各処理非同期対応 --------->>>>>>>>>>>>>>>>>>>>>>>>

                                        //PMTabSCMUpLoadMastAcs pmTabSCMUpLoadMastAcs = new PMTabSCMUpLoadMastAcs();
                                        //#region パラメータ分解
                                        //// 企業コード: TabletPushDataクラスプロパティの企業コード
                                        //enterpriseCode = data.EnterpriseCode;
                                        //// 拠点コード: TabletPushDataクラスプロパティの拠点コード
                                        //sectionCode = data.SectionCode;
                                        //#endregion

                                        //// タブレットログ対応　--------------------------------->>>>>
                                        //EasyLogger.Write(CLASS_NAME, methodName, "設定マスタアップロード");
                                        //EasyLogger.Write(CLASS_NAME, methodName, "企業コード：" + enterpriseCode + "  拠点コード：" + sectionCode);
                                        //// タブレットログ対応　---------------------------------<<<<<

                                        //// 自動回答処理（設定マスタ）を呼び出す
                                        //status = pmTabSCMUpLoadMastAcs.PMTabMastSCMUpLoad(enterpriseCode, sectionCode);
                                        // --- DEL 2013/08/23 三戸 各処理非同期対応 ---------<<<<<<<<<<<<<<<<<<<<<<<<

                                        #endregion

                                        // --- ADD 2013/08/23 三戸 各処理非同期対応 --------->>>>>>>>>>>>>>>>>>>>>>>>
                                        EasyLogger.Name = DEFAULT_NAME;
                                        EasyLogger.Write(CLASS_NAME, methodName, "設定マスタアップロード");
                                        EasyLogger.Write(CLASS_NAME, methodName, "企業コード：" + data.EnterpriseCode + "  拠点コード：" + data.SectionCode);
                                        setMastUpLoadAsyncCall caller = setMastUpLoad;
                                        IAsyncResult result = caller.BeginInvoke(data, methodName, null, null);  //非同期呼び出し開始
                                        // --- ADD 2013/08/23 三戸 各処理非同期対応 ---------<<<<<<<<<<<<<<<<<<<<<<<<

                                        break;
                                    }
                                
                                // 処理種別 = 「自動回答処理（得意先情報）」の場合
                                case AUTO_ANSWER_CUST_INFO:
                                    {
                                        # region// DEL 2013/08/23 三戸 各処理非同期対応
                                        // --- DEL 2013/08/23 三戸 各処理非同期対応 --------->>>>>>>>>>>>>>>>>>>>>>>>
                                        //TabSCMCustomerAcs tabSCMCustomerAcs = new TabSCMCustomerAcs();
                                        //#region パラメータ分解

                                        //// 企業コード: TabletPushDataクラスプロパティの企業コード
                                        //enterpriseCode = data.EnterpriseCode;

                                        //// 拠点コード: TabletPushDataクラスプロパティの拠点コード
                                        //sectionCode = data.SectionCode;

                                        //// 業務セッションID: TabletPushDataクラスプロパティの業務セッションID
                                        //sessionid = data.SessionId;

                                        //// 明細識別GUI: TabletPushDataクラスプロパティの明細識別GUID
                                        //string guidId = data.GuidId;
                                        //string[] param = data.Param.Split(new char[1] { ':' });

                                        //string custNameKana = string.Empty;
                                        //// 得意先名カナ: TabletPushDataクラスプロパティのパラメータの１番目
                                        //if (param.Length >= 1)
                                        //{
                                        //    custNameKana = param[0];
                                        //}

                                        //int custcode = 0;
                                        //// 得意先コード: TabletPushDataクラスプロパティのパラメータの２番目
                                        //if (param.Length >= 2)
                                        //{
                                        //    if (!string.IsNullOrEmpty(param[1]))
                                        //    {
                                        //        custcode = Convert.ToInt32(param[1]);
                                        //    }
                                        //    else 
                                        //    {
                                        //        custcode = 0;
                                        //    }
                                        //}

                                        //string mngSectionCode = string.Empty;
                                        //// 管理拠点: TabletPushDataクラスプロパティのパラメータの３番目
                                        //if (param.Length >= 3)
                                        //{
                                        //    mngSectionCode = param[2];
                                        //}

                                        //int kanaSearchDiv = 0;
                                        //// ｶﾅ名検索区分: TabletPushDataクラスプロパティのパラメータの４番目
                                        //if (param.Length >= 4)
                                        //{
                                        //    kanaSearchDiv = Convert.ToInt32(param[3]);
                                        //}

                                        //#endregion

                                        //// タブレットログ対応　--------------------------------->>>>>
                                        //EasyLogger.Write(CLASS_NAME, methodName, "自動回答処理（得意先情報）");
                                        //EasyLogger.Write(CLASS_NAME, methodName, 
                                        //    "企業コード：" + enterpriseCode
                                        //    + "  拠点コード：" + sectionCode
                                        //    + "  業務セッションID：" + sessionid
                                        //    + "  明細識別GUID：" + guidId
                                        //    + "  得意先名カナ：" + custNameKana
                                        //    + "  得意先コード：" + custcode
                                        //    + "  管理拠点：" + mngSectionCode
                                        //    + "  ｶﾅ名検索区分：" + kanaSearchDiv
                                        //    );
                                        //// タブレットログ対応　---------------------------------<<<<<

                                        //// 自動回答処理（得意先情報）を呼び出す
                                        //status = tabSCMCustomerAcs.SearchCustomerDataForTablet(enterpriseCode, sectionCode, sessionid, custNameKana, custcode, mngSectionCode, kanaSearchDiv, out message);
                                        // --- DEL 2013/08/23 三戸 各処理非同期対応 ---------<<<<<<<<<<<<<<<<<<<<<<<<
                                        #endregion

                                        // ADD 2013/09/02 Redmine#40121 ----------------------------------------->>>>>
                                        // Tablet端末への返答送信処理
                                        NotifyTabletByPublish(status, message, data.SessionId, (int)ScmPushDataConstMode.CHECNK1WAITESEND);
                                        // ADD 2013/09/02 Redmine#40121 -----------------------------------------<<<<<

                                        // --- ADD 2013/08/23 三戸 各処理非同期対応 --------->>>>>>>>>>>>>>>>>>>>>>>>
                                        #region パラメータ分解
                                        string[] param = data.Param.Split(new char[1] { ':' });

                                        string custNameKana = string.Empty;
                                        // 得意先名カナ: TabletPushDataクラスプロパティのパラメータの１番目
                                        if (param.Length >= 1)
                                        {
                                            custNameKana = param[0];
                                        }

                                        int custcode = 0;
                                        // 得意先コード: TabletPushDataクラスプロパティのパラメータの２番目
                                        if (param.Length >= 2)
                                        {
                                            if (!string.IsNullOrEmpty(param[1]))
                                            {
                                                custcode = Convert.ToInt32(param[1]);
                                            }
                                            else
                                            {
                                                custcode = 0;
                                            }
                                        }

                                        string mngSectionCode = string.Empty;
                                        // 管理拠点: TabletPushDataクラスプロパティのパラメータの３番目
                                        if (param.Length >= 3)
                                        {
                                            mngSectionCode = param[2];
                                        }

                                        int kanaSearchDiv = 0;
                                        // ｶﾅ名検索区分: TabletPushDataクラスプロパティのパラメータの４番目
                                        if (param.Length >= 4)
                                        {
                                            kanaSearchDiv = Convert.ToInt32(param[3]);
                                        }
                                        #endregion

                                        EasyLogger.Name = DEFAULT_NAME;
                                        EasyLogger.Write(CLASS_NAME, methodName, "自動回答処理（得意先情報）");
                                        EasyLogger.Write(CLASS_NAME, methodName,
                                            "企業コード：" + data.EnterpriseCode
                                            + "  拠点コード：" + data.SectionCode
                                            + "  業務セッションID：" + data.SectionCode
                                            + "  明細識別GUID：" + data.GuidId
                                            + "  得意先名カナ：" + custNameKana
                                            + "  得意先コード：" + custcode
                                            + "  管理拠点：" + mngSectionCode
                                            + "  ｶﾅ名検索区分：" + kanaSearchDiv
                                            );

                                        autoAnswerCustInfoAsyncCall caller = autoAnswerCustInfo;
                                        IAsyncResult result = caller.BeginInvoke(methodName, data.EnterpriseCode, data.SectionCode, data.SessionId, custNameKana, custcode, mngSectionCode, kanaSearchDiv, null, null);  //非同期呼び出し開始
                                        // --- ADD 2013/08/23 三戸 各処理非同期対応 ---------<<<<<<<<<<<<<<<<<<<<<<<<

                                        break;
                                    }
                                // 処理種別 = 「自動回答処理（検索）」の場合
                                case AUTO_ANSWER_SEARCH:
                                    {
                                        //# region <TODO：一時コメントとする> // DEL 2013/06/10 wangl2 FOR ソースチェック確認事項一覧NO.5の対応
                                        # region  // ADD 2013/06/10 wangl2 FOR ソースチェック確認事項一覧NO.5の対応
                                        // --- DEL 2013/08/23 三戸 各処理非同期対応 --------->>>>>>>>>>>>>>>>>>>>>>>>
                                        //ScmSearchForTablet scmSearchForTablet = new ScmSearchForTablet();

                                        //#region パラメータ分解
                                        //// 企業コード: TabletPushDataクラスプロパティの企業コード
                                        //enterpriseCode = data.EnterpriseCode;

                                        //// 拠点コード: TabletPushDataクラスプロパティの拠点コード
                                        //sectionCode = data.SectionCode;

                                        //// 業務セッションID: TabletPushDataクラスプロパティの業務セッションID
                                        //sessionid = data.SessionId;

                                        //// 明細識別GUID: TabletPushDataクラスプロパティの明細識別GUID
                                        //string guidId = data.GuidId;

                                        //string[] param = data.Param.Split(new char[1] { ':' });

                                        //string goodNo = string.Empty;
                                        //// 商品番号: TabletPushDataクラスプロパティのパラメータの１番目
                                        //if (param.Length >= 1)
                                        //{
                                        //    goodNo = param[0];
                                        //}

                                        //int blCode = 0;
                                        //// BLコード: TabletPushDataクラスプロパティのパラメータの２番目
                                        //if (param.Length >= 2)
                                        //{
                                        //    blCode = Convert.ToInt32(param[1]);
                                        //}

                                        //int custCode = 0;
                                        //// 得意先コード: TabletPushDataクラスプロパティのパラメータの３番目
                                        //if (param.Length >= 3)
                                        //{
                                        //    custCode = Convert.ToInt32(param[2]);
                                        //}

                                        //#endregion

                                        //// タブレットログ対応　--------------------------------->>>>>
                                        //EasyLogger.Write(CLASS_NAME, methodName, "自動回答処理（検索）");
                                        //EasyLogger.Write(CLASS_NAME, methodName,
                                        //    "企業コード：" + enterpriseCode
                                        //    + "  拠点コード：" + sectionCode
                                        //    + "  業務セッションID：" + sessionid
                                        //    + "  明細識別GUID：" + guidId
                                        //    + "  商品番号：" + goodNo
                                        //    + "  BLコード：" + blCode
                                        //    + "  得意先コード：" + custCode
                                        //    );
                                        //// タブレットログ対応　---------------------------------<<<<<
                                        //// 自動回答処理（検索）を呼び出す
                                        //status = scmSearchForTablet.SearchForTablet(enterpriseCode, sectionCode, goodNo, blCode, custCode, sessionid, guidId, out message);
                                        // --- DEL 2013/08/23 三戸 各処理非同期対応 ---------<<<<<<<<<<<<<<<<<<<<<<<<
                                        #endregion

                                        // --- ADD 2013/08/23 三戸 各処理非同期対応 --------->>>>>>>>>>>>>>>>>>>>>>>>
                                        #region パラメータ分解
                                        string[] param = data.Param.Split(new char[1] { ':' });

                                        string goodNo = string.Empty;
                                        // 商品番号: TabletPushDataクラスプロパティのパラメータの１番目
                                        if (param.Length >= 1)
                                        {
                                            goodNo = param[0];
                                        }

                                        int blCode = 0;
                                        // BLコード: TabletPushDataクラスプロパティのパラメータの２番目
                                        if (param.Length >= 2)
                                        {
                                            blCode = Convert.ToInt32(param[1]);
                                        }

                                        int custCode = 0;
                                        // 得意先コード: TabletPushDataクラスプロパティのパラメータの３番目
                                        if (param.Length >= 3)
                                        {
                                            custCode = Convert.ToInt32(param[2]);
                                        }
                                        #endregion

                                        EasyLogger.Name = DEFAULT_NAME;
                                        EasyLogger.Write(CLASS_NAME, methodName, "自動回答処理（検索）");
                                        EasyLogger.Write(CLASS_NAME, methodName,
                                            "企業コード：" + data.EnterpriseCode
                                            + "  拠点コード：" + data.SectionCode
                                            + "  業務セッションID：" + data.SessionId
                                            + "  明細識別GUID：" + data.GuidId
                                            + "  商品番号：" + goodNo
                                            + "  BLコード：" + blCode
                                            + "  得意先コード：" + custCode
                                            );

                                        autoAnswerSearchAsyncCall caller = autoAnswerSearch;
                                        IAsyncResult result = caller.BeginInvoke(methodName, data.EnterpriseCode, data.SectionCode, data.SessionId, goodNo, blCode, custCode, data.GuidId, null, null);  //非同期呼び出し開始
                                        // --- ADD 2013/08/23 三戸 各処理非同期対応 ---------<<<<<<<<<<<<<<<<<<<<<<<<
                                        break;
          
                                    }
                                // 処理種別 = 「自動回答処理（データ登録）」の場合
                                case AUTO_ANSWER_DATA_CREATE:
                                    {
                                        # region// DEL 2013/08/23 三戸 各処理非同期対応
                                        // --- DEL 2013/08/23 三戸 各処理非同期対応 --------->>>>>>>>>>>>>>>>>>>>>>>>
                                        //#region パラメータ分解

                                        //// 企業コード: TabletPushDataクラスプロパティの企業コード
                                        //enterpriseCode = data.EnterpriseCode;

                                        //// 拠点コード: TabletPushDataクラスプロパティの拠点コード
                                        //sectionCode = data.SectionCode;

                                        //// 業務セッションID: TabletPushDataクラスプロパティの業務セッションID
                                        //sessionid = data.SessionId;

                                        //#endregion

                                        //// タブレットログ対応　--------------------------------->>>>>
                                        //EasyLogger.Write(CLASS_NAME, methodName, "自動回答処理（データ登録）");
                                        //EasyLogger.Write(CLASS_NAME, methodName,
                                        //    "企業コード：" + enterpriseCode
                                        //    + "  拠点コード：" + sectionCode
                                        //    + "  業務セッションID：" + sessionid
                                        //    );
                                        //// タブレットログ対応　---------------------------------<<<<<

                                        //CustomerInfo customerInfo;
                                        //TabSCMSalesDataMaker tabSCMSalesDataMaker = new TabSCMSalesDataMaker(Program.argsSave[0] + " " + Program.argsSave[1]);

                                        //ConstantManagement.MethodResult result = tabSCMSalesDataMaker.Reply(enterpriseCode, sectionCode, sessionid, out message, out customerInfo);
                                        //status = (int)result;

                                        //// 売上情報登録の提示をポップアップ
                                        //if (result == ConstantManagement.MethodResult.ctFNC_NORMAL && null != customerInfo)
                                        //{
                                        //    this._dataTable.Clear();
                                        //    DataRow dr = this._dataTable.NewRow();
                                        //    dr[ctColumnName_CustomerCdName] = BLANK + customerInfo.CustomerCode + " " + customerInfo.CustomerSnm;
                                        //    this._dataTable.Rows.Add(dr);

                                        //    AppSettingsSection appSettingSection = GetAppSettingsSection();
                                        //    if (appSettingSection.Settings[CT_Conf_SaleSlipCreateView].Value.Equals("1"))
                                        //    {
                                        //        this.ShowPopup(this, new ReceivedEventArgs());
                                        //    }
                                        //}
                                        // --- DEL 2013/08/23 三戸 各処理非同期対応 ---------<<<<<<<<<<<<<<<<<<<<<<<<
                                        #endregion

                                        // ADD 2013/08/26 Redmine#40121 ----------------------------------------->>>>>
                                        // Tablet端末への返答送信処理
                                        NotifyTabletByPublish(status, message, data.SessionId, (int)ScmPushDataConstMode.CHECNK1WAITESEND);
                                        // ADD 2013/08/26 Redmine#40121 -----------------------------------------<<<<<

                                        // ADD 2013/08/30 Redmine#40121 yugami ----------------------------------------->>>>>
                                        if (!this._sessionIdDic.ContainsKey(data.SessionId))
                                        {
                                            this._sessionIdDic.Add(data.SessionId, null);
                                        }
                                        // ADD 2013/08/30 Redmine#40121 yugami -----------------------------------------<<<<<

                                        // --- ADD 2013/08/23 三戸 各処理非同期対応 --------->>>>>>>>>>>>>>>>>>>>>>>>
                                        EasyLogger.Name = DEFAULT_NAME;
                                        EasyLogger.Write(CLASS_NAME, methodName, "自動回答処理（データ登録）");
                                        EasyLogger.Write(CLASS_NAME, methodName,
                                            "企業コード：" + data.EnterpriseCode
                                            + "  拠点コード：" + data.SectionCode
                                            + "  業務セッションID：" + data.SessionId
                                            );
                                        autoAnswerDataCreateAsyncCall caller = autoAnswerDataCreate;
                                        IAsyncResult result = caller.BeginInvoke(data, methodName, new AsyncCallback(autoAnswerDataCreateCallback), null);  //非同期呼び出し開始
                                        // --- ADD 2013/08/23 三戸 各処理非同期対応 ---------<<<<<<<<<<<<<<<<<<<<<<<<

                                        break;
                                    }
                                // 処理種別 = 「自動回答処理（得意先電子元帳）」の場合
                                case AUTO_ANSWER_SLIP_LIST:
                                    {
                                        //# region <TODO：一時コメントとする>// DEL 2013/06/10 wangl2 FOR ソースチェック確認事項一覧NO.5の対応
                                        # region // ADD 2013/06/10 wangl2 FOR ソースチェック確認事項一覧NO.5の対応
                                        // --- DEL 2013/08/23 三戸 各処理非同期対応 --------->>>>>>>>>>>>>>>>>>>>>>>>
                                        //CustPrtSlipTabSearchAcs custPrtSlipTabSearchAcs = new CustPrtSlipTabSearchAcs();
                                        //custPrtSlipTabSearchAcs.notifyTabletByPublish += new CustPrtSlipTabSearchAcs.NotifyTabletByPublishEventHandler(NotifyTabletByPublish);

                                        //#region パラメータ分解

                                        //// 企業コード: TabletPushDataクラスプロパティの企業コード
                                        //enterpriseCode = data.EnterpriseCode;

                                        //// 拠点コード: TabletPushDataクラスプロパティの拠点コード
                                        //sectionCode = data.SectionCode;
                                        //sessionid = data.SessionId;
                                        //// 検索条件: TabletPushDataクラスプロパティの検索条件
                                        //string jsonString = data.SearchCondition.ToString();
                                        //DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(CustPrtParaWork));
                                        //MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(jsonString));
                                        //CustPrtParaWork custPrtParaWork = (CustPrtParaWork)ser.ReadObject(ms);
                                        //CustPrtPprWork custPrtPprWork = new CustPrtPprWork();
                                        ////custPrtPprWork.AcptAnOdrStatus = new int[] { Convert.ToInt32(custPrtParaWork.AcptAnOdrStatus) };// DEL 2013/06/20 wangl2 FOR ソースチェック確認事項NO.49の対応
                                        //// --------------- ADD START 2013/06/20 wangl2 FOR ソースチェック確認事項NO.49の対応 ------>>>>
                                        //if (custPrtParaWork.AcptAnOdrStatus == "-1")
                                        //{
                                        //    custPrtPprWork.AcptAnOdrStatus = new int[] { 20, 30, 40 };
                                        //}
                                        //else 
                                        //{ 
                                        //    custPrtPprWork.AcptAnOdrStatus = new int[] { Convert.ToInt32(custPrtParaWork.AcptAnOdrStatus) };
                                        //}
                                        //if (custPrtParaWork.SalesSlipCd == "-1")
                                        //{
                                        //    custPrtPprWork.SalesSlipCd = new int[] { 0, 1 };
                                        //}

                                        //else
                                        //{
                                        //    custPrtPprWork.SalesSlipCd = new int[] { Convert.ToInt32(custPrtParaWork.SalesSlipCd) };
                                        //}
                                        //// --------------- ADD END 2013/06/20 wangl2 FOR ソースチェック確認事項NO.49の対応 ------<<<<
                                        //// --------------- ADD START 2013/06/25 wangl2 FOR Redmin#37163 ------>>>>
                                        //if (!string.IsNullOrEmpty(custPrtParaWork.CustomerCode))
                                        //{
                                        //    custPrtPprWork.CustomerCode = Convert.ToInt32(custPrtParaWork.CustomerCode);
                                        //}
                                        //else 
                                        //{
                                        //    custPrtPprWork.CustomerCode = 0;
                                        //}
                                        //// --------------- ADD END 2013/06/25 wangl2 FOR Redmin#37163 ------<<<<
                                        //custPrtPprWork.St_SalesDate = GetDate(Convert.ToInt64(custPrtParaWork.SalesDateSt));
                                        //custPrtPprWork.Ed_SalesDate = GetDate(Convert.ToInt64(custPrtParaWork.SalesDateEd));
                                        //custPrtPprWork.SectionCode = new string[] { custPrtParaWork.SearchSectionCode };
                                        ////custPrtPprWork.SalesSlipCd = new int[] { Convert.ToInt32(custPrtParaWork.SalesSlipCd) };// DEL 2013/06/20 wangl2 FOR ソースチェック確認事項NO.49の対応
                                        //custPrtPprWork.SearchType = Convert.ToInt32(custPrtParaWork.SalesDepoDiv);
                                        //custPrtPprWork.SearchType++; // ADD 2013/06/20 wangl2 FOR ソースチェック確認事項NO.49の対応
                                        //string[] param = data.Param.Split(new char[1] { ':' });

                                        //string pmTabSearchGuid = param[0];

                                        //int notifyCount = 0;
                                        //// 通知件数: TabletPushDataクラスプロパティのパラメータの２番目
                                        //if (param.Length >= 2)
                                        //{
                                        //    notifyCount = Convert.ToInt32(param[1]);
                                        //}

                                        //#endregion
                                       
                                        //// タブレットログ対応　--------------------------------->>>>>
                                        //EasyLogger.Write(CLASS_NAME, methodName, "自動回答処理（得意先電子元帳）");
                                        //EasyLogger.Write(CLASS_NAME, methodName,
                                        //    "企業コード：" + enterpriseCode
                                        //    + "  拠点コード：" + sectionCode
                                        //    + "  業務セッションID：" + sessionid
                                        //    + "  検索条件.AcptAnOdrStatus：" + EasyLogger.LogUtlIntAryToCsv(custPrtPprWork.AcptAnOdrStatus)
                                        //    + "  検索条件.St_SalesDate：" + custPrtPprWork.St_SalesDate.ToString()
                                        //    + "  検索条件.Ed_SalesDate：" + custPrtPprWork.Ed_SalesDate.ToString()
                                        //    + "  検索条件.SectionCode：" + string.Join(",", custPrtPprWork.SectionCode)
                                        //    + "  検索条件.SalesSlipCd：" + EasyLogger.LogUtlIntAryToCsv(custPrtPprWork.SalesSlipCd)
                                        //    + "  検索条件.SearchType：" + custPrtPprWork.SearchType.ToString()
                                        //    + "  検索条件.CustomerCode：" + custPrtPprWork.CustomerCode.ToString() // ADD 2013/06/25 wangl2 FOR Redmin#37163
                                        //    + "  PMTAB検索GUID：" + pmTabSearchGuid
                                        //    + "  通知件数：" + notifyCount.ToString()
                                        //    );
                                        //// タブレットログ対応　---------------------------------<<<<<

                                        //// PMTAB 自動回答処理(得意先電子元帳)
                                        //status = custPrtSlipTabSearchAcs.SearchPmToScm(enterpriseCode, sectionCode, custPrtPprWork, pmTabSearchGuid, notifyCount, out message);
                                        // --- DEL 2013/08/23 三戸 各処理非同期対応 ---------<<<<<<<<<<<<<<<<<<<<<<<<
                                        #endregion


                                        // --- ADD 2013/08/23 三戸 各処理非同期対応 --------->>>>>>>>>>>>>>>>>>>>>>>>
                                        #region パラメータ分解
                                        // 検索条件: TabletPushDataクラスプロパティの検索条件
                                        string jsonString = data.SearchCondition.ToString();
                                        DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(CustPrtParaWork));
                                        MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(jsonString));
                                        CustPrtParaWork custPrtParaWork = (CustPrtParaWork)ser.ReadObject(ms);
                                        CustPrtPprWork custPrtPprWork = new CustPrtPprWork();
                                        if (custPrtParaWork.AcptAnOdrStatus == "-1")
                                        {
                                            custPrtPprWork.AcptAnOdrStatus = new int[] { 20, 30, 40 };
                                        }
                                        else
                                        {
                                            custPrtPprWork.AcptAnOdrStatus = new int[] { Convert.ToInt32(custPrtParaWork.AcptAnOdrStatus) };
                                        }
                                        if (custPrtParaWork.SalesSlipCd == "-1")
                                        {
                                            custPrtPprWork.SalesSlipCd = new int[] { 0, 1 };
                                        }

                                        else
                                        {
                                            custPrtPprWork.SalesSlipCd = new int[] { Convert.ToInt32(custPrtParaWork.SalesSlipCd) };
                                        }
                                        if (!string.IsNullOrEmpty(custPrtParaWork.CustomerCode))
                                        {
                                            custPrtPprWork.CustomerCode = Convert.ToInt32(custPrtParaWork.CustomerCode);
                                        }
                                        else
                                        {
                                            custPrtPprWork.CustomerCode = 0;
                                        }
                                        custPrtPprWork.St_SalesDate = GetDate(Convert.ToInt64(custPrtParaWork.SalesDateSt));
                                        custPrtPprWork.Ed_SalesDate = GetDate(Convert.ToInt64(custPrtParaWork.SalesDateEd));
                                        custPrtPprWork.SectionCode = new string[] { custPrtParaWork.SearchSectionCode };
                                        custPrtPprWork.SearchType = Convert.ToInt32(custPrtParaWork.SalesDepoDiv);
                                        custPrtPprWork.SearchType++;
                                        string[] param = data.Param.Split(new char[1] { ':' });

                                        string pmTabSearchGuid = param[0];

                                        int notifyCount = 0;
                                        // 通知件数: TabletPushDataクラスプロパティのパラメータの２番目
                                        if (param.Length >= 2)
                                        {
                                            notifyCount = Convert.ToInt32(param[1]);
                                        }
                                        #endregion

                                        EasyLogger.Name = DEFAULT_NAME;
                                        EasyLogger.Write(CLASS_NAME, methodName, "自動回答処理（得意先電子元帳）");
                                        EasyLogger.Write(CLASS_NAME, methodName,
                                            "企業コード：" + data.EnterpriseCode
                                            + "  拠点コード：" + data.SectionCode
                                            + "  業務セッションID：" + data.SessionId
                                            + "  検索条件.AcptAnOdrStatus：" + EasyLogger.LogUtlIntAryToCsv(custPrtPprWork.AcptAnOdrStatus)
                                            + "  検索条件.St_SalesDate：" + custPrtPprWork.St_SalesDate.ToString()
                                            + "  検索条件.Ed_SalesDate：" + custPrtPprWork.Ed_SalesDate.ToString()
                                            + "  検索条件.SectionCode：" + string.Join(",", custPrtPprWork.SectionCode)
                                            + "  検索条件.SalesSlipCd：" + EasyLogger.LogUtlIntAryToCsv(custPrtPprWork.SalesSlipCd)
                                            + "  検索条件.SearchType：" + custPrtPprWork.SearchType.ToString()
                                            + "  検索条件.CustomerCode：" + custPrtPprWork.CustomerCode.ToString() // ADD 2013/06/25 wangl2 FOR Redmin#37163
                                            + "  PMTAB検索GUID：" + pmTabSearchGuid
                                            + "  通知件数：" + notifyCount.ToString()
                                            );

                                        autoAnswerSlipListAsyncCall caller = autoAnswerSlipList;
                                        IAsyncResult result = caller.BeginInvoke(methodName, data.EnterpriseCode, data.SectionCode, data.SessionId, custPrtPprWork, pmTabSearchGuid, notifyCount, null, null); //非同期呼び出し開始
                                        // --- ADD 2013/08/23 三戸 各処理非同期対応 ---------<<<<<<<<<<<<<<<<<<<<<<<<

                                        break;
                                    }
                            }

                            // --- DEL 2013/08/23 三戸 各処理非同期対応 --------->>>>>>>>>>>>>>>>>>>>>>>>
                            //// WebSyncに通知する
                            //// UPD 2013/08/16 吉岡 Redmine#39972 ------------>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                            //// this.NotifyTabletByPublish(status, message, sessionid);
                            //// 自動回答処理（データ登録）の場合は、PMTAB00152Aで通知を返すので、ここでは実施しない
                            //if (!data.ProcKind.Equals(AUTO_ANSWER_DATA_CREATE))
                            //{
                            //    this.NotifyTabletByPublish(status, message, sessionid);
                            //}
                            //// UPD 2013/08/16 吉岡 Redmine#39972 ------------<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                            // --- DEL 2013/08/23 三戸 各処理非同期対応 ---------<<<<<<<<<<<<<<<<<<<<<<<<

                        }));
                        // UPD 2013/07/29 吉岡 ログ見直し----------------------->>>>>>>>>>>>>>>>>>>>>>>>>>>>
                        //// タブレットログ対応　--------------------------------->>>>>
                        //EasyLogger.Write(CLASS_NAME, methodName, "▲▲▲▲▲常駐自動回答処理　終了▲▲▲▲▲");
                        //// タブレットログ対応　---------------------------------<<<<<
                        EasyLogger.Name = DEFAULT_NAME;
                        EasyLogger.Write(CLASS_NAME, methodName, "▲常駐自動回答処理　終了▲");
                        // UPD 2013/07/29 吉岡 ログ見直し-----------------------<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                    }
                 );
                _tabletPushClient.Subscribe<TabletPushData>(subscribeArgs);
            //}// DEL 2013/06/27 wangl2 FOR Redmine#37412
            // タブレットログ対応　--------------------------------->>>>>
                EasyLogger.Name = DEFAULT_NAME;
                EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了");
            // タブレットログ対応　---------------------------------<<<<<
        }

        // --- ADD 2013/08/23 三戸 各処理非同期対応 --------->>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// 非同期デリゲートの定義（設定マスタアップロード）
        /// </summary>
        /// <param name="data"></param>
        /// <param name="methodName"></param>
        delegate void setMastUpLoadAsyncCall(TabletPushData data, string methodName);

        /// <summary>
        /// 非同期デリゲートの定義（自動回答処理（得意先情報））
        /// </summary>
        /// <param name="data"></param>
        /// <param name="methodName"></param>
        delegate void autoAnswerCustInfoAsyncCall(string methodName, string enterpriseCode, string sectionCode, string sessionid, string custNameKana, int custcode, string mngSectionCode, int kanaSearchDiv);

        /// <summary>
        /// 非同期デリゲートの定義（自動回答処理（検索））
        /// </summary>
        /// <param name="data"></param>
        /// <param name="methodName"></param>
        delegate void autoAnswerSearchAsyncCall(string methodName, string enterpriseCode, string sectionCode, string sessionid, string goodNo, int blCode, int custCode, string guidId);

        /// <summary>
        /// 非同期デリゲートの定義（自動回答処理（データ登録））
        /// </summary>
        /// <param name="data"></param>
        /// <param name="methodName"></param>
        delegate void autoAnswerDataCreateAsyncCall(TabletPushData data, string methodName);

        /// <summary>
        /// 非同期デリゲートの定義（自動回答処理（得意先電子元帳））
        /// </summary>
        /// <param name="data"></param>
        /// <param name="methodName"></param>
        delegate void autoAnswerSlipListAsyncCall(string methodName, string enterpriseCode, string sectionCode, string sessionid, CustPrtPprWork custPrtPprWork, string pmTabSearchGuid, int notifyCount);

        // ADD 2013/10/08 SCM仕掛一覧№10579対応 ------------------------------->>>>>
        /// <summary>
        /// 非同期デリゲートの定義（商品検索アクセスクラスキャッシュ処理）
        /// </summary>
        /// <param name="data"></param>
        /// <param name="methodName"></param>
        delegate void searchInitialAsyncCall();
        // ADD 2013/10/08 SCM仕掛一覧№10579対応 -------------------------------<<<<<

        /// <summary>
        /// 設定マスタアップロード呼び出し
        /// </summary>
        /// <param name="data"></param>
        /// <param name="methodName"></param>
        private void setMastUpLoad(TabletPushData data, string methodName)
        {
            System.Threading.Monitor.Enter(setMastUpLoadLock);
            try
            {
                PMTabSCMUpLoadMastAcs pmTabSCMUpLoadMastAcs = new PMTabSCMUpLoadMastAcs();
                #region パラメータ分解
                // 企業コード: TabletPushDataクラスプロパティの企業コード
                string enterpriseCode = data.EnterpriseCode;
                // 拠点コード: TabletPushDataクラスプロパティの拠点コード
                string sectionCode = data.SectionCode;
                string message = string.Empty;
                string sessionid = data.SessionId;
                #endregion

                // 自動回答処理（設定マスタ）を呼び出す
                int status = pmTabSCMUpLoadMastAcs.PMTabMastSCMUpLoad(enterpriseCode, sectionCode);

                this.NotifyTabletByPublish(status, message, sessionid);
            }
            finally
            {
                System.Threading.Monitor.Exit(setMastUpLoadLock);
            }
        }

        /// <summary>
        /// 自動回答処理（得意先情報）呼び出し
        /// </summary>
        /// <param name="data"></param>
        /// <param name="methodName"></param>
        private void autoAnswerCustInfo(string methodName, string enterpriseCode, string sectionCode, string sessionid, string custNameKana, int custcode, string mngSectionCode, int kanaSearchDiv)
        {
            System.Threading.Monitor.Enter(autoAnswerCustInfoLock);
            try
            {
                TabSCMCustomerAcs tabSCMCustomerAcs = new TabSCMCustomerAcs();

                string message = string.Empty;

                // 自動回答処理（得意先情報）を呼び出す
                int status = tabSCMCustomerAcs.SearchCustomerDataForTablet(enterpriseCode, sectionCode, sessionid, custNameKana, custcode, mngSectionCode, kanaSearchDiv, out message);

                this.NotifyTabletByPublish(status, message, sessionid);

                // ADD 2013/10/08 SCM仕掛一覧№10579対応 ------------------------------->>>>>
                // 商品検索アクセスクラスのキャッシュ処理
                searchInitialAsyncCall caller = SearchInitial;
                IAsyncResult result = caller.BeginInvoke(null, null);  //非同期呼び出し開始
                // ADD 2013/10/08 SCM仕掛一覧№10579対応 -------------------------------<<<<<

            }
            finally
            {
                System.Threading.Monitor.Exit(autoAnswerCustInfoLock);
            }
        }

        // ADD 2013/10/08 SCM仕掛一覧№10579対応 ------------------------------->>>>>
        /// <summary>
        ///  商品検索アクセスクラスキャッシュ処理
        /// </summary>
        public void SearchInitial()
        {
            System.Threading.Monitor.Enter(searchInitialLock);
            try
            {
                string msg = string.Empty;
                // 商品検索アクセスクラスキャッシュ対象
                if (_cacheInitType == 1)
                {
                    if (_cacheInUsedType == 2)
                    {
                        // ２番目のクラスが使用中のため１番目のクラスにキャッシュします
                        _goodsAccesser1 = new GoodsAcs(LoginInfoAcquisition.Employee.BelongSectionCode);
                        // 商品検索アクセスクラスキャッシュ処理
                        _goodsAccesser1.SearchInitial(LoginInfoAcquisition.EnterpriseCode, LoginInfoAcquisition.Employee.BelongSectionCode, out msg);
                        // １番目をキャッシュ済
                        _cacheInitType = 1;
                    }
                    else
                    {
                        // １番目がキャッシュ済のため２番目にキャッシュします
                        _goodsAccesser2 = new GoodsAcs(LoginInfoAcquisition.Employee.BelongSectionCode);
                        // 商品検索アクセスクラスキャッシュ処理
                        _goodsAccesser2.SearchInitial(LoginInfoAcquisition.EnterpriseCode, LoginInfoAcquisition.Employee.BelongSectionCode, out msg);
                        // ２番目をキャッシュ済
                        _cacheInitType = 2;
                    }
                }
                else
                {
                    if (_cacheInUsedType == 1)
                    {
                        // １番目のクラスが使用中のため２番目のクラスにキャッシュします
                        _goodsAccesser2 = new GoodsAcs(LoginInfoAcquisition.Employee.BelongSectionCode);
                        // 商品検索アクセスクラスキャッシュ処理
                        _goodsAccesser2.SearchInitial(LoginInfoAcquisition.EnterpriseCode, LoginInfoAcquisition.Employee.BelongSectionCode, out msg);
                        // ２番目をキャッシュ済
                        _cacheInitType = 2;
                    }
                    else
                    {
                        // ２番目がキャッシュ済のため１番目にキャッシュします
                        _goodsAccesser1 = new GoodsAcs(LoginInfoAcquisition.Employee.BelongSectionCode);
                        // 商品検索アクセスクラスキャッシュ処理
                        _goodsAccesser1.SearchInitial(LoginInfoAcquisition.EnterpriseCode, LoginInfoAcquisition.Employee.BelongSectionCode, out msg);
                        // １番目をキャッシュ済
                        _cacheInitType = 1;
                    }
                }
                // キャンペーン売価優先設定マスタアクセスクラス
                ArrayList campaignPrcPrStList = new ArrayList();
                _campaignPrcPrStAcs.SearchAll(out campaignPrcPrStList, LoginInfoAcquisition.EnterpriseCode);
                _campaignPrcPrStList = (ArrayList)campaignPrcPrStList.Clone();
            }
            finally
            {
                System.Threading.Monitor.Exit(searchInitialLock);
            }
        }
        // ADD 2013/10/08 SCM仕掛一覧№10579対応 -------------------------------<<<<<

        /// <summary>
        /// 自動回答処理（検索）呼び出し
        /// </summary>
        /// <param name="data"></param>
        /// <param name="methodName"></param>
        private void autoAnswerSearch(string methodName, string enterpriseCode, string sectionCode, string sessionid, string goodNo, int blCode, int custCode, string guidId)
        {
            System.Threading.Monitor.Enter(autoAnswerSearchLock);
            try
            {
                const string methodName2 = "autoAnswerSearch";
                EasyLogger.Name = DEFAULT_NAME;
                EasyLogger.Write(CLASS_NAME, methodName2, "自動回答処理（検索）開始　SessionId：" + sessionid);
                ScmSearchForTablet scmSearchForTablet = new ScmSearchForTablet();

                string message = string.Empty;

                // ADD 2013/10/08 SCM仕掛一覧№10579対応 ------------------------------->>>>>
                scmSearchForTablet.CampaignPrcPrStList = this._campaignPrcPrStList;
                if (_cacheInitType == 1)
                {
                    // １番目のクラスがキャッシュ済
                    scmSearchForTablet.GoodsAccesser = this._goodsAccesser1;
                    // １番目のクラスを使用中
                    _cacheInUsedType = 1;
                }
                else
                {
                    // ２番目のクラスがキャッシュ済
                    scmSearchForTablet.GoodsAccesser = this._goodsAccesser2;
                    // ２番目のクラスを使用中
                    _cacheInUsedType = 2;
                }
                // ADD 2013/10/08 SCM仕掛一覧№10579対応 -------------------------------<<<<<


                // 自動回答処理（検索）を呼び出す
                int status = scmSearchForTablet.SearchForTablet(enterpriseCode, sectionCode, goodNo, blCode, custCode, sessionid, guidId, out message);

                this.NotifyTabletByPublish(status, message, sessionid);

                // ADD 2013/10/08 SCM仕掛一覧№10579対応 ------------------------------->>>>>
                // 使用中フラグを解放
                _cacheInUsedType = 0;
                // ADD 2013/10/08 SCM仕掛一覧№10579対応 -------------------------------<<<<<

            }
            finally
            {
                System.Threading.Monitor.Exit(autoAnswerSearchLock);
            }
        }

        /// <summary>
        /// 自動回答処理（データ登録）呼び出し
        /// </summary>
        /// <param name="data"></param>
        /// <param name="methodName"></param>
        private void autoAnswerDataCreate(TabletPushData data, string methodName)
        {
            System.Threading.Monitor.Enter(autoAnswerDataCreateLock);
            try
            {
                #region パラメータ分解

                // 企業コード: TabletPushDataクラスプロパティの企業コード
                string enterpriseCode = data.EnterpriseCode;

                // 拠点コード: TabletPushDataクラスプロパティの拠点コード
                string sectionCode = data.SectionCode;

                // 業務セッションID: TabletPushDataクラスプロパティの業務セッションID
                string sessionid = data.SessionId;

                string message = string.Empty;

                #endregion

                // ADD 2013/08/26 Redmine#40121 ----------------------------------------->>>>>
                // Tablet端末への返答送信処理
                NotifyTabletByPublish(0, "", data.SessionId, (int)ScmPushDataConstMode.PROCESSING);
                // ADD 2013/08/26 Redmine#40121 -----------------------------------------<<<<<

                TabSCMSalesDataMaker tabSCMSalesDataMaker = new TabSCMSalesDataMaker(Program.argsSave[0] + " " + Program.argsSave[1]);

                resultReply = tabSCMSalesDataMaker.Reply(enterpriseCode, sectionCode, sessionid, out message, out customerInfo);

                // ADD 2013/08/30 Redmine#40121 yugami ------------------------------------------>>>>>
                // 売上情報登録の提示をポップアップ
                if (resultReply == ConstantManagement.MethodResult.ctFNC_NORMAL && null != customerInfo)
                {
                    this._dataTable.Rows[0][ctColumnName_CustomerCdName] = BLANK + customerInfo.CustomerCode + " " + customerInfo.CustomerSnm;

                    AppSettingsSection appSettingSection = GetAppSettingsSection();
                    if (appSettingSection.Settings[CT_Conf_SaleSlipCreateView].Value.Equals("1"))
                    {
                        this.ShowPopup(this, new ReceivedEventArgs());
                    }
                }

                // sessionIdディクショナリより除外
                System.Threading.Monitor.Enter(sessionIdDicLock);
                try
                {
                    this._sessionIdDic.Remove(data.SessionId);
                }
                finally
                {
                    System.Threading.Monitor.Exit(sessionIdDicLock);
                }
                // ADD 2013/08/30 Redmine#40121 yugami ------------------------------------------<<<<<

            }
            finally
            {
                System.Threading.Monitor.Exit(autoAnswerDataCreateLock);
            }
        }

        /// <summary>
        /// 自動回答処理（データ登録）完了コールバック
        /// </summary>
        /// <param name="data"></param>
        /// <param name="methodName"></param>
        private void autoAnswerDataCreateCallback(IAsyncResult result)
        {
            // DEL 2013/08/30 Redmine#40121 yugami ------------------------------------------------------->>>>>
            // 売上情報登録の提示をポップアップ
            //if (resultReply == ConstantManagement.MethodResult.ctFNC_NORMAL && null != customerInfo)
            //{
            //    this._dataTable.Rows[0][ctColumnName_CustomerCdName] = BLANK + customerInfo.CustomerCode + " " + customerInfo.CustomerSnm;

            //    AppSettingsSection appSettingSection = GetAppSettingsSection();
            //    if (appSettingSection.Settings[CT_Conf_SaleSlipCreateView].Value.Equals("1"))
            //    {
            //        this.ShowPopup(this, new ReceivedEventArgs());
            //    }
            //}
            // DEL 2013/08/30 Redmine#40121 yugami -------------------------------------------------------<<<<<

        }

        /// <summary>
        /// 自動回答処理（得意先電子元帳）呼び出し
        /// </summary>
        /// <param name="data"></param>
        /// <param name="methodName"></param>
        private void autoAnswerSlipList(string methodName, string enterpriseCode, string sectionCode, string sessionid, CustPrtPprWork custPrtPprWork, string pmTabSearchGuid, int notifyCount)
        {
            System.Threading.Monitor.Enter(autoAnswerSlipListLock);
            try
            {
                CustPrtSlipTabSearchAcs custPrtSlipTabSearchAcs = new CustPrtSlipTabSearchAcs();
                custPrtSlipTabSearchAcs.notifyTabletByPublish += new CustPrtSlipTabSearchAcs.NotifyTabletByPublishEventHandler(NotifyTabletByPublish);
                string message = string.Empty;

                // PMTAB 自動回答処理(得意先電子元帳)
                int status = custPrtSlipTabSearchAcs.SearchPmToScm(enterpriseCode, sectionCode, custPrtPprWork, pmTabSearchGuid, notifyCount, out message);

                this.NotifyTabletByPublish(status, message, sessionid);
            }
            finally
            {
                System.Threading.Monitor.Exit(autoAnswerSlipListLock);
            }
        }
        // --- ADD 2013/08/23 三戸 各処理非同期対応 ---------<<<<<<<<<<<<<<<<<<<<<<<<

        /// <summary>
        /// 指定或いは関連のTablet端末への返答送信処理
        /// </summary>
        /// <param name="destEnterpriseCode">企業コード</param>
        /// <param name="destSectionCode">拠点コード</param>
        /// <param name="inquiryNumber">問い合わせ番号</param>
        private void NotifyTabletByPublish(int status, string message,string sessionId)
        {
            // タブレットログ対応　--------------------------------->>>>>
            const string methodName = "NotifyTabletByPublish";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 開始");
            // タブレットログ対応　---------------------------------<<<<<

            TabletPullData payload = new TabletPullData();
            payload.Status = status;
            payload.Message = message;
            // ADD 2013/08/26 Redmine#40121 ----------------------------------------------->>>>>
            payload.SessionId = sessionId;
            payload.NoticeMode = (int)ScmPushDataConstMode.PROCESSFINISHED;
            // ADD 2013/08/26 Redmine#40121 -----------------------------------------------<<<<<
            
            PublishArgs publishArgs = new PublishArgs();
            publishArgs.Payload = payload;
            // 指定のTablet端末への返答送信処理
            publishArgs.Channel = string.Format("/{0}/PMNS/{1}/{2}/{3}", _tabletPushClient.WEBSYNC_CHANNEL_PMTAB, _enterpriseCode, _sectionCode.Trim(), sessionId);
            _tabletPushClient.Publish(publishArgs);
            // タブレットログ対応　--------------------------------->>>>>
            EasyLogger.Write(CLASS_NAME, methodName,
                "通知内容 Status：" + payload.Status.ToString()
                + "  Message：" + payload.Message
                + "  Channel：" + publishArgs.Channel
                );
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了");
            // タブレットログ対応　---------------------------------<<<<<
        }

        // ADD 2013/08/26 Redmine#40121 ----------------------------------------------->>>>>
        /// <summary>
        ///  指定或いは関連のTablet端末への返答送信処理（通知モード）
        /// </summary>
        /// <param name="status">ステータス</param>
        /// <param name="message">メッセージ</param>
        /// <param name="sessionId">セッションID</param>
        /// <param name="noticeMode">通知モード</param>
        private void NotifyTabletByPublish(int status, string message, string sessionId, int noticeMode)
        {
            // タブレットログ対応　--------------------------------->>>>>
            const string methodName = "NotifyTabletByPublish(NoticeMode)";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 開始");
            // タブレットログ対応　---------------------------------<<<<<

            TabletPullData payload = new TabletPullData();
            payload.Status = status;
            payload.Message = message;
            payload.SessionId = sessionId;
            payload.NoticeMode = noticeMode;

            PublishArgs publishArgs = new PublishArgs();
            publishArgs.Payload = payload;
            // 指定のTablet端末への返答送信処理
            publishArgs.Channel = string.Format("/{0}/PMNS/{1}/{2}/{3}", _tabletPushClient.WEBSYNC_CHANNEL_PMTAB, _enterpriseCode, _sectionCode.Trim(), sessionId);
            _tabletPushClient.Publish(publishArgs);
            // タブレットログ対応　--------------------------------->>>>>
            EasyLogger.Write(CLASS_NAME, methodName,
                "通知内容 Status：" + payload.Status.ToString()
                + "  Message：" + payload.Message
                + "  NoticeMode：" + payload.NoticeMode
                + "  Channel：" + publishArgs.Channel
                );
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了");
            // タブレットログ対応　---------------------------------<<<<<
        }
        // ADD 2013/08/26 Redmine#40121 -----------------------------------------------<<<<<

        /// <summary>
        /// 表示状態を設定します。
        /// </summary>
        /// <param name="visible">表示フラグ</param>
        private void SetVisibleState(bool visible)
        {
            // タブレットログ対応　--------------------------------->>>>>
            const string methodName = "CheckInitialSettings";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 開始");
            // タブレットログ対応　---------------------------------<<<<<

            if (visible)
            {
                SetInitialPosition();
                Visible = true;
                TopMost = true;
                Activate();
                TopMost = false;
            }
            else
            {
                Visible = false;
            }
            // タブレットログ対応　--------------------------------->>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了");
            // タブレットログ対応　---------------------------------<<<<<
        }

        /// <summary>
        /// 初期起動位置を設定します。
        /// </summary>
        private void SetInitialPosition()
        {
            // タブレットログ対応　--------------------------------->>>>>
            const string methodName = "SetInitialPosition";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 開始");
            // タブレットログ対応　---------------------------------<<<<<

            int screenWidth = Screen.PrimaryScreen.WorkingArea.Width;
            int screenheigth = Screen.PrimaryScreen.WorkingArea.Height;
            int appWidth = Width;
            //-----ADD songg 2013/07/01 障害報告 #37530の対応 ---->>>>>
            // 画面の高度再度設定
            int count = 1;
            if((this._dataTable != null) && (this._dataTable.Rows.Count > 0))
            {
                if (this._dataTable.Rows.Count > 5)
                {
                    count = 5;
                }
                else
                {
                    count = this._dataTable.Rows.Count;
                }

                this.Height = ctDefaultFormHeight + (this.dataGridView_Data.RowTemplate.Height * (count - 1));
            }
            else
            {
                this.Height = ctDefaultFormHeight;
            }
            //-----ADD songg 2013/07/01 障害報告 #37530の対応 ----<<<<<
            int appHeight = Height;
            int appLeftXPos = screenWidth - appWidth;
            int appLeftYPos = screenheigth - appHeight;

            SetDesktopBounds(appLeftXPos, appLeftYPos, appWidth, appHeight);
            // タブレットログ対応　--------------------------------->>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了");
            // タブレットログ対応　---------------------------------<<<<<
        }

        /// <summary>
        /// フォームのFormClosingイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void TabletPopupForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // タブレットログ対応　--------------------------------->>>>>
            const string methodName = "TabletPopupForm_FormClosing";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 開始");
            // タブレットログ対応　---------------------------------<<<<<

            if (!CanClose)
            {
                if (e.CloseReason.Equals(CloseReason.UserClosing))
                {
                    // 意図的な終了以外はキャンセルしてアイコン化（フォームを非表示にする）
                    e.Cancel = true; // 終了処理のキャンセル
                    SetVisibleState(false);
                    return;
                }
            }
            // タブレットログ対応　--------------------------------->>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了");
            // タブレットログ対応　---------------------------------<<<<<
        }
        #endregion // </フォーム>

        #region <ポップアップ>

        /// <summary>
        /// 受信スレッド用ポップアップ表示処理コールバック
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private delegate void ShowPopupCallback(object sender, ReceivedEventArgs e);

        /// <summary>
        /// ポップアップを表示します。
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        void ShowPopup(
            object sender,
            ReceivedEventArgs e
        )
        {
            // タブレットログ対応　--------------------------------->>>>>
            const string methodName = "ShowPopup";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 開始");
            // タブレットログ対応　---------------------------------<<<<<

            if (InvokeRequired)
            {
                // 受信スレッドからのイベント処理
                Invoke(new ShowPopupCallback(ShowPopup), new object[] { sender, e });
            }
            else
            {
                SetVisibleState(true);

                this.Refresh();// ADD BY zhujw 2014/06/11 RedMine#42648 Windows8.1動作検証結果_常駐ポップアップ背景が白抜き表示される場合がある 修正
            }
            // タブレットログ対応　--------------------------------->>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了");
            // タブレットログ対応　---------------------------------<<<<<
        }

        #endregion // </ポップアップ>

        #region privateメソッド
        /// <summary>
        /// 得意先名称取得処理
        /// </summary>
        /// <param name="customerCode"></param>
        /// <returns></returns>
        private CustomerInfo GetCustomerInfo(int customerCode)
        {
            // タブレットログ対応　--------------------------------->>>>>
            const string methodName = "GetCustomerInfo";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 開始");
            // タブレットログ対応　---------------------------------<<<<<

            if (_customerInfoAcs == null) _customerInfoAcs = new CustomerInfoAcs();

            CustomerInfo cust;

            int status = _customerInfoAcs.ReadDBData(LoginInfoAcquisition.EnterpriseCode, customerCode, out cust);

            // タブレットログ対応　--------------------------------->>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了");
            // タブレットログ対応　---------------------------------<<<<<
            if (status == 0 && cust != null)
            {
                return cust;
            }
            else
            {
                return new CustomerInfo();
            }
        }

        /// <summary>
        /// 画面 Paintイベント（ダブルバッファリングにより、画面サイズ変更時に発生する）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TabletPopupForm_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            //たてに白から黒へのグラデーションのブラシを作成
            //g.VisibleClipBoundsは表示クリッピング領域に外接する四角形
            LinearGradientBrush gb = new LinearGradientBrush(
                    panel_Info.Bounds,
                    Color.Black,
                    Color.Gray,
                    LinearGradientMode.Vertical);

            // 四角を描く
            g.FillRectangle(gb, panel_Info.Bounds);
            gb.Dispose();
            g.Dispose();
        }

        /// <summary>
        /// 文字列　バイト数指定切り抜き（Left [12345]678→12345）
        /// </summary>
        /// <param name="orgString">元の文字列</param>
        /// <param name="byteCount">バイト数</param>
        /// <returns>指定バイト数で切り抜いた文字列</returns>
        private static string SubStringOfByteLeft(string orgString, int byteCount)
        {
            // タブレットログ対応　--------------------------------->>>>>
            const string methodName = "SubStringOfByteLeft";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 開始");
            // タブレットログ対応　---------------------------------<<<<<

            Encoding _sjisEnc = Encoding.GetEncoding("Shift_JIS");
            string resultString = string.Empty;

            // あらかじめ「文字数」を指定して切り抜いておく
            // (この段階でbyte数は<文字数>～2*<文字数>の間になる)
            orgString = orgString.PadRight(byteCount).Substring(0, byteCount);

            int count;

            for (int i = orgString.Length; i >= 0; i--)
            {
                // 「文字数」を減らす
                resultString = orgString.Substring(0, i);

                // バイト数を取得して判定
                count = _sjisEnc.GetByteCount(resultString);
                if (count <= byteCount) break;
            }

            int nowlength = _sjisEnc.GetByteCount(resultString);
            if (nowlength < byteCount)
            {
                for (int x = 0; x < byteCount - nowlength; x++)
                {
                    resultString += " ";
                }
            }

            // タブレットログ対応　--------------------------------->>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了");
            // タブレットログ対応　---------------------------------<<<<<
            return resultString;
        }

        /// <summary>
        /// [設定]メニューアイテムのClickイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void setToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // タブレットログ対応　--------------------------------->>>>>
            const string methodName = "setToolStripMenuItem_Click";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 開始");
            // タブレットログ対応　---------------------------------<<<<<

            if (null == _form)
            {
                this._form = new PMTAB00100UC();
            }
            this._form.Owner = this;
            
            this._form.ShowDialog();

            AppSettingsSection appSettingSection = GetAppSettingsSection();

            int count = 0;
            if (this._dataTable.Rows.Count >= 5)
            {
                count = 5;
            }
            else
            {
                count = this._dataTable.Rows.Count;
            }

            if (appSettingSection.Settings[CT_Conf_SaleSlipCreateView].Value.Equals("1"))
            {
                this._visbleFlg = true;
                if (this._visbleFlg)
                {
                    //this.lblInformation.Text = string.Format(MSG_NEW_ORDER, this._dataTable.Rows.Count + 1);
                }
                this.Height = ctDefaultFormHeight + (this.dataGridView_Data.RowTemplate.Height * count) + 50;
            }
            else
            {
                this._visbleFlg = false;
                //this.lblInformation.Text = string.Format(MSG_NEW_ORDER, this._dataTable.Rows.Count);
                this.Height = ctDefaultFormHeight + (this.dataGridView_Data.RowTemplate.Height * count);
            }
            // タブレットログ対応　--------------------------------->>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了");
            // タブレットログ対応　---------------------------------<<<<<
        }

        /// <summary>
        /// ConfigurationSection取得処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : ConfigurationSection取得処理を行います。</br>
        /// </remarks>
        private AppSettingsSection GetAppSettingsSection()
        {
            // タブレットログ対応　--------------------------------->>>>>
            const string methodName = "GetAppSettingsSection";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 開始");
            // タブレットログ対応　---------------------------------<<<<<

            ExeConfigurationFileMap file = new ExeConfigurationFileMap();

            file.ExeConfigFilename = Exe_Conf_Filename;
            Configuration config = ConfigurationManager.OpenMappedExeConfiguration(file, ConfigurationUserLevel.None);

            // タブレットログ対応　--------------------------------->>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了");
            // タブレットログ対応　---------------------------------<<<<<
            return (AppSettingsSection)config.GetSection(App_Set_Section);
        }

        /// <summary>
        /// [閉じる]メニューアイテムのClickイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // タブレットログ対応　--------------------------------->>>>>
            const string methodName = "closeToolStripMenuItem_Click";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 開始");
            // タブレットログ対応　---------------------------------<<<<<

            DialogResult dResult = TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_QUESTION,
                    this.Name,
                    "受信待機処理も終了します。\r\n" +
                    "終了してもよろしいですか？",
                    0,
                    MessageBoxButtons.YesNo,
                    MessageBoxDefaultButton.Button1);

                if (dResult == DialogResult.No) return;

            CanClose = true;
            Close();
            // タブレットログ対応　--------------------------------->>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了");
            // タブレットログ対応　---------------------------------<<<<<
        }

        /// <summary>
        /// [更新]メニューアイテムのClickイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // タブレットログ対応　--------------------------------->>>>>
            const string methodName = "updateToolStripMenuItem_Click";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 開始");
            // タブレットログ対応　---------------------------------<<<<<

            // 新しいプロセスの起動
            try
            {
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                string fileName = Path.Combine(Directory.GetCurrentDirectory(), CT_Conf_ExeFileName);
                process.StartInfo.FileName = fileName;
                process.StartInfo.Arguments = Program.argsSave[0] + " " + Program.argsSave[1] + " " + Program.RIGHTCLICK;
                process.Start();
            }
            // タブレットログ対応　--------------------------------->>>>>
            // catch (Exception)
            catch (Exception ex)
            {
                EasyLogger.Write(CLASS_NAME, methodName, ex.Message);
            // タブレットログ対応　---------------------------------<<<<<

                MessageBox.Show(ex.Message);
            }
            CanClose = true;
            Close();
            // タブレットログ対応　--------------------------------->>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了");
            // タブレットログ対応　---------------------------------<<<<<
        }
        #endregion

        /// <summary>
        /// 日付フォーマット処理
        /// </summary>
        /// <param name="baseDate">yyyyMMddの日付</param>
        /// <returns>yyyyMMddの時間を戻る</returns>
        /// <remarks>
        /// <br>Note       : 日付フォーマット処理</br>
        /// <br>Programmer : wangl2</br>
        /// <br>Date       : 2013/06/18</br> 
        /// </remarks>
        private DateTime GetDate(long baseDate)
        {
            // タブレットログ対応　--------------------------------->>>>>
            const string methodName = "GetDate";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 開始");
            // タブレットログ対応　---------------------------------<<<<<

            if (baseDate == 0)
            {
                return DateTime.MinValue;

            }
            string datetime = Convert.ToString(baseDate);
            int year, month, day = 0;
            //年月日に分解
            year = int.Parse(datetime.Substring(0, 4));
            month = int.Parse(datetime.Substring(4, 2));
            day = int.Parse(datetime.Substring(6, 2));

            DateTime date = new DateTime(year, month, day);

            // タブレットログ対応　--------------------------------->>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了");
            // タブレットログ対応　---------------------------------<<<<<
            return date;
        }

        // ADD 2013/08/30 Redmine#40121 yugami -------------------------------------------->>>>>
        /// <summary>
        ///  待機時間リセット通知処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void waitTimeReset_Tick(object sender, EventArgs e)
        {
            // sessionIdディクショナリに存在しない時、終了
            if (this._sessionIdDic == null || this._sessionIdDic.Count == 0) return;

            System.Threading.Monitor.Enter(sessionIdDicLock);
            try
            {
                foreach (string key in this._sessionIdDic.Keys)
                {
                    NotifyTabletByPublish(0, "", key, (int)ScmPushDataConstMode.WAITETIMERESET);
                }
            }
            finally
            {
                System.Threading.Monitor.Exit(sessionIdDicLock);
            }
        }
        // ADD 2013/08/30 Redmine#40121 yugami --------------------------------------------<<<<<

        // ADD 2013/10/08 SCM仕掛一覧№10579対応 ------------------------------->>>>>
        /// <summary>
        /// 定刻キャッシュタイマー処理設定
        /// </summary>
        private void CachePunctualTimerSet()
        {
            const string methodName = "CachePunctualTimerSet";
            ExeConfigurationFileMap file = new ExeConfigurationFileMap();

            file.ExeConfigFilename = Exe_Conf_Filename;
            Configuration config = ConfigurationManager.OpenMappedExeConfiguration(file, ConfigurationUserLevel.None);

            DateTime punctualWk = new DateTime();
            if (config.AppSettings.Settings["CachePunctual"] == null ||
                !DateTime.TryParse(config.AppSettings.Settings["CachePunctual"].Value, out punctualWk))
            {
                // デフォルト AM9時
                punctualWk = punctualWk.AddHours(6);
            }

            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 定刻キャッシュ時刻：" + punctualWk.ToString("HH:mm"));


            // 1年1月1日＋定刻
            punctual = new DateTime(1, 1, 1, punctualWk.Hour, punctualWk.Minute, punctualWk.Second, punctualWk.Millisecond);

            this.timer.Interval = GetPunctualInterval();
            // タイマースタート
            this.timer.Tick += new EventHandler(CachePunctual);
            this.timer.Start();
        }

        /// <summary>
        /// 定刻キャッシュタイマー用 インターバル取得
        /// </summary>
        /// <returns></returns>
        private int GetPunctualInterval()
        {
            // 1年1月1日＋現在時刻
            DateTime now = new DateTime(1, 1, 1, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second, DateTime.Now.Millisecond);

            if (punctual <= now)
            {
                punctual = punctual.AddDays(1);
            }

            // 次の定刻までの差分を取得し、タイマーのインターバルにセット
            System.TimeSpan dif = punctual - now;
            return (int)dif.TotalMilliseconds;
        }

        /// <summary>
        /// 定刻キャッシュタイマー処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CachePunctual(object sender, EventArgs e)
        {
            // 初回以降は24時間後
            timer.Interval = GetPunctualInterval();
            
            // キャッシュ処理
            SearchInitial();
        }
        // ADD 2013/10/08 SCM仕掛一覧№10579対応 -------------------------------<<<<<

    }

    /// <summary>
    /// 
    /// </summary>
    public class CustPrtParaWork 
    {
        /// <summary>開始売上日付</summary>
        /// <remarks>YYYYMMDD</remarks>
        private string _salesDateSt;

        /// <summary>終了売上日付</summary>
        /// <remarks>YYYYMMDD</remarks>
        private string _salesDateEd;

        /// <summary>拠点コード</summary>
        /// <remarks>(配列)　全社指定は{""}</remarks>
        private string _searchSectionCode;

        /// <summary>検索タイプ</summary>
        /// <remarks>(配列)　全指定の場合は{""}</remarks>
        private string _salesDepoDiv;

        /// <summary>受注ステータス</summary>
        /// <remarks>(配列)　全指定の場合は{""}</remarks>
        private string _acptAnOdrStatus;

        /// <summary>売上伝票区分</summary>
        /// <remarks>(配列)　全指定の場合は{""}</remarks>
        private string _salesSlipCd;
        // --------------- ADD START 2013/06/25 wangl2 FOR Redmin#37163 ------>>>>
        /// <summary>得意先コード</summary>
        private string _customerCode;
        // --------------- ADD END 2013/06/25 wangl2 FOR Redmin#37163 ------<<<<

        /// public propaty name  :  SalesDateSt
        /// <summary>開始売上日付プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始売上日付プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SalesDateSt
        {
            get { return _salesDateSt; }
            set { _salesDateSt = value; }
        }

        // --------------- ADD START 2013/06/25 wangl2 FOR Redmin#37163 ------>>>>
        /// public propaty name  :  CustomerCode
        /// <summary>得意先コード</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始売上日付プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CustomerCode
        {
            get { return _customerCode; }
            set { _customerCode = value; }
        }
        // --------------- ADD END 2013/06/25 wangl2 FOR Redmin#37163 ------<<<<

        /// public propaty name  :  SalesDateEd
        /// <summary>終了売上日付プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了売上日付プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SalesDateEd
        {
            get { return _salesDateEd; }
            set { _salesDateEd = value; }
        }

        /// public propaty name  :  SearchSectionCode
        /// <summary>拠点コードプロパティ</summary>
        /// <value>(配列)　全社指定は{""}</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SearchSectionCode
        {
            get { return _searchSectionCode; }
            set { _searchSectionCode = value; }
        }

        /// public propaty name  :  SalesDepoDiv
        /// <summary>受注ステータスプロパティ</summary>
        /// <value>(配列)　全指定の場合は{""}</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   受注ステータスプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SalesDepoDiv
        {
            get { return _salesDepoDiv; }
            set { _salesDepoDiv = value; }
        }

        /// public propaty name  :  AcptAnOdrStatus
        /// <summary>受注ステータスプロパティ</summary>
        /// <value>(配列)　全指定の場合は{""}</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   受注ステータスプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AcptAnOdrStatus
        {
            get { return _acptAnOdrStatus; }
            set { _acptAnOdrStatus = value; }
        }

        /// public propaty name  :  SalesSlipCd
        /// <summary>検索タイプ</summary>
        /// <value>(配列)　全指定の場合は{""}</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   検索タイプ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SalesSlipCd
        {
            get { return _salesSlipCd; }
            set { _salesSlipCd = value; }
        }

    }

    // --------------- ADD START 2013/07/10 wangl2 FOR Redmine#38118------>>>>
    /// <summary>
    /// 常駐情報制御クラス
    /// </summary>
    /// <remarks>このクライアントで常駐情報制御クラスです。</remarks>
    internal class ResidentController
    {
        private PosTerminalMg _posTerminalMg;

        private ArrayList _arrayList;

        private const string CLASS_NAME = "NewArrNtfyController";
        public PosTerminalMg PosTerminalMg
        {
            get { return _posTerminalMg; }
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public ResidentController()
        {
        }

        /// <summary>
        /// 設定読み込み(全件)
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        public void SearchSetting(string enterpriseCode, string sectionCode)
        {
            const string methodName = "SearchSetting";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 開始");
            try
            {
                # region [自端末の端末番号を取得]
                // 自端末の端末番号を取得
                PosTerminalMgAcs posTerminalMgAcs = new PosTerminalMgAcs();
                int status = posTerminalMgAcs.Search(out _posTerminalMg, enterpriseCode);
                # endregion

                # region [全体設定マスタ(拠点別)]
                // 全体設定マスタ(拠点別)の端末番号を取得
                if (status == (int)Broadleaf.Library.Resources.ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    PmTabTtlStSecAcs pmTabTtlStSecAcs = new PmTabTtlStSecAcs();
                    status = pmTabTtlStSecAcs.Search(out _arrayList,enterpriseCode,sectionCode);
                    if (status != (int)Broadleaf.Library.Resources.ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        status = pmTabTtlStSecAcs.Search(out _arrayList, enterpriseCode, "00");
                    }

                }
                #endregion

            }
            catch
            {

            }

            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了");
        }

        /// <summary>
        /// マッチング判定処理
        /// </summary>
        // UPD 2013/08/01 吉岡 Redmine#39489 --------->>>>>>>>>>>>>>>>>>>>>>>>>
        // public bool Match()
        public bool Match(string enterpriseCode, string sectionCode)
        // UPD 2013/08/01 吉岡 Redmine#39489 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
        {
            const string methodName = "Match";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 開始");

            // ADD 2013/08/01 吉岡 Redmine#39489 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            _arrayList = null;
            SearchSetting(enterpriseCode, sectionCode);
            // ADD 2013/08/01 吉岡 Redmine#39489 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

            // 端末管理設定
            if (_posTerminalMg == null)
            {
                return false;
            }

            if (_arrayList == null)
            {
                return false;
            }

            foreach (PmTabTtlStSec pmTabTtlStSec in _arrayList)
            {
                if (pmTabTtlStSec.CashRegisterNo == _posTerminalMg.CashRegisterNo)
                {
                    return true;
                }
            }
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了");
            return false;
        }
    }
    // --------------- ADD END 2013/07/10 wangl2 FOR Redmine#38118--------<<<<

}
