using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   PriceUpdManualDataWork
    /// <summary>
    ///                      価格改正処理日付取得(手動)データクラスワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   価格改正処理日付取得(手動)データクラスワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2009/01/14  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class PriceUpdManualDataWork
    {
        /// <summary>提供日付</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _offerDate;

        /// <summary>最新提供日付</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _reNewOfferDate;

        /// <summary>対象データ件数</summary>
        private Int32 _dataCnt;

        /// <summary>全対象データ件数</summary>
        private Int32 _allDatacnt;

        /// <summary>対象データ区分</summary>
        /// <remarks>0:BLコードマスタ,1:BLグループマスタ,2:中分類マスタ,3:車種マスタ,4:メーカーマスタ,5:優良設定変更マスタ</remarks>
        private Int32 _dataDiv;


        /// public propaty name  :  OfferDate
        /// <summary>提供日付プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   提供日付プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime OfferDate
        {
            get { return _offerDate; }
            set { _offerDate = value; }
        }

        /// public propaty name  :  ReNewOfferDate
        /// <summary>最新提供日付プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   最新提供日付プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime ReNewOfferDate
        {
            get { return _reNewOfferDate; }
            set { _reNewOfferDate = value; }
        }

        /// public propaty name  :  dataCnt
        /// <summary>対象データ件数プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   対象データ件数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 dataCnt
        {
            get { return _dataCnt; }
            set { _dataCnt = value; }
        }

        /// public propaty name  :  allDatacnt
        /// <summary>全対象データ件数プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   全対象データ件数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 allDatacnt
        {
            get { return _allDatacnt; }
            set { _allDatacnt = value; }
        }

        /// public propaty name  :  dataDiv
        /// <summary>対象データ区分プロパティ</summary>
        /// <value>0:BLコードマスタ,1:BLグループマスタ,2:中分類マスタ,3:車種マスタ,4:メーカーマスタ,5:優良設定変更マスタ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   対象データ区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 dataDiv
        {
            get { return _dataDiv; }
            set { _dataDiv = value; }
        }


        /// <summary>
        /// 価格改正処理日付取得(手動)データクラスワークコンストラクタ
        /// </summary>
        /// <returns>PriceUpdManualDataWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PriceUpdManualDataWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public PriceUpdManualDataWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>PriceUpdManualDataWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   PriceUpdManualDataWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class PriceUpdManualDataWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   PriceUpdManualDataWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  PriceUpdManualDataWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is PriceUpdManualDataWork || graph is ArrayList || graph is PriceUpdManualDataWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(PriceUpdManualDataWork).FullName));

            if (graph != null && graph is PriceUpdManualDataWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.PriceUpdManualDataWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is PriceUpdManualDataWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((PriceUpdManualDataWork[])graph).Length;
            }
            else if (graph is PriceUpdManualDataWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //提供日付
            serInfo.MemberInfo.Add(typeof(Int32)); //OfferDate
            //最新提供日付
            serInfo.MemberInfo.Add(typeof(Int32)); //ReNewOfferDate
            //対象データ件数
            serInfo.MemberInfo.Add(typeof(Int32)); //dataCnt
            //全対象データ件数
            serInfo.MemberInfo.Add(typeof(Int32)); //allDatacnt
            //対象データ区分
            serInfo.MemberInfo.Add(typeof(Int32)); //dataDiv


            serInfo.Serialize(writer, serInfo);
            if (graph is PriceUpdManualDataWork)
            {
                PriceUpdManualDataWork temp = (PriceUpdManualDataWork)graph;

                SetPriceUpdManualDataWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is PriceUpdManualDataWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((PriceUpdManualDataWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (PriceUpdManualDataWork temp in lst)
                {
                    SetPriceUpdManualDataWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// PriceUpdManualDataWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 5;

        /// <summary>
        ///  PriceUpdManualDataWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   PriceUpdManualDataWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetPriceUpdManualDataWork(System.IO.BinaryWriter writer, PriceUpdManualDataWork temp)
        {
            //提供日付
            writer.Write((Int64)temp.OfferDate.Ticks);
            //最新提供日付
            writer.Write((Int64)temp.OfferDate.Ticks);
            //対象データ件数
            writer.Write(temp.dataCnt);
            //全対象データ件数
            writer.Write(temp.allDatacnt);
            //対象データ区分
            writer.Write(temp.dataDiv);

        }

        /// <summary>
        ///  PriceUpdManualDataWorkインスタンス取得
        /// </summary>
        /// <returns>PriceUpdManualDataWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PriceUpdManualDataWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private PriceUpdManualDataWork GetPriceUpdManualDataWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            PriceUpdManualDataWork temp = new PriceUpdManualDataWork();

            //提供日付
            temp.OfferDate = new DateTime(reader.ReadInt64());
            //最新提供日付
            temp.ReNewOfferDate = new DateTime(reader.ReadInt64());
            //対象データ件数
            temp.dataCnt = reader.ReadInt32();
            //全対象データ件数
            temp.allDatacnt = reader.ReadInt32();
            //対象データ区分
            temp.dataDiv = reader.ReadInt32();


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
        /// <returns>PriceUpdManualDataWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PriceUpdManualDataWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                PriceUpdManualDataWork temp = GetPriceUpdManualDataWork(reader, serInfo);
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
                    retValue = (PriceUpdManualDataWork[])lst.ToArray(typeof(PriceUpdManualDataWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }


}
