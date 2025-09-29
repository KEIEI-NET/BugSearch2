using System;
using System.Collections;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   SearchMstCountWork
    /// <summary>
    ///                      送信件数ワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   送信件数ワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2008/9/29</br>
    /// <br>Genarated Date   :   2009/04/08  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class SearchMstCountWork
    {
        /// <summary>売上データCOUNT</summary>
        /// <remarks>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</remarks>
        private Int32 _salesSlipCount;

        /// <summary>売上明細データCOUNT</summary>
        private Int32 _salesDetailCount;

        /// <summary>売上履歴データCOUNT</summary>
        private Int32 _salesHistoryCount;

        /// <summary>売上履歴明細データCOUNT</summary>
        private Int32 _salesHistDtlCount;

        /// <summary>入金データCOUNT</summary>
        private Int32 _depsitMainCount;

        /// <summary>入金明細データCOUNT</summary>
        private Int32 _depsitDtlCount;

        /// <summary>仕入データCOUNT</summary>
        private Int32 _stockSlipCount;

        /// <summary>仕入明細データCOUNT</summary>
        private Int32 _stockDetailCount;

        /// <summary>仕入履歴データCOUNT</summary>
        private Int32 _stockSlipHistCount;

        /// <summary>仕入履歴明細データCOUNT</summary>
        private Int32 _stockSlHistDtlCount;

        /// <summary>支払伝票マスタCOUNT</summary>
        private Int32 _paymentSlpCount;

        /// <summary>支払明細データCOUNT</summary>
        private Int32 _paymentDtlCount;

        /// <summary>受注マスタCOUNT</summary>
        private Int32 _acceptOdrCount;

        /// <summary>受注マスタ（車両）COUNT</summary>
        private Int32 _acceptOdrCarCount;

        /// <summary>売上月次集計データCOUNT</summary>
        private Int32 _mTtlSalesSlipCount;

        /// <summary>商品別売上月次集計データCOUNT</summary>
        private Int32 _goodsMTtlSaSlipCount;

        /// <summary>仕入月次集計データCOUNT</summary>
        private Int32 _mTtlStockSlipCount;


        /// public propaty name  :  SalesSlipCount
        /// <summary>売上データCOUNTプロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上データCOUNTプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SalesSlipCount
        {
            get { return _salesSlipCount; }
            set { _salesSlipCount = value; }
        }

        /// public propaty name  :  SalesDetailCount
        /// <summary>売上明細データCOUNTプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上明細データCOUNTプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SalesDetailCount
        {
            get { return _salesDetailCount; }
            set { _salesDetailCount = value; }
        }

        /// public propaty name  :  SalesHistoryCount
        /// <summary>売上履歴データCOUNTプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上履歴データCOUNTプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SalesHistoryCount
        {
            get { return _salesHistoryCount; }
            set { _salesHistoryCount = value; }
        }

        /// public propaty name  :  SalesHistDtlCount
        /// <summary>売上履歴明細データCOUNTプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上履歴明細データCOUNTプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SalesHistDtlCount
        {
            get { return _salesHistDtlCount; }
            set { _salesHistDtlCount = value; }
        }

        /// public propaty name  :  DepsitMainCount
        /// <summary>入金データCOUNTプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金データCOUNTプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DepsitMainCount
        {
            get { return _depsitMainCount; }
            set { _depsitMainCount = value; }
        }

        /// public propaty name  :  DepsitDtlCount
        /// <summary>入金明細データCOUNTプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金明細データCOUNTプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DepsitDtlCount
        {
            get { return _depsitDtlCount; }
            set { _depsitDtlCount = value; }
        }

        /// public propaty name  :  StockSlipCount
        /// <summary>仕入データCOUNTプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入データCOUNTプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 StockSlipCount
        {
            get { return _stockSlipCount; }
            set { _stockSlipCount = value; }
        }

        /// public propaty name  :  StockDetailCount
        /// <summary>仕入明細データCOUNTプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入明細データCOUNTプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 StockDetailCount
        {
            get { return _stockDetailCount; }
            set { _stockDetailCount = value; }
        }

        /// public propaty name  :  StockSlipHistCount
        /// <summary>仕入履歴データCOUNTプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入履歴データCOUNTプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 StockSlipHistCount
        {
            get { return _stockSlipHistCount; }
            set { _stockSlipHistCount = value; }
        }

        /// public propaty name  :  StockSlHistDtlCount
        /// <summary>仕入履歴明細データCOUNTプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入履歴明細データCOUNTプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 StockSlHistDtlCount
        {
            get { return _stockSlHistDtlCount; }
            set { _stockSlHistDtlCount = value; }
        }

        /// public propaty name  :  PaymentSlpCount
        /// <summary>支払伝票マスタCOUNTプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払伝票マスタCOUNTプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PaymentSlpCount
        {
            get { return _paymentSlpCount; }
            set { _paymentSlpCount = value; }
        }

        /// public propaty name  :  PaymentDtlCount
        /// <summary>支払明細データCOUNTプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払明細データCOUNTプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PaymentDtlCount
        {
            get { return _paymentDtlCount; }
            set { _paymentDtlCount = value; }
        }

        /// public propaty name  :  AcceptOdrCount
        /// <summary>受注マスタCOUNTプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   受注マスタCOUNTプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AcceptOdrCount
        {
            get { return _acceptOdrCount; }
            set { _acceptOdrCount = value; }
        }

        /// public propaty name  :  AcceptOdrCarCount
        /// <summary>受注マスタ（車両）COUNTプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   受注マスタ（車両）COUNTプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AcceptOdrCarCount
        {
            get { return _acceptOdrCarCount; }
            set { _acceptOdrCarCount = value; }
        }

        /// public propaty name  :  MTtlSalesSlipCount
        /// <summary>売上月次集計データCOUNTプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上月次集計データCOUNTプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 MTtlSalesSlipCount
        {
            get { return _mTtlSalesSlipCount; }
            set { _mTtlSalesSlipCount = value; }
        }

        /// public propaty name  :  GoodsMTtlSaSlipCount
        /// <summary>商品別売上月次集計データCOUNTプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品別売上月次集計データCOUNTプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsMTtlSaSlipCount
        {
            get { return _goodsMTtlSaSlipCount; }
            set { _goodsMTtlSaSlipCount = value; }
        }

        /// public propaty name  :  MTtlStockSlipCount
        /// <summary>仕入月次集計データCOUNTプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入月次集計データCOUNTプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 MTtlStockSlipCount
        {
            get { return _mTtlStockSlipCount; }
            set { _mTtlStockSlipCount = value; }
        }


        /// <summary>
        /// 出荷データワークコンストラクタ
        /// </summary>
        /// <returns>ShipmentWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   ShipmentWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SearchMstCountWork()
        {
        }

    }
}
