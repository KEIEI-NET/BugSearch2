using System;
using System.Collections;

using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   SeiKingetDetailParameter
	/// <summary>
	///                      請求KINGET明細用抽出条件パラメータクラス
	/// </summary>
	/// <remarks>
	/// <br>note             :   請求KINGET明細用の抽出条件パラメータクラスヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   2005/03/31</br>
	/// <br>Genarated Date   :   2005/07/21  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	[Serializable]
	public class SeiKingetDetailParameter
	{
		/// <summary>計上拠点コード</summary>
		/// <remarks>集計の対象となっている拠点コード</remarks>
		private string _addUpSecCode = "";

		/// <summary>得意先コード</summary>
		private Int32 _customerCode;

		/// <summary>計上年月日</summary>
		/// <remarks>YYYYMMDD</remarks>
		private Int32 _addUpDate;

		/// <summary>締日</summary>
		/// <remarks>DD</remarks>
		private Int32 _totalDay;

		/// <summary>日付範囲（開始）</summary>
		/// <remarks>YYYYMMDD</remarks>
		private Int32 _startDateSpan;

		/// <summary>日付範囲（終了）</summary>
		/// <remarks>YYYYMMDD</remarks>
		private Int32 _endDateSpan;


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

		/// public propaty name  :  AddUpDate
		/// <summary>計上年月日プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   計上年月日プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 AddUpDate
		{
			get{return _addUpDate;}
			set{_addUpDate = value;}
		}

		/// public propaty name  :  TotalDay
		/// <summary>締日プロパティ</summary>
		/// <value>DD</value>
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

		/// public propaty name  :  StartDateSpan
		/// <summary>日付範囲（開始）プロパティ</summary>
		/// <value>DD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   日付範囲（開始）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 StartDateSpan
		{
			get{return _startDateSpan;}
			set{_startDateSpan = value;}
		}

		/// public propaty name  :  EndDateSpan
		/// <summary>日付範囲（終了）プロパティ</summary>
		/// <value>DD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   日付範囲（終了）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 EndDateSpan
		{
			get{return _endDateSpan;}
			set{_endDateSpan = value;}
		}


		/// <summary>
		/// 請求KINGET明細用抽出条件パラメータクラスコンストラクタ
		/// </summary>
		/// <returns>SeiKingetDetailParameterクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SeiKingetDetailParameterクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public SeiKingetDetailParameter()
		{
		}

		/// <summary>
		/// 請求KINGET明細用抽出条件パラメータクラスコンストラクタ
		/// </summary>
		/// <param name="addUpSecCode">計上拠点コード(集計の対象となっている拠点コード)</param>
		/// <param name="customerCode">得意先コード</param>
		/// <param name="addUpDate">計上年月日(YYYYMMDD)</param>
		/// <param name="totalDay">締日</param>
		/// <param name="startDateSpan">日付範囲（開始）(YYYYMMDD)</param>
		/// <param name="endDateSpan">日付範囲（終了）(YYYYMMDD)</param>
		/// <returns>SeiKingetDetailParameterクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SeiKingetDetailParameterクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public SeiKingetDetailParameter(string addUpSecCode,Int32 customerCode,Int32 addUpDate,Int32 totalDay,Int32 startDateSpan,Int32 endDateSpan)
		{
			this._addUpSecCode = addUpSecCode;
			this._customerCode = customerCode;
			this._addUpDate = addUpDate;
			this._totalDay = totalDay;
			this._startDateSpan = startDateSpan;
			this._endDateSpan = endDateSpan;
		}

		/// <summary>
		/// 請求KINGET明細用抽出条件パラメータクラス複製処理
		/// </summary>
		/// <returns>SeiKingetDetailParameterクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   自身の内容と等しいSeiKingetDetailParameterクラスのインスタンスを返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public SeiKingetDetailParameter Clone()
		{
			return new SeiKingetDetailParameter(this._addUpSecCode,this._customerCode,this._addUpDate,this._totalDay,this._startDateSpan,this._endDateSpan);
		}

		/// <summary>
		/// 請求KINGET明細用抽出条件パラメータクラス初期化処理
		/// </summary>
		/// <remarks>
		/// <br>Note　　　　　　 :   SeiKingetDetailParameterクラスを初期化します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public void Clear()
		{
			this._addUpSecCode = "";
			this._customerCode = 0;
			this._addUpDate = 0;
			this._totalDay = 0;
			this._startDateSpan = 0;
			this._endDateSpan = 0;
		}

		/// <summary>
		/// 請求KINGET明細用抽出条件パラメータクラス比較処理
		/// </summary>
		/// <param name="target">比較対象のSeiKingetDetailParameterクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SeiKingetDetailParameterクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public bool Equals(SeiKingetDetailParameter target)
		{
			return ((this.AddUpSecCode == target.AddUpSecCode)
				&& (this.CustomerCode == target.CustomerCode)
				&& (this.AddUpDate == target.AddUpDate)
				&& (this.TotalDay == target.TotalDay)
				&& (this.StartDateSpan == target.StartDateSpan)
				&& (this.EndDateSpan == target.EndDateSpan));
		}

		/// <summary>
		/// 請求KINGET明細用抽出条件パラメータクラス比較処理
		/// </summary>
		/// <param name="custDmdPrc1">比較するSeiKingetDetailParameterクラスのインスタンス</param>
		/// <param name="custDmdPrc2">比較するSeiKingetDetailParameterクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SeiKingetDetailParameterクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static bool Equals(SeiKingetDetailParameter custDmdPrc1, SeiKingetDetailParameter custDmdPrc2)
		{
			return ((custDmdPrc1.AddUpSecCode == custDmdPrc2.AddUpSecCode)
				&& (custDmdPrc1.CustomerCode == custDmdPrc2.CustomerCode)
				&& (custDmdPrc1.AddUpDate == custDmdPrc2.AddUpDate)
				&& (custDmdPrc1.TotalDay == custDmdPrc2.TotalDay)
				&& (custDmdPrc1.StartDateSpan == custDmdPrc2.StartDateSpan)
				&& (custDmdPrc1.EndDateSpan == custDmdPrc2.EndDateSpan));
		}
		/// <summary>
		/// 請求KINGET明細用抽出条件パラメータクラス比較処理
		/// </summary>
		/// <param name="target">比較対象のSeiKingetDetailParameterクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SeiKingetDetailParameterクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ArrayList Compare(SeiKingetDetailParameter target)
		{
			ArrayList resList = new ArrayList();
			if(this.AddUpSecCode != target.AddUpSecCode)resList.Add("AddUpSecCode");
			if(this.CustomerCode != target.CustomerCode)resList.Add("CustomerCode");
			if(this.AddUpDate != target.AddUpDate)resList.Add("AddUpDate");
			if(this.TotalDay != target.TotalDay)resList.Add("TotalDay");
			if(this.StartDateSpan != target.StartDateSpan)resList.Add("StartDateSpan");
			if(this.EndDateSpan != target.EndDateSpan)resList.Add("EndDateSpan");

			return resList;
		}

		/// <summary>
		/// 請求KINGET明細用抽出条件パラメータクラス比較処理
		/// </summary>
		/// <param name="custDmdPrc1">比較するSeiKingetDetailParameterクラスのインスタンス</param>
		/// <param name="custDmdPrc2">比較するSeiKingetDetailParameterクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SeiKingetDetailParameterクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static ArrayList Compare(SeiKingetDetailParameter custDmdPrc1, SeiKingetDetailParameter custDmdPrc2)
		{
			ArrayList resList = new ArrayList();
			if(custDmdPrc1.AddUpSecCode != custDmdPrc2.AddUpSecCode)resList.Add("AddUpSecCode");
			if(custDmdPrc1.CustomerCode != custDmdPrc2.CustomerCode)resList.Add("CustomerCode");
			if(custDmdPrc1.AddUpDate != custDmdPrc2.AddUpDate)resList.Add("AddUpDate");
			if(custDmdPrc1.TotalDay != custDmdPrc2.TotalDay)resList.Add("TotalDay");
			if(custDmdPrc1.StartDateSpan != custDmdPrc2.StartDateSpan)resList.Add("StartDateSpan");
			if(custDmdPrc1.EndDateSpan != custDmdPrc2.EndDateSpan)resList.Add("EndDateSpan");

			return resList;
		}
	}
}
