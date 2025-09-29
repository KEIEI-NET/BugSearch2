using System;
using System.Collections;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   ShipmentChangeWork
    /// <summary>
    ///                      貸出変換処理検索結果ワークワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   貸出変換処理検索結果ワークワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2008/3/28</br>
    /// <br>Genarated Date   :   2015/02/03  (CSharp File Generated Date)</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class ShipmentChangeWork
    {
        /// <summary>更新日時</summary>
        private DateTime _updateDateTime;

        /// <summary>変換後商品番号</summary>
        private string _newGoodsNo = "";

        /// <summary>メーカーコード</summary>
        private Int32 _makerCode;

        /// <summary>商品番号</summary>
        private string _oldGoodsNo = "";

        /// <summary>受注ステータス</summary>
        private Int32 _acptAnOdrStatus;

        /// <summary>売上伝票番号</summary>
        private string _salesSlipNum = "";

        /// <summary>売上行番号</summary>
        private Int32 _salesRowNo;

        /// <summary>売上明細通番</summary>
        private Int64 _salesSlipDtlNum;

        /// <summary>メーカー名称</summary>
        private string _makerName = "";

        /// <summary>商品名称</summary>
        private string _goodsName = "";

        /// <summary>BL商品コード</summary>
        private Int32 _bLGoodsCode;

        /// <summary>BL商品コード名称（全角</summary>
        private string _bLGoodsFullName = "";

        /// <summary>出荷数</summary>
        private Double _shipmentCnt;

        /// <summary>オープン価格区分</summary>
        private Int32 _openPriceDiv;

        /// <summary>定価（税抜，浮動）</summary>
        private Double _listPriceTaxExcFl;

        /// <summary>原価単価</summary>
        private Double _salesUnitCost;

        /// <summary>原価</summary>
        private Int64 _cost;

        /// <summary>売上単価（税抜，浮動）</summary>
        private Double _salesUnPrcTaxExcFl;

        /// <summary>売上金額（税抜き）</summary>
        private Int64 _salesMoneyTaxExc;

        /// <summary>仕入先コード </summary>
        private Int32 _supplierCd;

        /// <summary>得意先コード</summary>
        private Int32 _customerCode;

        /// <summary>得意先略称</summary>
        private string _customerSnm = "";

        /// <summary>倉庫コード</summary>
        private string _warehouseCode = "";

        /// <summary>倉庫名称</summary>
        private string _warehouseName = "";

        /// <summary>倉庫棚番</summary>
        private string _warehouseShelfNo = "";

        /// <summary>拠点コード</summary>
        private string _sectionCode = "";

        /// <summary>拠点ガイド名称</summary>
        private string _sectionGuideNm = "";

        /// <summary>仕入在庫数</summary>
        private Double _supplierStock;

        /// <summary>受注数</summary>
        private Double _acpOdrCount;

        /// <summary>発注数</summary>
        private Double _salesOrderCount;

        /// <summary>移動中仕入在庫数</summary>
        private Double _movingSupliStock;

        /// <summary>出荷数（未計上）</summary>
        private Double _shipmentNoAddCnt;

        /// <summary>入荷数（未計上）</summary>
        private Double _arrivalCnt;

        /// <summary>出荷可能数</summary>
        private Double _shipmentPosCnt;

        /// <summary>メッセージ</summary>
        private string _message = "";


        /// public propaty name  :  UpdateDateTime
        /// <summary>更新日時プロパティ</summary>
        /// <value>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</value>
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

        /// public propaty name  :  NewGoodsNo
        /// <summary>変換後商品番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   変換後商品番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string NewGoodsNo
        {
            get { return _newGoodsNo; }
            set { _newGoodsNo = value; }
        }

        /// public propaty name  :  MakerCode
        /// <summary>メーカーコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メーカーコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 MakerCode
        {
            get { return _makerCode; }
            set { _makerCode = value; }
        }

        /// public propaty name  :  OldGoodsNo
        /// <summary>商品番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string OldGoodsNo
        {
            get { return _oldGoodsNo; }
            set { _oldGoodsNo = value; }
        }

        /// public propaty name  :  AcptAnOdrStatus
        /// <summary>受注ステータスプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   受注ステータスプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AcptAnOdrStatus
        {
            get { return _acptAnOdrStatus; }
            set { _acptAnOdrStatus = value; }
        }

        /// public propaty name  :  SalesSlipNum
        /// <summary>売上伝票番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上伝票番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SalesSlipNum
        {
            get { return _salesSlipNum; }
            set { _salesSlipNum = value; }
        }

        /// public propaty name  :  SalesRowNo
        /// <summary>売上行番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上行番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SalesRowNo
        {
            get { return _salesRowNo; }
            set { _salesRowNo = value; }
        }

        /// public propaty name  :  SalesSlipDtlNum
        /// <summary>売上明細通番プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上明細通番プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesSlipDtlNum
        {
            get { return _salesSlipDtlNum; }
            set { _salesSlipDtlNum = value; }
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
        /// <summary>BL商品コード名称（全角プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL商品コード名称（全角プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string BLGoodsFullName
        {
            get { return _bLGoodsFullName; }
            set { _bLGoodsFullName = value; }
        }

        /// public propaty name  :  ShipmentCnt
        /// <summary>出荷数プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   出荷数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double ShipmentCnt
        {
            get { return _shipmentCnt; }
            set { _shipmentCnt = value; }
        }

        /// public propaty name  :  OpenPriceDiv
        /// <summary>オープン価格区分プロパティ</summary>
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

        /// public propaty name  :  ListPriceTaxExcFl
        /// <summary>定価（税抜，浮動）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   定価（税抜，浮動）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double ListPriceTaxExcFl
        {
            get { return _listPriceTaxExcFl; }
            set { _listPriceTaxExcFl = value; }
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

        /// public propaty name  :  Cost
        /// <summary>原価プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   原価プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 Cost
        {
            get { return _cost; }
            set { _cost = value; }
        }

        /// public propaty name  :  SalesUnPrcTaxExcFl
        /// <summary>売上単価（税抜，浮動）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上単価（税抜，浮動）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double SalesUnPrcTaxExcFl
        {
            get { return _salesUnPrcTaxExcFl; }
            set { _salesUnPrcTaxExcFl = value; }
        }

        /// public propaty name  :  SalesMoneyTaxExc
        /// <summary>売上金額（税抜き）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上金額（税抜き）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesMoneyTaxExc
        {
            get { return _salesMoneyTaxExc; }
            set { _salesMoneyTaxExc = value; }
        }

        /// public propaty name  :  SupplierCd
        /// <summary>仕入先コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先コード プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SupplierCd
        {
            get { return _supplierCd; }
            set { _supplierCd = value; }
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

        /// public propaty name  :  CustomerSnm
        /// <summary>得意先略称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先略称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CustomerSnm
        {
            get { return _customerSnm; }
            set { _customerSnm = value; }
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

        /// public propaty name  :  WarehouseName
        /// <summary>倉庫名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   倉庫名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string WarehouseName
        {
            get { return _warehouseName; }
            set { _warehouseName = value; }
        }

        /// public propaty name  :  WarehouseShelfNo
        /// <summary>倉庫棚番プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   倉庫棚番プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string WarehouseShelfNo
        {
            get { return _warehouseShelfNo; }
            set { _warehouseShelfNo = value; }
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

        /// public propaty name  :  SectionGuideNmRF
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

        /// public propaty name  :  SupplierStock
        /// <summary>仕入在庫数プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入在庫数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double SupplierStock
        {
            get { return _supplierStock; }
            set { _supplierStock = value; }
        }

        /// public propaty name  :  AcpOdrCount
        /// <summary>受注数プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   受注数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double AcpOdrCount
        {
            get { return _acpOdrCount; }
            set { _acpOdrCount = value; }
        }

        /// public propaty name  :  SalesOrderCount
        /// <summary>発注数プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   発注数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double SalesOrderCount
        {
            get { return _salesOrderCount; }
            set { _salesOrderCount = value; }
        }

        /// public propaty name  :  MovingSupliStock
        /// <summary>移動中仕入在庫数プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   移動中仕入在庫数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double MovingSupliStock
        {
            get { return _movingSupliStock; }
            set { _movingSupliStock = value; }
        }

        /// public propaty name  :  ShipmentNoAddCnt
        /// <summary>出荷数（未計上）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   出荷数（未計上）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double ShipmentNoAddCnt
        {
            get { return _shipmentNoAddCnt; }
            set { _shipmentNoAddCnt = value; }
        }

        /// public propaty name  :  ArrivalCnt
        /// <summary>入荷数（未計上）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入荷数（未計上）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double ArrivalCnt
        {
            get { return _arrivalCnt; }
            set { _arrivalCnt = value; }
        }

        /// public propaty name  :  ShipmentPosCnt
        /// <summary>出荷可能数プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   出荷可能数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double ShipmentPosCnt
        {
            get { return _shipmentPosCnt; }
            set { _shipmentPosCnt = value; }
        }

        /// public propaty name  :  Message
        /// <summary>メッセージプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メッセージプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string Message
        {
            get { return _message; }
            set { _message = value; }
        }


        /// <summary>
        /// 貸出変換処理検索結果ワークワークコンストラクタ
        /// </summary>
        /// <returns>ShipmentChangeWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   ShipmentChangeWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ShipmentChangeWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>ShipmentChangeWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   ShipmentChangeWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class ShipmentChangeWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   ShipmentChangeWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  ShipmentChangeWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is ShipmentChangeWork || graph is ArrayList || graph is ShipmentChangeWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(ShipmentChangeWork).FullName));

            if (graph != null && graph is ShipmentChangeWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.ShipmentChangeWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is ShipmentChangeWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((ShipmentChangeWork[])graph).Length;
            }
            else if (graph is ShipmentChangeWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //更新日時
            serInfo.MemberInfo.Add(typeof(Int64)); //UpdateDateTime
            //変換後商品番号
            serInfo.MemberInfo.Add(typeof(string)); //NewGoodsNo
            //メーカーコード
            serInfo.MemberInfo.Add(typeof(Int32)); //MakerCode
            //商品番号
            serInfo.MemberInfo.Add(typeof(string)); //OldGoodsNo
            //受注ステータス
            serInfo.MemberInfo.Add(typeof(Int32)); //AcptAnOdrStatus
            //売上伝票番号
            serInfo.MemberInfo.Add(typeof(string)); //SalesSlipNum
            //売上行番号
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesRowNo
            //売上明細通番
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesSlipDtlNum
            //メーカー名称
            serInfo.MemberInfo.Add(typeof(string)); //MakerName
            //商品名称
            serInfo.MemberInfo.Add(typeof(string)); //GoodsName
            //BL商品コード
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGoodsCode
            //BL商品コード名称（全角
            serInfo.MemberInfo.Add(typeof(string)); //BLGoodsFullName
            //出荷数
            serInfo.MemberInfo.Add(typeof(Double)); //ShipmentCnt
            //オープン価格区分
            serInfo.MemberInfo.Add(typeof(Int32)); //OpenPriceDiv
            //定価（税抜，浮動）
            serInfo.MemberInfo.Add(typeof(Double)); //ListPriceTaxExcFl
            //原価単価
            serInfo.MemberInfo.Add(typeof(Double)); //SalesUnitCost
            //原価
            serInfo.MemberInfo.Add(typeof(Int64)); //Cost
            //売上単価（税抜，浮動）
            serInfo.MemberInfo.Add(typeof(Double)); //SalesUnPrcTaxExcFl
            //売上金額（税抜き）
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesMoneyTaxExc
            //仕入先コード
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierCd
            //得意先コード
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerCode
            //得意先略称
            serInfo.MemberInfo.Add(typeof(string)); //CustomerSnm
            //倉庫コード
            serInfo.MemberInfo.Add(typeof(string)); //WarehouseCode
            //倉庫名称
            serInfo.MemberInfo.Add(typeof(string)); //WarehouseName
            //倉庫棚番
            serInfo.MemberInfo.Add(typeof(string)); //WarehouseShelfNo
            //拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //SectionCode
            //拠点ガイド名称
            serInfo.MemberInfo.Add(typeof(string)); //SectionGuideNm
            //仕入在庫数
            serInfo.MemberInfo.Add(typeof(Double)); //SupplierStock
            //受注数
            serInfo.MemberInfo.Add(typeof(Double)); //AcpOdrCount
            //発注数
            serInfo.MemberInfo.Add(typeof(Double)); //SalesOrderCount
            //移動中仕入在庫数
            serInfo.MemberInfo.Add(typeof(Double)); //MovingSupliStock
            //出荷数（未計上）
            serInfo.MemberInfo.Add(typeof(Double)); //ShipmentNoAddCnt
            //入荷数（未計上）
            serInfo.MemberInfo.Add(typeof(Double)); //ArrivalCnt
            //出荷可能数
            serInfo.MemberInfo.Add(typeof(Double)); //ShipmentPosCnt
            //メッセージ
            serInfo.MemberInfo.Add(typeof(string)); //Message


            serInfo.Serialize(writer, serInfo);
            if (graph is ShipmentChangeWork)
            {
                ShipmentChangeWork temp = (ShipmentChangeWork)graph;

                SetShipmentChangeWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is ShipmentChangeWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((ShipmentChangeWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (ShipmentChangeWork temp in lst)
                {
                    SetShipmentChangeWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// ShipmentChangeWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 35;

        /// <summary>
        ///  ShipmentChangeWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   ShipmentChangeWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetShipmentChangeWork(System.IO.BinaryWriter writer, ShipmentChangeWork temp)
        {
            //更新日時
            writer.Write((Int64)temp.UpdateDateTime.Ticks);
            //変換後商品番号
            writer.Write(temp.NewGoodsNo);
            //メーカーコード
            writer.Write(temp.MakerCode);
            //商品番号
            writer.Write(temp.OldGoodsNo);
            //受注ステータス
            writer.Write(temp.AcptAnOdrStatus);
            //売上伝票番号
            writer.Write(temp.SalesSlipNum);
            //売上行番号
            writer.Write(temp.SalesRowNo);
            //売上明細通番
            writer.Write(temp.SalesSlipDtlNum);
            //メーカー名称
            writer.Write(temp.MakerName);
            //商品名称
            writer.Write(temp.GoodsName);
            //BL商品コード
            writer.Write(temp.BLGoodsCode);
            //BL商品コード名称（全角
            writer.Write(temp.BLGoodsFullName);
            //出荷数
            writer.Write(temp.ShipmentCnt);
            //オープン価格区分
            writer.Write(temp.OpenPriceDiv);
            //定価（税抜，浮動）
            writer.Write(temp.ListPriceTaxExcFl);
            //原価単価
            writer.Write(temp.SalesUnitCost);
            //原価
            writer.Write(temp.Cost);
            //売上単価（税抜，浮動）
            writer.Write(temp.SalesUnPrcTaxExcFl);
            //売上金額（税抜き）
            writer.Write(temp.SalesMoneyTaxExc);
            //仕入先コード
            writer.Write(temp.SupplierCd);
            //得意先コード
            writer.Write(temp.CustomerCode);
            //得意先略称
            writer.Write(temp.CustomerSnm);
            //倉庫コード
            writer.Write(temp.WarehouseCode);
            //倉庫名称
            writer.Write(temp.WarehouseName);
            //倉庫棚番
            writer.Write(temp.WarehouseShelfNo);
            //拠点コード
            writer.Write(temp.SectionCode);
            //拠点ガイド名称
            writer.Write(temp.SectionGuideNm);
            //仕入在庫数
            writer.Write(temp.SupplierStock);
            //受注数
            writer.Write(temp.AcpOdrCount);
            //発注数
            writer.Write(temp.SalesOrderCount);
            //移動中仕入在庫数
            writer.Write(temp.MovingSupliStock);
            //出荷数（未計上）
            writer.Write(temp.ShipmentNoAddCnt);
            //入荷数（未計上）
            writer.Write(temp.ArrivalCnt);
            //出荷可能数
            writer.Write(temp.ShipmentPosCnt);
            //メッセージ
            writer.Write(temp.Message);

        }

        /// <summary>
        ///  ShipmentChangeWorkインスタンス取得
        /// </summary>
        /// <returns>ShipmentChangeWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   ShipmentChangeWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private ShipmentChangeWork GetShipmentChangeWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            ShipmentChangeWork temp = new ShipmentChangeWork();

            //更新日時
            temp.UpdateDateTime = new DateTime(reader.ReadInt64());
            //変換後商品番号
            temp.NewGoodsNo = reader.ReadString();
            //メーカーコード
            temp.MakerCode = reader.ReadInt32();
            //商品番号
            temp.OldGoodsNo = reader.ReadString();
            //受注ステータス
            temp.AcptAnOdrStatus = reader.ReadInt32();
            //売上伝票番号
            temp.SalesSlipNum = reader.ReadString();
            //売上行番号
            temp.SalesRowNo = reader.ReadInt32();
            //売上明細通番
            temp.SalesSlipDtlNum = reader.ReadInt64();
            //メーカー名称
            temp.MakerName = reader.ReadString();
            //商品名称
            temp.GoodsName = reader.ReadString();
            //BL商品コード
            temp.BLGoodsCode = reader.ReadInt32();
            //BL商品コード名称（全角
            temp.BLGoodsFullName = reader.ReadString();
            //出荷数
            temp.ShipmentCnt = reader.ReadDouble();
            //オープン価格区分
            temp.OpenPriceDiv = reader.ReadInt32();
            //定価（税抜，浮動）
            temp.ListPriceTaxExcFl = reader.ReadDouble();
            //原価単価
            temp.SalesUnitCost = reader.ReadDouble();
            //原価
            temp.Cost = reader.ReadInt64();
            //売上単価（税抜，浮動）
            temp.SalesUnPrcTaxExcFl = reader.ReadDouble();
            //売上金額（税抜き）
            temp.SalesMoneyTaxExc = reader.ReadInt64();
            //仕入先コード
            temp.SupplierCd = reader.ReadInt32();
            //得意先コード
            temp.CustomerCode = reader.ReadInt32();
            //得意先略称
            temp.CustomerSnm = reader.ReadString();
            //倉庫コード
            temp.WarehouseCode = reader.ReadString();
            //倉庫名称
            temp.WarehouseName = reader.ReadString();
            //倉庫棚番
            temp.WarehouseShelfNo = reader.ReadString();
            //拠点コード
            temp.SectionCode = reader.ReadString();
            //拠点ガイド名称
            temp.SectionGuideNm = reader.ReadString();
            //仕入在庫数
            temp.SupplierStock = reader.ReadDouble();
            //受注数
            temp.AcpOdrCount = reader.ReadDouble();
            //発注数
            temp.SalesOrderCount = reader.ReadDouble();
            //移動中仕入在庫数
            temp.MovingSupliStock = reader.ReadDouble();
            //出荷数（未計上）
            temp.ShipmentNoAddCnt = reader.ReadDouble();
            //入荷数（未計上）
            temp.ArrivalCnt = reader.ReadDouble();
            //出荷可能数
            temp.ShipmentPosCnt = reader.ReadDouble();
            //メッセージ
            temp.Message = reader.ReadString();


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
        /// <returns>ShipmentChangeWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   ShipmentChangeWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                ShipmentChangeWork temp = GetShipmentChangeWork(reader, serInfo);
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
                    retValue = (ShipmentChangeWork[])lst.ToArray(typeof(ShipmentChangeWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}
