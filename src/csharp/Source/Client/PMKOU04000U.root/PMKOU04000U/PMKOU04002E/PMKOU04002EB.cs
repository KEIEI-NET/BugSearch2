using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
	/// public class name:   SuppPrtPprBlnce
	/// <summary>
	///                      仕入先電子元帳検索条件(残高一覧)
	/// </summary>
	/// <remarks>
	/// <br>note             :   仕入先電子元帳検索条件(残高一覧)ヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2008/10/16  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2010/07/20 chenyd</br>
    /// <br>           　        テキスト出力対応</br>
	/// </remarks>
	public class SuppPrtPprBlnce
	{
		/// <summary>企業コード</summary>
		/// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
		private string _enterpriseCode = "";

		/// <summary>拠点コード</summary>
		/// <remarks>(配列)　全社指定は{""}</remarks>
		private string[] _sectionCode;

		/// <summary>仕入先コード</summary>
		private Int32 _supplierCd;
        // ---------------------- ADD 2010/07/20 -------------->>>>>
        /// <summary>開始仕入先コード</summary>
        private Int32 _st_supplierCd;

        /// <summary>終了仕入先コード</summary>
        private Int32 _ed_supplierCd;
        // ---------------------- ADD 2010/07/20 ---------------<<<<<
        /// <summary>検索区分</summary>
        private Int32 _searchDiv;

		/// <summary>支払先コード</summary>
		private Int32 _payeeCode;

		/// <summary>開始対象年月</summary>
		/// <remarks>YYYYMM</remarks>
		private DateTime _st_AddUpYearMonth;

		/// <summary>終了対象年月</summary>
		/// <remarks>YYYYMM</remarks>
		private DateTime _ed_AddUpYearMonth;

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

		/// public propaty name  :  SupplierCd
		/// <summary>仕入先コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入先コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SupplierCd
		{
			get{return _supplierCd;}
			set{_supplierCd = value;}
		}
        // ---------------------- ADD 2010/07/20 --------------->>>>>
        /// public propaty name  :  St_SupplierCd
        /// <summary>開始仕入先コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始仕入先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 St_SupplierCd
        {
            get { return _st_supplierCd; }
            set { _st_supplierCd = value; }
        }

        /// public propaty name  :  Ed_SupplierCd
        /// <summary>終了仕入先コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了仕入先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 Ed_SupplierCd
        {
            get { return _ed_supplierCd; }
            set { _ed_supplierCd = value; }
        }
        // ---------------------- ADD 2010/07/20 ---------------<<<<<
        /// public propaty name  :  SearchDiv
        /// <summary>検索区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   検索区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SearchDiv
        {
            get { return _searchDiv; }
            set { _searchDiv = value; }
        }

		/// public propaty name  :  PayeeCode
		/// <summary>支払先コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   支払先コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 PayeeCode
		{
			get{return _payeeCode;}
			set{_payeeCode = value;}
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


		/// <summary>
		/// 仕入先電子元帳検索条件(残高一覧)コンストラクタ
		/// </summary>
		/// <returns>SuppPrtPprBlnceクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SuppPrtPprBlnceクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public SuppPrtPprBlnce()
		{
		}

		/// <summary>
		/// 仕入先電子元帳検索条件(残高一覧)コンストラクタ
		/// </summary>
		/// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
		/// <param name="sectionCode">拠点コード((配列)　全社指定は{""})</param>
		/// <param name="supplierCd">仕入先コード</param>
		/// <param name="payeeCode">支払先コード</param>
		/// <param name="st_AddUpYearMonth">開始対象年月(YYYYMM)</param>
		/// <param name="ed_AddUpYearMonth">終了対象年月(YYYYMM)</param>
		/// <param name="enterpriseName">企業名称</param>
		/// <returns>SuppPrtPprBlnceクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SuppPrtPprBlnceクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
        public SuppPrtPprBlnce(string enterpriseCode, string[] sectionCode, Int32 supplierCd, Int32 payeeCode, DateTime st_AddUpYearMonth, DateTime ed_AddUpYearMonth, string enterpriseName)
		{
			this._enterpriseCode = enterpriseCode;
			this._sectionCode = sectionCode;
			this._supplierCd = supplierCd;
			this._payeeCode = payeeCode;
			this._st_AddUpYearMonth = st_AddUpYearMonth;
			this._ed_AddUpYearMonth = ed_AddUpYearMonth;
			this._enterpriseName = enterpriseName;

		}

		/// <summary>
		/// 仕入先電子元帳検索条件(残高一覧)複製処理
		/// </summary>
		/// <returns>SuppPrtPprBlnceクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   自身の内容と等しいSuppPrtPprBlnceクラスのインスタンスを返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public SuppPrtPprBlnce Clone()
		{
			return new SuppPrtPprBlnce(this._enterpriseCode,this._sectionCode,this._supplierCd,this._payeeCode,this._st_AddUpYearMonth,this._ed_AddUpYearMonth,this._enterpriseName);
		}

		/// <summary>
		/// 仕入先電子元帳検索条件(残高一覧)比較処理
		/// </summary>
		/// <param name="target">比較対象のSuppPrtPprBlnceクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SuppPrtPprBlnceクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public bool Equals(SuppPrtPprBlnce target)
		{
			return ((this.EnterpriseCode == target.EnterpriseCode)
				 && (this.SectionCode == target.SectionCode)
				 && (this.SupplierCd == target.SupplierCd)
				 && (this.PayeeCode == target.PayeeCode)
				 && (this.St_AddUpYearMonth == target.St_AddUpYearMonth)
				 && (this.Ed_AddUpYearMonth == target.Ed_AddUpYearMonth)
				 && (this.EnterpriseName == target.EnterpriseName));
		}

		/// <summary>
		/// 仕入先電子元帳検索条件(残高一覧)比較処理
		/// </summary>
		/// <param name="suppPrtPprBlnce1">
		///                    比較するSuppPrtPprBlnceクラスのインスタンス
		/// </param>
		/// <param name="suppPrtPprBlnce2">比較するSuppPrtPprBlnceクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SuppPrtPprBlnceクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static bool Equals(SuppPrtPprBlnce suppPrtPprBlnce1, SuppPrtPprBlnce suppPrtPprBlnce2)
		{
			return ((suppPrtPprBlnce1.EnterpriseCode == suppPrtPprBlnce2.EnterpriseCode)
				 && (suppPrtPprBlnce1.SectionCode == suppPrtPprBlnce2.SectionCode)
				 && (suppPrtPprBlnce1.SupplierCd == suppPrtPprBlnce2.SupplierCd)
				 && (suppPrtPprBlnce1.PayeeCode == suppPrtPprBlnce2.PayeeCode)
				 && (suppPrtPprBlnce1.St_AddUpYearMonth == suppPrtPprBlnce2.St_AddUpYearMonth)
				 && (suppPrtPprBlnce1.Ed_AddUpYearMonth == suppPrtPprBlnce2.Ed_AddUpYearMonth)
				 && (suppPrtPprBlnce1.EnterpriseName == suppPrtPprBlnce2.EnterpriseName));
		}
		/// <summary>
		/// 仕入先電子元帳検索条件(残高一覧)比較処理
		/// </summary>
		/// <param name="target">比較対象のSuppPrtPprBlnceクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SuppPrtPprBlnceクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ArrayList Compare(SuppPrtPprBlnce target)
		{
			ArrayList resList = new ArrayList();
			if(this.EnterpriseCode != target.EnterpriseCode)resList.Add("EnterpriseCode");
			if(this.SectionCode != target.SectionCode)resList.Add("SectionCode");
			if(this.SupplierCd != target.SupplierCd)resList.Add("SupplierCd");
			if(this.PayeeCode != target.PayeeCode)resList.Add("PayeeCode");
			if(this.St_AddUpYearMonth != target.St_AddUpYearMonth)resList.Add("St_AddUpYearMonth");
			if(this.Ed_AddUpYearMonth != target.Ed_AddUpYearMonth)resList.Add("Ed_AddUpYearMonth");
			if(this.EnterpriseName != target.EnterpriseName)resList.Add("EnterpriseName");

			return resList;
		}

		/// <summary>
		/// 仕入先電子元帳検索条件(残高一覧)比較処理
		/// </summary>
		/// <param name="suppPrtPprBlnce1">比較するSuppPrtPprBlnceクラスのインスタンス</param>
		/// <param name="suppPrtPprBlnce2">比較するSuppPrtPprBlnceクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SuppPrtPprBlnceクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static ArrayList Compare(SuppPrtPprBlnce suppPrtPprBlnce1, SuppPrtPprBlnce suppPrtPprBlnce2)
		{
			ArrayList resList = new ArrayList();
			if(suppPrtPprBlnce1.EnterpriseCode != suppPrtPprBlnce2.EnterpriseCode)resList.Add("EnterpriseCode");
			if(suppPrtPprBlnce1.SectionCode != suppPrtPprBlnce2.SectionCode)resList.Add("SectionCode");
			if(suppPrtPprBlnce1.SupplierCd != suppPrtPprBlnce2.SupplierCd)resList.Add("SupplierCd");
			if(suppPrtPprBlnce1.PayeeCode != suppPrtPprBlnce2.PayeeCode)resList.Add("PayeeCode");
			if(suppPrtPprBlnce1.St_AddUpYearMonth != suppPrtPprBlnce2.St_AddUpYearMonth)resList.Add("St_AddUpYearMonth");
			if(suppPrtPprBlnce1.Ed_AddUpYearMonth != suppPrtPprBlnce2.Ed_AddUpYearMonth)resList.Add("Ed_AddUpYearMonth");
			if(suppPrtPprBlnce1.EnterpriseName != suppPrtPprBlnce2.EnterpriseName)resList.Add("EnterpriseName");

			return resList;
		}
	}
}
