using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;


namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   OfferJoinPriceRetWork
    /// <summary>
    ///                      提供結合結果価格クラスワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   提供結合結果価格クラスワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :    </br>
    /// <br>Genarated Date   :   2008/06/09  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class OfferJoinPriceRetWork
    {
        /// <summary>提供日付</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _offerDate;

        /// <summary>優良設定詳細コード１</summary>
        /// <remarks>セレクトコード</remarks>
        private Int32 _prmSetDtlNo1;

        /// <summary>部品メーカーコード</summary>
        private Int32 _partsMakerCd;

        /// <summary>優良品番(－付き品番)</summary>
        /// <remarks>ハイフン付き</remarks>
        private string _primePartsNoWithH = "";

        /// <summary>価格開始日</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _priceStartDate;

        /// <summary>新価格</summary>
        private Double _newPrice;

        /// <summary>オープン価格区分</summary>
        /// <remarks>0:通常／1:オープン価格</remarks>
        private Int32 _openPriceDiv;


        /// public propaty name  :  OfferDate
        /// <summary>提供日付プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   提供日付プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime OfferDate
        {
            get { return _offerDate; }
            set { _offerDate = value; }
        }

        /// public propaty name  :  PrmSetDtlNo1
        /// <summary>優良設定詳細コード１プロパティ</summary>
        /// <value>セレクトコード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   優良設定詳細コード１プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PrmSetDtlNo1
        {
            get { return _prmSetDtlNo1; }
            set { _prmSetDtlNo1 = value; }
        }

        /// public propaty name  :  PartsMakerCd
        /// <summary>部品メーカーコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   部品メーカーコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PartsMakerCd
        {
            get { return _partsMakerCd; }
            set { _partsMakerCd = value; }
        }

        /// public propaty name  :  PrimePartsNoWithH
        /// <summary>優良品番(－付き品番)プロパティ</summary>
        /// <value>ハイフン付き</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   優良品番(－付き品番)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PrimePartsNoWithH
        {
            get { return _primePartsNoWithH; }
            set { _primePartsNoWithH = value; }
        }

        /// public propaty name  :  PriceStartDate
        /// <summary>価格開始日プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   価格開始日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime PriceStartDate
        {
            get { return _priceStartDate; }
            set { _priceStartDate = value; }
        }

        /// public propaty name  :  NewPrice
        /// <summary>新価格プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   新価格プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double NewPrice
        {
            get { return _newPrice; }
            set { _newPrice = value; }
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


        /// <summary>
        /// 提供結合結果価格クラスワークコンストラクタ
        /// </summary>
        /// <returns>OfferJoinPriceRetWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   OfferJoinPriceRetWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public OfferJoinPriceRetWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>OfferJoinPriceRetWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   OfferJoinPriceRetWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class OfferJoinPriceRetWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   OfferJoinPriceRetWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  OfferJoinPriceRetWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is OfferJoinPriceRetWork || graph is ArrayList || graph is OfferJoinPriceRetWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(OfferJoinPriceRetWork).FullName));

            if (graph != null && graph is OfferJoinPriceRetWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.OfferJoinPriceRetWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is OfferJoinPriceRetWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((OfferJoinPriceRetWork[])graph).Length;
            }
            else if (graph is OfferJoinPriceRetWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //提供日付
            serInfo.MemberInfo.Add(typeof(Int64)); //OfferDate
            //優良設定詳細コード１
            serInfo.MemberInfo.Add(typeof(Int32)); //PrmSetDtlNo1
            //部品メーカーコード
            serInfo.MemberInfo.Add(typeof(Int32)); //PartsMakerCd
            //優良品番(－付き品番)
            serInfo.MemberInfo.Add(typeof(string)); //PrimePartsNoWithH
            //価格開始日
            serInfo.MemberInfo.Add(typeof(Int64)); //PriceStartDate
            //新価格
            serInfo.MemberInfo.Add(typeof(Double)); //NewPrice
            //オープン価格区分
            serInfo.MemberInfo.Add(typeof(Int32)); //OpenPriceDiv


            serInfo.Serialize(writer, serInfo);
            if (graph is OfferJoinPriceRetWork)
            {
                OfferJoinPriceRetWork temp = (OfferJoinPriceRetWork)graph;

                SetOfferJoinPriceRetWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is OfferJoinPriceRetWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((OfferJoinPriceRetWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (OfferJoinPriceRetWork temp in lst)
                {
                    SetOfferJoinPriceRetWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// OfferJoinPriceRetWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 7;

        /// <summary>
        ///  OfferJoinPriceRetWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   OfferJoinPriceRetWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetOfferJoinPriceRetWork(System.IO.BinaryWriter writer, OfferJoinPriceRetWork temp)
        {
            //提供日付
            writer.Write(temp.OfferDate.Ticks);
            //優良設定詳細コード１
            writer.Write(temp.PrmSetDtlNo1);
            //部品メーカーコード
            writer.Write(temp.PartsMakerCd);
            //優良品番(－付き品番)
            writer.Write(temp.PrimePartsNoWithH);
            //価格開始日
            writer.Write(temp.PriceStartDate.Ticks);
            //新価格
            writer.Write(temp.NewPrice);
            //オープン価格区分
            writer.Write(temp.OpenPriceDiv);

        }

        /// <summary>
        ///  OfferJoinPriceRetWorkインスタンス取得
        /// </summary>
        /// <returns>OfferJoinPriceRetWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   OfferJoinPriceRetWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private OfferJoinPriceRetWork GetOfferJoinPriceRetWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            OfferJoinPriceRetWork temp = new OfferJoinPriceRetWork();

            //提供日付
            temp.OfferDate = new DateTime(reader.ReadInt64());
            //優良設定詳細コード１
            temp.PrmSetDtlNo1 = reader.ReadInt32();
            //部品メーカーコード
            temp.PartsMakerCd = reader.ReadInt32();
            //優良品番(－付き品番)
            temp.PrimePartsNoWithH = reader.ReadString();
            //価格開始日
            temp.PriceStartDate = new DateTime(reader.ReadInt64());
            //新価格
            temp.NewPrice = reader.ReadDouble();
            //オープン価格区分
            temp.OpenPriceDiv = reader.ReadInt32();


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
        /// <returns>OfferJoinPriceRetWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   OfferJoinPriceRetWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                OfferJoinPriceRetWork temp = GetOfferJoinPriceRetWork(reader, serInfo);
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
                    retValue = (OfferJoinPriceRetWork[])lst.ToArray(typeof(OfferJoinPriceRetWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

}
