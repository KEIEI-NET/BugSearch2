using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
    /// public class name:   CustomInqResult
    /// <summary>
    ///                      得意先過年度実績照会抽出結果クラス
    /// </summary>
    /// <remarks>
    /// <br>note             :   得意先過年度実績照会抽出結果クラスヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/11/18  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class CustomInqResult
    {
        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>計上拠点コード</summary>
        /// <remarks>集計の対象となっている拠点コード</remarks>
        private string _addUpSecCode = "";

        /// <summary>得意先コード</summary>
        /// <remarks>納入先の場合の使用可能項目</remarks>
        private Int32 _customerCode;

        /// <summary>売上金額</summary>
        /// <remarks>税抜き（値引,返品含まず）</remarks>
        private Int64 _salesMoney;

        /// <summary>返品額</summary>
        private Int64 _salesRetGoodsPrice;

        /// <summary>値引金額</summary>
        private Int64 _discountPrice;

        /// <summary>粗利金額</summary>
        private Int64 _grossProfit;

        /// <summary>企業名称</summary>
        private string _enterpriseName = "";

        /// <summary>計上拠点名称</summary>
        private string _addUpSecName = "";


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

        /// public propaty name  :  AddUpSecCode
        /// <summary>計上拠点コードプロパティ</summary>
        /// <value>集計の対象となっている拠点コード</value>
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

        /// public propaty name  :  CustomerCode
        /// <summary>得意先コードプロパティ</summary>
        /// <value>納入先の場合の使用可能項目</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CustomerCode
        {
            get { return _customerCode; }
            set { _customerCode = value; }
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

        /// public propaty name  :  SalesRetGoodsPrice
        /// <summary>返品額プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   返品額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesRetGoodsPrice
        {
            get { return _salesRetGoodsPrice; }
            set { _salesRetGoodsPrice = value; }
        }

        /// public propaty name  :  DiscountPrice
        /// <summary>値引金額プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   値引金額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 DiscountPrice
        {
            get { return _discountPrice; }
            set { _discountPrice = value; }
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

        /// public propaty name  :  AddUpSecName
        /// <summary>計上拠点名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   計上拠点名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AddUpSecName
        {
            get { return _addUpSecName; }
            set { _addUpSecName = value; }
        }


        /// <summary>
        /// 得意先過年度実績照会抽出結果クラスコンストラクタ
        /// </summary>
        /// <returns>CustomInqResultクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CustomInqResultクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public CustomInqResult()
        {
        }

        /// <summary>
        /// 得意先過年度実績照会抽出結果クラスコンストラクタ
        /// </summary>
        /// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
        /// <param name="addUpSecCode">計上拠点コード(集計の対象となっている拠点コード)</param>
        /// <param name="customerCode">得意先コード(納入先の場合の使用可能項目)</param>
        /// <param name="salesMoney">売上金額(税抜き（値引,返品含まず）)</param>
        /// <param name="salesRetGoodsPrice">返品額</param>
        /// <param name="discountPrice">値引金額</param>
        /// <param name="grossProfit">粗利金額</param>
        /// <param name="enterpriseName">企業名称</param>
        /// <param name="addUpSecName">計上拠点名称</param>
        /// <returns>CustomInqResultクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CustomInqResultクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public CustomInqResult(string enterpriseCode, string addUpSecCode, Int32 customerCode, Int64 salesMoney, Int64 salesRetGoodsPrice, Int64 discountPrice, Int64 grossProfit, string enterpriseName, string addUpSecName)
        {
            this._enterpriseCode = enterpriseCode;
            this._addUpSecCode = addUpSecCode;
            this._customerCode = customerCode;
            this._salesMoney = salesMoney;
            this._salesRetGoodsPrice = salesRetGoodsPrice;
            this._discountPrice = discountPrice;
            this._grossProfit = grossProfit;
            this._enterpriseName = enterpriseName;
            this._addUpSecName = addUpSecName;

        }

        /// <summary>
        /// 得意先過年度実績照会抽出結果クラス複製処理
        /// </summary>
        /// <returns>CustomInqResultクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいCustomInqResultクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public CustomInqResult Clone()
        {
            return new CustomInqResult(this._enterpriseCode, this._addUpSecCode, this._customerCode, this._salesMoney, this._salesRetGoodsPrice, this._discountPrice, this._grossProfit, this._enterpriseName, this._addUpSecName);
        }

        /// <summary>
        /// 得意先過年度実績照会抽出結果クラス比較処理
        /// </summary>
        /// <param name="target">比較対象のCustomInqResultクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CustomInqResultクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool Equals(CustomInqResult target)
        {
            return ((this.EnterpriseCode == target.EnterpriseCode)
                 && (this.AddUpSecCode == target.AddUpSecCode)
                 && (this.CustomerCode == target.CustomerCode)
                 && (this.SalesMoney == target.SalesMoney)
                 && (this.SalesRetGoodsPrice == target.SalesRetGoodsPrice)
                 && (this.DiscountPrice == target.DiscountPrice)
                 && (this.GrossProfit == target.GrossProfit)
                 && (this.EnterpriseName == target.EnterpriseName)
                 && (this.AddUpSecName == target.AddUpSecName));
        }

        /// <summary>
        /// 得意先過年度実績照会抽出結果クラス比較処理
        /// </summary>
        /// <param name="customInqResult1">
        ///                    比較するCustomInqResultクラスのインスタンス
        /// </param>
        /// <param name="customInqResult2">比較するCustomInqResultクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CustomInqResultクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static bool Equals(CustomInqResult customInqResult1, CustomInqResult customInqResult2)
        {
            return ((customInqResult1.EnterpriseCode == customInqResult2.EnterpriseCode)
                 && (customInqResult1.AddUpSecCode == customInqResult2.AddUpSecCode)
                 && (customInqResult1.CustomerCode == customInqResult2.CustomerCode)
                 && (customInqResult1.SalesMoney == customInqResult2.SalesMoney)
                 && (customInqResult1.SalesRetGoodsPrice == customInqResult2.SalesRetGoodsPrice)
                 && (customInqResult1.DiscountPrice == customInqResult2.DiscountPrice)
                 && (customInqResult1.GrossProfit == customInqResult2.GrossProfit)
                 && (customInqResult1.EnterpriseName == customInqResult2.EnterpriseName)
                 && (customInqResult1.AddUpSecName == customInqResult2.AddUpSecName));
        }
        /// <summary>
        /// 得意先過年度実績照会抽出結果クラス比較処理
        /// </summary>
        /// <param name="target">比較対象のCustomInqResultクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CustomInqResultクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList Compare(CustomInqResult target)
        {
            ArrayList resList = new ArrayList();
            if (this.EnterpriseCode != target.EnterpriseCode) resList.Add("EnterpriseCode");
            if (this.AddUpSecCode != target.AddUpSecCode) resList.Add("AddUpSecCode");
            if (this.CustomerCode != target.CustomerCode) resList.Add("CustomerCode");
            if (this.SalesMoney != target.SalesMoney) resList.Add("SalesMoney");
            if (this.SalesRetGoodsPrice != target.SalesRetGoodsPrice) resList.Add("SalesRetGoodsPrice");
            if (this.DiscountPrice != target.DiscountPrice) resList.Add("DiscountPrice");
            if (this.GrossProfit != target.GrossProfit) resList.Add("GrossProfit");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            if (this.AddUpSecName != target.AddUpSecName) resList.Add("AddUpSecName");

            return resList;
        }

        /// <summary>
        /// 得意先過年度実績照会抽出結果クラス比較処理
        /// </summary>
        /// <param name="customInqResult1">比較するCustomInqResultクラスのインスタンス</param>
        /// <param name="customInqResult2">比較するCustomInqResultクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CustomInqResultクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static ArrayList Compare(CustomInqResult customInqResult1, CustomInqResult customInqResult2)
        {
            ArrayList resList = new ArrayList();
            if (customInqResult1.EnterpriseCode != customInqResult2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (customInqResult1.AddUpSecCode != customInqResult2.AddUpSecCode) resList.Add("AddUpSecCode");
            if (customInqResult1.CustomerCode != customInqResult2.CustomerCode) resList.Add("CustomerCode");
            if (customInqResult1.SalesMoney != customInqResult2.SalesMoney) resList.Add("SalesMoney");
            if (customInqResult1.SalesRetGoodsPrice != customInqResult2.SalesRetGoodsPrice) resList.Add("SalesRetGoodsPrice");
            if (customInqResult1.DiscountPrice != customInqResult2.DiscountPrice) resList.Add("DiscountPrice");
            if (customInqResult1.GrossProfit != customInqResult2.GrossProfit) resList.Add("GrossProfit");
            if (customInqResult1.EnterpriseName != customInqResult2.EnterpriseName) resList.Add("EnterpriseName");
            if (customInqResult1.AddUpSecName != customInqResult2.AddUpSecName) resList.Add("AddUpSecName");

            return resList;
        }
    }
}
