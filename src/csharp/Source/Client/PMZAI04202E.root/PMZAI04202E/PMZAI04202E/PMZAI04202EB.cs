using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   MTtlSalesSlip
    /// <summary>
    ///                      在庫マスタ棚卸表示データ
    /// </summary>
    /// <remarks>
    /// <br>note             :   在庫マスタ棚卸表示データヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2008/11/17</br>
    /// <br>Genarated Date   :   </br>
    /// <br>Update Note      :   2014/03/05 田建委</br>
    /// <br>                 :   Redmine#42247 印刷機能の追加</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class InventoryDataDspResult
    {
        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>表示タイプ</summary>
        /// <remarks>0:通常,1:ｱｲﾃﾑ数=0はｶｳﾝﾄしない,2:最大</remarks>
        private Int32 _listTypeDiv;

        /// <summary>倉庫名称</summary>
        private string _warehouseName;

        /// <summary>棚卸アイテム数</summary>
        private Int32 _inventoryItemCnt;

        /// <summary>棚卸金額</summary>
        private Double _inventoryMony;

        /// <summary>最大棚卸金額</summary>
        private Double _maximuminventoryMony;

        /// <summary>差額</summary>
        private Double _balanceMony;

        //----- ADD 2014/03/05 田建委 Redmine#42247 ---------->>>>>
        /// <summary>倉庫コード</summary>
        private string _warehouseCode = "";
        //----- ADD 2014/03/05 田建委 Redmine#42247 ----------<<<<<

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

        /// public propaty name  :  ListTypeDiv
        /// <summary>表示タイププロパティ</summary>
        /// <value>0:通常,1:ｱｲﾃﾑ数=0はｶｳﾝﾄしない,2:最大</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   表示タイププロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ListTypeDiv
        {
            get { return _listTypeDiv; }
            set { _listTypeDiv = value; }
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

        /// public propaty name  :  InventoryItemCnt
        /// <summary>棚卸アイテム数プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   棚卸アイテム数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 InventoryItemCnt
        {
            get { return _inventoryItemCnt; }
            set { _inventoryItemCnt = value; }
        }

        /// public propaty name  :  InventoryMony
        /// <summary>棚卸金額プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   棚卸金額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double InventoryMony
        {
            get { return _inventoryMony; }
            set { _inventoryMony = value; }
        }

        /// public propaty name  :  MaximuminventoryMony
        /// <summary>最高棚卸金額プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   最高棚卸金額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double MaximuminventoryMony
        {
            get { return _maximuminventoryMony; }
            set { _maximuminventoryMony = value; }
        }

        /// public propaty name  :  BalanceMony
        /// <summary>差額プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   差額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double BalanceMony
        {
            get { return _balanceMony; }
            set { _balanceMony = value; }
        }

        //----- ADD 2014/03/05 田建委 Redmine#42247 ---------->>>>>
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
        //----- ADD 2014/03/05 田建委 Redmine#42247 ----------<<<<<

        /// <summary>
        /// 売上月次集計データコンストラクタ
        /// </summary>
        /// <returns>ShipmentPartsDspResultクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   ShipmentPartsDspResultクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public InventoryDataDspResult()
        {
        }

        /// <summary>
        /// 在庫マスタ(棚卸表示)データコンストラクタ
        /// </summary>
        /// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
        /// <param name="rsltTtlDivCd">実績集計区分(0:部品合計 1:在庫 2:純正 3:作業)</param>
        /// <param name="salesTimes">売上回数(出荷回数(売上時のみ）)</param>
        /// <param name="salesMoney">売上金額(税抜き（値引,返品含まず）)</param>
        /// <param name="grossProfit">粗利金額</param>
        /// <param name="warehouseCode">倉庫コード</param>
        /// <returns>ShipmentPartsDspResultクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   ShipmentPartsDspResultクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// <br>Update Note      :   2014/03/05 田建委</br>
        /// <br>                 :   Redmine#42247 印刷機能の追加</br>
        /// </remarks>
        //public InventoryDataDspResult(string enterpriseCode, string warehouseName, Int32 inventoryItemCnt, double inventoryMony, double maximumInventoryMony, double balanceMony) // DEL 2014/03/05 田建委 Redmine#42247
        public InventoryDataDspResult(string enterpriseCode, string warehouseName, Int32 inventoryItemCnt, double inventoryMony, double maximumInventoryMony, double balanceMony, string warehouseCode) // ADD 2014/03/05 田建委 Redmine#42247
        {
            this._enterpriseCode = enterpriseCode;
            this._warehouseName = warehouseName;
            this._inventoryItemCnt = inventoryItemCnt;
            this._inventoryMony = inventoryMony;
            this._maximuminventoryMony = maximumInventoryMony;
            this._balanceMony = balanceMony;
            this._warehouseCode = warehouseCode; // ADD 2014/03/05 田建委 Redmine#42247
        }

        /// <summary>
        /// データ複製処理
        /// </summary>
        /// <returns>ShipmentPartsDspResultクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいShipmentPartsDspResultクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// <br>Update Note      :   2014/03/05 田建委</br>
        /// <br>                 :   Redmine#42247 印刷機能の追加</br>
        /// </remarks>
        public InventoryDataDspResult Clone()
        {
            //return new InventoryDataDspResult(this._enterpriseCode, this._warehouseName, this._inventoryItemCnt, this._inventoryMony, this._maximuminventoryMony, this._balanceMony); // DEL 2014/03/05 田建委 Redmine#42247
            return new InventoryDataDspResult(this._enterpriseCode, this._warehouseName, this._inventoryItemCnt, this._inventoryMony, this._maximuminventoryMony, this._balanceMony, this._warehouseCode); // ADD 2014/03/05 田建委 Redmine#42247
        }

        /// <summary>
        ///在庫マスタ(棚卸表示)データ比較処理
        /// </summary>
        /// <param name="target">比較対象のInventoryDataDspResultクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   InventoryDataDspResultクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// <br>Update Note      :   2014/03/05 田建委</br>
        /// <br>                 :   Redmine#42247 印刷機能の追加</br>
        /// </remarks>
        public bool Equals(InventoryDataDspResult target)
        {
            return ((this.EnterpriseCode == target.EnterpriseCode)
                 && (this._warehouseName == target.WarehouseName)
                 && (this._inventoryItemCnt == target.InventoryItemCnt)
                 && (this._inventoryMony == target.InventoryMony)
                 && (this._maximuminventoryMony == target.MaximuminventoryMony)
                 && (this._warehouseCode == target.WarehouseCode) // ADD 2014/03/05 田建委 Redmine#42247
                 && (this._balanceMony == target.BalanceMony));
        }

        /// <summary>
        /// 在庫マスタ(棚卸表示)データ比較処理
        /// </summary>
        /// <param name="ShipmentPartsDspResult">
        ///                    比較するShipmentPartsDspResultクラスのインスタンス
        /// </param>
        /// <param name="mTtlSalesSlip2">比較するShipmentPartsDspResultクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   ShipmentPartsDspResultクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// <br>Update Note      :   2014/03/05 田建委</br>
        /// <br>                 :   Redmine#42247 印刷機能の追加</br>
        /// </remarks>
        public static bool Equals(InventoryDataDspResult inventoryData1, InventoryDataDspResult inventoryData2)
        {
            return ((inventoryData1.EnterpriseCode == inventoryData2.EnterpriseCode)
                 && (inventoryData1.WarehouseName == inventoryData2.WarehouseName)
                 && (inventoryData1.InventoryItemCnt == inventoryData2.InventoryItemCnt)
                 && (inventoryData1.InventoryMony == inventoryData2.InventoryMony)
                 && (inventoryData1.MaximuminventoryMony == inventoryData2.MaximuminventoryMony)
                 && (inventoryData1.WarehouseCode == inventoryData2.WarehouseCode) // ADD 2014/03/05 田建委 Redmine#42247
                 && (inventoryData1.BalanceMony == inventoryData2.BalanceMony));
        }
        /// <summary>
        /// 在庫マスタ(棚卸表示)データ比較処理
        /// </summary>
        /// <param name="target">比較対象のShipmentPartsDspResultクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   ShipmentPartsDspResultクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// <br>Update Note      :   2014/03/05 田建委</br>
        /// <br>                 :   Redmine#42247 印刷機能の追加</br>
        /// </remarks>
        public ArrayList Compare(InventoryDataDspResult target)
        {
            ArrayList resList = new ArrayList();
            if (this.EnterpriseCode != target.EnterpriseCode) resList.Add("EnterpriseCode");
            if (this.WarehouseName != target.WarehouseName) resList.Add("WarehouseName");
            if (this.InventoryItemCnt != target.InventoryItemCnt) resList.Add("InbentoryItemCnt");
            if (this.InventoryMony != target.InventoryMony) resList.Add("InventoryMony");
            if (this.MaximuminventoryMony != target.MaximuminventoryMony) resList.Add("MaximuminventoryMony");
            if (this.BalanceMony != target.BalanceMony) resList.Add("BalanceMony");
            if (this.WarehouseCode != target.WarehouseCode) resList.Add("WarehouseCode"); // ADD 2014/03/05 田建委 Redmine#42247
            return resList;
        }

        /// <summary>
        /// 売上月次集計データ比較処理
        /// </summary>
        /// <param name="shipmentPartsDspResult1">比較するShipmentPartsDspResultクラスのインスタンス</param>
        /// <param name="shipmentPartsDspResult2">比較するShipmentPartsDspResultクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   MTtlSalesSlipクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// <br>Update Note      :   2014/03/05 田建委</br>
        /// <br>                 :   Redmine#42247 印刷機能の追加</br>
        /// </remarks>
        public static ArrayList Compare(InventoryDataDspResult InventoryDataDsp1, InventoryDataDspResult InventoryDataDsp2)
        {
            ArrayList resList = new ArrayList();
            if (InventoryDataDsp1.EnterpriseCode != InventoryDataDsp2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (InventoryDataDsp1.WarehouseName != InventoryDataDsp2.WarehouseName) resList.Add("WarehouseName");
            if (InventoryDataDsp1.InventoryItemCnt != InventoryDataDsp2.InventoryItemCnt) resList.Add("InventoryItemCnt");
            if (InventoryDataDsp1.InventoryMony != InventoryDataDsp2.InventoryMony) resList.Add("InventoryMony");
            if (InventoryDataDsp1.MaximuminventoryMony != InventoryDataDsp2.MaximuminventoryMony) resList.Add("MaximuminventoryMony");
            if (InventoryDataDsp1.BalanceMony != InventoryDataDsp2.BalanceMony) resList.Add("BalanceMony");
            if (InventoryDataDsp1.WarehouseCode != InventoryDataDsp2.WarehouseCode) resList.Add("WarehouseCode"); // ADD 2014/03/05 田建委 Redmine#42247

            return resList;
        }
    }
}
