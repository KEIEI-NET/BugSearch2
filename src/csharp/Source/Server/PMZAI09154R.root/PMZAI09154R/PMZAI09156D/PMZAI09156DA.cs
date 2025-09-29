using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   StockHistoryUpdateWork
    /// <summary>
    ///                      在庫履歴現在庫数設定パラメータワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   在庫履歴現在庫数設定パラメータワークヘッダファイル</br>
    /// <br>Programmer       :   李占川</br>
    /// <br>Date             :   2009/12/24</br>
    /// <br>Genarated Date   :   2007/04/05  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class StockHistoryUpdateWork
    {
        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>対象年月</summary>
        private Int32 _addUpYearMonth;

        /// public propaty name  :  EnterpriseCode
        /// <summary>企業コードプロパティ</summary>
        /// <value>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   企業コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EnterpriseCode
        {
            get { return _enterpriseCode; }
            set { _enterpriseCode = value; }
        }

        /// public propaty name  :  AddUpYearMonth
        /// <summary>対象年月プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   対象年月プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AddUpYearMonth
        {
            get { return _addUpYearMonth; }
            set { _addUpYearMonth = value; }
        }

        /// <summary>
        /// 在庫履歴現在庫数設定パラメータワークコンストラクタ
        /// </summary>
        /// <returns>StockHistoryUpdateWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockHistoryUpdateWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public StockHistoryUpdateWork()
        {
        }
    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>StockHistoryUpdateWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   StockHistoryUpdateWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class StockHistoryUpdateWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockHistoryUpdateWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  StockHistoryUpdateWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is StockHistoryUpdateWork || graph is ArrayList || graph is StockHistoryUpdateWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(StockHistoryUpdateWork).FullName));

            if (graph != null && graph is StockHistoryUpdateWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.StockHistoryUpdateWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is StockHistoryUpdateWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((StockHistoryUpdateWork[])graph).Length;
            }
            else if (graph is StockHistoryUpdateWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //企業コード
            serInfo.MemberInfo.Add(typeof(string)); //EnterpriseCode
            //対象年月
            serInfo.MemberInfo.Add(typeof(Int32)); //AddUpYearMonth

            serInfo.Serialize(writer, serInfo);
            if (graph is StockHistoryUpdateWork)
            {
                StockHistoryUpdateWork temp = (StockHistoryUpdateWork)graph;

                SetStockHistoryUpdateWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is StockHistoryUpdateWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((StockHistoryUpdateWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (StockHistoryUpdateWork temp in lst)
                {
                    SetStockHistoryUpdateWork(writer, temp);
                }
            }
        }

        /// <summary>
        /// StockHistoryUpdateWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 2;

        /// <summary>
        ///  StockHistoryUpdateWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockHistoryUpdateWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetStockHistoryUpdateWork(System.IO.BinaryWriter writer, StockHistoryUpdateWork temp)
        {
            //企業コード
            writer.Write(temp.EnterpriseCode);
            //対象年月
            writer.Write(temp.AddUpYearMonth);
        }

        /// <summary>
        ///  StockHistoryUpdateWorkインスタンス取得
        /// </summary>
        /// <returns>StockHistoryUpdateWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockHistoryUpdateWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private StockHistoryUpdateWork GetStockHistoryUpdateWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            StockHistoryUpdateWork temp = new StockHistoryUpdateWork();

            //企業コード
            temp.EnterpriseCode = reader.ReadString();
            //対象年月
            temp.AddUpYearMonth = reader.ReadInt32();

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
        /// <returns>StockHistoryUpdateWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockHistoryUpdateWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                StockHistoryUpdateWork temp = GetStockHistoryUpdateWork(reader, serInfo);
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
                    retValue = (StockHistoryUpdateWork[])lst.ToArray(typeof(StockHistoryUpdateWork));
                    break;
            }
            return retValue;
        }
        #endregion
    }
}
