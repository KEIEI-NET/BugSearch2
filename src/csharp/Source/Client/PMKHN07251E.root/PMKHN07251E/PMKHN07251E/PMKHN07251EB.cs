//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 在庫マスタ（エクスポート）
// プログラム概要   : 在庫マスタのｴｸｽﾎﾟｰﾄ処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 李占川
// 作 成 日  2009/05/14  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//

using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
	/// public class name:   Stock
	/// <summary>
	///                      在庫マスタ
	/// </summary>
	/// <remarks>
	/// <br>note             :   在庫マスタヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   2008/3/19</br>
	/// <br>Genarated Date   :   2009/05/14  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   2008/7/8  杉村</br>
	/// <br>                 :   出荷可能数の補足修正</br>
	/// </remarks>
	public class StockSetExp
	{
		/// <summary>拠点コード</summary>
		private string _sectionCode = "";

		/// <summary>倉庫コード</summary>
		private string _warehouseCode = "";

		/// <summary>商品メーカーコード</summary>
		private Int32 _goodsMakerCd;

		/// <summary>商品番号</summary>
		private string _goodsNo = "";

		/// <summary>仕入単価（税抜,浮動）</summary>
		/// <remarks>※在庫評価単価</remarks>
		private Double _stockUnitPriceFl;

		/// <summary>仕入在庫数</summary>
		/// <remarks>受託数を含まない在庫数（自社在庫）</remarks>
		private Double _supplierStock;

		/// <summary>受注数</summary>
		private Double _acpOdrCount;

		/// <summary>M/O発注数</summary>
		private Double _monthOrderCount;

		/// <summary>発注数</summary>
		private Double _salesOrderCount;

		/// <summary>在庫区分</summary>
		/// <remarks>0:自社,1:受託</remarks>
		private Int32 _stockDiv;

		/// <summary>移動中仕入在庫数</summary>
		/// <remarks>在庫移動後、かつ移動先が入荷する前までの間に有効値が入る。</remarks>
		private Double _movingSupliStock;

		/// <summary>出荷可能数</summary>
		/// <remarks>出荷可能数＝仕入在庫数 ＋ 入荷数（未計上）－ 出荷数（未計上）－受注数 － 移動中仕入在庫数</remarks>
		private Double _shipmentPosCnt;

		/// <summary>在庫保有総額</summary>
		private Int64 _stockTotalPrice;

		/// <summary>最終仕入年月日</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _lastStockDate;

		/// <summary>最終売上日</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _lastSalesDate;

		/// <summary>最終棚卸更新日</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _lastInventoryUpdate;

		/// <summary>最低在庫数</summary>
		private Double _minimumStockCnt;

		/// <summary>最高在庫数</summary>
		private Double _maximumStockCnt;

		/// <summary>基準発注数</summary>
		private Double _nmlSalOdrCount;

		/// <summary>発注単位</summary>
		/// <remarks>発注する単位の数量（１０個、２０個単位等）</remarks>
		private Int32 _salesOrderUnit;

		/// <summary>在庫発注先コード</summary>
		/// <remarks>在庫発注する場合の発注先（商品の発注先とは別管理）</remarks>
		private Int32 _stockSupplierCode;

		/// <summary>ハイフン無商品番号</summary>
		private string _goodsNoNoneHyphen = "";

		/// <summary>倉庫棚番</summary>
		private string _warehouseShelfNo = "";

		/// <summary>重複棚番１</summary>
		private string _duplicationShelfNo1 = "";

		/// <summary>重複棚番２</summary>
		private string _duplicationShelfNo2 = "";

		/// <summary>部品管理区分１</summary>
		private string _partsManagementDivide1 = "";

		/// <summary>部品管理区分２</summary>
		private string _partsManagementDivide2 = "";

		/// <summary>仕入備考1</summary>
		/// <remarks>※何の仕入かわかる内容を設定する　例）車両仕入であれば車種名　</remarks>
		private string _stockNote1 = "";

		/// <summary>仕入備考2</summary>
		private string _stockNote2 = "";

		/// <summary>出荷数（未計上）</summary>
		/// <remarks>貸出、出荷と同意</remarks>
		private Double _shipmentCnt;

		/// <summary>入荷数（未計上）</summary>
		/// <remarks>入荷</remarks>
		private Double _arrivalCnt;

		/// <summary>在庫登録日</summary>
		/// <remarks>YYYYMMDD</remarks>
		private Int32 _stockCreateDate;

		/// <summary>更新年月日</summary>
		/// <remarks>YYYYMMDD</remarks>
		private Int32 _updateDate;

		/// <summary>企業名称</summary>
		private string _enterpriseName = "";

		/// <summary>更新従業員名称</summary>
		private string _updEmployeeName = "";

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

		/// public propaty name  :  GoodsNo
		/// <summary>商品番号プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   商品番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string GoodsNo
		{
			get{return _goodsNo;}
			set{_goodsNo = value;}
		}

		/// public propaty name  :  StockUnitPriceFl
		/// <summary>仕入単価（税抜,浮動）プロパティ</summary>
		/// <value>※在庫評価単価</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入単価（税抜,浮動）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double StockUnitPriceFl
		{
			get{return _stockUnitPriceFl;}
			set{_stockUnitPriceFl = value;}
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

		/// public propaty name  :  MonthOrderCount
		/// <summary>M/O発注数プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   M/O発注数プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double MonthOrderCount
		{
			get{return _monthOrderCount;}
			set{_monthOrderCount = value;}
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

		/// public propaty name  :  StockDiv
		/// <summary>在庫区分プロパティ</summary>
		/// <value>0:自社,1:受託</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   在庫区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 StockDiv
		{
			get{return _stockDiv;}
			set{_stockDiv = value;}
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

		/// public propaty name  :  ShipmentPosCnt
		/// <summary>出荷可能数プロパティ</summary>
		/// <value>出荷可能数＝仕入在庫数 ＋ 入荷数（未計上）－ 出荷数（未計上）－受注数 － 移動中仕入在庫数</value>
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

		/// public propaty name  :  SalesOrderUnit
		/// <summary>発注単位プロパティ</summary>
		/// <value>発注する単位の数量（１０個、２０個単位等）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   発注単位プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SalesOrderUnit
		{
			get{return _salesOrderUnit;}
			set{_salesOrderUnit = value;}
		}

		/// public propaty name  :  StockSupplierCode
		/// <summary>在庫発注先コードプロパティ</summary>
		/// <value>在庫発注する場合の発注先（商品の発注先とは別管理）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   在庫発注先コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 StockSupplierCode
		{
			get{return _stockSupplierCode;}
			set{_stockSupplierCode = value;}
		}

		/// public propaty name  :  GoodsNoNoneHyphen
		/// <summary>ハイフン無商品番号プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ハイフン無商品番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string GoodsNoNoneHyphen
		{
			get{return _goodsNoNoneHyphen;}
			set{_goodsNoNoneHyphen = value;}
		}

		/// public propaty name  :  WarehouseShelfNo
		/// <summary>倉庫棚番プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   倉庫棚番プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string WarehouseShelfNo
		{
			get{return _warehouseShelfNo;}
			set{_warehouseShelfNo = value;}
		}

		/// public propaty name  :  DuplicationShelfNo1
		/// <summary>重複棚番１プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   重複棚番１プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string DuplicationShelfNo1
		{
			get{return _duplicationShelfNo1;}
			set{_duplicationShelfNo1 = value;}
		}

		/// public propaty name  :  DuplicationShelfNo2
		/// <summary>重複棚番２プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   重複棚番２プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string DuplicationShelfNo2
		{
			get{return _duplicationShelfNo2;}
			set{_duplicationShelfNo2 = value;}
		}

		/// public propaty name  :  PartsManagementDivide1
		/// <summary>部品管理区分１プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   部品管理区分１プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string PartsManagementDivide1
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
		public string PartsManagementDivide2
		{
			get{return _partsManagementDivide2;}
			set{_partsManagementDivide2 = value;}
		}

		/// public propaty name  :  StockNote1
		/// <summary>仕入備考1プロパティ</summary>
		/// <value>※何の仕入かわかる内容を設定する　例）車両仕入であれば車種名　</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入備考1プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string StockNote1
		{
			get{return _stockNote1;}
			set{_stockNote1 = value;}
		}

		/// public propaty name  :  StockNote2
		/// <summary>仕入備考2プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入備考2プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string StockNote2
		{
			get{return _stockNote2;}
			set{_stockNote2 = value;}
		}

		/// public propaty name  :  ShipmentCnt
		/// <summary>出荷数（未計上）プロパティ</summary>
		/// <value>貸出、出荷と同意</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   出荷数（未計上）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double ShipmentCnt
		{
			get{return _shipmentCnt;}
			set{_shipmentCnt = value;}
		}

		/// public propaty name  :  ArrivalCnt
		/// <summary>入荷数（未計上）プロパティ</summary>
		/// <value>入荷</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   入荷数（未計上）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double ArrivalCnt
		{
			get{return _arrivalCnt;}
			set{_arrivalCnt = value;}
		}

		/// public propaty name  :  StockCreateDate
		/// <summary>在庫登録日プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   在庫登録日プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 StockCreateDate
		{
			get{return _stockCreateDate;}
			set{_stockCreateDate = value;}
		}

		/// public propaty name  :  UpdateDate
		/// <summary>更新年月日プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   更新年月日プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 UpdateDate
		{
			get{return _updateDate;}
			set{_updateDate = value;}
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


		/// <summary>
		/// 在庫マスタコンストラクタ
		/// </summary>
		/// <returns>Stockクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   Stockクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public StockSetExp()
		{
		}

		/// <summary>
		/// 在庫マスタコンストラクタ
		/// </summary>
		/// <param name="sectionCode">拠点コード</param>
		/// <param name="warehouseCode">倉庫コード</param>
		/// <param name="goodsMakerCd">商品メーカーコード</param>
		/// <param name="goodsNo">商品番号</param>
		/// <param name="stockUnitPriceFl">仕入単価（税抜,浮動）(※在庫評価単価)</param>
		/// <param name="supplierStock">仕入在庫数(受託数を含まない在庫数（自社在庫）)</param>
		/// <param name="acpOdrCount">受注数</param>
		/// <param name="monthOrderCount">M/O発注数</param>
		/// <param name="salesOrderCount">発注数</param>
		/// <param name="stockDiv">在庫区分(0:自社,1:受託)</param>
		/// <param name="movingSupliStock">移動中仕入在庫数(在庫移動後、かつ移動先が入荷する前までの間に有効値が入る。)</param>
		/// <param name="shipmentPosCnt">出荷可能数(出荷可能数＝仕入在庫数 ＋ 入荷数（未計上）－ 出荷数（未計上）－受注数 － 移動中仕入在庫数)</param>
		/// <param name="stockTotalPrice">在庫保有総額</param>
		/// <param name="lastStockDate">最終仕入年月日(YYYYMMDD)</param>
		/// <param name="lastSalesDate">最終売上日(YYYYMMDD)</param>
		/// <param name="lastInventoryUpdate">最終棚卸更新日(YYYYMMDD)</param>
		/// <param name="minimumStockCnt">最低在庫数</param>
		/// <param name="maximumStockCnt">最高在庫数</param>
		/// <param name="nmlSalOdrCount">基準発注数</param>
		/// <param name="salesOrderUnit">発注単位(発注する単位の数量（１０個、２０個単位等）)</param>
		/// <param name="stockSupplierCode">在庫発注先コード(在庫発注する場合の発注先（商品の発注先とは別管理）)</param>
		/// <param name="goodsNoNoneHyphen">ハイフン無商品番号</param>
		/// <param name="warehouseShelfNo">倉庫棚番</param>
		/// <param name="duplicationShelfNo1">重複棚番１</param>
		/// <param name="duplicationShelfNo2">重複棚番２</param>
		/// <param name="partsManagementDivide1">部品管理区分１</param>
		/// <param name="partsManagementDivide2">部品管理区分２</param>
		/// <param name="stockNote1">仕入備考1(※何の仕入かわかる内容を設定する　例）車両仕入であれば車種名　)</param>
		/// <param name="stockNote2">仕入備考2</param>
		/// <param name="shipmentCnt">出荷数（未計上）(貸出、出荷と同意)</param>
		/// <param name="arrivalCnt">入荷数（未計上）(入荷)</param>
		/// <param name="stockCreateDate">在庫登録日(YYYYMMDD)</param>
		/// <param name="updateDate">更新年月日(YYYYMMDD)</param>
		/// <param name="enterpriseName">企業名称</param>
		/// <param name="updEmployeeName">更新従業員名称</param>
		/// <returns>Stockクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   Stockクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public StockSetExp(string sectionCode,string warehouseCode,Int32 goodsMakerCd,string goodsNo,Double stockUnitPriceFl,Double supplierStock,Double acpOdrCount,Double monthOrderCount,Double salesOrderCount,Int32 stockDiv,Double movingSupliStock,Double shipmentPosCnt,Int64 stockTotalPrice,DateTime lastStockDate,DateTime lastSalesDate,DateTime lastInventoryUpdate,Double minimumStockCnt,Double maximumStockCnt,Double nmlSalOdrCount,Int32 salesOrderUnit,Int32 stockSupplierCode,string goodsNoNoneHyphen,string warehouseShelfNo,string duplicationShelfNo1,string duplicationShelfNo2,string partsManagementDivide1,string partsManagementDivide2,string stockNote1,string stockNote2,Double shipmentCnt,Double arrivalCnt,Int32 stockCreateDate,Int32 updateDate,string enterpriseName,string updEmployeeName)
		{
			this._sectionCode = sectionCode;
			this._warehouseCode = warehouseCode;
			this._goodsMakerCd = goodsMakerCd;
			this._goodsNo = goodsNo;
			this._stockUnitPriceFl = stockUnitPriceFl;
			this._supplierStock = supplierStock;
			this._acpOdrCount = acpOdrCount;
			this._monthOrderCount = monthOrderCount;
			this._salesOrderCount = salesOrderCount;
			this._stockDiv = stockDiv;
			this._movingSupliStock = movingSupliStock;
			this._shipmentPosCnt = shipmentPosCnt;
			this._stockTotalPrice = stockTotalPrice;
			this.LastStockDate = lastStockDate;
			this.LastSalesDate = lastSalesDate;
			this.LastInventoryUpdate = lastInventoryUpdate;
			this._minimumStockCnt = minimumStockCnt;
			this._maximumStockCnt = maximumStockCnt;
			this._nmlSalOdrCount = nmlSalOdrCount;
			this._salesOrderUnit = salesOrderUnit;
			this._stockSupplierCode = stockSupplierCode;
			this._goodsNoNoneHyphen = goodsNoNoneHyphen;
			this._warehouseShelfNo = warehouseShelfNo;
			this._duplicationShelfNo1 = duplicationShelfNo1;
			this._duplicationShelfNo2 = duplicationShelfNo2;
			this._partsManagementDivide1 = partsManagementDivide1;
			this._partsManagementDivide2 = partsManagementDivide2;
			this._stockNote1 = stockNote1;
			this._stockNote2 = stockNote2;
			this._shipmentCnt = shipmentCnt;
			this._arrivalCnt = arrivalCnt;
			this._stockCreateDate = stockCreateDate;
			this._updateDate = updateDate;
			this._enterpriseName = enterpriseName;
			this._updEmployeeName = updEmployeeName;

		}

		/// <summary>
		/// 在庫マスタ複製処理
		/// </summary>
		/// <returns>Stockクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   自身の内容と等しいStockクラスのインスタンスを返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
        public StockSetExp Clone()
		{
            return new StockSetExp(this._sectionCode, this._warehouseCode, this._goodsMakerCd, this._goodsNo, this._stockUnitPriceFl, this._supplierStock, this._acpOdrCount, this._monthOrderCount, this._salesOrderCount, this._stockDiv, this._movingSupliStock, this._shipmentPosCnt, this._stockTotalPrice, this._lastStockDate, this._lastSalesDate, this._lastInventoryUpdate, this._minimumStockCnt, this._maximumStockCnt, this._nmlSalOdrCount, this._salesOrderUnit, this._stockSupplierCode, this._goodsNoNoneHyphen, this._warehouseShelfNo, this._duplicationShelfNo1, this._duplicationShelfNo2, this._partsManagementDivide1, this._partsManagementDivide2, this._stockNote1, this._stockNote2, this._shipmentCnt, this._arrivalCnt, this._stockCreateDate, this._updateDate, this._enterpriseName, this._updEmployeeName);
		}

    }
}
