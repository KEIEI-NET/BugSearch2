using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
	/// public class name:   PublicationConfOrderCndtn
	/// <summary>
	///                      発行確認一覧表抽出条件クラス
	/// </summary>
	/// <remarks>
	/// <br>note             :   発行確認一覧表抽出条件クラスヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2008/12/02  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   2008.12.24 30009 渋谷 大輔 プロパティ追加</br>
	/// </remarks>
	public class PublicationConfOrderCndtn
	{
		/// <summary>企業コード</summary>
		/// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
		private string _enterpriseCode = "";

		/// <summary>システム区分</summary>
		/// <remarks>0:手入力 1:伝発 2:検索 3：一括 4：補充</remarks>
		private Int32 _systemDivCd;

		/// <summary>拠点コード（複数指定）</summary>
		private string[] _sectionCodes;

		/// <summary>開始受信日付</summary>
		private DateTime _st_ReceiveDate;

		/// <summary>終了受信日付</summary>
        private DateTime _ed_ReceiveDate;

		/// <summary>印刷条件</summary>
		/// <remarks>0:チェック分のみ 1:全て</remarks>
		private Int32 _printCndtn;

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

		/// public propaty name  :  SystemDivCd
		/// <summary>システム区分プロパティ</summary>
		/// <value>0:手入力 1:伝発 2:検索 3：一括 4：補充</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   システム区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SystemDivCd
		{
			get{return _systemDivCd;}
			set{_systemDivCd = value;}
		}

		/// public propaty name  :  SectionCodes
		/// <summary>拠点コード（複数指定）プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   拠点コード（複数指定）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string[] SectionCodes
		{
			get{return _sectionCodes;}
			set{_sectionCodes = value;}
		}

        /// public propaty name  :  IsSelectAllSection
        /// <summary>全社選択プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   全社選択プロパティ</br>
        /// <br>Programer        :   30009 渋谷 大輔</br>
        /// </remarks>
        public bool IsSelectAllSection
        {
            get
            {
                bool isSelAlSec = false;
                if ((this._sectionCodes.Length == 1) && (this._sectionCodes[0].CompareTo("0") == 0))
                {
                    isSelAlSec = true;
                }
                return isSelAlSec;
            }
        }

        /// public propaty name  :  St_ReceiveDate
		/// <summary>開始受信日付プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始受信日付プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
        public DateTime St_ReceiveDate
		{
			get{return _st_ReceiveDate;}
			set{_st_ReceiveDate = value;}
		}

		/// public propaty name  :  Ed_ReceiveDate
		/// <summary>終了受信日付プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了受信日付プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
        public DateTime Ed_ReceiveDate
		{
			get{return _ed_ReceiveDate;}
			set{_ed_ReceiveDate = value;}
		}

		/// public propaty name  :  PrintCndtn
		/// <summary>印刷条件プロパティ</summary>
		/// <value>0:チェック分のみ 1:全て</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   印刷条件プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 PrintCndtn
		{
			get{return _printCndtn;}
			set{_printCndtn = value;}
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
		/// 発行確認一覧表抽出条件クラスコンストラクタ
		/// </summary>
		/// <returns>PublicationConfOrderCndtnクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   PublicationConfOrderCndtnクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public PublicationConfOrderCndtn()
		{
		}

		/// <summary>
		/// 発行確認一覧表抽出条件クラスコンストラクタ
		/// </summary>
		/// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
		/// <param name="systemDivCd">システム区分(0:手入力 1:伝発 2:検索 3：一括 4：補充)</param>
		/// <param name="sectionCodes">拠点コード（複数指定）</param>
		/// <param name="st_ReceiveDate">開始受信日付</param>
		/// <param name="ed_ReceiveDate">終了受信日付</param>
		/// <param name="printCndtn">印刷条件(0:チェック分のみ 1:全て)</param>
		/// <param name="enterpriseName">企業名称</param>
		/// <returns>PublicationConfOrderCndtnクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   PublicationConfOrderCndtnクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
        public PublicationConfOrderCndtn(string enterpriseCode, Int32 systemDivCd, string[] sectionCodes, DateTime st_ReceiveDate, DateTime ed_ReceiveDate, Int32 printCndtn, string enterpriseName)
		{
			this._enterpriseCode = enterpriseCode;
			this._systemDivCd = systemDivCd;
			this._sectionCodes = sectionCodes;
			this._st_ReceiveDate = st_ReceiveDate;
			this._ed_ReceiveDate = ed_ReceiveDate;
			this._printCndtn = printCndtn;
			this._enterpriseName = enterpriseName;

		}

		/// <summary>
		/// 発行確認一覧表抽出条件クラス複製処理
		/// </summary>
		/// <returns>PublicationConfOrderCndtnクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   自身の内容と等しいPublicationConfOrderCndtnクラスのインスタンスを返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public PublicationConfOrderCndtn Clone()
		{
			return new PublicationConfOrderCndtn(this._enterpriseCode,this._systemDivCd,this._sectionCodes,this._st_ReceiveDate,this._ed_ReceiveDate,this._printCndtn,this._enterpriseName);
		}

		/// <summary>
		/// 発行確認一覧表抽出条件クラス比較処理
		/// </summary>
		/// <param name="target">比較対象のPublicationConfOrderCndtnクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   PublicationConfOrderCndtnクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public bool Equals(PublicationConfOrderCndtn target)
		{
			return ((this.EnterpriseCode == target.EnterpriseCode)
				 && (this.SystemDivCd == target.SystemDivCd)
				 && (this.SectionCodes == target.SectionCodes)
				 && (this.St_ReceiveDate == target.St_ReceiveDate)
				 && (this.Ed_ReceiveDate == target.Ed_ReceiveDate)
				 && (this.PrintCndtn == target.PrintCndtn)
				 && (this.EnterpriseName == target.EnterpriseName));
		}

		/// <summary>
		/// 発行確認一覧表抽出条件クラス比較処理
		/// </summary>
		/// <param name="publicationConfOrderCndtn1">
		///                    比較するPublicationConfOrderCndtnクラスのインスタンス
		/// </param>
		/// <param name="publicationConfOrderCndtn2">比較するPublicationConfOrderCndtnクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   PublicationConfOrderCndtnクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static bool Equals(PublicationConfOrderCndtn publicationConfOrderCndtn1, PublicationConfOrderCndtn publicationConfOrderCndtn2)
		{
			return ((publicationConfOrderCndtn1.EnterpriseCode == publicationConfOrderCndtn2.EnterpriseCode)
				 && (publicationConfOrderCndtn1.SystemDivCd == publicationConfOrderCndtn2.SystemDivCd)
				 && (publicationConfOrderCndtn1.SectionCodes == publicationConfOrderCndtn2.SectionCodes)
				 && (publicationConfOrderCndtn1.St_ReceiveDate == publicationConfOrderCndtn2.St_ReceiveDate)
				 && (publicationConfOrderCndtn1.Ed_ReceiveDate == publicationConfOrderCndtn2.Ed_ReceiveDate)
				 && (publicationConfOrderCndtn1.PrintCndtn == publicationConfOrderCndtn2.PrintCndtn)
				 && (publicationConfOrderCndtn1.EnterpriseName == publicationConfOrderCndtn2.EnterpriseName));
		}
		/// <summary>
		/// 発行確認一覧表抽出条件クラス比較処理
		/// </summary>
		/// <param name="target">比較対象のPublicationConfOrderCndtnクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   PublicationConfOrderCndtnクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ArrayList Compare(PublicationConfOrderCndtn target)
		{
			ArrayList resList = new ArrayList();
			if(this.EnterpriseCode != target.EnterpriseCode)resList.Add("EnterpriseCode");
			if(this.SystemDivCd != target.SystemDivCd)resList.Add("SystemDivCd");
			if(this.SectionCodes != target.SectionCodes)resList.Add("SectionCodes");
			if(this.St_ReceiveDate != target.St_ReceiveDate)resList.Add("St_ReceiveDate");
			if(this.Ed_ReceiveDate != target.Ed_ReceiveDate)resList.Add("Ed_ReceiveDate");
			if(this.PrintCndtn != target.PrintCndtn)resList.Add("PrintCndtn");
			if(this.EnterpriseName != target.EnterpriseName)resList.Add("EnterpriseName");

			return resList;
		}

		/// <summary>
		/// 発行確認一覧表抽出条件クラス比較処理
		/// </summary>
		/// <param name="publicationConfOrderCndtn1">比較するPublicationConfOrderCndtnクラスのインスタンス</param>
		/// <param name="publicationConfOrderCndtn2">比較するPublicationConfOrderCndtnクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   PublicationConfOrderCndtnクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static ArrayList Compare(PublicationConfOrderCndtn publicationConfOrderCndtn1, PublicationConfOrderCndtn publicationConfOrderCndtn2)
		{
			ArrayList resList = new ArrayList();
			if(publicationConfOrderCndtn1.EnterpriseCode != publicationConfOrderCndtn2.EnterpriseCode)resList.Add("EnterpriseCode");
			if(publicationConfOrderCndtn1.SystemDivCd != publicationConfOrderCndtn2.SystemDivCd)resList.Add("SystemDivCd");
			if(publicationConfOrderCndtn1.SectionCodes != publicationConfOrderCndtn2.SectionCodes)resList.Add("SectionCodes");
			if(publicationConfOrderCndtn1.St_ReceiveDate != publicationConfOrderCndtn2.St_ReceiveDate)resList.Add("St_ReceiveDate");
			if(publicationConfOrderCndtn1.Ed_ReceiveDate != publicationConfOrderCndtn2.Ed_ReceiveDate)resList.Add("Ed_ReceiveDate");
			if(publicationConfOrderCndtn1.PrintCndtn != publicationConfOrderCndtn2.PrintCndtn)resList.Add("PrintCndtn");
			if(publicationConfOrderCndtn1.EnterpriseName != publicationConfOrderCndtn2.EnterpriseName)resList.Add("EnterpriseName");

			return resList;
		}
	}
}
