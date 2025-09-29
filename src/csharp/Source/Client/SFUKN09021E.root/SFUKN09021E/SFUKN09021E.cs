using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
	/// public class name:   CompanyNm
	/// <summary>
	///                      自社名称マスタ
	/// </summary>
	/// <remarks>
	/// <br>note             :   自社名称マスタヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2007/05/16  (CSharp File Generated Date)</br>
    /// -----------------------------------------------------------------------
    /// <br>Update Note      : 2008/06/04 30414　忍　幸史</br>
    /// <br>                 :「住所2」削除</br>
    /// </remarks>
	/// </remarks>
	public class CompanyNm
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

		/// <summary>自社名称コード</summary>
		private Int32 _companyNameCd;

		/// <summary>自社PR文</summary>
		private string _companyPr = "";

		/// <summary>自社名称1</summary>
		private string _companyName1 = "";

		/// <summary>自社名称2</summary>
		private string _companyName2 = "";

		/// <summary>郵便番号</summary>
		private string _postNo = "";

		/// <summary>住所1（都道府県市区郡・町村・字）</summary>
		private string _address1 = "";

        /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
		/// <summary>住所2（丁目）</summary>
		private Int32 _address2;
           --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/
        
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

		/// <summary>銀行振込案内文</summary>
		private string _transferGuidance = "";

		/// <summary>銀行口座1</summary>
		private string _accountNoInfo1 = "";

		/// <summary>銀行口座2</summary>
		private string _accountNoInfo2 = "";

		/// <summary>銀行口座3</summary>
		private string _accountNoInfo3 = "";

		/// <summary>自社設定摘要1</summary>
		private string _companySetNote1 = "";

		/// <summary>自社設定摘要2</summary>
		private string _companySetNote2 = "";

		/// <summary>画像情報区分</summary>
		/// <remarks>10:自社画像,20:POSで使用する画像</remarks>
		private Int32 _imageInfoDiv;

		/// <summary>画像情報コード</summary>
		private Int32 _imageInfoCode;

		/// <summary>自社URL</summary>
		private string _companyUrl = "";

		/// <summary>自社PR文2</summary>
		/// <remarks>代表取締役等の情報を入力</remarks>
		private string _companyPrSentence2 = "";

		/// <summary>画像印字用コメント1</summary>
		/// <remarks>画像印字する場合、画像の下に印字する（拠点名等）</remarks>
		private string _imageCommentForPrt1 = "";

		/// <summary>画像印字用コメント2</summary>
		/// <remarks>画像印字する場合、画像の下に印字する（拠点名等）</remarks>
		private string _imageCommentForPrt2 = "";

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

		/// public propaty name  :  CompanyNameCd
		/// <summary>自社名称コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   自社名称コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 CompanyNameCd
		{
			get{return _companyNameCd;}
			set{_companyNameCd = value;}
		}

		/// public propaty name  :  CompanyPr
		/// <summary>自社PR文プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   自社PR文プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string CompanyPr
		{
			get{return _companyPr;}
			set{_companyPr = value;}
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

        /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
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
           --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

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

		/// public propaty name  :  TransferGuidance
		/// <summary>銀行振込案内文プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   銀行振込案内文プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string TransferGuidance
		{
			get{return _transferGuidance;}
			set{_transferGuidance = value;}
		}

		/// public propaty name  :  AccountNoInfo1
		/// <summary>銀行口座1プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   銀行口座1プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string AccountNoInfo1
		{
			get{return _accountNoInfo1;}
			set{_accountNoInfo1 = value;}
		}

		/// public propaty name  :  AccountNoInfo2
		/// <summary>銀行口座2プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   銀行口座2プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string AccountNoInfo2
		{
			get{return _accountNoInfo2;}
			set{_accountNoInfo2 = value;}
		}

		/// public propaty name  :  AccountNoInfo3
		/// <summary>銀行口座3プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   銀行口座3プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string AccountNoInfo3
		{
			get{return _accountNoInfo3;}
			set{_accountNoInfo3 = value;}
		}

		/// public propaty name  :  CompanySetNote1
		/// <summary>自社設定摘要1プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   自社設定摘要1プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string CompanySetNote1
		{
			get{return _companySetNote1;}
			set{_companySetNote1 = value;}
		}

		/// public propaty name  :  CompanySetNote2
		/// <summary>自社設定摘要2プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   自社設定摘要2プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string CompanySetNote2
		{
			get{return _companySetNote2;}
			set{_companySetNote2 = value;}
		}

		/// public propaty name  :  ImageInfoDiv
		/// <summary>画像情報区分プロパティ</summary>
		/// <value>10:自社画像,20:POSで使用する画像</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   画像情報区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 ImageInfoDiv
		{
			get{return _imageInfoDiv;}
			set{_imageInfoDiv = value;}
		}

		/// public propaty name  :  ImageInfoCode
		/// <summary>画像情報コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   画像情報コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 ImageInfoCode
		{
			get{return _imageInfoCode;}
			set{_imageInfoCode = value;}
		}

		/// public propaty name  :  CompanyUrl
		/// <summary>自社URLプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   自社URLプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string CompanyUrl
		{
			get{return _companyUrl;}
			set{_companyUrl = value;}
		}

		/// public propaty name  :  CompanyPrSentence2
		/// <summary>自社PR文2プロパティ</summary>
		/// <value>代表取締役等の情報を入力</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   自社PR文2プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string CompanyPrSentence2
		{
			get{return _companyPrSentence2;}
			set{_companyPrSentence2 = value;}
		}

		/// public propaty name  :  ImageCommentForPrt1
		/// <summary>画像印字用コメント1プロパティ</summary>
		/// <value>画像印字する場合、画像の下に印字する（拠点名等）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   画像印字用コメント1プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string ImageCommentForPrt1
		{
			get{return _imageCommentForPrt1;}
			set{_imageCommentForPrt1 = value;}
		}

		/// public propaty name  :  ImageCommentForPrt2
		/// <summary>画像印字用コメント2プロパティ</summary>
		/// <value>画像印字する場合、画像の下に印字する（拠点名等）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   画像印字用コメント2プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string ImageCommentForPrt2
		{
			get{return _imageCommentForPrt2;}
			set{_imageCommentForPrt2 = value;}
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


		/// <summary>
		/// 自社名称マスタコンストラクタ
		/// </summary>
		/// <returns>CompanyNmクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   CompanyNmクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public CompanyNm()
		{
		}

		/// <summary>
		/// 自社名称マスタコンストラクタ
		/// </summary>
		/// <param name="createDateTime">作成日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
		/// <param name="updateDateTime">更新日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
		/// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
		/// <param name="fileHeaderGuid">GUID(共通ファイルヘッダ)</param>
		/// <param name="updEmployeeCode">更新従業員コード(共通ファイルヘッダ)</param>
		/// <param name="updAssemblyId1">更新アセンブリID1(共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）)</param>
		/// <param name="updAssemblyId2">更新アセンブリID2(共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）)</param>
		/// <param name="logicalDeleteCode">論理削除区分(共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除))</param>
		/// <param name="companyNameCd">自社名称コード</param>
		/// <param name="companyPr">自社PR文</param>
		/// <param name="companyName1">自社名称1</param>
		/// <param name="companyName2">自社名称2</param>
		/// <param name="postNo">郵便番号</param>
		/// <param name="address1">住所1（都道府県市区郡・町村・字）</param>
        /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
		/// <param name="address2">住所2（丁目）</param>
           --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/
        /// <param name="address3">住所3（番地）</param>
		/// <param name="address4">住所4（アパート名称）</param>
		/// <param name="companyTelNo1">自社電話番号1</param>
		/// <param name="companyTelNo2">自社電話番号2</param>
		/// <param name="companyTelNo3">自社電話番号3</param>
		/// <param name="companyTelTitle1">自社電話番号タイトル1</param>
		/// <param name="companyTelTitle2">自社電話番号タイトル2</param>
		/// <param name="companyTelTitle3">自社電話番号タイトル3</param>
		/// <param name="transferGuidance">銀行振込案内文</param>
		/// <param name="accountNoInfo1">銀行口座1</param>
		/// <param name="accountNoInfo2">銀行口座2</param>
		/// <param name="accountNoInfo3">銀行口座3</param>
		/// <param name="companySetNote1">自社設定摘要1</param>
		/// <param name="companySetNote2">自社設定摘要2</param>
		/// <param name="imageInfoDiv">画像情報区分(10:自社画像,20:POSで使用する画像)</param>
		/// <param name="imageInfoCode">画像情報コード</param>
		/// <param name="companyUrl">自社URL</param>
		/// <param name="companyPrSentence2">自社PR文2(代表取締役等の情報を入力)</param>
		/// <param name="imageCommentForPrt1">画像印字用コメント1(画像印字する場合、画像の下に印字する（拠点名等）)</param>
		/// <param name="imageCommentForPrt2">画像印字用コメント2(画像印字する場合、画像の下に印字する（拠点名等）)</param>
		/// <param name="enterpriseName">企業名称</param>
		/// <param name="updEmployeeName">更新従業員名称</param>
		/// <returns>CompanyNmクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   CompanyNmクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
        /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
		public CompanyNm(DateTime createDateTime,DateTime updateDateTime,string enterpriseCode,Guid fileHeaderGuid,string updEmployeeCode,string updAssemblyId1,string updAssemblyId2,Int32 logicalDeleteCode,Int32 companyNameCd,string companyPr,string companyName1,string companyName2,string postNo,string address1,Int32 address2,string address3,string address4,string companyTelNo1,string companyTelNo2,string companyTelNo3,string companyTelTitle1,string companyTelTitle2,string companyTelTitle3,string transferGuidance,string accountNoInfo1,string accountNoInfo2,string accountNoInfo3,string companySetNote1,string companySetNote2,Int32 imageInfoDiv,Int32 imageInfoCode,string companyUrl,string companyPrSentence2,string imageCommentForPrt1,string imageCommentForPrt2,string enterpriseName,string updEmployeeName)
		   --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/
        public CompanyNm(DateTime createDateTime,DateTime updateDateTime,string enterpriseCode,Guid fileHeaderGuid,string updEmployeeCode,string updAssemblyId1,string updAssemblyId2,Int32 logicalDeleteCode,Int32 companyNameCd,string companyPr,string companyName1,string companyName2,string postNo,string address1,string address3,string address4,string companyTelNo1,string companyTelNo2,string companyTelNo3,string companyTelTitle1,string companyTelTitle2,string companyTelTitle3,string transferGuidance,string accountNoInfo1,string accountNoInfo2,string accountNoInfo3,string companySetNote1,string companySetNote2,Int32 imageInfoDiv,Int32 imageInfoCode,string companyUrl,string companyPrSentence2,string imageCommentForPrt1,string imageCommentForPrt2,string enterpriseName,string updEmployeeName)
		{
			this.CreateDateTime = createDateTime;
			this.UpdateDateTime = updateDateTime;
			this._enterpriseCode = enterpriseCode;
			this._fileHeaderGuid = fileHeaderGuid;
			this._updEmployeeCode = updEmployeeCode;
			this._updAssemblyId1 = updAssemblyId1;
			this._updAssemblyId2 = updAssemblyId2;
			this._logicalDeleteCode = logicalDeleteCode;
			this._companyNameCd = companyNameCd;
			this._companyPr = companyPr;
			this._companyName1 = companyName1;
			this._companyName2 = companyName2;
			this._postNo = postNo;
			this._address1 = address1;
            //this._address2 = address2;  // DEL 2008/06/04
			this._address3 = address3;
			this._address4 = address4;
			this._companyTelNo1 = companyTelNo1;
			this._companyTelNo2 = companyTelNo2;
			this._companyTelNo3 = companyTelNo3;
			this._companyTelTitle1 = companyTelTitle1;
			this._companyTelTitle2 = companyTelTitle2;
			this._companyTelTitle3 = companyTelTitle3;
			this._transferGuidance = transferGuidance;
			this._accountNoInfo1 = accountNoInfo1;
			this._accountNoInfo2 = accountNoInfo2;
			this._accountNoInfo3 = accountNoInfo3;
			this._companySetNote1 = companySetNote1;
			this._companySetNote2 = companySetNote2;
			this._imageInfoDiv = imageInfoDiv;
			this._imageInfoCode = imageInfoCode;
			this._companyUrl = companyUrl;
			this._companyPrSentence2 = companyPrSentence2;
			this._imageCommentForPrt1 = imageCommentForPrt1;
			this._imageCommentForPrt2 = imageCommentForPrt2;
			this._enterpriseName = enterpriseName;
			this._updEmployeeName = updEmployeeName;

		}

		/// <summary>
		/// 自社名称マスタ複製処理
		/// </summary>
		/// <returns>CompanyNmクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   自身の内容と等しいCompanyNmクラスのインスタンスを返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public CompanyNm Clone()
		{
            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
            return new CompanyNm(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._companyNameCd, this._companyPr, this._companyName1, this._companyName2, this._postNo, this._address1, this._address2, this._address3, this._address4, this._companyTelNo1, this._companyTelNo2, this._companyTelNo3, this._companyTelTitle1, this._companyTelTitle2, this._companyTelTitle3, this._transferGuidance, this._accountNoInfo1, this._accountNoInfo2, this._accountNoInfo3, this._companySetNote1, this._companySetNote2, this._imageInfoDiv, this._imageInfoCode, this._companyUrl, this._companyPrSentence2, this._imageCommentForPrt1, this._imageCommentForPrt2, this._enterpriseName, this._updEmployeeName);
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/
            return new CompanyNm(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._companyNameCd, this._companyPr, this._companyName1, this._companyName2, this._postNo, this._address1, this._address3, this._address4, this._companyTelNo1, this._companyTelNo2, this._companyTelNo3, this._companyTelTitle1, this._companyTelTitle2, this._companyTelTitle3, this._transferGuidance, this._accountNoInfo1, this._accountNoInfo2, this._accountNoInfo3, this._companySetNote1, this._companySetNote2, this._imageInfoDiv, this._imageInfoCode, this._companyUrl, this._companyPrSentence2, this._imageCommentForPrt1, this._imageCommentForPrt2, this._enterpriseName, this._updEmployeeName);
		}

		/// <summary>
		/// 自社名称マスタ比較処理
		/// </summary>
		/// <param name="target">比較対象のCompanyNmクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   CompanyNmクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public bool Equals(CompanyNm target)
		{
			return ((this.CreateDateTime == target.CreateDateTime)
				 && (this.UpdateDateTime == target.UpdateDateTime)
				 && (this.EnterpriseCode == target.EnterpriseCode)
				 && (this.FileHeaderGuid == target.FileHeaderGuid)
				 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
				 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
				 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
				 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
				 && (this.CompanyNameCd == target.CompanyNameCd)
				 && (this.CompanyPr == target.CompanyPr)
				 && (this.CompanyName1 == target.CompanyName1)
				 && (this.CompanyName2 == target.CompanyName2)
				 && (this.PostNo == target.PostNo)
				 && (this.Address1 == target.Address1)
                //&& (this.Address2 == target.Address2)  // DEL 2008/06/04
				 && (this.Address3 == target.Address3)
				 && (this.Address4 == target.Address4)
				 && (this.CompanyTelNo1 == target.CompanyTelNo1)
				 && (this.CompanyTelNo2 == target.CompanyTelNo2)
				 && (this.CompanyTelNo3 == target.CompanyTelNo3)
				 && (this.CompanyTelTitle1 == target.CompanyTelTitle1)
				 && (this.CompanyTelTitle2 == target.CompanyTelTitle2)
				 && (this.CompanyTelTitle3 == target.CompanyTelTitle3)
				 && (this.TransferGuidance == target.TransferGuidance)
				 && (this.AccountNoInfo1 == target.AccountNoInfo1)
				 && (this.AccountNoInfo2 == target.AccountNoInfo2)
				 && (this.AccountNoInfo3 == target.AccountNoInfo3)
				 && (this.CompanySetNote1 == target.CompanySetNote1)
				 && (this.CompanySetNote2 == target.CompanySetNote2)
				 && (this.ImageInfoDiv == target.ImageInfoDiv)
				 && (this.ImageInfoCode == target.ImageInfoCode)
				 && (this.CompanyUrl == target.CompanyUrl)
				 && (this.CompanyPrSentence2 == target.CompanyPrSentence2)
				 && (this.ImageCommentForPrt1 == target.ImageCommentForPrt1)
				 && (this.ImageCommentForPrt2 == target.ImageCommentForPrt2)
				 && (this.EnterpriseName == target.EnterpriseName)
				 && (this.UpdEmployeeName == target.UpdEmployeeName));
		}

		/// <summary>
		/// 自社名称マスタ比較処理
		/// </summary>
		/// <param name="companyNm1">
		///                    比較するCompanyNmクラスのインスタンス
		/// </param>
		/// <param name="companyNm2">比較するCompanyNmクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   CompanyNmクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static bool Equals(CompanyNm companyNm1, CompanyNm companyNm2)
		{
			return ((companyNm1.CreateDateTime == companyNm2.CreateDateTime)
				 && (companyNm1.UpdateDateTime == companyNm2.UpdateDateTime)
				 && (companyNm1.EnterpriseCode == companyNm2.EnterpriseCode)
				 && (companyNm1.FileHeaderGuid == companyNm2.FileHeaderGuid)
				 && (companyNm1.UpdEmployeeCode == companyNm2.UpdEmployeeCode)
				 && (companyNm1.UpdAssemblyId1 == companyNm2.UpdAssemblyId1)
				 && (companyNm1.UpdAssemblyId2 == companyNm2.UpdAssemblyId2)
				 && (companyNm1.LogicalDeleteCode == companyNm2.LogicalDeleteCode)
				 && (companyNm1.CompanyNameCd == companyNm2.CompanyNameCd)
				 && (companyNm1.CompanyPr == companyNm2.CompanyPr)
				 && (companyNm1.CompanyName1 == companyNm2.CompanyName1)
				 && (companyNm1.CompanyName2 == companyNm2.CompanyName2)
				 && (companyNm1.PostNo == companyNm2.PostNo)
				 && (companyNm1.Address1 == companyNm2.Address1)
                //&& (companyNm1.Address2 == companyNm2.Address2)  // DEL 2008/06/04
				 && (companyNm1.Address3 == companyNm2.Address3)
				 && (companyNm1.Address4 == companyNm2.Address4)
				 && (companyNm1.CompanyTelNo1 == companyNm2.CompanyTelNo1)
				 && (companyNm1.CompanyTelNo2 == companyNm2.CompanyTelNo2)
				 && (companyNm1.CompanyTelNo3 == companyNm2.CompanyTelNo3)
				 && (companyNm1.CompanyTelTitle1 == companyNm2.CompanyTelTitle1)
				 && (companyNm1.CompanyTelTitle2 == companyNm2.CompanyTelTitle2)
				 && (companyNm1.CompanyTelTitle3 == companyNm2.CompanyTelTitle3)
				 && (companyNm1.TransferGuidance == companyNm2.TransferGuidance)
				 && (companyNm1.AccountNoInfo1 == companyNm2.AccountNoInfo1)
				 && (companyNm1.AccountNoInfo2 == companyNm2.AccountNoInfo2)
				 && (companyNm1.AccountNoInfo3 == companyNm2.AccountNoInfo3)
				 && (companyNm1.CompanySetNote1 == companyNm2.CompanySetNote1)
				 && (companyNm1.CompanySetNote2 == companyNm2.CompanySetNote2)
				 && (companyNm1.ImageInfoDiv == companyNm2.ImageInfoDiv)
				 && (companyNm1.ImageInfoCode == companyNm2.ImageInfoCode)
				 && (companyNm1.CompanyUrl == companyNm2.CompanyUrl)
				 && (companyNm1.CompanyPrSentence2 == companyNm2.CompanyPrSentence2)
				 && (companyNm1.ImageCommentForPrt1 == companyNm2.ImageCommentForPrt1)
				 && (companyNm1.ImageCommentForPrt2 == companyNm2.ImageCommentForPrt2)
				 && (companyNm1.EnterpriseName == companyNm2.EnterpriseName)
				 && (companyNm1.UpdEmployeeName == companyNm2.UpdEmployeeName));
		}
		/// <summary>
		/// 自社名称マスタ比較処理
		/// </summary>
		/// <param name="target">比較対象のCompanyNmクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   CompanyNmクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ArrayList Compare(CompanyNm target)
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
			if(this.CompanyNameCd != target.CompanyNameCd)resList.Add("CompanyNameCd");
			if(this.CompanyPr != target.CompanyPr)resList.Add("CompanyPr");
			if(this.CompanyName1 != target.CompanyName1)resList.Add("CompanyName1");
			if(this.CompanyName2 != target.CompanyName2)resList.Add("CompanyName2");
			if(this.PostNo != target.PostNo)resList.Add("PostNo");
			if(this.Address1 != target.Address1)resList.Add("Address1");
            //if(this.Address2 != target.Address2)resList.Add("Address2");  // DEL 2008/06/04
			if(this.Address3 != target.Address3)resList.Add("Address3");
			if(this.Address4 != target.Address4)resList.Add("Address4");
			if(this.CompanyTelNo1 != target.CompanyTelNo1)resList.Add("CompanyTelNo1");
			if(this.CompanyTelNo2 != target.CompanyTelNo2)resList.Add("CompanyTelNo2");
			if(this.CompanyTelNo3 != target.CompanyTelNo3)resList.Add("CompanyTelNo3");
			if(this.CompanyTelTitle1 != target.CompanyTelTitle1)resList.Add("CompanyTelTitle1");
			if(this.CompanyTelTitle2 != target.CompanyTelTitle2)resList.Add("CompanyTelTitle2");
			if(this.CompanyTelTitle3 != target.CompanyTelTitle3)resList.Add("CompanyTelTitle3");
			if(this.TransferGuidance != target.TransferGuidance)resList.Add("TransferGuidance");
			if(this.AccountNoInfo1 != target.AccountNoInfo1)resList.Add("AccountNoInfo1");
			if(this.AccountNoInfo2 != target.AccountNoInfo2)resList.Add("AccountNoInfo2");
			if(this.AccountNoInfo3 != target.AccountNoInfo3)resList.Add("AccountNoInfo3");
			if(this.CompanySetNote1 != target.CompanySetNote1)resList.Add("CompanySetNote1");
			if(this.CompanySetNote2 != target.CompanySetNote2)resList.Add("CompanySetNote2");
			if(this.ImageInfoDiv != target.ImageInfoDiv)resList.Add("ImageInfoDiv");
			if(this.ImageInfoCode != target.ImageInfoCode)resList.Add("ImageInfoCode");
			if(this.CompanyUrl != target.CompanyUrl)resList.Add("CompanyUrl");
			if(this.CompanyPrSentence2 != target.CompanyPrSentence2)resList.Add("CompanyPrSentence2");
			if(this.ImageCommentForPrt1 != target.ImageCommentForPrt1)resList.Add("ImageCommentForPrt1");
			if(this.ImageCommentForPrt2 != target.ImageCommentForPrt2)resList.Add("ImageCommentForPrt2");
			if(this.EnterpriseName != target.EnterpriseName)resList.Add("EnterpriseName");
			if(this.UpdEmployeeName != target.UpdEmployeeName)resList.Add("UpdEmployeeName");

			return resList;
		}

		/// <summary>
		/// 自社名称マスタ比較処理
		/// </summary>
		/// <param name="companyNm1">比較するCompanyNmクラスのインスタンス</param>
		/// <param name="companyNm2">比較するCompanyNmクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   CompanyNmクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static ArrayList Compare(CompanyNm companyNm1, CompanyNm companyNm2)
		{
			ArrayList resList = new ArrayList();
			if(companyNm1.CreateDateTime != companyNm2.CreateDateTime)resList.Add("CreateDateTime");
			if(companyNm1.UpdateDateTime != companyNm2.UpdateDateTime)resList.Add("UpdateDateTime");
			if(companyNm1.EnterpriseCode != companyNm2.EnterpriseCode)resList.Add("EnterpriseCode");
			if(companyNm1.FileHeaderGuid != companyNm2.FileHeaderGuid)resList.Add("FileHeaderGuid");
			if(companyNm1.UpdEmployeeCode != companyNm2.UpdEmployeeCode)resList.Add("UpdEmployeeCode");
			if(companyNm1.UpdAssemblyId1 != companyNm2.UpdAssemblyId1)resList.Add("UpdAssemblyId1");
			if(companyNm1.UpdAssemblyId2 != companyNm2.UpdAssemblyId2)resList.Add("UpdAssemblyId2");
			if(companyNm1.LogicalDeleteCode != companyNm2.LogicalDeleteCode)resList.Add("LogicalDeleteCode");
			if(companyNm1.CompanyNameCd != companyNm2.CompanyNameCd)resList.Add("CompanyNameCd");
			if(companyNm1.CompanyPr != companyNm2.CompanyPr)resList.Add("CompanyPr");
			if(companyNm1.CompanyName1 != companyNm2.CompanyName1)resList.Add("CompanyName1");
			if(companyNm1.CompanyName2 != companyNm2.CompanyName2)resList.Add("CompanyName2");
			if(companyNm1.PostNo != companyNm2.PostNo)resList.Add("PostNo");
			if(companyNm1.Address1 != companyNm2.Address1)resList.Add("Address1");
            //if(companyNm1.Address2 != companyNm2.Address2)resList.Add("Address2");  // DEL 2008/06/04
			if(companyNm1.Address3 != companyNm2.Address3)resList.Add("Address3");
			if(companyNm1.Address4 != companyNm2.Address4)resList.Add("Address4");
			if(companyNm1.CompanyTelNo1 != companyNm2.CompanyTelNo1)resList.Add("CompanyTelNo1");
			if(companyNm1.CompanyTelNo2 != companyNm2.CompanyTelNo2)resList.Add("CompanyTelNo2");
			if(companyNm1.CompanyTelNo3 != companyNm2.CompanyTelNo3)resList.Add("CompanyTelNo3");
			if(companyNm1.CompanyTelTitle1 != companyNm2.CompanyTelTitle1)resList.Add("CompanyTelTitle1");
			if(companyNm1.CompanyTelTitle2 != companyNm2.CompanyTelTitle2)resList.Add("CompanyTelTitle2");
			if(companyNm1.CompanyTelTitle3 != companyNm2.CompanyTelTitle3)resList.Add("CompanyTelTitle3");
			if(companyNm1.TransferGuidance != companyNm2.TransferGuidance)resList.Add("TransferGuidance");
			if(companyNm1.AccountNoInfo1 != companyNm2.AccountNoInfo1)resList.Add("AccountNoInfo1");
			if(companyNm1.AccountNoInfo2 != companyNm2.AccountNoInfo2)resList.Add("AccountNoInfo2");
			if(companyNm1.AccountNoInfo3 != companyNm2.AccountNoInfo3)resList.Add("AccountNoInfo3");
			if(companyNm1.CompanySetNote1 != companyNm2.CompanySetNote1)resList.Add("CompanySetNote1");
			if(companyNm1.CompanySetNote2 != companyNm2.CompanySetNote2)resList.Add("CompanySetNote2");
			if(companyNm1.ImageInfoDiv != companyNm2.ImageInfoDiv)resList.Add("ImageInfoDiv");
			if(companyNm1.ImageInfoCode != companyNm2.ImageInfoCode)resList.Add("ImageInfoCode");
			if(companyNm1.CompanyUrl != companyNm2.CompanyUrl)resList.Add("CompanyUrl");
			if(companyNm1.CompanyPrSentence2 != companyNm2.CompanyPrSentence2)resList.Add("CompanyPrSentence2");
			if(companyNm1.ImageCommentForPrt1 != companyNm2.ImageCommentForPrt1)resList.Add("ImageCommentForPrt1");
			if(companyNm1.ImageCommentForPrt2 != companyNm2.ImageCommentForPrt2)resList.Add("ImageCommentForPrt2");
			if(companyNm1.EnterpriseName != companyNm2.EnterpriseName)resList.Add("EnterpriseName");
			if(companyNm1.UpdEmployeeName != companyNm2.UpdEmployeeName)resList.Add("UpdEmployeeName");

			return resList;
		}
	}
}
