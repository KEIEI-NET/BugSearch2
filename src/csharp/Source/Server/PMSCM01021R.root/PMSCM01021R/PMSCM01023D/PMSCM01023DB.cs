//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   SCM関連データデータパラメータ
//                  :   PMSCM01023D.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programmer       :   22008 長内 数馬
// Date             :   2009.05.13
//----------------------------------------------------------------------
// Update Note      :
//----------------------------------------------------------------------
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//**********************************************************************

using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   SCMAcOdrDtCarWork
	/// <summary>
	///                      SCM受注データ(車両情報)ワーク
	/// </summary>
	/// <remarks>
	/// <br>note             :   SCM受注データ(車両情報)ワークヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   2009/04/13</br>
	/// <br>Genarated Date   :   2009/05/29  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   2009/05/26  杉村</br>
	/// <br>                 :   ○項目削除</br>
	/// <br>                 :   問合せ日</br>
	/// <br>                 :   問合せ従業員コード</br>
	/// <br>                 :   問合せ従業員名称</br>
	/// <br>                 :   発注日</br>
	/// <br>                 :   発注者従業員コード</br>
	/// <br>                 :   発注者従業員名称</br>
	/// <br>Update Note      :   2009/06/17  杉村</br>
	/// <br>                 :   ○項目追加</br>
	/// <br>                 :   受注ステータス</br>
	/// <br>                 :   売上伝票番号</br>
	/// <br>                 :   ○キー変更</br>
	/// <br>                 :   3,9,10,11⇒3,9,10,11,37,38</br>
	/// <br>Update Note      :   2011/8/18  對馬</br>
	/// <br>                 :   ○項目追加</br>
	/// <br>                 :   №39～№40</br>
	/// <br>Update Note      :   2011/8/24  長内</br>
	/// <br>                 :   ○項目追加</br>
	/// <br>                 :   ミッション名称</br>
	/// <br>                 :   シフト名称</br>
    /// <br>Update Note      :   2012/05/31  30744 湯上 千加子</br>
    /// <br>                 :   ○項目追加</br>
    /// <br>                 :   初年度（NUMタイプ）</br>
    /// <br>                 :   車両付加情報オブジェクト</br>
    /// <br>                 :   装備部品オブジェクト</br>
    /// <br>Update Note      :   2013/04/19  30744 湯上 千加子</br>
    /// <br>                 :   SCM障害№10521対応</br>
    /// <br>                 :   車両管理コード追加</br>
    /// <br>Update Note      :   2013/05/09  30747 三戸 伸悟</br>
    /// <br>                 :   SCM障害№10384対応</br>
    /// <br>                 :   入庫予定日追加</br>
    /// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class SCMAcOdrDtCarWork : IFileHeader
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
		private Byte[] _equipObj = new Byte[0];

        /// <summary>受注ステータス</summary>
        /// <remarks>10:見積,20:受注,30:売上</remarks>
        private Int32 _acptAnOdrStatus;

        /// <summary>売上伝票番号</summary>
        /// <remarks>見積伝票番号,受注伝票番号,出荷伝票番号,売上伝票番号を兼ねる。</remarks>
        private string _salesSlipNum = "";

		/// <summary>号車</summary>
		private string _carNo = "";

		/// <summary>メーカー名称</summary>
		private string _makerName = "";

		/// <summary>グレード名称</summary>
		private string _gradeName = "";

		/// <summary>ボディー名称</summary>
		private string _bodyName = "";

		/// <summary>ドア数</summary>
		private Int32 _doorCount;

		/// <summary>エンジン型式名称</summary>
		/// <remarks>型式により変動</remarks>
		private string _engineModelNm = "";

		/// <summary>通称排気量</summary>
		/// <remarks>1600,2000等</remarks>
		private Int32 _cmnNmEngineDisPlace;

		/// <summary>原動機型式（エンジン）</summary>
		/// <remarks>車検証記載原動機型式</remarks>
		private string _engineModel = "";

		/// <summary>変速段数</summary>
		/// <remarks>2:2速,3:3速･･･,6:6速</remarks>
		private Int32 _numberOfGear;

		/// <summary>変速機名称</summary>
		private string _gearNm = "";

		/// <summary>E区分名称</summary>
		/// <remarks>型式により変動</remarks>
		private string _eDivNm = "";

		/// <summary>ミッション名称</summary>
		private string _transmissionNm = "";

		/// <summary>シフト名称</summary>
		private string _shiftNm = "";

        // ADD 2012/05/31 ----------------------------------------------------->>>>>
        /// <summary>初年度（NUMタイプ）</summary>
        private Int32 _firstEntryDateNumTyp;

        /// <summary>車両付加情報オブジェクト</summary>
        private Byte[] _carAddInf = new Byte[0];

        /// <summary>装備部品オブジェクト</summary>
        private Byte[] _equipPrtsObj = new Byte[0];
        // ADD 2012/05/31 -----------------------------------------------------<<<<<

        // ADD 2013/04/19 SCM障害№10521対応 ----------------------------------->>>>>
        /// <summary>車両管理コード</summary>
        private string _carMngCode = "";
        // ADD 2013/04/19 SCM障害№10521対応 -----------------------------------<<<<<

        // ADD 2013/05/09 SCM障害№10384対応 ----------------------------------->>>>>
        /// <summary>入庫予定日</summary>
        private Int32 _expectedCeDate;
        // ADD 2013/05/09 SCM障害№10384対応 -----------------------------------<<<<<

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

        /// public propaty name  :  AcptAnOdrStatus
        /// <summary>受注ステータスプロパティ</summary>
        /// <value>10:見積,20:受注,30:売上</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   受注ステータスプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AcptAnOdrStatus
        {
            get { return _acptAnOdrStatus; }
            set { _acptAnOdrStatus = value; }
        }

        /// public propaty name  :  SalesSlipNum
        /// <summary>売上伝票番号プロパティ</summary>
        /// <value>見積伝票番号,受注伝票番号,出荷伝票番号,売上伝票番号を兼ねる。</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上伝票番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SalesSlipNum
        {
            get { return _salesSlipNum; }
            set { _salesSlipNum = value; }
        }

		/// public propaty name  :  CarNo
		/// <summary>号車プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   号車プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string CarNo
		{
			get{return _carNo;}
			set{_carNo = value;}
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

		/// public propaty name  :  GradeName
		/// <summary>グレード名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   グレード名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string GradeName
		{
			get{return _gradeName;}
			set{_gradeName = value;}
		}

		/// public propaty name  :  BodyName
		/// <summary>ボディー名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ボディー名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string BodyName
		{
			get{return _bodyName;}
			set{_bodyName = value;}
		}

		/// public propaty name  :  DoorCount
		/// <summary>ドア数プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ドア数プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 DoorCount
		{
			get{return _doorCount;}
			set{_doorCount = value;}
		}

		/// public propaty name  :  EngineModelNm
		/// <summary>エンジン型式名称プロパティ</summary>
		/// <value>型式により変動</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   エンジン型式名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string EngineModelNm
		{
			get{return _engineModelNm;}
			set{_engineModelNm = value;}
		}

		/// public propaty name  :  CmnNmEngineDisPlace
		/// <summary>通称排気量プロパティ</summary>
		/// <value>1600,2000等</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   通称排気量プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 CmnNmEngineDisPlace
		{
			get{return _cmnNmEngineDisPlace;}
			set{_cmnNmEngineDisPlace = value;}
		}

		/// public propaty name  :  EngineModel
		/// <summary>原動機型式（エンジン）プロパティ</summary>
		/// <value>車検証記載原動機型式</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   原動機型式（エンジン）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string EngineModel
		{
			get{return _engineModel;}
			set{_engineModel = value;}
		}

		/// public propaty name  :  NumberOfGear
		/// <summary>変速段数プロパティ</summary>
		/// <value>2:2速,3:3速･･･,6:6速</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   変速段数プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 NumberOfGear
		{
			get{return _numberOfGear;}
			set{_numberOfGear = value;}
		}

		/// public propaty name  :  GearNm
		/// <summary>変速機名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   変速機名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string GearNm
		{
			get{return _gearNm;}
			set{_gearNm = value;}
		}

		/// public propaty name  :  EDivNm
		/// <summary>E区分名称プロパティ</summary>
		/// <value>型式により変動</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   E区分名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string EDivNm
		{
			get{return _eDivNm;}
			set{_eDivNm = value;}
		}

		/// public propaty name  :  TransmissionNm
		/// <summary>ミッション名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ミッション名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string TransmissionNm
		{
			get{return _transmissionNm;}
			set{_transmissionNm = value;}
		}

		/// public propaty name  :  ShiftNm
		/// <summary>シフト名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   シフト名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string ShiftNm
		{
			get{return _shiftNm;}
			set{_shiftNm = value;}
		}

        // ADD 2012/05/31 ----------------------------------------------------->>>>>
        /// public propaty name  :  FirstEntryDateNumTyp
        /// <summary>初年度（NUMタイプ）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   初年度（NUMタイプ）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 FirstEntryDateNumTyp
        {
            get { return _firstEntryDateNumTyp; }
            set { _firstEntryDateNumTyp = value; }
        }

        /// public propaty name  :  CarAddInf
        /// <summary>車両付加情報オブジェクトプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車両付加情報オブジェクトプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Byte[] CarAddInf
        {
            get { return _carAddInf; }
            set { _carAddInf = value; }
        }

        /// public propaty name  :  EquipPrtsObj
        /// <summary>装備部品オブジェクトプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   装備部品オブジェクトプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Byte[] EquipPrtsObj
        {
            get { return _equipPrtsObj; }
            set { _equipPrtsObj = value; }
        }

        // ADD 2012/05/31 -----------------------------------------------------<<<<<

        // ADD 2013/04/19 SCM障害№10521対応 ----------------------------------->>>>>
        /// public propaty name  :  CarMngCode
        /// <summary>車両管理コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車両管理コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CarMngCode
        {
            get { return _carMngCode; }
            set { _carMngCode = value; }
        }
        // ADD 2013/04/19 SCM障害№10521対応 -----------------------------------<<<<<

        // ADD 2013/05/09 SCM障害№10384対応 ----------------------------------->>>>>
        /// public propaty name  :  ExpectedCeDate
        /// <summary>入庫予定日プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入庫予定日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ExpectedCeDate
        {
            get { return _expectedCeDate; }
            set { _expectedCeDate = value; }
        }
        // ADD 2013/05/09 SCM障害№10384対応 -----------------------------------<<<<<

		/// <summary>
		/// SCM受注データ(車両情報)ワークコンストラクタ
		/// </summary>
		/// <returns>SCMAcOdrDtCarWorkクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SCMAcOdrDtCarWorkクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public SCMAcOdrDtCarWork()
		{
		}

	}

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>SCMAcOdrDtCarWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   SCMAcOdrDtCarWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class SCMAcOdrDtCarWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   SCMAcOdrDtCarWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  SCMAcOdrDtCarWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is SCMAcOdrDtCarWork || graph is ArrayList || graph is SCMAcOdrDtCarWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(SCMAcOdrDtCarWork).FullName));

            if (graph != null && graph is SCMAcOdrDtCarWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.SCMAcOdrDtCarWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is SCMAcOdrDtCarWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((SCMAcOdrDtCarWork[])graph).Length;
            }
            else if (graph is SCMAcOdrDtCarWork)
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
            //問合せ元企業コード
            serInfo.MemberInfo.Add(typeof(string)); //InqOriginalEpCd
            //問合せ元拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //InqOriginalSecCd
            //問合せ番号
            serInfo.MemberInfo.Add(typeof(Int64)); //InquiryNumber
            //陸運事務所番号
            serInfo.MemberInfo.Add(typeof(Int32)); //NumberPlate1Code
            //陸運事務局名称
            serInfo.MemberInfo.Add(typeof(string)); //NumberPlate1Name
            //車両登録番号（種別）
            serInfo.MemberInfo.Add(typeof(string)); //NumberPlate2
            //車両登録番号（カナ）
            serInfo.MemberInfo.Add(typeof(string)); //NumberPlate3
            //車両登録番号（プレート番号）
            serInfo.MemberInfo.Add(typeof(Int32)); //NumberPlate4
            //型式指定番号
            serInfo.MemberInfo.Add(typeof(Int32)); //ModelDesignationNo
            //類別番号
            serInfo.MemberInfo.Add(typeof(Int32)); //CategoryNo
            //メーカーコード
            serInfo.MemberInfo.Add(typeof(Int32)); //MakerCode
            //車種コード
            serInfo.MemberInfo.Add(typeof(Int32)); //ModelCode
            //車種サブコード
            serInfo.MemberInfo.Add(typeof(Int32)); //ModelSubCode
            //車種名
            serInfo.MemberInfo.Add(typeof(string)); //ModelName
            //車検証型式
            serInfo.MemberInfo.Add(typeof(string)); //CarInspectCertModel
            //型式（フル型）
            serInfo.MemberInfo.Add(typeof(string)); //FullModel
            //車台番号
            serInfo.MemberInfo.Add(typeof(string)); //FrameNo
            //車台型式
            serInfo.MemberInfo.Add(typeof(string)); //FrameModel
            //シャシーNo
            serInfo.MemberInfo.Add(typeof(string)); //ChassisNo
            //車両固有番号
            serInfo.MemberInfo.Add(typeof(Int32)); //CarProperNo
            //生産年式（NUMタイプ）
            serInfo.MemberInfo.Add(typeof(Int32)); //ProduceTypeOfYearNum
            //コメント
            serInfo.MemberInfo.Add(typeof(string)); //Comment
            //リペアカラーコード
            serInfo.MemberInfo.Add(typeof(string)); //RpColorCode
            //カラー名称1
            serInfo.MemberInfo.Add(typeof(string)); //ColorName1
            //トリムコード
            serInfo.MemberInfo.Add(typeof(string)); //TrimCode
            //トリム名称
            serInfo.MemberInfo.Add(typeof(string)); //TrimName
            //車両走行距離
            serInfo.MemberInfo.Add(typeof(Int32)); //Mileage
            //装備オブジェクト
            serInfo.MemberInfo.Add(typeof(Byte[])); //EquipObj
            //受注ステータス
            serInfo.MemberInfo.Add(typeof(Int32)); //AcptAnOdrStatus
            //売上伝票番号
            serInfo.MemberInfo.Add(typeof(string)); //SalesSlipNum
    		//号車
    		serInfo.MemberInfo.Add( typeof(string) ); //CarNo
    		//メーカー名称
    		serInfo.MemberInfo.Add( typeof(string) ); //MakerName
    		//グレード名称
    		serInfo.MemberInfo.Add( typeof(string) ); //GradeName
    		//ボディー名称
    		serInfo.MemberInfo.Add( typeof(string) ); //BodyName
    		//ドア数
    		serInfo.MemberInfo.Add( typeof(Int32) ); //DoorCount
    		//エンジン型式名称
    		serInfo.MemberInfo.Add( typeof(string) ); //EngineModelNm
    		//通称排気量
    		serInfo.MemberInfo.Add( typeof(Int32) ); //CmnNmEngineDisPlace
    		//原動機型式（エンジン）
    		serInfo.MemberInfo.Add( typeof(string) ); //EngineModel
    		//変速段数
    		serInfo.MemberInfo.Add( typeof(Int32) ); //NumberOfGear
    		//変速機名称
    		serInfo.MemberInfo.Add( typeof(string) ); //GearNm
    		//E区分名称
    		serInfo.MemberInfo.Add( typeof(string) ); //EDivNm
    		//ミッション名称
    		serInfo.MemberInfo.Add( typeof(string) ); //TransmissionNm
    		//シフト名称
    		serInfo.MemberInfo.Add( typeof(string) ); //ShiftNm
            // ADD 2012/05/31 ----------------------------------------------------->>>>>
            //初年度（NUMタイプ）
            serInfo.MemberInfo.Add(typeof(Int32)); //FirstEntryDateNumTyp
            //車両付加情報オブジェクト
            serInfo.MemberInfo.Add(typeof(Byte[])); //CarAddInf
            //装備部品オブジェクト
            serInfo.MemberInfo.Add(typeof(Byte[])); //EquipPrtsObj
            // ADD 2012/05/31 -----------------------------------------------------<<<<<

            // ADD 2013/04/19 SCM障害№10521対応 ----------------------------------->>>>>
            //車両管理コード
            serInfo.MemberInfo.Add(typeof(string)); //CarMngCode
            // ADD 2013/04/19 SCM障害№10521対応 -----------------------------------<<<<<

            // ADD 2013/05/09 SCM障害№10384対応 ----------------------------------->>>>>
            //入庫予定日
            serInfo.MemberInfo.Add(typeof(Int32)); //ExpectedCeDate
            // ADD 2013/05/09 SCM障害№10384対応 -----------------------------------<<<<<

            serInfo.Serialize(writer, serInfo);
            if (graph is SCMAcOdrDtCarWork)
            {
                SCMAcOdrDtCarWork temp = (SCMAcOdrDtCarWork)graph;

                SetSCMAcOdrDtCarWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is SCMAcOdrDtCarWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((SCMAcOdrDtCarWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (SCMAcOdrDtCarWork temp in lst)
                {
                    SetSCMAcOdrDtCarWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// SCMAcOdrDtCarWorkメンバ数(publicプロパティ数)
        /// </summary>
        // UPD 2012/05/31 ---------------------------------->>>>>
        //private const int currentMemberCount = 51;
        // UPD 2013/04/19 SCM障害№10521対応 ----------------------------------->>>>>
        //private const int currentMemberCount = 54;
        // UPD 2013/05/09 SCM障害№10384対応 ----------------------------------->>>>>
        //private const int currentMemberCount = 55;
        private const int currentMemberCount = 56;
        // UPD 2013/05/09 SCM障害№10384対応 -----------------------------------<<<<<
        // UPD 2013/04/19 SCM障害№10521対応 -----------------------------------<<<<<
        // UPD 2012/05/31 ----------------------------------<<<<<

        /// <summary>
        ///  SCMAcOdrDtCarWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   SCMAcOdrDtCarWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetSCMAcOdrDtCarWork(System.IO.BinaryWriter writer, SCMAcOdrDtCarWork temp)
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
            //問合せ元企業コード
            writer.Write(temp.InqOriginalEpCd.Trim());	//@@@@20230303
            //問合せ元拠点コード
            writer.Write(temp.InqOriginalSecCd);
            //問合せ番号
            writer.Write(temp.InquiryNumber);
            //陸運事務所番号
            writer.Write(temp.NumberPlate1Code);
            //陸運事務局名称
            writer.Write(temp.NumberPlate1Name);
            //車両登録番号（種別）
            writer.Write(temp.NumberPlate2);
            //車両登録番号（カナ）
            writer.Write(temp.NumberPlate3);
            //車両登録番号（プレート番号）
            writer.Write(temp.NumberPlate4);
            //型式指定番号
            writer.Write(temp.ModelDesignationNo);
            //類別番号
            writer.Write(temp.CategoryNo);
            //メーカーコード
            writer.Write(temp.MakerCode);
            //車種コード
            writer.Write(temp.ModelCode);
            //車種サブコード
            writer.Write(temp.ModelSubCode);
            //車種名
            writer.Write(temp.ModelName);
            //車検証型式
            writer.Write(temp.CarInspectCertModel);
            //型式（フル型）
            writer.Write(temp.FullModel);
            //車台番号
            writer.Write(temp.FrameNo);
            //車台型式
            writer.Write(temp.FrameModel);
            //シャシーNo
            writer.Write(temp.ChassisNo);
            //車両固有番号
            writer.Write(temp.CarProperNo);
            //生産年式（NUMタイプ）
            writer.Write(temp.ProduceTypeOfYearNum);
            //コメント
            writer.Write(temp.Comment);
            //リペアカラーコード
            writer.Write(temp.RpColorCode);
            //カラー名称1
            writer.Write(temp.ColorName1);
            //トリムコード
            writer.Write(temp.TrimCode);
            //トリム名称
            writer.Write(temp.TrimName);
            //車両走行距離
            writer.Write(temp.Mileage);
            //装備オブジェクト
            writer.Write(temp.EquipObj.Length);
            writer.Write(temp.EquipObj);
            //受注ステータス
            writer.Write(temp.AcptAnOdrStatus);
            //売上伝票番号
            writer.Write(temp.SalesSlipNum);
    		//号車
    		writer.Write( temp.CarNo );
    		//メーカー名称
    		writer.Write( temp.MakerName );
    		//グレード名称
    		writer.Write( temp.GradeName );
    		//ボディー名称
    		writer.Write( temp.BodyName );
    		//ドア数
    		writer.Write( temp.DoorCount );
    		//エンジン型式名称
    		writer.Write( temp.EngineModelNm );
    		//通称排気量
    		writer.Write( temp.CmnNmEngineDisPlace );
    		//原動機型式（エンジン）
    		writer.Write( temp.EngineModel );
    		//変速段数
    		writer.Write( temp.NumberOfGear );
    		//変速機名称
    		writer.Write( temp.GearNm );
    		//E区分名称
    		writer.Write( temp.EDivNm );
    		//ミッション名称
    		writer.Write( temp.TransmissionNm );
    		//シフト名称
    		writer.Write( temp.ShiftNm );
            // ADD 2012/05/31 ----------------------------------------------------->>>>>
            //初年度（NUMタイプ）
            writer.Write(temp.FirstEntryDateNumTyp);
            //車両付加情報オブジェクト
            writer.Write(temp.CarAddInf.Length);
            writer.Write(temp.CarAddInf);
            //装備部品オブジェクト
            writer.Write(temp.EquipPrtsObj.Length);
            writer.Write(temp.EquipPrtsObj);
            // ADD 2012/05/31 -----------------------------------------------------<<<<<
            // ADD 2013/04/19 SCM障害№10521対応 ----------------------------------->>>>>
            //車両管理コード
            writer.Write(temp.CarMngCode);
            // ADD 2013/04/19 SCM障害№10521対応 -----------------------------------<<<<<
            // ADD 2013/05/09 SCM障害№10384対応 ----------------------------------->>>>>
            //入庫予定日
            writer.Write(temp.ExpectedCeDate);
            // ADD 2013/05/09 SCM障害№10384対応 -----------------------------------<<<<<
        }

        /// <summary>
        ///  SCMAcOdrDtCarWorkインスタンス取得
        /// </summary>
        /// <returns>SCMAcOdrDtCarWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SCMAcOdrDtCarWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private SCMAcOdrDtCarWork GetSCMAcOdrDtCarWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            SCMAcOdrDtCarWork temp = new SCMAcOdrDtCarWork();

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
            //問合せ元企業コード
            temp.InqOriginalEpCd = reader.ReadString().Trim();//@@@@20230303
            //問合せ元拠点コード
            temp.InqOriginalSecCd = reader.ReadString();
            //問合せ番号
            temp.InquiryNumber = reader.ReadInt64();
            //陸運事務所番号
            temp.NumberPlate1Code = reader.ReadInt32();
            //陸運事務局名称
            temp.NumberPlate1Name = reader.ReadString();
            //車両登録番号（種別）
            temp.NumberPlate2 = reader.ReadString();
            //車両登録番号（カナ）
            temp.NumberPlate3 = reader.ReadString();
            //車両登録番号（プレート番号）
            temp.NumberPlate4 = reader.ReadInt32();
            //型式指定番号
            temp.ModelDesignationNo = reader.ReadInt32();
            //類別番号
            temp.CategoryNo = reader.ReadInt32();
            //メーカーコード
            temp.MakerCode = reader.ReadInt32();
            //車種コード
            temp.ModelCode = reader.ReadInt32();
            //車種サブコード
            temp.ModelSubCode = reader.ReadInt32();
            //車種名
            temp.ModelName = reader.ReadString();
            //車検証型式
            temp.CarInspectCertModel = reader.ReadString();
            //型式（フル型）
            temp.FullModel = reader.ReadString();
            //車台番号
            temp.FrameNo = reader.ReadString();
            //車台型式
            temp.FrameModel = reader.ReadString();
            //シャシーNo
            temp.ChassisNo = reader.ReadString();
            //車両固有番号
            temp.CarProperNo = reader.ReadInt32();
            //生産年式（NUMタイプ）
            temp.ProduceTypeOfYearNum = reader.ReadInt32();
            //コメント
            temp.Comment = reader.ReadString();
            //リペアカラーコード
            temp.RpColorCode = reader.ReadString();
            //カラー名称1
            temp.ColorName1 = reader.ReadString();
            //トリムコード
            temp.TrimCode = reader.ReadString();
            //トリム名称
            temp.TrimName = reader.ReadString();
            //車両走行距離
            temp.Mileage = reader.ReadInt32();
            //装備オブジェクト
            int equipObjLength = reader.ReadInt32();
            temp.EquipObj = reader.ReadBytes(equipObjLength);
            //受注ステータス
            temp.AcptAnOdrStatus = reader.ReadInt32();
            //売上伝票番号
            temp.SalesSlipNum = reader.ReadString();
			//号車
    		temp.CarNo = reader.ReadString();
    		//メーカー名称
    		temp.MakerName = reader.ReadString();
    		//グレード名称
    		temp.GradeName = reader.ReadString();
    		//ボディー名称
    		temp.BodyName = reader.ReadString();
    		//ドア数
    		temp.DoorCount = reader.ReadInt32();
    		//エンジン型式名称
    		temp.EngineModelNm = reader.ReadString();
    		//通称排気量
    		temp.CmnNmEngineDisPlace = reader.ReadInt32();
    		//原動機型式（エンジン）
    		temp.EngineModel = reader.ReadString();
    		//変速段数
    		temp.NumberOfGear = reader.ReadInt32();
    		//変速機名称
    		temp.GearNm = reader.ReadString();
    		//E区分名称
    		temp.EDivNm = reader.ReadString();
    		//ミッション名称
    		temp.TransmissionNm = reader.ReadString();
    		//シフト名称
    		temp.ShiftNm = reader.ReadString();
            // ADD 2012/05/31 ----------------------------------------------------->>>>>
            //初年度（NUMタイプ）
            temp.FirstEntryDateNumTyp = reader.ReadInt32();
            //車両付加情報オブジェクト
            int carAddInfLength = reader.ReadInt32();
            temp.CarAddInf = reader.ReadBytes(carAddInfLength);
            //装備部品オブジェクト
            int equipPrtsObjLength = reader.ReadInt32();
            temp.EquipPrtsObj = reader.ReadBytes(equipPrtsObjLength);
            // ADD 2012/05/31 -----------------------------------------------------<<<<<

            // ADD 2013/04/19 SCM障害№10521対応 ----------------------------------->>>>>
            //車両管理コード
            temp.CarMngCode = reader.ReadString();
            // ADD 2013/04/19 SCM障害№10521対応 -----------------------------------<<<<<

            // ADD 2013/05/09 SCM障害№10384対応 ----------------------------------->>>>>
            //入庫予定日
            temp.ExpectedCeDate = reader.ReadInt32();
            // ADD 2013/05/09 SCM障害№10384対応 -----------------------------------<<<<<


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
        /// <returns>SCMAcOdrDtCarWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SCMAcOdrDtCarWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                SCMAcOdrDtCarWork temp = GetSCMAcOdrDtCarWork(reader, serInfo);
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
                    retValue = (SCMAcOdrDtCarWork[])lst.ToArray(typeof(SCMAcOdrDtCarWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

}
