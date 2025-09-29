using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   StockDayMonthReportDataWork
    /// <summary>
    ///                       仕入日報月報データワークワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :    仕入日報月報データワークワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/08/12  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2009/09/08 黄偉兵</br>
    /// <br>                     PM.NS-2-B・ＰＭ．ＮＳ保守依頼①</br>
    /// <br>                     過去分表示対応</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class StockDayMonthReportDataWork
    {
        /// <summary>拠点コード</summary>
        /// <remarks>※現在未使用</remarks>
        private string _sectionCode = "";

        /// <summary>仕入計上拠点コード</summary>
        /// <remarks>文字型 仕入計上対象の拠点コード(拠点制御の支払計上拠点のこと)</remarks>
        private string _stockAddUpSectionCd = "";

        /// <summary>拠点ガイド名称</summary>
        private string _sectionGuideNm = "";

        /// <summary>仕入先コード</summary>
        private Int32 _supplierCd;

        /// <summary>仕入先略称</summary>
        private string _supplierSnm = "";

        /// <summary>仕入伝票区分（明細）</summary>
        /// <remarks>0:仕入,1:返品,2:値引</remarks>
        private Int32 _stockSlipCdDtl;

        /// <summary>仕入在庫取寄せ区分</summary>
        /// <remarks>0:取寄せ,1:在庫</remarks>
        private Int32 _stockOrderDivCd;

        /// <summary>日計仕入金額</summary>
        /// <remarks>仕入金額（税抜き）</remarks>
        private Int64 _dayStockPriceTaxExc;

        /// <summary>累計仕入金額</summary>
        /// <remarks>仕入金額（税抜き）</remarks>
        private Int64 _monthStockPriceTaxExc;

        // --- ADD 2009/09/08 ---------->>>>>
        /// <summary>仕入数,発注,入荷で使用</summary>
        /// <remarks>仕入数</remarks>
        private Int32 _stockCount;
        // --- ADD 2009/09/08 ----------<<<<<

        /// public propaty name  :  SectionCode
        /// <summary>拠点コードプロパティ</summary>
        /// <value>※現在未使用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SectionCode
        {
            get { return _sectionCode; }
            set { _sectionCode = value; }
        }

        /// public propaty name  :  StockAddUpSectionCd
        /// <summary>仕入計上拠点コードプロパティ</summary>
        /// <value>文字型 仕入計上対象の拠点コード(拠点制御の支払計上拠点のこと)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入計上拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string StockAddUpSectionCd
        {
            get { return _stockAddUpSectionCd; }
            set { _stockAddUpSectionCd = value; }
        }

        /// public propaty name  :  SectionGuideNm
        /// <summary>拠点ガイド名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点ガイド名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SectionGuideNm
        {
            get { return _sectionGuideNm; }
            set { _sectionGuideNm = value; }
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

        /// public propaty name  :  StockSlipCdDtl
        /// <summary>仕入伝票区分（明細）プロパティ</summary>
        /// <value>0:仕入,1:返品,2:値引</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入伝票区分（明細）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 StockSlipCdDtl
        {
            get { return _stockSlipCdDtl; }
            set { _stockSlipCdDtl = value; }
        }

        /// public propaty name  :  StockOrderDivCd
        /// <summary>仕入在庫取寄せ区分プロパティ</summary>
        /// <value>0:取寄せ,1:在庫</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入在庫取寄せ区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 StockOrderDivCd
        {
            get { return _stockOrderDivCd; }
            set { _stockOrderDivCd = value; }
        }

        /// public propaty name  :  DayStockPriceTaxExc
        /// <summary>日計仕入金額プロパティ</summary>
        /// <value>仕入金額（税抜き）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   日計仕入金額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 DayStockPriceTaxExc
        {
            get { return _dayStockPriceTaxExc; }
            set { _dayStockPriceTaxExc = value; }
        }

        /// public propaty name  :  MonthStockPriceTaxExc
        /// <summary>累計仕入金額プロパティ</summary>
        /// <value>仕入金額（税抜き）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   累計仕入金額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 MonthStockPriceTaxExc
        {
            get { return _monthStockPriceTaxExc; }
            set { _monthStockPriceTaxExc = value; }
        }


        // --- ADD 2009/09/08 ---------->>>>>
        /// public propaty name  :  OrderCnt
        /// <summary>仕入数,発注,入荷で使用</summary>
        /// <value>仕入数</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入数</br>
        /// <br>Programer        :   KOIHEI ADD 2009/09/07</br>
        /// </remarks>
        public Int32 StockCount
        {
            get { return _stockCount; }
            set { _stockCount = value; }
        }
        // --- ADD 2009/09/08 ----------<<<<<

        /// <summary>
        ///  仕入日報月報データワークワークコンストラクタ
        /// </summary>
        /// <returns>StockDayMonthReportDataWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockDayMonthReportDataWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public StockDayMonthReportDataWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>StockDayMonthReportDataWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   StockDayMonthReportDataWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class StockDayMonthReportDataWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockDayMonthReportDataWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  StockDayMonthReportDataWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is StockDayMonthReportDataWork || graph is ArrayList || graph is StockDayMonthReportDataWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(StockDayMonthReportDataWork).FullName));

            if (graph != null && graph is StockDayMonthReportDataWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.StockDayMonthReportDataWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is StockDayMonthReportDataWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((StockDayMonthReportDataWork[])graph).Length;
            }
            else if (graph is StockDayMonthReportDataWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //SectionCode
            //仕入計上拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //StockAddUpSectionCd
            //拠点ガイド名称
            serInfo.MemberInfo.Add(typeof(string)); //SectionGuideNm
            //仕入先コード
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierCd
            //仕入先略称
            serInfo.MemberInfo.Add(typeof(string)); //SupplierSnm
            //仕入伝票区分（明細）
            serInfo.MemberInfo.Add(typeof(Int32)); //StockSlipCdDtl
            //仕入在庫取寄せ区分
            serInfo.MemberInfo.Add(typeof(Int32)); //StockOrderDivCd
            //日計仕入金額
            serInfo.MemberInfo.Add(typeof(Int64)); //DayStockPriceTaxExc
            //累計仕入金額
            serInfo.MemberInfo.Add(typeof(Int64)); //MonthStockPriceTaxExc
            // --- ADD 2009/09/08 ---------->>>>> 
            //仕入数
            serInfo.MemberInfo.Add(typeof(Double)); //OrderCnt
            // --- ADD 2009/09/08 ----------<<<<<


            serInfo.Serialize(writer, serInfo);
            if (graph is StockDayMonthReportDataWork)
            {
                StockDayMonthReportDataWork temp = (StockDayMonthReportDataWork)graph;

                SetStockDayMonthReportDataWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is StockDayMonthReportDataWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((StockDayMonthReportDataWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (StockDayMonthReportDataWork temp in lst)
                {
                    SetStockDayMonthReportDataWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// StockDayMonthReportDataWorkメンバ数(publicプロパティ数)
        /// </summary>
        // --- UPD 2009/09/08 ---------->>>>> 
        //private const int currentMemberCount = 9;
        //仕入数
        private const int currentMemberCount = 10;
        // --- UPD 2009/09/08 ----------<<<<<

        /// <summary>
        ///  StockDayMonthReportDataWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockDayMonthReportDataWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// <br>Update Note  : 2009/09/08 黄偉兵 過去分表示対応</br>
        /// </remarks>
        private void SetStockDayMonthReportDataWork(System.IO.BinaryWriter writer, StockDayMonthReportDataWork temp)
        {
            //拠点コード
            writer.Write(temp.SectionCode);
            //仕入計上拠点コード
            writer.Write(temp.StockAddUpSectionCd);
            //拠点ガイド名称
            writer.Write(temp.SectionGuideNm);
            //仕入先コード
            writer.Write(temp.SupplierCd);
            //仕入先略称
            writer.Write(temp.SupplierSnm);
            //仕入伝票区分（明細）
            writer.Write(temp.StockSlipCdDtl);
            //仕入在庫取寄せ区分
            writer.Write(temp.StockOrderDivCd);
            //日計仕入金額
            writer.Write(temp.DayStockPriceTaxExc);
            //累計仕入金額
            writer.Write(temp.MonthStockPriceTaxExc);
            //仕入数
            writer.Write(temp.StockCount); // ADD 2009/09/08

        }

        /// <summary>
        ///  StockDayMonthReportDataWorkインスタンス取得
        /// </summary>
        /// <returns>StockDayMonthReportDataWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockDayMonthReportDataWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// <br>Update Note  : 2009/09/08 黄偉兵 過去分表示対応</br>
        /// </remarks>
        private StockDayMonthReportDataWork GetStockDayMonthReportDataWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            StockDayMonthReportDataWork temp = new StockDayMonthReportDataWork();

            //拠点コード
            temp.SectionCode = reader.ReadString();
            //仕入計上拠点コード
            temp.StockAddUpSectionCd = reader.ReadString();
            //拠点ガイド名称
            temp.SectionGuideNm = reader.ReadString();
            //仕入先コード
            temp.SupplierCd = reader.ReadInt32();
            //仕入先略称
            temp.SupplierSnm = reader.ReadString();
            //仕入伝票区分（明細）
            temp.StockSlipCdDtl = reader.ReadInt32();
            //仕入在庫取寄せ区分
            temp.StockOrderDivCd = reader.ReadInt32();
            //日計仕入金額
            temp.DayStockPriceTaxExc = reader.ReadInt64();
            //累計仕入金額
            temp.MonthStockPriceTaxExc = reader.ReadInt64();
            //仕入数
            temp.StockCount = reader.ReadInt32(); // ADD 2009/09/08


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
        /// <returns>StockDayMonthReportDataWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockDayMonthReportDataWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                StockDayMonthReportDataWork temp = GetStockDayMonthReportDataWork(reader, serInfo);
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
                    retValue = (StockDayMonthReportDataWork[])lst.ToArray(typeof(StockDayMonthReportDataWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}
