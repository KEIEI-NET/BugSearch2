using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   SalesMonthYearReportParamWork
	/// <summary>
	///                      売上月報年報出条件クラスワーク
	/// </summary>
	/// <remarks>
	/// <br>note             :   売上月報年報出条件クラスワークヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2008/08/08  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class SalesMonthYearReportParamWork
	{
		/// <summary>企業コード</summary>
		/// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
		private string _enterpriseCode = "";

		/// <summary>拠点コード</summary>
		/// <remarks>(配列)　全社指定は{""}</remarks>
		private string[] _sectionCodes;

		/// <summary>集計単位</summary>
		/// <remarks>0:得意先別 1:担当者別 2:受注者別 3:発行者別 4:地区別 5:業種別 6:販売区分別</remarks>
		private Int32 _totalType;

		/// <summary>集計方法</summary>
		/// <remarks>0:全社 1:拠点毎</remarks>
		private Int32 _ttlType;

		/// <summary>印刷タイプ</summary>
		/// <remarks>0:当月 1:当期 2:当月＆当期</remarks>
		private Int32 _printType;

		/// <summary>出力順</summary>
		/// <remarks>※出力順について参照</remarks>
		private Int32 _outType;

		/// <summary>開始対象年月(当月)</summary>
		/// <remarks>計上年月(YYYYMM)</remarks>
		private DateTime _addUpYearMonthSt;

		/// <summary>終了対象年月(当月)</summary>
		/// <remarks>計上年月(YYYYMM)</remarks>
		private DateTime _addUpYearMonthEd;

		/// <summary>開始対象年月(当期)</summary>
		/// <remarks>期首月(YYYYMM)</remarks>
		private DateTime _annualAddUpYearMonthSt;

		/// <summary>終了対象年月(当期)</summary>
		/// <remarks>計上年月(YYYYMM)</remarks>
		private DateTime _annualAddUpYaerMonthEd;

		/// <summary>開始得意先コード</summary>
		private Int32 _customerCodeSt;

		/// <summary>終了得意先コード</summary>
		private Int32 _customerCodeEd;

		/// <summary>開始検索コード</summary>
		/// <remarks>XXXコードをセット　集計単位により変化(集計単位=0:なし 1:担当者 2:受注者 3:発行者 4:地区 5:業種 6:販売区分)</remarks>
		private string _srchCodeSt = "";

		/// <summary>終了検索コード</summary>
		/// <remarks>XXXコードをセット　集計単位により変化(集計単位=0:なし 1:担当者 2:受注者 3:発行者 4:地区 5:業種 6:販売区分)</remarks>
		private string _srchCodeEd = "";


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
		/// <value>(配列)　全社指定は{""}</value>
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

		/// public propaty name  :  TotalType
		/// <summary>集計単位プロパティ</summary>
		/// <value>0:得意先別 1:担当者別 2:受注者別 3:発行者別 4:地区別 5:業種別 6:販売区分別</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   集計単位プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 TotalType
		{
			get{return _totalType;}
			set{_totalType = value;}
		}

		/// public propaty name  :  TtlType
		/// <summary>集計方法プロパティ</summary>
		/// <value>0:全社 1:拠点毎</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   集計方法プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 TtlType
		{
			get{return _ttlType;}
			set{_ttlType = value;}
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
			get{return _printType;}
			set{_printType = value;}
		}

		/// public propaty name  :  OutType
		/// <summary>出力順プロパティ</summary>
		/// <value>※出力順について参照</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   出力順プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 OutType
		{
			get{return _outType;}
			set{_outType = value;}
		}

		/// public propaty name  :  AddUpYearMonthSt
		/// <summary>開始対象年月(当月)プロパティ</summary>
		/// <value>計上年月(YYYYMM)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始対象年月(当月)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime AddUpYearMonthSt
		{
			get{return _addUpYearMonthSt;}
			set{_addUpYearMonthSt = value;}
		}

		/// public propaty name  :  AddUpYearMonthEd
		/// <summary>終了対象年月(当月)プロパティ</summary>
		/// <value>計上年月(YYYYMM)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了対象年月(当月)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime AddUpYearMonthEd
		{
			get{return _addUpYearMonthEd;}
			set{_addUpYearMonthEd = value;}
		}

		/// public propaty name  :  AnnualAddUpYearMonthSt
		/// <summary>開始対象年月(当期)プロパティ</summary>
		/// <value>期首月(YYYYMM)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始対象年月(当期)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime AnnualAddUpYearMonthSt
		{
			get{return _annualAddUpYearMonthSt;}
			set{_annualAddUpYearMonthSt = value;}
		}

		/// public propaty name  :  AnnualAddUpYaerMonthEd
		/// <summary>終了対象年月(当期)プロパティ</summary>
		/// <value>計上年月(YYYYMM)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了対象年月(当期)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime AnnualAddUpYaerMonthEd
		{
			get{return _annualAddUpYaerMonthEd;}
			set{_annualAddUpYaerMonthEd = value;}
		}

		/// public propaty name  :  CustomerCodeSt
		/// <summary>開始得意先コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始得意先コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 CustomerCodeSt
		{
			get{return _customerCodeSt;}
			set{_customerCodeSt = value;}
		}

		/// public propaty name  :  CustomerCodeEd
		/// <summary>終了得意先コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了得意先コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 CustomerCodeEd
		{
			get{return _customerCodeEd;}
			set{_customerCodeEd = value;}
		}

		/// public propaty name  :  SrchCodeSt
		/// <summary>開始検索コードプロパティ</summary>
		/// <value>XXXコードをセット　集計単位により変化(集計単位=0:なし 1:担当者 2:受注者 3:発行者 4:地区 5:業種 6:販売区分)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始検索コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string SrchCodeSt
		{
			get{return _srchCodeSt;}
			set{_srchCodeSt = value;}
		}

		/// public propaty name  :  SrchCodeEd
		/// <summary>終了検索コードプロパティ</summary>
		/// <value>XXXコードをセット　集計単位により変化(集計単位=0:なし 1:担当者 2:受注者 3:発行者 4:地区 5:業種 6:販売区分)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了検索コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string SrchCodeEd
		{
			get{return _srchCodeEd;}
			set{_srchCodeEd = value;}
		}


		/// <summary>
		/// 売上月報年報出条件クラスワークコンストラクタ
		/// </summary>
		/// <returns>SalesMonthYearReportParamWorkクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SalesMonthYearReportParamWorkクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public SalesMonthYearReportParamWork()
		{
		}

	}
}
