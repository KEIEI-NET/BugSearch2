//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 発注点設定処理
// プログラム概要   : 発注点設定処理ワーク
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 劉学智
// 作 成 日  2009/04/28  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   OrderPointStSimulationWork
    /// <summary>
    ///                      発注点設定処理ワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   発注点設定処理ワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2009/04/09</br>
    /// <br>Genarated Date   :   2009/06/06  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2009/04/10  長内</br>
    /// <br>                 :   ○ファイル番号、ファイルＩＤ、</br>
    /// <br>                 :   　項目ＩＤの更新</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class OrderPointStSimulationWork : IFileHeader
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

        /// <summary>拠点名称</summary>
        private string _sectionName = "";

        /// <summary>パターン番号</summary>
        private Int32 _patterNo;

        /// <summary>パターン番号枝番</summary>
        /// <remarks>最大20個まで連番</remarks>
        private Int32 _patternNoDerivedNo;

        /// <summary>倉庫コード</summary>
        private string _warehouseCode = "";

        /// <summary>倉庫名称</summary>
        private string _warehouseName = "";

        /// <summary>倉庫棚番</summary>
        private string _warehouseShelfNo = "";

        /// <summary>仕入先コード</summary>
        private Int32 _supplierCd;

        /// <summary>仕入先名称</summary>
        private string _supplierNm = "";

        /// <summary>商品メーカーコード</summary>
        private Int32 _goodsMakerCd;

        /// <summary>商品メーカー名称</summary>
        private string _goodsMakerNm = "";

        /// <summary>商品中分類コード</summary>
        private Int32 _goodsMGroup;

        /// <summary>BLグループコード</summary>
        private Int32 _bLGroupCode;

        /// <summary>BL商品コード</summary>
        private Int32 _bLGoodsCode;

        /// <summary>在庫出荷対象開始月</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _stckShipMonthSt;

        /// <summary>在庫出荷対象終了月</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _stckShipMonthEd;

        /// <summary>発注適用区分</summary>
        /// <remarks>0:平均,1:合計</remarks>
        private Int32 _orderApplyDiv;

        /// <summary>在庫登録日</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _stockCreateDate;

        /// <summary>出荷数範囲(以上)</summary>
        private Double _shipScopeMore;

        /// <summary>出荷数範囲(以下)</summary>
        private Double _shipScopeLess;

        /// <summary>最低在庫数</summary>
        private Double _minimumStockCnt;

        /// <summary>最高在庫数</summary>
        private Double _maximumStockCnt;

        /// <summary>発注単位</summary>
        /// <remarks>発注ロット</remarks>
        private Int32 _salesOrderUnit;

        /// <summary>発注点処理更新フラグ</summary>
        /// <remarks>0:未更新,1:更新済</remarks>
        private Int32 _orderPProcUpdFlg;

        /// <summary>商品番号</summary>
        private string _goodsNo = "";

        /// <summary>商品名称</summary>
        private string _goodsName = "";

        /// <summary>集計方法</summary>
        private string _sumMethod = "";

        /// <summary>旧価格</summary>
        private Double _oldPrice;

        /// <summary>現在庫</summary>
        private Double _nowPrice;

        /// <summary>現在庫金額</summary>
        private Double _nowStockPrice;

        /// <summary>変更前最低数</summary>
        private Double _oldMinCnt;

        /// <summary>変更前最高数</summary>
        private Double _oldMaxCnt;

        /// <summary>変更後最低数</summary>
        private Double _newMinCnt;

        /// <summary>変更後最高数</summary>
        private Double _newMaxCnt;

        /// <summary>変更前最低金額</summary>
        private Double _oldMinPrice;

        /// <summary>変更前最高金額</summary>
        private Double _oldMaxPrice;

        /// <summary>変更後最低金額</summary>
        private Double _newMinPrice;

        /// <summary>変更後最高金額</summary>
        private Double _newMaxPrice;


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
            get { return _createDateTime; }
            set { _createDateTime = value; }
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
            get { return _updateDateTime; }
            set { _updateDateTime = value; }
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
            get { return _enterpriseCode; }
            set { _enterpriseCode = value; }
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
            get { return _fileHeaderGuid; }
            set { _fileHeaderGuid = value; }
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
            get { return _updEmployeeCode; }
            set { _updEmployeeCode = value; }
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
            get { return _updAssemblyId1; }
            set { _updAssemblyId1 = value; }
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
            get { return _updAssemblyId2; }
            set { _updAssemblyId2 = value; }
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
            get { return _logicalDeleteCode; }
            set { _logicalDeleteCode = value; }
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
            get { return _sectionCode; }
            set { _sectionCode = value; }
        }

        /// public propaty name  :  SectionName
        /// <summary>拠点名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SectionName
        {
            get { return _sectionName; }
            set { _sectionName = value; }
        }

        /// public propaty name  :  PatterNo
        /// <summary>パターン番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   パターン番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PatterNo
        {
            get { return _patterNo; }
            set { _patterNo = value; }
        }

        /// public propaty name  :  PatternNoDerivedNo
        /// <summary>パターン番号枝番プロパティ</summary>
        /// <value>最大20個まで連番</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   パターン番号枝番プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PatternNoDerivedNo
        {
            get { return _patternNoDerivedNo; }
            set { _patternNoDerivedNo = value; }
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
            get { return _warehouseCode; }
            set { _warehouseCode = value; }
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
            get { return _warehouseName; }
            set { _warehouseName = value; }
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
            get { return _warehouseShelfNo; }
            set { _warehouseShelfNo = value; }
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
            get { return _supplierCd; }
            set { _supplierCd = value; }
        }

        /// public propaty name  :  SupplierNm
        /// <summary>仕入先名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SupplierNm
        {
            get { return _supplierNm; }
            set { _supplierNm = value; }
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
            get { return _goodsMakerCd; }
            set { _goodsMakerCd = value; }
        }

        /// public propaty name  :  GoodsMakerNm
        /// <summary>商品メーカー名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品メーカー名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsMakerNm
        {
            get { return _goodsMakerNm; }
            set { _goodsMakerNm = value; }
        }

        /// public propaty name  :  GoodsMGroup
        /// <summary>商品中分類コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品中分類コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsMGroup
        {
            get { return _goodsMGroup; }
            set { _goodsMGroup = value; }
        }

        /// public propaty name  :  BLGroupCode
        /// <summary>BLグループコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BLグループコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BLGroupCode
        {
            get { return _bLGroupCode; }
            set { _bLGroupCode = value; }
        }

        /// public propaty name  :  BLGoodsCode
        /// <summary>BL商品コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL商品コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BLGoodsCode
        {
            get { return _bLGoodsCode; }
            set { _bLGoodsCode = value; }
        }

        /// public propaty name  :  StckShipMonthSt
        /// <summary>在庫出荷対象開始月プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   在庫出荷対象開始月プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 StckShipMonthSt
        {
            get { return _stckShipMonthSt; }
            set { _stckShipMonthSt = value; }
        }

        /// public propaty name  :  StckShipMonthEd
        /// <summary>在庫出荷対象終了月プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   在庫出荷対象終了月プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 StckShipMonthEd
        {
            get { return _stckShipMonthEd; }
            set { _stckShipMonthEd = value; }
        }

        /// public propaty name  :  OrderApplyDiv
        /// <summary>発注適用区分プロパティ</summary>
        /// <value>0:平均,1:合計</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   発注適用区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 OrderApplyDiv
        {
            get { return _orderApplyDiv; }
            set { _orderApplyDiv = value; }
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
            get { return _stockCreateDate; }
            set { _stockCreateDate = value; }
        }

        /// public propaty name  :  ShipScopeMore
        /// <summary>出荷数範囲(以上)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   出荷数範囲(以上)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double ShipScopeMore
        {
            get { return _shipScopeMore; }
            set { _shipScopeMore = value; }
        }

        /// public propaty name  :  ShipScopeLess
        /// <summary>出荷数範囲(以下)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   出荷数範囲(以下)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double ShipScopeLess
        {
            get { return _shipScopeLess; }
            set { _shipScopeLess = value; }
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
            get { return _minimumStockCnt; }
            set { _minimumStockCnt = value; }
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
            get { return _maximumStockCnt; }
            set { _maximumStockCnt = value; }
        }

        /// public propaty name  :  SalesOrderUnit
        /// <summary>発注単位プロパティ</summary>
        /// <value>発注ロット</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   発注単位プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SalesOrderUnit
        {
            get { return _salesOrderUnit; }
            set { _salesOrderUnit = value; }
        }

        /// public propaty name  :  OrderPProcUpdFlg
        /// <summary>発注点処理更新フラグプロパティ</summary>
        /// <value>0:未更新,1:更新済</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   発注点処理更新フラグプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 OrderPProcUpdFlg
        {
            get { return _orderPProcUpdFlg; }
            set { _orderPProcUpdFlg = value; }
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
            get { return _goodsNo; }
            set { _goodsNo = value; }
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
            get { return _goodsName; }
            set { _goodsName = value; }
        }

        /// public propaty name  :  SumMethod
        /// <summary>集計方法プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   集計方法プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SumMethod
        {
            get { return _sumMethod; }
            set { _sumMethod = value; }
        }

        /// public propaty name  :  OldPrice
        /// <summary>旧価格プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   旧価格プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double OldPrice
        {
            get { return _oldPrice; }
            set { _oldPrice = value; }
        }

        /// public propaty name  :  NowPrice
        /// <summary>現在庫プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   現在庫プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double NowPrice
        {
            get { return _nowPrice; }
            set { _nowPrice = value; }
        }

        /// public propaty name  :  NowStockPrice
        /// <summary>現在庫金額プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   現在庫金額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double NowStockPrice
        {
            get { return _nowStockPrice; }
            set { _nowStockPrice = value; }
        }

        /// public propaty name  :  OldMinCnt
        /// <summary>変更前最低数プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   変更前最低数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double OldMinCnt
        {
            get { return _oldMinCnt; }
            set { _oldMinCnt = value; }
        }

        /// public propaty name  :  OldMaxCnt
        /// <summary>変更前最高数プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   変更前最高数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double OldMaxCnt
        {
            get { return _oldMaxCnt; }
            set { _oldMaxCnt = value; }
        }

        /// public propaty name  :  NewMinCnt
        /// <summary>変更後最低数プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   変更後最低数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double NewMinCnt
        {
            get { return _newMinCnt; }
            set { _newMinCnt = value; }
        }

        /// public propaty name  :  NewMaxCnt
        /// <summary>変更後最高数プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   変更後最高数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double NewMaxCnt
        {
            get { return _newMaxCnt; }
            set { _newMaxCnt = value; }
        }

        /// public propaty name  :  OldMinPrice
        /// <summary>変更前最低金額プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   変更前最低金額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double OldMinPrice
        {
            get { return _oldMinPrice; }
            set { _oldMinPrice = value; }
        }

        /// public propaty name  :  OldMaxPrice
        /// <summary>変更前最高金額プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   変更前最高金額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double OldMaxPrice
        {
            get { return _oldMaxPrice; }
            set { _oldMaxPrice = value; }
        }

        /// public propaty name  :  NewMinPrice
        /// <summary>変更後最低金額プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   変更後最低金額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double NewMinPrice
        {
            get { return _newMinPrice; }
            set { _newMinPrice = value; }
        }

        /// public propaty name  :  NewMaxPrice
        /// <summary>変更後最高金額プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   変更後最高金額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double NewMaxPrice
        {
            get { return _newMaxPrice; }
            set { _newMaxPrice = value; }
        }


        /// <summary>
        /// 発注点設定処理ワークコンストラクタ
        /// </summary>
        /// <returns>OrderPointStSimulationWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   OrderPointStSimulationWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public OrderPointStSimulationWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>OrderPointStSimulationWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   OrderPointStSimulationWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class OrderPointStSimulationWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   OrderPointStSimulationWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  OrderPointStSimulationWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is OrderPointStSimulationWork || graph is ArrayList || graph is OrderPointStSimulationWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(OrderPointStSimulationWork).FullName));

            if (graph != null && graph is OrderPointStSimulationWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.OrderPointStSimulationWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is OrderPointStSimulationWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((OrderPointStSimulationWork[])graph).Length;
            }
            else if (graph is OrderPointStSimulationWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //作成日時
            serInfo.MemberInfo.Add(typeof(Int64)); //CreateDateTime
            //更新日時
            serInfo.MemberInfo.Add(typeof(Int64)); //UpdateDateTime
            //企業コード
            serInfo.MemberInfo.Add(typeof(string)); //EnterpriseCode
            //GUID
            serInfo.MemberInfo.Add(typeof(byte[]));  //FileHeaderGuid
            //更新従業員コード
            serInfo.MemberInfo.Add(typeof(string)); //UpdEmployeeCode
            //更新アセンブリID1
            serInfo.MemberInfo.Add(typeof(string)); //UpdAssemblyId1
            //更新アセンブリID2
            serInfo.MemberInfo.Add(typeof(string)); //UpdAssemblyId2
            //論理削除区分
            serInfo.MemberInfo.Add(typeof(Int32)); //LogicalDeleteCode
            //拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //SectionCode
            //拠点名称
            serInfo.MemberInfo.Add(typeof(string)); //SectionName
            //パターン番号
            serInfo.MemberInfo.Add(typeof(Int32)); //PatterNo
            //パターン番号枝番
            serInfo.MemberInfo.Add(typeof(Int32)); //PatternNoDerivedNo
            //倉庫コード
            serInfo.MemberInfo.Add(typeof(string)); //WarehouseCode
            //倉庫名称
            serInfo.MemberInfo.Add(typeof(string)); //WarehouseName
            //倉庫棚番
            serInfo.MemberInfo.Add(typeof(string)); //WarehouseShelfNo
            //仕入先コード
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierCd
            //仕入先名称
            serInfo.MemberInfo.Add(typeof(string)); //SupplierNm
            //商品メーカーコード
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd
            //商品メーカー名称
            serInfo.MemberInfo.Add(typeof(string)); //GoodsMakerNm
            //商品中分類コード
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMGroup
            //BLグループコード
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGroupCode
            //BL商品コード
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGoodsCode
            //在庫出荷対象開始月
            serInfo.MemberInfo.Add(typeof(Int32)); //StckShipMonthSt
            //在庫出荷対象終了月
            serInfo.MemberInfo.Add(typeof(Int32)); //StckShipMonthEd
            //発注適用区分
            serInfo.MemberInfo.Add(typeof(Int32)); //OrderApplyDiv
            //在庫登録日
            serInfo.MemberInfo.Add(typeof(Int32)); //StockCreateDate
            //出荷数範囲(以上)
            serInfo.MemberInfo.Add(typeof(Double)); //ShipScopeMore
            //出荷数範囲(以下)
            serInfo.MemberInfo.Add(typeof(Double)); //ShipScopeLess
            //最低在庫数
            serInfo.MemberInfo.Add(typeof(Double)); //MinimumStockCnt
            //最高在庫数
            serInfo.MemberInfo.Add(typeof(Double)); //MaximumStockCnt
            //発注単位
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesOrderUnit
            //発注点処理更新フラグ
            serInfo.MemberInfo.Add(typeof(Int32)); //OrderPProcUpdFlg
            //商品番号
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNo
            //商品名称
            serInfo.MemberInfo.Add(typeof(string)); //GoodsName
            //集計方法
            serInfo.MemberInfo.Add(typeof(string)); //SumMethod
            //旧価格
            serInfo.MemberInfo.Add(typeof(Double)); //OldPrice
            //現在庫
            serInfo.MemberInfo.Add(typeof(Double)); //NowPrice
            //現在庫金額
            serInfo.MemberInfo.Add(typeof(Double)); //NowStockPrice
            //変更前最低数
            serInfo.MemberInfo.Add(typeof(Double)); //OldMinCnt
            //変更前最高数
            serInfo.MemberInfo.Add(typeof(Double)); //OldMaxCnt
            //変更後最低数
            serInfo.MemberInfo.Add(typeof(Double)); //NewMinCnt
            //変更後最高数
            serInfo.MemberInfo.Add(typeof(Double)); //NewMaxCnt
            //変更前最低金額
            serInfo.MemberInfo.Add(typeof(Double)); //OldMinPrice
            //変更前最高金額
            serInfo.MemberInfo.Add(typeof(Double)); //OldMaxPrice
            //変更後最低金額
            serInfo.MemberInfo.Add(typeof(Double)); //NewMinPrice
            //変更後最高金額
            serInfo.MemberInfo.Add(typeof(Double)); //NewMaxPrice


            serInfo.Serialize(writer, serInfo);
            if (graph is OrderPointStSimulationWork)
            {
                OrderPointStSimulationWork temp = (OrderPointStSimulationWork)graph;

                SetOrderPointStSimulationWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is OrderPointStSimulationWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((OrderPointStSimulationWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (OrderPointStSimulationWork temp in lst)
                {
                    SetOrderPointStSimulationWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// OrderPointStSimulationWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 46;

        /// <summary>
        ///  OrderPointStSimulationWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   OrderPointStSimulationWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetOrderPointStSimulationWork(System.IO.BinaryWriter writer, OrderPointStSimulationWork temp)
        {
            //作成日時
            writer.Write((Int64)temp.CreateDateTime.Ticks);
            //更新日時
            writer.Write((Int64)temp.UpdateDateTime.Ticks);
            //企業コード
            writer.Write(temp.EnterpriseCode);
            //GUID
            byte[] fileHeaderGuidArray = temp.FileHeaderGuid.ToByteArray();
            writer.Write(fileHeaderGuidArray.Length);
            writer.Write(temp.FileHeaderGuid.ToByteArray());
            //更新従業員コード
            writer.Write(temp.UpdEmployeeCode);
            //更新アセンブリID1
            writer.Write(temp.UpdAssemblyId1);
            //更新アセンブリID2
            writer.Write(temp.UpdAssemblyId2);
            //論理削除区分
            writer.Write(temp.LogicalDeleteCode);
            //拠点コード
            writer.Write(temp.SectionCode);
            //拠点名称
            writer.Write(temp.SectionName);
            //パターン番号
            writer.Write(temp.PatterNo);
            //パターン番号枝番
            writer.Write(temp.PatternNoDerivedNo);
            //倉庫コード
            writer.Write(temp.WarehouseCode);
            //倉庫名称
            writer.Write(temp.WarehouseName);
            //倉庫棚番
            writer.Write(temp.WarehouseShelfNo);
            //仕入先コード
            writer.Write(temp.SupplierCd);
            //仕入先名称
            writer.Write(temp.SupplierNm);
            //商品メーカーコード
            writer.Write(temp.GoodsMakerCd);
            //商品メーカー名称
            writer.Write(temp.GoodsMakerNm);
            //商品中分類コード
            writer.Write(temp.GoodsMGroup);
            //BLグループコード
            writer.Write(temp.BLGroupCode);
            //BL商品コード
            writer.Write(temp.BLGoodsCode);
            //在庫出荷対象開始月
            writer.Write(temp.StckShipMonthSt);
            //在庫出荷対象終了月
            writer.Write(temp.StckShipMonthEd);
            //発注適用区分
            writer.Write(temp.OrderApplyDiv);
            //在庫登録日
            writer.Write((Int64)temp.StockCreateDate.Ticks);
            //出荷数範囲(以上)
            writer.Write(temp.ShipScopeMore);
            //出荷数範囲(以下)
            writer.Write(temp.ShipScopeLess);
            //最低在庫数
            writer.Write(temp.MinimumStockCnt);
            //最高在庫数
            writer.Write(temp.MaximumStockCnt);
            //発注単位
            writer.Write(temp.SalesOrderUnit);
            //発注点処理更新フラグ
            writer.Write(temp.OrderPProcUpdFlg);
            //商品番号
            writer.Write(temp.GoodsNo);
            //商品名称
            writer.Write(temp.GoodsName);
            //集計方法
            writer.Write(temp.SumMethod);
            //旧価格
            writer.Write(temp.OldPrice);
            //現在庫
            writer.Write(temp.NowPrice);
            //現在庫金額
            writer.Write(temp.NowStockPrice);
            //変更前最低数
            writer.Write(temp.OldMinCnt);
            //変更前最高数
            writer.Write(temp.OldMaxCnt);
            //変更後最低数
            writer.Write(temp.NewMinCnt);
            //変更後最高数
            writer.Write(temp.NewMaxCnt);
            //変更前最低金額
            writer.Write(temp.OldMinPrice);
            //変更前最高金額
            writer.Write(temp.OldMaxPrice);
            //変更後最低金額
            writer.Write(temp.NewMinPrice);
            //変更後最高金額
            writer.Write(temp.NewMaxPrice);

        }

        /// <summary>
        ///  OrderPointStSimulationWorkインスタンス取得
        /// </summary>
        /// <returns>OrderPointStSimulationWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   OrderPointStSimulationWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private OrderPointStSimulationWork GetOrderPointStSimulationWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            OrderPointStSimulationWork temp = new OrderPointStSimulationWork();

            //作成日時
            temp.CreateDateTime = new DateTime(reader.ReadInt64());
            //更新日時
            temp.UpdateDateTime = new DateTime(reader.ReadInt64());
            //企業コード
            temp.EnterpriseCode = reader.ReadString();
            //GUID
            int lenOfFileHeaderGuidArray = reader.ReadInt32();
            byte[] fileHeaderGuidArray = reader.ReadBytes(lenOfFileHeaderGuidArray);
            temp.FileHeaderGuid = new Guid(fileHeaderGuidArray);
            //更新従業員コード
            temp.UpdEmployeeCode = reader.ReadString();
            //更新アセンブリID1
            temp.UpdAssemblyId1 = reader.ReadString();
            //更新アセンブリID2
            temp.UpdAssemblyId2 = reader.ReadString();
            //論理削除区分
            temp.LogicalDeleteCode = reader.ReadInt32();
            //拠点コード
            temp.SectionCode = reader.ReadString();
            //拠点名称
            temp.SectionName = reader.ReadString();
            //パターン番号
            temp.PatterNo = reader.ReadInt32();
            //パターン番号枝番
            temp.PatternNoDerivedNo = reader.ReadInt32();
            //倉庫コード
            temp.WarehouseCode = reader.ReadString();
            //倉庫名称
            temp.WarehouseName = reader.ReadString();
            //倉庫棚番
            temp.WarehouseShelfNo = reader.ReadString();
            //仕入先コード
            temp.SupplierCd = reader.ReadInt32();
            //仕入先名称
            temp.SupplierNm = reader.ReadString();
            //商品メーカーコード
            temp.GoodsMakerCd = reader.ReadInt32();
            //商品メーカー名称
            temp.GoodsMakerNm = reader.ReadString();
            //商品中分類コード
            temp.GoodsMGroup = reader.ReadInt32();
            //BLグループコード
            temp.BLGroupCode = reader.ReadInt32();
            //BL商品コード
            temp.BLGoodsCode = reader.ReadInt32();
            //在庫出荷対象開始月
            temp.StckShipMonthSt = reader.ReadInt32();
            //在庫出荷対象終了月
            temp.StckShipMonthEd = reader.ReadInt32();
            //発注適用区分
            temp.OrderApplyDiv = reader.ReadInt32();
            //在庫登録日
            temp.StockCreateDate = new DateTime(reader.ReadInt64());
            //出荷数範囲(以上)
            temp.ShipScopeMore = reader.ReadDouble();
            //出荷数範囲(以下)
            temp.ShipScopeLess = reader.ReadDouble();
            //最低在庫数
            temp.MinimumStockCnt = reader.ReadDouble();
            //最高在庫数
            temp.MaximumStockCnt = reader.ReadDouble();
            //発注単位
            temp.SalesOrderUnit = reader.ReadInt32();
            //発注点処理更新フラグ
            temp.OrderPProcUpdFlg = reader.ReadInt32();
            //商品番号
            temp.GoodsNo = reader.ReadString();
            //商品名称
            temp.GoodsName = reader.ReadString();
            //集計方法
            temp.SumMethod = reader.ReadString();
            //旧価格
            temp.OldPrice = reader.ReadDouble();
            //現在庫
            temp.NowPrice = reader.ReadDouble();
            //現在庫金額
            temp.NowStockPrice = reader.ReadDouble();
            //変更前最低数
            temp.OldMinCnt = reader.ReadDouble();
            //変更前最高数
            temp.OldMaxCnt = reader.ReadDouble();
            //変更後最低数
            temp.NewMinCnt = reader.ReadDouble();
            //変更後最高数
            temp.NewMaxCnt = reader.ReadDouble();
            //変更前最低金額
            temp.OldMinPrice = reader.ReadDouble();
            //変更前最高金額
            temp.OldMaxPrice = reader.ReadDouble();
            //変更後最低金額
            temp.NewMinPrice = reader.ReadDouble();
            //変更後最高金額
            temp.NewMaxPrice = reader.ReadDouble();


            //以下は読み飛ばしです。このバージョンが想定する EmployeeWork型以降のバージョンの
            //データをデシリアライズする場合、シリアライズしたフォーマッタが記述した
            //型情報にしたがって、ストリームから情報を読み出します...といっても
            //読み出して捨てることになります。
            for (int k = currentMemberCount; k < serInfo.MemberInfo.Count; ++k)
            {
                //byte[],char[]をデシリアライズする直前に、そのlengthが
                //デシリアライズされているケースがある、byte[],char[]の
                //デシリアライズにはlengthが必要なのでint型のデータをデ
                //シリアライズした場合は、この値をこの変数に退避します。
                int optCount = 0;
                object oMemberType = serInfo.MemberInfo[k];
                if (oMemberType is Type)
                {
                    Type t = (Type)oMemberType;
                    object oData = TypeDeserializer.DeserializePrimitiveType(reader, t, optCount);
                    if (t.Equals(typeof(int)))
                    {
                        optCount = Convert.ToInt32(oData);
                    }
                    else
                    {
                        optCount = 0;
                    }
                }
                else if (oMemberType is string)
                {
                    Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate formatter = CustomFormatterServices.GetSurrogate((string)oMemberType);
                    object userData = formatter.Deserialize(reader);  //読み飛ばし
                }
            }
            return temp;
        }

        /// <summary>
        ///  Ver5.10.1.0用のカスタムデシリアライザです
        /// </summary>
        /// <returns>OrderPointStSimulationWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   OrderPointStSimulationWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                OrderPointStSimulationWork temp = GetOrderPointStSimulationWork(reader, serInfo);
                lst.Add(temp);
            }
            switch (serInfo.RetTypeInfo)
            {
                case 0:
                    retValue = lst;
                    break;
                case 1:
                    retValue = lst[0];
                    break;
                case 2:
                    retValue = (OrderPointStSimulationWork[])lst.ToArray(typeof(OrderPointStSimulationWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }


}
