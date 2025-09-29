using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   StockCarEnterCarOutRetWork
    /// <summary>
    ///                      在庫入出庫照会抽出結果クラスワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   在庫入出庫照会抽出結果クラスワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/07/23  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class StockCarEnterCarOutRetWork
    {
        /// <summary>在庫総数</summary>
        /// <remarks>履歴開始年月からの総在庫数</remarks>
        private Double _stockTotal;

        /// <summary>入荷数</summary>
        /// <remarks>受払開始年月日からの総入荷数</remarks>
        private Double _arrivalCnt;

        /// <summary>出荷数</summary>
        /// <remarks>受払開始年月日からの総出荷数</remarks>
        private Double _shipmentCnt;

        /// <summary>残数</summary>
        /// <remarks>履歴開始年月からの総在庫数＋受払開始年月日から開始入出荷日までの総入荷数ー受払開始年月日から開始入出荷日までの総出荷数</remarks>
        private Double _remainCount;


        /// public propaty name  :  StockTotal
        /// <summary>在庫総数プロパティ</summary>
        /// <value>履歴開始年月からの総在庫数</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   在庫総数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double StockTotal
        {
            get { return _stockTotal; }
            set { _stockTotal = value; }
        }

        /// public propaty name  :  ArrivalCnt
        /// <summary>入荷数プロパティ</summary>
        /// <value>受払開始年月日からの総入荷数</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入荷数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double ArrivalCnt
        {
            get { return _arrivalCnt; }
            set { _arrivalCnt = value; }
        }

        /// public propaty name  :  ShipmentCnt
        /// <summary>出荷数プロパティ</summary>
        /// <value>受払開始年月日からの総出荷数</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   出荷数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double ShipmentCnt
        {
            get { return _shipmentCnt; }
            set { _shipmentCnt = value; }
        }

        /// public propaty name  :  RemainCount
        /// <summary>残数プロパティ</summary>
        /// <value>履歴開始年月からの総在庫数＋受払開始年月日から開始入出荷日までの総入荷数ー受払開始年月日から開始入出荷日までの総出荷数</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   残数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double RemainCount
        {
            get { return _remainCount; }
            set { _remainCount = value; }
        }


        /// <summary>
        /// 在庫入出庫照会抽出結果クラスワークコンストラクタ
        /// </summary>
        /// <returns>StockCarEnterCarOutRetWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockCarEnterCarOutRetWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public StockCarEnterCarOutRetWork()
        {
        }

    }
    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>StockCarEnterCarOutRetWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   StockCarEnterCarOutRetWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class StockCarEnterCarOutRetWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockCarEnterCarOutRetWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  StockCarEnterCarOutRetWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is StockCarEnterCarOutRetWork || graph is ArrayList || graph is StockCarEnterCarOutRetWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(StockCarEnterCarOutRetWork).FullName));

            if (graph != null && graph is StockCarEnterCarOutRetWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.StockCarEnterCarOutRetWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is StockCarEnterCarOutRetWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((StockCarEnterCarOutRetWork[])graph).Length;
            }
            else if (graph is StockCarEnterCarOutRetWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //在庫総数
            serInfo.MemberInfo.Add(typeof(Double)); //StockTotal
            //入荷数
            serInfo.MemberInfo.Add(typeof(Double)); //ArrivalCnt
            //出荷数
            serInfo.MemberInfo.Add(typeof(Double)); //ShipmentCnt
            //残数
            serInfo.MemberInfo.Add(typeof(Double)); //RemainCount


            serInfo.Serialize(writer, serInfo);
            if (graph is StockCarEnterCarOutRetWork)
            {
                StockCarEnterCarOutRetWork temp = (StockCarEnterCarOutRetWork)graph;

                SetStockCarEnterCarOutRetWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is StockCarEnterCarOutRetWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((StockCarEnterCarOutRetWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (StockCarEnterCarOutRetWork temp in lst)
                {
                    SetStockCarEnterCarOutRetWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// StockCarEnterCarOutRetWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 4;

        /// <summary>
        ///  StockCarEnterCarOutRetWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockCarEnterCarOutRetWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetStockCarEnterCarOutRetWork(System.IO.BinaryWriter writer, StockCarEnterCarOutRetWork temp)
        {
            //在庫総数
            writer.Write(temp.StockTotal);
            //入荷数
            writer.Write(temp.ArrivalCnt);
            //出荷数
            writer.Write(temp.ShipmentCnt);
            //残数
            writer.Write(temp.RemainCount);

        }

        /// <summary>
        ///  StockCarEnterCarOutRetWorkインスタンス取得
        /// </summary>
        /// <returns>StockCarEnterCarOutRetWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockCarEnterCarOutRetWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private StockCarEnterCarOutRetWork GetStockCarEnterCarOutRetWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            StockCarEnterCarOutRetWork temp = new StockCarEnterCarOutRetWork();

            //在庫総数
            temp.StockTotal = reader.ReadDouble();
            //入荷数
            temp.ArrivalCnt = reader.ReadDouble();
            //出荷数
            temp.ShipmentCnt = reader.ReadDouble();
            //残数
            temp.RemainCount = reader.ReadDouble();


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
        /// <returns>StockCarEnterCarOutRetWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockCarEnterCarOutRetWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                StockCarEnterCarOutRetWork temp = GetStockCarEnterCarOutRetWork(reader, serInfo);
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
                    retValue = (StockCarEnterCarOutRetWork[])lst.ToArray(typeof(StockCarEnterCarOutRetWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }



}
