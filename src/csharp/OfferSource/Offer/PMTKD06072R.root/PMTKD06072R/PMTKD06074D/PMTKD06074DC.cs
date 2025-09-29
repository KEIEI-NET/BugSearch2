using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   TBOSearchPriceRetWork
    /// <summary>
    ///                      提供車輌情報結合価格抽出結果クラスワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   提供車輌情報結合価格抽出結果クラスワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :    </br>
    /// <br>Genarated Date   :   2008/06/11  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class TBOSearchPriceRetWork
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
        /// 提供車輌情報結合価格抽出結果クラスワークコンストラクタ
        /// </summary>
        /// <returns>TBOSearchPriceRetWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   TBOSearchPriceRetWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public TBOSearchPriceRetWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>TBOSearchPriceRetWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   TBOSearchPriceRetWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class TBOSearchPriceRetWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   TBOSearchPriceRetWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  TBOSearchPriceRetWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is TBOSearchPriceRetWork || graph is ArrayList || graph is TBOSearchPriceRetWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(TBOSearchPriceRetWork).FullName));

            if (graph != null && graph is TBOSearchPriceRetWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.TBOSearchPriceRetWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is TBOSearchPriceRetWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((TBOSearchPriceRetWork[])graph).Length;
            }
            else if (graph is TBOSearchPriceRetWork)
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
            if (graph is TBOSearchPriceRetWork)
            {
                TBOSearchPriceRetWork temp = (TBOSearchPriceRetWork)graph;

                SetTBOSearchPriceRetWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is TBOSearchPriceRetWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((TBOSearchPriceRetWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (TBOSearchPriceRetWork temp in lst)
                {
                    SetTBOSearchPriceRetWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// TBOSearchPriceRetWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 7;

        /// <summary>
        ///  TBOSearchPriceRetWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   TBOSearchPriceRetWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetTBOSearchPriceRetWork(System.IO.BinaryWriter writer, TBOSearchPriceRetWork temp)
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
        ///  TBOSearchPriceRetWorkインスタンス取得
        /// </summary>
        /// <returns>TBOSearchPriceRetWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   TBOSearchPriceRetWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private TBOSearchPriceRetWork GetTBOSearchPriceRetWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            TBOSearchPriceRetWork temp = new TBOSearchPriceRetWork();

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
        /// <returns>TBOSearchPriceRetWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   TBOSearchPriceRetWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                TBOSearchPriceRetWork temp = GetTBOSearchPriceRetWork(reader, serInfo);
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
                    retValue = (TBOSearchPriceRetWork[])lst.ToArray(typeof(TBOSearchPriceRetWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

}
