using System;
using System.Collections;
using System.Xml.Serialization;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
	/// public class name:   CustomerSearchPara
	/// <summary>
	///                      得意先検索条件パラメータクラス
	/// </summary>
	/// <remarks>
	/// <br>note             :   得意先検索条件パラメータクラスヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2007/02/14  (CSharp File Generated Date)</br>
    /// <br>------------------------------------------------------------------------------------</br>
    /// <br>Update Note: 2009/12/02 30517 夏野 駿希</br>
    /// <br>             MANTIS:14720 得意先名検索追加</br>
    /// <br>------------------------------------------------------------------------------------</br>
    /// <br>Update Note: 2010/08/06 朱 猛</br>
    /// <br>             PM1012A:電話番号検索追加と伴う修正</br>
    /// <br>------------------------------------------------------------------------------------</br>
    /// <br>Update Note: 2011/08/19 黄海霞</br>
    /// <br>             PCC自社用得意先ガイド追加</br>
    /// <br>------------------------------------------------------------------------------------</br>
    /// <br>Update Note: 2011/07/22 徐錦山</br>
    /// <br>             PM1107C:得意先略称表示列と検索追加(#826)</br>
    /// <br>------------------------------------------------------------------------------------</br>
    /// </remarks>
	public class CustomerSearchPara
	{
		/// <summary>企業コード</summary>
		/// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
		private string _enterpriseCode = "";

		/// <summary>得意先コード</summary>
		private Int32 _customerCode;

		/// <summary>得意先サブコード</summary>
		private string _customerSubCode = "";

		/// <summary>カナ</summary>
		private string _kana = "";

		/// <summary>電話番号（検索用下4桁）</summary>
		private string _searchTelNo = "";

		/// <summary>業販先区分</summary>
		/// <remarks>0:業販先以外,1:業販先 -1:業販先を除く</remarks>
		private Int32 _acceptWholeSale;

		/// <summary>得意先サブコード検索タイプ</summary>
		/// <remarks>0:前方一致検索,1:曖昧検索</remarks>
		private Int32 _customerSubCodeSearchType;

		/// <summary>得意先カナ検索タイプ</summary>
		/// <remarks>0:前方一致検索,1:曖昧検索</remarks>
		private Int32 _kanaSearchType;

		/// <summary>得意先分析コード１</summary>
		private Int32 _custAnalysCode1;

		/// <summary>得意先分析コード２</summary>
		private Int32 _custAnalysCode2;

		/// <summary>得意先分析コード３</summary>
		private Int32 _custAnalysCode3;

		/// <summary>得意先分析コード４</summary>
		private Int32 _custAnalysCode4;

		/// <summary>得意先分析コード５</summary>
		private Int32 _custAnalysCode5;

		/// <summary>得意先分析コード６</summary>
		private Int32 _custAnalysCode6;

		/// <summary>顧客担当従業員コード</summary>
		/// <remarks>文字型</remarks>
		private string _customerAgentCd = "";

		/// <summary>顧客担当従業員名称</summary>
		private string _customerAgentNm = "";

		/// <summary>集金担当従業員コード</summary>
		private string _billCollecterCd = "";

		/// <summary>集金担当従業員名称</summary>
		private string _billCollecterNm = "";

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        /// <summary>管理拠点コード</summary>
        private string _mngSectionCode = "";
        /// <summary>管理拠点名称</summary>
        private string _mngSectionName = "";
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

		/// <summary>論理削除データ抽出フラグ</summary>
		/// <remarks>0:抽出しない 1:抽出する</remarks>
		private Int32 _logicalDeleteDataPickUp;

		/// <summary>企業名称</summary>
		private string _enterpriseName = "";

        // 2009/12/02 Add >>>
        /// <summary>得意先名</summary>
        private string _name = "";

        /// <summary>得意先名検索タイプ</summary>
        /// <remarks>0:前方一致検索,1:曖昧検索</remarks>
        private Int32 _nameSearchType;
        // 2009/12/02 Add <<<

        // ---ADD 2010/08/06-------------------->>>
        /// <summary>電話番号</summary>
        private string _telNum = "";

        /// <summary>電話番号検索タイプ</summary>
        /// <remarks>0:前方一致検索,1:曖昧検索</remarks>
        private Int32 _telNumSearchType;
        // ---ADD 2010/08/06--------------------<<<
        // ---ADD 2010/08/06--------------------<<<
       
        // 2011/7/22 XUJS ADD STA>>>>>>
        /// <summary>得意先略称</summary>
        private string _customerSnm = "";
        /// <summary>得意先略称検索タイプ</summary>
        /// <remarks>0:前方一致検索,1:曖昧検索</remarks>
        private Int32 _customerSnmSearchType;
        // 2011/7/22 XUJS ADD END<<<<<<

        //-----ADD PCC自社用得意先ガイド追加 for #23705 on 2011.08.19 ----->>>>>
        private Int32 _pccuoeMode;
        //-----ADD PCC自社用得意先ガイド追加 for #23705 on 2011.08.19 -----<<<<<

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

		/// public propaty name  :  CustomerCode
		/// <summary>得意先コードプロパティ</summary>
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

		/// public propaty name  :  CustomerSubCode
		/// <summary>得意先サブコードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   得意先サブコードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string CustomerSubCode
		{
			get { return _customerSubCode; }
			set { _customerSubCode = value; }
		}

		/// public propaty name  :  Kana
		/// <summary>カナプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   カナプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string Kana
		{
			get { return _kana; }
			set { _kana = value; }
		}

		/// public propaty name  :  SearchTelNo
		/// <summary>電話番号（検索用下4桁）プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   電話番号（検索用下4桁）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string SearchTelNo
		{
			get { return _searchTelNo; }
			set { _searchTelNo = value; }
		}

		/// public propaty name  :  AcceptWholeSale
		/// <summary>業販先区分プロパティ</summary>
		/// <value>0:業販先以外,1:業販先 -1:業販先を除く</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   業販先区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 AcceptWholeSale
		{
			get { return _acceptWholeSale; }
			set { _acceptWholeSale = value; }
		}

		/// public propaty name  :  CustomerSubCodeSearchType
		/// <summary>得意先サブコード検索タイププロパティ</summary>
		/// <value>0:前方一致検索,1:曖昧検索</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   得意先サブコード検索タイププロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 CustomerSubCodeSearchType
		{
			get { return _customerSubCodeSearchType; }
			set { _customerSubCodeSearchType = value; }
		}

		/// public propaty name  :  KanaSearchType
		/// <summary>得意先カナ検索タイププロパティ</summary>
		/// <value>0:前方一致検索,1:曖昧検索</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   得意先カナ検索タイププロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 KanaSearchType
		{
			get { return _kanaSearchType; }
			set { _kanaSearchType = value; }
		}

		/// public propaty name  :  CustAnalysCode1
		/// <summary>得意先分析コード１プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   得意先分析コード１プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 CustAnalysCode1
		{
			get { return _custAnalysCode1; }
			set { _custAnalysCode1 = value; }
		}

		/// public propaty name  :  CustAnalysCode2
		/// <summary>得意先分析コード２プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   得意先分析コード２プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 CustAnalysCode2
		{
			get { return _custAnalysCode2; }
			set { _custAnalysCode2 = value; }
		}

		/// public propaty name  :  CustAnalysCode3
		/// <summary>得意先分析コード３プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   得意先分析コード３プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 CustAnalysCode3
		{
			get { return _custAnalysCode3; }
			set { _custAnalysCode3 = value; }
		}

		/// public propaty name  :  CustAnalysCode4
		/// <summary>得意先分析コード４プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   得意先分析コード４プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 CustAnalysCode4
		{
			get { return _custAnalysCode4; }
			set { _custAnalysCode4 = value; }
		}

		/// public propaty name  :  CustAnalysCode5
		/// <summary>得意先分析コード５プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   得意先分析コード５プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 CustAnalysCode5
		{
			get { return _custAnalysCode5; }
			set { _custAnalysCode5 = value; }
		}

		/// public propaty name  :  CustAnalysCode6
		/// <summary>得意先分析コード６プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   得意先分析コード６プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 CustAnalysCode6
		{
			get { return _custAnalysCode6; }
			set { _custAnalysCode6 = value; }
		}

		/// public propaty name  :  CustomerAgentCd
		/// <summary>顧客担当従業員コードプロパティ</summary>
		/// <value>文字型</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   顧客担当従業員コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string CustomerAgentCd
		{
			get { return _customerAgentCd; }
			set { _customerAgentCd = value; }
		}

		/// public propaty name  :  CustomerAgentNm
		/// <summary>顧客担当従業員名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   顧客担当従業員名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string CustomerAgentNm
		{
			get { return _customerAgentNm; }
			set { _customerAgentNm = value; }
		}

		/// public propaty name  :  BillCollecterCd
		/// <summary>集金担当従業員コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   集金担当従業員コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string BillCollecterCd
		{
			get { return _billCollecterCd; }
			set { _billCollecterCd = value; }
		}

		/// public propaty name  :  BillCollecterNm
		/// <summary>集金担当従業員名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   集金担当従業員名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string BillCollecterNm
		{
			get { return _billCollecterNm; }
			set { _billCollecterNm = value; }
		}

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        /// public propaty name : MngSectionCode
        /// <summary>管理拠点コード</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   管理拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MngSectionCode
        {
            get { return _mngSectionCode; }
            set { _mngSectionCode = value; }
        }
        /// public propaty name : MngSectionName
        /// <summary>管理拠点名称</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   管理拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MngSectionName
        {
            get { return _mngSectionName; }
            set { _mngSectionName = value; }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

		/// public propaty name  :  LogicalDeleteDataPickUp
		/// <summary>論理削除データ抽出フラグプロパティ</summary>
		/// <value>0:抽出しない 1:抽出する</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   論理削除データ抽出フラグプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 LogicalDeleteDataPickUp
		{
			get { return _logicalDeleteDataPickUp; }
			set { _logicalDeleteDataPickUp = value; }
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

        // 2009/12/02 Add >>>
        /// public propaty name  :  Name
        /// <summary>得意先名プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先名プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        /// public propaty name  :  KanaSearchType
        /// <summary>得意先名検索タイププロパティ</summary>
        /// <value>0:前方一致検索,1:曖昧検索</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先名検索タイププロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 NameSearchType
        {
            get { return _nameSearchType; }
            set { _nameSearchType = value; }
        }

        // 2009/12/02 Add <<<

        // ---ADD 2010/08/06-------------------->>>
        /// public propaty name  :  TelNum
        /// <summary>電話番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   電話番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string TelNum
        {
            get { return _telNum; }
            set { _telNum = value; }
        }

        /// public propaty name  :  TelNumSearchType
        /// <summary>電話番号検索タイププロパティ</summary>
        /// <value>0:前方一致検索,1:曖昧検索</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   電話番号検索タイププロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 TelNumSearchType
        {
            get { return _telNumSearchType; }
            set { _telNumSearchType = value; }
        }
        // ---ADD 2010/08/06--------------------<<<

        /// <br>------------------------------------------------------------------------------------</br>
        /// <br>Update Note: 2011/07/22 徐錦山</br>
        /// <br>             PM1107C:得意先略称表示列と検索追加(#826)</br>
        /// <br>------------------------------------------------------------------------------------</br>
        // 2011/7/22 XUJS ADD STA>>>>>>
        /// public propaty name  :  CustomerSnm
        /// <summary>得意先略称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先略称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CustomerSnm
        {
            get { return _customerSnm; }
            set { _customerSnm = value; }
        }

        /// public propaty name  :  CustomerSnmSearchType
        /// <summary>得意先略称検索タイププロパティ</summary>
        /// <value>0:前方一致検索,1:曖昧検索</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先略称検索タイププロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CustomerSnmSearchType
        {
            get { return _customerSnmSearchType; }
            set { _customerSnmSearchType = value; }
        }
        // 2011/7/22 XUJS ADD END<<<<<<

        //-----ADD PCC自社用得意先ガイド追加 for #23705 on 2011.08.19 ----->>>>>
        /// public propaty name  :  PccuoeMode
        /// <summary>PCC自社用タイプロパティ</summary>
        /// <value>0:通常,1:PCC自社用,2:PCCマスメン用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   電話番号検索タイププロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PccuoeMode
        {
            get { return _pccuoeMode; }
            set { _pccuoeMode = value; }
        }
        //-----ADD PCC自社用得意先ガイド追加 for #23705 on 2011.08.19 -----<<<<<

		/// <summary>
		/// 得意先検索条件パラメータクラスコンストラクタ
		/// </summary>
		/// <returns>CustomerSearchParaクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   CustomerSearchParaクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public CustomerSearchPara()
		{
		}

		/// <summary>
		/// 得意先検索条件パラメータクラスコンストラクタ
		/// </summary>
		/// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
		/// <param name="customerCode">得意先コード</param>
		/// <param name="customerSubCode">得意先サブコード</param>
		/// <param name="kana">カナ</param>
		/// <param name="searchTelNo">電話番号（検索用下4桁）</param>
		/// <param name="acceptWholeSale">業販先区分(0:業販先以外,1:業販先)</param>
		/// <param name="customerSubCodeSearchType">得意先サブコード検索タイプ(0:前方一致検索,1:曖昧検索)</param>
		/// <param name="kanaSearchType">得意先カナ検索タイプ(0:前方一致検索,1:曖昧検索)</param>
		/// <param name="custAnalysCode1">得意先分析コード１</param>
		/// <param name="custAnalysCode2">得意先分析コード２</param>
		/// <param name="custAnalysCode3">得意先分析コード３</param>
		/// <param name="custAnalysCode4">得意先分析コード４</param>
		/// <param name="custAnalysCode5">得意先分析コード５</param>
		/// <param name="custAnalysCode6">得意先分析コード６</param>
		/// <param name="customerAgentCd">顧客担当従業員コード(文字型)</param>
		/// <param name="customerAgentNm">顧客担当従業員名称</param>
		/// <param name="billCollecterCd">集金担当従業員コード</param>
		/// <param name="billCollecterNm">集金担当従業員名称</param>
		/// <param name="logicalDeleteDataPickUp">論理削除データ抽出フラグ(0:抽出しない 1:抽出する)</param>
		/// <param name="enterpriseName">企業名称</param>
        /// <param name="mngSectionCode">管理拠点コード</param>
        /// <param name="mngSectionName">管理拠点名称</param>
        /// <param name="telNum">電話番号</param>
        /// <param name="telNumSearchType">電話番号曖昧検索</param>
        /// <param name="customerSnm">得意先略称</param>
        /// <param name="customerSnmSearchType">得意先略称検索タイプ</param>
        /// <param name="pccuoeMode">PCC自社用タイプ</param>
		/// <returns>CustomerSearchParaクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   CustomerSearchParaクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
        /// <br>------------------------------------------------------------------------------------</br>
        /// <br>Update Note: 2011/07/22 徐錦山</br>
        /// <br>             PM1107C:得意先略称表示列と検索追加(#826)</br>
        /// <br>------------------------------------------------------------------------------------</br>
		/// </remarks>
        // 2009/12/02 >>>
        //public CustomerSearchPara(string enterpriseCode, Int32 customerCode, string customerSubCode, string kana, string searchTelNo, Int32 acceptWholeSale, Int32 customerSubCodeSearchType, Int32 kanaSearchType, Int32 custAnalysCode1, Int32 custAnalysCode2, Int32 custAnalysCode3, Int32 custAnalysCode4, Int32 custAnalysCode5, Int32 custAnalysCode6, string customerAgentCd, string customerAgentNm, string billCollecterCd, string billCollecterNm, Int32 logicalDeleteDataPickUp, string enterpriseName, string mngSectionCode, string mngSectionName)
        // ---UPD 2010/08/06-------------------->>>
        //public CustomerSearchPara(string enterpriseCode, Int32 customerCode, string customerSubCode, string kana, string searchTelNo, Int32 acceptWholeSale, Int32 customerSubCodeSearchType, Int32 kanaSearchType, Int32 custAnalysCode1, Int32 custAnalysCode2, Int32 custAnalysCode3, Int32 custAnalysCode4, Int32 custAnalysCode5, Int32 custAnalysCode6, string customerAgentCd, string customerAgentNm, string billCollecterCd, string billCollecterNm, Int32 logicalDeleteDataPickUp, string enterpriseName, string mngSectionCode, string mngSectionName, string name, Int32 nameSearchType)
        //public CustomerSearchPara(string enterpriseCode, Int32 customerCode, string customerSubCode, string kana, string searchTelNo, Int32 acceptWholeSale, Int32 customerSubCodeSearchType, Int32 kanaSearchType, Int32 custAnalysCode1, Int32 custAnalysCode2, Int32 custAnalysCode3, Int32 custAnalysCode4, Int32 custAnalysCode5, Int32 custAnalysCode6, string customerAgentCd, string customerAgentNm, string billCollecterCd, string billCollecterNm, Int32 logicalDeleteDataPickUp, string enterpriseName, string mngSectionCode, string mngSectionName, string name, Int32 nameSearchType, string telNum, Int32 telNumSearchType) //-----DEL PCC自社用得意先ガイド追加 for #23705 on 2011.08.19 
        // ---UPD 2010/08/06--------------------<<<
        public CustomerSearchPara(string enterpriseCode, Int32 customerCode, string customerSubCode, string kana, string searchTelNo, Int32 acceptWholeSale, Int32 customerSubCodeSearchType, Int32 kanaSearchType, Int32 custAnalysCode1, Int32 custAnalysCode2, Int32 custAnalysCode3, Int32 custAnalysCode4, Int32 custAnalysCode5, Int32 custAnalysCode6, string customerAgentCd, string customerAgentNm, string billCollecterCd, string billCollecterNm, Int32 logicalDeleteDataPickUp, string enterpriseName, string mngSectionCode, string mngSectionName, string name, Int32 nameSearchType, string telNum, Int32 telNumSearchType, String customerSnm, Int32 customerSnmSearchType, int pccuoeMode)  //-----ADD PCC自社用得意先ガイド追加 for #23705 on 2011.08.19 
        // 2009/12/02 <<<
        {
            this._enterpriseCode = enterpriseCode;
            this._customerCode = customerCode;
            this._customerSubCode = customerSubCode;
            this._kana = kana;
            this._searchTelNo = searchTelNo;
            this._acceptWholeSale = acceptWholeSale;
            this._customerSubCodeSearchType = customerSubCodeSearchType;
            this._kanaSearchType = kanaSearchType;
            this._custAnalysCode1 = custAnalysCode1;
            this._custAnalysCode2 = custAnalysCode2;
            this._custAnalysCode3 = custAnalysCode3;
            this._custAnalysCode4 = custAnalysCode4;
            this._custAnalysCode5 = custAnalysCode5;
            this._custAnalysCode6 = custAnalysCode6;
            this._customerAgentCd = customerAgentCd;
            this._customerAgentNm = customerAgentNm;
            this._billCollecterCd = billCollecterCd;
            this._billCollecterNm = billCollecterNm;
            this._logicalDeleteDataPickUp = logicalDeleteDataPickUp;
            this._enterpriseName = enterpriseName;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            this._mngSectionCode = mngSectionCode;
            this._mngSectionName = mngSectionName;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // 2009/12/02 Add >>>
            this._name = name;
            this._nameSearchType = nameSearchType;
            // 2009/12/02 Add <<<

            // ---ADD 2010/08/06-------------------->>>
            this._telNum = telNum;
            this._telNumSearchType = telNumSearchType;
            // ---ADD 2010/08/06--------------------<<<
            // 2011/7/22 XUJS ADD STA>>>>>>
            this._customerSnm = customerSnm;
            this._customerSnmSearchType = customerSnmSearchType;
            // 2011/7/22 XUJS ADD END<<<<<<\
            //-----ADD PCC自社用得意先ガイド追加 for #23705 on 2011.08.19 ----->>>>>
            this._pccuoeMode = pccuoeMode;
            //-----ADD PCC自社用得意先ガイド追加 for #23705 on 2011.08.19 -----<<<<<
            
        }

		/// <summary>
		/// 得意先検索条件パラメータクラス複製処理
		/// </summary>
		/// <returns>CustomerSearchParaクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   自身の内容と等しいCustomerSearchParaクラスのインスタンスを返します</br>
		/// <br>Programer        :   自動生成</br>
        /// <br>------------------------------------------------------------------------------------</br>
        /// <br>Update Note: 2011/07/22 徐錦山</br>
        /// <br>             PM1107C:得意先略称表示列と検索追加(#826)</br>
        /// <br>------------------------------------------------------------------------------------</br>
		/// </remarks>
		public CustomerSearchPara Clone()
		{
            // 2009/12/02 >>>
            //return new CustomerSearchPara(this._enterpriseCode, this._customerCode, this._customerSubCode, this._kana, this._searchTelNo, this._acceptWholeSale, this._customerSubCodeSearchType, this._kanaSearchType, this._custAnalysCode1, this._custAnalysCode2, this._custAnalysCode3, this._custAnalysCode4, this._custAnalysCode5, this._custAnalysCode6, this._customerAgentCd, this._customerAgentNm, this._billCollecterCd, this._billCollecterNm, this._logicalDeleteDataPickUp, this._enterpriseName, this._mngSectionCode, this._mngSectionName);
            // ---UPD 2010/08/06-------------------->>>
            //return new CustomerSearchPara(this._enterpriseCode, this._customerCode, this._customerSubCode, this._kana, this._searchTelNo, this._acceptWholeSale, this._customerSubCodeSearchType, this._kanaSearchType, this._custAnalysCode1, this._custAnalysCode2, this._custAnalysCode3, this._custAnalysCode4, this._custAnalysCode5, this._custAnalysCode6, this._customerAgentCd, this._customerAgentNm, this._billCollecterCd, this._billCollecterNm, this._logicalDeleteDataPickUp, this._enterpriseName, this._mngSectionCode, this._mngSectionName, this._name, this._nameSearchType);
            //return new CustomerSearchPara(this._enterpriseCode, this._customerCode, this._customerSubCode, this._kana, this._searchTelNo, this._acceptWholeSale, this._customerSubCodeSearchType, this._kanaSearchType, this._custAnalysCode1, this._custAnalysCode2, this._custAnalysCode3, this._custAnalysCode4, this._custAnalysCode5, this._custAnalysCode6, this._customerAgentCd, this._customerAgentNm, this._billCollecterCd, this._billCollecterNm, this._logicalDeleteDataPickUp, this._enterpriseName, this._mngSectionCode, this._mngSectionName, this._name, this._nameSearchType, this._telNum, this._telNumSearchType);//-----DEL PCC自社用得意先ガイド追加 for #23705 on 2011.08.19 
            // ---UPD 2010/08/06--------------------<<<
            return new CustomerSearchPara(this._enterpriseCode, this._customerCode, this._customerSubCode, this._kana, this._searchTelNo, this._acceptWholeSale, this._customerSubCodeSearchType, this._kanaSearchType, this._custAnalysCode1, this._custAnalysCode2, this._custAnalysCode3, this._custAnalysCode4, this._custAnalysCode5, this._custAnalysCode6, this._customerAgentCd, this._customerAgentNm, this._billCollecterCd, this._billCollecterNm, this._logicalDeleteDataPickUp, this._enterpriseName, this._mngSectionCode, this._mngSectionName, this._name, this._nameSearchType, this._telNum, this._telNumSearchType, this._customerSnm, this._customerSnmSearchType, this._pccuoeMode);//-----ADD PCC自社用得意先ガイド追加 for #23705 on 2011.08.19 
            
            // 2009/12/02 <<<
        }

		/// <summary>
		/// 得意先検索条件パラメータクラス比較処理
		/// </summary>
		/// <param name="target">比較対象のCustomerSearchParaクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   CustomerSearchParaクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public bool Equals(CustomerSearchPara target)
		{
			return ((this.EnterpriseCode == target.EnterpriseCode)
				 && (this.CustomerCode == target.CustomerCode)
				 && (this.CustomerSubCode == target.CustomerSubCode)
				 && (this.Kana == target.Kana)
				 && (this.SearchTelNo == target.SearchTelNo)
				 && (this.AcceptWholeSale == target.AcceptWholeSale)
				 && (this.CustomerSubCodeSearchType == target.CustomerSubCodeSearchType)
				 && (this.KanaSearchType == target.KanaSearchType)
				 && (this.CustAnalysCode1 == target.CustAnalysCode1)
				 && (this.CustAnalysCode2 == target.CustAnalysCode2)
				 && (this.CustAnalysCode3 == target.CustAnalysCode3)
				 && (this.CustAnalysCode4 == target.CustAnalysCode4)
				 && (this.CustAnalysCode5 == target.CustAnalysCode5)
				 && (this.CustAnalysCode6 == target.CustAnalysCode6)
				 && (this.CustomerAgentCd == target.CustomerAgentCd)
				 && (this.CustomerAgentNm == target.CustomerAgentNm)
				 && (this.BillCollecterCd == target.BillCollecterCd)
				 && (this.BillCollecterNm == target.BillCollecterNm)
				 && (this.LogicalDeleteDataPickUp == target.LogicalDeleteDataPickUp)
				 && (this.EnterpriseName == target.EnterpriseName)
                 // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                 && (this.MngSectionCode == target.MngSectionCode)
                 && (this.MngSectionName == target.MngSectionName)
                 // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

                 // 2009/12/02 Add >>>
                 &&(this.Name==target.Name)
                 &&(this.NameSearchType==target.NameSearchType)
                 // 2009/12/02 Add <<<

                 // ---ADD 2010/08/06-------------------->>>
                 && (this.TelNum == target.TelNum)
                 && (this.TelNumSearchType == target.TelNumSearchType)
                 // ---ADD 2010/08/06--------------------<<<
                //-----ADD PCC自社用得意先ガイド追加 for #23705 on 2011.08.19 ----->>>>>
                 && (this.CustomerSnm == target.CustomerSnm)
                 && (this.CustomerSnmSearchType == target.CustomerSnmSearchType)
                 && (this.PccuoeMode == target.PccuoeMode)
                //-----ADD PCC自社用得意先ガイド追加 for #23705 on 2011.08.19 -----<<<<<
                 );
		}

		/// <summary>
		/// 得意先検索条件パラメータクラス比較処理
		/// </summary>
		/// <param name="customerSearchPara1">
		///                    比較するCustomerSearchParaクラスのインスタンス
		/// </param>
		/// <param name="customerSearchPara2">比較するCustomerSearchParaクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   CustomerSearchParaクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static bool Equals(CustomerSearchPara customerSearchPara1, CustomerSearchPara customerSearchPara2)
		{
			return ((customerSearchPara1.EnterpriseCode == customerSearchPara2.EnterpriseCode)
				 && (customerSearchPara1.CustomerCode == customerSearchPara2.CustomerCode)
				 && (customerSearchPara1.CustomerSubCode == customerSearchPara2.CustomerSubCode)
				 && (customerSearchPara1.Kana == customerSearchPara2.Kana)
				 && (customerSearchPara1.SearchTelNo == customerSearchPara2.SearchTelNo)
				 && (customerSearchPara1.AcceptWholeSale == customerSearchPara2.AcceptWholeSale)
				 && (customerSearchPara1.CustomerSubCodeSearchType == customerSearchPara2.CustomerSubCodeSearchType)
				 && (customerSearchPara1.KanaSearchType == customerSearchPara2.KanaSearchType)
				 && (customerSearchPara1.CustAnalysCode1 == customerSearchPara2.CustAnalysCode1)
				 && (customerSearchPara1.CustAnalysCode2 == customerSearchPara2.CustAnalysCode2)
				 && (customerSearchPara1.CustAnalysCode3 == customerSearchPara2.CustAnalysCode3)
				 && (customerSearchPara1.CustAnalysCode4 == customerSearchPara2.CustAnalysCode4)
				 && (customerSearchPara1.CustAnalysCode5 == customerSearchPara2.CustAnalysCode5)
				 && (customerSearchPara1.CustAnalysCode6 == customerSearchPara2.CustAnalysCode6)
				 && (customerSearchPara1.CustomerAgentCd == customerSearchPara2.CustomerAgentCd)
				 && (customerSearchPara1.CustomerAgentNm == customerSearchPara2.CustomerAgentNm)
				 && (customerSearchPara1.BillCollecterCd == customerSearchPara2.BillCollecterCd)
				 && (customerSearchPara1.BillCollecterNm == customerSearchPara2.BillCollecterNm)
				 && (customerSearchPara1.LogicalDeleteDataPickUp == customerSearchPara2.LogicalDeleteDataPickUp)
				 && (customerSearchPara1.EnterpriseName == customerSearchPara2.EnterpriseName)
                 // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                 && (customerSearchPara1.MngSectionCode == customerSearchPara2.MngSectionCode)
                 && (customerSearchPara1.MngSectionName == customerSearchPara2.MngSectionName)
                 // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

                 // 2009/12/02 Add >>>
                 &&(customerSearchPara1.Name==customerSearchPara1.Name)
                 &&(customerSearchPara1.NameSearchType==customerSearchPara1.NameSearchType)
                 // 2009/12/02 Add <<<
                //-----ADD PCC自社用得意先ガイド追加 for #23705 on 2011.08.19 ----->>>>>
                 && (customerSearchPara1.CustomerSnm == customerSearchPara1.CustomerSnm)
                  && (customerSearchPara1.CustomerSnmSearchType == customerSearchPara1.CustomerSnmSearchType)
                 && (customerSearchPara1.PccuoeMode == customerSearchPara1.PccuoeMode)
                //-----ADD PCC自社用得意先ガイド追加 for #23705 on 2011.08.19 -----<<<<<
                 );
		}
		/// <summary>
		/// 得意先検索条件パラメータクラス比較処理
		/// </summary>
		/// <param name="target">比較対象のCustomerSearchParaクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   CustomerSearchParaクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
        /// <br>------------------------------------------------------------------------------------</br>
        /// <br>Update Note: 2011/07/22 徐錦山</br>
        /// <br>             PM1107C:得意先略称表示列と検索追加(#826)</br>
        /// <br>------------------------------------------------------------------------------------</br>
		/// </remarks>
		public ArrayList Compare(CustomerSearchPara target)
		{
			ArrayList resList = new ArrayList();
			if (this.EnterpriseCode != target.EnterpriseCode) resList.Add("EnterpriseCode");
			if (this.CustomerCode != target.CustomerCode) resList.Add("CustomerCode");
			if (this.CustomerSubCode != target.CustomerSubCode) resList.Add("CustomerSubCode");
			if (this.Kana != target.Kana) resList.Add("Kana");
			if (this.SearchTelNo != target.SearchTelNo) resList.Add("SearchTelNo");
			if (this.AcceptWholeSale != target.AcceptWholeSale) resList.Add("AcceptWholeSale");
			if (this.CustomerSubCodeSearchType != target.CustomerSubCodeSearchType) resList.Add("CustomerSubCodeSearchType");
			if (this.KanaSearchType != target.KanaSearchType) resList.Add("KanaSearchType");
			if (this.CustAnalysCode1 != target.CustAnalysCode1) resList.Add("CustAnalysCode1");
			if (this.CustAnalysCode2 != target.CustAnalysCode2) resList.Add("CustAnalysCode2");
			if (this.CustAnalysCode3 != target.CustAnalysCode3) resList.Add("CustAnalysCode3");
			if (this.CustAnalysCode4 != target.CustAnalysCode4) resList.Add("CustAnalysCode4");
			if (this.CustAnalysCode5 != target.CustAnalysCode5) resList.Add("CustAnalysCode5");
			if (this.CustAnalysCode6 != target.CustAnalysCode6) resList.Add("CustAnalysCode6");
			if (this.CustomerAgentCd != target.CustomerAgentCd) resList.Add("CustomerAgentCd");
			if (this.CustomerAgentNm != target.CustomerAgentNm) resList.Add("CustomerAgentNm");
			if (this.BillCollecterCd != target.BillCollecterCd) resList.Add("BillCollecterCd");
			if (this.BillCollecterNm != target.BillCollecterNm) resList.Add("BillCollecterNm");
			if (this.LogicalDeleteDataPickUp != target.LogicalDeleteDataPickUp) resList.Add("LogicalDeleteDataPickUp");
			if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            if ( this.MngSectionCode != target.MngSectionCode ) resList.Add( "MngSectionCode" );
            if ( this.MngSectionName != target.MngSectionName ) resList.Add( "MngSectionName" );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // 2009/12/02 Add >>>
            if (this.Name != target.Name) resList.Add("Name");
            if (this.NameSearchType != target.NameSearchType) resList.Add("NameSearchType");
            // 2009/12/02 Add <<<
            // ---ADD 2010/08/06-------------------->>>
            if (this.TelNum != target.TelNum)
            {
                resList.Add("TelNum");
            }
            if (this.TelNumSearchType != target.TelNumSearchType)
            {
                resList.Add("TelNumSearchType");
            }
            // ---ADD 2010/08/06--------------------<<<

            // 2011/7/22 XUJS ADD STA>>>>>>
            if (this.CustomerSnm != target.CustomerSnm) resList.Add("CustomerSnm");
            if (this.CustomerSnmSearchType != target.CustomerSnmSearchType) resList.Add("CustomerSnmSearchType");
			// 2011/7/22 XUJS ADD END<<<<<<
            //-----ADD PCC自社用得意先ガイド追加 for #23705 on 2011.08.19 ----->>>>>
            if (this.PccuoeMode != target.PccuoeMode) resList.Add("PccuoeMode");
            //-----ADD PCC自社用得意先ガイド追加 for #23705 on 2011.08.19 -----<<<<<
            
			return resList;
		}

		/// <summary>
		/// 得意先検索条件パラメータクラス比較処理
		/// </summary>
		/// <param name="customerSearchPara1">比較するCustomerSearchParaクラスのインスタンス</param>
		/// <param name="customerSearchPara2">比較するCustomerSearchParaクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   CustomerSearchParaクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
        /// <br>------------------------------------------------------------------------------------</br>
        /// <br>Update Note: 2011/07/22 徐錦山</br>
        /// <br>             PM1107C:得意先略称表示列と検索追加(#826)</br>
        /// <br>------------------------------------------------------------------------------------</br>
		/// </remarks>
		public static ArrayList Compare(CustomerSearchPara customerSearchPara1, CustomerSearchPara customerSearchPara2)
		{
			ArrayList resList = new ArrayList();
			if (customerSearchPara1.EnterpriseCode != customerSearchPara2.EnterpriseCode) resList.Add("EnterpriseCode");
			if (customerSearchPara1.CustomerCode != customerSearchPara2.CustomerCode) resList.Add("CustomerCode");
			if (customerSearchPara1.CustomerSubCode != customerSearchPara2.CustomerSubCode) resList.Add("CustomerSubCode");
			if (customerSearchPara1.Kana != customerSearchPara2.Kana) resList.Add("Kana");
			if (customerSearchPara1.SearchTelNo != customerSearchPara2.SearchTelNo) resList.Add("SearchTelNo");
			if (customerSearchPara1.AcceptWholeSale != customerSearchPara2.AcceptWholeSale) resList.Add("AcceptWholeSale");
			if (customerSearchPara1.CustomerSubCodeSearchType != customerSearchPara2.CustomerSubCodeSearchType) resList.Add("CustomerSubCodeSearchType");
			if (customerSearchPara1.KanaSearchType != customerSearchPara2.KanaSearchType) resList.Add("KanaSearchType");
			if (customerSearchPara1.CustAnalysCode1 != customerSearchPara2.CustAnalysCode1) resList.Add("CustAnalysCode1");
			if (customerSearchPara1.CustAnalysCode2 != customerSearchPara2.CustAnalysCode2) resList.Add("CustAnalysCode2");
			if (customerSearchPara1.CustAnalysCode3 != customerSearchPara2.CustAnalysCode3) resList.Add("CustAnalysCode3");
			if (customerSearchPara1.CustAnalysCode4 != customerSearchPara2.CustAnalysCode4) resList.Add("CustAnalysCode4");
			if (customerSearchPara1.CustAnalysCode5 != customerSearchPara2.CustAnalysCode5) resList.Add("CustAnalysCode5");
			if (customerSearchPara1.CustAnalysCode6 != customerSearchPara2.CustAnalysCode6) resList.Add("CustAnalysCode6");
			if (customerSearchPara1.CustomerAgentCd != customerSearchPara2.CustomerAgentCd) resList.Add("CustomerAgentCd");
			if (customerSearchPara1.CustomerAgentNm != customerSearchPara2.CustomerAgentNm) resList.Add("CustomerAgentNm");
			if (customerSearchPara1.BillCollecterCd != customerSearchPara2.BillCollecterCd) resList.Add("BillCollecterCd");
			if (customerSearchPara1.BillCollecterNm != customerSearchPara2.BillCollecterNm) resList.Add("BillCollecterNm");
			if (customerSearchPara1.LogicalDeleteDataPickUp != customerSearchPara2.LogicalDeleteDataPickUp) resList.Add("LogicalDeleteDataPickUp");
			if (customerSearchPara1.EnterpriseName != customerSearchPara2.EnterpriseName) resList.Add("EnterpriseName");
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            if ( customerSearchPara1.MngSectionCode != customerSearchPara2.MngSectionCode ) resList.Add( "MngSectionCode" );
            if ( customerSearchPara1.MngSectionName != customerSearchPara2.MngSectionName ) resList.Add( "MngSectionName" );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // 2009/12/02 Add >>>
            if (customerSearchPara1.Name != customerSearchPara2.Name) resList.Add("Name");
            if (customerSearchPara1.NameSearchType != customerSearchPara2.NameSearchType) resList.Add("NameSearchType");
            // 2009/12/02 Add <<<
            // 2011/7/22 XUJS ADD STA>>>>>>
            if (customerSearchPara1.CustomerSnm != customerSearchPara2.CustomerSnm) resList.Add("CustomerSnm");
            if (customerSearchPara1.CustomerSnmSearchType != customerSearchPara2.CustomerSnmSearchType) resList.Add("CustomerSnmSearchType");
            // 2011/7/22 XUJS ADD END<<<<<<
            //-----ADD PCC自社用得意先ガイド追加 for #23705 on 2011.08.19 ----->>>>>
            if (customerSearchPara1.PccuoeMode != customerSearchPara2.PccuoeMode) resList.Add("PccuoeMode");
            //-----ADD PCC自社用得意先ガイド追加 for #23705 on 2011.08.19 -----<<<<<
            
			return resList;
		}
	}
}
