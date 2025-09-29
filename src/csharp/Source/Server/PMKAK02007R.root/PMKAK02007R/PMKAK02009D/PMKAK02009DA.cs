//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : 支払一覧表（総括）
// プログラム概要   : 支払一覧表（総括）の印字を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2012 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : FSI東　隆史
// 作 成 日  2012/09/04  修正内容 : 新規作成
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   ExtrInfo_SumPaymentTotalWork
	/// <summary>
	///                      支払一覧表（総括）抽出条件ワークワーク
	/// </summary>
	/// <remarks>
	/// <br>note             :   支払一覧表（総括）抽出条件ワークワークヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2012/09/04  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class ExtrInfo_SumPaymentTotalWork
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


		/// <summary>
		/// 支払一覧表（総括）抽出条件ワークワークコンストラクタ
		/// </summary>
		/// <returns>ExtrInfo_SumPaymentTotalWorkクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note             :   ExtrInfo_SumPaymentTotalWorkクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ExtrInfo_SumPaymentTotalWork()
		{
		}

	}

}
