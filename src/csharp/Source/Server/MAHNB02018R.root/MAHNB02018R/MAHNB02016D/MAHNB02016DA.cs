using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   DepsitMainListParamWork
	/// <summary>
	///                      入金確認表検索条件ワーク
	/// </summary>
	/// <remarks>
	/// <br>note             :   入金確認表検索条件ワークヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2008/09/24  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   2008/9/24  久保田</br>
	/// <br>                 :   入金区分を復活</br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class DepsitMainListParamWork
	{
		/// <summary>企業コード</summary>
		/// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
		private string _enterpriseCode = "";

		/// <summary>拠点コードリスト</summary>
		/// <remarks>文字型　※配列項目</remarks>
		private string[] _depositAddupSecCodeList;

		/// <summary>開始入金計上日付</summary>
		private Int32 _st_AddUpADate;

		/// <summary>終了入金計上日付</summary>
		private Int32 _ed_AddUpADate;

		/// <summary>開始入力日付</summary>
		private Int32 _st_CreateDate;

		/// <summary>終了入力日付</summary>
		private Int32 _ed_CreateDate;

		/// <summary>開始得意先コード</summary>
		private Int32 _st_CustomerCode;

		/// <summary>終了得意先コード</summary>
		private Int32 _ed_CustomerCode;

		/// <summary>開始得意先カナ</summary>
		private string _st_CustomerKana = "";

		/// <summary>終了得意先カナ</summary>
		private string _ed_CustomerKana = "";

		/// <summary>担当者種別</summary>
		/// <remarks>0:得意先担当者,1:集金担当者,2:入金担当者,3:入金入力担当者</remarks>
		private Int32 _employeeKind;

		/// <summary>開始従業員コード</summary>
		private string _st_EmployeeCd = "";

		/// <summary>終了従業員コード</summary>
		private string _ed_EmployeeCd = "";

		/// <summary>開始入金番号</summary>
		private Int32 _st_DepositSlipNo;

		/// <summary>終了入金番号</summary>
		private Int32 _ed_DepositSlipNo;

		/// <summary>入金金種</summary>
		/// <remarks>(-1:全て,金種コード：金種名称）</remarks>
		private ArrayList _depositCdKind;

		/// <summary>引当区分</summary>
		/// <remarks>0:全て,1:引当済み,2:一部引当,3:未引当</remarks>
		private Int32 _allowanceDiv;

		/// <summary>帳票タイプ区分</summary>
		/// <remarks>1:総合計,2:簡易,3:金種別集計</remarks>
		private Int32 _printDiv;

		/// <summary>入金区分</summary>
		/// <remarks>0:全て,1:通常入金のみ,2:自動入金のみ</remarks>
		private Int32 _depositDiv;


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

		/// public propaty name  :  DepositAddupSecCodeList
		/// <summary>拠点コードリストプロパティ</summary>
		/// <value>文字型　※配列項目</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   拠点コードリストプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string[] DepositAddupSecCodeList
		{
			get{return _depositAddupSecCodeList;}
			set{_depositAddupSecCodeList = value;}
		}

		/// public propaty name  :  St_AddUpADate
		/// <summary>開始入金計上日付プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始入金計上日付プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 St_AddUpADate
		{
			get{return _st_AddUpADate;}
			set{_st_AddUpADate = value;}
		}

		/// public propaty name  :  Ed_AddUpADate
		/// <summary>終了入金計上日付プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了入金計上日付プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 Ed_AddUpADate
		{
			get{return _ed_AddUpADate;}
			set{_ed_AddUpADate = value;}
		}

		/// public propaty name  :  St_CreateDate
		/// <summary>開始入力日付プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始入力日付プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 St_CreateDate
		{
			get{return _st_CreateDate;}
			set{_st_CreateDate = value;}
		}

		/// public propaty name  :  Ed_CreateDate
		/// <summary>終了入力日付プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了入力日付プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 Ed_CreateDate
		{
			get{return _ed_CreateDate;}
			set{_ed_CreateDate = value;}
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

		/// public propaty name  :  St_CustomerKana
		/// <summary>開始得意先カナプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始得意先カナプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string St_CustomerKana
		{
			get{return _st_CustomerKana;}
			set{_st_CustomerKana = value;}
		}

		/// public propaty name  :  Ed_CustomerKana
		/// <summary>終了得意先カナプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了得意先カナプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string Ed_CustomerKana
		{
			get{return _ed_CustomerKana;}
			set{_ed_CustomerKana = value;}
		}

		/// public propaty name  :  EmployeeKind
		/// <summary>担当者種別プロパティ</summary>
		/// <value>0:得意先担当者,1:集金担当者,2:入金担当者,3:入金入力担当者</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   担当者種別プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 EmployeeKind
		{
			get{return _employeeKind;}
			set{_employeeKind = value;}
		}

		/// public propaty name  :  St_EmployeeCd
		/// <summary>開始従業員コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始従業員コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string St_EmployeeCd
		{
			get{return _st_EmployeeCd;}
			set{_st_EmployeeCd = value;}
		}

		/// public propaty name  :  Ed_EmployeeCd
		/// <summary>終了従業員コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了従業員コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string Ed_EmployeeCd
		{
			get{return _ed_EmployeeCd;}
			set{_ed_EmployeeCd = value;}
		}

		/// public propaty name  :  St_DepositSlipNo
		/// <summary>開始入金番号プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始入金番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 St_DepositSlipNo
		{
			get{return _st_DepositSlipNo;}
			set{_st_DepositSlipNo = value;}
		}

		/// public propaty name  :  Ed_DepositSlipNo
		/// <summary>終了入金番号プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了入金番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 Ed_DepositSlipNo
		{
			get{return _ed_DepositSlipNo;}
			set{_ed_DepositSlipNo = value;}
		}

		/// public propaty name  :  DepositCdKind
		/// <summary>入金金種プロパティ</summary>
		/// <value>(-1:全て,金種コード：金種名称）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   入金金種プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ArrayList DepositCdKind
		{
			get{return _depositCdKind;}
			set{_depositCdKind = value;}
		}

		/// public propaty name  :  AllowanceDiv
		/// <summary>引当区分プロパティ</summary>
		/// <value>0:全て,1:引当済み,2:一部引当,3:未引当</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   引当区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 AllowanceDiv
		{
			get{return _allowanceDiv;}
			set{_allowanceDiv = value;}
		}

		/// public propaty name  :  PrintDiv
		/// <summary>帳票タイプ区分プロパティ</summary>
		/// <value>1:総合計,2:簡易,3:金種別集計</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   帳票タイプ区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 PrintDiv
		{
			get{return _printDiv;}
			set{_printDiv = value;}
		}

		/// public propaty name  :  DepositDiv
		/// <summary>入金区分プロパティ</summary>
		/// <value>0:全て,1:通常入金のみ,2:自動入金のみ</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   入金区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 DepositDiv
		{
			get{return _depositDiv;}
			set{_depositDiv = value;}
		}


		/// <summary>
		/// 入金確認表検索条件ワークコンストラクタ
		/// </summary>
		/// <returns>DepsitMainListParamWorkクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   DepsitMainListParamWorkクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DepsitMainListParamWork()
		{
		}

	}
}
