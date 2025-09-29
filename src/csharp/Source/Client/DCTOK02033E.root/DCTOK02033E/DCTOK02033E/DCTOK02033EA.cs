using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
	/// public class name:   SalStcCompReport
	/// <summary>
	///                      売上仕入対比表抽出条件クラス
	/// </summary>
	/// <remarks>
	/// <br>note             :   売上仕入対比表抽出条件クラスヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2007/11/20  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	public class SalStcCompReport
	{
		/// <summary>企業コード</summary>
		/// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
		private string _enterpriseCode = "";

		/// <summary>拠点コード</summary>
		/// <remarks>文字型　※配列項目</remarks>
		private string[] _sectionCodes;

		/// <summary>売上日付(開始)</summary>
		/// <remarks>YYYYMMDD</remarks>
        //private DateTime _salesDateSt; // DEL 2008/12/08
        private Int32 _salesDateSt; // ADD 2008/12/08

		/// <summary>売上日付(終了)</summary>
		/// <remarks>YYYYMMDD</remarks>
        //private DateTime _salesDateEd; // DEL 2008/12/08
        private Int32 _salesDateEd; // ADD 2008/12/08

		/// <summary>売上累計日付(開始)</summary>
		/// <remarks>YYYYMMDD</remarks>
        //private DateTime _monthReportDateSt; // DEL 2008/12/08
        private Int32 _monthReportDateSt; // ADD 2008/12/08

		/// <summary>売上累計日付(終了)</summary>
		/// <remarks>YYYYMMDD</remarks>
        //private DateTime _monthReportDateEd; // DEL 2008/12/08
        private Int32 _monthReportDateEd; // ADD 2008/12/08

		/// <summary>仕入先コード(開始)</summary>
		private Int32 _supplierCdSt;

		/// <summary>仕入先コード(終了)</summary>
		private Int32 _supplierCdEd;

		/// <summary>帳票種別</summary>
		/// <remarks>0:営業所別 1:仕入先別</remarks>
		private Int32 _printType;

		/// <summary>改頁</summary>
		/// <remarks>0:なし 1:あり</remarks>
		private Int32 _crMode;

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
		/// 売上仕入対比表抽出条件クラスコンストラクタ
		/// </summary>
		/// <returns>SalStcCompReportクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SalStcCompReportクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public SalStcCompReport()
		{
		}

		/// <summary>
		/// 売上仕入対比表抽出条件クラスコンストラクタ
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
		/// <param name="enterpriseName">企業名称</param>
		/// <returns>SalStcCompReportクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SalStcCompReportクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
        //public SalStcCompReport(string enterpriseCode, string[] sectionCodes, DateTime salesDateSt, DateTime salesDateEd, DateTime monthReportDateSt, DateTime monthReportDateEd, Int32 supplierCdSt, Int32 supplierCdEd, Int32 printType, Int32 crMode, string enterpriseName) // DEL 2008/12/08
        public SalStcCompReport(string enterpriseCode, string[] sectionCodes, Int32 salesDateSt, Int32 salesDateEd, Int32 monthReportDateSt, Int32 monthReportDateEd, Int32 supplierCdSt, Int32 supplierCdEd, Int32 printType, Int32 crMode, string enterpriseName) // DEL 2008/12/08	
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
            this._enterpriseName = enterpriseName;

        }

		/// <summary>
		/// 売上仕入対比表抽出条件クラス複製処理
		/// </summary>
		/// <returns>SalStcCompReportクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   自身の内容と等しいSalStcCompReportクラスのインスタンスを返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public SalStcCompReport Clone()
		{
			return new SalStcCompReport(this._enterpriseCode, this._sectionCodes, this._salesDateSt, this._salesDateEd, this._monthReportDateSt, this._monthReportDateEd, this._supplierCdSt, this._supplierCdEd, this._printType, this._crMode, this._enterpriseName);
		}

		/// <summary>
		/// 売上仕入対比表抽出条件クラス比較処理
		/// </summary>
		/// <param name="target">比較対象のSalStcCompReportクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SalStcCompReportクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public bool Equals(SalStcCompReport target)
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
				 && (this.EnterpriseName == target.EnterpriseName));
		}

		/// <summary>
		/// 売上仕入対比表抽出条件クラス比較処理
		/// </summary>
		/// <param name="salStcCompReport1">
		///                    比較するSalStcCompReportクラスのインスタンス
		/// </param>
		/// <param name="salStcCompReport2">比較するSalStcCompReportクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SalStcCompReportクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static bool Equals(SalStcCompReport salStcCompReport1, SalStcCompReport salStcCompReport2)
		{
			return ((salStcCompReport1.EnterpriseCode == salStcCompReport2.EnterpriseCode)
				 && (salStcCompReport1.SectionCodes == salStcCompReport2.SectionCodes)
				 && (salStcCompReport1.SalesDateSt == salStcCompReport2.SalesDateSt)
				 && (salStcCompReport1.SalesDateEd == salStcCompReport2.SalesDateEd)
				 && (salStcCompReport1.MonthReportDateSt == salStcCompReport2.MonthReportDateSt)
				 && (salStcCompReport1.MonthReportDateEd == salStcCompReport2.MonthReportDateEd)
				 && (salStcCompReport1.SupplierCdSt == salStcCompReport2.SupplierCdSt)
				 && (salStcCompReport1.SupplierCdEd == salStcCompReport2.SupplierCdEd)
				 && (salStcCompReport1.PrintType == salStcCompReport2.PrintType)
				 && (salStcCompReport1.CrMode == salStcCompReport2.CrMode)
				 && (salStcCompReport1.EnterpriseName == salStcCompReport2.EnterpriseName));
		}
		/// <summary>
		/// 売上仕入対比表抽出条件クラス比較処理
		/// </summary>
		/// <param name="target">比較対象のSalStcCompReportクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SalStcCompReportクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ArrayList Compare(SalStcCompReport target)
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
			if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");

			return resList;
		}

		/// <summary>
		/// 売上仕入対比表抽出条件クラス比較処理
		/// </summary>
		/// <param name="salStcCompReport1">比較するSalStcCompReportクラスのインスタンス</param>
		/// <param name="salStcCompReport2">比較するSalStcCompReportクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SalStcCompReportクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static ArrayList Compare(SalStcCompReport salStcCompReport1, SalStcCompReport salStcCompReport2)
		{
			ArrayList resList = new ArrayList();
			if (salStcCompReport1.EnterpriseCode != salStcCompReport2.EnterpriseCode) resList.Add("EnterpriseCode");
			if (salStcCompReport1.SectionCodes != salStcCompReport2.SectionCodes) resList.Add("SectionCodes");
			if (salStcCompReport1.SalesDateSt != salStcCompReport2.SalesDateSt) resList.Add("SalesDateSt");
			if (salStcCompReport1.SalesDateEd != salStcCompReport2.SalesDateEd) resList.Add("SalesDateEd");
			if (salStcCompReport1.MonthReportDateSt != salStcCompReport2.MonthReportDateSt) resList.Add("MonthReportDateSt");
			if (salStcCompReport1.MonthReportDateEd != salStcCompReport2.MonthReportDateEd) resList.Add("MonthReportDateEd");
			if (salStcCompReport1.SupplierCdSt != salStcCompReport2.SupplierCdSt) resList.Add("SupplierCdSt");
			if (salStcCompReport1.SupplierCdEd != salStcCompReport2.SupplierCdEd) resList.Add("SupplierCdEd");
			if (salStcCompReport1.PrintType != salStcCompReport2.PrintType) resList.Add("PrintType");
			if (salStcCompReport1.CrMode != salStcCompReport2.CrMode) resList.Add("CrMode");
			if (salStcCompReport1.EnterpriseName != salStcCompReport2.EnterpriseName) resList.Add("EnterpriseName");

			return resList;
		}
	}
}
