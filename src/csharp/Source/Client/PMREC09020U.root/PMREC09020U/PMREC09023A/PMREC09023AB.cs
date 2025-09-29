//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : お買得情報マスタアクセスクラス
// プログラム概要   : お買得情報マスタ　価格算出を行います
//----------------------------------------------------------------------------//
//                (c)Copyright  2015 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11070266-00 作成担当 : 30744 湯上千加子
// 作 成 日  2015/02/20  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号  11070266-00 作成担当 : 脇田 靖之
// 更 新 日  2015/03/25  修正内容 : メーカー価格取得方法修正
//----------------------------------------------------------------------------//
// 管理番号  11070266-00 作成担当 : 脇田 靖之
// 更 新 日  2015/03/26  修正内容 : 品証Redmine#3247
//                                  PM商品マスタ(ユーザー登録)から取得したメーカー価格に対して離島設定が反映される
//----------------------------------------------------------------------------//
// 管理番号  11070266-00 作成担当 : 脇田 靖之
// 更 新 日  2015/04/01  修正内容 : システムテスト障害 №62
//                                  提供品番を商品在庫マスタに登録し、価格を削除するとメーカー価格が表示されない
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller.Agent;
using Broadleaf.Library.Resources;
// --- ADD 2015/03/25 Y.Wakita ---------->>>>>
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
// --- ADD 2015/03/25 Y.Wakita ----------<<<<<

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 価格算出クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 価格算出を行います。</br>
    /// <br></br>
    /// <br>UpdateNote : </br>
    /// </remarks>
    public class Calculator
    {
        #region public const
        /// <summary>純正メーカー最大コード</summary>
        public const int PURE_GOODS_MAKER_CODE_MAX = 1000;
        /// <summary>端数処理対象金額区分（売上金額）</summary>
        public const int ctFracProcMoneyDiv_SalesMoney = 0;
        /// <summary>端数処理対象金額区分（消費税）</summary>
        public const int ctFracProcMoneyDiv_Tax = 1;
        /// <summary>端数処理対象金額区分（売上単価）</summary>
        public const int ctFracProcMoneyDiv_SalesUnitPrice = 2;
        /// <summary>端数処理対象金額区分（原価単価）</summary>
        public const int ctFracProcMoneyDiv_SalesUnitCost = 2;
        /// <summary>端数処理対象金額区分（原価金額）</summary>
        public const int ctFracProcMoneyDiv_Cost = 0;
#if DEBUG
        public static readonly bool ctIsLocalDBRead = false; // true:ローカル参照 false:サーバー参照
#else
        public static readonly bool ctIsLocalDBRead = false; // true:ローカル参照 false:サーバー参照
#endif

        #endregion

        #region Private Members

        /// <summary>単価算出クラス</summary>
        private UnitPriceCalculation _unitPriceCalculation; 
        /// <summary>自社設定マスタ</summary>
        private CompanyInf _companyInf;
        /// <summary>得意先マスタアクセスクラス</summary>
        private CustomerInfoAcs _customerInfoAcs;
        /// <summary>仕入先マスタのアクセサ</summary>
        private SupplierAcs _supplierAcs;
        /// <summary>売上全体設定マスタのアクセサ</summary>
        private SalesTtlStAgent _salesTtlStAgent;
        /// <summary>キャンペーン対象商品設定アクセスクラス</summary>
        private CampaignObjGoodsStAcs _campaignObjGoodsStAcs;
        /// <summary>得意先掛率グループマスタアクセスクラス</summary>
        private CustRateGroupAcs _custRateGroupAcs;
        /// <summary>企業コード</summary>
        private string _enterpriseCode;
        /// <summary>得意先掛率グループリスト</summary>
        private List<CustRateGroup> _custRateGroupList;
        /// <summary>税率設定情報</summary>
        private TaxRateSet _taxRateSet;
        /// <summary>キャンペーン対象商品設定マスタ</summary>
        private CampaignObjGoodsSt _campaignObjGoodsSt;
        /// <summary>得意先情報</summary>
        private CustomerInfo _customerInfo;
        /// <summary>売上金額端数処理区分リスト</summary>
        private List<SalesProcMoney> _salesProcMoneyList = null;
        // --- ADD 2015/03/25 Y.Wakita ---------->>>>>
        /// <summary>MAKHN04112A)BLコード・品番検索</summary>
        private GoodsAcs _goodsAcs;
        // --- ADD 2015/03/25 Y.Wakita ----------<<<<<
        #endregion

        #region Construcstor
        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public Calculator()
        {
            this._unitPriceCalculation = new UnitPriceCalculation();
            this._customerInfoAcs = new CustomerInfoAcs();
            this._supplierAcs = new SupplierAcs();
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            this._salesTtlStAgent = new SalesTtlStAgent();
            this._custRateGroupAcs = new CustRateGroupAcs();
            // --- ADD 2015/03/25 Y.Wakita ---------->>>>>
            this._goodsAcs = new GoodsAcs();
            // --- ADD 2015/03/25 Y.Wakita ----------<<<<<
        }
        #endregion

        #region Property
        #endregion

        #region Public Method

        #region ﾒｰｶｰ希望小売価格、定価、売価の取得
        /// <summary>
        ///  部品情報よりﾒｰｶｰ希望小売価格、定価、売価を取得します
        /// </summary>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="goodsUnitData">商品情報</param>
        /// <param name="startDate">開始日</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="mkrSuggestRtPric">ﾒｰｶｰ希望小売価格</param>
        /// <param name="listPrice">定価</param>
        /// <param name="unitPrice">売価</param>
        /// <returns></returns>
        // --- UPD 2015/03/25 Y.Wakita ---------->>>>>
        //public void GetUnitPrice(
        //    int customerCode,
        //    GoodsUnitData goodsUnitData,
        //    DateTime startDate,
        //    string sectionCode,
        //    out long mkrSuggestRtPric,
        //    out long listPrice,
        //    out long unitPrice
        public void GetUnitPrice(
            int customerCode,
            GoodsUnitData goodsUnitData,
            DateTime startDate,
            string sectionCode,
            Dictionary<GoodsInfoKey, List<GoodsPrice>> mkrSuggestRtPricList,
            Dictionary<GoodsInfoKey, List<GoodsPrice>> mkrSuggestRtPricUList,
            out bool uPricDiv,  // ADD 2015/03/26 Y.Wakita
            out long mkrSuggestRtPric,
            out long listPrice,
            out long unitPrice
        // --- UPD 2015/03/25 Y.Wakita ----------<<<<<
        )
        {
            List<UnitPriceCalcRet> unitPriceList = null;
            mkrSuggestRtPric = 0;
            listPrice = 0;
            unitPrice = 0;
            uPricDiv = false;   // ADD 2015/03/26 Y.Wakita

            #region <Guard Phrase>

            //// 得意先情報がゼロの時は処理終了
            //if (customerCode == 0) return;
            // 商品情報が空の時は処理終了
            if (goodsUnitData == null) return;
            // 開始日が初期値の時は処理終了
            if (startDate == DateTime.MinValue) return;

            #endregion // </Guard Phrase>

            {
                // 価格算出パラメータ設定
                UnitPriceCalcParam condition = new UnitPriceCalcParam();
                {
                    condition.BLGoodsCode = goodsUnitData.BLGoodsCode;  // BLコード 
                    condition.BLGoodsName = goodsUnitData.BLGoodsName;  // BLコード名称
                    condition.BLGroupCode = goodsUnitData.BLGroupCode;  // BLグループコード
                    condition.CountFl = 1;                              // 数量
                    condition.CustomerCode = customerCode;              // 得意先コード

                    // 得意先情報取得
                    if (customerCode != 0)
                    {
                        GetCustomerInfo(customerCode);
                    }

                    // 売上金額処理区分リスト取得
                    GetSalesProcMoney();

                    // 得意先掛率グループコード
                    condition.CustRateGrpCode = this.GetCustomerRateGroupCode(
                        this._enterpriseCode,
                        customerCode,
                        goodsUnitData.GoodsMakerCd
                    );

                    condition.GoodsMakerCd = goodsUnitData.GoodsMakerCd;            // メーカーコード
                    condition.GoodsNo = goodsUnitData.GoodsNo;                      // 品番
                    condition.GoodsRateGrpCode = goodsUnitData.GoodsRateGrpCode;    // 商品掛率グループコード
                    condition.GoodsRateRank = goodsUnitData.GoodsRateRank;          // 商品掛率ランク

                    condition.PriceApplyDate = startDate;                           // 適用日

                    // 売上消費税端数処理コード
                    condition.SalesCnsTaxFrcProcCd = this._customerInfoAcs.GetSalesFractionProcCd(this._enterpriseCode, customerCode, CustomerInfoAcs.FracProcMoneyDiv.CnsTaxFrcProcCd);
                    // 売上単価端数処理コード
                    condition.SalesUnPrcFrcProcCd = this._customerInfoAcs.GetSalesFractionProcCd(this._enterpriseCode, customerCode, CustomerInfoAcs.FracProcMoneyDiv.UnPrcFrcProcCd);

                    condition.SectionCode = sectionCode;                            // 拠点コード

                    // 仕入消費税端数処理コード
                    condition.StockCnsTaxFrcProcCd = this._supplierAcs.GetStockFractionProcCd(this._enterpriseCode, goodsUnitData.SupplierCd, SupplierAcs.StockFracProcMoneyDiv.CnsTaxFrcProcCd);
                    // 仕入単価端数処理コード
                    condition.StockUnPrcFrcProcCd = this._supplierAcs.GetStockFractionProcCd(this._enterpriseCode, goodsUnitData.SupplierCd, SupplierAcs.StockFracProcMoneyDiv.UnPrcFrcProcCd);

                    condition.SupplierCd = goodsUnitData.SupplierCd;                // 仕入先コード
                    condition.TaxationDivCd = goodsUnitData.TaxationDivCd;          // 課税区分
                    condition.TaxRate = this.GetTaxRate(startDate);                 // 税率

                    // 請求先情報取得
                    CustomerInfo claim = ClaimInfo(customerCode);
                    if (claim != null)
                    {
                        // 請求先取得時は請求先情報の消費税転嫁方式を設定する
                        condition.ConsTaxLayMethod = claim.CustCTaXLayRefCd == 0 ? this._taxRateSet.ConsTaxLayMethod : claim.ConsTaxLayMethod;
                    }
                    else
                    {
                        // 請求先が取得できない場合は、税率設定マスタの消費税転嫁方式を設定
                        condition.ConsTaxLayMethod = this._taxRateSet.ConsTaxLayMethod;
                    }

                    condition.TotalAmountDispWayCd = 0; // 総額表示方法区分
                    condition.TtlAmntDspRateDivCd = 0;  // 総額表示掛率適用区分 0:(税込金額×掛率) 1:(税抜金額×掛率)から消費税を求め合算(消費税算出時消費税の端数処理が動作)
                }

                this._unitPriceCalculation.RatePriorityDiv = GetCompanyInf(this._enterpriseCode).RatePriorityDiv; //自社設定･掛率優先順位
                
                this._unitPriceCalculation.CacheSalesProcMoneyList(this._salesProcMoneyList); // 売上金額処理区分リストキャッシュ

                // 単価計算
                this._unitPriceCalculation.CalculateSalesRelevanceUnitPrice(condition, goodsUnitData, out unitPriceList);

                // 単価計算の結果より戻り値を設定
                if (unitPriceList != null && unitPriceList.Count != 0)
                {
                    // --- DEL 2015/04/01 Y.Wakita システムテスト障害 №62 ---------->>>>>
                    //// ﾒｰｶｰ希望小売価格取得
                    //// --- UPD 2015/03/26 Y.Wakita ---------->>>>>
                    ////// --- UPD 2015/03/25 Y.Wakita ---------->>>>>
                    //////mkrSuggestRtPric = this.GetmkrSuggestRtPric(startDate, goodsUnitData);
                    ////mkrSuggestRtPric = this.GetmkrSuggestRtPric(startDate, goodsUnitData, mkrSuggestRtPricList, mkrSuggestRtPricUList);
                    ////// --- UPD 2015/03/25 Y.Wakita ----------<<<<<
                    //mkrSuggestRtPric = this.GetmkrSuggestRtPric(out uPricDiv, startDate, goodsUnitData, mkrSuggestRtPricList, mkrSuggestRtPricUList);
                    // --- UPD 2015/03/26 Y.Wakita ---------->>>>>
                    // --- DEL 2015/04/01 Y.Wakita システムテスト障害 №62 ----------<<<<<
                    // 定価取得
                    listPrice = (long)this.GetListPrice(unitPriceList);
                    // 売価取得
                    unitPrice = (long)this.GetUnitPrice(unitPriceList, goodsUnitData, customerCode, startDate, condition, sectionCode);
                }

                // --- ADD 2015/04/01 Y.Wakita システムテスト障害 №62 ---------->>>>>
                // ﾒｰｶｰ希望小売価格取得
                mkrSuggestRtPric = this.GetmkrSuggestRtPric(out uPricDiv, startDate, goodsUnitData, mkrSuggestRtPricList, mkrSuggestRtPricUList);
                // --- ADD 2015/04/01 Y.Wakita システムテスト障害 №62 ----------<<<<<
            }
        }
        #endregion

        #endregion

        #region Private Method

        #region 自社設定マスタ
        /// <summary>
        ///  自社設定マスタ取得
        /// </summary>
        /// <param name="enterpriseCode"></param>
        /// <returns></returns>
        private CompanyInf GetCompanyInf(string enterpriseCode)
        {
            if (_companyInf == null)
            {
                CompanyInfAcs companyInfAcs = new CompanyInfAcs();
                companyInfAcs.Read(out this._companyInf, enterpriseCode);
            }
            return _companyInf;
        }
        #endregion

        #region 得意先マスタ
        /// <summary>
        ///  得意先マスタ取得
        /// </summary>
        /// <param name="enterpriseCode"></param>
        /// <returns></returns>
        private void GetCustomerInfo(int customerCode)
        {
            if (this._customerInfo == null)
            {
                this._customerInfo = new CustomerInfo();
            }

            this._customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, this._enterpriseCode, customerCode, out this._customerInfo);
        }
        #endregion

        #region 得意先掛率グループ
        /// <summary>
        /// 得意先掛率グループを取得します。
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="customerCode">得意先コード</param>
        /// <returns>得意先掛率グループ</returns>
        private List<CustRateGroup> GetCustomerRateGroupList(
            string enterpriseCode,
            int customerCode
        )
        {
            if (this._custRateGroupList == null)
            {
                if (customerCode != 0)
                {
                    ArrayList custRateGroupList;
                    this._custRateGroupAcs.Search(out custRateGroupList, this._enterpriseCode, customerCode, ConstantManagement.LogicalMode.GetData0);
                    if ((custRateGroupList != null) && (custRateGroupList.Count != 0))
                    {
                        this._custRateGroupList = new List<CustRateGroup>((CustRateGroup[])custRateGroupList.ToArray(typeof(CustRateGroup)));
                    }
                    else
                    {
                        this._custRateGroupList = new List<CustRateGroup>();
                    }
                }
                else
                {
                    this._custRateGroupList = new List<CustRateGroup>();
                }
            }
            return this._custRateGroupList;
        }

        /// <summary>
        /// 得意先掛率グループコード取得処理
        /// </summary>
        /// <remarks>
        /// MAHNB01012AB.cs l.9693 SalesSlipInputAcs.GetCustRateGroupCode() を参考<br/>
        /// </remarks>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="goodsMakerCode">メーカーコード</param>
        /// <returns>得意先掛率グループコード</returns>
        private int GetCustomerRateGroupCode(
            string enterpriseCode,
            int customerCode,
            int goodsMakerCode
        )
        {
            int pureCode = (goodsMakerCode <= PURE_GOODS_MAKER_CODE_MAX ? 0 : 1);    // 0:純正 1:優良

            // 単独キー
            CustRateGroup foundCustomerRateGroup = GetCustomerRateGroupList(enterpriseCode, customerCode).Find(
                delegate(CustRateGroup customerRateGroup)
                {
                    return customerRateGroup.GoodsMakerCd.Equals(goodsMakerCode) && customerRateGroup.PureCode.Equals(pureCode);
                }
            );
            if (foundCustomerRateGroup != null) return foundCustomerRateGroup.CustRateGrpCode;

            // 共通キー
            foundCustomerRateGroup = GetCustomerRateGroupList(enterpriseCode, customerCode).Find(
                delegate(CustRateGroup customerRateGroup)
                {
                    return customerRateGroup.GoodsMakerCd.Equals(0) && customerRateGroup.PureCode.Equals(pureCode);
                }
            );
            if (foundCustomerRateGroup != null) return foundCustomerRateGroup.CustRateGrpCode;
            return -1;
        }
        #endregion

        #region 請求先
        /// <summary>
        /// 請求先情報の取得
        /// 　得意先コードから請求先情報を取得する
        /// </summary>
        /// <param name="customerCode">得意先コード</param>
        /// <returns>請求先情報 取得できない場合はnull</returns>
        private CustomerInfo ClaimInfo(int customerCode)
        {
            CustomerInfo claim = null;

            if (this._customerInfo != null)
            {
                if (this._customerInfo.CustomerCode.Equals(this._customerInfo.ClaimCode))
                {
                    // 得意先と請求先が同じ場合
                    claim = this._customerInfo.Clone();
                }
                else
                {
                    // 請求先情報が取得されていない場合
                    this._customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, this._enterpriseCode,  this._customerInfo.ClaimCode, out claim);
                }
            }

            return claim;
        }
        #endregion

        #region 税率設定マスタ
        /// <summary>
        /// 税率設定情報を取得します。
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns>税率</returns>
        private void GetTaxRateSet(string enterpriseCode)
        {
            TaxRateSet taxRateSet = null;
            TaxRateSetAcs taxRateSetAcs = new TaxRateSetAcs();
            {
                int status = taxRateSetAcs.Read(out taxRateSet, enterpriseCode, 0);

                this._taxRateSet = new TaxRateSet();
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    this._taxRateSet = taxRateSet;
                }
            }
        }
        
        /// <summary>
        /// 税率を取得します。
        /// </summary>
        /// <param name="taxRateDate">税率基準日</param>
        /// <returns>税率</returns>
        private double GetTaxRate(DateTime taxRateDate)
        {
            double taxRate = 0;

            if (this._taxRateSet == null)
            {
                this.GetTaxRateSet(this._enterpriseCode);
            }
            if (taxRateDate != DateTime.MinValue)
            {
                taxRate = TaxRateSetAcs.GetTaxRate(this._taxRateSet, taxRateDate);
            }
            return taxRate;
        }
        #endregion

        #region 売上金額処理区分設定マスタ
        /// <summary>
        ///  売上金額端数処理区分リスト取得
        /// </summary>
        private void GetSalesProcMoney()
        {
            ArrayList aList;
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SalesProcMoneyAcs salesProcMoneyAcs = new SalesProcMoneyAcs();
            salesProcMoneyAcs.IsLocalDBRead = ctIsLocalDBRead;
            status = salesProcMoneyAcs.Search(out aList, this._enterpriseCode);
            this._salesProcMoneyList = new List<SalesProcMoney>();
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (aList != null) this._salesProcMoneyList = new List<SalesProcMoney>((SalesProcMoney[])aList.ToArray(typeof(SalesProcMoney)));
            }
        }
        #endregion

        #region キャンペーン商品設定
        /// <summary>
        /// キャンペーン適用処理
        /// </summary>
        /// <param name="taxationCode">課税区分</param>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="blGoodsCode">BLコード</param>
        /// <param name="goodsMakerCd">メーカーコード</param>
        /// <param name="goodsNo">品番</param>
        /// <param name="blGroupCode"> BLグループコード</param>
        /// <param name="salesCode">販売区分</param>
        /// <param name="applyDate">価格適用日</param>
        /// <param name="price">対象金額</param>
        private void ReflectCampaign(int taxationCode, int customerCode, int blGoodsCode, int goodsMakerCd, string goodsNo, int blGroupCode, int salesCode, DateTime applyDate, string sectionCode)
        {
            this._campaignObjGoodsStAcs = new CampaignObjGoodsStAcs();

            CampaignObjGoodsSt campaignObjGoodsSt;
            this._campaignObjGoodsStAcs.GetRatePriceOfCampaignMng(out campaignObjGoodsSt, this._enterpriseCode, sectionCode.Trim(), customerCode, goodsMakerCd, blGroupCode, blGoodsCode, salesCode, goodsNo, applyDate);
            this._campaignObjGoodsSt = campaignObjGoodsSt;

            this._campaignObjGoodsStAcs = null;

            if (campaignObjGoodsSt == null) return;
        }
        #endregion

        #region ﾒｰｶｰ希望小売価格
        /// <summary>
        /// 商品情報からﾒｰｶｰ希望小売価格を取得します
        /// </summary>
        /// <param name="targetDay">対象日</param>
        /// <param name="GoodsUnitData">商品情報</param>
        /// <param name="goodsPrice">価格情報オブジェクト</param>
        /// <returns></returns>
        // --- UPD 2015/03/25 Y.Wakita ---------->>>>>
        //private long GetmkrSuggestRtPric(DateTime targetDay, GoodsUnitData goodsUnitData)
        private long GetmkrSuggestRtPric(
            out bool uPricDiv,   // ADD 2015/03/26 Y.Wakita
            DateTime targetDay, 
            GoodsUnitData goodsUnitData,
            Dictionary<GoodsInfoKey, List<GoodsPrice>> mkrSuggestRtPricList,
            Dictionary<GoodsInfoKey, List<GoodsPrice>> mkrSuggestRtPricUList)
        // --- UPD 2015/03/25 Y.Wakita ----------<<<<<
        {
            long mkrSuggestRtPric = 0;
            uPricDiv = false;   // ADD 2015/03/26 Y.Wakita

            // --- DEL 2015/03/25 Y.Wakita ---------->>>>>
            #region 削除
            //GoodsPrice goodsPrice = null;

            //#region <Guard Phrase>
            //// 商品情報にﾒｰｶｰ希望小売価格情報リストが存在しない時はゼロ
            //if ((goodsUnitData == null) || (goodsUnitData.MkrSuggestRtPricList == null)) return mkrSuggestRtPric;
            //#endregion

            //List<GoodsPrice> goodsPriceList = goodsUnitData.MkrSuggestRtPricList;
            //DateTime dateWk = DateTime.MinValue;
            
            //foreach (GoodsPrice goodsPriceWk in goodsPriceList)
            //{
            //    if ((goodsPriceWk.PriceStartDate <= targetDay) && (goodsPriceWk.PriceStartDate > dateWk))
            //    {
            //        dateWk = goodsPriceWk.PriceStartDate;
            //        goodsPrice = goodsPriceWk.Clone();
            //    }
            //}
            //if (goodsPrice != null)
            //{
            //    mkrSuggestRtPric = (long)goodsPrice.ListPrice;
            //}
            #endregion
            // --- DEL 2015/03/25 Y.Wakita ----------<<<<<

            // --- ADD 2015/03/25 Y.Wakita ---------->>>>>
            long listPrice = 0;
            if (mkrSuggestRtPricList != null && mkrSuggestRtPricList.Count != 0)
            {
                // メーカー希望小売価格取得
                GoodsInfoKey goodsInfoKey = new GoodsInfoKey(goodsUnitData.GoodsNo, goodsUnitData.GoodsMakerCd);
                if (mkrSuggestRtPricList.ContainsKey(goodsInfoKey))
                {
                    // メーカー希望小売価格リストより基準日に該当する価格情報取得
                    List<GoodsPrice> _mkrSuggestRtPricList = mkrSuggestRtPricList[goodsInfoKey];
                    // 提供データの価格情報がなくユーザー登録品番の時、提供データを再取得する
                    if ((mkrSuggestRtPricList == null || mkrSuggestRtPricList.Count == 0) && IsUserRegistAtOfferKubun(goodsUnitData))
                    {
                        this.GetOfferGoodsPrice(goodsUnitData, out _mkrSuggestRtPricList);
                    }
                    object obj = null;
                    if (mkrSuggestRtPricList != null && mkrSuggestRtPricList.Count != 0)
                    {
                        obj = this.GetGoodsPrice(targetDay, _mkrSuggestRtPricList);
                    }
                    if ((obj != null) && (obj is GoodsPrice))
                    {
                        GoodsPrice goodsPrice = (GoodsPrice)obj;
                        // 取得した価格情報がオープン価格の時、メーカー希望小売価格リスト（ユーザー登録分）の価格情報を取得する
                        if (goodsPrice.OpenPriceDiv == 1)
                        {
                            if (mkrSuggestRtPricUList.ContainsKey(goodsInfoKey))
                            {
                                _mkrSuggestRtPricList = mkrSuggestRtPricUList[goodsInfoKey];
                                object objU = null;
                                if (_mkrSuggestRtPricList != null && _mkrSuggestRtPricList.Count != 0)
                                {
                                    objU = this.GetGoodsPrice(targetDay, _mkrSuggestRtPricList);
                                }
                                if ((objU != null) && (objU is GoodsPrice))
                                {
                                    GoodsPrice goodsPriceU = (GoodsPrice)objU;
                                    listPrice = (long)goodsPriceU.ListPrice;
                                    uPricDiv = true;    // ADD 2015/03/26 Y.Wakita
                                }
                            }
                        }
                        else
                        {
                            listPrice = (long)goodsPrice.ListPrice;
                        }
                    }
                    else
                    {
                        // 用品の時、メーカー希望小売価格リスト（ユーザー登録分）の価格情報を取得する
                        if (mkrSuggestRtPricUList.ContainsKey(goodsInfoKey))
                        {
                            _mkrSuggestRtPricList = mkrSuggestRtPricUList[goodsInfoKey];
                            object objU = null;
                            if (_mkrSuggestRtPricList != null && _mkrSuggestRtPricList.Count != 0)
                            {
                                objU = this.GetGoodsPrice(targetDay, _mkrSuggestRtPricList);
                            }
                            if ((objU != null) && (objU is GoodsPrice))
                            {
                                GoodsPrice goodsPriceU = (GoodsPrice)objU;
                                listPrice = (long)goodsPriceU.ListPrice;
                                uPricDiv = true;    // ADD 2015/03/26 Y.Wakita
                            }
                        }
                    }
                    mkrSuggestRtPric = listPrice; // メーカー希望小売価格
                }
            }
            // --- ADD 2015/03/25 Y.Wakita ----------<<<<<

            return mkrSuggestRtPric;
        }
        // --- ADD 2015/03/25 Y.Wakita ---------->>>>>
        /// <summary>提供部品検索コントローラー</summary>
        private static IOfferPartsInfo _iOfferPartsInfo;

        /// <summary>
        ///  提供区分がユーザー登録の提供データか判定します
        /// </summary>
        /// <param name="goodsUnitData">商品情報</param>
        /// <returns>true:ユーザー登録の提供データ false:提供データ・ユーザー登録のみ</returns>
        private bool IsUserRegistAtOfferKubun(GoodsUnitData goodsUnitData)
        {
            if (goodsUnitData == null) return false;

            switch (goodsUnitData.OfferKubun)
            {
                case 0:                 // ユーザー登録
                    {
                        // 0:ユーザー登録
                        if (goodsUnitData.OfferDataDiv == 0)
                        {
                            return false;
                        }
                        // 1:提供データ
                        else if (goodsUnitData.OfferDataDiv == 1)
                        {
                            return true;
                        }
                        return false;
                    }
                case 1: return true;    // 1:提供純正編集
                case 2: return true;    // 2:提供優良編集
                case 3: return false;   // 3:提供純正
                case 4: return false;   // 4:提供優良
                case 5: return false;   // 5:TBO
                case 7: return false;   // 7:オリジナル部品
                default:
                    return false;
            }
        }
        /// <summary>
        /// 提供データ価格情報取得
        /// </summary>
        /// <param name="partsInfoDataSet">部品検索データセット</param>
        /// <param name="goodsUnitDataList">商品連結データオブジェクトリスト</param>
        /// <returns></returns>
        public void GetOfrPriceDataList(
            PartsInfoDataSet partsInfoDataSet,
            List<GoodsUnitData> goodsUnitDataList, 
            out Dictionary<GoodsInfoKey, List<GoodsPrice>> mkrSuggestRtPricList,
            out Dictionary<GoodsInfoKey, List<GoodsPrice>> mkrSuggestRtPricUList)
        {
            this.GetOfrPriceDataListProc(partsInfoDataSet, goodsUnitDataList, out mkrSuggestRtPricList, out mkrSuggestRtPricUList, false);
        }

        /// <summary>
        /// 提供データ価格情報取得
        /// </summary>
        /// <param name="partsInfoDataSet">部品検索データセット</param>
        /// <param name="goodsUnitDataList">商品連結データオブジェクトリスト</param>
        /// <param name="goodsUnitDataList">更新フラグ</param>
        /// <returns></returns>
        private void GetOfrPriceDataListProc(
            PartsInfoDataSet partsInfoDataSet, 
            List<GoodsUnitData> goodsUnitDataList, 
            out Dictionary<GoodsInfoKey, List<GoodsPrice>> mkrSuggestRtPricList, 
            out Dictionary<GoodsInfoKey, List<GoodsPrice>> mkrSuggestRtPricUList, 
            bool isUpdate)
        {
            GoodsInfoKey goodsInfoKey;
            List<GoodsPrice> _mkrSuggestRtPricUList = null;
            List<GoodsPrice> _mkrSuggestRtPricList = null;

            mkrSuggestRtPricList = new Dictionary<GoodsInfoKey, List<GoodsPrice>>();  // ADD 2015/03/18 豊沢 SCM高速化 メーカー希望小売価格対応
            mkrSuggestRtPricUList = new Dictionary<GoodsInfoKey, List<GoodsPrice>>();  // ADD 2015/03/18 豊沢 SCM高速化 メーカー希望小売価格対応

            if (partsInfoDataSet == null || goodsUnitDataList == null || goodsUnitDataList.Count <= 0)
            {
                // パラメータ不正のため終了
                return;
            }

            foreach (GoodsUnitData goodsUnitData in goodsUnitDataList)
            {
                // 検索キー作成
                goodsInfoKey = new GoodsInfoKey(goodsUnitData.GoodsNo, goodsUnitData.GoodsMakerCd);

                // メーカー希望小売価格情報作成
                PartsInfoDataSet.UsrGoodsPriceRow[] usrGoodsPriceRows =
                    (PartsInfoDataSet.UsrGoodsPriceRow[])partsInfoDataSet.UsrGoodsPrice.Select(
                        string.Format("GoodsMakerCd = '{0}' AND GoodsNo = '{1}'",
                        goodsUnitData.GoodsMakerCd,
                        goodsUnitData.GoodsNo));

                // 提供データ価格情報データテーブルから価格一覧を作成
                _mkrSuggestRtPricUList = GetGoodsPriceList(usrGoodsPriceRows);

                // メーカー希望小売価格情報（ユーザー登録分）登録済みチェック
                if (mkrSuggestRtPricUList.ContainsKey(goodsInfoKey))
                {
                    // 登録済み
                    // 更新フラグがtrueの場合、旧データを削除し新データを追加する
                    // 更新フラグがfalseの場合、データ追加を行わない
                    if (isUpdate)
                    {
                        mkrSuggestRtPricUList.Remove(goodsInfoKey);
                        mkrSuggestRtPricUList.Add(goodsInfoKey, _mkrSuggestRtPricUList);
                    }
                }
                else
                {
                    // 未登録
                    mkrSuggestRtPricUList.Add(goodsInfoKey, _mkrSuggestRtPricUList);
                }

                // メーカー希望小売価格情報作成
                PartsInfoDataSet.UsrGoodsPriceRow[] ofrPriceRows =
                    (PartsInfoDataSet.UsrGoodsPriceRow[])partsInfoDataSet.OfrPriceDataTable.Select(
                        string.Format("GoodsMakerCd = '{0}' AND GoodsNo = '{1}'",
                        goodsUnitData.GoodsMakerCd,
                        goodsUnitData.GoodsNo));

                // 提供データ価格情報データテーブルから価格一覧を作成
                _mkrSuggestRtPricList = GetGoodsPriceList(ofrPriceRows);

                // メーカー希望小売価格情報登録済みチェック
                if (mkrSuggestRtPricList.ContainsKey(goodsInfoKey))
                {
                    // 登録済み
                    // 更新フラグがtrueの場合、旧データを削除し新データを追加する
                    // 更新フラグがfalseの場合、データ追加を行わない
                    if (isUpdate)
                    {
                        mkrSuggestRtPricUList.Remove(goodsInfoKey);
                        mkrSuggestRtPricList.Add(goodsInfoKey, _mkrSuggestRtPricList);
                    }
                }
                else
                {
                    // 未登録
                    mkrSuggestRtPricList.Add(goodsInfoKey, _mkrSuggestRtPricList);
                }
            }
        }

        private List<GoodsPrice> GetGoodsPriceList(PartsInfoDataSet.UsrGoodsPriceRow[] priceRows)
        {
            List<GoodsPrice> retList = new List<GoodsPrice>();

            if (priceRows != null)
            {
                // メーカー希望小売価格情報作成
                for (int j = 0; j < priceRows.Length; j++)
                {
                    GoodsPrice prc = new GoodsPrice();
                    prc.CreateDateTime = new DateTime(priceRows[j].CreateDateTime);
                    prc.UpdateDateTime = new DateTime(priceRows[j].UpdateDateTime);
                    prc.EnterpriseCode = priceRows[j].EnterpriseCode;
                    if (priceRows[j].IsFileHeaderGuidNull() == false)
                        prc.FileHeaderGuid = priceRows[j].FileHeaderGuid;
                    prc.UpdAssemblyId1 = priceRows[j].UpdAssemblyId1;
                    prc.UpdAssemblyId2 = priceRows[j].UpdAssemblyId2;
                    prc.UpdEmployeeCode = priceRows[j].UpdEmployeeCode;
                    prc.LogicalDeleteCode = priceRows[j].LogicalDeleteCode;

                    prc.GoodsMakerCd = priceRows[j].GoodsMakerCd;
                    prc.GoodsNo = priceRows[j].GoodsNo;
                    prc.ListPrice = priceRows[j].ListPrice;
                    prc.OpenPriceDiv = priceRows[j].OpenPriceDiv;
                    prc.PriceStartDate = priceRows[j].PriceStartDate;
                    prc.SalesUnitCost = priceRows[j].SalesUnitCost;
                    prc.StockRate = priceRows[j].StockRate;
                    if (priceRows[j].IsUpdateDateNull() == false)
                    {
                        prc.UpdateDate = priceRows[j].UpdateDate;
                    }
                    else
                    {
                        prc.UpdateDate = DateTime.MinValue;
                    }
                    prc.OfferDate = priceRows[j].OfferDate;
                    retList.Add(prc);
                }
            }
            return retList;
        }
        /// <summary>
        /// 指定日条件該当価格情報データオブジェクト取得処理
        /// </summary>
        /// <param name="targetDateTime">価格開始日</param>
        /// <param name="goodsPriceList">価格情報データオブジェクトリスト</param>
        /// <returns>価格情報データオブジェクト</returns>
        public GoodsPrice GetGoodsPrice(DateTime targetDateTime, List<GoodsPrice> goodsPriceList)
        {
            return this._goodsAcs.GetGoodsPriceFromGoodsPriceList(targetDateTime, goodsPriceList);
        }

        /// <summary>
        ///  提供データの価格情報を取得します
        /// </summary>
        /// <param name="goodsUnitData"></param>
        /// <param name="mkrSuggestRtPricList"></param>
        private void GetOfferGoodsPrice(GoodsUnitData goodsUnitData, out List<GoodsPrice> mkrSuggestRtPricList)
        {
            mkrSuggestRtPricList = null;

            if (goodsUnitData == null) return;

            // メーカーコード、品番より提供データの価格情報を取得
            ArrayList goodsPriceUWorkList = new ArrayList();
            GoodsPriceUWork goodsPriceUWork = new GoodsPriceUWork();
            ArrayList lstCond = new ArrayList();
            ArrayList lstRst;
            ArrayList lstRstPrm;
            ArrayList lstPrmPrice;

            OfrPrtsSrchCndWork work = new OfrPrtsSrchCndWork();
            work.MakerCode = goodsUnitData.GoodsMakerCd;
            work.PrtsNo = goodsUnitData.GoodsNo;
            lstCond.Add(work);

            if (_iOfferPartsInfo == null) _iOfferPartsInfo = MediationOfferPartsInfo.GetOfferPartsInfo();
            int status = _iOfferPartsInfo.GetOfrPartsInf(lstCond, out lstRst, out lstRstPrm, out lstPrmPrice);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if ((lstPrmPrice != null) && (lstPrmPrice.Count != 0))
                {
                    // 優良価格
                    foreach (OfferJoinPriceRetWork retWork in lstPrmPrice)
                    {
                        goodsPriceUWork = new GoodsPriceUWork();
                        goodsPriceUWork.GoodsMakerCd = retWork.PartsMakerCd;
                        goodsPriceUWork.GoodsNo = retWork.PrimePartsNoWithH;
                        goodsPriceUWork.ListPrice = retWork.NewPrice;
                        goodsPriceUWork.OfferDate = retWork.OfferDate;
                        goodsPriceUWork.OpenPriceDiv = retWork.OpenPriceDiv;
                        goodsPriceUWork.PriceStartDate = retWork.PriceStartDate;

                        goodsPriceUWorkList.Add(goodsPriceUWork);
                    }
                }
                if ((lstRst != null) && (lstRst.Count != 0))
                {
                    // 純正価格
                    foreach (RetPartsInf retWork in lstRst)
                    {
                        goodsPriceUWork = new GoodsPriceUWork();
                        goodsPriceUWork.GoodsMakerCd = retWork.CatalogPartsMakerCd;
                        goodsPriceUWork.GoodsNo = retWork.ClgPrtsNoWithHyphen;
                        // 離島価格を反映しない
                        goodsPriceUWork.ListPrice = retWork.PartsPrice;
                        goodsPriceUWork.OfferDate = retWork.OfferDate;
                        goodsPriceUWork.OpenPriceDiv = retWork.OpenPriceDiv;
                        goodsPriceUWork.PriceStartDate = retWork.PartsPriceStDate;

                        goodsPriceUWorkList.Add(goodsPriceUWork);
                    }
                }
            }

            if (goodsPriceUWorkList != null && goodsPriceUWorkList.Count != 0)
            {
                // 価格情報リスト(ArrayList)をGoodsPriceのリストに変換
                this.GetGoodsPriceListFromGoodsPriceUWorkList(goodsPriceUWorkList, out mkrSuggestRtPricList);
            }
        }

        /// <summary>
        /// 価格情報データオブジェクトリスト取得処理
        /// </summary>
        /// <param name="goodsPriceWorkList">価格情報データワークオブジェクトリスト</param>
        /// <param name="goodsPriceList">価格情報データオブジェクトリスト</param>
        private void GetGoodsPriceListFromGoodsPriceUWorkList(ArrayList goodsPriceWorkList, out List<GoodsPrice> goodsPriceList)
        {
            goodsPriceList = new List<GoodsPrice>();

            foreach (GoodsPriceUWork goodsPriceUWork in goodsPriceWorkList)
            {
                GoodsPrice goodsPrice = new GoodsPrice();

                goodsPrice.CreateDateTime = goodsPriceUWork.CreateDateTime; // 作成日時
                goodsPrice.UpdateDateTime = goodsPriceUWork.UpdateDateTime; // 更新日時
                goodsPrice.EnterpriseCode = goodsPriceUWork.EnterpriseCode; // 企業コード
                goodsPrice.FileHeaderGuid = goodsPriceUWork.FileHeaderGuid; // GUID
                goodsPrice.UpdEmployeeCode = goodsPriceUWork.UpdEmployeeCode; // 更新従業員コード
                goodsPrice.UpdAssemblyId1 = goodsPriceUWork.UpdAssemblyId1; // 更新アセンブリID1
                goodsPrice.UpdAssemblyId2 = goodsPriceUWork.UpdAssemblyId2; // 更新アセンブリID2
                goodsPrice.LogicalDeleteCode = goodsPriceUWork.LogicalDeleteCode; // 論理削除区分
                goodsPrice.GoodsMakerCd = goodsPriceUWork.GoodsMakerCd; // 商品メーカーコード
                goodsPrice.GoodsNo = goodsPriceUWork.GoodsNo; // 商品番号
                goodsPrice.PriceStartDate = goodsPriceUWork.PriceStartDate; // 価格開始日
                goodsPrice.ListPrice = goodsPriceUWork.ListPrice; // 定価（浮動）
                goodsPrice.SalesUnitCost = goodsPriceUWork.SalesUnitCost; // 原価単価
                goodsPrice.StockRate = goodsPriceUWork.StockRate; // 仕入率
                goodsPrice.OpenPriceDiv = goodsPriceUWork.OpenPriceDiv; // オープン価格区分
                goodsPrice.OfferDate = goodsPriceUWork.OfferDate; // 提供日付
                goodsPrice.UpdateDate = goodsPriceUWork.UpdateDate; // 更新年月日

                goodsPriceList.Add(goodsPrice);
            }
        }
        // --- ADD 2015/03/25 Y.Wakita ----------<<<<<
        #endregion

        #region 定価
        /// <summary>
        /// 定価を取得します。
        /// </summary>
        /// <returns>定価</returns>
        private double GetListPrice(List<UnitPriceCalcRet> unitPriceList)
        {
            double retListPrice = 0;

            #region <Guard Phrase>

            if (unitPriceList == null || unitPriceList.Count == 0) return retListPrice;

            #endregion // </Guard Phrase>

            foreach (UnitPriceCalcRet unitPriceCalcRet in unitPriceList)
            {
                if (unitPriceCalcRet.UnitPriceKind.Equals(UnitPriceCalculation.ctUnitPriceKind_ListPrice))
                {
                    retListPrice = unitPriceCalcRet.UnitPriceTaxExcFl;
                    break;
                }
            }
            return retListPrice;
        }
        #endregion

        #region 売価
        /// <summary>
        /// 単価を取得します。
        /// </summary>
        /// <returns>単価</returns>
        public double GetUnitPrice(List<UnitPriceCalcRet> unitPriceList, GoodsUnitData goodsUnitData, int customerCode, DateTime startDate, UnitPriceCalcParam condition, string sectionCode)
        {
            double retUnitPrice = 0;

            #region <Guard Phrase>

            if (unitPriceList == null || unitPriceList.Count == 0) return retUnitPrice;
            if (goodsUnitData == null) return retUnitPrice;

            #endregion // </Guard Phrase>

            double unitPrice = 0;
            UnitPriceCalcRet sellingPriceResult = null;

            foreach (UnitPriceCalcRet unitPriceCalcRet in unitPriceList)
            {
                if (unitPriceCalcRet.UnitPriceKind.Equals(UnitPriceCalculation.ctUnitPriceKind_SalesUnitPrice))
                {
                    sellingPriceResult = new UnitPriceCalcRet();
                    sellingPriceResult = unitPriceCalcRet;
                    break;
                }
            }

            if (sellingPriceResult != null)
            {
                unitPrice = sellingPriceResult.UnitPriceTaxExcFl;  // 単価は単価(税抜, 浮動)
            }
            else
            {
                // 売価未設定区分が「1:定価表示」の場合、定価を使用
                if (this._salesTtlStAgent.UsesListPriceIfSalesPriceIsNone(
                    this._enterpriseCode,
                    sectionCode
                ))
                {
                    unitPrice = this.GetListPrice(unitPriceList);
                }
            }

            double listPrice = this.GetListPrice(unitPriceList); // 定価
            double price = unitPrice; // 売価
            double priceTaxExc = 0; // 売価（税抜）
            double priceTaxInc = 0; // 売価（税込）

            // キャンペーン情報取得
            ReflectCampaign(goodsUnitData.TaxationDivCd, customerCode, goodsUnitData.BLGoodsCode, goodsUnitData.GoodsMakerCd, goodsUnitData.GoodsNo.Trim(), goodsUnitData.BLGroupCode, 0, startDate, sectionCode);

            if (this._campaignObjGoodsSt != null)
            {
                // キャンペーン価格適用
                if (this._campaignObjGoodsSt.PriceFl != 0)
                {
                    price = this._campaignObjGoodsSt.PriceFl;
                }
                // キャンペーン売価率適用
                if (this._campaignObjGoodsSt.RateVal != 0)
                {
                    this.CalclatePriceByRate(goodsUnitData.TaxationDivCd, this._campaignObjGoodsSt.RateVal, condition.SalesCnsTaxFrcProcCd, condition.SalesUnPrcFrcProcCd, condition.TotalAmountDispWayCd, condition.TaxRate, ref listPrice);
                    price = listPrice;
                }
                // キャンペーン値引率適用
                if (this._campaignObjGoodsSt.DiscountRate != 0)
                {
                    this.CalclatePriceByRate(goodsUnitData.TaxationDivCd, 100 - this._campaignObjGoodsSt.DiscountRate, condition.SalesCnsTaxFrcProcCd, condition.SalesUnPrcFrcProcCd, condition.TotalAmountDispWayCd, condition.TaxRate, ref price);
                }
            }
            // 価格再計算
            this.CalcTaxExcAndTaxInc(condition.TaxationDivCd, customerCode, condition.TaxRate, condition.TotalAmountDispWayCd, price, out priceTaxExc, out priceTaxInc);
            retUnitPrice = priceTaxExc;

            return retUnitPrice;
        }

        /// <summary>
        /// 掛率より金額取得
        /// </summary>
        /// <param name="taxationDivCd"></param>
        /// <param name="autoCooperatDis"></param>
        /// <param name="price"></param>
        private void CalclatePriceByRate(int taxationDivCd, double autoCooperatDis, int salesCnsTaxFrcProcCd, int frcProcCd, int totalAmountDispWayCd, double taxRate, ref double price)
        {
            double unitPriceTaxExc = 0;
            double unitPriceTaxInc = 0;

            // 消費税端数処理
            int taxFracProcCd = 0;
            double taxFracProcUnit = 0;
            this.GetSalesFractionProcInfo(ctFracProcMoneyDiv_Tax, salesCnsTaxFrcProcCd, 0, out taxFracProcUnit, out taxFracProcCd);

            // 売上単価端数処理
            double fracProcUnit = 0;
            int fracProcDiv = 0;
            this.GetSalesFractionProcInfo(ctFracProcMoneyDiv_SalesUnitPrice, salesCnsTaxFrcProcCd, 0, out fracProcUnit, out fracProcDiv);
            // 掛率による単価計算
            this._unitPriceCalculation.CalculateUnitPriceByRate(UnitPriceCalculation.UnitPriceKind.SalesUnitPrice,
                                            UnitPriceCalculation.UnitPrcCalcDiv.RateVal,
                                            0,
                                            0,
                                            frcProcCd,
                                            taxationDivCd,
                                            price,
                                            taxRate,
                                            taxFracProcUnit,
                                            taxFracProcCd,
                                            autoCooperatDis,
                                            ref fracProcUnit,
                                            ref fracProcDiv,
                                            out unitPriceTaxExc,
                                            out unitPriceTaxInc);

            if (taxationDivCd == (int)CalculateTax.TaxationCode.TaxInc)
            {
                price = unitPriceTaxInc;
            }
            else
            {
                price = unitPriceTaxExc;
            }
        }

        #region 単価計算
        /// <summary>
        /// 対象金額より、税抜き、税込み価格を計算します。
        /// </summary>
        /// <param name="taxationCode">課税区分</param>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="taxRate">税率</param>
        /// <param name="totalAmountDispWayCd">総額表示区分</param>
        /// <param name="displayPrice">対象金額</param>
        /// <param name="priceTaxExc">税抜き金額</param>
        /// <param name="priceTaxInc">税込み金額</param>
        private void CalcTaxExcAndTaxInc(int taxationCode, int customerCode, double taxRate, int totalAmountDispWayCd, double displayPrice, out double priceTaxExc, out double priceTaxInc)
        {
            priceTaxExc = 0;
            priceTaxInc = 0;
            // 得意先マスタから消費税端数処理情報を取得
            int salesTaxFrcProcCd = this._customerInfoAcs.GetSalesFractionProcCd(this._enterpriseCode, customerCode, CustomerInfoAcs.FracProcMoneyDiv.CnsTaxFrcProcCd);		// 売上消費税端数処理コード
            double fracProcUnit;
            int fracProcCd;
            this.GetSalesFractionProcInfo(ctFracProcMoneyDiv_Tax, salesTaxFrcProcCd, 0, out fracProcUnit, out fracProcCd);

            // 内税品
            if (taxationCode == (int)CalculateTax.TaxationCode.TaxInc)
            {
                priceTaxInc = displayPrice;
                priceTaxExc = displayPrice - CalculateTax.GetTaxFromPriceInc(taxRate, fracProcUnit, fracProcCd, priceTaxInc);
            }
            // 外税品
            else if (taxationCode == (int)CalculateTax.TaxationCode.TaxExc)
            {
                // 総額表示している場合は税込み価格
                if (totalAmountDispWayCd == 1)
                {
                    priceTaxInc = displayPrice;
                    priceTaxExc = displayPrice - CalculateTax.GetTaxFromPriceInc(taxRate, fracProcUnit, fracProcCd, priceTaxInc);
                }
                else
                {
                    priceTaxExc = displayPrice;
                    priceTaxInc = displayPrice + CalculateTax.GetTaxFromPriceExc(taxRate, fracProcUnit, fracProcCd, priceTaxExc);
                }
            }
            // 非課税品
            else if (taxationCode == (int)CalculateTax.TaxationCode.TaxNone)
            {
                priceTaxExc = displayPrice;
                priceTaxInc = displayPrice;
            }
            else
            {
                priceTaxExc = 0;
                priceTaxInc = 0;
            }
        }
        #endregion 

        #region 売上金額処理区分設定マスタ データ取得処理関連
        /// <summary>
        /// 端数処理単位、端数処理区分取得処理
        /// </summary>
        /// <param name="fracProcMoneyDiv">端数処理対象金額区分</param>
        /// <param name="fractionProcCode">端数処理コード</param>
        /// <param name="targetPrice">対象金額</param>
        /// <param name="fractionProcUnit">端数処理単位</param>
        /// <param name="fractionProcCd">端数処理区分</param>
        private void GetSalesFractionProcInfo(int fracProcMoneyDiv, int fractionProcCode, double targetPrice, out double fractionProcUnit, out int fractionProcCd)
        {
            //-----------------------------------------------------------------------------
            // 初期値
            //-----------------------------------------------------------------------------
            switch (fracProcMoneyDiv)
            {
                case ctFracProcMoneyDiv_SalesUnitPrice: // 単価は0.01円単位
                    fractionProcUnit = 0.01;
                    break;
                default:
                    fractionProcUnit = 1;               // 単価以外は1円単位
                    break;
            }
            fractionProcCd = 1;     // 切捨て

            //-----------------------------------------------------------------------------
            // コード該当レコード取得
            //-----------------------------------------------------------------------------
            List<SalesProcMoney> salesProcMoneyList = this._salesProcMoneyList.FindAll(
                delegate(SalesProcMoney sProcMoney)
                {
                    if ((sProcMoney.FracProcMoneyDiv == fracProcMoneyDiv) &&
                        (sProcMoney.FractionProcCode == fractionProcCode))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            );

            //-----------------------------------------------------------------------------
            // ソート（上限金額（昇順））
            //-----------------------------------------------------------------------------
            salesProcMoneyList.Sort(new SalesProcMoneyComparer());

            //-----------------------------------------------------------------------------
            // 上限金額該当レコード取得
            //-----------------------------------------------------------------------------
            SalesProcMoney salesProcMoney = salesProcMoneyList.Find(
                delegate(SalesProcMoney spm)
                {
                    if (spm.UpperLimitPrice >= targetPrice)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            );

            //-----------------------------------------------------------------------------
            // 戻り値設定
            //-----------------------------------------------------------------------------
            if (salesProcMoney != null)
            {
                fractionProcUnit = salesProcMoney.FractionProcUnit;
                fractionProcCd = salesProcMoney.FractionProcCd;
            }
        }

        /// <summary>
        /// 売上金額処理区分マスタ比較クラス(上限金額(昇順))
        /// </summary>
        private class SalesProcMoneyComparer : Comparer<SalesProcMoney>
        {
            public override int Compare(SalesProcMoney x, SalesProcMoney y)
            {
                int result = x.UpperLimitPrice.CompareTo(y.UpperLimitPrice);
                return result;
            }
        }
        #endregion

        #endregion

        #region ﾒｰｶｰ希望小売価格、定価、売価の取得
        /// <summary>
        ///  部品情報よりﾒｰｶｰ希望小売価格、定価、売価を取得します
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="mkrSuggestRtPric">ﾒｰｶｰ希望小売価格</param>
        /// <param name="rateVal">売価率</param>
        /// <param name="goodsUnitData">商品情報</param>
        /// <param name="startDate">開始日</param>
        /// <param name="listPrice">定価</param>
        /// <param name="unitPrice">売価</param>
        public void GetUnitPriceFromRate(
            string sectionCode,
            int customerCode,
            long mkrSuggestRtPric,
            double rateVal,
            GoodsUnitData goodsUnitData,
            DateTime startDate,
            out double listPrice,
            out double unitPrice
        )
        {
            unitPrice = 0.0;
            listPrice = 0.0;

            #region <Guard Phrase>

            // 商品情報が空の時は処理終了
            if (goodsUnitData == null) return;
            // 開始日が初期値の時は処理終了
            if (startDate == DateTime.MinValue) return;

            #endregion // </Guard Phrase>

            {
                // 価格算出パラメータ設定
                UnitPriceCalcParam condition = new UnitPriceCalcParam();
                {
                    condition.BLGoodsCode = goodsUnitData.BLGoodsCode;  // BLコード 
                    condition.BLGoodsName = goodsUnitData.BLGoodsName;  // BLコード名称
                    condition.BLGroupCode = goodsUnitData.BLGroupCode;  // BLグループコード
                    condition.CountFl = 1;                              // 数量
                    condition.CustomerCode = customerCode;              // 得意先コード

                    // 得意先情報取得
                    if (customerCode != 0)
                    {
                        GetCustomerInfo(customerCode);
                    }

                    // 売上金額処理区分リスト取得
                    GetSalesProcMoney();

                    // 得意先掛率グループコード
                    condition.CustRateGrpCode = this.GetCustomerRateGroupCode(
                        this._enterpriseCode,
                        customerCode,
                        goodsUnitData.GoodsMakerCd
                    );

                    condition.GoodsMakerCd = goodsUnitData.GoodsMakerCd;            // メーカーコード
                    condition.GoodsNo = goodsUnitData.GoodsNo;                      // 品番
                    condition.GoodsRateGrpCode = goodsUnitData.GoodsRateGrpCode;    // 商品掛率グループコード
                    condition.GoodsRateRank = goodsUnitData.GoodsRateRank;          // 商品掛率ランク

                    condition.PriceApplyDate = startDate;                           // 適用日

                    // 売上消費税端数処理コード
                    condition.SalesCnsTaxFrcProcCd = this._customerInfoAcs.GetSalesFractionProcCd(this._enterpriseCode, customerCode, CustomerInfoAcs.FracProcMoneyDiv.CnsTaxFrcProcCd);
                    // 売上単価端数処理コード
                    condition.SalesUnPrcFrcProcCd = this._customerInfoAcs.GetSalesFractionProcCd(this._enterpriseCode, customerCode, CustomerInfoAcs.FracProcMoneyDiv.UnPrcFrcProcCd);

                    condition.SectionCode = sectionCode;                            // 拠点コード

                    // 仕入消費税端数処理コード
                    condition.StockCnsTaxFrcProcCd = this._supplierAcs.GetStockFractionProcCd(this._enterpriseCode, goodsUnitData.SupplierCd, SupplierAcs.StockFracProcMoneyDiv.CnsTaxFrcProcCd);
                    // 仕入単価端数処理コード
                    condition.StockUnPrcFrcProcCd = this._supplierAcs.GetStockFractionProcCd(this._enterpriseCode, goodsUnitData.SupplierCd, SupplierAcs.StockFracProcMoneyDiv.UnPrcFrcProcCd);

                    condition.SupplierCd = goodsUnitData.SupplierCd;                // 仕入先コード
                    condition.TaxationDivCd = goodsUnitData.TaxationDivCd;          // 課税区分
                    condition.TaxRate = this.GetTaxRate(startDate);                 // 税率

                    // 請求先情報取得
                    CustomerInfo claim = ClaimInfo(customerCode);
                    if (claim != null)
                    {
                        // 請求先取得時は請求先情報の消費税転嫁方式を設定する
                        condition.ConsTaxLayMethod = claim.CustCTaXLayRefCd == 0 ? this._taxRateSet.ConsTaxLayMethod : claim.ConsTaxLayMethod;
                    }
                    else
                    {
                        // 請求先が取得できない場合は、税率設定マスタの消費税転嫁方式を設定
                        condition.ConsTaxLayMethod = this._taxRateSet.ConsTaxLayMethod;
                    }

                    condition.TotalAmountDispWayCd = 0; // 総額表示方法区分
                    condition.TtlAmntDspRateDivCd = 0;  // 総額表示掛率適用区分 0:(税込金額×掛率) 1:(税抜金額×掛率)から消費税を求め合算(消費税算出時消費税の端数処理が動作)
                }

                this._unitPriceCalculation.RatePriorityDiv = GetCompanyInf(this._enterpriseCode).RatePriorityDiv; //自社設定･掛率優先順位

                this._unitPriceCalculation.CacheSalesProcMoneyList(this._salesProcMoneyList); // 売上金額処理区分リストキャッシュ

                // 売価取得
                this.GetUnitPriceFromRate(sectionCode, customerCode, mkrSuggestRtPric, rateVal, goodsUnitData, condition, out listPrice, out unitPrice);
            }
        }


        /// <summary>
        /// 単価を取得します。
        /// </summary>
        /// <returns>単価</returns>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="mkrSuggestRtPric">ﾒｰｶｰ希望小売価格</param>
        /// <param name="rateVal">売価率</param>
        /// <param name="goodsUnitData">商品情報</param>
        /// <param name="condition"></param>
        /// <param name="listPrice">定価</param>
        /// <param name="unitPrice">売価</param>
        public void GetUnitPriceFromRate(
            string sectionCode,
            int customerCode,
            long mkrSuggestRtPric,
            double rateVal,
            GoodsUnitData goodsUnitData,
            UnitPriceCalcParam condition,
            out double listPrice,
            out double unitPrice)
        {
            unitPrice = 0.0;
            listPrice = 0.0;
            double retUnitPrice = unitPrice;
            double retListPrice = listPrice;

            double price = unitPrice;   // 売価
            double priceTaxExc = 0;     // 売価（税抜）
            double priceTaxInc = 0;     // 売価（税込）

            retListPrice = mkrSuggestRtPric; // ﾒｰｶｰ希望小売価格

            // 売価率適用
            this.CalclatePriceByRate(
                goodsUnitData.TaxationDivCd,
                rateVal,
                condition.SalesCnsTaxFrcProcCd,
                condition.SalesUnPrcFrcProcCd,
                condition.TotalAmountDispWayCd,
                condition.TaxRate,
                ref retListPrice);

            // 価格再計算
            this.CalcTaxExcAndTaxInc(
                condition.TaxationDivCd,
                customerCode,
                condition.TaxRate,
                condition.TotalAmountDispWayCd,
                retListPrice,
                out priceTaxExc,
                out priceTaxInc);

            listPrice = retListPrice;
            unitPrice = priceTaxExc;

        }
        #endregion

        #endregion

        // --- ADD 2015/03/25 Y.Wakita ---------->>>>>
        /// <summary>
        /// 商品自動登録データキー構造体
        /// </summary>
        public struct GoodsInfoKey
        {
            string _goodsNo;
            int _goodsMakerCd;

            /// <summary>
            /// 商品自動登録データキー構造体コンストラクタ
            /// </summary>
            /// <param name="goodsNo"></param>
            /// <param name="goodsMakeCd"></param>
            internal GoodsInfoKey(string goodsNo, int goodsMakeCd)
            {
                this._goodsNo = goodsNo;
                this._goodsMakerCd = goodsMakeCd;
            }

            /// <summary>品番プロパティ</summary>
            internal string GoodsNo
            {
                get { return this._goodsNo; }
                set { this._goodsNo = value; }
            }

            /// <summary>メーカープロパティ</summary>
            internal int GoodsMakerCd
            {
                get { return this._goodsMakerCd; }
                set { this._goodsMakerCd = value; }
            }
        }
        // --- ADD 2015/03/25 Y.Wakita ----------<<<<<
    }
}
