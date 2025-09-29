// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
/*
using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
	/// public class name:   StockEachWarehouse
	/// <summary>
	///                      在庫マスタ(倉庫毎)
	/// </summary>
	/// <remarks>
	/// <br>note             :   在庫マスタ(倉庫毎)ヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2007/07/05  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	public class StockEachWarehouse
	{
		/// <summary>作成日時</summary>
		/// <remarks>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</remarks>
		private DateTime _createDateTime;

		/// <summary>更新日時</summary>
		/// <remarks>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</remarks>
		private DateTime _updateDateTime;

		/// <summary>企業コード</summary>
		/// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
		private string _enterpriseCode = "";

		/// <summary>GUID</summary>
		/// <remarks>共通ファイルヘッダ</remarks>
		private Guid _fileHeaderGuid;

		/// <summary>更新従業員コード</summary>
		/// <remarks>共通ファイルヘッダ</remarks>
		private string _updEmployeeCode = "";

		/// <summary>更新アセンブリID1</summary>
		/// <remarks>共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）</remarks>
		private string _updAssemblyId1 = "";

		/// <summary>更新アセンブリID2</summary>
		/// <remarks>共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）</remarks>
		private string _updAssemblyId2 = "";

		/// <summary>論理削除区分</summary>
		/// <remarks>共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除)</remarks>
		private Int32 _logicalDeleteCode;

		/// <summary>拠点コード</summary>
		private string _sectionCode = "";

		/// <summary>メーカーコード</summary>
		/// <remarks>1～899:提供分, 900～ユーザー登録</remarks>
		private Int32 _goodsMakerCd;

		/// <summary>商品コード</summary>
		private string _goodsCode = "";

		/// <summary>商品名称</summary>
		private string _goodsName = "";

		/// <summary>仕入単価</summary>
		private Int64 _stockUnitPrice;

		/// <summary>仕入在庫数</summary>
		/// <remarks>受託数を含まない在庫数（自社在庫）</remarks>
		private Double _supplierStock;

		/// <summary>受託数</summary>
		/// <remarks>受託している在庫数（他社在庫）</remarks>
		private Double _trustCount;

		/// <summary>予約数</summary>
		/// <remarks>予約している数量（予約入力で加算）</remarks>
		private Int32 _reservedCount;

		/// <summary>引当在庫数</summary>
		/// <remarks>予約、見積時に引当在庫数を加算</remarks>
		private Double _allowStockCnt;

		/// <summary>受注数</summary>
		private Double _acpOdrCount;

		/// <summary>発注数</summary>
		private Double _salesOrderCount;

		/// <summary>仕入在庫分委託数</summary>
		/// <remarks>委託している在庫数（自社在庫）</remarks>
		private Double _entrustCnt;

		/// <summary>受託分委託数</summary>
		/// <remarks>委託している在庫数（受託在庫分）</remarks>
		private Double _trustEntrustCnt;

		/// <summary>売切数</summary>
		private Double _soldCnt;

		/// <summary>移動中仕入在庫数</summary>
		/// <remarks>在庫移動後、かつ移動先が入荷する前までの間に有効値が入る。</remarks>
		private Double _movingSupliStock;

		/// <summary>移動中受託在庫数</summary>
		/// <remarks>　　〃</remarks>
		private Double _movingTrustStock;

		/// <summary>出荷可能数</summary>
		/// <remarks>出荷可能数＝仕入在庫数＋受託在庫数－（仕入在庫分委託数＋受託分委託数）－（移動中仕入在庫数＋移動中受託在庫数）－引当在庫数</remarks>
		private Double _shipmentPosCnt;

		/// <summary>在庫保有総額</summary>
		/// <remarks>値引含む</remarks>
		private Int64 _stockTotalPrice;

		/// <summary>製番管理区分</summary>
		/// <remarks>0:無,1:有</remarks>
		private Int32 _prdNumMngDiv;

		/// <summary>最終仕入年月日</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _lastStockDate;

		/// <summary>最終売上日</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _lastSalesDate;

		/// <summary>最終棚卸更新日</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _lastInventoryUpdate;

		/// <summary>機種コード</summary>
		private string _cellphoneModelCode = "";

		/// <summary>機種名称</summary>
		private string _cellphoneModelName = "";

		/// <summary>キャリアコード</summary>
		/// <remarks>1～899:提供分,900～:ユーザー登録</remarks>
		private Int32 _carrierCode;

		/// <summary>キャリア名称</summary>
		private string _carrierName = "";

		/// <summary>メーカー名称</summary>
		private string _makerName = "";

		/// <summary>系統色コード</summary>
		private Int32 _systematicColorCd;

		/// <summary>系統色名称</summary>
		private string _systematicColorNm = "";

		/// <summary>商品区分グループコード</summary>
		/// <remarks>旧：商品大分類コード</remarks>
		private string _largeGoodsGanreCode = "";

		/// <summary>商品区分コード</summary>
		/// <remarks>旧：商品中分類コード</remarks>
		private string _mediumGoodsGanreCode = "";

		/// <summary>最低在庫数</summary>
		private Double _minimumStockCnt;

		/// <summary>最高在庫数</summary>
		private Double _maximumStockCnt;

		/// <summary>基準発注数</summary>
		private Double _nmlSalOdrCount;

		/// <summary>発注単位</summary>
		/// <remarks>発注する単位の数量（１０個、２０個単位等）</remarks>
		private Int32 _salOdrLot;

		/// <summary>倉庫コード</summary>
		private string _warehouseCode = "";

		/// <summary>倉庫名称</summary>
		private string _warehouseName = "";

		/// <summary>企業名称</summary>
		private string _enterpriseName = "";

		/// <summary>更新従業員名称</summary>
		private string _updEmployeeName = "";

		/// <summary>商品区分グループ名称</summary>
		/// <remarks>旧：商品大分類名称</remarks>
		private string _largeGoodsGanreName = "";

		/// <summary>商品区分名称</summary>
		/// <remarks>旧：商品中分類名称</remarks>
		private string _mediumGoodsGanreName = "";


		/// public propaty name  :  CreateDateTime
		/// <summary>作成日時プロパティ</summary>
		/// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   作成日時プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime CreateDateTime
		{
			get{return _createDateTime;}
			set{_createDateTime = value;}
		}

		/// public propaty name  :  CreateDateTimeJpFormal
		/// <summary>作成日時 和暦プロパティ</summary>
		/// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   作成日時 和暦プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string CreateDateTimeJpFormal
		{
			get{return TDateTime.DateTimeToString("GGYYMMDD", _createDateTime);}
			set{}
		}

		/// public propaty name  :  CreateDateTimeJpInFormal
		/// <summary>作成日時 和暦(略)プロパティ</summary>
		/// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   作成日時 和暦(略)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string CreateDateTimeJpInFormal
		{
			get{return TDateTime.DateTimeToString("ggYY/MM/DD", _createDateTime);}
			set{}
		}

		/// public propaty name  :  CreateDateTimeAdFormal
		/// <summary>作成日時 西暦プロパティ</summary>
		/// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   作成日時 西暦プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string CreateDateTimeAdFormal
		{
			get{return TDateTime.DateTimeToString("YYYY/MM/DD", _createDateTime);}
			set{}
		}

		/// public propaty name  :  CreateDateTimeAdInFormal
		/// <summary>作成日時 西暦(略)プロパティ</summary>
		/// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   作成日時 西暦(略)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string CreateDateTimeAdInFormal
		{
			get{return TDateTime.DateTimeToString("YY/MM/DD", _createDateTime);}
			set{}
		}

		/// public propaty name  :  UpdateDateTime
		/// <summary>更新日時プロパティ</summary>
		/// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   更新日時プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime UpdateDateTime
		{
			get{return _updateDateTime;}
			set{_updateDateTime = value;}
		}

		/// public propaty name  :  UpdateDateTimeJpFormal
		/// <summary>更新日時 和暦プロパティ</summary>
		/// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   更新日時 和暦プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string UpdateDateTimeJpFormal
		{
			get{return TDateTime.DateTimeToString("GGYYMMDD", _updateDateTime);}
			set{}
		}

		/// public propaty name  :  UpdateDateTimeJpInFormal
		/// <summary>更新日時 和暦(略)プロパティ</summary>
		/// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   更新日時 和暦(略)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string UpdateDateTimeJpInFormal
		{
			get{return TDateTime.DateTimeToString("ggYY/MM/DD", _updateDateTime);}
			set{}
		}

		/// public propaty name  :  UpdateDateTimeAdFormal
		/// <summary>更新日時 西暦プロパティ</summary>
		/// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   更新日時 西暦プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string UpdateDateTimeAdFormal
		{
			get{return TDateTime.DateTimeToString("YYYY/MM/DD", _updateDateTime);}
			set{}
		}

		/// public propaty name  :  UpdateDateTimeAdInFormal
		/// <summary>更新日時 西暦(略)プロパティ</summary>
		/// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   更新日時 西暦(略)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string UpdateDateTimeAdInFormal
		{
			get{return TDateTime.DateTimeToString("YY/MM/DD", _updateDateTime);}
			set{}
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

		/// public propaty name  :  FileHeaderGuid
		/// <summary>GUIDプロパティ</summary>
		/// <value>共通ファイルヘッダ</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   GUIDプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Guid FileHeaderGuid
		{
			get{return _fileHeaderGuid;}
			set{_fileHeaderGuid = value;}
		}

		/// public propaty name  :  UpdEmployeeCode
		/// <summary>更新従業員コードプロパティ</summary>
		/// <value>共通ファイルヘッダ</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   更新従業員コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string UpdEmployeeCode
		{
			get{return _updEmployeeCode;}
			set{_updEmployeeCode = value;}
		}

		/// public propaty name  :  UpdAssemblyId1
		/// <summary>更新アセンブリID1プロパティ</summary>
		/// <value>共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   更新アセンブリID1プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string UpdAssemblyId1
		{
			get{return _updAssemblyId1;}
			set{_updAssemblyId1 = value;}
		}

		/// public propaty name  :  UpdAssemblyId2
		/// <summary>更新アセンブリID2プロパティ</summary>
		/// <value>共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   更新アセンブリID2プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string UpdAssemblyId2
		{
			get{return _updAssemblyId2;}
			set{_updAssemblyId2 = value;}
		}

		/// public propaty name  :  LogicalDeleteCode
		/// <summary>論理削除区分プロパティ</summary>
		/// <value>共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   論理削除区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 LogicalDeleteCode
		{
			get{return _logicalDeleteCode;}
			set{_logicalDeleteCode = value;}
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

		/// public propaty name  :  GoodsMakerCd
		/// <summary>メーカーコードプロパティ</summary>
		/// <value>1～899:提供分, 900～ユーザー登録</value>
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

		/// public propaty name  :  GoodsCode
		/// <summary>商品コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   商品コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string GoodsCode
		{
			get{return _goodsCode;}
			set{_goodsCode = value;}
		}

		/// public propaty name  :  GoodsName
		/// <summary>商品名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   商品名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string GoodsName
		{
			get{return _goodsName;}
			set{_goodsName = value;}
		}

		/// public propaty name  :  StockUnitPrice
		/// <summary>仕入単価プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入単価プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 StockUnitPrice
		{
			get{return _stockUnitPrice;}
			set{_stockUnitPrice = value;}
		}

		/// public propaty name  :  SupplierStock
		/// <summary>仕入在庫数プロパティ</summary>
		/// <value>受託数を含まない在庫数（自社在庫）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入在庫数プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double SupplierStock
		{
			get{return _supplierStock;}
			set{_supplierStock = value;}
		}

		/// public propaty name  :  TrustCount
		/// <summary>受託数プロパティ</summary>
		/// <value>受託している在庫数（他社在庫）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   受託数プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double TrustCount
		{
			get{return _trustCount;}
			set{_trustCount = value;}
		}

		/// public propaty name  :  ReservedCount
		/// <summary>予約数プロパティ</summary>
		/// <value>予約している数量（予約入力で加算）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   予約数プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 ReservedCount
		{
			get{return _reservedCount;}
			set{_reservedCount = value;}
		}

		/// public propaty name  :  AllowStockCnt
		/// <summary>引当在庫数プロパティ</summary>
		/// <value>予約、見積時に引当在庫数を加算</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   引当在庫数プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double AllowStockCnt
		{
			get{return _allowStockCnt;}
			set{_allowStockCnt = value;}
		}

		/// public propaty name  :  AcpOdrCount
		/// <summary>受注数プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   受注数プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double AcpOdrCount
		{
			get{return _acpOdrCount;}
			set{_acpOdrCount = value;}
		}

		/// public propaty name  :  SalesOrderCount
		/// <summary>発注数プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   発注数プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double SalesOrderCount
		{
			get{return _salesOrderCount;}
			set{_salesOrderCount = value;}
		}

		/// public propaty name  :  EntrustCnt
		/// <summary>仕入在庫分委託数プロパティ</summary>
		/// <value>委託している在庫数（自社在庫）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入在庫分委託数プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double EntrustCnt
		{
			get{return _entrustCnt;}
			set{_entrustCnt = value;}
		}

		/// public propaty name  :  TrustEntrustCnt
		/// <summary>受託分委託数プロパティ</summary>
		/// <value>委託している在庫数（受託在庫分）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   受託分委託数プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double TrustEntrustCnt
		{
			get{return _trustEntrustCnt;}
			set{_trustEntrustCnt = value;}
		}

		/// public propaty name  :  SoldCnt
		/// <summary>売切数プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   売切数プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double SoldCnt
		{
			get{return _soldCnt;}
			set{_soldCnt = value;}
		}

		/// public propaty name  :  MovingSupliStock
		/// <summary>移動中仕入在庫数プロパティ</summary>
		/// <value>在庫移動後、かつ移動先が入荷する前までの間に有効値が入る。</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   移動中仕入在庫数プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double MovingSupliStock
		{
			get{return _movingSupliStock;}
			set{_movingSupliStock = value;}
		}

		/// public propaty name  :  MovingTrustStock
		/// <summary>移動中受託在庫数プロパティ</summary>
		/// <value>　　〃</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   移動中受託在庫数プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double MovingTrustStock
		{
			get{return _movingTrustStock;}
			set{_movingTrustStock = value;}
		}

		/// public propaty name  :  ShipmentPosCnt
		/// <summary>出荷可能数プロパティ</summary>
		/// <value>出荷可能数＝仕入在庫数＋受託在庫数－（仕入在庫分委託数＋受託分委託数）－（移動中仕入在庫数＋移動中受託在庫数）－引当在庫数</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   出荷可能数プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double ShipmentPosCnt
		{
			get{return _shipmentPosCnt;}
			set{_shipmentPosCnt = value;}
		}

		/// public propaty name  :  StockTotalPrice
		/// <summary>在庫保有総額プロパティ</summary>
		/// <value>値引含む</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   在庫保有総額プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 StockTotalPrice
		{
			get{return _stockTotalPrice;}
			set{_stockTotalPrice = value;}
		}

		/// public propaty name  :  PrdNumMngDiv
		/// <summary>製番管理区分プロパティ</summary>
		/// <value>0:無,1:有</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   製番管理区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 PrdNumMngDiv
		{
			get{return _prdNumMngDiv;}
			set{_prdNumMngDiv = value;}
		}

		/// public propaty name  :  LastStockDate
		/// <summary>最終仕入年月日プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   最終仕入年月日プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime LastStockDate
		{
			get{return _lastStockDate;}
			set{_lastStockDate = value;}
		}

		/// public propaty name  :  LastStockDateJpFormal
		/// <summary>最終仕入年月日 和暦プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   最終仕入年月日 和暦プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string LastStockDateJpFormal
		{
			get{return TDateTime.DateTimeToString("GGYYMMDD", _lastStockDate);}
			set{}
		}

		/// public propaty name  :  LastStockDateJpInFormal
		/// <summary>最終仕入年月日 和暦(略)プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   最終仕入年月日 和暦(略)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string LastStockDateJpInFormal
		{
			get{return TDateTime.DateTimeToString("ggYY/MM/DD", _lastStockDate);}
			set{}
		}

		/// public propaty name  :  LastStockDateAdFormal
		/// <summary>最終仕入年月日 西暦プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   最終仕入年月日 西暦プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string LastStockDateAdFormal
		{
			get{return TDateTime.DateTimeToString("YYYY/MM/DD", _lastStockDate);}
			set{}
		}

		/// public propaty name  :  LastStockDateAdInFormal
		/// <summary>最終仕入年月日 西暦(略)プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   最終仕入年月日 西暦(略)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string LastStockDateAdInFormal
		{
			get{return TDateTime.DateTimeToString("YY/MM/DD", _lastStockDate);}
			set{}
		}

		/// public propaty name  :  LastSalesDate
		/// <summary>最終売上日プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   最終売上日プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime LastSalesDate
		{
			get{return _lastSalesDate;}
			set{_lastSalesDate = value;}
		}

		/// public propaty name  :  LastSalesDateJpFormal
		/// <summary>最終売上日 和暦プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   最終売上日 和暦プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string LastSalesDateJpFormal
		{
			get{return TDateTime.DateTimeToString("GGYYMMDD", _lastSalesDate);}
			set{}
		}

		/// public propaty name  :  LastSalesDateJpInFormal
		/// <summary>最終売上日 和暦(略)プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   最終売上日 和暦(略)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string LastSalesDateJpInFormal
		{
			get{return TDateTime.DateTimeToString("ggYY/MM/DD", _lastSalesDate);}
			set{}
		}

		/// public propaty name  :  LastSalesDateAdFormal
		/// <summary>最終売上日 西暦プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   最終売上日 西暦プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string LastSalesDateAdFormal
		{
			get{return TDateTime.DateTimeToString("YYYY/MM/DD", _lastSalesDate);}
			set{}
		}

		/// public propaty name  :  LastSalesDateAdInFormal
		/// <summary>最終売上日 西暦(略)プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   最終売上日 西暦(略)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string LastSalesDateAdInFormal
		{
			get{return TDateTime.DateTimeToString("YY/MM/DD", _lastSalesDate);}
			set{}
		}

		/// public propaty name  :  LastInventoryUpdate
		/// <summary>最終棚卸更新日プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   最終棚卸更新日プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime LastInventoryUpdate
		{
			get{return _lastInventoryUpdate;}
			set{_lastInventoryUpdate = value;}
		}

		/// public propaty name  :  LastInventoryUpdateJpFormal
		/// <summary>最終棚卸更新日 和暦プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   最終棚卸更新日 和暦プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string LastInventoryUpdateJpFormal
		{
			get{return TDateTime.DateTimeToString("GGYYMMDD", _lastInventoryUpdate);}
			set{}
		}

		/// public propaty name  :  LastInventoryUpdateJpInFormal
		/// <summary>最終棚卸更新日 和暦(略)プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   最終棚卸更新日 和暦(略)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string LastInventoryUpdateJpInFormal
		{
			get{return TDateTime.DateTimeToString("ggYY/MM/DD", _lastInventoryUpdate);}
			set{}
		}

		/// public propaty name  :  LastInventoryUpdateAdFormal
		/// <summary>最終棚卸更新日 西暦プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   最終棚卸更新日 西暦プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string LastInventoryUpdateAdFormal
		{
			get{return TDateTime.DateTimeToString("YYYY/MM/DD", _lastInventoryUpdate);}
			set{}
		}

		/// public propaty name  :  LastInventoryUpdateAdInFormal
		/// <summary>最終棚卸更新日 西暦(略)プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   最終棚卸更新日 西暦(略)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string LastInventoryUpdateAdInFormal
		{
			get{return TDateTime.DateTimeToString("YY/MM/DD", _lastInventoryUpdate);}
			set{}
		}

		/// public propaty name  :  CellphoneModelCode
		/// <summary>機種コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   機種コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string CellphoneModelCode
		{
			get{return _cellphoneModelCode;}
			set{_cellphoneModelCode = value;}
		}

		/// public propaty name  :  CellphoneModelName
		/// <summary>機種名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   機種名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string CellphoneModelName
		{
			get{return _cellphoneModelName;}
			set{_cellphoneModelName = value;}
		}

		/// public propaty name  :  CarrierCode
		/// <summary>キャリアコードプロパティ</summary>
		/// <value>1～899:提供分,900～:ユーザー登録</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   キャリアコードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 CarrierCode
		{
			get{return _carrierCode;}
			set{_carrierCode = value;}
		}

		/// public propaty name  :  CarrierName
		/// <summary>キャリア名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   キャリア名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string CarrierName
		{
			get{return _carrierName;}
			set{_carrierName = value;}
		}

		/// public propaty name  :  MakerName
		/// <summary>メーカー名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   メーカー名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string MakerName
		{
			get{return _makerName;}
			set{_makerName = value;}
		}

		/// public propaty name  :  SystematicColorCd
		/// <summary>系統色コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   系統色コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SystematicColorCd
		{
			get{return _systematicColorCd;}
			set{_systematicColorCd = value;}
		}

		/// public propaty name  :  SystematicColorNm
		/// <summary>系統色名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   系統色名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string SystematicColorNm
		{
			get{return _systematicColorNm;}
			set{_systematicColorNm = value;}
		}

		/// public propaty name  :  LargeGoodsGanreCode
		/// <summary>商品区分グループコードプロパティ</summary>
		/// <value>旧：商品大分類コード</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   商品区分グループコードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string LargeGoodsGanreCode
		{
			get{return _largeGoodsGanreCode;}
			set{_largeGoodsGanreCode = value;}
		}

		/// public propaty name  :  MediumGoodsGanreCode
		/// <summary>商品区分コードプロパティ</summary>
		/// <value>旧：商品中分類コード</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   商品区分コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string MediumGoodsGanreCode
		{
			get{return _mediumGoodsGanreCode;}
			set{_mediumGoodsGanreCode = value;}
		}

		/// public propaty name  :  MinimumStockCnt
		/// <summary>最低在庫数プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   最低在庫数プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double MinimumStockCnt
		{
			get{return _minimumStockCnt;}
			set{_minimumStockCnt = value;}
		}

		/// public propaty name  :  MaximumStockCnt
		/// <summary>最高在庫数プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   最高在庫数プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double MaximumStockCnt
		{
			get{return _maximumStockCnt;}
			set{_maximumStockCnt = value;}
		}

		/// public propaty name  :  NmlSalOdrCount
		/// <summary>基準発注数プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   基準発注数プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double NmlSalOdrCount
		{
			get{return _nmlSalOdrCount;}
			set{_nmlSalOdrCount = value;}
		}

		/// public propaty name  :  SalOdrLot
		/// <summary>発注単位プロパティ</summary>
		/// <value>発注する単位の数量（１０個、２０個単位等）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   発注単位プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SalOdrLot
		{
			get{return _salOdrLot;}
			set{_salOdrLot = value;}
		}

		/// public propaty name  :  WarehouseCode
		/// <summary>倉庫コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   倉庫コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string WarehouseCode
		{
			get{return _warehouseCode;}
			set{_warehouseCode = value;}
		}

		/// public propaty name  :  WarehouseName
		/// <summary>倉庫名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   倉庫名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string WarehouseName
		{
			get{return _warehouseName;}
			set{_warehouseName = value;}
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

		/// public propaty name  :  UpdEmployeeName
		/// <summary>更新従業員名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   更新従業員名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string UpdEmployeeName
		{
			get{return _updEmployeeName;}
			set{_updEmployeeName = value;}
		}

		/// public propaty name  :  LargeGoodsGanreName
		/// <summary>商品区分グループ名称プロパティ</summary>
		/// <value>旧：商品大分類名称</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   商品区分グループ名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string LargeGoodsGanreName
		{
			get{return _largeGoodsGanreName;}
			set{_largeGoodsGanreName = value;}
		}

		/// public propaty name  :  MediumGoodsGanreName
		/// <summary>商品区分名称プロパティ</summary>
		/// <value>旧：商品中分類名称</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   商品区分名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string MediumGoodsGanreName
		{
			get{return _mediumGoodsGanreName;}
			set{_mediumGoodsGanreName = value;}
		}


		/// <summary>
		/// 在庫マスタ(倉庫毎)コンストラクタ
		/// </summary>
		/// <returns>StockEachWarehouseクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   StockEachWarehouseクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public StockEachWarehouse()
		{
		}

		/// <summary>
		/// 在庫マスタ(倉庫毎)コンストラクタ
		/// </summary>
		/// <param name="createDateTime">作成日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
		/// <param name="updateDateTime">更新日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
		/// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
		/// <param name="fileHeaderGuid">GUID(共通ファイルヘッダ)</param>
		/// <param name="updEmployeeCode">更新従業員コード(共通ファイルヘッダ)</param>
		/// <param name="updAssemblyId1">更新アセンブリID1(共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）)</param>
		/// <param name="updAssemblyId2">更新アセンブリID2(共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）)</param>
		/// <param name="logicalDeleteCode">論理削除区分(共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除))</param>
		/// <param name="sectionCode">拠点コード</param>
		/// <param name="GoodsMakerCd">メーカーコード(1～899:提供分, 900～ユーザー登録)</param>
		/// <param name="goodsCode">商品コード</param>
		/// <param name="goodsName">商品名称</param>
		/// <param name="stockUnitPrice">仕入単価</param>
		/// <param name="supplierStock">仕入在庫数(受託数を含まない在庫数（自社在庫）)</param>
		/// <param name="trustCount">受託数(受託している在庫数（他社在庫）)</param>
		/// <param name="reservedCount">予約数(予約している数量（予約入力で加算）)</param>
		/// <param name="allowStockCnt">引当在庫数(予約、見積時に引当在庫数を加算)</param>
		/// <param name="acpOdrCount">受注数</param>
		/// <param name="salesOrderCount">発注数</param>
		/// <param name="entrustCnt">仕入在庫分委託数(委託している在庫数（自社在庫）)</param>
		/// <param name="trustEntrustCnt">受託分委託数(委託している在庫数（受託在庫分）)</param>
		/// <param name="soldCnt">売切数</param>
		/// <param name="movingSupliStock">移動中仕入在庫数(在庫移動後、かつ移動先が入荷する前までの間に有効値が入る。)</param>
		/// <param name="movingTrustStock">移動中受託在庫数(　　〃)</param>
		/// <param name="shipmentPosCnt">出荷可能数(出荷可能数＝仕入在庫数＋受託在庫数－（仕入在庫分委託数＋受託分委託数）－（移動中仕入在庫数＋移動中受託在庫数）－引当在庫数)</param>
		/// <param name="stockTotalPrice">在庫保有総額(値引含む)</param>
		/// <param name="prdNumMngDiv">製番管理区分(0:無,1:有)</param>
		/// <param name="lastStockDate">最終仕入年月日(YYYYMMDD)</param>
		/// <param name="lastSalesDate">最終売上日(YYYYMMDD)</param>
		/// <param name="lastInventoryUpdate">最終棚卸更新日(YYYYMMDD)</param>
		/// <param name="cellphoneModelCode">機種コード</param>
		/// <param name="cellphoneModelName">機種名称</param>
		/// <param name="carrierCode">キャリアコード(1～899:提供分,900～:ユーザー登録)</param>
		/// <param name="carrierName">キャリア名称</param>
		/// <param name="makerName">メーカー名称</param>
		/// <param name="systematicColorCd">系統色コード</param>
		/// <param name="systematicColorNm">系統色名称</param>
		/// <param name="largeGoodsGanreCode">商品区分グループコード(旧：商品大分類コード)</param>
		/// <param name="mediumGoodsGanreCode">商品区分コード(旧：商品中分類コード)</param>
		/// <param name="minimumStockCnt">最低在庫数</param>
		/// <param name="maximumStockCnt">最高在庫数</param>
		/// <param name="nmlSalOdrCount">基準発注数</param>
		/// <param name="salOdrLot">発注単位(発注する単位の数量（１０個、２０個単位等）)</param>
		/// <param name="warehouseCode">倉庫コード</param>
		/// <param name="warehouseName">倉庫名称</param>
		/// <param name="enterpriseName">企業名称</param>
		/// <param name="updEmployeeName">更新従業員名称</param>
		/// <param name="largeGoodsGanreName">商品区分グループ名称(旧：商品大分類名称)</param>
		/// <param name="mediumGoodsGanreName">商品区分名称(旧：商品中分類名称)</param>
		/// <returns>StockEachWarehouseクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   StockEachWarehouseクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public StockEachWarehouse(DateTime createDateTime,DateTime updateDateTime,string enterpriseCode,Guid fileHeaderGuid,string updEmployeeCode,string updAssemblyId1,string updAssemblyId2,Int32 logicalDeleteCode,string sectionCode,Int32 GoodsMakerCd,string goodsCode,string goodsName,Int64 stockUnitPrice,Double supplierStock,Double trustCount,Int32 reservedCount,Double allowStockCnt,Double acpOdrCount,Double salesOrderCount,Double entrustCnt,Double trustEntrustCnt,Double soldCnt,Double movingSupliStock,Double movingTrustStock,Double shipmentPosCnt,Int64 stockTotalPrice,Int32 prdNumMngDiv,DateTime lastStockDate,DateTime lastSalesDate,DateTime lastInventoryUpdate,string cellphoneModelCode,string cellphoneModelName,Int32 carrierCode,string carrierName,string makerName,Int32 systematicColorCd,string systematicColorNm,string largeGoodsGanreCode,string mediumGoodsGanreCode,Double minimumStockCnt,Double maximumStockCnt,Double nmlSalOdrCount,Int32 salOdrLot,string warehouseCode,string warehouseName,string enterpriseName,string updEmployeeName,string largeGoodsGanreName,string mediumGoodsGanreName)
		{
			this.CreateDateTime = createDateTime;
			this.UpdateDateTime = updateDateTime;
			this._enterpriseCode = enterpriseCode;
			this._fileHeaderGuid = fileHeaderGuid;
			this._updEmployeeCode = updEmployeeCode;
			this._updAssemblyId1 = updAssemblyId1;
			this._updAssemblyId2 = updAssemblyId2;
			this._logicalDeleteCode = logicalDeleteCode;
			this._sectionCode = sectionCode;
			this._goodsMakerCd = GoodsMakerCd;
			this._goodsCode = goodsCode;
			this._goodsName = goodsName;
			this._stockUnitPrice = stockUnitPrice;
			this._supplierStock = supplierStock;
			this._trustCount = trustCount;
			this._reservedCount = reservedCount;
			this._allowStockCnt = allowStockCnt;
			this._acpOdrCount = acpOdrCount;
			this._salesOrderCount = salesOrderCount;
			this._entrustCnt = entrustCnt;
			this._trustEntrustCnt = trustEntrustCnt;
			this._soldCnt = soldCnt;
			this._movingSupliStock = movingSupliStock;
			this._movingTrustStock = movingTrustStock;
			this._shipmentPosCnt = shipmentPosCnt;
			this._stockTotalPrice = stockTotalPrice;
			this._prdNumMngDiv = prdNumMngDiv;
			this.LastStockDate = lastStockDate;
			this.LastSalesDate = lastSalesDate;
			this.LastInventoryUpdate = lastInventoryUpdate;
			this._cellphoneModelCode = cellphoneModelCode;
			this._cellphoneModelName = cellphoneModelName;
			this._carrierCode = carrierCode;
			this._carrierName = carrierName;
			this._makerName = makerName;
			this._systematicColorCd = systematicColorCd;
			this._systematicColorNm = systematicColorNm;
			this._largeGoodsGanreCode = largeGoodsGanreCode;
			this._mediumGoodsGanreCode = mediumGoodsGanreCode;
			this._minimumStockCnt = minimumStockCnt;
			this._maximumStockCnt = maximumStockCnt;
			this._nmlSalOdrCount = nmlSalOdrCount;
			this._salOdrLot = salOdrLot;
			this._warehouseCode = warehouseCode;
			this._warehouseName = warehouseName;
			this._enterpriseName = enterpriseName;
			this._updEmployeeName = updEmployeeName;
			this._largeGoodsGanreName = largeGoodsGanreName;
			this._mediumGoodsGanreName = mediumGoodsGanreName;

		}

		/// <summary>
		/// 在庫マスタ(倉庫毎)複製処理
		/// </summary>
		/// <returns>StockEachWarehouseクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   自身の内容と等しいStockEachWarehouseクラスのインスタンスを返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public StockEachWarehouse Clone()
		{
			return new StockEachWarehouse(this._createDateTime,this._updateDateTime,this._enterpriseCode,this._fileHeaderGuid,this._updEmployeeCode,this._updAssemblyId1,this._updAssemblyId2,this._logicalDeleteCode,this._sectionCode,this._goodsMakerCd,this._goodsCode,this._goodsName,this._stockUnitPrice,this._supplierStock,this._trustCount,this._reservedCount,this._allowStockCnt,this._acpOdrCount,this._salesOrderCount,this._entrustCnt,this._trustEntrustCnt,this._soldCnt,this._movingSupliStock,this._movingTrustStock,this._shipmentPosCnt,this._stockTotalPrice,this._prdNumMngDiv,this._lastStockDate,this._lastSalesDate,this._lastInventoryUpdate,this._cellphoneModelCode,this._cellphoneModelName,this._carrierCode,this._carrierName,this._makerName,this._systematicColorCd,this._systematicColorNm,this._largeGoodsGanreCode,this._mediumGoodsGanreCode,this._minimumStockCnt,this._maximumStockCnt,this._nmlSalOdrCount,this._salOdrLot,this._warehouseCode,this._warehouseName,this._enterpriseName,this._updEmployeeName,this._largeGoodsGanreName,this._mediumGoodsGanreName);
		}

		/// <summary>
		/// 在庫マスタ(倉庫毎)比較処理
		/// </summary>
		/// <param name="target">比較対象のStockEachWarehouseクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   StockEachWarehouseクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public bool Equals(StockEachWarehouse target)
		{
			return ((this.CreateDateTime == target.CreateDateTime)
				 && (this.UpdateDateTime == target.UpdateDateTime)
				 && (this.EnterpriseCode == target.EnterpriseCode)
				 && (this.FileHeaderGuid == target.FileHeaderGuid)
				 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
				 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
				 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
				 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
				 && (this.SectionCode == target.SectionCode)
				 && (this.GoodsMakerCd == target.GoodsMakerCd)
				 && (this.GoodsCode == target.GoodsCode)
				 && (this.GoodsName == target.GoodsName)
				 && (this.StockUnitPrice == target.StockUnitPrice)
				 && (this.SupplierStock == target.SupplierStock)
				 && (this.TrustCount == target.TrustCount)
				 && (this.ReservedCount == target.ReservedCount)
				 && (this.AllowStockCnt == target.AllowStockCnt)
				 && (this.AcpOdrCount == target.AcpOdrCount)
				 && (this.SalesOrderCount == target.SalesOrderCount)
				 && (this.EntrustCnt == target.EntrustCnt)
				 && (this.TrustEntrustCnt == target.TrustEntrustCnt)
				 && (this.SoldCnt == target.SoldCnt)
				 && (this.MovingSupliStock == target.MovingSupliStock)
				 && (this.MovingTrustStock == target.MovingTrustStock)
				 && (this.ShipmentPosCnt == target.ShipmentPosCnt)
				 && (this.StockTotalPrice == target.StockTotalPrice)
				 && (this.PrdNumMngDiv == target.PrdNumMngDiv)
				 && (this.LastStockDate == target.LastStockDate)
				 && (this.LastSalesDate == target.LastSalesDate)
				 && (this.LastInventoryUpdate == target.LastInventoryUpdate)
				 && (this.CellphoneModelCode == target.CellphoneModelCode)
				 && (this.CellphoneModelName == target.CellphoneModelName)
				 && (this.CarrierCode == target.CarrierCode)
				 && (this.CarrierName == target.CarrierName)
				 && (this.MakerName == target.MakerName)
				 && (this.SystematicColorCd == target.SystematicColorCd)
				 && (this.SystematicColorNm == target.SystematicColorNm)
				 && (this.LargeGoodsGanreCode == target.LargeGoodsGanreCode)
				 && (this.MediumGoodsGanreCode == target.MediumGoodsGanreCode)
				 && (this.MinimumStockCnt == target.MinimumStockCnt)
				 && (this.MaximumStockCnt == target.MaximumStockCnt)
				 && (this.NmlSalOdrCount == target.NmlSalOdrCount)
				 && (this.SalOdrLot == target.SalOdrLot)
				 && (this.WarehouseCode == target.WarehouseCode)
				 && (this.WarehouseName == target.WarehouseName)
				 && (this.EnterpriseName == target.EnterpriseName)
				 && (this.UpdEmployeeName == target.UpdEmployeeName)
				 && (this.LargeGoodsGanreName == target.LargeGoodsGanreName)
				 && (this.MediumGoodsGanreName == target.MediumGoodsGanreName));
		}

		/// <summary>
		/// 在庫マスタ(倉庫毎)比較処理
		/// </summary>
		/// <param name="stockEachWarehouse1">
		///                    比較するStockEachWarehouseクラスのインスタンス
		/// </param>
		/// <param name="stockEachWarehouse2">比較するStockEachWarehouseクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   StockEachWarehouseクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static bool Equals(StockEachWarehouse stockEachWarehouse1, StockEachWarehouse stockEachWarehouse2)
		{
			return ((stockEachWarehouse1.CreateDateTime == stockEachWarehouse2.CreateDateTime)
				 && (stockEachWarehouse1.UpdateDateTime == stockEachWarehouse2.UpdateDateTime)
				 && (stockEachWarehouse1.EnterpriseCode == stockEachWarehouse2.EnterpriseCode)
				 && (stockEachWarehouse1.FileHeaderGuid == stockEachWarehouse2.FileHeaderGuid)
				 && (stockEachWarehouse1.UpdEmployeeCode == stockEachWarehouse2.UpdEmployeeCode)
				 && (stockEachWarehouse1.UpdAssemblyId1 == stockEachWarehouse2.UpdAssemblyId1)
				 && (stockEachWarehouse1.UpdAssemblyId2 == stockEachWarehouse2.UpdAssemblyId2)
				 && (stockEachWarehouse1.LogicalDeleteCode == stockEachWarehouse2.LogicalDeleteCode)
				 && (stockEachWarehouse1.SectionCode == stockEachWarehouse2.SectionCode)
				 && (stockEachWarehouse1.GoodsMakerCd == stockEachWarehouse2.GoodsMakerCd)
				 && (stockEachWarehouse1.GoodsCode == stockEachWarehouse2.GoodsCode)
				 && (stockEachWarehouse1.GoodsName == stockEachWarehouse2.GoodsName)
				 && (stockEachWarehouse1.StockUnitPrice == stockEachWarehouse2.StockUnitPrice)
				 && (stockEachWarehouse1.SupplierStock == stockEachWarehouse2.SupplierStock)
				 && (stockEachWarehouse1.TrustCount == stockEachWarehouse2.TrustCount)
				 && (stockEachWarehouse1.ReservedCount == stockEachWarehouse2.ReservedCount)
				 && (stockEachWarehouse1.AllowStockCnt == stockEachWarehouse2.AllowStockCnt)
				 && (stockEachWarehouse1.AcpOdrCount == stockEachWarehouse2.AcpOdrCount)
				 && (stockEachWarehouse1.SalesOrderCount == stockEachWarehouse2.SalesOrderCount)
				 && (stockEachWarehouse1.EntrustCnt == stockEachWarehouse2.EntrustCnt)
				 && (stockEachWarehouse1.TrustEntrustCnt == stockEachWarehouse2.TrustEntrustCnt)
				 && (stockEachWarehouse1.SoldCnt == stockEachWarehouse2.SoldCnt)
				 && (stockEachWarehouse1.MovingSupliStock == stockEachWarehouse2.MovingSupliStock)
				 && (stockEachWarehouse1.MovingTrustStock == stockEachWarehouse2.MovingTrustStock)
				 && (stockEachWarehouse1.ShipmentPosCnt == stockEachWarehouse2.ShipmentPosCnt)
				 && (stockEachWarehouse1.StockTotalPrice == stockEachWarehouse2.StockTotalPrice)
				 && (stockEachWarehouse1.PrdNumMngDiv == stockEachWarehouse2.PrdNumMngDiv)
				 && (stockEachWarehouse1.LastStockDate == stockEachWarehouse2.LastStockDate)
				 && (stockEachWarehouse1.LastSalesDate == stockEachWarehouse2.LastSalesDate)
				 && (stockEachWarehouse1.LastInventoryUpdate == stockEachWarehouse2.LastInventoryUpdate)
				 && (stockEachWarehouse1.CellphoneModelCode == stockEachWarehouse2.CellphoneModelCode)
				 && (stockEachWarehouse1.CellphoneModelName == stockEachWarehouse2.CellphoneModelName)
				 && (stockEachWarehouse1.CarrierCode == stockEachWarehouse2.CarrierCode)
				 && (stockEachWarehouse1.CarrierName == stockEachWarehouse2.CarrierName)
				 && (stockEachWarehouse1.MakerName == stockEachWarehouse2.MakerName)
				 && (stockEachWarehouse1.SystematicColorCd == stockEachWarehouse2.SystematicColorCd)
				 && (stockEachWarehouse1.SystematicColorNm == stockEachWarehouse2.SystematicColorNm)
				 && (stockEachWarehouse1.LargeGoodsGanreCode == stockEachWarehouse2.LargeGoodsGanreCode)
				 && (stockEachWarehouse1.MediumGoodsGanreCode == stockEachWarehouse2.MediumGoodsGanreCode)
				 && (stockEachWarehouse1.MinimumStockCnt == stockEachWarehouse2.MinimumStockCnt)
				 && (stockEachWarehouse1.MaximumStockCnt == stockEachWarehouse2.MaximumStockCnt)
				 && (stockEachWarehouse1.NmlSalOdrCount == stockEachWarehouse2.NmlSalOdrCount)
				 && (stockEachWarehouse1.SalOdrLot == stockEachWarehouse2.SalOdrLot)
				 && (stockEachWarehouse1.WarehouseCode == stockEachWarehouse2.WarehouseCode)
				 && (stockEachWarehouse1.WarehouseName == stockEachWarehouse2.WarehouseName)
				 && (stockEachWarehouse1.EnterpriseName == stockEachWarehouse2.EnterpriseName)
				 && (stockEachWarehouse1.UpdEmployeeName == stockEachWarehouse2.UpdEmployeeName)
				 && (stockEachWarehouse1.LargeGoodsGanreName == stockEachWarehouse2.LargeGoodsGanreName)
				 && (stockEachWarehouse1.MediumGoodsGanreName == stockEachWarehouse2.MediumGoodsGanreName));
		}
		/// <summary>
		/// 在庫マスタ(倉庫毎)比較処理
		/// </summary>
		/// <param name="target">比較対象のStockEachWarehouseクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   StockEachWarehouseクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ArrayList Compare(StockEachWarehouse target)
		{
			ArrayList resList = new ArrayList();
			if(this.CreateDateTime != target.CreateDateTime)resList.Add("CreateDateTime");
			if(this.UpdateDateTime != target.UpdateDateTime)resList.Add("UpdateDateTime");
			if(this.EnterpriseCode != target.EnterpriseCode)resList.Add("EnterpriseCode");
			if(this.FileHeaderGuid != target.FileHeaderGuid)resList.Add("FileHeaderGuid");
			if(this.UpdEmployeeCode != target.UpdEmployeeCode)resList.Add("UpdEmployeeCode");
			if(this.UpdAssemblyId1 != target.UpdAssemblyId1)resList.Add("UpdAssemblyId1");
			if(this.UpdAssemblyId2 != target.UpdAssemblyId2)resList.Add("UpdAssemblyId2");
			if(this.LogicalDeleteCode != target.LogicalDeleteCode)resList.Add("LogicalDeleteCode");
			if(this.SectionCode != target.SectionCode)resList.Add("SectionCode");
			if(this.GoodsMakerCd != target.GoodsMakerCd)resList.Add("GoodsMakerCd");
			if(this.GoodsCode != target.GoodsCode)resList.Add("GoodsCode");
			if(this.GoodsName != target.GoodsName)resList.Add("GoodsName");
			if(this.StockUnitPrice != target.StockUnitPrice)resList.Add("StockUnitPrice");
			if(this.SupplierStock != target.SupplierStock)resList.Add("SupplierStock");
			if(this.TrustCount != target.TrustCount)resList.Add("TrustCount");
			if(this.ReservedCount != target.ReservedCount)resList.Add("ReservedCount");
			if(this.AllowStockCnt != target.AllowStockCnt)resList.Add("AllowStockCnt");
			if(this.AcpOdrCount != target.AcpOdrCount)resList.Add("AcpOdrCount");
			if(this.SalesOrderCount != target.SalesOrderCount)resList.Add("SalesOrderCount");
			if(this.EntrustCnt != target.EntrustCnt)resList.Add("EntrustCnt");
			if(this.TrustEntrustCnt != target.TrustEntrustCnt)resList.Add("TrustEntrustCnt");
			if(this.SoldCnt != target.SoldCnt)resList.Add("SoldCnt");
			if(this.MovingSupliStock != target.MovingSupliStock)resList.Add("MovingSupliStock");
			if(this.MovingTrustStock != target.MovingTrustStock)resList.Add("MovingTrustStock");
			if(this.ShipmentPosCnt != target.ShipmentPosCnt)resList.Add("ShipmentPosCnt");
			if(this.StockTotalPrice != target.StockTotalPrice)resList.Add("StockTotalPrice");
			if(this.PrdNumMngDiv != target.PrdNumMngDiv)resList.Add("PrdNumMngDiv");
			if(this.LastStockDate != target.LastStockDate)resList.Add("LastStockDate");
			if(this.LastSalesDate != target.LastSalesDate)resList.Add("LastSalesDate");
			if(this.LastInventoryUpdate != target.LastInventoryUpdate)resList.Add("LastInventoryUpdate");
			if(this.CellphoneModelCode != target.CellphoneModelCode)resList.Add("CellphoneModelCode");
			if(this.CellphoneModelName != target.CellphoneModelName)resList.Add("CellphoneModelName");
			if(this.CarrierCode != target.CarrierCode)resList.Add("CarrierCode");
			if(this.CarrierName != target.CarrierName)resList.Add("CarrierName");
			if(this.MakerName != target.MakerName)resList.Add("MakerName");
			if(this.SystematicColorCd != target.SystematicColorCd)resList.Add("SystematicColorCd");
			if(this.SystematicColorNm != target.SystematicColorNm)resList.Add("SystematicColorNm");
			if(this.LargeGoodsGanreCode != target.LargeGoodsGanreCode)resList.Add("LargeGoodsGanreCode");
			if(this.MediumGoodsGanreCode != target.MediumGoodsGanreCode)resList.Add("MediumGoodsGanreCode");
			if(this.MinimumStockCnt != target.MinimumStockCnt)resList.Add("MinimumStockCnt");
			if(this.MaximumStockCnt != target.MaximumStockCnt)resList.Add("MaximumStockCnt");
			if(this.NmlSalOdrCount != target.NmlSalOdrCount)resList.Add("NmlSalOdrCount");
			if(this.SalOdrLot != target.SalOdrLot)resList.Add("SalOdrLot");
			if(this.WarehouseCode != target.WarehouseCode)resList.Add("WarehouseCode");
			if(this.WarehouseName != target.WarehouseName)resList.Add("WarehouseName");
			if(this.EnterpriseName != target.EnterpriseName)resList.Add("EnterpriseName");
			if(this.UpdEmployeeName != target.UpdEmployeeName)resList.Add("UpdEmployeeName");
			if(this.LargeGoodsGanreName != target.LargeGoodsGanreName)resList.Add("LargeGoodsGanreName");
			if(this.MediumGoodsGanreName != target.MediumGoodsGanreName)resList.Add("MediumGoodsGanreName");

			return resList;
		}

		/// <summary>
		/// 在庫マスタ(倉庫毎)比較処理
		/// </summary>
		/// <param name="stockEachWarehouse1">比較するStockEachWarehouseクラスのインスタンス</param>
		/// <param name="stockEachWarehouse2">比較するStockEachWarehouseクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   StockEachWarehouseクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static ArrayList Compare(StockEachWarehouse stockEachWarehouse1, StockEachWarehouse stockEachWarehouse2)
		{
			ArrayList resList = new ArrayList();
			if(stockEachWarehouse1.CreateDateTime != stockEachWarehouse2.CreateDateTime)resList.Add("CreateDateTime");
			if(stockEachWarehouse1.UpdateDateTime != stockEachWarehouse2.UpdateDateTime)resList.Add("UpdateDateTime");
			if(stockEachWarehouse1.EnterpriseCode != stockEachWarehouse2.EnterpriseCode)resList.Add("EnterpriseCode");
			if(stockEachWarehouse1.FileHeaderGuid != stockEachWarehouse2.FileHeaderGuid)resList.Add("FileHeaderGuid");
			if(stockEachWarehouse1.UpdEmployeeCode != stockEachWarehouse2.UpdEmployeeCode)resList.Add("UpdEmployeeCode");
			if(stockEachWarehouse1.UpdAssemblyId1 != stockEachWarehouse2.UpdAssemblyId1)resList.Add("UpdAssemblyId1");
			if(stockEachWarehouse1.UpdAssemblyId2 != stockEachWarehouse2.UpdAssemblyId2)resList.Add("UpdAssemblyId2");
			if(stockEachWarehouse1.LogicalDeleteCode != stockEachWarehouse2.LogicalDeleteCode)resList.Add("LogicalDeleteCode");
			if(stockEachWarehouse1.SectionCode != stockEachWarehouse2.SectionCode)resList.Add("SectionCode");
			if(stockEachWarehouse1.GoodsMakerCd != stockEachWarehouse2.GoodsMakerCd)resList.Add("GoodsMakerCd");
			if(stockEachWarehouse1.GoodsCode != stockEachWarehouse2.GoodsCode)resList.Add("GoodsCode");
			if(stockEachWarehouse1.GoodsName != stockEachWarehouse2.GoodsName)resList.Add("GoodsName");
			if(stockEachWarehouse1.StockUnitPrice != stockEachWarehouse2.StockUnitPrice)resList.Add("StockUnitPrice");
			if(stockEachWarehouse1.SupplierStock != stockEachWarehouse2.SupplierStock)resList.Add("SupplierStock");
			if(stockEachWarehouse1.TrustCount != stockEachWarehouse2.TrustCount)resList.Add("TrustCount");
			if(stockEachWarehouse1.ReservedCount != stockEachWarehouse2.ReservedCount)resList.Add("ReservedCount");
			if(stockEachWarehouse1.AllowStockCnt != stockEachWarehouse2.AllowStockCnt)resList.Add("AllowStockCnt");
			if(stockEachWarehouse1.AcpOdrCount != stockEachWarehouse2.AcpOdrCount)resList.Add("AcpOdrCount");
			if(stockEachWarehouse1.SalesOrderCount != stockEachWarehouse2.SalesOrderCount)resList.Add("SalesOrderCount");
			if(stockEachWarehouse1.EntrustCnt != stockEachWarehouse2.EntrustCnt)resList.Add("EntrustCnt");
			if(stockEachWarehouse1.TrustEntrustCnt != stockEachWarehouse2.TrustEntrustCnt)resList.Add("TrustEntrustCnt");
			if(stockEachWarehouse1.SoldCnt != stockEachWarehouse2.SoldCnt)resList.Add("SoldCnt");
			if(stockEachWarehouse1.MovingSupliStock != stockEachWarehouse2.MovingSupliStock)resList.Add("MovingSupliStock");
			if(stockEachWarehouse1.MovingTrustStock != stockEachWarehouse2.MovingTrustStock)resList.Add("MovingTrustStock");
			if(stockEachWarehouse1.ShipmentPosCnt != stockEachWarehouse2.ShipmentPosCnt)resList.Add("ShipmentPosCnt");
			if(stockEachWarehouse1.StockTotalPrice != stockEachWarehouse2.StockTotalPrice)resList.Add("StockTotalPrice");
			if(stockEachWarehouse1.PrdNumMngDiv != stockEachWarehouse2.PrdNumMngDiv)resList.Add("PrdNumMngDiv");
			if(stockEachWarehouse1.LastStockDate != stockEachWarehouse2.LastStockDate)resList.Add("LastStockDate");
			if(stockEachWarehouse1.LastSalesDate != stockEachWarehouse2.LastSalesDate)resList.Add("LastSalesDate");
			if(stockEachWarehouse1.LastInventoryUpdate != stockEachWarehouse2.LastInventoryUpdate)resList.Add("LastInventoryUpdate");
			if(stockEachWarehouse1.CellphoneModelCode != stockEachWarehouse2.CellphoneModelCode)resList.Add("CellphoneModelCode");
			if(stockEachWarehouse1.CellphoneModelName != stockEachWarehouse2.CellphoneModelName)resList.Add("CellphoneModelName");
			if(stockEachWarehouse1.CarrierCode != stockEachWarehouse2.CarrierCode)resList.Add("CarrierCode");
			if(stockEachWarehouse1.CarrierName != stockEachWarehouse2.CarrierName)resList.Add("CarrierName");
			if(stockEachWarehouse1.MakerName != stockEachWarehouse2.MakerName)resList.Add("MakerName");
			if(stockEachWarehouse1.SystematicColorCd != stockEachWarehouse2.SystematicColorCd)resList.Add("SystematicColorCd");
			if(stockEachWarehouse1.SystematicColorNm != stockEachWarehouse2.SystematicColorNm)resList.Add("SystematicColorNm");
			if(stockEachWarehouse1.LargeGoodsGanreCode != stockEachWarehouse2.LargeGoodsGanreCode)resList.Add("LargeGoodsGanreCode");
			if(stockEachWarehouse1.MediumGoodsGanreCode != stockEachWarehouse2.MediumGoodsGanreCode)resList.Add("MediumGoodsGanreCode");
			if(stockEachWarehouse1.MinimumStockCnt != stockEachWarehouse2.MinimumStockCnt)resList.Add("MinimumStockCnt");
			if(stockEachWarehouse1.MaximumStockCnt != stockEachWarehouse2.MaximumStockCnt)resList.Add("MaximumStockCnt");
			if(stockEachWarehouse1.NmlSalOdrCount != stockEachWarehouse2.NmlSalOdrCount)resList.Add("NmlSalOdrCount");
			if(stockEachWarehouse1.SalOdrLot != stockEachWarehouse2.SalOdrLot)resList.Add("SalOdrLot");
			if(stockEachWarehouse1.WarehouseCode != stockEachWarehouse2.WarehouseCode)resList.Add("WarehouseCode");
			if(stockEachWarehouse1.WarehouseName != stockEachWarehouse2.WarehouseName)resList.Add("WarehouseName");
			if(stockEachWarehouse1.EnterpriseName != stockEachWarehouse2.EnterpriseName)resList.Add("EnterpriseName");
			if(stockEachWarehouse1.UpdEmployeeName != stockEachWarehouse2.UpdEmployeeName)resList.Add("UpdEmployeeName");
			if(stockEachWarehouse1.LargeGoodsGanreName != stockEachWarehouse2.LargeGoodsGanreName)resList.Add("LargeGoodsGanreName");
			if(stockEachWarehouse1.MediumGoodsGanreName != stockEachWarehouse2.MediumGoodsGanreName)resList.Add("MediumGoodsGanreName");

			return resList;
		}
	}
}
*/
// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki