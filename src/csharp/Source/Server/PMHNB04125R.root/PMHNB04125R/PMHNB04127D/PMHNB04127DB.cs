using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   CustomInqResultWork
    /// <summary>
    ///                      得意先過年度実績照会抽出結果クラスワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   得意先過年度実績照会抽出結果クラスワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/10/09  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class CustomInqResultWork
    {
        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>計上拠点コード</summary>
        /// <remarks>集計の対象となっている拠点コード</remarks>
        private string _addUpSecCode = "";

        /// <summary>得意先コード</summary>
        /// <remarks>納入先の場合の使用可能項目</remarks>
        private Int32 _customerCode;

        /// <summary>売上金額</summary>
        /// <remarks>税抜き（値引,返品含まず）</remarks>
        private Int64 _salesMoney;

        /// <summary>返品額</summary>
        private Int64 _salesRetGoodsPrice;

        /// <summary>値引金額</summary>
        private Int64 _discountPrice;

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

        /// public propaty name  :  AddUpSecCode
        /// <summary>計上拠点コードプロパティ</summary>
        /// <value>集計の対象となっている拠点コード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   計上拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AddUpSecCode
        {
            get { return _addUpSecCode; }
            set { _addUpSecCode = value; }
        }

        /// public propaty name  :  CustomerCode
        /// <summary>得意先コードプロパティ</summary>
        /// <value>納入先の場合の使用可能項目</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CustomerCode
        {
            get { return _customerCode; }
            set { _customerCode = value; }
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

        /// public propaty name  :  SalesRetGoodsPrice
        /// <summary>返品額プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   返品額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesRetGoodsPrice
        {
            get { return _salesRetGoodsPrice; }
            set { _salesRetGoodsPrice = value; }
        }

        /// public propaty name  :  DiscountPrice
        /// <summary>値引金額プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   値引金額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 DiscountPrice
        {
            get { return _discountPrice; }
            set { _discountPrice = value; }
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
        /// 得意先過年度実績照会抽出結果クラスワークコンストラクタ
        /// </summary>
        /// <returns>CustomInqResultWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CustomInqResultWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public CustomInqResultWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>CustomInqResultWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   CustomInqResultWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class CustomInqResultWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   CustomInqResultWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  CustomInqResultWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is CustomInqResultWork || graph is ArrayList || graph is CustomInqResultWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(CustomInqResultWork).FullName));

            if (graph != null && graph is CustomInqResultWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.CustomInqResultWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is CustomInqResultWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((CustomInqResultWork[])graph).Length;
            }
            else if (graph is CustomInqResultWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //企業コード
            serInfo.MemberInfo.Add(typeof(string)); //EnterpriseCode
            //計上拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //AddUpSecCode
            //得意先コード
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerCode
            //売上金額
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesMoney
            //返品額
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesRetGoodsPrice
            //値引金額
            serInfo.MemberInfo.Add(typeof(Int64)); //DiscountPrice
            //粗利金額
            serInfo.MemberInfo.Add(typeof(Int64)); //GrossProfit


            serInfo.Serialize(writer, serInfo);
            if (graph is CustomInqResultWork)
            {
                CustomInqResultWork temp = (CustomInqResultWork)graph;

                SetCustomInqResultWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is CustomInqResultWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((CustomInqResultWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (CustomInqResultWork temp in lst)
                {
                    SetCustomInqResultWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// CustomInqResultWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 7;

        /// <summary>
        ///  CustomInqResultWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   CustomInqResultWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetCustomInqResultWork(System.IO.BinaryWriter writer, CustomInqResultWork temp)
        {
            //企業コード
            writer.Write(temp.EnterpriseCode);
            //計上拠点コード
            writer.Write(temp.AddUpSecCode);
            //得意先コード
            writer.Write(temp.CustomerCode);
            //売上金額
            writer.Write(temp.SalesMoney);
            //返品額
            writer.Write(temp.SalesRetGoodsPrice);
            //値引金額
            writer.Write(temp.DiscountPrice);
            //粗利金額
            writer.Write(temp.GrossProfit);

        }

        /// <summary>
        ///  CustomInqResultWorkインスタンス取得
        /// </summary>
        /// <returns>CustomInqResultWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CustomInqResultWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private CustomInqResultWork GetCustomInqResultWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            CustomInqResultWork temp = new CustomInqResultWork();

            //企業コード
            temp.EnterpriseCode = reader.ReadString();
            //計上拠点コード
            temp.AddUpSecCode = reader.ReadString();
            //得意先コード
            temp.CustomerCode = reader.ReadInt32();
            //売上金額
            temp.SalesMoney = reader.ReadInt64();
            //返品額
            temp.SalesRetGoodsPrice = reader.ReadInt64();
            //値引金額
            temp.DiscountPrice = reader.ReadInt64();
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
        /// <returns>CustomInqResultWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CustomInqResultWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                CustomInqResultWork temp = GetCustomInqResultWork(reader, serInfo);
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
                    retValue = (CustomInqResultWork[])lst.ToArray(typeof(CustomInqResultWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

}
