using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   PartsLayerStPmWork
    /// <summary>
    ///                      ＢＬコードワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   ＢＬコードワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2013/02/18</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class PartsLayerStPmWork
    {
        /// <summary>提供日付</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _offerDate;

        /// <summary>層別コード</summary>
        private string _partsLayerCd = "";

        /// <summary>BLコード</summary>
        private Int32 _blGoodsCode;

        /// <summary>BLコード枝番</summary>
        /// <remarks>※未使用項目（レイアウトには入れておく）</remarks>
        private Int32 _blGoodsCdDerivedNo;

        /// <summary>部品メーカーコード</summary>
        private Int32 _partsMakerCode;

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

        /// public propaty name  :  PartsLayerCd
        /// <summary>層別コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   層別コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PartsLayerCd
        {
            get { return _partsLayerCd; }
            set { _partsLayerCd = value; }
        }

        /// public propaty name  :  BLGoodsCode
        /// <summary>BLコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BLコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BLGoodsCode
        {
            get { return _blGoodsCode; }
            set { _blGoodsCode = value; }
        }

        /// public propaty name  :  BLGoodsCdDerivedNo
        /// <summary>BLコード枝番プロパティ</summary>
        /// <value>※未使用項目（レイアウトには入れておく）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BLコード枝番プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BLGoodsCdDerivedNo
        {
            get { return _blGoodsCdDerivedNo; }
            set { _blGoodsCdDerivedNo = value; }
        }

        /// public propaty name  :  PartsMakerCode
        /// <summary>部品メーカーコード</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   部品メーカーコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PartsMakerCode
        {
            get { return _partsMakerCode; }
            set { _partsMakerCode = value; }
        }

        /// <summary>
        /// ＢＬコードワークコンストラクタ
        /// </summary>
        /// <returns>PartsLayerStPmWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PartsLayerStPmWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public PartsLayerStPmWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>PartsLayerStPmWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   PartsLayerStPmWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class PartsLayerStPmWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   PartsLayerStPmWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  PartsLayerStPmWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is PartsLayerStPmWork || graph is ArrayList || graph is PartsLayerStPmWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(PartsLayerStPmWork).FullName));

            if (graph != null && graph is PartsLayerStPmWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.PartsLayerStPmWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is PartsLayerStPmWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((PartsLayerStPmWork[])graph).Length;
            }
            else if (graph is PartsLayerStPmWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //提供日付
            serInfo.MemberInfo.Add(typeof(Int32)); //OfferDate
            //層別コード
            serInfo.MemberInfo.Add(typeof(string)); //PartsLayerCd
            //BLコード
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGoodsCode
            //BLコード枝番
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGoodsCdDerivedNo
            //部品メーカーコード
            serInfo.MemberInfo.Add(typeof(Int32)); //PartsMakerCode


            serInfo.Serialize(writer, serInfo);
            if (graph is PartsLayerStPmWork)
            {
                PartsLayerStPmWork temp = (PartsLayerStPmWork)graph;

                SetPartsLayerStPmWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is PartsLayerStPmWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((PartsLayerStPmWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (PartsLayerStPmWork temp in lst)
                {
                    SetPartsLayerStPmWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// PartsLayerStPmWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 5;

        /// <summary>
        ///  PartsLayerStPmWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   PartsLayerStPmWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetPartsLayerStPmWork(System.IO.BinaryWriter writer, PartsLayerStPmWork temp)
        {
            //提供日付
            writer.Write(temp.OfferDate);
            //層別コード
            writer.Write(temp.PartsLayerCd);
            //BLコード
            writer.Write(temp.BLGoodsCode);
            //BLコード枝番
            writer.Write(temp.BLGoodsCdDerivedNo);
            //部品メーカーコード
            writer.Write(temp.PartsMakerCode);

        }

        /// <summary>
        ///  PartsLayerStPmWorkインスタンス取得
        /// </summary>
        /// <returns>PartsLayerStPmWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PartsLayerStPmWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private PartsLayerStPmWork GetPartsLayerStPmWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            PartsLayerStPmWork temp = new PartsLayerStPmWork();

            //提供日付
            temp.OfferDate = reader.ReadInt32();
            //層別コード
            temp.PartsLayerCd = reader.ReadString();
            //BLコード
            temp.BLGoodsCode = reader.ReadInt32();
            //BLコード枝番
            temp.BLGoodsCdDerivedNo = reader.ReadInt32();
            //部品メーカーコード
            temp.PartsMakerCode = reader.ReadInt32();


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
        /// <returns>PartsLayerStPmWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PartsLayerStPmWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                PartsLayerStPmWork temp = GetPartsLayerStPmWork(reader, serInfo);
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
                    retValue = (PartsLayerStPmWork[])lst.ToArray(typeof(PartsLayerStPmWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}
