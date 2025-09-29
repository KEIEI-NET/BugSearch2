using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   StockListCndtnWork
	/// <summary>
	///                      在庫一覧表抽出条件クラスワーク
	/// </summary>
	/// <remarks>
	/// <br>note             :   在庫一覧表抽出条件クラスワークヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2008/07/09  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class StockListCndtnWork
	{
		/// <summary>企業コード</summary>
		/// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
		private string _enterpriseCode = "";

		/// <summary>拠点コード</summary>
		/// <remarks>(配列)　全社指定は{""}</remarks>
		private string[] _depositStockSecCodeList;

		/// <summary>在庫登録日</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _stockCreateDate;

		/// <summary>在庫登録日検索フラグ</summary>
		/// <remarks>0:以前 1:以降</remarks>
		private Int32 _stockCreateDateFlg;

		/// <summary>開始出荷可能数</summary>
		private Double _st_ShipmentPosCnt;

		/// <summary>終了出荷可能数</summary>
		private Double _ed_ShipmentPosCnt;

		/// <summary>部品管理区分１</summary>
		private string[] _partsManagementDivide1;

		/// <summary>部品管理区分２</summary>
		private string[] _partsManagementDivide2;

		/// <summary>開始最終仕入年月日</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _st_LastStockDate;

		/// <summary>終了最終仕入年月日</summary>
		/// <remarks>YYYYMMDD</remarks>
        private DateTime _ed_LastStockDate;

		/// <summary>開始倉庫コード</summary>
		private string _st_WarehouseCode = "";

		/// <summary>終了倉庫コード</summary>
		private string _ed_WarehouseCode = "";

		/// <summary>開始在庫発注先コード</summary>
		private Int32 _st_StockSupplierCode;

		/// <summary>終了在庫発注先コード</summary>
		private Int32 _ed_StockSupplierCode;

		/// <summary>開始倉庫棚番</summary>
		private string _st_WarehouseShelfNo = "";

		/// <summary>終了倉庫棚番</summary>
		private string _ed_WarehouseShelfNo = "";

		/// <summary>開始メーカーコード</summary>
		private Int32 _st_GoodsMakerCd;

		/// <summary>終了メーカーコード</summary>
		private Int32 _ed_GoodsMakerCd;

		/// <summary>開始BL商品コード</summary>
		private Int32 _st_BLGoodsCode;

		/// <summary>終了BL商品コード</summary>
		private Int32 _ed_BLGoodsCode;

		/// <summary>開始商品番号</summary>
		private string _st_GoodsNo = "";

		/// <summary>終了商品番号</summary>
		private string _ed_GoodsNo = "";


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

		/// public propaty name  :  DepositStockSecCodeList
		/// <summary>拠点コードプロパティ</summary>
		/// <value>(配列)　全社指定は{""}</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   拠点コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string[] DepositStockSecCodeList
		{
			get{return _depositStockSecCodeList;}
			set{_depositStockSecCodeList = value;}
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

		/// public propaty name  :  StockCreateDateFlg
		/// <summary>在庫登録日検索フラグプロパティ</summary>
		/// <value>0:以前 1:以降</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   在庫登録日検索フラグプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 StockCreateDateFlg
		{
			get{return _stockCreateDateFlg;}
			set{_stockCreateDateFlg = value;}
		}

		/// public propaty name  :  St_ShipmentPosCnt
		/// <summary>開始出荷可能数プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始出荷可能数プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double St_ShipmentPosCnt
		{
			get{return _st_ShipmentPosCnt;}
			set{_st_ShipmentPosCnt = value;}
		}

		/// public propaty name  :  Ed_ShipmentPosCnt
		/// <summary>終了出荷可能数プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了出荷可能数プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double Ed_ShipmentPosCnt
		{
			get{return _ed_ShipmentPosCnt;}
			set{_ed_ShipmentPosCnt = value;}
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

		/// public propaty name  :  St_LastStockDate
		/// <summary>開始最終仕入年月日プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始最終仕入年月日プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
        public DateTime St_LastStockDate
		{
			get{return _st_LastStockDate;}
			set{_st_LastStockDate = value;}
		}

		/// public propaty name  :  Ed_LastStockDate
		/// <summary>終了最終仕入年月日プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了最終仕入年月日プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
        public DateTime Ed_LastStockDate
		{
			get{return _ed_LastStockDate;}
			set{_ed_LastStockDate = value;}
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

		/// public propaty name  :  St_StockSupplierCode
		/// <summary>開始在庫発注先コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始在庫発注先コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 St_StockSupplierCode
		{
			get{return _st_StockSupplierCode;}
			set{_st_StockSupplierCode = value;}
		}

		/// public propaty name  :  Ed_StockSupplierCode
		/// <summary>終了在庫発注先コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了在庫発注先コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 Ed_StockSupplierCode
		{
			get{return _ed_StockSupplierCode;}
			set{_ed_StockSupplierCode = value;}
		}

		/// public propaty name  :  St_WarehouseShelfNo
		/// <summary>開始倉庫棚番プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始倉庫棚番プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string St_WarehouseShelfNo
		{
			get{return _st_WarehouseShelfNo;}
			set{_st_WarehouseShelfNo = value;}
		}

		/// public propaty name  :  Ed_WarehouseShelfNo
		/// <summary>終了倉庫棚番プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了倉庫棚番プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string Ed_WarehouseShelfNo
		{
			get{return _ed_WarehouseShelfNo;}
			set{_ed_WarehouseShelfNo = value;}
		}

		/// public propaty name  :  St_GoodsMakerCd
		/// <summary>開始メーカーコードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始メーカーコードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 St_GoodsMakerCd
		{
			get{return _st_GoodsMakerCd;}
			set{_st_GoodsMakerCd = value;}
		}

		/// public propaty name  :  Ed_GoodsMakerCd
		/// <summary>終了メーカーコードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了メーカーコードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 Ed_GoodsMakerCd
		{
			get{return _ed_GoodsMakerCd;}
			set{_ed_GoodsMakerCd = value;}
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


		/// <summary>
		/// 在庫一覧表抽出条件クラスワークコンストラクタ
		/// </summary>
		/// <returns>StockListCndtnWorkクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   StockListCndtnWorkクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public StockListCndtnWork()
		{
		}

	}
}




