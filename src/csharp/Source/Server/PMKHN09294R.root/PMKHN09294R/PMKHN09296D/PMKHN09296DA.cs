//****************************************************************************//
// システム         : RC.NS
// プログラム名称   : バックアップ処理履歴取得結果ワーク
// プログラム概要   : バックアップ処理履歴取得結果ワークデータパラメータ
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 自動生成
// 作 成 日  2011.06.22  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   BackUpExecutionWork
    /// <summary>
    ///                      バックアップ処理履歴取得結果ワークワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   バックアップ処理履歴取得結果ワークワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2011.06.22  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class BackUpExecutionWork 
    {
        /// <summary>処理開始時間</summary>
        /// <remarks>処理開始時間（string:精度は100ナノ秒）</remarks>
        private string _startDateTime;

        /// <summary>処理終了時間</summary>
        /// <remarks>処理終了時間（string:精度は100ナノ秒）</remarks>
        private string _endDateTime;

        /// <summary>バックアップファイル名</summary>
        private string _fileName = "";

        /// <summary>DBVersion</summary>
        private string _dBVersion = "";

        /// <summary>処理結果</summary>
        private string _resultContent = "";

        /// <summary>ステータス</summary>
        private Int32 _status;

        /// public propaty name  :  StartDateTime
        /// <summary>処理開始時間</summary>
        /// <value>処理開始時間（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   処理開始時間</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string StartDateTime
        {
            get { return _startDateTime; }
            set { _startDateTime = value; }
        }

        /// public propaty name  :  EndDateTime
        /// <summary>処理終了時間</summary>
        /// <value>処理終了時間（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   処理終了時間</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EndDateTime
        {
            get { return _endDateTime; }
            set { _endDateTime = value; }
        }

        /// public propaty name  :  FileName
        /// <summary>バックアップファイル名</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   バックアップファイル名</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string FileName
        {
            get { return _fileName; }
            set { _fileName = value; }
        }

        /// public propaty name  :  DBVersion
        /// <summary>DBVersion</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   DBVersion</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DBVersion
        {
            get { return _dBVersion; }
            set { _dBVersion = value; }
        }

        /// public propaty name  :  ResultContent
        /// <summary>処理結果</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   処理結果</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ResultContent
        {
            get { return _resultContent; }
            set { _resultContent = value; }
        }

        /// public propaty name  :  Status
        /// <summary>ステータス</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ステータス</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 Status
        {
            get { return _status; }
            set { _status = value; }
        }



        /// <summary>
        /// バックアップ処理履歴取得結果ワークワークコンストラクタ
        /// </summary>
        /// <returns>BackUpExecutionWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   BackUpExecutionWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public BackUpExecutionWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>BackUpExecutionWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   BackUpExecutionWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class BackUpExecutionWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   BackUpExecutionWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  BackUpExecutionWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is BackUpExecutionWork || graph is ArrayList || graph is BackUpExecutionWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(BackUpExecutionWork).FullName));

            if (graph != null && graph is BackUpExecutionWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.BackUpExecutionWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is BackUpExecutionWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((BackUpExecutionWork[])graph).Length;
            }
            else if (graph is BackUpExecutionWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //処理開始時間
            serInfo.MemberInfo.Add(typeof(string)); //StartDateTime
            //処理終了時間
            serInfo.MemberInfo.Add(typeof(string)); //EndDateTime
            //バックアップファイル名
            serInfo.MemberInfo.Add(typeof(string)); //FileName
            //DBVersion
            serInfo.MemberInfo.Add(typeof(string)); //DBVersion
            //処理結果
            serInfo.MemberInfo.Add(typeof(string)); //ResultContent
            //ステータス
            serInfo.MemberInfo.Add(typeof(Int32)); //Status



            serInfo.Serialize(writer, serInfo);
            if (graph is BackUpExecutionWork)
            {
                BackUpExecutionWork temp = (BackUpExecutionWork)graph;

                SetBackUpExecutionWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is BackUpExecutionWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((BackUpExecutionWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (BackUpExecutionWork temp in lst)
                {
                    SetBackUpExecutionWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// BackUpExecutionWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 6;

        /// <summary>
        ///  BackUpExecutionWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   BackUpExecutionWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetBackUpExecutionWork(System.IO.BinaryWriter writer, BackUpExecutionWork temp)
        {
            //処理開始時間
            //writer.Write((Int64)temp.StartDateTime.Ticks);
            writer.Write(temp.StartDateTime);
            //処理終了時間
            //writer.Write((Int64)temp.EndDateTime.Ticks);
            writer.Write(temp.EndDateTime);
            //バックアップファイル名
            writer.Write(temp.FileName);
            //DBVersion
            writer.Write(temp.DBVersion);
            //処理結果
            writer.Write(temp.ResultContent);
            //ステータス
            writer.Write((Int32)temp.Status);


        }

        /// <summary>
        ///  BackUpExecutionWorkインスタンス取得
        /// </summary>
        /// <returns>BackUpExecutionWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   BackUpExecutionWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private BackUpExecutionWork GetBackUpExecutionWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            BackUpExecutionWork temp = new BackUpExecutionWork();

            //処理開始時間
            //temp.StartDateTime = new DateTime(reader.ReadInt64());
            temp.StartDateTime = reader.ReadString();
            //処理終了時間
            //temp.EndDateTime = new DateTime(reader.ReadInt64());
            temp.EndDateTime = reader.ReadString();
            //バックアップファイル名
            temp.FileName = reader.ReadString();
            //DBVersion
            temp.DBVersion = reader.ReadString();
            //処理結果
            temp.ResultContent = reader.ReadString();
            //ステータス
            temp.Status = reader.ReadInt32();



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
        /// <returns>BackUpExecutionWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   BackUpExecutionWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                BackUpExecutionWork temp = GetBackUpExecutionWork(reader, serInfo);
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
                    retValue = (BackUpExecutionWork[])lst.ToArray(typeof(BackUpExecutionWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

}
