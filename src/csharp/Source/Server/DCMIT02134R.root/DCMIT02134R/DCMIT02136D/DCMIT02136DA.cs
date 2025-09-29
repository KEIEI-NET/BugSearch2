using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   StockMonthYearReportParamWork
    /// <summary>
    ///                      仕入月報年報抽出条件クラスワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   仕入月報年報抽出条件クラスワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2007/11/28  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class StockMonthYearReportParamWork
    {
        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>拠点コード</summary>
        /// <remarks>文字型　※配列項目　※部署管理区分が[0:拠点]の時に使用</remarks>
        private string[] _sectionCodes;

        /// <summary>部署管理区分</summary>
        /// <remarks>0:拠点　1:拠点＋部　2:拠点＋部＋課</remarks>
        private Int32 _sectionDiv;

        /// <summary>拠点コード(開始)</summary>
        /// <remarks>※部署管理区分が[1 または 2]の時に使用</remarks>
        private string _sectionCodeSt = "";

        /// <summary>拠点コード(終了)</summary>
        /// <remarks>※部署管理区分が[1 または 2]の時に使用</remarks>
        private string _sectionCodeEd = "";

        /// <summary>部門コード(開始)</summary>
        /// <remarks>※部署管理区分が[1 または 2]の時に使用</remarks>
        private Int32 _subSectionCodeSt;

        /// <summary>部門コード(終了)</summary>
        /// <remarks>※部署管理区分が[1 または 2]の時に使用</remarks>
        private Int32 _subSectionCodeEd;

        /// <summary>課コード(開始)</summary>
        /// <remarks>※部署管理区分が[1 または 2]の時に使用</remarks>
        private Int32 _minSectionCodeSt;

        /// <summary>課コード(終了)</summary>
        /// <remarks>※部署管理区分が[1 または 2]の時に使用</remarks>
        private Int32 _minSectionCodeEd;

        /// <summary>集計方法</summary>
        /// <remarks>0:全社 1:営業所毎</remarks>
        private Int32 _ttlType;

        /// <summary>仕入年月(開始)</summary>
        /// <remarks>YYYYMM</remarks>
        private DateTime _stockDateYmSt;

        /// <summary>仕入年月(終了)</summary>
        /// <remarks>YYYYMM</remarks>
        private DateTime _stockDateYmEd;

        /// <summary>仕入期年月(開始)</summary>
        /// <remarks>YYYYMM</remarks>
        private DateTime _annualStockDateYmSt;

        /// <summary>仕入期年月(終了)</summary>
        /// <remarks>YYYYMM</remarks>
        private DateTime _annualStockDateYmEd;

        /// <summary>仕入先コード(開始)</summary>
        /// <remarks>※仕入先として使用</remarks>
        private Int32 _supplierCdSt;

        /// <summary>仕入先コード(終了)</summary>
        /// <remarks>※仕入先として使用</remarks>
        private Int32 _supplierCdEd;

        /// <summary>担当者コード(開始)</summary>
        /// <remarks>未入力時は空文字("")</remarks>
        private string _employeeCodeSt = "";

        /// <summary>担当者コード(終了)</summary>
        /// <remarks>未入力時は空文字("")</remarks>
        private string _employeeCodeEd = "";

        /// <summary>メーカーコード(開始)</summary>
        private Int32 _goodsMakerCdSt;

        /// <summary>メーカーコード(終了)</summary>
        private Int32 _goodsMakerCdEd;

        /// <summary>集計単位</summary>
        /// <remarks>0:拠点別 1:仕入先別 2:担当者別 3:部署別 4:メーカー別 5:仕入先別メーカー別</remarks>
        private Int32 _totalType;

        /// <summary>印刷タイプ</summary>
        /// <remarks>0:当月 1:当期 2:当月＆当期</remarks>
        private Int32 _printType;


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

        /// public propaty name  :  SectionCodes
        /// <summary>拠点コードプロパティ</summary>
        /// <value>文字型　※配列項目　※部署管理区分が[0:拠点]の時に使用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string[] SectionCodes
        {
            get { return _sectionCodes; }
            set { _sectionCodes = value; }
        }

        /// public propaty name  :  SectionDiv
        /// <summary>部署管理区分プロパティ</summary>
        /// <value>0:拠点 1:部署</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   部署管理区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SectionDiv
        {
            get { return _sectionDiv; }
            set { _sectionDiv = value; }
        }

        /// public propaty name  :  SectionCodeSt
        /// <summary>拠点コード(開始)プロパティ</summary>
        /// <value>※部署管理区分が[1:部署]の時に使用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点コード(開始)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SectionCodeSt
        {
            get { return _sectionCodeSt; }
            set { _sectionCodeSt = value; }
        }

        /// public propaty name  :  SectionCodeEd
        /// <summary>拠点コード(終了)プロパティ</summary>
        /// <value>※部署管理区分が[1:部署]の時に使用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点コード(終了)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SectionCodeEd
        {
            get { return _sectionCodeEd; }
            set { _sectionCodeEd = value; }
        }

        /// public propaty name  :  SubSectionCodeSt
        /// <summary>部門コード(開始)プロパティ</summary>
        /// <value>※部署管理区分が[1:部署]の時に使用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   部門コード(開始)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SubSectionCodeSt
        {
            get { return _subSectionCodeSt; }
            set { _subSectionCodeSt = value; }
        }

        /// public propaty name  :  SubSectionCodeEd
        /// <summary>部門コード(終了)プロパティ</summary>
        /// <value>※部署管理区分が[1:部署]の時に使用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   部門コード(終了)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SubSectionCodeEd
        {
            get { return _subSectionCodeEd; }
            set { _subSectionCodeEd = value; }
        }

        /// public propaty name  :  MinSectionCodeSt
        /// <summary>課コード(開始)プロパティ</summary>
        /// <value>※部署管理区分が[1:部署]の時に使用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   課コード(開始)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 MinSectionCodeSt
        {
            get { return _minSectionCodeSt; }
            set { _minSectionCodeSt = value; }
        }

        /// public propaty name  :  MinSectionCodeEd
        /// <summary>課コード(終了)プロパティ</summary>
        /// <value>※部署管理区分が[1:部署]の時に使用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   課コード(終了)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 MinSectionCodeEd
        {
            get { return _minSectionCodeEd; }
            set { _minSectionCodeEd = value; }
        }

        /// public propaty name  :  TtlType
        /// <summary>集計方法プロパティ</summary>
        /// <value>0:全社 1:営業所毎</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   集計方法プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 TtlType
        {
            get { return _ttlType; }
            set { _ttlType = value; }
        }

        /// public propaty name  :  StockDateYmSt
        /// <summary>仕入年月(開始)プロパティ</summary>
        /// <value>YYYYMM</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入年月(開始)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime StockDateYmSt
        {
            get { return _stockDateYmSt; }
            set { _stockDateYmSt = value; }
        }

        /// public propaty name  :  StockDateYmEd
        /// <summary>仕入年月(終了)プロパティ</summary>
        /// <value>YYYYMM</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入年月(終了)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime StockDateYmEd
        {
            get { return _stockDateYmEd; }
            set { _stockDateYmEd = value; }
        }

        /// public propaty name  :  AnnualStockDateYmSt
        /// <summary>仕入期年月(開始)プロパティ</summary>
        /// <value>YYYYMM</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入期年月(開始)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime AnnualStockDateYmSt
        {
            get { return _annualStockDateYmSt; }
            set { _annualStockDateYmSt = value; }
        }

        /// public propaty name  :  AnnualStockDateYmEd
        /// <summary>仕入期年月(終了)プロパティ</summary>
        /// <value>YYYYMM</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入期年月(終了)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime AnnualStockDateYmEd
        {
            get { return _annualStockDateYmEd; }
            set { _annualStockDateYmEd = value; }
        }

        /// public propaty name  :  SupplierCdSt
        /// <summary>仕入先コード(開始)プロパティ</summary>
        /// <value>※仕入先として使用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先コード(開始)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SupplierCdSt
        {
            get { return _supplierCdSt; }
            set { _supplierCdSt = value; }
        }

        /// public propaty name  :  SupplierCdEd
        /// <summary>仕入先コード(終了)プロパティ</summary>
        /// <value>※仕入先として使用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先コード(終了)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SupplierCdEd
        {
            get { return _supplierCdEd; }
            set { _supplierCdEd = value; }
        }

        /// public propaty name  :  EmployeeCodeSt
        /// <summary>担当者コード(開始)プロパティ</summary>
        /// <value>未入力時は空文字("")</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   担当者コード(開始)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EmployeeCodeSt
        {
            get { return _employeeCodeSt; }
            set { _employeeCodeSt = value; }
        }

        /// public propaty name  :  EmployeeCodeEd
        /// <summary>担当者コード(終了)プロパティ</summary>
        /// <value>未入力時は空文字("")</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   担当者コード(終了)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EmployeeCodeEd
        {
            get { return _employeeCodeEd; }
            set { _employeeCodeEd = value; }
        }

        /// public propaty name  :  GoodsMakerCdSt
        /// <summary>メーカーコード(開始)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メーカーコード(開始)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsMakerCdSt
        {
            get { return _goodsMakerCdSt; }
            set { _goodsMakerCdSt = value; }
        }

        /// public propaty name  :  GoodsMakerCdEd
        /// <summary>メーカーコード(終了)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メーカーコード(終了)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsMakerCdEd
        {
            get { return _goodsMakerCdEd; }
            set { _goodsMakerCdEd = value; }
        }

        /// public propaty name  :  TotalType
        /// <summary>集計単位プロパティ</summary>
        /// <value>0:拠点別 1:仕入先別 2:担当者別 3:部署別 4:メーカー別 5:仕入先別メーカー別</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   集計単位プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 TotalType
        {
            get { return _totalType; }
            set { _totalType = value; }
        }

        /// public propaty name  :  PrintType
        /// <summary>印刷タイププロパティ</summary>
        /// <value>0:当月 1:当期 2:当月＆当期</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   印刷タイププロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PrintType
        {
            get { return _printType; }
            set { _printType = value; }
        }


        /// <summary>
        /// 仕入月報年報抽出条件クラスワークコンストラクタ
        /// </summary>
        /// <returns>StockMonthYearReportParamWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockMonthYearReportParamWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public StockMonthYearReportParamWork()
        {
        }

    }
}
