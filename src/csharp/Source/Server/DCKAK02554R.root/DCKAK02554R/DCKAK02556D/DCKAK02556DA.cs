using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   ExtrInfo_PaymentPlanWork
	/// <summary>
	///                      支払予定表抽出条件ワークワーク
	/// </summary>
	/// <remarks>
	/// <br>note             :   支払予定表抽出条件ワークワークヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2008/08/11  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class ExtrInfo_PaymentPlanWork
	{
		/// <summary>企業コード</summary>
		/// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
		private string _enterpriseCode = "";

		/// <summary>出力対象拠点</summary>
		/// <remarks>nullの場合は全拠点</remarks>
		private string[] _paymentAddupSecCodeList;

		/// <summary>処理日</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _addUpDate;

		/// <summary>出力順</summary>
		/// <remarks>1:仕入先順 2:担当者順 3:担当者別支払日順 4:支払日順 5:支払日別支払条件順</remarks>
		private Int32 _sortOrderDiv;

		/// <summary>開始担当者コード</summary>
		/// <remarks>仕入担当</remarks>
		private string _st_EmployeeCode = "";

		/// <summary>終了担当者コード</summary>
		/// <remarks>仕入担当</remarks>
		private string _ed_EmployeeCode = "";

		/// <summary>開始支払先コード</summary>
		private Int32 _st_PayeeCode;

		/// <summary>終了支払先コード</summary>
		private Int32 _ed_PayeeCode;

		/// <summary>締日</summary>
		/// <remarks>99指定時は28日以降全て</remarks>
        private Int32 _cAddUpUpdExecDate;

		/// <summary>締日末日指定</summary>
		/// <remarks>true:28～31全て false:指定締日のみ</remarks>
		private Boolean _isLastDayCAddUpUpdExecDate;

		/// <summary>支払予定日</summary>
		/// <remarks>今回請求分の支払（入金）予定日</remarks>
        private Int32 _paymentSchedule;

		/// <summary>支払予定日末日指定</summary>
		/// <remarks>true:28～31全て false:指定支払予定日のみ</remarks>
		private Boolean _isLastDayPaymentSchedule;

		/// <summary>支払条件</summary>
		/// <remarks>選択された金種ｺｰﾄﾞを格納 10:現金など(マスタ設定による) nullの場合は全て</remarks>
		private Int32[] _paymentCond;


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
		/// <summary>出力対象拠点プロパティ</summary>
		/// <value>nullの場合は全拠点</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   出力対象拠点プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
        public string[] PaymentAddupSecCodeList
		{
			get{return _paymentAddupSecCodeList;}
			set{_paymentAddupSecCodeList = value;}
		}

		/// public propaty name  :  AddUpDate
		/// <summary>処理日プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   処理日プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime AddUpDate
		{
			get{return _addUpDate;}
			set{_addUpDate = value;}
		}

		/// public propaty name  :  SortOrderDiv
		/// <summary>出力順プロパティ</summary>
		/// <value>1:仕入先順 2:担当者順 3:担当者別支払日順 4:支払日順 5:支払日別支払条件順</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   出力順プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SortOrderDiv
		{
			get{return _sortOrderDiv;}
			set{_sortOrderDiv = value;}
		}

		/// public propaty name  :  St_EmployeeCode
		/// <summary>開始担当者コードプロパティ</summary>
		/// <value>仕入担当</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始担当者コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string St_EmployeeCode
		{
			get{return _st_EmployeeCode;}
			set{_st_EmployeeCode = value;}
		}

		/// public propaty name  :  Ed_EmployeeCode
		/// <summary>終了担当者コードプロパティ</summary>
		/// <value>仕入担当</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了担当者コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string Ed_EmployeeCode
		{
			get{return _ed_EmployeeCode;}
			set{_ed_EmployeeCode = value;}
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

		/// public propaty name  :  CAddUpUpdExecDate
		/// <summary>締日プロパティ</summary>
		/// <value>99指定時は28日以降全て</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   締日プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
        public Int32 CAddUpUpdExecDate
		{
			get{return _cAddUpUpdExecDate;}
			set{_cAddUpUpdExecDate = value;}
		}

		/// public propaty name  :  IsLastDayCAddUpUpdExecDate
		/// <summary>締日末日指定プロパティ</summary>
		/// <value>true:28～31全て false:指定締日のみ</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   締日末日指定プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Boolean IsLastDayCAddUpUpdExecDate
		{
			get{return _isLastDayCAddUpUpdExecDate;}
			set{_isLastDayCAddUpUpdExecDate = value;}
		}

		/// public propaty name  :  PaymentSchedule
		/// <summary>支払予定日プロパティ</summary>
		/// <value>今回請求分の支払（入金）予定日</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   支払予定日プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
        public Int32 PaymentSchedule
		{
			get{return _paymentSchedule;}
			set{_paymentSchedule = value;}
		}

		/// public propaty name  :  IsLastDayPaymentSchedule
		/// <summary>支払予定日末日指定プロパティ</summary>
		/// <value>true:28～31全て false:指定支払予定日のみ</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   支払予定日末日指定プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Boolean IsLastDayPaymentSchedule
		{
			get{return _isLastDayPaymentSchedule;}
			set{_isLastDayPaymentSchedule = value;}
		}

		/// public propaty name  :  PaymentCond
		/// <summary>支払条件プロパティ</summary>
		/// <value>選択された金種ｺｰﾄﾞを格納 10:現金など(マスタ設定による) nullの場合は全て</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   支払条件プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32[] PaymentCond
		{
			get{return _paymentCond;}
			set{_paymentCond = value;}
		}


		/// <summary>
		/// 支払予定表抽出条件ワークワークコンストラクタ
		/// </summary>
		/// <returns>ExtrInfo_PaymentPlanWorkクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ExtrInfo_PaymentPlanWorkクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ExtrInfo_PaymentPlanWork()
		{
		}

	}

}
