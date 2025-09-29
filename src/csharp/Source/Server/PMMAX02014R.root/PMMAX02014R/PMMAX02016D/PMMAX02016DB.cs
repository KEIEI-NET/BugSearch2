//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 出品一括更新
// プログラム概要   : 出品一括更新抽出結果ワーク
//----------------------------------------------------------------------------//
//                (c)Copyright  2016 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11270001-00  作成担当 : 宋剛
// 作 成 日  2016/01/22  修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   PartsMaxStockUpdateResultWork
    /// <summary>
    ///                      出品一括更新抽出結果ワークワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   出品一括更新抽出結果ワークワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2016/01/22  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class PartsMaxStockUpdateResultWork
    {
        /// <summary>倉庫コード</summary>
        private string _warehouseCode = "";

        /// <summary>倉庫名称</summary>
        private string _warehouseNm = "";

        /// <summary>品番</summary>
        private string _goodsNo = "";

        /// <summary>品名</summary>
        private string _goodsName = "";

        /// <summary>単価</summary>
        private Double _salesUnitCost;

        /// <summary>在庫数量</summary>
        private Double _stockCnt;

        /// <summary>金額</summary>
        private Double _money;

        /// <summary>商品メーカーコード</summary>
        private Int32 _goodsMakerCd;

        /// <summary>拠点コード</summary>
        private string _sectionCode = "";

        /// <summary>メーカー名称</summary>
        private string _makerName = "";

        /// <summary>BL商品コード</summary>
        private Int32 _bLGoodsCode;

        /// <summary>BLグループコード</summary>
        /// <remarks>商品区分詳細</remarks>
        private Int32 _bLGroupCode;

        /// <summary>商品掛率グループコード</summary>
        /// <remarks>※中分類をセットする</remarks>
        private Int32 _goodsRateGrpCode;

        /// <summary>商品掛率ランク</summary>
        /// <remarks>層別</remarks>
        private string _goodsRateRank = "";

        /// <summary>得意先の売上単価端数処理コード</summary>
        /// <remarks>0の場合は 標準設定とする。</remarks>
        private Int32 _salesUnPrcFrcProcCd;

        /// <summary>得意先の売上消費税端数処理コード</summary>
        /// <remarks>0の場合は 標準設定とする。</remarks>
        private Int32 _salesCnsTaxFrcProcCd;

        /// <summary>売上掛率</summary>
        private Double _salesRateVal;

        /// <summary>仕入先コード</summary>
        private Int32 _supplierCd;

        /// <summary>オープン価格区分</summary>
        /// <remarks>0:通常／1:オープン価格</remarks>
        private Int32 _openPriceDiv;

        /// <summary>価格開始日</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _priceStartDate;

        /// <summary>定価</summary>
        private Double _listPrice;

        /// <summary>仕入率</summary>
        private Double _stockRate;

        /// <summary>提供日付</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _offerDate;

        /// <summary>更新年月日</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _updateDate;

        /// <summary>課税区分</summary>
        /// <remarks>0:課税,1:非課税,2:課税（内税）</remarks>
        private Int32 _taxationDivCd;

        /// <summary>価格マスタの原価単価</summary>
        private Double _gpuSalesUnitCost;


        /// public propaty name  :  WarehouseCode
        /// <summary>倉庫コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   倉庫コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string WarehouseCode
        {
            get { return _warehouseCode; }
            set { _warehouseCode = value; }
        }

        /// public propaty name  :  WarehouseNm
        /// <summary>倉庫名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   倉庫名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string WarehouseNm
        {
            get { return _warehouseNm; }
            set { _warehouseNm = value; }
        }

        /// public propaty name  :  GoodsNo
        /// <summary>品番プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   品番プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsNo
        {
            get { return _goodsNo; }
            set { _goodsNo = value; }
        }

        /// public propaty name  :  GoodsName
        /// <summary>品名プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   品名プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsName
        {
            get { return _goodsName; }
            set { _goodsName = value; }
        }

        /// public propaty name  :  SalesUnitCost
        /// <summary>単価プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   単価プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double SalesUnitCost
        {
            get { return _salesUnitCost; }
            set { _salesUnitCost = value; }
        }

        /// public propaty name  :  StockCnt
        /// <summary>在庫数量プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   在庫数量プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double StockCnt
        {
            get { return _stockCnt; }
            set { _stockCnt = value; }
        }

        /// public propaty name  :  Money
        /// <summary>金額プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   金額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double Money
        {
            get { return _money; }
            set { _money = value; }
        }

        /// public propaty name  :  GoodsMakerCd
        /// <summary>商品メーカーコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品メーカーコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsMakerCd
        {
            get { return _goodsMakerCd; }
            set { _goodsMakerCd = value; }
        }

        /// public propaty name  :  SectionCode
        /// <summary>拠点コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SectionCode
        {
            get { return _sectionCode; }
            set { _sectionCode = value; }
        }

        /// public propaty name  :  MakerName
        /// <summary>メーカー名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メーカー名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MakerName
        {
            get { return _makerName; }
            set { _makerName = value; }
        }

        /// public propaty name  :  BLGoodsCode
        /// <summary>BL商品コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL商品コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BLGoodsCode
        {
            get { return _bLGoodsCode; }
            set { _bLGoodsCode = value; }
        }

        /// public propaty name  :  BLGroupCode
        /// <summary>BLグループコードプロパティ</summary>
        /// <value>商品区分詳細</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BLグループコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BLGroupCode
        {
            get { return _bLGroupCode; }
            set { _bLGroupCode = value; }
        }

        /// public propaty name  :  GoodsRateGrpCode
        /// <summary>商品掛率グループコードプロパティ</summary>
        /// <value>※中分類をセットする</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品掛率グループコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsRateGrpCode
        {
            get { return _goodsRateGrpCode; }
            set { _goodsRateGrpCode = value; }
        }

        /// public propaty name  :  GoodsRateRank
        /// <summary>商品掛率ランクプロパティ</summary>
        /// <value>層別</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品掛率ランクプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsRateRank
        {
            get { return _goodsRateRank; }
            set { _goodsRateRank = value; }
        }

        /// public propaty name  :  SalesUnPrcFrcProcCd
        /// <summary>得意先の売上単価端数処理コードプロパティ</summary>
        /// <value>0の場合は 標準設定とする。</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先の売上単価端数処理コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SalesUnPrcFrcProcCd
        {
            get { return _salesUnPrcFrcProcCd; }
            set { _salesUnPrcFrcProcCd = value; }
        }

        /// public propaty name  :  SalesCnsTaxFrcProcCd
        /// <summary>得意先の売上消費税端数処理コードプロパティ</summary>
        /// <value>0の場合は 標準設定とする。</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先の売上消費税端数処理コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SalesCnsTaxFrcProcCd
        {
            get { return _salesCnsTaxFrcProcCd; }
            set { _salesCnsTaxFrcProcCd = value; }
        }

        /// public propaty name  :  SalesRateVal
        /// <summary>売上掛率プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上掛率プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double SalesRateVal
        {
            get { return _salesRateVal; }
            set { _salesRateVal = value; }
        }

        /// public propaty name  :  SupplierCd
        /// <summary>仕入先コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SupplierCd
        {
            get { return _supplierCd; }
            set { _supplierCd = value; }
        }

        /// public propaty name  :  OpenPriceDiv
        /// <summary>オープン価格区分プロパティ</summary>
        /// <value>0:通常／1:オープン価格</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   オープン価格区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 OpenPriceDiv
        {
            get { return _openPriceDiv; }
            set { _openPriceDiv = value; }
        }

        /// public propaty name  :  PriceStartDate
        /// <summary>価格開始日プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   価格開始日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PriceStartDate
        {
            get { return _priceStartDate; }
            set { _priceStartDate = value; }
        }

        /// public propaty name  :  ListPrice
        /// <summary>定価プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   定価プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double ListPrice
        {
            get { return _listPrice; }
            set { _listPrice = value; }
        }

        /// public propaty name  :  StockRate
        /// <summary>仕入率プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入率プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double StockRate
        {
            get { return _stockRate; }
            set { _stockRate = value; }
        }

        /// public propaty name  :  OfferDate
        /// <summary>提供日付プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   提供日付プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 OfferDate
        {
            get { return _offerDate; }
            set { _offerDate = value; }
        }

        /// public propaty name  :  UpdateDate
        /// <summary>更新年月日プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新年月日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 UpdateDate
        {
            get { return _updateDate; }
            set { _updateDate = value; }
        }

        /// public propaty name  :  TaxationDivCd
        /// <summary>課税区分プロパティ</summary>
        /// <value>0:課税,1:非課税,2:課税（内税）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   課税区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 TaxationDivCd
        {
            get { return _taxationDivCd; }
            set { _taxationDivCd = value; }
        }

        /// public propaty name  :  GpuSalesUnitCost
        /// <summary>価格マスタの原価単価プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   価格マスタの原価単価プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double GpuSalesUnitCost
        {
            get { return _gpuSalesUnitCost; }
            set { _gpuSalesUnitCost = value; }
        }


        /// <summary>
        /// 出品一括更新抽出結果ワークワークコンストラクタ
        /// </summary>
        /// <returns>PartsMaxStockUpdateResultWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PartsMaxStockUpdateResultWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public PartsMaxStockUpdateResultWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>PartsMaxStockUpdateResultWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   PartsMaxStockUpdateResultWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class PartsMaxStockUpdateResultWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   PartsMaxStockUpdateResultWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  PartsMaxStockUpdateResultWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is PartsMaxStockUpdateResultWork || graph is ArrayList || graph is PartsMaxStockUpdateResultWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(PartsMaxStockUpdateResultWork).FullName));

            if (graph != null && graph is PartsMaxStockUpdateResultWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.PartsMaxStockUpdateResultWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is PartsMaxStockUpdateResultWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((PartsMaxStockUpdateResultWork[])graph).Length;
            }
            else if (graph is PartsMaxStockUpdateResultWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //倉庫コード
            serInfo.MemberInfo.Add(typeof(string)); //WarehouseCode
            //倉庫名称
            serInfo.MemberInfo.Add(typeof(string)); //WarehouseNm
            //品番
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNo
            //品名
            serInfo.MemberInfo.Add(typeof(string)); //GoodsName
            //単価
            serInfo.MemberInfo.Add(typeof(Double)); //SalesUnitCost
            //在庫数量
            serInfo.MemberInfo.Add(typeof(Double)); //StockCnt
            //金額
            serInfo.MemberInfo.Add(typeof(Double)); //Money
            //商品メーカーコード
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd
            //拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //SectionCode
            //メーカー名称
            serInfo.MemberInfo.Add(typeof(string)); //MakerName
            //BL商品コード
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGoodsCode
            //BLグループコード
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGroupCode
            //商品掛率グループコード
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsRateGrpCode
            //商品掛率ランク
            serInfo.MemberInfo.Add(typeof(string)); //GoodsRateRank
            //得意先の売上単価端数処理コード
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesUnPrcFrcProcCd
            //得意先の売上消費税端数処理コード
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesCnsTaxFrcProcCd
            //売上掛率
            serInfo.MemberInfo.Add(typeof(Double)); //SalesRateVal
            //仕入先コード
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierCd
            //オープン価格区分
            serInfo.MemberInfo.Add(typeof(Int32)); //OpenPriceDiv
            //価格開始日
            serInfo.MemberInfo.Add(typeof(Int32)); //PriceStartDate
            //定価
            serInfo.MemberInfo.Add(typeof(Double)); //ListPrice
            //仕入率
            serInfo.MemberInfo.Add(typeof(Double)); //StockRate
            //提供日付
            serInfo.MemberInfo.Add(typeof(Int32)); //OfferDate
            //更新年月日
            serInfo.MemberInfo.Add(typeof(Int32)); //UpdateDate
            //課税区分
            serInfo.MemberInfo.Add(typeof(Int32)); //TaxationDivCd
            //価格マスタの原価単価
            serInfo.MemberInfo.Add(typeof(Double)); //GpuSalesUnitCost


            serInfo.Serialize(writer, serInfo);
            if (graph is PartsMaxStockUpdateResultWork)
            {
                PartsMaxStockUpdateResultWork temp = (PartsMaxStockUpdateResultWork)graph;

                SetPartsMaxStockUpdateResultWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is PartsMaxStockUpdateResultWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((PartsMaxStockUpdateResultWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (PartsMaxStockUpdateResultWork temp in lst)
                {
                    SetPartsMaxStockUpdateResultWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// PartsMaxStockUpdateResultWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 26;

        /// <summary>
        ///  PartsMaxStockUpdateResultWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   PartsMaxStockUpdateResultWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetPartsMaxStockUpdateResultWork(System.IO.BinaryWriter writer, PartsMaxStockUpdateResultWork temp)
        {
            //倉庫コード
            writer.Write(temp.WarehouseCode);
            //倉庫名称
            writer.Write(temp.WarehouseNm);
            //品番
            writer.Write(temp.GoodsNo);
            //品名
            writer.Write(temp.GoodsName);
            //単価
            writer.Write(temp.SalesUnitCost);
            //在庫数量
            writer.Write(temp.StockCnt);
            //金額
            writer.Write(temp.Money);
            //商品メーカーコード
            writer.Write(temp.GoodsMakerCd);
            //拠点コード
            writer.Write(temp.SectionCode);
            //メーカー名称
            writer.Write(temp.MakerName);
            //BL商品コード
            writer.Write(temp.BLGoodsCode);
            //BLグループコード
            writer.Write(temp.BLGroupCode);
            //商品掛率グループコード
            writer.Write(temp.GoodsRateGrpCode);
            //商品掛率ランク
            writer.Write(temp.GoodsRateRank);
            //得意先の売上単価端数処理コード
            writer.Write(temp.SalesUnPrcFrcProcCd);
            //得意先の売上消費税端数処理コード
            writer.Write(temp.SalesCnsTaxFrcProcCd);
            //売上掛率
            writer.Write(temp.SalesRateVal);
            //仕入先コード
            writer.Write(temp.SupplierCd);
            //オープン価格区分
            writer.Write(temp.OpenPriceDiv);
            //価格開始日
            writer.Write(temp.PriceStartDate);
            //定価
            writer.Write(temp.ListPrice);
            //仕入率
            writer.Write(temp.StockRate);
            //提供日付
            writer.Write(temp.OfferDate);
            //更新年月日
            writer.Write(temp.UpdateDate);
            //課税区分
            writer.Write(temp.TaxationDivCd);
            //価格マスタの原価単価
            writer.Write(temp.GpuSalesUnitCost);

        }

        /// <summary>
        ///  PartsMaxStockUpdateResultWorkインスタンス取得
        /// </summary>
        /// <returns>PartsMaxStockUpdateResultWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PartsMaxStockUpdateResultWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private PartsMaxStockUpdateResultWork GetPartsMaxStockUpdateResultWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            PartsMaxStockUpdateResultWork temp = new PartsMaxStockUpdateResultWork();

            //倉庫コード
            temp.WarehouseCode = reader.ReadString();
            //倉庫名称
            temp.WarehouseNm = reader.ReadString();
            //品番
            temp.GoodsNo = reader.ReadString();
            //品名
            temp.GoodsName = reader.ReadString();
            //単価
            temp.SalesUnitCost = reader.ReadDouble();
            //在庫数量
            temp.StockCnt = reader.ReadDouble();
            //金額
            temp.Money = reader.ReadDouble();
            //商品メーカーコード
            temp.GoodsMakerCd = reader.ReadInt32();
            //拠点コード
            temp.SectionCode = reader.ReadString();
            //メーカー名称
            temp.MakerName = reader.ReadString();
            //BL商品コード
            temp.BLGoodsCode = reader.ReadInt32();
            //BLグループコード
            temp.BLGroupCode = reader.ReadInt32();
            //商品掛率グループコード
            temp.GoodsRateGrpCode = reader.ReadInt32();
            //商品掛率ランク
            temp.GoodsRateRank = reader.ReadString();
            //得意先の売上単価端数処理コード
            temp.SalesUnPrcFrcProcCd = reader.ReadInt32();
            //得意先の売上消費税端数処理コード
            temp.SalesCnsTaxFrcProcCd = reader.ReadInt32();
            //売上掛率
            temp.SalesRateVal = reader.ReadDouble();
            //仕入先コード
            temp.SupplierCd = reader.ReadInt32();
            //オープン価格区分
            temp.OpenPriceDiv = reader.ReadInt32();
            //価格開始日
            temp.PriceStartDate = reader.ReadInt32();
            //定価
            temp.ListPrice = reader.ReadDouble();
            //仕入率
            temp.StockRate = reader.ReadDouble();
            //提供日付
            temp.OfferDate = reader.ReadInt32();
            //更新年月日
            temp.UpdateDate = reader.ReadInt32();
            //課税区分
            temp.TaxationDivCd = reader.ReadInt32();
            //価格マスタの原価単価
            temp.GpuSalesUnitCost = reader.ReadDouble();


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
        /// <returns>PartsMaxStockUpdateResultWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PartsMaxStockUpdateResultWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                PartsMaxStockUpdateResultWork temp = GetPartsMaxStockUpdateResultWork(reader, serInfo);
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
                    retValue = (PartsMaxStockUpdateResultWork[])lst.ToArray(typeof(PartsMaxStockUpdateResultWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}