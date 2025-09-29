using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
	/// public class name:   ExtrInfo_DemandBalance
	/// <summary>
	///                      請求残高元帳抽出条件ワーク
	/// </summary>
	/// <remarks>
	/// <br>note             :   請求残高元帳抽出条件ワークヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2008/11/26  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	public class ExtrInfo_DemandBalance
	{
        /// <summary>共通 日付フォーマット</summary>
        public const string ct_DateFomat = "YYYY/MM/DD";

        /// <summary>拠点オプション導入区分</summary>
        private bool _isOptSection;

		/// <summary>企業コード</summary>
		/// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
		private string _enterpriseCode = "";

		/// <summary>出力対象拠点</summary>
		/// <remarks>nullの場合は全拠点</remarks>
		private string[] _sectionCodes;

		/// <summary>開始計上年月</summary>
		/// <remarks>YYYYMM</remarks>
		private DateTime _st_AddUpYearMonth;

		/// <summary>終了計上年月</summary>
		/// <remarks>YYYYMM</remarks>
		private DateTime _ed_AddUpYearMonth;

		/// <summary>開始請求先コード</summary>
		private Int32 _st_ClaimCode;

		/// <summary>終了請求先コード</summary>
		private Int32 _ed_ClaimCode;

		/// <summary>企業名称</summary>
		private string _enterpriseName = "";

        /// <summary>全社選択フラグ</summary>
        private bool _isSelectAllSection;


        /// public propaty name  :  IsOptSection
        /// <summary>拠点オプション導入区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点オプション導入区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool IsOptSection
        {
            get { return _isOptSection; }
            set { _isOptSection = value; }
        }

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

		/// public propaty name  :  SectionCodes
		/// <summary>出力対象拠点プロパティ</summary>
		/// <value>nullの場合は全拠点</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   出力対象拠点プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string[] SectionCodes
		{
			get{return _sectionCodes;}
			set{_sectionCodes = value;}
		}

		/// public propaty name  :  St_AddUpYearMonth
		/// <summary>開始計上年月プロパティ</summary>
		/// <value>YYYYMM</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始計上年月プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime St_AddUpYearMonth
		{
			get{return _st_AddUpYearMonth;}
			set{_st_AddUpYearMonth = value;}
		}

		/// public propaty name  :  Ed_AddUpYearMonth
		/// <summary>終了計上年月プロパティ</summary>
		/// <value>YYYYMM</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了計上年月プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime Ed_AddUpYearMonth
		{
			get{return _ed_AddUpYearMonth;}
			set{_ed_AddUpYearMonth = value;}
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

        /// public propaty name  :  IsSelectAllSection
        /// <summary>全社選択プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   全社選択プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool IsSelectAllSection
        {
            get { return _isSelectAllSection; }
            set { _isSelectAllSection = value; }
        }


		/// <summary>
		/// 請求残高元帳抽出条件ワークコンストラクタ
		/// </summary>
		/// <returns>ExtrInfo_DemandBalanceクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ExtrInfo_DemandBalanceクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ExtrInfo_DemandBalance()
		{
		}

		/// <summary>
		/// 請求残高元帳抽出条件ワークコンストラクタ
		/// </summary>
		/// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
		/// <param name="sectionCodes">出力対象拠点(nullの場合は全拠点)</param>
		/// <param name="st_AddUpYearMonth">開始計上年月(YYYYMM)</param>
		/// <param name="ed_AddUpYearMonth">終了計上年月(YYYYMM)</param>
		/// <param name="st_ClaimCode">開始請求先コード</param>
		/// <param name="ed_ClaimCode">終了請求先コード</param>
		/// <param name="enterpriseName">企業名称</param>
        /// <param name="isSelectAllSection">全社選択フラグ</param>
		/// <returns>ExtrInfo_DemandBalanceクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ExtrInfo_DemandBalanceクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
        public ExtrInfo_DemandBalance(string enterpriseCode, string[] sectionCodes, DateTime st_AddUpYearMonth, DateTime ed_AddUpYearMonth, Int32 st_ClaimCode, Int32 ed_ClaimCode, string enterpriseName, bool isSelectAllSection)
		{
			this._enterpriseCode = enterpriseCode;
			this._sectionCodes = sectionCodes;
			this._st_AddUpYearMonth = st_AddUpYearMonth;
			this._ed_AddUpYearMonth = ed_AddUpYearMonth;
			this._st_ClaimCode = st_ClaimCode;
			this._ed_ClaimCode = ed_ClaimCode;
			this._enterpriseName = enterpriseName;
            this._isSelectAllSection = isSelectAllSection;
		}

		/// <summary>
		/// 請求残高元帳抽出条件ワーク複製処理
		/// </summary>
		/// <returns>ExtrInfo_DemandBalanceクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   自身の内容と等しいExtrInfo_DemandBalanceクラスのインスタンスを返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ExtrInfo_DemandBalance Clone()
		{
			return new ExtrInfo_DemandBalance(this._enterpriseCode,this._sectionCodes,this._st_AddUpYearMonth,this._ed_AddUpYearMonth,this._st_ClaimCode,this._ed_ClaimCode,this._enterpriseName, this._isSelectAllSection);
		}

		/// <summary>
		/// 請求残高元帳抽出条件ワーク比較処理
		/// </summary>
		/// <param name="target">比較対象のExtrInfo_DemandBalanceクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ExtrInfo_DemandBalanceクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public bool Equals(ExtrInfo_DemandBalance target)
		{
			return ((this.EnterpriseCode == target.EnterpriseCode)
				 && (this.SectionCodes == target.SectionCodes)
				 && (this.St_AddUpYearMonth == target.St_AddUpYearMonth)
				 && (this.Ed_AddUpYearMonth == target.Ed_AddUpYearMonth)
				 && (this.St_ClaimCode == target.St_ClaimCode)
				 && (this.Ed_ClaimCode == target.Ed_ClaimCode)
                 && (this.EnterpriseName == target.EnterpriseName)
                 && (this.IsSelectAllSection == target.IsSelectAllSection)
                 );
		}

		/// <summary>
		/// 請求残高元帳抽出条件ワーク比較処理
		/// </summary>
		/// <param name="extrInfo_DemandBalance1">
		///                    比較するExtrInfo_DemandBalanceクラスのインスタンス
		/// </param>
		/// <param name="extrInfo_DemandBalance2">比較するExtrInfo_DemandBalanceクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ExtrInfo_DemandBalanceクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static bool Equals(ExtrInfo_DemandBalance extrInfo_DemandBalance1, ExtrInfo_DemandBalance extrInfo_DemandBalance2)
		{
			return ((extrInfo_DemandBalance1.EnterpriseCode == extrInfo_DemandBalance2.EnterpriseCode)
				 && (extrInfo_DemandBalance1.SectionCodes == extrInfo_DemandBalance2.SectionCodes)
				 && (extrInfo_DemandBalance1.St_AddUpYearMonth == extrInfo_DemandBalance2.St_AddUpYearMonth)
				 && (extrInfo_DemandBalance1.Ed_AddUpYearMonth == extrInfo_DemandBalance2.Ed_AddUpYearMonth)
				 && (extrInfo_DemandBalance1.St_ClaimCode == extrInfo_DemandBalance2.St_ClaimCode)
				 && (extrInfo_DemandBalance1.Ed_ClaimCode == extrInfo_DemandBalance2.Ed_ClaimCode)
                 && (extrInfo_DemandBalance1.EnterpriseName == extrInfo_DemandBalance2.EnterpriseName)
                 && (extrInfo_DemandBalance1.IsSelectAllSection == extrInfo_DemandBalance2.IsSelectAllSection)
                 );
		}
		/// <summary>
		/// 請求残高元帳抽出条件ワーク比較処理
		/// </summary>
		/// <param name="target">比較対象のExtrInfo_DemandBalanceクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ExtrInfo_DemandBalanceクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ArrayList Compare(ExtrInfo_DemandBalance target)
		{
			ArrayList resList = new ArrayList();
			if(this.EnterpriseCode != target.EnterpriseCode)resList.Add("EnterpriseCode");
			if(this.SectionCodes != target.SectionCodes)resList.Add("SectionCodes");
			if(this.St_AddUpYearMonth != target.St_AddUpYearMonth)resList.Add("St_AddUpYearMonth");
			if(this.Ed_AddUpYearMonth != target.Ed_AddUpYearMonth)resList.Add("Ed_AddUpYearMonth");
			if(this.St_ClaimCode != target.St_ClaimCode)resList.Add("St_ClaimCode");
			if(this.Ed_ClaimCode != target.Ed_ClaimCode)resList.Add("Ed_ClaimCode");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            if (this.IsSelectAllSection != target.IsSelectAllSection) resList.Add("IsSelectAllSection");

			return resList;
		}

		/// <summary>
		/// 請求残高元帳抽出条件ワーク比較処理
		/// </summary>
		/// <param name="extrInfo_DemandBalance1">比較するExtrInfo_DemandBalanceクラスのインスタンス</param>
		/// <param name="extrInfo_DemandBalance2">比較するExtrInfo_DemandBalanceクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ExtrInfo_DemandBalanceクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static ArrayList Compare(ExtrInfo_DemandBalance extrInfo_DemandBalance1, ExtrInfo_DemandBalance extrInfo_DemandBalance2)
		{
			ArrayList resList = new ArrayList();
			if(extrInfo_DemandBalance1.EnterpriseCode != extrInfo_DemandBalance2.EnterpriseCode)resList.Add("EnterpriseCode");
			if(extrInfo_DemandBalance1.SectionCodes != extrInfo_DemandBalance2.SectionCodes)resList.Add("SectionCodes");
			if(extrInfo_DemandBalance1.St_AddUpYearMonth != extrInfo_DemandBalance2.St_AddUpYearMonth)resList.Add("St_AddUpYearMonth");
			if(extrInfo_DemandBalance1.Ed_AddUpYearMonth != extrInfo_DemandBalance2.Ed_AddUpYearMonth)resList.Add("Ed_AddUpYearMonth");
			if(extrInfo_DemandBalance1.St_ClaimCode != extrInfo_DemandBalance2.St_ClaimCode)resList.Add("St_ClaimCode");
			if(extrInfo_DemandBalance1.Ed_ClaimCode != extrInfo_DemandBalance2.Ed_ClaimCode)resList.Add("Ed_ClaimCode");
            if (extrInfo_DemandBalance1.EnterpriseName != extrInfo_DemandBalance2.EnterpriseName) resList.Add("EnterpriseName");
            if (extrInfo_DemandBalance1.IsSelectAllSection != extrInfo_DemandBalance2.IsSelectAllSection) resList.Add("IsSelectAllSection");

			return resList;
		}
	}
}
