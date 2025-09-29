using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
    /// public class name:   StockCarEnterCarOutRet
    /// <summary>
    ///                      在庫入出庫照会抽出結果クラス
    /// </summary>
    /// <remarks>
    /// <br>note             :   在庫入出庫照会抽出結果クラスヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/07/24  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class StockCarEnterCarOutRet
    {
        /// <summary>在庫総数</summary>
        /// <remarks>履歴開始年月からの総在庫数</remarks>
        private Double _stockTotal;

        /// <summary>入荷数</summary>
        /// <remarks>受払開始年月日からの総入荷数</remarks>
        private Double _arrivalCnt;

        /// <summary>出荷数</summary>
        /// <remarks>受払開始年月日からの総出荷数</remarks>
        private Double _shipmentCnt;

        /// <summary>残数</summary>
        /// <remarks>履歴開始年月からの総在庫数＋受払開始年月日から開始入出荷日までの総入荷数ー受払開始年月日から開始入出荷日までの総出荷数</remarks>
        private Double _remainCount;


        /// public propaty name  :  StockTotal
        /// <summary>在庫総数プロパティ</summary>
        /// <value>履歴開始年月からの総在庫数</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   在庫総数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double StockTotal
        {
            get { return _stockTotal; }
            set { _stockTotal = value; }
        }

        /// public propaty name  :  ArrivalCnt
        /// <summary>入荷数プロパティ</summary>
        /// <value>受払開始年月日からの総入荷数</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入荷数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double ArrivalCnt
        {
            get { return _arrivalCnt; }
            set { _arrivalCnt = value; }
        }

        /// public propaty name  :  ShipmentCnt
        /// <summary>出荷数プロパティ</summary>
        /// <value>受払開始年月日からの総出荷数</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   出荷数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double ShipmentCnt
        {
            get { return _shipmentCnt; }
            set { _shipmentCnt = value; }
        }

        /// public propaty name  :  RemainCount
        /// <summary>残数プロパティ</summary>
        /// <value>履歴開始年月からの総在庫数＋受払開始年月日から開始入出荷日までの総入荷数ー受払開始年月日から開始入出荷日までの総出荷数</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   残数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double RemainCount
        {
            get { return _remainCount; }
            set { _remainCount = value; }
        }


        /// <summary>
        /// 在庫入出庫照会抽出結果クラスコンストラクタ
        /// </summary>
        /// <returns>StockCarEnterCarOutRetクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockCarEnterCarOutRetクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public StockCarEnterCarOutRet()
        {
        }

        /// <summary>
        /// 在庫入出庫照会抽出結果クラスコンストラクタ
        /// </summary>
        /// <param name="stockTotal">在庫総数(履歴開始年月からの総在庫数)</param>
        /// <param name="arrivalCnt">入荷数(受払開始年月日からの総入荷数)</param>
        /// <param name="shipmentCnt">出荷数(受払開始年月日からの総出荷数)</param>
        /// <param name="remainCount">残数(履歴開始年月からの総在庫数＋受払開始年月日から開始入出荷日までの総入荷数ー受払開始年月日から開始入出荷日までの総出荷数)</param>
        /// <returns>StockCarEnterCarOutRetクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockCarEnterCarOutRetクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public StockCarEnterCarOutRet(Double stockTotal, Double arrivalCnt, Double shipmentCnt, Double remainCount)
        {
            this._stockTotal = stockTotal;
            this._arrivalCnt = arrivalCnt;
            this._shipmentCnt = shipmentCnt;
            this._remainCount = remainCount;

        }

        /// <summary>
        /// 在庫入出庫照会抽出結果クラス複製処理
        /// </summary>
        /// <returns>StockCarEnterCarOutRetクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいStockCarEnterCarOutRetクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public StockCarEnterCarOutRet Clone()
        {
            return new StockCarEnterCarOutRet(this._stockTotal, this._arrivalCnt, this._shipmentCnt, this._remainCount);
        }

        /// <summary>
        /// 在庫入出庫照会抽出結果クラス比較処理
        /// </summary>
        /// <param name="target">比較対象のStockCarEnterCarOutRetクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockCarEnterCarOutRetクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool Equals(StockCarEnterCarOutRet target)
        {
            return ((this.StockTotal == target.StockTotal)
                 && (this.ArrivalCnt == target.ArrivalCnt)
                 && (this.ShipmentCnt == target.ShipmentCnt)
                 && (this.RemainCount == target.RemainCount));
        }

        /// <summary>
        /// 在庫入出庫照会抽出結果クラス比較処理
        /// </summary>
        /// <param name="stockCarEnterCarOutRet1">
        ///                    比較するStockCarEnterCarOutRetクラスのインスタンス
        /// </param>
        /// <param name="stockCarEnterCarOutRet2">比較するStockCarEnterCarOutRetクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockCarEnterCarOutRetクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static bool Equals(StockCarEnterCarOutRet stockCarEnterCarOutRet1, StockCarEnterCarOutRet stockCarEnterCarOutRet2)
        {
            return ((stockCarEnterCarOutRet1.StockTotal == stockCarEnterCarOutRet2.StockTotal)
                 && (stockCarEnterCarOutRet1.ArrivalCnt == stockCarEnterCarOutRet2.ArrivalCnt)
                 && (stockCarEnterCarOutRet1.ShipmentCnt == stockCarEnterCarOutRet2.ShipmentCnt)
                 && (stockCarEnterCarOutRet1.RemainCount == stockCarEnterCarOutRet2.RemainCount));
        }
        /// <summary>
        /// 在庫入出庫照会抽出結果クラス比較処理
        /// </summary>
        /// <param name="target">比較対象のStockCarEnterCarOutRetクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockCarEnterCarOutRetクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList Compare(StockCarEnterCarOutRet target)
        {
            ArrayList resList = new ArrayList();
            if (this.StockTotal != target.StockTotal) resList.Add("StockTotal");
            if (this.ArrivalCnt != target.ArrivalCnt) resList.Add("ArrivalCnt");
            if (this.ShipmentCnt != target.ShipmentCnt) resList.Add("ShipmentCnt");
            if (this.RemainCount != target.RemainCount) resList.Add("RemainCount");

            return resList;
        }

        /// <summary>
        /// 在庫入出庫照会抽出結果クラス比較処理
        /// </summary>
        /// <param name="stockCarEnterCarOutRet1">比較するStockCarEnterCarOutRetクラスのインスタンス</param>
        /// <param name="stockCarEnterCarOutRet2">比較するStockCarEnterCarOutRetクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockCarEnterCarOutRetクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static ArrayList Compare(StockCarEnterCarOutRet stockCarEnterCarOutRet1, StockCarEnterCarOutRet stockCarEnterCarOutRet2)
        {
            ArrayList resList = new ArrayList();
            if (stockCarEnterCarOutRet1.StockTotal != stockCarEnterCarOutRet2.StockTotal) resList.Add("StockTotal");
            if (stockCarEnterCarOutRet1.ArrivalCnt != stockCarEnterCarOutRet2.ArrivalCnt) resList.Add("ArrivalCnt");
            if (stockCarEnterCarOutRet1.ShipmentCnt != stockCarEnterCarOutRet2.ShipmentCnt) resList.Add("ShipmentCnt");
            if (stockCarEnterCarOutRet1.RemainCount != stockCarEnterCarOutRet2.RemainCount) resList.Add("RemainCount");

            return resList;
        }
    }
}