using System;
using System.Collections;
using System.Collections.Generic;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   PartsEquipWork
    /// <summary>
    ///                      部品装備ワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   部品装備ワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2005/5/6</br>
    /// <br>Genarated Date   :   2005/05/21  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class PartsEquipWork
    {
        /// <summary>装備分類コード</summary>
        private Int32 _equipmentGenreCd;
        /// <summary>装備コード</summary>
        private Int32 _equipmentCode;
        /// <summary>部品固有番号</summary>
        private Int64 _partsproperno;

        /// <summary>部品固有番号</summary>
        public Int64 PartsProperNo
        {
            get { return _partsproperno; }
            set { _partsproperno = value; }
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
        /// <summary>
        /// 部品装備ワークコンストラクタ
        /// </summary>
        /// <returns>PartsEquipWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PartsEquipWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public PartsEquipWork()
        {
        }
        /// <summary>
        /// 部品装備ワークコンストラクタ
        /// </summary>
        /// <param name="equipmentGenreCd">装備分類コード</param>
        /// <param name="equipmentCode">装備コード</param>
        /// <param name="partsProperNo"></param>
        /// <returns>PartsEquipWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PartsEquipWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public PartsEquipWork(Int32 equipmentGenreCd, Int32 equipmentCode, Int64 partsProperNo)
        {
            this._equipmentGenreCd = equipmentGenreCd;
            this._equipmentCode = equipmentCode;
            this._partsproperno = partsProperNo;
        }
        /// <summary>
        /// 部品装備ワーク複製処理
        /// </summary>
        /// <returns>PartsEquipWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいPartsEquipWorkクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public PartsEquipWork Clone()
        {
            return new PartsEquipWork(this._equipmentGenreCd, this._equipmentCode, this._partsproperno);
        }
    }

    /// <summary>
    ///  Ver5.1.0.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>PartsEquipWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   PartsEquipWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class PartsEquipWork_SerializationSurrogate_For_V5100 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ
        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   PartsEquipWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  EmployeeWork_SerializationSurrogate_For_V5100.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is PartsEquipWork || graph is ArrayList))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(PartsEquipWork).FullName));

            if (graph != null && graph is PartsEquipWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is PartsEquipWork)
            {
                occurrence = 1;
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.1.0.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.PartsEquipWork");
            serInfo.Occurrence = occurrence;		 //繰り返し数	

            serInfo.MemberInfo.Add(typeof(Int32));
            serInfo.MemberInfo.Add(typeof(Int32));
            serInfo.MemberInfo.Add(typeof(Int64));


            serInfo.Serialize(writer, serInfo);
            if (graph is PartsEquipWork)
            {
                PartsEquipWork temp = (PartsEquipWork)graph;

                writer.Write(temp.EquipmentGenreCd);
                writer.Write(temp.EquipmentCode);
                writer.Write(temp.PartsProperNo);


            }
            else if (graph is ArrayList)
            {
                ArrayList lst = (ArrayList)graph;
                for (int i = 0; i < occurrence; ++i)
                {

                    PartsEquipWork temp = (PartsEquipWork)lst[i];

                    writer.Write(temp.EquipmentGenreCd);
                    writer.Write(temp.EquipmentCode);
                    writer.Write(temp.PartsProperNo);


                }

            }
        }

        /// <summary>
        /// PartsEquipWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 3;

        /// <summary>
        ///  PartsEquipWorkインスタンス取得
        /// </summary>
        /// <returns>PartsEquipWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PartsEquipWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private PartsEquipWork GetPartsEquipWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            PartsEquipWork temp = new PartsEquipWork();

            temp.EquipmentGenreCd = reader.ReadInt32();
            temp.EquipmentCode = reader.ReadInt32();
            temp.PartsProperNo = reader.ReadInt64();


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
        ///  Ver5.1.0.0用のカスタムデシリアライザです
        /// </summary>
        /// <returns>PartsEquipWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PartsEquipWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                PartsEquipWork temp = GetPartsEquipWork(reader, serInfo);
                lst.Add(temp);
            }
            retValue = lst;
            return retValue;
        }

        #endregion
    }

}
