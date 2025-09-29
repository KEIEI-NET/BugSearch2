using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   IOWriteMASIRReadWork
    /// <summary>
    ///                      仕入データ(IOWriteMASIRRead)ワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   仕入データ(IOWriteMASIRRead)ワーク</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2007/01/29  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class IOWriteMASIRReadWork
    {
        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>仕入伝票番号</summary>
        private Int32 _supplierSlipNo;

        /// <summary>仕入形式</summary>
        /// <remarks>0:買取(仕入),1:受託</remarks>
        private Int32 _supplierFormal;

        /// <summary>仕入伝票区分</summary>
        /// <remarks>10:仕入,20:返品</remarks>
        private Int32 _supplierSlipCd;

        /// <summary>赤伝区分</summary>
        /// <remarks>0:黒伝,1:赤伝,2:元黒</remarks>
        private Int32 _debitNoteDiv;

        /// <summary>仕入商品区分</summary>
        /// <remarks>0:商品,1:商品外,2:消費税調整,3:残高調整</remarks>
        private Int32 _stockGoodsCd;

        /// <summary>仕入担当者コード</summary>
        private string _stockAgentCode = "";

        /// <summary>相手先伝票番号</summary>
        /// <remarks>仕入先伝票番号に使用する</remarks>
        private string _partySaleSlipNum = "";

        /// <summary>仕入拠点コード</summary>
        private string _stockSectionCd = "";

        /// <summary>事業者コード(開始)</summary>
        private Int32 _carrierEpCodeStart;

        /// <summary>事業者コード(終了)</summary>
        private Int32 _carrierEpCodeEnd;

        /// <summary>得意先コード(開始)</summary>
        private Int32 _customerCodeStart;

        /// <summary>得意先コード(終了)</summary>
        private Int32 _customerCodeEnd;

        /// <summary>倉庫コード(開始)</summary>
        private string _warehouseCodeStart = "";

        /// <summary>倉庫コード(終了)</summary>
        private string _warehouseCodeEnd = "";

        /// <summary>仕入日(開始)</summary>
        private DateTime _stockDateStart;

        /// <summary>仕入日(終了)</summary>
        private DateTime _stockDateEnd;

        /// <summary>仕入計上日付(開始)</summary>
        /// <remarks>仕入計上日</remarks>
        private DateTime _stockAddUpADateStart;

        /// <summary>仕入計上日付(終了)</summary>
        /// <remarks>仕入計上日</remarks>
        private DateTime _stockAddUpADateEnd;

        /// <summary>商品コード</summary>
        private string _goodsCode = "";

        /// <summary>商品電話番号1(開始)</summary>
        private string _stockTelNo1Start = "";

        /// <summary>商品電話番号1(終了)</summary>
        private string _stockTelNo1End = "";

        /// <summary>製造番号1(開始)</summary>
        private string _productNumber1Start = "";

        /// <summary>製造番号1(終了)</summary>
        private string _productNumber1End = "";


        /// public propaty name  :  EnterpriseCode
        /// <summary>企業コードプロパティ</summary>
        /// <value>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   企業コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EnterpriseCode
        {
            get { return _enterpriseCode; }
            set { _enterpriseCode = value; }
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

        /// public propaty name  :  SupplierFormal
        /// <summary>仕入形式プロパティ</summary>
        /// <value>0:買取(仕入),1:受託</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入形式プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SupplierFormal
        {
            get { return _supplierFormal; }
            set { _supplierFormal = value; }
        }

        /// public propaty name  :  SupplierSlipCd
        /// <summary>仕入伝票区分プロパティ</summary>
        /// <value>10:仕入,20:返品</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入伝票区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SupplierSlipCd
        {
            get { return _supplierSlipCd; }
            set { _supplierSlipCd = value; }
        }

        /// public propaty name  :  DebitNoteDiv
        /// <summary>赤伝区分プロパティ</summary>
        /// <value>0:黒伝,1:赤伝,2:元黒</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   赤伝区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DebitNoteDiv
        {
            get { return _debitNoteDiv; }
            set { _debitNoteDiv = value; }
        }

        /// public propaty name  :  StockGoodsCd
        /// <summary>仕入商品区分プロパティ</summary>
        /// <value>0:商品,1:商品外,2:消費税調整,3:残高調整</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入商品区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 StockGoodsCd
        {
            get { return _stockGoodsCd; }
            set { _stockGoodsCd = value; }
        }

        /// public propaty name  :  StockAgentCode
        /// <summary>仕入担当者コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入担当者コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string StockAgentCode
        {
            get { return _stockAgentCode; }
            set { _stockAgentCode = value; }
        }

        /// public propaty name  :  PartySaleSlipNum
        /// <summary>相手先伝票番号プロパティ</summary>
        /// <value>仕入先伝票番号に使用する</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   相手先伝票番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PartySaleSlipNum
        {
            get { return _partySaleSlipNum; }
            set { _partySaleSlipNum = value; }
        }

        /// public propaty name  :  StockSectionCd
        /// <summary>仕入拠点コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string StockSectionCd
        {
            get { return _stockSectionCd; }
            set { _stockSectionCd = value; }
        }

        /// public propaty name  :  CarrierEpCodeStart
        /// <summary>事業者コード(開始)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   事業者コード(開始)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CarrierEpCodeStart
        {
            get { return _carrierEpCodeStart; }
            set { _carrierEpCodeStart = value; }
        }

        /// public propaty name  :  CarrierEpCodeEnd
        /// <summary>事業者コード(終了)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   事業者コード(終了)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CarrierEpCodeEnd
        {
            get { return _carrierEpCodeEnd; }
            set { _carrierEpCodeEnd = value; }
        }

        /// public propaty name  :  CustomerCodeStart
        /// <summary>得意先コード(開始)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先コード(開始)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CustomerCodeStart
        {
            get { return _customerCodeStart; }
            set { _customerCodeStart = value; }
        }

        /// public propaty name  :  CustomerCodeEnd
        /// <summary>得意先コード(終了)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先コード(終了)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CustomerCodeEnd
        {
            get { return _customerCodeEnd; }
            set { _customerCodeEnd = value; }
        }

        /// public propaty name  :  WarehouseCodeStart
        /// <summary>倉庫コード(開始)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   倉庫コード(開始)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string WarehouseCodeStart
        {
            get { return _warehouseCodeStart; }
            set { _warehouseCodeStart = value; }
        }

        /// public propaty name  :  WarehouseCodeEnd
        /// <summary>倉庫コード(終了)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   倉庫コード(終了)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string WarehouseCodeEnd
        {
            get { return _warehouseCodeEnd; }
            set { _warehouseCodeEnd = value; }
        }

        /// public propaty name  :  StockDateStart
        /// <summary>仕入日(開始)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入日(開始)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime StockDateStart
        {
            get { return _stockDateStart; }
            set { _stockDateStart = value; }
        }

        /// public propaty name  :  StockDateEnd
        /// <summary>仕入日(終了)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入日(終了)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime StockDateEnd
        {
            get { return _stockDateEnd; }
            set { _stockDateEnd = value; }
        }

        /// public propaty name  :  StockAddUpADateStart
        /// <summary>仕入計上日付(開始)プロパティ</summary>
        /// <value>仕入計上日</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入計上日付(開始)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime StockAddUpADateStart
        {
            get { return _stockAddUpADateStart; }
            set { _stockAddUpADateStart = value; }
        }

        /// public propaty name  :  StockAddUpADateEnd
        /// <summary>仕入計上日付(終了)プロパティ</summary>
        /// <value>仕入計上日</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入計上日付(終了)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime StockAddUpADateEnd
        {
            get { return _stockAddUpADateEnd; }
            set { _stockAddUpADateEnd = value; }
        }

        /// public propaty name  :  GoodsCode
        /// <summary>商品コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsCode
        {
            get { return _goodsCode; }
            set { _goodsCode = value; }
        }

        /// public propaty name  :  StockTelNo1Start
        /// <summary>商品電話番号1(開始)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品電話番号1(開始)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string StockTelNo1Start
        {
            get { return _stockTelNo1Start; }
            set { _stockTelNo1Start = value; }
        }

        /// public propaty name  :  StockTelNo1End
        /// <summary>商品電話番号1(終了)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品電話番号1(終了)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string StockTelNo1End
        {
            get { return _stockTelNo1End; }
            set { _stockTelNo1End = value; }
        }

        /// public propaty name  :  ProductNumber1Start
        /// <summary>製造番号1(開始)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   製造番号1(開始)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ProductNumber1Start
        {
            get { return _productNumber1Start; }
            set { _productNumber1Start = value; }
        }

        /// public propaty name  :  ProductNumber1End
        /// <summary>製造番号1(終了)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   製造番号1(終了)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ProductNumber1End
        {
            get { return _productNumber1End; }
            set { _productNumber1End = value; }
        }


        /// <summary>
        /// 伝票検索条件パラメータクラスワークコンストラクタ
        /// </summary>
        /// <returns>IOWriteMASIRReadWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   IOWriteMASIRReadWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public IOWriteMASIRReadWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>IOWriteMASIRReadWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   IOWriteMASIRReadWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class IOWriteMASIRReadWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   IOWriteMASIRReadWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  IOWriteMASIRReadWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is IOWriteMASIRReadWork || graph is ArrayList || graph is IOWriteMASIRReadWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(IOWriteMASIRReadWork).FullName));

            if (graph != null && graph is IOWriteMASIRReadWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.IOWriteMASIRReadWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is IOWriteMASIRReadWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((IOWriteMASIRReadWork[])graph).Length;
            }
            else if (graph is IOWriteMASIRReadWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //企業コード
            serInfo.MemberInfo.Add(typeof(string)); //EnterpriseCode
            //仕入伝票番号
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierSlipNo
            //仕入形式
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierFormal
            //仕入伝票区分
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierSlipCd
            //赤伝区分
            serInfo.MemberInfo.Add(typeof(Int32)); //DebitNoteDiv
            //仕入商品区分
            serInfo.MemberInfo.Add(typeof(Int32)); //StockGoodsCd
            //仕入担当者コード
            serInfo.MemberInfo.Add(typeof(string)); //StockAgentCode
            //相手先伝票番号
            serInfo.MemberInfo.Add(typeof(string)); //PartySaleSlipNum
            //仕入拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //StockSectionCd
            //事業者コード(開始)
            serInfo.MemberInfo.Add(typeof(Int32)); //CarrierEpCodeStart
            //事業者コード(終了)
            serInfo.MemberInfo.Add(typeof(Int32)); //CarrierEpCodeEnd
            //得意先コード(開始)
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerCodeStart
            //得意先コード(終了)
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerCodeEnd
            //倉庫コード(開始)
            serInfo.MemberInfo.Add(typeof(string)); //WarehouseCodeStart
            //倉庫コード(終了)
            serInfo.MemberInfo.Add(typeof(string)); //WarehouseCodeEnd
            //仕入日(開始)
            serInfo.MemberInfo.Add(typeof(Int32)); //StockDateStart
            //仕入日(終了)
            serInfo.MemberInfo.Add(typeof(Int32)); //StockDateEnd
            //仕入計上日付(開始)
            serInfo.MemberInfo.Add(typeof(Int32)); //StockAddUpADateStart
            //仕入計上日付(終了)
            serInfo.MemberInfo.Add(typeof(Int32)); //StockAddUpADateEnd
            //商品コード
            serInfo.MemberInfo.Add(typeof(string)); //GoodsCode
            //商品電話番号1(開始)
            serInfo.MemberInfo.Add(typeof(string)); //StockTelNo1Start
            //商品電話番号1(終了)
            serInfo.MemberInfo.Add(typeof(string)); //StockTelNo1End
            //製造番号1(開始)
            serInfo.MemberInfo.Add(typeof(string)); //ProductNumber1Start
            //製造番号1(終了)
            serInfo.MemberInfo.Add(typeof(string)); //ProductNumber1End


            serInfo.Serialize(writer, serInfo);
            if (graph is IOWriteMASIRReadWork)
            {
                IOWriteMASIRReadWork temp = (IOWriteMASIRReadWork)graph;

                SetIOWriteMASIRReadWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is IOWriteMASIRReadWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((IOWriteMASIRReadWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (IOWriteMASIRReadWork temp in lst)
                {
                    SetIOWriteMASIRReadWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// IOWriteMASIRReadWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 24;

        /// <summary>
        ///  IOWriteMASIRReadWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   IOWriteMASIRReadWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetIOWriteMASIRReadWork(System.IO.BinaryWriter writer, IOWriteMASIRReadWork temp)
        {
            //企業コード
            writer.Write(temp.EnterpriseCode);
            //仕入伝票番号
            writer.Write(temp.SupplierSlipNo);
            //仕入形式
            writer.Write(temp.SupplierFormal);
            //仕入伝票区分
            writer.Write(temp.SupplierSlipCd);
            //赤伝区分
            writer.Write(temp.DebitNoteDiv);
            //仕入商品区分
            writer.Write(temp.StockGoodsCd);
            //仕入担当者コード
            writer.Write(temp.StockAgentCode);
            //相手先伝票番号
            writer.Write(temp.PartySaleSlipNum);
            //仕入拠点コード
            writer.Write(temp.StockSectionCd);
            //事業者コード(開始)
            writer.Write(temp.CarrierEpCodeStart);
            //事業者コード(終了)
            writer.Write(temp.CarrierEpCodeEnd);
            //得意先コード(開始)
            writer.Write(temp.CustomerCodeStart);
            //得意先コード(終了)
            writer.Write(temp.CustomerCodeEnd);
            //倉庫コード(開始)
            writer.Write(temp.WarehouseCodeStart);
            //倉庫コード(終了)
            writer.Write(temp.WarehouseCodeEnd);
            //仕入日(開始)
            writer.Write((Int64)temp.StockDateStart.Ticks);
            //仕入日(終了)
            writer.Write((Int64)temp.StockDateEnd.Ticks);
            //仕入計上日付(開始)
            writer.Write((Int64)temp.StockAddUpADateStart.Ticks);
            //仕入計上日付(終了)
            writer.Write((Int64)temp.StockAddUpADateEnd.Ticks);
            //商品コード
            writer.Write(temp.GoodsCode);
            //商品電話番号1(開始)
            writer.Write(temp.StockTelNo1Start);
            //商品電話番号1(終了)
            writer.Write(temp.StockTelNo1End);
            //製造番号1(開始)
            writer.Write(temp.ProductNumber1Start);
            //製造番号1(終了)
            writer.Write(temp.ProductNumber1End);

        }

        /// <summary>
        ///  IOWriteMASIRReadWorkインスタンス取得
        /// </summary>
        /// <returns>IOWriteMASIRReadWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   IOWriteMASIRReadWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private IOWriteMASIRReadWork GetIOWriteMASIRReadWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            IOWriteMASIRReadWork temp = new IOWriteMASIRReadWork();

            //企業コード
            temp.EnterpriseCode = reader.ReadString();
            //仕入伝票番号
            temp.SupplierSlipNo = reader.ReadInt32();
            //仕入形式
            temp.SupplierFormal = reader.ReadInt32();
            //仕入伝票区分
            temp.SupplierSlipCd = reader.ReadInt32();
            //赤伝区分
            temp.DebitNoteDiv = reader.ReadInt32();
            //仕入商品区分
            temp.StockGoodsCd = reader.ReadInt32();
            //仕入担当者コード
            temp.StockAgentCode = reader.ReadString();
            //相手先伝票番号
            temp.PartySaleSlipNum = reader.ReadString();
            //仕入拠点コード
            temp.StockSectionCd = reader.ReadString();
            //事業者コード(開始)
            temp.CarrierEpCodeStart = reader.ReadInt32();
            //事業者コード(終了)
            temp.CarrierEpCodeEnd = reader.ReadInt32();
            //得意先コード(開始)
            temp.CustomerCodeStart = reader.ReadInt32();
            //得意先コード(終了)
            temp.CustomerCodeEnd = reader.ReadInt32();
            //倉庫コード(開始)
            temp.WarehouseCodeStart = reader.ReadString();
            //倉庫コード(終了)
            temp.WarehouseCodeEnd = reader.ReadString();
            //仕入日(開始)
            temp.StockDateStart = new DateTime(reader.ReadInt64());
            //仕入日(終了)
            temp.StockDateEnd = new DateTime(reader.ReadInt64());
            //仕入計上日付(開始)
            temp.StockAddUpADateStart = new DateTime(reader.ReadInt64());
            //仕入計上日付(終了)
            temp.StockAddUpADateEnd = new DateTime(reader.ReadInt64());
            //商品コード
            temp.GoodsCode = reader.ReadString();
            //商品電話番号1(開始)
            temp.StockTelNo1Start = reader.ReadString();
            //商品電話番号1(終了)
            temp.StockTelNo1End = reader.ReadString();
            //製造番号1(開始)
            temp.ProductNumber1Start = reader.ReadString();
            //製造番号1(終了)
            temp.ProductNumber1End = reader.ReadString();


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
        /// <returns>IOWriteMASIRReadWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   IOWriteMASIRReadWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                IOWriteMASIRReadWork temp = GetIOWriteMASIRReadWork(reader, serInfo);
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
                    retValue = (IOWriteMASIRReadWork[])lst.ToArray(typeof(IOWriteMASIRReadWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }


}
