//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 検品照会条件ワーク
// プログラム概要   : 検品照会条件ワークです
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11370006-00 作成担当 : 陳艶丹
// 作 成 日  2017/07/20  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号  11370074-00 作成担当 : 3H 張小磊                               
// 修 正 日  2017/09/07  修正内容 : 検品照会の変更対応
//----------------------------------------------------------------------------//

using System;
using System.Collections;

using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   HandyInspectParamWork
    /// <summary>
    ///                      検品照会条件ワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   検品照会条件ワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2017/07/20</br>
    /// <br>Genarated Date   :   2017/07/20  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2017/09/07 3H 張小磊</br>
    /// <br>　　　　　       :   検品照会の変更対応</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class HandyInspectParamWork
    {
        /// <summary>企業コード</summary>
        private string _enterpriseCode = "";

        /// <summary>取寄区分</summary>
        /// <remarks>含む/含まない</remarks>
        private Int32 _orderDivCd;

        /// <summary>ﾊﾟﾀｰﾝ</summary>
        /// <remarks>出庫検品/入庫検品/未入庫/検品のみ</remarks>
        private Int32 _pattern;

        /// <summary>商品メーカーコード</summary>
        private Int32 _goodsMakerCd;

        /// <summary>商品番号</summary>
        private string _goodsNo = "";

        /// <summary>倉庫コード</summary>
        /// <remarks>在庫管理なしは"0"</remarks>
        private string _warehouseCode = "";

        /// <summary>拠点コード</summary>
        private string _sectionCode = "";

        /// <summary>売上日付(開始)</summary>
        /// <remarks>売上日/出荷日</remarks>
        private DateTime _st_SalesDate;

        /// <summary>売上日付(終了)</summary>
        /// <remarks>売上日/出荷日</remarks>
        private DateTime _ed_SalesDate;

        /// <summary>検品日(開始)</summary>
        private DateTime _st_InspectDate;

        /// <summary>検品日(終了)</summary>
        private DateTime _ed_InspectDate;

        /// <summary>検索フィールド</summary>
        private string _searchStr = "";

        /// <summary>従業員コード</summary>
        /// <remarks>検品従業員</remarks>
        private string _employeeCode = "";

        /// <summary>品番検索タイプ</summary>
        /// <remarks>0:完全一致,1:前方一致検索,2:後方一致検索,3:曖昧検索</remarks>
        private Int32 _goodsNoSrchTyp;

        /// <summary>取引対象_売上</summary>
        /// <remarks>0：選択無し、1：選択有り</remarks>
        private Int32 _transSales;

        /// <summary>取引対象_貸出</summary>
        /// <remarks>0：選択無し、1：選択有り</remarks>
        private Int32 _transLend;

        // --- ADD 3H 張小磊 2017/09/07---------->>>>>
        /// <summary>委託先倉庫コード</summary>        
        private string _afWarehouseCd = "";     

        /// <summary>取引対象_移動出庫</summary>
        /// <remarks>0：選択無し、1：選択有り</remarks>
        private Int32 _transMoveOutWarehouse;

        /// <summary>取引対象_補充出庫</summary>
        /// <remarks>0：選択無し、1：選択有り</remarks>
        private Int32 _transReplenishOutWarehouse;

        /// <summary>取引対象_在庫仕入</summary>
        /// <remarks>0：選択無し、1：選択有り</remarks>
        private Int32 _transStockStockSlip;

        /// <summary>取引対象_仕入</summary>
        /// <remarks>0：選択無し、1：選択有り</remarks>
        private Int32 _transStockSlip;

        /// <summary>取引対象_移動入庫</summary>
        /// <remarks>0：選択無し、1：選択有り</remarks>
        private Int32 _transMoveInWarehouse;
        // --- ADD 3H 張小磊 2017/09/07----------<<<<<

        /// public propaty name  :  EnterpriseCode
        /// <summary>企業コードプロパティ</summary>
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

        /// public propaty name  :  OrderDivCd
        /// <summary>取寄区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   取寄区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 OrderDivCd
        {
            get { return _orderDivCd; }
            set { _orderDivCd = value; }
        }

        /// public propaty name  :  Pattern
        /// <summary>ﾊﾟﾀｰﾝプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ﾊﾟﾀｰﾝプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 Pattern
        {
            get { return _pattern; }
            set { _pattern = value; }
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

        /// public propaty name  :  WarehouseCode
        /// <summary>倉庫コードプロパティ</summary>
        /// <value>在庫管理なしは"0"</value>
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

        /// public propaty name  :  St_SalesDate
        /// <summary>売上日付(開始)プロパティ</summary>
        /// <value>受注日</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上日付(開始)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime St_SalesDate
        {
            get { return _st_SalesDate; }
            set { _st_SalesDate = value; }
        }

        /// public propaty name  :  Ed_SalesDate
        /// <summary>売上日付(終了)プロパティ</summary>
        /// <value>受注日</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上日付(終了)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime Ed_SalesDate
        {
            get { return _ed_SalesDate; }
            set { _ed_SalesDate = value; }
        }

        /// public propaty name  :  St_InspectDate
        /// <summary>検品日(開始)プロパティ</summary>
        /// <value>検品日</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   検品日(開始)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime St_InspectDate
        {
            get { return _st_InspectDate; }
            set { _st_InspectDate = value; }
        }

        /// public propaty name  :  Ed_InspectDate
        /// <summary>検品日(終了)プロパティ</summary>
        /// <value>検品日</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   検品日付(終了)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime Ed_InspectDate
        {
            get { return _ed_InspectDate; }
            set { _ed_InspectDate = value; }
        }

        /// public propaty name  :  SearchStr
        /// <summary>検索フィールドプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   検索フィールドプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SearchStr
        {
            get { return _searchStr; }
            set { _searchStr = value; }
        }

        /// public propaty name  :  EmployeeCode
        /// <summary>従業員コードプロパティ</summary>
        /// <value>検品従業員</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   従業員コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EmployeeCode
        {
            get { return _employeeCode; }
            set { _employeeCode = value; }
        }

        // public propaty name  :  GoodsNoSrchTyp
        /// <summary>品番検索タイププロパティ</summary>
        /// <value>0:完全一致,1:前方一致検索,2:後方一致検索,3:曖昧検索</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   品番検索タイププロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsNoSrchTyp
        {
            get { return _goodsNoSrchTyp; }
            set { _goodsNoSrchTyp = value; }
        }

        // public propaty name  :  TransSales
        /// <summary>取引対象_売上プロパティ</summary>
        /// <value>0：選択無し、1：選択有り</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   取引対象_売上プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 TransSales
        {
            get { return _transSales; }
            set { _transSales = value; }
        }

        // public propaty name  :  TransLend
        /// <summary>取引対象_貸出プロパティ</summary>
        /// <value>0：選択無し、1：選択有り</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   取引対象_貸出プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 TransLend
        {
            get { return _transLend; }
            set { _transLend = value; }
        }

        // --- ADD 3H 張小磊 2017/09/07---------->>>>>
        /// public propaty name  :  Mainmngwarehousecd
        /// <summary>委託先倉庫コード</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   委託先倉庫コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AfWarehouseCd
        {
            get { return _afWarehouseCd; }
            set { _afWarehouseCd = value; }
        }

        /// public propaty name  :  TransMoveOutWarehouse
        /// <summary>取引対象_移動出庫プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   取引対象_移動出庫プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 TransMoveOutWarehouse
        {
            get { return _transMoveOutWarehouse; }
            set { _transMoveOutWarehouse = value; }
        }

        /// public propaty name  :  TransReplenishOutWarehouse
        /// <summary>取引対象_補充出庫プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   取引対象_補充出庫プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 TransReplenishOutWarehouse
        {
            get { return _transReplenishOutWarehouse; }
            set { _transReplenishOutWarehouse = value; }
        }

        /// public propaty name  :  TransStockStockSlip
        /// <summary>取引対象_在庫仕入プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   取引対象_在庫仕入プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 TransStockStockSlip
        {
            get { return _transStockStockSlip; }
            set { _transStockStockSlip = value; }
        }

        /// public propaty name  :  TransStockSlip
        /// <summary>取引対象_仕入プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   取引対象_仕入プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 TransStockSlip
        {
            get { return _transStockSlip; }
            set { _transStockSlip = value; }
        }

        /// public propaty name  :  TransMoveInWarehouse
        /// <summary>取引対象_移動入庫プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   取引対象_移動入庫プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 TransMoveInWarehouse
        {
            get { return _transMoveInWarehouse; }
            set { _transMoveInWarehouse = value; }
        }
        // --- ADD 3H 張小磊 2017/09/07----------<<<<<

        /// <summary>
        /// 検品照会条件ワークコンストラクタ
        /// </summary>
        /// <returns>HandyInspectParamWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   HandyInspectParamWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public HandyInspectParamWork()
        {
        }

    }
}
