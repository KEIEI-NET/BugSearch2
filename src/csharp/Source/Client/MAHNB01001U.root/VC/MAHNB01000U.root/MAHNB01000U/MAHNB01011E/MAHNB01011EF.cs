using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Application.UIData
{
    # region [SalesSlipHeaderCopyData]
    /// <summary>
    /// 見出貼付情報クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 見出複写→貼付の内容を保持するデータクラスです。</br>
    /// <br>Programmer : 22018 鈴木 正臣</br>
    /// <br>Date       : 2009.08.10</br>
    /// <br></br>
    /// <br>Update Note  : 2009/09/08 張凱</br>
    /// <br>               PM.NS-2-A・車輌管理</br>
    /// <br>               車両走行距離、車輌備考、陸運事務所番号、陸運事務局名称の追加</br>
    /// <br>               車両登録番号（種別）、車両登録番号（カナ）、車両登録番号（プレート番号）の追加</br>
    /// <br>Update Note  : 2010/04/02 鈴木 正臣</br>
    /// <br>               【MANTIS:0015240】見出貼付の修正対応（車種名カナ）</br>
    /// <br>Update Note  : 2010/04/27 gaoyh</br>
    /// <br>               受注マスタ（車両）自由検索型式固定番号配列の追加対応</br>
    /// <br>Update Note: 2013/03/21 FSI今野 利裕</br>
    /// <br>管理番号   : 10900269-00</br>
    /// <br>             SPK車台番号文字列対応</br>   
    /// </remarks>
    [Serializable]
    public class SalesSlipHeaderCopyData
    {
        /// <summary>受注ステータス</summary>
        private int _acptAnOdrStatus;
        /// <summary>売上伝票区分</summary>
        private int _salesSlipCd;
        /// <summary>売上伝票番号</summary>
        private string _salesSlipNum = "";
        /// <summary>売上行番号</summary>
        private int _salesRowNo;
        /// <summary>売上日付</summary>
        private int _salesDate;
        /// <summary>拠点コード</summary>
        private string _sectionCode = "";
        /// <summary>得意先コード</summary>
        private int _customerCode;
        /// <summary>得意先略称</summary>
        private string _customerSnm = "";
        /// <summary>受注者コード</summary>
        private string _frontEmployeeCd;
        /// <summary>発行者コード</summary>
        private string _salesInputCode;
        /// <summary>車輌管理番号</summary>
        private string _carMngCode = "";
        /// <summary>車輌管理SEQ</summary>
        private int _carMngNo;
        /// <summary>型式指定番号</summary>
        private int _modelDesignationNo;
        /// <summary>類別番号</summary>
        private int _categoryNo;
        /// <summary>メーカーコード</summary>
        private int _makerCode;
        /// <summary>車種コード</summary>
        private int _modelCode;
        /// <summary>車種サブコード</summary>
        private int _modelSubCode;
        /// <summary>車種名称</summary>
        private string _modelFullName = "";
        /// <summary>型式（フル型式）</summary>
        private string _fullModel = "";
        /// <summary>エンジン型式</summary>
        private string _engineModelNm = "";
        /// <summary>年式</summary>
        private int _firstEntryDate;
        /// <summary>車台番号</summary>
        private string _frameNo = "";
        /// <summary>カラーコード</summary>
        private string _colorCode = "";
        /// <summary>トリムコード</summary>
        private string _trimCode = "";
        /// <summary>伝票備考１</summary>
        private string _slipNote = "";
        /// <summary>伝票備考２</summary>
        private string _slipNote2 = "";
        /// <summary>伝票備考３</summary>
        private string _slipNote3 = "";
        /// <summary>納入先コード</summary>
        private int _addresseeCode;
        /// <summary>納入先名称１</summary>
        private string _addresseeName = "";
        /// <summary>納入先名称２</summary>
        private string _addresseeName2 = "";
        /// <summary>納品区分</summary>
        private int _deliveredGoodsDiv;
        /// <summary>仮伝番号</summary>
        private string _partySaleSlipNum = "";
        /// <summary>フル型式固定番号配列</summary>
        private int[] _fullModelFixedNoAry = new int[0];
        /// <summary>装備情報配列</summary>
        private byte[] _categoryObjAry = new byte[0];
        // --- ADD 2009/09/08 ---------->>>>>
        /// <summary>車両走行距離</summary>
        private int _mileage;
        /// <summary>車輌備考</summary>
        private string _carNote = "";
        /// <summary>陸運事務所番号</summary>
        private int _numberPlate1Code;
        /// <summary>陸運事務局名称</summary>
        private string _numberPlate1Name = "";
        /// <summary>車両登録番号（種別）</summary>
        private string _numberPlate2 = "";
        /// <summary>車両登録番号（カナ）</summary>
        private string _numberPlate3 = "";
        /// <summary>車両登録番号（プレート番号）</summary>
        private int _numberPlate4;

        /// <summary>車検満期日</summary>
        private DateTime _inspectMaturityDate;
        /// <summary>前回車検満期日</summary>
        private DateTime _lTimeCiMatDate;
        /// <summary>車検期間</summary>
        private int _carInspectYear;
        /// <summary>原動機型式（エンジン）</summary>
        private string _engineModel = "";
        /// <summary>車輌追加情報１</summary>
        private string _carAddInfo1 = "";
        /// <summary>車輌追加情報２</summary>
        private string _carAddInfo2 = "";
        /// <summary>登録年月日</summary>
        private DateTime _entryDate;
        // --- ADD 2009/09/08 ----------<<<<<
        // --- ADD m.suzuki 2010/04/02 ---------->>>>>
        /// <summary>車種半角名称</summary>
        private string _modelHalfName;
        // --- ADD m.suzuki 2010/04/02 ----------<<<<<

        // --- ADD 2010/04/27 ---------->>>>>
        /// <summary>自由検索型式固定番号配列</summary>
        private string[] _freeSrchMdlFxdNoAry = new string[0];
        // --- ADD 2010/04/27 ----------<<<<<

        // PMNS:国産/外車区分 列追加
        // --- ADD 2013/03/21 ---------->>>>>
        /// <summary>国産/外車区分</summary>
        private int _domesticForeignCode;
        // --- ADD 2013/03/21 ----------<<<<<

        /// <summary>
        /// 受注ステータス
        /// </summary>
        public int AcptAnOdrStatus
        {
            get { return _acptAnOdrStatus; }
            set { _acptAnOdrStatus = value; }
        }
        /// <summary>
        /// 売上伝票区分
        /// </summary>
        public int SalesSlipCd
        {
            get { return _salesSlipCd; }
            set { _salesSlipCd = value; }
        }
        /// <summary>
        /// 売上伝票番号
        /// </summary>
        public string SalesSlipNum
        {
            get { return _salesSlipNum; }
            set { _salesSlipNum = value; }
        }
        /// <summary>
        /// 売上行番号
        /// </summary>
        public int SalesRowNo
        {
            get { return _salesRowNo; }
            set { _salesRowNo = value; }
        }
        /// <summary>
        /// 売上日付
        /// </summary>
        public int SalesDate
        {
            get { return _salesDate; }
            set { _salesDate = value; }
        }
        /// <summary>
        /// 拠点コード
        /// </summary>
        public string SectionCode
        {
            get { return _sectionCode; }
            set { _sectionCode = value; }
        }
        /// <summary>
        /// 得意先コード
        /// </summary>
        public int CustomerCode
        {
            get { return _customerCode; }
            set { _customerCode = value; }
        }
        /// <summary>
        /// 得意先略称
        /// </summary>
        public string CustomerSnm
        {
            get { return _customerSnm; }
            set { _customerSnm = value; }
        }
        /// <summary>
        /// 受注者コード
        /// </summary>
        public string FrontEmployeeCd
        {
            get { return _frontEmployeeCd; }
            set { _frontEmployeeCd = value; }
        }
        /// <summary>
        /// 発行者コード
        /// </summary>
        public string SalesInputCode
        {
            get { return _salesInputCode; }
            set { _salesInputCode = value; }
        }
        /// <summary>
        /// 車輌管理番号
        /// </summary>
        public string CarMngCode
        {
            get { return _carMngCode; }
            set { _carMngCode = value; }
        }
        /// <summary>
        /// 車輌管理SEQ
        /// </summary>
        public int CarMngNo
        {
            get { return _carMngNo; }
            set { _carMngNo = value; }
        }
        /// <summary>
        /// 型式指定番号
        /// </summary>
        public int ModelDesignationNo
        {
            get { return _modelDesignationNo; }
            set { _modelDesignationNo = value; }
        }
        /// <summary>
        /// 類別番号
        /// </summary>
        public int CategoryNo
        {
            get { return _categoryNo; }
            set { _categoryNo = value; }
        }
        /// <summary>
        /// メーカーコード
        /// </summary>
        public int MakerCode
        {
            get { return _makerCode; }
            set { _makerCode = value; }
        }
        /// <summary>
        /// 車種コード
        /// </summary>
        public int ModelCode
        {
            get { return _modelCode; }
            set { _modelCode = value; }
        }
        /// <summary>
        /// 車種サブコード
        /// </summary>
        public int ModelSubCode
        {
            get { return _modelSubCode; }
            set { _modelSubCode = value; }
        }
        /// <summary>
        /// 車種名称
        /// </summary>
        public string ModelFullName
        {
            get { return _modelFullName; }
            set { _modelFullName = value; }
        }
        /// <summary>
        /// 型式（フル型式）
        /// </summary>
        public string FullModel
        {
            get { return _fullModel; }
            set { _fullModel = value; }
        }
        /// <summary>
        /// エンジン型式
        /// </summary>
        public string EngineModelNm
        {
            get { return _engineModelNm; }
            set { _engineModelNm = value; }
        }
        /// <summary>
        /// 年式
        /// </summary>
        public int FirstEntryDate
        {
            get { return _firstEntryDate; }
            set { _firstEntryDate = value; }
        }
        /// <summary>
        /// 車台番号
        /// </summary>
        public string FrameNo
        {
            get { return _frameNo; }
            set { _frameNo = value; }
        }
        /// <summary>
        /// カラーコード
        /// </summary>
        public string ColorCode
        {
            get { return _colorCode; }
            set { _colorCode = value; }
        }
        /// <summary>
        /// トリムコード
        /// </summary>
        public string TrimCode
        {
            get { return _trimCode; }
            set { _trimCode = value; }
        }
        /// <summary>
        /// 伝票備考１
        /// </summary>
        public string SlipNote
        {
            get { return _slipNote; }
            set { _slipNote = value; }
        }
        /// <summary>
        /// 伝票備考２
        /// </summary>
        public string SlipNote2
        {
            get { return _slipNote2; }
            set { _slipNote2 = value; }
        }
        /// <summary>
        /// 伝票備考３
        /// </summary>
        public string SlipNote3
        {
            get { return _slipNote3; }
            set { _slipNote3 = value; }
        }
        /// <summary>
        /// 納入先コード
        /// </summary>
        public int AddresseeCode
        {
            get { return _addresseeCode; }
            set { _addresseeCode = value; }
        }
        /// <summary>
        /// 納入先名称１
        /// </summary>
        public string AddresseeName
        {
            get { return _addresseeName; }
            set { _addresseeName = value; }
        }
        /// <summary>
        /// 納入先名称２
        /// </summary>
        public string AddresseeName2
        {
            get { return _addresseeName2; }
            set { _addresseeName2 = value; }
        }
        /// <summary>
        /// 納品区分
        /// </summary>
        public int DeliveredGoodsDiv
        {
            get { return _deliveredGoodsDiv; }
            set { _deliveredGoodsDiv = value; }
        }
        /// <summary>
        /// 仮伝番号
        /// </summary>
        public string PartySaleSlipNum
        {
            get { return _partySaleSlipNum; }
            set { _partySaleSlipNum = value; }
        }
        /// <summary>
        /// フル型式固定番号配列
        /// </summary>
        public int[] FullModelFixedNoAry
        {
            get { return _fullModelFixedNoAry; }
            set { _fullModelFixedNoAry = value; }
        }
        /// <summary>
        /// 装備情報配列
        /// </summary>
        public byte[] CategoryObjAry
        {
            get { return _categoryObjAry; }
            set { _categoryObjAry = value; }
        }

        // --- ADD 2009/09/08 ---------->>>>>
        /// <summary>
        /// 車両走行距離
        /// </summary>
        public int Mileage
        {
            get { return _mileage; }
            set { _mileage = value; }
        }

        /// <summary>
        /// 車輌備考
        /// </summary>
        public string CarNote
        {
            get { return _carNote; }
            set { _carNote = value; }
        }

        /// <summary>
        /// 陸運事務所番号
        /// </summary>
        public int NumberPlate1Code
        {
            get { return _numberPlate1Code; }
            set { _numberPlate1Code = value; }
        }

        /// <summary>
        /// 陸運事務局名称
        /// </summary>
        public string NumberPlate1Name
        {
            get { return _numberPlate1Name; }
            set { _numberPlate1Name = value; }
        }

        /// <summary>
        /// 車両登録番号（種別）
        /// </summary>
        public string NumberPlate2
        {
            get { return _numberPlate2; }
            set { _numberPlate2 = value; }
        }

        /// <summary>
        /// 車両登録番号（カナ）
        /// </summary>
        public string NumberPlate3
        {
            get { return _numberPlate3; }
            set { _numberPlate3 = value; }
        }

        /// <summary>
        /// 車両登録番号（プレート番号）
        /// </summary>
        public int NumberPlate4
        {
            get { return _numberPlate4; }
            set { _numberPlate4 = value; }
        }

        /// <summary>
        /// 車検満期日
        /// </summary>
        public DateTime InspectMaturityDate
        {
            get { return _inspectMaturityDate; }
            set { _inspectMaturityDate = value; }
        }

        /// <summary>
        /// 前回車検満期日
        /// </summary>
        public DateTime LTimeCiMatDate
        {
            get { return _lTimeCiMatDate; }
            set { _lTimeCiMatDate = value; }
        }

        /// <summary>
        /// 車検期間
        /// </summary>
        public int CarInspectYear
        {
            get { return _carInspectYear; }
            set { _carInspectYear = value; }
        }

        /// <summary>
        /// 原動機型式（エンジン）
        /// </summary>
        public string EngineModel
        {
            get { return _engineModel; }
            set { _engineModel = value; }
        }

        /// <summary>
        /// 車輌追加情報１
        /// </summary>
        public string CarAddInfo1
        {
            get { return _carAddInfo1; }
            set { _carAddInfo1 = value; }
        }

        /// <summary>
        /// 車輌追加情報２
        /// </summary>
        public string CarAddInfo2
        {
            get { return _carAddInfo2; }
            set { _carAddInfo2 = value; }
        }

        /// <summary>
        /// 登録年月日
        /// </summary>
        public DateTime EntryDate
        {
            get { return _entryDate; }
            set { _entryDate = value; }
        }
        // --- ADD 2009/09/08 ----------<<<<<
        // --- ADD m.suzuki 2010/04/02 ---------->>>>>
        /// <summary>
        /// 車種半角名称プロパティ
        /// </summary>
        public string ModelHalfName
        {
            get { return _modelHalfName; }
            set { _modelHalfName = value; }
        }
        // --- ADD m.suzuki 2010/04/02 ----------<<<<<

        // --- ADD 2010/04/27 ---------->>>>>
        /// <summary>
        /// 自由検索型式固定番号配列プロパティ
        /// </summary>
        public string[] FreeSrchMdlFxdNoAry
        {
            get { return _freeSrchMdlFxdNoAry; }
            set { _freeSrchMdlFxdNoAry = value; }
        }
        // --- ADD 2010/04/27 ----------<<<<

        // --- ADD 2009/09/08 ----------<<<<<

        // --- ADD 2013/03/21 ---------->>>>>
        /// <summary>
        /// 国産/外車区分プロパティ
        /// </summary>
        public int DomesticForeignCode
        {
            get { return _domesticForeignCode; }
            set { _domesticForeignCode = value; }
        }
        // --- ADD 2013/03/21 ----------<<<<

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public SalesSlipHeaderCopyData()
        {
        }
    }
    # endregion

}
