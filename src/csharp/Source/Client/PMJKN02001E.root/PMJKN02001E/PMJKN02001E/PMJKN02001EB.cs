//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 自由検索型式マスタ（印刷） データクラス
// プログラム概要   : 自由検索型式マスタ（印刷） データクラスヘッダファイル
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 王海立
// 作 成 日  2010/04/27  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   FreeSearchModelSet
    /// <summary>
    ///                      自由検索型式マスタ
    /// </summary>
    /// <remarks>
    /// <br>note             :   自由検索型式マスタヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2010/04/27  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class FreeSearchModelSet
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

        /// <summary>自由検索型式固定番号</summary>
        /// <remarks>自由検索シリアル№</remarks>
        private string _freeSrchMdlFxdNo = "";

        /// <summary>メーカーコード</summary>
        /// <remarks>1～899:提供分, 900～ユーザー登録</remarks>
        private Int32 _makerCode;

        /// <summary>車種コード</summary>
        /// <remarks>車名コード(翼) 1～899:提供分, 900～ユーザー登録</remarks>
        private Int32 _modelCode;

        /// <summary>車種サブコード</summary>
        /// <remarks>0～899:提供分,900～ﾕｰｻﾞｰ登録</remarks>
        private Int32 _modelSubCode;

        /// <summary>排ガス記号</summary>
        /// <remarks>※型式0</remarks>
        private string _exhaustGasSign = "";

        /// <summary>シリーズ型式</summary>
        /// <remarks>※型式1</remarks>
        private string _seriesModel = "";

        /// <summary>型式（類別記号）</summary>
        /// <remarks>※型式2</remarks>
        private string _categorySignModel = "";

        /// <summary>型式（フル型）</summary>
        /// <remarks>フル型式(44桁用)</remarks>
        private string _fullModel = "";

        /// <summary>型式指定番号</summary>
        private Int32 _modelDesignationNo;

        /// <summary>類別番号</summary>
        private Int32 _categoryNo;

        /// <summary>開始生産年式</summary>
        /// <remarks>YYYYMM</remarks>
        private Int32 _stProduceTypeOfYear;

        /// <summary>終了生産年式</summary>
        /// <remarks>YYYYMM</remarks>
        private Int32 _edProduceTypeOfYear;

        /// <summary>生産車台番号開始</summary>
        private Int32 _stProduceFrameNo;

        /// <summary>生産車台番号終了</summary>
        private Int32 _edProduceFrameNo;

        /// <summary>型式グレード名称</summary>
        private string _modelGradeNm = "";

        /// <summary>ボディー名称</summary>
        private string _bodyName = "";

        /// <summary>ドア数</summary>
        private Int32 _doorCount;

        /// <summary>エンジン型式名称</summary>
        private string _engineModelNm = "";

        /// <summary>排気量名称</summary>
        /// <remarks>型式により変動</remarks>
        private string _engineDisplaceNm = "";

        /// <summary>E区分名称</summary>
        /// <remarks>型式により変動</remarks>
        private string _eDivNm = "";

        /// <summary>ミッション名称</summary>
        private string _transmissionNm = "";

        /// <summary>駆動方式名称</summary>
        /// <remarks>新規追加</remarks>
        private string _wheelDriveMethodNm = "";

        /// <summary>シフト名称</summary>
        private string _shiftNm = "";

        /// <summary>作成日付</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _createDate;

        /// <summary>更新年月日</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _updateDate;

        /// <summary>車種全角名称</summary>
        /// <remarks>正式名称（カナ漢字混在で全角管理）</remarks>
        private string _modelFullName = "";


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

        /// public propaty name  :  FreeSrchMdlFxdNo
        /// <summary>自由検索型式固定番号プロパティ</summary>
        /// <value>自由検索シリアル№</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自由検索型式固定番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string FreeSrchMdlFxdNo
        {
            get { return _freeSrchMdlFxdNo; }
            set { _freeSrchMdlFxdNo = value; }
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

        /// public propaty name  :  ExhaustGasSign
        /// <summary>排ガス記号プロパティ</summary>
        /// <value>※型式0</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   排ガス記号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ExhaustGasSign
        {
            get { return _exhaustGasSign; }
            set { _exhaustGasSign = value; }
        }

        /// public propaty name  :  SeriesModel
        /// <summary>シリーズ型式プロパティ</summary>
        /// <value>※型式1</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   シリーズ型式プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SeriesModel
        {
            get { return _seriesModel; }
            set { _seriesModel = value; }
        }

        /// public propaty name  :  CategorySignModel
        /// <summary>型式（類別記号）プロパティ</summary>
        /// <value>※型式2</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   型式（類別記号）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CategorySignModel
        {
            get { return _categorySignModel; }
            set { _categorySignModel = value; }
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

        /// public propaty name  :  StProduceTypeOfYear
        /// <summary>開始生産年式プロパティ</summary>
        /// <value>YYYYMM</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始生産年式プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 StProduceTypeOfYear
        {
            get { return _stProduceTypeOfYear; }
            set { _stProduceTypeOfYear = value; }
        }

        /// public propaty name  :  EdProduceTypeOfYear
        /// <summary>終了生産年式プロパティ</summary>
        /// <value>YYYYMM</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了生産年式プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 EdProduceTypeOfYear
        {
            get { return _edProduceTypeOfYear; }
            set { _edProduceTypeOfYear = value; }
        }

        /// public propaty name  :  StProduceFrameNo
        /// <summary>生産車台番号開始プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   生産車台番号開始プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 StProduceFrameNo
        {
            get { return _stProduceFrameNo; }
            set { _stProduceFrameNo = value; }
        }

        /// public propaty name  :  EdProduceFrameNo
        /// <summary>生産車台番号終了プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   生産車台番号終了プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 EdProduceFrameNo
        {
            get { return _edProduceFrameNo; }
            set { _edProduceFrameNo = value; }
        }

        /// public propaty name  :  ModelGradeNm
        /// <summary>型式グレード名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   型式グレード名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ModelGradeNm
        {
            get { return _modelGradeNm; }
            set { _modelGradeNm = value; }
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

        /// public propaty name  :  EngineDisplaceNm
        /// <summary>排気量名称プロパティ</summary>
        /// <value>型式により変動</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   排気量名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EngineDisplaceNm
        {
            get { return _engineDisplaceNm; }
            set { _engineDisplaceNm = value; }
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

        /// public propaty name  :  WheelDriveMethodNm
        /// <summary>駆動方式名称プロパティ</summary>
        /// <value>新規追加</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   駆動方式名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string WheelDriveMethodNm
        {
            get { return _wheelDriveMethodNm; }
            set { _wheelDriveMethodNm = value; }
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

        /// public propaty name  :  CreateDate
        /// <summary>作成日付プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   作成日付プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CreateDate
        {
            get { return _createDate; }
            set { _createDate = value; }
        }

        /// public propaty name  :  UpdateDate
        /// <summary>更新年月日プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新年月日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 UpdateDate
        {
            get { return _updateDate; }
            set { _updateDate = value; }
        }

        /// public propaty name  :  ModelFullName
        /// <summary>車種全角名称プロパティ</summary>
        /// <value>正式名称（カナ漢字混在で全角管理）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車種全角名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ModelFullName
        {
            get { return _modelFullName; }
            set { _modelFullName = value; }
        }


        /// <summary>
        /// 自由検索型式マスタコンストラクタ
        /// </summary>
        /// <returns>FreeSearchModelSetクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   FreeSearchModelSetクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public FreeSearchModelSet()
        {
        }

        /// <summary>
        /// 自由検索型式マスタコンストラクタ
        /// </summary>
        /// <param name="createDateTime">作成日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="updateDateTime">更新日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
        /// <param name="fileHeaderGuid">GUID(共通ファイルヘッダ)</param>
        /// <param name="updEmployeeCode">更新従業員コード(共通ファイルヘッダ)</param>
        /// <param name="updAssemblyId1">更新アセンブリID1(共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）)</param>
        /// <param name="updAssemblyId2">更新アセンブリID2(共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）)</param>
        /// <param name="logicalDeleteCode">論理削除区分(共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除))</param>
        /// <param name="freeSrchMdlFxdNo">自由検索型式固定番号(自由検索シリアル№)</param>
        /// <param name="makerCode">メーカーコード(1～899:提供分, 900～ユーザー登録)</param>
        /// <param name="modelCode">車種コード(車名コード(翼) 1～899:提供分, 900～ユーザー登録)</param>
        /// <param name="modelSubCode">車種サブコード(0～899:提供分,900～ﾕｰｻﾞｰ登録)</param>
        /// <param name="exhaustGasSign">排ガス記号(※型式0)</param>
        /// <param name="seriesModel">シリーズ型式(※型式1)</param>
        /// <param name="categorySignModel">型式（類別記号）(※型式2)</param>
        /// <param name="fullModel">型式（フル型）(フル型式(44桁用))</param>
        /// <param name="modelDesignationNo">型式指定番号</param>
        /// <param name="categoryNo">類別番号</param>
        /// <param name="stProduceTypeOfYear">開始生産年式(YYYYMM)</param>
        /// <param name="edProduceTypeOfYear">終了生産年式(YYYYMM)</param>
        /// <param name="stProduceFrameNo">生産車台番号開始</param>
        /// <param name="edProduceFrameNo">生産車台番号終了</param>
        /// <param name="modelGradeNm">型式グレード名称</param>
        /// <param name="bodyName">ボディー名称</param>
        /// <param name="doorCount">ドア数</param>
        /// <param name="engineModelNm">エンジン型式名称</param>
        /// <param name="engineDisplaceNm">排気量名称(型式により変動)</param>
        /// <param name="eDivNm">E区分名称(型式により変動)</param>
        /// <param name="transmissionNm">ミッション名称</param>
        /// <param name="wheelDriveMethodNm">駆動方式名称(新規追加)</param>
        /// <param name="shiftNm">シフト名称</param>
        /// <param name="createDate">作成日付(YYYYMMDD)</param>
        /// <param name="updateDate">更新年月日(YYYYMMDD)</param>
        /// <param name="modelFullName">車種全角名称(正式名称（カナ漢字混在で全角管理）)</param>
        /// <returns>FreeSearchModelSetクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   FreeSearchModelSetクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public FreeSearchModelSet(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, string freeSrchMdlFxdNo, Int32 makerCode, Int32 modelCode, Int32 modelSubCode, string exhaustGasSign, string seriesModel, string categorySignModel, string fullModel, Int32 modelDesignationNo, Int32 categoryNo, Int32 stProduceTypeOfYear, Int32 edProduceTypeOfYear, Int32 stProduceFrameNo, Int32 edProduceFrameNo, string modelGradeNm, string bodyName, Int32 doorCount, string engineModelNm, string engineDisplaceNm, string eDivNm, string transmissionNm, string wheelDriveMethodNm, string shiftNm, Int32 createDate, Int32 updateDate, string modelFullName)
        {
            this.CreateDateTime = createDateTime;
            this.UpdateDateTime = updateDateTime;
            this._enterpriseCode = enterpriseCode;
            this._fileHeaderGuid = fileHeaderGuid;
            this._updEmployeeCode = updEmployeeCode;
            this._updAssemblyId1 = updAssemblyId1;
            this._updAssemblyId2 = updAssemblyId2;
            this._logicalDeleteCode = logicalDeleteCode;
            this._freeSrchMdlFxdNo = freeSrchMdlFxdNo;
            this._makerCode = makerCode;
            this._modelCode = modelCode;
            this._modelSubCode = modelSubCode;
            this._exhaustGasSign = exhaustGasSign;
            this._seriesModel = seriesModel;
            this._categorySignModel = categorySignModel;
            this._fullModel = fullModel;
            this._modelDesignationNo = modelDesignationNo;
            this._categoryNo = categoryNo;
            this._stProduceTypeOfYear = stProduceTypeOfYear;
            this._edProduceTypeOfYear = edProduceTypeOfYear;
            this._stProduceFrameNo = stProduceFrameNo;
            this._edProduceFrameNo = edProduceFrameNo;
            this._modelGradeNm = modelGradeNm;
            this._bodyName = bodyName;
            this._doorCount = doorCount;
            this._engineModelNm = engineModelNm;
            this._engineDisplaceNm = engineDisplaceNm;
            this._eDivNm = eDivNm;
            this._transmissionNm = transmissionNm;
            this._wheelDriveMethodNm = wheelDriveMethodNm;
            this._shiftNm = shiftNm;
            this._createDate = createDate;
            this._updateDate = updateDate;
            this._modelFullName = modelFullName;

        }

        /// <summary>
        /// 自由検索型式マスタ複製処理
        /// </summary>
        /// <returns>FreeSearchModelSetクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいFreeSearchModelSetクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public FreeSearchModelSet Clone()
        {
            return new FreeSearchModelSet(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._freeSrchMdlFxdNo, this._makerCode, this._modelCode, this._modelSubCode, this._exhaustGasSign, this._seriesModel, this._categorySignModel, this._fullModel, this._modelDesignationNo, this._categoryNo, this._stProduceTypeOfYear, this._edProduceTypeOfYear, this._stProduceFrameNo, this._edProduceFrameNo, this._modelGradeNm, this._bodyName, this._doorCount, this._engineModelNm, this._engineDisplaceNm, this._eDivNm, this._transmissionNm, this._wheelDriveMethodNm, this._shiftNm, this._createDate, this._updateDate, this._modelFullName);
        }

        /// <summary>
        /// 自由検索型式マスタ比較処理
        /// </summary>
        /// <param name="target">比較対象のFreeSearchModelSetクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   FreeSearchModelSetクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool Equals(FreeSearchModelSet target)
        {
            return ((this.CreateDateTime == target.CreateDateTime)
                 && (this.UpdateDateTime == target.UpdateDateTime)
                 && (this.EnterpriseCode == target.EnterpriseCode)
                 && (this.FileHeaderGuid == target.FileHeaderGuid)
                 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
                 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
                 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
                 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
                 && (this.FreeSrchMdlFxdNo == target.FreeSrchMdlFxdNo)
                 && (this.MakerCode == target.MakerCode)
                 && (this.ModelCode == target.ModelCode)
                 && (this.ModelSubCode == target.ModelSubCode)
                 && (this.ExhaustGasSign == target.ExhaustGasSign)
                 && (this.SeriesModel == target.SeriesModel)
                 && (this.CategorySignModel == target.CategorySignModel)
                 && (this.FullModel == target.FullModel)
                 && (this.ModelDesignationNo == target.ModelDesignationNo)
                 && (this.CategoryNo == target.CategoryNo)
                 && (this.StProduceTypeOfYear == target.StProduceTypeOfYear)
                 && (this.EdProduceTypeOfYear == target.EdProduceTypeOfYear)
                 && (this.StProduceFrameNo == target.StProduceFrameNo)
                 && (this.EdProduceFrameNo == target.EdProduceFrameNo)
                 && (this.ModelGradeNm == target.ModelGradeNm)
                 && (this.BodyName == target.BodyName)
                 && (this.DoorCount == target.DoorCount)
                 && (this.EngineModelNm == target.EngineModelNm)
                 && (this.EngineDisplaceNm == target.EngineDisplaceNm)
                 && (this.EDivNm == target.EDivNm)
                 && (this.TransmissionNm == target.TransmissionNm)
                 && (this.WheelDriveMethodNm == target.WheelDriveMethodNm)
                 && (this.ShiftNm == target.ShiftNm)
                 && (this.CreateDate == target.CreateDate)
                 && (this.UpdateDate == target.UpdateDate)
                 && (this.ModelFullName == target.ModelFullName));
        }

        /// <summary>
        /// 自由検索型式マスタ比較処理
        /// </summary>
        /// <param name="freeSearchModel1">
        ///                    比較するFreeSearchModelSetクラスのインスタンス
        /// </param>
        /// <param name="freeSearchModel2">比較するFreeSearchModelSetクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   FreeSearchModelSetクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static bool Equals(FreeSearchModelSet freeSearchModel1, FreeSearchModelSet freeSearchModel2)
        {
            return ((freeSearchModel1.CreateDateTime == freeSearchModel2.CreateDateTime)
                 && (freeSearchModel1.UpdateDateTime == freeSearchModel2.UpdateDateTime)
                 && (freeSearchModel1.EnterpriseCode == freeSearchModel2.EnterpriseCode)
                 && (freeSearchModel1.FileHeaderGuid == freeSearchModel2.FileHeaderGuid)
                 && (freeSearchModel1.UpdEmployeeCode == freeSearchModel2.UpdEmployeeCode)
                 && (freeSearchModel1.UpdAssemblyId1 == freeSearchModel2.UpdAssemblyId1)
                 && (freeSearchModel1.UpdAssemblyId2 == freeSearchModel2.UpdAssemblyId2)
                 && (freeSearchModel1.LogicalDeleteCode == freeSearchModel2.LogicalDeleteCode)
                 && (freeSearchModel1.FreeSrchMdlFxdNo == freeSearchModel2.FreeSrchMdlFxdNo)
                 && (freeSearchModel1.MakerCode == freeSearchModel2.MakerCode)
                 && (freeSearchModel1.ModelCode == freeSearchModel2.ModelCode)
                 && (freeSearchModel1.ModelSubCode == freeSearchModel2.ModelSubCode)
                 && (freeSearchModel1.ExhaustGasSign == freeSearchModel2.ExhaustGasSign)
                 && (freeSearchModel1.SeriesModel == freeSearchModel2.SeriesModel)
                 && (freeSearchModel1.CategorySignModel == freeSearchModel2.CategorySignModel)
                 && (freeSearchModel1.FullModel == freeSearchModel2.FullModel)
                 && (freeSearchModel1.ModelDesignationNo == freeSearchModel2.ModelDesignationNo)
                 && (freeSearchModel1.CategoryNo == freeSearchModel2.CategoryNo)
                 && (freeSearchModel1.StProduceTypeOfYear == freeSearchModel2.StProduceTypeOfYear)
                 && (freeSearchModel1.EdProduceTypeOfYear == freeSearchModel2.EdProduceTypeOfYear)
                 && (freeSearchModel1.StProduceFrameNo == freeSearchModel2.StProduceFrameNo)
                 && (freeSearchModel1.EdProduceFrameNo == freeSearchModel2.EdProduceFrameNo)
                 && (freeSearchModel1.ModelGradeNm == freeSearchModel2.ModelGradeNm)
                 && (freeSearchModel1.BodyName == freeSearchModel2.BodyName)
                 && (freeSearchModel1.DoorCount == freeSearchModel2.DoorCount)
                 && (freeSearchModel1.EngineModelNm == freeSearchModel2.EngineModelNm)
                 && (freeSearchModel1.EngineDisplaceNm == freeSearchModel2.EngineDisplaceNm)
                 && (freeSearchModel1.EDivNm == freeSearchModel2.EDivNm)
                 && (freeSearchModel1.TransmissionNm == freeSearchModel2.TransmissionNm)
                 && (freeSearchModel1.WheelDriveMethodNm == freeSearchModel2.WheelDriveMethodNm)
                 && (freeSearchModel1.ShiftNm == freeSearchModel2.ShiftNm)
                 && (freeSearchModel1.CreateDate == freeSearchModel2.CreateDate)
                 && (freeSearchModel1.UpdateDate == freeSearchModel2.UpdateDate)
                 && (freeSearchModel1.ModelFullName == freeSearchModel2.ModelFullName));
        }
        /// <summary>
        /// 自由検索型式マスタ比較処理
        /// </summary>
        /// <param name="target">比較対象のFreeSearchModelSetクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   FreeSearchModelSetクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList Compare(FreeSearchModelSet target)
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
            if (this.FreeSrchMdlFxdNo != target.FreeSrchMdlFxdNo) resList.Add("FreeSrchMdlFxdNo");
            if (this.MakerCode != target.MakerCode) resList.Add("MakerCode");
            if (this.ModelCode != target.ModelCode) resList.Add("ModelCode");
            if (this.ModelSubCode != target.ModelSubCode) resList.Add("ModelSubCode");
            if (this.ExhaustGasSign != target.ExhaustGasSign) resList.Add("ExhaustGasSign");
            if (this.SeriesModel != target.SeriesModel) resList.Add("SeriesModel");
            if (this.CategorySignModel != target.CategorySignModel) resList.Add("CategorySignModel");
            if (this.FullModel != target.FullModel) resList.Add("FullModel");
            if (this.ModelDesignationNo != target.ModelDesignationNo) resList.Add("ModelDesignationNo");
            if (this.CategoryNo != target.CategoryNo) resList.Add("CategoryNo");
            if (this.StProduceTypeOfYear != target.StProduceTypeOfYear) resList.Add("StProduceTypeOfYear");
            if (this.EdProduceTypeOfYear != target.EdProduceTypeOfYear) resList.Add("EdProduceTypeOfYear");
            if (this.StProduceFrameNo != target.StProduceFrameNo) resList.Add("StProduceFrameNo");
            if (this.EdProduceFrameNo != target.EdProduceFrameNo) resList.Add("EdProduceFrameNo");
            if (this.ModelGradeNm != target.ModelGradeNm) resList.Add("ModelGradeNm");
            if (this.BodyName != target.BodyName) resList.Add("BodyName");
            if (this.DoorCount != target.DoorCount) resList.Add("DoorCount");
            if (this.EngineModelNm != target.EngineModelNm) resList.Add("EngineModelNm");
            if (this.EngineDisplaceNm != target.EngineDisplaceNm) resList.Add("EngineDisplaceNm");
            if (this.EDivNm != target.EDivNm) resList.Add("EDivNm");
            if (this.TransmissionNm != target.TransmissionNm) resList.Add("TransmissionNm");
            if (this.WheelDriveMethodNm != target.WheelDriveMethodNm) resList.Add("WheelDriveMethodNm");
            if (this.ShiftNm != target.ShiftNm) resList.Add("ShiftNm");
            if (this.CreateDate != target.CreateDate) resList.Add("CreateDate");
            if (this.UpdateDate != target.UpdateDate) resList.Add("UpdateDate");
            if (this.ModelFullName != target.ModelFullName) resList.Add("ModelFullName");

            return resList;
        }

        /// <summary>
        /// 自由検索型式マスタ比較処理
        /// </summary>
        /// <param name="freeSearchModel1">比較するFreeSearchModelSetクラスのインスタンス</param>
        /// <param name="freeSearchModel2">比較するFreeSearchModelSetクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   FreeSearchModelSetクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static ArrayList Compare(FreeSearchModelSet freeSearchModel1, FreeSearchModelSet freeSearchModel2)
        {
            ArrayList resList = new ArrayList();
            if (freeSearchModel1.CreateDateTime != freeSearchModel2.CreateDateTime) resList.Add("CreateDateTime");
            if (freeSearchModel1.UpdateDateTime != freeSearchModel2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (freeSearchModel1.EnterpriseCode != freeSearchModel2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (freeSearchModel1.FileHeaderGuid != freeSearchModel2.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (freeSearchModel1.UpdEmployeeCode != freeSearchModel2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (freeSearchModel1.UpdAssemblyId1 != freeSearchModel2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (freeSearchModel1.UpdAssemblyId2 != freeSearchModel2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (freeSearchModel1.LogicalDeleteCode != freeSearchModel2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (freeSearchModel1.FreeSrchMdlFxdNo != freeSearchModel2.FreeSrchMdlFxdNo) resList.Add("FreeSrchMdlFxdNo");
            if (freeSearchModel1.MakerCode != freeSearchModel2.MakerCode) resList.Add("MakerCode");
            if (freeSearchModel1.ModelCode != freeSearchModel2.ModelCode) resList.Add("ModelCode");
            if (freeSearchModel1.ModelSubCode != freeSearchModel2.ModelSubCode) resList.Add("ModelSubCode");
            if (freeSearchModel1.ExhaustGasSign != freeSearchModel2.ExhaustGasSign) resList.Add("ExhaustGasSign");
            if (freeSearchModel1.SeriesModel != freeSearchModel2.SeriesModel) resList.Add("SeriesModel");
            if (freeSearchModel1.CategorySignModel != freeSearchModel2.CategorySignModel) resList.Add("CategorySignModel");
            if (freeSearchModel1.FullModel != freeSearchModel2.FullModel) resList.Add("FullModel");
            if (freeSearchModel1.ModelDesignationNo != freeSearchModel2.ModelDesignationNo) resList.Add("ModelDesignationNo");
            if (freeSearchModel1.CategoryNo != freeSearchModel2.CategoryNo) resList.Add("CategoryNo");
            if (freeSearchModel1.StProduceTypeOfYear != freeSearchModel2.StProduceTypeOfYear) resList.Add("StProduceTypeOfYear");
            if (freeSearchModel1.EdProduceTypeOfYear != freeSearchModel2.EdProduceTypeOfYear) resList.Add("EdProduceTypeOfYear");
            if (freeSearchModel1.StProduceFrameNo != freeSearchModel2.StProduceFrameNo) resList.Add("StProduceFrameNo");
            if (freeSearchModel1.EdProduceFrameNo != freeSearchModel2.EdProduceFrameNo) resList.Add("EdProduceFrameNo");
            if (freeSearchModel1.ModelGradeNm != freeSearchModel2.ModelGradeNm) resList.Add("ModelGradeNm");
            if (freeSearchModel1.BodyName != freeSearchModel2.BodyName) resList.Add("BodyName");
            if (freeSearchModel1.DoorCount != freeSearchModel2.DoorCount) resList.Add("DoorCount");
            if (freeSearchModel1.EngineModelNm != freeSearchModel2.EngineModelNm) resList.Add("EngineModelNm");
            if (freeSearchModel1.EngineDisplaceNm != freeSearchModel2.EngineDisplaceNm) resList.Add("EngineDisplaceNm");
            if (freeSearchModel1.EDivNm != freeSearchModel2.EDivNm) resList.Add("EDivNm");
            if (freeSearchModel1.TransmissionNm != freeSearchModel2.TransmissionNm) resList.Add("TransmissionNm");
            if (freeSearchModel1.WheelDriveMethodNm != freeSearchModel2.WheelDriveMethodNm) resList.Add("WheelDriveMethodNm");
            if (freeSearchModel1.ShiftNm != freeSearchModel2.ShiftNm) resList.Add("ShiftNm");
            if (freeSearchModel1.CreateDate != freeSearchModel2.CreateDate) resList.Add("CreateDate");
            if (freeSearchModel1.UpdateDate != freeSearchModel2.UpdateDate) resList.Add("UpdateDate");
            if (freeSearchModel1.ModelFullName != freeSearchModel2.ModelFullName) resList.Add("ModelFullName");

            return resList;
        }
    }
}