//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   車両管理マスタデータパラメータ
//                  :   PMSYR09013D.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programmer       :   21112　久保田
// Date             :   2008.06.02
// Note             :   フル型式固定番号配列については、ツールで生成
//　　　　　　　　　:　 されたコードを修正する必要がある点に注意する
//----------------------------------------------------------------------
// Update Note      :   2009/09/11 李占川
//                      車輌管理マスタ LDNS開発対応
// Update Note      :   2010/04/27 gaoyh
//                      自由検索型式固定番号配列を追加
// Update Note      :   2013/03/22 FSI高橋 文彰
// 管理番号         :   10900269-00 
//                      SPK車台番号文字列対応に伴う国産/外車区分の追加
//----------------------------------------------------------------------
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//**********************************************************************

using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    // MANTIS 11632 対応
    // FirstEntryDate DataTime ⇒ Int32 
    // 自動生成時は手動で変更する必要あり


    /// ※車両管理マスタ比較処理を追記している点に注意する事
    /// public class name:   CarManagementWork
    /// <summary>
    ///                      車両管理ワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   車両管理ワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/09/19  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   8/12  久保田</br>
    /// <br>                 :   装備オブジェクト配列 を追加</br>
    /// <br>                 :   原動機型式（エンジン） を追加</br>
    /// <br>Update Note      :   2009/09/11 李占川</br>
    /// <br>                 :   車輌管理マスタ LDNS開発対応</br>
    /// <br>                 :   </br>
    /// <br>Update Note      :   2010/04/27 gaoyh</br>
    /// <br>                 :   自由検索型式固定番号配列を追加</br>
    /// <br>                 :   </br>
    /// <br>Update Note      :   2013/03/22 FSI高橋 文彰</br>
    /// <br>                 :   SPK車台番号文字列対応に伴う国産/外車区分の追加</br>
    /// <br>                 :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class CarManagementWork : IFileHeader
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

        /// <summary>得意先コード</summary>
        private Int32 _customerCode;

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

        /// <summary>登録年月日</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _entryDate;

        /// <summary>初年度</summary>
        /// <remarks>YYYYMM</remarks>
        private Int32 _firstEntryDate;

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

        // --- ADD 2009/09/08 ---------->>>>>
        /// <summary>車輌備考</summary>
        private string _carNote = "";
        // --- ADD 2009/09/08 ----------<<<<<

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

        /// <summary>自由検索型式固定番号配列</summary>
        /// <remarks>自由検索シリアル№の配列クラスを格納（再検索不要になる）</remarks>
        private Byte[] _freeSrchMdlFxdNoAry = new Byte[0];

        /// <summary>車両関連付けGUID</summary>
        /// <remarks>車両管理情報と伝票明細を紐付けるGUID、UI側で設定</remarks>
        private Guid _carRelationGuid;

        // ADD 2013/03/22  -------------------->>>>>
        /// <summary>国産/外車区分</summary>
        private Int32 _domesticForeignCode;

        /// <summary>ハンドル位置情報コード</summary>
        private Int32 _handleInfoCode;
        // ADD 2013/03/22  --------------------<<<<<

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
        public Int32 FirstEntryDate
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

        // --- ADD 2009/09/08 ---------->>>>>
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
        // --- ADD 2009/09/08 ----------<<<<<

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

        /// public propaty name  :  FreeSrchMdlFxdNoAry
        /// <summary>自由検索型式固定番号配列プロパティ</summary>
        /// <value>自由検索シリアル№の配列クラスを格納（再検索不要になる）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自由検索型式固定番号配列プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Byte[] FreeSrchMdlFxdNoAry
        {
            get { return _freeSrchMdlFxdNoAry; }
            set { _freeSrchMdlFxdNoAry = value; }
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

        // --- ADD 2009/09/11 ---------->>>>>
        /// <summary>車輌追加情報１</summary>
        private string _carAddInfo1 = "";

        /// <summary>車輌追加情報２</summary>
        private string _carAddInfo2 = "";

        /// <summary>得意先開始</summary>
        private int _customerCodeSt;

        /// <summary>得意先終了</summary>
        private int _customerCodeEd;

        /// <summary>車輌管理コード検索区分</summary>
        private int _carMngCodeSearchDiv;

        /// <summary>得意先名称</summary>
        private string _customerName = "";

        /// <summary>型式</summary>
        private string _kindModel = "";

        /// <summary>車輌備考検索区分</summary>
        private int _carNoteSearchDiv;

        /// <summary>型式検索区分</summary>
        private int _kindModelSearchDiv;

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

        /// public propaty name  :  CustomerCodeSt
        /// <summary>得意先開始プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先開始プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public int CustomerCodeSt
        {
            get { return _customerCodeSt; }
            set { _customerCodeSt = value; }
        }

        /// public propaty name  :  CustomerCodeEd
        /// <summary>得意先終了プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先終了プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public int CustomerCodeEd
        {
            get { return _customerCodeEd; }
            set { _customerCodeEd = value; }
        }

        /// public propaty name  :  CarMngNoSearchDiv
        /// <summary>車輌管理コード検索区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車輌管理コード検索区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public int CarMngCodeSearchDiv
        {
            get { return _carMngCodeSearchDiv; }
            set { _carMngCodeSearchDiv = value; }
        }

        /// public propaty name  :  CarNoteSearchDiv
        /// <summary>車輌備考検索区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車輌備考検索区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public int CarNoteSearchDiv 
        {
            get { return _carNoteSearchDiv; }
            set { _carNoteSearchDiv = value; }
        }

        /// public propaty name  :  KindModelSearchDiv
        /// <summary>型式検索区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   型式検索区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public int KindModelSearchDiv 
        {
            get { return _kindModelSearchDiv; }
            set { _kindModelSearchDiv = value; }
        }

        /// public propaty name  :  KindModel
        /// <summary>型式プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   型式プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string KindModel 
        {
            get { return _kindModel; }
            set { _kindModel = value; }
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
        // --- ADD 2009/09/11 ----------<<<<<

        // ADD 2013/03/22  -------------------->>>>>
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
        // ADD 2013/03/22  --------------------<<<<<
        

        /// <summary>
        /// 車両管理ワークコンストラクタ
        /// </summary>
        /// <returns>CarManagementWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CarManagementWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public CarManagementWork()
        {
        }


        /// <summary>
        /// 車両管理マスタ比較処理
        /// </summary>
        /// <param name="target">比較対象のCarManagementクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CarManagementクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// <br>Update Note      :   2009/09/11 李占川</br>
        /// <br>                 :   車輌管理マスタ LDNS開発対応</br>
        /// <br>Update Note      :   2013/03/22 FSI高橋 文彰</br>
        /// <br>                 :   SPK車台番号文字列対応に伴う国産/外車区分の追加</br>
        /// </remarks>
        public ArrayList Compare(CarManagementWork target)
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
            if (this.CustomerCode != target.CustomerCode) resList.Add("CustomerCode");
            if (this.CarMngNo != target.CarMngNo) resList.Add("CarMngNo");
            if (this.CarMngCode != target.CarMngCode) resList.Add("CarMngCode");
            if (this.NumberPlate1Code != target.NumberPlate1Code) resList.Add("NumberPlate1Code");
            if (this.NumberPlate1Name != target.NumberPlate1Name) resList.Add("NumberPlate1Name");
            if (this.NumberPlate2 != target.NumberPlate2) resList.Add("NumberPlate2");
            if (this.NumberPlate3 != target.NumberPlate3) resList.Add("NumberPlate3");
            if (this.NumberPlate4 != target.NumberPlate4) resList.Add("NumberPlate4");
            if (this.EntryDate != target.EntryDate) resList.Add("EntryDate");
            if (this.FirstEntryDate != target.FirstEntryDate) resList.Add("FirstEntryDate");
            if (this.MakerCode != target.MakerCode) resList.Add("MakerCode");
            if (this.MakerFullName != target.MakerFullName) resList.Add("MakerFullName");
            if (this.MakerHalfName != target.MakerHalfName) resList.Add("MakerHalfName");
            if (this.ModelCode != target.ModelCode) resList.Add("ModelCode");
            if (this.ModelSubCode != target.ModelSubCode) resList.Add("ModelSubCode");
            if (this.ModelFullName != target.ModelFullName) resList.Add("ModelFullName");
            if (this.ModelHalfName != target.ModelHalfName) resList.Add("ModelHalfName");
            if (this.SystematicCode != target.SystematicCode) resList.Add("SystematicCode");
            if (this.SystematicName != target.SystematicName) resList.Add("SystematicName");
            if (this.ProduceTypeOfYearCd != target.ProduceTypeOfYearCd) resList.Add("ProduceTypeOfYearCd");
            if (this.ProduceTypeOfYearNm != target.ProduceTypeOfYearNm) resList.Add("ProduceTypeOfYearNm");
            if (this.StProduceTypeOfYear != target.StProduceTypeOfYear) resList.Add("StProduceTypeOfYear");
            if (this.EdProduceTypeOfYear != target.EdProduceTypeOfYear) resList.Add("EdProduceTypeOfYear");
            if (this.DoorCount != target.DoorCount) resList.Add("DoorCount");
            if (this.BodyNameCode != target.BodyNameCode) resList.Add("BodyNameCode");
            if (this.BodyName != target.BodyName) resList.Add("BodyName");
            if (this.ExhaustGasSign != target.ExhaustGasSign) resList.Add("ExhaustGasSign");
            if (this.SeriesModel != target.SeriesModel) resList.Add("SeriesModel");
            if (this.CategorySignModel != target.CategorySignModel) resList.Add("CategorySignModel");
            if (this.FullModel != target.FullModel) resList.Add("FullModel");
            if (this.ModelDesignationNo != target.ModelDesignationNo) resList.Add("ModelDesignationNo");
            if (this.CategoryNo != target.CategoryNo) resList.Add("CategoryNo");
            if (this.FrameModel != target.FrameModel) resList.Add("FrameModel");
            if (this.FrameNo != target.FrameNo) resList.Add("FrameNo");
            if (this.SearchFrameNo != target.SearchFrameNo) resList.Add("SearchFrameNo");
            if (this.StProduceFrameNo != target.StProduceFrameNo) resList.Add("StProduceFrameNo");
            if (this.EdProduceFrameNo != target.EdProduceFrameNo) resList.Add("EdProduceFrameNo");
            if (this.EngineModel != target.EngineModel) resList.Add("EngineModel");
            if (this.ModelGradeNm != target.ModelGradeNm) resList.Add("ModelGradeNm");
            if (this.EngineModelNm != target.EngineModelNm) resList.Add("EngineModelNm");
            if (this.EngineDisplaceNm != target.EngineDisplaceNm) resList.Add("EngineDisplaceNm");
            if (this.EDivNm != target.EDivNm) resList.Add("EDivNm");
            if (this.TransmissionNm != target.TransmissionNm) resList.Add("TransmissionNm");
            if (this.ShiftNm != target.ShiftNm) resList.Add("ShiftNm");
            if (this.WheelDriveMethodNm != target.WheelDriveMethodNm) resList.Add("WheelDriveMethodNm");
            if (this.AddiCarSpec1 != target.AddiCarSpec1) resList.Add("AddiCarSpec1");
            if (this.AddiCarSpec2 != target.AddiCarSpec2) resList.Add("AddiCarSpec2");
            if (this.AddiCarSpec3 != target.AddiCarSpec3) resList.Add("AddiCarSpec3");
            if (this.AddiCarSpec4 != target.AddiCarSpec4) resList.Add("AddiCarSpec4");
            if (this.AddiCarSpec5 != target.AddiCarSpec5) resList.Add("AddiCarSpec5");
            if (this.AddiCarSpec6 != target.AddiCarSpec6) resList.Add("AddiCarSpec6");
            if (this.AddiCarSpecTitle1 != target.AddiCarSpecTitle1) resList.Add("AddiCarSpecTitle1");
            if (this.AddiCarSpecTitle2 != target.AddiCarSpecTitle2) resList.Add("AddiCarSpecTitle2");
            if (this.AddiCarSpecTitle3 != target.AddiCarSpecTitle3) resList.Add("AddiCarSpecTitle3");
            if (this.AddiCarSpecTitle4 != target.AddiCarSpecTitle4) resList.Add("AddiCarSpecTitle4");
            if (this.AddiCarSpecTitle5 != target.AddiCarSpecTitle5) resList.Add("AddiCarSpecTitle5");
            if (this.AddiCarSpecTitle6 != target.AddiCarSpecTitle6) resList.Add("AddiCarSpecTitle6");
            if (this.RelevanceModel != target.RelevanceModel) resList.Add("RelevanceModel");
            if (this.SubCarNmCd != target.SubCarNmCd) resList.Add("SubCarNmCd");
            if (this.ModelGradeSname != target.ModelGradeSname) resList.Add("ModelGradeSname");
            if (this.BlockIllustrationCd != target.BlockIllustrationCd) resList.Add("BlockIllustrationCd");
            if (this.ThreeDIllustNo != target.ThreeDIllustNo) resList.Add("ThreeDIllustNo");
            if (this.PartsDataOfferFlag != target.PartsDataOfferFlag) resList.Add("PartsDataOfferFlag");
            if (this.InspectMaturityDate != target.InspectMaturityDate) resList.Add("InspectMaturityDate");
            if (this.LTimeCiMatDate != target.LTimeCiMatDate) resList.Add("LTimeCiMatDate");
            if (this.CarInspectYear != target.CarInspectYear) resList.Add("CarInspectYear");
            if (this.Mileage != target.Mileage) resList.Add("Mileage");
            if (this.CarNote != target.CarNote) resList.Add("CarNote");  // ADD 2009/09/08
            if (this.CarNo != target.CarNo) resList.Add("CarNo");
            if (this.ColorCode != target.ColorCode) resList.Add("ColorCode");
            if (this.ColorName1 != target.ColorName1) resList.Add("ColorName1");
            if (this.TrimCode != target.TrimCode) resList.Add("TrimCode");
            if (this.TrimName != target.TrimName) resList.Add("TrimName");
            if (this.CarAddInfo1 != target.CarAddInfo1) resList.Add("CarAddInfo1");  // ADD 2009/09/11
            if (this.CarAddInfo2 != target.CarAddInfo2) resList.Add("CarAddInfo2");  // ADD 2009/09/11
            if (this.CustomerName != target.CustomerName) resList.Add("CustomerName");  // ADD 2009/09/11
            // ADD 2013/03/22 -------------------->>>>>
            if (this.DomesticForeignCode != target.DomesticForeignCode) resList.Add("DomesticForeignCode");
            if (this.HandleInfoCode != target.HandleInfoCode) resList.Add("HandleInfoCode");
            // ADD 2013/03/22 --------------------<<<<<
            if (this.FullModelFixedNoAry.Length != target.FullModelFixedNoAry.Length)
            {
                resList.Add("FullModelFixedNoAry");
            }
            else
            {
                for (int i = 0; this.FullModelFixedNoAry.Length > i; i++)
                {
                    if (this.FullModelFixedNoAry[i] != target.FullModelFixedNoAry[i])
                    {
                        resList.Add("FullModelFixedNoAry");
                        break;
                    }
                }
            }

            if (this.CategoryObjAry.Length != target.CategoryObjAry.Length)
            {
                resList.Add("CategoryObjAry");
            }
            else
            {
                for (int i = 0; this.CategoryObjAry.Length > i; i++)
                {
                    if (this.CategoryObjAry[i] != target.CategoryObjAry[i])
                    {
                        resList.Add("CategoryObjAry");
                        break;
                    }
                }
            }
            // ----- ADD 2010/04/27 ------------>>>
            if (this.FreeSrchMdlFxdNoAry.Length != target.FreeSrchMdlFxdNoAry.Length)
            {
                resList.Add("FreeSrchMdlFxdNoAry");
            }
            else
            {
                for (int i = 0; this.FreeSrchMdlFxdNoAry.Length > i; i++ )
                {
                    if (this.FreeSrchMdlFxdNoAry[i] != target.FreeSrchMdlFxdNoAry[i])
                    {
                        resList.Add("FreeSrchMdlFxdNoAry");
                        break;
                    }
                }
            }
            // ----- ADD 2010/04/27 ------------<<<

            if (this.CarRelationGuid != target.CarRelationGuid) resList.Add("CarRelationGuid");

            return resList;
        }
    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>CarManagementWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   CarManagementWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// <br>Update Note      :   2009/09/11 李占川</br>
    /// <br>                 :   車輌管理マスタ LDNS開発対応</br>
    /// <br>Update Note      :   2013/03/22 FSI高橋 文彰</br>
    /// <br>                 :   SPK車台番号文字列対応に伴う国産/外車区分の追加</br>
    /// </remarks>
    public class CarManagementWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   CarManagementWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  CarManagementWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is CarManagementWork || graph is ArrayList || graph is CarManagementWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(CarManagementWork).FullName));

            if (graph != null && graph is CarManagementWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.CarManagementWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is CarManagementWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((CarManagementWork[])graph).Length;
            }
            else if (graph is CarManagementWork)
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
            //得意先コード
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerCode
            //車両管理番号
            serInfo.MemberInfo.Add(typeof(Int32)); //CarMngNo
            //車輌管理コード
            serInfo.MemberInfo.Add(typeof(string)); //CarMngCode
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
            //登録年月日
            serInfo.MemberInfo.Add(typeof(Int32)); //EntryDate
            //初年度
            serInfo.MemberInfo.Add(typeof(Int32)); //FirstEntryDate
            //メーカーコード
            serInfo.MemberInfo.Add(typeof(Int32)); //MakerCode
            //メーカー全角名称
            serInfo.MemberInfo.Add(typeof(string)); //MakerFullName
            //メーカー半角名称
            serInfo.MemberInfo.Add(typeof(string)); //MakerHalfName
            //車種コード
            serInfo.MemberInfo.Add(typeof(Int32)); //ModelCode
            //車種サブコード
            serInfo.MemberInfo.Add(typeof(Int32)); //ModelSubCode
            //車種全角名称
            serInfo.MemberInfo.Add(typeof(string)); //ModelFullName
            //車種半角名称
            serInfo.MemberInfo.Add(typeof(string)); //ModelHalfName
            //系統コード
            serInfo.MemberInfo.Add(typeof(Int32)); //SystematicCode
            //系統名称
            serInfo.MemberInfo.Add(typeof(string)); //SystematicName
            //生産年式コード
            serInfo.MemberInfo.Add(typeof(Int32)); //ProduceTypeOfYearCd
            //生産年式名称
            serInfo.MemberInfo.Add(typeof(string)); //ProduceTypeOfYearNm
            //開始生産年式
            serInfo.MemberInfo.Add(typeof(Int32)); //StProduceTypeOfYear
            //終了生産年式
            serInfo.MemberInfo.Add(typeof(Int32)); //EdProduceTypeOfYear
            //ドア数
            serInfo.MemberInfo.Add(typeof(Int32)); //DoorCount
            //ボディー名コード
            serInfo.MemberInfo.Add(typeof(Int32)); //BodyNameCode
            //ボディー名称
            serInfo.MemberInfo.Add(typeof(string)); //BodyName
            //排ガス記号
            serInfo.MemberInfo.Add(typeof(string)); //ExhaustGasSign
            //シリーズ型式
            serInfo.MemberInfo.Add(typeof(string)); //SeriesModel
            //型式（類別記号）
            serInfo.MemberInfo.Add(typeof(string)); //CategorySignModel
            //型式（フル型）
            serInfo.MemberInfo.Add(typeof(string)); //FullModel
            //型式指定番号
            serInfo.MemberInfo.Add(typeof(Int32)); //ModelDesignationNo
            //類別番号
            serInfo.MemberInfo.Add(typeof(Int32)); //CategoryNo
            //車台型式
            serInfo.MemberInfo.Add(typeof(string)); //FrameModel
            //車台番号
            serInfo.MemberInfo.Add(typeof(string)); //FrameNo
            //車台番号（検索用）
            serInfo.MemberInfo.Add(typeof(Int32)); //SearchFrameNo
            //生産車台番号開始
            serInfo.MemberInfo.Add(typeof(Int32)); //StProduceFrameNo
            //生産車台番号終了
            serInfo.MemberInfo.Add(typeof(Int32)); //EdProduceFrameNo
            //原動機型式（エンジン）
            serInfo.MemberInfo.Add(typeof(string)); //EngineModel
            //型式グレード名称
            serInfo.MemberInfo.Add(typeof(string)); //ModelGradeNm
            //エンジン型式名称
            serInfo.MemberInfo.Add(typeof(string)); //EngineModelNm
            //排気量名称
            serInfo.MemberInfo.Add(typeof(string)); //EngineDisplaceNm
            //E区分名称
            serInfo.MemberInfo.Add(typeof(string)); //EDivNm
            //ミッション名称
            serInfo.MemberInfo.Add(typeof(string)); //TransmissionNm
            //シフト名称
            serInfo.MemberInfo.Add(typeof(string)); //ShiftNm
            //駆動方式名称
            serInfo.MemberInfo.Add(typeof(string)); //WheelDriveMethodNm
            //追加諸元1
            serInfo.MemberInfo.Add(typeof(string)); //AddiCarSpec1
            //追加諸元2
            serInfo.MemberInfo.Add(typeof(string)); //AddiCarSpec2
            //追加諸元3
            serInfo.MemberInfo.Add(typeof(string)); //AddiCarSpec3
            //追加諸元4
            serInfo.MemberInfo.Add(typeof(string)); //AddiCarSpec4
            //追加諸元5
            serInfo.MemberInfo.Add(typeof(string)); //AddiCarSpec5
            //追加諸元6
            serInfo.MemberInfo.Add(typeof(string)); //AddiCarSpec6
            //追加諸元タイトル1
            serInfo.MemberInfo.Add(typeof(string)); //AddiCarSpecTitle1
            //追加諸元タイトル2
            serInfo.MemberInfo.Add(typeof(string)); //AddiCarSpecTitle2
            //追加諸元タイトル3
            serInfo.MemberInfo.Add(typeof(string)); //AddiCarSpecTitle3
            //追加諸元タイトル4
            serInfo.MemberInfo.Add(typeof(string)); //AddiCarSpecTitle4
            //追加諸元タイトル5
            serInfo.MemberInfo.Add(typeof(string)); //AddiCarSpecTitle5
            //追加諸元タイトル6
            serInfo.MemberInfo.Add(typeof(string)); //AddiCarSpecTitle6
            //関連型式
            serInfo.MemberInfo.Add(typeof(string)); //RelevanceModel
            //サブ車名コード
            serInfo.MemberInfo.Add(typeof(Int32)); //SubCarNmCd
            //型式グレード略称
            serInfo.MemberInfo.Add(typeof(string)); //ModelGradeSname
            //ブロックイラストコード
            serInfo.MemberInfo.Add(typeof(Int32)); //BlockIllustrationCd
            //3DイラストNo
            serInfo.MemberInfo.Add(typeof(Int32)); //ThreeDIllustNo
            //部品データ提供フラグ
            serInfo.MemberInfo.Add(typeof(Int32)); //PartsDataOfferFlag
            //車検満期日
            serInfo.MemberInfo.Add(typeof(Int32)); //InspectMaturityDate
            //前回車検満期日
            serInfo.MemberInfo.Add(typeof(Int32)); //LTimeCiMatDate
            //車検期間
            serInfo.MemberInfo.Add(typeof(Int32)); //CarInspectYear
            //車両走行距離
            serInfo.MemberInfo.Add(typeof(Int32)); //Mileage
            // --- ADD 2009/09/08 ---------->>>>>
            //車輌備考
            serInfo.MemberInfo.Add(typeof(string)); //CarNote
            // --- ADD 2009/09/08 ----------<<<<<
            //号車
            serInfo.MemberInfo.Add(typeof(string)); //CarNo
            //カラーコード
            serInfo.MemberInfo.Add(typeof(string)); //ColorCode
            //カラー名称1
            serInfo.MemberInfo.Add(typeof(string)); //ColorName1
            //トリムコード
            serInfo.MemberInfo.Add(typeof(string)); //TrimCode
            //トリム名称
            serInfo.MemberInfo.Add(typeof(string)); //TrimName
            //フル型式固定番号配列
            serInfo.MemberInfo.Add(typeof(Int32[])); //FullModelFixedNoAry
            //装備オブジェクト配列
            serInfo.MemberInfo.Add(typeof(Byte[])); //CategoryObjAry
            //車両関連付けGUID
            serInfo.MemberInfo.Add(typeof(byte[]));  //CarRelationGuid
            // --- ADD 2009/09/11 ---------->>>>>
            //車輌追加情報１
            serInfo.MemberInfo.Add(typeof(string)); //CarAddInfo1
            //車輌追加情報２
            serInfo.MemberInfo.Add(typeof(string)); //CarAddInfo2
            //得意先名称
            serInfo.MemberInfo.Add(typeof(string)); //CustomerName
            // --- ADD 2009/09/11 ----------<<<<<
            // --- ADD 2010/04/27 ---------->>>>>
            serInfo.MemberInfo.Add(typeof(Byte[])); // FreeSrchMdlFxdNoAryRF
            // --- ADD 2010/04/27 ----------<<<<<
            // ADD 2013/03/22 -------------------->>>>>
            // 国産/外車区分
            serInfo.MemberInfo.Add(typeof(Int32)); // DomesticForeignCode
            // ハンドル位置情報
            serInfo.MemberInfo.Add(typeof(Int32)); // HandleInfoCode
            // ADD 2013/03/22 --------------------<<<<<

            serInfo.Serialize(writer, serInfo);
            if (graph is CarManagementWork)
            {
                CarManagementWork temp = (CarManagementWork)graph;

                SetCarManagementWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is CarManagementWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((CarManagementWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (CarManagementWork temp in lst)
                {
                    SetCarManagementWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// CarManagementWorkメンバ数(publicプロパティ数)
        /// </summary>
        //private const int currentMemberCount = 84; // DEL 2009/09/11
        //private const int currentMemberCount = 87;  // ADD 2009/09/11 // DEL 2010/04/27
        //private const int currentMemberCount = 88;  // ADD 2010/04/27 // DEL 2013/03/22
        private const int currentMemberCount = 90;  // ADD 2013/03/22

        /// <summary>
        ///  CarManagementWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   CarManagementWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// <br>Update Note      :   2009/09/11 李占川</br>
        /// <br>                 :   車輌管理マスタ LDNS開発対応</br>
        /// <br>Update Note      :   2013/03/22 FSI高橋 文彰</br>
        /// <br>                 :   SPK車台番号文字列対応に伴う国産/外車区分の追加</br>
        /// </remarks>
        private void SetCarManagementWork(System.IO.BinaryWriter writer, CarManagementWork temp)
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
            //得意先コード
            writer.Write(temp.CustomerCode);
            //車両管理番号
            writer.Write(temp.CarMngNo);
            //車輌管理コード
            writer.Write(temp.CarMngCode);
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
            //登録年月日
            writer.Write((Int64)temp.EntryDate.Ticks);
            //初年度
            writer.Write(temp.FirstEntryDate);
            //メーカーコード
            writer.Write(temp.MakerCode);
            //メーカー全角名称
            writer.Write(temp.MakerFullName);
            //メーカー半角名称
            writer.Write(temp.MakerHalfName);
            //車種コード
            writer.Write(temp.ModelCode);
            //車種サブコード
            writer.Write(temp.ModelSubCode);
            //車種全角名称
            writer.Write(temp.ModelFullName);
            //車種半角名称
            writer.Write(temp.ModelHalfName);
            //系統コード
            writer.Write(temp.SystematicCode);
            //系統名称
            writer.Write(temp.SystematicName);
            //生産年式コード
            writer.Write(temp.ProduceTypeOfYearCd);
            //生産年式名称
            writer.Write(temp.ProduceTypeOfYearNm);
            //開始生産年式
            writer.Write((Int64)temp.StProduceTypeOfYear.Ticks);
            //終了生産年式
            writer.Write((Int64)temp.EdProduceTypeOfYear.Ticks);
            //ドア数
            writer.Write(temp.DoorCount);
            //ボディー名コード
            writer.Write(temp.BodyNameCode);
            //ボディー名称
            writer.Write(temp.BodyName);
            //排ガス記号
            writer.Write(temp.ExhaustGasSign);
            //シリーズ型式
            writer.Write(temp.SeriesModel);
            //型式（類別記号）
            writer.Write(temp.CategorySignModel);
            //型式（フル型）
            writer.Write(temp.FullModel);
            //型式指定番号
            writer.Write(temp.ModelDesignationNo);
            //類別番号
            writer.Write(temp.CategoryNo);
            //車台型式
            writer.Write(temp.FrameModel);
            //車台番号
            writer.Write(temp.FrameNo);
            //車台番号（検索用）
            writer.Write(temp.SearchFrameNo);
            //生産車台番号開始
            writer.Write(temp.StProduceFrameNo);
            //生産車台番号終了
            writer.Write(temp.EdProduceFrameNo);
            //原動機型式（エンジン）
            writer.Write(temp.EngineModel);
            //型式グレード名称
            writer.Write(temp.ModelGradeNm);
            //エンジン型式名称
            writer.Write(temp.EngineModelNm);
            //排気量名称
            writer.Write(temp.EngineDisplaceNm);
            //E区分名称
            writer.Write(temp.EDivNm);
            //ミッション名称
            writer.Write(temp.TransmissionNm);
            //シフト名称
            writer.Write(temp.ShiftNm);
            //駆動方式名称
            writer.Write(temp.WheelDriveMethodNm);
            //追加諸元1
            writer.Write(temp.AddiCarSpec1);
            //追加諸元2
            writer.Write(temp.AddiCarSpec2);
            //追加諸元3
            writer.Write(temp.AddiCarSpec3);
            //追加諸元4
            writer.Write(temp.AddiCarSpec4);
            //追加諸元5
            writer.Write(temp.AddiCarSpec5);
            //追加諸元6
            writer.Write(temp.AddiCarSpec6);
            //追加諸元タイトル1
            writer.Write(temp.AddiCarSpecTitle1);
            //追加諸元タイトル2
            writer.Write(temp.AddiCarSpecTitle2);
            //追加諸元タイトル3
            writer.Write(temp.AddiCarSpecTitle3);
            //追加諸元タイトル4
            writer.Write(temp.AddiCarSpecTitle4);
            //追加諸元タイトル5
            writer.Write(temp.AddiCarSpecTitle5);
            //追加諸元タイトル6
            writer.Write(temp.AddiCarSpecTitle6);
            //関連型式
            writer.Write(temp.RelevanceModel);
            //サブ車名コード
            writer.Write(temp.SubCarNmCd);
            //型式グレード略称
            writer.Write(temp.ModelGradeSname);
            //ブロックイラストコード
            writer.Write(temp.BlockIllustrationCd);
            //3DイラストNo
            writer.Write(temp.ThreeDIllustNo);
            //部品データ提供フラグ
            writer.Write(temp.PartsDataOfferFlag);
            //車検満期日
            writer.Write((Int64)temp.InspectMaturityDate.Ticks);
            //前回車検満期日
            writer.Write((Int64)temp.LTimeCiMatDate.Ticks);
            //車検期間
            writer.Write(temp.CarInspectYear);
            //車両走行距離
            writer.Write(temp.Mileage);
            // --- ADD 2009/09/08 ---------->>>>>
            //車輌備考
            writer.Write(temp.CarNote);
            // --- ADD 2009/09/08 ----------<<<<<
            //号車
            writer.Write(temp.CarNo);
            //カラーコード
            writer.Write(temp.ColorCode);
            //カラー名称1
            writer.Write(temp.ColorName1);
            //トリムコード
            writer.Write(temp.TrimCode);
            //トリム名称
            writer.Write(temp.TrimName);
            //フル型式固定番号配列
            int length = temp.FullModelFixedNoAry.Length;
            writer.Write(length);
            for (int cnt = 0; cnt < length; cnt++)
                writer.Write(temp.FullModelFixedNoAry[cnt]);
            //装備オブジェクト配列
            writer.Write(temp.CategoryObjAry.Length);
            writer.Write(temp.CategoryObjAry);
            //車両関連付けGUID
            byte[] carRelationGuidArray = temp.CarRelationGuid.ToByteArray();
            writer.Write(carRelationGuidArray.Length);
            writer.Write(temp.CarRelationGuid.ToByteArray());
            // --- ADD 2009/09/11 ---------->>>>>
            writer.Write(temp.CarAddInfo1);
            writer.Write(temp.CarAddInfo2);
            writer.Write(temp.CustomerName);
            // --- ADD 2009/09/11 ----------<<<<<
            // --- ADD 2010/04/27 ---------->>>>>
            //自由検索型式固定番号配列
            writer.Write(temp.FreeSrchMdlFxdNoAry.Length);
            writer.Write(temp.FreeSrchMdlFxdNoAry);
            // --- ADD 2010/04/27 ----------<<<<<
            // ADD 2013/03/22 -------------------->>>>>
            // 国産/外車区分
            writer.Write(temp.DomesticForeignCode);
            // ハンドル位置情報
            writer.Write(temp.HandleInfoCode);
            // ADD 2013/03/22 --------------------<<<<<
        }

        /// <summary>
        ///  CarManagementWorkインスタンス取得
        /// </summary>
        /// <returns>CarManagementWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CarManagementWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// <br>Update Note      :   2009/09/11 李占川</br>
        /// <br>                 :   車輌管理マスタ LDNS開発対応</br>
        /// <br>Update Note      :   2013/03/22 FSI高橋 文彰</br>
        /// <br>                 :   SPK車台番号文字列対応に伴う国産/外車区分の追加</br>
        /// </remarks>
        private CarManagementWork GetCarManagementWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            CarManagementWork temp = new CarManagementWork();

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
            //得意先コード
            temp.CustomerCode = reader.ReadInt32();
            //車両管理番号
            temp.CarMngNo = reader.ReadInt32();
            //車輌管理コード
            temp.CarMngCode = reader.ReadString();
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
            //登録年月日
            temp.EntryDate = new DateTime(reader.ReadInt64());
            //初年度
            temp.FirstEntryDate = reader.ReadInt32();
            //メーカーコード
            temp.MakerCode = reader.ReadInt32();
            //メーカー全角名称
            temp.MakerFullName = reader.ReadString();
            //メーカー半角名称
            temp.MakerHalfName = reader.ReadString();
            //車種コード
            temp.ModelCode = reader.ReadInt32();
            //車種サブコード
            temp.ModelSubCode = reader.ReadInt32();
            //車種全角名称
            temp.ModelFullName = reader.ReadString();
            //車種半角名称
            temp.ModelHalfName = reader.ReadString();
            //系統コード
            temp.SystematicCode = reader.ReadInt32();
            //系統名称
            temp.SystematicName = reader.ReadString();
            //生産年式コード
            temp.ProduceTypeOfYearCd = reader.ReadInt32();
            //生産年式名称
            temp.ProduceTypeOfYearNm = reader.ReadString();
            //開始生産年式
            temp.StProduceTypeOfYear = new DateTime(reader.ReadInt64());
            //終了生産年式
            temp.EdProduceTypeOfYear = new DateTime(reader.ReadInt64());
            //ドア数
            temp.DoorCount = reader.ReadInt32();
            //ボディー名コード
            temp.BodyNameCode = reader.ReadInt32();
            //ボディー名称
            temp.BodyName = reader.ReadString();
            //排ガス記号
            temp.ExhaustGasSign = reader.ReadString();
            //シリーズ型式
            temp.SeriesModel = reader.ReadString();
            //型式（類別記号）
            temp.CategorySignModel = reader.ReadString();
            //型式（フル型）
            temp.FullModel = reader.ReadString();
            //型式指定番号
            temp.ModelDesignationNo = reader.ReadInt32();
            //類別番号
            temp.CategoryNo = reader.ReadInt32();
            //車台型式
            temp.FrameModel = reader.ReadString();
            //車台番号
            temp.FrameNo = reader.ReadString();
            //車台番号（検索用）
            temp.SearchFrameNo = reader.ReadInt32();
            //生産車台番号開始
            temp.StProduceFrameNo = reader.ReadInt32();
            //生産車台番号終了
            temp.EdProduceFrameNo = reader.ReadInt32();
            //原動機型式（エンジン）
            temp.EngineModel = reader.ReadString();
            //型式グレード名称
            temp.ModelGradeNm = reader.ReadString();
            //エンジン型式名称
            temp.EngineModelNm = reader.ReadString();
            //排気量名称
            temp.EngineDisplaceNm = reader.ReadString();
            //E区分名称
            temp.EDivNm = reader.ReadString();
            //ミッション名称
            temp.TransmissionNm = reader.ReadString();
            //シフト名称
            temp.ShiftNm = reader.ReadString();
            //駆動方式名称
            temp.WheelDriveMethodNm = reader.ReadString();
            //追加諸元1
            temp.AddiCarSpec1 = reader.ReadString();
            //追加諸元2
            temp.AddiCarSpec2 = reader.ReadString();
            //追加諸元3
            temp.AddiCarSpec3 = reader.ReadString();
            //追加諸元4
            temp.AddiCarSpec4 = reader.ReadString();
            //追加諸元5
            temp.AddiCarSpec5 = reader.ReadString();
            //追加諸元6
            temp.AddiCarSpec6 = reader.ReadString();
            //追加諸元タイトル1
            temp.AddiCarSpecTitle1 = reader.ReadString();
            //追加諸元タイトル2
            temp.AddiCarSpecTitle2 = reader.ReadString();
            //追加諸元タイトル3
            temp.AddiCarSpecTitle3 = reader.ReadString();
            //追加諸元タイトル4
            temp.AddiCarSpecTitle4 = reader.ReadString();
            //追加諸元タイトル5
            temp.AddiCarSpecTitle5 = reader.ReadString();
            //追加諸元タイトル6
            temp.AddiCarSpecTitle6 = reader.ReadString();
            //関連型式
            temp.RelevanceModel = reader.ReadString();
            //サブ車名コード
            temp.SubCarNmCd = reader.ReadInt32();
            //型式グレード略称
            temp.ModelGradeSname = reader.ReadString();
            //ブロックイラストコード
            temp.BlockIllustrationCd = reader.ReadInt32();
            //3DイラストNo
            temp.ThreeDIllustNo = reader.ReadInt32();
            //部品データ提供フラグ
            temp.PartsDataOfferFlag = reader.ReadInt32();
            //車検満期日
            temp.InspectMaturityDate = new DateTime(reader.ReadInt64());
            //前回車検満期日
            temp.LTimeCiMatDate = new DateTime(reader.ReadInt64());
            //車検期間
            temp.CarInspectYear = reader.ReadInt32();
            //車両走行距離
            temp.Mileage = reader.ReadInt32();
            // --- ADD 2009/09/08 ---------->>>>>
            //車輌備考
            temp.CarNote = reader.ReadString();
            // --- ADD 2009/09/08 ----------<<<<<
            //号車
            temp.CarNo = reader.ReadString();
            //カラーコード
            temp.ColorCode = reader.ReadString();
            //カラー名称1
            temp.ColorName1 = reader.ReadString();
            //トリムコード
            temp.TrimCode = reader.ReadString();
            //トリム名称
            temp.TrimName = reader.ReadString();
            //フル型式固定番号配列
            int length = reader.ReadInt32();
            temp.FullModelFixedNoAry = new int[length];
            for (int cnt = 0; cnt < length; cnt++)
                temp.FullModelFixedNoAry[cnt] = reader.ReadInt32();

            //装備オブジェクト配列
            length = reader.ReadInt32();
            temp.CategoryObjAry = reader.ReadBytes(length);

            //車両関連付けGUID
            int lenOfCarRelationGuidArray = reader.ReadInt32();
            byte[] carRelationGuidArray = reader.ReadBytes(lenOfCarRelationGuidArray);
            temp.CarRelationGuid = new Guid(carRelationGuidArray);

            // --- ADD 2009/09/11 ---------->>>>>
            //車輌追加情報１
            temp.CarAddInfo1 = reader.ReadString();
            //車輌追加情報２
            temp.CarAddInfo2 = reader.ReadString();
            //得意先名称
            temp.CustomerName = reader.ReadString();
            // --- ADD 2009/09/11 ----------<<<<<
            // --- ADD 2010/04/27 ---------->>>>>
            //自由検索型式固定番号配列
            length = reader.ReadInt32();
            temp.FreeSrchMdlFxdNoAry = reader.ReadBytes(length);
            // --- ADD 2010/04/27 ----------<<<<<
            // ADD 2013/03/22 -------------------->>>>>
            // 国産/外車区分
            temp.DomesticForeignCode = reader.ReadInt32();
            // ハンドル位置情報
            temp.HandleInfoCode = reader.ReadInt32();
            // ADD 2013/03/22 --------------------<<<<<
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
        /// <returns>CarManagementWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CarManagementWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                CarManagementWork temp = GetCarManagementWork(reader, serInfo);
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
                    retValue = (CarManagementWork[])lst.ToArray(typeof(CarManagementWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

    /// <summary>
    /// 車両管理データをキー順に並び替える
    /// </summary>
    public class CarManagementComparer : IComparer
    {
        /// <summary>
        /// 2 つのオブジェクトの明細関連付けGUIDを比較し、一方が他方より小さいか、等しいか、大きいかを示す値を返します。
        /// </summary>
        /// <param name="x">比較対象の第 1 オブジェクト</param>
        /// <param name="y">比較対象の第 2 オブジェクト</param>
        /// <returns>0 より小さい値: x が y より小さい。 0: x と y は等しい。 0 より大きい値: x が y より大きい値です。</returns>
        public int Compare(object x, object y)
        {
            Guid xGuid = Guid.Empty;
            Guid yGuid = Guid.Empty;

            if (x is CarManagementWork)
            {
                xGuid = (x as CarManagementWork).CarRelationGuid;
            }
            else if (x is Guid)
            {
                xGuid = (Guid)x;
            }

            if (y is CarManagementWork)
            {
                yGuid = (y as CarManagementWork).CarRelationGuid;
            }
            else if (y is Guid)
            {
                yGuid = (Guid)y;
            }

            return xGuid.CompareTo(yGuid);
        }
    }
}
