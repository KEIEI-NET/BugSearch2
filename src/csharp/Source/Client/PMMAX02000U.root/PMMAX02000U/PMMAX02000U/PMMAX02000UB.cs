//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 出品・入荷予約
// プログラム概要   : 出品・入荷予約
//----------------------------------------------------------------------------//
//                (c)Copyright  2016 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号 : 11270001-00  作成担当 : 陳艶丹
// 作 成 日 : 2016/01/21   修正内容 : 新規作成
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
// 作 成 日 : 2016/02/15   修正内容 : Redmine#48629の#70の　販売単価などのカンマは必要ないので削除する
//----------------------------------------------------------------------------//
// 管理番号 : 11270001-00  作成担当 : 宋剛
// 作 成 日 : 2016/02/16   修正内容 : Redmine#48629の障害一覧No.13　出荷数の小数点以下が切り捨てされない仕様変更対応
//----------------------------------------------------------------------------//
// 管理番号 : 11270001-00  作成担当 : 宋剛
// 作 成 日 : 2016/02/16   修正内容 : Redmine#48629の障害一覧No.14　初期ウィンドウサイズだと実行状況ログの下部が途切れる障害対応
//                                    PMMAX02000UB.Designer.csクラスのみを修正する
//----------------------------------------------------------------------------//
// 管理番号 : 11270001-00  作成担当 : 宋剛
// 作 成 日 : 2016/02/16   修正内容 : Redmine#48629の障害一覧No.15　実行状況ログの文字列が画面右端で折り返しされない障害対応
//                                    PMMAX02000UB.Designer.csクラスのみを修正する
//----------------------------------------------------------------------------//
// 管理番号 : 11270001-00  作成担当 : 宋剛
// 作 成 日 : 2016/02/16   修正内容 : Redmine#48629の障害一覧No.16　チェックリスト出力先に書き込み不可障害対応
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
// 作 成 日 : 2016/02/22   修正内容 : LDNS発生した障害　アップロードメッセージ不正の障害対応
//----------------------------------------------------------------------------//
// 管理番号 : 11270001-00  作成担当 : 宋剛
// 作 成 日 : 2016/02/23   修正内容 : LDNS発生した障害　取込むファイルのサイズは0の場合、実行状況のメッセージを出力しない
//----------------------------------------------------------------------------//
// 管理番号 : 11270001-00  作成担当 : 脇田 靖之
// 作 成 日 : 2016/02/24   修正内容 : ①全体配信障害一覧№245　起動後にエラー再取込を行うとエラー発生する障害対応
//                                    ②全体配信障害一覧№248　実行状況ログに出力済みのエラーが再出力される障害対応
//                                    ③全体配信障害一覧№231  部品MAX登録中に画面を終了できてしまう障害対応
//                                    ④全体配信障害一覧№224　csvのヘッダの文言の誤りを修正対応
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
    /// 出品・入荷予約フォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 出品・入荷予約を行います。</br>
    /// <br>Programmer : 陳艶丹</br>
    /// <br>Date       : 2016/01/21</br>
    /// <br>UpdateNote : 宋剛 2016/02/15</br>
    /// <br>           : Redmine#48629の#59の　CSVファイルがオープンされている障害対応</br>
    /// <br>UpdateNote : 宋剛 2016/02/15</br>
    /// <br>           : Redmine#48629の#64の　売価率と単価の整数出力対応</br>
    /// <br>UpdateNote : 宋剛 2016/02/15</br>
    /// <br>           : Redmine#48629の障害一覧No.2の　販売単価と売価率の「未満」仕様変更対応</br>
    /// <br>UpdateNote : 宋剛 2016/02/15</br>
    /// <br>           : Redmine#48629の#70の　販売単価などのカンマは必要ないので削除する</br>
    /// <br>UpdateNote : 宋剛 2016/02/16</br>
    /// <br>           : Redmine#48629の障害一覧No.13　出荷数の小数点以下が切り捨てされない仕様変更対応</br>
    /// <br>UpdateNote : 宋剛 2016/02/16</br>
    /// <br>           : Redmine#48629の障害一覧No.16　チェックリスト出力先に書き込み不可障害対応</br>
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
    /// <br>UpdateNote : 宋剛 2016/02/19</br>
    /// <br>           : LDNS発生した障害　アップロードメッセージ不正の障害対応</br>
    /// <br>UpdateNote : 宋剛 2016/02/23</br>
    /// <br>           : LDNS発生した障害　取込むファイルのサイズは0の場合、実行状況のメッセージを出力しない</br>
    /// </remarks>
    public partial class PMMAX02000UB : Form
    {
        # region Private Constant

        private const string ct_INPUT_ERROR = "正しい出荷日付を指定してください。";
        private const string ct_RUN_MESSAGE01 = "実行中";
        private const string ct_RUN_MESSAGE02 = "中止";
        // UPD BY 宋剛 2016/02/19 FOR Redmine#48629の障害一覧No.235　実行状況："成功"⇒"完了"にする。---->>>>>
        // private const string ct_RUN_MESSAGE03 = "成功";
        private const string ct_RUN_MESSAGE03 = "完了";
        // UPD BY 宋剛 2016/02/19 FOR Redmine#48629の障害一覧No.235　実行状況："成功"⇒"完了"にする。----<<<<<
        private const string ct_RUN_MESSAGE04 = "エラー";
        private const string ct_FILEALRDY_ERROR = "ファイルが使用中か、開いている為処理を実行できません。"; //ADD BY 宋剛 2016/02/15 FOR Redmine#48629の#59の　CSVファイルがオープンされている障害対応

        // クラス名
        private const string ct_PRINTNAME = "出品・入荷予約";
        private const string ct_PGID = "PMMAX02000UB";

        private const string SPACE = " ";

        private const int DATA_MOVE_MAX = 100000;
        private const int DATA_SIZE = 100;

        private const string ARFILENAME = "_入荷予約一覧.csv";
        private const string ERRFILENAME = "_入荷予約一覧_警告.csv";
        private const string ct_RESTTIME = "計算中…";
        private const string ct_CSVFILTER = "CSVファイル(*.csv)|*.csv";

        # endregion

        // ===================================================================================== //
        // プライベート変数
        // ===================================================================================== //
        # region Private Members

        private ImageList _imageList16 = null;

        private string _enterpriseCode;                    // 企業コード
        private string _loginSectionCode;                  // ログイン拠点コード
        private DateGetAcs _dateGetAcs;                    // 日付取得部品
        private SecInfoSetAcs _secInfoSetAcs;              // 拠点情報設定アクセスクラス
        private DataSet _exportDataSet;                    // 出力結果DataSet
        private PMMAX02000UE _pmmax02000UE;               // 部品MAX認証入力画面
        private PartsMaxStockArrivalCondt _searchCond;   // 出力条件
        private BuhinMaxStockArrivalProvider _buhinMaxStockArrivalProvider;
        // 倉庫マスタ
        private WarehouseAcs warehouseAcs;
        private CustomerInfoAcs _customerInfoAcs;

        private CustomerSearchAcs _customerSearchAcs;

        private MoveDataExportAcs _moveDataExportAcs;
        private PMMAX02000UC _pMMAX02000UC;    // 初期表示用クラス
        private Control _prevControl = null;
        // ログイン拠点コード
        private string _sectionCode;
        private string _filePath;
        private string _fileName;
        private string _fileWarningName;
        private int _restTime = 0; // 画面に残り予測時間
        private int _forecastTime = 0; // 規定予測処理時間
        private int _shipDateRange = 0; // 出荷日付初期値
        private DateTime _deletTime = DateTime.MinValue;
        private string _deletName;
        private string _loginId;
        private string _password;
        OutAndInPutUserSaveItems _saveItemsTemp = new OutAndInPutUserSaveItems();
        // 抽出条件前回入力値(更新有無チェック用)
        private string _preCustomerName;
        private PartsMaxStockArrivalCondt _preStockArrivalCondt;
        // 得意先情報
        private Dictionary<int, CustomerSearchRet> _customerSearchRetDic;
        // 売価率
        private string _salesRateStr = string.Empty;
        // 販売単価
        private string _salesPriceStr = string.Empty;
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
        /// 出品・入荷予約フォームクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 出品・入荷予約フォームクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2016/01/21</br>
        /// </remarks>
        public PMMAX02000UB()
        {
            InitializeComponent();

            // 変数初期化
            this._imageList16 = IconResourceManagement.ImageList16;
            // 初期化各種マスタ検索用アクセス
            this.warehouseAcs = new WarehouseAcs();　// 倉庫アクセス
            this._deletTime = DateTime.Today;
            _pMMAX02000UC = new PMMAX02000UC();
        }

        /// <summary>
        /// コンストラクタ　Nunit用
        /// </summary>
        /// <param name="param">パラメータ</param>
        /// <remarks>
        /// <br>Note       : 出品・入荷予約フォームクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2016/01/21</br>
        /// </remarks>
        public PMMAX02000UB(string param)
        {
            if (("NUnit").Equals(param))
            {
                // 初期化
                InitializeComponent();
            }
            else
            {
                throw new Exception();
            }
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
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2016/01/21</br>
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
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2016/01/21</br>
        /// </remarks>
        private void InitialScreenData()
        {
            this._password = string.Empty;
            this._loginId = string.Empty;
        }

        /// <summary>
        /// ガイドボタンのアイコン設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : ガイドボタンのアイコンを設定します。</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2016/01/21</br>
        /// </remarks>
        private void SetGuidButtonIcon()
        {
            this.uButton_CustomerGuide.Appearance.Image = this._imageList16.Images[(int)Size16_Index.STAR1];     // 部品MAX得意先ガイド
            this.AfSectionGuide_ultraButton.Appearance.Image = this._imageList16.Images[(int)Size16_Index.STAR1];　// 入庫拠点ガイド
            this.BfSectionGuide_uButton.Appearance.Image = this._imageList16.Images[(int)Size16_Index.STAR1];     // 出庫拠点ガイド
        }
        　
        /// <summary>
        /// 日付範囲チェック呼び出し
        /// </summary>
        /// <param name="cdrResult">チェック結果</param>
        /// <param name="startDate">開始日</param>
        /// <param name="endDate">終了日</param>
        /// <returns>チェック結果</returns>
        /// <remarks>
        /// <br>Note       : 日付範囲チェック呼び出し</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2016/01/21</br>
        /// </remarks>
        private bool CallCheckDateRange(out DateGetAcs.CheckDateRangeResult cdrResult, ref TDateEdit startDate, ref TDateEdit endDate)
        {
            // 日付範囲チェック(入力日)
            cdrResult = _dateGetAcs.CheckDateRange(DateGetAcs.YmdType.YearMonth, 0, ref startDate, ref endDate, false);
            return (cdrResult == DateGetAcs.CheckDateRangeResult.OK);
        }

        /// <summary>
        /// 初期化倉庫情報
        /// </summary>
        /// <remarks>
        /// <br>Note       : 初期化倉庫情報取得する</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2016/01/21</br>
        /// </remarks>
        private void InitWareHouseInfo()
        {
            this.checkedListBox_AfWarehouse.Items.Clear();
            this.checkedListBox_BfWarehouse.Items.Clear();
            ArrayList retList = new ArrayList();
            warehouseAcs.Search(out retList, this._enterpriseCode);
            if (retList.Count == 0)
            {
                return;
            }
            foreach (Warehouse warehouse in retList)
            {
                String key = warehouse.WarehouseCode.Trim() + SPACE + warehouse.WarehouseName.Trim();
                this.checkedListBox_AfWarehouse.Items.Add(key);
                this.checkedListBox_BfWarehouse.Items.Add(key);
            }
        }

        /// <summary>
        /// データセット列情報構築処理
        /// </summary>
        /// <param name="dataTable">DataTable</param>
        /// <remarks>
        /// <br>Note        : データセット列情報構築処理を行う。</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2016/01/21</br>
        /// </remarks>
        private void DataSetColumnConstruction(DataTable dataTable)
        {
            #region 移動データ

            // 企業コード
            DataColumn columnEnterpriseCode = new DataColumn(ExportMoveDataItems.ct_Col_EnterpriseCode, typeof(string));
            columnEnterpriseCode.Caption = "企業コード";
            dataTable.Columns.Add(columnEnterpriseCode);

            // 拠点コード
            DataColumn columnSectionCode = new DataColumn(ExportMoveDataItems.ct_Col_SectionCode, typeof(string));
            columnSectionCode.Caption = "拠点コード";
            dataTable.Columns.Add(columnSectionCode);

            // 出荷日
            DataColumn columnStockMoveDate = new DataColumn(ExportMoveDataItems.ct_Col_StockMoveDate, typeof(string));
            columnStockMoveDate.Caption = "出荷日";
            dataTable.Columns.Add(columnStockMoveDate);

            // 伝票番号
            DataColumn columnStockMoveSlipNo = new DataColumn(ExportMoveDataItems.ct_Col_StockMoveSlipNo, typeof(string));
            columnStockMoveSlipNo.Caption = "伝票番号";
            dataTable.Columns.Add(columnStockMoveSlipNo);

            // 伝票行番号
            DataColumn columnStockMoveRowNo = new DataColumn(ExportMoveDataItems.ct_Col_StockMoveRowNo, typeof(string));
            columnStockMoveRowNo.Caption = "伝票行番号";
            dataTable.Columns.Add(columnStockMoveRowNo);

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

            // 出荷数
            DataColumn columnShipmentCount = new DataColumn(ExportMoveDataItems.ct_Col_ShipmentCount, typeof(string));
            columnShipmentCount.Caption = "出荷数";
            dataTable.Columns.Add(columnShipmentCount);

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

            // 出庫拠点コード
            DataColumn columnBfSectionCode = new DataColumn(ExportMoveDataItems.ct_Col_BfSectionCode, typeof(string));
            columnBfSectionCode.Caption = "出庫拠点コード";
            dataTable.Columns.Add(columnBfSectionCode);

            // 出庫拠点名
            DataColumn columnBfSectionGuideSnm = new DataColumn(ExportMoveDataItems.ct_Col_BfSectionGuideSnm, typeof(string));
            columnBfSectionGuideSnm.Caption = "出庫拠点名";
            dataTable.Columns.Add(columnBfSectionGuideSnm);

            // 出庫倉庫
            DataColumn columnBfEnterWarehCode = new DataColumn(ExportMoveDataItems.ct_Col_BfEnterWarehCode, typeof(string));
            // ---------- UPD 2016/02/24 Y.Wakita ④ ---------->>>>>
            //columnBfEnterWarehCode.Caption = "出庫倉庫";
            columnBfEnterWarehCode.Caption = "出庫倉庫コード";
            // ---------- UPD 2016/02/24 Y.Wakita ④ ----------<<<<<
            dataTable.Columns.Add(columnBfEnterWarehCode);

            // 出庫倉庫名
            DataColumn columnBfEnterWarehName = new DataColumn(ExportMoveDataItems.ct_Col_BfEnterWarehName, typeof(string));
            columnBfEnterWarehName.Caption = "出庫倉庫名";
            dataTable.Columns.Add(columnBfEnterWarehName);

            // 入庫拠点コード
            DataColumn columnAfSectionCod = new DataColumn(ExportMoveDataItems.ct_Col_AfSectionCod, typeof(string));
            columnAfSectionCod.Caption = "入庫拠点コード";
            dataTable.Columns.Add(columnAfSectionCod);

            // 入庫拠点名
            DataColumn columnAfSectionGuideSnm = new DataColumn(ExportMoveDataItems.ct_Col_AfSectionGuideSnm, typeof(string));
            columnAfSectionGuideSnm.Caption = "入庫拠点名";
            dataTable.Columns.Add(columnAfSectionGuideSnm);

            // 入庫倉庫
            DataColumn columnAfEnterWarehCode = new DataColumn(ExportMoveDataItems.ct_Col_AfEnterWarehCode, typeof(string));
            // ---------- UPD 2016/02/24 Y.Wakita ④ ---------->>>>>
            //columnAfEnterWarehCode.Caption = "入庫倉庫";
            columnAfEnterWarehCode.Caption = "入庫倉庫コード";
            // ---------- UPD 2016/02/24 Y.Wakita ④ ----------<<<<<
            dataTable.Columns.Add(columnAfEnterWarehCode);

            // 入庫倉庫名
            DataColumn columnAfEnterWarehName = new DataColumn(ExportMoveDataItems.ct_Col_AfEnterWarehName, typeof(string));
            columnAfEnterWarehName.Caption = "入庫倉庫名";
            dataTable.Columns.Add(columnAfEnterWarehName);

            // 入荷予約日
            DataColumn columnStockArrivalDate = new DataColumn(ExportMoveDataItems.ct_Col_StockArrivalDate, typeof(string));
            columnStockArrivalDate.Caption = "入荷予約日";
            dataTable.Columns.Add(columnStockArrivalDate);

            // 警告理由
            DataColumn columnAlertReason = new DataColumn(ExportMoveDataItems.ct_Col_AlertReason, typeof(string));
            columnAlertReason.Caption = "警告理由";
            dataTable.Columns.Add(columnAlertReason);

            this._exportDataSet.Tables.Add(dataTable);
            #endregion
        }
        #endregion

        // ===================================================================================== //
        // 各コントロールイベント処理
        // ===================================================================================== //
        # region Control Event Methods
        /// <summary>
        /// Form.Load イベント(PMMAX02000UB)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : ユーザーがフォームを読み込むときに発生します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2016/01/21</br>
        /// </remarks>
        private void PMMAX02000UB_Load(object sender, EventArgs e)
        {
            this._pMMAX02000UC = new PMMAX02000UC();                       // 初期表示用クラス
            this._enterpriseCode = _pMMAX02000UC.EnterpriseCode;          // 企業コード
            this._loginSectionCode = _pMMAX02000UC.LoginSectionCode;      // ログイン拠点コード
            this._pmmax02000UE = new PMMAX02000UE();                   // 部品MAX認証入力画面
            this._secInfoSetAcs = new SecInfoSetAcs();                  // 拠点情報設定アクセスクラス
            this._dateGetAcs = DateGetAcs.GetInstance();                // 日付取得部品
            this._exportDataSet = new DataSet();                        // 出力結果DataSet
            this._searchCond = new PartsMaxStockArrivalCondt();        // 出力条件
            this._customerInfoAcs = new CustomerInfoAcs();
            this._moveDataExportAcs = new MoveDataExportAcs();        // 検索部品アクセス
            this._customerSearchAcs = new CustomerSearchAcs();
            this._preStockArrivalCondt = new PartsMaxStockArrivalCondt();
            this._sectionCode = LoginInfoAcquisition.Employee.BelongSectionCode.Trim().PadLeft(2, '0'); // 自拠点コード

            this._buhinMaxStockArrivalProvider = new BuhinMaxStockArrivalProvider(); // 部品MAX連携部品

            // 画面初期化
            InitialScreenSetting();
            this._deletName = this._fileName;

            DataTable arrivalDataTable = new DataTable(ExportMoveDataItems.ct_Tbl_Arrival);

            DataTable arrivalWarningDataTable = new DataTable(ExportMoveDataItems.ct_Tbl_ArrivalWarning);
            // データセット列情報構築処理
            this.DataSetColumnConstruction(arrivalDataTable);
            this.DataSetColumnConstruction(arrivalWarningDataTable);

        }

        /// <summary>
        /// PMMAX02000UB_Shown Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : PMMAX02000UB_Shown Event</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2016/01/21</br>
        /// </remarks>
        private void PMMAX02000UB_Shown(object sender, EventArgs e)
        {
            // 初期フォーカス設定
            this.tNedit_CustomerCode.Focus();
            // 初期化倉庫情報
            InitWareHouseInfo();
            this._filePath = Path.Combine(ConstantManagement_ClientDirectory.NSCurrentDirectory, Path.Combine(ConstantManagement_ClientDirectory.PRTOUT, @"CSV\"));
            // XMLファイルから画面をセットする
            this.XMLFileToScreen();
            this._preStockArrivalCondt.CustomerCode = this.tNedit_CustomerCode.GetInt();
            
            // 入荷予約一覧
            this._fileName = Path.Combine(this._filePath, DateTime.Now.ToString("yyyyMMdd") + ARFILENAME);
            // 入荷予約警告一覧
            this._fileWarningName = Path.Combine(this._filePath, DateTime.Now.ToString("yyyyMMdd") + ERRFILENAME);
        }
        #endregion

        // ===================================================================================== //
        // 入荷予約処理
        // ===================================================================================== //
        #region 入荷予約処理
        /// <summary>
        /// 入荷予約処理
        /// </summary>
        /// <param name="shipDateRange">出荷日付初期値</param>
        /// <param name="outPutPath">出力先</param>
        /// <param name="useId">部品MAXログインID</param>
        /// <param name="userPassWord">部品MAXパスワード</param>
        /// <remarks>
        /// <br>Note       : 入荷予約出力処理を行う。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2016/01/21</br>
        /// <br>UpdateNote : 宋剛 2016/02/15</br>
        /// <br>           : Redmine#48629の#59の　CSVファイルがオープンされている障害対応</br>
        /// <br>UpdateNote : 宋剛 2016/02/16</br>
        /// <br>           : Redmine#48629の障害一覧No.16　チェックリスト出力先に書き込み不可障害対応</br>
        /// </remarks>
        public int DataExport(int shipDateRange, string outPutPath, string useId, string userPassWord)
        {
            #region 実行準備処理
            string errMessage = string.Empty;
            // 出荷日付初期値
            this._shipDateRange = shipDateRange;
            // チェックリスト出力先
            if (!string.IsNullOrEmpty(outPutPath))
            {
                 this._filePath = outPutPath;
                 // 入荷予約一覧
                 this._fileName = Path.Combine(this._filePath, DateTime.Now.ToString("yyyyMMdd") + ARFILENAME);
                 // 入荷予約警告一覧
                 this._fileWarningName = Path.Combine(this._filePath, DateTime.Now.ToString("yyyyMMdd") + ERRFILENAME);
            }
            // 部品MAXログインID
            this._loginId = useId;
            // 部品MAXパスワード
            this._password = userPassWord;

            // DEL BY 宋剛 2016/02/16 FOR Redmine#48629の障害一覧No.16　チェックリスト出力先に書き込み不可障害対応 ---->>>>>
            //// 指定されたフォルダが存在チェック
            //if (!Directory.Exists(this._filePath))
            //{
            //    Directory.CreateDirectory(this._filePath);
            //}
            // DEL BY 宋剛 2016/02/16 FOR Redmine#48629の障害一覧No.16　チェックリスト出力先に書き込み不可障害対応 ----<<<<<

            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            // 実行準備
            this.ultraLabel_time.Left = 206;
            this.ShowResult(MessageInfo.M_012, ct_RUN_MESSAGE01);
            this.ultraLabel_time.Text = ct_RESTTIME;

            // ADD BY 宋剛 2016/02/16 FOR Redmine#48629の障害一覧No.16　チェックリスト出力先に書き込み不可障害対応 ---->>>>>
            // 指定されたフォルダが存在チェック
            Boolean errorFlag = false;
            try
            {
                if (!Directory.Exists(this._filePath))
                {
                    Directory.CreateDirectory(this._filePath);
                }

                if (!PMMAX02000UD.CheckDirectoryAccess(this._filePath))
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
                this.ShowResult(MessageInfo.M_007, ct_RUN_MESSAGE04);
                this.ultraLabel_time.Text = string.Empty;
                this.ultraLabel_time.Refresh();
                return status;
            }
            // ADD BY 宋剛 2016/02/16 FOR Redmine#48629の障害一覧No.16　チェックリスト出力先に書き込み不可障害対応 ----<<<<<

            // ファイルの削除
            status = DeleteFile(out errMessage);
            // 例外発生時
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // ADD BY 宋剛 2016/02/15 FOR Redmine#48629の#59の　CSVファイルがオープンされている障害対応 ---->>>>>
                if (!string.IsNullOrEmpty(errMessage))
                {
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                        this.Name,
                        errMessage,
                        -1,
                        MessageBoxButtons.OK);
                }
                // ADD BY 宋剛 2016/02/15 FOR Redmine#48629の#59の　CSVファイルがオープンされている障害対応 ----<<<<<

                this.ShowResult(string.Format(MessageInfo.M_033, status, errMessage), ct_RUN_MESSAGE04);
                this.ultraLabel_time.Text = string.Empty;
                return status;

            }
            // テーブルのクリア
            this._exportDataSet.Tables[ExportMoveDataItems.ct_Tbl_Arrival].Clear();
            this._exportDataSet.Tables[ExportMoveDataItems.ct_Tbl_ArrivalWarning].Clear();
            #endregion

            #region 入力値検査
            if (tNedit_CustomerCode.Focused)
            {
                _prevControl = this.tNedit_CustomerCode;
            }
            // 入力値検査
            if (this._prevControl != null)
            {
                ChangeFocusEventArgs e = new ChangeFocusEventArgs(false, false, false, Keys.Return, this._prevControl, this._prevControl);
                this.tRetKeyControl1_ChangeFocus(this, e);
                if (isErrorMsgboxShow)
                {
                    isErrorMsgboxShow = false;
                    this.ShowResult(MessageInfo.M_015, ct_RUN_MESSAGE04);
                    this.ultraLabel_time.Text = string.Empty;
                    this._prevControl.Focus();
                    return status;
                }
            }

            string message = string.Empty;
            Control errControl = null;
            string msg = string.Empty;
            bool canExport = this.BeforeSearchCheck(out message, out errControl);

            // 入力値異常検知した場合
            if (!canExport)
            {
                this.ShowResult(MessageInfo.M_015, ct_RUN_MESSAGE04);
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, ct_PGID, ct_PRINTNAME, "", "", message, -1, null, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                errControl.Focus();
                this.ultraLabel_time.Text = string.Empty;
                return status;
            }

            // 部品MAXログインID、部品MAXパスワードが入力されているかを確認する
            // ---------- DEL 2016/02/24 Y.Wakita ① ---------->>>>>
            #region 削除
            //// ユーザー情報
            //string userID;
            //string userPassWd;
            //bool userExistFlag = false;
            //if (string.IsNullOrEmpty(this._loginId) || string.IsNullOrEmpty(this._password))
            //{
            //    // DATファイルから、ユーザー情報を取得する
            //    _pMMAX02000UC.ReadDatFile(PMMAX02000UC.ct_Tbl_Users, this._enterpriseCode, this._loginSectionCode, out userID, out userPassWd, out userExistFlag);
            //    // 該当するユーザーを設定した場合
            //    if (string.IsNullOrEmpty(userID) || string.IsNullOrEmpty(userPassWd))
            //    {
            //        // 部品MAX認証入力画面
            //        this._pmmax02000UE.DisplayMessage = MessageInfo.M_044;
            //        this._pmmax02000UE.InitialScreenData();
            //        DialogResult ret = this._pmmax02000UE.ShowDialog();
            //        // 保存ボタン押下時
            //        if (ret == DialogResult.Yes)
            //        {
            //            // 部品MAXログインID
            //            this._loginId = this._pmmax02000UE.UserID;
            //            // 部品MAXパスワード
            //            this._password = this._pmmax02000UE.UserPassWord;
            //        }
            //        else
            //        {
            //            // 中止ボタン押下時
            //            this.ShowResult(MessageInfo.M_016, ct_RUN_MESSAGE02);
            //            this.ultraLabel_time.Text = string.Empty;
            //            status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            //            return status;
            //        }
            //    }
            //    else
            //    {
            //        // 部品MAXログインID
            //        this._loginId = userID;
            //        // 部品MAXパスワード
            //        this._password = userPassWd;
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

            // 実行状況ログ表示
            this.ShowResult(MessageInfo.M_014, ct_RUN_MESSAGE01);
            #endregion

            #region 在庫移動データ抽出処理・テキスト出力
            // 画面→抽出条件クラス
            status = this.SetExtraInfoFromScreen();
            if (status != 0)
            {
                return status;
            }
            // ★重要★初期化検索部品アクセス
            // 売価計算用データを取得する。
            _moveDataExportAcs.InitCustomerInfo(_searchCond);            // 得意先の情報初期化(売価計算用情報初期化取得)

            #region 対象データ件数取得
            // 対象データ件数取得
            int moveCount = 0;
            status = this._moveDataExportAcs.SearchCount(out moveCount, this._searchCond, out message);
            // 例外発生時
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL && moveCount != 0)
            {
                msg = string.Format(MessageInfo.M_017, status, message);
                this.ShowResult(msg, ct_RUN_MESSAGE04);
                this.ultraLabel_time.Text = string.Empty;
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                return status;

            }

            // 取得件数 > 10万件、処理を終了する
            if (moveCount > DATA_MOVE_MAX)
            {
                this.ShowResult(MessageInfo.M_040, ct_RUN_MESSAGE04);
                this.ultraLabel_time.Text = string.Empty;
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                return status;
            }
            #endregion

            #region 対象データゼロ件の場合、空のCSVを出力
            // 在庫移動データを読み込む
            ArrayList retMoveDataList = null;
            // テキスト出力
            FormattedTextWriter export = new FormattedTextWriter();
            if (moveCount == 0)
            {
                // 入荷予約一覧CSV出力
                status = DoOutPut(ref export, this._exportDataSet.Tables[ExportMoveDataItems.ct_Tbl_Arrival].DefaultView, this._fileName, 0, 1, out message);
                // 例外発生時
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    msg = string.Format(MessageInfo.M_023, status, message);
                    this.ShowResult(msg, ct_RUN_MESSAGE04);
                    this.ultraLabel_time.Text = string.Empty;
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    return status;
                }
                // 入荷予約警告一覧CSV出力
                status = DoOutPut(ref export, this._exportDataSet.Tables[ExportMoveDataItems.ct_Tbl_ArrivalWarning].DefaultView, this._fileWarningName, 1, 1, out message);
                // 例外発生時
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    msg = string.Format(MessageInfo.M_023, status, message);
                    this.ultraLabel_time.Text = string.Empty;
                    this.ShowResult(msg, ct_RUN_MESSAGE04);
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    return status;
                }
            }
            #endregion

            #region 残り予測時間取得
            // 残り予測時間の表示
            string runVelocityConfig = ConfigurationManager.AppSettings["RunVelocity"];
            double runVelocity = 0;
            double.TryParse(runVelocityConfig, out runVelocity);

            if (runVelocity != 0)
            {
                this._restTime = (int)(runVelocity * moveCount); // UIの残り予測時間
                this._forecastTime = this._restTime; // 規定予測処理時間
                // UIの残り時間を更新する
                UpdateUITime();
            }
            // Timerを作成
            this._restTimer = new System.Threading.Timer(new TimerCallback(TimerCall), null, 0, 1000);
            #endregion

            #region 100件単位で在庫移動データ分割取得
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
            // 入荷予約警告一覧ない場合はタイトル出力しない
            int i = 0;
            bool titleFlgW = false;
            // 入荷予約一覧ない場合はタイトル出力しない
            int j = 0;
            bool titleFlg = false;
            // 100件単位で分割取得
            for (int loopIndex = 0; loopIndex < loopCount; loopIndex++)
            {
                // 在庫移動データを読み込む
                status = this._moveDataExportAcs.SearchDayDataExportMain(out retMoveDataList, this._searchCond, out message, loopIndex);
                // 関連項目取得例外発生時
                if (status == -1)
                {
                    this.ShowResult(message, ct_RUN_MESSAGE04);
                    // Timerを閉じる
                    this._restTimer.Change(Timeout.Infinite, 0);
                    this.ultraLabel_time.Text = string.Empty;
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    return status;
                }
                // 検索例外発生時
                else if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                   msg = string.Format(MessageInfo.M_017, status, message);
                   this.ShowResult(msg, ct_RUN_MESSAGE04);
                   // Timerを閉じる
                   this._restTimer.Change(Timeout.Infinite, 0);
                   this.ultraLabel_time.Text = string.Empty;
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
                    // 在庫移動データ
                    if (retMoveDataList != null && retMoveDataList.Count > 0)
                    {
                        msg = string.Format(MessageInfo.M_021, retMoveDataList.Count);
                        this.ShowResult(msg, ct_RUN_MESSAGE01);
                        // 入荷予約一覧
                        // DataSetへ格納
                        GetMoveDataTable(retMoveDataList, 0);
                        // 入荷予約警告一覧
                        GetMoveDataTable(retMoveDataList, 1);

                        // 初回出力時、警告ない場合はタイトル出力しない
                        if (loopIndex == 0 && this._exportDataSet.Tables[ExportMoveDataItems.ct_Tbl_Arrival].Rows.Count == 0)
                        {
                            j = loopIndex + 1;
                            titleFlg = false;
                        }
                        // 初回出力時、警告ある場合はタイトル出力する
                        if (loopIndex == 0 && this._exportDataSet.Tables[ExportMoveDataItems.ct_Tbl_Arrival].Rows.Count > 0)
                        {
                            j = 0;
                            titleFlg = true;
                        }
                        // 次回以降、警告ある場合はタイトル出力する
                        if (!titleFlg && loopIndex > 0 && this._exportDataSet.Tables[ExportMoveDataItems.ct_Tbl_Arrival].Rows.Count > 0)
                        {
                            j = 0;
                            titleFlg = true;
                        }
                        // 入荷予約一覧CSV出力
                        status = DoOutPut(ref export, this._exportDataSet.Tables[ExportMoveDataItems.ct_Tbl_Arrival].DefaultView, this._fileName, 0, j, out message);
                        // 次回以降、タイトルある場合は再出力しない
                        if (titleFlg)
                        {
                            j = loopIndex + 1;
                        }
                        // 例外発生時
                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            msg =string.Format(MessageInfo.M_023, status, message);
                            this.ShowResult(msg, ct_RUN_MESSAGE04);
                            // Timerを閉じる
                            this._restTimer.Change(Timeout.Infinite, 0);
                            this.ultraLabel_time.Text = string.Empty;
                            status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                            return status;
                        }
                        // 初回出力時、警告ない場合はタイトル出力しない
                        if (loopIndex == 0 && this._exportDataSet.Tables[ExportMoveDataItems.ct_Tbl_ArrivalWarning].Rows.Count == 0)
                        {
                            i = loopIndex + 1;
                            titleFlgW = false;
                        }
                        // 初回出力時、警告ある場合はタイトル出力する
                        if (loopIndex == 0 && this._exportDataSet.Tables[ExportMoveDataItems.ct_Tbl_ArrivalWarning].Rows.Count > 0)
                        {
                            i = 0;
                            titleFlgW = true;
                        }
                        // 次回以降、警告ある場合はタイトル出力する
                        if (!titleFlgW && loopIndex > 0 && this._exportDataSet.Tables[ExportMoveDataItems.ct_Tbl_ArrivalWarning].Rows.Count > 0)
                        {
                            i = 0;
                            titleFlgW = true;
                        }

                        // 入荷予約警告一覧CSV出力
                        status = DoOutPut(ref export, this._exportDataSet.Tables[ExportMoveDataItems.ct_Tbl_ArrivalWarning].DefaultView, this._fileWarningName, 1, i, out message);
                        // 次回以降、タイトルある場合は再出力しない
                        if (titleFlgW)
                        {
                            i = loopIndex + 1;
                        }
                       
                        // 例外発生時
                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            msg =string.Format(MessageInfo.M_023, status, message);
                            this.ShowResult(msg, ct_RUN_MESSAGE04);
                            // Timerを閉じる
                            this._restTimer.Change(Timeout.Infinite, 0);
                            this.ultraLabel_time.Text = string.Empty;
                            status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                            return status;
                        }

                        // 結果リストをクリア
                        retMoveDataList.Clear();
                        // テーブルのクリア
                        this._exportDataSet.Tables[ExportMoveDataItems.ct_Tbl_Arrival].Clear();
                        this._exportDataSet.Tables[ExportMoveDataItems.ct_Tbl_ArrivalWarning].Clear();

                        // 残り予測時間更新
                        string step_ExporthConfig = ConfigurationManager.AppSettings["Step_Export"];
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
            #endregion
            #endregion

            #region アップロード処理・部品MAX状況監視・完了処理
            // アップロード判断
            status = this.UpLoadFileCheck(out errMessage);
            // 例外発生時
            if (!string.IsNullOrEmpty(errMessage))
            {
                string mesage = string.Format(MessageInfo.M_033, status, errMessage);
                this.ShowResult(mesage, ct_RUN_MESSAGE04);
                // Timerを閉じる
                this._restTimer.Change(Timeout.Infinite, 0);
                this.ultraLabel_time.Text = string.Empty;
                return status;
            }
            #endregion

            return status;
        }

        #region 出力ファイルの削除
        /// <summary>
        /// 出力ファイルの削除
        /// </summary>
        /// <param name="errMessage">メッセージ</param>
        /// <remarks>
        /// <br>Note       : 出力ファイルの削除を行う。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2016/01/21</br>
        /// <br>UpdateNote : 宋剛 2016/02/15</br>
        /// <br>           : Redmine#48629の#59の　CSVファイルがオープンされている障害対応</br>
        /// </remarks>
        private int DeleteFile(out string errMessage)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            errMessage = string.Empty;
            try
            {
                // 入荷予約一覧
                if (File.Exists(this._fileName))
                {
                    // ADD BY 宋剛 2016/02/15 FOR Redmine#48629の#59の　CSVファイルがオープンされている障害対応 ---->>>>>
                    status = IsFileLocked(this._fileName);
                    if ((int)FileLocked_Status.FileLocked_LOCKED == status)
                    {
                        errMessage = ct_FILEALRDY_ERROR;
                        return status;
                    }
                    // ADD BY 宋剛 2016/02/15 FOR Redmine#48629の#59の　CSVファイルがオープンされている障害対応 ----<<<<<

                    // 移動データの出力ファイルを削除
                    File.Delete(this._fileName);
                }
                // 入荷予約警告一覧
                if (File.Exists(this._fileWarningName))
                {
                    // ADD BY 宋剛 2016/02/15 FOR Redmine#48629の#59の　CSVファイルがオープンされている障害対応 ---->>>>>
                    status = IsFileLocked(this._fileWarningName);
                    if ((int)FileLocked_Status.FileLocked_LOCKED == status)
                    {
                        errMessage = ct_FILEALRDY_ERROR;
                        return status;
                    }
                    // ADD BY 宋剛 2016/02/15 FOR Redmine#48629の#59の　CSVファイルがオープンされている障害対応 ----<<<<<

                    // 移動データの出力ファイルを削除
                    File.Delete(this._fileWarningName);
                }

                // システム日付から60日以上前、出力ファイルを削除
                DirectoryInfo theFolder = new DirectoryInfo(this._filePath);
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
                                    errMessage = ct_FILEALRDY_ERROR;
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
            catch (Exception ex)
            {
                errMessage = ex.Message;
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
        #endregion

        #region 入力値検査
        /// <summary>
        /// テキスト出力前にチェック処理
        /// </summary>
        /// <param name="errMessage">エラーメッセージ</param>
        /// <param name="errControl">エラーコントロール</param>
        /// <returns>エラー有無フラグ</returns>
        /// <remarks>
        /// <br>Note       : テキスト出力前にチェック処理を行います。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2016/01/21</br>
        /// </remarks>
        private bool BeforeSearchCheck(out string errMessage, out Control errControl)
        {
            this.ShowResult(MessageInfo.M_013, string.Empty);
            DateGetAcs.CheckDateRangeResult cdrResult;
            bool result = true;
            errMessage = string.Empty;
            errControl = null;

            // 部品MAX得意先
            if (this.tNedit_CustomerCode.GetInt() == 0)
            {
                errMessage = MessageInfo.M_010;
                errControl = this.tNedit_CustomerCode;
                result = false;
                return result;
            }

            // 出荷日付(開始)、出荷日付(終了) 
            if (CallCheckDateRange(out cdrResult, ref TDateEdit_SlipDateSt, ref TDateEdit_SlipDateEd) == false)
            {
                result = false;
                switch (cdrResult)
                {
                    case DateGetAcs.CheckDateRangeResult.ErrorOfStartNoInput:
                        {
                            errMessage = MessageInfo.M_011;
                            errControl = this.TDateEdit_SlipDateSt;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfStartInvalid:
                        {
                            errMessage = MessageInfo.M_011;
                            errControl = this.TDateEdit_SlipDateSt;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfEndNoInput:
                        {
                            errMessage = MessageInfo.M_011;
                            errControl = this.TDateEdit_SlipDateEd;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfEndInvalid:
                        {
                            errMessage = MessageInfo.M_011;
                            errControl = this.TDateEdit_SlipDateEd;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfReverse:
                        {
                            errMessage = MessageInfo.M_003;
                            errControl = this.TDateEdit_SlipDateSt;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfRangeOver:
                        {
                            result = true;
                        }
                        break;
                }

                return result;
            }

            //入庫倉庫コードリスト
            if (this.checkedListBox_AfWarehouse.CheckedItems.Count == 0)
            {
                errMessage = MessageInfo.M_006;
                errControl = this.checkedListBox_AfWarehouse;
                result = false;
                return result;
            }

            // 発送日数
            if (string.IsNullOrEmpty(this.tNedit_ShDate.Text))
            {
                errMessage = MessageInfo.M_041;
                errControl = this.tNedit_ShDate;
                result = false;
                return result;
            }

            // 売価率下限値
            if (this.tNedit_SalesRate.GetInt() == 0)
            {
                errMessage = MessageInfo.M_038;
                errControl = this.tNedit_SalesRate;
                result = false;
                return result;
            }

            // 販売単価下限値
            if (this.tNedit_SalesPrice.GetInt() == 0)
            {
                errMessage = MessageInfo.M_039;
                errControl = this.tNedit_SalesPrice;
                result = false;
                return result;

            }

            return result;
        }
        #endregion

        #region 出力条件設定処理
        /// <summary>
        /// 出力条件設定処理(画面→出力条件)
        /// </summary>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 出力条件設定処理(画面→出力条件)を行う。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2016/01/21</br>
        /// </remarks>
        private int SetExtraInfoFromScreen()
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            try
            {
                // 企業コード
                this._searchCond.EnterpriseCode = this._enterpriseCode;

                // 得意先ｺｰﾄﾞ
                this._searchCond.CustomerCode = this.tNedit_CustomerCode.GetInt();

                // 出荷日付(開始)
                this._searchCond.ShipDateSt = this.TDateEdit_SlipDateSt.GetDateTime();
                // 出荷日付(終了)
                this._searchCond.ShipDateEd = this.TDateEdit_SlipDateEd.GetDateTime();

                // 入庫拠点
                if (!string.IsNullOrEmpty(this.AfSectionCode_tEdit.Text.Trim()))
                {
                    this._searchCond.AfSectionCode = this.AfSectionCode_tEdit.Text.Trim().PadLeft(2, '0');
                }
                else
                {
                    this._searchCond.AfSectionCode = string.Empty;
                }
                // 出庫拠点
                if (!string.IsNullOrEmpty(this.BfSectionCode_tEdit.Text.Trim()))
                {
                    this._searchCond.BfSectionCode = this.BfSectionCode_tEdit.Text.Trim().PadLeft(2, '0');
                }
                else
                {
                    this._searchCond.BfSectionCode = string.Empty;
                }

                // 入庫倉庫コードリスト
                int itemIndex = 0;
                string[] afWarehouse = new string[this.checkedListBox_AfWarehouse.CheckedItems.Count];
                string st = string.Empty;
                string aMovehouse = string.Empty;

                foreach (object checkedItem in this.checkedListBox_AfWarehouse.CheckedItems)
                {
                    st = (string)checkedItem;
                    aMovehouse = st.Substring(0, 4);
                    afWarehouse[itemIndex] = aMovehouse;
                    itemIndex++;
                }
                this._searchCond.AfWarehouseCodeList = afWarehouse;

                // 出庫倉庫コードリスト
                int itemIndexBf = 0;
                string[] bfWarehouse = new string[this.checkedListBox_BfWarehouse.CheckedItems.Count];

                foreach (object checkedItem in this.checkedListBox_BfWarehouse.CheckedItems)
                {
                    st = (string)checkedItem;
                    aMovehouse = st.Substring(0, 4);
                    bfWarehouse[itemIndexBf] = aMovehouse;
                    itemIndexBf++;
                }
                this._searchCond.BfWarehouseCodeList = bfWarehouse;

                // 発送日数
                this._searchCond.SalesOrderCount = this.tNedit_ShDate.GetInt();

                // 売価率下限値
                this._searchCond.SalesRate = this.tNedit_SalesRate.GetInt();

                // 販売単価下限値
                this._searchCond.SalesPrice = this.tNedit_SalesPrice.GetInt();

                // チェックリスト出力選択
                if (this.ultraCheckEditor.Checked)
                {
                    this._searchCond.MoveChecked = 1;
                }
            }
            catch (Exception)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }

            return status;
        }
        #endregion

        #region アップロード判断・処理・部品MAX状況監視処理・完了処理
        /// <summary>
        ///アップロード判断
        /// </summary>
        /// <param name="errMessage">メッセージ</param>
        /// <remarks>
        /// <br>Note       : アップロード判断を行う。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2016/01/21</br>
        /// <br>UpdateNote : 宋剛 2016/02/22</br>
        /// <br>           : LDNS発生した障害　アップロードメッセージ不正の障害対応</br>
        /// </remarks>
        private int UpLoadFileCheck(out string errMessage)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            string message = string.Empty;
            errMessage = string.Empty;
            try
            {
                // 指定されたフォルダが存在チェック
                if (!Directory.Exists(this._filePath)) return (int)ConstantManagement.DB_Status.ctDB_ERROR;
                if (!File.Exists(this._fileWarningName)) return (int)ConstantManagement.DB_Status.ctDB_ERROR;
                if (!File.Exists(this._fileName)) return (int)ConstantManagement.DB_Status.ctDB_ERROR;
                FileInfo fileInfoE = new FileInfo(this._fileWarningName);
                FileInfo fileInfo = new FileInfo(this._fileName);
                long sizeE = fileInfoE.Length;
                long size = fileInfo.Length;
                string fileName = string.Empty;
                // 入荷予約一覧_警告.csvのファイルサイズ  > 0バイト
                if (sizeE > 0)
                {
                    message = MessageInfo.M_042;
                    // 入荷予約一覧_警告.csv
                    fileName = this._fileWarningName;
                    // Timerを閉じる
                    this._restTimer.Change(Timeout.Infinite, 0);
                    // ダイアログを表示する
                    // UPD BY 宋剛 2016/02/22 FOR LDNS発生した障害　アップロードメッセージ不正の障害対応 ---->>>>>
                    // status = UpLoadDialog(message, fileName);
                    status = UpLoadDialog(message, fileName, out errMessage);
                    // UPD BY 宋剛 2016/02/22 FOR LDNS発生した障害　アップロードメッセージ不正の障害対応 ----<<<<<

                }
                // 入荷予約一覧.csvのファイルサイズ = 0バイト
                else if (size == 0)
                {
                    // 中止
                    this.ShowResult(MessageInfo.M_024, ct_RUN_MESSAGE02);
                    // Timerを閉じる
                    this._restTimer.Change(Timeout.Infinite, 0);
                    this.ultraLabel_time.Text = string.Empty;
                    return (int)ConstantManagement.DB_Status.ctDB_ERROR;

                }
                // チェックリスト出力選択 = 選択状態
                else if (this.ultraCheckEditor.Checked)
                {
                    message = MessageInfo.M_043;
                    // 入荷予約一覧.csv
                    fileName = this._fileName;
                    // Timerを閉じる
                    this._restTimer.Change(Timeout.Infinite, 0);
                    // ダイアログを表示する
                    // UPD BY 宋剛 2016/02/22 FOR LDNS発生した障害　アップロードメッセージ不正の障害対応 ---->>>>>
                    // status = UpLoadDialog(message, fileName);
                    status = UpLoadDialog(message, fileName, out errMessage);
                    // UPD BY 宋剛 2016/02/22 FOR LDNS発生した障害　アップロードメッセージ不正の障害対応 ----<<<<<

                }
                else
                {
                    // 部品MAXアップロード処理
                    this.UpLoadFile(out errMessage, this._fileName);
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
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2016/01/21</br>
        /// <br>UpdateNote : 宋剛 2016/02/22</br>
        /// <br>           : LDNS発生した障害　アップロードメッセージ不正の障害対応</br>
        /// </remarks>
        // private int UpLoadDialog(string message, string fileName) // DEL BY 宋剛 2016/02/22 FOR LDNS発生した障害　アップロードメッセージ不正の障害対応
        private int UpLoadDialog(string message, string fileName, out string errMessage) // ADD BY 宋剛 2016/02/22 FOR LDNS発生した障害　アップロードメッセージ不正の障害対応
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            errMessage = string.Empty;// ADD BY 宋剛 2016/02/22 FOR LDNS発生した障害　アップロードメッセージ不正の障害対応
            PMMAX02000UG frm = new PMMAX02000UG();
            
            // ダイアログを表示する
            DialogResult ret = frm.ShowDialog(this, message, 0, fileName);
            if (ret == DialogResult.Yes)
            {
                if (this._restTimer != null)
                {
                    // Timerを作成
                    this._restTimer = new System.Threading.Timer(new TimerCallback(TimerCall), null, 0, 1000);
                    
                }
                // 部品MAXアップロード処理
                // UPD BY 宋剛 2016/02/22 FOR LDNS発生した障害　アップロードメッセージ不正の障害対応 ---->>>>>
                // status = this.UpLoadFile(out message, this._fileName);
                status = this.UpLoadFile(out errMessage, this._fileName);
                // UPD BY 宋剛 2016/02/22 FOR LDNS発生した障害　アップロードメッセージ不正の障害対応 ----<<<<<

            }
            else if (ret == DialogResult.Abort)
            {
                // 中止ボタン押下時
                this.ShowResult(MessageInfo.M_016, ct_RUN_MESSAGE02);
                // Timerを閉じる
                this._restTimer.Change(Timeout.Infinite, 0);
                this.ultraLabel_time.Text = string.Empty;
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                return status;
            }
            return status;

        }

        /// <summary>
        /// Timerを閉じる
        /// </summary>
        /// <remarks>
        /// <br>Note       : Timerを閉じる。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2016/01/21</br>
        /// </remarks>
        private void StopTimer()
        {  
            // Timerを閉じる
            this._restTimer.Change(Timeout.Infinite, 0);
        }

        /// <summary>
        /// 部品MAXアップロード処理
        /// </summary>
        /// <param name="errMessage">メッセージ</param>
        /// <param name="fileName">出力ファイル</param>
        /// <remarks>
        /// <br>Note       : 部品MAXアップロード処理を行う。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2016/01/21</br>
        /// <br>UpdateNote : 宋剛 2016/02/19</br>
        /// <br>           : Redmine#48629の障害一覧No.243　「部品MAXに登録する」を選択すると、
        ///                 「予期せぬエラーが発生しました」が表示された障害対応</br>
        /// <br>UpdateNote : 宋剛 2016/02/19</br>
        /// <br>           : Redmine#48629の障害一覧No.244　認証失敗後に中止すると、実行状況が「中止」ではなく「エラー」になる障害対応</br>
        /// </remarks>
        private int UpLoadFile(out string errMessage, string fileName)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            this.ShowResult(MessageInfo.M_026, ct_RUN_MESSAGE01);
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
                    this.ShowResult(string.Format(MessageInfo.M_033, status, ct_FILEALRDY_ERROR), ct_RUN_MESSAGE04);

                    // Timerを閉じる
                    this._restTimer.Change(Timeout.Infinite, 0);
                    this.ultraLabel_time.Text = string.Empty;
                    this.ultraLabel_time.Refresh();
                    return (int)ConstantManagement.DB_Status.ctDB_ERROR;
                }
                // ADD BY 宋剛 2016/02/19 FOR Redmine#48629の障害一覧No.243　「部品MAXに登録する」を選択すると、「予期せぬエラーが発生しました」が表示された障害対応----<<<<<

                this._runFlg = true;   // ADD 2016/02/24 Y.Wakita ③

                // 部品MAX共通部品を呼び出し、入荷予約アップロード処理を行う。
                status = this._buhinMaxStockArrivalProvider.Regist(this._loginId, this._password, fileName, ref errMessage);

                // 残り予測時間更新
                string step_UploadConfig = ConfigurationManager.AppSettings["Step_Upload"];
                double step_Upload = 0;
                double.TryParse(step_UploadConfig.Replace("%", ""), out step_Upload);

                this.UpdateRestTime(step_Upload);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // 部品MAX状況監視
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
                    this.ShowResult(MessageInfo.M_025, ct_RUN_MESSAGE01);
                    // 部品MAXログインID、部品MAXパスワードが入力されているかを確認する
                    this._pmmax02000UE.DisplayMessage = MessageInfo.M_025;
                    DialogResult ret = this._pmmax02000UE.ShowDialog();
                    if (ret == DialogResult.Yes)
                    {
                        this._loginId = this._pmmax02000UE.UserID;
                        this._password = this._pmmax02000UE.UserPassWord;
                        status = UpLoadFile(out errMessage, fileName);

                    }
                    else if (ret == DialogResult.Cancel)
                    {
                        // 中止ボタン押下時
                        this.ShowResult(MessageInfo.M_016, ct_RUN_MESSAGE02);
                        errMessage = string.Empty; // ADD BY 宋剛 2016/02/19 FOR Redmine#48629の障害一覧No.244　認証失敗後に中止すると、実行状況が「中止」ではなく「エラー」になる障害対応
                        // Timerを閉じる
                        this._restTimer.Change(Timeout.Infinite, 0);
                        this.ultraLabel_time.Text = string.Empty;
                        status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                        return status;
                    }

                }
                // 部品MAX接続できませんでした
                else if (status == 400)
                {
                    this.ShowResult(MessageInfo.M_027, ct_RUN_MESSAGE04);
                    // Timerを閉じる
                    this._restTimer.Change(Timeout.Infinite, 0);
                    this.ultraLabel_time.Text = string.Empty;
                    return status;

                }
                else
                {
                    string msg = string.Format(MessageInfo.M_028, status, errMessage);
                    this.ShowResult(msg, ct_RUN_MESSAGE04);
                    // Timerを閉じる
                    this._restTimer.Change(Timeout.Infinite, 0);
                    this.ultraLabel_time.Text = string.Empty;
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
        /// <param name="readMsgDateTime">前回状況監視呼出日時</param>
        /// <remarks>
        /// <br>Note       : 部品MAX状況監視処理を行う。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2016/01/21</br>
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
                status = this._buhinMaxStockArrivalProvider.GetRegistStatus(readMessageDateTime, ref errorListCsvFileFullName, ref timeLeftSeconds, ref messageList);
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
                    // [メッセージ一覧]のM-030を出力する
                    this.ShowResult(MessageInfo.M_030, ct_RUN_MESSAGE01);
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

                    this.ShowResult(MessageInfo.M_029, ct_RUN_MESSAGE04);
                    // Timerを閉じる
                    this._restTimer.Change(Timeout.Infinite, 0);
                    this.ultraLabel_time.Text = string.Empty;
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
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2016/01/21</br>
        /// </remarks>
        private void EndSave()
        {
            // 完了処理
            this.ShowResult(MessageInfo.M_031, ct_RUN_MESSAGE03);
            // メインー画面項目と設定画面項目はXMLに保存する
            this.ScreenItemsToXML(_shipDateRange);
            this.ShowResult(MessageInfo.M_032, ct_RUN_MESSAGE03);
            // Timerを閉じる
            this._restTimer.Change(Timeout.Infinite, 0);
            this.ultraLabel_time.Text = string.Empty;
        }
        #endregion

        #region XMLファイル処理
        /// <summary>
        /// 画面設定値はXMLファイルにセットする
        /// </summary>
        /// <param name="shipDateRange">出荷日付初期値</param>
        /// <remarks>
        /// <br>Note        : 画面設定値はXMLファイルにセットする</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2016/01/21</br>
        /// </remarks>
        private void ScreenItemsToXML(int shipDateRange)
        {
            // XMLファイルを読み込む
            _pMMAX02000UC.Deserialize();
            OutAndInPutUserData exportSalesDataList = _pMMAX02000UC.ExportSalesDataList;
            // XMLファイルにユーザー情報が存在かどうかのフラグ
            bool checkFileFlag = false;
            if (exportSalesDataList.ExportSalesDataList != null && exportSalesDataList.ExportSalesDataList.Count > 0)
            {
                for (int i = 0; i < exportSalesDataList.ExportSalesDataList.Count; i++)
                {
                    OutAndInPutUserSaveItems saveItems = exportSalesDataList.ExportSalesDataList[i];
                    if (saveItems.EnterpriseCode == this._enterpriseCode && saveItems.SectionCode == this._loginSectionCode)
                    {
                        // チェックリスト出力先の設定
                        checkFileFlag = true;
                        // その他の項目の設定
                        this.SetItems(ref saveItems, shipDateRange);
                        break;
                      }
                }
            }
            // XMLファイルにユーザー情報がある場合
            if (!checkFileFlag)
            {
                // 新しいユーザー情報を追加する
                OutAndInPutUserSaveItems formSaveItems = new OutAndInPutUserSaveItems();
                // 企業コード
                formSaveItems.EnterpriseCode = this._enterpriseCode;
                // 拠点コード
                formSaveItems.SectionCode = this._sectionCode;
                // その他の項目の設定
                this.SetItems(ref formSaveItems, shipDateRange);
                exportSalesDataList.ExportSalesDataList.Add(formSaveItems);
            }
            else
            {
                // なし
            }

            // 画面条件をXMLファイルに保存する
            _pMMAX02000UC.Serialize();
        }

        /// <summary>
        /// XMLファイル保存用ワークの作成
        /// </summary>
        /// <param name="formSaveItems">XMLファイル保存用ワーク</param>
        /// <param name="shipDateRange">出荷日付初期値</param>
        /// <remarks>
        /// <br>Note       : XMLファイル保存用ワークの作成</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2016/01/21</br>
        /// </remarks>
        private void SetItems(ref OutAndInPutUserSaveItems formSaveItems, int shipDateRange)
        {
            // 部品MAX得意先
            formSaveItems.CustomerCode = this.tNedit_CustomerCode.GetInt();
            // 出庫拠点コード
            formSaveItems.BfSectionCode = this.BfSectionCode_tEdit.Text.Trim();
            // 入庫拠点コード
            formSaveItems.AfSectionCode = this.AfSectionCode_tEdit.Text.Trim();
            // 発送日数
            formSaveItems.SalesOrderCount = this.tNedit_ShDate.GetInt();
            // 売価率下限値
            formSaveItems.SalesRate = this.tNedit_SalesRate.GetInt();
            // 販売単価下限値
            formSaveItems.SalesPrice = this.tNedit_SalesPrice.GetInt();
            // チェックリスト出力選択
            if (this.ultraCheckEditor.Checked == true)
            {
                formSaveItems.MoveChecked = 1;
            }
            else
            {
                formSaveItems.MoveChecked = 0;
            }
            // 出庫倉庫コードリスト
            // 全て倉庫がChecked：true
            formSaveItems.BfWarehouseCodeList = "";
            for (int i = 0; i < this.checkedListBox_BfWarehouse.Items.Count; i++)
            {
                bool checkedFlag = this.checkedListBox_BfWarehouse.GetItemChecked(i);

                if (checkedFlag)
                {
                    // Checked項目の倉庫コードを取得する
                    string wareCode = checkedListBox_BfWarehouse.GetItemText(checkedListBox_BfWarehouse.Items[i]).Trim().Substring(0, 4);
                    // 初めて倉庫にセットする
                    if (string.IsNullOrEmpty(formSaveItems.BfWarehouseCodeList))
                    {
                        formSaveItems.BfWarehouseCodeList = wareCode;
                    }
                    else
                    {
                        formSaveItems.BfWarehouseCodeList += "," + wareCode;
                    }
                }
            }
            // 入庫倉庫コードリスト
            // 全て倉庫がChecked：true
            formSaveItems.AfWarehouseCodeList = "";
            for (int i = 0; i < this.checkedListBox_AfWarehouse.Items.Count; i++)
            {
                bool checkedFlag = this.checkedListBox_AfWarehouse.GetItemChecked(i);

                if (checkedFlag)
                {
                    // Checked項目の倉庫コードを取得する
                    string wareCode = checkedListBox_AfWarehouse.GetItemText(checkedListBox_AfWarehouse.Items[i]).Trim().Substring(0, 4);
                    // 初めて倉庫にセットする
                    if (string.IsNullOrEmpty(formSaveItems.AfWarehouseCodeList))
                    {
                        formSaveItems.AfWarehouseCodeList = wareCode;
                    }
                    else
                    {
                        formSaveItems.AfWarehouseCodeList += "," + wareCode;
                    }
                }
            }
            // チェックリスト出力先の設定
            formSaveItems.MoveFileName = this._filePath;
            
            // 出荷日付範囲
            if (shipDateRange == 0)
            {
                formSaveItems.ShipDateInit = 2;
            }
            else
            {
                formSaveItems.ShipDateInit = shipDateRange;
            }
        }

        /// <summary>
        /// XMLファイルから画面をセットする
        /// </summary>
        /// <remarks>
        /// <br>Note       : XMLファイルから画面をセットする</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date       : 2016/01/21</br>
        /// </remarks>
        private void XMLFileToScreen()
        {
            // XMLファイルを読み込む
            this._pMMAX02000UC.Deserialize();
            OutAndInPutUserData exportSalesDataList = _pMMAX02000UC.ExportSalesDataList;
            // ユーザー情報があるかどうかフラグ
            bool checkFileFlag = false;
            _saveItemsTemp = new OutAndInPutUserSaveItems();
            // XMLに該当するデータを取得する
            foreach (OutAndInPutUserSaveItems saveItems in exportSalesDataList.ExportSalesDataList)
            {
                if (saveItems.EnterpriseCode == this._enterpriseCode && saveItems.SectionCode == this._loginSectionCode)
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
                this.XMLDateToMnue(_saveItemsTemp);
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
        /// <br>Note       : XMLファイルに画面項目を保存しない場合、画面を初期化する</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2016/01/21</br>
        /// </remarks>
        public void InitDateToMnue()
        {
            // 部品MAX得意先
            this.tNedit_CustomerCode.Text = string.Empty;
            // 入庫拠点コード
            this.AfSectionCode_tEdit.Text = string.Empty;
            // 出庫拠点コード
            this.BfSectionCode_tEdit.Text = string.Empty;
            // 発送日数
            this.tNedit_ShDate.SetInt(0);
            // 売価率下限値
            this.tNedit_SalesRate.SetInt(50);
            // 販売単価下限値
            this.tNedit_SalesPrice.SetInt(1);
            // チェックリスト出力選択
            this.ultraCheckEditor.Checked = true;
            // 出庫倉庫コードリスト
            // 全て倉庫がChecked：false
            for (int i = 0; i < checkedListBox_BfWarehouse.Items.Count; i++)
            {
            this.checkedListBox_BfWarehouse.SetItemChecked(i, false);
            }
            // 入庫倉庫コードリスト
            // 全て倉庫がChecked：false
            for (int i = 0; i < checkedListBox_AfWarehouse.Items.Count; i++)
            {
                this.checkedListBox_AfWarehouse.SetItemChecked(i, false);
            }
            // 出荷日付(開始)
            this.TDateEdit_SlipDateSt.SetDateTime(DateTime.Now);
            // 出荷日付(終了)
            this.TDateEdit_SlipDateEd.SetDateTime(DateTime.Now);
        }

        /// <summary>
        /// XMLファイルから取得する項目値を画面にセットする
        /// </summary>
        /// <param name="saveItems">XMLファイルデータ</param>
        /// <remarks>
        /// <br>Note       : XMLファイルから取得する項目値を画面にセットする</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2016/01/21</br>
        /// </remarks>
        public void XMLDateToMnue(OutAndInPutUserSaveItems saveItems)
        {
            // 部品MAX得意先
            this.tNedit_CustomerCode.SetInt(saveItems.CustomerCode);
            this.tEdit_CustomerName.Text = this.GetCustomerName(this.tNedit_CustomerCode.GetInt());
            // 入庫拠点コード
            this.AfSectionCode_tEdit.Text = saveItems.AfSectionCode.Trim();
            string afSectionCode;
            string afSectionName;
            this.ReadAfSectionCodeName(out afSectionCode, out afSectionName);
            this.AfSectionName_tEdit.Text = afSectionName;
            // 出庫拠点コード
            this.BfSectionCode_tEdit.Text = saveItems.BfSectionCode.Trim();
            string bfSectionCode;
            string bfSectionName;
            this.ReadBfSectionCodeName(out bfSectionCode, out bfSectionName);
            this.BfSectionName_tEdit.Text = bfSectionName;
            // 発送日数
            this.tNedit_ShDate.SetInt(saveItems.SalesOrderCount);
            // 売価率下限値
            this.tNedit_SalesRate.SetInt(saveItems.SalesRate);
            // 販売単価下限値
            this.tNedit_SalesPrice.SetInt(saveItems.SalesPrice);
            // チェックリスト出力先
            this._filePath = saveItems.MoveFileName;
            // チェックリスト出力選択
            if (saveItems.MoveChecked == 0)
            {
                this.ultraCheckEditor.Checked = false;
            }
            else
            {
                this.ultraCheckEditor.Checked = true;
            }
            // 出庫倉庫コードリスト
            if (!string.IsNullOrEmpty(saveItems.BfWarehouseCodeList.Trim()))
            {
                string[] wareArray = saveItems.BfWarehouseCodeList.Trim().Split(',');
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
                for (int i = 0; i < checkedListBox_BfWarehouse.Items.Count; i++)
                {
                    string tempWarehouseCode = checkedListBox_BfWarehouse.GetItemText(checkedListBox_BfWarehouse.Items[i]).Trim().Substring(0, 4);
                    if (wareDic.ContainsKey(tempWarehouseCode))
                    {
                        this.checkedListBox_BfWarehouse.SetItemChecked(i, true);
                    }
                }
            }
            // 入庫倉庫コードリスト
            if (!string.IsNullOrEmpty(saveItems.AfWarehouseCodeList.Trim()))
            {
                string[] wareArray = saveItems.AfWarehouseCodeList.Trim().Split(',');
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
                for (int i = 0; i < checkedListBox_AfWarehouse.Items.Count; i++)
                {
                    string tempWarehouseCode = checkedListBox_AfWarehouse.GetItemText(checkedListBox_AfWarehouse.Items[i]).Trim().Substring(0, 4);
                    if (wareDic.ContainsKey(tempWarehouseCode))
                    {
                        this.checkedListBox_AfWarehouse.SetItemChecked(i, true);
                    }
                }
            }

            // 出荷日付初期値
            if (saveItems.ShipDateInit ==1)
            {
                this.TDateEdit_SlipDateSt.SetDateTime(DateTime.Now.AddDays(-1));    // 出荷日付(開始)
                this.TDateEdit_SlipDateEd.SetDateTime(DateTime.Now.AddDays(-1));    // 出荷日付終了
            }
            else if (saveItems.ShipDateInit == 2)
            {
                this.TDateEdit_SlipDateSt.SetDateTime(DateTime.Now);    // 出荷日付(開始)
                this.TDateEdit_SlipDateEd.SetDateTime(DateTime.Now);    // 出荷日付終了
            }
            else
            {
                this.TDateEdit_SlipDateSt.SetDateTime(DateTime.Now.AddDays(1));    // 出荷日付(開始)
                this.TDateEdit_SlipDateEd.SetDateTime(DateTime.Now.AddDays(1));    // 出荷日付終了
            }
        }
        #endregion

        #region データ準備
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
        private Boolean isContainSpecalCharMain(PartsMaxStockArrivalWork moveData)
        {
            if (isContainSpecalCharProc(moveData.GoodsName))
            {
                return true;
            }

            if (isContainSpecalCharProc(moveData.GoodsNo))
            {
                return true;
            }

            if (isContainSpecalCharProc(moveData.GoodsMakerNm))
            {
                return true;
            }

            if (isContainSpecalCharProc(moveData.BfSectionName))
            {
                return true;
            }

            if (isContainSpecalCharProc(moveData.BfEnterWarehName))
            {
                return true;
            }

            if (isContainSpecalCharProc(moveData.AfSectionName))
            {
                return true;
            }

            if (isContainSpecalCharProc(moveData.AfEnterWarehName))
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
        /// <param name="mode">0:入荷予約一覧,1:入荷予約警告一覧</param>
        /// <remarks>
        /// <br>Note       : 移動データをDataTableに格納します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2016/01/21</br>
        /// <br>UpdateNote : 宋剛 2016/02/15</br>
        /// <br>           : Redmine#48629の#64の　売価率と単価の整数出力対応</br>
        /// <br>UpdateNote : 宋剛 2016/02/15</br>
        /// <br>           : Redmine#48629の障害一覧No.2の　販売単価と売価率の「未満」仕様変更対応</br>
        /// <br>UpdateNote : 宋剛 2016/02/15</br>
        /// <br>           : Redmine#48629の#70の　販売単価などのカンマは必要ないので削除する</br>
        /// <br>UpdateNote : 宋剛 2016/02/16</br>
        /// <br>           : Redmine#48629の障害一覧No.13　出荷数の小数点以下が切り捨てされない仕様変更対応</br>
        /// <br>UpdateNote : 宋剛 2016/02/19</br>
        /// <br>           : チェック処理に名称にカンマとダブルクウォーテーションが含まれていないか判定処理追加</br>
        /// </remarks>
        private void GetMoveDataTable(ArrayList retMoveDataList, int mode)
        {
            string formatDate = "yyyy/MM/dd";
            // UPD BY 宋剛 2016/02/15 FOR Redmine#48629の#64の　売価率と単価の整数出力対応 ---->>>>>
            // string formatFraction = "#,##0.00;-#,##0.00;";
            string formatFraction = "#,##0;-#,##0;";
            // UPD BY 宋剛 2016/02/15 FOR Redmine#48629の#64の　売価率と単価の整数出力対応 ----<<<<<

            // 移動データ
            if (retMoveDataList != null && retMoveDataList.Count > 0)
            {
                foreach (PartsMaxStockArrivalWork moveData in retMoveDataList)
                {
                    DataRow row = this._exportDataSet.Tables[ExportMoveDataItems.ct_Tbl_Arrival].NewRow();
                    if (mode == 1)
                    {
                        row = this._exportDataSet.Tables[ExportMoveDataItems.ct_Tbl_ArrivalWarning].NewRow();
                    }

                    #region 移動データの格納
                    // 企業コード
                    row[ExportMoveDataItems.ct_Col_EnterpriseCode] = moveData.EnterpriseCode;
                    // 拠点コード
                    row[ExportMoveDataItems.ct_Col_SectionCode] = this._sectionCode;
                    // 出荷日
                    if (moveData.ShipDate == DateTime.MinValue)
                    {
                        row[ExportMoveDataItems.ct_Col_StockMoveDate] = DBNull.Value;
                    }
                    else
                    {
                        row[ExportMoveDataItems.ct_Col_StockMoveDate] = moveData.ShipDate.ToString(formatDate);
                    }
                    // 伝票番号
                    row[ExportMoveDataItems.ct_Col_StockMoveSlipNo] = moveData.StockMoveSlipNo;
                    // 行No
                    row[ExportMoveDataItems.ct_Col_StockMoveRowNo] = moveData.StockMoveSlipRowNo;
                    // 品名
                    row[ExportMoveDataItems.ct_Col_GoodsName] = ConvertSpecialStr(moveData.GoodsName);
                    // 品番
                    row[ExportMoveDataItems.ct_Col_GoodsNo] = ConvertSpecialStr(moveData.GoodsNo);
                    // メーカーコード
                    row[ExportMoveDataItems.ct_Col_GoodsMakerCd] = moveData.GoodsMakerCd.ToString().Trim().PadLeft(4, '0');
                    // メーカー名
                    row[ExportMoveDataItems.ct_Col_MakerName] = ConvertSpecialStr(moveData.GoodsMakerNm);
                    // BLｺｰﾄﾞ
                    row[ExportMoveDataItems.ct_Col_BLGoodsCode] = moveData.BLGoodsCod;
                    // 出荷数
                    // UPD BY 宋剛 2016/02/16 Redmine#48629の障害一覧No.13　出荷数の小数点以下が切り捨てされない仕様変更対応 ---->>>>>
                    // row[ExportMoveDataItems.ct_Col_ShipmentCount] = moveData.ShipmentCount.ToString();
                    row[ExportMoveDataItems.ct_Col_ShipmentCount] = CutDownNum(moveData.ShipmentCount);
                    // UPD BY 宋剛 2016/02/16 Redmine#48629の障害一覧No.13　出荷数の小数点以下が切り捨てされない仕様変更対応 ----<<<<<
                    // オープン価格区分
                    row[ExportMoveDataItems.ct_Col_OpenPriceDiv] = moveData.OpenPriceDiv;
                    // DEL BY 宋剛 2016/02/15 FOR Redmine#48629の#64の　売価率と単価の整数出力対応 ---->>>>>
                    //// 販売単価
                    //row[ExportMoveDataItems.ct_Col_SalesPrice] = moveData.SalesUnitCost.ToString(formatFraction);
                    //// 売価率
                    //row[ExportMoveDataItems.ct_Col_SalesRate] = moveData.SalesRate.ToString(formatFraction);
                    // DEL BY 宋剛 2016/02/15 FOR Redmine#48629の#64の　売価率と単価の整数出力対応 ----<<<<<
                    // ADD BY 宋剛 2016/02/15 FOR Redmine#48629の#64の　売価率と単価の整数出力対応 ---->>>>>
                    // 販売単価
                    // row[ExportMoveDataItems.ct_Col_SalesPrice] = Math.Floor(moveData.SalesUnitCost).ToString(formatFraction);// DEL BY 宋剛 2016/02/15 FOR Redmine#48629の#70の　販売単価などのカンマは必要ないので削除する
                    if ((int)moveData.SalesRate > 0)
                    {
                        row[ExportMoveDataItems.ct_Col_SalesPrice] = '0';
                    }
                    else
                    {
                        row[ExportMoveDataItems.ct_Col_SalesPrice] = Math.Floor(moveData.SalesUnitCost).ToString();// ADD BY 宋剛 2016/02/15 FOR Redmine#48629の#70の　販売単価などのカンマは必要ないので削除する
                    }
                    // 売価率
                    row[ExportMoveDataItems.ct_Col_SalesRate] = Math.Floor(moveData.SalesRate).ToString(formatFraction);
                    // ADD BY 宋剛 2016/02/15 FOR Redmine#48629の#64の　売価率と単価の整数出力対応 ----<<<<<

                    // 出庫拠点コード
                    row[ExportMoveDataItems.ct_Col_BfSectionCode] = moveData.BfSectionCode;
                    // 出庫拠点名
                    row[ExportMoveDataItems.ct_Col_BfSectionGuideSnm] = ConvertSpecialStr(moveData.BfSectionName);
                    // 出庫倉庫
                    row[ExportMoveDataItems.ct_Col_BfEnterWarehCode] = moveData.BfEnterWarehCode;
                    // 出庫倉庫名
                    row[ExportMoveDataItems.ct_Col_BfEnterWarehName] = ConvertSpecialStr(moveData.BfEnterWarehName);
                    // 入庫拠点コード
                    row[ExportMoveDataItems.ct_Col_AfSectionCod] = moveData.AfSectionCode;
                    // 入庫拠点名
                    row[ExportMoveDataItems.ct_Col_AfSectionGuideSnm] = ConvertSpecialStr(moveData.AfSectionName);
                    // 入庫倉庫
                    row[ExportMoveDataItems.ct_Col_AfEnterWarehCode] = moveData.AfEnterWarehCode;
                    // 入庫倉庫名
                    row[ExportMoveDataItems.ct_Col_AfEnterWarehName] = ConvertSpecialStr(moveData.AfEnterWarehName);
                    // 入荷予約日
                    if (moveData.ShipDate == DateTime.MinValue)
                    {
                        row[ExportMoveDataItems.ct_Col_StockArrivalDate] = DBNull.Value;
                    }
                    else
                    {
                        row[ExportMoveDataItems.ct_Col_StockArrivalDate] = moveData.ShipDate.AddDays(this.tNedit_ShDate.GetInt()).ToString(formatDate);
                    }

                    if (mode == 1)
                    {
                        // UPD BY 宋剛 2016/02/15 FOR Redmine#48629の障害一覧No.2の　販売単価と売価率の「未満」仕様変更対応 ---->>>>>
                        //// オープン価格区分が"0"、且つ売価率がUI項目"売価率下限値"以下である。
                        //if (moveData.OpenPriceDiv == 0 && moveData.SalesRate <= this.tNedit_SalesRate.GetInt())
                        // オープン価格区分が"0"、且つ売価率がUI項目"売価率下限値"未満である。
                        if (moveData.OpenPriceDiv == 0 && moveData.SalesRate < this.tNedit_SalesRate.GetInt())
                        // UPD BY 宋剛 2016/02/15 FOR Redmine#48629の障害一覧No.2の　販売単価と売価率の「未満」仕様変更対応 ----<<<<<
                        {
                            // 警告理由
                            row[ExportMoveDataItems.ct_Col_AlertReason] = string.Format(MessageInfo.M_018, this.tNedit_SalesRate.GetInt());
                        }
                        // UPD BY 宋剛 2016/02/15 FOR Redmine#48629の障害一覧No.2の　販売単価と売価率の「未満」仕様変更対応 ---->>>>>
                        //// オープン価格区分が"1"、且つ販売単価がUI項目"販売単価下限値"以下である。
                        //else if (moveData.OpenPriceDiv == 1 && moveData.SalesUnitCost <= this.tNedit_SalesPrice.GetInt())
                        // オープン価格区分が"1"、且つ販売単価がUI項目"販売単価下限値"未満である。
                        else if (moveData.OpenPriceDiv == 1 && moveData.SalesUnitCost < this.tNedit_SalesPrice.GetInt())
                        // UPD BY 宋剛 2016/02/15 FOR Redmine#48629の障害一覧No.2の　販売単価と売価率の「未満」仕様変更対応 ----<<<<<
                        {
                            // 警告理由
                            row[ExportMoveDataItems.ct_Col_AlertReason] = string.Format(MessageInfo.M_019, this.tNedit_SalesPrice.GetInt());

                        }
                        // UPD BY 宋剛 2016/02/15 FOR Redmine#48629の障害一覧No.2の　販売単価と売価率の「未満」仕様変更対応 ---->>>>>
                        //// オープン価格区分が"1"、且つ販売単価が1円以下である。
                        //else if (moveData.OpenPriceDiv == 1 && moveData.SalesUnitCost <= 1)
                        // オープン価格区分が"1"、且つ販売単価が1円未満である。
                        else if (moveData.OpenPriceDiv == 1 && moveData.SalesUnitCost < 1)
                        // UPD BY 宋剛 2016/02/15 FOR Redmine#48629の障害一覧No.2の　販売単価と売価率の「未満」仕様変更対応 ----<<<<<
                        {
                            // 警告理由
                            row[ExportMoveDataItems.ct_Col_AlertReason] = MessageInfo.M_020;
                        }
                        // 「売価率(double)の値 ≠ 売価率(int)の値」である。 (例：10.5 ≠ 10)
                        else if ((int)moveData.SalesRate != moveData.SalesRate)
                        {
                            // 警告理由
                            row[ExportMoveDataItems.ct_Col_AlertReason] = MessageInfo.M_034;
                        }
                        //「出荷数(double)の値 ≠ 出荷数(int)の値」である。 (例：10.5 ≠ 10)
                        else if ((int)moveData.ShipmentCount != moveData.ShipmentCount)
                        {
                            // 警告理由
                            row[ExportMoveDataItems.ct_Col_AlertReason] = MessageInfo.M_035;

                        }
                        // 出荷数(int) = 0の場合
                        else if ((int)moveData.ShipmentCount == 0)
                        {
                            // 警告理由
                            row[ExportMoveDataItems.ct_Col_AlertReason] = MessageInfo.M_036;

                        }
                        // ADD BY 宋剛 2016/02/19 FOR Redmine#48629の障害一覧No.237　チェック処理に名称にカンマとダブルクウォーテーションが含まれていないか判定処理追加 ---->>>>>
                        else if (isContainSpecalCharMain(moveData))
                        {
                            // 警告理由
                            row[ExportMoveDataItems.ct_Col_AlertReason] = MessageInfo.M_1042;

                        }
                        // ADD BY 宋剛 2016/02/19 FOR Redmine#48629の障害一覧No.237　チェック処理に名称にカンマとダブルクウォーテーションが含まれていないか判定処理追加 ----<<<<<
                        if (row[ExportMoveDataItems.ct_Col_AlertReason] != DBNull.Value)
                        {
                            this._exportDataSet.Tables[ExportMoveDataItems.ct_Tbl_ArrivalWarning].Rows.Add(row);
                        }
                    }
                    else
                    {
                        // オープン価格区分が"1"、且つ販売単価が1円以下である。
                        // 出荷数(int)が1以上である場合、出力しない
                        if (moveData.OpenPriceDiv == 1 && moveData.SalesUnitCost < 1 || (int)moveData.ShipmentCount < 1)
                        {
                            continue;
                        }

                        // ADD BY 宋剛 2016/02/19 FOR Redmine#48629の障害一覧No.237　チェック処理に名称にカンマとダブルクウォーテーションが含まれていないか判定処理追加 ---->>>>>
                        if (isContainSpecalCharMain(moveData))
                        {
                            continue;
                        }
                        // ADD BY 宋剛 2016/02/19 FOR Redmine#48629の障害一覧No.237　チェック処理に名称にカンマとダブルクウォーテーションが含まれていないか判定処理追加 ----<<<<<

                         this._exportDataSet.Tables[ExportMoveDataItems.ct_Tbl_Arrival].Rows.Add(row);
                    }

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
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2016/01/21</br>
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
        #endregion

        #region CSV出力処理
        /// <summary>
        /// CSV出力処理
        /// </summary>
        /// <param name="formattedTextWriter">出力Info</param>
        /// <param name="dataSource">出力データ</param>
        /// <param name="fileName">出力ファイル</param>
        /// <param name="mode">0:入荷予約一覧,1:入荷予約警告一覧</param>
        /// <param name="loopIndex">分割Index</param>
        /// <param name="errMessage">ｴﾗｰメッセージ</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : CSV出力処理を行う。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2016/01/21</br>
        /// </remarks>
        private int DoOutPut(ref FormattedTextWriter formattedTextWriter, DataView dataSource, string fileName, int mode, int loopIndex, out string errMessage)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            errMessage = string.Empty;
            List<string> schemeList = new List<string>();

            try
            {
                #region 移動データschemeList
                // 企業コード
                schemeList.Add(ExportMoveDataItems.ct_Col_EnterpriseCode);
                // >拠点コード
                schemeList.Add(ExportMoveDataItems.ct_Col_SectionCode);
                // 伝票日付
                schemeList.Add(ExportMoveDataItems.ct_Col_StockMoveDate);
                // 伝票番号
                schemeList.Add(ExportMoveDataItems.ct_Col_StockMoveSlipNo);
                // 行No
                schemeList.Add(ExportMoveDataItems.ct_Col_StockMoveRowNo);
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
                // 出荷数
                schemeList.Add(ExportMoveDataItems.ct_Col_ShipmentCount);
                // オープン価格区分
                schemeList.Add(ExportMoveDataItems.ct_Col_OpenPriceDiv);
                // 販売単価
                schemeList.Add(ExportMoveDataItems.ct_Col_SalesPrice);
                // 売価率
                schemeList.Add(ExportMoveDataItems.ct_Col_SalesRate);
                // 出庫拠点コード
                schemeList.Add(ExportMoveDataItems.ct_Col_BfSectionCode);
                // 出庫拠点名
                schemeList.Add(ExportMoveDataItems.ct_Col_BfSectionGuideSnm);
                // 出庫倉庫
                schemeList.Add(ExportMoveDataItems.ct_Col_BfEnterWarehCode);
                // 出庫倉庫名
                schemeList.Add(ExportMoveDataItems.ct_Col_BfEnterWarehName);
                // 入庫拠点コード
                schemeList.Add(ExportMoveDataItems.ct_Col_AfSectionCod);
                // 入庫拠点名
                schemeList.Add(ExportMoveDataItems.ct_Col_AfSectionGuideSnm);
                // 入庫倉庫
                schemeList.Add(ExportMoveDataItems.ct_Col_AfEnterWarehCode);
                // 入庫倉庫名
                schemeList.Add(ExportMoveDataItems.ct_Col_AfEnterWarehName);
                // 入荷予約日
                schemeList.Add(ExportMoveDataItems.ct_Col_StockArrivalDate);
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
                if (loopIndex == 0)
                {
                    formattedTextWriter.CaptionOutput = true;
                }
                else
                {
                    formattedTextWriter.CaptionOutput = false;
                }
                
                formattedTextWriter.FixedLength = false;
                formattedTextWriter.ReplaceList = null;
                formattedTextWriter.OutputMode = true;

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
        #endregion

        #region 画面イベント
        /// <summary>
        /// ChangeFocus イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : なし</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2016/01/21</br>
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
                case "tNedit_CustomerCode":
                    {
                        // 入力無し
                        if (tNedit_CustomerCode.GetInt() == 0)
                        {
                            this._preStockArrivalCondt.CustomerCode = 0;
                            this.tNedit_CustomerCode.DataText = string.Empty;
                            this.tEdit_CustomerName.Text = string.Empty;
                            break;
                        }

                        // 得意先コード取得
                        int customerCode = this.tNedit_CustomerCode.GetInt();
                        // 得意先名称取得
                        string customerName = GetCustomerName(customerCode);

                        if (!string.IsNullOrEmpty(customerName))
                        {
                            // 結果を画面に設定
                            this.tNedit_CustomerCode.SetInt(customerCode);
                            this.tEdit_CustomerName.Text = customerName;

                            // 設定値を保存
                            this._preStockArrivalCondt.CustomerCode = customerCode;
                        }
                        else
                        {
                            // 前回入力値を設定
                            string errorMsg = string.Format(MessageInfo.M_001, customerCode);
                            TMsgDisp.Show(this,                         // 親ウィンドウフォーム
                                emErrorLevel.ERR_LEVEL_INFO,            // エラーレベル
                                this.Name,							// アセンブリID
                                errorMsg,	                    // 表示するメッセージ
                                0,									    // ステータス値
                                MessageBoxButtons.OK);					// 表示するボタン
                            this.tNedit_CustomerCode.SetInt(this._preStockArrivalCondt.CustomerCode);
                            this.tNedit_CustomerCode.SelectAll();
                            isErrorMsgboxShow = true;
                            e.NextCtrl = e.PrevCtrl;

                            return;
                        }

                        if (e.NextCtrl != this.tNedit_CustomerCode)
                        {
                            if (e.Key == Keys.Tab || e.Key == Keys.Enter)
                            {
                                if (e.ShiftKey)
                                {
                                    e.NextCtrl = ultraCheckEditor;
                                }
                                else
                                {
                                    if (tNedit_CustomerCode.Text.Trim() != String.Empty)
                                        e.NextCtrl = TDateEdit_SlipDateSt;
                                    else
                                        e.NextCtrl = uButton_CustomerGuide;
                                }
                            }
                        }

                        break;
                    }
                // 更新日付（開始）
                case "TDateEdit_SlipDateSt":
                    {
                        // 入力無し
                        if (this.TDateEdit_SlipDateSt.GetDateYear() == 0 || this.TDateEdit_SlipDateSt.GetDateMonth() == 0 || this.TDateEdit_SlipDateSt.GetDateDay() == 0)
                        {
                            this.TDateEdit_SlipDateSt.Clear();
                            break;
                        }
                        if (e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        if (String.IsNullOrEmpty(this.tEdit_CustomerName.Text.Trim()))
                                        {
                                            e.NextCtrl = this.uButton_CustomerGuide;
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.tNedit_CustomerCode;
                                        }
                                    }
                                    break;
                            }
                        }
                        else
                        {
                            switch (e.Key)
                            {
                                case Keys.Down:
                                    {
                                        e.NextCtrl = this.AfSectionCode_tEdit; //入庫拠点コード
                                        break;
                                    }

                            }
                            break;
                        }
                        break;

                    }
                // 更新日付（終了）
                case "TDateEdit_SlipDateEd":
                    {
                        // 入力無し
                        if (this.TDateEdit_SlipDateEd.GetDateYear() == 0 || this.TDateEdit_SlipDateEd.GetDateMonth() == 0 || this.TDateEdit_SlipDateEd.GetDateDay() == 0)
                        {
                            this.TDateEdit_SlipDateEd.Clear();
                            break;
                        }
                        switch (e.Key)
                        {
                            case Keys.Down:
                                {
                                    e.NextCtrl = this.BfSectionCode_tEdit; // 出庫拠点
                                    break;
                                }
                        }
                        break;
                    }

                // 入庫拠点コード
                case "AfSectionCode_tEdit":
                    {
                        bool status = false;
                        string code = string.Empty;
                        string name = string.Empty;
                        string inputValue = this.AfSectionCode_tEdit.Text;
                        // 入力無し
                        if (AfSectionCode_tEdit.GetInt() == 0)
                        {
                            this._preStockArrivalCondt.AfSectionCode = string.Empty;
                            this.AfSectionCode_tEdit.DataText = string.Empty;
                            this.AfSectionName_tEdit.Text = string.Empty;
                            break;
                        }

                        status = ReadAfSectionCodeName(out code, out name);
                        if (status == true)
                        {
                            this.AfSectionCode_tEdit.Text = code;
                            this.AfSectionName_tEdit.Text = name;
                        }
                        else
                        {
                            string errorMsg = string.Format(MessageInfo.M_004, inputValue);
                            // エラー時
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                errorMsg,
                                -1,
                                MessageBoxButtons.OK);
                            isErrorMsgboxShow = true;
                            // コード戻す
                            this.AfSectionCode_tEdit.Text = code;
                            this.AfSectionCode_tEdit.SelectAll();
                            e.NextCtrl = e.PrevCtrl;
                        }
                        if (e.NextCtrl != this.AfSectionCode_tEdit)
                        {
                            if (e.Key == Keys.Tab || e.Key == Keys.Enter)
                            {
                                if (e.ShiftKey)
                                {
                                    e.NextCtrl = TDateEdit_SlipDateEd;
                                }
                                else
                                {
                                    if (AfSectionName_tEdit.Text.Trim() != String.Empty)
                                        e.NextCtrl = BfSectionCode_tEdit;
                                    else
                                        e.NextCtrl = AfSectionGuide_ultraButton;
                                }
                            }
                        }

                        break;
                    }

                // 出庫拠点コード
                case "BfSectionCode_tEdit":
                    {
                        bool status = false;
                        string code = string.Empty;
                        string name = string.Empty;
                        string inputValue = this.BfSectionCode_tEdit.Text;
                        // 入力無し
                        if (BfSectionCode_tEdit.GetInt() == 0)
                        {
                            this._preStockArrivalCondt.BfSectionCode = string.Empty;
                            this.BfSectionCode_tEdit.DataText = string.Empty;
                            this.BfSectionName_tEdit.Text = string.Empty;
                            break;
                        }

                        status = ReadBfSectionCodeName(out code, out name);
                        if (status == true)
                        {
                            this.BfSectionCode_tEdit.Text = code;
                            this.BfSectionName_tEdit.Text = name;
                        }
                        else
                        {
                            string errorMsg = string.Format(MessageInfo.M_005, inputValue);
                            // エラー時
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                errorMsg,
                                -1,
                                MessageBoxButtons.OK);
                            isErrorMsgboxShow = true;
                            // コード戻す
                            this.BfSectionCode_tEdit.Text = code;
                            this.BfSectionCode_tEdit.SelectAll();
                            e.NextCtrl = e.PrevCtrl;
                        }

                        if (e.NextCtrl != this.BfSectionCode_tEdit)
                        {
                            if (e.Key == Keys.Tab || e.Key == Keys.Enter)
                            {
                                if (e.ShiftKey)
                                {
                                    if (AfSectionName_tEdit.Text.Trim() != String.Empty)
                                        e.NextCtrl = AfSectionCode_tEdit;
                                    else
                                        e.NextCtrl = AfSectionGuide_ultraButton;
                                }
                                else
                                {
                                    if (BfSectionName_tEdit.Text.Trim() != String.Empty)
                                        e.NextCtrl = checkedListBox_AfWarehouse;
                                    else
                                        e.NextCtrl = BfSectionGuide_uButton;
                                }
                            }
                        }

                        break;
                    }
                // 入庫倉庫
                case "checkedListBox_AfWarehouse":
                    {
                        if (e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        if (String.IsNullOrEmpty(this.BfSectionName_tEdit.Text.Trim()))
                                        {
                                            e.NextCtrl = this.BfSectionGuide_uButton;
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.BfSectionCode_tEdit;
                                        }
                                    }
                                    break;
                            }
                        }
                        break;
                    }
                // 出庫倉庫
                case "checkedListBox_BfWarehouse":
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        e.NextCtrl = this.tNedit_ShDate;
                                    }
                                    break;
                            }
                        }
                        break;
                    }
                // 発送日数
                case "tNedit_ShDate":
                    {
                        bool numFlag = false;
                        int changeNum;
                        numFlag = Int32.TryParse(this.tNedit_ShDate.Text.Trim(), out changeNum);
                        // 数字の場合
                        if (numFlag)
                        {
                            // マイナス数字の場合
                            if (changeNum < 0)
                            {
                                this.tNedit_ShDate.SetInt(this._preStockArrivalCondt.SalesOrderCount);
                            }
                            else if (changeNum > 10)
                            {
                                if (string.IsNullOrEmpty(this.tNedit_ShDate.Text.Trim()))
                                {
                                    this.tNedit_ShDate.DataText = string.Empty;
                                    this._preStockArrivalCondt.SalesOrderCount = 0;
                                }
                                else
                                {
                                    this.tNedit_ShDate.SetInt(this._preStockArrivalCondt.SalesOrderCount);
                                }
                            }
                            // 正常な数字の場合
                            else
                            {
                                this.tNedit_ShDate.SetInt(changeNum);
                                this._preStockArrivalCondt.SalesOrderCount = changeNum;
                            }
                        }
                        // 文字と空白の場合
                        else
                        {
                            if (string.IsNullOrEmpty(this.tNedit_ShDate.Text.Trim()))
                            {
                                this.tNedit_ShDate.DataText = string.Empty;
                                this._preStockArrivalCondt.SalesOrderCount = 0;
                            }
                            else
                            {
                                this.tNedit_ShDate.SetInt(this._preStockArrivalCondt.SalesOrderCount);
                            }
                        }
                        if (e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        e.NextCtrl = this.checkedListBox_BfWarehouse;
                                    }
                                    break;
                            }
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
        /// GroupCollapsing イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note        : UltraExplorerBarGroup が縮小される前に発生します。</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2016/01/21</br>
        /// </remarks>
        private void ultraExplorerBar1_GroupCollapsing(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
        {
            if ((e.Group.Key == "ExResult") ||
                (e.Group.Key == "SearchCond") ||
                (e.Group.Key == "ExportCont"))
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
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2016/01/21</br>
        /// </remarks>
        private void ultraExplorerBar1_GroupExpanding(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
        {
            if ((e.Group.Key == "ExResult") ||
                (e.Group.Key == "SearchCond") ||
                (e.Group.Key == "ExportCont"))
            {
                // グループの縮小をキャンセル
                e.Cancel = true;
            }
        }

        /// <summary>
        /// 得意先ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks> 
        /// <br>Note       : 得意先ガイドをクリックするときに発生する</br> 
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2016/01/21</br>
        /// </remarks>
        private void uButton_CustomerGuide_Click(object sender, EventArgs e)
        {
            PMKHN04005UA customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_NORMAL, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY);
            customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.customerSearchForm_CustomerSelect);
            customerSearchForm.ShowDialog(this);

            Control nextControl = null;
            nextControl = this.TDateEdit_SlipDateSt;
            // フォーカス
            nextControl.Focus();

        }

        /// <summary>
        /// 得意先ガイド選択イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="customerSearchRet">customerSearchRet</param>
        /// <remarks> 
        /// <br>Note       : 得意先ガイドをクリックするときに発生する</br> 
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2016/01/21</br>
        /// <br>UpdateNote : 宋剛 2016/02/15</br>
        /// <br>           : Redmine#48629のNo.10　得意先マスタ.略称対応</br>
        /// </remarks>
        private void customerSearchForm_CustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        {
            if (customerSearchRet == null) return;

            // ガイド起動
            this.tNedit_CustomerCode.SetInt(customerSearchRet.CustomerCode);
            // UPD BY 宋剛 2016/02/15 FOR Redmine#48629のNo.10　得意先マスタ.略称対応 ---->>>>>
            //this.tEdit_CustomerName.Text = customerSearchRet.Name;
            this.tEdit_CustomerName.Text = customerSearchRet.Snm;
            // UPD BY 宋剛 2016/02/15 FOR Redmine#48629のNo.10　得意先マスタ.略称対応 ----<<<<<
            // 設定値を保存
            this._preStockArrivalCondt.CustomerCode = this.tNedit_CustomerCode.GetInt();
            this._preCustomerName = this.tEdit_CustomerName.Text;

        }

        /// <summary>
        /// 入庫拠点ガイドボタン
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note        : 入庫拠点ガイドボタンクリックイベント</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2016/01/21</br>
        /// </remarks>
        private void AfSectionGuide_ultraButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                SecInfoSet secInfoSet;
                int status = _secInfoSetAcs.ExecuteGuid(LoginInfoAcquisition.EnterpriseCode, false, out secInfoSet);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // 結果セット
                    this.AfSectionCode_tEdit.Text = secInfoSet.SectionCode.TrimEnd();
                    this.AfSectionName_tEdit.Text = secInfoSet.SectionGuideNm.TrimEnd();

                    // 次フォーカス
                    this.BfSectionCode_tEdit.Focus();
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// 出庫拠点ガイドボタン
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note        : 出庫拠点ガイドボタンクリックイベント</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2016/01/21</br>
        /// </remarks>
        private void BfSectionGuide_uButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                SecInfoSet secInfoSet;
                int status = _secInfoSetAcs.ExecuteGuid(LoginInfoAcquisition.EnterpriseCode, false, out secInfoSet);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // 結果セット
                    this.BfSectionCode_tEdit.Text = secInfoSet.SectionCode.TrimEnd();
                    this.BfSectionName_tEdit.Text = secInfoSet.SectionGuideNm.TrimEnd();

                    // 次フォーカス
                    this.BfSectionCode_tEdit.Focus();
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// チェックリストボックスフォーカスEnter時、選択
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : チェックリストボックスフォーカスEnter時、選択</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2016/01/21</br>
        /// </remarks>
        private void checkedListBox_AfWarehouse_Enter(object sender, EventArgs e)
        {
            if (this.checkedListBox_AfWarehouse.Items.Count != 0)
            {
                if (sender is ListBox)
                {
                    // 選択状態
                    ((ListBox)sender).SetSelected(0, true);
                }
            }
        }

        /// <summary>
        /// チェックリストボックスフォーカスLeave時、選択解除
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : チェックリストボックスフォーカスLeave時、選択解除</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2016/01/21</br>
        /// </remarks>
        private void checkedListBox_AfWarehouse_Leave(object sender, EventArgs e)
        {
            if (this.checkedListBox_AfWarehouse.Items.Count != 0)
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
        }

        /// <summary>
        /// チェックリストボックスフォーカスLeave時、選択解除
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : チェックリストボックスフォーカスLeave時、選択解除</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2016/01/21</br>
        /// </remarks>
        private void checkedListBox_BfWarehouse_Leave(object sender, EventArgs e)
        {
            if (this.checkedListBox_BfWarehouse.Items.Count != 0)
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
        }

        /// <summary>
        /// チェックリストボックスフォーカスEnter時、選択
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : チェックリストボックスフォーカスEnter時、選択</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2016/01/21</br>
        /// </remarks>
        private void checkedListBox_BfWarehouse_Enter(object sender, EventArgs e)
        {
            if (this.checkedListBox_BfWarehouse.Items.Count != 0)
            {
                if (sender is ListBox)
                {
                    // 選択状態
                    ((ListBox)sender).SetSelected(0, true);
                }
            }  
        }

        /// <summary>
        /// 売価率Enter
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note        : 売価率Enterイベント</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2016/01/21</br>
        /// </remarks>
        private void tNedit_SalesRate_Enter(object sender, EventArgs e)
        {
            this._salesRateStr = this.tNedit_SalesRate.Text.Trim();
        }

        /// <summary>
        /// 販売単価Enter
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note        : 販売単価Enterイベント</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2016/01/21</br>
        /// </remarks>
        private void tNedit_SalesPrice_Enter(object sender, EventArgs e)
        {
            this._salesPriceStr = this.tNedit_SalesPrice.Text.Trim();
        }

        /// <summary>
        /// 得意先名称取得処理
        /// </summary>
        /// <param name="customerCode">得意先コード</param>
        /// <returns>得意先名称</returns>
        /// <remarks>
        /// <br>Note       : 得意先名称を取得します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2016/01/21</br>
        /// <br>UpdateNote : 宋剛 2016/02/15</br>
        /// <br>           : Redmine#48629のNo.10　得意先マスタ.略称対応</br>
        /// </remarks>
        private string GetCustomerName(int customerCode)
        {
            string str = "";
            LoadCustomerSearchRet(false);
            try
            {
                if (this._customerSearchRetDic.ContainsKey(customerCode))
                {
                    // UPD BY 宋剛 2016/02/15 FOR Redmine#48629のNo.10　得意先マスタ.略称対応 ---->>>>>
                    // str = this._customerSearchRetDic[customerCode].Name.Trim();
                    str = this._customerSearchRetDic[customerCode].Snm.Trim(); // 略称
                    // UPD BY 宋剛 2016/02/15 FOR Redmine#48629のNo.10　得意先マスタ.略称対応 ----<<<<<
                }
            }
            catch
            {
                str = "";
            }
            return str;

        }

        /// <summary>
        /// 得意先マスタ読込処理
        /// </summary>
        /// <remarks>
        /// <param name="flg">flg</param>
        /// <br>Note       : 得意先マスタ読込処理を行う。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2016/01/21</br>
        /// </remarks>
        private void LoadCustomerSearchRet(bool flg)
        {
            if (flg == false && _customerSearchRetDic != null)
            {
                return;
            }

            this._customerSearchRetDic = new Dictionary<int, CustomerSearchRet>();
            try
            {
                CustomerSearchRet[] retArray;
                CustomerSearchPara paraRec = new CustomerSearchPara();
                paraRec.EnterpriseCode = this._enterpriseCode;


                // 得意先マスタ情報検索
                if (_customerSearchAcs.Serch(out retArray, paraRec) == 0)
                {
                    foreach (CustomerSearchRet ret in retArray)
                    {
                        if (ret.LogicalDeleteCode == 0)
                        {
                            // 保存得意先マスタ情報
                            this._customerSearchRetDic.Add(ret.CustomerCode, ret);
                        }
                    }
                }
            }
            catch
            {
                this._customerSearchRetDic = new Dictionary<int, CustomerSearchRet>();
            }
        }

        /// <summary>
        /// 拠点名称取得処理
        /// </summary>
        /// <param name="code">拠点コード</param>
        /// <param name="name">拠点名称</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note        : 拠点名称取得処理</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2016/01/21</br>
        /// </remarks>
        private bool ReadAfSectionCodeName(out string code, out string name)
        {
            // 入力値を取得
            string sectionCode = this.AfSectionCode_tEdit.Text.Trim().PadLeft(2, '0');
            code = sectionCode;
            name = AfSectionName_tEdit.Text;


            if (!String.IsNullOrEmpty(sectionCode.Trim()))
            {
                // 拠点情報を取得
                SecInfoSet sectionInfo;
                int status = this._secInfoSetAcs.Read(out sectionInfo, this._enterpriseCode, sectionCode);

                // ステータスが正常の場合はUIにセット
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && sectionInfo.LogicalDeleteCode == 0)
                {

                    code = sectionInfo.SectionCode.TrimEnd();
                    name = sectionInfo.SectionGuideNm.TrimEnd();
                    this._preStockArrivalCondt.AfSectionCode = code;
                    this._preStockArrivalCondt.AfSectionName = name;
                    return true;
                }
                else
                {
                    code = this._preStockArrivalCondt.AfSectionCode;
                    name = this._preStockArrivalCondt.AfSectionName;
                    return false;
                }
            }
            else
            {
                code = string.Empty;
                name = string.Empty;
                this._preStockArrivalCondt.AfSectionCode = code;
                this._preStockArrivalCondt.AfSectionName = name;
                return true;
            }
        }

        /// <summary>
        /// 拠点名称取得処理
        /// </summary>
        /// <param name="code">拠点コード</param>
        /// <param name="name">拠点名称</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note        : 拠点名称取得処理</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2016/01/21</br>
        /// </remarks>
        private bool ReadBfSectionCodeName(out string code, out string name)
        {
            // 入力値を取得
            string sectionCode = this.BfSectionCode_tEdit.Text.Trim().PadLeft(2, '0');
            code = sectionCode;
            name = BfSectionName_tEdit.Text;


            if (!String.IsNullOrEmpty(sectionCode.Trim()))
            {
                // 拠点情報を取得
                SecInfoSet sectionInfo;
                int status = this._secInfoSetAcs.Read(out sectionInfo, this._enterpriseCode, sectionCode);

                // ステータスが正常の場合はUIにセット
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && sectionInfo.LogicalDeleteCode == 0)
                {

                    code = sectionInfo.SectionCode.TrimEnd();
                    name = sectionInfo.SectionGuideNm.TrimEnd();
                    this._preStockArrivalCondt.BfSectionCode = code;
                    this._preStockArrivalCondt.BfSectionName = name;
                    return true;
                }
                else
                {
                    code = this._preStockArrivalCondt.BfSectionCode;
                    name = this._preStockArrivalCondt.BfSectionName;
                    return false;
                }
            }
            else
            {
                code = string.Empty;
                name = string.Empty;
                this._preStockArrivalCondt.BfSectionCode = code;
                this._preStockArrivalCondt.BfSectionName = name;
                return true;
            }
        }
        #endregion

        #region 実行状況ログ処理
        /// <summary>
        /// 実行状況ログ処理
        /// </summary>
        /// <param name="msg">実行結果メッセージ</param>
        /// <param name="msgRun">実行状況ログメッセージ</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note        : 実行状況ログ処理</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2016/01/21</br>
        /// </remarks>
        private void ShowResult(string msg, string msgRun)
        {
            DateTime dt = DateTime.Now;

            if (!string.IsNullOrEmpty(msg))
            {
                this.textBox1.Text += dt.ToString("HH:mm ") + msg + Environment.NewLine;
                this.textBox1.SelectionStart = this.textBox1.TextLength;
                this.textBox1.ScrollToCaret();
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
        #endregion

        #region 残り予測時間計算処理

        /// <summary>
        /// Timer実行処理
        /// </summary>
        /// <param name="obj">対象オブジェクト</param>
        /// <remarks>
        /// <br>Note        : Timer実行処理</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2016/01/21</br>
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
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2016/01/21</br>
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
        /// <remarks>
        /// <br>Note        :  UIの残り時間を更新する</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2016/01/21</br>
        /// </remarks>
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
            this.Refresh();
            this.Update();
            this.Invalidate();
            System.Windows.Forms.Application.DoEvents();
        }
        #endregion
        #endregion

        // ===================================================================================== //
        // ｴﾗｰ再取込処理
        // ===================================================================================== //
        # region ｴﾗｰ再取込
        /// <summary>
        /// ｴﾗｰ再取込処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : ｴﾗｰ再取込処理を行う。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2016/01/21</br>
        /// <br>UpdateNote : 宋剛 2016/02/19</br>
        /// <br>           : Redmine#48629の障害一覧No.241　エラー再取込実行時にエラーが表示される障害対応</br>
        /// <br>UpdateNote : 宋剛 2016/02/23</br>
        /// <br>           : LDNS発生した障害　取込むファイルのサイズは0の場合、実行状況のメッセージを出力しない</br>
        /// </remarks>
        public int ErrReRead()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            string errFileName = string.Empty;
            string errMessage = string.Empty;
            if (tNedit_CustomerCode.Focused)
            {
                _prevControl = this.tNedit_CustomerCode;
            }
            // 入力値検査
            if (this._prevControl != null)
            {
                ChangeFocusEventArgs e = new ChangeFocusEventArgs(false, false, false, Keys.Return, this._prevControl, this._prevControl);
                this.tRetKeyControl1_ChangeFocus(this, e);
                if (isErrorMsgboxShow)
                {
                    isErrorMsgboxShow = false;
                    this.ShowResult(MessageInfo.M_015, ct_RUN_MESSAGE04);
                    this.ultraLabel_time.Text = string.Empty;
                    this._prevControl.Focus();
                    return status;
                }
            }

            // ---------- ADD 2016/02/24 Y.Wakita ① ---------->>>>>
            // ③	部品MAXログインID、部品MAXパスワードが入力されているかを確認する。
            status = this.ReadUserSetting();
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                return status;
            }
            // ---------- ADD 2016/02/24 Y.Wakita ① ----------<<<<<

            // 実行準備
            this.ShowResult(MessageInfo.M_037, ct_RUN_MESSAGE01);

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
                this.ShowResult(string.Format(MessageInfo.M_033, status, errMessage), ct_RUN_MESSAGE04);
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
                this.ShowResult(MessageInfo.M_024, ct_RUN_MESSAGE02);
                // UPD BY 宋剛 2016/02/23 FOR LDNS発生した障害　取込むファイルのサイズは0の場合、実行状況のメッセージを出力しない ----<<<<<
                return status;

            }
            if (runVelocity != 0 && (rows - 1) >= 0)
            {
                this._restTime = (int)(runVelocity * (rows-1)); // UIの残り予測時間
                this._forecastTime = this._restTime; // 規定予測処理時間   
            }
            // Timerを作成
            this._restTimer = new System.Threading.Timer(new TimerCallback(TimerCall), null, 0, 1000);

            // 入荷予約処理呼出
            this.UpLoadFile(out errMessage, errFileName);

            return status;
        }

        /// <summary>
        /// ファイルを開く
        /// </summary>
        /// <param name="errFileName">ファイル名</param>
        /// <remarks>
        /// <br>Note        : ファイルを開く。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2016/01/21</br>
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
                    openFileDialog.InitialDirectory = System.IO.Path.GetDirectoryName(this._filePath + Path.DirectorySeparatorChar);
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
        /// ファイルの件数取得
        /// </summary>
        /// <param name="errFileName">取り込むエラーCSVファイル</param>
        /// <remarks>
        /// <br>Note       : ファイルの件数取得を行う。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2016/01/21</br>
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
            // 部品MAXログインID、部品MAXパスワードが入力されているかを確認する
            // ユーザー情報
            string userID;
            string userPassWd;
            bool userExistFlag = false;

            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            // DATファイルから、ユーザー情報を取得する
            _pMMAX02000UC.ReadDatFile(PMMAX02000UC.ct_Tbl_Users, this._enterpriseCode, this._loginSectionCode, out userID, out userPassWd, out userExistFlag);
            // 該当するユーザーを設定した場合
            if (string.IsNullOrEmpty(userID) || string.IsNullOrEmpty(userPassWd))
            {
                // 部品MAX認証入力画面
                this._pmmax02000UE.DisplayMessage = MessageInfo.M_044;
                this._pmmax02000UE.InitialScreenData();
                DialogResult ret = this._pmmax02000UE.ShowDialog();
                // 保存ボタン押下時
                if (ret == DialogResult.Yes)
                {
                    // 部品MAXログインID
                    this._loginId = this._pmmax02000UE.UserID;
                    // 部品MAXパスワード
                    this._password = this._pmmax02000UE.UserPassWord;
                }
                else
                {
                    // 中止ボタン押下時
                    this.ShowResult(MessageInfo.M_016, ct_RUN_MESSAGE02);
                    this.ultraLabel_time.Text = string.Empty;
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    return status;
                }
            }
            else
            {
                // 部品MAXログインID
                this._loginId = userID;
                // 部品MAXパスワード
                this._password = userPassWd;
            }

            return status;
        }
        // ---------- ADD 2016/02/24 Y.Wakita ① ----------<<<<<
        #endregion

    }
}