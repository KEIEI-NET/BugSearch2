using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
	/// public class name:   RateSearchParam
	/// <summary>
	///                      掛率マスタ一括登録修正抽出条件クラス
	/// </summary>
	/// <remarks>
	/// <br>note             :   掛率マスタ一括登録修正抽出条件クラスヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2009/01/22  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	public class RateSearchParam
	{
		/// <summary>企業コード</summary>
		/// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
		private string _enterpriseCode = "";

		/// <summary>拠点コード</summary>
		/// <remarks>(配列)　全社指定はnull</remarks>
		private String[] _sectionCode;

		/// <summary>仕入先コード</summary>
		private Int32 _supplierCd;

		/// <summary>商品掛率グループコード</summary>
		private Int32 _goodsRateGrpCode;

		/// <summary>商品メーカーコード</summary>
		private Int32 _goodsMakerCd;

		/// <summary>得意先コード</summary>
		/// <remarks>(配列) nullの場合は全て</remarks>
		private Int32[] _customerCode;

		/// <summary>得意先掛率グループコード</summary>
		/// <remarks>(配列) nullの場合は全て</remarks>
		private Int32[] _custRateGrpCode;

		/// <summary>企業名称</summary>
		private string _enterpriseName = "";

        /// <summary>ログイン拠点コード</summary>
        /// <remarks></remarks>
        private String[] _prmSectionCode;

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
		/// <value>(配列)　全社指定はnull</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   拠点コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public String[] SectionCode
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

		/// public propaty name  :  GoodsRateGrpCode
		/// <summary>商品掛率グループコードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   商品掛率グループコードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 GoodsRateGrpCode
		{
			get{return _goodsRateGrpCode;}
			set{_goodsRateGrpCode = value;}
		}

		/// public propaty name  :  GoodsMakerCd
		/// <summary>商品メーカーコードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   商品メーカーコードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 GoodsMakerCd
		{
			get{return _goodsMakerCd;}
			set{_goodsMakerCd = value;}
		}

		/// public propaty name  :  CustomerCode
		/// <summary>得意先コードプロパティ</summary>
		/// <value>(配列) nullの場合は全て</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   得意先コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32[] CustomerCode
		{
			get{return _customerCode;}
			set{_customerCode = value;}
		}

		/// public propaty name  :  CustRateGrpCode
		/// <summary>得意先掛率グループコードプロパティ</summary>
		/// <value>(配列) nullの場合は全て</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   得意先掛率グループコードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32[] CustRateGrpCode
		{
			get{return _custRateGrpCode;}
			set{_custRateGrpCode = value;}
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

        /// public propaty name  :  SectionCode
        /// <summary>ログイン拠点コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public String[] PrmSectionCode
        {
            get { return _prmSectionCode; }
            set { _prmSectionCode = value; }
        }

		/// <summary>
		/// 掛率マスタ一括登録修正抽出条件クラスコンストラクタ
		/// </summary>
		/// <returns>RateSearchParamクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   RateSearchParamクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public RateSearchParam()
		{
		}

		/// <summary>
		/// 掛率マスタ一括登録修正抽出条件クラスコンストラクタ
		/// </summary>
		/// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
		/// <param name="sectionCode">拠点コード((配列)　全社指定はnull)</param>
		/// <param name="supplierCd">仕入先コード</param>
		/// <param name="goodsRateGrpCode">商品掛率グループコード</param>
		/// <param name="goodsMakerCd">商品メーカーコード</param>
		/// <param name="customerCode">得意先コード((配列) nullの場合は全て)</param>
		/// <param name="custRateGrpCode">得意先掛率グループコード((配列) nullの場合は全て)</param>
		/// <param name="enterpriseName">企業名称</param>
        /// <param name="prmSectionCode">ログイン拠点コード</param>
		/// <returns>RateSearchParamクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   RateSearchParamクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
        public RateSearchParam(string enterpriseCode, String[] sectionCode, Int32 supplierCd, Int32 goodsRateGrpCode, Int32 goodsMakerCd, Int32[] customerCode, Int32[] custRateGrpCode, string enterpriseName, String[] prmSectionCode)
		{
			this._enterpriseCode = enterpriseCode;
			this._sectionCode = sectionCode;
			this._supplierCd = supplierCd;
			this._goodsRateGrpCode = goodsRateGrpCode;
			this._goodsMakerCd = goodsMakerCd;
			this._customerCode = customerCode;
			this._custRateGrpCode = custRateGrpCode;
			this._enterpriseName = enterpriseName;
            this._prmSectionCode = prmSectionCode;
		}

		/// <summary>
		/// 掛率マスタ一括登録修正抽出条件クラス複製処理
		/// </summary>
		/// <returns>RateSearchParamクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   自身の内容と等しいRateSearchParamクラスのインスタンスを返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public RateSearchParam Clone()
		{
			return new RateSearchParam(this._enterpriseCode,this._sectionCode,this._supplierCd,this._goodsRateGrpCode,this._goodsMakerCd,this._customerCode,this._custRateGrpCode,this._enterpriseName, this._prmSectionCode);
		}

		/// <summary>
		/// 掛率マスタ一括登録修正抽出条件クラス比較処理
		/// </summary>
		/// <param name="target">比較対象のRateSearchParamクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   RateSearchParamクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public bool Equals(RateSearchParam target)
		{
			return ((this.EnterpriseCode == target.EnterpriseCode)
				 && (this.SectionCode == target.SectionCode)
				 && (this.SupplierCd == target.SupplierCd)
				 && (this.GoodsRateGrpCode == target.GoodsRateGrpCode)
				 && (this.GoodsMakerCd == target.GoodsMakerCd)
				 && (this.CustomerCode == target.CustomerCode)
				 && (this.CustRateGrpCode == target.CustRateGrpCode)
				 && (this.EnterpriseName == target.EnterpriseName)
                 && (this.PrmSectionCode == target.PrmSectionCode));
		}

		/// <summary>
		/// 掛率マスタ一括登録修正抽出条件クラス比較処理
		/// </summary>
		/// <param name="rateSearchParam1">
		///                    比較するRateSearchParamクラスのインスタンス
		/// </param>
		/// <param name="rateSearchParam2">比較するRateSearchParamクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   RateSearchParamクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static bool Equals(RateSearchParam rateSearchParam1, RateSearchParam rateSearchParam2)
		{
			return ((rateSearchParam1.EnterpriseCode == rateSearchParam2.EnterpriseCode)
				 && (rateSearchParam1.SectionCode == rateSearchParam2.SectionCode)
				 && (rateSearchParam1.SupplierCd == rateSearchParam2.SupplierCd)
				 && (rateSearchParam1.GoodsRateGrpCode == rateSearchParam2.GoodsRateGrpCode)
				 && (rateSearchParam1.GoodsMakerCd == rateSearchParam2.GoodsMakerCd)
				 && (rateSearchParam1.CustomerCode == rateSearchParam2.CustomerCode)
				 && (rateSearchParam1.CustRateGrpCode == rateSearchParam2.CustRateGrpCode)
				 && (rateSearchParam1.EnterpriseName == rateSearchParam2.EnterpriseName)
                 && (rateSearchParam1.PrmSectionCode == rateSearchParam2.PrmSectionCode));
		}
		/// <summary>
		/// 掛率マスタ一括登録修正抽出条件クラス比較処理
		/// </summary>
		/// <param name="target">比較対象のRateSearchParamクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   RateSearchParamクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ArrayList Compare(RateSearchParam target)
		{
			ArrayList resList = new ArrayList();
			if(this.EnterpriseCode != target.EnterpriseCode)resList.Add("EnterpriseCode");
			if(this.SectionCode != target.SectionCode)resList.Add("SectionCode");
			if(this.SupplierCd != target.SupplierCd)resList.Add("SupplierCd");
			if(this.GoodsRateGrpCode != target.GoodsRateGrpCode)resList.Add("GoodsRateGrpCode");
			if(this.GoodsMakerCd != target.GoodsMakerCd)resList.Add("GoodsMakerCd");
			if(this.CustomerCode != target.CustomerCode)resList.Add("CustomerCode");
			if(this.CustRateGrpCode != target.CustRateGrpCode)resList.Add("CustRateGrpCode");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            if (this.PrmSectionCode != target.PrmSectionCode) resList.Add("PrmSectionCode");

			return resList;
		}

		/// <summary>
		/// 掛率マスタ一括登録修正抽出条件クラス比較処理
		/// </summary>
		/// <param name="rateSearchParam1">比較するRateSearchParamクラスのインスタンス</param>
		/// <param name="rateSearchParam2">比較するRateSearchParamクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   RateSearchParamクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static ArrayList Compare(RateSearchParam rateSearchParam1, RateSearchParam rateSearchParam2)
		{
			ArrayList resList = new ArrayList();
			if(rateSearchParam1.EnterpriseCode != rateSearchParam2.EnterpriseCode)resList.Add("EnterpriseCode");
			if(rateSearchParam1.SectionCode != rateSearchParam2.SectionCode)resList.Add("SectionCode");
			if(rateSearchParam1.SupplierCd != rateSearchParam2.SupplierCd)resList.Add("SupplierCd");
			if(rateSearchParam1.GoodsRateGrpCode != rateSearchParam2.GoodsRateGrpCode)resList.Add("GoodsRateGrpCode");
			if(rateSearchParam1.GoodsMakerCd != rateSearchParam2.GoodsMakerCd)resList.Add("GoodsMakerCd");
			if(rateSearchParam1.CustomerCode != rateSearchParam2.CustomerCode)resList.Add("CustomerCode");
			if(rateSearchParam1.CustRateGrpCode != rateSearchParam2.CustRateGrpCode)resList.Add("CustRateGrpCode");
            if (rateSearchParam1.EnterpriseName != rateSearchParam2.EnterpriseName) resList.Add("EnterpriseName");
            if (rateSearchParam1.PrmSectionCode != rateSearchParam2.PrmSectionCode) resList.Add("PrmSectionCode");

			return resList;
		}
	}
}
