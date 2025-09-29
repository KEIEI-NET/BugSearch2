//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 車両管理オブジェクト情報クラス
// プログラム概要   : 車輌管理マスタの登録・変更・削除を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 劉学智
// 作 成 日  2009/09/07  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// Update Note      :   2013/03/22 FSI高橋 文彰
// 管理番号         :   10900269-00 
//                      SPK車台番号文字列対応に伴う国産/外車区分の追加
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Application.UIData
{
    /// public class name:   CarMangInputExtraInfo
    /// <summary>
    ///                      車両管理オブジェクト
    /// </summary>
    /// <remarks>
    /// <br>note             :   車両管理ワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/09/19  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   8/12  久保田</br>
    /// <br>                 :   装備オブジェクト配列 を追加</br>
    /// <br>                 :   原動機型式（エンジン） を追加</br>
    /// <br>Update Note      :   2010/04/27  gaoyh</br>
    /// <br>                 :   自由検索型式固定番号配列を追加</br>
    /// </remarks>
    public class CarMangInputExtraInfo
    {
        /// <summary>作成日時</summary>
        /// <remarks>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</remarks>
        private DateTime _createDateTime;

        /// <summary>GUID</summary>
        /// <remarks>共通ファイルヘッダ</remarks>
        private Guid _fileHeaderGuid;

        /// <summary>更新日時</summary>
        /// <remarks>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</remarks>
        private DateTime _updateDateTime;

        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>論理削除区分</summary>
        /// <remarks>共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除)</remarks>
        private Int32 _logicalDeleteCode;

        /// <summary>得意先コード</summary>
        private Int32 _customerCode;

        /// <summary>得意先コード</summary>
        private string _customerCodeForGuide;

        /// <summary>得意先名称</summary>
        private string _customerName = "";

        /// <summary>車両管理番号</summary>
        /// <remarks>自動採番（無重複のシーケンス）PM7での車両SEQ</remarks>
        private Int32 _carMngNo;

        /// <summary>車輌管理コード</summary>
        /// <remarks>※PM7での車両管理番号</remarks>
        private string _carMngCode = "";

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

        /// <summary>車両登録番号（ガイド用）</summary>
        private string _numberPlateForGuide = "";

        /// <summary>登録年月日</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _entryDate;

        /// <summary>初年度</summary>
        /// <remarks>YYYYMM</remarks>
        //private DateTime _firstEntryDate;
        private Int32 _firstEntryDate;  // ADD 2009/10/10

        /// <summary>メーカーコード</summary>
        /// <remarks>1～899:提供分, 900～ユーザー登録</remarks>
        private Int32 _makerCode;

        /// <summary>メーカー全角名称</summary>
        /// <remarks>正式名称（カナ漢字混在で全角管理）</remarks>
        private string _makerFullName = "";

        /// <summary>メーカー半角名称</summary>
        /// <remarks>正式名称（半角で管理）</remarks>
        private string _makerHalfName = "";

        /// <summary>車種コード</summary>
        /// <remarks>車名コード(翼) 1～899:提供分, 900～ユーザー登録</remarks>
        private Int32 _modelCode;

        /// <summary>車種サブコード</summary>
        /// <remarks>0～899:提供分,900～ﾕｰｻﾞｰ登録</remarks>
        private Int32 _modelSubCode;

        /// <summary>車種全角名称</summary>
        /// <remarks>正式名称（カナ漢字混在で全角管理）</remarks>
        private string _modelFullName = "";

        /// <summary>車種半角名称</summary>
        /// <remarks>正式名称（半角で管理）</remarks>
        private string _modelHalfName = "";

        /// <summary>系統コード</summary>
        private Int32 _systematicCode;

        /// <summary>系統名称</summary>
        /// <remarks>140系,180系等</remarks>
        private string _systematicName = "";

        /// <summary>生産年式コード</summary>
        private Int32 _produceTypeOfYearCd;

        /// <summary>生産年式名称</summary>
        private string _produceTypeOfYearNm = "";

        /// <summary>開始生産年式</summary>
        /// <remarks>YYYYMM</remarks>
        private DateTime _stProduceTypeOfYear;

        /// <summary>終了生産年式</summary>
        /// <remarks>YYYYMM</remarks>
        private DateTime _edProduceTypeOfYear;

        /// <summary>ドア数</summary>
        private Int32 _doorCount;

        /// <summary>ボディー名コード</summary>
        private Int32 _bodyNameCode;

        /// <summary>ボディー名称</summary>
        private string _bodyName = "";

        /// <summary>排ガス記号</summary>
        private string _exhaustGasSign = "";

        /// <summary>シリーズ型式</summary>
        private string _seriesModel = "";

        /// <summary>型式（類別記号）</summary>
        private string _categorySignModel = "";

        /// <summary>型式（フル型）</summary>
        /// <remarks>フル型式(44桁用)</remarks>
        private string _fullModel = "";

        /// <summary>型式指定番号</summary>
        private Int32 _modelDesignationNo;

        /// <summary>類別番号</summary>
        private Int32 _categoryNo;

        /// <summary>車台型式</summary>
        private string _frameModel = "";

        /// <summary>車台番号</summary>
        /// <remarks>車検証記載フォーマット対応（ HCR32-100251584 等）</remarks>
        private string _frameNo = "";

        /// <summary>車台番号（検索用）</summary>
        /// <remarks>PM7の車台番号と同意</remarks>
        private Int32 _searchFrameNo;

        /// <summary>生産車台番号開始</summary>
        private Int32 _stProduceFrameNo;

        /// <summary>生産車台番号終了</summary>
        private Int32 _edProduceFrameNo;

        /// <summary>原動機型式（エンジン）</summary>
        /// <remarks>車検証記載原動機型式</remarks>
        private string _engineModel = "";

        /// <summary>型式グレード名称</summary>
        private string _modelGradeNm = "";

        /// <summary>エンジン型式名称</summary>
        /// <remarks>型式により変動</remarks>
        private string _engineModelNm = "";

        /// <summary>排気量名称</summary>
        /// <remarks>型式により変動</remarks>
        private string _engineDisplaceNm = "";

        /// <summary>E区分名称</summary>
        /// <remarks>型式により変動</remarks>
        private string _eDivNm = "";

        /// <summary>ミッション名称</summary>
        private string _transmissionNm = "";

        /// <summary>シフト名称</summary>
        private string _shiftNm = "";

        /// <summary>駆動方式名称</summary>
        /// <remarks>新規追加</remarks>
        private string _wheelDriveMethodNm = "";

        /// <summary>追加諸元1</summary>
        /// <remarks>型式により変動</remarks>
        private string _addiCarSpec1 = "";

        /// <summary>追加諸元2</summary>
        /// <remarks>型式により変動</remarks>
        private string _addiCarSpec2 = "";

        /// <summary>追加諸元3</summary>
        /// <remarks>型式により変動</remarks>
        private string _addiCarSpec3 = "";

        /// <summary>追加諸元4</summary>
        /// <remarks>型式により変動</remarks>
        private string _addiCarSpec4 = "";

        /// <summary>追加諸元5</summary>
        /// <remarks>型式により変動</remarks>
        private string _addiCarSpec5 = "";

        /// <summary>追加諸元6</summary>
        /// <remarks>型式により変動</remarks>
        private string _addiCarSpec6 = "";

        /// <summary>追加諸元タイトル1</summary>
        /// <remarks>型式により変動</remarks>
        private string _addiCarSpecTitle1 = "";

        /// <summary>追加諸元タイトル2</summary>
        /// <remarks>型式により変動</remarks>
        private string _addiCarSpecTitle2 = "";

        /// <summary>追加諸元タイトル3</summary>
        /// <remarks>型式により変動</remarks>
        private string _addiCarSpecTitle3 = "";

        /// <summary>追加諸元タイトル4</summary>
        /// <remarks>型式により変動</remarks>
        private string _addiCarSpecTitle4 = "";

        /// <summary>追加諸元タイトル5</summary>
        /// <remarks>型式により変動</remarks>
        private string _addiCarSpecTitle5 = "";

        /// <summary>追加諸元タイトル6</summary>
        /// <remarks>型式により変動</remarks>
        private string _addiCarSpecTitle6 = "";

        /// <summary>関連型式</summary>
        /// <remarks>リサイクル系で使用</remarks>
        private string _relevanceModel = "";

        /// <summary>サブ車名コード</summary>
        /// <remarks>リサイクル系で使用</remarks>
        private Int32 _subCarNmCd;

        /// <summary>型式グレード略称</summary>
        /// <remarks>リサイクル系で使用</remarks>
        private string _modelGradeSname = "";

        /// <summary>ブロックイラストコード</summary>
        /// <remarks>鈑金のブロック選択に使用</remarks>
        private Int32 _blockIllustrationCd;

        /// <summary>3DイラストNo</summary>
        /// <remarks>鈑金の3Dイラスト選択に使用</remarks>
        private Int32 _threeDIllustNo;

        /// <summary>部品データ提供フラグ</summary>
        /// <remarks>0:提供なし,1:提供あり</remarks>
        private Int32 _partsDataOfferFlag;

        /// <summary>車検満期日</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _inspectMaturityDate;

        /// <summary>前回車検満期日</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _lTimeCiMatDate;

        /// <summary>車検期間</summary>
        /// <remarks>1:1年,2:2年,3:3年</remarks>
        private Int32 _carInspectYear;

        /// <summary>車両走行距離</summary>
        private Int32 _mileage;

        /// <summary>号車</summary>
        private string _carNo = "";

        /// <summary>カラーコード</summary>
        /// <remarks>カタログの色コード</remarks>
        private string _colorCode = "";

        /// <summary>カラー名称1</summary>
        /// <remarks>画面表示用正式名称</remarks>
        private string _colorName1 = "";

        /// <summary>トリムコード</summary>
        private string _trimCode = "";

        /// <summary>トリム名称</summary>
        private string _trimName = "";

        /// <summary>フル型式固定番号配列</summary>
        /// <remarks>フル型式固定連番の配列クラスを格納（再検索不要になる）</remarks>
        private Int32[] _fullModelFixedNoAry = new Int32[0];

        /// <summary>装備オブジェクト配列</summary>
        private Byte[] _categoryObjAry = new Byte[0];

        /// <summary>車輌追加情報１</summary>
        private string _carAddInfo1 = "";

        /// <summary>車輌追加情報２</summary>
        private string _carAddInfo2 = "";

        /// <summary>車輌備考</summary>
        private string _carNote = "";

        /// <summary>自由検索型式固定番号配列</summary>
        /// <remarks>自由検索シリアル№の配列クラスを格納（再検索不要になる）</remarks>
        private string[] _freeSrchMdlFxdNoAry = new string[0];

        /// <summary>年式</summary>
        private Int32 _produceTypeOfYearInput;

        /// <summary>車両関連付けGUID</summary>
        /// <remarks>車両管理情報と伝票明細を紐付けるGUID、UI側で設定</remarks>
        private Guid _carRelationGuid;

        // ADD 2013/03/19 -------------------->>>>>
        /// <summary>国産/外車区分コード</summary>
        private Int32 _domesticForeignCode;

        /// <summary>ハンドル位置情報コード</summary>
        private Int32 _handleInfoCode;
        // ADD 2013/03/19 --------------------<<<<<

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

        /// public propaty name  :  CustomerCode
        /// <summary>得意先コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CustomerCode
        {
            get { return _customerCode; }
            set { _customerCode = value; }
        }

        /// public propaty name  :  CustomerCodeForGuide
        /// <summary>得意先コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CustomerCodeForGuide
        {
            get { return _customerCodeForGuide; }
            set { _customerCodeForGuide = value; }
        }

        /// public propaty name  :  CustomerName
        /// <summary>得意先名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CustomerName
        {
            get { return _customerName; }
            set { _customerName = value; }
        }

        /// public propaty name  :  CarMngNo
        /// <summary>車両管理番号プロパティ</summary>
        /// <value>自動採番（無重複のシーケンス）PM7での車両SEQ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車両管理番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CarMngNo
        {
            get { return _carMngNo; }
            set { _carMngNo = value; }
        }

        /// public propaty name  :  CarMngCode
        /// <summary>車輌管理コードプロパティ</summary>
        /// <value>※PM7での車両管理番号</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車輌管理コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CarMngCode
        {
            get { return _carMngCode; }
            set { _carMngCode = value; }
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

        /// public propaty name  :  NumberPlateForGuide
        /// <summary>車両登録番号（ガイド用）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車両登録番号（ガイド用）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string NumberPlateForGuide
        {
            get { return _numberPlateForGuide; }
            set { _numberPlateForGuide = value; }
        }

        /// public propaty name  :  EntryDate
        /// <summary>登録年月日プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   登録年月日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime EntryDate
        {
            get { return _entryDate; }
            set { _entryDate = value; }
        }

        /// public propaty name  :  FirstEntryDate
        /// <summary>初年度プロパティ</summary>
        /// <value>YYYYMM</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   初年度プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        // public DateTime FirstEntryDate
        public Int32 FirstEntryDate   // ADD 2009/10/10
        {
            get { return _firstEntryDate; }
            set { _firstEntryDate = value; }
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

        /// public propaty name  :  MakerFullName
        /// <summary>メーカー全角名称プロパティ</summary>
        /// <value>正式名称（カナ漢字混在で全角管理）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メーカー全角名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MakerFullName
        {
            get { return _makerFullName; }
            set { _makerFullName = value; }
        }

        /// public propaty name  :  MakerHalfName
        /// <summary>メーカー半角名称プロパティ</summary>
        /// <value>正式名称（半角で管理）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メーカー半角名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MakerHalfName
        {
            get { return _makerHalfName; }
            set { _makerHalfName = value; }
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

        /// public propaty name  :  ModelHalfName
        /// <summary>車種半角名称プロパティ</summary>
        /// <value>正式名称（半角で管理）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車種半角名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ModelHalfName
        {
            get { return _modelHalfName; }
            set { _modelHalfName = value; }
        }

        /// public propaty name  :  SystematicCode
        /// <summary>系統コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   系統コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SystematicCode
        {
            get { return _systematicCode; }
            set { _systematicCode = value; }
        }

        /// public propaty name  :  SystematicName
        /// <summary>系統名称プロパティ</summary>
        /// <value>140系,180系等</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   系統名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SystematicName
        {
            get { return _systematicName; }
            set { _systematicName = value; }
        }

        /// public propaty name  :  ProduceTypeOfYearCd
        /// <summary>生産年式コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   生産年式コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ProduceTypeOfYearCd
        {
            get { return _produceTypeOfYearCd; }
            set { _produceTypeOfYearCd = value; }
        }

        /// public propaty name  :  ProduceTypeOfYearNm
        /// <summary>生産年式名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   生産年式名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ProduceTypeOfYearNm
        {
            get { return _produceTypeOfYearNm; }
            set { _produceTypeOfYearNm = value; }
        }

        /// public propaty name  :  StProduceTypeOfYear
        /// <summary>開始生産年式プロパティ</summary>
        /// <value>YYYYMM</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始生産年式プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime StProduceTypeOfYear
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
        public DateTime EdProduceTypeOfYear
        {
            get { return _edProduceTypeOfYear; }
            set { _edProduceTypeOfYear = value; }
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

        /// public propaty name  :  BodyNameCode
        /// <summary>ボディー名コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ボディー名コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BodyNameCode
        {
            get { return _bodyNameCode; }
            set { _bodyNameCode = value; }
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

        /// public propaty name  :  ExhaustGasSign
        /// <summary>排ガス記号プロパティ</summary>
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

        /// public propaty name  :  FrameNo
        /// <summary>車台番号プロパティ</summary>
        /// <value>車検証記載フォーマット対応（ HCR32-100251584 等）</value>
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

        /// public propaty name  :  SearchFrameNo
        /// <summary>車台番号（検索用）プロパティ</summary>
        /// <value>PM7の車台番号と同意</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車台番号（検索用）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SearchFrameNo
        {
            get { return _searchFrameNo; }
            set { _searchFrameNo = value; }
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

        /// public propaty name  :  AddiCarSpec1
        /// <summary>追加諸元1プロパティ</summary>
        /// <value>型式により変動</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   追加諸元1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AddiCarSpec1
        {
            get { return _addiCarSpec1; }
            set { _addiCarSpec1 = value; }
        }

        /// public propaty name  :  AddiCarSpec2
        /// <summary>追加諸元2プロパティ</summary>
        /// <value>型式により変動</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   追加諸元2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AddiCarSpec2
        {
            get { return _addiCarSpec2; }
            set { _addiCarSpec2 = value; }
        }

        /// public propaty name  :  AddiCarSpec3
        /// <summary>追加諸元3プロパティ</summary>
        /// <value>型式により変動</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   追加諸元3プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AddiCarSpec3
        {
            get { return _addiCarSpec3; }
            set { _addiCarSpec3 = value; }
        }

        /// public propaty name  :  AddiCarSpec4
        /// <summary>追加諸元4プロパティ</summary>
        /// <value>型式により変動</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   追加諸元4プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AddiCarSpec4
        {
            get { return _addiCarSpec4; }
            set { _addiCarSpec4 = value; }
        }

        /// public propaty name  :  AddiCarSpec5
        /// <summary>追加諸元5プロパティ</summary>
        /// <value>型式により変動</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   追加諸元5プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AddiCarSpec5
        {
            get { return _addiCarSpec5; }
            set { _addiCarSpec5 = value; }
        }

        /// public propaty name  :  AddiCarSpec6
        /// <summary>追加諸元6プロパティ</summary>
        /// <value>型式により変動</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   追加諸元6プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AddiCarSpec6
        {
            get { return _addiCarSpec6; }
            set { _addiCarSpec6 = value; }
        }

        /// public propaty name  :  AddiCarSpecTitle1
        /// <summary>追加諸元タイトル1プロパティ</summary>
        /// <value>型式により変動</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   追加諸元タイトル1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AddiCarSpecTitle1
        {
            get { return _addiCarSpecTitle1; }
            set { _addiCarSpecTitle1 = value; }
        }

        /// public propaty name  :  AddiCarSpecTitle2
        /// <summary>追加諸元タイトル2プロパティ</summary>
        /// <value>型式により変動</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   追加諸元タイトル2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AddiCarSpecTitle2
        {
            get { return _addiCarSpecTitle2; }
            set { _addiCarSpecTitle2 = value; }
        }

        /// public propaty name  :  AddiCarSpecTitle3
        /// <summary>追加諸元タイトル3プロパティ</summary>
        /// <value>型式により変動</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   追加諸元タイトル3プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AddiCarSpecTitle3
        {
            get { return _addiCarSpecTitle3; }
            set { _addiCarSpecTitle3 = value; }
        }

        /// public propaty name  :  AddiCarSpecTitle4
        /// <summary>追加諸元タイトル4プロパティ</summary>
        /// <value>型式により変動</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   追加諸元タイトル4プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AddiCarSpecTitle4
        {
            get { return _addiCarSpecTitle4; }
            set { _addiCarSpecTitle4 = value; }
        }

        /// public propaty name  :  AddiCarSpecTitle5
        /// <summary>追加諸元タイトル5プロパティ</summary>
        /// <value>型式により変動</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   追加諸元タイトル5プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AddiCarSpecTitle5
        {
            get { return _addiCarSpecTitle5; }
            set { _addiCarSpecTitle5 = value; }
        }

        /// public propaty name  :  AddiCarSpecTitle6
        /// <summary>追加諸元タイトル6プロパティ</summary>
        /// <value>型式により変動</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   追加諸元タイトル6プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AddiCarSpecTitle6
        {
            get { return _addiCarSpecTitle6; }
            set { _addiCarSpecTitle6 = value; }
        }

        /// public propaty name  :  RelevanceModel
        /// <summary>関連型式プロパティ</summary>
        /// <value>リサイクル系で使用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   関連型式プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string RelevanceModel
        {
            get { return _relevanceModel; }
            set { _relevanceModel = value; }
        }

        /// public propaty name  :  SubCarNmCd
        /// <summary>サブ車名コードプロパティ</summary>
        /// <value>リサイクル系で使用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   サブ車名コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SubCarNmCd
        {
            get { return _subCarNmCd; }
            set { _subCarNmCd = value; }
        }

        /// public propaty name  :  ModelGradeSname
        /// <summary>型式グレード略称プロパティ</summary>
        /// <value>リサイクル系で使用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   型式グレード略称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ModelGradeSname
        {
            get { return _modelGradeSname; }
            set { _modelGradeSname = value; }
        }

        /// public propaty name  :  BlockIllustrationCd
        /// <summary>ブロックイラストコードプロパティ</summary>
        /// <value>鈑金のブロック選択に使用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ブロックイラストコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BlockIllustrationCd
        {
            get { return _blockIllustrationCd; }
            set { _blockIllustrationCd = value; }
        }

        /// public propaty name  :  ThreeDIllustNo
        /// <summary>3DイラストNoプロパティ</summary>
        /// <value>鈑金の3Dイラスト選択に使用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   3DイラストNoプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ThreeDIllustNo
        {
            get { return _threeDIllustNo; }
            set { _threeDIllustNo = value; }
        }

        /// public propaty name  :  PartsDataOfferFlag
        /// <summary>部品データ提供フラグプロパティ</summary>
        /// <value>0:提供なし,1:提供あり</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   部品データ提供フラグプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PartsDataOfferFlag
        {
            get { return _partsDataOfferFlag; }
            set { _partsDataOfferFlag = value; }
        }

        /// public propaty name  :  InspectMaturityDate
        /// <summary>車検満期日プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車検満期日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime InspectMaturityDate
        {
            get { return _inspectMaturityDate; }
            set { _inspectMaturityDate = value; }
        }

        /// public propaty name  :  LTimeCiMatDate
        /// <summary>前回車検満期日プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   前回車検満期日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime LTimeCiMatDate
        {
            get { return _lTimeCiMatDate; }
            set { _lTimeCiMatDate = value; }
        }

        /// public propaty name  :  CarInspectYear
        /// <summary>車検期間プロパティ</summary>
        /// <value>1:1年,2:2年,3:3年</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車検期間プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CarInspectYear
        {
            get { return _carInspectYear; }
            set { _carInspectYear = value; }
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

        /// public propaty name  :  ColorCode
        /// <summary>カラーコードプロパティ</summary>
        /// <value>カタログの色コード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   カラーコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ColorCode
        {
            get { return _colorCode; }
            set { _colorCode = value; }
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

        /// public propaty name  :  FullModelFixedNoAry
        /// <summary>フル型式固定番号配列プロパティ</summary>
        /// <value>フル型式固定連番の配列クラスを格納（再検索不要になる）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   フル型式固定番号配列プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32[] FullModelFixedNoAry
        {
            get { return _fullModelFixedNoAry; }
            set { _fullModelFixedNoAry = value; }
        }

        /// public propaty name  :  CategoryObjAry
        /// <summary>装備オブジェクト配列プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   装備オブジェクト配列プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Byte[] CategoryObjAry
        {
            get { return _categoryObjAry; }
            set { _categoryObjAry = value; }
        }

        /// public propaty name  :  CarRelationGuid
        /// <summary>車両関連付けGUIDプロパティ</summary>
        /// <value>車両管理情報と伝票明細を紐付けるGUID、UI側で設定</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車両関連付けGUIDプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Guid CarRelationGuid
        {
            get { return _carRelationGuid; }
            set { _carRelationGuid = value; }
        }

        /// public propaty name  :  CarAddInfo1
        /// <summary>車輌追加情報１プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車輌追加情報１プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CarAddInfo1
        {
            get { return _carAddInfo1; }
            set { _carAddInfo1 = value; }
        }

        /// public propaty name  :  CarAddInfo2
        /// <summary>車輌追加情報２プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車輌追加情報２プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CarAddInfo2
        {
            get { return _carAddInfo2; }
            set { _carAddInfo2 = value; }
        }

        /// public propaty name  :  CarNote
        /// <summary>車輌備考プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車輌備考プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CarNote
        {
            get { return _carNote; }
            set { _carNote = value; }
        }

        /// public propaty name  :  FreeSrchMdlFxdNoAry
        /// <summary>自由検索型式固定番号配列プロパティ</summary>
        /// <value>自由検索シリアル№の配列クラスを格納（再検索不要になる）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自由検索型式固定番号配列プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string[] FreeSrchMdlFxdNoAry
        {
            get { return _freeSrchMdlFxdNoAry; }
            set { _freeSrchMdlFxdNoAry = value; }
        }

        /// public propaty name  :  ProduceTypeOfYearInput
        /// <summary>年式プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   年式プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ProduceTypeOfYearInput
        {
            get { return _produceTypeOfYearInput; }
            set { _produceTypeOfYearInput = value; }
        }

        // ADD 2013/03/19 -------------------->>>>>
        /// public propaty name  :  DomesticForeignCode
        /// <summary>国産/外車区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   国産/外車区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DomesticForeignCode
        {
            get { return _domesticForeignCode; }
            set { _domesticForeignCode = value; }
        }

        /// public propaty name  :  HandleInfoCode
        /// <summary>ハンドル位置情報コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ハンドル位置情報コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 HandleInfoCode
        {
            get { return _handleInfoCode; }
            set { _handleInfoCode = value; }
        }
        // ADD 2013/03/19 --------------------<<<<<
        

        /// <summary>
        /// 車両管理ワークコンストラクタ
        /// </summary>
        /// <returns>CarMangInputExtraInfoクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CarMangInputExtraInfoクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public CarMangInputExtraInfo()
        {
        }

        /// <summary>
        /// 車輌管理情報オブジェクトのコピー処理
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 車輌管理情報オブジェクトをコピーする</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        public CarMangInputExtraInfo Clone()
        {
            CarMangInputExtraInfo newInfo = new CarMangInputExtraInfo();
            newInfo.EnterpriseCode = this._enterpriseCode;           // 企業コード
            newInfo.CreateDateTime = this._createDateTime;           // 作成日時
            newInfo.FileHeaderGuid = this._fileHeaderGuid;           // GUID
            newInfo.UpdateDateTime = this._updateDateTime;           // 更新日付
            newInfo.LogicalDeleteCode = this._logicalDeleteCode;     // 論理削除区分
            newInfo.CustomerCode = this._customerCode;               // 得意先コード
            newInfo.CustomerCodeForGuide = this._customerCodeForGuide;// 得意先コード
            newInfo.CustomerName = this._customerName;               // 得意先名称
            newInfo.CarMngNo = this._carMngNo;                       // 車両管理番号
            newInfo.CarMngCode = this._carMngCode;                   // 車輌管理コード
            newInfo.NumberPlate1Code = this._numberPlate1Code;       // 陸運事務所番号
            newInfo.NumberPlate1Name = this._numberPlate1Name;       // 陸運事務局名称
            newInfo.NumberPlate2 = this._numberPlate2;               // 車両登録番号（種別）
            newInfo.NumberPlate3 = this._numberPlate3;               // 車両登録番号（カナ）
            newInfo.NumberPlate4 = this._numberPlate4;               // 車両登録番号（プレート番号）
            newInfo.NumberPlateForGuide = this._numberPlateForGuide; // 登録番号（ガイド用）
            newInfo.EntryDate = this._entryDate;                     // 登録年月日
            newInfo.FirstEntryDate = this._firstEntryDate;           // 初年度
            newInfo.ProduceTypeOfYearInput = this._produceTypeOfYearInput; // 年式
            newInfo.MakerCode = this._makerCode;                     // メーカーコード
            newInfo.MakerFullName = this._makerFullName;             // メーカー全角名称
            newInfo.MakerHalfName = this._makerHalfName;             // メーカー半角名称
            newInfo.ModelCode = this._modelCode;                     // 車種コード
            newInfo.ModelSubCode = this._modelSubCode;               // 車種サブコード
            newInfo.ModelFullName = this._modelFullName;             // 車種全角名称
            newInfo.ModelHalfName = this._modelHalfName;             // 車種半角名称
            newInfo.SystematicCode = this._systematicCode;           // 系統コード
            newInfo.SystematicName = this._systematicName;           // 系統名称
            newInfo.ProduceTypeOfYearCd = this._produceTypeOfYearCd; // 生産年式コード
            newInfo.ProduceTypeOfYearNm = this._produceTypeOfYearNm; // 生産年式名称
            newInfo.StProduceTypeOfYear = this._stProduceTypeOfYear; // 開始生産年式
            newInfo.EdProduceTypeOfYear = this._edProduceTypeOfYear; // 終了生産年式
            newInfo.DoorCount = this._doorCount;                     // ドア数
            newInfo.BodyNameCode = this._bodyNameCode;               // ボディー名コード
            newInfo.BodyName = this._bodyName;                       // ボディー名称
            newInfo.ExhaustGasSign = this._exhaustGasSign;           // 排ガス記号
            newInfo.SeriesModel = this._seriesModel;                 // シリーズ型式
            newInfo.CategorySignModel = this._categorySignModel;     // 型式（類別記号）
            newInfo.FullModel = this._fullModel;                     // 型式（フル型）
            newInfo.ModelDesignationNo = this._modelDesignationNo;   // 型式指定番号
            newInfo.CategoryNo = this._categoryNo;                   // 類別番号
            newInfo.FrameModel = this._frameModel;                   // 車台型式
            newInfo.FrameNo = this._frameNo;                         // 車台番号
            newInfo.SearchFrameNo = this._searchFrameNo;             // 車台番号（検索用）
            newInfo.StProduceFrameNo = this._stProduceFrameNo;       // 生産車台番号開始
            newInfo.EdProduceFrameNo = this._edProduceFrameNo;       // 生産車台番号終了
            newInfo.EngineModel = this._engineModel;                 // 原動機型式
            newInfo.ModelGradeNm = this._modelGradeNm;               // 型式グレード名称
            newInfo.EngineModelNm = this._engineModelNm;             // エンジン型式名称
            newInfo.EngineDisplaceNm = this._engineDisplaceNm;       // 排気量名称
            newInfo.EDivNm = this._eDivNm;                           // E区分名称
            newInfo.TransmissionNm = this._transmissionNm;           // ミッション名称
            newInfo.ShiftNm = this._shiftNm;                         // シフト名称
            newInfo.WheelDriveMethodNm = this._wheelDriveMethodNm;   // 駆動方式名称
            newInfo.AddiCarSpec1 = this._addiCarSpec1;               // 追加諸元1
            newInfo.AddiCarSpec2 = this._addiCarSpec2;               // 追加諸元2
            newInfo.AddiCarSpec3 = this._addiCarSpec3;               // 追加諸元3
            newInfo.AddiCarSpec4 = this._addiCarSpec4;               // 追加諸元4
            newInfo.AddiCarSpec5 = this._addiCarSpec5;               // 追加諸元5
            newInfo.AddiCarSpec6 = this._addiCarSpec6;               // 追加諸元6
            newInfo.AddiCarSpecTitle1 = this._addiCarSpecTitle1;     // 追加諸元タイトル1
            newInfo.AddiCarSpecTitle2 = this._addiCarSpecTitle2;     // 追加諸元タイトル2
            newInfo.AddiCarSpecTitle3 = this._addiCarSpecTitle3;     // 追加諸元タイトル3
            newInfo.AddiCarSpecTitle4 = this._addiCarSpecTitle4;     // 追加諸元タイトル4
            newInfo.AddiCarSpecTitle5 = this._addiCarSpecTitle5;     // 追加諸元タイトル5
            newInfo.AddiCarSpecTitle6 = this._addiCarSpecTitle6;     // 追加諸元タイトル6
            newInfo.RelevanceModel = this._relevanceModel;           // 関連型式
            newInfo.SubCarNmCd = this._subCarNmCd;                   // サブ車名コード
            newInfo.ModelGradeSname = this._modelGradeSname;         // 型式グレード略称
            newInfo.BlockIllustrationCd = this._blockIllustrationCd; // ブロックイラストコード
            newInfo.ThreeDIllustNo = this._threeDIllustNo;           // 3DイラストNo
            newInfo.PartsDataOfferFlag = this._partsDataOfferFlag;   // 部品データ提供フラグ
            newInfo.InspectMaturityDate = this._inspectMaturityDate; // 車検満期日
            newInfo.LTimeCiMatDate = this._lTimeCiMatDate;           // 前回車検満期日
            newInfo.CarInspectYear = this._carInspectYear;           // 車検期間
            newInfo.Mileage = this._mileage;                         // 車両走行距離
            newInfo.CarNo = this._carNo;                             // 号車
            newInfo.FullModelFixedNoAry = this._fullModelFixedNoAry; // フル型式固定番号配列
            newInfo.ColorCode = this._colorCode;                     // カラーコード
            newInfo.ColorName1 = this._colorName1;                   // カラー名称
            newInfo.TrimCode = this._trimCode;                       // トリムコード
            newInfo.TrimName = this._trimName;                       // トリム名称
            newInfo.CategoryObjAry = this._categoryObjAry;           // 装備オブジェクト配列
            newInfo.CarAddInfo1 = this._carAddInfo1;                 // 追加情報１
            newInfo.CarAddInfo2 = this._carAddInfo2;                 // 追加情報２
            newInfo.CarNote = this._carNote;                         // 備考
            newInfo.FreeSrchMdlFxdNoAry = this._freeSrchMdlFxdNoAry; // 自由検索型式固定番号配列
            // ADD 2013/03/19 -------------------->>>>>
            newInfo.DomesticForeignCode = this._domesticForeignCode; // 国産/外車区分
            newInfo.HandleInfoCode = this._handleInfoCode;           // ハンドル位置情報
            // ADD 2013/03/19 --------------------<<<<<

            return newInfo;
        }
    }
}
