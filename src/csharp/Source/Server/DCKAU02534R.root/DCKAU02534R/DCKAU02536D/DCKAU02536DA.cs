using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   ExtrInfo_CollectPlanWork
	/// <summary>
	///                      回収予定表抽出条件ワーク
	/// </summary>
	/// <remarks>
	/// <br>note             :   回収予定表抽出条件ワークヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2008/08/08  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   12/25  山田</br>
	/// <br>                 :   締日末日指定を追加</br>
	/// <br>                 :   回収予定日末日指定を追加</br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class ExtrInfo_CollectPlanWork
	{
		/// <summary>企業コード</summary>
		/// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
		private string _enterpriseCode = "";

		/// <summary>出力対象拠点</summary>
		/// <remarks>nullの場合は全拠点</remarks>
		private string[] _collectAddupSecCodeList;

		/// <summary>処理日</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _addUpDate;

		/// <summary>出力順</summary>
		/// <remarks>1:得意先順 2:担当者順 3:地区順 4:担当者別回収日順 5:地区別回収日順 6:集金日順 7:集金日別回収条件順</remarks>
		private Int32 _sortOrderDiv;

		/// <summary>担当者区分</summary>
		/// <remarks>0:得意先担当 1:集金担当</remarks>
		private Int32 _employeeKindDiv;

		/// <summary>開始担当者コード</summary>
		private string _st_EmployeeCode = "";

		/// <summary>終了担当者コード</summary>
		private string _ed_EmployeeCode = "";

		/// <summary>開始販売エリアコード</summary>
		private Int32 _st_SalesAreaCode;

		/// <summary>終了販売エリアコード</summary>
		private Int32 _ed_SalesAreaCode;

		/// <summary>開始請求先コード</summary>
		private Int32 _st_ClaimCode;

		/// <summary>終了請求先コード</summary>
		private Int32 _ed_ClaimCode;

		/// <summary>締日</summary>
		/// <remarks>99指定時は全て</remarks>
		private Int32 _totalDay;

		/// <summary>締日末日指定</summary>
		/// <remarks>true:28～31全て false:指定締日のみ</remarks>
		private Boolean _isLastDayTotalDay;

		/// <summary>回収予定日</summary>
		private Int32 _collectSchedule;

		/// <summary>回収予定日末日指定</summary>
		/// <remarks>true:28～31全て false:指定締日のみ</remarks>
		private Boolean _isLastDayCollectSchedule;

		/// <summary>回収条件</summary>
		/// <remarks>選択された金種ｺｰﾄﾞを格納 10:現金など(マスタ設定による) nullの場合は全て</remarks>
		private Int32[] _collectCond;


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

		/// public propaty name  :  CollectAddupSecCodeList
		/// <summary>出力対象拠点プロパティ</summary>
		/// <value>nullの場合は全拠点</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   出力対象拠点プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string[] CollectAddupSecCodeList
		{
			get{return _collectAddupSecCodeList;}
			set{_collectAddupSecCodeList = value;}
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
		/// <value>1:得意先順 2:担当者順 3:地区順 4:担当者別回収日順 5:地区別回収日順 6:集金日順 7:集金日別回収条件順</value>
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

		/// public propaty name  :  EmployeeKindDiv
		/// <summary>担当者区分プロパティ</summary>
		/// <value>0:得意先担当 1:集金担当</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   担当者区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 EmployeeKindDiv
		{
			get{return _employeeKindDiv;}
			set{_employeeKindDiv = value;}
		}

		/// public propaty name  :  St_EmployeeCode
		/// <summary>開始担当者コードプロパティ</summary>
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

		/// public propaty name  :  St_SalesAreaCode
		/// <summary>開始販売エリアコードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始販売エリアコードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 St_SalesAreaCode
		{
			get{return _st_SalesAreaCode;}
			set{_st_SalesAreaCode = value;}
		}

		/// public propaty name  :  Ed_SalesAreaCode
		/// <summary>終了販売エリアコードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了販売エリアコードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 Ed_SalesAreaCode
		{
			get{return _ed_SalesAreaCode;}
			set{_ed_SalesAreaCode = value;}
		}

		/// public propaty name  :  St_ClaimCode
		/// <summary>開始請求先コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始請求先コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 St_ClaimCode
		{
			get{return _st_ClaimCode;}
			set{_st_ClaimCode = value;}
		}

		/// public propaty name  :  Ed_ClaimCode
		/// <summary>終了請求先コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了請求先コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 Ed_ClaimCode
		{
			get{return _ed_ClaimCode;}
			set{_ed_ClaimCode = value;}
		}

		/// public propaty name  :  TotalDay
		/// <summary>締日プロパティ</summary>
		/// <value>99指定時は全て</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   締日プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 TotalDay
		{
			get{return _totalDay;}
			set{_totalDay = value;}
		}

		/// public propaty name  :  IsLastDayTotalDay
		/// <summary>締日末日指定プロパティ</summary>
		/// <value>true:28～31全て false:指定締日のみ</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   締日末日指定プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Boolean IsLastDayTotalDay
		{
			get{return _isLastDayTotalDay;}
			set{_isLastDayTotalDay = value;}
		}

		/// public propaty name  :  CollectSchedule
		/// <summary>回収予定日プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   回収予定日プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 CollectSchedule
		{
			get{return _collectSchedule;}
			set{_collectSchedule = value;}
		}

		/// public propaty name  :  IsLastDayCollectSchedule
		/// <summary>回収予定日末日指定プロパティ</summary>
		/// <value>true:28～31全て false:指定締日のみ</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   回収予定日末日指定プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Boolean IsLastDayCollectSchedule
		{
			get{return _isLastDayCollectSchedule;}
			set{_isLastDayCollectSchedule = value;}
		}

		/// public propaty name  :  CollectCond
		/// <summary>回収条件プロパティ</summary>
		/// <value>選択された金種ｺｰﾄﾞを格納 10:現金など(マスタ設定による) nullの場合は全て</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   回収条件プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32[] CollectCond
		{
			get{return _collectCond;}
			set{_collectCond = value;}
		}


		/// <summary>
		/// 回収予定表抽出条件ワークコンストラクタ
		/// </summary>
		/// <returns>ExtrInfo_CollectPlanWorkクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ExtrInfo_CollectPlanWorkクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ExtrInfo_CollectPlanWork()
		{
		}

	}

}
