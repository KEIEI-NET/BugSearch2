using System;
using System.Text;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Collections;
using System.Runtime.Serialization.Formatters.Binary; // 2010/04/27
using System.IO; // 2010/04/27

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 売上データオブジェクトコンバートクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 売上関連クラスの項目コンバート制御を行います。</br>
    /// <br>Programmer : 20056 對馬　大輔</br>
    /// <br>Date       : 2007.09.10</br>
    /// <br></br>
    /// <br>UpDate</br>
    /// <br>2007.09.10 對馬　大輔  新規作成</br>
    /// <br>Update Note  : 2009/09/08 張凱</br>
    /// <br>               PM.NS-2-A・車輌管理</br>
    /// <br>               車輌備考の追加</br>
    /// <br>Update Note : 2009/10/19 張凱</br>
    /// <br>              PM.NS-3-A・PM.NS保守依頼②</br>
    /// <br>              標準価格選択有無区分を追加</br>
    /// <br>Update Note : 2010/02/26 對馬 大輔 </br>
    /// <br>              SCM対応</br>
    /// <br>Update Note : 2010/04/27 gaoyh</br>
    /// <br>              受注マスタ（車両）自由検索型式固定番号配列の追加対応</br>
    /// <br>UpdateNote :  2011/07/18 朱宝軍 回答区分の追加</br>
    /// <br>UpdateNote  : 2011/08/23 朱宝軍 Redmine#23645 PCCUOE_テーブルレイアウト変更対応</br>
    /// <br>Update Note : 2011/12/15 tianjw</br>
    /// <br>              Redmine#27390 拠点管理/売上日のチェック</br>
    /// <br>Update Note : 2012/01/16 30517 夏野 駿希</br>
    /// <br>              SCM改良・特記事項対応</br>
    /// <br>Update Note : 2012/01/19 tianjw</br>
    /// <br>              Redmine#28098 拠点管理／送信済みエラー</br>
    /// <br>Update Note: 2012/05/02 20056 對馬 大輔</br>
    /// <br>管理番号   : 10801804-00 障害対応</br>
    /// <br>             改良：貸出仕入同時入力対応</br>
    /// <br>Update Note: 2013/01/18 田建委</br>
    /// <br>管理番号   : 10806793-00 2013/03/13配信分</br>
    /// <br>           : Redmine#33797 自動入金備考区分の追加</br>
    /// <br>Update Note: 2013/01/24 鄧潘ハン</br>
    /// <br>管理番号   : 10900690-00 2013/03/13配信分</br>
    /// <br>           : Redmine#34605 売上画面の価格ｶﾞｲﾄﾞ表示に『拠点』や『表示区分』の追加</br>
    /// <br>Update Note: 2013/03/21 FSI今野 利裕</br>
    /// <br>管理番号   : 10900269-00</br>
    /// <br>             SPK車台番号文字列対応</br>   
    /// <br>Update Note: 2015/08/22 黄興貴</br>
    /// <br>管理番号   : 11170129-00 №836 Redmine#47045 保存時の重複エラー処理の障害対応</br>
    /// </remarks>
    public class ConvertSalesSlip
    {
        #region ■Public Static Methods
        /// <summary>
        /// PramData→UIData移項処理
        /// </summary>
        /// <param name="salHisRefResultParamWorkList">売上履歴照会ワークオブジェクトリスト</param>
        /// <returns>売上明細データオブジェクトリスト</returns>
        public static List<SalesDetail> UIDataFromParamData(List<SalHisRefResultParamWork> salHisRefResultParamWorkList)
        {
            return UIDataFromParamDataProc(salHisRefResultParamWorkList);
        }

        /// <summary>
        /// PramData→UIData移項処理
        /// </summary>
        /// <param name="salHisRefResultParamWork">売上履歴照会ワークオブジェクト</param>
        /// <returns>売上明細データオブジェクト</returns>
        public static SalesDetail UIDataFromParamData(SalHisRefResultParamWork salHisRefResultParamWork)
        {
            return UIDataFromParamDataProc(salHisRefResultParamWork);
        }

        /// <summary>
        /// PramData→UIData移項処理
        /// </summary>
        /// <param name="preChargedDataSelectResultWorkList">出荷／見積照会ワークオブジェクトリスト(明細選択)</param>
        /// <returns>売上明細データオブジェクトリスト</returns>
        public static List<SalesDetail> UIDataFromParamData(List<PreChargedDataSelectResultWork> preChargedDataSelectResultWorkList)
        {
            return UIDataFromParamDataProc(preChargedDataSelectResultWorkList);
        }

        /// <summary>
        /// PramData→UIData移項処理
        /// </summary>
        /// <param name="preChargedDataSelectResultWork">出荷／見積照会ワークオブジェクト(明細選択)</param>
        /// <returns>売上明細データオブジェクト</returns>
        public static SalesDetail UIDataFromParamData(PreChargedDataSelectResultWork preChargedDataSelectResultWork)
        {
            return UIDataFromParamDataProc(preChargedDataSelectResultWork);
        }

        /// <summary>
        /// PramData→UIData移項処理
        /// </summary>
        /// <param name="acptAnOdrRemainRefDataList">受注照会ワークオブジェクトリスト(明細選択)</param>
        /// <returns>売上明細データオブジェクトリスト</returns>
        public static List<SalesDetail> UIDataFromParamData(List<AcptAnOdrRemainRefData> acptAnOdrRemainRefDataList)
        {
            return UIDataFromParamDataProc(acptAnOdrRemainRefDataList);
        }

        /// <summary>
        /// PramData→UIData移項処理
        /// </summary>
        /// <param name="salHisRefResultParamWork">受注照会ワークオブジェクト(明細選択)</param>
        /// <returns>売上明細データオブジェクト</returns>
        public static SalesDetail UIDataFromParamData(AcptAnOdrRemainRefData acptAnOdrRemainRefData)
        {
            return UIDataFromParamDataProc(acptAnOdrRemainRefData);
        }

        /// <summary>
        /// PramData→UIData移項処理
        /// </summary>
        /// <param name="addUppSrcStockDetailWorkList">計上元仕入明細データワークオブジェクト配列</param>
        /// <returns>売上明細データオブジェクトリスト</returns>
        public static List<SalesDetail> UIDataFromParamData(AddUpOrgSalesDetailWork[] addUpSrcSalesDetailWorkList)
        {
            return UIDataFromParamDataProc(addUpSrcSalesDetailWorkList);
        }

        /// <summary>
        /// PramData→UIData移項処理
        /// </summary>
        /// <param name="salesSlipWork">売上データワークオブジェクト</param>
        /// <returns>売上データオブジェクト</returns>
        public static SalesSlip UIDataFromParamData(SalesSlipWork salesSlipWork)
        {
            return UIDataFromParamDataProc(salesSlipWork);
        }

        /// <summary>
        /// PramData→UIData移項処理
        /// </summary>
        /// <param name="salesDetailWorkArray">売上明細データワークオブジェクト配列</param>
        /// <returns>売上明細データオブジェクトリスト</returns>
        public static List<SalesDetail> UIDataFromParamData(SalesDetailWork[] salesDetailWorkArray)
        {
            return UIDataFromParamDataProc(salesDetailWorkArray);
        }

        //>>>2010/02/26
        /// <summary>
        /// PramData→UIData移項処理
        /// </summary>
        /// <param name="salesDetailWorkList">売上明細データワークオブジェクトリスト</param>
        /// <returns>売上明細データオブジェクトリスト</returns>
        public static List<SalesDetail> UIDataFromParamData(List<SalesDetailWork> salesDetailWorkList)
        {
            return UIDataFromParamDataProc(salesDetailWorkList);
        }
        //<<<2010/02/26

        /// <summary>
        /// PramData→UIData移項処理
        /// </summary>
        /// <param name="salesDetailWork">売上明細データワークオブジェクト</param>
        /// <returns>売上明細データオブジェクト</returns>
        public static SalesDetail UIDataFromParamData(SalesDetailWork salesDetailWork)
        {
            return UIDataFromParamDataProc( salesDetailWork);
        }

        /// <summary>
        /// UIData→PramData移項処理
        /// </summary>
        /// <param name="salesSlip">売上データオブジェクト</param>
        /// <returns>売上データワークオブジェクト</returns>
        public static SalesSlipWork ParamDataFromUIData(SalesSlip salesSlip)
        {
            return ParamDataFromUIDataProc(salesSlip);
        }

        /// <summary>
        /// UIData→PramData移項処理
        /// </summary>
        /// <param name="salesDetail">売上明細データオブジェクト</param>
        /// <returns>売上明細データワークオブジェクト</returns>
        public static SalesDetailWork ParamDataFromUIData(SalesDetail salesDetail)
        {
            return ParamDataFromUIDataProc(salesDetail);
        }

        /// <summary>
        /// PramData→UIData移項処理
        /// </summary>
        /// <param name="stockSlipWork">仕入データワークオブジェクト</param>
        /// <param name="stockDetailWork">仕入明細データワークオブジェクト</param>
        /// <returns>仕入情報オブジェクト</returns>
        public static StockTemp UIDataFromParamData(StockSlipWork stockSlipWork, StockDetailWork stockDetailWork)
        {
            return UIDataFromParamDataProc(stockSlipWork, stockDetailWork);
        }

        /// <summary>
        /// PramData→UIData移行処理
        /// </summary>
        /// <param name="acceptOdrCarWorkList">受注マスタ（車両）ワークオブジェクト配列</param>
        /// <returns>受注マスタ（車両）オブジェクトリスト</returns>
        public static List<AcceptOdrCar> UIDataFromParamData(AcceptOdrCarWork[] acceptOdrCarWorkList)
        {
            return UIDataFromParamDataProc(acceptOdrCarWorkList);
        }

        /// <summary>
        /// PramData→UIData移項処理
        /// </summary>
        /// <param name="acceptOdrCarWork">受注マスタ（車両）ワークオブジェクト</param>
        /// <returns>受注マスタ（車両）オブジェクト</returns>
        public static AcceptOdrCar UIDataFromParamData(AcceptOdrCarWork acceptOdrCarWork)
        {
            return UIDataFromParamDataProc(acceptOdrCarWork);
        }

        /// <summary>
        /// PramData→UIData移項処理
        /// </summary>
        /// <param name="depsitDataWork">入金ワークオブジェクト</param>
        /// <returns>入金データオブジェクト</returns>
        public static SearchDepsitMain UIDataFromParamData(DepsitDataWork depsitDataWork)
        {
            return UIDataFromParamDataProc( depsitDataWork);
        }

        /// <summary>
        /// PramData→UIData移項処理
        /// </summary>
        /// <param name="searchDepsitMain">入金データオブジェクト</param>
        /// <returns>入金ワークオブジェクト</returns>
        public static DepsitDataWork ParamDataFromUIData(SearchDepsitMain searchDepsitMain)
        {
            return ParamDataFromUIDataProc(searchDepsitMain);
        }

        /// <summary>
        /// 項目コピー処理
        /// </summary>
        /// <param name="source">コピー元売上データオブジェクト</param>
        /// <param name="target">コピー先売上データオブジェクト</param>
        public static void CopyItem(SalesSlip source, ref SalesSlip target)
        {
            CopyItemProc(source, ref target);
        }

        /// <summary>
        /// 項目コピー処理
        /// </summary>
        /// <param name="source">コピー元売上明細データオブジェクト</param>
        /// <param name="target">コピー先売上明細データオブジェクト</param>
        public static void CopyItem(SalesDetail source, ref SalesDetail target)
        {
            CopyItemProc(source, ref target);
        }
        #endregion

        #region ■Private Static Methods
        /// <summary>
        /// PramData→UIData移項処理
        /// </summary>
        /// <param name="salHisRefResultParamWorkList">売上履歴照会ワークオブジェクトリスト</param>
        /// <returns>売上明細データオブジェクトリスト</returns>
        private static List<SalesDetail> UIDataFromParamDataProc(List<SalHisRefResultParamWork> salHisRefResultParamWorkList)
        {
            if (salHisRefResultParamWorkList == null) return null;

            List<SalesDetail> salesDetailList = new List<SalesDetail>();

            foreach (SalHisRefResultParamWork salHisRefResultParamWork in salHisRefResultParamWorkList)
            {
                salesDetailList.Add(UIDataFromParamData(salHisRefResultParamWork));
            }

            return salesDetailList;
        }

        /// <summary>
        /// PramData→UIData移項処理
        /// </summary>
        /// <param name="salHisRefResultParamWork">売上履歴照会ワークオブジェクト</param>
        /// <returns>売上明細データオブジェクト</returns>
        private static SalesDetail UIDataFromParamDataProc(SalHisRefResultParamWork salHisRefResultParamWork)
        {
            SalesDetail salesDetail = new SalesDetail();
            //salesDetail.EnterpriseCode = salHisRefResultParamWork.EnterpriseCode;
            //salesDetail.LogicalDeleteCode = salHisRefResultParamWork.LogicalDeleteCode;
            //salesDetail.AcceptAnOrderNo = salHisRefResultParamWork.AcceptAnOrderNo;
            //salesDetail.AcptAnOdrStatus = salHisRefResultParamWork.AcptAnOdrStatus;
            //salesDetail.SalesSlipNum = salHisRefResultParamWork.SalesSlipNum;
            //salesDetail.SalesRowNo = salHisRefResultParamWork.SalesRowNo;
            //salesDetail.SectionCode = salHisRefResultParamWork.SectionCode;
            //salesDetail.SubSectionCode = salHisRefResultParamWork.SubSectionCode;
            //salesDetail.MinSectionCode = salHisRefResultParamWork.MinSectionCode;
            //salesDetail.SalesDate = salHisRefResultParamWork.SalesDate;
            //salesDetail.CommonSeqNo = salHisRefResultParamWork.CommonSeqNo;
            //salesDetail.SalesSlipDtlNum = salHisRefResultParamWork.SalesSlipDtlNum;
            //salesDetail.AcptAnOdrStatusSrc = salHisRefResultParamWork.AcptAnOdrStatusSrc;
            //salesDetail.SalesSlipDtlNumSrc = salHisRefResultParamWork.SalesSlipDtlNumSrc;
            //salesDetail.SupplierFormalSync = salHisRefResultParamWork.SupplierFormalSync;
            //salesDetail.StockSlipDtlNumSync = salHisRefResultParamWork.StockSlipDtlNumSync;
            //salesDetail.SalesSlipCdDtl = salHisRefResultParamWork.SalesSlipCdDtl;
            //salesDetail.ServiceSlipCd = salHisRefResultParamWork.ServiceSlipCd;
            //salesDetail.SalesDepositsDiv = salHisRefResultParamWork.SalesDepositsDiv;
            //salesDetail.StockMngExistCd = salHisRefResultParamWork.StockMngExistCd;
            //salesDetail.GoodsKindCode = salHisRefResultParamWork.GoodsKindCode;
            //salesDetail.GoodsMakerCd = salHisRefResultParamWork.GoodsMakerCd;
            //salesDetail.MakerName = salHisRefResultParamWork.MakerName;
            //salesDetail.GoodsNo = salHisRefResultParamWork.GoodsNo;
            //salesDetail.GoodsName = salHisRefResultParamWork.GoodsName;
            //salesDetail.GoodsSetDivCd = salHisRefResultParamWork.GoodsSetDivCd;
            //salesDetail.LargeGoodsGanreCode = salHisRefResultParamWork.LargeGoodsGanreCode;
            //salesDetail.LargeGoodsGanreName = salHisRefResultParamWork.LargeGoodsGanreName;
            //salesDetail.MediumGoodsGanreCode = salHisRefResultParamWork.MediumGoodsGanreCode;
            //salesDetail.MediumGoodsGanreName = salHisRefResultParamWork.MediumGoodsGanreName;
            //salesDetail.DetailGoodsGanreCode = salHisRefResultParamWork.DetailGoodsGanreCode;
            //salesDetail.DetailGoodsGanreName = salHisRefResultParamWork.DetailGoodsGanreName;
            //salesDetail.BLGoodsCode = salHisRefResultParamWork.BLGoodsCode;
            //salesDetail.BLGoodsFullName = salHisRefResultParamWork.BLGoodsFullName;
            //salesDetail.EnterpriseGanreCode = salHisRefResultParamWork.EnterpriseGanreCode;
            //salesDetail.EnterpriseGanreName = salHisRefResultParamWork.EnterpriseGanreName;
            //salesDetail.WarehouseCode = salHisRefResultParamWork.WarehouseCode;
            //salesDetail.WarehouseName = salHisRefResultParamWork.WarehouseName;
            //salesDetail.WarehouseShelfNo = salHisRefResultParamWork.WarehouseShelfNo;
            //salesDetail.SalesOrderDivCd = salHisRefResultParamWork.SalesOrderDivCd;
            //salesDetail.UnitCode = salHisRefResultParamWork.UnitCode;
            //salesDetail.UnitName = salHisRefResultParamWork.UnitName;
            //salesDetail.GoodsRateRank = salHisRefResultParamWork.GoodsRateRank;
            //salesDetail.CustRateGrpCode = salHisRefResultParamWork.CustRateGrpCode;
            //salesDetail.SuppRateGrpCode = salHisRefResultParamWork.SuppRateGrpCode;
            //salesDetail.ListPriceRate = salHisRefResultParamWork.ListPriceRate;
            //salesDetail.RateDivLPrice = salHisRefResultParamWork.RateDivLPrice;
            //salesDetail.UnPrcCalcCdLPrice = salHisRefResultParamWork.UnPrcCalcCdLPrice;
            //salesDetail.PriceCdLPrice = salHisRefResultParamWork.PriceCdLPrice;
            //salesDetail.StdUnPrcLPrice = salHisRefResultParamWork.StdUnPrcLPrice;
            //salesDetail.FracProcUnitLPrice = salHisRefResultParamWork.FracProcUnitLPrice;
            //salesDetail.FracProcLPrice = salHisRefResultParamWork.FracProcLPrice;
            //salesDetail.ListPriceTaxIncFl = salHisRefResultParamWork.ListPriceTaxIncFl;
            //salesDetail.ListPriceTaxExcFl = salHisRefResultParamWork.ListPriceTaxExcFl;
            //salesDetail.ListPriceChngCd = salHisRefResultParamWork.ListPriceChngCd;
            //salesDetail.SalesRate = salHisRefResultParamWork.SalesRate;
            //salesDetail.RateDivSalUnPrc = salHisRefResultParamWork.RateDivSalUnPrc;
            //salesDetail.UnPrcCalcCdSalUnPrc = salHisRefResultParamWork.UnPrcCalcCdSalUnPrc;
            //salesDetail.PriceCdSalUnPrc = salHisRefResultParamWork.PriceCdSalUnPrc;
            //salesDetail.StdUnPrcSalUnPrc = salHisRefResultParamWork.StdUnPrcSalUnPrc;
            //salesDetail.FracProcUnitSalUnPrc = salHisRefResultParamWork.FracProcUnitSalUnPrc;
            //salesDetail.FracProcSalUnPrc = salHisRefResultParamWork.FracProcSalUnPrc;
            //salesDetail.SalesUnPrcTaxIncFl = salHisRefResultParamWork.SalesUnPrcTaxIncFl;
            //salesDetail.SalesUnPrcTaxExcFl = salHisRefResultParamWork.SalesUnPrcTaxExcFl;
            //salesDetail.SalesUnPrcChngCd = salHisRefResultParamWork.SalesUnPrcChngCd;
            //salesDetail.CostRate = salHisRefResultParamWork.CostRate;
            //salesDetail.RateDivUnCst = salHisRefResultParamWork.RateDivUnCst;
            //salesDetail.UnPrcCalcCdUnCst = salHisRefResultParamWork.UnPrcCalcCdUnCst;
            //salesDetail.PriceCdUnCst = salHisRefResultParamWork.PriceCdUnCst;
            //salesDetail.StdUnPrcUnCst = salHisRefResultParamWork.StdUnPrcUnCst;
            //salesDetail.FracProcUnitUnCst = salHisRefResultParamWork.FracProcUnitUnCst;
            //salesDetail.FracProcUnCst = salHisRefResultParamWork.FracProcUnCst;
            //salesDetail.SalesUnitCost = salHisRefResultParamWork.SalesUnitCost;
            //salesDetail.SalesUnitCostChngDiv = salHisRefResultParamWork.SalesUnitCostChngDiv;
            //salesDetail.BargainCd = salHisRefResultParamWork.BargainCd;
            //salesDetail.BargainNm = salHisRefResultParamWork.BargainNm;
            //salesDetail.ShipmentCnt = salHisRefResultParamWork.ShipmentCnt;
            //salesDetail.SalesMoneyTaxInc = salHisRefResultParamWork.SalesMoneyTaxInc;
            //salesDetail.SalesMoneyTaxExc = salHisRefResultParamWork.SalesMoneyTaxExc;
            //salesDetail.Cost = salHisRefResultParamWork.Cost;
            //salesDetail.GrsProfitChkDiv = salHisRefResultParamWork.GrsProfitChkDiv;
            //salesDetail.SalesGoodsCd = salHisRefResultParamWork.SalesGoodsCd;
            //salesDetail.TaxAdjust = salHisRefResultParamWork.TaxAdjust;
            //salesDetail.BalanceAdjust = salHisRefResultParamWork.BalanceAdjust;
            //salesDetail.TaxationDivCd = salHisRefResultParamWork.TaxationDivCd;
            //salesDetail.PartySlipNumDtl = salHisRefResultParamWork.PartySlipNumDtl;
            //salesDetail.DtlNote = salHisRefResultParamWork.DtlNote;
            //salesDetail.SupplierCd = salHisRefResultParamWork.SupplierCd;
            //salesDetail.SupplierSnm = salHisRefResultParamWork.SupplierSnm;
            //salesDetail.ResultsAddUpSecCd = salHisRefResultParamWork.ResultsAddUpSecCd;
            //salesDetail.OrderNumber = salHisRefResultParamWork.OrderNumber;
            //salesDetail.SlipMemo1 = salHisRefResultParamWork.SlipMemo1;
            //salesDetail.SlipMemo2 = salHisRefResultParamWork.SlipMemo2;
            //salesDetail.SlipMemo3 = salHisRefResultParamWork.SlipMemo3;
            //salesDetail.SlipMemo4 = salHisRefResultParamWork.SlipMemo4;
            //salesDetail.SlipMemo5 = salHisRefResultParamWork.SlipMemo5;
            //salesDetail.SlipMemo6 = salHisRefResultParamWork.SlipMemo6;
            //salesDetail.InsideMemo1 = salHisRefResultParamWork.InsideMemo1;
            //salesDetail.InsideMemo2 = salHisRefResultParamWork.InsideMemo2;
            //salesDetail.InsideMemo3 = salHisRefResultParamWork.InsideMemo3;
            //salesDetail.InsideMemo4 = salHisRefResultParamWork.InsideMemo4;
            //salesDetail.InsideMemo5 = salHisRefResultParamWork.InsideMemo5;
            //salesDetail.InsideMemo6 = salHisRefResultParamWork.InsideMemo6;
            //salesDetail.BfListPrice = salHisRefResultParamWork.BfListPrice;
            //salesDetail.BfSalesUnitPrice = salHisRefResultParamWork.BfSalesUnitPrice;
            //salesDetail.BfUnitCost = salHisRefResultParamWork.BfUnitCost;
            //salesDetail.PrtGoodsNo = salHisRefResultParamWork.PrtGoodsNo;
            //salesDetail.PrtGoodsName = salHisRefResultParamWork.PrtGoodsName;
            //salesDetail.PrtGoodsMakerCd = salHisRefResultParamWork.PrtGoodsMakerCd;
            //salesDetail.PrtGoodsMakerNm = salHisRefResultParamWork.PrtGoodsMakerNm;
            return salesDetail;
        }

        /// <summary>
        /// PramData→UIData移項処理
        /// </summary>
        /// <param name="preChargedDataSelectResultWorkList">出荷／見積照会ワークオブジェクトリスト(明細選択)</param>
        /// <returns>売上明細データオブジェクトリスト</returns>
        private static List<SalesDetail> UIDataFromParamDataProc(List<PreChargedDataSelectResultWork> preChargedDataSelectResultWorkList)
        {
            if (preChargedDataSelectResultWorkList == null) return null;

            List<SalesDetail> salesDetailList = new List<SalesDetail>();

            foreach (PreChargedDataSelectResultWork preChargedDataSelectResultWork in preChargedDataSelectResultWorkList)
            {
                salesDetailList.Add(UIDataFromParamData(preChargedDataSelectResultWork));
            }

            return salesDetailList;
        }

        /// <summary>
        /// PramData→UIData移項処理
        /// </summary>
        /// <param name="preChargedDataSelectResultWork">出荷／見積照会ワークオブジェクト(明細選択)</param>
        /// <returns>売上明細データオブジェクト</returns>
        private static SalesDetail UIDataFromParamDataProc(PreChargedDataSelectResultWork preChargedDataSelectResultWork)
        {
            SalesDetail salesDetail = new SalesDetail();
            //salesDetail.EnterpriseCode = preChargedDataSelectResultWork.EnterpriseCode;
            //salesDetail.LogicalDeleteCode = preChargedDataSelectResultWork.LogicalDeleteCode;
            //salesDetail.AcceptAnOrderNo = preChargedDataSelectResultWork.AcceptAnOrderNo;
            //salesDetail.AcptAnOdrStatus = preChargedDataSelectResultWork.AcptAnOdrStatus;
            //salesDetail.SalesSlipNum = preChargedDataSelectResultWork.SalesSlipNum;
            //salesDetail.SalesRowNo = preChargedDataSelectResultWork.SalesRowNo;
            //salesDetail.SectionCode = preChargedDataSelectResultWork.SectionCode;
            //salesDetail.SubSectionCode = preChargedDataSelectResultWork.SubSectionCode;
            //salesDetail.MinSectionCode = preChargedDataSelectResultWork.MinSectionCode;
            //salesDetail.SalesDate = preChargedDataSelectResultWork.SalesDate;
            //salesDetail.CommonSeqNo = preChargedDataSelectResultWork.CommonSeqNo;
            //salesDetail.SalesSlipDtlNum = preChargedDataSelectResultWork.SalesSlipDtlNum;
            //salesDetail.AcptAnOdrStatusSrc = preChargedDataSelectResultWork.AcptAnOdrStatusSrc;
            //salesDetail.SalesSlipDtlNumSrc = preChargedDataSelectResultWork.SalesSlipDtlNumSrc;
            //salesDetail.SupplierFormalSync = preChargedDataSelectResultWork.SupplierFormalSync;
            //salesDetail.StockSlipDtlNumSync = preChargedDataSelectResultWork.StockSlipDtlNumSync;
            //salesDetail.SalesSlipCdDtl = preChargedDataSelectResultWork.SalesSlipCdDtl;
            //salesDetail.ServiceSlipCd = preChargedDataSelectResultWork.ServiceSlipCd;
            //salesDetail.SalesDepositsDiv = preChargedDataSelectResultWork.SalesDepositsDiv;
            //salesDetail.StockMngExistCd = preChargedDataSelectResultWork.StockMngExistCd;
            //salesDetail.GoodsKindCode = preChargedDataSelectResultWork.GoodsKindCode;
            //salesDetail.GoodsMakerCd = preChargedDataSelectResultWork.GoodsMakerCd;
            //salesDetail.MakerName = preChargedDataSelectResultWork.MakerName;
            //salesDetail.GoodsNo = preChargedDataSelectResultWork.GoodsNo;
            //salesDetail.GoodsName = preChargedDataSelectResultWork.GoodsName;
            //salesDetail.GoodsSetDivCd = preChargedDataSelectResultWork.GoodsSetDivCd;
            //salesDetail.LargeGoodsGanreCode = preChargedDataSelectResultWork.LargeGoodsGanreCode;
            //salesDetail.LargeGoodsGanreName = preChargedDataSelectResultWork.LargeGoodsGanreName;
            //salesDetail.MediumGoodsGanreCode = preChargedDataSelectResultWork.MediumGoodsGanreCode;
            //salesDetail.MediumGoodsGanreName = preChargedDataSelectResultWork.MediumGoodsGanreName;
            //salesDetail.DetailGoodsGanreCode = preChargedDataSelectResultWork.DetailGoodsGanreCode;
            //salesDetail.DetailGoodsGanreName = preChargedDataSelectResultWork.DetailGoodsGanreName;
            //salesDetail.BLGoodsCode = preChargedDataSelectResultWork.BLGoodsCode;
            //salesDetail.BLGoodsFullName = preChargedDataSelectResultWork.BLGoodsFullName;
            //salesDetail.EnterpriseGanreCode = preChargedDataSelectResultWork.EnterpriseGanreCode;
            //salesDetail.EnterpriseGanreName = preChargedDataSelectResultWork.EnterpriseGanreName;
            //salesDetail.WarehouseCode = preChargedDataSelectResultWork.WarehouseCode;
            //salesDetail.WarehouseName = preChargedDataSelectResultWork.WarehouseName;
            //salesDetail.WarehouseShelfNo = preChargedDataSelectResultWork.WarehouseShelfNo;
            //salesDetail.SalesOrderDivCd = preChargedDataSelectResultWork.SalesOrderDivCd;
            //salesDetail.UnitCode = preChargedDataSelectResultWork.UnitCode;
            //salesDetail.UnitName = preChargedDataSelectResultWork.UnitName;
            //salesDetail.GoodsRateRank = preChargedDataSelectResultWork.GoodsRateRank;
            //salesDetail.CustRateGrpCode = preChargedDataSelectResultWork.CustRateGrpCode;
            //salesDetail.SuppRateGrpCode = preChargedDataSelectResultWork.SuppRateGrpCode;
            //salesDetail.ListPriceRate = preChargedDataSelectResultWork.ListPriceRate;
            //salesDetail.RateDivLPrice = preChargedDataSelectResultWork.RateDivLPrice;
            //salesDetail.UnPrcCalcCdLPrice = preChargedDataSelectResultWork.UnPrcCalcCdLPrice;
            //salesDetail.PriceCdLPrice = preChargedDataSelectResultWork.PriceCdLPrice;
            //salesDetail.StdUnPrcLPrice = preChargedDataSelectResultWork.StdUnPrcLPrice;
            //salesDetail.FracProcUnitLPrice = preChargedDataSelectResultWork.FracProcUnitLPrice;
            //salesDetail.FracProcLPrice = preChargedDataSelectResultWork.FracProcLPrice;
            //salesDetail.ListPriceTaxIncFl = preChargedDataSelectResultWork.ListPriceTaxIncFl;
            //salesDetail.ListPriceTaxExcFl = preChargedDataSelectResultWork.ListPriceTaxExcFl;
            //salesDetail.ListPriceChngCd = preChargedDataSelectResultWork.ListPriceChngCd;
            //salesDetail.SalesRate = preChargedDataSelectResultWork.SalesRate;
            //salesDetail.RateDivSalUnPrc = preChargedDataSelectResultWork.RateDivSalUnPrc;
            //salesDetail.UnPrcCalcCdSalUnPrc = preChargedDataSelectResultWork.UnPrcCalcCdSalUnPrc;
            //salesDetail.PriceCdSalUnPrc = preChargedDataSelectResultWork.PriceCdSalUnPrc;
            //salesDetail.StdUnPrcSalUnPrc = preChargedDataSelectResultWork.StdUnPrcSalUnPrc;
            //salesDetail.FracProcUnitSalUnPrc = preChargedDataSelectResultWork.FracProcUnitSalUnPrc;
            //salesDetail.FracProcSalUnPrc = preChargedDataSelectResultWork.FracProcSalUnPrc;
            //salesDetail.SalesUnPrcTaxIncFl = preChargedDataSelectResultWork.SalesUnPrcTaxIncFl;
            //salesDetail.SalesUnPrcTaxExcFl = preChargedDataSelectResultWork.SalesUnPrcTaxExcFl;
            //salesDetail.SalesUnPrcChngCd = preChargedDataSelectResultWork.SalesUnPrcChngCd;
            //salesDetail.CostRate = preChargedDataSelectResultWork.CostRate;
            //salesDetail.RateDivUnCst = preChargedDataSelectResultWork.RateDivUnCst;
            //salesDetail.UnPrcCalcCdUnCst = preChargedDataSelectResultWork.UnPrcCalcCdUnCst;
            //salesDetail.PriceCdUnCst = preChargedDataSelectResultWork.PriceCdUnCst;
            //salesDetail.StdUnPrcUnCst = preChargedDataSelectResultWork.StdUnPrcUnCst;
            //salesDetail.FracProcUnitUnCst = preChargedDataSelectResultWork.FracProcUnitUnCst;
            //salesDetail.FracProcUnCst = preChargedDataSelectResultWork.FracProcUnCst;
            //salesDetail.SalesUnitCost = preChargedDataSelectResultWork.SalesUnitCost;
            //salesDetail.SalesUnitCostChngDiv = preChargedDataSelectResultWork.SalesUnitCostChngDiv;
            //salesDetail.BargainCd = preChargedDataSelectResultWork.BargainCd;
            //salesDetail.BargainNm = preChargedDataSelectResultWork.BargainNm;
            //salesDetail.ShipmentCnt = preChargedDataSelectResultWork.ShipmentCnt;
            //salesDetail.SalesMoneyTaxInc = preChargedDataSelectResultWork.SalesMoneyTaxInc;
            //salesDetail.SalesMoneyTaxExc = preChargedDataSelectResultWork.SalesMoneyTaxExc;
            //salesDetail.Cost = preChargedDataSelectResultWork.Cost;
            //salesDetail.GrsProfitChkDiv = preChargedDataSelectResultWork.GrsProfitChkDiv;
            //salesDetail.SalesGoodsCd = preChargedDataSelectResultWork.SalesGoodsCd;
            //salesDetail.TaxAdjust = preChargedDataSelectResultWork.TaxAdjust;
            //salesDetail.BalanceAdjust = preChargedDataSelectResultWork.BalanceAdjust;
            //salesDetail.TaxationDivCd = preChargedDataSelectResultWork.TaxationDivCd;
            //salesDetail.PartySlipNumDtl = preChargedDataSelectResultWork.PartySlipNumDtl;
            //salesDetail.DtlNote = preChargedDataSelectResultWork.DtlNote;
            //salesDetail.SupplierCd = preChargedDataSelectResultWork.SupplierCd;
            //salesDetail.SupplierSnm = preChargedDataSelectResultWork.SupplierSnm;
            //salesDetail.ResultsAddUpSecCd = preChargedDataSelectResultWork.ResultsAddUpSecCd;
            //salesDetail.OrderNumber = preChargedDataSelectResultWork.OrderNumber;
            //salesDetail.SlipMemo1 = preChargedDataSelectResultWork.SlipMemo1;
            //salesDetail.SlipMemo2 = preChargedDataSelectResultWork.SlipMemo2;
            //salesDetail.SlipMemo3 = preChargedDataSelectResultWork.SlipMemo3;
            //salesDetail.SlipMemo4 = preChargedDataSelectResultWork.SlipMemo4;
            //salesDetail.SlipMemo5 = preChargedDataSelectResultWork.SlipMemo5;
            //salesDetail.SlipMemo6 = preChargedDataSelectResultWork.SlipMemo6;
            //salesDetail.InsideMemo1 = preChargedDataSelectResultWork.InsideMemo1;
            //salesDetail.InsideMemo2 = preChargedDataSelectResultWork.InsideMemo2;
            //salesDetail.InsideMemo3 = preChargedDataSelectResultWork.InsideMemo3;
            //salesDetail.InsideMemo4 = preChargedDataSelectResultWork.InsideMemo4;
            //salesDetail.InsideMemo5 = preChargedDataSelectResultWork.InsideMemo5;
            //salesDetail.InsideMemo6 = preChargedDataSelectResultWork.InsideMemo6;
            //salesDetail.BfListPrice = preChargedDataSelectResultWork.BfListPrice;
            //salesDetail.BfSalesUnitPrice = preChargedDataSelectResultWork.BfSalesUnitPrice;
            //salesDetail.BfUnitCost = preChargedDataSelectResultWork.BfUnitCost;
            //salesDetail.PrtGoodsNo = preChargedDataSelectResultWork.PrtGoodsNo;
            //salesDetail.PrtGoodsName = preChargedDataSelectResultWork.PrtGoodsName;
            //salesDetail.PrtGoodsMakerCd = preChargedDataSelectResultWork.PrtGoodsMakerCd;
            //salesDetail.PrtGoodsMakerNm = preChargedDataSelectResultWork.PrtGoodsMakerNm;
            return salesDetail;
        }

        /// <summary>
        /// PramData→UIData移項処理
        /// </summary>
        /// <param name="acptAnOdrRemainRefDataList">受注照会ワークオブジェクトリスト(明細選択)</param>
        /// <returns>売上明細データオブジェクトリスト</returns>
        private static List<SalesDetail> UIDataFromParamDataProc(List<AcptAnOdrRemainRefData> acptAnOdrRemainRefDataList)
        {
            if (acptAnOdrRemainRefDataList == null) return null;

            List<SalesDetail> salesDetailList = new List<SalesDetail>();

            foreach (AcptAnOdrRemainRefData acptAnOdrRemainRefData in acptAnOdrRemainRefDataList)
            {
                salesDetailList.Add(UIDataFromParamData(acptAnOdrRemainRefData));
            }

            return salesDetailList;
        }

        /// <summary>
        /// PramData→UIData移項処理
        /// </summary>
        /// <param name="salHisRefResultParamWork">受注照会ワークオブジェクト(明細選択)</param>
        /// <returns>売上明細データオブジェクト</returns>
        private static SalesDetail UIDataFromParamDataProc(AcptAnOdrRemainRefData acptAnOdrRemainRefData)
        {
            SalesDetail salesDetail = new SalesDetail();
            //salesDetail.EnterpriseCode = acptAnOdrRemainRefData.EnterpriseCode;
            //salesDetail.AcceptAnOrderNo = acptAnOdrRemainRefData.AcceptAnOrderNo;
            //salesDetail.AcptAnOdrStatus = acptAnOdrRemainRefData.AcptAnOdrStatus;
            //salesDetail.SalesSlipNum = acptAnOdrRemainRefData.SalesSlipNum;
            //salesDetail.SalesDate = acptAnOdrRemainRefData.SalesDate;
            //salesDetail.CommonSeqNo = acptAnOdrRemainRefData.CommonSeqNo;
            //salesDetail.SalesSlipDtlNum = acptAnOdrRemainRefData.SalesSlipDtlNum;
            //salesDetail.MakerName = acptAnOdrRemainRefData.MakerName;
            //salesDetail.GoodsNo = acptAnOdrRemainRefData.GoodsNo;
            //salesDetail.GoodsName = acptAnOdrRemainRefData.GoodsName;
            //salesDetail.UnitName = acptAnOdrRemainRefData.UnitName;
            //salesDetail.StdUnPrcSalUnPrc = acptAnOdrRemainRefData.StdUnPrcSalUnPrc;
            //salesDetail.SalesUnPrcTaxExcFl = acptAnOdrRemainRefData.SalesUnPrcTaxExcFl;
            //salesDetail.SalesUnitCost = acptAnOdrRemainRefData.SalesUnitCost;
            //salesDetail.BargainNm = acptAnOdrRemainRefData.BargainNm;
            //salesDetail.PartySlipNumDtl = acptAnOdrRemainRefData.PartySlipNumDtl;
            //salesDetail.DtlNote = acptAnOdrRemainRefData.DtlNote;
            //salesDetail.SupplierSnm = acptAnOdrRemainRefData.SupplierSnm;
            //salesDetail.OrderNumber = acptAnOdrRemainRefData.OrderNumber;
            //salesDetail.SlipMemo1 = acptAnOdrRemainRefData.SlipMemo1;
            //salesDetail.SlipMemo2 = acptAnOdrRemainRefData.SlipMemo2;
            //salesDetail.SlipMemo3 = acptAnOdrRemainRefData.SlipMemo3;
            //salesDetail.SlipMemo4 = acptAnOdrRemainRefData.SlipMemo4;
            //salesDetail.SlipMemo5 = acptAnOdrRemainRefData.SlipMemo5;
            //salesDetail.SlipMemo6 = acptAnOdrRemainRefData.SlipMemo6;
            //salesDetail.InsideMemo1 = acptAnOdrRemainRefData.InsideMemo1;
            //salesDetail.InsideMemo2 = acptAnOdrRemainRefData.InsideMemo2;
            //salesDetail.InsideMemo3 = acptAnOdrRemainRefData.InsideMemo3;
            //salesDetail.InsideMemo4 = acptAnOdrRemainRefData.InsideMemo4;
            //salesDetail.InsideMemo5 = acptAnOdrRemainRefData.InsideMemo5;
            //salesDetail.InsideMemo6 = acptAnOdrRemainRefData.InsideMemo6;
            return salesDetail;
        }

        /// <summary>
        /// PramData→UIData移項処理
        /// </summary>
        /// <param name="addUppSrcStockDetailWorkList">計上元仕入明細データワークオブジェクト配列</param>
        /// <returns>売上明細データオブジェクトリスト</returns>
        private static List<SalesDetail> UIDataFromParamDataProc(AddUpOrgSalesDetailWork[] addUpSrcSalesDetailWorkList)
        {
            if (addUpSrcSalesDetailWorkList == null) return null;

            List<SalesDetail> addUpOrgSalesDetailList = new List<SalesDetail>();

            foreach (AddUpOrgSalesDetailWork addUpSrcSalesDetailWork in addUpSrcSalesDetailWorkList)
            {
                addUpOrgSalesDetailList.Add(UIDataFromParamData((SalesDetailWork)addUpSrcSalesDetailWork));
            }

            return addUpOrgSalesDetailList;
        }

        /// <summary>
        /// PramData→UIData移項処理
        /// </summary>
        /// <param name="salesSlipWork">売上データワークオブジェクト</param>
        /// <returns>売上データオブジェクト</returns>
        private static SalesSlip UIDataFromParamDataProc(SalesSlipWork salesSlipWork)
        {
            if (salesSlipWork == null) return null;  // --- ADD 2015/08/22 黄興貴 Redmine#47045

            SalesSlip salesSlip = new SalesSlip();

            salesSlip.CreateDateTime = salesSlipWork.CreateDateTime; // 作成日時
            salesSlip.UpdateDateTime = salesSlipWork.UpdateDateTime; // 更新日時
            salesSlip.EnterpriseCode = salesSlipWork.EnterpriseCode; // 企業コード
            salesSlip.FileHeaderGuid = salesSlipWork.FileHeaderGuid; // GUID
            salesSlip.UpdEmployeeCode = salesSlipWork.UpdEmployeeCode; // 更新従業員コード
            salesSlip.UpdAssemblyId1 = salesSlipWork.UpdAssemblyId1; // 更新アセンブリID1
            salesSlip.UpdAssemblyId2 = salesSlipWork.UpdAssemblyId2; // 更新アセンブリID2
            salesSlip.LogicalDeleteCode = salesSlipWork.LogicalDeleteCode; // 論理削除区分
            salesSlip.AcptAnOdrStatus = salesSlipWork.AcptAnOdrStatus; // 受注ステータス
            salesSlip.SalesSlipNum = salesSlipWork.SalesSlipNum; // 売上伝票番号
            salesSlip.SectionCode = salesSlipWork.SectionCode; // 拠点コード
            salesSlip.SubSectionCode = salesSlipWork.SubSectionCode; // 部門コード
            salesSlip.DebitNoteDiv = salesSlipWork.DebitNoteDiv; // 赤伝区分
            salesSlip.DebitNLnkSalesSlNum = salesSlipWork.DebitNLnkSalesSlNum; // 赤黒連結売上伝票番号
            salesSlip.SalesSlipCd = salesSlipWork.SalesSlipCd; // 売上伝票区分
            salesSlip.SalesGoodsCd = salesSlipWork.SalesGoodsCd; // 売上商品区分
            salesSlip.AccRecDivCd = salesSlipWork.AccRecDivCd; // 売掛区分
            salesSlip.SalesInpSecCd = salesSlipWork.SalesInpSecCd; // 売上入力拠点コード
            salesSlip.DemandAddUpSecCd = salesSlipWork.DemandAddUpSecCd; // 請求計上拠点コード
            salesSlip.ResultsAddUpSecCd = salesSlipWork.ResultsAddUpSecCd; // 実績計上拠点コード
            salesSlip.UpdateSecCd = salesSlipWork.UpdateSecCd; // 更新拠点コード
            salesSlip.SalesSlipUpdateCd = salesSlipWork.SalesSlipUpdateCd; // 売上伝票更新区分
            salesSlip.SearchSlipDate = salesSlipWork.SearchSlipDate; // 伝票検索日付
            salesSlip.ShipmentDay = salesSlipWork.ShipmentDay; // 出荷日付
            salesSlip.SalesDate = salesSlipWork.SalesDate; // 売上日付
            salesSlip.AddUpADate = salesSlipWork.AddUpADate; // 計上日付
            salesSlip.DelayPaymentDiv = salesSlipWork.DelayPaymentDiv; // 来勘区分
            salesSlip.EstimateFormNo = salesSlipWork.EstimateFormNo; // 見積書番号
            salesSlip.EstimateDivide = salesSlipWork.EstimateDivide; // 見積区分
            salesSlip.InputAgenCd = salesSlipWork.InputAgenCd; // 入力担当者コード
            salesSlip.InputAgenNm = salesSlipWork.InputAgenNm; // 入力担当者名称
            salesSlip.SalesInputCode = salesSlipWork.SalesInputCode; // 売上入力者コード
            salesSlip.SalesInputName = salesSlipWork.SalesInputName; // 売上入力者名称
            salesSlip.FrontEmployeeCd = salesSlipWork.FrontEmployeeCd; // 受付従業員コード
            salesSlip.FrontEmployeeNm = salesSlipWork.FrontEmployeeNm; // 受付従業員名称
            salesSlip.SalesEmployeeCd = salesSlipWork.SalesEmployeeCd; // 販売従業員コード
            salesSlip.SalesEmployeeNm = salesSlipWork.SalesEmployeeNm; // 販売従業員名称
            salesSlip.TotalAmountDispWayCd = salesSlipWork.TotalAmountDispWayCd; // 総額表示方法区分
            salesSlip.TtlAmntDispRateApy = salesSlipWork.TtlAmntDispRateApy; // 総額表示掛率適用区分
            salesSlip.SalesTotalTaxInc = salesSlipWork.SalesTotalTaxInc; // 売上伝票合計（税込み）
            salesSlip.SalesTotalTaxExc = salesSlipWork.SalesTotalTaxExc; // 売上伝票合計（税抜き）
            salesSlip.SalesPrtTotalTaxInc = salesSlipWork.SalesPrtTotalTaxInc; // 売上部品合計（税込み）
            salesSlip.SalesPrtTotalTaxExc = salesSlipWork.SalesPrtTotalTaxExc; // 売上部品合計（税抜き）
            salesSlip.SalesWorkTotalTaxInc = salesSlipWork.SalesWorkTotalTaxInc; // 売上作業合計（税込み）
            salesSlip.SalesWorkTotalTaxExc = salesSlipWork.SalesWorkTotalTaxExc; // 売上作業合計（税抜き）
            salesSlip.SalesSubtotalTaxInc = salesSlipWork.SalesSubtotalTaxInc; // 売上小計（税込み）
            salesSlip.SalesSubtotalTaxExc = salesSlipWork.SalesSubtotalTaxExc; // 売上小計（税抜き）
            salesSlip.SalesPrtSubttlInc = salesSlipWork.SalesPrtSubttlInc; // 売上部品小計（税込み）
            salesSlip.SalesPrtSubttlExc = salesSlipWork.SalesPrtSubttlExc; // 売上部品小計（税抜き）
            salesSlip.SalesWorkSubttlInc = salesSlipWork.SalesWorkSubttlInc; // 売上作業小計（税込み）
            salesSlip.SalesWorkSubttlExc = salesSlipWork.SalesWorkSubttlExc; // 売上作業小計（税抜き）
            salesSlip.SalesNetPrice = salesSlipWork.SalesNetPrice; // 売上正価金額
            salesSlip.SalesSubtotalTax = salesSlipWork.SalesSubtotalTax; // 売上小計（税）
            salesSlip.ItdedSalesOutTax = salesSlipWork.ItdedSalesOutTax; // 売上外税対象額
            salesSlip.ItdedSalesInTax = salesSlipWork.ItdedSalesInTax; // 売上内税対象額
            salesSlip.SalSubttlSubToTaxFre = salesSlipWork.SalSubttlSubToTaxFre; // 売上小計非課税対象額
            salesSlip.SalesOutTax = salesSlipWork.SalesOutTax; // 売上金額消費税額（外税）
            salesSlip.SalAmntConsTaxInclu = salesSlipWork.SalAmntConsTaxInclu; // 売上金額消費税額（内税）
            salesSlip.SalesDisTtlTaxExc = salesSlipWork.SalesDisTtlTaxExc; // 売上値引金額計（税抜き）
            salesSlip.ItdedSalesDisOutTax = salesSlipWork.ItdedSalesDisOutTax; // 売上値引外税対象額合計
            salesSlip.ItdedSalesDisInTax = salesSlipWork.ItdedSalesDisInTax; // 売上値引内税対象額合計
            salesSlip.ItdedPartsDisOutTax = salesSlipWork.ItdedPartsDisOutTax; // 部品値引対象額合計（税抜き）
            salesSlip.ItdedPartsDisInTax = salesSlipWork.ItdedPartsDisInTax; // 部品値引対象額合計（税込み）
            salesSlip.ItdedWorkDisOutTax = salesSlipWork.ItdedWorkDisOutTax; // 作業値引対象額合計（税抜き）
            salesSlip.ItdedWorkDisInTax = salesSlipWork.ItdedWorkDisInTax; // 作業値引対象額合計（税込み）
            salesSlip.ItdedSalesDisTaxFre = salesSlipWork.ItdedSalesDisTaxFre; // 売上値引非課税対象額合計
            salesSlip.SalesDisOutTax = salesSlipWork.SalesDisOutTax; // 売上値引消費税額（外税）
            salesSlip.SalesDisTtlTaxInclu = salesSlipWork.SalesDisTtlTaxInclu; // 売上値引消費税額（内税）
            salesSlip.PartsDiscountRate = salesSlipWork.PartsDiscountRate; // 部品値引率
            salesSlip.RavorDiscountRate = salesSlipWork.RavorDiscountRate; // 工賃値引率
            salesSlip.TotalCost = salesSlipWork.TotalCost; // 原価金額計
            salesSlip.ConsTaxLayMethod = salesSlipWork.ConsTaxLayMethod; // 消費税転嫁方式
            salesSlip.ConsTaxRate = salesSlipWork.ConsTaxRate; // 消費税税率
            salesSlip.FractionProcCd = salesSlipWork.FractionProcCd; // 端数処理区分
            salesSlip.AccRecConsTax = salesSlipWork.AccRecConsTax; // 売掛消費税
            salesSlip.AutoDepositCd = salesSlipWork.AutoDepositCd; // 自動入金区分
            salesSlip.AutoDepositNoteDiv = salesSlipWork.AutoDepositNoteDiv; // 自動入金備考区分 // ADD 2013/01/18 田建委 Redmine#33797
            salesSlip.AutoDepositSlipNo = salesSlipWork.AutoDepositSlipNo; // 自動入金伝票番号
            salesSlip.DepositAllowanceTtl = salesSlipWork.DepositAllowanceTtl; // 入金引当合計額
            salesSlip.DepositAlwcBlnce = salesSlipWork.DepositAlwcBlnce; // 入金引当残高
            salesSlip.ClaimCode = salesSlipWork.ClaimCode; // 請求先コード
            salesSlip.ClaimSnm = salesSlipWork.ClaimSnm; // 請求先略称
            salesSlip.CustomerCode = salesSlipWork.CustomerCode; // 得意先コード
            salesSlip.CustomerName = salesSlipWork.CustomerName; // 得意先名称
            salesSlip.CustomerName2 = salesSlipWork.CustomerName2; // 得意先名称2
            salesSlip.CustomerSnm = salesSlipWork.CustomerSnm; // 得意先略称
            salesSlip.HonorificTitle = salesSlipWork.HonorificTitle; // 敬称
            salesSlip.OutputNameCode = salesSlipWork.OutputNameCode; // 諸口コード
            salesSlip.OutputName = salesSlipWork.OutputName; // 諸口名称
            salesSlip.CustSlipNo = salesSlipWork.CustSlipNo; // 得意先伝票番号
            salesSlip.SlipAddressDiv = salesSlipWork.SlipAddressDiv; // 伝票住所区分
            salesSlip.AddresseeCode = salesSlipWork.AddresseeCode; // 納品先コード
            salesSlip.AddresseeName = salesSlipWork.AddresseeName; // 納品先名称
            salesSlip.AddresseeName2 = salesSlipWork.AddresseeName2; // 納品先名称2
            salesSlip.AddresseePostNo = salesSlipWork.AddresseePostNo; // 納品先郵便番号
            salesSlip.AddresseeAddr1 = salesSlipWork.AddresseeAddr1; // 納品先住所1(都道府県市区郡・町村・字)
            salesSlip.AddresseeAddr3 = salesSlipWork.AddresseeAddr3; // 納品先住所3(番地)
            salesSlip.AddresseeAddr4 = salesSlipWork.AddresseeAddr4; // 納品先住所4(アパート名称)
            salesSlip.AddresseeTelNo = salesSlipWork.AddresseeTelNo; // 納品先電話番号
            salesSlip.AddresseeFaxNo = salesSlipWork.AddresseeFaxNo; // 納品先FAX番号
            salesSlip.PartySaleSlipNum = salesSlipWork.PartySaleSlipNum; // 相手先伝票番号
            salesSlip.SlipNote = salesSlipWork.SlipNote; // 伝票備考
            salesSlip.SlipNote2 = salesSlipWork.SlipNote2; // 伝票備考２
            salesSlip.SlipNote3 = salesSlipWork.SlipNote3; // 伝票備考３
            salesSlip.RetGoodsReasonDiv = salesSlipWork.RetGoodsReasonDiv; // 返品理由コード
            salesSlip.RetGoodsReason = salesSlipWork.RetGoodsReason; // 返品理由
            salesSlip.RegiProcDate = salesSlipWork.RegiProcDate; // レジ処理日
            salesSlip.CashRegisterNo = salesSlipWork.CashRegisterNo; // レジ番号
            salesSlip.PosReceiptNo = salesSlipWork.PosReceiptNo; // POSレシート番号
            salesSlip.DetailRowCount = salesSlipWork.DetailRowCount; // 明細行数
            salesSlip.EdiSendDate = salesSlipWork.EdiSendDate; // ＥＤＩ送信日
            salesSlip.EdiTakeInDate = salesSlipWork.EdiTakeInDate; // ＥＤＩ取込日
            salesSlip.UoeRemark1 = salesSlipWork.UoeRemark1; // ＵＯＥリマーク１
            salesSlip.UoeRemark2 = salesSlipWork.UoeRemark2; // ＵＯＥリマーク２
            salesSlip.SlipPrintDivCd = salesSlipWork.SlipPrintDivCd; // 伝票発行区分
            salesSlip.SlipPrintFinishCd = salesSlipWork.SlipPrintFinishCd; // 伝票発行済区分
            salesSlip.SalesSlipPrintDate = salesSlipWork.SalesSlipPrintDate; // 売上伝票発行日
            salesSlip.BusinessTypeCode = salesSlipWork.BusinessTypeCode; // 業種コード
            salesSlip.BusinessTypeName = salesSlipWork.BusinessTypeName; // 業種名称
            salesSlip.OrderNumber = salesSlipWork.OrderNumber; // 発注番号
            salesSlip.DeliveredGoodsDiv = salesSlipWork.DeliveredGoodsDiv; // 納品区分
            salesSlip.DeliveredGoodsDivNm = salesSlipWork.DeliveredGoodsDivNm; // 納品区分名称
            salesSlip.SalesAreaCode = salesSlipWork.SalesAreaCode; // 販売エリアコード
            salesSlip.SalesAreaName = salesSlipWork.SalesAreaName; // 販売エリア名称
            salesSlip.ReconcileFlag = salesSlipWork.ReconcileFlag; // 消込フラグ
            salesSlip.SlipPrtSetPaperId = salesSlipWork.SlipPrtSetPaperId; // 伝票印刷設定用帳票ID
            salesSlip.CompleteCd = salesSlipWork.CompleteCd; // 一式伝票区分
            salesSlip.SalesPriceFracProcCd = salesSlipWork.SalesPriceFracProcCd; // 売上金額端数処理区分
            salesSlip.StockGoodsTtlTaxExc = salesSlipWork.StockGoodsTtlTaxExc; // 在庫商品合計金額（税抜）
            salesSlip.PureGoodsTtlTaxExc = salesSlipWork.PureGoodsTtlTaxExc; // 純正商品合計金額（税抜）
            salesSlip.ListPricePrintDiv = salesSlipWork.ListPricePrintDiv; // 定価印刷区分
            salesSlip.EraNameDispCd1 = salesSlipWork.EraNameDispCd1; // 元号表示区分１
            salesSlip.EstimaTaxDivCd = salesSlipWork.EstimaTaxDivCd; // 見積消費税区分
            salesSlip.EstimateFormPrtCd = salesSlipWork.EstimateFormPrtCd; // 見積書印刷区分
            salesSlip.EstimateSubject = salesSlipWork.EstimateSubject; // 見積件名
            salesSlip.Footnotes1 = salesSlipWork.Footnotes1; // 脚注１
            salesSlip.Footnotes2 = salesSlipWork.Footnotes2; // 脚注２
            salesSlip.EstimateTitle1 = salesSlipWork.EstimateTitle1; // 見積タイトル１
            salesSlip.EstimateTitle2 = salesSlipWork.EstimateTitle2; // 見積タイトル２
            salesSlip.EstimateTitle3 = salesSlipWork.EstimateTitle3; // 見積タイトル３
            salesSlip.EstimateTitle4 = salesSlipWork.EstimateTitle4; // 見積タイトル４
            salesSlip.EstimateTitle5 = salesSlipWork.EstimateTitle5; // 見積タイトル５
            salesSlip.EstimateNote1 = salesSlipWork.EstimateNote1; // 見積備考１
            salesSlip.EstimateNote2 = salesSlipWork.EstimateNote2; // 見積備考２
            salesSlip.EstimateNote3 = salesSlipWork.EstimateNote3; // 見積備考３
            salesSlip.EstimateNote4 = salesSlipWork.EstimateNote4; // 見積備考４
            salesSlip.EstimateNote5 = salesSlipWork.EstimateNote5; // 見積備考５
            salesSlip.EstimateValidityDate = salesSlipWork.EstimateValidityDate; // 見積有効期限
            salesSlip.PartsNoPrtCd = salesSlipWork.PartsNoPrtCd; // 品番印字区分
            salesSlip.OptionPringDivCd = salesSlipWork.OptionPringDivCd; // オプション印字区分
            salesSlip.RateUseCode = salesSlipWork.RateUseCode; // 掛率使用区分
            //salesSlip.InputMode = salesSlipWork.InputMode; // 入力モード
            //salesSlip.SalesSlipDisplay = salesSlipWork.SalesSlipDisplay; // 売上伝票区分(画面表示用)
            //salesSlip.AcptAnOdrStatusDisplay = salesSlipWork.AcptAnOdrStatusDisplay; // 受注ステータス
            //salesSlip.CustRateGrpCode = salesSlipWork.CustRateGrpCode; // 得意先掛率グループコード
            //salesSlip.ClaimName = salesSlipWork.ClaimName; // 請求先名称
            //salesSlip.ClaimName2 = salesSlipWork.ClaimName2; // 請求先名称２
            //salesSlip.CreditMngCode = salesSlipWork.CreditMngCode; // 与信管理区分
            //salesSlip.TotalDay = salesSlipWork.TotalDay; // 締日
            //salesSlip.NTimeCalcStDate = salesSlipWork.NTimeCalcStDate; // 次回勘定開始日
            //salesSlip.TotalMoneyForGrossProfit = salesSlipWork.TotalMoneyForGrossProfit; // 粗利計算用売上金額
            //salesSlip.AcceptAnOrderDate = salesSlipWork.AcceptAnOrderDate; // 受注日
            //salesSlip.SectionName = salesSlipWork.SectionName; // 拠点名称
            //salesSlip.SubSectionName = salesSlipWork.SubSectionName; // 部門名称
            //salesSlip.CarMngDivCd = salesSlipWork.CarMngDivCd; // 車輌管理区分
            //salesSlip.SearchMode = salesSlipWork.SearchMode; // 部品検索モード
            //salesSlip.SearchCarMode = salesSlipWork.SearchCarMode; // 車両検索モード
            //salesSlip.CustOrderNoDispDiv = salesSlipWork.CustOrderNoDispDiv; // 得意先注番表示区分

            return salesSlip;
        }

        /// <summary>
        /// PramData→UIData移項処理
        /// </summary>
        /// <param name="salesDetailWorkArray">売上明細データワークオブジェクト配列</param>
        /// <returns>売上明細データオブジェクトリスト</returns>
        private static List<SalesDetail> UIDataFromParamDataProc(SalesDetailWork[] salesDetailWorkArray)
        {
            if (salesDetailWorkArray == null) return null;

            List<SalesDetail> salesDetailList = new List<SalesDetail>();

            foreach (SalesDetailWork salesDetailWork in salesDetailWorkArray)
            {
                salesDetailList.Add(UIDataFromParamData(salesDetailWork));
            }

            return salesDetailList;
        }

        //>>>2010/02/26
        /// <summary>
        /// PramData→UIData移項処理
        /// </summary>
        /// <param name="salesDetailWorkList">売上明細データワークオブジェクトリスト</param>
        /// <returns>売上明細データオブジェクトリスト</returns>
        private static List<SalesDetail> UIDataFromParamDataProc(List<SalesDetailWork> salesDetailWorkList)
        {
            if (salesDetailWorkList == null) return null;

            List<SalesDetail> salesDetailList = new List<SalesDetail>();

            foreach (SalesDetailWork salesDetailWork in salesDetailWorkList)
            {
                salesDetailList.Add(UIDataFromParamData(salesDetailWork));
            }

            return salesDetailList;
        }
        //<<<2010/02/26

        /// <summary>
        /// PramData→UIData移項処理
        /// </summary>
        /// <param name="salesDetailWork">売上明細データワークオブジェクト</param>
        /// <returns>売上明細データオブジェクト</returns>
        private static SalesDetail UIDataFromParamDataProc(SalesDetailWork salesDetailWork)
        {
            SalesDetail salesDetail = new SalesDetail();

            salesDetail.CreateDateTime = salesDetailWork.CreateDateTime; // 作成日時
            salesDetail.UpdateDateTime = salesDetailWork.UpdateDateTime; // 更新日時
            salesDetail.EnterpriseCode = salesDetailWork.EnterpriseCode; // 企業コード
            salesDetail.FileHeaderGuid = salesDetailWork.FileHeaderGuid; // GUID
            salesDetail.UpdEmployeeCode = salesDetailWork.UpdEmployeeCode; // 更新従業員コード
            salesDetail.UpdAssemblyId1 = salesDetailWork.UpdAssemblyId1; // 更新アセンブリID1
            salesDetail.UpdAssemblyId2 = salesDetailWork.UpdAssemblyId2; // 更新アセンブリID2
            salesDetail.LogicalDeleteCode = salesDetailWork.LogicalDeleteCode; // 論理削除区分
            salesDetail.AcceptAnOrderNo = salesDetailWork.AcceptAnOrderNo; // 受注番号
            salesDetail.AcptAnOdrStatus = salesDetailWork.AcptAnOdrStatus; // 受注ステータス
            salesDetail.SalesSlipNum = salesDetailWork.SalesSlipNum; // 売上伝票番号
            salesDetail.SalesRowNo = salesDetailWork.SalesRowNo; // 売上行番号
            salesDetail.SalesRowDerivNo = salesDetailWork.SalesRowDerivNo; // 売上行番号枝番
            salesDetail.SectionCode = salesDetailWork.SectionCode; // 拠点コード
            salesDetail.SubSectionCode = salesDetailWork.SubSectionCode; // 部門コード
            salesDetail.SalesDate = salesDetailWork.SalesDate; // 売上日付
            salesDetail.CommonSeqNo = salesDetailWork.CommonSeqNo; // 共通通番
            salesDetail.SalesSlipDtlNum = salesDetailWork.SalesSlipDtlNum; // 売上明細通番
            salesDetail.AcptAnOdrStatusSrc = salesDetailWork.AcptAnOdrStatusSrc; // 受注ステータス（元）
            salesDetail.SalesSlipDtlNumSrc = salesDetailWork.SalesSlipDtlNumSrc; // 売上明細通番（元）
            salesDetail.SupplierFormalSync = salesDetailWork.SupplierFormalSync; // 仕入形式（同時）
            salesDetail.StockSlipDtlNumSync = salesDetailWork.StockSlipDtlNumSync; // 仕入明細通番（同時）
            salesDetail.SalesSlipCdDtl = salesDetailWork.SalesSlipCdDtl; // 売上伝票区分（明細）
            salesDetail.DeliGdsCmpltDueDate = salesDetailWork.DeliGdsCmpltDueDate; // 納品完了予定日
            salesDetail.GoodsKindCode = salesDetailWork.GoodsKindCode; // 商品属性
            salesDetail.GoodsSearchDivCd = salesDetailWork.GoodsSearchDivCd; // 商品検索区分
            salesDetail.GoodsMakerCd = salesDetailWork.GoodsMakerCd; // 商品メーカーコード
            salesDetail.MakerName = salesDetailWork.MakerName; // メーカー名称
            salesDetail.MakerKanaName = salesDetailWork.MakerKanaName; // メーカーカナ名称
            salesDetail.CmpltMakerKanaName = salesDetailWork.CmpltMakerKanaName; // メーカーカナ名称（一式）
            salesDetail.GoodsNo = salesDetailWork.GoodsNo; // 商品番号
            salesDetail.GoodsName = salesDetailWork.GoodsName; // 商品名称
            salesDetail.GoodsNameKana = salesDetailWork.GoodsNameKana; // 商品名称カナ
            salesDetail.GoodsLGroup = salesDetailWork.GoodsLGroup; // 商品大分類コード
            salesDetail.GoodsLGroupName = salesDetailWork.GoodsLGroupName; // 商品大分類名称
            salesDetail.GoodsMGroup = salesDetailWork.GoodsMGroup; // 商品中分類コード
            salesDetail.GoodsMGroupName = salesDetailWork.GoodsMGroupName; // 商品中分類名称
            salesDetail.BLGroupCode = salesDetailWork.BLGroupCode; // BLグループコード
            salesDetail.BLGroupName = salesDetailWork.BLGroupName; // BLグループコード名称
            salesDetail.BLGoodsCode = salesDetailWork.BLGoodsCode; // BL商品コード
            salesDetail.BLGoodsFullName = salesDetailWork.BLGoodsFullName; // BL商品コード名称（全角）
            salesDetail.EnterpriseGanreCode = salesDetailWork.EnterpriseGanreCode; // 自社分類コード
            salesDetail.EnterpriseGanreName = salesDetailWork.EnterpriseGanreName; // 自社分類名称
            salesDetail.WarehouseCode = salesDetailWork.WarehouseCode; // 倉庫コード
            salesDetail.WarehouseName = salesDetailWork.WarehouseName; // 倉庫名称
            salesDetail.WarehouseShelfNo = salesDetailWork.WarehouseShelfNo; // 倉庫棚番
            salesDetail.SalesOrderDivCd = salesDetailWork.SalesOrderDivCd; // 売上在庫取寄せ区分
            salesDetail.OpenPriceDiv = salesDetailWork.OpenPriceDiv; // オープン価格区分
            salesDetail.GoodsRateRank = salesDetailWork.GoodsRateRank; // 商品掛率ランク
            salesDetail.CustRateGrpCode = salesDetailWork.CustRateGrpCode; // 得意先掛率グループコード
            salesDetail.ListPriceRate = salesDetailWork.ListPriceRate; // 定価率
            salesDetail.RateSectPriceUnPrc = salesDetailWork.RateSectPriceUnPrc; // 掛率設定拠点（定価）
            salesDetail.RateDivLPrice = salesDetailWork.RateDivLPrice; // 掛率設定区分（定価）
            salesDetail.PriceSelectDiv = -1; // 標準価格選択区分（定価）// ADD 2013/01/24 鄧潘ハン REDMINE#34605
            salesDetail.UnPrcCalcCdLPrice = salesDetailWork.UnPrcCalcCdLPrice; // 単価算出区分（定価）
            salesDetail.PriceCdLPrice = salesDetailWork.PriceCdLPrice; // 価格区分（定価）
            salesDetail.StdUnPrcLPrice = salesDetailWork.StdUnPrcLPrice; // 基準単価（定価）
            salesDetail.FracProcUnitLPrice = salesDetailWork.FracProcUnitLPrice; // 端数処理単位（定価）
            salesDetail.FracProcLPrice = salesDetailWork.FracProcLPrice; // 端数処理（定価）
            salesDetail.ListPriceTaxIncFl = salesDetailWork.ListPriceTaxIncFl; // 定価（税込，浮動）
            salesDetail.ListPriceTaxExcFl = salesDetailWork.ListPriceTaxExcFl; // 定価（税抜，浮動）
            salesDetail.ListPriceChngCd = salesDetailWork.ListPriceChngCd; // 定価変更区分
            salesDetail.SalesRate = salesDetailWork.SalesRate; // 売価率
            salesDetail.RateSectSalUnPrc = salesDetailWork.RateSectSalUnPrc; // 掛率設定拠点（売上単価）
            salesDetail.RateDivSalUnPrc = salesDetailWork.RateDivSalUnPrc; // 掛率設定区分（売上単価）
            salesDetail.UnPrcCalcCdSalUnPrc = salesDetailWork.UnPrcCalcCdSalUnPrc; // 単価算出区分（売上単価）
            salesDetail.PriceCdSalUnPrc = salesDetailWork.PriceCdSalUnPrc; // 価格区分（売上単価）
            salesDetail.StdUnPrcSalUnPrc = salesDetailWork.StdUnPrcSalUnPrc; // 基準単価（売上単価）
            salesDetail.FracProcUnitSalUnPrc = salesDetailWork.FracProcUnitSalUnPrc; // 端数処理単位（売上単価）
            salesDetail.FracProcSalUnPrc = salesDetailWork.FracProcSalUnPrc; // 端数処理（売上単価）
            salesDetail.SalesUnPrcTaxIncFl = salesDetailWork.SalesUnPrcTaxIncFl; // 売上単価（税込，浮動）
            salesDetail.SalesUnPrcTaxExcFl = salesDetailWork.SalesUnPrcTaxExcFl; // 売上単価（税抜，浮動）
            salesDetail.SalesUnPrcChngCd = salesDetailWork.SalesUnPrcChngCd; // 売上単価変更区分
            salesDetail.CostRate = salesDetailWork.CostRate; // 原価率
            salesDetail.RateSectCstUnPrc = salesDetailWork.RateSectCstUnPrc; // 掛率設定拠点（原価単価）
            salesDetail.RateDivUnCst = salesDetailWork.RateDivUnCst; // 掛率設定区分（原価単価）
            salesDetail.UnPrcCalcCdUnCst = salesDetailWork.UnPrcCalcCdUnCst; // 単価算出区分（原価単価）
            salesDetail.PriceCdUnCst = salesDetailWork.PriceCdUnCst; // 価格区分（原価単価）
            salesDetail.StdUnPrcUnCst = salesDetailWork.StdUnPrcUnCst; // 基準単価（原価単価）
            salesDetail.FracProcUnitUnCst = salesDetailWork.FracProcUnitUnCst; // 端数処理単位（原価単価）
            salesDetail.FracProcUnCst = salesDetailWork.FracProcUnCst; // 端数処理（原価単価）
            salesDetail.SalesUnitCost = salesDetailWork.SalesUnitCost; // 原価単価
            salesDetail.SalesUnitCostChngDiv = salesDetailWork.SalesUnitCostChngDiv; // 原価単価変更区分
            salesDetail.RateBLGoodsCode = salesDetailWork.RateBLGoodsCode; // BL商品コード（掛率）
            salesDetail.RateBLGoodsName = salesDetailWork.RateBLGoodsName; // BL商品コード名称（掛率）
            salesDetail.RateGoodsRateGrpCd = salesDetailWork.RateGoodsRateGrpCd; // 商品掛率グループコード（掛率）
            salesDetail.RateGoodsRateGrpNm = salesDetailWork.RateGoodsRateGrpNm; // 商品掛率グループ名称（掛率）
            salesDetail.RateBLGroupCode = salesDetailWork.RateBLGroupCode; // BLグループコード（掛率）
            salesDetail.RateBLGroupName = salesDetailWork.RateBLGroupName; // BLグループ名称（掛率）
            salesDetail.PrtBLGoodsCode = salesDetailWork.PrtBLGoodsCode; // BL商品コード（印刷）
            salesDetail.PrtBLGoodsName = salesDetailWork.PrtBLGoodsName; // BL商品コード名称（印刷）
            salesDetail.SalesCode = salesDetailWork.SalesCode; // 販売区分コード
            salesDetail.SalesCdNm = salesDetailWork.SalesCdNm; // 販売区分名称
            salesDetail.WorkManHour = salesDetailWork.WorkManHour; // 作業工数
            salesDetail.ShipmentCnt = salesDetailWork.ShipmentCnt; // 出荷数
            salesDetail.AcceptAnOrderCnt = salesDetailWork.AcceptAnOrderCnt; // 受注数量
            salesDetail.AcptAnOdrAdjustCnt = salesDetailWork.AcptAnOdrAdjustCnt; // 受注調整数
            salesDetail.AcptAnOdrRemainCnt = salesDetailWork.AcptAnOdrRemainCnt; // 受注残数
            salesDetail.RemainCntUpdDate = salesDetailWork.RemainCntUpdDate; // 残数更新日
            salesDetail.SalesMoneyTaxInc = salesDetailWork.SalesMoneyTaxInc; // 売上金額（税込み）
            salesDetail.SalesMoneyTaxExc = salesDetailWork.SalesMoneyTaxExc; // 売上金額（税抜き）
            salesDetail.Cost = salesDetailWork.Cost; // 原価
            salesDetail.GrsProfitChkDiv = salesDetailWork.GrsProfitChkDiv; // 粗利チェック区分
            salesDetail.SalesGoodsCd = salesDetailWork.SalesGoodsCd; // 売上商品区分
            salesDetail.SalesPriceConsTax = salesDetailWork.SalesPriceConsTax; // 売上金額消費税額
            salesDetail.TaxationDivCd = salesDetailWork.TaxationDivCd; // 課税区分
            salesDetail.PartySlipNumDtl = salesDetailWork.PartySlipNumDtl; // 相手先伝票番号（明細）
            salesDetail.DtlNote = salesDetailWork.DtlNote; // 明細備考
            salesDetail.SupplierCd = salesDetailWork.SupplierCd; // 仕入先コード
            salesDetail.SupplierSnm = salesDetailWork.SupplierSnm; // 仕入先略称
            salesDetail.OrderNumber = salesDetailWork.OrderNumber; // 発注番号
            salesDetail.WayToOrder = salesDetailWork.WayToOrder; // 注文方法
            salesDetail.SlipMemo1 = salesDetailWork.SlipMemo1; // 伝票メモ１
            salesDetail.SlipMemo2 = salesDetailWork.SlipMemo2; // 伝票メモ２
            salesDetail.SlipMemo3 = salesDetailWork.SlipMemo3; // 伝票メモ３
            salesDetail.InsideMemo1 = salesDetailWork.InsideMemo1; // 社内メモ１
            salesDetail.InsideMemo2 = salesDetailWork.InsideMemo2; // 社内メモ２
            salesDetail.InsideMemo3 = salesDetailWork.InsideMemo3; // 社内メモ３
            salesDetail.BfListPrice = salesDetailWork.BfListPrice; // 変更前定価
            salesDetail.BfSalesUnitPrice = salesDetailWork.BfSalesUnitPrice; // 変更前売価
            salesDetail.BfUnitCost = salesDetailWork.BfUnitCost; // 変更前原価
            salesDetail.CmpltSalesRowNo = salesDetailWork.CmpltSalesRowNo; // 一式明細番号
            salesDetail.CmpltGoodsMakerCd = salesDetailWork.CmpltGoodsMakerCd; // メーカーコード（一式）
            salesDetail.CmpltMakerName = salesDetailWork.CmpltMakerName; // メーカー名称（一式）
            salesDetail.CmpltGoodsName = salesDetailWork.CmpltGoodsName; // 商品名称（一式）
            salesDetail.CmpltShipmentCnt = salesDetailWork.CmpltShipmentCnt; // 数量（一式）
            salesDetail.CmpltSalesUnPrcFl = salesDetailWork.CmpltSalesUnPrcFl; // 売上単価（一式）
            salesDetail.CmpltSalesMoney = salesDetailWork.CmpltSalesMoney; // 売上金額（一式）
            salesDetail.CmpltSalesUnitCost = salesDetailWork.CmpltSalesUnitCost; // 原価単価（一式）
            salesDetail.CmpltCost = salesDetailWork.CmpltCost; // 原価金額（一式）
            salesDetail.CmpltPartySalSlNum = salesDetailWork.CmpltPartySalSlNum; // 相手先伝票番号（一式）
            salesDetail.CmpltNote = salesDetailWork.CmpltNote; // 一式備考
            salesDetail.PrtGoodsNo = salesDetailWork.PrtGoodsNo; // 印刷用品番
            salesDetail.PrtMakerCode = salesDetailWork.PrtMakerCode; // 印刷用メーカーコード
            salesDetail.PrtMakerName = salesDetailWork.PrtMakerName; // 印刷用メーカー名称
            salesDetail.DtlRelationGuid = salesDetailWork.DtlRelationGuid; // 共通キー
            //salesDetail.CarRelationGuid = salesDetailWork.CarRelationGuid; // 車両情報共通キー
            //>>>2010/02/26
            salesDetail.CampaignCode = salesDetailWork.CampaignCode;
            salesDetail.CampaignName = salesDetailWork.CampaignName;
            salesDetail.GoodsDivCd = salesDetailWork.GoodsDivCd;
            salesDetail.AnswerDelivDate = salesDetailWork.AnswerDelivDate;
            salesDetail.RecycleDiv = salesDetailWork.RecycleDiv;
            salesDetail.RecycleDivNm = salesDetailWork.RecycleDivNm;
            salesDetail.WayToAcptOdr = salesDetailWork.WayToAcptOdr;
            //<<<2010/02/26
            salesDetail.AutoAnswerDivSCM = salesDetailWork.AutoAnswerDivSCM;//自動回答区分 zhubj
            salesDetail.AcceptOrOrderKind = salesDetailWork.AcceptOrOrderKind;//受発注種別 //add 2011/08/23
            salesDetail.InquiryNumber = salesDetailWork.InquiryNumber;//問合せ番号 //add 2011/08/23
            salesDetail.InqRowNumber = salesDetailWork.InqRowNumber;//問合せ行番号 //add 2011/08/23
            // 2012/01/16 Add >>>
            salesDetail.GoodsSpecialNote = salesDetailWork.GoodsSpecialNote; // 特記事項
            // 2012/01/16 Add <<<
            //>>>2012/05/02
            salesDetail.RentSyncStockDate = salesDetailWork.RentSyncStockDate;
            salesDetail.RentSyncSupplier = salesDetailWork.RentSyncSupplier;
            salesDetail.RentSyncSupSlipNo = salesDetailWork.RentSyncSupSlipNo;
            //<<<2012/05/02

            return salesDetail;
        }

        /// <summary>
        /// UIData→PramData移項処理
        /// </summary>
        /// <param name="salesSlip">売上データオブジェクト</param>
        /// <returns>売上データワークオブジェクト</returns>
        /// <remarks>
        /// <br>Update Note: 2011/12/15 tianjw</br>
        /// <br>             Redmine#27390 拠点管理/売上日のチェック</br>
        /// </remarks>
        private static SalesSlipWork ParamDataFromUIDataProc(SalesSlip salesSlip)
        {
            SalesSlipWork salesSlipWork = new SalesSlipWork();

            salesSlipWork.CreateDateTime = salesSlip.CreateDateTime; // 作成日時
            salesSlipWork.UpdateDateTime = salesSlip.UpdateDateTime; // 更新日時
            salesSlipWork.EnterpriseCode = salesSlip.EnterpriseCode; // 企業コード
            salesSlipWork.FileHeaderGuid = salesSlip.FileHeaderGuid; // GUID
            salesSlipWork.UpdEmployeeCode = salesSlip.UpdEmployeeCode; // 更新従業員コード
            salesSlipWork.UpdAssemblyId1 = salesSlip.UpdAssemblyId1; // 更新アセンブリID1
            salesSlipWork.UpdAssemblyId2 = salesSlip.UpdAssemblyId2; // 更新アセンブリID2
            salesSlipWork.LogicalDeleteCode = salesSlip.LogicalDeleteCode; // 論理削除区分
            salesSlipWork.AcptAnOdrStatus = salesSlip.AcptAnOdrStatus; // 受注ステータス
            salesSlipWork.SalesSlipNum = salesSlip.SalesSlipNum; // 売上伝票番号
            salesSlipWork.SectionCode = salesSlip.SectionCode; // 拠点コード
            salesSlipWork.SubSectionCode = salesSlip.SubSectionCode; // 部門コード
            salesSlipWork.DebitNoteDiv = salesSlip.DebitNoteDiv; // 赤伝区分
            salesSlipWork.DebitNLnkSalesSlNum = salesSlip.DebitNLnkSalesSlNum; // 赤黒連結売上伝票番号
            salesSlipWork.SalesSlipCd = salesSlip.SalesSlipCd; // 売上伝票区分
            salesSlipWork.SalesGoodsCd = salesSlip.SalesGoodsCd; // 売上商品区分
            salesSlipWork.AccRecDivCd = salesSlip.AccRecDivCd; // 売掛区分
            salesSlipWork.SalesInpSecCd = salesSlip.SalesInpSecCd; // 売上入力拠点コード
            salesSlipWork.DemandAddUpSecCd = salesSlip.DemandAddUpSecCd; // 請求計上拠点コード
            salesSlipWork.ResultsAddUpSecCd = salesSlip.ResultsAddUpSecCd; // 実績計上拠点コード
            salesSlipWork.UpdateSecCd = salesSlip.UpdateSecCd; // 更新拠点コード
            salesSlipWork.SalesSlipUpdateCd = salesSlip.SalesSlipUpdateCd; // 売上伝票更新区分
            salesSlipWork.SearchSlipDate = salesSlip.SearchSlipDate; // 伝票検索日付
            salesSlipWork.ShipmentDay = salesSlip.ShipmentDay; // 出荷日付
            salesSlipWork.SalesDate = salesSlip.SalesDate; // 売上日付
            salesSlipWork.PreSalesDate = salesSlip.PreSalesDate; // 前回売上日付 // ADD 2011/12/15
            salesSlipWork.AddUpADate = salesSlip.AddUpADate; // 計上日付
            salesSlipWork.DelayPaymentDiv = salesSlip.DelayPaymentDiv; // 来勘区分
            salesSlipWork.EstimateFormNo = salesSlip.EstimateFormNo; // 見積書番号
            salesSlipWork.EstimateDivide = salesSlip.EstimateDivide; // 見積区分
            salesSlipWork.InputAgenCd = salesSlip.InputAgenCd; // 入力担当者コード
            salesSlipWork.InputAgenNm = salesSlip.InputAgenNm; // 入力担当者名称
            salesSlipWork.SalesInputCode = salesSlip.SalesInputCode; // 売上入力者コード
            salesSlipWork.SalesInputName = salesSlip.SalesInputName; // 売上入力者名称
            salesSlipWork.FrontEmployeeCd = salesSlip.FrontEmployeeCd; // 受付従業員コード
            salesSlipWork.FrontEmployeeNm = salesSlip.FrontEmployeeNm; // 受付従業員名称
            salesSlipWork.SalesEmployeeCd = salesSlip.SalesEmployeeCd; // 販売従業員コード
            salesSlipWork.SalesEmployeeNm = salesSlip.SalesEmployeeNm; // 販売従業員名称
            salesSlipWork.TotalAmountDispWayCd = salesSlip.TotalAmountDispWayCd; // 総額表示方法区分
            salesSlipWork.TtlAmntDispRateApy = salesSlip.TtlAmntDispRateApy; // 総額表示掛率適用区分
            salesSlipWork.SalesTotalTaxInc = salesSlip.SalesTotalTaxInc; // 売上伝票合計（税込み）
            salesSlipWork.SalesTotalTaxExc = salesSlip.SalesTotalTaxExc; // 売上伝票合計（税抜き）
            salesSlipWork.SalesPrtTotalTaxInc = salesSlip.SalesPrtTotalTaxInc; // 売上部品合計（税込み）
            salesSlipWork.SalesPrtTotalTaxExc = salesSlip.SalesPrtTotalTaxExc; // 売上部品合計（税抜き）
            salesSlipWork.SalesWorkTotalTaxInc = salesSlip.SalesWorkTotalTaxInc; // 売上作業合計（税込み）
            salesSlipWork.SalesWorkTotalTaxExc = salesSlip.SalesWorkTotalTaxExc; // 売上作業合計（税抜き）
            salesSlipWork.SalesSubtotalTaxInc = salesSlip.SalesSubtotalTaxInc; // 売上小計（税込み）
            salesSlipWork.SalesSubtotalTaxExc = salesSlip.SalesSubtotalTaxExc; // 売上小計（税抜き）
            salesSlipWork.SalesPrtSubttlInc = salesSlip.SalesPrtSubttlInc; // 売上部品小計（税込み）
            salesSlipWork.SalesPrtSubttlExc = salesSlip.SalesPrtSubttlExc; // 売上部品小計（税抜き）
            salesSlipWork.SalesWorkSubttlInc = salesSlip.SalesWorkSubttlInc; // 売上作業小計（税込み）
            salesSlipWork.SalesWorkSubttlExc = salesSlip.SalesWorkSubttlExc; // 売上作業小計（税抜き）
            salesSlipWork.SalesNetPrice = salesSlip.SalesNetPrice; // 売上正価金額
            salesSlipWork.SalesSubtotalTax = salesSlip.SalesSubtotalTax; // 売上小計（税）
            salesSlipWork.ItdedSalesOutTax = salesSlip.ItdedSalesOutTax; // 売上外税対象額
            salesSlipWork.ItdedSalesInTax = salesSlip.ItdedSalesInTax; // 売上内税対象額
            salesSlipWork.SalSubttlSubToTaxFre = salesSlip.SalSubttlSubToTaxFre; // 売上小計非課税対象額
            salesSlipWork.SalesOutTax = salesSlip.SalesOutTax; // 売上金額消費税額（外税）
            salesSlipWork.SalAmntConsTaxInclu = salesSlip.SalAmntConsTaxInclu; // 売上金額消費税額（内税）
            salesSlipWork.SalesDisTtlTaxExc = salesSlip.SalesDisTtlTaxExc; // 売上値引金額計（税抜き）
            salesSlipWork.ItdedSalesDisOutTax = salesSlip.ItdedSalesDisOutTax; // 売上値引外税対象額合計
            salesSlipWork.ItdedSalesDisInTax = salesSlip.ItdedSalesDisInTax; // 売上値引内税対象額合計
            salesSlipWork.ItdedPartsDisOutTax = salesSlip.ItdedPartsDisOutTax; // 部品値引対象額合計（税抜き）
            salesSlipWork.ItdedPartsDisInTax = salesSlip.ItdedPartsDisInTax; // 部品値引対象額合計（税込み）
            salesSlipWork.ItdedWorkDisOutTax = salesSlip.ItdedWorkDisOutTax; // 作業値引対象額合計（税抜き）
            salesSlipWork.ItdedWorkDisInTax = salesSlip.ItdedWorkDisInTax; // 作業値引対象額合計（税込み）
            salesSlipWork.ItdedSalesDisTaxFre = salesSlip.ItdedSalesDisTaxFre; // 売上値引非課税対象額合計
            salesSlipWork.SalesDisOutTax = salesSlip.SalesDisOutTax; // 売上値引消費税額（外税）
            salesSlipWork.SalesDisTtlTaxInclu = salesSlip.SalesDisTtlTaxInclu; // 売上値引消費税額（内税）
            salesSlipWork.PartsDiscountRate = salesSlip.PartsDiscountRate; // 部品値引率
            salesSlipWork.RavorDiscountRate = salesSlip.RavorDiscountRate; // 工賃値引率
            salesSlipWork.TotalCost = salesSlip.TotalCost; // 原価金額計
            salesSlipWork.ConsTaxLayMethod = salesSlip.ConsTaxLayMethod; // 消費税転嫁方式
            salesSlipWork.ConsTaxRate = salesSlip.ConsTaxRate; // 消費税税率
            salesSlipWork.FractionProcCd = salesSlip.FractionProcCd; // 端数処理区分
            salesSlipWork.AccRecConsTax = salesSlip.AccRecConsTax; // 売掛消費税
            salesSlipWork.AutoDepositCd = salesSlip.AutoDepositCd; // 自動入金区分
            salesSlipWork.AutoDepositNoteDiv = salesSlip.AutoDepositNoteDiv; // 自動入金備考区分 // ADD 2013/01/18 田建委 Redmine#33797
            salesSlipWork.AutoDepositSlipNo = salesSlip.AutoDepositSlipNo; // 自動入金伝票番号
            salesSlipWork.DepositAllowanceTtl = salesSlip.DepositAllowanceTtl; // 入金引当合計額
            salesSlipWork.DepositAlwcBlnce = salesSlip.DepositAlwcBlnce; // 入金引当残高
            salesSlipWork.ClaimCode = salesSlip.ClaimCode; // 請求先コード
            salesSlipWork.ClaimSnm = salesSlip.ClaimSnm; // 請求先略称
            salesSlipWork.CustomerCode = salesSlip.CustomerCode; // 得意先コード
            salesSlipWork.CustomerName = salesSlip.CustomerName; // 得意先名称
            salesSlipWork.CustomerName2 = salesSlip.CustomerName2; // 得意先名称2
            salesSlipWork.CustomerSnm = salesSlip.CustomerSnm; // 得意先略称
            salesSlipWork.HonorificTitle = salesSlip.HonorificTitle; // 敬称
            salesSlipWork.OutputNameCode = salesSlip.OutputNameCode; // 諸口コード
            salesSlipWork.OutputName = salesSlip.OutputName; // 諸口名称
            salesSlipWork.CustSlipNo = salesSlip.CustSlipNo; // 得意先伝票番号
            salesSlipWork.SlipAddressDiv = salesSlip.SlipAddressDiv; // 伝票住所区分
            salesSlipWork.AddresseeCode = salesSlip.AddresseeCode; // 納品先コード
            salesSlipWork.AddresseeName = salesSlip.AddresseeName; // 納品先名称
            salesSlipWork.AddresseeName2 = salesSlip.AddresseeName2; // 納品先名称2
            salesSlipWork.AddresseePostNo = salesSlip.AddresseePostNo; // 納品先郵便番号
            salesSlipWork.AddresseeAddr1 = salesSlip.AddresseeAddr1; // 納品先住所1(都道府県市区郡・町村・字)
            salesSlipWork.AddresseeAddr3 = salesSlip.AddresseeAddr3; // 納品先住所3(番地)
            salesSlipWork.AddresseeAddr4 = salesSlip.AddresseeAddr4; // 納品先住所4(アパート名称)
            salesSlipWork.AddresseeTelNo = salesSlip.AddresseeTelNo; // 納品先電話番号
            salesSlipWork.AddresseeFaxNo = salesSlip.AddresseeFaxNo; // 納品先FAX番号
            salesSlipWork.PartySaleSlipNum = salesSlip.PartySaleSlipNum; // 相手先伝票番号
            salesSlipWork.SlipNote = salesSlip.SlipNote; // 伝票備考
            salesSlipWork.SlipNote2 = salesSlip.SlipNote2; // 伝票備考２
            salesSlipWork.SlipNote3 = salesSlip.SlipNote3; // 伝票備考３
            salesSlipWork.RetGoodsReasonDiv = salesSlip.RetGoodsReasonDiv; // 返品理由コード
            salesSlipWork.RetGoodsReason = salesSlip.RetGoodsReason; // 返品理由
            salesSlipWork.RegiProcDate = salesSlip.RegiProcDate; // レジ処理日
            salesSlipWork.CashRegisterNo = salesSlip.CashRegisterNo; // レジ番号
            salesSlipWork.PosReceiptNo = salesSlip.PosReceiptNo; // POSレシート番号
            salesSlipWork.DetailRowCount = salesSlip.DetailRowCount; // 明細行数
            salesSlipWork.EdiSendDate = salesSlip.EdiSendDate; // ＥＤＩ送信日
            salesSlipWork.EdiTakeInDate = salesSlip.EdiTakeInDate; // ＥＤＩ取込日
            salesSlipWork.UoeRemark1 = salesSlip.UoeRemark1; // ＵＯＥリマーク１
            salesSlipWork.UoeRemark2 = salesSlip.UoeRemark2; // ＵＯＥリマーク２
            salesSlipWork.SlipPrintDivCd = salesSlip.SlipPrintDivCd; // 伝票発行区分
            salesSlipWork.SlipPrintFinishCd = salesSlip.SlipPrintFinishCd; // 伝票発行済区分
            salesSlipWork.SalesSlipPrintDate = salesSlip.SalesSlipPrintDate; // 売上伝票発行日
            salesSlipWork.BusinessTypeCode = salesSlip.BusinessTypeCode; // 業種コード
            salesSlipWork.BusinessTypeName = salesSlip.BusinessTypeName; // 業種名称
            salesSlipWork.OrderNumber = salesSlip.OrderNumber; // 発注番号
            salesSlipWork.DeliveredGoodsDiv = salesSlip.DeliveredGoodsDiv; // 納品区分
            salesSlipWork.DeliveredGoodsDivNm = salesSlip.DeliveredGoodsDivNm; // 納品区分名称
            salesSlipWork.SalesAreaCode = salesSlip.SalesAreaCode; // 販売エリアコード
            salesSlipWork.SalesAreaName = salesSlip.SalesAreaName; // 販売エリア名称
            salesSlipWork.ReconcileFlag = salesSlip.ReconcileFlag; // 消込フラグ
            salesSlipWork.SlipPrtSetPaperId = salesSlip.SlipPrtSetPaperId; // 伝票印刷設定用帳票ID
            salesSlipWork.CompleteCd = salesSlip.CompleteCd; // 一式伝票区分
            salesSlipWork.SalesPriceFracProcCd = salesSlip.SalesPriceFracProcCd; // 売上金額端数処理区分
            salesSlipWork.StockGoodsTtlTaxExc = salesSlip.StockGoodsTtlTaxExc; // 在庫商品合計金額（税抜）
            salesSlipWork.PureGoodsTtlTaxExc = salesSlip.PureGoodsTtlTaxExc; // 純正商品合計金額（税抜）
            salesSlipWork.ListPricePrintDiv = salesSlip.ListPricePrintDiv; // 定価印刷区分
            salesSlipWork.EraNameDispCd1 = salesSlip.EraNameDispCd1; // 元号表示区分１
            salesSlipWork.EstimaTaxDivCd = salesSlip.EstimaTaxDivCd; // 見積消費税区分
            salesSlipWork.EstimateFormPrtCd = salesSlip.EstimateFormPrtCd; // 見積書印刷区分
            salesSlipWork.EstimateSubject = salesSlip.EstimateSubject; // 見積件名
            salesSlipWork.Footnotes1 = salesSlip.Footnotes1; // 脚注１
            salesSlipWork.Footnotes2 = salesSlip.Footnotes2; // 脚注２
            salesSlipWork.EstimateTitle1 = salesSlip.EstimateTitle1; // 見積タイトル１
            salesSlipWork.EstimateTitle2 = salesSlip.EstimateTitle2; // 見積タイトル２
            salesSlipWork.EstimateTitle3 = salesSlip.EstimateTitle3; // 見積タイトル３
            salesSlipWork.EstimateTitle4 = salesSlip.EstimateTitle4; // 見積タイトル４
            salesSlipWork.EstimateTitle5 = salesSlip.EstimateTitle5; // 見積タイトル５
            salesSlipWork.EstimateNote1 = salesSlip.EstimateNote1; // 見積備考１
            salesSlipWork.EstimateNote2 = salesSlip.EstimateNote2; // 見積備考２
            salesSlipWork.EstimateNote3 = salesSlip.EstimateNote3; // 見積備考３
            salesSlipWork.EstimateNote4 = salesSlip.EstimateNote4; // 見積備考４
            salesSlipWork.EstimateNote5 = salesSlip.EstimateNote5; // 見積備考５
            salesSlipWork.EstimateValidityDate = salesSlip.EstimateValidityDate; // 見積有効期限
            salesSlipWork.PartsNoPrtCd = salesSlip.PartsNoPrtCd; // 品番印字区分
            salesSlipWork.OptionPringDivCd = salesSlip.OptionPringDivCd; // オプション印字区分
            salesSlipWork.RateUseCode = salesSlip.RateUseCode; // 掛率使用区分
            //salesSlipWork.InputMode = salesSlip.InputMode; // 入力モード
            //salesSlipWork.SalesSlipDisplay = salesSlip.SalesSlipDisplay; // 売上伝票区分(画面表示用)
            //salesSlipWork.AcptAnOdrStatusDisplay = salesSlip.AcptAnOdrStatusDisplay; // 受注ステータス
            //salesSlipWork.CustRateGrpCode = salesSlip.CustRateGrpCode; // 得意先掛率グループコード
            //salesSlipWork.ClaimName = salesSlip.ClaimName; // 請求先名称
            //salesSlipWork.ClaimName2 = salesSlip.ClaimName2; // 請求先名称２
            //salesSlipWork.CreditMngCode = salesSlip.CreditMngCode; // 与信管理区分
            //salesSlipWork.TotalDay = salesSlip.TotalDay; // 締日
            //salesSlipWork.NTimeCalcStDate = salesSlip.NTimeCalcStDate; // 次回勘定開始日
            //salesSlipWork.TotalMoneyForGrossProfit = salesSlip.TotalMoneyForGrossProfit; // 粗利計算用売上金額
            //salesSlipWork.AcceptAnOrderDate = salesSlip.AcceptAnOrderDate; // 受注日
            //salesSlipWork.SectionName = salesSlip.SectionName; // 拠点名称
            //salesSlipWork.SubSectionName = salesSlip.SubSectionName; // 部門名称
            //salesSlipWork.CarMngDivCd = salesSlip.CarMngDivCd; // 車輌管理区分
            //salesSlipWork.SearchMode = salesSlip.SearchMode; // 部品検索モード
            //salesSlipWork.SearchCarMode = salesSlip.SearchCarMode; // 車両検索モード
            //salesSlipWork.CustOrderNoDispDiv = salesSlip.CustOrderNoDispDiv; // 得意先注番表示区分

            return salesSlipWork;
        }

        /// <summary>
        /// UIData→PramData移項処理
        /// </summary>
        /// <param name="salesDetail">売上明細データオブジェクト</param>
        /// <returns>売上明細データワークオブジェクト</returns>
        private static SalesDetailWork ParamDataFromUIDataProc(SalesDetail salesDetail)
        {
            SalesDetailWork salesDetailWork = new SalesDetailWork();

            salesDetailWork.CreateDateTime = salesDetail.CreateDateTime; // 作成日時
            salesDetailWork.UpdateDateTime = salesDetail.UpdateDateTime; // 更新日時
            salesDetailWork.EnterpriseCode = salesDetail.EnterpriseCode; // 企業コード
            salesDetailWork.FileHeaderGuid = salesDetail.FileHeaderGuid; // GUID
            salesDetailWork.UpdEmployeeCode = salesDetail.UpdEmployeeCode; // 更新従業員コード
            salesDetailWork.UpdAssemblyId1 = salesDetail.UpdAssemblyId1; // 更新アセンブリID1
            salesDetailWork.UpdAssemblyId2 = salesDetail.UpdAssemblyId2; // 更新アセンブリID2
            salesDetailWork.LogicalDeleteCode = salesDetail.LogicalDeleteCode; // 論理削除区分
            salesDetailWork.AcceptAnOrderNo = salesDetail.AcceptAnOrderNo; // 受注番号
            salesDetailWork.AcptAnOdrStatus = salesDetail.AcptAnOdrStatus; // 受注ステータス
            salesDetailWork.SalesSlipNum = salesDetail.SalesSlipNum; // 売上伝票番号
            salesDetailWork.SalesRowNo = salesDetail.SalesRowNo; // 売上行番号
            salesDetailWork.SalesRowDerivNo = salesDetail.SalesRowDerivNo; // 売上行番号枝番
            salesDetailWork.SectionCode = salesDetail.SectionCode; // 拠点コード
            salesDetailWork.SubSectionCode = salesDetail.SubSectionCode; // 部門コード
            salesDetailWork.SalesDate = salesDetail.SalesDate; // 売上日付
            salesDetailWork.CommonSeqNo = salesDetail.CommonSeqNo; // 共通通番
            salesDetailWork.SalesSlipDtlNum = salesDetail.SalesSlipDtlNum; // 売上明細通番
            salesDetailWork.AcptAnOdrStatusSrc = salesDetail.AcptAnOdrStatusSrc; // 受注ステータス（元）
            salesDetailWork.SalesSlipDtlNumSrc = salesDetail.SalesSlipDtlNumSrc; // 売上明細通番（元）
            salesDetailWork.SupplierFormalSync = salesDetail.SupplierFormalSync; // 仕入形式（同時）
            salesDetailWork.StockSlipDtlNumSync = salesDetail.StockSlipDtlNumSync; // 仕入明細通番（同時）
            salesDetailWork.SalesSlipCdDtl = salesDetail.SalesSlipCdDtl; // 売上伝票区分（明細）
            salesDetailWork.DeliGdsCmpltDueDate = salesDetail.DeliGdsCmpltDueDate; // 納品完了予定日
            salesDetailWork.GoodsKindCode = salesDetail.GoodsKindCode; // 商品属性
            salesDetailWork.GoodsSearchDivCd = salesDetail.GoodsSearchDivCd; // 商品検索区分
            salesDetailWork.GoodsMakerCd = salesDetail.GoodsMakerCd; // 商品メーカーコード
            salesDetailWork.MakerName = salesDetail.MakerName; // メーカー名称
            salesDetailWork.MakerKanaName = salesDetail.MakerKanaName; // メーカーカナ名称
            salesDetailWork.CmpltMakerKanaName = salesDetail.CmpltMakerKanaName; // メーカーカナ名称（一式）
            salesDetailWork.GoodsNo = salesDetail.GoodsNo; // 商品番号
            salesDetailWork.GoodsName = salesDetail.GoodsName; // 商品名称
            salesDetailWork.GoodsNameKana = salesDetail.GoodsNameKana; // 商品名称カナ
            salesDetailWork.GoodsLGroup = salesDetail.GoodsLGroup; // 商品大分類コード
            salesDetailWork.GoodsLGroupName = salesDetail.GoodsLGroupName; // 商品大分類名称
            salesDetailWork.GoodsMGroup = salesDetail.GoodsMGroup; // 商品中分類コード
            salesDetailWork.GoodsMGroupName = salesDetail.GoodsMGroupName; // 商品中分類名称
            salesDetailWork.BLGroupCode = salesDetail.BLGroupCode; // BLグループコード
            salesDetailWork.BLGroupName = salesDetail.BLGroupName; // BLグループコード名称
            salesDetailWork.BLGoodsCode = salesDetail.BLGoodsCode; // BL商品コード
            salesDetailWork.BLGoodsFullName = salesDetail.BLGoodsFullName; // BL商品コード名称（全角）
            salesDetailWork.EnterpriseGanreCode = salesDetail.EnterpriseGanreCode; // 自社分類コード
            salesDetailWork.EnterpriseGanreName = salesDetail.EnterpriseGanreName; // 自社分類名称
            salesDetailWork.WarehouseCode = salesDetail.WarehouseCode; // 倉庫コード
            salesDetailWork.WarehouseName = salesDetail.WarehouseName; // 倉庫名称
            salesDetailWork.WarehouseShelfNo = salesDetail.WarehouseShelfNo; // 倉庫棚番
            salesDetailWork.SalesOrderDivCd = salesDetail.SalesOrderDivCd; // 売上在庫取寄せ区分
            salesDetailWork.OpenPriceDiv = salesDetail.OpenPriceDiv; // オープン価格区分
            salesDetailWork.GoodsRateRank = salesDetail.GoodsRateRank; // 商品掛率ランク
            salesDetailWork.CustRateGrpCode = salesDetail.CustRateGrpCode; // 得意先掛率グループコード
            salesDetailWork.ListPriceRate = salesDetail.ListPriceRate; // 定価率
            salesDetailWork.RateSectPriceUnPrc = salesDetail.RateSectPriceUnPrc; // 掛率設定拠点（定価）
            salesDetailWork.RateDivLPrice = salesDetail.RateDivLPrice; // 掛率設定区分（定価）
            salesDetailWork.UnPrcCalcCdLPrice = salesDetail.UnPrcCalcCdLPrice; // 単価算出区分（定価）
            salesDetailWork.PriceCdLPrice = salesDetail.PriceCdLPrice; // 価格区分（定価）
            salesDetailWork.StdUnPrcLPrice = salesDetail.StdUnPrcLPrice; // 基準単価（定価）
            salesDetailWork.FracProcUnitLPrice = salesDetail.FracProcUnitLPrice; // 端数処理単位（定価）
            salesDetailWork.FracProcLPrice = salesDetail.FracProcLPrice; // 端数処理（定価）
            salesDetailWork.ListPriceTaxIncFl = salesDetail.ListPriceTaxIncFl; // 定価（税込，浮動）
            salesDetailWork.ListPriceTaxExcFl = salesDetail.ListPriceTaxExcFl; // 定価（税抜，浮動）
            salesDetailWork.ListPriceChngCd = salesDetail.ListPriceChngCd; // 定価変更区分
            salesDetailWork.SalesRate = salesDetail.SalesRate; // 売価率
            salesDetailWork.RateSectSalUnPrc = salesDetail.RateSectSalUnPrc; // 掛率設定拠点（売上単価）
            salesDetailWork.RateDivSalUnPrc = salesDetail.RateDivSalUnPrc; // 掛率設定区分（売上単価）
            salesDetailWork.UnPrcCalcCdSalUnPrc = salesDetail.UnPrcCalcCdSalUnPrc; // 単価算出区分（売上単価）
            salesDetailWork.PriceCdSalUnPrc = salesDetail.PriceCdSalUnPrc; // 価格区分（売上単価）
            salesDetailWork.StdUnPrcSalUnPrc = salesDetail.StdUnPrcSalUnPrc; // 基準単価（売上単価）
            salesDetailWork.FracProcUnitSalUnPrc = salesDetail.FracProcUnitSalUnPrc; // 端数処理単位（売上単価）
            salesDetailWork.FracProcSalUnPrc = salesDetail.FracProcSalUnPrc; // 端数処理（売上単価）
            salesDetailWork.SalesUnPrcTaxIncFl = salesDetail.SalesUnPrcTaxIncFl; // 売上単価（税込，浮動）
            salesDetailWork.SalesUnPrcTaxExcFl = salesDetail.SalesUnPrcTaxExcFl; // 売上単価（税抜，浮動）
            salesDetailWork.SalesUnPrcChngCd = salesDetail.SalesUnPrcChngCd; // 売上単価変更区分
            salesDetailWork.CostRate = salesDetail.CostRate; // 原価率
            salesDetailWork.RateSectCstUnPrc = salesDetail.RateSectCstUnPrc; // 掛率設定拠点（原価単価）
            salesDetailWork.RateDivUnCst = salesDetail.RateDivUnCst; // 掛率設定区分（原価単価）
            salesDetailWork.UnPrcCalcCdUnCst = salesDetail.UnPrcCalcCdUnCst; // 単価算出区分（原価単価）
            salesDetailWork.PriceCdUnCst = salesDetail.PriceCdUnCst; // 価格区分（原価単価）
            salesDetailWork.StdUnPrcUnCst = salesDetail.StdUnPrcUnCst; // 基準単価（原価単価）
            salesDetailWork.FracProcUnitUnCst = salesDetail.FracProcUnitUnCst; // 端数処理単位（原価単価）
            salesDetailWork.FracProcUnCst = salesDetail.FracProcUnCst; // 端数処理（原価単価）
            salesDetailWork.SalesUnitCost = salesDetail.SalesUnitCost; // 原価単価
            salesDetailWork.SalesUnitCostChngDiv = salesDetail.SalesUnitCostChngDiv; // 原価単価変更区分
            salesDetailWork.RateBLGoodsCode = salesDetail.RateBLGoodsCode; // BL商品コード（掛率）
            salesDetailWork.RateBLGoodsName = salesDetail.RateBLGoodsName; // BL商品コード名称（掛率）
            salesDetailWork.RateGoodsRateGrpCd = salesDetail.RateGoodsRateGrpCd; // 商品掛率グループコード（掛率）
            salesDetailWork.RateGoodsRateGrpNm = salesDetail.RateGoodsRateGrpNm; // 商品掛率グループ名称（掛率）
            salesDetailWork.RateBLGroupCode = salesDetail.RateBLGroupCode; // BLグループコード（掛率）
            salesDetailWork.RateBLGroupName = salesDetail.RateBLGroupName; // BLグループ名称（掛率）
            salesDetailWork.PrtBLGoodsCode = salesDetail.PrtBLGoodsCode; // BL商品コード（印刷）
            salesDetailWork.PrtBLGoodsName = salesDetail.PrtBLGoodsName; // BL商品コード名称（印刷）
            salesDetailWork.SalesCode = salesDetail.SalesCode; // 販売区分コード
            salesDetailWork.SalesCdNm = salesDetail.SalesCdNm; // 販売区分名称
            salesDetailWork.WorkManHour = salesDetail.WorkManHour; // 作業工数
            salesDetailWork.ShipmentCnt = salesDetail.ShipmentCnt; // 出荷数
            salesDetailWork.AcceptAnOrderCnt = salesDetail.AcceptAnOrderCnt; // 受注数量
            salesDetailWork.AcptAnOdrAdjustCnt = salesDetail.AcptAnOdrAdjustCnt; // 受注調整数
            salesDetailWork.AcptAnOdrRemainCnt = salesDetail.AcptAnOdrRemainCnt; // 受注残数
            salesDetailWork.RemainCntUpdDate = salesDetail.RemainCntUpdDate; // 残数更新日
            salesDetailWork.SalesMoneyTaxInc = salesDetail.SalesMoneyTaxInc; // 売上金額（税込み）
            salesDetailWork.SalesMoneyTaxExc = salesDetail.SalesMoneyTaxExc; // 売上金額（税抜き）
            salesDetailWork.Cost = salesDetail.Cost; // 原価
            salesDetailWork.GrsProfitChkDiv = salesDetail.GrsProfitChkDiv; // 粗利チェック区分
            salesDetailWork.SalesGoodsCd = salesDetail.SalesGoodsCd; // 売上商品区分
            salesDetailWork.SalesPriceConsTax = salesDetail.SalesPriceConsTax; // 売上金額消費税額
            salesDetailWork.TaxationDivCd = salesDetail.TaxationDivCd; // 課税区分
            salesDetailWork.PartySlipNumDtl = salesDetail.PartySlipNumDtl; // 相手先伝票番号（明細）
            salesDetailWork.DtlNote = salesDetail.DtlNote; // 明細備考
            salesDetailWork.SupplierCd = salesDetail.SupplierCd; // 仕入先コード
            salesDetailWork.SupplierSnm = salesDetail.SupplierSnm; // 仕入先略称
            salesDetailWork.OrderNumber = salesDetail.OrderNumber; // 発注番号
            salesDetailWork.WayToOrder = salesDetail.WayToOrder; // 注文方法
            salesDetailWork.SlipMemo1 = salesDetail.SlipMemo1; // 伝票メモ１
            salesDetailWork.SlipMemo2 = salesDetail.SlipMemo2; // 伝票メモ２
            salesDetailWork.SlipMemo3 = salesDetail.SlipMemo3; // 伝票メモ３
            salesDetailWork.InsideMemo1 = salesDetail.InsideMemo1; // 社内メモ１
            salesDetailWork.InsideMemo2 = salesDetail.InsideMemo2; // 社内メモ２
            salesDetailWork.InsideMemo3 = salesDetail.InsideMemo3; // 社内メモ３
            salesDetailWork.BfListPrice = salesDetail.BfListPrice; // 変更前定価
            salesDetailWork.BfSalesUnitPrice = salesDetail.BfSalesUnitPrice; // 変更前売価
            salesDetailWork.BfUnitCost = salesDetail.BfUnitCost; // 変更前原価
            salesDetailWork.CmpltSalesRowNo = salesDetail.CmpltSalesRowNo; // 一式明細番号
            salesDetailWork.CmpltGoodsMakerCd = salesDetail.CmpltGoodsMakerCd; // メーカーコード（一式）
            salesDetailWork.CmpltMakerName = salesDetail.CmpltMakerName; // メーカー名称（一式）
            salesDetailWork.CmpltGoodsName = salesDetail.CmpltGoodsName; // 商品名称（一式）
            salesDetailWork.CmpltShipmentCnt = salesDetail.CmpltShipmentCnt; // 数量（一式）
            salesDetailWork.CmpltSalesUnPrcFl = salesDetail.CmpltSalesUnPrcFl; // 売上単価（一式）
            salesDetailWork.CmpltSalesMoney = salesDetail.CmpltSalesMoney; // 売上金額（一式）
            salesDetailWork.CmpltSalesUnitCost = salesDetail.CmpltSalesUnitCost; // 原価単価（一式）
            salesDetailWork.CmpltCost = salesDetail.CmpltCost; // 原価金額（一式）
            salesDetailWork.CmpltPartySalSlNum = salesDetail.CmpltPartySalSlNum; // 相手先伝票番号（一式）
            salesDetailWork.CmpltNote = salesDetail.CmpltNote; // 一式備考
            salesDetailWork.PrtGoodsNo = salesDetail.PrtGoodsNo; // 印刷用品番
            salesDetailWork.PrtMakerCode = salesDetail.PrtMakerCode; // 印刷用メーカーコード
            salesDetailWork.PrtMakerName = salesDetail.PrtMakerName; // 印刷用メーカー名称
            salesDetailWork.DtlRelationGuid = salesDetail.DtlRelationGuid; // 共通キー
            //salesDetailWork.CarRelationGuid = salesDetail.CarRelationGuid; // 車両情報共通キー
            //>>>2010/02/26
            salesDetailWork.CampaignCode = salesDetail.CampaignCode;
            salesDetailWork.CampaignName = salesDetail.CampaignName;
            salesDetailWork.GoodsDivCd = salesDetail.GoodsDivCd;
            salesDetailWork.AnswerDelivDate = salesDetail.AnswerDelivDate;
            salesDetailWork.RecycleDiv = salesDetail.RecycleDiv;
            salesDetailWork.RecycleDivNm = salesDetail.RecycleDivNm;
            salesDetailWork.WayToAcptOdr = salesDetail.WayToAcptOdr;
            salesDetailWork.DtlRelationGuid = salesDetail.DtlRelationGuid; // 共通キー
            //<<<2010/02/26
            salesDetailWork.AutoAnswerDivSCM = salesDetail.AutoAnswerDivSCM; // 自動回答区分
            salesDetailWork.AcceptOrOrderKind = salesDetail.AcceptOrOrderKind;//受発注種別 //add 2011/08/23
            salesDetailWork.InquiryNumber = salesDetail.InquiryNumber;//問合せ番号 //add 2011/08/23
            salesDetailWork.InqRowNumber = salesDetail.InqRowNumber;//問合せ行番号 //add 2011/08/23
            // 2012/01/16 Add >>>
            salesDetailWork.GoodsSpecialNote = salesDetail.GoodsSpecialNote; // 特記事項
            // 2012/01/16 Add <<<
            //>>>2012/05/02
            salesDetailWork.RentSyncStockDate = salesDetail.RentSyncStockDate;
            salesDetailWork.RentSyncSupplier = salesDetail.RentSyncSupplier;
            salesDetailWork.RentSyncSupSlipNo = salesDetail.RentSyncSupSlipNo;
            //<<<2012/05/02
            return salesDetailWork;
        }

        /// <summary>
        /// PramData→UIData移項処理
        /// </summary>
        /// <param name="stockSlipWork">仕入データワークオブジェクト</param>
        /// <param name="stockDetailWork">仕入明細データワークオブジェクト</param>
        /// <returns>仕入情報オブジェクト</returns>
        private static StockTemp UIDataFromParamDataProc(StockSlipWork stockSlipWork, StockDetailWork stockDetailWork)
        {
            StockTemp stockTemp = new StockTemp();

            #region ●項目セット
            stockTemp.CreateDateTime = stockSlipWork.CreateDateTime; // 作成日時
            stockTemp.UpdateDateTime = stockSlipWork.UpdateDateTime; // 更新日時
            stockTemp.EnterpriseCode = stockSlipWork.EnterpriseCode; // 企業コード
            stockTemp.FileHeaderGuid = stockSlipWork.FileHeaderGuid; // GUID
            stockTemp.UpdEmployeeCode = stockSlipWork.UpdEmployeeCode; // 更新従業員コード
            stockTemp.UpdAssemblyId1 = stockSlipWork.UpdAssemblyId1; // 更新アセンブリID1
            stockTemp.UpdAssemblyId2 = stockSlipWork.UpdAssemblyId2; // 更新アセンブリID2
            stockTemp.LogicalDeleteCode = stockSlipWork.LogicalDeleteCode; // 論理削除区分
            stockTemp.SupplierFormal = stockSlipWork.SupplierFormal; // 仕入形式
            stockTemp.SupplierSlipNo = stockSlipWork.SupplierSlipNo; // 仕入伝票番号
            stockTemp.SectionCode = stockSlipWork.SectionCode; // 拠点コード
            stockTemp.SubSectionCode = stockSlipWork.SubSectionCode; // 部門コード
            stockTemp.DebitNoteDiv = stockSlipWork.DebitNoteDiv; // 赤伝区分
            stockTemp.DebitNLnkSuppSlipNo = stockSlipWork.DebitNLnkSuppSlipNo; // 赤黒連結仕入伝票番号
            stockTemp.SupplierSlipCd = stockSlipWork.SupplierSlipCd; // 仕入伝票区分
            stockTemp.StockGoodsCd = stockSlipWork.StockGoodsCd; // 仕入商品区分
            stockTemp.AccPayDivCd = stockSlipWork.AccPayDivCd; // 買掛区分
            stockTemp.StockSectionCd = stockSlipWork.StockSectionCd; // 仕入拠点コード
            stockTemp.StockAddUpSectionCd = stockSlipWork.StockAddUpSectionCd; // 仕入計上拠点コード
            stockTemp.StockSlipUpdateCd = stockSlipWork.StockSlipUpdateCd; // 仕入伝票更新区分
            stockTemp.InputDay = stockSlipWork.InputDay; // 入力日
            stockTemp.ArrivalGoodsDay = stockSlipWork.ArrivalGoodsDay; // 入荷日
            stockTemp.StockDate = stockSlipWork.StockDate; // 仕入日
            stockTemp.StockAddUpADate = stockSlipWork.StockAddUpADate; // 仕入計上日付
            stockTemp.DelayPaymentDiv = stockSlipWork.DelayPaymentDiv; // 来勘区分
            stockTemp.PayeeCode = stockSlipWork.PayeeCode; // 支払先コード
            stockTemp.PayeeSnm = stockSlipWork.PayeeSnm; // 支払先略称
            stockTemp.SupplierCd = stockSlipWork.SupplierCd; // 仕入先コード
            stockTemp.SupplierNm1 = stockSlipWork.SupplierNm1; // 仕入先名1
            stockTemp.SupplierNm2 = stockSlipWork.SupplierNm2; // 仕入先名2
            stockTemp.SupplierSnm = stockSlipWork.SupplierSnm; // 仕入先略称
            stockTemp.BusinessTypeCode = stockSlipWork.BusinessTypeCode; // 業種コード
            stockTemp.BusinessTypeName = stockSlipWork.BusinessTypeName; // 業種名称
            stockTemp.SalesAreaCode = stockSlipWork.SalesAreaCode; // 販売エリアコード
            stockTemp.SalesAreaName = stockSlipWork.SalesAreaName; // 販売エリア名称
            stockTemp.StockInputCode = stockSlipWork.StockInputCode; // 仕入入力者コード
            stockTemp.StockInputName = stockSlipWork.StockInputName; // 仕入入力者名称
            stockTemp.StockAgentCode = stockSlipWork.StockAgentCode; // 仕入担当者コード
            stockTemp.StockAgentName = stockSlipWork.StockAgentName; // 仕入担当者名称
            stockTemp.SuppTtlAmntDspWayCd = stockSlipWork.SuppTtlAmntDspWayCd; // 仕入先総額表示方法区分
            stockTemp.TtlAmntDispRateApy = stockSlipWork.TtlAmntDispRateApy; // 総額表示掛率適用区分
            stockTemp.StockTotalPrice = stockSlipWork.StockTotalPrice; // 仕入金額合計
            stockTemp.StockSubttlPrice = stockSlipWork.StockSubttlPrice; // 仕入金額小計
            stockTemp.StockTtlPricTaxInc = stockSlipWork.StockTtlPricTaxInc; // 仕入金額計（税込み）
            stockTemp.StockTtlPricTaxExc = stockSlipWork.StockTtlPricTaxExc; // 仕入金額計（税抜き）
            stockTemp.StockNetPrice = stockSlipWork.StockNetPrice; // 仕入正価金額
            stockTemp.StockPriceConsTax = stockSlipWork.StockPriceConsTax; // 仕入金額消費税額
            stockTemp.TtlItdedStcOutTax = stockSlipWork.TtlItdedStcOutTax; // 仕入外税対象額合計
            stockTemp.TtlItdedStcInTax = stockSlipWork.TtlItdedStcInTax; // 仕入内税対象額合計
            stockTemp.TtlItdedStcTaxFree = stockSlipWork.TtlItdedStcTaxFree; // 仕入非課税対象額合計
            stockTemp.StockOutTax = stockSlipWork.StockOutTax; // 仕入金額消費税額（外税）
            stockTemp.StckPrcConsTaxInclu = stockSlipWork.StckPrcConsTaxInclu; // 仕入金額消費税額（内税）
            stockTemp.StckDisTtlTaxExc = stockSlipWork.StckDisTtlTaxExc; // 仕入値引金額計（税抜き）
            stockTemp.ItdedStockDisOutTax = stockSlipWork.ItdedStockDisOutTax; // 仕入値引外税対象額合計
            stockTemp.ItdedStockDisInTax = stockSlipWork.ItdedStockDisInTax; // 仕入値引内税対象額合計
            stockTemp.ItdedStockDisTaxFre = stockSlipWork.ItdedStockDisTaxFre; // 仕入値引非課税対象額合計
            stockTemp.StockDisOutTax = stockSlipWork.StockDisOutTax; // 仕入値引消費税額（外税）
            stockTemp.StckDisTtlTaxInclu = stockSlipWork.StckDisTtlTaxInclu; // 仕入値引消費税額（内税）
            stockTemp.TaxAdjust = stockSlipWork.TaxAdjust; // 消費税調整額
            stockTemp.BalanceAdjust = stockSlipWork.BalanceAdjust; // 残高調整額
            stockTemp.SuppCTaxLayCd = stockSlipWork.SuppCTaxLayCd; // 仕入先消費税転嫁方式コード
            stockTemp.SupplierConsTaxRate = stockSlipWork.SupplierConsTaxRate; // 仕入先消費税税率
            stockTemp.AccPayConsTax = stockSlipWork.AccPayConsTax; // 買掛消費税
            stockTemp.StockFractionProcCd = stockSlipWork.StockFractionProcCd; // 仕入端数処理区分
            stockTemp.AutoPayment = stockSlipWork.AutoPayment; // 自動支払区分
            stockTemp.AutoPaySlipNum = stockSlipWork.AutoPaySlipNum; // 自動支払伝票番号
            stockTemp.RetGoodsReasonDiv = stockSlipWork.RetGoodsReasonDiv; // 返品理由コード
            stockTemp.RetGoodsReason = stockSlipWork.RetGoodsReason; // 返品理由
            stockTemp.PartySaleSlipNum = stockSlipWork.PartySaleSlipNum; // 相手先伝票番号
            stockTemp.SupplierSlipNote1 = stockSlipWork.SupplierSlipNote1; // 仕入伝票備考1
            stockTemp.SupplierSlipNote2 = stockSlipWork.SupplierSlipNote2; // 仕入伝票備考2
            stockTemp.DetailRowCount = stockSlipWork.DetailRowCount; // 明細行数
            stockTemp.EdiSendDate = stockSlipWork.EdiSendDate; // ＥＤＩ送信日
            stockTemp.EdiTakeInDate = stockSlipWork.EdiTakeInDate; // ＥＤＩ取込日
            stockTemp.UoeRemark1 = stockSlipWork.UoeRemark1; // ＵＯＥリマーク１
            stockTemp.UoeRemark2 = stockSlipWork.UoeRemark2; // ＵＯＥリマーク２
            stockTemp.SlipPrintDivCd = stockSlipWork.SlipPrintDivCd; // 伝票発行区分
            stockTemp.SlipPrintFinishCd = stockSlipWork.SlipPrintFinishCd; // 伝票発行済区分
            stockTemp.StockSlipPrintDate = stockSlipWork.StockSlipPrintDate; // 仕入伝票発行日
            stockTemp.SlipPrtSetPaperId = stockSlipWork.SlipPrtSetPaperId; // 伝票印刷設定用帳票ID
            stockTemp.SlipAddressDiv = stockSlipWork.SlipAddressDiv; // 伝票住所区分
            stockTemp.AddresseeCode = stockSlipWork.AddresseeCode; // 納品先コード
            stockTemp.AddresseeName = stockSlipWork.AddresseeName; // 納品先名称
            stockTemp.AddresseeName2 = stockSlipWork.AddresseeName2; // 納品先名称2
            stockTemp.AddresseePostNo = stockSlipWork.AddresseePostNo; // 納品先郵便番号
            stockTemp.AddresseeAddr1 = stockSlipWork.AddresseeAddr1; // 納品先住所1(都道府県市区郡・町村・字)
            stockTemp.AddresseeAddr3 = stockSlipWork.AddresseeAddr3; // 納品先住所3(番地)
            stockTemp.AddresseeAddr4 = stockSlipWork.AddresseeAddr4; // 納品先住所4(アパート名称)
            stockTemp.AddresseeTelNo = stockSlipWork.AddresseeTelNo; // 納品先電話番号
            stockTemp.AddresseeFaxNo = stockSlipWork.AddresseeFaxNo; // 納品先FAX番号
            stockTemp.DirectSendingCd = stockSlipWork.DirectSendingCd; // 直送区分

            stockTemp.AcceptAnOrderNo = stockDetailWork.AcceptAnOrderNo; // 受注番号
            stockTemp.SupplierFormalDetail = stockDetailWork.SupplierFormal; // 仕入形式
            stockTemp.SupplierSlipNoDetail = stockDetailWork.SupplierSlipNo; // 仕入伝票番号
            stockTemp.StockRowNo = stockDetailWork.StockRowNo; // 仕入行番号
            stockTemp.SectionCodeDetail = stockDetailWork.SectionCode; // 拠点コード
            stockTemp.SubSectionCodeDetail = stockDetailWork.SubSectionCode; // 部門コード
            stockTemp.CommonSeqNo = stockDetailWork.CommonSeqNo; // 共通通番
            stockTemp.StockSlipDtlNum = stockDetailWork.StockSlipDtlNum; // 仕入明細通番
            stockTemp.SupplierFormalSrc = stockDetailWork.SupplierFormalSrc; // 仕入形式（元）
            stockTemp.StockSlipDtlNumSrc = stockDetailWork.StockSlipDtlNumSrc; // 仕入明細通番（元）
            stockTemp.AcptAnOdrStatusSync = stockDetailWork.AcptAnOdrStatusSync; // 受注ステータス（同時）
            stockTemp.SalesSlipDtlNumSync = stockDetailWork.SalesSlipDtlNumSync; // 売上明細通番（同時）
            stockTemp.StockSlipCdDtl = stockDetailWork.StockSlipCdDtl; // 仕入伝票区分（明細）
            stockTemp.StockInputCodeDetail = stockDetailWork.StockInputCode; // 仕入入力者コード
            stockTemp.StockInputNameDetail = stockDetailWork.StockInputName; // 仕入入力者名称
            stockTemp.StockAgentCodeDetail = stockDetailWork.StockAgentCode; // 仕入担当者コード
            stockTemp.StockAgentNameDetail = stockDetailWork.StockAgentName; // 仕入担当者名称
            stockTemp.GoodsKindCode = stockDetailWork.GoodsKindCode; // 商品属性
            stockTemp.GoodsMakerCd = stockDetailWork.GoodsMakerCd; // 商品メーカーコード
            stockTemp.MakerName = stockDetailWork.MakerName; // メーカー名称
            stockTemp.MakerKanaName = stockDetailWork.MakerKanaName; // メーカーカナ名称
            stockTemp.CmpltMakerKanaName = stockDetailWork.CmpltMakerKanaName; // メーカーカナ名称（一式）
            stockTemp.GoodsNo = stockDetailWork.GoodsNo; // 商品番号
            stockTemp.GoodsName = stockDetailWork.GoodsName; // 商品名称
            stockTemp.GoodsNameKana = stockDetailWork.GoodsNameKana; // 商品名称カナ
            stockTemp.GoodsLGroup = stockDetailWork.GoodsLGroup; // 商品大分類コード
            stockTemp.GoodsLGroupName = stockDetailWork.GoodsLGroupName; // 商品大分類名称
            stockTemp.GoodsMGroup = stockDetailWork.GoodsMGroup; // 商品中分類コード
            stockTemp.GoodsMGroupName = stockDetailWork.GoodsMGroupName; // 商品中分類名称
            stockTemp.BLGroupCode = stockDetailWork.BLGroupCode; // BLグループコード
            stockTemp.BLGroupName = stockDetailWork.BLGroupName; // BLグループコード名称
            stockTemp.BLGoodsCode = stockDetailWork.BLGoodsCode; // BL商品コード
            stockTemp.BLGoodsFullName = stockDetailWork.BLGoodsFullName; // BL商品コード名称（全角）
            stockTemp.EnterpriseGanreCode = stockDetailWork.EnterpriseGanreCode; // 自社分類コード
            stockTemp.EnterpriseGanreName = stockDetailWork.EnterpriseGanreName; // 自社分類名称
            stockTemp.WarehouseCode = stockDetailWork.WarehouseCode; // 倉庫コード
            stockTemp.WarehouseName = stockDetailWork.WarehouseName; // 倉庫名称
            stockTemp.WarehouseShelfNo = stockDetailWork.WarehouseShelfNo; // 倉庫棚番
            stockTemp.StockOrderDivCd = stockDetailWork.StockOrderDivCd; // 仕入在庫取寄せ区分
            stockTemp.OpenPriceDiv = stockDetailWork.OpenPriceDiv; // オープン価格区分
            stockTemp.GoodsRateRank = stockDetailWork.GoodsRateRank; // 商品掛率ランク
            stockTemp.CustRateGrpCode = stockDetailWork.CustRateGrpCode; // 得意先掛率グループコード
            stockTemp.SuppRateGrpCode = stockDetailWork.SuppRateGrpCode; // 仕入先掛率グループコード
            stockTemp.ListPriceTaxExcFl = stockDetailWork.ListPriceTaxExcFl; // 定価（税抜，浮動）
            stockTemp.ListPriceTaxIncFl = stockDetailWork.ListPriceTaxIncFl; // 定価（税込，浮動）
            stockTemp.StockRate = stockDetailWork.StockRate; // 仕入率
            stockTemp.RateSectStckUnPrc = stockDetailWork.RateSectStckUnPrc; // 掛率設定拠点（仕入単価）
            stockTemp.RateDivStckUnPrc = stockDetailWork.RateDivStckUnPrc; // 掛率設定区分（仕入単価）
            stockTemp.UnPrcCalcCdStckUnPrc = stockDetailWork.UnPrcCalcCdStckUnPrc; // 単価算出区分（仕入単価）
            stockTemp.PriceCdStckUnPrc = stockDetailWork.PriceCdStckUnPrc; // 価格区分（仕入単価）
            stockTemp.StdUnPrcStckUnPrc = stockDetailWork.StdUnPrcStckUnPrc; // 基準単価（仕入単価）
            stockTemp.FracProcUnitStcUnPrc = stockDetailWork.FracProcUnitStcUnPrc; // 端数処理単位（仕入単価）
            stockTemp.FracProcStckUnPrc = stockDetailWork.FracProcStckUnPrc; // 端数処理（仕入単価）
            stockTemp.StockUnitPriceFl = stockDetailWork.StockUnitPriceFl; // 仕入単価（税抜，浮動）
            stockTemp.StockUnitTaxPriceFl = stockDetailWork.StockUnitTaxPriceFl; // 仕入単価（税込，浮動）
            stockTemp.StockUnitChngDiv = stockDetailWork.StockUnitChngDiv; // 仕入単価変更区分
            stockTemp.BfStockUnitPriceFl = stockDetailWork.BfStockUnitPriceFl; // 変更前仕入単価（浮動）
            stockTemp.BfListPrice = stockDetailWork.BfListPrice; // 変更前定価
            stockTemp.RateBLGoodsCode = stockDetailWork.RateBLGoodsCode; // BL商品コード（掛率）
            stockTemp.RateBLGoodsName = stockDetailWork.RateBLGoodsName; // BL商品コード名称（掛率）
            stockTemp.RateGoodsRateGrpCd = stockDetailWork.RateGoodsRateGrpCd; // 商品掛率グループコード（掛率）
            stockTemp.RateGoodsRateGrpNm = stockDetailWork.RateGoodsRateGrpNm; // 商品掛率グループ名称（掛率）
            stockTemp.RateBLGroupCode = stockDetailWork.RateBLGroupCode; // BLグループコード（掛率）
            stockTemp.RateBLGroupName = stockDetailWork.RateBLGroupName; // BLグループ名称（掛率）
            stockTemp.StockCount = stockDetailWork.StockCount; // 仕入数
            stockTemp.OrderCnt = stockDetailWork.OrderCnt; // 発注数量
            stockTemp.OrderAdjustCnt = stockDetailWork.OrderAdjustCnt; // 発注調整数
            stockTemp.OrderRemainCnt = stockDetailWork.OrderRemainCnt; // 発注残数
            stockTemp.RemainCntUpdDate = stockDetailWork.RemainCntUpdDate; // 残数更新日
            stockTemp.StockPriceTaxExc = stockDetailWork.StockPriceTaxExc; // 仕入金額（税抜き）
            stockTemp.StockPriceTaxInc = stockDetailWork.StockPriceTaxInc; // 仕入金額（税込み）
            stockTemp.StockGoodsCdDetail = stockDetailWork.StockGoodsCd; // 仕入商品区分
            stockTemp.StockPriceConsTaxDetail = stockDetailWork.StockPriceConsTax; // 仕入金額消費税額
            stockTemp.TaxationCode = stockDetailWork.TaxationCode; // 課税区分
            stockTemp.StockDtiSlipNote1 = stockDetailWork.StockDtiSlipNote1; // 仕入伝票明細備考1
            stockTemp.SalesCustomerCode = stockDetailWork.SalesCustomerCode; // 販売先コード
            stockTemp.SalesCustomerSnm = stockDetailWork.SalesCustomerSnm; // 販売先略称
            stockTemp.SlipMemo1 = stockDetailWork.SlipMemo1; // 伝票メモ１
            stockTemp.SlipMemo2 = stockDetailWork.SlipMemo2; // 伝票メモ２
            stockTemp.SlipMemo3 = stockDetailWork.SlipMemo3; // 伝票メモ３
            stockTemp.InsideMemo1 = stockDetailWork.InsideMemo1; // 社内メモ１
            stockTemp.InsideMemo2 = stockDetailWork.InsideMemo2; // 社内メモ２
            stockTemp.InsideMemo3 = stockDetailWork.InsideMemo3; // 社内メモ３
            stockTemp.SupplierCdDetail = stockDetailWork.SupplierCd; // 仕入先コード
            stockTemp.SupplierSnmDetail = stockDetailWork.SupplierSnm; // 仕入先略称
            stockTemp.AddresseeCodeDetail = stockDetailWork.AddresseeCode; // 納品先コード
            stockTemp.AddresseeNameDetail = stockDetailWork.AddresseeName; // 納品先名称
            stockTemp.DirectSendingCdDetail = stockDetailWork.DirectSendingCd; // 直送区分
            stockTemp.OrderNumber = stockDetailWork.OrderNumber; // 発注番号
            stockTemp.WayToOrder = stockDetailWork.WayToOrder; // 注文方法
            stockTemp.DeliGdsCmpltDueDate = stockDetailWork.DeliGdsCmpltDueDate; // 納品完了予定日
            stockTemp.ExpectDeliveryDate = stockDetailWork.ExpectDeliveryDate; // 希望納期
            stockTemp.OrderDataCreateDiv = stockDetailWork.OrderDataCreateDiv; // 発注データ作成区分
            stockTemp.OrderDataCreateDate = stockDetailWork.OrderDataCreateDate; // 発注データ作成日
            stockTemp.OrderFormIssuedDiv = stockDetailWork.OrderFormIssuedDiv; // 発注書発行済区分
            //stockTemp.TotalDay = stockDetailWork.TotalDay; // 締日
            //stockTemp.NTimeCalcStDate = stockDetailWork.NTimeCalcStDate; // 次回勘定開始日
            //stockTemp.PayeeName = stockDetailWork.PayeeName; // 支払先名称
            //stockTemp.PayeeName2 = stockDetailWork.PayeeName2; // 支払先名称２
            //stockTemp.AddUpEnableCnt = stockDetailWork.AddUpEnableCnt; // 計上可能数量
            //stockTemp.AlreadyAddUpCnt = stockDetailWork.AlreadyAddUpCnt; // 計上済数量
            //stockTemp.EditStatus = stockDetailWork.EditStatus; // エディットステータス
            stockTemp.DtlRelationGuid = stockDetailWork.DtlRelationGuid; // 共通キー

            #endregion

            return stockTemp;
        }

        /// <summary>
        /// PramData→UIData移行処理
        /// </summary>
        /// <param name="acceptOdrCarWorkList">受注マスタ（車両）ワークオブジェクト配列</param>
        /// <returns>受注マスタ（車両）オブジェクトリスト</returns>
        private static List<AcceptOdrCar> UIDataFromParamDataProc(AcceptOdrCarWork[] acceptOdrCarWorkList)
        {
            if (acceptOdrCarWorkList == null) return null;

            List<AcceptOdrCar> acceptOdrCarList = new List<AcceptOdrCar>();

            foreach (AcceptOdrCarWork acceptOdrCarWork in acceptOdrCarWorkList)
            {
                acceptOdrCarList.Add(UIDataFromParamData(acceptOdrCarWork));
            }

            return acceptOdrCarList;
        }

        /// <summary>
        /// PramData→UIData移項処理
        /// </summary>
        /// <param name="acceptOdrCarWork">受注マスタ（車両）ワークオブジェクト</param>
        /// <returns>受注マスタ（車両）オブジェクト</returns>
        /// <br>Update Note: 2009/09/08 張凱 車輌管理機能対応</br>
        private static AcceptOdrCar UIDataFromParamDataProc(AcceptOdrCarWork acceptOdrCarWork)
        {
            AcceptOdrCar acceptOdrCar = new AcceptOdrCar();

            acceptOdrCar.CreateDateTime = acceptOdrCarWork.CreateDateTime; // 作成日時
            acceptOdrCar.UpdateDateTime = acceptOdrCarWork.UpdateDateTime; // 更新日時
            acceptOdrCar.EnterpriseCode = acceptOdrCarWork.EnterpriseCode; // 企業コード
            acceptOdrCar.FileHeaderGuid = acceptOdrCarWork.FileHeaderGuid; // GUID
            acceptOdrCar.UpdEmployeeCode = acceptOdrCarWork.UpdEmployeeCode; // 更新従業員コード
            acceptOdrCar.UpdAssemblyId1 = acceptOdrCarWork.UpdAssemblyId1; // 更新アセンブリID1
            acceptOdrCar.UpdAssemblyId2 = acceptOdrCarWork.UpdAssemblyId2; // 更新アセンブリID2
            acceptOdrCar.LogicalDeleteCode = acceptOdrCarWork.LogicalDeleteCode; // 論理削除区分
            acceptOdrCar.AcceptAnOrderNo = acceptOdrCarWork.AcceptAnOrderNo; // 受注番号
            acceptOdrCar.AcptAnOdrStatus = acceptOdrCarWork.AcptAnOdrStatus; // 受注ステータス
            acceptOdrCar.DataInputSystem = acceptOdrCarWork.DataInputSystem; // データ入力システム
            acceptOdrCar.CarMngNo = acceptOdrCarWork.CarMngNo; // 車両管理番号
            acceptOdrCar.CarMngCode = acceptOdrCarWork.CarMngCode; // 車輌管理コード
            acceptOdrCar.NumberPlate1Code = acceptOdrCarWork.NumberPlate1Code; // 陸運事務所番号
            acceptOdrCar.NumberPlate1Name = acceptOdrCarWork.NumberPlate1Name; // 陸運事務局名称
            acceptOdrCar.NumberPlate2 = acceptOdrCarWork.NumberPlate2; // 車両登録番号（種別）
            acceptOdrCar.NumberPlate3 = acceptOdrCarWork.NumberPlate3; // 車両登録番号（カナ）
            acceptOdrCar.NumberPlate4 = acceptOdrCarWork.NumberPlate4; // 車両登録番号（プレート番号）
            // ここ
            //acceptOdrCar.FirstEntryDate = acceptOdrCarWork.FirstEntryDate; // 初年度

            // --- UPD 2009/09/08 ---------->>>>>
            //int iyy = acceptOdrCarWork.FirstEntryDate / 100;
            //int imm = acceptOdrCarWork.FirstEntryDate % 100;
            //DateTime produceTypeOfYearInput = DateTime.MinValue;
            //if ((iyy != 0) && (imm != 0)) produceTypeOfYearInput = new DateTime(iyy, imm, 1);
            //acceptOdrCar.FirstEntryDate = produceTypeOfYearInput; // 初年度
            acceptOdrCar.FirstEntryDate = acceptOdrCarWork.FirstEntryDate; // 初年度
            // --- UPD 2009/09/08 ----------<<<<<
            acceptOdrCar.MakerCode = acceptOdrCarWork.MakerCode; // メーカーコード
            acceptOdrCar.MakerFullName = acceptOdrCarWork.MakerFullName; // メーカー全角名称
            acceptOdrCar.MakerHalfName = acceptOdrCarWork.MakerHalfName; // メーカー半角名称
            acceptOdrCar.ModelCode = acceptOdrCarWork.ModelCode; // 車種コード
            acceptOdrCar.ModelSubCode = acceptOdrCarWork.ModelSubCode; // 車種サブコード
            acceptOdrCar.ModelFullName = acceptOdrCarWork.ModelFullName; // 車種全角名称
            acceptOdrCar.ModelHalfName = acceptOdrCarWork.ModelHalfName; // 車種半角名称
            acceptOdrCar.ExhaustGasSign = acceptOdrCarWork.ExhaustGasSign; // 排ガス記号
            acceptOdrCar.SeriesModel = acceptOdrCarWork.SeriesModel; // シリーズ型式
            acceptOdrCar.CategorySignModel = acceptOdrCarWork.CategorySignModel; // 型式（類別記号）
            acceptOdrCar.FullModel = acceptOdrCarWork.FullModel; // 型式（フル型）
            acceptOdrCar.ModelDesignationNo = acceptOdrCarWork.ModelDesignationNo; // 型式指定番号
            acceptOdrCar.CategoryNo = acceptOdrCarWork.CategoryNo; // 類別番号
            acceptOdrCar.FrameModel = acceptOdrCarWork.FrameModel; // 車台型式
            acceptOdrCar.FrameNo = acceptOdrCarWork.FrameNo; // 車台番号
            acceptOdrCar.SearchFrameNo = acceptOdrCarWork.SearchFrameNo; // 車台番号（検索用）
            acceptOdrCar.EngineModelNm = acceptOdrCarWork.EngineModelNm; // エンジン型式名称
            acceptOdrCar.RelevanceModel = acceptOdrCarWork.RelevanceModel; // 関連型式
            acceptOdrCar.SubCarNmCd = acceptOdrCarWork.SubCarNmCd; // サブ車名コード
            acceptOdrCar.ModelGradeSname = acceptOdrCarWork.ModelGradeSname; // 型式グレード略称
            acceptOdrCar.ColorCode = acceptOdrCarWork.ColorCode; // カラーコード
            acceptOdrCar.ColorName1 = acceptOdrCarWork.ColorName1; // カラー名称1
            acceptOdrCar.TrimCode = acceptOdrCarWork.TrimCode; // トリムコード
            acceptOdrCar.TrimName = acceptOdrCarWork.TrimName; // トリム名称
            acceptOdrCar.Mileage = acceptOdrCarWork.Mileage; // 車両走行距離
            acceptOdrCar.CategoryObjAry = acceptOdrCarWork.CategoryObjAry; // 装備オブジェクト配列
            acceptOdrCar.FullModelFixedNoAry = acceptOdrCarWork.FullModelFixedNoAry; // フル型式固定番号配列

            // --- ADD 2009/09/08 ---------->>>>>
            acceptOdrCar.CarNote = acceptOdrCarWork.CarNote; // 車輌備考
            // --- ADD 2009/09/08 ----------<<<<<

            // --- ADD 2010/04/27 ---------->>>>>
            if (null == acceptOdrCarWork.FreeSrchMdlFxdNoAry || 0 >= acceptOdrCarWork.FreeSrchMdlFxdNoAry.Length)
            {
                acceptOdrCar.FreeSrchMdlFxdNoAry = new string[0];
            }
            else
            {
                BinaryFormatter formatter = new BinaryFormatter();
                MemoryStream ms = new MemoryStream(acceptOdrCarWork.FreeSrchMdlFxdNoAry);
                acceptOdrCar.FreeSrchMdlFxdNoAry = (string[])formatter.Deserialize(ms);  // 自由検索型式固定番号配列
                ms.Close();
            }
            // --- ADD 2010/04/27 ----------<<<<<

            // PMNS:国産/外車区分セット
            // --- ADD 2013/03/21 ---------->>>>>
            acceptOdrCar.DomesticForeignCode = acceptOdrCarWork.DomesticForeignCode; // 国産/外車区分
            // --- ADD 2013/03/21 ----------<<<<<

            return acceptOdrCar;
        }

        /// <summary>
        /// PramData→UIData移項処理
        /// </summary>
        /// <param name="depsitDataWork">入金ワークオブジェクト</param>
        /// <returns>入金データオブジェクト</returns>
        private static SearchDepsitMain UIDataFromParamDataProc(DepsitDataWork depsitDataWork)
        {
            SearchDepsitMain searchDepsitMain = new SearchDepsitMain();
            DepsitMainWork depsitMainWork;
            DepsitDtlWork[] depsitDtlWorkArray;

            DepsitDataUtil.Division(depsitDataWork, out depsitMainWork, out depsitDtlWorkArray);
            searchDepsitMain.CreateDateTime = depsitMainWork.CreateDateTime; // 作成日時
            searchDepsitMain.UpdateDateTime = depsitMainWork.UpdateDateTime; // 更新日時
            searchDepsitMain.EnterpriseCode = depsitMainWork.EnterpriseCode; // 企業コード
            searchDepsitMain.FileHeaderGuid = depsitMainWork.FileHeaderGuid; // GUID
            searchDepsitMain.UpdEmployeeCode = depsitMainWork.UpdEmployeeCode; // 更新従業員コード
            searchDepsitMain.UpdAssemblyId1 = depsitMainWork.UpdAssemblyId1; // 更新アセンブリID1
            searchDepsitMain.UpdAssemblyId2 = depsitMainWork.UpdAssemblyId2; // 更新アセンブリID2
            searchDepsitMain.LogicalDeleteCode = depsitMainWork.LogicalDeleteCode; // 論理削除区分
            searchDepsitMain.AcptAnOdrStatus = depsitMainWork.AcptAnOdrStatus; // 受注ステータス
            searchDepsitMain.DepositDebitNoteCd = depsitMainWork.DepositDebitNoteCd; // 入金赤黒区分
            searchDepsitMain.DepositSlipNo = depsitMainWork.DepositSlipNo; // 入金伝票番号
            searchDepsitMain.SalesSlipNum = depsitMainWork.SalesSlipNum; // 売上伝票番号
            searchDepsitMain.InputDepositSecCd = depsitMainWork.InputDepositSecCd; // 入金入力拠点コード
            searchDepsitMain.AddUpSecCode = depsitMainWork.AddUpSecCode; // 計上拠点コード
            searchDepsitMain.UpdateSecCd = depsitMainWork.UpdateSecCd; // 更新拠点コード
            searchDepsitMain.SubSectionCode = depsitMainWork.SubSectionCode; // 部門コード
            searchDepsitMain.DepositDate = depsitMainWork.DepositDate; // 入金日付
            searchDepsitMain.AddUpADate = depsitMainWork.AddUpADate; // 計上日付
            searchDepsitMain.DepositTotal = depsitMainWork.DepositTotal; // 入金計
            searchDepsitMain.Deposit = depsitMainWork.Deposit; // 入金金額
            searchDepsitMain.FeeDeposit = depsitMainWork.FeeDeposit; // 手数料入金額
            searchDepsitMain.DiscountDeposit = depsitMainWork.DiscountDeposit; // 値引入金額
            searchDepsitMain.AutoDepositCd = depsitMainWork.AutoDepositCd; // 自動入金区分
            searchDepsitMain.DraftDrawingDate = depsitMainWork.DraftDrawingDate; // 手形振出日
            searchDepsitMain.DraftKind = depsitMainWork.DraftKind; // 手形種類
            searchDepsitMain.DraftKindName = depsitMainWork.DraftKindName; // 手形種類名称
            searchDepsitMain.DraftDivide = depsitMainWork.DraftDivide; // 手形区分
            searchDepsitMain.DraftDivideName = depsitMainWork.DraftDivideName; // 手形区分名称
            searchDepsitMain.DraftNo = depsitMainWork.DraftNo; // 手形番号
            searchDepsitMain.DepositAllowance = depsitMainWork.DepositAllowance; // 入金引当額
            searchDepsitMain.DepositAlwcBlnce = depsitMainWork.DepositAlwcBlnce; // 入金引当残高
            searchDepsitMain.DebitNoteLinkDepoNo = depsitMainWork.DebitNoteLinkDepoNo; // 赤黒入金連結番号
            searchDepsitMain.LastReconcileAddUpDt = depsitMainWork.LastReconcileAddUpDt; // 最終消し込み計上日
            searchDepsitMain.DepositAgentCode = depsitMainWork.DepositAgentCode; // 入金担当者コード
            searchDepsitMain.DepositAgentNm = depsitMainWork.DepositAgentNm; // 入金担当者名称
            searchDepsitMain.DepositInputAgentCd = depsitMainWork.DepositInputAgentCd; // 入金入力者コード
            searchDepsitMain.DepositInputAgentNm = depsitMainWork.DepositInputAgentNm; // 入金入力者名称
            searchDepsitMain.CustomerCode = depsitMainWork.CustomerCode; // 得意先コード
            searchDepsitMain.CustomerName = depsitMainWork.CustomerName; // 得意先名称
            searchDepsitMain.CustomerName2 = depsitMainWork.CustomerName2; // 得意先名称2
            searchDepsitMain.CustomerSnm = depsitMainWork.CustomerSnm; // 得意先略称
            searchDepsitMain.ClaimCode = depsitMainWork.ClaimCode; // 請求先コード
            searchDepsitMain.ClaimName = depsitMainWork.ClaimName; // 請求先名称
            searchDepsitMain.ClaimName2 = depsitMainWork.ClaimName2; // 請求先名称2
            searchDepsitMain.ClaimSnm = depsitMainWork.ClaimSnm; // 請求先略称
            searchDepsitMain.Outline = depsitMainWork.Outline; // 伝票摘要
            searchDepsitMain.BankCode = depsitMainWork.BankCode; // 銀行コード
            searchDepsitMain.BankName = depsitMainWork.BankName; // 銀行名称

            //searchDepsitMain.CreateDateTime = depsitDtlWorkArray[0].CreateDateTime; // 作成日時
            //searchDepsitMain.UpdateDateTime = depsitDtlWorkArray[0].UpdateDateTime; // 更新日時
            //searchDepsitMain.EnterpriseCode = depsitDtlWorkArray[0].EnterpriseCode; // 企業コード
            //searchDepsitMain.FileHeaderGuid = depsitDtlWorkArray[0].FileHeaderGuid; // GUID
            //searchDepsitMain.UpdEmployeeCode = depsitDtlWorkArray[0].UpdEmployeeCode; // 更新従業員コード
            //searchDepsitMain.UpdAssemblyId1 = depsitDtlWorkArray[0].UpdAssemblyId1; // 更新アセンブリID1
            //searchDepsitMain.UpdAssemblyId2 = depsitDtlWorkArray[0].UpdAssemblyId2; // 更新アセンブリID2
            //searchDepsitMain.LogicalDeleteCode = depsitDtlWorkArray[0].LogicalDeleteCode; // 論理削除区分
            //searchDepsitMain.AcptAnOdrStatus = depsitDtlWorkArray[0].AcptAnOdrStatus; // 受注ステータス
            //searchDepsitMain.DepositSlipNo = depsitDtlWorkArray[0].DepositSlipNo; // 入金伝票番号

            if (depsitDtlWorkArray != null)
            {
                for (int i = 0; i < depsitDtlWorkArray.Length; i++)
                {
                    searchDepsitMain.DepositRowNo[i] = depsitDtlWorkArray[i].DepositRowNo; // 入金行番号
                    searchDepsitMain.MoneyKindCode[i] = depsitDtlWorkArray[i].MoneyKindCode; // 金種コード
                    searchDepsitMain.MoneyKindName[i] = depsitDtlWorkArray[i].MoneyKindName; // 金種名称
                    searchDepsitMain.MoneyKindDiv[i] = depsitDtlWorkArray[i].MoneyKindDiv; // 金種区分
                    searchDepsitMain.DepositDtl[i] = depsitDtlWorkArray[i].Deposit; // 入金金額
                    searchDepsitMain.ValidityTerm[i] = depsitDtlWorkArray[i].ValidityTerm; // 有効期限
                }
            }

            return searchDepsitMain;
        }

        /// <summary>
        /// PramData→UIData移項処理
        /// </summary>
        /// <param name="searchDepsitMain">入金データオブジェクト</param>
        /// <returns>入金ワークオブジェクト</returns>
        /// <remarks>
        /// <br>Update Note : 2012/01/19 tianjw</br>
        /// <br>              Redmine#28098 拠点管理／送信済みエラー</br>
        /// </remarks>
        private static DepsitDataWork ParamDataFromUIDataProc(SearchDepsitMain searchDepsitMain)
        {
            DepsitDataWork depsitDataWork = new DepsitDataWork();
            DepsitMainWork depsitMainWork = new DepsitMainWork();
            DepsitDtlWork[] depsitDtlWorkArray = new DepsitDtlWork[searchDepsitMain.DepositRowNo.Length];

            depsitMainWork.CreateDateTime = searchDepsitMain.CreateDateTime; // 作成日時
            depsitMainWork.UpdateDateTime = searchDepsitMain.UpdateDateTime; // 更新日時
            depsitMainWork.EnterpriseCode = searchDepsitMain.EnterpriseCode; // 企業コード
            depsitMainWork.FileHeaderGuid = searchDepsitMain.FileHeaderGuid; // GUID
            depsitMainWork.UpdEmployeeCode = searchDepsitMain.UpdEmployeeCode; // 更新従業員コード
            depsitMainWork.UpdAssemblyId1 = searchDepsitMain.UpdAssemblyId1; // 更新アセンブリID1
            depsitMainWork.UpdAssemblyId2 = searchDepsitMain.UpdAssemblyId2; // 更新アセンブリID2
            depsitMainWork.LogicalDeleteCode = searchDepsitMain.LogicalDeleteCode; // 論理削除区分
            depsitMainWork.AcptAnOdrStatus = searchDepsitMain.AcptAnOdrStatus; // 受注ステータス
            depsitMainWork.DepositDebitNoteCd = searchDepsitMain.DepositDebitNoteCd; // 入金赤黒区分
            depsitMainWork.DepositSlipNo = searchDepsitMain.DepositSlipNo; // 入金伝票番号
            depsitMainWork.SalesSlipNum = searchDepsitMain.SalesSlipNum; // 売上伝票番号
            depsitMainWork.InputDepositSecCd = searchDepsitMain.InputDepositSecCd; // 入金入力拠点コード
            depsitMainWork.AddUpSecCode = searchDepsitMain.AddUpSecCode; // 計上拠点コード
            depsitMainWork.UpdateSecCd = searchDepsitMain.UpdateSecCd; // 更新拠点コード
            depsitMainWork.SubSectionCode = searchDepsitMain.SubSectionCode; // 部門コード
            depsitMainWork.DepositDate = searchDepsitMain.DepositDate; // 入金日付
            depsitMainWork.PreDepositDate = searchDepsitMain.DepositDate; // 前回入金日付 // ADD 2012/01/19 tianjw Redmine#27390
            depsitMainWork.AddUpADate = searchDepsitMain.AddUpADate; // 計上日付
            depsitMainWork.DepositTotal = searchDepsitMain.DepositTotal; // 入金計
            depsitMainWork.Deposit = searchDepsitMain.Deposit; // 入金金額
            depsitMainWork.FeeDeposit = searchDepsitMain.FeeDeposit; // 手数料入金額
            depsitMainWork.DiscountDeposit = searchDepsitMain.DiscountDeposit; // 値引入金額
            depsitMainWork.AutoDepositCd = searchDepsitMain.AutoDepositCd; // 自動入金区分
            depsitMainWork.DraftDrawingDate = searchDepsitMain.DraftDrawingDate; // 手形振出日
            depsitMainWork.DraftKind = searchDepsitMain.DraftKind; // 手形種類
            depsitMainWork.DraftKindName = searchDepsitMain.DraftKindName; // 手形種類名称
            depsitMainWork.DraftDivide = searchDepsitMain.DraftDivide; // 手形区分
            depsitMainWork.DraftDivideName = searchDepsitMain.DraftDivideName; // 手形区分名称
            depsitMainWork.DraftNo = searchDepsitMain.DraftNo; // 手形番号
            depsitMainWork.DepositAllowance = searchDepsitMain.DepositAllowance; // 入金引当額
            depsitMainWork.DepositAlwcBlnce = searchDepsitMain.DepositAlwcBlnce; // 入金引当残高
            depsitMainWork.DebitNoteLinkDepoNo = searchDepsitMain.DebitNoteLinkDepoNo; // 赤黒入金連結番号
            depsitMainWork.LastReconcileAddUpDt = searchDepsitMain.LastReconcileAddUpDt; // 最終消し込み計上日
            depsitMainWork.DepositAgentCode = searchDepsitMain.DepositAgentCode; // 入金担当者コード
            depsitMainWork.DepositAgentNm = searchDepsitMain.DepositAgentNm; // 入金担当者名称
            depsitMainWork.DepositInputAgentCd = searchDepsitMain.DepositInputAgentCd; // 入金入力者コード
            depsitMainWork.DepositInputAgentNm = searchDepsitMain.DepositInputAgentNm; // 入金入力者名称
            depsitMainWork.CustomerCode = searchDepsitMain.CustomerCode; // 得意先コード
            depsitMainWork.CustomerName = searchDepsitMain.CustomerName; // 得意先名称
            depsitMainWork.CustomerName2 = searchDepsitMain.CustomerName2; // 得意先名称2
            depsitMainWork.CustomerSnm = searchDepsitMain.CustomerSnm; // 得意先略称
            depsitMainWork.ClaimCode = searchDepsitMain.ClaimCode; // 請求先コード
            depsitMainWork.ClaimName = searchDepsitMain.ClaimName; // 請求先名称
            depsitMainWork.ClaimName2 = searchDepsitMain.ClaimName2; // 請求先名称2
            depsitMainWork.ClaimSnm = searchDepsitMain.ClaimSnm; // 請求先略称
            depsitMainWork.Outline = searchDepsitMain.Outline; // 伝票摘要
            depsitMainWork.BankCode = searchDepsitMain.BankCode; // 銀行コード
            depsitMainWork.BankName = searchDepsitMain.BankName; // 銀行名称

            for (int i = 0; i < searchDepsitMain.DepositRowNo.Length; i++)
            {
                DepsitDtlWork depsitDtlWork = new DepsitDtlWork();
                depsitDtlWork.DepositRowNo = searchDepsitMain.DepositRowNo[i]; // 入金行番号
                depsitDtlWork.MoneyKindCode = searchDepsitMain.MoneyKindCode[i]; // 金種コード
                depsitDtlWork.MoneyKindName = searchDepsitMain.MoneyKindName[i]; // 金種名称
                depsitDtlWork.MoneyKindDiv = searchDepsitMain.MoneyKindDiv[i]; // 金種区分
                depsitDtlWork.Deposit = searchDepsitMain.DepositDtl[i]; // 入金金額
                depsitDtlWork.ValidityTerm = searchDepsitMain.ValidityTerm[i]; // 有効期限
                depsitDtlWorkArray[i] = depsitDtlWork;
            }

            DepsitDataUtil.Union(out depsitDataWork, depsitMainWork, depsitDtlWorkArray);

            return depsitDataWork;
        }

        /// <summary>
        /// 項目コピー処理
        /// </summary>
        /// <param name="source">コピー元売上データオブジェクト</param>
        /// <param name="target">コピー先売上データオブジェクト</param>
        private static void CopyItemProc(SalesSlip source, ref SalesSlip target)
        {
            target.CreateDateTime = source.CreateDateTime; // 作成日時
            target.UpdateDateTime = source.UpdateDateTime; // 更新日時
            target.EnterpriseCode = source.EnterpriseCode; // 企業コード
            target.FileHeaderGuid = source.FileHeaderGuid; // GUID
            target.UpdEmployeeCode = source.UpdEmployeeCode; // 更新従業員コード
            target.UpdAssemblyId1 = source.UpdAssemblyId1; // 更新アセンブリID1
            target.UpdAssemblyId2 = source.UpdAssemblyId2; // 更新アセンブリID2
            target.LogicalDeleteCode = source.LogicalDeleteCode; // 論理削除区分
            target.AcptAnOdrStatus = source.AcptAnOdrStatus; // 受注ステータス
            target.SalesSlipNum = source.SalesSlipNum; // 売上伝票番号
            target.SectionCode = source.SectionCode; // 拠点コード
            target.SubSectionCode = source.SubSectionCode; // 部門コード
            target.DebitNoteDiv = source.DebitNoteDiv; // 赤伝区分
            target.DebitNLnkSalesSlNum = source.DebitNLnkSalesSlNum; // 赤黒連結売上伝票番号
            target.SalesSlipCd = source.SalesSlipCd; // 売上伝票区分
            target.SalesGoodsCd = source.SalesGoodsCd; // 売上商品区分
            target.AccRecDivCd = source.AccRecDivCd; // 売掛区分
            target.SalesInpSecCd = source.SalesInpSecCd; // 売上入力拠点コード
            target.DemandAddUpSecCd = source.DemandAddUpSecCd; // 請求計上拠点コード
            target.ResultsAddUpSecCd = source.ResultsAddUpSecCd; // 実績計上拠点コード
            target.UpdateSecCd = source.UpdateSecCd; // 更新拠点コード
            target.SalesSlipUpdateCd = source.SalesSlipUpdateCd; // 売上伝票更新区分
            target.SearchSlipDate = source.SearchSlipDate; // 伝票検索日付
            target.ShipmentDay = source.ShipmentDay; // 出荷日付
            target.SalesDate = source.SalesDate; // 売上日付
            target.AddUpADate = source.AddUpADate; // 計上日付
            target.DelayPaymentDiv = source.DelayPaymentDiv; // 来勘区分
            target.EstimateFormNo = source.EstimateFormNo; // 見積書番号
            target.EstimateDivide = source.EstimateDivide; // 見積区分
            target.InputAgenCd = source.InputAgenCd; // 入力担当者コード
            target.InputAgenNm = source.InputAgenNm; // 入力担当者名称
            target.SalesInputCode = source.SalesInputCode; // 売上入力者コード
            target.SalesInputName = source.SalesInputName; // 売上入力者名称
            target.FrontEmployeeCd = source.FrontEmployeeCd; // 受付従業員コード
            target.FrontEmployeeNm = source.FrontEmployeeNm; // 受付従業員名称
            target.SalesEmployeeCd = source.SalesEmployeeCd; // 販売従業員コード
            target.SalesEmployeeNm = source.SalesEmployeeNm; // 販売従業員名称
            target.TotalAmountDispWayCd = source.TotalAmountDispWayCd; // 総額表示方法区分
            target.TtlAmntDispRateApy = source.TtlAmntDispRateApy; // 総額表示掛率適用区分
            target.SalesTotalTaxInc = source.SalesTotalTaxInc; // 売上伝票合計（税込み）
            target.SalesTotalTaxExc = source.SalesTotalTaxExc; // 売上伝票合計（税抜き）
            target.SalesPrtTotalTaxInc = source.SalesPrtTotalTaxInc; // 売上部品合計（税込み）
            target.SalesPrtTotalTaxExc = source.SalesPrtTotalTaxExc; // 売上部品合計（税抜き）
            target.SalesWorkTotalTaxInc = source.SalesWorkTotalTaxInc; // 売上作業合計（税込み）
            target.SalesWorkTotalTaxExc = source.SalesWorkTotalTaxExc; // 売上作業合計（税抜き）
            target.SalesSubtotalTaxInc = source.SalesSubtotalTaxInc; // 売上小計（税込み）
            target.SalesSubtotalTaxExc = source.SalesSubtotalTaxExc; // 売上小計（税抜き）
            target.SalesPrtSubttlInc = source.SalesPrtSubttlInc; // 売上部品小計（税込み）
            target.SalesPrtSubttlExc = source.SalesPrtSubttlExc; // 売上部品小計（税抜き）
            target.SalesWorkSubttlInc = source.SalesWorkSubttlInc; // 売上作業小計（税込み）
            target.SalesWorkSubttlExc = source.SalesWorkSubttlExc; // 売上作業小計（税抜き）
            target.SalesNetPrice = source.SalesNetPrice; // 売上正価金額
            target.SalesSubtotalTax = source.SalesSubtotalTax; // 売上小計（税）
            target.ItdedSalesOutTax = source.ItdedSalesOutTax; // 売上外税対象額
            target.ItdedSalesInTax = source.ItdedSalesInTax; // 売上内税対象額
            target.SalSubttlSubToTaxFre = source.SalSubttlSubToTaxFre; // 売上小計非課税対象額
            target.SalesOutTax = source.SalesOutTax; // 売上金額消費税額（外税）
            target.SalAmntConsTaxInclu = source.SalAmntConsTaxInclu; // 売上金額消費税額（内税）
            target.SalesDisTtlTaxExc = source.SalesDisTtlTaxExc; // 売上値引金額計（税抜き）
            target.ItdedSalesDisOutTax = source.ItdedSalesDisOutTax; // 売上値引外税対象額合計
            target.ItdedSalesDisInTax = source.ItdedSalesDisInTax; // 売上値引内税対象額合計
            target.ItdedPartsDisOutTax = source.ItdedPartsDisOutTax; // 部品値引対象額合計（税抜き）
            target.ItdedPartsDisInTax = source.ItdedPartsDisInTax; // 部品値引対象額合計（税込み）
            target.ItdedWorkDisOutTax = source.ItdedWorkDisOutTax; // 作業値引対象額合計（税抜き）
            target.ItdedWorkDisInTax = source.ItdedWorkDisInTax; // 作業値引対象額合計（税込み）
            target.ItdedSalesDisTaxFre = source.ItdedSalesDisTaxFre; // 売上値引非課税対象額合計
            target.SalesDisOutTax = source.SalesDisOutTax; // 売上値引消費税額（外税）
            target.SalesDisTtlTaxInclu = source.SalesDisTtlTaxInclu; // 売上値引消費税額（内税）
            target.PartsDiscountRate = source.PartsDiscountRate; // 部品値引率
            target.RavorDiscountRate = source.RavorDiscountRate; // 工賃値引率
            target.TotalCost = source.TotalCost; // 原価金額計
            target.ConsTaxLayMethod = source.ConsTaxLayMethod; // 消費税転嫁方式
            target.ConsTaxRate = source.ConsTaxRate; // 消費税税率
            target.FractionProcCd = source.FractionProcCd; // 端数処理区分
            target.AccRecConsTax = source.AccRecConsTax; // 売掛消費税
            target.AutoDepositCd = source.AutoDepositCd; // 自動入金区分
            target.AutoDepositNoteDiv = source.AutoDepositNoteDiv; // 自動入金備考区分 // ADD 2013/01/18 田建委 Redmine#33797
            target.AutoDepositSlipNo = source.AutoDepositSlipNo; // 自動入金伝票番号
            target.DepositAllowanceTtl = source.DepositAllowanceTtl; // 入金引当合計額
            target.DepositAlwcBlnce = source.DepositAlwcBlnce; // 入金引当残高
            target.ClaimCode = source.ClaimCode; // 請求先コード
            target.ClaimSnm = source.ClaimSnm; // 請求先略称
            target.CustomerCode = source.CustomerCode; // 得意先コード
            target.CustomerName = source.CustomerName; // 得意先名称
            target.CustomerName2 = source.CustomerName2; // 得意先名称2
            target.CustomerSnm = source.CustomerSnm; // 得意先略称
            target.HonorificTitle = source.HonorificTitle; // 敬称
            target.OutputNameCode = source.OutputNameCode; // 諸口コード
            target.OutputName = source.OutputName; // 諸口名称
            target.CustSlipNo = source.CustSlipNo; // 得意先伝票番号
            target.SlipAddressDiv = source.SlipAddressDiv; // 伝票住所区分
            target.AddresseeCode = source.AddresseeCode; // 納品先コード
            target.AddresseeName = source.AddresseeName; // 納品先名称
            target.AddresseeName2 = source.AddresseeName2; // 納品先名称2
            target.AddresseePostNo = source.AddresseePostNo; // 納品先郵便番号
            target.AddresseeAddr1 = source.AddresseeAddr1; // 納品先住所1(都道府県市区郡・町村・字)
            target.AddresseeAddr3 = source.AddresseeAddr3; // 納品先住所3(番地)
            target.AddresseeAddr4 = source.AddresseeAddr4; // 納品先住所4(アパート名称)
            target.AddresseeTelNo = source.AddresseeTelNo; // 納品先電話番号
            target.AddresseeFaxNo = source.AddresseeFaxNo; // 納品先FAX番号
            target.PartySaleSlipNum = source.PartySaleSlipNum; // 相手先伝票番号
            target.SlipNote = source.SlipNote; // 伝票備考
            target.SlipNote2 = source.SlipNote2; // 伝票備考２
            target.SlipNote3 = source.SlipNote3; // 伝票備考３
            target.RetGoodsReasonDiv = source.RetGoodsReasonDiv; // 返品理由コード
            target.RetGoodsReason = source.RetGoodsReason; // 返品理由
            target.RegiProcDate = source.RegiProcDate; // レジ処理日
            target.CashRegisterNo = source.CashRegisterNo; // レジ番号
            target.PosReceiptNo = source.PosReceiptNo; // POSレシート番号
            target.DetailRowCount = source.DetailRowCount; // 明細行数
            target.EdiSendDate = source.EdiSendDate; // ＥＤＩ送信日
            target.EdiTakeInDate = source.EdiTakeInDate; // ＥＤＩ取込日
            target.UoeRemark1 = source.UoeRemark1; // ＵＯＥリマーク１
            target.UoeRemark2 = source.UoeRemark2; // ＵＯＥリマーク２
            target.SlipPrintDivCd = source.SlipPrintDivCd; // 伝票発行区分
            target.SlipPrintFinishCd = source.SlipPrintFinishCd; // 伝票発行済区分
            target.SalesSlipPrintDate = source.SalesSlipPrintDate; // 売上伝票発行日
            target.BusinessTypeCode = source.BusinessTypeCode; // 業種コード
            target.BusinessTypeName = source.BusinessTypeName; // 業種名称
            target.OrderNumber = source.OrderNumber; // 発注番号
            target.DeliveredGoodsDiv = source.DeliveredGoodsDiv; // 納品区分
            target.DeliveredGoodsDivNm = source.DeliveredGoodsDivNm; // 納品区分名称
            target.SalesAreaCode = source.SalesAreaCode; // 販売エリアコード
            target.SalesAreaName = source.SalesAreaName; // 販売エリア名称
            target.ReconcileFlag = source.ReconcileFlag; // 消込フラグ
            target.SlipPrtSetPaperId = source.SlipPrtSetPaperId; // 伝票印刷設定用帳票ID
            target.CompleteCd = source.CompleteCd; // 一式伝票区分
            target.SalesPriceFracProcCd = source.SalesPriceFracProcCd; // 売上金額端数処理区分
            target.StockGoodsTtlTaxExc = source.StockGoodsTtlTaxExc; // 在庫商品合計金額（税抜）
            target.PureGoodsTtlTaxExc = source.PureGoodsTtlTaxExc; // 純正商品合計金額（税抜）
            target.ListPricePrintDiv = source.ListPricePrintDiv; // 定価印刷区分
            target.EraNameDispCd1 = source.EraNameDispCd1; // 元号表示区分１
            target.EstimaTaxDivCd = source.EstimaTaxDivCd; // 見積消費税区分
            target.EstimateFormPrtCd = source.EstimateFormPrtCd; // 見積書印刷区分
            target.EstimateSubject = source.EstimateSubject; // 見積件名
            target.Footnotes1 = source.Footnotes1; // 脚注１
            target.Footnotes2 = source.Footnotes2; // 脚注２
            target.EstimateTitle1 = source.EstimateTitle1; // 見積タイトル１
            target.EstimateTitle2 = source.EstimateTitle2; // 見積タイトル２
            target.EstimateTitle3 = source.EstimateTitle3; // 見積タイトル３
            target.EstimateTitle4 = source.EstimateTitle4; // 見積タイトル４
            target.EstimateTitle5 = source.EstimateTitle5; // 見積タイトル５
            target.EstimateNote1 = source.EstimateNote1; // 見積備考１
            target.EstimateNote2 = source.EstimateNote2; // 見積備考２
            target.EstimateNote3 = source.EstimateNote3; // 見積備考３
            target.EstimateNote4 = source.EstimateNote4; // 見積備考４
            target.EstimateNote5 = source.EstimateNote5; // 見積備考５
            target.EstimateValidityDate = source.EstimateValidityDate; // 見積有効期限
            target.PartsNoPrtCd = source.PartsNoPrtCd; // 品番印字区分
            target.OptionPringDivCd = source.OptionPringDivCd; // オプション印字区分
            target.RateUseCode = source.RateUseCode; // 掛率使用区分
            target.InputMode = source.InputMode; // 入力モード
            target.SalesSlipDisplay = source.SalesSlipDisplay; // 売上伝票区分(画面表示用)
            target.AcptAnOdrStatusDisplay = source.AcptAnOdrStatusDisplay; // 受注ステータス
            target.CustRateGrpCode = source.CustRateGrpCode; // 得意先掛率グループコード
            target.ClaimName = source.ClaimName; // 請求先名称
            target.ClaimName2 = source.ClaimName2; // 請求先名称２
            target.CreditMngCode = source.CreditMngCode; // 与信管理区分
            target.TotalDay = source.TotalDay; // 締日
            target.NTimeCalcStDate = source.NTimeCalcStDate; // 次回勘定開始日
            target.TotalMoneyForGrossProfit = source.TotalMoneyForGrossProfit; // 粗利計算用売上金額
            target.SectionName = source.SectionName; // 拠点名称
            target.SubSectionName = source.SubSectionName; // 部門名称
            target.CarMngDivCd = source.CarMngDivCd; // 車輌管理区分
            target.SearchMode = source.SearchMode; // 部品検索モード
            target.SearchCarMode = source.SearchCarMode; // 車両検索モード
            target.CustOrderNoDispDiv = source.CustOrderNoDispDiv; // 得意先注番表示区分
            target.CustWarehouseCd = source.CustWarehouseCd; // 得意先優先倉庫コード
            target.AccRecDivCd = source.AccRecDivCd; // 売掛区分
            target.TransStopDate = source.TransStopDate; // 取引中止日
        }

        /// <summary>
        /// 項目コピー処理
        /// </summary>
        /// <param name="source">コピー元売上明細データオブジェクト</param>
        /// <param name="target">コピー先売上明細データオブジェクト</param>
        private static void CopyItemProc(SalesDetail source, ref SalesDetail target)
        {
            target.CreateDateTime = source.CreateDateTime; // 作成日時
            target.UpdateDateTime = source.UpdateDateTime; // 更新日時
            target.EnterpriseCode = source.EnterpriseCode; // 企業コード
            target.FileHeaderGuid = source.FileHeaderGuid; // GUID
            target.UpdEmployeeCode = source.UpdEmployeeCode; // 更新従業員コード
            target.UpdAssemblyId1 = source.UpdAssemblyId1; // 更新アセンブリID1
            target.UpdAssemblyId2 = source.UpdAssemblyId2; // 更新アセンブリID2
            target.LogicalDeleteCode = source.LogicalDeleteCode; // 論理削除区分
            target.AcceptAnOrderNo = source.AcceptAnOrderNo; // 受注番号
            target.AcptAnOdrStatus = source.AcptAnOdrStatus; // 受注ステータス
            target.SalesSlipNum = source.SalesSlipNum; // 売上伝票番号
            target.SalesRowNo = source.SalesRowNo; // 売上行番号
            target.SalesRowDerivNo = source.SalesRowDerivNo; // 売上行番号枝番
            target.SectionCode = source.SectionCode; // 拠点コード
            target.SubSectionCode = source.SubSectionCode; // 部門コード
            target.SalesDate = source.SalesDate; // 売上日付
            target.CommonSeqNo = source.CommonSeqNo; // 共通通番
            target.SalesSlipDtlNum = source.SalesSlipDtlNum; // 売上明細通番
            target.AcptAnOdrStatusSrc = source.AcptAnOdrStatusSrc; // 受注ステータス（元）
            target.SalesSlipDtlNumSrc = source.SalesSlipDtlNumSrc; // 売上明細通番（元）
            target.SupplierFormalSync = source.SupplierFormalSync; // 仕入形式（同時）
            target.StockSlipDtlNumSync = source.StockSlipDtlNumSync; // 仕入明細通番（同時）
            target.SalesSlipCdDtl = source.SalesSlipCdDtl; // 売上伝票区分（明細）
            target.DeliGdsCmpltDueDate = source.DeliGdsCmpltDueDate; // 納品完了予定日
            target.GoodsKindCode = source.GoodsKindCode; // 商品属性
            target.GoodsSearchDivCd = source.GoodsSearchDivCd; // 商品検索区分
            target.GoodsMakerCd = source.GoodsMakerCd; // 商品メーカーコード
            target.MakerName = source.MakerName; // メーカー名称
            target.MakerKanaName = source.MakerKanaName; // メーカーカナ名称
            target.CmpltMakerKanaName = source.CmpltMakerKanaName; // メーカーカナ名称（一式）
            target.GoodsNo = source.GoodsNo; // 商品番号
            target.GoodsName = source.GoodsName; // 商品名称
            target.GoodsNameKana = source.GoodsNameKana; // 商品名称カナ
            target.GoodsLGroup = source.GoodsLGroup; // 商品大分類コード
            target.GoodsLGroupName = source.GoodsLGroupName; // 商品大分類名称
            target.GoodsMGroup = source.GoodsMGroup; // 商品中分類コード
            target.GoodsMGroupName = source.GoodsMGroupName; // 商品中分類名称
            target.BLGroupCode = source.BLGroupCode; // BLグループコード
            target.BLGroupName = source.BLGroupName; // BLグループコード名称
            target.BLGoodsCode = source.BLGoodsCode; // BL商品コード
            target.BLGoodsFullName = source.BLGoodsFullName; // BL商品コード名称（全角）
            target.EnterpriseGanreCode = source.EnterpriseGanreCode; // 自社分類コード
            target.EnterpriseGanreName = source.EnterpriseGanreName; // 自社分類名称
            target.WarehouseCode = source.WarehouseCode; // 倉庫コード
            target.WarehouseName = source.WarehouseName; // 倉庫名称
            target.WarehouseShelfNo = source.WarehouseShelfNo; // 倉庫棚番
            target.SalesOrderDivCd = source.SalesOrderDivCd; // 売上在庫取寄せ区分
            target.OpenPriceDiv = source.OpenPriceDiv; // オープン価格区分
            target.GoodsRateRank = source.GoodsRateRank; // 商品掛率ランク
            target.CustRateGrpCode = source.CustRateGrpCode; // 得意先掛率グループコード
            target.ListPriceRate = source.ListPriceRate; // 定価率
            target.RateSectPriceUnPrc = source.RateSectPriceUnPrc; // 掛率設定拠点（定価）
            target.RateDivLPrice = source.RateDivLPrice; // 掛率設定区分（定価）
            target.PriceSelectDiv = source.PriceSelectDiv; // 標準価格選択区分（定価）// ADD 2013/01/24 鄧潘ハン REDMINE#34605
            target.UnPrcCalcCdLPrice = source.UnPrcCalcCdLPrice; // 単価算出区分（定価）
            target.PriceCdLPrice = source.PriceCdLPrice; // 価格区分（定価）
            target.StdUnPrcLPrice = source.StdUnPrcLPrice; // 基準単価（定価）
            target.FracProcUnitLPrice = source.FracProcUnitLPrice; // 端数処理単位（定価）
            target.FracProcLPrice = source.FracProcLPrice; // 端数処理（定価）
            target.ListPriceTaxIncFl = source.ListPriceTaxIncFl; // 定価（税込，浮動）
            target.ListPriceTaxExcFl = source.ListPriceTaxExcFl; // 定価（税抜，浮動）
            target.ListPriceChngCd = source.ListPriceChngCd; // 定価変更区分
            target.SalesRate = source.SalesRate; // 売価率
            target.RateSectSalUnPrc = source.RateSectSalUnPrc; // 掛率設定拠点（売上単価）
            target.RateDivSalUnPrc = source.RateDivSalUnPrc; // 掛率設定区分（売上単価）
            target.UnPrcCalcCdSalUnPrc = source.UnPrcCalcCdSalUnPrc; // 単価算出区分（売上単価）
            target.PriceCdSalUnPrc = source.PriceCdSalUnPrc; // 価格区分（売上単価）
            target.StdUnPrcSalUnPrc = source.StdUnPrcSalUnPrc; // 基準単価（売上単価）
            target.FracProcUnitSalUnPrc = source.FracProcUnitSalUnPrc; // 端数処理単位（売上単価）
            target.FracProcSalUnPrc = source.FracProcSalUnPrc; // 端数処理（売上単価）
            target.SalesUnPrcTaxIncFl = source.SalesUnPrcTaxIncFl; // 売上単価（税込，浮動）
            target.SalesUnPrcTaxExcFl = source.SalesUnPrcTaxExcFl; // 売上単価（税抜，浮動）
            target.SalesUnPrcChngCd = source.SalesUnPrcChngCd; // 売上単価変更区分
            target.CostRate = source.CostRate; // 原価率
            target.RateSectCstUnPrc = source.RateSectCstUnPrc; // 掛率設定拠点（原価単価）
            target.RateDivUnCst = source.RateDivUnCst; // 掛率設定区分（原価単価）
            target.UnPrcCalcCdUnCst = source.UnPrcCalcCdUnCst; // 単価算出区分（原価単価）
            target.PriceCdUnCst = source.PriceCdUnCst; // 価格区分（原価単価）
            target.StdUnPrcUnCst = source.StdUnPrcUnCst; // 基準単価（原価単価）
            target.FracProcUnitUnCst = source.FracProcUnitUnCst; // 端数処理単位（原価単価）
            target.FracProcUnCst = source.FracProcUnCst; // 端数処理（原価単価）
            target.SalesUnitCost = source.SalesUnitCost; // 原価単価
            target.SalesUnitCostChngDiv = source.SalesUnitCostChngDiv; // 原価単価変更区分
            target.RateBLGoodsCode = source.RateBLGoodsCode; // BL商品コード（掛率）
            target.RateBLGoodsName = source.RateBLGoodsName; // BL商品コード名称（掛率）
            target.RateGoodsRateGrpCd = source.RateGoodsRateGrpCd; // 商品掛率グループコード（掛率）
            target.RateGoodsRateGrpNm = source.RateGoodsRateGrpNm; // 商品掛率グループ名称（掛率）
            target.RateBLGroupCode = source.RateBLGroupCode; // BLグループコード（掛率）
            target.RateBLGroupName = source.RateBLGroupName; // BLグループ名称（掛率）
            target.PrtBLGoodsCode = source.PrtBLGoodsCode; // BL商品コード（印刷）
            target.PrtBLGoodsName = source.PrtBLGoodsName; // BL商品コード名称（印刷）
            target.SalesCode = source.SalesCode; // 販売区分コード
            target.SalesCdNm = source.SalesCdNm; // 販売区分名称
            target.WorkManHour = source.WorkManHour; // 作業工数
            target.ShipmentCnt = source.ShipmentCnt; // 出荷数
            target.AcceptAnOrderCnt = source.AcceptAnOrderCnt; // 受注数量
            target.AcptAnOdrAdjustCnt = source.AcptAnOdrAdjustCnt; // 受注調整数
            target.AcptAnOdrRemainCnt = source.AcptAnOdrRemainCnt; // 受注残数
            target.RemainCntUpdDate = source.RemainCntUpdDate; // 残数更新日
            target.SalesMoneyTaxInc = source.SalesMoneyTaxInc; // 売上金額（税込み）
            target.SalesMoneyTaxExc = source.SalesMoneyTaxExc; // 売上金額（税抜き）
            target.Cost = source.Cost; // 原価
            target.GrsProfitChkDiv = source.GrsProfitChkDiv; // 粗利チェック区分
            target.SalesGoodsCd = source.SalesGoodsCd; // 売上商品区分
            target.SalesPriceConsTax = source.SalesPriceConsTax; // 売上金額消費税額
            target.TaxationDivCd = source.TaxationDivCd; // 課税区分
            target.PartySlipNumDtl = source.PartySlipNumDtl; // 相手先伝票番号（明細）
            target.DtlNote = source.DtlNote; // 明細備考
            target.SupplierCd = source.SupplierCd; // 仕入先コード
            target.SupplierSnm = source.SupplierSnm; // 仕入先略称
            target.OrderNumber = source.OrderNumber; // 発注番号
            target.WayToOrder = source.WayToOrder; // 注文方法
            target.SlipMemo1 = source.SlipMemo1; // 伝票メモ１
            target.SlipMemo2 = source.SlipMemo2; // 伝票メモ２
            target.SlipMemo3 = source.SlipMemo3; // 伝票メモ３
            target.InsideMemo1 = source.InsideMemo1; // 社内メモ１
            target.InsideMemo2 = source.InsideMemo2; // 社内メモ２
            target.InsideMemo3 = source.InsideMemo3; // 社内メモ３
            target.BfListPrice = source.BfListPrice; // 変更前定価
            target.BfSalesUnitPrice = source.BfSalesUnitPrice; // 変更前売価
            target.BfUnitCost = source.BfUnitCost; // 変更前原価
            target.CmpltSalesRowNo = source.CmpltSalesRowNo; // 一式明細番号
            target.CmpltGoodsMakerCd = source.CmpltGoodsMakerCd; // メーカーコード（一式）
            target.CmpltMakerName = source.CmpltMakerName; // メーカー名称（一式）
            target.CmpltGoodsName = source.CmpltGoodsName; // 商品名称（一式）
            target.CmpltShipmentCnt = source.CmpltShipmentCnt; // 数量（一式）
            target.CmpltSalesUnPrcFl = source.CmpltSalesUnPrcFl; // 売上単価（一式）
            target.CmpltSalesMoney = source.CmpltSalesMoney; // 売上金額（一式）
            target.CmpltSalesUnitCost = source.CmpltSalesUnitCost; // 原価単価（一式）
            target.CmpltCost = source.CmpltCost; // 原価金額（一式）
            target.CmpltPartySalSlNum = source.CmpltPartySalSlNum; // 相手先伝票番号（一式）
            target.CmpltNote = source.CmpltNote; // 一式備考
            // --- ADD 2009/10/19 ---------->>>>>
            target.SelectedGoodsNoDiv = source.SelectedGoodsNoDiv; // 印刷用品番有効区分
            // --- ADD 2009/10/19 ----------<<<<<
            target.PrtGoodsNo = source.PrtGoodsNo; // 印刷用品番
            target.PrtMakerCode = source.PrtMakerCode; // 印刷用メーカコード
            target.PrtMakerName = source.PrtMakerName; // 印刷用メーカー名称
            target.DtlRelationGuid = source.DtlRelationGuid; // 共通キー
            target.CarRelationGuid = source.CarRelationGuid; // 車両情報共通キー
            //>>>2010/02/26
            target.CampaignCode = source.CampaignCode;
            target.CampaignName = source.CampaignName;
            target.GoodsDivCd = source.GoodsDivCd;
            target.AnswerDelivDate = source.AnswerDelivDate;
            target.RecycleDiv = source.RecycleDiv;
            target.RecycleDivNm = source.RecycleDivNm;
            target.WayToAcptOdr = source.WayToAcptOdr;
            target.DtlRelationGuid = source.DtlRelationGuid; // 共通キー
            target.DtlRelationGuid = source.DtlRelationGuid; // 共通キー
            //<<<2010/02/26
            // 2012/01/16 Add >>>
            target.GoodsSpecialNote = source.GoodsSpecialNote; // 特記事項
            // 2012/01/16 Add <<<
            //>>>2012/05/02
            target.RentSyncStockDate = source.RentSyncStockDate;
            target.RentSyncSupplier = source.RentSyncSupplier;
            target.RentSyncSupSlipNo = source.RentSyncSupSlipNo;
            //<<<2012/05/02
        }
        #endregion
    }

    /// <summary>
    /// CustomSerializeArrayList分解クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : CustomSerializeArrayListの分解処理を行います。</br>
    /// <br>Programmer : 20056 對馬　大輔</br>
    /// <br>Date       : 2008.09.24</br>
    /// <br></br>
    /// <br>UpDate</br>
    /// <br>2008.09.24 對馬　大輔  新規作成</br>
    /// </remarks>
    public class DivisionSalesSlipCustomSerializeArrayList
    {
        #region ■Public Static Methods
        /// <summary>
        /// CustomSerializeArrayListを各種データオブジェクトに分割します。（書込用）
        /// </summary>
        /// <param name="paraList">データ結合リスト</param>
        /// <param name="salesDataList">売上データリスト</param>
        /// <param name="acptDataList">受注データリスト</param>
        /// <param name="stockSlipInfoList">仕入データリスト</param>
        public static void DivisionCustomSerializeArrayListForWriting(CustomSerializeArrayList paraList, out ArrayList salesDataList, out ArrayList acptDataList, out ArrayList stockSlipInfoList)
        {
            ArrayList uoeOrderDataList;
            DivisionCustomSerializeArrayListForWritingProc(paraList, out salesDataList, out acptDataList, out stockSlipInfoList, out uoeOrderDataList);
        }

        /// <summary>
        /// CustomSerializeArrayListを各種データオブジェクトに分割します。（書込用）
        /// </summary>
        /// <param name="paraList">データ結合リスト</param>
        /// <param name="salesDataList">売上データリスト</param>
        /// <param name="acptDataList">受注データリスト</param>
        /// <param name="stockSlipInfoList">仕入データリスト</param>
        /// <param name="uoeOrderDataList">UOE発注データリスト</param>
        public static void DivisionCustomSerializeArrayListForWriting(CustomSerializeArrayList paraList, out ArrayList salesDataList, out ArrayList acptDataList, out ArrayList stockSlipInfoList, out ArrayList uoeOrderDataList)
        {
            DivisionCustomSerializeArrayListForWritingProc(paraList, out salesDataList, out acptDataList, out stockSlipInfoList, out uoeOrderDataList);
        }

        /// <summary>
        /// CustomSerializeArrayListを各種データオブジェクトに分割します。（書込用）
        /// </summary>
        /// <param name="paraList">カスタムシリアライズリストオブジェクト</param>
        /// <param name="salesSlipWork">売上データワークオブジェクトリスト</param>
        /// <param name="salesDetailWorkArray">売上明細データワークオブジェクト配列</param>
        /// <param name="stockWorkArray">在庫ワークオブジェクト配列</param>
        /// <param name="acceptOdrCarWorkArray">受注マスタ（車両）ワークオブジェクト配列</param>
        public static void DivisionCustomSerializeArrayListForWriting(CustomSerializeArrayList paraList, out SalesSlipWork salesSlipWork, out SalesDetailWork[] salesDetailWorkArray, out StockWork[] stockWorkArray, out AcceptOdrCarWork[] acceptOdrCarWorkArray)
        {
            DivisionCustomSerializeArrayListForWritingProc(paraList, out salesSlipWork, out salesDetailWorkArray, out stockWorkArray, out acceptOdrCarWorkArray);
        }

        /// <summary>
        /// CustomSerializeArrayListを各種データオブジェクトに分割します。（書込用）
        /// </summary>
        /// <param name="paraList">カスタムシリアライズリストオブジェクト</param>
        /// <param name="salesSlipWork">売上データワークオブジェクト</param>
        /// <param name="salesDetailWorkArray">売上明細データワークオブジェクト配列</param>
        /// <param name="addUppOrgSalesDetailWorkArray">計上元売上明細データワークオブジェクト配列</param>
        /// <param name="depsitDataWork">入金データオブジェクト</param>
        /// <param name="depositAlwWork">入金引当データオブジェクト</param>
        /// <param name="stockWorkArray">在庫ワークオブジェクト配列</param>        
        /// <param name="acceptOdrCarWorkArray">受注マスタ（車両）ワークオブジェクト配列</param>
        public static void DivisionCustomSerializeArrayListForWriting(CustomSerializeArrayList paraList, out SalesSlipWork salesSlipWork, out SalesDetailWork[] salesDetailWorkArray, out AddUpOrgSalesDetailWork[] addUpOrgSalesDetailWorkArray, out DepsitDataWork depsitDataWork, out DepositAlwWork depositAlwWork, out StockWork[] stockWorkArray, out AcceptOdrCarWork[] acceptOdrCarWorkArray)
        {
            DivisionSalesSlipCustomSerializeArrayList.DivisionCustomSerializeArrayList(paraList, out salesSlipWork, out salesDetailWorkArray, out addUpOrgSalesDetailWorkArray, out depsitDataWork, out depositAlwWork, out stockWorkArray, out acceptOdrCarWorkArray);
        }

        //>>>2010/02/26
        /// <summary>
        /// CustomSerializeArrayListを各種データオブジェクトに分割します。（書込用）
        /// </summary>
        /// <param name="paraList">カスタムシリアライズリストオブジェクト</param>
        /// <param name="salesSlipWork">売上データワークオブジェクト</param>
        /// <param name="salesDetailWorkArray">売上明細データワークオブジェクト配列</param>
        /// <param name="addUppOrgSalesDetailWorkArray">計上元売上明細データワークオブジェクト配列</param>
        /// <param name="depsitDataWork">入金データオブジェクト</param>
        /// <param name="depositAlwWork">入金引当データオブジェクト</param>
        /// <param name="stockWorkArray">在庫ワークオブジェクト配列</param>        
        /// <param name="acceptOdrCarWorkArray">受注マスタ（車両）ワークオブジェクト配列</param>
        public static void DivisionCustomSerializeArrayListForWriting(CustomSerializeArrayList paraList, out SalesSlipWork salesSlipWork, out SalesDetailWork[] salesDetailWorkArray, out AddUpOrgSalesDetailWork[] addUpOrgSalesDetailWorkArray, out DepsitDataWork depsitDataWork, out DepositAlwWork depositAlwWork, out StockWork[] stockWorkArray, out AcceptOdrCarWork[] acceptOdrCarWorkArray, out SCMAcOdrDataWork scmAcOdrDataWork, out SCMAcOdrDtlIqWork[] scmAcOdrDataWorkArray, out SCMAcOdrDtlAsWork[] scmAcOdrDtlAsWorkArray, out SCMAcOdrDtCarWork scmAcOdrDtCarWork)
        {
            DivisionSalesSlipCustomSerializeArrayList.DivisionCustomSerializeArrayList(paraList, out salesSlipWork, out salesDetailWorkArray, out addUpOrgSalesDetailWorkArray, out depsitDataWork, out depositAlwWork, out stockWorkArray, out acceptOdrCarWorkArray, out scmAcOdrDataWork, out scmAcOdrDataWorkArray, out scmAcOdrDtlAsWorkArray, out scmAcOdrDtCarWork);
        }
        //<<<2010/02/26

        /// <summary>
        /// CustomSerializeArrayListを各種データオブジェクトに分割します。（読込用）
        /// </summary>
        /// <param name="paraList1">カスタムシリアライズリストオブジェクト(親データ)</param>
        /// <param name="salesSlipWork">売上データワークオブジェクト</param>
        /// <param name="salesDetailWorkArray">売上明細データワークオブジェクト配列</param>
        /// <param name="stockWorkArray">在庫ワークオブジェクト配列</param>
        /// <param name="acceptOdrCarWorkArray">受注マスタ（車両）ワークオブジェクト配列</param>
        public static void DivisionCustomSerializeArrayListForReading(CustomSerializeArrayList paraList1, out SalesSlipWork salesSlipWork, out SalesDetailWork[] salesDetailWorkArray, out StockWork[] stockWorkArray, out AcceptOdrCarWork[] acceptOdrCarWorkArray)
        {
            AddUpOrgSalesDetailWork[] addUpOrgSalesDetailWorkArray;
            DepsitDataWork depsitDataWork;
            DepositAlwWork depositAlwWork;
            List<StockSlipWork> stockSlipWorkList;
            List<StockDetailWork> stockDetailWrokList;
            List<AddUpOrgStockDetailWork> addUpOrgStockDetailWorkList;

            DivisionSalesSlipCustomSerializeArrayList.DivisionCustomSerializeArrayListForReading(paraList1, null, out salesSlipWork, out salesDetailWorkArray, out addUpOrgSalesDetailWorkArray, out depsitDataWork, out depositAlwWork, out stockSlipWorkList, out stockDetailWrokList, out addUpOrgStockDetailWorkList, out stockWorkArray, out acceptOdrCarWorkArray);
        }

        /// <summary>
        /// CustomSerializeArrayListを各種データオブジェクトに分割します。（読込用）
        /// </summary>
        /// <param name="paraList1">カスタムシリアライズリストオブジェクト(親データ)</param>
        /// <param name="paraList2">カスタムシリアライズリストオブジェクト(計上元／同時入力データ)</param>
        /// <param name="salesSlipWork">売上データワークオブジェクト</param>
        /// <param name="salesDetailWorkArray">売上明細データワークオブジェクト配列</param>
        /// <param name="addUppOrgSalesDetailWorkArray">計上元明細データワークオブジェクト配列</param>
        /// <param name="depsitDataWork">入金データワークオブジェクト</param>
        /// <param name="depositAlwWork">入金引当データワークオブジェクト</param>
        /// <param name="stockSlipWorkList">同時入力データワークオブジェクトリスト</param>
        /// <param name="stockDetailWrokList">同時入力明細データワークオブジェクトリスト</param>
        /// <param name="addUpOrgStockDetailWorkList">同時入力計上元仕入明細データワークリスト</param>
        /// <param name="stockWorkArray">在庫ワークオブジェクト配列</param>        
        /// <param name="acceptOdrCarWorkArray">受注マスタ（車両）ワークオブジェクト配列</param>
        public static void DivisionCustomSerializeArrayListForReading(CustomSerializeArrayList paraList1, CustomSerializeArrayList paraList2, out SalesSlipWork salesSlipWork, out SalesDetailWork[] salesDetailWorkArray, out AddUpOrgSalesDetailWork[] addUpOrgSalesDetailWorkArray, out DepsitDataWork depsitDataWork, out DepositAlwWork depositAlwWork, out List<StockSlipWork> stockSlipWorkList, out List<StockDetailWork> stockDetailWrokList, out List<AddUpOrgStockDetailWork> addUpOrgStockDetailWorkList, out StockWork[] stockWorkArray, out AcceptOdrCarWork[] acceptOdrCarWorkArray)
        {
            UOEOrderDtlWork[] uoeOrderDtlWorkArray;
            //>>>2010/02/26
            UserSCMOrderHeaderRecord scmHeader;
            UserSCMOrderCarRecord scmCar;
            UserSCMOrderDetailRecord[] scmDetailList;
            UserSCMOrderAnswerRecord[] scmAnswerList;
            //<<<2010/02/26

            //>>>2010/02/26
            //DivisionCustomSerializeArrayListForReadingProc(paraList1, paraList2, out salesSlipWork, out salesDetailWorkArray, out addUpOrgSalesDetailWorkArray, out depsitDataWork, out depositAlwWork, out stockSlipWorkList, out stockDetailWrokList, out addUpOrgStockDetailWorkList, out stockWorkArray, out acceptOdrCarWorkArray, out uoeOrderDtlWorkArray);
            DivisionCustomSerializeArrayListForReadingProc(paraList1, paraList2, out salesSlipWork, out salesDetailWorkArray, out addUpOrgSalesDetailWorkArray, out depsitDataWork, out depositAlwWork, out stockSlipWorkList, out stockDetailWrokList, out addUpOrgStockDetailWorkList, out stockWorkArray, out acceptOdrCarWorkArray, out uoeOrderDtlWorkArray, out scmHeader, out scmCar, out scmDetailList, out scmAnswerList);
            //<<<2010/02/26
        }

        /// <summary>
        /// CustomSerializeArrayListを各種データオブジェクトに分割します。（読込用）
        /// </summary>
        /// <param name="paraList1">カスタムシリアライズリストオブジェクト(親データ)</param>
        /// <param name="paraList2">カスタムシリアライズリストオブジェクト(計上元／同時入力データ)</param>
        /// <param name="salesSlipWork">売上データワークオブジェクト</param>
        /// <param name="salesDetailWorkArray">売上明細データワークオブジェクト配列</param>
        /// <param name="addUppOrgSalesDetailWorkArray">計上元明細データワークオブジェクト配列</param>
        /// <param name="depsitDataWork">入金データワークオブジェクト</param>
        /// <param name="depositAlwWork">入金引当データワークオブジェクト</param>
        /// <param name="stockSlipWorkList">同時入力データワークオブジェクトリスト</param>
        /// <param name="stockDetailWrokList">同時入力明細データワークオブジェクトリスト</param>
        /// <param name="addUpOrgStockDetailWorkList">同時入力計上元仕入明細データワークリスト</param>
        /// <param name="stockWorkArray">在庫ワークオブジェクト配列</param>        
        /// <param name="acceptOdrCarWorkArray">受注マスタ（車両）ワークオブジェクト配列</param>
        /// <param name="uoeOrderDtlWorkArray">UOE発注データオブジェクト配列</param>
        //>>>2010/02/26
        //public static void DivisionCustomSerializeArrayListForReading(CustomSerializeArrayList paraList1, CustomSerializeArrayList paraList2, out SalesSlipWork salesSlipWork, out SalesDetailWork[] salesDetailWorkArray, out AddUpOrgSalesDetailWork[] addUpOrgSalesDetailWorkArray, out DepsitDataWork depsitDataWork, out DepositAlwWork depositAlwWork, out List<StockSlipWork> stockSlipWorkList, out List<StockDetailWork> stockDetailWrokList, out List<AddUpOrgStockDetailWork> addUpOrgStockDetailWorkList, out StockWork[] stockWorkArray, out AcceptOdrCarWork[] acceptOdrCarWorkArray, out UOEOrderDtlWork[] uoeOrderDtlWorkArray)
        public static void DivisionCustomSerializeArrayListForReading(CustomSerializeArrayList paraList1, CustomSerializeArrayList paraList2, out SalesSlipWork salesSlipWork, out SalesDetailWork[] salesDetailWorkArray, out AddUpOrgSalesDetailWork[] addUpOrgSalesDetailWorkArray, out DepsitDataWork depsitDataWork, out DepositAlwWork depositAlwWork, out List<StockSlipWork> stockSlipWorkList, out List<StockDetailWork> stockDetailWrokList, out List<AddUpOrgStockDetailWork> addUpOrgStockDetailWorkList, out StockWork[] stockWorkArray, out AcceptOdrCarWork[] acceptOdrCarWorkArray, out UOEOrderDtlWork[] uoeOrderDtlWorkArray, out UserSCMOrderHeaderRecord scmHeader, out UserSCMOrderCarRecord scmCar, out UserSCMOrderDetailRecord[] scmDetailList, out UserSCMOrderAnswerRecord[] scmAnswerList)
        //<<<2010/02/26
        {
            //>>>2010/02/26
            //DivisionCustomSerializeArrayListForReadingProc(paraList1, paraList2, out salesSlipWork, out salesDetailWorkArray, out addUpOrgSalesDetailWorkArray, out depsitDataWork, out depositAlwWork, out stockSlipWorkList, out stockDetailWrokList, out addUpOrgStockDetailWorkList, out stockWorkArray, out acceptOdrCarWorkArray, out uoeOrderDtlWorkArray);
            DivisionCustomSerializeArrayListForReadingProc(paraList1, paraList2, out salesSlipWork, out salesDetailWorkArray, out addUpOrgSalesDetailWorkArray, out depsitDataWork, out depositAlwWork, out stockSlipWorkList, out stockDetailWrokList, out addUpOrgStockDetailWorkList, out stockWorkArray, out acceptOdrCarWorkArray, out uoeOrderDtlWorkArray, out scmHeader, out scmCar, out scmDetailList, out scmAnswerList);
            //<<<2010/02/26
        }

        /// <summary>
        /// CustomSerializeArrayListを各種データオブジェクトに分割します。（明細読込用）
        /// </summary>
        /// <param name="paraList">カスタムシリアライズリストオブジェクト</param>
        /// <param name="paraList2">カスタムシリアライズリストオブジェクト</param>
        /// <param name="salesDetailWorkArray">売上明細データワークオブジェクト配列</param>
        /// <param name="acceptOdrCarWorkArray">受注マスタ（車両）ワークオブジェクト配列</param>
        /// <param name="stockSlipWorkArray">仕入データワークオブジェクト配列</param>
        /// <param name="stockDetailWorkArray">仕入明細データワークオブジェクト配列</param>
        public static void DivisionCustomSerializeArrayListForDetailsReading(CustomSerializeArrayList paraList, CustomSerializeArrayList paraList2, out SalesDetailWork[] salesDetailWorkArray, out AcceptOdrCarWork[] acceptOdrCarWorkArray, out StockSlipWork[] stockSlipWorkArray, out StockDetailWork[] stockDetailWorkArray)
        {
            UOEOrderDtlWork[] uoeOrderDtlWorkArray;
            DivisionCustomSerializeArrayListForDetailsReadingProc(paraList, paraList2, out salesDetailWorkArray, out acceptOdrCarWorkArray, out stockSlipWorkArray, out stockDetailWorkArray, out uoeOrderDtlWorkArray);
        }

        /// <summary>
        /// CustomSerializeArrayListを各種データオブジェクトに分割します。（明細読込用）
        /// </summary>
        /// <param name="paraList">カスタムシリアライズリストオブジェクト</param>
        /// <param name="paraList2">カスタムシリアライズリストオブジェクト</param>
        /// <param name="salesDetailWorkArray">売上明細データワークオブジェクト配列</param>
        /// <param name="acceptOdrCarWorkArray">受注マスタ（車両）ワークオブジェクト配列</param>
        /// <param name="stockSlipWorkArray">仕入データワークオブジェクト配列</param>
        /// <param name="stockDetailWorkArray">仕入明細データワークオブジェクト配列</param>
        /// <param name="uoeOrderDtlWorkArray">UOE発注データワークオブジェクト配列</param>
        public static void DivisionCustomSerializeArrayListForDetailsReading(CustomSerializeArrayList paraList, CustomSerializeArrayList paraList2, out SalesDetailWork[] salesDetailWorkArray, out AcceptOdrCarWork[] acceptOdrCarWorkArray, out StockSlipWork[] stockSlipWorkArray, out StockDetailWork[] stockDetailWorkArray, out UOEOrderDtlWork[] uoeOrderDtlWorkArray)
        {
            DivisionCustomSerializeArrayListForDetailsReadingProc(paraList, paraList2, out salesDetailWorkArray, out acceptOdrCarWorkArray, out stockSlipWorkArray, out stockDetailWorkArray, out uoeOrderDtlWorkArray);
        }
        #endregion

        #region ■Private Static Methods
        /// <summary>
        /// CustomSerializeArrayListを各種データオブジェクトに分割します。（Write後専用）
        /// </summary>
        /// <param name="paraList">データ結合リスト</param>
        /// <param name="salesDataList">売上データリスト</param>
        /// <param name="acptDataList">受注データリスト</param>
        /// <param name="stockSlipInfoList">仕入データリスト</param>
        /// <param name="uoeOrderDataList">UOE発注データリスト</param>
        private static void DivisionCustomSerializeArrayListForWritingProc(CustomSerializeArrayList paraList, out ArrayList salesDataList, out ArrayList acptDataList, out ArrayList stockSlipInfoList, out ArrayList uoeOrderDataList)
        {
            //------------------------------------------------------------------------------------
            // ParaList構成
            //------------------------------------------------------------------------------------
            //  CustomSerializeArrayList            統合リスト
            //      --CustomSerializeArrayList      売上リスト
            //          --SalesSlipWork             売上データオブジェクト
            //          --ArrayList                 売上明細リスト
            //              --SalesDetailWork       売上明細データオブジェクト
            //          --DepsitMainWork            入金データオブジェクト
            //          --DepositAlwWork            入金引当データオブジェクト
            //      --CustomSerializeArrayList      受注リスト
            //          --SalesSlipWork             受注データオブジェクト
            //          --ArrayList                 受注明細リスト
            //              --SalesDetailWork       受注明細データオブジェクト
            //      --CustomSerializeArrayList      仕入リスト
            //          --StockSlipWork             仕入データオブジェクト
            //          --ArrayList                 仕入明細リスト
            //              --StockDetailWork       仕入明細データオブジェクト
            //          --PaymentSlpWork            支払データオブジェクト
            //      --CustomSerializeArrayList      入荷リスト
            //          --StockSlipWork             入荷データオブジェクト
            //          --ArrayList                 入荷明細リスト
            //              --StockDetailWork       入荷明細データオブジェクト
            //          --PaymentSlpWork            支払データオブジェクト
            //      --CustomSerializeArrayList      発注リスト
            //          --StockSlipWork             発注データオブジェクト(※リモート参照用。実データは作成されません。)
            //          --ArrayList                 発注明細リスト
            //              --StockDetailWork       発注明細データオブジェクト
            //------------------------------------------------------------------------------------

            salesDataList = new ArrayList();
            acptDataList = new ArrayList();
            stockSlipInfoList = new ArrayList();
            uoeOrderDataList = new ArrayList();

            for (int i = 0; i < paraList.Count; i++)
            {
                if (paraList[i] is CustomSerializeArrayList)
                {
                    CustomSerializeArrayList tempList = (CustomSerializeArrayList)paraList[i];
                    foreach (object tempObj in tempList)
                    {
                        //---------------------------------------
                        // 売上情報
                        //---------------------------------------
                        if (tempObj is SalesSlipWork)
                        {
                            SalesSlipWork tempWork = (SalesSlipWork)tempObj;
                            switch ((SalesSlipInputAcs.AcptAnOdrStatusState)tempWork.AcptAnOdrStatus)
                            {
                                case SalesSlipInputAcs.AcptAnOdrStatusState.Estimate:
                                case SalesSlipInputAcs.AcptAnOdrStatusState.UnitPriceEstimate:
                                    salesDataList.Add(tempList);
                                    break;
                                case SalesSlipInputAcs.AcptAnOdrStatusState.AcceptAnOrder:
                                    acptDataList.Add(tempList);
                                    break;
                                case SalesSlipInputAcs.AcptAnOdrStatusState.Sales:
                                case SalesSlipInputAcs.AcptAnOdrStatusState.Shipment:
                                    salesDataList.Add(tempList);
                                    break;
                            }
                        }
                        //---------------------------------------
                        // 仕入情報
                        //---------------------------------------
                        else if (tempObj is StockSlipWork)
                        {
                            stockSlipInfoList.Add(tempList);
                        }
                        //---------------------------------------
                        // 発注情報
                        //---------------------------------------
                        else if (tempObj is CustomSerializeArrayList)
                        {
                            CustomSerializeArrayList tempCSList = (CustomSerializeArrayList)tempObj;
                            if ((tempCSList.Count != 0) && (tempCSList[0] is UOEOrderDtlWork))
                            {
                                uoeOrderDataList.Add(tempList);
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// CustomSerializeArrayListを各種データオブジェクトに分割します。（Write後専用）
        /// </summary>
        /// <param name="paraList">カスタムシリアライズリストオブジェクト</param>
        /// <param name="salesSlipWork">売上データワークオブジェクト</param>
        /// <param name="salesDetailWorkArray">売上明細データワークオブジェクト配列</param>
        /// <param name="stockWorkArray">在庫ワークオブジェクト配列</param>
        /// <param name="acceptOdrCarWorkArray">受注マスタ（車両）オブジェクト配列</param>
        private static void DivisionCustomSerializeArrayListForWritingProc(CustomSerializeArrayList paraList, out SalesSlipWork salesSlipWork, out SalesDetailWork[] salesDetailWorkArray, out StockWork[] stockWorkArray, out AcceptOdrCarWork[] acceptOdrCarWorkArray)
        {
            AddUpOrgSalesDetailWork[] addUpOrgSalesDetailWorkArray;
            DepsitDataWork depsitDataWork;
            DepositAlwWork depositAlwWork;

            DivisionSalesSlipCustomSerializeArrayList.DivisionCustomSerializeArrayList(paraList, out salesSlipWork, out salesDetailWorkArray, out addUpOrgSalesDetailWorkArray, out depsitDataWork, out depositAlwWork, out stockWorkArray, out acceptOdrCarWorkArray);
        }

        /// <summary>
        /// CustomSerializeArrayListを各種データオブジェクトに分割します。（Read後専用）
        /// </summary>
        /// <param name="paraList1">カスタムシリアライズリストオブジェクト(親データ)</param>
        /// <param name="paraList2">カスタムシリアライズリストオブジェクト(計上元／同時入力データ)</param>
        /// <param name="salesSlipWork">売上データワークオブジェクト</param>
        /// <param name="salesDetailWorkArray">売上明細データワークオブジェクト配列</param>
        /// <param name="addUppOrgSalesDetailWorkArray">計上元明細データワークオブジェクト配列</param>
        /// <param name="depsitDataWork">入金データワークオブジェクト</param>
        /// <param name="depositAlwWork">入金引当データワークオブジェクト</param>
        /// <param name="stockSlipWorkList">同時入力データワークオブジェクトリスト</param>
        /// <param name="stockDetailWrokList">同時入力明細データワークオブジェクトリスト</param>
        /// <param name="addUpOrgStockDetailWorkList">同時入力計上元仕入明細データワークリスト</param>
        /// <param name="stockWorkArray">在庫ワークオブジェクト配列</param>        
        /// <param name="acceptOdrCarWorkArray">受注マスタ（車両）ワークオブジェクト配列</param>
        /// <param name="uoeOrderDtlWorkArray">UOE発注データオブジェクト配列</param>
        //>>>2010/02/26
        //private static void DivisionCustomSerializeArrayListForReadingProc(CustomSerializeArrayList paraList1, CustomSerializeArrayList paraList2, out SalesSlipWork salesSlipWork, out SalesDetailWork[] salesDetailWorkArray, out AddUpOrgSalesDetailWork[] addUpOrgSalesDetailWorkArray, out DepsitDataWork depsitDataWork, out DepositAlwWork depositAlwWork, out List<StockSlipWork> stockSlipWorkList, out List<StockDetailWork> stockDetailWrokList, out List<AddUpOrgStockDetailWork> addUpOrgStockDetailWorkList, out StockWork[] stockWorkArray, out AcceptOdrCarWork[] acceptOdrCarWorkArray, out UOEOrderDtlWork[] uoeOrderDtlWorkArray)
        private static void DivisionCustomSerializeArrayListForReadingProc(CustomSerializeArrayList paraList1, CustomSerializeArrayList paraList2, out SalesSlipWork salesSlipWork, out SalesDetailWork[] salesDetailWorkArray, out AddUpOrgSalesDetailWork[] addUpOrgSalesDetailWorkArray, out DepsitDataWork depsitDataWork, out DepositAlwWork depositAlwWork, out List<StockSlipWork> stockSlipWorkList, out List<StockDetailWork> stockDetailWrokList, out List<AddUpOrgStockDetailWork> addUpOrgStockDetailWorkList, out StockWork[] stockWorkArray, out AcceptOdrCarWork[] acceptOdrCarWorkArray, out UOEOrderDtlWork[] uoeOrderDtlWorkArray, out UserSCMOrderHeaderRecord scmHeader, out UserSCMOrderCarRecord scmCar, out UserSCMOrderDetailRecord[] scmDetailList, out UserSCMOrderAnswerRecord[] scmAnswerList)
        //<<<2010/02/26
        {
            //-----------------------------------------------------------------------------------------------------------------------
            // ParaList構成
            //-----------------------------------------------------------------------------------------------------------------------
            //  CustomSerializeArrayList                売上情報リスト(第１パラメータ ParaList1)
            //    --SalesSlipWork                       売上データ                              →親データ
            //    --ArrayList                           売上明細リスト
            //        --SalesDetailWork                 売上明細データ                          →親データ
            //    --ArrayList                           計上元明細リスト
            //        --AddUppOrgSalesDetailWork        計上元明細データ                        →参照のみ(残数チェック)
            //    --DepsitDataWork                      入金データ                              →親データ同時修正可能
            //    --DepositAlwWork                      入金引当データ                          →親データ同時修正可能
            //    --ArrayList                           在庫ワークリスト                        
            //        --StockWork                       在庫ワークデータ                        →参照のみ(現在庫数セット)
            //    --ArrayList                           受注マスタ（車両）リスト
            //        --AcceptOdrCar                    受注マスタ（車両）
            //-----------------------------------------------------------------------------------------------------------------------
            //  CustomSerializeArrayList                計上元／同時入力リスト(第２パラメータ ParaList2)
            //    --CustomSerializeArrayList            計上元情報リスト(出荷、受注、見積)
            //      --SalesSlipWork                     計上元データ                            →親データ同時修正可(見積のみ)
            //      --ArrayList                         計上元明細リスト
            //          --SalesDetailWork               計上元明細データ                        →親データ同時修正可(見積のみ)
            //      --ArrayList                         計上元元明細リスト
            //          --AddUppOrgSalesDetailWork      計上元元明細データ                      →未使用(見積時は未セットとなる為)
            //      --DepsitMainWork                    計上元入金データ                        →未使用(見積時は未セットとなる為)
            //      --DepositAlwWork                    計上元入金引当データ                    →未使用(見積時は未セットとなる為)
            //      --ArrayList                         計上元在庫ワークリスト                        
            //          --StockWork                     計上元在庫ワークデータ                  →未使用
            //------------------------------------------
            //    --CustomSerializeArrayList            同時入力リスト(仕入、出荷、発注)
            //      --StockSlipWork                     同時入力データ                          →親データ同時修正可(受発注のみ)
            //      --ArrayList                         同時入力明細リスト
            //          --StockDetailWork               同時入力明細データ                      →親データ同時修正可(受発注のみ)
            //      --ArrayList                         同時入力計上元明細リスト
            //          --AddUpOrgStockDetailWork       同時入力計上元明細データ                →未使用(発注時は未セットとなる為)
            //      --PaymentSlpWork                    同時入力支払データ                      →親データ同時削除可
            //      --ArrayList                         同時入力在庫ワークリスト                        
            //          --StockWork                     同時入力在庫ワークデータ                →未使用
            //------------------------------------------
            //    --CustomSerializeArrayList            同時入力計上元リスト(出荷、発注)
            //      --StockSlipWork                     同時入力計上元データ                    →未使用
            //      --ArrayList                         同時入力計上元明細リスト
            //          --StockDetailWork               同時入力計上元明細データ                →未使用
            //      --ArrayList                         同時入力計上元元明細リスト
            //          --AddUpOrgStockDetailWork       同時入力計上元元明細データ              →未使用
            //      --PaymentSlpWork                    同時入力計上元支払データ                →未使用
            //      --ArrayList                         同時入力計上元在庫ワークリスト                        
            //          --StockWork                     同時入力計上元在庫ワークデータ          →未使用
            //-----------------------------------------------------------------------------------------------------------------------

            salesSlipWork = null;                                                   // 売上データワークオブジェクト
            salesDetailWorkArray = null;                                            // 売上明細データワークオブジェクト配列
            addUpOrgSalesDetailWorkArray = null;                                    // 計上元明細データワークオブジェクト配列
            depsitDataWork = null;                                                  // 入金データワークオブジェクト
            depositAlwWork = null;                                                  // 入金引当データワークオブジェクト
            stockWorkArray = null;                                                  // 在庫ワークオブジェクト配列
            stockSlipWorkList = new List<StockSlipWork>();                          // 同時入力データワークオブジェクトリスト
            stockDetailWrokList = new List<StockDetailWork>();                      // 同時入力明細データワークオブジェクトリスト
            addUpOrgStockDetailWorkList = new List<AddUpOrgStockDetailWork>();      // 同時入力計上元仕入明細データワークオブジェクトリスト
            acceptOdrCarWorkArray = null;                                           // 受注マスタ（車両）ワークオブジェクト配列
            uoeOrderDtlWorkArray = null;                                            // UOE発注データワークオブジェクト配列
            //>>>2010/02/26
            scmHeader = new UserSCMOrderHeaderRecord();                             // SCM受注データワークオブジェクト
            scmCar = new UserSCMOrderCarRecord();                                   // SCM受注データ(車両情報)ワークオブジェクト
            scmDetailList = null;                                                   // SCM受注明細データ(問合せ・発注)ワークオブジェクト配列
            scmAnswerList = null;                                                   // SCM受注明細データ(回答)ワークオブジェクト配列
            //<<<2010/02/26

            SalesSlipWork tempSalesSlipWork = null;                                 // 売上データワークオブジェクト
            SalesDetailWork[] tempSalesDetailWorkArray = null;                      // 売上明細データワークオブジェクト配列
            AddUpOrgSalesDetailWork[] tempAddUpOrgSalesDetailWorkArray = null;      // 計上元明細データワークオブジェクト配列
            DepsitDataWork tempDepsitDataWork = null;                               // 入金データワークオブジェクト
            DepositAlwWork tempDepositAlwWork = null;                               // 入金引当データワークオブジェクト
            StockWork[] tempStockWorkArray = null;                                  // 在庫ワークオブジェクト配列
            StockSlipWork tempStockSlipWork = null;                                 // 同時入力データワークオブジェクト
            StockDetailWork[] tempStockDetailWorkArray = null;                      // 同時入力明細データワークオブジェクト配列
            AddUpOrgStockDetailWork[] tempAddUpOrgStockDetailWorkArray = null;      // 同時入力計上元明細データワークオブジェクト配列
            AcceptOdrCarWork[] tempAcceptOdrCarWorkArray = null;                    // 受注マスタ（車両）ワークオブジェクト配列
            UOEOrderDtlWork[] tempUOEOrderDtlWorkArray = null;                      // UOE発注データワークオブジェクト配列
            //>>>2010/02/26
            UserSCMOrderHeaderRecord tempSCMHeader;                                 // SCM受注データワークオブジェクト
            UserSCMOrderCarRecord tempSCMCar;                                       // SCM受注データ(車両情報)ワークオブジェクト
            UserSCMOrderDetailRecord[] tempSCMDetailArray;                          // SCM受注明細データ(問合せ・発注)ワークオブジェクト配列
            UserSCMOrderAnswerRecord[] tempSCMAnswerArray;                          // SCM受注明細データ(回答)ワークオブジェクト配列
            //<<<2010/02/26

            //---------------------------------------------------
            // 親データ分割（売上情報リスト）
            //---------------------------------------------------
            //>>>2010/02/26
            //DivisionSalesSlipCustomSerializeArrayList.DivisionCustomSerializeArrayList(paraList1, out tempSalesSlipWork, out tempSalesDetailWorkArray, out tempAddUpOrgSalesDetailWorkArray, out tempDepsitDataWork, out tempDepositAlwWork, out tempStockWorkArray, out tempAcceptOdrCarWorkArray);
            DivisionSalesSlipCustomSerializeArrayList.DivisionCustomSerializeArrayList(paraList1, out tempSalesSlipWork, out tempSalesDetailWorkArray, out tempAddUpOrgSalesDetailWorkArray, out tempDepsitDataWork, out tempDepositAlwWork, out tempStockWorkArray, out tempAcceptOdrCarWorkArray, out tempSCMHeader, out tempSCMCar, out tempSCMDetailArray, out tempSCMAnswerArray);
            //<<<2010/02/26
            salesSlipWork = tempSalesSlipWork;
            salesDetailWorkArray = tempSalesDetailWorkArray;
            addUpOrgSalesDetailWorkArray = tempAddUpOrgSalesDetailWorkArray;
            depsitDataWork = tempDepsitDataWork;
            depositAlwWork = tempDepositAlwWork;
            stockWorkArray = tempStockWorkArray;
            acceptOdrCarWorkArray = tempAcceptOdrCarWorkArray;
            //>>>2010/02/26
            scmHeader = tempSCMHeader;
            scmCar = tempSCMCar;
            scmDetailList = tempSCMDetailArray;
            scmAnswerList = tempSCMAnswerArray;
            //<<<2010/02/26

            //---------------------------------------------------
            // 計上元／同時入力リスト分割
            //---------------------------------------------------
            if (paraList2 != null)
            {
                for (int i = 0; i < paraList2.Count; i++)
                {
                    if (paraList2[i] is CustomSerializeArrayList)
                    {

                        CustomSerializeArrayList tempList = (CustomSerializeArrayList)paraList2[i];
                        foreach (object tempObj in tempList)
                        {
                            if (tempObj is ArrayList)
                            {
                                ArrayList tempArrayList = (ArrayList)tempObj;
                                foreach (object detailObj in tempArrayList)
                                {
                                    //---------------------------------------------------
                                    // 同時入力データ
                                    //---------------------------------------------------
                                    if (detailObj is StockDetailWork)
                                    {
                                        StockDetailWork tempWork = (StockDetailWork)detailObj;
                                        if ((tempWork.SalesSlipDtlNumSync != 0) && (tempWork.StockSlipDtlNumSrc == 0))
                                        {
                                            DivisionSalesSlipCustomSerializeArrayList.DivisionCustomSerializeArrayList(tempList, out tempStockSlipWork, out tempStockDetailWorkArray, out tempAddUpOrgStockDetailWorkArray, out tempStockWorkArray, out tempUOEOrderDtlWorkArray);
                                            if (tempStockSlipWork != null)
                                            {
                                                stockSlipWorkList.Add(tempStockSlipWork);
                                                stockDetailWrokList.AddRange(tempStockDetailWorkArray);
                                            }
                                            if (tempAddUpOrgStockDetailWorkArray != null)
                                            {
                                                addUpOrgStockDetailWorkList.AddRange(tempAddUpOrgStockDetailWorkArray);
                                            }
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else if (paraList2[i] is ArrayList)
                    {
                        CustomSerializeArrayList tempList = new CustomSerializeArrayList();
                        ArrayList tempArrayList = (ArrayList)paraList2[i];

                        foreach (object detailObj in tempArrayList)
                        {
                            //---------------------------------------------------
                            // UOE発注データ
                            //---------------------------------------------------
                            if (detailObj is UOEOrderDtlWork)
                            {
                                UOEOrderDtlWork tempWork = (UOEOrderDtlWork)detailObj;
                                tempList.Add(tempArrayList);
                                DivisionSalesSlipCustomSerializeArrayList.DivisionCustomSerializeArrayList(tempList, out tempStockSlipWork, out tempStockDetailWorkArray, out tempAddUpOrgStockDetailWorkArray, out tempStockWorkArray, out tempUOEOrderDtlWorkArray);
                                if (tempUOEOrderDtlWorkArray != null)
                                {
                                    uoeOrderDtlWorkArray = tempUOEOrderDtlWorkArray;
                                }
                                break;
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// CustomSerializeArrayListを各種データオブジェクトに分割します。（明細読み込み用）
        /// </summary>
        /// <param name="paraList">カスタムシリアライズリストオブジェクト</param>
        /// <param name="paraList2">カスタムシリアライズリストオブジェクト</param>
        /// <param name="salesDetailWorkArray">売上明細データワークオブジェクト配列</param>
        /// <param name="acceptOdrCarWorkArray">受注マスタ（車両）ワークオブジェクト配列</param>
        /// <param name="stockSlipWorkArray">仕入データワークオブジェクト配列</param>
        /// <param name="stockDetailWorkArray">仕入明細データワークオブジェクト配列</param>
        /// <param name="uoeOrderDtlWorkArray">UOE発注データワークオブジェクト配列</param>
        private static void DivisionCustomSerializeArrayListForDetailsReadingProc(CustomSerializeArrayList paraList, CustomSerializeArrayList paraList2, out SalesDetailWork[] salesDetailWorkArray, out AcceptOdrCarWork[] acceptOdrCarWorkArray, out StockSlipWork[] stockSlipWorkArray, out StockDetailWork[] stockDetailWorkArray, out UOEOrderDtlWork[] uoeOrderDtlWorkArray)
        {
            //---------------------------------------------------
            // 売上明細データ、受注マスタ（車両）
            //---------------------------------------------------
            salesDetailWorkArray = null;
            ArrayList tempArrayList = new ArrayList();
            ArrayList retSalesDetailWorkList = new ArrayList();
            ArrayList retAcceptOdrCarWorkList = new ArrayList();
            for (int i = 0; i < paraList.Count; i++)
            {
                if (paraList[i] is ArrayList)
                {
                    tempArrayList = (ArrayList)paraList[i];
                    if (tempArrayList[0].GetType() == typeof(SalesDetailWork))
                    {
                        retSalesDetailWorkList = (ArrayList)paraList[i];
                    }
                    if (tempArrayList[0] is AcceptOdrCarWork)
                    {
                        retAcceptOdrCarWorkList = (ArrayList)paraList[i];
                    }
                }
            }
            salesDetailWorkArray = (SalesDetailWork[])retSalesDetailWorkList.ToArray(typeof(SalesDetailWork));
            acceptOdrCarWorkArray = (AcceptOdrCarWork[])retAcceptOdrCarWorkList.ToArray(typeof(AcceptOdrCarWork));

            //---------------------------------------------------
            // 仕入、仕入明細データ
            //---------------------------------------------------
            stockSlipWorkArray = null;
            stockDetailWorkArray = null;
            uoeOrderDtlWorkArray = null;
            if (paraList2 != null)
            {
                ArrayList retStockSlipWorkList = new ArrayList();
                ArrayList retStockDetailWorkList = new ArrayList();
                ArrayList retUOEOrderDtlWorkList = new ArrayList();

                for (int i = 0; i < paraList2.Count; i++)
                {
                    if (paraList2[i] is CustomSerializeArrayList)
                    {
                        StockSlipWork readStockSlipWork;
                        StockDetailWork[] readStockDetailWorkArray;
                        UOEOrderDtlWork[] readUOEOrderDtlWorkArray;

                        DivisionSalesSlipCustomSerializeArrayList.DivisionCustomSerializeArrayListForSalesSlipInfo((CustomSerializeArrayList)paraList2[i], out readStockSlipWork, out readStockDetailWorkArray, out readUOEOrderDtlWorkArray);

                        if (readStockSlipWork != null) retStockSlipWorkList.Add(readStockSlipWork);

                        if (readStockDetailWorkArray != null) retStockDetailWorkList.AddRange(readStockDetailWorkArray);

                        if (readUOEOrderDtlWorkArray != null) retUOEOrderDtlWorkList.AddRange(readUOEOrderDtlWorkArray);
                    }
                }

                stockSlipWorkArray = (StockSlipWork[])retStockSlipWorkList.ToArray(typeof(StockSlipWork));
                stockDetailWorkArray = (StockDetailWork[])retStockDetailWorkList.ToArray(typeof(StockDetailWork));
                uoeOrderDtlWorkArray = (UOEOrderDtlWork[])retUOEOrderDtlWorkList.ToArray(typeof(UOEOrderDtlWork));
            }
        }

        /// <summary>
        /// CustomSerializeArrayListを各種データオブジェクトに分割します。（仕入情報用）
        /// </summary>
        /// <param name="paraList">カスタムシリアライズリストオブジェクト</param>
        /// <param name="stockSlipWork">仕入データワークオブジェクト</param>
        /// <param name="stockDetailWorkArray">仕入明細データワークオブジェクト配列</param>
        /// <param name="addUpOrgStockDetailWorkArray">計上元仕入明細データワークオブジェクト配列</param>
        /// <param name="stockWorkArray">在庫ワークオブジェクト配列</param>
        /// <param name="uoeOrderDtlWorkArray">UOE発注データワークオブジェクト配列</param>
        private static void DivisionCustomSerializeArrayList(CustomSerializeArrayList paraList, out StockSlipWork stockSlipWork, out StockDetailWork[] stockDetailWorkArray, out AddUpOrgStockDetailWork[] addUpOrgStockDetailWorkArray, out StockWork[] stockWorkArray, out UOEOrderDtlWork[] uoeOrderDtlWorkArray)
        {
            stockSlipWork = null;
            stockDetailWorkArray = null;
            addUpOrgStockDetailWorkArray = null;
            stockWorkArray = null;
            uoeOrderDtlWorkArray = null;

            object objStockSlipWork;
            object objStockDetailWorkArray;
            object objPaymentWork;
            object objDepositAlwWork;
            object objAddUpOrgStockDetailWorkArray;
            object objUOEOrderDtlWorkArray;

            DivisionSalesSlipCustomSerializeArrayList.DivisionCustomSerializeArrayListProc(paraList, out objStockSlipWork, out objStockDetailWorkArray, out objAddUpOrgStockDetailWorkArray, out objPaymentWork, out objDepositAlwWork, out stockWorkArray, out objUOEOrderDtlWorkArray);

            if ((objStockSlipWork != null) && (objStockSlipWork is StockSlipWork)) stockSlipWork = (StockSlipWork)objStockSlipWork;

            if ((objStockDetailWorkArray != null) && (objStockDetailWorkArray is StockDetailWork[])) stockDetailWorkArray = (StockDetailWork[])objStockDetailWorkArray;

            if ((objAddUpOrgStockDetailWorkArray != null) && (objAddUpOrgStockDetailWorkArray is AddUpOrgStockDetailWork[])) addUpOrgStockDetailWorkArray = (AddUpOrgStockDetailWork[])objAddUpOrgStockDetailWorkArray;

            if ((objUOEOrderDtlWorkArray != null) && (objUOEOrderDtlWorkArray is UOEOrderDtlWork[])) uoeOrderDtlWorkArray = (UOEOrderDtlWork[])objUOEOrderDtlWorkArray;
        }

        //>>>2010/02/26
        /// <summary>
        /// CustomSerializeArrayListを各種データオブジェクトに分割します。（売上情報用）
        /// </summary>
        /// <param name="paraList">カスタムシリアライズリストオブジェクト</param>
        /// <param name="salesSlipWork">売上データワークオブジェクト</param>
        /// <param name="salesDetailWorkArray">売上明細データワークオブジェクト配列</param>
        /// <param name="addUppOrgSalesDetailWorkArray">計上元売上明細データワークオブジェクト配列</param>
        /// <param name="depsitDataWork">入金データオブジェクト</param>
        /// <param name="depositAlwWork">入金引当データオブジェクト</param>
        /// <param name="stockWorkArray">在庫ワークオブジェクト配列</param>        
        /// <param name="acceptOdrCarWorkArray">受注マスタ（車両）ワークオブジェクト配列</param>
        private static void DivisionCustomSerializeArrayList(CustomSerializeArrayList paraList, out SalesSlipWork salesSlipWork, out SalesDetailWork[] salesDetailWorkArray, out AddUpOrgSalesDetailWork[] addUpOrgSalesDetailWorkArray, out DepsitDataWork depsitDataWork, out DepositAlwWork depositAlwWork, out StockWork[] stockWorkArray, out AcceptOdrCarWork[] acceptOdrCarWorkArray)
        {
            SCMAcOdrDataWork scmAcOdrDataWork = null;
            SCMAcOdrDtlIqWork[] scmAcOdrDataWorkArray = null;
            SCMAcOdrDtlAsWork[] scmAcOdrDtlAsWorkArray = null;
            SCMAcOdrDtCarWork scmAcOdrDtCarWork = null;

            DivisionCustomSerializeArrayList(paraList, out salesSlipWork, out salesDetailWorkArray, out addUpOrgSalesDetailWorkArray, out depsitDataWork, out depositAlwWork, out stockWorkArray, out acceptOdrCarWorkArray, out  scmAcOdrDataWork, out scmAcOdrDataWorkArray, out scmAcOdrDtlAsWorkArray, out scmAcOdrDtCarWork);
        }
        //<<<2010/02/26

        /// <summary>
        /// CustomSerializeArrayListを各種データオブジェクトに分割します。（売上情報用）
        /// </summary>
        /// <param name="paraList">カスタムシリアライズリストオブジェクト</param>
        /// <param name="salesSlipWork">売上データワークオブジェクト</param>
        /// <param name="salesDetailWorkArray">売上明細データワークオブジェクト配列</param>
        /// <param name="addUppOrgSalesDetailWorkArray">計上元売上明細データワークオブジェクト配列</param>
        /// <param name="depsitDataWork">入金データオブジェクト</param>
        /// <param name="depositAlwWork">入金引当データオブジェクト</param>
        /// <param name="stockWorkArray">在庫ワークオブジェクト配列</param>        
        /// <param name="acceptOdrCarWorkArray">受注マスタ（車両）ワークオブジェクト配列</param>
        //private static void DivisionCustomSerializeArrayList(CustomSerializeArrayList paraList, out SalesSlipWork salesSlipWork, out SalesDetailWork[] salesDetailWorkArray, out AddUpOrgSalesDetailWork[] addUpOrgSalesDetailWorkArray, out DepsitDataWork depsitDataWork, out DepositAlwWork depositAlwWork, out StockWork[] stockWorkArray, out AcceptOdrCarWork[] acceptOdrCarWorkArray) // 2010/02/26
        private static void DivisionCustomSerializeArrayList(CustomSerializeArrayList paraList, out SalesSlipWork salesSlipWork, out SalesDetailWork[] salesDetailWorkArray, out AddUpOrgSalesDetailWork[] addUpOrgSalesDetailWorkArray, out DepsitDataWork depsitDataWork, out DepositAlwWork depositAlwWork, out StockWork[] stockWorkArray, out AcceptOdrCarWork[] acceptOdrCarWorkArray, out SCMAcOdrDataWork scmAcOdrDataWork, out SCMAcOdrDtlIqWork[] scmAcOdrDataWorkArray, out SCMAcOdrDtlAsWork[] scmAcOdrDtlAsWorkArray, out SCMAcOdrDtCarWork scmAcOdrDtCarWork) // 2010/02/26
        {
            salesSlipWork = null;
            salesDetailWorkArray = null;
            addUpOrgSalesDetailWorkArray = null;
            depsitDataWork = null;
            depositAlwWork = null;
            stockWorkArray = null;
            acceptOdrCarWorkArray = null;
            //>>>2010/02/26
            scmAcOdrDataWork = null;
            scmAcOdrDataWorkArray = null;
            scmAcOdrDtlAsWorkArray = null;
            scmAcOdrDtCarWork = null;
            //<<<2010/02/26

            object objSalesSlipWork;
            object objSalesDetailWorkArray;
            object objAddUpOrgSalesDetailWorkArray;
            object objDepsitDataWork;
            object objDepositAlwWork;
            object objAcceptOdrCarWorkArray;
            object objUOEOrderDtlWorkArray;
            //>>>2010/02/26
            object objSCMHeader;
            object objSCMCar;
            object objSCMDetailArray;
            object objSCMAnswerArray;
            //<<<2010/02/26

            //>>>2010/02/26
            //DivisionSalesSlipCustomSerializeArrayList.DivisionCustomSerializeArrayListProc(paraList, out objSalesSlipWork, out objSalesDetailWorkArray, out objAddUpOrgSalesDetailWorkArray, out objDepsitDataWork, out objDepositAlwWork, out stockWorkArray, out objAcceptOdrCarWorkArray, out objUOEOrderDtlWorkArray);
            DivisionSalesSlipCustomSerializeArrayList.DivisionCustomSerializeArrayListProc(paraList, out objSalesSlipWork, out objSalesDetailWorkArray, out objAddUpOrgSalesDetailWorkArray, out objDepsitDataWork, out objDepositAlwWork, out stockWorkArray, out objAcceptOdrCarWorkArray, out objUOEOrderDtlWorkArray, out objSCMHeader, out objSCMCar, out objSCMDetailArray, out objSCMAnswerArray);
            //<<<2010/02/26

            if ((objSalesSlipWork != null) && (objSalesSlipWork is SalesSlipWork)) salesSlipWork = (SalesSlipWork)objSalesSlipWork;

            if ((objSalesDetailWorkArray != null) && (objSalesDetailWorkArray.GetType() == typeof(SalesDetailWork[]))) salesDetailWorkArray = (SalesDetailWork[])objSalesDetailWorkArray;

            if ((objAddUpOrgSalesDetailWorkArray != null) && (objAddUpOrgSalesDetailWorkArray.GetType() == typeof(AddUpOrgSalesDetailWork[]))) addUpOrgSalesDetailWorkArray = (AddUpOrgSalesDetailWork[])objAddUpOrgSalesDetailWorkArray;

            if ((objDepsitDataWork != null) && (objDepsitDataWork is DepsitDataWork)) depsitDataWork = (DepsitDataWork)objDepsitDataWork;

            if ((objDepositAlwWork != null) && (objDepositAlwWork is DepositAlwWork)) depositAlwWork = (DepositAlwWork)objDepositAlwWork;

            if ((objAcceptOdrCarWorkArray != null) && (objAcceptOdrCarWorkArray is AcceptOdrCarWork[])) acceptOdrCarWorkArray = (AcceptOdrCarWork[])objAcceptOdrCarWorkArray;
            
            //>>>2010/02/26
            if ((objSCMHeader != null) && (objSCMHeader is SCMAcOdrDataWork)) scmAcOdrDataWork = (SCMAcOdrDataWork)objSCMHeader;
            if ((objSCMCar != null) && (objSCMCar is SCMAcOdrDtCarWork)) scmAcOdrDtCarWork = (SCMAcOdrDtCarWork)objSCMCar;
            if ((objSCMDetailArray != null) && (objSCMDetailArray is SCMAcOdrDtlIqWork[])) scmAcOdrDataWorkArray = (SCMAcOdrDtlIqWork[])objSCMDetailArray;
            if ((objSCMAnswerArray != null) && (objSCMAnswerArray is SCMAcOdrDtlAsWork[])) scmAcOdrDtlAsWorkArray = (SCMAcOdrDtlAsWork[])objSCMAnswerArray;
            //<<<2010/02/26
        }

        //>>>2010/02/26
        /// <summary>
        /// CustomSerializeArrayListを各種データオブジェクトに分割します。（売上情報用）
        /// </summary>
        /// <param name="paraList">カスタムシリアライズリストオブジェクト</param>
        /// <param name="salesSlipWork">売上データワークオブジェクト</param>
        /// <param name="salesDetailWorkArray">売上明細データワークオブジェクト配列</param>
        /// <param name="addUppOrgSalesDetailWorkArray">計上元売上明細データワークオブジェクト配列</param>
        /// <param name="depsitDataWork">入金データオブジェクト</param>
        /// <param name="depositAlwWork">入金引当データオブジェクト</param>
        /// <param name="stockWorkArray">在庫ワークオブジェクト配列</param>        
        /// <param name="acceptOdrCarWorkArray">受注マスタ（車両）ワークオブジェクト配列</param>
        /// <param name="scmHeader">SCM受注データワークオブジェクト</param>
        /// <param name="scmCar">SCM受注データ(車両情報)ワークオブジェクト</param>
        /// <param name="scmDetailArray">SCM受注明細データ(問合せ・発注)ワークオブジェクト配列</param>
        /// <param name="scmAnswerArray">SCM受注明細データ(回答)ワークオブジェクト配列</param>
        private static void DivisionCustomSerializeArrayList(CustomSerializeArrayList paraList, out SalesSlipWork salesSlipWork, out SalesDetailWork[] salesDetailWorkArray, out AddUpOrgSalesDetailWork[] addUpOrgSalesDetailWorkArray, out DepsitDataWork depsitDataWork, out DepositAlwWork depositAlwWork, out StockWork[] stockWorkArray, out AcceptOdrCarWork[] acceptOdrCarWorkArray, out UserSCMOrderHeaderRecord scmHeader, out UserSCMOrderCarRecord scmCar, out UserSCMOrderDetailRecord[] scmDetailArray, out UserSCMOrderAnswerRecord[] scmAnswerArray)
        {
            salesSlipWork = null;
            salesDetailWorkArray = null;
            addUpOrgSalesDetailWorkArray = null;
            depsitDataWork = null;
            depositAlwWork = null;
            stockWorkArray = null;
            acceptOdrCarWorkArray = null;
            scmHeader = null;
            scmCar = null;
            scmDetailArray = null;
            scmAnswerArray = null;

            object objSalesSlipWork;
            object objSalesDetailWorkArray;
            object objAddUpOrgSalesDetailWorkArray;
            object objDepsitDataWork;
            object objDepositAlwWork;
            object objAcceptOdrCarWorkArray;
            object objUOEOrderDtlWorkArray;
            object objSCMHeader;
            object objSCMCar;
            object objSCMDetailArray;
            object objSCMAnswerArray;

            DivisionSalesSlipCustomSerializeArrayList.DivisionCustomSerializeArrayListProc(paraList, out objSalesSlipWork, out objSalesDetailWorkArray, out objAddUpOrgSalesDetailWorkArray, out objDepsitDataWork, out objDepositAlwWork, out stockWorkArray, out objAcceptOdrCarWorkArray, out objUOEOrderDtlWorkArray, out objSCMHeader, out objSCMCar, out objSCMDetailArray, out objSCMAnswerArray);

            if ((objSalesSlipWork != null) && (objSalesSlipWork is SalesSlipWork)) salesSlipWork = (SalesSlipWork)objSalesSlipWork;

            if ((objSalesDetailWorkArray != null) && (objSalesDetailWorkArray.GetType() == typeof(SalesDetailWork[]))) salesDetailWorkArray = (SalesDetailWork[])objSalesDetailWorkArray;

            if ((objAddUpOrgSalesDetailWorkArray != null) && (objAddUpOrgSalesDetailWorkArray.GetType() == typeof(AddUpOrgSalesDetailWork[]))) addUpOrgSalesDetailWorkArray = (AddUpOrgSalesDetailWork[])objAddUpOrgSalesDetailWorkArray;

            if ((objDepsitDataWork != null) && (objDepsitDataWork is DepsitDataWork)) depsitDataWork = (DepsitDataWork)objDepsitDataWork;

            if ((objDepositAlwWork != null) && (objDepositAlwWork is DepositAlwWork)) depositAlwWork = (DepositAlwWork)objDepositAlwWork;

            if ((objAcceptOdrCarWorkArray != null) && (objAcceptOdrCarWorkArray is AcceptOdrCarWork[])) acceptOdrCarWorkArray = (AcceptOdrCarWork[])objAcceptOdrCarWorkArray;

            if ((objSCMHeader != null) && (objSCMHeader is SCMAcOdrDataWork)) scmHeader = new UserSCMOrderHeaderRecord((SCMAcOdrDataWork)objSCMHeader);
            if ((objSCMCar != null) && (objSCMCar is SCMAcOdrDtCarWork)) scmCar = new UserSCMOrderCarRecord((SCMAcOdrDtCarWork)objSCMCar);
            if ((objSCMDetailArray != null) && (objSCMDetailArray is UserSCMOrderDetailRecord[])) scmDetailArray = (UserSCMOrderDetailRecord[])objSCMDetailArray;
            if ((objSCMAnswerArray != null) && (objSCMAnswerArray is UserSCMOrderAnswerRecord[])) scmAnswerArray = (UserSCMOrderAnswerRecord[])objSCMAnswerArray;
        }
        //<<<2010/02/26

        /// <summary>
        /// CustomSerializeArrayListを各種データオブジェクトに分割します。
        /// </summary>
        /// <param name="paraList">カスタムシリアライズリストオブジェクト</param>
        /// <param name="slipWork">伝票データワークオブジェクト</param>
        /// <param name="detailWorkArray">明細データワークオブジェクト配列</param>
        /// <param name="addUpOrgDetailWorkArray">計上元明細データワークオブジェクト配列</param>
        /// <param name="depsitDataWork">入金／支払データワークオブジェクト</param>
        /// <param name="depositAlwWork">入金引当データワークオブジェクト</param>
        /// <param name="stockWorkArray">在庫ワークオブジェクト配列</param>
        /// <param name="uoeOrderDtlWorkArray">UOE発注データワークオブジェクト配列</param>
        private static void DivisionCustomSerializeArrayListProc(CustomSerializeArrayList paraList, out object slipWork, out object detailWorkArray, out object addUpOrgDetailWorkArray, out object depsitDataWork, out object depositAlwWork, out StockWork[] stockWorkArray, out object uoeOrderDtlWorkArray)
        {
            object acceptOdrCarWorkArray = null;
            //>>>2010/02/26
            object scmHeader = null;
            object scmCar = null;
            object scmDetailArray = null;
            object scmAnswerArray = null;
            //<<<2010/02/26

            //>>>2010/02/26
            //DivisionSalesSlipCustomSerializeArrayList.DivisionCustomSerializeArrayListProc(paraList, out slipWork, out detailWorkArray, out addUpOrgDetailWorkArray, out depsitDataWork, out depositAlwWork, out stockWorkArray, out acceptOdrCarWorkArray, out uoeOrderDtlWorkArray);
            DivisionSalesSlipCustomSerializeArrayList.DivisionCustomSerializeArrayListProc(paraList, out slipWork, out detailWorkArray, out addUpOrgDetailWorkArray, out depsitDataWork, out depositAlwWork, out stockWorkArray, out acceptOdrCarWorkArray, out uoeOrderDtlWorkArray, out scmHeader, out scmCar, out scmDetailArray, out scmAnswerArray);
            //<<<2010/02/26
        }

        /// <summary>
        /// CustomSerializeArrayListを各種データオブジェクトに分割します。
        /// </summary>
        /// <param name="paraList">カスタムシリアライズリストオブジェクト</param>
        /// <param name="slipWork">伝票データワークオブジェクト</param>
        /// <param name="detailWorkArray">明細データワークオブジェクト配列</param>
        /// <param name="addUpOrgDetailWorkArray">計上元明細データワークオブジェクト配列</param>
        /// <param name="depsitDataWork">入金／支払データワークオブジェクト</param>
        /// <param name="depositAlwWork">入金引当データワークオブジェクト</param>
        /// <param name="stockWorkArray">在庫ワークオブジェクト配列</param>
        /// <param name="acceptOdrCarWorkArray">受注マスタ（車両）ワークオブジェクト配列</param>
        /// <param name="uoeOrderDtlWorkArray">UOE発注データワークオブジェクト配列</param>
        //>>>2010/02/26
        //private static void DivisionCustomSerializeArrayListProc(CustomSerializeArrayList paraList, out object slipWork, out object detailWorkArray, out object addUpOrgDetailWorkArray, out object depsitDataWork, out object depositAlwWork, out StockWork[] stockWorkArray, out object acceptOdrCarWorkArray, out object uoeOrderDtlWorkArray)
        private static void DivisionCustomSerializeArrayListProc(CustomSerializeArrayList paraList, out object slipWork, out object detailWorkArray, out object addUpOrgDetailWorkArray, out object depsitDataWork, out object depositAlwWork, out StockWork[] stockWorkArray, out object acceptOdrCarWorkArray, out object uoeOrderDtlWorkArray, out object scmHeader, out object scmCar, out object scmDetailArray, out object scmAnswerArray)
        //<<<2010/02/26
        {
            slipWork = null;
            detailWorkArray = null;
            addUpOrgDetailWorkArray = null;
            depsitDataWork = null;
            depositAlwWork = null;
            stockWorkArray = null;
            acceptOdrCarWorkArray = null;
            uoeOrderDtlWorkArray = null;
            //>>>2010/02/26
            scmHeader = null;
            scmCar = null;
            scmDetailArray = null;
            scmAnswerArray = null;
            //<<<2010/02/26

            for (int i = 0; i < paraList.Count; i++)
            {
                if ((paraList[i] is StockSlipWork) || (paraList[i] is SalesSlipWork))
                {
                    slipWork = paraList[i];
                }
                else if ((paraList[i] is PaymentSlpWork) || (paraList[i] is DepsitDataWork))
                {
                    depsitDataWork = paraList[i];
                }
                else if (paraList[i] is DepositAlwWork)
                {
                    depositAlwWork = paraList[i];
                }
                //>>>2010/02/26
                else if (paraList[i] is SCMAcOdrDataWork) // SCM受注データワークオブジェクト
                {
                    scmHeader = paraList[i];
                }
                else if (paraList[i] is SCMAcOdrDtCarWork) // SCM受注データ(車両情報)ワークオブジェクト
                {
                    scmCar = paraList[i];
                }
                //<<<2010/02/26
                else if (paraList[i] is ArrayList)
                {
                    ArrayList list = (ArrayList)paraList[i];

                    if (list.Count == 0) continue;

                    if (list[0].GetType() == typeof(AddUpOrgStockDetailWork))
                    {
                        addUpOrgDetailWorkArray = (AddUpOrgStockDetailWork[])list.ToArray(typeof(AddUpOrgStockDetailWork));
                    }
                    else if (list[0].GetType() == typeof(AddUpOrgSalesDetailWork))
                    {
                        addUpOrgDetailWorkArray = (AddUpOrgSalesDetailWork[])list.ToArray(typeof(AddUpOrgSalesDetailWork));
                    }
                    else if (list[0].GetType() == typeof(StockDetailWork))
                    {
                        detailWorkArray = (StockDetailWork[])list.ToArray(typeof(StockDetailWork));
                    }
                    else if (list[0].GetType() == typeof(SalesDetailWork))
                    {
                        detailWorkArray = (SalesDetailWork[])list.ToArray(typeof(SalesDetailWork));
                    }
                    else if (list[0] is StockWork)
                    {
                        stockWorkArray = (StockWork[])list.ToArray(typeof(StockWork));
                    }
                    else if (list[0] is AcceptOdrCarWork)
                    {
                        acceptOdrCarWorkArray = (AcceptOdrCarWork[])list.ToArray(typeof(AcceptOdrCarWork));
                    }
                    else if (list[0] is UOEOrderDtlWork)
                    {
                        uoeOrderDtlWorkArray = (UOEOrderDtlWork[])list.ToArray(typeof(UOEOrderDtlWork));
                    }
                    //>>>2010/02/26
                    else if (list[0] is SCMAcOdrDtlIqWork) // SCM受注明細データ(問合せ・発注)ワークオブジェクト配列
                    {
                        ArrayList al = new ArrayList();
                        foreach (SCMAcOdrDtlIqWork work in list)
                        {
                            UserSCMOrderDetailRecord detail = new UserSCMOrderDetailRecord(work);
                            al.Add(detail);
                        }
                        scmDetailArray = (UserSCMOrderDetailRecord[])al.ToArray(typeof(UserSCMOrderDetailRecord));
                    }
                    else if (list[0] is SCMAcOdrDtlAsWork) // SCM受注明細データ(回答)ワークオブジェクト配列
                    {
                        ArrayList al = new ArrayList();
                        foreach (SCMAcOdrDtlAsWork work in list)
                        {
                            UserSCMOrderAnswerRecord answer = new UserSCMOrderAnswerRecord(work);
                            al.Add(answer);
                        }
                        scmAnswerArray = (UserSCMOrderAnswerRecord[])al.ToArray(typeof(UserSCMOrderAnswerRecord));
                    }
                    //<<<2010/02/26
                }
            }
        }

        /// <summary>
        /// CustomSerializeArrayListを売上明細データオブジェクトに分割します。
        /// </summary>
        /// <param name="paraList">カスタムシリアライズリストオブジェクト</param>
        /// <param name="salesDetailWorkArray">売上明細データワークオブジェクト配列</param>
        private static void DivisionCustomSerializeArrayList(CustomSerializeArrayList paraList, out SalesDetailWork[] salesDetailWorkArray)
        {
            salesDetailWorkArray = null;

            ArrayList retSalesDetailWorkList = new ArrayList();
            for (int i = 0; i < paraList.Count; i++)
            {
                if (paraList[i].GetType() == typeof(SalesDetailWork))
                {
                    retSalesDetailWorkList.Add((SalesDetailWork)paraList[i]);
                }
            }
            salesDetailWorkArray = (SalesDetailWork[])retSalesDetailWorkList.ToArray(typeof(SalesDetailWork));
        }

        /// <summary>
        /// CustomSerializeArrayListを各種データオブジェクトに分割します。（仕入情報用）（オーバーロード）
        /// </summary>
        /// <param name="paraList">カスタムシリアライズリストオブジェクト</param>
        /// <param name="stockSlipWork">仕入データワークオブジェクト</param>
        /// <param name="stockDetailWorkArray">仕入明細データワークオブジェクト配列</param>
        /// <param name="addUpOrgStockDetailWorkArray">計上元仕入明細データワークオブジェクト配列</param>
        /// <param name="paymentSlpWork">支払データオブジェクト</param>
        /// <param name="stockWorkArray">在庫ワークオブジェクト配列</param>
        /// <param name="uoeOrderDtlWorkArray">UOE発注データワークオブジェクト配列</param>
        private static void DivisionCustomSerializeArrayListForStockSlipInfo(CustomSerializeArrayList paraList, out StockSlipWork stockSlipWork, out StockDetailWork[] stockDetailWorkArray, out AddUpOrgStockDetailWork[] addUpOrgStockDetailWorkArray, out PaymentSlpWork paymentSlpWork, out StockWork[] stockWorkArray, out UOEOrderDtlWork[] uoeOrderDtlWorkArray)
        {
            stockSlipWork = null;
            stockDetailWorkArray = null;
            addUpOrgStockDetailWorkArray = null;
            paymentSlpWork = null;
            stockWorkArray = null;
            uoeOrderDtlWorkArray = null;

            object objStockSlipWork;
            object objStockDetailWorkArray;
            object objAddUpOrgStockDetailWorkArray;
            object objPaymentSlpWork;
            object objDummy;
            object objUOEOrderDtlWorkArray = null;

            DivisionSalesSlipCustomSerializeArrayList.DivisionCustomSerializeArrayListProc(paraList, out objStockSlipWork, out objStockDetailWorkArray, out objAddUpOrgStockDetailWorkArray, out objPaymentSlpWork, out objDummy, out stockWorkArray, out objUOEOrderDtlWorkArray);

            if ((objStockSlipWork != null) && (objStockSlipWork is StockSlipWork)) stockSlipWork = (StockSlipWork)objStockSlipWork;

            if ((objStockDetailWorkArray != null) && (objStockDetailWorkArray.GetType() == typeof(StockDetailWork[]))) stockDetailWorkArray = (StockDetailWork[])objStockDetailWorkArray;

            if ((objAddUpOrgStockDetailWorkArray != null) && (objAddUpOrgStockDetailWorkArray.GetType() == typeof(AddUpOrgStockDetailWork[]))) objAddUpOrgStockDetailWorkArray = (AddUpOrgStockDetailWork[])objAddUpOrgStockDetailWorkArray;

            if ((objPaymentSlpWork != null) && (objPaymentSlpWork is PaymentSlpWork)) paymentSlpWork = (PaymentSlpWork)objPaymentSlpWork;
        }

        /// <summary>
        /// CustomSerializeArrayListを各種データオブジェクトに分割します。（売上情報用）（オーバーロード）
        /// </summary>
        /// <param name="paraList">カスタムシリアライズリストオブジェクト</param>
        /// <param name="salesSlipWork">売上データオブジェクト</param>
        /// <param name="salesDetailWorkArray">売上明細データワークオブジェクト配列</param>
        /// <param name="uoeOrderDtlWorkArray">UOE発注データワークオブジェクト配列</param>
        private static void DivisionCustomSerializeArrayListForSalesSlipInfo(CustomSerializeArrayList paraList, out StockSlipWork stockSlipWork, out StockDetailWork[] stockDetailWorkArray, out UOEOrderDtlWork[] uoeOrderDtlWorkArray)
        {
            stockSlipWork = null;
            stockDetailWorkArray = null;
            uoeOrderDtlWorkArray = null;

            object objStockSlipWork;
            object objStockDetailWorkArray;
            object objAddUpOrgStockDetailWorkArray;
            object objPaymentSlpWork;
            object objDummy;
            StockWork[] stockWorkArray;
            object objUOEOrderDtlWorkArray;

            DivisionSalesSlipCustomSerializeArrayList.DivisionCustomSerializeArrayListProc(paraList, out objStockSlipWork, out objStockDetailWorkArray, out objAddUpOrgStockDetailWorkArray, out objPaymentSlpWork, out objDummy, out stockWorkArray, out objUOEOrderDtlWorkArray);

            if ((objStockSlipWork != null) && (objStockSlipWork is StockSlipWork)) stockSlipWork = (StockSlipWork)objStockSlipWork;

            if ((objStockDetailWorkArray != null) && (objStockDetailWorkArray.GetType() == typeof(StockDetailWork[]))) stockDetailWorkArray = (StockDetailWork[])objStockDetailWorkArray;

            if ((objUOEOrderDtlWorkArray != null) && (objUOEOrderDtlWorkArray is UOEOrderDtlWork[])) uoeOrderDtlWorkArray = (UOEOrderDtlWork[])objUOEOrderDtlWorkArray;
        }
        #endregion
    }
}
