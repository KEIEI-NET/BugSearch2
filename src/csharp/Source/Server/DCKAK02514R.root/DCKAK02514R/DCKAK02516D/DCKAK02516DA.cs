using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   ExtrInfo_PaymentTotalWork
	/// <summary>
	///                      支払一覧表抽出条件ワークワーク
	/// </summary>
	/// <remarks>
	/// <br>note             :   支払一覧表抽出条件ワークワークヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2008/08/11  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class ExtrInfo_PaymentTotalWork
	{
		/// <summary>企業コード</summary>
		/// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
		private string _enterpriseCode = "";

		/// <summary>選択支払計上拠点コード</summary>
		/// <remarks>nullの場合は全拠点</remarks>
		private string[] _paymentAddupSecCodeList;

		/// <summary>締日</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _cAddUpUpdExecDate;

		/// <summary>開始支払先コード</summary>
		private Int32 _st_PayeeCode;

		/// <summary>終了支払先コード</summary>
		private Int32 _ed_PayeeCode;

		/// <summary>支払先内訳</summary>
		/// <remarks>0:両方(親＋子) 1:親のみ出力 2:子のみ出力</remarks>
		private Int32 _payeeItems;


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

		/// public propaty name  :  PaymentAddupSecCodeList
		/// <summary>選択支払計上拠点コードプロパティ</summary>
		/// <value>nullの場合は全拠点</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   選択支払計上拠点コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
        public string[] PaymentAddupSecCodeList
		{
			get{return _paymentAddupSecCodeList;}
			set{_paymentAddupSecCodeList = value;}
		}

		/// public propaty name  :  CAddUpUpdExecDate
		/// <summary>締日プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   締日プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime CAddUpUpdExecDate
		{
			get{return _cAddUpUpdExecDate;}
			set{_cAddUpUpdExecDate = value;}
		}

		/// public propaty name  :  St_PayeeCode
		/// <summary>開始支払先コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始支払先コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 St_PayeeCode
		{
			get{return _st_PayeeCode;}
			set{_st_PayeeCode = value;}
		}

		/// public propaty name  :  Ed_PayeeCode
		/// <summary>終了支払先コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了支払先コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 Ed_PayeeCode
		{
			get{return _ed_PayeeCode;}
			set{_ed_PayeeCode = value;}
		}

		/// public propaty name  :  PayeeItems
		/// <summary>支払先内訳プロパティ</summary>
		/// <value>0:両方(親＋子) 1:親のみ出力 2:子のみ出力</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   支払先内訳プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 PayeeItems
		{
			get{return _payeeItems;}
			set{_payeeItems = value;}
		}


		/// <summary>
		/// 支払一覧表抽出条件ワークワークコンストラクタ
		/// </summary>
		/// <returns>ExtrInfo_PaymentTotalWorkクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ExtrInfo_PaymentTotalWorkクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ExtrInfo_PaymentTotalWork()
		{
		}

	}

}
