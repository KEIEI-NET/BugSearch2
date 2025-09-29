using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
	/// public class name:   SalStcCompMonthYearReport
	/// <summary>
	///                      売上仕入対比表(月報年報)抽出条件クラス
	/// </summary>
	/// <remarks>
	/// <br>note             :   売上仕入対比表(月報年報)抽出条件クラスヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2008/02/22  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2008/12/08 30452 上野 俊治</br>
    /// <br>                  ・PM.NS対応</br>
	/// </remarks>
    public class SalStcCompMonthYearReport
    {
        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>拠点コード</summary>
        /// <remarks>文字型　※配列項目</remarks>
        private string[] _sectionCodes;

        /// <summary>売上日付(開始)</summary>
        /// <remarks>YYYYMM</remarks>
        //private DateTime _salesDateSt; // DEL 2008/12/08
        private Int32 _salesDateSt; // ADD 2008/12/08

        /// <summary>売上日付(終了)</summary>
        /// <remarks>YYYYMM</remarks>
        //private DateTime _salesDateEd; // DEL 2008/12/08
        private Int32 _salesDateEd; // ADD 2008/12/08

        /// <summary>売上累計日付(開始)</summary>
        /// <remarks>YYYYMM</remarks>
        //private DateTime _monthReportDateSt; // DEL 2008/12/08
        private Int32 _monthReportDateSt; // ADD 2008/12/08

        /// <summary>売上累計日付(終了)</summary>
        /// <remarks>YYYYMM</remarks>
        //private DateTime _monthReportDateEd; // DEL 2008/12/08
        private Int32 _monthReportDateEd; // ADD 2008/12/08

        /// <summary>仕入先コード(開始)</summary>
        private Int32 _supplierCdSt;

        /// <summary>仕入先コード(終了)</summary>
        private Int32 _supplierCdEd;

        /// <summary>発行タイプ</summary>
        /// <remarks>0:拠点別 1:仕入先別</remarks>
        private Int32 _printType;

        /// <summary>改頁</summary>
        /// <remarks>0:なし 1:あり</remarks>
        private Int32 _crMode;

        /// <summary>金額単位</summary>
        /// <remarks>0:一円単位 1:千円単位</remarks>
        private Int32 _moneyUnit;

        // --- DEL 2008/12/08 -------------------------------->>>>>
        ///// <summary>印字用売上日付(開始)</summary>
        ///// <remarks>YYYYMMDD</remarks>
        //private DateTime _salesDatePrnSt;

        ///// <summary>印字用売上日付(終了)</summary>
        ///// <remarks>YYYYMMDD</remarks>
        //private DateTime _salesDatePrnEd;
        // --- DEL 2008/12/08 --------------------------------<<<<<

        /// <summary>企業名称</summary>
        private string _enterpriseName = "";


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
        /// <value>文字型　※配列項目</value>
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

        /// public propaty name  :  SalesDateSt
        /// <summary>売上日付(開始)プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上日付(開始)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        //public DateTime SalesDateSt // DEL 2008/12/08
        public Int32 SalesDateSt // ADD 2008/12/08
        {
            get { return _salesDateSt; }
            set { _salesDateSt = value; }
        }

        /// public propaty name  :  SalesDateEd
        /// <summary>売上日付(終了)プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上日付(終了)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        //public DateTime SalesDateEd // DEL 2008/12/08
        public Int32 SalesDateEd // ADD 2008/12/08
        {
            get { return _salesDateEd; }
            set { _salesDateEd = value; }
        }

        /// public propaty name  :  MonthReportDateSt
        /// <summary>売上累計日付(開始)プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上累計日付(開始)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        //public DateTime MonthReportDateSt // DEL 2008/12/08
        public Int32 MonthReportDateSt // ADD 2008/12/08
        {
            get { return _monthReportDateSt; }
            set { _monthReportDateSt = value; }
        }

        /// public propaty name  :  MonthReportDateEd
        /// <summary>売上累計日付(終了)プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上累計日付(終了)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        //public DateTime MonthReportDateEd // DEL 2008/12/08
        public Int32 MonthReportDateEd // ADD 2008/12/08
        {
            get { return _monthReportDateEd; }
            set { _monthReportDateEd = value; }
        }

        /// public propaty name  :  SupplierCdSt
        /// <summary>仕入先コード(開始)プロパティ</summary>
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

        /// public propaty name  :  PrintType
        /// <summary>帳票種別プロパティ</summary>
        /// <value>0:営業所別 1:仕入先別</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   帳票種別プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PrintType
        {
            get { return _printType; }
            set { _printType = value; }
        }

        /// public propaty name  :  CrMode
        /// <summary>改頁プロパティ</summary>
        /// <value>0:なし 1:あり</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   改頁プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CrMode
        {
            get { return _crMode; }
            set { _crMode = value; }
        }

        /// public propaty name  :  MoneyUnit
        /// <summary>金額単位プロパティ</summary>
        /// <value>0:一円単位 1:千円単位</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   金額単位プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 MoneyUnit
        {
            get { return _moneyUnit; }
            set { _moneyUnit = value; }
        }

        // --- DEL 2008/12/08 -------------------------------->>>>>
        ///// public propaty name  :  SalesDatePrnSt
        ///// <summary>印字用売上日付(開始)プロパティ</summary>
        ///// <value>YYYYMMDD</value>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   印字用売上日付(開始)プロパティ</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public DateTime SalesDatePrnSt
        //{
        //    get { return _salesDatePrnSt; }
        //    set { _salesDatePrnSt = value; }
        //}

        ///// public propaty name  :  SalesDatePrnEd
        ///// <summary>印字用売上日付(終了)プロパティ</summary>
        ///// <value>YYYYMMDD</value>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   印字用売上日付(終了)プロパティ</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public DateTime SalesDatePrnEd
        //{
        //    get { return _salesDatePrnEd; }
        //    set { _salesDatePrnEd = value; }
        //}
        // --- DEL 2008/12/08 --------------------------------<<<<<

        /// public propaty name  :  EnterpriseName
        /// <summary>企業名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   企業名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EnterpriseName
        {
            get { return _enterpriseName; }
            set { _enterpriseName = value; }
        }


        /// <summary>
        /// 売上仕入対比表(月報年報)抽出条件クラスコンストラクタ
        /// </summary>
        /// <returns>SalStcCompMonthYearReportクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SalStcCompMonthYearReportクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SalStcCompMonthYearReport()
        {
        }

        /// <summary>
        /// 売上仕入対比表(月報年報)抽出条件クラスコンストラクタ
        /// </summary>
        /// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
        /// <param name="sectionCodes">拠点コード(文字型　※配列項目)</param>
        /// <param name="salesDateSt">売上日付(開始)(YYYYMMDD)</param>
        /// <param name="salesDateEd">売上日付(終了)(YYYYMMDD)</param>
        /// <param name="monthReportDateSt">売上累計日付(開始)(YYYYMMDD)</param>
        /// <param name="monthReportDateEd">売上累計日付(終了)(YYYYMMDD)</param>
        /// <param name="supplierCdSt">仕入先コード(開始)</param>
        /// <param name="supplierCdEd">仕入先コード(終了)</param>
        /// <param name="printType">帳票種別(0:営業所別 1:仕入先別)</param>
        /// <param name="crMode">改頁(0:なし 1:あり)</param>
        /// <param name="moneyUnit">金額単位(0:一円単位 1:千円単位)</param>
        /// <param name="salesDatePrnSt">印字用売上日付(開始)(YYYYMMDD)</param>
        /// <param name="salesDatePrnEd">印字用売上日付(終了)(YYYYMMDD)</param>
        /// <param name="enterpriseName">企業名称</param>
        /// <returns>SalStcCompMonthYearReportクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SalStcCompMonthYearReportクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        //public SalStcCompMonthYearReport(string enterpriseCode, string[] sectionCodes, Int32 salesDateSt, Int32 salesDateEd, Int32 monthReportDateSt, Int32 monthReportDateEd, Int32 supplierCdSt, Int32 supplierCdEd, Int32 printType, Int32 crMode, Int32 moneyUnit, DateTime salesDatePrnSt, DateTime salesDatePrnEd, string enterpriseName) // DEL 2008/12/08
        public SalStcCompMonthYearReport(string enterpriseCode, string[] sectionCodes, Int32 salesDateSt, Int32 salesDateEd, Int32 monthReportDateSt, Int32 monthReportDateEd, Int32 supplierCdSt, Int32 supplierCdEd, Int32 printType, Int32 crMode, Int32 moneyUnit, string enterpriseName) // ADD 2008/12/08
        {
            this._enterpriseCode = enterpriseCode;
            this._sectionCodes = sectionCodes;
            this._salesDateSt = salesDateSt;
            this._salesDateEd = salesDateEd;
            this._monthReportDateSt = monthReportDateSt;
            this._monthReportDateEd = monthReportDateEd;
            this._supplierCdSt = supplierCdSt;
            this._supplierCdEd = supplierCdEd;
            this._printType = printType;
            this._crMode = crMode;
            this._moneyUnit = moneyUnit;
            //this._salesDatePrnSt = salesDatePrnSt; // DEL 2008/12/08
            //this._salesDatePrnEd = salesDatePrnEd; // DEL 2008/12/08
            this._enterpriseName = enterpriseName;

        }

        /// <summary>
        /// 売上仕入対比表(月報年報)抽出条件クラス複製処理
        /// </summary>
        /// <returns>SalStcCompMonthYearReportクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいSalStcCompMonthYearReportクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SalStcCompMonthYearReport Clone()
        {
            //return new SalStcCompMonthYearReport(this._enterpriseCode, this._sectionCodes, this._salesDateSt, this._salesDateEd, this._monthReportDateSt, this._monthReportDateEd, this._supplierCdSt, this._supplierCdEd, this._printType, this._crMode, this._moneyUnit, this._salesDatePrnSt, this._salesDatePrnEd, this._enterpriseName); // DEL 2008/12/08
            return new SalStcCompMonthYearReport(this._enterpriseCode, this._sectionCodes, this._salesDateSt, this._salesDateEd, this._monthReportDateSt, this._monthReportDateEd, this._supplierCdSt, this._supplierCdEd, this._printType, this._crMode, this._moneyUnit, this._enterpriseName); // ADD 2008/12/08
        }

        /// <summary>
        /// 売上仕入対比表(月報年報)抽出条件クラス比較処理
        /// </summary>
        /// <param name="target">比較対象のSalStcCompMonthYearReportクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SalStcCompMonthYearReportクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool Equals(SalStcCompMonthYearReport target)
        {
            return ((this.EnterpriseCode == target.EnterpriseCode)
                 && (this.SectionCodes == target.SectionCodes)
                 && (this.SalesDateSt == target.SalesDateSt)
                 && (this.SalesDateEd == target.SalesDateEd)
                 && (this.MonthReportDateSt == target.MonthReportDateSt)
                 && (this.MonthReportDateEd == target.MonthReportDateEd)
                 && (this.SupplierCdSt == target.SupplierCdSt)
                 && (this.SupplierCdEd == target.SupplierCdEd)
                 && (this.PrintType == target.PrintType)
                 && (this.CrMode == target.CrMode)
                 && (this.MoneyUnit == target.MoneyUnit)
                //&& (this.SalesDatePrnSt == target.SalesDatePrnSt) // DEL 2008/12/08
                //&& (this.SalesDatePrnEd == target.SalesDatePrnEd) // DEL 2008/12/08
                 && (this.EnterpriseName == target.EnterpriseName));
        }

        /// <summary>
        /// 売上仕入対比表(月報年報)抽出条件クラス比較処理
        /// </summary>
        /// <param name="salStcCompMonthYearReport1">
        ///                    比較するSalStcCompMonthYearReportクラスのインスタンス
        /// </param>
        /// <param name="salStcCompMonthYearReport2">比較するSalStcCompMonthYearReportクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SalStcCompMonthYearReportクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static bool Equals(SalStcCompMonthYearReport salStcCompMonthYearReport1, SalStcCompMonthYearReport salStcCompMonthYearReport2)
        {
            return ((salStcCompMonthYearReport1.EnterpriseCode == salStcCompMonthYearReport2.EnterpriseCode)
                 && (salStcCompMonthYearReport1.SectionCodes == salStcCompMonthYearReport2.SectionCodes)
                 && (salStcCompMonthYearReport1.SalesDateSt == salStcCompMonthYearReport2.SalesDateSt)
                 && (salStcCompMonthYearReport1.SalesDateEd == salStcCompMonthYearReport2.SalesDateEd)
                 && (salStcCompMonthYearReport1.MonthReportDateSt == salStcCompMonthYearReport2.MonthReportDateSt)
                 && (salStcCompMonthYearReport1.MonthReportDateEd == salStcCompMonthYearReport2.MonthReportDateEd)
                 && (salStcCompMonthYearReport1.SupplierCdSt == salStcCompMonthYearReport2.SupplierCdSt)
                 && (salStcCompMonthYearReport1.SupplierCdEd == salStcCompMonthYearReport2.SupplierCdEd)
                 && (salStcCompMonthYearReport1.PrintType == salStcCompMonthYearReport2.PrintType)
                 && (salStcCompMonthYearReport1.CrMode == salStcCompMonthYearReport2.CrMode)
                 && (salStcCompMonthYearReport1.MoneyUnit == salStcCompMonthYearReport2.MoneyUnit)
                //&& (salStcCompMonthYearReport1.SalesDatePrnSt == salStcCompMonthYearReport2.SalesDatePrnSt) // DEL 2008/12/08
                //&& (salStcCompMonthYearReport1.SalesDatePrnEd == salStcCompMonthYearReport2.SalesDatePrnEd) // DEL 2008/12/08
                 && (salStcCompMonthYearReport1.EnterpriseName == salStcCompMonthYearReport2.EnterpriseName));
        }
        /// <summary>
        /// 売上仕入対比表(月報年報)抽出条件クラス比較処理
        /// </summary>
        /// <param name="target">比較対象のSalStcCompMonthYearReportクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SalStcCompMonthYearReportクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList Compare(SalStcCompMonthYearReport target)
        {
            ArrayList resList = new ArrayList();
            if (this.EnterpriseCode != target.EnterpriseCode) resList.Add("EnterpriseCode");
            if (this.SectionCodes != target.SectionCodes) resList.Add("SectionCodes");
            if (this.SalesDateSt != target.SalesDateSt) resList.Add("SalesDateSt");
            if (this.SalesDateEd != target.SalesDateEd) resList.Add("SalesDateEd");
            if (this.MonthReportDateSt != target.MonthReportDateSt) resList.Add("MonthReportDateSt");
            if (this.MonthReportDateEd != target.MonthReportDateEd) resList.Add("MonthReportDateEd");
            if (this.SupplierCdSt != target.SupplierCdSt) resList.Add("SupplierCdSt");
            if (this.SupplierCdEd != target.SupplierCdEd) resList.Add("SupplierCdEd");
            if (this.PrintType != target.PrintType) resList.Add("PrintType");
            if (this.CrMode != target.CrMode) resList.Add("CrMode");
            if (this.MoneyUnit != target.MoneyUnit) resList.Add("MoneyUnit");
            //if (this.SalesDatePrnSt != target.SalesDatePrnSt) resList.Add("SalesDatePrnSt"); // DEL 2008/12/08
            //if (this.SalesDatePrnEd != target.SalesDatePrnEd) resList.Add("SalesDatePrnEd"); // DEL 2008/12/08
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");

            return resList;
        }

        /// <summary>
        /// 売上仕入対比表(月報年報)抽出条件クラス比較処理
        /// </summary>
        /// <param name="salStcCompMonthYearReport1">比較するSalStcCompMonthYearReportクラスのインスタンス</param>
        /// <param name="salStcCompMonthYearReport2">比較するSalStcCompMonthYearReportクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SalStcCompMonthYearReportクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static ArrayList Compare(SalStcCompMonthYearReport salStcCompMonthYearReport1, SalStcCompMonthYearReport salStcCompMonthYearReport2)
        {
            ArrayList resList = new ArrayList();
            if (salStcCompMonthYearReport1.EnterpriseCode != salStcCompMonthYearReport2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (salStcCompMonthYearReport1.SectionCodes != salStcCompMonthYearReport2.SectionCodes) resList.Add("SectionCodes");
            if (salStcCompMonthYearReport1.SalesDateSt != salStcCompMonthYearReport2.SalesDateSt) resList.Add("SalesDateSt");
            if (salStcCompMonthYearReport1.SalesDateEd != salStcCompMonthYearReport2.SalesDateEd) resList.Add("SalesDateEd");
            if (salStcCompMonthYearReport1.MonthReportDateSt != salStcCompMonthYearReport2.MonthReportDateSt) resList.Add("MonthReportDateSt");
            if (salStcCompMonthYearReport1.MonthReportDateEd != salStcCompMonthYearReport2.MonthReportDateEd) resList.Add("MonthReportDateEd");
            if (salStcCompMonthYearReport1.SupplierCdSt != salStcCompMonthYearReport2.SupplierCdSt) resList.Add("SupplierCdSt");
            if (salStcCompMonthYearReport1.SupplierCdEd != salStcCompMonthYearReport2.SupplierCdEd) resList.Add("SupplierCdEd");
            if (salStcCompMonthYearReport1.PrintType != salStcCompMonthYearReport2.PrintType) resList.Add("PrintType");
            if (salStcCompMonthYearReport1.CrMode != salStcCompMonthYearReport2.CrMode) resList.Add("CrMode");
            if (salStcCompMonthYearReport1.MoneyUnit != salStcCompMonthYearReport2.MoneyUnit) resList.Add("MoneyUnit");
            //if (salStcCompMonthYearReport1.SalesDatePrnSt != salStcCompMonthYearReport2.SalesDatePrnSt) resList.Add("SalesDatePrnSt"); // DEL 2008/12/08
            //if (salStcCompMonthYearReport1.SalesDatePrnEd != salStcCompMonthYearReport2.SalesDatePrnEd) resList.Add("SalesDatePrnEd"); // DEL 2008/12/08
            if (salStcCompMonthYearReport1.EnterpriseName != salStcCompMonthYearReport2.EnterpriseName) resList.Add("EnterpriseName");

            return resList;
        }
    }
}
