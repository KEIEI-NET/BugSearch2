using System;
using System.Collections;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   SalesTransListResultWork
    /// <summary>
    ///                      売上推移表抽出結果クラスワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   売上推移表抽出結果クラスワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/10/14  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class SalesTransListResultWork
    {
        /// <summary>拠点コード</summary>
        /// <remarks>計上拠点コード</remarks>
        private string _addUpSecCode = "";

        /// <summary>拠点名称</summary>
        /// <remarks>自社名称1</remarks>
        private string _companyName1 = "";

        /// <summary>商品メーカーコード</summary>
        private Int32 _goodsMakerCd;

        /// <summary>メーカー略称</summary>
        private string _makerShortName = "";

        /// <summary>商品大分類コード</summary>
        private Int32 _goodsLGroup;

        /// <summary>商品大分類名称</summary>
        private string _goodsLGroupName = "";

        /// <summary>商品中分類コード</summary>
        private Int32 _goodsMGroup;

        /// <summary>商品中分類名称</summary>
        private string _goodsMGroupName = "";

        /// <summary>BLグループコード</summary>
        private Int32 _bLGroupCode;

        /// <summary>BLグループコードカナ名称</summary>
        private string _bLGroupKanaName = "";

        /// <summary>BL商品コード</summary>
        private Int32 _bLGoodsCode;

        /// <summary>BL商品コード名称（半角）</summary>
        private string _bLGoodsHalfName = "";

        /// <summary>商品番号</summary>
        private string _goodsNo = "";

        /// <summary>商品名称</summary>
        /// <remarks>商品名称カナ</remarks>
        private string _goodsNameKana = "";

        /// <summary>得意先コード</summary>
        private Int32 _customerCode;

        /// <summary>得意先略称</summary>
        private string _customerSnm = "";

        /// <summary>仕入先コード</summary>
        private Int32 _supplierCode;

        /// <summary>仕入先略称</summary>
        private string _supplierSnm = "";

        /// <summary>従業員コード</summary>
        private string _employeeCode = "";

        /// <summary>従業員名称</summary>
        private string _name = "";

        /// <summary>売上金額1</summary>
        /// <remarks>税抜き（値引,返品含まず）</remarks>
        private Int64 _salesMoney1;

        /// <summary>売上金額2</summary>
        /// <remarks>税抜き（値引,返品含まず）</remarks>
        private Int64 _salesMoney2;

        /// <summary>売上金額3</summary>
        /// <remarks>税抜き（値引,返品含まず）</remarks>
        private Int64 _salesMoney3;

        /// <summary>売上金額4</summary>
        /// <remarks>税抜き（値引,返品含まず）</remarks>
        private Int64 _salesMoney4;

        /// <summary>売上金額5</summary>
        /// <remarks>税抜き（値引,返品含まず）</remarks>
        private Int64 _salesMoney5;

        /// <summary>売上金額6</summary>
        /// <remarks>税抜き（値引,返品含まず）</remarks>
        private Int64 _salesMoney6;

        /// <summary>売上金額7</summary>
        /// <remarks>税抜き（値引,返品含まず）</remarks>
        private Int64 _salesMoney7;

        /// <summary>売上金額8</summary>
        /// <remarks>税抜き（値引,返品含まず）</remarks>
        private Int64 _salesMoney8;

        /// <summary>売上金額9</summary>
        /// <remarks>税抜き（値引,返品含まず）</remarks>
        private Int64 _salesMoney9;

        /// <summary>売上金額10</summary>
        /// <remarks>税抜き（値引,返品含まず）</remarks>
        private Int64 _salesMoney10;

        /// <summary>売上金額11</summary>
        /// <remarks>税抜き（値引,返品含まず）</remarks>
        private Int64 _salesMoney11;

        /// <summary>売上金額12</summary>
        /// <remarks>税抜き（値引,返品含まず）</remarks>
        private Int64 _salesMoney12;

        /// <summary>売上数計1</summary>
        /// <remarks>出荷数(返品は減算)</remarks>
        private Double _totalSalesCount1;

        /// <summary>売上数計2</summary>
        /// <remarks>出荷数(返品は減算)</remarks>
        private Double _totalSalesCount2;

        /// <summary>売上数計3</summary>
        /// <remarks>出荷数(返品は減算)</remarks>
        private Double _totalSalesCount3;

        /// <summary>売上数計4</summary>
        /// <remarks>出荷数(返品は減算)</remarks>
        private Double _totalSalesCount4;

        /// <summary>売上数計5</summary>
        /// <remarks>出荷数(返品は減算)</remarks>
        private Double _totalSalesCount5;

        /// <summary>売上数計6</summary>
        /// <remarks>出荷数(返品は減算)</remarks>
        private Double _totalSalesCount6;

        /// <summary>売上数計7</summary>
        /// <remarks>出荷数(返品は減算)</remarks>
        private Double _totalSalesCount7;

        /// <summary>売上数計8</summary>
        /// <remarks>出荷数(返品は減算)</remarks>
        private Double _totalSalesCount8;

        /// <summary>売上数計9</summary>
        /// <remarks>出荷数(返品は減算)</remarks>
        private Double _totalSalesCount9;

        /// <summary>売上数計10</summary>
        /// <remarks>出荷数(返品は減算)</remarks>
        private Double _totalSalesCount10;

        /// <summary>売上数計11</summary>
        /// <remarks>出荷数(返品は減算)</remarks>
        private Double _totalSalesCount11;

        /// <summary>売上数計12</summary>
        /// <remarks>出荷数(返品は減算)</remarks>
        private Double _totalSalesCount12;


        /// public propaty name  :  AddUpSecCode
        /// <summary>拠点コードプロパティ</summary>
        /// <value>計上拠点コード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AddUpSecCode
        {
            get { return _addUpSecCode; }
            set { _addUpSecCode = value; }
        }

        /// public propaty name  :  CompanyName1
        /// <summary>拠点名称プロパティ</summary>
        /// <value>自社名称1</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CompanyName1
        {
            get { return _companyName1; }
            set { _companyName1 = value; }
        }

        /// public propaty name  :  GoodsMakerCd
        /// <summary>商品メーカーコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品メーカーコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsMakerCd
        {
            get { return _goodsMakerCd; }
            set { _goodsMakerCd = value; }
        }

        /// public propaty name  :  MakerShortName
        /// <summary>メーカー略称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メーカー略称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MakerShortName
        {
            get { return _makerShortName; }
            set { _makerShortName = value; }
        }

        /// public propaty name  :  GoodsLGroup
        /// <summary>商品大分類コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品大分類コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsLGroup
        {
            get { return _goodsLGroup; }
            set { _goodsLGroup = value; }
        }

        /// public propaty name  :  GoodsLGroupName
        /// <summary>商品大分類名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品大分類名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsLGroupName
        {
            get { return _goodsLGroupName; }
            set { _goodsLGroupName = value; }
        }

        /// public propaty name  :  GoodsMGroup
        /// <summary>商品中分類コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品中分類コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsMGroup
        {
            get { return _goodsMGroup; }
            set { _goodsMGroup = value; }
        }

        /// public propaty name  :  GoodsMGroupName
        /// <summary>商品中分類名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品中分類名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsMGroupName
        {
            get { return _goodsMGroupName; }
            set { _goodsMGroupName = value; }
        }

        /// public propaty name  :  BLGroupCode
        /// <summary>BLグループコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BLグループコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BLGroupCode
        {
            get { return _bLGroupCode; }
            set { _bLGroupCode = value; }
        }

        /// public propaty name  :  BLGroupKanaName
        /// <summary>BLグループコードカナ名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BLグループコードカナ名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string BLGroupKanaName
        {
            get { return _bLGroupKanaName; }
            set { _bLGroupKanaName = value; }
        }

        /// public propaty name  :  BLGoodsCode
        /// <summary>BL商品コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL商品コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BLGoodsCode
        {
            get { return _bLGoodsCode; }
            set { _bLGoodsCode = value; }
        }

        /// public propaty name  :  BLGoodsHalfName
        /// <summary>BL商品コード名称（半角）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL商品コード名称（半角）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string BLGoodsHalfName
        {
            get { return _bLGoodsHalfName; }
            set { _bLGoodsHalfName = value; }
        }

        /// public propaty name  :  GoodsNo
        /// <summary>商品番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsNo
        {
            get { return _goodsNo; }
            set { _goodsNo = value; }
        }

        /// public propaty name  :  GoodsNameKana
        /// <summary>商品名称プロパティ</summary>
        /// <value>商品名称カナ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsNameKana
        {
            get { return _goodsNameKana; }
            set { _goodsNameKana = value; }
        }

        /// public propaty name  :  CustomerCode
        /// <summary>得意先コードプロパティ</summary>
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

        /// public propaty name  :  CustomerSnm
        /// <summary>得意先略称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先略称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CustomerSnm
        {
            get { return _customerSnm; }
            set { _customerSnm = value; }
        }

        /// public propaty name  :  SupplierCode
        /// <summary>仕入先コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SupplierCode
        {
            get { return _supplierCode; }
            set { _supplierCode = value; }
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

        /// public propaty name  :  EmployeeCode
        /// <summary>従業員コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   従業員コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EmployeeCode
        {
            get { return _employeeCode; }
            set { _employeeCode = value; }
        }

        /// public propaty name  :  Name
        /// <summary>従業員名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   従業員名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        /// public propaty name  :  SalesMoney1
        /// <summary>売上金額1プロパティ</summary>
        /// <value>税抜き（値引,返品含まず）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上金額1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesMoney1
        {
            get { return _salesMoney1; }
            set { _salesMoney1 = value; }
        }

        /// public propaty name  :  SalesMoney2
        /// <summary>売上金額2プロパティ</summary>
        /// <value>税抜き（値引,返品含まず）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上金額2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesMoney2
        {
            get { return _salesMoney2; }
            set { _salesMoney2 = value; }
        }

        /// public propaty name  :  SalesMoney3
        /// <summary>売上金額3プロパティ</summary>
        /// <value>税抜き（値引,返品含まず）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上金額3プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesMoney3
        {
            get { return _salesMoney3; }
            set { _salesMoney3 = value; }
        }

        /// public propaty name  :  SalesMoney4
        /// <summary>売上金額4プロパティ</summary>
        /// <value>税抜き（値引,返品含まず）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上金額4プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesMoney4
        {
            get { return _salesMoney4; }
            set { _salesMoney4 = value; }
        }

        /// public propaty name  :  SalesMoney5
        /// <summary>売上金額5プロパティ</summary>
        /// <value>税抜き（値引,返品含まず）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上金額5プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesMoney5
        {
            get { return _salesMoney5; }
            set { _salesMoney5 = value; }
        }

        /// public propaty name  :  SalesMoney6
        /// <summary>売上金額6プロパティ</summary>
        /// <value>税抜き（値引,返品含まず）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上金額6プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesMoney6
        {
            get { return _salesMoney6; }
            set { _salesMoney6 = value; }
        }

        /// public propaty name  :  SalesMoney7
        /// <summary>売上金額7プロパティ</summary>
        /// <value>税抜き（値引,返品含まず）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上金額7プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesMoney7
        {
            get { return _salesMoney7; }
            set { _salesMoney7 = value; }
        }

        /// public propaty name  :  SalesMoney8
        /// <summary>売上金額8プロパティ</summary>
        /// <value>税抜き（値引,返品含まず）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上金額8プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesMoney8
        {
            get { return _salesMoney8; }
            set { _salesMoney8 = value; }
        }

        /// public propaty name  :  SalesMoney9
        /// <summary>売上金額9プロパティ</summary>
        /// <value>税抜き（値引,返品含まず）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上金額9プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesMoney9
        {
            get { return _salesMoney9; }
            set { _salesMoney9 = value; }
        }

        /// public propaty name  :  SalesMoney10
        /// <summary>売上金額10プロパティ</summary>
        /// <value>税抜き（値引,返品含まず）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上金額10プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesMoney10
        {
            get { return _salesMoney10; }
            set { _salesMoney10 = value; }
        }

        /// public propaty name  :  SalesMoney11
        /// <summary>売上金額11プロパティ</summary>
        /// <value>税抜き（値引,返品含まず）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上金額11プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesMoney11
        {
            get { return _salesMoney11; }
            set { _salesMoney11 = value; }
        }

        /// public propaty name  :  SalesMoney12
        /// <summary>売上金額12プロパティ</summary>
        /// <value>税抜き（値引,返品含まず）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上金額12プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesMoney12
        {
            get { return _salesMoney12; }
            set { _salesMoney12 = value; }
        }

        /// public propaty name  :  TotalSalesCount1
        /// <summary>売上数計1プロパティ</summary>
        /// <value>出荷数(返品は減算)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上数計1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double TotalSalesCount1
        {
            get { return _totalSalesCount1; }
            set { _totalSalesCount1 = value; }
        }

        /// public propaty name  :  TotalSalesCount2
        /// <summary>売上数計2プロパティ</summary>
        /// <value>出荷数(返品は減算)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上数計2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double TotalSalesCount2
        {
            get { return _totalSalesCount2; }
            set { _totalSalesCount2 = value; }
        }

        /// public propaty name  :  TotalSalesCount3
        /// <summary>売上数計3プロパティ</summary>
        /// <value>出荷数(返品は減算)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上数計3プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double TotalSalesCount3
        {
            get { return _totalSalesCount3; }
            set { _totalSalesCount3 = value; }
        }

        /// public propaty name  :  TotalSalesCount4
        /// <summary>売上数計4プロパティ</summary>
        /// <value>出荷数(返品は減算)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上数計4プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double TotalSalesCount4
        {
            get { return _totalSalesCount4; }
            set { _totalSalesCount4 = value; }
        }

        /// public propaty name  :  TotalSalesCount5
        /// <summary>売上数計5プロパティ</summary>
        /// <value>出荷数(返品は減算)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上数計5プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double TotalSalesCount5
        {
            get { return _totalSalesCount5; }
            set { _totalSalesCount5 = value; }
        }

        /// public propaty name  :  TotalSalesCount6
        /// <summary>売上数計6プロパティ</summary>
        /// <value>出荷数(返品は減算)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上数計6プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double TotalSalesCount6
        {
            get { return _totalSalesCount6; }
            set { _totalSalesCount6 = value; }
        }

        /// public propaty name  :  TotalSalesCount7
        /// <summary>売上数計7プロパティ</summary>
        /// <value>出荷数(返品は減算)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上数計7プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double TotalSalesCount7
        {
            get { return _totalSalesCount7; }
            set { _totalSalesCount7 = value; }
        }

        /// public propaty name  :  TotalSalesCount8
        /// <summary>売上数計8プロパティ</summary>
        /// <value>出荷数(返品は減算)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上数計8プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double TotalSalesCount8
        {
            get { return _totalSalesCount8; }
            set { _totalSalesCount8 = value; }
        }

        /// public propaty name  :  TotalSalesCount9
        /// <summary>売上数計9プロパティ</summary>
        /// <value>出荷数(返品は減算)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上数計9プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double TotalSalesCount9
        {
            get { return _totalSalesCount9; }
            set { _totalSalesCount9 = value; }
        }

        /// public propaty name  :  TotalSalesCount10
        /// <summary>売上数計10プロパティ</summary>
        /// <value>出荷数(返品は減算)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上数計10プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double TotalSalesCount10
        {
            get { return _totalSalesCount10; }
            set { _totalSalesCount10 = value; }
        }

        /// public propaty name  :  TotalSalesCount11
        /// <summary>売上数計11プロパティ</summary>
        /// <value>出荷数(返品は減算)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上数計11プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double TotalSalesCount11
        {
            get { return _totalSalesCount11; }
            set { _totalSalesCount11 = value; }
        }

        /// public propaty name  :  TotalSalesCount12
        /// <summary>売上数計12プロパティ</summary>
        /// <value>出荷数(返品は減算)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上数計12プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double TotalSalesCount12
        {
            get { return _totalSalesCount12; }
            set { _totalSalesCount12 = value; }
        }


        /// <summary>
        /// 売上推移表抽出結果クラスワークコンストラクタ
        /// </summary>
        /// <returns>SalesTransListResultWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SalesTransListResultWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SalesTransListResultWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>SalesTransListResultWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   SalesTransListResultWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class SalesTransListResultWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   SalesTransListResultWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  SalesTransListResultWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is SalesTransListResultWork || graph is ArrayList || graph is SalesTransListResultWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(SalesTransListResultWork).FullName));

            if (graph != null && graph is SalesTransListResultWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.SalesTransListResultWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is SalesTransListResultWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((SalesTransListResultWork[])graph).Length;
            }
            else if (graph is SalesTransListResultWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //AddUpSecCode
            //拠点名称
            serInfo.MemberInfo.Add(typeof(string)); //CompanyName1
            //商品メーカーコード
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd
            //メーカー略称
            serInfo.MemberInfo.Add(typeof(string)); //MakerShortName
            //商品大分類コード
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsLGroup
            //商品大分類名称
            serInfo.MemberInfo.Add(typeof(string)); //GoodsLGroupName
            //商品中分類コード
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMGroup
            //商品中分類名称
            serInfo.MemberInfo.Add(typeof(string)); //GoodsMGroupName
            //BLグループコード
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGroupCode
            //BLグループコードカナ名称
            serInfo.MemberInfo.Add(typeof(string)); //BLGroupKanaName
            //BL商品コード
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGoodsCode
            //BL商品コード名称（半角）
            serInfo.MemberInfo.Add(typeof(string)); //BLGoodsHalfName
            //商品番号
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNo
            //商品名称
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNameKana
            //得意先コード
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerCode
            //得意先略称
            serInfo.MemberInfo.Add(typeof(string)); //CustomerSnm
            //仕入先コード
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierCode
            //仕入先略称
            serInfo.MemberInfo.Add(typeof(string)); //SupplierSnm
            //従業員コード
            serInfo.MemberInfo.Add(typeof(string)); //EmployeeCode
            //従業員名称
            serInfo.MemberInfo.Add(typeof(string)); //Name
            //売上金額1
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesMoney1
            //売上金額2
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesMoney2
            //売上金額3
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesMoney3
            //売上金額4
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesMoney4
            //売上金額5
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesMoney5
            //売上金額6
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesMoney6
            //売上金額7
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesMoney7
            //売上金額8
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesMoney8
            //売上金額9
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesMoney9
            //売上金額10
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesMoney10
            //売上金額11
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesMoney11
            //売上金額12
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesMoney12
            //売上数計1
            serInfo.MemberInfo.Add(typeof(Double)); //TotalSalesCount1
            //売上数計2
            serInfo.MemberInfo.Add(typeof(Double)); //TotalSalesCount2
            //売上数計3
            serInfo.MemberInfo.Add(typeof(Double)); //TotalSalesCount3
            //売上数計4
            serInfo.MemberInfo.Add(typeof(Double)); //TotalSalesCount4
            //売上数計5
            serInfo.MemberInfo.Add(typeof(Double)); //TotalSalesCount5
            //売上数計6
            serInfo.MemberInfo.Add(typeof(Double)); //TotalSalesCount6
            //売上数計7
            serInfo.MemberInfo.Add(typeof(Double)); //TotalSalesCount7
            //売上数計8
            serInfo.MemberInfo.Add(typeof(Double)); //TotalSalesCount8
            //売上数計9
            serInfo.MemberInfo.Add(typeof(Double)); //TotalSalesCount9
            //売上数計10
            serInfo.MemberInfo.Add(typeof(Double)); //TotalSalesCount10
            //売上数計11
            serInfo.MemberInfo.Add(typeof(Double)); //TotalSalesCount11
            //売上数計12
            serInfo.MemberInfo.Add(typeof(Double)); //TotalSalesCount12


            serInfo.Serialize(writer, serInfo);
            if (graph is SalesTransListResultWork)
            {
                SalesTransListResultWork temp = (SalesTransListResultWork)graph;

                SetSalesTransListResultWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is SalesTransListResultWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((SalesTransListResultWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (SalesTransListResultWork temp in lst)
                {
                    SetSalesTransListResultWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// SalesTransListResultWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 44;

        /// <summary>
        ///  SalesTransListResultWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   SalesTransListResultWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetSalesTransListResultWork(System.IO.BinaryWriter writer, SalesTransListResultWork temp)
        {
            //拠点コード
            writer.Write(temp.AddUpSecCode);
            //拠点名称
            writer.Write(temp.CompanyName1);
            //商品メーカーコード
            writer.Write(temp.GoodsMakerCd);
            //メーカー略称
            writer.Write(temp.MakerShortName);
            //商品大分類コード
            writer.Write(temp.GoodsLGroup);
            //商品大分類名称
            writer.Write(temp.GoodsLGroupName);
            //商品中分類コード
            writer.Write(temp.GoodsMGroup);
            //商品中分類名称
            writer.Write(temp.GoodsMGroupName);
            //BLグループコード
            writer.Write(temp.BLGroupCode);
            //BLグループコードカナ名称
            writer.Write(temp.BLGroupKanaName);
            //BL商品コード
            writer.Write(temp.BLGoodsCode);
            //BL商品コード名称（半角）
            writer.Write(temp.BLGoodsHalfName);
            //商品番号
            writer.Write(temp.GoodsNo);
            //商品名称
            writer.Write(temp.GoodsNameKana);
            //得意先コード
            writer.Write(temp.CustomerCode);
            //得意先略称
            writer.Write(temp.CustomerSnm);
            //仕入先コード
            writer.Write(temp.SupplierCode);
            //仕入先略称
            writer.Write(temp.SupplierSnm);
            //従業員コード
            writer.Write(temp.EmployeeCode);
            //従業員名称
            writer.Write(temp.Name);
            //売上金額1
            writer.Write(temp.SalesMoney1);
            //売上金額2
            writer.Write(temp.SalesMoney2);
            //売上金額3
            writer.Write(temp.SalesMoney3);
            //売上金額4
            writer.Write(temp.SalesMoney4);
            //売上金額5
            writer.Write(temp.SalesMoney5);
            //売上金額6
            writer.Write(temp.SalesMoney6);
            //売上金額7
            writer.Write(temp.SalesMoney7);
            //売上金額8
            writer.Write(temp.SalesMoney8);
            //売上金額9
            writer.Write(temp.SalesMoney9);
            //売上金額10
            writer.Write(temp.SalesMoney10);
            //売上金額11
            writer.Write(temp.SalesMoney11);
            //売上金額12
            writer.Write(temp.SalesMoney12);
            //売上数計1
            writer.Write(temp.TotalSalesCount1);
            //売上数計2
            writer.Write(temp.TotalSalesCount2);
            //売上数計3
            writer.Write(temp.TotalSalesCount3);
            //売上数計4
            writer.Write(temp.TotalSalesCount4);
            //売上数計5
            writer.Write(temp.TotalSalesCount5);
            //売上数計6
            writer.Write(temp.TotalSalesCount6);
            //売上数計7
            writer.Write(temp.TotalSalesCount7);
            //売上数計8
            writer.Write(temp.TotalSalesCount8);
            //売上数計9
            writer.Write(temp.TotalSalesCount9);
            //売上数計10
            writer.Write(temp.TotalSalesCount10);
            //売上数計11
            writer.Write(temp.TotalSalesCount11);
            //売上数計12
            writer.Write(temp.TotalSalesCount12);

        }

        /// <summary>
        ///  SalesTransListResultWorkインスタンス取得
        /// </summary>
        /// <returns>SalesTransListResultWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SalesTransListResultWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private SalesTransListResultWork GetSalesTransListResultWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            SalesTransListResultWork temp = new SalesTransListResultWork();

            //拠点コード
            temp.AddUpSecCode = reader.ReadString();
            //拠点名称
            temp.CompanyName1 = reader.ReadString();
            //商品メーカーコード
            temp.GoodsMakerCd = reader.ReadInt32();
            //メーカー略称
            temp.MakerShortName = reader.ReadString();
            //商品大分類コード
            temp.GoodsLGroup = reader.ReadInt32();
            //商品大分類名称
            temp.GoodsLGroupName = reader.ReadString();
            //商品中分類コード
            temp.GoodsMGroup = reader.ReadInt32();
            //商品中分類名称
            temp.GoodsMGroupName = reader.ReadString();
            //BLグループコード
            temp.BLGroupCode = reader.ReadInt32();
            //BLグループコードカナ名称
            temp.BLGroupKanaName = reader.ReadString();
            //BL商品コード
            temp.BLGoodsCode = reader.ReadInt32();
            //BL商品コード名称（半角）
            temp.BLGoodsHalfName = reader.ReadString();
            //商品番号
            temp.GoodsNo = reader.ReadString();
            //商品名称
            temp.GoodsNameKana = reader.ReadString();
            //得意先コード
            temp.CustomerCode = reader.ReadInt32();
            //得意先略称
            temp.CustomerSnm = reader.ReadString();
            //仕入先コード
            temp.SupplierCode = reader.ReadInt32();
            //仕入先略称
            temp.SupplierSnm = reader.ReadString();
            //従業員コード
            temp.EmployeeCode = reader.ReadString();
            //従業員名称
            temp.Name = reader.ReadString();
            //売上金額1
            temp.SalesMoney1 = reader.ReadInt64();
            //売上金額2
            temp.SalesMoney2 = reader.ReadInt64();
            //売上金額3
            temp.SalesMoney3 = reader.ReadInt64();
            //売上金額4
            temp.SalesMoney4 = reader.ReadInt64();
            //売上金額5
            temp.SalesMoney5 = reader.ReadInt64();
            //売上金額6
            temp.SalesMoney6 = reader.ReadInt64();
            //売上金額7
            temp.SalesMoney7 = reader.ReadInt64();
            //売上金額8
            temp.SalesMoney8 = reader.ReadInt64();
            //売上金額9
            temp.SalesMoney9 = reader.ReadInt64();
            //売上金額10
            temp.SalesMoney10 = reader.ReadInt64();
            //売上金額11
            temp.SalesMoney11 = reader.ReadInt64();
            //売上金額12
            temp.SalesMoney12 = reader.ReadInt64();
            //売上数計1
            temp.TotalSalesCount1 = reader.ReadDouble();
            //売上数計2
            temp.TotalSalesCount2 = reader.ReadDouble();
            //売上数計3
            temp.TotalSalesCount3 = reader.ReadDouble();
            //売上数計4
            temp.TotalSalesCount4 = reader.ReadDouble();
            //売上数計5
            temp.TotalSalesCount5 = reader.ReadDouble();
            //売上数計6
            temp.TotalSalesCount6 = reader.ReadDouble();
            //売上数計7
            temp.TotalSalesCount7 = reader.ReadDouble();
            //売上数計8
            temp.TotalSalesCount8 = reader.ReadDouble();
            //売上数計9
            temp.TotalSalesCount9 = reader.ReadDouble();
            //売上数計10
            temp.TotalSalesCount10 = reader.ReadDouble();
            //売上数計11
            temp.TotalSalesCount11 = reader.ReadDouble();
            //売上数計12
            temp.TotalSalesCount12 = reader.ReadDouble();


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
        /// <returns>SalesTransListResultWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SalesTransListResultWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                SalesTransListResultWork temp = GetSalesTransListResultWork(reader, serInfo);
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
                    retValue = (SalesTransListResultWork[])lst.ToArray(typeof(SalesTransListResultWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}
