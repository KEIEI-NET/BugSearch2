using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   StcDtlDataRefWork
    /// <summary>
    ///                      仕入明細データ参照ワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   仕入明細データ参照ワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2007/12/04  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class StcDtlDataRefWork
    {
        /// <summary>受注番号</summary>
        private Int32 _acceptAnOrderNo;

        /// <summary>仕入形式</summary>
        /// <remarks>0:仕入　（受注ステータス）</remarks>
        private Int32 _supplierFormal;

        /// <summary>仕入伝票番号</summary>
        /// <remarks>発注伝票番号、仕入伝票番号、入荷伝票番号を兼ねる</remarks>
        private Int32 _supplierSlipNo;

        /// <summary>仕入行番号</summary>
        private Int32 _stockRowNo;

        /// <summary>拠点コード</summary>
        private string _sectionCode = "";

        /// <summary>拠点名称</summary>
        private string _sectionGuideNm = "";

        /// <summary>部門コード</summary>
        private Int32 _subSectionCode;

        /// <summary>課コード</summary>
        private Int32 _minSectionCode;

        /// <summary>共通通番</summary>
        private Int64 _commonSeqNo;

        /// <summary>仕入明細通番</summary>
        private Int64 _stockSlipDtlNum;

        /// <summary>仕入形式（元）</summary>
        /// <remarks>0:仕入</remarks>
        private Int32 _supplierFormalSrc;

        /// <summary>仕入明細通番（元）</summary>
        private Int64 _stockSlipDtlNumSrc;

        /// <summary>受注ステータス（同時）</summary>
        /// <remarks>30:売上,40:出荷</remarks>
        private Int32 _acptAnOdrStatusSync;

        /// <summary>売上明細通番（同時）</summary>
        /// <remarks>同時計上時の仕入明細通番をセット</remarks>
        private Int64 _salesSlipDtlNumSync;

        /// <summary>仕入伝票区分（明細）</summary>
        /// <remarks>0:仕入,1:返品,2:値引</remarks>
        private Int32 _stockSlipCdDtl;

        /// <summary>仕入担当者コード</summary>
        private string _stockAgentCode = "";

        /// <summary>仕入担当者名称</summary>
        private string _stockAgentName = "";

        /// <summary>在庫管理有無区分</summary>
        /// <remarks>0:在庫管理しない,1:在庫管理する</remarks>
        private Int32 _stockMngExistCd;

        /// <summary>商品属性</summary>
        private Int32 _goodsKindCode;

        /// <summary>商品メーカーコード</summary>
        /// <remarks>ﾊﾟｯｹｰｼﾞ毎にﾕｰｻﾞｰ登録範囲が異なる</remarks>
        private Int32 _goodsMakerCd;

        /// <summary>メーカー名称</summary>
        private string _makerName = "";

        /// <summary>商品番号</summary>
        private string _goodsNo = "";

        /// <summary>商品名称</summary>
        private string _goodsName = "";

        /// <summary>商品区分グループコード</summary>
        /// <remarks>旧：商品大分類コード</remarks>
        private string _largeGoodsGanreCode = "";

        /// <summary>商品区分グループ名称</summary>
        /// <remarks>旧：商品大分類名称</remarks>
        private string _largeGoodsGanreName = "";

        /// <summary>商品区分コード</summary>
        /// <remarks>旧：商品中分類コード</remarks>
        private string _mediumGoodsGanreCode = "";

        /// <summary>商品区分名称</summary>
        /// <remarks>旧：商品中分類名称</remarks>
        private string _mediumGoodsGanreName = "";

        /// <summary>商品区分詳細コード</summary>
        private string _detailGoodsGanreCode = "";

        /// <summary>商品区分詳細名称</summary>
        private string _detailGoodsGanreName = "";

        /// <summary>BL商品コード</summary>
        private Int32 _bLGoodsCode;

        /// <summary>BL商品コード名称（全角）</summary>
        private string _bLGoodsFullName = "";

        /// <summary>自社分類コード</summary>
        private Int32 _enterpriseGanreCode;

        /// <summary>自社分類名称</summary>
        private string _enterpriseGanreName = "";

        /// <summary>倉庫コード</summary>
        private string _warehouseCode = "";

        /// <summary>倉庫名称</summary>
        private string _warehouseName = "";

        /// <summary>倉庫棚番</summary>
        private string _warehouseShelfNo = "";

        /// <summary>仕入在庫取寄せ区分</summary>
        /// <remarks>0:取寄せ,1:在庫</remarks>
        private Int32 _stockOrderDivCd;

        /// <summary>オープン価格区分</summary>
        /// <remarks>0:通常／1:オープン価格</remarks>
        private Int32 _openPriceDiv;

        /// <summary>単位コード</summary>
        private Int32 _unitCode;

        /// <summary>単位名称</summary>
        private string _unitName = "";

        /// <summary>商品掛率ランク</summary>
        /// <remarks>商品の掛率用ランク</remarks>
        private string _goodsRateRank = "";

        /// <summary>得意先掛率グループコード</summary>
        private Int32 _custRateGrpCode;

        /// <summary>仕入先掛率グループコード</summary>
        private Int32 _suppRateGrpCode;

        /// <summary>定価（税抜，浮動）</summary>
        /// <remarks>税抜き</remarks>
        private Double _listPriceTaxExcFl;

        /// <summary>定価（税込，浮動）</summary>
        /// <remarks>税込み</remarks>
        private Double _listPriceTaxIncFl;

        /// <summary>仕入率</summary>
        private Double _stockRate;

        /// <summary>掛率設定拠点（仕入単価）</summary>
        /// <remarks>0:全社設定, その他:拠点コード</remarks>
        private string _rateSectStckUnPrc = "";

        /// <summary>掛率設定区分（仕入単価）</summary>
        /// <remarks>A7,A8,…</remarks>
        private string _rateDivStckUnPrc = "";

        /// <summary>単価算出区分（仕入単価）</summary>
        /// <remarks>1:掛率,2:原価ＵＰ率,3:粗利率</remarks>
        private Int32 _unPrcCalcCdStckUnPrc;

        /// <summary>価格区分（仕入単価）</summary>
        /// <remarks>0:定価,1:登録販売店価格,…</remarks>
        private Int32 _priceCdStckUnPrc;

        /// <summary>基準単価（仕入単価）</summary>
        private Double _stdUnPrcStckUnPrc;

        /// <summary>端数処理単位（仕入単価）</summary>
        private Double _fracProcUnitStcUnPrc;

        /// <summary>端数処理（仕入単価）</summary>
        /// <remarks>0:切上げ,1:切捨て,2:四捨五入</remarks>
        private Int32 _fracProcStckUnPrc;

        /// <summary>仕入単価（税抜，浮動）</summary>
        /// <remarks>税抜き</remarks>
        private Double _stockUnitPriceFl;

        /// <summary>仕入単価（税込，浮動）</summary>
        /// <remarks>税込み</remarks>
        private Double _stockUnitTaxPriceFl;

        /// <summary>仕入単価変更区分</summary>
        /// <remarks>1：切捨て,2：四捨五入,3:切上げ</remarks>
        private Int32 _stockUnitChngDiv;

        /// <summary>変更前仕入単価（浮動）</summary>
        /// <remarks>税抜き、掛率算出結果</remarks>
        private Double _bfStockUnitPriceFl;

        /// <summary>BL商品コード（掛率）</summary>
        /// <remarks>掛率算出時に使用したBLコード（商品検索結果）</remarks>
        private Int32 _rateBLGoodsCode;

        /// <summary>BL商品コード名称（掛率）</summary>
        /// <remarks>掛率算出時に使用したBLコード名称（商品検索結果）</remarks>
        private string _rateBLGoodsName = "";

        /// <summary>特売区分コード</summary>
        private Int32 _bargainCd;

        /// <summary>特売区分名称</summary>
        private string _bargainNm = "";

        /// <summary>仕入数</summary>
        private Double _stockCount;

        /// <summary>仕入金額（税抜き）</summary>
        private Int64 _stockPriceTaxExc;

        /// <summary>仕入金額（税込み）</summary>
        private Int64 _stockPriceTaxInc;

        /// <summary>仕入商品区分</summary>
        /// <remarks>0:商品,1:商品外,2:消費税調整,3:残高調整,4:買掛用消費税調整,5:買掛用残高調整,6:合計入力</remarks>
        private Int32 _stockGoodsCd;

        /// <summary>仕入金額消費税額</summary>
        /// <remarks>仕入金額（税込み）- 仕入金額（税抜き）※消費税調整額も兼ねる</remarks>
        private Int64 _stockPriceConsTax;

        /// <summary>消費税調整額</summary>
        private Int64 _taxAdjust;

        /// <summary>残高調整額</summary>
        private Int64 _balanceAdjust;

        /// <summary>課税区分</summary>
        /// <remarks>0:課税,1:非課税,2:課税（内税）</remarks>
        private Int32 _taxationCode;

        /// <summary>仕入伝票明細備考1</summary>
        private string _stockDtiSlipNote1 = "";

        /// <summary>販売先コード</summary>
        private Int32 _salesCustomerCode;

        /// <summary>販売先名称</summary>
        private string _salesCustomerName = "";

        /// <summary>発注番号</summary>
        /// <remarks>発注用</remarks>
        private string _orderNumber = "";

        /// <summary>伝票メモ１</summary>
        private string _slipMemo1 = "";

        /// <summary>伝票メモ２</summary>
        private string _slipMemo2 = "";

        /// <summary>伝票メモ３</summary>
        private string _slipMemo3 = "";

        /// <summary>伝票メモ４</summary>
        private string _slipMemo4 = "";

        /// <summary>伝票メモ５</summary>
        private string _slipMemo5 = "";

        /// <summary>伝票メモ６</summary>
        private string _slipMemo6 = "";

        /// <summary>社内メモ１</summary>
        private string _insideMemo1 = "";

        /// <summary>社内メモ２</summary>
        private string _insideMemo2 = "";

        /// <summary>社内メモ３</summary>
        private string _insideMemo3 = "";

        /// <summary>社内メモ４</summary>
        private string _insideMemo4 = "";

        /// <summary>社内メモ５</summary>
        private string _insideMemo5 = "";

        /// <summary>社内メモ６</summary>
        private string _insideMemo6 = "";

        /// <summary>仕入チェック区分（締次）</summary>
        /// <remarks>0:未ﾁｪｯｸ,1:ﾁｪｯｸ済　（明細データと仕入先伝票明細の比較）</remarks>
        private Int32 _stockCheckDivCAddUp;

        /// <summary>仕入チェック区分（日次）</summary>
        /// <remarks>0:未ﾁｪｯｸ,1:ﾁｪｯｸ済　（明細データと仕入先伝票明細の比較）</remarks>
        private Int32 _stockCheckDivDaily;


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

        /// public propaty name  :  SupplierFormal
        /// <summary>仕入形式プロパティ</summary>
        /// <value>0:仕入　（受注ステータス）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入形式プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SupplierFormal
        {
            get { return _supplierFormal; }
            set { _supplierFormal = value; }
        }

        /// public propaty name  :  SupplierSlipNo
        /// <summary>仕入伝票番号プロパティ</summary>
        /// <value>発注伝票番号、仕入伝票番号、入荷伝票番号を兼ねる</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入伝票番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SupplierSlipNo
        {
            get { return _supplierSlipNo; }
            set { _supplierSlipNo = value; }
        }

        /// public propaty name  :  StockRowNo
        /// <summary>仕入行番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入行番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 StockRowNo
        {
            get { return _stockRowNo; }
            set { _stockRowNo = value; }
        }

        /// public propaty name  :  SectionCode
        /// <summary>拠点コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SectionCode
        {
            get { return _sectionCode; }
            set { _sectionCode = value; }
        }

        /// public propaty name  :  SectionGuideNm
        /// <summary>拠点名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SectionGuideNm
        {
            get { return _sectionGuideNm; }
            set { _sectionGuideNm = value; }
        }

        /// public propaty name  :  SubSectionCode
        /// <summary>部門コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   部門コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SubSectionCode
        {
            get { return _subSectionCode; }
            set { _subSectionCode = value; }
        }

        /// public propaty name  :  MinSectionCode
        /// <summary>課コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   課コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 MinSectionCode
        {
            get { return _minSectionCode; }
            set { _minSectionCode = value; }
        }

        /// public propaty name  :  CommonSeqNo
        /// <summary>共通通番プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   共通通番プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 CommonSeqNo
        {
            get { return _commonSeqNo; }
            set { _commonSeqNo = value; }
        }

        /// public propaty name  :  StockSlipDtlNum
        /// <summary>仕入明細通番プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入明細通番プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 StockSlipDtlNum
        {
            get { return _stockSlipDtlNum; }
            set { _stockSlipDtlNum = value; }
        }

        /// public propaty name  :  SupplierFormalSrc
        /// <summary>仕入形式（元）プロパティ</summary>
        /// <value>0:仕入</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入形式（元）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SupplierFormalSrc
        {
            get { return _supplierFormalSrc; }
            set { _supplierFormalSrc = value; }
        }

        /// public propaty name  :  StockSlipDtlNumSrc
        /// <summary>仕入明細通番（元）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入明細通番（元）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 StockSlipDtlNumSrc
        {
            get { return _stockSlipDtlNumSrc; }
            set { _stockSlipDtlNumSrc = value; }
        }

        /// public propaty name  :  AcptAnOdrStatusSync
        /// <summary>受注ステータス（同時）プロパティ</summary>
        /// <value>30:売上,40:出荷</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   受注ステータス（同時）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AcptAnOdrStatusSync
        {
            get { return _acptAnOdrStatusSync; }
            set { _acptAnOdrStatusSync = value; }
        }

        /// public propaty name  :  SalesSlipDtlNumSync
        /// <summary>売上明細通番（同時）プロパティ</summary>
        /// <value>同時計上時の仕入明細通番をセット</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上明細通番（同時）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesSlipDtlNumSync
        {
            get { return _salesSlipDtlNumSync; }
            set { _salesSlipDtlNumSync = value; }
        }

        /// public propaty name  :  StockSlipCdDtl
        /// <summary>仕入伝票区分（明細）プロパティ</summary>
        /// <value>0:仕入,1:返品,2:値引</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入伝票区分（明細）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 StockSlipCdDtl
        {
            get { return _stockSlipCdDtl; }
            set { _stockSlipCdDtl = value; }
        }

        /// public propaty name  :  StockAgentCode
        /// <summary>仕入担当者コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入担当者コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string StockAgentCode
        {
            get { return _stockAgentCode; }
            set { _stockAgentCode = value; }
        }

        /// public propaty name  :  StockAgentName
        /// <summary>仕入担当者名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入担当者名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string StockAgentName
        {
            get { return _stockAgentName; }
            set { _stockAgentName = value; }
        }

        /// public propaty name  :  StockMngExistCd
        /// <summary>在庫管理有無区分プロパティ</summary>
        /// <value>0:在庫管理しない,1:在庫管理する</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   在庫管理有無区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 StockMngExistCd
        {
            get { return _stockMngExistCd; }
            set { _stockMngExistCd = value; }
        }

        /// public propaty name  :  GoodsKindCode
        /// <summary>商品属性プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品属性プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsKindCode
        {
            get { return _goodsKindCode; }
            set { _goodsKindCode = value; }
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

        /// public propaty name  :  LargeGoodsGanreCode
        /// <summary>商品区分グループコードプロパティ</summary>
        /// <value>旧：商品大分類コード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品区分グループコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string LargeGoodsGanreCode
        {
            get { return _largeGoodsGanreCode; }
            set { _largeGoodsGanreCode = value; }
        }

        /// public propaty name  :  LargeGoodsGanreName
        /// <summary>商品区分グループ名称プロパティ</summary>
        /// <value>旧：商品大分類名称</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品区分グループ名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string LargeGoodsGanreName
        {
            get { return _largeGoodsGanreName; }
            set { _largeGoodsGanreName = value; }
        }

        /// public propaty name  :  MediumGoodsGanreCode
        /// <summary>商品区分コードプロパティ</summary>
        /// <value>旧：商品中分類コード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品区分コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MediumGoodsGanreCode
        {
            get { return _mediumGoodsGanreCode; }
            set { _mediumGoodsGanreCode = value; }
        }

        /// public propaty name  :  MediumGoodsGanreName
        /// <summary>商品区分名称プロパティ</summary>
        /// <value>旧：商品中分類名称</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品区分名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MediumGoodsGanreName
        {
            get { return _mediumGoodsGanreName; }
            set { _mediumGoodsGanreName = value; }
        }

        /// public propaty name  :  DetailGoodsGanreCode
        /// <summary>商品区分詳細コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品区分詳細コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DetailGoodsGanreCode
        {
            get { return _detailGoodsGanreCode; }
            set { _detailGoodsGanreCode = value; }
        }

        /// public propaty name  :  DetailGoodsGanreName
        /// <summary>商品区分詳細名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品区分詳細名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DetailGoodsGanreName
        {
            get { return _detailGoodsGanreName; }
            set { _detailGoodsGanreName = value; }
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

        /// public propaty name  :  BLGoodsFullName
        /// <summary>BL商品コード名称（全角）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL商品コード名称（全角）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string BLGoodsFullName
        {
            get { return _bLGoodsFullName; }
            set { _bLGoodsFullName = value; }
        }

        /// public propaty name  :  EnterpriseGanreCode
        /// <summary>自社分類コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社分類コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 EnterpriseGanreCode
        {
            get { return _enterpriseGanreCode; }
            set { _enterpriseGanreCode = value; }
        }

        /// public propaty name  :  EnterpriseGanreName
        /// <summary>自社分類名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社分類名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EnterpriseGanreName
        {
            get { return _enterpriseGanreName; }
            set { _enterpriseGanreName = value; }
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

        /// public propaty name  :  StockOrderDivCd
        /// <summary>仕入在庫取寄せ区分プロパティ</summary>
        /// <value>0:取寄せ,1:在庫</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入在庫取寄せ区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 StockOrderDivCd
        {
            get { return _stockOrderDivCd; }
            set { _stockOrderDivCd = value; }
        }

        /// public propaty name  :  OpenPriceDiv
        /// <summary>オープン価格区分プロパティ</summary>
        /// <value>0:通常／1:オープン価格</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   オープン価格区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 OpenPriceDiv
        {
            get { return _openPriceDiv; }
            set { _openPriceDiv = value; }
        }

        /// public propaty name  :  UnitCode
        /// <summary>単位コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   単位コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 UnitCode
        {
            get { return _unitCode; }
            set { _unitCode = value; }
        }

        /// public propaty name  :  UnitName
        /// <summary>単位名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   単位名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UnitName
        {
            get { return _unitName; }
            set { _unitName = value; }
        }

        /// public propaty name  :  GoodsRateRank
        /// <summary>商品掛率ランクプロパティ</summary>
        /// <value>商品の掛率用ランク</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品掛率ランクプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsRateRank
        {
            get { return _goodsRateRank; }
            set { _goodsRateRank = value; }
        }

        /// public propaty name  :  CustRateGrpCode
        /// <summary>得意先掛率グループコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先掛率グループコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CustRateGrpCode
        {
            get { return _custRateGrpCode; }
            set { _custRateGrpCode = value; }
        }

        /// public propaty name  :  SuppRateGrpCode
        /// <summary>仕入先掛率グループコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先掛率グループコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SuppRateGrpCode
        {
            get { return _suppRateGrpCode; }
            set { _suppRateGrpCode = value; }
        }

        /// public propaty name  :  ListPriceTaxExcFl
        /// <summary>定価（税抜，浮動）プロパティ</summary>
        /// <value>税抜き</value>
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

        /// public propaty name  :  ListPriceTaxIncFl
        /// <summary>定価（税込，浮動）プロパティ</summary>
        /// <value>税込み</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   定価（税込，浮動）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double ListPriceTaxIncFl
        {
            get { return _listPriceTaxIncFl; }
            set { _listPriceTaxIncFl = value; }
        }

        /// public propaty name  :  StockRate
        /// <summary>仕入率プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入率プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double StockRate
        {
            get { return _stockRate; }
            set { _stockRate = value; }
        }

        /// public propaty name  :  RateSectStckUnPrc
        /// <summary>掛率設定拠点（仕入単価）プロパティ</summary>
        /// <value>0:全社設定, その他:拠点コード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   掛率設定拠点（仕入単価）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string RateSectStckUnPrc
        {
            get { return _rateSectStckUnPrc; }
            set { _rateSectStckUnPrc = value; }
        }

        /// public propaty name  :  RateDivStckUnPrc
        /// <summary>掛率設定区分（仕入単価）プロパティ</summary>
        /// <value>A7,A8,…</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   掛率設定区分（仕入単価）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string RateDivStckUnPrc
        {
            get { return _rateDivStckUnPrc; }
            set { _rateDivStckUnPrc = value; }
        }

        /// public propaty name  :  UnPrcCalcCdStckUnPrc
        /// <summary>単価算出区分（仕入単価）プロパティ</summary>
        /// <value>1:掛率,2:原価ＵＰ率,3:粗利率</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   単価算出区分（仕入単価）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 UnPrcCalcCdStckUnPrc
        {
            get { return _unPrcCalcCdStckUnPrc; }
            set { _unPrcCalcCdStckUnPrc = value; }
        }

        /// public propaty name  :  PriceCdStckUnPrc
        /// <summary>価格区分（仕入単価）プロパティ</summary>
        /// <value>0:定価,1:登録販売店価格,…</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   価格区分（仕入単価）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PriceCdStckUnPrc
        {
            get { return _priceCdStckUnPrc; }
            set { _priceCdStckUnPrc = value; }
        }

        /// public propaty name  :  StdUnPrcStckUnPrc
        /// <summary>基準単価（仕入単価）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   基準単価（仕入単価）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double StdUnPrcStckUnPrc
        {
            get { return _stdUnPrcStckUnPrc; }
            set { _stdUnPrcStckUnPrc = value; }
        }

        /// public propaty name  :  FracProcUnitStcUnPrc
        /// <summary>端数処理単位（仕入単価）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   端数処理単位（仕入単価）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double FracProcUnitStcUnPrc
        {
            get { return _fracProcUnitStcUnPrc; }
            set { _fracProcUnitStcUnPrc = value; }
        }

        /// public propaty name  :  FracProcStckUnPrc
        /// <summary>端数処理（仕入単価）プロパティ</summary>
        /// <value>0:切上げ,1:切捨て,2:四捨五入</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   端数処理（仕入単価）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 FracProcStckUnPrc
        {
            get { return _fracProcStckUnPrc; }
            set { _fracProcStckUnPrc = value; }
        }

        /// public propaty name  :  StockUnitPriceFl
        /// <summary>仕入単価（税抜，浮動）プロパティ</summary>
        /// <value>税抜き</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入単価（税抜，浮動）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double StockUnitPriceFl
        {
            get { return _stockUnitPriceFl; }
            set { _stockUnitPriceFl = value; }
        }

        /// public propaty name  :  StockUnitTaxPriceFl
        /// <summary>仕入単価（税込，浮動）プロパティ</summary>
        /// <value>税込み</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入単価（税込，浮動）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double StockUnitTaxPriceFl
        {
            get { return _stockUnitTaxPriceFl; }
            set { _stockUnitTaxPriceFl = value; }
        }

        /// public propaty name  :  StockUnitChngDiv
        /// <summary>仕入単価変更区分プロパティ</summary>
        /// <value>1：切捨て,2：四捨五入,3:切上げ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入単価変更区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 StockUnitChngDiv
        {
            get { return _stockUnitChngDiv; }
            set { _stockUnitChngDiv = value; }
        }

        /// public propaty name  :  BfStockUnitPriceFl
        /// <summary>変更前仕入単価（浮動）プロパティ</summary>
        /// <value>税抜き、掛率算出結果</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   変更前仕入単価（浮動）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double BfStockUnitPriceFl
        {
            get { return _bfStockUnitPriceFl; }
            set { _bfStockUnitPriceFl = value; }
        }

        /// public propaty name  :  RateBLGoodsCode
        /// <summary>BL商品コード（掛率）プロパティ</summary>
        /// <value>掛率算出時に使用したBLコード（商品検索結果）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL商品コード（掛率）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 RateBLGoodsCode
        {
            get { return _rateBLGoodsCode; }
            set { _rateBLGoodsCode = value; }
        }

        /// public propaty name  :  RateBLGoodsName
        /// <summary>BL商品コード名称（掛率）プロパティ</summary>
        /// <value>掛率算出時に使用したBLコード名称（商品検索結果）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL商品コード名称（掛率）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string RateBLGoodsName
        {
            get { return _rateBLGoodsName; }
            set { _rateBLGoodsName = value; }
        }

        /// public propaty name  :  BargainCd
        /// <summary>特売区分コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   特売区分コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BargainCd
        {
            get { return _bargainCd; }
            set { _bargainCd = value; }
        }

        /// public propaty name  :  BargainNm
        /// <summary>特売区分名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   特売区分名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string BargainNm
        {
            get { return _bargainNm; }
            set { _bargainNm = value; }
        }

        /// public propaty name  :  StockCount
        /// <summary>仕入数プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double StockCount
        {
            get { return _stockCount; }
            set { _stockCount = value; }
        }

        /// public propaty name  :  StockPriceTaxExc
        /// <summary>仕入金額（税抜き）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入金額（税抜き）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 StockPriceTaxExc
        {
            get { return _stockPriceTaxExc; }
            set { _stockPriceTaxExc = value; }
        }

        /// public propaty name  :  StockPriceTaxInc
        /// <summary>仕入金額（税込み）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入金額（税込み）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 StockPriceTaxInc
        {
            get { return _stockPriceTaxInc; }
            set { _stockPriceTaxInc = value; }
        }

        /// public propaty name  :  StockGoodsCd
        /// <summary>仕入商品区分プロパティ</summary>
        /// <value>0:商品,1:商品外,2:消費税調整,3:残高調整,4:買掛用消費税調整,5:買掛用残高調整,6:合計入力</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入商品区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 StockGoodsCd
        {
            get { return _stockGoodsCd; }
            set { _stockGoodsCd = value; }
        }

        /// public propaty name  :  StockPriceConsTax
        /// <summary>仕入金額消費税額プロパティ</summary>
        /// <value>仕入金額（税込み）- 仕入金額（税抜き）※消費税調整額も兼ねる</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入金額消費税額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 StockPriceConsTax
        {
            get { return _stockPriceConsTax; }
            set { _stockPriceConsTax = value; }
        }

        /// public propaty name  :  TaxAdjust
        /// <summary>消費税調整額プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   消費税調整額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 TaxAdjust
        {
            get { return _taxAdjust; }
            set { _taxAdjust = value; }
        }

        /// public propaty name  :  BalanceAdjust
        /// <summary>残高調整額プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   残高調整額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 BalanceAdjust
        {
            get { return _balanceAdjust; }
            set { _balanceAdjust = value; }
        }

        /// public propaty name  :  TaxationCode
        /// <summary>課税区分プロパティ</summary>
        /// <value>0:課税,1:非課税,2:課税（内税）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   課税区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 TaxationCode
        {
            get { return _taxationCode; }
            set { _taxationCode = value; }
        }

        /// public propaty name  :  StockDtiSlipNote1
        /// <summary>仕入伝票明細備考1プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入伝票明細備考1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string StockDtiSlipNote1
        {
            get { return _stockDtiSlipNote1; }
            set { _stockDtiSlipNote1 = value; }
        }

        /// public propaty name  :  SalesCustomerCode
        /// <summary>販売先コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   販売先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SalesCustomerCode
        {
            get { return _salesCustomerCode; }
            set { _salesCustomerCode = value; }
        }

        /// public propaty name  :  SalesCustomerName
        /// <summary>販売先名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   販売先名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SalesCustomerName
        {
            get { return _salesCustomerName; }
            set { _salesCustomerName = value; }
        }

        /// public propaty name  :  OrderNumber
        /// <summary>発注番号プロパティ</summary>
        /// <value>発注用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   発注番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string OrderNumber
        {
            get { return _orderNumber; }
            set { _orderNumber = value; }
        }

        /// public propaty name  :  SlipMemo1
        /// <summary>伝票メモ１プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票メモ１プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SlipMemo1
        {
            get { return _slipMemo1; }
            set { _slipMemo1 = value; }
        }

        /// public propaty name  :  SlipMemo2
        /// <summary>伝票メモ２プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票メモ２プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SlipMemo2
        {
            get { return _slipMemo2; }
            set { _slipMemo2 = value; }
        }

        /// public propaty name  :  SlipMemo3
        /// <summary>伝票メモ３プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票メモ３プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SlipMemo3
        {
            get { return _slipMemo3; }
            set { _slipMemo3 = value; }
        }

        /// public propaty name  :  SlipMemo4
        /// <summary>伝票メモ４プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票メモ４プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SlipMemo4
        {
            get { return _slipMemo4; }
            set { _slipMemo4 = value; }
        }

        /// public propaty name  :  SlipMemo5
        /// <summary>伝票メモ５プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票メモ５プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SlipMemo5
        {
            get { return _slipMemo5; }
            set { _slipMemo5 = value; }
        }

        /// public propaty name  :  SlipMemo6
        /// <summary>伝票メモ６プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票メモ６プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SlipMemo6
        {
            get { return _slipMemo6; }
            set { _slipMemo6 = value; }
        }

        /// public propaty name  :  InsideMemo1
        /// <summary>社内メモ１プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   社内メモ１プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string InsideMemo1
        {
            get { return _insideMemo1; }
            set { _insideMemo1 = value; }
        }

        /// public propaty name  :  InsideMemo2
        /// <summary>社内メモ２プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   社内メモ２プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string InsideMemo2
        {
            get { return _insideMemo2; }
            set { _insideMemo2 = value; }
        }

        /// public propaty name  :  InsideMemo3
        /// <summary>社内メモ３プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   社内メモ３プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string InsideMemo3
        {
            get { return _insideMemo3; }
            set { _insideMemo3 = value; }
        }

        /// public propaty name  :  InsideMemo4
        /// <summary>社内メモ４プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   社内メモ４プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string InsideMemo4
        {
            get { return _insideMemo4; }
            set { _insideMemo4 = value; }
        }

        /// public propaty name  :  InsideMemo5
        /// <summary>社内メモ５プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   社内メモ５プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string InsideMemo5
        {
            get { return _insideMemo5; }
            set { _insideMemo5 = value; }
        }

        /// public propaty name  :  InsideMemo6
        /// <summary>社内メモ６プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   社内メモ６プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string InsideMemo6
        {
            get { return _insideMemo6; }
            set { _insideMemo6 = value; }
        }

        /// public propaty name  :  StockCheckDivCAddUp
        /// <summary>仕入チェック区分（締次）プロパティ</summary>
        /// <value>0:未ﾁｪｯｸ,1:ﾁｪｯｸ済　（明細データと仕入先伝票明細の比較）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入チェック区分（締次）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 StockCheckDivCAddUp
        {
            get { return _stockCheckDivCAddUp; }
            set { _stockCheckDivCAddUp = value; }
        }

        /// public propaty name  :  StockCheckDivDaily
        /// <summary>仕入チェック区分（日次）プロパティ</summary>
        /// <value>0:未ﾁｪｯｸ,1:ﾁｪｯｸ済　（明細データと仕入先伝票明細の比較）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入チェック区分（日次）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 StockCheckDivDaily
        {
            get { return _stockCheckDivDaily; }
            set { _stockCheckDivDaily = value; }
        }


        /// <summary>
        /// 仕入明細データ参照ワークコンストラクタ
        /// </summary>
        /// <returns>StcDtlDataRefWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   StcDtlDataRefWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public StcDtlDataRefWork()
        {
        }

    }
    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>StcDtlDataRefWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   StcDtlDataRefWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class StcDtlDataRefWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   StcDtlDataRefWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  StcDtlDataRefWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is StcDtlDataRefWork || graph is ArrayList || graph is StcDtlDataRefWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(StcDtlDataRefWork).FullName));

            if (graph != null && graph is StcDtlDataRefWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.StcDtlDataRefWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is StcDtlDataRefWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((StcDtlDataRefWork[])graph).Length;
            }
            else if (graph is StcDtlDataRefWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //受注番号
            serInfo.MemberInfo.Add(typeof(Int32)); //AcceptAnOrderNo
            //仕入形式
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierFormal
            //仕入伝票番号
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierSlipNo
            //仕入行番号
            serInfo.MemberInfo.Add(typeof(Int32)); //StockRowNo
            //拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //SectionCode
            //拠点名称
            serInfo.MemberInfo.Add(typeof(string)); //SectionGuideNm
            //部門コード
            serInfo.MemberInfo.Add(typeof(Int32)); //SubSectionCode
            //課コード
            serInfo.MemberInfo.Add(typeof(Int32)); //MinSectionCode
            //共通通番
            serInfo.MemberInfo.Add(typeof(Int64)); //CommonSeqNo
            //仕入明細通番
            serInfo.MemberInfo.Add(typeof(Int64)); //StockSlipDtlNum
            //仕入形式（元）
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierFormalSrc
            //仕入明細通番（元）
            serInfo.MemberInfo.Add(typeof(Int64)); //StockSlipDtlNumSrc
            //受注ステータス（同時）
            serInfo.MemberInfo.Add(typeof(Int32)); //AcptAnOdrStatusSync
            //売上明細通番（同時）
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesSlipDtlNumSync
            //仕入伝票区分（明細）
            serInfo.MemberInfo.Add(typeof(Int32)); //StockSlipCdDtl
            //仕入担当者コード
            serInfo.MemberInfo.Add(typeof(string)); //StockAgentCode
            //仕入担当者名称
            serInfo.MemberInfo.Add(typeof(string)); //StockAgentName
            //在庫管理有無区分
            serInfo.MemberInfo.Add(typeof(Int32)); //StockMngExistCd
            //商品属性
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsKindCode
            //商品メーカーコード
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd
            //メーカー名称
            serInfo.MemberInfo.Add(typeof(string)); //MakerName
            //商品番号
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNo
            //商品名称
            serInfo.MemberInfo.Add(typeof(string)); //GoodsName
            //商品区分グループコード
            serInfo.MemberInfo.Add(typeof(string)); //LargeGoodsGanreCode
            //商品区分グループ名称
            serInfo.MemberInfo.Add(typeof(string)); //LargeGoodsGanreName
            //商品区分コード
            serInfo.MemberInfo.Add(typeof(string)); //MediumGoodsGanreCode
            //商品区分名称
            serInfo.MemberInfo.Add(typeof(string)); //MediumGoodsGanreName
            //商品区分詳細コード
            serInfo.MemberInfo.Add(typeof(string)); //DetailGoodsGanreCode
            //商品区分詳細名称
            serInfo.MemberInfo.Add(typeof(string)); //DetailGoodsGanreName
            //BL商品コード
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGoodsCode
            //BL商品コード名称（全角）
            serInfo.MemberInfo.Add(typeof(string)); //BLGoodsFullName
            //自社分類コード
            serInfo.MemberInfo.Add(typeof(Int32)); //EnterpriseGanreCode
            //自社分類名称
            serInfo.MemberInfo.Add(typeof(string)); //EnterpriseGanreName
            //倉庫コード
            serInfo.MemberInfo.Add(typeof(string)); //WarehouseCode
            //倉庫名称
            serInfo.MemberInfo.Add(typeof(string)); //WarehouseName
            //倉庫棚番
            serInfo.MemberInfo.Add(typeof(string)); //WarehouseShelfNo
            //仕入在庫取寄せ区分
            serInfo.MemberInfo.Add(typeof(Int32)); //StockOrderDivCd
            //オープン価格区分
            serInfo.MemberInfo.Add(typeof(Int32)); //OpenPriceDiv
            //単位コード
            serInfo.MemberInfo.Add(typeof(Int32)); //UnitCode
            //単位名称
            serInfo.MemberInfo.Add(typeof(string)); //UnitName
            //商品掛率ランク
            serInfo.MemberInfo.Add(typeof(string)); //GoodsRateRank
            //得意先掛率グループコード
            serInfo.MemberInfo.Add(typeof(Int32)); //CustRateGrpCode
            //仕入先掛率グループコード
            serInfo.MemberInfo.Add(typeof(Int32)); //SuppRateGrpCode
            //定価（税抜，浮動）
            serInfo.MemberInfo.Add(typeof(Double)); //ListPriceTaxExcFl
            //定価（税込，浮動）
            serInfo.MemberInfo.Add(typeof(Double)); //ListPriceTaxIncFl
            //仕入率
            serInfo.MemberInfo.Add(typeof(Double)); //StockRate
            //掛率設定拠点（仕入単価）
            serInfo.MemberInfo.Add(typeof(string)); //RateSectStckUnPrc
            //掛率設定区分（仕入単価）
            serInfo.MemberInfo.Add(typeof(string)); //RateDivStckUnPrc
            //単価算出区分（仕入単価）
            serInfo.MemberInfo.Add(typeof(Int32)); //UnPrcCalcCdStckUnPrc
            //価格区分（仕入単価）
            serInfo.MemberInfo.Add(typeof(Int32)); //PriceCdStckUnPrc
            //基準単価（仕入単価）
            serInfo.MemberInfo.Add(typeof(Double)); //StdUnPrcStckUnPrc
            //端数処理単位（仕入単価）
            serInfo.MemberInfo.Add(typeof(Double)); //FracProcUnitStcUnPrc
            //端数処理（仕入単価）
            serInfo.MemberInfo.Add(typeof(Int32)); //FracProcStckUnPrc
            //仕入単価（税抜，浮動）
            serInfo.MemberInfo.Add(typeof(Double)); //StockUnitPriceFl
            //仕入単価（税込，浮動）
            serInfo.MemberInfo.Add(typeof(Double)); //StockUnitTaxPriceFl
            //仕入単価変更区分
            serInfo.MemberInfo.Add(typeof(Int32)); //StockUnitChngDiv
            //変更前仕入単価（浮動）
            serInfo.MemberInfo.Add(typeof(Double)); //BfStockUnitPriceFl
            //BL商品コード（掛率）
            serInfo.MemberInfo.Add(typeof(Int32)); //RateBLGoodsCode
            //BL商品コード名称（掛率）
            serInfo.MemberInfo.Add(typeof(string)); //RateBLGoodsName
            //特売区分コード
            serInfo.MemberInfo.Add(typeof(Int32)); //BargainCd
            //特売区分名称
            serInfo.MemberInfo.Add(typeof(string)); //BargainNm
            //仕入数
            serInfo.MemberInfo.Add(typeof(Double)); //StockCount
            //仕入金額（税抜き）
            serInfo.MemberInfo.Add(typeof(Int64)); //StockPriceTaxExc
            //仕入金額（税込み）
            serInfo.MemberInfo.Add(typeof(Int64)); //StockPriceTaxInc
            //仕入商品区分
            serInfo.MemberInfo.Add(typeof(Int32)); //StockGoodsCd
            //仕入金額消費税額
            serInfo.MemberInfo.Add(typeof(Int64)); //StockPriceConsTax
            //消費税調整額
            serInfo.MemberInfo.Add(typeof(Int64)); //TaxAdjust
            //残高調整額
            serInfo.MemberInfo.Add(typeof(Int64)); //BalanceAdjust
            //課税区分
            serInfo.MemberInfo.Add(typeof(Int32)); //TaxationCode
            //仕入伝票明細備考1
            serInfo.MemberInfo.Add(typeof(string)); //StockDtiSlipNote1
            //販売先コード
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesCustomerCode
            //販売先名称
            serInfo.MemberInfo.Add(typeof(string)); //SalesCustomerName
            //発注番号
            serInfo.MemberInfo.Add(typeof(string)); //OrderNumber
            //伝票メモ１
            serInfo.MemberInfo.Add(typeof(string)); //SlipMemo1
            //伝票メモ２
            serInfo.MemberInfo.Add(typeof(string)); //SlipMemo2
            //伝票メモ３
            serInfo.MemberInfo.Add(typeof(string)); //SlipMemo3
            //伝票メモ４
            serInfo.MemberInfo.Add(typeof(string)); //SlipMemo4
            //伝票メモ５
            serInfo.MemberInfo.Add(typeof(string)); //SlipMemo5
            //伝票メモ６
            serInfo.MemberInfo.Add(typeof(string)); //SlipMemo6
            //社内メモ１
            serInfo.MemberInfo.Add(typeof(string)); //InsideMemo1
            //社内メモ２
            serInfo.MemberInfo.Add(typeof(string)); //InsideMemo2
            //社内メモ３
            serInfo.MemberInfo.Add(typeof(string)); //InsideMemo3
            //社内メモ４
            serInfo.MemberInfo.Add(typeof(string)); //InsideMemo4
            //社内メモ５
            serInfo.MemberInfo.Add(typeof(string)); //InsideMemo5
            //社内メモ６
            serInfo.MemberInfo.Add(typeof(string)); //InsideMemo6
            //仕入チェック区分（締次）
            serInfo.MemberInfo.Add(typeof(Int32)); //StockCheckDivCAddUp
            //仕入チェック区分（日次）
            serInfo.MemberInfo.Add(typeof(Int32)); //StockCheckDivDaily


            serInfo.Serialize(writer, serInfo);
            if (graph is StcDtlDataRefWork)
            {
                StcDtlDataRefWork temp = (StcDtlDataRefWork)graph;

                SetStcDtlDataRefWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is StcDtlDataRefWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((StcDtlDataRefWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (StcDtlDataRefWork temp in lst)
                {
                    SetStcDtlDataRefWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// StcDtlDataRefWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 87;

        /// <summary>
        ///  StcDtlDataRefWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   StcDtlDataRefWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetStcDtlDataRefWork(System.IO.BinaryWriter writer, StcDtlDataRefWork temp)
        {
            //受注番号
            writer.Write(temp.AcceptAnOrderNo);
            //仕入形式
            writer.Write(temp.SupplierFormal);
            //仕入伝票番号
            writer.Write(temp.SupplierSlipNo);
            //仕入行番号
            writer.Write(temp.StockRowNo);
            //拠点コード
            writer.Write(temp.SectionCode);
            //拠点名称
            writer.Write(temp.SectionGuideNm);
            //部門コード
            writer.Write(temp.SubSectionCode);
            //課コード
            writer.Write(temp.MinSectionCode);
            //共通通番
            writer.Write(temp.CommonSeqNo);
            //仕入明細通番
            writer.Write(temp.StockSlipDtlNum);
            //仕入形式（元）
            writer.Write(temp.SupplierFormalSrc);
            //仕入明細通番（元）
            writer.Write(temp.StockSlipDtlNumSrc);
            //受注ステータス（同時）
            writer.Write(temp.AcptAnOdrStatusSync);
            //売上明細通番（同時）
            writer.Write(temp.SalesSlipDtlNumSync);
            //仕入伝票区分（明細）
            writer.Write(temp.StockSlipCdDtl);
            //仕入担当者コード
            writer.Write(temp.StockAgentCode);
            //仕入担当者名称
            writer.Write(temp.StockAgentName);
            //在庫管理有無区分
            writer.Write(temp.StockMngExistCd);
            //商品属性
            writer.Write(temp.GoodsKindCode);
            //商品メーカーコード
            writer.Write(temp.GoodsMakerCd);
            //メーカー名称
            writer.Write(temp.MakerName);
            //商品番号
            writer.Write(temp.GoodsNo);
            //商品名称
            writer.Write(temp.GoodsName);
            //商品区分グループコード
            writer.Write(temp.LargeGoodsGanreCode);
            //商品区分グループ名称
            writer.Write(temp.LargeGoodsGanreName);
            //商品区分コード
            writer.Write(temp.MediumGoodsGanreCode);
            //商品区分名称
            writer.Write(temp.MediumGoodsGanreName);
            //商品区分詳細コード
            writer.Write(temp.DetailGoodsGanreCode);
            //商品区分詳細名称
            writer.Write(temp.DetailGoodsGanreName);
            //BL商品コード
            writer.Write(temp.BLGoodsCode);
            //BL商品コード名称（全角）
            writer.Write(temp.BLGoodsFullName);
            //自社分類コード
            writer.Write(temp.EnterpriseGanreCode);
            //自社分類名称
            writer.Write(temp.EnterpriseGanreName);
            //倉庫コード
            writer.Write(temp.WarehouseCode);
            //倉庫名称
            writer.Write(temp.WarehouseName);
            //倉庫棚番
            writer.Write(temp.WarehouseShelfNo);
            //仕入在庫取寄せ区分
            writer.Write(temp.StockOrderDivCd);
            //オープン価格区分
            writer.Write(temp.OpenPriceDiv);
            //単位コード
            writer.Write(temp.UnitCode);
            //単位名称
            writer.Write(temp.UnitName);
            //商品掛率ランク
            writer.Write(temp.GoodsRateRank);
            //得意先掛率グループコード
            writer.Write(temp.CustRateGrpCode);
            //仕入先掛率グループコード
            writer.Write(temp.SuppRateGrpCode);
            //定価（税抜，浮動）
            writer.Write(temp.ListPriceTaxExcFl);
            //定価（税込，浮動）
            writer.Write(temp.ListPriceTaxIncFl);
            //仕入率
            writer.Write(temp.StockRate);
            //掛率設定拠点（仕入単価）
            writer.Write(temp.RateSectStckUnPrc);
            //掛率設定区分（仕入単価）
            writer.Write(temp.RateDivStckUnPrc);
            //単価算出区分（仕入単価）
            writer.Write(temp.UnPrcCalcCdStckUnPrc);
            //価格区分（仕入単価）
            writer.Write(temp.PriceCdStckUnPrc);
            //基準単価（仕入単価）
            writer.Write(temp.StdUnPrcStckUnPrc);
            //端数処理単位（仕入単価）
            writer.Write(temp.FracProcUnitStcUnPrc);
            //端数処理（仕入単価）
            writer.Write(temp.FracProcStckUnPrc);
            //仕入単価（税抜，浮動）
            writer.Write(temp.StockUnitPriceFl);
            //仕入単価（税込，浮動）
            writer.Write(temp.StockUnitTaxPriceFl);
            //仕入単価変更区分
            writer.Write(temp.StockUnitChngDiv);
            //変更前仕入単価（浮動）
            writer.Write(temp.BfStockUnitPriceFl);
            //BL商品コード（掛率）
            writer.Write(temp.RateBLGoodsCode);
            //BL商品コード名称（掛率）
            writer.Write(temp.RateBLGoodsName);
            //特売区分コード
            writer.Write(temp.BargainCd);
            //特売区分名称
            writer.Write(temp.BargainNm);
            //仕入数
            writer.Write(temp.StockCount);
            //仕入金額（税抜き）
            writer.Write(temp.StockPriceTaxExc);
            //仕入金額（税込み）
            writer.Write(temp.StockPriceTaxInc);
            //仕入商品区分
            writer.Write(temp.StockGoodsCd);
            //仕入金額消費税額
            writer.Write(temp.StockPriceConsTax);
            //消費税調整額
            writer.Write(temp.TaxAdjust);
            //残高調整額
            writer.Write(temp.BalanceAdjust);
            //課税区分
            writer.Write(temp.TaxationCode);
            //仕入伝票明細備考1
            writer.Write(temp.StockDtiSlipNote1);
            //販売先コード
            writer.Write(temp.SalesCustomerCode);
            //販売先名称
            writer.Write(temp.SalesCustomerName);
            //発注番号
            writer.Write(temp.OrderNumber);
            //伝票メモ１
            writer.Write(temp.SlipMemo1);
            //伝票メモ２
            writer.Write(temp.SlipMemo2);
            //伝票メモ３
            writer.Write(temp.SlipMemo3);
            //伝票メモ４
            writer.Write(temp.SlipMemo4);
            //伝票メモ５
            writer.Write(temp.SlipMemo5);
            //伝票メモ６
            writer.Write(temp.SlipMemo6);
            //社内メモ１
            writer.Write(temp.InsideMemo1);
            //社内メモ２
            writer.Write(temp.InsideMemo2);
            //社内メモ３
            writer.Write(temp.InsideMemo3);
            //社内メモ４
            writer.Write(temp.InsideMemo4);
            //社内メモ５
            writer.Write(temp.InsideMemo5);
            //社内メモ６
            writer.Write(temp.InsideMemo6);
            //仕入チェック区分（締次）
            writer.Write(temp.StockCheckDivCAddUp);
            //仕入チェック区分（日次）
            writer.Write(temp.StockCheckDivDaily);

        }

        /// <summary>
        ///  StcDtlDataRefWorkインスタンス取得
        /// </summary>
        /// <returns>StcDtlDataRefWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   StcDtlDataRefWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private StcDtlDataRefWork GetStcDtlDataRefWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            StcDtlDataRefWork temp = new StcDtlDataRefWork();

            //受注番号
            temp.AcceptAnOrderNo = reader.ReadInt32();
            //仕入形式
            temp.SupplierFormal = reader.ReadInt32();
            //仕入伝票番号
            temp.SupplierSlipNo = reader.ReadInt32();
            //仕入行番号
            temp.StockRowNo = reader.ReadInt32();
            //拠点コード
            temp.SectionCode = reader.ReadString();
            //拠点名称
            temp.SectionGuideNm = reader.ReadString();
            //部門コード
            temp.SubSectionCode = reader.ReadInt32();
            //課コード
            temp.MinSectionCode = reader.ReadInt32();
            //共通通番
            temp.CommonSeqNo = reader.ReadInt64();
            //仕入明細通番
            temp.StockSlipDtlNum = reader.ReadInt64();
            //仕入形式（元）
            temp.SupplierFormalSrc = reader.ReadInt32();
            //仕入明細通番（元）
            temp.StockSlipDtlNumSrc = reader.ReadInt64();
            //受注ステータス（同時）
            temp.AcptAnOdrStatusSync = reader.ReadInt32();
            //売上明細通番（同時）
            temp.SalesSlipDtlNumSync = reader.ReadInt64();
            //仕入伝票区分（明細）
            temp.StockSlipCdDtl = reader.ReadInt32();
            //仕入担当者コード
            temp.StockAgentCode = reader.ReadString();
            //仕入担当者名称
            temp.StockAgentName = reader.ReadString();
            //在庫管理有無区分
            temp.StockMngExistCd = reader.ReadInt32();
            //商品属性
            temp.GoodsKindCode = reader.ReadInt32();
            //商品メーカーコード
            temp.GoodsMakerCd = reader.ReadInt32();
            //メーカー名称
            temp.MakerName = reader.ReadString();
            //商品番号
            temp.GoodsNo = reader.ReadString();
            //商品名称
            temp.GoodsName = reader.ReadString();
            //商品区分グループコード
            temp.LargeGoodsGanreCode = reader.ReadString();
            //商品区分グループ名称
            temp.LargeGoodsGanreName = reader.ReadString();
            //商品区分コード
            temp.MediumGoodsGanreCode = reader.ReadString();
            //商品区分名称
            temp.MediumGoodsGanreName = reader.ReadString();
            //商品区分詳細コード
            temp.DetailGoodsGanreCode = reader.ReadString();
            //商品区分詳細名称
            temp.DetailGoodsGanreName = reader.ReadString();
            //BL商品コード
            temp.BLGoodsCode = reader.ReadInt32();
            //BL商品コード名称（全角）
            temp.BLGoodsFullName = reader.ReadString();
            //自社分類コード
            temp.EnterpriseGanreCode = reader.ReadInt32();
            //自社分類名称
            temp.EnterpriseGanreName = reader.ReadString();
            //倉庫コード
            temp.WarehouseCode = reader.ReadString();
            //倉庫名称
            temp.WarehouseName = reader.ReadString();
            //倉庫棚番
            temp.WarehouseShelfNo = reader.ReadString();
            //仕入在庫取寄せ区分
            temp.StockOrderDivCd = reader.ReadInt32();
            //オープン価格区分
            temp.OpenPriceDiv = reader.ReadInt32();
            //単位コード
            temp.UnitCode = reader.ReadInt32();
            //単位名称
            temp.UnitName = reader.ReadString();
            //商品掛率ランク
            temp.GoodsRateRank = reader.ReadString();
            //得意先掛率グループコード
            temp.CustRateGrpCode = reader.ReadInt32();
            //仕入先掛率グループコード
            temp.SuppRateGrpCode = reader.ReadInt32();
            //定価（税抜，浮動）
            temp.ListPriceTaxExcFl = reader.ReadDouble();
            //定価（税込，浮動）
            temp.ListPriceTaxIncFl = reader.ReadDouble();
            //仕入率
            temp.StockRate = reader.ReadDouble();
            //掛率設定拠点（仕入単価）
            temp.RateSectStckUnPrc = reader.ReadString();
            //掛率設定区分（仕入単価）
            temp.RateDivStckUnPrc = reader.ReadString();
            //単価算出区分（仕入単価）
            temp.UnPrcCalcCdStckUnPrc = reader.ReadInt32();
            //価格区分（仕入単価）
            temp.PriceCdStckUnPrc = reader.ReadInt32();
            //基準単価（仕入単価）
            temp.StdUnPrcStckUnPrc = reader.ReadDouble();
            //端数処理単位（仕入単価）
            temp.FracProcUnitStcUnPrc = reader.ReadDouble();
            //端数処理（仕入単価）
            temp.FracProcStckUnPrc = reader.ReadInt32();
            //仕入単価（税抜，浮動）
            temp.StockUnitPriceFl = reader.ReadDouble();
            //仕入単価（税込，浮動）
            temp.StockUnitTaxPriceFl = reader.ReadDouble();
            //仕入単価変更区分
            temp.StockUnitChngDiv = reader.ReadInt32();
            //変更前仕入単価（浮動）
            temp.BfStockUnitPriceFl = reader.ReadDouble();
            //BL商品コード（掛率）
            temp.RateBLGoodsCode = reader.ReadInt32();
            //BL商品コード名称（掛率）
            temp.RateBLGoodsName = reader.ReadString();
            //特売区分コード
            temp.BargainCd = reader.ReadInt32();
            //特売区分名称
            temp.BargainNm = reader.ReadString();
            //仕入数
            temp.StockCount = reader.ReadDouble();
            //仕入金額（税抜き）
            temp.StockPriceTaxExc = reader.ReadInt64();
            //仕入金額（税込み）
            temp.StockPriceTaxInc = reader.ReadInt64();
            //仕入商品区分
            temp.StockGoodsCd = reader.ReadInt32();
            //仕入金額消費税額
            temp.StockPriceConsTax = reader.ReadInt64();
            //消費税調整額
            temp.TaxAdjust = reader.ReadInt64();
            //残高調整額
            temp.BalanceAdjust = reader.ReadInt64();
            //課税区分
            temp.TaxationCode = reader.ReadInt32();
            //仕入伝票明細備考1
            temp.StockDtiSlipNote1 = reader.ReadString();
            //販売先コード
            temp.SalesCustomerCode = reader.ReadInt32();
            //販売先名称
            temp.SalesCustomerName = reader.ReadString();
            //発注番号
            temp.OrderNumber = reader.ReadString();
            //伝票メモ１
            temp.SlipMemo1 = reader.ReadString();
            //伝票メモ２
            temp.SlipMemo2 = reader.ReadString();
            //伝票メモ３
            temp.SlipMemo3 = reader.ReadString();
            //伝票メモ４
            temp.SlipMemo4 = reader.ReadString();
            //伝票メモ５
            temp.SlipMemo5 = reader.ReadString();
            //伝票メモ６
            temp.SlipMemo6 = reader.ReadString();
            //社内メモ１
            temp.InsideMemo1 = reader.ReadString();
            //社内メモ２
            temp.InsideMemo2 = reader.ReadString();
            //社内メモ３
            temp.InsideMemo3 = reader.ReadString();
            //社内メモ４
            temp.InsideMemo4 = reader.ReadString();
            //社内メモ５
            temp.InsideMemo5 = reader.ReadString();
            //社内メモ６
            temp.InsideMemo6 = reader.ReadString();
            //仕入チェック区分（締次）
            temp.StockCheckDivCAddUp = reader.ReadInt32();
            //仕入チェック区分（日次）
            temp.StockCheckDivDaily = reader.ReadInt32();


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
        /// <returns>StcDtlDataRefWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   StcDtlDataRefWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                StcDtlDataRefWork temp = GetStcDtlDataRefWork(reader, serInfo);
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
                    retValue = (StcDtlDataRefWork[])lst.ToArray(typeof(StcDtlDataRefWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

}
