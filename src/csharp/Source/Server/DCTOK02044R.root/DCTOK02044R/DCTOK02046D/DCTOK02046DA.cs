using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   SalStcCompReportParamWork
	/// <summary>
	///                      売上仕入対比表(日報月報)抽出条件クラスワーク
	/// </summary>
	/// <remarks>
	/// <br>note             :   売上仕入対比表(日報月報)抽出条件クラスワークヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2008/11/20  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class SalStcCompReportParamWork 
	{
		/// <summary>企業コード</summary>
		/// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
		private string _enterpriseCode = "";

		/// <summary>拠点コード</summary>
		/// <remarks>集計の対象となっている拠点コード</remarks>
		private string[] _sectionCode;

		/// <summary>開始対象日付</summary>
		private Int32 _stReportDate;

		/// <summary>終了対象日付</summary>
		private Int32 _edReportDate;

		/// <summary>開始対象日付(累計)</summary>
		/// <remarks>累計抽出範囲の開始日付をセット</remarks>
		private Int32 _stMonthReportDate;

		/// <summary>終了対象日付(累計)</summary>
		/// <remarks>終了日付をセット</remarks>
		private Int32 _edMonthReportDate;

		/// <summary>開始得意先コード</summary>
		private Int32 _stSupplierCd;

		/// <summary>終了得意先コード</summary>
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

		/// public propaty name  :  SectionCode
		/// <summary>拠点コードプロパティ</summary>
		/// <value>集計の対象となっている拠点コード</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   拠点コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
        public string[] SectionCode
		{
			get{return _sectionCode;}
			set{_sectionCode = value;}
		}

		/// public propaty name  :  StReportDate
		/// <summary>開始対象日付プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始対象日付プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 StReportDate
		{
			get{return _stReportDate;}
			set{_stReportDate = value;}
		}

		/// public propaty name  :  EdReportDate
		/// <summary>終了対象日付プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了対象日付プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 EdReportDate
		{
			get{return _edReportDate;}
			set{_edReportDate = value;}
		}

		/// public propaty name  :  StMonthReportDate
		/// <summary>開始対象日付(累計)プロパティ</summary>
		/// <value>累計抽出範囲の開始日付をセット</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始対象日付(累計)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 StMonthReportDate
		{
			get{return _stMonthReportDate;}
			set{_stMonthReportDate = value;}
		}

		/// public propaty name  :  EdMonthReportDate
		/// <summary>終了対象日付(累計)プロパティ</summary>
		/// <value>終了日付をセット</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了対象日付(累計)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 EdMonthReportDate
		{
			get{return _edMonthReportDate;}
			set{_edMonthReportDate = value;}
		}

		/// public propaty name  :  StSupplierCd
		/// <summary>開始得意先コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始得意先コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 StSupplierCd
		{
			get{return _stSupplierCd;}
			set{_stSupplierCd = value;}
		}

		/// public propaty name  :  EdSupplierCd
		/// <summary>終了得意先コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了得意先コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 EdSupplierCd
		{
			get{return _edSupplierCd;}
			set{_edSupplierCd = value;}
		}


		/// <summary>
		/// 売上仕入対比表(日報月報)抽出条件クラスワークコンストラクタ
		/// </summary>
		/// <returns>SalStcCompReportParamWorkクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SalStcCompReportParamWorkクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public SalStcCompReportParamWork()
		{
		}

	}
}




