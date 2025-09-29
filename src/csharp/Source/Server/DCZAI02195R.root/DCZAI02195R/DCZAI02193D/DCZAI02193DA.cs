using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   StockOverListCndtnWork
	/// <summary>
	///                      在庫過剰一覧表抽出条件クラスワーク
	/// </summary>
	/// <remarks>
	/// <br>note             :   在庫過剰一覧表抽出条件クラスワークヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2008/07/15  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class StockOverListCndtnWork
	{
		/// <summary>企業コード</summary>
		/// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
		private string _enterpriseCode = "";

		/// <summary>拠点コード</summary>
		/// <remarks>(配列)　全社指定は{""}</remarks>
		private string[] _sectionCodes;

		/// <summary>在庫登録日</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _stockCreateDate;

		/// <summary>在庫登録日指定区分</summary>
		/// <remarks>0:以前 1:以降</remarks>
		private Int32 _stockCreateDateDiv;

		/// <summary>開始未出荷経過月</summary>
		/// <remarks>YYYYMM</remarks>
		private DateTime _st_AddUpYearMonth;

		/// <summary>終了未出荷経過月</summary>
		/// <remarks>YYYYMM</remarks>
		private DateTime _ed_AddUpYearMonth;

		/// <summary>未出荷指定区分</summary>
		/// <remarks>0:指定無し 1:指定有り</remarks>
		private Int32 _noShipmentDiv;

		/// <summary>部品管理区分１</summary>
		private string[] _partsManagementDivide1;

		/// <summary>部品管理区分２</summary>
		private string[] _partsManagementDivide2;

		/// <summary>開始倉庫コード</summary>
		private string _st_WarehouseCode = "";

		/// <summary>終了倉庫コード</summary>
		private string _ed_WarehouseCode = "";

		/// <summary>開始仕入先コード</summary>
		private Int32 _st_SupplierCd;

		/// <summary>終了仕入先コード</summary>
		private Int32 _ed_SupplierCd;

		/// <summary>開始商品メーカーコード</summary>
		private Int32 _st_GoodsMakerCd;

		/// <summary>終了商品メーカーコード</summary>
		private Int32 _ed_GoodsMakerCd;

		/// <summary>開始棚番</summary>
		private string _st_WarehouseShelfNo = "";

		/// <summary>終了棚番</summary>
		private string _ed_WarehouseShelfNo = "";

		/// <summary>開始商品番号</summary>
		private string _st_GoodsNo = "";

		/// <summary>終了商品番号</summary>
		private string _ed_GoodsNo = "";

		/// <summary>開始商品区分</summary>
		private Int32 _st_EnterpriseGanreCode;

		/// <summary>終了商品区分</summary>
		private Int32 _ed_EnterpriseGanreCode;

		/// <summary>開始BL商品コード</summary>
		private Int32 _st_BLGoodsCode;

		/// <summary>終了BL商品コード</summary>
		private Int32 _ed_BLGoodsCode;


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
		/// <summary>拠点コードプロパティ</summary>
		/// <value>(配列)　全社指定は{""}</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   拠点コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string[] SectionCodes
		{
			get{return _sectionCodes;}
			set{_sectionCodes = value;}
		}

		/// public propaty name  :  StockCreateDate
		/// <summary>在庫登録日プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   在庫登録日プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime StockCreateDate
		{
			get{return _stockCreateDate;}
			set{_stockCreateDate = value;}
		}

		/// public propaty name  :  StockCreateDateDiv
		/// <summary>在庫登録日指定区分プロパティ</summary>
		/// <value>0:以前 1:以降</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   在庫登録日指定区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 StockCreateDateDiv
		{
			get{return _stockCreateDateDiv;}
			set{_stockCreateDateDiv = value;}
		}

		/// public propaty name  :  St_AddUpYearMonth
		/// <summary>開始未出荷経過月プロパティ</summary>
		/// <value>YYYYMM</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始未出荷経過月プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime St_AddUpYearMonth
		{
			get{return _st_AddUpYearMonth;}
			set{_st_AddUpYearMonth = value;}
		}

		/// public propaty name  :  Ed_AddUpYearMonth
		/// <summary>終了未出荷経過月プロパティ</summary>
		/// <value>YYYYMM</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了未出荷経過月プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime Ed_AddUpYearMonth
		{
			get{return _ed_AddUpYearMonth;}
			set{_ed_AddUpYearMonth = value;}
		}

		/// public propaty name  :  NoShipmentDiv
		/// <summary>未出荷指定区分プロパティ</summary>
		/// <value>0:指定無し 1:指定有り</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   未出荷指定区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 NoShipmentDiv
		{
			get{return _noShipmentDiv;}
			set{_noShipmentDiv = value;}
		}

		/// public propaty name  :  PartsManagementDivide1
		/// <summary>部品管理区分１プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   部品管理区分１プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string[] PartsManagementDivide1
		{
			get{return _partsManagementDivide1;}
			set{_partsManagementDivide1 = value;}
		}

		/// public propaty name  :  PartsManagementDivide2
		/// <summary>部品管理区分２プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   部品管理区分２プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string[] PartsManagementDivide2
		{
			get{return _partsManagementDivide2;}
			set{_partsManagementDivide2 = value;}
		}

		/// public propaty name  :  St_WarehouseCode
		/// <summary>開始倉庫コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始倉庫コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string St_WarehouseCode
		{
			get{return _st_WarehouseCode;}
			set{_st_WarehouseCode = value;}
		}

		/// public propaty name  :  Ed_WarehouseCode
		/// <summary>終了倉庫コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了倉庫コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string Ed_WarehouseCode
		{
			get{return _ed_WarehouseCode;}
			set{_ed_WarehouseCode = value;}
		}

		/// public propaty name  :  St_SupplierCd
		/// <summary>開始仕入先コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始仕入先コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 St_SupplierCd
		{
			get{return _st_SupplierCd;}
			set{_st_SupplierCd = value;}
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
			get{return _ed_SupplierCd;}
			set{_ed_SupplierCd = value;}
		}

		/// public propaty name  :  St_GoodsMakerCd
		/// <summary>開始商品メーカーコードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始商品メーカーコードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 St_GoodsMakerCd
		{
			get{return _st_GoodsMakerCd;}
			set{_st_GoodsMakerCd = value;}
		}

		/// public propaty name  :  Ed_GoodsMakerCd
		/// <summary>終了商品メーカーコードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了商品メーカーコードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 Ed_GoodsMakerCd
		{
			get{return _ed_GoodsMakerCd;}
			set{_ed_GoodsMakerCd = value;}
		}

		/// public propaty name  :  St_WarehouseShelfNo
		/// <summary>開始棚番プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始棚番プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string St_WarehouseShelfNo
		{
			get{return _st_WarehouseShelfNo;}
			set{_st_WarehouseShelfNo = value;}
		}

		/// public propaty name  :  Ed_WarehouseShelfNo
		/// <summary>終了棚番プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了棚番プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string Ed_WarehouseShelfNo
		{
			get{return _ed_WarehouseShelfNo;}
			set{_ed_WarehouseShelfNo = value;}
		}

		/// public propaty name  :  St_GoodsNo
		/// <summary>開始商品番号プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始商品番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string St_GoodsNo
		{
			get{return _st_GoodsNo;}
			set{_st_GoodsNo = value;}
		}

		/// public propaty name  :  Ed_GoodsNo
		/// <summary>終了商品番号プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了商品番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string Ed_GoodsNo
		{
			get{return _ed_GoodsNo;}
			set{_ed_GoodsNo = value;}
		}

		/// public propaty name  :  St_EnterpriseGanreCode
		/// <summary>開始商品区分プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始商品区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 St_EnterpriseGanreCode
		{
			get{return _st_EnterpriseGanreCode;}
			set{_st_EnterpriseGanreCode = value;}
		}

		/// public propaty name  :  Ed_EnterpriseGanreCode
		/// <summary>終了商品区分プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了商品区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 Ed_EnterpriseGanreCode
		{
			get{return _ed_EnterpriseGanreCode;}
			set{_ed_EnterpriseGanreCode = value;}
		}

		/// public propaty name  :  St_BLGoodsCode
		/// <summary>開始BL商品コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始BL商品コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 St_BLGoodsCode
		{
			get{return _st_BLGoodsCode;}
			set{_st_BLGoodsCode = value;}
		}

		/// public propaty name  :  Ed_BLGoodsCode
		/// <summary>終了BL商品コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了BL商品コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 Ed_BLGoodsCode
		{
			get{return _ed_BLGoodsCode;}
			set{_ed_BLGoodsCode = value;}
		}


		/// <summary>
		/// 在庫過剰一覧表抽出条件クラスワークコンストラクタ
		/// </summary>
		/// <returns>StockOverListCndtnWorkクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   StockOverListCndtnWorkクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public StockOverListCndtnWork()
		{
		}

	}
}