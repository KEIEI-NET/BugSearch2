using System;
using System.Collections;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   CarShipmentPartsDispWork
    /// <summary>
    ///                      車輌出荷部品表示ワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   車輌出荷部品表示ワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2008/3/28</br>
    /// <br>Genarated Date   :   2009/09/24  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2008/6/9  杉村</br>
    /// <br>                 :   ○スペルミス修正</br>
    /// <br>                 :   売上値引非課税対象額合計</br>
    /// <br>                 :   売上正価金額</br>
    /// <br>                 :   売上金額消費税額（外税）</br>
    /// <br>Update Note      :   2008/7/29  長内</br>
    /// <br>                 :   ○項目追加</br>
    /// <br>                 :   得意先伝票番号</br>
    /// <br>Update Note      :   2012/08/09   凌小青</br>
    /// <br>                 :   ○項目追加</br>
    /// <br>                 :   行番号</br>
    /// <br>Update Note      :   SPK車台番号文字列対応に伴う車台番号表示レイアウトの修正</br>
    /// <br>Programmer       :   FSI厚川 宏</br>
    /// <br>Date             :   2013/03/25</br>
    /// <br>管理番号         :   10900269-00</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class CarShipmentPartsDispWork
    {
        /// <summary>売上日付</summary>
        /// <remarks>(YYYYMMDD)</remarks>
        private DateTime _salesDate;

        /// <summary>商品番号</summary>
        private string _goodsNo = "";

        /// <summary>商品名称</summary>
        private string _goodsName = "";

        /// <summary>商品メーカーコード</summary>
        /// <remarks>ﾊﾟｯｹｰｼﾞ毎にﾕｰｻﾞｰ登録範囲が異なる</remarks>
        private Int32 _goodsMakerCd;

        /// <summary>メーカー名称</summary>
        private string _makerName = "";

        /// <summary>BL商品コード</summary>
        private Int32 _bLGoodsCode;

        /// <summary>売上在庫取寄せ区分</summary>
        /// <remarks>0:取寄せ，1:在庫</remarks>
        private Int32 _salesOrderDivCd;

        /// <summary>定価（税抜，浮動）</summary>
        /// <remarks>税込み</remarks>
        private Double _listPriceTaxExcFl;

        /// <summary>出荷数</summary>
        private Double _shipmentCnt;

        /// <summary>売上単価（税抜，浮動）</summary>
        private Double _salesUnPrcTaxExcFl;

        /// <summary>売上金額（税抜き）</summary>
        private Int64 _salesMoneyTaxExc;

        /// <summary>粗利金額</summary>
        private Int64 _grossProfit;

        /// <summary>原価単価</summary>
        private Double _salesUnitCost;

        /// <summary>伝票備考</summary>
        private string _slipNote = "";

        /// <summary>車輌備考</summary>
        private string _carNote = "";

        /// <summary>売上伝票番号</summary>
        private string _salesSlipNum = "";

        /// <summary>車両走行距離</summary>
        private Int32 _mileage;

        /// <summary>シリーズ型式</summary>
        private string _seriesModel = "";

        /// <summary>型式（類別記号）</summary>
        private string _categorySignModel = "";

        /// <summary>初年度</summary>
        /// <remarks>YYYYMM</remarks>
        private DateTime _firstEntryDate;

        /// <summary>メーカーコード</summary>
        /// <remarks>1～899:提供分, 900～ユーザー登録</remarks>
        private Int32 _makerCode;

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

        /// <summary>型式（フル型）</summary>
        /// <remarks>フル型式(44桁用)</remarks>
        private string _fullModel = "";

        /// <summary>型式指定番号</summary>
        private Int32 _modelDesignationNo;

        /// <summary>類別番号</summary>
        private Int32 _categoryNo;

        /// <summary>車台番号</summary>
        /// <remarks>車検証記載フォーマット対応（ HCR32-100251584 等）</remarks>
        private string _frameNo = "";

        /// <summary>エンジン型式名称</summary>
        /// <remarks>エンジン検索</remarks>
        private string _engineModelNm = "";

        /// <summary>カラーコード</summary>
        /// <remarks>カタログの色コード</remarks>
        private string _colorCode = "";

        /// <summary>トリムコード</summary>
        private string _trimCode = "";

        /// <summary>生産車台番号開始</summary>
        private Int32 _stProduceFrameNo;

        /// <summary>生産車台番号終了</summary>
        private Int32 _edProduceFrameNo;

        /// <summary>原動機型式（エンジン）</summary>
        /// <remarks>車検証記載原動機型式</remarks>
        private string _engineModel = "";

        /// <summary>型式グレード名称</summary>
        private string _modelGradeNm = "";

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

        /// <summary>開始生産年式</summary>
        /// <remarks>YYYYMM</remarks>
        private DateTime _stProduceTypeOfYear;

        /// <summary>終了生産年式</summary>
        /// <remarks>YYYYMM</remarks>
        private DateTime _edProduceTypeOfYear;

        /// <summary>ドア数</summary>
        private Int32 _doorCount;

        /// <summary>ボディー名称</summary>
        private string _bodyName = "";

        /// <summary>出荷可能数</summary>
        /// <remarks>出荷可能数＝仕入在庫数 ＋ 入荷数（未計上）－ 出荷数（未計上）－受注数 － 移動中仕入在庫数</remarks>
        private Double _shipmentPosCnt;

        /// <summary>倉庫コード</summary>
        private string _warehouseCode = "";

        /// <summary>倉庫名称</summary>
        private string _warehouseName = "";

        /// <summary>倉庫棚番</summary>
        private string _warehouseShelfNo = "";

        /// <summary>原価</summary>
        private Int64 _cost;

        /// <summary>数量</summary>
        private Double _shipmentTotalCnt;

        /// <summary>売上金額（合計）</summary>
        private Int64 _salesMoneyTaxExcTotal;

        /// <summary>出荷回数</summary>
        private Double _shipmentCntTotal;

        /// <summary>数量（在庫）</summary>
        private Double _shipmentCntInTotal;

        /// <summary>数量（取寄）</summary>
        private Double _shipmentCntOutTotal;

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

        /// <summary>カラー名称1</summary>
        /// <remarks>画面表示用正式名称</remarks>
        private string _colorName1 = "";

        /// <summary>トリム名称</summary>
        private string _trimName = "";

        /// <summary>管理番号</summary>
        private string _carMngCode = "";

        /// <summary>受注ステータス</summary>
        private int _acptAnOdrStatus;

        /// <summary>売上伝票区分（明細）</summary>
        private Int32 _salesSlipCdDtl;

        // -------ADD BY 凌小青　on 2012/08/09 for Redmine#31532------->>>>>>>
        /// <summary>行番号</summary>
        private int _rowNo;

        // --- ADD 2013/03/25 ---------->>>>>
        /// <summary>国産/外車区分</summary>
        private Int32 _domesticForeignCode;
        // --- ADD 2013/03/25 ----------<<<<<

        /// public propaty name  :  RowNo
        /// <summary>行番号プロパティ</summary>
        /// <value></value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   行番号プロパティ</br>
        /// <br>Programer        :   Redmine#31532の対応を追加</br>
        /// </remarks>
        public Int32 RowNo
        {
            get { return _rowNo; }
            set { _rowNo = value; }
        }
        // -------ADD BY 凌小青　on 2012/08/09 for Redmine#31532-------<<<<<<<
        /// public propaty name  :  SalesDate
        /// <summary>売上日付プロパティ</summary>
        /// <value>(YYYYMMDD)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上日付プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime SalesDate
        {
            get { return _salesDate; }
            set { _salesDate = value; }
        }

        /// public propaty name  :  GoodsNo
        /// <summary>商品番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsNo
        {
            get { return _goodsNo; }
            set { _goodsNo = value; }
        }

        /// public propaty name  :  GoodsName
        /// <summary>商品名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsName
        {
            get { return _goodsName; }
            set { _goodsName = value; }
        }

        /// public propaty name  :  GoodsMakerCd
        /// <summary>商品メーカーコードプロパティ</summary>
        /// <value>ﾊﾟｯｹｰｼﾞ毎にﾕｰｻﾞｰ登録範囲が異なる</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品メーカーコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsMakerCd
        {
            get { return _goodsMakerCd; }
            set { _goodsMakerCd = value; }
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

        /// public propaty name  :  BLGoodsCode
        /// <summary>BL商品コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL商品コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BLGoodsCode
        {
            get { return _bLGoodsCode; }
            set { _bLGoodsCode = value; }
        }

        /// public propaty name  :  SalesOrderDivCd
        /// <summary>売上在庫取寄せ区分プロパティ</summary>
        /// <value>0:取寄せ，1:在庫</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上在庫取寄せ区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SalesOrderDivCd
        {
            get { return _salesOrderDivCd; }
            set { _salesOrderDivCd = value; }
        }

        /// public propaty name  :  ListPriceTaxExcFl
        /// <summary>定価（税抜，浮動）プロパティ</summary>
        /// <value>税込み</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   定価（税抜，浮動）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double ListPriceTaxExcFl
        {
            get { return _listPriceTaxExcFl; }
            set { _listPriceTaxExcFl = value; }
        }

        /// public propaty name  :  ShipmentCnt
        /// <summary>出荷数プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   出荷数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double ShipmentCnt
        {
            get { return _shipmentCnt; }
            set { _shipmentCnt = value; }
        }

        /// public propaty name  :  SalesUnPrcTaxExcFl
        /// <summary>売上単価（税抜，浮動）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上単価（税抜，浮動）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double SalesUnPrcTaxExcFl
        {
            get { return _salesUnPrcTaxExcFl; }
            set { _salesUnPrcTaxExcFl = value; }
        }

        /// public propaty name  :  SalesMoneyTaxExc
        /// <summary>売上金額（税抜き）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上金額（税抜き）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesMoneyTaxExc
        {
            get { return _salesMoneyTaxExc; }
            set { _salesMoneyTaxExc = value; }
        }

        /// public propaty name  :  SalesUnitCost
        /// <summary>原価単価プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   原価単価プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double SalesUnitCost
        {
            get { return _salesUnitCost; }
            set { _salesUnitCost = value; }
        }

        /// public propaty name  :  SlipNote
        /// <summary>伝票備考プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票備考プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SlipNote
        {
            get { return _slipNote; }
            set { _slipNote = value; }
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

        /// public propaty name  :  SalesSlipNum
        /// <summary>売上伝票番号プロパティ</summary>
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

        /// public propaty name  :  ShipmentPosCnt
        /// <summary>出荷可能数プロパティ</summary>
        /// <value>出荷可能数＝仕入在庫数 ＋ 入荷数（未計上）－ 出荷数（未計上）－受注数 － 移動中仕入在庫数</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   出荷可能数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double ShipmentPosCnt
        {
            get { return _shipmentPosCnt; }
            set { _shipmentPosCnt = value; }
        }

        /// public propaty name  :  WarehouseCode
        /// <summary>倉庫コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   倉庫コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string WarehouseCode
        {
            get { return _warehouseCode; }
            set { _warehouseCode = value; }
        }

        /// public propaty name  :  WarehouseName
        /// <summary>倉庫名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   倉庫名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string WarehouseName
        {
            get { return _warehouseName; }
            set { _warehouseName = value; }
        }

        /// public propaty name  :  WarehouseShelfNo
        /// <summary>倉庫棚番プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   倉庫棚番プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string WarehouseShelfNo
        {
            get { return _warehouseShelfNo; }
            set { _warehouseShelfNo = value; }
        }

        /// public propaty name  :  Cost
        /// <summary>原価プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   原価プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 Cost
        {
            get { return _cost; }
            set { _cost = value; }
        }

        /// public propaty name  :  ShipmentTotalCnt
        /// <summary>数量プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   数量プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double ShipmentTotalCnt
        {
            get { return _shipmentTotalCnt; }
            set { _shipmentTotalCnt = value; }
        }

        /// public propaty name  :  SalesMoneyTaxExcTotal
        /// <summary>売上金額（合計）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上金額（合計）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesMoneyTaxExcTotal
        {
            get { return _salesMoneyTaxExcTotal; }
            set { _salesMoneyTaxExcTotal = value; }
        }

        /// public propaty name  :  GrossProfit
        /// <summary>粗利金額プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   粗利金額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 GrossProfit
        {
            get { return _grossProfit; }
            set { _grossProfit = value; }
        }

        /// public propaty name  :  ShipmentCntTotal
        /// <summary>出荷回数プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   出荷回数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double ShipmentCntTotal
        {
            get { return _shipmentCntTotal; }
            set { _shipmentCntTotal = value; }
        }

        /// public propaty name  :  ShipmentCntInTotal
        /// <summary>数量（在庫）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   数量（在庫）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double ShipmentCntInTotal
        {
            get { return _shipmentCntInTotal; }
            set { _shipmentCntInTotal = value; }
        }

        /// public propaty name  :  ShipmentCntOutTotal
        /// <summary>数量（取寄）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   数量（取寄）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double ShipmentCntOutTotal
        {
            get { return _shipmentCntOutTotal; }
            set { _shipmentCntOutTotal = value; }
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

        /// public propaty name  :  CarMngCode
        /// <summary>管理番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   管理番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CarMngCode
        {
            get { return _carMngCode; }
            set { _carMngCode = value; }
        }

        /// public propaty name  :  AcptAnOdrStatus
        /// <summary>受注ステータスプロパティ</summary>
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

        /// public propaty name  :  SalesSlipCdDtl
        /// <summary>売上伝票区分（明細）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上伝票区分（明細）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SalesSlipCdDtl
        {
            get { return _salesSlipCdDtl; }
            set { _salesSlipCdDtl = value; }
        }

        // --- ADD 2013/03/25 ---------->>>>>
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
        // --- ADD 2013/03/25 ----------<<<<<

        /// <summary>
        /// 車輌出荷部品表示ワークコンストラクタ
        /// </summary>
        /// <returns>CarShipmentPartsDispWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CarShipmentPartsDispWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public CarShipmentPartsDispWork()
        {
        }

    }
    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>CarShipmentPartsDispWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   CarShipmentPartsDispWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class CarShipmentPartsDispWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   CarShipmentPartsDispWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// <br>Update Note      :   SPK車台番号文字列対応に伴う車台番号表示レイアウトの修正</br>
        /// <br>Programmer       :   FSI厚川 宏</br>
        /// <br>Date             :   2013/03/25</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  CarShipmentPartsDispWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is CarShipmentPartsDispWork || graph is ArrayList || graph is CarShipmentPartsDispWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(CarShipmentPartsDispWork).FullName));

            if (graph != null && graph is CarShipmentPartsDispWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.CarShipmentPartsDispWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is CarShipmentPartsDispWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((CarShipmentPartsDispWork[])graph).Length;
            }
            else if (graph is CarShipmentPartsDispWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //売上日付
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesDate
            //商品番号
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNo
            //商品名称
            serInfo.MemberInfo.Add(typeof(string)); //GoodsName
            //商品メーカーコード
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd
            //メーカー名称
            serInfo.MemberInfo.Add(typeof(string)); //MakerName
            //BL商品コード
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGoodsCode
            //売上在庫取寄せ区分
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesOrderDivCd
            //定価（税抜，浮動）
            serInfo.MemberInfo.Add(typeof(Double)); //ListPriceTaxExcFl
            //出荷数
            serInfo.MemberInfo.Add(typeof(Double)); //ShipmentCnt
            //売上単価（税抜，浮動）
            serInfo.MemberInfo.Add(typeof(Double)); //SalesUnPrcTaxExcFl
            //売上金額（税抜き）
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesMoneyTaxExc
            //粗利金額
            serInfo.MemberInfo.Add(typeof(Int64)); //GrossProfit
            //原価単価
            serInfo.MemberInfo.Add(typeof(Double)); //SalesUnitCost
            //伝票備考
            serInfo.MemberInfo.Add(typeof(string)); //SlipNote
            //車輌備考
            serInfo.MemberInfo.Add(typeof(string)); //CarNote
            //売上伝票番号
            serInfo.MemberInfo.Add(typeof(string)); //SalesSlipNum
            //車両走行距離
            serInfo.MemberInfo.Add(typeof(Int32)); //Mileage
            //シリーズ型式
            serInfo.MemberInfo.Add(typeof(string)); //SeriesModel
            //型式（類別記号）
            serInfo.MemberInfo.Add(typeof(string)); //CategorySignModel
            //初年度
            serInfo.MemberInfo.Add(typeof(Int32)); //FirstEntryDate
            //メーカーコード
            serInfo.MemberInfo.Add(typeof(Int32)); //MakerCode
            //車種コード
            serInfo.MemberInfo.Add(typeof(Int32)); //ModelCode
            //車種サブコード
            serInfo.MemberInfo.Add(typeof(Int32)); //ModelSubCode
            //車種全角名称
            serInfo.MemberInfo.Add(typeof(string)); //ModelFullName
            //車種半角名称
            serInfo.MemberInfo.Add(typeof(string)); //ModelHalfName
            //型式（フル型）
            serInfo.MemberInfo.Add(typeof(string)); //FullModel
            //型式指定番号
            serInfo.MemberInfo.Add(typeof(Int32)); //ModelDesignationNo
            //類別番号
            serInfo.MemberInfo.Add(typeof(Int32)); //CategoryNo
            //車台番号
            serInfo.MemberInfo.Add(typeof(string)); //FrameNo
            //エンジン型式名称
            serInfo.MemberInfo.Add(typeof(string)); //EngineModelNm
            //カラーコード
            serInfo.MemberInfo.Add(typeof(string)); //ColorCode
            //トリムコード
            serInfo.MemberInfo.Add(typeof(string)); //TrimCode
            //生産車台番号開始
            serInfo.MemberInfo.Add(typeof(Int32)); //StProduceFrameNo
            //生産車台番号終了
            serInfo.MemberInfo.Add(typeof(Int32)); //EdProduceFrameNo
            //原動機型式（エンジン）
            serInfo.MemberInfo.Add(typeof(string)); //EngineModel
            //型式グレード名称
            serInfo.MemberInfo.Add(typeof(string)); //ModelGradeNm
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
            //開始生産年式
            serInfo.MemberInfo.Add(typeof(Int32)); //StProduceTypeOfYear
            //終了生産年式
            serInfo.MemberInfo.Add(typeof(Int32)); //EdProduceTypeOfYear
            //ドア数
            serInfo.MemberInfo.Add(typeof(Int32)); //DoorCount
            //ボディー名称
            serInfo.MemberInfo.Add(typeof(string)); //BodyName
            //出荷可能数
            serInfo.MemberInfo.Add(typeof(Double)); //ShipmentPosCnt
            //倉庫コード
            serInfo.MemberInfo.Add(typeof(string)); //WarehouseCode
            //倉庫名称
            serInfo.MemberInfo.Add(typeof(string)); //WarehouseName
            //倉庫棚番
            serInfo.MemberInfo.Add(typeof(string)); //WarehouseShelfNo
            //原価
            serInfo.MemberInfo.Add(typeof(Int64)); //Cost
            //数量
            serInfo.MemberInfo.Add(typeof(Double)); //ShipmentTotalCnt
            //売上金額（合計）
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesMoneyTaxExcTotal
            //出荷回数
            serInfo.MemberInfo.Add(typeof(Double)); //ShipmentCntTotal
            //数量（在庫）
            serInfo.MemberInfo.Add(typeof(Double)); //ShipmentCntInTotal
            //数量（取寄）
            serInfo.MemberInfo.Add(typeof(Double)); //ShipmentCntOutTotal
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
            //カラー名称1
            serInfo.MemberInfo.Add(typeof(string)); //ColorName1
            //トリム名称
            serInfo.MemberInfo.Add(typeof(string)); //TrimName
            //管理番号
            serInfo.MemberInfo.Add(typeof(string)); //CarMngCode
            //受注ステータス
            serInfo.MemberInfo.Add(typeof(Int32)); //AcptAnOdrStatus
            //売上伝票区分（明細）
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesSlipCdDtl
            // --- ADD 2013/03/25 ---------->>>>>
            //国産/外車区分
            serInfo.MemberInfo.Add(typeof(Int32)); //DomesticForeignCode
            // --- ADD 2013/03/25 ----------<<<<<

            serInfo.Serialize(writer, serInfo);
            if (graph is CarShipmentPartsDispWork)
            {
                CarShipmentPartsDispWork temp = (CarShipmentPartsDispWork)graph;

                SetCarShipmentPartsDispWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is CarShipmentPartsDispWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((CarShipmentPartsDispWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (CarShipmentPartsDispWork temp in lst)
                {
                    SetCarShipmentPartsDispWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// CarShipmentPartsDispWorkメンバ数(publicプロパティ数)
        /// </summary>
        //private const int currentMemberCount = 77;//DEL BY 凌小青　on 2012/08/09 for Redmine#31532
        //private const int currentMemberCount = 78;//ADD BY 凌小青　on 2012/08/09 for Redmine#31532 //DEL 2013/03/25
        private const int currentMemberCount = 79;//ADD 2013/03/25

        /// <summary>
        ///  CarShipmentPartsDispWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   CarShipmentPartsDispWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// <br>Update Note      :   SPK車台番号文字列対応に伴う車台番号表示レイアウトの修正</br>
        /// <br>Programmer       :   FSI厚川 宏</br>
        /// <br>Date             :   2013/03/25</br>
        /// </remarks>
        private void SetCarShipmentPartsDispWork(System.IO.BinaryWriter writer, CarShipmentPartsDispWork temp)
        {
            //売上日付
            writer.Write((Int64)temp.SalesDate.Ticks);
            //商品番号
            writer.Write(temp.GoodsNo);
            //商品名称
            writer.Write(temp.GoodsName);
            //商品メーカーコード
            writer.Write(temp.GoodsMakerCd);
            //メーカー名称
            writer.Write(temp.MakerName);
            //BL商品コード
            writer.Write(temp.BLGoodsCode);
            //売上在庫取寄せ区分
            writer.Write(temp.SalesOrderDivCd);
            //定価（税抜，浮動）
            writer.Write(temp.ListPriceTaxExcFl);
            //出荷数
            writer.Write(temp.ShipmentCnt);
            //売上単価（税抜，浮動）
            writer.Write(temp.SalesUnPrcTaxExcFl);
            //売上金額（税抜き）
            writer.Write(temp.SalesMoneyTaxExc);
            //粗利金額
            writer.Write(temp.GrossProfit);
            //原価単価
            writer.Write(temp.SalesUnitCost);
            //伝票備考
            writer.Write(temp.SlipNote);
            //車輌備考
            writer.Write(temp.CarNote);
            //売上伝票番号
            writer.Write(temp.SalesSlipNum);
            //車両走行距離
            writer.Write(temp.Mileage);
            //シリーズ型式
            writer.Write(temp.SeriesModel);
            //型式（類別記号）
            writer.Write(temp.CategorySignModel);
            //初年度
            writer.Write((Int64)temp.FirstEntryDate.Ticks);
            //メーカーコード
            writer.Write(temp.MakerCode);
            //車種コード
            writer.Write(temp.ModelCode);
            //車種サブコード
            writer.Write(temp.ModelSubCode);
            //車種全角名称
            writer.Write(temp.ModelFullName);
            //車種半角名称
            writer.Write(temp.ModelHalfName);
            //型式（フル型）
            writer.Write(temp.FullModel);
            //型式指定番号
            writer.Write(temp.ModelDesignationNo);
            //類別番号
            writer.Write(temp.CategoryNo);
            //車台番号
            writer.Write(temp.FrameNo);
            //エンジン型式名称
            writer.Write(temp.EngineModelNm);
            //カラーコード
            writer.Write(temp.ColorCode);
            //トリムコード
            writer.Write(temp.TrimCode);
            //生産車台番号開始
            writer.Write(temp.StProduceFrameNo);
            //生産車台番号終了
            writer.Write(temp.EdProduceFrameNo);
            //原動機型式（エンジン）
            writer.Write(temp.EngineModel);
            //型式グレード名称
            writer.Write(temp.ModelGradeNm);
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
            //開始生産年式
            writer.Write((Int64)temp.StProduceTypeOfYear.Ticks);
            //終了生産年式
            writer.Write((Int64)temp.EdProduceTypeOfYear.Ticks);
            //ドア数
            writer.Write(temp.DoorCount);
            //ボディー名称
            writer.Write(temp.BodyName);
            //出荷可能数
            writer.Write(temp.ShipmentPosCnt);
            //倉庫コード
            writer.Write(temp.WarehouseCode);
            //倉庫名称
            writer.Write(temp.WarehouseName);
            //倉庫棚番
            writer.Write(temp.WarehouseShelfNo);
            //原価
            writer.Write(temp.Cost);
            //数量
            writer.Write(temp.ShipmentTotalCnt);
            //売上金額（合計）
            writer.Write(temp.SalesMoneyTaxExcTotal);
            //出荷回数
            writer.Write(temp.ShipmentCntTotal);
            //数量（在庫）
            writer.Write(temp.ShipmentCntInTotal);
            //数量（取寄）
            writer.Write(temp.ShipmentCntOutTotal);
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
            //カラー名称1
            writer.Write(temp.ColorName1);
            //トリム名称
            writer.Write(temp.TrimName);
            //管理番号
            writer.Write(temp.CarMngCode);
            // 受注ステータス
            writer.Write(temp.AcptAnOdrStatus);
            // 売上伝票区分（明細）
            writer.Write(temp.SalesSlipCdDtl);
            //行番号
            writer.Write(temp.RowNo);//ADD BY 凌小青　on 2012/08/09 for Redmine#31532
            // --- ADD 2013/03/25 ---------->>>>>
            //国産/外車区分
            writer.Write(temp.DomesticForeignCode);
            // --- ADD 2013/03/25 ----------<<<<<

        }

        /// <summary>
        ///  CarShipmentPartsDispWorkインスタンス取得
        /// </summary>
        /// <returns>CarShipmentPartsDispWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CarShipmentPartsDispWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// <br>Update Note      :   SPK車台番号文字列対応に伴う車台番号表示レイアウトの修正</br>
        /// <br>Programmer       :   FSI厚川 宏</br>
        /// <br>Date             :   2013/03/25</br>
        /// </remarks>
        private CarShipmentPartsDispWork GetCarShipmentPartsDispWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            CarShipmentPartsDispWork temp = new CarShipmentPartsDispWork();

            //売上日付
            temp.SalesDate = new DateTime(reader.ReadInt64());
            //商品番号
            temp.GoodsNo = reader.ReadString();
            //商品名称
            temp.GoodsName = reader.ReadString();
            //商品メーカーコード
            temp.GoodsMakerCd = reader.ReadInt32();
            //メーカー名称
            temp.MakerName = reader.ReadString();
            //BL商品コード
            temp.BLGoodsCode = reader.ReadInt32();
            //売上在庫取寄せ区分
            temp.SalesOrderDivCd = reader.ReadInt32();
            //定価（税抜，浮動）
            temp.ListPriceTaxExcFl = reader.ReadDouble();
            //出荷数
            temp.ShipmentCnt = reader.ReadDouble();
            //売上単価（税抜，浮動）
            temp.SalesUnPrcTaxExcFl = reader.ReadDouble();
            //売上金額（税抜き）
            temp.SalesMoneyTaxExc = reader.ReadInt64();
            //粗利金額
            temp.GrossProfit = reader.ReadInt64();
            //原価単価
            temp.SalesUnitCost = reader.ReadDouble();
            //伝票備考
            temp.SlipNote = reader.ReadString();
            //車輌備考
            temp.CarNote = reader.ReadString();
            //売上伝票番号
            temp.SalesSlipNum = reader.ReadString();
            //車両走行距離
            temp.Mileage = reader.ReadInt32();
            //シリーズ型式
            temp.SeriesModel = reader.ReadString();
            //型式（類別記号）
            temp.CategorySignModel = reader.ReadString();
            //初年度
            temp.FirstEntryDate = new DateTime(reader.ReadInt64());
            //メーカーコード
            temp.MakerCode = reader.ReadInt32();
            //車種コード
            temp.ModelCode = reader.ReadInt32();
            //車種サブコード
            temp.ModelSubCode = reader.ReadInt32();
            //車種全角名称
            temp.ModelFullName = reader.ReadString();
            //車種半角名称
            temp.ModelHalfName = reader.ReadString();
            //型式（フル型）
            temp.FullModel = reader.ReadString();
            //型式指定番号
            temp.ModelDesignationNo = reader.ReadInt32();
            //類別番号
            temp.CategoryNo = reader.ReadInt32();
            //車台番号
            temp.FrameNo = reader.ReadString();
            //エンジン型式名称
            temp.EngineModelNm = reader.ReadString();
            //カラーコード
            temp.ColorCode = reader.ReadString();
            //トリムコード
            temp.TrimCode = reader.ReadString();
            //生産車台番号開始
            temp.StProduceFrameNo = reader.ReadInt32();
            //生産車台番号終了
            temp.EdProduceFrameNo = reader.ReadInt32();
            //原動機型式（エンジン）
            temp.EngineModel = reader.ReadString();
            //型式グレード名称
            temp.ModelGradeNm = reader.ReadString();
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
            //開始生産年式
            temp.StProduceTypeOfYear = new DateTime(reader.ReadInt64());
            //終了生産年式
            temp.EdProduceTypeOfYear = new DateTime(reader.ReadInt64());
            //ドア数
            temp.DoorCount = reader.ReadInt32();
            //ボディー名称
            temp.BodyName = reader.ReadString();
            //出荷可能数
            temp.ShipmentPosCnt = reader.ReadDouble();
            //倉庫コード
            temp.WarehouseCode = reader.ReadString();
            //倉庫名称
            temp.WarehouseName = reader.ReadString();
            //倉庫棚番
            temp.WarehouseShelfNo = reader.ReadString();
            //原価
            temp.Cost = reader.ReadInt64();
            //数量
            temp.ShipmentTotalCnt = reader.ReadDouble();
            //売上金額（合計）
            temp.SalesMoneyTaxExcTotal = reader.ReadInt64();
            //出荷回数
            temp.ShipmentCntTotal = reader.ReadDouble();
            //数量（在庫）
            temp.ShipmentCntInTotal = reader.ReadDouble();
            //数量（取寄）
            temp.ShipmentCntOutTotal = reader.ReadDouble();
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
            //カラー名称1
            temp.ColorName1 = reader.ReadString();
            //トリム名称
            temp.TrimName = reader.ReadString();
            //管理番号
            temp.CarMngCode = reader.ReadString();
            // 受注ステータス
            temp.AcptAnOdrStatus = reader.ReadInt32();
            //売上伝票区分（明細）
            temp.SalesSlipCdDtl = reader.ReadInt32();
            //行番号
            temp.RowNo = reader.ReadInt32();//ADD BY 凌小青　on 2012/08/09 for Redmine#31532
            // --- ADD 2013/03/25 ---------->>>>>
            //国産/外車区分
            temp.DomesticForeignCode = reader.ReadInt32();
            // --- ADD 2013/03/25 ----------<<<<<

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
        /// <returns>CarShipmentPartsDispWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CarShipmentPartsDispWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                CarShipmentPartsDispWork temp = GetCarShipmentPartsDispWork(reader, serInfo);
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
                    retValue = (CarShipmentPartsDispWork[])lst.ToArray(typeof(CarShipmentPartsDispWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

}
