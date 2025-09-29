using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   StockTransListResultWork
    /// <summary>
    ///                      仕入推移表抽出結果クラスワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   仕入推移表抽出結果クラスワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/03/06  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class StockTransListResultWork
    {
        /// <summary>計上拠点コード</summary>
        /// <remarks>集計の対象となっている拠点コード</remarks>
        private string _stockSectionCd = "";

        /// <summary>自社名称1</summary>
        private string _companyName1 = "";

        /// <summary>自社名称2</summary>
        private string _companyName2 = "";

        /// <summary>拠点ガイド名称</summary>
        private string _sectionGuideNm = "";

        /// <summary>部門コード</summary>
        private Int32 _subSectionCode;

        /// <summary>部門名称</summary>
        private string _subSectionName = "";

        /// <summary>課コード</summary>
        private Int32 _minSectionCode;

        /// <summary>課名称</summary>
        private string _minSectionName = "";

        /// <summary>従業員コード</summary>
        private string _employeeCode = "";

        /// <summary>従業員名称</summary>
        private string _employeeName = "";

        /// <summary>仕入先コード</summary>
        private Int32 _supplierCd;

        /// <summary>仕入先略称</summary>
        private string _supplierSnm = "";

        /// <summary>商品メーカーコード</summary>
        private Int32 _goodsMakerCd;

        /// <summary>メーカー名称</summary>
        private string _makerName = "";

        /// <summary>商品区分グループコード</summary>
        /// <remarks>旧：商品大分類コード</remarks>
        private string _largeGoodsGanreCode = "";

        /// <summary>商品区分グループ名称</summary>
        /// <remarks>旧：商品大分類名称</remarks>
        private string _largeGoodsGanreName = "";

        /// <summary>商品区分コード</summary>
        /// <remarks>旧：商品中分類コード</remarks>
        private string _mediumGoodsGanreCode = "";

        /// <summary>商品区分名称</summary>
        /// <remarks>旧：商品中分類名称</remarks>
        private string _mediumGoodsGanreName = "";

        /// <summary>商品区分詳細コード</summary>
        private string _detailGoodsGanreCode = "";

        /// <summary>商品区分詳細名称</summary>
        private string _detailGoodsGanreName = "";

        /// <summary>自社分類コード</summary>
        /// <remarks>商品マスタから取得</remarks>
        private Int32 _enterpriseGanreCode;

        /// <summary>自社分類名称</summary>
        /// <remarks>商品マスタから取得</remarks>
        private string _enterpriseGanreName = "";

        /// <summary>BL商品コード</summary>
        private Int32 _bLGoodsCode;

        /// <summary>BL商品コード名称（全角）</summary>
        private string _bLGoodsFullName = "";

        /// <summary>商品番号</summary>
        /// <remarks>（商品別の場合のみセット）</remarks>
        private string _goodsNo = "";

        /// <summary>商品名略称</summary>
        /// <remarks>（商品別の場合のみセット）</remarks>
        private string _goodsShortName = "";

        /// <summary>月仕入数計1</summary>
        /// <remarks>出荷数</remarks>
        private Double _totalStockCount1;

        /// <summary>月仕入数計2</summary>
        /// <remarks>出荷数</remarks>
        private Double _totalStockCount2;

        /// <summary>月仕入数計3</summary>
        /// <remarks>出荷数</remarks>
        private Double _totalStockCount3;

        /// <summary>月仕入数計4</summary>
        /// <remarks>出荷数</remarks>
        private Double _totalStockCount4;

        /// <summary>月仕入数計5</summary>
        /// <remarks>出荷数</remarks>
        private Double _totalStockCount5;

        /// <summary>月仕入数計6</summary>
        /// <remarks>出荷数</remarks>
        private Double _totalStockCount6;

        /// <summary>月仕入数計7</summary>
        /// <remarks>出荷数</remarks>
        private Double _totalStockCount7;

        /// <summary>月仕入数計8</summary>
        /// <remarks>出荷数</remarks>
        private Double _totalStockCount8;

        /// <summary>月仕入数計9</summary>
        /// <remarks>出荷数</remarks>
        private Double _totalStockCount9;

        /// <summary>月仕入数計10</summary>
        /// <remarks>出荷数</remarks>
        private Double _totalStockCount10;

        /// <summary>月仕入数計11</summary>
        /// <remarks>出荷数</remarks>
        private Double _totalStockCount11;

        /// <summary>月仕入数計12</summary>
        /// <remarks>出荷数</remarks>
        private Double _totalStockCount12;

        /// <summary>月仕入伝票合計1（税抜き）</summary>
        /// <remarks>仕入伝票の合計（税抜き＋値引込み）</remarks>
        private Int64 _stockTotalTaxExc1;

        /// <summary>月仕入伝票合計2（税抜き）</summary>
        /// <remarks>仕入伝票の合計（税抜き＋値引込み）</remarks>
        private Int64 _stockTotalTaxExc2;

        /// <summary>月仕入伝票合計3（税抜き）</summary>
        /// <remarks>仕入伝票の合計（税抜き＋値引込み）</remarks>
        private Int64 _stockTotalTaxExc3;

        /// <summary>月仕入伝票合計4（税抜き）</summary>
        /// <remarks>仕入伝票の合計（税抜き＋値引込み）</remarks>
        private Int64 _stockTotalTaxExc4;

        /// <summary>月仕入伝票合計5（税抜き）</summary>
        /// <remarks>仕入伝票の合計（税抜き＋値引込み）</remarks>
        private Int64 _stockTotalTaxExc5;

        /// <summary>月仕入伝票合計6（税抜き）</summary>
        /// <remarks>仕入伝票の合計（税抜き＋値引込み）</remarks>
        private Int64 _stockTotalTaxExc6;

        /// <summary>月仕入伝票合計7（税抜き）</summary>
        /// <remarks>仕入伝票の合計（税抜き＋値引込み）</remarks>
        private Int64 _stockTotalTaxExc7;

        /// <summary>月仕入伝票合計8（税抜き）</summary>
        /// <remarks>仕入伝票の合計（税抜き＋値引込み）</remarks>
        private Int64 _stockTotalTaxExc8;

        /// <summary>月仕入伝票合計9（税抜き）</summary>
        /// <remarks>仕入伝票の合計（税抜き＋値引込み）</remarks>
        private Int64 _stockTotalTaxExc9;

        /// <summary>月仕入伝票合計10（税抜き）</summary>
        /// <remarks>仕入伝票の合計（税抜き＋値引込み）</remarks>
        private Int64 _stockTotalTaxExc10;

        /// <summary>月仕入伝票合計11（税抜き）</summary>
        /// <remarks>仕入伝票の合計（税抜き＋値引込み）</remarks>
        private Int64 _stockTotalTaxExc11;

        /// <summary>月仕入伝票合計12（税抜き）</summary>
        /// <remarks>仕入伝票の合計（税抜き＋値引込み）</remarks>
        private Int64 _stockTotalTaxExc12;

        /// <summary>月返品額1</summary>
        /// <remarks>返品額</remarks>
        private Int64 _stockRetGoodsPrice1;

        /// <summary>月返品額2</summary>
        /// <remarks>返品額</remarks>
        private Int64 _stockRetGoodsPrice2;

        /// <summary>月返品額3</summary>
        /// <remarks>返品額</remarks>
        private Int64 _stockRetGoodsPrice3;

        /// <summary>月返品額4</summary>
        /// <remarks>返品額</remarks>
        private Int64 _stockRetGoodsPrice4;

        /// <summary>月返品額5</summary>
        /// <remarks>返品額</remarks>
        private Int64 _stockRetGoodsPrice5;

        /// <summary>月返品額6</summary>
        /// <remarks>返品額</remarks>
        private Int64 _stockRetGoodsPrice6;

        /// <summary>月返品額7</summary>
        /// <remarks>返品額</remarks>
        private Int64 _stockRetGoodsPrice7;

        /// <summary>月返品額8</summary>
        /// <remarks>返品額</remarks>
        private Int64 _stockRetGoodsPrice8;

        /// <summary>月返品額9</summary>
        /// <remarks>返品額</remarks>
        private Int64 _stockRetGoodsPrice9;

        /// <summary>月返品額10</summary>
        /// <remarks>返品額</remarks>
        private Int64 _stockRetGoodsPrice10;

        /// <summary>月返品額11</summary>
        /// <remarks>返品額</remarks>
        private Int64 _stockRetGoodsPrice11;

        /// <summary>月返品額12</summary>
        /// <remarks>返品額</remarks>
        private Int64 _stockRetGoodsPrice12;


        /// public propaty name  :  StockSectionCd
        /// <summary>計上拠点コードプロパティ</summary>
        /// <value>集計の対象となっている拠点コード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   計上拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string StockSectionCd
        {
            get { return _stockSectionCd; }
            set { _stockSectionCd = value; }
        }

        /// public propaty name  :  CompanyName1
        /// <summary>自社名称1プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社名称1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CompanyName1
        {
            get { return _companyName1; }
            set { _companyName1 = value; }
        }

        /// public propaty name  :  CompanyName2
        /// <summary>自社名称2プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社名称2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CompanyName2
        {
            get { return _companyName2; }
            set { _companyName2 = value; }
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

        /// public propaty name  :  SubSectionCode
        /// <summary>部門コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   部門コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SubSectionCode
        {
            get { return _subSectionCode; }
            set { _subSectionCode = value; }
        }

        /// public propaty name  :  SubSectionName
        /// <summary>部門名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   部門名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SubSectionName
        {
            get { return _subSectionName; }
            set { _subSectionName = value; }
        }

        /// public propaty name  :  MinSectionCode
        /// <summary>課コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   課コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 MinSectionCode
        {
            get { return _minSectionCode; }
            set { _minSectionCode = value; }
        }

        /// public propaty name  :  MinSectionName
        /// <summary>課名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   課名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MinSectionName
        {
            get { return _minSectionName; }
            set { _minSectionName = value; }
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

        /// public propaty name  :  EmployeeName
        /// <summary>従業員名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   従業員名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EmployeeName
        {
            get { return _employeeName; }
            set { _employeeName = value; }
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

        /// public propaty name  :  MakerName
        /// <summary>メーカー名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メーカー名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MakerName
        {
            get { return _makerName; }
            set { _makerName = value; }
        }

        /// public propaty name  :  LargeGoodsGanreCode
        /// <summary>商品区分グループコードプロパティ</summary>
        /// <value>旧：商品大分類コード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品区分グループコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string LargeGoodsGanreCode
        {
            get { return _largeGoodsGanreCode; }
            set { _largeGoodsGanreCode = value; }
        }

        /// public propaty name  :  LargeGoodsGanreName
        /// <summary>商品区分グループ名称プロパティ</summary>
        /// <value>旧：商品大分類名称</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品区分グループ名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string LargeGoodsGanreName
        {
            get { return _largeGoodsGanreName; }
            set { _largeGoodsGanreName = value; }
        }

        /// public propaty name  :  MediumGoodsGanreCode
        /// <summary>商品区分コードプロパティ</summary>
        /// <value>旧：商品中分類コード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品区分コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MediumGoodsGanreCode
        {
            get { return _mediumGoodsGanreCode; }
            set { _mediumGoodsGanreCode = value; }
        }

        /// public propaty name  :  MediumGoodsGanreName
        /// <summary>商品区分名称プロパティ</summary>
        /// <value>旧：商品中分類名称</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品区分名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MediumGoodsGanreName
        {
            get { return _mediumGoodsGanreName; }
            set { _mediumGoodsGanreName = value; }
        }

        /// public propaty name  :  DetailGoodsGanreCode
        /// <summary>商品区分詳細コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品区分詳細コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DetailGoodsGanreCode
        {
            get { return _detailGoodsGanreCode; }
            set { _detailGoodsGanreCode = value; }
        }

        /// public propaty name  :  DetailGoodsGanreName
        /// <summary>商品区分詳細名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品区分詳細名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DetailGoodsGanreName
        {
            get { return _detailGoodsGanreName; }
            set { _detailGoodsGanreName = value; }
        }

        /// public propaty name  :  EnterpriseGanreCode
        /// <summary>自社分類コードプロパティ</summary>
        /// <value>商品マスタから取得</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社分類コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 EnterpriseGanreCode
        {
            get { return _enterpriseGanreCode; }
            set { _enterpriseGanreCode = value; }
        }

        /// public propaty name  :  EnterpriseGanreName
        /// <summary>自社分類名称プロパティ</summary>
        /// <value>商品マスタから取得</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社分類名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EnterpriseGanreName
        {
            get { return _enterpriseGanreName; }
            set { _enterpriseGanreName = value; }
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

        /// public propaty name  :  BLGoodsFullName
        /// <summary>BL商品コード名称（全角）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL商品コード名称（全角）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string BLGoodsFullName
        {
            get { return _bLGoodsFullName; }
            set { _bLGoodsFullName = value; }
        }

        /// public propaty name  :  GoodsNo
        /// <summary>商品番号プロパティ</summary>
        /// <value>（商品別の場合のみセット）</value>
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

        /// public propaty name  :  GoodsShortName
        /// <summary>商品名略称プロパティ</summary>
        /// <value>（商品別の場合のみセット）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品名略称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsShortName
        {
            get { return _goodsShortName; }
            set { _goodsShortName = value; }
        }

        /// public propaty name  :  TotalStockCount1
        /// <summary>月仕入数計1プロパティ</summary>
        /// <value>出荷数</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   月仕入数計1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double TotalStockCount1
        {
            get { return _totalStockCount1; }
            set { _totalStockCount1 = value; }
        }

        /// public propaty name  :  TotalStockCount2
        /// <summary>月仕入数計2プロパティ</summary>
        /// <value>出荷数</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   月仕入数計2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double TotalStockCount2
        {
            get { return _totalStockCount2; }
            set { _totalStockCount2 = value; }
        }

        /// public propaty name  :  TotalStockCount3
        /// <summary>月仕入数計3プロパティ</summary>
        /// <value>出荷数</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   月仕入数計3プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double TotalStockCount3
        {
            get { return _totalStockCount3; }
            set { _totalStockCount3 = value; }
        }

        /// public propaty name  :  TotalStockCount4
        /// <summary>月仕入数計4プロパティ</summary>
        /// <value>出荷数</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   月仕入数計4プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double TotalStockCount4
        {
            get { return _totalStockCount4; }
            set { _totalStockCount4 = value; }
        }

        /// public propaty name  :  TotalStockCount5
        /// <summary>月仕入数計5プロパティ</summary>
        /// <value>出荷数</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   月仕入数計5プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double TotalStockCount5
        {
            get { return _totalStockCount5; }
            set { _totalStockCount5 = value; }
        }

        /// public propaty name  :  TotalStockCount6
        /// <summary>月仕入数計6プロパティ</summary>
        /// <value>出荷数</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   月仕入数計6プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double TotalStockCount6
        {
            get { return _totalStockCount6; }
            set { _totalStockCount6 = value; }
        }

        /// public propaty name  :  TotalStockCount7
        /// <summary>月仕入数計7プロパティ</summary>
        /// <value>出荷数</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   月仕入数計7プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double TotalStockCount7
        {
            get { return _totalStockCount7; }
            set { _totalStockCount7 = value; }
        }

        /// public propaty name  :  TotalStockCount8
        /// <summary>月仕入数計8プロパティ</summary>
        /// <value>出荷数</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   月仕入数計8プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double TotalStockCount8
        {
            get { return _totalStockCount8; }
            set { _totalStockCount8 = value; }
        }

        /// public propaty name  :  TotalStockCount9
        /// <summary>月仕入数計9プロパティ</summary>
        /// <value>出荷数</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   月仕入数計9プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double TotalStockCount9
        {
            get { return _totalStockCount9; }
            set { _totalStockCount9 = value; }
        }

        /// public propaty name  :  TotalStockCount10
        /// <summary>月仕入数計10プロパティ</summary>
        /// <value>出荷数</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   月仕入数計10プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double TotalStockCount10
        {
            get { return _totalStockCount10; }
            set { _totalStockCount10 = value; }
        }

        /// public propaty name  :  TotalStockCount11
        /// <summary>月仕入数計11プロパティ</summary>
        /// <value>出荷数</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   月仕入数計11プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double TotalStockCount11
        {
            get { return _totalStockCount11; }
            set { _totalStockCount11 = value; }
        }

        /// public propaty name  :  TotalStockCount12
        /// <summary>月仕入数計12プロパティ</summary>
        /// <value>出荷数</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   月仕入数計12プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double TotalStockCount12
        {
            get { return _totalStockCount12; }
            set { _totalStockCount12 = value; }
        }

        /// public propaty name  :  StockTotalTaxExc1
        /// <summary>月仕入伝票合計1（税抜き）プロパティ</summary>
        /// <value>仕入伝票の合計（税抜き＋値引込み）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   月仕入伝票合計1（税抜き）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 StockTotalTaxExc1
        {
            get { return _stockTotalTaxExc1; }
            set { _stockTotalTaxExc1 = value; }
        }

        /// public propaty name  :  StockTotalTaxExc2
        /// <summary>月仕入伝票合計2（税抜き）プロパティ</summary>
        /// <value>仕入伝票の合計（税抜き＋値引込み）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   月仕入伝票合計2（税抜き）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 StockTotalTaxExc2
        {
            get { return _stockTotalTaxExc2; }
            set { _stockTotalTaxExc2 = value; }
        }

        /// public propaty name  :  StockTotalTaxExc3
        /// <summary>月仕入伝票合計3（税抜き）プロパティ</summary>
        /// <value>仕入伝票の合計（税抜き＋値引込み）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   月仕入伝票合計3（税抜き）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 StockTotalTaxExc3
        {
            get { return _stockTotalTaxExc3; }
            set { _stockTotalTaxExc3 = value; }
        }

        /// public propaty name  :  StockTotalTaxExc4
        /// <summary>月仕入伝票合計4（税抜き）プロパティ</summary>
        /// <value>仕入伝票の合計（税抜き＋値引込み）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   月仕入伝票合計4（税抜き）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 StockTotalTaxExc4
        {
            get { return _stockTotalTaxExc4; }
            set { _stockTotalTaxExc4 = value; }
        }

        /// public propaty name  :  StockTotalTaxExc5
        /// <summary>月仕入伝票合計5（税抜き）プロパティ</summary>
        /// <value>仕入伝票の合計（税抜き＋値引込み）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   月仕入伝票合計5（税抜き）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 StockTotalTaxExc5
        {
            get { return _stockTotalTaxExc5; }
            set { _stockTotalTaxExc5 = value; }
        }

        /// public propaty name  :  StockTotalTaxExc6
        /// <summary>月仕入伝票合計6（税抜き）プロパティ</summary>
        /// <value>仕入伝票の合計（税抜き＋値引込み）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   月仕入伝票合計6（税抜き）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 StockTotalTaxExc6
        {
            get { return _stockTotalTaxExc6; }
            set { _stockTotalTaxExc6 = value; }
        }

        /// public propaty name  :  StockTotalTaxExc7
        /// <summary>月仕入伝票合計7（税抜き）プロパティ</summary>
        /// <value>仕入伝票の合計（税抜き＋値引込み）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   月仕入伝票合計7（税抜き）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 StockTotalTaxExc7
        {
            get { return _stockTotalTaxExc7; }
            set { _stockTotalTaxExc7 = value; }
        }

        /// public propaty name  :  StockTotalTaxExc8
        /// <summary>月仕入伝票合計8（税抜き）プロパティ</summary>
        /// <value>仕入伝票の合計（税抜き＋値引込み）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   月仕入伝票合計8（税抜き）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 StockTotalTaxExc8
        {
            get { return _stockTotalTaxExc8; }
            set { _stockTotalTaxExc8 = value; }
        }

        /// public propaty name  :  StockTotalTaxExc9
        /// <summary>月仕入伝票合計9（税抜き）プロパティ</summary>
        /// <value>仕入伝票の合計（税抜き＋値引込み）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   月仕入伝票合計9（税抜き）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 StockTotalTaxExc9
        {
            get { return _stockTotalTaxExc9; }
            set { _stockTotalTaxExc9 = value; }
        }

        /// public propaty name  :  StockTotalTaxExc10
        /// <summary>月仕入伝票合計10（税抜き）プロパティ</summary>
        /// <value>仕入伝票の合計（税抜き＋値引込み）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   月仕入伝票合計10（税抜き）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 StockTotalTaxExc10
        {
            get { return _stockTotalTaxExc10; }
            set { _stockTotalTaxExc10 = value; }
        }

        /// public propaty name  :  StockTotalTaxExc11
        /// <summary>月仕入伝票合計11（税抜き）プロパティ</summary>
        /// <value>仕入伝票の合計（税抜き＋値引込み）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   月仕入伝票合計11（税抜き）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 StockTotalTaxExc11
        {
            get { return _stockTotalTaxExc11; }
            set { _stockTotalTaxExc11 = value; }
        }

        /// public propaty name  :  StockTotalTaxExc12
        /// <summary>月仕入伝票合計12（税抜き）プロパティ</summary>
        /// <value>仕入伝票の合計（税抜き＋値引込み）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   月仕入伝票合計12（税抜き）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 StockTotalTaxExc12
        {
            get { return _stockTotalTaxExc12; }
            set { _stockTotalTaxExc12 = value; }
        }

        /// public propaty name  :  StockRetGoodsPrice1
        /// <summary>月返品額1プロパティ</summary>
        /// <value>返品額</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   月返品額1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 StockRetGoodsPrice1
        {
            get { return _stockRetGoodsPrice1; }
            set { _stockRetGoodsPrice1 = value; }
        }

        /// public propaty name  :  StockRetGoodsPrice2
        /// <summary>月返品額2プロパティ</summary>
        /// <value>返品額</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   月返品額2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 StockRetGoodsPrice2
        {
            get { return _stockRetGoodsPrice2; }
            set { _stockRetGoodsPrice2 = value; }
        }

        /// public propaty name  :  StockRetGoodsPrice3
        /// <summary>月返品額3プロパティ</summary>
        /// <value>返品額</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   月返品額3プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 StockRetGoodsPrice3
        {
            get { return _stockRetGoodsPrice3; }
            set { _stockRetGoodsPrice3 = value; }
        }

        /// public propaty name  :  StockRetGoodsPrice4
        /// <summary>月返品額4プロパティ</summary>
        /// <value>返品額</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   月返品額4プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 StockRetGoodsPrice4
        {
            get { return _stockRetGoodsPrice4; }
            set { _stockRetGoodsPrice4 = value; }
        }

        /// public propaty name  :  StockRetGoodsPrice5
        /// <summary>月返品額5プロパティ</summary>
        /// <value>返品額</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   月返品額5プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 StockRetGoodsPrice5
        {
            get { return _stockRetGoodsPrice5; }
            set { _stockRetGoodsPrice5 = value; }
        }

        /// public propaty name  :  StockRetGoodsPrice6
        /// <summary>月返品額6プロパティ</summary>
        /// <value>返品額</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   月返品額6プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 StockRetGoodsPrice6
        {
            get { return _stockRetGoodsPrice6; }
            set { _stockRetGoodsPrice6 = value; }
        }

        /// public propaty name  :  StockRetGoodsPrice7
        /// <summary>月返品額7プロパティ</summary>
        /// <value>返品額</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   月返品額7プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 StockRetGoodsPrice7
        {
            get { return _stockRetGoodsPrice7; }
            set { _stockRetGoodsPrice7 = value; }
        }

        /// public propaty name  :  StockRetGoodsPrice8
        /// <summary>月返品額8プロパティ</summary>
        /// <value>返品額</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   月返品額8プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 StockRetGoodsPrice8
        {
            get { return _stockRetGoodsPrice8; }
            set { _stockRetGoodsPrice8 = value; }
        }

        /// public propaty name  :  StockRetGoodsPrice9
        /// <summary>月返品額9プロパティ</summary>
        /// <value>返品額</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   月返品額9プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 StockRetGoodsPrice9
        {
            get { return _stockRetGoodsPrice9; }
            set { _stockRetGoodsPrice9 = value; }
        }

        /// public propaty name  :  StockRetGoodsPrice10
        /// <summary>月返品額10プロパティ</summary>
        /// <value>返品額</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   月返品額10プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 StockRetGoodsPrice10
        {
            get { return _stockRetGoodsPrice10; }
            set { _stockRetGoodsPrice10 = value; }
        }

        /// public propaty name  :  StockRetGoodsPrice11
        /// <summary>月返品額11プロパティ</summary>
        /// <value>返品額</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   月返品額11プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 StockRetGoodsPrice11
        {
            get { return _stockRetGoodsPrice11; }
            set { _stockRetGoodsPrice11 = value; }
        }

        /// public propaty name  :  StockRetGoodsPrice12
        /// <summary>月返品額12プロパティ</summary>
        /// <value>返品額</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   月返品額12プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 StockRetGoodsPrice12
        {
            get { return _stockRetGoodsPrice12; }
            set { _stockRetGoodsPrice12 = value; }
        }


        /// <summary>
        /// 仕入推移表抽出結果クラスワークコンストラクタ
        /// </summary>
        /// <returns>StockTransListResultWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockTransListResultWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public StockTransListResultWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>StockTransListResultWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   StockTransListResultWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class StockTransListResultWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockTransListResultWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  StockTransListResultWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is StockTransListResultWork || graph is ArrayList || graph is StockTransListResultWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(StockTransListResultWork).FullName));

            if (graph != null && graph is StockTransListResultWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.StockTransListResultWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is StockTransListResultWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((StockTransListResultWork[])graph).Length;
            }
            else if (graph is StockTransListResultWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //計上拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //StockSectionCd
            //自社名称1
            serInfo.MemberInfo.Add(typeof(string)); //CompanyName1
            //自社名称2
            serInfo.MemberInfo.Add(typeof(string)); //CompanyName2
            //拠点ガイド名称
            serInfo.MemberInfo.Add(typeof(string)); //SectionGuideNm
            //部門コード
            serInfo.MemberInfo.Add(typeof(Int32)); //SubSectionCode
            //部門名称
            serInfo.MemberInfo.Add(typeof(string)); //SubSectionName
            //課コード
            serInfo.MemberInfo.Add(typeof(Int32)); //MinSectionCode
            //課名称
            serInfo.MemberInfo.Add(typeof(string)); //MinSectionName
            //従業員コード
            serInfo.MemberInfo.Add(typeof(string)); //EmployeeCode
            //従業員名称
            serInfo.MemberInfo.Add(typeof(string)); //EmployeeName
            //仕入先コード
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierCd
            //仕入先略称
            serInfo.MemberInfo.Add(typeof(string)); //SupplierSnm
            //商品メーカーコード
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd
            //メーカー名称
            serInfo.MemberInfo.Add(typeof(string)); //MakerName
            //商品区分グループコード
            serInfo.MemberInfo.Add(typeof(string)); //LargeGoodsGanreCode
            //商品区分グループ名称
            serInfo.MemberInfo.Add(typeof(string)); //LargeGoodsGanreName
            //商品区分コード
            serInfo.MemberInfo.Add(typeof(string)); //MediumGoodsGanreCode
            //商品区分名称
            serInfo.MemberInfo.Add(typeof(string)); //MediumGoodsGanreName
            //商品区分詳細コード
            serInfo.MemberInfo.Add(typeof(string)); //DetailGoodsGanreCode
            //商品区分詳細名称
            serInfo.MemberInfo.Add(typeof(string)); //DetailGoodsGanreName
            //自社分類コード
            serInfo.MemberInfo.Add(typeof(Int32)); //EnterpriseGanreCode
            //自社分類名称
            serInfo.MemberInfo.Add(typeof(string)); //EnterpriseGanreName
            //BL商品コード
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGoodsCode
            //BL商品コード名称（全角）
            serInfo.MemberInfo.Add(typeof(string)); //BLGoodsFullName
            //商品番号
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNo
            //商品名略称
            serInfo.MemberInfo.Add(typeof(string)); //GoodsShortName
            //月仕入数計1
            serInfo.MemberInfo.Add(typeof(Double)); //TotalStockCount1
            //月仕入数計2
            serInfo.MemberInfo.Add(typeof(Double)); //TotalStockCount2
            //月仕入数計3
            serInfo.MemberInfo.Add(typeof(Double)); //TotalStockCount3
            //月仕入数計4
            serInfo.MemberInfo.Add(typeof(Double)); //TotalStockCount4
            //月仕入数計5
            serInfo.MemberInfo.Add(typeof(Double)); //TotalStockCount5
            //月仕入数計6
            serInfo.MemberInfo.Add(typeof(Double)); //TotalStockCount6
            //月仕入数計7
            serInfo.MemberInfo.Add(typeof(Double)); //TotalStockCount7
            //月仕入数計8
            serInfo.MemberInfo.Add(typeof(Double)); //TotalStockCount8
            //月仕入数計9
            serInfo.MemberInfo.Add(typeof(Double)); //TotalStockCount9
            //月仕入数計10
            serInfo.MemberInfo.Add(typeof(Double)); //TotalStockCount10
            //月仕入数計11
            serInfo.MemberInfo.Add(typeof(Double)); //TotalStockCount11
            //月仕入数計12
            serInfo.MemberInfo.Add(typeof(Double)); //TotalStockCount12
            //月仕入伝票合計1（税抜き）
            serInfo.MemberInfo.Add(typeof(Int64)); //StockTotalTaxExc1
            //月仕入伝票合計2（税抜き）
            serInfo.MemberInfo.Add(typeof(Int64)); //StockTotalTaxExc2
            //月仕入伝票合計3（税抜き）
            serInfo.MemberInfo.Add(typeof(Int64)); //StockTotalTaxExc3
            //月仕入伝票合計4（税抜き）
            serInfo.MemberInfo.Add(typeof(Int64)); //StockTotalTaxExc4
            //月仕入伝票合計5（税抜き）
            serInfo.MemberInfo.Add(typeof(Int64)); //StockTotalTaxExc5
            //月仕入伝票合計6（税抜き）
            serInfo.MemberInfo.Add(typeof(Int64)); //StockTotalTaxExc6
            //月仕入伝票合計7（税抜き）
            serInfo.MemberInfo.Add(typeof(Int64)); //StockTotalTaxExc7
            //月仕入伝票合計8（税抜き）
            serInfo.MemberInfo.Add(typeof(Int64)); //StockTotalTaxExc8
            //月仕入伝票合計9（税抜き）
            serInfo.MemberInfo.Add(typeof(Int64)); //StockTotalTaxExc9
            //月仕入伝票合計10（税抜き）
            serInfo.MemberInfo.Add(typeof(Int64)); //StockTotalTaxExc10
            //月仕入伝票合計11（税抜き）
            serInfo.MemberInfo.Add(typeof(Int64)); //StockTotalTaxExc11
            //月仕入伝票合計12（税抜き）
            serInfo.MemberInfo.Add(typeof(Int64)); //StockTotalTaxExc12
            //月返品額1
            serInfo.MemberInfo.Add(typeof(Int64)); //StockRetGoodsPrice1
            //月返品額2
            serInfo.MemberInfo.Add(typeof(Int64)); //StockRetGoodsPrice2
            //月返品額3
            serInfo.MemberInfo.Add(typeof(Int64)); //StockRetGoodsPrice3
            //月返品額4
            serInfo.MemberInfo.Add(typeof(Int64)); //StockRetGoodsPrice4
            //月返品額5
            serInfo.MemberInfo.Add(typeof(Int64)); //StockRetGoodsPrice5
            //月返品額6
            serInfo.MemberInfo.Add(typeof(Int64)); //StockRetGoodsPrice6
            //月返品額7
            serInfo.MemberInfo.Add(typeof(Int64)); //StockRetGoodsPrice7
            //月返品額8
            serInfo.MemberInfo.Add(typeof(Int64)); //StockRetGoodsPrice8
            //月返品額9
            serInfo.MemberInfo.Add(typeof(Int64)); //StockRetGoodsPrice9
            //月返品額10
            serInfo.MemberInfo.Add(typeof(Int64)); //StockRetGoodsPrice10
            //月返品額11
            serInfo.MemberInfo.Add(typeof(Int64)); //StockRetGoodsPrice11
            //月返品額12
            serInfo.MemberInfo.Add(typeof(Int64)); //StockRetGoodsPrice12


            serInfo.Serialize(writer, serInfo);
            if (graph is StockTransListResultWork)
            {
                StockTransListResultWork temp = (StockTransListResultWork)graph;

                SetStockTransListResultWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is StockTransListResultWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((StockTransListResultWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (StockTransListResultWork temp in lst)
                {
                    SetStockTransListResultWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// StockTransListResultWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 62;

        /// <summary>
        ///  StockTransListResultWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockTransListResultWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetStockTransListResultWork(System.IO.BinaryWriter writer, StockTransListResultWork temp)
        {
            //計上拠点コード
            writer.Write(temp.StockSectionCd);
            //自社名称1
            writer.Write(temp.CompanyName1);
            //自社名称2
            writer.Write(temp.CompanyName2);
            //拠点ガイド名称
            writer.Write(temp.SectionGuideNm);
            //部門コード
            writer.Write(temp.SubSectionCode);
            //部門名称
            writer.Write(temp.SubSectionName);
            //課コード
            writer.Write(temp.MinSectionCode);
            //課名称
            writer.Write(temp.MinSectionName);
            //従業員コード
            writer.Write(temp.EmployeeCode);
            //従業員名称
            writer.Write(temp.EmployeeName);
            //仕入先コード
            writer.Write(temp.SupplierCd);
            //仕入先略称
            writer.Write(temp.SupplierSnm);
            //商品メーカーコード
            writer.Write(temp.GoodsMakerCd);
            //メーカー名称
            writer.Write(temp.MakerName);
            //商品区分グループコード
            writer.Write(temp.LargeGoodsGanreCode);
            //商品区分グループ名称
            writer.Write(temp.LargeGoodsGanreName);
            //商品区分コード
            writer.Write(temp.MediumGoodsGanreCode);
            //商品区分名称
            writer.Write(temp.MediumGoodsGanreName);
            //商品区分詳細コード
            writer.Write(temp.DetailGoodsGanreCode);
            //商品区分詳細名称
            writer.Write(temp.DetailGoodsGanreName);
            //自社分類コード
            writer.Write(temp.EnterpriseGanreCode);
            //自社分類名称
            writer.Write(temp.EnterpriseGanreName);
            //BL商品コード
            writer.Write(temp.BLGoodsCode);
            //BL商品コード名称（全角）
            writer.Write(temp.BLGoodsFullName);
            //商品番号
            writer.Write(temp.GoodsNo);
            //商品名略称
            writer.Write(temp.GoodsShortName);
            //月仕入数計1
            writer.Write(temp.TotalStockCount1);
            //月仕入数計2
            writer.Write(temp.TotalStockCount2);
            //月仕入数計3
            writer.Write(temp.TotalStockCount3);
            //月仕入数計4
            writer.Write(temp.TotalStockCount4);
            //月仕入数計5
            writer.Write(temp.TotalStockCount5);
            //月仕入数計6
            writer.Write(temp.TotalStockCount6);
            //月仕入数計7
            writer.Write(temp.TotalStockCount7);
            //月仕入数計8
            writer.Write(temp.TotalStockCount8);
            //月仕入数計9
            writer.Write(temp.TotalStockCount9);
            //月仕入数計10
            writer.Write(temp.TotalStockCount10);
            //月仕入数計11
            writer.Write(temp.TotalStockCount11);
            //月仕入数計12
            writer.Write(temp.TotalStockCount12);
            //月仕入伝票合計1（税抜き）
            writer.Write(temp.StockTotalTaxExc1);
            //月仕入伝票合計2（税抜き）
            writer.Write(temp.StockTotalTaxExc2);
            //月仕入伝票合計3（税抜き）
            writer.Write(temp.StockTotalTaxExc3);
            //月仕入伝票合計4（税抜き）
            writer.Write(temp.StockTotalTaxExc4);
            //月仕入伝票合計5（税抜き）
            writer.Write(temp.StockTotalTaxExc5);
            //月仕入伝票合計6（税抜き）
            writer.Write(temp.StockTotalTaxExc6);
            //月仕入伝票合計7（税抜き）
            writer.Write(temp.StockTotalTaxExc7);
            //月仕入伝票合計8（税抜き）
            writer.Write(temp.StockTotalTaxExc8);
            //月仕入伝票合計9（税抜き）
            writer.Write(temp.StockTotalTaxExc9);
            //月仕入伝票合計10（税抜き）
            writer.Write(temp.StockTotalTaxExc10);
            //月仕入伝票合計11（税抜き）
            writer.Write(temp.StockTotalTaxExc11);
            //月仕入伝票合計12（税抜き）
            writer.Write(temp.StockTotalTaxExc12);
            //月返品額1
            writer.Write(temp.StockRetGoodsPrice1);
            //月返品額2
            writer.Write(temp.StockRetGoodsPrice2);
            //月返品額3
            writer.Write(temp.StockRetGoodsPrice3);
            //月返品額4
            writer.Write(temp.StockRetGoodsPrice4);
            //月返品額5
            writer.Write(temp.StockRetGoodsPrice5);
            //月返品額6
            writer.Write(temp.StockRetGoodsPrice6);
            //月返品額7
            writer.Write(temp.StockRetGoodsPrice7);
            //月返品額8
            writer.Write(temp.StockRetGoodsPrice8);
            //月返品額9
            writer.Write(temp.StockRetGoodsPrice9);
            //月返品額10
            writer.Write(temp.StockRetGoodsPrice10);
            //月返品額11
            writer.Write(temp.StockRetGoodsPrice11);
            //月返品額12
            writer.Write(temp.StockRetGoodsPrice12);

        }

        /// <summary>
        ///  StockTransListResultWorkインスタンス取得
        /// </summary>
        /// <returns>StockTransListResultWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockTransListResultWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private StockTransListResultWork GetStockTransListResultWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            StockTransListResultWork temp = new StockTransListResultWork();

            //計上拠点コード
            temp.StockSectionCd = reader.ReadString();
            //自社名称1
            temp.CompanyName1 = reader.ReadString();
            //自社名称2
            temp.CompanyName2 = reader.ReadString();
            //拠点ガイド名称
            temp.SectionGuideNm = reader.ReadString();
            //部門コード
            temp.SubSectionCode = reader.ReadInt32();
            //部門名称
            temp.SubSectionName = reader.ReadString();
            //課コード
            temp.MinSectionCode = reader.ReadInt32();
            //課名称
            temp.MinSectionName = reader.ReadString();
            //従業員コード
            temp.EmployeeCode = reader.ReadString();
            //従業員名称
            temp.EmployeeName = reader.ReadString();
            //仕入先コード
            temp.SupplierCd = reader.ReadInt32();
            //仕入先略称
            temp.SupplierSnm = reader.ReadString();
            //商品メーカーコード
            temp.GoodsMakerCd = reader.ReadInt32();
            //メーカー名称
            temp.MakerName = reader.ReadString();
            //商品区分グループコード
            temp.LargeGoodsGanreCode = reader.ReadString();
            //商品区分グループ名称
            temp.LargeGoodsGanreName = reader.ReadString();
            //商品区分コード
            temp.MediumGoodsGanreCode = reader.ReadString();
            //商品区分名称
            temp.MediumGoodsGanreName = reader.ReadString();
            //商品区分詳細コード
            temp.DetailGoodsGanreCode = reader.ReadString();
            //商品区分詳細名称
            temp.DetailGoodsGanreName = reader.ReadString();
            //自社分類コード
            temp.EnterpriseGanreCode = reader.ReadInt32();
            //自社分類名称
            temp.EnterpriseGanreName = reader.ReadString();
            //BL商品コード
            temp.BLGoodsCode = reader.ReadInt32();
            //BL商品コード名称（全角）
            temp.BLGoodsFullName = reader.ReadString();
            //商品番号
            temp.GoodsNo = reader.ReadString();
            //商品名略称
            temp.GoodsShortName = reader.ReadString();
            //月仕入数計1
            temp.TotalStockCount1 = reader.ReadDouble();
            //月仕入数計2
            temp.TotalStockCount2 = reader.ReadDouble();
            //月仕入数計3
            temp.TotalStockCount3 = reader.ReadDouble();
            //月仕入数計4
            temp.TotalStockCount4 = reader.ReadDouble();
            //月仕入数計5
            temp.TotalStockCount5 = reader.ReadDouble();
            //月仕入数計6
            temp.TotalStockCount6 = reader.ReadDouble();
            //月仕入数計7
            temp.TotalStockCount7 = reader.ReadDouble();
            //月仕入数計8
            temp.TotalStockCount8 = reader.ReadDouble();
            //月仕入数計9
            temp.TotalStockCount9 = reader.ReadDouble();
            //月仕入数計10
            temp.TotalStockCount10 = reader.ReadDouble();
            //月仕入数計11
            temp.TotalStockCount11 = reader.ReadDouble();
            //月仕入数計12
            temp.TotalStockCount12 = reader.ReadDouble();
            //月仕入伝票合計1（税抜き）
            temp.StockTotalTaxExc1 = reader.ReadInt64();
            //月仕入伝票合計2（税抜き）
            temp.StockTotalTaxExc2 = reader.ReadInt64();
            //月仕入伝票合計3（税抜き）
            temp.StockTotalTaxExc3 = reader.ReadInt64();
            //月仕入伝票合計4（税抜き）
            temp.StockTotalTaxExc4 = reader.ReadInt64();
            //月仕入伝票合計5（税抜き）
            temp.StockTotalTaxExc5 = reader.ReadInt64();
            //月仕入伝票合計6（税抜き）
            temp.StockTotalTaxExc6 = reader.ReadInt64();
            //月仕入伝票合計7（税抜き）
            temp.StockTotalTaxExc7 = reader.ReadInt64();
            //月仕入伝票合計8（税抜き）
            temp.StockTotalTaxExc8 = reader.ReadInt64();
            //月仕入伝票合計9（税抜き）
            temp.StockTotalTaxExc9 = reader.ReadInt64();
            //月仕入伝票合計10（税抜き）
            temp.StockTotalTaxExc10 = reader.ReadInt64();
            //月仕入伝票合計11（税抜き）
            temp.StockTotalTaxExc11 = reader.ReadInt64();
            //月仕入伝票合計12（税抜き）
            temp.StockTotalTaxExc12 = reader.ReadInt64();
            //月返品額1
            temp.StockRetGoodsPrice1 = reader.ReadInt64();
            //月返品額2
            temp.StockRetGoodsPrice2 = reader.ReadInt64();
            //月返品額3
            temp.StockRetGoodsPrice3 = reader.ReadInt64();
            //月返品額4
            temp.StockRetGoodsPrice4 = reader.ReadInt64();
            //月返品額5
            temp.StockRetGoodsPrice5 = reader.ReadInt64();
            //月返品額6
            temp.StockRetGoodsPrice6 = reader.ReadInt64();
            //月返品額7
            temp.StockRetGoodsPrice7 = reader.ReadInt64();
            //月返品額8
            temp.StockRetGoodsPrice8 = reader.ReadInt64();
            //月返品額9
            temp.StockRetGoodsPrice9 = reader.ReadInt64();
            //月返品額10
            temp.StockRetGoodsPrice10 = reader.ReadInt64();
            //月返品額11
            temp.StockRetGoodsPrice11 = reader.ReadInt64();
            //月返品額12
            temp.StockRetGoodsPrice12 = reader.ReadInt64();


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
        /// <returns>StockTransListResultWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockTransListResultWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                StockTransListResultWork temp = GetStockTransListResultWork(reader, serInfo);
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
                    retValue = (StockTransListResultWork[])lst.ToArray(typeof(StockTransListResultWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

}
