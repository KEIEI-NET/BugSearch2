using System;
using System.Collections;

using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   CustAccRecInfSearchParameter
	/// <summary>
	///                      売掛情報取得抽出条件パラメータクラス
	/// </summary>
	/// <remarks>
	/// <br>note             :   売掛情報取得抽出条件パラメータクラスヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2007/11/20  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    public class CustAccRecInfSearchParameter
    {
        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>計上拠点コードリスト</summary>
        /// <remarks>抽出対象となっている計上拠点コード</remarks>
        private string[] _addUpSecCodeList;

        /// <summary>得意先コード(開始)</summary>
        /// <remarks>CustomerCodeが設定されている場合は無効</remarks>
        private Int32 _startCustomerCode;

        /// <summary>得意先コード(終了)</summary>
        /// <remarks>CustomerCodeが設定されている場合は無効</remarks>
        private Int32 _endCustomerCode;

        /// <summary>計上年月（開始）</summary>
        /// <remarks>YYYYMM</remarks>
        private DateTime _startAddUpYearMonth;

        /// <summary>計上年月（終了）</summary>
        /// <remarks>YYYYMM</remarks>
        private DateTime _endAddUpYearMonth;

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

        /// public propaty name  :  AddUpSecCodet
        /// <summary>計上拠点コードプロパティ</summary>
        /// <value>抽出の対象となっている拠点コード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   計上拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string[] AddUpSecCodeList
        {
            get { return _addUpSecCodeList; }
            set { _addUpSecCodeList = value; }
        }

        /// public propaty name  :  StartCustomerCode
        /// <summary>得意先コード(開始)プロパティ</summary>
        /// <value>CustomerCodeが設定されている場合は無効</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先コード(開始)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 StartCustomerCode
        {
            get { return _startCustomerCode; }
            set { _startCustomerCode = value; }
        }

        /// public propaty name  :  EndCustomerCode
        /// <summary>得意先コード(終了)プロパティ</summary>
        /// <value>CustomerCodeが設定されている場合は無効</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先コード(終了)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 EndCustomerCode
        {
            get { return _endCustomerCode; }
            set { _endCustomerCode = value; }
        }

        /// public propaty name  :  StartAddUpYearMonth
        /// <summary>計上年月（開始）プロパティ</summary>
        /// <value>YYYYMM</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   計上年月（開始）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime StartAddUpYearMonth
        {
            get { return _startAddUpYearMonth; }
            set { _startAddUpYearMonth = value; }
        }

        /// public propaty name  :  EndAddUpYearMonth
        /// <summary>計上年月（終了）プロパティ</summary>
        /// <value>YYYYMM</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   計上年月（終了）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime EndAddUpYearMonth
        {
            get { return _endAddUpYearMonth; }
            set { _endAddUpYearMonth = value; }
        }

        /// <summary>
        /// 売掛情報用抽出条件パラメータクラスコンストラクタ
        /// </summary>
        /// <returns>CustAccRecInfSearchParameterクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CustAccRecInfSearchParameterクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public CustAccRecInfSearchParameter()
        {
        }
    }
}
