using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   ConvertResultWork
    /// <summary>
    ///                      コンバート結果ワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   コンバート結果ワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2008/3/31</br>
    /// <br>Genarated Date   :   2008/09/25  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class ConvertResultWork
    {
        /// <summary>更新行数</summary>
        private Int32 _updateCnt;

        /// <summary>更新失敗行数</summary>
        private Int32 _failedRowCnt;

        /// <summary>エラーメッセージ</summary>
        private string _errMsg = "";


        /// public propaty name  :  UpdateCnt
        /// <summary>更新行数プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新行数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 UpdateCnt
        {
            get { return _updateCnt; }
            set { _updateCnt = value; }
        }

        /// public propaty name  :  FailedRowCnt
        /// <summary>更新失敗行数プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新失敗行数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 FailedRowCnt
        {
            get { return _failedRowCnt; }
            set { _failedRowCnt = value; }
        }

        /// public propaty name  :  ErrMsg
        /// <summary>エラーメッセージプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   エラーメッセージプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ErrMsg
        {
            get { return _errMsg; }
            set { _errMsg = value; }
        }


        /// <summary>
        /// コンバート結果ワークコンストラクタ
        /// </summary>
        /// <returns>ConvertResultWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   ConvertResultWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ConvertResultWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>ConvertResultWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   ConvertResultWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class ConvertResultWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   ConvertResultWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  ConvertResultWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is ConvertResultWork || graph is ArrayList || graph is ConvertResultWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(ConvertResultWork).FullName));

            if (graph != null && graph is ConvertResultWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.ConvertResultWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is ConvertResultWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((ConvertResultWork[])graph).Length;
            }
            else if (graph is ConvertResultWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //更新行数
            serInfo.MemberInfo.Add(typeof(Int32)); //UpdateCnt
            //更新失敗行数
            serInfo.MemberInfo.Add(typeof(Int32)); //FailedRowCnt
            //エラーメッセージ
            serInfo.MemberInfo.Add(typeof(string)); //ErrMsg


            serInfo.Serialize(writer, serInfo);
            if (graph is ConvertResultWork)
            {
                ConvertResultWork temp = (ConvertResultWork)graph;

                SetConvertResultWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is ConvertResultWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((ConvertResultWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (ConvertResultWork temp in lst)
                {
                    SetConvertResultWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// ConvertResultWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 3;

        /// <summary>
        ///  ConvertResultWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   ConvertResultWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetConvertResultWork(System.IO.BinaryWriter writer, ConvertResultWork temp)
        {
            //更新行数
            writer.Write(temp.UpdateCnt);
            //更新失敗行数
            writer.Write(temp.FailedRowCnt);
            //エラーメッセージ
            writer.Write(temp.ErrMsg);

        }

        /// <summary>
        ///  ConvertResultWorkインスタンス取得
        /// </summary>
        /// <returns>ConvertResultWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   ConvertResultWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private ConvertResultWork GetConvertResultWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            ConvertResultWork temp = new ConvertResultWork();

            //更新行数
            temp.UpdateCnt = reader.ReadInt32();
            //更新失敗行数
            temp.FailedRowCnt = reader.ReadInt32();
            //エラーメッセージ
            temp.ErrMsg = reader.ReadString();


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
        /// <returns>ConvertResultWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   ConvertResultWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                ConvertResultWork temp = GetConvertResultWork(reader, serInfo);
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
                    retValue = (ConvertResultWork[])lst.ToArray(typeof(ConvertResultWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

}
