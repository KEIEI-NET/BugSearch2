//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : 売上明細テーブルスキーマクラス
// プログラム概要   : 売上明細テーブル定義を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10402071-00 作成担当 : 立花 裕輔
// 作 成 日  2008/05/26  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30517 夏野 駿希
// 作 成 日  2011/01/19  修正内容 : Mantis.16772 SCM項目が送信処理で売上データにセットされない件の修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 朱宝軍
// 作 成 日  2011/07/28  修正内容 : 自動回答区分追加対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30517 夏野 駿希
// 作 成 日  2012/01/16  修正内容 : SCM改良・特記事項対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 湯上 千加子
// 作 成 日  2012/12/06  修正内容 : SCM障害№10447対応
//----------------------------------------------------------------------------//
using System;
using System.Data;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// 売上明細テーブルスキーマクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 売上明細抽出結果テーブルスキーマ</br>
    /// <br>Programmer : 96186　立花裕輔</br>
    /// <br>Date       : 2008.05.26</br>
    /// </remarks>
    public class SalesDetailSchema
    {
        #region Public Members
        /// <summary>売上明細テーブル名</summary>
        public const string CT_SalesDetailDataTable = "SalesDetailDataTable";

        /// <summary>受注明細テーブル名</summary>
        public const string CT_AcptDetailDataTable = "AcptDetailDataTable";


        #region カラム初期情報
        public const double defValueDouble = 0;
        public const Int64 defValueInt64 = 0;
        public const Int32 defValueInt32 = 0;
        public const string defValuestring = "";
        // ADD 2012/12/06 2012/12/12配信予定 SCM障害№10447対応 ----------------------------------->>>>>
        public const short defValueShort = 0;
        // ADD 2012/12/06 2012/12/12配信予定 SCM障害№10447対応 -----------------------------------<<<<<
        #endregion

        #region カラム情報
        /// <summary> 作成日時 </summary>
        public const string ct_Col_CreateDateTime = "CreateDateTime";
        /// <summary> 更新日時 </summary>
        public const string ct_Col_UpdateDateTime = "UpdateDateTime";
        /// <summary> 企業コード </summary>
        public const string ct_Col_EnterpriseCode = "EnterpriseCode";
        /// <summary> GUID </summary>
        public const string ct_Col_FileHeaderGuid = "FileHeaderGuid";
        /// <summary> 更新従業員コード </summary>
        public const string ct_Col_UpdEmployeeCode = "UpdEmployeeCode";
        /// <summary> 更新アセンブリID1 </summary>
        public const string ct_Col_UpdAssemblyId1 = "UpdAssemblyId1";
        /// <summary> 更新アセンブリID2 </summary>
        public const string ct_Col_UpdAssemblyId2 = "UpdAssemblyId2";
        /// <summary> 論理削除区分 </summary>
        public const string ct_Col_LogicalDeleteCode = "LogicalDeleteCode";
        /// <summary> 受注番号 </summary>
        public const string ct_Col_AcceptAnOrderNo = "AcceptAnOrderNo";
        /// <summary> 受注ステータス </summary>
        public const string ct_Col_AcptAnOdrStatus = "AcptAnOdrStatus";
        /// <summary> 売上伝票番号 </summary>
        public const string ct_Col_SalesSlipNum = "SalesSlipNum";
        /// <summary> 売上行番号 </summary>
        public const string ct_Col_SalesRowNo = "SalesRowNo";
        /// <summary> 売上行番号枝番 </summary>
        public const string ct_Col_SalesRowDerivNo = "SalesRowDerivNo";
        /// <summary> 拠点コード </summary>
        public const string ct_Col_SectionCode = "SectionCode";
        /// <summary> 部門コード </summary>
        public const string ct_Col_SubSectionCode = "SubSectionCode";
        /// <summary> 売上日付 </summary>
        public const string ct_Col_SalesDate = "SalesDate";
        /// <summary> 共通通番 </summary>
        public const string ct_Col_CommonSeqNo = "CommonSeqNo";
        /// <summary> 売上明細通番 </summary>
        public const string ct_Col_SalesSlipDtlNum = "SalesSlipDtlNum";
        /// <summary> 受注ステータス（元） </summary>
        public const string ct_Col_AcptAnOdrStatusSrc = "AcptAnOdrStatusSrc";
        /// <summary> 売上明細通番（元） </summary>
        public const string ct_Col_SalesSlipDtlNumSrc = "SalesSlipDtlNumSrc";
        /// <summary> 仕入形式（同時） </summary>
        public const string ct_Col_SupplierFormalSync = "SupplierFormalSync";
        /// <summary> 仕入明細通番（同時） </summary>
        public const string ct_Col_StockSlipDtlNumSync = "StockSlipDtlNumSync";
        /// <summary> 売上伝票区分（明細） </summary>
        public const string ct_Col_SalesSlipCdDtl = "SalesSlipCdDtl";
        /// <summary> 納品完了予定日 </summary>
        public const string ct_Col_DeliGdsCmpltDueDate = "DeliGdsCmpltDueDate";
        /// <summary> 商品属性 </summary>
        public const string ct_Col_GoodsKindCode = "GoodsKindCode";
        /// <summary> 商品検索区分 </summary>
        public const string ct_Col_GoodsSearchDivCd = "GoodsSearchDivCd";
        /// <summary> 商品メーカーコード </summary>
        public const string ct_Col_GoodsMakerCd = "GoodsMakerCd";
        /// <summary> メーカー名称 </summary>
        public const string ct_Col_MakerName = "MakerName";
        /// <summary> メーカーカナ名称 </summary>
        public const string ct_Col_MakerKanaName = "MakerKanaName";
        /// <summary> 商品番号 </summary>
        public const string ct_Col_GoodsNo = "GoodsNo";
        /// <summary> 商品名称 </summary>
        public const string ct_Col_GoodsName = "GoodsName";
        /// <summary> 商品名称カナ </summary>
        public const string ct_Col_GoodsNameKana = "GoodsNameKana";
        /// <summary> 商品大分類コード </summary>
        public const string ct_Col_GoodsLGroup = "GoodsLGroup";
        /// <summary> 商品大分類名称 </summary>
        public const string ct_Col_GoodsLGroupName = "GoodsLGroupName";
        /// <summary> 商品中分類コード </summary>
        public const string ct_Col_GoodsMGroup = "GoodsMGroup";
        /// <summary> 商品中分類名称 </summary>
        public const string ct_Col_GoodsMGroupName = "GoodsMGroupName";
        /// <summary> BLグループコード </summary>
        public const string ct_Col_BLGroupCode = "BLGroupCode";
        /// <summary> BLグループコード名称 </summary>
        public const string ct_Col_BLGroupName = "BLGroupName";
        /// <summary> BL商品コード </summary>
        public const string ct_Col_BLGoodsCode = "BLGoodsCode";
        /// <summary> BL商品コード名称（全角） </summary>
        public const string ct_Col_BLGoodsFullName = "BLGoodsFullName";
        /// <summary> 自社分類コード </summary>
        public const string ct_Col_EnterpriseGanreCode = "EnterpriseGanreCode";
        /// <summary> 自社分類名称 </summary>
        public const string ct_Col_EnterpriseGanreName = "EnterpriseGanreName";
        /// <summary> 倉庫コード </summary>
        public const string ct_Col_WarehouseCode = "WarehouseCode";
        /// <summary> 倉庫名称 </summary>
        public const string ct_Col_WarehouseName = "WarehouseName";
        /// <summary> 倉庫棚番 </summary>
        public const string ct_Col_WarehouseShelfNo = "WarehouseShelfNo";
        /// <summary> 売上在庫取寄せ区分 </summary>
        public const string ct_Col_SalesOrderDivCd = "SalesOrderDivCd";
        /// <summary> オープン価格区分 </summary>
        public const string ct_Col_OpenPriceDiv = "OpenPriceDiv";
        /// <summary> 商品掛率ランク </summary>
        public const string ct_Col_GoodsRateRank = "GoodsRateRank";
        /// <summary> 得意先掛率グループコード </summary>
        public const string ct_Col_CustRateGrpCode = "CustRateGrpCode";
        /// <summary> 定価率 </summary>
        public const string ct_Col_ListPriceRate = "ListPriceRate";
        /// <summary> 掛率設定拠点（定価） </summary>
        public const string ct_Col_RateSectPriceUnPrc = "RateSectPriceUnPrc";
        /// <summary> 掛率設定区分（定価） </summary>
        public const string ct_Col_RateDivLPrice = "RateDivLPrice";
        /// <summary> 単価算出区分（定価） </summary>
        public const string ct_Col_UnPrcCalcCdLPrice = "UnPrcCalcCdLPrice";
        /// <summary> 価格区分（定価） </summary>
        public const string ct_Col_PriceCdLPrice = "PriceCdLPrice";
        /// <summary> 基準単価（定価） </summary>
        public const string ct_Col_StdUnPrcLPrice = "StdUnPrcLPrice";
        /// <summary> 端数処理単位（定価） </summary>
        public const string ct_Col_FracProcUnitLPrice = "FracProcUnitLPrice";
        /// <summary> 端数処理（定価） </summary>
        public const string ct_Col_FracProcLPrice = "FracProcLPrice";
        /// <summary> 定価（税込，浮動） </summary>
        public const string ct_Col_ListPriceTaxIncFl = "ListPriceTaxIncFl";
        /// <summary> 定価（税抜，浮動） </summary>
        public const string ct_Col_ListPriceTaxExcFl = "ListPriceTaxExcFl";
        /// <summary> 定価変更区分 </summary>
        public const string ct_Col_ListPriceChngCd = "ListPriceChngCd";
        /// <summary> 売価率 </summary>
        public const string ct_Col_SalesRate = "SalesRate";
        /// <summary> 掛率設定拠点（売上単価） </summary>
        public const string ct_Col_RateSectSalUnPrc = "RateSectSalUnPrc";
        /// <summary> 掛率設定区分（売上単価） </summary>
        public const string ct_Col_RateDivSalUnPrc = "RateDivSalUnPrc";
        /// <summary> 単価算出区分（売上単価） </summary>
        public const string ct_Col_UnPrcCalcCdSalUnPrc = "UnPrcCalcCdSalUnPrc";
        /// <summary> 価格区分（売上単価） </summary>
        public const string ct_Col_PriceCdSalUnPrc = "PriceCdSalUnPrc";
        /// <summary> 基準単価（売上単価） </summary>
        public const string ct_Col_StdUnPrcSalUnPrc = "StdUnPrcSalUnPrc";
        /// <summary> 端数処理単位（売上単価） </summary>
        public const string ct_Col_FracProcUnitSalUnPrc = "FracProcUnitSalUnPrc";
        /// <summary> 端数処理（売上単価） </summary>
        public const string ct_Col_FracProcSalUnPrc = "FracProcSalUnPrc";
        /// <summary> 売上単価（税込，浮動） </summary>
        public const string ct_Col_SalesUnPrcTaxIncFl = "SalesUnPrcTaxIncFl";
        /// <summary> 売上単価（税抜，浮動） </summary>
        public const string ct_Col_SalesUnPrcTaxExcFl = "SalesUnPrcTaxExcFl";
        /// <summary> 売上単価変更区分 </summary>
        public const string ct_Col_SalesUnPrcChngCd = "SalesUnPrcChngCd";
        /// <summary> 原価率 </summary>
        public const string ct_Col_CostRate = "CostRate";
        /// <summary> 掛率設定拠点（原価単価） </summary>
        public const string ct_Col_RateSectCstUnPrc = "RateSectCstUnPrc";
        /// <summary> 掛率設定区分（原価単価） </summary>
        public const string ct_Col_RateDivUnCst = "RateDivUnCst";
        /// <summary> 単価算出区分（原価単価） </summary>
        public const string ct_Col_UnPrcCalcCdUnCst = "UnPrcCalcCdUnCst";
        /// <summary> 価格区分（原価単価） </summary>
        public const string ct_Col_PriceCdUnCst = "PriceCdUnCst";
        /// <summary> 基準単価（原価単価） </summary>
        public const string ct_Col_StdUnPrcUnCst = "StdUnPrcUnCst";
        /// <summary> 端数処理単位（原価単価） </summary>
        public const string ct_Col_FracProcUnitUnCst = "FracProcUnitUnCst";
        /// <summary> 端数処理（原価単価） </summary>
        public const string ct_Col_FracProcUnCst = "FracProcUnCst";
        /// <summary> 原価単価 </summary>
        public const string ct_Col_SalesUnitCost = "SalesUnitCost";
        /// <summary> 原価単価変更区分 </summary>
        public const string ct_Col_SalesUnitCostChngDiv = "SalesUnitCostChngDiv";
        /// <summary> BL商品コード（掛率） </summary>
        public const string ct_Col_RateBLGoodsCode = "RateBLGoodsCode";
        /// <summary> BL商品コード名称（掛率） </summary>
        public const string ct_Col_RateBLGoodsName = "RateBLGoodsName";
        /// <summary> 商品掛率グループコード（掛率） </summary>
        public const string ct_Col_RateGoodsRateGrpCd = "RateGoodsRateGrpCd";
        /// <summary> 商品掛率グループ名称（掛率） </summary>
        public const string ct_Col_RateGoodsRateGrpNm = "RateGoodsRateGrpNm";
        /// <summary> BLグループコード（掛率） </summary>
        public const string ct_Col_RateBLGroupCode = "RateBLGroupCode";
        /// <summary> BLグループ名称（掛率） </summary>
        public const string ct_Col_RateBLGroupName = "RateBLGroupName";
        /// <summary> BL商品コード（印刷） </summary>
        public const string ct_Col_PrtBLGoodsCode = "PrtBLGoodsCode";
        /// <summary> BL商品コード名称（印刷） </summary>
        public const string ct_Col_PrtBLGoodsName = "PrtBLGoodsName";
        /// <summary> 販売区分コード </summary>
        public const string ct_Col_SalesCode = "SalesCode";
        /// <summary> 販売区分名称 </summary>
        public const string ct_Col_SalesCdNm = "SalesCdNm";
        /// <summary> 作業工数 </summary>
        public const string ct_Col_WorkManHour = "WorkManHour";
        /// <summary> 出荷数 </summary>
        public const string ct_Col_ShipmentCnt = "ShipmentCnt";
        /// <summary> 受注数量 </summary>
        public const string ct_Col_AcceptAnOrderCnt = "AcceptAnOrderCnt";
        /// <summary> 受注調整数 </summary>
        public const string ct_Col_AcptAnOdrAdjustCnt = "AcptAnOdrAdjustCnt";
        /// <summary> 受注残数 </summary>
        public const string ct_Col_AcptAnOdrRemainCnt = "AcptAnOdrRemainCnt";
        /// <summary> 残数更新日 </summary>
        public const string ct_Col_RemainCntUpdDate = "RemainCntUpdDate";
        /// <summary> 売上金額（税込み） </summary>
        public const string ct_Col_SalesMoneyTaxInc = "SalesMoneyTaxInc";
        /// <summary> 売上金額（税抜き） </summary>
        public const string ct_Col_SalesMoneyTaxExc = "SalesMoneyTaxExc";
        /// <summary> 原価 </summary>
        public const string ct_Col_Cost = "Cost";
        /// <summary> 粗利チェック区分 </summary>
        public const string ct_Col_GrsProfitChkDiv = "GrsProfitChkDiv";
        /// <summary> 売上商品区分 </summary>
        public const string ct_Col_SalesGoodsCd = "SalesGoodsCd";
        /// <summary> 売上金額消費税額 </summary>
        public const string ct_Col_SalesPriceConsTax = "SalesPriceConsTax";
        /// <summary> 課税区分 </summary>
        public const string ct_Col_TaxationDivCd = "TaxationDivCd";
        /// <summary> 相手先伝票番号（明細） </summary>
        public const string ct_Col_PartySlipNumDtl = "PartySlipNumDtl";
        /// <summary> 明細備考 </summary>
        public const string ct_Col_DtlNote = "DtlNote";
        /// <summary> 仕入先コード </summary>
        public const string ct_Col_SupplierCd = "SupplierCd";
        /// <summary> 仕入先略称 </summary>
        public const string ct_Col_SupplierSnm = "SupplierSnm";
        /// <summary> 発注番号 </summary>
        public const string ct_Col_OrderNumber = "OrderNumber";
        /// <summary> 注文方法 </summary>
        public const string ct_Col_WayToOrder = "WayToOrder";
        /// <summary> 伝票メモ１ </summary>
        public const string ct_Col_SlipMemo1 = "SlipMemo1";
        /// <summary> 伝票メモ２ </summary>
        public const string ct_Col_SlipMemo2 = "SlipMemo2";
        /// <summary> 伝票メモ３ </summary>
        public const string ct_Col_SlipMemo3 = "SlipMemo3";
        /// <summary> 社内メモ１ </summary>
        public const string ct_Col_InsideMemo1 = "InsideMemo1";
        /// <summary> 社内メモ２ </summary>
        public const string ct_Col_InsideMemo2 = "InsideMemo2";
        /// <summary> 社内メモ３ </summary>
        public const string ct_Col_InsideMemo3 = "InsideMemo3";
        /// <summary> 変更前定価 </summary>
        public const string ct_Col_BfListPrice = "BfListPrice";
        /// <summary> 変更前売価 </summary>
        public const string ct_Col_BfSalesUnitPrice = "BfSalesUnitPrice";
        /// <summary> 変更前原価 </summary>
        public const string ct_Col_BfUnitCost = "BfUnitCost";
        /// <summary> 一式明細番号 </summary>
        public const string ct_Col_CmpltSalesRowNo = "CmpltSalesRowNo";
        /// <summary> メーカーコード（一式） </summary>
        public const string ct_Col_CmpltGoodsMakerCd = "CmpltGoodsMakerCd";
        /// <summary> メーカー名称（一式） </summary>
        public const string ct_Col_CmpltMakerName = "CmpltMakerName";
        /// <summary> メーカーカナ名称（一式） </summary>
        public const string ct_Col_CmpltMakerKanaName = "CmpltMakerKanaName";
        /// <summary> 商品名称（一式） </summary>
        public const string ct_Col_CmpltGoodsName = "CmpltGoodsName";
        /// <summary> 数量（一式） </summary>
        public const string ct_Col_CmpltShipmentCnt = "CmpltShipmentCnt";
        /// <summary> 売上単価（一式） </summary>
        public const string ct_Col_CmpltSalesUnPrcFl = "CmpltSalesUnPrcFl";
        /// <summary> 売上金額（一式） </summary>
        public const string ct_Col_CmpltSalesMoney = "CmpltSalesMoney";
        /// <summary> 原価単価（一式） </summary>
        public const string ct_Col_CmpltSalesUnitCost = "CmpltSalesUnitCost";
        /// <summary> 原価金額（一式） </summary>
        public const string ct_Col_CmpltCost = "CmpltCost";
        /// <summary> 相手先伝票番号（一式） </summary>
        public const string ct_Col_CmpltPartySalSlNum = "CmpltPartySalSlNum";
        /// <summary> 一式備考 </summary>
        public const string ct_Col_CmpltNote = "CmpltNote";
        /// <summary> 印刷用品番 </summary>
        public const string ct_Col_PrtGoodsNo = "PrtGoodsNo";
        /// <summary> 印刷用メーカーコード </summary>
        public const string ct_Col_PrtMakerCode = "PrtMakerCode";
        /// <summary> 印刷用メーカー名称 </summary>
        public const string ct_Col_PrtMakerName = "PrtMakerName";
        /// <summary> 出荷差分数 </summary>
        public const string ct_Col_ShipmCntDifference = "ShipmCntDifference";
        /// <summary> 明細関連付けGUID </summary>
        public const string ct_Col_DtlRelationGuid = "DtlRelationGuid";
        /// <summary> 在庫更新区分 </summary>
        public const string ct_Col_StockUpdateDiv = "StockUpdateDiv";

        /// <summary> 売上伝票番号（仮） </summary>
        public const string ct_Col_TempSalesSlipNum = "TempSalesSlipNum";
        /// <summary> 売上明細通番（仮） </summary>
        public const string ct_Col_TempSalesSlipDtlNum = "TempSalesSlipDtlNum";


        /// <summary> (印刷用)受信時刻 </summary>
        public const string ct_Col_PrtReceiveTime = "PrtReceiveTime";
        /// <summary> (印刷用)BO区分 </summary>
        public const string ct_Col_PrtBoCode = "PrtBoCode";
        /// <summary> (印刷用)納品区分 </summary>
        public const string ct_Col_PrtUOEDeliGoodsDiv = "PrtUOEDeliGoodsDiv";
        /// <summary> (印刷用)納品区分名称 </summary>
        public const string ct_Col_PrtDeliveredGoodsDivNm = "PrtDeliveredGoodsDivNm";
        /// <summary> (印刷用)フォロー納品区分 </summary>
        public const string ct_Col_PrtFollowDeliGoodsDiv = "PrtFollowDeliGoodsDiv";
        /// <summary> (印刷用)フォロー納品区分名称 </summary>
        public const string ct_Col_PrtFollowDeliGoodsDivNm = "PrtFollowDeliGoodsDivNm";
        /// <summary>(印刷用)受注数</summary>
        public const string ct_Col_PrtAcceptAnOrderCnt = "PrtAcceptAnOrderCnt";
        /// <summary>(印刷用)出庫数</summary>
        public const string ct_Col_PrtShipmentCnt = "PrtShipmentCnt";
        /// <summary>(印刷用)拠点出庫数</summary>
        public const string ct_Col_PrtUOESectOutGoodsCnt = "PrtUOESectOutGoodsCnt";
        /// <summary>(印刷用)BO出庫数</summary>
        public const string ct_Col_PrtBOShipmentCnt = "PrtBOShipmentCnt";
        /// <summary>明細種別</summary>
        public const string ct_Col_DetailCd = "DetailCd";

        // 2011/01/19 Add >>>
        /// <summary>キャンペーンコード</summary>
        public const string ct_Col_CampaignCode = "CampaignCode";
        /// <summary>キャンペーン名称</summary>
        public const string ct_Col_CampaignName = "CampaignName";
        /// <summary>商品種別</summary>
        public const string ct_Col_GoodsDivCd = "GoodsDivCd";
        /// <summary>回答納期</summary>
        public const string ct_Col_AnswerDelivDate = "AnswerDelivDate";
        /// <summary>リサイクル区分</summary>
        public const string ct_Col_RecycleDiv = "RecycleDiv";
        /// <summary>リサイクル区分名称</summary>
        public const string ct_Col_RecycleDivNm = "RecycleDivNm";
        /// <summary>受注方法</summary>
        public const string ct_Col_WayToAcptOdr = "WayToAcptOdr";
        // 2011/01/19 Add <<<
        // 2011/07/28 Add >>>
        /// <summary>自動回答区分</summary>
        public const string ct_Col_AutoAnswerDivSCM = "AutoAnswerDivSCM";
        // 2011/07/28 Add <<<
        // 2012/01/16 Add >>>
        /// <summary>特記事項</summary>
        public const string ct_Col_GoodsSpecialNote = "GoodsSpecialNote";
        // 2012/01/16 Add <<<

        // ADD 2012/12/06 2012/12/12配信予定 SCM障害№10447対応 ----------------------------------->>>>>
        /// <summary>受発注種別</summary>
        public const string ct_Col_AcceptOrOrderKind = "AcceptOrOrderKind";
        // ADD 2012/12/06 2012/12/12配信予定 SCM障害№10447対応 -----------------------------------<<<<<

        #endregion

        #endregion

        #region Constructor
        /// <summary>
        /// 売上明細テーブルスキーマクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 売上明細テーブルスキーマクラスの初期化及びインスタンス生成を行います。</br>
        /// <br>Programmer : 96186　立花裕輔</br>
        /// <br>Date       : 2008.05.26</br>
        /// </remarks>
        public SalesDetailSchema()
        {
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// データセット、データテーブル設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br>Programmer : 96186 立花裕輔</br>
        /// <br>Date       : 2006.01.21</br>
        /// </remarks>
        public static void SettingDataSet(ref DataSet ds, string dataTableName)
        {
            // テーブルが存在するかどうかをチェック
            if ((ds.Tables.Contains(dataTableName)))
            {
                // TODO:テーブルが存在するときはクリアーするのみ
                // スキーマをもう一度設定するようなことはしない。
                ds.Tables[dataTableName].Clear();
            }
            else
            {
                CreateTable(ref ds, dataTableName);

            }
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// 売上明細作成処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br>Programmer : 96186 立花裕輔</br>
        /// <br>Date       : 2008.05.26</br>
        /// </remarks>
        private static void CreateTable(ref DataSet ds, string dataTableName)
        {
            DataTable dt = null;
            // スキーマ設定
            ds.Tables.Add(dataTableName);
            dt = ds.Tables[dataTableName];

            // 作成日時
            dt.Columns.Add(ct_Col_CreateDateTime, typeof(Int64));
            dt.Columns[ct_Col_CreateDateTime].DefaultValue = defValueInt64;
            // 更新日時
            dt.Columns.Add(ct_Col_UpdateDateTime, typeof(Int64));
            dt.Columns[ct_Col_UpdateDateTime].DefaultValue = defValueInt64;
            // 企業コード
            dt.Columns.Add(ct_Col_EnterpriseCode, typeof(string));
            dt.Columns[ct_Col_EnterpriseCode].DefaultValue = defValuestring;
            // GUID
            dt.Columns.Add(ct_Col_FileHeaderGuid, typeof(Guid));
            dt.Columns[ct_Col_FileHeaderGuid].DefaultValue = Guid.Empty;
            // 更新従業員コード
            dt.Columns.Add(ct_Col_UpdEmployeeCode, typeof(string));
            dt.Columns[ct_Col_UpdEmployeeCode].DefaultValue = defValuestring;
            // 更新アセンブリID1
            dt.Columns.Add(ct_Col_UpdAssemblyId1, typeof(string));
            dt.Columns[ct_Col_UpdAssemblyId1].DefaultValue = defValuestring;
            // 更新アセンブリID2
            dt.Columns.Add(ct_Col_UpdAssemblyId2, typeof(string));
            dt.Columns[ct_Col_UpdAssemblyId2].DefaultValue = defValuestring;
            // 論理削除区分
            dt.Columns.Add(ct_Col_LogicalDeleteCode, typeof(Int32));
            dt.Columns[ct_Col_LogicalDeleteCode].DefaultValue = defValueInt32;
            // 受注番号
            dt.Columns.Add(ct_Col_AcceptAnOrderNo, typeof(Int32));
            dt.Columns[ct_Col_AcceptAnOrderNo].DefaultValue = defValueInt32;
            // 受注ステータス
            dt.Columns.Add(ct_Col_AcptAnOdrStatus, typeof(Int32));
            dt.Columns[ct_Col_AcptAnOdrStatus].DefaultValue = defValueInt32;
            // 売上伝票番号
            dt.Columns.Add(ct_Col_SalesSlipNum, typeof(string));
            dt.Columns[ct_Col_SalesSlipNum].DefaultValue = defValuestring;
            // 売上行番号
            dt.Columns.Add(ct_Col_SalesRowNo, typeof(Int32));
            dt.Columns[ct_Col_SalesRowNo].DefaultValue = defValueInt32;
            // 売上行番号枝番
            dt.Columns.Add(ct_Col_SalesRowDerivNo, typeof(Int32));
            dt.Columns[ct_Col_SalesRowDerivNo].DefaultValue = defValueInt32;
            // 拠点コード
            dt.Columns.Add(ct_Col_SectionCode, typeof(string));
            dt.Columns[ct_Col_SectionCode].DefaultValue = defValuestring;
            // 部門コード
            dt.Columns.Add(ct_Col_SubSectionCode, typeof(Int32));
            dt.Columns[ct_Col_SubSectionCode].DefaultValue = defValueInt32;
            // 売上日付
            dt.Columns.Add(ct_Col_SalesDate, typeof(DateTime));
            dt.Columns[ct_Col_SalesDate].DefaultValue = DateTime.MinValue;
            // 共通通番
            dt.Columns.Add(ct_Col_CommonSeqNo, typeof(Int64));
            dt.Columns[ct_Col_CommonSeqNo].DefaultValue = defValueInt64;
            // 売上明細通番
            dt.Columns.Add(ct_Col_SalesSlipDtlNum, typeof(Int64));
            dt.Columns[ct_Col_SalesSlipDtlNum].DefaultValue = defValueInt64;
            // 受注ステータス（元）
            dt.Columns.Add(ct_Col_AcptAnOdrStatusSrc, typeof(Int32));
            dt.Columns[ct_Col_AcptAnOdrStatusSrc].DefaultValue = defValueInt32;
            // 売上明細通番（元）
            dt.Columns.Add(ct_Col_SalesSlipDtlNumSrc, typeof(Int64));
            dt.Columns[ct_Col_SalesSlipDtlNumSrc].DefaultValue = defValueInt64;
            // 仕入形式（同時）
            dt.Columns.Add(ct_Col_SupplierFormalSync, typeof(Int32));
            dt.Columns[ct_Col_SupplierFormalSync].DefaultValue = defValueInt32;
            // 仕入明細通番（同時）
            dt.Columns.Add(ct_Col_StockSlipDtlNumSync, typeof(Int64));
            dt.Columns[ct_Col_StockSlipDtlNumSync].DefaultValue = defValueInt64;
            // 売上伝票区分（明細）
            dt.Columns.Add(ct_Col_SalesSlipCdDtl, typeof(Int32));
            dt.Columns[ct_Col_SalesSlipCdDtl].DefaultValue = defValueInt32;
            // 納品完了予定日
            dt.Columns.Add(ct_Col_DeliGdsCmpltDueDate, typeof(DateTime));
            dt.Columns[ct_Col_DeliGdsCmpltDueDate].DefaultValue = DateTime.MinValue;
            // 商品属性
            dt.Columns.Add(ct_Col_GoodsKindCode, typeof(Int32));
            dt.Columns[ct_Col_GoodsKindCode].DefaultValue = defValueInt32;
            // 商品検索区分
            dt.Columns.Add(ct_Col_GoodsSearchDivCd, typeof(Int32));
            dt.Columns[ct_Col_GoodsSearchDivCd].DefaultValue = defValueInt32;
            // 商品メーカーコード
            dt.Columns.Add(ct_Col_GoodsMakerCd, typeof(Int32));
            dt.Columns[ct_Col_GoodsMakerCd].DefaultValue = defValueInt32;
            // メーカー名称
            dt.Columns.Add(ct_Col_MakerName, typeof(string));
            dt.Columns[ct_Col_MakerName].DefaultValue = defValuestring;
            // メーカーカナ名称
            dt.Columns.Add(ct_Col_MakerKanaName, typeof(string));
            dt.Columns[ct_Col_MakerKanaName].DefaultValue = defValuestring;
            // 商品番号
            dt.Columns.Add(ct_Col_GoodsNo, typeof(string));
            dt.Columns[ct_Col_GoodsNo].DefaultValue = defValuestring;
            // 商品名称
            dt.Columns.Add(ct_Col_GoodsName, typeof(string));
            dt.Columns[ct_Col_GoodsName].DefaultValue = defValuestring;
            // 商品名称カナ
            dt.Columns.Add(ct_Col_GoodsNameKana, typeof(string));
            dt.Columns[ct_Col_GoodsNameKana].DefaultValue = defValuestring;
            // 商品大分類コード
            dt.Columns.Add(ct_Col_GoodsLGroup, typeof(Int32));
            dt.Columns[ct_Col_GoodsLGroup].DefaultValue = defValueInt32;
            // 商品大分類名称
            dt.Columns.Add(ct_Col_GoodsLGroupName, typeof(string));
            dt.Columns[ct_Col_GoodsLGroupName].DefaultValue = defValuestring;
            // 商品中分類コード
            dt.Columns.Add(ct_Col_GoodsMGroup, typeof(Int32));
            dt.Columns[ct_Col_GoodsMGroup].DefaultValue = defValueInt32;
            // 商品中分類名称
            dt.Columns.Add(ct_Col_GoodsMGroupName, typeof(string));
            dt.Columns[ct_Col_GoodsMGroupName].DefaultValue = defValuestring;
            // BLグループコード
            dt.Columns.Add(ct_Col_BLGroupCode, typeof(Int32));
            dt.Columns[ct_Col_BLGroupCode].DefaultValue = defValueInt32;
            // BLグループコード名称
            dt.Columns.Add(ct_Col_BLGroupName, typeof(string));
            dt.Columns[ct_Col_BLGroupName].DefaultValue = defValuestring;
            // BL商品コード
            dt.Columns.Add(ct_Col_BLGoodsCode, typeof(Int32));
            dt.Columns[ct_Col_BLGoodsCode].DefaultValue = defValueInt32;
            // BL商品コード名称（全角）
            dt.Columns.Add(ct_Col_BLGoodsFullName, typeof(string));
            dt.Columns[ct_Col_BLGoodsFullName].DefaultValue = defValuestring;
            // 自社分類コード
            dt.Columns.Add(ct_Col_EnterpriseGanreCode, typeof(Int32));
            dt.Columns[ct_Col_EnterpriseGanreCode].DefaultValue = defValueInt32;
            // 自社分類名称
            dt.Columns.Add(ct_Col_EnterpriseGanreName, typeof(string));
            dt.Columns[ct_Col_EnterpriseGanreName].DefaultValue = defValuestring;
            // 倉庫コード
            dt.Columns.Add(ct_Col_WarehouseCode, typeof(string));
            dt.Columns[ct_Col_WarehouseCode].DefaultValue = defValuestring;
            // 倉庫名称
            dt.Columns.Add(ct_Col_WarehouseName, typeof(string));
            dt.Columns[ct_Col_WarehouseName].DefaultValue = defValuestring;
            // 倉庫棚番
            dt.Columns.Add(ct_Col_WarehouseShelfNo, typeof(string));
            dt.Columns[ct_Col_WarehouseShelfNo].DefaultValue = defValuestring;
            // 売上在庫取寄せ区分
            dt.Columns.Add(ct_Col_SalesOrderDivCd, typeof(Int32));
            dt.Columns[ct_Col_SalesOrderDivCd].DefaultValue = defValueInt32;
            // オープン価格区分
            dt.Columns.Add(ct_Col_OpenPriceDiv, typeof(Int32));
            dt.Columns[ct_Col_OpenPriceDiv].DefaultValue = defValueInt32;
            // 商品掛率ランク
            dt.Columns.Add(ct_Col_GoodsRateRank, typeof(string));
            dt.Columns[ct_Col_GoodsRateRank].DefaultValue = defValuestring;
            // 得意先掛率グループコード
            dt.Columns.Add(ct_Col_CustRateGrpCode, typeof(Int32));
            dt.Columns[ct_Col_CustRateGrpCode].DefaultValue = defValueInt32;
            // 定価率
            dt.Columns.Add(ct_Col_ListPriceRate, typeof(Double));
            dt.Columns[ct_Col_ListPriceRate].DefaultValue = defValueDouble;
            // 掛率設定拠点（定価）
            dt.Columns.Add(ct_Col_RateSectPriceUnPrc, typeof(string));
            dt.Columns[ct_Col_RateSectPriceUnPrc].DefaultValue = defValuestring;
            // 掛率設定区分（定価）
            dt.Columns.Add(ct_Col_RateDivLPrice, typeof(string));
            dt.Columns[ct_Col_RateDivLPrice].DefaultValue = defValuestring;
            // 単価算出区分（定価）
            dt.Columns.Add(ct_Col_UnPrcCalcCdLPrice, typeof(Int32));
            dt.Columns[ct_Col_UnPrcCalcCdLPrice].DefaultValue = defValueInt32;
            // 価格区分（定価）
            dt.Columns.Add(ct_Col_PriceCdLPrice, typeof(Int32));
            dt.Columns[ct_Col_PriceCdLPrice].DefaultValue = defValueInt32;
            // 基準単価（定価）
            dt.Columns.Add(ct_Col_StdUnPrcLPrice, typeof(Double));
            dt.Columns[ct_Col_StdUnPrcLPrice].DefaultValue = defValueDouble;
            // 端数処理単位（定価）
            dt.Columns.Add(ct_Col_FracProcUnitLPrice, typeof(Double));
            dt.Columns[ct_Col_FracProcUnitLPrice].DefaultValue = defValueDouble;
            // 端数処理（定価）
            dt.Columns.Add(ct_Col_FracProcLPrice, typeof(Int32));
            dt.Columns[ct_Col_FracProcLPrice].DefaultValue = defValueInt32;
            // 定価（税込，浮動）
            dt.Columns.Add(ct_Col_ListPriceTaxIncFl, typeof(Double));
            dt.Columns[ct_Col_ListPriceTaxIncFl].DefaultValue = defValueDouble;
            // 定価（税抜，浮動）
            dt.Columns.Add(ct_Col_ListPriceTaxExcFl, typeof(Double));
            dt.Columns[ct_Col_ListPriceTaxExcFl].DefaultValue = defValueDouble;
            // 定価変更区分
            dt.Columns.Add(ct_Col_ListPriceChngCd, typeof(Int32));
            dt.Columns[ct_Col_ListPriceChngCd].DefaultValue = defValueInt32;
            // 売価率
            dt.Columns.Add(ct_Col_SalesRate, typeof(Double));
            dt.Columns[ct_Col_SalesRate].DefaultValue = defValueDouble;
            // 掛率設定拠点（売上単価）
            dt.Columns.Add(ct_Col_RateSectSalUnPrc, typeof(string));
            dt.Columns[ct_Col_RateSectSalUnPrc].DefaultValue = defValuestring;
            // 掛率設定区分（売上単価）
            dt.Columns.Add(ct_Col_RateDivSalUnPrc, typeof(string));
            dt.Columns[ct_Col_RateDivSalUnPrc].DefaultValue = defValuestring;
            // 単価算出区分（売上単価）
            dt.Columns.Add(ct_Col_UnPrcCalcCdSalUnPrc, typeof(Int32));
            dt.Columns[ct_Col_UnPrcCalcCdSalUnPrc].DefaultValue = defValueInt32;
            // 価格区分（売上単価）
            dt.Columns.Add(ct_Col_PriceCdSalUnPrc, typeof(Int32));
            dt.Columns[ct_Col_PriceCdSalUnPrc].DefaultValue = defValueInt32;
            // 基準単価（売上単価）
            dt.Columns.Add(ct_Col_StdUnPrcSalUnPrc, typeof(Double));
            dt.Columns[ct_Col_StdUnPrcSalUnPrc].DefaultValue = defValueDouble;
            // 端数処理単位（売上単価）
            dt.Columns.Add(ct_Col_FracProcUnitSalUnPrc, typeof(Double));
            dt.Columns[ct_Col_FracProcUnitSalUnPrc].DefaultValue = defValueDouble;
            // 端数処理（売上単価）
            dt.Columns.Add(ct_Col_FracProcSalUnPrc, typeof(Int32));
            dt.Columns[ct_Col_FracProcSalUnPrc].DefaultValue = defValueInt32;
            // 売上単価（税込，浮動）
            dt.Columns.Add(ct_Col_SalesUnPrcTaxIncFl, typeof(Double));
            dt.Columns[ct_Col_SalesUnPrcTaxIncFl].DefaultValue = defValueDouble;
            // 売上単価（税抜，浮動）
            dt.Columns.Add(ct_Col_SalesUnPrcTaxExcFl, typeof(Double));
            dt.Columns[ct_Col_SalesUnPrcTaxExcFl].DefaultValue = defValueDouble;
            // 売上単価変更区分
            dt.Columns.Add(ct_Col_SalesUnPrcChngCd, typeof(Int32));
            dt.Columns[ct_Col_SalesUnPrcChngCd].DefaultValue = defValueInt32;
            // 原価率
            dt.Columns.Add(ct_Col_CostRate, typeof(Double));
            dt.Columns[ct_Col_CostRate].DefaultValue = defValueDouble;
            // 掛率設定拠点（原価単価）
            dt.Columns.Add(ct_Col_RateSectCstUnPrc, typeof(string));
            dt.Columns[ct_Col_RateSectCstUnPrc].DefaultValue = defValuestring;
            // 掛率設定区分（原価単価）
            dt.Columns.Add(ct_Col_RateDivUnCst, typeof(string));
            dt.Columns[ct_Col_RateDivUnCst].DefaultValue = defValuestring;
            // 単価算出区分（原価単価）
            dt.Columns.Add(ct_Col_UnPrcCalcCdUnCst, typeof(Int32));
            dt.Columns[ct_Col_UnPrcCalcCdUnCst].DefaultValue = defValueInt32;
            // 価格区分（原価単価）
            dt.Columns.Add(ct_Col_PriceCdUnCst, typeof(Int32));
            dt.Columns[ct_Col_PriceCdUnCst].DefaultValue = defValueInt32;
            // 基準単価（原価単価）
            dt.Columns.Add(ct_Col_StdUnPrcUnCst, typeof(Double));
            dt.Columns[ct_Col_StdUnPrcUnCst].DefaultValue = defValueDouble;
            // 端数処理単位（原価単価）
            dt.Columns.Add(ct_Col_FracProcUnitUnCst, typeof(Double));
            dt.Columns[ct_Col_FracProcUnitUnCst].DefaultValue = defValueDouble;
            // 端数処理（原価単価）
            dt.Columns.Add(ct_Col_FracProcUnCst, typeof(Int32));
            dt.Columns[ct_Col_FracProcUnCst].DefaultValue = defValueInt32;
            // 原価単価
            dt.Columns.Add(ct_Col_SalesUnitCost, typeof(Double));
            dt.Columns[ct_Col_SalesUnitCost].DefaultValue = defValueDouble;
            // 原価単価変更区分
            dt.Columns.Add(ct_Col_SalesUnitCostChngDiv, typeof(Int32));
            dt.Columns[ct_Col_SalesUnitCostChngDiv].DefaultValue = defValueInt32;
            // BL商品コード（掛率）
            dt.Columns.Add(ct_Col_RateBLGoodsCode, typeof(Int32));
            dt.Columns[ct_Col_RateBLGoodsCode].DefaultValue = defValueInt32;
            // BL商品コード名称（掛率）
            dt.Columns.Add(ct_Col_RateBLGoodsName, typeof(string));
            dt.Columns[ct_Col_RateBLGoodsName].DefaultValue = defValuestring;
            // 商品掛率グループコード（掛率）
            dt.Columns.Add(ct_Col_RateGoodsRateGrpCd, typeof(Int32));
            dt.Columns[ct_Col_RateGoodsRateGrpCd].DefaultValue = defValueInt32;
            // 商品掛率グループ名称（掛率）
            dt.Columns.Add(ct_Col_RateGoodsRateGrpNm, typeof(string));
            dt.Columns[ct_Col_RateGoodsRateGrpNm].DefaultValue = defValuestring;
            // BLグループコード（掛率）
            dt.Columns.Add(ct_Col_RateBLGroupCode, typeof(Int32));
            dt.Columns[ct_Col_RateBLGroupCode].DefaultValue = defValueInt32;
            // BLグループ名称（掛率）
            dt.Columns.Add(ct_Col_RateBLGroupName, typeof(string));
            dt.Columns[ct_Col_RateBLGroupName].DefaultValue = defValuestring;
            // BL商品コード（印刷）
            dt.Columns.Add(ct_Col_PrtBLGoodsCode, typeof(Int32));
            dt.Columns[ct_Col_PrtBLGoodsCode].DefaultValue = defValueInt32;
            // BL商品コード名称（印刷）
            dt.Columns.Add(ct_Col_PrtBLGoodsName, typeof(string));
            dt.Columns[ct_Col_PrtBLGoodsName].DefaultValue = defValuestring;
            // 販売区分コード
            dt.Columns.Add(ct_Col_SalesCode, typeof(Int32));
            dt.Columns[ct_Col_SalesCode].DefaultValue = defValueInt32;
            // 販売区分名称
            dt.Columns.Add(ct_Col_SalesCdNm, typeof(string));
            dt.Columns[ct_Col_SalesCdNm].DefaultValue = defValuestring;
            // 作業工数
            dt.Columns.Add(ct_Col_WorkManHour, typeof(Double));
            dt.Columns[ct_Col_WorkManHour].DefaultValue = defValueDouble;
            // 出荷数
            dt.Columns.Add(ct_Col_ShipmentCnt, typeof(Double));
            dt.Columns[ct_Col_ShipmentCnt].DefaultValue = defValueDouble;
            // 受注数量
            dt.Columns.Add(ct_Col_AcceptAnOrderCnt, typeof(Double));
            dt.Columns[ct_Col_AcceptAnOrderCnt].DefaultValue = defValueDouble;
            // 受注調整数
            dt.Columns.Add(ct_Col_AcptAnOdrAdjustCnt, typeof(Double));
            dt.Columns[ct_Col_AcptAnOdrAdjustCnt].DefaultValue = defValueDouble;
            // 受注残数
            dt.Columns.Add(ct_Col_AcptAnOdrRemainCnt, typeof(Double));
            dt.Columns[ct_Col_AcptAnOdrRemainCnt].DefaultValue = defValueDouble;
            // 残数更新日
            dt.Columns.Add(ct_Col_RemainCntUpdDate, typeof(DateTime));
            dt.Columns[ct_Col_RemainCntUpdDate].DefaultValue = DateTime.MinValue;
            // 売上金額（税込み）
            dt.Columns.Add(ct_Col_SalesMoneyTaxInc, typeof(Int64));
            dt.Columns[ct_Col_SalesMoneyTaxInc].DefaultValue = defValueInt64;
            // 売上金額（税抜き）
            dt.Columns.Add(ct_Col_SalesMoneyTaxExc, typeof(Int64));
            dt.Columns[ct_Col_SalesMoneyTaxExc].DefaultValue = defValueInt64;
            // 原価
            dt.Columns.Add(ct_Col_Cost, typeof(Int64));
            dt.Columns[ct_Col_Cost].DefaultValue = defValueInt64;
            // 粗利チェック区分
            dt.Columns.Add(ct_Col_GrsProfitChkDiv, typeof(Int32));
            dt.Columns[ct_Col_GrsProfitChkDiv].DefaultValue = defValueInt32;
            // 売上商品区分
            dt.Columns.Add(ct_Col_SalesGoodsCd, typeof(Int32));
            dt.Columns[ct_Col_SalesGoodsCd].DefaultValue = defValueInt32;
            // 売上金額消費税額
            dt.Columns.Add(ct_Col_SalesPriceConsTax, typeof(Int64));
            dt.Columns[ct_Col_SalesPriceConsTax].DefaultValue = defValueInt64;
            // 課税区分
            dt.Columns.Add(ct_Col_TaxationDivCd, typeof(Int32));
            dt.Columns[ct_Col_TaxationDivCd].DefaultValue = defValueInt32;
            // 相手先伝票番号（明細）
            dt.Columns.Add(ct_Col_PartySlipNumDtl, typeof(string));
            dt.Columns[ct_Col_PartySlipNumDtl].DefaultValue = defValuestring;
            // 明細備考
            dt.Columns.Add(ct_Col_DtlNote, typeof(string));
            dt.Columns[ct_Col_DtlNote].DefaultValue = defValuestring;
            // 仕入先コード
            dt.Columns.Add(ct_Col_SupplierCd, typeof(Int32));
            dt.Columns[ct_Col_SupplierCd].DefaultValue = defValueInt32;
            // 仕入先略称
            dt.Columns.Add(ct_Col_SupplierSnm, typeof(string));
            dt.Columns[ct_Col_SupplierSnm].DefaultValue = defValuestring;
            // 発注番号
            dt.Columns.Add(ct_Col_OrderNumber, typeof(string));
            dt.Columns[ct_Col_OrderNumber].DefaultValue = defValuestring;
            // 注文方法
            dt.Columns.Add(ct_Col_WayToOrder, typeof(Int32));
            dt.Columns[ct_Col_WayToOrder].DefaultValue = defValueInt32;
            // 伝票メモ１
            dt.Columns.Add(ct_Col_SlipMemo1, typeof(string));
            dt.Columns[ct_Col_SlipMemo1].DefaultValue = defValuestring;
            // 伝票メモ２
            dt.Columns.Add(ct_Col_SlipMemo2, typeof(string));
            dt.Columns[ct_Col_SlipMemo2].DefaultValue = defValuestring;
            // 伝票メモ３
            dt.Columns.Add(ct_Col_SlipMemo3, typeof(string));
            dt.Columns[ct_Col_SlipMemo3].DefaultValue = defValuestring;
            // 社内メモ１
            dt.Columns.Add(ct_Col_InsideMemo1, typeof(string));
            dt.Columns[ct_Col_InsideMemo1].DefaultValue = defValuestring;
            // 社内メモ２
            dt.Columns.Add(ct_Col_InsideMemo2, typeof(string));
            dt.Columns[ct_Col_InsideMemo2].DefaultValue = defValuestring;
            // 社内メモ３
            dt.Columns.Add(ct_Col_InsideMemo3, typeof(string));
            dt.Columns[ct_Col_InsideMemo3].DefaultValue = defValuestring;
            // 変更前定価
            dt.Columns.Add(ct_Col_BfListPrice, typeof(Double));
            dt.Columns[ct_Col_BfListPrice].DefaultValue = defValueDouble;
            // 変更前売価
            dt.Columns.Add(ct_Col_BfSalesUnitPrice, typeof(Double));
            dt.Columns[ct_Col_BfSalesUnitPrice].DefaultValue = defValueDouble;
            // 変更前原価
            dt.Columns.Add(ct_Col_BfUnitCost, typeof(Double));
            dt.Columns[ct_Col_BfUnitCost].DefaultValue = defValueDouble;
            // 一式明細番号
            dt.Columns.Add(ct_Col_CmpltSalesRowNo, typeof(Int32));
            dt.Columns[ct_Col_CmpltSalesRowNo].DefaultValue = defValueInt32;
            // メーカーコード（一式）
            dt.Columns.Add(ct_Col_CmpltGoodsMakerCd, typeof(Int32));
            dt.Columns[ct_Col_CmpltGoodsMakerCd].DefaultValue = defValueInt32;
            // メーカー名称（一式）
            dt.Columns.Add(ct_Col_CmpltMakerName, typeof(string));
            dt.Columns[ct_Col_CmpltMakerName].DefaultValue = defValuestring;
            // メーカーカナ名称（一式）
            dt.Columns.Add(ct_Col_CmpltMakerKanaName, typeof(string));
            dt.Columns[ct_Col_CmpltMakerKanaName].DefaultValue = defValuestring;
            // 商品名称（一式）
            dt.Columns.Add(ct_Col_CmpltGoodsName, typeof(string));
            dt.Columns[ct_Col_CmpltGoodsName].DefaultValue = defValuestring;
            // 数量（一式）
            dt.Columns.Add(ct_Col_CmpltShipmentCnt, typeof(Double));
            dt.Columns[ct_Col_CmpltShipmentCnt].DefaultValue = defValueDouble;
            // 売上単価（一式）
            dt.Columns.Add(ct_Col_CmpltSalesUnPrcFl, typeof(Double));
            dt.Columns[ct_Col_CmpltSalesUnPrcFl].DefaultValue = defValueDouble;
            // 売上金額（一式）
            dt.Columns.Add(ct_Col_CmpltSalesMoney, typeof(Int64));
            dt.Columns[ct_Col_CmpltSalesMoney].DefaultValue = defValueInt64;
            // 原価単価（一式）
            dt.Columns.Add(ct_Col_CmpltSalesUnitCost, typeof(Double));
            dt.Columns[ct_Col_CmpltSalesUnitCost].DefaultValue = defValueDouble;
            // 原価金額（一式）
            dt.Columns.Add(ct_Col_CmpltCost, typeof(Int64));
            dt.Columns[ct_Col_CmpltCost].DefaultValue = defValueInt64;
            // 相手先伝票番号（一式）
            dt.Columns.Add(ct_Col_CmpltPartySalSlNum, typeof(string));
            dt.Columns[ct_Col_CmpltPartySalSlNum].DefaultValue = defValuestring;
            // 一式備考
            dt.Columns.Add(ct_Col_CmpltNote, typeof(string));
            dt.Columns[ct_Col_CmpltNote].DefaultValue = defValuestring;
            // 印刷用品番
            dt.Columns.Add(ct_Col_PrtGoodsNo, typeof(string));
            dt.Columns[ct_Col_PrtGoodsNo].DefaultValue = defValuestring;
            // 印刷用メーカーコード
            dt.Columns.Add(ct_Col_PrtMakerCode, typeof(Int32));
            dt.Columns[ct_Col_PrtMakerCode].DefaultValue = defValueInt32;
            // 印刷用メーカー名称
            dt.Columns.Add(ct_Col_PrtMakerName, typeof(string));
            dt.Columns[ct_Col_PrtMakerName].DefaultValue = defValuestring;
            // 出荷差分数
            dt.Columns.Add(ct_Col_ShipmCntDifference, typeof(Double));
            dt.Columns[ct_Col_ShipmCntDifference].DefaultValue = defValueDouble;
            // 明細関連付けGUID
            dt.Columns.Add(ct_Col_DtlRelationGuid, typeof(Guid));
            dt.Columns[ct_Col_DtlRelationGuid].DefaultValue = Guid.Empty;

            // 売上伝票番号（仮）
            dt.Columns.Add(ct_Col_TempSalesSlipNum, typeof(string));
            dt.Columns[ct_Col_TempSalesSlipNum].DefaultValue = defValuestring;
            // 売上明細通番（仮）
            dt.Columns.Add(ct_Col_TempSalesSlipDtlNum, typeof(Int64));
            dt.Columns[ct_Col_TempSalesSlipDtlNum].DefaultValue = defValueInt64;

            // (印刷用) BO区分
            dt.Columns.Add(ct_Col_PrtReceiveTime, typeof(Int32));
            dt.Columns[ct_Col_PrtReceiveTime].DefaultValue = defValueInt32;
            // (印刷用) BO区分
            dt.Columns.Add(ct_Col_PrtBoCode, typeof(string));
            dt.Columns[ct_Col_PrtBoCode].DefaultValue = defValuestring;
            // (印刷用)納品区分
            dt.Columns.Add(ct_Col_PrtUOEDeliGoodsDiv, typeof(string));
            dt.Columns[ct_Col_PrtUOEDeliGoodsDiv].DefaultValue = defValuestring;
            // (印刷用)納品区分名称
            dt.Columns.Add(ct_Col_PrtDeliveredGoodsDivNm, typeof(string));
            dt.Columns[ct_Col_PrtDeliveredGoodsDivNm].DefaultValue = defValuestring;
            // (印刷用)フォロー納品区分
            dt.Columns.Add(ct_Col_PrtFollowDeliGoodsDiv, typeof(string));
            dt.Columns[ct_Col_PrtFollowDeliGoodsDiv].DefaultValue = defValuestring;
            // (印刷用)フォロー納品区分名称
            dt.Columns.Add(ct_Col_PrtFollowDeliGoodsDivNm, typeof(string));
            dt.Columns[ct_Col_PrtFollowDeliGoodsDivNm].DefaultValue = defValuestring;
            //(印刷用)受注数
            dt.Columns.Add(ct_Col_PrtAcceptAnOrderCnt, typeof(Double));
            dt.Columns[ct_Col_PrtAcceptAnOrderCnt].DefaultValue = defValueDouble;
            //(印刷用)出庫数
            dt.Columns.Add(ct_Col_PrtShipmentCnt, typeof(Int32));
            dt.Columns[ct_Col_PrtShipmentCnt].DefaultValue = defValueInt32;
            //(印刷用)拠点出庫数
            dt.Columns.Add(ct_Col_PrtUOESectOutGoodsCnt, typeof(Int32));
            dt.Columns[ct_Col_PrtUOESectOutGoodsCnt].DefaultValue = defValueInt32;
            //(印刷用)BO出庫数
            dt.Columns.Add(ct_Col_PrtBOShipmentCnt, typeof(Int32));
            dt.Columns[ct_Col_PrtBOShipmentCnt].DefaultValue = defValueInt32;
            //明細種別
            dt.Columns.Add(ct_Col_DetailCd, typeof(Int32));
            dt.Columns[ct_Col_DetailCd].DefaultValue = defValueInt32;

            // 2011/01/19 Add >>>
            //キャンペーンコード
            dt.Columns.Add(ct_Col_CampaignCode, typeof(Int32));
            dt.Columns[ct_Col_CampaignCode].DefaultValue = defValueInt32;
            //キャンペーン名称
            dt.Columns.Add(ct_Col_CampaignName, typeof(string));
            dt.Columns[ct_Col_CampaignName].DefaultValue = defValuestring;
            //商品種別
            dt.Columns.Add(ct_Col_GoodsDivCd, typeof(Int32));
            dt.Columns[ct_Col_GoodsDivCd].DefaultValue = defValueInt32;
            //回答納期
            dt.Columns.Add(ct_Col_AnswerDelivDate, typeof(string));
            dt.Columns[ct_Col_AnswerDelivDate].DefaultValue = defValuestring;
            //リサイクル区分
            dt.Columns.Add(ct_Col_RecycleDiv, typeof(Int32));
            dt.Columns[ct_Col_RecycleDiv].DefaultValue = defValueInt32;
            //リサイクル区分名称
            dt.Columns.Add(ct_Col_RecycleDivNm, typeof(string));
            dt.Columns[ct_Col_RecycleDivNm].DefaultValue = defValuestring;
            //受注方法
            dt.Columns.Add(ct_Col_WayToAcptOdr, typeof(Int32));
            dt.Columns[ct_Col_WayToAcptOdr].DefaultValue = defValueInt32;
            // 2011/01/19 Add <<<
            // 2011/07/28 Add >>>
            //自動回答区分
            dt.Columns.Add(ct_Col_AutoAnswerDivSCM, typeof(Int32));
            dt.Columns[ct_Col_AutoAnswerDivSCM].DefaultValue = defValueInt32;
            // 2011/07/28 Add <<<
            // 2012/01/16 Add >>>
            //特記事項
            dt.Columns.Add(ct_Col_GoodsSpecialNote, typeof(string));
            dt.Columns[ct_Col_GoodsSpecialNote].DefaultValue = defValuestring;
            // 2012/01/16 Add <<<

            // ADD 2012/12/06 2012/12/12配信予定 SCM障害№10447対応 ----------------------------------->>>>>
            dt.Columns.Add(ct_Col_AcceptOrOrderKind, typeof(short));
            dt.Columns[ct_Col_AcceptOrOrderKind].DefaultValue = defValueShort;
            // ADD 2012/12/06 2012/12/12配信予定 SCM障害№10447対応 -----------------------------------<<<<<

            //PrimaryKeyの設定
            //売上明細テーブル
            //受注ステータス＋明細関連付けGUID
            if (dataTableName == CT_SalesDetailDataTable)
            {
                dt.PrimaryKey = new DataColumn[] { dt.Columns[ct_Col_AcptAnOdrStatus], dt.Columns[ct_Col_DtlRelationGuid] };
            }
            //受注明細テーブル
            //受注ステータス＋売上明細通番
            else
            {
                dt.PrimaryKey = new DataColumn[] { dt.Columns[ct_Col_AcptAnOdrStatus], dt.Columns[ct_Col_SalesSlipDtlNum] };
            }

        }
        #endregion
    }
}