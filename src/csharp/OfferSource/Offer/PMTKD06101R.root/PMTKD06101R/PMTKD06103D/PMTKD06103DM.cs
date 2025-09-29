using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   CtgryEquipWork
    /// <summary>
    ///                      類別装備ワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   類別装備ワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2005/04/06</br>
    /// <br>Genarated Date   :   2008/07/29  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class CtgryEquipWork
    {
        /// <summary>提供日付</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _offerDate;

        /// <summary>型式指定番号</summary>
        private Int32 _modelDesignationNo;

        /// <summary>類別番号</summary>
        private Int32 _categoryNo;

        /// <summary>装備分類コード</summary>
        private Int32 _equipmentGenreCd;

        /// <summary>装備分類名称</summary>
        private string _equipmentGenreNm = "";

        /// <summary>装備コード</summary>
        private Int32 _equipmentCode;

        /// <summary>装備名称</summary>
        private string _equipmentName = "";

        /// <summary>装備略称</summary>
        private string _equipmentShortName = "";

        /// <summary>装備ICONコード</summary>
        private Int32 _equipmentIconCode;


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

        /// public propaty name  :  ModelDesignationNo
        /// <summary>型式指定番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   型式指定番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ModelDesignationNo
        {
            get { return _modelDesignationNo; }
            set { _modelDesignationNo = value; }
        }

        /// public propaty name  :  CategoryNo
        /// <summary>類別番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   類別番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CategoryNo
        {
            get { return _categoryNo; }
            set { _categoryNo = value; }
        }

        /// public propaty name  :  EquipmentGenreCd
        /// <summary>装備分類コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   装備分類コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 EquipmentGenreCd
        {
            get { return _equipmentGenreCd; }
            set { _equipmentGenreCd = value; }
        }

        /// public propaty name  :  EquipmentGenreNm
        /// <summary>装備分類名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   装備分類名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EquipmentGenreNm
        {
            get { return _equipmentGenreNm; }
            set { _equipmentGenreNm = value; }
        }

        /// public propaty name  :  EquipmentCode
        /// <summary>装備コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   装備コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 EquipmentCode
        {
            get { return _equipmentCode; }
            set { _equipmentCode = value; }
        }

        /// public propaty name  :  EquipmentName
        /// <summary>装備名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   装備名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EquipmentName
        {
            get { return _equipmentName; }
            set { _equipmentName = value; }
        }

        /// public propaty name  :  EquipmentShortName
        /// <summary>装備略称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   装備略称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EquipmentShortName
        {
            get { return _equipmentShortName; }
            set { _equipmentShortName = value; }
        }

        /// public propaty name  :  EquipmentIconCode
        /// <summary>装備ICONコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   装備ICONコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 EquipmentIconCode
        {
            get { return _equipmentIconCode; }
            set { _equipmentIconCode = value; }
        }


        /// <summary>
        /// 類別装備ワークコンストラクタ
        /// </summary>
        /// <returns>CtgryEquipWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CtgryEquipWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public CtgryEquipWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>CtgryEquipWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   CtgryEquipWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class CtgryEquipWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   CtgryEquipWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  CtgryEquipWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is CtgryEquipWork || graph is ArrayList || graph is CtgryEquipWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(CtgryEquipWork).FullName));

            if (graph != null && graph is CtgryEquipWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.CtgryEquipWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is CtgryEquipWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((CtgryEquipWork[])graph).Length;
            }
            else if (graph is CtgryEquipWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //提供日付
            serInfo.MemberInfo.Add(typeof(Int32)); //OfferDate
            //型式指定番号
            serInfo.MemberInfo.Add(typeof(Int32)); //ModelDesignationNo
            //類別番号
            serInfo.MemberInfo.Add(typeof(Int32)); //CategoryNo
            //装備分類コード
            serInfo.MemberInfo.Add(typeof(Int32)); //EquipmentGenreCd
            //装備分類名称
            serInfo.MemberInfo.Add(typeof(string)); //EquipmentGenreNm
            //装備コード
            serInfo.MemberInfo.Add(typeof(Int32)); //EquipmentCode
            //装備名称
            serInfo.MemberInfo.Add(typeof(string)); //EquipmentName
            //装備略称
            serInfo.MemberInfo.Add(typeof(string)); //EquipmentShortName
            //装備ICONコード
            serInfo.MemberInfo.Add(typeof(Int32)); //EquipmentIconCode


            serInfo.Serialize(writer, serInfo);
            if (graph is CtgryEquipWork)
            {
                CtgryEquipWork temp = (CtgryEquipWork)graph;

                SetCtgryEquipWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is CtgryEquipWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((CtgryEquipWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (CtgryEquipWork temp in lst)
                {
                    SetCtgryEquipWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// CtgryEquipWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 9;

        /// <summary>
        ///  CtgryEquipWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   CtgryEquipWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetCtgryEquipWork(System.IO.BinaryWriter writer, CtgryEquipWork temp)
        {
            //提供日付
            writer.Write(temp.OfferDate);
            //型式指定番号
            writer.Write(temp.ModelDesignationNo);
            //類別番号
            writer.Write(temp.CategoryNo);
            //装備分類コード
            writer.Write(temp.EquipmentGenreCd);
            //装備分類名称
            writer.Write(temp.EquipmentGenreNm);
            //装備コード
            writer.Write(temp.EquipmentCode);
            //装備名称
            writer.Write(temp.EquipmentName);
            //装備略称
            writer.Write(temp.EquipmentShortName);
            //装備ICONコード
            writer.Write(temp.EquipmentIconCode);

        }

        /// <summary>
        ///  CtgryEquipWorkインスタンス取得
        /// </summary>
        /// <returns>CtgryEquipWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CtgryEquipWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private CtgryEquipWork GetCtgryEquipWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            CtgryEquipWork temp = new CtgryEquipWork();

            //提供日付
            temp.OfferDate = reader.ReadInt32();
            //型式指定番号
            temp.ModelDesignationNo = reader.ReadInt32();
            //類別番号
            temp.CategoryNo = reader.ReadInt32();
            //装備分類コード
            temp.EquipmentGenreCd = reader.ReadInt32();
            //装備分類名称
            temp.EquipmentGenreNm = reader.ReadString();
            //装備コード
            temp.EquipmentCode = reader.ReadInt32();
            //装備名称
            temp.EquipmentName = reader.ReadString();
            //装備略称
            temp.EquipmentShortName = reader.ReadString();
            //装備ICONコード
            temp.EquipmentIconCode = reader.ReadInt32();


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
        /// <returns>CtgryEquipWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CtgryEquipWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                CtgryEquipWork temp = GetCtgryEquipWork(reader, serInfo);
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
                    retValue = (CtgryEquipWork[])lst.ToArray(typeof(CtgryEquipWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

}
