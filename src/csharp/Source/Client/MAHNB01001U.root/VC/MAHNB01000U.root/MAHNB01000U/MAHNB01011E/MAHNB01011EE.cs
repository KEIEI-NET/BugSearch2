using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   AcceptOdrCar
    /// <summary>
    ///                      受注マスタ（車両）
    /// </summary>
    /// <remarks>
    /// <br>note             :   受注マスタ（車両）ヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2008/4/24</br>
    /// <br>Genarated Date   :   2008/09/08  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2008/6/9  杉村</br>
    /// <br>                 :   項目追加</br>
    /// <br>                 :   フル型式固定番号配列</br>
    /// <br>Update Note      :   2008/6/23  長内</br>
    /// <br>                 :   ○項目追加</br>
    /// <br>                 :   車種半角名称</br>
    /// <br>                 :   メーカー半角名称</br>
    /// <br>Update Note      :   2008/6/30  長内</br>
    /// <br>                 :   ○項目追加</br>
    /// <br>                 :   装備オブジェクト配列</br>
    /// <br>Update Note      :   2008/09/08  張凱</br>
    /// <br>                 :   ○項目追加</br>
    /// <br>                 :   車輌備考</br>
    /// <br>Update Note      :   2010/04/27 gaoyh</br>
    /// <br>                 :   受注マスタ（車両）自由検索型式固定番号配列の追加対応</br>
    /// <br>Update Note      :   2012/05/31 30744 湯上 千加子</br>
    /// <br>                 :   障害No10277</br>
    /// <br>                 :   SCM受注データ(車両情報)装備情報の設定方法の変更</br>
    /// <br>Update Note      :   2013/03/21 FSI今野 利裕</br>
    /// <br>管理番号         :   10900269-00</br>
    /// <br>                     SPK車台番号文字列対応</br>   
    /// </remarks>
    public class AcceptOdrCar
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

        /// <summary>受注番号</summary>
        private Int32 _acceptAnOrderNo;

        /// <summary>受注ステータス</summary>
        /// <remarks>1:見積 2:発注 3:受注 4:入荷 5:出荷 6:仕入 7:売上 8:返品 9:入金 10:支払</remarks>
        private Int32 _acptAnOdrStatus;

        /// <summary>データ入力システム</summary>
        /// <remarks>0:共通,1:整備,2:鈑金,3:車販 10:PM,11:電装,12:硝子,13:RC </remarks>
        private Int32 _dataInputSystem;

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

        /// <summary>エンジン型式名称</summary>
        /// <remarks>エンジン検索</remarks>
        private string _engineModelNm = "";

        /// <summary>関連型式</summary>
        /// <remarks>リサイクル系で使用</remarks>
        private string _relevanceModel = "";

        /// <summary>サブ車名コード</summary>
        /// <remarks>リサイクル系で使用</remarks>
        private Int32 _subCarNmCd;

        /// <summary>型式グレード略称</summary>
        /// <remarks>リサイクル系で使用</remarks>
        private string _modelGradeSname = "";

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

        /// <summary>車両走行距離</summary>
        private Int32 _mileage;

        /// <summary>フル型式固定番号配列</summary>
        /// <remarks>フル型式固定連番の配列クラスを格納（再検索不要になる）</remarks>
        private Int32[] _fullModelFixedNoAry;

        /// <summary>装備オブジェクト配列</summary>
        private Byte[] _categoryObjAry;

        /// <summary>企業名称</summary>
        private string _enterpriseName = "";

        /// <summary>更新従業員名称</summary>
        private string _updEmployeeName = "";

        /// <summary>データ入力システム名称</summary>
        /// <remarks>共通,整備,鈑金,車販</remarks>
        private string _dataInputSystemName = "";

        /// <summary>カラー名称</summary>
        private string _colorName = "";

        // --- ADD 2009/09/08 ---------->>>>>
        /// <summary>車輌備考</summary>
        private string _carNote = "";
        // --- ADD 2009/09/08 ----------<<<<<

        // --- ADD 2010/04/27 ---------->>>>>
        /// <summary>自由検索型式固定番号配列</summary>
        /// <remarks>自由検索シリアル№の配列クラスを格納（再検索不要になる）</remarks>
        private string[] _freeSrchMdlFxdNoAry = new string[0];
        // --- ADD 2010/04/27 ----------<<<<<

        // --- ADD 2012/05/31 ---------->>>>>
        /// <summary>初年度（NUMタイプ）</summary>
        private Int32 _firstEntryDateNumTyp;
        /// <summary>車両付加情報オブジェクト</summary>
        private Byte[] _carAddInf;
        /// <summary>装備部品オブジェクト</summary>
        private Byte[] _equipPrtsObj;
        // --- ADD 2012/05/31 ----------<<<<<

        // PMNS:国産/外車区分 列追加
        // --- ADD 2013/03/21 ---------->>>>>
        /// <summary>国産/外車区分</summary>
        private int _domesticForeignCode;
        // --- ADD 2013/03/21 ----------<<<<<

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

        /// public propaty name  :  AcceptAnOrderNo
        /// <summary>受注番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   受注番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AcceptAnOrderNo
        {
            get { return _acceptAnOrderNo; }
            set { _acceptAnOrderNo = value; }
        }

        /// public propaty name  :  AcptAnOdrStatus
        /// <summary>受注ステータスプロパティ</summary>
        /// <value>1:見積 2:発注 3:受注 4:入荷 5:出荷 6:仕入 7:売上 8:返品 9:入金 10:支払</value>
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

        /// public propaty name  :  DataInputSystem
        /// <summary>データ入力システムプロパティ</summary>
        /// <value>0:共通,1:整備,2:鈑金,3:車販 10:PM,11:電装,12:硝子,13:RC </value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   データ入力システムプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DataInputSystem
        {
            get { return _dataInputSystem; }
            set { _dataInputSystem = value; }
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

        // --- UPD 2009/09/08 ---------->>>>>
        ///// public propaty name  :  FirstEntryDateJpFormal
        ///// <summary>初年度 和暦プロパティ</summary>
        ///// <value>YYYYMM</value>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   初年度 和暦プロパティ</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public string FirstEntryDateJpFormal
        //{
        //    get { return TDateTime.DateTimeToString("GGYYMM", _firstEntryDate); }
        //    set { }
        //}

        ///// public propaty name  :  FirstEntryDateJpInFormal
        ///// <summary>初年度 和暦(略)プロパティ</summary>
        ///// <value>YYYYMM</value>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   初年度 和暦(略)プロパティ</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public string FirstEntryDateJpInFormal
        //{
        //    get { return TDateTime.DateTimeToString("ggYY/MM", _firstEntryDate); }
        //    set { }
        //}

        ///// public propaty name  :  FirstEntryDateAdFormal
        ///// <summary>初年度 西暦プロパティ</summary>
        ///// <value>YYYYMM</value>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   初年度 西暦プロパティ</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public string FirstEntryDateAdFormal
        //{
        //    get { return TDateTime.DateTimeToString("YYYY/MM", _firstEntryDate); }
        //    set { }
        //}

        ///// public propaty name  :  FirstEntryDateAdInFormal
        ///// <summary>初年度 西暦(略)プロパティ</summary>
        ///// <value>YYYYMM</value>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   初年度 西暦(略)プロパティ</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public string FirstEntryDateAdInFormal
        //{
        //    get { return TDateTime.DateTimeToString("YY/MM", _firstEntryDate); }
        //    set { }
        //}

        // --- UPD 2009/09/08 ----------<<<<<

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

        /// public propaty name  :  EngineModelNm
        /// <summary>エンジン型式名称プロパティ</summary>
        /// <value>エンジン検索</value>
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

        /// public propaty name  :  DataInputSystemName
        /// <summary>データ入力システム名称プロパティ</summary>
        /// <value>共通,整備,鈑金,車販</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   データ入力システム名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DataInputSystemName
        {
            get { return _dataInputSystemName; }
            set { _dataInputSystemName = value; }
        }

        /// public propaty name  :  ColorName
        /// <summary>カラー名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   カラー名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ColorName
        {
            get { return _colorName; }
            set { _colorName = value; }
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

        // --- ADD 2010/04/27 ---------->>>>>
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
        // --- ADD 2010/04/27 ----------<<<<
        // --- ADD 2012/05/31 ---------->>>>>
        /// public propaty name  : FirstEntryDateNumTyp
        /// <summary>初年度（NUMタイプ）</summary>
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

        /// public propaty name  : CarAddInf
        /// <summary>車両付加情報オブジェクト</summary>
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

        /// public propaty name  : EquipPrtsObj
        /// <summary>装備部品オブジェクト</summary>
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
        // --- ADD 2012/05/31 ----------<<<<<

        // PMNS:国産/外車区分 列追加
        // --- ADD 2013/03/21 ---------->>>>>
        /// public propaty name  :  DomesticForeignCode
        /// <summary>国産/外車区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   国産/外車区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public int DomesticForeignCode
        {
            get { return _domesticForeignCode; }
            set { _domesticForeignCode = value; }
        }
        // --- ADD 2013/03/21 ----------<<<<<

        /// <summary>
        /// 受注マスタ（車両）コンストラクタ
        /// </summary>
        /// <returns>AcceptOdrCarクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   AcceptOdrCarクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public AcceptOdrCar()
        {
        }

        /// <summary>
        /// 受注マスタ（車両）コンストラクタ
        /// </summary>
        /// <param name="createDateTime">作成日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="updateDateTime">更新日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
        /// <param name="fileHeaderGuid">GUID(共通ファイルヘッダ)</param>
        /// <param name="updEmployeeCode">更新従業員コード(共通ファイルヘッダ)</param>
        /// <param name="updAssemblyId1">更新アセンブリID1(共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）)</param>
        /// <param name="updAssemblyId2">更新アセンブリID2(共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）)</param>
        /// <param name="logicalDeleteCode">論理削除区分(共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除))</param>
        /// <param name="acceptAnOrderNo">受注番号</param>
        /// <param name="acptAnOdrStatus">受注ステータス(1:見積 2:発注 3:受注 4:入荷 5:出荷 6:仕入 7:売上 8:返品 9:入金 10:支払)</param>
        /// <param name="dataInputSystem">データ入力システム(0:共通,1:整備,2:鈑金,3:車販 10:PM,11:電装,12:硝子,13:RC )</param>
        /// <param name="carMngNo">車両管理番号(自動採番（無重複のシーケンス）PM7での車両SEQ)</param>
        /// <param name="carMngCode">車輌管理コード(※PM7での車両管理番号)</param>
        /// <param name="numberPlate1Code">陸運事務所番号</param>
        /// <param name="numberPlate1Name">陸運事務局名称</param>
        /// <param name="numberPlate2">車両登録番号（種別）</param>
        /// <param name="numberPlate3">車両登録番号（カナ）</param>
        /// <param name="numberPlate4">車両登録番号（プレート番号）</param>
        /// <param name="firstEntryDate">初年度(YYYYMM)</param>
        /// <param name="makerCode">メーカーコード(1～899:提供分, 900～ユーザー登録)</param>
        /// <param name="makerFullName">メーカー全角名称(正式名称（カナ漢字混在で全角管理）)</param>
        /// <param name="makerHalfName">メーカー半角名称(正式名称（半角で管理）)</param>
        /// <param name="modelCode">車種コード(車名コード(翼) 1～899:提供分, 900～ユーザー登録)</param>
        /// <param name="modelSubCode">車種サブコード(0～899:提供分,900～ﾕｰｻﾞｰ登録)</param>
        /// <param name="modelFullName">車種全角名称(正式名称（カナ漢字混在で全角管理）)</param>
        /// <param name="modelHalfName">車種半角名称(正式名称（半角で管理）)</param>
        /// <param name="exhaustGasSign">排ガス記号</param>
        /// <param name="seriesModel">シリーズ型式</param>
        /// <param name="categorySignModel">型式（類別記号）</param>
        /// <param name="fullModel">型式（フル型）(フル型式(44桁用))</param>
        /// <param name="modelDesignationNo">型式指定番号</param>
        /// <param name="categoryNo">類別番号</param>
        /// <param name="frameModel">車台型式</param>
        /// <param name="frameNo">車台番号(車検証記載フォーマット対応（ HCR32-100251584 等）)</param>
        /// <param name="searchFrameNo">車台番号（検索用）(PM7の車台番号と同意)</param>
        /// <param name="engineModelNm">エンジン型式名称(エンジン検索)</param>
        /// <param name="relevanceModel">関連型式(リサイクル系で使用)</param>
        /// <param name="subCarNmCd">サブ車名コード(リサイクル系で使用)</param>
        /// <param name="modelGradeSname">型式グレード略称(リサイクル系で使用)</param>
        /// <param name="colorCode">カラーコード(カタログの色コード)</param>
        /// <param name="colorName1">カラー名称1(画面表示用正式名称)</param>
        /// <param name="trimCode">トリムコード</param>
        /// <param name="trimName">トリム名称</param>
        /// <param name="mileage">車両走行距離</param>
        /// <param name="fullModelFixedNoAry">フル型式固定番号配列(フル型式固定連番の配列クラスを格納（再検索不要になる）)</param>
        /// <param name="categoryObjAry">装備オブジェクト配列</param>
        /// <param name="enterpriseName">企業名称</param>
        /// <param name="updEmployeeName">更新従業員名称</param>
        /// <param name="dataInputSystemName">データ入力システム名称(共通,整備,鈑金,車販)</param>
        /// <param name="colorName">カラー名称</param>
        /// <param name="carNote">車輌備考</param>
        /// <param name="freeSrchMdlFxdNoAry"></param>
        /// <returns>AcceptOdrCarクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   AcceptOdrCarクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        //public AcceptOdrCar(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 acceptAnOrderNo, Int32 acptAnOdrStatus, Int32 dataInputSystem, Int32 carMngNo, string carMngCode, Int32 numberPlate1Code, string numberPlate1Name, string numberPlate2, string numberPlate3, Int32 numberPlate4, Int32 firstEntryDate, Int32 makerCode, string makerFullName, string makerHalfName, Int32 modelCode, Int32 modelSubCode, string modelFullName, string modelHalfName, string exhaustGasSign, string seriesModel, string categorySignModel, string fullModel, Int32 modelDesignationNo, Int32 categoryNo, string frameModel, string frameNo, Int32 searchFrameNo, string engineModelNm, string relevanceModel, Int32 subCarNmCd, string modelGradeSname, string colorCode, string colorName1, string trimCode, string trimName, Int32 mileage, Int32[] fullModelFixedNoAry, Byte[] categoryObjAry, string enterpriseName, string updEmployeeName, string dataInputSystemName, string colorName, string carNote) // DEL 2010/04/27
        // --- UPD 2012/05/31 ---------->>>>>
        //public AcceptOdrCar(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 acceptAnOrderNo, Int32 acptAnOdrStatus, Int32 dataInputSystem, Int32 carMngNo, string carMngCode, Int32 numberPlate1Code, string numberPlate1Name, string numberPlate2, string numberPlate3, Int32 numberPlate4, Int32 firstEntryDate, Int32 makerCode, string makerFullName, string makerHalfName, Int32 modelCode, Int32 modelSubCode, string modelFullName, string modelHalfName, string exhaustGasSign, string seriesModel, string categorySignModel, string fullModel, Int32 modelDesignationNo, Int32 categoryNo, string frameModel, string frameNo, Int32 searchFrameNo, string engineModelNm, string relevanceModel, Int32 subCarNmCd, string modelGradeSname, string colorCode, string colorName1, string trimCode, string trimName, Int32 mileage, Int32[] fullModelFixedNoAry, Byte[] categoryObjAry, string enterpriseName, string updEmployeeName, string dataInputSystemName, string colorName, string carNote, string[] freeSrchMdlFxdNoAry) // ADD 2010/04/27
        // --- UPD 2013/03/21 ---------->>>>>
        //public AcceptOdrCar(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 acceptAnOrderNo, Int32 acptAnOdrStatus, Int32 dataInputSystem, Int32 carMngNo, string carMngCode, Int32 numberPlate1Code, string numberPlate1Name, string numberPlate2, string numberPlate3, Int32 numberPlate4, Int32 firstEntryDate, Int32 makerCode, string makerFullName, string makerHalfName, Int32 modelCode, Int32 modelSubCode, string modelFullName, string modelHalfName, string exhaustGasSign, string seriesModel, string categorySignModel, string fullModel, Int32 modelDesignationNo, Int32 categoryNo, string frameModel, string frameNo, Int32 searchFrameNo, string engineModelNm, string relevanceModel, Int32 subCarNmCd, string modelGradeSname, string colorCode, string colorName1, string trimCode, string trimName, Int32 mileage, Int32[] fullModelFixedNoAry, Byte[] categoryObjAry, string enterpriseName, string updEmployeeName, string dataInputSystemName, string colorName, string carNote, string[] freeSrchMdlFxdNoAry, int firstEntryDateNumTypm, Byte[] carAddInf, Byte[] equipPrtsObj)
        public AcceptOdrCar(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 acceptAnOrderNo, Int32 acptAnOdrStatus, Int32 dataInputSystem, Int32 carMngNo, string carMngCode, Int32 numberPlate1Code, string numberPlate1Name, string numberPlate2, string numberPlate3, Int32 numberPlate4, Int32 firstEntryDate, Int32 makerCode, string makerFullName, string makerHalfName, Int32 modelCode, Int32 modelSubCode, string modelFullName, string modelHalfName, string exhaustGasSign, string seriesModel, string categorySignModel, string fullModel, Int32 modelDesignationNo, Int32 categoryNo, string frameModel, string frameNo, Int32 searchFrameNo, string engineModelNm, string relevanceModel, Int32 subCarNmCd, string modelGradeSname, string colorCode, string colorName1, string trimCode, string trimName, Int32 mileage, Int32[] fullModelFixedNoAry, Byte[] categoryObjAry, string enterpriseName, string updEmployeeName, string dataInputSystemName, string colorName, string carNote, string[] freeSrchMdlFxdNoAry, int firstEntryDateNumTypm, Byte[] carAddInf, Byte[] equipPrtsObj, int domesticForeignCode)
        // --- UPD 2013/03/21 ----------<<<<<
        // --- UPD 2012/05/31 ----------<<<<<
        {
            this.CreateDateTime = createDateTime;
            this.UpdateDateTime = updateDateTime;
            this._enterpriseCode = enterpriseCode;
            this._fileHeaderGuid = fileHeaderGuid;
            this._updEmployeeCode = updEmployeeCode;
            this._updAssemblyId1 = updAssemblyId1;
            this._updAssemblyId2 = updAssemblyId2;
            this._logicalDeleteCode = logicalDeleteCode;
            this._acceptAnOrderNo = acceptAnOrderNo;
            this._acptAnOdrStatus = acptAnOdrStatus;
            this._dataInputSystem = dataInputSystem;
            this._carMngNo = carMngNo;
            this._carMngCode = carMngCode;
            this._numberPlate1Code = numberPlate1Code;
            this._numberPlate1Name = numberPlate1Name;
            this._numberPlate2 = numberPlate2;
            this._numberPlate3 = numberPlate3;
            this._numberPlate4 = numberPlate4;
            this.FirstEntryDate = firstEntryDate;
            this._makerCode = makerCode;
            this._makerFullName = makerFullName;
            this._makerHalfName = makerHalfName;
            this._modelCode = modelCode;
            this._modelSubCode = modelSubCode;
            this._modelFullName = modelFullName;
            this._modelHalfName = modelHalfName;
            this._exhaustGasSign = exhaustGasSign;
            this._seriesModel = seriesModel;
            this._categorySignModel = categorySignModel;
            this._fullModel = fullModel;
            this._modelDesignationNo = modelDesignationNo;
            this._categoryNo = categoryNo;
            this._frameModel = frameModel;
            this._frameNo = frameNo;
            this._searchFrameNo = searchFrameNo;
            this._engineModelNm = engineModelNm;
            this._relevanceModel = relevanceModel;
            this._subCarNmCd = subCarNmCd;
            this._modelGradeSname = modelGradeSname;
            this._colorCode = colorCode;
            this._colorName1 = colorName1;
            this._trimCode = trimCode;
            this._trimName = trimName;
            this._mileage = mileage;
            this._fullModelFixedNoAry = fullModelFixedNoAry;
            this._categoryObjAry = categoryObjAry;
            this._enterpriseName = enterpriseName;
            this._updEmployeeName = updEmployeeName;
            this._dataInputSystemName = dataInputSystemName;
            this._colorName = colorName;
            this._carNote = CarNote;
            this._freeSrchMdlFxdNoAry = freeSrchMdlFxdNoAry; // ADD 2010/04/27
            // --- ADD 2012/05/31 ---------->>>>>
            this._firstEntryDateNumTyp = FirstEntryDateNumTyp;
            this._carAddInf = carAddInf;
            this._equipPrtsObj = EquipPrtsObj;
            // --- ADD 2012/05/31 ----------<<<<<
            // --- ADD 2013/03/21 ---------->>>>>
            this._domesticForeignCode = domesticForeignCode;
            // --- ADD 2013/03/21 ----------<<<<<
        }

        /// <summary>
        /// 受注マスタ（車両）複製処理
        /// </summary>
        /// <returns>AcceptOdrCarクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいAcceptOdrCarクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public AcceptOdrCar Clone()
        {
            //return new AcceptOdrCar(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._acceptAnOrderNo, this._acptAnOdrStatus, this._dataInputSystem, this._carMngNo, this._carMngCode, this._numberPlate1Code, this._numberPlate1Name, this._numberPlate2, this._numberPlate3, this._numberPlate4, this._firstEntryDate, this._makerCode, this._makerFullName, this._makerHalfName, this._modelCode, this._modelSubCode, this._modelFullName, this._modelHalfName, this._exhaustGasSign, this._seriesModel, this._categorySignModel, this._fullModel, this._modelDesignationNo, this._categoryNo, this._frameModel, this._frameNo, this._searchFrameNo, this._engineModelNm, this._relevanceModel, this._subCarNmCd, this._modelGradeSname, this._colorCode, this._colorName1, this._trimCode, this._trimName, this._mileage, this._fullModelFixedNoAry, this._categoryObjAry, this._enterpriseName, this._updEmployeeName, this._dataInputSystemName, this._colorName, this._carNote); // DEL 2010/04/27
            // --- UPD 2012/05/31 ---------->>>>>
            //return new AcceptOdrCar(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._acceptAnOrderNo, this._acptAnOdrStatus, this._dataInputSystem, this._carMngNo, this._carMngCode, this._numberPlate1Code, this._numberPlate1Name, this._numberPlate2, this._numberPlate3, this._numberPlate4, this._firstEntryDate, this._makerCode, this._makerFullName, this._makerHalfName, this._modelCode, this._modelSubCode, this._modelFullName, this._modelHalfName, this._exhaustGasSign, this._seriesModel, this._categorySignModel, this._fullModel, this._modelDesignationNo, this._categoryNo, this._frameModel, this._frameNo, this._searchFrameNo, this._engineModelNm, this._relevanceModel, this._subCarNmCd, this._modelGradeSname, this._colorCode, this._colorName1, this._trimCode, this._trimName, this._mileage, this._fullModelFixedNoAry, this._categoryObjAry, this._enterpriseName, this._updEmployeeName, this._dataInputSystemName, this._colorName, this._carNote, this._freeSrchMdlFxdNoAry); // ADD 2010/04/27
            // --- UPD 2013/03/21 ---------->>>>>
            //return new AcceptOdrCar(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._acceptAnOrderNo, this._acptAnOdrStatus, this._dataInputSystem, this._carMngNo, this._carMngCode, this._numberPlate1Code, this._numberPlate1Name, this._numberPlate2, this._numberPlate3, this._numberPlate4, this._firstEntryDate, this._makerCode, this._makerFullName, this._makerHalfName, this._modelCode, this._modelSubCode, this._modelFullName, this._modelHalfName, this._exhaustGasSign, this._seriesModel, this._categorySignModel, this._fullModel, this._modelDesignationNo, this._categoryNo, this._frameModel, this._frameNo, this._searchFrameNo, this._engineModelNm, this._relevanceModel, this._subCarNmCd, this._modelGradeSname, this._colorCode, this._colorName1, this._trimCode, this._trimName, this._mileage, this._fullModelFixedNoAry, this._categoryObjAry, this._enterpriseName, this._updEmployeeName, this._dataInputSystemName, this._colorName, this._carNote, this._freeSrchMdlFxdNoAry, this._firstEntryDateNumTyp, this._carAddInf, this._equipPrtsObj);
            return new AcceptOdrCar(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._acceptAnOrderNo, this._acptAnOdrStatus, this._dataInputSystem, this._carMngNo, this._carMngCode, this._numberPlate1Code, this._numberPlate1Name, this._numberPlate2, this._numberPlate3, this._numberPlate4, this._firstEntryDate, this._makerCode, this._makerFullName, this._makerHalfName, this._modelCode, this._modelSubCode, this._modelFullName, this._modelHalfName, this._exhaustGasSign, this._seriesModel, this._categorySignModel, this._fullModel, this._modelDesignationNo, this._categoryNo, this._frameModel, this._frameNo, this._searchFrameNo, this._engineModelNm, this._relevanceModel, this._subCarNmCd, this._modelGradeSname, this._colorCode, this._colorName1, this._trimCode, this._trimName, this._mileage, this._fullModelFixedNoAry, this._categoryObjAry, this._enterpriseName, this._updEmployeeName, this._dataInputSystemName, this._colorName, this._carNote, this._freeSrchMdlFxdNoAry, this._firstEntryDateNumTyp, this._carAddInf, this._equipPrtsObj, this._domesticForeignCode);
            // --- UPD 2013/03/21 ----------<<<<<
            // --- UPD 2012/05/31 ----------<<<<<
        }

        /// <summary>
        /// 受注マスタ（車両）比較処理
        /// </summary>
        /// <param name="target">比較対象のAcceptOdrCarクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   AcceptOdrCarクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool Equals(AcceptOdrCar target)
        {
            return ((this.CreateDateTime == target.CreateDateTime)
                 && (this.UpdateDateTime == target.UpdateDateTime)
                 && (this.EnterpriseCode == target.EnterpriseCode)
                 && (this.FileHeaderGuid == target.FileHeaderGuid)
                 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
                 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
                 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
                 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
                 && (this.AcceptAnOrderNo == target.AcceptAnOrderNo)
                 && (this.AcptAnOdrStatus == target.AcptAnOdrStatus)
                 && (this.DataInputSystem == target.DataInputSystem)
                 && (this.CarMngNo == target.CarMngNo)
                 && (this.CarMngCode == target.CarMngCode)
                 && (this.NumberPlate1Code == target.NumberPlate1Code)
                 && (this.NumberPlate1Name == target.NumberPlate1Name)
                 && (this.NumberPlate2 == target.NumberPlate2)
                 && (this.NumberPlate3 == target.NumberPlate3)
                 && (this.NumberPlate4 == target.NumberPlate4)
                 && (this.FirstEntryDate == target.FirstEntryDate)
                 && (this.MakerCode == target.MakerCode)
                 && (this.MakerFullName == target.MakerFullName)
                 && (this.MakerHalfName == target.MakerHalfName)
                 && (this.ModelCode == target.ModelCode)
                 && (this.ModelSubCode == target.ModelSubCode)
                 && (this.ModelFullName == target.ModelFullName)
                 && (this.ModelHalfName == target.ModelHalfName)
                 && (this.ExhaustGasSign == target.ExhaustGasSign)
                 && (this.SeriesModel == target.SeriesModel)
                 && (this.CategorySignModel == target.CategorySignModel)
                 && (this.FullModel == target.FullModel)
                 && (this.ModelDesignationNo == target.ModelDesignationNo)
                 && (this.CategoryNo == target.CategoryNo)
                 && (this.FrameModel == target.FrameModel)
                 && (this.FrameNo == target.FrameNo)
                 && (this.SearchFrameNo == target.SearchFrameNo)
                 && (this.EngineModelNm == target.EngineModelNm)
                 && (this.RelevanceModel == target.RelevanceModel)
                 && (this.SubCarNmCd == target.SubCarNmCd)
                 && (this.ModelGradeSname == target.ModelGradeSname)
                 && (this.ColorCode == target.ColorCode)
                 && (this.ColorName1 == target.ColorName1)
                 && (this.TrimCode == target.TrimCode)
                 && (this.TrimName == target.TrimName)
                 && (this.Mileage == target.Mileage)
                 && (this.FullModelFixedNoAry == target.FullModelFixedNoAry)
                 && (this.CategoryObjAry == target.CategoryObjAry)
                 && (this.EnterpriseName == target.EnterpriseName)
                 && (this.UpdEmployeeName == target.UpdEmployeeName)
                 && (this.DataInputSystemName == target.DataInputSystemName)
                 && (this.ColorName == target.ColorName)
                 && (this.CarNote == target.CarNote)
                 && (this._freeSrchMdlFxdNoAry == target.FreeSrchMdlFxdNoAry) // ADD 2010/04/27
                // --- ADD 2012/05/31 ---------->>>>>
                 && (this.FirstEntryDateNumTyp == target.FirstEntryDateNumTyp)
                 && (this.CarAddInf == target.CarAddInf)
                 && (this.EquipPrtsObj == target.EquipPrtsObj)
                // --- ADD 2012/05/31 ----------<<<<<
            );
        }

        /// <summary>
        /// 受注マスタ（車両）比較処理
        /// </summary>
        /// <param name="acceptOdrCar1">
        ///                    比較するAcceptOdrCarクラスのインスタンス
        /// </param>
        /// <param name="acceptOdrCar2">比較するAcceptOdrCarクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   AcceptOdrCarクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static bool Equals(AcceptOdrCar acceptOdrCar1, AcceptOdrCar acceptOdrCar2)
        {
            return ((acceptOdrCar1.CreateDateTime == acceptOdrCar2.CreateDateTime)
                 && (acceptOdrCar1.UpdateDateTime == acceptOdrCar2.UpdateDateTime)
                 && (acceptOdrCar1.EnterpriseCode == acceptOdrCar2.EnterpriseCode)
                 && (acceptOdrCar1.FileHeaderGuid == acceptOdrCar2.FileHeaderGuid)
                 && (acceptOdrCar1.UpdEmployeeCode == acceptOdrCar2.UpdEmployeeCode)
                 && (acceptOdrCar1.UpdAssemblyId1 == acceptOdrCar2.UpdAssemblyId1)
                 && (acceptOdrCar1.UpdAssemblyId2 == acceptOdrCar2.UpdAssemblyId2)
                 && (acceptOdrCar1.LogicalDeleteCode == acceptOdrCar2.LogicalDeleteCode)
                 && (acceptOdrCar1.AcceptAnOrderNo == acceptOdrCar2.AcceptAnOrderNo)
                 && (acceptOdrCar1.AcptAnOdrStatus == acceptOdrCar2.AcptAnOdrStatus)
                 && (acceptOdrCar1.DataInputSystem == acceptOdrCar2.DataInputSystem)
                 && (acceptOdrCar1.CarMngNo == acceptOdrCar2.CarMngNo)
                 && (acceptOdrCar1.CarMngCode == acceptOdrCar2.CarMngCode)
                 && (acceptOdrCar1.NumberPlate1Code == acceptOdrCar2.NumberPlate1Code)
                 && (acceptOdrCar1.NumberPlate1Name == acceptOdrCar2.NumberPlate1Name)
                 && (acceptOdrCar1.NumberPlate2 == acceptOdrCar2.NumberPlate2)
                 && (acceptOdrCar1.NumberPlate3 == acceptOdrCar2.NumberPlate3)
                 && (acceptOdrCar1.NumberPlate4 == acceptOdrCar2.NumberPlate4)
                 && (acceptOdrCar1.FirstEntryDate == acceptOdrCar2.FirstEntryDate)
                 && (acceptOdrCar1.MakerCode == acceptOdrCar2.MakerCode)
                 && (acceptOdrCar1.MakerFullName == acceptOdrCar2.MakerFullName)
                 && (acceptOdrCar1.MakerHalfName == acceptOdrCar2.MakerHalfName)
                 && (acceptOdrCar1.ModelCode == acceptOdrCar2.ModelCode)
                 && (acceptOdrCar1.ModelSubCode == acceptOdrCar2.ModelSubCode)
                 && (acceptOdrCar1.ModelFullName == acceptOdrCar2.ModelFullName)
                 && (acceptOdrCar1.ModelHalfName == acceptOdrCar2.ModelHalfName)
                 && (acceptOdrCar1.ExhaustGasSign == acceptOdrCar2.ExhaustGasSign)
                 && (acceptOdrCar1.SeriesModel == acceptOdrCar2.SeriesModel)
                 && (acceptOdrCar1.CategorySignModel == acceptOdrCar2.CategorySignModel)
                 && (acceptOdrCar1.FullModel == acceptOdrCar2.FullModel)
                 && (acceptOdrCar1.ModelDesignationNo == acceptOdrCar2.ModelDesignationNo)
                 && (acceptOdrCar1.CategoryNo == acceptOdrCar2.CategoryNo)
                 && (acceptOdrCar1.FrameModel == acceptOdrCar2.FrameModel)
                 && (acceptOdrCar1.FrameNo == acceptOdrCar2.FrameNo)
                 && (acceptOdrCar1.SearchFrameNo == acceptOdrCar2.SearchFrameNo)
                 && (acceptOdrCar1.EngineModelNm == acceptOdrCar2.EngineModelNm)
                 && (acceptOdrCar1.RelevanceModel == acceptOdrCar2.RelevanceModel)
                 && (acceptOdrCar1.SubCarNmCd == acceptOdrCar2.SubCarNmCd)
                 && (acceptOdrCar1.ModelGradeSname == acceptOdrCar2.ModelGradeSname)
                 && (acceptOdrCar1.ColorCode == acceptOdrCar2.ColorCode)
                 && (acceptOdrCar1.ColorName1 == acceptOdrCar2.ColorName1)
                 && (acceptOdrCar1.TrimCode == acceptOdrCar2.TrimCode)
                 && (acceptOdrCar1.TrimName == acceptOdrCar2.TrimName)
                 && (acceptOdrCar1.Mileage == acceptOdrCar2.Mileage)
                 && (acceptOdrCar1.FullModelFixedNoAry == acceptOdrCar2.FullModelFixedNoAry)
                 && (acceptOdrCar1.CategoryObjAry == acceptOdrCar2.CategoryObjAry)
                 && (acceptOdrCar1.EnterpriseName == acceptOdrCar2.EnterpriseName)
                 && (acceptOdrCar1.UpdEmployeeName == acceptOdrCar2.UpdEmployeeName)
                 && (acceptOdrCar1.DataInputSystemName == acceptOdrCar2.DataInputSystemName)
                 && (acceptOdrCar1.ColorName == acceptOdrCar2.ColorName)
                 && (acceptOdrCar1.CarNote == acceptOdrCar2.CarNote)
                 && (acceptOdrCar1.FreeSrchMdlFxdNoAry == acceptOdrCar2.FreeSrchMdlFxdNoAry) // ADD 2010/04/27
                // --- ADD 2012/05/31 ---------->>>>>
                 && (acceptOdrCar1.FirstEntryDateNumTyp == acceptOdrCar2.FirstEntryDateNumTyp)
                 && (acceptOdrCar1.CarAddInf == acceptOdrCar2.CarAddInf)
                 && (acceptOdrCar1.EquipPrtsObj == acceptOdrCar2.EquipPrtsObj)
                // --- ADD 2012/05/31 ----------<<<<<
            );
        }
        /// <summary>
        /// 受注マスタ（車両）比較処理
        /// </summary>
        /// <param name="target">比較対象のAcceptOdrCarクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   AcceptOdrCarクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList Compare(AcceptOdrCar target)
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
            if (this.AcceptAnOrderNo != target.AcceptAnOrderNo) resList.Add("AcceptAnOrderNo");
            if (this.AcptAnOdrStatus != target.AcptAnOdrStatus) resList.Add("AcptAnOdrStatus");
            if (this.DataInputSystem != target.DataInputSystem) resList.Add("DataInputSystem");
            if (this.CarMngNo != target.CarMngNo) resList.Add("CarMngNo");
            if (this.CarMngCode != target.CarMngCode) resList.Add("CarMngCode");
            if (this.NumberPlate1Code != target.NumberPlate1Code) resList.Add("NumberPlate1Code");
            if (this.NumberPlate1Name != target.NumberPlate1Name) resList.Add("NumberPlate1Name");
            if (this.NumberPlate2 != target.NumberPlate2) resList.Add("NumberPlate2");
            if (this.NumberPlate3 != target.NumberPlate3) resList.Add("NumberPlate3");
            if (this.NumberPlate4 != target.NumberPlate4) resList.Add("NumberPlate4");
            if (this.FirstEntryDate != target.FirstEntryDate) resList.Add("FirstEntryDate");
            if (this.MakerCode != target.MakerCode) resList.Add("MakerCode");
            if (this.MakerFullName != target.MakerFullName) resList.Add("MakerFullName");
            if (this.MakerHalfName != target.MakerHalfName) resList.Add("MakerHalfName");
            if (this.ModelCode != target.ModelCode) resList.Add("ModelCode");
            if (this.ModelSubCode != target.ModelSubCode) resList.Add("ModelSubCode");
            if (this.ModelFullName != target.ModelFullName) resList.Add("ModelFullName");
            if (this.ModelHalfName != target.ModelHalfName) resList.Add("ModelHalfName");
            if (this.ExhaustGasSign != target.ExhaustGasSign) resList.Add("ExhaustGasSign");
            if (this.SeriesModel != target.SeriesModel) resList.Add("SeriesModel");
            if (this.CategorySignModel != target.CategorySignModel) resList.Add("CategorySignModel");
            if (this.FullModel != target.FullModel) resList.Add("FullModel");
            if (this.ModelDesignationNo != target.ModelDesignationNo) resList.Add("ModelDesignationNo");
            if (this.CategoryNo != target.CategoryNo) resList.Add("CategoryNo");
            if (this.FrameModel != target.FrameModel) resList.Add("FrameModel");
            if (this.FrameNo != target.FrameNo) resList.Add("FrameNo");
            if (this.SearchFrameNo != target.SearchFrameNo) resList.Add("SearchFrameNo");
            if (this.EngineModelNm != target.EngineModelNm) resList.Add("EngineModelNm");
            if (this.RelevanceModel != target.RelevanceModel) resList.Add("RelevanceModel");
            if (this.SubCarNmCd != target.SubCarNmCd) resList.Add("SubCarNmCd");
            if (this.ModelGradeSname != target.ModelGradeSname) resList.Add("ModelGradeSname");
            if (this.ColorCode != target.ColorCode) resList.Add("ColorCode");
            if (this.ColorName1 != target.ColorName1) resList.Add("ColorName1");
            if (this.TrimCode != target.TrimCode) resList.Add("TrimCode");
            if (this.TrimName != target.TrimName) resList.Add("TrimName");
            if (this.Mileage != target.Mileage) resList.Add("Mileage");
            if (this.FullModelFixedNoAry != target.FullModelFixedNoAry) resList.Add("FullModelFixedNoAry");
            if (this.CategoryObjAry != target.CategoryObjAry) resList.Add("CategoryObjAry");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            if (this.UpdEmployeeName != target.UpdEmployeeName) resList.Add("UpdEmployeeName");
            if (this.DataInputSystemName != target.DataInputSystemName) resList.Add("DataInputSystemName");
            if (this.ColorName != target.ColorName) resList.Add("ColorName");
            if (this.CarNote != target.CarNote) resList.Add("CarNote");
            if (this._freeSrchMdlFxdNoAry != target.FreeSrchMdlFxdNoAry) resList.Add("FreeSrchMdlFxdNoAry"); // ADD 2010/04/27
            // --- ADD 2012/05/31 ---------->>>>>
            if (this.FirstEntryDateNumTyp != target.FirstEntryDateNumTyp) resList.Add("FirstEntryDateNumTyp");
            if (this.CarAddInf != target.CarAddInf) resList.Add("CarAddInf");
            if (this.EquipPrtsObj != target.EquipPrtsObj) resList.Add("EquipPrtsObj");
            // --- ADD 2012/05/31 ----------<<<<<

            return resList;
        }

        /// <summary>
        /// 受注マスタ（車両）比較処理
        /// </summary>
        /// <param name="acceptOdrCar1">比較するAcceptOdrCarクラスのインスタンス</param>
        /// <param name="acceptOdrCar2">比較するAcceptOdrCarクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   AcceptOdrCarクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static ArrayList Compare(AcceptOdrCar acceptOdrCar1, AcceptOdrCar acceptOdrCar2)
        {
            ArrayList resList = new ArrayList();
            if (acceptOdrCar1.CreateDateTime != acceptOdrCar2.CreateDateTime) resList.Add("CreateDateTime");
            if (acceptOdrCar1.UpdateDateTime != acceptOdrCar2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (acceptOdrCar1.EnterpriseCode != acceptOdrCar2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (acceptOdrCar1.FileHeaderGuid != acceptOdrCar2.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (acceptOdrCar1.UpdEmployeeCode != acceptOdrCar2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (acceptOdrCar1.UpdAssemblyId1 != acceptOdrCar2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (acceptOdrCar1.UpdAssemblyId2 != acceptOdrCar2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (acceptOdrCar1.LogicalDeleteCode != acceptOdrCar2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (acceptOdrCar1.AcceptAnOrderNo != acceptOdrCar2.AcceptAnOrderNo) resList.Add("AcceptAnOrderNo");
            if (acceptOdrCar1.AcptAnOdrStatus != acceptOdrCar2.AcptAnOdrStatus) resList.Add("AcptAnOdrStatus");
            if (acceptOdrCar1.DataInputSystem != acceptOdrCar2.DataInputSystem) resList.Add("DataInputSystem");
            if (acceptOdrCar1.CarMngNo != acceptOdrCar2.CarMngNo) resList.Add("CarMngNo");
            if (acceptOdrCar1.CarMngCode != acceptOdrCar2.CarMngCode) resList.Add("CarMngCode");
            if (acceptOdrCar1.NumberPlate1Code != acceptOdrCar2.NumberPlate1Code) resList.Add("NumberPlate1Code");
            if (acceptOdrCar1.NumberPlate1Name != acceptOdrCar2.NumberPlate1Name) resList.Add("NumberPlate1Name");
            if (acceptOdrCar1.NumberPlate2 != acceptOdrCar2.NumberPlate2) resList.Add("NumberPlate2");
            if (acceptOdrCar1.NumberPlate3 != acceptOdrCar2.NumberPlate3) resList.Add("NumberPlate3");
            if (acceptOdrCar1.NumberPlate4 != acceptOdrCar2.NumberPlate4) resList.Add("NumberPlate4");
            if (acceptOdrCar1.FirstEntryDate != acceptOdrCar2.FirstEntryDate) resList.Add("FirstEntryDate");
            if (acceptOdrCar1.MakerCode != acceptOdrCar2.MakerCode) resList.Add("MakerCode");
            if (acceptOdrCar1.MakerFullName != acceptOdrCar2.MakerFullName) resList.Add("MakerFullName");
            if (acceptOdrCar1.MakerHalfName != acceptOdrCar2.MakerHalfName) resList.Add("MakerHalfName");
            if (acceptOdrCar1.ModelCode != acceptOdrCar2.ModelCode) resList.Add("ModelCode");
            if (acceptOdrCar1.ModelSubCode != acceptOdrCar2.ModelSubCode) resList.Add("ModelSubCode");
            if (acceptOdrCar1.ModelFullName != acceptOdrCar2.ModelFullName) resList.Add("ModelFullName");
            if (acceptOdrCar1.ModelHalfName != acceptOdrCar2.ModelHalfName) resList.Add("ModelHalfName");
            if (acceptOdrCar1.ExhaustGasSign != acceptOdrCar2.ExhaustGasSign) resList.Add("ExhaustGasSign");
            if (acceptOdrCar1.SeriesModel != acceptOdrCar2.SeriesModel) resList.Add("SeriesModel");
            if (acceptOdrCar1.CategorySignModel != acceptOdrCar2.CategorySignModel) resList.Add("CategorySignModel");
            if (acceptOdrCar1.FullModel != acceptOdrCar2.FullModel) resList.Add("FullModel");
            if (acceptOdrCar1.ModelDesignationNo != acceptOdrCar2.ModelDesignationNo) resList.Add("ModelDesignationNo");
            if (acceptOdrCar1.CategoryNo != acceptOdrCar2.CategoryNo) resList.Add("CategoryNo");
            if (acceptOdrCar1.FrameModel != acceptOdrCar2.FrameModel) resList.Add("FrameModel");
            if (acceptOdrCar1.FrameNo != acceptOdrCar2.FrameNo) resList.Add("FrameNo");
            if (acceptOdrCar1.SearchFrameNo != acceptOdrCar2.SearchFrameNo) resList.Add("SearchFrameNo");
            if (acceptOdrCar1.EngineModelNm != acceptOdrCar2.EngineModelNm) resList.Add("EngineModelNm");
            if (acceptOdrCar1.RelevanceModel != acceptOdrCar2.RelevanceModel) resList.Add("RelevanceModel");
            if (acceptOdrCar1.SubCarNmCd != acceptOdrCar2.SubCarNmCd) resList.Add("SubCarNmCd");
            if (acceptOdrCar1.ModelGradeSname != acceptOdrCar2.ModelGradeSname) resList.Add("ModelGradeSname");
            if (acceptOdrCar1.ColorCode != acceptOdrCar2.ColorCode) resList.Add("ColorCode");
            if (acceptOdrCar1.ColorName1 != acceptOdrCar2.ColorName1) resList.Add("ColorName1");
            if (acceptOdrCar1.TrimCode != acceptOdrCar2.TrimCode) resList.Add("TrimCode");
            if (acceptOdrCar1.TrimName != acceptOdrCar2.TrimName) resList.Add("TrimName");
            if (acceptOdrCar1.Mileage != acceptOdrCar2.Mileage) resList.Add("Mileage");
            if (acceptOdrCar1.FullModelFixedNoAry != acceptOdrCar2.FullModelFixedNoAry) resList.Add("FullModelFixedNoAry");
            if (acceptOdrCar1.CategoryObjAry != acceptOdrCar2.CategoryObjAry) resList.Add("CategoryObjAry");
            if (acceptOdrCar1.EnterpriseName != acceptOdrCar2.EnterpriseName) resList.Add("EnterpriseName");
            if (acceptOdrCar1.UpdEmployeeName != acceptOdrCar2.UpdEmployeeName) resList.Add("UpdEmployeeName");
            if (acceptOdrCar1.DataInputSystemName != acceptOdrCar2.DataInputSystemName) resList.Add("DataInputSystemName");
            if (acceptOdrCar1.ColorName != acceptOdrCar2.ColorName) resList.Add("ColorName");
            if (acceptOdrCar1.CarNote != acceptOdrCar2.CarNote) resList.Add("CarNote");
            if (acceptOdrCar1.FreeSrchMdlFxdNoAry != acceptOdrCar2.FreeSrchMdlFxdNoAry) resList.Add("FreeSrchMdlFxdNoAry"); // ADD 2010/04/27
            // --- ADD 2012/05/31 ---------->>>>>
            if (acceptOdrCar1.FirstEntryDateNumTyp != acceptOdrCar2.FirstEntryDateNumTyp) resList.Add("FirstEntryDateNumTyp");
            if (acceptOdrCar1.CarAddInf != acceptOdrCar2.CarAddInf) resList.Add("CarAddInf");
            if (acceptOdrCar1.EquipPrtsObj != acceptOdrCar2.EquipPrtsObj) resList.Add("EquipPrtsObj");
            // --- ADD 2012/05/31 ----------<<<<<

            return resList;
        }
    }
}
