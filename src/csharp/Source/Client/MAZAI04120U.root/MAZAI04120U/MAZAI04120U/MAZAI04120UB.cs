//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : 在庫移動入力
// プログラム概要   : 在庫移動入力のグリッド側画面のクラスです。
//----------------------------------------------------------------------------//
//                (c)Copyright  2007 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 20008 伊藤 豊
// 作 成 日  2007/04/24  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 22018 鈴木 正臣
// 修 正 日  2007/09/05  修正内容 : 流通.NS用に項目変更
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30414 忍 幸史
// 修 正 日  2008/07/14  修正内容 : Partsman用に変更
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2009/06/04  修正内容 : 不具合対応[13200]
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2009/06/29  修正内容 : 不具合対応[13659]
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 佐々木 健
// 修 正 日  2009.07.07  修正内容 : MANTIS対応[0013690]
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 22018 鈴木 正臣
// 修 正 日  2010/04/15  修正内容 : MANTIS対応[0015286] 品名カナ印字対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 曹文傑
// 修 正 日  2010/11/15  修正内容 : 障害改良対応「５，６，７」の対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : tianjw
// 修 正 日  2010/11/25  修正内容 : 障害報告 #17589
//----------------------------------------------------------------------------//
// 管理番号  10700008-00 作成担当 : 鄧潘ハン
// 修 正 日  2011/04/11  修正内容 : 障害改良対応(4月)
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 朱俊成
// 修 正 日  2011/05/10  修正内容 : Redmine#20837、Redmine#20879
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : tianjw
// 修 正 日  2011/05/10  修正内容 : redmine #20881
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : zhujc
// 修 正 日  2011/05/16  修正内容 : redmine #20881 出荷日を変更時、合計移動金額を再計算
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : zhujc
// 修 正 日  2011/05/20  修正内容 : Redmine #21632、Redmine#21636、Redmine#21642
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : zhujc
// 修 正 日  2011/05/26  修正内容 : Redmine #21733
//----------------------------------------------------------------------------//
// 管理番号  10704766-00 作成担当 : 譚洪
// 修 正 日  2011/07/25  修正内容 : 連番No.16 掛率設定に関して、00全社共通 と 拠点の掛率の優先順位の同等化（WAN運用）の対応
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : wangf
// 修 正 日  2012/05/22  修正内容 : 06/27配信分、Redmine#29881 在庫移動入力抽出条件に日付を指定しても反映されないの対応
//----------------------------------------------------------------------------//
// 管理番号  10904597-00 作成担当 : 宮本 利明
// 修 正 日  2014/04/09  修正内容 : 仕掛一覧 №2358　入庫前数・入庫後数を追加
//----------------------------------------------------------------------------//
// 管理番号  10904597-00 作成担当 : 宮本 利明
// 修 正 日  2014/04/16  修正内容 : 入庫前・入庫後数表示対応 システムテスト障害一覧_先行配信分 №73,75,76
//----------------------------------------------------------------------------//
// 管理番号  10904597-00 作成担当 : 宮本 利明
// 修 正 日  2014/04/17  修正内容 : 出庫倉庫が存在しない場合に入庫前後数が表示されない障害を修正
//----------------------------------------------------------------------------//
// 管理番号  10904597-00 作成担当 : 宮本 利明
// 修 正 日  2014/04/21  修正内容 : 明細行選択状態でTABキー押下時にエラーとなる障害を修正
//----------------------------------------------------------------------------//
// 管理番号  11070071-00 作成担当 : 宮本 利明
// 修 正 日  2014/05/09  修正内容 : 入庫前数の算出方法を出庫前数に合わせる
//----------------------------------------------------------------------------//
// 管理番号  11070071-00 作成担当 : 宮本 利明
// 修 正 日  2014/05/13  修正内容 : 出庫前数と入庫前数の算出方法を入荷処理の入庫前数に合わせる(出荷可能数)
//----------------------------------------------------------------------------//
// 管理番号  11601223-00 作成担当 : 陳艶丹
// 修 正 日  2021/10/08  修正内容 : BLINCIDENT-3114 小文字品番の在庫情報取得不具合の対応
//----------------------------------------------------------------------------//
// 管理番号  11800082-00 作成担当 : 陳艶丹
// 修 正 日  2022/01/20  修正内容 : BLINCIDENT-3254 再度同一品番選択画面が表示される対応
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;
using Infragistics.Win.UltraWinToolbars;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Resources;
using System.IO;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 移動在庫入力グリッド画面クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 移動在庫入力のグリッド側画面のクラスです。</br>
    /// <br>Programmer : 20008 伊藤 豊</br>
    /// <br>Date       : 2007.04.24</br>
    /// <br>----------------------------------------------------</br>
    /// <br>Note       : 流通.NS用に項目変更</br>
    /// <br>Programmer : 22018 鈴木 正臣</br>
    /// <br>Date       : 2007.09.05</br>
    /// <br>----------------------------------------------------</br>
    /// <br>Note       : Partsman用に変更</br>
    /// <br>Programmer : 30414 忍 幸史</br>
    /// <br>Date       : 2008/07/14</br>
    /// <br>----------------------------------------------------</br>
    /// <br>Note       : 不具合対応[13200]</br>
    /// <br>Programmer : 照田 貴志</br>
    /// <br>Date       : 2009/06/04</br>
    /// <br>----------------------------------------------------</br>
    /// <br>Note       : 不具合対応[13659]</br>
    /// <br>Programmer : 照田 貴志</br>
    /// <br>Date       : 2009/06/29</br>
    /// <br>----------------------------------------------------</br>
    /// <br>Note       : MANTIS対応[0013690]</br>
    /// <br>Programmer : 佐々木 健</br>
    /// <br>Date       : 2009.07.07</br>
    /// <br>----------------------------------------------------</br>
    /// <br>Note       : MANTIS対応[0015286]</br>
    /// <br>Programmer : 鈴木 正臣</br>
    /// <br>Date       : 2010/04/15</br>
    /// <br>----------------------------------------------------</br>
    /// <br>Note       : 障害改良対応「５，６，７」の対応</br>
    /// <br>Programmer : 曹文傑</br>
    /// <br>Date       : 2010/11/15</br>
    /// <br>----------------------------------------------------</br>
    /// <br>Note       : 障害報告 #17589</br>
    /// <br>Programmer : tianjw</br>
    /// <br>Date       : 2010/11/25</br>
    /// <br>----------------------------------------------------</br>
    /// <br>Note       : ①明細に仕入先を追加する。②定価取得時の不具合修正。</br>
    /// <br>Programmer : 鄧潘ハン</br>
    /// <br>Date       : 2011/04/11</br>
    /// <br>----------------------------------------------------</br>
    /// <br>Note       : redmine #20881</br>
    /// <br>Programmer : tianjw</br>
    /// <br>Date       : 2011/05/10</br>
    /// <br>Update Note: 2011/07/25 譚洪 連番No.16 掛率設定に関して、00全社共通 と 拠点の掛率の優先順位の同等化（WAN運用）の対応</br>
    /// <br>Update Note: 2021/10/08 陳艶丹</br>
    /// <br>管理番号   : 11601223-00</br>
    /// <br>           : BLINCIDENT-3114 小文字品番の在庫情報取得不具合の対応</br> 
    /// <br>Update Note: 2022/01/20 陳艶丹</br>
    /// <br>管理番号   : 11800082-00</br>
    /// <br>           : BLINCIDENT-3254 再度同一品番選択画面が表示される対応</br> 
    /// </remarks>
    public partial class MAZAI04120UB : UserControl
    {
        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public MAZAI04120UB()
        {
            InitializeComponent();

            // スキンインスタンスの生成
            _controlScreenSkin = new ControlScreenSkin();

            //this._rowDeleteButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager.Tools["ButtonTool_RowDelete"];

            this._imageList16 = IconResourceManagement.ImageList16;
            this._guideButtonImage = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];

            this._stockMoveInputAcs = StockMoveInputAcs.GetInstance();
            this._stockMoveInputInitAcs = StockMoveInputInitDataAcs.GetInstance();
            this._stockMoveHeader = _stockMoveInputInitAcs.StockMoveHeader;

            this._stockMoveDataTable = _stockMoveInputAcs.StockMoveDataTable;
            
            // --- ADD 2008/07/14 --------------------------------------------------------------------->>>>>
            this._goodsAcs = new GoodsAcs();
            string errMsg;
            this._goodsAcs.SearchInitial(LoginInfoAcquisition.EnterpriseCode, LoginInfoAcquisition.Employee.BelongSectionCode, out errMsg);

            this._keyList = new Dictionary<int, string>();

            this._stockProcMoneyAcs = new StockProcMoneyAcs();
            this._taxRateSetAcs = new TaxRateSetAcs();
            this._unitPriceCalculation = new UnitPriceCalculation();

            ReadInitData();         // 単価算出クラス初期データ読込
            ReadTaxRate();          // 税率設定マスタ読込
            // --- ADD 2008/07/14 ---------------------------------------------------------------------<<<<<
            
            // 在庫移動明細データテーブル列表示設定 クラスセッティング処理
            this.SettingStockMoveDetailRowVisibleControl();
        }

        /// <summary>画面デザイン変更クラス</summary>
        private ControlScreenSkin _controlScreenSkin;
        private int _index = -1; // ADD 2011/05/10
        private string _key = ""; // ADD 2011/05/10
        private ImageList _imageList16 = null;
        public int oldsupplierCd = -1; // ADD 2011/04/11
        private Image _guideButtonImage;

        private StockMoveInputAcs _stockMoveInputAcs;
        private StockMoveInputInitDataAcs _stockMoveInputInitAcs;
        private StockMoveHeader _stockMoveHeader;
        private StockMoveInputDataSet.StockMoveDataTable _stockMoveDataTable;
        // --- ADD 2011/05/10 --------------------------------------------------------------------->>>>>
        private Boolean _sameGoodNoFlg = false;
        // --- ADD 2011/05/10 ---------------------------------------------------------------------<<<<<

        // --- ADD 2008/07/14 --------------------------------------------------------------------->>>>>
        private GoodsAcs _goodsAcs;
        private bool _movingSupliStockFlg;
        private bool _warehouseFocusFlg;
        private string _warehouseName;
        private bool _logicalDeleteFlg;
        private bool _closeFlg;
        private bool _deleteFlg;
        private bool _saveFlg;

        private Dictionary<int, string> _keyList;

        // フォーカス設定イベント
        internal event SetFocusEventHandler setFocus;
        internal delegate void SetFocusEventHandler(string controlName);

        // 品番列アクティブ時イベント
        internal event EnterGoodsNoColumnEventHandler enterGoodsNoColumn;
        internal delegate void EnterGoodsNoColumnEventHandler(Boolean goodsNoFlg);

        // 伝票番号取得イベント
        internal event GetSlipNoEventHandler getSlipNo;
        internal delegate string GetSlipNoEventHandler();

        // 出荷日取得イベント
        internal event GetSlipmentDayEventHandler getSlipmentDay;
        internal delegate DateTime GetSlipmentDayEventHandler();

        private StockProcMoneyAcs _stockProcMoneyAcs;   // 単価算出クラスアクセスクラス
        private TaxRateSetAcs _taxRateSetAcs;           // 税率設定マスタアクセスクラス
        private TaxRateSet _taxRateSet;
        private UnitPriceCalculation _unitPriceCalculation;
        // --- ADD 2008/07/14 ---------------------------------------------------------------------<<<<<

        // 合計金額設定イベント
        internal event SettingTotalPriceEventHandler TotalPriceSetting;
        internal delegate void SettingTotalPriceEventHandler();

        // ヘッダ、フッタ情報格納イベント
        internal event SetStockMoveHeaderEventHandler SetStockMoveHeader;
        internal delegate void SetStockMoveHeaderEventHandler();

        /* --- DEL 2008/07/14 --------------------------------------------------------------------->>>>>
        private double updateSupliRemainCount;
        private double updateTrustRemainCount;

        private double updateMovingSupliStock;
        private double updateMovingTrustStock;
           --- DEL 2008/07/14 ---------------------------------------------------------------------<<<<<*/

        // 伝票呼出後更新されたかどうかのフラグ
        private Boolean tableUpdateFlg = false;

        private StockMoveDetailRowVisibleControl _stockMoveDetailRowVisibleControl = new StockMoveDetailRowVisibleControl();

        /* --- DEL 2008/07/14 --------------------------------------------------------------------->>>>>
        // 商品番号検索エラー
        private bool _errGoodsNo;

        // 出荷数のエラー
        private bool _errMoveCount;
           --- DEL 2008/07/14 ---------------------------------------------------------------------<<<<<*/

        // --- ADD m.suzuki 2010/04/15 ---------->>>>>
        // 品名退避用
        private string _beforeGoodsName;
        // --- ADD m.suzuki 2010/04/15 ----------<<<<<

        //private Infragistics.Win.UltraWinToolbars.ButtonTool _rowDeleteButto
        private static readonly Color DISABLE_COLOR = Color.Gainsboro;
        private static readonly Color DISABLE_FONT_COLOR = Color.Black;
        private static readonly Color READONLY_COLOR = Color.WhiteSmoke;
        private static readonly Color ROWSTATUS_COPY_COLOR = Color.Pink;
        private static readonly Color ROWSTATUS_CUT_COLOR = Color.Gray;
        private static readonly Color REDUCTION_FONT_COLOR = Color.Green;
        private static readonly Color READONLY_CELL_COLOR = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(220)))));
        internal static readonly string ITEM_NAME_CUSTOMERCODE = "CustomerCode";

        //--- ADD 陳艶丹 2021/10/08 BLINCIDENT-3114 小文字品番の在庫情報取得不具合の対応 ----->>>>>
        private const string StrResearchErrMsg = "商品検索でエラーが発生しました。\n\r商品を再度入力してください。";
        //--- ADD 陳艶丹 2021/10/08 BLINCIDENT-3114 小文字品番の在庫情報取得不具合の対応 -----<<<<<
        // --- ADD 陳艶丹 2022/01/20 BLINCIDENT-3254 再度同一品番選択画面が表示される対応 ----->>>>>
        // アスタリスク
        private const string CTASTER = "*";
        // ハイフン
        private const string CTHYPHEN = "-";
        // --- ADD 陳艶丹 2022/01/20 BLINCIDENT-3254 再度同一品番選択画面が表示される対応 -----<<<<<

        // ===================================================================================== //
        // デリゲート
        // ===================================================================================== //
        # region Delegate
        /// <summary>
        /// ステータスバーメッセージ表示デリゲート
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="message">表示メッセージ</param>
        internal delegate void SettingStatusBarMessageEventHandler(object sender, string message);

        /* --- DEL 2008/07/14 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// フォーカス設定デリゲート
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="itemName">項目名称</param>
        internal delegate void SettingFocusEventHandler(object sender, string itemName);
           --- DEL 2008/07/14 ---------------------------------------------------------------------<<<<<*/
        # endregion

        /* --- DEL 2008/07/14 --------------------------------------------------------------------->>>>>
        // ===================================================================================== //
        // イベント
        // ===================================================================================== //
        # region Event
        /// <summary>グリッド最上位行キーダウンイベント</summary>
        internal event EventHandler GridKeyDownTopRow;

        /// <summary>グリッド最下層行キーダウンイベント</summary>
        internal event EventHandler GridKeyDownButtomRow;

        /// <summary>フォーカス設定イベント</summary>
        internal event SettingFocusEventHandler FocusSetting;

        # endregion
           --- DEL 2008/07/14 ---------------------------------------------------------------------<<<<<*/

        # region アクセサメソッド

        /// <summary>
        /// 伝票呼出後データテーブルが更新されているかのフラグ
        /// </summary>
        public Boolean TableUpdateFlg
        {
            get { return tableUpdateFlg; }
            set { tableUpdateFlg = value; }
        }

        /// <summary>
        /// 終了前フラグ
        /// </summary>
        public bool CloseFlg
        {
            get { return _closeFlg; }
            set { _closeFlg = value; }
        }

        public bool SaveFlg
        {
            get { return _saveFlg; }
            set { _saveFlg = value; }
        }

        # endregion

        // --- ADD 2008/07/14 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 単価算出クラス初期データ読込処理
        /// </summary>
        private void ReadInitData()
        {
            List<StockProcMoney> stockProcMoneyList = new List<StockProcMoney>();
            ArrayList retStockProcMoneyList;

            int status = this._stockProcMoneyAcs.Search(out retStockProcMoneyList, LoginInfoAcquisition.EnterpriseCode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                foreach (StockProcMoney stockProcMoney in retStockProcMoneyList)
                {
                    stockProcMoneyList.Add(stockProcMoney.Clone());
                }
            }

            this._unitPriceCalculation.CacheStockProcMoneyList(stockProcMoneyList);
        }

        /// <summary>
        /// 原単価取得処理
        /// </summary>
        /// <param name="stock">在庫マスタ</param>
        /// <param name="goodsUnitData">商品連結データ</param>
        /// <returns>原単価</returns>
        /// <remarks>
        /// <br>Note       : 在庫マスタ、商品連結データより原単価を取得します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/07/14</br>
        /// </remarks>
        private Double GetStockUnitPrice(GoodsUnitData goodsUnitData)
        {
            Double stockUnitPrice = 0;

            // 商品連結データから単価算出結果オブジェクトを取得
            UnitPriceCalcRet unitPriceCalcRet = GetUnitPriceCalcRet(goodsUnitData);

            // 単価算出結果オブジェクトより原単価取得
            stockUnitPrice = unitPriceCalcRet.UnitPriceTaxExcFl;

            return stockUnitPrice;
        }

        /// <summary>
        /// 単価算出結果オブジェクト取得処理
        /// </summary>
        /// <param name="goodsUnitData">商品連結データ</param>
        /// <returns>単価算出結果オブジェクト</returns>
        /// <remarks>
        /// <br>Note       : 商品連結データより単価算出結果オブジェクトを取得します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/07/14</br>
        /// </remarks>
        private UnitPriceCalcRet GetUnitPriceCalcRet(GoodsUnitData goodsUnitData)
        {
            // 単価算出パラメータ設定
            UnitPriceCalcParam unitPriceCalcParam = new UnitPriceCalcParam();
            unitPriceCalcParam.SectionCode = LoginInfoAcquisition.Employee.BelongSectionCode.Trim();    // 拠点コード
            unitPriceCalcParam.GoodsMakerCd = goodsUnitData.GoodsMakerCd;                               // 商品メーカーコード
            unitPriceCalcParam.GoodsNo = goodsUnitData.GoodsNo;                                         // 商品番号
            unitPriceCalcParam.GoodsRateRank = goodsUnitData.GoodsRateRank;                             // 商品掛率ランク
            unitPriceCalcParam.GoodsRateGrpCode = goodsUnitData.GoodsMGroup;                            // 商品掛率グループコード
            unitPriceCalcParam.BLGroupCode = goodsUnitData.BLGroupCode;                                 // BLグループコード
            unitPriceCalcParam.BLGoodsCode = goodsUnitData.BLGoodsCode;                                 // BL商品コード
            unitPriceCalcParam.SupplierCd = goodsUnitData.SupplierCd;                                   // 仕入先コード
            unitPriceCalcParam.PriceApplyDate = getSlipmentDay();                                       // 価格適用日
            unitPriceCalcParam.CountFl = 1;                                                             // 数量
            unitPriceCalcParam.TaxationDivCd = goodsUnitData.TaxationDivCd;                             // 課税区分
            unitPriceCalcParam.TaxRate = TaxRateSetAcs.GetTaxRate(this._taxRateSet, getSlipmentDay());  // 税率
            unitPriceCalcParam.StockCnsTaxFrcProcCd = goodsUnitData.StockCnsTaxFrcProcCd;               // 仕入消費税端数処理コード
            unitPriceCalcParam.StockUnPrcFrcProcCd = goodsUnitData.StockUnPrcFrcProcCd;                 // 仕入単価端数処理コード

            List<UnitPriceCalcRet> unitPriceCalcRetList;
            this._unitPriceCalculation.CalculateUnitCost(unitPriceCalcParam, goodsUnitData, out unitPriceCalcRetList);

            foreach (UnitPriceCalcRet unitPriceCalcRetWk in unitPriceCalcRetList)
            {
                if (unitPriceCalcRetWk.UnitPriceKind == UnitPriceCalculation.ctUnitPriceKind_UnitCost)
                {
                    return unitPriceCalcRetWk;
                }
            }

            return new UnitPriceCalcRet();
        }

        /// <summary>
        /// 税率設定マスタ取得処理
        /// </summary>
        private void ReadTaxRate()
        {
            int status;

            try
            {
                // 税率設定マスタ取得(税率コード=0固定)
                status = this._taxRateSetAcs.Read(out this._taxRateSet, LoginInfoAcquisition.EnterpriseCode, 0);
            }
            catch
            {
                this._taxRateSet = new TaxRateSet();
            }
        }

        /// <summary>
        /// ユーザー設定反映処理
        /// </summary>
        public void SetUserSetting(ArrayList userSettingList)
        {
            ArrayList captionKeyList = new ArrayList();
            captionKeyList = (ArrayList)userSettingList[0];
            
            ArrayList captionNameList = new ArrayList();
            captionNameList = (ArrayList)userSettingList[1];

            ArrayList visibleList = new ArrayList();
            visibleList = (ArrayList)userSettingList[2];

            ArrayList visibleAllowList = new ArrayList();
            visibleAllowList = (ArrayList)userSettingList[3];

            ArrayList visiblePositionList = new ArrayList();
            visiblePositionList = (ArrayList)userSettingList[4];

            ArrayList moveAllowList = new ArrayList();
            moveAllowList = (ArrayList)userSettingList[5];

            StockMoveInputDataSet.StockMoveDataTable tbl = this._stockMoveInputAcs.StockMoveDataTable;

            ColumnsCollection columns = this.ultraGrid1.DisplayLayout.Bands[0].Columns;

            try
            {
                this.ultraGrid1.BeginUpdate();

                columns[tbl.StockMoveRowNoColumn.ColumnName].Header.VisiblePosition = 0;
                for (int index = 0; index < captionKeyList.Count; index++)
                {
                    for (int columnIndex = 0; columnIndex < columns.Count; columnIndex++)
                    {
                        if ((String)captionKeyList[index] == columns[columnIndex].Key)
                        {
                            columns[columnIndex].Hidden = (Boolean)visibleList[index];
                            columns[columnIndex].Header.VisiblePosition = (int)visiblePositionList[index];
                            break;
                        }
                    }
                }
            }
            finally
            {
                this.ultraGrid1.EndUpdate();
            }
        }

        /// <summary>
        /// ユーザー設定取得処理
        /// </summary>
        /// <br>Update Note: 2011/04/11 鄧潘ハン 明細に仕入先を追加する</br>
        public void GetUserSetting(out ArrayList userSettingList)
        {
            userSettingList = new ArrayList();

            ArrayList captionKeyList = new ArrayList();
            ArrayList captionNameList = new ArrayList();
            ArrayList visibleList = new ArrayList();
            ArrayList visibleAllowList = new ArrayList();
            ArrayList visiblePositionList = new ArrayList();
            ArrayList moveAllowList = new ArrayList();

            StockMoveInputDataSet.StockMoveDataTable tbl = this._stockMoveInputAcs.StockMoveDataTable;

            ColumnsCollection columns = this.ultraGrid1.DisplayLayout.Bands[0].Columns;

            SortedList<int, string> columnList = new SortedList<int, string>();

            columnList.Add(columns[tbl.GoodsNoColumn.ColumnName].Header.VisiblePosition, columns[tbl.GoodsNoColumn.ColumnName].Key);
            columnList.Add(columns[tbl.GoodsNameColumn.ColumnName].Header.VisiblePosition, columns[tbl.GoodsNameColumn.ColumnName].Key);
            columnList.Add(columns[tbl.GoodsMakerCdColumn.ColumnName].Header.VisiblePosition, columns[tbl.GoodsMakerCdColumn.ColumnName].Key);
            columnList.Add(columns[tbl.MakerGuideButtonColumn.ColumnName].Header.VisiblePosition, columns[tbl.MakerGuideButtonColumn.ColumnName].Key);
            columnList.Add(columns[tbl.BLGoodsCodeColumn.ColumnName].Header.VisiblePosition, columns[tbl.BLGoodsCodeColumn.ColumnName].Key);
            columnList.Add(columns[tbl.BLCodeGuideButtonColumn.ColumnName].Header.VisiblePosition, columns[tbl.BLCodeGuideButtonColumn.ColumnName].Key);
            //---ADD 2011/04/11----------------------------------------------------------->>>>>
            columnList.Add(columns[tbl.SupplierCdColumn.ColumnName].Header.VisiblePosition, columns[tbl.SupplierCdColumn.ColumnName].Key);
            columnList.Add(columns[tbl.SupplierCdGuideButtonColumn.ColumnName].Header.VisiblePosition, columns[tbl.SupplierCdGuideButtonColumn.ColumnName].Key);
            //---ADD 2011/04/11-----------------------------------------------------------<<<<<
            columnList.Add(columns[tbl.MovingSupliStockColumn.ColumnName].Header.VisiblePosition, columns[tbl.MovingSupliStockColumn.ColumnName].Key);
            columnList.Add(columns[tbl.StockUnitPriceFlColumn.ColumnName].Header.VisiblePosition, columns[tbl.StockUnitPriceFlColumn.ColumnName].Key);
            columnList.Add(columns[tbl.ListPriceFlViewColumn.ColumnName].Header.VisiblePosition, columns[tbl.ListPriceFlViewColumn.ColumnName].Key);
            columnList.Add(columns[tbl.BfShelfNoColumn.ColumnName].Header.VisiblePosition, columns[tbl.BfShelfNoColumn.ColumnName].Key);
            columnList.Add(columns[tbl.AfShelfNoColumn.ColumnName].Header.VisiblePosition, columns[tbl.AfShelfNoColumn.ColumnName].Key);
            columnList.Add(columns[tbl.BfBeforeMoveCountColumn.ColumnName].Header.VisiblePosition, columns[tbl.BfBeforeMoveCountColumn.ColumnName].Key);
            columnList.Add(columns[tbl.BfAfterMoveCountColumn.ColumnName].Header.VisiblePosition, columns[tbl.BfAfterMoveCountColumn.ColumnName].Key);
            // --- ADD 2014/04/09 T.Miyamoto ------------------------------>>>>>
            columnList.Add(columns[tbl.AfBeforeMoveCountColumn.ColumnName].Header.VisiblePosition, columns[tbl.AfBeforeMoveCountColumn.ColumnName].Key);
            columnList.Add(columns[tbl.AfAfterMoveCountColumn.ColumnName].Header.VisiblePosition, columns[tbl.AfAfterMoveCountColumn.ColumnName].Key);
            // --- ADD 2014/04/09 T.Miyamoto ------------------------------<<<<<

            foreach (int key in columnList.Keys)
            {
                for (int index = 0; index < columns.Count; index++)
                {
                    if (columnList[key] != columns[index].Key)
                    {
                        continue;
                    }

                    captionKeyList.Add(columns[index].Key);
                    visibleList.Add(!(columns[index].Hidden));
                    visiblePositionList.Add(key);

                    if (columns[index].Key == tbl.GoodsNoColumn.ColumnName)
                    {
                        captionNameList.Add(tbl.GoodsNoColumn.Caption);
                        visibleAllowList.Add(false);
                        moveAllowList.Add(false);
                    }
                    else if (columns[index].Key == tbl.GoodsNameColumn.ColumnName)
                    {
                        captionNameList.Add(tbl.GoodsNameColumn.Caption);
                        visibleAllowList.Add(false);
                        moveAllowList.Add(false);
                    }
                    else if (columns[index].Key == tbl.GoodsMakerCdColumn.ColumnName)
                    {
                        captionNameList.Add(tbl.GoodsMakerCdColumn.Caption);
                        visibleAllowList.Add(false);
                        moveAllowList.Add(true);
                    }
                    else if (columns[index].Key == tbl.MakerGuideButtonColumn.ColumnName)
                    {
                        captionNameList.Add("メーカーガイドボタン");
                        visibleAllowList.Add(true);
                        moveAllowList.Add(true);
                    }
                    else if (columns[index].Key == tbl.BLGoodsCodeColumn.ColumnName)
                    {
                        captionNameList.Add(tbl.BLGoodsCodeColumn.Caption);
                        visibleAllowList.Add(true);
                        moveAllowList.Add(true);
                    }
                    else if (columns[index].Key == tbl.BLCodeGuideButtonColumn.ColumnName)
                    {
                        captionNameList.Add("BLｺｰﾄﾞガイドボタン");
                        visibleAllowList.Add(true);
                        moveAllowList.Add(true);
                    }
                    //---ADD 2011/04/11----------------------------------------------------------->>>>>
                    else if (columns[index].Key == tbl.SupplierCdColumn.ColumnName)
                    {
                        captionNameList.Add(tbl.SupplierCdColumn.Caption);
                        visibleAllowList.Add(true);
                        moveAllowList.Add(true);
                    }
                    else if (columns[index].Key == tbl.SupplierCdGuideButtonColumn.ColumnName)
                    {
                        //captionNameList.Add("仕入先ｺｰﾄﾞガイドボタン"); // DEL 2011/05/20
                        captionNameList.Add("仕入先ガイドボタン"); //ADD 2011/05/20
                        visibleAllowList.Add(true);
                        moveAllowList.Add(true);
                    }
                    //---ADD 2011/04/11-----------------------------------------------------------<<<<<
                    else if (columns[index].Key == tbl.MovingSupliStockColumn.ColumnName)
                    {
                        captionNameList.Add(tbl.MovingSupliStockColumn.Caption);
                        visibleAllowList.Add(false);
                        moveAllowList.Add(true);
                    }
                    else if (columns[index].Key == tbl.StockUnitPriceFlColumn.ColumnName)
                    {
                        captionNameList.Add(tbl.StockUnitPriceFlColumn.Caption);
                        visibleAllowList.Add(true);
                        moveAllowList.Add(true);
                    }
                    else if (columns[index].Key == tbl.ListPriceFlViewColumn.ColumnName)
                    {
                        captionNameList.Add(tbl.ListPriceFlViewColumn.Caption);
                        visibleAllowList.Add(true);
                        moveAllowList.Add(true);
                    }
                    else if (columns[index].Key == tbl.BfShelfNoColumn.ColumnName)
                    {
                        captionNameList.Add(tbl.BfShelfNoColumn.Caption);
                        visibleAllowList.Add(true);
                        moveAllowList.Add(true);
                    }
                    else if (columns[index].Key == tbl.AfShelfNoColumn.ColumnName)
                    {
                        captionNameList.Add(tbl.AfShelfNoColumn.Caption);
                        visibleAllowList.Add(true);
                        moveAllowList.Add(true);
                    }
                    else if (columns[index].Key == tbl.BfBeforeMoveCountColumn.ColumnName)
                    {
                        captionNameList.Add(tbl.BfBeforeMoveCountColumn.Caption);
                        visibleAllowList.Add(true);
                        moveAllowList.Add(true);
                    }
                    else if (columns[index].Key == tbl.BfAfterMoveCountColumn.ColumnName)
                    {
                        captionNameList.Add(tbl.BfAfterMoveCountColumn.Caption);
                        visibleAllowList.Add(true);
                        moveAllowList.Add(true);
                    }
                    // --- ADD 2014/04/09 T.Miyamoto ------------------------------>>>>>
                    else if (columns[index].Key == tbl.AfBeforeMoveCountColumn.ColumnName)
                    {
                        captionNameList.Add(tbl.AfBeforeMoveCountColumn.Caption);
                        visibleAllowList.Add(true);
                        moveAllowList.Add(true);
                    }
                    else if (columns[index].Key == tbl.AfAfterMoveCountColumn.ColumnName)
                    {
                        captionNameList.Add(tbl.AfAfterMoveCountColumn.Caption);
                        visibleAllowList.Add(true);
                        moveAllowList.Add(true);
                    }
                    // --- ADD 2014/04/09 T.Miyamoto ------------------------------<<<<<
                }
            }

            userSettingList.Add(captionKeyList);
            userSettingList.Add(captionNameList);
            userSettingList.Add(visibleList);
            userSettingList.Add(visibleAllowList);
            userSettingList.Add(visiblePositionList);
            userSettingList.Add(moveAllowList);
        }

        /// <summary>
        /// グリッド情報XML保存処理
        /// </summary>
        public void SaveXmlData()
        {
            ColumnsCollection columns = this.ultraGrid1.DisplayLayout.Bands[0].Columns;

            StockMoveDetailColumnStatus[] stockMoveDetailColumnStatusArray = new StockMoveDetailColumnStatus[columns.Count];

            // グリッド情報取得
            
            for (int index = 0; index < columns.Count; index++)
            {
                StockMoveDetailColumnStatus stockMoveDetailColumnStatus = new StockMoveDetailColumnStatus();
                stockMoveDetailColumnStatus.ColumnKey = columns[index].Key;
                stockMoveDetailColumnStatus.Hidden = columns[index].Hidden;
                stockMoveDetailColumnStatus.VisiblePosition = columns[index].Header.VisiblePosition;
                stockMoveDetailColumnStatus.Width = columns[index].Width;

                stockMoveDetailColumnStatusArray[index] = stockMoveDetailColumnStatus;
            }

            XmlByteSerializer.Serialize(stockMoveDetailColumnStatusArray, Path.Combine(ConstantManagement_ClientDirectory.UISettings_GridInfo, "MAZAI04120UB.dat"));
        }

        // --- ADD 2011/07/25 --- >>>>>
        /// <summary>
        /// 自社情報設定取得処理
        /// </summary>
        public void SetCompanyInf()
        {
            // 自社情報設定取得処理
            this._stockMoveInputAcs.LoadCompanyInf();

            if (this._stockMoveInputAcs.GetCompanyInf() != null)
            {
                this._unitPriceCalculation.RatePriorityDiv = this._stockMoveInputAcs.GetCompanyInf().RatePriorityDiv;
            }
        }
        // --- ADD 2011/07/25 --- <<<<<

        /// <summary>
        /// グリッド情報XML読込処理
        /// </summary>
        private void LoadXmlData()
        {
            try
            {
                StockMoveDetailColumnStatus[] stockMoveDetailColumnStatusArray = (StockMoveDetailColumnStatus[])XmlByteSerializer.Deserialize(Path.Combine(ConstantManagement_ClientDirectory.UISettings_GridInfo, "MAZAI04120UB.dat"), typeof(StockMoveDetailColumnStatus[]));

                ColumnsCollection columns = this.ultraGrid1.DisplayLayout.Bands[0].Columns;
                for (int index = 0; index < stockMoveDetailColumnStatusArray.Length; index++)
                {
                    columns[stockMoveDetailColumnStatusArray[index].ColumnKey].Hidden = stockMoveDetailColumnStatusArray[index].Hidden;
                    columns[stockMoveDetailColumnStatusArray[index].ColumnKey].Header.VisiblePosition = stockMoveDetailColumnStatusArray[index].VisiblePosition;
                    columns[stockMoveDetailColumnStatusArray[index].ColumnKey].Width = stockMoveDetailColumnStatusArray[index].Width;
                }
            }
            catch
            {
            }
        }

        /// <summary>
        /// 移動伝票明細データテーブル列表示設定クラスセッティング処理
        /// <br>Update Note: 2011/04/11 鄧潘ハン 明細に仕入先を追加する</br>
        /// </summary>
        private void SettingStockMoveDetailRowVisibleControl()
        {
            // 移動伝票番号
            this._stockMoveDetailRowVisibleControl.Add(this._stockMoveInputAcs.StockMoveDataTable.StockMoveSlipNoColumn.ColumnName, StatusType.Default, 0, true);
            // №
            this._stockMoveDetailRowVisibleControl.Add(this._stockMoveInputAcs.StockMoveDataTable.StockMoveRowNoColumn.ColumnName, StatusType.Default, 0, false);
            // 商品コード
            this._stockMoveDetailRowVisibleControl.Add(this._stockMoveInputAcs.StockMoveDataTable.GoodsNoColumn.ColumnName, StatusType.Default, 0, false);
            // メーカーコード
            this._stockMoveDetailRowVisibleControl.Add(this._stockMoveInputAcs.StockMoveDataTable.GoodsMakerCdColumn.ColumnName, StatusType.Default, 0, false);
            // メーカーガイドボタン
            this._stockMoveDetailRowVisibleControl.Add(this._stockMoveInputAcs.StockMoveDataTable.MakerGuideButtonColumn.ColumnName, StatusType.Default, 0, false);
            // BLコードガイドボタン
            this._stockMoveDetailRowVisibleControl.Add(this._stockMoveInputAcs.StockMoveDataTable.BLCodeGuideButtonColumn.ColumnName, StatusType.Default, 0, false);
            // ＢＬコード
            this._stockMoveDetailRowVisibleControl.Add(this._stockMoveInputAcs.StockMoveDataTable.BLGoodsCodeColumn.ColumnName, StatusType.Default, 0, false);
            //---ADD 2011/04/11----------------------------------------------------------->>>>>
            // 仕入先
            this._stockMoveDetailRowVisibleControl.Add(this._stockMoveInputAcs.StockMoveDataTable.SupplierCdColumn.ColumnName, StatusType.Default, 0, false);
            // 仕入先コードガイドボタン
            this._stockMoveDetailRowVisibleControl.Add(this._stockMoveInputAcs.StockMoveDataTable.SupplierCdGuideButtonColumn.ColumnName, StatusType.Default, 0, false);
            //---ADD 2011/04/11-----------------------------------------------------------<<<<<
            // 商品名
            this._stockMoveDetailRowVisibleControl.Add(this._stockMoveInputAcs.StockMoveDataTable.GoodsNameColumn.ColumnName, StatusType.Default, 0, false);
            // --- ADD m.suzuki 2010/04/15 ---------->>>>>
            // 品名カナ
            this._stockMoveDetailRowVisibleControl.Add( this._stockMoveInputAcs.StockMoveDataTable.GoodsNameKanaColumn.ColumnName, StatusType.Default, 0, true ); // 非表示
            // --- ADD m.suzuki 2010/04/15 ----------<<<<<
            // 仕入在庫出荷数
            this._stockMoveDetailRowVisibleControl.Add(this._stockMoveInputAcs.StockMoveDataTable.MovingSupliStockColumn.ColumnName, StatusType.Default, 0, false);
            // 受託在庫出荷数
            this._stockMoveDetailRowVisibleControl.Add( this._stockMoveInputAcs.StockMoveDataTable.MovingTrustStockColumn.ColumnName, StatusType.Default, 0, true );
            // 受託在庫残数
            this._stockMoveDetailRowVisibleControl.Add( this._stockMoveInputAcs.StockMoveDataTable.TrustRemainCountColumn.ColumnName, StatusType.Default, 0, true );
            // 単価
            this._stockMoveDetailRowVisibleControl.Add(this._stockMoveInputAcs.StockMoveDataTable.StockUnitPriceFlColumn.ColumnName, StatusType.Default, 0, false);
            // 定価
            this._stockMoveDetailRowVisibleControl.Add(this._stockMoveInputAcs.StockMoveDataTable.ListPriceFlColumn.ColumnName, StatusType.Default, 0, true);      // 数値(double):内部的に使用
            this._stockMoveDetailRowVisibleControl.Add(this._stockMoveInputAcs.StockMoveDataTable.ListPriceFlViewColumn.ColumnName, StatusType.Default, 0, false);  // 文字列:表示用（オープン価格対応）
            // 出庫棚番
            this._stockMoveDetailRowVisibleControl.Add(this._stockMoveInputAcs.StockMoveDataTable.BfShelfNoColumn.ColumnName, StatusType.Default, 0, false);
            // 入庫棚番
            this._stockMoveDetailRowVisibleControl.Add(this._stockMoveInputAcs.StockMoveDataTable.AfShelfNoColumn.ColumnName, StatusType.Default, 0, false);
            // 出庫前数
            this._stockMoveDetailRowVisibleControl.Add(this._stockMoveInputAcs.StockMoveDataTable.BfBeforeMoveCountColumn.ColumnName, StatusType.Default, 0, false);
            // 出庫後数
            this._stockMoveDetailRowVisibleControl.Add(this._stockMoveInputAcs.StockMoveDataTable.BfAfterMoveCountColumn.ColumnName, StatusType.Default, 0, false);
            // 提供区分
            this._stockMoveDetailRowVisibleControl.Add(this._stockMoveInputAcs.StockMoveDataTable.OfferKubunColumn.ColumnName, StatusType.Default, 0, true);
            // 変更前出荷数
            this._stockMoveDetailRowVisibleControl.Add(this._stockMoveInputAcs.StockMoveDataTable.BfMovingSupliStockColumn.ColumnName, StatusType.Default, 0, true);
            // 変更前仕入単価
            this._stockMoveDetailRowVisibleControl.Add(this._stockMoveInputAcs.StockMoveDataTable.BfStockUnitPriceFlColumn.ColumnName, StatusType.Default, 0, true);
            // --- ADD 2014/04/09 T.Miyamoto ------------------------------>>>>>
            // 入庫前数
            this._stockMoveDetailRowVisibleControl.Add(this._stockMoveInputAcs.StockMoveDataTable.AfBeforeMoveCountColumn.ColumnName, StatusType.Default, 0, false);
            // 入庫後数
            this._stockMoveDetailRowVisibleControl.Add(this._stockMoveInputAcs.StockMoveDataTable.AfAfterMoveCountColumn.ColumnName, StatusType.Default, 0, false);
            // --- ADD 2014/04/09 T.Miyamoto ------------------------------<<<<<
        }
        // --- ADD 2008/07/14 ---------------------------------------------------------------------<<<<<

        #region DEL 2008/07/14 Partsman用に変更
        /* --- DEL 2008/07/14 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 移動伝票明細データテーブル列表示設定クラスセッティング処理
        /// </summary>
        private void SettingStockMoveDetailRowVisibleControl()
        {
            // 移動伝票番号
            this._stockMoveDetailRowVisibleControl.Add(this._stockMoveInputAcs.StockMoveDataTable.StockMoveSlipNoColumn.ColumnName, StatusType.Default, 0, true);

            // №
            this._stockMoveDetailRowVisibleControl.Add(this._stockMoveInputAcs.StockMoveDataTable.StockMoveRowNoColumn.ColumnName, StatusType.Default, 0, false);

            // 商品コード
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //this._stockMoveDetailRowVisibleControl.Add(this._stockMoveInputAcs.StockMoveDataTable.GoodsCodeColumn.ColumnName, StatusType.Default, 0, false);
            this._stockMoveDetailRowVisibleControl.Add(this._stockMoveInputAcs.StockMoveDataTable.GoodsNoColumn.ColumnName, StatusType.Default, 0, false);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            // メーカーコード
            this._stockMoveDetailRowVisibleControl.Add(this._stockMoveInputAcs.StockMoveDataTable.GoodsMakerCdColumn.ColumnName, StatusType.Default, 0, false);

            // メーカー名称
            this._stockMoveDetailRowVisibleControl.Add(this._stockMoveInputAcs.StockMoveDataTable.MakerNameColumn.ColumnName, StatusType.Default, 0, false);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // 商品ガイドボタン
            this._stockMoveDetailRowVisibleControl.Add(this._stockMoveInputAcs.StockMoveDataTable.GoodsGuideButtonColumn.ColumnName, StatusType.Default, 0, false);

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            // ＢＬコード
            this._stockMoveDetailRowVisibleControl.Add(this._stockMoveInputAcs.StockMoveDataTable.BLGoodsCodeColumn.ColumnName, StatusType.Default, 0, false);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // 商品名
            this._stockMoveDetailRowVisibleControl.Add(this._stockMoveInputAcs.StockMoveDataTable.GoodsNameColumn.ColumnName, StatusType.Default, 0, false);

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //// 製造番号
            //this._stockMoveDetailRowVisibleControl.Add(this._stockMoveInputAcs.StockMoveDataTable.ProductNumberColumn.ColumnName, StatusType.Default, 0, false);
            //// 電話番号1
            //this._stockMoveDetailRowVisibleControl.Add(this._stockMoveInputAcs.StockMoveDataTable.StockTelNo1Column.ColumnName, StatusType.Default, 0, false);
            //// 電話番号2
            //this._stockMoveDetailRowVisibleControl.Add(this._stockMoveInputAcs.StockMoveDataTable.StockTelNo2Column.ColumnName, StatusType.Default, 0, false);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // 仕入在庫出荷数
            this._stockMoveDetailRowVisibleControl.Add(this._stockMoveInputAcs.StockMoveDataTable.MovingSupliStockColumn.ColumnName, StatusType.Default, 0, false);

            // 仕入在庫残数
            this._stockMoveDetailRowVisibleControl.Add(this._stockMoveInputAcs.StockMoveDataTable.SlipRemainCountColumn.ColumnName, StatusType.Default, 0, false);

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //// 受託在庫出荷数
            //this._stockMoveDetailRowVisibleControl.Add(this._stockMoveInputAcs.StockMoveDataTable.MovingTrustStockColumn.ColumnName, StatusType.Default, 0, false);

            //// 受託在庫残数
            //this._stockMoveDetailRowVisibleControl.Add(this._stockMoveInputAcs.StockMoveDataTable.TrustRemainCountColumn.ColumnName, StatusType.Default, 0, false);

            // 受託在庫出荷数
            this._stockMoveDetailRowVisibleControl.Add(this._stockMoveInputAcs.StockMoveDataTable.MovingTrustStockColumn.ColumnName, StatusType.Default, 0, true);

            // 受託在庫残数
            this._stockMoveDetailRowVisibleControl.Add(this._stockMoveInputAcs.StockMoveDataTable.TrustRemainCountColumn.ColumnName, StatusType.Default, 0, true);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // 単価
            this._stockMoveDetailRowVisibleControl.Add(this._stockMoveInputAcs.StockMoveDataTable.StockUnitPriceFlColumn.ColumnName, StatusType.Default, 0, false);

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            // 定価
            this._stockMoveDetailRowVisibleControl.Add(this._stockMoveInputAcs.StockMoveDataTable.ListPriceFlColumn.ColumnName, StatusType.Default, 0, true);      // 数値(double):内部的に使用
            this._stockMoveDetailRowVisibleControl.Add(this._stockMoveInputAcs.StockMoveDataTable.ListPriceFlViewColumn.ColumnName, StatusType.Default, 0, false);  // 文字列:表示用（オープン価格対応）
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // 移動金額
            //this._stockMoveDetailRowVisibleControl.Add(this._stockMoveInputAcs.StockMoveDataTable.MovingPriceColumn.ColumnName, StatusType.Default, 0, false);

            // 出庫拠点名
            this._stockMoveDetailRowVisibleControl.Add(this._stockMoveInputAcs.StockMoveDataTable.BfSectionGuideNmColumn.ColumnName, StatusType.Default, 0, false);

            // 出庫倉庫名
            this._stockMoveDetailRowVisibleControl.Add(this._stockMoveInputAcs.StockMoveDataTable.BfEnterWarehNameColumn.ColumnName, StatusType.Default, 0, false);

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            // 出庫棚番
            this._stockMoveDetailRowVisibleControl.Add(this._stockMoveInputAcs.StockMoveDataTable.BfShelfNoColumn.ColumnName, StatusType.Default, 0, false);
            // 出庫前数
            this._stockMoveDetailRowVisibleControl.Add(this._stockMoveInputAcs.StockMoveDataTable.BfBeforeMoveCountColumn.ColumnName, StatusType.Default, 0, false);
            // 出庫後数
            this._stockMoveDetailRowVisibleControl.Add(this._stockMoveInputAcs.StockMoveDataTable.BfAfterMoveCountColumn.ColumnName, StatusType.Default, 0, false);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
        }
           --- DEL 2008/07/14 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/14 Partsman用に変更

        /// <summary>
        /// 画面初期化処理
        /// </summary>
        /// <br>Update Note: 2011/04/11 鄧潘ハン 明細に仕入先を追加する</br>
        internal void Clear()
        {
            // 在庫移動明細DataTable行クリア処理
            _stockMoveInputAcs.StockMoveDataTable.Rows.Clear();

            // 在庫移動詳細DataTable行クリア処理
            //_stockMoveInputAcs.StockMoveExpDataTable.Rows.Clear();

            // グリッド行初期設定処理(仕入ではユーザ設定クラスのAから取得している)
            this._stockMoveInputAcs.StockMoveDetailRowInitialSetting(20);

            // 明細グリッドセル設定処理
            this.SettingGrid();


            //---DEL 2011/04/11------------------------------------------------------------------------>>>>>
            //// グリッド列表示順位処理
            //this.VisiblePositionSettings()
            //---DEL 2011/04/11------------------------------------------------------------------------<<<<<

            // グリッド有効
            ultraGrid1.Enabled = true;

            // ボタンの有効化
            this.RowDelete_ultraButton.Enabled = true;
            /* --- DEL 2008/07/14 --------------------------------------------------------------------->>>>>
            this.GoodsSearch_ultraButton.Enabled = true;
            
            // 初期アクティブセルの指定
            ultraGrid1.ActiveCell = ultraGrid1.Rows[0].Cells[0];
            this.ultraGrid1.PerformAction(UltraGridAction.EnterEditMode);
               --- DEL 2008/07/14 ---------------------------------------------------------------------<<<<<*/

            // 更新モード
            _stockMoveInputInitAcs.RegistMode = 0;

            // --- ADD 2008/07/14 --------------------------------------------------------------------->>>>>
            // グリッド情報XML読込
            LoadXmlData();

            this._deleteFlg = false;

            // KeyList取得
            GetKeyList();
            // --- ADD 2008/07/14 ---------------------------------------------------------------------<<<<<

            //---ADD 2011/04/11------------------------------------------------------------------------>>>>>
            // グリッド列表示順位処理
            this.VisiblePositionSettings();
            //---ADD 2011/04/11------------------------------------------------------------------------<<<<<
        }

        #region DEL 2008/07/14 Partsman用に変更
        /* --- DEL 2008/07/14 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// グリッド列表示順位設定
        /// </summary>
        private void VisiblePositionSettings()
        {
            StockMoveInputDataSet.StockMoveDataTable tbl = _stockMoveInputAcs.StockMoveDataTable;

            int currentPosition = 0;
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[tbl.StockMoveRowNoColumn.ColumnName].Header.VisiblePosition = ++currentPosition;
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[tbl.GoodsNoColumn.ColumnName].Header.VisiblePosition = ++currentPosition;
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[tbl.GoodsGuideButtonColumn.ColumnName].Header.VisiblePosition = ++currentPosition;
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[tbl.GoodsNameColumn.ColumnName].Header.VisiblePosition = ++currentPosition;
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[tbl.GoodsMakerCdColumn.ColumnName].Header.VisiblePosition = ++currentPosition;
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[tbl.MakerNameColumn.ColumnName].Header.VisiblePosition = ++currentPosition;
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[tbl.BLGoodsCodeColumn.ColumnName].Header.VisiblePosition = ++currentPosition;
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[tbl.MovingSupliStockColumn.ColumnName].Header.VisiblePosition = ++currentPosition;
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[tbl.MovingTrustStockColumn.ColumnName].Header.VisiblePosition = ++currentPosition;
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[tbl.SlipRemainCountColumn.ColumnName].Header.VisiblePosition = ++currentPosition;
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[tbl.TrustRemainCountColumn.ColumnName].Header.VisiblePosition = ++currentPosition;
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[tbl.StockUnitPriceFlColumn.ColumnName].Header.VisiblePosition = ++currentPosition;
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[tbl.ListPriceFlColumn.ColumnName].Header.VisiblePosition = ++currentPosition;
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[tbl.ListPriceFlViewColumn.ColumnName].Header.VisiblePosition = ++currentPosition;
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[tbl.BfSectionGuideNmColumn.ColumnName].Header.VisiblePosition = ++currentPosition;
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[tbl.BfEnterWarehNameColumn.ColumnName].Header.VisiblePosition = ++currentPosition;
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[tbl.BfShelfNoColumn.ColumnName].Header.VisiblePosition = ++currentPosition;
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[tbl.BfBeforeMoveCountColumn.ColumnName].Header.VisiblePosition = ++currentPosition;
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[tbl.BfAfterMoveCountColumn.ColumnName].Header.VisiblePosition = ++currentPosition;
        }
           --- DEL 2008/07/14 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/14 Partsman用に変更

        // --- ADD 2008/07/14 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// グリッド列表示順位設定
        /// </summary>
        /// <br>Update Note: 2011/04/11 鄧潘ハン 明細に仕入先を追加する</br>
        private void VisiblePositionSettings()
        {
            StockMoveInputDataSet.StockMoveDataTable tbl = _stockMoveInputAcs.StockMoveDataTable;
            ColumnsCollection columns = this.ultraGrid1.DisplayLayout.Bands[0].Columns;

            int positionMin = 0;
            //int positionMax = 68;// DEL 2011/04/11
            int positionMax = 71;// ADD 2011/04/11
            for (int index = 0; index < columns.Count; index++)
            {
                if (columns[index].Key == tbl.StockMoveRowNoColumn.ColumnName)
                {
                    columns[index].Header.VisiblePosition = positionMin;
                    positionMin++;
                }
                else if (columns[index].Key == tbl.GoodsNoColumn.ColumnName)
                {
                    columns[index].Header.VisiblePosition = positionMin;
                    positionMin++;
                }
                else if (columns[index].Key == tbl.GoodsNameColumn.ColumnName)
                {
                    columns[index].Header.VisiblePosition = positionMin;
                    positionMin++;
                }
                else if (columns[index].Key == tbl.GoodsMakerCdColumn.ColumnName)
                {
                    columns[index].Header.VisiblePosition = positionMin;
                    positionMin++;
                }
                else if (columns[index].Key == tbl.MakerGuideButtonColumn.ColumnName)
                {
                    columns[index].Header.VisiblePosition = positionMin;
                    positionMin++;
                }
                else if (columns[index].Key == tbl.BLGoodsCodeColumn.ColumnName)
                {
                    columns[index].Header.VisiblePosition = positionMin;
                    positionMin++;
                }
                else if (columns[index].Key == tbl.BLCodeGuideButtonColumn.ColumnName)
                {
                    columns[index].Header.VisiblePosition = positionMin;
                    positionMin++;
                }
                //---ADD 2011/04/11----------------------------------------------------------->>>>>
                else if (columns[index].Key == tbl.SupplierCdColumn.ColumnName)
                {
                    columns[index].Header.VisiblePosition = positionMin;
                    positionMin++;
                }
                else if (columns[index].Key == tbl.SupplierCdGuideButtonColumn.ColumnName)
                {
                    columns[index].Header.VisiblePosition = positionMin;
                    positionMin++;
                }
                //---ADD 2011/04/11-----------------------------------------------------------<<<<<
                else if (columns[index].Key == tbl.MovingSupliStockColumn.ColumnName)
                {
                    columns[index].Header.VisiblePosition = positionMin;
                    positionMin++;
                }
                else if (columns[index].Key == tbl.StockUnitPriceFlColumn.ColumnName)
                {
                    columns[index].Header.VisiblePosition = positionMin;
                    positionMin++;
                }
                else if (columns[index].Key == tbl.ListPriceFlViewColumn.ColumnName)
                {
                    columns[index].Header.VisiblePosition = positionMin;
                    positionMin++;
                }
                else if (columns[index].Key == tbl.BfShelfNoColumn.ColumnName)
                {
                    columns[index].Header.VisiblePosition = positionMin;
                    positionMin++;
                }
                else if (columns[index].Key == tbl.AfShelfNoColumn.ColumnName)
                {
                    columns[index].Header.VisiblePosition = positionMin;
                    positionMin++;
                }
                else if (columns[index].Key == tbl.BfBeforeMoveCountColumn.ColumnName)
                {
                    columns[index].Header.VisiblePosition = positionMin;
                    positionMin++;
                }
                else if (columns[index].Key == tbl.BfAfterMoveCountColumn.ColumnName)
                {
                    columns[index].Header.VisiblePosition = positionMin;
                    positionMin++;
                }
                // --- ADD 2014/04/09 T.Miyamoto ------------------------------>>>>>
                else if (columns[index].Key == tbl.AfBeforeMoveCountColumn.ColumnName)
                {
                    columns[index].Header.VisiblePosition = positionMin;
                    positionMin++;
                }
                else if (columns[index].Key == tbl.AfAfterMoveCountColumn.ColumnName)
                {
                    columns[index].Header.VisiblePosition = positionMin;
                    positionMin++;
                }
                // --- ADD 2014/04/09 T.Miyamoto ------------------------------<<<<<
                else 
                {
                    columns[index].Header.VisiblePosition = positionMax;
                    positionMax--;
                }
            }

            int currentPosition = 0;
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[tbl.StockMoveRowNoColumn.ColumnName].Header.VisiblePosition = ++currentPosition;
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[tbl.GoodsNoColumn.ColumnName].Header.VisiblePosition = ++currentPosition;
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[tbl.GoodsNameColumn.ColumnName].Header.VisiblePosition = ++currentPosition;
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[tbl.GoodsMakerCdColumn.ColumnName].Header.VisiblePosition = ++currentPosition;
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[tbl.MakerGuideButtonColumn.ColumnName].Header.VisiblePosition = ++currentPosition;
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[tbl.BLGoodsCodeColumn.ColumnName].Header.VisiblePosition = ++currentPosition;
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[tbl.BLCodeGuideButtonColumn.ColumnName].Header.VisiblePosition = ++currentPosition;
            //---ADD 2011/04/11----------------------------------------------------------->>>>>
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[tbl.SupplierCdColumn.ColumnName].Header.VisiblePosition = ++currentPosition;
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[tbl.SupplierCdGuideButtonColumn.ColumnName].Header.VisiblePosition = ++currentPosition;
            //---ADD 2011/04/11-----------------------------------------------------------<<<<<
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[tbl.MovingSupliStockColumn.ColumnName].Header.VisiblePosition = ++currentPosition;
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[tbl.StockUnitPriceFlColumn.ColumnName].Header.VisiblePosition = ++currentPosition;
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[tbl.ListPriceFlViewColumn.ColumnName].Header.VisiblePosition = ++currentPosition;
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[tbl.BfShelfNoColumn.ColumnName].Header.VisiblePosition = ++currentPosition;
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[tbl.AfShelfNoColumn.ColumnName].Header.VisiblePosition = ++currentPosition;
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[tbl.BfBeforeMoveCountColumn.ColumnName].Header.VisiblePosition = ++currentPosition;
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[tbl.BfAfterMoveCountColumn.ColumnName].Header.VisiblePosition = ++currentPosition;
            // --- ADD 2014/04/09 T.Miyamoto ------------------------------>>>>>
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[tbl.AfBeforeMoveCountColumn.ColumnName].Header.VisiblePosition = ++currentPosition;
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[tbl.AfAfterMoveCountColumn.ColumnName].Header.VisiblePosition = ++currentPosition;
            // --- ADD 2014/04/09 T.Miyamoto ------------------------------<<<<<
        }

        /// <summary>
        /// 削除行チェック処理
        /// </summary>
        /// <returns>ステータス(True:削除対象行あり  False:削除対象行なし)</returns>
        /// <br>Update Note: 2011/04/11 鄧潘ハン 明細に仕入先を追加する</br>
        private bool CheckDeleteRow()
        {
            // グリッドに削除対象行が存在するかどうかチェックします
            for (int index = 0; index < this.ultraGrid1.Rows.Count; index++)
            {
                if ((this.ultraGrid1.Rows[index].Cells[_stockMoveDataTable.GoodsNoColumn.ColumnName].Text.Trim() != "") ||
                    (this.ultraGrid1.Rows[index].Cells[_stockMoveDataTable.GoodsNameColumn.ColumnName].Text.Trim() != "") ||
                    (this.ultraGrid1.Rows[index].Cells[_stockMoveDataTable.GoodsMakerCdColumn.ColumnName].Text.Trim() != "") ||
                    (this.ultraGrid1.Rows[index].Cells[_stockMoveDataTable.BLGoodsCodeColumn.ColumnName].Text.Trim() != "") ||
                    (this.ultraGrid1.Rows[index].Cells[_stockMoveDataTable.SupplierCdColumn.ColumnName].Text.Trim() != "") || // ADD 2011/04/11
                    (this.ultraGrid1.Rows[index].Cells[_stockMoveDataTable.MovingSupliStockColumn.ColumnName].Text.Trim() != "") ||
                    (this.ultraGrid1.Rows[index].Cells[_stockMoveDataTable.StockUnitPriceFlColumn.ColumnName].Text.Trim() != "") ||
                    (this.ultraGrid1.Rows[index].Cells[_stockMoveDataTable.ListPriceFlViewColumn.ColumnName].Text.Trim() != ""))
                {
                    return (true);
                }
            }

            return (false);
        }

        /// <summary>
        /// 出荷数チェック処理
        /// </summary>
        /// <param name="rowIndex">行インデックス</param>
        /// <returns>ステータス(True:正常  False:異常)</returns>
        private bool CheckInputMovingSupliStock(int rowIndex)
        {
            string goodsNo = this._stockMoveInputAcs.StockMoveDataTable[rowIndex].GoodsNo;
            int goodsMakerCd = this._stockMoveInputAcs.StringToInt(this._stockMoveInputAcs.StockMoveDataTable[rowIndex].GoodsMakerCd);

            // 品番もしくはメーカーコードが未入力の場合
            if ((String.IsNullOrEmpty(goodsNo) == true) || (goodsMakerCd == 0))
            {
                return (true);
            }

            // 商品データがユーザーデータ以外の場合
            int offerKubun = this._stockMoveInputAcs.StockMoveDataTable[rowIndex].OfferKubun;
            if (offerKubun != 0)
            {
                return (true);
            }

            // 出荷数チェック
            if (CheckInputMovingSupliStock(this.ultraGrid1.ActiveCell) == false)
            {
                return (false);
            }
            else
            {
                return (true);
            }
        }

        /// <summary>
        /// カンマ・ピリオド削除処理
        /// </summary>
        /// <param name="targetText">カンマ・ピリオド削除前テキスト</param>
        /// <param name="retText">カンマ・ピリオド削除済みテキスト</param>
        /// <param name="periodDelFlg">ピリオド削除フラグ(True:カンマ・ピリオド削除  False:カンマ削除)</param>
        private void RemoveCommaPeriod(string targetText, out string retText, bool periodDelFlg)
        {
            retText = "";

            // セル値編集用にカンマ・ピリオド削除
            for (int i = targetText.Length - 1; i >= 0; i--)
            {
                // カンマ・ピリオド削除
                if (periodDelFlg == true)
                {
                    if ((targetText[i].ToString() == ",") || (targetText[i].ToString() == "."))
                    {
                        targetText = targetText.Remove(i, 1);
                    }
                }
                // カンマのみ削除
                else
                {
                    if (targetText[i].ToString() == ",")
                    {
                        targetText = targetText.Remove(i, 1);
                    }
                }
            }

            retText = targetText;
        }

        /// <summary>
        /// 小数点取得処理
        /// </summary>
        /// <param name="targetText">チェック対象テキスト</param>
        /// <param name="retText">小数部分テキスト</param>
        private void GetDecimal(string targetText, out string retText)
        {
            retText = "";

            for (int i = targetText.IndexOf(".") + 1; i < targetText.Length; i++)
            {
                retText += targetText[i].ToString();
            }
        }

        /// <summary>
        /// Key作成処理
        /// </summary>
        /// <param name="makerCode">メーカーコード</param>
        /// <param name="goodsNo">品番</param>
        /// <returns>Key(メーカーコード(4桁)＋品番)</returns>
        private string MakeKey(int makerCode, string goodsNo)
        {
            string key = makerCode.ToString("0000") + goodsNo.Trim();

            return key;
        }

        /// <summary>
        /// 商品検索処理
        /// </summary>
        /// <param name="goodsNo">品番</param>
        /// <param name="makerCode">メーカーコード</param>
        /// <param name="goodsUnitData">商品連結データ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Update Note: 2021/10/08 陳艶丹</br>
        /// <br>管理番号   : 11601223-00</br>
        /// <br>           : BLINCIDENT-3114 小文字品番の在庫情報取得不具合の対応</br> 
        /// <br>Update Note: 2022/01/20 陳艶丹</br>
        /// <br>管理番号   : 11800082-00</br>
        /// <br>           : BLINCIDENT-3254 再度同一品番選択画面が表示される対応</br> 
        /// </remarks>
        private int SearchGoods(string goodsNo, int makerCode, out GoodsUnitData goodsUnitData)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            this._logicalDeleteFlg = false;

            goodsUnitData = new GoodsUnitData();

            // 商品検索条件クラスのインスタンス作成
            GoodsCndtn goodsCndtn = new GoodsCndtn();
            goodsCndtn.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;    // 企業コード
            if (_stockMoveHeader.BfSectionCode.Trim() != "")
            {
                goodsCndtn.SectionCode = _stockMoveHeader.BfSectionCode;        // 拠点コード
            }
            goodsCndtn.GoodsNo = goodsNo;                                       // 品番
            goodsCndtn.GoodsMakerCd = makerCode;                                // メーカーコード
            goodsCndtn.PriceApplyDate = getSlipmentDay();                       // 価格適用日
            List<string> listPriorWarehouse = new List<string>();
            listPriorWarehouse.Add(_stockMoveHeader.BfEnterWarehCode);
            goodsCndtn.ListPriorWarehouse = listPriorWarehouse;
            goodsCndtn.GoodsNoSrchTyp = 9;

            List<GoodsUnitData> goodsUnitDataList;

            try
            {
                // DEL Redmine#21642 2011/05/20 --------------------------------------------------------------------->>>>>>
                // リモート呼ぶ前に商品連結データDictionaryに対象データがあるかチェック
                //if (this._stockMoveInputAcs.GoodsUnitDataDic.ContainsKey(MakeKey(makerCode, goodsNo)) == true)
                //{
                //    goodsUnitData = (GoodsUnitData)this._stockMoveInputAcs.GoodsUnitDataDic[MakeKey(makerCode, goodsNo)];
                //    status = 0;
                //}
                //else
                //{
                // DEL Redmine#21642 2011/05/20 ---------------------------------------------------------------------<<<<<<
                    string errMsg;

                    // 商品検索
                    status = this._goodsAcs.SearchPartsFromGoodsNoNonVariousSearch(goodsCndtn, out goodsUnitDataList, out errMsg);

                    //--- ADD 陳艶丹 2021/10/08 BLINCIDENT-3114 小文字品番の在庫情報取得不具合の対応 ----->>>>>
                    if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                    {
                        try
                        {
                            goodsUnitData = goodsUnitDataList[0];

                            // --- UPD 陳艶丹 2022/01/20 BLINCIDENT-3254 再度同一品番選択画面が表示される対応 ----->>>>>
                            //// 入力品番が大文字 且つ 検索された品番が入力品番と不一致の場合
                            //if (goodsNo.ToUpper().Equals(goodsNo) &&
                            //    !goodsNo.Equals(goodsUnitData.GoodsNo))
                            string chkInputGoodsNo = string.Empty;
                            string chkSearchGoodsNo = string.Empty;
                            // 比較用品番取得
                            GetCompareGoodsNo(goodsNo, goodsUnitData.GoodsNo, out chkInputGoodsNo, out chkSearchGoodsNo);
                            // 入力品番が大文字 且つ 検索された品番が入力品番と不一致の場合
                            if (chkInputGoodsNo.ToUpper().Equals(chkInputGoodsNo) &&
                                !chkInputGoodsNo.Equals(chkSearchGoodsNo))
                            // --- UPD 陳艶丹 2022/01/20 BLINCIDENT-3254 再度同一品番選択画面が表示される対応 -----<<<<<
                            {
                                // ユーザー分品番検索
                                GoodsUnitData goodsUnitDataCk;
                                int ckStatus = this._goodsAcs.Read(LoginInfoAcquisition.EnterpriseCode, _stockMoveHeader.BfSectionCode, goodsUnitData.GoodsMakerCd, goodsUnitData.GoodsNo, out goodsUnitDataCk);

                                // ユーザー分商品登録される場合
                                if (ckStatus == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                                {
                                    // 小文字品番で再検索
                                    goodsCndtn.GoodsNo = goodsUnitData.GoodsNo;
                                    goodsCndtn.GoodsMakerCd = goodsUnitData.GoodsMakerCd; // ADD 陳艶丹 2022/01/20 BLINCIDENT-3254

                                    // 商品検索
                                    status = this._goodsAcs.SearchPartsFromGoodsNoNonVariousSearch(goodsCndtn, out goodsUnitDataList, out errMsg);
                                }
                            }
                        }
                        catch
                        {
                            // エラーメッセージを表示
                            Form form = new Form();
                            form.TopMost = true;
                            TMsgDisp.Show(
                                    form,
                                    emErrorLevel.ERR_LEVEL_INFO,
                                    this.Name,
                                    StrResearchErrMsg,
                                    0,
                                    MessageBoxButtons.OK);
                            form.TopMost = false;
                            status = 5;
                            return (status);
                        }
                    }
                    //--- ADD 陳艶丹 2021/10/08 BLINCIDENT-3114 小文字品番の在庫情報取得不具合の対応 -----<<<<<
                    if (status == 0)
                    {
                        goodsUnitData = goodsUnitDataList[0];

                        if (this._stockMoveInputAcs.GoodsUnitDataDic.ContainsKey(MakeKey(goodsUnitData.GoodsMakerCd, goodsUnitData.GoodsNo)) == false)
                        {
                            // FIXME:商品連結データDictionaryに追加(Key：メーカーコード＋品番　Value：商品連結データ)
                            this._stockMoveInputAcs.GoodsUnitDataDic.Add(MakeKey(goodsUnitData.GoodsMakerCd, goodsUnitData.GoodsNo), goodsUnitData);
                        }

                        bool bfStockExist = false;
                        bool afStockExist = false;
                        if ((goodsUnitData.StockList != null) && (goodsUnitData.StockList.Count != 0))
                        {
                            foreach (Stock stock in goodsUnitData.StockList)
                            {
                                if ((stock.WarehouseCode.Trim() == _stockMoveHeader.BfEnterWarehCode.Trim()) &&
                                    (stock.SectionCode.Trim() == _stockMoveHeader.BfSectionCode.Trim()))
                                {
                                    bfStockExist = true;
                                }
                                if ((stock.WarehouseCode.Trim() == _stockMoveHeader.AfEnterWarehCode.Trim()) &&
                                    (stock.SectionCode.Trim() == _stockMoveHeader.AfSectionCode.Trim()))
                                {
                                    afStockExist = true;
                                }
                            }

                            if ((bfStockExist == true) || (afStockExist == true))
                            {
                                goodsCndtn = new GoodsCndtn();
                                goodsCndtn.EnterpriseCode = goodsUnitData.EnterpriseCode;
                                goodsCndtn.GoodsMakerCd = goodsUnitData.GoodsMakerCd;
                                goodsCndtn.GoodsNo = goodsUnitData.GoodsNo;
                                goodsCndtn.GoodsKindCode = 9;

                                // FIXME:種類の違う品番検索を2回行う？
                                List<Stock> stockList = new List<Stock>();
                                status = this._goodsAcs.Search(goodsCndtn, ConstantManagement.LogicalMode.GetData01, out goodsUnitDataList, out errMsg);
                                if ((status == 0) && (goodsUnitDataList != null))
                                {
                                    stockList = goodsUnitDataList[0].StockList;
                                }

                                foreach (Stock stock in stockList)
                                {
                                    if (stock.LogicalDeleteCode != 0)
                                    {
                                        if (((stock.WarehouseCode.Trim() == _stockMoveHeader.BfEnterWarehCode.Trim()) &&
                                            (stock.SectionCode.Trim() == _stockMoveHeader.BfSectionCode.Trim())) ||
                                            ((stock.WarehouseCode.Trim() == _stockMoveHeader.AfEnterWarehCode.Trim()) &&
                                            (stock.SectionCode.Trim() == _stockMoveHeader.AfSectionCode.Trim())))
                                        {
                                            TMsgDisp.Show(this,
                                              emErrorLevel.ERR_LEVEL_INFO,
                                              this.Name,
                                              "在庫が論理削除の為、在庫移動できません。",
                                              5,
                                              MessageBoxButtons.OK);

                                            this._logicalDeleteFlg = true;

                                            status = 5;
                                            return (status);
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            // 在庫情報が存在しない場合、論理削除されているかもしれないので確認する
                            List<Stock> stockList = new List<Stock>();
                            int status2 = this._goodsAcs.Search(goodsCndtn, ConstantManagement.LogicalMode.GetData01, out goodsUnitDataList, out errMsg);
                            if ((status2 == 0) && (goodsUnitDataList != null))
                            {
                                stockList = goodsUnitDataList[0].StockList;
                            }

                            foreach (Stock stock in stockList)
                            {
                                if (stock.LogicalDeleteCode != 0)
                                {
                                    if (((stock.WarehouseCode.Trim() == _stockMoveHeader.BfEnterWarehCode.Trim()) &&
                                        (stock.SectionCode.Trim() == _stockMoveHeader.BfSectionCode.Trim())) ||
                                        ((stock.WarehouseCode.Trim() == _stockMoveHeader.AfEnterWarehCode.Trim()) &&
                                        (stock.SectionCode.Trim() == _stockMoveHeader.AfSectionCode.Trim())))
                                    {
                                        TMsgDisp.Show(this,
                                          emErrorLevel.ERR_LEVEL_INFO,
                                          this.Name,
                                          "在庫が論理削除の為、在庫移動できません。",
                                          5,
                                          MessageBoxButtons.OK);

                                        this._logicalDeleteFlg = true;

                                        status = 5;
                                        return (status);
                                    }
                                }
                            }
                        }
                    }
                    else if (status != -1)
                    {
                        // 入力された品番とメーカーコードに該当する商品が存在しなかった場合、
                        // 念のため、論理削除されているかどうかチェック
                        status = _goodsAcs.Read(LoginInfoAcquisition.EnterpriseCode, makerCode, goodsNo, ConstantManagement.LogicalMode.GetDataAll, out goodsUnitData);
                        if ((status == 0) && (goodsUnitData.LogicalDeleteCode != 0))
                        {
                            TMsgDisp.Show(this,
                                          emErrorLevel.ERR_LEVEL_INFO,
                                          this.Name,
                                          "論理削除商品のため、在庫移動できません。",
                                          5,
                                          MessageBoxButtons.OK);

                            this._logicalDeleteFlg = true;

                            status = 5;
                        }
                    }
                    else if (status == -1)
                    {
                        this._logicalDeleteFlg = true;

                        status = 5;
                    }
                // DEL Redmine#21642 2011/05/20 --------------------------------------------------------------------->>>>>>
                //}
                // DEL Redmine#21642 2011/05/20 ---------------------------------------------------------------------<<<<<<
            }
            catch
            {
                status = -1;
                goodsUnitData = new GoodsUnitData();
            }

            return (status);
        }

        // --- ADD 陳艶丹 2022/01/20 BLINCIDENT-3254 再度同一品番選択画面が表示される対応 ----->>>>>
        /// <summary>
        /// 比較用品番取得(ハイフン「-」と前方一致検索用の「*」を除き)
        /// </summary>
        /// <param name="inputGoodsNo">入力品番</param>
        /// <param name="searchGoodsNo">検索品番</param>
        /// <param name="compareInputGoodsNo">比較用入力品番</param>
        /// <param name="compareSearchGoodsNo">比較用検索品番</param>
        /// <remarks>
        /// <br>Note       : 2022/01/20 陳艶丹</br>
        /// <br>管理番号   : 11800082-00</br>
        /// <br>           : 比較用品番取得</br> 
        /// </remarks>
        private void GetCompareGoodsNo(string inputGoodsNo, string searchGoodsNo, out string compareInputGoodsNo, out string compareSearchGoodsNo)
        {
            compareInputGoodsNo = string.Empty;
            compareSearchGoodsNo = string.Empty;
            try
            {
                // 入力品番
                // ハイフンを除き
                string rstStr = string.Empty;
                rstStr = inputGoodsNo.Replace(CTHYPHEN, string.Empty);
                // 曖昧検索の場合、前方一致検索用"*"を除き
                if (inputGoodsNo.EndsWith(CTASTER)) rstStr = rstStr.Substring(0, rstStr.Length - 1);
                compareInputGoodsNo = rstStr;

                // 検索品番
                // ハイフンを除き
                rstStr = string.Empty;
                rstStr = searchGoodsNo.Replace(CTHYPHEN, string.Empty);
                // 曖昧検索の場合、入力品番より一部品番で比較
                if (inputGoodsNo.EndsWith(CTASTER) && rstStr.Length > compareInputGoodsNo.Length)
                {
                    rstStr = rstStr.Substring(0, compareInputGoodsNo.Length);
                }
                compareSearchGoodsNo = rstStr;
            }
            catch
            {
                // 取得失敗時、既存処理に影響しない為、比較しない
                compareInputGoodsNo = string.Empty;
                compareSearchGoodsNo = string.Empty;
            }
        }
        // --- ADD 陳艶丹 2022/01/20 BLINCIDENT-3254 再度同一品番選択画面が表示される対応 -----<<<<<

        /// <summary>
        /// 仕入在庫出荷数入力チェック（出荷数(仕)入力）
        /// </summary>
        /// <param name="activeCell">アクティブセル</param>
        private bool CheckInputMovingSupliStock(UltraGridCell activeCell)
        {
            double movingSupliStock;
            if (activeCell.Value == DBNull.Value)
            {
                movingSupliStock = 0;
            }
            else
            {
                movingSupliStock = Double.Parse(activeCell.Value.ToString());
            }

            // 更新したアクティブセルの行
            StockMoveInputDataSet.StockMoveRow row = _stockMoveDataTable[activeCell.Row.Index];

            double bfBeforeMoveCount;

            if ((this.ultraGrid1.Rows[activeCell.Row.Index].Cells[_stockMoveDataTable.BfBeforeMoveCountColumn.ColumnName].Value == DBNull.Value) ||
                (this.ultraGrid1.Rows[activeCell.Row.Index].Cells[_stockMoveDataTable.BfBeforeMoveCountColumn.ColumnName].Text.Trim() == ""))
            {
                // 出庫前数
                bfBeforeMoveCount = 0;
            }
            else
            {
                // 出庫前数
                bfBeforeMoveCount = ChangeCellValueToDouble(this.ultraGrid1.Rows[activeCell.Row.Index].Cells[_stockMoveDataTable.BfBeforeMoveCountColumn.ColumnName].Value);
            }

            // もし、仕入在庫出荷数が仕入在庫出荷可能数を超えていた場合
            if (bfBeforeMoveCount < movingSupliStock)
            {
                DialogResult dialogResult = TMsgDisp.Show(
                this,
                emErrorLevel.ERR_LEVEL_INFO,
                this.Name,
                "出庫数が出荷可能数を超えています。",
                -1,
                MessageBoxButtons.OK);

                return (false);
            }

            return (true);
        }

        /// <summary>
        /// グリッド列初期設定処理
        /// </summary>
        /// <br>Update Note: 2011/04/11 鄧潘ハン 明細に仕入先を追加する</br>
        private void GridColInitialSetting()
        {
            UltraGridBand editBand = this.ultraGrid1.DisplayLayout.Bands[0];
            if (editBand == null) return;
            StockMoveInputDataSet.StockMoveDataTable table = this._stockMoveInputAcs.StockMoveDataTable;

            foreach (UltraGridColumn col in editBand.Columns)
            {
                // 全ての列をいったん非表示にする。
                col.Hidden = true;

                // 「No列」以外の全てのセルのDiabledColorを設定する。
                if (col.Key != this._stockMoveInputAcs.StockMoveDataTable.StockMoveRowNoColumn.ColumnName)
                {
                    col.CellAppearance.BackColorDisabled = DISABLE_COLOR;
                    col.CellAppearance.ForeColorDisabled = DISABLE_FONT_COLOR;
                }
            }

            // グリッド列表示非表示設定処理
            this.SettingGridColVisible(StatusType.Default, 0);

            // 表示幅設定
            editBand.Columns[table.StockMoveRowNoColumn.ColumnName].Width = 44;			// №
            editBand.Columns[table.GoodsNoColumn.ColumnName].Width = 100;				// 商品コード
            editBand.Columns[table.MakerGuideButtonColumn.ColumnName].Width = 25;		// メーカーガイドボタン
            editBand.Columns[table.BLCodeGuideButtonColumn.ColumnName].Width = 25;		// BLコードガイドボタン
            editBand.Columns[table.GoodsNameColumn.ColumnName].Width = 140;				// 商品名
            editBand.Columns[table.MovingSupliStockColumn.ColumnName].Width = 110;		// 仕入在庫出荷数
            editBand.Columns[table.MovingTrustStockColumn.ColumnName].Width = 85;	    // 受託在庫出荷数
            editBand.Columns[table.TrustRemainCountColumn.ColumnName].Width = 85;		// 受託在庫残数            
            editBand.Columns[table.StockUnitPriceFlColumn.ColumnName].Width = 130;		// 単価
            editBand.Columns[table.GoodsMakerCdColumn.ColumnName].Width = 80; 		    // メーカーコード
            editBand.Columns[table.BLGoodsCodeColumn.ColumnName].Width = 80;		    // ＢＬコード
            //---ADD 2011/04/11----------------------------------------------------------->>>>>
            editBand.Columns[table.SupplierCdColumn.ColumnName].Width = 80;		        // 仕入先 
            editBand.Columns[table.SupplierCdGuideButtonColumn.ColumnName].Width = 25;	// 仕入先コードガイドボタン
            //---ADD 2011/04/11-----------------------------------------------------------<<<<<
            editBand.Columns[table.BfShelfNoColumn.ColumnName].Width = 125;		        // 出庫棚番
            editBand.Columns[table.AfShelfNoColumn.ColumnName].Width = 125;		        // 入庫棚番
            editBand.Columns[table.BfBeforeMoveCountColumn.ColumnName].Width = 125;	    // 出庫前数
            editBand.Columns[table.BfAfterMoveCountColumn.ColumnName].Width = 125;	    // 出庫後数
            editBand.Columns[table.ListPriceFlColumn.ColumnName].Width = 125;		    // 定価
            editBand.Columns[table.ListPriceFlViewColumn.ColumnName].Width = 125;		// 定価
            // --- ADD 2014/04/09 T.Miyamoto ------------------------------>>>>>
            editBand.Columns[table.AfBeforeMoveCountColumn.ColumnName].Width = 125;	    // 入庫前数
            editBand.Columns[table.AfAfterMoveCountColumn.ColumnName].Width = 125;	    // 入庫後数
            // --- ADD 2014/04/09 T.Miyamoto ------------------------------<<<<<

            // 固定列設定
            editBand.Columns[table.StockMoveRowNoColumn.ColumnName].Header.Fixed = true;	// №
            editBand.Columns[table.GoodsNoColumn.ColumnName].Header.Fixed = true;			// 商品コード
            editBand.Columns[table.GoodsNameColumn.ColumnName].Header.Fixed = true;			// 商品名
            editBand.Columns[table.StockMoveRowNoColumn.ColumnName].Header.FixedHeaderIndicator = FixedHeaderIndicator.None;
            editBand.Columns[table.GoodsNoColumn.ColumnName].Header.FixedHeaderIndicator = FixedHeaderIndicator.None;
            editBand.Columns[table.GoodsNameColumn.ColumnName].Header.FixedHeaderIndicator = FixedHeaderIndicator.None;

            // CellAppearance設定
            editBand.Columns[table.StockMoveRowNoColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right;   // 在庫移動行番号(右寄せ)
            editBand.Columns[table.MovingSupliStockColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right; // 移動中仕入在庫数(右寄せ)
            editBand.Columns[table.MovingTrustStockColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right; // 移動中受託在庫数(右寄せ)
            editBand.Columns[table.TrustRemainCountColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right;  // 受託在庫残数(右寄せ)
            editBand.Columns[table.StockUnitPriceFlColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right;        // 単価(右寄せ)
            editBand.Columns[table.GoodsMakerCdColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right;		    // メーカーコード
            editBand.Columns[table.BLGoodsCodeColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right;		    // ＢＬコード
            editBand.Columns[table.SupplierCdColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right;		    // 仕入先 // ADD 2011/04/11
            editBand.Columns[table.BfBeforeMoveCountColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right;	// 出庫前数
            editBand.Columns[table.BfAfterMoveCountColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right;	    // 出庫後数
            editBand.Columns[table.ListPriceFlColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right;		    // 定価
            editBand.Columns[table.ListPriceFlViewColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right;		    // 定価
            // --- ADD 2014/04/09 T.Miyamoto ------------------------------>>>>>
            editBand.Columns[table.AfBeforeMoveCountColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right;	// 入庫前数
            editBand.Columns[table.AfAfterMoveCountColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right;	    // 入庫後数
            // --- ADD 2014/04/09 T.Miyamoto ------------------------------<<<<<

            // ReadOnly設定
            editBand.Columns[table.TrustRemainCountColumn.ColumnName].CellAppearance.BackColor = DISABLE_COLOR;		// 受託在庫残数            
            editBand.Columns[table.BfShelfNoColumn.ColumnName].CellAppearance.BackColor = DISABLE_COLOR;	        // 出庫棚番
            editBand.Columns[table.AfShelfNoColumn.ColumnName].CellAppearance.BackColor = DISABLE_COLOR;	        // 入庫棚番
            editBand.Columns[table.BfBeforeMoveCountColumn.ColumnName].CellAppearance.BackColor = DISABLE_COLOR;    // 出庫前数
            editBand.Columns[table.BfAfterMoveCountColumn.ColumnName].CellAppearance.BackColor = DISABLE_COLOR;	    // 出庫後数
            editBand.Columns[table.ListPriceFlColumn.ColumnName].CellAppearance.BackColor = DISABLE_COLOR;		    // 定価
            // --- ADD 2014/04/09 T.Miyamoto ------------------------------>>>>>
            editBand.Columns[table.AfBeforeMoveCountColumn.ColumnName].CellAppearance.BackColor = DISABLE_COLOR;    // 入庫前数
            editBand.Columns[table.AfAfterMoveCountColumn.ColumnName].CellAppearance.BackColor = DISABLE_COLOR;	    // 入庫後数
            // --- ADD 2014/04/09 T.Miyamoto ------------------------------<<<<<

            // 通常BackColor設定
            editBand.Columns[table.StockMoveRowNoColumn.ColumnName].CellAppearance.BackColor = this.ultraGrid1.DisplayLayout.Override.HeaderAppearance.BackColor;
            editBand.Columns[table.StockMoveRowNoColumn.ColumnName].CellAppearance.BackColor2 = this.ultraGrid1.DisplayLayout.Override.HeaderAppearance.BackColor2;
            editBand.Columns[table.StockMoveRowNoColumn.ColumnName].CellAppearance.BackGradientStyle = this.ultraGrid1.DisplayLayout.Override.HeaderAppearance.BackGradientStyle;
            editBand.Columns[table.StockMoveRowNoColumn.ColumnName].CellAppearance.FontData.Bold = DefaultableBoolean.True;
            editBand.Columns[table.StockMoveRowNoColumn.ColumnName].CellAppearance.ForeColor = this.ultraGrid1.DisplayLayout.Override.HeaderAppearance.ForeColor;
            editBand.Columns[table.StockMoveRowNoColumn.ColumnName].CellAppearance.ForeColorDisabled = this.ultraGrid1.DisplayLayout.Override.HeaderAppearance.ForeColor;

            // 入力許可設定
            editBand.Columns[table.StockMoveRowNoColumn.ColumnName].CellActivation = Activation.Disabled;	// No
            editBand.Columns[table.TrustRemainCountColumn.ColumnName].CellActivation = Activation.NoEdit;	// 受託在庫残数
            editBand.Columns[table.BfShelfNoColumn.ColumnName].CellActivation = Activation.NoEdit;		    // 出庫棚番
            editBand.Columns[table.AfShelfNoColumn.ColumnName].CellActivation = Activation.NoEdit;		    // 入庫棚番
            editBand.Columns[table.BfBeforeMoveCountColumn.ColumnName].CellActivation = Activation.NoEdit;	    // 出庫前数
            editBand.Columns[table.BfAfterMoveCountColumn.ColumnName].CellActivation = Activation.NoEdit;	    // 出庫後数
            editBand.Columns[table.ListPriceFlColumn.ColumnName].CellActivation = Activation.NoEdit;		    // 定価
            // --- ADD 2014/04/09 T.Miyamoto ------------------------------>>>>>
            editBand.Columns[table.AfBeforeMoveCountColumn.ColumnName].CellActivation = Activation.NoEdit;	    // 入庫前数
            editBand.Columns[table.AfAfterMoveCountColumn.ColumnName].CellActivation = Activation.NoEdit;	    // 入庫後数
            // --- ADD 2014/04/09 T.Miyamoto ------------------------------<<<<<

            // Style設定
            editBand.Columns[table.GoodsNoColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;					// 商品コード
            editBand.Columns[table.MakerGuideButtonColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;			// メーカーガイドボタン
            editBand.Columns[table.BLCodeGuideButtonColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;			// BLコードガイドボタン
            editBand.Columns[table.GoodsMakerCdColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;					// メーカーコード
            editBand.Columns[table.BLGoodsCodeColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;					// BLコードコード
            //---ADD 2011/04/11----------------------------------------------------------->>>>>
            editBand.Columns[table.SupplierCdColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;					// 仕入先 
            editBand.Columns[table.SupplierCdGuideButtonColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;	// 仕入先 コードガイドボタン
            //---ADD 2011/04/11-----------------------------------------------------------<<<<<
            editBand.Columns[table.GoodsNoColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;					// 商品名
            editBand.Columns[table.MovingSupliStockColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;			// 仕入在庫出荷数
            editBand.Columns[table.MovingTrustStockColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;			// 受託在庫出荷数
            editBand.Columns[table.StockUnitPriceFlColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;			// 受託在庫出荷数
            editBand.Columns[table.ListPriceFlViewColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;			// 受託在庫出荷数

            // Button用個別設定
            editBand.Columns[table.MakerGuideButtonColumn.ColumnName].AllowRowFiltering = DefaultableBoolean.False;
            editBand.Columns[table.MakerGuideButtonColumn.ColumnName].ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always;
            editBand.Columns[table.MakerGuideButtonColumn.ColumnName].CellButtonAppearance.Image = this._guideButtonImage;
            editBand.Columns[table.MakerGuideButtonColumn.ColumnName].CellButtonAppearance.ImageVAlign = VAlign.Middle;
            editBand.Columns[table.MakerGuideButtonColumn.ColumnName].CellButtonAppearance.ImageHAlign = HAlign.Center;
            editBand.Columns[table.MakerGuideButtonColumn.ColumnName].CellAppearance.Cursor = Cursors.Hand;

            editBand.Columns[table.BLCodeGuideButtonColumn.ColumnName].AllowRowFiltering = DefaultableBoolean.False;
            editBand.Columns[table.BLCodeGuideButtonColumn.ColumnName].ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always;
            editBand.Columns[table.BLCodeGuideButtonColumn.ColumnName].CellButtonAppearance.Image = this._guideButtonImage;
            editBand.Columns[table.BLCodeGuideButtonColumn.ColumnName].CellButtonAppearance.ImageVAlign = VAlign.Middle;
            editBand.Columns[table.BLCodeGuideButtonColumn.ColumnName].CellButtonAppearance.ImageHAlign = HAlign.Center;
            editBand.Columns[table.BLCodeGuideButtonColumn.ColumnName].CellAppearance.Cursor = Cursors.Hand;

            //---ADD 2011/04/11----------------------------------------------------------->>>>>
            editBand.Columns[table.SupplierCdGuideButtonColumn.ColumnName].AllowRowFiltering = DefaultableBoolean.False;
            editBand.Columns[table.SupplierCdGuideButtonColumn.ColumnName].ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always;
            editBand.Columns[table.SupplierCdGuideButtonColumn.ColumnName].CellButtonAppearance.Image = this._guideButtonImage;
            editBand.Columns[table.SupplierCdGuideButtonColumn.ColumnName].CellButtonAppearance.ImageVAlign = VAlign.Middle;
            editBand.Columns[table.SupplierCdGuideButtonColumn.ColumnName].CellButtonAppearance.ImageHAlign = HAlign.Center;
            editBand.Columns[table.SupplierCdGuideButtonColumn.ColumnName].CellAppearance.Cursor = Cursors.Hand;
            //---ADD 2011/04/11-----------------------------------------------------------<<<<<

            // フォーマット設定
            string decimalFormat = "#,##0.00;-#,##0.00;''";
            string codeFormat = "#0;-#0;''";

            editBand.Columns[table.MovingSupliStockColumn.ColumnName].Format = decimalFormat; // 仕入在庫出荷数
            editBand.Columns[table.MovingTrustStockColumn.ColumnName].Format = decimalFormat; // 受託在庫出荷数
            editBand.Columns[table.TrustRemainCountColumn.ColumnName].Format = decimalFormat; // 受託在庫残数
            editBand.Columns[table.StockUnitPriceFlColumn.ColumnName].Format = decimalFormat; // 単価
            editBand.Columns[table.GoodsMakerCdColumn.ColumnName].Format = codeFormat;	    // メーカーコード
            editBand.Columns[table.BLGoodsCodeColumn.ColumnName].Format = codeFormat;        // ＢＬコード
            editBand.Columns[table.SupplierCdColumn.ColumnName].Format = codeFormat;        // 仕入先 // ADD 2011/04/11
            editBand.Columns[table.BfBeforeMoveCountColumn.ColumnName].Format = decimalFormat;	    // 出庫前数
            editBand.Columns[table.BfAfterMoveCountColumn.ColumnName].Format = decimalFormat;	    // 出庫後数
            editBand.Columns[table.ListPriceFlColumn.ColumnName].Format = decimalFormat;		    // 定価
            editBand.Columns[table.ListPriceFlViewColumn.ColumnName].Format = decimalFormat;		    // 定価
            // --- ADD 2014/04/09 T.Miyamoto ------------------------------>>>>>
            editBand.Columns[table.AfBeforeMoveCountColumn.ColumnName].Format = decimalFormat;	    // 入庫前数
            editBand.Columns[table.AfAfterMoveCountColumn.ColumnName].Format = decimalFormat;	    // 入庫後数
            // --- ADD 2014/04/09 T.Miyamoto ------------------------------<<<<<

            int maxLength;
            string targetKey;

            // 品番
            targetKey = editBand.Columns[table.GoodsNoColumn.ColumnName].Key;
            maxLength = uiSetControl1.GetSettingColumnCount(targetKey);
            if (maxLength > 0)
            {
                editBand.Columns[table.GoodsNoColumn.ColumnName].MaxLength = maxLength;
                editBand.Columns[table.GoodsNoColumn.ColumnName].CellAppearance.TextHAlign = uiSetControl1.GetSettingHAlign(targetKey);
            }
            // 品名
            targetKey = editBand.Columns[table.GoodsNameColumn.ColumnName].Key;
            maxLength = uiSetControl1.GetSettingColumnCount(targetKey);
            if (maxLength > 0)
            {
                editBand.Columns[table.GoodsNameColumn.ColumnName].MaxLength = maxLength;
                editBand.Columns[table.GoodsNameColumn.ColumnName].CellAppearance.TextHAlign = uiSetControl1.GetSettingHAlign(targetKey);
            }
            // メーカーコード
            targetKey = editBand.Columns[table.GoodsMakerCdColumn.ColumnName].Key;
            maxLength = uiSetControl1.GetSettingColumnCount(targetKey);
            if (maxLength > 0)
            {
                editBand.Columns[table.GoodsMakerCdColumn.ColumnName].MaxLength = maxLength;
                editBand.Columns[table.GoodsMakerCdColumn.ColumnName].CellAppearance.TextHAlign = uiSetControl1.GetSettingHAlign(targetKey);
            }
            // BLコード
            targetKey = editBand.Columns[table.BLGoodsCodeColumn.ColumnName].Key;
            maxLength = uiSetControl1.GetSettingColumnCount(targetKey);
            if (maxLength > 0)
            {
                editBand.Columns[table.BLGoodsCodeColumn.ColumnName].MaxLength = maxLength;
                editBand.Columns[table.BLGoodsCodeColumn.ColumnName].CellAppearance.TextHAlign = uiSetControl1.GetSettingHAlign(targetKey);
            }
        }

        /// <summary>
        /// 在庫移動データレコードクリア
        /// </summary>
        /// <param name="index">行インデックス</param>
        /// <param name="allFlg">全クリアフラグ(True:全クリア False:一部クリア)</param>
        /// <br>Update Note: 2011/04/11 鄧潘ハン 明細に仕入先を追加する</br>
        private void StockMoveDetailRowClear(int index, bool allFlg)
        {
            // レコードをクリア
            _stockMoveDataTable[index].CreateDateTime = new DateTime();
            _stockMoveDataTable[index].UpdateDateTime = new DateTime();
            _stockMoveDataTable[index].EnterpriseCode = "";
            _stockMoveDataTable[index].FileHeaderGuid = new Guid();
            _stockMoveDataTable[index].UpdEmployeeCode = "";
            _stockMoveDataTable[index].UpdAssemblyId1 = "";
            _stockMoveDataTable[index].UpdAssemblyId2 = "";
            _stockMoveDataTable[index].LogicalDeleteCode = 0;
            _stockMoveDataTable[index].StockMoveFormal = 0;
            _stockMoveDataTable[index].StockMoveSlipNo = 0;
            _stockMoveDataTable[index].StockMoveRowNo = 0;
            _stockMoveDataTable[index].UpdateSecCd = "";
            _stockMoveDataTable[index].BfSectionCode = "";
            _stockMoveDataTable[index].BfEnterWarehCode = "";
            _stockMoveDataTable[index].AfSectionCode = "";
            _stockMoveDataTable[index].AfSectionGuideNm = "";
            _stockMoveDataTable[index].AfEnterWarehCode = "";
            _stockMoveDataTable[index].AfEnterWarehName = "";
            _stockMoveDataTable[index].ShipmentScdlDay = "";
            _stockMoveDataTable[index].ShipmentFixDay = "";
            _stockMoveDataTable[index].ArrivalGoodsDay = "";
            _stockMoveDataTable[index].MoveStatus = 0;
            _stockMoveDataTable[index].StockMvEmpCode = "";
            _stockMoveDataTable[index].StockMvEmpName = "";
            _stockMoveDataTable[index].ShipAgentCd = "";
            _stockMoveDataTable[index].ShipAgentNm = "";
            _stockMoveDataTable[index].MovingTrustStock = 0;
            _stockMoveDataTable[index].ReceiveAgentCd = "";
            _stockMoveDataTable[index].ReceiveAgentNm = "";
            _stockMoveDataTable[index].Outline = "";
            _stockMoveDataTable[index].WarehouseNote1 = "";
            _stockMoveDataTable[index].RowStatus = 0;
            _stockMoveDataTable[index].TrustRemainCount = 0;
            _stockMoveDataTable[index].MovingPrice = 0;
            _stockMoveDataTable[index].FixFlag = false;
            _stockMoveDataTable[index].ArrivalFlag = false;
            _stockMoveDataTable[index].SearchIndexNumber = 0;
            _stockMoveDataTable[index].BfAfterMoveCount = "";
            _stockMoveDataTable[index].BfBeforeMoveCount = "";
            // --- ADD 2014/04/16 T.Miyamoto 入庫前・入庫後数表示対応 システムテスト障害一覧_先行配信分 №75 ----------<<<<<
            _stockMoveDataTable[index].AfAfterMoveCount = "";
            _stockMoveDataTable[index].AfBeforeMoveCount = "";
            // --- ADD 2014/04/16 T.Miyamoto 入庫前・入庫後数表示対応 システムテスト障害一覧_先行配信分 №75 ----------<<<<<
            _stockMoveDataTable[index].BLGoodsCdDerivedNo = 0;
            _stockMoveDataTable[index].BLGoodsFullName = "";
            _stockMoveDataTable[index].BfSectionCode = "";
            _stockMoveDataTable[index].BfEnterWarehCode = "";
            _stockMoveDataTable[index].BfShelfNo = "";
            _stockMoveDataTable[index].AfSectionCode = "";
            _stockMoveDataTable[index].AfSectionGuideNm = "";
            _stockMoveDataTable[index].AfEnterWarehCode = "";
            _stockMoveDataTable[index].AfEnterWarehName = "";
            _stockMoveDataTable[index].AfShelfNo = "";
            _stockMoveDataTable[index].OfferKubun = -1;

            if (allFlg == true)
            {
                _stockMoveDataTable[index].GoodsMakerCd = "";
                _stockMoveDataTable[index].GoodsNo = "";
                _stockMoveDataTable[index].GoodsName = "";
                // --- ADD m.suzuki 2010/04/15 ---------->>>>>
                _stockMoveDataTable[index].GoodsNameKana = "";
                // --- ADD m.suzuki 2010/04/15 ----------<<<<<
                _stockMoveDataTable[index].BLGoodsCode = "";
               //---ADD 2011/04/11----------------------->>>>>
                _stockMoveDataTable[index].SupplierCd = ""; 
                _stockMoveDataTable[index].SupplierSnm = "";
               //---ADD 2011/04/11-----------------------<<<<<
                _stockMoveDataTable[index].MovingSupliStock = 0;
                _stockMoveDataTable[index].BfMovingSupliStock = 0;
                _stockMoveDataTable[index].StockUnitPriceFl = 0;
                _stockMoveDataTable[index].BfStockUnitPriceFl = 0;
                _stockMoveDataTable[index].ListPriceFl = 0;
                _stockMoveDataTable[index].ListPriceFlView = "";
            }
        }

        /// <summary>
        /// セル値変換処理(Object→String)
        /// </summary>
        /// <param name="cellValue">セル値(Object)</param>
        /// <returns>セル値(String型)</returns>
        private string ChangeCellValueToString(object cellValue)
        {
            string targetStrValue = "";

            if ((cellValue == DBNull.Value) || (cellValue == null))
            {
                return targetStrValue;
            }

            targetStrValue = (string)cellValue;

            return targetStrValue;
        }

        /// <summary>
        /// セル値変換処理(Object→Int)
        /// </summary>
        /// <param name="cellValue">セル値(Object)</param>
        /// <returns>セル値(Int型)</returns>
        private int ChangeCellValueToInt(object cellValue)
        {
            int targetIntValue = 0;

            if ((cellValue == DBNull.Value) || (cellValue == null) || ((cellValue.ToString()).Trim() == ""))
            {
                return targetIntValue;
            }

            targetIntValue = int.Parse(cellValue.ToString());

            return targetIntValue;
        }

        /// <summary>
        /// セル値変換処理(Object→Double)
        /// </summary>
        /// <param name="cellValue">セル値(Object)</param>
        /// <returns>セル値(Double型)</returns>
        private double ChangeCellValueToDouble(object cellValue)
        {
            double targetDoubleValue = 0;

            if ((cellValue == DBNull.Value) || (cellValue == null) || ((cellValue.ToString()).Trim() == ""))
            {
                return targetDoubleValue;
            }

            targetDoubleValue = double.Parse(cellValue.ToString());

            return targetDoubleValue;
        }
        // --- ADD 2008/07/14 ---------------------------------------------------------------------<<<<<

        /// <summary>
        /// 明細グリッド設定処理
        /// </summary>
        internal void SettingGrid()
        {
            try
            {
                // 描画を一時停止
                this.ultraGrid1.BeginUpdate();

                //StockMove stockMove = this._stockMoveInputAcs.GetCurrentStockMoveSlip();
                //StockMove stockMove = null;
                //if (stockMove == null) return;

                // 描画が必要な明細件数を取得する。
                int cnt = _stockMoveInputAcs.StockMoveDataTable.Count;

                // 各行ごとの設定
                for (int i = 0; i < cnt; i++)
                {
                    //this.SettingGridRow(i, stockMove);
                    this.SettingGridRow(i);
                }
            }
            finally
            {
                // 描画を開始
                this.ultraGrid1.EndUpdate();
            }
        }

        /// <summary>
        /// グリッド列表示非表示設定処理
        /// </summary>
        /// <param name="statusType">ステータスタイププロパティ</param>
        /// <param name="value">値</param>
        private void SettingGridColVisible(StatusType statusType, int value)
        {
            // すべての列の表示非表示設定
            UltraGridBand editBand = this.ultraGrid1.DisplayLayout.Bands[0];
            if (editBand == null) return;

            // 指定行の全ての列に対して設定を行う。
            foreach (UltraGridColumn col in editBand.Columns)
            {
                bool hidden;
                if (this._stockMoveDetailRowVisibleControl.GetHidden(col.Key, statusType, value, out hidden) == 0)
                {
                    col.Hidden = hidden;
                }
            }
        }

        # region コントロールイベントメソッド
        /// <summary>
        /// コントロールロードイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void InputDetails_Load(object sender, EventArgs e)
        {
            // 画面スキンファイルの読込(デフォルトスキン指定)
            this._controlScreenSkin.LoadSkin();

            // 画面スキン変更
            this._controlScreenSkin.SettingScreenSkin(this);

            // グリッドに対してデータソースを割り当て
            this.ultraGrid1.DataSource = _stockMoveInputAcs.StockMoveDataTable;

            // ボタン初期設定処理
            this.ButtonInitialSetting();

            /* --- DEL 2008/07/14 --------------------------------------------------------------------->>>>>
            // グリッドキーマッピング設定処理
            this.MakeKeyMappingForGrid(this.ultraGrid1);
               --- DEL 2008/07/14 ---------------------------------------------------------------------<<<<<*/

            // クリア処理
            this.Clear();

            //_stockMoveInputAcs.StockMoveDataTable.ColumnChanged += new DataColumnChangeEventHandler(this.StockMoveDetail_ColumnChanged);
        }

        #region DEL 2008/07/14 Partsman用に変更
        /* --- DEL 2008/07/14 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// ボタン初期設定処理
        /// </summary>
        private void ButtonInitialSetting()
        {
            this.RowInsert_ultraButton.ImageList = this._imageList16;
            this.RowDelete_ultraButton.ImageList = this._imageList16;
            this.RowCut_ultraButton.ImageList = this._imageList16;
            this.RowCopy_ultraButton.ImageList = this._imageList16;
            this.RowPaste_ultraButton.ImageList = this._imageList16;
            this.GoodsSearch_ultraButton.ImageList = this._imageList16;

            this.RowInsert_ultraButton.Appearance.Image = (int)Size16_Index.ROWINSERT;
            this.RowDelete_ultraButton.Appearance.Image = (int)Size16_Index.ROWDELETE;
            this.RowCut_ultraButton.Appearance.Image = (int)Size16_Index.ROWCUT;
            this.RowCopy_ultraButton.Appearance.Image = (int)Size16_Index.ROWCOPY;
            this.RowPaste_ultraButton.Appearance.Image = (int)Size16_Index.ROWPASTE;
            this.GoodsSearch_ultraButton.Appearance.Image = (int)Size16_Index.SEARCH;

            this.RowInsert_ultraButton.Enabled = false;
            this.RowDelete_ultraButton.Enabled = false;
            this.RowCut_ultraButton.Enabled = false;
            this.RowCopy_ultraButton.Enabled = false;
            this.RowPaste_ultraButton.Enabled = false;

            this.tToolbarsManager.ImageListSmall = this._imageList16;
        }
           --- DEL 2008/07/14 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/14 Partsman用に変更

        // --- ADD 2008/07/14 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// ボタン初期設定処理
        /// </summary>
        private void ButtonInitialSetting()
        {
            this.RowDelete_ultraButton.ImageList = this._imageList16;
            this.RowDelete_ultraButton.Appearance.Image = (int)Size16_Index.ROWDELETE;
            this.RowDelete_ultraButton.Enabled = false;

            this.tToolbarsManager.ImageListSmall = this._imageList16;
        }
        // --- ADD 2008/07/14 ---------------------------------------------------------------------<<<<<

        # endregion

        # region グリッドボタンイベント

        #region DEL 2008/07/14 使用していないのでコメントアウト
        /* --- DEL 2008/07/14 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 挿入ボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void RowInsert_ultraButton_Click(object sender, EventArgs e)
        {
            // ActiveRowインデックス取得処理
            int rowIndex = this.GetActiveRowIndex();
            if (rowIndex == -1) return;

            // 在庫移動明細行挿入処理
            this._stockMoveInputAcs.InsertStockDetailRow(rowIndex);

            // 明細グリッドセル設定処理
            this.SettingGrid();

            // 次入力可能セル移動処理
            this.MoveNextAllowEditCell(true);
        }
           --- DEL 2008/07/14 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/14 使用していないのでコメントアウト

        /// <summary>
        /// 削除ボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void RowDelete_ultraButton_Click(object sender, EventArgs e)
        {
            if (CheckDeleteRow() == false)
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "削除対象行が存在しません。",
                    0,
                    MessageBoxButtons.OK);
                return;
            }

            if ((this.ultraGrid1.ActiveRow == null) && (this.ultraGrid1.Selected.Rows.Count == 0))
            {
                return;
            }

            // 選択済み在庫移動行番号リスト取得処理
            List<int> selectedStockRowNoList = this.GetSelectedStockMoveRowNoList();
            if (selectedStockRowNoList.Count == 0) return;

            DialogResult dialogResult = TMsgDisp.Show(
                this,
                emErrorLevel.ERR_LEVEL_QUESTION,
                this.Name,
                "選択行を削除してもよろしいですか？",
                0,
                MessageBoxButtons.YesNo,
                MessageBoxDefaultButton.Button1);

            if (dialogResult != DialogResult.Yes)
            {
                return;
            }

            // ActiveRowインデックス取得処理
            int rowIndex = this.GetActiveRowIndex();

            // 在庫移動明細行削除処理
            this._stockMoveInputAcs.DeleteStockMoveDetailRow(selectedStockRowNoList);

            // 明細グリッドセル設定処理
            this.SettingGrid();

            if ((this.ultraGrid1.ActiveCell == null) && (this.ultraGrid1.Rows.Count > rowIndex))
            {
                this.ultraGrid1.ActiveCell = this.ultraGrid1.Rows[rowIndex].Cells[_stockMoveInputAcs.StockMoveDataTable.GoodsNoColumn.ColumnName];

                if ((this.ultraGrid1.ActiveCell.Activation == Activation.AllowEdit) &&
                    (this.ultraGrid1.ActiveCell.Column.CellActivation == Activation.AllowEdit))
                {
                    this.ultraGrid1.PerformAction(UltraGridAction.EnterEditMode);
                }
            }

            // 次入力可能セル移動処理
            this.MoveNextAllowEditCell(true);

            // 移動合計更新デリゲート
            this.TotalPriceSetting();

            // テーブルのコミット
            _stockMoveDataTable.AcceptChanges();

            GetKeyList();
        }

        #region DEL 2008/07/14 使用していないのでコメントアウト
        /* --- DEL 2008/07/14 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 切り取りボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void RowCut_ultraButton_Click(object sender, EventArgs e)
        {
            // 選択済み仕入行番号リスト取得処理
            List<int> selectedStockRowNoList = this.GetSelectedStockMoveRowNoList();
            if (selectedStockRowNoList == null) return;

            // 仕入明細データテーブルRowStatus列初期化処理
            this._stockMoveInputAcs.InitializeStockDetailRowStatusColumn();

            // 仕入明細データテーブルRowStatus列値設定処理
            this._stockMoveInputAcs.SetStockDetailRowStatusColumn(selectedStockRowNoList, StockMoveInputAcs.CODE_ROWSTATUS_CUT);

            // 明細グリッドセル設定処理
            this.SettingGrid();

            // 次入力可能セル移動処理
            this.MoveNextAllowEditCell(true);
        }

        /// <summary>
        /// コピーボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void RowCopy_ultraButton_Click(object sender, EventArgs e)
        {
            // 選択済み移動在庫行番号リスト取得処理
            List<int> selectedStockRowNoList = this.GetSelectedStockMoveRowNoList();
            if (selectedStockRowNoList == null) return;

            // 在庫移動明細データテーブルRowStatus列初期化処理
            this._stockMoveInputAcs.InitializeStockDetailRowStatusColumn();

            // 在庫移動明細データテーブルRowStatus列値設定処理
            this._stockMoveInputAcs.SetStockDetailRowStatusColumn(selectedStockRowNoList, StockMoveInputAcs.CODE_ROWSTATUS_COPY);

            // 明細グリッドセル設定処理
            this.SettingGrid();

            // 次入力可能セル移動処理
            this.MoveNextAllowEditCell(true);
        }

        /// <summary>
        /// 貼り付けボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void RowPaste_ultraButton_Click(object sender, EventArgs e)
        {
            // ActiveRowインデックス取得処理
            int rowIndex = this.GetActiveRowIndex();
            if (rowIndex == -1) return;

            // コピー在庫移動明細行番号取得処理
            List<int> copyStockRowNoList = this._stockMoveInputAcs.GetCopyStockMoveDetailRowNo();
            if (copyStockRowNoList == null) return;

            // 在庫移動明細行貼り付け処理
            this._stockMoveInputAcs.PasteStockMoveDetailRow(copyStockRowNoList, rowIndex);

            // 明細グリッドセル設定処理
            this.SettingGrid();

            // 仕入金額変更後発生イベントコール処理
            //this.StockPriceChangedEventCall();

            // 次入力可能セル移動処理
            this.MoveNextAllowEditCell(true);

            // 移動合計更新デリゲート
            this.TotalPriceSetting();
        }
           --- DEL 2008/07/14 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/14 使用していないのでコメントアウト

        #region DEL 2008/07/14 Partsman用に変更
        /* --- DEL 2008/07/14 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 商品検索ボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void GoodsSearch_ultraButton_Click(object sender, EventArgs e)
        {
            // ヘッダ情報を更新
            this.SetStockMoveHeader();

            // 商品検索ガイド画面のインスタンスを生成
            StockSearchGuide stockSearchGuide = new StockSearchGuide();
                        
            // 商品検索ガイド検索条件データ
            StockSearchPara stockSearchPara = new StockSearchPara();

            // 企業コード
            stockSearchPara.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            // 出庫拠点、出庫倉庫の入力があった場合はそちらを優先(本社機能時のみ入力可能)
            // 拠点コード
            if (_stockMoveHeader.BfSectionCode.Trim() == "")
            {
                stockSearchPara.SectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
                stockSearchGuide.IsFixedSection = true;
            }
            else
            {
                stockSearchPara.SectionCode = _stockMoveHeader.BfSectionCode;
                stockSearchGuide.IsFixedSection = true;
            }

            // 倉庫コード
            if (_stockMoveHeader.BfEnterWarehCode.Trim() == "")
            {
                // 倉庫の指定が無かった場合は条件に含めない。
                stockSearchGuide.IsFixedWarehouseCode = false;
            }
            else
            {
                stockSearchPara.WarehouseCode = _stockMoveHeader.BfEnterWarehCode;
                stockSearchGuide.IsFixedWarehouseCode = true;
            }

            // 商品検索ガイド結果オブジェクト
            object retObj = null;

            // 複数選択可能設定
            stockSearchGuide.IsMultiSelect = false;

            // 商品検索ガイド画面の表示
            stockSearchGuide.ShowGuide(this, StockSearchGuide.emSearchMode.Stock, true, stockSearchPara, out retObj);

            // 何も選択されなかった場合
            if (retObj == null)
            {
                return;
            }
            
            // レスポンスデータ取得
            List<StockExpansion> stockSearchRetList = (List<StockExpansion>)retObj;
            List<Stock> stockSearchRetList = (List<Stock>)retObj;

            // 最新レコード
            int MostNewRecord = 0;

            // 最下レコードを検索
            foreach(StockMoveInputDataSet.StockMoveRow row in _stockMoveDataTable)
            {
                if ( row.GoodsNo != "" )
                {
                    MostNewRecord = row.StockMoveRowNo;
                }
            }
                        
            // グリッドのアクティブセルを取得
            UltraGridCell activeCell = this.ultraGrid1.Rows[MostNewRecord].Cells[42];


            // 在庫移動データテーブルに格納(在庫移動データ関連のみ)
            this.StockMoveDataTableFromStockSearchRet(stockSearchRetList, activeCell);

            ultraGrid1.ActiveCell = activeCell;
            this.ultraGrid1.PerformAction(UltraGridAction.EnterEditMode);

            // 移動合計更新デリゲート
            this.TotalPriceSetting();
        }
           --- DEL 2008/07/14 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/14 Partsman用に変更

        #region DEL
        ///// <summary>
        ///// 在庫移動伝票検索ボタンクリックイベント
        ///// </summary>
        ///// <param name="sender">対象オブジェクト</param>
        ///// <param name="e">イベントパラメータクラス</param>
        //private void StockMoveSlipSearch_ultraButton_Click(object sender, EventArgs e)
        //{
        //    MAZAI04120UD StockMoveSlipSearch = new MAZAI04120UD();

        //    // 結果オブジェクト
        //    object retObj = null;

        //    // 在庫移動伝票検索画面表示
        //    StockMoveSlipSearch.ShowGuide(this, out retObj);

        //    if (_stockMoveDataTable.Count > 0)
        //    {
        //        _stockMoveInputInitAcs.RegistMode = 1;
        //    }
        //    else
        //    {
        //        _stockMoveInputInitAcs.RegistMode = 0;
        //    }
        //}
        #endregion DEL

        #region DEL 2008/07/14 使用していないのでコメントアウト
        /* --- DEL 2008/07/14 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 倉庫備考ボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void WareHouseNote_ultraButton_Click(object sender, EventArgs e)
        {

        }
           --- DEL 2008/07/14 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/14 使用していないのでコメントアウト

        # endregion

        # region ツールバー系イベントハンドラ
        /// <summary>
        /// ツールバーツールクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void tToolbarsManager_Main_ToolClick(object sender, ToolClickEventArgs e)
        {
            // --- CHG 2008/07/14 --------------------------------------------------------------------->>>>>
            switch (e.Tool.Key)
            {
                // 行削除
                case "ButtonTool_RowDelete":
                    {
                        this.RowDelete_ultraButton_Click(this.RowDelete_ultraButton, new EventArgs());
                        break;
                    }
            }
            //switch (e.Tool.Key)
            //{
            //    // 行挿入
            //    case "ButtonTool_RowInsert":
            //        {
            //            this.RowInsert_ultraButton_Click(this.RowInsert_ultraButton, new EventArgs());
            //            break;
            //        }
            //    // 行削除
            //    case "ButtonTool_RowDelete":
            //        {
            //            this.RowDelete_ultraButton_Click(this.RowDelete_ultraButton, new EventArgs());
            //            break;
            //        }
            //    // 行切り取り
            //    case "ButtonTool_RowCut":
            //        {
            //            this.RowCut_ultraButton_Click(this.RowCut_ultraButton, new EventArgs());
            //            break;
            //        }
            //    // 行コピー
            //    case "ButtonTool_RowCopy":
            //        {
            //            this.RowCopy_ultraButton_Click(this.RowCopy_ultraButton, new EventArgs());
            //            break;
            //        }
            //    // 行貼り付け
            //    case "ButtonTool_RowPaste":
            //        {
            //            this.RowPaste_ultraButton_Click(this.RowPaste_ultraButton, new EventArgs());
            //            break;
            //        }
            //}
            // --- CHG 2008/07/14 ---------------------------------------------------------------------<<<<<
        }
        # endregion

        # region グリッド系イベントハンドラ

        #region DEL 2008/07/14 Partsman用に変更
        /* --- DEL 2008/07/14 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// グリッドキーマッピング設定処理
        /// </summary>
        /// <param name="grid">設定対象のグリッド</param>
        private void MakeKeyMappingForGrid(UltraGrid grid)
        {
            GridKeyActionMapping enterMap;

            //----- Enterキー
            enterMap = new GridKeyActionMapping(
                Keys.Enter,
                UltraGridAction.NextCellByTab,
                0,
                UltraGridState.Cell,
                SpecialKeys.All,
                0,
                true);
            this.ultraGrid1.KeyActionMappings.Add(enterMap);

            //----- Shift + Enterキー
            enterMap = new GridKeyActionMapping(
                Keys.Enter,
                UltraGridAction.PrevCellByTab,
                0,
                UltraGridState.Cell,
                SpecialKeys.AltCtrl,
                SpecialKeys.Shift,
                true);
            this.ultraGrid1.KeyActionMappings.Add(enterMap);

            //----- ↑キー
            enterMap = new GridKeyActionMapping(
                Keys.Up,
                UltraGridAction.AboveCell,
                UltraGridState.IsDroppedDown,
                UltraGridState.InEdit,
                SpecialKeys.All,
                0,
                true);
            this.ultraGrid1.KeyActionMappings.Add(enterMap);

            //----- ↑キー (最上段のドロップダウンリストでは何もしない。これが無いとリスト項目が変わってしまうので...)
            enterMap = new GridKeyActionMapping(
                Keys.Up,
                UltraGridAction.ExitEditMode,
                UltraGridState.IsDroppedDown,
                UltraGridState.RowFirst | UltraGridState.HasDropdown,
                SpecialKeys.All,
                0,
                true);
            this.ultraGrid1.KeyActionMappings.Add(enterMap);

            //----- ↓キー (最下段のドロップダウンリストでは何もしない。これが無いとリスト項目が変わってしまうので...)
            enterMap = new GridKeyActionMapping(
                Keys.Down,
                UltraGridAction.ExitEditMode,
                UltraGridState.IsDroppedDown,
                UltraGridState.RowLast | UltraGridState.HasDropdown,
                SpecialKeys.All,
                0,
                true);
            this.ultraGrid1.KeyActionMappings.Add(enterMap);

            //----- ↓キー
            enterMap = new GridKeyActionMapping(
                Keys.Down,
                UltraGridAction.BelowCell,
                UltraGridState.IsDroppedDown,
                UltraGridState.InEdit,
                SpecialKeys.All,
                0,
                true);
            this.ultraGrid1.KeyActionMappings.Add(enterMap);

            //----- 前頁キー
            enterMap = new GridKeyActionMapping(
                Keys.Prior,
                UltraGridAction.PageUpCell,
                0,
                UltraGridState.InEdit,
                SpecialKeys.All,
                0,
                true);
            this.ultraGrid1.KeyActionMappings.Add(enterMap);

            //----- 次頁キー
            enterMap = new GridKeyActionMapping(
                Keys.Next,
                UltraGridAction.PageDownCell,
                0,
                UltraGridState.InEdit,
                SpecialKeys.All,
                0,
                true);
            this.ultraGrid1.KeyActionMappings.Add(enterMap);
        }
        
        /// <summary>
        /// グリッドマウスクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uGrid_Details_MouseClick(object sender, MouseEventArgs e)
        {
            Point nowPos = new Point(e.X, e.Y);
            UIElement objElement = this.ultraGrid1.DisplayLayout.UIElement.ElementFromPoint(nowPos);

            if (objElement != null)
            {
                if (objElement.SelectableItem is UltraGridCell)
                {
                    this.timer1.Enabled = true;
                }
            }
        }

        /// <summary>
        /// グリッドキーダウンイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uGrid_Details_KeyDown(object sender, KeyEventArgs e)
        {
            // グリッド内にアクティブセルがある場合
            if (this.ultraGrid1.ActiveCell != null)
            {
                // アクティブセルの内容を取得
                UltraGridCell cell = this.ultraGrid1.ActiveCell;

                if (e.KeyCode == Keys.Escape)
                {
                    // 在庫異動明細データテーブルRowStatus列初期化処理
                    this._stockMoveInputAcs.InitializeStockDetailRowStatusColumn();

                    // 明細グリッドセル設定処理
                    this.SettingGrid();
                }

                // 編集中であった場合
                if (cell.IsInEditMode)
                {
                    // セルのスタイルにて判定
                    switch (this.ultraGrid1.ActiveCell.StyleResolved)
                    {
                        // テキストボックス・テキストボックス(ボタン付)
                        case Infragistics.Win.UltraWinGrid.ColumnStyle.Edit:
                        case Infragistics.Win.UltraWinGrid.ColumnStyle.EditButton:
                            switch (e.KeyData)
                            {
                                // ←キー
                                case Keys.Left:
                                    if (this.ultraGrid1.ActiveCell.SelStart == 0)
                                    {
                                        this.ultraGrid1.PerformAction(UltraGridAction.PrevCellByTab);
                                        e.Handled = true;
                                    }
                                    break;
                                // →キー
                                case Keys.Right:
                                    if (this.ultraGrid1.ActiveCell.SelStart >= this.ultraGrid1.ActiveCell.Text.Length)
                                    {
                                        this.ultraGrid1.PerformAction(UltraGridAction.NextCellByTab);
                                        e.Handled = true;
                                    }
                                    break;
                                // ↑キー
                                case Keys.Up:
                                    {

                                    }
                                    break;
                                // ↓キー
                                case Keys.Down:
                                    {

                                    }
                                    break;
                            }
                            break;
                        // 上記以外のスタイル
                        default:
                            switch (e.KeyData)
                            {
                                // ←キー
                                case Keys.Left:
                                    {
                                        this.ultraGrid1.PerformAction(UltraGridAction.PrevCellByTab);
                                        e.Handled = true;
                                    }
                                    break;
                                // →キー
                                case Keys.Right:
                                    {
                                        this.ultraGrid1.PerformAction(UltraGridAction.NextCellByTab);
                                        e.Handled = true;
                                    }
                                    break;
                            }
                            break;
                    }
                }

                if (this.ultraGrid1.ActiveCell != null)
                {
                    if (this.ultraGrid1.ActiveCell.Row.Index == 0)
                    {
                        if (e.KeyCode == Keys.Up)
                        {
                            if (this.GridKeyDownTopRow != null)
                            {
                                this.GridKeyDownTopRow(this, new EventArgs());
                                e.Handled = true;
                            }
                        }
                    }
                    else if (this.ultraGrid1.ActiveCell.Row.Index == this.ultraGrid1.Rows.Count - 1)
                    {
                        if (e.KeyCode == Keys.Down)
                        {
                            if (this.GridKeyDownButtomRow != null)
                            {
                                this.GridKeyDownButtomRow(this, new EventArgs());
                                e.Handled = true;
                            }
                        }
                    }
                }
            }
            //else if (this.ultraGrid1.ActiveRow != null)
            //{
            //    UltraGridRow row = this.ultraGrid1.ActiveRow;

            //    switch (e.KeyCode)
            //    {
            //        case Keys.Delete:
            //            {
            //                this.uButton_RowDelete_Click(this.uButton_RowDelete, new EventArgs());
            //                break;
            //            }
            //    }
            //}
        }
           --- DEL 2008/07/14 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/14 Partsman用に変更

        // --- ADD 2008/07/14 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// KeyDown イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <br>Update Note : 2010/11/15 曹文傑 障害改良対応「５，６，７」の対応</br>
        /// <br>Update Note: 2011/04/11 鄧潘ハン 明細に仕入先を追加する</br>
        private void uGrid_Details_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.ultraGrid1.ActiveCell == null)
            {
                return;
            }

            int rowIndex = this.ultraGrid1.ActiveCell.Row.Index;
            string columnKey = this.ultraGrid1.ActiveCell.Column.Key;

            // ヘッダを格納
            SetStockMoveHeader();

            switch (e.KeyCode)
            {
                case Keys.Up:
                    {
                        if (columnKey == "GoodsNo")
                        {
                            this.ultraGrid1.PerformAction(UltraGridAction.ExitEditMode);

                            if (this._logicalDeleteFlg == true)
                            {
                                // 品番にフォーカス
                                this.ultraGrid1.Rows[rowIndex].Cells[_stockMoveInputAcs.StockMoveDataTable.GoodsNoColumn.ColumnName].Activate();
                                this.ultraGrid1.PerformAction(UltraGridAction.EnterEditMode);
                                e.Handled = true;

                                this._logicalDeleteFlg = false;
                                return;
                            }
                            else
                            {
                                // 品名取得
                                string goodsName = ChangeCellValueToString(this.ultraGrid1.Rows[rowIndex].Cells[_stockMoveInputAcs.StockMoveDataTable.GoodsNameColumn.ColumnName].Value);
                                if (goodsName == "")
                                {
                                    if (this._warehouseFocusFlg)
                                    {
                                        // 出庫倉庫コードにフォーカス
                                        setFocus(this._warehouseName);
                                        return;
                                    }
                                }
                            }
                        }
                        else if (columnKey == "MovingSupliStock")
                        {
                            this.ultraGrid1.PerformAction(UltraGridAction.ExitEditMode);

                            if (this._movingSupliStockFlg)
                            {
                                // 出荷数にフォーカス
                                this.ultraGrid1.Rows[rowIndex].Cells[_stockMoveInputAcs.StockMoveDataTable.MovingSupliStockColumn.ColumnName].Activate();
                                this.ultraGrid1.PerformAction(UltraGridAction.EnterEditMode);
                                e.Handled = true;

                                this._movingSupliStockFlg = false;
                                return;
                            }
                        }

                        if (rowIndex == 0)
                        {
                            setFocus("AfSectionCode_tEdit");
                        }
                        else
                        {
                            // ---UPD 2010/11/15---------------->>>>>
                            //this.ultraGrid1.Rows[rowIndex - 1].Cells[columnKey].Activate();
                            //this.ultraGrid1.PerformAction(UltraGridAction.EnterEditMode);
                            //--ADD  2011/05/10---------------------->>>>>>>>>>>>>
                            if (this._sameGoodNoFlg)
                            {
                                this.ultraGrid1.Rows[rowIndex].Cells[columnKey].Activate();
                                this.ultraGrid1.PerformAction(UltraGridAction.EnterEditMode);
                            }
                            //--ADD  2011/05/10----------------------<<<<<<<<<
                            else if (this.ultraGrid1.Rows[rowIndex - 1].Cells[columnKey].CanEnterEditMode)
                            {
                                this.ultraGrid1.Rows[rowIndex - 1].Cells[columnKey].Activate();
                                this.ultraGrid1.PerformAction(UltraGridAction.EnterEditMode);
                            }
                            else
                            {
                                this.ultraGrid1.Rows[rowIndex - 1].Cells["GoodsNo"].Activate();
                                this.ultraGrid1.PerformAction(UltraGridAction.EnterEditMode);
                            }
                            // ---UPD 2010/11/15----------------<<<<<
                        }
                        e.Handled = true;
                        this._sameGoodNoFlg = false;
                        break;
                    }
                case Keys.Down:
                    {
                        if (columnKey == "GoodsNo")
                        {
                            this.ultraGrid1.PerformAction(UltraGridAction.ExitEditMode);

                            if (this._logicalDeleteFlg == true)
                            {
                                // 品番にフォーカス
                                this.ultraGrid1.Rows[rowIndex].Cells[_stockMoveInputAcs.StockMoveDataTable.GoodsNoColumn.ColumnName].Activate();
                                this.ultraGrid1.PerformAction(UltraGridAction.EnterEditMode);
                                e.Handled = true;

                                this._logicalDeleteFlg = false;
                                return;
                            }
                            else
                            {
                                // 品名取得
                                string goodsName = ChangeCellValueToString(this.ultraGrid1.Rows[rowIndex].Cells[_stockMoveInputAcs.StockMoveDataTable.GoodsNameColumn.ColumnName].Value);
                                if (goodsName == "")
                                {
                                    if (this._warehouseFocusFlg)
                                    {
                                        // 出庫倉庫コードにフBfEnterWarehCode_tEditォーカス
                                        setFocus(this._warehouseName);
                                        return;
                                    }
                                }
                            }
                        }
                        else if (columnKey == "MovingSupliStock")
                        {
                            this.ultraGrid1.PerformAction(UltraGridAction.ExitEditMode);

                            if (this._movingSupliStockFlg)
                            {
                                // 出荷数にフォーカス
                                this.ultraGrid1.Rows[rowIndex].Cells[_stockMoveInputAcs.StockMoveDataTable.MovingSupliStockColumn.ColumnName].Activate();
                                this.ultraGrid1.PerformAction(UltraGridAction.EnterEditMode);
                                e.Handled = true;

                                this._movingSupliStockFlg = false;
                                return;
                            }
                        }

                        if (rowIndex == this.ultraGrid1.Rows.Count - 1)
                        {
                            // 備考にフォーカス
                            setFocus("Outline_tEdit");
                        }
                        else
                        {
                            // ---UPD 2010/11/15---------------->>>>>
                            //this.ultraGrid1.Rows[rowIndex + 1].Cells[columnKey].Activate();
                            //this.ultraGrid1.PerformAction(UltraGridAction.EnterEditMode);
                            //--ADD 2011/05/10--------------------->>>>>>
                            if (this._sameGoodNoFlg)
                            {
                                this.ultraGrid1.Rows[rowIndex].Cells[columnKey].Activate();
                                this.ultraGrid1.PerformAction(UltraGridAction.EnterEditMode);
                            }
                            //--ADD 2011/05/10---------------------<<<<<<
                            else if (this.ultraGrid1.Rows[rowIndex + 1].Cells[columnKey].CanEnterEditMode)
                            {
                                this.ultraGrid1.Rows[rowIndex + 1].Cells[columnKey].Activate();
                                this.ultraGrid1.PerformAction(UltraGridAction.EnterEditMode);
                            }
                            else
                            {
                                this.ultraGrid1.Rows[rowIndex + 1].Cells["GoodsNo"].Activate();
                                this.ultraGrid1.PerformAction(UltraGridAction.EnterEditMode);
                            }
                            // ---UPD 2010/11/15----------------<<<<<
                        }
                        e.Handled = true;
                        this._sameGoodNoFlg = false;//ADD 2011/05/10
                        
                        break;
                    }
                case Keys.Left:
                    {
                        if (this.ultraGrid1.ActiveCell.IsInEditMode)
                        {
                            if (this.ultraGrid1.ActiveCell.SelStart == 0)
                            {
                                if (columnKey == "GoodsNo")
                                {
                                    this.ultraGrid1.PerformAction(UltraGridAction.ExitEditMode);

                                    if (this._logicalDeleteFlg == true)
                                    {
                                        // 品番にフォーカス
                                        this.ultraGrid1.Rows[rowIndex].Cells[_stockMoveInputAcs.StockMoveDataTable.GoodsNoColumn.ColumnName].Activate();
                                        this.ultraGrid1.PerformAction(UltraGridAction.EnterEditMode);
                                        e.Handled = true;

                                        this._logicalDeleteFlg = false;
                                        return;
                                    }
                                    else
                                    {
                                        // 品名取得
                                        string goodsName = ChangeCellValueToString(this.ultraGrid1.Rows[rowIndex].Cells[_stockMoveInputAcs.StockMoveDataTable.GoodsNameColumn.ColumnName].Value);
                                        if (goodsName == "")
                                        {
                                            if (this._warehouseFocusFlg)
                                            {
                                                // 出庫倉庫コードにフォーカス
                                                setFocus(this._warehouseName);
                                                return;
                                            }
                                        }
                                    }
                                }
                                else if (columnKey == "MovingSupliStock")
                                {
                                    this.ultraGrid1.PerformAction(UltraGridAction.ExitEditMode);

                                    if (this._movingSupliStockFlg)
                                    {
                                        // 出荷数にフォーカス
                                        this.ultraGrid1.Rows[rowIndex].Cells[_stockMoveInputAcs.StockMoveDataTable.MovingSupliStockColumn.ColumnName].Activate();
                                        this.ultraGrid1.PerformAction(UltraGridAction.EnterEditMode);
                                        e.Handled = true;

                                        this._movingSupliStockFlg = false;
                                        return;
                                    }
                                }

                                if ((rowIndex == 0) && (columnKey == "GoodsNo"))
                                {
                                    this.ultraGrid1.PerformAction(UltraGridAction.EnterEditMode);
                                    e.Handled = true;
                                    break;
                                }
                                //--ADD 2011/05/10----->>>>>>>>
                                else if (this._sameGoodNoFlg)
                                {
                                    this.ultraGrid1.Rows[rowIndex].Cells[columnKey].Activate();
                                    this.ultraGrid1.PerformAction(UltraGridAction.EnterEditMode);
                                }
                                //--ADD 2011/05/10-----<<<<<<<
                                else
                                {
                                    this.ultraGrid1.PerformAction(UltraGridAction.PrevCellByTab);
                                }
                                e.Handled = true;
                            }
                        }
                        else
                        {
                            this.ultraGrid1.PerformAction(UltraGridAction.PrevCellByTab);
                            e.Handled = true;
                        }
                        this._sameGoodNoFlg = false; //--ADD 2011/05/10
                        break;
                    }
                case Keys.Right:
                    {
                        if (this.ultraGrid1.ActiveCell.IsInEditMode)
                        {
                            if (this.ultraGrid1.ActiveCell.SelStart >= this.ultraGrid1.ActiveCell.Text.Length)
                            {
                                if (columnKey == "GoodsNo")
                                {
                                    this.ultraGrid1.PerformAction(UltraGridAction.ExitEditMode);

                                    if (this._logicalDeleteFlg == true)
                                    {
                                        // 品番にフォーカス
                                        this.ultraGrid1.Rows[rowIndex].Cells[_stockMoveInputAcs.StockMoveDataTable.GoodsNoColumn.ColumnName].Activate();
                                        this.ultraGrid1.PerformAction(UltraGridAction.EnterEditMode);
                                        e.Handled = true;

                                        this._logicalDeleteFlg = false;
                                        return;
                                    }
                                    else
                                    {
                                        // 品名取得
                                        string goodsName = ChangeCellValueToString(this.ultraGrid1.Rows[rowIndex].Cells[_stockMoveInputAcs.StockMoveDataTable.GoodsNameColumn.ColumnName].Value);
                                        if (goodsName == "")
                                        {
                                            if (this._warehouseFocusFlg)
                                            {
                                                // 出庫倉庫コードにフォーカス
                                                setFocus(this._warehouseName);
                                                return;
                                            }
                                            //--ADD 2011/05/10----->>>>>>>>
                                            if (this._sameGoodNoFlg)
                                            {
                                                this.ultraGrid1.Rows[rowIndex].Cells[columnKey].Activate();
                                                this.ultraGrid1.PerformAction(UltraGridAction.EnterEditMode);
                                                this._sameGoodNoFlg = false;
                                                return;
                                            }
                                            //--ADD 2011/05/10-----<<<<<<<
                                        }
                                    }
                                }
                                else if (columnKey == "MovingSupliStock")
                                {
                                    this.ultraGrid1.PerformAction(UltraGridAction.ExitEditMode);

                                    if (this._movingSupliStockFlg)
                                    {
                                        // 出荷数にフォーカス
                                        this.ultraGrid1.Rows[rowIndex].Cells[_stockMoveInputAcs.StockMoveDataTable.MovingSupliStockColumn.ColumnName].Activate();
                                        this.ultraGrid1.PerformAction(UltraGridAction.EnterEditMode);
                                        e.Handled = true;

                                        this._movingSupliStockFlg = false;
                                        return;
                                    }
                                }
                                this.ultraGrid1.PerformAction(UltraGridAction.NextCellByTab);
                                e.Handled = true;
                            }
                        }
                        else
                        {
                            this.ultraGrid1.PerformAction(UltraGridAction.NextCellByTab);
                            e.Handled = true;
                        }
                        break;
                    }
                case Keys.Space:
                    {
                        //---UPD 2011/04/11------------------------------------------------------------>>>>>
                        //if ((columnKey == "MakerGuideButton") || (columnKey == "BLCodeGuideButton"))
                        if ((columnKey == "MakerGuideButton") || (columnKey == "BLCodeGuideButton") || (columnKey == "SupplierCdGuideButton"))
                        //---UPD 2011/04/11------------------------------------------------------------<<<<<
                        {
                            ultraGrid1_ClickCellButton(this.ultraGrid1, new CellEventArgs(this.ultraGrid1.ActiveCell));
                        }
                        break;
                    }
                case Keys.Escape:
                    {
                        if (ultraGrid1.ActiveCell.IsInEditMode)
                        {
                            UltraGridCell cell = ultraGrid1.ActiveCell;
                            ultraGrid1.ActiveCell = null;
                            if (cell.Row.Index != ultraGrid1.Rows.Count - 1)
                            {
                                ultraGrid1.Rows[cell.Row.Index + 1].Activate();
                            }
                            else
                            {
                                ultraGrid1.Rows[cell.Row.Index - 1].Activate();
                            }
                            ultraGrid1.Rows[cell.Row.Index].Activate();
                            ultraGrid1.ActiveCell = cell;
                            this.ultraGrid1.PerformAction(UltraGridAction.EnterEditMode);//--ADD 2011/05/10--
                            e.Handled = true;
                        }
                        break;
                    }
            }
        }

        /// <summary>
        /// グリッドキープレスイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <br>Update Note: 2011/04/11 鄧潘ハン 明細に仕入先を追加する</br>
        private void uGrid_Details_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (this.ultraGrid1.ActiveCell == null)
            {
                return;
            }

            UltraGridCell cell = this.ultraGrid1.ActiveCell;

            if (cell.IsInEditMode)
            {
                // UI設定を参照
                if (uiSetControl1.CheckMatchingSet(cell.Column.Key, e.KeyChar) == false)
                {
                    e.Handled = true;
                    return;
                }

                string retText;
                string targetText = this.ultraGrid1.ActiveCell.Text;
                this.ultraGrid1.PerformAction(UltraGridAction.EnterEditMode);

                if (cell.Column.Key == _stockMoveInputAcs.StockMoveDataTable.StockUnitPriceFlColumn.ColumnName)
                {
                    // ActiveCellが単価の場合
                    
                    // 「Backspace」キーを押された時
                    if ((byte)e.KeyChar == (byte)'\b')
                    {
                        return;
                    }
                    // セルのテキストが選択されている場合
                    if (this.ultraGrid1.ActiveCell.SelText == targetText)
                    {
                        // 数値のみ入力可
                        if ((byte)e.KeyChar < (byte)'0' || (byte)'9' < (byte)e.KeyChar)
                        {
                            e.KeyChar = '\0';
                        }
                    }
                    else
                    {
                        // カンマ、ピリオド削除
                        RemoveCommaPeriod(targetText, out retText, true);

                        // 文字数が9文字だったら入力不可
                        if (retText.Length == 9)
                        {
                            e.KeyChar = '\0';
                        }
                        else
                        {
                            // 数値以外の時
                            if ((byte)e.KeyChar < (byte)'0' || (byte)'9' < (byte)e.KeyChar)
                            {
                                // 入力値の1文字目は「,」「.」不可
                                if (targetText == "")
                                {
                                    e.KeyChar = '\0';
                                }
                                else
                                {
                                    if (targetText.IndexOf(".") >= 0)
                                    {
                                        e.KeyChar = '\0';
                                    }

                                    if (targetText[targetText.Length - 1].ToString() == ",")
                                    {
                                        e.KeyChar = '\0';
                                    }

                                    // カンマ、ピリオド削除
                                    RemoveCommaPeriod(targetText, out retText, true);

                                    if (retText.Length == 7)
                                    {
                                        if ((byte)e.KeyChar != '.')
                                        {
                                            e.KeyChar = '\0';
                                        }
                                    }

                                    // 「,」「.」は入力可
                                    if (((byte)e.KeyChar == ',') || ((byte)e.KeyChar == '.'))
                                    {
                                        return;
                                    }
                                    else
                                    {
                                        e.KeyChar = '\0';
                                    }
                                }
                            }
                            else
                            {
                                if (targetText.IndexOf(".") >= 0)
                                {
                                    // 小数点取得
                                    GetDecimal(targetText, out retText);

                                    if (retText.Length == 2)
                                    {
                                        e.KeyChar = '\0';
                                    }
                                }
                                else
                                {
                                    // カンマ、ピリオド削除
                                    RemoveCommaPeriod(targetText, out retText, true);

                                    if (retText.Length == 7)
                                    {
                                        e.KeyChar = '\0';
                                    }
                                }
                            }
                        }
                    }
                }
                else if ((cell.Column.Key == _stockMoveInputAcs.StockMoveDataTable.MovingSupliStockColumn.ColumnName ||
                          cell.Column.Key == _stockMoveInputAcs.StockMoveDataTable.MovingTrustStockColumn.ColumnName))
                {
                    // ActiveCellが出荷数の場合

                    // 「Backspace」キーを押された時
                    if ((byte)e.KeyChar == (byte)'\b')
                    {
                        return;
                    }
                    // セルのテキストが選択されている場合
                    if (this.ultraGrid1.ActiveCell.SelText == targetText)
                    {
                        // 数値のみ入力可
                        if ((byte)e.KeyChar < (byte)'0' || (byte)'9' < (byte)e.KeyChar)
                        {
                            e.KeyChar = '\0';
                        }
                    }
                    else
                    {
                        // カンマ、ピリオド削除
                        RemoveCommaPeriod(targetText, out retText, true);

                        // 文字数が9文字だったら入力不可
                        if (retText.Length == 9)
                        {
                            e.KeyChar = '\0';
                        }
                        else
                        {
                            // 数値以外の時
                            if ((byte)e.KeyChar < (byte)'0' || (byte)'9' < (byte)e.KeyChar)
                            {
                                // 入力値の1文字目は「,」「.」不可
                                if (targetText == "")
                                {
                                    e.KeyChar = '\0';
                                }
                                else
                                {
                                    if (targetText.IndexOf(".") >= 0)
                                    {
                                        e.KeyChar = '\0';
                                    }

                                    if (targetText[targetText.Length - 1].ToString() == ",")
                                    {
                                        e.KeyChar = '\0';
                                    }

                                    // カンマ、ピリオド削除
                                    RemoveCommaPeriod(targetText, out retText, true);

                                    if (retText.Length == 7)
                                    {
                                        if ((byte)e.KeyChar != '.')
                                        {
                                            e.KeyChar = '\0';
                                        }
                                    }

                                    // 「,」「.」は入力可
                                    if (((byte)e.KeyChar == ',') || ((byte)e.KeyChar == '.'))
                                    {
                                        return;
                                    }
                                    else
                                    {
                                        e.KeyChar = '\0';
                                    }
                                }
                            }
                            else
                            {
                                if (targetText.IndexOf(".") >= 0)
                                {
                                    // 小数点取得
                                    GetDecimal(targetText, out retText);

                                    if (retText.Length == 2)
                                    {
                                        e.KeyChar = '\0';
                                    }
                                }
                                else
                                {
                                    // カンマ、ピリオド削除
                                    RemoveCommaPeriod(targetText, out retText, true);

                                    if (retText.Length == 7)
                                    {
                                        e.KeyChar = '\0';
                                    }
                                }
                            }
                        }
                    }
                }
                else if (cell.Column.Key == _stockMoveInputAcs.StockMoveDataTable.ListPriceFlViewColumn.ColumnName)
                {
                    // 「Backspace」キーを押された時
                    if ((byte)e.KeyChar == (byte)'\b')
                    {
                        return;
                    }

                    // ActiveCellが標準価格の場合
                    // セルのテキストが選択されている場合
                    if (this.ultraGrid1.ActiveCell.SelText == targetText)
                    {
                        // 数値のみ入力可
                        if ((byte)e.KeyChar < (byte)'0' || (byte)'9' < (byte)e.KeyChar)
                        {
                            e.KeyChar = '\0';
                        }
                    }
                    else
                    {
                        // カンマ、ピリオド削除
                        RemoveCommaPeriod(targetText, out retText, true);

                        // 文字数が7文字だったら入力不可
                        if (retText.Length == 7)
                        {
                            e.KeyChar = '\0';
                        }
                        else
                        {
                            // 数値以外の時
                            if ((byte)e.KeyChar < (byte)'0' || (byte)'9' < (byte)e.KeyChar)
                            {
                                // 入力値の1文字目は「,」不可
                                if (targetText == "")
                                {
                                    e.KeyChar = '\0';
                                }
                                else
                                {
                                    // 「,」は入力可
                                    if ((byte)e.KeyChar != ',')
                                    {
                                        e.KeyChar = '\0';
                                    }

                                    if (targetText[targetText.Length - 1].ToString() == ",")
                                    {
                                        e.KeyChar = '\0';
                                    }
                                }
                            }
                        }
                    }
                }
                //---ADD 2011/04/11----------------------------------------------------------->>>>>
                else if (cell.Column.Key == _stockMoveInputAcs.StockMoveDataTable.SupplierCdColumn.ColumnName)
                {
                    // 「Backspace」キーを押された時
                    if ((byte)e.KeyChar == (byte)'\b')
                    {
                        return;
                    }

                    // ActiveCellが標準価格の場合
                    // セルのテキストが選択されている場合
                    if (this.ultraGrid1.ActiveCell.SelText == targetText)
                    {
                        // 数値のみ入力可
                        if ((byte)e.KeyChar < (byte)'0' || (byte)'9' < (byte)e.KeyChar)
                        {
                            e.KeyChar = '\0';
                        }
                    }
                    else
                    {
                        // カンマ、ピリオド削除
                        RemoveCommaPeriod(targetText, out retText, true);

                        // 文字数が7文字だったら入力不可
                        if (retText.Length == 6)
                        {
                            e.KeyChar = '\0';
                        }
                        else
                        {
                            // 数値以外の時
                            if ((byte)e.KeyChar < (byte)'0' || (byte)'9' < (byte)e.KeyChar)
                            {
                                // 入力値の1文字目は「,」不可
                                if (targetText == "")
                                {
                                    e.KeyChar = '\0';
                                }
                                else
                                {
                                    // 「,」は入力可
                                    if ((byte)e.KeyChar != ',')
                                    {
                                        e.KeyChar = '\0';
                                    }

                                    if (targetText[targetText.Length - 1].ToString() == ",")
                                    {
                                        e.KeyChar = '\0';
                                    }
                                }
                            }
                        }
                    }
                }
                //---ADD 2011/04/11-----------------------------------------------------------<<<<<
            }
        }

        /// <summary>
        /// グリッドセルアクティブ後発生イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uGrid_Details_AfterCellActivate(object sender, EventArgs e)
        {
            if (this.ultraGrid1.ActiveCell == null) return;
            UltraGridCell cell = this.ultraGrid1.ActiveCell;

            if (getSlipNo() == "")
            {
                if (!this._deleteFlg)
                {
                    this.RowDelete_ultraButton.Enabled = true;
                }
            }

            // 横スクロールバー位置設定
            if (cell.Column.Key == _stockMoveInputAcs.StockMoveDataTable.GoodsNoColumn.ColumnName)
            {
                enterGoodsNoColumn(true);
                this.ultraGrid1.DisplayLayout.ColScrollRegions[0].Position = 0;
            }
            else
            {
                enterGoodsNoColumn(false);
            }
            //--ADD 2011/05/10--->>>>>>>>>
            if (this._sameGoodNoFlg)
            {

                this.ultraGrid1.Rows[_index].Cells[_key].Activate();
                this.ultraGrid1.PerformAction(UltraGridAction.EnterEditMode);
                this._sameGoodNoFlg = false;
            }
            //--ADD 2011/05/10---<<<<<<<<
        }

        /// <summary>
        /// グリッド行アクティブ後発生イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uGrid_Details_AfterRowActivate(object sender, EventArgs e)
        {
            if (this.ultraGrid1.ActiveRow == null) return;
            UltraGridRow row = this.ultraGrid1.ActiveRow;

            if (!this._deleteFlg)
            {
                this.RowDelete_ultraButton.Enabled = true;
            }
            //--ADD 2011/05/10--->>>>>>>>>
            if (this._sameGoodNoFlg)
            {

                this.ultraGrid1.Rows[_index].Cells[_key].Activate();
                this.ultraGrid1.PerformAction(UltraGridAction.EnterEditMode);

            }
            //--ADD 2011/05/10---<<<<<<<<

        }
        // --- ADD 2008/07/14 ---------------------------------------------------------------------<<<<<

        #region DEL 2008/07/14 Partsman用に変更
        /* --- DEL 2008/07/14 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// グリッドキープレスイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uGrid_Details_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (this.ultraGrid1.ActiveCell == null) return;
            UltraGridCell cell = this.ultraGrid1.ActiveCell;

            // ActiveCellが単価の場合
            if (cell.Column.Key == _stockMoveInputAcs.StockMoveDataTable.StockUnitPriceFlColumn.ColumnName)
            {
                // 編集モード中？
                if (cell.IsInEditMode)
                {
                    if (!this.KeyPressNumCheck(12, 2, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, true))
                    {
                        e.Handled = true;
                        return;
                    }
                }
            }
            // ActiveCellが出荷数の場合
            else if (cell.Column.Key == _stockMoveInputAcs.StockMoveDataTable.MovingSupliStockColumn.ColumnName ||
                     cell.Column.Key == _stockMoveInputAcs.StockMoveDataTable.MovingTrustStockColumn.ColumnName)
            {
                // 編集モード中？
                if (cell.IsInEditMode)
                {
                    if (!this.KeyPressNumCheck(12, 2, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false))
                    {
                        e.Handled = true;
                        return;
                    }
                }
            }
            // ActiveCellが商品ガイドボタンの場合
            else if (e.KeyChar == (Char)Keys.Space && cell.Column.Key == _stockMoveDataTable.GoodsGuideButtonColumn.ColumnName)
            {
                timer1.Enabled = true;
            }
        }
        
        /// <summary>
        /// 数値入力チェック処理
        /// </summary>
        /// <param name="keta">桁数(マイナス符号を含まず)</param>
        /// <param name="priod">小数点以下桁数</param>
        /// <param name="prevVal">現在の文字列</param>
        /// <param name="key">入力されたキー値</param>
        /// <param name="selstart">カーソル位置</param>
        /// <param name="sellength">選択文字長</param>
        /// <param name="minusFlg">マイナス入力可？</param>
        /// <returns>true=入力可,false=入力不可</returns>
        private bool KeyPressNumCheck(int keta, int priod, string prevVal, char key, int selstart, int sellength, Boolean minusFlg)
        {
            // 制御キーが押された？
            if (Char.IsControl(key))
            {
                return true;
            }
            // 数値以外は、ＮＧ
            if (!Char.IsDigit(key))
            {
                // 小数点または、マイナス以外
                if ((key != '.') && (key != '-'))
                {
                    return false;
                }
            }

            // キーが押されたと仮定した場合の文字列を生成する。
            string _strResult = "";
            if (sellength > 0)
            {
                _strResult = prevVal.Substring(0, selstart) + prevVal.Substring(selstart + sellength, prevVal.Length - (selstart + sellength));
            }
            else
            {
                _strResult = prevVal;
            }

            // マイナスのチェック
            if (key == '-')
            {
                if ((minusFlg == false) || (selstart > 0) || (_strResult.IndexOf('-') != -1))
                {
                    return false;
                }
            }

            // 小数点のチェック
            if (key == '.')
            {
                if ((priod <= 0) || (_strResult.IndexOf('.') != -1))
                {
                    return false;
                }
            }
            // キーが押された結果の文字列を生成する。
            _strResult = prevVal.Substring(0, selstart)
                + key
                + prevVal.Substring(selstart + sellength, prevVal.Length - (selstart + sellength));

            // 桁数チェック！
            if (_strResult.Length > keta)
            {
                if (_strResult[0] == '-')
                {
                    if (_strResult.Length > (keta + 1))
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            
            // 小数点以下のチェック
            if (priod > 0)
            {
                // 小数点の位置決定
                int _pointPos = _strResult.IndexOf('.');

                // 整数部に入力可能な桁数を決定！
                int _Rketa = (_strResult[0] == '-') ? keta - priod : keta - priod - 1;
                // 整数部の桁数をチェック
                if (_pointPos != -1)
                {
                    if (_pointPos > _Rketa)
                    {
                        return false;
                    }
                }
                else
                {
                    if (_strResult.Length > _Rketa)
                    {
                        return false;
                    }
                }

                // 小数部の桁数をチェック
                if (_pointPos != -1)
                {
                    // 小数部の桁数を計算
                    int _priketa = _strResult.Length - _pointPos - 1;
                    if (priod < _priketa)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// グリッドセルアクティブ後発生イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uGrid_Details_AfterCellActivate(object sender, EventArgs e)
        {
            if (this.ultraGrid1.ActiveCell == null) return;
            UltraGridCell cell = this.ultraGrid1.ActiveCell;

            // 行操作ボタンの有効無効を設定する
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //string goodsCode = _stockMoveInputAcs.StockMoveDataTable[cell.Row.Index].GoodsCode.ToString();
            string goodsCode = _stockMoveInputAcs.StockMoveDataTable[cell.Row.Index].GoodsNo.ToString();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            string goodsName = _stockMoveInputAcs.StockMoveDataTable[cell.Row.Index].GoodsName;

            if (goodsName == "")
            {
                this.RowCut_ultraButton.Enabled = false;
                this.RowCopy_ultraButton.Enabled = false;
            }
            else
            {
                this.RowCut_ultraButton.Enabled = true;
                this.RowCopy_ultraButton.Enabled = true;
            }

            // コピー仕入明細行存在チェック処理
            if (this._stockMoveInputAcs.ExistCopyStockMoveDetailRow())
            {
                this.RowPaste_ultraButton.Enabled = true;
            }
            else
            {
                this.RowPaste_ultraButton.Enabled = false;
            }

            if (getSlipNo() == "")
            {
                this.RowInsert_ultraButton.Enabled = true;
                this.RowDelete_ultraButton.Enabled = true;
            }

            // ガイドボタンの有効無効を設定する
            //if ((cell.Column.Key == this._stockDetailDataTable.GoodsCodeColumn.ColumnName) ||
            //    (cell.Column.Key == this._stockDetailDataTable.GoodsGuideButtonColumn.ColumnName) ||
            //    (cell.Column.Key == this._stockDetailDataTable.GoodsNameColumn.ColumnName) ||
            //    (cell.Column.Key == this._stockDetailDataTable.WarehouseCodeColumn.ColumnName) ||
            //    (cell.Column.Key == this._stockDetailDataTable.WarehouseNameColumn.ColumnName))
            //{
            //    this.uButton_Guide.Enabled = true;
            //}
            //else
            //{
            //    this.uButton_Guide.Enabled = false;
            //}

            // 横スクロールバー位置設定
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //if (cell.Column.Key == _stockMoveInputAcs.StockMoveDataTable.GoodsCodeColumn.ColumnName)
            if (cell.Column.Key == _stockMoveInputAcs.StockMoveDataTable.GoodsNoColumn.ColumnName)
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            {
                this.ultraGrid1.DisplayLayout.ColScrollRegions[0].Position = 0;
            }

            if (cell.Column.Key == _stockMoveInputAcs.StockMoveDataTable.GoodsNoColumn.ColumnName)
            {
                enterGoodsNoColumn(true);
            }
            else
            {
                enterGoodsNoColumn(false);
            }
        }
           --- DEL 2008/07/14 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/14 Partsman用に変更

        #region DEL 2008/07/14 Partsman用に変更
        /* --- DEL 2008/07/14 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// グリッドセルアップデート後イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uGrid_Details_AfterCellUpdate(object sender, CellEventArgs e)
        {
            _stockMoveDataTable.BeginLoadData();

            if (e.Cell == null || e.Cell.Value == null) return;

            UltraGridCell activeCell = e.Cell;
            
            // セルの内容が<DBNull>かつそのデータ型がInt32,Int64,doubleだった場合、
            // セルの内容を「0」にする。
            if (e.Cell.Value is DBNull)
            {
                if ((e.Cell.Column.DataType == typeof(Int32)) ||
                    (e.Cell.Column.DataType == typeof(Int64)) ||
                    (e.Cell.Column.DataType == typeof(double)))
                {
                    e.Cell.Value = 0;
                }
            }

            bool isInGoodsNo = (activeCell.Column.Key == _stockMoveInputAcs.StockMoveDataTable.GoodsNoColumn.ColumnName);
            bool isInMakerCd = ( activeCell.Column.Key == _stockMoveInputAcs.StockMoveDataTable.GoodsMakerCdColumn.ColumnName );

            // ActiveCellが商品番号またはメーカーコードの場合
            if ( isInGoodsNo || isInMakerCd ) 
            {
                // ヘッダを格納
                SetStockMoveHeader();

                string goodsNo = "";
                int goodsMakerCd = 0;
                try {
                    goodsNo = _stockMoveInputAcs.StockMoveDataTable[activeCell.Row.Index].GoodsNo;
                }
                catch {
                }
                try {
                    goodsMakerCd = _stockMoveInputAcs.StockMoveDataTable[activeCell.Row.Index].GoodsMakerCd;
                }
                catch {
                }

                // 商品コードが入力されていた場合
                if ( isInGoodsNo && !String.IsNullOrEmpty(goodsNo) || 
                     isInMakerCd && goodsMakerCd != 0 )
                {
                    // 在庫検索呼び出し
                    if (CallStockSearch(activeCell, goodsNo) == false)
                    {
                        return;
                    }
                }
                // 商品コードの入力情報が無かった場合
                else
                {
                    // 行内容クリア
                    ClearRecordInput(activeCell.Row.Index);
                }
            }

            // ActiveCellが仕入在庫出荷数の場合
            else if (activeCell.Column.Key == _stockMoveInputAcs.StockMoveDataTable.MovingSupliStockColumn.ColumnName)
            {
                if (CheckInputMovingSupliStock(activeCell) == false) return;
            }

            // ActiveCellが受託在庫出荷数の場合
            else if (activeCell.Column.Key == _stockMoveInputAcs.StockMoveDataTable.MovingTrustStockColumn.ColumnName)
            {
                if ( CheckInputMovingTrustStock(activeCell) == false ) return;
            }

            _stockMoveDataTable.EndLoadData();

            // テーブル更新フラグをTrueにする。
            this.tableUpdateFlg = true;

            // 移動合計更新デリゲート
            this.TotalPriceSetting();
        }

        /// <summary>
        /// グリッドセルアップデート後イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : グリッドセルアップデート後に発生します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/07/14</br>
        /// </remarks>
        private void uGrid_Details_AfterCellUpdate(object sender, CellEventArgs e)
        {
            try
            {
                this._stockMoveDataTable.BeginLoadData();

                if (e.Cell == null || e.Cell.Value == null)
                {
                    return;
                }

                UltraGridCell activeCell = e.Cell;

                if (activeCell.Column.DataType == typeof(string))
                {
                    // セル値更新
                    this.ultraGrid1.AfterCellUpdate -= uGrid_Details_AfterCellUpdate;

                    activeCell.Value = uiSetControl1.GetZeroPaddedText(activeCell.Column.Key, activeCell.Value.ToString());

                    this.ultraGrid1.AfterCellUpdate += uGrid_Details_AfterCellUpdate;
                }

                bool isInGoodsNo = (activeCell.Column.Key == this._stockMoveInputAcs.StockMoveDataTable.GoodsNoColumn.ColumnName);
                bool isInMakerCd = (activeCell.Column.Key == this._stockMoveInputAcs.StockMoveDataTable.GoodsMakerCdColumn.ColumnName);

                if (activeCell.Column.Key == this._stockMoveInputAcs.StockMoveDataTable.GoodsNoColumn.ColumnName)
                {
                    // 品番取得
                    string goodsNo = this._stockMoveInputAcs.StockMoveDataTable[activeCell.Row.Index].GoodsNo;
                    if (String.IsNullOrEmpty(goodsNo) == true)
                    {
                        this._warehouseFocusFlg = false;

                        // 行内容クリア
                        ClearRecordInput(activeCell.Row.Index);
                    }
                    else
                    {
                        // ヘッダを格納
                        SetStockMoveHeader();

                        // メーカーコード取得
                        int goodsMakerCd = this._stockMoveInputAcs.StringToInt(this._stockMoveInputAcs.StockMoveDataTable[activeCell.Row.Index].GoodsMakerCd);

                        // 商品検索呼び出し
                        if (SearchPartsFromGoodsNo(activeCell, goodsNo, goodsMakerCd) == false)
                        {
                            return;
                        }
                    }
                }
                else if (activeCell.Column.Key == this._stockMoveInputAcs.StockMoveDataTable.GoodsMakerCdColumn.ColumnName)
                {
                    // メーカーコード取得
                    int goodsMakerCd = this._stockMoveInputAcs.StringToInt(this._stockMoveInputAcs.StockMoveDataTable[activeCell.Row.Index].GoodsMakerCd);

                    if (goodsMakerCd == 0)
                    {
                        this._warehouseFocusFlg = false;

                        // 行内容クリア
                        ClearRecordInput(activeCell.Row.Index);
                    }
                    else
                    {
                        // 品番取得
                        string goodsNo = this._stockMoveInputAcs.StockMoveDataTable[activeCell.Row.Index].GoodsNo;

                        if (String.IsNullOrEmpty(goodsNo) != true)
                        {
                            // ヘッダを格納
                            SetStockMoveHeader();

                            // 商品検索呼び出し
                            if (SearchPartsFromGoodsNo(activeCell, goodsNo, goodsMakerCd) == false)
                            {
                                return;
                            }
                        }
                    }
                }
                // ActiveCellが仕入在庫出荷数の場合
                else if (activeCell.Column.Key == this._stockMoveInputAcs.StockMoveDataTable.MovingSupliStockColumn.ColumnName)
                {
                    string goodsNo = this._stockMoveInputAcs.StockMoveDataTable[activeCell.Row.Index].GoodsNo;
                    int goodsMakerCd = this._stockMoveInputAcs.StringToInt(this._stockMoveInputAcs.StockMoveDataTable[activeCell.Row.Index].GoodsMakerCd);

                    // 品番もしくはメーカーコードが未入力の場合
                    if ((String.IsNullOrEmpty(goodsNo) == true) || (goodsMakerCd == 0))
                    {
                        return;
                    }

                    // 商品データがユーザーデータ以外の場合
                    int offerKubun = this._stockMoveInputAcs.StockMoveDataTable[activeCell.Row.Index].OfferKubun;
                    if (offerKubun != 0)
                    {
                        return;
                    }

                    if (CheckInputMovingSupliStock(activeCell) == false) return;
                }
                // ActiveCellが標準価格の場合
                else if (activeCell.Column.Key == this._stockMoveInputAcs.StockMoveDataTable.ListPriceFlViewColumn.ColumnName)
                {
                    if ((activeCell.Value == DBNull.Value) || (activeCell.Value == null) || ((string)activeCell.Value == ""))
                    {
                        return;
                    }

                    bool bStatus;
                    double listPrice;
                    bStatus = double.TryParse((string)activeCell.Value, out listPrice);
                    if (!bStatus)
                    {
                        return;
                    }

                    // セル値更新
                    this.ultraGrid1.AfterCellUpdate -= uGrid_Details_AfterCellUpdate;

                    activeCell.Value = listPrice.ToString("###,###");

                    this.ultraGrid1.AfterCellUpdate += uGrid_Details_AfterCellUpdate;
                }
            }
            finally
            {
                this._stockMoveDataTable.EndLoadData();
            }

            // テーブル更新フラグをTrueにする。
            this.tableUpdateFlg = true;

            // 移動合計更新デリゲート
            this.TotalPriceSetting();
        }
           --- DEL 2008/07/14 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/14 Partsman用に変更

        # region ■■　明細部セル更新の各種処理　■■

        #region DEL 2008/07/14 Partsman用に変更
        /* --- DEL 2008/07/14 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 在庫検索呼び出し（商品番号・メーカー入力）
        /// </summary>
        private bool CallStockSearch(UltraGridCell activeCell,string  goodsNo)
        {
            _errGoodsNo = false;

            // 商品検索ガイド画面のインスタンスを生成
            StockSearchGuide stockSearchGuide = new StockSearchGuide();

            // 商品検索ガイド検索条件データ
            StockSearchPara stockSearchPara = new StockSearchPara();

            //---------------------------------------------------------------
            // パラメータ指定
            //---------------------------------------------------------------

            // 企業コード
            stockSearchPara.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            // 出庫拠点、出庫倉庫の入力があった場合はそちらを優先(本社機能時のみ入力可能)
            // 拠点コード
            if ( _stockMoveHeader.BfSectionCode.Trim() == "" ) {
                //stockSearchPara.SectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
            }
            else {
                stockSearchPara.SectionCode = _stockMoveHeader.BfSectionCode;
                stockSearchGuide.IsFixedSection = true;
            }

            // 倉庫コード
            if ( _stockMoveHeader.BfEnterWarehCode.Trim() == "" ) {
                // 倉庫の指定が無かった場合は条件に含めない。
            }
            else {
                stockSearchPara.WarehouseCode = _stockMoveHeader.BfEnterWarehCode;
            }

            // ゼロ在庫表示
            // 0:表示する 1:表示しない
            stockSearchPara.ZeroStckDsp = 1;

            // 商品コード検索タイプ(0:完全一致,1:前方一致検索,2:後方一致検索,3:曖昧検索)
            // 完全一致判別
            int targetIndex = goodsNo.IndexOf("*");

            // 完全一致
            if ( targetIndex == -1 ) {
                stockSearchPara.GoodsNoSrchTyp = 0;
            }
            // 曖昧検索
            else if ( goodsNo.StartsWith("*") && goodsNo.EndsWith("*") ) {
                stockSearchPara.GoodsNoSrchTyp = 3;
                goodsNo = goodsNo.Replace("*", "");
            }
            // 前方一致
            else if ( goodsNo.EndsWith("*") ) {
                stockSearchPara.GoodsNoSrchTyp = 1;
                goodsNo = goodsNo.Replace("*", "");
            }
            // 後方一致
            else if ( goodsNo.StartsWith("*") ) {
                stockSearchPara.GoodsNoSrchTyp = 2;
                goodsNo = goodsNo.Replace("*", "");
            }

            // 商品コード
            stockSearchPara.GoodsNo = goodsNo;

            // メーカーコード
            stockSearchPara.GoodsMakerCd = this._stockMoveInputAcs.StockMoveDataTable[activeCell.Row.Index].GoodsMakerCd;

            // 商品検索ガイド結果オブジェクト
            object retObj = null;
            string msg;


            //--------------------------------------------------------------------
            // 検索呼び出し
            //--------------------------------------------------------------------

            int status = -1;

            // 複数選択可能設定
            stockSearchGuide.IsMultiSelect = false;

            // 在庫検索呼び出し
            status = stockSearchGuide.ReadStock(this, stockSearchPara, out retObj, out msg);

            //--------------------------------------------------------------------
            // 結果
            //--------------------------------------------------------------------

            // 選択無し
            if ( status == -1 ) {
                _errGoodsNo = true;
                return false;
            }
            // 該当無し
            else if ( status == ( int ) ConstantManagement.DB_Status.ctDB_NOT_FOUND ) {
                DialogResult dialogResult = TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        msg,
                        -1,
                        MessageBoxButtons.OK);
                _errGoodsNo = true;
                return false;
            }
            // 正常に取得した場合
            else {
                if ((retObj == null) || ((retObj as List<StockExpansion>).Count == 0)){
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        "該当データが存在しません。",
                        -1,
                        MessageBoxButtons.OK);

                    // 商品コードが無かった(削除された)場合、データテーブルの該当レコードデータをクリア
                    int stockMoveSlipNoDel = _stockMoveDataTable[activeCell.Row.Index].StockMoveSlipNo;
                    int stockMoveRowNoDel = _stockMoveDataTable[activeCell.Row.Index].StockMoveRowNo;

                    // 在庫移動データレコードをクリア
                    this.StockMoveDetailRowClear(activeCell.Row.Index);

                    // 行状態を変更
                    this.SettingGridRow( activeCell.Row.Index );

                    _stockMoveDataTable[activeCell.Row.Index].StockMoveSlipNo = stockMoveSlipNoDel;
                    _stockMoveDataTable[activeCell.Row.Index].StockMoveRowNo = stockMoveRowNoDel;

                    _errGoodsNo = true;

                    return false;
                }

                // 入力値クリア
                if ( activeCell.Column.Key == _stockMoveInputAcs.StockMoveDataTable.GoodsNoColumn.ColumnName ) {
                    activeCell.Value = "";
                }
                else if ( activeCell.Column.Key == _stockMoveInputAcs.StockMoveDataTable.GoodsMakerCdColumn.ColumnName ) {
                    activeCell.Value = 0;
                }

                // 在庫移動データ、在庫移動詳細データを格納及びデータテーブルを更新
                List<StockExpansion> stockSearchRetList = (retObj as List<StockExpansion>);
                if (stockSearchRetList == null) {
                    stockSearchRetList = new List<StockExpansion>();
                }
                // 在庫移動データテーブルに格納
                this.StockMoveDataTableFromStockSearchRet(stockSearchRetList, activeCell);

                if ( !_errGoodsNo )
                {
                    // セル移動
                    activeCell = this.ultraGrid1.Rows[activeCell.Row.Index].Cells[42];
                    ultraGrid1.ActiveCell = activeCell;
                    this.ultraGrid1.PerformAction( UltraGridAction.EnterEditMode );

                    // 行状態を変更
                    this.SettingGridRow( activeCell.Row.Index );
                }
                else
                {
                    // セル移動
                    UltraGridCell cell = this.ultraGrid1.Rows[activeCell.Row.Index].Cells[_stockMoveInputAcs.StockMoveDataTable.GoodsNoColumn.ColumnName];
                    ultraGrid1.ActiveCell = cell;
                    this.ultraGrid1.PerformAction( UltraGridAction.EnterEditMode );
                }
            }


            // 最終行の場合は、１行追加する
            if ( activeCell.Row.Index == _stockMoveInputAcs.StockMoveDataTable.Rows.Count - 1 ) {
                this._stockMoveInputAcs.AddStockDetailRow();
            }

            return true;
        }
           --- DEL 2008/07/14 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/14 Partsman用に変更

        /// <summary>
        /// 明細レコードクリア（商品番号未入力）
        /// </summary>
        private bool ClearRecordInput (int index)
        {
            // 商品コードが無かった(削除された)場合、データテーブルの該当レコードデータをクリア
            int stockMoveSlipNoDel = _stockMoveDataTable[index].StockMoveSlipNo;
            int stockMoveRowNoDel = _stockMoveDataTable[index].StockMoveRowNo;

            // 在庫移動データレコードをクリア
            // --- CHG 2008/07/14 --------------------------------------------------------------------->>>>>
            //this.StockMoveDetailRowClear(index);
            this.StockMoveDetailRowClear(index, true);
            this.ultraGrid1.Rows[index].Cells[_stockMoveDataTable.GoodsNoColumn.ColumnName].Tag = null;
            this.ultraGrid1.Rows[index].Cells[_stockMoveDataTable.GoodsMakerCdColumn.ColumnName].Tag = null;
            this.ultraGrid1.Rows[index].Cells[_stockMoveDataTable.StockMoveRowNoColumn.ColumnName].Tag = null;
            // --- CHG 2008/07/14 ---------------------------------------------------------------------<<<<<

            // 行状態を変更
            this.SettingGridRow( index );

            _stockMoveDataTable[index].StockMoveSlipNo = stockMoveSlipNoDel;
            _stockMoveDataTable[index].StockMoveRowNo = stockMoveRowNoDel;

            // 移動合計更新デリゲート
            this.TotalPriceSetting();

            GetKeyList();
            return true;
        }

        #region DEL 2008/07/14 Partsman用に変更
        /* --- DEL 2008/07/14 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 仕入在庫出荷数入力チェック（出荷数(仕)入力）
        /// </summary>
        private bool CheckInputMovingSupliStock(UltraGridCell activeCell)
        {
            double movingSupliStock;
            if (activeCell.Value == DBNull.Value)
            {
                movingSupliStock = 0;
            }
            else
            {
                movingSupliStock = Double.Parse(activeCell.Value.ToString());
            }

            // 更新したアクティブセルの行
            StockMoveInputDataSet.StockMoveRow row = _stockMoveDataTable[activeCell.Row.Index];

            // 仕入在庫出荷可能数
            updateSupliRemainCount = _stockMoveDataTable[activeCell.Row.Index].SlipRemainCount;
            // 仕入在庫出荷数
            //updateMovingSupliStock = Double.Parse(e.Cell.Value.ToString());
            updateMovingSupliStock = _stockMoveDataTable[activeCell.Row.Index].MovingSupliStock;

            // 移動中受託在庫数チェック
            if (updateMovingTrustStock != 0)
            {
                DialogResult dialogResult = TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                    this.Name,
                    "１レコードで処理できるのは仕入在庫もしくは受託在庫のどちらかです。" + "\r\n" + "\r\n" +
                    "仕入在庫の入力を許可し、受託在庫の出荷数を0にしてよろしいですか？",
                    0,
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxDefaultButton.Button1);

                // 編集データを登録して閉じる場合
                if (dialogResult == DialogResult.Yes)
                {
                    // 受託在庫出荷数を0にする
                    row.MovingTrustStock = 0;
                    row.SlipRemainCount = updateSupliRemainCount - movingSupliStock;
                    row.TrustRemainCount = updateTrustRemainCount + updateMovingTrustStock;
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                    row.BfAfterMoveCount = row.SlipRemainCount + row.TrustRemainCount;
                    row.BfBeforeMoveCount = row.BfAfterMoveCount + row.MovingSupliStock + row.MovingTrustStock;
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                }
                // 編集データを登録せずに閉じる場合
                else if (dialogResult == DialogResult.No)
                {
                    row.SlipRemainCount = updateSupliRemainCount;
                    // 仕入在庫出荷数を0にする
                    row.MovingSupliStock = 0;
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                    row.BfAfterMoveCount = row.SlipRemainCount + row.TrustRemainCount;
                    row.BfBeforeMoveCount = row.BfAfterMoveCount + row.MovingSupliStock + row.MovingTrustStock;
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                    return false;
                }
                // キャンセルされた場合(Noと同じ動作)
                else
                {
                    row.SlipRemainCount = updateSupliRemainCount;
                    // 仕入在庫出荷数を0にする
                    row.MovingSupliStock = 0;
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                    row.BfAfterMoveCount = row.SlipRemainCount + row.TrustRemainCount;
                    row.BfBeforeMoveCount = row.BfAfterMoveCount + row.MovingSupliStock + row.MovingTrustStock;
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                    return false;
                }
            }

            // もし、仕入在庫出荷数が仕入在庫出荷可能数を超えていた場合
            if (updateSupliRemainCount + updateMovingSupliStock < movingSupliStock)
            {
                DialogResult dialogResult = TMsgDisp.Show(
                this,
                emErrorLevel.ERR_LEVEL_INFO,
                this.Name,
                "出荷数が出荷可能数を超えています。",
                -1,
                MessageBoxButtons.OK);

                // 初期状態に戻す。
                row.MovingSupliStock = updateMovingSupliStock;
                row.SlipRemainCount = updateSupliRemainCount;
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                row.BfAfterMoveCount = row.SlipRemainCount + row.TrustRemainCount;
                row.BfBeforeMoveCount = row.BfAfterMoveCount + row.MovingSupliStock + row.MovingTrustStock;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

                // テーブルのコミット
                _stockMoveDataTable.AcceptChanges();

                _errMoveCount = true;

                return false;

            }
            _errMoveCount = false;

            if (updateMovingSupliStock < movingSupliStock)
            {
                row.SlipRemainCount = (updateSupliRemainCount + updateMovingSupliStock) - movingSupliStock;
            }
            else if (updateMovingSupliStock > movingSupliStock)
            {
                row.SlipRemainCount = updateSupliRemainCount + (updateMovingSupliStock - movingSupliStock);
            }
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            row.BfAfterMoveCount = row.SlipRemainCount + row.TrustRemainCount;
            row.BfBeforeMoveCount = row.BfAfterMoveCount + row.MovingSupliStock + row.MovingTrustStock;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            if (updateMovingSupliStock < movingSupliStock)
            {
                row.SlipRemainCount = (updateSupliRemainCount + updateMovingSupliStock) - movingSupliStock;
                row.BfAfterMoveCount = row.SlipRemainCount - updateMovingSupliStock;
            }
            else if (updateMovingSupliStock > movingSupliStock)
            {
                row.SlipRemainCount = updateSupliRemainCount + (updateMovingSupliStock - movingSupliStock);
                row.BfAfterMoveCount = row.SlipRemainCount;
            }

            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            // テーブルのコミット
            _stockMoveDataTable.AcceptChanges();
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            return true;
        }
           --- DEL 2008/07/14 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/14 Partsman用に変更

        #region DEL 2008/07/14 使用していないのでコメントアウト
        /* --- DEL 2008/07/14 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 受託在庫出荷数入力チェック（出荷数(受)入力）
        /// </summary>
        private bool CheckInputMovingTrustStock ( UltraGridCell activeCell )
        {
            double movingTrustStock = Double.Parse(activeCell.Value.ToString());

            // 更新したアクティブセルの行
            StockMoveInputDataSet.StockMoveRow row = _stockMoveDataTable[activeCell.Row.Index];

            // 移動中仕入在庫数チェック
            if ( updateMovingSupliStock != 0 ) {
                DialogResult dialogResult = TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                    this.Name,
                    "１レコードで処理できるのは仕入在庫もしくは受託在庫のどちらかです。" + "\r\n" + "\r\n" +
                    "受託在庫の入力を許可し、仕入在庫の出荷数を0にしてよろしいですか？",
                    0,
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxDefaultButton.Button1);

                // 編集データを登録して閉じる場合
                if ( dialogResult == DialogResult.Yes ) {
                    // 仕入在庫出荷数を0にする
                    row.MovingSupliStock = 0;
                    row.TrustRemainCount = updateTrustRemainCount - movingTrustStock;
                    row.SlipRemainCount = updateSupliRemainCount + updateMovingSupliStock;
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                    row.BfAfterMoveCount = row.SlipRemainCount + row.TrustRemainCount;
                    row.BfBeforeMoveCount = row.BfAfterMoveCount + row.MovingSupliStock + row.MovingTrustStock;
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                }
                // 編集データを登録せずに閉じる場合
                else if ( dialogResult == DialogResult.No ) {
                    row.TrustRemainCount = updateTrustRemainCount;
                    // 受託在庫出荷数を0にする
                    row.MovingTrustStock = 0;
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                    row.BfAfterMoveCount = row.SlipRemainCount + row.TrustRemainCount;
                    row.BfBeforeMoveCount = row.BfAfterMoveCount + row.MovingSupliStock + row.MovingTrustStock;
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                    return false;
                }
                // キャンセルされた場合(Noと同じ動作)
                else {
                    row.TrustRemainCount = updateTrustRemainCount;
                    // 受託在庫出荷数を0にする
                    row.MovingTrustStock = 0;
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                    row.BfAfterMoveCount = row.SlipRemainCount + row.TrustRemainCount;
                    row.BfBeforeMoveCount = row.BfAfterMoveCount + row.MovingSupliStock + row.MovingTrustStock;
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                    return false;
                }
            }

            // もし、受託在庫出荷数が受託在庫出荷可能数を超えていた場合
            if ( updateTrustRemainCount + updateMovingTrustStock < movingTrustStock ) {
                DialogResult dialogResult = TMsgDisp.Show(
                this,
                emErrorLevel.ERR_LEVEL_INFO,
                this.Name,
                "受託在庫出荷数が受託在庫出荷可能数を超えています。",
                -1,
                MessageBoxButtons.OK);

                // 初期状態に戻す。
                row.MovingTrustStock = updateMovingTrustStock;
                row.TrustRemainCount = updateTrustRemainCount;

                // テーブルのコミット
                _stockMoveDataTable.AcceptChanges();

                return false;

            }

            if ( updateMovingTrustStock < movingTrustStock ) {
                row.TrustRemainCount = ( updateTrustRemainCount + updateMovingTrustStock ) - movingTrustStock;
            }
            else if ( updateMovingTrustStock > movingTrustStock ) {
                row.TrustRemainCount = updateTrustRemainCount + ( updateMovingTrustStock - movingTrustStock );
            }
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            row.BfAfterMoveCount = row.SlipRemainCount + row.TrustRemainCount;
            row.BfBeforeMoveCount = row.BfAfterMoveCount + row.MovingSupliStock + row.MovingTrustStock;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            return true;
        }
           --- DEL 2008/07/14 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/14 使用していないのでコメントアウト

        # endregion

        /// <summary>
        /// 明細グリッド・行単位でのセル設定
        /// </summary>
        /// <param name="rowIndex">対象行インデックス</param>
        /// <remarks>
        /// <br>行ごとに項目の入力可否設定・背景色設定を行う。</br>
        /// <br>Update Note: 2011/04/11 鄧潘ハン 明細に仕入先を追加する</br>
        /// </remarks>
        private void SettingGridRow(int rowIndex)
        {
            UltraGridBand editBand = this.ultraGrid1.DisplayLayout.Bands[0];
            if (editBand == null) return;

            // --- CHG 2008/07/14 --------------------------------------------------------------------->>>>>
            //// 商品名称を取得
            //string goodsName = _stockMoveInputAcs.StockMoveDataTable[rowIndex].GoodsName;
            // 商品コードを取得
            string goodsNo = _stockMoveInputAcs.StockMoveDataTable[rowIndex].GoodsNo;
            // --- CHG 2008/07/14 ---------------------------------------------------------------------<<<<<
            // 行ステータスを取得
            int rowStatus = _stockMoveInputAcs.StockMoveDataTable[rowIndex].RowStatus;

            // 指定行の全ての列に対して設定を行う。
            foreach (UltraGridColumn col in editBand.Columns)
            {
                // セル情報を取得
                UltraGridCell cell = this.ultraGrid1.Rows[rowIndex].Cells[col];
                if (cell == null) continue;

                // --- CHG 2008/07/14 --------------------------------------------------------------------->>>>>
                //// カラムが在庫移動行番号、商品コード、商品コードガイドボタンだった場合
                //if ((col.Key == _stockMoveInputAcs.StockMoveDataTable.StockMoveRowNoColumn.ColumnName) ||
                //    (col.Key == _stockMoveInputAcs.StockMoveDataTable.GoodsNoColumn.ColumnName) ||
                //    (col.Key == _stockMoveInputAcs.StockMoveDataTable.GoodsGuideButtonColumn.ColumnName))
                //{ 
                //    // 編集可能にする。
                //    cell.Activation = Activation.AllowEdit;
                //}
                //else
                //{
                //    // 商品名称が入力されていない場合は「商品コード」「商品ガイドボタン」以外を無効にする
                //    if (goodsName.Trim() == "")
                //    {
                //        cell.Activation = Activation.Disabled;
                //    }
                //    else
                //    {
                //        cell.Activation = Activation.AllowEdit;
                //    }
                //}

                // カラムが在庫移動行番号、商品コード、メーカー、メーカーガイドボタン
                // BLコード、BLコードガイドボタン、商品名称、出荷数、標準価格、原単価だった場合
                //if ((col.Key == _stockMoveInputAcs.StockMoveDataTable.StockMoveRowNoColumn.ColumnName) ||
                //    (col.Key == _stockMoveInputAcs.StockMoveDataTable.GoodsNoColumn.ColumnName) ||
                //    (col.Key == _stockMoveInputAcs.StockMoveDataTable.GoodsMakerCdColumn.ColumnName) ||
                //    (col.Key == _stockMoveInputAcs.StockMoveDataTable.MakerGuideButtonColumn.ColumnName) ||
                //    (col.Key == _stockMoveInputAcs.StockMoveDataTable.BLGoodsCodeColumn.ColumnName) ||
                //    (col.Key == _stockMoveInputAcs.StockMoveDataTable.BLCodeGuideButtonColumn.ColumnName) ||
                //    (col.Key == _stockMoveInputAcs.StockMoveDataTable.GoodsNameColumn.ColumnName) ||
                //    (col.Key == _stockMoveInputAcs.StockMoveDataTable.StockUnitPriceFlColumn.ColumnName) ||
                //    (col.Key == _stockMoveInputAcs.StockMoveDataTable.ListPriceFlViewColumn.ColumnName) ||
                //    (col.Key == _stockMoveInputAcs.StockMoveDataTable.MovingSupliStockColumn.ColumnName))
                //{
                //    // 編集可能にする。
                //    cell.Activation = Activation.AllowEdit;
                //}
                //else
                //{
                //    if (goodsNo.Trim() == "")
                //    {
                //        cell.Activation = Activation.Disabled;
                //    }
                //    else
                //    {
                //        cell.Activation = Activation.AllowEdit;
                //    }
                //}
                if ((col.Key == _stockMoveInputAcs.StockMoveDataTable.StockMoveRowNoColumn.ColumnName) ||
                    (col.Key == _stockMoveInputAcs.StockMoveDataTable.GoodsNoColumn.ColumnName))
                {
                    // 編集可能にする。
                    cell.Activation = Activation.AllowEdit;
                }
                else
                {
                    if (goodsNo.Trim() == "")
                    {
                        cell.Activation = Activation.Disabled;
                    }
                    else
                    {
                        cell.Activation = Activation.AllowEdit;
                    }
                }
                // --- CHG 2008/07/14 ---------------------------------------------------------------------<<<<<

                if (rowStatus == StockMoveInputAcs.CODE_ROWSTATUS_COPY)
                {
                    cell.Appearance.BackColor = ROWSTATUS_COPY_COLOR;
                    cell.Appearance.ForeColor = this.ultraGrid1.DisplayLayout.Override.RowAppearance.ForeColor;
                }
                else if (rowStatus == StockMoveInputAcs.CODE_ROWSTATUS_CUT)
                {
                    cell.Appearance.BackColor = ROWSTATUS_COPY_COLOR;
                    cell.Appearance.ForeColor = ROWSTATUS_CUT_COLOR;
                }
                else
                {
                    cell.Appearance.BackColor = this.ultraGrid1.DisplayLayout.Override.RowAppearance.BackColor;

                    cell.Appearance.ForeColor = this.ultraGrid1.DisplayLayout.Override.RowAppearance.ForeColor;

                    if ((cell.Activation == Activation.NoEdit) ||
                        (cell.Column.CellActivation == Activation.NoEdit))
                    {
                        cell.Appearance.BackColor = READONLY_CELL_COLOR;
                    }
                    else
                    {
                        cell.Appearance.BackColor = this.ultraGrid1.DisplayLayout.Override.CellAppearance.BackColor;
                    }
                }
            }
        }

        private void SetRowEnabled(int rowIndex)
        {
            UltraGridBand editBand = this.ultraGrid1.DisplayLayout.Bands[0];
            if (editBand == null) return;

            // 商品コードを取得
            string goodsNo = _stockMoveInputAcs.StockMoveDataTable[rowIndex].GoodsNo;
            // 行ステータスを取得
            int rowStatus = _stockMoveInputAcs.StockMoveDataTable[rowIndex].RowStatus;

            // 指定行の全ての列に対して設定を行う。
            foreach (UltraGridColumn col in editBand.Columns)
            {
                // セル情報を取得
                UltraGridCell cell = this.ultraGrid1.Rows[rowIndex].Cells[col];
                if (cell == null) continue;

                if ((col.Key == _stockMoveInputAcs.StockMoveDataTable.StockMoveRowNoColumn.ColumnName) ||
                    (col.Key == _stockMoveInputAcs.StockMoveDataTable.GoodsNoColumn.ColumnName) ||
                    (col.Key == _stockMoveInputAcs.StockMoveDataTable.GoodsMakerCdColumn.ColumnName) ||
                    (col.Key == _stockMoveInputAcs.StockMoveDataTable.MakerGuideButtonColumn.ColumnName) ||
                    (col.Key == _stockMoveInputAcs.StockMoveDataTable.BLGoodsCodeColumn.ColumnName) ||
                    (col.Key == _stockMoveInputAcs.StockMoveDataTable.BLCodeGuideButtonColumn.ColumnName) ||
                    //---ADD 2011/04/11----------------------------------------------------------->>>>>
                    (col.Key == _stockMoveInputAcs.StockMoveDataTable.SupplierCdColumn.ColumnName) ||
                    (col.Key == _stockMoveInputAcs.StockMoveDataTable.SupplierCdGuideButtonColumn.ColumnName) ||
                    //---ADD 2011/04/11-----------------------------------------------------------<<<<<
                    (col.Key == _stockMoveInputAcs.StockMoveDataTable.GoodsNameColumn.ColumnName) ||
                    (col.Key == _stockMoveInputAcs.StockMoveDataTable.StockUnitPriceFlColumn.ColumnName) ||
                    (col.Key == _stockMoveInputAcs.StockMoveDataTable.ListPriceFlViewColumn.ColumnName) ||
                    (col.Key == _stockMoveInputAcs.StockMoveDataTable.MovingSupliStockColumn.ColumnName))
                {
                    // 編集可能にする。
                    cell.Activation = Activation.AllowEdit;
                }
                else
                {
                    if (goodsNo.Trim() == "")
                    {
                        cell.Activation = Activation.Disabled;
                    }
                    else
                    {
                        cell.Activation = Activation.AllowEdit;
                    }
                }

                if (rowStatus == StockMoveInputAcs.CODE_ROWSTATUS_COPY)
                {
                    cell.Appearance.BackColor = ROWSTATUS_COPY_COLOR;
                    cell.Appearance.ForeColor = this.ultraGrid1.DisplayLayout.Override.RowAppearance.ForeColor;
                }
                else if (rowStatus == StockMoveInputAcs.CODE_ROWSTATUS_CUT)
                {
                    cell.Appearance.BackColor = ROWSTATUS_COPY_COLOR;
                    cell.Appearance.ForeColor = ROWSTATUS_CUT_COLOR;
                }
                else
                {
                    cell.Appearance.BackColor = this.ultraGrid1.DisplayLayout.Override.RowAppearance.BackColor;

                    cell.Appearance.ForeColor = this.ultraGrid1.DisplayLayout.Override.RowAppearance.ForeColor;

                    if ((cell.Activation == Activation.NoEdit) ||
                        (cell.Column.CellActivation == Activation.NoEdit))
                    {
                        cell.Appearance.BackColor = READONLY_CELL_COLOR;
                    }
                    else
                    {
                        cell.Appearance.BackColor = this.ultraGrid1.DisplayLayout.Override.CellAppearance.BackColor;
                    }
                }
            }
        }

        #region DEL 2008/07/14 使用していないのでコメントアウト
        /* --- DEL 2008/07/14 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// Gridアクション処理後イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uGrid_Details_AfterPerformAction(object sender, AfterUltraGridPerformActionEventArgs e)
        {
            switch (e.UltraGridAction)
            {
                case UltraGridAction.ActivateCell:
                case UltraGridAction.AboveCell:
                case UltraGridAction.BelowCell:
                case UltraGridAction.PrevCell:
                case UltraGridAction.NextCell:
                case UltraGridAction.PageUpCell:
                case UltraGridAction.PageDownCell:

                    // アクティブなセルがあるか？または編集可能セルか？
                    if ((this.ultraGrid1.ActiveCell != null) && (this.ultraGrid1.ActiveCell.Column.CellActivation == Activation.AllowEdit) && (this.ultraGrid1.ActiveCell.Activation == Activation.AllowEdit))
                    {
                        // アクティブセルのスタイルを取得
                        switch (this.ultraGrid1.ActiveCell.StyleResolved)
                        {
                            // エディット系スタイル
                            case Infragistics.Win.UltraWinGrid.ColumnStyle.Default:
                            case Infragistics.Win.UltraWinGrid.ColumnStyle.Edit:
                            case Infragistics.Win.UltraWinGrid.ColumnStyle.EditButton:
                                {
                                    // 編集モードにある？
                                    if (this.ultraGrid1.PerformAction(UltraGridAction.EnterEditMode))
                                    {
                                        if (this.ultraGrid1.ActiveCell != null && !(this.ultraGrid1.ActiveCell.Value is System.DBNull))
                                        {
                                            try
                                            {
                                                // 全選択状態にする。
                                                this.ultraGrid1.ActiveCell.SelStart = 0;
                                                this.ultraGrid1.ActiveCell.SelLength = this.ultraGrid1.ActiveCell.Text.Length;
                                            }
                                            catch
                                            {
                                            }
                                        }
                                    }
                                    break;
                                }
                            default:
                                {
                                    // エディット系以外のスタイルであれば、編集状態にする。
                                    this.ultraGrid1.PerformAction(UltraGridAction.EnterEditMode);
                                    break;
                                }
                        }
                    }
                    break;
            }
        }
           --- DEL 2008/07/14 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/14 使用していないのでコメントアウト

        #region DEL 2008/07/14 Partsman用に変更
        /* --- DEL 2008/07/14 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// グリッド行アクティブ後発生イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uGrid_Details_AfterRowActivate(object sender, EventArgs e)
        {
            if (this.ultraGrid1.ActiveRow == null) return;
            UltraGridRow row = this.ultraGrid1.ActiveRow;

            // 行操作ボタンの有効無効を設定する
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //string goodsCode = _stockMoveInputAcs.StockMoveDataTable[row.Index].GoodsCode.ToString();
            string goodsCode = _stockMoveInputAcs.StockMoveDataTable[row.Index].GoodsNo.ToString();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            string goodsName = _stockMoveInputAcs.StockMoveDataTable[row.Index].GoodsName;

            if (goodsName == "")
            {
                this.RowCut_ultraButton.Enabled = false;
                this.RowCopy_ultraButton.Enabled = false;
            }
            else
            {
                this.RowCut_ultraButton.Enabled = true;
                this.RowCopy_ultraButton.Enabled = true;
            }

            if (this._stockMoveInputAcs.ExistCopyStockMoveDetailRow())
            {
                this.RowPaste_ultraButton.Enabled = true;
            }
            else
            {
                this.RowPaste_ultraButton.Enabled = false;
            }

            this.RowInsert_ultraButton.Enabled = true;
            this.RowDelete_ultraButton.Enabled = true;

            // ガイドボタンの有効無効を設定する
            //this.uButton_Guide.Enabled = false;

            //// 横スクロールバー位置設定
            //this.ultraGrid1.DisplayLayout.ColScrollRegions[0].Position = 0;

        }

        /// <summary>
        /// グリッドセルアクティブ化前イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uGrid_Details_BeforeCellActivate(object sender, CancelableCellEventArgs e)
        {
            // 在庫移動では倉庫名称は入れない
            // セル単位でのIME制御(これは備考がグリッド内にある場合にその直前でIMEのモード移行を行う。)
            //if (e.Cell.Column.Key == _stockMoveInputAcs.StockMoveDataTable.WareHouseNameColumn.ColumnName)
            //{
            //    // IMEをひらがなモードにする
            //    this.ultraGrid1.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            //}
            //else
            //{
            //    // IMEを起動しない
            //    this.ultraGrid1.ImeMode = System.Windows.Forms.ImeMode.Disable;
            //}
        }
           --- DEL 2008/07/14 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/14 Partsman用に変更

        #region DEL 2008/07/14 使用していないのでコメントアウト
        /* --- DEL 2008/07/14 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// グリッドセルアップデート前イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uGrid_Details_BeforeCellUpdate(object sender, BeforeCellUpdateEventArgs e)
        {
            // これから更新をかけるセルの仕入在庫出荷可能数、受託在庫出荷可能数を保持
            if (e.Cell == null) return;

            UltraGridCell activeCell = e.Cell;

            // 仕入在庫出荷数の場合
            if (activeCell.Column.Key == _stockMoveInputAcs.StockMoveDataTable.MovingSupliStockColumn.ColumnName)
            {
                if (!_stockMoveDataTable[activeCell.Row.Index].IsNull(_stockMoveDataTable.MovingSupliStockColumn))
                {
                    // 仕入在庫出荷可能数
                    updateSupliRemainCount = _stockMoveDataTable[activeCell.Row.Index].SlipRemainCount;
                    // 仕入在庫出荷数
                    //updateMovingSupliStock = Double.Parse(e.Cell.Value.ToString());
                    updateMovingSupliStock = _stockMoveDataTable[activeCell.Row.Index].MovingSupliStock;
                    // 受託在庫出荷可能数
                    updateTrustRemainCount = _stockMoveDataTable[activeCell.Row.Index].TrustRemainCount;
                    // 受託在庫出荷数
                    //updateMovingTrustStock = Double.Parse(e.Cell.Value.ToString());
                    updateMovingTrustStock = _stockMoveDataTable[activeCell.Row.Index].MovingTrustStock;
                }
            }

            // 受託在庫出荷数の場合
            if (activeCell.Column.Key == _stockMoveInputAcs.StockMoveDataTable.MovingTrustStockColumn.ColumnName)
            {

                if (!_stockMoveDataTable[activeCell.Row.Index].IsNull(_stockMoveDataTable.MovingTrustStockColumn))
                {
                    // 仕入在庫出荷可能数
                    updateSupliRemainCount = _stockMoveDataTable[activeCell.Row.Index].SlipRemainCount;
                    // 仕入在庫出荷数
                    //updateMovingSupliStock = Double.Parse(e.Cell.Value.ToString());
                    updateMovingSupliStock = _stockMoveDataTable[activeCell.Row.Index].MovingSupliStock;
                    // 受託在庫出荷可能数
                    updateTrustRemainCount = _stockMoveDataTable[activeCell.Row.Index].TrustRemainCount;
                    // 受託在庫出荷数
                    //updateMovingTrustStock = Double.Parse(e.Cell.Value.ToString());
                    updateMovingTrustStock = _stockMoveDataTable[activeCell.Row.Index].MovingTrustStock;
                }
            }
        }
        
        /// <summary>
        /// フォーカス設定イベントコール処理
        /// </summary>
        /// <param name="itemName">項目名称</param>
        private void SettingFocusEventCall(string itemName)
        {
            if (this.FocusSetting != null)
            {
                this.FocusSetting(this, itemName);
            }
        }
        
        /// <summary>
        /// グリッドデータエラー発生イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uGrid_Details_CellDataError(object sender, CellDataErrorEventArgs e)
        {
            if (this.ultraGrid1.ActiveCell != null)
            {
                // 数値項目の場合
                if ((this.ultraGrid1.ActiveCell.Column.DataType == typeof(Int32)) ||
                    (this.ultraGrid1.ActiveCell.Column.DataType == typeof(Int64)) ||
                    (this.ultraGrid1.ActiveCell.Column.DataType == typeof(double)))
                {
                    EmbeddableEditorBase editorBase = this.ultraGrid1.ActiveCell.EditorResolved;

                    // 未入力は0にする
                    if (editorBase.CurrentEditText.Trim() == "")
                    {
                        editorBase.Value = 0;				// 0をセット
                        this.ultraGrid1.ActiveCell.Value = 0;
                    }
                    // 数値項目に「-」or「.」だけしか入ってなかったら駄目です
                    else if ((editorBase.CurrentEditText.Trim() == "-") ||
                        (editorBase.CurrentEditText.Trim() == ".") ||
                        (editorBase.CurrentEditText.Trim() == "-."))
                    {
                        editorBase.Value = 0;				// 0をセット
                        this.ultraGrid1.ActiveCell.Value = 0;
                    }
                    // 通常入力
                    else
                    {
                        try
                        {
                            editorBase.Value = Convert.ChangeType(editorBase.CurrentEditText.Trim(), this.ultraGrid1.ActiveCell.Column.DataType);
                            this.ultraGrid1.ActiveCell.Value = editorBase.Value;
                        }
                        catch
                        {
                            editorBase.Value = 0;
                            this.ultraGrid1.ActiveCell.Value = 0;
                        }
                    }
                    e.RaiseErrorEvent = false;			// エラーイベントは発生させない
                    e.RestoreOriginalValue = false;		// セルの値を元に戻さない
                    e.StayInEditMode = false;			// 編集モードは抜ける
                }
            }
        }

        /// <summary>
        /// グリッドセルリスト選択時発生イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uGrid_Details_CellListSelect(object sender, CellEventArgs e)
        {
            if (e.Cell == null) return;

            UltraGridCell cell = e.Cell;
            int stockRowNo = _stockMoveInputAcs.StockMoveDataTable[cell.Row.Index].StockMoveRowNo;
        }
           --- DEL 2008/07/14 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/14 使用していないのでコメントアウト

        /// <summary>
        /// グリッド初期レイアウト設定イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void ultraGrid1_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            // グリッド列初期設定処理
            this.GridColInitialSetting();

            // グリッド列設定処理（ユーザー設定より）
            //this.GridSetting(this._stockInputConstructionAcs.StockInputConstruction);
        }

        #region DEL 2008/07/14 Partsman用に変更
        /* --- DEL 2008/07/14 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// グリッド列初期設定処理
        /// </summary>
        private void GridColInitialSetting()
        {
            UltraGridBand editBand = this.ultraGrid1.DisplayLayout.Bands[0];
            if (editBand == null) return;
            StockMoveInputDataSet.StockMoveDataTable table = _stockMoveInputAcs.StockMoveDataTable;

            foreach (UltraGridColumn col in editBand.Columns)
            {
                // 全ての列をいったん非表示にする。
                col.Hidden = true;

                // 「No列」以外の全てのセルのDiabledColorを設定する。
                if (col.Key != _stockMoveInputAcs.StockMoveDataTable.StockMoveRowNoColumn.ColumnName)
                {
                    col.CellAppearance.BackColorDisabled = DISABLE_COLOR;
                    col.CellAppearance.ForeColorDisabled = DISABLE_FONT_COLOR;
                }
            }

            // グリッド列表示非表示設定処理
            this.SettingGridColVisible(StatusType.Default, 0);

            // 表示幅設定
            editBand.Columns[table.StockMoveRowNoColumn.ColumnName].Width = 44;			// №
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //editBand.Columns[table.GoodsCodeColumn.ColumnName].Width = 100;				// 商品コード
            editBand.Columns[table.GoodsNoColumn.ColumnName].Width = 100;				// 商品コード
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            editBand.Columns[table.GoodsGuideButtonColumn.ColumnName].Width = 25;		// 商品ガイドボタン
            editBand.Columns[table.GoodsNameColumn.ColumnName].Width = 140;				// 商品名
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //editBand.Columns[table.ProductNumberColumn.ColumnName].Width = 140;			// 製造番号
            //editBand.Columns[table.StockTelNo1Column.ColumnName].Width = 90;    		// 電話番号1
            //editBand.Columns[table.StockTelNo2Column.ColumnName].Width = 90;    		// 電話番号2
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            editBand.Columns[table.MovingSupliStockColumn.ColumnName].Width = 85;		// 仕入在庫出荷数
            editBand.Columns[table.SlipRemainCountColumn.ColumnName].Width = 85;		// 仕入在庫残数
            editBand.Columns[table.MovingTrustStockColumn.ColumnName].Width = 85;	// 受託在庫出荷数
            editBand.Columns[table.TrustRemainCountColumn.ColumnName].Width = 85;		// 受託在庫残数            
            editBand.Columns[table.StockUnitPriceFlColumn.ColumnName].Width = 130;		        // 単価
            //editBand.Columns[table.MovingPriceColumn.ColumnName].Width = 130;		    // 移動金額
            editBand.Columns[table.BfSectionGuideNmColumn.ColumnName].Width = 125;		// 出庫拠点
            editBand.Columns[table.BfEnterWarehNameColumn.ColumnName].Width = 125;		// 出庫倉庫

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            editBand.Columns[table.GoodsMakerCdColumn.ColumnName].Width = 80; 		// メーカーコード
            editBand.Columns[table.MakerNameColumn.ColumnName].Width = 100;		    // メーカー名称
            editBand.Columns[table.BLGoodsCodeColumn.ColumnName].Width = 80;		    // ＢＬコード
            editBand.Columns[table.BfShelfNoColumn.ColumnName].Width = 125;		// 棚番
            editBand.Columns[table.BfBeforeMoveCountColumn.ColumnName].Width = 125;	// 出庫前数
            editBand.Columns[table.BfAfterMoveCountColumn.ColumnName].Width = 125;	// 出庫後数
            editBand.Columns[table.ListPriceFlColumn.ColumnName].Width = 125;		    // 定価
            editBand.Columns[table.ListPriceFlViewColumn.ColumnName].Width = 125;		    // 定価
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // 固定列設定
            editBand.Columns[table.StockMoveRowNoColumn.ColumnName].Header.Fixed = true;	// №
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //editBand.Columns[table.GoodsCodeColumn.ColumnName].Header.Fixed = true;			// 商品コード
            editBand.Columns[table.GoodsNoColumn.ColumnName].Header.Fixed = true;			// 商品コード
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            editBand.Columns[table.GoodsGuideButtonColumn.ColumnName].Header.Fixed = true;	// 商品ガイドボタン
            editBand.Columns[table.GoodsNameColumn.ColumnName].Header.Fixed = true;			// 商品名
            editBand.Columns[table.StockMoveRowNoColumn.ColumnName].Header.FixedHeaderIndicator = FixedHeaderIndicator.None;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //editBand.Columns[table.GoodsCodeColumn.ColumnName].Header.FixedHeaderIndicator = FixedHeaderIndicator.None;
            editBand.Columns[table.GoodsNoColumn.ColumnName].Header.FixedHeaderIndicator = FixedHeaderIndicator.None;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            editBand.Columns[table.GoodsGuideButtonColumn.ColumnName].Header.FixedHeaderIndicator = FixedHeaderIndicator.None;
            editBand.Columns[table.GoodsNameColumn.ColumnName].Header.FixedHeaderIndicator = FixedHeaderIndicator.None;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            ////editBand.Columns[table.GoodsMakerCdColumn.ColumnName].Header.Fixed = true;		// メーカーコード
            ////editBand.Columns[table.MakerNameColumn.ColumnName].Header.Fixed = true;		// メーカー名称
            ////editBand.Columns[table.BLGoodsCodeColumn.ColumnName].Header.Fixed = true;		// ＢＬ商品コード
            ////editBand.Columns[table.GoodsMakerCdColumn.ColumnName].Header.FixedHeaderIndicator = FixedHeaderIndicator.None;
            ////editBand.Columns[table.MakerNameColumn.ColumnName].Header.FixedHeaderIndicator = FixedHeaderIndicator.None;
            ////editBand.Columns[table.BLGoodsCodeColumn.ColumnName].Header.FixedHeaderIndicator = FixedHeaderIndicator.None;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // CellAppearance設定
            editBand.Columns[table.StockMoveRowNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;   // 在庫移動行番号(右寄せ)
            editBand.Columns[table.MovingSupliStockColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right; // 移動中仕入在庫数(右寄せ)
            editBand.Columns[table.MovingTrustStockColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right; // 移動中受託在庫数(右寄せ)
            editBand.Columns[table.SlipRemainCountColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;  // 仕入在庫残数(右寄せ)
            editBand.Columns[table.TrustRemainCountColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;  // 受託在庫残数(右寄せ)
            editBand.Columns[table.StockUnitPriceFlColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;        // 単価(右寄せ)
            //editBand.Columns[table.MovingPriceColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;      // 移動金額(右寄せ)

            editBand.Columns[table.GoodsGuideButtonColumn.ColumnName].CellAppearance.Cursor = Cursors.Hand;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            editBand.Columns[table.GoodsMakerCdColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;		    // メーカーコード
            editBand.Columns[table.BLGoodsCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;		    // ＢＬコード
            editBand.Columns[table.BfBeforeMoveCountColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;	// 出庫前数
            editBand.Columns[table.BfAfterMoveCountColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;	    // 出庫後数
            editBand.Columns[table.ListPriceFlColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;		    // 定価
            editBand.Columns[table.ListPriceFlViewColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;		    // 定価
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki


            // ReadOnly設定
            editBand.Columns[table.GoodsNameColumn.ColumnName].CellAppearance.BackColor = DISABLE_COLOR;  			// 商品名
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //editBand.Columns[table.ProductNumberColumn.ColumnName].CellAppearance.BackColor = DISABLE_COLOR;			// 製造番号
            //editBand.Columns[table.StockTelNo1Column.ColumnName].CellAppearance.BackColor = DISABLE_COLOR;    		// 電話番号1
            //editBand.Columns[table.StockTelNo2Column.ColumnName].CellAppearance.BackColor = DISABLE_COLOR;    		// 電話番号2
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            editBand.Columns[table.SlipRemainCountColumn.ColumnName].CellAppearance.BackColor = DISABLE_COLOR;		// 仕入在庫残数
            editBand.Columns[table.TrustRemainCountColumn.ColumnName].CellAppearance.BackColor = DISABLE_COLOR;		// 受託在庫残数            
            editBand.Columns[table.StockUnitPriceFlColumn.ColumnName].CellAppearance.BackColor = DISABLE_COLOR;		    // 単価
            //editBand.Columns[table.MovingPriceColumn.ColumnName].CellAppearance.BackColor = DISABLE_COLOR;		    // 移動金額
            editBand.Columns[table.BfSectionGuideNmColumn.ColumnName].CellAppearance.BackColor = DISABLE_COLOR;		// 出庫拠点
            editBand.Columns[table.BfEnterWarehNameColumn.ColumnName].CellAppearance.BackColor = DISABLE_COLOR;		// 出庫倉庫

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            editBand.Columns[table.GoodsMakerCdColumn.ColumnName].CellAppearance.BackColor = DISABLE_COLOR;		        // メーカーコード
            editBand.Columns[table.MakerNameColumn.ColumnName].CellAppearance.BackColor = DISABLE_COLOR;		        // メーカー名称
            editBand.Columns[table.BLGoodsCodeColumn.ColumnName].CellAppearance.BackColor = DISABLE_COLOR;		    // ＢＬコード
            editBand.Columns[table.BfShelfNoColumn.ColumnName].CellAppearance.BackColor = DISABLE_COLOR;	        // 出庫棚番
            editBand.Columns[table.BfBeforeMoveCountColumn.ColumnName].CellAppearance.BackColor = DISABLE_COLOR;	    // 出庫前数
            editBand.Columns[table.BfAfterMoveCountColumn.ColumnName].CellAppearance.BackColor = DISABLE_COLOR;	    // 出庫後数
            editBand.Columns[table.ListPriceFlColumn.ColumnName].CellAppearance.BackColor = DISABLE_COLOR;		    // 定価
            editBand.Columns[table.ListPriceFlViewColumn.ColumnName].CellAppearance.BackColor = DISABLE_COLOR;		    // 定価
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            
            // 通常BackColor設定
            editBand.Columns[table.StockMoveRowNoColumn.ColumnName].CellAppearance.BackColor = this.ultraGrid1.DisplayLayout.Override.HeaderAppearance.BackColor;
            editBand.Columns[table.StockMoveRowNoColumn.ColumnName].CellAppearance.BackColor2 = this.ultraGrid1.DisplayLayout.Override.HeaderAppearance.BackColor2;
            editBand.Columns[table.StockMoveRowNoColumn.ColumnName].CellAppearance.BackGradientStyle = this.ultraGrid1.DisplayLayout.Override.HeaderAppearance.BackGradientStyle;
            editBand.Columns[table.StockMoveRowNoColumn.ColumnName].CellAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
            editBand.Columns[table.StockMoveRowNoColumn.ColumnName].CellAppearance.ForeColor = this.ultraGrid1.DisplayLayout.Override.HeaderAppearance.ForeColor;
            editBand.Columns[table.StockMoveRowNoColumn.ColumnName].CellAppearance.ForeColorDisabled = this.ultraGrid1.DisplayLayout.Override.HeaderAppearance.ForeColor;

            // 入力許可設定
            editBand.Columns[table.StockMoveRowNoColumn.ColumnName].CellActivation = Activation.Disabled;	// No
            editBand.Columns[table.GoodsNameColumn.ColumnName].CellActivation = Activation.NoEdit;		    // 商品名
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //editBand.Columns[table.ProductNumberColumn.ColumnName].CellActivation = Activation.NoEdit;	    // 製造番号
            //editBand.Columns[table.StockTelNo1Column.ColumnName].CellActivation = Activation.NoEdit;		// 電話番号1
            //editBand.Columns[table.StockTelNo2Column.ColumnName].CellActivation = Activation.NoEdit;		// 電話番号2
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            editBand.Columns[table.SlipRemainCountColumn.ColumnName].CellActivation = Activation.NoEdit;	// 仕入在庫残数
            editBand.Columns[table.TrustRemainCountColumn.ColumnName].CellActivation = Activation.NoEdit;	// 受託在庫残数
            editBand.Columns[table.StockUnitPriceFlColumn.ColumnName].CellActivation = Activation.NoEdit;		// 単価
            //editBand.Columns[table.MovingPriceColumn.ColumnName].CellActivation = Activation.NoEdit;		// 移動金額
            editBand.Columns[table.BfSectionGuideNmColumn.ColumnName].CellActivation = Activation.NoEdit;	// 拠点名称
            editBand.Columns[table.BfEnterWarehNameColumn.ColumnName].CellActivation = Activation.NoEdit;	// 倉庫名称

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            editBand.Columns[table.GoodsMakerCdColumn.ColumnName].CellActivation = Activation.NoEdit;		        // メーカーコード
            editBand.Columns[table.MakerNameColumn.ColumnName].CellActivation = Activation.NoEdit;		        // メーカー名称
            editBand.Columns[table.BLGoodsCodeColumn.ColumnName].CellActivation = Activation.NoEdit;		    // ＢＬコード
            editBand.Columns[table.BfShelfNoColumn.ColumnName].CellActivation = Activation.NoEdit;		    // 出庫棚番
            editBand.Columns[table.BfBeforeMoveCountColumn.ColumnName].CellActivation = Activation.NoEdit;	    // 出庫前数
            editBand.Columns[table.BfAfterMoveCountColumn.ColumnName].CellActivation = Activation.NoEdit;	    // 出庫後数
            editBand.Columns[table.ListPriceFlColumn.ColumnName].CellActivation = Activation.NoEdit;		    // 定価
            editBand.Columns[table.ListPriceFlViewColumn.ColumnName].CellActivation = Activation.NoEdit;		    // 定価
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // Style設定
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //editBand.Columns[table.GoodsCodeColumn.ColumnName].Style = ColumnStyle.Edit;					// 商品コード
            editBand.Columns[table.GoodsNoColumn.ColumnName].Style = ColumnStyle.Edit;					// 商品コード
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            editBand.Columns[table.GoodsGuideButtonColumn.ColumnName].Style = ColumnStyle.Button;			// 商品ガイドボタン
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //editBand.Columns[table.ProductNumberColumn.ColumnName].Style = ColumnStyle.Edit;				// 製造番号
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            editBand.Columns[table.MovingSupliStockColumn.ColumnName].Style = ColumnStyle.Edit;			// 仕入在庫出荷数
            editBand.Columns[table.MovingTrustStockColumn.ColumnName].Style = ColumnStyle.Edit;			// 受託在庫出荷数

            //editBand.Columns[table.StockDtiSlipNote1Column.ColumnName].Style = ColumnStyle.Edit;		// 備考

            // Button用個別設定
            editBand.Columns[table.GoodsGuideButtonColumn.ColumnName].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            editBand.Columns[table.GoodsGuideButtonColumn.ColumnName].ButtonDisplayStyle = ButtonDisplayStyle.Always;
            editBand.Columns[table.GoodsGuideButtonColumn.ColumnName].CellButtonAppearance.Image = this._guideButtonImage;
            editBand.Columns[table.GoodsGuideButtonColumn.ColumnName].CellButtonAppearance.ImageVAlign = Infragistics.Win.VAlign.Middle;
            editBand.Columns[table.GoodsGuideButtonColumn.ColumnName].CellButtonAppearance.ImageHAlign = Infragistics.Win.HAlign.Center;

            // フォーマット設定
            //string moneyFormat = "#,##0;-#,##0;''";
            string decimalFormat = "#,##0.00;-#,##0.00;''";
            string codeFormat = "#0;-#0;''";

            editBand.Columns[table.MovingSupliStockColumn.ColumnName].Format = decimalFormat; // 仕入在庫出荷数
            editBand.Columns[table.SlipRemainCountColumn.ColumnName].Format = decimalFormat;  // 仕入在庫残数
            editBand.Columns[table.MovingTrustStockColumn.ColumnName].Format = decimalFormat; // 受託在庫出荷数
            editBand.Columns[table.TrustRemainCountColumn.ColumnName].Format = decimalFormat; // 受託在庫残数

            editBand.Columns[table.StockUnitPriceFlColumn.ColumnName].Format = decimalFormat; // 単価
            //editBand.Columns[table.MovingPriceColumn.ColumnName].Format = moneyFormat;	// 移動金額

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            editBand.Columns[table.GoodsMakerCdColumn.ColumnName].Format = codeFormat;	    // メーカーコード
            editBand.Columns[table.BLGoodsCodeColumn.ColumnName].Format = codeFormat;        // ＢＬコード
            editBand.Columns[table.BfBeforeMoveCountColumn.ColumnName].Format = decimalFormat;	    // 出庫前数
            editBand.Columns[table.BfAfterMoveCountColumn.ColumnName].Format = decimalFormat;	    // 出庫後数
            editBand.Columns[table.ListPriceFlColumn.ColumnName].Format = decimalFormat;		    // 定価
            editBand.Columns[table.ListPriceFlViewColumn.ColumnName].Format = decimalFormat;		    // 定価
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // MaxLength設定
            editBand.Columns[table.MovingSupliStockColumn.ColumnName].MaxLength = 9; // 仕入在庫出荷数
            editBand.Columns[table.SlipRemainCountColumn.ColumnName].MaxLength = 9;  // 仕入在庫残数
            editBand.Columns[table.MovingTrustStockColumn.ColumnName].MaxLength = 9; // 受託在庫出荷数
            editBand.Columns[table.TrustRemainCountColumn.ColumnName].MaxLength = 9; // 受託在庫残数

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            editBand.Columns[table.GoodsMakerCdColumn.ColumnName].MaxLength = 6;		    // メーカーコード
            editBand.Columns[table.BLGoodsCodeColumn.ColumnName].MaxLength = 8;		    // ＢＬコード
            editBand.Columns[table.BfBeforeMoveCountColumn.ColumnName].MaxLength = 9;	    // 出庫前数
            editBand.Columns[table.BfAfterMoveCountColumn.ColumnName].MaxLength = 9;	    // 出庫後数
            editBand.Columns[table.ListPriceFlColumn.ColumnName].MaxLength = 11;		    // 定価
            editBand.Columns[table.ListPriceFlViewColumn.ColumnName].MaxLength = 11;		    // 定価
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
        }
           --- DEL 2008/07/14 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/14 Partsman用に変更

        /// <summary>
        /// グリッドエンターイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uGrid_Details_Enter(object sender, EventArgs e)
        {
            if (this.ultraGrid1.ActiveCell == null)
            {
                if (!this.ultraGrid1.PerformAction(UltraGridAction.ActivateCell))
                {
                    if (this.ultraGrid1.Rows.Count > 0)
                    {
                        this.ultraGrid1.ActiveCell = this.ultraGrid1.Rows[0].Cells[_stockMoveInputAcs.StockMoveDataTable.GoodsNoColumn.ColumnName];

                        // 次入力可能セル移動処理
                        this.MoveNextAllowEditCell(true);
                    }
                }
            }

            if (this.ultraGrid1.ActiveCell != null)
            {
                if ((!this.ultraGrid1.ActiveCell.IsInEditMode) && (this.ultraGrid1.ActiveCell.Activation == Activation.AllowEdit))
                {
                    this.ultraGrid1.PerformAction(UltraGridAction.EnterEditMode);
                }
                else
                {
                    this.ultraGrid1.PerformAction(UltraGridAction.NextCellByTab);
                }
            }
        }

        /// <summary>
        /// 次入力可能セル移動処理
        /// </summary>
        /// <param name="activeCellCheck">true:ActiveCellが入力可能の場合はNextに移動させない false:ActiveCellに関係なくNextに移動させる</param>
        /// <returns>true:セル移動完了 false:セル移動失敗</returns>
        private bool MoveNextAllowEditCell(bool activeCellCheck)
        {
            bool moved = false;
            bool performActionResult = false;

            if ((activeCellCheck) && (this.ultraGrid1.ActiveCell != null))
            {
                if ((this.ultraGrid1.ActiveCell.Activation == Activation.AllowEdit) &&
                    (this.ultraGrid1.ActiveCell.Column.CellActivation == Activation.AllowEdit))
                {
                    return true;
                }
            }

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            // 更新開始 (描画ストップ)
            this.ultraGrid1.BeginUpdate();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            
            while (!moved)
            {
                performActionResult = this.ultraGrid1.PerformAction(UltraGridAction.NextCellByTab);

                if (performActionResult)
                {
                    if ((this.ultraGrid1.ActiveCell.Activation == Activation.AllowEdit) &&
                        (this.ultraGrid1.ActiveCell.Column.CellActivation == Activation.AllowEdit))
                    {
                        moved = true;
                    }
                    else
                    {
                        moved = false;
                    }
                }
                else
                {
                    break;
                }
            }
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            // 更新終了（描画再開）
            this.ultraGrid1.EndUpdate();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            return performActionResult;
        }
                                                                                                                                                                                                                                                                                                       
        # endregion

        # region プライベートメソッド

        /// <summary>
        /// ActiveRowインデックス取得処理
        /// </summary>
        /// <returns>ActiveRowインデックス</returns>
        private int GetActiveRowIndex()
        {
            if (this.ultraGrid1.ActiveCell != null)
            {
                return this.ultraGrid1.ActiveCell.Row.Index;
            }
            else if (this.ultraGrid1.ActiveRow != null)
            {
                return this.ultraGrid1.ActiveRow.Index;
            }
            else
            {
                if (this.ultraGrid1.Selected.Rows.Count == 0)
                {
                    return -1;
                }
                else
                {
                    return this.ultraGrid1.Selected.Rows[0].Index;
                }
            }
        }

        /// <summary>
        /// 選択済み在庫移動行番号リスト取得処理
        /// </summary>
        /// <returns>選択済み仕入行番号リスト</returns>
        private List<int> GetSelectedStockMoveRowNoList()
        {
            UltraGridCell cell = this.ultraGrid1.ActiveCell;
            UltraGridRow activeRow = this.ultraGrid1.ActiveRow;
            SelectedRowsCollection rows = this.ultraGrid1.Selected.Rows;
            if ((cell == null) && (activeRow == null) && (rows == null)) return null;

            List<int> deleteIndexList = new List<int>();

            if ((rows != null) && (rows.Count > 0))
            {
                foreach (UltraGridRow row in rows)
                {
                    deleteIndexList.Add(_stockMoveInputAcs.StockMoveDataTable[row.Index].StockMoveRowNo);
                }
            }
            else if (cell != null)
            {
                deleteIndexList.Add(_stockMoveInputAcs.StockMoveDataTable[cell.Row.Index].StockMoveRowNo);
            }
            else if (activeRow != null)
            {
                deleteIndexList.Add(_stockMoveInputAcs.StockMoveDataTable[activeRow.Index].StockMoveRowNo);
            }

            return deleteIndexList;
        }

        #region DEL 2008/07/14 使用していないのでコメントアウト
        /* --- DEL 2008/07/14 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 選択済み在庫移動詳細行番号リスト取得処理
        /// </summary>
        /// <returns>選択済み仕入行番号リスト</returns>
        private List<int> GetSelectedStockMoveExpRowNoList()
        {
            UltraGridCell cell = this.ultraGrid1.ActiveCell;
            SelectedRowsCollection rows = this.ultraGrid1.Selected.Rows;
            if ((cell == null) && (rows == null)) return null;

            List<int> deleteIndexList = new List<int>();

            if (cell != null)
            {
                deleteIndexList.Add(_stockMoveInputAcs.StockMoveDataTable[cell.Row.Index].StockMoveRowNo);
            }
            else if (rows != null)
            {
                foreach (UltraGridRow row in rows)
                {
                    deleteIndexList.Add(_stockMoveInputAcs.StockMoveDataTable[row.Index].StockMoveRowNo);
                }
            }

            return deleteIndexList;
        }
           --- DEL 2008/07/14 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/14 使用していないのでコメントアウト

        // ----- ADD 2011/05/10 tianjw ------------------------------------------------------------------->>>>>
        // <summary>
        /// 出荷日を変更時、定価・原価を再取得する様に変更
        /// </summary>
        /// <remarks>
        /// <br>Note       : 出荷日を変更時、定価・原価を再取得する様に変更を行う。</br>
        /// <br>Programmer : tianjw</br>
        /// <br>Date       : 2011/05/10</br>
        /// <br>Update Note: 2011/05/16 朱俊成 出荷日を変更時、合計移動金額を再計算</br>
        /// <br></br>
        /// </remarks>
        public void ResetStockMoveDataTable()
        {
            string goodsNo = string.Empty;
            int makerCode = 0;
            GoodsUnitData goodsUnitData;

            if (this.ultraGrid1.Rows.Count != 0)
            {
                foreach (Infragistics.Win.UltraWinGrid.UltraGridRow gridDetailRow in this.ultraGrid1.Rows)
                {
                    // 品番
                    goodsNo = ChangeCellValueToString(gridDetailRow.Cells[_stockMoveDataTable.GoodsNoColumn.ColumnName].Value);
                    // メーカーコード
                    makerCode = ChangeCellValueToInt(gridDetailRow.Cells[_stockMoveDataTable.GoodsMakerCdColumn.ColumnName].Value);
                    if (!string.IsNullOrEmpty(goodsNo))
                    {
                        // 商品検索
                        int status = SearchGoods(goodsNo, makerCode, out goodsUnitData);

                        if (status == 0)
                        {
                            // 定価
                            GoodsPrice goodsPrice = this._goodsAcs.GetGoodsPriceFromGoodsPriceList(getSlipmentDay(), goodsUnitData.GoodsPriceList);
                            // ADD 2011/05/20 -------------------------->>>>>>
                            // 入力した仕入先を設定します
                            goodsUnitData.SupplierCd = ChangeCellValueToInt(gridDetailRow.Cells[_stockMoveDataTable.SupplierCdColumn.ColumnName].Value);
                            // ADD 2011/05/20 --------------------------<<<<<<
                            if (goodsPrice == null)
                            {
                                _stockMoveDataTable[gridDetailRow.Index].ListPriceFl = 0;
                                _stockMoveDataTable[gridDetailRow.Index].ListPriceFlView = "";
                            }
                            else
                            {
                                _stockMoveDataTable[gridDetailRow.Index].ListPriceFl = goodsPrice.ListPrice;
                                _stockMoveDataTable[gridDetailRow.Index].ListPriceFlView = goodsPrice.ListPrice.ToString("###,###,###,##0");
                            }
                            // 仕入単価
                            _stockMoveDataTable[gridDetailRow.Index].StockUnitPriceFl = GetStockUnitPrice(goodsUnitData);
                            _stockMoveDataTable[gridDetailRow.Index].BfStockUnitPriceFl = GetStockUnitPrice(goodsUnitData);
                        }
                    }
                }
                // ADD 2011/05/16 zhujc Redmine#20881------------------>>>>>
                this.TotalPriceSetting();
                // ADD 2011/05/16 zhujc ------------------<<<<<
            }

        }
        // ----- ADD 2011/05/10 tianjw -------------------------------------------------------------------<<<<<

        // ----- ADD 2011/05/20 朱俊成 ------------------------------------------------------------------->>>>>
        // <summary>
        /// 明細行オブジェクトが存在するかどうかをチェックします
        /// </summary>
        /// <remarks>
        /// <br>Note       : 出明細行オブジェクトが存在。</br>
        /// <br>Programmer : 朱俊成</br>
        /// <br>Date       : 2011/05/20</br>
        /// <br></br>
        /// </remarks>
        public bool ExistDetailData()
        {
            if (this.ultraGrid1.Rows.Count != 0)
            {
                foreach (Infragistics.Win.UltraWinGrid.UltraGridRow gridDetailRow in this.ultraGrid1.Rows)
                {
                    // 品番
                    if (!string.IsNullOrEmpty(ChangeCellValueToString(gridDetailRow.Cells[_stockMoveDataTable.GoodsNoColumn.ColumnName].Value)))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        // ----- ADD 2011/05/20 朱俊成 -------------------------------------------------------------------<<<<<

        /// <summary>
        /// 在庫移動テーブル格納処理(在庫検索・在庫情報から)
        /// </summary>
        /// <param name="stockList"></param>
        /// <param name="activeCell"></param>
        /// <br>Update Note: 2011/04/11 鄧潘ハン ①明細に仕入先を追加する</br>　
        /// <br>　　　　　　　　　　　　　　　　 ②定価取得時の不具合修正。</br>　
        private void StockMoveDataTableFromStockSearchRet(GoodsUnitData goodsUnitData, UltraGridCell activeCell)
        {
            List<Stock> stockList = goodsUnitData.StockList;

            // 同一商品レコードチェック
            if (CheckSameGoods(goodsUnitData, activeCell.Row.Index) == true)
            {
                // 同一商品コードが読み込まれた場合エラーとする
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "同一商品のレコードが存在するため読み込めません。",
                    -1,
                    MessageBoxButtons.OK);

                // 行内容クリア
                ClearRecordInput(this.ultraGrid1.ActiveCell.Row.Index);
                // --- ADD 2011/05/10 ---------------------------------------->>>>>
                this._sameGoodNoFlg = true;
                this._index = ultraGrid1.ActiveRow.Index;
                this._key = _stockMoveDataTable.GoodsNoColumn.ColumnName;
                // --- ADD 2011/05/10 ----------------------------------------<<<<<
                return;
            }

            // アクティブセルがない場合
            if (activeCell == null)
            {
                activeCell = ultraGrid1.Rows[0].Cells[1];
            }
            
            int index = activeCell.Row.Index;

            bool warehouseExistFlg = false;
            bool afWarehouseExistFlg = false; // ADD 2014/04/17 T.Miyamoto

            Stock afStock = new Stock();

            // 在庫ガイド結果を在庫移動テーブルに格納
            foreach (Stock stock in stockList)
            {
                if (stock.WarehouseCode.Trim() == _stockMoveHeader.AfEnterWarehCode.Trim())
                {
                    afStock = stock.Clone();
                    afWarehouseExistFlg = true; // ADD 2014/04/17 T.Miyamoto
                    break;
                }
            }
            // --- ADD 2014/04/17 T.Miyamoto ------------------------------>>>>>
            if ((stockList.Count == 0) || (afWarehouseExistFlg == false))
            {
                // 入庫前数
                _stockMoveDataTable[index].AfBeforeMoveCount = "0.00";
            }
            else
            {
                // --- UPD 2014/05/13 T.Miyamoto ------------------------------>>>>>
                //// --- UPD 2014/05/09 T.Miyamoto ------------------------------>>>>>
                ////// 入庫前数
                ////_stockMoveDataTable[index].AfBeforeMoveCount = afStock.SupplierStock.ToString("N");
                //// 入庫前数 ＝ 仕入在庫数 － 移動中仕入在庫数
                //_stockMoveDataTable[index].AfBeforeMoveCount = (afStock.SupplierStock - afStock.MovingSupliStock).ToString("N");
                //// --- UPD 2014/05/09 T.Miyamoto ------------------------------<<<<<
                // 入庫前数 ＝ 出荷可能数
                _stockMoveDataTable[index].AfBeforeMoveCount = (afStock.ShipmentPosCnt).ToString("N");
                // --- UPD 2014/05/13 T.Miyamoto ------------------------------<<<<<
            }
            // --- ADD 2014/04/17 T.Miyamoto ------------------------------<<<<<

            foreach (Stock stock in stockList)
            {
                if (stock.WarehouseCode.Trim() != _stockMoveHeader.BfEnterWarehCode.Trim())
                {
                    continue;
                }

                warehouseExistFlg = true;

                this.ultraGrid1.Rows[index].Cells[_stockMoveDataTable.StockMoveRowNoColumn.ColumnName].Tag = true;

                // 新規読込時はヘッダ情報は企業コードのみ格納する。
                // 企業コード
                this._stockMoveDataTable[index].EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;

                // 在庫移動形式(1:在庫移動 2:倉庫移動)
                if (this._stockMoveHeader.AfSectionCode != "")
                {
                    // 入庫拠点の指定があった場合は在庫移動
                    this._stockMoveDataTable[index].StockMoveFormal = 1;
                }
                else
                {
                    // それ以外は倉庫移動
                    this._stockMoveDataTable[index].StockMoveFormal = 2;
                }
                // 在庫移動伝票番号
                if (this._stockMoveInputInitAcs.RegistMode == 0)
                {
                    this._stockMoveDataTable[index].StockMoveSlipNo = 0;
                }
                else if (this._stockMoveInputInitAcs.RegistMode == 1)
                {
                    // 今のところ一番先頭のレコードから伝票番号をとる
                    this._stockMoveDataTable[index].StockMoveSlipNo = this._stockMoveDataTable[0].StockMoveSlipNo;
                }
                // 在庫移動行番号
                this._stockMoveDataTable[index].StockMoveRowNo = index + 1;
                // メーカーコード
                if (stock.GoodsMakerCd == 0)
                {
                    this._stockMoveDataTable[index].GoodsMakerCd = "";
                    this.ultraGrid1.Rows[index].Cells[_stockMoveDataTable.GoodsMakerCdColumn.ColumnName].Tag = "";
                }
                else
                {
                    this._stockMoveDataTable[index].GoodsMakerCd = stock.GoodsMakerCd.ToString().PadLeft(4, '0');
                    this.ultraGrid1.Rows[index].Cells[_stockMoveDataTable.GoodsMakerCdColumn.ColumnName].Tag = stock.GoodsMakerCd.ToString().PadLeft(4, '0');
                }
                // 商品コード
                this._stockMoveDataTable[index].GoodsNo = stock.GoodsNo;
                this.ultraGrid1.Rows[index].Cells[_stockMoveDataTable.GoodsNoColumn.ColumnName].Tag = stock.GoodsNo;
                // 商品名称
                this._stockMoveDataTable[index].GoodsName = goodsUnitData.GoodsName;
                // --- ADD m.suzuki 2010/04/15 ---------->>>>>
                // 商品名称カナ
                this._stockMoveDataTable[index].GoodsNameKana = goodsUnitData.GoodsNameKana;
                // --- ADD m.suzuki 2010/04/15 ----------<<<<<
                // 更新拠点コード
                this._stockMoveDataTable[index].UpdateSecCd = LoginInfoAcquisition.Employee.BelongSectionCode;
                // 出庫拠点コード
                this._stockMoveDataTable[index].BfSectionCode = this._stockMoveHeader.BfSectionCode;
                // 出庫倉庫コード
                this._stockMoveDataTable[index].BfEnterWarehCode = this._stockMoveHeader.BfEnterWarehCode;
                // 出庫倉庫棚番
                this._stockMoveDataTable[index].BfShelfNo = stock.WarehouseShelfNo;
                // 入庫拠点コード
                this._stockMoveDataTable[index].AfSectionCode = this._stockMoveHeader.AfSectionCode;
                // 入庫拠点ガイド名称
                this._stockMoveDataTable[index].AfSectionGuideNm = this._stockMoveHeader.AfSectionGuideName;
                // 入庫倉庫コード
                this._stockMoveDataTable[index].AfEnterWarehCode = this._stockMoveHeader.AfEnterWarehCode;
                // 入庫倉庫名称
                this._stockMoveDataTable[index].AfEnterWarehName = this._stockMoveHeader.AfEnterWarehName;
                // 入庫倉庫棚番
                this._stockMoveDataTable[index].AfShelfNo = afStock.WarehouseShelfNo.Trim();
                // 出荷予定日
                this._stockMoveDataTable[index].ShipmentScdlDay = "";
                // 出荷確定日
                this._stockMoveDataTable[index].ShipmentFixDay = "";
                // 入荷日
                this._stockMoveDataTable[index].ArrivalGoodsDay = "";
                // 移動状態
                /* --- DEL 2008/07/14 --------------------------------------------------------------------->>>>>
                // 在庫全体設定マスタ(在庫移動確定区分)によって振り分け(1:出荷確定有り 2:出荷確定無し)
                this._stockMoveDataTable[index].MoveStatus = this._stockMoveInputInitAcs.StockMoveFixCode;
                   --- DEL 2008/07/14 ---------------------------------------------------------------------<<<<<*/
                // 在庫移動入力従業員コード
                this._stockMoveDataTable[index].StockMvEmpCode = "";
                // 在庫移動入力従業員名称
                this._stockMoveDataTable[index].StockMvEmpName = "";
                // 出荷担当従業員コード
                this._stockMoveDataTable[index].ShipAgentCd = "";
                // 出荷担当従業員名称
                this._stockMoveDataTable[index].ShipAgentNm = "";
                // 在庫全体設定マスタ(受託在庫拠点間移動区分・受託在庫倉庫間移動区分)によって振り分け(1:移動なし 2:移動あり)
                // 本来であればどちらか片方に数量1以上が入る。
                // 移動中仕入在庫数
                this._stockMoveDataTable[index].MovingSupliStock = 1;
                // 変更前移動中仕入在庫数
                this._stockMoveDataTable[index].BfMovingSupliStock = 0;
                // 移動中受託在庫数
                this._stockMoveDataTable[index].MovingTrustStock = 0;
                // 引取担当従業員コード
                this._stockMoveDataTable[index].ReceiveAgentCd = "";
                // 引取担当従業員名称
                this._stockMoveDataTable[index].ReceiveAgentNm = "";
                // 伝票摘要
                this._stockMoveDataTable[index].Outline = "";
                // 倉庫備考1
                this._stockMoveDataTable[index].WarehouseNote1 = "";
                // --- UPD 2014/05/13 T.Miyamoto ------------------------------>>>>>
                //// 仕入在庫残数
                //// (仕入在庫数 － 仕入在庫委託数 － 移動中仕入在庫数)
                //double slipShipmentStock = stock.SupplierStock - stock.MovingSupliStock;
                // 出荷可能数
                double slipShipmentStock = stock.ShipmentPosCnt;
                // --- UPD 2014/05/13 T.Miyamoto ------------------------------<<<<<
                // 移動金額
                _stockMoveDataTable[index].MovingPrice = 0;
                // 行ステータス
                _stockMoveDataTable[index].RowStatus = 0;
                // グロスフラグ
                _stockMoveDataTable[index].GrossFlag = true;
                // 出庫後数
                // 2009.07.07 >>>
                //_stockMoveDataTable[index].BfAfterMoveCount = slipShipmentStock.ToString("N");
                _stockMoveDataTable[index].BfAfterMoveCount = ( slipShipmentStock - this._stockMoveDataTable[index].MovingSupliStock).ToString("N");
                // 2009.07.07 <<<
                // 出庫前数
                _stockMoveDataTable[index].BfBeforeMoveCount = slipShipmentStock.ToString("N");
                // --- UPD 2014/04/17 T.Miyamoto ------------------------------>>>>>
                //// --- ADD 2014/04/09 T.Miyamoto ------------------------------>>>>>
                //// 入庫前数
                //_stockMoveDataTable[index].AfBeforeMoveCount = afStock.SupplierStock.ToString("N");
                //// 入庫後数
                //_stockMoveDataTable[index].AfAfterMoveCount = (afStock.SupplierStock + this._stockMoveDataTable[index].MovingSupliStock).ToString("N");
                //// --- ADD 2014/04/09 T.Miyamoto ------------------------------<<<<<
                // 入庫後数
                _stockMoveDataTable[index].AfAfterMoveCount = (double.Parse(_stockMoveDataTable[index].AfBeforeMoveCount) + this._stockMoveDataTable[index].MovingSupliStock).ToString("N");
                // --- UPD 2014/04/17 T.Miyamoto ------------------------------<<<<<
                // ＢＬ商品コード
                if (goodsUnitData.BLGoodsCode == 0)
                {
                    _stockMoveDataTable[index].BLGoodsCode = "";
                }
                else
                {
                    _stockMoveDataTable[index].BLGoodsCode = goodsUnitData.BLGoodsCode.ToString().PadLeft(5, '0');
                }
                //---ADD 2011/04/11----------------------------------------------------------->>>>>
                if (goodsUnitData.SupplierCd == 0)
                {
                    _stockMoveDataTable[index].SupplierCd = "";
                }
                else
                {
                    _stockMoveDataTable[index].SupplierCd = goodsUnitData.SupplierCd.ToString().PadLeft(6, '0');
                }
                _stockMoveDataTable[index].SupplierSnm = goodsUnitData.SupplierSnm;
                //---ADD 2011/04/11-----------------------------------------------------------<<<<<
                // ＢＬ商品コード名称
                _stockMoveDataTable[index].BLGoodsFullName = this._stockMoveInputAcs.GetBLGoodsFullName(goodsUnitData.BLGoodsCode);
                // ＢＬ商品コード枝番
                _stockMoveDataTable[index].BLGoodsCdDerivedNo = 0;

                // 定価
                //---UPD 2011/04/11----------------------------------------------------------->>>>>
                //GoodsPrice goodsPrice = this._goodsAcs.GetGoodsPriceFromGoodsPriceList(DateTime.Today, goodsUnitData.GoodsPriceList);// DEL 2011/04/11
                GoodsPrice goodsPrice = this._goodsAcs.GetGoodsPriceFromGoodsPriceList(getSlipmentDay(), goodsUnitData.GoodsPriceList);
                //---UPD 2011/04/11-----------------------------------------------------------<<<<<
                if (goodsPrice == null)
                {
                    _stockMoveDataTable[index].ListPriceFl = 0;
                    _stockMoveDataTable[index].ListPriceFlView = "";
                }
                else
                {
                    //if (goodsPrice.OpenPriceDiv != 0)
                    //{
                    //    _stockMoveDataTable[index].ListPriceFl = goodsPrice.ListPrice;
                    //    _stockMoveDataTable[index].ListPriceFlView = "オープン価格";
                    //}
                    //else
                    //{
                    //    _stockMoveDataTable[index].ListPriceFl = goodsPrice.ListPrice;
                    //    _stockMoveDataTable[index].ListPriceFlView = goodsPrice.ListPrice.ToString("###,###,###,##0");
                    //}
                    _stockMoveDataTable[index].ListPriceFl = goodsPrice.ListPrice;
                    _stockMoveDataTable[index].ListPriceFlView = goodsPrice.ListPrice.ToString("###,###,###,##0");
                }
                // 仕入単価
                //_stockMoveDataTable[index].StockUnitPriceFl = goodsPrice.SalesUnitCost;
                _stockMoveDataTable[index].StockUnitPriceFl = GetStockUnitPrice(goodsUnitData);
                _stockMoveDataTable[index].BfStockUnitPriceFl = GetStockUnitPrice(goodsUnitData);

                // 提供区分
                _stockMoveDataTable[index].OfferKubun = goodsUnitData.OfferKubun;
                
                // ---ADD 2009/06/04 不具合対応[13200] --------------------------------------------------->>>>>
                // 仕入先
                // ※更新時にCustomerName＋CustomerName2としている為、CustomerNameには略称、CustomerName2はstring.emptyとする
                _stockMoveDataTable[index].CustomerCode = goodsUnitData.SupplierCd;
                _stockMoveDataTable[index].CustomerName = goodsUnitData.SupplierSnm;
                _stockMoveDataTable[index].CustomerName2 = "";
                // ---ADD 2009/06/04 不具合対応[13200] ---------------------------------------------------<<<<<

                // 行状態を変更
                this.SettingGridRow( index );

                // 最終行の場合は、１行追加する
                if (index == _stockMoveInputAcs.StockMoveDataTable.Rows.Count - 1)
                {
                    this._stockMoveInputAcs.AddStockDetailRow();
                }

                index++;
            }

            if ((stockList.Count == 0) || (warehouseExistFlg == false))
            {
                CopyToStockMoveDataTableFromGoodsUnitData(goodsUnitData, afStock, activeCell.Row.Index);
            }
            else
            {
                double movingSupliStock = 1;

                // 出庫前数
                double bfBeforeMoveCount = ChangeCellValueToDouble(this.ultraGrid1.Rows[activeCell.Row.Index].Cells[_stockMoveDataTable.BfBeforeMoveCountColumn.ColumnName].Value);

                // 在庫切れ出荷区分チェック
                int stockTolerncShipmDiv = this._stockMoveInputAcs.GetStockTolerncShipmDiv(LoginInfoAcquisition.Employee.BelongSectionCode);
                switch (stockTolerncShipmDiv)
                {
                    // 警告、警告＋再入力
                    case 1:
                    case 2:
                        {
                            if (movingSupliStock > bfBeforeMoveCount)
                            {
                                TMsgDisp.Show(this,
                                            emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                            this.Name,
                                            "出庫数が在庫数を上回ります。",
                                            -1,
                                            MessageBoxButtons.OK);

                                if (stockTolerncShipmDiv == 2)
                                {
                                    this.ultraGrid1.AfterCellUpdate -= this.ultraGrid1_AfterCellUpdate;
                                    this.ultraGrid1.Rows[activeCell.Row.Index].Cells[_stockMoveDataTable.MovingSupliStockColumn.ColumnName].Value = 0;
                                    this.ultraGrid1.AfterCellUpdate += this.ultraGrid1_AfterCellUpdate;
                                    this._movingSupliStockFlg = true;
                                }
                            }
                            break;
                        }
                    case 3:
                        {
                            if (movingSupliStock > bfBeforeMoveCount)
                            {
                                this.ultraGrid1.AfterCellUpdate -= this.ultraGrid1_AfterCellUpdate;
                                this.ultraGrid1.Rows[activeCell.Row.Index].Cells[_stockMoveDataTable.MovingSupliStockColumn.ColumnName].Value = 0;
                                this.ultraGrid1.AfterCellUpdate += this.ultraGrid1_AfterCellUpdate;
                                this._movingSupliStockFlg = true;
                            }
                            break;
                        }
                }
            }

            // 移動合計更新デリゲート
            this.TotalPriceSetting();

            // データテーブル更新フラグ
            this.tableUpdateFlg = true;
        }

        /// <summary>
        /// 在庫移動テーブル格納処理(商品連結データから)
        /// </summary>
        /// <param name="goodsUnitData">商品連結データ</param>
        /// <param name="stock">在庫マスタ</param>
        /// <param name="index">行インデックス</param>
        /// <br>Update Note: 2011/04/11 鄧潘ハン ①明細に仕入先を追加する</br>　
        /// <br>　　　　　　　　　　　　　　　　 ②定価取得時の不具合修正。</br>　
        private void CopyToStockMoveDataTableFromGoodsUnitData(GoodsUnitData goodsUnitData, Stock stock, int index)
        {
            this.ultraGrid1.Rows[index].Cells[_stockMoveDataTable.StockMoveRowNoColumn.ColumnName].Tag = false;

            // 新規読込時はヘッダ情報は企業コードのみ格納する。
            // 企業コード
            this._stockMoveDataTable[index].EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            // 在庫移動形式(1:在庫移動 2:倉庫移動)
            if (this._stockMoveHeader.AfSectionCode != "")
            {
                // 入庫拠点の指定があった場合は在庫移動
                this._stockMoveDataTable[index].StockMoveFormal = 1;
            }
            else
            {
                // それ以外は倉庫移動
                this._stockMoveDataTable[index].StockMoveFormal = 2;
            }
            // 在庫移動伝票番号
            if (this._stockMoveInputInitAcs.RegistMode == 0)
            {
                this._stockMoveDataTable[index].StockMoveSlipNo = 0;
            }
            else if (this._stockMoveInputInitAcs.RegistMode == 1)
            {
                // 今のところ一番先頭のレコードから伝票番号をとる
                this._stockMoveDataTable[index].StockMoveSlipNo = this._stockMoveDataTable[0].StockMoveSlipNo;
            }
            // 在庫移動行番号
            this._stockMoveDataTable[index].StockMoveRowNo = index + 1;
            // メーカーコード
            if (goodsUnitData.GoodsMakerCd == 0)
            {
                this._stockMoveDataTable[index].GoodsMakerCd = "";
                this.ultraGrid1.Rows[index].Cells[_stockMoveDataTable.GoodsMakerCdColumn.ColumnName].Tag = "";
            }
            else
            {
                this._stockMoveDataTable[index].GoodsMakerCd = goodsUnitData.GoodsMakerCd.ToString().PadLeft(4, '0');
                this.ultraGrid1.Rows[index].Cells[_stockMoveDataTable.GoodsMakerCdColumn.ColumnName].Tag = goodsUnitData.GoodsMakerCd.ToString().PadLeft(4, '0');
            }
            // 商品コード
            this._stockMoveDataTable[index].GoodsNo = goodsUnitData.GoodsNo;
            this.ultraGrid1.Rows[index].Cells[_stockMoveDataTable.GoodsNoColumn.ColumnName].Tag = goodsUnitData.GoodsNo;
            // 商品名称
            this._stockMoveDataTable[index].GoodsName = goodsUnitData.GoodsName;
            // --- ADD m.suzuki 2010/04/15 ---------->>>>>
            // 商品名称カナ
            this._stockMoveDataTable[index].GoodsNameKana = goodsUnitData.GoodsNameKana;
            // --- ADD m.suzuki 2010/04/15 ----------<<<<<
            // 更新拠点コード
            this._stockMoveDataTable[index].UpdateSecCd = LoginInfoAcquisition.Employee.BelongSectionCode;
            // 出庫拠点コード
            this._stockMoveDataTable[index].BfSectionCode = this._stockMoveHeader.BfSectionCode;
            // 出庫倉庫コード
            this._stockMoveDataTable[index].BfEnterWarehCode = this._stockMoveHeader.BfEnterWarehCode;
            // 出庫倉庫棚番
            this._stockMoveDataTable[index].BfShelfNo = "";
            // 入庫拠点コード
            this._stockMoveDataTable[index].AfSectionCode = this._stockMoveHeader.AfSectionCode;
            // 入庫拠点ガイド名称
            this._stockMoveDataTable[index].AfSectionGuideNm = this._stockMoveHeader.AfSectionGuideName;
            // 入庫倉庫コード
            this._stockMoveDataTable[index].AfEnterWarehCode = this._stockMoveHeader.AfEnterWarehCode;
            // 入庫倉庫名称
            this._stockMoveDataTable[index].AfEnterWarehName = this._stockMoveHeader.AfEnterWarehName;
            // 入庫倉庫棚番
            this._stockMoveDataTable[index].AfShelfNo = stock.WarehouseShelfNo.Trim();
            // 出荷予定日
            this._stockMoveDataTable[index].ShipmentScdlDay = "";
            // 出荷確定日
            this._stockMoveDataTable[index].ShipmentFixDay = "";
            // 入荷日
            this._stockMoveDataTable[index].ArrivalGoodsDay = "";
            // 移動状態
            /* --- DEL 2008/07/14 --------------------------------------------------------------------->>>>>
            // 在庫全体設定マスタ(在庫移動確定区分)によって振り分け(1:出荷確定有り 2:出荷確定無し)
            this._stockMoveDataTable[index].MoveStatus = this._stockMoveInputInitAcs.StockMoveFixCode;
               --- DEL 2008/07/14 ---------------------------------------------------------------------<<<<<*/
            // 在庫移動入力従業員コード
            this._stockMoveDataTable[index].StockMvEmpCode = "";
            // 在庫移動入力従業員名称
            this._stockMoveDataTable[index].StockMvEmpName = "";
            // 出荷担当従業員コード
            this._stockMoveDataTable[index].ShipAgentCd = "";
            // 出荷担当従業員名称
            this._stockMoveDataTable[index].ShipAgentNm = "";
            // 在庫全体設定マスタ(受託在庫拠点間移動区分・受託在庫倉庫間移動区分)によって振り分け(1:移動なし 2:移動あり)
            // 本来であればどちらか片方に数量1以上が入る。
            // 移動中仕入在庫数
            this._stockMoveDataTable[index].MovingSupliStock = 1;
            // 変更前移動中仕入在庫数
            this._stockMoveDataTable[index].BfMovingSupliStock = 0;
            // 移動中受託在庫数
            this._stockMoveDataTable[index].MovingTrustStock = 0;
            // 引取担当従業員コード
            this._stockMoveDataTable[index].ReceiveAgentCd = "";
            // 引取担当従業員名称
            this._stockMoveDataTable[index].ReceiveAgentNm = "";
            // 伝票摘要
            this._stockMoveDataTable[index].Outline = "";
            // 倉庫備考1
            this._stockMoveDataTable[index].WarehouseNote1 = "";
            // 移動金額
            _stockMoveDataTable[index].MovingPrice = 0;
            // 行ステータス
            _stockMoveDataTable[index].RowStatus = 0;
            // グロスフラグ
            _stockMoveDataTable[index].GrossFlag = true;
            // --- UPD 2014/04/17 T.Miyamoto ------------------------------>>>>>
            //// 出庫後数
            //_stockMoveDataTable[index].BfAfterMoveCount = "0.00";
            //// 出庫前数
            //_stockMoveDataTable[index].BfBeforeMoveCount = "0.00";
            //// --- ADD 2014/04/09 T.Miyamoto ------------------------------>>>>>
            //// 入庫後数
            //_stockMoveDataTable[index].AfAfterMoveCount = "0.00";
            //// 入庫前数
            //_stockMoveDataTable[index].AfAfterMoveCount = "0.00";
            //// --- ADD 2014/04/09 T.Miyamoto ------------------------------<<<<<
            // 出庫前数
            _stockMoveDataTable[index].BfBeforeMoveCount = "0.00";
            // 出庫後数
            _stockMoveDataTable[index].BfAfterMoveCount = (double.Parse(_stockMoveDataTable[index].BfBeforeMoveCount) - this._stockMoveDataTable[index].MovingSupliStock).ToString("N");
            // 入庫後数
            _stockMoveDataTable[index].AfAfterMoveCount = (double.Parse(_stockMoveDataTable[index].AfBeforeMoveCount) + this._stockMoveDataTable[index].MovingSupliStock).ToString("N");
            // --- UPD 2014/04/17 T.Miyamoto ------------------------------<<<<<
            // ＢＬ商品コード
            if (goodsUnitData.BLGoodsCode == 0)
            {
                _stockMoveDataTable[index].BLGoodsCode = "";
            }
            else
            {
                _stockMoveDataTable[index].BLGoodsCode = goodsUnitData.BLGoodsCode.ToString().PadLeft(5, '0');
            }
            //---ADD 2011/04/11----------------------------------------------------------->>>>>
            if (goodsUnitData.SupplierCd == 0)
            {
                _stockMoveDataTable[index].SupplierCd = "";
            }
            else
            {
                _stockMoveDataTable[index].SupplierCd = goodsUnitData.SupplierCd.ToString().PadLeft(6, '0');
            }
            _stockMoveDataTable[index].SupplierSnm = goodsUnitData.SupplierSnm;
            //---ADD 2011/04/11-----------------------------------------------------------<<<<<
            // ＢＬ商品コード名称
            _stockMoveDataTable[index].BLGoodsFullName = this._stockMoveInputAcs.GetBLGoodsFullName(goodsUnitData.BLGoodsCode);
            // ＢＬ商品コード枝番
            _stockMoveDataTable[index].BLGoodsCdDerivedNo = 0;

            // 定価
            //---UPD 2011/04/11----------------------------------------------------------->>>>>
            //GoodsPrice goodsPrice = this._goodsAcs.GetGoodsPriceFromGoodsPriceList(DateTime.Today, goodsUnitData.GoodsPriceList);// DEL 2011/04/11
            GoodsPrice goodsPrice = this._goodsAcs.GetGoodsPriceFromGoodsPriceList(getSlipmentDay(), goodsUnitData.GoodsPriceList);
            //---UPD 2011/04/11-----------------------------------------------------------<<<<<
            if (goodsPrice == null)
            {
                _stockMoveDataTable[index].ListPriceFl = 0;
                _stockMoveDataTable[index].ListPriceFlView = "";
            }
            else
            {
                if (goodsPrice.OpenPriceDiv != 0)
                {
                    _stockMoveDataTable[index].ListPriceFl = goodsPrice.ListPrice;
                    //_stockMoveDataTable[index].ListPriceFlView = "オープン価格";
                    _stockMoveDataTable[index].ListPriceFlView = "";
                }
                else
                {
                    _stockMoveDataTable[index].ListPriceFl = goodsPrice.ListPrice;
                    _stockMoveDataTable[index].ListPriceFlView = goodsPrice.ListPrice.ToString("###,###,###,##0");
                }
            }

            // ---ADD 2009/06/29 不具合対応[13659] --------------------------------------------------->>>>>
            // 仕入先
            // ※更新時にCustomerName＋CustomerName2としている為、CustomerNameには略称、CustomerName2はstring.emptyとする
            _stockMoveDataTable[index].CustomerCode = goodsUnitData.SupplierCd;
            _stockMoveDataTable[index].CustomerName = goodsUnitData.SupplierSnm;
            _stockMoveDataTable[index].CustomerName2 = "";
            // ---ADD 2009/06/29 不具合対応[13659] ---------------------------------------------------<<<<<

            // 仕入単価
            //_stockMoveDataTable[index].StockUnitPriceFl = goodsPrice.SalesUnitCost;
            _stockMoveDataTable[index].StockUnitPriceFl = GetStockUnitPrice(goodsUnitData);
            _stockMoveDataTable[index].BfStockUnitPriceFl = GetStockUnitPrice(goodsUnitData);

            // 提供区分
            _stockMoveDataTable[index].OfferKubun = goodsUnitData.OfferKubun;

            // 行状態を変更
            this.SettingGridRow(index);

            // 最終行の場合は、１行追加する
            if (index == _stockMoveInputAcs.StockMoveDataTable.Rows.Count - 1)
            {
                this._stockMoveInputAcs.AddStockDetailRow();
            }
        }

        /// <summary>
        /// 同一商品チェック処理
        /// </summary>
        /// <param name="goodsUnitDataList">商品マスタリスト</param>
        /// <returns>true:同一商品あり／false:同一商品なし</returns>
        private bool CheckSameGoods(GoodsUnitData goodsUnitData, int rowIndex)
        {
            for (int index = 0; index < this.ultraGrid1.Rows.Count; index++)
            {
                if (index == rowIndex)
                {
                    continue;
                }

                string goodsNo = ChangeCellValueToString(this.ultraGrid1.Rows[index].Cells[_stockMoveDataTable.GoodsNoColumn.ColumnName].Value);
                int makerCode = ChangeCellValueToInt(this.ultraGrid1.Rows[index].Cells[_stockMoveDataTable.GoodsMakerCdColumn.ColumnName].Value);

                if ((goodsNo.Trim() == goodsUnitData.GoodsNo.Trim()) && (makerCode == goodsUnitData.GoodsMakerCd))
                {
                    return (true);
                }
            }
            return (false);
        }

        #region DEL 2008/07/14 Partsman用に変更
        /* --- DEL 2008/07/14 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 在庫移動テーブル格納処理(在庫検索・在庫情報から)
        /// </summary>
        private void StockMoveDataTableFromStockSearchRet(List<Stock> stockSearchRetList, UltraGridCell activeCell)
        {
            # region [入力チェック]

            // 同一商品レコードチェック
            if (CheckSameGoods(stockSearchRetList) == true)
            {
                // 同一商品コードが読み込まれた場合エラーとする
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "同一商品のレコードが存在するため読み込めません。",
                    -1,
                    MessageBoxButtons.OK);

                _errGoodsNo = true;
                return;
            }
            # endregion

            StockMove stockMove = new StockMove();

            // アクティブセルがない場合
            if (activeCell == null)
            {
                activeCell = ultraGrid1.Rows[0].Cells[1];
            }

            int index = activeCell.Row.Index;

            // 在庫ガイド結果を在庫移動テーブルに格納
            foreach (StockExpansion stockSearchRet in stockSearchRetList)
            {
                # region [入庫在庫有無判定]
                if (_stockMoveHeader.AfSectionCode == _stockMoveHeader.BfSectionCode)
                {
                    // 入庫在庫有無判定（同一拠点内）
                    if (CheckArrivalSideExistsOnSection(stockSearchRet) == false)
                    {
                        TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_INFO,
                            this.Name,
                            "入庫に在庫が存在しない為、入力出来ません。\r\n" + stockSearchRet.MakerName + " " + stockSearchRet.GoodsNo,
                            -1,
                            MessageBoxButtons.OK);

                        continue;
                    }
                }
                else
                {
                    // 入庫在庫有無判定（他拠点間）
                    if (CheckArrivalSideExists(stockSearchRet) == false)
                    {
                        TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_INFO,
                            this.Name,
                            "入庫が在庫管理しない設定の為、入力出来ません。\r\n" + stockSearchRet.MakerName + " " + stockSearchRet.GoodsNo,
                            -1,
                            MessageBoxButtons.OK);

                        continue;
                    }
                }
                # endregion

                # region [行セット処理]
                // 新規読込時はヘッダ情報は企業コードのみ格納する。
                // 企業コード
                _stockMoveDataTable[index].EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;

                // 在庫移動形式(1:在庫移動 2:倉庫移動)
                if (_stockMoveHeader.AfSectionCode != "")
                {
                    // 入庫拠点の指定があった場合は在庫移動
                    _stockMoveDataTable[index].StockMoveFormal = 1;
                }
                else
                {
                    // それ以外は倉庫移動
                    _stockMoveDataTable[index].StockMoveFormal = 2;
                }
                // 在庫移動伝票番号
                if (_stockMoveInputInitAcs.RegistMode == 0)
                {
                    _stockMoveDataTable[index].StockMoveSlipNo = 0;
                }
                else if (_stockMoveInputInitAcs.RegistMode == 1)
                {
                    // 今のところ一番先頭のレコードから伝票番号をとる
                    _stockMoveDataTable[index].StockMoveSlipNo = _stockMoveDataTable[0].StockMoveSlipNo;
                }
                // 在庫移動行番号
                _stockMoveDataTable[index].StockMoveRowNo = index + 1;
                // 在庫移動詳細行番号
                //_stockMoveDataTable[index].StockMoveExpNum = detailIndex + 1;
                // メーカーコード
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                //_stockMoveDataTable[index].MakerCode = stockSearchRet.MakerCode;
                _stockMoveDataTable[index].GoodsMakerCd = stockSearchRet.GoodsMakerCd;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                // メーカー名称
                _stockMoveDataTable[index].MakerName = stockSearchRet.MakerName;
                // 商品コード
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                //_stockMoveDataTable[index].GoodsCode = stockSearchRet.GoodsCode;
                _stockMoveDataTable[index].GoodsNo = stockSearchRet.GoodsNo;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                // 商品名称
                _stockMoveDataTable[index].GoodsName = stockSearchRet.GoodsName;
                // 更新拠点コード
                _stockMoveDataTable[index].UpdateSecCd = LoginInfoAcquisition.Employee.BelongSectionCode;
                // 出庫拠点コード
                _stockMoveDataTable[index].BfSectionCode = stockSearchRet.SectionCode;
                // 出庫拠点ガイド名称
                _stockMoveDataTable[index].BfSectionGuideNm = _stockMoveInputInitAcs.GetSectionName(stockSearchRet.SectionCode);
                // 出庫倉庫コード
                _stockMoveDataTable[index].BfEnterWarehCode = _stockMoveHeader.BfEnterWarehCode;
                // 出庫倉庫名称
                _stockMoveDataTable[index].BfEnterWarehName = _stockMoveHeader.BfEnterWarehName;
                // 入庫拠点コード
                _stockMoveDataTable[index].AfSectionCode = "";
                // 入庫拠点ガイド名称
                _stockMoveDataTable[index].AfSectionGuideNm = "";
                // 入庫倉庫コード
                _stockMoveDataTable[index].AfEnterWarehCode = "";
                // 入庫倉庫名称
                _stockMoveDataTable[index].AfEnterWarehName = "";
                // 出荷予定日
                _stockMoveDataTable[index].ShipmentScdlDay = "";
                // 出荷確定日
                _stockMoveDataTable[index].ShipmentFixDay = "";
                // 入荷日
                _stockMoveDataTable[index].ArrivalGoodsDay = "";

                // 移動状態
                // 在庫全体設定マスタ(在庫移動確定区分)によって振り分け(1:出荷確定有り 2:出荷確定無し)
                _stockMoveDataTable[index].MoveStatus = 1;
                //_stockMoveDataTable[index].MoveStatus = 2;

                // 在庫移動入力従業員コード
                _stockMoveDataTable[index].StockMvEmpCode = "";
                // 在庫移動入力従業員名称
                _stockMoveDataTable[index].StockMvEmpName = "";
                // 出荷担当従業員コード
                _stockMoveDataTable[index].ShipAgentCd = "";
                // 出荷担当従業員名称
                _stockMoveDataTable[index].ShipAgentNm = "";

                // 在庫全体設定マスタ(受託在庫拠点間移動区分・受託在庫倉庫間移動区分)によって振り分け(1:移動なし 2:移動あり)
                // 本来であればどちらか片方に数量1以上が入る。
                // 移動中仕入在庫数
                _stockMoveDataTable[index].MovingSupliStock = 0;
                // 移動中受託在庫数
                _stockMoveDataTable[index].MovingTrustStock = 0;

                // 引取担当従業員コード
                _stockMoveDataTable[index].ReceiveAgentCd = "";
                // 引取担当従業員名称
                _stockMoveDataTable[index].ReceiveAgentNm = "";
                // 伝票摘要
                _stockMoveDataTable[index].Outline = "";
                // 倉庫備考1
                _stockMoveDataTable[index].WarehouseNote1 = "";
                // 倉庫備考2
                _stockMoveDataTable[index].WarehouseNote2 = "";
                // 倉庫備考3
                _stockMoveDataTable[index].WarehouseNote3 = "";
                // 倉庫備考4
                _stockMoveDataTable[index].WarehouseNote4 = "";
                // 倉庫備考5
                _stockMoveDataTable[index].WarehouseNote5 = "";

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                //// 仕入在庫残数
                //// (仕入在庫数 － 仕入在庫委託数 － 移動中仕入在庫数 － 引当在庫数)
                //double SlipShipmentStock = stockSearchRet.SupplierStock - stockSearchRet.EntrustCnt - stockSearchRet.MovingSupliStock - stockSearchRet.AllowStockCnt;

                // 仕入在庫残数
                // (仕入在庫数 － 仕入在庫委託数 － 移動中仕入在庫数)
                double SlipShipmentStock = stockSearchRet.SupplierStock - stockSearchRet.EntrustCnt - stockSearchRet.MovingSupliStock;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                _stockMoveDataTable[index].SlipRemainCount = SlipShipmentStock;

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                //// 受託在庫残数
                //// (受託在庫数 － 受託在庫委託数 － 移動中受託在庫数 － 引当在庫数)
                //double TrustShipmentStock = stockSearchRet.TrustCount - stockSearchRet.TrustEntrustCnt - stockSearchRet.MovingTrustStock - stockSearchRet.AllowStockCnt;

                // 受託在庫残数
                // (受託在庫数 － 移動中受託在庫数 － 引当在庫数)
                double TrustShipmentStock = stockSearchRet.TrustCount - stockSearchRet.MovingTrustStock;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                _stockMoveDataTable[index].TrustRemainCount = TrustShipmentStock;

                // 移動金額
                _stockMoveDataTable[index].MovingPrice = 0;

                // 行ステータス
                _stockMoveDataTable[index].RowStatus = 0;

                // グロスフラグ
                _stockMoveDataTable[index].GrossFlag = true;

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki

                // TODO: ファイルレイアウト上に追加した項目のセット処理を追加
                //_stockMoveDataTable[index].xxx = xxx

                // 出庫後数
                _stockMoveDataTable[index].BfAfterMoveCount = _stockMoveDataTable[index].SlipRemainCount + _stockMoveDataTable[index].TrustRemainCount;
                // 出庫前数
                _stockMoveDataTable[index].BfBeforeMoveCount = _stockMoveDataTable[index].BfAfterMoveCount + 0;

                // ＢＬ商品コード
                _stockMoveDataTable[index].BLGoodsCode = stockSearchRet.BLGoodsCode;

                // ＢＬ商品コード名称
                _stockMoveDataTable[index].BLGoodsFullName = stockSearchRet.BLGoodsFullName;

                // ＢＬ商品コード枝番
                _stockMoveDataTable[index].BLGoodsCdDerivedNo = 0;

                // 定価
                string retString;
                _stockMoveDataTable[index].ListPriceFl = GetListPriceFl(stockSearchRet, _stockMoveDataTable[index], out retString);
                _stockMoveDataTable[index].ListPriceFlView = retString;

                // 仕入単価
                _stockMoveDataTable[index].StockUnitPriceFl = stockSearchRet.StockUnitPriceFl;

                // （出庫）倉庫コード
                _stockMoveDataTable[index].BfEnterWarehCode = stockSearchRet.WarehouseCode;

                // （出庫）倉庫名称
                _stockMoveDataTable[index].BfEnterWarehName = stockSearchRet.WarehouseName;

                // （出庫）倉庫棚番
                _stockMoveDataTable[index].BfShelfNo = stockSearchRet.WarehouseShelfNo;

                // （入庫）倉庫コード
                _stockMoveDataTable[index].AfEnterWarehCode = "";

                // （入庫）倉庫名称
                _stockMoveDataTable[index].AfEnterWarehName = "";

                // （入庫）倉庫棚番
                _stockMoveDataTable[index].AfShelfNo = "";
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

                // 行状態を変更
                this.SettingGridRow(index);

                // 最終行の場合は、１行追加する
                if (index == _stockMoveInputAcs.StockMoveDataTable.Rows.Count - 1)
                {
                    this._stockMoveInputAcs.AddStockDetailRow();
                }
                # endregion

                index++;
            }

            // データテーブル更新フラグ
            this.tableUpdateFlg = true;
        }

        /// <summary>
        /// 定価取得処理
        /// </summary>
        /// <param name="stock">在庫情報</param>
        /// <param name="stockMoveRow">在庫移動入力行</param>
        /// <param name="retString">文字列編集(オープン価格考慮)</param>
        /// <returns></returns>
        private Double GetListPriceFl(StockExpansion stock, StockMoveInputDataSet.StockMoveRow stockMoveRow, out string retString)
        {
            double retDouble = 0;
            retString = "";

            // オープン価格判定
            if (stock.OpenPriceDiv != 0)
            {
                retDouble = 0;
                retString = "オープン価格";
                return retDouble;
            }

            // 新価格判定

            //   DateTimeに変換
            string[] splitString;
            DateTime dtShipmentScdlDay = DateTime.MinValue;
            //   (出荷予定日)
            try
            {
                if (stockMoveRow.ShipmentScdlDay.Trim().Contains("/"))
                {
                    splitString = stockMoveRow.ShipmentScdlDay.Trim().Split('/');
                    dtShipmentScdlDay = new DateTime(Int32.Parse(splitString[0]), Int32.Parse(splitString[1]), Int32.Parse(splitString[2]));
                }
            }
            catch
            {
            }
            //   (出荷確定日)
            DateTime dtShipmentFixDay = DateTime.MinValue;
            try
            {
                if (stockMoveRow.ShipmentFixDay.Trim().Contains("/"))
                {
                    splitString = stockMoveRow.ShipmentFixDay.Trim().Split('/');
                    dtShipmentFixDay = new DateTime(Int32.Parse(splitString[0]), Int32.Parse(splitString[1]), Int32.Parse(splitString[2]));
                }
            }
            catch
            {
            }

            //   比較対象の日付を取得
            DateTime cmpDateTime = dtShipmentScdlDay;   // 出荷予定日

            if (dtShipmentFixDay > cmpDateTime)
            {
                cmpDateTime = dtShipmentFixDay;         // 出荷確定日
            }

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            if (cmpDateTime == DateTime.MinValue)
            {
                cmpDateTime = _stockMoveHeader.ShipmentScdlDay;
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            //   新価格適用日と比較
            if (cmpDateTime < stock.NewPriceStartDate)
            {
                // 旧価格
                retDouble = stock.OldPrice;
                retString = retDouble.ToString("###,###,###,##0");
            }
            else
            {
                // 新価格
                retDouble = stock.NewPrice;
                retString = retDouble.ToString("###,###,###,##0");
            }

            return retDouble;
        }

        /// <summary>
        /// 在庫移動テーブル格納処理(在庫検索・在庫情報から)
        /// </summary>
        private void StockMoveDataTableFromStockSearchRet(List<StockExpansion> stockSearchRetList, UltraGridCell activeCell)
        {
            # region [入力チェック]

            // 同一商品レコードチェック
            if (CheckSameGoods(stockSearchRetList) == true)
            {
                // 同一商品コードが読み込まれた場合エラーとする
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "同一商品のレコードが存在するため読み込めません。",
                    -1,
                    MessageBoxButtons.OK);

                _errGoodsNo = true;
                return;
            }
            # endregion

            StockMove stockMove = new StockMove();

            // アクティブセルがない場合
            if (activeCell == null)
            {
                activeCell = ultraGrid1.Rows[0].Cells[1];
            }

            int index = activeCell.Row.Index;

            // 在庫ガイド結果を在庫移動テーブルに格納
            foreach (StockExpansion stockSearchRet in stockSearchRetList)
            {
                # region [入庫在庫有無判定]
                if (_stockMoveHeader.AfSectionCode == _stockMoveHeader.BfSectionCode)
                {
                    // 入庫在庫有無判定（同一拠点内）
                    if (CheckArrivalSideExistsOnSection(stockSearchRet) == false)
                    {
                        TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_INFO,
                            this.Name,
                            "入庫に在庫が存在しない為、入力出来ません。\r\n" + stockSearchRet.MakerName + " " + stockSearchRet.GoodsNo,
                            -1,
                            MessageBoxButtons.OK);

                        continue;
                    }
                }
                else
                {
                    // 入庫在庫有無判定（他拠点間）
                    if (CheckArrivalSideExists(stockSearchRet) == false)
                    {
                        TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_INFO,
                            this.Name,
                            "入庫が在庫管理しない設定の為、入力出来ません。\r\n" + stockSearchRet.MakerName + " " + stockSearchRet.GoodsNo,
                            -1,
                            MessageBoxButtons.OK);

                        continue;
                    }
                }
                # endregion

                # region [行セット処理]
                // 新規読込時はヘッダ情報は企業コードのみ格納する。
                // 企業コード
                _stockMoveDataTable[index].EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;

                // 在庫移動形式(1:在庫移動 2:倉庫移動)
                if (_stockMoveHeader.AfSectionCode != "")
                {
                    // 入庫拠点の指定があった場合は在庫移動
                    _stockMoveDataTable[index].StockMoveFormal = 1;
                }
                else
                {
                    // それ以外は倉庫移動
                    _stockMoveDataTable[index].StockMoveFormal = 2;
                }
                // 在庫移動伝票番号
                if (_stockMoveInputInitAcs.RegistMode == 0)
                {
                    _stockMoveDataTable[index].StockMoveSlipNo = 0;
                }
                else if (_stockMoveInputInitAcs.RegistMode == 1)
                {
                    // 今のところ一番先頭のレコードから伝票番号をとる
                    _stockMoveDataTable[index].StockMoveSlipNo = _stockMoveDataTable[0].StockMoveSlipNo;
                }
                // 在庫移動行番号
                _stockMoveDataTable[index].StockMoveRowNo = index + 1;
                // 在庫移動詳細行番号
                //_stockMoveDataTable[index].StockMoveExpNum = detailIndex + 1;
                // メーカーコード
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                //_stockMoveDataTable[index].MakerCode = stockSearchRet.MakerCode;
                _stockMoveDataTable[index].GoodsMakerCd = stockSearchRet.GoodsMakerCd;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                // メーカー名称
                _stockMoveDataTable[index].MakerName = stockSearchRet.MakerName;
                // 商品コード
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                //_stockMoveDataTable[index].GoodsCode = stockSearchRet.GoodsCode;
                _stockMoveDataTable[index].GoodsNo = stockSearchRet.GoodsNo;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                // 商品名称
                _stockMoveDataTable[index].GoodsName = stockSearchRet.GoodsName;
                // 更新拠点コード
                _stockMoveDataTable[index].UpdateSecCd = LoginInfoAcquisition.Employee.BelongSectionCode;
                // 出庫拠点コード
                _stockMoveDataTable[index].BfSectionCode = stockSearchRet.SectionCode;
                // 出庫拠点ガイド名称
                _stockMoveDataTable[index].BfSectionGuideNm = _stockMoveInputInitAcs.GetSectionName(stockSearchRet.SectionCode);
                // 出庫倉庫コード
                _stockMoveDataTable[index].BfEnterWarehCode = _stockMoveHeader.BfEnterWarehCode;
                // 出庫倉庫名称
                _stockMoveDataTable[index].BfEnterWarehName = _stockMoveHeader.BfEnterWarehName;
                // 入庫拠点コード
                _stockMoveDataTable[index].AfSectionCode = "";
                // 入庫拠点ガイド名称
                _stockMoveDataTable[index].AfSectionGuideNm = "";
                // 入庫倉庫コード
                _stockMoveDataTable[index].AfEnterWarehCode = "";
                // 入庫倉庫名称
                _stockMoveDataTable[index].AfEnterWarehName = "";
                // 出荷予定日
                _stockMoveDataTable[index].ShipmentScdlDay = "";
                // 出荷確定日
                _stockMoveDataTable[index].ShipmentFixDay = "";
                // 入荷日
                _stockMoveDataTable[index].ArrivalGoodsDay = "";

                // 移動状態
                // 在庫全体設定マスタ(在庫移動確定区分)によって振り分け(1:出荷確定有り 2:出荷確定無し)
                _stockMoveDataTable[index].MoveStatus = 1;
                //_stockMoveDataTable[index].MoveStatus = 2;

                // 在庫移動入力従業員コード
                _stockMoveDataTable[index].StockMvEmpCode = "";
                // 在庫移動入力従業員名称
                _stockMoveDataTable[index].StockMvEmpName = "";
                // 出荷担当従業員コード
                _stockMoveDataTable[index].ShipAgentCd = "";
                // 出荷担当従業員名称
                _stockMoveDataTable[index].ShipAgentNm = "";

                // 在庫全体設定マスタ(受託在庫拠点間移動区分・受託在庫倉庫間移動区分)によって振り分け(1:移動なし 2:移動あり)
                // 本来であればどちらか片方に数量1以上が入る。
                // 移動中仕入在庫数
                _stockMoveDataTable[index].MovingSupliStock = 0;
                // 移動中受託在庫数
                _stockMoveDataTable[index].MovingTrustStock = 0;

                // 引取担当従業員コード
                _stockMoveDataTable[index].ReceiveAgentCd = "";
                // 引取担当従業員名称
                _stockMoveDataTable[index].ReceiveAgentNm = "";
                // 伝票摘要
                _stockMoveDataTable[index].Outline = "";
                // 倉庫備考1
                _stockMoveDataTable[index].WarehouseNote1 = "";
                // 倉庫備考2
                _stockMoveDataTable[index].WarehouseNote2 = "";
                // 倉庫備考3
                _stockMoveDataTable[index].WarehouseNote3 = "";
                // 倉庫備考4
                _stockMoveDataTable[index].WarehouseNote4 = "";
                // 倉庫備考5
                _stockMoveDataTable[index].WarehouseNote5 = "";

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                //// 仕入在庫残数
                //// (仕入在庫数 － 仕入在庫委託数 － 移動中仕入在庫数 － 引当在庫数)
                //double SlipShipmentStock = stockSearchRet.SupplierStock - stockSearchRet.EntrustCnt - stockSearchRet.MovingSupliStock - stockSearchRet.AllowStockCnt;

                // 仕入在庫残数
                // (仕入在庫数 － 仕入在庫委託数 － 移動中仕入在庫数)
                double SlipShipmentStock = stockSearchRet.SupplierStock - stockSearchRet.EntrustCnt - stockSearchRet.MovingSupliStock;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                _stockMoveDataTable[index].SlipRemainCount = SlipShipmentStock;

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                //// 受託在庫残数
                //// (受託在庫数 － 受託在庫委託数 － 移動中受託在庫数 － 引当在庫数)
                //double TrustShipmentStock = stockSearchRet.TrustCount - stockSearchRet.TrustEntrustCnt - stockSearchRet.MovingTrustStock - stockSearchRet.AllowStockCnt;

                // 受託在庫残数
                // (受託在庫数 － 移動中受託在庫数 － 引当在庫数)
                double TrustShipmentStock = stockSearchRet.TrustCount - stockSearchRet.MovingTrustStock;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                _stockMoveDataTable[index].TrustRemainCount = TrustShipmentStock;

                // 移動金額
                _stockMoveDataTable[index].MovingPrice = 0;

                // 行ステータス
                _stockMoveDataTable[index].RowStatus = 0;

                // グロスフラグ
                _stockMoveDataTable[index].GrossFlag = true;

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki

                // TODO: ファイルレイアウト上に追加した項目のセット処理を追加
                //_stockMoveDataTable[index].xxx = xxx

                // 出庫後数
                _stockMoveDataTable[index].BfAfterMoveCount = _stockMoveDataTable[index].SlipRemainCount + _stockMoveDataTable[index].TrustRemainCount;
                // 出庫前数
                _stockMoveDataTable[index].BfBeforeMoveCount = _stockMoveDataTable[index].BfAfterMoveCount + 0;

                // ＢＬ商品コード
                _stockMoveDataTable[index].BLGoodsCode = stockSearchRet.BLGoodsCode;

                // ＢＬ商品コード名称
                _stockMoveDataTable[index].BLGoodsFullName = stockSearchRet.BLGoodsFullName;

                // ＢＬ商品コード枝番
                _stockMoveDataTable[index].BLGoodsCdDerivedNo = 0;

                // 定価
                string retString;
                _stockMoveDataTable[index].ListPriceFl = GetListPriceFl(stockSearchRet, _stockMoveDataTable[index], out retString);
                _stockMoveDataTable[index].ListPriceFlView = retString;

                // 仕入単価
                _stockMoveDataTable[index].StockUnitPriceFl = stockSearchRet.StockUnitPriceFl;

                // （出庫）倉庫コード
                _stockMoveDataTable[index].BfEnterWarehCode = stockSearchRet.WarehouseCode;

                // （出庫）倉庫名称
                _stockMoveDataTable[index].BfEnterWarehName = stockSearchRet.WarehouseName;

                // （出庫）倉庫棚番
                _stockMoveDataTable[index].BfShelfNo = stockSearchRet.WarehouseShelfNo;

                // （入庫）倉庫コード
                _stockMoveDataTable[index].AfEnterWarehCode = "";

                // （入庫）倉庫名称
                _stockMoveDataTable[index].AfEnterWarehName = "";

                // （入庫）倉庫棚番
                _stockMoveDataTable[index].AfShelfNo = "";
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

                // 行状態を変更
                this.SettingGridRow(index);

                // 最終行の場合は、１行追加する
                if (index == _stockMoveInputAcs.StockMoveDataTable.Rows.Count - 1)
                {
                    this._stockMoveInputAcs.AddStockDetailRow();
                }
                # endregion

                index++;
            }

            // データテーブル更新フラグ
            this.tableUpdateFlg = true;
        }

        /// <summary>
        /// 入庫在庫管理チェック（拠点違い）
        /// </summary>
        /// <param name="stockSearchRet"></param>
        /// <returns>true:(入庫)在庫管理する／false:(入庫)在庫管理しない</returns>
        /// <remaks>
        /// <br>商品情報読み込みにより付随する在庫管理区分を取得して判定します</br>
        /// </remaks>
        private bool CheckArrivalSideExists(StockExpansion stockSearchRet)
        {
            // 商品情報読み込み
            GoodsUnitData goodsUnitData;
            int status = _stockMoveInputAcs.ReadGoods(out goodsUnitData, _stockMoveHeader.AfSectionCode, stockSearchRet.GoodsMakerCd, stockSearchRet.GoodsNo);

            if (status == 0)
            {
                // 1:管理する／0:管理しない
                return (goodsUnitData.StockMngExistCd == 1);
            }

            // 商品読み込み失敗した場合は「0:管理しない」扱い
            return false;
        }

        /// <summary>
        /// 入庫在庫管理チェック（同一拠点内）
        /// </summary>
        /// <param name="stockSearchRet"></param>
        /// <returns>true:(入庫)在庫あり／false:(入庫)在庫なし</returns>
        /// <remarks>
        /// <br>在庫情報を参照し、実レコード有無で判定します。</br>
        /// </remarks>
        private bool CheckArrivalSideExistsOnSection(StockExpansion stockSearchRet)
        {

            StockExpansion stockExpansion;
            int status = _stockMoveInputAcs.ReadStock(out stockExpansion, _stockMoveHeader.AfSectionCode, _stockMoveHeader.AfEnterWarehCode, stockSearchRet.GoodsMakerCd, stockSearchRet.GoodsNo);

            // 読み込み成功でも返却がnullなら「在庫なし」
            if (status == 0)
            {
                return (stockExpansion != null);
            }

            // 在庫読み込み失敗した場合は「在庫なし」扱い
            return false;
        }

        /// <summary>
        /// 同一商品チェック処理
        /// </summary>
        /// <param name="stockSearchRetList"></param>
        /// <returns>true:同一商品あり／false:同一商品なし</returns>
        private bool CheckSameGoods(List<StockExpansion> stockSearchRetList)
        {
            foreach (StockMoveInputDataSet.StockMoveRow row in _stockMoveDataTable)
            {
                string goodsNo = row.GoodsNo;
                int makerCode = row.GoodsMakerCd;

                for (int i = 0; i < stockSearchRetList.Count; i++)
                {
                    StockExpansion stockSearchRet = stockSearchRetList[i];

                    if (goodsNo == stockSearchRet.GoodsNo && makerCode == stockSearchRet.GoodsMakerCd)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
           --- DEL 2008/07/14 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/14 Partsman用に変更

        #region DEL
        ///// <summary>
        ///// グリッド内色変更処理
        ///// </summary>
        ///// <param name="rowIndex">変更するグリッドの列番号</param>
        ///// 
        //private void ChangeColor(int rowIndex)
        //{
        //    SettingGridRow(rowIndex);
        //}
        #endregion DEL

        #region DEL 2008/07/14 Partsman用に変更
        /* --- DEL 2008/07/14 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 在庫移動データレコードクリア
        /// </summary>
        /// <param name="index"></param>
        private void StockMoveDetailRowClear(int index)
        {
            // レコードをクリア
            _stockMoveDataTable[index].CreateDateTime = new DateTime();
            _stockMoveDataTable[index].UpdateDateTime = new DateTime();
            _stockMoveDataTable[index].EnterpriseCode = "";
            _stockMoveDataTable[index].FileHeaderGuid = new Guid();
            _stockMoveDataTable[index].UpdEmployeeCode = "";
            _stockMoveDataTable[index].UpdAssemblyId1 = "";
            _stockMoveDataTable[index].UpdAssemblyId2 = "";
            _stockMoveDataTable[index].LogicalDeleteCode = 0;
            _stockMoveDataTable[index].StockMoveFormal = 0;
            _stockMoveDataTable[index].StockMoveSlipNo = 0;
            _stockMoveDataTable[index].StockMoveRowNo = 0;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //_stockMoveDataTable[index].MakerCode = 0;
            _stockMoveDataTable[index].GoodsMakerCd = 0;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            _stockMoveDataTable[index].MakerName = "";
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //_stockMoveDataTable[index].GoodsCode = "";
            _stockMoveDataTable[index].GoodsNo = "";
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            _stockMoveDataTable[index].GoodsName = "";
            _stockMoveDataTable[index].UpdateSecCd = "";
            _stockMoveDataTable[index].BfSectionCode = "";
            _stockMoveDataTable[index].BfSectionGuideNm = "";
            _stockMoveDataTable[index].BfEnterWarehCode = "";
            _stockMoveDataTable[index].BfEnterWarehName = "";
            _stockMoveDataTable[index].AfSectionCode = "";
            _stockMoveDataTable[index].AfSectionGuideNm = "";
            _stockMoveDataTable[index].AfEnterWarehCode = "";
            _stockMoveDataTable[index].AfEnterWarehName = "";
            _stockMoveDataTable[index].ShipmentScdlDay = "";
            _stockMoveDataTable[index].ShipmentFixDay = "";
            _stockMoveDataTable[index].ArrivalGoodsDay = "";
            _stockMoveDataTable[index].MoveStatus = 0;
            _stockMoveDataTable[index].StockMvEmpCode = "";
            _stockMoveDataTable[index].StockMvEmpName = "";
            _stockMoveDataTable[index].ShipAgentCd = "";
            _stockMoveDataTable[index].ShipAgentNm = "";
            _stockMoveDataTable[index].MovingSupliStock = 0;
            _stockMoveDataTable[index].MovingTrustStock = 0;
            _stockMoveDataTable[index].ReceiveAgentCd = "";
            _stockMoveDataTable[index].ReceiveAgentNm = "";
            _stockMoveDataTable[index].Outline = "";
            _stockMoveDataTable[index].WarehouseNote1 = "";
            _stockMoveDataTable[index].WarehouseNote2 = "";
            _stockMoveDataTable[index].WarehouseNote3 = "";
            _stockMoveDataTable[index].WarehouseNote4 = "";
            _stockMoveDataTable[index].WarehouseNote5 = "";
            _stockMoveDataTable[index].RowStatus = 0;
            _stockMoveDataTable[index].GoodsGuideButton = null;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //_stockMoveDataTable[index].ProductNumber = "";
            //_stockMoveDataTable[index].ProductStockGuid = new Guid();
            //_stockMoveDataTable[index].StockTelNo1 = "";
            //_stockMoveDataTable[index].StockTelNo2 = "";
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            _stockMoveDataTable[index].SlipRemainCount = 0;
            _stockMoveDataTable[index].TrustRemainCount = 0;
            _stockMoveDataTable[index].StockUnitPriceFl = 0;
            _stockMoveDataTable[index].MovingPrice = 0;
            _stockMoveDataTable[index].FixFlag = false;
            _stockMoveDataTable[index].ArrivalFlag = false;
            _stockMoveDataTable[index].SearchIndexNumber = 0;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            _stockMoveDataTable[index].BfAfterMoveCount = 0;
            _stockMoveDataTable[index].BfBeforeMoveCount = 0;
            _stockMoveDataTable[index].BLGoodsCode = 0;
            _stockMoveDataTable[index].BLGoodsCdDerivedNo = 0;
            _stockMoveDataTable[index].BLGoodsFullName = "";
            _stockMoveDataTable[index].BfSectionCode = "";
            _stockMoveDataTable[index].BfSectionGuideNm = "";
            _stockMoveDataTable[index].BfEnterWarehCode = "";
            _stockMoveDataTable[index].BfEnterWarehName = "";
            _stockMoveDataTable[index].BfShelfNo = "";
            _stockMoveDataTable[index].AfSectionCode = "";
            _stockMoveDataTable[index].AfSectionGuideNm = "";
            _stockMoveDataTable[index].AfEnterWarehCode = "";
            _stockMoveDataTable[index].AfEnterWarehName = "";
            _stockMoveDataTable[index].AfShelfNo = "";
            _stockMoveDataTable[index].ListPriceFl = 0;
            _stockMoveDataTable[index].ListPriceFlView = "";
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
        }
           --- DEL 2008/07/14 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/14 Partsman用に変更

        #endregion

        # region パブリックメソッド
        // --- ADD 2008/07/14 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// ReturnKey押下処理(グリッド内)
        /// </summary>
        /// <param name="e">イベントハンドラ</param>
        /// <br>Update Note : 2010/11/15 曹文傑 障害改良対応「５，６，７」の対応</br>
        /// <br>Update Note : 2010/11/25 tianjw 障害報告 #17589</br>
        /// <br>Update Note : 2011/04/11 鄧潘ハン 明細に仕入先を追加する</br>
        public void ReturnKeyDown(ref ChangeFocusEventArgs e)
        {
            if ((this.ultraGrid1.ActiveCell == null) && (this.ultraGrid1.ActiveRow == null))
            {
                this.ultraGrid1.Rows[0].Cells[_stockMoveDataTable.GoodsNoColumn.ColumnName].Activate();
            }

            string columnKey;
            int rowIndex;

            if (this.ultraGrid1.ActiveCell != null)
            {
                columnKey = this.ultraGrid1.ActiveCell.Column.Key;
                rowIndex = this.ultraGrid1.ActiveCell.Row.Index;
            }
            else
            {
                columnKey = _stockMoveDataTable.GoodsNoColumn.ColumnName;
                rowIndex = this.ultraGrid1.ActiveRow.Index;
            }
            // --- ADD 2014/04/21 T.Miyamoto ------------------------------>>>>>
            // 行選択時
            if (this.ultraGrid1.ActiveRow.Selected)
            {
                e.NextCtrl = e.PrevCtrl;
                return;
            }
            // --- ADD 2014/04/21 T.Miyamoto ------------------------------<<<<<

            e.NextCtrl = null;

            // ヘッダを格納
            SetStockMoveHeader();

            this.ultraGrid1.PerformAction(UltraGridAction.ExitEditMode);

            switch (columnKey)
            {
                case "GoodsNo":
                    {
                        if (this._logicalDeleteFlg == true)
                        {
                            // 品番にフォーカス
                            this.ultraGrid1.Rows[rowIndex].Cells[_stockMoveDataTable.GoodsNoColumn.ColumnName].Activate();
                            this.ultraGrid1.PerformAction(UltraGridAction.EnterEditMode);

                            this._logicalDeleteFlg = false;
                        }
                        else
                        {
                            // 品番取得
                            string goodsNo = ChangeCellValueToString(this.ultraGrid1.ActiveCell.Value);

                            if (goodsNo == "")
                            {
                                if (this._warehouseFocusFlg)
                                {
                                    // 出庫倉庫コードにフォーカス
                                    setFocus(this._warehouseName);
                                    this._warehouseFocusFlg = false;
                                }
                                //--ADD 2011/05/10--------------------->>>>>>
                                else if (this._sameGoodNoFlg)
                                {
                                    this.ultraGrid1.Rows[rowIndex].Cells[columnKey].Activate();
                                    this.ultraGrid1.PerformAction(UltraGridAction.EnterEditMode);
                                    this._sameGoodNoFlg = false;

                                }
                                //--ADD 2011/05/10---------------------<<<<<<
                                else
                                {
                                    this.ultraGrid1.PerformAction(UltraGridAction.NextCellByTab);
                                }
                            }
                            else
                            {
                                // 品名取得
                                string goodsName = ChangeCellValueToString(this.ultraGrid1.Rows[rowIndex].Cells[_stockMoveDataTable.GoodsNameColumn.ColumnName].Value);
                                if (goodsName == "")
                                {
                                    if (this._warehouseFocusFlg)
                                    {
                                        // 出庫倉庫コードにフォーカス
                                        setFocus(this._warehouseName);
                                        this._warehouseFocusFlg = false;
                                    }
                                    else
                                    {
                                        // 品名にフォーカス
                                        this.ultraGrid1.Rows[rowIndex].Cells[_stockMoveDataTable.GoodsNameColumn.ColumnName].Activate();
                                        this.ultraGrid1.PerformAction(UltraGridAction.EnterEditMode);
                                    }
                                }
                                else
                                {
                                    // 出荷数にフォーカス
                                    this.ultraGrid1.Rows[rowIndex].Cells[_stockMoveDataTable.MovingSupliStockColumn.ColumnName].Activate();
                                    this.ultraGrid1.PerformAction(UltraGridAction.EnterEditMode);
                                }
                            }
                        }
                        return;
                    }
                case "GoodsMakerCd":
                    {
                        if (this._logicalDeleteFlg == true)
                        {
                            // 品番にフォーカス
                            this.ultraGrid1.Rows[rowIndex].Cells[_stockMoveDataTable.GoodsNoColumn.ColumnName].Activate();
                            this.ultraGrid1.PerformAction(UltraGridAction.EnterEditMode);

                            this._logicalDeleteFlg = false;
                        }
                        else
                        {
                            // メーカーコード
                            int makerCode = ChangeCellValueToInt(this.ultraGrid1.ActiveCell.Value);
                            if (makerCode == 0)
                            {
                                // -------- UPD 2010/11/25 ------------------------------------>>>>>
                                //// メーカーガイドボタンにフォーカス
                                //this.ultraGrid1.Rows[rowIndex].Cells[_stockMoveDataTable.MakerGuideButtonColumn.ColumnName].Activate();
                                //this.ultraGrid1.PerformAction(UltraGridAction.EnterEditMode);

                                // 次のセルにフォーカス
                                this.ultraGrid1.PerformAction(UltraGridAction.NextCellByTab);
                                // -------- UPD 2010/11/25 ------------------------------------<<<<<
                            }
                            else
                            {
                                // -------- UPD 2010/11/25 ------------------------------------>>>>>
                                // BLコードにフォーカス
                                //this.ultraGrid1.Rows[rowIndex].Cells[_stockMoveDataTable.BLGoodsCodeColumn.ColumnName].Activate();
                                //this.ultraGrid1.PerformAction(UltraGridAction.EnterEditMode);
                                if (!this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveDataTable.BLGoodsCodeColumn.ColumnName].Hidden)
                                {
                                    // BLコードにフォーカス
                                    this.ultraGrid1.Rows[rowIndex].Cells[_stockMoveDataTable.BLGoodsCodeColumn.ColumnName].Activate();
                                    this.ultraGrid1.PerformAction(UltraGridAction.EnterEditMode);
                                }
                                // -------- ADD 2011/04/11 ------------------------------------>>>>>
                                else if (!this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveDataTable.SupplierCdColumn.ColumnName].Hidden)
                                {
                                    // 仕入先にフォーカス
                                    this.ultraGrid1.Rows[rowIndex].Cells[_stockMoveDataTable.SupplierCdColumn.ColumnName].Activate();
                                    this.ultraGrid1.PerformAction(UltraGridAction.EnterEditMode);
                                }
                                // -------- ADD 2011/04/11 ------------------------------------<<<<<
                                else
                                {
                                    // 出荷数にフォーカス
                                    this.ultraGrid1.Rows[rowIndex].Cells[_stockMoveDataTable.MovingSupliStockColumn.ColumnName].Activate();
                                    this.ultraGrid1.PerformAction(UltraGridAction.EnterEditMode);
                                }
                                // -------- UPD 2010/11/25 ------------------------------------>>>>>
                            }
                        }
                        return;
                    }
                case "BLGoodsCode":
                    {
                        // BLコード
                        int bLGoodsCode = ChangeCellValueToInt(this.ultraGrid1.ActiveCell.Value);
                        if (bLGoodsCode == 0)
                        {
                            // -------- UPD 2010/11/25 ------------------------------------>>>>>
                            //// BLガイドボタンにフォーカス
                            //this.ultraGrid1.Rows[rowIndex].Cells[_stockMoveDataTable.BLCodeGuideButtonColumn.ColumnName].Activate();
                            //this.ultraGrid1.PerformAction(UltraGridAction.EnterEditMode);

                            // 次のセルにフォーカス
                            this.ultraGrid1.PerformAction(UltraGridAction.NextCellByTab);
                            // -------- UPD 2010/11/25 ------------------------------------<<<<<
                        }
                        else
                        {
                            // -------- DEL 2011/04/11 ------------------------------------>>>>>
                            //// 出荷数にフォーカス
                            //this.ultraGrid1.Rows[rowIndex].Cells[_stockMoveDataTable.MovingSupliStockColumn.ColumnName].Activate();
                            //this.ultraGrid1.PerformAction(UltraGridAction.EnterEditMode);
                            // -------- DEL 2011/04/11 ------------------------------------<<<<<
                            // -------- ADD 2011/04/11 ------------------------------------>>>>>
                            if (!this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveDataTable.SupplierCdColumn.ColumnName].Hidden)
                            {

                                // 仕入先にフォーカス
                                this.ultraGrid1.Rows[rowIndex].Cells[_stockMoveDataTable.SupplierCdColumn.ColumnName].Activate();
                                this.ultraGrid1.PerformAction(UltraGridAction.EnterEditMode);
                                
                            }
                            else 
                            {
                                // 出荷数にフォーカス
                                this.ultraGrid1.Rows[rowIndex].Cells[_stockMoveDataTable.MovingSupliStockColumn.ColumnName].Activate();
                                this.ultraGrid1.PerformAction(UltraGridAction.EnterEditMode);
                            }
                            // -------- ADD 2011/04/11 ------------------------------------<<<<<

                        }
                        return;
                    }
                // -------- ADD 2011/04/11 ------------------------------------>>>>>
                case "SupplierCd":
                    {
                        // BLコード
                        int SupplierCd = ChangeCellValueToInt(this.ultraGrid1.ActiveCell.Value);
                        if (SupplierCd == 0)
                        {
                            this.ultraGrid1.PerformAction(UltraGridAction.NextCellByTab);
                        }
                        else
                        {
                             // 出荷数にフォーカス
                             this.ultraGrid1.Rows[rowIndex].Cells[_stockMoveDataTable.MovingSupliStockColumn.ColumnName].Activate();
                             this.ultraGrid1.PerformAction(UltraGridAction.EnterEditMode);
                        }
                        return;
                    }
                // -------- ADD 2011/04/11 ------------------------------------<<<<<
                case "MovingSupliStock":
                    {
                        if (this._movingSupliStockFlg)
                        {
                            // 出荷数にフォーカス
                            this.ultraGrid1.Rows[rowIndex].Cells[_stockMoveDataTable.MovingSupliStockColumn.ColumnName].Activate();
                            this.ultraGrid1.PerformAction(UltraGridAction.EnterEditMode);

                            this._movingSupliStockFlg = false;
                        }
                        else
                        {
                            // ---UPD 2010/11/15---------------->>>>>
                            // 原単価にフォーカス
                            //this.ultraGrid1.Rows[rowIndex].Cells[_stockMoveDataTable.StockUnitPriceFlColumn.ColumnName].Activate();
                            //this.ultraGrid1.PerformAction(UltraGridAction.EnterEditMode);

                            // 次のセルにフォーカス
                            this.ultraGrid1.PerformAction(UltraGridAction.NextCellByTab);
                            // ---UPD 2010/11/15----------------<<<<<
                        }

                        //// 原単価にフォーカス
                        //this.ultraGrid1.Rows[rowIndex].Cells[_stockMoveDataTable.StockUnitPriceFlColumn.ColumnName].Activate();
                        //this.ultraGrid1.PerformAction(UltraGridAction.EnterEditMode);

                        break;
                    }
                case "ListPriceFlView":
                    {
                        if (rowIndex == this.ultraGrid1.Rows.Count - 1)
                        {
                            // 備考にフォーカス
                            setFocus("Outline_tEdit");
                        }
                        else
                        {
                            // 次のセルにフォーカス
                            this.ultraGrid1.PerformAction(UltraGridAction.NextCellByTab);
                        }
                        return;
                    }
                default:
                    {
                        // 次のセルにフォーカス
                        this.ultraGrid1.PerformAction(UltraGridAction.NextCellByTab);
                        return;
                    }
            }
        }

        /// <summary>
        /// ShiftKey押下処理(グリッド内)
        /// </summary>
        /// <param name="e">イベントハンドラ</param>
        /// <br>Update Note : 2010/11/25 tianjw 障害報告 #17589</br>
        /// <br>Update Note : 2011/04/11 鄧潘ハン 明細に仕入先を追加する</br>
        public void ShiftKeyDown(ref ChangeFocusEventArgs e)
        {
            if ((this.ultraGrid1.ActiveCell == null) && (this.ultraGrid1.ActiveRow == null))
            {
                this.ultraGrid1.Rows[0].Cells[_stockMoveDataTable.GoodsNoColumn.ColumnName].Activate();
            }

            // --- ADD 2014/04/21 T.Miyamoto ------------------------------>>>>>
            // 行選択時
            if (this.ultraGrid1.ActiveRow.Selected)
            {
                e.NextCtrl = e.PrevCtrl;
                return;
            }
            // --- ADD 2014/04/21 T.Miyamoto ------------------------------<<<<<
            string columnKey = this.ultraGrid1.ActiveCell.Column.Key;
            int rowIndex = this.ultraGrid1.ActiveCell.Row.Index;

            e.NextCtrl = null;

            // ヘッダを格納
            SetStockMoveHeader();

            this.ultraGrid1.PerformAction(UltraGridAction.ExitEditMode);

            switch (columnKey)
            {
                case "GoodsNo":
                    {
                        if (this._logicalDeleteFlg == true)
                        {
                            // 品番にフォーカス
                            this.ultraGrid1.Rows[rowIndex].Cells[_stockMoveDataTable.GoodsNoColumn.ColumnName].Activate();
                            this.ultraGrid1.PerformAction(UltraGridAction.EnterEditMode);

                            this._logicalDeleteFlg = false;
                        }
                        else
                        {
                            // 品名取得
                            string goodsName = ChangeCellValueToString(this.ultraGrid1.Rows[rowIndex].Cells[_stockMoveDataTable.GoodsNameColumn.ColumnName].Value);
                            if (goodsName == "")
                            {
                                if (this._warehouseFocusFlg)
                                {
                                    // 出庫倉庫コードにフォーカス
                                    setFocus(this._warehouseName);
                                    this._warehouseFocusFlg = false;
                                }
                                else
                                {
                                    if (rowIndex == 0)
                                    {
                                        if (_stockMoveHeader.AfEnterWarehName.Trim() == "")
                                        {
                                            // 入庫倉庫ガイドにフォーカス
                                            setFocus("MoveOthWarehouseGuide_uButton");
                                        }
                                        else
                                        {
                                            // 入庫倉庫コードにフォーカス
                                            setFocus("AfEnterWarehCode_tEdit");
                                        }
                                    }
                                    else
                                    {
                                        //--ADD 2011/05/10--------------------->>>>>>
                                        if (this._sameGoodNoFlg)
                                        {
                                            this.ultraGrid1.Rows[rowIndex].Cells[columnKey].Activate();
                                            this.ultraGrid1.PerformAction(UltraGridAction.EnterEditMode);
                                            this._sameGoodNoFlg = false;
                                            return;
                                        }
                                        //--ADD 2011/05/10---------------------<<<<<<
                                        // 前のセルにフォーカス
                                        this.ultraGrid1.PerformAction(UltraGridAction.PrevCellByTab);
                                    }
                                }
                            }
                            else
                            {
                                if (rowIndex == 0)
                                {
                                    if (_stockMoveHeader.AfEnterWarehName.Trim() == "")
                                    {
                                        // 入庫倉庫ガイドにフォーカス
                                        setFocus("MoveOthWarehouseGuide_uButton");
                                    }
                                    else
                                    {
                                        // 入庫倉庫コードにフォーカス
                                        setFocus("AfEnterWarehCode_tEdit");
                                    }
                                }
                                else
                                {
                                    // 前のセルにフォーカス
                                    this.ultraGrid1.PerformAction(UltraGridAction.PrevCellByTab);
                                }
                            }
                        }
                        return;
                    }
                case "GoodsMakerCd":
                    {
                        if (this._logicalDeleteFlg == true)
                        {
                            // 品番にフォーカス
                            this.ultraGrid1.Rows[rowIndex].Cells[_stockMoveDataTable.GoodsNoColumn.ColumnName].Activate();
                            this.ultraGrid1.PerformAction(UltraGridAction.EnterEditMode);

                            this._logicalDeleteFlg = false;
                            return;
                        }

                        // 品名にフォーカス
                        this.ultraGrid1.Rows[rowIndex].Cells[_stockMoveDataTable.GoodsNameColumn.ColumnName].Activate();
                        this.ultraGrid1.PerformAction(UltraGridAction.EnterEditMode);
                        return;
                    }
                case "BLGoodsCode":
                    {
                        int makerCode = ChangeCellValueToInt(this.ultraGrid1.Rows[rowIndex].Cells[_stockMoveDataTable.GoodsMakerCdColumn.ColumnName].Value);
                        if (makerCode == 0)
                        {
                            // -------- UPD 2010/11/25 ------------------------------------>>>>>
                            // メーカーガイドにフォーカス
                            //this.ultraGrid1.Rows[rowIndex].Cells[_stockMoveDataTable.MakerGuideButtonColumn.ColumnName].Activate();
                            //this.ultraGrid1.PerformAction(UltraGridAction.EnterEditMode);

                            this.ultraGrid1.PerformAction(UltraGridAction.PrevCellByTab);
                            // -------- UPD 2010/11/25 ------------------------------------<<<<<
                        }
                        else
                        {
                            // メーカーコードにフォーカス
                            this.ultraGrid1.Rows[rowIndex].Cells[_stockMoveDataTable.GoodsMakerCdColumn.ColumnName].Activate();
                            this.ultraGrid1.PerformAction(UltraGridAction.EnterEditMode);
                        }
                        return;
                    }
                // -------- ADD 2011/04/11 ------------------------------------>>>>>
                case "SupplierCd":
                    {
                        int bLGoodsCode = ChangeCellValueToInt(this.ultraGrid1.Rows[rowIndex].Cells[_stockMoveDataTable.BLGoodsCodeColumn.ColumnName].Value);
                        if (bLGoodsCode == 0)
                        {
                            this.ultraGrid1.PerformAction(UltraGridAction.PrevCellByTab);
                        }
                        else if (!this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveDataTable.BLGoodsCodeColumn.ColumnName].Hidden)
                        {
                            // BLコードにフォーカス
                            this.ultraGrid1.Rows[rowIndex].Cells[_stockMoveDataTable.BLGoodsCodeColumn.ColumnName].Activate();

                            this.ultraGrid1.PerformAction(UltraGridAction.EnterEditMode);
                        }
                        else 
                        {
                            // メーカーコードにフォーカス
                            this.ultraGrid1.Rows[rowIndex].Cells[_stockMoveDataTable.GoodsMakerCdColumn.ColumnName].Activate();
                            this.ultraGrid1.PerformAction(UltraGridAction.EnterEditMode);
                        }
                        return;
                    }
                // -------- ADD 2011/04/11 ------------------------------------<<<<<
                case "MovingSupliStock":
                    {
                        if (this._movingSupliStockFlg)
                        {
                            // 出荷数にフォーカス
                            this.ultraGrid1.Rows[rowIndex].Cells[_stockMoveDataTable.MovingSupliStockColumn.ColumnName].Activate();
                            this.ultraGrid1.PerformAction(UltraGridAction.EnterEditMode);

                            this._movingSupliStockFlg = false;
                        }
                        else
                        {
                            // -------- UPD 2011/04/11 ------------------------------------>>>>>
                            //int blGoodsCode = ChangeCellValueToInt(this.ultraGrid1.Rows[rowIndex].Cells[_stockMoveDataTable.BLGoodsCodeColumn.ColumnName].Value);
                            //if (blGoodsCode == 0)
                            int supplierCd = ChangeCellValueToInt(this.ultraGrid1.Rows[rowIndex].Cells[_stockMoveDataTable.SupplierCdColumn.ColumnName].Value);
                            if (supplierCd == 0)
                            // -------- UPD 2011/04/11 ------------------------------------>>>>>
                            {
                                // -------- UPD 2010/11/25 ------------------------------------>>>>>
                                //// BLガイドにフォーカス
                                //this.ultraGrid1.Rows[rowIndex].Cells[_stockMoveDataTable.BLCodeGuideButtonColumn.ColumnName].Activate();
                                //this.ultraGrid1.PerformAction(UltraGridAction.EnterEditMode);
                                this.ultraGrid1.PerformAction(UltraGridAction.PrevCellByTab);
                                // -------- UPD 2010/11/25 ------------------------------------<<<<<
                            }
                            else
                            {
                       
                                // -------- UPD 2010/11/25 ------------------------------------>>>>>
                                //// BLコードにフォーカス
                                //this.ultraGrid1.Rows[rowIndex].Cells[_stockMoveDataTable.BLGoodsCodeColumn.ColumnName].Activate();
                                //this.ultraGrid1.PerformAction(UltraGridAction.EnterEditMode);
                                // -------- ADD 2011/04/11 ------------------------------------>>>>>
                                if (!this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveDataTable.SupplierCdColumn.ColumnName].Hidden)
                                {
                                    // 仕入先にフォーカス
                                    this.ultraGrid1.Rows[rowIndex].Cells[_stockMoveDataTable.SupplierCdColumn.ColumnName].Activate();
                                    this.ultraGrid1.PerformAction(UltraGridAction.EnterEditMode);
                                }
                                // -------- ADD 2011/04/11 ------------------------------------<<<<<
                                // -------- UPD 2011/04/11 ------------------------------------>>>>>
                                //if (!this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveDataTable.BLGoodsCodeColumn.ColumnName].Hidden)
                                else if (!this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveDataTable.BLGoodsCodeColumn.ColumnName].Hidden)
                                // -------- UPD 2011/04/11 ------------------------------------<<<<<
                                {
                                    // BLコードにフォーカス
                                    this.ultraGrid1.Rows[rowIndex].Cells[_stockMoveDataTable.BLGoodsCodeColumn.ColumnName].Activate();
                                    this.ultraGrid1.PerformAction(UltraGridAction.EnterEditMode);
                                }
                                
                                else
                                {
                                    this.ultraGrid1.PerformAction(UltraGridAction.PrevCellByTab);
                                }
                                // -------- UPD 2010/11/25 ------------------------------------<<<<<
                                
                            }
                        }

                        //blGoodsCode = ChangeCellValueToInt(this.ultraGrid1.Rows[rowIndex].Cells[_stockMoveDataTable.BLGoodsCodeColumn.ColumnName].Value);
                        //if (blGoodsCode == 0)
                        //{
                        //    // BLガイドにフォーカス
                        //    this.ultraGrid1.Rows[rowIndex].Cells[_stockMoveDataTable.BLCodeGuideButtonColumn.ColumnName].Activate();
                        //    this.ultraGrid1.PerformAction(UltraGridAction.EnterEditMode);
                        //}
                        //else
                        //{
                        //    // BLコードにフォーカス
                        //    this.ultraGrid1.Rows[rowIndex].Cells[_stockMoveDataTable.BLGoodsCodeColumn.ColumnName].Activate();
                        //    this.ultraGrid1.PerformAction(UltraGridAction.EnterEditMode);
                        //}

                        break;
                    }
                default:
                    {
                        this.ultraGrid1.PerformAction(UltraGridAction.PrevCellByTab);
                        return;
                    }
            }

            // テーブル更新フラグをTrueにする。
            this.tableUpdateFlg = true;

            // 移動合計更新デリゲート
            this.TotalPriceSetting();
        }

        /// <summary>
        /// グリッドEnter時フォーカス設定処理(ReturnKey押下時)
        /// </summary>
        public void ReturnKeyDownEnterFocus()
        {
            // 先頭行の品番にフォーカスをセットします
            this.ultraGrid1.Rows[0].Cells[_stockMoveDataTable.GoodsNoColumn.ColumnName].Activate();
            this.ultraGrid1.PerformAction(UltraGridAction.EnterEditMode);
        }

        /// <summary>
        /// グリッドEnter時フォーカス設定処理(ShiftKey押下時)
        /// </summary>
        public void ShiftKeyDownEnterFocus()
        {
            // 最終行の標準価格にフォーカスをセットします
            this.ultraGrid1.Rows[this.ultraGrid1.Rows.Count - 1].Cells[_stockMoveDataTable.ListPriceFlViewColumn.ColumnName].Activate();
            this.ultraGrid1.PerformAction(UltraGridAction.EnterEditMode);
        }

        private double StringToDouble(string targetText)
        {
            if ((targetText == null) || (targetText.Trim() == ""))
            {
                return 0;
            }

            try
            {
                return Convert.ToDouble(targetText);
            }
            catch
            {
                return 0;
            }
        }

        public bool CheckGridBeforeRetry(ArrayList retList)
        {
            if (this.ultraGrid1.Rows.Count != retList.Count)
            {
                return (false);
            }

            for (int index = 0; index < this.ultraGrid1.Rows.Count; index++)
            {
                StockMoveWork stockMoveWork = (StockMoveWork)retList[index];

                // ADD 2011/05/10 ------>>>>>
                // Redmine#20837元に戻すボタンのチェック対象に仕入先も追加します。
                // 仕入先コード
                if (StringToDouble(this.ultraGrid1.Rows[index].Cells[_stockMoveDataTable.SupplierCdColumn.ColumnName].Text) != stockMoveWork.SupplierCd)
                {
                    return (false);
                }
                // ADD 2011/05/10 ------<<<<<

                // 出荷数
                if (StringToDouble(this.ultraGrid1.Rows[index].Cells[_stockMoveDataTable.MovingSupliStockColumn.ColumnName].Text) != stockMoveWork.MoveCount)
                {
                    return (false);
                }

                // 原単価
                if (StringToDouble(this.ultraGrid1.Rows[index].Cells[_stockMoveDataTable.StockUnitPriceFlColumn.ColumnName].Text) != stockMoveWork.StockUnitPriceFl)
                {
                    return (false);
                }

                // 標準価格
                if (StringToDouble(this.ultraGrid1.Rows[index].Cells[_stockMoveDataTable.ListPriceFlViewColumn.ColumnName].Text) != stockMoveWork.ListPriceFl)
                {
                    return (false);
                }
            }

            return (true);
        }

        public bool CheckGridBeforeNewProc()
        {
            for (int index = 0; index < this.ultraGrid1.Rows.Count; index++)
            {
                if (this.ultraGrid1.Rows[index].Cells[_stockMoveDataTable.GoodsNoColumn.ColumnName].Text.Trim() != "")
                {
                    return (false);
                }
                if (this.ultraGrid1.Rows[index].Cells[_stockMoveDataTable.GoodsNameColumn.ColumnName].Text.Trim() != "")
                {
                    return (false);
                }
                if (this.ultraGrid1.Rows[index].Cells[_stockMoveDataTable.GoodsMakerCdColumn.ColumnName].Text.Trim() != "")
                {
                    return (false);
                }
                if (this.ultraGrid1.Rows[index].Cells[_stockMoveDataTable.BLGoodsCodeColumn.ColumnName].Text.Trim() != "")
                {
                    return (false);
                }
                //---ADD 2011/04/11----------------------------------------------------------->>>>>
                if (this.ultraGrid1.Rows[index].Cells[_stockMoveDataTable.SupplierCdColumn.ColumnName].Text.Trim() != "")
                {
                    return (false);
                }
                //---ADD 2011/04/11-----------------------------------------------------------<<<<<
                if (this.ultraGrid1.Rows[index].Cells[_stockMoveDataTable.MovingSupliStockColumn.ColumnName].Text.Trim() != "")
                {
                    return (false);
                }
                if (this.ultraGrid1.Rows[index].Cells[_stockMoveDataTable.StockUnitPriceFlColumn.ColumnName].Text.Trim() != "")
                {
                    return (false);
                }
                if (this.ultraGrid1.Rows[index].Cells[_stockMoveDataTable.ListPriceFlViewColumn.ColumnName].Text.Trim() != "")
                {
                    return (false);
                }
            }

            return (true);
        }

        /// <summary>
        /// グリッド入力チェック処理
        /// </summary>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>ステータス</returns>
        /// <br>Update Note: 2011/04/11 鄧潘ハン 明細に仕入先を追加する</br>
        public bool CheckInputGrid(out string errMsg)
        {
            errMsg = "";

            for (int index = 0; index < this.ultraGrid1.Rows.Count; index++)
            {
                // 品番取得
                string goodsNo = ChangeCellValueToString(this.ultraGrid1.Rows[index].Cells[_stockMoveDataTable.GoodsNoColumn.ColumnName].Value);

                if (goodsNo == "")
                {
                    continue;
                }

                // 品名取得
                string goodsName = ChangeCellValueToString(this.ultraGrid1.Rows[index].Cells[_stockMoveDataTable.GoodsNameColumn.ColumnName].Value);
                if (goodsName == "")
                {
                    errMsg = "品名を入力してください。";
                    this.ultraGrid1.Rows[index].Cells[_stockMoveDataTable.GoodsNameColumn.ColumnName].Activate();
                    this.ultraGrid1.PerformAction(UltraGridAction.EnterEditMode);
                    return (false);
                }

                // メーカーコード取得
                int makerCode = ChangeCellValueToInt(this.ultraGrid1.Rows[index].Cells[_stockMoveDataTable.GoodsMakerCdColumn.ColumnName].Value);
                if (makerCode == 0)
                {
                    errMsg = "メーカーコードを入力してください。";
                    this.ultraGrid1.Rows[index].Cells[_stockMoveDataTable.GoodsMakerCdColumn.ColumnName].Activate();
                    this.ultraGrid1.PerformAction(UltraGridAction.EnterEditMode);
                    return (false);
                }
                if (!this._stockMoveInputAcs.makerCodeCheck(makerCode))
                {
                    errMsg = "マスタに登録されていないメーカーコードが存在します。";
                    this.ultraGrid1.Rows[index].Cells[_stockMoveDataTable.GoodsMakerCdColumn.ColumnName].Activate();
                    this.ultraGrid1.PerformAction(UltraGridAction.EnterEditMode);
                    return (false);
                }
               
                // BLコード取得
                int blGoodsCode = ChangeCellValueToInt(this.ultraGrid1.Rows[index].Cells[_stockMoveDataTable.BLGoodsCodeColumn.ColumnName].Value);
                if (blGoodsCode != 0)
                {
                    if (!this._stockMoveInputAcs.blGoodsCodeCheck(blGoodsCode))
                    {
                        errMsg = "マスタに登録されていないBLｺｰﾄﾞが存在します。";
                        this.ultraGrid1.Rows[index].Cells[_stockMoveDataTable.BLGoodsCodeColumn.ColumnName].Activate();
                        this.ultraGrid1.PerformAction(UltraGridAction.EnterEditMode);
                        return (false);
                    }
                }
                //---ADD 2011/04/11----------------------------------------------------------->>>>>
                // 仕入先取得
                int SupplierCd = ChangeCellValueToInt(this.ultraGrid1.Rows[index].Cells[_stockMoveDataTable.SupplierCdColumn.ColumnName].Value);
                // ADD 2011/05/10 ------>>>>>
                // Redmine#20879 F10保存をクリックして、仕入先必須チェックを削除する
                if (SupplierCd != 0)
                {
                // ADD 2011/05/10 ------<<<<<
                    if (!this._stockMoveInputAcs.SupplierCdCheck(SupplierCd))
                    {
                        errMsg = "マスタに登録されていない仕入先コードが存在します。";
                        this.ultraGrid1.Rows[index].Cells[_stockMoveDataTable.SupplierCdColumn.ColumnName].Activate();
                        this.ultraGrid1.PerformAction(UltraGridAction.EnterEditMode);
                        return (false);
                    }
                // ADD 2011/05/10 ------>>>>>
                }
                // ADD 2011/05/10 ------<<<<<
                //---ADD 2011/04/11-----------------------------------------------------------<<<<<

                // 出庫拠点コード取得
                string bfSectionCode = ChangeCellValueToString(this.ultraGrid1.Rows[index].Cells[_stockMoveDataTable.BfSectionCodeColumn.ColumnName].Value);
                // 出庫倉庫コード取得
                string bfWarehouseCode = ChangeCellValueToString(this.ultraGrid1.Rows[index].Cells[_stockMoveDataTable.BfEnterWarehCodeColumn.ColumnName].Value);

                if ((bfSectionCode == _stockMoveHeader.AfSectionCode.Trim()) &&
                    ((bfWarehouseCode != "") && (bfWarehouseCode == _stockMoveHeader.AfEnterWarehCode.Trim())))
                {
                    errMsg = "同一倉庫への在庫移動処理はできません。";
                    this.ultraGrid1.Rows[index].Cells[_stockMoveDataTable.GoodsNoColumn.ColumnName].Activate();
                    this.ultraGrid1.PerformAction(UltraGridAction.EnterEditMode);
                    return (false);
                }

                // 出荷数取得
                double movingSupliStock = ChangeCellValueToDouble(this.ultraGrid1.Rows[index].Cells[_stockMoveDataTable.MovingSupliStockColumn.ColumnName].Value);
                if (movingSupliStock == 0)
                {
                    errMsg = "出庫数を入力してください。";
                    this.ultraGrid1.Rows[index].Cells[_stockMoveDataTable.MovingSupliStockColumn.ColumnName].Activate();
                    this.ultraGrid1.PerformAction(UltraGridAction.EnterEditMode);
                    return (false);
                }

                bool stockExistFlg;
                if (this.ultraGrid1.Rows[index].Cells[_stockMoveDataTable.StockMoveRowNoColumn.ColumnName].Tag == null)
                {
                    stockExistFlg = false;
                }
                else
                {
                    stockExistFlg = (bool)this.ultraGrid1.Rows[index].Cells[_stockMoveDataTable.StockMoveRowNoColumn.ColumnName].Tag;
                }

                if (stockExistFlg)
                {
                    // 在庫切れ出荷区分チェック
                    int stockTolerncShipmDiv = this._stockMoveInputAcs.GetStockTolerncShipmDiv(LoginInfoAcquisition.Employee.BelongSectionCode);
                    switch (stockTolerncShipmDiv)
                    {
                        // 警告＋再入力、再入力
                        case 2:
                        case 3:
                            {
                                // 出庫前数
                                double bfBeforeMoveCount = ChangeCellValueToDouble(this.ultraGrid1.Rows[index].Cells[_stockMoveDataTable.BfBeforeMoveCountColumn.ColumnName].Value);

                                if (movingSupliStock > bfBeforeMoveCount)
                                {
                                    errMsg = "出庫数が現在庫を上回るため、登録できません。";
                                    this.ultraGrid1.Rows[index].Cells[_stockMoveDataTable.MovingSupliStockColumn.ColumnName].Activate();
                                    this.ultraGrid1.PerformAction(UltraGridAction.EnterEditMode);
                                    return (false);
                                }
                                break;
                            }
                    }
                }
            }

            return (true);
        }
        // --- ADD 2008/07/14 ---------------------------------------------------------------------<<<<<

        #region DEL 2008/07/14 Partsman用に変更
        /* --- DEL 2008/07/14 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// Returnキーダウン処理
        /// </summary>
        /// <returns>true:セル移動完了 false:セル移動失敗</returns>
        public bool ReturnKeyDown()
        {
            this._warehouseFocusFlg = false;

            if (this.ultraGrid1.ActiveCell == null) return false;
            UltraGridCell cell = this.ultraGrid1.ActiveCell;
            int stockRowNo = _stockMoveInputAcs.StockMoveDataTable[cell.Row.Index].StockMoveRowNo;

            bool canMove = true;

            // ActiveCellが商品コードの場合
            if ( cell.Column.Key == _stockMoveInputAcs.StockMoveDataTable.GoodsNoColumn.ColumnName )
            {
                // ActiveCellが変更していない場合はNextCellを実行する
                if ( this.ultraGrid1.ActiveCell.Column.Key == _stockMoveInputAcs.StockMoveDataTable.GoodsNoColumn.ColumnName )
                {
                    this.ultraGrid1.PerformAction( UltraGridAction.ExitEditMode );

                    if ((string)cell.Value != string.Empty)
                    {
                        // セル移動→出荷数へ
                        this.ultraGrid1.PerformAction(UltraGridAction.ExitEditMode);
                        this.ultraGrid1.PerformAction(UltraGridAction.EnterEditMode);

                        cell = ultraGrid1.Rows[cell.Row.Index].Cells[_stockMoveInputAcs.StockMoveDataTable.MovingSupliStockColumn.ColumnName];
                        ultraGrid1.ActiveCell = cell;

                        this.ultraGrid1.PerformAction(UltraGridAction.ExitEditMode);
                        this.ultraGrid1.PerformAction(UltraGridAction.EnterEditMode);

                        // ActiveCellが変更していない場合はNextCellを実行する
                        if (this.ultraGrid1.ActiveCell.Column.Key == _stockMoveInputAcs.StockMoveDataTable.GoodsNoColumn.ColumnName)
                        {
                            canMove = this.ultraGrid1.PerformAction(UltraGridAction.NextCellByTab);
                        }
                    }
                }
            }
            // ActiveCellが出荷数の場合
            else if (cell.Column.Key == _stockMoveInputAcs.StockMoveDataTable.MovingSupliStockColumn.ColumnName)
            {
                this.ultraGrid1.PerformAction( UltraGridAction.ExitEditMode );

                if ( _errMoveCount )
                {
                    // セル移動しない
                    cell = this.ultraGrid1.Rows[cell.Row.Index].Cells[_stockMoveInputAcs.StockMoveDataTable.MovingSupliStockColumn.ColumnName];
                    ultraGrid1.ActiveCell = cell;
                    this.ultraGrid1.PerformAction( UltraGridAction.EnterEditMode );
                }
                else
                {
                    // 次入力可能セル移動処理
                    canMove = this.MoveNextAllowEditCell( false );
                }
            }
            else
            {
                if (this._warehouseFocusFlg == false)
                {
                    // 次入力可能セル移動処理
                    canMove = this.MoveNextAllowEditCell(false);
                }
                else
                {
                    setWarehouseCodeFocus();
                }
            }

            return canMove;
        }
           --- DEL 2008/07/14 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/14 Partsman用に変更

        /// <summary>
        /// グリッド有効件数の取得
        /// </summary>
        /// <returns>グリッド内での有効なレコード件数</returns>
        public int GetGridValidCount()
        {
            int recordCount = 0;

            foreach (StockMoveInputDataSet.StockMoveRow row in _stockMoveDataTable)
            {
                if ( row.GoodsNo.Trim() != "" )
                {
                    recordCount++;
                }
            }

            return recordCount;
        }

        /// <summary>
        /// 在庫検索ボタン有効(無効)変更処理
        /// </summary>
        /// <param name="enable">True:表示 False:非表示</param>
        public void StockSearchEnable(bool enable)
        {
            /* --- DEL 2008/07/14 --------------------------------------------------------------------->>>>>
            this.GoodsSearch_ultraButton.Enabled = enable;
               --- DEL 2008/07/14 ---------------------------------------------------------------------<<<<<*/
            this.RowDelete_ultraButton.Enabled = enable;
            this._deleteFlg = true;
        }

        /// <summary>
        /// Keyリスト取得処理
        /// </summary>
        private void GetKeyList()
        {
            // グリッドの行インデックスをKeyに品番とメーカーコードを保持します
            this._keyList = new Dictionary<int, string>();

            for (int index = 0; index < this.ultraGrid1.Rows.Count; index++)
            {
                // 品番
                string goodsNo = ChangeCellValueToString(this.ultraGrid1.Rows[index].Cells[_stockMoveDataTable.GoodsNoColumn.ColumnName].Value);
                // メーカーコード
                int makerCode = ChangeCellValueToInt(this.ultraGrid1.Rows[index].Cells[_stockMoveInputAcs.StockMoveDataTable.GoodsMakerCdColumn.ColumnName].Value);

                if ((goodsNo == "") || (makerCode == 0))
                {
                    continue;
                }

                this._keyList.Add(index, MakeKey(makerCode, goodsNo));
            }
        }

        /// <summary>
        /// 同一商品チェック処理
        /// </summary>
        /// <param name="index">行インデックス</param>
        /// <param name="makerCode">メーカーコード</param>
        /// <param name="goodsNo">品番</param>
        /// <returns>すてーたす(True:同一商品あり  False:同一商品なし)</returns>
        private bool CheckSameGoods(int index, int makerCode, string goodsNo)
        {
            // 対象行のメーカーコードと品番が既に検索されているかどうかチェックします
            if (this._keyList.ContainsKey(index))
            {
                if (this._keyList[index] == MakeKey(makerCode, goodsNo))
                {
                    return (true);
                }
            }

            return (false);
        }

        #region DEL 2008/07/14 使用していないのでコメントアウト
        /* --- DEL 2008/07/14 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// ヘッダ画面からのフォーカス遷移
        /// </summary>
        public void SetGridFocus()
        {
            ultraGrid1.ActiveCell = ultraGrid1.Rows[0].Cells[0];
            this.ultraGrid1.PerformAction(UltraGridAction.EnterEditMode);

            UltraGridCell cell = this.ultraGrid1.ActiveCell;
            
            this.ultraGrid1.PerformAction(UltraGridAction.FirstCellInRow);

            this.ultraGrid1.PerformAction(UltraGridAction.ExitEditMode);
            this.ultraGrid1.PerformAction(UltraGridAction.EnterEditMode);
        }
           --- DEL 2008/07/14 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/14 使用していないのでコメントアウト

        # endregion

        #region DEL 2008/07/14 使用していないのでコメントアウト
        /* --- DEL 2008/07/14 --------------------------------------------------------------------->>>>>
        # region タイマーイベント

        /// <summary>
        /// 在庫移動グリッド情報取得タイマー起動イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;

            if (this.ultraGrid1.ActiveCell != null)
            {
                // アクティブセルの取得
                UltraGridCell activeCell = this.ultraGrid1.ActiveCell;

                if (activeCell.Column.Key == _stockMoveDataTable.GoodsGuideButtonColumn.ColumnName)
                {
                    // エラーキャンセル
                    _errGoodsNo = false;


                    // ヘッダ情報を更新
                    this.SetStockMoveHeader();

                    // 商品検索ガイド画面のインスタンスを生成
                    StockSearchGuide stockSearchGuide = new StockSearchGuide();

                    // 商品検索ガイド検索条件データ
                    StockSearchPara stockSearchPara = new StockSearchPara();

                    // 企業コード
                    stockSearchPara.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;

                    // 出庫拠点、出庫倉庫の入力があった場合はそちらを優先(本社機能時のみ入力可能)
                    // 拠点コード
                    if (_stockMoveHeader.BfSectionCode.Trim() == "")
                    {
                        stockSearchPara.SectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
                        stockSearchGuide.IsFixedSection = true;
                    }
                    else
                    {
                        stockSearchPara.SectionCode = _stockMoveHeader.BfSectionCode;
                        stockSearchGuide.IsFixedSection = true;
                    }

                    // 倉庫コード
                    if (_stockMoveHeader.BfEnterWarehCode.Trim() == "")
                    {
                        // 倉庫の指定が無かった場合は条件に含めない。
                        stockSearchGuide.IsFixedWarehouseCode = false;
                    }
                    else
                    {
                        stockSearchPara.WarehouseCode = _stockMoveHeader.BfEnterWarehCode;
                        stockSearchGuide.IsFixedWarehouseCode = true;
                    }

                    // ゼロ在庫表示
                    // 0:表示する 1:表示しない
                    stockSearchPara.ZeroStckDsp = 1;


                    // 商品検索ガイド結果オブジェクト
                    object retObj = null;

                    timer1.Enabled = false;

                    // 複数選択可能設定
                    stockSearchGuide.IsMultiSelect = false;

                    // 商品検索ガイド画面の表示
                    stockSearchGuide.ShowGuide(this, StockSearchGuide.emSearchMode.Stock, true, stockSearchPara, out retObj);

                    // ガイドからの選択が無かった場合
                    if (retObj == null)
                    {
                        return;
                    }
                    // 正常に取得した場合
                    else
                    {
                        // データテーブル更新フラグ
                        this.tableUpdateFlg = true;

                        // 在庫移動データ、在庫移動詳細データを格納及びデータテーブルを更新
                        List<StockExpansion> stockSearchRetList = (List<StockExpansion>)retObj;

                        if (stockSearchRetList == null || stockSearchRetList.Count == 0)
                        {
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "該当データが存在しません。",
                                -1,
                                MessageBoxButtons.OK);
                            _errGoodsNo = true;
                            return;
                        }

                        // 在庫移動データテーブルに格納(在庫移動データのみ)
                        this.StockMoveDataTableFromStockSearchRet(stockSearchRetList, activeCell);

                        if (!_errGoodsNo)
                        {
                            // Nextセルに移動
                            this.MoveNextAllowEditCell(false);

                            // 行状態を変更
                            this.SettingGridRow(activeCell.Row.Index);
                        }
                        else
                        {
                            // セル移動
                            UltraGridCell cell = this.ultraGrid1.Rows[activeCell.Row.Index].Cells[_stockMoveInputAcs.StockMoveDataTable.GoodsNoColumn.ColumnName];
                            ultraGrid1.ActiveCell = cell;
                            this.ultraGrid1.PerformAction(UltraGridAction.EnterEditMode);
                            return;
                        }
                    }

                    // 最終行の場合は、１行追加する
                    if (activeCell.Row.Index == _stockMoveInputAcs.StockMoveDataTable.Rows.Count - 1)
                    {
                        this._stockMoveInputAcs.AddStockDetailRow();
                    }
                }

            }
            timer1.Enabled = false;
        }

        # endregion
           --- DEL 2008/07/14 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/14 使用していないのでコメントアウト

        // --- ADD 2008/07/14 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// Leave イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        private void ultraGrid1_Leave(object sender, EventArgs e)
        {
            enterGoodsNoColumn(false);

            this.ultraGrid1.ActiveCell = null;
            //--ADD 2011/05/10------->>>>>>>
            if (this._sameGoodNoFlg)
            {
                this.ultraGrid1.Rows[_index].Cells[_key].Activate();
                this.ultraGrid1.PerformAction(UltraGridAction.EnterEditMode);
                this._sameGoodNoFlg = false;
            }
           //--ADD 2011/05/10----<<<<<<
        }

        /// <summary>
        /// ClickCellButton イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        private void ultraGrid1_ClickCellButton(object sender, CellEventArgs e)
        {
            int rowIndex = this.ultraGrid1.ActiveCell.Row.Index;
            string columnKey = this.ultraGrid1.ActiveCell.Column.Key;

            switch (columnKey)
            {
                case "MakerGuideButton":
                    {
                        this.Cursor = Cursors.WaitCursor;

                        MakerUMnt makerUMnt;
                        MakerAcs makerAcs = new MakerAcs();

                        // メーカーガイド表示
                        int status = makerAcs.ExecuteGuid(LoginInfoAcquisition.EnterpriseCode, out makerUMnt);
                        if (status == 0)
                        {
                            _stockMoveDataTable[rowIndex].GoodsMakerCd = makerUMnt.GoodsMakerCd.ToString().PadLeft(4, '0');

                            this.ultraGrid1.Rows[rowIndex].Cells[_stockMoveInputAcs.StockMoveDataTable.GoodsMakerCdColumn.ColumnName].Activate();
                            //ultraGrid1_AfterExitEditMode(this.ultraGrid1, new EventArgs());
                            ultraGrid1_AfterCellUpdate(this.ultraGrid1, new CellEventArgs(this.ultraGrid1.ActiveCell));

                            this.ultraGrid1.Rows[rowIndex].Cells[_stockMoveInputAcs.StockMoveDataTable.BLGoodsCodeColumn.ColumnName].Activate();
                            this.ultraGrid1.PerformAction(UltraGridAction.EnterEditMode);
                        }

                        break;
                    }
                case "BLCodeGuideButton":
                    {
                        this.Cursor = Cursors.WaitCursor;

                        BLGoodsCdUMnt blGoodsCdUMnt;
                        BLGoodsCdAcs blGoodsCdAcs = new BLGoodsCdAcs();

                        // BLコードガイド表示
                        int status = blGoodsCdAcs.ExecuteGuid(LoginInfoAcquisition.EnterpriseCode, out blGoodsCdUMnt);
                        if (status == 0)
                        {
                            _stockMoveDataTable[rowIndex].BLGoodsCode = blGoodsCdUMnt.BLGoodsCode.ToString().PadLeft(5, '0');
                            this.ultraGrid1.Rows[rowIndex].Cells[_stockMoveInputAcs.StockMoveDataTable.MovingSupliStockColumn.ColumnName].Activate();
                            this.ultraGrid1.PerformAction(UltraGridAction.EnterEditMode);
                        }

                        break;
                    }
                //---ADD 2011/04/11----------------------------------------------------------->>>>>
                case "SupplierCdGuideButton":
                    {
                        this.Cursor = Cursors.WaitCursor;

                        SupplierAcs supplierAcs = new SupplierAcs();
                        Supplier supplier;
                        // ガイドボタンをクリック前の仕入先コードを保存する
                        oldsupplierCd = ChangeCellValueToInt(this.ultraGrid1.Rows[rowIndex].Cells[_stockMoveInputAcs.StockMoveDataTable.SupplierCdColumn.ColumnName].Value); // ADD 2011/05/26
                        // 仕入先ガイド表示
                        int status = supplierAcs.ExecuteGuid(out supplier, LoginInfoAcquisition.EnterpriseCode, "");
                        if (status == 0)
                        {
                            _stockMoveDataTable[rowIndex].SupplierCd = supplier.SupplierCd.ToString().PadLeft(6, '0');
                            //this.ultraGrid1.Rows[rowIndex].Cells[_stockMoveInputAcs.StockMoveDataTable.SupplierCdColumn.ColumnName].Activate(); //DEL 2011/05/26
                            this.ultraGrid1.PerformAction(UltraGridAction.EnterEditMode);
                           
                            // 商品検索
                            GoodsUnitData goodsUnitData;
                            string goodsNo = ChangeCellValueToString(this.ultraGrid1.Rows[rowIndex].Cells[_stockMoveInputAcs.StockMoveDataTable.GoodsNoColumn.ColumnName].Value);
                            int makerCode = ChangeCellValueToInt(this.ultraGrid1.Rows[rowIndex].Cells[_stockMoveInputAcs.StockMoveDataTable.GoodsMakerCdColumn.ColumnName].Value);
                            if (goodsNo != "")
                            {
                                SearchGoods(goodsNo, makerCode, out goodsUnitData);
                                goodsUnitData.SupplierCd = ChangeCellValueToInt(this.ultraGrid1.Rows[rowIndex].Cells[_stockMoveInputAcs.StockMoveDataTable.SupplierCdColumn.ColumnName].Value);
                                if (oldsupplierCd != goodsUnitData.SupplierCd)
                                {
                                    // Redmine#21632 仕入先変更時、メッセージを追加します
                                    //_stockMoveDataTable[rowIndex].StockUnitPriceFl = GetStockUnitPrice(goodsUnitData); //---DEL 2011/05/20 
                                    //_stockMoveDataTable[rowIndex].BfStockUnitPriceFl = GetStockUnitPrice(goodsUnitData); //---DEL 2011/05/20 
                                    //---ADD 2011/05/20---------------------->>>>>
                                    DialogResult dialogResult = TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                        this.Name,
                                        "仕入先が変更されました。" + "\r\n" + "\r\n" +
                                        "商品価格を再取得しますか？",
                                        -1,
                                        MessageBoxButtons.YesNo);
                                    if (dialogResult == DialogResult.Yes)
                                    {
                                        _stockMoveDataTable[rowIndex].StockUnitPriceFl = GetStockUnitPrice(goodsUnitData);
                                        _stockMoveDataTable[rowIndex].BfStockUnitPriceFl = GetStockUnitPrice(goodsUnitData);
                                    }
                                    //---ADD 2011/05/20----------------------<<<<<
                                    _stockMoveDataTable[rowIndex].SupplierSnm = supplier.SupplierSnm;
                                    // oldsupplierCd = goodsUnitData.SupplierCd; //DEL 2011/05/26
                                }
                                this.TotalPriceSetting();
                                //---ADD 2011/05/20---------------------->>>>>
                                //　ガイドより仕入先コードを取得後で、フォーカスが出庫数を設定します
                                this.ultraGrid1.Rows[rowIndex].Cells[_stockMoveInputAcs.StockMoveDataTable.MovingSupliStockColumn.ColumnName].Activate();
                                this.ultraGrid1.PerformAction(UltraGridAction.EnterEditMode);
                                //---ADD 2011/05/20----------------------<<<<<
                            }
                        }
                        break;
                    }
                //---ADD 2011/04/11-----------------------------------------------------------<<<<<
            }
        }

        private void ultraGrid1_AfterExitEditMode(object sender, EventArgs e)
        {
            if (this.ultraGrid1.ActiveCell == null)
            {
                return;
            }

            switch (this.ultraGrid1.ActiveCell.Column.Key)
            {
                case "GoodsMakerCd":
                    {
                        int makerCode = ChangeCellValueToInt(this.ultraGrid1.ActiveCell.Value);
                        if (makerCode == 0)
                        {
                            return;
                        }

                        this.ultraGrid1.AfterCellUpdate -= this.ultraGrid1_AfterCellUpdate;
                        this.ultraGrid1.ActiveCell.Value = makerCode.ToString("0000");
                        this.ultraGrid1.AfterCellUpdate += this.ultraGrid1_AfterCellUpdate;

                        break;
                    }
                case "BLGoodsCode":
                    {
                        int blGoodsCode = ChangeCellValueToInt(this.ultraGrid1.ActiveCell.Value);
                        if (blGoodsCode == 0)
                        {
                            return;
                        }

                        this.ultraGrid1.AfterCellUpdate -= this.ultraGrid1_AfterCellUpdate;
                        this.ultraGrid1.ActiveCell.Value = blGoodsCode.ToString("00000");
                        this.ultraGrid1.AfterCellUpdate += this.ultraGrid1_AfterCellUpdate;

                        break;
                    }
                //---ADD 2011/04/11----------------------------------------------------------->>>>>
                case "SupplierCd":
                    {
                        int SupplierCd = ChangeCellValueToInt(this.ultraGrid1.ActiveCell.Value);
                        if (SupplierCd == 0)
                        {
                            return;
                        }
                        this.ultraGrid1.AfterCellUpdate -= this.ultraGrid1_AfterCellUpdate;
                
                        this.ultraGrid1.ActiveCell.Value = SupplierCd.ToString("000000");
                        this.ultraGrid1.AfterCellUpdate += this.ultraGrid1_AfterCellUpdate;

                        break;
                    }
                //---ADD 2011/04/11-----------------------------------------------------------<<<<<
                // ------------ADD START wangf 2012/05/22 FOR Redmine#29881--------->>>>
                case "ListPriceFlView":
                    {
                        if ("オープン価格".Equals(this.ultraGrid1.ActiveCell.Value.ToString()))
                        {
                            return;
                        }

                        // 標準価格
                        double listPriceFl = ChangeCellValueToDouble(this.ultraGrid1.ActiveCell.Value);
                        if (listPriceFl == 0)
                        {
                            return;
                        }

                        this.ultraGrid1.AfterCellUpdate -= this.ultraGrid1_AfterCellUpdate;
                        this.ultraGrid1.ActiveCell.Value = listPriceFl.ToString("#,##0");
                        this.ultraGrid1.AfterCellUpdate += this.ultraGrid1_AfterCellUpdate;
                        break;
                    }
                // ------------ADD END wangf 2012/05/22 FOR Redmine#29881---------<<<<<
            }

        }

        private void ultraGrid1_AfterCellUpdate(object sender, CellEventArgs e)
        {
            if (this._closeFlg == true)
            {
                return;
            }

            if (this.ultraGrid1.ActiveCell == null)
            {
                return;
            }

            int rowIndex = this.ultraGrid1.ActiveCell.Row.Index;
            string columnKey = this.ultraGrid1.ActiveCell.Column.Key;

            int status;

            this._warehouseFocusFlg = false;
            this._movingSupliStockFlg = false;

            switch (columnKey)
            {
                case "GoodsNo":
                    {
                        // ヘッダを格納
                        SetStockMoveHeader();

                        if (ChangeCellValueToString(this.ultraGrid1.ActiveCell.Value) == "")
                        {
                            //-----------------
                            // 品番が未入力
                            //-----------------

                            if ((this.ultraGrid1.ActiveCell.Tag != null) && ((string)this.ultraGrid1.ActiveCell.Tag != ""))
                            {
                                // 行内容クリア
                                ClearRecordInput(rowIndex);
                            }
                        }
                        else
                        {
                            //-----------------
                            // 品番が入力
                            //-----------------
                            string msg = "";
                            if (_stockMoveHeader.BfEnterWarehCode.Trim() == "")
                            {
                                msg = "先に出庫倉庫を入力してください。";
                                this._warehouseFocusFlg = true;
                                this._warehouseName = "BfEnterWarehCode_tEdit";
                            }
                            else if (_stockMoveHeader.AfEnterWarehCode.Trim() == "")
                            {
                                msg = "先に入庫倉庫を入力してください。";
                                this._warehouseFocusFlg = true;
                                this._warehouseName = "AfEnterWarehCode_tEdit";
                            }

                            if (this._warehouseFocusFlg)
                            {
                                TMsgDisp.Show(
                                    this,
                                    emErrorLevel.ERR_LEVEL_INFO,
                                    this.Name,
                                    msg,
                                    -1,
                                    MessageBoxButtons.OK);

                                // 行内容クリア
                                ClearRecordInput(this.ultraGrid1.ActiveCell.Row.Index);
                                return;
                            }

                            // 品番
                            string goodsNo = ChangeCellValueToString(this.ultraGrid1.ActiveCell.Value);
                            // 品名
                            string goodsName = ChangeCellValueToString(this.ultraGrid1.Rows[rowIndex].Cells[_stockMoveInputAcs.StockMoveDataTable.GoodsNameColumn.ColumnName].Value);
                            // メーカーコード
                            int makerCode = 0;
                            //int makerCode = ChangeCellValueToInt(this.ultraGrid1.Rows[rowIndex].Cells[_stockMoveInputAcs.StockMoveDataTable.GoodsMakerCdColumn.ColumnName].Value);

                            //if (CheckSameGoods(rowIndex, makerCode, goodsNo))
                            //{
                            //    return;
                            //}

                            // 商品検索
                            GoodsUnitData goodsUnitData;
                            status = SearchGoods(goodsNo, makerCode, out goodsUnitData);
                            if (status == 0)
                            {
                                if (CheckSameGoods(rowIndex, goodsUnitData.GoodsMakerCd, goodsUnitData.GoodsNo))
                                {
                                    // 行内容クリア
                                    ClearRecordInput(this.ultraGrid1.ActiveCell.Row.Index);
                                    return;
                                }

                                SetRowEnabled(rowIndex);

                                // 在庫移動データテーブルに格納
                                StockMoveDataTableFromStockSearchRet(goodsUnitData, this.ultraGrid1.ActiveCell);

                                // 最終行の場合は、１行追加する
                                if (rowIndex == _stockMoveInputAcs.StockMoveDataTable.Rows.Count - 1)
                                {
                                    this._stockMoveInputAcs.AddStockDetailRow();
                                }

                                GetKeyList();
                            }
                            else if (status == 5)
                            {
                                // 行内容クリア
                                ClearRecordInput(this.ultraGrid1.ActiveCell.Row.Index);
                            }
                            else if (status == -1)
                            {
                                // 商品検索キャンセル時
                            }
                            else
                            {
                                // 行内容クリア
                                ClearRecordInput(this.ultraGrid1.ActiveCell.Row.Index);

                                SetRowEnabled(rowIndex);

                                this.ultraGrid1.AfterCellUpdate -= this.ultraGrid1_AfterCellUpdate;
                                this.ultraGrid1.ActiveCell.Value = goodsNo;
                                this.ultraGrid1.ActiveCell.Tag = goodsNo;
                                this.ultraGrid1.AfterCellUpdate += this.ultraGrid1_AfterCellUpdate;

                                //if (goodsName != "")
                                //{
                                //    this.ultraGrid1.AfterCellUpdate -= this.ultraGrid1_AfterCellUpdate;
                                //    this.ultraGrid1.Rows[rowIndex].Cells[_stockMoveInputAcs.StockMoveDataTable.GoodsNameColumn.ColumnName].Value = goodsName;
                                //    this.ultraGrid1.AfterCellUpdate += this.ultraGrid1_AfterCellUpdate;
                                //}

                                //if (makerCode != 0)
                                //{
                                //    this.ultraGrid1.AfterCellUpdate -= this.ultraGrid1_AfterCellUpdate;
                                //    this.ultraGrid1.Rows[rowIndex].Cells[_stockMoveInputAcs.StockMoveDataTable.GoodsMakerCdColumn.ColumnName].Value = makerCode.ToString("0000");
                                //    this.ultraGrid1.Rows[rowIndex].Cells[_stockMoveInputAcs.StockMoveDataTable.GoodsMakerCdColumn.ColumnName].Tag = makerCode.ToString("0000");
                                //    this.ultraGrid1.AfterCellUpdate += this.ultraGrid1_AfterCellUpdate;
                                //}
                            }
                        }

                        break;
                    }
                case "GoodsMakerCd":
                    {
                        // ヘッダを格納
                        SetStockMoveHeader();

                        // 品番
                        string goodsNo = ChangeCellValueToString(this.ultraGrid1.Rows[rowIndex].Cells[_stockMoveInputAcs.StockMoveDataTable.GoodsNoColumn.ColumnName].Value);
                        // メーカーコード
                        int makerCode = ChangeCellValueToInt(this.ultraGrid1.ActiveCell.Value);
                        if (makerCode == 0)
                        {
                            if ((this.ultraGrid1.ActiveCell.Tag != null) && ((string)this.ultraGrid1.ActiveCell.Tag != ""))
                            {
                                // 商品検索
                                GoodsUnitData goodsUnitData;
                                status = SearchGoods(goodsNo, makerCode, out goodsUnitData);
                                if (status == 0)
                                {
                                    if (CheckSameGoods(rowIndex, makerCode, goodsNo))
                                    {
                                        // 行内容クリア
                                        ClearRecordInput(this.ultraGrid1.ActiveCell.Row.Index);
                                        return;
                                    }

                                    // 在庫移動データテーブルに格納
                                    StockMoveDataTableFromStockSearchRet(goodsUnitData, this.ultraGrid1.ActiveCell);

                                    // 最終行の場合は、１行追加する
                                    if (rowIndex == _stockMoveInputAcs.StockMoveDataTable.Rows.Count - 1)
                                    {
                                        this._stockMoveInputAcs.AddStockDetailRow();
                                    }

                                    GetKeyList();
                                }
                                else if (status == 5)
                                {
                                    this._logicalDeleteFlg = false;
                                    int prevMakerCode = int.Parse((string)this.ultraGrid1.ActiveCell.Tag);
                                    this.ultraGrid1.AfterCellUpdate -= this.ultraGrid1_AfterCellUpdate;
                                    this.ultraGrid1.ActiveCell.Value = prevMakerCode.ToString("0000");
                                    this.ultraGrid1.ActiveCell.Tag = prevMakerCode.ToString("0000");
                                    this.ultraGrid1.AfterCellUpdate += this.ultraGrid1_AfterCellUpdate;
                                    //// 行内容クリア
                                    //ClearRecordInput(this.ultraGrid1.ActiveCell.Row.Index);
                                }
                                else if (status == 1)
                                {
                                    // 商品検索キャンセル時
                                }

                                //// 行内容クリア
                                //ClearRecordInput(this.ultraGrid1.ActiveCell.Row.Index);
                            }
                        }
                        else
                        {
                            //// 品番
                            //string goodsNo = ChangeCellValueToString((this.ultraGrid1.Rows[rowIndex].Cells[_stockMoveInputAcs.StockMoveDataTable.GoodsNoColumn.ColumnName].Value));
                            // 品名
                            string goodsName = ChangeCellValueToString((this.ultraGrid1.Rows[rowIndex].Cells[_stockMoveInputAcs.StockMoveDataTable.GoodsNameColumn.ColumnName].Value));

                            if (goodsNo == "")
                            {
                                this.ultraGrid1.AfterCellUpdate -= this.ultraGrid1_AfterCellUpdate;
                                this.ultraGrid1.ActiveCell.Value = makerCode.ToString("0000");
                                this.ultraGrid1.AfterCellUpdate += this.ultraGrid1_AfterCellUpdate;
                            }
                            else
                            {
                                // 商品検索
                                GoodsUnitData goodsUnitData;
                                status = SearchGoods(goodsNo, makerCode, out goodsUnitData);
                                if (status == 0)
                                {
                                    if (CheckSameGoods(rowIndex, makerCode, goodsNo))
                                    {
                                        //this.ultraGrid1.AfterCellUpdate -= this.ultraGrid1_AfterCellUpdate;
                                        //this.ultraGrid1.ActiveCell.Value = makerCode.ToString("0000");
                                        //this.ultraGrid1.ActiveCell.Tag = makerCode.ToString("0000");
                                        //this.ultraGrid1.AfterCellUpdate += this.ultraGrid1_AfterCellUpdate;
                                        // 行内容クリア
                                        ClearRecordInput(this.ultraGrid1.ActiveCell.Row.Index);
                                        return;
                                    }

                                    // 在庫移動データテーブルに格納
                                    StockMoveDataTableFromStockSearchRet(goodsUnitData, this.ultraGrid1.ActiveCell);

                                    // 最終行の場合は、１行追加する
                                    if (rowIndex == _stockMoveInputAcs.StockMoveDataTable.Rows.Count - 1)
                                    {
                                        this._stockMoveInputAcs.AddStockDetailRow();
                                    }

                                    GetKeyList();
                                }
                                else if (status == 5)
                                {
                                    // 行内容クリア
                                    ClearRecordInput(this.ultraGrid1.ActiveCell.Row.Index);
                                }
                                else if (status == 1)
                                {
                                    // 商品検索キャンセル時
                                }
                                else
                                {
                                    // 行内容クリア
                                    ClearRecordInput(this.ultraGrid1.ActiveCell.Row.Index);

                                    SetRowEnabled(rowIndex);

                                    this.ultraGrid1.AfterCellUpdate -= this.ultraGrid1_AfterCellUpdate;
                                    this.ultraGrid1.ActiveCell.Value = makerCode.ToString("0000");
                                    this.ultraGrid1.ActiveCell.Tag = makerCode.ToString("0000");
                                    this.ultraGrid1.Rows[rowIndex].Cells[_stockMoveInputAcs.StockMoveDataTable.GoodsNoColumn.ColumnName].Value = goodsNo;
                                    this.ultraGrid1.Rows[rowIndex].Cells[_stockMoveInputAcs.StockMoveDataTable.GoodsNoColumn.ColumnName].Tag = goodsNo;
                                    this.ultraGrid1.Rows[rowIndex].Cells[_stockMoveInputAcs.StockMoveDataTable.GoodsNameColumn.ColumnName].Value = goodsName;
                                    // --- ADD m.suzuki 2010/04/15 ---------->>>>>
                                    this.ultraGrid1.Rows[rowIndex].Cells[_stockMoveInputAcs.StockMoveDataTable.GoodsNameKanaColumn.ColumnName].Value = goodsUnitData.GoodsNameKana;
                                    // --- ADD m.suzuki 2010/04/15 ----------<<<<<
                                    this.ultraGrid1.AfterCellUpdate += this.ultraGrid1_AfterCellUpdate;
                                }
                            }
                        }

                        break;
                    }
                // --- ADD m.suzuki 2010/04/15 ---------->>>>>
                case "GoodsName":
                    {
                        // クリアされたら戻す
                        if ( string.IsNullOrEmpty( e.Cell.Value.ToString() ) )
                        {
                            this._stockMoveDataTable[e.Cell.Row.Index].GoodsName = this._beforeGoodsName.Trim();
                            return;
                        }

                        // 前回値と異なる場合はカナにもセット
                        if ( this._beforeGoodsName.Trim() != e.Cell.Value.ToString().Trim() )
                        {
                            // 全角⇒半角変換
                            string goodsNameKana = GetKanaString( e.Cell.Value.ToString() );

                            // ガ(1文字)⇒ｶﾞ(2文字)のような変換もあるので、長さをチェックする。
                            int kanaMaxLength = 40;
                            if ( goodsNameKana.Length > kanaMaxLength )
                            {
                                goodsNameKana = goodsNameKana.Substring(0, kanaMaxLength );
                            }
                            this._stockMoveDataTable[e.Cell.Row.Index].GoodsNameKana = goodsNameKana;
                        }

                        break;
                    }
                // --- ADD m.suzuki 2010/04/15 ----------<<<<<
                case "BLGoodsCode":
                    {
                        // BLコード
                        int blGoodsCode = ChangeCellValueToInt(this.ultraGrid1.ActiveCell.Value);
                        if (blGoodsCode != 0)
                        {
                            this.ultraGrid1.AfterCellUpdate -= this.ultraGrid1_AfterCellUpdate;
                            this.ultraGrid1.ActiveCell.Value = blGoodsCode.ToString("00000");
                            this.ultraGrid1.AfterCellUpdate += this.ultraGrid1_AfterCellUpdate;
                        }

                        break;
                    }
                //---ADD 2011/04/11----------------------------------------------------------->>>>>
                case "SupplierCd":
                    {
                        // 商品検索
                        GoodsUnitData goodsUnitData;
                        SupplierAcs supplierAcs = new SupplierAcs();
                        Supplier supplier;
                        string goodsNo = ChangeCellValueToString(this.ultraGrid1.Rows[rowIndex].Cells[_stockMoveInputAcs.StockMoveDataTable.GoodsNoColumn.ColumnName].Value);
                        int makerCode = ChangeCellValueToInt(this.ultraGrid1.Rows[rowIndex].Cells[_stockMoveInputAcs.StockMoveDataTable.GoodsMakerCdColumn.ColumnName].Value);
                        if (goodsNo != "")
                        {
                            SearchGoods(goodsNo, makerCode, out goodsUnitData);
                            goodsUnitData.SupplierCd = ChangeCellValueToInt(this.ultraGrid1.Rows[rowIndex].Cells[_stockMoveInputAcs.StockMoveDataTable.SupplierCdColumn.ColumnName].Value);
                            if (oldsupplierCd != goodsUnitData.SupplierCd)
                            {
                                int status_flag = supplierAcs.Read(out supplier, LoginInfoAcquisition.EnterpriseCode, goodsUnitData.SupplierCd);
                                // Redmine#21632 仕入先変更時、メッセージを追加します
                                //_stockMoveDataTable[rowIndex].StockUnitPriceFl = GetStockUnitPrice(goodsUnitData); //---DEL 2011/05/20
                                //_stockMoveDataTable[rowIndex].BfStockUnitPriceFl = GetStockUnitPrice(goodsUnitData); //---DEL 2011/05/20
                                //---ADD 2011/05/20---------------------->>>>>
                                DialogResult dialogResult = TMsgDisp.Show(
                                    this,
                                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                    this.Name,
                                    "仕入先が変更されました。" + "\r\n" + "\r\n" +
                                    "商品価格を再取得しますか？",
                                    -1,
                                    MessageBoxButtons.YesNo);
                                if (dialogResult == DialogResult.Yes)
                                {
                                    _stockMoveDataTable[rowIndex].StockUnitPriceFl = GetStockUnitPrice(goodsUnitData);
                                    _stockMoveDataTable[rowIndex].BfStockUnitPriceFl = GetStockUnitPrice(goodsUnitData);
                                }
                                //---ADD 2011/05/20----------------------<<<<<
                                if (status_flag == 0)
                                {
                                    _stockMoveDataTable[rowIndex].SupplierSnm = supplier.SupplierSnm;
                                }
                                else
                                {
                                    _stockMoveDataTable[rowIndex].SupplierSnm = "";
                                }
                                // oldsupplierCd = goodsUnitData.SupplierCd; //DEL 2011/05/26
                            }
                            this.TotalPriceSetting();
                        }
                        break;
                    }
                //---ADD 2011/04/11-----------------------------------------------------------<<<<<
                case "MovingSupliStock":
                    {
                        // 品番
                        string goodsNo = ChangeCellValueToString((this.ultraGrid1.Rows[rowIndex].Cells[_stockMoveInputAcs.StockMoveDataTable.GoodsNoColumn.ColumnName].Value));
                        if (goodsNo == "")
                        {
                            return;
                        }

                        // 更新したアクティブセルの行
                        StockMoveInputDataSet.StockMoveRow row = _stockMoveDataTable[rowIndex];

                        double movingSupliStock = 0;
                        if (this.ultraGrid1.ActiveCell.Value != DBNull.Value)
                        {
                            movingSupliStock = (double)this.ultraGrid1.ActiveCell.Value;
                        }

                        // 出庫前数
                        double bfBeforeMoveCount = ChangeCellValueToDouble(this.ultraGrid1.Rows[rowIndex].Cells[_stockMoveDataTable.BfBeforeMoveCountColumn.ColumnName].Value);
                        // --- ADD 2014/04/09 T.Miyamoto ------------------------------>>>>>
                        // 入庫前数
                        double afBeforeMoveCount = ChangeCellValueToDouble(this.ultraGrid1.Rows[rowIndex].Cells[_stockMoveDataTable.AfBeforeMoveCountColumn.ColumnName].Value);
                        // --- ADD 2014/04/09 T.Miyamoto ------------------------------<<<<<

                        bool stockExistFlg;
                        if (this.ultraGrid1.Rows[rowIndex].Cells[_stockMoveDataTable.StockMoveRowNoColumn.ColumnName].Tag == null)
                        {
                            stockExistFlg = false;
                        }
                        else
                        {
                            stockExistFlg = (bool)this.ultraGrid1.Rows[rowIndex].Cells[_stockMoveDataTable.StockMoveRowNoColumn.ColumnName].Tag;
                        }
                        if ((!this._saveFlg) && (stockExistFlg))
                        {
                            // 在庫切れ出荷区分チェック
                            int stockTolerncShipmDiv = this._stockMoveInputAcs.GetStockTolerncShipmDiv(LoginInfoAcquisition.Employee.BelongSectionCode);
                            switch (stockTolerncShipmDiv)
                            {
                                // 警告、警告＋再入力
                                case 1:
                                case 2:
                                    {
                                        if (movingSupliStock != 0)
                                        {
                                            if (movingSupliStock > bfBeforeMoveCount)
                                            {
                                                TMsgDisp.Show(this,
                                                            emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                                            this.Name,
                                                            "出庫数が在庫数を上回ります。",
                                                            -1,
                                                            MessageBoxButtons.OK);

                                                if (stockTolerncShipmDiv == 2)
                                                {
                                                    this.ultraGrid1.AfterCellUpdate -= this.ultraGrid1_AfterCellUpdate;
                                                    this.ultraGrid1.ActiveCell.Value = 0;
                                                    this.ultraGrid1.AfterCellUpdate += this.ultraGrid1_AfterCellUpdate;
                                                    this._movingSupliStockFlg = true;
                                                }
                                            }
                                        }
                                        break;
                                    }
                                case 3:
                                    {
                                        if (movingSupliStock != 0)
                                        {
                                            if (movingSupliStock > bfBeforeMoveCount)
                                            {
                                                this.ultraGrid1.AfterCellUpdate -= this.ultraGrid1_AfterCellUpdate;
                                                this.ultraGrid1.ActiveCell.Value = 0;
                                                this.ultraGrid1.AfterCellUpdate += this.ultraGrid1_AfterCellUpdate;
                                                this._movingSupliStockFlg = true;
                                            }
                                        }
                                        break;
                                    }
                            }
                            this.ultraGrid1.ActiveCell.Tag = movingSupliStock;
                        }

                        // 出庫後数
                        row.BfAfterMoveCount = (bfBeforeMoveCount - movingSupliStock).ToString("N");

                        // --- ADD 2014/04/09 T.Miyamoto ------------------------------>>>>>
                        // 入庫後数
                        row.AfAfterMoveCount = (afBeforeMoveCount + movingSupliStock).ToString("N");
                        // --- ADD 2014/04/09 T.Miyamoto ------------------------------<<<<<

                        // テーブルのコミット
                        _stockMoveDataTable.AcceptChanges();

                        // テーブル更新フラグをTrueにする。
                        this.tableUpdateFlg = true;

                        // 移動合計更新デリゲート
                        this.TotalPriceSetting();

                        break;
                    }
                case "StockUnitPriceFl":
                    {
                        // 移動合計更新デリゲート
                        this.TotalPriceSetting();

                        break;
                    }
                case "ListPriceFlView":
                    {
                        if (this.ultraGrid1.Rows[rowIndex].Cells[_stockMoveDataTable.ListPriceFlViewColumn.ColumnName].Text.Trim() == "オープン価格")
                        {
                            return;
                        }

                        // 標準価格
                        double listPriceFl = ChangeCellValueToDouble(this.ultraGrid1.Rows[rowIndex].Cells[_stockMoveDataTable.ListPriceFlViewColumn.ColumnName].Value);
                        if (listPriceFl == 0)
                        {
                            return;
                        }

                        this.ultraGrid1.AfterCellUpdate -= this.ultraGrid1_AfterCellUpdate;
                        this.ultraGrid1.ActiveCell.Value = listPriceFl.ToString("###,###");
                        this.ultraGrid1.AfterCellUpdate += this.ultraGrid1_AfterCellUpdate;
                        break;
                    }
            }
        }

        // --- ADD m.suzuki 2010/04/15 ---------->>>>>
        /// <summary>
        /// 全角⇒半角変換
        /// </summary>
        /// <param name="orgString"></param>
        /// <returns></returns>
        private string GetKanaString( string orgString )
        {
            // 全角⇒半角変換（途中に含まれる変換できない文字はそのまま）
            return Microsoft.VisualBasic.Strings.StrConv( orgString, Microsoft.VisualBasic.VbStrConv.Narrow, 0 );
        }
        // --- ADD m.suzuki 2010/04/15 ----------<<<<<

        /// <summary>
        /// BeforeCellActivate イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <br>Update Note: 2011/04/11 鄧潘ハン 明細に仕入先を追加する</br>
        /// <br>Update Note: 2011/05/26 朱俊成   Redmine#21733</br>
        private void ultraGrid1_BeforeCellActivate(object sender, CancelableCellEventArgs e)
        {
            // 項目に従いIMEモード設定
            this.ultraGrid1.ImeMode = this.uiSetControl1.GetSettingImeMode(e.Cell.Column.Key);

            // ゼロ詰め解除実行
            if (e.Cell.Column.DataType == typeof(string) &&
                e.Cell.StyleResolved == Infragistics.Win.UltraWinGrid.ColumnStyle.Edit)
            {
                if ((e.Cell.Value != DBNull.Value) && (e.Cell.Value != null))
                {
                    this.ultraGrid1.AfterCellUpdate -= this.ultraGrid1_AfterCellUpdate;
                    //---ADD 2011/04/11----------------------------------->>>>>
                    if (e.Cell.Column.Key == "SupplierCd")
                    {
                        if ((string)this.ultraGrid1.Rows[e.Cell.Row.Index].Cells[e.Cell.Column.Key].Value != string.Empty)
                        {
                            int SupplierCd = Convert.ToInt32((string)this.ultraGrid1.Rows[e.Cell.Row.Index].Cells[e.Cell.Column.Key].Value);
                            if (SupplierCd == 0)
                            {
                                this.ultraGrid1.Rows[e.Cell.Row.Index].Cells[e.Cell.Column.Key].Value = string.Empty;
                            }
                            else
                            {
                                this.ultraGrid1.Rows[e.Cell.Row.Index].Cells[e.Cell.Column.Key].Value = SupplierCd.ToString();
                            }
                            oldsupplierCd = System.Convert.ToInt32(this.ultraGrid1.Rows[e.Cell.Row.Index].Cells[e.Cell.Column.Key].Value); //ADD 2011/05/26
                        }
                        // ADD 2011/05/26  ------------------------->>>>>>
                        else
                        {
                            oldsupplierCd = 0;
                        }
                        // ADD 2011/05/26  -------------------------<<<<<<
                    }
                    else
                    {
                    //---ADD 2011/04/11-----------------------------------<<<<<
                        this.ultraGrid1.Rows[e.Cell.Row.Index].Cells[e.Cell.Column.Key].Value
                        = this.uiSetControl1.GetZeroPadCanceledText(e.Cell.Column.Key,
                          (string)this.ultraGrid1.Rows[e.Cell.Row.Index].Cells[e.Cell.Column.Key].Value);
                    }// ADD 2011/04/11
                    
                    this.ultraGrid1.AfterCellUpdate += this.ultraGrid1_AfterCellUpdate;
                }
            }

            // 標準価格の場合
            if (e.Cell.Column.Key == "ListPriceFlView")
            {
                if (e.Cell.Text.Trim() == "オープン価格")
                {
                    return;
                }

                // 標準価格
                double listPriceFl = ChangeCellValueToDouble(e.Cell.Text);
                if (listPriceFl == 0)
                {
                    return;
                }

                this.ultraGrid1.AfterCellUpdate -= this.ultraGrid1_AfterCellUpdate;
                e.Cell.Value = listPriceFl.ToString();
                this.ultraGrid1.AfterCellUpdate += this.ultraGrid1_AfterCellUpdate;
            }
        }
        // --- ADD 2008/07/14 ---------------------------------------------------------------------<<<<<
        // --- ADD m.suzuki 2010/04/15 ---------->>>>>
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ultraGrid1_BeforeCellUpdate( object sender, BeforeCellUpdateEventArgs e )
        {
            if ( e.Cell == null ) return;
            Infragistics.Win.UltraWinGrid.UltraGridCell cell = e.Cell;

            #region 品名
            //------------------------------------------------------------
            // ActiveCellが「品名」の場合
            //------------------------------------------------------------
            if ( cell.Column.Key == this._stockMoveDataTable.GoodsNameColumn.ColumnName )
            {
                this._beforeGoodsName = e.Cell.Value.ToString();
            }
            #endregion

        }
        // --- ADD m.suzuki 2010/04/15 ----------<<<<<

        // ---ADD 2010/11/15---------------->>>>>
        /// <summary>
        /// 新規入力時の保存実行後のフォーカスは、明細１行目の品番へ移動する
        /// </summary>
        /// <remarks>
        /// <br>Note       : 新規入力時の保存実行後のフォーカスは、明細１行目の品番へ移動する。</br>br>
        /// <br>Programer  : 曹文傑</br>
        /// <br>Date       : 2010/11/15<br/>
        /// </remarks>
        public void SetFocusAfterSave()
        {
            if (this.ultraGrid1.Rows.Count > 0)
            {
                this.ultraGrid1.Rows[0].Cells["GoodsNo"].Activate();
                this.ultraGrid1.PerformAction(UltraGridAction.EnterEditMode);
            }
        }
         // ---ADD 2011/05/10----------------<<<<<
        private void ultraGrid1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && this._sameGoodNoFlg)
            {
                this.ultraGrid1.Rows[_index].Cells[_key].Activate();
                this.ultraGrid1.PerformAction(UltraGridAction.EnterEditMode);
                this._sameGoodNoFlg = false;
            }
        }
           // ---ADD 2011/05/10----------------<<<<<
        // ---ADD 2010/11/15----------------<<<<<
    }
}