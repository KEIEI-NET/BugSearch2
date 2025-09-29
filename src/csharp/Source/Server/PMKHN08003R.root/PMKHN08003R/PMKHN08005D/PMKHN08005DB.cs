using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   ErrorReportWork
    /// <summary>
    ///                      エラーリポートワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   エラーリポートワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2008/3/31</br>
    /// <br>Genarated Date   :   2008/09/25  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class ErrorReportWork
    {

        /// <summary>処理データ</summary>
        private string _processingData;

        /// <summary>エラーメッセージ</summary>
        private string _errMsg = "";


        /// public propaty name  :  ProcessingData
        /// <summary>処理データプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   処理データプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ProcessingData
        {
            get { return _processingData; }
            set { _processingData = value; }
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
        /// <returns>ErrorReportWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   ErrorReportWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ErrorReportWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>ErrorReportWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   ErrorReportWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class ErrorReportWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   ErrorReportWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  ErrorReportWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is ErrorReportWork || graph is ArrayList || graph is ErrorReportWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(ErrorReportWork).FullName));

            if (graph != null && graph is ErrorReportWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.ErrorReportWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is ErrorReportWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((ErrorReportWork[])graph).Length;
            }
            else if (graph is ErrorReportWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //処理データ
            serInfo.MemberInfo.Add(typeof(string)); //ProcessingData
            //エラーメッセージ
            serInfo.MemberInfo.Add(typeof(string)); //ErrMsg


            serInfo.Serialize(writer, serInfo);
            if (graph is ErrorReportWork)
            {
                ErrorReportWork temp = (ErrorReportWork)graph;

                SetErrorReportWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is ErrorReportWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((ErrorReportWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (ErrorReportWork temp in lst)
                {
                    SetErrorReportWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// ErrorReportWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 2;

        /// <summary>
        ///  ErrorReportWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   ErrorReportWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetErrorReportWork(System.IO.BinaryWriter writer, ErrorReportWork temp)
        {
            //処理データ
            writer.Write(temp.ProcessingData);
            //エラーメッセージ
            writer.Write(temp.ErrMsg);

        }

        /// <summary>
        ///  ErrorReportWorkインスタンス取得
        /// </summary>
        /// <returns>ErrorReportWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   ErrorReportWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private ErrorReportWork GetErrorReportWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            ErrorReportWork temp = new ErrorReportWork();

            //処理データ
            temp.ProcessingData = reader.ReadString();
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
        /// <returns>ErrorReportWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   ErrorReportWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                ErrorReportWork temp = GetErrorReportWork(reader, serInfo);
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
                    retValue = (ErrorReportWork[])lst.ToArray(typeof(ErrorReportWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

}
