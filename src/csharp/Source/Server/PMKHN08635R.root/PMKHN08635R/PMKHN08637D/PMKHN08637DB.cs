using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   SalTrgtPrintResultWork
    /// <summary>
    ///                      売上目標設定印刷抽出結果クラスワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   売上目標設定印刷抽出結果クラスワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/11/11  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class SalTrgtPrintResultWork 
    {
        /// <summary>更新日時</summary>
        /// <remarks>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</remarks>
        private DateTime _updateDateTime;

        /// <summary>拠点コード</summary>
        private string _sectionCode = "";

        /// <summary>拠点ガイド略称</summary>
        /// <remarks>帳票印字用</remarks>
        private string _sectionGuideSnm = "";

        /// <summary>部門コード</summary>
        private Int32 _subSectionCode;

        /// <summary>部門名称</summary>
        private string _subSectionName = "";

        /// <summary>担当者コード</summary>
        private string _salesEmployeeCd = "";

        /// <summary>担当者名称</summary>
        private string _salesEmployeeNm = "";

        /// <summary>受注者コード</summary>
        private string _frontEmployeeCd = "";

        /// <summary>受注者名称</summary>
        private string _frontEmployeeNm = "";

        /// <summary>発行者コード</summary>
        private string _salesInputCode = "";

        /// <summary>発行者名称</summary>
        private string _salesInputName = "";

        /// <summary>販売区分コード</summary>
        private Int32 _salesCode;

        /// <summary>販売区分名称</summary>
        private string _salesCodeName = "";

        /// <summary>商品区分コード</summary>
        /// <remarks>自社分類コード</remarks>
        private Int32 _enterpriseGanreCode;

        /// <summary>商品区分名称</summary>
        private string _enterpriseGanreCodeName = "";

        /// <summary>得意先コード</summary>
        private Int32 _customerCode;

        /// <summary>得意先略称</summary>
        private string _customerSnm = "";

        /// <summary>業種コード</summary>
        private Int32 _businessTypeCode;

        /// <summary>業種名称</summary>
        private string _businessTypeCodeName = "";

        /// <summary>販売エリアコード</summary>
        private Int32 _salesAreaCode;

        /// <summary>販売エリア名称</summary>
        private string _salesAreaCodeName = "";

        /// <summary>売上目標金額１</summary>
        private Int64 _salesTargetMoney1;

        /// <summary>売上目標金額２</summary>
        private Int64 _salesTargetMoney2;

        /// <summary>売上目標金額３</summary>
        private Int64 _salesTargetMoney3;

        /// <summary>売上目標金額４</summary>
        private Int64 _salesTargetMoney4;

        /// <summary>売上目標金額５</summary>
        private Int64 _salesTargetMoney5;

        /// <summary>売上目標金額６</summary>
        private Int64 _salesTargetMoney6;

        /// <summary>売上目標金額７</summary>
        private Int64 _salesTargetMoney7;

        /// <summary>売上目標金額８</summary>
        private Int64 _salesTargetMoney8;

        /// <summary>売上目標金額９</summary>
        private Int64 _salesTargetMoney9;

        /// <summary>売上目標金額１０</summary>
        private Int64 _salesTargetMoney10;

        /// <summary>売上目標金額１１</summary>
        private Int64 _salesTargetMoney11;

        /// <summary>売上目標金額１２</summary>
        private Int64 _salesTargetMoney12;

        /// <summary>売上目標粗利額１</summary>
        private Int64 _salesTargetProfit1;

        /// <summary>売上目標粗利額２</summary>
        private Int64 _salesTargetProfit2;

        /// <summary>売上目標粗利額３</summary>
        private Int64 _salesTargetProfit3;

        /// <summary>売上目標粗利額４</summary>
        private Int64 _salesTargetProfit4;

        /// <summary>売上目標粗利額５</summary>
        private Int64 _salesTargetProfit5;

        /// <summary>売上目標粗利額６</summary>
        private Int64 _salesTargetProfit6;

        /// <summary>売上目標粗利額７</summary>
        private Int64 _salesTargetProfit7;

        /// <summary>売上目標粗利額８</summary>
        private Int64 _salesTargetProfit8;

        /// <summary>売上目標粗利額９</summary>
        private Int64 _salesTargetProfit9;

        /// <summary>売上目標粗利額１０</summary>
        private Int64 _salesTargetProfit10;

        /// <summary>売上目標粗利額１１</summary>
        private Int64 _salesTargetProfit11;

        /// <summary>売上目標粗利額１２</summary>
        private Int64 _salesTargetProfit12;


        /// public propaty name  :  UpdateDateTime
        /// <summary>更新日時プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新日時プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime UpdateDateTime
        {
            get { return _updateDateTime; }
            set { _updateDateTime = value; }
        }

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

        /// public propaty name  :  SalesEmployeeCd
        /// <summary>担当者コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   担当者コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SalesEmployeeCd
        {
            get { return _salesEmployeeCd; }
            set { _salesEmployeeCd = value; }
        }

        /// public propaty name  :  SalesEmployeeNm
        /// <summary>担当者名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   担当者名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SalesEmployeeNm
        {
            get { return _salesEmployeeNm; }
            set { _salesEmployeeNm = value; }
        }

        /// public propaty name  :  FrontEmployeeCd
        /// <summary>受注者コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   受注者コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string FrontEmployeeCd
        {
            get { return _frontEmployeeCd; }
            set { _frontEmployeeCd = value; }
        }

        /// public propaty name  :  FrontEmployeeNm
        /// <summary>受注者名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   受注者名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string FrontEmployeeNm
        {
            get { return _frontEmployeeNm; }
            set { _frontEmployeeNm = value; }
        }

        /// public propaty name  :  SalesInputCode
        /// <summary>発行者コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   発行者コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SalesInputCode
        {
            get { return _salesInputCode; }
            set { _salesInputCode = value; }
        }

        /// public propaty name  :  SalesInputName
        /// <summary>発行者名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   発行者名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SalesInputName
        {
            get { return _salesInputName; }
            set { _salesInputName = value; }
        }

        /// public propaty name  :  SalesCode
        /// <summary>販売区分コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   販売区分コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SalesCode
        {
            get { return _salesCode; }
            set { _salesCode = value; }
        }

        /// public propaty name  :  SalesCodeName
        /// <summary>販売区分名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   販売区分名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SalesCodeName
        {
            get { return _salesCodeName; }
            set { _salesCodeName = value; }
        }

        /// public propaty name  :  EnterpriseGanreCode
        /// <summary>商品区分コードプロパティ</summary>
        /// <value>自社分類コード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品区分コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 EnterpriseGanreCode
        {
            get { return _enterpriseGanreCode; }
            set { _enterpriseGanreCode = value; }
        }

        /// public propaty name  :  EnterpriseGanreCodeName
        /// <summary>商品区分名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品区分名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EnterpriseGanreCodeName
        {
            get { return _enterpriseGanreCodeName; }
            set { _enterpriseGanreCodeName = value; }
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

        /// public propaty name  :  BusinessTypeCode
        /// <summary>業種コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   業種コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BusinessTypeCode
        {
            get { return _businessTypeCode; }
            set { _businessTypeCode = value; }
        }

        /// public propaty name  :  BusinessTypeCodeName
        /// <summary>業種名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   業種名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string BusinessTypeCodeName
        {
            get { return _businessTypeCodeName; }
            set { _businessTypeCodeName = value; }
        }

        /// public propaty name  :  SalesAreaCode
        /// <summary>販売エリアコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   販売エリアコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SalesAreaCode
        {
            get { return _salesAreaCode; }
            set { _salesAreaCode = value; }
        }

        /// public propaty name  :  SalesAreaCodeName
        /// <summary>販売エリア名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   販売エリア名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SalesAreaCodeName
        {
            get { return _salesAreaCodeName; }
            set { _salesAreaCodeName = value; }
        }

        /// public propaty name  :  SalesTargetMoney1
        /// <summary>売上目標金額１プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上目標金額１プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesTargetMoney1
        {
            get { return _salesTargetMoney1; }
            set { _salesTargetMoney1 = value; }
        }

        /// public propaty name  :  SalesTargetMoney2
        /// <summary>売上目標金額２プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上目標金額２プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesTargetMoney2
        {
            get { return _salesTargetMoney2; }
            set { _salesTargetMoney2 = value; }
        }

        /// public propaty name  :  SalesTargetMoney3
        /// <summary>売上目標金額３プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上目標金額３プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesTargetMoney3
        {
            get { return _salesTargetMoney3; }
            set { _salesTargetMoney3 = value; }
        }

        /// public propaty name  :  SalesTargetMoney4
        /// <summary>売上目標金額４プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上目標金額４プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesTargetMoney4
        {
            get { return _salesTargetMoney4; }
            set { _salesTargetMoney4 = value; }
        }

        /// public propaty name  :  SalesTargetMoney5
        /// <summary>売上目標金額５プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上目標金額５プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesTargetMoney5
        {
            get { return _salesTargetMoney5; }
            set { _salesTargetMoney5 = value; }
        }

        /// public propaty name  :  SalesTargetMoney6
        /// <summary>売上目標金額６プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上目標金額６プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesTargetMoney6
        {
            get { return _salesTargetMoney6; }
            set { _salesTargetMoney6 = value; }
        }

        /// public propaty name  :  SalesTargetMoney7
        /// <summary>売上目標金額７プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上目標金額７プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesTargetMoney7
        {
            get { return _salesTargetMoney7; }
            set { _salesTargetMoney7 = value; }
        }

        /// public propaty name  :  SalesTargetMoney8
        /// <summary>売上目標金額８プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上目標金額８プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesTargetMoney8
        {
            get { return _salesTargetMoney8; }
            set { _salesTargetMoney8 = value; }
        }

        /// public propaty name  :  SalesTargetMoney9
        /// <summary>売上目標金額９プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上目標金額９プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesTargetMoney9
        {
            get { return _salesTargetMoney9; }
            set { _salesTargetMoney9 = value; }
        }

        /// public propaty name  :  SalesTargetMoney10
        /// <summary>売上目標金額１０プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上目標金額１０プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesTargetMoney10
        {
            get { return _salesTargetMoney10; }
            set { _salesTargetMoney10 = value; }
        }

        /// public propaty name  :  SalesTargetMoney11
        /// <summary>売上目標金額１１プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上目標金額１１プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesTargetMoney11
        {
            get { return _salesTargetMoney11; }
            set { _salesTargetMoney11 = value; }
        }

        /// public propaty name  :  SalesTargetMoney12
        /// <summary>売上目標金額１２プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上目標金額１２プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesTargetMoney12
        {
            get { return _salesTargetMoney12; }
            set { _salesTargetMoney12 = value; }
        }

        /// public propaty name  :  SalesTargetProfit1
        /// <summary>売上目標粗利額１プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上目標粗利額１プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesTargetProfit1
        {
            get { return _salesTargetProfit1; }
            set { _salesTargetProfit1 = value; }
        }

        /// public propaty name  :  SalesTargetProfit2
        /// <summary>売上目標粗利額２プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上目標粗利額２プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesTargetProfit2
        {
            get { return _salesTargetProfit2; }
            set { _salesTargetProfit2 = value; }
        }

        /// public propaty name  :  SalesTargetProfit3
        /// <summary>売上目標粗利額３プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上目標粗利額３プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesTargetProfit3
        {
            get { return _salesTargetProfit3; }
            set { _salesTargetProfit3 = value; }
        }

        /// public propaty name  :  SalesTargetProfit4
        /// <summary>売上目標粗利額４プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上目標粗利額４プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesTargetProfit4
        {
            get { return _salesTargetProfit4; }
            set { _salesTargetProfit4 = value; }
        }

        /// public propaty name  :  SalesTargetProfit5
        /// <summary>売上目標粗利額５プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上目標粗利額５プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesTargetProfit5
        {
            get { return _salesTargetProfit5; }
            set { _salesTargetProfit5 = value; }
        }

        /// public propaty name  :  SalesTargetProfit6
        /// <summary>売上目標粗利額６プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上目標粗利額６プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesTargetProfit6
        {
            get { return _salesTargetProfit6; }
            set { _salesTargetProfit6 = value; }
        }

        /// public propaty name  :  SalesTargetProfit7
        /// <summary>売上目標粗利額７プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上目標粗利額７プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesTargetProfit7
        {
            get { return _salesTargetProfit7; }
            set { _salesTargetProfit7 = value; }
        }

        /// public propaty name  :  SalesTargetProfit8
        /// <summary>売上目標粗利額８プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上目標粗利額８プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesTargetProfit8
        {
            get { return _salesTargetProfit8; }
            set { _salesTargetProfit8 = value; }
        }

        /// public propaty name  :  SalesTargetProfit9
        /// <summary>売上目標粗利額９プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上目標粗利額９プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesTargetProfit9
        {
            get { return _salesTargetProfit9; }
            set { _salesTargetProfit9 = value; }
        }

        /// public propaty name  :  SalesTargetProfit10
        /// <summary>売上目標粗利額１０プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上目標粗利額１０プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesTargetProfit10
        {
            get { return _salesTargetProfit10; }
            set { _salesTargetProfit10 = value; }
        }

        /// public propaty name  :  SalesTargetProfit11
        /// <summary>売上目標粗利額１１プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上目標粗利額１１プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesTargetProfit11
        {
            get { return _salesTargetProfit11; }
            set { _salesTargetProfit11 = value; }
        }

        /// public propaty name  :  SalesTargetProfit12
        /// <summary>売上目標粗利額１２プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上目標粗利額１２プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesTargetProfit12
        {
            get { return _salesTargetProfit12; }
            set { _salesTargetProfit12 = value; }
        }


        /// <summary>
        /// 売上目標設定印刷抽出結果クラスワークコンストラクタ
        /// </summary>
        /// <returns>SalTrgtPrintResultWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SalTrgtPrintResultWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SalTrgtPrintResultWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>SalTrgtPrintResultWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   SalTrgtPrintResultWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class SalTrgtPrintResultWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   SalTrgtPrintResultWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  SalTrgtPrintResultWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is SalTrgtPrintResultWork || graph is ArrayList || graph is SalTrgtPrintResultWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(SalTrgtPrintResultWork).FullName));

            if (graph != null && graph is SalTrgtPrintResultWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.SalTrgtPrintResultWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is SalTrgtPrintResultWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((SalTrgtPrintResultWork[])graph).Length;
            }
            else if (graph is SalTrgtPrintResultWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //更新日時
            serInfo.MemberInfo.Add(typeof(Int64)); //UpdateDateTime
            //拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //SectionCode
            //拠点ガイド略称
            serInfo.MemberInfo.Add(typeof(string)); //SectionGuideSnm
            //部門コード
            serInfo.MemberInfo.Add(typeof(Int32)); //SubSectionCode
            //部門名称
            serInfo.MemberInfo.Add(typeof(string)); //SubSectionName
            //担当者コード
            serInfo.MemberInfo.Add(typeof(string)); //SalesEmployeeCd
            //担当者名称
            serInfo.MemberInfo.Add(typeof(string)); //SalesEmployeeNm
            //受注者コード
            serInfo.MemberInfo.Add(typeof(string)); //FrontEmployeeCd
            //受注者名称
            serInfo.MemberInfo.Add(typeof(string)); //FrontEmployeeNm
            //発行者コード
            serInfo.MemberInfo.Add(typeof(string)); //SalesInputCode
            //発行者名称
            serInfo.MemberInfo.Add(typeof(string)); //SalesInputName
            //販売区分コード
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesCode
            //販売区分名称
            serInfo.MemberInfo.Add(typeof(string)); //SalesCodeName
            //商品区分コード
            serInfo.MemberInfo.Add(typeof(Int32)); //EnterpriseGanreCode
            //商品区分名称
            serInfo.MemberInfo.Add(typeof(string)); //EnterpriseGanreCodeName
            //得意先コード
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerCode
            //得意先略称
            serInfo.MemberInfo.Add(typeof(string)); //CustomerSnm
            //業種コード
            serInfo.MemberInfo.Add(typeof(Int32)); //BusinessTypeCode
            //業種名称
            serInfo.MemberInfo.Add(typeof(string)); //BusinessTypeCodeName
            //販売エリアコード
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesAreaCode
            //販売エリア名称
            serInfo.MemberInfo.Add(typeof(string)); //SalesAreaCodeName
            //売上目標金額１
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTargetMoney1
            //売上目標金額２
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTargetMoney2
            //売上目標金額３
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTargetMoney3
            //売上目標金額４
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTargetMoney4
            //売上目標金額５
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTargetMoney5
            //売上目標金額６
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTargetMoney6
            //売上目標金額７
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTargetMoney7
            //売上目標金額８
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTargetMoney8
            //売上目標金額９
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTargetMoney9
            //売上目標金額１０
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTargetMoney10
            //売上目標金額１１
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTargetMoney11
            //売上目標金額１２
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTargetMoney12
            //売上目標粗利額１
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTargetProfit1
            //売上目標粗利額２
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTargetProfit2
            //売上目標粗利額３
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTargetProfit3
            //売上目標粗利額４
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTargetProfit4
            //売上目標粗利額５
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTargetProfit5
            //売上目標粗利額６
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTargetProfit6
            //売上目標粗利額７
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTargetProfit7
            //売上目標粗利額８
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTargetProfit8
            //売上目標粗利額９
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTargetProfit9
            //売上目標粗利額１０
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTargetProfit10
            //売上目標粗利額１１
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTargetProfit11
            //売上目標粗利額１２
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTargetProfit12


            serInfo.Serialize(writer, serInfo);
            if (graph is SalTrgtPrintResultWork)
            {
                SalTrgtPrintResultWork temp = (SalTrgtPrintResultWork)graph;

                SetSalTrgtPrintResultWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is SalTrgtPrintResultWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((SalTrgtPrintResultWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (SalTrgtPrintResultWork temp in lst)
                {
                    SetSalTrgtPrintResultWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// SalTrgtPrintResultWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 45;

        /// <summary>
        ///  SalTrgtPrintResultWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   SalTrgtPrintResultWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetSalTrgtPrintResultWork(System.IO.BinaryWriter writer, SalTrgtPrintResultWork temp)
        {
            //更新日時
            writer.Write((Int64)temp.UpdateDateTime.Ticks);
            //拠点コード
            writer.Write(temp.SectionCode);
            //拠点ガイド略称
            writer.Write(temp.SectionGuideSnm);
            //部門コード
            writer.Write(temp.SubSectionCode);
            //部門名称
            writer.Write(temp.SubSectionName);
            //担当者コード
            writer.Write(temp.SalesEmployeeCd);
            //担当者名称
            writer.Write(temp.SalesEmployeeNm);
            //受注者コード
            writer.Write(temp.FrontEmployeeCd);
            //受注者名称
            writer.Write(temp.FrontEmployeeNm);
            //発行者コード
            writer.Write(temp.SalesInputCode);
            //発行者名称
            writer.Write(temp.SalesInputName);
            //販売区分コード
            writer.Write(temp.SalesCode);
            //販売区分名称
            writer.Write(temp.SalesCodeName);
            //商品区分コード
            writer.Write(temp.EnterpriseGanreCode);
            //商品区分名称
            writer.Write(temp.EnterpriseGanreCodeName);
            //得意先コード
            writer.Write(temp.CustomerCode);
            //得意先略称
            writer.Write(temp.CustomerSnm);
            //業種コード
            writer.Write(temp.BusinessTypeCode);
            //業種名称
            writer.Write(temp.BusinessTypeCodeName);
            //販売エリアコード
            writer.Write(temp.SalesAreaCode);
            //販売エリア名称
            writer.Write(temp.SalesAreaCodeName);
            //売上目標金額１
            writer.Write(temp.SalesTargetMoney1);
            //売上目標金額２
            writer.Write(temp.SalesTargetMoney2);
            //売上目標金額３
            writer.Write(temp.SalesTargetMoney3);
            //売上目標金額４
            writer.Write(temp.SalesTargetMoney4);
            //売上目標金額５
            writer.Write(temp.SalesTargetMoney5);
            //売上目標金額６
            writer.Write(temp.SalesTargetMoney6);
            //売上目標金額７
            writer.Write(temp.SalesTargetMoney7);
            //売上目標金額８
            writer.Write(temp.SalesTargetMoney8);
            //売上目標金額９
            writer.Write(temp.SalesTargetMoney9);
            //売上目標金額１０
            writer.Write(temp.SalesTargetMoney10);
            //売上目標金額１１
            writer.Write(temp.SalesTargetMoney11);
            //売上目標金額１２
            writer.Write(temp.SalesTargetMoney12);
            //売上目標粗利額１
            writer.Write(temp.SalesTargetProfit1);
            //売上目標粗利額２
            writer.Write(temp.SalesTargetProfit2);
            //売上目標粗利額３
            writer.Write(temp.SalesTargetProfit3);
            //売上目標粗利額４
            writer.Write(temp.SalesTargetProfit4);
            //売上目標粗利額５
            writer.Write(temp.SalesTargetProfit5);
            //売上目標粗利額６
            writer.Write(temp.SalesTargetProfit6);
            //売上目標粗利額７
            writer.Write(temp.SalesTargetProfit7);
            //売上目標粗利額８
            writer.Write(temp.SalesTargetProfit8);
            //売上目標粗利額９
            writer.Write(temp.SalesTargetProfit9);
            //売上目標粗利額１０
            writer.Write(temp.SalesTargetProfit10);
            //売上目標粗利額１１
            writer.Write(temp.SalesTargetProfit11);
            //売上目標粗利額１２
            writer.Write(temp.SalesTargetProfit12);

        }

        /// <summary>
        ///  SalTrgtPrintResultWorkインスタンス取得
        /// </summary>
        /// <returns>SalTrgtPrintResultWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SalTrgtPrintResultWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private SalTrgtPrintResultWork GetSalTrgtPrintResultWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            SalTrgtPrintResultWork temp = new SalTrgtPrintResultWork();

            //更新日時
            temp.UpdateDateTime = new DateTime(reader.ReadInt64());
            //拠点コード
            temp.SectionCode = reader.ReadString();
            //拠点ガイド略称
            temp.SectionGuideSnm = reader.ReadString();
            //部門コード
            temp.SubSectionCode = reader.ReadInt32();
            //部門名称
            temp.SubSectionName = reader.ReadString();
            //担当者コード
            temp.SalesEmployeeCd = reader.ReadString();
            //担当者名称
            temp.SalesEmployeeNm = reader.ReadString();
            //受注者コード
            temp.FrontEmployeeCd = reader.ReadString();
            //受注者名称
            temp.FrontEmployeeNm = reader.ReadString();
            //発行者コード
            temp.SalesInputCode = reader.ReadString();
            //発行者名称
            temp.SalesInputName = reader.ReadString();
            //販売区分コード
            temp.SalesCode = reader.ReadInt32();
            //販売区分名称
            temp.SalesCodeName = reader.ReadString();
            //商品区分コード
            temp.EnterpriseGanreCode = reader.ReadInt32();
            //商品区分名称
            temp.EnterpriseGanreCodeName = reader.ReadString();
            //得意先コード
            temp.CustomerCode = reader.ReadInt32();
            //得意先略称
            temp.CustomerSnm = reader.ReadString();
            //業種コード
            temp.BusinessTypeCode = reader.ReadInt32();
            //業種名称
            temp.BusinessTypeCodeName = reader.ReadString();
            //販売エリアコード
            temp.SalesAreaCode = reader.ReadInt32();
            //販売エリア名称
            temp.SalesAreaCodeName = reader.ReadString();
            //売上目標金額１
            temp.SalesTargetMoney1 = reader.ReadInt64();
            //売上目標金額２
            temp.SalesTargetMoney2 = reader.ReadInt64();
            //売上目標金額３
            temp.SalesTargetMoney3 = reader.ReadInt64();
            //売上目標金額４
            temp.SalesTargetMoney4 = reader.ReadInt64();
            //売上目標金額５
            temp.SalesTargetMoney5 = reader.ReadInt64();
            //売上目標金額６
            temp.SalesTargetMoney6 = reader.ReadInt64();
            //売上目標金額７
            temp.SalesTargetMoney7 = reader.ReadInt64();
            //売上目標金額８
            temp.SalesTargetMoney8 = reader.ReadInt64();
            //売上目標金額９
            temp.SalesTargetMoney9 = reader.ReadInt64();
            //売上目標金額１０
            temp.SalesTargetMoney10 = reader.ReadInt64();
            //売上目標金額１１
            temp.SalesTargetMoney11 = reader.ReadInt64();
            //売上目標金額１２
            temp.SalesTargetMoney12 = reader.ReadInt64();
            //売上目標粗利額１
            temp.SalesTargetProfit1 = reader.ReadInt64();
            //売上目標粗利額２
            temp.SalesTargetProfit2 = reader.ReadInt64();
            //売上目標粗利額３
            temp.SalesTargetProfit3 = reader.ReadInt64();
            //売上目標粗利額４
            temp.SalesTargetProfit4 = reader.ReadInt64();
            //売上目標粗利額５
            temp.SalesTargetProfit5 = reader.ReadInt64();
            //売上目標粗利額６
            temp.SalesTargetProfit6 = reader.ReadInt64();
            //売上目標粗利額７
            temp.SalesTargetProfit7 = reader.ReadInt64();
            //売上目標粗利額８
            temp.SalesTargetProfit8 = reader.ReadInt64();
            //売上目標粗利額９
            temp.SalesTargetProfit9 = reader.ReadInt64();
            //売上目標粗利額１０
            temp.SalesTargetProfit10 = reader.ReadInt64();
            //売上目標粗利額１１
            temp.SalesTargetProfit11 = reader.ReadInt64();
            //売上目標粗利額１２
            temp.SalesTargetProfit12 = reader.ReadInt64();


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
        /// <returns>SalTrgtPrintResultWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SalTrgtPrintResultWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                SalTrgtPrintResultWork temp = GetSalTrgtPrintResultWork(reader, serInfo);
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
                    retValue = (SalTrgtPrintResultWork[])lst.ToArray(typeof(SalTrgtPrintResultWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}
