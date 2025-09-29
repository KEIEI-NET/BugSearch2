//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 出品一括更新
// プログラム概要   : 出品一括更新
//----------------------------------------------------------------------------//
//                (c)Copyright  2016 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号 : 11270001-00  作成担当 : 宋剛
// 作 成 日 : 2016/01/22   修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号 : 11270001-00  作成担当 : 宋剛
// 作 成 日 : 2016/02/15   修正内容 : Redmine#48629の#59の　CSVファイルがオープンされている障害対応
//----------------------------------------------------------------------------//
// 管理番号 : 11270001-00  作成担当 : 宋剛
// 作 成 日 : 2016/02/15   修正内容 : Redmine#48629の#64の　売価率と単価の整数出力対応
//----------------------------------------------------------------------------//
// 管理番号 : 11270001-00  作成担当 : 宋剛
// 作 成 日 : 2016/02/15   修正内容 : Redmine#48629の障害一覧No.2の　販売単価と売価率の「未満」仕様変更対応
//----------------------------------------------------------------------------//
// 管理番号 : 11270001-00  作成担当 : 宋剛
// 作 成 日 : 2016/02/15   修正内容 : Redmine#48629の障害一覧No.10　得意先マスタ.略称対応
//----------------------------------------------------------------------------//
// 管理番号 : 11270001-00  作成担当 : 宋剛
// 作 成 日 : 2016/02/15   修正内容 : Redmine#48629の#70の　販売単価などのカンマは必要ないので削除する
//----------------------------------------------------------------------------//
// 管理番号 : 11270001-00  作成担当 : 宋剛
// 作 成 日 : 2016/02/16   修正内容 : Redmine#48629の障害一覧No.13　出荷数の小数点以下が切り捨てされない仕様変更対応
//----------------------------------------------------------------------------//
// 管理番号 : 11270001-00  作成担当 : 宋剛
// 作 成 日 : 2016/02/16   修正内容 : Redmine#48629の障害一覧No.16　チェックリスト出力先に書き込み不可障害対応
//----------------------------------------------------------------------------//
// 管理番号 : 11270001-00  作成担当 : 宋剛
// 作 成 日 : 2016/02/17   修正内容 : Redmine#48629の障害一覧No.19　仕入先フォーカスを移動すると支払先コード設定障害対応
//----------------------------------------------------------------------------//
// 管理番号 : 11270001-00  作成担当 : 宋剛
// 作 成 日 : 2016/02/19   修正内容 : Redmine#48629の障害一覧No.235　実行状況："成功"⇒"完了"にする。
//----------------------------------------------------------------------------//
// 管理番号 : 11270001-00  作成担当 : 宋剛
// 作 成 日 : 2016/02/19   修正内容 : Redmine#48629の障害一覧No.237　チェック処理に名称にカンマとダブルクウォーテーションが含まれていないか判定処理追加
//----------------------------------------------------------------------------//
// 管理番号 : 11270001-00  作成担当 : 宋剛
// 作 成 日 : 2016/02/19   修正内容 : Redmine#48629の障害一覧No.238　ステータス5の戻りの場合に実行状況ログに記載が行われていない
//----------------------------------------------------------------------------//
// 管理番号 : 11270001-00  作成担当 : 宋剛
// 作 成 日 : 2016/02/19   修正内容 : Redmine#48629の障害一覧No.241　エラー再取込実行時にエラーが表示される障害対応
//----------------------------------------------------------------------------//
// 管理番号 : 11270001-00  作成担当 : 宋剛
// 作 成 日 : 2016/02/19   修正内容 : Redmine#48629の障害一覧No.243　「部品MAXに登録する」を選択すると、「予期せぬエラーが発生しました」が表示された障害対応
//----------------------------------------------------------------------------//
// 管理番号 : 11270001-00  作成担当 : 宋剛
// 作 成 日 : 2016/02/19   修正内容 : Redmine#48629の障害一覧No.244　認証失敗後に中止すると、実行状況が「中止」ではなく「エラー」になる障害対応
//----------------------------------------------------------------------------//
// 管理番号 : 11270001-00  作成担当 : 宋剛
// 作 成 日 : 2016/02/23   修正内容 : LDNS発生した障害　取込むファイルのサイズは0の場合、実行状況のメッセージを出力しない
//----------------------------------------------------------------------------//
// 管理番号 : 11270001-00  作成担当 : 脇田 靖之
// 作 成 日 : 2016/02/24   修正内容 : ①全体配信障害一覧№245　起動後にエラー再取込を行うとエラー発生する障害対応
//                                    ②全体配信障害一覧№248　実行状況ログに出力済みのエラーが再出力される障害対応
//                                    ③全体配信障害一覧№231  部品MAX登録中に画面を終了できてしまう障害対応
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Common;
using Broadleaf.Library.Windows.Forms;
using System.Net.NetworkInformation;
using System.Collections;
using Broadleaf.Application.Remoting.ParamData;
using System.Windows.Forms;
using Infragistics.Win.Misc;
using System.IO;
using Broadleaf.Library.Globarization;
using Broadleaf.Application.Resources;
using System.Configuration;
using System.Threading;
using System.Diagnostics;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 出品・在庫一括更新フォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 出品・在庫一括更新を行います。</br>
    /// <br>Programmer : 宋剛</br>
    /// <br>Date       : 2016/01/22</br>
    /// <br>UpdateNote : 宋剛 2016/02/15</br>
    /// <br>           : Redmine#48629の#59の　CSVファイルがオープンされている障害対応</br>
    /// <br>UpdateNote : 宋剛 2016/02/15</br>
    /// <br>           : Redmine#48629の#64の　売価率と単価の整数出力対応</br>
    /// <br>UpdateNote : 宋剛 2016/02/15</br>
    /// <br>           : Redmine#48629の障害一覧No.2の　販売単価と売価率の「未満」仕様変更対応</br>
    /// <br>UpdateNote : 宋剛 2016/02/15</br>
    /// <br>           : Redmine#48629の障害一覧No.10　得意先マスタ.略称対応</br>
    /// <br>UpdateNote : 宋剛 2016/02/15</br>
    /// <br>           : Redmine#48629の#70の　販売単価などのカンマは必要ないので削除する</br>
    /// <br>UpdateNote : 宋剛 2016/02/16</br>
    /// <br>           : Redmine#48629の障害一覧No.13　出荷数の小数点以下が切り捨てされない仕様変更対応</br>
    /// <br>UpdateNote : 宋剛 2016/02/16</br>
    /// <br>           : Redmine#48629の障害一覧No.16　チェックリスト出力先に書き込み不可障害対応</br>
    /// <br>UpdateNote : 宋剛 2016/02/17</br>
    /// <br>           : Redmine#48629の障害一覧No.19　仕入先フォーカスを移動すると支払先コード設定障害対応</br>
    /// <br>UpdateNote : 宋剛 2016/02/19</br>
    /// <br>           : Redmine#48629の障害一覧No.235　実行状況："成功"⇒"完了"にする。</br>
    /// <br>UpdateNote : 宋剛 2016/02/19</br>
    /// <br>           : Redmine#48629の障害一覧No.237　チェック処理に名称にカンマとダブルクウォーテーションが含まれていないか判定処理追加</br>
    /// <br>UpdateNote : 宋剛 2016/02/19</br>
    /// <br>           : Redmine#48629の障害一覧No.238　ステータス5の戻りの場合に実行状況ログに記載が行われていない</br>
    /// <br>UpdateNote : 宋剛 2016/02/19</br>
    /// <br>           : Redmine#48629の障害一覧No.241　エラー再取込実行時にエラーが表示される障害対応</br>
    /// <br>UpdateNote : 宋剛 2016/02/19</br>
    /// <br>           : Redmine#48629の障害一覧No.243　「部品MAXに登録する」を選択すると、「予期せぬエラーが発生しました」が表示された障害対応</br>
    /// <br>UpdateNote : 宋剛 2016/02/19</br>
    /// <br>           : Redmine#48629の障害一覧No.244　認証失敗後に中止すると、実行状況が「中止」ではなく「エラー」になる障害対応</br>
    /// <br>UpdateNote : 宋剛 2016/02/23</br>
    /// <br>           : LDNS発生した障害　取込むファイルのサイズは0の場合、実行状況のメッセージを出力しない</br>
    /// </remarks>
    public partial class PMMAX02010UB : Form
    {
        # region Private Constant

        private const string SPACE = " ";

        // DEL BY 宋剛 2016/02/15 FOR Redmine#48629の#59の　CSVファイルがオープンされている障害対応 ---->>>>>
        //private const string ct_NOINPUT = "を入力してください。";
        //private const string ct_INPUT_ERROR = "の入力が不正です。";
        //private const string ct_INPUT_OUTOFRANGE = "の範囲指定に誤りがあります。";
        //private const string ct_FILEPATH_ERROR = "指定されたファイルパスが存在しません。";
        //private const string ct_FILEPATH_INVALID = "パスに無効な文字が含まれています。";
        //private const string ct_FILEALRDY_ERROR = "出力先ファイルが他で使用中です。";
        //private const string ct_FILEACCESSERROR = "ファイルへのアクセスが拒否されました。";
        // DEL BY 宋剛 2016/02/15 FOR Redmine#48629の#59の　CSVファイルがオープンされている障害対応----<<<<<
        private const string ct_FILEALRDY_ERROR = "ファイルが使用中か、開いている為処理を実行できません。"; //ADD BY 宋剛 2016/02/15 FOR Redmine#48629の#59の　CSVファイルがオープンされている障害対応
        

        private const string ct_CSVFILTER = "CSVファイル(*.csv)|*.csv";


        private const int DATA_SIZE = 100;

        private const string ct_RUN_MESSAGE01 = "実行中";
        private const string ct_RUN_MESSAGE02 = "中止";
        // UPD BY 宋剛 2016/02/19 FOR Redmine#48629の障害一覧No.235　実行状況："成功"⇒"完了"にする。---->>>>>
        //private const string ct_RUN_MESSAGE03 = "成功";
        private const string ct_RUN_MESSAGE03 = "完了";
        // UPD BY 宋剛 2016/02/19 FOR Redmine#48629の障害一覧No.235　実行状況："成功"⇒"完了"にする。----<<<<<
        private const string ct_RUN_MESSAGE04 = "エラー";
        private const string ct_CANCEL_MESSAGE = "中止ボタンが押されたため、処理を中止します。";
        private const string ct_RESTTIME = "計算中…";

        private const string ARFILENAME = "_出品更新一覧.csv";
        private const string ERRFILENAME = "_出品更新一覧_警告.csv";


        // クラス名
        private const string ct_PRINTNAME = "出品・在庫一括更新";
        private const string ct_PGID = "PMMAX02010UB";

        /// <summary>FocusChangeモード</summary>
        private const int getName_FocusChangeMode = 0;

        /// <summary>XMLファイル読み込みモード</summary>
        private const int getName_XMLReadMode = 1;

        # endregion

        // ===================================================================================== //
        // プライベート変数
        // ===================================================================================== //
        # region Private Members

        // BLCODE情報のDictionary
        private Dictionary<int, BLGoodsCdUMnt> _blCodeDic = new Dictionary<int, BLGoodsCdUMnt>();

        ExportSalesFormSaveItems _saveItemsTemp = new ExportSalesFormSaveItems();

        private PMMAX02000UE _pmmax02000UE;

        private string _loginId;
        private string _password;

        private string _filePath;

        private DataSet _exportDataSet;                    // 出力結果DataSet

        // 初期化アクセス
        // 倉庫情報クセスクラス
        private WarehouseAcs _warehouseAcs = null; 
        //ＢＬ商品マスタアクセスクラス
        private BLGoodsCdAcs _blGoodsCdAcs = null;
        //メーカーマスタアクセスクラス
        private MakerAcs _makerAcs = null;
        // 中分類アクセス
        private GoodsGroupUAcs _goodsGroupUAcs = null;
        // 仕入先アクセス
        private SupplierAcs _supplierAcs;
        private ImageList _imageList16 = null;
        // 企業コード
        private string _enterpriseCode;
        // ログイン拠点コード
        private string _loginSectionCode;
        // 日付取得部品
        private DateGetAcs _dateGetAcs;
        // 初期表示用クラス
        private PMMAX02010UC _pMMAX02010UC;
        private PMMAX02000UC _pMMAX02000UC;
        // 出力条件
        private PartsMaxStockUpdateCndtnWork _searchCond;
        // 検索部品アクセス
        private PartsMaxStockUpdateAcs _partsMaxStockUpdateAcs;
        private Control _prevControl = null;
        // 画面に残り予測時間
        private int _restTime = 0;
        // 規定予測処理時間
        private int _forecastTime = 0;
        // 売価率
        string _salesRateStr = string.Empty;
        // 販売単価
        string _salesPriceStr = string.Empty;
        // 得意先コード
        string _customerCodeStr = string.Empty;
        // BLコード
        string _blCodeStr = string.Empty;
        // メーカーコード
        string _makerCodeStr = string.Empty;
        // 中分類コード
        string _goodsMGroupCodeStr = string.Empty;
        // 商品掛率グループコード
        string _rateGrpCodeStr = string.Empty;
        // 仕入先コード
        string _suppilerCodeStr = string.Empty;
        private BuhinMaxExhibitStockProvider _buhinMaxExhibitStockProvider;

        private string _fileName;
        private string _fileWarningName;

        private Boolean isErrorMsgboxShow = false;
        private System.Threading.Timer _restTimer;
        // ---------- ADD 2016/02/24 Y.Wakita ③ ---------->>>>>
        // 実行フラグ
        private bool _runFlg = false;
        /// <summary>
        /// 実行フラグ
        /// </summary>
        public bool RunFlg
        {
            get { return _runFlg; }
            set { _runFlg = value; }
        }
        // ---------- ADD 2016/02/24 Y.Wakita ③ ----------<<<<<
        # endregion

        // ===================================================================================== //
        // Constructor
        // ===================================================================================== //
        #region Constructor

        /// <summary>
        /// 出品・在庫一括更新フォームクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 出品・在庫一括更新フォームクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 宋剛</br>
        /// <br>Date       : 2016/01/22</br>
        /// </remarks>
        public PMMAX02010UB()
        {
            InitializeComponent();


            // 初期化各種マスタ検索用アクセス
            this._warehouseAcs = new WarehouseAcs();　// 倉庫アクセス
            this._blGoodsCdAcs = new BLGoodsCdAcs();　// BLｺｰﾄﾞアクセス
            this._makerAcs = new MakerAcs();// メーカーアクセス
            this._goodsGroupUAcs = new GoodsGroupUAcs(); // 中分類アクセス
            this._supplierAcs = new SupplierAcs();// 仕入先アクセス

            // 変数初期化
            this._imageList16 = IconResourceManagement.ImageList16;

            this._pmmax02000UE = new PMMAX02000UE();
        }

        /// <summary>
        /// コンストラクタ　Nunit用
        /// </summary>
        /// <param name="param">パラメータ</param>
        /// <remarks>
        /// <br>Note       : 出品・在庫一括更新フォームクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 宋剛</br>
        /// <br>Date       : 2016/01/22</br>
        /// </remarks>
        public PMMAX02010UB(string param)
        {
            try
            {
                if (("NUnit").Equals(param))
                {
                    // 初期化
                    InitializeComponent();
                }
            }
            catch
            {

            }
        }

        #endregion

        // ===================================================================================== //
        // 各コントロールイベント処理
        // ===================================================================================== //
        # region Control Event Methods
        /// <summary>
        /// Form.Load イベント(PMMAX02010UB)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : ユーザーがフォームを読み込むときに発生します。</br>
        /// <br>Programmer : 宋剛</br>
        /// <br>Date       : 2016/01/22</br>
        /// </remarks>
        private void PMMAX02010UB_Load(object sender, EventArgs e)
        {
            this._pMMAX02010UC = new PMMAX02010UC();                    // 初期表示用クラス
            this._pMMAX02000UC = new PMMAX02000UC();                    // 初期表示用クラス
            this._enterpriseCode = _pMMAX02000UC.EnterpriseCode;       // 企業コード
            this._loginSectionCode = _pMMAX02000UC.LoginSectionCode;   // ログイン拠点コード
            this._dateGetAcs = DateGetAcs.GetInstance();                // 日付取得部品
            this._exportDataSet = new DataSet();                        // 出力結果DataSet
            this._searchCond = new PartsMaxStockUpdateCndtnWork();      // 出力条件
            this._partsMaxStockUpdateAcs = new PartsMaxStockUpdateAcs();            // 検索部品アクセス(売価など情報初期化)

            // 画面初期化
            InitialScreenSetting();

            // データセット列情報構築処理
            DataTable dataTable = new DataTable(ExportMoveDataItems.ct_Tbl_Arrival);

            DataTable warningDataTable = new DataTable(ExportMoveDataItems.ct_Tbl_ArrivalWarning);
            // データセット列情報構築処理(CSV出力用データ)
            this.DataSetColumnConstruction(dataTable);
            this.DataSetWarningColumnConstruction(warningDataTable);

            this._buhinMaxExhibitStockProvider = new BuhinMaxExhibitStockProvider(); // 部品MAX連携部品
        }

        /// <summary>
        /// PMMAX02010UB_Shown Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : PMMAX02010UB_Shown Event</br>
        /// <br>Programmer : 宋剛</br>
        /// <br>Date       : 2016/01/22</br>
        /// </remarks>
        private void PMMAX02010UB_Shown(object sender, EventArgs e)
        {
            // 初期化倉庫情報
            InitWareHouseInfo();

            // 初期化BLCode情報
            InitBlCodeList();

            // XMLファイルから画面をセットする
            this.XMLFileToScreen();

            // 初期フォーカス設定
            this.tNedit_CustomerCode.Focus();

            // 初期化パス
            this._filePath = Path.Combine(ConstantManagement_ClientDirectory.NSCurrentDirectory, Path.Combine(ConstantManagement_ClientDirectory.PRTOUT, PMMAX02010UD.CHECKL_FILE_PATH));

            // 出品一括更新一覧ファイル名称
            this._fileName = Path.Combine(this._filePath, DateTime.Now.ToString("yyyyMMdd") + ARFILENAME);
            // 出品一括更新警告一覧ファイル名称
            this._fileWarningName = Path.Combine(this._filePath, DateTime.Now.ToString("yyyyMMdd") + ERRFILENAME);
        }

        /// <summary>
        /// 初期化倉庫情報
        /// </summary>
        private void InitWareHouseInfo()
        {
            this.checkedListBox_Warehouse.Items.Clear();
            ArrayList retList = new ArrayList();
            _warehouseAcs.Search(out retList, this._enterpriseCode);

            this.checkedListBox_Warehouse.BeginUpdate();
            foreach (Warehouse warehouse in retList)
            {
                String key = warehouse.WarehouseCode.Trim() + SPACE + warehouse.WarehouseName.Trim();
                this.checkedListBox_Warehouse.Items.Add(key);
            }
            this.checkedListBox_Warehouse.EndUpdate();


        }

        
        #endregion

        // ===================================================================================== //
        //  Private Methods
        // ===================================================================================== //
        #region Private Methods
        /// <summary>
        /// 初期画面設定
        /// </summary>
        /// <remarks>
        /// <br>Note        : 画面初期化時に発生します。</br>
        /// <br>Programmer  : 宋剛</br>
        /// <br>Date        : 2016/01/22</br>
        /// </remarks> 
        private void InitialScreenSetting()
        {
            this.SetGuidButtonIcon();          // ボタンアイコン設定
            this.InitialScreenData();          // 初期画面データ設定
        }

        /// <summary>
        /// 画面初期化
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面初期化を行う。</br>
        /// <br>Programmer : 宋剛</br>
        /// <br>Date       : 2016/01/22</br>
        /// </remarks>
        private void InitialScreenData()
        {
            this.tNedit_CustomerCode.SetValue(0); // 得意先ｺｰﾄﾞ
            this.uLabel_CustomerName.Text = string.Empty; //得意先名称
            this.checkedListBox_Warehouse.Items.Clear();//倉庫
            this.tDateEdit_LastStockUpdDate.SetDateTime(DateTime.Now);// 在庫最終更新日付
            this.tNedit_BLGoodsCode.SetValue(0);// BLコード
            this.BLtEdit_GoodsName.Text = string.Empty;//BLコード名称
            this.tNedit_GoodsMakerCd.SetValue(0); // 部品メーカー
            this.uLabel_GoodsMakerCd.Text = string.Empty; // 部品メーカー名称
            this.tNedit_GoodsMGroup.SetValue(0); // 中分類ｺｰﾄﾞ
            this.GoodsMGroupName_tEdit.Text = string.Empty; // 中分類名称
            this.tNedit_RateGrpCode.SetValue(0);// 商品掛率G
            this.GoodsRateGrpName_tEdit.Text = string.Empty;// 商品掛率G名称
            this.tNedit_SupplierCd.SetValue(0);　// 仕入先ｺｰﾄﾞ
            this.uLabel_SupplierCd.Text = string.Empty; // 仕入先名称
            this.tDateEdit_priceCalDate.SetDateTime(DateTime.Now); //価格算出日付
            this.tNedit_SalesRate.SetInt(50);// 売価率下限値
            this.tNedit_SalesPrice.SetInt(1);// 販売単価下限値
            this.ultraCheckEditor.Checked = true; // チェックリスト出力選択
            this._password = string.Empty;
            this._loginId = string.Empty;
        }

        /// <summary>
        /// 画面設定値はXMLファイルにセットする
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面設定値はXMLファイルにセットする</br>
        /// <br>Programmer : 宋剛</br>
        /// <br>Date       : 2016/01/22</br>
        /// </remarks>
        private void ScreenItemsToXML()
        {
            // XMLファイルを読み込む
            _pMMAX02010UC.Deserialize();
            ExportSalesData exportSalesDataList = _pMMAX02010UC.ExportSalesDataList;
            // XMLファイルにユーザー情報が存在かどうかのフラグ
            bool checkFileFlag = false;
            if (exportSalesDataList.ExportSalesDataList != null && exportSalesDataList.ExportSalesDataList.Count > 0)
            {
                for (int i = 0; i < exportSalesDataList.ExportSalesDataList.Count; i++)
                {
                    ExportSalesFormSaveItems saveItems = exportSalesDataList.ExportSalesDataList[i];
                    if (saveItems.EnterPriseCode == this._enterpriseCode && saveItems.LoginSectionCode == this._loginSectionCode)
                    {
                        // チェックリスト出力先の設定
                        checkFileFlag = true;
                        // XML保存用項目の設定
                        this.SetItems(ref saveItems);
                        break;
                    }
                }
            }
            // XMLファイルにユーザー情報がある場合
            if (!checkFileFlag)
            {
                // 新しいユーザー情報を追加する
                ExportSalesFormSaveItems formSaveItems = new ExportSalesFormSaveItems();
                // 企業コード
                formSaveItems.EnterPriseCode = this._enterpriseCode;
                // 拠点コード
                formSaveItems.LoginSectionCode = this._loginSectionCode;
                // その他の項目の設定
                this.SetItems(ref formSaveItems);

                exportSalesDataList.ExportSalesDataList.Add(formSaveItems);
            }
            else
            {
                // なし
            }

            // 画面条件をXMLファイルに保存する
            _pMMAX02010UC.Serialize();
        }

        /// <summary>
        /// XMLファイル保存用ワークの作成
        /// </summary>
        /// <remarks>
        /// <br>Note       : XMLファイル保存用ワークの作成</br>
        /// <br>Programmer : 宋剛</br>
        /// <br>Date       : 2016/01/22</br>
        /// </remarks>
        private void SetItems(ref ExportSalesFormSaveItems formSaveItems)
        {
            // 部品MAX得意先
            formSaveItems.MaxCustomerCode = this.tNedit_CustomerCode.Text.Trim();
            // 倉庫コードリスト
            // 全て倉庫がChecked：false
            formSaveItems.WareCodeList = "";
            for (int i = 0; i < this.checkedListBox_Warehouse.Items.Count; i++)
            {
                bool checkedFlag = this.checkedListBox_Warehouse.GetItemChecked(i);

                if (checkedFlag)
                {
                    // Checked項目の倉庫コードを取得する
                    string wareCode = checkedListBox_Warehouse.GetItemText(checkedListBox_Warehouse.Items[i]).Trim().Substring(0, 4);
                    // 初めて倉庫にセットする
                    if (string.IsNullOrEmpty(formSaveItems.WareCodeList))
                    {
                        formSaveItems.WareCodeList = wareCode;
                    }
                    else
                    {
                        formSaveItems.WareCodeList += "," + wareCode;
                    }
                }
            }
            // BLコード
            formSaveItems.BlCode = this.tNedit_BLGoodsCode.Text.Trim();
            // 部品メーカーコード
            formSaveItems.MakerCode = this.tNedit_GoodsMakerCd.Text.Trim();
            // 中分類コード
            formSaveItems.GoodsMGroup = this.tNedit_GoodsMGroup.Text.Trim();
            // 商品掛率グループ
            formSaveItems.RateGrpCode = this.tNedit_RateGrpCode.Text.Trim();
            // 仕入先コード
            formSaveItems.SupplierCd = this.tNedit_SupplierCd.Text.Trim();
            // 売価率下限値
            formSaveItems.SalesRateLow = this.tNedit_SalesRate.GetInt();
            // 販売単価下限値
            formSaveItems.SalesPriceLow = this.tNedit_SalesPrice.GetInt();
            // チェックリスト出力選択
            if (this.ultraCheckEditor.Checked == true)
            {
                formSaveItems.CheckSelect = 1;
            }
            else
            {
                formSaveItems.CheckSelect = 0;
            }
            // チェックリスト出力先の設定
            formSaveItems.CheckFilePath = this._filePath;
        }

        /// <summary>
        /// XMLファイルから画面をセットする
        /// </summary>
        /// <remarks>
        /// <br>Note       : XMLファイルから画面をセットする</br>
        /// <br>Programmer : 宋剛</br>
        /// <br>Date       : 2016/01/22</br>
        /// </remarks>
        private void XMLFileToScreen()
        {
            // XMLファイルを読み込む
            this._pMMAX02010UC.Deserialize();
            ExportSalesData exportSalesDataList = _pMMAX02010UC.ExportSalesDataList;
            // ユーザー情報があるかどうかフラグ
            bool checkFileFlag = false;
            _saveItemsTemp = new ExportSalesFormSaveItems();
            foreach (ExportSalesFormSaveItems saveItems in exportSalesDataList.ExportSalesDataList)
            {
                if (saveItems.EnterPriseCode == this._enterpriseCode && saveItems.LoginSectionCode == this._loginSectionCode)
                {
                    // XMLファイルにユーザー情報がある
                    checkFileFlag = true;
                    // ユーザー情報を保存するクラス
                    _saveItemsTemp = saveItems;
                    break;
                }
            }
            // XMLファイルにユーザー情報がある場合
            if (checkFileFlag)
            {
                // XMLファイルから取得する項目値を画面にセットする
                this.XMLDataToMnue(_saveItemsTemp);
            }
            // XMLファイルにユーザー情報がない場合
            else
            {
                // XMLファイルに画面項目を保存しない場合、画面を初期化する
                this.InitDateToMnue();
            }
        }

        /// <summary>
        /// XMLファイルに画面項目を保存しない場合、画面を初期化する
        /// </summary>
        /// <remarks>
        /// <br>Note        : XMLファイルに画面項目を保存しない場合、画面を初期化する</br>
        /// <br>Programmer  : 宋剛</br>
        /// <br>Date        : 2016/01/22</br>
        /// </remarks>
        public void InitDateToMnue()
        {
            // 部品MAX得意先
            this.tNedit_CustomerCode.Text = string.Empty;
            // 倉庫コードリスト
            // 全て倉庫がChecked：false
            for (int i = 0; i < checkedListBox_Warehouse.Items.Count; i++)
            {
                this.checkedListBox_Warehouse.SetItemChecked(i, false);
            }
            // BLコード
            this.tNedit_BLGoodsCode.Text = string.Empty;
            // 部品メーカーコード
            this.tNedit_GoodsMakerCd.Text = string.Empty;
            // 中分類コード
            this.tNedit_GoodsMGroup.Text = string.Empty;
            // 商品掛率グループ
            this.tNedit_RateGrpCode.Text = string.Empty;
            // 仕入先コード
            this.tNedit_SupplierCd.Text = string.Empty;
            // 売価率下限値
            this.tNedit_SalesRate.SetInt(50);
            // 販売単価下限値
            this.tNedit_SalesPrice.SetInt(1);
            // チェックリスト出力選択
            this.ultraCheckEditor.Checked = true;
        }

        /// <summary>
        /// XMLファイルから取得する項目値を画面にセットする
        /// </summary>
        /// <param name="saveItems">XMLファイルデータ</param>
        /// <remarks>
        /// <br>Note        : XMLファイルから取得する項目値を画面にセットする</br>
        /// <br>Programmer  : 宋剛</br>
        /// <br>Date        : 2016/01/22</br>
        /// </remarks>
        public void XMLDataToMnue(ExportSalesFormSaveItems saveItems)
        {
            // 部品MAX得意先
            this.tNedit_CustomerCode.Text = saveItems.MaxCustomerCode.Trim();
            this._customerCodeStr = saveItems.MaxCustomerCode.Trim();
            if (!string.IsNullOrEmpty(saveItems.MaxCustomerCode.Trim()))
            {
                this.GetCustomerName(this.tNedit_CustomerCode.GetInt(), getName_XMLReadMode);
            }
            // BLコード
            this.tNedit_BLGoodsCode.Text = saveItems.BlCode.Trim();
            this._blCodeStr = saveItems.BlCode.Trim();
            if (!string.IsNullOrEmpty(saveItems.BlCode.Trim()))
            {
                this.GetBlCodeName(this.tNedit_BLGoodsCode.GetInt(), getName_XMLReadMode);
            }
            // 部品メーカーコード
            this.tNedit_GoodsMakerCd.Text = saveItems.MakerCode.Trim();
            this._makerCodeStr = saveItems.MakerCode.Trim();
            if (!string.IsNullOrEmpty(saveItems.MakerCode.Trim()))
            {
                this.GetMakerCodeName(this.tNedit_GoodsMakerCd.GetInt(), getName_XMLReadMode);
            }
            // 中分類コード
            this.tNedit_GoodsMGroup.Text = saveItems.GoodsMGroup.Trim();
            this._goodsMGroupCodeStr = saveItems.GoodsMGroup.Trim();
            if (!string.IsNullOrEmpty(saveItems.GoodsMGroup.Trim()))
            {
                this.GetGoodsGroupUCodeName(this.tNedit_GoodsMGroup.GetInt(), getName_XMLReadMode);
            }
            // 商品掛率グループ
            this.tNedit_RateGrpCode.Text = saveItems.RateGrpCode.Trim();
            this._rateGrpCodeStr = saveItems.RateGrpCode.Trim();
            if (!string.IsNullOrEmpty(saveItems.RateGrpCode.Trim()))
            {
                this.GetGoodsRateGrpCodeName(this.tNedit_RateGrpCode.GetInt(), getName_XMLReadMode);
            }
            // 仕入先コード
            this.tNedit_SupplierCd.Text = saveItems.SupplierCd.Trim();
            this._suppilerCodeStr = saveItems.SupplierCd.Trim();
            if (!string.IsNullOrEmpty(saveItems.SupplierCd.Trim()))
            {
                this.GetSupplierCdName(this.tNedit_SupplierCd.GetInt(), getName_XMLReadMode);
            }
            // 売価率下限値
            this.tNedit_SalesRate.SetInt(saveItems.SalesRateLow);
            this._salesRateStr = saveItems.SalesRateLow.ToString();
            // 販売単価下限値
            this.tNedit_SalesPrice.SetInt(saveItems.SalesPriceLow);
            this._salesPriceStr = saveItems.SalesPriceLow.ToString();
            // チェックリスト出力先
            this._filePath = saveItems.CheckFilePath;
            // チェックリスト出力選択
            if (saveItems.CheckSelect == 0)
            {
                this.ultraCheckEditor.Checked = false;
            }
            else
            {
                this.ultraCheckEditor.Checked = true;
            }
            // 倉庫コードリスト
            if (!string.IsNullOrEmpty(saveItems.WareCodeList.Trim()))
            {
                string[] wareArray = saveItems.WareCodeList.Trim().Split(',');
                Dictionary<string, string> wareDic = new Dictionary<string, string>();
                // 倉庫コードのDictionaryの作成
                foreach (string wareCode in wareArray)
                {
                    if (!wareDic.ContainsKey(wareCode))
                    {
                        wareDic.Add(wareCode, string.Empty);
                    }
                }
                // 前回Checked倉庫がChecked：true
                for (int i = 0; i < checkedListBox_Warehouse.Items.Count; i++)
                {
                    string tempWarehouseCode = checkedListBox_Warehouse.GetItemText(checkedListBox_Warehouse.Items[i]).Trim().Substring(0, 4);
                    if (wareDic.ContainsKey(tempWarehouseCode))
                    {
                        this.checkedListBox_Warehouse.SetItemChecked(i, true);
                    }
                }
            }
        }

        /// <summary>
        /// ガイドボタンのアイコン設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : ガイドボタンのアイコンを設定します。</br>
        /// <br>Programmer  : 宋剛</br>
        /// <br>Date        : 2016/01/22</br>
        /// </remarks>
        private void SetGuidButtonIcon()
        {
            this.uButton_CustomerCode.Appearance.Image = this._imageList16.Images[(int)Size16_Index.STAR1]; // 得意先ガイド
            this.uButton_BLGoodsGuide.Appearance.Image = this._imageList16.Images[(int)Size16_Index.STAR1]; // BLｺｰﾄガイド
            this.uButton_GoodsMakerCd.Appearance.Image = this._imageList16.Images[(int)Size16_Index.STAR1]; // 部品メーカーガイド
            this.uButton_GoodsMGroup.Appearance.Image = this._imageList16.Images[(int)Size16_Index.STAR1]; // 中分類ガイド
            this.uButton_RateGrpCode.Appearance.Image = this._imageList16.Images[(int)Size16_Index.STAR1]; // 商品掛率Gガイド
            this.uButton_SupplierCd.Appearance.Image = this._imageList16.Images[(int)Size16_Index.STAR1]; // 仕入先ガイド
        }

        /// <summary>
        /// データセット列情報構築処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : データセット列情報構築処理を行う。</br>
        /// <br>Programmer  : 宋剛</br>
        /// <br>Date        : 2016/01/22</br>
        /// </remarks>
        private void DataSetColumnConstruction(DataTable dataTable)
        {
            #region 出品更新一覧

            // 企業コード
            DataColumn columnEnterpriseCode = new DataColumn(ExportMoveDataItems.ct_Col_EnterpriseCode, typeof(string));
            columnEnterpriseCode.Caption = "企業コード";
            dataTable.Columns.Add(columnEnterpriseCode);

            // 拠点コード
            DataColumn columnSectionCode = new DataColumn(ExportMoveDataItems.ct_Col_SectionCode, typeof(string));
            columnSectionCode.Caption = "拠点コード";
            dataTable.Columns.Add(columnSectionCode);

            // 倉庫
            DataColumn columnBfEnterWarehCode = new DataColumn(ExportMoveDataItems.ct_Col_WarehCode, typeof(string));
            columnBfEnterWarehCode.Caption = "倉庫コード";
            dataTable.Columns.Add(columnBfEnterWarehCode);

            // 倉庫名
            DataColumn columnBfEnterWarehName = new DataColumn(ExportMoveDataItems.ct_Col_WarehName, typeof(string));
            columnBfEnterWarehName.Caption = "倉庫名";
            dataTable.Columns.Add(columnBfEnterWarehName);

            // 品名
            DataColumn columnGoodsName2 = new DataColumn(ExportMoveDataItems.ct_Col_GoodsName, typeof(string));
            columnGoodsName2.Caption = "品名";
            dataTable.Columns.Add(columnGoodsName2);

            // 品番
            DataColumn columnGoodsNo2 = new DataColumn(ExportMoveDataItems.ct_Col_GoodsNo, typeof(string));
            columnGoodsNo2.Caption = "品番";
            dataTable.Columns.Add(columnGoodsNo2);

            // メーカーコード
            DataColumn columnGoodsMakerCd2 = new DataColumn(ExportMoveDataItems.ct_Col_GoodsMakerCd, typeof(string));
            columnGoodsMakerCd2.Caption = "メーカーコード";
            dataTable.Columns.Add(columnGoodsMakerCd2);

            // メーカー名
            DataColumn columnMakerName2 = new DataColumn(ExportMoveDataItems.ct_Col_MakerName, typeof(string));
            columnMakerName2.Caption = "メーカー名";
            dataTable.Columns.Add(columnMakerName2);

            // BLｺｰﾄﾞ
            DataColumn columnBLGoodsCode2 = new DataColumn(ExportMoveDataItems.ct_Col_BLGoodsCode, typeof(string));
            columnBLGoodsCode2.Caption = "BLコード";
            dataTable.Columns.Add(columnBLGoodsCode2);

            // オープン価格区分
            DataColumn columnOpenPriceDiv = new DataColumn(ExportMoveDataItems.ct_Col_OpenPriceDiv, typeof(string));
            columnOpenPriceDiv.Caption = "オープン価格区分";
            dataTable.Columns.Add(columnOpenPriceDiv);

            // 販売単価
            DataColumn columnSalesPrice = new DataColumn(ExportMoveDataItems.ct_Col_SalesPrice, typeof(string));
            columnSalesPrice.Caption = "販売単価";
            dataTable.Columns.Add(columnSalesPrice);

            // 売価率
            DataColumn columnSalesRate = new DataColumn(ExportMoveDataItems.ct_Col_SalesRate, typeof(string));
            columnSalesRate.Caption = "売価率";
            dataTable.Columns.Add(columnSalesRate);

            // 現在在庫数
            DataColumn columnShipmentCount = new DataColumn(ExportMoveDataItems.ct_Col_ShipmentCount, typeof(string));
            columnShipmentCount.Caption = "現在庫数";
            dataTable.Columns.Add(columnShipmentCount);

            this._exportDataSet.Tables.Add(dataTable);
            #endregion
        }

        /// <summary>
        /// データセット列情報構築処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : データセット列情報構築処理を行う。</br>
        /// <br>Programmer  : 宋剛</br>
        /// <br>Date        : 2016/01/22</br>
        /// </remarks>
        private void DataSetWarningColumnConstruction(DataTable dataTable)
        {
            #region 出品更新一覧

            // 企業コード
            DataColumn columnEnterpriseCode = new DataColumn(ExportMoveDataItems.ct_Col_EnterpriseCode, typeof(string));
            columnEnterpriseCode.Caption = "企業コード";
            dataTable.Columns.Add(columnEnterpriseCode);

            // 拠点コード
            DataColumn columnSectionCode = new DataColumn(ExportMoveDataItems.ct_Col_SectionCode, typeof(string));
            columnSectionCode.Caption = "拠点コード";
            dataTable.Columns.Add(columnSectionCode);

            // 倉庫
            DataColumn columnBfEnterWarehCode = new DataColumn(ExportMoveDataItems.ct_Col_WarehCode, typeof(string));
            columnBfEnterWarehCode.Caption = "倉庫コード";
            dataTable.Columns.Add(columnBfEnterWarehCode);

            // 倉庫名
            DataColumn columnBfEnterWarehName = new DataColumn(ExportMoveDataItems.ct_Col_WarehName, typeof(string));
            columnBfEnterWarehName.Caption = "倉庫名";
            dataTable.Columns.Add(columnBfEnterWarehName);

            // 品名
            DataColumn columnGoodsName2 = new DataColumn(ExportMoveDataItems.ct_Col_GoodsName, typeof(string));
            columnGoodsName2.Caption = "品名";
            dataTable.Columns.Add(columnGoodsName2);

            // 品番
            DataColumn columnGoodsNo2 = new DataColumn(ExportMoveDataItems.ct_Col_GoodsNo, typeof(string));
            columnGoodsNo2.Caption = "品番";
            dataTable.Columns.Add(columnGoodsNo2);

            // メーカーコード
            DataColumn columnGoodsMakerCd2 = new DataColumn(ExportMoveDataItems.ct_Col_GoodsMakerCd, typeof(string));
            columnGoodsMakerCd2.Caption = "メーカーコード";
            dataTable.Columns.Add(columnGoodsMakerCd2);

            // メーカー名
            DataColumn columnMakerName2 = new DataColumn(ExportMoveDataItems.ct_Col_MakerName, typeof(string));
            columnMakerName2.Caption = "メーカー名";
            dataTable.Columns.Add(columnMakerName2);

            // BLｺｰﾄﾞ
            DataColumn columnBLGoodsCode2 = new DataColumn(ExportMoveDataItems.ct_Col_BLGoodsCode, typeof(string));
            columnBLGoodsCode2.Caption = "BLコード";
            dataTable.Columns.Add(columnBLGoodsCode2);

            // オープン価格区分
            DataColumn columnOpenPriceDiv = new DataColumn(ExportMoveDataItems.ct_Col_OpenPriceDiv, typeof(string));
            columnOpenPriceDiv.Caption = "オープン価格区分";
            dataTable.Columns.Add(columnOpenPriceDiv);

            // 販売単価
            DataColumn columnSalesPrice = new DataColumn(ExportMoveDataItems.ct_Col_SalesPrice, typeof(string));
            columnSalesPrice.Caption = "販売単価";
            dataTable.Columns.Add(columnSalesPrice);

            // 売価率
            DataColumn columnSalesRate = new DataColumn(ExportMoveDataItems.ct_Col_SalesRate, typeof(string));
            columnSalesRate.Caption = "売価率";
            dataTable.Columns.Add(columnSalesRate);

            // 現在庫数
            DataColumn columnShipmentCount = new DataColumn(ExportMoveDataItems.ct_Col_ShipmentCount, typeof(string));
            columnShipmentCount.Caption = "現在庫数";
            dataTable.Columns.Add(columnShipmentCount);

            // 警告理由
            DataColumn columnAlertReason = new DataColumn(ExportMoveDataItems.ct_Col_AlertReason, typeof(string));
            columnAlertReason.Caption = "警告理由";
            dataTable.Columns.Add(columnAlertReason);

            this._exportDataSet.Tables.Add(dataTable);
            #endregion
        }

        /// <summary>
        /// エラー再取込
        /// </summary>
        /// <param name="outPutPath">出力先</param>
        /// <remarks>
        /// <br>Note        :エラー再取込処理</br>
        /// <br>Programmer  : 宋剛</br>
        /// <br>Date        : 2016/01/22</br>
        /// <br>UpdateNote : 宋剛 2016/02/19</br>
        /// <br>           : Redmine#48629の障害一覧No.241　エラー再取込実行時にエラーが表示される障害対応</br>
        /// <br>UpdateNote : 宋剛 2016/02/23</br>
        /// <br>           : LDNS発生した障害　取込むファイルのサイズは0の場合、実行状況のメッセージを出力しない</br>
        /// </remarks>
        public int ErrReRead(string outPutPath)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            string errFileName = string.Empty;
            string errMessage = string.Empty;

            // 1.1入力値検査
            #region 1.1入力値検査

            if (tNedit_CustomerCode.Focused)
            {
                _prevControl = this.tNedit_CustomerCode;
            }
            else if (tNedit_BLGoodsCode.Focused)
            {
                _prevControl = this.tNedit_BLGoodsCode;
            }
            else if (tNedit_GoodsMakerCd.Focused)
            {
                _prevControl = this.tNedit_GoodsMakerCd;
            }
            else if (tNedit_GoodsMGroup.Focused)
            {
                _prevControl = this.tNedit_GoodsMGroup;
            }
            else if (tNedit_RateGrpCode.Focused)
            {
                _prevControl = this.tNedit_RateGrpCode;
            }
            else if (tNedit_SupplierCd.Focused)
            {
                _prevControl = this.tNedit_SupplierCd;
            }

            if (this._prevControl != null)
            {

                ChangeFocusEventArgs e = new ChangeFocusEventArgs(false, false, false, Keys.Return, this._prevControl, this._prevControl);
                this.tRetKeyControl1_ChangeFocus(this, e);

                if (isErrorMsgboxShow)
                {
                    isErrorMsgboxShow = false;
                    this._prevControl.Focus();
                    this.ultraLabel_time.Text = string.Empty;
                    this.ultraLabel_time.Refresh();
                    return status;
                }
            }
            #endregion

            // ---------- ADD 2016/02/24 Y.Wakita ① ---------->>>>>
            // ③	部品MAXログインID、部品MAXパスワードが入力されているかを確認する。
            status = this.ReadUserSetting();
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                return status;
            }
            // ---------- ADD 2016/02/24 Y.Wakita ① ----------<<<<<

            // チェックリスト出力先
            if (!string.IsNullOrEmpty(outPutPath))
            {
                this._filePath = outPutPath;
            }
            
            // 実行準備
            this.ShowResult(PMMAX02010UE.M_042, ct_RUN_MESSAGE01);

            // ファイル選択ダイアログを表示します。
            status = OpenCSVFile(out errFileName);

            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // 中止
                this.ShowResult(string.Empty, ct_RUN_MESSAGE02);
                return status;
            }

            // ADD BY 宋剛 2016/02/19 FOR Redmine#48629の障害一覧No.241　エラー再取込実行時にエラーが表示される障害対応 ---->>>>>
            status = IsFileLocked(errFileName);
            if ((int)FileLocked_Status.FileLocked_LOCKED == status)
            {
                errMessage = ct_FILEALRDY_ERROR;
                TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                        this.Name,
                        errMessage,
                        -1,
                        MessageBoxButtons.OK);
                this.ShowResult(string.Format(PMMAX02010UE.M_033, status, errMessage), ct_RUN_MESSAGE04);
                this.ultraLabel_time.Text = string.Empty;
                return status;
            }
            // ADD BY 宋剛 2016/02/19 FOR Redmine#48629の障害一覧No.241　エラー再取込実行時にエラーが表示される障害対応 ----<<<<<

            int rows = GetRows(errFileName);
            // 総時間
            string runVelocityConfig = ConfigurationManager.AppSettings["RunVelocity"];
            double runVelocity = 0;
            double.TryParse(runVelocityConfig, out runVelocity);

            if ((rows - 1) < 0)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                // 中止
                // UPD BY 宋剛 2016/02/23 FOR LDNS発生した障害　取込むファイルのサイズは0の場合、実行状況のメッセージを出力しない ---->>>>>
                // this.ShowResult(string.Empty, ct_RUN_MESSAGE02);
                this.ShowResult(PMMAX02010UE.M_024, ct_RUN_MESSAGE02);
                // UPD BY 宋剛 2016/02/23 FOR LDNS発生した障害　取込むファイルのサイズは0の場合、実行状況のメッセージを出力しない ----<<<<<
                return status;

            }
            if (runVelocity != 0 && (rows - 1) >= 0)
            {
                this._restTime = (int)(runVelocity * (rows - 1)); // UIの残り予測時間
                this._forecastTime = this._restTime; // 規定予測処理時間
            }

            // Timerを作成
            this._restTimer = new System.Threading.Timer(new TimerCallback(TimerCall), null, 0, 1000);

            // エラーアップロード処理呼出
            this.UpLoadFile(out errMessage, errFileName);

            return status;
        }

        /// <summary>
        /// ファイルの件数取得
        /// </summary>
        /// <param name="errFileName">取り込むエラーCSVファイル</param>
        /// <remarks>
        /// <br>Note       : ファイルの件数取得を行う。</br>
        /// <br>Programmer : 宋剛</br>
        /// <br>Date       : 2016/01/22</br>
        /// </remarks>
        private int GetRows(string errFileName)
        {
            int lineCount = 0;
            using (StreamReader str = new StreamReader(errFileName, Encoding.Default))
            {
                while (str.Peek() >= 0)
                {
                    String tempStr = str.ReadLine();
                    if (!string.IsNullOrEmpty(tempStr))
                    {
                        lineCount++;
                    }
                }
            }

            return lineCount;
        }

        /// <summary>
        /// ファイルを開く
        /// </summary>
        /// <param name="errFileName">ファイル名</param>
        /// <remarks>
        /// <br>Note        : ファイルを開く。</br>
        /// <br>Programmer : 宋剛</br>
        /// <br>Date       : 2016/01/22</br>
        /// </remarks>
        private int OpenCSVFile(out string errFileName)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            errFileName = string.Empty;
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                // タイトルバーの文字列
                openFileDialog.Title = "取り込むエラーCSVファイルを指定してください。";
                openFileDialog.RestoreDirectory = true;
                if (this._filePath == string.Empty)
                {
                    openFileDialog.InitialDirectory = ConstantManagement_ClientDirectory.PRTOUT_CSV;

                }
                else
                {
                    openFileDialog.InitialDirectory = this._filePath;
                }

                //「ファイルの種類」を指定
                openFileDialog.Filter = ct_CSVFILTER;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    errFileName = openFileDialog.FileName;
                }
                else
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    return status;
                }
            }
            return status;

        }

        /// <summary>
        /// テキスト出力前にチェック処理
        /// </summary>
        /// <param name="errMessage">エラーメッセージ</param>
        /// <param name="errControl">エラーコントロール</param>
        /// <returns>エラー有無フラグ</returns>
        /// <remarks>
        /// <br>Note       : テキスト出力前にチェック処理を行います。</br>
        /// <br>Programmer : 宋剛</br>
        /// <br>Date       : 2016/01/22</br>
        /// </remarks>
        private bool BeforeSearchCheck(out string errMessage, out Control errControl)
        {
            bool result = true;
            errMessage = string.Empty;
            errControl = null;

            #region 得意先ｺｰﾄﾞチェック
            if (this.tNedit_CustomerCode.GetInt() == 0)
            {
                errMessage = PMMAX02010UE.M_010;
                errControl = this.tNedit_CustomerCode;
                return false;
            }
            #endregion

            // 倉庫ｺｰﾄﾞ
            if (this.checkedListBox_Warehouse.CheckedItems.Count == 0)
            {
                // 倉庫に、部品MAXの倉庫を1つ以上選択してください。
                errMessage = PMMAX02010UE.M_034;
                errControl = this.checkedListBox_Warehouse;
                return false;
            }

            // 在庫最終更新日
            if (_dateGetAcs.CheckDate(ref tDateEdit_LastStockUpdDate, true) == DateGetAcs.CheckDateResult.ErrorOfInvalid)
            {
                errMessage = "在庫最終更新日付が不正です。";
                errControl = this.tDateEdit_LastStockUpdDate;
                return false;
            }

            // 在庫最終更新日
            if (_dateGetAcs.CheckDate(ref tDateEdit_LastStockUpdDate, true) == DateGetAcs.CheckDateResult.ErrorOfInvalid)
            {
                errMessage = "在庫最終更新日付が不正です。";
                errControl = this.tDateEdit_LastStockUpdDate;
                return false;
            }

            DateGetAcs.CheckDateResult cdResult;
            // 価格算出日付
            cdResult = _dateGetAcs.CheckDate(ref tDateEdit_priceCalDate, false);
            if (cdResult == DateGetAcs.CheckDateResult.ErrorOfNoInput)
            {
                errMessage = PMMAX02010UE.M_039; 
                errControl = this.tDateEdit_priceCalDate;
                return false;
            }
            else if (cdResult == DateGetAcs.CheckDateResult.ErrorOfInvalid)
            {
                errMessage = "価格算出日付が不正です。";
                errControl = this.tDateEdit_priceCalDate;
                return false;
            }

            // 売価率
            if (this.tNedit_SalesRate.GetInt() == 0)
            {
                errMessage = PMMAX02010UE.M_040;
                errControl = this.tNedit_SalesRate;
                return false;
            }

            // 販売価格
            if (this.tNedit_SalesPrice.GetInt() == 0)
            {
                errMessage = PMMAX02010UE.M_041;
                errControl = this.tNedit_SalesPrice;
                return false;
            }

            return result;
        }

        /// <summary>
        /// テキスト出力処理
        /// </summary>
        /// <param name="outPutPath">出力先パス</param>
        /// <remarks>
        /// <br>Note       : テキスト出力処理を行う。</br>
        /// <br>Programmer : 宋剛</br>
        /// <br>Date       : 2016/01/22</br>
        /// <br>UpdateNote : 宋剛 2016/02/15</br>
        /// <br>           : Redmine#48629の#59の　CSVファイルがオープンされている障害対応</br>
        /// <br>UpdateNote : 宋剛 2016/02/16</br>
        /// <br>           : Redmine#48629の障害一覧No.16　チェックリスト出力先に書き込み不可障害対応</br>
        /// </remarks>
        public int DataExport(string outPutPath)
        {
            // チェックリスト出力先
            if (!string.IsNullOrEmpty(outPutPath))
            {
                this._filePath = outPutPath;

                // 出品一括更新一覧ファイル名称
                this._fileName = Path.Combine(this._filePath, DateTime.Now.ToString("yyyyMMdd") + ARFILENAME);
                // 出品一括更新警告一覧ファイル名称
                this._fileWarningName = Path.Combine(this._filePath, DateTime.Now.ToString("yyyyMMdd") + ERRFILENAME);
            }

            // DEL BY 宋剛 2016/02/16 FOR Redmine#48629の障害一覧No.16　チェックリスト出力先に書き込み不可障害対応 ---->>>>>
            //// 指定されたフォルダが存在チェック
            //if (!Directory.Exists(this._filePath))
            //{
            //    Directory.CreateDirectory(this._filePath);
            //}
            // DEL BY 宋剛 2016/02/16 FOR Redmine#48629の障害一覧No.16　チェックリスト出力先に書き込み不可障害対応 ----<<<<<

            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            // 1.0.実行準備
            #region 1.0.実行準備
            // ①	別紙[メッセージ一覧]のM-012を出力する。
            // 操作ログ記録    "入荷処理を開始します。"

            // ②	実行結果表示項目に"実行中"と表示する。
            this.ShowResult(PMMAX02010UE.M_012, ct_RUN_MESSAGE01);
            this.ultraLabel_time.Text = ct_RESTTIME;
            this.ultraLabel_time.Refresh();

            // ADD BY 宋剛 2016/02/16 FOR Redmine#48629の障害一覧No.16　チェックリスト出力先に書き込み不可障害対応 ---->>>>>
            // 指定されたフォルダが存在チェック
            Boolean errorFlag = false;
            try
            {
                if (!Directory.Exists(this._filePath))
                {
                    Directory.CreateDirectory(this._filePath);
                }

                if (!PMMAX02010UD.CheckDirectoryAccess(this._filePath))
                {
                    errorFlag = true;
                }
            }
            catch
            {
                errorFlag = true;
            }
            if (errorFlag)
            {
                this.ShowResult(PMMAX02010UE.M_007, ct_RUN_MESSAGE04);
                this.ultraLabel_time.Text = string.Empty;
                this.ultraLabel_time.Refresh();
                return status;
            }
            // ADD BY 宋剛 2016/02/16 FOR Redmine#48629の障害一覧No.16　チェックリスト出力先に書き込み不可障害対応 ----<<<<<

            // ③	出力予定となる下記ファイルを削除する。
            string delFileErrMessage = string.Empty;
            status = DeleteFile(out delFileErrMessage);

            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // ADD BY 宋剛 2016/02/15 FOR Redmine#48629の#59の　CSVファイルがオープンされている障害対応 ---->>>>>
                if (!string.IsNullOrEmpty(delFileErrMessage))
                {
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                        this.Name,
                        delFileErrMessage,
                        -1,
                        MessageBoxButtons.OK);
                }
                // ADD BY 宋剛 2016/02/15 FOR Redmine#48629の#59の　CSVファイルがオープンされている障害対応 ----<<<<<

                string mesage = string.Format(PMMAX02010UE.M_033, status, delFileErrMessage);
                this.ShowResult(mesage, ct_RUN_MESSAGE04);
                this.ultraLabel_time.Text = string.Empty;
                this.ultraLabel_time.Refresh();
                return status;
            }
            #endregion

            // 1.1入力値検査
            #region 1.1入力値検査
            // ①	別紙[メッセージ一覧]のM-013を出力する
            this.ShowResult(PMMAX02010UE.M_013, "");

            if (tNedit_CustomerCode.Focused)
            {
                _prevControl = this.tNedit_CustomerCode;
            }
            else if (tNedit_BLGoodsCode.Focused)
            {
                _prevControl = this.tNedit_BLGoodsCode;
            }
            else if (tNedit_GoodsMakerCd.Focused)
            {
                _prevControl = this.tNedit_GoodsMakerCd;
            }
            else if (tNedit_GoodsMGroup.Focused)
            {
                _prevControl = this.tNedit_GoodsMGroup;
            }
            else if (tNedit_RateGrpCode.Focused)
            {
                _prevControl = this.tNedit_RateGrpCode;
            }
            else if (tNedit_SupplierCd.Focused)
            {
                _prevControl = this.tNedit_SupplierCd;
            }


            if (this._prevControl != null)
            {

                ChangeFocusEventArgs e = new ChangeFocusEventArgs(false, false, false, Keys.Return, this._prevControl, this._prevControl);
                this.tRetKeyControl1_ChangeFocus(this, e);

                if (isErrorMsgboxShow)
                {
                    this.ShowResult(PMMAX02010UE.M_015, ct_RUN_MESSAGE04);
                    isErrorMsgboxShow = false;
                    this._prevControl.Focus();
                    this.ultraLabel_time.Text = string.Empty;
                    this.ultraLabel_time.Refresh();
                    return status;
                }
            }

            // ②	別紙[UI定義書]の「1-2.入力値検査機能」に従い、画面入力値を検査する。
            string message = string.Empty;
            Control errControl = null;
            string msg = "";
            bool canExport = this.BeforeSearchCheck(out message, out errControl);

            if (!canExport)
            {
                //入力値異常検知した場合
                //a-1.		実行結果表示項目に"エラー"と表示する。
                //a-2.		別紙[メッセージ一覧]のM-015を出力する。
                //          PMMAX02010UE.M_015 = "画面入力値に不備がありましたので、処理を終了しました。"
                this.ShowResult(PMMAX02010UE.M_015, ct_RUN_MESSAGE04);
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, ct_PGID, ct_PRINTNAME, "", "", message, -1, null, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                errControl.Focus();
                this.ultraLabel_time.Text = string.Empty;
                this.ultraLabel_time.Refresh();
                return status;
            }

            // ③	部品MAXログインID、部品MAXパスワードが入力されているかを確認する。
            // ---------- DEL 2016/02/24 Y.Wakita ① ---------->>>>>
            #region 削除
            //while (true)
            //{
            //    // ユーザー情報
            //    string userID;
            //    string userPassWord;
            //    bool userExistFlag = false;
            //    // DATファイルから、ユーザー情報を取得する
            //    _pMMAX02000UC.ReadDatFile(PMMAX02000UC.ct_Tbl_Users, this._enterpriseCode, this._loginSectionCode, out userID, out userPassWord, out userExistFlag);
            //    // 該当するユーザーを設定した場合
            //    if (string.IsNullOrEmpty(userID) || string.IsNullOrEmpty(userPassWord))
            //    {
            //        // 入力値が存在しない場合
            //        this._pmmax02000UE.DisplayMessage = "部品MAX管理画面にログインするための下記情報を入力してください。\r\n出品情報、及び入荷予約情報の登録に必要になります。\r\n※入力情報は記憶されるため、次回より入力不要です。\r\n　本情報は設定画面にて変更する事ができます。";
            //        this._pmmax02000UE.InitialScreenData();
            //        DialogResult dr = _pmmax02000UE.ShowDialog();

            //        if (dr == DialogResult.Yes)
            //        {
            //            // 部品MAXログインID
            //            this._loginId = this._pmmax02000UE.UserID;
            //            // 部品MAXパスワード
            //            this._password = this._pmmax02000UE.UserPassWord;
            //            break;
            //        }
            //        else
            //        {
            //            this.ShowResult(PMMAX02010UE.M_016, ct_RUN_MESSAGE02);
            //            this.ultraLabel_time.Text = string.Empty;
            //            this.ultraLabel_time.Refresh();
            //            return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            //        }
            //    }
            //    // 入力しました場合
            //    else
            //    {
            //        // 部品MAXログインID
            //        this._loginId = userID;
            //        // 部品MAXパスワード
            //        this._password = userPassWord;

            //        break;
            //    }
            //}
            #endregion
            // ---------- DEL 2016/02/24 Y.Wakita ① ----------<<<<<
            // ---------- ADD 2016/02/24 Y.Wakita ① ---------->>>>>
            status = this.ReadUserSetting();
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                return status;
            }
            // ---------- ADD 2016/02/24 Y.Wakita ① ----------<<<<<
            #endregion

            // 在庫移動データ読込
            this.ShowResult(PMMAX02010UE.M_014, ct_RUN_MESSAGE01);

            // 画面→抽出条件クラス
            status = this.SetExtraInfoFromScreen();
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                return status;
            }

            // ★重要★初期化検索部品アクセス
            // 売価計算用データを取得する。
            _partsMaxStockUpdateAcs.InitCustomerInfo(_searchCond);            // 得意先の情報初期化(売価計算用情報初期化取得)

            // 1.2.在庫マスタ読込
            string errMsg = "";
            int moveCount = 0;
            status = this._partsMaxStockUpdateAcs.SearchCount(out moveCount, this._searchCond, out errMsg);

            if ((int)ConstantManagement.DB_Status.ctDB_NORMAL != status
                && (int)ConstantManagement.DB_Status.ctDB_WARNING != status // 10万件の場合
                && (int)ConstantManagement.DB_Status.ctDB_EOF != status)　　// 0件の場合
            {
                msg = string.Format(PMMAX02010UE.M_017, status, errMsg);
                this.ShowResult(msg, ct_RUN_MESSAGE04);
                this.ultraLabel_time.Text = string.Empty;
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                return status;

            }

            // 取得件数 > 10万件
            if ((int)ConstantManagement.DB_Status.ctDB_WARNING == status)
            {
                // a)　取得件数 > 10万件
                // a-2-2-1.実行結果表示項目に"エラー"と表示する。
                // a-2-2-2.別紙[メッセージ一覧]のM-047を出力する。
                // a-2-2-3.処理を終了する。(Eに遷移
                this.ShowResult(PMMAX02010UE.M_047, ct_RUN_MESSAGE04);
                this.ultraLabel_time.Text = string.Empty;
                this.ultraLabel_time.Refresh();
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            // 0件の場合
            if ((int)ConstantManagement.DB_Status.ctDB_EOF == status)
            {
                this.ultraLabel_time.Text = string.Empty;
            }

            // 検索処理
            ArrayList retMoveDataList = null;


            // テーブルのクリア
            this._exportDataSet.Tables[ExportMoveDataItems.ct_Tbl_Arrival].Clear();
            this._exportDataSet.Tables[ExportMoveDataItems.ct_Tbl_ArrivalWarning].Clear();

            FormattedTextWriter export = new FormattedTextWriter();

            Boolean okTitleOutputFlg = false;
            Boolean errTitleOutputFlg = false;
            if (moveCount == 0)
            {

                // 一覧CSV出力
                status = DoOutPut(ref export, this._exportDataSet.Tables[ExportMoveDataItems.ct_Tbl_Arrival].DefaultView, this._fileName, 0, ref okTitleOutputFlg, out message);
                // 例外発生時
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    msg = string.Format(PMMAX02010UE.M_023, status, message);
                    this.ShowResult(msg, ct_RUN_MESSAGE04);
                    this.ultraLabel_time.Text = string.Empty;
                    this.ultraLabel_time.Refresh();
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    return status;
                }
                // 警告一覧CSV出力
                status = DoOutPut(ref export, this._exportDataSet.Tables[ExportMoveDataItems.ct_Tbl_ArrivalWarning].DefaultView, this._fileWarningName, 1, ref errTitleOutputFlg, out message);
                // 例外発生時
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    msg = string.Format(PMMAX02010UE.M_023, status, message);
                    this.ultraLabel_time.Text = string.Empty;
                    this.ultraLabel_time.Refresh();
                    this.ShowResult(msg, ct_RUN_MESSAGE04);
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    return status;
                }
            }

            #region 残り予測時間取得
            string runVelocityConfig = ConfigurationManager.AppSettings["RunVelocity"];  // 出品・一括更新データ1件当たりの登録速度
            double runVelocity = 0;
            double.TryParse(runVelocityConfig, out runVelocity);

            if (runVelocity != 0)
            {
                this._restTime = (int)(runVelocity * moveCount);    // UIの残り予測時間
                this._forecastTime = _restTime; // 規定予測処理時間
                // UIの残り時間を更新する
                UpdateUITime();
            }
            // Timerを作成
            this._restTimer = new System.Threading.Timer(new TimerCallback(TimerCall), null, 0, 1000);
            #endregion

            // 100件単位で在庫移動データ分割取得
            int loopCount = 0;
            if (moveCount % DATA_SIZE == 0)
            {
                loopCount = moveCount / DATA_SIZE;
            }
            else
            {
                loopCount = moveCount / DATA_SIZE + 1;
            }
            this._searchCond.DataSize = DATA_SIZE;

            okTitleOutputFlg = false;
            errTitleOutputFlg = false;
            for (int loopIndex = 0; loopIndex < loopCount; loopIndex++)
            {
                status = this._partsMaxStockUpdateAcs.SearchMain(out retMoveDataList, this._searchCond, out message, loopIndex);
                if (status == -1)
                {
                    this.ShowResult(message, ct_RUN_MESSAGE04);
                    // Timerを閉じる
                    this._restTimer.Change(Timeout.Infinite, 0);
                    this.ultraLabel_time.Text = string.Empty;
                    this.ultraLabel_time.Refresh();
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    return status;
                }
                else if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL && status != (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN)
                {
                    msg = string.Format(PMMAX02010UE.M_017, status, message);
                    this.ShowResult(msg, ct_RUN_MESSAGE04);
                    // Timerを閉じる
                    this._restTimer.Change(Timeout.Infinite, 0);
                    this.ultraLabel_time.Text = string.Empty;
                    this.ultraLabel_time.Refresh();
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    return status;
                }
                else
                {
                    // 残り予測時間更新
                    string step_SearchConfig = ConfigurationManager.AppSettings["Step_Search"];
                    double step_Search = 0;
                    double.TryParse(step_SearchConfig.Replace("%", ""), out step_Search);
                    this.UpdateRestTime(step_Search / loopCount);

                    // 出品一括更新データ
                    if (retMoveDataList != null && retMoveDataList.Count > 0)
                    {
                        msg = string.Format(PMMAX02010UE.M_021, retMoveDataList.Count);
                        this.ShowResult(msg, ct_RUN_MESSAGE01);

                        // 出品更新一覧
                        // DataSetへ格納
                        GetMoveDataTable(retMoveDataList);


                        // 出品更新一覧CSV出力
                        status = DoOutPut(ref export, this._exportDataSet.Tables[ExportMoveDataItems.ct_Tbl_Arrival].DefaultView, this._fileName, 0, ref okTitleOutputFlg, out message);
                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            msg = string.Format(PMMAX02010UE.M_023, status, message);
                            this.ShowResult(msg, ct_RUN_MESSAGE04);
                            // Timerを閉じる
                            this._restTimer.Change(Timeout.Infinite, 0);
                            this.ultraLabel_time.Text = string.Empty;
                            this.ultraLabel_time.Refresh();
                            status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                            return status;
                        }
                        // 出品更新警告一覧CSV出力
                        status = DoOutPut(ref export, this._exportDataSet.Tables[ExportMoveDataItems.ct_Tbl_ArrivalWarning].DefaultView, this._fileWarningName, 1, ref errTitleOutputFlg, out message);
                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            msg = string.Format(PMMAX02010UE.M_023, status, message);
                            this.ShowResult(msg, ct_RUN_MESSAGE04);
                            // Timerを閉じる
                            this._restTimer.Change(Timeout.Infinite, 0);
                            this.ultraLabel_time.Text = string.Empty;
                            this.ultraLabel_time.Refresh();
                            status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                            return status;
                        }

                        // 結果リストをクリア
                        retMoveDataList.Clear();
                        // テーブルのクリア
                        this._exportDataSet.Tables[ExportMoveDataItems.ct_Tbl_Arrival].Clear();
                        this._exportDataSet.Tables[ExportMoveDataItems.ct_Tbl_ArrivalWarning].Clear();

                        string step_ExporthConfig = ConfigurationManager.AppSettings["Step_Export"]; // テキスト出力処理の処理割合
                        double step_Export = 0;
                        double.TryParse(step_ExporthConfig.Replace("%", ""), out step_Export);

                        this.UpdateRestTime(step_Export / loopCount);
                    }
                    else
                    {
                        // 移動データなし場合、正常とする
                        status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                    }
                }
            }

            // 1.5 アップロード判断とアップロード処理
            string errMessage = string.Empty;
            status = this.UpLoadFileCheck(out errMessage);

            // アップロード処理
            if (!string.IsNullOrEmpty(errMessage))
            {
                string mesage = string.Format(PMMAX02010UE.M_033, status, errMessage);
                this.ShowResult(mesage, ct_RUN_MESSAGE04);
                // Timerを閉じる
                this._restTimer.Change(Timeout.Infinite, 0);
                this.ultraLabel_time.Text = string.Empty;
                this.ultraLabel_time.Refresh();
                return status;
            }

            return status;
        }

        /// <summary>
        ///アップロード判断
        /// </summary>
        /// <remarks>
        /// <br>Note       : アップロード判断を行う。</br>
        /// <br>Programmer : 宋剛</br>
        /// <br>Date       : 2016/01/22</br>
        /// </remarks>
        private int UpLoadFileCheck(out string errMessage)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            errMessage = string.Empty;

            string message = string.Empty;
            try
            {
                PMMAX02000UG frm = new PMMAX02000UG();
                // 指定されたフォルダが存在チェック
                if (!Directory.Exists(this._filePath)) return (int)ConstantManagement.DB_Status.ctDB_ERROR;
                if (!File.Exists(this._fileWarningName)) return (int)ConstantManagement.DB_Status.ctDB_ERROR;
                if (!File.Exists(this._fileName)) return (int)ConstantManagement.DB_Status.ctDB_ERROR;
                FileInfo fileInfoE = new FileInfo(this._fileWarningName);
                FileInfo fileInfo = new FileInfo(this._fileName);
                long sizeE = fileInfoE.Length;
                long size = fileInfo.Length;
                string fileName = string.Empty;
                // 出品更新一覧_警告.csvのファイルサイズ  > 0バイト
                if (sizeE > 0)
                {
                    message = "抽出結果に問題がある商品を発見しました。\r\nチェックリストを確認してください。\r\n問題が無ければ、『部品MAXに登録する』を押し、部品MAXに登録を行ってください。\r\n売価率・販売単価等を修正する場合は『中止する』を押して\r\n修正後に処理をしなおしてください。";

                    fileName = this._fileWarningName;
                    status = UpLoadDialog(message, fileName, out errMessage);
                }
                else
                {
                    // 出品更新一覧.csvのファイルサイズ = 0バイト
                    if (size == 0)
                    {
                        // 中止
                        this.ShowResult(PMMAX02010UE.M_024, ct_RUN_MESSAGE02);
                        // Timerを閉じる
                        this._restTimer.Change(Timeout.Infinite, 0);
                        this.ultraLabel_time.Text = string.Empty;
                        this.ultraLabel_time.Refresh();
                        return (int)ConstantManagement.DB_Status.ctDB_ERROR;

                    }
                    // チェックリスト出力選択 = 選択状態
                    else if (this.ultraCheckEditor.Checked)
                    {
                        message = "出品更新対象のチェックリスト出力が完了しました。\r\nチェックリストを確認してください。\r\n問題が無ければ、『部品MAXに登録する』を押し、部品MAXに登録を行ってください。\r\n";

                        fileName = this._fileName;

                        status = this.UpLoadDialog(message, fileName, out errMessage);
                    }
                    else
                    {
                        // 部品MAXアップロード処理
                        this.UpLoadFile(out errMessage, this._fileName);
                    }
                }

            }
            catch (Exception ex)
            {
                errMessage = ex.Message;

                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }

        /// <summary>
        /// アップロード処理
        /// </summary>
        /// <param name="message">メッセージ</param>
        /// <param name="fileName">出力ファイル</param>
        /// <param name="errMessage">エラーメッセージ</param>
        /// <remarks>
        /// <br>Note       : アップロード処理を行う。</br>
        /// <br>Programmer : 宋剛</br>
        /// <br>Date       : 2016/01/22</br>
        /// </remarks>
        private int UpLoadDialog(string message, string fileName, out string errMessage)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            errMessage = string.Empty;
            PMMAX02000UG frm = new PMMAX02000UG();

            // STOP
            this._restTimer.Change(Timeout.Infinite, 0);

            // ダイアログを表示する
            DialogResult ret = frm.ShowDialog(this, message, 0, fileName);
            if (ret == DialogResult.Yes)
            {
                // 1.6　部品MAXアップロード処理
                status = this.UpLoadFile(out errMessage, this._fileName);

            }
            else if (ret == DialogResult.Abort)
            {
                // 中止ボタン押下時
                this.ShowResult(PMMAX02010UE.M_016, ct_RUN_MESSAGE02);
                // Timerを閉じる
                this._restTimer.Change(Timeout.Infinite, 0);
                this.ultraLabel_time.Text = string.Empty;
                this.ultraLabel_time.Refresh();
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                return status;
            }
            else
            {

            }
            return status;

        }

        /// <summary>
        /// 1.6　部品MAXアップロード処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 部品MAXアップロード処理を行う。</br>
        /// <br>Programmer : 宋剛</br>
        /// <br>Date       : 2016/01/22</br>
        /// <br>UpdateNote : 宋剛 2016/02/19</br>
        /// <br>           : Redmine#48629の障害一覧No.243　「部品MAXに登録する」を選択すると、
        ///                 「予期せぬエラーが発生しました」が表示された障害対応</br>
        /// <br>UpdateNote : 宋剛 2016/02/19</br>
        /// <br>           : Redmine#48629の障害一覧No.244　認証失敗後に中止すると、実行状況が「中止」ではなく「エラー」になる障害対応</br>
        /// </remarks>
        private int UpLoadFile(out string errMessage, string fileName)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            this.ShowResult(PMMAX02010UE.M_026, ct_RUN_MESSAGE01);
            errMessage = string.Empty;
            DateTime readMsgDateTime = DateTime.Now;
            try
            {
                // ADD BY 宋剛 2016/02/19 FOR Redmine#48629の障害一覧No.243　「部品MAXに登録する」を選択すると、「予期せぬエラーが発生しました」が表示された障害対応---->>>>>
                status = IsFileLocked(fileName);
                if ((int)FileLocked_Status.FileLocked_LOCKED == status)
                {
                    TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,
                            this.Name,
                            ct_FILEALRDY_ERROR,
                            -1,
                            MessageBoxButtons.OK);
                    this.ShowResult(string.Format(PMMAX02010UE.M_033, status, ct_FILEALRDY_ERROR), ct_RUN_MESSAGE04);

                    // Timerを閉じる
                    this._restTimer.Change(Timeout.Infinite, 0);
                    this.ultraLabel_time.Text = string.Empty;
                    this.ultraLabel_time.Refresh();
                    return (int)ConstantManagement.DB_Status.ctDB_ERROR;
                }
                // ADD BY 宋剛 2016/02/19 FOR Redmine#48629の障害一覧No.243　「部品MAXに登録する」を選択すると、「予期せぬエラーが発生しました」が表示された障害対応----<<<<<

                this._runFlg = true;   // ADD 2016/02/24 Y.Wakita ③

                // 部品MAX共通部品を呼び出し、出品更新アップロード処理を行う。
                status = this._buhinMaxExhibitStockProvider.Regist(this._loginId, this._password, fileName, ref errMessage);

                // 残り予測時間更新
                string step_UploadConfig = ConfigurationManager.AppSettings["Step_Upload"];
                double step_Upload = 0;
                double.TryParse(step_UploadConfig.Replace("%", ""), out step_Upload);

                this.UpdateRestTime(step_Upload);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // 1.7.部品MAX状況監視
                    status = GetRegist(out errMessage, readMsgDateTime);
                    this._runFlg = false;   // ADD 2016/02/24 Y.Wakita ③
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        return status;
                    }
                }
                // ステータス = 認証エラー 
                else if (status == 403)
                {
                    this.ShowResult(PMMAX02010UE.M_025, ct_RUN_MESSAGE01);
                    // 部品MAXログインID、部品MAXパスワードが入力されているかを確認する
                    this._pmmax02000UE.DisplayMessage = PMMAX02010UE.M_025;
                    DialogResult ret = this._pmmax02000UE.ShowDialog();
                    if (ret == DialogResult.Yes)
                    {
                        this._loginId = this._pmmax02000UE.UserID;
                        this._password = this._pmmax02000UE.UserPassWord;
                        status = UpLoadFile(out errMessage, fileName);
                    }
                    else
                    {
                        // 中止ボタン押下時
                        this.ShowResult(PMMAX02010UE.M_016, ct_RUN_MESSAGE02);
                        errMessage = string.Empty; // ADD BY 宋剛 2016/02/19 FOR Redmine#48629の障害一覧No.244　認証失敗後に中止すると、実行状況が「中止」ではなく「エラー」になる障害対応
                        // Timerを閉じる
                        this._restTimer.Change(Timeout.Infinite, 0);
                        this.ultraLabel_time.Text = string.Empty;
                        this.ultraLabel_time.Refresh();
                        status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                        return status;
                    }

                }
                else if (status == 400)
                {
                    this.ShowResult(PMMAX02010UE.M_027, ct_RUN_MESSAGE04);
                    // Timerを閉じる
                    this._restTimer.Change(Timeout.Infinite, 0);
                    this.ultraLabel_time.Text = string.Empty;
                    this.ultraLabel_time.Refresh();
                    return status;

                }
                else
                {
                    string msg = string.Format(PMMAX02010UE.M_028, status, errMessage);
                    this.ShowResult(msg, ct_RUN_MESSAGE04);
                    // Timerを閉じる
                    this._restTimer.Change(Timeout.Infinite, 0);
                    this.ultraLabel_time.Text = string.Empty;
                    this.ultraLabel_time.Refresh();
                    return status;
                }
            }
            catch (Exception ex)
            {
                errMessage = ex.Message;

                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            // ---------- ADD 2016/02/24 Y.Wakita ③ ---------->>>>>
            finally
            {
                this._runFlg = false;
            }
            // ---------- ADD 2016/02/24 Y.Wakita ③ ----------<<<<<

            return status;
        }

        /// <summary>
        /// 部品MAX状況監視処理
        /// </summary>
        /// <param name="errMessage">メッセージ</param>
        /// <remarks>
        /// <br>Note       : 部品MAX状況監視処理を行う。</br>
        /// <param name="readMsgDateTime">前回状況監視呼出日時</param>
        /// <br>Programmer : 宋剛</br>
        /// <br>Date       : 2016/01/22</br>
        /// <br>UpdateNote : 宋剛 2016/02/19</br>
        /// <br>           : Redmine#48629の障害一覧No.238　ステータス5の戻りの場合に実行状況ログに記載が行われていない</br>
        /// </remarks>
        private int GetRegist(out string errMessage, DateTime readMsgDateTime)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            errMessage = string.Empty;
            int timeLeftSeconds = 0;
            List<string> messageList = new List<string>();
            string errorListCsvFileFullName = string.Empty;
            DateTime readMessageDateTime = readMsgDateTime;
            try
            {
                // 1.7.部品MAX状況監視
                status = this._buhinMaxExhibitStockProvider.GetRegistStatus(readMessageDateTime, ref errorListCsvFileFullName, ref timeLeftSeconds, ref messageList);
                // ---------- ADD 2016/02/24 Y.Wakita ② ---------->>>>>
                readMessageDateTime = DateTime.Now;
                // ---------- ADD 2016/02/24 Y.Wakita ② ----------<<<<<
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // 部品MAX連携部品より返される残り予測時間をそのまま使用する。
                    // Timerを閉じる
                    this._restTimer.Change(Timeout.Infinite, 0);
                    this._restTime = timeLeftSeconds;
                    // UIの残り時間を更新する
                    UpdateUITime();
                    // 戻り値を実行状況ログに出力する。
                    foreach (string msg in messageList)
                    {
                        this.ShowResult(msg, ct_RUN_MESSAGE01);
                    }

                    // 戻り値を実行状況ログに出力する。
                    this.ShowResult(PMMAX02010UE.M_030, ct_RUN_MESSAGE01);

                    // 完了処理
                    this.EndSave();
                }
                // ステータス = 5
                else if (status == (int)ConstantManagement.DB_Status.ctDB_DUPLICATE)
                {
                    // 部品MAX連携部品より返される残り予測時間をそのまま使用する。
                    // Timerを閉じる
                    this._restTimer.Change(Timeout.Infinite, 0);
                    this._restTime = timeLeftSeconds;
                    // UIの残り時間を更新する
                    UpdateUITime();
                    // ADD BY 宋剛 2016/02/19 FOR Redmine#48629の障害一覧No.238　ステータス5の戻りの場合に実行状況ログに記載が行われていない---->>>>>
                    foreach (string msg in messageList)
                    {
                        this.ShowResult(msg, ct_RUN_MESSAGE01);
                    }
                    // ADD BY 宋剛 2016/02/19 FOR Redmine#48629の障害一覧No.238　ステータス5の戻りの場合に実行状況ログに記載が行われていない----<<<<<
                    PMMAX02000UG frm = new PMMAX02000UG();
                    string message = "一部のデータの登録に失敗しました。" + Environment.NewLine +
                                         "登録できなかったリストを下記ファイル名で保存しました。" + Environment.NewLine +
                                         errorListCsvFileFullName + Environment.NewLine +
                                         "エラー内容を修正したあとで[エラー再取込]ボタンを押し、" + Environment.NewLine +
                                         "再度登録をお願いします。";

                    DialogResult ret = frm.ShowDialog(this, message, 1, errorListCsvFileFullName);
                    if (ret == DialogResult.OK || ret == DialogResult.Yes)
                    {
                        // 完了処理
                        this.EndSave();
                    }
                }
                else if (status == 100)
                {
                    // 戻り値を実行状況ログに出力する。
                    foreach (string msg in messageList)
                    {
                        this.ShowResult(msg, ct_RUN_MESSAGE01);
                    }
                    // 5秒待機する。
                    Thread.Sleep(5000);
                    // 再度実行する。
                    this.GetRegist(out errMessage, readMessageDateTime);

                }
                else
                {
                    // 戻り値を実行状況ログに出力する。
                    foreach (string msg in messageList)
                    {
                        this.ShowResult(msg, ct_RUN_MESSAGE04);
                    }

                    this.ShowResult(PMMAX02010UE.M_029, ct_RUN_MESSAGE04);
                    // Timerを閉じる
                    this._restTimer.Change(Timeout.Infinite, 0);
                    this.ultraLabel_time.Text = string.Empty;
                    this.ultraLabel_time.Refresh();
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    return status;
                }
            }
            catch (Exception ex)
            {
                errMessage = ex.Message;

                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;

        }

        /// <summary>
        /// 1.8.完了処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 完了処理を行う。</br>
        /// <br>Programmer : 宋剛</br>
        /// <br>Date       : 2016/01/22</br>
        /// </remarks>
        private void EndSave()
        {
            // 完了処理
            this.ShowResult(PMMAX02010UE.M_031, ct_RUN_MESSAGE03);
            // メインー画面項目と設定画面項目はXMLに保存する
            this.ScreenItemsToXML();
            this.ShowResult(PMMAX02010UE.M_032, ct_RUN_MESSAGE03);
            // Timerを閉じる
            this._restTimer.Change(Timeout.Infinite, 0);
            this.ultraLabel_time.Text = string.Empty;
        }

        // ADD BY 宋剛 2016/02/19 FOR Redmine#48629の障害一覧No.237　チェック処理に名称にカンマとダブルクウォーテーションが含まれていないか判定処理追加---->>>>>
        /// <summary>
        /// 名称にカンマとダブルクウォーテーションが含まれていないか判定処理
        /// </summary>
        /// <param name="moveData">データ</param>
        /// <returns>判定結果true:含まる false:含まない</returns>
        /// <remarks>
        /// <br>Note       : 名称にカンマとダブルクウォーテーションが含まれていないか判定処理を行う</br>
        /// <br>Programmer : 宋剛</br>
        /// <br>Date       : 2016/02/19</br>
        /// </remarks>
        private Boolean isContainSpecalCharMain(PartsMaxStockUpdateResultWork moveData)
        {
            if (isContainSpecalCharProc(moveData.GoodsName))
            {
                return true;
            }

            if (isContainSpecalCharProc(moveData.GoodsNo))
            {
                return true;
            }

            if (isContainSpecalCharProc(moveData.MakerName))
            {
                return true;
            }

            if (isContainSpecalCharProc(moveData.WarehouseNm))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// 名称にカンマとダブルクウォーテーションが含まれていないか判定処理
        /// </summary>
        /// <param name="inputStr">文字列</param>
        /// <returns>判定結果true:含まる false:含まない</returns>
        /// <remarks>
        /// <br>Note       : 名称にカンマとダブルクウォーテーションが含まれていないか判定処理を行う</br>
        /// <br>Programmer : 宋剛</br>
        /// <br>Date       : 2016/02/19</br>
        /// </remarks>
        private Boolean isContainSpecalCharProc(string inputStr)
        {
            string specialChar1 = ",";
            string specialChar = "\"";
            

            if (!string.IsNullOrEmpty(inputStr) && !inputStr.Contains(specialChar) && !inputStr.Contains(specialChar1))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        // ADD BY 宋剛 2016/02/19 FOR Redmine#48629の障害一覧No.237　チェック処理に名称にカンマとダブルクウォーテーションが含まれていないか判定処理追加----<<<<<

        /// <summary>
        /// 移動データ→DataTableに格納
        /// </summary>
        /// <param name="retMoveDataList">移動データ</param>
        /// <remarks>
        /// <br>Note       : 移動データをDataTableに格納します。</br>
        /// <br>Programmer : 宋剛</br>
        /// <br>Date       : 2016/01/22</br>
        /// <br>UpdateNote : 宋剛 2016/02/15</br>
        /// <br>           : Redmine#48629の#64の　売価率と単価の整数出力対応</br>
        /// <br>UpdateNote : 宋剛 2016/02/15</br>
        /// <br>           : Redmine#48629の#64の　売価率と単価の整数出力対応</br>
        /// <br>UpdateNote : 宋剛 2016/02/15</br>
        /// <br>           : Redmine#48629の#70の　販売単価などのカンマは必要ないので削除する</br>
        /// <br>UpdateNote : 宋剛 2016/02/16</br>
        /// <br>           : Redmine#48629の障害一覧No.13　出荷数の小数点以下が切り捨てされない仕様変更対応</br>
        /// <br>UpdateNote : 宋剛 2016/02/19</br>
        /// <br>           : Redmine#48629の障害一覧No.237　チェック処理に名称にカンマとダブルクウォーテーションが含まれていないか判定処理追加</br>
        /// </remarks>
        private void GetMoveDataTable(ArrayList retMoveDataList)
        {
            // UPD BY 宋剛 2016/02/15 FOR Redmine#48629の#64の　売価率と単価の整数出力対応 ---->>>>>
            // string formatFraction = "#,##0.00;-#,##0.00;";
            string formatFraction = "#,##0;-#,##0;";
            // UPD BY 宋剛 2016/02/15 FOR Redmine#48629の#64の　売価率と単価の整数出力対応 ----<<<<<

            // データ
            if (retMoveDataList != null && retMoveDataList.Count > 0)
            {
                foreach (PartsMaxStockUpdateResultWork moveData in retMoveDataList)
                {
                    // 
                    Boolean isWarning = false;

                    // カンマとダブルクウォーテーションが含まれていないか判定フラグ
                    Boolean isContainSpecalChar = false;  // ADD BY 宋剛 2016/02/19 FOR Redmine#48629の障害一覧No.237　チェック処理に名称にカンマとダブルクウォーテーションが含まれていないか判定処理追加
                    //条件判断
                    // UPD BY 宋剛 2016/02/15 FOR Redmine#48629の障害一覧No.2の　販売単価と売価率の「未満」仕様変更対応 ---->>>>>
                    //if ((moveData.OpenPriceDiv == 0 && (int)moveData.SalesRateVal <= this.tNedit_SalesRate.GetInt())
                    //    || (moveData.OpenPriceDiv == 1 && (int)moveData.SalesUnitCost <= this.tNedit_SalesPrice.GetInt())
                    //    || (moveData.OpenPriceDiv == 1 && (int)moveData.SalesUnitCost <= 1)
                    //    || ((int)moveData.SalesRateVal != moveData.SalesRateVal)
                    //    || ((int)moveData.StockCnt != moveData.StockCnt)
                    //    || ((int)moveData.StockCnt == 0))
                    if ((moveData.OpenPriceDiv == 0 && (int)moveData.SalesRateVal < this.tNedit_SalesRate.GetInt())
                        || (moveData.OpenPriceDiv == 1 && (int)moveData.SalesUnitCost < this.tNedit_SalesPrice.GetInt())
                        || (moveData.OpenPriceDiv == 1 && (int)moveData.SalesUnitCost < 1)
                        || ((int)moveData.SalesRateVal != moveData.SalesRateVal)
                        || ((int)moveData.StockCnt != moveData.StockCnt)
                        || ((int)moveData.StockCnt == 0))
                    // UPD BY 宋剛 2016/02/15 FOR Redmine#48629の障害一覧No.2の　販売単価と売価率の「未満」仕様変更対応 ----<<<<<
                    {
                        isWarning = true;
                    }

                    // ADD BY 宋剛 2016/02/19 FOR Redmine#48629の障害一覧No.237　チェック処理に名称にカンマとダブルクウォーテーションが含まれていないか判定処理追加 ---->>>>>
                    if (isContainSpecalCharMain(moveData))
                    {
                        isContainSpecalChar = true;
                    }
                    // ADD BY 宋剛 2016/02/19 FOR Redmine#48629の障害一覧No.237　チェック処理に名称にカンマとダブルクウォーテーションが含まれていないか判定処理追加 ----<<<<<

                    DataRow row = null;
                    // UPD BY 宋剛 2016/02/19 FOR Redmine#48629の障害一覧No.237　チェック処理に名称にカンマとダブルクウォーテーションが含まれていないか判定処理追加 ---->>>>>
                    // if (isWarning)
                    if (isWarning || isContainSpecalChar)
                    // UPD BY 宋剛 2016/02/19 FOR Redmine#48629の障害一覧No.237　チェック処理に名称にカンマとダブルクウォーテーションが含まれていないか判定処理追加 ----<<<<<
                    {
                        row = this._exportDataSet.Tables[ExportMoveDataItems.ct_Tbl_ArrivalWarning].NewRow();
                    }
                    else
                    {
                        row = this._exportDataSet.Tables[ExportMoveDataItems.ct_Tbl_Arrival].NewRow();
                    }


                    #region 移動データの格納
                    // 企業コード
                    row[ExportMoveDataItems.ct_Col_EnterpriseCode] = _enterpriseCode;
                    // 拠点コード
                    row[ExportMoveDataItems.ct_Col_SectionCode] = _loginSectionCode;
                    // 品名
                    row[ExportMoveDataItems.ct_Col_GoodsName] = ConvertSpecialStr(moveData.GoodsName);
                    // 品番
                    row[ExportMoveDataItems.ct_Col_GoodsNo] = ConvertSpecialStr(moveData.GoodsNo);
                    // メーカーコード
                    row[ExportMoveDataItems.ct_Col_GoodsMakerCd] = moveData.GoodsMakerCd.ToString().PadLeft(4, '0');
                    // メーカー名
                    row[ExportMoveDataItems.ct_Col_MakerName] = ConvertSpecialStr(moveData.MakerName);
                    // BLｺｰﾄﾞ
                    row[ExportMoveDataItems.ct_Col_BLGoodsCode] = moveData.BLGoodsCode;
                    // 出荷数
                    // UPD BY 宋剛 2016/02/16 Redmine#48629の障害一覧No.13　出荷数の小数点以下が切り捨てされない仕様変更対応 ---->>>>>
                    // row[ExportMoveDataItems.ct_Col_ShipmentCount] = moveData.StockCnt;
                    row[ExportMoveDataItems.ct_Col_ShipmentCount] = CutDownNum(moveData.StockCnt);
                    // UPD BY 宋剛 2016/02/16 Redmine#48629の障害一覧No.13　出荷数の小数点以下が切り捨てされない仕様変更対応 ----<<<<<
                    // オープン価格区分
                    row[ExportMoveDataItems.ct_Col_OpenPriceDiv] = moveData.OpenPriceDiv;
                    // DEL BY 宋剛 2016/02/15 FOR Redmine#48629の#64の　売価率と単価の整数出力対応 ---->>>>>
                    //// 販売単価
                    //row[ExportMoveDataItems.ct_Col_SalesPrice] = moveData.SalesUnitCost.ToString(formatFraction);
                    //// 売価率
                    //row[ExportMoveDataItems.ct_Col_SalesRate] = moveData.SalesRateVal.ToString(formatFraction);
                    // DEL BY 宋剛 2016/02/15 FOR Redmine#48629の#64の　売価率と単価の整数出力対応 ----<<<<<
                    // ADD BY 宋剛 2016/02/15 FOR Redmine#48629の#64の　売価率と単価の整数出力対応 ---->>>>>
                    // 販売単価
                    //row[ExportMoveDataItems.ct_Col_SalesPrice] = Math.Floor(moveData.SalesUnitCost).ToString(formatFraction); // DEL BY 宋剛 2016/02/15 FOR Redmine#48629の#70の　販売単価などのカンマは必要ないので削除する
                    if ((int)moveData.SalesRateVal > 0)
                    {
                        row[ExportMoveDataItems.ct_Col_SalesPrice] = '0';
                    }
                    else
                    {
                        row[ExportMoveDataItems.ct_Col_SalesPrice] = Math.Floor(moveData.SalesUnitCost).ToString();// ADD BY 宋剛 2016/02/15 FOR Redmine#48629の#70の　販売単価などのカンマは必要ないので削除する
                    }
                    // 売価率
                    row[ExportMoveDataItems.ct_Col_SalesRate] = Math.Floor(moveData.SalesRateVal).ToString(formatFraction);
                    // ADD BY 宋剛 2016/02/15 FOR Redmine#48629の#64の　売価率と単価の整数出力対応 ----<<<<<
                    // 倉庫
                    if (!string.IsNullOrEmpty(moveData.WarehouseCode))
                    {
                        row[ExportMoveDataItems.ct_Col_WarehCode] = moveData.WarehouseCode.Trim().PadLeft(4, '0');
                    }
                    else
                    {
                        row[ExportMoveDataItems.ct_Col_WarehCode] = string.Empty;
                    }
                    
                    // 倉庫名
                    row[ExportMoveDataItems.ct_Col_WarehName] = ConvertSpecialStr(moveData.WarehouseNm);

                    // UPD BY 宋剛 2016/02/19 FOR Redmine#48629の障害一覧No.237　チェック処理に名称にカンマとダブルクウォーテーションが含まれていないか判定処理追加 ---->>>>>
                    // if (isWarning)
                    if (isWarning || isContainSpecalChar)
                    // UPD BY 宋剛 2016/02/19 FOR Redmine#48629の障害一覧No.237　チェック処理に名称にカンマとダブルクウォーテーションが含まれていないか判定処理追加 ----<<<<<
                    {
                        // UPD BY 宋剛 2016/02/15 FOR Redmine#48629の障害一覧No.2の　販売単価と売価率の「未満」仕様変更対応 ---->>>>>
                        // if (moveData.OpenPriceDiv == 0 && (int)moveData.SalesRateVal <= this.tNedit_SalesRate.GetInt())
                        if (moveData.OpenPriceDiv == 0 && (int)moveData.SalesRateVal < this.tNedit_SalesRate.GetInt())
                        // UPD BY 宋剛 2016/02/15 FOR Redmine#48629の障害一覧No.2の　販売単価と売価率の「未満」仕様変更対応 ----<<<<<
                        {
                            // 警告理由
                            row[ExportMoveDataItems.ct_Col_AlertReason] = string.Format(PMMAX02010UE.M_018, this.tNedit_SalesRate.GetInt());
                        }
                        // UPD BY 宋剛 2016/02/15 FOR Redmine#48629の障害一覧No.2の　販売単価と売価率の「未満」仕様変更対応 ---->>>>>
                        // else if (moveData.OpenPriceDiv == 1 && (int)moveData.SalesUnitCost <= this.tNedit_SalesPrice.GetInt())
                        else if (moveData.OpenPriceDiv == 1 && (int)moveData.SalesUnitCost < this.tNedit_SalesPrice.GetInt())
                        // UPD BY 宋剛 2016/02/15 FOR Redmine#48629の障害一覧No.2の　販売単価と売価率の「未満」仕様変更対応 ----<<<<<
                        {
                            // 警告理由
                            row[ExportMoveDataItems.ct_Col_AlertReason] = string.Format(PMMAX02010UE.M_019, this.tNedit_SalesPrice.GetInt());
                        }
                        // UPD BY 宋剛 2016/02/15 FOR Redmine#48629の障害一覧No.2の　販売単価と売価率の「未満」仕様変更対応 ---->>>>>
                        // else if (moveData.OpenPriceDiv == 1 && (int)moveData.SalesUnitCost <= 1)
                        else if (moveData.OpenPriceDiv == 1 && (int)moveData.SalesUnitCost < 1)
                        // UPD BY 宋剛 2016/02/15 FOR Redmine#48629の障害一覧No.2の　販売単価と売価率の「未満」仕様変更対応 ----<<<<<
                        {
                            // 警告理由
                            row[ExportMoveDataItems.ct_Col_AlertReason] = PMMAX02010UE.M_020;
                        }
                        else if ((int)moveData.SalesRateVal != moveData.SalesRateVal)
                        {
                            // 警告理由
                            row[ExportMoveDataItems.ct_Col_AlertReason] = PMMAX02010UE.M_044;
                        }
                        else if ((int)moveData.StockCnt != moveData.StockCnt)
                        {
                            // 警告理由
                            row[ExportMoveDataItems.ct_Col_AlertReason] = PMMAX02010UE.M_045;

                        }
                        else if ((int)moveData.StockCnt == 0)
                        {
                            // 警告理由
                            row[ExportMoveDataItems.ct_Col_AlertReason] = PMMAX02010UE.M_046;
                        }
                        // ADD BY 宋剛 2016/02/19 FOR Redmine#48629の障害一覧No.237　チェック処理に名称にカンマとダブルクウォーテーションが含まれていないか判定処理追加 ---->>>>>
                        else if (isContainSpecalChar)
                        {
                            // 警告理由
                            row[ExportMoveDataItems.ct_Col_AlertReason] = PMMAX02010UE.M_050;
                        }
                        // ADD BY 宋剛 2016/02/19 FOR Redmine#48629の障害一覧No.237　チェック処理に名称にカンマとダブルクウォーテーションが含まれていないか判定処理追加 ----<<<<<

                    }

                    // UPD BY 宋剛 2016/02/19 FOR Redmine#48629の障害一覧No.237　チェック処理に名称にカンマとダブルクウォーテーションが含まれていないか判定処理追加 ---->>>>>
                    // if (isWarning)
                    if (isWarning || isContainSpecalChar)
                    // UPD BY 宋剛 2016/02/19 FOR Redmine#48629の障害一覧No.237　チェック処理に名称にカンマとダブルクウォーテーションが含まれていないか判定処理追加 ----<<<<<
                    {
                        this._exportDataSet.Tables[ExportMoveDataItems.ct_Tbl_ArrivalWarning].Rows.Add(row);
                    }
                    else
                    {
                        this._exportDataSet.Tables[ExportMoveDataItems.ct_Tbl_Arrival].Rows.Add(row);
                    }

                    #region Ⅲの条件に一致しない、且つ出荷可能数(int)が1以上である場合、[出品更新一覧仕様書]に従い、対象情報を出力する。
                    // Ⅲ	オープン価格区分が"1"、且つ販売単価が1円以下である。
                    // Ⅲの条件に一致しない、且つ出荷可能数(int)が1以上である場合、
                    // [出品更新一覧仕様書]に従い、対象情報を出力する。
                    // 以上の条件を満足した、警告データがありません。
                    // UPD BY 宋剛 2016/02/19 FOR Redmine#48629の障害一覧No.237　チェック処理に名称にカンマとダブルクウォーテーションが含まれていないか判定処理追加 ---->>>>>
                    // if ((!(moveData.OpenPriceDiv == 1 && (int)moveData.SalesUnitCost <= 1) && moveData.StockCnt >= 1) && (isWarning))
                    if ((!(moveData.OpenPriceDiv == 1 && (int)moveData.SalesUnitCost < 1) && moveData.StockCnt >= 1) && (isWarning) && (!isContainSpecalChar))
                    // UPD BY 宋剛 2016/02/19 FOR Redmine#48629の障害一覧No.237　チェック処理に名称にカンマとダブルクウォーテーションが含まれていないか判定処理追加 ----<<<<<
                    {
                        DataRow row1 = this._exportDataSet.Tables[ExportMoveDataItems.ct_Tbl_Arrival].NewRow();

                        // 企業コード
                        row1[ExportMoveDataItems.ct_Col_EnterpriseCode] = _enterpriseCode;
                        // 拠点コード
                        row1[ExportMoveDataItems.ct_Col_SectionCode] = _loginSectionCode;
                        // 品名
                        row1[ExportMoveDataItems.ct_Col_GoodsName] = ConvertSpecialStr(moveData.GoodsName);
                        // 品番
                        row1[ExportMoveDataItems.ct_Col_GoodsNo] = ConvertSpecialStr(moveData.GoodsNo);
                        // メーカーコード
                        row1[ExportMoveDataItems.ct_Col_GoodsMakerCd] = moveData.GoodsMakerCd.ToString().PadLeft(4, '0');
                        // メーカー名
                        row1[ExportMoveDataItems.ct_Col_MakerName] = ConvertSpecialStr(moveData.MakerName);
                        // BLｺｰﾄﾞ
                        row1[ExportMoveDataItems.ct_Col_BLGoodsCode] = moveData.BLGoodsCode;
                        // 出荷数
                        // UPD BY 宋剛 2016/02/16 Redmine#48629の障害一覧No.13　出荷数の小数点以下が切り捨てされない仕様変更対応 ---->>>>>
                        // row1[ExportMoveDataItems.ct_Col_ShipmentCount] = moveData.StockCnt;
                        row1[ExportMoveDataItems.ct_Col_ShipmentCount] = CutDownNum(moveData.StockCnt);
                        // UPD BY 宋剛 2016/02/16 Redmine#48629の障害一覧No.13　出荷数の小数点以下が切り捨てされない仕様変更対応 ----<<<<<
                        // オープン価格区分
                        row1[ExportMoveDataItems.ct_Col_OpenPriceDiv] = moveData.OpenPriceDiv;
                        // DEL BY 宋剛 2016/02/15 FOR Redmine#48629の#64の　売価率と単価の整数出力対応 ---->>>>>
                        //// 販売単価
                        //row1[ExportMoveDataItems.ct_Col_SalesPrice] = moveData.SalesUnitCost.ToString(formatFraction);
                        //// 売価率
                        //row1[ExportMoveDataItems.ct_Col_SalesRate] = moveData.SalesRateVal.ToString(formatFraction);
                        // DEL BY 宋剛 2016/02/15 FOR Redmine#48629の#64の　売価率と単価の整数出力対応 ----<<<<<
                        // ADD BY 宋剛 2016/02/15 FOR Redmine#48629の#64の　売価率と単価の整数出力対応 ---->>>>>
                        // 販売単価
                        // row1[ExportMoveDataItems.ct_Col_SalesPrice] = Math.Floor(moveData.SalesUnitCost).ToString(formatFraction);// DEL BY 宋剛 2016/02/15 FOR Redmine#48629の#70の　販売単価などのカンマは必要ないので削除する
                        //売価率設定がある場合は販売単価の設定は0とする。
                        if ((int)moveData.SalesRateVal > 0)
                        {
                            row1[ExportMoveDataItems.ct_Col_SalesPrice] = '0';
                        }
                        else
                        {
                            row1[ExportMoveDataItems.ct_Col_SalesPrice] = Math.Floor(moveData.SalesUnitCost).ToString();// ADD BY 宋剛 2016/02/15 FOR Redmine#48629の#70の　販売単価などのカンマは必要ないので削除する
                        }
                        // 売価率
                        row1[ExportMoveDataItems.ct_Col_SalesRate] = Math.Floor(moveData.SalesRateVal).ToString(formatFraction);
                        // ADD BY 宋剛 2016/02/15 FOR Redmine#48629の#64の　売価率と単価の整数出力対応 ----<<<<<
                        // 倉庫
                        if (!string.IsNullOrEmpty(moveData.WarehouseCode))
                        {
                            row1[ExportMoveDataItems.ct_Col_WarehCode] = moveData.WarehouseCode.Trim().PadLeft(4, '0');
                        }
                        else
                        {
                            row1[ExportMoveDataItems.ct_Col_WarehCode] = string.Empty;
                        }
                        
                        // 倉庫名
                        row1[ExportMoveDataItems.ct_Col_WarehName] = ConvertSpecialStr(moveData.WarehouseNm);

                        this._exportDataSet.Tables[ExportMoveDataItems.ct_Tbl_Arrival].Rows.Add(row1);

                    }
                    #endregion

                    #endregion


                }
            }
        }

        // ADD BY 宋剛 2016/02/16 Redmine#48629の障害一覧No.13　出荷数の小数点以下が切り捨てされない仕様変更対応 ---->>>>>
        /// <summary>
        /// 数字の切り捨てる処理
        /// </summary>
        /// <param name="num">数字</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 数字の切り捨てる処理を行う。</br>
        /// <br>Programmer : 宋剛</br>
        /// <br>Date       : 2016/02/16</br>
        /// </remarks>
        private string CutDownNum(double num)
        {
            string retNum = "0";

            if (num >= 0)
            {
                retNum = Math.Floor(num).ToString();
            }
            else
            {
                retNum = (Math.Floor(Math.Abs(num)) * -1).ToString();
            }

            return retNum;
        }
        // ADD BY 宋剛 2016/02/16 Redmine#48629の障害一覧No.13　出荷数の小数点以下が切り捨てされない仕様変更対応 ----<<<<<

        /// <summary>
        /// 文字列 " ⇒ "" の変換
        /// </summary>
        /// <param name="inputStr">文字列</param>
        /// <returns>変換結果</returns>
        /// <remarks>
        /// <br>Note       : 文字列 " ⇒ "" の変換を行う。</br>
        /// <br>Programmer : 宋剛</br>
        /// <br>Date       : 2016/01/22</br>
        /// </remarks>
        public string ConvertSpecialStr(string inputStr)
        {
            string retStr = inputStr;
            string replaceStrSrc = "\"";
            string replaceStrDest = "\"\"";

            if (!string.IsNullOrEmpty(inputStr) && inputStr.Contains(replaceStrSrc))
            {
                retStr = inputStr.Replace(replaceStrSrc, replaceStrDest);
            }

            return retStr;
        }

        /// <summary>
        /// CSV出力処理
        /// </summary>
        /// <param name="formattedTextWriter">出力Info</param>
        /// <param name="dataSource">出力データ</param>
        /// <param name="fileName">出力ファイル</param>
        /// <param name="mode">0:出品更新一覧,1:出品更新警告一覧</param>
        /// <param name="titleOutputFlg">タイトル出力フラグ（true: 出力しました　false:未出力）</param>
        /// <param name="errMessage">ｴﾗｰメッセージ</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : CSV出力処理を行う。</br>
        /// <br>Programmer : 宋剛</br>
        /// <br>Date       : 2016/01/22</br>
        /// </remarks>
        private int DoOutPut(ref FormattedTextWriter formattedTextWriter, DataView dataSource, string fileName, int mode, ref Boolean titleOutputFlg, out string errMessage)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            errMessage = "";
            List<string> schemeList = new List<string>();

            try
            {
                #region 移動データschemeList
                // 企業コード
                schemeList.Add(ExportMoveDataItems.ct_Col_EnterpriseCode);
                // 拠点コード
                schemeList.Add(ExportMoveDataItems.ct_Col_SectionCode);
                // 倉庫
                schemeList.Add(ExportMoveDataItems.ct_Col_WarehCode);
                // 倉庫名
                schemeList.Add(ExportMoveDataItems.ct_Col_WarehName);
                // 品名
                schemeList.Add(ExportMoveDataItems.ct_Col_GoodsName);
                // 品番
                schemeList.Add(ExportMoveDataItems.ct_Col_GoodsNo);
                // メーカーコード
                schemeList.Add(ExportMoveDataItems.ct_Col_GoodsMakerCd);
                // メーカー名
                schemeList.Add(ExportMoveDataItems.ct_Col_MakerName);
                // BLｺｰﾄﾞ
                schemeList.Add(ExportMoveDataItems.ct_Col_BLGoodsCode);
                // オープン価格区分
                schemeList.Add(ExportMoveDataItems.ct_Col_OpenPriceDiv);
                // 販売単価
                schemeList.Add(ExportMoveDataItems.ct_Col_SalesPrice);
                // 売価率
                schemeList.Add(ExportMoveDataItems.ct_Col_SalesRate);
                // 出荷数
                schemeList.Add(ExportMoveDataItems.ct_Col_ShipmentCount);
                

                if (mode == 1)
                {
                    // 警告理由
                    schemeList.Add(ExportMoveDataItems.ct_Col_AlertReason);
                }
                #endregion

                List<Type> enclosingTypeList = new List<Type>();
                enclosingTypeList.Add("".GetType());

                formattedTextWriter.DataSource = dataSource;
                formattedTextWriter.DataMember = String.Empty;
                formattedTextWriter.OutputFileName = fileName;

                //テキスト出力する項目名のリスト
                formattedTextWriter.SchemeList = schemeList;
                formattedTextWriter.Splitter = ",";
                formattedTextWriter.Encloser = "\"";
                formattedTextWriter.EnclosingTypeList = enclosingTypeList;
                formattedTextWriter.FormatList = null;
                if ((titleOutputFlg == false) && (dataSource.Count > 0))
                {
                    formattedTextWriter.CaptionOutput = true;

                    titleOutputFlg = true;
                }
                else
                {
                    formattedTextWriter.CaptionOutput = false;
                }
                formattedTextWriter.FixedLength = false;
                formattedTextWriter.ReplaceList = null;
                formattedTextWriter.OutputMode = true; // 続き出力

                int totalCount;
                status = formattedTextWriter.TextOut(out totalCount);
            }
            catch(Exception ex)
            {
                errMessage = ex.Message;
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }

        /// <summary>
        /// 出力条件設定処理(画面→出力条件)
        /// </summary>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 出力条件設定処理(画面→出力条件)を行う。</br>
        /// <br>Programmer : 宋剛</br>
        /// <br>Date       : 2016/01/22</br>
        /// </remarks>
        private int SetExtraInfoFromScreen()
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            try
            { 
                // 企業ｺｰﾄﾞ
                _searchCond.EnterpriseCode = _enterpriseCode;

                // 拠点ｺｰﾄﾞ
                _searchCond.LoginUserSecCode = LoginInfoAcquisition.Employee.BelongSectionCode.Trim();

                // 得意先ｺｰﾄﾞ
                _searchCond.CustomerCode = this.tNedit_CustomerCode.GetInt();

                // 倉庫
                String tempWarehouseCode = "";
                Hashtable tempWarehouseCodeList = new Hashtable();
                for (int i = 0; i < checkedListBox_Warehouse.Items.Count; i++)
                {
                    if (checkedListBox_Warehouse.GetItemChecked(i))
                    {
                        tempWarehouseCode = checkedListBox_Warehouse.GetItemText(checkedListBox_Warehouse.Items[i]);
                        tempWarehouseCodeList.Add(tempWarehouseCode.Substring(0, 4), tempWarehouseCode);
                    }
                }
                _searchCond.WarehouseCodes = (string[])new ArrayList(tempWarehouseCodeList.Keys).ToArray(typeof(string));

                // 在庫最終更新日付
                _searchCond.LastStockUpdDate = this.tDateEdit_LastStockUpdDate.LongDate;

                // BLCODE
                _searchCond.BLGoodsCode = this.tNedit_BLGoodsCode.GetInt();

                // 部品メーカー
                _searchCond.GoodsMakerCd = this.tNedit_GoodsMakerCd.GetInt();

                // 中分類
                _searchCond.GoodsMGroup = tNedit_GoodsMGroup.GetInt();

                // 商品掛率G
                _searchCond.RateGrpCode = tNedit_RateGrpCode.GetInt();

                // 仕入先
                _searchCond.SupplierCd = tNedit_SupplierCd.GetInt();

                // 価格算出日付
                _searchCond.PriceStartDate = this.tDateEdit_priceCalDate.LongDate;
            }
            catch (Exception)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }

            return status;
        }

        /// <summary>
        /// ChangeFocus イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : なし</br>
        /// <br>Programmer : 宋剛</br>
        /// <br>Date       : 2016/01/22</br>
        /// </remarks>
        private void tRetKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null)
            {
                return;
            }

            this._prevControl = e.NextCtrl;

            isErrorMsgboxShow = false;

            switch (e.PrevCtrl.Name)
            {
                // 得意先ｺｰﾄﾞ
                case "tNedit_CustomerCode":
                    {
                        bool canChangeFocus = true;
                        // 非数字のハードコピーの防ぎ
                        if (!string.IsNullOrEmpty(this.tNedit_CustomerCode.Text.Trim()))
                        {
                            int customerCode = 0;
                            if (!int.TryParse(this.tNedit_CustomerCode.Text.Trim(), out customerCode) || customerCode < 0)
                            {
                                int customerCodeBak;
                                if (string.IsNullOrEmpty(this._customerCodeStr))
                                {
                                    this.tNedit_CustomerCode.Text = string.Empty;
                                }
                                else
                                {
                                    if (Int32.TryParse(this._customerCodeStr, out customerCodeBak))
                                    {
                                        this.tNedit_CustomerCode.SetInt(customerCodeBak);
                                        e.NextCtrl = e.PrevCtrl;
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                canChangeFocus = this.GetCustomerName(customerCode, getName_FocusChangeMode);
                            }
                        }
                        else
                        {
                            // 得意先入力しない場合
                            if (!String.IsNullOrEmpty(uLabel_CustomerName.Text))
                            {
                                uLabel_CustomerName.Text = string.Empty;
                                this._customerCodeStr = string.Empty;
                            }
                        }

                        if (canChangeFocus)
                        {
                            this._customerCodeStr = this.tNedit_CustomerCode.Text.Trim();
                            if (!e.ShiftKey)
                            {
                                switch (e.Key)
                                {
                                    case Keys.Tab:
                                    case Keys.Enter:
                                        {
                                            if (string.IsNullOrEmpty(this.tNedit_CustomerCode.Text.Trim()))
                                            {
                                                e.NextCtrl = this.uButton_CustomerCode; // 得意先ｺｰﾄﾞ
                                            }
                                            else
                                            {
                                                e.NextCtrl = this.checkedListBox_Warehouse; // 倉庫コード
                                            }
                                        }
                                        break;
                                }
                            }
                        }
                        else
                        {
                            int customerCode;
                            if (string.IsNullOrEmpty(this._customerCodeStr))
                            {
                                this.tNedit_CustomerCode.Text = string.Empty;
                            }
                            else
                            {
                                if (Int32.TryParse(this._customerCodeStr, out customerCode))
                                {
                                    this.tNedit_CustomerCode.SetInt(customerCode);
                                }
                            }
                            e.NextCtrl = e.PrevCtrl;
                        }

                        break;
                    }
                // BLコード
                case "tNedit_BLGoodsCode":
                    {
                        bool canChangeFocus = true;
                        // 非数字のハードコピーの防ぎ
                        if (!string.IsNullOrEmpty(this.tNedit_BLGoodsCode.Text.Trim()))
                        {
                            int blGoodsCode = 0;
                            if (!int.TryParse(this.tNedit_BLGoodsCode.Text.Trim(), out blGoodsCode) || blGoodsCode < 0)
                            {
                                int blCode;
                                if (string.IsNullOrEmpty(this._blCodeStr))
                                {
                                    this.tNedit_BLGoodsCode.Text = string.Empty;
                                }
                                else
                                {
                                    if (Int32.TryParse(this._blCodeStr, out blCode))
                                    {
                                        this.tNedit_BLGoodsCode.SetInt(blCode);
                                        e.NextCtrl = e.PrevCtrl;
                                        break;
                                    }
                                }
                            }

                            if (this.tNedit_BLGoodsCode.GetInt() != 0)
                            {
                                canChangeFocus = this.GetBlCodeName(blGoodsCode, getName_FocusChangeMode);
                            }
                            else
                            {
                                this.tNedit_BLGoodsCode.SetInt(0);
                                this.BLtEdit_GoodsName.Text = "";
                            }
                        }
                        else
                        {
                            this.tNedit_BLGoodsCode.SetInt(0);
                            this.BLtEdit_GoodsName.Text = "";
                        }

                        if (canChangeFocus)
                        {
                            this._blCodeStr = this.tNedit_BLGoodsCode.Text.Trim();
                            if (!e.ShiftKey)
                            {
                                switch (e.Key)
                                {
                                    case Keys.Tab:
                                    case Keys.Return:
                                        {
                                            if (this.tNedit_BLGoodsCode.GetInt() != 0)
                                            {
                                                e.NextCtrl = this.tNedit_GoodsMakerCd;
                                            }
                                            else
                                            {
                                                e.NextCtrl = this.uButton_BLGoodsGuide;
                                            }
                                        }
                                        break;
                                }
                            }
                        }
                        else
                        {
                            int blCode;
                            if (string.IsNullOrEmpty(this._blCodeStr))
                            {
                                this.tNedit_BLGoodsCode.Text = string.Empty;
                            }
                            else
                            {
                                if (Int32.TryParse(this._blCodeStr, out blCode))
                                {
                                    this.tNedit_BLGoodsCode.SetInt(blCode);
                                }
                            }
                            e.NextCtrl = e.PrevCtrl;
                        }
                        break;     
                    }
                // メーカー
                case "tNedit_GoodsMakerCd":
                    {
                        bool canChangeFocus = true;
                        // 非数字のハードコピーの防ぎ
                        if (!string.IsNullOrEmpty(this.tNedit_GoodsMakerCd.Text.Trim()))
                        {
                            int goodsMakerCd = 0;
                            if (!int.TryParse(this.tNedit_GoodsMakerCd.Text.Trim(), out goodsMakerCd) || goodsMakerCd < 0)
                            {
                                int makerCode;
                                if (string.IsNullOrEmpty(this._makerCodeStr))
                                {
                                    this.tNedit_GoodsMakerCd.Text = string.Empty;
                                }
                                else
                                {
                                    if (Int32.TryParse(this._makerCodeStr, out makerCode))
                                    {
                                        this.tNedit_GoodsMakerCd.SetInt(makerCode);
                                        e.NextCtrl = e.PrevCtrl;
                                        break;
                                    }
                                }
                            }

                            if (this.tNedit_GoodsMakerCd.GetInt() != 0)
                            {
                                canChangeFocus = this.GetMakerCodeName(goodsMakerCd, getName_FocusChangeMode);
                            }
                            else
                            {
                                this.tNedit_GoodsMakerCd.SetInt(0);
                                this.uLabel_GoodsMakerCd.Text = "";
                            }
                        }
                        else
                        {
                            this.tNedit_GoodsMakerCd.SetInt(0);
                            this.uLabel_GoodsMakerCd.Text = "";
                        }

                        if (canChangeFocus)
                        {
                            this._makerCodeStr = this.tNedit_GoodsMakerCd.Text.Trim();
                            if (!e.ShiftKey)
                            {
                                switch (e.Key)
                                {
                                    case Keys.Tab:
                                    case Keys.Return:
                                        {
                                            if (this.tNedit_GoodsMakerCd.GetInt() != 0)
                                            {
                                                e.NextCtrl = this.tNedit_GoodsMGroup;
                                            }
                                            else
                                            {
                                                e.NextCtrl = this.uButton_GoodsMakerCd;
                                            }
                                        }
                                        break;
                                }
                            }
                        }
                        else
                        {
                            int makerCode;
                            if (string.IsNullOrEmpty(this._makerCodeStr))
                            {
                                this.tNedit_GoodsMakerCd.Text = string.Empty;
                            }
                            else
                            {
                                if (Int32.TryParse(this._makerCodeStr, out makerCode))
                                {
                                    this.tNedit_GoodsMakerCd.SetInt(makerCode);
                                }
                            }
                            e.NextCtrl = e.PrevCtrl;
                        }
                        break;
                    }
                // 中分類
                case "tNedit_GoodsMGroup":
                    {
                        bool canChangeFocus = true;
                        // 非数字のハードコピーの防ぎ
                        if (!string.IsNullOrEmpty(this.tNedit_GoodsMGroup.Text.Trim()))
                        {
                            int goodsMGroup = 0;
                            if (!int.TryParse(this.tNedit_GoodsMGroup.Text.Trim(), out goodsMGroup) || goodsMGroup < 0)
                            {
                                int goodsMCode;
                                if (string.IsNullOrEmpty(this._goodsMGroupCodeStr))
                                {
                                    this.tNedit_GoodsMGroup.Text = string.Empty;
                                }
                                else
                                {
                                    if (Int32.TryParse(this._goodsMGroupCodeStr, out goodsMCode))
                                    {
                                        this.tNedit_GoodsMGroup.SetInt(goodsMCode);
                                        e.NextCtrl = e.PrevCtrl;
                                        break;
                                    }
                                }
                            }

                            if (this.tNedit_GoodsMGroup.GetInt() != 0)
                            {
                                canChangeFocus = this.GetGoodsGroupUCodeName(goodsMGroup, getName_FocusChangeMode);
                            }
                            else
                            {
                                // 中分類ｺｰﾄﾞ
                                this.tNedit_GoodsMGroup.SetInt(0);
                                // 中分類名称
                                this.GoodsMGroupName_tEdit.Text = "";
                            }
                        }
                        else
                        {
                            // 中分類ｺｰﾄﾞ
                            this.tNedit_GoodsMGroup.SetInt(0);
                            // 中分類名称
                            this.GoodsMGroupName_tEdit.Text = "";
                        }

                        if (canChangeFocus)
                        {
                            this._goodsMGroupCodeStr = this.tNedit_GoodsMGroup.Text.Trim();
                            if (!e.ShiftKey)
                            {
                                switch (e.Key)
                                {
                                    case Keys.Tab:
                                    case Keys.Return:
                                        {
                                            if (this.tNedit_GoodsMGroup.GetInt() != 0)
                                            {
                                                e.NextCtrl = this.tNedit_RateGrpCode;
                                            }
                                            else
                                            {
                                                e.NextCtrl = this.uButton_GoodsMGroup;
                                            }
                                        }
                                        break;
                                }
                            }
                        }
                        else
                        {
                            int goodsMCode;
                            if (string.IsNullOrEmpty(this._goodsMGroupCodeStr))
                            {
                                this.tNedit_GoodsMGroup.Text = string.Empty;
                            }
                            else
                            {
                                if (Int32.TryParse(this._goodsMGroupCodeStr, out goodsMCode))
                                {
                                    this.tNedit_GoodsMGroup.SetInt(goodsMCode);
                                }
                            }
                            e.NextCtrl = e.PrevCtrl;
                        }
                        break;
                    }
                // 商品掛率Ｇ
                case "tNedit_RateGrpCode":
                    {
                        bool canChangeFocus = true;
                        // 非数字のハードコピーの防ぎ
                        if (!string.IsNullOrEmpty(this.tNedit_RateGrpCode.Text.Trim()))
                        {
                            int goodsRateGrpCode = 0;
                            if (!int.TryParse(this.tNedit_RateGrpCode.Text.Trim(), out goodsRateGrpCode) || goodsRateGrpCode < 0)
                            {
                                int rateGrpCode;
                                if (string.IsNullOrEmpty(this._rateGrpCodeStr))
                                {
                                    this.tNedit_RateGrpCode.Text = string.Empty;
                                }
                                else
                                {
                                    if (Int32.TryParse(this._rateGrpCodeStr, out rateGrpCode))
                                    {
                                        this.tNedit_RateGrpCode.SetInt(rateGrpCode);
                                        e.NextCtrl = e.PrevCtrl;
                                        break;
                                    }
                                }
                            }

                            if (this.tNedit_RateGrpCode.GetInt() != 0)
                            {
                                canChangeFocus = this.GetGoodsRateGrpCodeName(goodsRateGrpCode, getName_FocusChangeMode);
                            }
                            else
                            {
                                // 商品掛率Ｇ
                                this.tNedit_RateGrpCode.SetInt(0);
                                // 商品掛率Ｇ名称
                                this.GoodsRateGrpName_tEdit.Text = "";
                            }
                        }
                        else
                        {
                            // 商品掛率Ｇ
                            this.tNedit_RateGrpCode.SetInt(0);
                            // 商品掛率Ｇ名称
                            this.GoodsRateGrpName_tEdit.Text = "";
                        }

                        if (canChangeFocus)
                        {
                            this._rateGrpCodeStr = this.tNedit_RateGrpCode.Text.Trim();
                            if (!e.ShiftKey)
                            {
                                switch (e.Key)
                                {
                                    case Keys.Tab:
                                    case Keys.Return:
                                        {
                                            if (this.tNedit_RateGrpCode.GetInt() != 0)
                                            {
                                                e.NextCtrl = this.tNedit_SupplierCd;
                                            }
                                            else
                                            {
                                                e.NextCtrl = this.uButton_RateGrpCode;
                                            }
                                        }
                                        break;
                                }
                            }
                        }
                        else
                        {
                            int rateGrpCode;
                            if (string.IsNullOrEmpty(this._rateGrpCodeStr))
                            {
                                this.tNedit_RateGrpCode.Text = string.Empty;
                            }
                            else
                            {
                                if (Int32.TryParse(this._rateGrpCodeStr, out rateGrpCode))
                                {
                                    this.tNedit_RateGrpCode.SetInt(rateGrpCode);
                                }
                            }
                            e.NextCtrl = e.PrevCtrl;
                        }
                        break;
                    }
                // 仕入先
                case "tNedit_SupplierCd":
                    {
                        bool canChangeFocus = true;
                        // 非数字のハードコピーの防ぎ
                        if (!string.IsNullOrEmpty(this.tNedit_SupplierCd.Text.Trim()))
                        {
                            int supplierCd = 0;
                            if (!int.TryParse(this.tNedit_SupplierCd.Text.Trim(), out supplierCd) || supplierCd < 0)
                            {
                                int suppilerCode;
                                if (string.IsNullOrEmpty(this._suppilerCodeStr))
                                {
                                    this.tNedit_SupplierCd.Text = string.Empty;
                                }
                                else
                                {
                                    if (Int32.TryParse(this._suppilerCodeStr, out suppilerCode))
                                    {
                                        this.tNedit_SupplierCd.SetInt(suppilerCode);
                                        e.NextCtrl = e.PrevCtrl;
                                        break;
                                    }
                                }
                            }

                            if (this.tNedit_SupplierCd.GetInt() != 0)
                            {
                                canChangeFocus = this.GetSupplierCdName(supplierCd, getName_FocusChangeMode);
                            }
                            else
                            {
                                // 仕入先ｺｰﾄﾞ
                                this.tNedit_SupplierCd.SetInt(0);
                                // 仕入先名称
                                this.uLabel_SupplierCd.Text = "";
                            }
                        }
                        else
                        {
                            // 仕入先ｺｰﾄﾞ
                            this.tNedit_SupplierCd.SetInt(0);
                            // 仕入先名称
                            this.uLabel_SupplierCd.Text = "";
                        }

                        if (canChangeFocus)
                        {
                            this._suppilerCodeStr = this.tNedit_SupplierCd.Text.Trim();
                            if (!e.ShiftKey)
                            {
                                switch (e.Key)
                                {
                                    case Keys.Tab:
                                    case Keys.Return:
                                        {
                                            if (this.tNedit_SupplierCd.GetInt() != 0)
                                            {
                                                e.NextCtrl = this.tDateEdit_priceCalDate;
                                            }
                                            else
                                            {
                                                e.NextCtrl = this.uButton_SupplierCd;
                                            }
                                        }
                                        break;
                                }
                            }
                        }
                        else
                        {
                            int suppilerCode;
                            if (string.IsNullOrEmpty(this._suppilerCodeStr))
                            {
                                this.tNedit_SupplierCd.Text = string.Empty;
                            }
                            else
                            {
                                if (Int32.TryParse(this._suppilerCodeStr, out suppilerCode))
                                {
                                    this.tNedit_SupplierCd.SetInt(suppilerCode);
                                }
                            }
                            e.NextCtrl = e.PrevCtrl;
                        }
                        break;
                    }
                // 在庫最終更新日付
                case "tDateEdit_LastStockUpdDate":
                    {
                        // 非数字のハードコピーの防ぎ
                        if (this.tDateEdit_LastStockUpdDate.GetDateYear() == 0 || this.tDateEdit_LastStockUpdDate.GetDateMonth() == 0 || this.tDateEdit_LastStockUpdDate.GetDateDay() == 0)
                        {
                            this.tDateEdit_LastStockUpdDate.Clear();
                            break;
                        }

                        break;
                    }
                // 価格算出日付
                case "tDateEdit_priceCalDate":
                    {
                        // 非数字のハードコピーの防ぎ
                        if (this.tDateEdit_priceCalDate.GetDateYear() == 0 || this.tDateEdit_priceCalDate.GetDateMonth() == 0 || this.tDateEdit_priceCalDate.GetDateDay() == 0)
                        {
                            this.tDateEdit_priceCalDate.Clear();
                            break;
                        }

                        break;
                    }
                // 売価率
                case "tNedit_SalesRate":
                    {
                        bool numFlag = false;
                        int changeNum;
                        numFlag = Int32.TryParse(this.tNedit_SalesRate.Text.Trim(), out changeNum);
                        // 非数字、マイナス、100以上の場合、前回の値を戻る
                        if (!numFlag || changeNum < 0 || this.tNedit_SalesRate.GetInt() > 100)
                        {
                            // クリアーする場合
                            if (string.IsNullOrEmpty(this.tNedit_SalesRate.Text.Trim()))
                            {
                                this.tNedit_SalesRate.DataText = string.Empty;
                            }
                            // 前回の値を戻る
                            else
                            {
                                int setSalesRate;
                                if (Int32.TryParse(this._salesRateStr, out setSalesRate))
                                {
                                    this.tNedit_SalesRate.SetInt(setSalesRate);
                                }
                                else
                                {
                                    this.tNedit_SalesRate.DataText = string.Empty;
                                }
                            }
                        }
                        else
                        {
                            this.tNedit_SalesRate.SetInt(changeNum);
                        }
                        break;
                    }
                // 販売単価
                case "tNedit_SalesPrice":
                    {
                        bool numFlag = false;
                        int changeNum;
                        numFlag = Int32.TryParse(this.tNedit_SalesPrice.Text.Trim(), out changeNum);
                        // 非数字、マイナスの場合、前回の値を戻る
                        if (!numFlag || changeNum < 0)
                        {
                            // クリアーする場合
                            if (string.IsNullOrEmpty(this.tNedit_SalesPrice.Text.Trim()))
                            {
                                this.tNedit_SalesPrice.DataText = string.Empty;
                            }
                            // 前回の値を戻る
                            else
                            {
                                int setSalesPrice;
                                if (Int32.TryParse(this._salesPriceStr, out setSalesPrice))
                                {
                                    this.tNedit_SalesPrice.SetInt(setSalesPrice);
                                }
                                else
                                {
                                    this.tNedit_SalesPrice.DataText = string.Empty;
                                }
                            }
                        }
                        // Length>7の場合、前7桁だけを表示する
                        else if (this.tNedit_SalesPrice.Text.Trim().Length > 7)
                        {
                            this.tNedit_SalesPrice.DataText = this.tNedit_SalesPrice.Text.Trim().Substring(0, 7);
                        }
                        else
                        {
                            this.tNedit_SalesPrice.SetInt(changeNum);
                        }
                        break;
                    }
            }

            this._prevControl = e.NextCtrl;
        }

        /// <summary>
        /// 得意先名称取得
        /// </summary>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="searchMode">検索モード</param>
        /// <remarks>
        /// <br>Note        : 得意先名称取得</br>
        /// <br>Programmer  : 宋剛</br>
        /// <br>Date        : 2016/01/22</br>
        /// <br>UpdateNote : 宋剛 2016/02/15</br>
        /// <br>           : Redmine#48629の障害一覧No.10　得意先マスタ.略称対応</br>
        /// </remarks>
        private bool GetCustomerName(int customerCode, int searchMode)
        {
            bool canChangeFocus = true;
            // 得意先名称取得
            CustomerInfoAcs customerInfoAcs = new CustomerInfoAcs();
            CustomerInfo customerInfo;
            int status = customerInfoAcs.ReadDBData(this._enterpriseCode, this.tNedit_CustomerCode.GetInt(), out customerInfo);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // UPD BY 宋剛 2016/02/15 FOR Redmine#48629の障害一覧No.10　得意先マスタ.略称対応 ---->>>>>
                // uLabel_CustomerName.Text = customerInfo.Name;
                uLabel_CustomerName.Text = customerInfo.CustomerSnm; // 略称
                // UPD BY 宋剛 2016/02/15 FOR Redmine#48629の障害一覧No.10　得意先マスタ.略称対応 ----<<<<<
            }
            else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                if (searchMode == getName_XMLReadMode)
                {
                    return canChangeFocus;
                }
                //"得意先コード[{0:00000000}]は存在しないか、削除されています。"
                string errorMsg = string.Format(PMMAX02010UE.M_001, customerCode);
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                    this.Name,
                    errorMsg,
                    -1,
                    MessageBoxButtons.OK);
                canChangeFocus = false;
                isErrorMsgboxShow = true;
            }
            else
            {
                if (searchMode == getName_XMLReadMode)
                {
                    return canChangeFocus;
                }
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_STOPDISP,
                    this.Name,
                    "得意先の取得に失敗しました。",
                    status,
                    MessageBoxButtons.OK);
                canChangeFocus = false;
                isErrorMsgboxShow = true;
            }

            return canChangeFocus;
        }

        /// <summary>
        /// BLコード名称の取得
        /// </summary>
        /// <param name="blGoodsCode">BLコード</param>
        /// <param name="searchMode">検索モード</param>
        /// <remarks>
        /// <br>Note        : BLコード名称の取得</br>
        /// <br>Programmer  : 宋剛</br>
        /// <br>Date        : 2016/01/22</br>
        /// </remarks>
        private bool GetBlCodeName(int blGoodsCode, int searchMode)
        {
            bool canChangeFocus = true;
            BLGoodsCdUMnt blGoodsCdUMnt = new BLGoodsCdUMnt();
            int status = GetBLGoodsCdUMnt(this.tNedit_BLGoodsCode.GetInt(), out blGoodsCdUMnt);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // BLｺｰﾄﾞ
                this.tNedit_BLGoodsCode.SetInt(blGoodsCdUMnt.BLGoodsCode);
                // BL名称
                this.BLtEdit_GoodsName.Text = blGoodsCdUMnt.BLGoodsHalfName;
            }
            else
            {
                if (searchMode == getName_XMLReadMode)
                {
                    return canChangeFocus;
                }
                string errMsg = string.Format(PMMAX02010UE.M_035, blGoodsCode);
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                    this.Name,
                    errMsg,
                    -1,
                    MessageBoxButtons.OK);
                canChangeFocus = false;
                isErrorMsgboxShow = true;
            }

            return canChangeFocus;
        }

        /// <summary>
        /// メーカー名称の取得
        /// </summary>
        /// <param name="goodsMakerCd">メーカーコード</param>
        /// <param name="searchMode">検索モード</param>
        /// <remarks>
        /// <br>Note        : メーカー名称の取得</br>
        /// <br>Programmer  : 宋剛</br>
        /// <br>Date        : 2016/01/22</br>
        /// </remarks>
        private bool GetMakerCodeName(int goodsMakerCd, int searchMode)
        {
            bool canChangeFocus = true;

            MakerUMnt makerUMnt = new MakerUMnt();
            int status = _makerAcs.Read(out makerUMnt, _enterpriseCode, goodsMakerCd);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (makerUMnt.LogicalDeleteCode == 0)
                {
                    // メーカーｺｰﾄﾞ
                    this.tNedit_GoodsMakerCd.SetInt(makerUMnt.GoodsMakerCd);
                    // メーカー名称
                    this.uLabel_GoodsMakerCd.Text = makerUMnt.MakerName;
                }
                else
                {
                    if (searchMode == getName_XMLReadMode)
                    {
                        return canChangeFocus;
                    }
                    string errMsg = string.Format(PMMAX02010UE.M_036, goodsMakerCd);
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                        this.Name,
                        errMsg,
                        -1,
                        MessageBoxButtons.OK);
                    canChangeFocus = false;
                    isErrorMsgboxShow = true;
                }
            }
            else
            {
                if (searchMode == getName_XMLReadMode)
                {
                    return canChangeFocus;
                }
                string errMsg = string.Format(PMMAX02010UE.M_036, goodsMakerCd);
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                    this.Name,
                    errMsg,
                    -1,
                    MessageBoxButtons.OK);
                canChangeFocus = false;
                isErrorMsgboxShow = true;
            }

            return canChangeFocus;
        }

        /// <summary>
        /// 中分類名称の取得
        /// </summary>
        /// <param name="goodsGroupUCode">中分類コード</param>
        /// <param name="searchMode">検索モード</param>
        /// <remarks>
        /// <br>Note        : 中分類名称の取得</br>
        /// <br>Programmer  : 宋剛</br>
        /// <br>Date        : 2016/01/22</br>
        /// </remarks>
        private bool GetGoodsGroupUCodeName(int goodsGroupUCode, int searchMode)
        {
            bool canChangeFocus = true;
            
            GoodsGroupU goodsGroupU = new GoodsGroupU();

            int status = _goodsGroupUAcs.Search(out goodsGroupU, _enterpriseCode, goodsGroupUCode);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (goodsGroupU.LogicalDeleteCode == 0)
                {
                    this.tNedit_GoodsMGroup.SetInt(goodsGroupU.GoodsMGroup);
                    this.GoodsMGroupName_tEdit.Text = goodsGroupU.GoodsMGroupName;
                }
                else
                {
                    if (searchMode == getName_XMLReadMode)
                    {
                        return canChangeFocus;
                    }
                    string errMsg = string.Format(PMMAX02010UE.M_043, goodsGroupUCode);
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                        this.Name,
                        errMsg,
                        -1,
                        MessageBoxButtons.OK);
                    canChangeFocus = false;
                    isErrorMsgboxShow = true;
                }
            }
            else
            {
                if (searchMode == getName_XMLReadMode)
                {
                    return canChangeFocus;
                }
                string errMsg = string.Format(PMMAX02010UE.M_043, goodsGroupUCode);
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                    this.Name,
                    errMsg,
                    -1,
                    MessageBoxButtons.OK);
                canChangeFocus = false;
                isErrorMsgboxShow = true;
            }

            return canChangeFocus;
        }

        /// <summary>
        /// 商品掛率グループ名称の取得
        /// </summary>
        /// <param name="goodsRateGrpCode">商品掛率グループコード</param>
        /// <param name="searchMode">検索モード</param>
        /// <remarks>
        /// <br>Note        : 商品掛率グループ名称の取得</br>
        /// <br>Programmer  : 宋剛</br>
        /// <br>Date        : 2016/01/22</br>
        /// </remarks>
        private bool GetGoodsRateGrpCodeName(int goodsRateGrpCode, int searchMode)
        {
            bool canChangeFocus = true;
            GoodsGroupU goodsGroupU = new GoodsGroupU();

            int status = _goodsGroupUAcs.Search(out goodsGroupU, _enterpriseCode, goodsRateGrpCode);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (goodsGroupU.LogicalDeleteCode == 0)
                {
                    this.tNedit_RateGrpCode.SetInt(goodsGroupU.GoodsMGroup);
                    this.GoodsRateGrpName_tEdit.Text = goodsGroupU.GoodsMGroupName;
                }
                else
                {
                    if (searchMode == getName_XMLReadMode)
                    {
                        return canChangeFocus;
                    }
                    string errMsg = string.Format(PMMAX02010UE.M_037, goodsRateGrpCode);
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                        this.Name,
                        errMsg,
                        -1,
                        MessageBoxButtons.OK);
                    canChangeFocus = false;
                    isErrorMsgboxShow = true;
                }
            }
            else
            {
                if (searchMode == getName_XMLReadMode)
                {
                    return canChangeFocus;
                }
                string errMsg = string.Format(PMMAX02010UE.M_037, goodsRateGrpCode);
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                    this.Name,
                    errMsg,
                    -1,
                    MessageBoxButtons.OK);
                canChangeFocus = false;
                isErrorMsgboxShow = true;
            }

            return canChangeFocus;
        }

        /// <summary>
        /// 仕入先名称の取得
        /// </summary>
        /// <param name="supplierCd">仕入先コード</param>
        /// <param name="searchMode">検索モード</param>
        /// <remarks>
        /// <br>Note        : 仕入先名称の取得</br>
        /// <br>Programmer  : 宋剛</br>
        /// <br>Date        : 2016/01/22</br>
        /// <br>UpdateNote : 宋剛 2016/02/17</br>
        /// <br>           : Redmine#48629の障害一覧No.19　仕入先フォーカスを移動すると支払先コード設定障害対応</br>
        /// </remarks>
        private bool GetSupplierCdName(int supplierCd, int searchMode)
        {
            bool canChangeFocus = true;
            Supplier supplier = new Supplier();

            int status = _supplierAcs.Read(out supplier, _enterpriseCode, supplierCd);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (supplier.LogicalDeleteCode == 0)
                {
                    // UPD BY 宋剛 2016/02/18 FRO Redmine#48629の障害一覧No.19　仕入先フォーカスを移動すると支払先コード設定障害対応 ---->>>>>
                    //this.tNedit_SupplierCd.SetInt(supplier.PayeeCode);
                    //this.uLabel_SupplierCd.Text = supplier.PayeeSnm;
                    this.tNedit_SupplierCd.SetInt(supplier.SupplierCd);
                    this.uLabel_SupplierCd.Text = supplier.SupplierSnm;
                    // UPD BY 宋剛 2016/02/18 FRO Redmine#48629の障害一覧No.19　仕入先フォーカスを移動すると支払先コード設定障害対応 ----<<<<<
                }
                else
                {
                    if (searchMode == getName_XMLReadMode)
                    {
                        return canChangeFocus;
                    }
                    string errMsg = string.Format(PMMAX02010UE.M_038, supplierCd);
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                        this.Name,
                        errMsg,
                        -1,
                        MessageBoxButtons.OK);
                    canChangeFocus = false;
                    isErrorMsgboxShow = true;
                }
            }
            else
            {
                if (searchMode == getName_XMLReadMode)
                {
                    return canChangeFocus;
                }
                string errMsg = string.Format(PMMAX02010UE.M_038, supplierCd);
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                    this.Name,
                    errMsg,
                    -1,
                    MessageBoxButtons.OK);
                canChangeFocus = false;
                isErrorMsgboxShow = true;
            }

            return canChangeFocus;
        }

        /// <summary>
        /// GroupCollapsing イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note        : UltraExplorerBarGroup が縮小される前に発生します。</br>
        /// <br>Programmer  : 宋剛</br>
        /// <br>Date        : 2016/01/22</br>
        /// </remarks>
        private void ultraExplorerBar1_GroupCollapsing(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
        {
            if ((e.Group.Key == "ExportFile") ||
                (e.Group.Key == "SearchCond") ||
                (e.Group.Key == "ExportResult"))
            {
                // グループの縮小をキャンセル
                e.Cancel = true;
            }
        }

        /// <summary>
        /// GroupExpanding イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note        : UltraExplorerBarGroup が展開される前に発生します。</br>
        /// <br>Programmer  : 宋剛</br>
        /// <br>Date        : 2016/01/22</br>
        /// </remarks>
        private void ultraExplorerBar1_GroupExpanding(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
        {
            if ((e.Group.Key == "ExportFile") ||
                (e.Group.Key == "SearchCond") ||
                (e.Group.Key == "ExportResult"))
            {
                // グループの展開をキャンセル
                e.Cancel = true;
            }
        }

        /// <summary>
        /// 画面を閉じる時、チェックボックス値の保存
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note        : 画面を閉じる時、チェックボックス値を保存します。</br>
        /// <br>Programmer  : 宋剛</br>
        /// <br>Date        : 2016/01/22</br>
        /// </remarks>
        private void PMMAX02010UB_FormClosed(object sender, FormClosedEventArgs e)
        {
            // なし
        }

        /// <summary>
        /// ファイルを開く
        /// </summary>
        /// <param name="tEdit_FileName">ファイル名コントロール</param>
        /// <remarks>
        /// <br>Note        : ファイルを開く。</br>
        /// <br>Programmer  : 宋剛</br>
        /// <br>Date        : 2016/01/22</br>
        /// </remarks>
        private void OpenCSVFileDialog(TEdit tEdit_FileName)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                // タイトルバーの文字列
                saveFileDialog.Title = "出力ファイル選択";
                saveFileDialog.RestoreDirectory = true;

                try
                {
                    if (string.IsNullOrEmpty(tEdit_FileName.Text.Trim()))
                    {
                        saveFileDialog.InitialDirectory = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                    }
                    else
                    {
                        saveFileDialog.FileName = System.IO.Path.GetFileName(tEdit_FileName.Text);
                        saveFileDialog.InitialDirectory = System.IO.Path.GetDirectoryName(tEdit_FileName.Text);
                    }
                }
                catch
                {
                    // 処理なし
                }
                finally
                {
                    if (string.IsNullOrEmpty(saveFileDialog.InitialDirectory))
                    {
                        saveFileDialog.FileName = string.Empty;
                        saveFileDialog.InitialDirectory = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                    }
                }

                //「ファイルの種類」を指定
                saveFileDialog.Filter = ct_CSVFILTER;
                saveFileDialog.FilterIndex = 1;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    tEdit_FileName.DataText = saveFileDialog.FileName;
                }
            }
        }


        #region 得意先ガイド
        /// <summary>
        /// 得意先ガイドクリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Programmer  : 宋剛</br>
        /// <br>Date        : 2016/01/22</br>
        /// </remarks>
        private void uButton_CustomerCode_Click(object sender, EventArgs e)
        {
            // フォーカス制御用、ガイド呼出前の得意先コード
            PMKHN04005UA customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_CUSTOMER_ONLY, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY);
            customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.CustomerSearchForm_CustomerSelect);
            DialogResult dr = customerSearchForm.ShowDialog(this);

            if (dr == DialogResult.OK)
            {
                Control nextControl = null;
                nextControl = this.checkedListBox_Warehouse;
                // フォーカス
                nextControl.Focus();
            }
        }

        /// <summary>
        /// 得意先選択時発生イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="customerSearchRet">得意先車両検索戻り値クラス</param>
        /// <remarks>
        /// <br>Note　　　  : 得意先コードガイドクリック時に発生イベント</br>
        /// <br>Programmer  : 宋剛</br>
        /// <br>Date        : 2016/01/22</br>
        /// <br>UpdateNote : 宋剛 2016/02/15</br>
        /// <br>           : Redmine#48629の障害一覧No.10　得意先マスタ.略称対応</br>
        /// </remarks>
        private void CustomerSearchForm_CustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        {
            if (customerSearchRet == null) return;

            this.tNedit_CustomerCode.SetInt(customerSearchRet.CustomerCode);
            // UPD BY 宋剛 2016/02/15 FOR Redmine#48629の障害一覧No.10　得意先マスタ.略称対応 ---->>>>>
            //this.uLabel_CustomerName.Text = customerSearchRet.Name;
            this.uLabel_CustomerName.Text = customerSearchRet.Snm; // 略称
            // UPD BY 宋剛 2016/02/15 FOR Redmine#48629の障害一覧No.10　得意先マスタ.略称対応 ----<<<<<
            this._customerCodeStr = customerSearchRet.CustomerCode.ToString();
        }
        #endregion

        #region BLｺｰﾄﾞガイドクリック
        /// <summary>
        /// BLｺｰﾄﾞガイドクリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_BLGoodsGuide_Click(object sender, EventArgs e)
        {
            BLGoodsCdUMnt blGoodsCdUMnt = null;

            //ＢＬ商品ガイド起動
            int status = this._blGoodsCdAcs.ExecuteGuid(this._enterpriseCode, out blGoodsCdUMnt);

            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return;

            switch (status)
            {
                //取得
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        if (blGoodsCdUMnt != null)
                        {
                            // BLｺｰﾄﾞ
                            this.tNedit_BLGoodsCode.SetInt(blGoodsCdUMnt.BLGoodsCode);
                            // BL名称
                            this.BLtEdit_GoodsName.Text = blGoodsCdUMnt.BLGoodsHalfName;
                            this._blCodeStr = blGoodsCdUMnt.BLGoodsCode.ToString();
                            // フォーカス設定
                            this.tNedit_GoodsMakerCd.Focus();
                        }
                        break;
                    }
                //キャンセル
                case 1:
                    {
                        break;
                    }
            }
        }

        #endregion

        #region BLCODE情報取得
        /// <summary>
        /// 初期化bl情報
        /// </summary>
        private void InitBlCodeList()
        {
            _blCodeDic = new Dictionary<int, BLGoodsCdUMnt>();

            ArrayList retList;
            int status = this._blGoodsCdAcs.SearchAll(out retList, this._enterpriseCode);

            if (status == (int)(int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                foreach (BLGoodsCdUMnt tempBLGoodsCdUMnt in retList)
                {
                    if (tempBLGoodsCdUMnt.LogicalDeleteCode == 0)
                    {
                        _blCodeDic.Add(tempBLGoodsCdUMnt.BLGoodsCode, tempBLGoodsCdUMnt);
                    }
                }
            }
        }

        /// <summary>
        /// BLCODE情報取得
        /// </summary>
        /// <param name="blCode">blｺｰﾄﾞ</param>
        /// <param name="blGoodsCdUMnt">bl情報</param>
        /// <returns></returns>
        private int GetBLGoodsCdUMnt(int blCode, out BLGoodsCdUMnt blGoodsCdUMnt)
        {
            blGoodsCdUMnt = new BLGoodsCdUMnt();
            if (_blCodeDic != null && _blCodeDic.ContainsKey(blCode))
            {
                blGoodsCdUMnt = _blCodeDic[blCode];
                return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            else
            {
                return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            }
        }
        #endregion

        #region メーカー情報取得（ガイド）
        /// <summary>
        /// メーカー情報取得（ガイド）
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void MakerGuide_uButton_Click(object sender, EventArgs e)
        {
            MakerUMnt makerUMnt = null;


            //メーカーガイド起動
            int status = this._makerAcs.ExecuteGuid(this._enterpriseCode, out makerUMnt);

            switch (status)
            {
                //取得
                case 0:
                    {
                        if (makerUMnt != null)
                        {
                            //
                            this.tNedit_GoodsMakerCd.SetInt(makerUMnt.GoodsMakerCd);
                            this.uLabel_GoodsMakerCd.Text = makerUMnt.MakerName;
                            this._makerCodeStr = makerUMnt.GoodsMakerCd.ToString();
                            // フォーカス設定
                            this.tNedit_GoodsMGroup.Focus();
                    }
                        break;
                    }
                //キャンセル
                case 1:
                    {
                        break;
                    }
            }
        }
        #endregion

        #region 中分類情報取得（ガイド）
        /// <summary>
        /// 中分類情報取得（ガイド）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_GoodsMGroup_Click(object sender, EventArgs e)
        {
            GoodsGroupU goodsGroupU;

            //中分類ガイド起動
            int status = this._goodsGroupUAcs.ExecuteGuid(this._enterpriseCode, out goodsGroupU, true);

            switch (status)
            {
                //取得
                case 0:
                    {
                        if (goodsGroupU != null)
                        {
                            //
                            this.tNedit_GoodsMGroup.SetInt(goodsGroupU.GoodsMGroup);
                            this.GoodsMGroupName_tEdit.Text = goodsGroupU.GoodsMGroupName;
                            this._goodsMGroupCodeStr = goodsGroupU.GoodsMGroup.ToString();
                            // フォーカス設定
                            this.tNedit_RateGrpCode.Focus();
                        }
                        break;
                    }
                //キャンセル
                case 1:
                    {
                        break;
                    }
            }
        }
        #endregion

        #region 掛率グループＧ(ガイド)
        /// <summary>
        /// 掛率グループＧ情報ガイド
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_RateGrpCode_Click(object sender, EventArgs e)
        {
            GoodsGroupU goodsGroupU;

            //中分類ガイド起動
            int status = this._goodsGroupUAcs.ExecuteGuid(this._enterpriseCode, out goodsGroupU, false);

            switch (status)
            {
                //取得
                case 0:
                    {
                        if (goodsGroupU != null)
                        {
                            //
                            this.tNedit_RateGrpCode.SetInt(goodsGroupU.GoodsMGroup);
                            this.GoodsRateGrpName_tEdit.Text = goodsGroupU.GoodsMGroupName;
                            this._rateGrpCodeStr = goodsGroupU.GoodsMGroup.ToString();
                            // フォーカス設定
                            this.tNedit_SupplierCd.Focus();
                        }
                        break;
                    }
                //キャンセル
                case 1:
                    {
                        break;
                    }
            }
        }
        #endregion

        #region 仕入先情報取得（ガイド）
        /// <summary>
        /// 仕入先情報取得（ガイド）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : 仕入先情報取得処理</br>
        /// <br>Programmer : 宋剛</br>
        /// <br>Date       : 2016/01/22</br>
        /// <br>UpdateNote : 宋剛 2016/02/17</br>
        /// <br>           : Redmine#48629の障害一覧No.19　仕入先フォーカスを移動すると支払先コード設定障害対応</br>
        /// </remarks>
        private void uButton_SupplierCd_Click(object sender, EventArgs e)
        {
            Supplier supplier = null;

            // 仕入先ガイド起動
            int status = this._supplierAcs.ExecuteGuid(out supplier, this._enterpriseCode, LoginInfoAcquisition.Employee.BelongSectionCode);
            switch (status)
            {
                // 取得
                case 0:
                    {
                        if (supplier != null)
                        {
                            // 仕入先ｺｰﾄﾞ
                            this.tNedit_SupplierCd.SetInt(supplier.SupplierCd);
                            // 仕入先名称
                            this.uLabel_SupplierCd.Text = supplier.SupplierSnm;
                            // UPD BY 宋剛 2016/02/18 FRO Redmine#48629の障害一覧No.19　仕入先フォーカスを移動すると支払先コード設定障害対応 ---->>>>>
                            // this._suppilerCodeStr = supplier.PayeeCode.ToString();
                            this._suppilerCodeStr = supplier.SupplierCd.ToString();
                            // UPD BY 宋剛 2016/02/18 FRO Redmine#48629の障害一覧No.19　仕入先フォーカスを移動すると支払先コード設定障害対応 ----<<<<<
                            // フォーカス設定
                            this.tDateEdit_priceCalDate.Focus();
                           
                        }
                        break;
                    }
            }
        }
        #endregion

        #region [売価率保存]
        /// <summary>
        /// 売価率Enter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tNedit_SalesRate_Enter(object sender, EventArgs e)
        {
            this._salesRateStr = this.tNedit_SalesRate.Text.Trim();
        }
        #endregion

        #region [販売単価保存]
        /// <summary>
        /// 販売単価Enter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tNedit_SalesPrice_Enter(object sender, EventArgs e)
        {
            this._salesPriceStr = this.tNedit_SalesPrice.Text.Trim();
        }
        #endregion

        #region 倉庫コードリスト
        /// <summary>
        /// チェックリストボックスフォーカスEnter時、選択
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <br>Note        : チェックリストボックスフォーカスEnter時、選択</br>
        /// <br>Programmer  : 宋剛</br>
        /// <br>Date        : 2016/01/22</br>
        private void CheckedListBox_Enter(object sender, EventArgs e)
        {
            if ((sender is ListBox) && (((ListBox)sender).Items.Count > 0))
            {
                // 選択状態
                ((ListBox)sender).SetSelected(0, true);
            }
        }
        /// <summary>
        /// チェックリストボックスフォーカスLeave時、選択解除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <br>Note        : チェックリストボックスフォーカスLeave時、選択解除</br>
        /// <br>Programmer  : 宋剛</br>
        /// <br>Date        : 2016/01/22</br>
        private void CheckedListBox_Leave(object sender, EventArgs e)
        {
            if (sender is ListBox)
            {
                ListBox listBox = (ListBox)sender;

                // 選択状態解除
                if (listBox.SelectedItem != null)
                {
                    listBox.SetSelected(listBox.SelectedIndex, false);
                }
            }
        }
        #endregion

        /// <summary>
        /// 実行状況ログ処理
        /// </summary>
        /// <param name="msg">ログメッセージ</param>
        /// <param name="msgRun">実行情報</param>
        /// <br>Note        : 実行状況ログ処理</br>
        /// <br>Programmer  : 宋剛</br>
        /// <br>Date        : 2016/01/22</br>
        private void ShowResult(string msg, string msgRun)
        {
            if (!string.IsNullOrEmpty(msg))
            {
                if (!string.IsNullOrEmpty(this.richTextBox1.Text))
                {
                    this.richTextBox1.Text += Environment.NewLine;
                }
                this.richTextBox1.Text += DateTime.Now.ToString("HH:mm") + " " + msg;
                this.richTextBox1.SelectionStart = this.richTextBox1.TextLength;
                this.richTextBox1.ScrollToCaret();
            }
            if (!string.IsNullOrEmpty(msgRun))
            {
                this.ultra_Run.Text = msgRun;
            }

            this.Refresh();
            this.Update();
            this.Invalidate();
            System.Windows.Forms.Application.DoEvents();
        }

        /// <summary>
        /// 出力ファイルの削除
        /// </summary>
        /// <remarks>
        /// <br>Note       : 出力ファイルの削除を行う。</br>
        /// <br>Programmer : 宋剛</br>
        /// <br>Date       : 2016/01/22</br>
        /// <br>UpdateNote : 宋剛 2016/02/15</br>
        /// <br>           : Redmine#48629の#59の　CSVファイルがオープンされている障害対応</br>
        /// </remarks>
        private int DeleteFile(out string errorMessage)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            errorMessage = string.Empty;
            // ③	出力予定となる下記ファイルを削除する。
            //・	${yyyyMMdd}_出品更新一覧.csv
            //・	${yyyyMMdd}_出品更新一覧_警告.csv
            //※フォルダ名は、[設定画面]-[チェックリスト出力先]から読み込む。
            //※${yyyyMMdd}…システム日付年月日

            try
            {
                // 出品更新一覧
                if (File.Exists(this._fileName))
                {
                    // ADD BY 宋剛 2016/02/15 FOR Redmine#48629の#59の　CSVファイルがオープンされている障害対応 ---->>>>>
                    status = IsFileLocked(this._fileName);
                    if ((int)FileLocked_Status.FileLocked_LOCKED == status)
                    {
                        errorMessage = ct_FILEALRDY_ERROR;
                        return status;
                    }
                    // ADD BY 宋剛 2016/02/15 FOR Redmine#48629の#59の　CSVファイルがオープンされている障害対応 ----<<<<<

                    // 移動データの出力ファイルを削除
                    File.Delete(this._fileName);
                }
                // 出品更新警告一覧
                if (File.Exists(this._fileWarningName))
                {
                    // ADD BY 宋剛 2016/02/15 FOR Redmine#48629の#59の　CSVファイルがオープンされている障害対応 ---->>>>>
                    status = IsFileLocked(this._fileWarningName);
                    if ((int)FileLocked_Status.FileLocked_LOCKED == status)
                    {
                        errorMessage = ct_FILEALRDY_ERROR;
                        return status;
                    }
                    // ADD BY 宋剛 2016/02/15 FOR Redmine#48629の#59の　CSVファイルがオープンされている障害対応 ----<<<<<

                    // 移動データの出力ファイルを削除
                    File.Delete(this._fileWarningName);
                }

                // ④	下記ファイルに一致するファイルを削除します。
                //ファイル名 ：	*_出品更新一覧.csv or *_出品更新一覧_警告.csv
                //ファイル名更新日付 ：	システム日付から60日以上前

                DirectoryInfo theFolder = new DirectoryInfo(_filePath);
                FileInfo[] allFile = theFolder.GetFiles();

                int month2Date = 0;
                int.TryParse(DateTime.Now.AddDays(-60).ToString("yyyyMMdd"), out month2Date);
                foreach (FileInfo fi in allFile)
                {
                    string tempFileFullName = fi.FullName;

                    if ((tempFileFullName.IndexOf(ARFILENAME) > -1) || (tempFileFullName.IndexOf(ERRFILENAME) > -1))
                    {
                        try
                        {
                            int tempDate = Convert.ToInt32(fi.Name.Substring(0, 8));
                            
                            if (tempDate <= month2Date)
                            {
                                // ADD BY 宋剛 2016/02/15 FOR Redmine#48629の#59の　CSVファイルがオープンされている障害対応 ---->>>>>
                                status = IsFileLocked(tempFileFullName);
                                if ((int)FileLocked_Status.FileLocked_LOCKED == status)
                                {
                                    errorMessage = ct_FILEALRDY_ERROR;
                                    return status;
                                }
                                // ADD BY 宋剛 2016/02/15 FOR Redmine#48629の#59の　CSVファイルがオープンされている障害対応 ----<<<<<
                                File.Delete(tempFileFullName);
                            }
                        }
                        catch
                        {
                            continue;
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                errorMessage = ex.ToString();
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }
        // ADD BY 宋剛 2016/02/15 FOR Redmine#48629の#59の　CSVファイルがオープンされている障害対応 ---->>>>>
        /// <summary>
        /// 指定したファイルは使用するかどうかをチェックしている
        /// </summary>
        /// <param name="fileNm">ファイル名</param>
        /// <remarks>
        /// <br>Note       : 指定ファイルは使用中しているかどうかをチェックしている</br>
        /// <br>Programmer : 宋剛</br>
        /// <br>Date	   : 2016/02/15</br>
        /// </remarks>
        private int IsFileLocked(string fileNm)
        {
            FileStream stream = null;

            // ﾌｧｲﾙが存在しない場合、ﾃｷｽﾄ出力時に作成している
            if (!File.Exists(fileNm))
                return (int)FileLocked_Status.FileLocked_NORMAL;

            try
            {
                stream = File.Open(fileNm, FileMode.Open, FileAccess.ReadWrite, FileShare.None);
            }
            catch (IOException)
            {
                return (int)FileLocked_Status.FileLocked_LOCKED;
            }
            catch (UnauthorizedAccessException)
            {
                FileInfo fi = new FileInfo(fileNm);
                if (fi.Attributes.ToString().IndexOf("ReadOnly") != -1)
                {
                    fi.Attributes = FileAttributes.Normal;
                }
                return (int)FileLocked_Status.FileLocked_NORMAL;
            }
            catch (Exception)
            {
                return (int)FileLocked_Status.FileLocked_EOF;
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }
            return (int)FileLocked_Status.FileLocked_NORMAL;
        }

        /// <summary>
        /// ファイルは使用フラグ
        /// </summary>
        private enum FileLocked_Status
        {
            //ファイルは使用できる
            FileLocked_NORMAL = 0,
            //ファイルが他で使用中です
            FileLocked_LOCKED = 1,
            //ファイルがアクセスできない。
            FileLocked_CANNOTACCESS = 2,
            //その他エラー
            FileLocked_EOF = 3,
        }

        // ADD BY 宋剛 2016/02/15 FOR Redmine#48629の#59の　CSVファイルがオープンされている障害対応 ----<<<<<


        /// <summary>
        /// timer実行処理
        /// </summary>
        /// <param name="obj">対象オブジェクト</param>
        /// <remarks>
        /// <br>Note        : timer実行処理</br>
        /// <br>Programmer  : 宋剛</br>
        /// <br>Date        : 2016/01/22</br>
        /// </remarks>
        private void TimerCall(object obj)
        {
            if (_restTime >= 1)
            {
                _restTime--;
            }
            else
            {
                this._restTimer.Change(Timeout.Infinite, 0);
                return;
            }

            // UIの残り時間を更新する
            UpdateUITime();

        }

        /// <summary>
        /// 残り予測時間更新処理
        /// </summary>
        /// <param name="ratio">処理割合</param>
        /// <remarks>
        /// <br>Note       : 残り予測時間更新処理を行う。</br>
        /// <br>Programmer : 宋剛</br>
        /// <br>Date       : 2016/01/22</br>
        /// </remarks>
        private void UpdateRestTime(double ratio)
        {
            int tempTime = this._restTime - (int)(this._forecastTime * (1 - ratio / 100));

            if (tempTime >= 5)
            {
                this._forecastTime = (int)(this._forecastTime * (1 - ratio / 100));
                this._restTime = this._forecastTime;

                // UIの残り時間を更新する
                UpdateUITime();
            }
        }

        /// <summary>
        ///  UIの残り時間の更新
        /// </summary>
        /// <br>Note        :  UIの残り時間を更新する</br>
        /// <br>Programmer  : 宋剛</br>
        /// <br>Date        : 2016/01/22</br>
        private void UpdateUITime()
        {
            string restTime = string.Empty;
            // 1分以下
            if (_restTime <= 60)
            {
                restTime = _restTime + "秒";
            }
            // 1時間以下
            else if (_restTime > 60 && _restTime <= 3600)
            {
                if (_restTime % 60 == 0)
                {
                    restTime = _restTime / 60 + "分";
                }
                else
                {
                    restTime = _restTime / 60 + "分" + _restTime % 60 + "秒";
                }
            }
            // 上記以外
            else
            {
                int restSec = _restTime % 3600;
                if (restSec % 60 == 0)
                {
                    restTime = _restTime / 3600 + "時" + restSec / 60 + "分";
                }
                else
                {
                    restTime = _restTime / 3600 + "時" + restSec / 60 + "分" + restSec % 60 + "秒";
                }
            }
            string restTimeStr = string.Format("（残り予測時間：{0}）", restTime);
            // 残り予測時間
            this.ultraLabel_time.Text = restTimeStr;
            this.ultraLabel_time.Refresh();
        }

        // ---------- ADD 2016/02/24 Y.Wakita ① ---------->>>>>
        /// <summary>
        /// 部品MAX管理画面情報取得処理
        /// </summary>
        /// <br>Note        : 部品MAX管理画面で設定した情報を取得する</br>
        /// <br>Programmer  : 脇田 靖之</br>
        /// <br>Date        : 2016/02/24</br>
        /// <returns>
        /// </returns>
        private int ReadUserSetting()
        {
            while (true)
            {
                // ユーザー情報
                string userID;
                string userPassWord;
                bool userExistFlag = false;
                // DATファイルから、ユーザー情報を取得する
                _pMMAX02000UC.ReadDatFile(PMMAX02000UC.ct_Tbl_Users, this._enterpriseCode, this._loginSectionCode, out userID, out userPassWord, out userExistFlag);
                // 該当するユーザーを設定した場合
                if (string.IsNullOrEmpty(userID) || string.IsNullOrEmpty(userPassWord))
                {
                    // 入力値が存在しない場合
                    this._pmmax02000UE.DisplayMessage = "部品MAX管理画面にログインするための下記情報を入力してください。\r\n出品情報、及び入荷予約情報の登録に必要になります。\r\n※入力情報は記憶されるため、次回より入力不要です。\r\n　本情報は設定画面にて変更する事ができます。";
                    this._pmmax02000UE.InitialScreenData();
                    DialogResult dr = _pmmax02000UE.ShowDialog();

                    if (dr == DialogResult.Yes)
                    {
                        // 部品MAXログインID
                        this._loginId = this._pmmax02000UE.UserID;
                        // 部品MAXパスワード
                        this._password = this._pmmax02000UE.UserPassWord;
                        break;
                    }
                    else
                    {
                        this.ShowResult(PMMAX02010UE.M_016, ct_RUN_MESSAGE02);
                        this.ultraLabel_time.Text = string.Empty;
                        this.ultraLabel_time.Refresh();
                        return (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    }
                }
                // 入力しました場合
                else
                {
                    // 部品MAXログインID
                    this._loginId = userID;
                    // 部品MAXパスワード
                    this._password = userPassWord;

                    break;
                }
            }
            return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        }
        // ---------- ADD 2016/02/24 Y.Wakita ① ----------<<<<<
        #endregion
    }
}
