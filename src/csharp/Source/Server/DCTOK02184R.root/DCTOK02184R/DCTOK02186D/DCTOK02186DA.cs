using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   ExtrInfo_PastYearStatisticsWork
    /// <summary>
    ///                      過年度統計表抽出条件ワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   過年度統計表抽出条件ワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2007/12/03  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class ExtrInfo_PastYearStatisticsWork
    {
        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>出力対象拠点</summary>
        /// <remarks>nullの場合は全拠点</remarks>
        private String[] _secCodeList;

        /// <summary>集計方法</summary>
        /// <remarks>True:全社集計 False:拠点別集計</remarks>
        private Boolean _totalWay;

        /// <summary>帳票タイプ</summary>
        /// <remarks>0:拠点別 1:得意先別</remarks>
        private Int32 _listType;

        /// <summary>金額単位</summary>
        /// <remarks>0:一円単位 1:千円単位</remarks>
        private Int32 _moneyUnit;

        /// <summary>開始対象年月</summary>
        /// <remarks>YYYY</remarks>
        private Int32 _st_AddUpYear;

        /// <summary>終了対象年月</summary>
        /// <remarks>YYYY</remarks>
        private Int32 _ed_AddUpYear;

        /// <summary>開始得意先コード</summary>
        /// <remarks>得意先別で使用</remarks>
        private Int32 _st_CustomerCode;

        /// <summary>終了得意先コード</summary>
        /// <remarks>得意先別で使用</remarks>
        private Int32 _ed_CustomerCode;


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

        /// public propaty name  :  SecCodeList
        /// <summary>出力対象拠点プロパティ</summary>
        /// <value>nullの場合は全拠点</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   出力対象拠点プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public String[] SecCodeList
        {
            get { return _secCodeList; }
            set { _secCodeList = value; }
        }

        /// public propaty name  :  TotalWay
        /// <summary>集計方法プロパティ</summary>
        /// <value>True:全社集計 False:拠点別集計</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   集計方法プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Boolean TotalWay
        {
            get { return _totalWay; }
            set { _totalWay = value; }
        }

        /// public propaty name  :  ListType
        /// <summary>帳票タイププロパティ</summary>
        /// <value>0:拠点別 1:得意先別</value>
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
        /// <value>0:一円単位 1:千円単位</value>
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

        /// public propaty name  :  St_AddUpYear
        /// <summary>開始対象年月プロパティ</summary>
        /// <value>YYYY</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始対象年月プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 St_AddUpYear
        {
            get { return _st_AddUpYear; }
            set { _st_AddUpYear = value; }
        }

        /// public propaty name  :  Ed_AddUpYear
        /// <summary>終了対象年月プロパティ</summary>
        /// <value>YYYY</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了対象年月プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 Ed_AddUpYear
        {
            get { return _ed_AddUpYear; }
            set { _ed_AddUpYear = value; }
        }

        /// public propaty name  :  St_CustomerCode
        /// <summary>開始得意先コードプロパティ</summary>
        /// <value>得意先別で使用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始得意先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 St_CustomerCode
        {
            get { return _st_CustomerCode; }
            set { _st_CustomerCode = value; }
        }

        /// public propaty name  :  Ed_CustomerCode
        /// <summary>終了得意先コードプロパティ</summary>
        /// <value>得意先別で使用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了得意先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 Ed_CustomerCode
        {
            get { return _ed_CustomerCode; }
            set { _ed_CustomerCode = value; }
        }


        /// <summary>
        /// 過年度統計表抽出条件ワークコンストラクタ
        /// </summary>
        /// <returns>ExtrInfo_PastYearStatisticsWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   ExtrInfo_PastYearStatisticsWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ExtrInfo_PastYearStatisticsWork()
        {
        }

    }
}
