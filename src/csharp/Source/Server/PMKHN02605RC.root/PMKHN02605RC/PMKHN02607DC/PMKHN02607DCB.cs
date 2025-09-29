using System;
using System.Collections;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   FutabaGoodsPrintResultWork
    /// <summary>
    ///                      商品印刷抽出結果クラスワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   商品印刷抽出結果クラスワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/11/11  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// <br>UpdateNote       : K2013/09/10 wangl2　フタバ修正</br>
    /// <br>管理番号         : 10902160-00</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class FutabaGoodsPrintResultWork 
    {
        /// <summary>更新日時</summary>
        /// <remarks>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</remarks>
        private DateTime _updateDateTime;
        // --------------- ADD START K2013/09/10 wangl2 FOR フタバ様改修------>>>>
        /// <summary>更新日時</summary>
        /// <remarks>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</remarks>
        private DateTime _createDateTime;

        /// <summary>更新年月日</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _updateDate;
        // --------------- ADD END K2013/09/10 wangl2 FOR フタバ様改修--------<<<<
        /// <summary>拠点コード</summary>
        private string _sectionCode = "";

        /// <summary>商品メーカーコード</summary>
        private Int32 _goodsMakerCd;

        /// <summary>メーカー略称</summary>
        private string _makerShortName = "";

        /// <summary>商品番号</summary>
        private string _goodsNo = "";

        /// <summary>商品名称</summary>
        private string _goodsName = "";

        /// <summary>商品名称カナ</summary>
        private string _goodsNameKana = "";

        /// <summary>BL商品コード</summary>
        private Int32 _bLGoodsCode;

        /// <summary>BL商品コード名称（半角）</summary>
        private string _bLGoodsHalfName = "";

        /// <summary>仕入先コード</summary>
        private Int32 _supplierCd;

        /// <summary>仕入先略称</summary>
        private string _supplierSnm = "";

        /// <summary>標準価格</summary>
        /// <remarks>定価（浮動）</remarks>
        private Double _listPrice;

        /// <summary>仕入率</summary>
        private Double _stockRate;

        /// <summary>原価単価</summary>
        private Double _salesUnitCost;

        /// <summary>層別</summary>
        /// <remarks>商品掛率ランク</remarks>
        private string _goodsRateRank = "";

        /// <summary>発注ロット</summary>
        private Int32 _supplierLot;

        /// <summary>商品規格・特記事項</summary>
        private string _goodsSpecialNote = "";

        /// <summary>商品備考１</summary>
        private string _goodsNote1 = "";

        /// <summary>商品備考２</summary>
        private string _goodsNote2 = "";

        /// <summary>適用日</summary>
        /// <remarks>価格開始日 YYYYMMDD</remarks>
        private DateTime _priceStartDate;

        /// <summary>新適用価格</summary>
        /// <remarks>定価（浮動）</remarks>
        private Double _newListPrice;

        /// <summary>純優区分</summary>
        /// <remarks>商品属性 0:純正 1:その他</remarks>
        private Int32 _goodsKindCode;

        /// <summary>課税区分</summary>
        /// <remarks>0:課税 1:非課税 2:課税（内税）</remarks>
        private Int32 _taxationDivCd;

        /// <summary>商品区分</summary>
        /// <remarks>自社分類コード</remarks>
        private Int32 _enterpriseGanreCode;

        /// <summary>商品区分名称</summary>
        /// <remarks>ユーザーガイド区分名称(自社分類コード)</remarks>
        private string _enterpriseGanreCodeName = "";

        /// <summary>提供データ区分</summary>
        /// <remarks>0:ユーザデータ 1:提供データ</remarks>
        private Int32 _offerDataDiv;

        //----------------ADD 2011/08/12----------------------->>>>>
        /// <summary>中分類</summary>
        private Int32 _goodsRateGrpCode;
        //----------------ADD 2011/08/12-----------------------<<<<<


        /// public propaty name  :  UpdateDateTime
        /// <summary>更新日時プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新日時プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime UpdateDateTime
        {
            get { return _updateDateTime; }
            set { _updateDateTime = value; }
        }

        // --------------- ADD START K2013/09/10 wangl2 FOR フタバ様改修------>>>>
        /// public propaty name  :  CreateDateTime
        /// <summary>作成日時プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   作成日時プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime CreateDateTime
        {
            get { return _createDateTime; }
            set { _createDateTime = value; }
        }

        /// public propaty name  :  UpdateDate
        /// <summary>更新年月日プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新年月日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime UpdateDate
        {
            get { return _updateDate; }
            set { _updateDate = value; }
        }
        // --------------- ADD END K2013/09/10 wangl2 FOR フタバ様改修--------<<<<
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

        /// public propaty name  :  MakerShortName
        /// <summary>メーカー略称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メーカー略称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MakerShortName
        {
            get { return _makerShortName; }
            set { _makerShortName = value; }
        }

        /// public propaty name  :  GoodsNo
        /// <summary>商品番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsNo
        {
            get { return _goodsNo; }
            set { _goodsNo = value; }
        }

        /// public propaty name  :  GoodsName
        /// <summary>商品名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsName
        {
            get { return _goodsName; }
            set { _goodsName = value; }
        }

        /// public propaty name  :  GoodsNameKana
        /// <summary>商品名称カナプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品名称カナプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsNameKana
        {
            get { return _goodsNameKana; }
            set { _goodsNameKana = value; }
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

        /// public propaty name  :  BLGoodsHalfName
        /// <summary>BL商品コード名称（半角）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL商品コード名称（半角）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string BLGoodsHalfName
        {
            get { return _bLGoodsHalfName; }
            set { _bLGoodsHalfName = value; }
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

        /// public propaty name  :  SupplierSnm
        /// <summary>仕入先略称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先略称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SupplierSnm
        {
            get { return _supplierSnm; }
            set { _supplierSnm = value; }
        }

        /// public propaty name  :  ListPrice
        /// <summary>標準価格プロパティ</summary>
        /// <value>定価（浮動）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   標準価格プロパティ</br>
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

        /// public propaty name  :  SalesUnitCost
        /// <summary>原価単価プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   原価単価プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double SalesUnitCost
        {
            get { return _salesUnitCost; }
            set { _salesUnitCost = value; }
        }

        /// public propaty name  :  GoodsRateRank
        /// <summary>層別プロパティ</summary>
        /// <value>商品掛率ランク</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   層別プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsRateRank
        {
            get { return _goodsRateRank; }
            set { _goodsRateRank = value; }
        }

        /// public propaty name  :  SupplierLot
        /// <summary>発注ロットプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   発注ロットプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SupplierLot
        {
            get { return _supplierLot; }
            set { _supplierLot = value; }
        }

        /// public propaty name  :  GoodsSpecialNote
        /// <summary>商品規格・特記事項プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品規格・特記事項プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsSpecialNote
        {
            get { return _goodsSpecialNote; }
            set { _goodsSpecialNote = value; }
        }

        /// public propaty name  :  GoodsNote1
        /// <summary>商品備考１プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品備考１プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsNote1
        {
            get { return _goodsNote1; }
            set { _goodsNote1 = value; }
        }

        /// public propaty name  :  GoodsNote2
        /// <summary>商品備考２プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品備考２プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsNote2
        {
            get { return _goodsNote2; }
            set { _goodsNote2 = value; }
        }

        /// public propaty name  :  PriceStartDate
        /// <summary>適用日プロパティ</summary>
        /// <value>価格開始日 YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   適用日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime PriceStartDate
        {
            get { return _priceStartDate; }
            set { _priceStartDate = value; }
        }

        /// public propaty name  :  NewListPrice
        /// <summary>新適用価格プロパティ</summary>
        /// <value>定価（浮動）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   新適用価格プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double NewListPrice
        {
            get { return _newListPrice; }
            set { _newListPrice = value; }
        }

        /// public propaty name  :  GoodsKindCode
        /// <summary>純優区分プロパティ</summary>
        /// <value>商品属性 0:純正 1:その他</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   純優区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsKindCode
        {
            get { return _goodsKindCode; }
            set { _goodsKindCode = value; }
        }

        /// public propaty name  :  TaxationDivCd
        /// <summary>課税区分プロパティ</summary>
        /// <value>0:課税 1:非課税 2:課税（内税）</value>
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

        /// public propaty name  :  EnterpriseGanreCode
        /// <summary>商品区分プロパティ</summary>
        /// <value>自社分類コード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 EnterpriseGanreCode
        {
            get { return _enterpriseGanreCode; }
            set { _enterpriseGanreCode = value; }
        }

        /// public propaty name  :  EnterpriseGanreCodeName
        /// <summary>商品区分名称プロパティ</summary>
        /// <value>ユーザーガイド区分名称(自社分類コード)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品区分名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EnterpriseGanreCodeName
        {
            get { return _enterpriseGanreCodeName; }
            set { _enterpriseGanreCodeName = value; }
        }

        /// public propaty name  :  OfferDataDiv
        /// <summary>提供データ区分プロパティ</summary>
        /// <value>0:ユーザデータ 1:提供データ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   提供データ区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 OfferDataDiv
        {
            get { return _offerDataDiv; }
            set { _offerDataDiv = value; }
        }

        //-------------------ADD 2011/08/12-------------------->>>>>
        /// public propaty name  :  GoodsRateGrpCode
        /// <summary>中分類プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   中分類プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsRateGrpCode
        {
            get { return _goodsRateGrpCode; }
            set { _goodsRateGrpCode = value; }
        }
        //-------------------ADD 2011/08/12--------------------<<<<<


        /// <summary>
        /// 商品印刷抽出結果クラスワークコンストラクタ
        /// </summary>
        /// <returns>FutabaGoodsPrintResultWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   FutabaGoodsPrintResultWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public FutabaGoodsPrintResultWork()
        {
        }
    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>FutabaGoodsPrintResultWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   FutabaGoodsPrintResultWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class FutabaGoodsPrintResultWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   FutabaGoodsPrintResultWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  FutabaGoodsPrintResultWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is FutabaGoodsPrintResultWork || graph is ArrayList || graph is FutabaGoodsPrintResultWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(FutabaGoodsPrintResultWork).FullName));

            if (graph != null && graph is FutabaGoodsPrintResultWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.FutabaGoodsPrintResultWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is FutabaGoodsPrintResultWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((FutabaGoodsPrintResultWork[])graph).Length;
            }
            else if (graph is FutabaGoodsPrintResultWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //更新日時
            serInfo.MemberInfo.Add(typeof(Int64)); //UpdateDateTime
            //作成日時
            serInfo.MemberInfo.Add(typeof(Int64)); //CreateDateTime// ADD K2013/09/10 wangl2 FOR フタバ様改修
            // 更新年月日
            serInfo.MemberInfo.Add(typeof(Int32));// UpdateDate// ADD K2013/09/10 wangl2 FOR フタバ様改修
            //拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //SectionCode
            //商品メーカーコード
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd
            //メーカー略称
            serInfo.MemberInfo.Add(typeof(string)); //MakerShortName
            //商品番号
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNo
            //商品名称
            serInfo.MemberInfo.Add(typeof(string)); //GoodsName
            //商品名称カナ
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNameKana
            //BL商品コード
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGoodsCode
            //BL商品コード名称（半角）
            serInfo.MemberInfo.Add(typeof(string)); //BLGoodsHalfName
            //仕入先コード
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierCd
            //仕入先略称
            serInfo.MemberInfo.Add(typeof(string)); //SupplierSnm
            //標準価格
            serInfo.MemberInfo.Add(typeof(Double)); //ListPrice
            //仕入率
            serInfo.MemberInfo.Add(typeof(Double)); //StockRate
            //原価単価
            serInfo.MemberInfo.Add(typeof(Double)); //SalesUnitCost
            //層別
            serInfo.MemberInfo.Add(typeof(string)); //GoodsRateRank
            //発注ロット
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierLot
            //商品規格・特記事項
            serInfo.MemberInfo.Add(typeof(string)); //GoodsSpecialNote
            //商品備考１
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNote1
            //商品備考２
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNote2
            //適用日
            serInfo.MemberInfo.Add(typeof(Int32)); //PriceStartDate
            //新適用価格
            serInfo.MemberInfo.Add(typeof(Double)); //NewListPrice
            //純優区分
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsKindCode
            //課税区分
            serInfo.MemberInfo.Add(typeof(Int32)); //TaxationDivCd
            //商品区分
            serInfo.MemberInfo.Add(typeof(Int32)); //EnterpriseGanreCode
            //商品区分名称
            serInfo.MemberInfo.Add(typeof(string)); //EnterpriseGanreCodeName
            //提供データ区分
            serInfo.MemberInfo.Add(typeof(Int32)); //OfferDataDiv
            //------------ADD 2011/08/12-------------------->>>>>
            //中分類
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsRateGrpCode
            //------------ADD 2011/08/12--------------------<<<<<


            serInfo.Serialize(writer, serInfo);
            if (graph is FutabaGoodsPrintResultWork)
            {
                FutabaGoodsPrintResultWork temp = (FutabaGoodsPrintResultWork)graph;

                SetGoodsPrintResultWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is FutabaGoodsPrintResultWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((FutabaGoodsPrintResultWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (FutabaGoodsPrintResultWork temp in lst)
                {
                    SetGoodsPrintResultWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// FutabaGoodsPrintResultWorkメンバ数(publicプロパティ数)
        /// </summary>
        //private const int currentMemberCount = 27;// DEL K2013/09/10 wangl2 FOR フタバ様改修
        private const int currentMemberCount = 29;// ADD K2013/09/10 wangl2 FOR フタバ様改修

        /// <summary>
        ///  FutabaGoodsPrintResultWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   FutabaGoodsPrintResultWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetGoodsPrintResultWork(System.IO.BinaryWriter writer, FutabaGoodsPrintResultWork temp)
        {
            //更新日時
            writer.Write((Int64)temp.UpdateDateTime.Ticks);
            //作成日時
            writer.Write((Int64)temp.CreateDateTime.Ticks);// ADD K2013/09/10 wangl2 FOR フタバ様改修
            // 更新年月日
            writer.Write((Int64)temp.UpdateDate.Ticks);// ADD K2013/09/10 wangl2 FOR フタバ様改修
            //拠点コード
            writer.Write(temp.SectionCode);
            //商品メーカーコード
            writer.Write(temp.GoodsMakerCd);
            //メーカー略称
            writer.Write(temp.MakerShortName);
            //商品番号
            writer.Write(temp.GoodsNo);
            //商品名称
            writer.Write(temp.GoodsName);
            //商品名称カナ
            writer.Write(temp.GoodsNameKana);
            //BL商品コード
            writer.Write(temp.BLGoodsCode);
            //BL商品コード名称（半角）
            writer.Write(temp.BLGoodsHalfName);
            //仕入先コード
            writer.Write(temp.SupplierCd);
            //仕入先略称
            writer.Write(temp.SupplierSnm);
            //標準価格
            writer.Write(temp.ListPrice);
            //仕入率
            writer.Write(temp.StockRate);
            //原価単価
            writer.Write(temp.SalesUnitCost);
            //層別
            writer.Write(temp.GoodsRateRank);
            //発注ロット
            writer.Write(temp.SupplierLot);
            //商品規格・特記事項
            writer.Write(temp.GoodsSpecialNote);
            //商品備考１
            writer.Write(temp.GoodsNote1);
            //商品備考２
            writer.Write(temp.GoodsNote2);
            //適用日
            writer.Write((Int64)temp.PriceStartDate.Ticks);
            //新適用価格
            writer.Write(temp.NewListPrice);
            //純優区分
            writer.Write(temp.GoodsKindCode);
            //課税区分
            writer.Write(temp.TaxationDivCd);
            //商品区分
            writer.Write(temp.EnterpriseGanreCode);
            //商品区分名称
            writer.Write(temp.EnterpriseGanreCodeName);
            //提供データ区分
            writer.Write(temp.OfferDataDiv);
            //-----------------ADD 2011/08/12--------------->>>>>
            //中分類
            writer.Write(temp.GoodsRateGrpCode);
            //-----------------ADD 2011/08/12---------------<<<<<

        }

        /// <summary>
        ///  FutabaGoodsPrintResultWorkインスタンス取得
        /// </summary>
        /// <returns>FutabaGoodsPrintResultWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   FutabaGoodsPrintResultWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private FutabaGoodsPrintResultWork GetGoodsPrintResultWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            FutabaGoodsPrintResultWork temp = new FutabaGoodsPrintResultWork();

            //更新日時
            temp.UpdateDateTime = new DateTime(reader.ReadInt64());
            //作成日時
            temp.CreateDateTime = new DateTime(reader.ReadInt64());// ADD K2013/09/10 wangl2 FOR フタバ様改修
            //更新年月日
            temp.UpdateDate = new DateTime(reader.ReadInt64());// ADD K2013/09/10 wangl2 FOR フタバ様改修
            //拠点コード
            temp.SectionCode = reader.ReadString();
            //商品メーカーコード
            temp.GoodsMakerCd = reader.ReadInt32();
            //メーカー略称
            temp.MakerShortName = reader.ReadString();
            //商品番号
            temp.GoodsNo = reader.ReadString();
            //商品名称
            temp.GoodsName = reader.ReadString();
            //商品名称カナ
            temp.GoodsNameKana = reader.ReadString();
            //BL商品コード
            temp.BLGoodsCode = reader.ReadInt32();
            //BL商品コード名称（半角）
            temp.BLGoodsHalfName = reader.ReadString();
            //仕入先コード
            temp.SupplierCd = reader.ReadInt32();
            //仕入先略称
            temp.SupplierSnm = reader.ReadString();
            //標準価格
            temp.ListPrice = reader.ReadDouble();
            //仕入率
            temp.StockRate = reader.ReadDouble();
            //原価単価
            temp.SalesUnitCost = reader.ReadDouble();
            //層別
            temp.GoodsRateRank = reader.ReadString();
            //発注ロット
            temp.SupplierLot = reader.ReadInt32();
            //商品規格・特記事項
            temp.GoodsSpecialNote = reader.ReadString();
            //商品備考１
            temp.GoodsNote1 = reader.ReadString();
            //商品備考２
            temp.GoodsNote2 = reader.ReadString();
            //適用日
            temp.PriceStartDate = new DateTime(reader.ReadInt64());
            //新適用価格
            temp.NewListPrice = reader.ReadDouble();
            //純優区分
            temp.GoodsKindCode = reader.ReadInt32();
            //課税区分
            temp.TaxationDivCd = reader.ReadInt32();
            //商品区分
            temp.EnterpriseGanreCode = reader.ReadInt32();
            //商品区分名称
            temp.EnterpriseGanreCodeName = reader.ReadString();
            //提供データ区分
            temp.OfferDataDiv = reader.ReadInt32();
            //-----------------ADD 2011/08/12------------------->>>>>
            //中分類
            temp.GoodsRateGrpCode = reader.ReadInt32();
            //-----------------ADD 2011/08/12-------------------<<<<<


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
        /// <returns>FutabaGoodsPrintResultWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   FutabaGoodsPrintResultWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                FutabaGoodsPrintResultWork temp = GetGoodsPrintResultWork(reader, serInfo);
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
                    retValue = (FutabaGoodsPrintResultWork[])lst.ToArray(typeof(FutabaGoodsPrintResultWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}
