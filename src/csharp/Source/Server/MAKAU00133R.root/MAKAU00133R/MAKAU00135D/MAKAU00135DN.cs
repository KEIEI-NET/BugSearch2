using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   MTtlSalesStockSlipWork3
    /// <summary>
    ///                      売上仕入月次集計データ(仕入用)ワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   売上仕入月次集計データ(仕入用)ワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/08/01  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class MTtlSalesStockSlipWork3 : System.IComparable
    {
        /// <summary>計上拠点コード</summary>
        /// <remarks>仕入データの仕入拠点コード</remarks>
        private string _addUpSecCode = "";

        /// <summary>計上年月</summary>
        /// <remarks>売上日付から取得</remarks>
        private Int32 _addUpYearMonth;

        /// <summary>実績集計区分</summary>
        /// <remarks>0：合計 1：在庫</remarks>
        private Int32 _rsltTtlDivCd;

        /// <summary>仕入先コード</summary>
        private Int32 _supplierCd;

        /// <summary>赤伝区分</summary>
        /// <remarks>0:黒伝,1:赤伝,2:元黒</remarks>
        private Int32 _debitNoteDiv;

        /// <summary>仕入在庫取寄せ区分</summary>
        /// <remarks>0:取寄せ,1:在庫</remarks>
        private Int32 _stockOrderDivCd;

        /// <summary>仕入伝票区分（明細）</summary>
        /// <remarks>0:仕入,1:返品,2:値引</remarks>
        private Int32 _stockSlipCdDtl;

        /// <summary>仕入数</summary>
        private Double _stockCount;

        /// <summary>仕入金額（税抜き）</summary>
        private Int64 _stockPriceTaxExc;

        /// <summary>仕入日</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _stockDate;

        /// <summary>マッチング状態</summary>
        /// <remarks>0:unmatched、1:matched</remarks>
        private Int32 _matchingStatus;


        /// public propaty name  :  AddUpSecCode
        /// <summary>計上拠点コードプロパティ</summary>
        /// <value>仕入データの仕入拠点コード</value>
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
        /// <value>売上日付から取得</value>
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

        /// public propaty name  :  DebitNoteDiv
        /// <summary>赤伝区分プロパティ</summary>
        /// <value>0:黒伝,1:赤伝,2:元黒</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   赤伝区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DebitNoteDiv
        {
            get { return _debitNoteDiv; }
            set { _debitNoteDiv = value; }
        }

        /// public propaty name  :  StockOrderDivCd
        /// <summary>仕入在庫取寄せ区分プロパティ</summary>
        /// <value>0:取寄せ,1:在庫</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入在庫取寄せ区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 StockOrderDivCd
        {
            get { return _stockOrderDivCd; }
            set { _stockOrderDivCd = value; }
        }

        /// public propaty name  :  StockSlipCdDtl
        /// <summary>仕入伝票区分（明細）プロパティ</summary>
        /// <value>0:仕入,1:返品,2:値引</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入伝票区分（明細）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 StockSlipCdDtl
        {
            get { return _stockSlipCdDtl; }
            set { _stockSlipCdDtl = value; }
        }

        /// public propaty name  :  StockCount
        /// <summary>仕入数プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double StockCount
        {
            get { return _stockCount; }
            set { _stockCount = value; }
        }

        /// public propaty name  :  StockPriceTaxExc
        /// <summary>仕入金額（税抜き）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入金額（税抜き）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 StockPriceTaxExc
        {
            get { return _stockPriceTaxExc; }
            set { _stockPriceTaxExc = value; }
        }

        /// public propaty name  :  StockDate
        /// <summary>仕入日プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 StockDate
        {
            get { return _stockDate; }
            set { _stockDate = value; }
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
        /// 売上仕入月次集計データ(仕入用)ワークコンストラクタ
        /// </summary>
        /// <returns>MTtlSalesStockSlip3Workクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   MTtlSalesStockSlip3Workクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public MTtlSalesStockSlipWork3()
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
            if ((result = this.AddUpSecCode.CompareTo(((MTtlSalesStockSlipWork3)obj).AddUpSecCode)) != 0) return result;
            if ((this.AddUpYearMonth - ((MTtlSalesStockSlipWork3)obj).AddUpYearMonth) != 0) return result;
            if ((this.RsltTtlDivCd - ((MTtlSalesStockSlipWork3)obj).RsltTtlDivCd) != 0) return result;
            return this.SupplierCd - ((MTtlSalesStockSlipWork3)obj).SupplierCd;
        }


    }

}

