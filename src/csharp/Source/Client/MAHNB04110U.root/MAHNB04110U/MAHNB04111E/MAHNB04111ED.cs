using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
	/// public class name:   SalesSlipDetailSearch
	/// <summary>
	///                      売上伝票明細検索条件
	/// </summary>
	/// <remarks>
	/// <br>note             :   売上伝票明細検索条件ヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2007/10/16  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	public class SalesSlipDetailSearch
	{
		/// <summary>企業コード</summary>
		/// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
		private string _enterpriseCode = "";

		/// <summary>受注ステータス</summary>
		/// <remarks>10:見積,20:受注,30:売上,40:出荷</remarks>
		private Int32 _acptAnOdrStatus;

		/// <summary>売上伝票番号</summary>
		private string _salesSlipNum = "";

		/// <summary>企業名称</summary>
		private string _enterpriseName = "";


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
			get { return _enterpriseCode; }
			set { _enterpriseCode = value; }
		}

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
			get { return _acptAnOdrStatus; }
			set { _acptAnOdrStatus = value; }
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
			get { return _salesSlipNum; }
			set { _salesSlipNum = value; }
		}

		/// public propaty name  :  EnterpriseName
		/// <summary>企業名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   企業名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string EnterpriseName
		{
			get { return _enterpriseName; }
			set { _enterpriseName = value; }
		}


		/// <summary>
		/// 売上伝票明細検索条件コンストラクタ
		/// </summary>
		/// <returns>SalesSlipDetailSearchクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SalesSlipDetailSearchクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public SalesSlipDetailSearch()
		{
		}

		/// <summary>
		/// 売上伝票明細検索条件コンストラクタ
		/// </summary>
		/// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
		/// <param name="acptAnOdrStatus">受注ステータス(10:見積,20:受注,30:売上,40:出荷)</param>
		/// <param name="salesSlipNum">売上伝票番号</param>
		/// <param name="enterpriseName">企業名称</param>
		/// <returns>SalesSlipDetailSearchクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SalesSlipDetailSearchクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public SalesSlipDetailSearch(string enterpriseCode, Int32 acptAnOdrStatus, string salesSlipNum, string enterpriseName)
		{
			this._enterpriseCode = enterpriseCode;
			this._acptAnOdrStatus = acptAnOdrStatus;
			this._salesSlipNum = salesSlipNum;
			this._enterpriseName = enterpriseName;

		}

		/// <summary>
		/// 売上伝票明細検索条件複製処理
		/// </summary>
		/// <returns>SalesSlipDetailSearchクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   自身の内容と等しいSalesSlipDetailSearchクラスのインスタンスを返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public SalesSlipDetailSearch Clone()
		{
			return new SalesSlipDetailSearch(this._enterpriseCode, this._acptAnOdrStatus, this._salesSlipNum, this._enterpriseName);
		}

		/// <summary>
		/// 売上伝票明細検索条件比較処理
		/// </summary>
		/// <param name="target">比較対象のSalesSlipDetailSearchクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SalesSlipDetailSearchクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public bool Equals(SalesSlipDetailSearch target)
		{
			return ((this.EnterpriseCode == target.EnterpriseCode)
				 && (this.AcptAnOdrStatus == target.AcptAnOdrStatus)
				 && (this.SalesSlipNum == target.SalesSlipNum)
				 && (this.EnterpriseName == target.EnterpriseName));
		}

		/// <summary>
		/// 売上伝票明細検索条件比較処理
		/// </summary>
		/// <param name="salesSlipDetailSearch1">
		///                    比較するSalesSlipDetailSearchクラスのインスタンス
		/// </param>
		/// <param name="salesSlipDetailSearch2">比較するSalesSlipDetailSearchクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SalesSlipDetailSearchクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static bool Equals(SalesSlipDetailSearch salesSlipDetailSearch1, SalesSlipDetailSearch salesSlipDetailSearch2)
		{
			return ((salesSlipDetailSearch1.EnterpriseCode == salesSlipDetailSearch2.EnterpriseCode)
				 && (salesSlipDetailSearch1.AcptAnOdrStatus == salesSlipDetailSearch2.AcptAnOdrStatus)
				 && (salesSlipDetailSearch1.SalesSlipNum == salesSlipDetailSearch2.SalesSlipNum)
				 && (salesSlipDetailSearch1.EnterpriseName == salesSlipDetailSearch2.EnterpriseName));
		}
		/// <summary>
		/// 売上伝票明細検索条件比較処理
		/// </summary>
		/// <param name="target">比較対象のSalesSlipDetailSearchクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SalesSlipDetailSearchクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ArrayList Compare(SalesSlipDetailSearch target)
		{
			ArrayList resList = new ArrayList();
			if (this.EnterpriseCode != target.EnterpriseCode) resList.Add("EnterpriseCode");
			if (this.AcptAnOdrStatus != target.AcptAnOdrStatus) resList.Add("AcptAnOdrStatus");
			if (this.SalesSlipNum != target.SalesSlipNum) resList.Add("SalesSlipNum");
			if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");

			return resList;
		}

		/// <summary>
		/// 売上伝票明細検索条件比較処理
		/// </summary>
		/// <param name="salesSlipDetailSearch1">比較するSalesSlipDetailSearchクラスのインスタンス</param>
		/// <param name="salesSlipDetailSearch2">比較するSalesSlipDetailSearchクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SalesSlipDetailSearchクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static ArrayList Compare(SalesSlipDetailSearch salesSlipDetailSearch1, SalesSlipDetailSearch salesSlipDetailSearch2)
		{
			ArrayList resList = new ArrayList();
			if (salesSlipDetailSearch1.EnterpriseCode != salesSlipDetailSearch2.EnterpriseCode) resList.Add("EnterpriseCode");
			if (salesSlipDetailSearch1.AcptAnOdrStatus != salesSlipDetailSearch2.AcptAnOdrStatus) resList.Add("AcptAnOdrStatus");
			if (salesSlipDetailSearch1.SalesSlipNum != salesSlipDetailSearch2.SalesSlipNum) resList.Add("SalesSlipNum");
			if (salesSlipDetailSearch1.EnterpriseName != salesSlipDetailSearch2.EnterpriseName) resList.Add("EnterpriseName");

			return resList;
		}
	}
}
