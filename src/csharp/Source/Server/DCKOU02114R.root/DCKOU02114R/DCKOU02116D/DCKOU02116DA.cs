using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   StockDayMonthReportWork
	/// <summary>
	///                      仕入日報月報抽出条件ワークワーク
	/// </summary>
	/// <remarks>
	/// <br>note             :   仕入日報月報抽出条件ワークワークヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2008/08/12  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class StockDayMonthReportWork
	{
		/// <summary>企業コード</summary>
		/// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
		private string _enterpriseCode = "";

		/// <summary>拠点コード</summary>
		/// <remarks>(配列)　全社指定は{""}</remarks>
		private string[] _depositStockSecCodeList;

		/// <summary>仕入先コード(開始)</summary>
		private Int32 _supplierCdSt;

		/// <summary>仕入先コード(終了)</summary>
		private Int32 _supplierCdEd;

		/// <summary>開始仕入日(日計)</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _dayStockDateSt;

		/// <summary>終了仕入日(日計)</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _dayStockDateEd;

		/// <summary>開始仕入日(累計)</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _monthStockDateSt;

		/// <summary>終了仕入日(累計)</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _monthStockDateEd;


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
			get{return _enterpriseCode;}
			set{_enterpriseCode = value;}
		}

		/// public propaty name  :  DepositStockSecCodeList
		/// <summary>拠点コードプロパティ</summary>
		/// <value>(配列)　全社指定は{""}</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   拠点コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string[] DepositStockSecCodeList
		{
			get{return _depositStockSecCodeList;}
			set{_depositStockSecCodeList = value;}
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
			get{return _supplierCdSt;}
			set{_supplierCdSt = value;}
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
			get{return _supplierCdEd;}
			set{_supplierCdEd = value;}
		}

		/// public propaty name  :  DayStockDateSt
		/// <summary>開始仕入日(日計)プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始仕入日(日計)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime DayStockDateSt
		{
			get{return _dayStockDateSt;}
			set{_dayStockDateSt = value;}
		}

		/// public propaty name  :  DayStockDateEd
		/// <summary>終了仕入日(日計)プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了仕入日(日計)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime DayStockDateEd
		{
			get{return _dayStockDateEd;}
			set{_dayStockDateEd = value;}
		}

		/// public propaty name  :  MonthStockDateSt
		/// <summary>開始仕入日(累計)プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始仕入日(累計)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime MonthStockDateSt
		{
			get{return _monthStockDateSt;}
			set{_monthStockDateSt = value;}
		}

		/// public propaty name  :  MonthStockDateEd
		/// <summary>終了仕入日(累計)プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了仕入日(累計)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime MonthStockDateEd
		{
			get{return _monthStockDateEd;}
			set{_monthStockDateEd = value;}
		}


		/// <summary>
		/// 仕入日報月報抽出条件ワークワークコンストラクタ
		/// </summary>
		/// <returns>StockDayMonthReportWorkクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   StockDayMonthReportWorkクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public StockDayMonthReportWork()
		{
		}

	}
}
