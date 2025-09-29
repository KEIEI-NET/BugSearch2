using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
	/// public class name:   CompanyInf
	/// <summary>
	///                      自社情報
	/// </summary>
	/// <remarks>
	/// <br>note             :   自社情報ヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   2007/7/25</br>
	/// <br>Genarated Date   :   2008/01/11  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   2008/01/09  杉村</br>
	/// <br>                 :   部署管理区分の追加（全体初期値設定マスタから移動）</br>
    /// <br>Update Note      :   2008/06/03  忍　幸史</br>
    /// <br>                 :   部署管理区分から「拠点＋部＋課」を削除</br>
    /// <br>Update Note      :   2011/07/14  LDNS wangqx</br>
    /// <br>                 :   データクリア処理実行年月日、データクリア処理実行時分秒ミリ秒を追加</br>
	/// </remarks>
	public class CompanyInf
	{
		/// <summary>作成日時</summary>
		/// <remarks>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</remarks>
		private DateTime _createDateTime;

		/// <summary>更新日時</summary>
		/// <remarks>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</remarks>
		private DateTime _updateDateTime;

		/// <summary>企業コード</summary>
		/// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
		private string _enterpriseCode = "";

		/// <summary>GUID</summary>
		/// <remarks>共通ファイルヘッダ</remarks>
		private Guid _fileHeaderGuid;

		/// <summary>更新従業員コード</summary>
		/// <remarks>共通ファイルヘッダ</remarks>
		private string _updEmployeeCode = "";

		/// <summary>更新アセンブリID1</summary>
		/// <remarks>共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）</remarks>
		private string _updAssemblyId1 = "";

		/// <summary>更新アセンブリID2</summary>
		/// <remarks>共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）</remarks>
		private string _updAssemblyId2 = "";

		/// <summary>論理削除区分</summary>
		/// <remarks>共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除)</remarks>
		private Int32 _logicalDeleteCode;

		/// <summary>自社コード</summary>
		private Int32 _companyCode;

		/// <summary>自社締日</summary>
		/// <remarks>DD　期首年月日より算出される末日未満であること期首日の日を越える値</remarks>
		private Int32 _companyTotalDay;

		/// <summary>会計年度</summary>
		/// <remarks>YYYY</remarks>
		private Int32 _financialYear;

		/// <summary>期首月</summary>
		/// <remarks>MM</remarks>
		private Int32 _companyBiginMonth;

		/// <summary>期首月2</summary>
		/// <remarks>MM</remarks>
		private Int32 _companyBiginMonth2;

		/// <summary>期首年月日</summary>
		/// <remarks>YYYYMMDD</remarks>
		private Int32 _companyBiginDate;

		/// <summary>開始年区分</summary>
		/// <remarks>0:前年 1:翌年</remarks>
		private Int32 _startYearDiv;

		/// <summary>開始月区分</summary>
		/// <remarks>0:前月 1:翌月</remarks>
		private Int32 _startMonthDiv;

		/// <summary>自社名称1</summary>
		private string _companyName1 = "";

		/// <summary>自社名称2</summary>
		private string _companyName2 = "";

		/// <summary>郵便番号</summary>
		private string _postNo = "";

		/// <summary>住所1（都道府県市区郡・町村・字）</summary>
		private string _address1 = "";

		/// <summary>住所2（丁目）</summary>
		private Int32 _address2;

		/// <summary>住所3（番地）</summary>
		private string _address3 = "";

		/// <summary>住所4（アパート名称）</summary>
		private string _address4 = "";

		/// <summary>自社電話番号1</summary>
		private string _companyTelNo1 = "";

		/// <summary>自社電話番号2</summary>
		private string _companyTelNo2 = "";

		/// <summary>自社電話番号3</summary>
		private string _companyTelNo3 = "";

		/// <summary>自社電話番号タイトル1</summary>
		private string _companyTelTitle1 = "";

		/// <summary>自社電話番号タイトル2</summary>
		private string _companyTelTitle2 = "";

		/// <summary>自社電話番号タイトル3</summary>
		private string _companyTelTitle3 = "";

        /* --- DEL 2008/06/03 --------------------------------------------------------------------->>>>>
		/// <summary>部署管理区分</summary>
		/// <remarks>0:拠点　1:拠点＋部　2:拠点＋部＋課</remarks>
           --- DEL 2008/06/03 ---------------------------------------------------------------------<<<<<*/
        // --- ADD 2008/06/03 --------------------------------------------------------------------->>>>>
        /// <summary>部署管理区分</summary>
        /// <remarks>0:拠点　1:拠点＋部</remarks>
        // --- ADD 2008/06/03 ---------------------------------------------------------------------<<<<<
        private Int32 _secMngDiv;

        // --- ADD 2011/07/14 --------------------------------------------------------------------->>>>>
        /// <summary>データクリア処理実行年月日</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _dataClrExecDate;

        /// <summary>データクリア処理実行時分秒ミリ秒</summary>
        /// <remarks>HHMMSSXXX</remarks>
        private Int32 _dataClrExecTime;
        // --- ADD 2011/07/14 ---------------------------------------------------------------------<<<<<

        /// <summary>データ保存月数</summary>
        private Int32 _dataSaveMonths;

        /// <summary>データ圧縮日</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _dataCompressDt;

        /// <summary>実績データ保存月数</summary>
        private Int32 _resultDtSaveMonths;

        /// <summary>実績データ圧縮日</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _resultDtCompressDt;

        /// <summary>車輌部品データ保存月数</summary>
        private Int32 _caPrtsDtSaveMonths;

        /// <summary>車輌部品データ圧縮日</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _caPrtsDtCompressDt;

        /// <summary>マスタ保存月数</summary>
        private Int32 _masterSaveMonths;

        /// <summary>マスタ圧縮日</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _masterCompressDt;

		/// <summary>掛率優先区分</summary>
		/// <remarks>0:拠点優先 1:設定区分優先</remarks>
		private Int32 _ratePriorityDiv;

		/// <summary>企業名称</summary>
		private string _enterpriseName = "";

		/// <summary>更新従業員名称</summary>
		private string _updEmployeeName = "";


		/// public propaty name  :  CreateDateTime
		/// <summary>作成日時プロパティ</summary>
		/// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   作成日時プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime CreateDateTime
		{
			get{return _createDateTime;}
			set{_createDateTime = value;}
		}

		/// public propaty name  :  UpdateDateTime
		/// <summary>更新日時プロパティ</summary>
		/// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   更新日時プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime UpdateDateTime
		{
			get{return _updateDateTime;}
			set{_updateDateTime = value;}
		}

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

		/// public propaty name  :  FileHeaderGuid
		/// <summary>GUIDプロパティ</summary>
		/// <value>共通ファイルヘッダ</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   GUIDプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Guid FileHeaderGuid
		{
			get{return _fileHeaderGuid;}
			set{_fileHeaderGuid = value;}
		}

		/// public propaty name  :  UpdEmployeeCode
		/// <summary>更新従業員コードプロパティ</summary>
		/// <value>共通ファイルヘッダ</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   更新従業員コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string UpdEmployeeCode
		{
			get{return _updEmployeeCode;}
			set{_updEmployeeCode = value;}
		}

		/// public propaty name  :  UpdAssemblyId1
		/// <summary>更新アセンブリID1プロパティ</summary>
		/// <value>共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   更新アセンブリID1プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string UpdAssemblyId1
		{
			get{return _updAssemblyId1;}
			set{_updAssemblyId1 = value;}
		}

		/// public propaty name  :  UpdAssemblyId2
		/// <summary>更新アセンブリID2プロパティ</summary>
		/// <value>共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   更新アセンブリID2プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string UpdAssemblyId2
		{
			get{return _updAssemblyId2;}
			set{_updAssemblyId2 = value;}
		}

		/// public propaty name  :  LogicalDeleteCode
		/// <summary>論理削除区分プロパティ</summary>
		/// <value>共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   論理削除区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 LogicalDeleteCode
		{
			get{return _logicalDeleteCode;}
			set{_logicalDeleteCode = value;}
		}

		/// public propaty name  :  CompanyCode
		/// <summary>自社コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   自社コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 CompanyCode
		{
			get{return _companyCode;}
			set{_companyCode = value;}
		}

		/// public propaty name  :  CompanyTotalDay
		/// <summary>自社締日プロパティ</summary>
		/// <value>DD　期首年月日より算出される末日未満であること期首日の日を越える値</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   自社締日プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 CompanyTotalDay
		{
			get{return _companyTotalDay;}
			set{_companyTotalDay = value;}
		}

		/// public propaty name  :  FinancialYear
		/// <summary>会計年度プロパティ</summary>
		/// <value>YYYY</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   会計年度プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 FinancialYear
		{
			get{return _financialYear;}
			set{_financialYear = value;}
		}

		/// public propaty name  :  CompanyBiginMonth
		/// <summary>期首月プロパティ</summary>
		/// <value>MM</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   期首月プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 CompanyBiginMonth
		{
			get{return _companyBiginMonth;}
			set{_companyBiginMonth = value;}
		}

		/// public propaty name  :  CompanyBiginMonth2
		/// <summary>期首月2プロパティ</summary>
		/// <value>MM</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   期首月2プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 CompanyBiginMonth2
		{
			get{return _companyBiginMonth2;}
			set{_companyBiginMonth2 = value;}
		}

		/// public propaty name  :  CompanyBiginDate
		/// <summary>期首年月日プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   期首年月日プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 CompanyBiginDate
		{
			get{return _companyBiginDate;}
			set{_companyBiginDate = value;}
		}

		/// public propaty name  :  StartYearDiv
		/// <summary>開始年区分プロパティ</summary>
		/// <value>0:前年 1:翌年</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始年区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 StartYearDiv
		{
			get{return _startYearDiv;}
			set{_startYearDiv = value;}
		}

		/// public propaty name  :  StartMonthDiv
		/// <summary>開始月区分プロパティ</summary>
		/// <value>0:前月 1:翌月</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始月区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 StartMonthDiv
		{
			get{return _startMonthDiv;}
			set{_startMonthDiv = value;}
		}

		/// public propaty name  :  CompanyName1
		/// <summary>自社名称1プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   自社名称1プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string CompanyName1
		{
			get{return _companyName1;}
			set{_companyName1 = value;}
		}

		/// public propaty name  :  CompanyName2
		/// <summary>自社名称2プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   自社名称2プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string CompanyName2
		{
			get{return _companyName2;}
			set{_companyName2 = value;}
		}

		/// public propaty name  :  PostNo
		/// <summary>郵便番号プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   郵便番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string PostNo
		{
			get{return _postNo;}
			set{_postNo = value;}
		}

		/// public propaty name  :  Address1
		/// <summary>住所1（都道府県市区郡・町村・字）プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   住所1（都道府県市区郡・町村・字）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string Address1
		{
			get{return _address1;}
			set{_address1 = value;}
		}

		/// public propaty name  :  Address2
		/// <summary>住所2（丁目）プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   住所2（丁目）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 Address2
		{
			get{return _address2;}
			set{_address2 = value;}
		}

		/// public propaty name  :  Address3
		/// <summary>住所3（番地）プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   住所3（番地）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string Address3
		{
			get{return _address3;}
			set{_address3 = value;}
		}

		/// public propaty name  :  Address4
		/// <summary>住所4（アパート名称）プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   住所4（アパート名称）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string Address4
		{
			get{return _address4;}
			set{_address4 = value;}
		}

		/// public propaty name  :  CompanyTelNo1
		/// <summary>自社電話番号1プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   自社電話番号1プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string CompanyTelNo1
		{
			get{return _companyTelNo1;}
			set{_companyTelNo1 = value;}
		}

		/// public propaty name  :  CompanyTelNo2
		/// <summary>自社電話番号2プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   自社電話番号2プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string CompanyTelNo2
		{
			get{return _companyTelNo2;}
			set{_companyTelNo2 = value;}
		}

		/// public propaty name  :  CompanyTelNo3
		/// <summary>自社電話番号3プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   自社電話番号3プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string CompanyTelNo3
		{
			get{return _companyTelNo3;}
			set{_companyTelNo3 = value;}
		}

		/// public propaty name  :  CompanyTelTitle1
		/// <summary>自社電話番号タイトル1プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   自社電話番号タイトル1プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string CompanyTelTitle1
		{
			get{return _companyTelTitle1;}
			set{_companyTelTitle1 = value;}
		}

		/// public propaty name  :  CompanyTelTitle2
		/// <summary>自社電話番号タイトル2プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   自社電話番号タイトル2プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string CompanyTelTitle2
		{
			get{return _companyTelTitle2;}
			set{_companyTelTitle2 = value;}
		}

		/// public propaty name  :  CompanyTelTitle3
		/// <summary>自社電話番号タイトル3プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   自社電話番号タイトル3プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string CompanyTelTitle3
		{
			get{return _companyTelTitle3;}
			set{_companyTelTitle3 = value;}
		}

        /* --- DEL 2008/06/03 --------------------------------------------------------------------->>>>>
		/// public propaty name  :  SecMngDiv
		/// <summary>部署管理区分プロパティ</summary>
		/// <value>0:拠点　1:拠点＋部　2:拠点＋部＋課</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   部署管理区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
           --- DEL 2008/06/03 ---------------------------------------------------------------------<<<<<*/
        // --- ADD 2008/06/03 --------------------------------------------------------------------->>>>>
        /// public propaty name  :  SecMngDiv
        /// <summary>部署管理区分プロパティ</summary>
        /// <value>0:拠点　1:拠点＋部</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   部署管理区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        // --- ADD 2008/06/03 ---------------------------------------------------------------------<<<<<
        public Int32 SecMngDiv
		{
			get{return _secMngDiv;}
			set{_secMngDiv = value;}
		}

        // --- ADD 2011/07/14 --------------------------------------------------------------------->>>>>
        /// public propaty name  :  DataClrExecDate
        /// <summary>データクリア処理実行年月日プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   データクリア処理実行年月日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DataClrExecDate
        {
            get { return _dataClrExecDate; }
            set { _dataClrExecDate = value; }
        }

        /// public propaty name  :  DataClrExecTime
        /// <summary>データクリア処理実行時分秒ミリ秒プロパティ</summary>
        /// <value>HHMMSSXXX</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   データクリア処理実行時分秒ミリ秒プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DataClrExecTime
        {
            get { return _dataClrExecTime; }
            set { _dataClrExecTime = value; }
        }
        // --- ADD 2011/07/14 ---------------------------------------------------------------------<<<<<

        /// public propaty name  :  DataSaveMonths
        /// <summary>データ保存月数プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   データ保存月数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DataSaveMonths
        {
            get { return _dataSaveMonths; }
            set { _dataSaveMonths = value; }
        }

        /// public propaty name  :  DataCompressDt
        /// <summary>データ圧縮日プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   データ圧縮日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DataCompressDt
        {
            get { return _dataCompressDt; }
            set { _dataCompressDt = value; }
        }

        /// public propaty name  :  ResultDtSaveMonths
        /// <summary>実績データ保存月数プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   実績データ保存月数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ResultDtSaveMonths
        {
            get { return _resultDtSaveMonths; }
            set { _resultDtSaveMonths = value; }
        }

        /// public propaty name  :  ResultDtCompressDt
        /// <summary>実績データ圧縮日プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   実績データ圧縮日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ResultDtCompressDt
        {
            get { return _resultDtCompressDt; }
            set { _resultDtCompressDt = value; }
        }

        /// public propaty name  :  CaPrtsDtSaveMonths
        /// <summary>車輌部品データ保存月数プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車輌部品データ保存月数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CaPrtsDtSaveMonths
        {
            get { return _caPrtsDtSaveMonths; }
            set { _caPrtsDtSaveMonths = value; }
        }

        /// public propaty name  :  CaPrtsDtCompressDt
        /// <summary>車輌部品データ圧縮日プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車輌部品データ圧縮日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CaPrtsDtCompressDt
        {
            get { return _caPrtsDtCompressDt; }
            set { _caPrtsDtCompressDt = value; }
        }

        /// public propaty name  :  MasterSaveMonths
        /// <summary>マスタ保存月数プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   マスタ保存月数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 MasterSaveMonths
        {
            get { return _masterSaveMonths; }
            set { _masterSaveMonths = value; }
        }

        /// public propaty name  :  MasterCompressDt
        /// <summary>マスタ圧縮日プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   マスタ圧縮日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 MasterCompressDt
        {
            get { return _masterCompressDt; }
            set { _masterCompressDt = value; }
        }

		/// public propaty name  :  RatePriorityDiv
		/// <summary>掛率優先区分プロパティ</summary>
		/// <value>0:拠点優先 1:設定区分優先</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   掛率優先区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 RatePriorityDiv
		{
			get{return _ratePriorityDiv;}
			set{_ratePriorityDiv = value;}
		}

		/// <summary>
		/// 自社情報コンストラクタ
		/// </summary>
		/// <returns>CompanyInfクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   CompanyInfクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public CompanyInf()
		{
		}

		/// <summary>
		/// 自社情報コンストラクタ
		/// </summary>
		/// <param name="createDateTime">作成日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
		/// <param name="updateDateTime">更新日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
		/// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
		/// <param name="fileHeaderGuid">GUID(共通ファイルヘッダ)</param>
		/// <param name="updEmployeeCode">更新従業員コード(共通ファイルヘッダ)</param>
		/// <param name="updAssemblyId1">更新アセンブリID1(共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）)</param>
		/// <param name="updAssemblyId2">更新アセンブリID2(共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）)</param>
		/// <param name="logicalDeleteCode">論理削除区分(共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除))</param>
		/// <param name="companyCode">自社コード</param>
		/// <param name="companyTotalDay">自社締日(DD　期首年月日より算出される末日未満であること期首日の日を越える値)</param>
		/// <param name="financialYear">会計年度(YYYY)</param>
		/// <param name="companyBiginMonth">期首月(MM)</param>
		/// <param name="companyBiginMonth2">期首月2(MM)</param>
		/// <param name="companyBiginDate">期首年月日(YYYYMMDD)</param>
		/// <param name="startYearDiv">開始年区分(0:前年 1:翌年)</param>
		/// <param name="startMonthDiv">開始月区分(0:前月 1:翌月)</param>
		/// <param name="companyName1">自社名称1</param>
		/// <param name="companyName2">自社名称2</param>
		/// <param name="postNo">郵便番号</param>
		/// <param name="address1">住所1（都道府県市区郡・町村・字）</param>
		/// <param name="address2">住所2（丁目）</param>
		/// <param name="address3">住所3（番地）</param>
		/// <param name="address4">住所4（アパート名称）</param>
		/// <param name="companyTelNo1">自社電話番号1</param>
		/// <param name="companyTelNo2">自社電話番号2</param>
		/// <param name="companyTelNo3">自社電話番号3</param>
		/// <param name="companyTelTitle1">自社電話番号タイトル1</param>
		/// <param name="companyTelTitle2">自社電話番号タイトル2</param>
		/// <param name="companyTelTitle3">自社電話番号タイトル3</param>
		/// <param name="secMngDiv">部署管理区分(0:拠点　1:拠点＋部)</param>
        /// <param name="dataClrExecDate">データクリア処理実行年月日</param>
        /// <param name="dataClrExecTime">データクリア処理実行時分秒ミリ秒</param>
        /// <param name="dataSaveMonths">データ保存月数</param>
        /// <param name="dataCompressDt">データ圧縮日(YYYYMMDD)</param>
        /// <param name="resultDtSaveMonths">実績データ保存月数</param>
        /// <param name="resultDtCompressDt">実績データ圧縮日(YYYYMMDD)</param>
        /// <param name="caPrtsDtSaveMonths">車輌部品データ保存月数</param>
        /// <param name="caPrtsDtCompressDt">車輌部品データ圧縮日(YYYYMMDD)</param>
        /// <param name="masterSaveMonths">マスタ保存月数</param>
        /// <param name="masterCompressDt">マスタ圧縮日(YYYYMMDD)</param>
		/// <param name="ratePriorityDiv">掛率優先区分(0:拠点優先 1:設定区分優先)</param>
		/// <returns>CompanyInfクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   CompanyInfクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
        /* --- DEL 2011/07/14 --------------------------------------------------------------------->>>>>
		public CompanyInf(DateTime createDateTime,DateTime updateDateTime,string enterpriseCode,Guid fileHeaderGuid,string updEmployeeCode,string updAssemblyId1,string updAssemblyId2,Int32 logicalDeleteCode,Int32 companyCode,Int32 companyTotalDay,Int32 financialYear,Int32 companyBiginMonth,Int32 companyBiginMonth2,Int32 companyBiginDate,Int32 startYearDiv,Int32 startMonthDiv,string companyName1,string companyName2,string postNo,string address1,Int32 address2,string address3,string address4,string companyTelNo1,string companyTelNo2,string companyTelNo3,string companyTelTitle1,string companyTelTitle2,string companyTelTitle3,Int32 secMngDiv)
		--- DEL 2011/07/14 ---------------------------------------------------------------------<<<<<*/
        // --- ADD 2011/07/14 --------------------------------------------------------------------->>>>>
        //public CompanyInf(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 companyCode, Int32 companyTotalDay, Int32 financialYear, Int32 companyBiginMonth, Int32 companyBiginMonth2, Int32 companyBiginDate, Int32 startYearDiv, Int32 startMonthDiv, string companyName1, string companyName2, string postNo, string address1, Int32 address2, string address3, string address4, string companyTelNo1, string companyTelNo2, string companyTelNo3, string companyTelTitle1, string companyTelTitle2, string companyTelTitle3, Int32 secMngDiv, Int32 dataClrExecDate, Int32 dataClrExecTime)
        // --- ADD 2011/07/14 ---------------------------------------------------------------------<<<<<
        public CompanyInf(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 companyCode, Int32 companyTotalDay, Int32 financialYear, Int32 companyBiginMonth, Int32 companyBiginMonth2, Int32 companyBiginDate, Int32 startYearDiv, Int32 startMonthDiv, string companyName1, string companyName2, string postNo, string address1, Int32 address2, string address3, string address4, string companyTelNo1, string companyTelNo2, string companyTelNo3, string companyTelTitle1, string companyTelTitle2, string companyTelTitle3, Int32 secMngDiv, Int32 dataClrExecDate, Int32 dataClrExecTime, Int32 dataSaveMonths, Int32 dataCompressDt, Int32 resultDtSaveMonths, Int32 resultDtCompressDt, Int32 caPrtsDtSaveMonths, Int32 caPrtsDtCompressDt, Int32 masterSaveMonths, Int32 masterCompressDt, Int32 ratePriorityDiv)
		{
			this.CreateDateTime = createDateTime;
			this.UpdateDateTime = updateDateTime;
			this._enterpriseCode = enterpriseCode;
			this._fileHeaderGuid = fileHeaderGuid;
			this._updEmployeeCode = updEmployeeCode;
			this._updAssemblyId1 = updAssemblyId1;
			this._updAssemblyId2 = updAssemblyId2;
			this._logicalDeleteCode = logicalDeleteCode;
			this._companyCode = companyCode;
			this._companyTotalDay = companyTotalDay;
			this._financialYear = financialYear;
			this._companyBiginMonth = companyBiginMonth;
			this._companyBiginMonth2 = companyBiginMonth2;
			this._companyBiginDate = companyBiginDate;
			this._startYearDiv = startYearDiv;
			this._startMonthDiv = startMonthDiv;
			this._companyName1 = companyName1;
			this._companyName2 = companyName2;
			this._postNo = postNo;
			this._address1 = address1;
			this._address2 = address2;
			this._address3 = address3;
			this._address4 = address4;
			this._companyTelNo1 = companyTelNo1;
			this._companyTelNo2 = companyTelNo2;
			this._companyTelNo3 = companyTelNo3;
			this._companyTelTitle1 = companyTelTitle1;
			this._companyTelTitle2 = companyTelTitle2;
			this._companyTelTitle3 = companyTelTitle3;
			this._secMngDiv = secMngDiv;
            // --- ADD 2011/07/14 --------------------------------------------------------------------->>>>>
            this._dataClrExecDate = dataClrExecDate;
            this._dataClrExecTime = dataClrExecTime;
            // --- ADD 2011/07/14 ---------------------------------------------------------------------<<<<<
            this._dataSaveMonths = dataSaveMonths;
            this._dataCompressDt = dataCompressDt;
            this._resultDtSaveMonths = resultDtSaveMonths;
            this._resultDtCompressDt = resultDtCompressDt;
            this._caPrtsDtSaveMonths = caPrtsDtSaveMonths;
            this._caPrtsDtCompressDt = caPrtsDtCompressDt;
            this._masterSaveMonths = masterSaveMonths;
            this._masterCompressDt = masterCompressDt;
			this._ratePriorityDiv = ratePriorityDiv;

		}

		/// <summary>
		/// 自社情報複製処理
		/// </summary>
		/// <returns>CompanyInfクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   自身の内容と等しいCompanyInfクラスのインスタンスを返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public CompanyInf Clone()
		{
            /* --- DEL 2011/07/14 --------------------------------------------------------------------->>>>>
            return new CompanyInf(this._createDateTime,this._updateDateTime,this._enterpriseCode,this._fileHeaderGuid,this._updEmployeeCode,this._updAssemblyId1,this._updAssemblyId2,this._logicalDeleteCode,this._companyCode,this._companyTotalDay,this._financialYear,this._companyBiginMonth,this._companyBiginMonth2,this._companyBiginDate,this._startYearDiv,this._startMonthDiv,this._companyName1,this._companyName2,this._postNo,this._address1,this._address2,this._address3,this._address4,this._companyTelNo1,this._companyTelNo2,this._companyTelNo3,this._companyTelTitle1,this._companyTelTitle2,this._companyTelTitle3,this._secMngDiv);
            --- DEL 2011/07/14 ---------------------------------------------------------------------<<<<<*/
            // --- ADD 2011/07/14 --------------------------------------------------------------------->>>>>
            //return new CompanyInf(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._companyCode, this._companyTotalDay, this._financialYear, this._companyBiginMonth, this._companyBiginMonth2, this._companyBiginDate, this._startYearDiv, this._startMonthDiv, this._companyName1, this._companyName2, this._postNo, this._address1, this._address2, this._address3, this._address4, this._companyTelNo1, this._companyTelNo2, this._companyTelNo3, this._companyTelTitle1, this._companyTelTitle2, this._companyTelTitle3, this._secMngDiv, this._dataClrExecDate, this._dataClrExecTime);
            // --- ADD 2011/07/14 ---------------------------------------------------------------------<<<<<
            return new CompanyInf(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._companyCode, this._companyTotalDay, this._financialYear, this._companyBiginMonth, this._companyBiginMonth2, this._companyBiginDate, this._startYearDiv, this._startMonthDiv, this._companyName1, this._companyName2, this._postNo, this._address1, this._address2, this._address3, this._address4, this._companyTelNo1, this._companyTelNo2, this._companyTelNo3, this._companyTelTitle1, this._companyTelTitle2, this._companyTelTitle3, this._secMngDiv, this._dataClrExecDate, this._dataClrExecTime, this._dataSaveMonths, this._dataCompressDt, this._resultDtSaveMonths, this._resultDtCompressDt, this._caPrtsDtSaveMonths, this._caPrtsDtCompressDt, this._masterSaveMonths, this._masterCompressDt, this._ratePriorityDiv);
		}

		/// <summary>
		/// 自社情報比較処理
		/// </summary>
		/// <param name="target">比較対象のCompanyInfクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   CompanyInfクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public bool Equals(CompanyInf target)
		{
			return ((this.CreateDateTime == target.CreateDateTime)
				 && (this.UpdateDateTime == target.UpdateDateTime)
				 && (this.EnterpriseCode == target.EnterpriseCode)
				 && (this.FileHeaderGuid == target.FileHeaderGuid)
				 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
				 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
				 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
				 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
				 && (this.CompanyCode == target.CompanyCode)
				 && (this.CompanyTotalDay == target.CompanyTotalDay)
				 && (this.FinancialYear == target.FinancialYear)
				 && (this.CompanyBiginMonth == target.CompanyBiginMonth)
				 && (this.CompanyBiginMonth2 == target.CompanyBiginMonth2)
				 && (this.CompanyBiginDate == target.CompanyBiginDate)
				 && (this.StartYearDiv == target.StartYearDiv)
				 && (this.StartMonthDiv == target.StartMonthDiv)
				 && (this.CompanyName1 == target.CompanyName1)
				 && (this.CompanyName2 == target.CompanyName2)
				 && (this.PostNo == target.PostNo)
				 && (this.Address1 == target.Address1)
				 && (this.Address2 == target.Address2)
				 && (this.Address3 == target.Address3)
				 && (this.Address4 == target.Address4)
				 && (this.CompanyTelNo1 == target.CompanyTelNo1)
				 && (this.CompanyTelNo2 == target.CompanyTelNo2)
				 && (this.CompanyTelNo3 == target.CompanyTelNo3)
				 && (this.CompanyTelTitle1 == target.CompanyTelTitle1)
				 && (this.CompanyTelTitle2 == target.CompanyTelTitle2)
				 && (this.CompanyTelTitle3 == target.CompanyTelTitle3)
                 /* --- DEL 2011/07/14 --------------------------------------------------------------------->>>>>
				 && (this.SecMngDiv == target.SecMngDiv));
                 --- DEL 2011/07/14 ---------------------------------------------------------------------<<<<<*/
                // --- ADD 2011/07/14 --------------------------------------------------------------------->>>>>
                && (this.SecMngDiv == target.SecMngDiv)
                && (this.DataClrExecDate == target.DataClrExecDate)
                && (this.DataClrExecTime == target.DataClrExecTime)
                // --- ADD 2011/07/14 ---------------------------------------------------------------------<<<<<
                 && (this.DataSaveMonths == target.DataSaveMonths)
                 && (this.DataCompressDt == target.DataCompressDt)
                 && (this.ResultDtSaveMonths == target.ResultDtSaveMonths)
                 && (this.ResultDtCompressDt == target.ResultDtCompressDt)
                 && (this.CaPrtsDtSaveMonths == target.CaPrtsDtSaveMonths)
                 && (this.CaPrtsDtCompressDt == target.CaPrtsDtCompressDt)
                 && (this.MasterSaveMonths == target.MasterSaveMonths)
                 && (this.MasterCompressDt == target.MasterCompressDt)
                 && (this.RatePriorityDiv == target.RatePriorityDiv));
		}

		/// <summary>
		/// 自社情報比較処理
		/// </summary>
		/// <param name="companyInf1">
		///                    比較するCompanyInfクラスのインスタンス
		/// </param>
		/// <param name="companyInf2">比較するCompanyInfクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   CompanyInfクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static bool Equals(CompanyInf companyInf1, CompanyInf companyInf2)
		{
			return ((companyInf1.CreateDateTime == companyInf2.CreateDateTime)
				 && (companyInf1.UpdateDateTime == companyInf2.UpdateDateTime)
				 && (companyInf1.EnterpriseCode == companyInf2.EnterpriseCode)
				 && (companyInf1.FileHeaderGuid == companyInf2.FileHeaderGuid)
				 && (companyInf1.UpdEmployeeCode == companyInf2.UpdEmployeeCode)
				 && (companyInf1.UpdAssemblyId1 == companyInf2.UpdAssemblyId1)
				 && (companyInf1.UpdAssemblyId2 == companyInf2.UpdAssemblyId2)
				 && (companyInf1.LogicalDeleteCode == companyInf2.LogicalDeleteCode)
				 && (companyInf1.CompanyCode == companyInf2.CompanyCode)
				 && (companyInf1.CompanyTotalDay == companyInf2.CompanyTotalDay)
				 && (companyInf1.FinancialYear == companyInf2.FinancialYear)
				 && (companyInf1.CompanyBiginMonth == companyInf2.CompanyBiginMonth)
				 && (companyInf1.CompanyBiginMonth2 == companyInf2.CompanyBiginMonth2)
				 && (companyInf1.CompanyBiginDate == companyInf2.CompanyBiginDate)
				 && (companyInf1.StartYearDiv == companyInf2.StartYearDiv)
				 && (companyInf1.StartMonthDiv == companyInf2.StartMonthDiv)
				 && (companyInf1.CompanyName1 == companyInf2.CompanyName1)
				 && (companyInf1.CompanyName2 == companyInf2.CompanyName2)
				 && (companyInf1.PostNo == companyInf2.PostNo)
				 && (companyInf1.Address1 == companyInf2.Address1)
				 && (companyInf1.Address2 == companyInf2.Address2)
				 && (companyInf1.Address3 == companyInf2.Address3)
				 && (companyInf1.Address4 == companyInf2.Address4)
				 && (companyInf1.CompanyTelNo1 == companyInf2.CompanyTelNo1)
				 && (companyInf1.CompanyTelNo2 == companyInf2.CompanyTelNo2)
				 && (companyInf1.CompanyTelNo3 == companyInf2.CompanyTelNo3)
				 && (companyInf1.CompanyTelTitle1 == companyInf2.CompanyTelTitle1)
				 && (companyInf1.CompanyTelTitle2 == companyInf2.CompanyTelTitle2)
				 && (companyInf1.CompanyTelTitle3 == companyInf2.CompanyTelTitle3)
                 /* --- DEL 2011/07/14 --------------------------------------------------------------------->>>>>
				 && (companyInf1.SecMngDiv == companyInf2.SecMngDiv));
                 --- DEL 2011/07/14 ---------------------------------------------------------------------<<<<<*/
                // --- ADD 2011/07/14 --------------------------------------------------------------------->>>>>
                && (companyInf1.SecMngDiv == companyInf2.SecMngDiv)
                && (companyInf1.DataClrExecDate == companyInf2.DataClrExecDate)
                && (companyInf1.DataClrExecTime == companyInf2.DataClrExecTime)
                // --- ADD 2011/07/14 ---------------------------------------------------------------------<<<<<
                 && (companyInf1.DataSaveMonths == companyInf2.DataSaveMonths)
                 && (companyInf1.DataCompressDt == companyInf2.DataCompressDt)
                 && (companyInf1.ResultDtSaveMonths == companyInf2.ResultDtSaveMonths)
                 && (companyInf1.ResultDtCompressDt == companyInf2.ResultDtCompressDt)
                 && (companyInf1.CaPrtsDtSaveMonths == companyInf2.CaPrtsDtSaveMonths)
                 && (companyInf1.CaPrtsDtCompressDt == companyInf2.CaPrtsDtCompressDt)
                 && (companyInf1.MasterSaveMonths == companyInf2.MasterSaveMonths)
                 && (companyInf1.MasterCompressDt == companyInf2.MasterCompressDt)
                 && (companyInf1.RatePriorityDiv == companyInf2.RatePriorityDiv));
		}
		/// <summary>
		/// 自社情報比較処理
		/// </summary>
		/// <param name="target">比較対象のCompanyInfクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   CompanyInfクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ArrayList Compare(CompanyInf target)
		{
			ArrayList resList = new ArrayList();
			if(this.CreateDateTime != target.CreateDateTime)resList.Add("CreateDateTime");
			if(this.UpdateDateTime != target.UpdateDateTime)resList.Add("UpdateDateTime");
			if(this.EnterpriseCode != target.EnterpriseCode)resList.Add("EnterpriseCode");
			if(this.FileHeaderGuid != target.FileHeaderGuid)resList.Add("FileHeaderGuid");
			if(this.UpdEmployeeCode != target.UpdEmployeeCode)resList.Add("UpdEmployeeCode");
			if(this.UpdAssemblyId1 != target.UpdAssemblyId1)resList.Add("UpdAssemblyId1");
			if(this.UpdAssemblyId2 != target.UpdAssemblyId2)resList.Add("UpdAssemblyId2");
			if(this.LogicalDeleteCode != target.LogicalDeleteCode)resList.Add("LogicalDeleteCode");
			if(this.CompanyCode != target.CompanyCode)resList.Add("CompanyCode");
			if(this.CompanyTotalDay != target.CompanyTotalDay)resList.Add("CompanyTotalDay");
			if(this.FinancialYear != target.FinancialYear)resList.Add("FinancialYear");
			if(this.CompanyBiginMonth != target.CompanyBiginMonth)resList.Add("CompanyBiginMonth");
			if(this.CompanyBiginMonth2 != target.CompanyBiginMonth2)resList.Add("CompanyBiginMonth2");
			if(this.CompanyBiginDate != target.CompanyBiginDate)resList.Add("CompanyBiginDate");
			if(this.StartYearDiv != target.StartYearDiv)resList.Add("StartYearDiv");
			if(this.StartMonthDiv != target.StartMonthDiv)resList.Add("StartMonthDiv");
			if(this.CompanyName1 != target.CompanyName1)resList.Add("CompanyName1");
			if(this.CompanyName2 != target.CompanyName2)resList.Add("CompanyName2");
			if(this.PostNo != target.PostNo)resList.Add("PostNo");
			if(this.Address1 != target.Address1)resList.Add("Address1");
			if(this.Address2 != target.Address2)resList.Add("Address2");
			if(this.Address3 != target.Address3)resList.Add("Address3");
			if(this.Address4 != target.Address4)resList.Add("Address4");
			if(this.CompanyTelNo1 != target.CompanyTelNo1)resList.Add("CompanyTelNo1");
			if(this.CompanyTelNo2 != target.CompanyTelNo2)resList.Add("CompanyTelNo2");
			if(this.CompanyTelNo3 != target.CompanyTelNo3)resList.Add("CompanyTelNo3");
			if(this.CompanyTelTitle1 != target.CompanyTelTitle1)resList.Add("CompanyTelTitle1");
			if(this.CompanyTelTitle2 != target.CompanyTelTitle2)resList.Add("CompanyTelTitle2");
			if(this.CompanyTelTitle3 != target.CompanyTelTitle3)resList.Add("CompanyTelTitle3");
			if(this.SecMngDiv != target.SecMngDiv)resList.Add("SecMngDiv");
            // --- ADD 2011/07/14 --------------------------------------------------------------------->>>>>
            if (this.DataClrExecDate != target.DataClrExecDate) resList.Add("DataClrExecDate");
            if (this.DataClrExecTime != target.DataClrExecTime) resList.Add("DataClrExecTime");
            // --- ADD 2011/07/14 ---------------------------------------------------------------------<<<<<
            if (this.DataSaveMonths != target.DataSaveMonths) resList.Add("DataSaveMonths");
            if (this.DataCompressDt != target.DataCompressDt) resList.Add("DataCompressDt");
            if (this.ResultDtSaveMonths != target.ResultDtSaveMonths) resList.Add("ResultDtSaveMonths");
            if (this.ResultDtCompressDt != target.ResultDtCompressDt) resList.Add("ResultDtCompressDt");
            if (this.CaPrtsDtSaveMonths != target.CaPrtsDtSaveMonths) resList.Add("CaPrtsDtSaveMonths");
            if (this.CaPrtsDtCompressDt != target.CaPrtsDtCompressDt) resList.Add("CaPrtsDtCompressDt");
            if (this.MasterSaveMonths != target.MasterSaveMonths) resList.Add("MasterSaveMonths");
            if (this.MasterCompressDt != target.MasterCompressDt) resList.Add("MasterCompressDt");
            if (this.RatePriorityDiv != target.RatePriorityDiv) resList.Add("RatePriorityDiv");

			return resList;
		}

		/// <summary>
		/// 自社情報比較処理
		/// </summary>
		/// <param name="companyInf1">比較するCompanyInfクラスのインスタンス</param>
		/// <param name="companyInf2">比較するCompanyInfクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   CompanyInfクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static ArrayList Compare(CompanyInf companyInf1, CompanyInf companyInf2)
		{
			ArrayList resList = new ArrayList();
			if(companyInf1.CreateDateTime != companyInf2.CreateDateTime)resList.Add("CreateDateTime");
			if(companyInf1.UpdateDateTime != companyInf2.UpdateDateTime)resList.Add("UpdateDateTime");
			if(companyInf1.EnterpriseCode != companyInf2.EnterpriseCode)resList.Add("EnterpriseCode");
			if(companyInf1.FileHeaderGuid != companyInf2.FileHeaderGuid)resList.Add("FileHeaderGuid");
			if(companyInf1.UpdEmployeeCode != companyInf2.UpdEmployeeCode)resList.Add("UpdEmployeeCode");
			if(companyInf1.UpdAssemblyId1 != companyInf2.UpdAssemblyId1)resList.Add("UpdAssemblyId1");
			if(companyInf1.UpdAssemblyId2 != companyInf2.UpdAssemblyId2)resList.Add("UpdAssemblyId2");
			if(companyInf1.LogicalDeleteCode != companyInf2.LogicalDeleteCode)resList.Add("LogicalDeleteCode");
			if(companyInf1.CompanyCode != companyInf2.CompanyCode)resList.Add("CompanyCode");
			if(companyInf1.CompanyTotalDay != companyInf2.CompanyTotalDay)resList.Add("CompanyTotalDay");
			if(companyInf1.FinancialYear != companyInf2.FinancialYear)resList.Add("FinancialYear");
			if(companyInf1.CompanyBiginMonth != companyInf2.CompanyBiginMonth)resList.Add("CompanyBiginMonth");
			if(companyInf1.CompanyBiginMonth2 != companyInf2.CompanyBiginMonth2)resList.Add("CompanyBiginMonth2");
			if(companyInf1.CompanyBiginDate != companyInf2.CompanyBiginDate)resList.Add("CompanyBiginDate");
			if(companyInf1.StartYearDiv != companyInf2.StartYearDiv)resList.Add("StartYearDiv");
			if(companyInf1.StartMonthDiv != companyInf2.StartMonthDiv)resList.Add("StartMonthDiv");
			if(companyInf1.CompanyName1 != companyInf2.CompanyName1)resList.Add("CompanyName1");
			if(companyInf1.CompanyName2 != companyInf2.CompanyName2)resList.Add("CompanyName2");
			if(companyInf1.PostNo != companyInf2.PostNo)resList.Add("PostNo");
			if(companyInf1.Address1 != companyInf2.Address1)resList.Add("Address1");
			if(companyInf1.Address2 != companyInf2.Address2)resList.Add("Address2");
			if(companyInf1.Address3 != companyInf2.Address3)resList.Add("Address3");
			if(companyInf1.Address4 != companyInf2.Address4)resList.Add("Address4");
			if(companyInf1.CompanyTelNo1 != companyInf2.CompanyTelNo1)resList.Add("CompanyTelNo1");
			if(companyInf1.CompanyTelNo2 != companyInf2.CompanyTelNo2)resList.Add("CompanyTelNo2");
			if(companyInf1.CompanyTelNo3 != companyInf2.CompanyTelNo3)resList.Add("CompanyTelNo3");
			if(companyInf1.CompanyTelTitle1 != companyInf2.CompanyTelTitle1)resList.Add("CompanyTelTitle1");
			if(companyInf1.CompanyTelTitle2 != companyInf2.CompanyTelTitle2)resList.Add("CompanyTelTitle2");
			if(companyInf1.CompanyTelTitle3 != companyInf2.CompanyTelTitle3)resList.Add("CompanyTelTitle3");
			if(companyInf1.SecMngDiv != companyInf2.SecMngDiv)resList.Add("SecMngDiv");
            // --- ADD 2011/07/14 --------------------------------------------------------------------->>>>>
            if (companyInf1.DataClrExecDate != companyInf2.DataClrExecDate) resList.Add("DataClrExecDate");
            if (companyInf1.DataClrExecTime != companyInf2.DataClrExecTime) resList.Add("DataClrExecTime");
            // --- ADD 2011/07/14 ---------------------------------------------------------------------<<<<<
            if (companyInf1.DataSaveMonths != companyInf2.DataSaveMonths) resList.Add("DataSaveMonths");
            if (companyInf1.DataCompressDt != companyInf2.DataCompressDt) resList.Add("DataCompressDt");
            if (companyInf1.ResultDtSaveMonths != companyInf2.ResultDtSaveMonths) resList.Add("ResultDtSaveMonths");
            if (companyInf1.ResultDtCompressDt != companyInf2.ResultDtCompressDt) resList.Add("ResultDtCompressDt");
            if (companyInf1.CaPrtsDtSaveMonths != companyInf2.CaPrtsDtSaveMonths) resList.Add("CaPrtsDtSaveMonths");
            if (companyInf1.CaPrtsDtCompressDt != companyInf2.CaPrtsDtCompressDt) resList.Add("CaPrtsDtCompressDt");
            if (companyInf1.MasterSaveMonths != companyInf2.MasterSaveMonths) resList.Add("MasterSaveMonths");
            if (companyInf1.MasterCompressDt != companyInf2.MasterCompressDt) resList.Add("MasterCompressDt");
            if (companyInf1.RatePriorityDiv != companyInf2.RatePriorityDiv) resList.Add("RatePriorityDiv");

			return resList;
		}
	}
}
