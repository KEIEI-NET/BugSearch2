//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : ハンディターミナル棚卸データ条件ワーク
// プログラム概要   : ハンディターミナル棚卸データ条件ワークです
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11370074-00 作成担当 : 陳艶丹
// 作 成 日  2017/08/16  修正内容 : 新規作成
//----------------------------------------------------------------------------//

using System;
using System.Collections;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   HandyInventoryCondWork
    /// <summary>
    /// ハンディターミナル棚卸データ条件ワーク                     
    /// </summary>
    /// <remarks>
    /// <br>note             :  ハンディターミナル棚卸データ条件ワークヘッダファイル</br>
    /// <br>Programmer       :  自動生成</br>
    /// <br>Date             :  2017/08/16</br>
    /// <br>Genarated Date   :  2017/08/16  (CSharp File Generated Date)</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class HandyInventoryCondWork
    {
        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>従業員コード</summary>
        private string _employeeCode = "";

        /// <summary>コンピュータ名</summary>
        private string _machineName = "";

        /// <summary>倉庫コード(開始)</summary>
        private string _warehouseCode = "";

        /// <summary>倉庫コード(終了)</summary>
        private string _warehouseCodeEd = "";

        /// <summary>棚卸日</summary>
        private Int32 _inventoryDate;

        /// <summary>商品バーコード</summary>
        private string _goodsBarCode = "";

        /// <summary>処理区分</summary>
        private Int32 _procDiv;

        /// <summary>商品メーカーコード</summary>
        private Int32 _goodsMakerCd;

        /// <summary>商品番号</summary>
        private string _goodsNo = "";

        /// <summary>倉庫棚番</summary>
        private string _warehouseShelfNo = "";

        /// <summary>棚卸在庫数</summary>
        private Double _InventoryStockCnt;

        /// <summary>循環棚卸通番</summary>
        private Int32 _circulInventSeqNo;

        /// <summary>拠点コード</summary>
        private string _belongSectionCode = "";

        /// <summary>備考</summary>
        private string _note = "";

        /// <summary>初回フラグ</summary>
        /// <remarks>1：初回、2：次回以降</remarks>
        private Int32 _firstFlg;

        /// <summary>棚卸日(開始)</summary>
        private DateTime _inventoryDateStart;

        /// <summary>棚卸日(終了)</summary>
        private DateTime _inventoryDateEnd;

        /// <summary>品番検索タイプ</summary>
        /// <remarks>0:完全一致,1:前方一致検索,2:後方一致検索,3:曖昧検索</remarks>
        private Int32 _goodsNoSrchTyp;

        /// <summary>倉庫棚番(開始)</summary>
        private string _warehouseShelfNoStart = "";

        /// <summary>倉庫棚番(終了)</summary>
        private string _warehouseShelfNoEnd = "";

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

        /// public propaty name  :  EmployeeCode
        /// <summary>更新従業員コードプロパティ</summary>
        /// <value>共通ファイルヘッダ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新従業員コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EmployeeCode
        {
            get { return _employeeCode; }
            set { _employeeCode = value; }
        }

        /// public propaty name  :  MachineName
        /// <summary>コンピュータ名プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   コンピュータ名プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MachineName
        {
            get { return _machineName; }
            set { _machineName = value; }
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

        /// public propaty name  :  WarehouseCodeEd
        /// <summary>倉庫コード(終了)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   倉庫コード(終了)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string WarehouseCodeEd
        {
            get { return _warehouseCodeEd; }
            set { _warehouseCodeEd = value; }
        }

        /// public propaty name  :  InventoryDate
        /// <summary>棚卸日プロパティ</summary>
        /// <value>棚卸日をセット</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   棚卸日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 InventoryDate
        {
            get { return _inventoryDate; }
            set { _inventoryDate = value; }
        }

        /// public propaty name  :  GoodsBarCode
        /// <summary>商品バーコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品バーコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsBarCode
        {
            get { return _goodsBarCode; }
            set { _goodsBarCode = value; }
        }

        /// public propaty name  :  ProcDiv
        /// <summary>処理区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   処理区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ProcDiv
        {
            get { return _procDiv; }
            set { _procDiv = value; }
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

        /// public propaty name  :  InventoryStockCnt
        /// <summary>棚卸在庫数プロパティ</summary>
        /// <value>棚卸数</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   棚卸在庫数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double InventoryStockCnt
        {
            get { return _InventoryStockCnt; }
            set { _InventoryStockCnt = value; }
        }

        /// public propaty name  :  CirculInventSeqNo
        /// <summary>循環棚卸通番プロパティ</summary>
        /// <value>循環棚卸通番</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   循環棚卸通番プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CirculInventSeqNo
        {
            get { return _circulInventSeqNo; }
            set { _circulInventSeqNo = value; }
        }

        /// public propaty name  :  BelongSectionCode
        /// <summary>拠点コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string BelongSectionCode
        {
            get { return _belongSectionCode; }
            set { _belongSectionCode = value; }
        }

        /// public propaty name  :  Note
        /// <summary>備考プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   備考プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string Note
        {
            get { return _note; }
            set { _note = value; }
        }

        /// public propaty name  :  FirstFlg
        /// <summary>初回フラグプロパティ</summary>
        /// <value>1：初回、2：次回以降</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   初回フラグプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 FirstFlg
        {
            get { return _firstFlg; }
            set { _firstFlg = value; }
        }

        /// public propaty name  :  InventoryDateStart
        /// <summary>棚卸日(開始)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   棚卸日(開始)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime InventoryDateStart
        {
            get { return _inventoryDateStart; }
            set { _inventoryDateStart = value; }
        }

        /// public propaty name  :  InventoryDateEnd
        /// <summary>棚卸日(終了)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   棚卸日(終了)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime InventoryDateEnd
        {
            get { return _inventoryDateEnd; }
            set { _inventoryDateEnd = value; }
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

        /// public propaty name  :  WarehouseShelfNoStart
        /// <summary>倉庫棚番(開始)プロパティ</summary>
        /// <value>倉庫棚番(開始)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   倉庫棚番(開始)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string WarehouseShelfNoStart
        {
            get { return _warehouseShelfNoStart; }
            set { _warehouseShelfNoStart = value; }
        }

        /// public propaty name  :  WarehouseShelfNoEnd
        /// <summary>倉庫棚番(終了)プロパティ</summary>
        /// <value>倉庫棚番(終了)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   倉庫棚番(終了)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string WarehouseShelfNoEnd
        {
            get { return _warehouseShelfNoEnd; }
            set { _warehouseShelfNoEnd = value; }
        }



        /// <summary>
        /// 棚卸処理（一斉）条件ワークコンストラクタ
        /// </summary>
        /// <returns>HandyInventoryCondWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   HandyInventoryCondWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public HandyInventoryCondWork()
        {
        }

    }
}
