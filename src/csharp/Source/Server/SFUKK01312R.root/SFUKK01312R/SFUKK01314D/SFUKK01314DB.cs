using System;
using System.Collections;

using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   SeiKingetParameter
	/// <summary>
	///                      請求KINGET用抽出条件パラメータクラス
	/// </summary>
	/// <remarks>
	/// <br>note             :   請求KINGET用の抽出条件パラメータクラスヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   2005/03/31</br>
	/// <br>Genarated Date   :   2005/07/21  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	[Serializable]
	public class SeiKingetParameter
	{
		/// <summary>企業コード</summary>
		/// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
		private string _enterpriseCode = "";

		/// <summary>計上拠点コードリスト</summary>
		/// <remarks>抽出対象となっている計上拠点コードのリスト</remarks>
		private ArrayList _addUpSecCodeList;

		/// <summary>全社選択</summary>
		/// <remarks>true:全社選択 false:各拠点選択</remarks>
		private bool _isSelectAllSection;

		/// <summary>得意先コード（開始）</summary>
		private Int32 _startCustomerCode;

		/// <summary>得意先コード（終了）</summary>
		private Int32 _endCustomerCode;

		/// <summary>締日</summary>
		/// <remarks>DD</remarks>
		private Int32 _totalDay;

		/// <summary>締日(開始)</summary>
		/// <remarks>DD</remarks>
		private Int32 _startTotalDay;

		/// <summary>締日(終了)</summary>
		/// <remarks>DD</remarks>
		private Int32 _endTotalDay;

		/// <summary>計上年月日（開始）</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _startAddUpDate;

		/// <summary>計上年月日（開始） 和暦</summary>
		/// <remarks>YYYYMMDD</remarks>
		private string _startAddUpDateJpFormal = "";

		/// <summary>計上年月日（開始） 和暦(略)</summary>
		/// <remarks>YYYYMMDD</remarks>
		private string _startAddUpDateJpInFormal = "";

		/// <summary>計上年月日（開始） 西暦</summary>
		/// <remarks>YYYYMMDD</remarks>
		private string _startAddUpDateAdFormal = "";

		/// <summary>計上年月日（開始） 西暦(略)</summary>
		/// <remarks>YYYYMMDD</remarks>
		private string _startAddUpDateAdInFormal = "";

		/// <summary>計上年月日（終了）</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _endAddUpDate;

		/// <summary>計上年月日（終了） 和暦</summary>
		/// <remarks>YYYYMMDD</remarks>
		private string _endAddUpDateJpFormal = "";

		/// <summary>計上年月日（終了） 和暦(略)</summary>
		/// <remarks>YYYYMMDD</remarks>
		private string _endAddUpDateJpInFormal = "";

		/// <summary>計上年月日（終了） 西暦</summary>
		/// <remarks>YYYYMMDD</remarks>
		private string _endAddUpDateAdFormal = "";

		/// <summary>計上年月日（終了） 西暦(略)</summary>
		/// <remarks>YYYYMMDD</remarks>
		private string _endAddUpDateAdInFormal = "";

		/// <summary>計上年月（開始）</summary>
		/// <remarks>YYYYMM</remarks>
		private Int32 _startAddUpYearMonth;

		/// <summary>計上年月（終了）</summary>
		/// <remarks>YYYYMM</remarks>
		private Int32 _endAddUpYearMonth;

		/// <summary>残高０出力</summary>
		/// <remarks>true:請求残高が０の場合でも仮想的に情報を作成する。false;請求残高が０の場合は作成しない</remarks>
		private bool _isOutputZeroBlance;

		/// <summary>全拠点レコード出力</summary>
		/// <remarks>true:全拠点レコードを出力する。false:全拠点レコードを出力しない</remarks>
		private bool _isOutputAllSecRec;

		/// <summary>得意先カナ（開始）</summary>
		private string _startKana = "";

		/// <summary>得意先カナ（終了）</summary>
		private string _endKana = "";

		/// <summary>全個人・法人区分フラグ</summary>
		/// <remarks>true:全ての個人・法人区分を対象とする,false:個人・法人区分リストに基づいて検索する</remarks>
		private bool _isAllCorporateDivCode;

		/// <summary>個人・法人区分リスト</summary>
		/// <remarks>抽出対象となっている個人・法人区分のリスト</remarks>
		private ArrayList _corporateDivCodeList;

		/// <summary>請求書出力区分判断</summary>
		/// <remarks>true:請求書出力区分を検索条件に入れる,false:請求書出力区分を検索条件に入れない</remarks>
		private bool _isJudgeBillOutputCode;

		/// <summary>従業員区分</summary>
		/// <remarks>0:得意先,1:集金</remarks>
		private Int32 _employeeKind;

		/// <summary>従業員コード（開始）</summary>
		private string _startEmployeeCode = "";

		/// <summary>従業員コード（終了）</summary>
		private string _endEmployeeCode = "";

		/// <summary>開始得意先分析コード１</summary>
		private Int32 _startCustAnalysCode1;

		/// <summary>開始得意先分析コード２</summary>
		private Int32 _startCustAnalysCode2;

		/// <summary>開始得意先分析コード３</summary>
		private Int32 _startCustAnalysCode3;

		/// <summary>開始得意先分析コード４</summary>
		private Int32 _startCustAnalysCode4;

		/// <summary>開始得意先分析コード５</summary>
		private Int32 _startCustAnalysCode5;

		/// <summary>開始得意先分析コード６</summary>
		private Int32 _startCustAnalysCode6;

		/// <summary>終了得意先分析コード１</summary>
		private Int32 _endCustAnalysCode1 = 999;

		/// <summary>終了得意先分析コード２</summary>
		private Int32 _endCustAnalysCode2 = 999;

		/// <summary>終了得意先分析コード３</summary>
		private Int32 _endCustAnalysCode3 = 999;

		/// <summary>終了得意先分析コード４</summary>
		private Int32 _endCustAnalysCode4 = 999;

		/// <summary>終了得意先分析コード５</summary>
		private Int32 _endCustAnalysCode5 = 999;

		/// <summary>終了得意先分析コード６</summary>
		private Int32 _endCustAnalysCode6 = 999;


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
			get{return _enterpriseCode;}
			set{_enterpriseCode = value;}
		}

		/// public propaty name  :  AddUpSecCodeList
		/// <summary>計上拠点コードリストプロパティ</summary>
		/// <value>抽出の対象となっている拠点コードリスト</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   計上拠点コードリストプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ArrayList AddUpSecCodeList
		{
			get{return _addUpSecCodeList;}
			set{_addUpSecCodeList = value;}
		}

		/// public propaty name  :  IsSelectAllSection
		/// <summary>全社選択プロパティ</summary>
		/// <value>true:全社選択 false:各拠点選択</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   全社選択プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public bool IsSelectAllSection
		{
			get{return _isSelectAllSection;}
			set{_isSelectAllSection = value;}
		}

		/// public propaty name  :  StartCustomerCode
		/// <summary>得意先コード（開始）プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   得意先コード（開始）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 StartCustomerCode
		{
			get{return _startCustomerCode;}
			set{_startCustomerCode = value;}
		}

		/// public propaty name  :  EndCustomerCode
		/// <summary>得意先コード（終了）プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   得意先コード（終了）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 EndCustomerCode
		{
			get{return _endCustomerCode;}
			set{_endCustomerCode = value;}
		}

		/// public propaty name  :  TotalDay
		/// <summary>締日プロパティ</summary>
		/// <value>DD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   締日プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 TotalDay
		{
			get{return _totalDay;}
			set{_totalDay = value;}
		}

		/// public propaty name  :  StartTotalDay
		/// <summary>締日(開始)プロパティ</summary>
		/// <value>DD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   締日(開始)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 StartTotalDay
		{
			get{return _startTotalDay;}
			set{_startTotalDay = value;}
		}

		/// public propaty name  :  EndTotalDay
		/// <summary>締日(終了)プロパティ</summary>
		/// <value>DD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   締日(終了)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 EndTotalDay
		{
			get{return _endTotalDay;}
			set{_endTotalDay = value;}
		}

		/// public propaty name  :  StartAddUpDate
		/// <summary>計上年月日（開始）プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   計上年月日（開始）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime StartAddUpDate
		{
			get{return _startAddUpDate;}
			set
			{
				_startAddUpDate = value;
				string[] dateTimes = TDateTime.DateTimeToStringArray("YYYYMMDD", value);
				this._startAddUpDateJpFormal = dateTimes[0];
				this._startAddUpDateJpInFormal = dateTimes[1];
				this._startAddUpDateAdFormal = dateTimes[2];
				this._startAddUpDateAdInFormal = dateTimes[3];
			}
		}

		/// public propaty name  :  StartAddUpDateJpFormal
		/// <summary>計上年月日（開始） 和暦プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   計上年月日（開始） 和暦プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string StartAddUpDateJpFormal
		{
			get{return _startAddUpDateJpFormal;}
		}

		/// public propaty name  :  StartAddUpDateJpInFormal
		/// <summary>計上年月日（開始） 和暦(略)プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   計上年月日（開始） 和暦(略)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string StartAddUpDateJpInFormal
		{
			get{return _startAddUpDateJpInFormal;}
		}

		/// public propaty name  :  StartAddUpDateAdFormal
		/// <summary>計上年月日（開始） 西暦プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   計上年月日（開始） 西暦プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string StartAddUpDateAdFormal
		{
			get{return _startAddUpDateAdFormal;}
		}

		/// public propaty name  :  StartAddUpDateAdInFormal
		/// <summary>計上年月日（開始） 西暦(略)プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   計上年月日（開始） 西暦(略)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string StartAddUpDateAdInFormal
		{
			get{return _startAddUpDateAdInFormal;}
		}

		/// public propaty name  :  EndAddUpDate
		/// <summary>計上年月日（終了）プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   計上年月日（終了）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime EndAddUpDate
		{
			get{return _endAddUpDate;}
			set
			{
				_endAddUpDate = value;
				string[] dateTimes = TDateTime.DateTimeToStringArray("YYYYMMDD", value);
				this._endAddUpDateJpFormal = dateTimes[0];
				this._endAddUpDateJpInFormal = dateTimes[1];
				this._endAddUpDateAdFormal = dateTimes[2];
				this._endAddUpDateAdInFormal = dateTimes[3];
			}
		}

		/// public propaty name  :  EndAddUpDateJpFormal
		/// <summary>計上年月日（終了） 和暦プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   計上年月日（終了） 和暦プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string EndAddUpDateJpFormal
		{
			get{return _endAddUpDateJpFormal;}
		}

		/// public propaty name  :  EndAddUpDateJpInFormal
		/// <summary>計上年月日（終了） 和暦(略)プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   計上年月日（終了） 和暦(略)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string EndAddUpDateJpInFormal
		{
			get{return _endAddUpDateJpInFormal;}
		}

		/// public propaty name  :  EndAddUpDateAdFormal
		/// <summary>計上年月日（終了） 西暦プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   計上年月日（終了） 西暦プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string EndAddUpDateAdFormal
		{
			get{return _endAddUpDateAdFormal;}
		}

		/// public propaty name  :  EndAddUpDateAdInFormal
		/// <summary>計上年月日（終了） 西暦(略)プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   計上年月日（終了） 西暦(略)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string EndAddUpDateAdInFormal
		{
			get{return _endAddUpDateAdInFormal;}
		}

		/// public propaty name  :  StartAddUpYearMonth
		/// <summary>計上年月（開始）プロパティ</summary>
		/// <value>YYYYMM</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   計上年月（開始）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 StartAddUpYearMonth
		{
			get{return _startAddUpYearMonth;}
			set{_startAddUpYearMonth = value;}
		}

		/// public propaty name  :  EndAddUpYearMonth
		/// <summary>計上年月（終了）プロパティ</summary>
		/// <value>YYYYMM</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   計上年月（終了）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 EndAddUpYearMonth
		{
			get{return _endAddUpYearMonth;}
			set{_endAddUpYearMonth = value;}
		}

		/// public propaty name  :  IsOutputZeroBlance
		/// <summary>残高０出力プロパティ</summary>
		/// <value>true:請求残高が０の場合でも仮想的に情報を作成する。false;請求残高が０の場合は作成しない</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   残高０出力プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public bool IsOutputZeroBlance
		{
			get{return _isOutputZeroBlance;}
			set{_isOutputZeroBlance = value;}
		}

		/// public propaty name  :  IsOutputAllSecRec
		/// <summary>全拠点レコード出力プロパティ</summary>
		/// <value>true:全拠点レコードを出力する。false:全拠点レコードを出力しない</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   全拠点レコード出力プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public bool IsOutputAllSecRec
		{
			get{return _isOutputAllSecRec;}
			set{_isOutputAllSecRec = value;}
		}

		/// public propaty name  :  StartKana
		/// <summary>得意先カナ（開始）プロパティ</summary>
		/// <value>YYYYMM</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   得意先カナ（開始）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string StartKana
		{
			get{return _startKana;}
			set{_startKana = value;}
		}

		/// public propaty name  :  EndKana
		/// <summary>得意先カナ（終了）プロパティ</summary>
		/// <value>YYYYMM</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   得意先カナ（終了）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string EndKana
		{
			get{return _endKana;}
			set{_endKana = value;}
		}

		/// public propaty name  :  CorporateDivCodeList
		/// <summary>全個人・法人区分プロパティ</summary>
		/// <value>true:全ての個人・法人区分を対象とする,false:個人・法人区分リストに基づいて検索する</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   全個人・法人区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public bool IsAllCorporateDivCode
		{
			get{return _isAllCorporateDivCode;}
			set{_isAllCorporateDivCode = value;}
		}

		/// public propaty name  :  CorporateDivCodeList
		/// <summary>個人・法人区分リストプロパティ</summary>
		/// <value>抽出対象となっている個人・法人区分のリスト</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   個人・法人区分リストプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ArrayList CorporateDivCodeList
		{
			get{return _corporateDivCodeList;}
			set{_corporateDivCodeList = value;}
		}

		/// public propaty name  :  IsJudgeBillOutputCode
		/// <summary>請求書出力区分判断プロパティ</summary>
		/// <value>true:全拠点レコードを出力する。false:全拠点レコードを出力しない</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   請求書出力区分判断プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public bool IsJudgeBillOutputCode
		{
			get{return _isJudgeBillOutputCode;}
			set{_isJudgeBillOutputCode = value;}
		}

		/// public propaty name  :  EmployeeKind
		/// <summary>従業員区分プロパティ</summary>
		/// <value>0:得意先,1:集金</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   従業員区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 EmployeeKind
		{
			get{return _employeeKind;}
			set{_employeeKind = value;}
		}

		/// public propaty name  :  StartEmployeeCode
		/// <summary>従業員コード（開始）プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   従業員コード（開始）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string StartEmployeeCode
		{
			get{return _startEmployeeCode;}
			set{_startEmployeeCode = value;}
		}

		/// public propaty name  :  EndEmployeeCode
		/// <summary>従業員コード（終了）プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   従業員コード（終了）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string EndEmployeeCode
		{
			get{return _endEmployeeCode;}
			set{_endEmployeeCode = value;}
		}

		/// public propaty name  :  StartCustAnalysCode1
		/// <summary>開始得意先分析コード１プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始得意先分析コード１プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 StartCustAnalysCode1
		{
			get{return _startCustAnalysCode1;}
			set{_startCustAnalysCode1 = value;}
		}

		/// public propaty name  :  StartCustAnalysCode2
		/// <summary>開始得意先分析コード２プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始得意先分析コード２プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 StartCustAnalysCode2
		{
			get{return _startCustAnalysCode2;}
			set{_startCustAnalysCode2 = value;}
		}

		/// public propaty name  :  StartCustAnalysCode3
		/// <summary>開始得意先分析コード３プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始得意先分析コード３プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 StartCustAnalysCode3
		{
			get{return _startCustAnalysCode3;}
			set{_startCustAnalysCode3 = value;}
		}

		/// public propaty name  :  StartCustAnalysCode4
		/// <summary>開始得意先分析コード４プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始得意先分析コード４プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 StartCustAnalysCode4
		{
			get{return _startCustAnalysCode4;}
			set{_startCustAnalysCode4 = value;}
		}

		/// public propaty name  :  StartCustAnalysCode5
		/// <summary>開始得意先分析コード５プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始得意先分析コード５プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 StartCustAnalysCode5
		{
			get{return _startCustAnalysCode5;}
			set{_startCustAnalysCode5 = value;}
		}

		/// public propaty name  :  StartCustAnalysCode6
		/// <summary>開始得意先分析コード６プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始得意先分析コード６プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 StartCustAnalysCode6
		{
			get{return _startCustAnalysCode6;}
			set{_startCustAnalysCode6 = value;}
		}

		/// public propaty name  :  EndCustAnalysCode1
		/// <summary>終了得意先分析コード１プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了得意先分析コード１プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 EndCustAnalysCode1
		{
			get{return _endCustAnalysCode1;}
			set{_endCustAnalysCode1 = value;}
		}

		/// public propaty name  :  EndCustAnalysCode2
		/// <summary>終了得意先分析コード２プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了得意先分析コード２プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 EndCustAnalysCode2
		{
			get{return _endCustAnalysCode2;}
			set{_endCustAnalysCode2 = value;}
		}

		/// public propaty name  :  EndCustAnalysCode3
		/// <summary>終了得意先分析コード３プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了得意先分析コード３プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 EndCustAnalysCode3
		{
			get{return _endCustAnalysCode3;}
			set{_endCustAnalysCode3 = value;}
		}

		/// public propaty name  :  EndCustAnalysCode4
		/// <summary>終了得意先分析コード４プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了得意先分析コード４プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 EndCustAnalysCode4
		{
			get{return _endCustAnalysCode4;}
			set{_endCustAnalysCode4 = value;}
		}

		/// public propaty name  :  EndCustAnalysCode5
		/// <summary>終了得意先分析コード５プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了得意先分析コード５プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 EndCustAnalysCode5
		{
			get{return _endCustAnalysCode5;}
			set{_endCustAnalysCode5 = value;}
		}

		/// public propaty name  :  EndCustAnalysCode6
		/// <summary>終了得意先分析コード６プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了得意先分析コード６プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 EndCustAnalysCode6
		{
			get{return _endCustAnalysCode6;}
			set{_endCustAnalysCode6 = value;}
		}


		/// <summary>
		/// 請求KINGET用抽出条件パラメータクラスコンストラクタ
		/// </summary>
		/// <returns>SeiKingetParameterクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SeiKingetParameterクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public SeiKingetParameter()
		{
			this._addUpSecCodeList = new ArrayList();
			this.StartAddUpDate = DateTime.MinValue;
			this.EndAddUpDate = DateTime.MinValue;
			this._corporateDivCodeList = new ArrayList();
		}

		/// <summary>
		/// 請求KINGET用抽出条件パラメータクラスコンストラクタ
		/// </summary>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="addUpSecCodeList">計上拠点コードリスト(集計の対象となっている拠点コード)</param>
		/// <param name="isSelectAllSection">全社選択(true:全社選択 false:各拠点選択)</param>
		/// <param name="startCustomerCode">得意先コード（開始）</param>
		/// <param name="endCustomerCode">得意先コード（終了）</param>
		/// <param name="totalDay">締日</param>
		/// <param name="startTotalDay">締日(開始)</param>
		/// <param name="endTotalDay">締日(終了)</param>
		/// <param name="startAddUpDate">計上年月日（開始）(YYYYMMDD)</param>
		/// <param name="endAddUpDate">計上年月日（終了）(YYYYMMDD)</param>
		/// <param name="startAddUpYearMonth">計上年月（開始）(YYYYMM)</param>
		/// <param name="endAddUpYearMonth">計上年月（終了）(YYYYMM)</param>
		/// <param name="isOutputZeroBlance">残高０出力(true:請求残高が０の場合でも仮想的に情報を作成する。false;請求残高が０の場合は作成しない)</param>
		/// <param name="isOutputAllSecRec">全拠点レコード出力(true:全拠点レコードを出力する。false:全拠点レコードを出力しない)</param>
		/// <param name="startKana">得意先カナ（開始）</param>
		/// <param name="endKana">得意先カナ（終了）</param>
		/// <param name="isAllCorporateDivCode">全個人・法人区分(true:全ての個人・法人区分を対象とする,false:個人・法人区分リストに基づいて検索する)</param>
		/// <param name="corporateDivCodeList">個人・法人区分リスト(抽出対象となっている個人・法人区分のリスト)</param>
		/// <param name="isJudgeBillOutputCode">請求書出力区分判断(true:請求書出力区分を判断する,false:請求書出力区分を判断しない)</param>
		/// <param name="employeeKind">従業員区分(0:得意先,1:集金)</param>
		/// <param name="startEmployeeCode">従業員コード（開始）</param>
		/// <param name="endEmployeeCode">従業員コード（終了）</param>		
		/// <param name="startCustAnalysCode1">開始得意先分析コード１</param>
		/// <param name="startCustAnalysCode2">開始得意先分析コード２</param>
		/// <param name="startCustAnalysCode3">開始得意先分析コード３</param>
		/// <param name="startCustAnalysCode4">開始得意先分析コード４</param>
		/// <param name="startCustAnalysCode5">開始得意先分析コード５</param>
		/// <param name="startCustAnalysCode6">開始得意先分析コード６</param>
		/// <param name="endCustAnalysCode1">終了得意先分析コード１</param>
		/// <param name="endCustAnalysCode2">終了得意先分析コード２</param>
		/// <param name="endCustAnalysCode3">終了得意先分析コード３</param>
		/// <param name="endCustAnalysCode4">終了得意先分析コード４</param>
		/// <param name="endCustAnalysCode5">終了得意先分析コード５</param>
		/// <param name="endCustAnalysCode6">終了得意先分析コード６</param>
		/// <returns>SeiKingetParameterクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SeiKingetParameterクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public SeiKingetParameter(string enterpriseCode,ArrayList addUpSecCodeList,bool isSelectAllSection,Int32 startCustomerCode,Int32 endCustomerCode,Int32 totalDay,Int32 startTotalDay,Int32 endTotalDay,DateTime startAddUpDate,DateTime endAddUpDate,Int32 startAddUpYearMonth,Int32 endAddUpYearMonth,bool isOutputZeroBlance,bool isOutputAllSecRec,
			string startKana,string endKana,bool isAllCorporateDivCode,ArrayList corporateDivCodeList, bool isJudgeBillOutputCode,int employeeKind,string startEmployeeCode,string endEmployeeCode,Int32 startCustAnalysCode1,Int32 startCustAnalysCode2,Int32 startCustAnalysCode3,Int32 startCustAnalysCode4,Int32 startCustAnalysCode5,Int32 startCustAnalysCode6,Int32 endCustAnalysCode1,Int32 endCustAnalysCode2,Int32 endCustAnalysCode3,Int32 endCustAnalysCode4,Int32 endCustAnalysCode5,Int32 endCustAnalysCode6)
		{
			this._enterpriseCode = enterpriseCode;
			this._addUpSecCodeList = addUpSecCodeList;
			this._isSelectAllSection = isSelectAllSection;
			this._startCustomerCode = startCustomerCode;
			this._endCustomerCode = endCustomerCode;
			this._totalDay = totalDay;
			this._startTotalDay = startTotalDay;
			this._endTotalDay = endTotalDay;
			this.StartAddUpDate = startAddUpDate;
			this.EndAddUpDate = endAddUpDate;
			this._startAddUpYearMonth = startAddUpYearMonth;
			this._endAddUpYearMonth = endAddUpYearMonth;
			this._isOutputZeroBlance = isOutputZeroBlance;
			this._isOutputAllSecRec = isOutputAllSecRec;
			this._startKana = startKana;
			this._endKana = endKana;
			this._isAllCorporateDivCode = isAllCorporateDivCode;
			this._corporateDivCodeList = corporateDivCodeList;
			this._isJudgeBillOutputCode = isJudgeBillOutputCode;
			this._employeeKind = employeeKind;
			this._startEmployeeCode = startEmployeeCode;
			this._endEmployeeCode = endEmployeeCode;
			this._startCustAnalysCode1 = startCustAnalysCode1;
			this._startCustAnalysCode2 = startCustAnalysCode2;
			this._startCustAnalysCode3 = startCustAnalysCode3;
			this._startCustAnalysCode4 = startCustAnalysCode4;
			this._startCustAnalysCode5 = startCustAnalysCode5;
			this._startCustAnalysCode6 = startCustAnalysCode6;
			this._endCustAnalysCode1 = endCustAnalysCode1;
			this._endCustAnalysCode2 = endCustAnalysCode2;
			this._endCustAnalysCode3 = endCustAnalysCode3;
			this._endCustAnalysCode4 = endCustAnalysCode4;
			this._endCustAnalysCode5 = endCustAnalysCode5;
			this._endCustAnalysCode6 = endCustAnalysCode6;
		}

		/// <summary>
		/// 請求KINGET用抽出条件パラメータクラス複製処理
		/// </summary>
		/// <returns>SeiKingetParameterクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   自身の内容と等しいSeiKingetParameterクラスのインスタンスを返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public SeiKingetParameter Clone()
		{
			return new SeiKingetParameter(this._enterpriseCode,this._addUpSecCodeList,this._isSelectAllSection,this._startCustomerCode,this._endCustomerCode,this._totalDay,this._startTotalDay,this._endTotalDay,this._startAddUpDate,this._endAddUpDate,this._startAddUpYearMonth,this._endAddUpYearMonth,this._isOutputZeroBlance,this._isOutputAllSecRec,this._startKana,this._endKana,this._isAllCorporateDivCode,this._corporateDivCodeList,this._isJudgeBillOutputCode,this._employeeKind,this._startEmployeeCode,this._endEmployeeCode,this._startCustAnalysCode1,this._startCustAnalysCode2,this._startCustAnalysCode3,this._startCustAnalysCode4,this._startCustAnalysCode5,this._startCustAnalysCode6,this._endCustAnalysCode1,this._endCustAnalysCode2,this._endCustAnalysCode3,this._endCustAnalysCode4,this._endCustAnalysCode5,this._endCustAnalysCode6);
		}

		/// <summary>
		/// 請求KINGET用抽出条件パラメータクラス初期化処理
		/// </summary>
		/// <remarks>
		/// <br>Note　　　　　　 :   SeiKingetParameterクラスを初期化します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public void Clear()
		{
			this._enterpriseCode = "";
			this._addUpSecCodeList = new ArrayList();
			this._isSelectAllSection = false;
			this._startCustomerCode = 0;
			this._endCustomerCode = 0;
			this._totalDay = 0;
			this._startTotalDay = 0;
			this._endTotalDay = 0;
			this.StartAddUpDate = DateTime.MinValue;
			this.EndAddUpDate = DateTime.MinValue;
			this._startAddUpYearMonth = 0;
			this._endAddUpYearMonth = 0;
			this._isOutputZeroBlance = false;
			this._isOutputAllSecRec = false;
			this._startKana = "";
			this._endKana = "";
			this._isAllCorporateDivCode = false;
			this._corporateDivCodeList = new ArrayList();
			this._isJudgeBillOutputCode = false;
			this._employeeKind = 0;
			this._startEmployeeCode = "";
			this._endEmployeeCode = "";
			this._startCustAnalysCode1 = 0;
			this._startCustAnalysCode2 = 0;
			this._startCustAnalysCode3 = 0;
			this._startCustAnalysCode4 = 0;
			this._startCustAnalysCode5 = 0;
			this._startCustAnalysCode6 = 0;
			this._endCustAnalysCode1 = 999;
			this._endCustAnalysCode2 = 999;
			this._endCustAnalysCode3 = 999;
			this._endCustAnalysCode4 = 999;
			this._endCustAnalysCode5 = 999;
			this._endCustAnalysCode6 = 999;
		}

		/// <summary>
		/// 請求KINGET用抽出条件パラメータクラス比較処理
		/// </summary>
		/// <param name="target">比較対象のSeiKingetParameterクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SeiKingetParameterクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public bool Equals(SeiKingetParameter target)
		{
			return ((this.EnterpriseCode == target.EnterpriseCode)
				&& (this._addUpSecCodeList.Equals(target.AddUpSecCodeList))
				&& (this.IsSelectAllSection == target.IsSelectAllSection)
				&& (this.StartCustomerCode == target.StartCustomerCode)
				&& (this.EndCustomerCode == target.EndCustomerCode)
				&& (this.TotalDay == target.TotalDay)
				&& (this.StartTotalDay == target.StartTotalDay)
				&& (this.EndTotalDay == target.EndTotalDay)
				&& (this.StartAddUpDate == target.StartAddUpDate)
				&& (this.EndAddUpDate == target.EndAddUpDate)
				&& (this.StartAddUpYearMonth == target.StartAddUpYearMonth)
				&& (this.EndAddUpYearMonth == target.EndAddUpYearMonth)
				&& (this.IsOutputZeroBlance == target.IsOutputZeroBlance)
				&& (this.IsOutputAllSecRec == target.IsOutputAllSecRec)
				&& (this.StartKana == target.StartKana)
				&& (this.EndKana == target.EndKana)
				&& (this.IsAllCorporateDivCode == target.IsAllCorporateDivCode)
				&& (this.CorporateDivCodeList == target.CorporateDivCodeList)
				&& (this.IsJudgeBillOutputCode == target.IsJudgeBillOutputCode)
				&& (this.StartEmployeeCode == target.StartEmployeeCode)
				&& (this.EndEmployeeCode == target.EndEmployeeCode)
				&& (this.StartCustAnalysCode1 == target.StartCustAnalysCode1)
				&& (this.StartCustAnalysCode2 == target.StartCustAnalysCode2)
				&& (this.StartCustAnalysCode3 == target.StartCustAnalysCode3)
				&& (this.StartCustAnalysCode4 == target.StartCustAnalysCode4)
				&& (this.StartCustAnalysCode5 == target.StartCustAnalysCode5)
				&& (this.StartCustAnalysCode6 == target.StartCustAnalysCode6)
				&& (this.EndCustAnalysCode1 == target.EndCustAnalysCode1)
				&& (this.EndCustAnalysCode2 == target.EndCustAnalysCode2)
				&& (this.EndCustAnalysCode3 == target.EndCustAnalysCode3)
				&& (this.EndCustAnalysCode4 == target.EndCustAnalysCode4)
				&& (this.EndCustAnalysCode5 == target.EndCustAnalysCode5)
				&& (this.EndCustAnalysCode6 == target.EndCustAnalysCode6)
				);
		}

		/// <summary>
		/// 請求KINGET用抽出条件パラメータクラス比較処理
		/// </summary>
		/// <param name="para1">比較するSeiKingetParameterクラスのインスタンス</param>
		/// <param name="para2">比較するSeiKingetParameterクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SeiKingetParameterクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static bool Equals(SeiKingetParameter para1, SeiKingetParameter para2)
		{
			return ((para1.EnterpriseCode == para2.EnterpriseCode)
				&& (para1.AddUpSecCodeList.Equals(para2.AddUpSecCodeList))
				&& (para1.IsSelectAllSection == para2.IsSelectAllSection)
				&& (para1.StartCustomerCode == para2.StartCustomerCode)
				&& (para1.EndCustomerCode == para2.EndCustomerCode)
				&& (para1.TotalDay == para2.TotalDay)
				&& (para1.StartTotalDay == para2.StartTotalDay)
				&& (para1.EndTotalDay == para2.EndTotalDay)
				&& (para1.StartAddUpDate == para2.StartAddUpDate)
				&& (para1.EndAddUpDate == para2.EndAddUpDate)
				&& (para1.StartAddUpYearMonth == para2.StartAddUpYearMonth)
				&& (para1.EndAddUpYearMonth == para2.EndAddUpYearMonth)
				&& (para1.IsOutputZeroBlance == para2.IsOutputZeroBlance)
				&& (para1.IsOutputAllSecRec == para2.IsOutputAllSecRec)
				&& (para1.StartKana == para2.StartKana)
				&& (para1.EndKana == para2.EndKana)
				&& (para1.IsAllCorporateDivCode == para2.IsAllCorporateDivCode)
				&& (para1.CorporateDivCodeList == para2.CorporateDivCodeList)
				&& (para1.IsJudgeBillOutputCode == para2.IsJudgeBillOutputCode)
				&& (para1.StartEmployeeCode == para2.StartEmployeeCode)
				&& (para1.EndEmployeeCode == para2.EndEmployeeCode)
				&& (para1.StartCustAnalysCode1 == para2.StartCustAnalysCode1)
				&& (para1.StartCustAnalysCode2 == para2.StartCustAnalysCode2)
				&& (para1.StartCustAnalysCode3 == para2.StartCustAnalysCode3)
				&& (para1.StartCustAnalysCode4 == para2.StartCustAnalysCode4)
				&& (para1.StartCustAnalysCode5 == para2.StartCustAnalysCode5)
				&& (para1.StartCustAnalysCode6 == para2.StartCustAnalysCode6)
				&& (para1.EndCustAnalysCode1 == para2.EndCustAnalysCode1)
				&& (para1.EndCustAnalysCode2 == para2.EndCustAnalysCode2)
				&& (para1.EndCustAnalysCode3 == para2.EndCustAnalysCode3)
				&& (para1.EndCustAnalysCode4 == para2.EndCustAnalysCode4)
				&& (para1.EndCustAnalysCode5 == para2.EndCustAnalysCode5)
				&& (para1.EndCustAnalysCode6 == para2.EndCustAnalysCode6)
				);
		}
		/// <summary>
		/// 請求KINGET用抽出条件パラメータクラス比較処理
		/// </summary>
		/// <param name="target">比較対象のSeiKingetParameterクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SeiKingetParameterクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ArrayList Compare(SeiKingetParameter target)
		{
			ArrayList resList = new ArrayList();
			if(this.EnterpriseCode != target.EnterpriseCode)resList.Add("EnterpriseCode");
			if(this.AddUpSecCodeList != target.AddUpSecCodeList)resList.Add("AddUpSecCodeList");
			if(this.IsSelectAllSection != target.IsSelectAllSection)resList.Add("IsSelectAllSection");
			if(this.StartCustomerCode != target.StartCustomerCode)resList.Add("StartCustomerCode");
			if(this.EndCustomerCode != target.EndCustomerCode)resList.Add("EndCustomerCode");
			if(this.TotalDay != target.TotalDay)resList.Add("TotalDay");
			if(this.StartTotalDay != target.StartTotalDay)resList.Add("StartTotalDay");
			if(this.EndTotalDay != target.EndTotalDay)resList.Add("EndTotalDay");
			if(this.StartAddUpDate != target.StartAddUpDate)resList.Add("StartAddUpDate");
			if(this.EndAddUpDate != target.EndAddUpDate)resList.Add("EndAddUpDate");
			if(this.StartAddUpYearMonth != target.StartAddUpYearMonth)resList.Add("StartAddUpYearMonth");
			if(this.EndAddUpYearMonth != target.EndAddUpYearMonth)resList.Add("EndAddUpYearMonth");
			if(this.IsOutputZeroBlance != target.IsOutputZeroBlance)resList.Add("IsOutputZeroBlance");
			if(this.IsOutputAllSecRec != target.IsOutputAllSecRec)resList.Add("IsOutputAllSecRec");
			if(this.StartKana != target.StartKana)resList.Add("StartKana");
			if(this.EndKana != target.EndKana)resList.Add("EndKana");
			if(this.IsAllCorporateDivCode != target.IsAllCorporateDivCode)resList.Add("IsAllCorporateDivCode");
			if(this.CorporateDivCodeList != target.CorporateDivCodeList)resList.Add("CorporateDivCodeList");
			if(this.IsJudgeBillOutputCode != target.IsJudgeBillOutputCode)resList.Add("IsJudgeBillOutputCode");
			if(this.StartEmployeeCode != target.StartEmployeeCode)resList.Add("StartEmployeeCode");
			if(this.EndEmployeeCode != target.EndEmployeeCode)resList.Add("EndEmployeeCode");
			if(this.StartCustAnalysCode1 != target.StartCustAnalysCode1)resList.Add("StartCustAnalysCode1");
			if(this.StartCustAnalysCode2 != target.StartCustAnalysCode2)resList.Add("StartCustAnalysCode2");
			if(this.StartCustAnalysCode3 != target.StartCustAnalysCode3)resList.Add("StartCustAnalysCode3");
			if(this.StartCustAnalysCode4 != target.StartCustAnalysCode4)resList.Add("StartCustAnalysCode4");
			if(this.StartCustAnalysCode5 != target.StartCustAnalysCode5)resList.Add("StartCustAnalysCode5");
			if(this.StartCustAnalysCode6 != target.StartCustAnalysCode6)resList.Add("StartCustAnalysCode6");
			if(this.EndCustAnalysCode1 != target.EndCustAnalysCode1)resList.Add("EndCustAnalysCode1");
			if(this.EndCustAnalysCode2 != target.EndCustAnalysCode2)resList.Add("EndCustAnalysCode2");
			if(this.EndCustAnalysCode3 != target.EndCustAnalysCode3)resList.Add("EndCustAnalysCode3");
			if(this.EndCustAnalysCode4 != target.EndCustAnalysCode4)resList.Add("EndCustAnalysCode4");
			if(this.EndCustAnalysCode5 != target.EndCustAnalysCode5)resList.Add("EndCustAnalysCode5");
			if(this.EndCustAnalysCode6 != target.EndCustAnalysCode6)resList.Add("EndCustAnalysCode6");

			return resList;
		}

		/// <summary>
		/// 請求KINGET用抽出条件パラメータクラス比較処理
		/// </summary>
		/// <param name="para1">比較するSeiKingetParameterクラスのインスタンス</param>
		/// <param name="para2">比較するSeiKingetParameterクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SeiKingetParameterクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static ArrayList Compare(SeiKingetParameter para1, SeiKingetParameter para2)
		{
			ArrayList resList = new ArrayList();
			if(para1.EnterpriseCode != para2.EnterpriseCode)resList.Add("EnterpriseCode");
			if(para1.AddUpSecCodeList != para2.AddUpSecCodeList)resList.Add("AddUpSecCodeList");
			if(para1.IsSelectAllSection != para2.IsSelectAllSection)resList.Add("IsSelectAllSection");
			if(para1.StartCustomerCode != para2.StartCustomerCode)resList.Add("StartCustomerCode");
			if(para1.EndCustomerCode != para2.EndCustomerCode)resList.Add("EndCustomerCode");
			if(para1.TotalDay != para2.TotalDay)resList.Add("TotalDay");
			if(para1.StartTotalDay != para2.StartTotalDay)resList.Add("StartTotalDay");
			if(para1.EndTotalDay != para2.EndTotalDay)resList.Add("EndTotalDay");
			if(para1.StartAddUpDate != para2.StartAddUpDate)resList.Add("StartAddUpDate");
			if(para1.EndAddUpDate != para2.EndAddUpDate)resList.Add("EndAddUpDate");
			if(para1.StartAddUpYearMonth != para2.StartAddUpYearMonth)resList.Add("StartAddUpYearMonth");
			if(para1.EndAddUpYearMonth != para2.EndAddUpYearMonth)resList.Add("EndAddUpYearMonth");
			if(para1.IsOutputZeroBlance != para2.IsOutputZeroBlance)resList.Add("IsOutputZeroBlance");
			if(para1.IsOutputAllSecRec != para2.IsOutputAllSecRec)resList.Add("IsOutputAllSecRec");
			if(para1.StartKana != para2.StartKana)resList.Add("StartKana");
			if(para1.EndKana != para2.EndKana)resList.Add("EndKana");
			if(para1.IsAllCorporateDivCode != para2.IsAllCorporateDivCode)resList.Add("IsAllCorporateDivCode");
			if(para1.CorporateDivCodeList != para2.CorporateDivCodeList)resList.Add("CorporateDivCodeList");
			if(para1.IsJudgeBillOutputCode != para2.IsJudgeBillOutputCode)resList.Add("IsJudgeBillOutputCode");
			if(para1.StartEmployeeCode != para2.StartEmployeeCode)resList.Add("StartEmployeeCode");
			if(para1.EndEmployeeCode != para2.EndEmployeeCode)resList.Add("EndEmployeeCode");
			if(para1.StartCustAnalysCode1 != para2.StartCustAnalysCode1)resList.Add("StartCustAnalysCode1");
			if(para1.StartCustAnalysCode2 != para2.StartCustAnalysCode2)resList.Add("StartCustAnalysCode2");
			if(para1.StartCustAnalysCode3 != para2.StartCustAnalysCode3)resList.Add("StartCustAnalysCode3");
			if(para1.StartCustAnalysCode4 != para2.StartCustAnalysCode4)resList.Add("StartCustAnalysCode4");
			if(para1.StartCustAnalysCode5 != para2.StartCustAnalysCode5)resList.Add("StartCustAnalysCode5");
			if(para1.StartCustAnalysCode6 != para2.StartCustAnalysCode6)resList.Add("StartCustAnalysCode6");
			if(para1.EndCustAnalysCode1 != para2.EndCustAnalysCode1)resList.Add("EndCustAnalysCode1");
			if(para1.EndCustAnalysCode2 != para2.EndCustAnalysCode2)resList.Add("EndCustAnalysCode2");
			if(para1.EndCustAnalysCode3 != para2.EndCustAnalysCode3)resList.Add("EndCustAnalysCode3");
			if(para1.EndCustAnalysCode4 != para2.EndCustAnalysCode4)resList.Add("EndCustAnalysCode4");
			if(para1.EndCustAnalysCode5 != para2.EndCustAnalysCode5)resList.Add("EndCustAnalysCode5");
			if(para1.EndCustAnalysCode6 != para2.EndCustAnalysCode6)resList.Add("EndCustAnalysCode6");

			return resList;
		}
	}
}
