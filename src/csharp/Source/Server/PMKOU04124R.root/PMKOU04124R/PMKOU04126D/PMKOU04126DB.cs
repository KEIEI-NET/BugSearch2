using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   SuppYearResultSuppResultWork
    /// <summary>
    ///                      仕入年間実績照会(実績照会)抽出結果クラスワークワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   仕入年間実績照会(実績照会)抽出結果クラスワークワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/11/20  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class SuppYearResultSuppResultWork
    {
        /// <summary>計上年月</summary>
        /// <remarks>YYYYMM</remarks>
        private DateTime _addUpYearMonth;

        /// <summary>仕入金額（税抜き）(在庫)</summary>
        private Int64 _st_StockPriceTaxExc;

        /// <summary>仕入返品額(在庫)</summary>
        private Int64 _st_StockRetGoodsPrice;

        /// <summary>仕入値引計(在庫)</summary>
        private Int64 _st_StockTotalDiscount;

        /// <summary>仕入金額消費税額（在庫）</summary>
        private Int64 _st_StockPriceConsTax;

        /// <summary>仕入金額（税抜き）(取寄)</summary>
        private Int64 _or_StockPriceTaxExc;

        /// <summary>仕入返品額(取寄)</summary>
        private Int64 _or_StockRetGoodsPrice;

        /// <summary>仕入値引計(取寄)</summary>
        private Int64 _or_StockTotalDiscount;

        /// <summary>仕入金額消費税額（在庫）</summary>
        private Int64 _or_StockPriceConsTax;

        // --- ADD 2010/07/20-------------------------------->>>>>
        /// <summary>拠点コード</summary>
        private string _stockSectionCd;

        /// <summary>仕入先コード</summary>
        private Int32 _supplierCd;

        /// <summary>拠点名称</summary>
        private string _sectionGuideNm;

        /// <summary>仕入先名称</summary>
        private string _supplierNm;
        // --- ADD 2010/07/20--------------------------------<<<<<


        /// public propaty name  :  AddUpYearMonth
        /// <summary>計上年月プロパティ</summary>
        /// <value>YYYYMM</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   計上年月プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime AddUpYearMonth
        {
            get { return _addUpYearMonth; }
            set { _addUpYearMonth = value; }
        }

        /// public propaty name  :  St_StockPriceTaxExc
        /// <summary>仕入金額（税抜き）(在庫)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入金額（税抜き）(在庫)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 St_StockPriceTaxExc
        {
            get { return _st_StockPriceTaxExc; }
            set { _st_StockPriceTaxExc = value; }
        }

        /// public propaty name  :  St_StockRetGoodsPrice
        /// <summary>仕入返品額(在庫)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入返品額(在庫)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 St_StockRetGoodsPrice
        {
            get { return _st_StockRetGoodsPrice; }
            set { _st_StockRetGoodsPrice = value; }
        }

        /// public propaty name  :  St_StockTotalDiscount
        /// <summary>仕入値引計(在庫)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入値引計(在庫)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 St_StockTotalDiscount
        {
            get { return _st_StockTotalDiscount; }
            set { _st_StockTotalDiscount = value; }
        }

        /// public propaty name  :  St_StockPriceConsTax
        /// <summary>仕入金額消費税額（在庫）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入金額消費税額（在庫）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 St_StockPriceConsTax
        {
            get { return _st_StockPriceConsTax; }
            set { _st_StockPriceConsTax = value; }
        }

        /// public propaty name  :  Or_StockPriceTaxExc
        /// <summary>仕入金額（税抜き）(取寄)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入金額（税抜き）(取寄)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 Or_StockPriceTaxExc
        {
            get { return _or_StockPriceTaxExc; }
            set { _or_StockPriceTaxExc = value; }
        }

        /// public propaty name  :  Or_StockRetGoodsPrice
        /// <summary>仕入返品額(取寄)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入返品額(取寄)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 Or_StockRetGoodsPrice
        {
            get { return _or_StockRetGoodsPrice; }
            set { _or_StockRetGoodsPrice = value; }
        }

        /// public propaty name  :  Or_StockTotalDiscount
        /// <summary>仕入値引計(取寄)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入値引計(取寄)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 Or_StockTotalDiscount
        {
            get { return _or_StockTotalDiscount; }
            set { _or_StockTotalDiscount = value; }
        }

        /// public propaty name  :  Or_StockPriceConsTax
        /// <summary>仕入金額消費税額（在庫）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入金額消費税額（在庫）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 Or_StockPriceConsTax
        {
            get { return _or_StockPriceConsTax; }
            set { _or_StockPriceConsTax = value; }
        }

        // --- ADD 2010/07/20-------------------------------->>>>>
        /// public propaty name  :  StockSectionCd
        /// <summary>拠点コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string StockSectionCd
        {
            get { return _stockSectionCd; }
            set { _stockSectionCd = value; }
        }

        /// public propaty name  :  SupplierCd
        /// <summary>仕入先コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SupplierCd
        {
            get { return _supplierCd; }
            set { _supplierCd = value; }
        }

        /// public propaty name  :  SectionGuideNm
        /// <summary>拠点名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SectionGuideNm
        {
            get { return _sectionGuideNm; }
            set { _sectionGuideNm = value; }
        }

        /// public propaty name  :  SectionGuideNm
        /// <summary>仕入先名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SupplierNm
        {
            get { return _supplierNm; }
            set { _supplierNm = value; }
        }
        // --- ADD 2010/07/20--------------------------------<<<<<

        /// <summary>
        /// 仕入年間実績照会(実績照会)抽出結果クラスワークワークコンストラクタ
        /// </summary>
        /// <returns>SuppYearResultSuppResultWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SuppYearResultSuppResultWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SuppYearResultSuppResultWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>SuppYearResultSuppResultWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   SuppYearResultSuppResultWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class SuppYearResultSuppResultWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   SuppYearResultSuppResultWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  SuppYearResultSuppResultWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is SuppYearResultSuppResultWork || graph is ArrayList || graph is SuppYearResultSuppResultWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(SuppYearResultSuppResultWork).FullName));

            if (graph != null && graph is SuppYearResultSuppResultWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.SuppYearResultSuppResultWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is SuppYearResultSuppResultWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((SuppYearResultSuppResultWork[])graph).Length;
            }
            else if (graph is SuppYearResultSuppResultWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //計上年月
            serInfo.MemberInfo.Add(typeof(Int32)); //AddUpYearMonth
            //仕入金額（税抜き）(在庫)
            serInfo.MemberInfo.Add(typeof(Int64)); //St_StockPriceTaxExc
            //仕入返品額(在庫)
            serInfo.MemberInfo.Add(typeof(Int64)); //St_StockRetGoodsPrice
            //仕入値引計(在庫)
            serInfo.MemberInfo.Add(typeof(Int64)); //St_StockTotalDiscount
            //仕入金額消費税額（在庫）
            serInfo.MemberInfo.Add(typeof(Int64)); //St_StockPriceConsTax
            //仕入金額（税抜き）(取寄)
            serInfo.MemberInfo.Add(typeof(Int64)); //Or_StockPriceTaxExc
            //仕入返品額(取寄)
            serInfo.MemberInfo.Add(typeof(Int64)); //Or_StockRetGoodsPrice
            //仕入値引計(取寄)
            serInfo.MemberInfo.Add(typeof(Int64)); //Or_StockTotalDiscount
            //仕入金額消費税額（在庫）
            serInfo.MemberInfo.Add(typeof(Int64)); //Or_StockPriceConsTax

            // --- ADD 2010/07/20-------------------------------->>>>>
            //拠点コード
            serInfo.MemberInfo.Add(typeof(String)); //StockSectionCd
            //仕入先コード
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierCd
            //拠点名称
            serInfo.MemberInfo.Add(typeof(String)); //SectionGuideNm
            //仕入先名称
            serInfo.MemberInfo.Add(typeof(String)); //SupplierNm
            // --- ADD 2010/07/20--------------------------------<<<<<


            serInfo.Serialize(writer, serInfo);
            if (graph is SuppYearResultSuppResultWork)
            {
                SuppYearResultSuppResultWork temp = (SuppYearResultSuppResultWork)graph;

                SetSuppYearResultSuppResultWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is SuppYearResultSuppResultWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((SuppYearResultSuppResultWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (SuppYearResultSuppResultWork temp in lst)
                {
                    SetSuppYearResultSuppResultWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// SuppYearResultSuppResultWorkメンバ数(publicプロパティ数)
        /// </summary>
        // private const int currentMemberCount = 9; // DEL 2010/07/20
        private const int currentMemberCount = 13; // ADD 2010/07/20

        /// <summary>
        ///  SuppYearResultSuppResultWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   SuppYearResultSuppResultWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetSuppYearResultSuppResultWork(System.IO.BinaryWriter writer, SuppYearResultSuppResultWork temp)
        {
            //計上年月
            writer.Write((Int64)temp.AddUpYearMonth.Ticks);
            //仕入金額（税抜き）(在庫)
            writer.Write(temp.St_StockPriceTaxExc);
            //仕入返品額(在庫)
            writer.Write(temp.St_StockRetGoodsPrice);
            //仕入値引計(在庫)
            writer.Write(temp.St_StockTotalDiscount);
            //仕入金額消費税額（在庫）
            writer.Write(temp.St_StockPriceConsTax);
            //仕入金額（税抜き）(取寄)
            writer.Write(temp.Or_StockPriceTaxExc);
            //仕入返品額(取寄)
            writer.Write(temp.Or_StockRetGoodsPrice);
            //仕入値引計(取寄)
            writer.Write(temp.Or_StockTotalDiscount);
            //仕入金額消費税額（在庫）
            writer.Write(temp.Or_StockPriceConsTax);

            // --- ADD 2010/07/20-------------------------------->>>>>
            //拠点コード
            writer.Write(temp.StockSectionCd);
            //仕入先コード
            writer.Write(temp.SupplierCd);
            //拠点名称
            writer.Write(temp.SectionGuideNm);
            //仕入先名称
            writer.Write(temp.SupplierNm);
            // --- ADD 2010/07/20--------------------------------<<<<<

        }

        /// <summary>
        ///  SuppYearResultSuppResultWorkインスタンス取得
        /// </summary>
        /// <returns>SuppYearResultSuppResultWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SuppYearResultSuppResultWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private SuppYearResultSuppResultWork GetSuppYearResultSuppResultWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            SuppYearResultSuppResultWork temp = new SuppYearResultSuppResultWork();

            //計上年月
            temp.AddUpYearMonth = new DateTime(reader.ReadInt64());
            //仕入金額（税抜き）(在庫)
            temp.St_StockPriceTaxExc = reader.ReadInt64();
            //仕入返品額(在庫)
            temp.St_StockRetGoodsPrice = reader.ReadInt64();
            //仕入値引計(在庫)
            temp.St_StockTotalDiscount = reader.ReadInt64();
            //仕入金額消費税額（在庫）
            temp.St_StockPriceConsTax = reader.ReadInt64();
            //仕入金額（税抜き）(取寄)
            temp.Or_StockPriceTaxExc = reader.ReadInt64();
            //仕入返品額(取寄)
            temp.Or_StockRetGoodsPrice = reader.ReadInt64();
            //仕入値引計(取寄)
            temp.Or_StockTotalDiscount = reader.ReadInt64();
            //仕入金額消費税額（在庫）
            temp.Or_StockPriceConsTax = reader.ReadInt64();

            // --- ADD 2010/07/20-------------------------------->>>>>
            //拠点コード
            temp.StockSectionCd = reader.ReadString();
            //仕入先コード
            temp.SupplierCd = reader.ReadInt32();
            //拠点名称
            temp.SectionGuideNm = reader.ReadString();
            //仕入先名称
            temp.SupplierNm = reader.ReadString();
            // --- ADD 2010/07/20--------------------------------<<<<<


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
        /// <returns>SuppYearResultSuppResultWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SuppYearResultSuppResultWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                SuppYearResultSuppResultWork temp = GetSuppYearResultSuppResultWork(reader, serInfo);
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
                    retValue = (SuppYearResultSuppResultWork[])lst.ToArray(typeof(SuppYearResultSuppResultWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

}
