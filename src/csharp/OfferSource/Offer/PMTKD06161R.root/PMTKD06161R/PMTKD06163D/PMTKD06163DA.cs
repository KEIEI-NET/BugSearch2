//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 部品情報取得（提供）
// プログラム概要   : 部品情報取得（提供）データパラメータ
//----------------------------------------------------------------------------//
//                (c)Copyright  2018 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号 :              作成担当 : 30290
// 作 成 日 : 2005/04/14   修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号 : 11470007-00  作成担当 : 30757 佐々木　貴英
// 作 成 日 : 2018/03/26   修正内容 : NS3Ai対応（BL統一部品コード対応）
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Collections.Generic;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    #region [ 部品情報結果格納クラス ]
    /// <summary>
    ///                      部品情報結果格納クラス
    /// </summary>
    /// <remarks>
    /// <br>Date             :   2005/04/14</br>
    /// <br>Genarated Date   :   2005/04/14</br>
    /// <br>Update Note      :   20060710 iwa ＴＳＰ対応　品番をパラメータに追加</br>
    /// <br>Update Note      :   2009/10/23　21024 佐々木 検索品名取得カーメーカーコードを追加</br>
    /// <br>Update Note      :   2013/02/12　20056 對馬 大輔 優良結合連携フラグ追加(ダミー品番判別用)</br>
    /// <br>Update Note      :   2013/03/25  FSI斎藤 和宏 VIN生産No.(始期)・VIN生産No.(終期)を追加(SPK車台番号文字列対応)</br>
    /// <br>Update Note      :   2018/03/26  30757 佐々木　貴英</br>
    /// <br>管理番号         :   11470007-00</br>
    /// <br>                 :   NS3Ai対応（BL統一部品コード対応）</br>
    /// <br>                     BL統一部品コード関連メンバーの追加</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class RetPartsInf
    {
        /// <summary>提供日付</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _offerDate;
        /// <summary>
        /// 部品検索区分
        /// </summary>
        private int _PartsSearchCode;
        ///<summary>部品絞込み区分 0:生産年式 1:シャシーNO</summary>
        private int _PartsNarrowingCode;
        /// <summary>部品名称</summary>
        private string _partsName = "";
        /// <summary>部品名称カナ</summary>
        private string _partsNameKana = "";
        /// <summary>作業部品区分ｺｰﾄﾞ</summary>
        private Int32 _partsCode;
        /// <summary>作業部品区分名称</summary>
        private string _workOrPartsDivNm = "";
        /// <summary>フル型式固定番号</summary>
        private Int32 _fullModelFixedNo;
        /// <summary>翼部品コード</summary>
        /// <remarks>1～99999:提供分,100000～ユーザー登録用</remarks>
        private Int32 _tbsPartsCode;
        /// <summary>翼部品コード枝番</summary>
        private Int32 _tbsPartsCdDerivedNo;
        /// <summary>Fig図番</summary>
        /// <remarks>イラストの図番と連携</remarks>
        private string _figshapeNo = "";
        /// <summary>型式別部品採用年月</summary>
        /// <remarks>YYYYMM</remarks>
        private Int32 _modelPrtsAdptYm;
        /// <summary>型式別部品廃止年月</summary>
        /// <remarks>YYYYMM</remarks>
        private Int32 _modelPrtsAblsYm;
        /// <summary>型式別部品採用車台番号</summary>
        private Int32 _modelPrtsAdptFrameNo;
        /// <summary>型式別部品廃止車台番号</summary>
        private Int32 _modelPrtsAblsFrameNo;
        /// <summary>部品QTY</summary>
        private Double _partsQty;
        /// <summary>部品オプション名称</summary>
        private string _partsOpNm = "";
        /// <summary>規格名称</summary>
        private string _standardName = "";
        /// <summary>カタログ部品メーカーコード</summary>
        private Int32 _catalogPartsMakerCd;
        /// <summary>ハイフン付カタログ部品品番</summary>
        private string _clgPrtsNoWithHyphen = "";
        /// <summary>寒冷地フラグ</summary>
        /// <remarks>0:通常部品,1:寒冷地仕様,9:共通部品</remarks>
        private Int32 _coldDistrictsFlag;
        /// <summary>カラー絞込フラグ</summary>
        /// <remarks>0:カラー情報なし,1:カラー情報あり</remarks>
        private Int32 _colorNarrowingFlag;
        /// <summary>トリム絞込フラグ</summary>
        /// <remarks>0:トリム情報なし,1:トリム情報あり</remarks>
        private Int32 _trimNarrowingFlag;
        /// <summary>装備絞込フラグ</summary>
        /// <remarks>0:装備情報なし,1:装備情報あり</remarks>
        private Int32 _equipNarrowingFlag;
        /// <summary>ハイフン付最新部品品番</summary>
        private string _newPrtsNoWithHyphen = "";
        /// <summary>ハイフン無最新部品品番</summary>
        private string _newPrtsNoNoneHyphen = "";
        /// <summary>メーカー別部品名称</summary>
        private string _makerOfferPartsName = "";
        /// <summary>部品提供日付</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _priceOfferDate;
        /// <summary>部品価格</summary>
        private Int64 _partsPrice;
        /// <summary>部品開始日</summary>
        private DateTime _partsPriceStDate;
        /// <summary>層別コード</summary>
        private string _partsLayerCd = "";
        /// <summary>部品固有番号</summary>
        private Int64 _PartsUniqueNo;
        /// <summary>メーカー提供部品カナ名称</summary>
        private string _makerOfferPartsKana = "";
        /// <summary>オープン価格区分</summary>
        private Int32 _openPriceDiv;
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.07.23 ADD
        /// <summary>シリーズ型式（型式１）</summary>
        private string _seriesModel = "";
        /// <summary>型式（類別記号）（型式２）</summary>
        private string _categorySignModel = "";
        /// <summary>排ガス記号（型式０）</summary>
        private string _exhaustGasSign = "";
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.07.23 ADD
        // 2009/10/23 Add >>>
        /// <summary>検索品名取得カーメーカーコード</summary>
        private Int32 _srchPNmAcqrCarMkrCd;
        // 2009/10/23 Add <<<
        // --- ADD m.suzuki 2011/05/18 ---------->>>>>
        /// <summary>自動見積部品コード</summary>
        private string _autoEstimatePartsCd = "";
        /// <summary>BL部品コード枝番用部品名称</summary>
        private string _tbsPartsCdDerivedNm = "";
        // --- ADD m.suzuki 2011/05/18 ----------<<<<<
        //>>>2013/02/12
        /// <summary>優良結合連携フラグ</summary>
        private Int32 _primeJoinLnkFlg;
        //<<<2013/02/12

        // --- ADD 2013/03/25 ---------->>>>>
        /// <summary>VIN生産No.(始期)</summary>
        private Int32 _vinProduceStartNo;
        /// <summary>VIN生産No.(終期)</summary>
        private Int32 _vinProduceEndNo;
        // --- ADD 2013/03/25 ----------<<<<<

        // ----ADD 2018/03/26 30757 佐々木　貴英 11470007-00 NS3Ai対応（BL統一部品コード対応） ------->>>>>
        /// <summary>BL統一部品コード(スリーコード版)</summary>
        private string _blUtyPtThCd = string.Empty;
        /// <summary>BL統一部品コード</summary>
        private string _blUtyPtCd = string.Empty;
        /// <summary>BL統一部品サブコード</summary>
        private Int32  _blUtyPtSbCd = 0;
        // ----ADD 2018/03/26 30757 佐々木　貴英 11470007-00 NS3Ai対応（BL統一部品コード対応） -------<<<<<

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
        /// public propaty name  :  PartsSearchCode
        /// <summary>部品検索区分</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   部品検索区分</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public int PartsSearchCode
        {
            get { return _PartsSearchCode; }
            set { _PartsSearchCode = value; }
        }
        /// public propaty name  :  PartsNarrowingCode
        /// <summary>デフォルトチェック区分(作業レコード区分が1,2の場合に使用。デフォルトチェックの見分け1の場合は最高点数加算)</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   デフォルトチェック区分</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public int PartsNarrowingCode
        {
            get { return _PartsNarrowingCode; }
            set { _PartsNarrowingCode = value; }
        }
        /// public propaty name  :  PartsName
        /// <summary>部品名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   部品名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PartsName
        {
            get { return _partsName; }
            set { _partsName = value; }
        }
        /// public propaty name  :  PartsNameKana
        /// <summary>部品名称カナプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   部品名称カナプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PartsNameKana
        {
            get { return _partsNameKana; }
            set { _partsNameKana = value; }
        }
        /// public propaty name  :  _partsCode
        /// <summary>作業部品区分名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   フル型式固定番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string WorkOrPartsDivNm
        {
            get { return _workOrPartsDivNm; }
            set { _workOrPartsDivNm = value; }
        }
        /// public propaty name  :  _partsCode
        /// <summary>作業部品区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   フル型式固定番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PartsCode
        {
            get { return _partsCode; }
            set { _partsCode = value; }
        }
        /// public propaty name  :  FullModelFixedNo
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
        /// public propaty name  :  TbsPartsCode
        /// <summary>翼部品コードプロパティ</summary>
        /// <value>1～99999:提供分,100000～ユーザー登録用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   翼部品コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 TbsPartsCode
        {
            get { return _tbsPartsCode; }
            set { _tbsPartsCode = value; }
        }
        /// public propaty name  :  TbsPartsCdDerivedNo
        /// <summary>翼部品コード枝番プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   翼部品コード枝番プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 TbsPartsCdDerivedNo
        {
            get { return _tbsPartsCdDerivedNo; }
            set { _tbsPartsCdDerivedNo = value; }
        }
        /// public propaty name  :  FigShapeNo
        /// <summary>Fig図番プロパティ</summary>
        /// <value>イラストの図番と連携</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   Fig図番プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string FigShapeNo
        {
            get { return _figshapeNo; }
            set { _figshapeNo = value; }
        }
        /// public propaty name  :  ModelPrtsAdptYm
        /// <summary>型式別部品採用年月プロパティ</summary>
        /// <value>YYYYMM</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   型式別部品採用年月プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ModelPrtsAdptYm
        {
            get { return _modelPrtsAdptYm; }
            set { _modelPrtsAdptYm = value; }
        }
        /// public propaty name  :  ModelPrtsAblsYm
        /// <summary>型式別部品廃止年月プロパティ</summary>
        /// <value>YYYYMM</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   型式別部品廃止年月プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ModelPrtsAblsYm
        {
            get { return _modelPrtsAblsYm; }
            set { _modelPrtsAblsYm = value; }
        }
        /// public propaty name  :  ModelPrtsAdptFrameNo
        /// <summary>型式別部品採用車台番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   型式別部品採用車台番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ModelPrtsAdptFrameNo
        {
            get { return _modelPrtsAdptFrameNo; }
            set { _modelPrtsAdptFrameNo = value; }
        }
        /// public propaty name  :  ModelPrtsAblsFrameNo
        /// <summary>型式別部品廃止車台番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   型式別部品廃止車台番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ModelPrtsAblsFrameNo
        {
            get { return _modelPrtsAblsFrameNo; }
            set { _modelPrtsAblsFrameNo = value; }
        }
        /// public propaty name  :  PartsQty
        /// <summary>部品QTYプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   部品QTYプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double PartsQty
        {
            get { return _partsQty; }
            set { _partsQty = value; }
        }
        /// public propaty name  :  PartsOpNm
        /// <summary>部品オプション名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   部品オプション名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PartsOpNm
        {
            get { return _partsOpNm; }
            set { _partsOpNm = value; }
        }
        /// public propaty name  :  StandardName
        /// <summary>規格名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   規格名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string StandardName
        {
            get { return _standardName; }
            set { _standardName = value; }
        }
        /// public propaty name  :  CatalogPartsMakerCd
        /// <summary>カタログ部品メーカーコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   カタログ部品メーカーコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CatalogPartsMakerCd
        {
            get { return _catalogPartsMakerCd; }
            set { _catalogPartsMakerCd = value; }
        }
        /// public propaty name  :  ClgPrtsNoWithHyphen
        /// <summary>ハイフン付カタログ部品品番プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ハイフン付カタログ部品品番プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ClgPrtsNoWithHyphen
        {
            get { return _clgPrtsNoWithHyphen; }
            set { _clgPrtsNoWithHyphen = value; }
        }
        /// public propaty name  :  ColdDistrictsFlag
        /// <summary>寒冷地フラグプロパティ</summary>
        /// <value>0:通常部品,1:寒冷地仕様,9:共通部品</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   寒冷地フラグプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ColdDistrictsFlag
        {
            get { return _coldDistrictsFlag; }
            set { _coldDistrictsFlag = value; }
        }
        /// public propaty name  :  ColorNarrowingFlag
        /// <summary>カラー絞込フラグプロパティ</summary>
        /// <value>0:カラー情報なし,1:カラー情報あり</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   カラー絞込フラグプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ColorNarrowingFlag
        {
            get { return _colorNarrowingFlag; }
            set { _colorNarrowingFlag = value; }
        }
        /// public propaty name  :  TrimNarrowingFlag
        /// <summary>トリム絞込フラグプロパティ</summary>
        /// <value>0:トリム情報なし,1:トリム情報あり</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   トリム絞込フラグプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 TrimNarrowingFlag
        {
            get { return _trimNarrowingFlag; }
            set { _trimNarrowingFlag = value; }
        }
        /// public propaty name  :  EquipNarrowingFlag
        /// <summary>装備絞込フラグプロパティ</summary>
        /// <value>0:装備情報なし,1:装備情報あり</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   装備絞込フラグプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 EquipNarrowingFlag
        {
            get { return _equipNarrowingFlag; }
            set { _equipNarrowingFlag = value; }
        }
        /// public propaty name  :  NewPrtsNoWithHyphen
        /// <summary>ハイフン付最新部品品番プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ハイフン付最新部品品番プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string NewPrtsNoWithHyphen
        {
            get { return _newPrtsNoWithHyphen; }
            set { _newPrtsNoWithHyphen = value; }
        }
        /// public propaty name  :  NewPrtsNoNoneHyphen
        /// <summary>ハイフン無最新部品品番プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ハイフン無最新部品品番プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string NewPrtsNoNoneHyphen
        {
            get { return _newPrtsNoNoneHyphen; }
            set { _newPrtsNoNoneHyphen = value; }
        }
        /// public propaty name  :  MakerOfferPartsName
        /// <summary>メーカー別部品名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メーカー別部品名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MakerOfferPartsName
        {
            get { return _makerOfferPartsName; }
            set { _makerOfferPartsName = value; }
        }
        /// public propaty name  :  PriceOfferDate
        /// <summary>価格提供日付プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   価格提供日付プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime PriceOfferDate
        {
            get { return _priceOfferDate; }
            set { _priceOfferDate = value; }
        }
        /// public propaty name  :  PartsPrice
        /// <summary>部品価格プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   部品価格プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 PartsPrice
        {
            get { return _partsPrice; }
            set { _partsPrice = value; }
        }
        /// public propaty name  :  PartsPriceStDate
        /// <summary>部品価格開始日プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   部品価格開始日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime PartsPriceStDate
        {
            get { return _partsPriceStDate; }
            set { _partsPriceStDate = value; }
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

        /// public propaty name  :  PartsUniqueNo
        /// <summary>部品数量(整備)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   </br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 PartsUniqueNo
        {
            get { return _PartsUniqueNo; }
            set { _PartsUniqueNo = value; }
        }

        /// public propaty name  :  MakerOfferPartsKana
        /// <summary>メーカー提供部品カナ名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   </br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MakerOfferPartsKana
        {
            get { return _makerOfferPartsKana; }
            set { _makerOfferPartsKana = value; }
        }

        /// public propaty name  :  OpenPriceDiv
        /// <summary>オープン価格区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   </br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 OpenPriceDiv
        {
            get { return _openPriceDiv; }
            set { _openPriceDiv = value; }
        }

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.07.23 ADD
        /// <summary>
        /// シリーズ型式（型式１）
        /// </summary>
        public string SeriesModel
        {
            get { return _seriesModel; }
            set { _seriesModel = value; }
        }
        /// <summary>
        /// 型式（類別記号）（型式２）
        /// </summary>
        public string CategorySignModel
        {
            get { return _categorySignModel; }
            set { _categorySignModel = value; }
        }
        /// <summary>
        /// 排ガス記号（型式０）
        /// </summary>
        public string ExhaustGasSign
        {
            get { return _exhaustGasSign; }
            set { _exhaustGasSign = value; }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.07.23 ADD

        // 2009/10/23 Add >>>
        /// <summary>
        /// 検索品名取得カーメーカーコード
        /// </summary>
        public Int32 SrchPNmAcqrCarMkrCd
        {
            get { return _srchPNmAcqrCarMkrCd; }
            set { _srchPNmAcqrCarMkrCd = value; }
        }
        // 2009/10/23 Add <<<

        // --- ADD m.suzuki 2011/05/18 ---------->>>>>
        /// <summary>
        /// 自動見積部品コード
        /// </summary>
        public string AutoEstimatePartsCd
        {
            get { return _autoEstimatePartsCd; }
            set { _autoEstimatePartsCd = value; }
        }
        /// <summary>
        /// BL部品コード枝番用部品名称
        /// </summary>
        public string TbsPartsCdDerivedNm
        {
            get { return _tbsPartsCdDerivedNm; }
            set { _tbsPartsCdDerivedNm = value; }
        }
        // --- ADD m.suzuki 2011/05/18 ----------<<<<<

        //>>>2013/02/12
        /// <summary>
        /// 優良結合連携フラグ
        /// </summary>
        public Int32 PrimeJoinLnkFlg
        {
            get { return _primeJoinLnkFlg; }
            set { _primeJoinLnkFlg = value; }
        }
        //<<<2013/02/12

        // --- ADD 2013/03/25 ---------->>>>>
        /// <summary>VIN生産No.(始期)</summary>
        public Int32 VinProduceStartNo
        {
            get { return _vinProduceStartNo; }
            set { _vinProduceStartNo = value; }
        }
        /// <summary>VIN生産No.(終期)</summary>
        public Int32 VinProduceEndNo
        {
            get { return _vinProduceEndNo; }
            set { _vinProduceEndNo = value; }
        }
        // --- ADD 2013/03/25 ----------<<<<<

        // ----ADD 2018/03/26 30757 佐々木　貴英 11470007-00 NS3Ai対応（BL統一部品コード対応） ------->>>>>
        /// <summary>BL統一部品コード(スリーコード版)パラメータ</summary>
        /// <value>BL統一部品コード(スリーコード版)</value>
        /// <remarks>
        /// <br>Note       : BL統一部品コード(スリーコード版)の取得と設定</br>
        /// <br>Programmer : 30757 佐々木　貴英</br>
        /// <br>Date       : 2018/03/26</br>
        /// <br>管理番号   :   11470007-00</br>
        /// <br>           :   NS3Ai対応（BL統一部品コード対応）</br>
        /// </remarks>
        public string BlUtyPtThCd
        {
            get { return this._blUtyPtThCd; }
            set { this._blUtyPtThCd = value; }
        }
        /// <summary>BL統一部品コードパラメータ</summary>
        /// <value>BL統一部品コード</value>
        /// <remarks>
        /// <br>Note       : BL統一部品コードの取得と設定</br>
        /// <br>Programmer : 30757 佐々木　貴英</br>
        /// <br>Date       : 2018/03/26</br>
        /// <br>管理番号   :   11470007-00</br>
        /// <br>           :   NS3Ai対応（BL統一部品コード対応）</br>
        /// </remarks>
        public string BlUtyPtCd
        {
            get { return this._blUtyPtCd; }
            set { this._blUtyPtCd = value; }
        }
        /// <summary>BL統一部品サブコードパラメータ</summary>
        /// <value>BL統一部品サブコード</value>
        /// <remarks>
        /// <br>Note       : BL統一部品サブコードの取得と設定</br>
        /// <br>Programmer : 30757 佐々木　貴英</br>
        /// <br>Date       : 2018/03/26</br>
        /// <br>管理番号   :   11470007-00</br>
        /// <br>           :   NS3Ai対応（BL統一部品コード対応）</br>
        /// </remarks>
        public Int32 BlUtyPtSbCd
        {
            get { return this._blUtyPtSbCd; }
            set { this._blUtyPtSbCd = value; }
        }
        // ----ADD 2018/03/26 30757 佐々木　貴英 11470007-00 NS3Ai対応（BL統一部品コード対応） -------<<<<<

        /// <summary>
        /// UIクラスワークコンストラクタ
        /// </summary>
        /// <returns>RetPartsInfクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   RetPartsInfクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public RetPartsInf()
        {
        }

        /// <summary>
        /// UIクラスワークコンストラクタ
        /// </summary>
        /// <param name="OfferDate"></param>
        /// <param name="PartsSearchCode"></param>
        /// <param name="PartsNarrowingCode"></param>
        /// <param name="partsName"></param>
        /// <param name="partsNameKana"></param>
        /// <param name="partsCode"></param>
        /// <param name="workOrPartsDivNm"></param>
        /// <param name="fullModelFixedNo">フル型式固定番号</param>
        /// <param name="tbsPartsCode">翼部品コード(1～99999:提供分,100000～ユーザー登録用)</param>
        /// <param name="tbsPartsCdDerivedNo">翼部品コード枝番</param>
        /// <param name="figshapeNo">Fig図番(イラストの図番と連携)</param>
        /// <param name="modelPrtsAdptYm">型式別部品採用年月(YYYYMM)</param>
        /// <param name="modelPrtsAblsYm">型式別部品廃止年月(YYYYMM)</param>
        /// <param name="modelPrtsAdptFrameNo">型式別部品採用車台番号</param>
        /// <param name="modelPrtsAblsFrameNo">型式別部品廃止車台番号</param>
        /// <param name="partsQty">部品QTY</param>
        /// <param name="partsOpNm">部品オプション名称</param>
        /// <param name="standardName">規格名称</param>
        /// <param name="catalogPartsMakerCd">カタログ部品メーカーコード</param>
        /// <param name="clgPrtsNoWithHyphen">ハイフン付カタログ部品品番</param>
        /// <param name="coldDistrictsFlag">寒冷地フラグ(0:通常部品,1:寒冷地仕様,9:共通部品)</param>
        /// <param name="colorNarrowingFlag">カラー絞込フラグ(0:カラー情報なし,1:カラー情報あり)</param>
        /// <param name="trimNarrowingFlag">トリム絞込フラグ(0:トリム情報なし,1:トリム情報あり)</param>
        /// <param name="equipNarrowingFlag">装備絞込フラグ(0:装備情報なし,1:装備情報あり)</param>
        /// <param name="newPrtsNoWithHyphen">ハイフン付最新部品品番</param>
        /// <param name="newPrtsNoNoneHyphen">ハイフン無最新部品品番</param>
        /// <param name="makerOfferPartsName">メーカー別部品名称</param>
        /// <param name="PriceOfferDate">価格提供日付</param>
        /// <param name="partsPrice">部品価格</param>
        /// <param name="partsPriceStDate"></param>
        /// <param name="partsLayerCd">層別コード</param>
        /// <param name="partsUniqueNo"></param>
        /// <param name="makerOfferPartsKana">メーカー提供部品カナ名称</param>
        /// <param name="openPriceDiv">オープン価格区分</param>
        /// <param name="vinProduceStartNo">VIN生産No.(始期)</param>
        /// <param name="vinProduceEndNo">VIN生産No.(終期)</param>
        /// <param name="autoEstimatePartsCd"></param>
        /// <param name="categorySignModel"></param>
        /// <param name="exhaustGasSign"></param>
        /// <param name="primeJoinLnkFlg"></param>
        /// <param name="seriesModel"></param>
        /// <param name="srchPNmAcqrCarMkrCd"></param>
        /// <param name="tbsPartsCdDerivedNm"></param>
        /// <param name="blUtyPtThCd">BL統一部品コード(スリーコード版)</param>
        /// <param name="blUtyPtCd">BL統一部品コード</param>
        /// <param name="blUtyPtSbCd">BL統一部品サブコード</param>
        /// <returns>RetPartsInfクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   RetPartsInfクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// <br />
        /// <br>Update Note      :   2018/03/26  30757 佐々木　貴英</br>
        /// <br>管理番号         :   11470007-00</br>
        /// <br>                 :   NS3Ai対応（BL統一部品コード対応）</br>
        /// <br>                     BL統一部品コード関連メンバーの追加</br>
        /// </remarks>
        //>>>2013/02/12
        //// --- UPD m.suzuki 2011/05/18 ---------->>>>>
        ////// 2009/10/23 >>>
        //////// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.07.23 DEL
        ////////public RetPartsInf(DateTime OfferDate, Int32 PartsSearchCode, Int32 PartsNarrowingCode, string partsName, string partsNameKana,
        ////////    Int32 partsCode, string workOrPartsDivNm, Int32 fullModelFixedNo, Int32 tbsPartsCode, Int32 tbsPartsCdDerivedNo,
        ////////    string figshapeNo, Int32 modelPrtsAdptYm, Int32 modelPrtsAblsYm, Int32 modelPrtsAdptFrameNo,
        ////////    Int32 modelPrtsAblsFrameNo, Double partsQty, string partsOpNm, string standardName, Int32 catalogPartsMakerCd,
        ////////    string clgPrtsNoWithHyphen, Int32 coldDistrictsFlag, Int32 colorNarrowingFlag, Int32 trimNarrowingFlag,
        ////////    Int32 equipNarrowingFlag, string newPrtsNoWithHyphen, string newPrtsNoNoneHyphen, string makerOfferPartsName, DateTime PriceOfferDate,
        ////////    Int64 partsPrice, DateTime partsPriceStDate, string partsLayerCd, Int64 partsUniqueNo, string makerOfferPartsKana, Int32 openPriceDiv)
        //////// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.07.23 DEL
        //////// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.07.23 ADD
        //////public RetPartsInf( DateTime OfferDate, Int32 PartsSearchCode, Int32 PartsNarrowingCode, string partsName, string partsNameKana,
        //////    Int32 partsCode, string workOrPartsDivNm, Int32 fullModelFixedNo, Int32 tbsPartsCode, Int32 tbsPartsCdDerivedNo,
        //////    string figshapeNo, Int32 modelPrtsAdptYm, Int32 modelPrtsAblsYm, Int32 modelPrtsAdptFrameNo,
        //////    Int32 modelPrtsAblsFrameNo, Double partsQty, string partsOpNm, string standardName, Int32 catalogPartsMakerCd,
        //////    string clgPrtsNoWithHyphen, Int32 coldDistrictsFlag, Int32 colorNarrowingFlag, Int32 trimNarrowingFlag,
        //////    Int32 equipNarrowingFlag, string newPrtsNoWithHyphen, string newPrtsNoNoneHyphen, string makerOfferPartsName, DateTime PriceOfferDate,
        //////    Int64 partsPrice, DateTime partsPriceStDate, string partsLayerCd, Int64 partsUniqueNo, string makerOfferPartsKana, Int32 openPriceDiv,
        //////    string seriesModel, string categorySignModel, string exhaustGasSign )
        //////// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.07.23 ADD
        ////public RetPartsInf(DateTime OfferDate, Int32 PartsSearchCode, Int32 PartsNarrowingCode, string partsName, string partsNameKana,
        ////    Int32 partsCode, string workOrPartsDivNm, Int32 fullModelFixedNo, Int32 tbsPartsCode, Int32 tbsPartsCdDerivedNo,
        ////    string figshapeNo, Int32 modelPrtsAdptYm, Int32 modelPrtsAblsYm, Int32 modelPrtsAdptFrameNo,
        ////    Int32 modelPrtsAblsFrameNo, Double partsQty, string partsOpNm, string standardName, Int32 catalogPartsMakerCd,
        ////    string clgPrtsNoWithHyphen, Int32 coldDistrictsFlag, Int32 colorNarrowingFlag, Int32 trimNarrowingFlag,
        ////    Int32 equipNarrowingFlag, string newPrtsNoWithHyphen, string newPrtsNoNoneHyphen, string makerOfferPartsName, DateTime PriceOfferDate,
        ////    Int64 partsPrice, DateTime partsPriceStDate, string partsLayerCd, Int64 partsUniqueNo, string makerOfferPartsKana, Int32 openPriceDiv,
        ////    string seriesModel, string categorySignModel, string exhaustGasSign, Int32 srchPNmAcqrCarMkrCd)
        ////// 2009/10/23 <<<

        //public RetPartsInf(DateTime OfferDate, Int32 PartsSearchCode, Int32 PartsNarrowingCode, string partsName, string partsNameKana,
        //    Int32 partsCode, string workOrPartsDivNm, Int32 fullModelFixedNo, Int32 tbsPartsCode, Int32 tbsPartsCdDerivedNo,
        //    string figshapeNo, Int32 modelPrtsAdptYm, Int32 modelPrtsAblsYm, Int32 modelPrtsAdptFrameNo,
        //    Int32 modelPrtsAblsFrameNo, Double partsQty, string partsOpNm, string standardName, Int32 catalogPartsMakerCd,
        //    string clgPrtsNoWithHyphen, Int32 coldDistrictsFlag, Int32 colorNarrowingFlag, Int32 trimNarrowingFlag,
        //    Int32 equipNarrowingFlag, string newPrtsNoWithHyphen, string newPrtsNoNoneHyphen, string makerOfferPartsName, DateTime PriceOfferDate,
        //    Int64 partsPrice, DateTime partsPriceStDate, string partsLayerCd, Int64 partsUniqueNo, string makerOfferPartsKana, Int32 openPriceDiv,
        //    string seriesModel, string categorySignModel, string exhaustGasSign, Int32 srchPNmAcqrCarMkrCd, string autoEstimatePartsCd, string tbsPartsCdDerivedNm )
        //// --- UPD m.suzuki 2011/05/18 ----------<<<<<

        // --- DEL 2013/03/25 ---------->>>>>
        //public RetPartsInf(DateTime OfferDate, Int32 PartsSearchCode, Int32 PartsNarrowingCode, string partsName, string partsNameKana,
        //    Int32 partsCode, string workOrPartsDivNm, Int32 fullModelFixedNo, Int32 tbsPartsCode, Int32 tbsPartsCdDerivedNo,
        //    string figshapeNo, Int32 modelPrtsAdptYm, Int32 modelPrtsAblsYm, Int32 modelPrtsAdptFrameNo,
        //    Int32 modelPrtsAblsFrameNo, Double partsQty, string partsOpNm, string standardName, Int32 catalogPartsMakerCd,
        //    string clgPrtsNoWithHyphen, Int32 coldDistrictsFlag, Int32 colorNarrowingFlag, Int32 trimNarrowingFlag,
        //    Int32 equipNarrowingFlag, string newPrtsNoWithHyphen, string newPrtsNoNoneHyphen, string makerOfferPartsName, DateTime PriceOfferDate,
        //    Int64 partsPrice, DateTime partsPriceStDate, string partsLayerCd, Int64 partsUniqueNo, string makerOfferPartsKana, Int32 openPriceDiv,
        //    string seriesModel, string categorySignModel, string exhaustGasSign, Int32 srchPNmAcqrCarMkrCd, string autoEstimatePartsCd, string tbsPartsCdDerivedNm, Int32 primeJoinLnkFlg)
        //<<<2013/02/12
        // --- DEL 2013/03/25 ----------<<<<<
        // ----DEL 2018/03/26 30757 佐々木　貴英 11470007-00 NS3Ai対応（BL統一部品コード対応） ------->>>>>
        //// --- ADD 2013/03/25 ---------->>>>>
        //public RetPartsInf(DateTime OfferDate, Int32 PartsSearchCode, Int32 PartsNarrowingCode, string partsName, string partsNameKana,
        //    Int32 partsCode, string workOrPartsDivNm, Int32 fullModelFixedNo, Int32 tbsPartsCode, Int32 tbsPartsCdDerivedNo,
        //    string figshapeNo, Int32 modelPrtsAdptYm, Int32 modelPrtsAblsYm, Int32 modelPrtsAdptFrameNo,
        //    Int32 modelPrtsAblsFrameNo, Double partsQty, string partsOpNm, string standardName, Int32 catalogPartsMakerCd,
        //    string clgPrtsNoWithHyphen, Int32 coldDistrictsFlag, Int32 colorNarrowingFlag, Int32 trimNarrowingFlag,
        //    Int32 equipNarrowingFlag, string newPrtsNoWithHyphen, string newPrtsNoNoneHyphen, string makerOfferPartsName, DateTime PriceOfferDate,
        //    Int64 partsPrice, DateTime partsPriceStDate, string partsLayerCd, Int64 partsUniqueNo, string makerOfferPartsKana, Int32 openPriceDiv,
        //    string seriesModel, string categorySignModel, string exhaustGasSign, Int32 srchPNmAcqrCarMkrCd, string autoEstimatePartsCd, string tbsPartsCdDerivedNm, Int32 primeJoinLnkFlg, Int32 vinProduceStartNo, Int32 vinProduceEndNo)
        //// --- ADD 2013/03/25 ----------<<<<<
        // ----DEL 2018/03/26 30757 佐々木　貴英 11470007-00 NS3Ai対応（BL統一部品コード対応） -------<<<<<
        // ----ADD 2018/03/26 30757 佐々木　貴英 11470007-00 NS3Ai対応（BL統一部品コード対応） ------->>>>>
        public RetPartsInf(DateTime OfferDate, Int32 PartsSearchCode, Int32 PartsNarrowingCode, string partsName, string partsNameKana,
            Int32 partsCode, string workOrPartsDivNm, Int32 fullModelFixedNo, Int32 tbsPartsCode, Int32 tbsPartsCdDerivedNo,
            string figshapeNo, Int32 modelPrtsAdptYm, Int32 modelPrtsAblsYm, Int32 modelPrtsAdptFrameNo,
            Int32 modelPrtsAblsFrameNo, Double partsQty, string partsOpNm, string standardName, Int32 catalogPartsMakerCd,
            string clgPrtsNoWithHyphen, Int32 coldDistrictsFlag, Int32 colorNarrowingFlag, Int32 trimNarrowingFlag,
            Int32 equipNarrowingFlag, string newPrtsNoWithHyphen, string newPrtsNoNoneHyphen, string makerOfferPartsName, DateTime PriceOfferDate,
            Int64 partsPrice, DateTime partsPriceStDate, string partsLayerCd, Int64 partsUniqueNo, string makerOfferPartsKana, Int32 openPriceDiv,
            string seriesModel, string categorySignModel, string exhaustGasSign, Int32 srchPNmAcqrCarMkrCd, string autoEstimatePartsCd, string tbsPartsCdDerivedNm, Int32 primeJoinLnkFlg, Int32 vinProduceStartNo, Int32 vinProduceEndNo,
            string blUtyPtThCd, string blUtyPtCd, Int32 blUtyPtSbCd)
        // ----ADD 2018/03/26 30757 佐々木　貴英 11470007-00 NS3Ai対応（BL統一部品コード対応） -------<<<<<
        {
            this._offerDate = OfferDate;
            this._PartsSearchCode = PartsSearchCode;
            this._PartsNarrowingCode = PartsNarrowingCode;
            this._partsName = partsName;
            this._partsNameKana = partsNameKana;
            this._partsCode = partsCode;
            this._workOrPartsDivNm = workOrPartsDivNm;
            this._fullModelFixedNo = fullModelFixedNo;
            this._tbsPartsCode = tbsPartsCode;
            this._tbsPartsCdDerivedNo = tbsPartsCdDerivedNo;
            this._figshapeNo = figshapeNo;
            this._modelPrtsAdptYm = modelPrtsAdptYm;
            this._modelPrtsAblsYm = modelPrtsAblsYm;
            this._modelPrtsAdptFrameNo = modelPrtsAdptFrameNo;
            this._modelPrtsAblsFrameNo = modelPrtsAblsFrameNo;
            this._partsQty = partsQty;
            this._partsOpNm = partsOpNm;
            this._standardName = standardName;
            this._catalogPartsMakerCd = catalogPartsMakerCd;
            this._clgPrtsNoWithHyphen = clgPrtsNoWithHyphen;
            this._coldDistrictsFlag = coldDistrictsFlag;
            this._colorNarrowingFlag = colorNarrowingFlag;
            this._trimNarrowingFlag = trimNarrowingFlag;
            this._equipNarrowingFlag = equipNarrowingFlag;
            this._newPrtsNoWithHyphen = newPrtsNoWithHyphen;
            this._newPrtsNoNoneHyphen = newPrtsNoNoneHyphen;
            this._makerOfferPartsName = makerOfferPartsName;
            this._priceOfferDate = PriceOfferDate;
            this._partsPrice = partsPrice;
            this._partsPriceStDate = partsPriceStDate;
            this._partsLayerCd = partsLayerCd;
            this._PartsUniqueNo = partsUniqueNo;
            this._makerOfferPartsKana = makerOfferPartsKana;
            this._openPriceDiv = openPriceDiv;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.07.23 ADD
            this.SeriesModel = seriesModel;
            this.CategorySignModel = categorySignModel;
            this.ExhaustGasSign = exhaustGasSign;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.07.23 ADD
            // 2009/10/23 Add >>>
            this.SrchPNmAcqrCarMkrCd = srchPNmAcqrCarMkrCd;
            // 2009/10/23 Add <<<
            // --- ADD m.suzuki 2011/05/18 ---------->>>>>
            this.AutoEstimatePartsCd = autoEstimatePartsCd;
            this.TbsPartsCdDerivedNm = tbsPartsCdDerivedNm;
            // --- ADD m.suzuki 2011/05/18 ----------<<<<<
            //>>>2013/02/12
            this.PrimeJoinLnkFlg = primeJoinLnkFlg;
            //<<<2013/02/12
            // --- ADD 2013/03/25 ---------->>>>>
            this._vinProduceStartNo = vinProduceStartNo;
            this._vinProduceEndNo = vinProduceEndNo;
            // --- ADD 2013/03/25 ----------<<<<<
            // ----ADD 2018/03/26 30757 佐々木　貴英 11470007-00 NS3Ai対応（BL統一部品コード対応） ------->>>>>
            this._blUtyPtThCd = blUtyPtThCd;
            this._blUtyPtCd = blUtyPtCd;
            this._blUtyPtSbCd = blUtyPtSbCd;
            // ----ADD 2018/03/26 30757 佐々木　貴英 11470007-00 NS3Ai対応（BL統一部品コード対応） -------<<<<<
        }
       
        /// <summary>
        /// UIクラスワーク複製処理
        /// </summary>
        /// <returns>RetPartsInfクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいRetPartsInfクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// <br />
        /// <br>Update Note      :   2018/03/26  30757 佐々木　貴英</br>
        /// <br>管理番号         :   11470007-00</br>
        /// <br>                 :   NS3Ai対応（BL統一部品コード対応）</br>
        /// <br>                     BL統一部品コード関連メンバーの追加</br>
        /// </remarks>
        public RetPartsInf Clone()
        {
            //>>>2013/02/12
            //// --- UPD m.suzuki 2011/05/18 ---------->>>>>
            ////// 2009/10/23 >>>
            //////// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.07.23 DEL
            ////////return new RetPartsInf(this._offerDate, this._PartsSearchCode, this._PartsNarrowingCode, this._partsName, this._partsNameKana, this._partsCode, this._workOrPartsDivNm, this._fullModelFixedNo, this._tbsPartsCode, this._tbsPartsCdDerivedNo, this._figshapeNo, this._modelPrtsAdptYm, this._modelPrtsAblsYm, this._modelPrtsAdptFrameNo, this._modelPrtsAblsFrameNo, this._partsQty, this._partsOpNm, this._standardName, this._catalogPartsMakerCd, this._clgPrtsNoWithHyphen, this._coldDistrictsFlag, this._colorNarrowingFlag, this._trimNarrowingFlag, this._equipNarrowingFlag, this._newPrtsNoWithHyphen, this._newPrtsNoNoneHyphen, this._makerOfferPartsName, this._priceOfferDate,this._partsPrice, this._partsPriceStDate, this._partsLayerCd, this._PartsUniqueNo, this._makerOfferPartsKana, this._openPriceDiv);
            //////// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.07.23 DEL
            //////// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.07.23 ADD
            //////return new RetPartsInf( this._offerDate, this._PartsSearchCode, this._PartsNarrowingCode, this._partsName, this._partsNameKana, this._partsCode, this._workOrPartsDivNm, this._fullModelFixedNo, this._tbsPartsCode, this._tbsPartsCdDerivedNo, this._figshapeNo, this._modelPrtsAdptYm, this._modelPrtsAblsYm, this._modelPrtsAdptFrameNo, this._modelPrtsAblsFrameNo, this._partsQty, this._partsOpNm, this._standardName, this._catalogPartsMakerCd, this._clgPrtsNoWithHyphen, this._coldDistrictsFlag, this._colorNarrowingFlag, this._trimNarrowingFlag, this._equipNarrowingFlag, this._newPrtsNoWithHyphen, this._newPrtsNoNoneHyphen, this._makerOfferPartsName, this._priceOfferDate, this._partsPrice, this._partsPriceStDate, this._partsLayerCd, this._PartsUniqueNo, this._makerOfferPartsKana, this._openPriceDiv, this._seriesModel, this._categorySignModel, this._exhaustGasSign );
            //////// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.07.23 ADD
            ////
            ////return new RetPartsInf(this._offerDate, this._PartsSearchCode, this._PartsNarrowingCode, this._partsName, this._partsNameKana, this._partsCode, this._workOrPartsDivNm, this._fullModelFixedNo, this._tbsPartsCode, this._tbsPartsCdDerivedNo, this._figshapeNo, this._modelPrtsAdptYm, this._modelPrtsAblsYm, this._modelPrtsAdptFrameNo, this._modelPrtsAblsFrameNo, this._partsQty, this._partsOpNm, this._standardName, this._catalogPartsMakerCd, this._clgPrtsNoWithHyphen, this._coldDistrictsFlag, this._colorNarrowingFlag, this._trimNarrowingFlag, this._equipNarrowingFlag, this._newPrtsNoWithHyphen, this._newPrtsNoNoneHyphen, this._makerOfferPartsName, this._priceOfferDate, this._partsPrice, this._partsPriceStDate, this._partsLayerCd, this._PartsUniqueNo, this._makerOfferPartsKana, this._openPriceDiv, this._seriesModel, this._categorySignModel, this._exhaustGasSign, this._srchPNmAcqrCarMkrCd);
            ////// 2009/10/23 <<<
            //return new RetPartsInf( this._offerDate, this._PartsSearchCode, this._PartsNarrowingCode, this._partsName, this._partsNameKana, this._partsCode, this._workOrPartsDivNm, this._fullModelFixedNo, this._tbsPartsCode, this._tbsPartsCdDerivedNo, this._figshapeNo, this._modelPrtsAdptYm, this._modelPrtsAblsYm, this._modelPrtsAdptFrameNo, this._modelPrtsAblsFrameNo, this._partsQty, this._partsOpNm, this._standardName, this._catalogPartsMakerCd, this._clgPrtsNoWithHyphen, this._coldDistrictsFlag, this._colorNarrowingFlag, this._trimNarrowingFlag, this._equipNarrowingFlag, this._newPrtsNoWithHyphen, this._newPrtsNoNoneHyphen, this._makerOfferPartsName, this._priceOfferDate, this._partsPrice, this._partsPriceStDate, this._partsLayerCd, this._PartsUniqueNo, this._makerOfferPartsKana, this._openPriceDiv, this._seriesModel, this._categorySignModel, this._exhaustGasSign, this._srchPNmAcqrCarMkrCd, this._autoEstimatePartsCd, this._tbsPartsCdDerivedNm );
            //// --- UPD m.suzuki 2011/05/18 ----------<<<<<

            // --- DEL 2013/03/25 ---------->>>>>
            //return new RetPartsInf(this._offerDate, this._PartsSearchCode, this._PartsNarrowingCode, this._partsName, this._partsNameKana, this._partsCode, this._workOrPartsDivNm, this._fullModelFixedNo, this._tbsPartsCode, this._tbsPartsCdDerivedNo, this._figshapeNo, this._modelPrtsAdptYm, this._modelPrtsAblsYm, this._modelPrtsAdptFrameNo, this._modelPrtsAblsFrameNo, this._partsQty, this._partsOpNm, this._standardName, this._catalogPartsMakerCd, this._clgPrtsNoWithHyphen, this._coldDistrictsFlag, this._colorNarrowingFlag, this._trimNarrowingFlag, this._equipNarrowingFlag, this._newPrtsNoWithHyphen, this._newPrtsNoNoneHyphen, this._makerOfferPartsName, this._priceOfferDate, this._partsPrice, this._partsPriceStDate, this._partsLayerCd, this._PartsUniqueNo, this._makerOfferPartsKana, this._openPriceDiv, this._seriesModel, this._categorySignModel, this._exhaustGasSign, this._srchPNmAcqrCarMkrCd, this._autoEstimatePartsCd, this._tbsPartsCdDerivedNm, this._primeJoinLnkFlg);
            //<<<2013/02/12
            // --- DEL 2013/03/25 ----------<<<<<
            // ----DEL 2018/03/26 30757 佐々木　貴英 11470007-00 NS3Ai対応（BL統一部品コード対応） ------->>>>>
            //// --- ADD 2013/03/25 ---------->>>>>
            //return new RetPartsInf(this._offerDate, this._PartsSearchCode, this._PartsNarrowingCode, this._partsName, this._partsNameKana, this._partsCode, this._workOrPartsDivNm, this._fullModelFixedNo, this._tbsPartsCode, this._tbsPartsCdDerivedNo, this._figshapeNo, this._modelPrtsAdptYm, this._modelPrtsAblsYm, this._modelPrtsAdptFrameNo, this._modelPrtsAblsFrameNo, this._partsQty, this._partsOpNm, this._standardName, this._catalogPartsMakerCd, this._clgPrtsNoWithHyphen, this._coldDistrictsFlag, this._colorNarrowingFlag, this._trimNarrowingFlag, this._equipNarrowingFlag, this._newPrtsNoWithHyphen, this._newPrtsNoNoneHyphen, this._makerOfferPartsName, this._priceOfferDate, this._partsPrice, this._partsPriceStDate, this._partsLayerCd, this._PartsUniqueNo, this._makerOfferPartsKana, this._openPriceDiv, this._seriesModel, this._categorySignModel, this._exhaustGasSign, this._srchPNmAcqrCarMkrCd, this._autoEstimatePartsCd, this._tbsPartsCdDerivedNm, this._primeJoinLnkFlg, this._vinProduceStartNo, this._vinProduceEndNo);
            //// --- ADD 2013/03/25 ----------<<<<<
            // ----DEL 2018/03/26 30757 佐々木　貴英 11470007-00 NS3Ai対応（BL統一部品コード対応） -------<<<<<
            // ----ADD 2018/03/26 30757 佐々木　貴英 11470007-00 NS3Ai対応（BL統一部品コード対応） ------->>>>>
            return new RetPartsInf(
                this._offerDate
                , this._PartsSearchCode
                , this._PartsNarrowingCode
                , this._partsName
                , this._partsNameKana
                , this._partsCode
                , this._workOrPartsDivNm
                , this._fullModelFixedNo
                , this._tbsPartsCode
                , this._tbsPartsCdDerivedNo
                , this._figshapeNo
                , this._modelPrtsAdptYm
                , this._modelPrtsAblsYm
                , this._modelPrtsAdptFrameNo
                , this._modelPrtsAblsFrameNo
                , this._partsQty
                , this._partsOpNm
                , this._standardName
                , this._catalogPartsMakerCd
                , this._clgPrtsNoWithHyphen
                , this._coldDistrictsFlag
                , this._colorNarrowingFlag
                , this._trimNarrowingFlag
                , this._equipNarrowingFlag
                , this._newPrtsNoWithHyphen
                , this._newPrtsNoNoneHyphen
                , this._makerOfferPartsName
                , this._priceOfferDate
                , this._partsPrice
                , this._partsPriceStDate
                , this._partsLayerCd
                , this._PartsUniqueNo
                , this._makerOfferPartsKana
                , this._openPriceDiv
                , this._seriesModel
                , this._categorySignModel
                , this._exhaustGasSign
                , this._srchPNmAcqrCarMkrCd
                , this._autoEstimatePartsCd
                , this._tbsPartsCdDerivedNm
                , this._primeJoinLnkFlg
                , this._vinProduceStartNo
                , this._vinProduceEndNo
                , this._blUtyPtThCd
                , this._blUtyPtCd
                , this._blUtyPtSbCd
                );
            // ----ADD 2018/03/26 30757 佐々木　貴英 11470007-00 NS3Ai対応（BL統一部品コード対応） -------<<<<<
        }
    }

    /// <summary>
    ///  Ver5.1.0.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>RetPartsInfクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   RetPartsInfクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// <br>Update Note      :   2009/10/23　21024 佐々木 検索品名取得カーメーカーコードを追加</br>
    /// <br>Update Note      :   2018/03/26  30757 佐々木　貴英</br>
    /// <br>管理番号         :   11470007-00</br>
    /// <br>                 :   NS3Ai対応（BL統一部品コード対応）</br>
    /// <br>                     BL統一部品コード関連メンバーの追加</br>
    /// </remarks>
    public class RetPartsInf_SerializationSurrogate_For_V5100 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ
        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   RetPartsInfクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// <br>Update Note      :   2018/03/26  30757 佐々木　貴英</br>
        /// <br>管理番号         :   11470007-00</br>
        /// <br>                 :   NS3Ai対応（BL統一部品コード対応）</br>
        /// <br>                     BL統一部品コード関連メンバーの追加</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  EmployeeWork_SerializationSurrogate_For_V5100.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is RetPartsInf || graph is ArrayList))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(RetPartsInf).FullName));

            if (graph != null && graph is RetPartsInf)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is RetPartsInf)
            {
                occurrence = 1;
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.1.0.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.RetPartsInf");
            serInfo.Occurrence = occurrence;		 //繰り返し数	

            serInfo.MemberInfo.Add(typeof(Int64));
            serInfo.MemberInfo.Add(typeof(Int32));
            serInfo.MemberInfo.Add(typeof(Int32));
            serInfo.MemberInfo.Add(typeof(string));
            serInfo.MemberInfo.Add(typeof(string));
            serInfo.MemberInfo.Add(typeof(Int32));
            serInfo.MemberInfo.Add(typeof(string));
            serInfo.MemberInfo.Add(typeof(Int32));
            serInfo.MemberInfo.Add(typeof(Int32));
            serInfo.MemberInfo.Add(typeof(Int32));
            serInfo.MemberInfo.Add(typeof(string));//10th
            serInfo.MemberInfo.Add(typeof(Int32));
            serInfo.MemberInfo.Add(typeof(Int32));
            serInfo.MemberInfo.Add(typeof(Int32));
            serInfo.MemberInfo.Add(typeof(Int32));
            serInfo.MemberInfo.Add(typeof(Double));
            serInfo.MemberInfo.Add(typeof(string));
            serInfo.MemberInfo.Add(typeof(string));
            serInfo.MemberInfo.Add(typeof(Int32));
            serInfo.MemberInfo.Add(typeof(string));
            serInfo.MemberInfo.Add(typeof(Int32));
            serInfo.MemberInfo.Add(typeof(Int32));
            serInfo.MemberInfo.Add(typeof(Int32));
            serInfo.MemberInfo.Add(typeof(Int32));
            serInfo.MemberInfo.Add(typeof(string));
            serInfo.MemberInfo.Add(typeof(string));
            serInfo.MemberInfo.Add(typeof(string));
            serInfo.MemberInfo.Add(typeof(Int64));
            serInfo.MemberInfo.Add(typeof(Int64));
            serInfo.MemberInfo.Add(typeof(Int64));
            serInfo.MemberInfo.Add(typeof(string));//30th
            serInfo.MemberInfo.Add(typeof(Int64));
            serInfo.MemberInfo.Add(typeof(string));
            serInfo.MemberInfo.Add(typeof(Int32));
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.07.23 ADD
            serInfo.MemberInfo.Add( typeof( string ) );
            serInfo.MemberInfo.Add( typeof( string ) );
            serInfo.MemberInfo.Add( typeof( string ) );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.07.23 ADD
            serInfo.MemberInfo.Add(typeof(Int32));      // 2009/10/23 Add
            // --- ADD m.suzuki 2011/05/18 ---------->>>>>
            serInfo.MemberInfo.Add( typeof( string ) );
            serInfo.MemberInfo.Add( typeof( string ) );
            // --- ADD m.suzuki 2011/05/18 ----------<<<<<
            //>>>2013/02/12
            serInfo.MemberInfo.Add(typeof(Int32));
            //<<<2013/02/12

            // --- ADD 2013/03/25 ---------->>>>>
            serInfo.MemberInfo.Add(typeof(Int32));     // VinProduceStartNo
            serInfo.MemberInfo.Add(typeof(Int32));     // VinProduceEndNo
            // --- ADD 2013/03/25 ----------<<<<<

            // ----ADD 2018/03/26 30757 佐々木　貴英 11470007-00 NS3Ai対応（BL統一部品コード対応） ------->>>>>
            serInfo.MemberInfo.Add( typeof( string ) ); // BlUtyPtThCdRF
            serInfo.MemberInfo.Add( typeof( string ) ); // BlUtyPtCdRF
            serInfo.MemberInfo.Add( typeof( Int32 ) );  // BlUtyPtSbCdRF
            // ----ADD 2018/03/26 30757 佐々木　貴英 11470007-00 NS3Ai対応（BL統一部品コード対応） -------<<<<<

            serInfo.Serialize(writer, serInfo);
            if (graph is RetPartsInf)
            {
                RetPartsInf temp = (RetPartsInf)graph;

                writer.Write(temp.OfferDate.Ticks);
                writer.Write(temp.PartsSearchCode);
                writer.Write(temp.PartsNarrowingCode);
                writer.Write(temp.PartsName);
                writer.Write(temp.PartsNameKana);
                writer.Write(temp.PartsCode);
                writer.Write(temp.WorkOrPartsDivNm);
                writer.Write(temp.FullModelFixedNo);
                writer.Write(temp.TbsPartsCode);
                writer.Write(temp.TbsPartsCdDerivedNo);
                writer.Write(temp.FigShapeNo);
                writer.Write(temp.ModelPrtsAdptYm);
                writer.Write(temp.ModelPrtsAblsYm);
                writer.Write(temp.ModelPrtsAdptFrameNo);
                writer.Write(temp.ModelPrtsAblsFrameNo);
                writer.Write(temp.PartsQty);
                writer.Write(temp.PartsOpNm);
                writer.Write(temp.StandardName);
                writer.Write(temp.CatalogPartsMakerCd);
                writer.Write(temp.ClgPrtsNoWithHyphen);
                writer.Write(temp.ColdDistrictsFlag);
                writer.Write(temp.ColorNarrowingFlag);
                writer.Write(temp.TrimNarrowingFlag);
                writer.Write(temp.EquipNarrowingFlag);
                writer.Write(temp.NewPrtsNoWithHyphen);
                writer.Write(temp.NewPrtsNoNoneHyphen);
                writer.Write(temp.MakerOfferPartsName);
                writer.Write(temp.PriceOfferDate.Ticks);
                writer.Write(temp.PartsPrice);
                writer.Write((Int64)temp.PartsPriceStDate.Ticks);
                writer.Write(temp.PartsLayerCd);
                writer.Write(temp.PartsUniqueNo);
                writer.Write(temp.MakerOfferPartsKana);
                writer.Write(temp.OpenPriceDiv);
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.07.23 ADD
                writer.Write( temp.SeriesModel );
                writer.Write( temp.CategorySignModel );
                writer.Write( temp.ExhaustGasSign );
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.07.23 ADD
                writer.Write(temp.SrchPNmAcqrCarMkrCd);     // 2009/10/23 Add
                // --- ADD m.suzuki 2011/05/18 ---------->>>>>
                writer.Write( temp.AutoEstimatePartsCd );
                writer.Write( temp.TbsPartsCdDerivedNm );
                // --- ADD m.suzuki 2011/05/18 ----------<<<<<
                //>>>2013/02/12
                writer.Write(temp.PrimeJoinLnkFlg);
                //<<<2013/02/12

                // --- ADD 2013/03/25 ---------->>>>>
                writer.Write(temp.VinProduceStartNo);        // VinProduceStartNo
                writer.Write(temp.VinProduceEndNo);          // VinProduceEndNo
                // --- ADD 2013/03/25 ----------<<<<<
                // ----ADD 2018/03/26 30757 佐々木　貴英 11470007-00 NS3Ai対応（BL統一部品コード対応） ------->>>>>
                writer.Write( temp.BlUtyPtThCd );         // BlUtyPtThCd
                writer.Write( temp.BlUtyPtCd );           // BlUtyPtCd
                writer.Write( temp.BlUtyPtSbCd );         // BlUtyPtSbCd
                // ----ADD 2018/03/26 30757 佐々木　貴英 11470007-00 NS3Ai対応（BL統一部品コード対応） -------<<<<<

            }
            else if (graph is ArrayList)
            {
                ArrayList lst = (ArrayList)graph;
                for (int i = 0; i < occurrence; ++i)
                {

                    RetPartsInf temp = (RetPartsInf)lst[i];

                    writer.Write(temp.OfferDate.Ticks);
                    writer.Write(temp.PartsSearchCode);
                    writer.Write(temp.PartsNarrowingCode);
                    writer.Write(temp.PartsName);
                    writer.Write(temp.PartsNameKana);
                    writer.Write(temp.PartsCode);
                    writer.Write(temp.WorkOrPartsDivNm);
                    writer.Write(temp.FullModelFixedNo);
                    writer.Write(temp.TbsPartsCode);
                    writer.Write(temp.TbsPartsCdDerivedNo);
                    writer.Write(temp.FigShapeNo);
                    writer.Write(temp.ModelPrtsAdptYm);
                    writer.Write(temp.ModelPrtsAblsYm);
                    writer.Write(temp.ModelPrtsAdptFrameNo);
                    writer.Write(temp.ModelPrtsAblsFrameNo);
                    writer.Write(temp.PartsQty);
                    writer.Write(temp.PartsOpNm);
                    writer.Write(temp.StandardName);
                    writer.Write(temp.CatalogPartsMakerCd);
                    writer.Write(temp.ClgPrtsNoWithHyphen);
                    writer.Write(temp.ColdDistrictsFlag);
                    writer.Write(temp.ColorNarrowingFlag);
                    writer.Write(temp.TrimNarrowingFlag);
                    writer.Write(temp.EquipNarrowingFlag);
                    writer.Write(temp.NewPrtsNoWithHyphen);
                    writer.Write(temp.NewPrtsNoNoneHyphen);
                    writer.Write(temp.MakerOfferPartsName);
                    writer.Write(temp.PriceOfferDate.Ticks);
                    writer.Write(temp.PartsPrice);
                    writer.Write((Int64)temp.PartsPriceStDate.Ticks);
                    writer.Write(temp.PartsLayerCd);
                    writer.Write(temp.PartsUniqueNo);
                    writer.Write(temp.MakerOfferPartsKana);
                    writer.Write(temp.OpenPriceDiv);
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.07.23 ADD
                    writer.Write( temp.SeriesModel );
                    writer.Write( temp.CategorySignModel );
                    writer.Write( temp.ExhaustGasSign );
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.07.23 ADD
                    writer.Write(temp.SrchPNmAcqrCarMkrCd);     // 2009/10/23 Add
                    // --- ADD m.suzuki 2011/05/18 ---------->>>>>
                    writer.Write( temp.AutoEstimatePartsCd );
                    writer.Write( temp.TbsPartsCdDerivedNm );
                    // --- ADD m.suzuki 2011/05/18 ----------<<<<<
                    //>>>2013/02/12
                    writer.Write(temp.PrimeJoinLnkFlg);
                    //<<<2013/02/12
                    // --- ADD 2013/03/25 ---------->>>>>
                    writer.Write(temp.VinProduceStartNo);        // VinProduceStartNo
                    writer.Write(temp.VinProduceEndNo);          // VinProduceEndNo
                    // --- ADD 2013/03/25 ----------<<<<<

                    // ----ADD 2018/03/26 30757 佐々木　貴英 11470007-00 NS3Ai対応（BL統一部品コード対応） ------->>>>>
                    writer.Write( temp.BlUtyPtThCd );         // BlUtyPtThCd
                    writer.Write( temp.BlUtyPtCd );           // BlUtyPtCd
                    writer.Write( temp.BlUtyPtSbCd );         // BlUtyPtSbCd
                    // ----ADD 2018/03/26 30757 佐々木　貴英 11470007-00 NS3Ai対応（BL統一部品コード対応） -------<<<<<
                }

            }
        }

        /// <summary>
        /// RetPartsInfメンバ数(publicプロパティ数)
        /// </summary>
        //>>>2013/02/12
        //// --- UPD m.suzuki 2011/05/18 ---------->>>>>
        ////// 2009/10/23 >>>
        //////// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.07.23 DEL
        ////////private const int currentMemberCount = 34;
        //////// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.07.23 DEL
        //////// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.07.23 ADD
        //////private const int currentMemberCount = 37;
        //////// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.07.23 ADD
        ////
        ////private const int currentMemberCount = 38;
        ////// 2009/10/23 <<<
        //private const int currentMemberCount = 40;
        //// --- UPD m.suzuki 2011/05/18 ----------<<<<<
        // --- DEL 2013/03/25 ---------->>>>>
        //private const int currentMemberCount = 41;
        //<<<2013/02/12
        // --- DEL 2013/03/25 ----------<<<<<
        // ----DEL 2018/03/26 30757 佐々木　貴英 11470007-00 NS3Ai対応（BL統一部品コード対応） ------->>>>>
        //// --- ADD 2013/03/25 ---------->>>>>
        //private const int currentMemberCount = 43;
        //// --- ADD 2013/03/25 ----------<<<<<
        // ----DEL 2018/03/26 30757 佐々木　貴英 11470007-00 NS3Ai対応（BL統一部品コード対応） -------<<<<<
        // ----ADD 2018/03/26 30757 佐々木　貴英 11470007-00 NS3Ai対応（BL統一部品コード対応） ------->>>>>
        private const int currentMemberCount = 46;
        // ----ADD 2018/03/26 30757 佐々木　貴英 11470007-00 NS3Ai対応（BL統一部品コード対応） -------<<<<<


        /// <summary>
        ///  RetPartsInfインスタンス取得
        /// </summary>
        /// <returns>RetPartsInfクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   RetPartsInfのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// <br />
        /// <br>Update Note      :   2018/03/26  30757 佐々木　貴英</br>
        /// <br>管理番号         :   11470007-00</br>
        /// <br>                 :   NS3Ai対応（BL統一部品コード対応）</br>
        /// <br>                     BL統一部品コード関連メンバーの追加</br>
        /// </remarks>
        private RetPartsInf GetRetPartsInf(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            RetPartsInf temp = new RetPartsInf();

            temp.OfferDate = new DateTime(reader.ReadInt64());
            temp.PartsSearchCode = reader.ReadInt32();
            temp.PartsNarrowingCode = reader.ReadInt32();
            temp.PartsName = reader.ReadString();
            temp.PartsNameKana = reader.ReadString();
            temp.PartsCode = reader.ReadInt32();
            temp.WorkOrPartsDivNm = reader.ReadString();
            temp.FullModelFixedNo = reader.ReadInt32();
            temp.TbsPartsCode = reader.ReadInt32();
            temp.TbsPartsCdDerivedNo = reader.ReadInt32();
            temp.FigShapeNo = reader.ReadString();
            temp.ModelPrtsAdptYm = reader.ReadInt32();
            temp.ModelPrtsAblsYm = reader.ReadInt32();
            temp.ModelPrtsAdptFrameNo = reader.ReadInt32();
            temp.ModelPrtsAblsFrameNo = reader.ReadInt32();
            temp.PartsQty = reader.ReadDouble();
            temp.PartsOpNm = reader.ReadString();
            temp.StandardName = reader.ReadString();
            temp.CatalogPartsMakerCd = reader.ReadInt32();
            temp.ClgPrtsNoWithHyphen = reader.ReadString();
            temp.ColdDistrictsFlag = reader.ReadInt32();
            temp.ColorNarrowingFlag = reader.ReadInt32();
            temp.TrimNarrowingFlag = reader.ReadInt32();
            temp.EquipNarrowingFlag = reader.ReadInt32();
            temp.NewPrtsNoWithHyphen = reader.ReadString();
            temp.NewPrtsNoNoneHyphen = reader.ReadString();
            temp.MakerOfferPartsName = reader.ReadString();
            temp.PriceOfferDate = new DateTime(reader.ReadInt64());
            temp.PartsPrice = reader.ReadInt64();
            temp.PartsPriceStDate = new DateTime(reader.ReadInt64());
            temp.PartsLayerCd = reader.ReadString();
            temp.PartsUniqueNo = reader.ReadInt64();
            temp.MakerOfferPartsKana = reader.ReadString();
            temp.OpenPriceDiv = reader.ReadInt32();
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.07.23 ADD
            temp.SeriesModel = reader.ReadString();
            temp.CategorySignModel = reader.ReadString();
            temp.ExhaustGasSign = reader.ReadString();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.07.23 ADD
            temp.SrchPNmAcqrCarMkrCd = reader.ReadInt32();  // 2009/10/22 Add
            // --- ADD m.suzuki 2011/05/18 ---------->>>>>
            temp.AutoEstimatePartsCd = reader.ReadString();
            temp.TbsPartsCdDerivedNm = reader.ReadString();
            // --- ADD m.suzuki 2011/05/18 ----------<<<<<
            //>>>2013/02/12
            temp.PrimeJoinLnkFlg = reader.ReadInt32();
            //<<<2013/02/12

            // --- ADD 2013/03/25 ---------->>>>>
            temp.VinProduceStartNo = reader.ReadInt32();       // VinProduceStartNo
            temp.VinProduceEndNo = reader.ReadInt32();         // VinProduceEndNo
            // --- ADD 2013/03/25 ----------<<<<<

            // ----ADD 2018/03/26 30757 佐々木　貴英 11470007-00 NS3Ai対応（BL統一部品コード対応） ------->>>>>
            temp.BlUtyPtThCd = reader.ReadString();           // BlUtyPtThCd
            temp.BlUtyPtCd = reader.ReadString();             // BlUtyPtCd
            temp.BlUtyPtSbCd = reader.ReadInt32();            // BlUtyPtSbCd
            // ----ADD 2018/03/26 30757 佐々木　貴英 11470007-00 NS3Ai対応（BL統一部品コード対応） -------<<<<<

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
        ///  Ver5.1.0.0用のカスタムデシリアライザです
        /// </summary>
        /// <returns>RetPartsInfクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   RetPartsInfクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                RetPartsInf temp = GetRetPartsInf(reader, serInfo);
                lst.Add(temp);
            }
            retValue = lst;
            return retValue;
        }

        #endregion
    }
    #endregion

    /// <summary>
    ///                      部品価格取得パラメータ
    /// </summary>
    /// <remarks>
    /// <br>Date             :   2005/04/14</br>
    /// <br>Genarated Date   :   2005/04/14</br>
    /// <br></br>
    /// <br>Update Note: 2010/06/04  22018 鈴木 正臣</br>
    /// <br>           : 成果物統合</br>
    /// <br>           : 　自由検索 2010/04/28 の組込</br>
    /// <br></br>
    /// <br>Update Note: 2010/06/12  22018 鈴木 正臣</br>
    /// <br>           : 成果物統合</br>
    /// <br>           : 　２輪オプション対応（2輪ｵﾌﾟｼｮﾝ=OFFなら2輪ﾒｰｶｰを除外する）</br>
    /// <br></br>
    /// <br>Update Note: 2013/03/25　FSI斎藤 和宏</br>
    /// <br>           : 10900269-00 SPK車台番号文字列対応</br>
    /// <br>           :   検索条件にVINコード・ハンドル位置情報・生産工場コードを追加</br>
    /// <br />
    /// <br>Update Note: 2018/03/26  30757 佐々木　貴英</br>
    /// <br>管理番号   : 11470007-00</br>
    /// <br>           : NS3Ai対応（BL統一部品コード対応）</br>
    /// <br>             BL統一部品コード関連メンバーの追加</br>
    /// </remarks>
    [Serializable]
    public class GetPartsInfPara
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public GetPartsInfPara()
        {
            _NoSubst = 0;
        }

        //>>>>20060710 iwa add start
        /// <summary>ハイフン付最新部品品番</summary>
        private string _PrtsNoWithHyphen = "";
        /// <summary>ハイフン無最新部品品番</summary>
        private string _PrtsNoNoneHyphen = "";
        //<<<<20060710 iwa add end

        ///寒冷地部品抽出区分 0:全抽出（両方） 1:標準地域部品のみ抽出 2:寒冷地部品のみ抽出
        private int _ColdDistrictsExtrDivCd;
        /// ﾒｰｶｰ
        private int _MakerCode;
        /// 車種
        private int _ModelCode;
        /// 車種サブ
        private int _ModelSubCode;
        /// 生産年式
        private int _ProduceTypeOfYear;
        /// シャシーNo
        private string _ChassisNo;
        /// 企業コード
        private string _EnterpriseCode;
        /// プル型式固定番号
        private int[] _FullModelFixedNo;
        /// 類別番号
        private int _CategoryNo;
        /// 型式指定番号
        private int _ModelDesignationNo;
        /// フル型式
        private string _Model12FullModel;
        /// 翼部品コード
        private int _TbsPartsCode;
        /// Fig図番
        private string _FigShapeNo;
        /// カラーコード
        private string _ColorCdInfoNo;
        /// トリムコード
        private string _TrimCode;
        /// 装備情報
        private Equipment[] _alEquipment;
        /// 代替検索なしフラグ
        private int _NoSubst;
        ///// 最高価格所得モード
        //private int _MaxPriceMode;

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/16 ADD
        /// <summary>価格適用日付</summary>
        private DateTime _PriceDate;
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/16 ADD

        /// <summary>商品番号検索区分</summary>
        /// <remarks>0:完全一致,1:前方一致検索,2:後方一致検索,3:曖昧検索</remarks>
        private int _SrchTyp;

        // --- ADD m.suzuki 2010/04/28 ---------->>>>>
        /// 通常検索除外フラグ
        private bool _normalSearchExclude;
        /// 検索キーリスト（自由検索用）
        private ArrayList _searchKeyList;
        // --- ADD m.suzuki 2010/04/28 ----------<<<<<
        // --- ADD m.suzuki 2010/06/12 ---------->>>>>
        /// <summary>２輪メーカー除外フラグ</summary>
        private bool _twoWheelerMakerExclude;
        /// <summary>２輪メーカー開始</summary>
        private int _twoWheelerMakerCdSt;
        /// <summary>２輪メーカー終了</summary>
        private int _twoWheelerMakerCdEd;
        // --- ADD m.suzuki 2010/06/12 ----------<<<<<
        // --- ADD m.suzuki 2011/05/18 ---------->>>>>
        /// <summary>BLコード枝番</summary>
        private int _tbsPartsCdDerivedNo;
        // --- ADD m.suzuki 2011/05/18 ----------<<<<<

        // --- ADD 2013/03/25 ---------->>>>>
        /// <summary>VINコード</summary>
        private int _vinCode;

        /// <summary>ハンドル位置情報</summary>
        private int _handleInfoCd;

        /// <summary>生産工場コード</summary>
        private string _productionFactoryCd = "";
        // --- ADD 2013/03/25 ----------<<<<<

        // ----ADD 2018/03/26 30757 佐々木　貴英 11470007-00 NS3Ai対応（BL統一部品コード対応） ------->>>>>
        /// <summary>BL統一部品コード(スリーコード版)</summary>
        private string _blUtyPtThCd = string.Empty;
        /// <summary>BL統一部品サブコード</summary>
        private Int32 _blUtyPtSbCd = 0;
        // ----ADD 2018/03/26 30757 佐々木　貴英 11470007-00 NS3Ai対応（BL統一部品コード対応） -------<<<<<

        /// <summary>商品番号検索区分</summary>
        /// <remarks>0:完全一致,1:前方一致検索,2:後方一致検索,3:曖昧検索</remarks>
        public int SearchType
        {
            get { return _SrchTyp; }
            set { _SrchTyp = value; }
        }

        //>>>>20060710 iwa add start
        /// ハイフン付最新部品品番
        public string PrtsNoWithHyphen
        {
            get { return this._PrtsNoWithHyphen; }
            set { this._PrtsNoWithHyphen = value; }
        }
        /// ハイフン無最新部品品番
        public string PrtsNoNoneHyphen
        {
            get { return this._PrtsNoNoneHyphen; }
            set { this._PrtsNoNoneHyphen = value; }
        }
        //<<<<20060710 iwa add end

        /// public propaty name  :  PartsRateDivCe
        /// <summary>寒冷地部品抽出区分プロパティ0:全抽出（両方） 1:標準地域部品のみ抽出 2:寒冷地部品のみ抽出</summary>
        /// <value>寒冷地部品抽出区分</value>
        /// ----------------------------------------------------------------------
        public Int32 ColdDistrictsExtrDivCd
        {
            get { return _ColdDistrictsExtrDivCd; }
            set { _ColdDistrictsExtrDivCd = value; }
        }
        /// Fig図番
        public string FigShapeNo
        {
            get { return this._FigShapeNo; }
            set { this._FigShapeNo = value; }
        }
        /// ﾒｰｶｰ
        public int MakerCode
        {
            get { return this._MakerCode; }
            set { this._MakerCode = value; }
        }
        /// 車種
        public int ModelCode
        {
            get { return this._ModelCode; }
            set { this._ModelCode = value; }
        }
        /// 車種サブ
        public int ModelSubCode
        {
            get { return this._ModelSubCode; }
            set { this._ModelSubCode = value; }
        }
        /// 生産年式
        public int ProduceTypeOfYear
        {
            get { return this._ProduceTypeOfYear; }
            set { this._ProduceTypeOfYear = value; }
        }
        /// シャシーNo
        public string ChassisNo
        {
            get { return this._ChassisNo; }
            set { this._ChassisNo = value; }
        }
        /// <summary>
        /// 企業コード
        /// </summary>
        public string EnterpriseCode
        {
            get { return this._EnterpriseCode; }
            set { this._EnterpriseCode = value; }
        }
        /// <summary>
        /// フル型式固定番号
        /// </summary>
        public int[] FullModelFixedNo
        {
            get { return this._FullModelFixedNo; }
            set { this._FullModelFixedNo = value; }
        }
        /// <summary>
        /// 類別番号
        /// </summary>
        public int CategoryNo
        {
            get { return this._CategoryNo; }
            set { this._CategoryNo = value; }
        }
        /// <summary>
        /// 型式指定番号
        /// </summary>
        public int ModelDesignationNo
        {
            get { return this._ModelDesignationNo; }
            set { this._ModelDesignationNo = value; }
        }
        /// <summary>
        /// フル型式
        /// </summary>
        public string Model12FullModel
        {
            get { return this._Model12FullModel; }
            set { this._Model12FullModel = value; }
        }
        /// <summary>
        /// 翼部品コード
        /// </summary>
        public int TbsPartsCode
        {
            get { return this._TbsPartsCode; }
            set { this._TbsPartsCode = value; }
        }
        /// <summary>
        /// カラーコード
        /// </summary>
        public string ColorCdInfoNo
        {
            get { return this._ColorCdInfoNo; }
            set { this._ColorCdInfoNo = value; }
        }
        /// <summary>
        /// トリムコード
        /// </summary>
        public string TrimCode
        {
            get { return this._TrimCode; }
            set { this._TrimCode = value; }
        }
        /// <summary>
        /// 装備情報
        /// </summary>
        public Equipment[] alEquipment
        {
            get { return this._alEquipment; }
            set { this._alEquipment = value; }
        }
        /// <summary>
        /// 代替検索なしフラグ  0:代替検索あり　 1:代替検索なし
        /// </summary>
        public int NoSubst
        {
            get { return this._NoSubst; }
            set { this._NoSubst = value; }
        }
        ///// <summary>
        ///// 最高価格取得モード 0:全件リード 1:最高点数レコード取得
        ///// </summary>
        //public int MaxPriceMode
        //{
        //    get { return this._MaxPriceMode; }
        //    set { this._MaxPriceMode = value; }
        //}
        
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/16 ADD
        /// <summary>
        /// 価格適用日付
        /// </summary>
        public DateTime PriceDate
        {
            get { return _PriceDate; }
            set { _PriceDate = value; }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/16 ADD
        // --- ADD m.suzuki 2010/04/28 ---------->>>>>
        /// <summary>
        /// 通常検索除外フラグ
        /// </summary>
        public bool NormalSearchExclude
        {
            get { return _normalSearchExclude; }
            set { _normalSearchExclude = value; }
        }
        /// <summary>
        /// 検索キーリスト（自由検索用）
        /// </summary>
        public ArrayList SearchKeyList
        {
            get { return _searchKeyList; }
            set { _searchKeyList = value; }
        }
        // --- ADD m.suzuki 2010/04/28 ----------<<<<<
        // --- ADD m.suzuki 2010/06/12 ---------->>>>>
        /// <summary>
        /// ２輪メーカー除外フラグ
        /// </summary>
        public bool TwoWheelerMakerExclude
        {
            get { return _twoWheelerMakerExclude; }
            set { _twoWheelerMakerExclude = value; }
        }
        /// <summary>
        /// ２輪メーカーコード開始
        /// </summary>
        public int TwoWheelerMakerCdSt
        {
            get { return _twoWheelerMakerCdSt; }
            set { _twoWheelerMakerCdSt = value; }
        }
        /// <summary>
        /// ２輪メーカーコード終了
        /// </summary>
        public int TwoWheelerMakerCdEd
        {
            get { return _twoWheelerMakerCdEd; }
            set { _twoWheelerMakerCdEd = value; }
        }
        // --- ADD m.suzuki 2010/06/12 ----------<<<<<
        // --- ADD m.suzuki 2011/05/18 ---------->>>>>
        /// <summary>
        /// BLコード枝番
        /// </summary>
        public int TbsPartsCdDerivedNo
        {
            get { return _tbsPartsCdDerivedNo; }
            set { _tbsPartsCdDerivedNo = value; }
        }
        // --- ADD m.suzuki 2011/05/18 ----------<<<<<

        // --- ADD 2013/03/25 ---------->>>>>
        /// <summary>VINコード</summary>
        public int VinCode
        {
            get { return _vinCode; }
            set { _vinCode = value; }
        }

        /// <summary>ハンドル位置情報</summary>
        public int HandleInfoCd
        {
            get { return _handleInfoCd; }
            set { _handleInfoCd = value; }
        }

        /// <summary>生産工場コード</summary>
        public string ProductionFactoryCd
        {
            get { return _productionFactoryCd; }
            set { _productionFactoryCd = value; }
        }
        // --- ADD 2013/03/25 ----------<<<<<

        // ----ADD 2018/03/26 30757 佐々木　貴英 11470007-00 NS3Ai対応（BL統一部品コード対応） ------->>>>>
        /// <summary>BL統一部品コード(スリーコード版)パラメータ</summary>
        /// <value>BL統一部品コード(スリーコード版)</value>
        /// <remarks>
        /// <br>Note       : BL統一部品コード(スリーコード版)の取得と設定</br>
        /// <br>Programmer : 30757 佐々木　貴英</br>
        /// <br>Date       : 2018/03/26</br>
        /// <br>管理番号   :   11470007-00</br>
        /// <br>           :   NS3Ai対応（BL統一部品コード対応）</br>
        /// </remarks>
        public string BlUtyPtThCd
        {
            get { return this._blUtyPtThCd; }
            set { this._blUtyPtThCd = value; }
        }
        /// <summary>BL統一部品サブコードパラメータ</summary>
        /// <value>BL統一部品サブコード</value>
        /// <remarks>
        /// <br>Note       : BL統一部品サブコードの取得と設定</br>
        /// <br>Programmer : 30757 佐々木　貴英</br>
        /// <br>Date       : 2018/03/26</br>
        /// <br>管理番号   :   11470007-00</br>
        /// <br>           :   NS3Ai対応（BL統一部品コード対応）</br>
        /// </remarks>
        public Int32 BlUtyPtSbCd
        {
            get { return this._blUtyPtSbCd; }
            set { this._blUtyPtSbCd = value; }
        }
        // ----ADD 2018/03/26 30757 佐々木　貴英 11470007-00 NS3Ai対応（BL統一部品コード対応） -------<<<<<
    }

    /// <summary>
    /// 装備情報パラメータ
    /// </summary>
    [Serializable]
    public struct Equipment
    {
        /// <summary>
        /// 装備分類コード
        /// </summary>
        public int EquipmentGenreCd;
        /// <summary>
        /// 装備分類名称
        /// </summary>
        public string EquipmentGenreNm;
        /// <summary>
        /// 装備コード
        /// </summary>
        public int EquipmentCode;
        /// <summary>
        /// 装備名称
        /// </summary>
        public string EquipmentName;
    }

    /// <summary>
    ///                      部品一括価格取得パラメータ
    /// </summary>
    /// <remarks>
    /// <br>Date             :   2005/04/14</br>
    /// <br>Genarated Date   :   2005/04/14</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    public class SerchPartsInfPara
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public SerchPartsInfPara()
        {
        }
        /// ﾒｰｶｰ
        private int _MakerCode;
        /// 車種
        private int _ModelCode;
        /// 車種サブ
        private int _ModelSubCode;
        /// 企業コード
        private string _EnterpriseCode;
        /// プル型式固定番号
        private int[] _FullModelFixedNo;
        /// 類別番号
        private int _CategoryNo;
        /// 型式指定番号
        private int _ModelDesignationNo;
        /// フル型式
        private string _Model12FullModel;
        /// ﾒｰｶｰ
        public int MakerCode
        {
            get { return this._MakerCode; }
            set { this._MakerCode = value; }
        }
        /// 車種
        public int ModelCode
        {
            get { return this._ModelCode; }
            set { this._ModelCode = value; }
        }
        /// 車種サブ
        public int ModelSubCode
        {
            get { return this._ModelSubCode; }
            set { this._ModelSubCode = value; }
        }
        /// <summary>
        /// 企業コード
        /// </summary>
        public string EnterpriseCode
        {
            get { return this._EnterpriseCode; }
            set { this._EnterpriseCode = value; }
        }
        /// <summary>
        /// フル型式固定番号
        /// </summary>
        public int[] FullModelFixedNo
        {
            get { return this._FullModelFixedNo; }
            set { this._FullModelFixedNo = value; }
        }
        /// <summary>
        /// 類別番号
        /// </summary>
        public int CategoryNo
        {
            get { return this._CategoryNo; }
            set { this._CategoryNo = value; }
        }
        /// <summary>
        /// 型式指定番号
        /// </summary>
        public int ModelDesignationNo
        {
            get { return this._ModelDesignationNo; }
            set { this._ModelDesignationNo = value; }
        }
        /// <summary>
        /// フル型式
        /// </summary>
        public string Model12FullModel
        {
            get { return this._Model12FullModel; }
            set { this._Model12FullModel = value; }
        }
    }

    /// <summary>
    ///                      PartsModelLnkWork
    /// </summary>
    /// <remarks>
    /// <br>note             :   部品ー型式連携クラス</br>
    /// <br>Programmer       :   ハンドメイド</br>
    /// <br>Date             :   2007/03/27</br>
    /// <br>Genarated Date   :   </br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    public class PartsModelLnkWork
    {
        /// <summary>部品固有番号</summary>
        private Int64 _partsproperno;

        /// <summary>フル型式固定番号配列</summary>
        private List<Int32> _fullModelFixedNos;

        /// public propaty name  :  PartsProperNo
        /// <summary>部品固有番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   部品固有番号プロパティプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 PartsProperNo
        {
            get { return _partsproperno; }
            set { _partsproperno = value; }
        }

        /// public propaty name  :  FullModelFixedNos
        /// <summary>フル型式固定番号配列プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   フル型式固定番号配列プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public List<Int32> FullModelFixedNos
        {
            get { return _fullModelFixedNos; }
            set { _fullModelFixedNos = value; }
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public PartsModelLnkWork()
        {
        }
    }

    /// <summary>
    ///                      提供部品検索抽出条件クラスワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   提供部品検索抽出条件クラスワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :    </br>
    /// <br>Genarated Date   :   2008/05/15  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class OfrPrtsSrchCndWork
    {
        /// <summary>メーカーコード</summary>
        private Int32 _makerCode;

        /// <summary>部品品番</summary>
        private string _prtsNo = "";

        /// <summary>メーカーコードプロパティ</summary>
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

        /// <summary>部品品番プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   部品品番プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PrtsNo
        {
            get { return _prtsNo; }
            set { _prtsNo = value; }
        }

        /// <summary>
        /// 提供部品検索抽出条件クラスワークコンストラクタ
        /// </summary>
        /// <returns>OfrPrtsSrchCndWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   OfrPrtsSrchCndWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public OfrPrtsSrchCndWork()
        {
        }

        /// <summary>
        /// 提供部品検索抽出条件クラスワークコンストラクタ
        /// </summary>
        /// <returns>OfrPrtsSrchCndWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   OfrPrtsSrchCndWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public OfrPrtsSrchCndWork(OfrPrtsSrchCndWork srcObject)
        {
            _makerCode = srcObject.MakerCode;
            _prtsNo = srcObject.PrtsNo;
        }

    }

    /// <summary>
    ///                      部品一括登録検索抽出条件クラスワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   部品一括登録検索抽出条件クラスワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :    </br>
    /// <br>Genarated Date   :   2008/05/15  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class PrtsSrchCndWork
    {
        /// <summary>メーカーコード</summary>
        private Int32 _makerCode;

        /// <summary>BLコード</summary>
        private Int32 _BLCode;

        /// <summary>部品品番[前方一致検索のみ：PM7継承]</summary>
        private string _prtsNo = "";

        /// <summary>取得データMAX件数</summary>
        private Int32 _MaxCnt;

        /// <summary>メーカーコードプロパティ</summary>
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

        /// <summary>BLコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BLコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BLCode
        {
            get { return _BLCode; }
            set { _BLCode = value; }
        }

        /// <summary>部品品番プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   部品品番プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PrtsNo
        {
            get { return _prtsNo; }
            set { _prtsNo = value; }
        }

        /// <summary>取得データMAX件数プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   取得データMAX件数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 MaxCnt
        {
            get { return _MaxCnt; }
            set { _MaxCnt = value; }
        }

        /// <summary>
        /// 部品一括登録検索抽出条件クラスワークコンストラクタ
        /// </summary>
        /// <returns>PrtsSrchCndWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PrtsSrchCndWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public PrtsSrchCndWork()
        {
        }

        /// <summary>
        /// 部品一括登録検索抽出条件クラスワークコンストラクタ
        /// </summary>
        /// <returns>PrtsSrchCndWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PrtsSrchCndWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public PrtsSrchCndWork(OfrPrtsSrchCndWork srcObject)
        {
            _makerCode = srcObject.MakerCode;
            _prtsNo = srcObject.PrtsNo;
        }

    }

}
