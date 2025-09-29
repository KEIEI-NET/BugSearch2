using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
	/// public class name:   TaxRateSet
	/// <summary>
	///                      税率設定クラス
	/// </summary>
	/// <remarks>
	/// <br>note             :   税率設定クラスヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   2005/04/30</br>
	/// <br>Genarated Date   :   2005/05/02  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2007.08.16 980035 金沢 貞義</br>
    /// <br>			         ・端数処理区分を削除して消費税転嫁方式を追加</br>
    /// </remarks>
	public class TaxRateSet
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
		private string _updEmployeeCode;

		/// <summary>更新アセンブリID1</summary>
		/// <remarks>共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）</remarks>
		private string _updAssemblyId1;

		/// <summary>更新アセンブリID2</summary>
		/// <remarks>共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）</remarks>
		private string _updAssemblyId2;

		/// <summary>論理削除区分</summary>
		/// <remarks>共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除)</remarks>
		private Int32 _logicalDeleteCode;

		/// <summary>税率コード</summary>
		/// <remarks>0:一般消費税,1:諸費用消費税</remarks>
		private Int32 _taxRateCode;

		/// <summary>税率固有名称</summary>
		/// <remarks>税率コード固有の名称(変更不可)</remarks>
		private string _taxRateProperNounNm;

		/// <summary>税率名称</summary>
		private string _taxRateName;

        /// <summary>消費税転嫁方式</summary>
		private Int32 _consTaxLayMethod;

		/// <summary>税率開始日</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _taxRateStartDate;

		/// <summary>税率開始日 和暦</summary>
		/// <remarks>YYYYMMDD</remarks>
		private string _taxRateStartDateJpFormal;

		/// <summary>税率開始日 和暦(略)</summary>
		/// <remarks>YYYYMMDD</remarks>
		private string _taxRateStartDateJpInFormal;

		/// <summary>税率開始日 西暦</summary>
		/// <remarks>YYYYMMDD</remarks>
		private string _taxRateStartDateAdFormal;

		/// <summary>税率開始日 西暦(略)</summary>
		/// <remarks>YYYYMMDD</remarks>
		private string _taxRateStartDateAdInFormal;

		/// <summary>税率終了日</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _taxRateEndDate;

		/// <summary>税率終了日 和暦</summary>
		/// <remarks>YYYYMMDD</remarks>
		private string _taxRateEndDateJpFormal;

		/// <summary>税率終了日 和暦(略)</summary>
		/// <remarks>YYYYMMDD</remarks>
		private string _taxRateEndDateJpInFormal;

		/// <summary>税率終了日 西暦</summary>
		/// <remarks>YYYYMMDD</remarks>
		private string _taxRateEndDateAdFormal;

		/// <summary>税率終了日 西暦(略)</summary>
		/// <remarks>YYYYMMDD</remarks>
		private string _taxRateEndDateAdInFormal;

		/// <summary>税率</summary>
		private Double _taxRate;

		/// <summary>税率開始日2</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _taxRateStartDate2;

		/// <summary>税率開始日2 和暦</summary>
		/// <remarks>YYYYMMDD</remarks>
		private string _taxRateStartDate2JpFormal;

		/// <summary>税率開始日2 和暦(略)</summary>
		/// <remarks>YYYYMMDD</remarks>
		private string _taxRateStartDate2JpInFormal;

		/// <summary>税率開始日2 西暦</summary>
		/// <remarks>YYYYMMDD</remarks>
		private string _taxRateStartDate2AdFormal;

		/// <summary>税率開始日2 西暦(略)</summary>
		/// <remarks>YYYYMMDD</remarks>
		private string _taxRateStartDate2AdInFormal;

		/// <summary>税率終了日2</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _taxRateEndDate2;

		/// <summary>税率終了日2 和暦</summary>
		/// <remarks>YYYYMMDD</remarks>
		private string _taxRateEndDate2JpFormal;

		/// <summary>税率終了日2 和暦(略)</summary>
		/// <remarks>YYYYMMDD</remarks>
		private string _taxRateEndDate2JpInFormal;

		/// <summary>税率終了日2 西暦</summary>
		/// <remarks>YYYYMMDD</remarks>
		private string _taxRateEndDate2AdFormal;

		/// <summary>税率終了日2 西暦(略)</summary>
		/// <remarks>YYYYMMDD</remarks>
		private string _taxRateEndDate2AdInFormal;

		/// <summary>税率2</summary>
		private Double _taxRate2;

		/// <summary>税率開始日3</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _taxRateStartDate3;

		/// <summary>税率開始日3 和暦</summary>
		/// <remarks>YYYYMMDD</remarks>
		private string _taxRateStartDate3JpFormal;

		/// <summary>税率開始日3 和暦(略)</summary>
		/// <remarks>YYYYMMDD</remarks>
		private string _taxRateStartDate3JpInFormal;

		/// <summary>税率開始日3 西暦</summary>
		/// <remarks>YYYYMMDD</remarks>
		private string _taxRateStartDate3AdFormal;

		/// <summary>税率開始日3 西暦(略)</summary>
		/// <remarks>YYYYMMDD</remarks>
		private string _taxRateStartDate3AdInFormal;

		/// <summary>税率終了日3</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _taxRateEndDate3;

		/// <summary>税率終了日3 和暦</summary>
		/// <remarks>YYYYMMDD</remarks>
		private string _taxRateEndDate3JpFormal;

		/// <summary>税率終了日3 和暦(略)</summary>
		/// <remarks>YYYYMMDD</remarks>
		private string _taxRateEndDate3JpInFormal;

		/// <summary>税率終了日3 西暦</summary>
		/// <remarks>YYYYMMDD</remarks>
		private string _taxRateEndDate3AdFormal;

		/// <summary>税率終了日3 西暦(略)</summary>
		/// <remarks>YYYYMMDD</remarks>
		private string _taxRateEndDate3AdInFormal;

		/// <summary>税率3</summary>
		private Double _taxRate3;

		/// <summary>更新従業員名称</summary>
		private string _updEmployeeName;

		/// <summary>企業名称</summary>
		private string _enterpriseName;


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

        /// public propaty name  :  CreateDateTimeJpFormal
        /// <summary>作成日時 和暦プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   作成日時 和暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CreateDateTimeJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _createDateTime); }
            set { }
        }

        /// public propaty name  :  CreateDateTimeJpInFormal
        /// <summary>作成日時 和暦(略)プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   作成日時 和暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CreateDateTimeJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _createDateTime); }
            set { }
        }

        /// public propaty name  :  CreateDateTimeAdFormal
        /// <summary>作成日時 西暦プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   作成日時 西暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CreateDateTimeAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _createDateTime); }
            set { }
        }

        /// public propaty name  :  CreateDateTimeAdInFormal
        /// <summary>作成日時 西暦(略)プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   作成日時 西暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CreateDateTimeAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _createDateTime); }
            set { }
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

        /// public propaty name  :  UpdateDateTimeJpFormal
        /// <summary>更新日時 和暦プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新日時 和暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UpdateDateTimeJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _updateDateTime); }
            set { }
        }

        /// public propaty name  :  UpdateDateTimeJpInFormal
        /// <summary>更新日時 和暦(略)プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新日時 和暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UpdateDateTimeJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _updateDateTime); }
            set { }
        }

        /// public propaty name  :  UpdateDateTimeAdFormal
        /// <summary>更新日時 西暦プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新日時 西暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UpdateDateTimeAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _updateDateTime); }
            set { }
        }

        /// public propaty name  :  UpdateDateTimeAdInFormal
        /// <summary>更新日時 西暦(略)プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新日時 西暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UpdateDateTimeAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _updateDateTime); }
            set { }
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

		/// public propaty name  :  TaxRateCode
		/// <summary>税率コードプロパティ</summary>
		/// <value>0:一般消費税,1:諸費用消費税</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   税率コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 TaxRateCode
		{
			get{return _taxRateCode;}
			set{_taxRateCode = value;}
		}

		/// public propaty name  :  TaxRateProperNounNm
		/// <summary>税率固有名称プロパティ</summary>
		/// <value>税率コード固有の名称(変更不可)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   税率固有名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string TaxRateProperNounNm
		{
			get{return _taxRateProperNounNm;}
			set{_taxRateProperNounNm = value;}
		}

		/// public propaty name  :  TaxRateName
		/// <summary>税率名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   税率名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string TaxRateName
		{
			get{return _taxRateName;}
			set{_taxRateName = value;}
		}

        /// public propaty name  :  ConsTaxLayMethod
        /// <summary>消費税転嫁方式プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
        /// <br>note             :   消費税転嫁方式プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
        public Int32 ConsTaxLayMethod
		{
            get{return _consTaxLayMethod;}
            set{_consTaxLayMethod = value;}
		}

        /// public propaty name  :  TaxRateStartDate
		/// <summary>税率開始日プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   税率開始日プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime TaxRateStartDate
		{
			get{return _taxRateStartDate;}
			set
			{
				_taxRateStartDate = value;
				string[] dateTimes = TDateTime.DateTimeToStringArray("YYYYMMDD", value);
				this._taxRateStartDateJpFormal = dateTimes[0];
				this._taxRateStartDateJpInFormal = dateTimes[1];
				this._taxRateStartDateAdFormal = dateTimes[2];
				this._taxRateStartDateAdInFormal = dateTimes[3];
			}
		}

		/// public propaty name  :  TaxRateStartDateJpFormal
		/// <summary>税率開始日 和暦プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   税率開始日 和暦プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string TaxRateStartDateJpFormal
		{
			get{return _taxRateStartDateJpFormal;}
		}

		/// public propaty name  :  TaxRateStartDateJpInFormal
		/// <summary>税率開始日 和暦(略)プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   税率開始日 和暦(略)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string TaxRateStartDateJpInFormal
		{
			get{return _taxRateStartDateJpInFormal;}
		}

		/// public propaty name  :  TaxRateStartDateAdFormal
		/// <summary>税率開始日 西暦プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   税率開始日 西暦プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string TaxRateStartDateAdFormal
		{
			get{return _taxRateStartDateAdFormal;}
		}

		/// public propaty name  :  TaxRateStartDateAdInFormal
		/// <summary>税率開始日 西暦(略)プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   税率開始日 西暦(略)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string TaxRateStartDateAdInFormal
		{
			get{return _taxRateStartDateAdInFormal;}
		}

		/// public propaty name  :  TaxRateEndDate
		/// <summary>税率終了日プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   税率終了日プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime TaxRateEndDate
		{
			get{return _taxRateEndDate;}
			set
			{
				_taxRateEndDate = value;
				string[] dateTimes = TDateTime.DateTimeToStringArray("YYYYMMDD", value);
				this._taxRateEndDateJpFormal = dateTimes[0];
				this._taxRateEndDateJpInFormal = dateTimes[1];
				this._taxRateEndDateAdFormal = dateTimes[2];
				this._taxRateEndDateAdInFormal = dateTimes[3];
			}
		}

		/// public propaty name  :  TaxRateEndDateJpFormal
		/// <summary>税率終了日 和暦プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   税率終了日 和暦プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string TaxRateEndDateJpFormal
		{
			get{return _taxRateEndDateJpFormal;}
		}

		/// public propaty name  :  TaxRateEndDateJpInFormal
		/// <summary>税率終了日 和暦(略)プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   税率終了日 和暦(略)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string TaxRateEndDateJpInFormal
		{
			get{return _taxRateEndDateJpInFormal;}
		}

		/// public propaty name  :  TaxRateEndDateAdFormal
		/// <summary>税率終了日 西暦プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   税率終了日 西暦プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string TaxRateEndDateAdFormal
		{
			get{return _taxRateEndDateAdFormal;}
		}

		/// public propaty name  :  TaxRateEndDateAdInFormal
		/// <summary>税率終了日 西暦(略)プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   税率終了日 西暦(略)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string TaxRateEndDateAdInFormal
		{
			get{return _taxRateEndDateAdInFormal;}
		}

		/// public propaty name  :  TaxRate
		/// <summary>税率プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   税率プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double TaxRate
		{
			get{return _taxRate;}
			set{_taxRate = value;}
		}

		/// public propaty name  :  TaxRateStartDate2
		/// <summary>税率開始日2プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   税率開始日2プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime TaxRateStartDate2
		{
			get{return _taxRateStartDate2;}
			set
			{
				_taxRateStartDate2 = value;
				string[] dateTimes = TDateTime.DateTimeToStringArray("YYYYMMDD", value);
				this._taxRateStartDate2JpFormal = dateTimes[0];
				this._taxRateStartDate2JpInFormal = dateTimes[1];
				this._taxRateStartDate2AdFormal = dateTimes[2];
				this._taxRateStartDate2AdInFormal = dateTimes[3];
			}
		}

		/// public propaty name  :  TaxRateStartDate2JpFormal
		/// <summary>税率開始日2 和暦プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   税率開始日2 和暦プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string TaxRateStartDate2JpFormal
		{
			get{return _taxRateStartDate2JpFormal;}
		}

		/// public propaty name  :  TaxRateStartDate2JpInFormal
		/// <summary>税率開始日2 和暦(略)プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   税率開始日2 和暦(略)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string TaxRateStartDate2JpInFormal
		{
			get{return _taxRateStartDate2JpInFormal;}
		}

		/// public propaty name  :  TaxRateStartDate2AdFormal
		/// <summary>税率開始日2 西暦プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   税率開始日2 西暦プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string TaxRateStartDate2AdFormal
		{
			get{return _taxRateStartDate2AdFormal;}
		}

		/// public propaty name  :  TaxRateStartDate2AdInFormal
		/// <summary>税率開始日2 西暦(略)プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   税率開始日2 西暦(略)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string TaxRateStartDate2AdInFormal
		{
			get{return _taxRateStartDate2AdInFormal;}
		}

		/// public propaty name  :  TaxRateEndDate2
		/// <summary>税率終了日2プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   税率終了日2プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime TaxRateEndDate2
		{
			get{return _taxRateEndDate2;}
			set
			{
				_taxRateEndDate2 = value;
				string[] dateTimes = TDateTime.DateTimeToStringArray("YYYYMMDD", value);
				this._taxRateEndDate2JpFormal = dateTimes[0];
				this._taxRateEndDate2JpInFormal = dateTimes[1];
				this._taxRateEndDate2AdFormal = dateTimes[2];
				this._taxRateEndDate2AdInFormal = dateTimes[3];
			}
		}

		/// public propaty name  :  TaxRateEndDate2JpFormal
		/// <summary>税率終了日2 和暦プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   税率終了日2 和暦プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string TaxRateEndDate2JpFormal
		{
			get{return _taxRateEndDate2JpFormal;}
		}

		/// public propaty name  :  TaxRateEndDate2JpInFormal
		/// <summary>税率終了日2 和暦(略)プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   税率終了日2 和暦(略)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string TaxRateEndDate2JpInFormal
		{
			get{return _taxRateEndDate2JpInFormal;}
		}

		/// public propaty name  :  TaxRateEndDate2AdFormal
		/// <summary>税率終了日2 西暦プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   税率終了日2 西暦プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string TaxRateEndDate2AdFormal
		{
			get{return _taxRateEndDate2AdFormal;}
		}

		/// public propaty name  :  TaxRateEndDate2AdInFormal
		/// <summary>税率終了日2 西暦(略)プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   税率終了日2 西暦(略)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string TaxRateEndDate2AdInFormal
		{
			get{return _taxRateEndDate2AdInFormal;}
		}

		/// public propaty name  :  TaxRate2
		/// <summary>税率2プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   税率2プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double TaxRate2
		{
			get{return _taxRate2;}
			set{_taxRate2 = value;}
		}

		/// public propaty name  :  TaxRateStartDate3
		/// <summary>税率開始日3プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   税率開始日3プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime TaxRateStartDate3
		{
			get{return _taxRateStartDate3;}
			set
			{
				_taxRateStartDate3 = value;
				string[] dateTimes = TDateTime.DateTimeToStringArray("YYYYMMDD", value);
				this._taxRateStartDate3JpFormal = dateTimes[0];
				this._taxRateStartDate3JpInFormal = dateTimes[1];
				this._taxRateStartDate3AdFormal = dateTimes[2];
				this._taxRateStartDate3AdInFormal = dateTimes[3];
			}
		}

		/// public propaty name  :  TaxRateStartDate3JpFormal
		/// <summary>税率開始日3 和暦プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   税率開始日3 和暦プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string TaxRateStartDate3JpFormal
		{
			get{return _taxRateStartDate3JpFormal;}
		}

		/// public propaty name  :  TaxRateStartDate3JpInFormal
		/// <summary>税率開始日3 和暦(略)プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   税率開始日3 和暦(略)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string TaxRateStartDate3JpInFormal
		{
			get{return _taxRateStartDate3JpInFormal;}
		}

		/// public propaty name  :  TaxRateStartDate3AdFormal
		/// <summary>税率開始日3 西暦プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   税率開始日3 西暦プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string TaxRateStartDate3AdFormal
		{
			get{return _taxRateStartDate3AdFormal;}
		}

		/// public propaty name  :  TaxRateStartDate3AdInFormal
		/// <summary>税率開始日3 西暦(略)プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   税率開始日3 西暦(略)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string TaxRateStartDate3AdInFormal
		{
			get{return _taxRateStartDate3AdInFormal;}
		}

		/// public propaty name  :  TaxRateEndDate3
		/// <summary>税率終了日3プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   税率終了日3プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime TaxRateEndDate3
		{
			get{return _taxRateEndDate3;}
			set
			{
				_taxRateEndDate3 = value;
				string[] dateTimes = TDateTime.DateTimeToStringArray("YYYYMMDD", value);
				this._taxRateEndDate3JpFormal = dateTimes[0];
				this._taxRateEndDate3JpInFormal = dateTimes[1];
				this._taxRateEndDate3AdFormal = dateTimes[2];
				this._taxRateEndDate3AdInFormal = dateTimes[3];
			}
		}

		/// public propaty name  :  TaxRateEndDate3JpFormal
		/// <summary>税率終了日3 和暦プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   税率終了日3 和暦プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string TaxRateEndDate3JpFormal
		{
			get{return _taxRateEndDate3JpFormal;}
		}

		/// public propaty name  :  TaxRateEndDate3JpInFormal
		/// <summary>税率終了日3 和暦(略)プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   税率終了日3 和暦(略)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string TaxRateEndDate3JpInFormal
		{
			get{return _taxRateEndDate3JpInFormal;}
		}

		/// public propaty name  :  TaxRateEndDate3AdFormal
		/// <summary>税率終了日3 西暦プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   税率終了日3 西暦プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string TaxRateEndDate3AdFormal
		{
			get{return _taxRateEndDate3AdFormal;}
		}

		/// public propaty name  :  TaxRateEndDate3AdInFormal
		/// <summary>税率終了日3 西暦(略)プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   税率終了日3 西暦(略)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string TaxRateEndDate3AdInFormal
		{
			get{return _taxRateEndDate3AdInFormal;}
		}

		/// public propaty name  :  TaxRate3
		/// <summary>税率3プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   税率3プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double TaxRate3
		{
			get{return _taxRate3;}
			set{_taxRate3 = value;}
		}

		/// public propaty name  :  UpdEmployeeName
		/// <summary>更新従業員名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   更新従業員名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string UpdEmployeeName
		{
			get{return _updEmployeeName;}
			set{_updEmployeeName = value;}
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
			get{return _enterpriseName;}
			set{_enterpriseName = value;}
		}


		/// <summary>
		/// 税率設定クラスコンストラクタ
		/// </summary>
		/// <returns>TaxRateSetクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   TaxRateSetクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public TaxRateSet()
		{
		}

        /// <summary>
		/// 税率設定クラスコンストラクタ
		/// </summary>
		/// <param name="createDateTime">作成日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
		/// <param name="updateDateTime">更新日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
		/// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
		/// <param name="fileHeaderGuid">GUID(共通ファイルヘッダ)</param>
		/// <param name="updEmployeeCode">更新従業員コード(共通ファイルヘッダ)</param>
		/// <param name="updAssemblyId1">更新アセンブリID1(共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）)</param>
		/// <param name="updAssemblyId2">更新アセンブリID2(共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）)</param>
		/// <param name="logicalDeleteCode">論理削除区分(共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除))</param>
		/// <param name="taxRateCode">税率コード(0:一般消費税,1:諸費用消費税)</param>
		/// <param name="taxRateProperNounNm">税率固有名称(税率コード固有の名称(変更不可))</param>
		/// <param name="taxRateName">税率名称</param>
        /// <param name="fractionProcCd">消費税転嫁方式</param>
		/// <param name="taxRateStartDate">税率開始日(YYYYMMDD)</param>
		/// <param name="taxRateEndDate">税率終了日(YYYYMMDD)</param>
		/// <param name="taxRate">税率</param>
		/// <param name="taxRateStartDate2">税率開始日2(YYYYMMDD)</param>
		/// <param name="taxRateEndDate2">税率終了日2(YYYYMMDD)</param>
		/// <param name="taxRate2">税率2</param>
		/// <param name="taxRateStartDate3">税率開始日3(YYYYMMDD)</param>
		/// <param name="taxRateEndDate3">税率終了日3(YYYYMMDD)</param>
		/// <param name="taxRate3">税率3</param>
		/// <param name="updEmployeeName">更新従業員名称</param>
		/// <param name="enterpriseName">企業名称</param>
		/// <returns>TaxRateSetクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   TaxRateSetクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
        public TaxRateSet(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 taxRateCode, string taxRateProperNounNm, string taxRateName, Int32 consTaxLayMethod, DateTime taxRateStartDate, DateTime taxRateEndDate, Double taxRate, DateTime taxRateStartDate2, DateTime taxRateEndDate2, Double taxRate2, DateTime taxRateStartDate3, DateTime taxRateEndDate3, Double taxRate3, string updEmployeeName, string enterpriseName)
		{
			this.CreateDateTime = createDateTime;
			this.UpdateDateTime = updateDateTime;
			this._enterpriseCode = enterpriseCode;
			this._fileHeaderGuid = fileHeaderGuid;
			this._updEmployeeCode = updEmployeeCode;
			this._updAssemblyId1 = updAssemblyId1;
			this._updAssemblyId2 = updAssemblyId2;
			this._logicalDeleteCode = logicalDeleteCode;
			this._taxRateCode = taxRateCode;
			this._taxRateProperNounNm = taxRateProperNounNm;
			this._taxRateName = taxRateName;
            this._consTaxLayMethod = consTaxLayMethod;
			this.TaxRateStartDate = taxRateStartDate;
			this.TaxRateEndDate = taxRateEndDate;
			this._taxRate = taxRate;
			this.TaxRateStartDate2 = taxRateStartDate2;
			this.TaxRateEndDate2 = taxRateEndDate2;
			this._taxRate2 = taxRate2;
			this.TaxRateStartDate3 = taxRateStartDate3;
			this.TaxRateEndDate3 = taxRateEndDate3;
			this._taxRate3 = taxRate3;
			this._updEmployeeName = updEmployeeName;
			this._enterpriseName = enterpriseName;

		}

		/// <summary>
		/// 税率設定クラス複製処理
		/// </summary>
		/// <returns>TaxRateSetクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   自身の内容と等しいTaxRateSetクラスのインスタンスを返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public TaxRateSet Clone()
		{
            return new TaxRateSet(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._taxRateCode, this._taxRateProperNounNm, this._taxRateName, this._consTaxLayMethod, this._taxRateStartDate, this._taxRateEndDate, this._taxRate, this._taxRateStartDate2, this._taxRateEndDate2, this._taxRate2, this._taxRateStartDate3, this._taxRateEndDate3, this._taxRate3, this._updEmployeeName, this._enterpriseName);
		}

		/// <summary>
		/// 税率設定クラス比較処理
		/// </summary>
		/// <param name="target">比較対象のTaxRateSetクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   TaxRateSetクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public bool Equals(TaxRateSet target)
		{
			return ((this.CreateDateTime == target.CreateDateTime)
				&& (this.UpdateDateTime == target.UpdateDateTime)
				&& (this.EnterpriseCode == target.EnterpriseCode)
				&& (this.FileHeaderGuid == target.FileHeaderGuid)
				&& (this.UpdEmployeeCode == target.UpdEmployeeCode)
				&& (this.UpdAssemblyId1 == target.UpdAssemblyId1)
				&& (this.UpdAssemblyId2 == target.UpdAssemblyId2)
				&& (this.LogicalDeleteCode == target.LogicalDeleteCode)
				&& (this.TaxRateCode == target.TaxRateCode)
				&& (this.TaxRateProperNounNm == target.TaxRateProperNounNm)
				&& (this.TaxRateName == target.TaxRateName)
                && (this.ConsTaxLayMethod == target.ConsTaxLayMethod)
				&& (this.TaxRateStartDate == target.TaxRateStartDate)
				&& (this.TaxRateEndDate == target.TaxRateEndDate)
				&& (this.TaxRate == target.TaxRate)
				&& (this.TaxRateStartDate2 == target.TaxRateStartDate2)
				&& (this.TaxRateEndDate2 == target.TaxRateEndDate2)
				&& (this.TaxRate2 == target.TaxRate2)
				&& (this.TaxRateStartDate3 == target.TaxRateStartDate3)
				&& (this.TaxRateEndDate3 == target.TaxRateEndDate3)
				&& (this.TaxRate3 == target.TaxRate3)
				&& (this.UpdEmployeeName == target.UpdEmployeeName)
				&& (this.EnterpriseName == target.EnterpriseName));
		}

		/// <summary>
		/// 税率設定クラス比較処理
		/// </summary>
		/// <param name="taxrateset1">
		///                    比較するTaxRateSetクラスのインスタンス
		/// </param>
		/// <param name="taxrateset2">比較するTaxRateSetクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   TaxRateSetクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static bool Equals(TaxRateSet taxrateset1, TaxRateSet taxrateset2)
		{
			return ((taxrateset1.CreateDateTime == taxrateset2.CreateDateTime)
				&& (taxrateset1.UpdateDateTime == taxrateset2.UpdateDateTime)
				&& (taxrateset1.EnterpriseCode == taxrateset2.EnterpriseCode)
				&& (taxrateset1.FileHeaderGuid == taxrateset2.FileHeaderGuid)
				&& (taxrateset1.UpdEmployeeCode == taxrateset2.UpdEmployeeCode)
				&& (taxrateset1.UpdAssemblyId1 == taxrateset2.UpdAssemblyId1)
				&& (taxrateset1.UpdAssemblyId2 == taxrateset2.UpdAssemblyId2)
				&& (taxrateset1.LogicalDeleteCode == taxrateset2.LogicalDeleteCode)
				&& (taxrateset1.TaxRateCode == taxrateset2.TaxRateCode)
				&& (taxrateset1.TaxRateProperNounNm == taxrateset2.TaxRateProperNounNm)
				&& (taxrateset1.TaxRateName == taxrateset2.TaxRateName)
                && (taxrateset1.ConsTaxLayMethod == taxrateset2.ConsTaxLayMethod)
				&& (taxrateset1.TaxRateStartDate == taxrateset2.TaxRateStartDate)
				&& (taxrateset1.TaxRateEndDate == taxrateset2.TaxRateEndDate)
				&& (taxrateset1.TaxRate == taxrateset2.TaxRate)
				&& (taxrateset1.TaxRateStartDate2 == taxrateset2.TaxRateStartDate2)
				&& (taxrateset1.TaxRateEndDate2 == taxrateset2.TaxRateEndDate2)
				&& (taxrateset1.TaxRate2 == taxrateset2.TaxRate2)
				&& (taxrateset1.TaxRateStartDate3 == taxrateset2.TaxRateStartDate3)
				&& (taxrateset1.TaxRateEndDate3 == taxrateset2.TaxRateEndDate3)
				&& (taxrateset1.TaxRate3 == taxrateset2.TaxRate3)
				&& (taxrateset1.UpdEmployeeName == taxrateset2.UpdEmployeeName)
				&& (taxrateset1.EnterpriseName == taxrateset2.EnterpriseName));
		}
		/// <summary>
		/// 税率設定クラス比較処理
		/// </summary>
		/// <param name="target">比較対象のTaxRateSetクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   TaxRateSetクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ArrayList Compare(TaxRateSet target)
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
			if(this.TaxRateCode != target.TaxRateCode)resList.Add("TaxRateCode");
			if(this.TaxRateProperNounNm != target.TaxRateProperNounNm)resList.Add("TaxRateProperNounNm");
			if(this.TaxRateName != target.TaxRateName)resList.Add("TaxRateName");
            if(this.ConsTaxLayMethod != target.ConsTaxLayMethod)resList.Add("ConsTaxLayMethod");
			if(this.TaxRateStartDate != target.TaxRateStartDate)resList.Add("TaxRateStartDate");
			if(this.TaxRateEndDate != target.TaxRateEndDate)resList.Add("TaxRateEndDate");
			if(this.TaxRate != target.TaxRate)resList.Add("TaxRate");
			if(this.TaxRateStartDate2 != target.TaxRateStartDate2)resList.Add("TaxRateStartDate2");
			if(this.TaxRateEndDate2 != target.TaxRateEndDate2)resList.Add("TaxRateEndDate2");
			if(this.TaxRate2 != target.TaxRate2)resList.Add("TaxRate2");
			if(this.TaxRateStartDate3 != target.TaxRateStartDate3)resList.Add("TaxRateStartDate3");
			if(this.TaxRateEndDate3 != target.TaxRateEndDate3)resList.Add("TaxRateEndDate3");
			if(this.TaxRate3 != target.TaxRate3)resList.Add("TaxRate3");
			if(this.UpdEmployeeName != target.UpdEmployeeName)resList.Add("UpdEmployeeName");
			if(this.EnterpriseName != target.EnterpriseName)resList.Add("EnterpriseName");

			return resList;
		}

		/// <summary>
		/// 税率設定クラス比較処理
		/// </summary>
		/// <param name="taxrateset1">比較するTaxRateSetクラスのインスタンス</param>
		/// <param name="taxrateset2">比較するTaxRateSetクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   TaxRateSetクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static ArrayList Compare(TaxRateSet taxrateset1, TaxRateSet taxrateset2)
		{
			ArrayList resList = new ArrayList();
			if(taxrateset1.CreateDateTime != taxrateset2.CreateDateTime)resList.Add("CreateDateTime");
			if(taxrateset1.UpdateDateTime != taxrateset2.UpdateDateTime)resList.Add("UpdateDateTime");
			if(taxrateset1.EnterpriseCode != taxrateset2.EnterpriseCode)resList.Add("EnterpriseCode");
			if(taxrateset1.FileHeaderGuid != taxrateset2.FileHeaderGuid)resList.Add("FileHeaderGuid");
			if(taxrateset1.UpdEmployeeCode != taxrateset2.UpdEmployeeCode)resList.Add("UpdEmployeeCode");
			if(taxrateset1.UpdAssemblyId1 != taxrateset2.UpdAssemblyId1)resList.Add("UpdAssemblyId1");
			if(taxrateset1.UpdAssemblyId2 != taxrateset2.UpdAssemblyId2)resList.Add("UpdAssemblyId2");
			if(taxrateset1.LogicalDeleteCode != taxrateset2.LogicalDeleteCode)resList.Add("LogicalDeleteCode");
			if(taxrateset1.TaxRateCode != taxrateset2.TaxRateCode)resList.Add("TaxRateCode");
			if(taxrateset1.TaxRateProperNounNm != taxrateset2.TaxRateProperNounNm)resList.Add("TaxRateProperNounNm");
			if(taxrateset1.TaxRateName != taxrateset2.TaxRateName)resList.Add("TaxRateName");
            if(taxrateset1.ConsTaxLayMethod != taxrateset2.ConsTaxLayMethod)resList.Add("ConsTaxLayMethod");
			if(taxrateset1.TaxRateStartDate != taxrateset2.TaxRateStartDate)resList.Add("TaxRateStartDate");
			if(taxrateset1.TaxRateEndDate != taxrateset2.TaxRateEndDate)resList.Add("TaxRateEndDate");
			if(taxrateset1.TaxRate != taxrateset2.TaxRate)resList.Add("TaxRate");
			if(taxrateset1.TaxRateStartDate2 != taxrateset2.TaxRateStartDate2)resList.Add("TaxRateStartDate2");
			if(taxrateset1.TaxRateEndDate2 != taxrateset2.TaxRateEndDate2)resList.Add("TaxRateEndDate2");
			if(taxrateset1.TaxRate2 != taxrateset2.TaxRate2)resList.Add("TaxRate2");
			if(taxrateset1.TaxRateStartDate3 != taxrateset2.TaxRateStartDate3)resList.Add("TaxRateStartDate3");
			if(taxrateset1.TaxRateEndDate3 != taxrateset2.TaxRateEndDate3)resList.Add("TaxRateEndDate3");
			if(taxrateset1.TaxRate3 != taxrateset2.TaxRate3)resList.Add("TaxRate3");
			if(taxrateset1.UpdEmployeeName != taxrateset2.UpdEmployeeName)resList.Add("UpdEmployeeName");
			if(taxrateset1.EnterpriseName != taxrateset2.EnterpriseName)resList.Add("EnterpriseName");

			return resList;
		}
	}
}
