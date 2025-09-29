//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 仕入チェックリスト
// プログラム概要   : 仕入チェックリスト帳票を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張莉莉
// 作 成 日  2009/05/10  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日               修正内容 : 
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Application.UIData
{
    /// public class name:   StockSlipPMData
    /// <summary>
    ///                      仕入先PMデータ
    /// </summary>
    /// <remarks>
    /// <br>note             :   仕入先PMデータヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2008/9/29</br>
    /// <br>Genarated Date   :   2009/04/21  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class StockSlipPMData
    {
        /// <summary>仕入日</summary>
        private DateTime _stockDate;

        /// <summary>相手先伝票番号</summary>
        private string _partySaleSlipNum;

        /// <summary>仕入計上拠点コード</summary>
        private string _stockAddUpSectionCd;

        /// <summary>仕入伝票番号</summary>
        private Int32 _supplierSlipNo;

        /// <summary>仕入金額合計</summary>
        private Int64 _stockTotalPrice;

        /// <summary>仕入伝票備考1</summary>
        private string _supplierSlipNote1;

        /// <summary>支払先コード</summary>
        private Int32 _payeeCode;

        /// <summary>支払先略称</summary>
        private string _payeeSnm;

        /// <summary>注文方法</summary>
        private Int32 _wayToOrder;

        /// <summary>チェック　ある/なし</summary>
        private bool _isChecked;

        /// <summary>チェック　結果</summary>
        private bool _checkResult;

        /// public propaty name  :  CheckResult
        /// <summary>チェック　結果プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   チェック　結果プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool CheckResult
        {
            get { return _checkResult; }
            set { _checkResult = value; }
        }

        /// public propaty name  :  IsChecked
        /// <summary>チェック　ある/なしプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   チェック　ある/なしプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool IsChecked
        {
            get { return _isChecked; }
            set { _isChecked = value; }
        }

        /// public propaty name  :  StockDate
        /// <summary>仕入日プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime StockDate
        {
            get { return _stockDate; }
            set { _stockDate = value; }
        }

        /// public propaty name  :  PartySaleSlipNum
        /// <summary>相手先伝票番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   相手先伝票番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PartySaleSlipNum
        {
            get { return _partySaleSlipNum; }
            set { _partySaleSlipNum = value; }
        }

        /// public propaty name  :  StockAddUpSectionCd
        /// <summary>仕入計上拠点コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入計上拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string StockAddUpSectionCd
        {
            get { return _stockAddUpSectionCd; }
            set { _stockAddUpSectionCd = value; }
        }

        /// public propaty name  :  SupplierSlipNo
        /// <summary>仕入伝票番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入伝票番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SupplierSlipNo
        {
            get { return _supplierSlipNo; }
            set { _supplierSlipNo = value; }
        }

        /// public propaty name  :  StockTotalPrice
        /// <summary>仕入金額合計プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入金額合計プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 StockTotalPrice
        {
            get { return _stockTotalPrice; }
            set { _stockTotalPrice = value; }
        }

        /// public propaty name  :  SupplierSlipNote1
        /// <summary>仕入伝票備考1プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入伝票備考1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SupplierSlipNote1
        {
            get { return _supplierSlipNote1; }
            set { _supplierSlipNote1 = value; }
        }

        /// public propaty name  :  PayeeCode
        /// <summary>支払先コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PayeeCode
        {
            get { return _payeeCode; }
            set { _payeeCode = value; }
        }

        /// public propaty name  :  PayeeSnm
        /// <summary>支払先略称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払先略称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PayeeSnm
        {
            get { return _payeeSnm; }
            set { _payeeSnm = value; }
        }

        /// public propaty name  :  WayToOrder
        /// <summary>注文方法プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   注文方法プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 WayToOrder
        {
            get { return _wayToOrder; }
            set { _wayToOrder = value; }
        }
    }
}
