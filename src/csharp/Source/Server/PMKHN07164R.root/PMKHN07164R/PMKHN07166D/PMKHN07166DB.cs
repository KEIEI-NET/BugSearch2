using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   GoodsExportResultWork
    /// <summary>
    ///                      商品エクスポート抽出結果クラスワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   商品エクスポート抽出結果クラスワークヘッダファイル</br>
    /// <br>Programmer       :   30517 夏野 駿希</br>
    /// <br>Date             :   2010/05/12</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class GoodsExportResultWork 
    {
        /// <summary>商品番号</summary>
        private string _goodsNo = "";

        /// <summary>商品メーカーコード</summary>
        private Int32 _goodsMakerCd;

        /// <summary>商品名称</summary>
        private string _goodsName = "";

        /// <summary>商品名称カナ</summary>
        private string _goodsNameKana = "";

        /// <summary>JANコード</summary>
        private string _jan = "";

        /// <summary>BL商品コード</summary>
        private Int32 _bLGoodsCode;

        /// <summary>商品区分</summary>
        /// <remarks>自社分類コード</remarks>
        private Int32 _enterpriseGanreCode;

        /// <summary>層別</summary>
        /// <remarks>商品掛率ランク</remarks>
        private string _goodsRateRank = "";

        /// <summary>純優区分</summary>
        /// <remarks>商品属性 0:純正 1:その他</remarks>
        private Int32 _goodsKindCode;

        /// <summary>課税区分</summary>
        /// <remarks>0:課税 1:非課税 2:課税（内税）</remarks>
        private Int32 _taxationDivCd;

        /// <summary>商品備考１</summary>
        private string _goodsNote1 = "";

        /// <summary>商品備考２</summary>
        private string _goodsNote2 = "";

        /// <summary>商品規格・特記事項</summary>
        private string _goodsSpecialNote = "";

        /// <summary>適用日</summary>
        /// <remarks>価格開始日 YYYYMMDD</remarks>
        private DateTime _priceStartDate;

        /// <summary>新適用価格</summary>
        /// <remarks>定価（浮動）</remarks>
        private Double _listPrice;

        /// <summary>オープン価格区分</summary>
        private int _openPriceDiv;

        /// <summary>仕入率</summary>
        private Double _stockRate;

        /// <summary>原価単価</summary>
        private Double _salesUnitCost;

        /// <summary>提供データ区分</summary>
        /// <remarks>0:ユーザデータ 1:提供データ</remarks>
        private Int32 _offerDataDiv;


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

        /// public propaty name  :  Jan
        /// <summary>JANコードプロパティプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品名称カナプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string Jan
        {
            get { return _jan; }
            set { _jan = value; }
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

        /// public propaty name  :  ListPrice
        /// <summary>新適用価格プロパティ</summary>
        /// <value>定価（浮動）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   新適用価格プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double ListPrice
        {
            get { return _listPrice; }
            set { _listPrice = value; }
        }

        /// public propaty name  :  OpenPriceDiv
        /// <summary>オープン価格区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   オープン価格区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public int OpenPriceDiv
        {
            get { return _openPriceDiv; }
            set { _openPriceDiv = value; }
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


        /// <summary>
        /// 商品エクスポート抽出結果クラスワークコンストラクタ
        /// </summary>
        /// <returns>GoodsExportResultWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   GoodsExportResultWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public GoodsExportResultWork()
        {
        }
    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>GoodsExportResultWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   GoodsExportResultWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   30517 夏野 駿希</br>
    /// </remarks>
    public class GoodsExportResultWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   GoodsExportResultWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   30517 夏野 駿希</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  GoodsPrintResultWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is GoodsExportResultWork || graph is ArrayList || graph is GoodsExportResultWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(GoodsExportResultWork).FullName));

            if (graph != null && graph is GoodsExportResultWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.GoodsExportResultWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is GoodsExportResultWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((GoodsExportResultWork[])graph).Length;
            }
            else if (graph is GoodsExportResultWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //商品番号
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNo
            //商品メーカーコード
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd
            //商品名称
            serInfo.MemberInfo.Add(typeof(string)); //GoodsName
            //商品名称カナ
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNameKana
            //Janコード
            serInfo.MemberInfo.Add(typeof(string)); //Jan
            //BL商品コード
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGoodsCode
            //商品区分
            serInfo.MemberInfo.Add(typeof(Int32)); //EnterpriseGanreCode
            //層別
            serInfo.MemberInfo.Add(typeof(string)); //GoodsRateRank
            //純優区分
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsKindCode
            //課税区分
            serInfo.MemberInfo.Add(typeof(Int32)); //TaxationDivCd
            //商品備考１
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNote1
            //商品備考２
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNote2
            //商品規格・特記事項
            serInfo.MemberInfo.Add(typeof(string)); //GoodsSpecialNote
            //適用日
            serInfo.MemberInfo.Add(typeof(Int32)); //PriceStartDate
            //新適用価格
            serInfo.MemberInfo.Add(typeof(Double)); //ListPrice
            //オープン価格区分
            serInfo.MemberInfo.Add(typeof(int));    //OpenPriceDiv
            //仕入率
            serInfo.MemberInfo.Add(typeof(Double)); //StockRate
            //原価単価
            serInfo.MemberInfo.Add(typeof(Double)); //SalesUnitCost
            //提供データ区分
            serInfo.MemberInfo.Add(typeof(Int32)); //OfferDataDiv


            serInfo.Serialize(writer, serInfo);
            if (graph is GoodsExportResultWork)
            {
                GoodsExportResultWork temp = (GoodsExportResultWork)graph;

                SetGoodsPrintResultWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is GoodsExportResultWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((GoodsExportResultWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (GoodsExportResultWork temp in lst)
                {
                    SetGoodsPrintResultWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// GoodsExportResultWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 19;

        /// <summary>
        ///  GoodsExportResultWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   GoodsExportResultWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   30517 夏野 駿希</br>
        /// </remarks>
        private void SetGoodsPrintResultWork(System.IO.BinaryWriter writer, GoodsExportResultWork temp)
        {
            //商品番号
            writer.Write(temp.GoodsNo);
            //商品メーカーコード
            writer.Write(temp.GoodsMakerCd);
            //商品名称
            writer.Write(temp.GoodsName);
            //商品名称カナ
            writer.Write(temp.GoodsNameKana);
            //Janコード
            writer.Write(temp.Jan);
            //BL商品コード
            writer.Write(temp.BLGoodsCode);
            //商品区分
            writer.Write(temp.EnterpriseGanreCode);
            //層別
            writer.Write(temp.GoodsRateRank);
            //純優区分
            writer.Write(temp.GoodsKindCode);
            //課税区分
            writer.Write(temp.TaxationDivCd);
            //商品備考１
            writer.Write(temp.GoodsNote1);
            //商品備考２
            writer.Write(temp.GoodsNote2);
            //商品規格・特記事項
            writer.Write(temp.GoodsSpecialNote);
            //適用日
            writer.Write((Int64)temp.PriceStartDate.Ticks);
            //新適用価格
            writer.Write(temp.ListPrice);
            //オープン価格区分
            writer.Write(temp.OpenPriceDiv);
            //仕入率
            writer.Write(temp.StockRate);
            //原価単価
            writer.Write(temp.SalesUnitCost);
            //提供データ区分
            writer.Write(temp.OfferDataDiv);

        }

        /// <summary>
        ///  GoodsExportResultWorkインスタンス取得
        /// </summary>
        /// <returns>GoodsExportResultWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   GoodsExportResultWorkのインスタンスを取得します</br>
        /// <br>Programer        :   30517 夏野 駿希</br>
        /// </remarks>
        private GoodsExportResultWork GetGoodsPrintResultWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            GoodsExportResultWork temp = new GoodsExportResultWork();

            //商品番号
            temp.GoodsNo = reader.ReadString();
            //商品メーカーコード
            temp.GoodsMakerCd = reader.ReadInt32();
            //商品名称
            temp.GoodsName = reader.ReadString();
            //商品名称カナ
            temp.GoodsNameKana = reader.ReadString();
            //Janコード
            temp.Jan = reader.ReadString();
            //BL商品コード
            temp.BLGoodsCode = reader.ReadInt32();
            //商品区分
            temp.EnterpriseGanreCode = reader.ReadInt32();
            //層別
            temp.GoodsRateRank = reader.ReadString();
            //純優区分
            temp.GoodsKindCode = reader.ReadInt32();
            //課税区分
            temp.TaxationDivCd = reader.ReadInt32();
            //商品備考１
            temp.GoodsNote1 = reader.ReadString();
            //商品備考２
            temp.GoodsNote2 = reader.ReadString();
            //商品規格・特記事項
            temp.GoodsSpecialNote = reader.ReadString();
            //適用日
            temp.PriceStartDate = new DateTime(reader.ReadInt64());
            //新適用価格
            temp.ListPrice = reader.ReadDouble();
            //オープン価格区分
            temp.OpenPriceDiv = reader.ReadInt32();
            //仕入率
            temp.StockRate = reader.ReadDouble();
            //原価単価
            temp.SalesUnitCost = reader.ReadDouble();
            //提供データ区分
            temp.OfferDataDiv = reader.ReadInt32();


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
        /// <returns>GoodsExportResultWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   GoodsExportResultWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   30517 夏野 駿希</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                GoodsExportResultWork temp = GetGoodsPrintResultWork(reader, serInfo);
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
                    retValue = (GoodsExportResultWork[])lst.ToArray(typeof(GoodsExportResultWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}
