using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   ExtrInfo_PrevYearComparisonWork
    /// <summary>
    ///                      前年対比表抽出条件クラスワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   前年対比表抽出条件クラスワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/11/07  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class ExtrInfo_PrevYearComparisonWork
    {
        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>拠点コード</summary>
        /// <remarks>(配列)　全社指定は{""}</remarks>
        private String[] _secCodeList;

        /// <summary>集計方法</summary>
        /// <remarks>0:全社、1:拠点毎</remarks>
        private Int32 _totalWay;

        /// <summary>帳票タイプ</summary>
        /// <remarks>0:得意先別,1:担当者別,2:受注者別,3:地区別,4:業種別,5:グループコード別,6:BLコード別</remarks>
        private Int32 _listType;

        /// <summary>金額単位</summary>
        /// <remarks>0:円,1:千円</remarks>
        private Int32 _moneyUnit;

        /// <summary>発行タイプ</summary>
        private Int32 _printType;

        /// <summary>開始対象年月</summary>
        private Int32 _st_AddUpYearMonth;

        /// <summary>終了対象年月</summary>
        private Int32 _ed_AddUpYearMonth;

        /// <summary>前年比(開始当月純売上)</summary>
        private Double _st_MonthSalesRatio;

        /// <summary>前年比(終了当月純売上)</summary>
        private Double _ed_MonthSalesRatio;

        /// <summary>前年比(開始当年粗利)</summary>
        private Double _st_YearSalesRatio;

        /// <summary>前年比(終了当年粗利)</summary>
        private Double _ed_YearSalesRatio;

        /// <summary>前年比(開始当月粗利)</summary>
        private Double _st_MonthGrossRatio;

        /// <summary>前年比(終了当月粗利)</summary>
        private Double _ed_MonthGrossRatio;

        /// <summary>前年比(開始当年粗利)</summary>
        private Double _st_YearGrossRatio;

        /// <summary>前年比(終了当年粗利)</summary>
        private Double _ed_YearGrossRatio;

        /// <summary>得意先コード開始</summary>
        private Int32 _st_CustomerCode;

        /// <summary>得意先コード終了</summary>
        private Int32 _ed_CustomerCode;

        /// <summary>担当者コード開始</summary>
        /// <remarks>受注者コードを兼ねる</remarks>
        private string _st_EmployeeCode = "";

        /// <summary>担当者コード終了</summary>
        /// <remarks>受注者コードを兼ねる</remarks>
        private string _ed_EmployeeCode = "";

        /// <summary>BLコード開始</summary>
        private Int32 _st_BLGoodsCode;

        /// <summary>BLコード終了</summary>
        private Int32 _ed_BLGoodsCode;

        /// <summary>商品大分類コード開始</summary>
        private Int32 _st_GoodsLGroup;

        /// <summary>商品大分類コード終了</summary>
        private Int32 _ed_GoodsLGroup;

        /// <summary>商品中分類コード開始</summary>
        private Int32 _st_GoodsMGroup;

        /// <summary>商品中分類コード終了</summary>
        private Int32 _ed_GoodsMGroup;

        /// <summary>グループコード開始</summary>
        private Int32 _st_BLGroupCode;

        /// <summary>グループコード終了</summary>
        private Int32 _ed_BLGroupCode;

        /// <summary>地区コード開始</summary>
        private Int32 _st_SalesAreaCode;

        /// <summary>地区コード終了</summary>
        private Int32 _ed_SalesAreaCode;

        /// <summary>業種コード開始</summary>
        private Int32 _st_BusinessTypeCode;

        /// <summary>業種コード終了</summary>
        private Int32 _ed_BusinessTypeCode;


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

        /// public propaty name  :  secCodeList
        /// <summary>拠点コードプロパティ</summary>
        /// <value>(配列)　全社指定は{""}</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public String[] secCodeList
        {
            get { return _secCodeList; }
            set { _secCodeList = value; }
        }

        /// public propaty name  :  TotalWay
        /// <summary>集計方法プロパティ</summary>
        /// <value>0:全社、1:拠点毎</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   集計方法プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 TotalWay
        {
            get { return _totalWay; }
            set { _totalWay = value; }
        }

        /// public propaty name  :  ListType
        /// <summary>帳票タイププロパティ</summary>
        /// <value>0:得意先別,1:担当者別,2:受注者別,3:地区別,4:業種別,5:グループコード別,6:BLコード別</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   帳票タイププロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ListType
        {
            get { return _listType; }
            set { _listType = value; }
        }

        /// public propaty name  :  MoneyUnit
        /// <summary>金額単位プロパティ</summary>
        /// <value>0:円,1:千円</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   金額単位プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 MoneyUnit
        {
            get { return _moneyUnit; }
            set { _moneyUnit = value; }
        }

        /// public propaty name  :  printType
        /// <summary>発行タイププロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   発行タイププロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 printType
        {
            get { return _printType; }
            set { _printType = value; }
        }

        /// public propaty name  :  St_AddUpYearMonth
        /// <summary>開始対象年月プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始対象年月プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 St_AddUpYearMonth
        {
            get { return _st_AddUpYearMonth; }
            set { _st_AddUpYearMonth = value; }
        }

        /// public propaty name  :  Ed_AddUpYearMonth
        /// <summary>終了対象年月プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了対象年月プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 Ed_AddUpYearMonth
        {
            get { return _ed_AddUpYearMonth; }
            set { _ed_AddUpYearMonth = value; }
        }

        /// public propaty name  :  St_MonthSalesRatio
        /// <summary>前年比(開始当月純売上)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   前年比(開始当月純売上)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double St_MonthSalesRatio
        {
            get { return _st_MonthSalesRatio; }
            set { _st_MonthSalesRatio = value; }
        }

        /// public propaty name  :  Ed_MonthSalesRatio
        /// <summary>前年比(終了当月純売上)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   前年比(終了当月純売上)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double Ed_MonthSalesRatio
        {
            get { return _ed_MonthSalesRatio; }
            set { _ed_MonthSalesRatio = value; }
        }

        /// public propaty name  :  St_YearSalesRatio
        /// <summary>前年比(開始当年粗利)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   前年比(開始当年粗利)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double St_YearSalesRatio
        {
            get { return _st_YearSalesRatio; }
            set { _st_YearSalesRatio = value; }
        }

        /// public propaty name  :  Ed_YearSalesRatio
        /// <summary>前年比(終了当年粗利)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   前年比(終了当年粗利)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double Ed_YearSalesRatio
        {
            get { return _ed_YearSalesRatio; }
            set { _ed_YearSalesRatio = value; }
        }

        /// public propaty name  :  St_MonthGrossRatio
        /// <summary>前年比(開始当月粗利)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   前年比(開始当月粗利)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double St_MonthGrossRatio
        {
            get { return _st_MonthGrossRatio; }
            set { _st_MonthGrossRatio = value; }
        }

        /// public propaty name  :  Ed_MonthGrossRatio
        /// <summary>前年比(終了当月粗利)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   前年比(終了当月粗利)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double Ed_MonthGrossRatio
        {
            get { return _ed_MonthGrossRatio; }
            set { _ed_MonthGrossRatio = value; }
        }

        /// public propaty name  :  St_YearGrossRatio
        /// <summary>前年比(開始当年粗利)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   前年比(開始当年粗利)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double St_YearGrossRatio
        {
            get { return _st_YearGrossRatio; }
            set { _st_YearGrossRatio = value; }
        }

        /// public propaty name  :  Ed_YearGrossRatio
        /// <summary>前年比(終了当年粗利)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   前年比(終了当年粗利)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double Ed_YearGrossRatio
        {
            get { return _ed_YearGrossRatio; }
            set { _ed_YearGrossRatio = value; }
        }

        /// public propaty name  :  St_CustomerCode
        /// <summary>得意先コード開始プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先コード開始プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 St_CustomerCode
        {
            get { return _st_CustomerCode; }
            set { _st_CustomerCode = value; }
        }

        /// public propaty name  :  Ed_CustomerCode
        /// <summary>得意先コード終了プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先コード終了プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 Ed_CustomerCode
        {
            get { return _ed_CustomerCode; }
            set { _ed_CustomerCode = value; }
        }

        /// public propaty name  :  St_EmployeeCode
        /// <summary>担当者コード開始プロパティ</summary>
        /// <value>受注者コードを兼ねる</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   担当者コード開始プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string St_EmployeeCode
        {
            get { return _st_EmployeeCode; }
            set { _st_EmployeeCode = value; }
        }

        /// public propaty name  :  Ed_EmployeeCode
        /// <summary>担当者コード終了プロパティ</summary>
        /// <value>受注者コードを兼ねる</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   担当者コード終了プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string Ed_EmployeeCode
        {
            get { return _ed_EmployeeCode; }
            set { _ed_EmployeeCode = value; }
        }

        /// public propaty name  :  St_BLGoodsCode
        /// <summary>BLコード開始プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BLコード開始プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 St_BLGoodsCode
        {
            get { return _st_BLGoodsCode; }
            set { _st_BLGoodsCode = value; }
        }

        /// public propaty name  :  Ed_BLGoodsCode
        /// <summary>BLコード終了プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BLコード終了プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 Ed_BLGoodsCode
        {
            get { return _ed_BLGoodsCode; }
            set { _ed_BLGoodsCode = value; }
        }

        /// public propaty name  :  St_GoodsLGroup
        /// <summary>商品大分類コード開始プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品大分類コード開始プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 St_GoodsLGroup
        {
            get { return _st_GoodsLGroup; }
            set { _st_GoodsLGroup = value; }
        }

        /// public propaty name  :  Ed_GoodsLGroup
        /// <summary>商品大分類コード終了プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品大分類コード終了プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 Ed_GoodsLGroup
        {
            get { return _ed_GoodsLGroup; }
            set { _ed_GoodsLGroup = value; }
        }

        /// public propaty name  :  St_GoodsMGroup
        /// <summary>商品中分類コード開始プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品中分類コード開始プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 St_GoodsMGroup
        {
            get { return _st_GoodsMGroup; }
            set { _st_GoodsMGroup = value; }
        }

        /// public propaty name  :  Ed_GoodsMGroup
        /// <summary>商品中分類コード終了プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品中分類コード終了プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 Ed_GoodsMGroup
        {
            get { return _ed_GoodsMGroup; }
            set { _ed_GoodsMGroup = value; }
        }

        /// public propaty name  :  St_BLGroupCode
        /// <summary>グループコード開始プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   グループコード開始プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 St_BLGroupCode
        {
            get { return _st_BLGroupCode; }
            set { _st_BLGroupCode = value; }
        }

        /// public propaty name  :  Ed_BLGroupCode
        /// <summary>グループコード終了プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   グループコード終了プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 Ed_BLGroupCode
        {
            get { return _ed_BLGroupCode; }
            set { _ed_BLGroupCode = value; }
        }

        /// public propaty name  :  St_SalesAreaCode
        /// <summary>地区コード開始プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   地区コード開始プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 St_SalesAreaCode
        {
            get { return _st_SalesAreaCode; }
            set { _st_SalesAreaCode = value; }
        }

        /// public propaty name  :  Ed_SalesAreaCode
        /// <summary>地区コード終了プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   地区コード終了プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 Ed_SalesAreaCode
        {
            get { return _ed_SalesAreaCode; }
            set { _ed_SalesAreaCode = value; }
        }

        /// public propaty name  :  St_BusinessTypeCode
        /// <summary>業種コード開始プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   業種コード開始プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 St_BusinessTypeCode
        {
            get { return _st_BusinessTypeCode; }
            set { _st_BusinessTypeCode = value; }
        }

        /// public propaty name  :  Ed_BusinessTypeCode
        /// <summary>業種コード終了プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   業種コード終了プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 Ed_BusinessTypeCode
        {
            get { return _ed_BusinessTypeCode; }
            set { _ed_BusinessTypeCode = value; }
        }


        /// <summary>
        /// 前年対比表抽出条件クラスワークコンストラクタ
        /// </summary>
        /// <returns>ExtrInfo_PrevYearComparisonWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   ExtrInfo_PrevYearComparisonWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ExtrInfo_PrevYearComparisonWork()
        {
        }

    }
}
