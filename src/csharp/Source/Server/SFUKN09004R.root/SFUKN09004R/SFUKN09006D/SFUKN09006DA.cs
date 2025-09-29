using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   CompanyInfWork
    /// <summary>
    ///                      自社情報ワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   自社情報ワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2008/3/10</br>
    /// <br>Genarated Date   :   2008/05/20  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2008/4/1  杉村</br>
    /// <br>                 :   部署管理区分の内容を変更</br>
    /// <br>                 :   0:拠点　1:拠点＋部　2:拠点＋部＋課</br>
    /// <br>                 :   ↓</br>
    /// <br>                 :   0:拠点　1:拠点＋部</br>
    /// <br>Update Note      :   2011/07/14  LDNS wangqx</br>
    /// <br>                 :   データクリア処理実行年月日、データクリア処理実行時分秒ミリ秒を追加</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class CompanyInfWork : IFileHeader
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
        /// <remarks>０固定</remarks>
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

        /// <summary>住所3（番地）</summary>
        private string _address3 = "";

        /// <summary>住所4（アパート名称）</summary>
        private string _address4 = "";

        /// <summary>自社電話番号1</summary>
        /// <remarks>TEL</remarks>
        private string _companyTelNo1 = "";

        /// <summary>自社電話番号2</summary>
        /// <remarks>TEL2</remarks>
        private string _companyTelNo2 = "";

        /// <summary>自社電話番号3</summary>
        /// <remarks>FAX</remarks>
        private string _companyTelNo3 = "";

        /// <summary>自社電話番号タイトル1</summary>
        /// <remarks>TEL</remarks>
        private string _companyTelTitle1 = "";

        /// <summary>自社電話番号タイトル2</summary>
        /// <remarks>TEL2</remarks>
        private string _companyTelTitle2 = "";

        /// <summary>自社電話番号タイトル3</summary>
        /// <remarks>FAX</remarks>
        private string _companyTelTitle3 = "";

        /// <summary>部署管理区分</summary>
        /// <remarks>0:拠点　1:拠点＋部</remarks>
        private Int32 _secMngDiv;

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

        // --- ADD 2011/07/14 --------------------------------------------------------------------->>>>>
        /// <summary>データクリア処理実行年月日</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _dataClrExecDate;

        /// <summary>データクリア処理実行時分秒ミリ秒</summary>
        /// <remarks>HHMMSSXXX</remarks>
        private Int32 _dataClrExecTime;
        // --- ADD 2011/07/14 ---------------------------------------------------------------------<<<<<

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
            get { return _createDateTime; }
            set { _createDateTime = value; }
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
            get { return _updateDateTime; }
            set { _updateDateTime = value; }
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
            get { return _enterpriseCode; }
            set { _enterpriseCode = value; }
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
            get { return _fileHeaderGuid; }
            set { _fileHeaderGuid = value; }
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
            get { return _updEmployeeCode; }
            set { _updEmployeeCode = value; }
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
            get { return _updAssemblyId1; }
            set { _updAssemblyId1 = value; }
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
            get { return _updAssemblyId2; }
            set { _updAssemblyId2 = value; }
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
            get { return _logicalDeleteCode; }
            set { _logicalDeleteCode = value; }
        }

        /// public propaty name  :  CompanyCode
        /// <summary>自社コードプロパティ</summary>
        /// <value>０固定</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CompanyCode
        {
            get { return _companyCode; }
            set { _companyCode = value; }
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
            get { return _companyTotalDay; }
            set { _companyTotalDay = value; }
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
            get { return _financialYear; }
            set { _financialYear = value; }
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
            get { return _companyBiginMonth; }
            set { _companyBiginMonth = value; }
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
            get { return _companyBiginMonth2; }
            set { _companyBiginMonth2 = value; }
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
            get { return _companyBiginDate; }
            set { _companyBiginDate = value; }
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
            get { return _startYearDiv; }
            set { _startYearDiv = value; }
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
            get { return _startMonthDiv; }
            set { _startMonthDiv = value; }
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
            get { return _companyName1; }
            set { _companyName1 = value; }
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
            get { return _companyName2; }
            set { _companyName2 = value; }
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
            get { return _postNo; }
            set { _postNo = value; }
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
            get { return _address1; }
            set { _address1 = value; }
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
            get { return _address3; }
            set { _address3 = value; }
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
            get { return _address4; }
            set { _address4 = value; }
        }

        /// public propaty name  :  CompanyTelNo1
        /// <summary>自社電話番号1プロパティ</summary>
        /// <value>TEL</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社電話番号1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CompanyTelNo1
        {
            get { return _companyTelNo1; }
            set { _companyTelNo1 = value; }
        }

        /// public propaty name  :  CompanyTelNo2
        /// <summary>自社電話番号2プロパティ</summary>
        /// <value>TEL2</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社電話番号2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CompanyTelNo2
        {
            get { return _companyTelNo2; }
            set { _companyTelNo2 = value; }
        }

        /// public propaty name  :  CompanyTelNo3
        /// <summary>自社電話番号3プロパティ</summary>
        /// <value>FAX</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社電話番号3プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CompanyTelNo3
        {
            get { return _companyTelNo3; }
            set { _companyTelNo3 = value; }
        }

        /// public propaty name  :  CompanyTelTitle1
        /// <summary>自社電話番号タイトル1プロパティ</summary>
        /// <value>TEL</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社電話番号タイトル1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CompanyTelTitle1
        {
            get { return _companyTelTitle1; }
            set { _companyTelTitle1 = value; }
        }

        /// public propaty name  :  CompanyTelTitle2
        /// <summary>自社電話番号タイトル2プロパティ</summary>
        /// <value>TEL2</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社電話番号タイトル2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CompanyTelTitle2
        {
            get { return _companyTelTitle2; }
            set { _companyTelTitle2 = value; }
        }

        /// public propaty name  :  CompanyTelTitle3
        /// <summary>自社電話番号タイトル3プロパティ</summary>
        /// <value>FAX</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社電話番号タイトル3プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CompanyTelTitle3
        {
            get { return _companyTelTitle3; }
            set { _companyTelTitle3 = value; }
        }

        /// public propaty name  :  SecMngDiv
        /// <summary>部署管理区分プロパティ</summary>
        /// <value>0:拠点　1:拠点＋部</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   部署管理区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SecMngDiv
        {
            get { return _secMngDiv; }
            set { _secMngDiv = value; }
        }
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
 
        /// <summary>
        /// 自社情報ワークコンストラクタ
        /// </summary>
        /// <returns>CompanyInfWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CompanyInfWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public CompanyInfWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>CompanyInfWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   CompanyInfWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class CompanyInfWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   CompanyInfWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  CompanyInfWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is CompanyInfWork || graph is ArrayList || graph is CompanyInfWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(CompanyInfWork).FullName));

            if (graph != null && graph is CompanyInfWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.CompanyInfWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is CompanyInfWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((CompanyInfWork[])graph).Length;
            }
            else if (graph is CompanyInfWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //作成日時
            serInfo.MemberInfo.Add(typeof(Int64)); //CreateDateTime
            //更新日時
            serInfo.MemberInfo.Add(typeof(Int64)); //UpdateDateTime
            //企業コード
            serInfo.MemberInfo.Add(typeof(string)); //EnterpriseCode
            //GUID
            serInfo.MemberInfo.Add(typeof(byte[]));  //FileHeaderGuid
            //更新従業員コード
            serInfo.MemberInfo.Add(typeof(string)); //UpdEmployeeCode
            //更新アセンブリID1
            serInfo.MemberInfo.Add(typeof(string)); //UpdAssemblyId1
            //更新アセンブリID2
            serInfo.MemberInfo.Add(typeof(string)); //UpdAssemblyId2
            //論理削除区分
            serInfo.MemberInfo.Add(typeof(Int32)); //LogicalDeleteCode
            //自社コード
            serInfo.MemberInfo.Add(typeof(Int32)); //CompanyCode
            //自社締日
            serInfo.MemberInfo.Add(typeof(Int32)); //CompanyTotalDay
            //会計年度
            serInfo.MemberInfo.Add(typeof(Int32)); //FinancialYear
            //期首月
            serInfo.MemberInfo.Add(typeof(Int32)); //CompanyBiginMonth
            //期首月2
            serInfo.MemberInfo.Add(typeof(Int32)); //CompanyBiginMonth2
            //期首年月日
            serInfo.MemberInfo.Add(typeof(Int32)); //CompanyBiginDate
            //開始年区分
            serInfo.MemberInfo.Add(typeof(Int32)); //StartYearDiv
            //開始月区分
            serInfo.MemberInfo.Add(typeof(Int32)); //StartMonthDiv
            //自社名称1
            serInfo.MemberInfo.Add(typeof(string)); //CompanyName1
            //自社名称2
            serInfo.MemberInfo.Add(typeof(string)); //CompanyName2
            //郵便番号
            serInfo.MemberInfo.Add(typeof(string)); //PostNo
            //住所1（都道府県市区郡・町村・字）
            serInfo.MemberInfo.Add(typeof(string)); //Address1
            //住所3（番地）
            serInfo.MemberInfo.Add(typeof(string)); //Address3
            //住所4（アパート名称）
            serInfo.MemberInfo.Add(typeof(string)); //Address4
            //自社電話番号1
            serInfo.MemberInfo.Add(typeof(string)); //CompanyTelNo1
            //自社電話番号2
            serInfo.MemberInfo.Add(typeof(string)); //CompanyTelNo2
            //自社電話番号3
            serInfo.MemberInfo.Add(typeof(string)); //CompanyTelNo3
            //自社電話番号タイトル1
            serInfo.MemberInfo.Add(typeof(string)); //CompanyTelTitle1
            //自社電話番号タイトル2
            serInfo.MemberInfo.Add(typeof(string)); //CompanyTelTitle2
            //自社電話番号タイトル3
            serInfo.MemberInfo.Add(typeof(string)); //CompanyTelTitle3
            //部署管理区分
            serInfo.MemberInfo.Add(typeof(Int32)); //SecMngDiv
            //データ保存月数
            serInfo.MemberInfo.Add(typeof(Int32)); //DataSaveMonths
            //データ圧縮日
            serInfo.MemberInfo.Add(typeof(Int32)); //DataCompressDt
            //実績データ保存月数
            serInfo.MemberInfo.Add(typeof(Int32)); //ResultDtSaveMonths
            //実績データ圧縮日
            serInfo.MemberInfo.Add(typeof(Int32)); //ResultDtCompressDt
            //車輌部品データ保存月数
            serInfo.MemberInfo.Add(typeof(Int32)); //CaPrtsDtSaveMonths
            //車輌部品データ圧縮日
            serInfo.MemberInfo.Add(typeof(Int32)); //CaPrtsDtCompressDt
            //マスタ保存月数
            serInfo.MemberInfo.Add(typeof(Int32)); //MasterSaveMonths
            //マスタ圧縮日
            serInfo.MemberInfo.Add(typeof(Int32)); //MasterCompressDt
		//掛率優先区分
		serInfo.MemberInfo.Add( typeof(Int32) ); //RatePriorityDiv
            // --- ADD 2011/07/14 --------------------------------------------------------------------->>>>>
            //データクリア処理実行年月日
            serInfo.MemberInfo.Add(typeof(Int32)); //DataClrExecDate
            //部署管理区分
            serInfo.MemberInfo.Add(typeof(Int32)); //DataClrExecTime
            // --- ADD 2011/07/14 ---------------------------------------------------------------------<<<<<

            serInfo.Serialize(writer, serInfo);
            if (graph is CompanyInfWork)
            {
                CompanyInfWork temp = (CompanyInfWork)graph;

                SetCompanyInfWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is CompanyInfWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((CompanyInfWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (CompanyInfWork temp in lst)
                {
                    SetCompanyInfWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// CompanyInfWorkメンバ数(publicプロパティ数)
        /// </summary>
        /// 
        /* --- DEL 2011/07/14 --------------------------------------------------------------------->>>>>
        private const int currentMemberCount = 30;
        --- DEL 2011/07/14 ---------------------------------------------------------------------<<<<<*/
        // --- ADD 2011/07/14 --------------------------------------------------------------------->>>>>
        private const int currentMemberCount = 41;
        // --- ADD 2011/07/14 ---------------------------------------------------------------------<<<<<

        /// <summary>
        ///  CompanyInfWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   CompanyInfWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetCompanyInfWork(System.IO.BinaryWriter writer, CompanyInfWork temp)
        {
            //作成日時
            writer.Write((Int64)temp.CreateDateTime.Ticks);
            //更新日時
            writer.Write((Int64)temp.UpdateDateTime.Ticks);
            //企業コード
            writer.Write(temp.EnterpriseCode);
            //GUID
            byte[] fileHeaderGuidArray = temp.FileHeaderGuid.ToByteArray();
            writer.Write(fileHeaderGuidArray.Length);
            writer.Write(temp.FileHeaderGuid.ToByteArray());
            //更新従業員コード
            writer.Write(temp.UpdEmployeeCode);
            //更新アセンブリID1
            writer.Write(temp.UpdAssemblyId1);
            //更新アセンブリID2
            writer.Write(temp.UpdAssemblyId2);
            //論理削除区分
            writer.Write(temp.LogicalDeleteCode);
            //自社コード
            writer.Write(temp.CompanyCode);
            //自社締日
            writer.Write(temp.CompanyTotalDay);
            //会計年度
            writer.Write(temp.FinancialYear);
            //期首月
            writer.Write(temp.CompanyBiginMonth);
            //期首月2
            writer.Write(temp.CompanyBiginMonth2);
            //期首年月日
            writer.Write(temp.CompanyBiginDate);
            //開始年区分
            writer.Write(temp.StartYearDiv);
            //開始月区分
            writer.Write(temp.StartMonthDiv);
            //自社名称1
            writer.Write(temp.CompanyName1);
            //自社名称2
            writer.Write(temp.CompanyName2);
            //郵便番号
            writer.Write(temp.PostNo);
            //住所1（都道府県市区郡・町村・字）
            writer.Write(temp.Address1);
            //住所3（番地）
            writer.Write(temp.Address3);
            //住所4（アパート名称）
            writer.Write(temp.Address4);
            //自社電話番号1
            writer.Write(temp.CompanyTelNo1);
            //自社電話番号2
            writer.Write(temp.CompanyTelNo2);
            //自社電話番号3
            writer.Write(temp.CompanyTelNo3);
            //自社電話番号タイトル1
            writer.Write(temp.CompanyTelTitle1);
            //自社電話番号タイトル2
            writer.Write(temp.CompanyTelTitle2);
            //自社電話番号タイトル3
            writer.Write(temp.CompanyTelTitle3);
            //部署管理区分
            writer.Write(temp.SecMngDiv);
            //データ保存月数
            writer.Write(temp.DataSaveMonths);
            //データ圧縮日
            writer.Write(temp.DataCompressDt);
            //実績データ保存月数
            writer.Write(temp.ResultDtSaveMonths);
            //実績データ圧縮日
            writer.Write(temp.ResultDtCompressDt);
            //車輌部品データ保存月数
            writer.Write(temp.CaPrtsDtSaveMonths);
            //車輌部品データ圧縮日
            writer.Write(temp.CaPrtsDtCompressDt);
            //マスタ保存月数
            writer.Write(temp.MasterSaveMonths);
            //マスタ圧縮日
            writer.Write(temp.MasterCompressDt);
		//掛率優先区分
		writer.Write( temp.RatePriorityDiv );
            // --- ADD 2011/07/14 --------------------------------------------------------------------->>>>>
            //データクリア処理実行年月日
            writer.Write(temp.DataClrExecDate);
            //データクリア処理実行時分秒ミリ秒
            writer.Write(temp.DataClrExecTime);
            // --- ADD 2011/07/14 ---------------------------------------------------------------------<<<<<
        }

        /// <summary>
        ///  CompanyInfWorkインスタンス取得
        /// </summary>
        /// <returns>CompanyInfWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CompanyInfWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private CompanyInfWork GetCompanyInfWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            CompanyInfWork temp = new CompanyInfWork();

            //作成日時
            temp.CreateDateTime = new DateTime(reader.ReadInt64());
            //更新日時
            temp.UpdateDateTime = new DateTime(reader.ReadInt64());
            //企業コード
            temp.EnterpriseCode = reader.ReadString();
            //GUID
            int lenOfFileHeaderGuidArray = reader.ReadInt32();
            byte[] fileHeaderGuidArray = reader.ReadBytes(lenOfFileHeaderGuidArray);
            temp.FileHeaderGuid = new Guid(fileHeaderGuidArray);
            //更新従業員コード
            temp.UpdEmployeeCode = reader.ReadString();
            //更新アセンブリID1
            temp.UpdAssemblyId1 = reader.ReadString();
            //更新アセンブリID2
            temp.UpdAssemblyId2 = reader.ReadString();
            //論理削除区分
            temp.LogicalDeleteCode = reader.ReadInt32();
            //自社コード
            temp.CompanyCode = reader.ReadInt32();
            //自社締日
            temp.CompanyTotalDay = reader.ReadInt32();
            //会計年度
            temp.FinancialYear = reader.ReadInt32();
            //期首月
            temp.CompanyBiginMonth = reader.ReadInt32();
            //期首月2
            temp.CompanyBiginMonth2 = reader.ReadInt32();
            //期首年月日
            temp.CompanyBiginDate = reader.ReadInt32();
            //開始年区分
            temp.StartYearDiv = reader.ReadInt32();
            //開始月区分
            temp.StartMonthDiv = reader.ReadInt32();
            //自社名称1
            temp.CompanyName1 = reader.ReadString();
            //自社名称2
            temp.CompanyName2 = reader.ReadString();
            //郵便番号
            temp.PostNo = reader.ReadString();
            //住所1（都道府県市区郡・町村・字）
            temp.Address1 = reader.ReadString();
            //住所3（番地）
            temp.Address3 = reader.ReadString();
            //住所4（アパート名称）
            temp.Address4 = reader.ReadString();
            //自社電話番号1
            temp.CompanyTelNo1 = reader.ReadString();
            //自社電話番号2
            temp.CompanyTelNo2 = reader.ReadString();
            //自社電話番号3
            temp.CompanyTelNo3 = reader.ReadString();
            //自社電話番号タイトル1
            temp.CompanyTelTitle1 = reader.ReadString();
            //自社電話番号タイトル2
            temp.CompanyTelTitle2 = reader.ReadString();
            //自社電話番号タイトル3
            temp.CompanyTelTitle3 = reader.ReadString();
            //部署管理区分
            temp.SecMngDiv = reader.ReadInt32();
            //データ保存月数
            temp.DataSaveMonths = reader.ReadInt32();
            //データ圧縮日
            temp.DataCompressDt = reader.ReadInt32();
            //実績データ保存月数
            temp.ResultDtSaveMonths = reader.ReadInt32();
            //実績データ圧縮日
            temp.ResultDtCompressDt = reader.ReadInt32();
            //車輌部品データ保存月数
            temp.CaPrtsDtSaveMonths = reader.ReadInt32();
            //車輌部品データ圧縮日
            temp.CaPrtsDtCompressDt = reader.ReadInt32();
            //マスタ保存月数
            temp.MasterSaveMonths = reader.ReadInt32();
            //マスタ圧縮日
            temp.MasterCompressDt = reader.ReadInt32();
		//掛率優先区分
		temp.RatePriorityDiv = reader.ReadInt32();
            // --- ADD 2011/07/14 --------------------------------------------------------------------->>>>>
            //データクリア処理実行年月日
            temp.DataClrExecDate = reader.ReadInt32();
            //データクリア処理実行時分秒ミリ秒
            temp.DataClrExecTime = reader.ReadInt32();
            // --- ADD 2011/07/14 ---------------------------------------------------------------------<<<<<

            //以下は読み飛ばしです。このバージョンが想定する EmployeeWork型以降のバージョンの
            //データをデシリアライズする場合、シリアライズしたフォーマッタが記述した
            //型情報にしたがって、ストリームから情報を読み出します...といっても
            //読み出して捨てることになります。
            for (int k = currentMemberCount; k < serInfo.MemberInfo.Count; ++k)
            {
                //byte[],char[]をデシリアライズする直前に、そのlengthが
                //デシリアライズされているケースがある、byte[],char[]の
                //デシリアライズにはlengthが必要なのでint型のデータをデ
                //シリアライズした場合は、この値をこの変数に退避します。
                int optCount = 0;
                object oMemberType = serInfo.MemberInfo[k];
                if (oMemberType is Type)
                {
                    Type t = (Type)oMemberType;
                    object oData = TypeDeserializer.DeserializePrimitiveType(reader, t, optCount);
                    if (t.Equals(typeof(int)))
                    {
                        optCount = Convert.ToInt32(oData);
                    }
                    else
                    {
                        optCount = 0;
                    }
                }
                else if (oMemberType is string)
                {
                    Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate formatter = CustomFormatterServices.GetSurrogate((string)oMemberType);
                    object userData = formatter.Deserialize(reader);  //読み飛ばし
                }
            }
            return temp;
        }

        /// <summary>
        ///  Ver5.10.1.0用のカスタムデシリアライザです
        /// </summary>
        /// <returns>CompanyInfWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CompanyInfWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                CompanyInfWork temp = GetCompanyInfWork(reader, serInfo);
                lst.Add(temp);
            }
            switch (serInfo.RetTypeInfo)
            {
                case 0:
                    retValue = lst;
                    break;
                case 1:
                    retValue = lst[0];
                    break;
                case 2:
                    retValue = (CompanyInfWork[])lst.ToArray(typeof(CompanyInfWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}

