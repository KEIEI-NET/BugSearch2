using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   OfferPrimeSearchRetWork
    /// <summary>
    ///                      優良ＢＬ検索抽出結果クラスワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   優良ＢＬ検索抽出結果クラスワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :    </br>
    /// <br>Genarated Date   :   2008/12/02  (CSharp File Generated Date)</br>
    /// <br></br>
    /// <br>Update Note      :   検索品名取得カーメーカーコードを追加</br>
    /// <br>Programmer       :   21024　佐々木 健</br>
    /// <br>Date             :   2009/10/22</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class OfferPrimeSearchRetWork
    {
        /// <summary>優良設定詳細コード２</summary>
        private Int32 _prmSetDtlNo2;

        /// <summary>優良品番</summary>
        private string _primePartsNo = "";

        /// <summary>優良部品固有番号</summary>
        private Int64 _prmPartsProperNo;

        /// <summary>部品表示順位</summary>
        /// <remarks>4,5,6,7,8,10,12が同一の結合が複数存在する場合の連番</remarks>
        private Int32 _partsDispOrder;

        /// <summary>セット品番フラグ</summary>
        /// <remarks>0:セット品無し　1:セット品有り</remarks>
        private Int32 _setPartsFlg;

        /// <summary>優良QTY</summary>
        private Double _primeQty;

        /// <summary>優良特記事項</summary>
        private string _primeSpecialNote = "";

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

        /// <summary>提供日付</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _offerDate;

        /// <summary>商品中分類コード</summary>
        /// <remarks>※中分類</remarks>
        private Int32 _goodsMGroup;

        /// <summary>BLコード</summary>
        /// <remarks>曖昧検索で優良設定マスタをチェック</remarks>
        private Int32 _tbsPartsCode;

        /// <summary>BLコード枝番</summary>
        /// <remarks>※未使用項目（レイアウトには入れておく）</remarks>
        private Int32 _tbsPartsCdDerivedNo;

        /// <summary>優良設定詳細コード１</summary>
        /// <remarks>曖昧検索で優良設定マスタをチェック</remarks>
        private Int32 _prmSetDtlNo1;

        /// <summary>部品メーカーコード</summary>
        /// <remarks>曖昧検索で優良設定マスタをチェック</remarks>
        private Int32 _partsMakerCd;

        /// <summary>優良品番(－付き品番)</summary>
        /// <remarks>ハイフン付き</remarks>
        private string _primePartsNoWithH = "";

        /// <summary>優良品番(－無し品番)</summary>
        /// <remarks>ハイフン無し</remarks>
        private string _primePartsNoNoneH = "";

        /// <summary>優良部品名称</summary>
        private string _primePartsName = "";

        /// <summary>優良部品カナ名称</summary>
        /// <remarks>半角カナ</remarks>
        private string _primePartsKanaNm = "";

        /// <summary>層別コード</summary>
        private string _partsLayerCd = "";

        /// <summary>優良部品規格・特記事項</summary>
        private string _primePartsSpecialNote = "";

        /// <summary>部品属性</summary>
        /// <remarks>0:純正 や優良、用品などを区別するための属性</remarks>
        private Int32 _partsAttribute;

        /// <summary>カタログ削除フラグ</summary>
        private Int32 _catalogDeleteFlag;

        /// <summary>優良部品イラストコード</summary>
        private string _prmPartsIllustC = "";

        /// <summary>代替フラグ</summary>
        /// <remarks>0:一般　1:代替</remarks>
        private Int32 _substFlag;

        /// <summary>検索品名（全角）</summary>
        private string _searchPartsFullName = "";

        /// <summary>検索品名（半角）</summary>
        private string _searchPartsHalfName = "";

        /// <summary>型式グレード名称</summary>
        private string _modelGradeNm = "";

        /// <summary>ボディー名称</summary>
        private string _bodyName = "";

        /// <summary>ドア数</summary>
        private Int32 _doorCount;

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
        private string _wheelDriveMethodNm = "";

        // 2009/10/22 Add >>>
        /// <summary>検索品名取得カーメーカーコード</summary>
        private Int32 _srchPNmAcqrCarMkrCd;
        // 2009/10/22 Add <<<

        /// public propaty name  :  PrmSetDtlNo2
        /// <summary>優良設定詳細コード２プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   優良設定詳細コード２プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PrmSetDtlNo2
        {
            get { return _prmSetDtlNo2; }
            set { _prmSetDtlNo2 = value; }
        }

        /// public propaty name  :  PrimePartsNo
        /// <summary>優良品番プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   優良品番プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PrimePartsNo
        {
            get { return _primePartsNo; }
            set { _primePartsNo = value; }
        }

        /// public propaty name  :  PrmPartsProperNo
        /// <summary>優良部品固有番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   優良部品固有番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 PrmPartsProperNo
        {
            get { return _prmPartsProperNo; }
            set { _prmPartsProperNo = value; }
        }

        /// public propaty name  :  PartsDispOrder
        /// <summary>部品表示順位プロパティ</summary>
        /// <value>4,5,6,7,8,10,12が同一の結合が複数存在する場合の連番</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   部品表示順位プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PartsDispOrder
        {
            get { return _partsDispOrder; }
            set { _partsDispOrder = value; }
        }

        /// public propaty name  :  SetPartsFlg
        /// <summary>セット品番フラグプロパティ</summary>
        /// <value>0:セット品無し　1:セット品有り</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   セット品番フラグプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SetPartsFlg
        {
            get { return _setPartsFlg; }
            set { _setPartsFlg = value; }
        }

        /// public propaty name  :  PrimeQty
        /// <summary>優良QTYプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   優良QTYプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double PrimeQty
        {
            get { return _primeQty; }
            set { _primeQty = value; }
        }

        /// public propaty name  :  PrimeSpecialNote
        /// <summary>優良特記事項プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   優良特記事項プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PrimeSpecialNote
        {
            get { return _primeSpecialNote; }
            set { _primeSpecialNote = value; }
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

        /// public propaty name  :  OfferDate
        /// <summary>提供日付プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   提供日付プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime OfferDate
        {
            get { return _offerDate; }
            set { _offerDate = value; }
        }

        /// public propaty name  :  GoodsMGroup
        /// <summary>商品中分類コードプロパティ</summary>
        /// <value>※中分類</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品中分類コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsMGroup
        {
            get { return _goodsMGroup; }
            set { _goodsMGroup = value; }
        }

        /// public propaty name  :  TbsPartsCode
        /// <summary>BLコードプロパティ</summary>
        /// <value>曖昧検索で優良設定マスタをチェック</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BLコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 TbsPartsCode
        {
            get { return _tbsPartsCode; }
            set { _tbsPartsCode = value; }
        }

        /// public propaty name  :  TbsPartsCdDerivedNo
        /// <summary>BLコード枝番プロパティ</summary>
        /// <value>※未使用項目（レイアウトには入れておく）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BLコード枝番プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 TbsPartsCdDerivedNo
        {
            get { return _tbsPartsCdDerivedNo; }
            set { _tbsPartsCdDerivedNo = value; }
        }

        /// public propaty name  :  PrmSetDtlNo1
        /// <summary>優良設定詳細コード１プロパティ</summary>
        /// <value>曖昧検索で優良設定マスタをチェック</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   優良設定詳細コード１プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PrmSetDtlNo1
        {
            get { return _prmSetDtlNo1; }
            set { _prmSetDtlNo1 = value; }
        }

        /// public propaty name  :  PartsMakerCd
        /// <summary>部品メーカーコードプロパティ</summary>
        /// <value>曖昧検索で優良設定マスタをチェック</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   部品メーカーコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PartsMakerCd
        {
            get { return _partsMakerCd; }
            set { _partsMakerCd = value; }
        }

        /// public propaty name  :  PrimePartsNoWithH
        /// <summary>優良品番(－付き品番)プロパティ</summary>
        /// <value>ハイフン付き</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   優良品番(－付き品番)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PrimePartsNoWithH
        {
            get { return _primePartsNoWithH; }
            set { _primePartsNoWithH = value; }
        }

        /// public propaty name  :  PrimePartsNoNoneH
        /// <summary>優良品番(－無し品番)プロパティ</summary>
        /// <value>ハイフン無し</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   優良品番(－無し品番)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PrimePartsNoNoneH
        {
            get { return _primePartsNoNoneH; }
            set { _primePartsNoNoneH = value; }
        }

        /// public propaty name  :  PrimePartsName
        /// <summary>優良部品名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   優良部品名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PrimePartsName
        {
            get { return _primePartsName; }
            set { _primePartsName = value; }
        }

        /// public propaty name  :  PrimePartsKanaNm
        /// <summary>優良部品カナ名称プロパティ</summary>
        /// <value>半角カナ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   優良部品カナ名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PrimePartsKanaNm
        {
            get { return _primePartsKanaNm; }
            set { _primePartsKanaNm = value; }
        }

        /// public propaty name  :  PartsLayerCd
        /// <summary>層別コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   層別コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PartsLayerCd
        {
            get { return _partsLayerCd; }
            set { _partsLayerCd = value; }
        }

        /// public propaty name  :  PrimePartsSpecialNote
        /// <summary>優良部品規格・特記事項プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   優良部品規格・特記事項プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PrimePartsSpecialNote
        {
            get { return _primePartsSpecialNote; }
            set { _primePartsSpecialNote = value; }
        }

        /// public propaty name  :  PartsAttribute
        /// <summary>部品属性プロパティ</summary>
        /// <value>0:純正 や優良、用品などを区別するための属性</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   部品属性プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PartsAttribute
        {
            get { return _partsAttribute; }
            set { _partsAttribute = value; }
        }

        /// public propaty name  :  CatalogDeleteFlag
        /// <summary>カタログ削除フラグプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   カタログ削除フラグプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CatalogDeleteFlag
        {
            get { return _catalogDeleteFlag; }
            set { _catalogDeleteFlag = value; }
        }

        /// public propaty name  :  PrmPartsIllustC
        /// <summary>優良部品イラストコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   優良部品イラストコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PrmPartsIllustC
        {
            get { return _prmPartsIllustC; }
            set { _prmPartsIllustC = value; }
        }

        /// public propaty name  :  SubstFlag
        /// <summary>代替フラグプロパティ</summary>
        /// <value>0:一般　1:代替</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   代替フラグプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SubstFlag
        {
            get { return _substFlag; }
            set { _substFlag = value; }
        }

        /// public propaty name  :  SearchPartsFullName
        /// <summary>検索品名（全角）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   検索品名（全角）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SearchPartsFullName
        {
            get { return _searchPartsFullName; }
            set { _searchPartsFullName = value; }
        }

        /// public propaty name  :  SearchPartsHalfName
        /// <summary>検索品名（半角）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   検索品名（半角）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SearchPartsHalfName
        {
            get { return _searchPartsHalfName; }
            set { _searchPartsHalfName = value; }
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

        // 2009/10/22 Add >>>
        /// <summary>
        /// 検索品名取得カーメーカーコード
        /// </summary>
        public Int32 SrchPNmAcqrCarMkrCd
        {
            get { return _srchPNmAcqrCarMkrCd; }
            set { _srchPNmAcqrCarMkrCd = value; }
        }    
        // 2009/10/22 Add <<<


        /// <summary>
        /// 優良ＢＬ検索抽出結果クラスワークコンストラクタ
        /// </summary>
        /// <returns>OfferPrimeSearchRetWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   OfferPrimeSearchRetWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public OfferPrimeSearchRetWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>OfferPrimeSearchRetWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   OfferPrimeSearchRetWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// <br></br>
    /// <br>Update Note      :   検索品名取得カーメーカーコードを追加</br>
    /// <br>Programmer       :   21024　佐々木 健</br>
    /// <br>Date             :   2009/10/22</br>
    /// </remarks>
    public class OfferPrimeSearchRetWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   OfferPrimeSearchRetWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  OfferPrimeSearchRetWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is OfferPrimeSearchRetWork || graph is ArrayList || graph is OfferPrimeSearchRetWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(OfferPrimeSearchRetWork).FullName));

            if (graph != null && graph is OfferPrimeSearchRetWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.OfferPrimeSearchRetWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is OfferPrimeSearchRetWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((OfferPrimeSearchRetWork[])graph).Length;
            }
            else if (graph is OfferPrimeSearchRetWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //優良設定詳細コード２
            serInfo.MemberInfo.Add(typeof(Int32)); //PrmSetDtlNo2
            //優良品番
            serInfo.MemberInfo.Add(typeof(string)); //PrimePartsNo
            //優良部品固有番号
            serInfo.MemberInfo.Add(typeof(Int64)); //PrmPartsProperNo
            //部品表示順位
            serInfo.MemberInfo.Add(typeof(Int32)); //PartsDispOrder
            //セット品番フラグ
            serInfo.MemberInfo.Add(typeof(Int32)); //SetPartsFlg
            //優良QTY
            serInfo.MemberInfo.Add(typeof(Double)); //PrimeQty
            //優良特記事項
            serInfo.MemberInfo.Add(typeof(string)); //PrimeSpecialNote
            //開始生産年式
            serInfo.MemberInfo.Add(typeof(Int32)); //StProduceTypeOfYear
            //終了生産年式
            serInfo.MemberInfo.Add(typeof(Int32)); //EdProduceTypeOfYear
            //生産車台番号開始
            serInfo.MemberInfo.Add(typeof(Int32)); //StProduceFrameNo
            //生産車台番号終了
            serInfo.MemberInfo.Add(typeof(Int32)); //EdProduceFrameNo
            //提供日付
            serInfo.MemberInfo.Add(typeof(Int64)); //OfferDate
            //商品中分類コード
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMGroup
            //BLコード
            serInfo.MemberInfo.Add(typeof(Int32)); //TbsPartsCode
            //BLコード枝番
            serInfo.MemberInfo.Add(typeof(Int32)); //TbsPartsCdDerivedNo
            //優良設定詳細コード１
            serInfo.MemberInfo.Add(typeof(Int32)); //PrmSetDtlNo1
            //部品メーカーコード
            serInfo.MemberInfo.Add(typeof(Int32)); //PartsMakerCd
            //優良品番(－付き品番)
            serInfo.MemberInfo.Add(typeof(string)); //PrimePartsNoWithH
            //優良品番(－無し品番)
            serInfo.MemberInfo.Add(typeof(string)); //PrimePartsNoNoneH
            //優良部品名称
            serInfo.MemberInfo.Add(typeof(string)); //PrimePartsName
            //優良部品カナ名称
            serInfo.MemberInfo.Add(typeof(string)); //PrimePartsKanaNm
            //層別コード
            serInfo.MemberInfo.Add(typeof(string)); //PartsLayerCd
            //優良部品規格・特記事項
            serInfo.MemberInfo.Add(typeof(string)); //PrimePartsSpecialNote
            //部品属性
            serInfo.MemberInfo.Add(typeof(Int32)); //PartsAttribute
            //カタログ削除フラグ
            serInfo.MemberInfo.Add(typeof(Int32)); //CatalogDeleteFlag
            //優良部品イラストコード
            serInfo.MemberInfo.Add(typeof(string)); //PrmPartsIllustC
            //代替フラグ
            serInfo.MemberInfo.Add(typeof(Int32)); //SubstFlag
            //検索品名（全角）
            serInfo.MemberInfo.Add(typeof(string)); //SearchPartsFullName
            //検索品名（半角）
            serInfo.MemberInfo.Add(typeof(string)); //SearchPartsHalfName
            //型式グレード名称
            serInfo.MemberInfo.Add(typeof(string)); //ModelGradeNm
            //ボディー名称
            serInfo.MemberInfo.Add(typeof(string)); //BodyName
            //ドア数
            serInfo.MemberInfo.Add(typeof(Int32)); //DoorCount
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
            // 2009/10/22 Add >>>
            // 検索品名取得カーメーカーコード
            serInfo.MemberInfo.Add(typeof(Int32));  //SrchPNmAcqrCarMkrCd
            // 2009/10/22 Add <<<


            serInfo.Serialize(writer, serInfo);
            if (graph is OfferPrimeSearchRetWork)
            {
                OfferPrimeSearchRetWork temp = (OfferPrimeSearchRetWork)graph;

                SetOfferPrimeSearchRetWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is OfferPrimeSearchRetWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((OfferPrimeSearchRetWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (OfferPrimeSearchRetWork temp in lst)
                {
                    SetOfferPrimeSearchRetWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// OfferPrimeSearchRetWorkメンバ数(publicプロパティ数)
        /// </summary>
        // 2009/10/22 >>>
        //private const int currentMemberCount = 38;
        private const int currentMemberCount = 39;
        // 2009/10/22 <<<

        /// <summary>
        ///  OfferPrimeSearchRetWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   OfferPrimeSearchRetWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetOfferPrimeSearchRetWork(System.IO.BinaryWriter writer, OfferPrimeSearchRetWork temp)
        {
            //優良設定詳細コード２
            writer.Write(temp.PrmSetDtlNo2);
            //優良品番
            writer.Write(temp.PrimePartsNo);
            //優良部品固有番号
            writer.Write(temp.PrmPartsProperNo);
            //部品表示順位
            writer.Write(temp.PartsDispOrder);
            //セット品番フラグ
            writer.Write(temp.SetPartsFlg);
            //優良QTY
            writer.Write(temp.PrimeQty);
            //優良特記事項
            writer.Write(temp.PrimeSpecialNote);
            //開始生産年式
            writer.Write(temp.StProduceTypeOfYear);
            //終了生産年式
            writer.Write(temp.EdProduceTypeOfYear);
            //生産車台番号開始
            writer.Write(temp.StProduceFrameNo);
            //生産車台番号終了
            writer.Write(temp.EdProduceFrameNo);
            //提供日付
            writer.Write(temp.OfferDate.Ticks);
            //商品中分類コード
            writer.Write(temp.GoodsMGroup);
            //BLコード
            writer.Write(temp.TbsPartsCode);
            //BLコード枝番
            writer.Write(temp.TbsPartsCdDerivedNo);
            //優良設定詳細コード１
            writer.Write(temp.PrmSetDtlNo1);
            //部品メーカーコード
            writer.Write(temp.PartsMakerCd);
            //優良品番(－付き品番)
            writer.Write(temp.PrimePartsNoWithH);
            //優良品番(－無し品番)
            writer.Write(temp.PrimePartsNoNoneH);
            //優良部品名称
            writer.Write(temp.PrimePartsName);
            //優良部品カナ名称
            writer.Write(temp.PrimePartsKanaNm);
            //層別コード
            writer.Write(temp.PartsLayerCd);
            //優良部品規格・特記事項
            writer.Write(temp.PrimePartsSpecialNote);
            //部品属性
            writer.Write(temp.PartsAttribute);
            //カタログ削除フラグ
            writer.Write(temp.CatalogDeleteFlag);
            //優良部品イラストコード
            writer.Write(temp.PrmPartsIllustC);
            //代替フラグ
            writer.Write(temp.SubstFlag);
            //検索品名（全角）
            writer.Write(temp.SearchPartsFullName);
            //検索品名（半角）
            writer.Write(temp.SearchPartsHalfName);
            //型式グレード名称
            writer.Write(temp.ModelGradeNm);
            //ボディー名称
            writer.Write(temp.BodyName);
            //ドア数
            writer.Write(temp.DoorCount);
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
            // 2009/10/22 Add >>>
            //検索品名取得カーメーカーコード
            writer.Write(temp.SrchPNmAcqrCarMkrCd);
            // 2009/10/22 Add <<<
        }

        /// <summary>
        ///  OfferPrimeSearchRetWorkインスタンス取得
        /// </summary>
        /// <returns>OfferPrimeSearchRetWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   OfferPrimeSearchRetWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private OfferPrimeSearchRetWork GetOfferPrimeSearchRetWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            OfferPrimeSearchRetWork temp = new OfferPrimeSearchRetWork();

            //優良設定詳細コード２
            temp.PrmSetDtlNo2 = reader.ReadInt32();
            //優良品番
            temp.PrimePartsNo = reader.ReadString();
            //優良部品固有番号
            temp.PrmPartsProperNo = reader.ReadInt64();
            //部品表示順位
            temp.PartsDispOrder = reader.ReadInt32();
            //セット品番フラグ
            temp.SetPartsFlg = reader.ReadInt32();
            //優良QTY
            temp.PrimeQty = reader.ReadDouble();
            //優良特記事項
            temp.PrimeSpecialNote = reader.ReadString();
            //開始生産年式
            temp.StProduceTypeOfYear = reader.ReadInt32();
            //終了生産年式
            temp.EdProduceTypeOfYear = reader.ReadInt32();
            //生産車台番号開始
            temp.StProduceFrameNo = reader.ReadInt32();
            //生産車台番号終了
            temp.EdProduceFrameNo = reader.ReadInt32();
            //提供日付
            temp.OfferDate = new DateTime(reader.ReadInt64());
            //商品中分類コード
            temp.GoodsMGroup = reader.ReadInt32();
            //BLコード
            temp.TbsPartsCode = reader.ReadInt32();
            //BLコード枝番
            temp.TbsPartsCdDerivedNo = reader.ReadInt32();
            //優良設定詳細コード１
            temp.PrmSetDtlNo1 = reader.ReadInt32();
            //部品メーカーコード
            temp.PartsMakerCd = reader.ReadInt32();
            //優良品番(－付き品番)
            temp.PrimePartsNoWithH = reader.ReadString();
            //優良品番(－無し品番)
            temp.PrimePartsNoNoneH = reader.ReadString();
            //優良部品名称
            temp.PrimePartsName = reader.ReadString();
            //優良部品カナ名称
            temp.PrimePartsKanaNm = reader.ReadString();
            //層別コード
            temp.PartsLayerCd = reader.ReadString();
            //優良部品規格・特記事項
            temp.PrimePartsSpecialNote = reader.ReadString();
            //部品属性
            temp.PartsAttribute = reader.ReadInt32();
            //カタログ削除フラグ
            temp.CatalogDeleteFlag = reader.ReadInt32();
            //優良部品イラストコード
            temp.PrmPartsIllustC = reader.ReadString();
            //代替フラグ
            temp.SubstFlag = reader.ReadInt32();
            //検索品名（全角）
            temp.SearchPartsFullName = reader.ReadString();
            //検索品名（半角）
            temp.SearchPartsHalfName = reader.ReadString();
            //型式グレード名称
            temp.ModelGradeNm = reader.ReadString();
            //ボディー名称
            temp.BodyName = reader.ReadString();
            //ドア数
            temp.DoorCount = reader.ReadInt32();
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
            // 2009/10/22 Add >>>
            //検索品名取得カーメーカーコード
            temp.SrchPNmAcqrCarMkrCd = reader.ReadInt32();
            // 2009/10/22 Add <<<


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
        /// <returns>OfferPrimeSearchRetWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   OfferPrimeSearchRetWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                OfferPrimeSearchRetWork temp = GetOfferPrimeSearchRetWork(reader, serInfo);
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
                    retValue = (OfferPrimeSearchRetWork[])lst.ToArray(typeof(OfferPrimeSearchRetWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

}