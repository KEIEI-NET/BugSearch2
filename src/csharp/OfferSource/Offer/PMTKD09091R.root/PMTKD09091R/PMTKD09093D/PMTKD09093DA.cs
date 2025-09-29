using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   OfrSupplierWork
    /// <summary>
    ///                      仕入先（提供）ワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   仕入先（提供）ワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2007/1/29</br>
    /// <br>Genarated Date   :   2008/10/29  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2008/4/25  杉村</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class OfrSupplierWork
    {
        /// <summary>提供日付</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _offerDate;

        /// <summary>仕入先コード</summary>
        private Int32 _supplierCd;

        /// <summary>仕入先名1</summary>
        private string _supplierNm1 = "";

        /// <summary>仕入先カナ</summary>
        private string _supplierKana = "";

        /// <summary>仕入先略称</summary>
        private string _supplierSnm = "";


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

        /// public propaty name  :  SupplierNm1
        /// <summary>仕入先名1プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先名1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SupplierNm1
        {
            get { return _supplierNm1; }
            set { _supplierNm1 = value; }
        }

        /// public propaty name  :  SupplierKana
        /// <summary>仕入先カナプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先カナプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SupplierKana
        {
            get { return _supplierKana; }
            set { _supplierKana = value; }
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


        /// <summary>
        /// 仕入先（提供）ワークコンストラクタ
        /// </summary>
        /// <returns>OfrSupplierWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   OfrSupplierWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public OfrSupplierWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>OfrSupplierWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   OfrSupplierWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class OfrSupplierWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   OfrSupplierWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  OfrSupplierWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is OfrSupplierWork || graph is ArrayList || graph is OfrSupplierWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(OfrSupplierWork).FullName));

            if (graph != null && graph is OfrSupplierWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.OfrSupplierWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is OfrSupplierWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((OfrSupplierWork[])graph).Length;
            }
            else if (graph is OfrSupplierWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //提供日付
            serInfo.MemberInfo.Add(typeof(Int32)); //OfferDate
            //仕入先コード
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierCd
            //仕入先名1
            serInfo.MemberInfo.Add(typeof(string)); //SupplierNm1
            //仕入先カナ
            serInfo.MemberInfo.Add(typeof(string)); //SupplierKana
            //仕入先略称
            serInfo.MemberInfo.Add(typeof(string)); //SupplierSnm


            serInfo.Serialize(writer, serInfo);
            if (graph is OfrSupplierWork)
            {
                OfrSupplierWork temp = (OfrSupplierWork)graph;

                SetOfrSupplierWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is OfrSupplierWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((OfrSupplierWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (OfrSupplierWork temp in lst)
                {
                    SetOfrSupplierWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// OfrSupplierWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 5;

        /// <summary>
        ///  OfrSupplierWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   OfrSupplierWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetOfrSupplierWork(System.IO.BinaryWriter writer, OfrSupplierWork temp)
        {
            //提供日付
            writer.Write(temp.OfferDate);
            //仕入先コード
            writer.Write(temp.SupplierCd);
            //仕入先名1
            writer.Write(temp.SupplierNm1);
            //仕入先カナ
            writer.Write(temp.SupplierKana);
            //仕入先略称
            writer.Write(temp.SupplierSnm);

        }

        /// <summary>
        ///  OfrSupplierWorkインスタンス取得
        /// </summary>
        /// <returns>OfrSupplierWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   OfrSupplierWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private OfrSupplierWork GetOfrSupplierWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            OfrSupplierWork temp = new OfrSupplierWork();

            //提供日付
            temp.OfferDate = reader.ReadInt32();
            //仕入先コード
            temp.SupplierCd = reader.ReadInt32();
            //仕入先名1
            temp.SupplierNm1 = reader.ReadString();
            //仕入先カナ
            temp.SupplierKana = reader.ReadString();
            //仕入先略称
            temp.SupplierSnm = reader.ReadString();


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
        /// <returns>OfrSupplierWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   OfrSupplierWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                OfrSupplierWork temp = GetOfrSupplierWork(reader, serInfo);
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
                    retValue = (OfrSupplierWork[])lst.ToArray(typeof(OfrSupplierWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

}

