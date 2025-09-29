using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   SalStcCompReportResultWork
    /// <summary>
    ///                      売上仕入対比表(日報月報)抽出結果クラスワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   売上仕入対比表(日報月報)抽出結果クラスワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/11/20  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class SalStcCompReportResultWork
    {
        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>拠点コード</summary>
        private string _secCode = "";

        /// <summary>拠点ガイド略称</summary>
        /// <remarks>帳票印字用</remarks>
        private string _sectionGuideSnm = "";

        /// <summary>仕入先コード</summary>
        private Int32 _supplierCd;

        /// <summary>仕入先略称</summary>
        private string _supplierSnm = "";

        /// <summary>売上金額(日計取寄)</summary>
        /// <remarks>税抜き（値引,返品含む）</remarks>
        private Int64 _salesMoney;

        /// <summary>売上金額(日計在庫)</summary>
        /// <remarks>税抜き（値引,返品含む）</remarks>
        private Int64 _salesMoneyStock;

        /// <summary>原価金額計(日計)</summary>
        private Int64 _totalCost;

        /// <summary>移動数(日計売上)</summary>
        private Double _moveCountSales;

        /// <summary>仕入単価（日計売上）</summary>
        /// <remarks>在庫移動する在庫の仕入価格情報をセット</remarks>
        private Double _stockUnitPriceFlSales;

        /// <summary>移動金額(日計売上)</summary>
        /// <remarks>税抜き（値引,返品含む）</remarks>
        private Int64 _stockMovePriceSales;

        /// <summary>仕入金額(日計取寄)</summary>
        private Int64 _stockPriceTaxExc;

        /// <summary>仕入金額(日計在庫)</summary>
        private Int64 _stockPriceTaxExcStock;

        /// <summary>移動数(日計仕入)</summary>
        private Double _moveCountSalesSlip;

        /// <summary>仕入単価（日計仕入）</summary>
        /// <remarks>在庫移動する在庫の仕入価格情報をセット</remarks>
        private Double _stockUnitPriceFlSalesSlip;

        /// <summary>移動金額(日計仕入)</summary>
        /// <remarks>税抜き（値引,返品含む）</remarks>
        private Int64 _stockMovePriceSlip;

        /// <summary>売上金額(累計取寄)</summary>
        /// <remarks>税抜き（値引,返品含む）</remarks>
        private Int64 _monthSalesMoney;

        /// <summary>売上金額(累計在庫)</summary>
        private Int64 _monthSalesMoneyStock;

        /// <summary>原価金額計(累計)</summary>
        private Int64 _monthTotalCost;

        /// <summary>移動数(累計売上)</summary>
        /// <remarks>在庫移動する在庫の仕入価格情報をセット</remarks>
        private Double _monthMoveCountSales;

        /// <summary>仕入単価（累計売上）</summary>
        private Double _monthStockUnitPriceFlSales;

        /// <summary>移動金額(累計売上)</summary>
        /// <remarks>税抜き（値引,返品含む）</remarks>
        private Int64 _monthStockMovePriceSales;

        /// <summary>仕入金額(累計取寄)</summary>
        private Int64 _monthStockPriceTaxExc;

        /// <summary>仕入金額(累計在庫)</summary>
        private Int64 _monthStockPriceTaxExcStock;

        /// <summary>移動数(累計仕入)</summary>
        /// <remarks>在庫移動する在庫の仕入価格情報をセット</remarks>
        private Double _monthMoveCountSalesSlip;

        /// <summary>仕入単価（累計仕入）</summary>
        private Double _monthStockUnitPriceFlSalesSlip;

        /// <summary>移動金額(累計仕入)</summary>
        /// <remarks>税抜き（値引,返品含む）</remarks>
        private Int64 _monthStockMovePriceSlip;


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

        /// public propaty name  :  SecCode
        /// <summary>拠点コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SecCode
        {
            get { return _secCode; }
            set { _secCode = value; }
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

        /// public propaty name  :  SalesMoney
        /// <summary>売上金額(日計取寄)プロパティ</summary>
        /// <value>税抜き（値引,返品含む）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上金額(日計取寄)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesMoney
        {
            get { return _salesMoney; }
            set { _salesMoney = value; }
        }

        /// public propaty name  :  SalesMoneyStock
        /// <summary>売上金額(日計在庫)プロパティ</summary>
        /// <value>税抜き（値引,返品含む）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上金額(日計在庫)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesMoneyStock
        {
            get { return _salesMoneyStock; }
            set { _salesMoneyStock = value; }
        }

        /// public propaty name  :  TotalCost
        /// <summary>原価金額計(日計)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   原価金額計(日計)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 TotalCost
        {
            get { return _totalCost; }
            set { _totalCost = value; }
        }

        /// public propaty name  :  MoveCountSales
        /// <summary>移動数(日計売上)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   移動数(日計売上)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double MoveCountSales
        {
            get { return _moveCountSales; }
            set { _moveCountSales = value; }
        }

        /// public propaty name  :  StockUnitPriceFlSales
        /// <summary>仕入単価（日計売上）プロパティ</summary>
        /// <value>在庫移動する在庫の仕入価格情報をセット</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入単価（日計売上）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double StockUnitPriceFlSales
        {
            get { return _stockUnitPriceFlSales; }
            set { _stockUnitPriceFlSales = value; }
        }

        /// public propaty name  :  StockMovePriceSales
        /// <summary>移動金額(日計売上)プロパティ</summary>
        /// <value>税抜き（値引,返品含む）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   移動金額(日計売上)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 StockMovePriceSales
        {
            get { return _stockMovePriceSales; }
            set { _stockMovePriceSales = value; }
        }

        /// public propaty name  :  StockPriceTaxExc
        /// <summary>仕入金額(日計取寄)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入金額(日計取寄)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 StockPriceTaxExc
        {
            get { return _stockPriceTaxExc; }
            set { _stockPriceTaxExc = value; }
        }

        /// public propaty name  :  StockPriceTaxExcStock
        /// <summary>仕入金額(日計在庫)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入金額(日計在庫)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 StockPriceTaxExcStock
        {
            get { return _stockPriceTaxExcStock; }
            set { _stockPriceTaxExcStock = value; }
        }

        /// public propaty name  :  MoveCountSalesSlip
        /// <summary>移動数(日計仕入)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   移動数(日計仕入)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double MoveCountSalesSlip
        {
            get { return _moveCountSalesSlip; }
            set { _moveCountSalesSlip = value; }
        }

        /// public propaty name  :  StockUnitPriceFlSalesSlip
        /// <summary>仕入単価（日計仕入）プロパティ</summary>
        /// <value>在庫移動する在庫の仕入価格情報をセット</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入単価（日計仕入）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double StockUnitPriceFlSalesSlip
        {
            get { return _stockUnitPriceFlSalesSlip; }
            set { _stockUnitPriceFlSalesSlip = value; }
        }

        /// public propaty name  :  StockMovePriceSlip
        /// <summary>移動金額(日計仕入)プロパティ</summary>
        /// <value>税抜き（値引,返品含む）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   移動金額(日計仕入)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 StockMovePriceSlip
        {
            get { return _stockMovePriceSlip; }
            set { _stockMovePriceSlip = value; }
        }

        /// public propaty name  :  MonthSalesMoney
        /// <summary>売上金額(累計取寄)プロパティ</summary>
        /// <value>税抜き（値引,返品含む）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上金額(累計取寄)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 MonthSalesMoney
        {
            get { return _monthSalesMoney; }
            set { _monthSalesMoney = value; }
        }

        /// public propaty name  :  MonthSalesMoneyStock
        /// <summary>売上金額(累計在庫)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上金額(累計在庫)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 MonthSalesMoneyStock
        {
            get { return _monthSalesMoneyStock; }
            set { _monthSalesMoneyStock = value; }
        }

        /// public propaty name  :  MonthTotalCost
        /// <summary>原価金額計(累計)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   原価金額計(累計)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 MonthTotalCost
        {
            get { return _monthTotalCost; }
            set { _monthTotalCost = value; }
        }

        /// public propaty name  :  MonthMoveCountSales
        /// <summary>移動数(累計売上)プロパティ</summary>
        /// <value>在庫移動する在庫の仕入価格情報をセット</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   移動数(累計売上)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double MonthMoveCountSales
        {
            get { return _monthMoveCountSales; }
            set { _monthMoveCountSales = value; }
        }

        /// public propaty name  :  MonthStockUnitPriceFlSales
        /// <summary>仕入単価（累計売上）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入単価（累計売上）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double MonthStockUnitPriceFlSales
        {
            get { return _monthStockUnitPriceFlSales; }
            set { _monthStockUnitPriceFlSales = value; }
        }

        /// public propaty name  :  MonthStockMovePriceSales
        /// <summary>移動金額(累計売上)プロパティ</summary>
        /// <value>税抜き（値引,返品含む）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   移動金額(累計売上)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 MonthStockMovePriceSales
        {
            get { return _monthStockMovePriceSales; }
            set { _monthStockMovePriceSales = value; }
        }

        /// public propaty name  :  MonthStockPriceTaxExc
        /// <summary>仕入金額(累計取寄)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入金額(累計取寄)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 MonthStockPriceTaxExc
        {
            get { return _monthStockPriceTaxExc; }
            set { _monthStockPriceTaxExc = value; }
        }

        /// public propaty name  :  MonthStockPriceTaxExcStock
        /// <summary>仕入金額(累計在庫)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入金額(累計在庫)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 MonthStockPriceTaxExcStock
        {
            get { return _monthStockPriceTaxExcStock; }
            set { _monthStockPriceTaxExcStock = value; }
        }

        /// public propaty name  :  MonthMoveCountSalesSlip
        /// <summary>移動数(累計仕入)プロパティ</summary>
        /// <value>在庫移動する在庫の仕入価格情報をセット</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   移動数(累計仕入)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double MonthMoveCountSalesSlip
        {
            get { return _monthMoveCountSalesSlip; }
            set { _monthMoveCountSalesSlip = value; }
        }

        /// public propaty name  :  MonthStockUnitPriceFlSalesSlip
        /// <summary>仕入単価（累計仕入）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入単価（累計仕入）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double MonthStockUnitPriceFlSalesSlip
        {
            get { return _monthStockUnitPriceFlSalesSlip; }
            set { _monthStockUnitPriceFlSalesSlip = value; }
        }

        /// public propaty name  :  MonthStockMovePriceSlip
        /// <summary>移動金額(累計仕入)プロパティ</summary>
        /// <value>税抜き（値引,返品含む）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   移動金額(累計仕入)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 MonthStockMovePriceSlip
        {
            get { return _monthStockMovePriceSlip; }
            set { _monthStockMovePriceSlip = value; }
        }


        /// <summary>
        /// 売上仕入対比表(日報月報)抽出結果クラスワークコンストラクタ
        /// </summary>
        /// <returns>SalStcCompReportResultWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SalStcCompReportResultWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SalStcCompReportResultWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>SalStcCompReportResultWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   SalStcCompReportResultWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class SalStcCompReportResultWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   SalStcCompReportResultWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  SalStcCompReportResultWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is SalStcCompReportResultWork || graph is ArrayList || graph is SalStcCompReportResultWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(SalStcCompReportResultWork).FullName));

            if (graph != null && graph is SalStcCompReportResultWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.SalStcCompReportResultWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is SalStcCompReportResultWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((SalStcCompReportResultWork[])graph).Length;
            }
            else if (graph is SalStcCompReportResultWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //企業コード
            serInfo.MemberInfo.Add(typeof(string)); //EnterpriseCode
            //拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //SecCode
            //拠点ガイド略称
            serInfo.MemberInfo.Add(typeof(string)); //SectionGuideSnm
            //仕入先コード
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierCd
            //仕入先略称
            serInfo.MemberInfo.Add(typeof(string)); //SupplierSnm
            //売上金額(日計取寄)
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesMoney
            //売上金額(日計在庫)
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesMoneyStock
            //原価金額計(日計)
            serInfo.MemberInfo.Add(typeof(Int64)); //TotalCost
            //移動数(日計売上)
            serInfo.MemberInfo.Add(typeof(Double)); //MoveCountSales
            //仕入単価（日計売上）
            serInfo.MemberInfo.Add(typeof(Double)); //StockUnitPriceFlSales
            //移動金額(日計売上)
            serInfo.MemberInfo.Add(typeof(Int64)); //StockMovePriceSales
            //仕入金額(日計取寄)
            serInfo.MemberInfo.Add(typeof(Int64)); //StockPriceTaxExc
            //仕入金額(日計在庫)
            serInfo.MemberInfo.Add(typeof(Int64)); //StockPriceTaxExcStock
            //移動数(日計仕入)
            serInfo.MemberInfo.Add(typeof(Double)); //MoveCountSalesSlip
            //仕入単価（日計仕入）
            serInfo.MemberInfo.Add(typeof(Double)); //StockUnitPriceFlSalesSlip
            //移動金額(日計仕入)
            serInfo.MemberInfo.Add(typeof(Int64)); //StockMovePriceSlip
            //売上金額(累計取寄)
            serInfo.MemberInfo.Add(typeof(Int64)); //MonthSalesMoney
            //売上金額(累計在庫)
            serInfo.MemberInfo.Add(typeof(Int64)); //MonthSalesMoneyStock
            //原価金額計(累計)
            serInfo.MemberInfo.Add(typeof(Int64)); //MonthTotalCost
            //移動数(累計売上)
            serInfo.MemberInfo.Add(typeof(Double)); //MonthMoveCountSales
            //仕入単価（累計売上）
            serInfo.MemberInfo.Add(typeof(Double)); //MonthStockUnitPriceFlSales
            //移動金額(累計売上)
            serInfo.MemberInfo.Add(typeof(Int64)); //MonthStockMovePriceSales
            //仕入金額(累計取寄)
            serInfo.MemberInfo.Add(typeof(Int64)); //MonthStockPriceTaxExc
            //仕入金額(累計在庫)
            serInfo.MemberInfo.Add(typeof(Int64)); //MonthStockPriceTaxExcStock
            //移動数(累計仕入)
            serInfo.MemberInfo.Add(typeof(Double)); //MonthMoveCountSalesSlip
            //仕入単価（累計仕入）
            serInfo.MemberInfo.Add(typeof(Double)); //MonthStockUnitPriceFlSalesSlip
            //移動金額(累計仕入)
            serInfo.MemberInfo.Add(typeof(Int64)); //MonthStockMovePriceSlip


            serInfo.Serialize(writer, serInfo);
            if (graph is SalStcCompReportResultWork)
            {
                SalStcCompReportResultWork temp = (SalStcCompReportResultWork)graph;

                SetSalStcCompReportResultWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is SalStcCompReportResultWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((SalStcCompReportResultWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (SalStcCompReportResultWork temp in lst)
                {
                    SetSalStcCompReportResultWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// SalStcCompReportResultWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 27;

        /// <summary>
        ///  SalStcCompReportResultWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   SalStcCompReportResultWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetSalStcCompReportResultWork(System.IO.BinaryWriter writer, SalStcCompReportResultWork temp)
        {
            //企業コード
            writer.Write(temp.EnterpriseCode);
            //拠点コード
            writer.Write(temp.SecCode);
            //拠点ガイド略称
            writer.Write(temp.SectionGuideSnm);
            //仕入先コード
            writer.Write(temp.SupplierCd);
            //仕入先略称
            writer.Write(temp.SupplierSnm);
            //売上金額(日計取寄)
            writer.Write(temp.SalesMoney);
            //売上金額(日計在庫)
            writer.Write(temp.SalesMoneyStock);
            //原価金額計(日計)
            writer.Write(temp.TotalCost);
            //移動数(日計売上)
            writer.Write(temp.MoveCountSales);
            //仕入単価（日計売上）
            writer.Write(temp.StockUnitPriceFlSales);
            //移動金額(日計売上)
            writer.Write(temp.StockMovePriceSales);
            //仕入金額(日計取寄)
            writer.Write(temp.StockPriceTaxExc);
            //仕入金額(日計在庫)
            writer.Write(temp.StockPriceTaxExcStock);
            //移動数(日計仕入)
            writer.Write(temp.MoveCountSalesSlip);
            //仕入単価（日計仕入）
            writer.Write(temp.StockUnitPriceFlSalesSlip);
            //移動金額(日計仕入)
            writer.Write(temp.StockMovePriceSlip);
            //売上金額(累計取寄)
            writer.Write(temp.MonthSalesMoney);
            //売上金額(累計在庫)
            writer.Write(temp.MonthSalesMoneyStock);
            //原価金額計(累計)
            writer.Write(temp.MonthTotalCost);
            //移動数(累計売上)
            writer.Write(temp.MonthMoveCountSales);
            //仕入単価（累計売上）
            writer.Write(temp.MonthStockUnitPriceFlSales);
            //移動金額(累計売上)
            writer.Write(temp.MonthStockMovePriceSales);
            //仕入金額(累計取寄)
            writer.Write(temp.MonthStockPriceTaxExc);
            //仕入金額(累計在庫)
            writer.Write(temp.MonthStockPriceTaxExcStock);
            //移動数(累計仕入)
            writer.Write(temp.MonthMoveCountSalesSlip);
            //仕入単価（累計仕入）
            writer.Write(temp.MonthStockUnitPriceFlSalesSlip);
            //移動金額(累計仕入)
            writer.Write(temp.MonthStockMovePriceSlip);

        }

        /// <summary>
        ///  SalStcCompReportResultWorkインスタンス取得
        /// </summary>
        /// <returns>SalStcCompReportResultWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SalStcCompReportResultWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private SalStcCompReportResultWork GetSalStcCompReportResultWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            SalStcCompReportResultWork temp = new SalStcCompReportResultWork();

            //企業コード
            temp.EnterpriseCode = reader.ReadString();
            //拠点コード
            temp.SecCode = reader.ReadString();
            //拠点ガイド略称
            temp.SectionGuideSnm = reader.ReadString();
            //仕入先コード
            temp.SupplierCd = reader.ReadInt32();
            //仕入先略称
            temp.SupplierSnm = reader.ReadString();
            //売上金額(日計取寄)
            temp.SalesMoney = reader.ReadInt64();
            //売上金額(日計在庫)
            temp.SalesMoneyStock = reader.ReadInt64();
            //原価金額計(日計)
            temp.TotalCost = reader.ReadInt64();
            //移動数(日計売上)
            temp.MoveCountSales = reader.ReadDouble();
            //仕入単価（日計売上）
            temp.StockUnitPriceFlSales = reader.ReadDouble();
            //移動金額(日計売上)
            temp.StockMovePriceSales = reader.ReadInt64();
            //仕入金額(日計取寄)
            temp.StockPriceTaxExc = reader.ReadInt64();
            //仕入金額(日計在庫)
            temp.StockPriceTaxExcStock = reader.ReadInt64();
            //移動数(日計仕入)
            temp.MoveCountSalesSlip = reader.ReadDouble();
            //仕入単価（日計仕入）
            temp.StockUnitPriceFlSalesSlip = reader.ReadDouble();
            //移動金額(日計仕入)
            temp.StockMovePriceSlip = reader.ReadInt64();
            //売上金額(累計取寄)
            temp.MonthSalesMoney = reader.ReadInt64();
            //売上金額(累計在庫)
            temp.MonthSalesMoneyStock = reader.ReadInt64();
            //原価金額計(累計)
            temp.MonthTotalCost = reader.ReadInt64();
            //移動数(累計売上)
            temp.MonthMoveCountSales = reader.ReadDouble();
            //仕入単価（累計売上）
            temp.MonthStockUnitPriceFlSales = reader.ReadDouble();
            //移動金額(累計売上)
            temp.MonthStockMovePriceSales = reader.ReadInt64();
            //仕入金額(累計取寄)
            temp.MonthStockPriceTaxExc = reader.ReadInt64();
            //仕入金額(累計在庫)
            temp.MonthStockPriceTaxExcStock = reader.ReadInt64();
            //移動数(累計仕入)
            temp.MonthMoveCountSalesSlip = reader.ReadDouble();
            //仕入単価（累計仕入）
            temp.MonthStockUnitPriceFlSalesSlip = reader.ReadDouble();
            //移動金額(累計仕入)
            temp.MonthStockMovePriceSlip = reader.ReadInt64();


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
        /// <returns>SalStcCompReportResultWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SalStcCompReportResultWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                SalStcCompReportResultWork temp = GetSalStcCompReportResultWork(reader, serInfo);
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
                    retValue = (SalStcCompReportResultWork[])lst.ToArray(typeof(SalStcCompReportResultWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}
