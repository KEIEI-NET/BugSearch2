using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   SalesSlipYearContrastParamWork
	/// <summary>
	///                      売上仕入対比表(月報年報)抽出条件クラスワーク
	/// </summary>
	/// <remarks>
	/// <br>note             :   売上仕入対比表(月報年報)抽出条件クラスワークヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2008/11/18  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class SalesSlipYearContrastParamWork 
	{
		/// <summary>企業コード</summary>
		/// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
		private string _enterpriseCode = "";

		/// <summary>拠点コード</summary>
		/// <remarks>(配列)　全社指定はnull</remarks>
		private string[] _sectionCodes;

		/// <summary>開始計上年月(当月)</summary>
		/// <remarks>YYYYMM</remarks>
		private Int32 _stAddUpYearMonth;

		/// <summary>終了計上年月(当月)</summary>
		/// <remarks>YYYYMM</remarks>
		private Int32 _edAddUpYearMonth;

		/// <summary>開始計上年月(当期)</summary>
		/// <remarks>YYYYMM</remarks>
		private Int32 _stAnnualAddUpYearMonth;

		/// <summary>終了計上年月(当期)</summary>
		/// <remarks>YYYYMM</remarks>
		private Int32 _edAnnualAddUpYearMonth;

		/// <summary>開始仕入先コード</summary>
		private Int32 _stSupplierCd;

		/// <summary>終了仕入先コード</summary>
		private Int32 _edSupplierCd;


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

		/// public propaty name  :  SectionCodes
		/// <summary>拠点コードプロパティ</summary>
		/// <value>(配列)　全社指定はnull</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   拠点コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
        public string[] SectionCodes
		{
			get{return _sectionCodes;}
			set{_sectionCodes = value;}
		}

		/// public propaty name  :  StAddUpYearMonth
		/// <summary>開始計上年月(当月)プロパティ</summary>
		/// <value>YYYYMM</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始計上年月(当月)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 StAddUpYearMonth
		{
			get{return _stAddUpYearMonth;}
			set{_stAddUpYearMonth = value;}
		}

		/// public propaty name  :  EdAddUpYearMonth
		/// <summary>終了計上年月(当月)プロパティ</summary>
		/// <value>YYYYMM</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了計上年月(当月)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 EdAddUpYearMonth
		{
			get{return _edAddUpYearMonth;}
			set{_edAddUpYearMonth = value;}
		}

		/// public propaty name  :  StAnnualAddUpYearMonth
		/// <summary>開始計上年月(当期)プロパティ</summary>
		/// <value>YYYYMM</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始計上年月(当期)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 StAnnualAddUpYearMonth
		{
			get{return _stAnnualAddUpYearMonth;}
			set{_stAnnualAddUpYearMonth = value;}
		}

		/// public propaty name  :  EdAnnualAddUpYearMonth
		/// <summary>終了計上年月(当期)プロパティ</summary>
		/// <value>YYYYMM</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了計上年月(当期)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 EdAnnualAddUpYearMonth
		{
			get{return _edAnnualAddUpYearMonth;}
			set{_edAnnualAddUpYearMonth = value;}
		}

		/// public propaty name  :  StSupplierCd
		/// <summary>開始仕入先コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始仕入先コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 StSupplierCd
		{
			get{return _stSupplierCd;}
			set{_stSupplierCd = value;}
		}

		/// public propaty name  :  EdSupplierCd
		/// <summary>終了仕入先コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了仕入先コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 EdSupplierCd
		{
			get{return _edSupplierCd;}
			set{_edSupplierCd = value;}
		}


		/// <summary>
		/// 売上仕入対比表(月報年報)抽出条件クラスワークコンストラクタ
		/// </summary>
		/// <returns>SalesSlipYearContrastParamWorkクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SalesSlipYearContrastParamWorkクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public SalesSlipYearContrastParamWork()
		{
		}

	}
}




