using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   ScmOdDtCar
    /// <summary>
    ///                      SCM受発注データ(車両情報)
    /// </summary>
    /// <remarks>
    /// <br>note             :   SCM受発注データ(車両情報)ヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2009/2/20</br>
    /// <br>Genarated Date   :   2011/08/24  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2011/7/28  阿間見　充</br>
    /// <br>                 :   項目追加</br>
    /// <br>                 :    No32.号車</br>
    /// <br>Update Note      :   2011/7/29  岩本　勇</br>
    /// <br>                 :   項目追加</br>
    /// <br>                 :   　No33-No42</br>
    /// <br>Update Note      :   2011/8/23  岩本　勇</br>
    /// <br>                 :   項目追加</br>
    /// <br>                 :   43,44</br>
    /// </remarks>
    public class ScmOdDtCar
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
        private byte[] _equipObj;

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

        /// public propaty name  :  InqOriginalEpCd
        /// <summary>問合せ元企業コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   問合せ元企業コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string InqOriginalEpCd
        {
            get { return _inqOriginalEpCd; }
            set { _inqOriginalEpCd = value; }
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
            get { return _inqOriginalSecCd; }
            set { _inqOriginalSecCd = value; }
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
            get { return _inquiryNumber; }
            set { _inquiryNumber = value; }
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
            get { return _numberPlate1Code; }
            set { _numberPlate1Code = value; }
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
            get { return _numberPlate1Name; }
            set { _numberPlate1Name = value; }
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
            get { return _numberPlate2; }
            set { _numberPlate2 = value; }
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
            get { return _numberPlate3; }
            set { _numberPlate3 = value; }
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
            get { return _numberPlate4; }
            set { _numberPlate4 = value; }
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
            get { return _modelDesignationNo; }
            set { _modelDesignationNo = value; }
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
            get { return _categoryNo; }
            set { _categoryNo = value; }
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
            get { return _makerCode; }
            set { _makerCode = value; }
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
            get { return _modelCode; }
            set { _modelCode = value; }
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
            get { return _modelSubCode; }
            set { _modelSubCode = value; }
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
            get { return _modelName; }
            set { _modelName = value; }
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
            get { return _carInspectCertModel; }
            set { _carInspectCertModel = value; }
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
            get { return _fullModel; }
            set { _fullModel = value; }
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
            get { return _frameNo; }
            set { _frameNo = value; }
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
            get { return _frameModel; }
            set { _frameModel = value; }
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
            get { return _chassisNo; }
            set { _chassisNo = value; }
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
            get { return _carProperNo; }
            set { _carProperNo = value; }
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
            get { return _produceTypeOfYearNum; }
            set { _produceTypeOfYearNum = value; }
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
            get { return _comment; }
            set { _comment = value; }
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
            get { return _rpColorCode; }
            set { _rpColorCode = value; }
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
            get { return _colorName1; }
            set { _colorName1 = value; }
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
            get { return _trimCode; }
            set { _trimCode = value; }
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
            get { return _trimName; }
            set { _trimName = value; }
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
            get { return _mileage; }
            set { _mileage = value; }
        }

        /// public propaty name  :  EquipObj
        /// <summary>装備オブジェクトプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   装備オブジェクトプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public byte[] EquipObj
        {
            get { return _equipObj; }
            set { _equipObj = value; }
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
            get { return _carNo; }
            set { _carNo = value; }
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
            get { return _makerName; }
            set { _makerName = value; }
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
            get { return _gradeName; }
            set { _gradeName = value; }
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
            get { return _bodyName; }
            set { _bodyName = value; }
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
            get { return _doorCount; }
            set { _doorCount = value; }
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
            get { return _engineModelNm; }
            set { _engineModelNm = value; }
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
            get { return _cmnNmEngineDisPlace; }
            set { _cmnNmEngineDisPlace = value; }
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
            get { return _engineModel; }
            set { _engineModel = value; }
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
            get { return _numberOfGear; }
            set { _numberOfGear = value; }
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
            get { return _gearNm; }
            set { _gearNm = value; }
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
            get { return _eDivNm; }
            set { _eDivNm = value; }
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
            get { return _transmissionNm; }
            set { _transmissionNm = value; }
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
            get { return _shiftNm; }
            set { _shiftNm = value; }
        }


        /// <summary>
        /// SCM受発注データ(車両情報)コンストラクタ
        /// </summary>
        /// <returns>ScmOdDtCarクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   ScmOdDtCarクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ScmOdDtCar()
        {
        }

        /// <summary>
        /// SCM受発注データ(車両情報)コンストラクタ
        /// </summary>
        /// <param name="createDateTime">作成日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="updateDateTime">更新日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
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
        /// <param name="carNo">号車</param>
        /// <param name="makerName">メーカー名称</param>
        /// <param name="gradeName">グレード名称</param>
        /// <param name="bodyName">ボディー名称</param>
        /// <param name="doorCount">ドア数</param>
        /// <param name="engineModelNm">エンジン型式名称(型式により変動)</param>
        /// <param name="cmnNmEngineDisPlace">通称排気量(1600,2000等)</param>
        /// <param name="engineModel">原動機型式（エンジン）(車検証記載原動機型式)</param>
        /// <param name="numberOfGear">変速段数(2:2速,3:3速･･･,6:6速)</param>
        /// <param name="gearNm">変速機名称</param>
        /// <param name="eDivNm">E区分名称(型式により変動)</param>
        /// <param name="transmissionNm">ミッション名称</param>
        /// <param name="shiftNm">シフト名称</param>
        /// <returns>ScmOdDtCarクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   ScmOdDtCarクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ScmOdDtCar(DateTime createDateTime, DateTime updateDateTime, Int32 logicalDeleteCode, string inqOriginalEpCd, string inqOriginalSecCd, Int64 inquiryNumber, Int32 numberPlate1Code, string numberPlate1Name, string numberPlate2, string numberPlate3, Int32 numberPlate4, Int32 modelDesignationNo, Int32 categoryNo, Int32 makerCode, Int32 modelCode, Int32 modelSubCode, string modelName, string carInspectCertModel, string fullModel, string frameNo, string frameModel, string chassisNo, Int32 carProperNo, Int32 produceTypeOfYearNum, string comment, string rpColorCode, string colorName1, string trimCode, string trimName, Int32 mileage, byte[] equipObj, string carNo, string makerName, string gradeName, string bodyName, Int32 doorCount, string engineModelNm, Int32 cmnNmEngineDisPlace, string engineModel, Int32 numberOfGear, string gearNm, string eDivNm, string transmissionNm, string shiftNm)
        {
            this.CreateDateTime = createDateTime;
            this.UpdateDateTime = updateDateTime;
            this._logicalDeleteCode = logicalDeleteCode;
            this._inqOriginalEpCd = inqOriginalEpCd;
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
            this._carNo = carNo;
            this._makerName = makerName;
            this._gradeName = gradeName;
            this._bodyName = bodyName;
            this._doorCount = doorCount;
            this._engineModelNm = engineModelNm;
            this._cmnNmEngineDisPlace = cmnNmEngineDisPlace;
            this._engineModel = engineModel;
            this._numberOfGear = numberOfGear;
            this._gearNm = gearNm;
            this._eDivNm = eDivNm;
            this._transmissionNm = transmissionNm;
            this._shiftNm = shiftNm;

        }

        /// <summary>
        /// SCM受発注データ(車両情報)複製処理
        /// </summary>
        /// <returns>ScmOdDtCarクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいScmOdDtCarクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ScmOdDtCar Clone()
        {
            return new ScmOdDtCar(this._createDateTime, this._updateDateTime, this._logicalDeleteCode, this._inqOriginalEpCd, this._inqOriginalSecCd, this._inquiryNumber, this._numberPlate1Code, this._numberPlate1Name, this._numberPlate2, this._numberPlate3, this._numberPlate4, this._modelDesignationNo, this._categoryNo, this._makerCode, this._modelCode, this._modelSubCode, this._modelName, this._carInspectCertModel, this._fullModel, this._frameNo, this._frameModel, this._chassisNo, this._carProperNo, this._produceTypeOfYearNum, this._comment, this._rpColorCode, this._colorName1, this._trimCode, this._trimName, this._mileage, this._equipObj, this._carNo, this._makerName, this._gradeName, this._bodyName, this._doorCount, this._engineModelNm, this._cmnNmEngineDisPlace, this._engineModel, this._numberOfGear, this._gearNm, this._eDivNm, this._transmissionNm, this._shiftNm);
        }

        /// <summary>
        /// SCM受発注データ(車両情報)比較処理
        /// </summary>
        /// <param name="target">比較対象のScmOdDtCarクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   ScmOdDtCarクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool Equals(ScmOdDtCar target)
        {
            return ((this.CreateDateTime == target.CreateDateTime)
                 && (this.UpdateDateTime == target.UpdateDateTime)
                 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
                 && (this.InqOriginalEpCd == target.InqOriginalEpCd)
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
                 && (this.CarNo == target.CarNo)
                 && (this.MakerName == target.MakerName)
                 && (this.GradeName == target.GradeName)
                 && (this.BodyName == target.BodyName)
                 && (this.DoorCount == target.DoorCount)
                 && (this.EngineModelNm == target.EngineModelNm)
                 && (this.CmnNmEngineDisPlace == target.CmnNmEngineDisPlace)
                 && (this.EngineModel == target.EngineModel)
                 && (this.NumberOfGear == target.NumberOfGear)
                 && (this.GearNm == target.GearNm)
                 && (this.EDivNm == target.EDivNm)
                 && (this.TransmissionNm == target.TransmissionNm)
                 && (this.ShiftNm == target.ShiftNm));
        }

        /// <summary>
        /// SCM受発注データ(車両情報)比較処理
        /// </summary>
        /// <param name="scmOdDtCar1">
        ///                    比較するScmOdDtCarクラスのインスタンス
        /// </param>
        /// <param name="scmOdDtCar2">比較するScmOdDtCarクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   ScmOdDtCarクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static bool Equals(ScmOdDtCar scmOdDtCar1, ScmOdDtCar scmOdDtCar2)
        {
            return ((scmOdDtCar1.CreateDateTime == scmOdDtCar2.CreateDateTime)
                 && (scmOdDtCar1.UpdateDateTime == scmOdDtCar2.UpdateDateTime)
                 && (scmOdDtCar1.LogicalDeleteCode == scmOdDtCar2.LogicalDeleteCode)
                 && (scmOdDtCar1.InqOriginalEpCd == scmOdDtCar2.InqOriginalEpCd)
                 && (scmOdDtCar1.InqOriginalSecCd == scmOdDtCar2.InqOriginalSecCd)
                 && (scmOdDtCar1.InquiryNumber == scmOdDtCar2.InquiryNumber)
                 && (scmOdDtCar1.NumberPlate1Code == scmOdDtCar2.NumberPlate1Code)
                 && (scmOdDtCar1.NumberPlate1Name == scmOdDtCar2.NumberPlate1Name)
                 && (scmOdDtCar1.NumberPlate2 == scmOdDtCar2.NumberPlate2)
                 && (scmOdDtCar1.NumberPlate3 == scmOdDtCar2.NumberPlate3)
                 && (scmOdDtCar1.NumberPlate4 == scmOdDtCar2.NumberPlate4)
                 && (scmOdDtCar1.ModelDesignationNo == scmOdDtCar2.ModelDesignationNo)
                 && (scmOdDtCar1.CategoryNo == scmOdDtCar2.CategoryNo)
                 && (scmOdDtCar1.MakerCode == scmOdDtCar2.MakerCode)
                 && (scmOdDtCar1.ModelCode == scmOdDtCar2.ModelCode)
                 && (scmOdDtCar1.ModelSubCode == scmOdDtCar2.ModelSubCode)
                 && (scmOdDtCar1.ModelName == scmOdDtCar2.ModelName)
                 && (scmOdDtCar1.CarInspectCertModel == scmOdDtCar2.CarInspectCertModel)
                 && (scmOdDtCar1.FullModel == scmOdDtCar2.FullModel)
                 && (scmOdDtCar1.FrameNo == scmOdDtCar2.FrameNo)
                 && (scmOdDtCar1.FrameModel == scmOdDtCar2.FrameModel)
                 && (scmOdDtCar1.ChassisNo == scmOdDtCar2.ChassisNo)
                 && (scmOdDtCar1.CarProperNo == scmOdDtCar2.CarProperNo)
                 && (scmOdDtCar1.ProduceTypeOfYearNum == scmOdDtCar2.ProduceTypeOfYearNum)
                 && (scmOdDtCar1.Comment == scmOdDtCar2.Comment)
                 && (scmOdDtCar1.RpColorCode == scmOdDtCar2.RpColorCode)
                 && (scmOdDtCar1.ColorName1 == scmOdDtCar2.ColorName1)
                 && (scmOdDtCar1.TrimCode == scmOdDtCar2.TrimCode)
                 && (scmOdDtCar1.TrimName == scmOdDtCar2.TrimName)
                 && (scmOdDtCar1.Mileage == scmOdDtCar2.Mileage)
                 && (scmOdDtCar1.EquipObj == scmOdDtCar2.EquipObj)
                 && (scmOdDtCar1.CarNo == scmOdDtCar2.CarNo)
                 && (scmOdDtCar1.MakerName == scmOdDtCar2.MakerName)
                 && (scmOdDtCar1.GradeName == scmOdDtCar2.GradeName)
                 && (scmOdDtCar1.BodyName == scmOdDtCar2.BodyName)
                 && (scmOdDtCar1.DoorCount == scmOdDtCar2.DoorCount)
                 && (scmOdDtCar1.EngineModelNm == scmOdDtCar2.EngineModelNm)
                 && (scmOdDtCar1.CmnNmEngineDisPlace == scmOdDtCar2.CmnNmEngineDisPlace)
                 && (scmOdDtCar1.EngineModel == scmOdDtCar2.EngineModel)
                 && (scmOdDtCar1.NumberOfGear == scmOdDtCar2.NumberOfGear)
                 && (scmOdDtCar1.GearNm == scmOdDtCar2.GearNm)
                 && (scmOdDtCar1.EDivNm == scmOdDtCar2.EDivNm)
                 && (scmOdDtCar1.TransmissionNm == scmOdDtCar2.TransmissionNm)
                 && (scmOdDtCar1.ShiftNm == scmOdDtCar2.ShiftNm));
        }
        /// <summary>
        /// SCM受発注データ(車両情報)比較処理
        /// </summary>
        /// <param name="target">比較対象のScmOdDtCarクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   ScmOdDtCarクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList Compare(ScmOdDtCar target)
        {
            ArrayList resList = new ArrayList();
            if (this.CreateDateTime != target.CreateDateTime) resList.Add("CreateDateTime");
            if (this.UpdateDateTime != target.UpdateDateTime) resList.Add("UpdateDateTime");
            if (this.LogicalDeleteCode != target.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (this.InqOriginalEpCd != target.InqOriginalEpCd) resList.Add("InqOriginalEpCd");
            if (this.InqOriginalSecCd != target.InqOriginalSecCd) resList.Add("InqOriginalSecCd");
            if (this.InquiryNumber != target.InquiryNumber) resList.Add("InquiryNumber");
            if (this.NumberPlate1Code != target.NumberPlate1Code) resList.Add("NumberPlate1Code");
            if (this.NumberPlate1Name != target.NumberPlate1Name) resList.Add("NumberPlate1Name");
            if (this.NumberPlate2 != target.NumberPlate2) resList.Add("NumberPlate2");
            if (this.NumberPlate3 != target.NumberPlate3) resList.Add("NumberPlate3");
            if (this.NumberPlate4 != target.NumberPlate4) resList.Add("NumberPlate4");
            if (this.ModelDesignationNo != target.ModelDesignationNo) resList.Add("ModelDesignationNo");
            if (this.CategoryNo != target.CategoryNo) resList.Add("CategoryNo");
            if (this.MakerCode != target.MakerCode) resList.Add("MakerCode");
            if (this.ModelCode != target.ModelCode) resList.Add("ModelCode");
            if (this.ModelSubCode != target.ModelSubCode) resList.Add("ModelSubCode");
            if (this.ModelName != target.ModelName) resList.Add("ModelName");
            if (this.CarInspectCertModel != target.CarInspectCertModel) resList.Add("CarInspectCertModel");
            if (this.FullModel != target.FullModel) resList.Add("FullModel");
            if (this.FrameNo != target.FrameNo) resList.Add("FrameNo");
            if (this.FrameModel != target.FrameModel) resList.Add("FrameModel");
            if (this.ChassisNo != target.ChassisNo) resList.Add("ChassisNo");
            if (this.CarProperNo != target.CarProperNo) resList.Add("CarProperNo");
            if (this.ProduceTypeOfYearNum != target.ProduceTypeOfYearNum) resList.Add("ProduceTypeOfYearNum");
            if (this.Comment != target.Comment) resList.Add("Comment");
            if (this.RpColorCode != target.RpColorCode) resList.Add("RpColorCode");
            if (this.ColorName1 != target.ColorName1) resList.Add("ColorName1");
            if (this.TrimCode != target.TrimCode) resList.Add("TrimCode");
            if (this.TrimName != target.TrimName) resList.Add("TrimName");
            if (this.Mileage != target.Mileage) resList.Add("Mileage");
            if (this.EquipObj != target.EquipObj) resList.Add("EquipObj");
            if (this.CarNo != target.CarNo) resList.Add("CarNo");
            if (this.MakerName != target.MakerName) resList.Add("MakerName");
            if (this.GradeName != target.GradeName) resList.Add("GradeName");
            if (this.BodyName != target.BodyName) resList.Add("BodyName");
            if (this.DoorCount != target.DoorCount) resList.Add("DoorCount");
            if (this.EngineModelNm != target.EngineModelNm) resList.Add("EngineModelNm");
            if (this.CmnNmEngineDisPlace != target.CmnNmEngineDisPlace) resList.Add("CmnNmEngineDisPlace");
            if (this.EngineModel != target.EngineModel) resList.Add("EngineModel");
            if (this.NumberOfGear != target.NumberOfGear) resList.Add("NumberOfGear");
            if (this.GearNm != target.GearNm) resList.Add("GearNm");
            if (this.EDivNm != target.EDivNm) resList.Add("EDivNm");
            if (this.TransmissionNm != target.TransmissionNm) resList.Add("TransmissionNm");
            if (this.ShiftNm != target.ShiftNm) resList.Add("ShiftNm");

            return resList;
        }

        /// <summary>
        /// SCM受発注データ(車両情報)比較処理
        /// </summary>
        /// <param name="scmOdDtCar1">比較するScmOdDtCarクラスのインスタンス</param>
        /// <param name="scmOdDtCar2">比較するScmOdDtCarクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   ScmOdDtCarクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static ArrayList Compare(ScmOdDtCar scmOdDtCar1, ScmOdDtCar scmOdDtCar2)
        {
            ArrayList resList = new ArrayList();
            if (scmOdDtCar1.CreateDateTime != scmOdDtCar2.CreateDateTime) resList.Add("CreateDateTime");
            if (scmOdDtCar1.UpdateDateTime != scmOdDtCar2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (scmOdDtCar1.LogicalDeleteCode != scmOdDtCar2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (scmOdDtCar1.InqOriginalEpCd != scmOdDtCar2.InqOriginalEpCd) resList.Add("InqOriginalEpCd");
            if (scmOdDtCar1.InqOriginalSecCd != scmOdDtCar2.InqOriginalSecCd) resList.Add("InqOriginalSecCd");
            if (scmOdDtCar1.InquiryNumber != scmOdDtCar2.InquiryNumber) resList.Add("InquiryNumber");
            if (scmOdDtCar1.NumberPlate1Code != scmOdDtCar2.NumberPlate1Code) resList.Add("NumberPlate1Code");
            if (scmOdDtCar1.NumberPlate1Name != scmOdDtCar2.NumberPlate1Name) resList.Add("NumberPlate1Name");
            if (scmOdDtCar1.NumberPlate2 != scmOdDtCar2.NumberPlate2) resList.Add("NumberPlate2");
            if (scmOdDtCar1.NumberPlate3 != scmOdDtCar2.NumberPlate3) resList.Add("NumberPlate3");
            if (scmOdDtCar1.NumberPlate4 != scmOdDtCar2.NumberPlate4) resList.Add("NumberPlate4");
            if (scmOdDtCar1.ModelDesignationNo != scmOdDtCar2.ModelDesignationNo) resList.Add("ModelDesignationNo");
            if (scmOdDtCar1.CategoryNo != scmOdDtCar2.CategoryNo) resList.Add("CategoryNo");
            if (scmOdDtCar1.MakerCode != scmOdDtCar2.MakerCode) resList.Add("MakerCode");
            if (scmOdDtCar1.ModelCode != scmOdDtCar2.ModelCode) resList.Add("ModelCode");
            if (scmOdDtCar1.ModelSubCode != scmOdDtCar2.ModelSubCode) resList.Add("ModelSubCode");
            if (scmOdDtCar1.ModelName != scmOdDtCar2.ModelName) resList.Add("ModelName");
            if (scmOdDtCar1.CarInspectCertModel != scmOdDtCar2.CarInspectCertModel) resList.Add("CarInspectCertModel");
            if (scmOdDtCar1.FullModel != scmOdDtCar2.FullModel) resList.Add("FullModel");
            if (scmOdDtCar1.FrameNo != scmOdDtCar2.FrameNo) resList.Add("FrameNo");
            if (scmOdDtCar1.FrameModel != scmOdDtCar2.FrameModel) resList.Add("FrameModel");
            if (scmOdDtCar1.ChassisNo != scmOdDtCar2.ChassisNo) resList.Add("ChassisNo");
            if (scmOdDtCar1.CarProperNo != scmOdDtCar2.CarProperNo) resList.Add("CarProperNo");
            if (scmOdDtCar1.ProduceTypeOfYearNum != scmOdDtCar2.ProduceTypeOfYearNum) resList.Add("ProduceTypeOfYearNum");
            if (scmOdDtCar1.Comment != scmOdDtCar2.Comment) resList.Add("Comment");
            if (scmOdDtCar1.RpColorCode != scmOdDtCar2.RpColorCode) resList.Add("RpColorCode");
            if (scmOdDtCar1.ColorName1 != scmOdDtCar2.ColorName1) resList.Add("ColorName1");
            if (scmOdDtCar1.TrimCode != scmOdDtCar2.TrimCode) resList.Add("TrimCode");
            if (scmOdDtCar1.TrimName != scmOdDtCar2.TrimName) resList.Add("TrimName");
            if (scmOdDtCar1.Mileage != scmOdDtCar2.Mileage) resList.Add("Mileage");
            if (scmOdDtCar1.EquipObj != scmOdDtCar2.EquipObj) resList.Add("EquipObj");
            if (scmOdDtCar1.CarNo != scmOdDtCar2.CarNo) resList.Add("CarNo");
            if (scmOdDtCar1.MakerName != scmOdDtCar2.MakerName) resList.Add("MakerName");
            if (scmOdDtCar1.GradeName != scmOdDtCar2.GradeName) resList.Add("GradeName");
            if (scmOdDtCar1.BodyName != scmOdDtCar2.BodyName) resList.Add("BodyName");
            if (scmOdDtCar1.DoorCount != scmOdDtCar2.DoorCount) resList.Add("DoorCount");
            if (scmOdDtCar1.EngineModelNm != scmOdDtCar2.EngineModelNm) resList.Add("EngineModelNm");
            if (scmOdDtCar1.CmnNmEngineDisPlace != scmOdDtCar2.CmnNmEngineDisPlace) resList.Add("CmnNmEngineDisPlace");
            if (scmOdDtCar1.EngineModel != scmOdDtCar2.EngineModel) resList.Add("EngineModel");
            if (scmOdDtCar1.NumberOfGear != scmOdDtCar2.NumberOfGear) resList.Add("NumberOfGear");
            if (scmOdDtCar1.GearNm != scmOdDtCar2.GearNm) resList.Add("GearNm");
            if (scmOdDtCar1.EDivNm != scmOdDtCar2.EDivNm) resList.Add("EDivNm");
            if (scmOdDtCar1.TransmissionNm != scmOdDtCar2.TransmissionNm) resList.Add("TransmissionNm");
            if (scmOdDtCar1.ShiftNm != scmOdDtCar2.ShiftNm) resList.Add("ShiftNm");

            return resList;
        }
    }
}
