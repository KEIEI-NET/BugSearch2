//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 得意先別見積書・棚卸表
// プログラム概要   : 得意先別見積書・棚卸表抽出結果ワーク
//----------------------------------------------------------------------------//
//                (c)Copyright  2013 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10970531-00  作成担当 : songg
// 作 成 日  K2013/12/03  修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   TakekawaQuotaInventResultWork
    /// <summary>
    ///                      得意先別見積書・棚卸表抽出結果ワークワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   得意先別見積書・棚卸表抽出結果ワークワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2014/01/20  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class TakekawaQuotaInventResultWork
    {
        /// <summary>処理日付</summary>
        private string _oprDate = "";

        /// <summary>拠点名称</summary>
        private string _sectionNm = "";

        /// <summary>敬称</summary>
        private string _honorificTtl = "";

        /// <summary>拠点郵便番号</summary>
        private string _sectionPostNo = "";

        /// <summary>拠点住所1</summary>
        private string _sectionAddress1 = "";

        /// <summary>拠点住所2</summary>
        private string _sectionAddress2 = "";

        /// <summary>倉庫コード</summary>
        private string _warehouseCode = "";

        /// <summary>倉庫名称</summary>
        private string _warehouseNm = "";

        /// <summary>棚番</summary>
        private string _warehouseShelfNo = "";

        /// <summary>品番</summary>
        private string _goodsNo = "";

        /// <summary>品名</summary>
        private string _goodsName = "";

        /// <summary>定価</summary>
        private Double _listPrice;

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

        /// <summary>得意先コード</summary>
        private Int32 _customerCode;

        /// <summary>得意先名称1</summary>
        private string _customerName = "";

        /// <summary>得意先名称2</summary>
        private string _customerName2 = "";

        /// <summary>BL商品コード</summary>
        private Int32 _bLGoodsCode;

        /// <summary>仕入先コード</summary>
        private Int32 _supplierCd;

        /// <summary>棚卸在庫数</summary>
        /// <remarks>棚卸数</remarks>
        private Double _inventoryStockCnt;

        /// <summary>BLグループコード</summary>
        /// <remarks>商品区分詳細</remarks>
        private Int32 _bLGroupCode;

        /// <summary>商品掛率グループコード</summary>
        /// <remarks>※中分類をセットする</remarks>
        private Int32 _goodsRateGrpCode;

        /// <summary>商品掛率ランク</summary>
        /// <remarks>層別</remarks>
        private string _goodsRateRank = "";

        /// <summary>課税区分</summary>
        /// <remarks>0:課税,1:非課税,2:課税（内税）</remarks>
        private Int32 _taxationDivCd;

        /// <summary>得意先の売上単価端数処理コード</summary>
        /// <remarks>0の場合は 標準設定とする。</remarks>
        private Int32 _salesUnPrcFrcProcCd;

        /// <summary>得意先の売上消費税端数処理コード</summary>
        /// <remarks>0の場合は 標準設定とする。</remarks>
        private Int32 _salesCnsTaxFrcProcCd;

        /// <summary>請求先の得意先消費税転嫁方式参照区分</summary>
        /// <remarks>0:税率設定マスタを参照　1:得意先マスタを参照</remarks>
        private Int32 _custCTaXLayRefCd;

        /// <summary>消費税転嫁方式</summary>
        /// <remarks>0:伝票単位1:明細単位2:請求親3:請求子　9:非課税</remarks>
        private Int32 _consTaxLayMethod;

        /// <summary>売上掛率</summary>
        private Double _salesRateVal;


        /// public propaty name  :  OprDate
        /// <summary>処理日付プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   処理日付プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string OprDate
        {
            get { return _oprDate; }
            set { _oprDate = value; }
        }

        /// public propaty name  :  SectionNm
        /// <summary>拠点名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SectionNm
        {
            get { return _sectionNm; }
            set { _sectionNm = value; }
        }

        /// public propaty name  :  HonorificTtl
        /// <summary>敬称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   敬称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HonorificTtl
        {
            get { return _honorificTtl; }
            set { _honorificTtl = value; }
        }

        /// public propaty name  :  SectionPostNo
        /// <summary>拠点郵便番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点郵便番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SectionPostNo
        {
            get { return _sectionPostNo; }
            set { _sectionPostNo = value; }
        }

        /// public propaty name  :  SectionAddress1
        /// <summary>拠点住所1プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点住所1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SectionAddress1
        {
            get { return _sectionAddress1; }
            set { _sectionAddress1 = value; }
        }

        /// public propaty name  :  SectionAddress2
        /// <summary>拠点住所2プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点住所2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SectionAddress2
        {
            get { return _sectionAddress2; }
            set { _sectionAddress2 = value; }
        }

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

        /// public propaty name  :  WarehouseShelfNo
        /// <summary>棚番プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   棚番プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string WarehouseShelfNo
        {
            get { return _warehouseShelfNo; }
            set { _warehouseShelfNo = value; }
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

        /// public propaty name  :  CustomerCode
        /// <summary>得意先コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CustomerCode
        {
            get { return _customerCode; }
            set { _customerCode = value; }
        }

        /// public propaty name  :  CustomerName
        /// <summary>得意先名称1プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先名称1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CustomerName
        {
            get { return _customerName; }
            set { _customerName = value; }
        }

        /// public propaty name  :  CustomerName2
        /// <summary>得意先名称2プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先名称2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CustomerName2
        {
            get { return _customerName2; }
            set { _customerName2 = value; }
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

        /// public propaty name  :  InventoryStockCnt
        /// <summary>棚卸在庫数プロパティ</summary>
        /// <value>棚卸数</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   棚卸在庫数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double InventoryStockCnt
        {
            get { return _inventoryStockCnt; }
            set { _inventoryStockCnt = value; }
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

        /// public propaty name  :  CustCTaXLayRefCd
        /// <summary>請求先の得意先消費税転嫁方式参照区分プロパティ</summary>
        /// <value>0:税率設定マスタを参照　1:得意先マスタを参照</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   請求先の得意先消費税転嫁方式参照区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CustCTaXLayRefCd
        {
            get { return _custCTaXLayRefCd; }
            set { _custCTaXLayRefCd = value; }
        }

        /// public propaty name  :  ConsTaxLayMethod
        /// <summary>消費税転嫁方式プロパティ</summary>
        /// <value>0:伝票単位1:明細単位2:請求親3:請求子　9:非課税</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   消費税転嫁方式プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ConsTaxLayMethod
        {
            get { return _consTaxLayMethod; }
            set { _consTaxLayMethod = value; }
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


        /// <summary>
        /// 得意先別見積書・棚卸表抽出結果ワークワークコンストラクタ
        /// </summary>
        /// <returns>TakekawaQuotaInventResultWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   TakekawaQuotaInventResultWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public TakekawaQuotaInventResultWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>TakekawaQuotaInventResultWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   TakekawaQuotaInventResultWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class TakekawaQuotaInventResultWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   TakekawaQuotaInventResultWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  TakekawaQuotaInventResultWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is TakekawaQuotaInventResultWork || graph is ArrayList || graph is TakekawaQuotaInventResultWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(TakekawaQuotaInventResultWork).FullName));

            if (graph != null && graph is TakekawaQuotaInventResultWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.TakekawaQuotaInventResultWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is TakekawaQuotaInventResultWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((TakekawaQuotaInventResultWork[])graph).Length;
            }
            else if (graph is TakekawaQuotaInventResultWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //処理日付
            serInfo.MemberInfo.Add(typeof(string)); //OprDate
            //拠点名称
            serInfo.MemberInfo.Add(typeof(string)); //SectionNm
            //敬称
            serInfo.MemberInfo.Add(typeof(string)); //HonorificTtl
            //拠点郵便番号
            serInfo.MemberInfo.Add(typeof(string)); //SectionPostNo
            //拠点住所1
            serInfo.MemberInfo.Add(typeof(string)); //SectionAddress1
            //拠点住所2
            serInfo.MemberInfo.Add(typeof(string)); //SectionAddress2
            //倉庫コード
            serInfo.MemberInfo.Add(typeof(string)); //WarehouseCode
            //倉庫名称
            serInfo.MemberInfo.Add(typeof(string)); //WarehouseNm
            //棚番
            serInfo.MemberInfo.Add(typeof(string)); //WarehouseShelfNo
            //品番
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNo
            //品名
            serInfo.MemberInfo.Add(typeof(string)); //GoodsName
            //定価
            serInfo.MemberInfo.Add(typeof(Double)); //ListPrice
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
            //得意先コード
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerCode
            //得意先名称1
            serInfo.MemberInfo.Add(typeof(string)); //CustomerName
            //得意先名称2
            serInfo.MemberInfo.Add(typeof(string)); //CustomerName2
            //BL商品コード
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGoodsCode
            //仕入先コード
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierCd
            //棚卸在庫数
            serInfo.MemberInfo.Add(typeof(Double)); //InventoryStockCnt
            //BLグループコード
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGroupCode
            //商品掛率グループコード
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsRateGrpCode
            //商品掛率ランク
            serInfo.MemberInfo.Add(typeof(string)); //GoodsRateRank
            //課税区分
            serInfo.MemberInfo.Add(typeof(Int32)); //TaxationDivCd
            //得意先の売上単価端数処理コード
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesUnPrcFrcProcCd
            //得意先の売上消費税端数処理コード
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesCnsTaxFrcProcCd
            //請求先の得意先消費税転嫁方式参照区分
            serInfo.MemberInfo.Add(typeof(Int32)); //CustCTaXLayRefCd
            //消費税転嫁方式
            serInfo.MemberInfo.Add(typeof(Int32)); //ConsTaxLayMethod
            //売上掛率
            serInfo.MemberInfo.Add(typeof(Double)); //SalesRateVal


            serInfo.Serialize(writer, serInfo);
            if (graph is TakekawaQuotaInventResultWork)
            {
                TakekawaQuotaInventResultWork temp = (TakekawaQuotaInventResultWork)graph;

                SetTakekawaQuotaInventResultWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is TakekawaQuotaInventResultWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((TakekawaQuotaInventResultWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (TakekawaQuotaInventResultWork temp in lst)
                {
                    SetTakekawaQuotaInventResultWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// TakekawaQuotaInventResultWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 32;

        /// <summary>
        ///  TakekawaQuotaInventResultWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   TakekawaQuotaInventResultWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetTakekawaQuotaInventResultWork(System.IO.BinaryWriter writer, TakekawaQuotaInventResultWork temp)
        {
            //処理日付
            writer.Write(temp.OprDate);
            //拠点名称
            writer.Write(temp.SectionNm);
            //敬称
            writer.Write(temp.HonorificTtl);
            //拠点郵便番号
            writer.Write(temp.SectionPostNo);
            //拠点住所1
            writer.Write(temp.SectionAddress1);
            //拠点住所2
            writer.Write(temp.SectionAddress2);
            //倉庫コード
            writer.Write(temp.WarehouseCode);
            //倉庫名称
            writer.Write(temp.WarehouseNm);
            //棚番
            writer.Write(temp.WarehouseShelfNo);
            //品番
            writer.Write(temp.GoodsNo);
            //品名
            writer.Write(temp.GoodsName);
            //定価
            writer.Write(temp.ListPrice);
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
            //得意先コード
            writer.Write(temp.CustomerCode);
            //得意先名称1
            writer.Write(temp.CustomerName);
            //得意先名称2
            writer.Write(temp.CustomerName2);
            //BL商品コード
            writer.Write(temp.BLGoodsCode);
            //仕入先コード
            writer.Write(temp.SupplierCd);
            //棚卸在庫数
            writer.Write(temp.InventoryStockCnt);
            //BLグループコード
            writer.Write(temp.BLGroupCode);
            //商品掛率グループコード
            writer.Write(temp.GoodsRateGrpCode);
            //商品掛率ランク
            writer.Write(temp.GoodsRateRank);
            //課税区分
            writer.Write(temp.TaxationDivCd);
            //得意先の売上単価端数処理コード
            writer.Write(temp.SalesUnPrcFrcProcCd);
            //得意先の売上消費税端数処理コード
            writer.Write(temp.SalesCnsTaxFrcProcCd);
            //請求先の得意先消費税転嫁方式参照区分
            writer.Write(temp.CustCTaXLayRefCd);
            //消費税転嫁方式
            writer.Write(temp.ConsTaxLayMethod);
            //売上掛率
            writer.Write(temp.SalesRateVal);

        }

        /// <summary>
        ///  TakekawaQuotaInventResultWorkインスタンス取得
        /// </summary>
        /// <returns>TakekawaQuotaInventResultWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   TakekawaQuotaInventResultWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private TakekawaQuotaInventResultWork GetTakekawaQuotaInventResultWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            TakekawaQuotaInventResultWork temp = new TakekawaQuotaInventResultWork();

            //処理日付
            temp.OprDate = reader.ReadString();
            //拠点名称
            temp.SectionNm = reader.ReadString();
            //敬称
            temp.HonorificTtl = reader.ReadString();
            //拠点郵便番号
            temp.SectionPostNo = reader.ReadString();
            //拠点住所1
            temp.SectionAddress1 = reader.ReadString();
            //拠点住所2
            temp.SectionAddress2 = reader.ReadString();
            //倉庫コード
            temp.WarehouseCode = reader.ReadString();
            //倉庫名称
            temp.WarehouseNm = reader.ReadString();
            //棚番
            temp.WarehouseShelfNo = reader.ReadString();
            //品番
            temp.GoodsNo = reader.ReadString();
            //品名
            temp.GoodsName = reader.ReadString();
            //定価
            temp.ListPrice = reader.ReadDouble();
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
            //得意先コード
            temp.CustomerCode = reader.ReadInt32();
            //得意先名称1
            temp.CustomerName = reader.ReadString();
            //得意先名称2
            temp.CustomerName2 = reader.ReadString();
            //BL商品コード
            temp.BLGoodsCode = reader.ReadInt32();
            //仕入先コード
            temp.SupplierCd = reader.ReadInt32();
            //棚卸在庫数
            temp.InventoryStockCnt = reader.ReadDouble();
            //BLグループコード
            temp.BLGroupCode = reader.ReadInt32();
            //商品掛率グループコード
            temp.GoodsRateGrpCode = reader.ReadInt32();
            //商品掛率ランク
            temp.GoodsRateRank = reader.ReadString();
            //課税区分
            temp.TaxationDivCd = reader.ReadInt32();
            //得意先の売上単価端数処理コード
            temp.SalesUnPrcFrcProcCd = reader.ReadInt32();
            //得意先の売上消費税端数処理コード
            temp.SalesCnsTaxFrcProcCd = reader.ReadInt32();
            //請求先の得意先消費税転嫁方式参照区分
            temp.CustCTaXLayRefCd = reader.ReadInt32();
            //消費税転嫁方式
            temp.ConsTaxLayMethod = reader.ReadInt32();
            //売上掛率
            temp.SalesRateVal = reader.ReadDouble();


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
        /// <returns>TakekawaQuotaInventResultWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   TakekawaQuotaInventResultWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                TakekawaQuotaInventResultWork temp = GetTakekawaQuotaInventResultWork(reader, serInfo);
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
                    retValue = (TakekawaQuotaInventResultWork[])lst.ToArray(typeof(TakekawaQuotaInventResultWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }






}

