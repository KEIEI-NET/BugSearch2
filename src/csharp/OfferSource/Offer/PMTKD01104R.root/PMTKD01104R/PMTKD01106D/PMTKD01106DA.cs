//**********************************************************************//
// System			:	PM.NS											//
// Sub System		:													//
// Program name		:	提供データ削除処理 データパラメータ             //
//					:	PMTKD01106D.DLL									//
// Name Space		:	Broadleaf.Application.Remoting.ParamData    	//
// Programmer		:	呉元嘯　                                        //
// Date				:	2009.06.16										//
//----------------------------------------------------------------------//
// Update Note      :                                                   //
//----------------------------------------------------------------------//
//                 Copyright(c)2009 Broadleaf Co.,Ltd.                  //
//**********************************************************************//
using System;
using System.Collections;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   OfferDataDeleteWork
    /// <summary>
    ///                      提供データ削除処理ワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   提供データ削除処理ワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2009/06/23  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2008/06/26  菅</br>
    /// <br>                 :   処理区分追加。</br>
    /// <br>                 :   キー変更</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class OfferDataDeleteWork
    {
        /// <summary>テーブル名</summary>
        private string _tableName = "";

        /// <summary>テーブルＩＤ</summary>
        private string _tableID = "";

        /// <summary>処理コード</summary>
        /// <remarks>子コード（子コードがゼロの場合は、親コードの名称）</remarks>
        private Int32 _code;

        /// <summary>処理フィールド</summary>
        private string _field = "";

        /// <summary>処理結果</summary>
        private string _result = "";


        /// public propaty name  :  TableName
        /// <summary>テーブル名プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   テーブル名プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string TableName
        {
            get { return _tableName; }
            set { _tableName = value; }
        }

        /// public propaty name  :  TableID
        /// <summary>テーブルＩＤプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   テーブルＩＤプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string TableID
        {
            get { return _tableID; }
            set { _tableID = value; }
        }

        /// public propaty name  :  Code
        /// <summary>処理コードプロパティ</summary>
        /// <value>子コード（子コードがゼロの場合は、親コードの名称）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   処理コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 Code
        {
            get { return _code; }
            set { _code = value; }
        }

        /// public propaty name  :  Field
        /// <summary>処理フィールドプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   処理フィールドプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string Field
        {
            get { return _field; }
            set { _field = value; }
        }

        /// public propaty name  :  Result
        /// <summary>処理結果プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   処理結果プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string Result
        {
            get { return _result; }
            set { _result = value; }
        }


        /// <summary>
        /// 提供データ削除処理ワークコンストラクタ
        /// </summary>
        /// <returns>OfferDataDeleteWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   OfferDataDeleteWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public OfferDataDeleteWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>OfferDataDeleteWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   OfferDataDeleteWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class OfferDataDeleteWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   OfferDataDeleteWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  OfferDataDeleteWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is OfferDataDeleteWork || graph is ArrayList || graph is OfferDataDeleteWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(OfferDataDeleteWork).FullName));

            if (graph != null && graph is OfferDataDeleteWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.OfferDataDeleteWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is OfferDataDeleteWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((OfferDataDeleteWork[])graph).Length;
            }
            else if (graph is OfferDataDeleteWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //テーブル名
            serInfo.MemberInfo.Add(typeof(string)); //TableName
            //テーブルＩＤ
            serInfo.MemberInfo.Add(typeof(string)); //TableID
            //処理コード
            serInfo.MemberInfo.Add(typeof(Int32)); //Code
            //処理フィールド
            serInfo.MemberInfo.Add(typeof(string)); //Field
            //処理結果
            serInfo.MemberInfo.Add(typeof(string)); //Result


            serInfo.Serialize(writer, serInfo);
            if (graph is OfferDataDeleteWork)
            {
                OfferDataDeleteWork temp = (OfferDataDeleteWork)graph;

                SetOfferDataDeleteWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is OfferDataDeleteWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((OfferDataDeleteWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (OfferDataDeleteWork temp in lst)
                {
                    SetOfferDataDeleteWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// OfferDataDeleteWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 5;

        /// <summary>
        ///  OfferDataDeleteWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   OfferDataDeleteWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetOfferDataDeleteWork(System.IO.BinaryWriter writer, OfferDataDeleteWork temp)
        {
            //テーブル名
            writer.Write(temp.TableName);
            //テーブルＩＤ
            writer.Write(temp.TableID);
            //処理コード
            writer.Write(temp.Code);
            //処理フィールド
            writer.Write(temp.Field);
            //処理結果
            writer.Write(temp.Result);

        }

        /// <summary>
        ///  OfferDataDeleteWorkインスタンス取得
        /// </summary>
        /// <returns>OfferDataDeleteWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   OfferDataDeleteWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private OfferDataDeleteWork GetOfferDataDeleteWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            OfferDataDeleteWork temp = new OfferDataDeleteWork();

            //テーブル名
            temp.TableName = reader.ReadString();
            //テーブルＩＤ
            temp.TableID = reader.ReadString();
            //処理コード
            temp.Code = reader.ReadInt32();
            //処理フィールド
            temp.Field = reader.ReadString();
            //処理結果
            temp.Result = reader.ReadString();


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
        /// <returns>OfferDataDeleteWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   OfferDataDeleteWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                OfferDataDeleteWork temp = GetOfferDataDeleteWork(reader, serInfo);
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
                    retValue = (OfferDataDeleteWork[])lst.ToArray(typeof(OfferDataDeleteWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }


}
