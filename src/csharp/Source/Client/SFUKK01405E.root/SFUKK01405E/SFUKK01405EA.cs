using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
	/// public class name:   DepositCustomer
	/// <summary>
	///                      入金得意先情報クラス
	/// </summary>
	/// <remarks>
	/// <br>note             :   入金得意先情報クラスヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   2005/04/1</br>
	/// <br>Genarated Date   :   2006/08/01  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	public class DepositCustomer
	{
        /// <summary>請求先コード</summary>
        private Int32 _claimCode;

        /// <summary>請求先名称１</summary>
        private string _cName = "";

        /// <summary>請求先名称２</summary>
        private string _cName2 = "";

        /// <summary>請求先略称</summary>
        private string _cSnm = "";

		/// <summary>得意先コード</summary>
		private Int32 _customerCode;

		/// <summary>得意先名称１</summary>
		private string _name = "";

		/// <summary>得意先名称２</summary>
		private string _name2 = "";

        /// <summary>得意先略称</summary>
        private string _sNm = "";

		/// <summary>敬称</summary>
		private string _honorificTitle = "";

		/// <summary>締日</summary>
		/// <remarks>DD</remarks>
		private Int32 _totalDay;

		/// <summary>集金月区分名称</summary>
		/// <remarks>当月,翌月,翌々月</remarks>
		private string _collectMoneyName = "";

		/// <summary>集金日</summary>
		/// <remarks>DD</remarks>
		private Int32 _collectMoneyDay;

		/// <summary>前回締次更新年月日</summary>
		/// <remarks>YYYYMMDD</remarks>
		private Int32 _cAddUpUpdDate;

        /// public propaty name  :  ClaimCode
        /// <summary>請求先コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   請求先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ClaimCode
        {
            get { return _claimCode; }
            set { _claimCode = value; }
        }

        /// public propaty name  :  CName
        /// <summary>請求先名称１プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   請求先名称１プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CName
        {
            get { return _cName; }
            set { _cName = value; }
        }

        /// public propaty name  :  CName2
        /// <summary>請求先名称２プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   請求先名称２プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CName2
        {
            get { return _cName2; }
            set { _cName2 = value; }
        }

        /// public propaty name  :  CSnm
        /// <summary>請求先略称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   請求先略称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CSnm
        {
            get { return _cSnm; }
            set { _cSnm = value; }
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

		/// public propaty name  :  Name
		/// <summary>得意先名称１プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   得意先名称１プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string Name
		{
			get{return _name;}
			set{_name = value;}
		}

		/// public propaty name  :  Name2
		/// <summary>得意先名称２プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   得意先名称２プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string Name2
		{
			get{return _name2;}
			set{_name2 = value;}
		}

        /// public propaty name  :  SNm
        /// <summary>得意先略称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先略称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SNm
        {
            get { return _sNm; }
            set { _sNm = value; }
        }

		/// public propaty name  :  HonorificTitle
		/// <summary>敬称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   敬称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string HonorificTitle
		{
			get {return _honorificTitle;}
			set {_honorificTitle = value;}
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

		/// public propaty name  :  CollectMoneyName
		/// <summary>集金月区分名称プロパティ</summary>
		/// <value>当月,翌月,翌々月</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   集金月区分名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string CollectMoneyName
		{
			get{return _collectMoneyName;}
			set{_collectMoneyName = value;}
		}

		/// public propaty name  :  CollectMoneyDay
		/// <summary>集金日プロパティ</summary>
		/// <value>DD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   集金日プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 CollectMoneyDay
		{
			get{return _collectMoneyDay;}
			set{_collectMoneyDay = value;}
		}

		/// public propaty name  :  CAddUpUpdDate
		/// <summary>前回締次更新年月日プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   前回締次更新年月日プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 CAddUpUpdDate
		{
			get{return _cAddUpUpdDate;}
			set{_cAddUpUpdDate = value;}
		}


		/// <summary>
		/// 入金得意先情報クラスコンストラクタ
		/// </summary>
		/// <returns>DepositCustomerクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   DepositCustomerクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DepositCustomer()
		{
		}

		/// <summary>
		/// 入金得意先情報クラスコンストラクタ
		/// </summary>
		/// <param name="claimCode">請求先コード</param>
		/// <param name="cName">請求先名称１</param>
		/// <param name="cName2">請求先名称２</param>
        /// <param name="cSnm">請求先略称</param>
        /// <param name="customerCode">得意先コード</param>
		/// <param name="name">得意先名称１</param>
		/// <param name="name2">得意先名称２</param>
		/// <param name="sNm">得意先先略称</param>
        /// <param name="honorificTitle">敬称</param>
		/// <param name="totalDay">締日(DD)</param>
		/// <param name="collectMoneyName">集金月区分名称(当月,翌月,翌々月)</param>
		/// <param name="collectMoneyDay">集金日(DD)</param>
		/// <param name="cAddUpUpdDate">前回締次更新年月日(YYYYMMDD)</param>
		/// <returns>DepositCustomerクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   DepositCustomerクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
        public DepositCustomer(Int32 claimCode, string cName, string cName2, string cSnm, Int32 customerCode, string name, string name2, string sNm, string honorificTitle, Int32 totalDay, string collectMoneyName, Int32 collectMoneyDay, Int32 cAddUpUpdDate)
		{
            this._claimCode = claimCode;
            this._cName = cName;
            this._cName2 = cName2;
            this._cSnm = cSnm;
			this._customerCode = customerCode;
			this._name = name;
			this._name2 = name2;
            this._sNm = sNm; 
			this._honorificTitle = honorificTitle;
			this._totalDay = totalDay;
			this._collectMoneyName = collectMoneyName;
			this._collectMoneyDay = collectMoneyDay;
			this._cAddUpUpdDate = cAddUpUpdDate;

		}

		/// <summary>
		/// 入金得意先情報クラス複製処理
		/// </summary>
		/// <returns>DepositCustomerクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   自身の内容と等しいDepositCustomerクラスのインスタンスを返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DepositCustomer Clone()
		{
            return new DepositCustomer(this._claimCode, this._cName, this._cName2, this._cSnm, this._customerCode, this._name, this._name2, this._sNm, this._honorificTitle, this._totalDay, this._collectMoneyName, this._collectMoneyDay, this._cAddUpUpdDate);
		}

		/// <summary>
		/// 入金得意先情報クラス比較処理
		/// </summary>
		/// <param name="target">比較対象のDepositCustomerクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   DepositCustomerクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public bool Equals(DepositCustomer target)
		{
			return ((this.ClaimCode == target.ClaimCode)
                 && (this.CName == target.CName)
                 && (this.CName2 == target.CName2)
                 && (this.CSnm == target.CSnm)
                 && (this.CustomerCode == target.CustomerCode)
				 && (this.Name == target.Name)
				 && (this.Name2 == target.Name2)
				 && (this.SNm == target.SNm)
                 && (this.HonorificTitle == target.HonorificTitle)
				 && (this.TotalDay == target.TotalDay)
				 && (this.CollectMoneyName == target.CollectMoneyName)
				 && (this.CollectMoneyDay == target.CollectMoneyDay)
				 && (this.CAddUpUpdDate == target.CAddUpUpdDate));
		}

		/// <summary>
		/// 入金得意先情報クラス比較処理
		/// </summary>
		/// <param name="depositCustomer1">
		///                    比較するDepositCustomerクラスのインスタンス
		/// </param>
		/// <param name="depositCustomer2">比較するDepositCustomerクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   DepositCustomerクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static bool Equals(DepositCustomer depositCustomer1, DepositCustomer depositCustomer2)
		{
			return ((depositCustomer1.ClaimCode == depositCustomer2.ClaimCode)
                 && (depositCustomer1.CName == depositCustomer2.CName)
                 && (depositCustomer1.CName2 == depositCustomer2.CName2)
                 && (depositCustomer1.CSnm == depositCustomer2.CSnm)
                 && (depositCustomer1.CustomerCode == depositCustomer2.CustomerCode)
				 && (depositCustomer1.Name == depositCustomer2.Name)
				 && (depositCustomer1.Name2 == depositCustomer2.Name2)
                 && (depositCustomer1.SNm == depositCustomer2.SNm)
				 && (depositCustomer1.HonorificTitle == depositCustomer2.HonorificTitle)
				 && (depositCustomer1.TotalDay == depositCustomer2.TotalDay)
				 && (depositCustomer1.CollectMoneyName == depositCustomer2.CollectMoneyName)
				 && (depositCustomer1.CollectMoneyDay == depositCustomer2.CollectMoneyDay)
				 && (depositCustomer1.CAddUpUpdDate == depositCustomer2.CAddUpUpdDate));
		}
		/// <summary>
		/// 入金得意先情報クラス比較処理
		/// </summary>
		/// <param name="target">比較対象のDepositCustomerクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   DepositCustomerクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ArrayList Compare(DepositCustomer target)
		{
			ArrayList resList = new ArrayList();
            if(this.ClaimCode != target.ClaimCode) resList.Add("ClaimCode");
            if(this.CName != target.CName) resList.Add("CName");
            if(this.CName2 != target.CName2) resList.Add("CName2");
            if(this.CSnm != target.CSnm) resList.Add("CSnm");
			if(this.CustomerCode != target.CustomerCode)resList.Add("CustomerCode");
			if(this.Name != target.Name)resList.Add("Name");
			if(this.Name2 != target.Name2) resList.Add("Name2");
            if(this.SNm != target.SNm) resList.Add("Snm");
			if(this.HonorificTitle != target.HonorificTitle) resList.Add("HonorificTitle");
			if(this.TotalDay != target.TotalDay) resList.Add("TotalDay");
			if(this.CollectMoneyName != target.CollectMoneyName)resList.Add("CollectMoneyName");
			if(this.CollectMoneyDay != target.CollectMoneyDay)resList.Add("CollectMoneyDay");
			if(this.CAddUpUpdDate != target.CAddUpUpdDate)resList.Add("CAddUpUpdDate");

			return resList;
		}

		/// <summary>
		/// 入金得意先情報クラス比較処理
		/// </summary>
		/// <param name="depositCustomer1">比較するDepositCustomerクラスのインスタンス</param>
		/// <param name="depositCustomer2">比較するDepositCustomerクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   DepositCustomerクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static ArrayList Compare(DepositCustomer depositCustomer1, DepositCustomer depositCustomer2)
		{
			ArrayList resList = new ArrayList();
            if (depositCustomer1.ClaimCode != depositCustomer2.ClaimCode) resList.Add("ClaimCode");
            if (depositCustomer1.CName != depositCustomer2.CName) resList.Add("CName");
            if (depositCustomer1.CName2 != depositCustomer2.CName2) resList.Add("CName2");
            if (depositCustomer1.CSnm != depositCustomer2.CSnm) resList.Add("CSnm");
            if(depositCustomer1.CustomerCode != depositCustomer2.CustomerCode)resList.Add("CustomerCode");
			if(depositCustomer1.Name != depositCustomer2.Name)resList.Add("Name");
			if(depositCustomer1.Name2 != depositCustomer2.Name2) resList.Add("Name2");
            if (depositCustomer1.SNm != depositCustomer2.SNm) resList.Add("SNm");
			if(depositCustomer1.HonorificTitle != depositCustomer2.HonorificTitle) resList.Add("HonorificTitle");
			if(depositCustomer1.TotalDay != depositCustomer2.TotalDay) resList.Add("TotalDay");
			if(depositCustomer1.CollectMoneyName != depositCustomer2.CollectMoneyName)resList.Add("CollectMoneyName");
			if(depositCustomer1.CollectMoneyDay != depositCustomer2.CollectMoneyDay)resList.Add("CollectMoneyDay");
			if(depositCustomer1.CAddUpUpdDate != depositCustomer2.CAddUpUpdDate)resList.Add("CAddUpUpdDate");

			return resList;
		}
	}
}
