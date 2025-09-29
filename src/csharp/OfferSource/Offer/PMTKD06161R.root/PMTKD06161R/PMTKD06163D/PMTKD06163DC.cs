using System;
using System.Collections;
using System.Collections.Generic;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   RetTbsPartsCodeWork
    /// <summary>
    ///                      ＢＬ名称取得結果クラス
    /// </summary>
    /// <remarks>
    /// <br>note             :   ＢＬ名称取得結果クラスワークヘッダファイル</br>
    /// <br>Programmer       :   ハンドメイド</br>
    /// <br>Date             :   2007/03/06</br>
    /// <br>Genarated Date   :   </br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class RetTbsPartsCodeWork
    {
        /// <summary>ＢＬコード</summary>
        private Int32 _tbsPartsCode;

        /// <summary>ＢＬコード名称（全角）</summary>
        private string _tbsPartsFullName = "";

        /// <summary>ＢＬコード名称（半角）</summary>
        private string _tbsPartsHalfName = "";

        /// <summary>装備分類</summary>
        /// <remarks>例）1001：バッテリ</remarks>
        private Int32 _equipGenre;

        /// <summary>優良検索区分</summary>
        /// <remarks>0：優良検索無し　1：優良検索有り</remarks>
        private Int32 _primeSearchFlg;

        /// public propaty name  :  TbsPartsCode
        /// <summary>ＢＬコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ＢＬコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 TbsPartsCode
        {
            get { return _tbsPartsCode; }
            set { _tbsPartsCode = value; }
        }

        /// public propaty name  :  TbsPartsFullName
        /// <summary>ＢＬコード名称（全角）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ＢＬコード名称（全角）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string TbsPartsFullName
        {
            get { return _tbsPartsFullName; }
            set { _tbsPartsFullName = value; }
        }

        /// public propaty name  :  TbsPartsHalfName
        /// <summary>ＢＬコード名称（半角）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ＢＬコード名称（半角）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string TbsPartsHalfName
        {
            get { return _tbsPartsHalfName; }
            set { _tbsPartsHalfName = value; }
        }

        /// public propaty name  :  EquipGenre
        /// <summary>装備分類プロパティ</summary>
        /// <value>例）1001：バッテリ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   装備分類プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 EquipGenre
        {
            get { return _equipGenre; }
            set { _equipGenre = value; }
        }

        /// public propaty name  :  PrimeSearchFlg
        /// <summary>優良検索区分プロパティ</summary>
        /// <value>0：優良検索無し　1：優良検索有り</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   優良検索区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PrimeSearchFlg
        {
            get { return _primeSearchFlg; }
            set { _primeSearchFlg = value; }
        }

        /// <summary>
        /// ＢＬ名称取得結果クラスコンストラクタ
        /// </summary>
        /// <returns>PartsSubstWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PartsSubstWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public RetTbsPartsCodeWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>RetTbsPartsCodeWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   RetTbsPartsCodeWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class RetTbsPartsCodeWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   PartsSubstWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  PartsSubstWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is RetTbsPartsCodeWork || graph is ArrayList || graph is RetTbsPartsCodeWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(RetTbsPartsCodeWork).FullName));

            if (graph != null && graph is RetTbsPartsCodeWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.RetTbsPartsCodeWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is RetTbsPartsCodeWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((RetTbsPartsCodeWork[])graph).Length;
            }
            else if (graph is RetTbsPartsCodeWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //ＢＬコード
            serInfo.MemberInfo.Add(typeof(Int32)); //tbspartscode
            //ＢＬコード名称（全角）
            serInfo.MemberInfo.Add(typeof(string)); //tbspartsfullname
            //ＢＬコード名称（半角）
            serInfo.MemberInfo.Add(typeof(string)); //tbspartshalfname
            //装備分類
            serInfo.MemberInfo.Add(typeof(Int32)); //EquipGenre
            //優良検索区分
            serInfo.MemberInfo.Add(typeof(Int32)); //PrimeSearchFlg

            serInfo.Serialize(writer, serInfo);
            if (graph is RetTbsPartsCodeWork)
            {
                RetTbsPartsCodeWork temp = (RetTbsPartsCodeWork)graph;

                SetRetTbsPartsCodeWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is RetTbsPartsCodeWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((RetTbsPartsCodeWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (RetTbsPartsCodeWork temp in lst)
                {
                    SetRetTbsPartsCodeWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// RetTbsPartsCodeWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 5;

        /// <summary>
        ///  RetTbsPartsCodeWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   PartsSubstWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetRetTbsPartsCodeWork(System.IO.BinaryWriter writer, RetTbsPartsCodeWork temp)
        {
            //ＢＬコード
            writer.Write(temp.TbsPartsCode);
            //ＢＬコード名称（全角）
            writer.Write(temp.TbsPartsFullName);
            //ＢＬコード名称（半角）
            writer.Write(temp.TbsPartsHalfName);
            //装備分類
            writer.Write(temp.EquipGenre);
            //優良検索区分
            writer.Write(temp.PrimeSearchFlg);
        }

        /// <summary>
        ///  RetTbsPartsCodeWorkインスタンス取得
        /// </summary>
        /// <returns>RetTbsPartsCodeWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   RetTbsPartsCodeWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private RetTbsPartsCodeWork GetRetTbsPartsCodeWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            RetTbsPartsCodeWork temp = new RetTbsPartsCodeWork();

            //ＢＬコード
            temp.TbsPartsCode = reader.ReadInt32();
            //ＢＬコード名称（全角）
            temp.TbsPartsFullName = reader.ReadString();
            //ＢＬコード名称（半角）
            temp.TbsPartsHalfName = reader.ReadString();
            //装備分類
            temp.EquipGenre = reader.ReadInt32();
            //優良検索区分
            temp.PrimeSearchFlg = reader.ReadInt32();

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
        /// <returns>PartsSubstWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PartsSubstWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                RetTbsPartsCodeWork temp = GetRetTbsPartsCodeWork(reader, serInfo);
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
                    retValue = (RetTbsPartsCodeWork[])lst.ToArray(typeof(RetTbsPartsCodeWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

}
