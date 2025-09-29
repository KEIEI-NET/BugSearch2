using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   MTtlSalesStockSlipWork4
    /// <summary>
    ///                      売上仕入月次集計データ(在庫移動用)ワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   売上仕入月次集計データ(在庫移動用)ワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/08/01  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class MTtlSalesStockSlipWork4 : System.IComparable
    {
        /// <summary>計上拠点コード</summary>
        /// <remarks>在庫移動データの移動先拠点コード</remarks>
        private string _addUpSecCode = "";

        /// <summary>計上年月</summary>
        /// <remarks>出荷確定日または入荷確定日から取得</remarks>
        private Int32 _addUpYearMonth;

        /// <summary>実績集計区分</summary>
        /// <remarks>0：合計 1：在庫</remarks>
        private Int32 _rsltTtlDivCd;

        /// <summary>仕入先コード</summary>
        private Int32 _supplierCd;

        /// <summary>移動状態</summary>
        /// <remarks>0:移動対象外、1:未出荷状態、2:移動中、9:入荷済</remarks>
        private Int32 _moveStatus;

        /// <summary>移動数</summary>
        private Double _moveCount;

        /// <summary>仕入単価（税抜,浮動）</summary>
        /// <remarks>在庫移動する在庫の仕入価格情報をセット</remarks>
        private Double _stockUnitPriceFl;

        /// <summary>出荷予定日</summary>
        /// <remarks>在庫移動処理（出荷側）を行った時にセット</remarks>
        private Int32 _shipmentScdlDay;

        /// <summary>出荷確定日</summary>
        /// <remarks>出荷確定処理（出荷側）を行った時にセット</remarks>
        private Int32 _shipmentFixDay;

        /// <summary>入荷日</summary>
        /// <remarks>在庫移動処理（入荷側）を行った時にセット</remarks>
        private Int32 _arrivalGoodsDay;

        /// <summary>マッチング状態</summary>
        /// <remarks>0:unmatched、1:matched</remarks>
        private Int32 _matchingStatus;


        /// public propaty name  :  AddUpSecCode
        /// <summary>計上拠点コードプロパティ</summary>
        /// <value>在庫移動データの移動先拠点コード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   計上拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AddUpSecCode
        {
            get { return _addUpSecCode; }
            set { _addUpSecCode = value; }
        }

        /// public propaty name  :  AddUpYearMonth
        /// <summary>計上年月プロパティ</summary>
        /// <value>出荷確定日または入荷確定日から取得</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   計上年月プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AddUpYearMonth
        {
            get { return _addUpYearMonth; }
            set { _addUpYearMonth = value; }
        }

        /// public propaty name  :  RsltTtlDivCd
        /// <summary>実績集計区分プロパティ</summary>
        /// <value>0：合計 1：在庫</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   実績集計区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 RsltTtlDivCd
        {
            get { return _rsltTtlDivCd; }
            set { _rsltTtlDivCd = value; }
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

        /// public propaty name  :  MoveStatus
        /// <summary>移動状態プロパティ</summary>
        /// <value>0:移動対象外、1:未出荷状態、2:移動中、9:入荷済</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   移動状態プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 MoveStatus
        {
            get { return _moveStatus; }
            set { _moveStatus = value; }
        }

        /// public propaty name  :  MoveCount
        /// <summary>移動数プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   移動数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double MoveCount
        {
            get { return _moveCount; }
            set { _moveCount = value; }
        }

        /// public propaty name  :  StockUnitPriceFl
        /// <summary>仕入単価（税抜,浮動）プロパティ</summary>
        /// <value>在庫移動する在庫の仕入価格情報をセット</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入単価（税抜,浮動）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double StockUnitPriceFl
        {
            get { return _stockUnitPriceFl; }
            set { _stockUnitPriceFl = value; }
        }

        /// public propaty name  :  ShipmentScdlDay
        /// <summary>出荷予定日プロパティ</summary>
        /// <value>在庫移動処理（出荷側）を行った時にセット</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   出荷予定日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ShipmentScdlDay
        {
            get { return _shipmentScdlDay; }
            set { _shipmentScdlDay = value; }
        }

        /// public propaty name  :  ShipmentFixDay
        /// <summary>出荷確定日プロパティ</summary>
        /// <value>出荷確定処理（出荷側）を行った時にセット</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   出荷確定日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ShipmentFixDay
        {
            get { return _shipmentFixDay; }
            set { _shipmentFixDay = value; }
        }

        /// public propaty name  :  ArrivalGoodsDay
        /// <summary>入荷日プロパティ</summary>
        /// <value>在庫移動処理（入荷側）を行った時にセット</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入荷日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ArrivalGoodsDay
        {
            get { return _arrivalGoodsDay; }
            set { _arrivalGoodsDay = value; }
        }

        /// public propaty name  :  MatchingStatus
        /// <summary>マッチング状態プロパティ</summary>
        /// <value>0:unmatched、1:matched</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   マッチング状態プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 MatchingStatus
        {
            get { return _matchingStatus; }
            set { _matchingStatus = value; }
        }


        /// <summary>
        /// 売上仕入月次集計データ(在庫移動用)ワークコンストラクタ
        /// </summary>
        /// <returns>MTtlSalesStockSlip4Workクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   MTtlSalesStockSlip4Workクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public MTtlSalesStockSlipWork4()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        /// <remarks>
        /// System.IComparableのCompareToメソッドの実装
        /// </remarks>
        public int CompareTo(object obj)
        {
            // this > object	:	正の値を返す。
            // this == object	:	0を返す。
            // this < object	:	負の値を返す
            int result;
            if ((result = this.AddUpSecCode.CompareTo(((MTtlSalesStockSlipWork4)obj).AddUpSecCode)) != 0) return result;
            if ((this.AddUpYearMonth - ((MTtlSalesStockSlipWork4)obj).AddUpYearMonth) != 0) return result;
            if ((this.RsltTtlDivCd - ((MTtlSalesStockSlipWork4)obj).RsltTtlDivCd) != 0) return result;
            return this.SupplierCd - ((MTtlSalesStockSlipWork4)obj).SupplierCd;
        }


    }

}

