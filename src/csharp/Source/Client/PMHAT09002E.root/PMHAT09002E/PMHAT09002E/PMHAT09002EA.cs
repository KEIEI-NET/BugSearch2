//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 発注点設定マスタメンテナンス
// プログラム概要   : 発注点設定の登録・変更・削除を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 李占川
// 作 成 日  2009/03/31  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   OrderPointSt
    /// <summary>
    ///                      発注点設定マスタ
    /// </summary>
    /// <remarks>
    /// <br>note             :   発注点設定マスタヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2009/04/09</br>
    /// <br>Genarated Date   :   2009/04/10  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2009/04/10  長内</br>
    /// <br>                 :   ○ファイル番号、ファイルＩＤ、</br>
    /// <br>                 :   　項目ＩＤの更新</br>
    /// </remarks>
    public class OrderPointSt
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

        /// <summary>パターン番号</summary>
        private Int32 _patterNo;

        /// <summary>パターン番号枝番</summary>
        /// <remarks>最大20個まで連番</remarks>
        private Int32 _patternNoDerivedNo;

        /// <summary>倉庫コード</summary>
        private string _warehouseCode = "";

        /// <summary>仕入先コード</summary>
        private Int32 _supplierCd;

        /// <summary>商品メーカーコード</summary>
        private Int32 _goodsMakerCd;

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
        private Int32 _stockCreateDate;

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

        /// <summary>企業名称</summary>
        private string _enterpriseName = "";

        /// <summary>更新従業員名称</summary>
        private string _updEmployeeName = "";


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
            get { return TDateTime.DateTimeToString("GGYYMMDD", _createDateTime); }
            set { }
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
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _createDateTime); }
            set { }
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
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _createDateTime); }
            set { }
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
            get { return TDateTime.DateTimeToString("YY/MM/DD", _createDateTime); }
            set { }
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
            get { return TDateTime.DateTimeToString("GGYYMMDD", _updateDateTime); }
            set { }
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
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _updateDateTime); }
            set { }
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
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _updateDateTime); }
            set { }
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
            get { return TDateTime.DateTimeToString("YY/MM/DD", _updateDateTime); }
            set { }
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
        public Int32 StockCreateDate
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

        /// public propaty name  :  EnterpriseName
        /// <summary>企業名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   企業名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EnterpriseName
        {
            get { return _enterpriseName; }
            set { _enterpriseName = value; }
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
            get { return _updEmployeeName; }
            set { _updEmployeeName = value; }
        }


        /// <summary>
        /// 発注点設定マスタコンストラクタ
        /// </summary>
        /// <returns>OrderPointStクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   OrderPointStクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public OrderPointSt()
        {
        }

        /// <summary>
        /// 発注点設定マスタコンストラクタ
        /// </summary>
        /// <param name="createDateTime">作成日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="updateDateTime">更新日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
        /// <param name="fileHeaderGuid">GUID(共通ファイルヘッダ)</param>
        /// <param name="updEmployeeCode">更新従業員コード(共通ファイルヘッダ)</param>
        /// <param name="updAssemblyId1">更新アセンブリID1(共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）)</param>
        /// <param name="updAssemblyId2">更新アセンブリID2(共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）)</param>
        /// <param name="logicalDeleteCode">論理削除区分(共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除))</param>
        /// <param name="patterNo">パターン番号</param>
        /// <param name="patternNoDerivedNo">パターン番号枝番(最大20個まで連番)</param>
        /// <param name="warehouseCode">倉庫コード</param>
        /// <param name="supplierCd">仕入先コード</param>
        /// <param name="goodsMakerCd">商品メーカーコード</param>
        /// <param name="goodsMGroup">商品中分類コード</param>
        /// <param name="bLGroupCode">BLグループコード</param>
        /// <param name="bLGoodsCode">BL商品コード</param>
        /// <param name="stckShipMonthSt">在庫出荷対象開始月(YYYYMMDD)</param>
        /// <param name="stckShipMonthEd">在庫出荷対象終了月(YYYYMMDD)</param>
        /// <param name="orderApplyDiv">発注適用区分(0:平均,1:合計)</param>
        /// <param name="stockCreateDate">在庫登録日(YYYYMMDD)</param>
        /// <param name="shipScopeMore">出荷数範囲(以上)</param>
        /// <param name="shipScopeLess">出荷数範囲(以下)</param>
        /// <param name="minimumStockCnt">最低在庫数</param>
        /// <param name="maximumStockCnt">最高在庫数</param>
        /// <param name="salesOrderUnit">発注単位(発注ロット)</param>
        /// <param name="orderPProcUpdFlg">発注点処理更新フラグ(0:未更新,1:更新済)</param>
        /// <param name="enterpriseName">企業名称</param>
        /// <param name="updEmployeeName">更新従業員名称</param>
        /// <returns>OrderPointStクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   OrderPointStクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public OrderPointSt(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 patterNo, Int32 patternNoDerivedNo, string warehouseCode, Int32 supplierCd, Int32 goodsMakerCd, Int32 goodsMGroup, Int32 bLGroupCode, Int32 bLGoodsCode, Int32 stckShipMonthSt, Int32 stckShipMonthEd, Int32 orderApplyDiv, Int32 stockCreateDate, Double shipScopeMore, Double shipScopeLess, Double minimumStockCnt, Double maximumStockCnt, Int32 salesOrderUnit, Int32 orderPProcUpdFlg, string enterpriseName, string updEmployeeName)
        {
            this.CreateDateTime = createDateTime;
            this.UpdateDateTime = updateDateTime;
            this._enterpriseCode = enterpriseCode;
            this._fileHeaderGuid = fileHeaderGuid;
            this._updEmployeeCode = updEmployeeCode;
            this._updAssemblyId1 = updAssemblyId1;
            this._updAssemblyId2 = updAssemblyId2;
            this._logicalDeleteCode = logicalDeleteCode;
            this._patterNo = patterNo;
            this._patternNoDerivedNo = patternNoDerivedNo;
            this._warehouseCode = warehouseCode;
            this._supplierCd = supplierCd;
            this._goodsMakerCd = goodsMakerCd;
            this._goodsMGroup = goodsMGroup;
            this._bLGroupCode = bLGroupCode;
            this._bLGoodsCode = bLGoodsCode;
            this._stckShipMonthSt = stckShipMonthSt;
            this._stckShipMonthEd = stckShipMonthEd;
            this._orderApplyDiv = orderApplyDiv;
            this._stockCreateDate = stockCreateDate;
            this._shipScopeMore = shipScopeMore;
            this._shipScopeLess = shipScopeLess;
            this._minimumStockCnt = minimumStockCnt;
            this._maximumStockCnt = maximumStockCnt;
            this._salesOrderUnit = salesOrderUnit;
            this._orderPProcUpdFlg = orderPProcUpdFlg;
            this._enterpriseName = enterpriseName;
            this._updEmployeeName = updEmployeeName;

        }

        /// <summary>
        /// 発注点設定マスタ複製処理
        /// </summary>
        /// <returns>OrderPointStクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいOrderPointStクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public OrderPointSt Clone()
        {
            return new OrderPointSt(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._patterNo, this._patternNoDerivedNo, this._warehouseCode, this._supplierCd, this._goodsMakerCd, this._goodsMGroup, this._bLGroupCode, this._bLGoodsCode, this._stckShipMonthSt, this._stckShipMonthEd, this._orderApplyDiv, this._stockCreateDate, this._shipScopeMore, this._shipScopeLess, this._minimumStockCnt, this._maximumStockCnt, this._salesOrderUnit, this._orderPProcUpdFlg, this._enterpriseName, this._updEmployeeName);
        }

        /// <summary>
        /// 発注点設定マスタ比較処理
        /// </summary>
        /// <param name="target">比較対象のOrderPointStクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   OrderPointStクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool Equals(OrderPointSt target)
        {
            return ((this.CreateDateTime == target.CreateDateTime)
                 && (this.UpdateDateTime == target.UpdateDateTime)
                 && (this.EnterpriseCode == target.EnterpriseCode)
                 && (this.FileHeaderGuid == target.FileHeaderGuid)
                 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
                 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
                 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
                 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
                 //&& (this.PatterNo == target.PatterNo)
                 && (this.PatternNoDerivedNo == target.PatternNoDerivedNo)
                 && (this.WarehouseCode == target.WarehouseCode)
                 && (this.SupplierCd == target.SupplierCd)
                 && (this.GoodsMakerCd == target.GoodsMakerCd)
                 && (this.GoodsMGroup == target.GoodsMGroup)
                 && (this.BLGroupCode == target.BLGroupCode)
                 && (this.BLGoodsCode == target.BLGoodsCode)
                 && (this.StckShipMonthSt == target.StckShipMonthSt)
                 && (this.StckShipMonthEd == target.StckShipMonthEd)
                 && (this.OrderApplyDiv == target.OrderApplyDiv)
                 && (this.StockCreateDate == target.StockCreateDate)
                 && (this.ShipScopeMore == target.ShipScopeMore)
                 && (this.ShipScopeLess == target.ShipScopeLess)
                 && (this.MinimumStockCnt == target.MinimumStockCnt)
                 && (this.MaximumStockCnt == target.MaximumStockCnt)
                 && (this.SalesOrderUnit == target.SalesOrderUnit)
                 && (this.OrderPProcUpdFlg == target.OrderPProcUpdFlg)
                 && (this.EnterpriseName == target.EnterpriseName)
                 && (this.UpdEmployeeName == target.UpdEmployeeName));
        }

        /// <summary>
        /// 発注点設定マスタ比較処理
        /// </summary>
        /// <param name="orderPointSt1">
        ///                    比較するOrderPointStクラスのインスタンス
        /// </param>
        /// <param name="orderPointSt2">比較するOrderPointStクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   OrderPointStクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static bool Equals(OrderPointSt orderPointSt1, OrderPointSt orderPointSt2)
        {
            return ((orderPointSt1.CreateDateTime == orderPointSt2.CreateDateTime)
                 && (orderPointSt1.UpdateDateTime == orderPointSt2.UpdateDateTime)
                 && (orderPointSt1.EnterpriseCode == orderPointSt2.EnterpriseCode)
                 && (orderPointSt1.FileHeaderGuid == orderPointSt2.FileHeaderGuid)
                 && (orderPointSt1.UpdEmployeeCode == orderPointSt2.UpdEmployeeCode)
                 && (orderPointSt1.UpdAssemblyId1 == orderPointSt2.UpdAssemblyId1)
                 && (orderPointSt1.UpdAssemblyId2 == orderPointSt2.UpdAssemblyId2)
                 && (orderPointSt1.LogicalDeleteCode == orderPointSt2.LogicalDeleteCode)
                 //&& (orderPointSt1.PatterNo == orderPointSt2.PatterNo)
                 && (orderPointSt1.PatternNoDerivedNo == orderPointSt2.PatternNoDerivedNo)
                 && (orderPointSt1.WarehouseCode == orderPointSt2.WarehouseCode)
                 && (orderPointSt1.SupplierCd == orderPointSt2.SupplierCd)
                 && (orderPointSt1.GoodsMakerCd == orderPointSt2.GoodsMakerCd)
                 && (orderPointSt1.GoodsMGroup == orderPointSt2.GoodsMGroup)
                 && (orderPointSt1.BLGroupCode == orderPointSt2.BLGroupCode)
                 && (orderPointSt1.BLGoodsCode == orderPointSt2.BLGoodsCode)
                 && (orderPointSt1.StckShipMonthSt == orderPointSt2.StckShipMonthSt)
                 && (orderPointSt1.StckShipMonthEd == orderPointSt2.StckShipMonthEd)
                 && (orderPointSt1.OrderApplyDiv == orderPointSt2.OrderApplyDiv)
                 && (orderPointSt1.StockCreateDate == orderPointSt2.StockCreateDate)
                 && (orderPointSt1.ShipScopeMore == orderPointSt2.ShipScopeMore)
                 && (orderPointSt1.ShipScopeLess == orderPointSt2.ShipScopeLess)
                 && (orderPointSt1.MinimumStockCnt == orderPointSt2.MinimumStockCnt)
                 && (orderPointSt1.MaximumStockCnt == orderPointSt2.MaximumStockCnt)
                 && (orderPointSt1.SalesOrderUnit == orderPointSt2.SalesOrderUnit)
                 && (orderPointSt1.OrderPProcUpdFlg == orderPointSt2.OrderPProcUpdFlg)
                 && (orderPointSt1.EnterpriseName == orderPointSt2.EnterpriseName)
                 && (orderPointSt1.UpdEmployeeName == orderPointSt2.UpdEmployeeName));
        }
        /// <summary>
        /// 発注点設定マスタ比較処理
        /// </summary>
        /// <param name="target">比較対象のOrderPointStクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   OrderPointStクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList Compare(OrderPointSt target)
        {
            ArrayList resList = new ArrayList();
            if (this.CreateDateTime != target.CreateDateTime) resList.Add("CreateDateTime");
            if (this.UpdateDateTime != target.UpdateDateTime) resList.Add("UpdateDateTime");
            if (this.EnterpriseCode != target.EnterpriseCode) resList.Add("EnterpriseCode");
            if (this.FileHeaderGuid != target.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (this.UpdEmployeeCode != target.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (this.UpdAssemblyId1 != target.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (this.UpdAssemblyId2 != target.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (this.LogicalDeleteCode != target.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (this.PatterNo != target.PatterNo) resList.Add("PatterNo");
            if (this.PatternNoDerivedNo != target.PatternNoDerivedNo) resList.Add("PatternNoDerivedNo");
            if (this.WarehouseCode != target.WarehouseCode) resList.Add("WarehouseCode");
            if (this.SupplierCd != target.SupplierCd) resList.Add("SupplierCd");
            if (this.GoodsMakerCd != target.GoodsMakerCd) resList.Add("GoodsMakerCd");
            if (this.GoodsMGroup != target.GoodsMGroup) resList.Add("GoodsMGroup");
            if (this.BLGroupCode != target.BLGroupCode) resList.Add("BLGroupCode");
            if (this.BLGoodsCode != target.BLGoodsCode) resList.Add("BLGoodsCode");
            if (this.StckShipMonthSt != target.StckShipMonthSt) resList.Add("StckShipMonthSt");
            if (this.StckShipMonthEd != target.StckShipMonthEd) resList.Add("StckShipMonthEd");
            if (this.OrderApplyDiv != target.OrderApplyDiv) resList.Add("OrderApplyDiv");
            if (this.StockCreateDate != target.StockCreateDate) resList.Add("StockCreateDate");
            if (this.ShipScopeMore != target.ShipScopeMore) resList.Add("ShipScopeMore");
            if (this.ShipScopeLess != target.ShipScopeLess) resList.Add("ShipScopeLess");
            if (this.MinimumStockCnt != target.MinimumStockCnt) resList.Add("MinimumStockCnt");
            if (this.MaximumStockCnt != target.MaximumStockCnt) resList.Add("MaximumStockCnt");
            if (this.SalesOrderUnit != target.SalesOrderUnit) resList.Add("SalesOrderUnit");
            if (this.OrderPProcUpdFlg != target.OrderPProcUpdFlg) resList.Add("OrderPProcUpdFlg");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            if (this.UpdEmployeeName != target.UpdEmployeeName) resList.Add("UpdEmployeeName");

            return resList;
        }

        /// <summary>
        /// 発注点設定マスタ比較処理
        /// </summary>
        /// <param name="orderPointSt1">比較するOrderPointStクラスのインスタンス</param>
        /// <param name="orderPointSt2">比較するOrderPointStクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   OrderPointStクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static ArrayList Compare(OrderPointSt orderPointSt1, OrderPointSt orderPointSt2)
        {
            ArrayList resList = new ArrayList();
            if (orderPointSt1.CreateDateTime != orderPointSt2.CreateDateTime) resList.Add("CreateDateTime");
            if (orderPointSt1.UpdateDateTime != orderPointSt2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (orderPointSt1.EnterpriseCode != orderPointSt2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (orderPointSt1.FileHeaderGuid != orderPointSt2.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (orderPointSt1.UpdEmployeeCode != orderPointSt2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (orderPointSt1.UpdAssemblyId1 != orderPointSt2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (orderPointSt1.UpdAssemblyId2 != orderPointSt2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (orderPointSt1.LogicalDeleteCode != orderPointSt2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (orderPointSt1.PatterNo != orderPointSt2.PatterNo) resList.Add("PatterNo");
            if (orderPointSt1.PatternNoDerivedNo != orderPointSt2.PatternNoDerivedNo) resList.Add("PatternNoDerivedNo");
            if (orderPointSt1.WarehouseCode != orderPointSt2.WarehouseCode) resList.Add("WarehouseCode");
            if (orderPointSt1.SupplierCd != orderPointSt2.SupplierCd) resList.Add("SupplierCd");
            if (orderPointSt1.GoodsMakerCd != orderPointSt2.GoodsMakerCd) resList.Add("GoodsMakerCd");
            if (orderPointSt1.GoodsMGroup != orderPointSt2.GoodsMGroup) resList.Add("GoodsMGroup");
            if (orderPointSt1.BLGroupCode != orderPointSt2.BLGroupCode) resList.Add("BLGroupCode");
            if (orderPointSt1.BLGoodsCode != orderPointSt2.BLGoodsCode) resList.Add("BLGoodsCode");
            if (orderPointSt1.StckShipMonthSt != orderPointSt2.StckShipMonthSt) resList.Add("StckShipMonthSt");
            if (orderPointSt1.StckShipMonthEd != orderPointSt2.StckShipMonthEd) resList.Add("StckShipMonthEd");
            if (orderPointSt1.OrderApplyDiv != orderPointSt2.OrderApplyDiv) resList.Add("OrderApplyDiv");
            if (orderPointSt1.StockCreateDate != orderPointSt2.StockCreateDate) resList.Add("StockCreateDate");
            if (orderPointSt1.ShipScopeMore != orderPointSt2.ShipScopeMore) resList.Add("ShipScopeMore");
            if (orderPointSt1.ShipScopeLess != orderPointSt2.ShipScopeLess) resList.Add("ShipScopeLess");
            if (orderPointSt1.MinimumStockCnt != orderPointSt2.MinimumStockCnt) resList.Add("MinimumStockCnt");
            if (orderPointSt1.MaximumStockCnt != orderPointSt2.MaximumStockCnt) resList.Add("MaximumStockCnt");
            if (orderPointSt1.SalesOrderUnit != orderPointSt2.SalesOrderUnit) resList.Add("SalesOrderUnit");
            if (orderPointSt1.OrderPProcUpdFlg != orderPointSt2.OrderPProcUpdFlg) resList.Add("OrderPProcUpdFlg");
            if (orderPointSt1.EnterpriseName != orderPointSt2.EnterpriseName) resList.Add("EnterpriseName");
            if (orderPointSt1.UpdEmployeeName != orderPointSt2.UpdEmployeeName) resList.Add("UpdEmployeeName");

            return resList;
        }
    }
}
