//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   抽出・更新DB仲介クラス
//                  :   PMKYO07141D.DLL
// Name Space       :   Broadleaf.Application.Remoting.ParamData
// Programmer       :   譚洪
// Date             :   2009.3.30
//----------------------------------------------------------------------
// Update Note      :
//----------------------------------------------------------------------
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
// 履歴
//----------------------------------------------------------------------
// 管理番号              作成担当 : 馮文雄
// 修 正 日  2009/09/14  修正内容 : PM.NS-2-A・車輌管理
//　　　　　　　　　　　　　　　　　受注マスタ（車両）に車輌備考の追加
//----------------------------------------------------------------------
// 管理番号              作成担当 : gaoyh
// 修 正 日  2010/04/27  修正内容 : 受注マスタ（車両）に自由検索型式固定番号配列の追加
//----------------------------------------------------------------------------
// 管理番号  10900269-00 作成担当 : FSI厚川 宏
// 修 正 日  2013/03/21  修正内容 : SPK車台番号文字列対応に伴う国産/外車区分の追加
//----------------------------------------------------------------------------
//**********************************************************************
using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   AcceptOdrCarWork
    /// <summary>
    ///                      受注（車両）ワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   受注（車両）ワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2008/4/24</br>
    /// <br>Genarated Date   :   2009/03/30  (CSharp File Generated Date)</br>
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
    /// <br>Update Note      :   2009/09/14  馮文雄</br>
    /// <br>                 :   ○項目追加</br>
    /// <br>                 :   車輌備考</br>
    /// <br>Update Note      :   2010/04/27  gaoyh</br>
    /// <br>                 :   受注マスタ（車両）に自由検索型式固定番号配列の追加</br>
    /// <br>Update Note      :   SPK車台番号文字列対応に伴う国産/外車区分の追加</br>
    /// <br>Programmer       :   FSI厚川 宏</br>
    /// <br>Date             :   2013/03/21</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class APAcceptOdrCarWork : IFileHeader
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
        private DateTime _firstEntryDate;

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
        private Int32[] _fullModelFixedNoAry = new Int32[0];

        /// <summary>装備オブジェクト配列</summary>
        private Byte[] _categoryObjAry = new Byte[0];

        // --- ADD 2009/09/14 ---------->>>>>
        /// <summary>車輌備考</summary>
        private string _carNote = "";
        // --- ADD 2009/09/14 ----------<<<<<

        // --- ADD 2010/04/27 ---------->>>>>
        /// <summary>自由検索型式固定番号配列</summary>
        /// <remarks>自由検索シリアル№の配列クラスを格納（再検索不要になる）</remarks>
        private Byte[] _freeSrchMdlFxdNoAry = new Byte[0];
        // --- ADD 2010/04/27 ----------<<<<<

        // --- ADD 2013/03/21 ---------->>>>>
        /// <summary>国産/外車区分</summary>
        private Int32 _domesticForeignCode;
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
        public DateTime FirstEntryDate
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

        // --- ADD 2009/09/14 ---------->>>>>
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
        // --- ADD 2009/09/14 ----------<<<<<

        // --- ADD 2010/04/27 ---------->>>>>
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
        // --- ADD 2010/04/27 ----------<<<<

        // --- ADD 2013/03/21 ---------->>>>>
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
        // --- ADD 2013/03/21 ----------<<<<<

        /// <summary>
        /// 受注（車両）ワークコンストラクタ
        /// </summary>
        /// <returns>AcceptOdrCarWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   AcceptOdrCarWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public APAcceptOdrCarWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>AcceptOdrCarWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   AcceptOdrCarWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// <br>Update Note      :   2009/09/14  馮文雄</br>
    /// <br>                 :   ○項目追加</br>
    /// <br>                 :   車輌備考</br>
    /// </remarks>
    public class APAcceptOdrCarWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   AcceptOdrCarWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// <br>Update Note      :   SPK車台番号文字列対応に伴う国産/外車区分の追加</br>
        /// <br>Programmer       :   FSI厚川 宏</br>
        /// <br>Date             :   2013/03/21</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  AcceptOdrCarWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is APAcceptOdrCarWork || graph is ArrayList || graph is APAcceptOdrCarWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(APAcceptOdrCarWork).FullName));

            if (graph != null && graph is APAcceptOdrCarWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.AcceptOdrCarWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is APAcceptOdrCarWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((APAcceptOdrCarWork[])graph).Length;
            }
            else if (graph is APAcceptOdrCarWork)
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
            //受注番号
            serInfo.MemberInfo.Add(typeof(Int32)); //AcceptAnOrderNo
            //受注ステータス
            serInfo.MemberInfo.Add(typeof(Int32)); //AcptAnOdrStatus
            //データ入力システム
            serInfo.MemberInfo.Add(typeof(Int32)); //DataInputSystem
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
            //エンジン型式名称
            serInfo.MemberInfo.Add(typeof(string)); //EngineModelNm
            //関連型式
            serInfo.MemberInfo.Add(typeof(string)); //RelevanceModel
            //サブ車名コード
            serInfo.MemberInfo.Add(typeof(Int32)); //SubCarNmCd
            //型式グレード略称
            serInfo.MemberInfo.Add(typeof(string)); //ModelGradeSname
            //カラーコード
            serInfo.MemberInfo.Add(typeof(string)); //ColorCode
            //カラー名称1
            serInfo.MemberInfo.Add(typeof(string)); //ColorName1
            //トリムコード
            serInfo.MemberInfo.Add(typeof(string)); //TrimCode
            //トリム名称
            serInfo.MemberInfo.Add(typeof(string)); //TrimName
            //車両走行距離
            serInfo.MemberInfo.Add(typeof(Int32)); //Mileage
            //フル型式固定番号配列
            serInfo.MemberInfo.Add(typeof(Int32[])); //FullModelFixedNoAry
            //装備オブジェクト配列
            serInfo.MemberInfo.Add(typeof(Byte[])); //CategoryObjAry
            // --- ADD 2009/09/14 ---------->>>>>
            //車輌備考
            serInfo.MemberInfo.Add(typeof(string)); //CarNote
            // --- ADD 2009/09/14 ----------<<<<<
            // --- ADD 2010/04/27 ---------->>>>>
            serInfo.MemberInfo.Add(typeof(Byte[])); // FreeSrchMdlFxdNoAryRF
            // --- ADD 2010/04/27 ----------<<<<<
            // --- ADD 2013/03/21 ---------->>>>>
            //国産/外車区分
            serInfo.MemberInfo.Add(typeof(Int32)); //DomesticForeignCode
            // --- ADD 2013/03/21 ----------<<<<<


            serInfo.Serialize(writer, serInfo);
            if (graph is APAcceptOdrCarWork)
            {
                APAcceptOdrCarWork temp = (APAcceptOdrCarWork)graph;

                SetAcceptOdrCarWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is APAcceptOdrCarWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((APAcceptOdrCarWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (APAcceptOdrCarWork temp in lst)
                {
                    SetAcceptOdrCarWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// AcceptOdrCarWorkメンバ数(publicプロパティ数)
        /// </summary>
        // private const int currentMemberCount = 46;  // DEL 2009/09/14 車輌備考の追加
        //private const int currentMemberCount = 47;  // ADD 2009/09/14 // DEL 2010/04/27
        //private const int currentMemberCount = 48;  // ADD 2010/04/27 // DEL 2013/03/21
        private const int currentMemberCount = 49;  // ADD 2013/03/21

        /// <summary>
        ///  AcceptOdrCarWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   AcceptOdrCarWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// <br>Update Note      :   SPK車台番号文字列対応に伴う国産/外車区分の追加</br>
        /// <br>Programmer       :   FSI厚川 宏</br>
        /// <br>Date             :   2013/03/21</br>
        /// </remarks>
        private void SetAcceptOdrCarWork(System.IO.BinaryWriter writer, APAcceptOdrCarWork temp)
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
            //受注番号
            writer.Write(temp.AcceptAnOrderNo);
            //受注ステータス
            writer.Write(temp.AcptAnOdrStatus);
            //データ入力システム
            writer.Write(temp.DataInputSystem);
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
            //初年度
            writer.Write((Int64)temp.FirstEntryDate.Ticks);
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
            //エンジン型式名称
            writer.Write(temp.EngineModelNm);
            //関連型式
            writer.Write(temp.RelevanceModel);
            //サブ車名コード
            writer.Write(temp.SubCarNmCd);
            //型式グレード略称
            writer.Write(temp.ModelGradeSname);
            //カラーコード
            writer.Write(temp.ColorCode);
            //カラー名称1
            writer.Write(temp.ColorName1);
            //トリムコード
            writer.Write(temp.TrimCode);
            //トリム名称
            writer.Write(temp.TrimName);
            //車両走行距離
            writer.Write(temp.Mileage);
            //フル型式固定番号配列
            int length = temp.FullModelFixedNoAry.Length;
            writer.Write(length);
            for (int cnt = 0; cnt < length; cnt++)
                writer.Write(temp.FullModelFixedNoAry[cnt]);
            //装備オブジェクト配列
            writer.Write(temp.CategoryObjAry.Length);
            writer.Write(temp.CategoryObjAry);
            // --- ADD 2009/09/14 ---------->>>>>
            //車輌備考
            writer.Write(temp.CarNote);
            // --- ADD 2009/09/14 ----------<<<<<
            // --- ADD 2010/04/27 ---------->>>>>
            //自由検索型式固定番号配列
            writer.Write(temp.FreeSrchMdlFxdNoAry.Length);
            writer.Write(temp.FreeSrchMdlFxdNoAry);
            // --- ADD 2010/04/27 ----------<<<<<
            // --- ADD 2013/03/21 ---------->>>>>
            //国産/外車区分
            writer.Write(temp.DomesticForeignCode);
            // --- ADD 2013/03/21 ----------<<<<<

        }

        /// <summary>
        ///  AcceptOdrCarWorkインスタンス取得
        /// </summary>
        /// <returns>AcceptOdrCarWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   AcceptOdrCarWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// <br>Update Note      :   SPK車台番号文字列対応に伴う国産/外車区分の追加</br>
        /// <br>Programmer       :   FSI厚川 宏</br>
        /// <br>Date             :   2013/03/21</br>
        /// </remarks>
        private APAcceptOdrCarWork GetAcceptOdrCarWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            APAcceptOdrCarWork temp = new APAcceptOdrCarWork();

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
            //受注番号
            temp.AcceptAnOrderNo = reader.ReadInt32();
            //受注ステータス
            temp.AcptAnOdrStatus = reader.ReadInt32();
            //データ入力システム
            temp.DataInputSystem = reader.ReadInt32();
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
            //初年度
            temp.FirstEntryDate = new DateTime(reader.ReadInt64());
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
            //エンジン型式名称
            temp.EngineModelNm = reader.ReadString();
            //関連型式
            temp.RelevanceModel = reader.ReadString();
            //サブ車名コード
            temp.SubCarNmCd = reader.ReadInt32();
            //型式グレード略称
            temp.ModelGradeSname = reader.ReadString();
            //カラーコード
            temp.ColorCode = reader.ReadString();
            //カラー名称1
            temp.ColorName1 = reader.ReadString();
            //トリムコード
            temp.TrimCode = reader.ReadString();
            //トリム名称
            temp.TrimName = reader.ReadString();
            //車両走行距離
            temp.Mileage = reader.ReadInt32();
            //フル型式固定番号配列
            int length = reader.ReadInt32();
            temp.FullModelFixedNoAry = new int[length];
            for (int cnt = 0; cnt < length; cnt++)
                temp.FullModelFixedNoAry[cnt] = reader.ReadInt32();

            //装備オブジェクト配列
            int lenCategoryObjArray = reader.ReadInt32();
            temp.CategoryObjAry = reader.ReadBytes(lenCategoryObjArray);
            // --- ADD 2009/09/14 ---------->>>>>
            //車輌備考
            temp.CarNote = reader.ReadString();
            // --- ADD 2009/09/14 ----------<<<<<
            // --- ADD 2010/04/27 ---------->>>>>
            //自由検索型式固定番号配列
            length = reader.ReadInt32();
            temp.FreeSrchMdlFxdNoAry = reader.ReadBytes(length);
            // --- ADD 2010/04/27 ----------<<<<<
            // --- ADD 2013/03/21 ---------->>>>>
            //国産/外車区分
            temp.DomesticForeignCode = reader.ReadInt32();
            // --- ADD 2013/03/21 ----------<<<<<


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
        /// <returns>AcceptOdrCarWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   AcceptOdrCarWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                APAcceptOdrCarWork temp = GetAcceptOdrCarWork(reader, serInfo);
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
                    retValue = (APAcceptOdrCarWork[])lst.ToArray(typeof(APAcceptOdrCarWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

}
