using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   SmplInqBas
    /// <summary>
    ///                      簡単問合せID付属情報マスタ(基本情報)
    /// </summary>
    /// <remarks>
    /// <br>note             :   簡単問合せID付属情報マスタ(基本情報)ヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   中村 仁</br>
    /// <br>Genarated Date   :   2010/04/06  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class SmplInqBas
    {
        /// <summary>作成日時</summary>
        /// <remarks>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</remarks>
        private DateTime _createDateTime;

        /// <summary>更新日時</summary>
        /// <remarks>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</remarks>
        private DateTime _updateDateTime;

        /// <summary>論理削除区分</summary>
        /// <remarks>共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除)</remarks>
        private Int32 _logicalDeleteCode;

        /// <summary>簡単問合せID付属情報管理番号</summary>
        /// <remarks>ユーザー単位の連番</remarks>
        private Int64 _simpleInqIdInfMngNo;

        /// <summary>名称</summary>
        private string _name = "";

        /// <summary>名称2</summary>
        private string _name2 = "";

        /// <summary>カナ</summary>
        private string _kana = "";

        /// <summary>性別コード</summary>
        /// <remarks>:男,1:女,2:無</remarks>
        private Int32 _sexCode;

        /// <summary>性別名称</summary>
        /// <remarks>全角で管理</remarks>
        private string _sexName = "";

        /// <summary>生年月日</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _birthday;

        /// <summary>郵便番号</summary>
        private string _postNo = "";

        /// <summary>都道府県コード</summary>
        /// <remarks>都道府県市区郡ｺｰﾄﾞの上2桁</remarks>
        private Int32 _addressCode1Upper;

        /// <summary>WEB表示住所(都道府県)</summary>
        /// <remarks>(半角全角混在)</remarks>
        private string _webDspAddrADOJp = "";

        /// <summary>WEB表示住所(区市町村)</summary>
        /// <remarks>(半角全角混在)</remarks>
        private string _webDspAddrCity = "";

        /// <summary>WEB表示住所(ビル･マンション名)</summary>
        /// <remarks>(半角全角混在)</remarks>
        private string _webDspAddrBuil = "";

        /// <summary>職種コード</summary>
        private Int32 _jobTypeCode;

        /// <summary>業種コード</summary>
        private Int32 _businessTypeCode;

        /// <summary>電話番号（自宅）</summary>
        /// <remarks>ハイフンを含めた16桁の番号</remarks>
        private string _homeTelNo = "";

        /// <summary>電話番号（勤務先）</summary>
        private string _officeTelNo = "";

        /// <summary>電話番号（携帯）</summary>
        private string _portableTelNo = "";

        /// <summary>FAX番号（自宅）</summary>
        private string _homeFaxNo = "";

        /// <summary>FAX番号（勤務先）</summary>
        private string _officeFaxNo = "";

        /// <summary>メールアドレス1</summary>
        private string _mailAddress1 = "";

        /// <summary>メールアドレス種別コード1</summary>
        /// <remarks>0:自宅,1:会社,2:携帯端末,3:本人以外,99:その他</remarks>
        private Int32 _mailAddrKindCode1;

        /// <summary>メールアドレス2</summary>
        private string _mailAddress2 = "";

        /// <summary>メールアドレス種別コード2</summary>
        /// <remarks>0:自宅,1:会社,2:携帯端末,3:本人以外,99:その他</remarks>
        private Int32 _mailAddrKindCode2;

        /// <summary>メールアドレス3</summary>
        private string _mailAddress3 = "";

        /// <summary>メールアドレス種別コード3</summary>
        /// <remarks>0:自宅,1:会社,2:携帯端末,3:本人以外,99:その他</remarks>
        private Int32 _mailAddrKindCode3;

        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>企業名称</summary>
        private string _enterpriseName = "";

        /// <summary>職種名称</summary>
        private string _jobTypeName = "";

        /// <summary>業種名称</summary>
        private string _businessTypeName = "";


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

        /// public propaty name  :  SimpleInqIdInfMngNo
        /// <summary>簡単問合せID付属情報管理番号プロパティ</summary>
        /// <value>ユーザー単位の連番</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   簡単問合せID付属情報管理番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SimpleInqIdInfMngNo
        {
            get { return _simpleInqIdInfMngNo; }
            set { _simpleInqIdInfMngNo = value; }
        }

        /// public propaty name  :  Name
        /// <summary>名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        /// public propaty name  :  Name2
        /// <summary>名称2プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   名称2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string Name2
        {
            get { return _name2; }
            set { _name2 = value; }
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

        /// public propaty name  :  SexCode
        /// <summary>性別コードプロパティ</summary>
        /// <value>:男,1:女,2:無</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   性別コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SexCode
        {
            get { return _sexCode; }
            set { _sexCode = value; }
        }

        /// public propaty name  :  SexName
        /// <summary>性別名称プロパティ</summary>
        /// <value>全角で管理</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   性別名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SexName
        {
            get { return _sexName; }
            set { _sexName = value; }
        }

        /// public propaty name  :  Birthday
        /// <summary>生年月日プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   生年月日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime Birthday
        {
            get { return _birthday; }
            set { _birthday = value; }
        }

        /// public propaty name  :  BirthdayJpFormal
        /// <summary>生年月日 和暦プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   生年月日 和暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string BirthdayJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _birthday); }
            set { }
        }

        /// public propaty name  :  BirthdayJpInFormal
        /// <summary>生年月日 和暦(略)プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   生年月日 和暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string BirthdayJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _birthday); }
            set { }
        }

        /// public propaty name  :  BirthdayAdFormal
        /// <summary>生年月日 西暦プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   生年月日 西暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string BirthdayAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _birthday); }
            set { }
        }

        /// public propaty name  :  BirthdayAdInFormal
        /// <summary>生年月日 西暦(略)プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   生年月日 西暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string BirthdayAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _birthday); }
            set { }
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

        /// public propaty name  :  AddressCode1Upper
        /// <summary>都道府県コードプロパティ</summary>
        /// <value>都道府県市区郡ｺｰﾄﾞの上2桁</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   都道府県コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AddressCode1Upper
        {
            get { return _addressCode1Upper; }
            set { _addressCode1Upper = value; }
        }

        /// public propaty name  :  WebDspAddrADOJp
        /// <summary>WEB表示住所(都道府県)プロパティ</summary>
        /// <value>(半角全角混在)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   WEB表示住所(都道府県)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string WebDspAddrADOJp
        {
            get { return _webDspAddrADOJp; }
            set { _webDspAddrADOJp = value; }
        }

        /// public propaty name  :  WebDspAddrCity
        /// <summary>WEB表示住所(区市町村)プロパティ</summary>
        /// <value>(半角全角混在)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   WEB表示住所(区市町村)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string WebDspAddrCity
        {
            get { return _webDspAddrCity; }
            set { _webDspAddrCity = value; }
        }

        /// public propaty name  :  WebDspAddrBuil
        /// <summary>WEB表示住所(ビル･マンション名)プロパティ</summary>
        /// <value>(半角全角混在)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   WEB表示住所(ビル･マンション名)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string WebDspAddrBuil
        {
            get { return _webDspAddrBuil; }
            set { _webDspAddrBuil = value; }
        }

        /// public propaty name  :  JobTypeCode
        /// <summary>職種コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   職種コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 JobTypeCode
        {
            get { return _jobTypeCode; }
            set { _jobTypeCode = value; }
        }

        /// public propaty name  :  BusinessTypeCode
        /// <summary>業種コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   業種コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BusinessTypeCode
        {
            get { return _businessTypeCode; }
            set { _businessTypeCode = value; }
        }

        /// public propaty name  :  HomeTelNo
        /// <summary>電話番号（自宅）プロパティ</summary>
        /// <value>ハイフンを含めた16桁の番号</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   電話番号（自宅）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HomeTelNo
        {
            get { return _homeTelNo; }
            set { _homeTelNo = value; }
        }

        /// public propaty name  :  OfficeTelNo
        /// <summary>電話番号（勤務先）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   電話番号（勤務先）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string OfficeTelNo
        {
            get { return _officeTelNo; }
            set { _officeTelNo = value; }
        }

        /// public propaty name  :  PortableTelNo
        /// <summary>電話番号（携帯）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   電話番号（携帯）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PortableTelNo
        {
            get { return _portableTelNo; }
            set { _portableTelNo = value; }
        }

        /// public propaty name  :  HomeFaxNo
        /// <summary>FAX番号（自宅）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   FAX番号（自宅）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HomeFaxNo
        {
            get { return _homeFaxNo; }
            set { _homeFaxNo = value; }
        }

        /// public propaty name  :  OfficeFaxNo
        /// <summary>FAX番号（勤務先）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   FAX番号（勤務先）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string OfficeFaxNo
        {
            get { return _officeFaxNo; }
            set { _officeFaxNo = value; }
        }

        /// public propaty name  :  MailAddress1
        /// <summary>メールアドレス1プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メールアドレス1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MailAddress1
        {
            get { return _mailAddress1; }
            set { _mailAddress1 = value; }
        }

        /// public propaty name  :  MailAddrKindCode1
        /// <summary>メールアドレス種別コード1プロパティ</summary>
        /// <value>0:自宅,1:会社,2:携帯端末,3:本人以外,99:その他</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メールアドレス種別コード1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 MailAddrKindCode1
        {
            get { return _mailAddrKindCode1; }
            set { _mailAddrKindCode1 = value; }
        }

        /// public propaty name  :  MailAddress2
        /// <summary>メールアドレス2プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メールアドレス2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MailAddress2
        {
            get { return _mailAddress2; }
            set { _mailAddress2 = value; }
        }

        /// public propaty name  :  MailAddrKindCode2
        /// <summary>メールアドレス種別コード2プロパティ</summary>
        /// <value>0:自宅,1:会社,2:携帯端末,3:本人以外,99:その他</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メールアドレス種別コード2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 MailAddrKindCode2
        {
            get { return _mailAddrKindCode2; }
            set { _mailAddrKindCode2 = value; }
        }

        /// public propaty name  :  MailAddress3
        /// <summary>メールアドレス3プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メールアドレス3プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MailAddress3
        {
            get { return _mailAddress3; }
            set { _mailAddress3 = value; }
        }

        /// public propaty name  :  MailAddrKindCode3
        /// <summary>メールアドレス種別コード3プロパティ</summary>
        /// <value>0:自宅,1:会社,2:携帯端末,3:本人以外,99:その他</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メールアドレス種別コード3プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 MailAddrKindCode3
        {
            get { return _mailAddrKindCode3; }
            set { _mailAddrKindCode3 = value; }
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

        /// public propaty name  :  JobTypeName
        /// <summary>職種名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   職種名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string JobTypeName
        {
            get { return _jobTypeName; }
            set { _jobTypeName = value; }
        }

        /// public propaty name  :  BusinessTypeName
        /// <summary>業種名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   業種名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string BusinessTypeName
        {
            get { return _businessTypeName; }
            set { _businessTypeName = value; }
        }


        /// <summary>
        /// 簡単問合せID付属情報マスタ(基本情報)コンストラクタ
        /// </summary>
        /// <returns>SmplInqBasクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SmplInqBasクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SmplInqBas()
        {
        }

        /// <summary>
        /// 簡単問合せID付属情報マスタ(基本情報)コンストラクタ
        /// </summary>
        /// <param name="createDateTime">作成日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="updateDateTime">更新日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="logicalDeleteCode">論理削除区分(共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除))</param>
        /// <param name="simpleInqIdInfMngNo">簡単問合せID付属情報管理番号(ユーザー単位の連番)</param>
        /// <param name="name">名称</param>
        /// <param name="name2">名称2</param>
        /// <param name="kana">カナ</param>
        /// <param name="sexCode">性別コード(:男,1:女,2:無)</param>
        /// <param name="sexName">性別名称(全角で管理)</param>
        /// <param name="birthday">生年月日(YYYYMMDD)</param>
        /// <param name="postNo">郵便番号</param>
        /// <param name="addressCode1Upper">都道府県コード(都道府県市区郡ｺｰﾄﾞの上2桁)</param>
        /// <param name="webDspAddrADOJp">WEB表示住所(都道府県)((半角全角混在))</param>
        /// <param name="webDspAddrCity">WEB表示住所(区市町村)((半角全角混在))</param>
        /// <param name="webDspAddrBuil">WEB表示住所(ビル･マンション名)((半角全角混在))</param>
        /// <param name="jobTypeCode">職種コード</param>
        /// <param name="businessTypeCode">業種コード</param>
        /// <param name="homeTelNo">電話番号（自宅）(ハイフンを含めた16桁の番号)</param>
        /// <param name="officeTelNo">電話番号（勤務先）</param>
        /// <param name="portableTelNo">電話番号（携帯）</param>
        /// <param name="homeFaxNo">FAX番号（自宅）</param>
        /// <param name="officeFaxNo">FAX番号（勤務先）</param>
        /// <param name="mailAddress1">メールアドレス1</param>
        /// <param name="mailAddrKindCode1">メールアドレス種別コード1(0:自宅,1:会社,2:携帯端末,3:本人以外,99:その他)</param>
        /// <param name="mailAddress2">メールアドレス2</param>
        /// <param name="mailAddrKindCode2">メールアドレス種別コード2(0:自宅,1:会社,2:携帯端末,3:本人以外,99:その他)</param>
        /// <param name="mailAddress3">メールアドレス3</param>
        /// <param name="mailAddrKindCode3">メールアドレス種別コード3(0:自宅,1:会社,2:携帯端末,3:本人以外,99:その他)</param>
        /// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
        /// <param name="enterpriseName">企業名称</param>
        /// <param name="jobTypeName">職種名称</param>
        /// <param name="businessTypeName">業種名称</param>
        /// <returns>SmplInqBasクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SmplInqBasクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SmplInqBas(DateTime createDateTime, DateTime updateDateTime, Int32 logicalDeleteCode, Int64 simpleInqIdInfMngNo, string name, string name2, string kana, Int32 sexCode, string sexName, DateTime birthday, string postNo, Int32 addressCode1Upper, string webDspAddrADOJp, string webDspAddrCity, string webDspAddrBuil, Int32 jobTypeCode, Int32 businessTypeCode, string homeTelNo, string officeTelNo, string portableTelNo, string homeFaxNo, string officeFaxNo, string mailAddress1, Int32 mailAddrKindCode1, string mailAddress2, Int32 mailAddrKindCode2, string mailAddress3, Int32 mailAddrKindCode3, string enterpriseCode, string enterpriseName, string jobTypeName, string businessTypeName)
        {
            this.CreateDateTime = createDateTime;
            this.UpdateDateTime = updateDateTime;
            this._logicalDeleteCode = logicalDeleteCode;
            this._simpleInqIdInfMngNo = simpleInqIdInfMngNo;
            this._name = name;
            this._name2 = name2;
            this._kana = kana;
            this._sexCode = sexCode;
            this._sexName = sexName;
            this.Birthday = birthday;
            this._postNo = postNo;
            this._addressCode1Upper = addressCode1Upper;
            this._webDspAddrADOJp = webDspAddrADOJp;
            this._webDspAddrCity = webDspAddrCity;
            this._webDspAddrBuil = webDspAddrBuil;
            this._jobTypeCode = jobTypeCode;
            this._businessTypeCode = businessTypeCode;
            this._homeTelNo = homeTelNo;
            this._officeTelNo = officeTelNo;
            this._portableTelNo = portableTelNo;
            this._homeFaxNo = homeFaxNo;
            this._officeFaxNo = officeFaxNo;
            this._mailAddress1 = mailAddress1;
            this._mailAddrKindCode1 = mailAddrKindCode1;
            this._mailAddress2 = mailAddress2;
            this._mailAddrKindCode2 = mailAddrKindCode2;
            this._mailAddress3 = mailAddress3;
            this._mailAddrKindCode3 = mailAddrKindCode3;
            this._enterpriseCode = enterpriseCode;
            this._enterpriseName = enterpriseName;
            this._jobTypeName = jobTypeName;
            this._businessTypeName = businessTypeName;

        }

        /// <summary>
        /// 簡単問合せID付属情報マスタ(基本情報)複製処理
        /// </summary>
        /// <returns>SmplInqBasクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいSmplInqBasクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SmplInqBas Clone()
        {
            return new SmplInqBas(this._createDateTime, this._updateDateTime, this._logicalDeleteCode, this._simpleInqIdInfMngNo, this._name, this._name2, this._kana, this._sexCode, this._sexName, this._birthday, this._postNo, this._addressCode1Upper, this._webDspAddrADOJp, this._webDspAddrCity, this._webDspAddrBuil, this._jobTypeCode, this._businessTypeCode, this._homeTelNo, this._officeTelNo, this._portableTelNo, this._homeFaxNo, this._officeFaxNo, this._mailAddress1, this._mailAddrKindCode1, this._mailAddress2, this._mailAddrKindCode2, this._mailAddress3, this._mailAddrKindCode3, this._enterpriseCode, this._enterpriseName, this._jobTypeName, this._businessTypeName);
        }

        /// <summary>
        /// 簡単問合せID付属情報マスタ(基本情報)比較処理
        /// </summary>
        /// <param name="target">比較対象のSmplInqBasクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SmplInqBasクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool Equals(SmplInqBas target)
        {
            return ( ( this.CreateDateTime == target.CreateDateTime )
                 && ( this.UpdateDateTime == target.UpdateDateTime )
                 && ( this.LogicalDeleteCode == target.LogicalDeleteCode )
                 && ( this.SimpleInqIdInfMngNo == target.SimpleInqIdInfMngNo )
                 && ( this.Name == target.Name )
                 && ( this.Name2 == target.Name2 )
                 && ( this.Kana == target.Kana )
                 && ( this.SexCode == target.SexCode )
                 && ( this.SexName == target.SexName )
                 && ( this.Birthday == target.Birthday )
                 && ( this.PostNo == target.PostNo )
                 && ( this.AddressCode1Upper == target.AddressCode1Upper )
                 && ( this.WebDspAddrADOJp == target.WebDspAddrADOJp )
                 && ( this.WebDspAddrCity == target.WebDspAddrCity )
                 && ( this.WebDspAddrBuil == target.WebDspAddrBuil )
                 && ( this.JobTypeCode == target.JobTypeCode )
                 && ( this.BusinessTypeCode == target.BusinessTypeCode )
                 && ( this.HomeTelNo == target.HomeTelNo )
                 && ( this.OfficeTelNo == target.OfficeTelNo )
                 && ( this.PortableTelNo == target.PortableTelNo )
                 && ( this.HomeFaxNo == target.HomeFaxNo )
                 && ( this.OfficeFaxNo == target.OfficeFaxNo )
                 && ( this.MailAddress1 == target.MailAddress1 )
                 && ( this.MailAddrKindCode1 == target.MailAddrKindCode1 )
                 && ( this.MailAddress2 == target.MailAddress2 )
                 && ( this.MailAddrKindCode2 == target.MailAddrKindCode2 )
                 && ( this.MailAddress3 == target.MailAddress3 )
                 && ( this.MailAddrKindCode3 == target.MailAddrKindCode3 )
                 && ( this.EnterpriseCode == target.EnterpriseCode )
                 && ( this.EnterpriseName == target.EnterpriseName )
                 && ( this.JobTypeName == target.JobTypeName )
                 && ( this.BusinessTypeName == target.BusinessTypeName ) );
        }

        /// <summary>
        /// 簡単問合せID付属情報マスタ(基本情報)比較処理
        /// </summary>
        /// <param name="smplInqBas1">
        ///                    比較するSmplInqBasクラスのインスタンス
        /// </param>
        /// <param name="smplInqBas2">比較するSmplInqBasクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SmplInqBasクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static bool Equals(SmplInqBas smplInqBas1, SmplInqBas smplInqBas2)
        {
            return ( ( smplInqBas1.CreateDateTime == smplInqBas2.CreateDateTime )
                 && ( smplInqBas1.UpdateDateTime == smplInqBas2.UpdateDateTime )
                 && ( smplInqBas1.LogicalDeleteCode == smplInqBas2.LogicalDeleteCode )
                 && ( smplInqBas1.SimpleInqIdInfMngNo == smplInqBas2.SimpleInqIdInfMngNo )
                 && ( smplInqBas1.Name == smplInqBas2.Name )
                 && ( smplInqBas1.Name2 == smplInqBas2.Name2 )
                 && ( smplInqBas1.Kana == smplInqBas2.Kana )
                 && ( smplInqBas1.SexCode == smplInqBas2.SexCode )
                 && ( smplInqBas1.SexName == smplInqBas2.SexName )
                 && ( smplInqBas1.Birthday == smplInqBas2.Birthday )
                 && ( smplInqBas1.PostNo == smplInqBas2.PostNo )
                 && ( smplInqBas1.AddressCode1Upper == smplInqBas2.AddressCode1Upper )
                 && ( smplInqBas1.WebDspAddrADOJp == smplInqBas2.WebDspAddrADOJp )
                 && ( smplInqBas1.WebDspAddrCity == smplInqBas2.WebDspAddrCity )
                 && ( smplInqBas1.WebDspAddrBuil == smplInqBas2.WebDspAddrBuil )
                 && ( smplInqBas1.JobTypeCode == smplInqBas2.JobTypeCode )
                 && ( smplInqBas1.BusinessTypeCode == smplInqBas2.BusinessTypeCode )
                 && ( smplInqBas1.HomeTelNo == smplInqBas2.HomeTelNo )
                 && ( smplInqBas1.OfficeTelNo == smplInqBas2.OfficeTelNo )
                 && ( smplInqBas1.PortableTelNo == smplInqBas2.PortableTelNo )
                 && ( smplInqBas1.HomeFaxNo == smplInqBas2.HomeFaxNo )
                 && ( smplInqBas1.OfficeFaxNo == smplInqBas2.OfficeFaxNo )
                 && ( smplInqBas1.MailAddress1 == smplInqBas2.MailAddress1 )
                 && ( smplInqBas1.MailAddrKindCode1 == smplInqBas2.MailAddrKindCode1 )
                 && ( smplInqBas1.MailAddress2 == smplInqBas2.MailAddress2 )
                 && ( smplInqBas1.MailAddrKindCode2 == smplInqBas2.MailAddrKindCode2 )
                 && ( smplInqBas1.MailAddress3 == smplInqBas2.MailAddress3 )
                 && ( smplInqBas1.MailAddrKindCode3 == smplInqBas2.MailAddrKindCode3 )
                 && ( smplInqBas1.EnterpriseCode == smplInqBas2.EnterpriseCode )
                 && ( smplInqBas1.EnterpriseName == smplInqBas2.EnterpriseName )
                 && ( smplInqBas1.JobTypeName == smplInqBas2.JobTypeName )
                 && ( smplInqBas1.BusinessTypeName == smplInqBas2.BusinessTypeName ) );
        }
        /// <summary>
        /// 簡単問合せID付属情報マスタ(基本情報)比較処理
        /// </summary>
        /// <param name="target">比較対象のSmplInqBasクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SmplInqBasクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList Compare(SmplInqBas target)
        {
            ArrayList resList = new ArrayList();
            if (this.CreateDateTime != target.CreateDateTime) resList.Add("CreateDateTime");
            if (this.UpdateDateTime != target.UpdateDateTime) resList.Add("UpdateDateTime");
            if (this.LogicalDeleteCode != target.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (this.SimpleInqIdInfMngNo != target.SimpleInqIdInfMngNo) resList.Add("SimpleInqIdInfMngNo");
            if (this.Name != target.Name) resList.Add("Name");
            if (this.Name2 != target.Name2) resList.Add("Name2");
            if (this.Kana != target.Kana) resList.Add("Kana");
            if (this.SexCode != target.SexCode) resList.Add("SexCode");
            if (this.SexName != target.SexName) resList.Add("SexName");
            if (this.Birthday != target.Birthday) resList.Add("Birthday");
            if (this.PostNo != target.PostNo) resList.Add("PostNo");
            if (this.AddressCode1Upper != target.AddressCode1Upper) resList.Add("AddressCode1Upper");
            if (this.WebDspAddrADOJp != target.WebDspAddrADOJp) resList.Add("WebDspAddrADOJp");
            if (this.WebDspAddrCity != target.WebDspAddrCity) resList.Add("WebDspAddrCity");
            if (this.WebDspAddrBuil != target.WebDspAddrBuil) resList.Add("WebDspAddrBuil");
            if (this.JobTypeCode != target.JobTypeCode) resList.Add("JobTypeCode");
            if (this.BusinessTypeCode != target.BusinessTypeCode) resList.Add("BusinessTypeCode");
            if (this.HomeTelNo != target.HomeTelNo) resList.Add("HomeTelNo");
            if (this.OfficeTelNo != target.OfficeTelNo) resList.Add("OfficeTelNo");
            if (this.PortableTelNo != target.PortableTelNo) resList.Add("PortableTelNo");
            if (this.HomeFaxNo != target.HomeFaxNo) resList.Add("HomeFaxNo");
            if (this.OfficeFaxNo != target.OfficeFaxNo) resList.Add("OfficeFaxNo");
            if (this.MailAddress1 != target.MailAddress1) resList.Add("MailAddress1");
            if (this.MailAddrKindCode1 != target.MailAddrKindCode1) resList.Add("MailAddrKindCode1");
            if (this.MailAddress2 != target.MailAddress2) resList.Add("MailAddress2");
            if (this.MailAddrKindCode2 != target.MailAddrKindCode2) resList.Add("MailAddrKindCode2");
            if (this.MailAddress3 != target.MailAddress3) resList.Add("MailAddress3");
            if (this.MailAddrKindCode3 != target.MailAddrKindCode3) resList.Add("MailAddrKindCode3");
            if (this.EnterpriseCode != target.EnterpriseCode) resList.Add("EnterpriseCode");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            if (this.JobTypeName != target.JobTypeName) resList.Add("JobTypeName");
            if (this.BusinessTypeName != target.BusinessTypeName) resList.Add("BusinessTypeName");

            return resList;
        }

        /// <summary>
        /// 簡単問合せID付属情報マスタ(基本情報)比較処理
        /// </summary>
        /// <param name="smplInqBas1">比較するSmplInqBasクラスのインスタンス</param>
        /// <param name="smplInqBas2">比較するSmplInqBasクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SmplInqBasクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static ArrayList Compare(SmplInqBas smplInqBas1, SmplInqBas smplInqBas2)
        {
            ArrayList resList = new ArrayList();
            if (smplInqBas1.CreateDateTime != smplInqBas2.CreateDateTime) resList.Add("CreateDateTime");
            if (smplInqBas1.UpdateDateTime != smplInqBas2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (smplInqBas1.LogicalDeleteCode != smplInqBas2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (smplInqBas1.SimpleInqIdInfMngNo != smplInqBas2.SimpleInqIdInfMngNo) resList.Add("SimpleInqIdInfMngNo");
            if (smplInqBas1.Name != smplInqBas2.Name) resList.Add("Name");
            if (smplInqBas1.Name2 != smplInqBas2.Name2) resList.Add("Name2");
            if (smplInqBas1.Kana != smplInqBas2.Kana) resList.Add("Kana");
            if (smplInqBas1.SexCode != smplInqBas2.SexCode) resList.Add("SexCode");
            if (smplInqBas1.SexName != smplInqBas2.SexName) resList.Add("SexName");
            if (smplInqBas1.Birthday != smplInqBas2.Birthday) resList.Add("Birthday");
            if (smplInqBas1.PostNo != smplInqBas2.PostNo) resList.Add("PostNo");
            if (smplInqBas1.AddressCode1Upper != smplInqBas2.AddressCode1Upper) resList.Add("AddressCode1Upper");
            if (smplInqBas1.WebDspAddrADOJp != smplInqBas2.WebDspAddrADOJp) resList.Add("WebDspAddrADOJp");
            if (smplInqBas1.WebDspAddrCity != smplInqBas2.WebDspAddrCity) resList.Add("WebDspAddrCity");
            if (smplInqBas1.WebDspAddrBuil != smplInqBas2.WebDspAddrBuil) resList.Add("WebDspAddrBuil");
            if (smplInqBas1.JobTypeCode != smplInqBas2.JobTypeCode) resList.Add("JobTypeCode");
            if (smplInqBas1.BusinessTypeCode != smplInqBas2.BusinessTypeCode) resList.Add("BusinessTypeCode");
            if (smplInqBas1.HomeTelNo != smplInqBas2.HomeTelNo) resList.Add("HomeTelNo");
            if (smplInqBas1.OfficeTelNo != smplInqBas2.OfficeTelNo) resList.Add("OfficeTelNo");
            if (smplInqBas1.PortableTelNo != smplInqBas2.PortableTelNo) resList.Add("PortableTelNo");
            if (smplInqBas1.HomeFaxNo != smplInqBas2.HomeFaxNo) resList.Add("HomeFaxNo");
            if (smplInqBas1.OfficeFaxNo != smplInqBas2.OfficeFaxNo) resList.Add("OfficeFaxNo");
            if (smplInqBas1.MailAddress1 != smplInqBas2.MailAddress1) resList.Add("MailAddress1");
            if (smplInqBas1.MailAddrKindCode1 != smplInqBas2.MailAddrKindCode1) resList.Add("MailAddrKindCode1");
            if (smplInqBas1.MailAddress2 != smplInqBas2.MailAddress2) resList.Add("MailAddress2");
            if (smplInqBas1.MailAddrKindCode2 != smplInqBas2.MailAddrKindCode2) resList.Add("MailAddrKindCode2");
            if (smplInqBas1.MailAddress3 != smplInqBas2.MailAddress3) resList.Add("MailAddress3");
            if (smplInqBas1.MailAddrKindCode3 != smplInqBas2.MailAddrKindCode3) resList.Add("MailAddrKindCode3");
            if (smplInqBas1.EnterpriseCode != smplInqBas2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (smplInqBas1.EnterpriseName != smplInqBas2.EnterpriseName) resList.Add("EnterpriseName");
            if (smplInqBas1.JobTypeName != smplInqBas2.JobTypeName) resList.Add("JobTypeName");
            if (smplInqBas1.BusinessTypeName != smplInqBas2.BusinessTypeName) resList.Add("BusinessTypeName");

            return resList;
        }
    }
}
