using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData.StubDB
{
	/// public class name:   SCMAcOdrDtCar
	/// <summary>
	///                      SCM受注データ(車両情報)
	/// </summary>
	/// <remarks>
	/// <br>note             :   SCM受注データ(車両情報)ヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   2009/04/13</br>
	/// <br>Genarated Date   :   2009/05/27  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   2009/05/26  杉村</br>
	/// <br>                 :   ○項目削除</br>
	/// <br>                 :   問合せ日</br>
	/// <br>                 :   問合せ従業員コード</br>
	/// <br>                 :   問合せ従業員名称</br>
	/// <br>                 :   発注日</br>
	/// <br>                 :   発注者従業員コード</br>
	/// <br>                 :   発注者従業員名称</br>
	/// </remarks>
	public class SCMAcOdrDtCar
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

		/// <summary>問合せ元企業コード</summary>
		private string _inqOriginalEpCd = "";

		/// <summary>問合せ元拠点コード</summary>
		private string _inqOriginalSecCd = "";

		/// <summary>問合せ番号</summary>
		private Int64 _inquiryNumber;

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

		/// <summary>型式指定番号</summary>
		private Int32 _modelDesignationNo;

		/// <summary>類別番号</summary>
		private Int32 _categoryNo;

		/// <summary>メーカーコード</summary>
		/// <remarks>1～899:提供分, 900～ユーザー登録</remarks>
		private Int32 _makerCode;

		/// <summary>車種コード</summary>
		/// <remarks>車名コード(翼) 1～899:提供分, 900～ユーザー登録</remarks>
		private Int32 _modelCode;

		/// <summary>車種サブコード</summary>
		/// <remarks>0～899:提供分,900～ﾕｰｻﾞｰ登録</remarks>
		private Int32 _modelSubCode;

		/// <summary>車種名</summary>
		private string _modelName = "";

		/// <summary>車検証型式</summary>
		private string _carInspectCertModel = "";

		/// <summary>型式（フル型）</summary>
		/// <remarks>フル型式(44桁用)</remarks>
		private string _fullModel = "";

		/// <summary>車台番号</summary>
		private string _frameNo = "";

		/// <summary>車台型式</summary>
		private string _frameModel = "";

		/// <summary>シャシーNo</summary>
		private string _chassisNo = "";

		/// <summary>車両固有番号</summary>
		/// <remarks>ユニークな固定番号</remarks>
		private Int32 _carProperNo;

		/// <summary>生産年式（NUMタイプ）</summary>
		/// <remarks>YYYYMM</remarks>
		private Int32 _produceTypeOfYearNum;

		/// <summary>コメント</summary>
		/// <remarks>カタログのコメントや単位・カラーが格納</remarks>
		private string _comment = "";

		/// <summary>リペアカラーコード</summary>
		/// <remarks>カタログの色コード（リペア用が新車時と異なる場合）</remarks>
		private string _rpColorCode = "";

		/// <summary>カラー名称1</summary>
		/// <remarks>画面表示用正式名称</remarks>
		private string _colorName1 = "";

		/// <summary>トリムコード</summary>
		private string _trimCode = "";

		/// <summary>トリム名称</summary>
		private string _trimName = "";

		/// <summary>車両走行距離</summary>
		private Int32 _mileage;

		/// <summary>装備オブジェクト</summary>
		private Byte[] _equipObj;

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

		/// public propaty name  :  InqOriginalEpCd
		/// <summary>問合せ元企業コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   問合せ元企業コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string InqOriginalEpCd
		{
			get{return _inqOriginalEpCd;}
			set{_inqOriginalEpCd = value;}
		}

		/// public propaty name  :  InqOriginalSecCd
		/// <summary>問合せ元拠点コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   問合せ元拠点コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string InqOriginalSecCd
		{
			get{return _inqOriginalSecCd;}
			set{_inqOriginalSecCd = value;}
		}

		/// public propaty name  :  InquiryNumber
		/// <summary>問合せ番号プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   問合せ番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 InquiryNumber
		{
			get{return _inquiryNumber;}
			set{_inquiryNumber = value;}
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

		/// public propaty name  :  ModelDesignationNo
		/// <summary>型式指定番号プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   型式指定番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 ModelDesignationNo
		{
			get{return _modelDesignationNo;}
			set{_modelDesignationNo = value;}
		}

		/// public propaty name  :  CategoryNo
		/// <summary>類別番号プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   類別番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 CategoryNo
		{
			get{return _categoryNo;}
			set{_categoryNo = value;}
		}

		/// public propaty name  :  MakerCode
		/// <summary>メーカーコードプロパティ</summary>
		/// <value>1～899:提供分, 900～ユーザー登録</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   メーカーコードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 MakerCode
		{
			get{return _makerCode;}
			set{_makerCode = value;}
		}

		/// public propaty name  :  ModelCode
		/// <summary>車種コードプロパティ</summary>
		/// <value>車名コード(翼) 1～899:提供分, 900～ユーザー登録</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   車種コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 ModelCode
		{
			get{return _modelCode;}
			set{_modelCode = value;}
		}

		/// public propaty name  :  ModelSubCode
		/// <summary>車種サブコードプロパティ</summary>
		/// <value>0～899:提供分,900～ﾕｰｻﾞｰ登録</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   車種サブコードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 ModelSubCode
		{
			get{return _modelSubCode;}
			set{_modelSubCode = value;}
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

		/// public propaty name  :  CarInspectCertModel
		/// <summary>車検証型式プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   車検証型式プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string CarInspectCertModel
		{
			get{return _carInspectCertModel;}
			set{_carInspectCertModel = value;}
		}

		/// public propaty name  :  FullModel
		/// <summary>型式（フル型）プロパティ</summary>
		/// <value>フル型式(44桁用)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   型式（フル型）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string FullModel
		{
			get{return _fullModel;}
			set{_fullModel = value;}
		}

		/// public propaty name  :  FrameNo
		/// <summary>車台番号プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   車台番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string FrameNo
		{
			get{return _frameNo;}
			set{_frameNo = value;}
		}

		/// public propaty name  :  FrameModel
		/// <summary>車台型式プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   車台型式プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string FrameModel
		{
			get{return _frameModel;}
			set{_frameModel = value;}
		}

		/// public propaty name  :  ChassisNo
		/// <summary>シャシーNoプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   シャシーNoプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string ChassisNo
		{
			get{return _chassisNo;}
			set{_chassisNo = value;}
		}

		/// public propaty name  :  CarProperNo
		/// <summary>車両固有番号プロパティ</summary>
		/// <value>ユニークな固定番号</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   車両固有番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 CarProperNo
		{
			get{return _carProperNo;}
			set{_carProperNo = value;}
		}

		/// public propaty name  :  ProduceTypeOfYearNum
		/// <summary>生産年式（NUMタイプ）プロパティ</summary>
		/// <value>YYYYMM</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   生産年式（NUMタイプ）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 ProduceTypeOfYearNum
		{
			get{return _produceTypeOfYearNum;}
			set{_produceTypeOfYearNum = value;}
		}

		/// public propaty name  :  Comment
		/// <summary>コメントプロパティ</summary>
		/// <value>カタログのコメントや単位・カラーが格納</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   コメントプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string Comment
		{
			get{return _comment;}
			set{_comment = value;}
		}

		/// public propaty name  :  RpColorCode
		/// <summary>リペアカラーコードプロパティ</summary>
		/// <value>カタログの色コード（リペア用が新車時と異なる場合）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   リペアカラーコードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string RpColorCode
		{
			get{return _rpColorCode;}
			set{_rpColorCode = value;}
		}

		/// public propaty name  :  ColorName1
		/// <summary>カラー名称1プロパティ</summary>
		/// <value>画面表示用正式名称</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   カラー名称1プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string ColorName1
		{
			get{return _colorName1;}
			set{_colorName1 = value;}
		}

		/// public propaty name  :  TrimCode
		/// <summary>トリムコードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   トリムコードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string TrimCode
		{
			get{return _trimCode;}
			set{_trimCode = value;}
		}

		/// public propaty name  :  TrimName
		/// <summary>トリム名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   トリム名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string TrimName
		{
			get{return _trimName;}
			set{_trimName = value;}
		}

		/// public propaty name  :  Mileage
		/// <summary>車両走行距離プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   車両走行距離プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 Mileage
		{
			get{return _mileage;}
			set{_mileage = value;}
		}

		/// public propaty name  :  EquipObj
		/// <summary>装備オブジェクトプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   装備オブジェクトプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Byte[] EquipObj
		{
			get{return _equipObj;}
			set{_equipObj = value;}
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
		/// SCM受注データ(車両情報)コンストラクタ
		/// </summary>
		/// <returns>SCMAcOdrDtCarクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SCMAcOdrDtCarクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public SCMAcOdrDtCar()
		{
		}

		/// <summary>
		/// SCM受注データ(車両情報)コンストラクタ
		/// </summary>
		/// <param name="createDateTime">作成日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
		/// <param name="updateDateTime">更新日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
		/// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
		/// <param name="fileHeaderGuid">GUID(共通ファイルヘッダ)</param>
		/// <param name="updEmployeeCode">更新従業員コード(共通ファイルヘッダ)</param>
		/// <param name="updAssemblyId1">更新アセンブリID1(共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）)</param>
		/// <param name="updAssemblyId2">更新アセンブリID2(共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）)</param>
		/// <param name="logicalDeleteCode">論理削除区分(共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除))</param>
		/// <param name="inqOriginalEpCd">問合せ元企業コード</param>
		/// <param name="inqOriginalSecCd">問合せ元拠点コード</param>
		/// <param name="inquiryNumber">問合せ番号</param>
		/// <param name="numberPlate1Code">陸運事務所番号</param>
		/// <param name="numberPlate1Name">陸運事務局名称</param>
		/// <param name="numberPlate2">車両登録番号（種別）</param>
		/// <param name="numberPlate3">車両登録番号（カナ）</param>
		/// <param name="numberPlate4">車両登録番号（プレート番号）</param>
		/// <param name="modelDesignationNo">型式指定番号</param>
		/// <param name="categoryNo">類別番号</param>
		/// <param name="makerCode">メーカーコード(1～899:提供分, 900～ユーザー登録)</param>
		/// <param name="modelCode">車種コード(車名コード(翼) 1～899:提供分, 900～ユーザー登録)</param>
		/// <param name="modelSubCode">車種サブコード(0～899:提供分,900～ﾕｰｻﾞｰ登録)</param>
		/// <param name="modelName">車種名</param>
		/// <param name="carInspectCertModel">車検証型式</param>
		/// <param name="fullModel">型式（フル型）(フル型式(44桁用))</param>
		/// <param name="frameNo">車台番号</param>
		/// <param name="frameModel">車台型式</param>
		/// <param name="chassisNo">シャシーNo</param>
		/// <param name="carProperNo">車両固有番号(ユニークな固定番号)</param>
		/// <param name="produceTypeOfYearNum">生産年式（NUMタイプ）(YYYYMM)</param>
		/// <param name="comment">コメント(カタログのコメントや単位・カラーが格納)</param>
		/// <param name="rpColorCode">リペアカラーコード(カタログの色コード（リペア用が新車時と異なる場合）)</param>
		/// <param name="colorName1">カラー名称1(画面表示用正式名称)</param>
		/// <param name="trimCode">トリムコード</param>
		/// <param name="trimName">トリム名称</param>
		/// <param name="mileage">車両走行距離</param>
		/// <param name="equipObj">装備オブジェクト</param>
		/// <param name="enterpriseName">企業名称</param>
		/// <param name="updEmployeeName">更新従業員名称</param>
		/// <returns>SCMAcOdrDtCarクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SCMAcOdrDtCarクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public SCMAcOdrDtCar(DateTime createDateTime,DateTime updateDateTime,string enterpriseCode,Guid fileHeaderGuid,string updEmployeeCode,string updAssemblyId1,string updAssemblyId2,Int32 logicalDeleteCode,string inqOriginalEpCd,string inqOriginalSecCd,Int64 inquiryNumber,Int32 numberPlate1Code,string numberPlate1Name,string numberPlate2,string numberPlate3,Int32 numberPlate4,Int32 modelDesignationNo,Int32 categoryNo,Int32 makerCode,Int32 modelCode,Int32 modelSubCode,string modelName,string carInspectCertModel,string fullModel,string frameNo,string frameModel,string chassisNo,Int32 carProperNo,Int32 produceTypeOfYearNum,string comment,string rpColorCode,string colorName1,string trimCode,string trimName,Int32 mileage,Byte[] equipObj,string enterpriseName,string updEmployeeName)
		{
			this.CreateDateTime = createDateTime;
			this.UpdateDateTime = updateDateTime;
			this._enterpriseCode = enterpriseCode;
			this._fileHeaderGuid = fileHeaderGuid;
			this._updEmployeeCode = updEmployeeCode;
			this._updAssemblyId1 = updAssemblyId1;
			this._updAssemblyId2 = updAssemblyId2;
			this._logicalDeleteCode = logicalDeleteCode;
			this._inqOriginalEpCd = inqOriginalEpCd.Trim();//@@@@20230303
			this._inqOriginalSecCd = inqOriginalSecCd;
			this._inquiryNumber = inquiryNumber;
			this._numberPlate1Code = numberPlate1Code;
			this._numberPlate1Name = numberPlate1Name;
			this._numberPlate2 = numberPlate2;
			this._numberPlate3 = numberPlate3;
			this._numberPlate4 = numberPlate4;
			this._modelDesignationNo = modelDesignationNo;
			this._categoryNo = categoryNo;
			this._makerCode = makerCode;
			this._modelCode = modelCode;
			this._modelSubCode = modelSubCode;
			this._modelName = modelName;
			this._carInspectCertModel = carInspectCertModel;
			this._fullModel = fullModel;
			this._frameNo = frameNo;
			this._frameModel = frameModel;
			this._chassisNo = chassisNo;
			this._carProperNo = carProperNo;
			this._produceTypeOfYearNum = produceTypeOfYearNum;
			this._comment = comment;
			this._rpColorCode = rpColorCode;
			this._colorName1 = colorName1;
			this._trimCode = trimCode;
			this._trimName = trimName;
			this._mileage = mileage;
			this._equipObj = equipObj;
			this._enterpriseName = enterpriseName;
			this._updEmployeeName = updEmployeeName;

		}

		/// <summary>
		/// SCM受注データ(車両情報)複製処理
		/// </summary>
		/// <returns>SCMAcOdrDtCarクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   自身の内容と等しいSCMAcOdrDtCarクラスのインスタンスを返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public SCMAcOdrDtCar Clone()
		{
			return new SCMAcOdrDtCar(this._createDateTime,this._updateDateTime,this._enterpriseCode,this._fileHeaderGuid,this._updEmployeeCode,this._updAssemblyId1,this._updAssemblyId2,this._logicalDeleteCode,this._inqOriginalEpCd.Trim(),this._inqOriginalSecCd,this._inquiryNumber,this._numberPlate1Code,this._numberPlate1Name,this._numberPlate2,this._numberPlate3,this._numberPlate4,this._modelDesignationNo,this._categoryNo,this._makerCode,this._modelCode,this._modelSubCode,this._modelName,this._carInspectCertModel,this._fullModel,this._frameNo,this._frameModel,this._chassisNo,this._carProperNo,this._produceTypeOfYearNum,this._comment,this._rpColorCode,this._colorName1,this._trimCode,this._trimName,this._mileage,this._equipObj,this._enterpriseName,this._updEmployeeName);//@@@@20230303
		}

		/// <summary>
		/// SCM受注データ(車両情報)比較処理
		/// </summary>
		/// <param name="target">比較対象のSCMAcOdrDtCarクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SCMAcOdrDtCarクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public bool Equals(SCMAcOdrDtCar target)
		{
			return ((this.CreateDateTime == target.CreateDateTime)
				 && (this.UpdateDateTime == target.UpdateDateTime)
				 && (this.EnterpriseCode == target.EnterpriseCode)
				 && (this.FileHeaderGuid == target.FileHeaderGuid)
				 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
				 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
				 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
				 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
				 && (this.InqOriginalEpCd.Trim() == target.InqOriginalEpCd.Trim()) //@@@@20230303
				 && (this.InqOriginalSecCd == target.InqOriginalSecCd)
				 && (this.InquiryNumber == target.InquiryNumber)
				 && (this.NumberPlate1Code == target.NumberPlate1Code)
				 && (this.NumberPlate1Name == target.NumberPlate1Name)
				 && (this.NumberPlate2 == target.NumberPlate2)
				 && (this.NumberPlate3 == target.NumberPlate3)
				 && (this.NumberPlate4 == target.NumberPlate4)
				 && (this.ModelDesignationNo == target.ModelDesignationNo)
				 && (this.CategoryNo == target.CategoryNo)
				 && (this.MakerCode == target.MakerCode)
				 && (this.ModelCode == target.ModelCode)
				 && (this.ModelSubCode == target.ModelSubCode)
				 && (this.ModelName == target.ModelName)
				 && (this.CarInspectCertModel == target.CarInspectCertModel)
				 && (this.FullModel == target.FullModel)
				 && (this.FrameNo == target.FrameNo)
				 && (this.FrameModel == target.FrameModel)
				 && (this.ChassisNo == target.ChassisNo)
				 && (this.CarProperNo == target.CarProperNo)
				 && (this.ProduceTypeOfYearNum == target.ProduceTypeOfYearNum)
				 && (this.Comment == target.Comment)
				 && (this.RpColorCode == target.RpColorCode)
				 && (this.ColorName1 == target.ColorName1)
				 && (this.TrimCode == target.TrimCode)
				 && (this.TrimName == target.TrimName)
				 && (this.Mileage == target.Mileage)
				 && (this.EquipObj == target.EquipObj)
				 && (this.EnterpriseName == target.EnterpriseName)
				 && (this.UpdEmployeeName == target.UpdEmployeeName));
		}

		/// <summary>
		/// SCM受注データ(車両情報)比較処理
		/// </summary>
		/// <param name="sCMAcOdrDtCar1">
		///                    比較するSCMAcOdrDtCarクラスのインスタンス
		/// </param>
		/// <param name="sCMAcOdrDtCar2">比較するSCMAcOdrDtCarクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SCMAcOdrDtCarクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static bool Equals(SCMAcOdrDtCar sCMAcOdrDtCar1, SCMAcOdrDtCar sCMAcOdrDtCar2)
		{
			return ((sCMAcOdrDtCar1.CreateDateTime == sCMAcOdrDtCar2.CreateDateTime)
				 && (sCMAcOdrDtCar1.UpdateDateTime == sCMAcOdrDtCar2.UpdateDateTime)
				 && (sCMAcOdrDtCar1.EnterpriseCode == sCMAcOdrDtCar2.EnterpriseCode)
				 && (sCMAcOdrDtCar1.FileHeaderGuid == sCMAcOdrDtCar2.FileHeaderGuid)
				 && (sCMAcOdrDtCar1.UpdEmployeeCode == sCMAcOdrDtCar2.UpdEmployeeCode)
				 && (sCMAcOdrDtCar1.UpdAssemblyId1 == sCMAcOdrDtCar2.UpdAssemblyId1)
				 && (sCMAcOdrDtCar1.UpdAssemblyId2 == sCMAcOdrDtCar2.UpdAssemblyId2)
				 && (sCMAcOdrDtCar1.LogicalDeleteCode == sCMAcOdrDtCar2.LogicalDeleteCode)
				 && (sCMAcOdrDtCar1.InqOriginalEpCd.Trim() == sCMAcOdrDtCar2.InqOriginalEpCd.Trim()) //@@@@20230303
				 && (sCMAcOdrDtCar1.InqOriginalSecCd == sCMAcOdrDtCar2.InqOriginalSecCd)
				 && (sCMAcOdrDtCar1.InquiryNumber == sCMAcOdrDtCar2.InquiryNumber)
				 && (sCMAcOdrDtCar1.NumberPlate1Code == sCMAcOdrDtCar2.NumberPlate1Code)
				 && (sCMAcOdrDtCar1.NumberPlate1Name == sCMAcOdrDtCar2.NumberPlate1Name)
				 && (sCMAcOdrDtCar1.NumberPlate2 == sCMAcOdrDtCar2.NumberPlate2)
				 && (sCMAcOdrDtCar1.NumberPlate3 == sCMAcOdrDtCar2.NumberPlate3)
				 && (sCMAcOdrDtCar1.NumberPlate4 == sCMAcOdrDtCar2.NumberPlate4)
				 && (sCMAcOdrDtCar1.ModelDesignationNo == sCMAcOdrDtCar2.ModelDesignationNo)
				 && (sCMAcOdrDtCar1.CategoryNo == sCMAcOdrDtCar2.CategoryNo)
				 && (sCMAcOdrDtCar1.MakerCode == sCMAcOdrDtCar2.MakerCode)
				 && (sCMAcOdrDtCar1.ModelCode == sCMAcOdrDtCar2.ModelCode)
				 && (sCMAcOdrDtCar1.ModelSubCode == sCMAcOdrDtCar2.ModelSubCode)
				 && (sCMAcOdrDtCar1.ModelName == sCMAcOdrDtCar2.ModelName)
				 && (sCMAcOdrDtCar1.CarInspectCertModel == sCMAcOdrDtCar2.CarInspectCertModel)
				 && (sCMAcOdrDtCar1.FullModel == sCMAcOdrDtCar2.FullModel)
				 && (sCMAcOdrDtCar1.FrameNo == sCMAcOdrDtCar2.FrameNo)
				 && (sCMAcOdrDtCar1.FrameModel == sCMAcOdrDtCar2.FrameModel)
				 && (sCMAcOdrDtCar1.ChassisNo == sCMAcOdrDtCar2.ChassisNo)
				 && (sCMAcOdrDtCar1.CarProperNo == sCMAcOdrDtCar2.CarProperNo)
				 && (sCMAcOdrDtCar1.ProduceTypeOfYearNum == sCMAcOdrDtCar2.ProduceTypeOfYearNum)
				 && (sCMAcOdrDtCar1.Comment == sCMAcOdrDtCar2.Comment)
				 && (sCMAcOdrDtCar1.RpColorCode == sCMAcOdrDtCar2.RpColorCode)
				 && (sCMAcOdrDtCar1.ColorName1 == sCMAcOdrDtCar2.ColorName1)
				 && (sCMAcOdrDtCar1.TrimCode == sCMAcOdrDtCar2.TrimCode)
				 && (sCMAcOdrDtCar1.TrimName == sCMAcOdrDtCar2.TrimName)
				 && (sCMAcOdrDtCar1.Mileage == sCMAcOdrDtCar2.Mileage)
				 && (sCMAcOdrDtCar1.EquipObj == sCMAcOdrDtCar2.EquipObj)
				 && (sCMAcOdrDtCar1.EnterpriseName == sCMAcOdrDtCar2.EnterpriseName)
				 && (sCMAcOdrDtCar1.UpdEmployeeName == sCMAcOdrDtCar2.UpdEmployeeName));
		}
		/// <summary>
		/// SCM受注データ(車両情報)比較処理
		/// </summary>
		/// <param name="target">比較対象のSCMAcOdrDtCarクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SCMAcOdrDtCarクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ArrayList Compare(SCMAcOdrDtCar target)
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
			if(this.InqOriginalEpCd.Trim() != target.InqOriginalEpCd.Trim())resList.Add("InqOriginalEpCd");//@@@@20230303
			if(this.InqOriginalSecCd != target.InqOriginalSecCd)resList.Add("InqOriginalSecCd");
			if(this.InquiryNumber != target.InquiryNumber)resList.Add("InquiryNumber");
			if(this.NumberPlate1Code != target.NumberPlate1Code)resList.Add("NumberPlate1Code");
			if(this.NumberPlate1Name != target.NumberPlate1Name)resList.Add("NumberPlate1Name");
			if(this.NumberPlate2 != target.NumberPlate2)resList.Add("NumberPlate2");
			if(this.NumberPlate3 != target.NumberPlate3)resList.Add("NumberPlate3");
			if(this.NumberPlate4 != target.NumberPlate4)resList.Add("NumberPlate4");
			if(this.ModelDesignationNo != target.ModelDesignationNo)resList.Add("ModelDesignationNo");
			if(this.CategoryNo != target.CategoryNo)resList.Add("CategoryNo");
			if(this.MakerCode != target.MakerCode)resList.Add("MakerCode");
			if(this.ModelCode != target.ModelCode)resList.Add("ModelCode");
			if(this.ModelSubCode != target.ModelSubCode)resList.Add("ModelSubCode");
			if(this.ModelName != target.ModelName)resList.Add("ModelName");
			if(this.CarInspectCertModel != target.CarInspectCertModel)resList.Add("CarInspectCertModel");
			if(this.FullModel != target.FullModel)resList.Add("FullModel");
			if(this.FrameNo != target.FrameNo)resList.Add("FrameNo");
			if(this.FrameModel != target.FrameModel)resList.Add("FrameModel");
			if(this.ChassisNo != target.ChassisNo)resList.Add("ChassisNo");
			if(this.CarProperNo != target.CarProperNo)resList.Add("CarProperNo");
			if(this.ProduceTypeOfYearNum != target.ProduceTypeOfYearNum)resList.Add("ProduceTypeOfYearNum");
			if(this.Comment != target.Comment)resList.Add("Comment");
			if(this.RpColorCode != target.RpColorCode)resList.Add("RpColorCode");
			if(this.ColorName1 != target.ColorName1)resList.Add("ColorName1");
			if(this.TrimCode != target.TrimCode)resList.Add("TrimCode");
			if(this.TrimName != target.TrimName)resList.Add("TrimName");
			if(this.Mileage != target.Mileage)resList.Add("Mileage");
			if(this.EquipObj != target.EquipObj)resList.Add("EquipObj");
			if(this.EnterpriseName != target.EnterpriseName)resList.Add("EnterpriseName");
			if(this.UpdEmployeeName != target.UpdEmployeeName)resList.Add("UpdEmployeeName");

			return resList;
		}

		/// <summary>
		/// SCM受注データ(車両情報)比較処理
		/// </summary>
		/// <param name="sCMAcOdrDtCar1">比較するSCMAcOdrDtCarクラスのインスタンス</param>
		/// <param name="sCMAcOdrDtCar2">比較するSCMAcOdrDtCarクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SCMAcOdrDtCarクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static ArrayList Compare(SCMAcOdrDtCar sCMAcOdrDtCar1, SCMAcOdrDtCar sCMAcOdrDtCar2)
		{
			ArrayList resList = new ArrayList();
			if(sCMAcOdrDtCar1.CreateDateTime != sCMAcOdrDtCar2.CreateDateTime)resList.Add("CreateDateTime");
			if(sCMAcOdrDtCar1.UpdateDateTime != sCMAcOdrDtCar2.UpdateDateTime)resList.Add("UpdateDateTime");
			if(sCMAcOdrDtCar1.EnterpriseCode != sCMAcOdrDtCar2.EnterpriseCode)resList.Add("EnterpriseCode");
			if(sCMAcOdrDtCar1.FileHeaderGuid != sCMAcOdrDtCar2.FileHeaderGuid)resList.Add("FileHeaderGuid");
			if(sCMAcOdrDtCar1.UpdEmployeeCode != sCMAcOdrDtCar2.UpdEmployeeCode)resList.Add("UpdEmployeeCode");
			if(sCMAcOdrDtCar1.UpdAssemblyId1 != sCMAcOdrDtCar2.UpdAssemblyId1)resList.Add("UpdAssemblyId1");
			if(sCMAcOdrDtCar1.UpdAssemblyId2 != sCMAcOdrDtCar2.UpdAssemblyId2)resList.Add("UpdAssemblyId2");
			if(sCMAcOdrDtCar1.LogicalDeleteCode != sCMAcOdrDtCar2.LogicalDeleteCode)resList.Add("LogicalDeleteCode");
			if(sCMAcOdrDtCar1.InqOriginalEpCd.Trim() != sCMAcOdrDtCar2.InqOriginalEpCd.Trim())resList.Add("InqOriginalEpCd");//@@@@20230303
			if(sCMAcOdrDtCar1.InqOriginalSecCd != sCMAcOdrDtCar2.InqOriginalSecCd)resList.Add("InqOriginalSecCd");
			if(sCMAcOdrDtCar1.InquiryNumber != sCMAcOdrDtCar2.InquiryNumber)resList.Add("InquiryNumber");
			if(sCMAcOdrDtCar1.NumberPlate1Code != sCMAcOdrDtCar2.NumberPlate1Code)resList.Add("NumberPlate1Code");
			if(sCMAcOdrDtCar1.NumberPlate1Name != sCMAcOdrDtCar2.NumberPlate1Name)resList.Add("NumberPlate1Name");
			if(sCMAcOdrDtCar1.NumberPlate2 != sCMAcOdrDtCar2.NumberPlate2)resList.Add("NumberPlate2");
			if(sCMAcOdrDtCar1.NumberPlate3 != sCMAcOdrDtCar2.NumberPlate3)resList.Add("NumberPlate3");
			if(sCMAcOdrDtCar1.NumberPlate4 != sCMAcOdrDtCar2.NumberPlate4)resList.Add("NumberPlate4");
			if(sCMAcOdrDtCar1.ModelDesignationNo != sCMAcOdrDtCar2.ModelDesignationNo)resList.Add("ModelDesignationNo");
			if(sCMAcOdrDtCar1.CategoryNo != sCMAcOdrDtCar2.CategoryNo)resList.Add("CategoryNo");
			if(sCMAcOdrDtCar1.MakerCode != sCMAcOdrDtCar2.MakerCode)resList.Add("MakerCode");
			if(sCMAcOdrDtCar1.ModelCode != sCMAcOdrDtCar2.ModelCode)resList.Add("ModelCode");
			if(sCMAcOdrDtCar1.ModelSubCode != sCMAcOdrDtCar2.ModelSubCode)resList.Add("ModelSubCode");
			if(sCMAcOdrDtCar1.ModelName != sCMAcOdrDtCar2.ModelName)resList.Add("ModelName");
			if(sCMAcOdrDtCar1.CarInspectCertModel != sCMAcOdrDtCar2.CarInspectCertModel)resList.Add("CarInspectCertModel");
			if(sCMAcOdrDtCar1.FullModel != sCMAcOdrDtCar2.FullModel)resList.Add("FullModel");
			if(sCMAcOdrDtCar1.FrameNo != sCMAcOdrDtCar2.FrameNo)resList.Add("FrameNo");
			if(sCMAcOdrDtCar1.FrameModel != sCMAcOdrDtCar2.FrameModel)resList.Add("FrameModel");
			if(sCMAcOdrDtCar1.ChassisNo != sCMAcOdrDtCar2.ChassisNo)resList.Add("ChassisNo");
			if(sCMAcOdrDtCar1.CarProperNo != sCMAcOdrDtCar2.CarProperNo)resList.Add("CarProperNo");
			if(sCMAcOdrDtCar1.ProduceTypeOfYearNum != sCMAcOdrDtCar2.ProduceTypeOfYearNum)resList.Add("ProduceTypeOfYearNum");
			if(sCMAcOdrDtCar1.Comment != sCMAcOdrDtCar2.Comment)resList.Add("Comment");
			if(sCMAcOdrDtCar1.RpColorCode != sCMAcOdrDtCar2.RpColorCode)resList.Add("RpColorCode");
			if(sCMAcOdrDtCar1.ColorName1 != sCMAcOdrDtCar2.ColorName1)resList.Add("ColorName1");
			if(sCMAcOdrDtCar1.TrimCode != sCMAcOdrDtCar2.TrimCode)resList.Add("TrimCode");
			if(sCMAcOdrDtCar1.TrimName != sCMAcOdrDtCar2.TrimName)resList.Add("TrimName");
			if(sCMAcOdrDtCar1.Mileage != sCMAcOdrDtCar2.Mileage)resList.Add("Mileage");
			if(sCMAcOdrDtCar1.EquipObj != sCMAcOdrDtCar2.EquipObj)resList.Add("EquipObj");
			if(sCMAcOdrDtCar1.EnterpriseName != sCMAcOdrDtCar2.EnterpriseName)resList.Add("EnterpriseName");
			if(sCMAcOdrDtCar1.UpdEmployeeName != sCMAcOdrDtCar2.UpdEmployeeName)resList.Add("UpdEmployeeName");

			return resList;
		}
	}
}
