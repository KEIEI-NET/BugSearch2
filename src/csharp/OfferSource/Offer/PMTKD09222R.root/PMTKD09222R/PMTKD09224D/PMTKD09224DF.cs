using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   PrmPrtBrcdWork
    /// <summary>
    ///                      優良部品バーコード
    /// </summary>
    /// <remarks>
    /// <br>note             :   優良部品バーコードワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2006/11/22</br>
    /// <br>Genarated Date   :   2008/09/09  (CSharp File Generated Date)</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class PrmPrtBrcdWork
    {
        /// <summary>提供日付</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _offerDate;

        /// <summary>部品メーカーコード</summary>
        /// <remarks>自動車ﾒｰｶｰ</remarks>
        private Int32 _partsMakerCode;

        /// <summary>BLコード</summary>
        /// <remarks></remarks>
        private Int32 _tbsPartsCode;

        /// <summary>優良品番(－付き品番)</summary>
        /// <remarks>ハイフン付き</remarks>
        private string _primePartsNoWithH = "";

        /// <summary>部品バーコード種別</summary>
        /// <remarks>バーコード種別として使用</remarks>
        private Int16 _primePrtsBarCdKndDiv;

        /// <summary>部品バーコード情報</summary>
        private string _primePartsBarCode = "";

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

        /// public propaty name  :  PartsMakerCode
        /// <summary>部品メーカーコードプロパティ</summary>
        /// <value>自動車ﾒｰｶｰ</value>
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

        /// public propaty name  :  TbsPartsCode
        /// <summary>BLコードプロパティ</summary>
        /// <value></value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BLコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 TbsPartsCode
        {
            get { return _tbsPartsCode; }
            set { _tbsPartsCode = value; }
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

        /// public propaty name  :  PrimePrtsBarCdKndDiv
        /// <summary>部品バーコード種別プロパティ</summary>
        /// <value>部品バーコード種別として使用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   部品バーコード種別プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int16 PrimePrtsBarCdKndDiv
        {
            get { return _primePrtsBarCdKndDiv; }
            set { _primePrtsBarCdKndDiv = value; }
        }

        /// public propaty name  :  PrimePartsBarCode
        /// <summary>部品バーコード情報プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   部品バーコード情報プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PrimePartsBarCode
        {
            get { return _primePartsBarCode; }
            set { _primePartsBarCode = value; }
        }

        /// <summary>
        /// 優良部品バーコードワークコンストラクタ
        /// </summary>
        /// <returns>PrmPrtBrcdWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PrmPrtBrcdWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public PrmPrtBrcdWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>PrmPrtBrcdWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   PrmPrtBrcdWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class PrmPrtBrcdWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   PrmPrtBrcdWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  PrmPrtBrcdWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is PrmPrtBrcdWork || graph is ArrayList || graph is PrmPrtBrcdWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(PrmPrtBrcdWork).FullName));

            if (graph != null && graph is PrmPrtBrcdWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.PrmPrtBrcdWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is PrmPrtBrcdWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((PrmPrtBrcdWork[])graph).Length;
            }
            else if (graph is PrmPrtBrcdWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //提供日付
            serInfo.MemberInfo.Add(typeof(Int32));	//OfferDate
            //部品メーカーコード
            serInfo.MemberInfo.Add(typeof(Int32));	//PartsMakerCode
            //BLコード
            serInfo.MemberInfo.Add(typeof(Int32));	//TbsPartsCode
            //優良品番(－付き品番)
            serInfo.MemberInfo.Add(typeof(string));	//PrimePartsNoWithH
            //部品バーコード種別
            serInfo.MemberInfo.Add(typeof(Int16));	//PrimePrtsBarCdKndDiv
            //部品バーコード情報
            serInfo.MemberInfo.Add(typeof(string));	//PrimePartsBarCode

            serInfo.Serialize(writer, serInfo);
            if (graph is PrmPrtBrcdWork)
            {
                PrmPrtBrcdWork temp = (PrmPrtBrcdWork)graph;

                SetPrmPrtBrcdWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is PrmPrtBrcdWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((PrmPrtBrcdWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (PrmPrtBrcdWork temp in lst)
                {
                    SetPrmPrtBrcdWork(writer, temp);
                }
            }
        }

        /// <summary>
        /// PrmPrtBrcdWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 6;

        /// <summary>
        ///  PrmPrtBrcdWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   PrmPrtBrcdWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetPrmPrtBrcdWork(System.IO.BinaryWriter writer, PrmPrtBrcdWork temp)
        {
            //提供日付
            writer.Write(temp.OfferDate);
            //部品メーカーコード
            writer.Write(temp.PartsMakerCode);
            //BLコード
            writer.Write(temp.TbsPartsCode);
            //優良品番(－付き品番)
            writer.Write(temp.PrimePartsNoWithH);
            //部品バーコード種別
            writer.Write(temp.PrimePrtsBarCdKndDiv);
            //部品バーコード情報
            writer.Write(temp.PrimePartsBarCode);
        }

        /// <summary>
        ///  PrmPrtBrcdWorkインスタンス取得
        /// </summary>
        /// <returns>PrmPrtBrcdWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PrmPrtBrcdWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private PrmPrtBrcdWork GetPrmPrtBrcdWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            PrmPrtBrcdWork temp = new PrmPrtBrcdWork();

            //提供日付
            temp.OfferDate = reader.ReadInt32();
            //部品メーカーコード
            temp.PartsMakerCode = reader.ReadInt32();
            //BLコード
            temp.TbsPartsCode = reader.ReadInt32();
            //優良品番(－付き品番)
            temp.PrimePartsNoWithH = reader.ReadString();
            //部品属性
            temp.PrimePrtsBarCdKndDiv = reader.ReadInt16();
            //優良部品イラストコード
            temp.PrimePartsBarCode = reader.ReadString();

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
        /// <returns>PrmPrtBrcdWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PrmPrtBrcdWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                PrmPrtBrcdWork temp = GetPrmPrtBrcdWork(reader, serInfo);
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
                    retValue = (PrmPrtBrcdWork[])lst.ToArray(typeof(PrmPrtBrcdWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

}
