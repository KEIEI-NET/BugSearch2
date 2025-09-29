using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
	/// public class name:   CustPrtPprBlnce
	/// <summary>
	///                      得意先電子元帳検索条件(残高一覧)
	/// </summary>
	/// <remarks>
	/// <br>note             :   得意先電子元帳検索条件(残高一覧)ヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2008/09/04  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2012/06/01 30744 湯上 千加子 入力拠点コード、拠点名称の追加</br>
    /// <br>Update Note      :   2013/03/13 30744 湯上 千加子 与信残高の出力フラグを追加</br>
    /// <br>Update Note      :   </br>
	/// </remarks>
	public class CustPrtPprBlnce
	{
		/// <summary>企業コード</summary>
		/// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
		private string _enterpriseCode = "";

		/// <summary>拠点コード</summary>
		/// <remarks>(配列)　全社指定は{""}</remarks>
		private string[] _sectionCode;

		/// <summary>得意先コード</summary>
		private Int32 _customerCode;

		/// <summary>請求先コード</summary>
		private Int32 _claimCode;

		/// <summary>開始対象年月</summary>
		/// <remarks>YYYYMM</remarks>
		private DateTime _st_AddUpYearMonth;

		/// <summary>終了対象年月</summary>
		/// <remarks>YYYYMM</remarks>
		private DateTime _ed_AddUpYearMonth;

		/// <summary>企業名称</summary>
		private string _enterpriseName = "";

        // ADD 2012/06/01 ----------------------->>>>>
        /// <summary>入力拠点コード</summary>
        private string _inputSectionCode = "";

        /// <summary>入力拠点名称</summary>
        private string _inputSectionName = "";

        /// <summary>抽出拠点種別</summary>
        private Int32 _remainSectionType;
        // ADD 2012/06/01 -----------------------<<<<<
        // ADD 2013/03/13 神姫産業-与信調査 対応----------------------------------------->>>>>
        /// <summary>与信残高出力フラグ</summary>
        private bool _creditMoneyOutputDiv;
        /// <summary>入力開始年月</summary>
        private DateTime _input_St_AddUpYearMonth;
        // ADD 2013/03/13 神姫産業-与信調査 対応-----------------------------------------<<<<<




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

		/// public propaty name  :  SectionCode
		/// <summary>拠点コードプロパティ</summary>
		/// <value>(配列)　全社指定は{""}</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   拠点コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string[] SectionCode
		{
			get{return _sectionCode;}
			set{_sectionCode = value;}
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

		/// public propaty name  :  St_AddUpYearMonth
		/// <summary>開始対象年月プロパティ</summary>
		/// <value>YYYYMM</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始対象年月プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime St_AddUpYearMonth
		{
			get{return _st_AddUpYearMonth;}
			set{_st_AddUpYearMonth = value;}
		}

		/// public propaty name  :  Ed_AddUpYearMonth
		/// <summary>終了対象年月プロパティ</summary>
		/// <value>YYYYMM</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了対象年月プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime Ed_AddUpYearMonth
		{
			get{return _ed_AddUpYearMonth;}
			set{_ed_AddUpYearMonth = value;}
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
			get{return _enterpriseName;}
			set{_enterpriseName = value;}
		}


        // ADD 2012/06/01 ----------------------->>>>>
        /// public propaty name  :  InputSectionCode
        /// <summary>入力拠点コード</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入力拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string InputSectionCode
        {
            get { return _inputSectionCode; }
            set { _inputSectionCode = value; }
        }

        /// public propaty name  :  InputSectionName
        /// <summary>入力拠点名称</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入力拠点名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string InputSectionName
        {
            get { return _inputSectionName; }
            set { _inputSectionName = value; }
        }

        /// public propaty name  :  RemainSectionType
        /// <summary>抽出拠点種別</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   抽出拠点種別プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 RemainSectionType
        {
            get { return _remainSectionType; }
            set { _remainSectionType = value; }
        }

        // ADD 2012/06/01 -----------------------<<<<<

        // ADD 2013/03/13 神姫産業-与信調査 対応----------------------------------------->>>>>
        /// public propaty name  :  CreditMoneyOutputDiv
        /// <summary>与信残高出力フラグ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   与信残高出力フラグプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool CreditMoneyOutputDiv
        {
            get { return _creditMoneyOutputDiv; }
            set { _creditMoneyOutputDiv = value; }
        }

        /// public propaty name  :  Input_St_AddUpYearMonth
        /// <summary>入力開始年月</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入力開始年月プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime Input_St_AddUpYearMonth
        {
            get { return _input_St_AddUpYearMonth; }
            set { _input_St_AddUpYearMonth = value; }
        }
        
        // ADD 2013/03/13 神姫産業-与信調査 対応-----------------------------------------<<<<<

		/// <summary>
		/// 得意先電子元帳検索条件(残高一覧)コンストラクタ
		/// </summary>
		/// <returns>CustPrtPprBlnceクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   CustPrtPprBlnceクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public CustPrtPprBlnce()
		{
		}

		/// <summary>
		/// 得意先電子元帳検索条件(残高一覧)コンストラクタ
		/// </summary>
		/// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
		/// <param name="sectionCode">拠点コード((配列)　全社指定は{""})</param>
		/// <param name="customerCode">得意先コード</param>
		/// <param name="claimCode">請求先コード</param>
		/// <param name="st_AddUpYearMonth">開始対象年月(YYYYMM)</param>
		/// <param name="ed_AddUpYearMonth">終了対象年月(YYYYMM)</param>
		/// <param name="enterpriseName">企業名称</param>
		/// <returns>CustPrtPprBlnceクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   CustPrtPprBlnceクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
        // UPD 2012/06/01 ----------------------->>>>>
        //public CustPrtPprBlnce(string enterpriseCode, string[] sectionCode, Int32 customerCode, Int32 claimCode, DateTime st_AddUpYearMonth, DateTime ed_AddUpYearMonth, string enterpriseName)
        // UPD 2013/03/13 神姫産業-与信調査 対応----------------------------------------->>>>>
        //public CustPrtPprBlnce(string enterpriseCode, string[] sectionCode, Int32 customerCode, Int32 claimCode, DateTime st_AddUpYearMonth, DateTime ed_AddUpYearMonth, string enterpriseName, string inputSectionCode, string inputSectionName, int remainSectionType)
        public CustPrtPprBlnce(string enterpriseCode, string[] sectionCode, Int32 customerCode, Int32 claimCode, DateTime st_AddUpYearMonth, DateTime ed_AddUpYearMonth, string enterpriseName, string inputSectionCode, string inputSectionName, int remainSectionType, bool creditMoneyOutputDiv, DateTime input_St_AddUpYearMonth)
        // UPD 2013/03/13 神姫産業-与信調査 対応-----------------------------------------<<<<<
        // UPD 2012/06/01 -----------------------<<<<<
        {
			this._enterpriseCode = enterpriseCode;
			this._sectionCode = sectionCode;
			this._customerCode = customerCode;
			this._claimCode = claimCode;
			this._st_AddUpYearMonth = st_AddUpYearMonth;
			this._ed_AddUpYearMonth = ed_AddUpYearMonth;
			this._enterpriseName = enterpriseName;
            // ADD 2012/06/01 ----------------------->>>>>
            this._inputSectionCode = inputSectionCode;
            this._inputSectionName = inputSectionName;
            this._remainSectionType = remainSectionType;
            // ADD 2012/06/01 -----------------------<<<<<
            // ADD 2013/03/13 神姫産業-与信調査 対応----------------------------------------->>>>>
            this._creditMoneyOutputDiv = creditMoneyOutputDiv;
            this.Input_St_AddUpYearMonth = input_St_AddUpYearMonth;
            // ADD 2013/03/13 神姫産業-与信調査 対応-----------------------------------------<<<<<

        }

		/// <summary>
		/// 得意先電子元帳検索条件(残高一覧)複製処理
		/// </summary>
		/// <returns>CustPrtPprBlnceクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   自身の内容と等しいCustPrtPprBlnceクラスのインスタンスを返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public CustPrtPprBlnce Clone()
		{
            // UPD 2012/06/01 ----------------------->>>>>
			//return new CustPrtPprBlnce(this._enterpriseCode,this._sectionCode,this._customerCode,this._claimCode,this._st_AddUpYearMonth,this._ed_AddUpYearMonth,this._enterpriseName);
            // UPD 2013/03/13 神姫産業-与信調査 対応----------------------------------------->>>>>
            //return new CustPrtPprBlnce(this._enterpriseCode, this._sectionCode, this._customerCode, this._claimCode, this._st_AddUpYearMonth, this._ed_AddUpYearMonth, this._enterpriseName, this._inputSectionCode, this._inputSectionName, this._remainSectionType);
            return new CustPrtPprBlnce(this._enterpriseCode, this._sectionCode, this._customerCode, this._claimCode, this._st_AddUpYearMonth, this._ed_AddUpYearMonth, this._enterpriseName, this._inputSectionCode, this._inputSectionName, this._remainSectionType, this._creditMoneyOutputDiv, this.Input_St_AddUpYearMonth);
            // UPD 2013/03/13 神姫産業-与信調査 対応-----------------------------------------<<<<<
            // UPD 2012/06/01 -----------------------<<<<<
        }

		/// <summary>
		/// 得意先電子元帳検索条件(残高一覧)比較処理
		/// </summary>
		/// <param name="target">比較対象のCustPrtPprBlnceクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   CustPrtPprBlnceクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public bool Equals(CustPrtPprBlnce target)
		{
            // UPD 2012/06/01 ----------------------->>>>>
            //return ((this.EnterpriseCode == target.EnterpriseCode)
            //     && (this.SectionCode == target.SectionCode)
            //     && (this.CustomerCode == target.CustomerCode)
            //     && (this.ClaimCode == target.ClaimCode)
            //     && (this.St_AddUpYearMonth == target.St_AddUpYearMonth)
            //     && (this.Ed_AddUpYearMonth == target.Ed_AddUpYearMonth)
            //     && (this.EnterpriseName == target.EnterpriseName));
            // UPD 2013/03/13 神姫産業-与信調査 対応----------------------------------------->>>>>
            //return ((this.EnterpriseCode == target.EnterpriseCode)
            //     && (this.SectionCode == target.SectionCode)
            //     && (this.CustomerCode == target.CustomerCode)
            //     && (this.ClaimCode == target.ClaimCode)
            //     && (this.St_AddUpYearMonth == target.St_AddUpYearMonth)
            //     && (this.Ed_AddUpYearMonth == target.Ed_AddUpYearMonth)
            //     && (this.EnterpriseName == target.EnterpriseName)
            //     && (this.InputSectionCode == target.InputSectionCode)
            //     && (this.InputSectionName == target.InputSectionName)
            //     && (this.RemainSectionType == target.RemainSectionType));
            return ((this.EnterpriseCode == target.EnterpriseCode)
                 && (this.SectionCode == target.SectionCode)
                 && (this.CustomerCode == target.CustomerCode)
                 && (this.ClaimCode == target.ClaimCode)
                 && (this.St_AddUpYearMonth == target.St_AddUpYearMonth)
                 && (this.Ed_AddUpYearMonth == target.Ed_AddUpYearMonth)
                 && (this.EnterpriseName == target.EnterpriseName)
                 && (this.InputSectionCode == target.InputSectionCode)
                 && (this.InputSectionName == target.InputSectionName)
                 && (this.RemainSectionType == target.RemainSectionType)
                 && (this.CreditMoneyOutputDiv == target.CreditMoneyOutputDiv)
                 && (this.Input_St_AddUpYearMonth == target.Input_St_AddUpYearMonth)
                 );
            // UPD 2013/03/13 神姫産業-与信調査 対応-----------------------------------------<<<<<
            // UPD 2012/06/01 -----------------------<<<<<
        }

		/// <summary>
		/// 得意先電子元帳検索条件(残高一覧)比較処理
		/// </summary>
		/// <param name="custPrtPprBlnce1">
		///                    比較するCustPrtPprBlnceクラスのインスタンス
		/// </param>
		/// <param name="custPrtPprBlnce2">比較するCustPrtPprBlnceクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   CustPrtPprBlnceクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static bool Equals(CustPrtPprBlnce custPrtPprBlnce1, CustPrtPprBlnce custPrtPprBlnce2)
		{
            // UPD 2012/06/01 ----------------------->>>>>
            //return ((custPrtPprBlnce1.EnterpriseCode == custPrtPprBlnce2.EnterpriseCode)
            //     && (custPrtPprBlnce1.SectionCode == custPrtPprBlnce2.SectionCode)
            //     && (custPrtPprBlnce1.CustomerCode == custPrtPprBlnce2.CustomerCode)
            //     && (custPrtPprBlnce1.ClaimCode == custPrtPprBlnce2.ClaimCode)
            //     && (custPrtPprBlnce1.St_AddUpYearMonth == custPrtPprBlnce2.St_AddUpYearMonth)
            //     && (custPrtPprBlnce1.Ed_AddUpYearMonth == custPrtPprBlnce2.Ed_AddUpYearMonth)
            //     && (custPrtPprBlnce1.EnterpriseName == custPrtPprBlnce2.EnterpriseName));
            // UPD 2013/03/13 神姫産業-与信調査 対応----------------------------------------->>>>>
            //return ((custPrtPprBlnce1.EnterpriseCode == custPrtPprBlnce2.EnterpriseCode)
            //     && (custPrtPprBlnce1.SectionCode == custPrtPprBlnce2.SectionCode)
            //     && (custPrtPprBlnce1.CustomerCode == custPrtPprBlnce2.CustomerCode)
            //     && (custPrtPprBlnce1.ClaimCode == custPrtPprBlnce2.ClaimCode)
            //     && (custPrtPprBlnce1.St_AddUpYearMonth == custPrtPprBlnce2.St_AddUpYearMonth)
            //     && (custPrtPprBlnce1.Ed_AddUpYearMonth == custPrtPprBlnce2.Ed_AddUpYearMonth)
            //     && (custPrtPprBlnce1.EnterpriseName == custPrtPprBlnce2.EnterpriseName)
            //     && (custPrtPprBlnce1.InputSectionCode == custPrtPprBlnce2.InputSectionCode)
            //     && (custPrtPprBlnce1.InputSectionName == custPrtPprBlnce2.InputSectionName)
            //     && (custPrtPprBlnce1.RemainSectionType == custPrtPprBlnce2.RemainSectionType));
            return ((custPrtPprBlnce1.EnterpriseCode == custPrtPprBlnce2.EnterpriseCode)
                 && (custPrtPprBlnce1.SectionCode == custPrtPprBlnce2.SectionCode)
                 && (custPrtPprBlnce1.CustomerCode == custPrtPprBlnce2.CustomerCode)
                 && (custPrtPprBlnce1.ClaimCode == custPrtPprBlnce2.ClaimCode)
                 && (custPrtPprBlnce1.St_AddUpYearMonth == custPrtPprBlnce2.St_AddUpYearMonth)
                 && (custPrtPprBlnce1.Ed_AddUpYearMonth == custPrtPprBlnce2.Ed_AddUpYearMonth)
                 && (custPrtPprBlnce1.EnterpriseName == custPrtPprBlnce2.EnterpriseName)
                 && (custPrtPprBlnce1.InputSectionCode == custPrtPprBlnce2.InputSectionCode)
                 && (custPrtPprBlnce1.InputSectionName == custPrtPprBlnce2.InputSectionName)
                 && (custPrtPprBlnce1.RemainSectionType == custPrtPprBlnce2.RemainSectionType)
                 && (custPrtPprBlnce1.CreditMoneyOutputDiv == custPrtPprBlnce2.CreditMoneyOutputDiv)
                 && (custPrtPprBlnce1.Input_St_AddUpYearMonth == custPrtPprBlnce2.Input_St_AddUpYearMonth)
                 );
            // UPD 2013/03/13 神姫産業-与信調査 対応-----------------------------------------<<<<<
            // UPD 2012/06/01 -----------------------<<<<<
        }
		/// <summary>
		/// 得意先電子元帳検索条件(残高一覧)比較処理
		/// </summary>
		/// <param name="target">比較対象のCustPrtPprBlnceクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   CustPrtPprBlnceクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ArrayList Compare(CustPrtPprBlnce target)
		{
			ArrayList resList = new ArrayList();
			if(this.EnterpriseCode != target.EnterpriseCode)resList.Add("EnterpriseCode");
			if(this.SectionCode != target.SectionCode)resList.Add("SectionCode");
			if(this.CustomerCode != target.CustomerCode)resList.Add("CustomerCode");
			if(this.ClaimCode != target.ClaimCode)resList.Add("ClaimCode");
			if(this.St_AddUpYearMonth != target.St_AddUpYearMonth)resList.Add("St_AddUpYearMonth");
			if(this.Ed_AddUpYearMonth != target.Ed_AddUpYearMonth)resList.Add("Ed_AddUpYearMonth");
			if(this.EnterpriseName != target.EnterpriseName)resList.Add("EnterpriseName");
            // ADD 2012/06/01 ----------------------->>>>>
            if(this.InputSectionCode != target.InputSectionCode) resList.Add("InputSectionCode");
            if(this.InputSectionName != target.InputSectionName) resList.Add("InputSectionName");
            if(this.RemainSectionType != target.RemainSectionType) resList.Add("RemainSectionType");
            // ADD 2012/06/01 -----------------------<<<<<
            // ADD 2013/03/13 神姫産業-与信調査 対応----------------------------------------->>>>>
            if (this.CreditMoneyOutputDiv != target.CreditMoneyOutputDiv) resList.Add("CreditMoneyOutputDiv");
            if (this.Input_St_AddUpYearMonth != target.Input_St_AddUpYearMonth) resList.Add("Input_St_AddUpYearMonth");
            // ADD 2013/03/13 神姫産業-与信調査 対応-----------------------------------------<<<<<

			return resList;
		}

		/// <summary>
		/// 得意先電子元帳検索条件(残高一覧)比較処理
		/// </summary>
		/// <param name="custPrtPprBlnce1">比較するCustPrtPprBlnceクラスのインスタンス</param>
		/// <param name="custPrtPprBlnce2">比較するCustPrtPprBlnceクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   CustPrtPprBlnceクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static ArrayList Compare(CustPrtPprBlnce custPrtPprBlnce1, CustPrtPprBlnce custPrtPprBlnce2)
		{
			ArrayList resList = new ArrayList();
			if(custPrtPprBlnce1.EnterpriseCode != custPrtPprBlnce2.EnterpriseCode)resList.Add("EnterpriseCode");
			if(custPrtPprBlnce1.SectionCode != custPrtPprBlnce2.SectionCode)resList.Add("SectionCode");
			if(custPrtPprBlnce1.CustomerCode != custPrtPprBlnce2.CustomerCode)resList.Add("CustomerCode");
			if(custPrtPprBlnce1.ClaimCode != custPrtPprBlnce2.ClaimCode)resList.Add("ClaimCode");
			if(custPrtPprBlnce1.St_AddUpYearMonth != custPrtPprBlnce2.St_AddUpYearMonth)resList.Add("St_AddUpYearMonth");
			if(custPrtPprBlnce1.Ed_AddUpYearMonth != custPrtPprBlnce2.Ed_AddUpYearMonth)resList.Add("Ed_AddUpYearMonth");
			if(custPrtPprBlnce1.EnterpriseName != custPrtPprBlnce2.EnterpriseName)resList.Add("EnterpriseName");
            // ADD 2012/06/01 ----------------------->>>>>
            if(custPrtPprBlnce1.InputSectionCode != custPrtPprBlnce2.InputSectionCode) resList.Add("InputSectionCode");
            if(custPrtPprBlnce1.InputSectionName != custPrtPprBlnce2.InputSectionName) resList.Add("InputSectionName");
            if(custPrtPprBlnce1.RemainSectionType != custPrtPprBlnce2.RemainSectionType) resList.Add("RemainSectionType");
            // ADD 2012/06/01 -----------------------<<<<<
            // ADD 2013/03/13 神姫産業-与信調査 対応----------------------------------------->>>>>
            if (custPrtPprBlnce1.CreditMoneyOutputDiv != custPrtPprBlnce2.CreditMoneyOutputDiv) resList.Add("CreditMoneyOutputDiv");
            if (custPrtPprBlnce1.Input_St_AddUpYearMonth != custPrtPprBlnce2.Input_St_AddUpYearMonth) resList.Add("Input_St_AddUpYearMonth");
            // ADD 2013/03/13 神姫産業-与信調査 対応-----------------------------------------<<<<<

			return resList;
		}
	}
}
