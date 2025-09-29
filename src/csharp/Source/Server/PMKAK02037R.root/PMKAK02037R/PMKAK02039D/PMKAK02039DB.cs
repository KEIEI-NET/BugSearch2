//***************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : 仕入返品予定一覧表
// プログラム概要   : 仕入返品予定一覧表 抽出結果クラスワーク
//----------------------------------------------------------------------------//
//                (c)Copyright  2013 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10806793-00 作成担当 : FSI高橋 文彰
// 作 成 日   2013/01/28 修正内容 : 新規作成 仕入返品予定機能対応
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   StockRetPlnList
    /// <summary>
    ///                      仕入返品予定一覧表抽出結果クラスワークワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   仕入返品予定一覧表抽出結果クラスワークワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2009/04/07  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class StockRetPlnList
    {
        /// <summary>拠点コード</summary>
        private string _sectionCode = "";
        /// <summary>拠点ガイド名称</summary>
        private string _sectionGuideNm = "";
        /// <summary>仕入伝票番号</summary>
        private Int32 _supplierSlipNo;
        /// <summary>伝票金額（税抜）</summary>
        private Int64 _stockTtlPricTaxExc;
        /// <summary>伝票金額（税込）</summary>
        private Int64 _stockTtlPricTaxInc;
        /// <summary>入力日</summary>
        private DateTime _inputDay;
        /// <summary>仕入日</summary>
        private DateTime _stockDate;
        /// <summary>仕入先コード</summary>
        private Int32 _supplierCd;
        /// <summary>仕入先略称</summary>
        private string _supplierSnm = "";
        /// <summary>伝票消費税額</summary>
        private Int64 _DtlConsTax;
        /// <summary>商品メーカーコード</summary>
        private Int32 _goodsMakerCd;
        /// <summary>メーカー名称</summary>
        private string _makerName = "";
        /// <summary>商品番号</summary>
        private string _goodsNo = "";
        /// <summary>商品名称</summary>
        private string _goodsName = "";
        /// <summary>仕入数</summary>
        private Double _stockCount;
        /// <summary>定価（税抜）</summary>
        private Double _ListPriceTaxExc;
        /// <summary>定価（税込）</summary>
        private Double _ListPriceTaxInc;
        /// <summary>仕入単価（税抜）</summary>
        private Double _stockUnitPriceFl;
        /// <summary>仕入単価（税込）</summary>
        private Double _stockUnitTaxPriceFl;
        /// <summary>仕入金額（税抜）</summary>
        private Int64 _stockPriceTaxExc;
        /// <summary>仕入金額（税込）</summary>
        private Int64 _stockPriceTaxInc;
        /// <summary>課税区分</summary>
        private Int32 _taxationCode;
        /// <summary>仕入伝票備考1</summary>
        private string _supplierSlipNote1 = "";
        /// <summary>仕入先消費税転嫁方式コード</summary>
        private Int32 _suppCTaxLayCd;
        /// <summary>BL商品コード</summary>
        private Int32 _bLGoodsCode;
        /// <summary>BL商品コード名称（全角）</summary>
        private string _bLGoodsFullName = "";
        /// <summary>明細消費税額</summary>
        private Int64 _SlpConsTax;
        /// <summary>論理削除区分(仕入データ)</summary>
        private Int32 _slpLogDelCd;
        /// <summary>論理削除区分(仕入明細データ)</summary>
        private Int32 _dtlLogDelCd;
        /// <summary>売上明細通番（同時）</summary>
        private Int64 _salesSlipDtlNum;
        /// <summary>伝票区分</summary>
        private Int32 _supplierSlipCd;

        /// public propaty name  :  SupplierSlipCd
        /// <summary>伝票区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SupplierSlipCd
        {
            get { return _supplierSlipCd; }
            set { _supplierSlipCd = value; }
        }

        /// public propaty name  :  SlpLogDelCd
        /// <summary>論理削除区分プロパティ(仕入データ)</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   論理削除区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SlpLogDelCd
        {
            get { return _slpLogDelCd; }
            set { _slpLogDelCd = value; }
        }

        /// public propaty name  :  LogicalDelCode
        /// <summary>論理削除区分プロパティ(仕入明細データ)</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   論理削除区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DtlLogDelCd
        {
            get { return _dtlLogDelCd; }
            set { _dtlLogDelCd = value; }
        }

        /// public propaty name  :  SalesSlipDtlNum
        /// <summary>売上明細通番（同時）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上明細通番（同時）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesSlipDtlNum
        {
            get { return _salesSlipDtlNum; }
            set { _salesSlipDtlNum = value; }
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

        /// public propaty name  :  SectionGuideNm
        /// <summary>拠点ガイド名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点ガイド名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SectionGuideNm
        {
            get { return _sectionGuideNm; }
            set { _sectionGuideNm = value; }
        }

        /// public propaty name  :  SupplierSlipNo
        /// <summary>仕入伝票番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入伝票番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SupplierSlipNo
        {
            get { return _supplierSlipNo; }
            set { _supplierSlipNo = value; }
        }

        /// public propaty name  :  StockTtlPricTaxExc
        /// <summary>伝票金額（税抜）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票金額（税抜）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 StockTtlPricTaxExc
        {
            get { return _stockTtlPricTaxExc; }
            set { _stockTtlPricTaxExc = value; }
        }

        /// public propaty name  :  StockTtlPricTaxInc
        /// <summary>伝票金額（税込）プロパティ</summary>
        /// <value>0:黒伝,1:赤伝,2:黒伝</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票金額（税込）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 StockTtlPricTaxInc
        {
            get { return _stockTtlPricTaxInc; }
            set { _stockTtlPricTaxInc = value; }
        }

        /// public propaty name  :  InputDay
        /// <summary>入力日プロパティ</summary>
        /// <value>YYYYMMDD　（更新年月日）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入力日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime InputDay
        {
            get { return _inputDay; }
            set { _inputDay = value; }
        }

        /// public propaty name  :  StockDate
        /// <summary>仕入日プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime StockDate
        {
            get { return _stockDate; }
            set { _stockDate = value; }
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

        /// public propaty name  :  DtlConsTax
        /// <summary>伝票消費税額プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票消費税額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 DtlConsTax
        {
            get { return _DtlConsTax; }
            set { _DtlConsTax = value; }
        }


        /// public propaty name  :  GoodsMakerCd
        /// <summary>商品メーカーコードプロパティ</summary>
        /// <value>ﾊﾟｯｹｰｼﾞ毎にﾕｰｻﾞｰ登録範囲が異なる</value>
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

        /// public propaty name  :  StockCount
        /// <summary>仕入数プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double StockCount
        {
            get { return _stockCount; }
            set { _stockCount = value; }
        }

        /// public propaty name  :  ListPriceTaxExc
        /// <summary>定価（税抜）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   定価（税抜）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double ListPriceTaxExc
        {
            get { return _ListPriceTaxExc; }
            set { _ListPriceTaxExc = value; }
        }

        /// public propaty name  :  ListPriceTaxInc
        /// <summary>定価（税込）プロパティ</summary>
        /// <value>現在の発注数は「定価（税抜）＋定価（税込）」で算出</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   定価（税込）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double ListPriceTaxInc
        {
            get { return _ListPriceTaxInc; }
            set { _ListPriceTaxInc = value; }
        }

        /// public propaty name  :  StockUnitPriceFl
        /// <summary>仕入単価（税抜，浮動）プロパティ</summary>
        /// <value>税抜き</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入単価（税抜，浮動）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double StockUnitPriceFl
        {
            get { return _stockUnitPriceFl; }
            set { _stockUnitPriceFl = value; }
        }

        /// public propaty name  :  StockUnitTaxPriceFl
        /// <summary>仕入単価（税込，浮動）プロパティ</summary>
        /// <value>税込み</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入単価（税込，浮動）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double StockUnitTaxPriceFl
        {
            get { return _stockUnitTaxPriceFl; }
            set { _stockUnitTaxPriceFl = value; }
        }

        /// public propaty name  :  StockPriceTaxExc
        /// <summary>仕入金額（税抜き）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入金額（税抜き）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 StockPriceTaxExc
        {
            get { return _stockPriceTaxExc; }
            set { _stockPriceTaxExc = value; }
        }

        /// public propaty name  :  StockPriceTaxInc
        /// <summary>仕入金額（税込み）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入金額（税込み）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 StockPriceTaxInc
        {
            get { return _stockPriceTaxInc; }
            set { _stockPriceTaxInc = value; }
        }

        /// public propaty name  :  TaxationCode
        /// <summary>課税区分プロパティ</summary>
        /// <value>0:課税,1:非課税,2:課税（内税）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   課税区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 TaxationCode
        {
            get { return _taxationCode; }
            set { _taxationCode = value; }
        }

        /// public propaty name  :  SupplierSlipNote1
        /// <summary>仕入伝票備考1プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入伝票備考1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SupplierSlipNote1
        {
            get { return _supplierSlipNote1; }
            set { _supplierSlipNote1 = value; }
        }

        /// public propaty name  :  SuppCTaxLayCd
        /// <summary>仕入先消費税転嫁方式コードプロパティ</summary>
        /// <value>0:伝票単位1:明細単位2:支払親 3:支払子 9:非課税</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先消費税転嫁方式コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SuppCTaxLayCd
        {
            get { return _suppCTaxLayCd; }
            set { _suppCTaxLayCd = value; }
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

        /// public propaty name  :  BLGoodsFullName
        /// <summary>BL商品コード名称（全角）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL商品コード名称（全角）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string BLGoodsFullName
        {
            get { return _bLGoodsFullName; }
            set { _bLGoodsFullName = value; }
        }

        /// public propaty name  :  SlpConsTax
        /// <summary>明細消費税額プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   明細消費税額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SlpConsTax
        {
            get { return _SlpConsTax; }
            set { _SlpConsTax = value; }
        }

        /// <summary>
        /// 仕入返品予定一覧表抽出結果クラスワークワークコンストラクタ
        /// </summary>
        /// <returns>StockRetPlnListクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockRetPlnListクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public StockRetPlnList()
        {
        }
    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>StockRetPlnListクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   StockRetPlnListクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class StockRetPlnList_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockRetPlnListクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is StockRetPlnList || graph is ArrayList || graph is StockRetPlnList[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(StockRetPlnList).FullName));

            if (graph != null && graph is StockRetPlnList)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.StockRetPlnList");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is StockRetPlnList[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((StockRetPlnList[])graph).Length;
            }
            else if (graph is StockRetPlnList)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	
            //拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //SectionCode
            //拠点ガイド名称
            serInfo.MemberInfo.Add(typeof(string)); //SectionGuideNm
            //仕入伝票番号
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierSlipNo
            //伝票金額（税抜）
            serInfo.MemberInfo.Add(typeof(Int64)); //StockTtlPricTaxExc
            //伝票金額（税込）
            serInfo.MemberInfo.Add(typeof(Int64)); //StockTtlPricTaxInc
            //入力日
            serInfo.MemberInfo.Add(typeof(Int32)); //InputDay
            //仕入日
            serInfo.MemberInfo.Add(typeof(Int32)); //StockDate
            //仕入先コード
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierCd
            //仕入先略称
            serInfo.MemberInfo.Add(typeof(string)); //SupplierSnm
            //伝票消費税額
            serInfo.MemberInfo.Add(typeof(Int64)); //DtlConsTax
            //商品メーカーコード
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd
            //メーカー名称
            serInfo.MemberInfo.Add(typeof(string)); //MakerName
            //商品番号
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNo
            //商品名称
            serInfo.MemberInfo.Add(typeof(string)); //GoodsName
            //仕入数
            serInfo.MemberInfo.Add(typeof(Double)); //StockCount
            //定価（税抜）
            serInfo.MemberInfo.Add(typeof(Double)); //ListPriceTaxExc
            //定価（税込）
            serInfo.MemberInfo.Add(typeof(Double)); //ListPriceTaxInc
            //仕入単価（税抜，浮動）
            serInfo.MemberInfo.Add(typeof(Double)); //StockUnitPriceFl
            //仕入単価（税込，浮動）
            serInfo.MemberInfo.Add(typeof(Double)); //StockUnitTaxPriceFl
            //仕入金額（税抜き）
            serInfo.MemberInfo.Add(typeof(Int64)); //StockPriceTaxExc
            //仕入金額（税込み）
            serInfo.MemberInfo.Add(typeof(Int64)); //StockPriceTaxInc
            //課税区分
            serInfo.MemberInfo.Add(typeof(Int32)); //TaxationCode
            //仕入伝票備考1
            serInfo.MemberInfo.Add(typeof(string)); //SupplierSlipNote1
            //仕入先消費税転嫁方式コード
            serInfo.MemberInfo.Add(typeof(Int32)); //SuppCTaxLayCd
            //BL商品コード
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGoodsCode
            //BL商品コード名称（全角）
            serInfo.MemberInfo.Add(typeof(string)); //BLGoodsFullName
            //明細消費税額
            serInfo.MemberInfo.Add(typeof(Int64)); //SlpConsTax
            //論理削除区分(仕入データ)
            serInfo.MemberInfo.Add(typeof(Int32)); //SlpLogDelCd
            //論理削除区分(仕入明細データ)
            serInfo.MemberInfo.Add(typeof(Int32)); //DtlLogDelCd
            //売上明細通番（同時）
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesSlipDtlNum
            //伝票区分
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierSlipCd

            serInfo.Serialize(writer, serInfo);
            if (graph is StockRetPlnList)
            {
                StockRetPlnList temp = (StockRetPlnList)graph;

                SetStockRetPlnList(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is StockRetPlnList[])
                {
                    lst = new ArrayList();
                    lst.AddRange((StockRetPlnList[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (StockRetPlnList temp in lst)
                {
                    SetStockRetPlnList(writer, temp);
                }
            }
        }

        /// <summary>
        /// StockRetPlnListメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 31;
        /// <summary>
        ///  StockRetPlnListインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockRetPlnListのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetStockRetPlnList(System.IO.BinaryWriter writer, StockRetPlnList temp)
        {
            //拠点コード
            writer.Write(temp.SectionCode);
            //拠点ガイド名称
            writer.Write(temp.SectionGuideNm);
            //仕入伝票番号
            writer.Write(temp.SupplierSlipNo);
            //伝票金額（税抜）
            writer.Write(temp.StockTtlPricTaxExc);
            //伝票金額（税込）
            writer.Write(temp.StockTtlPricTaxInc);
            //入力日
            writer.Write((Int64)temp.InputDay.Ticks);
            //仕入日
            writer.Write((Int64)temp.StockDate.Ticks);
            //仕入先コード
            writer.Write(temp.SupplierCd);
            //仕入先略称
            writer.Write(temp.SupplierSnm);
            //伝票消費税額
            writer.Write(temp.DtlConsTax);
            //商品メーカーコード
            writer.Write(temp.GoodsMakerCd);
            //メーカー名称
            writer.Write(temp.MakerName);
            //商品番号
            writer.Write(temp.GoodsNo);
            //商品名称
            writer.Write(temp.GoodsName);
            //仕入数
            writer.Write(temp.StockCount);
            //定価（税抜）
            writer.Write(temp.ListPriceTaxExc);
            //定価（税込）
            writer.Write(temp.ListPriceTaxInc);
            //仕入単価（税抜，浮動）
            writer.Write(temp.StockUnitPriceFl);
            //仕入単価（税込，浮動）
            writer.Write(temp.StockUnitTaxPriceFl);
            //仕入金額（税抜き）
            writer.Write(temp.StockPriceTaxExc);
            //仕入金額（税込み）
            writer.Write(temp.StockPriceTaxInc);
            //課税区分
            writer.Write(temp.TaxationCode);
            //仕入伝票備考1
            writer.Write(temp.SupplierSlipNote1);
            //仕入先消費税転嫁方式コード
            writer.Write(temp.SuppCTaxLayCd);
            //BL商品コード
            writer.Write(temp.BLGoodsCode);
            //BL商品コード名称（全角）
            writer.Write(temp.BLGoodsFullName);
            //明細消費税額
            writer.Write(temp.SlpConsTax);
            //論理削除区分
            writer.Write(temp.SlpLogDelCd);
            //論理削除区分
            writer.Write(temp.DtlLogDelCd);
            //売上明細通番（同時）
            writer.Write(temp.SalesSlipDtlNum);
            //伝票区分SalesSlipDtlNum
            writer.Write(temp.SupplierSlipCd);
        }

        /// <summary>
        ///  StockRetPlnListインスタンス取得
        /// </summary>
        /// <returns>StockRetPlnListクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockRetPlnListのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private StockRetPlnList GetStockRetPlnList(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            StockRetPlnList temp = new StockRetPlnList();
            //拠点コード
            temp.SectionCode = reader.ReadString();
            //拠点ガイド名称
            temp.SectionGuideNm = reader.ReadString();
            //仕入伝票番号
            temp.SupplierSlipNo = reader.ReadInt32();
            //伝票金額（税抜）
            temp.StockTtlPricTaxExc = reader.ReadInt64();
            //伝票金額（税込）
            temp.StockTtlPricTaxInc = reader.ReadInt64();
            //入力日
            temp.InputDay = new DateTime(reader.ReadInt64());
            //仕入日
            temp.StockDate = new DateTime(reader.ReadInt64());
            //仕入先コード
            temp.SupplierCd = reader.ReadInt32();
            //仕入先略称
            temp.SupplierSnm = reader.ReadString();
            //伝票消費税額
            temp.DtlConsTax = reader.ReadInt64();
            //商品メーカーコード
            temp.GoodsMakerCd = reader.ReadInt32();
            //メーカー名称
            temp.MakerName = reader.ReadString();
            //商品番号
            temp.GoodsNo = reader.ReadString();
            //商品名称
            temp.GoodsName = reader.ReadString();
            //仕入数
            temp.StockCount = reader.ReadDouble();
            //定価（税抜）
            temp.ListPriceTaxExc = reader.ReadDouble();
            //定価（税込）
            temp.ListPriceTaxInc = reader.ReadDouble();
            //仕入単価（税抜，浮動）
            temp.StockUnitPriceFl = reader.ReadDouble();
            //仕入単価（税込，浮動）
            temp.StockUnitTaxPriceFl = reader.ReadDouble();
            //仕入金額（税抜き）
            temp.StockPriceTaxExc = reader.ReadInt64();
            //仕入金額（税込み）
            temp.StockPriceTaxInc = reader.ReadInt64();
            //課税区分
            temp.TaxationCode = reader.ReadInt32();
            //仕入伝票備考1
            temp.SupplierSlipNote1 = reader.ReadString();
            //仕入先消費税転嫁方式コード
            temp.SuppCTaxLayCd = reader.ReadInt32();
            //BL商品コード
            temp.BLGoodsCode = reader.ReadInt32();
            //BL商品コード名称（全角）
            temp.BLGoodsFullName = reader.ReadString();
            //明細消費税額
            temp.SlpConsTax = reader.ReadInt64();
            //論理削除区分(仕入データ)
            temp.SlpLogDelCd = reader.ReadInt32();
            //論理削除区分(仕入明細データ)
            temp.DtlLogDelCd = reader.ReadInt32();
            //売上明細通番（同時）
            temp.SalesSlipDtlNum = reader.ReadInt64();
            //伝票区分
            temp.SupplierSlipCd = reader.ReadInt32();

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
        /// <returns>StockRetPlnListクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockRetPlnListクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                StockRetPlnList temp = GetStockRetPlnList(reader, serInfo);
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
                    retValue = (StockRetPlnList[])lst.ToArray(typeof(StockRetPlnList));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}
