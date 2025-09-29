using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   SalesAnnualDataSelectResultWork
    /// <summary>
    ///                      売上年間実績照会抽出結果クラスワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   売上年間実績照会抽出結果クラスワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2007/12/13  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class SalesAnnualDataSelectResultWork
    {
        /// <summary>計上年月</summary>
        /// <remarks>YYYYMM</remarks>
        private Int32 _aUPYearMonth;

        /// <summary>実績集計区分</summary>
        /// <remarks>0:部品合計 1:在庫 2:純正 3:作業</remarks>
        private Int32 _rsltTtlDivCd;

        /// <summary>売上金額</summary>
        /// <remarks>税抜き（値引,返品含まず）</remarks>
        private Int64 _salesMoney;

        /// <summary>返品額</summary>
        private Int64 _salesRetGoodsPrice;

        /// <summary>値引金額</summary>
        private Int64 _discountPrice;

        /// <summary>粗利額</summary>
        private Int64 _grossProfit;

        /// <summary>売上目標額</summary>
        /// <remarks>※同一計上年月のレコードには同じ値がセットされます</remarks>
        private Int64 _salesTargetMoney;

        /// <summary>粗利目標額</summary>
        /// <remarks>※同一計上年月のレコードには同じ値がセットされます</remarks>
        private Int64 _salesTargetProfit;

        /// <summary>売上回数</summary>
        /// <remarks>出荷回数(売上時のみ）</remarks>
        private Int32 _salesTimes;

        /// <summary>期間伝票枚数</summary>
        /// <remarks>※同一計上年月のレコードには同じ値がセットされます</remarks>
        private Int32 _termSalesSlipCount;

        /// <summary>売上伝票区分</summary>
        /// <remarks>0:売上,1:返品,2:値引,3:注釈,4:小計,5:作業　※得意先別のみ使用</remarks>
        private Int32 _salesSlipCdDtl;

        /// <summary>売上在庫取寄区分 </summary>
        /// <remarks>0:取寄、1:在庫　※得意先別のみ使用</remarks>
        private Int32 _salesOrderDivCd;

        /// <summary>商品属性</summary>
        /// <remarks>0:純正、1:その他　※得意先別のみ使用</remarks>
        private Int32 _goodsKindCode;

        /// <summary>売上金額（税抜き）</summary>
        /// <remarks>売上金額（税抜き）</remarks>
        private Int64 _salesMoneyTaxExc;

        /// <summary>原価</summary>
        private Int64 _cost;

        // --- ADD 2010/08/02 -------------------------------->>>>>
        /// <summary>拠点コード</summary>
        private string _sectionCode = string.Empty;

        /// <summary>拠点名称</summary>
        private string _sectionName = string.Empty;

        /// <summary>selectionCode</summary>
        private string _selectionCode = string.Empty;

        /// <summary>selectionName</summary>
        private string _selectionName = string.Empty;
        // --- ADD 2010/08/02 --------------------------------<<<<<

        /// public propaty name  :  AUPYearMonth
        /// <summary>計上年月プロパティ</summary>
        /// <value>YYYYMM</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   計上年月プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AUPYearMonth
        {
            get { return _aUPYearMonth; }
            set { _aUPYearMonth = value; }
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
        /// <summary>粗利額プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   粗利額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 GrossProfit
        {
            get { return _grossProfit; }
            set { _grossProfit = value; }
        }

        /// public propaty name  :  SalesTargetMoney
        /// <summary>売上目標額プロパティ</summary>
        /// <value>※同一計上年月のレコードには同じ値がセットされます</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上目標額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesTargetMoney
        {
            get { return _salesTargetMoney; }
            set { _salesTargetMoney = value; }
        }

        /// public propaty name  :  SalesTargetProfit
        /// <summary>粗利目標額プロパティ</summary>
        /// <value>※同一計上年月のレコードには同じ値がセットされます</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   粗利目標額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesTargetProfit
        {
            get { return _salesTargetProfit; }
            set { _salesTargetProfit = value; }
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

        /// public propaty name  :  TermSalesSlipCount
        /// <summary>期間伝票枚数プロパティ</summary>
        /// <value>※同一計上年月のレコードには同じ値がセットされます</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   期間伝票枚数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 TermSalesSlipCount
        {
            get { return _termSalesSlipCount; }
            set { _termSalesSlipCount = value; }
        }

        /// public propaty name  :  SalesSlipCdDtl
        /// <summary>売上伝票区分プロパティ</summary>
        /// <value>0:売上,1:返品,2:値引,3:注釈,4:小計,5:作業　※得意先別のみ使用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上伝票区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SalesSlipCdDtl
        {
            get { return _salesSlipCdDtl; }
            set { _salesSlipCdDtl = value; }
        }

        /// public propaty name  :  SalesOrderDivCd
        /// <summary>売上在庫取寄区分 プロパティ</summary>
        /// <value>0:取寄、1:在庫　※得意先別のみ使用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上在庫取寄区分 プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SalesOrderDivCd
        {
            get { return _salesOrderDivCd; }
            set { _salesOrderDivCd = value; }
        }

        /// public propaty name  :  GoodsKindCode
        /// <summary>商品属性プロパティ</summary>
        /// <value>0:純正、1:その他　※得意先別のみ使用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品属性プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsKindCode
        {
            get { return _goodsKindCode; }
            set { _goodsKindCode = value; }
        }

        /// public propaty name  :  SalesMoneyTaxExc
        /// <summary>売上金額（税抜き）プロパティ</summary>
        /// <value>売上金額（税抜き）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上金額（税抜き）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesMoneyTaxExc
        {
            get { return _salesMoneyTaxExc; }
            set { _salesMoneyTaxExc = value; }
        }

        /// public propaty name  :  Cost
        /// <summary>原価プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   原価プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 Cost
        {
            get { return _cost; }
            set { _cost = value; }
        }


        // --- ADD 2010/08/02 -------------------------------->>>>>
        /// public propaty name  :  SectionCode
        /// <summary>拠点コードプロパティ</summary>
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

        /// public propaty name  :  _sectionName
        /// <summary>拠点コード名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点コード名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SectionName
        {
            get { return _sectionName; }
            set { _sectionName = value; }
        }

        /// public propaty name  :  SelectionCode
        /// <summary>SelectionCodeプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   SelectionCodeプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SelectionCode
        {
            get { return _selectionCode; }
            set { _selectionCode = value; }
        }

        /// public propaty name  :  SelectionName
        /// <summary>SelectionNameプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   SelectionNameプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SelectionName
        {
            get { return _selectionName; }
            set { _selectionName = value; }
        }

        // --- ADD 2010/08/02 --------------------------------<<<<<


        /// <summary>
        /// 売上年間実績照会抽出結果クラスワークワークコンストラクタ
        /// </summary>
        /// <returns>SalesAnnualDataSelectResultWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SalesAnnualDataSelectResultWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SalesAnnualDataSelectResultWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>SalesAnnualDataSelectResultWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   SalesAnnualDataSelectResultWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class SalesAnnualDataSelectResultWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   SalesAnnualDataSelectResultWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  SalesAnnualDataSelectResultWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is SalesAnnualDataSelectResultWork || graph is ArrayList || graph is SalesAnnualDataSelectResultWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(SalesAnnualDataSelectResultWork).FullName));

            if (graph != null && graph is SalesAnnualDataSelectResultWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.SalesAnnualDataSelectResultWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is SalesAnnualDataSelectResultWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((SalesAnnualDataSelectResultWork[])graph).Length;
            }
            else if (graph is SalesAnnualDataSelectResultWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //計上年月
            serInfo.MemberInfo.Add(typeof(Int32)); //AUPYearMonth
            //実績集計区分
            serInfo.MemberInfo.Add(typeof(Int32)); //RsltTtlDivCd
            //売上金額
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesMoney
            //返品額
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesRetGoodsPrice
            //値引金額
            serInfo.MemberInfo.Add(typeof(Int64)); //DiscountPrice
            //粗利額
            serInfo.MemberInfo.Add(typeof(Int64)); //GrossProfit
            //売上目標額
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTargetMoney
            //粗利目標額
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTargetProfit
            //売上回数
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesTimes
            //期間伝票枚数
            serInfo.MemberInfo.Add(typeof(Int32)); //TermSalesSlipCount
            //売上伝票区分
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesSlipCdDtl
            //売上在庫取寄区分 
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesOrderDivCd
            //商品属性
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsKindCode
            //売上金額（税抜き）
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesMoneyTaxExc
            //原価
            serInfo.MemberInfo.Add(typeof(Int64)); //Cost
            // --- ADD 2010/08/02 -------------------------------->>>>>
            //拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //SectionCode
            //拠点名称
            serInfo.MemberInfo.Add(typeof(string)); //SectionName
            //SelectionCode
            serInfo.MemberInfo.Add(typeof(string)); //SelectionCode
            //SelectionName
            serInfo.MemberInfo.Add(typeof(string)); //SelectionName
            // --- ADD 2010/08/02 --------------------------------<<<<<

            serInfo.Serialize(writer, serInfo);
            if (graph is SalesAnnualDataSelectResultWork)
            {
                SalesAnnualDataSelectResultWork temp = (SalesAnnualDataSelectResultWork)graph;

                SetSalesAnnualDataSelectResultWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is SalesAnnualDataSelectResultWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((SalesAnnualDataSelectResultWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (SalesAnnualDataSelectResultWork temp in lst)
                {
                    SetSalesAnnualDataSelectResultWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// SalesAnnualDataSelectResultWorkメンバ数(publicプロパティ数)
        /// </summary>
        //private const int currentMemberCount = 15; // DEL 2010/08/02
        private const int currentMemberCount = 19; // ADD 2010/08/02

        /// <summary>
        ///  SalesAnnualDataSelectResultWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   SalesAnnualDataSelectResultWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetSalesAnnualDataSelectResultWork(System.IO.BinaryWriter writer, SalesAnnualDataSelectResultWork temp)
        {
            //計上年月
            writer.Write(temp.AUPYearMonth);
            //実績集計区分
            writer.Write(temp.RsltTtlDivCd);
            //売上金額
            writer.Write(temp.SalesMoney);
            //返品額
            writer.Write(temp.SalesRetGoodsPrice);
            //値引金額
            writer.Write(temp.DiscountPrice);
            //粗利額
            writer.Write(temp.GrossProfit);
            //売上目標額
            writer.Write(temp.SalesTargetMoney);
            //粗利目標額
            writer.Write(temp.SalesTargetProfit);
            //売上回数
            writer.Write(temp.SalesTimes);
            //期間伝票枚数
            writer.Write(temp.TermSalesSlipCount);
            //売上伝票区分
            writer.Write(temp.SalesSlipCdDtl);
            //売上在庫取寄区分 
            writer.Write(temp.SalesOrderDivCd);
            //商品属性
            writer.Write(temp.GoodsKindCode);
            //売上金額（税抜き）
            writer.Write(temp.SalesMoneyTaxExc);
            //原価
            writer.Write(temp.Cost);
            // --- ADD 2010/08/02 -------------------------------->>>>>
            //拠点コード
            writer.Write(temp.SectionCode);
            //拠点名称
            writer.Write(temp.SectionName);
            //SelectionCode
            writer.Write(temp.SelectionCode);
            //SelectionName
            writer.Write(temp.SelectionName);
            // --- ADD 2010/08/02 --------------------------------<<<<<

        }

        /// <summary>
        ///  SalesAnnualDataSelectResultWorkインスタンス取得
        /// </summary>
        /// <returns>SalesAnnualDataSelectResultWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SalesAnnualDataSelectResultWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private SalesAnnualDataSelectResultWork GetSalesAnnualDataSelectResultWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            SalesAnnualDataSelectResultWork temp = new SalesAnnualDataSelectResultWork();

            //計上年月
            temp.AUPYearMonth = reader.ReadInt32();
            //実績集計区分
            temp.RsltTtlDivCd = reader.ReadInt32();
            //売上金額
            temp.SalesMoney = reader.ReadInt64();
            //返品額
            temp.SalesRetGoodsPrice = reader.ReadInt64();
            //値引金額
            temp.DiscountPrice = reader.ReadInt64();
            //粗利額
            temp.GrossProfit = reader.ReadInt64();
            //売上目標額
            temp.SalesTargetMoney = reader.ReadInt64();
            //粗利目標額
            temp.SalesTargetProfit = reader.ReadInt64();
            //売上回数
            temp.SalesTimes = reader.ReadInt32();
            //期間伝票枚数
            temp.TermSalesSlipCount = reader.ReadInt32();
            //売上伝票区分
            temp.SalesSlipCdDtl = reader.ReadInt32();
            //売上在庫取寄区分 
            temp.SalesOrderDivCd = reader.ReadInt32();
            //商品属性
            temp.GoodsKindCode = reader.ReadInt32();
            //売上金額（税抜き）
            temp.SalesMoneyTaxExc = reader.ReadInt64();
            //原価
            temp.Cost = reader.ReadInt64();
            // --- ADD 2010/08/02 -------------------------------->>>>>
            //拠点コード
            temp.SectionCode = reader.ReadString();
            //拠点名称
            temp.SectionName = reader.ReadString();
            //SelectionCode
            temp.SelectionCode = reader.ReadString();
            //SelectionName
            temp.SelectionName = reader.ReadString();
            // --- ADD 2010/08/02 --------------------------------<<<<<


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
        /// <returns>SalesAnnualDataSelectResultWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SalesAnnualDataSelectResultWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                SalesAnnualDataSelectResultWork temp = GetSalesAnnualDataSelectResultWork(reader, serInfo);
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
                    retValue = (SalesAnnualDataSelectResultWork[])lst.ToArray(typeof(SalesAnnualDataSelectResultWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

}
