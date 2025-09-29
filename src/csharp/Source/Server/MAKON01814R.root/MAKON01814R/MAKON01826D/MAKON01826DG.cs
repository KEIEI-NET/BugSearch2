using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   AddUpOrgStockDetailWork
    /// <summary>
    /// 計上元仕入明細データワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   計上元仕入明細データワークヘッダファイル</br>
    /// <br>Programmer       :   手動生成</br>
    /// <br>Date             :   2007/10/18</br>
    /// <br>Genarated Date   :   2007/10/18  (CSharp File Generated Date)</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class AddUpOrgStockDetailWork : StockDetailWork
    {
        // StockDetailWork を継承して作成しているので、仕入明細データレイアウトに変更が
        // 有った場合でも StockDetailWork だけ修正すれば良い
    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>AddUppOrgStockDetailWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   AddUppOrgStockDetailWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class AddUpOrgStockDetailWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   AddUpOrgStockDetailWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  StockDetailWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is AddUpOrgStockDetailWork || graph is ArrayList || graph is AddUpOrgStockDetailWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(AddUpOrgStockDetailWork).FullName));

            if (graph != null && graph is AddUpOrgStockDetailWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.AddUpOrgStockDetailWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is AddUpOrgStockDetailWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((AddUpOrgStockDetailWork[])graph).Length;
            }
            else if (graph is AddUpOrgStockDetailWork)
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
            //仕入形式
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierFormal
            //仕入伝票番号
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierSlipNo
            //仕入行番号
            serInfo.MemberInfo.Add(typeof(Int32)); //StockRowNo
            //拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //SectionCode
            //部門コード
            serInfo.MemberInfo.Add(typeof(Int32)); //SubSectionCode
            //共通通番
            serInfo.MemberInfo.Add(typeof(Int64)); //CommonSeqNo
            //仕入明細通番
            serInfo.MemberInfo.Add(typeof(Int64)); //StockSlipDtlNum
            //仕入形式（元）
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierFormalSrc
            //仕入明細通番（元）
            serInfo.MemberInfo.Add(typeof(Int64)); //StockSlipDtlNumSrc
            //受注ステータス（同時）
            serInfo.MemberInfo.Add(typeof(Int32)); //AcptAnOdrStatusSync
            //売上明細通番（同時）
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesSlipDtlNumSync
            //仕入伝票区分（明細）
            serInfo.MemberInfo.Add(typeof(Int32)); //StockSlipCdDtl
            //仕入入力者コード
            serInfo.MemberInfo.Add(typeof(string)); //StockInputCode
            //仕入入力者名称
            serInfo.MemberInfo.Add(typeof(string)); //StockInputName
            //仕入担当者コード
            serInfo.MemberInfo.Add(typeof(string)); //StockAgentCode
            //仕入担当者名称
            serInfo.MemberInfo.Add(typeof(string)); //StockAgentName
            //商品属性
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsKindCode
            //商品メーカーコード
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd
            //メーカー名称
            serInfo.MemberInfo.Add(typeof(string)); //MakerName
            //メーカーカナ名称
            serInfo.MemberInfo.Add(typeof(string)); //MakerKanaName
            //メーカーカナ名称（一式）
            serInfo.MemberInfo.Add(typeof(string)); //CmpltMakerKanaName
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
            //仕入在庫取寄せ区分
            serInfo.MemberInfo.Add(typeof(Int32)); //StockOrderDivCd
            //オープン価格区分
            serInfo.MemberInfo.Add(typeof(Int32)); //OpenPriceDiv
            //商品掛率ランク
            serInfo.MemberInfo.Add(typeof(string)); //GoodsRateRank
            //得意先掛率グループコード
            serInfo.MemberInfo.Add(typeof(Int32)); //CustRateGrpCode
            //仕入先掛率グループコード
            serInfo.MemberInfo.Add(typeof(Int32)); //SuppRateGrpCode
            //定価（税抜，浮動）
            serInfo.MemberInfo.Add(typeof(Double)); //ListPriceTaxExcFl
            //定価（税込，浮動）
            serInfo.MemberInfo.Add(typeof(Double)); //ListPriceTaxIncFl
            //仕入率
            serInfo.MemberInfo.Add(typeof(Double)); //StockRate
            //掛率設定拠点（仕入単価）
            serInfo.MemberInfo.Add(typeof(string)); //RateSectStckUnPrc
            //掛率設定区分（仕入単価）
            serInfo.MemberInfo.Add(typeof(string)); //RateDivStckUnPrc
            //単価算出区分（仕入単価）
            serInfo.MemberInfo.Add(typeof(Int32)); //UnPrcCalcCdStckUnPrc
            //価格区分（仕入単価）
            serInfo.MemberInfo.Add(typeof(Int32)); //PriceCdStckUnPrc
            //基準単価（仕入単価）
            serInfo.MemberInfo.Add(typeof(Double)); //StdUnPrcStckUnPrc
            //端数処理単位（仕入単価）
            serInfo.MemberInfo.Add(typeof(Double)); //FracProcUnitStcUnPrc
            //端数処理（仕入単価）
            serInfo.MemberInfo.Add(typeof(Int32)); //FracProcStckUnPrc
            //仕入単価（税抜，浮動）
            serInfo.MemberInfo.Add(typeof(Double)); //StockUnitPriceFl
            //仕入単価（税込，浮動）
            serInfo.MemberInfo.Add(typeof(Double)); //StockUnitTaxPriceFl
            //仕入単価変更区分
            serInfo.MemberInfo.Add(typeof(Int32)); //StockUnitChngDiv
            //変更前仕入単価（浮動）
            serInfo.MemberInfo.Add(typeof(Double)); //BfStockUnitPriceFl
            //変更前定価
            serInfo.MemberInfo.Add(typeof(Double)); //BfListPrice
            //BL商品コード（掛率）
            serInfo.MemberInfo.Add(typeof(Int32)); //RateBLGoodsCode
            //BL商品コード名称（掛率）
            serInfo.MemberInfo.Add(typeof(string)); //RateBLGoodsName
            //仕入数
            serInfo.MemberInfo.Add(typeof(Double)); //StockCount
            //発注数量
            serInfo.MemberInfo.Add(typeof(Double)); //OrderCnt
            //発注調整数
            serInfo.MemberInfo.Add(typeof(Double)); //OrderAdjustCnt
            //発注残数
            serInfo.MemberInfo.Add(typeof(Double)); //OrderRemainCnt
            //残数更新日
            serInfo.MemberInfo.Add(typeof(Int32)); //RemainCntUpdDate
            //仕入金額（税抜き）
            serInfo.MemberInfo.Add(typeof(Int64)); //StockPriceTaxExc
            //仕入金額（税込み）
            serInfo.MemberInfo.Add(typeof(Int64)); //StockPriceTaxInc
            //仕入商品区分
            serInfo.MemberInfo.Add(typeof(Int32)); //StockGoodsCd
            //仕入金額消費税額
            serInfo.MemberInfo.Add(typeof(Int64)); //StockPriceConsTax
            //課税区分
            serInfo.MemberInfo.Add(typeof(Int32)); //TaxationCode
            //仕入伝票明細備考1
            serInfo.MemberInfo.Add(typeof(string)); //StockDtiSlipNote1
            //販売先コード
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesCustomerCode
            //販売先略称
            serInfo.MemberInfo.Add(typeof(string)); //SalesCustomerSnm
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
            //仕入先コード
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierCd
            //仕入先略称
            serInfo.MemberInfo.Add(typeof(string)); //SupplierSnm
            //納品先コード
            serInfo.MemberInfo.Add(typeof(Int32)); //AddresseeCode
            //納品先名称
            serInfo.MemberInfo.Add(typeof(string)); //AddresseeName
            //直送区分
            serInfo.MemberInfo.Add(typeof(Int32)); //DirectSendingCd
            //発注番号
            serInfo.MemberInfo.Add(typeof(string)); //OrderNumber
            //注文方法
            serInfo.MemberInfo.Add(typeof(Int32)); //WayToOrder
            //納品完了予定日
            serInfo.MemberInfo.Add(typeof(Int32)); //DeliGdsCmpltDueDate
            //希望納期
            serInfo.MemberInfo.Add(typeof(Int32)); //ExpectDeliveryDate
            //発注データ作成区分
            serInfo.MemberInfo.Add(typeof(Int32)); //OrderDataCreateDiv
            //発注データ作成日
            serInfo.MemberInfo.Add(typeof(Int32)); //OrderDataCreateDate
            //発注書発行済区分
            serInfo.MemberInfo.Add(typeof(Int32)); //OrderFormIssuedDiv
            //仕入差分数
            serInfo.MemberInfo.Add(typeof(Double)); //StockCountDifference
            //明細関連付けGUID
            serInfo.MemberInfo.Add(typeof(byte[]));  //DtlRelationGuid

            serInfo.Serialize(writer, serInfo);
            if (graph is AddUpOrgStockDetailWork)
            {
                AddUpOrgStockDetailWork temp = (AddUpOrgStockDetailWork)graph;

                SetStockDetailWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is AddUpOrgStockDetailWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((AddUpOrgStockDetailWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (AddUpOrgStockDetailWork temp in lst)
                {
                    SetStockDetailWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// AddUpOrgStockDetailWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 101;

        /// <summary>
        ///  AddUpOrgStockDetailWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   AddUpOrgStockDetailWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetStockDetailWork(System.IO.BinaryWriter writer, AddUpOrgStockDetailWork temp)
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
            //仕入形式
            writer.Write(temp.SupplierFormal);
            //仕入伝票番号
            writer.Write(temp.SupplierSlipNo);
            //仕入行番号
            writer.Write(temp.StockRowNo);
            //拠点コード
            writer.Write(temp.SectionCode);
            //部門コード
            writer.Write(temp.SubSectionCode);
            //共通通番
            writer.Write(temp.CommonSeqNo);
            //仕入明細通番
            writer.Write(temp.StockSlipDtlNum);
            //仕入形式（元）
            writer.Write(temp.SupplierFormalSrc);
            //仕入明細通番（元）
            writer.Write(temp.StockSlipDtlNumSrc);
            //受注ステータス（同時）
            writer.Write(temp.AcptAnOdrStatusSync);
            //売上明細通番（同時）
            writer.Write(temp.SalesSlipDtlNumSync);
            //仕入伝票区分（明細）
            writer.Write(temp.StockSlipCdDtl);
            //仕入入力者コード
            writer.Write(temp.StockInputCode);
            //仕入入力者名称
            writer.Write(temp.StockInputName);
            //仕入担当者コード
            writer.Write(temp.StockAgentCode);
            //仕入担当者名称
            writer.Write(temp.StockAgentName);
            //商品属性
            writer.Write(temp.GoodsKindCode);
            //商品メーカーコード
            writer.Write(temp.GoodsMakerCd);
            //メーカー名称
            writer.Write(temp.MakerName);
            //メーカーカナ名称
            writer.Write(temp.MakerKanaName);
            //メーカーカナ名称（一式）
            writer.Write(temp.CmpltMakerKanaName);
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
            //仕入在庫取寄せ区分
            writer.Write(temp.StockOrderDivCd);
            //オープン価格区分
            writer.Write(temp.OpenPriceDiv);
            //商品掛率ランク
            writer.Write(temp.GoodsRateRank);
            //得意先掛率グループコード
            writer.Write(temp.CustRateGrpCode);
            //仕入先掛率グループコード
            writer.Write(temp.SuppRateGrpCode);
            //定価（税抜，浮動）
            writer.Write(temp.ListPriceTaxExcFl);
            //定価（税込，浮動）
            writer.Write(temp.ListPriceTaxIncFl);
            //仕入率
            writer.Write(temp.StockRate);
            //掛率設定拠点（仕入単価）
            writer.Write(temp.RateSectStckUnPrc);
            //掛率設定区分（仕入単価）
            writer.Write(temp.RateDivStckUnPrc);
            //単価算出区分（仕入単価）
            writer.Write(temp.UnPrcCalcCdStckUnPrc);
            //価格区分（仕入単価）
            writer.Write(temp.PriceCdStckUnPrc);
            //基準単価（仕入単価）
            writer.Write(temp.StdUnPrcStckUnPrc);
            //端数処理単位（仕入単価）
            writer.Write(temp.FracProcUnitStcUnPrc);
            //端数処理（仕入単価）
            writer.Write(temp.FracProcStckUnPrc);
            //仕入単価（税抜，浮動）
            writer.Write(temp.StockUnitPriceFl);
            //仕入単価（税込，浮動）
            writer.Write(temp.StockUnitTaxPriceFl);
            //仕入単価変更区分
            writer.Write(temp.StockUnitChngDiv);
            //変更前仕入単価（浮動）
            writer.Write(temp.BfStockUnitPriceFl);
            //変更前定価
            writer.Write(temp.BfListPrice);
            //BL商品コード（掛率）
            writer.Write(temp.RateBLGoodsCode);
            //BL商品コード名称（掛率）
            writer.Write(temp.RateBLGoodsName);
            //仕入数
            writer.Write(temp.StockCount);
            //発注数量
            writer.Write(temp.OrderCnt);
            //発注調整数
            writer.Write(temp.OrderAdjustCnt);
            //発注残数
            writer.Write(temp.OrderRemainCnt);
            //残数更新日
            writer.Write((Int64)temp.RemainCntUpdDate.Ticks);
            //仕入金額（税抜き）
            writer.Write(temp.StockPriceTaxExc);
            //仕入金額（税込み）
            writer.Write(temp.StockPriceTaxInc);
            //仕入商品区分
            writer.Write(temp.StockGoodsCd);
            //仕入金額消費税額
            writer.Write(temp.StockPriceConsTax);
            //課税区分
            writer.Write(temp.TaxationCode);
            //仕入伝票明細備考1
            writer.Write(temp.StockDtiSlipNote1);
            //販売先コード
            writer.Write(temp.SalesCustomerCode);
            //販売先略称
            writer.Write(temp.SalesCustomerSnm);
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
            //仕入先コード
            writer.Write(temp.SupplierCd);
            //仕入先略称
            writer.Write(temp.SupplierSnm);
            //納品先コード
            writer.Write(temp.AddresseeCode);
            //納品先名称
            writer.Write(temp.AddresseeName);
            //直送区分
            writer.Write(temp.DirectSendingCd);
            //発注番号
            writer.Write(temp.OrderNumber);
            //注文方法
            writer.Write(temp.WayToOrder);
            //納品完了予定日
            writer.Write((Int64)temp.DeliGdsCmpltDueDate.Ticks);
            //希望納期
            writer.Write((Int64)temp.ExpectDeliveryDate.Ticks);
            //発注データ作成区分
            writer.Write(temp.OrderDataCreateDiv);
            //発注データ作成日
            writer.Write((Int64)temp.OrderDataCreateDate.Ticks);
            //発注書発行済区分
            writer.Write(temp.OrderFormIssuedDiv);
            //仕入差分数
            writer.Write(temp.StockCountDifference);
            //明細関連付けGUID
            byte[] dtlRelationGuidArray = temp.DtlRelationGuid.ToByteArray();
            writer.Write(dtlRelationGuidArray.Length);
            writer.Write(temp.DtlRelationGuid.ToByteArray());
        }

        /// <summary>
        ///  AddUpOrgStockDetailWorkインスタンス取得
        /// </summary>
        /// <returns>AddUpOrgStockDetailWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   AddUpOrgStockDetailWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private AddUpOrgStockDetailWork GetStockDetailWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            AddUpOrgStockDetailWork temp = new AddUpOrgStockDetailWork();

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
            //仕入形式
            temp.SupplierFormal = reader.ReadInt32();
            //仕入伝票番号
            temp.SupplierSlipNo = reader.ReadInt32();
            //仕入行番号
            temp.StockRowNo = reader.ReadInt32();
            //拠点コード
            temp.SectionCode = reader.ReadString();
            //部門コード
            temp.SubSectionCode = reader.ReadInt32();
            //共通通番
            temp.CommonSeqNo = reader.ReadInt64();
            //仕入明細通番
            temp.StockSlipDtlNum = reader.ReadInt64();
            //仕入形式（元）
            temp.SupplierFormalSrc = reader.ReadInt32();
            //仕入明細通番（元）
            temp.StockSlipDtlNumSrc = reader.ReadInt64();
            //受注ステータス（同時）
            temp.AcptAnOdrStatusSync = reader.ReadInt32();
            //売上明細通番（同時）
            temp.SalesSlipDtlNumSync = reader.ReadInt64();
            //仕入伝票区分（明細）
            temp.StockSlipCdDtl = reader.ReadInt32();
            //仕入入力者コード
            temp.StockInputCode = reader.ReadString();
            //仕入入力者名称
            temp.StockInputName = reader.ReadString();
            //仕入担当者コード
            temp.StockAgentCode = reader.ReadString();
            //仕入担当者名称
            temp.StockAgentName = reader.ReadString();
            //商品属性
            temp.GoodsKindCode = reader.ReadInt32();
            //商品メーカーコード
            temp.GoodsMakerCd = reader.ReadInt32();
            //メーカー名称
            temp.MakerName = reader.ReadString();
            //メーカーカナ名称
            temp.MakerKanaName = reader.ReadString();
            //メーカーカナ名称（一式）
            temp.CmpltMakerKanaName = reader.ReadString();
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
            //仕入在庫取寄せ区分
            temp.StockOrderDivCd = reader.ReadInt32();
            //オープン価格区分
            temp.OpenPriceDiv = reader.ReadInt32();
            //商品掛率ランク
            temp.GoodsRateRank = reader.ReadString();
            //得意先掛率グループコード
            temp.CustRateGrpCode = reader.ReadInt32();
            //仕入先掛率グループコード
            temp.SuppRateGrpCode = reader.ReadInt32();
            //定価（税抜，浮動）
            temp.ListPriceTaxExcFl = reader.ReadDouble();
            //定価（税込，浮動）
            temp.ListPriceTaxIncFl = reader.ReadDouble();
            //仕入率
            temp.StockRate = reader.ReadDouble();
            //掛率設定拠点（仕入単価）
            temp.RateSectStckUnPrc = reader.ReadString();
            //掛率設定区分（仕入単価）
            temp.RateDivStckUnPrc = reader.ReadString();
            //単価算出区分（仕入単価）
            temp.UnPrcCalcCdStckUnPrc = reader.ReadInt32();
            //価格区分（仕入単価）
            temp.PriceCdStckUnPrc = reader.ReadInt32();
            //基準単価（仕入単価）
            temp.StdUnPrcStckUnPrc = reader.ReadDouble();
            //端数処理単位（仕入単価）
            temp.FracProcUnitStcUnPrc = reader.ReadDouble();
            //端数処理（仕入単価）
            temp.FracProcStckUnPrc = reader.ReadInt32();
            //仕入単価（税抜，浮動）
            temp.StockUnitPriceFl = reader.ReadDouble();
            //仕入単価（税込，浮動）
            temp.StockUnitTaxPriceFl = reader.ReadDouble();
            //仕入単価変更区分
            temp.StockUnitChngDiv = reader.ReadInt32();
            //変更前仕入単価（浮動）
            temp.BfStockUnitPriceFl = reader.ReadDouble();
            //変更前定価
            temp.BfListPrice = reader.ReadDouble();
            //BL商品コード（掛率）
            temp.RateBLGoodsCode = reader.ReadInt32();
            //BL商品コード名称（掛率）
            temp.RateBLGoodsName = reader.ReadString();
            //仕入数
            temp.StockCount = reader.ReadDouble();
            //発注数量
            temp.OrderCnt = reader.ReadDouble();
            //発注調整数
            temp.OrderAdjustCnt = reader.ReadDouble();
            //発注残数
            temp.OrderRemainCnt = reader.ReadDouble();
            //残数更新日
            temp.RemainCntUpdDate = new DateTime(reader.ReadInt64());
            //仕入金額（税抜き）
            temp.StockPriceTaxExc = reader.ReadInt64();
            //仕入金額（税込み）
            temp.StockPriceTaxInc = reader.ReadInt64();
            //仕入商品区分
            temp.StockGoodsCd = reader.ReadInt32();
            //仕入金額消費税額
            temp.StockPriceConsTax = reader.ReadInt64();
            //課税区分
            temp.TaxationCode = reader.ReadInt32();
            //仕入伝票明細備考1
            temp.StockDtiSlipNote1 = reader.ReadString();
            //販売先コード
            temp.SalesCustomerCode = reader.ReadInt32();
            //販売先略称
            temp.SalesCustomerSnm = reader.ReadString();
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
            //仕入先コード
            temp.SupplierCd = reader.ReadInt32();
            //仕入先略称
            temp.SupplierSnm = reader.ReadString();
            //納品先コード
            temp.AddresseeCode = reader.ReadInt32();
            //納品先名称
            temp.AddresseeName = reader.ReadString();
            //直送区分
            temp.DirectSendingCd = reader.ReadInt32();
            //発注番号
            temp.OrderNumber = reader.ReadString();
            //注文方法
            temp.WayToOrder = reader.ReadInt32();
            //納品完了予定日
            temp.DeliGdsCmpltDueDate = new DateTime(reader.ReadInt64());
            //希望納期
            temp.ExpectDeliveryDate = new DateTime(reader.ReadInt64());
            //発注データ作成区分
            temp.OrderDataCreateDiv = reader.ReadInt32();
            //発注データ作成日
            temp.OrderDataCreateDate = new DateTime(reader.ReadInt64());
            //発注書発行済区分
            temp.OrderFormIssuedDiv = reader.ReadInt32();
            //仕入差分数
            temp.StockCountDifference = reader.ReadDouble();
            //明細関連付けGUID
            int lenOfDtlRelationGuidArray = reader.ReadInt32();
            byte[] dtlRelationGuidArray = reader.ReadBytes(lenOfDtlRelationGuidArray);
            temp.DtlRelationGuid = new Guid(dtlRelationGuidArray);

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
        /// <returns>AddUpOrgStockDetailWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   AddUpOrgStockDetailWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                AddUpOrgStockDetailWork temp = GetStockDetailWork(reader, serInfo);
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
                    retValue = (AddUpOrgStockDetailWork[])lst.ToArray(typeof(AddUpOrgStockDetailWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}
