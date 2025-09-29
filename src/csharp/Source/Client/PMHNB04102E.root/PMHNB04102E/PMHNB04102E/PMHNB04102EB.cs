using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   MTtlSalesSlip
    /// <summary>
    ///                      売上月次集計データ
    /// </summary>
    /// <remarks>
    /// <br>note             :   売上月次集計データヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2008/4/24</br>
    /// <br>Genarated Date   :   2008/11/07  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2008/7/31  長内</br>
    /// <br>                 :   ○項目追加（キー追加）</br>
    /// <br>                 :   販売区分コード</br>
    /// </remarks>
    public class ShipmentPartsDspResult
    {
        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>実績集計区分</summary>
        /// <remarks>0:部品合計 1:在庫 2:純正 3:作業</remarks>
        private Int32 _rsltTtlDivCd;

        /// <summary>売上回数</summary>
        /// <remarks>出荷回数(売上時のみ）</remarks>
        private Int32 _salesTimes;

        /// <summary>売上金額</summary>
        /// <remarks>税抜き（値引,返品含まず）</remarks>
        private Int64 _salesMoney;

        /// <summary>粗利金額</summary>
        private Int64 _grossProfit;

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

        /// public propaty name  :  RsltTtlDivCd
        /// <summary>実績集計区分プロパティ</summary>
        /// <value>0:部品合計 1:在庫 2:純正 3:作業</value>
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

        /// public propaty name  :  SalesTimes
        /// <summary>売上回数プロパティ</summary>
        /// <value>出荷回数(売上時のみ）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上回数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SalesTimes
        {
            get { return _salesTimes; }
            set { _salesTimes = value; }
        }

        /// public propaty name  :  SalesMoney
        /// <summary>売上金額プロパティ</summary>
        /// <value>税抜き（値引,返品含まず）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上金額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesMoney
        {
            get { return _salesMoney; }
            set { _salesMoney = value; }
        }

        /// public propaty name  :  GrossProfit
        /// <summary>粗利金額プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   粗利金額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 GrossProfit
        {
            get { return _grossProfit; }
            set { _grossProfit = value; }
        }

        /// <summary>
        /// 売上月次集計データコンストラクタ
        /// </summary>
        /// <returns>ShipmentPartsDspResultクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   ShipmentPartsDspResultクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ShipmentPartsDspResult()
        {
        }

        /// <summary>
        /// 売上月次集計データコンストラクタ
        /// </summary>
        /// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
        /// <param name="rsltTtlDivCd">実績集計区分(0:部品合計 1:在庫 2:純正 3:作業)</param>
        /// <param name="salesTimes">売上回数(出荷回数(売上時のみ）)</param>
        /// <param name="salesMoney">売上金額(税抜き（値引,返品含まず）)</param>
        /// <param name="grossProfit">粗利金額</param>
        /// <returns>ShipmentPartsDspResultクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   ShipmentPartsDspResultクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ShipmentPartsDspResult(string enterpriseCode, Int32 rsltTtlDivCd, Int32 salesTimes, Int64 salesMoney, Int64 grossProfit)
        {
            this._enterpriseCode = enterpriseCode;
            this._rsltTtlDivCd = rsltTtlDivCd;
            this._salesTimes = salesTimes;
            this._salesMoney = salesMoney;
            this._grossProfit = grossProfit;
        }

        /// <summary>
        /// 売上月次集計データ複製処理
        /// </summary>
        /// <returns>ShipmentPartsDspResultクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいShipmentPartsDspResultクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ShipmentPartsDspResult Clone()
        {
            return new ShipmentPartsDspResult(this._enterpriseCode, this._rsltTtlDivCd, this._salesTimes, this._salesMoney, this._grossProfit);
        }

        /// <summary>
        /// 売上月次集計データ比較処理
        /// </summary>
        /// <param name="target">比較対象のShipmentPartsDspResultクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   ShipmentPartsDspResultクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool Equals(ShipmentPartsDspResult target)
        {
            return ((this.EnterpriseCode == target.EnterpriseCode)
                 && (this.RsltTtlDivCd == target.RsltTtlDivCd)
                 && (this.SalesTimes == target.SalesTimes)
                 && (this.SalesMoney == target.SalesMoney)
                 && (this.GrossProfit == target.GrossProfit));
        }

        /// <summary>
        /// 売上月次集計データ比較処理
        /// </summary>
        /// <param name="ShipmentPartsDspResult">
        ///                    比較するShipmentPartsDspResultクラスのインスタンス
        /// </param>
        /// <param name="mTtlSalesSlip2">比較するShipmentPartsDspResultクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   ShipmentPartsDspResultクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static bool Equals(ShipmentPartsDspResult mTtlSalesSlip1, ShipmentPartsDspResult mTtlSalesSlip2)
        {
            return ((mTtlSalesSlip1.EnterpriseCode == mTtlSalesSlip2.EnterpriseCode)
                 && (mTtlSalesSlip1.RsltTtlDivCd == mTtlSalesSlip2.RsltTtlDivCd)
                 && (mTtlSalesSlip1.SalesTimes == mTtlSalesSlip2.SalesTimes)
                 && (mTtlSalesSlip1.SalesMoney == mTtlSalesSlip2.SalesMoney)
                 && (mTtlSalesSlip1.GrossProfit == mTtlSalesSlip2.GrossProfit));
        }
        /// <summary>
        /// 売上月次集計データ比較処理
        /// </summary>
        /// <param name="target">比較対象のShipmentPartsDspResultクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   ShipmentPartsDspResultクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList Compare(ShipmentPartsDspResult target)
        {
            ArrayList resList = new ArrayList();
            if (this.EnterpriseCode != target.EnterpriseCode) resList.Add("EnterpriseCode");
            if (this.RsltTtlDivCd != target.RsltTtlDivCd) resList.Add("RsltTtlDivCd");
            if (this.SalesTimes != target.SalesTimes) resList.Add("SalesTimes");
            if (this.SalesMoney != target.SalesMoney) resList.Add("SalesMoney");
            if (this.GrossProfit != target.GrossProfit) resList.Add("GrossProfit");

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
        /// </remarks>
        public static ArrayList Compare(ShipmentPartsDspResult shipmentPartsDspResult1, ShipmentPartsDspResult shipmentPartsDspResult2)
        {
            ArrayList resList = new ArrayList();
            if (shipmentPartsDspResult1.EnterpriseCode != shipmentPartsDspResult2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (shipmentPartsDspResult1.RsltTtlDivCd != shipmentPartsDspResult2.RsltTtlDivCd) resList.Add("RsltTtlDivCd");
            if (shipmentPartsDspResult1.SalesTimes != shipmentPartsDspResult2.SalesTimes) resList.Add("SalesTimes");
            if (shipmentPartsDspResult1.SalesMoney != shipmentPartsDspResult2.SalesMoney) resList.Add("SalesMoney");
            if (shipmentPartsDspResult1.GrossProfit != shipmentPartsDspResult2.GrossProfit) resList.Add("GrossProfit");

            return resList;
        }
    }
}
