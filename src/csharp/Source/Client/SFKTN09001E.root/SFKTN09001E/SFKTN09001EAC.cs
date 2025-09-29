using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   SecInfoSet
    /// <summary>
    ///                      拠点情報設定クラス
    /// </summary>
    /// <remarks>
    /// <br>note             :   拠点情報設定クラスヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2005/3/18</br>
    /// <br>Genarated Date   :   2005/03/31  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2006.12.13 22022 段上 知子</br>
    /// <br>        					1.SF版を流用し携帯版を作成</br>
    /// <br>        					2.自社名称1を必須入力へ変更</br>
    /// -----------------------------------------------------------------------
    /// <br>Update Note      : 2008/06/03 30414　忍　幸史</br>
    /// <br>                 :「拠点略称」「導入年月日」追加、「他拠点伝票自社名印刷区分」「予備２～１０」削除</br>
    /// </remarks>
    public class SecInfoSet
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

        /// <summary>拠点コード</summary>
        private string _sectionCode = "";

        ///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA DEL STA //
        //		/// <summary>自社PR文</summary>
        //		private string _companyPr = "";
        //
        //		/// <summary>自社名称1</summary>
        //		private string _companyName1 = "";
        //
        //		/// <summary>自社名称2</summary>
        //		private string _companyName2 = "";
        //
        //		/// <summary>郵便番号</summary>
        //		private string _postNo = "";
        //
        //		/// <summary>住所1（都道府県市区郡・町村・字）</summary>
        //		private string _address1 = "";
        //
        //		/// <summary>住所2（丁目）</summary>
        //		private Int32 _address2;
        //
        //		/// <summary>住所3（番地）</summary>
        //		private string _address3 = "";
        //
        //		/// <summary>住所4（アパート名称）</summary>
        //		private string _address4 = "";
        //
        //		/// <summary>自社電話番号1</summary>
        //		private string _companyTelNo1 = "";
        //
        //		/// <summary>自社電話番号2</summary>
        //		private string _companyTelNo2 = "";
        //
        //		/// <summary>自社電話番号3</summary>
        //		private string _companyTelNo3 = "";
        //
        //		/// <summary>自社電話番号タイトル1</summary>
        //		private string _companyTelTitle1 = "";
        //
        //		/// <summary>自社電話番号タイトル2</summary>
        //		private string _companyTelTitle2 = "";
        //
        //		/// <summary>自社電話番号タイトル3</summary>
        //		private string _companyTelTitle3 = "";
        //
        //		/// <summary>銀行振込案内文</summary>
        //		private string _transferGuidance = "";
        //
        //		/// <summary>銀行口座1</summary>
        //		private string _accountNoInfo1 = "";
        //
        //		/// <summary>銀行口座2</summary>
        //		private string _accountNoInfo2 = "";
        //
        //		/// <summary>銀行口座3</summary>
        //		private string _accountNoInfo3 = "";
        //
        //		/// <summary>自社設定摘要1</summary>
        //		private string _companySetNote1 = "";
        //
        //		/// <summary>自社設定摘要2</summary>
        //		private string _companySetNote2 = "";
        //
        //		/// <summary>伝票自社名印刷区分</summary>
        //		/// <remarks>0:拠点設定,1:自社設定</remarks>
        //		private Int32 _slipCompanyNmCd;
        // 2005.09.13 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////

        /* --- DEL 2008/06/03 --------------------------------------------------------------------->>>>>
        /// <summary>他拠点伝票自社印刷区分</summary>
        /// <remarks>0:他拠点情報,1:自拠点情報　※１</remarks>
        private Int32 _othrSlipCompanyNmCd;
           --- DEL 2008/06/03 ---------------------------------------------------------------------<<<<<*/

        /// <summary>拠点ガイド名称</summary>
        private string _sectionGuideNm = "";

        /// <summary>本社機能フラグ</summary>
        /// <remarks>0:拠点 1:本社</remarks>
        private Int32 _mainOfficeFuncFlag;

        ///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA DEL STA //
        //		/// <summary>請求書自社名印刷区分</summary>
        //		/// <remarks>0:拠点設定,1:自社設定</remarks>
        //		private Int32 _billCompanyNmPrtCd;
        // 2005.09.13 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////

        ///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA ADD STA //

        /* --- DEL 2008/06/03 --------------------------------------------------------------------->>>>>
        /// <summary>拠点コード（番号採番用）</summary>
        /// <remarks>各種の管理番号で拠点を識別する２桁のユニークコード</remarks>
        private string _secCdForNumbering = "";
           --- DEL 2008/06/03 ---------------------------------------------------------------------<<<<<*/

        /// <summary>自社名称コード1</summary>
        /// <remarks>整備システムで使用する自社名称コード</remarks>
        private Int32 _companyNameCd1;

        /* --- DEL 2008/06/03 --------------------------------------------------------------------->>>>>
        /// <summary>自社名称コード2</summary>
        /// <remarks>鈑金システムで使用する自社名称コード</remarks>
        private Int32 _companyNameCd2;

        /// <summary>自社名称コード3</summary>
        /// <remarks>車販システムで使用する自社名称コード</remarks>
        private Int32 _companyNameCd3;

        /// <summary>自社名称コード4</summary>
        /// <remarks>請求書関連で使用する自社名称コード</remarks>
        private Int32 _companyNameCd4;

        /// <summary>自社名称コード5</summary>
        private Int32 _companyNameCd5;

        /// <summary>自社名称コード6</summary>
        private Int32 _companyNameCd6;

        /// <summary>自社名称コード7</summary>
        private Int32 _companyNameCd7;

        /// <summary>自社名称コード8</summary>
        private Int32 _companyNameCd8;

        /// <summary>自社名称コード9</summary>
        private Int32 _companyNameCd9;

        /// <summary>自社名称コード10</summary>
        private Int32 _companyNameCd10;
           --- DEL 2008/06/03 ---------------------------------------------------------------------<<<<<*/

        /// <summary>自社名称1</summary>
        /// <remarks>整備システムで使用する自社名称</remarks>
        private string _companyName1 = "";

        /* --- DEL 2008/06/03 --------------------------------------------------------------------->>>>>
        /// <summary>自社名称2</summary>
        /// <remarks>鈑金システムで使用する自社名称</remarks>
        private string _companyName2 = "";

        /// <summary>自社名称3</summary>
        /// <remarks>車販システムで使用する自社名称</remarks>
        private string _companyName3 = "";

        /// <summary>自社名称4</summary>
        /// <remarks>請求書関連で使用する自社名称</remarks>
        private string _companyName4 = "";

        /// <summary>自社名称5</summary>
        private string _companyName5 = "";

        /// <summary>自社名称6</summary>
        private string _companyName6 = "";

        /// <summary>自社名称7</summary>
        private string _companyName7 = "";

        /// <summary>自社名称8</summary>
        private string _companyName8 = "";

        /// <summary>自社名称9</summary>
        private string _companyName9 = "";

        /// <summary>自社名称10</summary>
        private string _companyName10 = "";
           --- DEL 2008/06/03 ---------------------------------------------------------------------<<<<<*/

        //↓ 2007.10.5 add/////////////////////////

        /// <summary>拠点倉庫コード1</summary>
        /// <remarks>拠点毎の倉庫優先順位1</remarks>
        private string _sectWarehouseCd1 = "";

        /// <summary>拠点倉庫コード2</summary>
        /// <remarks>拠点毎の倉庫優先順位2</remarks>
        private string _sectWarehouseCd2 = "";

        /// <summary>拠点倉庫コード3</summary>
        /// <remarks>拠点毎の倉庫優先順位3</remarks>
        private string _sectWarehouseCd3 = "";

        /// <summary>拠点倉庫名称1</summary>
        private string _sectWarehouseNm1 = "";

        /// <summary>拠点倉庫名称2</summary>
        private string _sectWarehouseNm2 = "";

        /// <summary>拠点倉庫名称3</summary>
        private string _sectWarehouseNm3 = "";

        //↑ 2007.10.5 add/////////////////////////

        // 2005.09.13 AKIYAMA ADD END /////////////////////////////////////////////////////////////////////

        /// <summary>更新従業員名称</summary>
        private string _updEmployeeName = "";

        /// <summary>企業名称</summary>
        private string _enterpriseName = "";

        ///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA DEL STA //
        //		/// <summary>伝票自社名印刷区分名称</summary>
        //		private string _slipCompanyNm;
        //
        //		/// <summary>他拠点伝票自社印刷区分名称</summary>
        //		private string _othrSlipCompanyNm;
        //
        //		/// <summary>本社機能フラグ名称</summary>
        //		private string _mainOfficeFuncNm;
        //
        //		/// <summary>請求書自社名印刷区分名称</summary>
        //		private string _billCompanyNmPrtNm;
        // 2005.09.13 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////

        // --- ADD 2008/06/03 --------------------------------------------------------------------->>>>>
        /// <summary>拠点略称</summary>
        private string _sectionGuideSnm = "";

        /// <summary>導入年月日</summary>
        private DateTime _introductionDate;
        // --- ADD 2008/06/03 ---------------------------------------------------------------------<<<<<

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

        /// public propaty name  :  SectionCode
        /// <summary>拠点コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SectionCode
        {
            get { return _sectionCode; }
            set { _sectionCode = value; }
        }

        ///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA DEL STA //
        //		/// public propaty name  :  CompanyPr
        //		/// <summary>自社PR文プロパティ</summary>
        //		/// ----------------------------------------------------------------------
        //		/// <remarks>
        //		/// <br>note             :   自社PR文プロパティ</br>
        //		/// <br>Programer        :   自動生成</br>
        //		/// </remarks>
        //		public string CompanyPr
        //		{
        //			get{return _companyPr;}
        //			set{_companyPr = value;}
        //		}
        //
        //		/// public propaty name  :  CompanyName1
        //		/// <summary>自社名称1プロパティ</summary>
        //		/// ----------------------------------------------------------------------
        //		/// <remarks>
        //		/// <br>note             :   自社名称1プロパティ</br>
        //		/// <br>Programer        :   自動生成</br>
        //		/// </remarks>
        //		public string CompanyName1
        //		{
        //			get{return _companyName1;}
        //			set{_companyName1 = value;}
        //		}
        //
        //		/// public propaty name  :  CompanyName2
        //		/// <summary>自社名称2プロパティ</summary>
        //		/// ----------------------------------------------------------------------
        //		/// <remarks>
        //		/// <br>note             :   自社名称2プロパティ</br>
        //		/// <br>Programer        :   自動生成</br>
        //		/// </remarks>
        //		public string CompanyName2
        //		{
        //			get{return _companyName2;}
        //			set{_companyName2 = value;}
        //		}
        //
        //		/// public propaty name  :  PostNo
        //		/// <summary>郵便番号プロパティ</summary>
        //		/// ----------------------------------------------------------------------
        //		/// <remarks>
        //		/// <br>note             :   郵便番号プロパティ</br>
        //		/// <br>Programer        :   自動生成</br>
        //		/// </remarks>
        //		public string PostNo
        //		{
        //			get{return _postNo;}
        //			set{_postNo = value;}
        //		}
        //
        //		/// public propaty name  :  Address1
        //		/// <summary>住所1（都道府県市区郡・町村・字）プロパティ</summary>
        //		/// ----------------------------------------------------------------------
        //		/// <remarks>
        //		/// <br>note             :   住所1（都道府県市区郡・町村・字）プロパティ</br>
        //		/// <br>Programer        :   自動生成</br>
        //		/// </remarks>
        //		public string Address1
        //		{
        //			get{return _address1;}
        //			set{_address1 = value;}
        //		}
        //
        //		/// public propaty name  :  Address2
        //		/// <summary>住所2（丁目）プロパティ</summary>
        //		/// ----------------------------------------------------------------------
        //		/// <remarks>
        //		/// <br>note             :   住所2（丁目）プロパティ</br>
        //		/// <br>Programer        :   自動生成</br>
        //		/// </remarks>
        //		public Int32 Address2
        //		{
        //			get{return _address2;}
        //			set{_address2 = value;}
        //		}
        //
        //		/// public propaty name  :  Address3
        //		/// <summary>住所3（番地）プロパティ</summary>
        //		/// ----------------------------------------------------------------------
        //		/// <remarks>
        //		/// <br>note             :   住所3（番地）プロパティ</br>
        //		/// <br>Programer        :   自動生成</br>
        //		/// </remarks>
        //		public string Address3
        //		{
        //			get{return _address3;}
        //			set{_address3 = value;}
        //		}
        //
        //		/// public propaty name  :  Address4
        //		/// <summary>住所4（アパート名称）プロパティ</summary>
        //		/// ----------------------------------------------------------------------
        //		/// <remarks>
        //		/// <br>note             :   住所4（アパート名称）プロパティ</br>
        //		/// <br>Programer        :   自動生成</br>
        //		/// </remarks>
        //		public string Address4
        //		{
        //			get{return _address4;}
        //			set{_address4 = value;}
        //		}
        //
        //		/// public propaty name  :  CompanyTelNo1
        //		/// <summary>自社電話番号1プロパティ</summary>
        //		/// ----------------------------------------------------------------------
        //		/// <remarks>
        //		/// <br>note             :   自社電話番号1プロパティ</br>
        //		/// <br>Programer        :   自動生成</br>
        //		/// </remarks>
        //		public string CompanyTelNo1
        //		{
        //			get{return _companyTelNo1;}
        //			set{_companyTelNo1 = value;}
        //		}
        //
        //		/// public propaty name  :  CompanyTelNo2
        //		/// <summary>自社電話番号2プロパティ</summary>
        //		/// ----------------------------------------------------------------------
        //		/// <remarks>
        //		/// <br>note             :   自社電話番号2プロパティ</br>
        //		/// <br>Programer        :   自動生成</br>
        //		/// </remarks>
        //		public string CompanyTelNo2
        //		{
        //			get{return _companyTelNo2;}
        //			set{_companyTelNo2 = value;}
        //		}
        //
        //		/// public propaty name  :  CompanyTelNo3
        //		/// <summary>自社電話番号3プロパティ</summary>
        //		/// ----------------------------------------------------------------------
        //		/// <remarks>
        //		/// <br>note             :   自社電話番号3プロパティ</br>
        //		/// <br>Programer        :   自動生成</br>
        //		/// </remarks>
        //		public string CompanyTelNo3
        //		{
        //			get{return _companyTelNo3;}
        //			set{_companyTelNo3 = value;}
        //		}
        //
        //		/// public propaty name  :  CompanyTelTitle1
        //		/// <summary>自社電話番号タイトル1プロパティ</summary>
        //		/// ----------------------------------------------------------------------
        //		/// <remarks>
        //		/// <br>note             :   自社電話番号タイトル1プロパティ</br>
        //		/// <br>Programer        :   自動生成</br>
        //		/// </remarks>
        //		public string CompanyTelTitle1
        //		{
        //			get{return _companyTelTitle1;}
        //			set{_companyTelTitle1 = value;}
        //		}
        //
        //		/// public propaty name  :  CompanyTelTitle2
        //		/// <summary>自社電話番号タイトル2プロパティ</summary>
        //		/// ----------------------------------------------------------------------
        //		/// <remarks>
        //		/// <br>note             :   自社電話番号タイトル2プロパティ</br>
        //		/// <br>Programer        :   自動生成</br>
        //		/// </remarks>
        //		public string CompanyTelTitle2
        //		{
        //			get{return _companyTelTitle2;}
        //			set{_companyTelTitle2 = value;}
        //		}
        //
        //		/// public propaty name  :  CompanyTelTitle3
        //		/// <summary>自社電話番号タイトル3プロパティ</summary>
        //		/// ----------------------------------------------------------------------
        //		/// <remarks>
        //		/// <br>note             :   自社電話番号タイトル3プロパティ</br>
        //		/// <br>Programer        :   自動生成</br>
        //		/// </remarks>
        //		public string CompanyTelTitle3
        //		{
        //			get{return _companyTelTitle3;}
        //			set{_companyTelTitle3 = value;}
        //		}
        //
        //		/// public propaty name  :  TransferGuidance
        //		/// <summary>銀行振込案内文プロパティ</summary>
        //		/// ----------------------------------------------------------------------
        //		/// <remarks>
        //		/// <br>note             :   銀行振込案内文プロパティ</br>
        //		/// <br>Programer        :   自動生成</br>
        //		/// </remarks>
        //		public string TransferGuidance
        //		{
        //			get{return _transferGuidance;}
        //			set{_transferGuidance = value;}
        //		}
        //
        //		/// public propaty name  :  AccountNoInfo1
        //		/// <summary>銀行口座1プロパティ</summary>
        //		/// ----------------------------------------------------------------------
        //		/// <remarks>
        //		/// <br>note             :   銀行口座1プロパティ</br>
        //		/// <br>Programer        :   自動生成</br>
        //		/// </remarks>
        //		public string AccountNoInfo1
        //		{
        //			get{return _accountNoInfo1;}
        //			set{_accountNoInfo1 = value;}
        //		}
        //
        //		/// public propaty name  :  AccountNoInfo2
        //		/// <summary>銀行口座2プロパティ</summary>
        //		/// ----------------------------------------------------------------------
        //		/// <remarks>
        //		/// <br>note             :   銀行口座2プロパティ</br>
        //		/// <br>Programer        :   自動生成</br>
        //		/// </remarks>
        //		public string AccountNoInfo2
        //		{
        //			get{return _accountNoInfo2;}
        //			set{_accountNoInfo2 = value;}
        //		}
        //
        //		/// public propaty name  :  AccountNoInfo3
        //		/// <summary>銀行口座3プロパティ</summary>
        //		/// ----------------------------------------------------------------------
        //		/// <remarks>
        //		/// <br>note             :   銀行口座3プロパティ</br>
        //		/// <br>Programer        :   自動生成</br>
        //		/// </remarks>
        //		public string AccountNoInfo3
        //		{
        //			get{return _accountNoInfo3;}
        //			set{_accountNoInfo3 = value;}
        //		}
        //
        //		/// public propaty name  :  CompanySetNote1
        //		/// <summary>自社設定摘要1プロパティ</summary>
        //		/// ----------------------------------------------------------------------
        //		/// <remarks>
        //		/// <br>note             :   自社設定摘要1プロパティ</br>
        //		/// <br>Programer        :   自動生成</br>
        //		/// </remarks>
        //		public string CompanySetNote1
        //		{
        //			get{return _companySetNote1;}
        //			set{_companySetNote1 = value;}
        //		}
        //
        //		/// public propaty name  :  CompanySetNote2
        //		/// <summary>自社設定摘要2プロパティ</summary>
        //		/// ----------------------------------------------------------------------
        //		/// <remarks>
        //		/// <br>note             :   自社設定摘要2プロパティ</br>
        //		/// <br>Programer        :   自動生成</br>
        //		/// </remarks>
        //		public string CompanySetNote2
        //		{
        //			get{return _companySetNote2;}
        //			set{_companySetNote2 = value;}
        //		}
        //
        //		/// public propaty name  :  SlipCompanyNmCd
        //		/// <summary>伝票自社名印刷区分プロパティ</summary>
        //		/// <value>0:拠点設定,1:自社設定</value>
        //		/// ----------------------------------------------------------------------
        //		/// <remarks>
        //		/// <br>note             :   伝票自社名印刷区分プロパティ</br>
        //		/// <br>Programer        :   自動生成</br>
        //		/// </remarks>
        //		public Int32 SlipCompanyNmCd
        //		{
        //			get{return _slipCompanyNmCd;}
        //			set{_slipCompanyNmCd = value;}
        //		}
        // 2005.09.13 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////

        /* --- DEL 2008/06/03 --------------------------------------------------------------------->>>>>
        /// public propaty name  :  OthrSlipCompanyNmCd
        /// <summary>他拠点伝票自社印刷区分プロパティ</summary>
        /// <value>0:他拠点情報,1:自拠点情報　※１</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   他拠点伝票自社印刷区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 OthrSlipCompanyNmCd
        {
            get { return _othrSlipCompanyNmCd; }
            set { _othrSlipCompanyNmCd = value; }
        }
         *    --- DEL 2008/06/03 ---------------------------------------------------------------------<<<<<*/

        /// public propaty name  :  SectionGuideNm
        /// <summary>拠点ガイド名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点ガイド名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SectionGuideNm
        {
            get { return _sectionGuideNm; }
            set { _sectionGuideNm = value; }
        }

        /// public propaty name  :  MainOfficeFuncFlag
        /// <summary>本社機能フラグプロパティ</summary>
        /// <value>0:拠点 1:本社</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   本社機能フラグプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 MainOfficeFuncFlag
        {
            get { return _mainOfficeFuncFlag; }
            set { _mainOfficeFuncFlag = value; }
        }

        ///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA DEL STA //
        //		/// public propaty name  :  BillCompanyNmPrtCd
        //		/// <summary>請求書自社名印刷区分プロパティ</summary>
        //		/// <value>0:拠点設定,1:自社設定</value>
        //		/// ----------------------------------------------------------------------
        //		/// <remarks>
        //		/// <br>note             :   請求書自社名印刷区分プロパティ</br>
        //		/// <br>Programer        :   自動生成</br>
        //		/// </remarks>
        //		public Int32 BillCompanyNmPrtCd
        //		{
        //			get{return _billCompanyNmPrtCd;}
        //			set{_billCompanyNmPrtCd = value;}
        //		}
        // 2005.09.13 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////

        ///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA ADD STA //

        /* --- DEL 2008/06/03 --------------------------------------------------------------------->>>>>
        /// public propaty name  :  SecCdForNumbering
        /// <summary>拠点コード（番号採番用）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点コード（番号採番用）プロパティ</br>
        /// <br>Programmer       :   23001 秋山　亮介</br>
        /// <br>Date             :   2005.09.13</br>
        /// </remarks>
        public string SecCdForNumbering
        {
            get { return _secCdForNumbering; }
            set { _secCdForNumbering = value; }
        }
           --- DEL 2008/06/03 ---------------------------------------------------------------------<<<<<*/

        /// public propary name  :  CompanyNameCd1
        /// <summary>自社名称コード1プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社名称コード1プロパティ</br>
        /// <br>Programmer       :   23001 秋山　亮介</br>
        /// <br>Date             :   2005.09.13</br>
        /// </remarks>
        public int CompanyNameCd1
        {
            get { return _companyNameCd1; }
            set { _companyNameCd1 = value; }
        }

        /* --- DEL 2008/06/03 --------------------------------------------------------------------->>>>>
        /// public propary name  :  CompanyNameCd2
        /// <summary>自社名称コード2プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社名称コード2プロパティ</br>
        /// <br>Programmer       :   23001 秋山　亮介</br>
        /// <br>Date             :   2005.09.13</br>
        /// </remarks>
        public int CompanyNameCd2
        {
            get { return _companyNameCd2; }
            set { _companyNameCd2 = value; }
        }

        /// public propary name  :  CompanyNameCd3
        /// <summary>自社名称コード3プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社名称コード3プロパティ</br>
        /// <br>Programmer       :   23001 秋山　亮介</br>
        /// <br>Date             :   2005.09.13</br>
        /// </remarks>
        public int CompanyNameCd3
        {
            get { return _companyNameCd3; }
            set { _companyNameCd3 = value; }
        }

        /// public propary name  :  CompanyNameCd4
        /// <summary>自社名称コード4プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社名称コード4プロパティ</br>
        /// <br>Programmer       :   23001 秋山　亮介</br>
        /// <br>Date             :   2005.09.13</br>
        /// </remarks>
        public int CompanyNameCd4
        {
            get { return _companyNameCd4; }
            set { _companyNameCd4 = value; }
        }

        /// public propary name  :  CompanyNameCd5
        /// <summary>自社名称コード5プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社名称コード5プロパティ</br>
        /// <br>Programmer       :   23001 秋山　亮介</br>
        /// <br>Date             :   2005.09.13</br>
        /// </remarks>
        public int CompanyNameCd5
        {
            get { return _companyNameCd5; }
            set { _companyNameCd5 = value; }
        }

        /// public propary name  :  CompanyNameCd6
        /// <summary>自社名称コード6プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社名称コード6プロパティ</br>
        /// <br>Programmer       :   23001 秋山　亮介</br>
        /// <br>Date             :   2005.09.13</br>
        /// </remarks>
        public int CompanyNameCd6
        {
            get { return _companyNameCd6; }
            set { _companyNameCd6 = value; }
        }

        /// public propary name  :  CompanyNameCd7
        /// <summary>自社名称コード7プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社名称コード7プロパティ</br>
        /// <br>Programmer       :   23001 秋山　亮介</br>
        /// <br>Date             :   2005.09.13</br>
        /// </remarks>
        public int CompanyNameCd7
        {
            get { return _companyNameCd7; }
            set { _companyNameCd7 = value; }
        }

        /// public propary name  :  CompanyNameCd8
        /// <summary>自社名称コード8プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社名称コード8プロパティ</br>
        /// <br>Programmer       :   23001 秋山　亮介</br>
        /// <br>Date             :   2005.09.13</br>
        /// </remarks>
        public int CompanyNameCd8
        {
            get { return _companyNameCd8; }
            set { _companyNameCd8 = value; }
        }

        /// public propary name  :  CompanyNameCd9
        /// <summary>自社名称コード9プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社名称コード9プロパティ</br>
        /// <br>Programmer       :   23001 秋山　亮介</br>
        /// <br>Date             :   2005.09.13</br>
        /// </remarks>
        public int CompanyNameCd9
        {
            get { return _companyNameCd9; }
            set { _companyNameCd9 = value; }
        }

        /// public propary name  :  CompanyNameCd10
        /// <summary>自社名称コード10プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社名称コード10プロパティ</br>
        /// <br>Programmer       :   23001 秋山　亮介</br>
        /// <br>Date             :   2005.09.13</br>
        /// </remarks>
        public int CompanyNameCd10
        {
            get { return _companyNameCd10; }
            set { _companyNameCd10 = value; }
        }
           --- DEL 2008/06/03 ---------------------------------------------------------------------<<<<<*/

        /// public propary name  :  CompanyName1
        /// <summary>自社名称1プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社名称1プロパティ</br>
        /// <br>Programmer       :   23001 秋山　亮介</br>
        /// <br>Date             :   2005.09.13</br>
        /// </remarks>
        public string CompanyName1
        {
            get { return _companyName1; }
            set { _companyName1 = value; }
        }

        /* --- DEL 2008/06/03 --------------------------------------------------------------------->>>>>
        /// public propary name  :  CompanyName2
        /// <summary>自社名称2プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社名称2プロパティ</br>
        /// <br>Programmer       :   23001 秋山　亮介</br>
        /// <br>Date             :   2005.09.13</br>
        /// </remarks>
        public string CompanyName2
        {
            get { return _companyName2; }
            set { _companyName2 = value; }
        }

        /// public propary name  :  CompanyName3
        /// <summary>自社名称3プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社名称3プロパティ</br>
        /// <br>Programmer       :   23001 秋山　亮介</br>
        /// <br>Date             :   2005.09.13</br>
        /// </remarks>
        public string CompanyName3
        {
            get { return _companyName3; }
            set { _companyName3 = value; }
        }

        /// public propary name  :  CompanyName4
        /// <summary>自社名称4プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社名称4プロパティ</br>
        /// <br>Programmer       :   23001 秋山　亮介</br>
        /// <br>Date             :   2005.09.13</br>
        /// </remarks>
        public string CompanyName4
        {
            get { return _companyName4; }
            set { _companyName4 = value; }
        }

        /// public propary name  :  CompanyName5
        /// <summary>自社名称5プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社名称5プロパティ</br>
        /// <br>Programmer       :   23001 秋山　亮介</br>
        /// <br>Date             :   2005.09.13</br>
        /// </remarks>
        public string CompanyName5
        {
            get { return _companyName5; }
            set { _companyName5 = value; }
        }

        /// public propary name  :  CompanyName6
        /// <summary>自社名称6プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社名称6プロパティ</br>
        /// <br>Programmer       :   23001 秋山　亮介</br>
        /// <br>Date             :   2005.09.13</br>
        /// </remarks>
        public string CompanyName6
        {
            get { return _companyName6; }
            set { _companyName6 = value; }
        }

        /// public propary name  :  CompanyName7
        /// <summary>自社名称7プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社名称7プロパティ</br>
        /// <br>Programmer       :   23001 秋山　亮介</br>
        /// <br>Date             :   2005.09.13</br>
        /// </remarks>
        public string CompanyName7
        {
            get { return _companyName7; }
            set { _companyName7 = value; }
        }

        /// public propary name  :  CompanyName8
        /// <summary>自社名称8プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社名称8プロパティ</br>
        /// <br>Programmer       :   23001 秋山　亮介</br>
        /// <br>Date             :   2005.09.13</br>
        /// </remarks>
        public string CompanyName8
        {
            get { return _companyName8; }
            set { _companyName8 = value; }
        }

        /// public propary name  :  CompanyName9
        /// <summary>自社名称9プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社名称9プロパティ</br>
        /// <br>Programmer       :   23001 秋山　亮介</br>
        /// <br>Date             :   2005.09.13</br>
        /// </remarks>
        public string CompanyName9
        {
            get { return _companyName9; }
            set { _companyName9 = value; }
        }

        /// public propary name  :  CompanyName10
        /// <summary>自社名称10プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社名称10プロパティ</br>
        /// <br>Programmer       :   23001 秋山　亮介</br>
        /// <br>Date             :   2005.09.13</br>
        /// </remarks>
        public string CompanyName10
        {
            get { return _companyName10; }
            set { _companyName10 = value; }
        }
         *    --- DEL 2008/06/03 ---------------------------------------------------------------------<<<<<*/

        // ↓ 2007.10.5 add////////////////////////////////////////////////////////
        /// public propary name  :  SectWarehouseCd1
        /// <summary>拠点倉庫コード1プロパティ</summary>
        /// ----------------------------------------------------------------------
        public string SectWarehouseCd1
        {
            get { return _sectWarehouseCd1; }
            set { _sectWarehouseCd1 = value; }
        }

        /// public propary name  :  SectWarehouseCd2
        /// <summary>拠点倉庫コード2プロパティ</summary>
        /// ----------------------------------------------------------------------
        public string SectWarehouseCd2
        {
            get { return _sectWarehouseCd2; }
            set { _sectWarehouseCd2 = value; }
        }

        /// public propary name  :  SectWarehouseCd3
        /// <summary>拠点倉庫コード3プロパティ</summary>
        /// ----------------------------------------------------------------------
        public string SectWarehouseCd3
        {
            get { return _sectWarehouseCd3; }
            set { _sectWarehouseCd3 = value; }
        }

        /// public propary name  :  SectWarehouseNm1
        /// <summary>拠点倉庫名称1プロパティ</summary>
        /// ----------------------------------------------------------------------
        public string SectWarehouseNm1
        {
            get { return _sectWarehouseNm1; }
            set { _sectWarehouseNm1 = value; }
        }

        /// public propary name  :  SectWarehouseNm2
        /// <summary>拠点倉庫名称2プロパティ</summary>
        /// ----------------------------------------------------------------------
        public string SectWarehouseNm2
        {
            get { return _sectWarehouseNm2; }
            set { _sectWarehouseNm2 = value; }
        }

        /// public propary name  :  SectWarehouseNm3
        /// <summary>拠点倉庫名称3プロパティ</summary>
        /// ----------------------------------------------------------------------
        public string SectWarehouseNm3
        {
            get { return _sectWarehouseNm3; }
            set { _sectWarehouseNm3 = value; }
        }
        // ↑ 2007.10.5 add////////////////////////////////////////////////////////

        // 2005.09.13 AKIYAMA ADD END /////////////////////////////////////////////////////////////////////

        /// public propaty name  :  UpdEmployeeName
        /// <summary>更新従業員名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新従業員名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UpdEmployeeName
        {
            get { return _updEmployeeName; }
            set { _updEmployeeName = value; }
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

        ///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA ADD STA //
        /* --- DEL 2008/06/03 --------------------------------------------------------------------->>>>>
        /// public propaty name  :  OthrSlipCompanyNm
        /// <summary>他拠点伝票自社印刷区分名称プロパティ</summary>
        /// <value>0:他拠点情報,1:自拠点情報　※１</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   他拠点伝票自社印刷区分名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string OthrSlipCompanyNm
        {
            get { return GetOthrSlipCompanyNm(this._othrSlipCompanyNmCd); }
        }
           --- DEL 2008/06/03 ---------------------------------------------------------------------<<<<<*/

        /// public propaty name  :  MainOfficeFuncFlagName
        /// <summary>本社機能フラグ名称プロパティ</summary>
        /// <value>0:拠点 1:本社</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   本社機能フラグ名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MainOfficeFuncFlagName
        {
            get { return GetMainOfficeFuncFlagName(this._mainOfficeFuncFlag); }
        }

        /// <summary>他拠点伝票自社印刷区分 0: 他拠点情報</summary>
        public const int CONSTOTHRSLIPCOMPANYNMCD_OTHER = 0;
        /// <summary>他拠点伝票自社印刷区分 0: 自拠点情報</summary>
        public const int CONSTOTHRSLIPCOMPANYNMCD_SELF = 1;
        /// <summary>
        /// 他拠点伝票自社印刷区分名称取得
        /// </summary>
        /// <param name="othrSlipCompanyNmCd">他拠点伝票自社印刷区分</param>
        /// <returns>他拠点伝票自社印刷区分名称</returns>
        /// <remarks>
        /// <br>Note       : 他拠点伝票自社印刷区分から他拠点伝票自社印刷区分名称を取得します</br>
        /// <br>Programmer : 23001 秋山　亮介</br>
        /// <br>Date       : 2005.09.13</br>
        /// </remarks>
        public string GetOthrSlipCompanyNm(int othrSlipCompanyNmCd)
        {
            switch (othrSlipCompanyNmCd)
            {
                case CONSTOTHRSLIPCOMPANYNMCD_OTHER:
                    return "他拠点情報";
                case CONSTOTHRSLIPCOMPANYNMCD_SELF:
                    return "自拠点情報";
                default:
                    return "未設定";
            }
        }

        /// <summary>他拠点伝票自社印刷区分の種類</summary>
        static private int[] _othrSlipCompanyNmCds = { CONSTOTHRSLIPCOMPANYNMCD_OTHER, CONSTOTHRSLIPCOMPANYNMCD_SELF };
        /// <summary>他拠点伝票自社印刷区分の種類プロパティ</summary>
        /// <remarks>
        /// <br>Note       : 他拠点伝票自社印刷区分の種類プロパティ</br>
        /// <br>Programmer : 23001 秋山　亮介</br>
        /// <br>Date       : 2005.09.13</br>
        /// </remarks>
        static public int[] OthrSlipCompanyNmCds
        {
            get
            {
                return _othrSlipCompanyNmCds;
            }
        }

        /// <summary>本社機能フラグ 0: 拠点</summary>
        public const int CONSTMAINOFFICEFUNCFLAG_OTHER = 0;
        /// <summary>本社機能フラグ 1: 本社</summary>
        public const int CONSTMAINOFFICEFUNCFLAG_MAIN = 1;
        /// <summary>
        /// 本社機能フラグ名称取得
        /// </summary>
        /// <param name="mainOfficeFuncFlag">本社機能フラグ</param>
        /// <returns>本社機能フラグ名称</returns>
        /// <remarks>
        /// <br>Note       : 本社機能フラグから本社機能フラグ名称を取得します</br>
        /// <br>Programmer : 23001 秋山　亮介</br>
        /// <br>Date       : 2005.09.13</br>
        /// </remarks>
        public string GetMainOfficeFuncFlagName(int mainOfficeFuncFlag)
        {
            switch (mainOfficeFuncFlag)
            {
                case CONSTMAINOFFICEFUNCFLAG_OTHER:
                    return "拠点";
                case CONSTMAINOFFICEFUNCFLAG_MAIN:
                    return "本社";
                default:
                    return "未設定";
            }
        }

        /// <summary>本社機能フラグの種類</summary>
        static private int[] _mainOfficeFuncFlags = { CONSTMAINOFFICEFUNCFLAG_OTHER, CONSTMAINOFFICEFUNCFLAG_MAIN };
        /// <summary>本社機能フラグの種類プロパティ</summary>
        /// <remarks>
        /// <br>Note       : 本社機能フラグの種類プロパティ</br>
        /// <br>Programmer : 23001 秋山　亮介</br>
        /// <br>Date       : 2005.09.13</br>
        /// </remarks>
        static public int[] MainOfficeFuncFlags
        {
            get
            {
                return _mainOfficeFuncFlags;
            }
        }

        // 2005.09.13 AKIYAMA ADD END /////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA DEL STA //
        //		/// public propaty name  :  SlipCompanyNm
        //		/// <summary>伝票自社名印刷区分名称プロパティ</summary>
        //		/// ----------------------------------------------------------------------
        //		/// <remarks>
        //		/// <br>note             :   伝票自社名印刷区分名称プロパティ</br>
        //		/// <br>Programer        :   96219 椿原　義樹</br>
        //		/// <br>Date             :   2005/3/31</br>
        //		/// </remarks>
        //		public string SlipCompanyNm
        //		{
        //			get{return _slipCompanyNm;}
        //			set{_slipCompanyNm = value;}
        //		}
        //
        //		/// public propaty name  :  OthrSlipCompanyNm
        //		/// <summary>他拠点伝票自社印刷区分名称プロパティ</summary>
        //		/// ----------------------------------------------------------------------
        //		/// <remarks>
        //		/// <br>note             :   他拠点伝票自社印刷区分名称プロパティ</br>
        //		/// <br>Programer        :   96219 椿原　義樹</br>
        //		/// <br>Date             :   2005/3/31</br>
        //		/// </remarks>
        //		public string OthrSlipCompanyNm
        //		{
        //			get{return _othrSlipCompanyNm;}
        //			set{_othrSlipCompanyNm = value;}
        //		}
        //
        //		/// public propaty name  :  MainOfficeFuncNm
        //		/// <summary>本社機能フラグ名称プロパティ</summary>
        //		/// ----------------------------------------------------------------------
        //		/// <remarks>
        //		/// <br>note             :   本社機能フラグ名称プロパティ</br>
        //		/// <br>Programer        :   96219 椿原　義樹</br>
        //		/// <br>Date             :   2005/3/31</br>
        //		/// </remarks>
        //		public string MainOfficeFuncNm
        //		{
        //			get{return _mainOfficeFuncNm;}
        //			set{_mainOfficeFuncNm = value;}
        //		}
        //
        //		/// public propaty name  :  MainOfficeFuncNm
        //		/// <summary>請求書自社名印刷区分名称プロパティ</summary>
        //		/// ----------------------------------------------------------------------
        //		/// <remarks>
        //		/// <br>note             :   請求書自社名印刷区分名称プロパティ</br>
        //		/// <br>Programer        :   96219 椿原　義樹</br>
        //		/// <br>Date             :   2005/3/31</br>
        //		/// </remarks>
        //		public string BillCompanyNmPrtNm
        //		{
        //			get{return _billCompanyNmPrtNm;}
        //			set{_billCompanyNmPrtNm = value;}
        //		}
        // 2005.09.13 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////

        // --- ADD 2008/06/03 --------------------------------------------------------------------->>>>>
        /// public property name  :  SectionGuideSnm
        /// <summary>拠点略称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点略称プロパティ</br>
        /// <br>Programer        :   忍　幸史</br>
        /// </remarks>
        public string SectionGuideSnm
        {
            get { return _sectionGuideSnm; }
            set { _sectionGuideSnm = value; }
        }

        /// public property name  :  IntroductionDate
        /// <summary>導入年月日プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   導入年月日プロパティ</br>
        /// <br>Programer        :   忍　幸史</br>
        /// </remarks>
        public DateTime IntroductionDate
        {
            get { return _introductionDate; }
            set { _introductionDate = value; }
        }
        // --- ADD 2008/06/03 ---------------------------------------------------------------------<<<<<

        /// <summary>
        /// 拠点情報設定クラスコンストラクタ
        /// </summary>
        /// <returns>SecInfoSetクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SecInfoSetクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SecInfoSet()
        {
        }

        /// <summary>
        /// 拠点情報設定クラスコンストラクタ
        /// </summary>
        /// <param name="createDateTime">作成日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="updateDateTime">更新日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
        /// <param name="fileHeaderGuid">GUID(共通ファイルヘッダ)</param>
        /// <param name="updEmployeeCode">更新従業員コード(共通ファイルヘッダ)</param>
        /// <param name="updAssemblyId1">更新アセンブリID1(共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）)</param>
        /// <param name="updAssemblyId2">更新アセンブリID2(共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）)</param>
        /// <param name="logicalDeleteCode">論理削除区分(共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除))</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="sectionGuideNm">拠点ガイド名称</param>
        /// <param name="mainOfficeFuncFlag">本社機能フラグ(0:拠点 1:本社)</param>
        /// <param name="companyNameCd1">自社名称コード1(整備システムで使用する自社名称コード)</param>
        /// <param name="companyName1">自社名称1(整備システムで使用する自社名称)</param>
        /// <param name="updEmployeeName">更新従業員名称</param>
        /// <param name="enterpriseName">企業名称</param>
        /// <param name="sectWarehouseCd1">拠点倉庫コード1</param>
        /// <param name="sectWarehouseCd2">拠点倉庫コード2</param>
        /// <param name="sectWarehouseCd3">拠点倉庫コード3</param>        
        /// <param name="sectWarehouseNm1">拠点倉庫名称1</param>
        /// <param name="sectWarehouseNm2">拠点倉庫名称2</param>
        /// <param name="sectWarehouseNm3">拠点倉庫名称3</param>
        /// <param name="sectionGuideSnm">拠点略称</param>
        /// <param name="introductionDate">導入年月日</param>
        /// <returns>SecInfoSetクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SecInfoSetクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        /* --- DEL 2008/06/03 --------------------------------------------------------------------->>>>>
        //public SecInfoSet(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, string sectionCode, Int32 othrSlipCompanyNmCd, string sectionGuideNm, Int32 mainOfficeFuncFlag, string secCdForNumbering, Int32 companyNameCd1, Int32 companyNameCd2, Int32 companyNameCd3, Int32 companyNameCd4, Int32 companyNameCd5, Int32 companyNameCd6, Int32 companyNameCd7, Int32 companyNameCd8, Int32 companyNameCd9, Int32 companyNameCd10, string companyName1, string companyName2, string companyName3, string companyName4, string companyName5, string companyName6, string companyName7, string companyName8, string companyName9, string companyName10, string sectWarehouseCd1, string sectWarehouseCd2, string sectWarehouseCd3, string sectWarehouseNm1, string sectWarehouseNm2, string sectWarehouseNm3, string updEmployeeName, string enterpriseName)
           --- DEL 2008/06/03 ---------------------------------------------------------------------<<<<<*/
        public SecInfoSet(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, string sectionCode, string sectionGuideNm, Int32 mainOfficeFuncFlag, Int32 companyNameCd1, string companyName1, string sectWarehouseCd1, string sectWarehouseCd2, string sectWarehouseCd3, string sectWarehouseNm1, string sectWarehouseNm2, string sectWarehouseNm3, string updEmployeeName, string enterpriseName, string sectionGuideSnm, DateTime introductionDate)
        {
            this.CreateDateTime = createDateTime;
            this.UpdateDateTime = updateDateTime;
            this._enterpriseCode = enterpriseCode;
            this._fileHeaderGuid = fileHeaderGuid;
            this._updEmployeeCode = updEmployeeCode;
            this._updAssemblyId1 = updAssemblyId1;
            this._updAssemblyId2 = updAssemblyId2;
            this._logicalDeleteCode = logicalDeleteCode;
            this._sectionCode = sectionCode;

            ///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA DEL STA //
            //			this._companyPr = companyPr;
            //			this._companyName1 = companyName1;
            //			this._companyName2 = companyName2;
            //			this._postNo = postNo;
            //			this._address1 = address1;
            //			this._address2 = address2;
            //			this._address3 = address3;
            //			this._address4 = address4;
            //			this._companyTelNo1 = companyTelNo1;
            //			this._companyTelNo2 = companyTelNo2;
            //			this._companyTelNo3 = companyTelNo3;
            //			this._companyTelTitle1 = companyTelTitle1;
            //			this._companyTelTitle2 = companyTelTitle2;
            //			this._companyTelTitle3 = companyTelTitle3;
            //			this._transferGuidance = transferGuidance;
            //			this._accountNoInfo1 = accountNoInfo1;
            //			this._accountNoInfo2 = accountNoInfo2;
            //			this._accountNoInfo3 = accountNoInfo3;
            //			this._companySetNote1 = companySetNote1;
            //			this._companySetNote2 = companySetNote2;
            //			this._slipCompanyNmCd = slipCompanyNmCd;
            // 2005.09.13 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////

            /* --- DEL 2008/06/03 --------------------------------------------------------------------->>>>>
            this._othrSlipCompanyNmCd = othrSlipCompanyNmCd;
               --- DEL 2008/06/03 ---------------------------------------------------------------------<<<<<*/

            this._sectionGuideNm = sectionGuideNm;
            this._mainOfficeFuncFlag = mainOfficeFuncFlag;

            ///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA DEL STA //
            //			this._billCompanyNmPrtCd = billCompanyNmPrtCd;
            // 2005.09.13 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////

            ///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA ADD STA //
            //this._secCdForNumbering = secCdForNumbering;  // DEL 2008/06/03
            this._companyNameCd1 = companyNameCd1;
            /* --- DEL 2008/06/03 --------------------------------------------------------------------->>>>>
            this._companyNameCd2 = companyNameCd2;
            this._companyNameCd3 = companyNameCd3;
            this._companyNameCd4 = companyNameCd4;
            this._companyNameCd5 = companyNameCd5;
            this._companyNameCd6 = companyNameCd6;
            this._companyNameCd7 = companyNameCd7;
            this._companyNameCd8 = companyNameCd8;
            this._companyNameCd9 = companyNameCd9;
            this._companyNameCd10 = companyNameCd10;
             *    --- DEL 2008/06/03 ---------------------------------------------------------------------<<<<<*/
            this._companyName1 = companyName1;
            /* --- DEL 2008/06/03 --------------------------------------------------------------------->>>>>
            this._companyName2 = companyName2;
            this._companyName3 = companyName3;
            this._companyName4 = companyName4;
            this._companyName5 = companyName5;
            this._companyName6 = companyName6;
            this._companyName7 = companyName7;
            this._companyName8 = companyName8;
            this._companyName9 = companyName9;
            this._companyName10 = companyName10;
               --- DEL 2008/06/03 ---------------------------------------------------------------------<<<<<*/

            // ↓ 2007.10.5 add///////////////////////
            this._sectWarehouseCd1 = sectWarehouseCd1;
            this._sectWarehouseCd2 = sectWarehouseCd2;
            this._sectWarehouseCd3 = sectWarehouseCd3;
            this._sectWarehouseNm1 = sectWarehouseNm1;
            this._sectWarehouseNm2 = sectWarehouseNm2;
            this._sectWarehouseNm3 = sectWarehouseNm3;
            // ↑ 2007.10.5 add///////////////////////

            // 2005.09.13 AKIYAMA ADD END /////////////////////////////////////////////////////////////////////

            this._updEmployeeName = updEmployeeName;
            this._enterpriseName = enterpriseName;

            ///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA DEL STA //
            //			this._slipCompanyNm = slipCompanyNm;
            //			this._othrSlipCompanyNm = othrSlipCompanyNm;
            //			this._mainOfficeFuncNm = mainOfficeFuncNm;
            //			this._billCompanyNmPrtNm = billCompanyNmPrtNm;
            // 2005.09.13 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////

            // --- ADD 2008/06/03 --------------------------------------------------------------------->>>>>
            this._sectionGuideSnm = sectionGuideSnm;
            this._introductionDate = introductionDate;
            // --- ADD 2008/06/03 ---------------------------------------------------------------------<<<<<
        }

        /// <summary>
        /// 拠点情報設定クラス複製処理
        /// </summary>
        /// <returns>SecInfoSetクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいSecInfoSetクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SecInfoSet Clone()
        {
            /* --- DEL 2008/06/03 --------------------------------------------------------------------->>>>>
            // ↓ 2007.10.5 add//
            return new SecInfoSet(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._sectionCode, this._othrSlipCompanyNmCd, this._sectionGuideNm, this._mainOfficeFuncFlag, this._secCdForNumbering, this._companyNameCd1, this._companyNameCd2, this._companyNameCd3, this._companyNameCd4, this._companyNameCd5, this._companyNameCd6, this._companyNameCd7, this._companyNameCd8, this._companyNameCd9, this._companyNameCd10, this._companyName1, this._companyName2, this._companyName3, this._companyName4, this._companyName5, this._companyName6, this._companyName7, this._companyName8, this._companyName9, this._companyName10, this._sectWarehouseCd1, this._sectWarehouseCd2, this._sectWarehouseCd3, this._sectWarehouseNm1, this._sectWarehouseNm2, this._sectWarehouseNm3, this._updEmployeeName, this._enterpriseName);
            // ↑ 2007.10.5 add//
               --- DEL 2008/06/03 ---------------------------------------------------------------------<<<<<*/

            // --- ADD 2008/06/03 --------------------------------------------------------------------->>>>>
            return new SecInfoSet(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._sectionCode, this._sectionGuideNm, this._mainOfficeFuncFlag, this._companyNameCd1, this._companyName1, this._sectWarehouseCd1, this._sectWarehouseCd2, this._sectWarehouseCd3, this._sectWarehouseNm1, this._sectWarehouseNm2, this._sectWarehouseNm3, this._updEmployeeName, this._enterpriseName, this._sectionGuideSnm, this._introductionDate);
            // --- ADD 2008/06/03 ---------------------------------------------------------------------<<<<<

            // ↓ 2007.9.26 delete
            ///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA ADD STA //
            //          return new SecInfoSet(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._sectionCode, this._othrSlipCompanyNmCd, this._sectionGuideNm, this._mainOfficeFuncFlag, this._secCdForNumbering, this._companyNameCd1, this._companyNameCd2, this._companyNameCd3, this._companyNameCd4, this._companyNameCd5, this._companyNameCd6, this._companyNameCd7, this._companyNameCd8, this._companyNameCd9, this._companyNameCd10, this._companyName1, this._companyName2, this._companyName3, this._companyName4, this._companyName5, this._companyName6, this._companyName7, this._companyName8, this._companyName9, this._companyName10, this._updEmployeeName, this._enterpriseName);
            // 2005.09.13 AKIYAMA ADD END /////////////////////////////////////////////////////////////////////
            // ↑ 2007.9.26 delete

            ///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA DEL STA //
            //			return new SecInfoSet(this._createDateTime,this._updateDateTime,this._enterpriseCode,this._fileHeaderGuid,this._updEmployeeCode,this._updAssemblyId1,this._updAssemblyId2,this._logicalDeleteCode,this._sectionCode,this._companyPr,this._companyName1,this._companyName2,this._postNo,this._address1,this._address2,this._address3,this._address4,this._companyTelNo1,this._companyTelNo2,this._companyTelNo3,this._companyTelTitle1,this._companyTelTitle2,this._companyTelTitle3,this._transferGuidance,this._accountNoInfo1,this._accountNoInfo2,this._accountNoInfo3,this._companySetNote1,this._companySetNote2,this._slipCompanyNmCd,this._othrSlipCompanyNmCd,this._sectionGuideNm,this._mainOfficeFuncFlag,this._billCompanyNmPrtCd,this._updEmployeeName,this._enterpriseName,this._slipCompanyNm,this._othrSlipCompanyNm,this._mainOfficeFuncNm,this._billCompanyNmPrtNm);
            // 2005.09.13 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////
        }

        /// <summary>
        /// 拠点情報設定クラス比較処理
        /// </summary>
        /// <param name="target">比較対象のSecInfoSetクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SecInfoSetクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool Equals(SecInfoSet target)
        {
            return ((this.CreateDateTime == target.CreateDateTime)
                 && (this.UpdateDateTime == target.UpdateDateTime)
                 && (this.EnterpriseCode == target.EnterpriseCode)
                 && (this.FileHeaderGuid == target.FileHeaderGuid)
                 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
                 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
                 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
                 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
                 && (this.SectionCode == target.SectionCode)

///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA DEL STA //
                //				 && (this.CompanyPr == target.CompanyPr)
                //				 && (this.CompanyName1 == target.CompanyName1)
                //				 && (this.CompanyName2 == target.CompanyName2)
                //				 && (this.PostNo == target.PostNo)
                //				 && (this.Address1 == target.Address1)
                //				 && (this.Address2 == target.Address2)
                //				 && (this.Address3 == target.Address3)
                //				 && (this.Address4 == target.Address4)
                //				 && (this.CompanyTelNo1 == target.CompanyTelNo1)
                //				 && (this.CompanyTelNo2 == target.CompanyTelNo2)
                //				 && (this.CompanyTelNo3 == target.CompanyTelNo3)
                //				 && (this.CompanyTelTitle1 == target.CompanyTelTitle1)
                //				 && (this.CompanyTelTitle2 == target.CompanyTelTitle2)
                //				 && (this.CompanyTelTitle3 == target.CompanyTelTitle3)
                //				 && (this.TransferGuidance == target.TransferGuidance)
                //				 && (this.AccountNoInfo1 == target.AccountNoInfo1)
                //				 && (this.AccountNoInfo2 == target.AccountNoInfo2)
                //				 && (this.AccountNoInfo3 == target.AccountNoInfo3)
                //				 && (this.CompanySetNote1 == target.CompanySetNote1)
                //				 && (this.CompanySetNote2 == target.CompanySetNote2)
                //				 && (this.SlipCompanyNmCd == target.SlipCompanyNmCd)
                // 2005.09.13 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////

                 //&& (this.OthrSlipCompanyNmCd == target.OthrSlipCompanyNmCd)  // DEL 2008/06/03
                 && (this.SectionGuideNm == target.SectionGuideNm)
                 && (this.MainOfficeFuncFlag == target.MainOfficeFuncFlag)

///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA DEL STA //
                //				 && (this.BillCompanyNmPrtCd == target.BillCompanyNmPrtCd)
                // 2005.09.13 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////

///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA ADD STA //
                //&& (this.SecCdForNumbering == target.SecCdForNumbering)  // DEL 2008/06/03
                 && (this.CompanyNameCd1 == target.CompanyNameCd1)
                /* --- DEL 2008/06/03 --------------------------------------------------------------------->>>>>
                && (this.CompanyNameCd2 == target.CompanyNameCd2)
                && (this.CompanyNameCd3 == target.CompanyNameCd3)
                && (this.CompanyNameCd4 == target.CompanyNameCd4)
                && (this.CompanyNameCd5 == target.CompanyNameCd5)
                && (this.CompanyNameCd6 == target.CompanyNameCd6)
                && (this.CompanyNameCd7 == target.CompanyNameCd7)
                && (this.CompanyNameCd8 == target.CompanyNameCd8)
                && (this.CompanyNameCd9 == target.CompanyNameCd9)
                && (this.CompanyNameCd10 == target.CompanyNameCd10)
                   --- DEL 2008/06/03 ---------------------------------------------------------------------<<<<<*/
                 && (this.CompanyName1 == target.CompanyName1)
                /* --- DEL 2008/06/03 --------------------------------------------------------------------->>>>>
                && (this.CompanyName2 == target.CompanyName2)
                && (this.CompanyName3 == target.CompanyName3)
                && (this.CompanyName4 == target.CompanyName4)
                && (this.CompanyName5 == target.CompanyName5)
                && (this.CompanyName6 == target.CompanyName6)
                && (this.CompanyName7 == target.CompanyName7)
                && (this.CompanyName8 == target.CompanyName8)
                && (this.CompanyName9 == target.CompanyName9)
                && (this.CompanyName10 == target.CompanyName10)
                   --- DEL 2008/06/03 ---------------------------------------------------------------------<<<<<*/
                // 2005.09.13 AKIYAMA ADD END /////////////////////////////////////////////////////////////////////

                 // ↓ 2007.10.5 add///////////////////////////////////
                 && (this.SectWarehouseCd1 == target.SectWarehouseCd1)
                 && (this.SectWarehouseCd2 == target.SectWarehouseCd2)
                 && (this.SectWarehouseCd3 == target.SectWarehouseCd3)

                 && (this.SectWarehouseNm1 == target.SectWarehouseNm1)
                 && (this.SectWarehouseNm2 == target.SectWarehouseNm2)
                 && (this.SectWarehouseNm3 == target.SectWarehouseNm3)
                //  ↑ 2007.10.5 add//////////////////////////////////

                 && (this.UpdEmployeeName == target.UpdEmployeeName)

                 // --- ADD 2008/06/03 --------------------------------------------------------------------->>>>>
                 && (this.SectionGuideSnm == target.SectionGuideSnm)
                 && (this.IntroductionDate == target.IntroductionDate)
                 // --- ADD 2008/06/03 ---------------------------------------------------------------------<<<<<

///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA ADD STA //
                 && (this.EnterpriseName == target.EnterpriseName));
            // 2005.09.13 AKIYAMA ADD END /////////////////////////////////////////////////////////////////////

            ///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA DEL STA //
            //				 && (this.EnterpriseName == target.EnterpriseName)
            //				 && (this.SlipCompanyNm == target.SlipCompanyNm)
            //				 && (this.OthrSlipCompanyNm == target.OthrSlipCompanyNm)
            //				 && (this.MainOfficeFuncNm == target.MainOfficeFuncNm)
            //				 && (this.BillCompanyNmPrtNm == target.BillCompanyNmPrtNm));
            // 2005.09.13 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////
        }

        /// <summary>
        /// 拠点情報設定クラス比較処理
        /// </summary>
        /// <param name="secinfoset1">
        ///                    比較するSecInfoSetクラスのインスタンス
        /// </param>
        /// <param name="secinfoset2">比較するSecInfoSetクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SecInfoSetクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static bool Equals(SecInfoSet secinfoset1, SecInfoSet secinfoset2)
        {
            return ((secinfoset1.CreateDateTime == secinfoset2.CreateDateTime)
                 && (secinfoset1.UpdateDateTime == secinfoset2.UpdateDateTime)
                 && (secinfoset1.EnterpriseCode == secinfoset2.EnterpriseCode)
                 && (secinfoset1.FileHeaderGuid == secinfoset2.FileHeaderGuid)
                 && (secinfoset1.UpdEmployeeCode == secinfoset2.UpdEmployeeCode)
                 && (secinfoset1.UpdAssemblyId1 == secinfoset2.UpdAssemblyId1)
                 && (secinfoset1.UpdAssemblyId2 == secinfoset2.UpdAssemblyId2)
                 && (secinfoset1.LogicalDeleteCode == secinfoset2.LogicalDeleteCode)
                 && (secinfoset1.SectionCode == secinfoset2.SectionCode)
                ///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA DEL STA //
                //				 && (secinfoset1.CompanyPr == secinfoset2.CompanyPr)
                //				 && (secinfoset1.CompanyName1 == secinfoset2.CompanyName1)
                //				 && (secinfoset1.CompanyName2 == secinfoset2.CompanyName2)
                //				 && (secinfoset1.PostNo == secinfoset2.PostNo)
                //				 && (secinfoset1.Address1 == secinfoset2.Address1)
                //				 && (secinfoset1.Address2 == secinfoset2.Address2)
                //				 && (secinfoset1.Address3 == secinfoset2.Address3)
                //				 && (secinfoset1.Address4 == secinfoset2.Address4)
                //				 && (secinfoset1.CompanyTelNo1 == secinfoset2.CompanyTelNo1)
                //				 && (secinfoset1.CompanyTelNo2 == secinfoset2.CompanyTelNo2)
                //				 && (secinfoset1.CompanyTelNo3 == secinfoset2.CompanyTelNo3)
                //				 && (secinfoset1.CompanyTelTitle1 == secinfoset2.CompanyTelTitle1)
                //				 && (secinfoset1.CompanyTelTitle2 == secinfoset2.CompanyTelTitle2)
                //				 && (secinfoset1.CompanyTelTitle3 == secinfoset2.CompanyTelTitle3)
                //				 && (secinfoset1.TransferGuidance == secinfoset2.TransferGuidance)
                //				 && (secinfoset1.AccountNoInfo1 == secinfoset2.AccountNoInfo1)
                //				 && (secinfoset1.AccountNoInfo2 == secinfoset2.AccountNoInfo2)
                //				 && (secinfoset1.AccountNoInfo3 == secinfoset2.AccountNoInfo3)
                //				 && (secinfoset1.CompanySetNote1 == secinfoset2.CompanySetNote1)
                //				 && (secinfoset1.CompanySetNote2 == secinfoset2.CompanySetNote2)
                //				 && (secinfoset1.SlipCompanyNmCd == secinfoset2.SlipCompanyNmCd)
                // 2005.09.13 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////

                 //&& (secinfoset1.OthrSlipCompanyNmCd == secinfoset2.OthrSlipCompanyNmCd)  // DEL 2008/06/03
                 && (secinfoset1.SectionGuideNm == secinfoset2.SectionGuideNm)
                 && (secinfoset1.MainOfficeFuncFlag == secinfoset2.MainOfficeFuncFlag)

///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA DEL STA //
                //				 && (secinfoset1.BillCompanyNmPrtCd == secinfoset2.BillCompanyNmPrtCd)
                // 2005.09.13 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////

///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA ADD STA //
                //&& (secinfoset1.SecCdForNumbering == secinfoset2.SecCdForNumbering)  // DEL 2008/06/03
                 && (secinfoset1.CompanyNameCd1 == secinfoset2.CompanyNameCd1)
                /* --- DEL 2008/06/03 --------------------------------------------------------------------->>>>>
                && (secinfoset1.CompanyNameCd2 == secinfoset2.CompanyNameCd2)
                && (secinfoset1.CompanyNameCd3 == secinfoset2.CompanyNameCd3)
                && (secinfoset1.CompanyNameCd4 == secinfoset2.CompanyNameCd4)
                && (secinfoset1.CompanyNameCd5 == secinfoset2.CompanyNameCd5)
                && (secinfoset1.CompanyNameCd6 == secinfoset2.CompanyNameCd6)
                && (secinfoset1.CompanyNameCd7 == secinfoset2.CompanyNameCd7)
                && (secinfoset1.CompanyNameCd8 == secinfoset2.CompanyNameCd8)
                && (secinfoset1.CompanyNameCd9 == secinfoset2.CompanyNameCd9)
                && (secinfoset1.CompanyNameCd10 == secinfoset2.CompanyNameCd10)
                   --- DEL 2008/06/03 ---------------------------------------------------------------------<<<<<*/
                 && (secinfoset1.CompanyName1 == secinfoset2.CompanyName1)
                /* --- DEL 2008/06/03 --------------------------------------------------------------------->>>>>
                && (secinfoset1.CompanyName2 == secinfoset2.CompanyName2)
                && (secinfoset1.CompanyName3 == secinfoset2.CompanyName3)
                && (secinfoset1.CompanyName4 == secinfoset2.CompanyName4)
                && (secinfoset1.CompanyName5 == secinfoset2.CompanyName5)
                && (secinfoset1.CompanyName6 == secinfoset2.CompanyName6)
                && (secinfoset1.CompanyName7 == secinfoset2.CompanyName7)
                && (secinfoset1.CompanyName8 == secinfoset2.CompanyName8)
                && (secinfoset1.CompanyName9 == secinfoset2.CompanyName9)
                && (secinfoset1.CompanyName10 == secinfoset2.CompanyName10)
                   --- DEL 2008/06/03 ---------------------------------------------------------------------<<<<<*/
                // 2005.09.13 AKIYAMA ADD END /////////////////////////////////////////////////////////////////////

                // ↓ 2007.10.5 add///////////////////////////////////////////////////
                 && (secinfoset1.SectWarehouseCd1 == secinfoset2.SectWarehouseCd1)
                 && (secinfoset1.SectWarehouseCd2 == secinfoset2.SectWarehouseCd2)
                 && (secinfoset1.SectWarehouseCd3 == secinfoset2.SectWarehouseCd3)
                 && (secinfoset1.SectWarehouseNm1 == secinfoset2.SectWarehouseNm1)
                 && (secinfoset1.SectWarehouseNm2 == secinfoset2.SectWarehouseNm2)
                 && (secinfoset1.SectWarehouseNm3 == secinfoset2.SectWarehouseNm3)
                // ↑ 2007.10.5 add///////////////////////////////////////////////////


                 && (secinfoset1.UpdEmployeeName == secinfoset2.UpdEmployeeName)

                 // --- ADD 2008/06/03 --------------------------------------------------------------------->>>>>
                 && (secinfoset1.SectionGuideSnm == secinfoset2.SectionGuideSnm)
                 && (secinfoset1.IntroductionDate == secinfoset2.IntroductionDate)
                 // --- ADD 2008/06/03 ---------------------------------------------------------------------<<<<<

///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA ADD STA //
                 && (secinfoset1.EnterpriseName == secinfoset2.EnterpriseName));
            // 2005.09.13 AKIYAMA ADD END /////////////////////////////////////////////////////////////////////

            ///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA DEL STA //
            //				 && (secinfoset1.EnterpriseName == secinfoset2.EnterpriseName)
            //				 && (secinfoset1.SlipCompanyNm == secinfoset2.SlipCompanyNm)
            //				 && (secinfoset1.OthrSlipCompanyNm == secinfoset2.OthrSlipCompanyNm)
            //				 && (secinfoset1.MainOfficeFuncNm == secinfoset2.MainOfficeFuncNm)
            //				 && (secinfoset1.BillCompanyNmPrtNm == secinfoset2.BillCompanyNmPrtNm));
            // 2005.09.13 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////
        }
        /// <summary>
        /// 拠点情報設定クラス比較処理
        /// </summary>
        /// <param name="target">比較対象のSecInfoSetクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SecInfoSetクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList Compare(SecInfoSet target)
        {
            ArrayList resList = new ArrayList();
            if (this.CreateDateTime != target.CreateDateTime) resList.Add("CreateDateTime");
            if (this.UpdateDateTime != target.UpdateDateTime) resList.Add("UpdateDateTime");
            if (this.EnterpriseCode != target.EnterpriseCode) resList.Add("EnterpriseCode");
            if (this.FileHeaderGuid != target.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (this.UpdEmployeeCode != target.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (this.UpdAssemblyId1 != target.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (this.UpdAssemblyId2 != target.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (this.LogicalDeleteCode != target.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (this.SectionCode != target.SectionCode) resList.Add("SectionCode");

            ///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA DEL STA //
            //			if(this.CompanyPr != target.CompanyPr)resList.Add("CompanyPr");
            //			if(this.CompanyName1 != target.CompanyName1)resList.Add("CompanyName1");
            //			if(this.CompanyName2 != target.CompanyName2)resList.Add("CompanyName2");
            //			if(this.PostNo != target.PostNo)resList.Add("PostNo");
            //			if(this.Address1 != target.Address1)resList.Add("Address1");
            //			if(this.Address2 != target.Address2)resList.Add("Address2");
            //			if(this.Address3 != target.Address3)resList.Add("Address3");
            //			if(this.Address4 != target.Address4)resList.Add("Address4");
            //			if(this.CompanyTelNo1 != target.CompanyTelNo1)resList.Add("CompanyTelNo1");
            //			if(this.CompanyTelNo2 != target.CompanyTelNo2)resList.Add("CompanyTelNo2");
            //			if(this.CompanyTelNo3 != target.CompanyTelNo3)resList.Add("CompanyTelNo3");
            //			if(this.CompanyTelTitle1 != target.CompanyTelTitle1)resList.Add("CompanyTelTitle1");
            //			if(this.CompanyTelTitle2 != target.CompanyTelTitle2)resList.Add("CompanyTelTitle2");
            //			if(this.CompanyTelTitle3 != target.CompanyTelTitle3)resList.Add("CompanyTelTitle3");
            //			if(this.TransferGuidance != target.TransferGuidance)resList.Add("TransferGuidance");
            //			if(this.AccountNoInfo1 != target.AccountNoInfo1)resList.Add("AccountNoInfo1");
            //			if(this.AccountNoInfo2 != target.AccountNoInfo2)resList.Add("AccountNoInfo2");
            //			if(this.AccountNoInfo3 != target.AccountNoInfo3)resList.Add("AccountNoInfo3");
            //			if(this.CompanySetNote1 != target.CompanySetNote1)resList.Add("CompanySetNote1");
            //			if(this.CompanySetNote2 != target.CompanySetNote2)resList.Add("CompanySetNote2");
            //			if(this.SlipCompanyNmCd != target.SlipCompanyNmCd)resList.Add("SlipCompanyNmCd");
            // 2005.09.13 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////

            //if (this.OthrSlipCompanyNmCd != target.OthrSlipCompanyNmCd) resList.Add("OthrSlipCompanyNmCd");  // DEL 2008/06/03
            if (this.SectionGuideNm != target.SectionGuideNm) resList.Add("SectionGuideNm");
            if (this.MainOfficeFuncFlag != target.MainOfficeFuncFlag) resList.Add("MainOfficeFuncFlag");

            ///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA DEL STA //
            //			if(this.BillCompanyNmPrtCd != target.BillCompanyNmPrtCd)resList.Add("BillCompanyNmPrtCd");
            // 2005.09.13 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////

            ///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA ADD STA //
            //if (this.SecCdForNumbering != target.SecCdForNumbering) resList.Add("SecCdForNumbering");  // DEL 2008/06/03
            if (this.CompanyNameCd1 != target.CompanyNameCd1) resList.Add("CompanyNameCd1");
            /* --- DEL 2008/06/03 --------------------------------------------------------------------->>>>>
            if (this.CompanyNameCd2 != target.CompanyNameCd2) resList.Add("CompanyNameCd2");
            if (this.CompanyNameCd3 != target.CompanyNameCd3) resList.Add("CompanyNameCd3");
            if (this.CompanyNameCd4 != target.CompanyNameCd4) resList.Add("CompanyNameCd4");
            if (this.CompanyNameCd5 != target.CompanyNameCd5) resList.Add("CompanyNameCd5");
            if (this.CompanyNameCd6 != target.CompanyNameCd6) resList.Add("CompanyNameCd6");
            if (this.CompanyNameCd7 != target.CompanyNameCd7) resList.Add("CompanyNameCd7");
            if (this.CompanyNameCd8 != target.CompanyNameCd8) resList.Add("CompanyNameCd8");
            if (this.CompanyNameCd9 != target.CompanyNameCd9) resList.Add("CompanyNameCd9");
            if (this.CompanyNameCd10 != target.CompanyNameCd10) resList.Add("CompanyNameCd10");
               --- DEL 2008/06/03 ---------------------------------------------------------------------<<<<<*/
            if (this.CompanyName1 != target.CompanyName1) resList.Add("CompanyName1");
            /* --- DEL 2008/06/03 --------------------------------------------------------------------->>>>>
            if (this.CompanyName2 != target.CompanyName2) resList.Add("CompanyName2");
            if (this.CompanyName3 != target.CompanyName3) resList.Add("CompanyName3");
            if (this.CompanyName4 != target.CompanyName4) resList.Add("CompanyName4");
            if (this.CompanyName5 != target.CompanyName5) resList.Add("CompanyName5");
            if (this.CompanyName6 != target.CompanyName6) resList.Add("CompanyName6");
            if (this.CompanyName7 != target.CompanyName7) resList.Add("CompanyName7");
            if (this.CompanyName8 != target.CompanyName8) resList.Add("CompanyName8");
            if (this.CompanyName9 != target.CompanyName9) resList.Add("CompanyName9");
            if (this.CompanyName10 != target.CompanyName10) resList.Add("CompanyName10");
               --- DEL 2008/06/03 ---------------------------------------------------------------------<<<<<*/
            // 2005.09.13 AKIYAMA ADD END /////////////////////////////////////////////////////////////////////

            // ↓ 2007.10.5 add///////////////////////////////////////////////////////////////////
            if (this.SectWarehouseCd1 != target.SectWarehouseCd1) resList.Add("SectWarehouseCd1");
            if (this.SectWarehouseCd2 != target.SectWarehouseCd2) resList.Add("SectWarehouseCd2");
            if (this.SectWarehouseCd3 != target.SectWarehouseCd3) resList.Add("SectWarehouseCd3");
            if (this.SectWarehouseNm1 != target.SectWarehouseNm1) resList.Add("SectWarehouseNm1");
            if (this.SectWarehouseNm2 != target.SectWarehouseNm2) resList.Add("SectWarehouseNm2");
            if (this.SectWarehouseNm3 != target.SectWarehouseNm3) resList.Add("SectWarehouseNm3");
            // ↑ 2007.10.5 add//////////////////////////////////////////////////////////////////


            if (this.UpdEmployeeName != target.UpdEmployeeName) resList.Add("UpdEmployeeName");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");

            ///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA DEL STA //
            //			if(this.SlipCompanyNm != target.SlipCompanyNm)resList.Add("SlipCompanyNm");
            //			if(this.OthrSlipCompanyNm != target.OthrSlipCompanyNm)resList.Add("OthrSlipCompanyNm");
            //			if(this.MainOfficeFuncNm != target.MainOfficeFuncNm)resList.Add("MainOfficeFuncNm");
            //			if(this.BillCompanyNmPrtNm != target.BillCompanyNmPrtNm)resList.Add("BillCompanyNmPrtNm");
            // 2005.09.13 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////

            // --- ADD 2008/06/03 --------------------------------------------------------------------->>>>>
            if (this.SectionGuideSnm != target.SectionGuideSnm) resList.Add("SectionGuideSnm");
            if (this.IntroductionDate != target.IntroductionDate) resList.Add("IntroductionDate");
            // --- ADD 2008/06/03 ---------------------------------------------------------------------<<<<<

            return resList;
        }

        /// <summary>
        /// 拠点情報設定クラス比較処理
        /// </summary>
        /// <param name="secinfoset1">比較するSecInfoSetクラスのインスタンス</param>
        /// <param name="secinfoset2">比較するSecInfoSetクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SecInfoSetクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static ArrayList Compare(SecInfoSet secinfoset1, SecInfoSet secinfoset2)
        {
            ArrayList resList = new ArrayList();
            if (secinfoset1.CreateDateTime != secinfoset2.CreateDateTime) resList.Add("CreateDateTime");
            if (secinfoset1.UpdateDateTime != secinfoset2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (secinfoset1.EnterpriseCode != secinfoset2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (secinfoset1.FileHeaderGuid != secinfoset2.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (secinfoset1.UpdEmployeeCode != secinfoset2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (secinfoset1.UpdAssemblyId1 != secinfoset2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (secinfoset1.UpdAssemblyId2 != secinfoset2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (secinfoset1.LogicalDeleteCode != secinfoset2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (secinfoset1.SectionCode != secinfoset2.SectionCode) resList.Add("SectionCode");

            ///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA DEL STA //
            //			if(secinfoset1.CompanyPr != secinfoset2.CompanyPr)resList.Add("CompanyPr");
            //			if(secinfoset1.CompanyName1 != secinfoset2.CompanyName1)resList.Add("CompanyName1");
            //			if(secinfoset1.CompanyName2 != secinfoset2.CompanyName2)resList.Add("CompanyName2");
            //			if(secinfoset1.PostNo != secinfoset2.PostNo)resList.Add("PostNo");
            //			if(secinfoset1.Address1 != secinfoset2.Address1)resList.Add("Address1");
            //			if(secinfoset1.Address2 != secinfoset2.Address2)resList.Add("Address2");
            //			if(secinfoset1.Address3 != secinfoset2.Address3)resList.Add("Address3");
            //			if(secinfoset1.Address4 != secinfoset2.Address4)resList.Add("Address4");
            //			if(secinfoset1.CompanyTelNo1 != secinfoset2.CompanyTelNo1)resList.Add("CompanyTelNo1");
            //			if(secinfoset1.CompanyTelNo2 != secinfoset2.CompanyTelNo2)resList.Add("CompanyTelNo2");
            //			if(secinfoset1.CompanyTelNo3 != secinfoset2.CompanyTelNo3)resList.Add("CompanyTelNo3");
            //			if(secinfoset1.CompanyTelTitle1 != secinfoset2.CompanyTelTitle1)resList.Add("CompanyTelTitle1");
            //			if(secinfoset1.CompanyTelTitle2 != secinfoset2.CompanyTelTitle2)resList.Add("CompanyTelTitle2");
            //			if(secinfoset1.CompanyTelTitle3 != secinfoset2.CompanyTelTitle3)resList.Add("CompanyTelTitle3");
            //			if(secinfoset1.TransferGuidance != secinfoset2.TransferGuidance)resList.Add("TransferGuidance");
            //			if(secinfoset1.AccountNoInfo1 != secinfoset2.AccountNoInfo1)resList.Add("AccountNoInfo1");
            //			if(secinfoset1.AccountNoInfo2 != secinfoset2.AccountNoInfo2)resList.Add("AccountNoInfo2");
            //			if(secinfoset1.AccountNoInfo3 != secinfoset2.AccountNoInfo3)resList.Add("AccountNoInfo3");
            //			if(secinfoset1.CompanySetNote1 != secinfoset2.CompanySetNote1)resList.Add("CompanySetNote1");
            //			if(secinfoset1.CompanySetNote2 != secinfoset2.CompanySetNote2)resList.Add("CompanySetNote2");
            //			if(secinfoset1.SlipCompanyNmCd != secinfoset2.SlipCompanyNmCd)resList.Add("SlipCompanyNmCd");
            // 2005.09.13 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////

            //if (secinfoset1.OthrSlipCompanyNmCd != secinfoset2.OthrSlipCompanyNmCd) resList.Add("OthrSlipCompanyNmCd");  // DEL 2008/06/03
            if (secinfoset1.SectionGuideNm != secinfoset2.SectionGuideNm) resList.Add("SectionGuideNm");
            if (secinfoset1.MainOfficeFuncFlag != secinfoset2.MainOfficeFuncFlag) resList.Add("MainOfficeFuncFlag");

            ///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA DEL STA //
            //			if(secinfoset1.BillCompanyNmPrtCd != secinfoset2.BillCompanyNmPrtCd)resList.Add("BillCompanyNmPrtCd");
            // 2005.09.13 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////

            ///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA ADD STA //
            //if (secinfoset1.SecCdForNumbering != secinfoset2.SecCdForNumbering) resList.Add("SecCdForNumbering");  // DEL 2008/06/03
            if (secinfoset1.CompanyNameCd1 != secinfoset2.CompanyNameCd1) resList.Add("CompanyNameCd1");
            /* --- DEL 2008/06/03 --------------------------------------------------------------------->>>>>
            if (secinfoset1.CompanyNameCd2 != secinfoset2.CompanyNameCd2) resList.Add("CompanyNameCd2");
            if (secinfoset1.CompanyNameCd3 != secinfoset2.CompanyNameCd3) resList.Add("CompanyNameCd3");
            if (secinfoset1.CompanyNameCd4 != secinfoset2.CompanyNameCd4) resList.Add("CompanyNameCd4");
            if (secinfoset1.CompanyNameCd5 != secinfoset2.CompanyNameCd5) resList.Add("CompanyNameCd5");
            if (secinfoset1.CompanyNameCd6 != secinfoset2.CompanyNameCd6) resList.Add("CompanyNameCd6");
            if (secinfoset1.CompanyNameCd7 != secinfoset2.CompanyNameCd7) resList.Add("CompanyNameCd7");
            if (secinfoset1.CompanyNameCd8 != secinfoset2.CompanyNameCd8) resList.Add("CompanyNameCd8");
            if (secinfoset1.CompanyNameCd9 != secinfoset2.CompanyNameCd9) resList.Add("CompanyNameCd9");
            if (secinfoset1.CompanyNameCd10 != secinfoset2.CompanyNameCd10) resList.Add("CompanyNameCd10");
               --- DEL 2008/06/03 ---------------------------------------------------------------------<<<<<*/
            if (secinfoset1.CompanyName1 != secinfoset2.CompanyName1) resList.Add("CompanyName1");
            /* --- DEL 2008/06/03 --------------------------------------------------------------------->>>>>
            if (secinfoset1.CompanyName2 != secinfoset2.CompanyName2) resList.Add("CompanyName2");
            if (secinfoset1.CompanyName3 != secinfoset2.CompanyName3) resList.Add("CompanyName3");
            if (secinfoset1.CompanyName4 != secinfoset2.CompanyName4) resList.Add("CompanyName4");
            if (secinfoset1.CompanyName5 != secinfoset2.CompanyName5) resList.Add("CompanyName5");
            if (secinfoset1.CompanyName6 != secinfoset2.CompanyName6) resList.Add("CompanyName6");
            if (secinfoset1.CompanyName7 != secinfoset2.CompanyName7) resList.Add("CompanyName7");
            if (secinfoset1.CompanyName8 != secinfoset2.CompanyName8) resList.Add("CompanyName8");
            if (secinfoset1.CompanyName9 != secinfoset2.CompanyName9) resList.Add("CompanyName9");
            if (secinfoset1.CompanyName10 != secinfoset2.CompanyName10) resList.Add("CompanyName10");
               --- DEL 2008/06/03 ---------------------------------------------------------------------<<<<<*/
            // 2005.09.13 AKIYAMA ADD END /////////////////////////////////////////////////////////////////////

            // ↓ 2007.10.5 add////////////////////////////////////////////////////////////////////////////////
            if (secinfoset1.SectWarehouseCd1 != secinfoset2.SectWarehouseCd1) resList.Add("SectWarehouseCd1");
            if (secinfoset1.SectWarehouseCd2 != secinfoset2.SectWarehouseCd2) resList.Add("SectWarehouseCd2");
            if (secinfoset1.SectWarehouseCd3 != secinfoset2.SectWarehouseCd3) resList.Add("SectWarehouseCd3");
            if (secinfoset1.SectWarehouseNm1 != secinfoset2.SectWarehouseNm1) resList.Add("SectWarehouseNm1");
            if (secinfoset1.SectWarehouseNm2 != secinfoset2.SectWarehouseNm2) resList.Add("SectWarehouseNm2");
            if (secinfoset1.SectWarehouseNm3 != secinfoset2.SectWarehouseNm3) resList.Add("SectWarehouseNm3");
            // ↑ 2007.10.5 add///////////////////////////////////////////////////////////////////////////////

            if (secinfoset1.UpdEmployeeName != secinfoset2.UpdEmployeeName) resList.Add("UpdEmployeeName");
            if (secinfoset1.EnterpriseName != secinfoset2.EnterpriseName) resList.Add("EnterpriseName");

            ///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA DEL STA //
            //			if(secinfoset1.SlipCompanyNm != secinfoset2.SlipCompanyNm)resList.Add("SlipCompanyNm");
            //			if(secinfoset1.OthrSlipCompanyNm != secinfoset2.OthrSlipCompanyNm)resList.Add("OthrSlipCompanyNm");
            //			if(secinfoset1.MainOfficeFuncNm != secinfoset2.MainOfficeFuncNm)resList.Add("MainOfficeFuncNm");
            //			if(secinfoset1.BillCompanyNmPrtNm != secinfoset2.BillCompanyNmPrtNm)resList.Add("BillCompanyNmPrtNm");
            // 2005.09.13 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////

            // --- ADD 2008/06/03 --------------------------------------------------------------------->>>>>
            if (secinfoset1.SectionGuideSnm != secinfoset2.SectionGuideSnm) resList.Add("SectionGuideSnm");
            if (secinfoset1.IntroductionDate != secinfoset2.IntroductionDate) resList.Add("IntroductionDate");
            // --- ADD 2008/06/03 ---------------------------------------------------------------------<<<<<

            return resList;
        }

        ///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA ADD STA //
        /// <summary>
        /// 自社名称コード取得処理
        /// </summary>
        /// <param name="index">インデックス</param>
        /// <returns>自社名称コード</returns>
        /// <remarks>
        /// <br>Note       : インデックスで指定した自社名称コードを取得します</br>
        /// <br>Programmer : 23001 秋山　亮介</br>
        /// <br>Date       : 2005.09.13</br>
        /// </remarks>
        public int GetCompanyNameCd(int index)
        {
            switch (index)
            {
                case 0:
                    {
                        return this._companyNameCd1;
                    }
            /* --- DEL 2008/06/03 --------------------------------------------------------------------->>>>>
            case 1:
                {
                    return this._companyNameCd2;
                }
            case 2:
                {
                    return this._companyNameCd3;
                }
            case 3:
                {
                    return this._companyNameCd4;
                }
            case 4:
                {
                    return this._companyNameCd5;
                }
            case 5:
                {
                    return this._companyNameCd6;
                }
            case 6:
                {
                    return this._companyNameCd7;
                }
            case 7:
                {
                    return this._companyNameCd8;
                }
            case 8:
                {
                    return this._companyNameCd9;
                }
            case 9:
                {
                    return this._companyNameCd10;
                }
               --- DEL 2008/06/03 ---------------------------------------------------------------------<<<<<*/
                default:
                    {
                        return 0;
                    }
            }
        }

        /// <summary>
        /// 自社名称コード設定処理
        /// </summary>
        /// <param name="companyNameCd">自社名称コード</param>
        /// <param name="index">インデックス</param>
        /// <remarks>
        /// <br>Note       : インデックスで指定した自社名称コードを設定します</br>
        /// <br>Programmer : 23001 秋山　亮介</br>
        /// <br>Date       : 2005.09.13</br>
        /// </remarks>
        public void SetCompanyNameCd(int companyNameCd, int index)
        {
            switch (index)
            {
                case 0:
                    {
                        this._companyNameCd1 = companyNameCd;
                        break;
                    }
                /* --- DEL 2008/06/03 --------------------------------------------------------------------->>>>>
                case 1:
                    {
                        this._companyNameCd2 = companyNameCd;
                        break;
                    }
                case 2:
                    {
                        this._companyNameCd3 = companyNameCd;
                        break;
                    }
                case 3:
                    {
                        this._companyNameCd4 = companyNameCd;
                        break;
                    }
                case 4:
                    {
                        this._companyNameCd5 = companyNameCd;
                        break;
                    }
                case 5:
                    {
                        this._companyNameCd6 = companyNameCd;
                        break;
                    }
                case 6:
                    {
                        this._companyNameCd7 = companyNameCd;
                        break;
                    }
                case 7:
                    {
                        this._companyNameCd8 = companyNameCd;
                        break;
                    }
                case 8:
                    {
                        this._companyNameCd9 = companyNameCd;
                        break;
                    }
                case 9:
                    {
                        this._companyNameCd10 = companyNameCd;
                        break;
                    }
                   --- DEL 2008/06/03 ---------------------------------------------------------------------<<<<<*/
                default:
                    {
                        break;
                    }
            }
        }

        /// <summary>
        /// 自社名称取得処理
        /// </summary>
        /// <param name="index">インデックス</param>
        /// <returns>自社名称</returns>
        /// <remarks>
        /// <br>Note       : インデックスで指定した自社名称を取得します</br>
        /// <br>Programmer : 23001 秋山　亮介</br>
        /// <br>Date       : 2005.09.13</br>
        /// </remarks>
        public string GetCompanyName(int index)
        {
            switch (index)
            {
                case 0:
                    {
                        return this._companyName1;
                    }
                /* --- DEL 2008/06/03 --------------------------------------------------------------------->>>>>
                case 1:
                    {
                        return this._companyName2;
                    }
                case 2:
                    {
                        return this._companyName3;
                    }
                case 3:
                    {
                        return this._companyName4;
                    }
                case 4:
                    {
                        return this._companyName5;
                    }
                case 5:
                    {
                        return this._companyName6;
                    }
                case 6:
                    {
                        return this._companyName7;
                    }
                case 7:
                    {
                        return this._companyName8;
                    }
                case 8:
                    {
                        return this._companyName9;
                    }
                case 9:
                    {
                        return this._companyName10;
                    }
                   --- DEL 2008/06/03 ---------------------------------------------------------------------<<<<<*/
                default:
                    {
                        return "";
                    }
            }
        }

        /// <summary>
        /// 自社名称設定処理
        /// </summary>
        /// <param name="companyName">自社名称</param>
        /// <param name="index">インデックス</param>
        /// <remarks>
        /// <br>Note       : インデックスで指定した自社名称を設定します</br>
        /// <br>Programmer : 23001 秋山　亮介</br>
        /// <br>Date       : 2005.09.13</br>
        /// </remarks>
        public void SetCompanyName(string companyName, int index)
        {
            switch (index)
            {
                case 0:
                    {
                        this._companyName1 = companyName;
                        break;
                    }
                /* --- DEL 2008/06/03 --------------------------------------------------------------------->>>>>
                case 1:
                    {
                        this._companyName2 = companyName;
                        break;
                    }
                case 2:
                    {
                        this._companyName3 = companyName;
                        break;
                    }
                case 3:
                    {
                        this._companyName4 = companyName;
                        break;
                    }
                case 4:
                    {
                        this._companyName5 = companyName;
                        break;
                    }
                case 5:
                    {
                        this._companyName6 = companyName;
                        break;
                    }
                case 6:
                    {
                        this._companyName7 = companyName;
                        break;
                    }
                case 7:
                    {
                        this._companyName8 = companyName;
                        break;
                    }
                case 8:
                    {
                        this._companyName9 = companyName;
                        break;
                    }
                case 9:
                    {
                        this._companyName10 = companyName;
                        break;
                    }
                   --- DEL 2008/06/03 ---------------------------------------------------------------------<<<<<*/
                default:
                    {
                        break;
                    }
            }
        }
        // 2005.09.13 AKIYAMA ADD END /////////////////////////////////////////////////////////////////////


        // ↓ 2007.10.5 add///////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// 拠点倉庫コード取得処理
        /// </summary>
        /// <param name="index">インデックス</param>
        /// <returns>拠点倉庫コード</returns>
        /// <remarks>
        /// <br>Note       : インデックスで指定した拠点倉庫コードを取得します</br>
        /// <br>Date       : 2007.10.5</br>
        /// </remarks>
        public string GetSectWarehouseCd(int index)
        {
            switch (index)
            {
                case 0:
                    {
                        return this._sectWarehouseCd1;
                    }
                case 1:
                    {
                        return this._sectWarehouseCd2;
                    }
                case 2:
                    {
                        return this._sectWarehouseCd3;
                    }
                default:
                    {
                        return "";
                    }
            }
        }

        /// <summary>
        /// 拠点倉庫コード設定処理
        /// </summary>
        /// <param name="sectWarehouseCd">拠点倉庫コード</param>
        /// <param name="index">インデックス</param>
        /// <remarks>
        /// <br>Note       : インデックスで指定した拠点倉庫コードを設定します</br>
        /// <br>Date       : 2007.10.5</br>
        /// </remarks>
        public void SetSectWarehouseCd(string sectWarehouseCd, int index)
        {
            switch (index)
            {
                case 0:
                    {
                        this._sectWarehouseCd1 = sectWarehouseCd;
                        break;
                    }
                case 1:
                    {
                        this._sectWarehouseCd2 = sectWarehouseCd;
                        break;
                    }
                case 2:
                    {
                        this._sectWarehouseCd3 = sectWarehouseCd;
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }

        /// <summary>
        /// 拠点倉庫名称取得処理
        /// </summary>
        /// <param name="index">インデックス</param>
        /// <returns>拠点倉庫名称</returns>
        /// <remarks>
        /// <br>Note       : インデックスで指定した自社名称を取得します</br>
        /// <br>Date       : 2007.10.5</br>
        /// </remarks>
        public string GetSectWarehouseNm(int index)
        {
            switch (index)
            {
                case 0:
                    {
                        return this._sectWarehouseNm1;
                    }
                case 1:
                    {
                        return this._sectWarehouseNm2;
                    }
                case 2:
                    {
                        return this._sectWarehouseNm3;
                    }
                default:
                    {
                        return "";
                    }

            }
        }

        /// <summary>
        /// 拠点倉庫名称設定処理
        /// </summary>
        /// <param name="sectWarehouseNm">拠点倉庫名称</param>
        /// <param name="index">インデックス</param>
        /// <remarks>
        /// <br>Note       : インデックスで指定した自社名称を設定します</br>
        /// <br>Date       : 2007.10.5</br>
        /// </remarks>
        public void SetSectWarehouseNm(string sectWarehouseNm, int index)
        {
            switch (index)
            {
                case 0:
                    {
                        this._sectWarehouseNm1 = sectWarehouseNm;
                        break;
                    }
                case 1:
                    {
                        this._sectWarehouseNm2 = sectWarehouseNm;
                        break;
                    }
                case 2:
                    {
                        this._sectWarehouseNm3 = sectWarehouseNm;
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }

        // ↑ 2007.10.5 add//////////////////////////////////////////////////////////////////////////////
    }
}