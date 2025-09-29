using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   StockDayTotalDataWork
    /// <summary>
    ///                      仕入日計累計表データワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   仕入日計累計表データワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2007/09/13  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class StockDayTotalDataWork
    {
        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>仕入拠点コード</summary>
        private string _stockSectionCd = "";

        /// <summary>仕入拠点名称</summary>
        private string _stockSectionNm = "";

        /// <summary>仕入日</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _stockDate;

        /// <summary>仕入担当者コード</summary>
        private string _stockAgentCode = "";

        /// <summary>仕入担当者名称</summary>
        private string _stockAgentName = "";

        /// <summary>仕入先コード</summary>
        private Int32 _supplierCd;

        /// <summary>仕入先名称</summary>
        private string _supplierNm1 = "";

        /// <summary>仕入先名称2</summary>
        private string _supplierNm2 = "";

        /// <summary>仕入額日計</summary>
        /// <remarks>仕入金額(税込)の日計</remarks>
        private Int64 _stockTtlPrice;

        /// <summary>返品額日計</summary>
        private Int64 _retGoodsTtlPrice;

        /// <summary>値引額日計</summary>
        private Int64 _discountTtlPrice;

        /// <summary>純仕入額日計</summary>
        private Int64 _pureStockTtlPrice;


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

        /// public propaty name  :  StockSectionCd
        /// <summary>仕入拠点コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string StockSectionCd
        {
            get { return _stockSectionCd; }
            set { _stockSectionCd = value; }
        }

        /// public propaty name  :  StockSectionNm
        /// <summary>仕入拠点名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入拠点名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string StockSectionNm
        {
            get { return _stockSectionNm; }
            set { _stockSectionNm = value; }
        }

        /// public propaty name  :  StockDate
        /// <summary>仕入日プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime StockDate
        {
            get { return _stockDate; }
            set { _stockDate = value; }
        }

        /// public propaty name  :  StockAgentCode
        /// <summary>仕入担当者コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入担当者コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string StockAgentCode
        {
            get { return _stockAgentCode; }
            set { _stockAgentCode = value; }
        }

        /// public propaty name  :  StockAgentName
        /// <summary>仕入担当者名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入担当者名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string StockAgentName
        {
            get { return _stockAgentName; }
            set { _stockAgentName = value; }
        }

        /// public propaty name  :  SupplierCd
        /// <summary>仕入先コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SupplierCd
        {
            get { return _supplierCd; }
            set { _supplierCd = value; }
        }

        /// public propaty name  :  SupplierNm1
        /// <summary>仕入先名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SupplierNm1
        {
            get { return _supplierNm1; }
            set { _supplierNm1 = value; }
        }

        /// public propaty name  :  SupplierNm2
        /// <summary>仕入先名称2プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先名称2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SupplierNm2
        {
            get { return _supplierNm2; }
            set { _supplierNm2 = value; }
        }

        /// public propaty name  :  StockTtlPrice
        /// <summary>仕入額日計プロパティ</summary>
        /// <value>仕入金額(税込)の日計</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入額日計プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 StockTtlPrice
        {
            get { return _stockTtlPrice; }
            set { _stockTtlPrice = value; }
        }

        /// public propaty name  :  RetGoodsTtlPrice
        /// <summary>返品額日計プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   返品額日計プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 RetGoodsTtlPrice
        {
            get { return _retGoodsTtlPrice; }
            set { _retGoodsTtlPrice = value; }
        }

        /// public propaty name  :  DiscountTtlPrice
        /// <summary>値引額日計プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   値引額日計プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 DiscountTtlPrice
        {
            get { return _discountTtlPrice; }
            set { _discountTtlPrice = value; }
        }

        /// public propaty name  :  PureStockTtlPrice
        /// <summary>純仕入額日計プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   純仕入額日計プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 PureStockTtlPrice
        {
            get { return _pureStockTtlPrice; }
            set { _pureStockTtlPrice = value; }
        }

        /// <summary>
        /// 仕入日計累計表データワークコンストラクタ
        /// </summary>
        /// <returns>StockDayTotalDataWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockDayTotalDataWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public StockDayTotalDataWork()
        {
        }
    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>StockDayTotalDataWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   StockDayTotalDataWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class StockDayTotalDataWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockDayTotalDataWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  StockDayTotalDataWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is StockDayTotalDataWork || graph is ArrayList || graph is StockDayTotalDataWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(StockDayTotalDataWork).FullName));

            if (graph != null && graph is StockDayTotalDataWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.StockDayTotalDataWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is StockDayTotalDataWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((StockDayTotalDataWork[])graph).Length;
            }
            else if (graph is StockDayTotalDataWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //企業コード
            serInfo.MemberInfo.Add(typeof(string)); //EnterpriseCode
            //仕入拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //StockSectionCd
            //仕入拠点名称
            serInfo.MemberInfo.Add(typeof(string)); //StockSectionNm
            //仕入日
            serInfo.MemberInfo.Add(typeof(Int32)); //StockDate
            //仕入担当者コード
            serInfo.MemberInfo.Add(typeof(string)); //StockAgentCode
            //仕入担当者名称
            serInfo.MemberInfo.Add(typeof(string)); //StockAgentName
            //仕入先コード
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierCd
            //仕入先名称
            serInfo.MemberInfo.Add(typeof(string)); //SupplierNm1
            //仕入先名称2
            serInfo.MemberInfo.Add(typeof(string)); //SupplierNm2
            //仕入額日計
            serInfo.MemberInfo.Add(typeof(Int64)); //StockTtlPrice
            //返品額日計
            serInfo.MemberInfo.Add(typeof(Int64)); //RetGoodsTtlPrice
            //値引額日計
            serInfo.MemberInfo.Add(typeof(Int64)); //DiscountTtlPrice
            //純仕入額日計
            serInfo.MemberInfo.Add(typeof(Int64)); //PureStockTtlPrice


            serInfo.Serialize(writer, serInfo);
            if (graph is StockDayTotalDataWork)
            {
                StockDayTotalDataWork temp = (StockDayTotalDataWork)graph;

                SetStockDayTotalDataWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is StockDayTotalDataWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((StockDayTotalDataWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (StockDayTotalDataWork temp in lst)
                {
                    SetStockDayTotalDataWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// StockDayTotalDataWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 13;

        /// <summary>
        ///  StockDayTotalDataWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockDayTotalDataWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetStockDayTotalDataWork(System.IO.BinaryWriter writer, StockDayTotalDataWork temp)
        {
            //企業コード
            writer.Write(temp.EnterpriseCode);
            //仕入拠点コード
            writer.Write(temp.StockSectionCd);
            //仕入拠点名称
            writer.Write(temp.StockSectionNm);
            //仕入日
            writer.Write((Int64)temp.StockDate.Ticks);
            //仕入担当者コード
            writer.Write(temp.StockAgentCode);
            //仕入担当者名称
            writer.Write(temp.StockAgentName);
            //仕入先コード
            writer.Write(temp.SupplierCd);
            //仕入先名称
            writer.Write(temp.SupplierNm1);
            //仕入先名称2
            writer.Write(temp.SupplierNm2);
            //仕入額日計
            writer.Write(temp.StockTtlPrice);
            //返品額日計
            writer.Write(temp.RetGoodsTtlPrice);
            //値引額日計
            writer.Write(temp.DiscountTtlPrice);
            //純仕入額日計
            writer.Write(temp.PureStockTtlPrice);

        }

        /// <summary>
        ///  StockDayTotalDataWorkインスタンス取得
        /// </summary>
        /// <returns>StockDayTotalDataWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockDayTotalDataWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private StockDayTotalDataWork GetStockDayTotalDataWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            StockDayTotalDataWork temp = new StockDayTotalDataWork();

            //企業コード
            temp.EnterpriseCode = reader.ReadString();
            //仕入拠点コード
            temp.StockSectionCd = reader.ReadString();
            //仕入拠点名称
            temp.StockSectionNm = reader.ReadString();
            //仕入日
            temp.StockDate = new DateTime(reader.ReadInt64());
            //仕入担当者コード
            temp.StockAgentCode = reader.ReadString();
            //仕入担当者名称
            temp.StockAgentName = reader.ReadString();
            //仕入先コード
            temp.SupplierCd = reader.ReadInt32();
            //仕入先名称
            temp.SupplierNm1 = reader.ReadString();
            //仕入先名称2
            temp.SupplierNm2 = reader.ReadString();
            //仕入額日計
            temp.StockTtlPrice = reader.ReadInt64();
            //返品額日計
            temp.RetGoodsTtlPrice = reader.ReadInt64();
            //値引額日計
            temp.DiscountTtlPrice = reader.ReadInt64();
            //純仕入額日計
            temp.PureStockTtlPrice = reader.ReadInt64();


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
        /// <returns>StockDayTotalDataWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockDayTotalDataWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                StockDayTotalDataWork temp = GetStockDayTotalDataWork(reader, serInfo);
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
                    retValue = (StockDayTotalDataWork[])lst.ToArray(typeof(StockDayTotalDataWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}
