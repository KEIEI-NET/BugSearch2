using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   CustSalesDistributionReportParamWork
	/// <summary>
	///                      得意先別取引分布表抽出条件クラスワーク
	/// </summary>
	/// <remarks>
	/// <br>note             :   得意先別取引分布表抽出条件クラスワークヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2008/11/21  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class CustSalesDistributionReportParamWork
	{
		/// <summary>企業コード</summary>
		/// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
		private string _enterpriseCode = "";

		/// <summary>拠点コード</summary>
		/// <remarks>集計の対象となっている拠点コード</remarks>
		private string[] _sectionCode;

		/// <summary>開始対象日付</summary>
		private Int32 _stSalesDate;

		/// <summary>終了対象日付</summary>
		private Int32 _edSalesDate;

		/// <summary>開始販売従業員コード</summary>
		private string _stSalesEmployeeCd = "";

		/// <summary>終了販売従業員コード</summary>
		private string _edSalesEmployeeCd = "";

		/// <summary>販売エリアコード</summary>
		/// <remarks>地区コード</remarks>
		private Int32 _stSalesAreaCode;

		/// <summary>販売エリアコード</summary>
		/// <remarks>地区コード</remarks>
		private Int32 _edSalesAreaCode;

		/// <summary>開始得意先コード</summary>
		private Int32 _stCustomerCode;

		/// <summary>終了得意先コード</summary>
		private Int32 _edCustomerCode;

		/// <summary>発行タイプ</summary>
		/// <remarks>0:得意先 1:担当者 2:地区</remarks>
		private Int32 _printDiv;

		/// <summary>実績無印刷区分</summary>
		/// <remarks>0:する 1:しない</remarks>
		private Int32 _searchDiv;


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

		/// public propaty name  :  StSalesDate
		/// <summary>開始対象日付プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始対象日付プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 StSalesDate
		{
			get{return _stSalesDate;}
			set{_stSalesDate = value;}
		}

		/// public propaty name  :  EdSalesDate
		/// <summary>終了対象日付プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了対象日付プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 EdSalesDate
		{
			get{return _edSalesDate;}
			set{_edSalesDate = value;}
		}

		/// public propaty name  :  StSalesEmployeeCd
		/// <summary>開始販売従業員コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始販売従業員コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string StSalesEmployeeCd
		{
			get{return _stSalesEmployeeCd;}
			set{_stSalesEmployeeCd = value;}
		}

		/// public propaty name  :  EdSalesEmployeeCd
		/// <summary>終了販売従業員コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了販売従業員コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string EdSalesEmployeeCd
		{
			get{return _edSalesEmployeeCd;}
			set{_edSalesEmployeeCd = value;}
		}

		/// public propaty name  :  StSalesAreaCode
		/// <summary>販売エリアコードプロパティ</summary>
		/// <value>地区コード</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   販売エリアコードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 StSalesAreaCode
		{
			get{return _stSalesAreaCode;}
			set{_stSalesAreaCode = value;}
		}

		/// public propaty name  :  EdSalesAreaCode
		/// <summary>販売エリアコードプロパティ</summary>
		/// <value>地区コード</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   販売エリアコードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 EdSalesAreaCode
		{
			get{return _edSalesAreaCode;}
			set{_edSalesAreaCode = value;}
		}

		/// public propaty name  :  StCustomerCode
		/// <summary>開始得意先コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始得意先コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 StCustomerCode
		{
			get{return _stCustomerCode;}
			set{_stCustomerCode = value;}
		}

		/// public propaty name  :  EdCustomerCode
		/// <summary>終了得意先コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了得意先コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 EdCustomerCode
		{
			get{return _edCustomerCode;}
			set{_edCustomerCode = value;}
		}

		/// public propaty name  :  PrintDiv
		/// <summary>発行タイププロパティ</summary>
		/// <value>0:得意先 1:担当者 2:地区</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   発行タイププロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 PrintDiv
		{
			get{return _printDiv;}
			set{_printDiv = value;}
		}

		/// public propaty name  :  SearchDiv
		/// <summary>実績無印刷区分プロパティ</summary>
		/// <value>0:する 1:しない</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   実績無印刷区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SearchDiv
		{
			get{return _searchDiv;}
			set{_searchDiv = value;}
		}


		/// <summary>
		/// 得意先別取引分布表抽出条件クラスワークコンストラクタ
		/// </summary>
		/// <returns>CustSalesDistributionReportParamWorkクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   CustSalesDistributionReportParamWorkクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public CustSalesDistributionReportParamWork()
		{
		}

	}
}
