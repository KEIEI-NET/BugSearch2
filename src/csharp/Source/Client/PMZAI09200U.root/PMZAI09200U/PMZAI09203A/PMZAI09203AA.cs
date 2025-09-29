using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;

using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Resources;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 商品在庫一括登録修正アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 商品在庫一括登録修正のデータ取得、保存制御全般を行う。</br>
    /// <br>Programmer : 33045 上野 俊治</br>
    /// <br>Date       : 2008.12.22</br>
    /// <br></br>
    /// <br>Update Note: 2009.02.16 30452 上野 俊治</br>
    /// <br>            ・速度アップ対応</br>
    /// <br>Update Note: 2009.02.18 30452 上野 俊治</br>
    /// <br>            ・障害対応11649(エラー処理の修正、DataTable検索時大小文字を区別するよう修正)</br>
    /// <br>Update Note: 2009/02/19 30452 上野 俊治</br>
    /// <br>            ・障害対応11721(商品マスタ検索(ユーザ)の最大検索数を3200件に固定)</br>
    /// <br>Update Note: 2009/03/03 30452 上野 俊治</br>
    /// <br>            ・障害対応12104,12103,12081,12074,12075</br>
    /// <br>Update Note: 2009/03/05 30452 上野 俊治</br>
    /// <br>            ・障害対応12082,12070,12132,12073,12205</br>
    /// <br>Update Note: 2009/03/10 30452 上野 俊治</br>
    /// <br>            ・障害対応12080</br>
    /// <br>Update Note: 2009/03/10 30452 上野 俊治</br>
    /// <br>            ・障害対応12223</br>
    /// <br>Update Note: 2009/04/03 30452 上野 俊治</br>
    /// <br>            ・障害対応13070</br>
    /// <br>Update Note: 2010/01/08 30434 工藤 恵優</br>
    /// <br>            ・障害対応14861</br>
    /// <br>Update Note: 2010/08/31 高峰</br>
    /// <br>            ・redmine #13980</br>
    /// <br>Update Note: 2010/12/15 22008 長内 数馬</br>
    /// <br>            ・在庫マスタに存在するレコードが表示されない不具合の修正（森川部品様で発生）</br>
    /// <br>Update Note: 2011/07/22 連番916　王飛３</br>
    /// <br>            ・在庫マスタを新規作成する場合、修正したものだけでは無く明細にある全ての商品が在庫マスタに書き込まれてしまう、PM7と同じ仕様にする</br>
    /// <br>Update Note: 2011/08/03 王飛３</br>
    /// <br>            ・Redmine23379</br>
    /// <br>①在庫登録時に管理区分１・２が未入力の場合、コード０をセットして頂く様にしました。</br>
    /// <br>②管理区分マスタに登録の無いコードの入力があった際は、マスタの存在チェックを行わずに登録可能としました</br>
    /// <br>Update Note: 2011/08/23 wangf</br>
    /// <br>            ・Redmine23907</br>
    /// <br>            ・表示区分「新規登録」且つ対象区分「在庫」の場合は連番916の改修は反映される</br>
    /// <br>Update Note: 2011/10/17 30517 夏野 駿希</br>
    /// <br>            ・Mantis.17857　対象区分が『商品』の場合、現在庫数が倍になってしまう不具合の対応</br>
    /// <br>Update Note: 2011/12/31 徐秋華</br> 
    /// <br>管理番号     10707327-00 2012/01/25配信分</br> 							
    /// <br>             Redmine27530 商品在庫一括登録/「０円」の掛率データの登録</br> 										 
    /// <br>Update Note: 2012/09/11 yangmj 障害・改良対応（７月リリース案件）</br>
    /// <br>管理番号   : 10707327-00 PM1203G</br> 							
    /// <br>             Redmine32095 商品在庫一括登録修正で「全ての価格情報が消える」</br> 		 
    /// <br>Update Note: 2013/01/24 gezh </br>
    /// <br>             Redmine#33361 商品在庫一括登録修正のサーバー負荷軽減の修正</br>	
    /// <br>Update Note: 2013/03/18 yangyi</br>
    /// <br>管理番号   : 10801804-00 20150515配信分の対応</br>
    /// <br>           : Redmine#34962 　「商品在庫一括修正」のサーバー負荷軽減対応</br>
    /// <br>Update Note: 2013/04/25 yangyi</br>
    /// <br>管理番号   : 10801804-00 20150515配信分の対応</br>
    /// <br>           : Redmine#35018 　「商品在庫一括修正」のサーバー負荷軽減対応</br>
    /// <br>Update Note: 2013/05/11 yangyi</br>
    /// <br>管理番号   : 10801804-00 20150515配信分の対応</br>
    /// <br>           : Redmine#35018 「商品在庫一括修正」のサーバー負荷軽減　その２対応</br>
    /// <br>Update Note: 2015/01/14 田建委</br>
    /// <br>管理番号   : 11100008-00</br>
    /// <br>           : Redmine#44473 商品在庫一括登録修正にて在庫削除日が削除処理した日付になっていない対応</br>
    /// <br>Update Note: 2015/08/17 田建委</br>
    /// <br>管理番号   : 11170052-00</br>
    /// <br>           : Redmine#47036 商品在庫一括登録修正 管理拠点・倉庫の追加</br>
    /// </remarks>
    public class GoodsStockAcs
    {
        #region ■private定数
        // 掛率マスタの初期値
        private const string CT_UnitRateSetDivCd = "36A"; // 単価掛率設定区分
        private const string CT_UnitPriceKind = "3"; // 単価種類
        private const string CT_RateSettingDivide = "6A"; // 掛率設定区分
        private const string CT_RateMngGoodsCd = "A"; // 掛率設定区分（商品）
        private const string CT_RateMngGoodsNm = "ﾒｰｶｰ＋品番"; // 掛率設定名称（商品）
        private const string CT_RateMngCustCd = "6"; // 掛率設定区分（得意先）
        private const string CT_RateMngCustNm = "設定なし"; // 掛率設定名称（得意先）
        private const double CT_UnPrcFracProcUnit = 1; // 単価端数処理単位
        private const Int32 CT_UnPrcFracProcDiv = 2; // 単価端数処理区分
        private const double CT_LotCount = 9999999.99; // ロット数の初期値

        //private const Int32 CT_MaxSearchNum = 3200; // 最大検索数 // ADD 2009/02/19 DEL 2010/12/15
        private const Int32 CT_MaxSearchNum = 0; // 最大検索数 // ADD 2010/12/15
        #endregion

        #region ■private変数
        // 企業コード
        private string _enterpriseCode;
        // ログイン拠点コード
        private string _loginSectionCode;
        
        // 商品在庫一括登録修正アクセスクラス
        private static GoodsStockAcs _goodsStockAcs;
        // 商品マスタアクセス
        private GoodsAcs _goodsAcs;
        // 在庫マスタアクセス
        private SearchStockAcs _searchStockAcs;
        // 仕入先マスタアクセス
        private SupplierAcs _supplierAcs;
        // 倉庫マスタアクセス
        private WarehouseAcs _warehouseAcs;
        // BLコードマスタアクセス
        private BLGoodsCdAcs _blGoodsCdAcs;
        // 管理拠点ガイド
        private SecInfoSetAcs _secInfoSetAcs; // ADD 2009/03/10

        // 商品管理情報マスタアクセス
        private GoodsMngAcs _goodsMngAcs;
        // 掛率マスタアクセス
        private RateAcs _rateAcs;
        // 掛率優先管理マスタアクセス
        private RateProtyMngAcs _rateProtyMngAcs;

        // グリッド表示テーブル
        private GoodsStockDataSet _goodsStockDataSet;
        private GoodsStockDataSet.GoodsStockDataTable _goodsStockDataTable;
        private DataTable _originalGoodsStockDataTable; // 変更有無チェック用 検索時のデータ

        private List<GoodsUnitData> _originalGoodsUnitDataList; // 編集処理用商品連結データ
        // 掛率マスタ情報
        private List<Rate> _originalRateList;
        //// 掛率マスタ情報(全社設定で該当のあったもの)
        //private List<Rate> _originalAllSectionRateList; // DEL 2009/02/04 

        // 掛率優先管理情報有無フラグ(true:該当あり、false:該当なし)
        private bool _rateProtyMngFlg;

        //-----ADD 2011/08/03---------->>>>>
        private bool _noneflag = true;
        private bool _havenullsectionrow = false ;


        public bool NoneFlag
        {
            get { return _noneflag; }
    
        }

        public bool HaveNullSectionRow
        {
            get { return _havenullsectionrow; }

        }

        //-----ADD 2011/08/03----------<<<<<

        // --- ADD 2009/02/04 -------------------------------->>>>>
        // キャンセル処理フラグ
        private bool _cancelFlg;

        // BLコード名(半角)リスト
        private Dictionary<int, string> _blGoodsCdUMntList;
        // 発注先名称リスト
        private Dictionary<int, string> _supplierList;
        // --- ADD 2009/02/04 --------------------------------<<<<<
        private bool _outMaxCount = false;  // ADD gezh 2013/01/24 Redmine#33361「20000件」の改修案
        private Dictionary<string, SecInfoSet> _sectionDic;  // ADD gezh 2013/01/24 Redmine#33361 Client端の改修案①
        #endregion

        #region ■コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public GoodsStockAcs()
        {
            //this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode; // DEL 2009/02/04
            //this._loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode; // DEL 2009/02/04
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode.TrimEnd(); // ADD 2009/02/04
            this._loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode.TrimEnd(); // ADD 2009/02/04

            this._goodsAcs = new GoodsAcs();
            string msg;
            this._goodsAcs.SearchInitial(this._enterpriseCode, this._loginSectionCode, out msg);

            this._goodsMngAcs = new GoodsMngAcs();
            this._rateAcs = new RateAcs();
            this._rateProtyMngAcs = new RateProtyMngAcs();
            this._supplierAcs = new SupplierAcs();
            this._warehouseAcs = new WarehouseAcs();
            this._blGoodsCdAcs = new BLGoodsCdAcs();
            this._secInfoSetAcs = new SecInfoSetAcs(); // ADD 2009/03/10

            this._searchStockAcs = new SearchStockAcs();
            this._goodsStockDataSet = new GoodsStockDataSet();
            this._goodsStockDataTable = this._goodsStockDataSet.GoodsStock;
            this._originalGoodsStockDataTable = new DataTable();

            this._goodsStockDataTable.CaseSensitive = true; // ADD 2009.02.18
            this._originalGoodsStockDataTable.CaseSensitive = true; // ADD 2009.02.18

            this._originalRateList = new List<Rate>();
            //this._originalAllSectionRateList = new List<Rate>(); // DEL 2009/02/04

            this._rateProtyMngFlg = this.SearchRateProtyMng();

            this._cancelFlg = false; // ADD 2009/02/04
        }

        /// <summary>
        /// 在庫一括登録アクセスクラス インスタンス取得処理
        /// </summary>
        /// <returns>在庫一括登録アクセスクラス インスタンス</returns>
        public static GoodsStockAcs GetInstance()
        {
            if (_goodsStockAcs == null)
            {
                _goodsStockAcs = new GoodsStockAcs();
            }

            return _goodsStockAcs;
        }
        #endregion

        #region ■publicプロパティ
        /// <summary>
        /// 商品在庫データテーブルプロパティ
        /// </summary>
        public GoodsStockDataSet.GoodsStockDataTable GoodsStockDataTable
        {
            get { return _goodsStockDataTable; }
        }

        /// <summary>
        /// 検索時の商品在庫データテーブルプロパティ
        /// </summary>
        public DataTable OriginalGoodsStockDataTable
        {
            get { return _originalGoodsStockDataTable; }
        }

        /// <summary>
        /// 掛率優先管理情報の有無情報プロパティ
        /// </summary>
        public bool RateProtyMngExist
        {
            get { return this._rateProtyMngFlg; }
        }

        // --- ADD 2009/02/04 -------------------------------->>>>>
        /// <summary>
        /// キャンセルフラグプロパティ
        /// </summary>
        public bool CancelFlg
        {
            get { return this._cancelFlg; }
            set { this._cancelFlg = value; }
        }
        // --- ADD 2009/02/04 --------------------------------<<<<<
        // ADD gezh 2013/01/24 Redmine#33361 「20000件」の改修案 ----->>>>>
        /// <summary>
        /// 最大件数プロパティ
        /// </summary>
        public bool OutMaxCount
        {
            get { return this._outMaxCount; }
            set { this._outMaxCount = value; }
        }
        // ADD gezh 2013/01/24 Redmine#33361 「20000件」の改修案 -----<<<<<
        #endregion

        #region ■ publicメソッド

        #region ■ 検索処理
        /// <summary>
        /// 商品連結データ(提供分)検索処理
        /// </summary>
        /// <returns></returns>
        public int SearchOfferGoodsUnitData(ExtractInfo extractInfo, out string errMsg)
        {
            // 前回検索分を初期化
            this._goodsStockDataTable.Clear(); // ADD 2009/02/04
            _outMaxCount = false;  // ADD gezh 2013/01/24 Redmine#33361「20000件」の改修案
            errMsg = string.Empty;

            List<GoodsUnitData> goodsUnitDataList;
            PartsInfoDataSet partsInfoDataSet;

            // 抽出条件の作成
            GoodsCndtn goodsCndtn = new GoodsCndtn();

            goodsCndtn.EnterpriseCode = this._enterpriseCode;
            goodsCndtn.GoodsMakerCd = extractInfo.GoodsMakerCd;
            goodsCndtn.GoodsNo = extractInfo.GoodsNo;

            if (extractInfo.DisplayDiv == ExtractInfo.DisplayDivState.New)
            {
                goodsCndtn.BLGoodsCode = extractInfo.BLGoodsCode;
            }

            goodsCndtn.IsSettingSupplier = 1; // ADD 2009/02/16

            // 商品マスタ（提供データ）検索
            int status = this._goodsAcs.SearchPartsOfNonGoodsNo(goodsCndtn, out partsInfoDataSet, out goodsUnitDataList, out errMsg);

            if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                // --- DEL 2009/02/04 -------------------------------->>>>>
                #region 削除
                //// 提供データの選別
                //goodsUnitDataList = this.GetOfferGoodsUnitData(goodsUnitDataList);

                //if (goodsUnitDataList.Count != 0)
                //{
                //    // 商品連結データをGoodsStockテーブルに格納
                //    this.SetGoodsStockDataTableFromGoodsUnitDataList(goodsUnitDataList, extractInfo);

                //    // 行番号の設定
                //    this.SetRowNumber();

                //    // 検索時の商品連結データ情報を保持
                //    this._originalGoodsStockDataTable = this._goodsStockDataTable.Copy();
                //    this._originalGoodsUnitDataList = goodsUnitDataList;
                //}
                //else
                //{
                //    this._goodsStockDataTable.Clear();
                //    this._originalGoodsStockDataTable.Clear();
                //    this._originalGoodsUnitDataList = null;

                //    return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                //}
                #endregion
                // --- DEL 2009/02/04 --------------------------------<<<<<
                // --- ADD 2009/02/04 -------------------------------->>>>>

                // 掛率マスタも取得する
                int rateStat;
                ArrayList retList;

                // ログイン拠点での検索
                // 引数設定
                Rate rate = new Rate();
                rate.EnterpriseCode = this._enterpriseCode;
                rate.UnitPriceKind = CT_UnitPriceKind;
                rate.RateSettingDivide = CT_RateSettingDivide;
                rate.UnitRateSetDivCd = CT_UnitRateSetDivCd;

                rateStat = this._rateAcs.SearchAll(out retList, ref rate, out errMsg);

                if (rateStat == (int)ConstantManagement.DB_Status.ctDB_NORMAL
                    && retList != null
                    && retList.Count != 0)
                {
                    // --- DEL 2009/02/16 -------------------------------->>>>>
                    //foreach (Rate retRate in retList)
                    //{
                    //    this._originalRateList.Add(retRate);
                    //}
                    // --- DEL 2009/02/16 --------------------------------<<<<<
                    this._originalRateList = new List<Rate>((Rate[])retList.ToArray(typeof(Rate))); // ADD 2009/02/16
                }

                foreach (GoodsUnitData goodsUnitData in goodsUnitDataList)
                {
                    if (this._cancelFlg)
                    {
                        break;
                    }

                    // ユーザデータチェック
                    if(!this.CheckOfferGoodsUnitData(goodsUnitData))
                    {
                        continue;
                    }

                    // GoodsStockテーブルに格納
                    this.SetGoodsStockDataRow(goodsUnitData, null);
                }

                // --- ADD 2009/03/06 -------------------------------->>>>>
                // 品番、メーカー、倉庫でソート
                DataTable tmpTable = this._goodsStockDataTable.Copy();
                this._goodsStockDataTable.Clear();

                DataRow[] drList = tmpTable.Select("",
                    this._goodsStockDataTable.GoodsNoColumn.ColumnName + ", "
                    + this._goodsStockDataTable.GoodsMakerColumn.ColumnName + ", "
                    + this._goodsStockDataTable.WarehouseCodeColumn.ColumnName);

                foreach (DataRow dr in drList)
                {
                    // --- ADD yangyi 2013/03/18 for Redmine#34962 ------->>>>>>>>>>>
                    if (this._goodsStockDataTable.Rows.Count >= extractInfo.MaxCount)
                    {
                        break;
                    }
                    // --- ADD yangyi 2013/03/18 for Redmine#34962 -------<<<<<<<<<<<

                    this._goodsStockDataTable.ImportRow(dr);
                    // ADD gezh 2013/01/24 Redmine#33361 「20000件」の改修案 ----->>>>>
                    if (this._goodsStockDataTable.Rows.Count >= 20000)
                    {
                        _outMaxCount = true;
                        break;
                    }
                    // ADD gezh 2013/01/24 Redmine#33361 「20000件」の改修案 -----<<<<<
                }
                // --- ADD 2009/03/06 --------------------------------<<<<<

                // 行番号の設定
                //this.SetRowNumber();// DEL 2009/03/06
                this.SetRowNumber(extractInfo); // ADD 2009/03/06

                if (this._goodsStockDataTable.Rows.Count != 0)
                {
                    this._originalGoodsStockDataTable = this._goodsStockDataTable.Copy();
                    this._originalGoodsUnitDataList = goodsUnitDataList;
                }
                else
                {
                    this._goodsStockDataTable.Clear();
                    this._originalGoodsStockDataTable.Clear();
                    this._originalGoodsUnitDataList = null;

                    if (!this._cancelFlg) // ADD 2009/02/04
                    {
                        return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                    }
                }
                // --- ADD 2009/02/04 --------------------------------<<<<<

            }
            else if (status == (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN)
            {
                this._goodsStockDataTable.Clear();
                this._originalGoodsStockDataTable.Clear();
                this._originalGoodsUnitDataList = null;

                return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            }
            else
            {
                this._goodsStockDataTable.Clear();
                this._originalGoodsStockDataTable.Clear();
                this._originalGoodsUnitDataList = null;
            }

            return status;
        }

        /// <summary>
        /// 商品連結データ(ユーザー分)検索処理
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Update Note: 2015/08/17 田建委</br>
        /// <br>管理番号   : 11170052-00</br>
        /// <br>           : Redmine#47036 商品在庫一括登録修正 管理拠点・倉庫の追加</br>
        /// </remarks>
        public int SearchUserGoodsUnitData(ExtractInfo extractInfo, out string errMsg)
        {
            // 前回検索分を初期化
            this._goodsStockDataTable.Clear(); // ADD 2009/02/04
            _outMaxCount = false;  // ADD gezh 2013/01/24 Redmine#33361「20000件」の改修案
            errMsg = string.Empty;

            List<GoodsUnitData> goodsUnitDataList;

            // 抽出条件の作成
            GoodsCndtn goodsCndtn = new GoodsCndtn();

            goodsCndtn.EnterpriseCode = this._enterpriseCode;
            goodsCndtn.GoodsMakerCd = extractInfo.GoodsMakerCd;
            goodsCndtn.GoodsNo = extractInfo.GoodsNo;

            //----- ADD 2015/08/17 田建委 Redmine#47036 ---------->>>>>
            // 対象区分：在庫-商品/在庫の場合、管理拠点・倉庫を追加する
            if (extractInfo.TargetDiv == ExtractInfo.TargetDivState.StockGoods
               || extractInfo.TargetDiv == ExtractInfo.TargetDivState.Stock)
            {
                goodsCndtn.AddUpSectionCode = extractInfo.AddUpSectionCode;
                goodsCndtn.WarehouseCode = extractInfo.WarehouseCode;
            }
            //----- ADD 2015/08/17 田建委 Redmine#47036 ----------<<<<<

            if (extractInfo.TargetDiv == ExtractInfo.TargetDivState.Goods
                || extractInfo.TargetDiv == ExtractInfo.TargetDivState.GoodsStock)
            {
                goodsCndtn.GoodsMGroup = extractInfo.GoodsMGroup;
                goodsCndtn.BLGoodsCode = extractInfo.BLGoodsCode;
            }

            // 前方一致
            goodsCndtn.GoodsNoSrchTyp = 1;
            // 商品属性 (0,1両方)
            goodsCndtn.GoodsKindCode = 9; // ADD 2009/02/03

            goodsCndtn.IsSettingSupplier = 1; // ADD 2009/02/16

            int targetDiv = 0;
            switch (extractInfo.TargetDiv)
            {
                case ExtractInfo.TargetDivState.Goods:
                    targetDiv = 0;
                    break;
                case ExtractInfo.TargetDivState.GoodsStock:
                    targetDiv = 1;
                    break;
                case ExtractInfo.TargetDivState.StockGoods:
                    targetDiv = 2;
                    break;
                case ExtractInfo.TargetDivState.Stock:
                    targetDiv = 3;
                    break;
                default:
                    break;
            }

            // 検索 (論理削除データも取得する)
            //int status = this._goodsAcs.Search(goodsCndtn, ConstantManagement.LogicalMode.GetData01, out goodsUnitDataList, out errMsg); // DEL 2009/02/19
            //int status = this._goodsAcs.Search(goodsCndtn, CT_MaxSearchNum, ConstantManagement.LogicalMode.GetData01, out goodsUnitDataList, out errMsg); // ADD 2009/02/19 //DEL yangyi 2013/03/18 Redmine#34962 
            int status = this._goodsAcs.Search(goodsCndtn, extractInfo.MaxCount, targetDiv, ConstantManagement.LogicalMode.GetData01, out goodsUnitDataList, out errMsg); //ADD yangyi 2013/03/18 Redmine#34962 

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // --- DEL 2009/02/04 -------------------------------->>>>>
                #region 削除
                //if (goodsUnitDataList.Count != 0)
                //{
                //    // 対象区分の反映
                //    if (extractInfo.DisplayDiv == ExtractInfo.DisplayDivState.Update
                //        &&
                //        (extractInfo.TargetDiv == ExtractInfo.TargetDivState.Stock
                //        || extractInfo.TargetDiv == ExtractInfo.TargetDivState.StockGoods)
                //        )
                //    {
                //        // 抽出条件「倉庫コード」「計上拠点」の反映
                //        this.FilterGoodsUnitDataByExtractInfo(goodsUnitDataList, extractInfo);

                //        // 「修正登録」、対象区分が「在庫」「在庫-商品」の場合
                //        // 商品が論理削除でなく、在庫登録があるデータのみ表示
                //        this.FilterGoodsUnitDataByExistGoods(goodsUnitDataList);
                //    }
                //    else if (extractInfo.DisplayDiv == ExtractInfo.DisplayDivState.New
                //        && extractInfo.TargetDiv == ExtractInfo.TargetDivState.Stock)
                //    {
                //        // 「新規登録」、対象区分が「在庫」「在庫-商品」の場合
                //        // 商品が論理削除でなく、在庫登録がないデータのみ表示
                //        this.FilterGoodsUnitDataByNoGoods(goodsUnitDataList);
                //    }

                //    if (goodsUnitDataList.Count == 0)
                //    {
                //        this._goodsStockDataTable.Clear();
                //        this._originalGoodsStockDataTable.Clear();
                //        this._originalGoodsUnitDataList = null;
                //        return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                //    }

                //    // 商品連結データをGoodsStockテーブルに格納
                //    this.SetGoodsStockDataTableFromGoodsUnitDataList(goodsUnitDataList, extractInfo);

                //    // 出力指定の反映 (掛率マスタを参照する為、GoodsStockテーブル作成後にフィルタ処理を行う)
                //    if (extractInfo.DisplayDiv == ExtractInfo.DisplayDivState.Update
                //        && extractInfo.TargetDiv != ExtractInfo.TargetDivState.Stock)
                //    {
                //        this.FilterGoodsUnitDataByOutputDiv(extractInfo);
                //    }

                //    if (this._goodsStockDataTable.Rows.Count == 0)
                //    {
                //        this._goodsStockDataTable.Clear();
                //        this._originalGoodsStockDataTable.Clear();
                //        this._originalGoodsUnitDataList = null;
                //        return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                //    }

                //    // 行番号の設定
                //    this.SetRowNumber();

                //    // 検索時の商品連結データ情報を保持
                //    this._originalGoodsStockDataTable = this._goodsStockDataTable.Copy();
                //    this._originalGoodsUnitDataList = goodsUnitDataList;
                //}
                //else
                //{
                //    this._goodsStockDataTable.Clear();
                //    this._originalGoodsStockDataTable.Clear();
                //    this._originalGoodsUnitDataList = null;

                //    return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                //}
                #endregion
                // --- DEL 2009/02/04 --------------------------------<<<<<
                // --- ADD 2009/02/04 -------------------------------->>>>>

                // 掛率マスタも取得する
                int rateStat;
                ArrayList retList;

                // ログイン拠点での検索
                // 引数設定
                Rate rate = new Rate();
                rate.EnterpriseCode = this._enterpriseCode;
                rate.UnitPriceKind = CT_UnitPriceKind;
                rate.RateSettingDivide = CT_RateSettingDivide;
                rate.UnitRateSetDivCd = CT_UnitRateSetDivCd;

                rateStat = this._rateAcs.SearchAll(out retList, ref rate, out errMsg);

                if (rateStat == (int)ConstantManagement.DB_Status.ctDB_NORMAL
                    && retList != null
                    && retList.Count != 0)
                {
                    // --- DEL 2009/02/16 -------------------------------->>>>>
                    //foreach (Rate retRate in retList)
                    //{
                    //    this._originalRateList.Add(retRate);
                    //}
                    // --- DEL 2009/02/16 --------------------------------<<<<<
                    this._originalRateList = new List<Rate>((Rate[])retList.ToArray(typeof(Rate))); // ADD 2009/02/16
                }

                foreach (GoodsUnitData goodsUnitData in goodsUnitDataList)
                {
                    if (this._cancelFlg)
                    {
                        break;
                    }

                    if (extractInfo.DisplayDiv == ExtractInfo.DisplayDivState.New
                        && extractInfo.TargetDiv == ExtractInfo.TargetDivState.Stock)
                    {
                        // 表示区分「新規登録」、対象区分「在庫」
                        //if (!this.CheckGoodsUnitDataByNoGoods(goodsUnitData)) // DEL 2009/03/10
                        if (!this.FilterGoodsUnitDataForNewStock(goodsUnitData, extractInfo)) // ADD 2009/03/10
                        {
                            continue;
                        }
                    }
                    else if (extractInfo.DisplayDiv == ExtractInfo.DisplayDivState.Update
                        &&
                        (extractInfo.TargetDiv == ExtractInfo.TargetDivState.Stock
                        || extractInfo.TargetDiv == ExtractInfo.TargetDivState.StockGoods)
                        )
                    {
                        // 表示区分「修正登録」、対象区分「在庫」または「在庫商品」
                        // 抽出条件「倉庫コード」「計上拠点」の反映
                        this.FilterGoodsUnitDataByExtractInfo(goodsUnitData, extractInfo);

                        // 商品が論理削除でなく、在庫登録があるデータのみ表示
                        if (!this.FilterGoodsUnitDataByExistGoods(goodsUnitData))
                        {
                            continue;
                        }
                    }

                    // 商品連結データをGoodsStockテーブルに格納
                    if (extractInfo.TargetDiv != ExtractInfo.TargetDivState.Goods
                    &&
                    (goodsUnitData.StockList != null && goodsUnitData.StockList.Count != 0)
                    )
                    {
                        // 対象区分「商品-在庫」、「在庫-商品」で在庫リストが存在する場合
                        for (int j = 0; j < goodsUnitData.StockList.Count; j++)
                        {
                            // レコードは在庫単位で作成
                            Stock stock = goodsUnitData.StockList[j];

                            this.SetGoodsStockDataRow(goodsUnitData, stock);
                        }
                    }
                    else
                    {
                        // 対象区分「商品」または在庫リストが存在しない
                        this.SetGoodsStockDataRow(goodsUnitData, null);
                    }
                }

                // 出力指定の反映 (掛率マスタを参照する為、GoodsStockテーブル作成後にフィルタ処理を行う)
                if (extractInfo.DisplayDiv == ExtractInfo.DisplayDivState.Update
                    && extractInfo.TargetDiv != ExtractInfo.TargetDivState.Stock)
                {
                    this.FilterGoodsUnitDataByOutputDiv(extractInfo);
                }

                // --- ADD 2009/03/06 -------------------------------->>>>>
                // 品番、メーカー、倉庫でソート
                DataTable tmpTable = this._goodsStockDataTable.Copy();
                this._goodsStockDataTable.Clear();

                DataRow[] drList = tmpTable.Select("",
                    this._goodsStockDataTable.GoodsNoColumn.ColumnName + ", "
                    + this._goodsStockDataTable.GoodsMakerColumn.ColumnName + ", "
                    + this._goodsStockDataTable.WarehouseCodeColumn.ColumnName);

                foreach (DataRow dr in drList)
                {
                    // --- ADD yangyi 2013/03/18 for Redmine#34962 ------->>>>>>>>>>>
                    // --- DEL yangyi 2013/04/25 for Redmine#35018 ------->>>>>>>>>>>
                    //if (extractInfo.TargetDiv != ExtractInfo.TargetDivState.GoodsStock
                    //    && this._goodsStockDataTable.Rows.Count >= extractInfo.MaxCount)
                    // --- DEL yangyi 2013/04/25 for Redmine#35018 -------<<<<<<<<<<<
                    // --- ADD yangyi 2013/04/25 for Redmine#35018 ------->>>>>>>>>>>
                    if (this._goodsStockDataTable.Rows.Count >= extractInfo.MaxCount)
                    // --- ADD yangyi 2013/04/25 for Redmine#35018 -------<<<<<<<<<<<
                    {
                         break;
                    }
                    // --- ADD yangyi 2013/03/18 for Redmine#34962 -------<<<<<<<<<<<


                    this._goodsStockDataTable.ImportRow(dr);

                    // ADD gezh 2013/01/24 Redmine#33361 「20000件」の改修案 ----->>>>>
                    if (this._goodsStockDataTable.Rows.Count >= 20000)
                    {
                        _outMaxCount = true;
                        break;
                    }
                    // ADD gezh 2013/01/24 Redmine#33361 「20000件」の改修案 -----<<<<<
                }
                // --- ADD 2009/03/06 --------------------------------<<<<<

                // 行番号の設定
                //this.SetRowNumber(); // DEL 2009/03/06
                this.SetRowNumber(extractInfo); // ADD 2009/03/06

                if (this._goodsStockDataTable.Rows.Count != 0)
                {
                    this._originalGoodsStockDataTable = this._goodsStockDataTable.Copy();
                    this._originalGoodsUnitDataList = goodsUnitDataList;
                }
                else
                {
                    this._goodsStockDataTable.Clear();
                    this._originalGoodsStockDataTable.Clear();
                    this._originalGoodsUnitDataList = null;

                    if (!this._cancelFlg) // ADD 2009/02/04
                    {
                        return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                    }
                }
                // --- ADD 2009/02/04 --------------------------------<<<<<
            }
            else
            {
                this._goodsStockDataTable.Clear();
                this._originalGoodsStockDataTable.Clear();
                this._originalGoodsUnitDataList = null;
            }

            return status;
        }

        
        #endregion

        #region ■ 保存処理
        /// <summary>
        /// DB更新処理
        /// </summary>
        /// <param name="beforeExtractInfo">前回検索時の抽出条件</param>
        /// <param name="newExtractInfo">保存ボタン押下時の抽出条件</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Update Note: 2013/05/11 yangyi</br>
        /// <br>管理番号   : 10801804-00 20150515配信分の対応</br>
        /// <br>           : Redmine#35018 「商品在庫一括修正」のサーバー負荷軽減　その２対応</br>
        /// </remarks>
        public int Write(ExtractInfo beforeExtractInfo, ExtractInfo newExtractInfo, out string msg)
        {
            // Write処理全体のステータス(一つでもエラーがあればエラーを返す)
            int writeStatus = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            msg = string.Empty;
            int methodRes = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;

            GoodsUnitData goodsUnitData;
            List<Stock> prevStockList;
            List<Rate> rateList;

            List<GoodsUnitData> errGoodsUnitDataList = new List<GoodsUnitData>();

            // 処理済(正常)商品キーdictionary(更新は商品連結データ単位のため)
            //Dictionary<string, int> finishKeyDic = new Dictionary<string, int>(); // DEL 2009/02/04
            Dictionary<string, List<int>> finishKeyDic = new Dictionary<string, List<int>>(); // ADD 2009/02/04

            // 処理済(エラー)商品キーdictionary(更新は商品連結データ単位のため)
            Dictionary<string, List<int>> errKeyDic = new Dictionary<string, List<int>>(); // ADD 2009.02.18

            int count = 0;// ADD 2011/07/22
            // goodsStockテーブル1行ずつ更新処理
            _noneflag = true;// ADD 2011/08/03
            _havenullsectionrow = false;// ADD 2011/08/03
            foreach (DataRow dr in this._goodsStockDataTable.Rows)
            {
                /* --- DEL 2011/08/23 ----->>>>>
                 //--- ADD 2011/07/22 -----<<<<<
                // --- ADD 2011/08/03 -----<<<<<
                if (dr[4].ToString()  == "1" )
                {
                    count++;
                    continue;
                }
                // --- ADD 2011/08/03 -----<<<<<
                bool ComparerRowFlag = true;
                if (string.IsNullOrEmpty(dr[this._goodsStockDataTable.SectionCodeColumn.ColumnName].ToString()))
                {
                    _havenullsectionrow = true;// ADD 2011/08/03
                    DataRow originalDr = _originalGoodsStockDataTable.Rows[count];
                    for (int i = 0; i < this._goodsStockDataTable.Columns.Count; i++)
                    {              
                        if (!((originalDr[i]).ToString()).Equals(((dr[i]).ToString())))
                        {
                            ComparerRowFlag = false;
                            _noneflag = false;// ADD 2011/08/03
                            break;
                        }
                    }
                }

                count++;
                if (ComparerRowFlag == true && string.IsNullOrEmpty(dr[this._goodsStockDataTable.SectionCodeColumn.ColumnName].ToString()))
                    continue;

                // --- ADD 2011/07/22 -----<<<<<
                // --- DEL 2011/08/23 ----<<<<<*/
                // --- ADD 2011/08/23 ----->>>>>
                // 表示区分「新規登録」且つ対象区分「在庫」の場合は連番916の改修は反映される
                if (beforeExtractInfo.DisplayDiv == ExtractInfo.DisplayDivState.New && beforeExtractInfo.TargetDiv == ExtractInfo.TargetDivState.Stock)
                {
                    if (dr[4].ToString() == "1")
                    {
                        count++;
                        continue;
                    }
                    bool ComparerRowFlag = true;
                    if (string.IsNullOrEmpty(dr[this._goodsStockDataTable.SectionCodeColumn.ColumnName].ToString()))
                    {
                        _havenullsectionrow = true;
                        DataRow originalDr = _originalGoodsStockDataTable.Rows[count];
                        for (int i = 0; i < this._goodsStockDataTable.Columns.Count; i++)
                        {
                            if (!((originalDr[i]).ToString()).Equals(((dr[i]).ToString())))
                            {
                                ComparerRowFlag = false;
                                _noneflag = false;
                                break;
                            }
                        }
                    }

                    count++;
                    if (ComparerRowFlag == true && string.IsNullOrEmpty(dr[this._goodsStockDataTable.SectionCodeColumn.ColumnName].ToString()))
                        continue;
                }
                // --- ADD 2011/08/23 -----<<<<<

                // 1商品連結データの更新結果ステータス
                int dbUpdateStatus = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

                // 処理済み商品チェック
                // --- DEL 2009/02/04 -------------------------------->>>>>
                //if (finishKeyDic.ContainsKey(dr[this._goodsStockDataTable.GoodsNoColumn.ColumnName].ToString()))
                //{
                //    if (finishKeyDic[dr[this._goodsStockDataTable.GoodsNoColumn.ColumnName].ToString()]
                //        == (int)dr[this._goodsStockDataTable.GoodsMakerColumn.ColumnName])
                //    {
                //        // 処理済
                //        continue;
                //    }
                //}
                // --- DEL 2009/02/04 --------------------------------<<<<<
                //----- ADD 2013/05/11 yangyi Redmine#35018の#53-No.7 ----->>>>>
                if (string.IsNullOrEmpty(dr[this._goodsStockDataTable.GoodsNameColumn.ColumnName].ToString()))
                {
                    continue;
                }
                //----- ADD 2013/05/11 yangyi Redmine#35018の#53-No.7 -----<<<<<
                // --- ADD 2009/02/04 -------------------------------->>>>>
                if (finishKeyDic.ContainsKey(dr[this._goodsStockDataTable.GoodsNoColumn.ColumnName].ToString()))
                {
                    if (finishKeyDic[dr[this._goodsStockDataTable.GoodsNoColumn.ColumnName].ToString()]
                        .Contains((int)dr[this._goodsStockDataTable.GoodsMakerColumn.ColumnName]))
                    {
                        // --- ADD 2009.02.18 -------------------------------->>>>>
                        // 処理済(正常)
                        // エラーフラグ
                        dr[this._goodsStockDataTable.UpdateErrFlgColumn.ColumnName] = 0;
                        // --- ADD 2009.02.18 --------------------------------<<<<<

                        continue;
                    }
                }
                // --- ADD 2009/02/04 --------------------------------<<<<<

                // --- ADD 2009.02.18 -------------------------------->>>>>
                if (errKeyDic.ContainsKey(dr[this._goodsStockDataTable.GoodsNoColumn.ColumnName].ToString()))
                {
                    if (errKeyDic[dr[this._goodsStockDataTable.GoodsNoColumn.ColumnName].ToString()]
                        .Contains((int)dr[this._goodsStockDataTable.GoodsMakerColumn.ColumnName]))
                    {
                        // 処理済(エラー)
                        // エラーフラグ
                        dr[this._goodsStockDataTable.UpdateErrFlgColumn.ColumnName] = 1;

                        continue;
                    }
                }
                // --- ADD 2009.02.18 --------------------------------<<<<<

                // 更新用データリストを取得
                methodRes = this.SetGoodsUnitDataListFromGoodsStockDataTable(dr, out goodsUnitData, out prevStockList, out rateList, beforeExtractInfo, newExtractInfo);

                try
                {
                    if (methodRes == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                    {
                        if (beforeExtractInfo.DisplayDiv == ExtractInfo.DisplayDivState.Update
                            && goodsUnitData.LogicalDeleteCode == 1)
                        {
                            // 商品連結データ論理削除
                            dbUpdateStatus = this._goodsAcs.Delete(ref goodsUnitData, prevStockList, ref rateList, out msg);
                        }
                        else
                        {
                            // 商品連結データ更新(在庫の論理削除もこちら)
                            dbUpdateStatus = this._goodsAcs.Write(ref goodsUnitData, prevStockList, ref rateList, out msg);
                        }
                    }
                }
                catch
                {
                    dbUpdateStatus = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                }

                // --- DEL 2009.02.18 -------------------------------->>>>>
                //// 処理済みのキー値を保存
                //if (goodsUnitData != null)
                //{
                //    //finishKeyDic.Add(goodsUnitData.GoodsNo, goodsUnitData.GoodsMakerCd); // DEL 2009/02/04
                //    // --- ADD 2009/02/04 -------------------------------->>>>>
                //    if (finishKeyDic.ContainsKey(goodsUnitData.GoodsNo))
                //    {
                //        finishKeyDic[goodsUnitData.GoodsNo].Add(goodsUnitData.GoodsMakerCd);
                //    }
                //    else
                //    {
                //        List<int> goodsMakerCdList = new List<int>();
                //        goodsMakerCdList.Add(goodsUnitData.GoodsMakerCd);

                //        finishKeyDic.Add(goodsUnitData.GoodsNo, goodsMakerCdList);
                //    }
                //    // --- ADD 2009/02/04 --------------------------------<<<<<

                //    // MethodResult.ctFNC_CANCELは既論理削除行等、更新が必要ない行なのでエラーではない
                //    if ((methodRes != (int)ConstantManagement.MethodResult.ctFNC_NORMAL
                //        && methodRes != (int)ConstantManagement.MethodResult.ctFNC_CANCEL)
                //        || dbUpdateStatus != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                //    {
                //        // エラー行の情報を残す
                //        errGoodsUnitDataList.Add(goodsUnitData.Clone());

                //        writeStatus = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                //    }
                //}
                // --- DEL 2009.02.18 --------------------------------<<<<<
                // --- ADD 2009.02.18 -------------------------------->>>>>
                if ((methodRes != (int)ConstantManagement.MethodResult.ctFNC_NORMAL
                        && methodRes != (int)ConstantManagement.MethodResult.ctFNC_CANCEL)
                        || dbUpdateStatus != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // 処理済(エラー)キーの保存
                    if (errKeyDic.ContainsKey(dr[this._goodsStockDataTable.GoodsNoColumn.ColumnName].ToString()))
                    {
                        errKeyDic[dr[this._goodsStockDataTable.GoodsNoColumn.ColumnName].ToString()]
                            .Add((int)dr[this._goodsStockDataTable.GoodsMakerColumn.ColumnName]);
                    }
                    else
                    {
                        List<int> goodsMakerCdList = new List<int>();
                        goodsMakerCdList.Add((int)dr[this._goodsStockDataTable.GoodsMakerColumn.ColumnName]);

                        errKeyDic.Add(dr[this._goodsStockDataTable.GoodsNoColumn.ColumnName].ToString(), goodsMakerCdList);
                    }

                    // エラーフラグ
                    dr[this._goodsStockDataTable.UpdateErrFlgColumn.ColumnName] = 1;
                    
                    // --- ADD 2009/03/10 -------------------------------->>>>>
                    // エラーメッセージ
                    if (!string.IsNullOrEmpty(msg))
                    {
                        msg = msg.Replace("\r\n", string.Empty);
                        dr[this._goodsStockDataTable.ErrorMessageColumn.ColumnName] = msg + " (ST = " + dbUpdateStatus + ")"; // ADD 2009/03/10
                    }
                    else
                    {
                        // 予期しないエラー
                        dr[this._goodsStockDataTable.ErrorMessageColumn.ColumnName] = "保存処理にて例外が発生しました" + " (ST = " + dbUpdateStatus + ")"; // ADD 2009/03/10
                    }
                    // --- ADD 2009/03/10 --------------------------------<<<<<

                    // 1件でもエラーがあればエラーを返す
                    writeStatus = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                }
                else
                {
                    // 処理済(正常)キーの保存
                    if (finishKeyDic.ContainsKey(dr[this._goodsStockDataTable.GoodsNoColumn.ColumnName].ToString()))
                    {
                        finishKeyDic[dr[this._goodsStockDataTable.GoodsNoColumn.ColumnName].ToString()]
                            .Add((int)dr[this._goodsStockDataTable.GoodsMakerColumn.ColumnName]);
                    }
                    else
                    {
                        List<int> goodsMakerCdList = new List<int>();
                        goodsMakerCdList.Add((int)dr[this._goodsStockDataTable.GoodsMakerColumn.ColumnName]);

                        finishKeyDic.Add(dr[this._goodsStockDataTable.GoodsNoColumn.ColumnName].ToString(), goodsMakerCdList);
                    }

                    // エラーフラグ
                    dr[this._goodsStockDataTable.UpdateErrFlgColumn.ColumnName] = 0;
                }
                // --- ADD 2009.02.18 --------------------------------<<<<<
            }

            #region ■エラー処理
            if (writeStatus != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // --- DEL 2009.02.18 -------------------------------->>>>>
                // エラー行がある場合、グリッドをクリアしないのでデータの詰替えを行う
                //DataTable originalBackUp = this._originalGoodsStockDataTable.Copy();
                //this._originalGoodsStockDataTable.Clear();

                //foreach (DataRow dr in this._goodsStockDataTable.Rows)
                //{
                //    bool isErrGoods = false;

                //    foreach (GoodsUnitData errGoodsUnitData in errGoodsUnitDataList)
                //    {

                //        // エラー行の判別
                //        if (dr[this._goodsStockDataTable.GoodsNoColumn.ColumnName].ToString() == errGoodsUnitData.GoodsNo
                //            && (int)dr[this._goodsStockDataTable.GoodsMakerColumn.ColumnName] == errGoodsUnitData.GoodsMakerCd)
                //        {
                //            isErrGoods = true;
                //            break;
                //        }
                //    }

                //    if (isErrGoods)
                //    {
                //        // エラー行の場合、更新元データからDataRowを取得
                //        foreach (DataRow backupDr in originalBackUp.Rows)
                //        {
                //            if (backupDr[this._goodsStockDataTable.GoodsNoColumn.ColumnName].ToString() == dr[this._goodsStockDataTable.GoodsNoColumn.ColumnName].ToString()
                //                && (int)backupDr[this._goodsStockDataTable.GoodsMakerColumn.ColumnName] == (int)dr[this._goodsStockDataTable.GoodsMakerColumn.ColumnName])
                //            {
                //                if (
                //                    (backupDr[this._goodsStockDataTable.WarehouseCodeColumn.ColumnName] == null
                //                    || backupDr[this._goodsStockDataTable.WarehouseCodeColumn.ColumnName] == DBNull.Value)
                //                    ||
                //                    backupDr[this._goodsStockDataTable.WarehouseCodeColumn.ColumnName].ToString() == dr[this._goodsStockDataTable.WarehouseCodeColumn.ColumnName].ToString()
                //                    )
                //                {
                //                    // エラー行の場合、エラーフラグ = 1
                //                    dr[this._goodsStockDataTable.UpdateErrFlgColumn.ColumnName] = 1;
                //                    this._originalGoodsStockDataTable.ImportRow(backupDr);

                //                    break;
                //                }
                //            }
                //        }
                //    }
                //    else
                //    {
                //        // 正常処理行の場合、エラーフラグ = 0
                //        dr[this._goodsStockDataTable.UpdateErrFlgColumn.ColumnName] = 0;
                //        this._originalGoodsStockDataTable.ImportRow(dr);
                //    }
                //}
                // --- DEL 2009.02.18 --------------------------------<<<<<
                // --- ADD 2009.02.18 -------------------------------->>>>>
                // エラー行がある場合、グリッドをクリアしないのでデータの詰替えを行う
                DataTable originalBackUp = this._originalGoodsStockDataTable.Copy();
                this._originalGoodsStockDataTable.Clear();

                foreach (DataRow dr in this._goodsStockDataTable.Rows)
                {
                    if ((int)dr[this._goodsStockDataTable.UpdateErrFlgColumn.ColumnName] == 0)
                    {
                        // 正常行
                        this._originalGoodsStockDataTable.ImportRow(dr);
                    }
                    else
                    {
                        // エラー行
                        //if (dr[this._goodsStockDataTable.RowNumberColumn.ColumnName].ToString() != "新規") // DEL 2009/03/06
                        if (dr[this._goodsStockDataTable.RowIndexColumn.ColumnName].ToString() != "新規") // ADD 2009/03/06
                        {
                            DataRow[] backupDr = originalBackUp.Select(
                                //this._goodsStockDataTable.RowNumberColumn.ColumnName + " = '" + dr[this._goodsStockDataTable.RowNumberColumn.ColumnName].ToString() + "'"); // DEL 2009/03/06
                                this._goodsStockDataTable.RowIndexColumn.ColumnName + " = '" + dr[this._goodsStockDataTable.RowIndexColumn.ColumnName].ToString() + "'"); // ADD 2009/03/06

                            if (backupDr.Length != 0)
                            {
                                this._originalGoodsStockDataTable.ImportRow(backupDr[0]);
                            }
                        }
                    }
                }
                // --- ADD 2009.02.18 --------------------------------<<<<<
            }

            #endregion

            if (writeStatus == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // 掛率リストは更新後再取得が必要なのでクリア
                this._originalRateList.Clear(); // ADD 2009/02/03
            }

            return writeStatus;
        }

        #endregion

        #region ■ 完全削除処理
        /// <summary>
        /// 商品完全削除処理
        /// </summary>
        /// <returns></returns>
        public int GoodsCompleteDelete(string goodsNo, int goodsMakerCd)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            string msg;

            // 更新用商品連結リストから同商品のデータを取得
            GoodsUnitData goodsUnitData = this.GetOriginalGoodsUnitData(goodsNo, goodsMakerCd);

            status = this._goodsAcs.CompleteDelete(goodsUnitData, out msg);

            return status;
        }

        /// <summary>
        /// 在庫完全削除処理
        /// </summary>
        /// <returns></returns>
        public int StockCompleteDelete(string goodsNo, int goodsMakerCd, string warehouseCd)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            string msg;

            // 更新用商品連結リストから同商品のデータを取得
            GoodsUnitData goodsUnitData = this.GetOriginalGoodsUnitData(goodsNo, goodsMakerCd);

            // prevStockリストを作成
            List<Stock> prevStockList = new List<Stock>(); // ADD 2009/03/10

            // 倉庫コードに該当する在庫情報を取得
            foreach (Stock stock in goodsUnitData.StockList)
            {
                prevStockList.Add(stock.Clone()); // ADD 2009/03/10

                if (stock.WarehouseCode == warehouseCd)
                {
                    stock.LogicalDeleteCode = 3;
                }
            }

            List<Rate> rateList = new List<Rate>();

            //status = this._goodsAcs.Write(ref goodsUnitData, out msg); // DEL 2009/03/10
            status = this._goodsAcs.Write(ref goodsUnitData, prevStockList, ref rateList, out msg); // ADD 2009/03/10

            return status;
        }
        #endregion

        #region ■ 復活処理
        /// <summary>
        /// 商品復活処理
        /// </summary>
        /// <returns></returns>
        public int GoodsRevive(string goodsNo, int goodsMakerCd)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            string msg;

            // 更新用商品連結リストから同商品のデータを取得
            GoodsUnitData goodsUnitData = this.GetOriginalGoodsUnitData(goodsNo, goodsMakerCd);

            status = this._goodsAcs.Revival(ref goodsUnitData, out msg);

            return status;
        }

        /// <summary>
        /// 在庫復活処理
        /// </summary>
        /// <returns></returns>
        public int StockRevive(string goodsNo, int goodsMakerCd, string warehouseCd)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            string msg;

            // 更新用商品連結リストから同商品のデータを取得
            GoodsUnitData goodsUnitData = this.GetOriginalGoodsUnitData(goodsNo, goodsMakerCd);

            // prevStockリストを作成
            List<Stock> prevStockList = new List<Stock>(); // ADD 2009/04/03

            // 倉庫コードに該当する在庫情報を取得
            foreach (Stock stock in goodsUnitData.StockList)
            {
                prevStockList.Add(stock.Clone()); // ADD 2009/04/03

                if (stock.WarehouseCode == warehouseCd)
                {
                    stock.LogicalDeleteCode = 0;
                }
            }

            List<Rate> rateList = new List<Rate>(); // ADD 2009/04/03

            //status = this._goodsAcs.Write(ref goodsUnitData, out msg); // DEL 2009/04/03
            status = this._goodsAcs.Write(ref goodsUnitData, prevStockList, ref rateList, out msg); // ADD 2009/04/03

            return status;
        }

        #endregion

        #region ■ キー重複チェック
        /// <summary>
        /// キー重複チェックを行う
        /// </summary>
        /// <param name="goodsNo">品番</param>
        /// <param name="makerCd">メーカー</param>
        /// <param name="warehouseCd">倉庫コード(商品チェック時はstring.Empty)</param>
        /// <returns>true：キー重複無し、false：キー重複あり</returns>
        /// <remarks>
        /// <br>新規追加行用</br>
        /// </remarks>
        public bool CheckKeyDuplication(string goodsNo, int makerCd, string warehouseCd)
        {
            List<GoodsUnitData> goodsUnitDataList;
            //PartsInfoDataSet partsInfoDataSet; // DEL 2009/03/03
            string msg;
            GoodsCndtn goodsCndtn = new GoodsCndtn();

            goodsCndtn.EnterpriseCode = this._enterpriseCode;
            goodsCndtn.GoodsNo = goodsNo;
            goodsCndtn.GoodsMakerCd = makerCd;

            goodsCndtn.IsSettingSupplier = 1;  // ADD 2009/02/16
            goodsCndtn.IsSettingVariousMst = 1;  // ADD 2009/02/16

            //int status = this._goodsAcs.SearchPartsFromGoodsNoWholeWord(goodsCndtn, out partsInfoDataSet, out goodsUnitDataList, out msg); // DEL 2009/03/03
            int status = this._goodsAcs.Search(goodsCndtn, ConstantManagement.LogicalMode.GetData01, out goodsUnitDataList, out msg); // ADD 2009/03/03

            if (goodsUnitDataList.Count == 0)
            {
                // 該当がなければ重複無し
                return true;
            }
            else
            {
                if (warehouseCd == string.Empty)
                {
                    // 商品チェックの場合、該当（キー重複）あり
                    return false;
                }
                else
                {
                    if (goodsUnitDataList[0].StockList == null
                        || goodsUnitDataList[0].StockList.Count == 0)
                    {
                        // 在庫がないのでキー重複無し
                        return true;
                    }
                    else
                    {
                        foreach (Stock stock in goodsUnitDataList[0].StockList)
                        {
                            if (stock.WarehouseCode == warehouseCd)
                            {
                                // 同じ倉庫がある場合、該当（キー重複）あり
                                return false;
                            }
                        }

                        return true;
                    }
                }
            }
        }
        #endregion

        #endregion

        #region ■privateメソッド

        #region ■ 検索系処理
        /// <summary>
        /// 掛率優先管理マスタ情報取得処理
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>掛率優先管理情報を検索し、該当レコードの有無を返す</br>
        /// </remarks>
        private bool SearchRateProtyMng()
        {
            int status;
            ArrayList retList;
            int retCount;
            bool nextData;
            string errMsg;

            // ログイン拠点で検索
            status = this._rateProtyMngAcs.Search(
                out retList, out retCount, out nextData, this._enterpriseCode, this._loginSectionCode, out errMsg);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL
                && retList.Count != 0)
            {
                foreach (RateProtyMng rateProtyMng in retList)
                {
                    if (rateProtyMng.UnitPriceKind == Convert.ToInt32(CT_UnitPriceKind) 
                        && rateProtyMng.SectionCode == this._loginSectionCode// ADD 徐秋華 2011/12/31 Redmine#27530
                        && rateProtyMng.RateSettingDivide == CT_RateSettingDivide)
                    {
                        return true;
                    }
                }
            }

            // 全社設定で検索
            status = this._rateProtyMngAcs.Search(
                out retList, out retCount, out nextData, this._enterpriseCode, "00", out errMsg);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL
                && retList.Count != 0)
            {
                foreach (RateProtyMng rateProtyMng in retList)
                {
                    if (rateProtyMng.UnitPriceKind == Convert.ToInt32(CT_UnitPriceKind)
                        && rateProtyMng.SectionCode.Equals("00")// ADD 徐秋華 2011/12/31 Redmine#27530
                        && rateProtyMng.RateSettingDivide == CT_RateSettingDivide)
                    {
                        return true;
                    }
                }
            }

            // 存在しない
            return false;
        }

        // --- DEL 2009/02/04 -------------------------------->>>>>
        ///// <summary>
        ///// 商品連結データ(提供分)から、ユーザデータに登録のあるデータを除外する
        ///// </summary>
        ///// <returns>商品連結データ(提供分のみ)</returns>
        //private List<GoodsUnitData> GetOfferGoodsUnitData(List<GoodsUnitData> goodsUnitDataList)
        //{
        //    List<GoodsUnitData> offerGoodsUnitDataList = new List<GoodsUnitData>();
        //    string errMsg;

        //    foreach (GoodsUnitData goodsUnitData in goodsUnitDataList)
        //    {
        //        // ユーザデータ
        //        GoodsCndtn goodsCndtn = new GoodsCndtn();

        //        goodsCndtn.EnterpriseCode = this._enterpriseCode;
        //        goodsCndtn.GoodsNo = goodsUnitData.GoodsNo;
        //        goodsCndtn.GoodsMakerCd = goodsUnitData.GoodsMakerCd;

        //        List<GoodsUnitData> userGoodsUnitDataList;

        //        this._goodsAcs.Search(goodsCndtn, ConstantManagement.LogicalMode.GetData01, out userGoodsUnitDataList, out errMsg);

        //        if (userGoodsUnitDataList.Count == 0)
        //        {
        //            // ユーザデータに同じ商品が無ければ表示対象に追加
        //            offerGoodsUnitDataList.Add(goodsUnitData);
        //        }
        //    }

        //    return offerGoodsUnitDataList;
        //}
        // --- DEL 2009/02/04 --------------------------------<<<<<

        // --- ADD 2009/02/04 -------------------------------->>>>>
        /// <summary>
        /// 商品連結データ（ユーザ分）存在チェック
        /// </summary>
        /// <param name="goodsUnitData">商品連結データ(提供分)</param>
        /// <returns>true:ユーザデータにない false：ユーザデータにある</returns>
        /// <remarks>
        /// <br>商品連結データ(提供分)がユーザ分にも存在するかチェックする</br>
        /// </remarks>
        private bool CheckOfferGoodsUnitData(GoodsUnitData goodsUnitData)
        {
            string errMsg;

            // ユーザデータ
            GoodsCndtn goodsCndtn = new GoodsCndtn();

            goodsCndtn.EnterpriseCode = this._enterpriseCode;
            goodsCndtn.GoodsNo = goodsUnitData.GoodsNo;
            goodsCndtn.GoodsMakerCd = goodsUnitData.GoodsMakerCd;

            // 商品属性 (0,1両方)
            goodsCndtn.GoodsKindCode = 9;

            goodsCndtn.IsSettingSupplier = 1; // ADD 2009/02/16
            goodsCndtn.IsSettingVariousMst = 1; // ADD 2009/02/16

            List<GoodsUnitData> userGoodsUnitDataList;

            this._goodsAcs.Search(goodsCndtn, ConstantManagement.LogicalMode.GetData01, out userGoodsUnitDataList, out errMsg);

            if (userGoodsUnitDataList.Count == 0)
            {
                return true;
            }

            return false;
        }
        // --- ADD 2009/02/04 --------------------------------<<<<<

        // --- DEL 2009/02/04 -------------------------------->>>>>
        ///// <summary>
        ///// 在庫登録のない商品のみを取得
        ///// </summary>
        ///// <param name="goodsUnitDataList"></param>
        ///// <param name="extractInfo"></param>
        ///// <returns></returns>
        //private void FilterGoodsUnitDataByNoGoods(List<GoodsUnitData> goodsUnitDataList)
        //{
        //    for (int i = goodsUnitDataList.Count - 1; i >= 0; i--)
        //    {
        //        if (goodsUnitDataList[i].LogicalDeleteCode != 0
        //            ||
        //            (goodsUnitDataList[i].StockList != null
        //            && goodsUnitDataList[i].StockList.Count != 0)
        //            )
        //        {
        //            goodsUnitDataList.RemoveAt(i);
        //        }
        //    }
        //}
        // --- DEL 2009/02/04 --------------------------------<<<<<

        // --- DEL 2009/03/10 -------------------------------->>>>>
        // --- ADD 2009/02/04 -------------------------------->>>>>
        ///// <summary>
        ///// 在庫登録のない商品のみを取得
        ///// </summary>
        ///// <param name="goodsUnitDataList"></param>
        ///// <param name="extractInfo"></param>
        ///// <returns>true:在庫なし false：在庫あり</returns>
        //private bool CheckGoodsUnitDataByNoGoods(GoodsUnitData goodsUnitData)
        //{
        //    if (goodsUnitData.LogicalDeleteCode != 0
        //        ||
        //        (goodsUnitData.StockList != null
        //        && goodsUnitData.StockList.Count != 0)
        //        )
        //    {
        //        return false;
        //    }

        //    return true;
        //}
        //// --- ADD 2009/02/04 --------------------------------<<<<<
        // --- DEL 2009/03/10 --------------------------------<<<<<
        // --- ADD 2009/03/10 -------------------------------->>>>>
        /// <summary>
        /// 新規登録、在庫の場合のフィルタ処理
        /// </summary>
        /// <param name="goodsUnitData"></param>
        /// <param name="extractInfo"></param>
        /// <returns></returns>
        private bool FilterGoodsUnitDataForNewStock(GoodsUnitData goodsUnitData, ExtractInfo extractInfo)
        {
            if (goodsUnitData.LogicalDeleteCode != 0)
            {
                return false;
            }

            if (goodsUnitData.StockList == null
                || goodsUnitData.StockList.Count == 0)
            {
                return true;
            }

            List<Stock> stockList = goodsUnitData.StockList;

            // 指定倉庫、拠点以外の在庫情報を除く
            for (int i = stockList.Count - 1; i >= 0; i--)
            {
                if (stockList[i].WarehouseCode.Trim() != extractInfo.WarehouseCode.Trim())
                {
                    stockList.RemoveAt(i);
                }
            }

            if (stockList.Count == 0)
            {
                // 同倉庫が無い場合は表示対象
                return true;
            }
            else
            {
                if (stockList[0].LogicalDeleteCode != 0
                    || stockList[0].SectionCode.Trim().PadLeft(2, '0') == extractInfo.AddUpSectionCode.Trim())
                {
                    return false;
                }
                else
                {
                    // 同拠点でないかつ論理削除で無い場合、表示対象
                    return true;
                }
            }
        }
        // --- ADD 2009/03/10 --------------------------------<<<<<

        // --- DEL 2009/02/04 -------------------------------->>>>>
        ///// <summary>
        ///// 抽出条件「倉庫」「管理拠点」に合致する商品在庫のみを取得
        ///// </summary>
        ///// <param name="goodsUnitDataList"></param>
        ///// <remarks>在庫有無チェックの後に呼ばれるので、在庫が存在することを前提とする</remarks>
        //private void FilterGoodsUnitDataByExtractInfo(List<GoodsUnitData> goodsUnitDataList, ExtractInfo extractInfo)
        //{
        //    foreach(GoodsUnitData goodsUnitData in goodsUnitDataList)
        //    {
        //        List<Stock> stockList = goodsUnitData.StockList;

        //        for (int i = stockList.Count - 1; i >= 0; i--)
        //        {
        //            if (!string.IsNullOrEmpty(extractInfo.WarehouseCode)
        //                && !string.IsNullOrEmpty(extractInfo.SectionCode))
        //            {
        //                if (stockList[i].WarehouseCode != extractInfo.WarehouseCode
        //                    || stockList[i].SectionCode != extractInfo.AddUpSectionCode)
        //                {
        //                    stockList.RemoveAt(i);
        //                }
        //            }
        //            else if (!string.IsNullOrEmpty(extractInfo.WarehouseCode))
        //            {
        //                if (stockList[i].WarehouseCode != extractInfo.WarehouseCode)
        //                {
        //                    stockList.RemoveAt(i);
        //                }
        //            }
        //            else if (!string.IsNullOrEmpty(extractInfo.SectionCode))
        //            {
        //                if (stockList[i].SectionCode != extractInfo.AddUpSectionCode)
        //                {
        //                    stockList.RemoveAt(i);
        //                }
        //            }
        //        }
        //    }
        //}
        // --- DEL 2009/02/04 --------------------------------<<<<<

        // --- ADD 2009/02/04 -------------------------------->>>>>
        /// <summary>
        /// 抽出条件「倉庫」「管理拠点」に合致する商品在庫のみを取得
        /// </summary>
        /// <param name="goodsUnitDataList"></param>
        private void FilterGoodsUnitDataByExtractInfo(GoodsUnitData goodsUnitData, ExtractInfo extractInfo)
        {
            List<Stock> stockList = goodsUnitData.StockList;

            if (stockList == null)
            {
                return;
            }

            for (int i = stockList.Count - 1; i >= 0; i--)
            {
                if (!string.IsNullOrEmpty(extractInfo.WarehouseCode)
                    //&& !string.IsNullOrEmpty(extractInfo.SectionCode)) // DEL 2009/03/10
                    && !string.IsNullOrEmpty(extractInfo.AddUpSectionCode)) // ADD 2009/03/10
                {
                    if (stockList[i].WarehouseCode != extractInfo.WarehouseCode
                        || stockList[i].SectionCode != extractInfo.AddUpSectionCode)
                    {
                        stockList.RemoveAt(i);
                    }
                }
                else if (!string.IsNullOrEmpty(extractInfo.WarehouseCode))
                {
                    if (stockList[i].WarehouseCode != extractInfo.WarehouseCode)
                    {
                        stockList.RemoveAt(i);
                    }
                }
                //else if (!string.IsNullOrEmpty(extractInfo.SectionCode)) // DEL 2009/03/10
                else if (!string.IsNullOrEmpty(extractInfo.AddUpSectionCode)) // ADD 2009/03/10
                {
                    if (stockList[i].SectionCode != extractInfo.AddUpSectionCode)
                    {
                        stockList.RemoveAt(i);
                    }
                }
            }
        }
        // --- ADD 2009/02/04 --------------------------------<<<<<

        // --- DEL 2009/02/04 -------------------------------->>>>>
        ///// <summary>
        ///// 在庫登録のある商品のみを取得
        ///// </summary>
        ///// <param name="goodsUnitDataList"></param>
        ///// <param name="extractInfo"></param>
        ///// <returns></returns>
        //private void FilterGoodsUnitDataByExistGoods(List<GoodsUnitData> goodsUnitDataList)
        //{
        //    for (int i = goodsUnitDataList.Count - 1; i >= 0; i--)
        //    {
        //        if (goodsUnitDataList[i].LogicalDeleteCode != 0
        //            || goodsUnitDataList[i].StockList == null
        //            || goodsUnitDataList[i].StockList.Count == 0)
        //        {
        //            goodsUnitDataList.RemoveAt(i);
        //        }
        //    }
        //}
        // --- DEL 2009/02/04 --------------------------------<<<<<

        // --- ADD 2009/02/04 -------------------------------->>>>>
        /// <summary>
        /// 在庫登録のある商品のみを取得
        /// </summary>
        /// <param name="goodsUnitDataList"></param>
        /// <param name="extractInfo"></param>
        /// <returns>true:在庫あり false:在庫なし</returns>
        private bool FilterGoodsUnitDataByExistGoods(GoodsUnitData goodsUnitData)
        {
            if (goodsUnitData.LogicalDeleteCode != 0
                || goodsUnitData.StockList == null
                || goodsUnitData.StockList.Count == 0)
            {
                return false;
            }

            return true;
        }
        // --- ADD 2009/02/04 --------------------------------<<<<<

        /// <summary>
        /// 出力指定によるフィルタ処理
        /// </summary>
        /// <param name="goodsUnitDataList"></param>
        /// <returns></returns>
        private void FilterGoodsUnitDataByOutputDiv(ExtractInfo extractInfo)
        {
            string fillStr = string.Empty;

            if (extractInfo.OutputDiv == ExtractInfo.OutputDivState.UserPrice)
            {
                // ユーザ価格、価格UP率(掛率マスタ)に値が設定されている
                fillStr = this._goodsStockDataTable.PriceFlColumn.ColumnName + " <> 0 OR "
                         + this._goodsStockDataTable.UpRateColumn.ColumnName + " <> 0";
            }
            else if (extractInfo.OutputDiv == ExtractInfo.OutputDivState.CostPrice)
            {
                // 原単価1,2,3の何れかに値が設定されている
                fillStr = this._goodsStockDataTable.SalesUnitCost1Column.ColumnName + " <> 0 OR "
                         + this._goodsStockDataTable.SalesUnitCost2Column.ColumnName + " <> 0 OR "
                         + this._goodsStockDataTable.SalesUnitCost3Column.ColumnName + " <> 0";
            }

            DataTable tmpTable = this._goodsStockDataTable.Copy();
            this._goodsStockDataTable.Clear();

            //DataRow[] drList = tmpTable.Select(fillStr, this._goodsStockDataTable.RowNumberColumn.ColumnName); // DEL 2009/03/06
            DataRow[] drList = tmpTable.Select(fillStr); // ADD 2009/03/06

            foreach (DataRow dr in drList)
            {
                this._goodsStockDataTable.ImportRow(dr);
            }
        }

        // --- DEL 2009/02/04 -------------------------------->>>>>
        ///// <summary>
        ///// 商品連結データから商品在庫テーブルへのデータ詰替処理
        ///// </summary>
        ///// <param name="goodsUnitDataList"></param>
        //private void SetGoodsStockDataTableFromGoodsUnitDataList(List<GoodsUnitData> goodsUnitDataList, ExtractInfo extractInfo)
        //{
        //    // テーブルの初期化
        //    this._goodsStockDataTable.Clear();

        //    for (int i = 0; i < goodsUnitDataList.Count; i++)
        //    {
        //        GoodsUnitData goodsUnitData = goodsUnitDataList[i];

        //        if (extractInfo.TargetDiv != ExtractInfo.TargetDivState.Goods
        //            && 
        //            (goodsUnitData.StockList != null && goodsUnitData.StockList.Count != 0)
        //            )
        //        {
        //            // 対象区分「商品-在庫」、「在庫-商品」で在庫リストが存在する場合
        //            for (int j = 0; j < goodsUnitData.StockList.Count; j++)
        //            {
        //                // レコードは在庫単位で作成
        //                Stock stock = goodsUnitData.StockList[j];

        //                this.SetGoodsStockDataRow(goodsUnitData, stock);
        //            }
        //        }
        //        else
        //        {
        //            // 対象区分「商品」または在庫リストが存在しない
        //            this.SetGoodsStockDataRow(goodsUnitData, null);
        //        }
        //    }
        //}
        // --- DEL 2009/02/04 --------------------------------<<<<<

        /// <summary>
        /// 在庫データから商品在庫テーブルへのデータ詰替処理
        /// </summary>
        /// <param name="goodsUnitDataList"></param>
        private void SetGoodsStockDataTableFromStockList(List<Stock> stockList)
        {
            // テーブルの初期化
            this._goodsStockDataTable.Clear();

            foreach (Stock stock in stockList)
            {
                // 在庫情報のみ設定
                this.SetGoodsStockDataRow(null, stock);
            }
        }

        /// <summary>
        /// 商品連結データ、在庫データより、商品在庫テーブル1レコードの設定を行う。
        /// </summary>
        /// <param name="goodsUnitDataList"></param>
        private void SetGoodsStockDataRow(GoodsUnitData goodsUnitData, Stock stock)
        {
            DataRow dr = this._goodsStockDataTable.NewRow();

            if (goodsUnitData != null)
            {
                dr[this._goodsStockDataTable.GoodsLogicalDeleteFlgColumn.ColumnName] = goodsUnitData.LogicalDeleteCode; // 論理削除フラグ
                if (goodsUnitData.LogicalDeleteCode != 0)
                {
                    // 論理削除データの場合、削除日を設定
                    dr[this._goodsStockDataTable.GoodsDeleteDateColumn.ColumnName] = goodsUnitData.UpdateDate; // 商品削除日(更新日)
                }
                dr[this._goodsStockDataTable.GoodsNoColumn.ColumnName] = goodsUnitData.GoodsNo; // 品番
                dr[this._goodsStockDataTable.GoodsNameColumn.ColumnName] = goodsUnitData.GoodsName; // 品名
                dr[this._goodsStockDataTable.GoodsMakerColumn.ColumnName] = goodsUnitData.GoodsMakerCd; // メーカーコード
                dr[this._goodsStockDataTable.GoodsMakerNameColumn.ColumnName] = goodsUnitData.MakerName; // メーカー名
                dr[this._goodsStockDataTable.GoodsNameKanaColumn.ColumnName] = goodsUnitData.GoodsNameKana; // 品名カナ
                dr[this._goodsStockDataTable.JanColumn.ColumnName] = goodsUnitData.Jan; // JANコード
                dr[this._goodsStockDataTable.BLGoodsCodeColumn.ColumnName] = goodsUnitData.BLGoodsCode; // BLコード
                dr[this._goodsStockDataTable.BLGoodsNameColumn.ColumnName] = this.GetBLGoodsHalfName(goodsUnitData.BLGoodsCode); // BLコード名
                dr[this._goodsStockDataTable.EnterpriseGanreCodeColumn.ColumnName] = goodsUnitData.EnterpriseGanreCode;
                dr[this._goodsStockDataTable.EnterpriseGanreNameColumn.ColumnName] = goodsUnitData.EnterpriseGanreName;
                dr[this._goodsStockDataTable.GoodsRateRankColumn.ColumnName] = goodsUnitData.GoodsRateRank;
                dr[this._goodsStockDataTable.GoodsKindCodeColumn.ColumnName] = goodsUnitData.GoodsKindCode;
                dr[this._goodsStockDataTable.TaxationDivCdColumn.ColumnName] = goodsUnitData.TaxationDivCd;
                dr[this._goodsStockDataTable.GoodsMGroupColumn.ColumnName] = goodsUnitData.GoodsMGroup;
                dr[this._goodsStockDataTable.GoodsMGroupNameColumn.ColumnName] = goodsUnitData.GoodsMGroupName;
                dr[this._goodsStockDataTable.BLGroupCodeColumn.ColumnName] = goodsUnitData.BLGroupCode;
                dr[this._goodsStockDataTable.BLGroupNameColumn.ColumnName] = goodsUnitData.BLGroupName;
                if (goodsUnitData.GoodsPriceList.Count != 0)
                {
                    dr[this._goodsStockDataTable.PriceStartDate1Column.ColumnName] = ConvertLongDateFromDateTime(goodsUnitData.GoodsPriceList[0].PriceStartDate);
                    dr[this._goodsStockDataTable.ListPrice1Column.ColumnName] = goodsUnitData.GoodsPriceList[0].ListPrice;
                    dr[this._goodsStockDataTable.OpenPriceDiv1Column.ColumnName] = goodsUnitData.GoodsPriceList[0].OpenPriceDiv;
                    dr[this._goodsStockDataTable.StockRate1Column.ColumnName] = goodsUnitData.GoodsPriceList[0].StockRate;
                    dr[this._goodsStockDataTable.SalesUnitCost1Column.ColumnName] = goodsUnitData.GoodsPriceList[0].SalesUnitCost;
                    dr[this._goodsStockDataTable.OfferDate1Column.ColumnName] = ConvertLongDateFromDateTime(goodsUnitData.GoodsPriceList[0].OfferDate); // ADD 2010/08/31
                    if (goodsUnitData.GoodsPriceList.Count != 1)
                    {
                        dr[this._goodsStockDataTable.PriceStartDate2Column.ColumnName] = ConvertLongDateFromDateTime(goodsUnitData.GoodsPriceList[1].PriceStartDate);
                        dr[this._goodsStockDataTable.ListPrice2Column.ColumnName] = goodsUnitData.GoodsPriceList[1].ListPrice;
                        dr[this._goodsStockDataTable.OpenPriceDiv2Column.ColumnName] = goodsUnitData.GoodsPriceList[1].OpenPriceDiv;
                        dr[this._goodsStockDataTable.StockRate2Column.ColumnName] = goodsUnitData.GoodsPriceList[1].StockRate;
                        dr[this._goodsStockDataTable.SalesUnitCost2Column.ColumnName] = goodsUnitData.GoodsPriceList[1].SalesUnitCost;
                        dr[this._goodsStockDataTable.OfferDate2Column.ColumnName] = ConvertLongDateFromDateTime(goodsUnitData.GoodsPriceList[1].OfferDate); // ADD 2010/08/31
                        if (goodsUnitData.GoodsPriceList.Count != 2)
                        {
                            dr[this._goodsStockDataTable.PriceStartDate3Column.ColumnName] = ConvertLongDateFromDateTime(goodsUnitData.GoodsPriceList[2].PriceStartDate);
                            dr[this._goodsStockDataTable.ListPrice3Column.ColumnName] = goodsUnitData.GoodsPriceList[2].ListPrice;
                            dr[this._goodsStockDataTable.OpenPriceDiv3Column.ColumnName] = goodsUnitData.GoodsPriceList[2].OpenPriceDiv;
                            dr[this._goodsStockDataTable.StockRate3Column.ColumnName] = goodsUnitData.GoodsPriceList[2].StockRate;
                            dr[this._goodsStockDataTable.SalesUnitCost3Column.ColumnName] = goodsUnitData.GoodsPriceList[2].SalesUnitCost;
                            dr[this._goodsStockDataTable.OfferDate3Column.ColumnName] = ConvertLongDateFromDateTime(goodsUnitData.GoodsPriceList[2].OfferDate); // ADD 2010/08/31

                            // --- ADD 2010/08/11 ---------->>>>>
                            if (goodsUnitData.GoodsPriceList.Count != 3)
                            {
                                dr[this._goodsStockDataTable.PriceStartDate4Column.ColumnName] = ConvertLongDateFromDateTime(goodsUnitData.GoodsPriceList[3].PriceStartDate);
                                dr[this._goodsStockDataTable.ListPrice4Column.ColumnName] = goodsUnitData.GoodsPriceList[3].ListPrice;
                                dr[this._goodsStockDataTable.OpenPriceDiv4Column.ColumnName] = goodsUnitData.GoodsPriceList[3].OpenPriceDiv;
                                dr[this._goodsStockDataTable.StockRate4Column.ColumnName] = goodsUnitData.GoodsPriceList[3].StockRate;
                                dr[this._goodsStockDataTable.SalesUnitCost4Column.ColumnName] = goodsUnitData.GoodsPriceList[3].SalesUnitCost;
                                dr[this._goodsStockDataTable.OfferDate4Column.ColumnName] = ConvertLongDateFromDateTime(goodsUnitData.GoodsPriceList[3].OfferDate); // ADD 2010/08/31

                                if (goodsUnitData.GoodsPriceList.Count != 4)
                                {
                                    dr[this._goodsStockDataTable.PriceStartDate5Column.ColumnName] = ConvertLongDateFromDateTime(goodsUnitData.GoodsPriceList[4].PriceStartDate);
                                    dr[this._goodsStockDataTable.ListPrice5Column.ColumnName] = goodsUnitData.GoodsPriceList[4].ListPrice;
                                    dr[this._goodsStockDataTable.OpenPriceDiv5Column.ColumnName] = goodsUnitData.GoodsPriceList[4].OpenPriceDiv;
                                    dr[this._goodsStockDataTable.StockRate5Column.ColumnName] = goodsUnitData.GoodsPriceList[4].StockRate;
                                    dr[this._goodsStockDataTable.SalesUnitCost5Column.ColumnName] = goodsUnitData.GoodsPriceList[4].SalesUnitCost;
                                    dr[this._goodsStockDataTable.OfferDate5Column.ColumnName] = ConvertLongDateFromDateTime(goodsUnitData.GoodsPriceList[4].OfferDate); // ADD 2010/08/31
                                }
                            }

                            // --- ADD 2010/08/11 ----------<<<<<
                        }
                    }
                }

                // 掛率マスタより
                this.GetRateInfo(ref dr, goodsUnitData.GoodsNo, goodsUnitData.GoodsMakerCd);
            }

            // 在庫情報
            if (stock != null)
            {
                dr[_goodsStockDataTable.StockLogicalDeleteFlgColumn.ColumnName] = stock.LogicalDeleteCode; // 論理削除フラグ

                if (stock.LogicalDeleteCode != 0)
                {
                    // 論理削除データの場合、削除日を設定
                    dr[_goodsStockDataTable.StockDeleteDateColumn.ColumnName] = stock.UpdateDate; // 商品削除日(更新日)
                }
                dr[_goodsStockDataTable.OriginalWarehouseCodeColumn.ColumnName] = stock.WarehouseCode.Trim().PadLeft(4, '0');
                dr[_goodsStockDataTable.WarehouseCodeColumn.ColumnName] = stock.WarehouseCode.Trim().PadLeft(4, '0');
                dr[_goodsStockDataTable.WarehouseNameColumn.ColumnName] = stock.WarehouseName;
                // --- ADD 2009/03/10 -------------------------------->>>>>
                dr[_goodsStockDataTable.SectionCodeColumn.ColumnName] = stock.SectionCode.Trim().PadLeft(2, '0');
                /* ---------------- DEL gezh 2013/01/24 Redmine#33361 Client端の改修案① ---------->>>>>
                SecInfoSet secInfoSet;
                int status = this._secInfoSetAcs.Read(out secInfoSet, this._enterpriseCode, stock.SectionCode.Trim().PadLeft(2, '0'));
                <<<<<-------------- DEL gezh 2013/01/24 Redmine#33361 Client端の改修案① ------------ */
                // ADD gezh 2013/01/24 Redmine#33361 Client端の改修案① ----->>>>>
                if (this._sectionDic == null)
                {
                    this.ReadSecInfoSet();
                }

                SecInfoSet secInfoSet;
                this._sectionDic.TryGetValue(stock.SectionCode.Trim().PadLeft(2, '0'), out secInfoSet);
                // ADD gezh 2013/01/24 Redmine#33361 Client端の改修案① -----<<<<<
                if (secInfoSet != null)
                {
                    dr[_goodsStockDataTable.SectionGuideSnmColumn.ColumnName] = secInfoSet.SectionGuideSnm;
                }
                // --- ADD 2009/03/10 --------------------------------<<<<<
                dr[_goodsStockDataTable.WarehouseShelfNoColumn.ColumnName] = stock.WarehouseShelfNo;
                dr[_goodsStockDataTable.DuplicationShelfNo1Column.ColumnName] = stock.DuplicationShelfNo1;
                dr[_goodsStockDataTable.DuplicationShelfNo2Column.ColumnName] = stock.DuplicationShelfNo2;
                //dr[_goodsStockDataTable.PartsManagementDivide1Column.ColumnName] = stock.PartsManagementDivide1;//DEL 2011/08/03
                dr[_goodsStockDataTable.PartsManagementDivide1Column.ColumnName] = string.IsNullOrEmpty((stock.PartsManagementDivide1).Trim()) ? "0" : stock.PartsManagementDivide1;//ADD 2011/08/03
                //dr[_goodsStockDataTable.PartsManagementDivide2Column.ColumnName] = stock.PartsManagementDivide2;//DEL 2011/08/03
                dr[_goodsStockDataTable.PartsManagementDivide2Column.ColumnName] = string.IsNullOrEmpty((stock.PartsManagementDivide2).Trim()) ? "0" : stock.PartsManagementDivide2;//ADD 2011/08/03
                dr[_goodsStockDataTable.StockSupplierCodeColumn.ColumnName] = stock.StockSupplierCode;
                dr[_goodsStockDataTable.StockSupplierSnmColumn.ColumnName] = this.GetSupplierSnm(stock.StockSupplierCode);
                dr[_goodsStockDataTable.StockDivColumn.ColumnName] = stock.StockDiv;
                dr[_goodsStockDataTable.SalesOrderUnitColumn.ColumnName] = stock.SalesOrderUnit;
                dr[_goodsStockDataTable.MinimumStockCntColumn.ColumnName] = stock.MinimumStockCnt;
                dr[_goodsStockDataTable.MaximumStockCntColumn.ColumnName] = stock.MaximumStockCnt;
                dr[_goodsStockDataTable.SupplierStockColumn.ColumnName] = stock.SupplierStock;
                dr[_goodsStockDataTable.ArrivalCntColumn.ColumnName] = stock.ArrivalCnt;
                dr[_goodsStockDataTable.ShipmentCntColumn.ColumnName] = stock.ShipmentCnt;
                dr[_goodsStockDataTable.AcpOdrCountColumn.ColumnName] = stock.AcpOdrCount;
                dr[_goodsStockDataTable.MovingSupliStockColumn.ColumnName] = stock.MovingSupliStock;
                dr[_goodsStockDataTable.NowStockCntColumn.ColumnName] = stock.SupplierStock
                                                                      + stock.ArrivalCnt - stock.ShipmentCnt
                                                                      - stock.AcpOdrCount - stock.MovingSupliStock;
                // --- ADD 2009/03/05 -------------------------------->>>>>
                dr[_goodsStockDataTable.OriginalStockUnitPriceFlColumn.ColumnName] = stock.StockUnitPriceFl;
                dr[_goodsStockDataTable.StockUnitPriceFlColumn.ColumnName] = stock.StockUnitPriceFl;
                // --- ADD 2009/03/05 --------------------------------<<<<<

            }
            else
            {
                //-----ADD 2011/08/03---------->>>>>
                dr[_goodsStockDataTable.PartsManagementDivide1Column.ColumnName] = "0";
                dr[_goodsStockDataTable.PartsManagementDivide2Column.ColumnName] = "0";
                //-----ADD 2011/08/03----------<<<<<
            }

            this._goodsStockDataTable.Rows.Add(dr);
        }

        /// <summary>
        /// 掛率マスタの項目取得
        /// </summary>
        /// <param name="dr"></param>
        private void GetRateInfo(ref DataRow dr, string goodsNo, int goodsMakerCd)
        {
            // --- DEL 2009/02/04 -------------------------------->>>>>
            //int status;

            //// 検索済みの掛率情報があれば取得
            //Rate orgRate = this.GetOriginalRate(goodsNo, goodsMakerCd);

            //if (orgRate != null)
            //{
            //    dr[_goodsStockDataTable.PriceFlColumn.ColumnName] = orgRate.PriceFl;
            //    dr[_goodsStockDataTable.UpRateColumn.ColumnName] = orgRate.UpRate;

            //    return;
            //}

            //ArrayList retList;
            //string errMsg;

            //// ログイン拠点での検索
            //// 引数設定
            //Rate rate = new Rate();
            //rate.EnterpriseCode = this._enterpriseCode;
            //rate.UnitPriceKind = CT_UnitPriceKind;
            //rate.RateSettingDivide = CT_RateSettingDivide;
            //rate.UnitRateSetDivCd = CT_UnitRateSetDivCd;
            //rate.SectionCode = this._loginSectionCode; // 拠点コード
            //rate.GoodsNo = goodsNo;
            //rate.GoodsMakerCd = goodsMakerCd;

            //status = this._rateAcs.SearchAll(out retList, ref rate, out errMsg);

            //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL
            //    && retList.Count != 0)
            //{
            //    // ログイン拠点で該当があれば、リストに保存
            //    this._originalRateList.Add((Rate)retList[0]);
            //}
            //else
            //{
            //    // ログイン拠点で存在しない場合、全社設定で検索
            //    rate.SectionCode = "00";

            //    status = this._rateAcs.SearchAll(out retList, ref rate, out errMsg);

            //    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL
            //        && retList.Count != 0)
            //    {
            //        // 全社設定で該当があれば、リストに保存
            //        this._originalAllSectionRateList.Add((Rate)retList[0]);
            //    }
            //}

            //if (retList.Count != 0)
            //{
            //    Rate retRate = (Rate)retList[0];

            //    dr[_goodsStockDataTable.PriceFlColumn.ColumnName] = retRate.PriceFl;
            //    dr[_goodsStockDataTable.UpRateColumn.ColumnName] = retRate.UpRate;
            //}
            // --- DEL 2009/02/04 --------------------------------<<<<<
            // --- DEL 2009/02/16 -------------------------------->>>>>
            //// --- ADD 2009/02/04 -------------------------------->>>>>
            //// ログイン拠点で該当があれば設定
            //foreach (Rate rate in this._originalRateList)
            //{
            //    if (rate.SectionCode.TrimEnd() == this._loginSectionCode.TrimEnd()
            //        && rate.GoodsNo == goodsNo
            //        && rate.GoodsMakerCd == goodsMakerCd)
            //    {
            //        dr[_goodsStockDataTable.PriceFlColumn.ColumnName] = rate.PriceFl;
            //        dr[_goodsStockDataTable.UpRateColumn.ColumnName] = rate.UpRate;

            //        return;
            //    }
            //}

            //// 全社設定で該当があれば設定
            //foreach (Rate rate in this._originalRateList)
            //{
            //    if (rate.SectionCode.TrimEnd() == "00"
            //        && rate.GoodsNo == goodsNo
            //        && rate.GoodsMakerCd == goodsMakerCd)
            //    {
            //        dr[_goodsStockDataTable.PriceFlColumn.ColumnName] = rate.PriceFl;
            //        dr[_goodsStockDataTable.UpRateColumn.ColumnName] = rate.UpRate;

            //        return;
            //    }
            //}
            //// --- ADD 2009/02/04 --------------------------------<<<<<
            // --- DEL 2009/02/16 --------------------------------<<<<<
            // --- ADD 2009/02/16 -------------------------------->>>>>
            // ログイン拠点で該当があれば設定
            Rate rate = null;
            rate = this._originalRateList.Find(
                delegate(Rate orgRate)
                {
                    if ((orgRate.GoodsNo == goodsNo) &&
                        (orgRate.GoodsMakerCd == goodsMakerCd) &&
                        (orgRate.SectionCode.TrimEnd() == this._loginSectionCode.TrimEnd()))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            );

            if (rate != null)
            {
                dr[_goodsStockDataTable.PriceFlColumn.ColumnName] = rate.PriceFl;
                dr[_goodsStockDataTable.UpRateColumn.ColumnName] = rate.UpRate;
                return;
            }

            // 全社設定で該当があれば設定
            rate = null;
            rate = this._originalRateList.Find(
                delegate(Rate orgRate)
                {
                    if ((orgRate.GoodsNo == goodsNo) &&
                        (orgRate.GoodsMakerCd == goodsMakerCd) &&
                        (orgRate.SectionCode.TrimEnd() == "00"))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            );

            if (rate != null)
            {
                dr[_goodsStockDataTable.PriceFlColumn.ColumnName] = rate.PriceFl;
                dr[_goodsStockDataTable.UpRateColumn.ColumnName] = rate.UpRate;
                return;
            }
            // --- ADD 2009/02/16 --------------------------------<<<<<
        }

        /// <summary>
        /// 仕入先略称取得
        /// </summary>
        /// <param name="supplierCd"></param>
        /// <returns></returns>
        private string GetSupplierSnm(int supplierCd)
        {
            // --- DEL 2009/02/04 -------------------------------->>>>>
            //Supplier supplier;

            //int status = this._supplierAcs.Read(out supplier, this._enterpriseCode, supplierCd); 

            //if (status == 0)
            //{
            //    return supplier.SupplierSnm;
            //}

            //return string.Empty;
            // --- DEL 2009/02/04 --------------------------------<<<<<
            // --- ADD 2009/02/04 -------------------------------->>>>>
            if (this._supplierList == null)
            {
                this._supplierList = new Dictionary<int, string>();
 
                ArrayList arrayList;
                this._supplierAcs.SearchAll(out arrayList, this._enterpriseCode);

                foreach (Supplier supplier in arrayList)
                {
                    this._supplierList.Add(supplier.SupplierCd, supplier.SupplierSnm);
                }
            }

            if (this._supplierList.ContainsKey(supplierCd))
            {
                return this._supplierList[supplierCd];
            }

            return string.Empty;
            // --- ADD 2009/02/04 --------------------------------<<<<<
        }

        /// <summary>
        /// BLコード名称(カナ)取得
        /// </summary>
        /// <param name="supplierCd"></param>
        /// <returns></returns>
        private string GetBLGoodsHalfName(int blGoodsCd)
        {
            // --- DEL 2009/02/04 -------------------------------->>>>>
            //BLGoodsCdUMnt blGoodsCdUMnt;

            //int status = this._blGoodsCdAcs.Read(out blGoodsCdUMnt, this._enterpriseCode, blGoodsCd);

            //if (status == 0)
            //{
            //    return blGoodsCdUMnt.BLGoodsHalfName;
            //}

            //return string.Empty;
            // --- DEL 2009/02/04 --------------------------------<<<<<
            // --- ADD 2009/02/04 -------------------------------->>>>>
            if (this._blGoodsCdUMntList == null)
            {
                this._blGoodsCdUMntList = new Dictionary<int, string>();

                ArrayList arrList;
                this._blGoodsCdAcs.SearchAll(out arrList, this._enterpriseCode);

                foreach (BLGoodsCdUMnt blGoodsCdUMnt in arrList)
                {
                    this._blGoodsCdUMntList.Add(blGoodsCdUMnt.BLGoodsCode, blGoodsCdUMnt.BLGoodsHalfName);
                }
            }

            if (this._blGoodsCdUMntList.ContainsKey(blGoodsCd))
            {
                return this._blGoodsCdUMntList[blGoodsCd];
            }

            return string.Empty;
            // --- ADD 2009/02/04 --------------------------------<<<<<
        }
        // ADD gezh 2013/01/24 Redmine#33361 Client端の改修案① ----->>>>>
        /// <summary>
        /// 拠点情報取得
        /// </summary>
        private void ReadSecInfoSet()
        {
            this._sectionDic = new Dictionary<string, SecInfoSet>();

            ArrayList retList;

            try
            {
                int status = this._secInfoSetAcs.SearchAll(out retList, LoginInfoAcquisition.EnterpriseCode);
                if (status == 0)
                {
                    foreach (SecInfoSet secInfoSet in retList)
                    {
                        if (secInfoSet.LogicalDeleteCode == 0)
                        {
                            this._sectionDic.Add(secInfoSet.SectionCode.Trim(), secInfoSet);
                        }
                    }
                }
            }
            catch
            {
                this._sectionDic = new Dictionary<string, SecInfoSet>();
            }
        }
        // ADD gezh 2013/01/24 Redmine#33361 Client端の改修案① ----->>>>>
        #endregion

        #region ■ 更新系処理
        /// <summary>
        /// 商品在庫テーブルから商品連結データへのデータ詰替処理
        /// </summary>
        /// <param name="extractInfo">検索時の抽出条件</param>
        /// <param name="dr">更新後データの1行データ</param>
        /// <param name="goodsUnitDataList"></param>
        /// <returns>0:更新対象行、1:更新不要行、その他:エラー</returns>
        /// <remarks>
        /// <br>UpdateNote       : 2010/06/08 高峰 障害・改良対応（７月リリース案件）</br>
        /// <br>Update Note      : 2011/12/31 徐秋華</br> 
        /// <br>                 管理番号 10707327-00 2012/01/25配信分</br> 							
        /// <br>                 Redmine27530 商品在庫一括登録/「０円」の掛率データの登録</br> 		 
        /// <br>Update Note      : 2012/09/11 yangmj 障害・改良対応（７月リリース案件）</br>
        /// <br>管理番号         : 10707327-00 PM1203G</br> 							
        /// <br>                   Redmine32095 商品在庫一括登録修正で「全ての価格情報が消える」</br>
        /// <br>Update Note      : 2015/01/14 田建委</br>
        /// <br>管理番号         : 11100008-00</br>
        /// <br>                 : Redmine#44473 商品在庫一括登録修正にて在庫削除日が削除処理した日付になっていない対応</br>
        /// </remarks>
        private int SetGoodsUnitDataListFromGoodsStockDataTable(DataRow dr,
            out GoodsUnitData goodsUnitData, out List<Stock> prevStockList, out List<Rate> rateList, ExtractInfo beforeExtractInfo, ExtractInfo newExtractInfo)
        {
            // 更新要フラグ
            bool updateFlg = false;

            // 更新用商品連結データ
            goodsUnitData = GetOriginalGoodsUnitData(
                    dr[this._goodsStockDataTable.GoodsNoColumn.ColumnName].ToString(), (int)dr[this._goodsStockDataTable.GoodsMakerColumn.ColumnName]);
            prevStockList = new List<Stock>();
            rateList = new List<Rate>();

            //----- ADD YANGMJ 2012/09/11 REDMINE#32095 ----->>>>>
            string goodsNo = dr[this._goodsStockDataTable.GoodsNoColumn.ColumnName].ToString();
            if (goodsNo.Contains("'"))
            {
                goodsNo = goodsNo.Replace("'", "''");
            }
            //----- ADD YANGMJ 2012/09/11 REDMINE#32095 -----<<<<<

            if (beforeExtractInfo.DisplayDiv == ExtractInfo.DisplayDivState.New
                && beforeExtractInfo.TargetDiv == ExtractInfo.TargetDivState.Goods)
            {
                #region ■ 新規登録-商品
                // 提供データなので、論理削除行はない
                // 削除予約行
                //if (dr[this._goodsStockDataTable.GoodsDeleteDateColumn.ColumnName] != null
                //    && dr[this._goodsStockDataTable.GoodsDeleteDateColumn.ColumnName] != DBNull.Value) // DEL 2009/02/05
                if ((int)dr[this._goodsStockDataTable.GoodsDeleteReserveFlgColumn.ColumnName] != 0) // ADD 2009/02/05
                {
                    return (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                }

                // 価格開始日に入力が無ければ処理対象外
                if (
                    (dr[this._goodsStockDataTable.PriceStartDate1Column.ColumnName] == null
                    || dr[this._goodsStockDataTable.PriceStartDate1Column.ColumnName] == DBNull.Value)
                    &&
                    (dr[this._goodsStockDataTable.PriceStartDate2Column.ColumnName] == null
                    || dr[this._goodsStockDataTable.PriceStartDate2Column.ColumnName] == DBNull.Value)
                    &&
                    (dr[this._goodsStockDataTable.PriceStartDate3Column.ColumnName] == null
                    || dr[this._goodsStockDataTable.PriceStartDate3Column.ColumnName] == DBNull.Value)
                    // --- ADD 2010/08/11 ---------->>>>>
                    &&
                    (dr[this._goodsStockDataTable.PriceStartDate4Column.ColumnName] == null
                    || dr[this._goodsStockDataTable.PriceStartDate4Column.ColumnName] == DBNull.Value)
                    &&
                    (dr[this._goodsStockDataTable.PriceStartDate5Column.ColumnName] == null
                    || dr[this._goodsStockDataTable.PriceStartDate5Column.ColumnName] == DBNull.Value)
                    // --- ADD 2010/08/11 ----------<<<<<
                    )
                {
                    return (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                }

                if (goodsUnitData == null)
                {
                    goodsUnitData = new GoodsUnitData();
                    goodsUnitData.EnterpriseCode = this._enterpriseCode; // 企業コード
                    goodsUnitData.LogicalDeleteCode = 0; // 論理削除フラグ
                    goodsUnitData.GoodsNo = dr[this._goodsStockDataTable.GoodsNoColumn.ColumnName].ToString(); // 品番
                    goodsUnitData.GoodsMakerCd = (int)dr[this._goodsStockDataTable.GoodsMakerColumn.ColumnName]; // メーカーコード
                    goodsUnitData.MakerName = dr[this._goodsStockDataTable.GoodsMakerNameColumn.ColumnName].ToString(); // メーカー名
                    goodsUnitData.OfferDataDiv = 0; // 提供区分「ユーザー」
                }
                goodsUnitData.UpdEmployeeCode = newExtractInfo.StockAgentCode; // 入力担当者コード
                goodsUnitData.UpdEmployeeName = newExtractInfo.StockAgentName; // 入力担当者名
                goodsUnitData.GoodsNoNoneHyphen = dr[this._goodsStockDataTable.GoodsNoColumn.ColumnName].ToString().Replace("-", string.Empty); // ハイフン無し品番
                goodsUnitData.GoodsName = dr[this._goodsStockDataTable.GoodsNameColumn.ColumnName].ToString(); // 品名
                // --- UPD 2010/06/08 ---------->>>>>
                //goodsUnitData.GoodsNameKana = dr[this._goodsStockDataTable.GoodsNameKanaColumn.ColumnName].ToString(); // 品名カナ
                goodsUnitData.GoodsNameKana = dr[this._goodsStockDataTable.GoodsNameColumn.ColumnName].ToString(); // 品名カナ
                // --- UPD 2010/06/08 ----------<<<<<
                goodsUnitData.Jan = dr[this._goodsStockDataTable.JanColumn.ColumnName].ToString(); // JANコード
                goodsUnitData.BLGoodsCode = ConvertToInt32FromGridValue(dr[this._goodsStockDataTable.BLGoodsCodeColumn.ColumnName]); // BLコード
                goodsUnitData.BLGoodsName = dr[this._goodsStockDataTable.BLGoodsNameColumn.ColumnName].ToString(); // BLコード名
                goodsUnitData.EnterpriseGanreCode = ConvertToInt32FromGridValue(dr[this._goodsStockDataTable.EnterpriseGanreCodeColumn.ColumnName]); // 自社分類コード
                goodsUnitData.EnterpriseGanreName = dr[this._goodsStockDataTable.EnterpriseGanreNameColumn.ColumnName].ToString();
                goodsUnitData.GoodsRateRank = dr[this._goodsStockDataTable.GoodsRateRankColumn.ColumnName].ToString();
                goodsUnitData.GoodsKindCode = ConvertToInt32FromGridValue(dr[this._goodsStockDataTable.GoodsKindCodeColumn.ColumnName]);
                goodsUnitData.TaxationDivCd = ConvertToInt32FromGridValue(dr[this._goodsStockDataTable.TaxationDivCdColumn.ColumnName]);
                goodsUnitData.GoodsMGroup = ConvertToInt32FromGridValue(dr[this._goodsStockDataTable.GoodsMGroupColumn.ColumnName]);
                goodsUnitData.GoodsMGroupName = dr[this._goodsStockDataTable.GoodsMGroupNameColumn.ColumnName].ToString();
                goodsUnitData.BLGroupCode = ConvertToInt32FromGridValue(dr[this._goodsStockDataTable.BLGroupCodeColumn.ColumnName]);
                goodsUnitData.BLGroupName = dr[this._goodsStockDataTable.BLGroupNameColumn.ColumnName].ToString();

                // 価格情報
                goodsUnitData.GoodsPriceList = new List<GoodsPrice>();

                List<GoodsPrice> goodsPriceList = MakeNewGoodsPriceList(dr);

                if (goodsPriceList != null)
                {
                    goodsUnitData.GoodsPriceList.AddRange(goodsPriceList);
                }

                // 在庫情報
                goodsUnitData.StockList = new List<Stock>();

                // 掛率情報
                Rate rate = new Rate();

                if ((dr[this._goodsStockDataTable.PriceFlColumn.ColumnName] != null
                    && dr[this._goodsStockDataTable.PriceFlColumn.ColumnName] != DBNull.Value)
                    ||
                    (dr[this._goodsStockDataTable.UpRateColumn.ColumnName] != null
                    && dr[this._goodsStockDataTable.UpRateColumn.ColumnName] != DBNull.Value))
                {
                    // --- ADD 徐秋華 2011/12/31 Redmine#27530 ---------->>>>>
                    if (RateProtyMngExist && (Convert.ToInt64(dr[this._goodsStockDataTable.PriceFlColumn.ColumnName]) != 0
                        || Convert.ToDouble(dr[this._goodsStockDataTable.UpRateColumn.ColumnName]) != 0))
                    {
                    // --- ADD 徐秋華 2011/12/31 Redmine#27530 ----------<<<<<
                        // 必ず新規になる
                        rate.EnterpriseCode = this._enterpriseCode;
                        rate.SectionCode = this._loginSectionCode;
                        rate.UnitRateSetDivCd = CT_UnitRateSetDivCd; // 単価掛率設定区分
                        rate.UnitPriceKind = CT_UnitPriceKind; // 単価種類
                        rate.RateSettingDivide = CT_RateSettingDivide; // 掛率設定区分
                        rate.RateMngGoodsCd = CT_RateMngGoodsCd; // 掛率設定区分（商品）
                        rate.RateMngGoodsNm = CT_RateMngGoodsNm; // 掛率設定名称（商品）
                        rate.RateMngCustCd = CT_RateMngCustCd; // 掛率設定区分（得意先）
                        rate.RateMngCustNm = CT_RateMngCustNm; // 掛率設定名称（得意先）
                        rate.GoodsMakerCd = goodsUnitData.GoodsMakerCd;
                        rate.GoodsNo = goodsUnitData.GoodsNo;
                        rate.PriceFl = this.ConvertToDoubleFromGridValue(dr[this._goodsStockDataTable.PriceFlColumn.ColumnName]);
                        rate.UpRate = this.ConvertToDoubleFromGridValue(dr[this._goodsStockDataTable.UpRateColumn.ColumnName]);
                        rate.LotCount = CT_LotCount; // ロット数の初期値
                        rate.UnPrcFracProcUnit = CT_UnPrcFracProcUnit; // 単価端数処理単位
                        rate.UnPrcFracProcDiv = CT_UnPrcFracProcDiv; // 単価端数処理区分

                        rateList.Add(rate);
                    }// ADD 徐秋華 2011/12/31 Redmine#27530
                }

                updateFlg = true; // ADD 2009/02/04

                #endregion
            }
            else if (beforeExtractInfo.DisplayDiv == ExtractInfo.DisplayDivState.New
                && beforeExtractInfo.TargetDiv == ExtractInfo.TargetDivState.Stock)
            {
                #region ■ 新規登録-在庫
                // 在庫はないので論理削除行はない
                // 削除予約行
                //if (dr[this._goodsStockDataTable.StockDeleteDateColumn.ColumnName] != null
                //    && dr[this._goodsStockDataTable.StockDeleteDateColumn.ColumnName] != DBNull.Value) // DEL 2009/02/05
                if ((int)dr[this._goodsStockDataTable.StockDeleteReserveFlgColumn.ColumnName] != 0) // ADD 2009/02/05
                {
                    // 処理対象外
                    return (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                }
                else
                {
                    // --- ADD 2009/03/10 -------------------------------->>>>>
                    if (goodsUnitData.StockList.Count != 0)
                    {
                        // 更新前に編集前在庫リストを作成
                        foreach (Stock prevStock in goodsUnitData.StockList)
                        {
                            prevStockList.Add(prevStock.Clone());
                        }

                        // 新規-在庫の場合は、1商品1在庫(倉庫が必須のため)
                        Stock stock = goodsUnitData.StockList[0];

                        stock.UpdEmployeeCode = newExtractInfo.StockAgentCode; // 入力担当者コード
                        stock.UpdEmployeeName = newExtractInfo.StockAgentName; // 入力担当者名
                        stock.LogicalDeleteCode = 0; // 論理削除フラグ
                        stock.WarehouseCode = beforeExtractInfo.WarehouseCode; // 倉庫コード
                        stock.WarehouseName = beforeExtractInfo.WarehouseName; // 倉庫名
                        stock.SectionCode = beforeExtractInfo.AddUpSectionCode; // 管理拠点コード
                        stock.WarehouseShelfNo = dr[this._goodsStockDataTable.WarehouseShelfNoColumn.ColumnName].ToString(); // 棚番
                        stock.DuplicationShelfNo1 = dr[this._goodsStockDataTable.DuplicationShelfNo1Column.ColumnName].ToString(); // 重複棚番
                        stock.DuplicationShelfNo2 = dr[this._goodsStockDataTable.DuplicationShelfNo2Column.ColumnName].ToString(); // 重複棚番2
                        stock.PartsManagementDivide1 = dr[this._goodsStockDataTable.PartsManagementDivide1Column.ColumnName].ToString(); // 管理区分1
                        stock.PartsManagementDivide2 = dr[this._goodsStockDataTable.PartsManagementDivide2Column.ColumnName].ToString(); // 管理区分2
                        stock.StockSupplierCode = ConvertToInt32FromGridValue(dr[this._goodsStockDataTable.StockSupplierCodeColumn.ColumnName]); // 発注先
                        stock.StockDiv = ConvertToInt32FromGridValue(dr[this._goodsStockDataTable.StockDivColumn.ColumnName]); // 在庫区分
                        stock.SalesOrderUnit = ConvertToInt32FromGridValue(dr[this._goodsStockDataTable.SalesOrderUnitColumn.ColumnName]); // 発注ロット
                        stock.MinimumStockCnt = ConvertToDoubleFromGridValue(dr[this._goodsStockDataTable.MinimumStockCntColumn.ColumnName]); // 最低在庫数
                        stock.MaximumStockCnt = ConvertToDoubleFromGridValue(dr[this._goodsStockDataTable.MaximumStockCntColumn.ColumnName]); // 最高在庫数
                        stock.SupplierStock = ConvertToDoubleFromGridValue(dr[this._goodsStockDataTable.SupplierStockColumn.ColumnName]); // 仕入在庫
                        stock.ArrivalCnt = ConvertToDoubleFromGridValue(dr[this._goodsStockDataTable.ArrivalCntColumn.ColumnName]); // 入荷数
                        stock.ShipmentCnt = ConvertToDoubleFromGridValue(dr[this._goodsStockDataTable.ShipmentCntColumn.ColumnName]); // 出荷数
                        stock.AcpOdrCount = ConvertToDoubleFromGridValue(dr[this._goodsStockDataTable.AcpOdrCountColumn.ColumnName]); // 受注数
                        stock.MovingSupliStock = ConvertToDoubleFromGridValue(dr[this._goodsStockDataTable.MovingSupliStockColumn.ColumnName]);// 移動中仕入在庫数
                        stock.StockUnitPriceFl = ConvertToDoubleFromGridValue(dr[this._goodsStockDataTable.StockUnitPriceFlColumn.ColumnName]); // 棚卸評価単価 // ADD 2009/03/05
                        stock.UpdateDate = DateTime.Today;

                        goodsUnitData.StockList.Add(stock);

                        updateFlg = true;
                    }
                    // --- ADD 2009/03/10 --------------------------------<<<<<
                    else
                    {
                        // 在庫情報追加
                        goodsUnitData.StockList = new List<Stock>();
                        Stock stock = new Stock(); // DEL 2009/03/10

                        stock.EnterpriseCode = this._enterpriseCode; // 企業コード
                        stock.UpdEmployeeCode = newExtractInfo.StockAgentCode; // 入力担当者コード
                        stock.UpdEmployeeName = newExtractInfo.StockAgentName; // 入力担当者名
                        stock.LogicalDeleteCode = 0; // 論理削除フラグ
                        stock.GoodsNo = dr[this._goodsStockDataTable.GoodsNoColumn.ColumnName].ToString(); // 品番
                        stock.GoodsNoNoneHyphen = dr[this._goodsStockDataTable.GoodsNoColumn.ColumnName].ToString().Replace("-", string.Empty); // ハイフン無し品番
                        stock.GoodsName = dr[this._goodsStockDataTable.GoodsNameColumn.ColumnName].ToString(); // 品名
                        stock.GoodsMakerCd = (int)dr[this._goodsStockDataTable.GoodsMakerColumn.ColumnName]; // メーカーコード
                        stock.MakerName = dr[this._goodsStockDataTable.GoodsMakerNameColumn.ColumnName].ToString(); // メーカー名
                        stock.WarehouseCode = beforeExtractInfo.WarehouseCode; // 倉庫コード
                        stock.WarehouseName = beforeExtractInfo.WarehouseName; // 倉庫名
                        stock.SectionCode = beforeExtractInfo.AddUpSectionCode; // 管理拠点コード
                        stock.WarehouseShelfNo = dr[this._goodsStockDataTable.WarehouseShelfNoColumn.ColumnName].ToString(); // 棚番
                        stock.DuplicationShelfNo1 = dr[this._goodsStockDataTable.DuplicationShelfNo1Column.ColumnName].ToString(); // 重複棚番
                        stock.DuplicationShelfNo2 = dr[this._goodsStockDataTable.DuplicationShelfNo2Column.ColumnName].ToString(); // 重複棚番2
                        stock.PartsManagementDivide1 = dr[this._goodsStockDataTable.PartsManagementDivide1Column.ColumnName].ToString(); // 管理区分1
                        stock.PartsManagementDivide2 = dr[this._goodsStockDataTable.PartsManagementDivide2Column.ColumnName].ToString(); // 管理区分2
                        stock.StockSupplierCode = ConvertToInt32FromGridValue(dr[this._goodsStockDataTable.StockSupplierCodeColumn.ColumnName]); // 発注先
                        stock.StockDiv = ConvertToInt32FromGridValue(dr[this._goodsStockDataTable.StockDivColumn.ColumnName]); // 在庫区分
                        stock.SalesOrderUnit = ConvertToInt32FromGridValue(dr[this._goodsStockDataTable.SalesOrderUnitColumn.ColumnName]); // 発注ロット
                        stock.MinimumStockCnt = ConvertToDoubleFromGridValue(dr[this._goodsStockDataTable.MinimumStockCntColumn.ColumnName]); // 最低在庫数
                        stock.MaximumStockCnt = ConvertToDoubleFromGridValue(dr[this._goodsStockDataTable.MaximumStockCntColumn.ColumnName]); // 最高在庫数
                        stock.SupplierStock = ConvertToDoubleFromGridValue(dr[this._goodsStockDataTable.SupplierStockColumn.ColumnName]); // 仕入在庫
                        stock.ArrivalCnt = ConvertToDoubleFromGridValue(dr[this._goodsStockDataTable.ArrivalCntColumn.ColumnName]); // 入荷数
                        stock.ShipmentCnt = ConvertToDoubleFromGridValue(dr[this._goodsStockDataTable.ShipmentCntColumn.ColumnName]); // 出荷数
                        stock.AcpOdrCount = ConvertToDoubleFromGridValue(dr[this._goodsStockDataTable.AcpOdrCountColumn.ColumnName]); // 受注数
                        stock.MovingSupliStock = ConvertToDoubleFromGridValue(dr[this._goodsStockDataTable.MovingSupliStockColumn.ColumnName]);// 移動中仕入在庫数
                        // --- ADD 2009/03/05 -------------------------------->>>>>
                        stock.StockUnitPriceFl = ConvertToDoubleFromGridValue(dr[this._goodsStockDataTable.StockUnitPriceFlColumn.ColumnName]); // 棚卸評価単価 // ADD 2009/03/05
                        // --- ADD 2009/03/05 --------------------------------<<<<<
                        stock.CreateDateTime = DateTime.Today;
                        stock.UpdateDate = DateTime.Today;

                        goodsUnitData.StockList.Add(stock);

                        updateFlg = true; // ADD 2009/02/04
                    }
                }
                #endregion
            }
            else if (beforeExtractInfo.DisplayDiv == ExtractInfo.DisplayDivState.Update
                && beforeExtractInfo.TargetDiv == ExtractInfo.TargetDivState.Goods)
            {
                #region ■ 修正登録-商品
                // 論理削除行
                if ((int)dr[this._goodsStockDataTable.GoodsLogicalDeleteFlgColumn.ColumnName] != 0)
                {
                    return (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                }

                // 商品削除予約行
                //if (dr[this._goodsStockDataTable.GoodsDeleteDateColumn.ColumnName] != null
                //    && dr[this._goodsStockDataTable.GoodsDeleteDateColumn.ColumnName] != DBNull.Value) // DEL 2009/02/05
                if ((int)dr[this._goodsStockDataTable.GoodsDeleteReserveFlgColumn.ColumnName] != 0) // ADD 2009/02/05
                {
                    // 論理削除フラグに1をセット
                    goodsUnitData.LogicalDeleteCode = 1;

                    //----- ADD 2015/01/14 田建委 Redmine#44473 ----->>>>>
                    // 在庫削除
                    foreach (Stock stock in goodsUnitData.StockList)
                    {
                        stock.LogicalDeleteCode = 1;
                        stock.UpdateDate = DateTime.Today;
                    }
                    //----- ADD 2015/01/14 田建委 Redmine#44473 -----<<<<<

                    // 掛率（ログイン拠点）取得
                    Rate rate = GetOriginalRate(
                        dr[this._goodsStockDataTable.GoodsNoColumn.ColumnName].ToString(),
                        (int)dr[this._goodsStockDataTable.GoodsMakerColumn.ColumnName],
                        this._loginSectionCode // ADD 2009/02/04
                        );

                    if (rate != null)
                    {
                        rate.LogicalDeleteCode = 3;
                        rateList.Add(rate);
                    }

                    updateFlg = true; // ADD 2009/02/04
                }
                else
                {
                    if (GoodsUpdateCheck(goodsUnitData, dr))
                    {
                        //goodsUnitData.EnterpriseCode = this._enterpriseCode; // 企業コード
                        goodsUnitData.LogicalDeleteCode = 0; // 論理削除フラグ
                        goodsUnitData.UpdEmployeeCode = newExtractInfo.StockAgentCode; // 入力担当者コード
                        goodsUnitData.UpdEmployeeName = newExtractInfo.StockAgentName; // 入力担当者名
                        //goodsUnitData.GoodsNo = dr[this._goodsStockDataTable.GoodsNoColumn.ColumnName].ToString(); // 品番
                        goodsUnitData.GoodsNoNoneHyphen = dr[this._goodsStockDataTable.GoodsNoColumn.ColumnName].ToString().Replace("-", string.Empty); // ハイフン無し品番
                        goodsUnitData.GoodsName = dr[this._goodsStockDataTable.GoodsNameColumn.ColumnName].ToString(); // 品名
                        //goodsUnitData.GoodsMakerCd = (int)dr[this._goodsStockDataTable.GoodsMakerColumn.ColumnName]; // メーカーコード
                        goodsUnitData.MakerName = dr[this._goodsStockDataTable.GoodsMakerNameColumn.ColumnName].ToString(); // メーカー名
                        // --- UPD 2010/06/08 ---------->>>>>
                        //goodsUnitData.GoodsNameKana = dr[this._goodsStockDataTable.GoodsNameKanaColumn.ColumnName].ToString(); // 品名カナ
                        goodsUnitData.GoodsNameKana = dr[this._goodsStockDataTable.GoodsNameColumn.ColumnName].ToString(); // 品名カナ
                        // --- UPD 2010/06/08 ----------<<<<<
                        goodsUnitData.Jan = dr[this._goodsStockDataTable.JanColumn.ColumnName].ToString(); // JANコード
                        goodsUnitData.BLGoodsCode = ConvertToInt32FromGridValue(dr[this._goodsStockDataTable.BLGoodsCodeColumn.ColumnName]); // BLコード
                        goodsUnitData.BLGoodsName = dr[this._goodsStockDataTable.BLGoodsNameColumn.ColumnName].ToString(); // BLコード名
                        goodsUnitData.EnterpriseGanreCode = ConvertToInt32FromGridValue(dr[this._goodsStockDataTable.EnterpriseGanreCodeColumn.ColumnName]); // 自社分類コード
                        goodsUnitData.EnterpriseGanreName = dr[this._goodsStockDataTable.EnterpriseGanreNameColumn.ColumnName].ToString();
                        goodsUnitData.GoodsRateRank = dr[this._goodsStockDataTable.GoodsRateRankColumn.ColumnName].ToString();
                        goodsUnitData.GoodsKindCode = ConvertToInt32FromGridValue(dr[this._goodsStockDataTable.GoodsKindCodeColumn.ColumnName]);
                        goodsUnitData.TaxationDivCd = ConvertToInt32FromGridValue(dr[this._goodsStockDataTable.TaxationDivCdColumn.ColumnName]);
                        goodsUnitData.GoodsMGroup = ConvertToInt32FromGridValue(dr[this._goodsStockDataTable.GoodsMGroupColumn.ColumnName]);
                        goodsUnitData.GoodsMGroupName = dr[this._goodsStockDataTable.GoodsMGroupNameColumn.ColumnName].ToString();
                        goodsUnitData.BLGroupCode = ConvertToInt32FromGridValue(dr[this._goodsStockDataTable.BLGroupCodeColumn.ColumnName]);
                        goodsUnitData.BLGroupName = dr[this._goodsStockDataTable.BLGroupNameColumn.ColumnName].ToString();

                        updateFlg = true; // ADD 2009/02/04
                    }

                    // 価格情報
                    if (PriceUpdateCheck(goodsUnitData, dr))
                    {
                        goodsUnitData.GoodsPriceList = new List<GoodsPrice>();

                        List<GoodsPrice> goodsPriceList = MakeNewGoodsPriceList(dr);

                        if (goodsPriceList != null)
                        {
                            goodsUnitData.GoodsPriceList.AddRange(goodsPriceList);
                        }

                        updateFlg = true; // ADD 2009/02/04
                    }

                    // 在庫情報
                    //// 無い場合でもListのnewは必要
                    //goodsUnitData.StockList = new List<Stock>();

                    // 2011/10/17 Add >>>
                    // 在庫情報
                    // 同商品のGoodsStockリスト
                    DataRow[] drList = this._goodsStockDataTable.Select(
                        this._goodsStockDataTable.GoodsNoColumn.ColumnName
                        + " = '"
                        //+ dr[this._goodsStockDataTable.GoodsNoColumn.ColumnName].ToString()//DEL YANGMJ REDMINE#32095
                        + goodsNo// ADD YANGMJ 2012/09/11 REDMINE#32095
                        + "' AND "
                        + this._goodsStockDataTable.GoodsMakerColumn.ColumnName
                        + " = "
                        + dr[this._goodsStockDataTable.GoodsMakerColumn.ColumnName].ToString()
                        );

                    // 更新前に編集前在庫リストを作成
                    foreach (Stock prevStock in goodsUnitData.StockList)
                    {
                        prevStockList.Add(prevStock.Clone());
                    }
                    // 2011/10/17 Add <<<

                    // 掛率
                    Rate rate = GetOriginalRate(
                        dr[this._goodsStockDataTable.GoodsNoColumn.ColumnName].ToString(),
                        (int)dr[this._goodsStockDataTable.GoodsMakerColumn.ColumnName],
                        this._loginSectionCode); // ADD 2009/02/04

                    if (RateUpdateCheck(rate, dr))
                    {
                        if (rate == null)
                        {
                            // 全社設定で読込み
                            //rate = GetOriginalAllSectionRate(
                            //    dr[this._goodsStockDataTable.GoodsNoColumn.ColumnName].ToString(), (int)dr[this._goodsStockDataTable.GoodsMakerColumn.ColumnName]); // DEL 2009/02/04
                            rate = GetOriginalRate(
                                dr[this._goodsStockDataTable.GoodsNoColumn.ColumnName].ToString(),
                                (int)dr[this._goodsStockDataTable.GoodsMakerColumn.ColumnName],
                                "00"); // ADD 2009/02/04

                            if (rate == null)
                            {
                                rate = new Rate();

                                rate.EnterpriseCode = this._enterpriseCode;
                                rate.SectionCode = this._loginSectionCode;
                                rate.UnitRateSetDivCd = CT_UnitRateSetDivCd; // 単価掛率設定区分
                                rate.UnitPriceKind = CT_UnitPriceKind; // 単価種類
                                rate.RateSettingDivide = CT_RateSettingDivide; // 掛率設定区分
                                rate.RateMngGoodsCd = CT_RateMngGoodsCd; // 掛率設定区分（商品）
                                rate.RateMngGoodsNm = CT_RateMngGoodsNm; // 掛率設定名称（商品）
                                rate.RateMngCustCd = CT_RateMngCustCd; // 掛率設定区分（得意先）
                                rate.RateMngCustNm = CT_RateMngCustNm; // 掛率設定名称（得意先）
                                rate.GoodsMakerCd = goodsUnitData.GoodsMakerCd;
                                rate.GoodsNo = goodsUnitData.GoodsNo;
                                rate.LotCount = CT_LotCount; // ロット数の初期値
                                rate.UnPrcFracProcUnit = CT_UnPrcFracProcUnit; // 単価端数処理単位
                                rate.UnPrcFracProcDiv = CT_UnPrcFracProcDiv; // 単価端数処理区分
                            }
                            // DEL 2010/01/08 MANTIS対応[14861]：掛率マスタ項目に値が設定されているレコードが更新できない ---------->>>>>
                            // FIXME:強制的にログイン拠点に変更しているので、削除
                            //else
                            //{
                            //    // 全社設定から拠点のみ変更
                            //    rate.SectionCode = this._loginSectionCode;
                            //}
                            // DEL 2010/01/08 MANTIS対応[14861]：掛率マスタ項目に値が設定されているレコードが更新できない ----------<<<<<
                        }

                        rate.PriceFl = this.ConvertToDoubleFromGridValue(dr[this._goodsStockDataTable.PriceFlColumn.ColumnName]);
                        rate.UpRate = this.ConvertToDoubleFromGridValue(dr[this._goodsStockDataTable.UpRateColumn.ColumnName]);

                        rateList.Add(rate);

                        updateFlg = true; // ADD 2009/02/04
                    }
                }
                #endregion
            }
            else if (beforeExtractInfo.DisplayDiv == ExtractInfo.DisplayDivState.Update
                && beforeExtractInfo.TargetDiv == ExtractInfo.TargetDivState.Stock)
            {
                #region ■ 修正登録-在庫
                // 同商品のGoodsStockリスト
                DataRow[] drList = this._goodsStockDataTable.Select(
                    this._goodsStockDataTable.GoodsNoColumn.ColumnName
                    + " = '"
                    //+ dr[this._goodsStockDataTable.GoodsNoColumn.ColumnName].ToString()//DEL YANGMJ REDMINE#32095
                    + goodsNo//ADD YANGMJ 2012/09/11 REDMINE#32095
                    + "' AND "
                    + this._goodsStockDataTable.GoodsMakerColumn.ColumnName
                    + " = "
                    + dr[this._goodsStockDataTable.GoodsMakerColumn.ColumnName].ToString()
                    );

                // 更新前に編集前在庫リストを作成
                foreach (Stock prevStock in goodsUnitData.StockList)
                {
                    prevStockList.Add(prevStock.Clone());
                }

                // 在庫情報
                foreach (DataRow goodsStockDr in drList)
                {
                    if ((int)goodsStockDr[this._goodsStockDataTable.StockLogicalDeleteFlgColumn.ColumnName] != 0)
                    {
                        // 論理削除行
                        continue;
                    }

                    // 修正登録-在庫の場合は必ず該当あり
                    Stock originalStock = GetOriginalStock(goodsUnitData, goodsStockDr[this._goodsStockDataTable.WarehouseCodeColumn.ColumnName].ToString());

                    //if (goodsStockDr[this._goodsStockDataTable.StockDeleteDateColumn.ColumnName] != null
                    //    && goodsStockDr[this._goodsStockDataTable.StockDeleteDateColumn.ColumnName] != DBNull.Value) // DEL 2009/02/05
                    if ((int)goodsStockDr[this._goodsStockDataTable.StockDeleteReserveFlgColumn.ColumnName] != 0) // ADD 2009/02/05
                    {
                        // 削除予約行
                        originalStock.LogicalDeleteCode = 1;
                        originalStock.UpdateDate = DateTime.Today; // ADD 2015/01/14 田建委 Redmine#44473
                        updateFlg = true; // ADD 2009/02/04
                    }
                    else
                    {
                        if (StockUpdateCheck(originalStock, goodsStockDr))
                        {
                            //originalStock.EnterpriseCode = this._enterpriseCode; // 企業コード
                            originalStock.UpdEmployeeCode = newExtractInfo.StockAgentCode; // 入力担当者コード
                            originalStock.UpdEmployeeName = newExtractInfo.StockAgentName; // 入力担当者名
                            originalStock.LogicalDeleteCode = 0; // 論理削除フラグ
                            //originalStock.SectionCode = newExtractInfo.AddUpSectionCode; // 管理拠点コード
                            //originalStock.GoodsNo = dr[this._goodsStockDataTable.GoodsNoColumn.ColumnName].ToString(); // 品番
                            //originalStock.GoodsNoNoneHyphen = goodsStockDr[this._goodsStockDataTable.GoodsNoColumn.ColumnName].ToString().Replace("-", string.Empty); // ハイフン無し品番
                            //originalStock.GoodsName = goodsStockDr[this._goodsStockDataTable.GoodsNameColumn.ColumnName].ToString(); // 品名
                            //originalStock.GoodsMakerCd = (int)goodsStockDr[this._goodsStockDataTable.GoodsMakerColumn.ColumnName]; // メーカーコード
                            //originalStock.MakerName = goodsStockDr[this._goodsStockDataTable.GoodsMakerNameColumn.ColumnName].ToString(); // メーカー名
                            //originalStock.WarehouseCode = newExtractInfo.WarehouseCode; // 倉庫コード
                            //originalStock.WarehouseName = newExtractInfo.WarehouseName; // 倉庫名
                            originalStock.WarehouseShelfNo = goodsStockDr[this._goodsStockDataTable.WarehouseShelfNoColumn.ColumnName].ToString(); // 棚番
                            originalStock.DuplicationShelfNo1 = goodsStockDr[this._goodsStockDataTable.DuplicationShelfNo1Column.ColumnName].ToString(); // 重複棚番
                            originalStock.DuplicationShelfNo2 = goodsStockDr[this._goodsStockDataTable.DuplicationShelfNo2Column.ColumnName].ToString(); // 重複棚番2
                            originalStock.PartsManagementDivide1 = goodsStockDr[this._goodsStockDataTable.PartsManagementDivide1Column.ColumnName].ToString(); // 管理区分1
                            originalStock.PartsManagementDivide2 = goodsStockDr[this._goodsStockDataTable.PartsManagementDivide2Column.ColumnName].ToString(); // 管理区分2
                            originalStock.StockSupplierCode = ConvertToInt32FromGridValue(goodsStockDr[this._goodsStockDataTable.StockSupplierCodeColumn.ColumnName]); // 発注先
                            originalStock.StockDiv = ConvertToInt32FromGridValue(goodsStockDr[this._goodsStockDataTable.StockDivColumn.ColumnName]); // 在庫区分
                            originalStock.SalesOrderUnit = ConvertToInt32FromGridValue(goodsStockDr[this._goodsStockDataTable.SalesOrderUnitColumn.ColumnName]); // 発注ロット
                            originalStock.MinimumStockCnt = ConvertToDoubleFromGridValue(goodsStockDr[this._goodsStockDataTable.MinimumStockCntColumn.ColumnName]); // 最低在庫数
                            originalStock.MaximumStockCnt = ConvertToDoubleFromGridValue(goodsStockDr[this._goodsStockDataTable.MaximumStockCntColumn.ColumnName]); // 最高在庫数
                            originalStock.SupplierStock = ConvertToDoubleFromGridValue(goodsStockDr[this._goodsStockDataTable.SupplierStockColumn.ColumnName]); // 仕入在庫
                            originalStock.ArrivalCnt = ConvertToDoubleFromGridValue(goodsStockDr[this._goodsStockDataTable.ArrivalCntColumn.ColumnName]); // 入荷数
                            originalStock.ShipmentCnt = ConvertToDoubleFromGridValue(goodsStockDr[this._goodsStockDataTable.ShipmentCntColumn.ColumnName]); // 出荷数
                            originalStock.AcpOdrCount = ConvertToDoubleFromGridValue(goodsStockDr[this._goodsStockDataTable.AcpOdrCountColumn.ColumnName]); // 受注数
                            originalStock.MovingSupliStock = ConvertToDoubleFromGridValue(goodsStockDr[this._goodsStockDataTable.MovingSupliStockColumn.ColumnName]);// 移動中仕入在庫数
                            // --- ADD 2009/03/05 -------------------------------->>>>>
                            originalStock.StockUnitPriceFl = ConvertToDoubleFromGridValue(goodsStockDr[this._goodsStockDataTable.StockUnitPriceFlColumn.ColumnName]); // 棚卸評価単価 // ADD 2009/03/05
                            // --- ADD 2009/03/05 --------------------------------<<<<<
                            //originalStock.CreateDateTime = DateTime.Today;
                            originalStock.UpdateDate = DateTime.Today;

                            updateFlg = true; // ADD 2009/02/04
                        }
                    }
                }
                #endregion
            }
            else
            {
                #region ■ 修正登録-商品在庫、在庫商品

                if ((int)dr[this._goodsStockDataTable.GoodsLogicalDeleteFlgColumn.ColumnName] != 0)
                {
                    // 商品論理削除行
                    return (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                }

                //if (dr[this._goodsStockDataTable.GoodsDeleteDateColumn.ColumnName] != null
                //    && dr[this._goodsStockDataTable.GoodsDeleteDateColumn.ColumnName] != DBNull.Value)
                if ((int)dr[this._goodsStockDataTable.GoodsDeleteReserveFlgColumn.ColumnName] != 0)
                {
                    // 商品削除予約行

                    // 論理削除フラグに1をセット
                    goodsUnitData.LogicalDeleteCode = 1;

                    //----- ADD 2015/01/14 田建委 Redmine#44473 ----->>>>>
                    // 在庫削除
                    foreach (Stock stock in goodsUnitData.StockList)
                    {
                        stock.LogicalDeleteCode = 1;
                        stock.UpdateDate = DateTime.Today;
                    }
                    //----- ADD 2015/01/14 田建委 Redmine#44473 -----<<<<<

                    // 掛率取得
                    Rate rate = GetOriginalRate(
                        dr[this._goodsStockDataTable.GoodsNoColumn.ColumnName].ToString(),
                        (int)dr[this._goodsStockDataTable.GoodsMakerColumn.ColumnName],
                        this._loginSectionCode); // ADD 2009/02/04

                    if (rate != null)
                    {
                        rate.LogicalDeleteCode = 3;
                        rateList.Add(rate);
                    }

                    updateFlg = true; // ADD 2009/02/04
                }
                else
                {
                    if (this.GoodsUpdateCheck(goodsUnitData, dr))
                    {
                        // 商品情報
                        goodsUnitData.EnterpriseCode = this._enterpriseCode; // 企業コード
                        goodsUnitData.LogicalDeleteCode = 0; // 論理削除フラグ
                        goodsUnitData.UpdEmployeeCode = newExtractInfo.StockAgentCode; // 入力担当者コード
                        goodsUnitData.UpdEmployeeName = newExtractInfo.StockAgentName; // 入力担当者名
                        goodsUnitData.GoodsNo = dr[this._goodsStockDataTable.GoodsNoColumn.ColumnName].ToString(); // 品番
                        goodsUnitData.GoodsNoNoneHyphen = dr[this._goodsStockDataTable.GoodsNoColumn.ColumnName].ToString().Replace("-", string.Empty); // ハイフン無し品番
                        goodsUnitData.GoodsName = dr[this._goodsStockDataTable.GoodsNameColumn.ColumnName].ToString(); // 品名
                        goodsUnitData.GoodsMakerCd = (int)dr[this._goodsStockDataTable.GoodsMakerColumn.ColumnName]; // メーカーコード
                        goodsUnitData.MakerName = dr[this._goodsStockDataTable.GoodsMakerNameColumn.ColumnName].ToString(); // メーカー名
                        // --- UPD 2010/06/08 ---------->>>>>
                        //goodsUnitData.GoodsNameKana = dr[this._goodsStockDataTable.GoodsNameKanaColumn.ColumnName].ToString(); // 品名カナ
                        goodsUnitData.GoodsNameKana = dr[this._goodsStockDataTable.GoodsNameColumn.ColumnName].ToString(); // 品名カナ
                        // --- UPD 2010/06/08 ----------<<<<<
                        goodsUnitData.Jan = dr[this._goodsStockDataTable.JanColumn.ColumnName].ToString(); // JANコード
                        goodsUnitData.BLGoodsCode = ConvertToInt32FromGridValue(dr[this._goodsStockDataTable.BLGoodsCodeColumn.ColumnName]); // BLコード
                        goodsUnitData.BLGoodsName = dr[this._goodsStockDataTable.BLGoodsNameColumn.ColumnName].ToString(); // BLコード名
                        goodsUnitData.EnterpriseGanreCode = ConvertToInt32FromGridValue(dr[this._goodsStockDataTable.EnterpriseGanreCodeColumn.ColumnName]); // 自社分類コード
                        goodsUnitData.EnterpriseGanreName = dr[this._goodsStockDataTable.EnterpriseGanreNameColumn.ColumnName].ToString();
                        goodsUnitData.GoodsRateRank = dr[this._goodsStockDataTable.GoodsRateRankColumn.ColumnName].ToString();
                        goodsUnitData.GoodsKindCode = ConvertToInt32FromGridValue(dr[this._goodsStockDataTable.GoodsKindCodeColumn.ColumnName]);
                        goodsUnitData.TaxationDivCd = ConvertToInt32FromGridValue(dr[this._goodsStockDataTable.TaxationDivCdColumn.ColumnName]);
                        goodsUnitData.GoodsMGroup = ConvertToInt32FromGridValue(dr[this._goodsStockDataTable.GoodsMGroupColumn.ColumnName]);
                        goodsUnitData.GoodsMGroupName = dr[this._goodsStockDataTable.GoodsMGroupNameColumn.ColumnName].ToString();
                        goodsUnitData.BLGroupCode = ConvertToInt32FromGridValue(dr[this._goodsStockDataTable.BLGroupCodeColumn.ColumnName]);
                        goodsUnitData.BLGroupName = dr[this._goodsStockDataTable.BLGroupNameColumn.ColumnName].ToString();

                        updateFlg = true; // ADD 2009/02/04
                    }

                    // 価格情報
                    if (PriceUpdateCheck(goodsUnitData, dr))
                    {
                        goodsUnitData.GoodsPriceList = new List<GoodsPrice>();

                        List<GoodsPrice> goodsPriceList = MakeNewGoodsPriceList(dr);

                        if (goodsPriceList != null)
                        {
                            goodsUnitData.GoodsPriceList.AddRange(goodsPriceList);
                        }

                        updateFlg = true; // ADD 2009/02/04
                    }

                    // 在庫情報
                    // 同商品のGoodsStockリスト
                    DataRow[] drList = this._goodsStockDataTable.Select(
                        this._goodsStockDataTable.GoodsNoColumn.ColumnName
                        + " = '"
                        //+ dr[this._goodsStockDataTable.GoodsNoColumn.ColumnName].ToString()//DEL YANGMJ REDMINE#32095
                        + goodsNo//ADD YANGMJ 2012/09/11 REDMINE#32095
                        + "' AND "
                        + this._goodsStockDataTable.GoodsMakerColumn.ColumnName
                        + " = "
                        + dr[this._goodsStockDataTable.GoodsMakerColumn.ColumnName].ToString()
                        );

                    // 更新前に編集前在庫リストを作成
                    foreach (Stock prevStock in goodsUnitData.StockList)
                    {
                        prevStockList.Add(prevStock.Clone());
                    }

                    foreach (DataRow goodsStockDr in drList)
                    {
                        if (goodsStockDr[this._goodsStockDataTable.WarehouseCodeColumn.ColumnName] == null
                        || goodsStockDr[this._goodsStockDataTable.WarehouseCodeColumn.ColumnName] == DBNull.Value)
                        {
                            // 倉庫コードが無い行は処理対象外
                            continue;
                        }

                        if ((int)goodsStockDr[this._goodsStockDataTable.StockLogicalDeleteFlgColumn.ColumnName] != 0)
                        {
                            // 在庫論理既削除行
                            continue;
                        }

                        // 編集用の在庫情報
                        Stock originalStock = GetOriginalStock(goodsUnitData, goodsStockDr[this._goodsStockDataTable.WarehouseCodeColumn.ColumnName].ToString());

                        bool isNewStockRow = false;

                        if (originalStock == null)
                        {
                            // 新規在庫
                            originalStock = new Stock();
                            isNewStockRow = true;
                        }

                        //if (goodsStockDr[this._goodsStockDataTable.StockDeleteDateColumn.ColumnName] != null
                        //    && goodsStockDr[this._goodsStockDataTable.StockDeleteDateColumn.ColumnName] != DBNull.Value) // DEL 2009/02/05
                        if ((int)goodsStockDr[this._goodsStockDataTable.StockDeleteReserveFlgColumn.ColumnName] != 0) // ADD 2009/02/05
                        {
                            // 在庫削除予約行
                            originalStock.LogicalDeleteCode = 1;
                            originalStock.UpdateDate = DateTime.Today; // ADD 2015/01/14 田建委 Redmine#44473
                            updateFlg = true; // ADD 2009/02/04
                        }
                        else
                        {
                            if (StockUpdateCheck(originalStock, goodsStockDr))
                            {
                                originalStock.EnterpriseCode = this._enterpriseCode; // 企業コード
                                originalStock.UpdEmployeeCode = newExtractInfo.StockAgentCode; // 入力担当者コード
                                originalStock.UpdEmployeeName = newExtractInfo.StockAgentName; // 入力担当者名
                                originalStock.LogicalDeleteCode = 0; // 論理削除フラグ
                                if (isNewStockRow)
                                {
                                    originalStock.SectionCode = this.GetAddUpSectionCode(goodsStockDr[this._goodsStockDataTable.WarehouseCodeColumn.ColumnName].ToString()); // 管理拠点コード
                                    originalStock.GoodsNo = dr[this._goodsStockDataTable.GoodsNoColumn.ColumnName].ToString(); // 品番
                                    originalStock.GoodsNoNoneHyphen = goodsStockDr[this._goodsStockDataTable.GoodsNoColumn.ColumnName].ToString().Replace("-", string.Empty); // ハイフン無し品番
                                    originalStock.GoodsName = goodsStockDr[this._goodsStockDataTable.GoodsNameColumn.ColumnName].ToString(); // 品名
                                    originalStock.GoodsMakerCd = (int)goodsStockDr[this._goodsStockDataTable.GoodsMakerColumn.ColumnName]; // メーカーコード
                                    originalStock.MakerName = goodsStockDr[this._goodsStockDataTable.GoodsMakerNameColumn.ColumnName].ToString(); // メーカー名
                                    originalStock.WarehouseCode = goodsStockDr[this._goodsStockDataTable.WarehouseCodeColumn.ColumnName].ToString(); // 倉庫コード
                                    originalStock.WarehouseName = goodsStockDr[this._goodsStockDataTable.WarehouseNameColumn.ColumnName].ToString(); // 倉庫名
                                }
                                originalStock.WarehouseShelfNo = goodsStockDr[this._goodsStockDataTable.WarehouseShelfNoColumn.ColumnName].ToString(); // 棚番
                                originalStock.DuplicationShelfNo1 = goodsStockDr[this._goodsStockDataTable.DuplicationShelfNo1Column.ColumnName].ToString(); // 重複棚番
                                originalStock.DuplicationShelfNo2 = goodsStockDr[this._goodsStockDataTable.DuplicationShelfNo2Column.ColumnName].ToString(); // 重複棚番2
                                originalStock.PartsManagementDivide1 = goodsStockDr[this._goodsStockDataTable.PartsManagementDivide1Column.ColumnName].ToString(); // 管理区分1
                                originalStock.PartsManagementDivide2 = goodsStockDr[this._goodsStockDataTable.PartsManagementDivide2Column.ColumnName].ToString(); // 管理区分2
                                originalStock.StockSupplierCode = ConvertToInt32FromGridValue(goodsStockDr[this._goodsStockDataTable.StockSupplierCodeColumn.ColumnName]); // 発注先
                                originalStock.StockDiv = ConvertToInt32FromGridValue(goodsStockDr[this._goodsStockDataTable.StockDivColumn.ColumnName]); // 在庫区分
                                originalStock.SalesOrderUnit = ConvertToInt32FromGridValue(goodsStockDr[this._goodsStockDataTable.SalesOrderUnitColumn.ColumnName]); // 発注ロット
                                originalStock.MinimumStockCnt = ConvertToDoubleFromGridValue(goodsStockDr[this._goodsStockDataTable.MinimumStockCntColumn.ColumnName]); // 最低在庫数
                                originalStock.MaximumStockCnt = ConvertToDoubleFromGridValue(goodsStockDr[this._goodsStockDataTable.MaximumStockCntColumn.ColumnName]); // 最高在庫数
                                originalStock.SupplierStock = ConvertToDoubleFromGridValue(goodsStockDr[this._goodsStockDataTable.SupplierStockColumn.ColumnName]); // 仕入在庫
                                originalStock.ArrivalCnt = ConvertToDoubleFromGridValue(goodsStockDr[this._goodsStockDataTable.ArrivalCntColumn.ColumnName]); // 入荷数
                                originalStock.ShipmentCnt = ConvertToDoubleFromGridValue(goodsStockDr[this._goodsStockDataTable.ShipmentCntColumn.ColumnName]); // 出荷数
                                originalStock.AcpOdrCount = ConvertToDoubleFromGridValue(goodsStockDr[this._goodsStockDataTable.AcpOdrCountColumn.ColumnName]); // 受注数
                                originalStock.MovingSupliStock = ConvertToDoubleFromGridValue(goodsStockDr[this._goodsStockDataTable.MovingSupliStockColumn.ColumnName]);// 移動中仕入在庫数
                                // --- ADD 2009/03/05 -------------------------------->>>>>
                                originalStock.StockUnitPriceFl = ConvertToDoubleFromGridValue(goodsStockDr[this._goodsStockDataTable.StockUnitPriceFlColumn.ColumnName]); // 棚卸評価単価 // ADD 2009/03/05
                                // --- ADD 2009/03/05 --------------------------------<<<<<
                                if (originalStock.CreateDateTime == DateTime.MinValue)
                                {
                                    // 追加行の場合設定
                                    originalStock.CreateDateTime = DateTime.Today;
                                }
                                originalStock.UpdateDate = DateTime.Today;

                                if (isNewStockRow)
                                {
                                    // 追加行の場合、商品連結データに追加
                                    goodsUnitData.StockList.Add(originalStock);
                                }

                                updateFlg = true; // ADD 2009/02/04
                            }
                        }
                    }

                    // 掛率
                    Rate rate = GetOriginalRate(
                        dr[this._goodsStockDataTable.GoodsNoColumn.ColumnName].ToString(),
                        (int)dr[this._goodsStockDataTable.GoodsMakerColumn.ColumnName],
                        this._loginSectionCode);

                    if (RateUpdateCheck(rate, dr))
                    {
                        if (rate == null)
                        {
                            // 全社設定で読込み
                            //rate = GetOriginalAllSectionRate(
                            //    dr[this._goodsStockDataTable.GoodsNoColumn.ColumnName].ToString(), (int)dr[this._goodsStockDataTable.GoodsMakerColumn.ColumnName]); // DEL 2009/02/04
                            rate = GetOriginalRate(
                                dr[this._goodsStockDataTable.GoodsNoColumn.ColumnName].ToString(),
                                (int)dr[this._goodsStockDataTable.GoodsMakerColumn.ColumnName],
                                "00"); // ADD 2009/02/04

                            if (rate == null)
                            {
                                rate = new Rate();

                                rate.EnterpriseCode = this._enterpriseCode;
                                rate.SectionCode = this._loginSectionCode;
                                rate.UnitRateSetDivCd = CT_UnitRateSetDivCd; // 単価掛率設定区分
                                rate.UnitPriceKind = CT_UnitPriceKind; // 単価種類
                                rate.RateSettingDivide = CT_RateSettingDivide; // 掛率設定区分
                                rate.RateMngGoodsCd = CT_RateMngGoodsCd; // 掛率設定区分（商品）
                                rate.RateMngGoodsNm = CT_RateMngGoodsNm; // 掛率設定名称（商品）
                                rate.RateMngCustCd = CT_RateMngCustCd; // 掛率設定区分（得意先）
                                rate.RateMngCustNm = CT_RateMngCustNm; // 掛率設定名称（得意先）
                                rate.GoodsMakerCd = goodsUnitData.GoodsMakerCd;
                                rate.GoodsNo = goodsUnitData.GoodsNo;
                                rate.LotCount = CT_LotCount; // ロット数の初期値
                                rate.UnPrcFracProcUnit = CT_UnPrcFracProcUnit; // 単価端数処理単位
                                rate.UnPrcFracProcDiv = CT_UnPrcFracProcDiv; // 単価端数処理区分
                            }
                            // DEL 2010/01/08 MANTIS対応[14861]：掛率マスタ項目に値が設定されているレコードが更新できない ---------->>>>>
                            // FIXME:強制的にログイン拠点に変更しているので、削除
                            //else
                            //{
                            //    // 全社設定から拠点のみ変更
                            //    rate.SectionCode = this._loginSectionCode;
                            //}
                            // DEL 2010/01/08 MANTIS対応[14861]：掛率マスタ項目に値が設定されているレコードが更新できない ----------<<<<<
                        }

                        rate.PriceFl = this.ConvertToDoubleFromGridValue(dr[this._goodsStockDataTable.PriceFlColumn.ColumnName]);
                        rate.UpRate = this.ConvertToDoubleFromGridValue(dr[this._goodsStockDataTable.UpRateColumn.ColumnName]);

                        rateList.Add(rate);

                        updateFlg = true; // ADD 2009/02/04
                    }
                }
                #endregion
            }

            // --- ADD 2009/02/04 -------------------------------->>>>>
            if (updateFlg)
            {
                return (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            }
            else
            {
                // 更新対象がない商品
                return (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
            // --- ADD 2009/02/04 --------------------------------<<<<<
        }

        /// <summary>
        /// 更新用価格リスト作成処理
        /// </summary>
        /// <param name="dr"></param>
        /// <returns>価格開始日でソートされた価格リスト</returns>
        private List<GoodsPrice> MakeNewGoodsPriceList(DataRow dr)
        {
            // 価格開始日全て入力が無ければnullを返す
            if (
                (dr[this._goodsStockDataTable.PriceStartDate1Column.ColumnName] == null
                || dr[this._goodsStockDataTable.PriceStartDate1Column.ColumnName] == DBNull.Value)
                &&
                (dr[this._goodsStockDataTable.PriceStartDate2Column.ColumnName] == null
                || dr[this._goodsStockDataTable.PriceStartDate2Column.ColumnName] == DBNull.Value)
                &&
                (dr[this._goodsStockDataTable.PriceStartDate3Column.ColumnName] == null
                || dr[this._goodsStockDataTable.PriceStartDate3Column.ColumnName] == DBNull.Value)
                // --- ADD 2010/08/11 ---------->>>>>
                &&
                (dr[this._goodsStockDataTable.PriceStartDate4Column.ColumnName] == null
                || dr[this._goodsStockDataTable.PriceStartDate4Column.ColumnName] == DBNull.Value)
                &&
                (dr[this._goodsStockDataTable.PriceStartDate5Column.ColumnName] == null
                || dr[this._goodsStockDataTable.PriceStartDate5Column.ColumnName] == DBNull.Value)

                // --- ADD 2010/08/11 ----------<<<<<
                )
            {
                return null;
            }

            List<GoodsPrice> goodsPriceList = new List<GoodsPrice>();

            if (dr[this._goodsStockDataTable.PriceStartDate1Column.ColumnName] != null
                && dr[this._goodsStockDataTable.PriceStartDate1Column.ColumnName] != DBNull.Value)
            {
                GoodsPrice goodsPrice1 = new GoodsPrice();
                goodsPrice1.EnterpriseCode = this._enterpriseCode;
                goodsPrice1.GoodsMakerCd = this.ConvertToInt32FromGridValue(dr[this._goodsStockDataTable.GoodsMakerColumn.ColumnName]);
                goodsPrice1.GoodsNo = dr[this._goodsStockDataTable.GoodsNoColumn.ColumnName].ToString();
                goodsPrice1.PriceStartDate = this.ConvertDateTimeFromLongDate((int)dr[this._goodsStockDataTable.PriceStartDate1Column.ColumnName]);
                goodsPrice1.ListPrice = this.ConvertToDoubleFromGridValue(dr[this._goodsStockDataTable.ListPrice1Column.ColumnName]);
                goodsPrice1.OpenPriceDiv = this.ConvertToInt32FromGridValue(dr[this._goodsStockDataTable.OpenPriceDiv1Column.ColumnName]);
                goodsPrice1.StockRate = this.ConvertToDoubleFromGridValue(dr[this._goodsStockDataTable.StockRate1Column.ColumnName]);
                goodsPrice1.SalesUnitCost = this.ConvertToDoubleFromGridValue(dr[this._goodsStockDataTable.SalesUnitCost1Column.ColumnName]);
                // --- ADD 2010/08/31 ---------->>>>>
                if (dr[this._goodsStockDataTable.OfferDate1Column.ColumnName] != null && dr[this._goodsStockDataTable.OfferDate1Column.ColumnName] != DBNull.Value)
                {
                    goodsPrice1.OfferDate = this.ConvertDateTimeFromLongDate((int)dr[this._goodsStockDataTable.OfferDate1Column.ColumnName]);
                }
                // --- ADD 2010/08/31 ----------<<<<<

                goodsPriceList.Add(goodsPrice1);
            }

            if (dr[this._goodsStockDataTable.PriceStartDate2Column.ColumnName] != null
                && dr[this._goodsStockDataTable.PriceStartDate2Column.ColumnName] != DBNull.Value)
            {
                GoodsPrice goodsPrice2 = new GoodsPrice();
                goodsPrice2.EnterpriseCode = this._enterpriseCode;
                goodsPrice2.GoodsMakerCd = this.ConvertToInt32FromGridValue(dr[this._goodsStockDataTable.GoodsMakerColumn.ColumnName]);
                goodsPrice2.GoodsNo = dr[this._goodsStockDataTable.GoodsNoColumn.ColumnName].ToString();
                goodsPrice2.PriceStartDate = this.ConvertDateTimeFromLongDate((int)dr[this._goodsStockDataTable.PriceStartDate2Column.ColumnName]);
                goodsPrice2.ListPrice = this.ConvertToDoubleFromGridValue(dr[this._goodsStockDataTable.ListPrice2Column.ColumnName]);
                goodsPrice2.OpenPriceDiv = this.ConvertToInt32FromGridValue(dr[this._goodsStockDataTable.OpenPriceDiv2Column.ColumnName]);
                goodsPrice2.StockRate = this.ConvertToDoubleFromGridValue(dr[this._goodsStockDataTable.StockRate2Column.ColumnName]);
                goodsPrice2.SalesUnitCost = this.ConvertToDoubleFromGridValue(dr[this._goodsStockDataTable.SalesUnitCost2Column.ColumnName]);
                // --- ADD 2010/08/31 ---------->>>>>
                if (dr[this._goodsStockDataTable.OfferDate2Column.ColumnName] != null && dr[this._goodsStockDataTable.OfferDate2Column.ColumnName] != DBNull.Value)
                {
                    goodsPrice2.OfferDate = this.ConvertDateTimeFromLongDate((int)dr[this._goodsStockDataTable.OfferDate2Column.ColumnName]);
                }
                // --- ADD 2010/08/31 ----------<<<<<

                goodsPriceList.Add(goodsPrice2);
            }

            if (dr[this._goodsStockDataTable.PriceStartDate3Column.ColumnName] != null
                && dr[this._goodsStockDataTable.PriceStartDate3Column.ColumnName] != DBNull.Value)
            {
                GoodsPrice goodsPrice3 = new GoodsPrice();
                goodsPrice3.EnterpriseCode = this._enterpriseCode;
                goodsPrice3.GoodsMakerCd = this.ConvertToInt32FromGridValue(dr[this._goodsStockDataTable.GoodsMakerColumn.ColumnName]);
                goodsPrice3.GoodsNo = dr[this._goodsStockDataTable.GoodsNoColumn.ColumnName].ToString();
                goodsPrice3.PriceStartDate = this.ConvertDateTimeFromLongDate((int)dr[this._goodsStockDataTable.PriceStartDate3Column.ColumnName]);
                goodsPrice3.ListPrice = this.ConvertToDoubleFromGridValue(dr[this._goodsStockDataTable.ListPrice3Column.ColumnName]);
                goodsPrice3.OpenPriceDiv = this.ConvertToInt32FromGridValue(dr[this._goodsStockDataTable.OpenPriceDiv3Column.ColumnName]);
                goodsPrice3.StockRate = this.ConvertToDoubleFromGridValue(dr[this._goodsStockDataTable.StockRate3Column.ColumnName]);
                goodsPrice3.SalesUnitCost = this.ConvertToDoubleFromGridValue(dr[this._goodsStockDataTable.SalesUnitCost3Column.ColumnName]);
                // --- ADD 2010/08/31 ---------->>>>>
                if (dr[this._goodsStockDataTable.OfferDate3Column.ColumnName] != null && dr[this._goodsStockDataTable.OfferDate3Column.ColumnName] != DBNull.Value)
                {
                    goodsPrice3.OfferDate = this.ConvertDateTimeFromLongDate((int)dr[this._goodsStockDataTable.OfferDate3Column.ColumnName]);
                }
                // --- ADD 2010/08/31 ----------<<<<<

                goodsPriceList.Add(goodsPrice3);
            }

            // --- ADD 2010/08/11 ---------->>>>>
            if (dr[this._goodsStockDataTable.PriceStartDate4Column.ColumnName] != null
                && dr[this._goodsStockDataTable.PriceStartDate4Column.ColumnName] != DBNull.Value)
            {
                GoodsPrice goodsPrice4 = new GoodsPrice();
                goodsPrice4.EnterpriseCode = this._enterpriseCode;
                goodsPrice4.GoodsMakerCd = this.ConvertToInt32FromGridValue(dr[this._goodsStockDataTable.GoodsMakerColumn.ColumnName]);
                goodsPrice4.GoodsNo = dr[this._goodsStockDataTable.GoodsNoColumn.ColumnName].ToString();
                goodsPrice4.PriceStartDate = this.ConvertDateTimeFromLongDate((int)dr[this._goodsStockDataTable.PriceStartDate4Column.ColumnName]);
                goodsPrice4.ListPrice = this.ConvertToDoubleFromGridValue(dr[this._goodsStockDataTable.ListPrice4Column.ColumnName]);
                goodsPrice4.OpenPriceDiv = this.ConvertToInt32FromGridValue(dr[this._goodsStockDataTable.OpenPriceDiv4Column.ColumnName]);
                goodsPrice4.StockRate = this.ConvertToDoubleFromGridValue(dr[this._goodsStockDataTable.StockRate4Column.ColumnName]);
                goodsPrice4.SalesUnitCost = this.ConvertToDoubleFromGridValue(dr[this._goodsStockDataTable.SalesUnitCost4Column.ColumnName]);
                // --- ADD 2010/08/31 ---------->>>>>
                if (dr[this._goodsStockDataTable.OfferDate4Column.ColumnName] != null && dr[this._goodsStockDataTable.OfferDate4Column.ColumnName] != DBNull.Value)
                {
                    goodsPrice4.OfferDate = this.ConvertDateTimeFromLongDate((int)dr[this._goodsStockDataTable.OfferDate4Column.ColumnName]);
                }
                // --- ADD 2010/08/31 ----------<<<<<

                goodsPriceList.Add(goodsPrice4);
            }

            if (dr[this._goodsStockDataTable.PriceStartDate5Column.ColumnName] != null
                && dr[this._goodsStockDataTable.PriceStartDate5Column.ColumnName] != DBNull.Value)
            {
                GoodsPrice goodsPrice5 = new GoodsPrice();
                goodsPrice5.EnterpriseCode = this._enterpriseCode;
                goodsPrice5.GoodsMakerCd = this.ConvertToInt32FromGridValue(dr[this._goodsStockDataTable.GoodsMakerColumn.ColumnName]);
                goodsPrice5.GoodsNo = dr[this._goodsStockDataTable.GoodsNoColumn.ColumnName].ToString();
                goodsPrice5.PriceStartDate = this.ConvertDateTimeFromLongDate((int)dr[this._goodsStockDataTable.PriceStartDate5Column.ColumnName]);
                goodsPrice5.ListPrice = this.ConvertToDoubleFromGridValue(dr[this._goodsStockDataTable.ListPrice5Column.ColumnName]);
                goodsPrice5.OpenPriceDiv = this.ConvertToInt32FromGridValue(dr[this._goodsStockDataTable.OpenPriceDiv5Column.ColumnName]);
                goodsPrice5.StockRate = this.ConvertToDoubleFromGridValue(dr[this._goodsStockDataTable.StockRate5Column.ColumnName]);
                goodsPrice5.SalesUnitCost = this.ConvertToDoubleFromGridValue(dr[this._goodsStockDataTable.SalesUnitCost5Column.ColumnName]);
                // --- ADD 2010/08/31 ---------->>>>>
                if (dr[this._goodsStockDataTable.OfferDate5Column.ColumnName] != null && dr[this._goodsStockDataTable.OfferDate5Column.ColumnName] != DBNull.Value)
                {
                    goodsPrice5.OfferDate = this.ConvertDateTimeFromLongDate((int)dr[this._goodsStockDataTable.OfferDate5Column.ColumnName]);
                }
                // --- ADD 2010/08/31 ----------<<<<<

                goodsPriceList.Add(goodsPrice5);
            }

            // --- ADD 2010/08/11 ----------<<<<<

            // 開始日でソート
            goodsPriceList.Sort(ComparisonByPriceStartDate);

            return goodsPriceList;
        }

        /// <summary>
        /// 開始日ソート設定
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private int ComparisonByPriceStartDate(GoodsPrice x, GoodsPrice y)
        {
            if (x == null)
            {
                if (y == null)
                {
                    return 0;
                }
                else
                {
                    return -1;
                }
            }
            else
            {
                if (y == null)
                {
                    return 1;
                }
                else
                {
                    return x.PriceStartDate.CompareTo(y.PriceStartDate);
                }
            }
        }

        /// <summary>
        /// 更新有無チェック処理(商品)
        /// </summary>
        /// <param name="originalGoodsUnitData">変更前の商品連結データ</param>
        /// <param name="goodsStockRow">商品在庫データ（変更後）</param>
        /// <returns>true:更新あり、false：更新なし</returns>
        /// <remarks>
        /// <br>UpdateNote       : 2010/06/08 高峰 障害・改良対応（７月リリース案件）</br>
        /// </remarks>
        private bool GoodsUpdateCheck(GoodsUnitData originalGoodsUnitData, DataRow goodsStockRow)
        {
            if (originalGoodsUnitData == null)
            {
                return true;
            }

            // 商品情報チェック
            if (originalGoodsUnitData.GoodsNameKana
                != goodsStockRow[this._goodsStockDataTable.GoodsNameKanaColumn.ColumnName].ToString()
                ||
                originalGoodsUnitData.Jan
                != goodsStockRow[this._goodsStockDataTable.JanColumn.ColumnName].ToString()
                ||
                originalGoodsUnitData.BLGoodsCode
                != ConvertToInt32FromGridValue(goodsStockRow[this._goodsStockDataTable.BLGoodsCodeColumn.ColumnName])
                ||
                originalGoodsUnitData.EnterpriseGanreCode
                != ConvertToInt32FromGridValue(goodsStockRow[this._goodsStockDataTable.EnterpriseGanreCodeColumn.ColumnName])
                ||
                originalGoodsUnitData.GoodsRateRank
                != goodsStockRow[this._goodsStockDataTable.GoodsRateRankColumn.ColumnName].ToString()
                ||
                originalGoodsUnitData.GoodsKindCode
                != ConvertToInt32FromGridValue(goodsStockRow[this._goodsStockDataTable.GoodsKindCodeColumn.ColumnName])
                ||
                originalGoodsUnitData.TaxationDivCd
                != ConvertToInt32FromGridValue(goodsStockRow[this._goodsStockDataTable.TaxationDivCdColumn.ColumnName])
                // --- ADD 2010/06/08 ---------->>>>>
                ||
                originalGoodsUnitData.GoodsName
                != goodsStockRow[this._goodsStockDataTable.GoodsNameColumn.ColumnName].ToString()
                // --- ADD 2010/06/08 ----------<<<<<
                )
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// 更新有無チェック処理(価格)
        /// </summary>
        /// <param name="originalGoodsUnitData">変更前の商品連結データ</param>
        /// <param name="goodsStockRow">商品在庫データ（変更後）</param>
        /// <returns>true:更新あり、false：更新なし</returns>
        private bool PriceUpdateCheck(GoodsUnitData originalGoodsUnitData, DataRow goodsStockRow)
        {
            if (originalGoodsUnitData == null)
            {
                return true;
            }

            // 価格リストが存在する
            if (originalGoodsUnitData.GoodsPriceList != null
                && originalGoodsUnitData.GoodsPriceList.Count != 0)
            {
                if (
                    goodsStockRow[this._goodsStockDataTable.PriceStartDate1Column.ColumnName] == null
                    ||
                    goodsStockRow[this._goodsStockDataTable.PriceStartDate1Column.ColumnName] == DBNull.Value
                    ||
                    originalGoodsUnitData.GoodsPriceList[0].PriceStartDate
                    != ConvertDateTimeFromLongDate((int)goodsStockRow[this._goodsStockDataTable.PriceStartDate1Column.ColumnName])
                    ||
                    originalGoodsUnitData.GoodsPriceList[0].ListPrice
                    != ConvertToDoubleFromGridValue(goodsStockRow[this._goodsStockDataTable.ListPrice1Column.ColumnName])
                    ||
                    originalGoodsUnitData.GoodsPriceList[0].OpenPriceDiv
                    != ConvertToInt32FromGridValue(goodsStockRow[this._goodsStockDataTable.OpenPriceDiv1Column.ColumnName])
                    ||
                    originalGoodsUnitData.GoodsPriceList[0].StockRate
                    != ConvertToDoubleFromGridValue(goodsStockRow[this._goodsStockDataTable.StockRate1Column.ColumnName])
                    ||
                    originalGoodsUnitData.GoodsPriceList[0].SalesUnitCost
                    != ConvertToDoubleFromGridValue(goodsStockRow[this._goodsStockDataTable.SalesUnitCost1Column.ColumnName])
                    )
                {
                    // 価格リストが削除されている場合もこちらに該当する
                    return true;
                }

                if (originalGoodsUnitData.GoodsPriceList.Count > 1)
                {
                    if (
                        goodsStockRow[this._goodsStockDataTable.PriceStartDate2Column.ColumnName] == null
                    || 
                    goodsStockRow[this._goodsStockDataTable.PriceStartDate2Column.ColumnName] == DBNull.Value
                    ||
                    originalGoodsUnitData.GoodsPriceList[1].PriceStartDate
                    != ConvertDateTimeFromLongDate((int)goodsStockRow[this._goodsStockDataTable.PriceStartDate2Column.ColumnName])
                    ||
                    originalGoodsUnitData.GoodsPriceList[1].ListPrice
                    != ConvertToDoubleFromGridValue(goodsStockRow[this._goodsStockDataTable.ListPrice2Column.ColumnName])
                    ||
                    originalGoodsUnitData.GoodsPriceList[1].OpenPriceDiv
                    != ConvertToInt32FromGridValue(goodsStockRow[this._goodsStockDataTable.OpenPriceDiv2Column.ColumnName])
                    ||
                    originalGoodsUnitData.GoodsPriceList[1].StockRate
                    != ConvertToDoubleFromGridValue(goodsStockRow[this._goodsStockDataTable.StockRate2Column.ColumnName])
                    ||
                    originalGoodsUnitData.GoodsPriceList[1].SalesUnitCost
                    != ConvertToDoubleFromGridValue(goodsStockRow[this._goodsStockDataTable.SalesUnitCost2Column.ColumnName])
                    )
                    {
                        return true;
                    }
                }
                else
                {
                    if (ConvertToInt32FromGridValue(goodsStockRow[this._goodsStockDataTable.PriceStartDate2Column.ColumnName]) != 0)
                    {
                        return true;
                    }
                }

                if (originalGoodsUnitData.GoodsPriceList.Count > 2)
                {
                    if (
                        goodsStockRow[this._goodsStockDataTable.PriceStartDate3Column.ColumnName] == null
                    || 
                    goodsStockRow[this._goodsStockDataTable.PriceStartDate3Column.ColumnName] == DBNull.Value
                    ||
                    originalGoodsUnitData.GoodsPriceList[2].PriceStartDate
                    != ConvertDateTimeFromLongDate((int)goodsStockRow[this._goodsStockDataTable.PriceStartDate3Column.ColumnName])
                    ||
                    originalGoodsUnitData.GoodsPriceList[2].ListPrice
                    != ConvertToDoubleFromGridValue(goodsStockRow[this._goodsStockDataTable.ListPrice3Column.ColumnName])
                    ||
                    originalGoodsUnitData.GoodsPriceList[2].OpenPriceDiv
                    != ConvertToInt32FromGridValue(goodsStockRow[this._goodsStockDataTable.OpenPriceDiv3Column.ColumnName])
                    ||
                    originalGoodsUnitData.GoodsPriceList[2].StockRate
                    != ConvertToDoubleFromGridValue(goodsStockRow[this._goodsStockDataTable.StockRate3Column.ColumnName])
                    ||
                    originalGoodsUnitData.GoodsPriceList[2].SalesUnitCost
                    != ConvertToDoubleFromGridValue(goodsStockRow[this._goodsStockDataTable.SalesUnitCost3Column.ColumnName])
                    )
                    {
                        return true;
                    }
                }
                else
                {
                    if (ConvertToInt32FromGridValue(goodsStockRow[this._goodsStockDataTable.PriceStartDate3Column.ColumnName]) != 0)
                    {
                        return true;
                    }
                }

                // --- ADD 2010/08/11 ---------->>>>>
                if (originalGoodsUnitData.GoodsPriceList.Count > 3)
                {
                    if (
                        goodsStockRow[this._goodsStockDataTable.PriceStartDate3Column.ColumnName] == null
                    ||
                    goodsStockRow[this._goodsStockDataTable.PriceStartDate3Column.ColumnName] == DBNull.Value
                    ||
                    originalGoodsUnitData.GoodsPriceList[3].PriceStartDate
                    != ConvertDateTimeFromLongDate((int)goodsStockRow[this._goodsStockDataTable.PriceStartDate4Column.ColumnName])
                    ||
                    originalGoodsUnitData.GoodsPriceList[3].ListPrice
                    != ConvertToDoubleFromGridValue(goodsStockRow[this._goodsStockDataTable.ListPrice4Column.ColumnName])
                    ||
                    originalGoodsUnitData.GoodsPriceList[3].OpenPriceDiv
                    != ConvertToInt32FromGridValue(goodsStockRow[this._goodsStockDataTable.OpenPriceDiv4Column.ColumnName])
                    ||
                    originalGoodsUnitData.GoodsPriceList[3].StockRate
                    != ConvertToDoubleFromGridValue(goodsStockRow[this._goodsStockDataTable.StockRate4Column.ColumnName])
                    ||
                    originalGoodsUnitData.GoodsPriceList[3].SalesUnitCost
                    != ConvertToDoubleFromGridValue(goodsStockRow[this._goodsStockDataTable.SalesUnitCost4Column.ColumnName])
                    )
                    {
                        return true;
                    }
                }
                else
                {
                    if (ConvertToInt32FromGridValue(goodsStockRow[this._goodsStockDataTable.PriceStartDate4Column.ColumnName]) != 0)
                    {
                        return true;
                    }
                }

                if (originalGoodsUnitData.GoodsPriceList.Count > 4)
                {
                    if (
                        goodsStockRow[this._goodsStockDataTable.PriceStartDate3Column.ColumnName] == null
                    ||
                    goodsStockRow[this._goodsStockDataTable.PriceStartDate3Column.ColumnName] == DBNull.Value
                    ||
                    originalGoodsUnitData.GoodsPriceList[4].PriceStartDate
                    != ConvertDateTimeFromLongDate((int)goodsStockRow[this._goodsStockDataTable.PriceStartDate5Column.ColumnName])
                    ||
                    originalGoodsUnitData.GoodsPriceList[4].ListPrice
                    != ConvertToDoubleFromGridValue(goodsStockRow[this._goodsStockDataTable.ListPrice5Column.ColumnName])
                    ||
                    originalGoodsUnitData.GoodsPriceList[4].OpenPriceDiv
                    != ConvertToInt32FromGridValue(goodsStockRow[this._goodsStockDataTable.OpenPriceDiv5Column.ColumnName])
                    ||
                    originalGoodsUnitData.GoodsPriceList[4].StockRate
                    != ConvertToDoubleFromGridValue(goodsStockRow[this._goodsStockDataTable.StockRate5Column.ColumnName])
                    ||
                    originalGoodsUnitData.GoodsPriceList[4].SalesUnitCost
                    != ConvertToDoubleFromGridValue(goodsStockRow[this._goodsStockDataTable.SalesUnitCost5Column.ColumnName])
                    )
                    {
                        return true;
                    }
                }
                else
                {
                    if (ConvertToInt32FromGridValue(goodsStockRow[this._goodsStockDataTable.PriceStartDate5Column.ColumnName]) != 0)
                    {
                        return true;
                    }
                }


                // --- ADD 2010/08/11 ----------<<<<<
            }
            else
            {
                if (ConvertToInt32FromGridValue(goodsStockRow[this._goodsStockDataTable.PriceStartDate1Column.ColumnName]) != 0)
                {
                    return true;
                }
            }

            return false;
        }
        
        /// <summary>
        /// 更新有無チェック処理(掛率)
        /// </summary>
        /// <param name="originalGoodsUnitData">変更前の掛率</param>
        /// <param name="goodsStockRow">商品在庫データ（変更後）</param>
        /// <returns>true:更新あり、false：更新なし</returns>
        private bool RateUpdateCheck(Rate originalRate, DataRow goodsStockRow)
        {
            if (originalRate == null)
            {
                if (ConvertToDoubleFromGridValue(goodsStockRow[this._goodsStockDataTable.PriceFlColumn.ColumnName]) != 0
                    ||
                    ConvertToDoubleFromGridValue(goodsStockRow[this._goodsStockDataTable.UpRateColumn.ColumnName]) != 0)
                {
                    // 新規作成
                    return true;
                }
                else
                {
                    // 作成しない
                    return false;
                }
            }

            if (originalRate.PriceFl
                != ConvertToDoubleFromGridValue(goodsStockRow[this._goodsStockDataTable.PriceFlColumn.ColumnName])
                ||
                originalRate.UpRate
                != ConvertToDoubleFromGridValue(goodsStockRow[this._goodsStockDataTable.UpRateColumn.ColumnName])
                )
            {
                // 値が変わっている場合、要更新
                return true;
            }

            return false;
        }

        /// <summary>
        /// 更新有無チェック処理(在庫)
        /// </summary>
        /// <param name="originalGoodsUnitData">変更前の在庫</param>
        /// <param name="goodsStockRow">商品在庫データ（変更後）</param>
        /// <returns>true:更新あり、false：更新なし</returns>
        private bool StockUpdateCheck(Stock originalStock, DataRow goodsStockRow)
        {
            if (
                originalStock.WarehouseCode
                != goodsStockRow[this._goodsStockDataTable.WarehouseCodeColumn.ColumnName].ToString()
                ||
                originalStock.WarehouseShelfNo
                != goodsStockRow[this._goodsStockDataTable.WarehouseShelfNoColumn.ColumnName].ToString()
                ||
                originalStock.DuplicationShelfNo1
                != goodsStockRow[this._goodsStockDataTable.DuplicationShelfNo1Column.ColumnName].ToString()
                ||
                originalStock.DuplicationShelfNo2
                != goodsStockRow[this._goodsStockDataTable.DuplicationShelfNo2Column.ColumnName].ToString()
                ||
                originalStock.PartsManagementDivide1
                != goodsStockRow[this._goodsStockDataTable.PartsManagementDivide1Column.ColumnName].ToString()
                ||
                originalStock.PartsManagementDivide2
                != goodsStockRow[this._goodsStockDataTable.PartsManagementDivide2Column.ColumnName].ToString()
                ||
                originalStock.StockSupplierCode
                != ConvertToInt32FromGridValue(goodsStockRow[this._goodsStockDataTable.StockSupplierCodeColumn.ColumnName])
                ||
                originalStock.StockDiv
                != ConvertToInt32FromGridValue(goodsStockRow[this._goodsStockDataTable.StockDivColumn.ColumnName])
                ||
                originalStock.SalesOrderUnit
                != ConvertToInt32FromGridValue(goodsStockRow[this._goodsStockDataTable.SalesOrderUnitColumn.ColumnName])
                ||
                originalStock.MaximumStockCnt
                != ConvertToDoubleFromGridValue(goodsStockRow[this._goodsStockDataTable.MaximumStockCntColumn.ColumnName])
                ||
                originalStock.MinimumStockCnt
                != ConvertToDoubleFromGridValue(goodsStockRow[this._goodsStockDataTable.MinimumStockCntColumn.ColumnName])
                ||
                originalStock.SupplierStock
                != ConvertToDoubleFromGridValue(goodsStockRow[this._goodsStockDataTable.SupplierStockColumn.ColumnName])
                ||
                originalStock.ArrivalCnt
                != ConvertToDoubleFromGridValue(goodsStockRow[this._goodsStockDataTable.ArrivalCntColumn.ColumnName])
                ||
                originalStock.ShipmentCnt
                != ConvertToDoubleFromGridValue(goodsStockRow[this._goodsStockDataTable.ShipmentCntColumn.ColumnName])
                ||
                originalStock.AcpOdrCount
                != ConvertToDoubleFromGridValue(goodsStockRow[this._goodsStockDataTable.AcpOdrCountColumn.ColumnName])
                ||
                originalStock.MovingSupliStock
                != ConvertToDoubleFromGridValue(goodsStockRow[this._goodsStockDataTable.MovingSupliStockColumn.ColumnName])
                // --- ADD 2009/03/05 -------------------------------->>>>>
                ||
                originalStock.StockUnitPriceFl
                != ConvertToDoubleFromGridValue(goodsStockRow[this._goodsStockDataTable.StockUnitPriceFlColumn.ColumnName]) // ADD 2009/03/05
                // --- ADD 2009/03/05 --------------------------------<<<<<
                )
            {
                return true;
            }

            return false;

        }

        /// <summary>
        /// 管理拠点取得処理
        /// </summary>
        /// <param name="warehouseCode"></param>
        private string GetAddUpSectionCode(string warehouseCode)
        {
            Warehouse warehouse;

            int status = this._warehouseAcs.Read(out warehouse, this._enterpriseCode, string.Empty, warehouseCode);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                return warehouse.SectionCode;
            }

            return string.Empty;
        }

        #endregion

        #region ■ その他処理

        /// <summary>
        /// 指定したキーに該当する更新前商品連結データを取得する
        /// </summary>
        /// <param name="goodsNo"></param>
        /// <param name="goodsMakerCd"></param>
        /// <returns></returns>
        private GoodsUnitData GetOriginalGoodsUnitData(string goodsNo, int goodsMakerCd)
        {
            if (this._originalGoodsUnitDataList == null)
            {
                // 新規-商品でグリッド表示なしで商品追加した場合のみ
                return null;
            }
            // --- DEL 2009/02/16 -------------------------------->>>>>
            //foreach (GoodsUnitData goodsUnitData in this._originalGoodsUnitDataList)
            //{
            //    if (goodsUnitData.GoodsNo == goodsNo && goodsUnitData.GoodsMakerCd == goodsMakerCd)
            //    {
            //        return goodsUnitData;
            //    }
            //}

            //return null;
            // --- DEL 2009/02/16 --------------------------------<<<<<
            // --- ADD 2009/02/16 -------------------------------->>>>>
            GoodsUnitData goodsUnitData = null;

            goodsUnitData = this._originalGoodsUnitDataList.Find(
                delegate(GoodsUnitData orgGoodsUnitData)
                {
                    if (orgGoodsUnitData.GoodsNo == goodsNo
                        && orgGoodsUnitData.GoodsMakerCd == goodsMakerCd)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            );

            return goodsUnitData;
            // --- ADD 2009/02/16 --------------------------------<<<<<
        }

        /// <summary>
        /// 指定したキーに該当する掛率データ(ログイン拠点)を取得する
        /// </summary>
        /// <param name="goodsNo"></param>
        /// <param name="goodsMakerCd"></param>
        /// <param name="sectionCd"></param>
        /// <returns></returns>
        private Rate GetOriginalRate(string goodsNo, int goodsMakerCd, string sectionCd)
        {
            // --- DEL 2009/02/16 -------------------------------->>>>>
            //foreach (Rate rate in this._originalRateList)
            //{
            //    if (rate.GoodsNo == goodsNo
            //        && rate.GoodsMakerCd == goodsMakerCd)
            //    {
            //        return rate;
            //    }
            //}

            //return null;
            // --- DEL 2009/02/16 --------------------------------<<<<<

            // --- ADD 2009/02/16 -------------------------------->>>>>
            Rate rate;
            rate = this._originalRateList.Find(
                delegate(Rate orgRate)
                {
                    if ((orgRate.GoodsNo == goodsNo) &&
                        (orgRate.GoodsMakerCd == goodsMakerCd) &&
                        (orgRate.SectionCode.TrimEnd() == sectionCd.TrimEnd()))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            );

            return rate;
            // --- ADD 2009/02/16 -------------------------------->>>>>
        }

        // --- DEL 2009/02/04 -------------------------------->>>>>
        ///// <summary>
        ///// 指定したキーに該当する掛率データ（全社設定）を取得する
        ///// </summary>
        ///// <param name="goodsNo"></param>
        ///// <param name="goodsMakerCd"></param>
        ///// <returns></returns>
        //private Rate GetOriginalAllSectionRate(string goodsNo, int goodsMakerCd)
        //{
        //    foreach (Rate rate in this._originalAllSectionRateList)
        //    {
        //        if (rate.GoodsNo == goodsNo
        //            && rate.GoodsMakerCd == goodsMakerCd)
        //        {
        //            return rate;
        //        }
        //    }

        //    return null;
        //}
        // --- DEL 2009/02/04 --------------------------------<<<<<

        /// <summary>
        /// 指定したキーに該当する在庫データを取得する
        /// </summary>
        /// <param name="goodsUnitData"></param>
        /// <param name="warehouseCd"></param>
        /// <returns></returns>
        private Stock GetOriginalStock(GoodsUnitData goodsUnitData, string warehouseCd)
        {
            if (goodsUnitData.StockList == null
                || goodsUnitData.StockList.Count == 0)
            {
                return null;
            }

            // --- DEL 2009/02/16 -------------------------------->>>>>
            //foreach (Stock stock in goodsUnitData.StockList)
            //{
            //    if (stock.WarehouseCode == warehouseCd)
            //    {
            //        return stock;
            //    }
            //}

            //return null;
            // --- DEL 2009/02/16 --------------------------------<<<<<
            // --- ADD 2009/02/16 -------------------------------->>>>>
            Stock stock = null;

            stock = goodsUnitData.StockList.Find(
                delegate(Stock orgStock)
                {
                    if (orgStock.WarehouseCode == warehouseCd)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            );

            return stock;
            // --- ADD 2009/02/16 --------------------------------<<<<<
        }

        /// <summary>
        /// 行番号設定
        /// </summary>
        private void SetRowNumber(ExtractInfo extractInfo)
        {
            // --- DEL 2009/03/06 -------------------------------->>>>>
            //for (int i = 0; i < this._goodsStockDataTable.Rows.Count; i++)
            //{
            //    this._goodsStockDataTable
            //        .Rows[i][this._goodsStockDataTable.RowNumberColumn.ColumnName] = i + 1;
            //}
            // --- DEL 2009/03/06 --------------------------------<<<<<
            // --- ADD 2009/03/06 -------------------------------->>>>>
            if (extractInfo.DisplayDiv == ExtractInfo.DisplayDivState.New
                && extractInfo.TargetDiv == ExtractInfo.TargetDivState.Goods)
            {
                // 表示区分「新規登録」-対象区分「商品」
                // 論理削除行はありえない
                for (int i = 0; i < this._goodsStockDataTable.Rows.Count; i++)
                {
                    this._goodsStockDataTable
                        .Rows[i][this._goodsStockDataTable.RowNumberColumn.ColumnName] = i + 1;
                    this._goodsStockDataTable
                        .Rows[i][this._goodsStockDataTable.RowIndexColumn.ColumnName] = i + 1;
                }
            }
            else if (extractInfo.DisplayDiv == ExtractInfo.DisplayDivState.Update
           && extractInfo.TargetDiv == ExtractInfo.TargetDivState.Goods)
            {
                // 表示区分「修正登録」-対象区分「商品」
                // 商品の論理削除を除外
                int deleteRowIndex = 0;
                for (int i = 0; i < this._goodsStockDataTable.Rows.Count; i++)
                {
                    if ((int)this._goodsStockDataTable
                        .Rows[i][this._goodsStockDataTable.GoodsLogicalDeleteFlgColumn.ColumnName] == 0)
                    {
                        this._goodsStockDataTable
                            .Rows[i][this._goodsStockDataTable.RowNumberColumn.ColumnName] = deleteRowIndex + 1;
                        this._goodsStockDataTable
                            .Rows[i][this._goodsStockDataTable.RowIndexColumn.ColumnName] = deleteRowIndex + 1;

                        deleteRowIndex++;
                    }
                }

                for (int i = 0; i < this._goodsStockDataTable.Rows.Count; i++)
                {
                    if ((int)this._goodsStockDataTable
                        .Rows[i][this._goodsStockDataTable.GoodsLogicalDeleteFlgColumn.ColumnName] != 0)
                    {
                        this._goodsStockDataTable
                            .Rows[i][this._goodsStockDataTable.RowNumberColumn.ColumnName] = "-";
                        this._goodsStockDataTable
                            .Rows[i][this._goodsStockDataTable.RowIndexColumn.ColumnName] = deleteRowIndex + 1;

                        deleteRowIndex++;
                    } 
                }
            }
            else if (extractInfo.DisplayDiv == ExtractInfo.DisplayDivState.Update
                && extractInfo.TargetDiv == ExtractInfo.TargetDivState.GoodsStock)
            {
                // 表示区分「修正登録」-対象区分「商品-在庫」
                // 商品、在庫の論理削除を除外
                int deleteRowIndex = 0;
                for (int i = 0; i < this._goodsStockDataTable.Rows.Count; i++)
                {
                    if ((int)this._goodsStockDataTable
                        .Rows[i][this._goodsStockDataTable.GoodsLogicalDeleteFlgColumn.ColumnName] == 0
                        &&
                        (int)this._goodsStockDataTable
                        .Rows[i][this._goodsStockDataTable.StockLogicalDeleteFlgColumn.ColumnName] == 0
                        )
                    {
                        this._goodsStockDataTable
                            .Rows[i][this._goodsStockDataTable.RowNumberColumn.ColumnName] = deleteRowIndex + 1;
                        this._goodsStockDataTable
                            .Rows[i][this._goodsStockDataTable.RowIndexColumn.ColumnName] = deleteRowIndex + 1;

                        deleteRowIndex++;
                    }
                }

                for (int i = 0; i < this._goodsStockDataTable.Rows.Count; i++)
                {
                    if ((int)this._goodsStockDataTable
                        .Rows[i][this._goodsStockDataTable.GoodsLogicalDeleteFlgColumn.ColumnName] != 0
                        ||
                        (int)this._goodsStockDataTable
                        .Rows[i][this._goodsStockDataTable.StockLogicalDeleteFlgColumn.ColumnName] != 0
                        )
                    {
                        this._goodsStockDataTable
                            .Rows[i][this._goodsStockDataTable.RowNumberColumn.ColumnName] = "-";
                        this._goodsStockDataTable
                            .Rows[i][this._goodsStockDataTable.RowIndexColumn.ColumnName] = deleteRowIndex + 1;

                        deleteRowIndex++;
                    }
                }
            }
            else
            {
                // 対象区分「在庫」「在庫-商品」
                // 在庫の論理削除を除外(商品の論理削除は除かれている)
                int deleteRowIndex = 0;
                for (int i = 0; i < this._goodsStockDataTable.Rows.Count; i++)
                {
                    if ((int)this._goodsStockDataTable
                        .Rows[i][this._goodsStockDataTable.StockLogicalDeleteFlgColumn.ColumnName] == 0)
                    {
                        this._goodsStockDataTable
                            .Rows[i][this._goodsStockDataTable.RowNumberColumn.ColumnName] = deleteRowIndex + 1;
                        this._goodsStockDataTable
                            .Rows[i][this._goodsStockDataTable.RowIndexColumn.ColumnName] = deleteRowIndex + 1;

                        deleteRowIndex++;
                    }
                }

                for (int i = 0; i < this._goodsStockDataTable.Rows.Count; i++)
                {
                    if ((int)this._goodsStockDataTable
                        .Rows[i][this._goodsStockDataTable.StockLogicalDeleteFlgColumn.ColumnName] != 0)
                    {
                        this._goodsStockDataTable
                            .Rows[i][this._goodsStockDataTable.RowNumberColumn.ColumnName] = "-";
                        this._goodsStockDataTable
                            .Rows[i][this._goodsStockDataTable.RowIndexColumn.ColumnName] = deleteRowIndex + 1;

                        deleteRowIndex++;
                    }
                }
            }

            // --- ADD 2009/03/06 --------------------------------<<<<<
        }

        /// <summary>
        /// DateTime⇒LongDate(8桁)の変換処理
        /// </summary>
        /// <returns></returns>
        private Int32 ConvertLongDateFromDateTime(DateTime date)
        {
            return date.Year * 10000 + date.Month * 100 + date.Day;
        }

        /// <summary>
        /// LongDate(8桁)⇒DateTimeの変換処理
        /// </summary>
        /// <returns></returns>
        private DateTime ConvertDateTimeFromLongDate(Int32 date)
        {
            int year = date / 10000;
            int month = (date / 100) % 100;
            int day = date % 100;

            return new DateTime(year, month, day);
        }


        /// <summary>
        /// DBNullを含む項目の数値変換処理(整数用)
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        private Int32 ConvertToInt32FromGridValue(object obj)
        {
            if (obj == null || obj == DBNull.Value)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        } 

        /// <summary>
        /// DBNullを含む項目の数値変換処理(整数用)
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        private double ConvertToDoubleFromGridValue(object obj)
        {
            if (obj == null || obj == DBNull.Value)
            {
                return 0;
            }
            else
            {
                return Convert.ToDouble(obj);
            }
        }
        #endregion

        #endregion
    }
}
