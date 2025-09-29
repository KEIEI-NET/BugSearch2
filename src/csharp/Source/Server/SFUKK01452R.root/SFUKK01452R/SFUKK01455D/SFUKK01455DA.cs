using System;
using System.Collections;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   SearchParaDepositRead
	/// <summary>
	///                      入金/引当検索パラメータクラス
	/// </summary>
	/// <remarks>
	/// <br>note             :   入金/引当検索パラメータクラスヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   2007/1/24</br>
	/// <br>Genarated Date   :   2007/05/14  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2007/05/14  木村 武正</br>
    /// <br>Update Note      :   2007/10/12  山田 明友</br>
    /// <br>                 :     受注ステータスの説明をDC用に変更</br>
    /// <br>                 :     受注番号・受注伝票番号・サービス伝票区分の削除</br>
    /// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class SearchParaDepositRead
	{
		/// <summary>企業コード</summary>
		/// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
		private string _enterpriseCode = "";

		/// <summary>計上拠点コード</summary>
		/// <remarks>集計の対象となっている拠点コード</remarks>
		private string _addUpSecCode = "";

		/// <summary>得意先コード</summary>
		private Int32 _customerCode;

		/// <summary>請求先コード</summary>
		private Int32 _claimCode;

		///// <summary>受注番号</summary>
		//private Int32 _acceptAnOrderNo;

		/// <summary>受注ステータス</summary>
        /// <remarks>10:見積,20:受注,30:売上,40:出荷</remarks>
		private Int32 _acptAnOdrStatus;

		/// <summary>売上伝票番号</summary>
		private string _salesSlipNum = "";

		///// <summary>受注伝票番号</summary>
		//private Int32 _acptAnOdrSlipNum;

		/// <summary>入金伝票番号</summary>
		private Int32 _depositSlipNo;

		/// <summary>入金日(開始)</summary>
		/// <remarks>YYYYMMDD</remarks>
		private Int32 _depositCallMonthsStart;

		/// <summary>入金日(終了)</summary>
		/// <remarks>YYYYMMDD</remarks>
		private Int32 _depositCallMonthsEnd;

		/// <summary>引当済入金伝票呼出区分</summary>
		private Int32 _alwcDepositCall;

		/// <summary>自動入金区分</summary>
		/// <remarks>0:通常入金,1:自動入金</remarks>
		private Int32 _autoDepositCd;

		///// <summary>サービス伝票区分</summary>
		///// <remarks>0:OFF, 1:ON</remarks>
		//private Int32 _serviceSlipCd;


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

		/// public propaty name  :  AddUpSecCode
		/// <summary>計上拠点コードプロパティ</summary>
		/// <value>集計の対象となっている拠点コード</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   計上拠点コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string AddUpSecCode
		{
			get{return _addUpSecCode;}
			set{_addUpSecCode = value;}
		}

		/// public propaty name  :  CustomerCode
		/// <summary>得意先コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   得意先コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 CustomerCode
		{
			get{return _customerCode;}
			set{_customerCode = value;}
		}

		/// public propaty name  :  ClaimCode
		/// <summary>請求先コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   請求先コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 ClaimCode
		{
			get{return _claimCode;}
			set{_claimCode = value;}
		}

		///// public propaty name  :  AcceptAnOrderNo
		///// <summary>受注番号プロパティ</summary>
		///// ----------------------------------------------------------------------
		///// <remarks>
		///// <br>note             :   受注番号プロパティ</br>
		///// <br>Programer        :   自動生成</br>
		///// </remarks>
		//public Int32 AcceptAnOrderNo
		//{
		//	get{return _acceptAnOrderNo;}
		//	set{_acceptAnOrderNo = value;}
		//}

		/// public propaty name  :  AcptAnOdrStatus
		/// <summary>受注ステータスプロパティ</summary>
        /// <value>10:見積,20:受注,30:売上,40:出荷</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   受注ステータスプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 AcptAnOdrStatus
		{
			get{return _acptAnOdrStatus;}
			set{_acptAnOdrStatus = value;}
		}

		/// public propaty name  :  SalesSlipNum
		/// <summary>売上伝票番号プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   売上伝票番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string SalesSlipNum
		{
			get{return _salesSlipNum;}
			set{_salesSlipNum = value;}
		}

		///// public propaty name  :  AcptAnOdrSlipNum
		///// <summary>受注伝票番号プロパティ</summary>
		///// ----------------------------------------------------------------------
		///// <remarks>
		///// <br>note             :   受注伝票番号プロパティ</br>
		///// <br>Programer        :   自動生成</br>
		///// </remarks>
		//public Int32 AcptAnOdrSlipNum
		//{
		//	get{return _acptAnOdrSlipNum;}
		//	set{_acptAnOdrSlipNum = value;}
		//}

		/// public propaty name  :  DepositSlipNo
		/// <summary>入金伝票番号プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   入金伝票番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 DepositSlipNo
		{
			get{return _depositSlipNo;}
			set{_depositSlipNo = value;}
		}

		/// public propaty name  :  DepositCallMonthsStart
		/// <summary>入金日(開始)プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   入金日(開始)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 DepositCallMonthsStart
		{
			get{return _depositCallMonthsStart;}
			set{_depositCallMonthsStart = value;}
		}

		/// public propaty name  :  DepositCallMonthsEnd
		/// <summary>入金日(終了)プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   入金日(終了)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 DepositCallMonthsEnd
		{
			get{return _depositCallMonthsEnd;}
			set{_depositCallMonthsEnd = value;}
		}

		/// public propaty name  :  AlwcDepositCall
		/// <summary>引当済入金伝票呼出区分プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   引当済入金伝票呼出区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 AlwcDepositCall
		{
			get{return _alwcDepositCall;}
			set{_alwcDepositCall = value;}
		}

		/// public propaty name  :  AutoDepositCd
		/// <summary>自動入金区分プロパティ</summary>
		/// <value>0:通常入金,1:自動入金</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   自動入金区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 AutoDepositCd
		{
			get{return _autoDepositCd;}
			set{_autoDepositCd = value;}
		}

		///// public propaty name  :  ServiceSlipCd
		///// <summary>サービス伝票区分プロパティ</summary>
		///// <value>0:OFF, 1:ON</value>
		///// ----------------------------------------------------------------------
		///// <remarks>
		///// <br>note             :   サービス伝票区分プロパティ</br>
		///// <br>Programer        :   自動生成</br>
		///// </remarks>
		//public Int32 ServiceSlipCd
		//{
		//	get{return _serviceSlipCd;}
		//	set{_serviceSlipCd = value;}
		//}


		/// <summary>
		/// 入金/引当検索パラメータクラスコンストラクタ
		/// </summary>
		/// <returns>SearchParaDepositReadクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SearchParaDepositReadクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public SearchParaDepositRead()
		{
		}

	}
}
