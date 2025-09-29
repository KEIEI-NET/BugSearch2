using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   AddUpOrgSalesDetailWork
    /// <summary>
    /// 計上元売上明細データワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   計上元売上明細データワークヘッダファイル</br>
    /// <br>Programmer       :   手動生成</br>
    /// <br>Date             :   2007/11/20</br>
    /// <br>Genarated Date   :   2007/11/20  (CSharp File Generated Date)</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class AddUpOrgSalesDetailWork : SalesDetailWork
    {
        // SalesDetailWork を継承して作成しているので、売上明細データレイアウトに変更が
        // 有った場合でも StockDetailWork だけ修正すれば良い
    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>AddUpOrgSalesDetailWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   AddUpOrgSalesDetailWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class AddUpOrgSalesDetailWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   AddUpOrgSalesDetailWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  AddUpOrgSalesDetailWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is AddUpOrgSalesDetailWork || graph is ArrayList || graph is AddUpOrgSalesDetailWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(AddUpOrgSalesDetailWork).FullName));

            if (graph != null && graph is AddUpOrgSalesDetailWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.AddUpOrgSalesDetailWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is AddUpOrgSalesDetailWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((AddUpOrgSalesDetailWork[])graph).Length;
            }
            else if (graph is AddUpOrgSalesDetailWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //作成日時
            serInfo.MemberInfo.Add(typeof(Int64)); //CreateDateTime
            //更新日時
            serInfo.MemberInfo.Add(typeof(Int64)); //UpdateDateTime
            //企業コード
            serInfo.MemberInfo.Add(typeof(string)); //EnterpriseCode
            //GUID
            serInfo.MemberInfo.Add(typeof(byte[]));  //FileHeaderGuid
            //更新従業員コード
            serInfo.MemberInfo.Add(typeof(string)); //UpdEmployeeCode
            //更新アセンブリID1
            serInfo.MemberInfo.Add(typeof(string)); //UpdAssemblyId1
            //更新アセンブリID2
            serInfo.MemberInfo.Add(typeof(string)); //UpdAssemblyId2
            //論理削除区分
            serInfo.MemberInfo.Add(typeof(Int32)); //LogicalDeleteCode
            //受注番号
            serInfo.MemberInfo.Add(typeof(Int32)); //AcceptAnOrderNo
            //受注ステータス
            serInfo.MemberInfo.Add(typeof(Int32)); //AcptAnOdrStatus
            //売上伝票番号
            serInfo.MemberInfo.Add(typeof(string)); //SalesSlipNum
            //売上行番号
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesRowNo
            //売上行番号枝番
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesRowDerivNo
            //拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //SectionCode
            //部門コード
            serInfo.MemberInfo.Add(typeof(Int32)); //SubSectionCode
            //売上日付
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesDate
            //共通通番
            serInfo.MemberInfo.Add(typeof(Int64)); //CommonSeqNo
            //売上明細通番
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesSlipDtlNum
            //受注ステータス（元）
            serInfo.MemberInfo.Add(typeof(Int32)); //AcptAnOdrStatusSrc
            //売上明細通番（元）
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesSlipDtlNumSrc
            //仕入形式（同時）
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierFormalSync
            //仕入明細通番（同時）
            serInfo.MemberInfo.Add(typeof(Int64)); //StockSlipDtlNumSync
            //売上伝票区分（明細）
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesSlipCdDtl
            //納品完了予定日
            serInfo.MemberInfo.Add(typeof(Int32)); //DeliGdsCmpltDueDate
            //商品属性
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsKindCode
            //商品検索区分
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsSearchDivCd
            //商品メーカーコード
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd
            //メーカー名称
            serInfo.MemberInfo.Add(typeof(string)); //MakerName
            //メーカーカナ名称
            serInfo.MemberInfo.Add(typeof(string)); //MakerKanaName
            //商品番号
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNo
            //商品名称
            serInfo.MemberInfo.Add(typeof(string)); //GoodsName
            //商品名称カナ
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNameKana
            //商品大分類コード
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsLGroup
            //商品大分類名称
            serInfo.MemberInfo.Add(typeof(string)); //GoodsLGroupName
            //商品中分類コード
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMGroup
            //商品中分類名称
            serInfo.MemberInfo.Add(typeof(string)); //GoodsMGroupName
            //BLグループコード
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGroupCode
            //BLグループコード名称
            serInfo.MemberInfo.Add(typeof(string)); //BLGroupName
            //BL商品コード
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGoodsCode
            //BL商品コード名称（全角）
            serInfo.MemberInfo.Add(typeof(string)); //BLGoodsFullName
            //自社分類コード
            serInfo.MemberInfo.Add(typeof(Int32)); //EnterpriseGanreCode
            //自社分類名称
            serInfo.MemberInfo.Add(typeof(string)); //EnterpriseGanreName
            //倉庫コード
            serInfo.MemberInfo.Add(typeof(string)); //WarehouseCode
            //倉庫名称
            serInfo.MemberInfo.Add(typeof(string)); //WarehouseName
            //倉庫棚番
            serInfo.MemberInfo.Add(typeof(string)); //WarehouseShelfNo
            //売上在庫取寄せ区分
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesOrderDivCd
            //オープン価格区分
            serInfo.MemberInfo.Add(typeof(Int32)); //OpenPriceDiv
            //商品掛率ランク
            serInfo.MemberInfo.Add(typeof(string)); //GoodsRateRank
            //得意先掛率グループコード
            serInfo.MemberInfo.Add(typeof(Int32)); //CustRateGrpCode
            //定価率
            serInfo.MemberInfo.Add(typeof(Double)); //ListPriceRate
            //掛率設定拠点（定価）
            serInfo.MemberInfo.Add(typeof(string)); //RateSectPriceUnPrc
            //掛率設定区分（定価）
            serInfo.MemberInfo.Add(typeof(string)); //RateDivLPrice
            //単価算出区分（定価）
            serInfo.MemberInfo.Add(typeof(Int32)); //UnPrcCalcCdLPrice
            //価格区分（定価）
            serInfo.MemberInfo.Add(typeof(Int32)); //PriceCdLPrice
            //基準単価（定価）
            serInfo.MemberInfo.Add(typeof(Double)); //StdUnPrcLPrice
            //端数処理単位（定価）
            serInfo.MemberInfo.Add(typeof(Double)); //FracProcUnitLPrice
            //端数処理（定価）
            serInfo.MemberInfo.Add(typeof(Int32)); //FracProcLPrice
            //定価（税込，浮動）
            serInfo.MemberInfo.Add(typeof(Double)); //ListPriceTaxIncFl
            //定価（税抜，浮動）
            serInfo.MemberInfo.Add(typeof(Double)); //ListPriceTaxExcFl
            //定価変更区分
            serInfo.MemberInfo.Add(typeof(Int32)); //ListPriceChngCd
            //売価率
            serInfo.MemberInfo.Add(typeof(Double)); //SalesRate
            //掛率設定拠点（売上単価）
            serInfo.MemberInfo.Add(typeof(string)); //RateSectSalUnPrc
            //掛率設定区分（売上単価）
            serInfo.MemberInfo.Add(typeof(string)); //RateDivSalUnPrc
            //単価算出区分（売上単価）
            serInfo.MemberInfo.Add(typeof(Int32)); //UnPrcCalcCdSalUnPrc
            //価格区分（売上単価）
            serInfo.MemberInfo.Add(typeof(Int32)); //PriceCdSalUnPrc
            //基準単価（売上単価）
            serInfo.MemberInfo.Add(typeof(Double)); //StdUnPrcSalUnPrc
            //端数処理単位（売上単価）
            serInfo.MemberInfo.Add(typeof(Double)); //FracProcUnitSalUnPrc
            //端数処理（売上単価）
            serInfo.MemberInfo.Add(typeof(Int32)); //FracProcSalUnPrc
            //売上単価（税込，浮動）
            serInfo.MemberInfo.Add(typeof(Double)); //SalesUnPrcTaxIncFl
            //売上単価（税抜，浮動）
            serInfo.MemberInfo.Add(typeof(Double)); //SalesUnPrcTaxExcFl
            //売上単価変更区分
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesUnPrcChngCd
            //原価率
            serInfo.MemberInfo.Add(typeof(Double)); //CostRate
            //掛率設定拠点（原価単価）
            serInfo.MemberInfo.Add(typeof(string)); //RateSectCstUnPrc
            //掛率設定区分（原価単価）
            serInfo.MemberInfo.Add(typeof(string)); //RateDivUnCst
            //単価算出区分（原価単価）
            serInfo.MemberInfo.Add(typeof(Int32)); //UnPrcCalcCdUnCst
            //価格区分（原価単価）
            serInfo.MemberInfo.Add(typeof(Int32)); //PriceCdUnCst
            //基準単価（原価単価）
            serInfo.MemberInfo.Add(typeof(Double)); //StdUnPrcUnCst
            //端数処理単位（原価単価）
            serInfo.MemberInfo.Add(typeof(Double)); //FracProcUnitUnCst
            //端数処理（原価単価）
            serInfo.MemberInfo.Add(typeof(Int32)); //FracProcUnCst
            //原価単価
            serInfo.MemberInfo.Add(typeof(Double)); //SalesUnitCost
            //原価単価変更区分
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesUnitCostChngDiv
            //BL商品コード（掛率）
            serInfo.MemberInfo.Add(typeof(Int32)); //RateBLGoodsCode
            //BL商品コード名称（掛率）
            serInfo.MemberInfo.Add(typeof(string)); //RateBLGoodsName
            //商品掛率グループコード（掛率）
            serInfo.MemberInfo.Add(typeof(Int32)); //RateGoodsRateGrpCd
            //商品掛率グループ名称（掛率）
            serInfo.MemberInfo.Add(typeof(string)); //RateGoodsRateGrpNm
            //BLグループコード（掛率）
            serInfo.MemberInfo.Add(typeof(Int32)); //RateBLGroupCode
            //BLグループ名称（掛率）
            serInfo.MemberInfo.Add(typeof(string)); //RateBLGroupName
            //BL商品コード（印刷）
            serInfo.MemberInfo.Add(typeof(Int32)); //PrtBLGoodsCode
            //BL商品コード名称（印刷）
            serInfo.MemberInfo.Add(typeof(string)); //PrtBLGoodsName
            //販売区分コード
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesCode
            //販売区分名称
            serInfo.MemberInfo.Add(typeof(string)); //SalesCdNm
            //作業工数
            serInfo.MemberInfo.Add(typeof(Double)); //WorkManHour
            //出荷数
            serInfo.MemberInfo.Add(typeof(Double)); //ShipmentCnt
            //受注数量
            serInfo.MemberInfo.Add(typeof(Double)); //AcceptAnOrderCnt
            //受注調整数
            serInfo.MemberInfo.Add(typeof(Double)); //AcptAnOdrAdjustCnt
            //受注残数
            serInfo.MemberInfo.Add(typeof(Double)); //AcptAnOdrRemainCnt
            //残数更新日
            serInfo.MemberInfo.Add(typeof(Int32)); //RemainCntUpdDate
            //売上金額（税込み）
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesMoneyTaxInc
            //売上金額（税抜き）
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesMoneyTaxExc
            //原価
            serInfo.MemberInfo.Add(typeof(Int64)); //Cost
            //粗利チェック区分
            serInfo.MemberInfo.Add(typeof(Int32)); //GrsProfitChkDiv
            //売上商品区分
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesGoodsCd
            //売上金額消費税額
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesPriceConsTax
            //課税区分
            serInfo.MemberInfo.Add(typeof(Int32)); //TaxationDivCd
            //相手先伝票番号（明細）
            serInfo.MemberInfo.Add(typeof(string)); //PartySlipNumDtl
            //明細備考
            serInfo.MemberInfo.Add(typeof(string)); //DtlNote
            //仕入先コード
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierCd
            //仕入先略称
            serInfo.MemberInfo.Add(typeof(string)); //SupplierSnm
            //発注番号
            serInfo.MemberInfo.Add(typeof(string)); //OrderNumber
            //注文方法
            serInfo.MemberInfo.Add(typeof(Int32)); //WayToOrder
            //伝票メモ１
            serInfo.MemberInfo.Add(typeof(string)); //SlipMemo1
            //伝票メモ２
            serInfo.MemberInfo.Add(typeof(string)); //SlipMemo2
            //伝票メモ３
            serInfo.MemberInfo.Add(typeof(string)); //SlipMemo3
            //社内メモ１
            serInfo.MemberInfo.Add(typeof(string)); //InsideMemo1
            //社内メモ２
            serInfo.MemberInfo.Add(typeof(string)); //InsideMemo2
            //社内メモ３
            serInfo.MemberInfo.Add(typeof(string)); //InsideMemo3
            //変更前定価
            serInfo.MemberInfo.Add(typeof(Double)); //BfListPrice
            //変更前売価
            serInfo.MemberInfo.Add(typeof(Double)); //BfSalesUnitPrice
            //変更前原価
            serInfo.MemberInfo.Add(typeof(Double)); //BfUnitCost
            //一式明細番号
            serInfo.MemberInfo.Add(typeof(Int32)); //CmpltSalesRowNo
            //メーカーコード（一式）
            serInfo.MemberInfo.Add(typeof(Int32)); //CmpltGoodsMakerCd
            //メーカー名称（一式）
            serInfo.MemberInfo.Add(typeof(string)); //CmpltMakerName
            //メーカーカナ名称（一式）
            serInfo.MemberInfo.Add(typeof(string)); //CmpltMakerKanaName
            //商品名称（一式）
            serInfo.MemberInfo.Add(typeof(string)); //CmpltGoodsName
            //数量（一式）
            serInfo.MemberInfo.Add(typeof(Double)); //CmpltShipmentCnt
            //売上単価（一式）
            serInfo.MemberInfo.Add(typeof(Double)); //CmpltSalesUnPrcFl
            //売上金額（一式）
            serInfo.MemberInfo.Add(typeof(Int64)); //CmpltSalesMoney
            //原価単価（一式）
            serInfo.MemberInfo.Add(typeof(Double)); //CmpltSalesUnitCost
            //原価金額（一式）
            serInfo.MemberInfo.Add(typeof(Int64)); //CmpltCost
            //相手先伝票番号（一式）
            serInfo.MemberInfo.Add(typeof(string)); //CmpltPartySalSlNum
            //一式備考
            serInfo.MemberInfo.Add(typeof(string)); //CmpltNote
            //印刷用品番
            serInfo.MemberInfo.Add(typeof(string)); //PrtGoodsNo
            //印刷用メーカーコード
            serInfo.MemberInfo.Add(typeof(Int32)); //PrtMakerCode
            //印刷用メーカー名称
            serInfo.MemberInfo.Add(typeof(string)); //PrtMakerName
            //キャンペーンコード
            serInfo.MemberInfo.Add(typeof(Int32)); //CampaignCode
            //キャンペーン名称
            serInfo.MemberInfo.Add(typeof(string)); //CampaignName
            //商品種別
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsDivCd
            //回答納期
            serInfo.MemberInfo.Add(typeof(string)); //AnswerDelivDate
            //リサイクル区分
            serInfo.MemberInfo.Add(typeof(Int32)); //RecycleDiv
            //リサイクル区分名称
            serInfo.MemberInfo.Add(typeof(string)); //RecycleDivNm
            //受注方法
            serInfo.MemberInfo.Add(typeof(Int32)); //WayToAcptOdr
            //出荷差分数
            serInfo.MemberInfo.Add(typeof(Double)); //ShipmCntDifference
            //明細関連付けGUID
            serInfo.MemberInfo.Add(typeof(byte[]));  //DtlRelationGuid
            //在庫更新区分(読取専用)
            //serInfo.MemberInfo.Add(typeof(Boolean)); //StockUpdateDiv


            serInfo.Serialize(writer, serInfo);
            if (graph is AddUpOrgSalesDetailWork)
            {
                AddUpOrgSalesDetailWork temp = (AddUpOrgSalesDetailWork)graph;

                SetAddUpOrgSalesDetailWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is AddUpOrgSalesDetailWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((AddUpOrgSalesDetailWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (AddUpOrgSalesDetailWork temp in lst)
                {
                    SetAddUpOrgSalesDetailWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// AddUpOrgSalesDetailWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 143;  // 読取専用プロパティ分を減算

        /// <summary>
        ///  AddUpOrgSalesDetailWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   AddUpOrgSalesDetailWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetAddUpOrgSalesDetailWork(System.IO.BinaryWriter writer, AddUpOrgSalesDetailWork temp)
        {
            //作成日時
            writer.Write((Int64)temp.CreateDateTime.Ticks);
            //更新日時
            writer.Write((Int64)temp.UpdateDateTime.Ticks);
            //企業コード
            writer.Write(temp.EnterpriseCode);
            //GUID
            byte[] fileHeaderGuidArray = temp.FileHeaderGuid.ToByteArray();
            writer.Write(fileHeaderGuidArray.Length);
            writer.Write(temp.FileHeaderGuid.ToByteArray());
            //更新従業員コード
            writer.Write(temp.UpdEmployeeCode);
            //更新アセンブリID1
            writer.Write(temp.UpdAssemblyId1);
            //更新アセンブリID2
            writer.Write(temp.UpdAssemblyId2);
            //論理削除区分
            writer.Write(temp.LogicalDeleteCode);
            //受注番号
            writer.Write(temp.AcceptAnOrderNo);
            //受注ステータス
            writer.Write(temp.AcptAnOdrStatus);
            //売上伝票番号
            writer.Write(temp.SalesSlipNum);
            //売上行番号
            writer.Write(temp.SalesRowNo);
            //売上行番号枝番
            writer.Write(temp.SalesRowDerivNo);
            //拠点コード
            writer.Write(temp.SectionCode);
            //部門コード
            writer.Write(temp.SubSectionCode);
            //売上日付
            writer.Write((Int64)temp.SalesDate.Ticks);
            //共通通番
            writer.Write(temp.CommonSeqNo);
            //売上明細通番
            writer.Write(temp.SalesSlipDtlNum);
            //受注ステータス（元）
            writer.Write(temp.AcptAnOdrStatusSrc);
            //売上明細通番（元）
            writer.Write(temp.SalesSlipDtlNumSrc);
            //仕入形式（同時）
            writer.Write(temp.SupplierFormalSync);
            //仕入明細通番（同時）
            writer.Write(temp.StockSlipDtlNumSync);
            //売上伝票区分（明細）
            writer.Write(temp.SalesSlipCdDtl);
            //納品完了予定日
            writer.Write((Int64)temp.DeliGdsCmpltDueDate.Ticks);
            //商品属性
            writer.Write(temp.GoodsKindCode);
            //商品検索区分
            writer.Write(temp.GoodsSearchDivCd);
            //商品メーカーコード
            writer.Write(temp.GoodsMakerCd);
            //メーカー名称
            writer.Write(temp.MakerName);
            //メーカーカナ名称
            writer.Write(temp.MakerKanaName);
            //商品番号
            writer.Write(temp.GoodsNo);
            //商品名称
            writer.Write(temp.GoodsName);
            //商品名称カナ
            writer.Write(temp.GoodsNameKana);
            //商品大分類コード
            writer.Write(temp.GoodsLGroup);
            //商品大分類名称
            writer.Write(temp.GoodsLGroupName);
            //商品中分類コード
            writer.Write(temp.GoodsMGroup);
            //商品中分類名称
            writer.Write(temp.GoodsMGroupName);
            //BLグループコード
            writer.Write(temp.BLGroupCode);
            //BLグループコード名称
            writer.Write(temp.BLGroupName);
            //BL商品コード
            writer.Write(temp.BLGoodsCode);
            //BL商品コード名称（全角）
            writer.Write(temp.BLGoodsFullName);
            //自社分類コード
            writer.Write(temp.EnterpriseGanreCode);
            //自社分類名称
            writer.Write(temp.EnterpriseGanreName);
            //倉庫コード
            writer.Write(temp.WarehouseCode);
            //倉庫名称
            writer.Write(temp.WarehouseName);
            //倉庫棚番
            writer.Write(temp.WarehouseShelfNo);
            //売上在庫取寄せ区分
            writer.Write(temp.SalesOrderDivCd);
            //オープン価格区分
            writer.Write(temp.OpenPriceDiv);
            //商品掛率ランク
            writer.Write(temp.GoodsRateRank);
            //得意先掛率グループコード
            writer.Write(temp.CustRateGrpCode);
            //定価率
            writer.Write(temp.ListPriceRate);
            //掛率設定拠点（定価）
            writer.Write(temp.RateSectPriceUnPrc);
            //掛率設定区分（定価）
            writer.Write(temp.RateDivLPrice);
            //単価算出区分（定価）
            writer.Write(temp.UnPrcCalcCdLPrice);
            //価格区分（定価）
            writer.Write(temp.PriceCdLPrice);
            //基準単価（定価）
            writer.Write(temp.StdUnPrcLPrice);
            //端数処理単位（定価）
            writer.Write(temp.FracProcUnitLPrice);
            //端数処理（定価）
            writer.Write(temp.FracProcLPrice);
            //定価（税込，浮動）
            writer.Write(temp.ListPriceTaxIncFl);
            //定価（税抜，浮動）
            writer.Write(temp.ListPriceTaxExcFl);
            //定価変更区分
            writer.Write(temp.ListPriceChngCd);
            //売価率
            writer.Write(temp.SalesRate);
            //掛率設定拠点（売上単価）
            writer.Write(temp.RateSectSalUnPrc);
            //掛率設定区分（売上単価）
            writer.Write(temp.RateDivSalUnPrc);
            //単価算出区分（売上単価）
            writer.Write(temp.UnPrcCalcCdSalUnPrc);
            //価格区分（売上単価）
            writer.Write(temp.PriceCdSalUnPrc);
            //基準単価（売上単価）
            writer.Write(temp.StdUnPrcSalUnPrc);
            //端数処理単位（売上単価）
            writer.Write(temp.FracProcUnitSalUnPrc);
            //端数処理（売上単価）
            writer.Write(temp.FracProcSalUnPrc);
            //売上単価（税込，浮動）
            writer.Write(temp.SalesUnPrcTaxIncFl);
            //売上単価（税抜，浮動）
            writer.Write(temp.SalesUnPrcTaxExcFl);
            //売上単価変更区分
            writer.Write(temp.SalesUnPrcChngCd);
            //原価率
            writer.Write(temp.CostRate);
            //掛率設定拠点（原価単価）
            writer.Write(temp.RateSectCstUnPrc);
            //掛率設定区分（原価単価）
            writer.Write(temp.RateDivUnCst);
            //単価算出区分（原価単価）
            writer.Write(temp.UnPrcCalcCdUnCst);
            //価格区分（原価単価）
            writer.Write(temp.PriceCdUnCst);
            //基準単価（原価単価）
            writer.Write(temp.StdUnPrcUnCst);
            //端数処理単位（原価単価）
            writer.Write(temp.FracProcUnitUnCst);
            //端数処理（原価単価）
            writer.Write(temp.FracProcUnCst);
            //原価単価
            writer.Write(temp.SalesUnitCost);
            //原価単価変更区分
            writer.Write(temp.SalesUnitCostChngDiv);
            //BL商品コード（掛率）
            writer.Write(temp.RateBLGoodsCode);
            //BL商品コード名称（掛率）
            writer.Write(temp.RateBLGoodsName);
            //商品掛率グループコード（掛率）
            writer.Write(temp.RateGoodsRateGrpCd);
            //商品掛率グループ名称（掛率）
            writer.Write(temp.RateGoodsRateGrpNm);
            //BLグループコード（掛率）
            writer.Write(temp.RateBLGroupCode);
            //BLグループ名称（掛率）
            writer.Write(temp.RateBLGroupName);
            //BL商品コード（印刷）
            writer.Write(temp.PrtBLGoodsCode);
            //BL商品コード名称（印刷）
            writer.Write(temp.PrtBLGoodsName);
            //販売区分コード
            writer.Write(temp.SalesCode);
            //販売区分名称
            writer.Write(temp.SalesCdNm);
            //作業工数
            writer.Write(temp.WorkManHour);
            //出荷数
            writer.Write(temp.ShipmentCnt);
            //受注数量
            writer.Write(temp.AcceptAnOrderCnt);
            //受注調整数
            writer.Write(temp.AcptAnOdrAdjustCnt);
            //受注残数
            writer.Write(temp.AcptAnOdrRemainCnt);
            //残数更新日
            writer.Write((Int64)temp.RemainCntUpdDate.Ticks);
            //売上金額（税込み）
            writer.Write(temp.SalesMoneyTaxInc);
            //売上金額（税抜き）
            writer.Write(temp.SalesMoneyTaxExc);
            //原価
            writer.Write(temp.Cost);
            //粗利チェック区分
            writer.Write(temp.GrsProfitChkDiv);
            //売上商品区分
            writer.Write(temp.SalesGoodsCd);
            //売上金額消費税額
            writer.Write(temp.SalesPriceConsTax);
            //課税区分
            writer.Write(temp.TaxationDivCd);
            //相手先伝票番号（明細）
            writer.Write(temp.PartySlipNumDtl);
            //明細備考
            writer.Write(temp.DtlNote);
            //仕入先コード
            writer.Write(temp.SupplierCd);
            //仕入先略称
            writer.Write(temp.SupplierSnm);
            //発注番号
            writer.Write(temp.OrderNumber);
            //注文方法
            writer.Write(temp.WayToOrder);
            //伝票メモ１
            writer.Write(temp.SlipMemo1);
            //伝票メモ２
            writer.Write(temp.SlipMemo2);
            //伝票メモ３
            writer.Write(temp.SlipMemo3);
            //社内メモ１
            writer.Write(temp.InsideMemo1);
            //社内メモ２
            writer.Write(temp.InsideMemo2);
            //社内メモ３
            writer.Write(temp.InsideMemo3);
            //変更前定価
            writer.Write(temp.BfListPrice);
            //変更前売価
            writer.Write(temp.BfSalesUnitPrice);
            //変更前原価
            writer.Write(temp.BfUnitCost);
            //一式明細番号
            writer.Write(temp.CmpltSalesRowNo);
            //メーカーコード（一式）
            writer.Write(temp.CmpltGoodsMakerCd);
            //メーカー名称（一式）
            writer.Write(temp.CmpltMakerName);
            //メーカーカナ名称（一式）
            writer.Write(temp.CmpltMakerKanaName);
            //商品名称（一式）
            writer.Write(temp.CmpltGoodsName);
            //数量（一式）
            writer.Write(temp.CmpltShipmentCnt);
            //売上単価（一式）
            writer.Write(temp.CmpltSalesUnPrcFl);
            //売上金額（一式）
            writer.Write(temp.CmpltSalesMoney);
            //原価単価（一式）
            writer.Write(temp.CmpltSalesUnitCost);
            //原価金額（一式）
            writer.Write(temp.CmpltCost);
            //相手先伝票番号（一式）
            writer.Write(temp.CmpltPartySalSlNum);
            //一式備考
            writer.Write(temp.CmpltNote);
            //印刷用品番
            writer.Write(temp.PrtGoodsNo);
            //印刷用メーカーコード
            writer.Write(temp.PrtMakerCode);
            //印刷用メーカー名称
            writer.Write(temp.PrtMakerName);
            //キャンペーンコード
            writer.Write(temp.CampaignCode);
            //キャンペーン名称
            writer.Write(temp.CampaignName);
            //商品種別
            writer.Write(temp.GoodsDivCd);
            //回答納期
            writer.Write(temp.AnswerDelivDate);
            //リサイクル区分
            writer.Write(temp.RecycleDiv);
            //リサイクル区分名称
            writer.Write(temp.RecycleDivNm);
            //受注方法
            writer.Write(temp.WayToAcptOdr);
            //出荷差分数
            writer.Write(temp.ShipmCntDifference);
            //明細関連付けGUID
            byte[] dtlRelationGuidArray = temp.DtlRelationGuid.ToByteArray();
            writer.Write(dtlRelationGuidArray.Length);
            writer.Write(temp.DtlRelationGuid.ToByteArray());
            //在庫更新区分
            //writer.Write(temp.StockUpdateDiv);

        }

        /// <summary>
        ///  AddUpOrgSalesDetailWorkインスタンス取得
        /// </summary>
        /// <returns>AddUpOrgSalesDetailWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   AddUpOrgSalesDetailWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private AddUpOrgSalesDetailWork GetAddUpOrgSalesDetailWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            AddUpOrgSalesDetailWork temp = new AddUpOrgSalesDetailWork();

            //作成日時
            temp.CreateDateTime = new DateTime(reader.ReadInt64());
            //更新日時
            temp.UpdateDateTime = new DateTime(reader.ReadInt64());
            //企業コード
            temp.EnterpriseCode = reader.ReadString();
            //GUID
            int lenOfFileHeaderGuidArray = reader.ReadInt32();
            byte[] fileHeaderGuidArray = reader.ReadBytes(lenOfFileHeaderGuidArray);
            temp.FileHeaderGuid = new Guid(fileHeaderGuidArray);
            //更新従業員コード
            temp.UpdEmployeeCode = reader.ReadString();
            //更新アセンブリID1
            temp.UpdAssemblyId1 = reader.ReadString();
            //更新アセンブリID2
            temp.UpdAssemblyId2 = reader.ReadString();
            //論理削除区分
            temp.LogicalDeleteCode = reader.ReadInt32();
            //受注番号
            temp.AcceptAnOrderNo = reader.ReadInt32();
            //受注ステータス
            temp.AcptAnOdrStatus = reader.ReadInt32();
            //売上伝票番号
            temp.SalesSlipNum = reader.ReadString();
            //売上行番号
            temp.SalesRowNo = reader.ReadInt32();
            //売上行番号枝番
            temp.SalesRowDerivNo = reader.ReadInt32();
            //拠点コード
            temp.SectionCode = reader.ReadString();
            //部門コード
            temp.SubSectionCode = reader.ReadInt32();
            //売上日付
            temp.SalesDate = new DateTime(reader.ReadInt64());
            //共通通番
            temp.CommonSeqNo = reader.ReadInt64();
            //売上明細通番
            temp.SalesSlipDtlNum = reader.ReadInt64();
            //受注ステータス（元）
            temp.AcptAnOdrStatusSrc = reader.ReadInt32();
            //売上明細通番（元）
            temp.SalesSlipDtlNumSrc = reader.ReadInt64();
            //仕入形式（同時）
            temp.SupplierFormalSync = reader.ReadInt32();
            //仕入明細通番（同時）
            temp.StockSlipDtlNumSync = reader.ReadInt64();
            //売上伝票区分（明細）
            temp.SalesSlipCdDtl = reader.ReadInt32();
            //納品完了予定日
            temp.DeliGdsCmpltDueDate = new DateTime(reader.ReadInt64());
            //商品属性
            temp.GoodsKindCode = reader.ReadInt32();
            //商品検索区分
            temp.GoodsSearchDivCd = reader.ReadInt32();
            //商品メーカーコード
            temp.GoodsMakerCd = reader.ReadInt32();
            //メーカー名称
            temp.MakerName = reader.ReadString();
            //メーカーカナ名称
            temp.MakerKanaName = reader.ReadString();
            //商品番号
            temp.GoodsNo = reader.ReadString();
            //商品名称
            temp.GoodsName = reader.ReadString();
            //商品名称カナ
            temp.GoodsNameKana = reader.ReadString();
            //商品大分類コード
            temp.GoodsLGroup = reader.ReadInt32();
            //商品大分類名称
            temp.GoodsLGroupName = reader.ReadString();
            //商品中分類コード
            temp.GoodsMGroup = reader.ReadInt32();
            //商品中分類名称
            temp.GoodsMGroupName = reader.ReadString();
            //BLグループコード
            temp.BLGroupCode = reader.ReadInt32();
            //BLグループコード名称
            temp.BLGroupName = reader.ReadString();
            //BL商品コード
            temp.BLGoodsCode = reader.ReadInt32();
            //BL商品コード名称（全角）
            temp.BLGoodsFullName = reader.ReadString();
            //自社分類コード
            temp.EnterpriseGanreCode = reader.ReadInt32();
            //自社分類名称
            temp.EnterpriseGanreName = reader.ReadString();
            //倉庫コード
            temp.WarehouseCode = reader.ReadString();
            //倉庫名称
            temp.WarehouseName = reader.ReadString();
            //倉庫棚番
            temp.WarehouseShelfNo = reader.ReadString();
            //売上在庫取寄せ区分
            temp.SalesOrderDivCd = reader.ReadInt32();
            //オープン価格区分
            temp.OpenPriceDiv = reader.ReadInt32();
            //商品掛率ランク
            temp.GoodsRateRank = reader.ReadString();
            //得意先掛率グループコード
            temp.CustRateGrpCode = reader.ReadInt32();
            //定価率
            temp.ListPriceRate = reader.ReadDouble();
            //掛率設定拠点（定価）
            temp.RateSectPriceUnPrc = reader.ReadString();
            //掛率設定区分（定価）
            temp.RateDivLPrice = reader.ReadString();
            //単価算出区分（定価）
            temp.UnPrcCalcCdLPrice = reader.ReadInt32();
            //価格区分（定価）
            temp.PriceCdLPrice = reader.ReadInt32();
            //基準単価（定価）
            temp.StdUnPrcLPrice = reader.ReadDouble();
            //端数処理単位（定価）
            temp.FracProcUnitLPrice = reader.ReadDouble();
            //端数処理（定価）
            temp.FracProcLPrice = reader.ReadInt32();
            //定価（税込，浮動）
            temp.ListPriceTaxIncFl = reader.ReadDouble();
            //定価（税抜，浮動）
            temp.ListPriceTaxExcFl = reader.ReadDouble();
            //定価変更区分
            temp.ListPriceChngCd = reader.ReadInt32();
            //売価率
            temp.SalesRate = reader.ReadDouble();
            //掛率設定拠点（売上単価）
            temp.RateSectSalUnPrc = reader.ReadString();
            //掛率設定区分（売上単価）
            temp.RateDivSalUnPrc = reader.ReadString();
            //単価算出区分（売上単価）
            temp.UnPrcCalcCdSalUnPrc = reader.ReadInt32();
            //価格区分（売上単価）
            temp.PriceCdSalUnPrc = reader.ReadInt32();
            //基準単価（売上単価）
            temp.StdUnPrcSalUnPrc = reader.ReadDouble();
            //端数処理単位（売上単価）
            temp.FracProcUnitSalUnPrc = reader.ReadDouble();
            //端数処理（売上単価）
            temp.FracProcSalUnPrc = reader.ReadInt32();
            //売上単価（税込，浮動）
            temp.SalesUnPrcTaxIncFl = reader.ReadDouble();
            //売上単価（税抜，浮動）
            temp.SalesUnPrcTaxExcFl = reader.ReadDouble();
            //売上単価変更区分
            temp.SalesUnPrcChngCd = reader.ReadInt32();
            //原価率
            temp.CostRate = reader.ReadDouble();
            //掛率設定拠点（原価単価）
            temp.RateSectCstUnPrc = reader.ReadString();
            //掛率設定区分（原価単価）
            temp.RateDivUnCst = reader.ReadString();
            //単価算出区分（原価単価）
            temp.UnPrcCalcCdUnCst = reader.ReadInt32();
            //価格区分（原価単価）
            temp.PriceCdUnCst = reader.ReadInt32();
            //基準単価（原価単価）
            temp.StdUnPrcUnCst = reader.ReadDouble();
            //端数処理単位（原価単価）
            temp.FracProcUnitUnCst = reader.ReadDouble();
            //端数処理（原価単価）
            temp.FracProcUnCst = reader.ReadInt32();
            //原価単価
            temp.SalesUnitCost = reader.ReadDouble();
            //原価単価変更区分
            temp.SalesUnitCostChngDiv = reader.ReadInt32();
            //BL商品コード（掛率）
            temp.RateBLGoodsCode = reader.ReadInt32();
            //BL商品コード名称（掛率）
            temp.RateBLGoodsName = reader.ReadString();
            //商品掛率グループコード（掛率）
            temp.RateGoodsRateGrpCd = reader.ReadInt32();
            //商品掛率グループ名称（掛率）
            temp.RateGoodsRateGrpNm = reader.ReadString();
            //BLグループコード（掛率）
            temp.RateBLGroupCode = reader.ReadInt32();
            //BLグループ名称（掛率）
            temp.RateBLGroupName = reader.ReadString();
            //BL商品コード（印刷）
            temp.PrtBLGoodsCode = reader.ReadInt32();
            //BL商品コード名称（印刷）
            temp.PrtBLGoodsName = reader.ReadString();
            //販売区分コード
            temp.SalesCode = reader.ReadInt32();
            //販売区分名称
            temp.SalesCdNm = reader.ReadString();
            //作業工数
            temp.WorkManHour = reader.ReadDouble();
            //出荷数
            temp.ShipmentCnt = reader.ReadDouble();
            //受注数量
            temp.AcceptAnOrderCnt = reader.ReadDouble();
            //受注調整数
            temp.AcptAnOdrAdjustCnt = reader.ReadDouble();
            //受注残数
            temp.AcptAnOdrRemainCnt = reader.ReadDouble();
            //残数更新日
            temp.RemainCntUpdDate = new DateTime(reader.ReadInt64());
            //売上金額（税込み）
            temp.SalesMoneyTaxInc = reader.ReadInt64();
            //売上金額（税抜き）
            temp.SalesMoneyTaxExc = reader.ReadInt64();
            //原価
            temp.Cost = reader.ReadInt64();
            //粗利チェック区分
            temp.GrsProfitChkDiv = reader.ReadInt32();
            //売上商品区分
            temp.SalesGoodsCd = reader.ReadInt32();
            //売上金額消費税額
            temp.SalesPriceConsTax = reader.ReadInt64();
            //課税区分
            temp.TaxationDivCd = reader.ReadInt32();
            //相手先伝票番号（明細）
            temp.PartySlipNumDtl = reader.ReadString();
            //明細備考
            temp.DtlNote = reader.ReadString();
            //仕入先コード
            temp.SupplierCd = reader.ReadInt32();
            //仕入先略称
            temp.SupplierSnm = reader.ReadString();
            //発注番号
            temp.OrderNumber = reader.ReadString();
            //注文方法
            temp.WayToOrder = reader.ReadInt32();
            //伝票メモ１
            temp.SlipMemo1 = reader.ReadString();
            //伝票メモ２
            temp.SlipMemo2 = reader.ReadString();
            //伝票メモ３
            temp.SlipMemo3 = reader.ReadString();
            //社内メモ１
            temp.InsideMemo1 = reader.ReadString();
            //社内メモ２
            temp.InsideMemo2 = reader.ReadString();
            //社内メモ３
            temp.InsideMemo3 = reader.ReadString();
            //変更前定価
            temp.BfListPrice = reader.ReadDouble();
            //変更前売価
            temp.BfSalesUnitPrice = reader.ReadDouble();
            //変更前原価
            temp.BfUnitCost = reader.ReadDouble();
            //一式明細番号
            temp.CmpltSalesRowNo = reader.ReadInt32();
            //メーカーコード（一式）
            temp.CmpltGoodsMakerCd = reader.ReadInt32();
            //メーカー名称（一式）
            temp.CmpltMakerName = reader.ReadString();
            //メーカーカナ名称（一式）
            temp.CmpltMakerKanaName = reader.ReadString();
            //商品名称（一式）
            temp.CmpltGoodsName = reader.ReadString();
            //数量（一式）
            temp.CmpltShipmentCnt = reader.ReadDouble();
            //売上単価（一式）
            temp.CmpltSalesUnPrcFl = reader.ReadDouble();
            //売上金額（一式）
            temp.CmpltSalesMoney = reader.ReadInt64();
            //原価単価（一式）
            temp.CmpltSalesUnitCost = reader.ReadDouble();
            //原価金額（一式）
            temp.CmpltCost = reader.ReadInt64();
            //相手先伝票番号（一式）
            temp.CmpltPartySalSlNum = reader.ReadString();
            //一式備考
            temp.CmpltNote = reader.ReadString();
            //印刷用品番
            temp.PrtGoodsNo = reader.ReadString();
            //印刷用メーカーコード
            temp.PrtMakerCode = reader.ReadInt32();
            //印刷用メーカー名称
            temp.PrtMakerName = reader.ReadString();
            //キャンペーンコード
            temp.CampaignCode = reader.ReadInt32();
            //キャンペーン名称
            temp.CampaignName = reader.ReadString();
            //商品種別
            temp.GoodsDivCd = reader.ReadInt32();
            //回答納期
            temp.AnswerDelivDate = reader.ReadString();
            //リサイクル区分
            temp.RecycleDiv = reader.ReadInt32();
            //リサイクル区分名称
            temp.RecycleDivNm = reader.ReadString();
            //受注方法
            temp.WayToAcptOdr = reader.ReadInt32();
            //出荷差分数
            temp.ShipmCntDifference = reader.ReadDouble();
            //明細関連付けGUID
            int lenOfDtlRelationGuidArray = reader.ReadInt32();
            byte[] dtlRelationGuidArray = reader.ReadBytes(lenOfDtlRelationGuidArray);
            temp.DtlRelationGuid = new Guid(dtlRelationGuidArray);
            //在庫更新区分


            //以下は読み飛ばしです。このバージョンが想定する EmployeeWork型以降のバージョンの
            //データをデシリアライズする場合、シリアライズしたフォーマッタが記述した
            //型情報にしたがって、ストリームから情報を読み出します...といっても
            //読み出して捨てることになります。
            for (int k = currentMemberCount; k < serInfo.MemberInfo.Count; ++k)
            {
                //byte[],char[]をデシリアライズする直前に、そのlengthが
                //デシリアライズされているケースがある、byte[],char[]の
                //デシリアライズにはlengthが必要なのでint型のデータをデ
                //シリアライズした場合は、この値をこの変数に退避します。
                int optCount = 0;
                object oMemberType = serInfo.MemberInfo[k];
                if (oMemberType is Type)
                {
                    Type t = (Type)oMemberType;
                    object oData = TypeDeserializer.DeserializePrimitiveType(reader, t, optCount);
                    if (t.Equals(typeof(int)))
                    {
                        optCount = Convert.ToInt32(oData);
                    }
                    else
                    {
                        optCount = 0;
                    }
                }
                else if (oMemberType is string)
                {
                    Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate formatter = CustomFormatterServices.GetSurrogate((string)oMemberType);
                    object userData = formatter.Deserialize(reader);  //読み飛ばし
                }
            }
            return temp;
        }

        /// <summary>
        ///  Ver5.10.1.0用のカスタムデシリアライザです
        /// </summary>
        /// <returns>AddUpOrgSalesDetailWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   AddUpOrgSalesDetailWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                AddUpOrgSalesDetailWork temp = GetAddUpOrgSalesDetailWork(reader, serInfo);
                lst.Add(temp);
            }
            switch (serInfo.RetTypeInfo)
            {
                case 0:
                    retValue = lst;
                    break;
                case 1:
                    retValue = lst[0];
                    break;
                case 2:
                    retValue = (AddUpOrgSalesDetailWork[])lst.ToArray(typeof(AddUpOrgSalesDetailWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}
