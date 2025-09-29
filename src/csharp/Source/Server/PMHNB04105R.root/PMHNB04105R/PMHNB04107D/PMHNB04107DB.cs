using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   ShipmentPartsDspResultWork
    /// <summary>
    ///                      出荷部品照会抽出結果ワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   出荷部品照会抽出結果ワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/10/03  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class ShipmentPartsDspResultWork
    {
        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>実績集計区分</summary>
        /// <remarks>0:部品合計 1:在庫 2:純正 3:作業</remarks>
        private Int32 _rsltTtlDivCd;

        /// <summary>売上回数</summary>
        /// <remarks>出荷回数(売上時のみ）</remarks>
        private Int32 _salesTimes;

        /// <summary>売上金額</summary>
        /// <remarks>税抜き（値引,返品含まず）</remarks>
        private Int64 _salesMoney;

        /// <summary>粗利金額</summary>
        private Int64 _grossProfit;


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

        /// public propaty name  :  RsltTtlDivCd
        /// <summary>実績集計区分プロパティ</summary>
        /// <value>0:部品合計 1:在庫 2:純正 3:作業</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   実績集計区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 RsltTtlDivCd
        {
            get { return _rsltTtlDivCd; }
            set { _rsltTtlDivCd = value; }
        }

        /// public propaty name  :  SalesTimes
        /// <summary>売上回数プロパティ</summary>
        /// <value>出荷回数(売上時のみ）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上回数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SalesTimes
        {
            get { return _salesTimes; }
            set { _salesTimes = value; }
        }

        /// public propaty name  :  SalesMoney
        /// <summary>売上金額プロパティ</summary>
        /// <value>税抜き（値引,返品含まず）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上金額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesMoney
        {
            get { return _salesMoney; }
            set { _salesMoney = value; }
        }

        /// public propaty name  :  GrossProfit
        /// <summary>粗利金額プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   粗利金額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 GrossProfit
        {
            get { return _grossProfit; }
            set { _grossProfit = value; }
        }


        /// <summary>
        /// 出荷部品照会抽出結果ワークコンストラクタ
        /// </summary>
        /// <returns>ShipmentPartsDspResultWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   ShipmentPartsDspResultWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ShipmentPartsDspResultWork()
        {
        }

    }
    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>ShipmentPartsDspResultWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   ShipmentPartsDspResultWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class ShipmentPartsDspResultWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   ShipmentPartsDspResultWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  ShipmentPartsDspResultWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is ShipmentPartsDspResultWork || graph is ArrayList || graph is ShipmentPartsDspResultWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(ShipmentPartsDspResultWork).FullName));

            if (graph != null && graph is ShipmentPartsDspResultWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.ShipmentPartsDspResultWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is ShipmentPartsDspResultWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((ShipmentPartsDspResultWork[])graph).Length;
            }
            else if (graph is ShipmentPartsDspResultWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //企業コード
            serInfo.MemberInfo.Add(typeof(string)); //EnterpriseCode
            //実績集計区分
            serInfo.MemberInfo.Add(typeof(Int32)); //RsltTtlDivCd
            //売上回数
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesTimes
            //売上金額
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesMoney
            //粗利金額
            serInfo.MemberInfo.Add(typeof(Int64)); //GrossProfit


            serInfo.Serialize(writer, serInfo);
            if (graph is ShipmentPartsDspResultWork)
            {
                ShipmentPartsDspResultWork temp = (ShipmentPartsDspResultWork)graph;

                SetShipmentPartsDspResultWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is ShipmentPartsDspResultWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((ShipmentPartsDspResultWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (ShipmentPartsDspResultWork temp in lst)
                {
                    SetShipmentPartsDspResultWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// ShipmentPartsDspResultWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 5;

        /// <summary>
        ///  ShipmentPartsDspResultWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   ShipmentPartsDspResultWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetShipmentPartsDspResultWork(System.IO.BinaryWriter writer, ShipmentPartsDspResultWork temp)
        {
            //企業コード
            writer.Write(temp.EnterpriseCode);
            //実績集計区分
            writer.Write(temp.RsltTtlDivCd);
            //売上回数
            writer.Write(temp.SalesTimes);
            //売上金額
            writer.Write(temp.SalesMoney);
            //粗利金額
            writer.Write(temp.GrossProfit);

        }

        /// <summary>
        ///  ShipmentPartsDspResultWorkインスタンス取得
        /// </summary>
        /// <returns>ShipmentPartsDspResultWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   ShipmentPartsDspResultWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private ShipmentPartsDspResultWork GetShipmentPartsDspResultWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            ShipmentPartsDspResultWork temp = new ShipmentPartsDspResultWork();

            //企業コード
            temp.EnterpriseCode = reader.ReadString();
            //実績集計区分
            temp.RsltTtlDivCd = reader.ReadInt32();
            //売上回数
            temp.SalesTimes = reader.ReadInt32();
            //売上金額
            temp.SalesMoney = reader.ReadInt64();
            //粗利金額
            temp.GrossProfit = reader.ReadInt64();


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
        /// <returns>ShipmentPartsDspResultWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   ShipmentPartsDspResultWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                ShipmentPartsDspResultWork temp = GetShipmentPartsDspResultWork(reader, serInfo);
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
                    retValue = (ShipmentPartsDspResultWork[])lst.ToArray(typeof(ShipmentPartsDspResultWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}
