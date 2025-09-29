using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   SearchPrtCtlWork
    /// <summary>
    ///                      検索品目制御ワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   検索品目制御ワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :    2007/1/17</br>
    /// <br>Genarated Date   :   2008/11/11  (CSharp File Generated Date)</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class SearchPrtCtlWork
    {
        /// <summary>提供日付</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _offerDate;

        /// <summary>検索タイプ</summary>
        /// <remarks>0:標準 10:拡張 20:外装</remarks>
        private Int32 _searchPrtType;

        /// <summary>大型提供区分</summary>
        /// <remarks>0:小型 1:大型</remarks>
        private Int32 _bigCarOfferDiv;

        /// <summary>BLコード</summary>
        private Int32 _tbsPartsCode;


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

        /// public propaty name  :  SearchPrtType
        /// <summary>検索タイププロパティ</summary>
        /// <value>0:標準 10:拡張 20:外装</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   検索タイププロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SearchPrtType
        {
            get { return _searchPrtType; }
            set { _searchPrtType = value; }
        }

        /// public propaty name  :  BigCarOfferDiv
        /// <summary>大型提供区分プロパティ</summary>
        /// <value>0:小型 1:大型</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   大型提供区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BigCarOfferDiv
        {
            get { return _bigCarOfferDiv; }
            set { _bigCarOfferDiv = value; }
        }

        /// public propaty name  :  TbsPartsCode
        /// <summary>BLコードプロパティ</summary>
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


        /// <summary>
        /// 検索品目制御ワークコンストラクタ
        /// </summary>
        /// <returns>SearchPrtCtlWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SearchPrtCtlWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SearchPrtCtlWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>SearchPrtCtlWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   SearchPrtCtlWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class SearchPrtCtlWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   SearchPrtCtlWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  SearchPrtCtlWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is SearchPrtCtlWork || graph is ArrayList || graph is SearchPrtCtlWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(SearchPrtCtlWork).FullName));

            if (graph != null && graph is SearchPrtCtlWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.SearchPrtCtlWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is SearchPrtCtlWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((SearchPrtCtlWork[])graph).Length;
            }
            else if (graph is SearchPrtCtlWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //提供日付
            serInfo.MemberInfo.Add(typeof(Int32)); //OfferDate
            //検索タイプ
            serInfo.MemberInfo.Add(typeof(Int32)); //SearchPrtType
            //大型提供区分
            serInfo.MemberInfo.Add(typeof(Int32)); //BigCarOfferDiv
            //BLコード
            serInfo.MemberInfo.Add(typeof(Int32)); //TbsPartsCode


            serInfo.Serialize(writer, serInfo);
            if (graph is SearchPrtCtlWork)
            {
                SearchPrtCtlWork temp = (SearchPrtCtlWork)graph;

                SetSearchPrtCtlWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is SearchPrtCtlWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((SearchPrtCtlWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (SearchPrtCtlWork temp in lst)
                {
                    SetSearchPrtCtlWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// SearchPrtCtlWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 4;

        /// <summary>
        ///  SearchPrtCtlWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   SearchPrtCtlWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetSearchPrtCtlWork(System.IO.BinaryWriter writer, SearchPrtCtlWork temp)
        {
            //提供日付
            writer.Write(temp.OfferDate);
            //検索タイプ
            writer.Write(temp.SearchPrtType);
            //大型提供区分
            writer.Write(temp.BigCarOfferDiv);
            //BLコード
            writer.Write(temp.TbsPartsCode);

        }

        /// <summary>
        ///  SearchPrtCtlWorkインスタンス取得
        /// </summary>
        /// <returns>SearchPrtCtlWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SearchPrtCtlWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private SearchPrtCtlWork GetSearchPrtCtlWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            SearchPrtCtlWork temp = new SearchPrtCtlWork();

            //提供日付
            temp.OfferDate = reader.ReadInt32();
            //検索タイプ
            temp.SearchPrtType = reader.ReadInt32();
            //大型提供区分
            temp.BigCarOfferDiv = reader.ReadInt32();
            //BLコード
            temp.TbsPartsCode = reader.ReadInt32();


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
        /// <returns>SearchPrtCtlWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SearchPrtCtlWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                SearchPrtCtlWork temp = GetSearchPrtCtlWork(reader, serInfo);
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
                    retValue = (SearchPrtCtlWork[])lst.ToArray(typeof(SearchPrtCtlWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

}

