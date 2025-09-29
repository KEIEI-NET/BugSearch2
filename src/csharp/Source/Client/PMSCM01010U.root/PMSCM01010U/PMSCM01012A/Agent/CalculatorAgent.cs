//****************************************************************************//
// システム         : 自働回答処理
// プログラム名称   : 自働回答処理アクセス
// プログラム概要   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤 恵優
// 作 成 日  2009/05/22  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : LDNS wangqx
// 作 成 日  2011/09/19  修正内容 : ReadMine#25267
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : LDNS wangqx
// 作 成 日  2011/10/08  修正内容 : ReadMine#25800
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 高峰
// 作 成 日  2011/10/12  修正内容 : ReadMine#25768
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 湯上 千加子
// 作 成 日  2012/11/08  修正内容 : 2012/11/14配信 システムテスト障害対応
//----------------------------------------------------------------------------//
// 管理番号  10902175-00 作成担当 : 宮本 利明
// 作 成 日  2013/08/07  修正内容 : Redmine#39620(旧#128)対応
//                                  自社設定の掛率優先順位を参照するように修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 湯上 千加子
// 作 成 日  2013/10/25  修正内容 : 201311XX配信予定システムテスト障害№13,14対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 湯上 千加子
// 作 成 日  2013/11/19  修正内容 : 201312xx配信予定ｼｽﾃﾑﾃｽﾄ障害№22対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 湯上 千加子
// 作 成 日  2014/01/30  修正内容 : Redmine#41771 障害№13対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 湯上 千加子
// 作 成 日  2014/02/05  修正内容 : SCM仕掛一覧№10627対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30745 吉岡 孝憲
// 作 成 日  2014/02/05  修正内容 : 仕掛一覧№10631 自動回答速度改善 掛率マスタキャッシュ
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 湯上
// 作 成 日  2015/01/07  修正内容 : メーカー希望小売価格対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 湯上
// 作 成 日  2015/03/10  修正内容 : SCM社内障害一覧№98対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 湯上
// 作 成 日  2015/03/18  修正内容 : SCM高速化 メーカー希望小売価格対応 2015/01/07対応分を除外
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;

using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;

namespace Broadleaf.Application.Controller.Agent
{
    using RealAccesserType  = UnitPriceCalculation;
    using RecordType        = IList<UnitPriceCalcRet>;

    /// <summary>
    /// 価格算出系クラスの代理人クラス
    /// </summary>
    public sealed class CalculatorAgent : AgentPolicy<RealAccesserType, RecordType>
    {
        // --- ADD 2013/08/07 T.Miyamoto ------------------------------>>>>>
        #region <自社設定>
        private CompanyInf _companyInf;
        /// <summary>
        /// 自社設定情報取得
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns>自社設定情報</returns>
        public CompanyInf GetCompanyInf(string enterpriseCode)
        {
            // ADD 2014/02/05 SCM仕掛一覧№10627対応 ----------------------------------->>>>>
            if (_companyInf == null)
            {
            // ADD 2014/02/05 SCM仕掛一覧№10627対応 -----------------------------------<<<<<
                CompanyInfAcs companyInfAcs = new CompanyInfAcs();
                companyInfAcs.Read(out this._companyInf, enterpriseCode);
            // ADD 2014/02/05 SCM仕掛一覧№10627対応 ----------------------------------->>>>>
            }
            // ADD 2014/02/05 SCM仕掛一覧№10627対応 -----------------------------------<<<<<
            return _companyInf;
        }
        #endregion // </自社設定>
        // --- ADD 2013/08/07 T.Miyamoto ------------------------------<<<<<

        #region <得意先マスタ>

        /// <summary>得意先マスタのアクセサ</summary>
        private CustomerAgent _customerDB;
        /// <summary>得意先マスタのアクセサを取得します。</summary>
        public CustomerAgent CustomerDB
        {
            get
            {
                if (_customerDB == null)
                {
                    _customerDB = new CustomerAgent();
                }
                return _customerDB;
            }
        }

        /// <summary>
        /// 得意先掛率グループを取得します。
        /// </summary>
        /// <remarks>
        /// <c>SCMPriceCalculator.CurrentCustomerRateGroupList</c>
        /// と同じ処理となるので、統合するのが望ましい。
        /// </remarks>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="customerCode">得意先コード</param>
        /// <returns>得意先掛率グループ</returns>
        private List<CustRateGroup> GetCustomerRateGroupList(
            string enterpriseCode,
            int customerCode
        )
        {
            if (CustomerDB.CustomerRateGroupMap.ContainsKey(customerCode))
            {
                return CustomerDB.CustomerRateGroupMap[customerCode];
            }
            else
            {
                CustomerDB.TakeCustomerInfo(enterpriseCode, customerCode);
                if (CustomerDB.CustomerRateGroupMap.ContainsKey(customerCode))
                {
                    return CustomerDB.CustomerRateGroupMap[customerCode];
                }
                else
                {
                    return new List<CustRateGroup>();
                }
            }
        }

        // ADD 2014/02/05 SCM仕掛一覧№10627対応 ----------------------------------->>>>>
        /// <summary>
        /// 請求先情報の取得
        /// 　得意先コードから請求先情報を取得する
        /// </summary>
        /// <param name="customerCode">得意先コード</param>
        /// <returns>請求先情報 取得できない場合はnull</returns>
        public CustomerInfo ClaimInfo(int customerCode)
        {
            CustomerInfo claim = null;
            CustomerInfo customerInfo = CustomerDB.CustomerInfoMap[customerCode];
            if (customerInfo != null)
            {
                if (customerInfo.CustomerCode.Equals(customerInfo.ClaimCode))
                {
                    // 得意先と請求先が同じ場合
                    claim = customerInfo.Clone();
                }
                else if (CustomerDB.CustomerInfoMap.ContainsKey(customerInfo.ClaimCode))
                {
                    // 請求先情報がすでに取得済みの場合
                    claim = CustomerDB.CustomerInfoMap[customerInfo.ClaimCode];
                }
                else
                {
                    // 請求先情報が取得されていない場合
                    CustomerDB.TakeCustomerInfo(customerInfo.EnterpriseCode, customerInfo.ClaimCode);
                    if (CustomerDB.CustomerInfoMap.ContainsKey(customerInfo.ClaimCode))
                    {
                        claim = CustomerDB.CustomerInfoMap[customerInfo.ClaimCode];
                    }
                }
            }

            return claim;
        }
        // ADD 2014/02/05 SCM仕掛一覧№10627対応 -----------------------------------<<<<<

        #endregion // </得意先マスタ>

        #region <仕入先マスタ>

        /// <summary>仕入先マスタのアクセサ</summary>
        private SupplierAgent _supplierDB;
        /// <summary>仕入先マスタのアクセサを取得します。</summary>
        public SupplierAgent SupplierDB
        {
            get
            {
                if (_supplierDB == null)
                {
                    _supplierDB = new SupplierAgent();
                }
                return _supplierDB;
            }
        }

        #endregion // </仕入先マスタ>

        #region <Constructor>

        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public CalculatorAgent() : base() { }

        #endregion // </Constructor>

        /// <summary>
        /// 単価を取得します。
        /// </summary>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="detailRecord">SCM受注明細データ(問合せ・発注)のレコード</param>
        /// <param name="goodsUnitData">商品連結データ</param>
        /// <param name="cancelDiv">キャンセル区分</param>
        /// <param name="inquiryDate">問合せ日</param>
        /// <returns>単価算出結果のリスト</returns>
        // UPD 2014/01/30 Redmine#41771-障害№13対応 ------------------------------------------------------>>>>>
        //public IList<UnitPriceCalcRet> GetUnitPrice(
        //    int customerCode,
        //    ISCMOrderDetailRecord detailRecord,
        //    GoodsUnitData goodsUnitData
        //)
        public IList<UnitPriceCalcRet> GetUnitPrice(
            int customerCode,
            ISCMOrderDetailRecord detailRecord,
            GoodsUnitData goodsUnitData,
            short cancelDiv,
            DateTime inquiryDate
        )
        // UPD 2014/01/30 Redmine#41771-障害№13対応 ------------------------------------------------------<<<<<
        {
            List<UnitPriceCalcRet> unitPriceList = null;
            {
                UnitPriceCalcParam condition = new UnitPriceCalcParam();
                {
                    //condition.BLGoodsCode = goodsUnitData.BLGroupCode;  // BLコード // DEL 2011/10/12
                    condition.BLGoodsCode = goodsUnitData.BLGoodsCode;  // BLコード // ADD 2011/10/12
                    condition.BLGoodsName = goodsUnitData.BLGoodsName;  // BLコード名称
                    condition.BLGroupCode = goodsUnitData.BLGroupCode;  // BLグループコード

                    condition.CountFl = detailRecord.SalesOrderCount;   // 数量
                    condition.CustomerCode = customerCode;              // 得意先コード

                    // 得意先掛率グループコード
                    condition.CustRateGrpCode = GetCustomerRateGroupCode(
                        detailRecord.InqOtherEpCd,
                        customerCode,
                        goodsUnitData.GoodsMakerCd
                    );

                    condition.GoodsMakerCd      = goodsUnitData.GoodsMakerCd;       // メーカーコード
                    condition.GoodsNo           = goodsUnitData.GoodsNo;            // 品番
                    condition.GoodsRateGrpCode  = goodsUnitData.GoodsRateGrpCode;   // 商品掛率グループコード
                    condition.GoodsRateRank     = goodsUnitData.GoodsRateRank;      // 商品掛率ランク

                    condition.PriceApplyDate = DateTime.Today;  // 適用日

                    // 売上消費税端数処理コード
                    condition.SalesCnsTaxFrcProcCd = CustomerDB.GetSalesFractionProcCdOfTax(customerCode, goodsUnitData);
                    // 売上単価端数処理コード
                    condition.SalesUnPrcFrcProcCd = CustomerDB.GetSalesFractionProcCdOfUnit(customerCode, goodsUnitData);

                    condition.SectionCode = goodsUnitData.SectionCode;  // 拠点コード

                    // 仕入消費税端数処理コード
                    condition.StockCnsTaxFrcProcCd = SupplierDB.GetStockFractionProcCdOfTax(goodsUnitData);
                    // 仕入単価端数処理コード
                    condition.StockUnPrcFrcProcCd = SupplierDB.GetStockFractionProcCdOfUnit(goodsUnitData);

                    condition.SupplierCd    = goodsUnitData.SupplierCd;     // 仕入先コード
                    condition.TaxationDivCd = goodsUnitData.TaxationDivCd;  // 課税区分

                    // HACK:condition.TaxRate = 0;              // 税率
                    // HACK:condition.TotalAmountDispWayCd = 0; // 総額表示方法区分
                    // HACK:condition.TtlAmntDspRateDivCd = 0;  // 総額表示掛率適用区分 0:(税込金額×掛率) 1:(税抜金額×掛率)から消費税を求め合算(消費税算出時消費税の端数処理が動作)
                    // HACK:condition.ConsTaxLayMethod = 0;     // 消費税転嫁方式
                    // -- ADD 2011/09/19   ------ >>>>>>
                    // DEL 2013/10/25 201311XX配信予定システムテスト障害№13,14対応 -------------------------------->>>>> 
                    //// 得意先情報
                    //CustomerInfo customerInfo = CustomerDB.CustomerInfoMap[customerCode];
                    //if (customerInfo != null)
                    //{
                    //    condition.ConsTaxLayMethod = customerInfo.ConsTaxLayMethod; // 072.消費税転嫁方式…得意先マスタ or 税率設定マスタ
                    //}
                    // DEL 2013/10/25 201311XX配信予定システムテスト障害№13,14対応 -------------------------------->>>>> 
                    TaxRateSetAgent taxRateSet = new TaxRateSetAgent(detailRecord.InqOtherEpCd);
                    {
                        // UPD 2014/01/30 Redmine#41771-障害№13対応 ------------------------------------------------------>>>>>
                        //condition.TaxRate = taxRateSet.TaxRateOfNow;    // 073.消費税税率…税率設定マスタ
                        taxRateSet.CancelDiv = cancelDiv;       // キャンセル区分
                        taxRateSet.TaxRateDate = inquiryDate;   // 税率判定日付
                        condition.TaxRate = (taxRateSet.CancelDiv == 1) ? taxRateSet.TaxRateOfSlesDate : taxRateSet.TaxRateOfNow; // 073.消費税税率…税率設定マスタ
                        // UPD 2014/01/30 Redmine#41771-障害№13対応 ------------------------------------------------------<<<<<
                    }

                    // DEL 2014/02/05 SCM仕掛一覧№10627対応 ----------------------------------->>>>>
                    #region 旧ソース
                    ////// ADD 2013/10/25 201311XX配信予定システムテスト障害№13,14対応 -------------------------------->>>>> 
                    ////CustomerInfo claim;
                    ////// 得意先情報取得
                    ////CustomerInfo customerInfo = CustomerDB.CustomerInfoMap[customerCode];
                    ////if (customerInfo != null)
                    ////{
                    ////    // 請求先情報取得
                    ////    int status = CustomerDB.RealAccesser.ReadDBData(Broadleaf.Library.Resources.ConstantManagement.LogicalMode.GetData0, customerInfo.EnterpriseCode, customerInfo.ClaimCode, true, false, out claim);
                    ////    if (status != (int)Broadleaf.Library.Resources.ConstantManagement.DB_Status.ctDB_NORMAL)
                    ////    {
                    ////        claim = new CustomerInfo();
                    ////    }

                    ////    if (claim != null)
                    ////    {
                    ////        condition.ConsTaxLayMethod = (claim.CustCTaXLayRefCd == 0) ? taxRateSet.ConsTaxLayMethod : claim.ConsTaxLayMethod;
                    ////    }
                    ////}
                    ////// ADD 2013/10/25 201311XX配信予定システムテスト障害№13,14対応 --------------------------------<<<<< 
                    #endregion
                    // DEL 2014/02/05 SCM仕掛一覧№10627対応 -----------------------------------<<<<<

                    // ADD 2014/02/05 SCM仕掛一覧№10627対応 ----------------------------------->>>>>
                    CustomerInfo claim = ClaimInfo(customerCode);
                    if (claim != null)
                    {
                        condition.ConsTaxLayMethod = claim.CustCTaXLayRefCd == 0 ? taxRateSet.ConsTaxLayMethod : claim.ConsTaxLayMethod;
                    }
                    else
                    {
                        // 請求先が取得できない場合は、マスタの税率設定をセット
                        condition.ConsTaxLayMethod = taxRateSet.ConsTaxLayMethod;
                    }
                    // ADD 2014/02/05 SCM仕掛一覧№10627対応 -----------------------------------<<<<<

                    condition.TotalAmountDispWayCd = 0; // 総額表示方法区分
                    condition.TtlAmntDspRateDivCd = 0;  // 総額表示掛率適用区分 0:(税込金額×掛率) 1:(税抜金額×掛率)から消費税を求め合算(消費税算出時消費税の端数処理が動作)
                    // -- ADD 2011/09/19   ------ <<<<<<
                    #region 実験コード

                    //condition.SectionCode = "25";
                    //condition.GoodsMakerCd = 2;
                    //condition.GoodsNo = "11044-42L00";
                    //condition.GoodsRateRank = "A";
                    //condition.GoodsRateGrpCode = 20;
                    //condition.BLGroupCode = 9;
                    //condition.BLGoodsCode = 1;
                    //condition.CustomerCode = 2000;
                    //condition.CustRateGrpCode = 0;
                    //condition.SupplierCd = 200;
                    //condition.PriceApplyDate = new DateTime(2009, 6, 10);
                    //condition.CountFl = 1;
                    //condition.TaxationDivCd = 0;
                    //condition.TaxRate = 0.05;
                    //condition.SalesCnsTaxFrcProcCd = 26;
                    //condition.StockCnsTaxFrcProcCd = 1801;
                    //condition.TotalAmountDispWayCd = 0;
                    //condition.TtlAmntDspRateDivCd = 0;
                    //condition.SalesUnPrcFrcProcCd = 26;
                    //condition.StockUnPrcFrcProcCd = 0;
                    //condition.ConsTaxLayMethod = 0;
                    //condition.BLGoodsName = "ヘッドガスケット（マージテスト２）";

                    //goodsUnitData.GoodsMakerCd = 2;
                    //goodsUnitData.MakerName = "ニッサン";
                    //goodsUnitData.MakerShortName = "";
                    //goodsUnitData.MakerKanaName = "ﾆｯｻﾝ";
                    //goodsUnitData.GoodsNo = "11044-42L00";
                    //goodsUnitData.GoodsName = "ヘッドＧ／Ｋ";
                    //goodsUnitData.GoodsNameKana = "ﾍｯﾄﾞG/K";
                    //goodsUnitData.Jan = "";
                    //goodsUnitData.BLGoodsCode = 1;
                    //goodsUnitData.BLGoodsFullName = "ヘッドガスケット（マージテスト２）";
                    //goodsUnitData.DisplayOrder = 0;
                    //goodsUnitData.GoodsLGroup = 1;
                    //goodsUnitData.GoodsLGroupName = "大分類１";
                    //goodsUnitData.GoodsMGroup = 9000;
                    //goodsUnitData.GoodsMGroupName = "テストデータ";
                    //goodsUnitData.BLGroupCode = 9;
                    //goodsUnitData.BLGroupName = "オイルパンドレンコック";
                    //goodsUnitData.GoodsRateRank = "A";
                    //goodsUnitData.TaxationDivCd = 0;
                    //goodsUnitData.GoodsNoNoneHyphen = "1104442L00";
                    //goodsUnitData.OfferDate = new DateTime(2008, 11, 7);
                    //goodsUnitData.GoodsKindCode = 0;
                    //goodsUnitData.GoodsNote1 = "";
                    //goodsUnitData.GoodsNote2 = "";
                    //goodsUnitData.GoodsSpecialNote = "";
                    //goodsUnitData.EnterpriseGanreCode = 0;
                    //goodsUnitData.EnterpriseGanreName = "";
                    //goodsUnitData.UpdateDate = DateTime.MinValue;
                    //goodsUnitData.UpdateDateJpFormal = "";
                    //goodsUnitData.UpdateDateJpInFormal = "";
                    //goodsUnitData.UpdateDateAdFormal = "";
                    //goodsUnitData.UpdateDateAdInFormal = "";
                    //goodsUnitData.GoodsRateGrpCode = 20;
                    //goodsUnitData.GoodsRateGrpName = "ブレーキパーツＢ";
                    //goodsUnitData.SalesCode = 0;
                    //goodsUnitData.SalesCodeName = "";
                    //goodsUnitData.SupplierCd = 200;
                    //goodsUnitData.SupplierNm1 = "日産";
                    //goodsUnitData.SupplierNm2 = "";
                    //goodsUnitData.SuppHonorificTitle = "様";
                    //goodsUnitData.SupplierKana = "ﾆｯｻﾝｶﾅ";
                    //goodsUnitData.SupplierSnm = "日産略";
                    //goodsUnitData.StockUnPrcFrcProcCd = 0;
                    //goodsUnitData.StockCnsTaxFrcProcCd = 0;
                    //goodsUnitData.SupplierLot = 0;
                    //goodsUnitData.SecretCode = 0;
                    //goodsUnitData.PrimePartsDisplayOrder = 0;
                    //goodsUnitData.PrmSetDtlNo1 = 0;
                    //goodsUnitData.PrmSetDtlName1 = "";
                    //goodsUnitData.PrmSetDtlNo2 = 0;
                    //goodsUnitData.PrmSetDtlName2 = "";
                    //goodsUnitData.SectionCode = "25";
                    //

                    #endregion // 実験コード
                }
                // --- ADD 2013/08/07 T.Miyamoto ------------------------------>>>>>
                RealAccesser.RatePriorityDiv = GetCompanyInf(detailRecord.EnterpriseCode).RatePriorityDiv; //自社設定･掛率優先順位
                // --- ADD 2013/08/07 T.Miyamoto ------------------------------<<<<<

                // UPD 2014/02/05 №10631 吉岡 掛率マスタキャッシュ ------->>>>>>>>>>>>>>>>>>>
                // RealAccesser.CalculateSalesRelevanceUnitPrice(condition, goodsUnitData, out unitPriceList);
                RealAccesser.CalculateSalesRelevanceUnitPriceRateCache(condition, goodsUnitData, out unitPriceList);
                // UPD 2014/02/05 №10631 吉岡 掛率マスタキャッシュ -------<<<<<<<<<<<<<<<<<<<

            }
            return unitPriceList ?? new List<UnitPriceCalcRet>();
        }

        /// <summary>
        /// 得意先掛率グループコード取得処理
        /// </summary>
        /// <remarks>
        /// MAHNB01012AB.cs l.9693 SalesSlipInputAcs.GetCustRateGroupCode() を参考<br/>
        /// <c>SCMPriceCalcurator.GetCustomerRateGroupCode()</c>
        /// と同じ処理となるので、統合するのが望ましい。
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
            int pureCode = (goodsMakerCode <= SCMPriceCalculator.PURE_GOODS_MAKER_CODE_MAX ? 0 : 1);    // 0:純正 1:優良

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
            // --- DELETE 2011/09/19 ---------->>>>>
            //return 0;
            // --- DELETE 2011/09/19 ----------<<<<<
            // --- ADD 2011/09/19 ---------->>>>>
            return -1;
            // --- ADD 2011/09/19 ----------<<<<<
        }

        // ADD 2012/11/08 2012/11/14配信 システムテスト障害対応：湯上 ------------------>>>>>
        #region <商品価格情報>

        /// <summary>
        /// 商品検索結果から価格情報を取得します
        /// </summary>
        /// <param name="targetDay">対象日</param>
        /// <param name="scmGoodsUnitData">商品連結データオブジェクト</param>
        /// <param name="goodsPrice">価格情報オブジェクト</param>
        /// <returns></returns>
        public static void GetPrice(DateTime targetDay, SCMGoodsUnitData scmGoodsUnitData, out GoodsPrice goodsPrice)
        {
            goodsPrice = null;
            if ((scmGoodsUnitData == null) || (scmGoodsUnitData.RealGoodsUnitData.GoodsPriceList == null)) return;

            List<GoodsPrice> goodsPriceList = scmGoodsUnitData.RealGoodsUnitData.GoodsPriceList;

            DateTime dateWk = DateTime.MinValue;
            foreach (GoodsPrice goodsPriceWk in goodsPriceList)
            {
                if ((goodsPriceWk.PriceStartDate <= targetDay) && (goodsPriceWk.PriceStartDate > dateWk))
                {
                    dateWk = goodsPriceWk.PriceStartDate;
                    goodsPrice = goodsPriceWk.Clone();
                }
            }
        }

        #endregion // </商品価格情報>
        // ADD 2012/11/08 2012/11/14配信 システムテスト障害対応：湯上 ------------------<<<<<


        // ADD 2015/01/07 メーカー希望小売価格対応 --------------------->>>>>
        #region メーカー希望小売価格
        // DEL 2015/03/18 SCM高速化 メーカー希望小売価格対応 ------------------------------------->>>>>
        #region 削除
        ///// <summary>
        ///// 商品検索結果からメーカー希望小売価格を取得します
        ///// </summary>
        ///// <param name="targetDay">対象日</param>
        ///// <param name="scmGoodsUnitData">商品連結データオブジェクト</param>
        ///// <param name="goodsPrice">価格情報オブジェクト</param>
        ///// <returns></returns>
        //public static void GetMkrSuggestRtPric(DateTime targetDay, SCMGoodsUnitData scmGoodsUnitData, out GoodsPrice goodsPrice)
        //{
        //    goodsPrice = null;
        //    if ((scmGoodsUnitData == null) || (scmGoodsUnitData.RealGoodsUnitData.MkrSuggestRtPricList == null)) return;

        //    List<GoodsPrice> goodsPriceList = scmGoodsUnitData.RealGoodsUnitData.MkrSuggestRtPricList;

        //    DateTime dateWk = DateTime.MinValue;
        //    foreach (GoodsPrice goodsPriceWk in goodsPriceList)
        //    {
        //        if ((goodsPriceWk.PriceStartDate <= targetDay) && (goodsPriceWk.PriceStartDate > dateWk))
        //        {
        //            dateWk = goodsPriceWk.PriceStartDate;
        //            goodsPrice = goodsPriceWk.Clone();
        //        }
        //    }
        //}
        #endregion
        // DEL 2015/03/18 SCM高速化 メーカー希望小売価格対応 -------------------------------------<<<<<

        // ADD 2015/03/10 SCM社内障害一覧№98対応 ---------------------------------->>>>>
        /// <summary>
        /// 価格情報リストからメーカー希望小売価格を取得します
        /// </summary>
        /// <param name="targetDay">対象日</param>
        /// <param name="mkrSuggestRtPricList">価格情報リスト</param>
        /// <param name="goodsPrice">価格情報オブジェクト</param>
        /// <returns></returns>
        public static void GetMkrSuggestRtPric(DateTime targetDay, List<GoodsPrice> mkrSuggestRtPricList, out GoodsPrice goodsPrice)
        {
            goodsPrice = null;
            if ((mkrSuggestRtPricList == null) || (mkrSuggestRtPricList.Count == 0)) return;

            DateTime dateWk = DateTime.MinValue;
            foreach (GoodsPrice goodsPriceWk in mkrSuggestRtPricList)
            {
                if ((goodsPriceWk.PriceStartDate <= targetDay) && (goodsPriceWk.PriceStartDate > dateWk))
                {
                    dateWk = goodsPriceWk.PriceStartDate;
                    goodsPrice = goodsPriceWk.Clone();
                }
            }
        }
        // ADD 2015/03/10 SCM社内障害一覧№98対応 ----------------------------------<<<<<
        #endregion
        // ADD 2015/01/07 メーカー希望小売価格対応 ---------------------<<<<<


        #region <定価>

        /// <summary>
        /// 定価の算出結果を取得します
        /// </summary>
        /// <param name="unitPriceCalcRetList">価格算出結果</param>
        /// <returns>定価の算出結果　※定価の算出結果が存在しない場合、<c>null</c>を返します。</returns>
        public static UnitPriceCalcRet GetListPriceResult(IList<UnitPriceCalcRet> unitPriceCalcRetList)
        {
            #region <Guard Phrase>

            if (unitPriceCalcRetList == null || unitPriceCalcRetList.Count.Equals(0)) return null;

            #endregion // </Guard Phrase>

            foreach (UnitPriceCalcRet unitPriceCalcRet in unitPriceCalcRetList)
            {
                if (unitPriceCalcRet.UnitPriceKind.Equals(UnitPriceCalculation.ctUnitPriceKind_ListPrice))
                {
                    return unitPriceCalcRet;
                }
            }
            return null;
        }

        #endregion // </定価>

        #region <売価>

        /// <summary>
        /// 売価の算出結果を取得します
        /// </summary>
        /// <param name="unitPriceCalcRetList">価格算出結果</param>
        /// <returns>売価の算出結果　※売価の算出結果が存在しない場合、<c>null</c>を返します。</returns>
        public static UnitPriceCalcRet GetSellingPriceResult(IList<UnitPriceCalcRet> unitPriceCalcRetList)
        {
            #region <Guard Phrase>

            if (unitPriceCalcRetList == null || unitPriceCalcRetList.Count.Equals(0)) return null;

            #endregion // </Guard Phrase>

            foreach (UnitPriceCalcRet unitPriceCalcRet in unitPriceCalcRetList)
            {
                if (unitPriceCalcRet.UnitPriceKind.Equals(UnitPriceCalculation.ctUnitPriceKind_SalesUnitPrice))
                {
                    return unitPriceCalcRet;
                }
            }
            return null;
        }

        #endregion // </売価>

        #region <原価>

        /// <summary>
        /// 原価の算出結果を取得します
        /// </summary>
        /// <param name="unitPriceCalcRetList">価格算出結果</param>
        /// <returns>原価の算出結果　※原価の算出結果が存在しない場合、<c>null</c>を返します。</returns>
        public static UnitPriceCalcRet GetCostPriceResult(IList<UnitPriceCalcRet> unitPriceCalcRetList)
        {
            #region <Guard Phrase>

            if (unitPriceCalcRetList == null || unitPriceCalcRetList.Count.Equals(0)) return null;

            #endregion // </Guard Phrase>

            foreach (UnitPriceCalcRet unitPriceCalcRet in unitPriceCalcRetList)
            {
                if (unitPriceCalcRet.UnitPriceKind.Equals(UnitPriceCalculation.ctUnitPriceKind_UnitCost))
                {
                    return unitPriceCalcRet;
                }
            }
            return null;
        }

        #endregion // </原価>

        #region <粗利>

        /// <summary>
        /// 粗利額を取得します。
        /// </summary>
        /// <param name="unitPriceCalcRetList">価格算出結果リスト</param>
        /// <param name="priseIsNone">売価未設定区分</param>
        /// <returns>売価 - 原価</returns>
        // UPD 2013/11/19 201312xx配信予定ｼｽﾃﾑﾃｽﾄ障害№22対応 ----------------------->>>>>
        //public static long GetRoughProfit(IList<UnitPriceCalcRet> unitPriceCalcRetList)
        public static long GetRoughProfit(IList<UnitPriceCalcRet> unitPriceCalcRetList, bool priseIsNone)
        // UPD 2013/11/19 201312xx配信予定ｼｽﾃﾑﾃｽﾄ障害№22対応 -----------------------<<<<<
        {
            // 売価
            double salesPrice = 0.0;
            UnitPriceCalcRet salesResult = GetSellingPriceResult(unitPriceCalcRetList);
            if (salesResult != null)
            {
                // -- DEL 2011/10/08   ------ >>>>>>
                //salesPrice = salesResult.UnitPriceTaxIncFl;
                // -- DEL 2011/10/08   ------ <<<<<<
                // -- ADD 2011/10/08   ------ >>>>>>
                salesPrice = salesResult.UnitPriceTaxExcFl;
                // -- ADD 2011/10/08   ------ <<<<<<
            }
            // ADD 2013/11/19 201312xx配信予定ｼｽﾃﾑﾃｽﾄ障害№22対応 ----------------------->>>>>
            else
            {
                // 売価未設定区分が「1:定価表示」の場合、定価を使用
                if (priseIsNone)
                {
                    salesResult = GetListPriceResult(unitPriceCalcRetList);
                    if (salesResult != null)
                    {
                        salesPrice = salesResult.UnitPriceTaxExcFl;
                    }
                }
            }
            // ADD 2013/11/19 201312xx配信予定ｼｽﾃﾑﾃｽﾄ障害№22対応 -----------------------<<<<<

            // 原価
            double costPrice = 0.0;
            UnitPriceCalcRet costResult = GetCostPriceResult(unitPriceCalcRetList);
            if (costResult != null)
            {
                // -- DEL 2011/10/08   ------ >>>>>>
                //costPrice = costResult.UnitPriceTaxIncFl;
                // -- DEL 2011/10/08   ------ <<<<<<
                // -- ADD 2011/10/08   ------ >>>>>>
                costPrice = costResult.UnitPriceTaxExcFl;
                // -- ADD 2011/10/08   ------ <<<<<<
            }

            return (long)(salesPrice - costPrice);
        }

        /// <summary>
        /// 粗利率を取得します。
        /// </summary>
        /// <param name="unitPriceCalcRetList">価格算出結果リスト</param>
        /// <param name="priseIsNone">売価未設定区分</param>
        /// <returns>(売価 - 原価) / 売価 * 100.0</returns>
        // UPD 2013/11/19 201312xx配信予定ｼｽﾃﾑﾃｽﾄ障害№22対応 ----------------------->>>>>
        //public static double GetRoughRate(IList<UnitPriceCalcRet> unitPriceCalcRetList)
        public static double GetRoughRate(IList<UnitPriceCalcRet> unitPriceCalcRetList, bool priseIsNone)
        // UPD 2013/11/19 201312xx配信予定ｼｽﾃﾑﾃｽﾄ障害№22対応 -----------------------<<<<<
        {
            // 売価
            double salesPrice = 0.0;
            UnitPriceCalcRet salesResult = GetSellingPriceResult(unitPriceCalcRetList);
            if (salesResult != null)
            {
                // -- DEL 2011/10/08   ------ >>>>>>
                //salesPrice = salesResult.UnitPriceTaxIncFl;
                // -- DEL 2011/10/08   ------ <<<<<<
                // -- ADD 2011/10/08   ------ >>>>>>
                salesPrice = salesResult.UnitPriceTaxExcFl;
                // -- ADD 2011/10/08   ------ <<<<<<
            }
            // ADD 2013/11/19 201312xx配信予定ｼｽﾃﾑﾃｽﾄ障害№22対応 ----------------------->>>>>
            else
            {
                // 売価未設定区分が「1:定価表示」の場合、定価を使用
                if (priseIsNone)
                {
                    salesResult = GetListPriceResult(unitPriceCalcRetList);
                    if (salesResult != null)
                    {
                        salesPrice = salesResult.UnitPriceTaxExcFl;
                    }
                }
            }
            // ADD 2013/11/19 201312xx配信予定ｼｽﾃﾑﾃｽﾄ障害№22対応 -----------------------<<<<<

            // 原価
            double costPrice = 0.0;
            UnitPriceCalcRet costResult = GetCostPriceResult(unitPriceCalcRetList);
            if (costResult != null)
            {
                // -- DEL 2011/10/08   ------ >>>>>>
                //costPrice = costResult.UnitPriceTaxIncFl;
                // -- DEL 2011/10/08   ------ <<<<<<
                // -- ADD 2011/10/08   ------ >>>>>>
                costPrice = costResult.UnitPriceTaxExcFl;
                // -- ADD 2011/10/08   ------ <<<<<<
            }

            if (salesPrice > 0.0)
            {
                return (salesPrice - costPrice) / salesPrice * 100.0;
            }
            else
            {
                return 0.0;
            }
        }

        #endregion // <粗利>

        /// <summary> 
        /// 指定値を指定された精度の数値に四捨五入します。 
        /// </summary> 
        /// <param name="roundValue">指定値</param> 
        /// <param name="digits">精度（<c>0</c> の場合は整数になります）</param> 
        /// <returns>指定された精度に四捨五入された数値</returns> 
        public static double RoundOff(
            double roundValue,
            int digits
        )
        {
            double shift = Math.Pow(10, (double)digits);
            return Math.Floor(roundValue * shift + 0.5) / shift;
        }
    }
}
