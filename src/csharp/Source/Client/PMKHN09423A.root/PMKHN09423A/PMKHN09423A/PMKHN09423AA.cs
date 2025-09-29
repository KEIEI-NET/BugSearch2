//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : ユーザー価格・原価一括設定
// プログラム概要   : ユーザー価格・原価を複数件一括で修正・登録する。
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 劉洋
// 作 成 日  2009/05/06  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日               修正内容 : 
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using System.Collections;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// ユーザー価格・原価一括設定フォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : ユーザー価格・原価一括設定のフォームクラスです。</br>
    /// <br>Programmer : 劉洋</br>
    /// <br>Date       : 2009.05.05</br>
    /// <br></br>
    /// <br>UpDate</br>
    /// <br>2008.05.21 men 新規作成(DC.NSから流用)</br>
    /// </remarks>
    public class UserPriceInputAcs
    {
        // ===================================================================================== //
        // コンストラクタ
        // ===================================================================================== //
        # region ■Constructor
        /// <summary>
        /// デフォルトコンストラクタ（Singletonデザインパターンを採用している為、privateとする）
        /// </summary>
        /// <remarks>
        /// <br>Note       : なし。</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.05.05</br>
        /// </remarks>
        private UserPriceInputAcs()
        {
            this._userPriceData = new UserPriceData();
            this._userPriceSaveData = new UserPriceData();
            this._userPriceDataTable = new UserPriceDataSet.UserPriceDataTable();
            this._userPriceCopyDataTable = new UserPriceDataSet.UserPriceDataTable();
            this._taxRateSetAcs = new TaxRateSetAcs();
            this._unitPriceCalculation = new UnitPriceCalculation();
            this._rateAcs = new RateAcs();

            ReadTaxRate();

            try
            {
                // リモートオブジェクト取得
                this._userPriceDB = (IUserPriceDB)MediationUserPriceDB.GetUserPriceDB();
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._userPriceDB = null;
            }

            try
            {
                // リモートオブジェクト取得
                this._goodsPriceUDB = (IGoodsPriceUDB)MediationGoodsPriceUDB.GetGoodsPriceUDB();
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._goodsPriceUDB = null;
            }
        }

        /// <summary>
        /// 入力アクセスクラス インスタンス取得処理
        /// </summary>
        /// <returns>入力アクセスクラス インスタンス</returns>
        /// <remarks>
        /// <br>Note       : なし。</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.05.05</br>
        /// </remarks>
        public static UserPriceInputAcs GetInstance()
        {
            if (_userPriceInputAcs == null)
            {
                _userPriceInputAcs = new UserPriceInputAcs();
            }

            return _userPriceInputAcs;
        }
        #endregion

        // ===================================================================================== //
        // プライベート変数2
        // ===================================================================================== //
        # region ■Private Members
        private UserPriceData _userPriceData;
        private UserPriceData _userPriceSaveData;
        private static UserPriceInputAcs _userPriceInputAcs;
        private UserPriceDataSet.UserPriceDataTable _userPriceDataTable;
        private TaxRateSetAcs _taxRateSetAcs;           // 税率設定マスタアクセスクラス
        private TaxRateSet _taxRateSet;
        private UnitPriceCalculation _unitPriceCalculation;
        private ArrayList rateList = new ArrayList();
        private ArrayList goodsPriceUList = new ArrayList();
        private ArrayList delRateList = new ArrayList();
        private ArrayList delGoodsPriceUList = new ArrayList();
        private ArrayList delRateCopyList = new ArrayList();
        // リモートオブジェクト格納バッファ
        private IUserPriceDB _userPriceDB = null;    // 課設定リモート
        private IGoodsPriceUDB _goodsPriceUDB = null;

        private RateAcs _rateAcs = null;

        private UserPriceDataSet.UserPriceDataTable _userPriceCopyDataTable;

        #endregion

        // ===================================================================================== //
        // プロパティ
        // ===================================================================================== //
        # region ■Properties
        /// <summary>商品マスタ</summary>
        public ArrayList GoodsPriceUList
        {
            get { return this.goodsPriceUList; }
            set { this.goodsPriceUList = value; }
        }

        /// <summary>掛率マスタ</summary>
        public ArrayList RateList
        {
            get { return this.rateList; }
            set { this.rateList = value; }
        }

        /// <summary>入力データ</summary>
        public UserPriceData UserPriceData
        {
            get { return this._userPriceData; }
        }

        /// <summary>入力データ</summary>
        public UserPriceData UserPriceSaveData
        {
            get { return this._userPriceSaveData; }
            set { this._userPriceSaveData = value; }
        }

        /// <summary>データセット</summary>
        public UserPriceDataSet.UserPriceDataTable UserPriceDataTable
        {
            get { return this._userPriceDataTable; }
        }

        /// <summary>データセット</summary>
        public UserPriceDataSet.UserPriceDataTable UserPriceCopyDataTable
        {
            get { return this._userPriceCopyDataTable; }
            set { this._userPriceCopyDataTable = value; }
        }
        #endregion

        // ===================================================================================== //
        // パブリックメソッド
        // ===================================================================================== //
        # region ■Public Methods
        /// <summary>
        /// 検索データ初期インスタンス生成処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : なし。</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.05.05</br>
        /// </remarks>
        public void CreateSalesSlipInitialData()
        {
            UserPriceData userPriceData = new UserPriceData();

            // 拠点初期値
            userPriceData.SectionCode = "00";
            userPriceData.SectionName = "全社";

            this.CacheUserPriceData(userPriceData);
        }

        /// <summary>
        /// 検索データキャッシュ処理
        /// </summary>
        /// <param name="source">売上データインスタンス</param>
        /// <remarks>
        /// <br>Note       : なし。</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.05.05</br>
        /// </remarks>
        public void CacheUserPriceData(UserPriceData source)
        {
            this._userPriceData = source.Clone();
        }

        /// <summary>
        /// 掛率マスタ検索
        /// </summary>
        /// <returns>ステータス</returns>
        public int SearchRate()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            // 削除リスト
            this.delRateList = new ArrayList();
            // ↓ 2009.06.19 劉洋 add
            this.delRateCopyList = new ArrayList();
            // ↑ 2009.06.19 劉洋 add

            // 抽出条件の作成
            // 掛率マスタも取得する
            ArrayList retList = null;

            // 引数設定
            Rate rate = new Rate();
            string errMsg = null;
            rate.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            // 単価掛率設定区分
            rate.UnitRateSetDivCd = "36A";
            rate.RateSettingDivide = "6A";
            // 単価種類
            rate.UnitPriceKind = "3";
            // 単価掛率設定区分
            // 論理削除フラグ不要
            // rate.LogicalDeleteCode = 0;

            status = _rateAcs.SearchAll(out retList, ref rate, out errMsg);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL
                && retList != null
                && retList.Count != 0)
            {
                // リストを追加する
                this.rateList.AddRange(retList);
            }

            return status;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// <br>Note       : なし。</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.05.05</br>
        /// </remarks>
        public double GetUserPrice(GoodsUnitData goodsUnitData)
        {
            double userPrice = 0;

            foreach (Rate rate in this.rateList)
            {
                if (rate.SectionCode.Equals(this._userPriceData.SectionCode)
                    && rate.GoodsMakerCd == goodsUnitData.GoodsMakerCd
                    && rate.GoodsNo.Equals(goodsUnitData.GoodsNo))
                {
                    // 削除リスト作成する
                    RateWork rateWork = new RateWork();
                    rateWork = this.CopyToRateWorkFromRate(rate);
                    delRateList.Add(rateWork);
                    // ↓ 2009.06.18 liuyang add
                    delRateCopyList.Add(rateWork);
                    // ↑ 2009.06.18 liuyang add

                    if (rate.LogicalDeleteCode == 0)
                    {
                        userPrice = rate.PriceFl;
                    }
                    else
                    {
                        // 論理削除場合
                        userPrice = 0;
                    }
                    break;
                }
            }

            return userPrice;
        }

        /// <summary>
        /// 価格マスタ
        /// </summary>
        /// <returns>ステータス</returns>
        public void SearchGoodsPriceU(List<GoodsUnitData> goodsUnitDataList)
        {
            // 削除リスト
            // this.delGoodsPriceUList = new ArrayList();

            List<UnitPriceCalcParam> unitPriceCalcParamList = new List<UnitPriceCalcParam>();

            foreach (GoodsUnitData goodsUnitData in goodsUnitDataList)
            {
                // 単価算出パラメータ設定
                UnitPriceCalcParam unitPriceCalcParam = new UnitPriceCalcParam();
                unitPriceCalcParam.SectionCode = this._userPriceSaveData.SectionCode;    // 拠点コード
                unitPriceCalcParam.GoodsMakerCd = goodsUnitData.GoodsMakerCd;                               // 商品メーカーコード
                unitPriceCalcParam.GoodsNo = goodsUnitData.GoodsNo;                                         // 商品番号
                unitPriceCalcParam.GoodsRateRank = goodsUnitData.GoodsRateRank;                             // 商品掛率ランク
                unitPriceCalcParam.GoodsRateGrpCode = goodsUnitData.GoodsMGroup;                            // 商品掛率グループコード
                unitPriceCalcParam.BLGroupCode = goodsUnitData.BLGroupCode;                                 // BLグループコード
                unitPriceCalcParam.BLGoodsCode = goodsUnitData.BLGoodsCode;                                 // BL商品コード
                unitPriceCalcParam.SupplierCd = goodsUnitData.SupplierCd;                                   // 仕入先コード
                unitPriceCalcParam.PriceApplyDate = DateTime.Now;                                           // 価格適用日
                unitPriceCalcParam.CountFl = 1;                                                             // 数量
                unitPriceCalcParam.TaxationDivCd = goodsUnitData.TaxationDivCd;                             // 課税区分
                unitPriceCalcParam.TaxRate = TaxRateSetAcs.GetTaxRate(this._taxRateSet, DateTime.Now);      // 税率
                unitPriceCalcParam.StockCnsTaxFrcProcCd = goodsUnitData.StockCnsTaxFrcProcCd;               // 仕入消費税端数処理コード
                unitPriceCalcParam.StockUnPrcFrcProcCd = goodsUnitData.StockUnPrcFrcProcCd;                 // 仕入単価端数処理コード
                unitPriceCalcParam.TotalAmountDispWayCd = 0;                                                // 総額表示方法区分
                unitPriceCalcParam.TtlAmntDspRateDivCd = 1;                                                 // 総額表示掛率適用区分
                unitPriceCalcParam.ConsTaxLayMethod = this._taxRateSet.ConsTaxLayMethod;                    // 消費税転嫁方式

                unitPriceCalcParamList.Add(unitPriceCalcParam);
            }

            List<UnitPriceCalcRet> unitPriceCalcRetList;
            this._unitPriceCalculation.CalculateUnitCost(unitPriceCalcParamList, goodsUnitDataList, out unitPriceCalcRetList);

            foreach (UnitPriceCalcRet unitPriceCalcRetWk in unitPriceCalcRetList)
            {
                if (unitPriceCalcRetWk.UnitPriceKind == UnitPriceCalculation.ctUnitPriceKind_UnitCost)
                {
                    // 情報を保存する
                    goodsPriceUList.Add(unitPriceCalcRetWk);
                }
            }

        }

        /// <summary>
        /// 仕入原価検索
        /// </summary>
        /// <remarks>
        /// <br>Note       : なし。</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.05.05</br>
        /// </remarks>
        public double GetStockUnitPrice(GoodsUnitData goodsUnitData, ref int starFlg)
        {
            double stockUnitPrice = 0;

            foreach (UnitPriceCalcRet unitPriceCalcRet in this.goodsPriceUList)
            {
                if (unitPriceCalcRet.GoodsMakerCd == goodsUnitData.GoodsMakerCd
                    && unitPriceCalcRet.GoodsNo.Equals(goodsUnitData.GoodsNo))
                {
                    //stockUnitPrice = ((goodsUnitData.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxInc)) ? unitPriceCalcRet.UnitPriceTaxIncFl : unitPriceCalcRet.UnitPriceTaxExcFl;
                    stockUnitPrice = unitPriceCalcRet.UnitPriceTaxExcFl;

                    if (!string.IsNullOrEmpty(unitPriceCalcRet.RateSettingDivide))
                    {
                        starFlg = 1;
                    }
                }
            }

            return stockUnitPrice;
        }
        #endregion

        // ===================================================================================== //
        // プライベートメソッド
        // ===================================================================================== //
        # region ■Private Methods
        /// <summary>
        /// 単価算出結果オブジェクト取得処理
        /// </summary>
        /// <param name="goodsUnitData">商品連結データ</param>
        /// <returns>単価算出結果オブジェクト</returns>
        /// <remarks>
        /// <br>Note       : 商品連結データより単価算出結果オブジェクトを取得します。</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009/05/05</br>
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
            unitPriceCalcParam.PriceApplyDate = DateTime.Now;                                           // 価格適用日
            unitPriceCalcParam.CountFl = 1;                                                             // 数量
            unitPriceCalcParam.TaxationDivCd = goodsUnitData.TaxationDivCd;                             // 課税区分
            unitPriceCalcParam.TaxRate = TaxRateSetAcs.GetTaxRate(this._taxRateSet, DateTime.Now);      // 税率
            unitPriceCalcParam.StockCnsTaxFrcProcCd = goodsUnitData.StockCnsTaxFrcProcCd;               // 仕入消費税端数処理コード
            unitPriceCalcParam.StockUnPrcFrcProcCd = goodsUnitData.StockUnPrcFrcProcCd;                 // 仕入単価端数処理コード
            unitPriceCalcParam.TotalAmountDispWayCd = 0;                                                // 総額表示方法区分
            unitPriceCalcParam.TtlAmntDspRateDivCd = 1;                                                 // 総額表示掛率適用区分
            unitPriceCalcParam.ConsTaxLayMethod = this._taxRateSet.ConsTaxLayMethod;                    // 消費税転嫁方式

            List<UnitPriceCalcRet> unitPriceCalcRetList;
            this._unitPriceCalculation.CalculateUnitCost(unitPriceCalcParam, goodsUnitData, out unitPriceCalcRetList);

            foreach (UnitPriceCalcRet unitPriceCalcRetWk in unitPriceCalcRetList)
            {
                if (unitPriceCalcRetWk.UnitPriceKind == UnitPriceCalculation.ctUnitPriceKind_UnitCost)
                {
                    // 情報を保存する
                    goodsPriceUList.Add(unitPriceCalcRetWk);
                    return unitPriceCalcRetWk;
                }
            }

            return new UnitPriceCalcRet();
        }

        /// <summary>
        /// 税率設定マスタ取得処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : なし。</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.05.05</br>
        /// </remarks>
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
        /// 掛率マスタ
        /// </summary>
        /// <param name="rate">掛率マスタ</param>
        /// <param name="BLGoodsNo">品番</param>
        /// <param name="goodsMakerCd">商品コード</param>
        /// <param name="sectionCode">拠点</param>
        /// <returns>フラグ</returns>
        /// <remarks>
        /// <br>Note       : なし。</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.05.05</br>
        /// </remarks>
        private bool FindRateData(ref Rate rate, string BLGoodsNo, int goodsMakerCd, string sectionCode)
        {
            foreach (Rate rateData in this.rateList)
            {
                if (rateData.GoodsNo.Equals(BLGoodsNo) && rateData.GoodsMakerCd == goodsMakerCd
                    && rateData.SectionCode.Equals(sectionCode) && rateData.LogicalDeleteCode == 0)
                {
                    rate = rateData;
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 掛率マスタ
        /// </summary>
        /// <param name="BLGoodsNo">品番</param>
        /// <param name="goodsMakerCd">商品コード</param>
        /// <param name="sectionCode">拠点</param>
        /// <returns>フラグ</returns>
        /// <remarks>
        /// <br>Note       : なし。</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.05.05</br>
        /// </remarks>
        public bool FindRateData(string BLGoodsNo, int goodsMakerCd, string sectionCode)
        {
            foreach (Rate rateData in this.rateList)
            {
                if (rateData.GoodsNo.Equals(BLGoodsNo) && rateData.GoodsMakerCd == goodsMakerCd
                    && rateData.SectionCode.Equals(sectionCode) && rateData.LogicalDeleteCode == 0)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 価格マスタ
        /// </summary>
        /// <param name="unitPriceCalcRet">価格マスタ</param>
        /// <param name="BLGoodsNo">品番</param>
        /// <param name="goodsMakerCd">商品コード</param>
        /// <returns>フラグ</returns>
        /// <remarks>
        /// <br>Note       : なし。</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.05.05</br>
        /// </remarks>
        private bool FindPriceCalcData(ref UnitPriceCalcRet unitPriceCalcRet, string BLGoodsNo, int goodsMakerCd)
        {
            foreach (UnitPriceCalcRet unitPriceCalcRetData in this.goodsPriceUList)
            {
                if (unitPriceCalcRetData.GoodsNo.Equals(BLGoodsNo) && unitPriceCalcRetData.GoodsMakerCd == goodsMakerCd)
                {
                    unitPriceCalcRet = unitPriceCalcRetData;
                    return true;
                }
            }
            return false;
        }
        #endregion

        // ===================================================================================== //
        // DBデータアクセス処理
        // ===================================================================================== //
        # region ■DataBase Access Methods
        /// <summary>
        /// 保存処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : なし。</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.05.05</br>
        /// </remarks>
        public int SaveData()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            ArrayList updateRateData = new ArrayList();
            ArrayList updateGoodsPriceUData = new ArrayList();

            this.delGoodsPriceUList = new ArrayList();

            // ↓ 2009.06.19 劉洋 add
            delRateList = new ArrayList();
            delRateList.AddRange(delRateCopyList);
            // ↑ 2009.06.19 劉洋 add

            int i = 0;
            foreach (UserPriceDataSet.UserPriceRow row in this._userPriceDataTable)
            {
                // ↓ 2009.06.18 劉洋 modify PVCS.199
                UserPriceDataSet.UserPriceRow copyRow = (UserPriceDataSet.UserPriceRow)this._userPriceCopyDataTable.Rows[i];

                if (row.UserPrice != copyRow.UserPrice)
                {
                    RateWork rateWork = CreateRateSaveData(row);
                    updateRateData.Add(rateWork);

                    // 削除データをクリア
                    if (rateWork.LogicalDeleteCode == 1)
                    {
                        foreach (RateWork rate in this.delRateList)
                        {
                            if (rateWork.GoodsNo.Equals(rate.GoodsNo) && rateWork.GoodsMakerCd == rate.GoodsMakerCd
                                && rateWork.SectionCode.Equals(rate.SectionCode))
                            {
                                delRateList.Remove(rate);
                                break;
                            }
                        }
                    }
                }
                else
                {
                    // 削除データクリア
                    foreach (RateWork rate in this.delRateList)
                    {
                        if (row.BLGoodsNo.Equals(rate.GoodsNo) && this._userPriceSaveData.GoodsMakerCd == rate.GoodsMakerCd
                            && this._userPriceSaveData.SectionCode.Equals(rate.SectionCode))
                        {
                            delRateList.Remove(rate);
                            break;
                        }
                    }
                }

                if (row.StockPrice != copyRow.StockPrice)
                {
                    GoodsPriceUWork goodsPriceUWork = CreateGoodsPriceUData(row);
                    // 仕入原価がゼロ以外の場合
                    if (goodsPriceUWork.GoodsMakerCd != 0)
                    {
                        updateGoodsPriceUData.Add(goodsPriceUWork);
                    }
                }
                i++;
                // ↑ 2009.06.18 劉洋 modify
            }

            object paraRateDelObj = (object)delRateList;
            object paraGoodsPriceUDelObj = (object)delGoodsPriceUList;
            object paraRateObj = (object)updateRateData;
            object paraGoodsPriceObj = (object)updateGoodsPriceUData;

            // ↓ 2009.06.18 劉洋 modify
            if (updateRateData.Count == 0 && updateGoodsPriceUData.Count == 0
                && delRateList.Count == 0 && delGoodsPriceUList.Count == 0)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                return status;
            }
            // ↑ 2009.06.18 劉洋 modify

            // 情報登録
            string msg = "";
            status = this._userPriceDB.Write(paraRateObj, paraGoodsPriceObj, paraRateDelObj,paraGoodsPriceUDelObj, ref msg);
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                return status;
            }

            return status;
        }

        /// <summary>
        /// 掛率マスタ情報作成
        /// </summary>
        /// <returns>掛率マスタ</returns>
        private RateWork CreateRateSaveData(UserPriceDataSet.UserPriceRow row)
        {
            // 掛率マスタ登録
            RateWork rateWork = new RateWork();

            Rate rate = new Rate();
            bool isExistFlg = FindRateData(ref rate, row.BLGoodsNo, this._userPriceSaveData.GoodsMakerCd, this._userPriceSaveData.SectionCode);
            // 更新の場合
            if (isExistFlg)
            {
                rateWork = this.CopyToRateWorkFromRate(rate);

                if (row.UserPrice == 0)
                {
                    if (rateWork.UpRate == 0)
                    {
                        rateWork.LogicalDeleteCode = 1;
                    }
                    else
                    {
                        // 更新日時
                        rateWork.UpdateDateTime = DateTime.MinValue;
                        rateWork.PriceFl = 0;
                    }
                }
                else
                {
                    // 更新日時
                    rateWork.UpdateDateTime = DateTime.MinValue;
                    rateWork.PriceFl = row.UserPrice;
                }
            }
            else
            {
                // 登録の場合
                rateWork.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
                // 拠点コード
                rateWork.SectionCode = this._userPriceSaveData.SectionCode;
                // 単価掛率設定区分
                rateWork.UnitRateSetDivCd = "36A";
                // 単価種類
                rateWork.UnitPriceKind = "3";
                // 掛率設定区分
                rateWork.RateSettingDivide = "6A";
                // 掛率設定区分（商品）
                rateWork.RateMngGoodsCd = "A";
                // 掛率設定名称（商品）
                rateWork.RateMngGoodsNm = "ﾒｰｶｰ+品番";
                // 掛率設定区分（得意先）
                rateWork.RateMngCustCd = "6";
                // 掛率設定名称（得意先）
                rateWork.RateMngCustNm = "指定なし";
                // 商品メーカーコード
                rateWork.GoodsMakerCd = this.UserPriceData.GoodsMakerCd;
                // 商品番号
                rateWork.GoodsNo = row.BLGoodsNo;
                // 商品掛率ランク
                rateWork.GoodsRateRank = string.Empty;
                // 商品掛率グループコード
                rateWork.GoodsRateGrpCode = 0;
                // BLグループコード
                rateWork.BLGroupCode = 0;
                // BL商品コード
                rateWork.BLGoodsCode = 0;
                // 得意先コード
                rateWork.CustomerCode = 0;
                // 得意先掛率グループコード
                rateWork.CustRateGrpCode = 0;
                // 仕入先コード
                rateWork.SupplierCd = 0;
                // ロット数
                rateWork.LotCount = 9999999.99;
                // 価格（浮動）
                rateWork.PriceFl = row.UserPrice;
                // 掛率
                rateWork.RateVal = 0;
                // UP率
                rateWork.UpRate = 0;
                // 粗利確保率
                rateWork.GrsProfitSecureRate = 0;
                // ↓ 2009.06.18 劉洋 modify PVCS.207
                // 単価端数処理単位
                // rateWork.UnPrcFracProcUnit = 0;
                rateWork.UnPrcFracProcUnit = 1.00;
                // 単価端数処理区分
                // rateWork.UnPrcFracProcDiv = 0;
                rateWork.UnPrcFracProcDiv = 2;
                // ↑ 2009.06.18 劉洋 modify
            }

            return rateWork;
        }

        /// <summary>
        /// 価格マスタ情報作成
        /// </summary>
        /// <param name="row">価格マスタ</param>
        /// <returns>価格マスタ</returns>
        private GoodsPriceUWork CreateGoodsPriceUData(UserPriceDataSet.UserPriceRow row)
        {
            GoodsPriceUWork goodsPriceUWork = new GoodsPriceUWork();

            UnitPriceCalcRet unitPriceCalcRet = new UnitPriceCalcRet();
            bool isExistFlg = FindPriceCalcData(ref unitPriceCalcRet, row.BLGoodsNo, this._userPriceSaveData.GoodsMakerCd);

            if (isExistFlg)
            {
                GoodsPriceUWork paraGoodsPriceUWork = new GoodsPriceUWork();
                // パラメータ
                paraGoodsPriceUWork.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
                paraGoodsPriceUWork.LogicalDeleteCode = 0;
                paraGoodsPriceUWork.GoodsMakerCd = unitPriceCalcRet.GoodsMakerCd;
                paraGoodsPriceUWork.GoodsNo = unitPriceCalcRet.GoodsNo;
                paraGoodsPriceUWork.PriceStartDate = unitPriceCalcRet.PriceStartDate;
                // 検索
                object goodsPriceUDataList = null;
                int status = this._goodsPriceUDB.Search(out goodsPriceUDataList,
                    (object)paraGoodsPriceUWork, 0, ConstantManagement.LogicalMode.GetData0);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    ArrayList result = (ArrayList)goodsPriceUDataList;
                    goodsPriceUWork = (GoodsPriceUWork)result[0];
                    // 削除リスト作成
                    GoodsPriceUWork goodsPriceUCopyWork = this.CopyTogoodsPriceUWork(goodsPriceUWork);
                    this.delGoodsPriceUList.Add(goodsPriceUCopyWork);
                    // 価格
                    goodsPriceUWork.SalesUnitCost = row.StockPrice;
                    goodsPriceUWork.UpdateDateTime = DateTime.MinValue;
                }
                else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                {
                    // 仕入原価がゼロ以外の場合
                    if (row.StockPrice != 0)
                    {
                        goodsPriceUWork.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
                        goodsPriceUWork.GoodsMakerCd = this._userPriceSaveData.GoodsMakerCd;
                        goodsPriceUWork.GoodsNo = row.BLGoodsNo;
                        goodsPriceUWork.PriceStartDate = DateTime.Now;
                        goodsPriceUWork.ListPrice = 0;
                        goodsPriceUWork.SalesUnitCost = row.StockPrice;
                        goodsPriceUWork.StockRate = 0;
                        goodsPriceUWork.OpenPriceDiv = 0;
                        goodsPriceUWork.OfferDate = DateTime.Now;
                        goodsPriceUWork.UpdateDate = DateTime.Now;
                    }
                }
                else if (status == (int)ConstantManagement.DB_Status.ctDB_EOF)
                {
                    // 仕入原価がゼロ以外の場合
                    if (row.StockPrice != 0)
                    {
                        goodsPriceUWork.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
                        goodsPriceUWork.GoodsMakerCd = this._userPriceSaveData.GoodsMakerCd;
                        goodsPriceUWork.GoodsNo = row.BLGoodsNo;
                        goodsPriceUWork.PriceStartDate = DateTime.Now;
                        goodsPriceUWork.ListPrice = 0;
                        goodsPriceUWork.SalesUnitCost = row.StockPrice;
                        goodsPriceUWork.StockRate = 0;
                        goodsPriceUWork.OpenPriceDiv = 0;
                        goodsPriceUWork.OfferDate = DateTime.Now;
                        goodsPriceUWork.UpdateDate = DateTime.Now;
                    }
                }
                else
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                }
            }
            else
            {
                GoodsPriceUWork paraGoodsPriceUWork = new GoodsPriceUWork();
                // パラメータ
                paraGoodsPriceUWork.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
                paraGoodsPriceUWork.LogicalDeleteCode = 0;
                paraGoodsPriceUWork.GoodsMakerCd = this._userPriceSaveData.GoodsMakerCd;
                paraGoodsPriceUWork.GoodsNo = row.BLGoodsNo;

                // 検索
                object goodsPriceUDataList = null;
                int status = this._goodsPriceUDB.Search(out goodsPriceUDataList,
                    (object)paraGoodsPriceUWork, 0, ConstantManagement.LogicalMode.GetData0);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // 最近日時データを取得する
                    ArrayList result = (ArrayList)goodsPriceUDataList;
                    int i = 0;
                    int j = -1;
                    DateTime value = DateTime.MinValue;
                    foreach (GoodsPriceUWork res in result)
                    {
                        if (res.PriceStartDate > value && res.PriceStartDate.Date <= DateTime.Now.Date)
                        {
                            value = res.PriceStartDate;
                            j = i;
                        }

                        i++;
                    }
                    // ↓ 2009.06.17 liuyang add PVCS.181
                    //goodsPriceUWork = (GoodsPriceUWork)result[j];
                    //// 削除リスト作成
                    //GoodsPriceUWork goodsPriceUCopyWork = this.CopyTogoodsPriceUWork(goodsPriceUWork);
                    //this.delGoodsPriceUList.Add(goodsPriceUCopyWork);
                    //// 価格
                    //goodsPriceUWork.SalesUnitCost = row.StockPrice;
                    //goodsPriceUWork.UpdateDateTime = DateTime.MinValue;
                    if (j != -1)
                    {
                        goodsPriceUWork = (GoodsPriceUWork)result[j];
                        // 削除リスト作成
                        GoodsPriceUWork goodsPriceUCopyWork = this.CopyTogoodsPriceUWork(goodsPriceUWork);
                        this.delGoodsPriceUList.Add(goodsPriceUCopyWork);
                        // 価格
                        goodsPriceUWork.SalesUnitCost = row.StockPrice;
                        goodsPriceUWork.UpdateDateTime = DateTime.MinValue;

                    }
                    else
                    {
                        // 仕入原価がゼロ以外の場合
                        if (row.StockPrice != 0)
                        {
                            goodsPriceUWork.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
                            goodsPriceUWork.GoodsMakerCd = this._userPriceSaveData.GoodsMakerCd;
                            goodsPriceUWork.GoodsNo = row.BLGoodsNo;
                            goodsPriceUWork.PriceStartDate = DateTime.Now;
                            goodsPriceUWork.ListPrice = 0;
                            goodsPriceUWork.SalesUnitCost = row.StockPrice;
                            goodsPriceUWork.StockRate = 0;
                            goodsPriceUWork.OpenPriceDiv = 0;
                            goodsPriceUWork.OfferDate = DateTime.Now;
                            goodsPriceUWork.UpdateDate = DateTime.Now;
                        }
                    }
                    // ↑ 2009.06.17 liuyang modify
                }
                else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                {
                    // 仕入原価がゼロ以外の場合
                    if (row.StockPrice != 0)
                    {
                        goodsPriceUWork.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
                        goodsPriceUWork.GoodsMakerCd = this._userPriceSaveData.GoodsMakerCd;
                        goodsPriceUWork.GoodsNo = row.BLGoodsNo;
                        goodsPriceUWork.PriceStartDate = DateTime.Now;
                        goodsPriceUWork.ListPrice = 0;
                        goodsPriceUWork.SalesUnitCost = row.StockPrice;
                        goodsPriceUWork.StockRate = 0;
                        goodsPriceUWork.OpenPriceDiv = 0;
                        goodsPriceUWork.OfferDate = DateTime.Now;
                        goodsPriceUWork.UpdateDate = DateTime.Now;
                    }
                }
                else if (status == (int)ConstantManagement.DB_Status.ctDB_EOF)
                {
                    // 仕入原価がゼロ以外の場合
                    if (row.StockPrice != 0)
                    {
                        goodsPriceUWork.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
                        goodsPriceUWork.GoodsMakerCd = this._userPriceSaveData.GoodsMakerCd;
                        goodsPriceUWork.GoodsNo = row.BLGoodsNo;
                        goodsPriceUWork.PriceStartDate = DateTime.Now;
                        goodsPriceUWork.ListPrice = 0;
                        goodsPriceUWork.SalesUnitCost = row.StockPrice;
                        goodsPriceUWork.StockRate = 0;
                        goodsPriceUWork.OpenPriceDiv = 0;
                        goodsPriceUWork.OfferDate = DateTime.Now;
                        goodsPriceUWork.UpdateDate = DateTime.Now;
                    }
                }
                else
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                }

                //// 仕入原価がゼロ以外の場合
                //if (row.StockPrice != 0)
                //{
                //    goodsPriceUWork.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
                //    goodsPriceUWork.GoodsMakerCd = this._userPriceSaveData.GoodsMakerCd;
                //    goodsPriceUWork.GoodsNo = row.BLGoodsNo;
                //    goodsPriceUWork.PriceStartDate = DateTime.Now;
                //    goodsPriceUWork.ListPrice = 0;
                //    goodsPriceUWork.SalesUnitCost = row.StockPrice;
                //    goodsPriceUWork.StockRate = 0;
                //    goodsPriceUWork.OpenPriceDiv = 0;
                //    goodsPriceUWork.OfferDate = DateTime.Now;
                //    goodsPriceUWork.UpdateDate = DateTime.Now;
                //}
            }

            return goodsPriceUWork;
        }

        /// <summary>
        /// クラスメンバーコピー処理（掛率設定クラス⇒掛率設定ワーククラス）
        /// </summary>
        /// <param name="rate">掛率設定クラス</param>
        /// <returns>RateWork</returns>
        /// <remarks>
        /// <br>Note       : 掛率設定クラスから掛率設定ワーククラスへメンバーのコピーを行います。</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009/04/01</br>
        /// </remarks>
        private RateWork CopyToRateWorkFromRate(Rate rate)
        {
            RateWork rateWork = new RateWork();

            // 作成日時
            rateWork.CreateDateTime = rate.CreateDateTime;
            // 更新日時
            rateWork.UpdateDateTime = rate.UpdateDateTime;
            // 企業コード
            rateWork.EnterpriseCode = rate.EnterpriseCode;
            // GUID
            rateWork.FileHeaderGuid = rate.FileHeaderGuid;
            // 更新従業員コード
            rateWork.UpdEmployeeCode = rate.UpdEmployeeCode;
            // 更新アセンブリID1
            rateWork.UpdAssemblyId1 = rate.UpdAssemblyId1;
            // 更新アセンブリID2
            rateWork.UpdAssemblyId2 = rate.UpdAssemblyId2;
            // 論理削除区分
            rateWork.LogicalDeleteCode = rate.LogicalDeleteCode;
            // 拠点コード
            rateWork.SectionCode = rate.SectionCode;
            // 単価掛率設定区分
            rateWork.UnitRateSetDivCd = rate.UnitRateSetDivCd;
            // 単価種類
            rateWork.UnitPriceKind = rate.UnitPriceKind;
            // 掛率設定区分
            rateWork.RateSettingDivide = rate.RateSettingDivide;
            // 掛率設定区分（商品）
            rateWork.RateMngGoodsCd = rate.RateMngGoodsCd;
            // 掛率設定名称（商品）
            rateWork.RateMngGoodsNm = rate.RateMngGoodsNm;
            // 掛率設定区分（得意先）
            rateWork.RateMngCustCd = rate.RateMngCustCd;
            // 掛率設定名称（得意先）
            rateWork.RateMngCustNm = rate.RateMngCustNm;
            // 商品メーカーコード
            rateWork.GoodsMakerCd = rate.GoodsMakerCd;
            // 商品番号
            rateWork.GoodsNo = rate.GoodsNo;
            // 商品掛率ランク
            rateWork.GoodsRateRank = rate.GoodsRateRank;
            // BL商品コード
            rateWork.BLGoodsCode = rate.BLGoodsCode;
            // 得意先コード
            rateWork.CustomerCode = rate.CustomerCode;
            // 得意先掛率グループコード
            rateWork.CustRateGrpCode = rate.CustRateGrpCode;
            // 仕入先コード
            rateWork.SupplierCd = rate.SupplierCd;
            // ロット数
            rateWork.LotCount = rate.LotCount;
            // 価格
            rateWork.PriceFl = rate.PriceFl;
            // 掛率
            rateWork.RateVal = rate.RateVal;
            // 単価端数処理単位
            rateWork.UnPrcFracProcUnit = rate.UnPrcFracProcUnit;
            // 単価端数処理区分
            rateWork.UnPrcFracProcDiv = rate.UnPrcFracProcDiv;
            // 商品掛率グループコード
            rateWork.GoodsRateGrpCode = rate.GoodsRateGrpCode;
            // BLグループコード
            rateWork.BLGroupCode = rate.BLGroupCode;
            // UP率
            rateWork.UpRate = rate.UpRate;
            // 粗利確保率
            rateWork.GrsProfitSecureRate = rate.GrsProfitSecureRate;

            return rateWork;
        }

        /// <summary>
        /// 価格マスタコピー
        /// </summary>
        /// <param name="goodsPriceUWork">価格マスタ</param>
        /// <returns>価格マスタ</returns>
        private GoodsPriceUWork CopyTogoodsPriceUWork(GoodsPriceUWork goodsPriceUWork)
        {
            GoodsPriceUWork goodsPriceUWorkCopy = new GoodsPriceUWork();

            goodsPriceUWorkCopy.CreateDateTime = goodsPriceUWork.CreateDateTime;
            goodsPriceUWorkCopy.UpdateDateTime = goodsPriceUWork.UpdateDateTime;
            goodsPriceUWorkCopy.EnterpriseCode = goodsPriceUWork.EnterpriseCode;
            goodsPriceUWorkCopy.FileHeaderGuid = goodsPriceUWork.FileHeaderGuid;
            goodsPriceUWorkCopy.UpdEmployeeCode = goodsPriceUWork.UpdEmployeeCode;
            goodsPriceUWorkCopy.UpdAssemblyId1 = goodsPriceUWork.UpdAssemblyId1;
            goodsPriceUWorkCopy.UpdAssemblyId2 = goodsPriceUWork.UpdAssemblyId2;
            goodsPriceUWorkCopy.LogicalDeleteCode = goodsPriceUWork.LogicalDeleteCode;
            goodsPriceUWorkCopy.GoodsMakerCd = goodsPriceUWork.GoodsMakerCd;
            goodsPriceUWorkCopy.GoodsNo = goodsPriceUWork.GoodsNo;
            goodsPriceUWorkCopy.PriceStartDate = goodsPriceUWork.PriceStartDate;
            goodsPriceUWorkCopy.ListPrice = goodsPriceUWork.ListPrice;
            goodsPriceUWorkCopy.SalesUnitCost = goodsPriceUWork.SalesUnitCost;
            goodsPriceUWorkCopy.StockRate = goodsPriceUWork.StockRate;
            goodsPriceUWorkCopy.OpenPriceDiv = goodsPriceUWork.OpenPriceDiv;
            goodsPriceUWorkCopy.OfferDate = goodsPriceUWork.OfferDate;
            goodsPriceUWorkCopy.UpdateDate = goodsPriceUWork.UpdateDate;


            return goodsPriceUWorkCopy;
        }

        #endregion
    }
}
