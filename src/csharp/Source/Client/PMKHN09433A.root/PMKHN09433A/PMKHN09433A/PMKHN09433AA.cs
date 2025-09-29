//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 売価一括修正
// プログラム概要   : 売価一括修正を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張凱
// 作 成 日  2009/04/14  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 李占川
// 修 正 日  2009/07/10  修正内容 : PVCS#322 抽出条件の変更  
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張凱
// 修 正 日  2009/08/28  修正内容 : PVCS#324 抽出条件の変更  
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤
// 修 正 日  2009/11/30  修正内容 : 得意先掛率グループ改良  
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30514 夏野 駿希
// 修 正 日  2010/06/21  修正内容 : Mantis.15304フィードバック　エラー対応
//                                  抽出条件のBLコードが空白の場合、全BLコードを抽出対象とするように修正。  
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;
using System.Collections;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 売価一括修正アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 売価一括修正のアクセス制御を行います。</br>
    /// <br>Programmer : 張凱</br>
    /// <br>Date       : 2009/04/01</br>
    /// </remarks>
    public class SaleRateUpdateAcs
    {
        #region ■private定数
        private const string CT_UnitRateSetDivCd = "14A"; // 単価掛率設定区分
        private const string CT_UnitPriceKind = "1"; // 単価種類
        private const string CT_RateSettingDivide = "4A"; // 掛率設定区分

        private const string CT_UserUnitRateSetDivCd = "36A"; // 単価掛率設定区分
        private const string CT_UserUnitPriceKind = "3"; // 単価種類
        private const string CT_UserRateSettingDivide = "6A"; // 掛率設定区分

        #endregion ■private定数

        #region ■private変数
        // 企業コード
        private string _enterpriseCode;
        // ログイン拠点コード
        private string _loginSectionCode;

        // 商品マスタアクセス
        private GoodsAcs _goodsAcs;

        // 掛率マスタアクセス
        private RateAcs _rateAcs;

        private TaxRateSetAcs _taxRateSetAcs;           // 税率設定マスタアクセスクラス

        private TaxRateSet _taxRateSet;

        private ArrayList goodsPriceUList = new ArrayList();

        private UnitPriceCalculation _unitPriceCalculation;

        #endregion ■private変数

        #region Private Members

        // リモートオブジェクト格納バッファ
        private ISaleRateDB _iSaleRateDB = null;    // 課設定リモート

        /// <summary>商品マスタ</summary>
        public ArrayList GoodsPriceUList
        {
            get { return this.goodsPriceUList; }
            set { this.goodsPriceUList = value; }
        }

        #endregion Private Members

        #region ■ Construcstor
        /// <summary>
        /// 売価一括修正アクセスクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 売価一括修正アクセスクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009/04/01</br>
        /// </remarks>
        public SaleRateUpdateAcs()
        {
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode.TrimEnd();
            this._loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode.TrimEnd();
            this._rateAcs = new RateAcs();
            this._goodsAcs = new GoodsAcs();
            this._taxRateSetAcs = new TaxRateSetAcs();
            this._unitPriceCalculation = new UnitPriceCalculation();
            string msg;
            this._goodsAcs.SearchInitial(this._enterpriseCode, this._loginSectionCode, out msg);

            ReadTaxRate();

            try
            {
                // リモートオブジェクト取得
                this._iSaleRateDB = (ISaleRateDB)MediationSaleRateDB.GetSaleRateDB();
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._iSaleRateDB = null;
            }
        }

        #endregion ■ Construcstor

        #region ■ Public Methods
        /// <summary>
        /// 商品マスタ検索処理
        /// </summary>
        /// <param name="goodsUnitDataList">商品マスタ検索結果リスト</param>
        /// <param name="salesRateSearchParam">商品マスタ検索条件</param>
        /// <param name="errMsg">商品マスタ検索条件</param>
        /// <remarks>
        /// <br>Note       : 商品マスタを検索します。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009/04/01</br>
        /// </remarks>
        public int Search(out List<GoodsUnitData> goodsUnitDataList, SalesRateSearchParam salesRateSearchParam, out string errMsg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            errMsg = string.Empty;
            goodsUnitDataList = new List<GoodsUnitData>();

            List<GoodsUnitData> retList = new List<GoodsUnitData>(); // ADD 2009/07/10
            // 抽出条件の作成
            GoodsCndtn goodsCndtn = new GoodsCndtn();
            goodsCndtn.SectionCode = salesRateSearchParam.SectionCode;
            goodsCndtn.EnterpriseCode = salesRateSearchParam.EnterpriseCode;
            goodsCndtn.GoodsMakerCd = salesRateSearchParam.GoodsMakerCd;
            goodsCndtn.BLGoodsCode = salesRateSearchParam.BLGoodsCode;
            // 商品属性 (0,1両方)
            goodsCndtn.GoodsKindCode = 9;

            try
            {
                status = this._goodsAcs.Search(goodsCndtn, ConstantManagement.LogicalMode.GetData0, out retList, out errMsg);

                // --- ADD 2009/07/10 ------------------------------->>>>>
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    foreach (GoodsUnitData goodsUnitData in retList)
                    {
                        // 2010/06/21 Add 抽出条件のBLコードが0なら全BLコード対象 >>>
                        if (salesRateSearchParam.BLGoodsCode == 0)
                        {
                            goodsUnitDataList.Add(goodsUnitData);
                        }
                        else
                        {
                            // 2010/06/21 Add <<<
                            if (goodsUnitData.BLGoodsCode == salesRateSearchParam.BLGoodsCode)
                            {
                                goodsUnitDataList.Add(goodsUnitData);
                            }
                        }   // 2010/06/21 Add
                    }
                }
                // --- ADD 2009/07/10 ------------------------------<<<<<
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                goodsUnitDataList = new List<GoodsUnitData>();
            }

            return (status);
        }

        /// <summary>
        /// 掛率マスタ検索処理
        /// </summary>
        /// <param name="rateSearchResultLis">掛率マスタ検索結果リスト</param>
        /// <param name="userRateSearchResultLis">掛率マスタ検索条件</param>
        /// <param name="goodsUnitDataList">掛率マスタ検索条件</param>
        /// <param name="salesRateSearchParam">掛率マスタ検索条件</param>
        /// <param name="errMsg">掛率マスタ検索条件</param>
        /// <remarks>
        /// <br>Note       : 掛率マスタを検索します。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009/04/01</br>
        /// </remarks>
        public int Search(out List<Rate> rateSearchResultLis, out List<Rate> userRateSearchResultLis, List<GoodsUnitData> goodsUnitDataList, SalesRateSearchParam salesRateSearchParam, out string errMsg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            errMsg = string.Empty;
            rateSearchResultLis = new List<Rate>();
            userRateSearchResultLis = new List<Rate>();

            // 抽出条件の作成
            // 掛率マスタも取得する
            ArrayList retList;
            List<Rate> userRetList;

            // 引数設定
            Rate rate = new Rate();
            rate.EnterpriseCode = this._enterpriseCode;
            // 単価種類
            rate.UnitPriceKind = CT_UnitPriceKind;

            // 単価掛率設定区分
            // DEL 2009/11/30 3次分対応 得意先掛率グループ改良 ---------->>>>>
            // TODO:rate.UnitRateSetDivCd = CT_UnitRateSetDivCd;
            // TODO:rate.RateSettingDivide = CT_RateSettingDivide;
            // DEL 2009/11/30 3次分対応 得意先掛率グループ改良 ----------<<<<<
            // ADD 2009/11/30 3次分対応 得意先掛率グループ改良 ---------->>>>>
            rate.UnitRateSetDivCd = ExistsAllCustRateGrpCode(salesRateSearchParam) ? string.Empty : CT_UnitRateSetDivCd;
            rate.RateSettingDivide = ExistsAllCustRateGrpCode(salesRateSearchParam) ? string.Empty : CT_RateSettingDivide;
            // ADD 2009/11/30 3次分対応 得意先掛率グループ改良 ----------<<<<<

            rate.LogicalDeleteCode = 0;
            rate.CustRateGrpCode = -1;// ADD 2009/08/28

            status = this._rateAcs.SearchAll(out retList, ref rate, out errMsg);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL
                && retList != null
                && retList.Count != 0)
            {
                // DEL 2009/11/30 3次分対応 得意先掛率グループ改良 ---------->>>>>
                // TODO:rateSearchResultLis = new List<Rate>((Rate[])retList.ToArray(typeof(Rate)));
                // DEL 2009/11/30 3次分対応 得意先掛率グループ改良 ----------<<<<<
                // ADD 2009/11/30 3次分対応 得意先掛率グループ改良 ---------->>>>>
                if (!ExistsAllCustRateGrpCode(salesRateSearchParam))
                {
                    rateSearchResultLis = new List<Rate>((Rate[])retList.ToArray(typeof(Rate)));
                }
                else
                {
                    foreach (Rate searchedRate in retList)
                    {
                        if (
                            searchedRate.UnitRateSetDivCd.Trim().Equals(CT_UnitRateSetDivCd)
                                ||
                            searchedRate.UnitRateSetDivCd.Trim().Equals(ALL_UNIT_RATE_SET_DIV_CD)
                        )
                        {
                            if (searchedRate.UnitRateSetDivCd.Trim().Equals(ALL_UNIT_RATE_SET_DIV_CD))
                            {
                                Debug.WriteLine(searchedRate.GoodsNo + " " + searchedRate.CustRateGrpCode.ToString());
                                searchedRate.CustRateGrpCode = ALL_CUST_RATE_GRP_CODE;
                            }
                            rateSearchResultLis.Add(searchedRate);
                        }
                    }
                }
                // ADD 2009/11/30 3次分対応 得意先掛率グループ改良 ----------<<<<<
            }

            List<Rate> userrateList = new List<Rate>();
            Rate userrate = new Rate();
            userrate.EnterpriseCode = this._enterpriseCode;
            // 単価種類
            userrate.UnitPriceKind = CT_UserUnitPriceKind;
            // 単価掛率設定区分
            userrate.UnitRateSetDivCd = CT_UserUnitRateSetDivCd;
            userrate.RateSettingDivide = CT_UserRateSettingDivide;
            userrate.LogicalDeleteCode = 0;
            userrate.CustRateGrpCode = -1;// ADD 2009/08/28
            userrateList.Add(userrate);

            status = this._rateAcs.Search(out userRetList, userrateList, out errMsg);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL
                && userRetList != null
                && userRetList.Count != 0)
            {
                userRateSearchResultLis = userRetList;
            }

            return (status);
        }

        // ADD 2009/11/30 3次分対応 得意先掛率グループ改良 ---------->>>>>
        /// <summary>得意先掛率グループコード指定なし</summary>
        public const int ALL_CUST_RATE_GRP_CODE = -1;

        /// <summary>得意先掛率グループコード指定なし</summary>
        private const string ALL_UNIT_RATE_SET_DIV_CD = "16A";

        /// <summary>
        /// 得意先掛率グループコード指定なしが存在するか判定します。
        /// </summary>
        /// <param name="salesRateSearchParam">売価設定検索条件</param>
        /// <returns>
        /// <c>true</c> :存在します。<br/>
        /// <c>false</c>:存在しません。
        /// </returns>
        private static bool ExistsAllCustRateGrpCode(SalesRateSearchParam salesRateSearchParam)
        {
            return Array.Exists<int>(salesRateSearchParam.CustRateGrpCode, delegate(int custRateGrpCode)
            {
                return custRateGrpCode < 0;
            });
        }
        // ADD 2009/11/30 3次分対応 得意先掛率グループ改良 ----------<<<<<

        #region Save 保存処理
        /// <summary>
        /// 保存処理
        /// </summary>
        /// <param name="delRateList">削除データリスト</param>
        /// <param name="updRateList">更新データリスト</param>
        /// <param name="message">メッセージ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 保存処理を行います。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009/04/01</br>
        /// </remarks>
        public int Save(ref ArrayList delRateList, ref ArrayList updRateList, out string message)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            message = "";

            try
            {
                RateWork delRateWork = null;
                RateWork updRateWork = null;
                ArrayList delRateWorkList = new ArrayList();	// ワーククラス格納用ArrayList
                ArrayList updRateWorkList = new ArrayList();	// ワーククラス格納用ArrayList

                // ワーククラス格納用ArrayListへ詰め替え
                for (int i = 0; i < delRateList.Count; i++)
                {
                    // クラスデータをワーククラスデータに変換
                    delRateWork = CopyToRateWorkFromRate((Rate)delRateList[i]);
                    delRateWorkList.Add(delRateWork);
                }

                for (int i = 0; i < updRateList.Count; i++)
                {
                    // クラスデータをワーククラスデータに変換
                    updRateWork = CopyToRateWorkFromRate((Rate)updRateList[i]);
                    updRateWorkList.Add(updRateWork);
                }

                object delparaObj = (object)delRateWorkList;
                object updparaObj = (object)updRateWorkList;

                // 保存処理
                status = this._iSaleRateDB.Save(delparaObj, updparaObj, ref message);

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // 何かしらのエラー発生
                    message = "保存に失敗しました。";
                    return status;
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                // オフライン時はnullをセット
                this._iSaleRateDB = null;
                // 通信エラー
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;
        }
        #endregion Save 保存処理


        #endregion ■ Public Methods

        #region クラスメンバコピー処理
        /// <summary>
        /// クラスメンバーコピー処理（掛率設定クラス⇒掛率設定ワーククラス）
        /// </summary>
        /// <param name="rate">掛率設定クラス</param>
        /// <returns>RateWork</returns>
        /// <remarks>
        /// <br>Note       : 掛率設定クラスから掛率設定ワーククラスへメンバーのコピーを行います。</br>
        /// <br>Programmer : 張凱</br>
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
        #endregion クラスメンバコピー処理

        /// <summary>
        /// 税率設定マスタ取得処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : なし。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009/04/01</br>
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
        /// 価格マスタ
        /// </summary>
        /// <returns>ステータス</returns>
        public void SearchGoodsPriceU(List<GoodsUnitData> goodsUnitDataList, string searchSectionCode)
        {
            List<UnitPriceCalcParam> unitPriceCalcParamList = new List<UnitPriceCalcParam>();

            foreach (GoodsUnitData goodsUnitData in goodsUnitDataList)
            {
                // 単価算出パラメータ設定
                UnitPriceCalcParam unitPriceCalcParam = new UnitPriceCalcParam();
                unitPriceCalcParam.SectionCode = searchSectionCode;    // 拠点コード
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
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009/04/01</br>
        /// </remarks>
        public double GetStockUnitPrice(GoodsUnitData goodsUnitData)
        {
            double stockUnitPrice = 0;

            foreach (UnitPriceCalcRet unitPriceCalcRet in this.goodsPriceUList)
            {
                if (unitPriceCalcRet.GoodsMakerCd == goodsUnitData.GoodsMakerCd
                    && unitPriceCalcRet.GoodsNo.Equals(goodsUnitData.GoodsNo))
                {
                    stockUnitPrice = unitPriceCalcRet.UnitPriceTaxExcFl;
                }
            }

            return stockUnitPrice;
        }

    }
}
