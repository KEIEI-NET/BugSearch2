using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   AddrUpdMngWork
    /// <summary>
    ///                      住所マスタ更新管理ワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   住所マスタ更新管理ワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2006/09/08</br>
    /// <br>Genarated Date   :   2006/09/08  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class AddrUpdMngWork : IFileHeaderOffer
    {
        /// <summary>作成日時</summary>
        /// <remarks>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</remarks>
        private DateTime _createDateTime;

        /// <summary>更新日時</summary>
        /// <remarks>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</remarks>
        private DateTime _updateDateTime;

        /// <summary>論理削除区分</summary>
        /// <remarks>共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除)</remarks>
        private Int32 _logicalDeleteCode;

        /// <summary>住所連結コード1</summary>
        private Int32 _addrConnectCd1;

        /// <summary>住所更新日時</summary>
        /// <remarks>DateTime:精度は100ナノ秒</remarks>
        private DateTime _addrUpdateDateTime;


        /// public propaty name  :  CreateDateTime
        /// <summary>作成日時プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   作成日時プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime CreateDateTime
        {
            get { return _createDateTime; }
            set { _createDateTime = value; }
        }

        /// public propaty name  :  UpdateDateTime
        /// <summary>更新日時プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新日時プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime UpdateDateTime
        {
            get { return _updateDateTime; }
            set { _updateDateTime = value; }
        }

        /// public propaty name  :  LogicalDeleteCode
        /// <summary>論理削除区分プロパティ</summary>
        /// <value>共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   論理削除区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 LogicalDeleteCode
        {
            get { return _logicalDeleteCode; }
            set { _logicalDeleteCode = value; }
        }

        /// public propaty name  :  AddrConnectCd1
        /// <summary>住所連結コード1プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   住所連結コード1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AddrConnectCd1
        {
            get { return _addrConnectCd1; }
            set { _addrConnectCd1 = value; }
        }

        /// public propaty name  :  AddrUpdateDateTime
        /// <summary>住所更新日時プロパティ</summary>
        /// <value>DateTime:精度は100ナノ秒</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   住所更新日時プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime AddrUpdateDateTime
        {
            get { return _addrUpdateDateTime; }
            set { _addrUpdateDateTime = value; }
        }


        /// <summary>
        /// 住所マスタ更新管理ワークコンストラクタ
        /// </summary>
        /// <returns>AddrUpdMngWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   AddrUpdMngWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public AddrUpdMngWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>AddrUpdMngWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   AddrUpdMngWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class AddrUpdMngWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   AddrUpdMngWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  AddrUpdMngWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is AddrUpdMngWork || graph is ArrayList || graph is AddrUpdMngWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(AddrUpdMngWork).FullName));

            if (graph != null && graph is AddrUpdMngWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.AddrUpdMngWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is AddrUpdMngWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((AddrUpdMngWork[])graph).Length;
            }
            else if (graph is AddrUpdMngWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //作成日時
            serInfo.MemberInfo.Add(typeof(Int64)); //CreateDateTime
            //更新日時
            serInfo.MemberInfo.Add(typeof(Int64)); //UpdateDateTime
            //論理削除区分
            serInfo.MemberInfo.Add(typeof(Int32)); //LogicalDeleteCode
            //住所連結コード1
            serInfo.MemberInfo.Add(typeof(Int32)); //AddrConnectCd1
            //住所更新日時
            serInfo.MemberInfo.Add(typeof(Int64)); //AddrUpdateDateTime


            serInfo.Serialize(writer, serInfo);
            if (graph is AddrUpdMngWork)
            {
                AddrUpdMngWork temp = (AddrUpdMngWork)graph;

                SetAddrUpdMngWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is AddrUpdMngWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((AddrUpdMngWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (AddrUpdMngWork temp in lst)
                {
                    SetAddrUpdMngWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// AddrUpdMngWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 5;

        /// <summary>
        ///  AddrUpdMngWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   AddrUpdMngWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetAddrUpdMngWork(System.IO.BinaryWriter writer, AddrUpdMngWork temp)
        {
            //作成日時
            writer.Write((Int64)temp.CreateDateTime.Ticks);
            //更新日時
            writer.Write((Int64)temp.UpdateDateTime.Ticks);
            //論理削除区分
            writer.Write(temp.LogicalDeleteCode);
            //住所連結コード1
            writer.Write(temp.AddrConnectCd1);
            //住所更新日時
            writer.Write((Int64)temp.AddrUpdateDateTime.Ticks);

        }

        /// <summary>
        ///  AddrUpdMngWorkインスタンス取得
        /// </summary>
        /// <returns>AddrUpdMngWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   AddrUpdMngWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private AddrUpdMngWork GetAddrUpdMngWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            AddrUpdMngWork temp = new AddrUpdMngWork();

            //作成日時
            temp.CreateDateTime = new DateTime(reader.ReadInt64());
            //更新日時
            temp.UpdateDateTime = new DateTime(reader.ReadInt64());
            //論理削除区分
            temp.LogicalDeleteCode = reader.ReadInt32();
            //住所連結コード1
            temp.AddrConnectCd1 = reader.ReadInt32();
            //住所更新日時
            temp.AddrUpdateDateTime = new DateTime(reader.ReadInt64());


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
        /// <returns>AddrUpdMngWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   AddrUpdMngWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                AddrUpdMngWork temp = GetAddrUpdMngWork(reader, serInfo);
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
                    retValue = (AddrUpdMngWork[])lst.ToArray(typeof(AddrUpdMngWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

}
