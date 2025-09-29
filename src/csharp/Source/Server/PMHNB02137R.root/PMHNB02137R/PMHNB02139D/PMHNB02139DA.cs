using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   CustFinancialListCndtnWork
	/// <summary>
	///                      得意先過年度統計表抽出条件クラスワーク
	/// </summary>
	/// <remarks>
	/// <br>note             :   得意先過年度統計表抽出条件クラスワークヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2008/10/25  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class CustFinancialListCndtnWork
	{
		/// <summary>企業コード</summary>
		/// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
		private string _enterpriseCode = "";

		/// <summary>計上拠点コード</summary>
		/// <remarks>集計の対象となっている拠点コード</remarks>
		private string[] _addUpSecCodes;

		/// <summary>開始得意先コード</summary>
		private Int32 _st_CustomerCode;

		/// <summary>終了得意先コード</summary>
		private Int32 _ed_CustomerCode;

		/// <summary>開始年度</summary>
		private DateTime _st_Year;

		/// <summary>終了年度</summary>
		private DateTime _ed_Year;

		/// <summary>開始計上年月</summary>
		/// <remarks>終了年度の開始年月度をセット</remarks>
		private DateTime _st_AddUpYearMonth;

		/// <summary>終了計上年月</summary>
		/// <remarks>終了年度の終了年月度をセット</remarks>
		private DateTime _ed_AddUpYearMonth;

		/// <summary>発行タイプ</summary>
		/// <remarks>0:得意先別,1:拠点別,2:得意先別拠点別,3:管理拠点別,4:請求先別</remarks>
		private Int32 _printDiv;


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

		/// public propaty name  :  AddUpSecCodes
		/// <summary>計上拠点コードプロパティ</summary>
		/// <value>集計の対象となっている拠点コード</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   計上拠点コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string[] AddUpSecCodes
		{
			get{return _addUpSecCodes;}
			set{_addUpSecCodes = value;}
		}

		/// public propaty name  :  St_CustomerCode
		/// <summary>開始得意先コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始得意先コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 St_CustomerCode
		{
			get{return _st_CustomerCode;}
			set{_st_CustomerCode = value;}
		}

		/// public propaty name  :  Ed_CustomerCode
		/// <summary>終了得意先コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了得意先コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 Ed_CustomerCode
		{
			get{return _ed_CustomerCode;}
			set{_ed_CustomerCode = value;}
		}

		/// public propaty name  :  St_Year
		/// <summary>開始年度プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始年度プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime St_Year
		{
			get{return _st_Year;}
			set{_st_Year = value;}
		}

		/// public propaty name  :  Ed_Year
		/// <summary>終了年度プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了年度プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime Ed_Year
		{
			get{return _ed_Year;}
			set{_ed_Year = value;}
		}

		/// public propaty name  :  St_AddUpYearMonth
		/// <summary>開始計上年月プロパティ</summary>
		/// <value>終了年度の開始年月度をセット</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始計上年月プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime St_AddUpYearMonth
		{
			get{return _st_AddUpYearMonth;}
			set{_st_AddUpYearMonth = value;}
		}

		/// public propaty name  :  Ed_AddUpYearMonth
		/// <summary>終了計上年月プロパティ</summary>
		/// <value>終了年度の終了年月度をセット</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了計上年月プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime Ed_AddUpYearMonth
		{
			get{return _ed_AddUpYearMonth;}
			set{_ed_AddUpYearMonth = value;}
		}

		/// public propaty name  :  PrintDiv
		/// <summary>発行タイププロパティ</summary>
		/// <value>0:得意先別,1:拠点別,2:得意先別拠点別,3:管理拠点別,4:請求先別</value>
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


		/// <summary>
		/// 得意先過年度統計表抽出条件クラスワークコンストラクタ
		/// </summary>
		/// <returns>CustFinancialListCndtnWorkクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   CustFinancialListCndtnWorkクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public CustFinancialListCndtnWork()
		{
		}

	}
}




