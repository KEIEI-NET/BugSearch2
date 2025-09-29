using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   PMakerNmWork
    /// <summary>
    ///                      部品メーカー名称（提供）ワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   部品メーカー名称（提供）ワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2005/03/07</br>
    /// <br>Genarated Date   :   2008/06/03  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class PMakerNmWork : IFileHeaderOffer2
    {
        /// <summary>提供日付</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _offerDate;

        /// <summary>部品メーカーコード</summary>
        private Int32 _partsMakerCode;

        /// <summary>部品メーカー名称（全角）</summary>
        private string _partsMakerFullName = "";

        /// <summary>部品メーカー名称（半角）</summary>
        private string _partsMakerHalfName = "";


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

        /// public propaty name  :  PartsMakerFullName
        /// <summary>部品メーカー名称（全角）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   部品メーカー名称（全角）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PartsMakerFullName
        {
            get { return _partsMakerFullName; }
            set { _partsMakerFullName = value; }
        }

        /// public propaty name  :  PartsMakerHalfName
        /// <summary>部品メーカー名称（半角）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   部品メーカー名称（半角）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PartsMakerHalfName
        {
            get { return _partsMakerHalfName; }
            set { _partsMakerHalfName = value; }
        }


        /// <summary>
        /// 部品メーカー名称（提供）ワークコンストラクタ
        /// </summary>
        /// <returns>PMakerNmWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PMakerNmWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public PMakerNmWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>PMakerNmWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   PMakerNmWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class PMakerNmWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   PMakerNmWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  PMakerNmWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is PMakerNmWork || graph is ArrayList || graph is PMakerNmWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(PMakerNmWork).FullName));

            if (graph != null && graph is PMakerNmWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.PMakerNmWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is PMakerNmWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((PMakerNmWork[])graph).Length;
            }
            else if (graph is PMakerNmWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //提供日付
            serInfo.MemberInfo.Add(typeof(Int32)); //OfferDate
            //部品メーカーコード
            serInfo.MemberInfo.Add(typeof(Int32)); //PartsMakerCode
            //部品メーカー名称（全角）
            serInfo.MemberInfo.Add(typeof(string)); //PartsMakerFullName
            //部品メーカー名称（半角）
            serInfo.MemberInfo.Add(typeof(string)); //PartsMakerHalfName


            serInfo.Serialize(writer, serInfo);
            if (graph is PMakerNmWork)
            {
                PMakerNmWork temp = (PMakerNmWork)graph;

                SetPMakerNmWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is PMakerNmWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((PMakerNmWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (PMakerNmWork temp in lst)
                {
                    SetPMakerNmWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// PMakerNmWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 4;

        /// <summary>
        ///  PMakerNmWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   PMakerNmWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetPMakerNmWork(System.IO.BinaryWriter writer, PMakerNmWork temp)
        {
            //提供日付
            writer.Write(temp.OfferDate);
            //部品メーカーコード
            writer.Write(temp.PartsMakerCode);
            //部品メーカー名称（全角）
            writer.Write(temp.PartsMakerFullName);
            //部品メーカー名称（半角）
            writer.Write(temp.PartsMakerHalfName);

        }

        /// <summary>
        ///  PMakerNmWorkインスタンス取得
        /// </summary>
        /// <returns>PMakerNmWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PMakerNmWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private PMakerNmWork GetPMakerNmWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            PMakerNmWork temp = new PMakerNmWork();

            //提供日付
            temp.OfferDate = reader.ReadInt32();
            //部品メーカーコード
            temp.PartsMakerCode = reader.ReadInt32();
            //部品メーカー名称（全角）
            temp.PartsMakerFullName = reader.ReadString();
            //部品メーカー名称（半角）
            temp.PartsMakerHalfName = reader.ReadString();


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
        /// <returns>PMakerNmWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PMakerNmWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                PMakerNmWork temp = GetPMakerNmWork(reader, serInfo);
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
                    retValue = (PMakerNmWork[])lst.ToArray(typeof(PMakerNmWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

}
