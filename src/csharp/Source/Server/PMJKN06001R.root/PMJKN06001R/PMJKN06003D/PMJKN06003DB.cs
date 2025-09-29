using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   FreeSearchModelSRetWork
    /// <summary>
    ///                      自由検索型式抽出結果クラスワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   自由検索型式抽出結果クラスワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2010/04/19</br>
    /// <br>Genarated Date   :   2010/04/19  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class FreeSearchModelSRetWork
    {
        /// <summary>メーカーコード</summary>
        /// <remarks>1～899:提供分, 900～ユーザー登録</remarks>
        private Int32 _makerCode;

        /// <summary>メーカー全角名称</summary>
        /// <remarks>正式名称（カナ漢字混在で全角管理）</remarks>
        private string _makerFullName = "";

        /// <summary>メーカー半角名称</summary>
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
        private Int32 _stProduceTypeOfYear;

        /// <summary>終了生産年式</summary>
        /// <remarks>YYYYMM</remarks>
        private Int32 _edProduceTypeOfYear;

        /// <summary>ドア数</summary>
        private Int32 _doorCount;

        /// <summary>ボディー名コード</summary>
        private Int32 _bodyNameCode;

        /// <summary>ボディー名称</summary>
        private string _bodyName = "";

        /// <summary>車両固有番号</summary>
        /// <remarks>ユニークな固定番号</remarks>
        private Int32 _carProperNo;

        /// <summary>フル型式固定番号</summary>
        private Int32 _fullModelFixedNo;

        /// <summary>排ガス記号</summary>
        private string _exhaustGasSign = "";

        /// <summary>シリーズ型式</summary>
        private string _seriesModel = "";

        /// <summary>型式（類別記号）</summary>
        private string _categorySignModel = "";

        /// <summary>型式（フル型）</summary>
        /// <remarks>フル型式(44桁用)</remarks>
        private string _fullModel = "";

        /// <summary>車台型式</summary>
        private string _frameModel = "";

        /// <summary>生産車台番号開始</summary>
        private Int32 _stProduceFrameNo;

        /// <summary>生産車台番号終了</summary>
        private Int32 _edProduceFrameNo;

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

        /// <summary>駆動方式名称</summary>        
        private string _wheelDriveMethodNm = "";

        /// <summary>シフト名称</summary>
        private string _shiftNm = "";

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

        /// <summary>自由検索型式固定番号</summary>
        /// <remarks>自由検索シリアル№</remarks>
        private string _freeSrchMdlFxdNo;


        /// public property name  :  MakerCode
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

        /// public property name  :  MakerFullName
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


        /// public property name  :  ModelCode
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

        /// public property name  :  ModelSubCode
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

        /// public property name  :  ModelFullName
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

        /// public property name  :  SystematicCode
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

        /// public property name  :  SystematicName
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

        /// public property name  :  ProduceTypeOfYearCd
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

        /// public property name  :  ProduceTypeOfYearNm
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

        /// public property name  :  StProduceTypeOfYear
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

        /// public property name  :  EdProduceTypeOfYear
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

        /// public property name  :  DoorCount
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

        /// public property name  :  BodyNameCode
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

        /// public property name  :  BodyName
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

        /// public property name  :  CarProperNo
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

        /// public property name  :  FullModelFixedNo
        /// <summary>フル型式固定番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   フル型式固定番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 FullModelFixedNo
        {
            get { return _fullModelFixedNo; }
            set { _fullModelFixedNo = value; }
        }

        /// public property name  :  ExhaustGasSign
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

        /// public property name  :  SeriesModel
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

        /// public property name  :  CategorySignModel
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

        /// public property name  :  FullModel
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

        /// public property name  :  FrameModel
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

        /// public property name  :  StProduceFrameNo
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

        /// public property name  :  EdProduceFrameNo
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

        /// public property name  :  ModelGradeNm
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

        /// public property name  :  EngineModelNm
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

        /// public property name  :  EngineDisplaceNm
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

        /// public property name  :  EDivNm
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

        /// public property name  :  TransmissionNm
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

        /// public property name  :  WheelDriveMethodNm
        /// <summary>駆動方式名称プロパティ</summary>
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

        /// public property name  :  ShiftNm
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

        /// public property name  :  AddiCarSpec1
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

        /// public property name  :  AddiCarSpec2
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

        /// public property name  :  AddiCarSpec3
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

        /// public property name  :  AddiCarSpec4
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

        /// public property name  :  AddiCarSpec5
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

        /// public property name  :  AddiCarSpec6
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

        /// public property name  :  AddiCarSpecTitle1
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

        /// public property name  :  AddiCarSpecTitle2
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

        /// public property name  :  AddiCarSpecTitle3
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

        /// public property name  :  AddiCarSpecTitle4
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

        /// public property name  :  AddiCarSpecTitle5
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

        /// public property name  :  AddiCarSpecTitle6
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

        /// public property name  :  RelevanceModel
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

        /// public property name  :  SubCarNmCd
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

        /// public property name  :  ModelGradeSname
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

        /// public property name  :  BlockIllustrationCd
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

        /// public property name  :  ThreeDIllustNo
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

        /// public property name  :  PartsDataOfferFlag
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

        /// public property name  :  FreeSrchMdlFxdNo
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


        /// <summary>
        /// 車輌型式抽出結果クラスワークコンストラクタ
        /// </summary>
        /// <returns>FreeSearchModelSCndtnWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   FreeSearchModelSCndtnWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public FreeSearchModelSRetWork()
        {
        }

        /// <summary>
        /// １カタログ絞込判定
        /// </summary>
        /// <param name="FreeSearchModelSCndtnWork">比較対象</param>
        /// <returns></returns>
        public bool IsCatalogEqual( FreeSearchModelSRetWork FreeSearchModelSCndtnWork )
        {
            if ( (_makerCode == FreeSearchModelSCndtnWork.MakerCode)
                && (_modelCode == FreeSearchModelSCndtnWork.ModelCode)
                && (_modelSubCode == FreeSearchModelSCndtnWork.ModelSubCode)
                && (_systematicCode == FreeSearchModelSCndtnWork.SystematicCode)
                && (_produceTypeOfYearCd == FreeSearchModelSCndtnWork.ProduceTypeOfYearCd)
                && (_doorCount == FreeSearchModelSCndtnWork.DoorCount)
                && (_bodyNameCode == FreeSearchModelSCndtnWork.BodyNameCode) )
                return true;
            return false;
        }

        /// <summary>
        /// １車台型式絞込判定
        /// </summary>
        /// <param name="FreeSearchModelSCndtnWork">比較対象</param>
        /// <returns></returns>
        public bool IsFrameModelEqual( FreeSearchModelSRetWork FreeSearchModelSCndtnWork )
        {
            if ( (_makerCode == FreeSearchModelSCndtnWork.MakerCode)
                    && (_frameModel == FreeSearchModelSCndtnWork.FrameModel) )
            {
                return true;
            }
            return false;
        }
    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>FreeSearchModelSCndtnWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   FreeSearchModelSCndtnWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class FreeSearchModelSRetWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   FreeSearchModelSCndtnWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize( System.IO.BinaryWriter writer, object graph )
        {
            // TODO:  FreeSearchModelSRetWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if ( writer == null )
                throw new ArgumentNullException();

            if ( graph != null && !(graph is FreeSearchModelSRetWork || graph is ArrayList || graph is FreeSearchModelSRetWork[]) )
                throw new ArgumentException( string.Format( "graphが{0}のインスタンスでありません", typeof( FreeSearchModelSRetWork ).FullName ) );

            if ( graph != null && graph is FreeSearchModelSRetWork )
            {
                Type t = graph.GetType();
                if ( !CustomFormatterServices.NeedCustomSerialization( t ) )
                    throw new ArgumentException( string.Format( "graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName ) );
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo( ", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.FreeSearchModelSRetWork" );

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if ( graph is ArrayList )
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if ( graph is FreeSearchModelSRetWork[] )
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((FreeSearchModelSRetWork[])graph).Length;
            }
            else if ( graph is FreeSearchModelSRetWork )
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //メーカーコード
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //MakerCode
            //メーカー全角名称
            serInfo.MemberInfo.Add( typeof( string ) ); //MakerFullName
            //メーカー半角名称
            serInfo.MemberInfo.Add( typeof( string ) ); //MakerHalfName
            //車種コード
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //ModelCode
            //車種サブコード
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //ModelSubCode
            //車種全角名称
            serInfo.MemberInfo.Add( typeof( string ) ); //ModelFullName
            //車種半角名称
            serInfo.MemberInfo.Add( typeof( string ) ); //ModelHalfName
            //系統コード
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SystematicCode
            //系統名称
            serInfo.MemberInfo.Add( typeof( string ) ); //SystematicName
            //生産年式コード
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //ProduceTypeOfYearCd
            //生産年式名称
            serInfo.MemberInfo.Add( typeof( string ) ); //ProduceTypeOfYearNm
            //開始生産年式
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //StProduceTypeOfYear
            //終了生産年式
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //EdProduceTypeOfYear
            //ドア数
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //DoorCount
            //ボディー名コード
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //BodyNameCode
            //ボディー名称
            serInfo.MemberInfo.Add( typeof( string ) ); //BodyName
            //車両固有番号
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //CarProperNo
            //フル型式固定番号
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //FullModelFixedNo
            //排ガス記号
            serInfo.MemberInfo.Add( typeof( string ) ); //ExhaustGasSign
            //シリーズ型式
            serInfo.MemberInfo.Add( typeof( string ) ); //SeriesModel
            //型式（類別記号）
            serInfo.MemberInfo.Add( typeof( string ) ); //CategorySignModel
            //型式（フル型）
            serInfo.MemberInfo.Add( typeof( string ) ); //FullModel
            //車台型式
            serInfo.MemberInfo.Add( typeof( string ) ); //FrameModel
            //生産車台番号開始
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //StProduceFrameNo
            //生産車台番号終了
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //EdProduceFrameNo
            //型式グレード名称
            serInfo.MemberInfo.Add( typeof( string ) ); //ModelGradeNm
            //エンジン型式名称
            serInfo.MemberInfo.Add( typeof( string ) ); //EngineModelNm
            //排気量名称
            serInfo.MemberInfo.Add( typeof( string ) ); //EngineDisplaceNm
            //E区分名称
            serInfo.MemberInfo.Add( typeof( string ) ); //EDivNm
            //ミッション名称
            serInfo.MemberInfo.Add( typeof( string ) ); //TransmissionNm
            //駆動方式名称
            serInfo.MemberInfo.Add( typeof( string ) ); //WheelDriveMethodNm
            //シフト名称
            serInfo.MemberInfo.Add( typeof( string ) ); //ShiftNm
            //追加諸元1
            serInfo.MemberInfo.Add( typeof( string ) ); //AddiCarSpec1
            //追加諸元2
            serInfo.MemberInfo.Add( typeof( string ) ); //AddiCarSpec2
            //追加諸元3
            serInfo.MemberInfo.Add( typeof( string ) ); //AddiCarSpec3
            //追加諸元4
            serInfo.MemberInfo.Add( typeof( string ) ); //AddiCarSpec4
            //追加諸元5
            serInfo.MemberInfo.Add( typeof( string ) ); //AddiCarSpec5
            //追加諸元6
            serInfo.MemberInfo.Add( typeof( string ) ); //AddiCarSpec6
            //追加諸元タイトル1
            serInfo.MemberInfo.Add( typeof( string ) ); //AddiCarSpecTitle1
            //追加諸元タイトル2
            serInfo.MemberInfo.Add( typeof( string ) ); //AddiCarSpecTitle2
            //追加諸元タイトル3
            serInfo.MemberInfo.Add( typeof( string ) ); //AddiCarSpecTitle3
            //追加諸元タイトル4
            serInfo.MemberInfo.Add( typeof( string ) ); //AddiCarSpecTitle4
            //追加諸元タイトル5
            serInfo.MemberInfo.Add( typeof( string ) ); //AddiCarSpecTitle5
            //追加諸元タイトル6
            serInfo.MemberInfo.Add( typeof( string ) ); //AddiCarSpecTitle6
            //関連型式
            serInfo.MemberInfo.Add( typeof( string ) ); //RelevanceModel
            //サブ車名コード
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SubCarNmCd
            //型式グレード略称
            serInfo.MemberInfo.Add( typeof( string ) ); //ModelGradeSname
            //ブロックイラストコード
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //BlockIllustrationCd
            //3DイラストNo
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //ThreeDIllustNo
            //部品データ提供フラグ
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //PartsDataOfferFlag
            //自由検索型式固定番号
            serInfo.MemberInfo.Add( typeof( string ) ); //FreeSrchMdlFxdNo

            serInfo.Serialize( writer, serInfo );
            if ( graph is FreeSearchModelSRetWork )
            {
                FreeSearchModelSRetWork temp = (FreeSearchModelSRetWork)graph;

                SetFreeSearchModelSRetWork( writer, temp );
            }
            else
            {
                ArrayList lst = null;
                if ( graph is FreeSearchModelSRetWork[] )
                {
                    lst = new ArrayList();
                    lst.AddRange( (FreeSearchModelSRetWork[])graph );
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach ( FreeSearchModelSRetWork temp in lst )
                {
                    SetFreeSearchModelSRetWork( writer, temp );
                }

            }


        }


        /// <summary>
        /// FreeSearchModelSCndtnWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 51;

        /// <summary>
        ///  FreeSearchModelSCndtnWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   FreeSearchModelSCndtnWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetFreeSearchModelSRetWork( System.IO.BinaryWriter writer, FreeSearchModelSRetWork temp )
        {
            //メーカーコード
            writer.Write( temp.MakerCode );
            //メーカー全角名称
            writer.Write( temp.MakerFullName );
            //メーカー半角名称
            writer.Write( temp.MakerHalfName );
            //車種コード
            writer.Write( temp.ModelCode );
            //車種サブコード
            writer.Write( temp.ModelSubCode );
            //車種全角名称
            writer.Write( temp.ModelFullName );
            //車種半角名称
            writer.Write( temp.ModelHalfName );
            //系統コード
            writer.Write( temp.SystematicCode );
            //系統名称
            writer.Write( temp.SystematicName );
            //生産年式コード
            writer.Write( temp.ProduceTypeOfYearCd );
            //生産年式名称
            writer.Write( temp.ProduceTypeOfYearNm );
            //開始生産年式
            writer.Write( temp.StProduceTypeOfYear );
            //終了生産年式
            writer.Write( temp.EdProduceTypeOfYear );
            //ドア数
            writer.Write( temp.DoorCount );
            //ボディー名コード
            writer.Write( temp.BodyNameCode );
            //ボディー名称
            writer.Write( temp.BodyName );
            //車両固有番号
            writer.Write( temp.CarProperNo );
            //フル型式固定番号
            writer.Write( temp.FullModelFixedNo );
            //排ガス記号
            writer.Write( temp.ExhaustGasSign );
            //シリーズ型式
            writer.Write( temp.SeriesModel );
            //型式（類別記号）
            writer.Write( temp.CategorySignModel );
            //型式（フル型）
            writer.Write( temp.FullModel );
            //車台型式
            writer.Write( temp.FrameModel );
            //生産車台番号開始
            writer.Write( temp.StProduceFrameNo );
            //生産車台番号終了
            writer.Write( temp.EdProduceFrameNo );
            //型式グレード名称
            writer.Write( temp.ModelGradeNm );
            //エンジン型式名称
            writer.Write( temp.EngineModelNm );
            //排気量名称
            writer.Write( temp.EngineDisplaceNm );
            //E区分名称
            writer.Write( temp.EDivNm );
            //ミッション名称
            writer.Write( temp.TransmissionNm );
            //駆動方式名称
            writer.Write( temp.WheelDriveMethodNm );
            //シフト名称
            writer.Write( temp.ShiftNm );
            //追加諸元1
            writer.Write( temp.AddiCarSpec1 );
            //追加諸元2
            writer.Write( temp.AddiCarSpec2 );
            //追加諸元3
            writer.Write( temp.AddiCarSpec3 );
            //追加諸元4
            writer.Write( temp.AddiCarSpec4 );
            //追加諸元5
            writer.Write( temp.AddiCarSpec5 );
            //追加諸元6
            writer.Write( temp.AddiCarSpec6 );
            //追加諸元タイトル1
            writer.Write( temp.AddiCarSpecTitle1 );
            //追加諸元タイトル2
            writer.Write( temp.AddiCarSpecTitle2 );
            //追加諸元タイトル3
            writer.Write( temp.AddiCarSpecTitle3 );
            //追加諸元タイトル4
            writer.Write( temp.AddiCarSpecTitle4 );
            //追加諸元タイトル5
            writer.Write( temp.AddiCarSpecTitle5 );
            //追加諸元タイトル6
            writer.Write( temp.AddiCarSpecTitle6 );
            //関連型式
            writer.Write( temp.RelevanceModel );
            //サブ車名コード
            writer.Write( temp.SubCarNmCd );
            //型式グレード略称
            writer.Write( temp.ModelGradeSname );
            //ブロックイラストコード
            writer.Write( temp.BlockIllustrationCd );
            //3DイラストNo
            writer.Write( temp.ThreeDIllustNo );
            //部品データ提供フラグ
            writer.Write( temp.PartsDataOfferFlag );
            //自由検索型式固定番号
            writer.Write( temp.FreeSrchMdlFxdNo );
        }

        /// <summary>
        ///  FreeSearchModelSCndtnWorkインスタンス取得
        /// </summary>
        /// <returns>FreeSearchModelSCndtnWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   FreeSearchModelSCndtnWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private FreeSearchModelSRetWork GetFreeSearchModelSRetWork( System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo )
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            FreeSearchModelSRetWork temp = new FreeSearchModelSRetWork();

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
            temp.StProduceTypeOfYear = reader.ReadInt32();
            //終了生産年式
            temp.EdProduceTypeOfYear = reader.ReadInt32();
            //ドア数
            temp.DoorCount = reader.ReadInt32();
            //ボディー名コード
            temp.BodyNameCode = reader.ReadInt32();
            //ボディー名称
            temp.BodyName = reader.ReadString();
            //車両固有番号
            temp.CarProperNo = reader.ReadInt32();
            //フル型式固定番号
            temp.FullModelFixedNo = reader.ReadInt32();
            //排ガス記号
            temp.ExhaustGasSign = reader.ReadString();
            //シリーズ型式
            temp.SeriesModel = reader.ReadString();
            //型式（類別記号）
            temp.CategorySignModel = reader.ReadString();
            //型式（フル型）
            temp.FullModel = reader.ReadString();
            //車台型式
            temp.FrameModel = reader.ReadString();
            //生産車台番号開始
            temp.StProduceFrameNo = reader.ReadInt32();
            //生産車台番号終了
            temp.EdProduceFrameNo = reader.ReadInt32();
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
            //駆動方式名称
            temp.WheelDriveMethodNm = reader.ReadString();
            //シフト名称
            temp.ShiftNm = reader.ReadString();
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
            //自由検索型式固定番号
            temp.FreeSrchMdlFxdNo = reader.ReadString();

            //以下は読み飛ばしです。このバージョンが想定する EmployeeWork型以降のバージョンの
            //データをデシリアライズする場合、シリアライズしたフォーマッタが記述した
            //型情報にしたがって、ストリームから情報を読み出します...といっても
            //読み出して捨てることになります。
            for ( int k = currentMemberCount; k < serInfo.MemberInfo.Count; ++k )
            {
                //byte[],char[]をデシリアライズする直前に、そのlengthが
                //デシリアライズされているケースがある、byte[],char[]の
                //デシリアライズにはlengthが必要なのでint型のデータをデ
                //シリアライズした場合は、この値をこの変数に退避します。
                int optCount = 0;
                object oMemberType = serInfo.MemberInfo[k];
                if ( oMemberType is Type )
                {
                    Type t = (Type)oMemberType;
                    object oData = TypeDeserializer.DeserializePrimitiveType( reader, t, optCount );
                    if ( t.Equals( typeof( int ) ) )
                    {
                        optCount = Convert.ToInt32( oData );
                    }
                    else
                    {
                        optCount = 0;
                    }
                }
                else if ( oMemberType is string )
                {
                    Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate formatter = CustomFormatterServices.GetSurrogate( (string)oMemberType );
                    object userData = formatter.Deserialize( reader );  //読み飛ばし
                }
            }
            return temp;
        }

        /// <summary>
        ///  Ver5.10.1.0用のカスタムデシリアライザです
        /// </summary>
        /// <returns>FreeSearchModelSCndtnWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   FreeSearchModelSCndtnWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize( System.IO.BinaryReader reader )
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject( reader );
            ArrayList lst = new ArrayList();
            for ( int cnt = 0; cnt < serInfo.Occurrence; ++cnt )
            {
                FreeSearchModelSRetWork temp = GetFreeSearchModelSRetWork( reader, serInfo );
                lst.Add( temp );
            }
            switch ( serInfo.RetTypeInfo )
            {
                case 0:
                    retValue = lst;
                    break;
                case 1:
                    retValue = lst[0];
                    break;
                case 2:
                    retValue = (FreeSearchModelSRetWork[])lst.ToArray( typeof( FreeSearchModelSRetWork ) );
                    break;
            }
            return retValue;
        }

        #endregion
    }
}
