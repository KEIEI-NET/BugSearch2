//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 自動起動サービス処理
// プログラム概要   : 自動起動サービスファイルを保存
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 劉洋
// 作 成 日  2009/04/01  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日               修正内容 : 
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   ServiceFilesWork
    /// <summary>
    ///                      サービスファイルワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   サービスファイルワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2008/3/25</br>
    /// <br>Genarated Date   :   2009/04/29  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2008/6/23  長内</br>
    /// <br>                 :   項目追加</br>
    /// <br>                 :   商品名称カナ</br>
    /// <br>Update Note      :   2008/9/25  杉村</br>
    /// <br>                 :   ○項目削除</br>
    /// <br>                 :   倉庫備考2</br>
    /// <br>                 :   倉庫備考3</br>
    /// <br>                 :   倉庫備考4</br>
    /// <br>                 :   倉庫備考5 </br>
    /// <br>Update Note      :   2009/1/21  長内</br>
    /// <br>                 :   ○項目追加</br>
    /// <br>                 :   移動金額</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class ServiceFilesWork
    {
        /// <summary>ファイル内容</summary>
        private Byte[] _fileContent;


        /// public propaty name  :  FileContent
        /// <summary>ファイル内容プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ファイル内容プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Byte[] FileContent
        {
            get { return _fileContent; }
            set { _fileContent = value; }
        }


        /// <summary>
        /// サービスファイルワークコンストラクタ
        /// </summary>
        /// <returns>ServiceFilesWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   ServiceFilesWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ServiceFilesWork()
        {
        }

    }
    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>ServiceFilesWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   ServiceFilesWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class ServiceFilesWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   ServiceFilesWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  ServiceFilesWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is ServiceFilesWork || graph is ArrayList || graph is ServiceFilesWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(ServiceFilesWork).FullName));

            if (graph != null && graph is ServiceFilesWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.ServiceFilesWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is ServiceFilesWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((ServiceFilesWork[])graph).Length;
            }
            else if (graph is ServiceFilesWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //ファイル内容
            serInfo.MemberInfo.Add(typeof(Byte[])); //FileContent


            serInfo.Serialize(writer, serInfo);
            if (graph is ServiceFilesWork)
            {
                ServiceFilesWork temp = (ServiceFilesWork)graph;

                SetServiceFilesWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is ServiceFilesWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((ServiceFilesWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (ServiceFilesWork temp in lst)
                {
                    SetServiceFilesWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// ServiceFilesWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 1;

        /// <summary>
        ///  ServiceFilesWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   ServiceFilesWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetServiceFilesWork(System.IO.BinaryWriter writer, ServiceFilesWork temp)
        {
            //ファイル内容
            writer.Write(temp.FileContent.Length);
            writer.Write(temp.FileContent);

        }

        /// <summary>
        ///  ServiceFilesWorkインスタンス取得
        /// </summary>
        /// <returns>ServiceFilesWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   ServiceFilesWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private ServiceFilesWork GetServiceFilesWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            ServiceFilesWork temp = new ServiceFilesWork();

            //ファイル内容
            int length = reader.ReadInt32();
            temp.FileContent = reader.ReadBytes(length);


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
        /// <returns>ServiceFilesWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   ServiceFilesWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                ServiceFilesWork temp = GetServiceFilesWork(reader, serInfo);
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
                    retValue = (ServiceFilesWork[])lst.ToArray(typeof(ServiceFilesWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}

