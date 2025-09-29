using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   SlipHistAnalyzeResultWork
    /// <summary>
    ///                      仕入分析表抽出結果クラスワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   仕入分析表抽出結果クラスワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/11/13  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class SlipHistAnalyzeResultWork
    {
        /// <summary>計上拠点コード</summary>
        /// <remarks>集計の対象となっている拠点コード</remarks>
        private string _addUpSecCode = "";

        /// <summary>拠点ガイド略称</summary>
        /// <remarks>帳票印字用</remarks>
        private string _sectionGuideSnm = "";

        /// <summary>仕入先コード</summary>
        private Int32 _supplierCd;

        /// <summary>仕入先略称</summary>
        private string _supplierSnm = "";

        /// <summary>仕入金額合計(当月)</summary>
        private Int64 _totalPrice;

        /// <summary>仕入返品額(当月)</summary>
        private Int64 _retGoodsPrice;

        /// <summary>仕入値引計(当月)</summary>
        private Int64 _totalDiscount;

        /// <summary>仕入金額合計(当月在庫)</summary>
        private Int64 _totalPriceStock;

        /// <summary>仕入金額合計(当月合計)</summary>
        private Int64 _totalPriceTotal;

        /// <summary>仕入金額合計(当期)</summary>
        private Int64 _annualTotalPrice;

        /// <summary>仕入返品額(当期)</summary>
        private Int64 _annualRetGoodsPrice;

        /// <summary>仕入値引計(当期)</summary>
        private Int64 _annualTotalDiscount;

        /// <summary>仕入金額合計(当期在庫)</summary>
        private Int64 _annualTotalPriceStock;

        /// <summary>仕入金額合計(当期合計)</summary>
        private Int64 _annualTotalPriceTotal;


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

        /// public propaty name  :  SectionGuideSnm
        /// <summary>拠点ガイド略称プロパティ</summary>
        /// <value>帳票印字用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点ガイド略称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SectionGuideSnm
        {
            get { return _sectionGuideSnm; }
            set { _sectionGuideSnm = value; }
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

        /// public propaty name  :  SupplierSnm
        /// <summary>仕入先略称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先略称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SupplierSnm
        {
            get { return _supplierSnm; }
            set { _supplierSnm = value; }
        }

        /// public propaty name  :  TotalPrice
        /// <summary>仕入金額合計(当月)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入金額合計(当月)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 TotalPrice
        {
            get { return _totalPrice; }
            set { _totalPrice = value; }
        }

        /// public propaty name  :  RetGoodsPrice
        /// <summary>仕入返品額(当月)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入返品額(当月)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 RetGoodsPrice
        {
            get { return _retGoodsPrice; }
            set { _retGoodsPrice = value; }
        }

        /// public propaty name  :  TotalDiscount
        /// <summary>仕入値引計(当月)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入値引計(当月)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 TotalDiscount
        {
            get { return _totalDiscount; }
            set { _totalDiscount = value; }
        }

        /// public propaty name  :  TotalPriceStock
        /// <summary>仕入金額合計(当月在庫)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入金額合計(当月在庫)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 TotalPriceStock
        {
            get { return _totalPriceStock; }
            set { _totalPriceStock = value; }
        }

        /// public propaty name  :  TotalPriceTotal
        /// <summary>仕入金額合計(当月合計)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入金額合計(当月合計)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 TotalPriceTotal
        {
            get { return _totalPriceTotal; }
            set { _totalPriceTotal = value; }
        }

        /// public propaty name  :  AnnualTotalPrice
        /// <summary>仕入金額合計(当期)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入金額合計(当期)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 AnnualTotalPrice
        {
            get { return _annualTotalPrice; }
            set { _annualTotalPrice = value; }
        }

        /// public propaty name  :  AnnualRetGoodsPrice
        /// <summary>仕入返品額(当期)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入返品額(当期)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 AnnualRetGoodsPrice
        {
            get { return _annualRetGoodsPrice; }
            set { _annualRetGoodsPrice = value; }
        }

        /// public propaty name  :  AnnualTotalDiscount
        /// <summary>仕入値引計(当期)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入値引計(当期)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 AnnualTotalDiscount
        {
            get { return _annualTotalDiscount; }
            set { _annualTotalDiscount = value; }
        }

        /// public propaty name  :  AnnualTotalPriceStock
        /// <summary>仕入金額合計(当期在庫)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入金額合計(当期在庫)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 AnnualTotalPriceStock
        {
            get { return _annualTotalPriceStock; }
            set { _annualTotalPriceStock = value; }
        }

        /// public propaty name  :  AnnualTotalPriceTotal
        /// <summary>仕入金額合計(当期合計)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入金額合計(当期合計)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 AnnualTotalPriceTotal
        {
            get { return _annualTotalPriceTotal; }
            set { _annualTotalPriceTotal = value; }
        }


        /// <summary>
        /// 仕入分析表抽出結果クラスワークコンストラクタ
        /// </summary>
        /// <returns>SlipHistAnalyzeResultWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SlipHistAnalyzeResultWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SlipHistAnalyzeResultWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>SlipHistAnalyzeResultWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   SlipHistAnalyzeResultWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class SlipHistAnalyzeResultWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   SlipHistAnalyzeResultWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  SlipHistAnalyzeResultWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is SlipHistAnalyzeResultWork || graph is ArrayList || graph is SlipHistAnalyzeResultWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(SlipHistAnalyzeResultWork).FullName));

            if (graph != null && graph is SlipHistAnalyzeResultWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.SlipHistAnalyzeResultWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is SlipHistAnalyzeResultWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((SlipHistAnalyzeResultWork[])graph).Length;
            }
            else if (graph is SlipHistAnalyzeResultWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //計上拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //AddUpSecCode
            //拠点ガイド略称
            serInfo.MemberInfo.Add(typeof(string)); //SectionGuideSnm
            //仕入先コード
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierCd
            //仕入先略称
            serInfo.MemberInfo.Add(typeof(string)); //SupplierSnm
            //仕入金額合計(当月)
            serInfo.MemberInfo.Add(typeof(Int64)); //TotalPrice
            //仕入返品額(当月)
            serInfo.MemberInfo.Add(typeof(Int64)); //RetGoodsPrice
            //仕入値引計(当月)
            serInfo.MemberInfo.Add(typeof(Int64)); //TotalDiscount
            //仕入金額合計(当月在庫)
            serInfo.MemberInfo.Add(typeof(Int64)); //TotalPriceStock
            //仕入金額合計(当月合計)
            serInfo.MemberInfo.Add(typeof(Int64)); //TotalPriceTotal
            //仕入金額合計(当期)
            serInfo.MemberInfo.Add(typeof(Int64)); //AnnualTotalPrice
            //仕入返品額(当期)
            serInfo.MemberInfo.Add(typeof(Int64)); //AnnualRetGoodsPrice
            //仕入値引計(当期)
            serInfo.MemberInfo.Add(typeof(Int64)); //AnnualTotalDiscount
            //仕入金額合計(当期在庫)
            serInfo.MemberInfo.Add(typeof(Int64)); //AnnualTotalPriceStock
            //仕入金額合計(当期合計)
            serInfo.MemberInfo.Add(typeof(Int64)); //AnnualTotalPriceTotal


            serInfo.Serialize(writer, serInfo);
            if (graph is SlipHistAnalyzeResultWork)
            {
                SlipHistAnalyzeResultWork temp = (SlipHistAnalyzeResultWork)graph;

                SetSlipHistAnalyzeResultWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is SlipHistAnalyzeResultWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((SlipHistAnalyzeResultWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (SlipHistAnalyzeResultWork temp in lst)
                {
                    SetSlipHistAnalyzeResultWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// SlipHistAnalyzeResultWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 14;

        /// <summary>
        ///  SlipHistAnalyzeResultWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   SlipHistAnalyzeResultWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetSlipHistAnalyzeResultWork(System.IO.BinaryWriter writer, SlipHistAnalyzeResultWork temp)
        {
            //計上拠点コード
            writer.Write(temp.AddUpSecCode);
            //拠点ガイド略称
            writer.Write(temp.SectionGuideSnm);
            //仕入先コード
            writer.Write(temp.SupplierCd);
            //仕入先略称
            writer.Write(temp.SupplierSnm);
            //仕入金額合計(当月)
            writer.Write(temp.TotalPrice);
            //仕入返品額(当月)
            writer.Write(temp.RetGoodsPrice);
            //仕入値引計(当月)
            writer.Write(temp.TotalDiscount);
            //仕入金額合計(当月在庫)
            writer.Write(temp.TotalPriceStock);
            //仕入金額合計(当月合計)
            writer.Write(temp.TotalPriceTotal);
            //仕入金額合計(当期)
            writer.Write(temp.AnnualTotalPrice);
            //仕入返品額(当期)
            writer.Write(temp.AnnualRetGoodsPrice);
            //仕入値引計(当期)
            writer.Write(temp.AnnualTotalDiscount);
            //仕入金額合計(当期在庫)
            writer.Write(temp.AnnualTotalPriceStock);
            //仕入金額合計(当期合計)
            writer.Write(temp.AnnualTotalPriceTotal);

        }

        /// <summary>
        ///  SlipHistAnalyzeResultWorkインスタンス取得
        /// </summary>
        /// <returns>SlipHistAnalyzeResultWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SlipHistAnalyzeResultWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private SlipHistAnalyzeResultWork GetSlipHistAnalyzeResultWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            SlipHistAnalyzeResultWork temp = new SlipHistAnalyzeResultWork();

            //計上拠点コード
            temp.AddUpSecCode = reader.ReadString();
            //拠点ガイド略称
            temp.SectionGuideSnm = reader.ReadString();
            //仕入先コード
            temp.SupplierCd = reader.ReadInt32();
            //仕入先略称
            temp.SupplierSnm = reader.ReadString();
            //仕入金額合計(当月)
            temp.TotalPrice = reader.ReadInt64();
            //仕入返品額(当月)
            temp.RetGoodsPrice = reader.ReadInt64();
            //仕入値引計(当月)
            temp.TotalDiscount = reader.ReadInt64();
            //仕入金額合計(当月在庫)
            temp.TotalPriceStock = reader.ReadInt64();
            //仕入金額合計(当月合計)
            temp.TotalPriceTotal = reader.ReadInt64();
            //仕入金額合計(当期)
            temp.AnnualTotalPrice = reader.ReadInt64();
            //仕入返品額(当期)
            temp.AnnualRetGoodsPrice = reader.ReadInt64();
            //仕入値引計(当期)
            temp.AnnualTotalDiscount = reader.ReadInt64();
            //仕入金額合計(当期在庫)
            temp.AnnualTotalPriceStock = reader.ReadInt64();
            //仕入金額合計(当期合計)
            temp.AnnualTotalPriceTotal = reader.ReadInt64();


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
        /// <returns>SlipHistAnalyzeResultWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SlipHistAnalyzeResultWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                SlipHistAnalyzeResultWork temp = GetSlipHistAnalyzeResultWork(reader, serInfo);
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
                    retValue = (SlipHistAnalyzeResultWork[])lst.ToArray(typeof(SlipHistAnalyzeResultWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

}
