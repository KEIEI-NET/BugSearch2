using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
	/// public class name:   ShipGdsPrmListCndtnPartner
	/// <summary>
	///                      出荷商品優良対応表(対応品番用)抽出条件クラス
	/// </summary>
	/// <remarks>
	/// <br>note             :   出荷商品優良対応表(対応品番用)抽出条件クラスヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2008/11/25  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	public class ShipGdsPrmListCndtnPartner2
	{
		/// <summary>企業コード</summary>
		/// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
		private string _enterpriseCode = "";

		/// <summary>拠点コード</summary>
		private string _sectionCode = "";

		/// <summary>開始対象年月</summary>
		private DateTime _st_AddUpYearMonth;

		/// <summary>終了対象年月</summary>
		private DateTime _ed_AddUpYearMonth;

		/// <summary>メーカーコード</summary>
		private Int32 _goodsMakerCd;

		/// <summary>品番</summary>
		private string _goodsNo = "";

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
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   拠点コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string SectionCode
		{
			get{return _sectionCode;}
			set{_sectionCode = value;}
		}

		/// public propaty name  :  St_AddUpYearMonth
		/// <summary>開始対象年月プロパティ</summary>
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

		/// public propaty name  :  GoodsMakerCd
		/// <summary>メーカーコードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   メーカーコードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 GoodsMakerCd
		{
			get{return _goodsMakerCd;}
			set{_goodsMakerCd = value;}
		}

		/// public propaty name  :  GoodsNo
		/// <summary>品番プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   品番プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string GoodsNo
		{
			get{return _goodsNo;}
			set{_goodsNo = value;}
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
		/// 出荷商品優良対応表(対応品番用)抽出条件クラスコンストラクタ
		/// </summary>
		/// <returns>ShipGdsPrmListCndtnPartnerクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ShipGdsPrmListCndtnPartnerクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ShipGdsPrmListCndtnPartner2()
		{
		}

		/// <summary>
		/// 出荷商品優良対応表(対応品番用)抽出条件クラスコンストラクタ
		/// </summary>
		/// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
		/// <param name="sectionCode">拠点コード</param>
		/// <param name="st_AddUpYearMonth">開始対象年月</param>
		/// <param name="ed_AddUpYearMonth">終了対象年月</param>
		/// <param name="goodsMakerCd">メーカーコード</param>
		/// <param name="goodsNo">品番</param>
		/// <param name="enterpriseName">企業名称</param>
		/// <returns>ShipGdsPrmListCndtnPartnerクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ShipGdsPrmListCndtnPartnerクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
        public ShipGdsPrmListCndtnPartner2(string enterpriseCode, string sectionCode, DateTime st_AddUpYearMonth, DateTime ed_AddUpYearMonth, Int32 goodsMakerCd, string goodsNo, string enterpriseName)
		{
			this._enterpriseCode = enterpriseCode;
			this._sectionCode = sectionCode;
			this._st_AddUpYearMonth = st_AddUpYearMonth;
			this._ed_AddUpYearMonth = ed_AddUpYearMonth;
			this._goodsMakerCd = goodsMakerCd;
			this._goodsNo = goodsNo;
			this._enterpriseName = enterpriseName;

		}

		/// <summary>
		/// 出荷商品優良対応表(対応品番用)抽出条件クラス複製処理
		/// </summary>
		/// <returns>ShipGdsPrmListCndtnPartnerクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   自身の内容と等しいShipGdsPrmListCndtnPartnerクラスのインスタンスを返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
        public ShipGdsPrmListCndtnPartner2 Clone()
		{
			return new ShipGdsPrmListCndtnPartner2(this._enterpriseCode,this._sectionCode,this._st_AddUpYearMonth,this._ed_AddUpYearMonth,this._goodsMakerCd,this._goodsNo,this._enterpriseName);
		}

		/// <summary>
		/// 出荷商品優良対応表(対応品番用)抽出条件クラス比較処理
		/// </summary>
		/// <param name="target">比較対象のShipGdsPrmListCndtnPartnerクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ShipGdsPrmListCndtnPartnerクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
        public bool Equals(ShipGdsPrmListCndtnPartner2 target)
		{
			return ((this.EnterpriseCode == target.EnterpriseCode)
				 && (this.SectionCode == target.SectionCode)
				 && (this.St_AddUpYearMonth == target.St_AddUpYearMonth)
				 && (this.Ed_AddUpYearMonth == target.Ed_AddUpYearMonth)
				 && (this.GoodsMakerCd == target.GoodsMakerCd)
				 && (this.GoodsNo == target.GoodsNo)
				 && (this.EnterpriseName == target.EnterpriseName));
		}

		/// <summary>
		/// 出荷商品優良対応表(対応品番用)抽出条件クラス比較処理
		/// </summary>
		/// <param name="shipGdsPrmListCndtnPartner1">
		///                    比較するShipGdsPrmListCndtnPartnerクラスのインスタンス
		/// </param>
		/// <param name="shipGdsPrmListCndtnPartner2">比較するShipGdsPrmListCndtnPartnerクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ShipGdsPrmListCndtnPartnerクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
        public static bool Equals(ShipGdsPrmListCndtnPartner2 shipGdsPrmListCndtnPartner1, ShipGdsPrmListCndtnPartner2 shipGdsPrmListCndtnPartner2)
		{
			return ((shipGdsPrmListCndtnPartner1.EnterpriseCode == shipGdsPrmListCndtnPartner2.EnterpriseCode)
				 && (shipGdsPrmListCndtnPartner1.SectionCode == shipGdsPrmListCndtnPartner2.SectionCode)
				 && (shipGdsPrmListCndtnPartner1.St_AddUpYearMonth == shipGdsPrmListCndtnPartner2.St_AddUpYearMonth)
				 && (shipGdsPrmListCndtnPartner1.Ed_AddUpYearMonth == shipGdsPrmListCndtnPartner2.Ed_AddUpYearMonth)
				 && (shipGdsPrmListCndtnPartner1.GoodsMakerCd == shipGdsPrmListCndtnPartner2.GoodsMakerCd)
				 && (shipGdsPrmListCndtnPartner1.GoodsNo == shipGdsPrmListCndtnPartner2.GoodsNo)
				 && (shipGdsPrmListCndtnPartner1.EnterpriseName == shipGdsPrmListCndtnPartner2.EnterpriseName));
		}
		/// <summary>
		/// 出荷商品優良対応表(対応品番用)抽出条件クラス比較処理
		/// </summary>
		/// <param name="target">比較対象のShipGdsPrmListCndtnPartnerクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ShipGdsPrmListCndtnPartnerクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
        public ArrayList Compare(ShipGdsPrmListCndtnPartner2 target)
		{
			ArrayList resList = new ArrayList();
			if(this.EnterpriseCode != target.EnterpriseCode)resList.Add("EnterpriseCode");
			if(this.SectionCode != target.SectionCode)resList.Add("SectionCode");
			if(this.St_AddUpYearMonth != target.St_AddUpYearMonth)resList.Add("St_AddUpYearMonth");
			if(this.Ed_AddUpYearMonth != target.Ed_AddUpYearMonth)resList.Add("Ed_AddUpYearMonth");
			if(this.GoodsMakerCd != target.GoodsMakerCd)resList.Add("GoodsMakerCd");
			if(this.GoodsNo != target.GoodsNo)resList.Add("GoodsNo");
			if(this.EnterpriseName != target.EnterpriseName)resList.Add("EnterpriseName");

			return resList;
		}

		/// <summary>
		/// 出荷商品優良対応表(対応品番用)抽出条件クラス比較処理
		/// </summary>
		/// <param name="shipGdsPrmListCndtnPartner1">比較するShipGdsPrmListCndtnPartnerクラスのインスタンス</param>
		/// <param name="shipGdsPrmListCndtnPartner2">比較するShipGdsPrmListCndtnPartnerクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ShipGdsPrmListCndtnPartnerクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
        public static ArrayList Compare(ShipGdsPrmListCndtnPartner2 shipGdsPrmListCndtnPartner1, ShipGdsPrmListCndtnPartner2 shipGdsPrmListCndtnPartner2)
		{
			ArrayList resList = new ArrayList();
			if(shipGdsPrmListCndtnPartner1.EnterpriseCode != shipGdsPrmListCndtnPartner2.EnterpriseCode)resList.Add("EnterpriseCode");
			if(shipGdsPrmListCndtnPartner1.SectionCode != shipGdsPrmListCndtnPartner2.SectionCode)resList.Add("SectionCode");
			if(shipGdsPrmListCndtnPartner1.St_AddUpYearMonth != shipGdsPrmListCndtnPartner2.St_AddUpYearMonth)resList.Add("St_AddUpYearMonth");
			if(shipGdsPrmListCndtnPartner1.Ed_AddUpYearMonth != shipGdsPrmListCndtnPartner2.Ed_AddUpYearMonth)resList.Add("Ed_AddUpYearMonth");
			if(shipGdsPrmListCndtnPartner1.GoodsMakerCd != shipGdsPrmListCndtnPartner2.GoodsMakerCd)resList.Add("GoodsMakerCd");
			if(shipGdsPrmListCndtnPartner1.GoodsNo != shipGdsPrmListCndtnPartner2.GoodsNo)resList.Add("GoodsNo");
			if(shipGdsPrmListCndtnPartner1.EnterpriseName != shipGdsPrmListCndtnPartner2.EnterpriseName)resList.Add("EnterpriseName");

			return resList;
		}
	}
}
