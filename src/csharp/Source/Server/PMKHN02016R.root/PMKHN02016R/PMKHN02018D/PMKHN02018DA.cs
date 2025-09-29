using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   RatePrtReqWork
	/// <summary>
	///                      掛率印刷抽出条件クラスワーク
	/// </summary>
	/// <remarks>
	/// <br>note             :   掛率印刷抽出条件クラスワークヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2008/10/17  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class RatePrtReqWork
	{
		/// <summary>企業コード</summary>
		/// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
		private string _enterpriseCode = "";

		/// <summary>拠点コード</summary>
		/// <remarks>(配列)　全社指定はnull</remarks>
		private string[] _sectionCode;

		/// <summary>単価種類</summary>
		/// <remarks>1:売価設定,2:原価設定,3:価格設定,4:作業原価,5:作業売価</remarks>
		private Int32 _unitPriceKind;

		/// <summary>設定方法</summary>
		/// <remarks>1:単品設定 0:グループ設定</remarks>
		private Int32 _rateMngGoodsCdKind;

		/// <summary>開始掛率設定区分</summary>
		/// <remarks>A1,A2等</remarks>
		private string _rateSettingDivideSt = "";

		/// <summary>終了掛率設定区分</summary>
		/// <remarks>A1,A2等</remarks>
		private string _rateSettingDivideEd = "";

		/// <summary>開始得意先コード</summary>
		private Int32 _customerCodeSt;

		/// <summary>終了得意先コード</summary>
		private Int32 _customerCodeEd;

		/// <summary>開始得意先掛率グループコード</summary>
		private Int32 _custRateGrpCodeSt;

		/// <summary>終了得意先掛率グループコード</summary>
		private Int32 _custRateGrpCodeEd;

		/// <summary>開始仕入先コード</summary>
		private Int32 _supplierCdSt;

		/// <summary>終了仕入先コード</summary>
		private Int32 _supplierCdEd;

		/// <summary>開始商品メーカーコード</summary>
		private Int32 _goodsMakerCdSt;

		/// <summary>終了商品メーカーコード</summary>
		private Int32 _goodsMakerCdEd;

		/// <summary>開始商品掛率ランク</summary>
		/// <remarks>層別</remarks>
		private string _goodsRateRankSt = "";

		/// <summary>終了商品掛率ランク</summary>
		/// <remarks>層別</remarks>
		private string _goodsRateRankEd = "";

		/// <summary>開始商品掛率グループコード</summary>
		private Int32 _goodsRateGrpCodeSt;

		/// <summary>終了商品掛率グループコード</summary>
		private Int32 _goodsRateGrpCodeEd;

		/// <summary>開始BLグループコード</summary>
		private Int32 _bLGroupCodeSt;

		/// <summary>終了BLグループコード</summary>
		private Int32 _bLGroupCodeEd;

		/// <summary>開始BL商品コード</summary>
		private Int32 _bLGoodsCodeSt;

		/// <summary>終了BL商品コード</summary>
		private Int32 _bLGoodsCodeEd;

		/// <summary>開始商品番号</summary>
		private string _goodsNoSt = "";

		/// <summary>終了商品番号</summary>
		private string _goodsNoEd = "";


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
		public string[] SectionCode
		{
			get{return _sectionCode;}
			set{_sectionCode = value;}
		}

		/// public propaty name  :  UnitPriceKind
		/// <summary>単価種類プロパティ</summary>
		/// <value>1:売価設定,2:原価設定,3:価格設定,4:作業原価,5:作業売価</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   単価種類プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 UnitPriceKind
		{
			get{return _unitPriceKind;}
			set{_unitPriceKind = value;}
		}

		/// public propaty name  :  RateMngGoodsCdKind
		/// <summary>設定方法プロパティ</summary>
		/// <value>1:単品設定 0:グループ設定</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   設定方法プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 RateMngGoodsCdKind
		{
			get{return _rateMngGoodsCdKind;}
			set{_rateMngGoodsCdKind = value;}
		}

		/// public propaty name  :  RateSettingDivideSt
		/// <summary>開始掛率設定区分プロパティ</summary>
		/// <value>A1,A2等</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始掛率設定区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string RateSettingDivideSt
		{
			get{return _rateSettingDivideSt;}
			set{_rateSettingDivideSt = value;}
		}

		/// public propaty name  :  RateSettingDivideEd
		/// <summary>終了掛率設定区分プロパティ</summary>
		/// <value>A1,A2等</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了掛率設定区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string RateSettingDivideEd
		{
			get{return _rateSettingDivideEd;}
			set{_rateSettingDivideEd = value;}
		}

		/// public propaty name  :  CustomerCodeSt
		/// <summary>開始得意先コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始得意先コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 CustomerCodeSt
		{
			get{return _customerCodeSt;}
			set{_customerCodeSt = value;}
		}

		/// public propaty name  :  CustomerCodeEd
		/// <summary>終了得意先コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了得意先コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 CustomerCodeEd
		{
			get{return _customerCodeEd;}
			set{_customerCodeEd = value;}
		}

		/// public propaty name  :  CustRateGrpCodeSt
		/// <summary>開始得意先掛率グループコードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始得意先掛率グループコードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 CustRateGrpCodeSt
		{
			get{return _custRateGrpCodeSt;}
			set{_custRateGrpCodeSt = value;}
		}

		/// public propaty name  :  CustRateGrpCodeEd
		/// <summary>終了得意先掛率グループコードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了得意先掛率グループコードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 CustRateGrpCodeEd
		{
			get{return _custRateGrpCodeEd;}
			set{_custRateGrpCodeEd = value;}
		}

		/// public propaty name  :  SupplierCdSt
		/// <summary>開始仕入先コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始仕入先コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SupplierCdSt
		{
			get{return _supplierCdSt;}
			set{_supplierCdSt = value;}
		}

		/// public propaty name  :  SupplierCdEd
		/// <summary>終了仕入先コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了仕入先コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SupplierCdEd
		{
			get{return _supplierCdEd;}
			set{_supplierCdEd = value;}
		}

		/// public propaty name  :  GoodsMakerCdSt
		/// <summary>開始商品メーカーコードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始商品メーカーコードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 GoodsMakerCdSt
		{
			get{return _goodsMakerCdSt;}
			set{_goodsMakerCdSt = value;}
		}

		/// public propaty name  :  GoodsMakerCdEd
		/// <summary>終了商品メーカーコードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了商品メーカーコードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 GoodsMakerCdEd
		{
			get{return _goodsMakerCdEd;}
			set{_goodsMakerCdEd = value;}
		}

		/// public propaty name  :  GoodsRateRankSt
		/// <summary>開始商品掛率ランクプロパティ</summary>
		/// <value>層別</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始商品掛率ランクプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string GoodsRateRankSt
		{
			get{return _goodsRateRankSt;}
			set{_goodsRateRankSt = value;}
		}

		/// public propaty name  :  GoodsRateRankEd
		/// <summary>終了商品掛率ランクプロパティ</summary>
		/// <value>層別</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了商品掛率ランクプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string GoodsRateRankEd
		{
			get{return _goodsRateRankEd;}
			set{_goodsRateRankEd = value;}
		}

		/// public propaty name  :  GoodsRateGrpCodeSt
		/// <summary>開始商品掛率グループコードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始商品掛率グループコードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 GoodsRateGrpCodeSt
		{
			get{return _goodsRateGrpCodeSt;}
			set{_goodsRateGrpCodeSt = value;}
		}

		/// public propaty name  :  GoodsRateGrpCodeEd
		/// <summary>終了商品掛率グループコードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了商品掛率グループコードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 GoodsRateGrpCodeEd
		{
			get{return _goodsRateGrpCodeEd;}
			set{_goodsRateGrpCodeEd = value;}
		}

		/// public propaty name  :  BLGroupCodeSt
		/// <summary>開始BLグループコードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始BLグループコードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 BLGroupCodeSt
		{
			get{return _bLGroupCodeSt;}
			set{_bLGroupCodeSt = value;}
		}

		/// public propaty name  :  BLGroupCodeEd
		/// <summary>終了BLグループコードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了BLグループコードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 BLGroupCodeEd
		{
			get{return _bLGroupCodeEd;}
			set{_bLGroupCodeEd = value;}
		}

		/// public propaty name  :  BLGoodsCodeSt
		/// <summary>開始BL商品コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始BL商品コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 BLGoodsCodeSt
		{
			get{return _bLGoodsCodeSt;}
			set{_bLGoodsCodeSt = value;}
		}

		/// public propaty name  :  BLGoodsCodeEd
		/// <summary>終了BL商品コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了BL商品コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 BLGoodsCodeEd
		{
			get{return _bLGoodsCodeEd;}
			set{_bLGoodsCodeEd = value;}
		}

		/// public propaty name  :  GoodsNoSt
		/// <summary>開始商品番号プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始商品番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string GoodsNoSt
		{
			get{return _goodsNoSt;}
			set{_goodsNoSt = value;}
		}

		/// public propaty name  :  GoodsNoEd
		/// <summary>終了商品番号プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了商品番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string GoodsNoEd
		{
			get{return _goodsNoEd;}
			set{_goodsNoEd = value;}
		}


		/// <summary>
		/// 掛率印刷抽出条件クラスワークコンストラクタ
		/// </summary>
		/// <returns>RatePrtReqWorkクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   RatePrtReqWorkクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public RatePrtReqWork()
		{
		}

	}
}
