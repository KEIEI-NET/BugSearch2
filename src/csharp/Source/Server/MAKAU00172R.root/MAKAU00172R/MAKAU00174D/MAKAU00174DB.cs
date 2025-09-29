using System;
using System.Collections;

using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   CustDmdPrcInfSearchParameter
    /// <summary>
    ///                      得意先元帳抽出条件クラスワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   得意先元帳抽出条件クラスワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/10/02  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class CustDmdPrcInfSearchParameter
    {
        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>拠点コード（複数指定）</summary>
        /// <remarks>（配列）</remarks>
        private string[] _addUpSecCodeList;

        /// <summary>開始計上年月</summary>
        /// <remarks>YYYYMM</remarks>
        private DateTime _startAddUpYearMonth;

        /// <summary>終了計上年月</summary>
        /// <remarks>YYYYMM</remarks>
        private DateTime _endAddUpYearMonth;

        /// <summary>開始得意先コード</summary>
        private Int32 _startCustomerCode;

        /// <summary>終了得意先コード</summary>
        private Int32 _endCustomerCode;


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

        /// public propaty name  :  AddUpSecCodeList
        /// <summary>拠点コード（複数指定）プロパティ</summary>
        /// <value>（配列）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点コード（複数指定）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string[] AddUpSecCodeList
        {
            get { return _addUpSecCodeList; }
            set { _addUpSecCodeList = value; }
        }

        /// public propaty name  :  StartAddUpYearMonth
        /// <summary>開始計上年月プロパティ</summary>
        /// <value>YYYYMM</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始計上年月プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime StartAddUpYearMonth
        {
            get { return _startAddUpYearMonth; }
            set { _startAddUpYearMonth = value; }
        }

        /// public propaty name  :  EndAddUpYearMonth
        /// <summary>終了計上年月プロパティ</summary>
        /// <value>YYYYMM</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了計上年月プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime EndAddUpYearMonth
        {
            get { return _endAddUpYearMonth; }
            set { _endAddUpYearMonth = value; }
        }

        /// public propaty name  :  StartCustomerCode
        /// <summary>開始得意先コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始得意先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 StartCustomerCode
        {
            get { return _startCustomerCode; }
            set { _startCustomerCode = value; }
        }

        /// public propaty name  :  EndCustomerCode
        /// <summary>終了得意先コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了得意先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 EndCustomerCode
        {
            get { return _endCustomerCode; }
            set { _endCustomerCode = value; }
        }


        /// <summary>
        /// 得意先元帳抽出条件クラスワークコンストラクタ
        /// </summary>
        /// <returns>CustDmdPrcInfSearchParameterWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CustDmdPrcInfSearchParameterWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public CustDmdPrcInfSearchParameter()
        {
        }

    }
}
