using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
	/// public class name:   MailBackup
	/// <summary>
	///                      メールバックアップマスタ
	/// </summary>
	/// <remarks>
	/// <br>note             :   メールバックアップマスタヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   2006/9/29</br>
	/// <br>Genarated Date   :   2006/10/23  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	public class MailBackup
    {

        // 自動生成以外のプロパティ(消さないでください)
        #region 自動生成以外のプロパティ(消さないでください)


        /// <summary>
        /// メールステータス定義 0:新規
        /// </summary>
        public static int MailBackup_MailStatus_NEW = 0;

        /// <summary>
        /// メールステータス定義 5:エラー未送信
        /// </summary>
        public static int MailBackup_MailStatus_ERROR = 5;


        #endregion


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

		/// <summary>送信拠点コード</summary>
		private string _sendSectionCode = "";

		/// <summary>メール管理連番</summary>
		private Int32 _mailManagementConsNo;

		/// <summary>メールステータス</summary>
		/// <remarks>0:新規, 5:エラー未送信</remarks>
		private Int32 _mailStatus;

		/// <summary>送信日時</summary>
		/// <remarks>200601011212(西暦日付＋時分）</remarks>
		private Int64 _sendDateTime;

		/// <summary>得意先コード</summary>
		private Int32 _customerCode;

		/// <summary>名称</summary>
		private string _name = "";

		/// <summary>名称2</summary>
		private string _name2 = "";

		/// <summary>敬称</summary>
		private string _honorificTitle = "";

		/// <summary>カナ</summary>
		private string _kana = "";

		/// <summary>車両管理番号</summary>
		private Int32 _carMngNo;

		/// <summary>陸運事務所番号</summary>
		private Int32 _numberPlate1Code;

		/// <summary>陸運事務局名称</summary>
		private string _numberPlate1Name = "";

		/// <summary>車両登録番号（種別）</summary>
		private string _numberPlate2 = "";

		/// <summary>車両登録番号（カナ）</summary>
		private string _numberPlate3 = "";

		/// <summary>車両登録番号（プレート番号）</summary>
		private Int32 _numberPlate4;

		/// <summary>メーカー名称</summary>
		private string _makerName = "";

		/// <summary>車種名</summary>
		private string _modelName = "";

		/// <summary>メールアドレス</summary>
		/// <remarks>自端末のメールアドレス</remarks>
		private string _mailAddress = "";

		/// <summary>メールアドレス種別コード</summary>
		/// <remarks>0:自宅,1:会社,2:携帯端末,3:本人以外,99:その他</remarks>
		private Int32 _mailAddrKindCode1;

		/// <summary>メールアドレス種別名称</summary>
		private string _mailAddrKindName1 = "";

		/// <summary>メール送信区分コード</summary>
		/// <remarks>0:非送信,1:送信</remarks>
		private Int32 _mailSendCode1;

		/// <summary>メール形式</summary>
		/// <remarks>0:Text,1:HTML</remarks>
		private Int32 _mailFormal;

		/// <summary>抽出アセンブリ区分</summary>
		private string _extraAssemblyDivide = "";

		/// <summary>メール文書番号</summary>
		private Int32 _mailDocumentNo;

		/// <summary>メール文書区分</summary>
		/// <remarks>0:メール文書,1:携帯メール文書,2:署名</remarks>
		private Int32 _mailDocCode;

		/// <summary>点検種別</summary>
		/// <remarks>1:車検,2法定,3:新車,4:一般点検,9:DM区分</remarks>
		private Int32 _checkKindCode;

		/// <summary>点検区分</summary>
		/// <remarks>0:一般,3:3点,6:6点,12:12点,24:24点</remarks>
		private Int32 _checkDivCd;

		/// <summary>メールタイトル</summary>
		/// <remarks>nvarchar(max)</remarks>
		private string _mailTitle;

		/// <summary>メール文書</summary>
		/// <remarks>nvarchar(max)</remarks>
		private string _mailDocumentCnts;

		/// <summary>企業名称</summary>
		private string _enterpriseName = "";

		/// <summary>更新従業員名称</summary>
		private string _updEmployeeName = "";

        /// <summary>メール管理Guid</summary>
        /// <remarks>Guid</remarks>
        private Guid _mailMngGuid;

        /// <summary>CC</summary>
        private string _carbonCopy = "";

        /// <summary>添付ファイル</summary>
        private string _attachFile = "";

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
			get{return TDateTime.DateTimeToString("GGYYMMDD", _createDateTime);}
			set{}
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
			get{return TDateTime.DateTimeToString("ggYY/MM/DD", _createDateTime);}
			set{}
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
			get{return TDateTime.DateTimeToString("YYYY/MM/DD", _createDateTime);}
			set{}
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
			get{return TDateTime.DateTimeToString("YY/MM/DD", _createDateTime);}
			set{}
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
			get{return TDateTime.DateTimeToString("GGYYMMDD", _updateDateTime);}
			set{}
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
			get{return TDateTime.DateTimeToString("ggYY/MM/DD", _updateDateTime);}
			set{}
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
			get{return TDateTime.DateTimeToString("YYYY/MM/DD", _updateDateTime);}
			set{}
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
			get{return TDateTime.DateTimeToString("YY/MM/DD", _updateDateTime);}
			set{}
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

		/// public propaty name  :  SendSectionCode
		/// <summary>送信拠点コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   送信拠点コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string SendSectionCode
		{
			get{return _sendSectionCode;}
			set{_sendSectionCode = value;}
		}

		/// public propaty name  :  MailManagementConsNo
		/// <summary>メール管理連番プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   メール管理連番プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 MailManagementConsNo
		{
			get{return _mailManagementConsNo;}
			set{_mailManagementConsNo = value;}
		}

		/// public propaty name  :  MailStatus
		/// <summary>メールステータスプロパティ</summary>
		/// <value>0:新規, 5:エラー未送信</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   メールステータスプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 MailStatus
		{
			get{return _mailStatus;}
			set{_mailStatus = value;}
		}

		/// public propaty name  :  SendDateTime
		/// <summary>送信日時プロパティ</summary>
		/// <value>200601011212(西暦日付＋時分）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   送信日時プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 SendDateTime
		{
			get{return _sendDateTime;}
			set{_sendDateTime = value;}
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
			get{return _customerCode;}
			set{_customerCode = value;}
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
			get{return _name;}
			set{_name = value;}
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
			get{return _name2;}
			set{_name2 = value;}
		}

		/// public propaty name  :  HonorificTitle
		/// <summary>敬称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   敬称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string HonorificTitle
		{
			get{return _honorificTitle;}
			set{_honorificTitle = value;}
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
			get{return _kana;}
			set{_kana = value;}
		}

		/// public propaty name  :  CarMngNo
		/// <summary>車両管理番号プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   車両管理番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 CarMngNo
		{
			get{return _carMngNo;}
			set{_carMngNo = value;}
		}

		/// public propaty name  :  NumberPlate1Code
		/// <summary>陸運事務所番号プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   陸運事務所番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 NumberPlate1Code
		{
			get{return _numberPlate1Code;}
			set{_numberPlate1Code = value;}
		}

		/// public propaty name  :  NumberPlate1Name
		/// <summary>陸運事務局名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   陸運事務局名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string NumberPlate1Name
		{
			get{return _numberPlate1Name;}
			set{_numberPlate1Name = value;}
		}

		/// public propaty name  :  NumberPlate2
		/// <summary>車両登録番号（種別）プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   車両登録番号（種別）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string NumberPlate2
		{
			get{return _numberPlate2;}
			set{_numberPlate2 = value;}
		}

		/// public propaty name  :  NumberPlate3
		/// <summary>車両登録番号（カナ）プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   車両登録番号（カナ）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string NumberPlate3
		{
			get{return _numberPlate3;}
			set{_numberPlate3 = value;}
		}

		/// public propaty name  :  NumberPlate4
		/// <summary>車両登録番号（プレート番号）プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   車両登録番号（プレート番号）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 NumberPlate4
		{
			get{return _numberPlate4;}
			set{_numberPlate4 = value;}
		}

		/// public propaty name  :  MakerName
		/// <summary>メーカー名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   メーカー名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string MakerName
		{
			get{return _makerName;}
			set{_makerName = value;}
		}

		/// public propaty name  :  ModelName
		/// <summary>車種名プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   車種名プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string ModelName
		{
			get{return _modelName;}
			set{_modelName = value;}
		}

		/// public propaty name  :  MailAddress
		/// <summary>メールアドレスプロパティ</summary>
		/// <value>自端末のメールアドレス</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   メールアドレスプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string MailAddress
		{
			get{return _mailAddress;}
			set{_mailAddress = value;}
		}

		/// public propaty name  :  MailAddrKindCode1
		/// <summary>メールアドレス種別コードプロパティ</summary>
		/// <value>0:自宅,1:会社,2:携帯端末,3:本人以外,99:その他</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   メールアドレス種別コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 MailAddrKindCode1
		{
			get{return _mailAddrKindCode1;}
			set{_mailAddrKindCode1 = value;}
		}

		/// public propaty name  :  MailAddrKindName1
		/// <summary>メールアドレス種別名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   メールアドレス種別名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string MailAddrKindName1
		{
			get{return _mailAddrKindName1;}
			set{_mailAddrKindName1 = value;}
		}

		/// public propaty name  :  MailSendCode1
		/// <summary>メール送信区分コードプロパティ</summary>
		/// <value>0:非送信,1:送信</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   メール送信区分コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 MailSendCode1
		{
			get{return _mailSendCode1;}
			set{_mailSendCode1 = value;}
		}

		/// public propaty name  :  MailFormal
		/// <summary>メール形式プロパティ</summary>
		/// <value>0:Text,1:HTML</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   メール形式プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 MailFormal
		{
			get{return _mailFormal;}
			set{_mailFormal = value;}
		}

		/// public propaty name  :  ExtraAssemblyDivide
		/// <summary>抽出アセンブリ区分プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   抽出アセンブリ区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string ExtraAssemblyDivide
		{
			get{return _extraAssemblyDivide;}
			set{_extraAssemblyDivide = value;}
		}

		/// public propaty name  :  MailDocumentNo
		/// <summary>メール文書番号プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   メール文書番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 MailDocumentNo
		{
			get{return _mailDocumentNo;}
			set{_mailDocumentNo = value;}
		}

		/// public propaty name  :  MailDocCode
		/// <summary>メール文書区分プロパティ</summary>
		/// <value>0:メール文書,1:携帯メール文書,2:署名</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   メール文書区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 MailDocCode
		{
			get{return _mailDocCode;}
			set{_mailDocCode = value;}
		}

		/// public propaty name  :  CheckKindCode
		/// <summary>点検種別プロパティ</summary>
		/// <value>1:車検,2法定,3:新車,4:一般点検,9:DM区分</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   点検種別プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 CheckKindCode
		{
			get{return _checkKindCode;}
			set{_checkKindCode = value;}
		}

		/// public propaty name  :  CheckDivCd
		/// <summary>点検区分プロパティ</summary>
		/// <value>0:一般,3:3点,6:6点,12:12点,24:24点</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   点検区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 CheckDivCd
		{
			get{return _checkDivCd;}
			set{_checkDivCd = value;}
		}

		/// public propaty name  :  MailTitle
		/// <summary>メールタイトルプロパティ</summary>
		/// <value>nvarchar(max)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   メールタイトルプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string MailTitle
		{
			get{return _mailTitle;}
			set{_mailTitle = value;}
		}

		/// public propaty name  :  MailDocumentCnts
		/// <summary>メール文書プロパティ</summary>
		/// <value>nvarchar(max)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   メール文書プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string MailDocumentCnts
		{
			get{return _mailDocumentCnts;}
			set{_mailDocumentCnts = value;}
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

        /// public propaty name  :  MailMngGuid
        /// <summary>メール管理Guid</summary>
        /// <value>Guid</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メール文書プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Guid MailMngGuid
        {
            get { return _mailMngGuid; }
            set { _mailMngGuid = value; }
        }

        /// <summary>CC</summary>
        /// public propaty name  :  CarbonCopy
        /// <summary>CC</summary>
        /// <value>string</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メール文書プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CarbonCopy
        {
            get { return _carbonCopy; }
            set { _carbonCopy = value; }
        }

        /// <summary>添付ファイル</summary>
        /// public propaty name  :  AttachFile
        /// <summary>添付ファイル</summary>
        /// <value>string</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メール文書プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AttachFile
        {
            get { return _attachFile; }
            set { _attachFile = value; }
        }


		/// <summary>
		/// メールバックアップマスタコンストラクタ
		/// </summary>
		/// <returns>MailBackupクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   MailBackupクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public MailBackup()
		{


		}

		/// <summary>
		/// メールバックアップマスタコンストラクタ
		/// </summary>
		/// <param name="createDateTime">作成日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
		/// <param name="updateDateTime">更新日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
		/// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
		/// <param name="fileHeaderGuid">GUID(共通ファイルヘッダ)</param>
		/// <param name="updEmployeeCode">更新従業員コード(共通ファイルヘッダ)</param>
		/// <param name="updAssemblyId1">更新アセンブリID1(共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）)</param>
		/// <param name="updAssemblyId2">更新アセンブリID2(共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）)</param>
		/// <param name="logicalDeleteCode">論理削除区分(共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除))</param>
		/// <param name="sendSectionCode">送信拠点コード</param>
		/// <param name="mailManagementConsNo">メール管理連番</param>
		/// <param name="mailStatus">メールステータス(0:新規, 5:エラー未送信)</param>
		/// <param name="sendDateTime">送信日時(200601011212(西暦日付＋時分）)</param>
		/// <param name="customerCode">得意先コード</param>
		/// <param name="name">名称</param>
		/// <param name="name2">名称2</param>
		/// <param name="honorificTitle">敬称</param>
		/// <param name="kana">カナ</param>
		/// <param name="carMngNo">車両管理番号</param>
		/// <param name="numberPlate1Code">陸運事務所番号</param>
		/// <param name="numberPlate1Name">陸運事務局名称</param>
		/// <param name="numberPlate2">車両登録番号（種別）</param>
		/// <param name="numberPlate3">車両登録番号（カナ）</param>
		/// <param name="numberPlate4">車両登録番号（プレート番号）</param>
		/// <param name="makerName">メーカー名称</param>
		/// <param name="modelName">車種名</param>
		/// <param name="mailAddress">メールアドレス(自端末のメールアドレス)</param>
		/// <param name="mailAddrKindCode1">メールアドレス種別コード(0:自宅,1:会社,2:携帯端末,3:本人以外,99:その他)</param>
		/// <param name="mailAddrKindName1">メールアドレス種別名称</param>
		/// <param name="mailSendCode1">メール送信区分コード(0:非送信,1:送信)</param>
		/// <param name="mailFormal">メール形式(0:Text,1:HTML)</param>
		/// <param name="extraAssemblyDivide">抽出アセンブリ区分</param>
		/// <param name="mailDocumentNo">メール文書番号</param>
		/// <param name="mailDocCode">メール文書区分(0:メール文書,1:携帯メール文書,2:署名)</param>
		/// <param name="checkKindCode">点検種別(1:車検,2法定,3:新車,4:一般点検,9:DM区分)</param>
		/// <param name="checkDivCd">点検区分(0:一般,3:3点,6:6点,12:12点,24:24点)</param>
		/// <param name="mailTitle">メールタイトル(nvarchar(max))</param>
		/// <param name="mailDocumentCnts">メール文書(nvarchar(max))</param>
		/// <param name="enterpriseName">企業名称</param>
		/// <param name="updEmployeeName">更新従業員名称</param>
		/// <returns>MailBackupクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   MailBackupクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public MailBackup(DateTime createDateTime,DateTime updateDateTime,string enterpriseCode,Guid fileHeaderGuid,string updEmployeeCode,string updAssemblyId1,string updAssemblyId2,Int32 logicalDeleteCode,string sendSectionCode,Int32 mailManagementConsNo,Int32 mailStatus,Int64 sendDateTime,Int32 customerCode,string name,string name2,string honorificTitle,string kana,Int32 carMngNo,Int32 numberPlate1Code,string numberPlate1Name,string numberPlate2,string numberPlate3,Int32 numberPlate4,string makerName,string modelName,string mailAddress,Int32 mailAddrKindCode1,string mailAddrKindName1,Int32 mailSendCode1,Int32 mailFormal,string extraAssemblyDivide,Int32 mailDocumentNo,Int32 mailDocCode,Int32 checkKindCode,Int32 checkDivCd,string mailTitle,string mailDocumentCnts,string enterpriseName,string updEmployeeName)
		{
			this.CreateDateTime = createDateTime;
			this.UpdateDateTime = updateDateTime;
			this._enterpriseCode = enterpriseCode;
			this._fileHeaderGuid = fileHeaderGuid;
			this._updEmployeeCode = updEmployeeCode;
			this._updAssemblyId1 = updAssemblyId1;
			this._updAssemblyId2 = updAssemblyId2;
			this._logicalDeleteCode = logicalDeleteCode;
			this._sendSectionCode = sendSectionCode;
			this._mailManagementConsNo = mailManagementConsNo;
			this._mailStatus = mailStatus;
			this._sendDateTime = sendDateTime;
			this._customerCode = customerCode;
			this._name = name;
			this._name2 = name2;
			this._honorificTitle = honorificTitle;
			this._kana = kana;
			this._carMngNo = carMngNo;
			this._numberPlate1Code = numberPlate1Code;
			this._numberPlate1Name = numberPlate1Name;
			this._numberPlate2 = numberPlate2;
			this._numberPlate3 = numberPlate3;
			this._numberPlate4 = numberPlate4;
			this._makerName = makerName;
			this._modelName = modelName;
			this._mailAddress = mailAddress;
			this._mailAddrKindCode1 = mailAddrKindCode1;
			this._mailAddrKindName1 = mailAddrKindName1;
			this._mailSendCode1 = mailSendCode1;
			this._mailFormal = mailFormal;
			this._extraAssemblyDivide = extraAssemblyDivide;
			this._mailDocumentNo = mailDocumentNo;
			this._mailDocCode = mailDocCode;
			this._checkKindCode = checkKindCode;
			this._checkDivCd = checkDivCd;
			this._mailTitle = mailTitle;
			this._mailDocumentCnts = mailDocumentCnts;
			this._enterpriseName = enterpriseName;
			this._updEmployeeName = updEmployeeName;
		}


        // 2008.07.01 R.Sokei ADD >>>>
        /// <summary>
        /// メールバックアップマスタコンストラクタ
        /// </summary>
        /// <param name="createDateTime">作成日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="updateDateTime">更新日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
        /// <param name="fileHeaderGuid">GUID(共通ファイルヘッダ)</param>
        /// <param name="updEmployeeCode">更新従業員コード(共通ファイルヘッダ)</param>
        /// <param name="updAssemblyId1">更新アセンブリID1(共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）)</param>
        /// <param name="updAssemblyId2">更新アセンブリID2(共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）)</param>
        /// <param name="logicalDeleteCode">論理削除区分(共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除))</param>
        /// <param name="sendSectionCode">送信拠点コード</param>
        /// <param name="mailManagementConsNo">メール管理連番</param>
        /// <param name="mailStatus">メールステータス(0:新規, 5:エラー未送信)</param>
        /// <param name="sendDateTime">送信日時(200601011212(西暦日付＋時分）)</param>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="name">名称</param>
        /// <param name="name2">名称2</param>
        /// <param name="honorificTitle">敬称</param>
        /// <param name="kana">カナ</param>
        /// <param name="carMngNo">車両管理番号</param>
        /// <param name="numberPlate1Code">陸運事務所番号</param>
        /// <param name="numberPlate1Name">陸運事務局名称</param>
        /// <param name="numberPlate2">車両登録番号（種別）</param>
        /// <param name="numberPlate3">車両登録番号（カナ）</param>
        /// <param name="numberPlate4">車両登録番号（プレート番号）</param>
        /// <param name="makerName">メーカー名称</param>
        /// <param name="modelName">車種名</param>
        /// <param name="mailAddress">メールアドレス(自端末のメールアドレス)</param>
        /// <param name="mailAddrKindCode1">メールアドレス種別コード(0:自宅,1:会社,2:携帯端末,3:本人以外,99:その他)</param>
        /// <param name="mailAddrKindName1">メールアドレス種別名称</param>
        /// <param name="mailSendCode1">メール送信区分コード(0:非送信,1:送信)</param>
        /// <param name="mailFormal">メール形式(0:Text,1:HTML)</param>
        /// <param name="extraAssemblyDivide">抽出アセンブリ区分</param>
        /// <param name="mailDocumentNo">メール文書番号</param>
        /// <param name="mailDocCode">メール文書区分(0:メール文書,1:携帯メール文書,2:署名)</param>
        /// <param name="checkKindCode">点検種別(1:車検,2法定,3:新車,4:一般点検,9:DM区分)</param>
        /// <param name="checkDivCd">点検区分(0:一般,3:3点,6:6点,12:12点,24:24点)</param>
        /// <param name="mailTitle">メールタイトル(nvarchar(max))</param>
        /// <param name="mailDocumentCnts">メール文書(nvarchar(max))</param>
        /// <param name="enterpriseName">企業名称</param>
        /// <param name="updEmployeeName">更新従業員名称</param>
        /// <param name="mailMngGuid">メール管理Guid</param>
        /// <param name="carbonCopy">CC</param>
        /// <param name="attachFile">添付ファイル</param>
        /// <returns>MailBackupクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   MailBackupクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public MailBackup(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, string sendSectionCode, Int32 mailManagementConsNo, Int32 mailStatus, Int64 sendDateTime, Int32 customerCode, string name, string name2, string honorificTitle, string kana, Int32 carMngNo, Int32 numberPlate1Code, string numberPlate1Name, string numberPlate2, string numberPlate3, Int32 numberPlate4, string makerName, string modelName, string mailAddress, Int32 mailAddrKindCode1, string mailAddrKindName1, Int32 mailSendCode1, Int32 mailFormal, string extraAssemblyDivide, Int32 mailDocumentNo, Int32 mailDocCode, Int32 checkKindCode, Int32 checkDivCd, string mailTitle, string mailDocumentCnts, string enterpriseName, string updEmployeeName, Guid mailMngGuid, string carbonCopy, string attachFile)
        {
            this.CreateDateTime = createDateTime;
            this.UpdateDateTime = updateDateTime;
            this._enterpriseCode = enterpriseCode;
            this._fileHeaderGuid = fileHeaderGuid;
            this._updEmployeeCode = updEmployeeCode;
            this._updAssemblyId1 = updAssemblyId1;
            this._updAssemblyId2 = updAssemblyId2;
            this._logicalDeleteCode = logicalDeleteCode;
            this._sendSectionCode = sendSectionCode;
            this._mailManagementConsNo = mailManagementConsNo;
            this._mailStatus = mailStatus;
            this._sendDateTime = sendDateTime;
            this._customerCode = customerCode;
            this._name = name;
            this._name2 = name2;
            this._honorificTitle = honorificTitle;
            this._kana = kana;
            this._carMngNo = carMngNo;
            this._numberPlate1Code = numberPlate1Code;
            this._numberPlate1Name = numberPlate1Name;
            this._numberPlate2 = numberPlate2;
            this._numberPlate3 = numberPlate3;
            this._numberPlate4 = numberPlate4;
            this._makerName = makerName;
            this._modelName = modelName;
            this._mailAddress = mailAddress;
            this._mailAddrKindCode1 = mailAddrKindCode1;
            this._mailAddrKindName1 = mailAddrKindName1;
            this._mailSendCode1 = mailSendCode1;
            this._mailFormal = mailFormal;
            this._extraAssemblyDivide = extraAssemblyDivide;
            this._mailDocumentNo = mailDocumentNo;
            this._mailDocCode = mailDocCode;
            this._checkKindCode = checkKindCode;
            this._checkDivCd = checkDivCd;
            this._mailTitle = mailTitle;
            this._mailDocumentCnts = mailDocumentCnts;
            this._enterpriseName = enterpriseName;
            this._updEmployeeName = updEmployeeName;
            this._mailMngGuid = mailMngGuid;
            this._carbonCopy = carbonCopy;
            this._attachFile = attachFile;
        }
        // 2008.07.01 R.Sokei ADD <<<<



		/// <summary>
		/// メールバックアップマスタ複製処理
		/// </summary>
		/// <returns>MailBackupクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   自身の内容と等しいMailBackupクラスのインスタンスを返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
        public MailBackup Clone()
        {
            //			return new MailBackup(this._createDateTime,this._updateDateTime,this._enterpriseCode,this._fileHeaderGuid,this._updEmployeeCode,this._updAssemblyId1,this._updAssemblyId2,this._logicalDeleteCode,this._sendSectionCode,this._mailManagementConsNo,this._mailStatus,this._sendDateTime,this._customerCode,this._name,this._name2,this._honorificTitle,this._kana,this._carMngNo,this._numberPlate1Code,this._numberPlate1Name,this._numberPlate2,this._numberPlate3,this._numberPlate4,this._makerName,this._modelName,this._mailAddress,this._mailAddrKindCode1,this._mailAddrKindName1,this._mailSendCode1,this._mailFormal,this._extraAssemblyDivide,this._mailDocumentNo,this._mailDocCode,this._checkKindCode,this._checkDivCd,this._mailTitle,this._mailDocumentCnts,this._enterpriseName,this._updEmployeeName,this._mailMngGuid);
            // 2008.07.01 R.Sokei ADD >>>>
            return new MailBackup(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._sendSectionCode, this._mailManagementConsNo, this._mailStatus, this._sendDateTime, this._customerCode, this._name, this._name2, this._honorificTitle, this._kana, this._carMngNo, this._numberPlate1Code, this._numberPlate1Name, this._numberPlate2, this._numberPlate3, this._numberPlate4, this._makerName, this._modelName, this._mailAddress, this._mailAddrKindCode1, this._mailAddrKindName1, this._mailSendCode1, this._mailFormal, this._extraAssemblyDivide, this._mailDocumentNo, this._mailDocCode, this._checkKindCode, this._checkDivCd, this._mailTitle, this._mailDocumentCnts, this._enterpriseName, this._updEmployeeName, this._mailMngGuid, this._carbonCopy, this._attachFile);
            // 2008.07.01 R.Sokei ADD <<<<

        }

		/// <summary>
		/// メールバックアップマスタ比較処理
		/// </summary>
		/// <param name="target">比較対象のMailBackupクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   MailBackupクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
        public bool Equals(MailBackup target)
        {
            return ((this.CreateDateTime == target.CreateDateTime)
                 && (this.UpdateDateTime == target.UpdateDateTime)
                 && (this.EnterpriseCode == target.EnterpriseCode)
                 && (this.FileHeaderGuid == target.FileHeaderGuid)
                 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
                 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
                 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
                 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
                 && (this.SendSectionCode == target.SendSectionCode)
                 && (this.MailManagementConsNo == target.MailManagementConsNo)
                 && (this.MailStatus == target.MailStatus)
                 && (this.SendDateTime == target.SendDateTime)
                 && (this.CustomerCode == target.CustomerCode)
                 && (this.Name == target.Name)
                 && (this.Name2 == target.Name2)
                 && (this.HonorificTitle == target.HonorificTitle)
                 && (this.Kana == target.Kana)
                 && (this.CarMngNo == target.CarMngNo)
                 && (this.NumberPlate1Code == target.NumberPlate1Code)
                 && (this.NumberPlate1Name == target.NumberPlate1Name)
                 && (this.NumberPlate2 == target.NumberPlate2)
                 && (this.NumberPlate3 == target.NumberPlate3)
                 && (this.NumberPlate4 == target.NumberPlate4)
                 && (this.MakerName == target.MakerName)
                 && (this.ModelName == target.ModelName)
                 && (this.MailAddress == target.MailAddress)
                 && (this.MailAddrKindCode1 == target.MailAddrKindCode1)
                 && (this.MailAddrKindName1 == target.MailAddrKindName1)
                 && (this.MailSendCode1 == target.MailSendCode1)
                 && (this.MailFormal == target.MailFormal)
                 && (this.ExtraAssemblyDivide == target.ExtraAssemblyDivide)
                 && (this.MailDocumentNo == target.MailDocumentNo)
                 && (this.MailDocCode == target.MailDocCode)
                 && (this.CheckKindCode == target.CheckKindCode)
                 && (this.CheckDivCd == target.CheckDivCd)
                 && (this.MailTitle == target.MailTitle)
                 && (this.MailDocumentCnts == target.MailDocumentCnts)
                 && (this.EnterpriseName == target.EnterpriseName)
                 && (this.UpdEmployeeName == target.UpdEmployeeName)
                 // 2008.07.01 R.Sokei ADD >>>>
                 && (this.MailMngGuid == target.MailMngGuid)
                 // 2008.07.01 R.Sokei ADD <<<<
                 && (this.CarbonCopy == target.CarbonCopy)
                 && (this.AttachFile == target.AttachFile));
        }

		/// <summary>
		/// メールバックアップマスタ比較処理
		/// </summary>
		/// <param name="mailBackup1">
		///                    比較するMailBackupクラスのインスタンス
		/// </param>
		/// <param name="mailBackup2">比較するMailBackupクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   MailBackupクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
        public static bool Equals(MailBackup mailBackup1, MailBackup mailBackup2)
        {
            return ((mailBackup1.CreateDateTime == mailBackup2.CreateDateTime)
                 && (mailBackup1.UpdateDateTime == mailBackup2.UpdateDateTime)
                 && (mailBackup1.EnterpriseCode == mailBackup2.EnterpriseCode)
                 && (mailBackup1.FileHeaderGuid == mailBackup2.FileHeaderGuid)
                 && (mailBackup1.UpdEmployeeCode == mailBackup2.UpdEmployeeCode)
                 && (mailBackup1.UpdAssemblyId1 == mailBackup2.UpdAssemblyId1)
                 && (mailBackup1.UpdAssemblyId2 == mailBackup2.UpdAssemblyId2)
                 && (mailBackup1.LogicalDeleteCode == mailBackup2.LogicalDeleteCode)
                 && (mailBackup1.SendSectionCode == mailBackup2.SendSectionCode)
                 && (mailBackup1.MailManagementConsNo == mailBackup2.MailManagementConsNo)
                 && (mailBackup1.MailStatus == mailBackup2.MailStatus)
                 && (mailBackup1.SendDateTime == mailBackup2.SendDateTime)
                 && (mailBackup1.CustomerCode == mailBackup2.CustomerCode)
                 && (mailBackup1.Name == mailBackup2.Name)
                 && (mailBackup1.Name2 == mailBackup2.Name2)
                 && (mailBackup1.HonorificTitle == mailBackup2.HonorificTitle)
                 && (mailBackup1.Kana == mailBackup2.Kana)
                 && (mailBackup1.CarMngNo == mailBackup2.CarMngNo)
                 && (mailBackup1.NumberPlate1Code == mailBackup2.NumberPlate1Code)
                 && (mailBackup1.NumberPlate1Name == mailBackup2.NumberPlate1Name)
                 && (mailBackup1.NumberPlate2 == mailBackup2.NumberPlate2)
                 && (mailBackup1.NumberPlate3 == mailBackup2.NumberPlate3)
                 && (mailBackup1.NumberPlate4 == mailBackup2.NumberPlate4)
                 && (mailBackup1.MakerName == mailBackup2.MakerName)
                 && (mailBackup1.ModelName == mailBackup2.ModelName)
                 && (mailBackup1.MailAddress == mailBackup2.MailAddress)
                 && (mailBackup1.MailAddrKindCode1 == mailBackup2.MailAddrKindCode1)
                 && (mailBackup1.MailAddrKindName1 == mailBackup2.MailAddrKindName1)
                 && (mailBackup1.MailSendCode1 == mailBackup2.MailSendCode1)
                 && (mailBackup1.MailFormal == mailBackup2.MailFormal)
                 && (mailBackup1.ExtraAssemblyDivide == mailBackup2.ExtraAssemblyDivide)
                 && (mailBackup1.MailDocumentNo == mailBackup2.MailDocumentNo)
                 && (mailBackup1.MailDocCode == mailBackup2.MailDocCode)
                 && (mailBackup1.CheckKindCode == mailBackup2.CheckKindCode)
                 && (mailBackup1.CheckDivCd == mailBackup2.CheckDivCd)
                 && (mailBackup1.MailTitle == mailBackup2.MailTitle)
                 && (mailBackup1.MailDocumentCnts == mailBackup2.MailDocumentCnts)
                 && (mailBackup1.EnterpriseName == mailBackup2.EnterpriseName)
                 && (mailBackup1.UpdEmployeeName == mailBackup2.UpdEmployeeName)
                 // 2008.07.01 R.Sokei ADD >>>>
                 && (mailBackup1.MailMngGuid == mailBackup2.MailMngGuid)
                 // 2008.07.01 R.Sokei ADD <<<<
                 && (mailBackup1.CarbonCopy == mailBackup2.CarbonCopy)
                 && (mailBackup1.AttachFile == mailBackup2.AttachFile));
        }


		/// <summary>
		/// メールバックアップマスタ比較処理
		/// </summary>
		/// <param name="target">比較対象のMailBackupクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   MailBackupクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ArrayList Compare(MailBackup target)
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
			if(this.SendSectionCode != target.SendSectionCode)resList.Add("SendSectionCode");
			if(this.MailManagementConsNo != target.MailManagementConsNo)resList.Add("MailManagementConsNo");
			if(this.MailStatus != target.MailStatus)resList.Add("MailStatus");
			if(this.SendDateTime != target.SendDateTime)resList.Add("SendDateTime");
			if(this.CustomerCode != target.CustomerCode)resList.Add("CustomerCode");
			if(this.Name != target.Name)resList.Add("Name");
			if(this.Name2 != target.Name2)resList.Add("Name2");
			if(this.HonorificTitle != target.HonorificTitle)resList.Add("HonorificTitle");
			if(this.Kana != target.Kana)resList.Add("Kana");
			if(this.CarMngNo != target.CarMngNo)resList.Add("CarMngNo");
			if(this.NumberPlate1Code != target.NumberPlate1Code)resList.Add("NumberPlate1Code");
			if(this.NumberPlate1Name != target.NumberPlate1Name)resList.Add("NumberPlate1Name");
			if(this.NumberPlate2 != target.NumberPlate2)resList.Add("NumberPlate2");
			if(this.NumberPlate3 != target.NumberPlate3)resList.Add("NumberPlate3");
			if(this.NumberPlate4 != target.NumberPlate4)resList.Add("NumberPlate4");
			if(this.MakerName != target.MakerName)resList.Add("MakerName");
			if(this.ModelName != target.ModelName)resList.Add("ModelName");
			if(this.MailAddress != target.MailAddress)resList.Add("MailAddress");
			if(this.MailAddrKindCode1 != target.MailAddrKindCode1)resList.Add("MailAddrKindCode1");
			if(this.MailAddrKindName1 != target.MailAddrKindName1)resList.Add("MailAddrKindName1");
			if(this.MailSendCode1 != target.MailSendCode1)resList.Add("MailSendCode1");
			if(this.MailFormal != target.MailFormal)resList.Add("MailFormal");
			if(this.ExtraAssemblyDivide != target.ExtraAssemblyDivide)resList.Add("ExtraAssemblyDivide");
			if(this.MailDocumentNo != target.MailDocumentNo)resList.Add("MailDocumentNo");
			if(this.MailDocCode != target.MailDocCode)resList.Add("MailDocCode");
			if(this.CheckKindCode != target.CheckKindCode)resList.Add("CheckKindCode");
			if(this.CheckDivCd != target.CheckDivCd)resList.Add("CheckDivCd");
			if(this.MailTitle != target.MailTitle)resList.Add("MailTitle");
			if(this.MailDocumentCnts != target.MailDocumentCnts)resList.Add("MailDocumentCnts");
			if(this.EnterpriseName != target.EnterpriseName)resList.Add("EnterpriseName");
			if(this.UpdEmployeeName != target.UpdEmployeeName)resList.Add("UpdEmployeeName");
            // 2008.07.01 R.Sokei ADD >>>>
            if (this.MailMngGuid != target.MailMngGuid) resList.Add("MailMngGuid");
            // 2008.07.01 R.Sokei ADD <<<<
            if (this.CarbonCopy != target.CarbonCopy) resList.Add("CarbonCopy");
            if (this.AttachFile != target.AttachFile) resList.Add("AttachFile");

			return resList;
		}

		/// <summary>
		/// メールバックアップマスタ比較処理
		/// </summary>
		/// <param name="mailBackup1">比較するMailBackupクラスのインスタンス</param>
		/// <param name="mailBackup2">比較するMailBackupクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   MailBackupクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static ArrayList Compare(MailBackup mailBackup1, MailBackup mailBackup2)
		{
			ArrayList resList = new ArrayList();
			if(mailBackup1.CreateDateTime != mailBackup2.CreateDateTime)resList.Add("CreateDateTime");
			if(mailBackup1.UpdateDateTime != mailBackup2.UpdateDateTime)resList.Add("UpdateDateTime");
			if(mailBackup1.EnterpriseCode != mailBackup2.EnterpriseCode)resList.Add("EnterpriseCode");
			if(mailBackup1.FileHeaderGuid != mailBackup2.FileHeaderGuid)resList.Add("FileHeaderGuid");
			if(mailBackup1.UpdEmployeeCode != mailBackup2.UpdEmployeeCode)resList.Add("UpdEmployeeCode");
			if(mailBackup1.UpdAssemblyId1 != mailBackup2.UpdAssemblyId1)resList.Add("UpdAssemblyId1");
			if(mailBackup1.UpdAssemblyId2 != mailBackup2.UpdAssemblyId2)resList.Add("UpdAssemblyId2");
			if(mailBackup1.LogicalDeleteCode != mailBackup2.LogicalDeleteCode)resList.Add("LogicalDeleteCode");
			if(mailBackup1.SendSectionCode != mailBackup2.SendSectionCode)resList.Add("SendSectionCode");
			if(mailBackup1.MailManagementConsNo != mailBackup2.MailManagementConsNo)resList.Add("MailManagementConsNo");
			if(mailBackup1.MailStatus != mailBackup2.MailStatus)resList.Add("MailStatus");
			if(mailBackup1.SendDateTime != mailBackup2.SendDateTime)resList.Add("SendDateTime");
			if(mailBackup1.CustomerCode != mailBackup2.CustomerCode)resList.Add("CustomerCode");
			if(mailBackup1.Name != mailBackup2.Name)resList.Add("Name");
			if(mailBackup1.Name2 != mailBackup2.Name2)resList.Add("Name2");
			if(mailBackup1.HonorificTitle != mailBackup2.HonorificTitle)resList.Add("HonorificTitle");
			if(mailBackup1.Kana != mailBackup2.Kana)resList.Add("Kana");
			if(mailBackup1.CarMngNo != mailBackup2.CarMngNo)resList.Add("CarMngNo");
			if(mailBackup1.NumberPlate1Code != mailBackup2.NumberPlate1Code)resList.Add("NumberPlate1Code");
			if(mailBackup1.NumberPlate1Name != mailBackup2.NumberPlate1Name)resList.Add("NumberPlate1Name");
			if(mailBackup1.NumberPlate2 != mailBackup2.NumberPlate2)resList.Add("NumberPlate2");
			if(mailBackup1.NumberPlate3 != mailBackup2.NumberPlate3)resList.Add("NumberPlate3");
			if(mailBackup1.NumberPlate4 != mailBackup2.NumberPlate4)resList.Add("NumberPlate4");
			if(mailBackup1.MakerName != mailBackup2.MakerName)resList.Add("MakerName");
			if(mailBackup1.ModelName != mailBackup2.ModelName)resList.Add("ModelName");
			if(mailBackup1.MailAddress != mailBackup2.MailAddress)resList.Add("MailAddress");
			if(mailBackup1.MailAddrKindCode1 != mailBackup2.MailAddrKindCode1)resList.Add("MailAddrKindCode1");
			if(mailBackup1.MailAddrKindName1 != mailBackup2.MailAddrKindName1)resList.Add("MailAddrKindName1");
			if(mailBackup1.MailSendCode1 != mailBackup2.MailSendCode1)resList.Add("MailSendCode1");
			if(mailBackup1.MailFormal != mailBackup2.MailFormal)resList.Add("MailFormal");
			if(mailBackup1.ExtraAssemblyDivide != mailBackup2.ExtraAssemblyDivide)resList.Add("ExtraAssemblyDivide");
			if(mailBackup1.MailDocumentNo != mailBackup2.MailDocumentNo)resList.Add("MailDocumentNo");
			if(mailBackup1.MailDocCode != mailBackup2.MailDocCode)resList.Add("MailDocCode");
			if(mailBackup1.CheckKindCode != mailBackup2.CheckKindCode)resList.Add("CheckKindCode");
			if(mailBackup1.CheckDivCd != mailBackup2.CheckDivCd)resList.Add("CheckDivCd");
			if(mailBackup1.MailTitle != mailBackup2.MailTitle)resList.Add("MailTitle");
			if(mailBackup1.MailDocumentCnts != mailBackup2.MailDocumentCnts)resList.Add("MailDocumentCnts");
			if(mailBackup1.EnterpriseName != mailBackup2.EnterpriseName)resList.Add("EnterpriseName");
			if(mailBackup1.UpdEmployeeName != mailBackup2.UpdEmployeeName)resList.Add("UpdEmployeeName");
            // 2008.07.01 R.Sokei ADD >>>>
            if (mailBackup1.MailMngGuid != mailBackup2.MailMngGuid) resList.Add("MailMngGuid");
            // 2008.07.01 R.Sokei ADD <<<<
            if (mailBackup1.CarbonCopy != mailBackup2.CarbonCopy) resList.Add("CarbonCopy");
            if (mailBackup1.AttachFile != mailBackup2.AttachFile) resList.Add("AttachFile");

			return resList;
		}
	}
}
