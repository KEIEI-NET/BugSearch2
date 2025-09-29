using System;
using System.Collections;
using System.Collections.Generic;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   SalesDetail
    /// <summary>
    ///                      売上明細データ
    /// </summary>
    /// <remarks>
    /// <br>note             :   売上明細データヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2008/3/25</br>
    /// <br>Genarated Date   :   2008/10/21  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2008/6/9  杉村</br>
    /// <br>                 :   ○スペルミス修正</br>
    /// <br>                 :   販売区分コード</br>
    /// <br>                 :   販売区分名称</br>
    /// <br>                 :   売上金額消費税額</br>
    /// <br>Update Note      :   2008/6/23  長内</br>
    /// <br>                 :   ○項目追加</br>
    /// <br>                 :   商品名称カナ</br>
    /// <br>                 :   メーカーカナ名称</br>
    /// <br>                 :   メーカーカナ名称（一式）</br>
    /// <br>Update Note      :   2008/7/31  長内</br>
    /// <br>                 :   ○項目追加</br>
    /// <br>                 :   印刷用品番</br>
    /// <br>                 :   印刷用メーカーコード</br>
    /// <br>                 :   印刷用メーカー名称</br>
    /// <br>Update Note      :   2008/9/9  長内</br>
    /// <br>                 :   ○項目追加</br>
    /// <br>                 :   商品掛率グループコード（掛率）</br>
    /// <br>                 :   商品掛率グループ名称（掛率）</br>
    /// <br>                 :   BLグループコード（掛率）</br>
    /// <br>                 :   BLグループ名称（掛率）</br>
    /// <br>Update Note      :   2008/10/20  對馬</br>
    /// <br>                 :   ○売上データレイアウトに対し、以下の項目追加</br>
    /// <br>                 :   共通キー</br>
    /// <br>                 :   車両情報共通キー</br>
    /// <br>                 :   出荷数初期値、出荷数初期値(変更チェック用)</br>
    /// <br>                 :   受注数初期値、受注数初期値(変更チェック用)</br>
    /// <br>                 :   売上単価(税込)初期値、売上単価(税抜)初期値</br>
    /// <br>                 :   原単価(税込)初期値、原単価(税抜)初期値</br>
    /// <br>Update Note      :   2009/10/19 張凱</br>
    /// <br>                     PM.NS-3-A・PM.NS保守依頼②</br>
    /// <br>                     標準価格選択有無区分を追加</br>
    /// <br>Update Note      :   2010/02/26 對馬 大輔 </br>
    /// <br>                     SCM対応</br>
    /// <br>Update Note      :   2010/04/06 張凱</br>
    /// <br>                     EditStatusを追加</br>
    /// <br>Update Note      :   2011/07/18 朱宝軍</br>
    /// <br>                     自動回答区分を追加</br>
    /// <br>Update Note      :   2011/08/10 高峰</br>
    /// <br>                     自動回答区分(SCM)、受発注種別、問合せ番号、問合せ行番号を追加</br>                     
    /// <br>Update Note      : 　2012/01/16 30517 夏野 駿希</br>
    /// <br>                   　SCM改良・特記事項対応</br>
    /// <br>Update Note: 2012/05/02 20056 對馬 大輔</br>
    /// <br>管理番号   : 10801804-00 障害対応</br>
    /// <br>             改良：貸出仕入同時入力対応</br>
    /// <br>Update Note: 2012/06/15 吉岡 孝憲</br>
    /// <br>             障害対応 №90</br>
    /// <br>             SCM障害№171修正時のバグ対応。</br>
    /// <br>Update Note: 2012/06/19 湯上 千加子</br>
    /// <br>             障害対応 №104</br>
    /// <br>             システムテスト障害№90修正時のバグ対応。</br>
    /// </remarks>
    public class SalesDetail
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
        /// <remarks>10:見積,20:受注,30:売上,40:出荷,70:指示書,80:クレーム,99:一時保管  </remarks>
        private Int32 _acptAnOdrStatus;

        /// <summary>売上伝票番号</summary>
        /// <remarks>見積伝票番号,受注伝票番号,出荷伝票番号,売上伝票番号を兼ねる。</remarks>
        private string _salesSlipNum = "";

        /// <summary>売上行番号</summary>
        private Int32 _salesRowNo;

        /// <summary>売上行番号枝番</summary>
        /// <remarks>検索見積の対比で使用する</remarks>
        private Int32 _salesRowDerivNo;

        /// <summary>拠点コード</summary>
        private string _sectionCode = "";

        /// <summary>部門コード</summary>
        private Int32 _subSectionCode;

        /// <summary>売上日付</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _salesDate;

        /// <summary>共通通番</summary>
        private Int64 _commonSeqNo;

        /// <summary>売上明細通番</summary>
        private Int64 _salesSlipDtlNum;

        /// <summary>受注ステータス（元）</summary>
        /// <remarks>10:見積,20:受注,30:売上,40:出荷</remarks>
        private Int32 _acptAnOdrStatusSrc;

        /// <summary>売上明細通番（元）</summary>
        /// <remarks>計上時の元データ明細通番をセット</remarks>
        private Int64 _salesSlipDtlNumSrc;

        /// <summary>仕入形式（同時）</summary>
        /// <remarks>0:仕入,1:入荷</remarks>
        private Int32 _supplierFormalSync;

        /// <summary>仕入明細通番（同時）</summary>
        /// <remarks>同時計上時の仕入明細通番をセット</remarks>
        private Int64 _stockSlipDtlNumSync;

        /// <summary>売上伝票区分（明細）</summary>
        /// <remarks>0:売上,1:返品,2:値引,3:注釈,4:小計,5:作業</remarks>
        private Int32 _salesSlipCdDtl;

        /// <summary>納品完了予定日</summary>
        /// <remarks>客先納期(YYYYMMDD)</remarks>
        private DateTime _deliGdsCmpltDueDate;

        /// <summary>商品属性</summary>
        /// <remarks>0:純正 1:優良</remarks>
        private Int32 _goodsKindCode;

        /// <summary>商品検索区分</summary>
        /// <remarks>0:BL検索 1:品番 2:手入力</remarks>
        private Int32 _goodsSearchDivCd;

        /// <summary>商品メーカーコード</summary>
        /// <remarks>ﾊﾟｯｹｰｼﾞ毎にﾕｰｻﾞｰ登録範囲が異なる</remarks>
        private Int32 _goodsMakerCd;

        /// <summary>メーカー名称</summary>
        private string _makerName = "";

        /// <summary>メーカーカナ名称</summary>
        private string _makerKanaName = "";

        /// <summary>商品番号</summary>
        private string _goodsNo = "";

        /// <summary>商品名称</summary>
        private string _goodsName = "";

        /// <summary>商品名称カナ</summary>
        private string _goodsNameKana = "";

        /// <summary>商品大分類コード</summary>
        /// <remarks>旧大分類（ユーザーガイド）</remarks>
        private Int32 _goodsLGroup;

        /// <summary>商品大分類名称</summary>
        private string _goodsLGroupName = "";

        /// <summary>商品中分類コード</summary>
        /// <remarks>旧中分類コード</remarks>
        private Int32 _goodsMGroup;

        /// <summary>商品中分類名称</summary>
        private string _goodsMGroupName = "";

        /// <summary>BLグループコード</summary>
        /// <remarks>旧グループコード</remarks>
        private Int32 _bLGroupCode;

        /// <summary>BLグループコード名称</summary>
        private string _bLGroupName = "";

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

        /// <summary>売上在庫取寄せ区分</summary>
        /// <remarks>0:取寄せ，1:在庫</remarks>
        private Int32 _salesOrderDivCd;

        /// <summary>オープン価格区分</summary>
        /// <remarks>0:通常／1:オープン価格</remarks>
        private Int32 _openPriceDiv;

        /// <summary>商品掛率ランク</summary>
        /// <remarks>商品の掛率用ランク</remarks>
        private string _goodsRateRank = "";

        /// <summary>得意先掛率グループコード</summary>
        private Int32 _custRateGrpCode;

        /// <summary>定価率</summary>
        private Double _listPriceRate;

        /// <summary>掛率設定拠点（定価）</summary>
        /// <remarks>0:全社設定, その他:拠点コード</remarks>
        private string _rateSectPriceUnPrc = "";

        /// <summary>掛率設定区分（定価）</summary>
        /// <remarks>A1,A2,…</remarks>
        private string _rateDivLPrice = "";

        /// <summary>単価算出区分（定価）</summary>
        /// <remarks>1:掛率,2:原価ＵＰ率,3:粗利率</remarks>
        private Int32 _unPrcCalcCdLPrice;

        /// <summary>価格区分（定価）</summary>
        /// <remarks>0:定価,1:登録販売店価格,… 9:ユーザー定価</remarks>
        private Int32 _priceCdLPrice;

        /// <summary>基準単価（定価）</summary>
        private Double _stdUnPrcLPrice;

        /// <summary>端数処理単位（定価）</summary>
        private Double _fracProcUnitLPrice;

        /// <summary>端数処理（定価）</summary>
        /// <remarks>1：切捨て,2：四捨五入,3:切上げ</remarks>
        private Int32 _fracProcLPrice;

        /// <summary>定価（税込，浮動）</summary>
        /// <remarks>税抜き</remarks>
        private Double _listPriceTaxIncFl;

        /// <summary>定価（税抜，浮動）</summary>
        /// <remarks>税込み</remarks>
        private Double _listPriceTaxExcFl;

        /// <summary>定価変更区分</summary>
        /// <remarks>0:変更なし,1:変更あり　（定価手入力）</remarks>
        private Int32 _listPriceChngCd;

        /// <summary>売価率</summary>
        private Double _salesRate;

        /// <summary>掛率設定拠点（売上単価）</summary>
        /// <remarks>0:全社設定, その他:拠点コード</remarks>
        private string _rateSectSalUnPrc = "";

        /// <summary>掛率設定区分（売上単価）</summary>
        /// <remarks>A1,A2,…</remarks>
        private string _rateDivSalUnPrc = "";

        /// <summary>単価算出区分（売上単価）</summary>
        /// <remarks>1:掛率,2:原価ＵＰ率,3:粗利率</remarks>
        private Int32 _unPrcCalcCdSalUnPrc;

        /// <summary>価格区分（売上単価）</summary>
        /// <remarks>0:定価,1:登録販売店価格,…</remarks>
        private Int32 _priceCdSalUnPrc;

        /// <summary>基準単価（売上単価）</summary>
        private Double _stdUnPrcSalUnPrc;

        /// <summary>端数処理単位（売上単価）</summary>
        private Double _fracProcUnitSalUnPrc;

        /// <summary>端数処理（売上単価）</summary>
        /// <remarks>1：切捨て,2：四捨五入,3:切上げ</remarks>
        private Int32 _fracProcSalUnPrc;

        /// <summary>売上単価（税込，浮動）</summary>
        private Double _salesUnPrcTaxIncFl;

        /// <summary>売上単価（税抜，浮動）</summary>
        private Double _salesUnPrcTaxExcFl;

        /// <summary>売上単価変更区分</summary>
        /// <remarks>0:変更なし,1:変更あり　（売上単価手入力）</remarks>
        private Int32 _salesUnPrcChngCd;

        /// <summary>原価率</summary>
        private Double _costRate;

        /// <summary>掛率設定拠点（原価単価）</summary>
        /// <remarks>0:全社設定, その他:拠点コード</remarks>
        private string _rateSectCstUnPrc = "";

        /// <summary>掛率設定区分（原価単価）</summary>
        /// <remarks>A7,A8,…</remarks>
        private string _rateDivUnCst = "";

        /// <summary>単価算出区分（原価単価）</summary>
        /// <remarks>1:掛率,2:原価ＵＰ率,3:粗利率</remarks>
        private Int32 _unPrcCalcCdUnCst;

        /// <summary>価格区分（原価単価）</summary>
        /// <remarks>0:定価,1:登録販売店価格,…</remarks>
        private Int32 _priceCdUnCst;

        /// <summary>基準単価（原価単価）</summary>
        private Double _stdUnPrcUnCst;

        /// <summary>端数処理単位（原価単価）</summary>
        private Double _fracProcUnitUnCst;

        /// <summary>端数処理（原価単価）</summary>
        /// <remarks>1：切捨て,2：四捨五入,3:切上げ</remarks>
        private Int32 _fracProcUnCst;

        /// <summary>原価単価</summary>
        private Double _salesUnitCost;

        /// <summary>原価単価変更区分</summary>
        /// <remarks>0:変更なし,1:変更あり　（原価単価手入力）</remarks>
        private Int32 _salesUnitCostChngDiv;

        /// <summary>BL商品コード（掛率）</summary>
        /// <remarks>掛率算出時に使用したBLコード（商品検索結果）</remarks>
        private Int32 _rateBLGoodsCode;

        /// <summary>BL商品コード名称（掛率）</summary>
        /// <remarks>掛率算出時に使用したBLコード名称（商品検索結果）</remarks>
        private string _rateBLGoodsName = "";

        /// <summary>商品掛率グループコード（掛率）</summary>
        /// <remarks>掛率算出時に使用した商品掛率コード（商品検索結果）</remarks>
        private Int32 _rateGoodsRateGrpCd;

        /// <summary>商品掛率グループ名称（掛率）</summary>
        /// <remarks>掛率算出時に使用した商品掛率名称（商品検索結果）</remarks>
        private string _rateGoodsRateGrpNm = "";

        /// <summary>BLグループコード（掛率）</summary>
        /// <remarks>掛率算出時に使用したBLグループコード（商品検索結果）</remarks>
        private Int32 _rateBLGroupCode;

        /// <summary>BLグループ名称（掛率）</summary>
        /// <remarks>掛率算出時に使用したBLグループ名称（商品検索結果）</remarks>
        private string _rateBLGroupName = "";

        /// <summary>BL商品コード（印刷）</summary>
        /// <remarks>掛率算出時に使用したBLコード（商品検索結果）</remarks>
        private Int32 _prtBLGoodsCode;

        /// <summary>BL商品コード名称（印刷）</summary>
        /// <remarks>掛率算出時に使用したBLコード名称（商品検索結果）</remarks>
        private string _prtBLGoodsName = "";

        /// <summary>販売区分コード</summary>
        private Int32 _salesCode;

        /// <summary>販売区分名称</summary>
        private string _salesCdNm = "";

        /// <summary>作業工数</summary>
        private Double _workManHour;

        /// <summary>出荷数</summary>
        private Double _shipmentCnt;

        /// <summary>受注数量</summary>
        /// <remarks>受注,出荷で使用</remarks>
        private Double _acceptAnOrderCnt;

        /// <summary>受注調整数</summary>
        /// <remarks>現在の受注数は「受注数量＋受注調整数」で算出</remarks>
        private Double _acptAnOdrAdjustCnt;

        /// <summary>受注残数</summary>
        /// <remarks>受注数量＋受注調整数－出荷数</remarks>
        private Double _acptAnOdrRemainCnt;

        /// <summary>残数更新日</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _remainCntUpdDate;

        /// <summary>売上金額（税込み）</summary>
        private Int64 _salesMoneyTaxInc;

        /// <summary>売上金額（税抜き）</summary>
        private Int64 _salesMoneyTaxExc;

        /// <summary>原価</summary>
        private Int64 _cost;

        /// <summary>粗利チェック区分</summary>
        /// <remarks>0:正常,1:原価割れ,2:利益の上げ過ぎ</remarks>
        private Int32 _grsProfitChkDiv;

        /// <summary>売上商品区分</summary>
        /// <remarks>0:商品,1:商品外,2:消費税調整,3:残高調整,4:売掛用消費税調整,5:売掛用残高調整,10:売掛用消費税調整(自動),11:相殺,12:相殺(自動)</remarks>
        private Int32 _salesGoodsCd;

        /// <summary>売上金額消費税額</summary>
        /// <remarks>売上金額（税込み）- 売上金額（税抜き）※消費税調整額も兼ねる</remarks>
        private Int64 _salesPriceConsTax;

        /// <summary>課税区分</summary>
        /// <remarks>0:課税,1:非課税,2:課税（内税）</remarks>
        private Int32 _taxationDivCd;

        /// <summary>相手先伝票番号（明細）</summary>
        /// <remarks>得意先注文番号（仮伝No）</remarks>
        private string _partySlipNumDtl = "";

        /// <summary>明細備考</summary>
        private string _dtlNote = "";

        /// <summary>仕入先コード</summary>
        private Int32 _supplierCd;

        /// <summary>仕入先略称</summary>
        private string _supplierSnm = "";

        /// <summary>発注番号</summary>
        private string _orderNumber = "";

        /// <summary>注文方法</summary>
        /// <remarks>0:発注書発注,1:FAX送信,2:オンライン発注,4:発注済事後登録</remarks>
        private Int32 _wayToOrder;

        /// <summary>伝票メモ１</summary>
        private string _slipMemo1 = "";

        /// <summary>伝票メモ２</summary>
        private string _slipMemo2 = "";

        /// <summary>伝票メモ３</summary>
        private string _slipMemo3 = "";

        /// <summary>社内メモ１</summary>
        private string _insideMemo1 = "";

        /// <summary>社内メモ２</summary>
        private string _insideMemo2 = "";

        /// <summary>社内メモ３</summary>
        private string _insideMemo3 = "";

        /// <summary>変更前定価</summary>
        /// <remarks>税抜き、掛率算出結果</remarks>
        private Double _bfListPrice;

        /// <summary>変更前売価</summary>
        /// <remarks>税抜き、掛率算出結果</remarks>
        private Double _bfSalesUnitPrice;

        /// <summary>変更前原価</summary>
        /// <remarks>税抜き、掛率算出結果</remarks>
        private Double _bfUnitCost;

        /// <summary>一式明細番号</summary>
        /// <remarks>0:一式なし　1～一式連番</remarks>
        private Int32 _cmpltSalesRowNo;

        /// <summary>メーカーコード（一式）</summary>
        private Int32 _cmpltGoodsMakerCd;

        /// <summary>メーカー名称（一式）</summary>
        private string _cmpltMakerName = "";

        /// <summary>メーカーカナ名称（一式）</summary>
        private string _cmpltMakerKanaName = "";

        /// <summary>商品名称（一式）</summary>
        private string _cmpltGoodsName = "";

        /// <summary>数量（一式）</summary>
        private Double _cmpltShipmentCnt;

        /// <summary>売上単価（一式）</summary>
        /// <remarks>売上金額（一式の合計）/ 数量  ※少数第３位四捨五入</remarks>
        private Double _cmpltSalesUnPrcFl;

        /// <summary>売上金額（一式）</summary>
        /// <remarks>売上金額（税抜き）の同一一式明細の合計</remarks>
        private Int64 _cmpltSalesMoney;

        /// <summary>原価単価（一式）</summary>
        /// <remarks>原価金額（一式の合計）/ 数量  ※少数第３位四捨五入</remarks>
        private Double _cmpltSalesUnitCost;

        /// <summary>原価金額（一式）</summary>
        /// <remarks>原価の同一一式明細の合計</remarks>
        private Int64 _cmpltCost;

        /// <summary>相手先伝票番号（一式）</summary>
        /// <remarks>得意先注文番号</remarks>
        private string _cmpltPartySalSlNum = "";

        /// <summary>一式備考</summary>
        private string _cmpltNote = "";

        // --- ADD 2009/10/19 ---------->>>>>
        /// <summary>印刷用品番有効区分</summary>
        private Int32 _selectedGoodsNoDiv;
        // --- ADD 2009/10/19 ----------<<<<<

        /// <summary>印刷用品番</summary>
        private string _prtGoodsNo = "";

        /// <summary>印刷用メーカーコード</summary>
        private Int32 _prtMakerCode;

        /// <summary>印刷用メーカー名称</summary>
        private string _prtMakerName = "";

        /// <summary>共通キー</summary>
        private Guid _dtlRelationGuid;

        /// <summary>車両情報共通キー</summary>
        private Guid _carRelationGuid;

        /// <summary>出荷数初期値</summary>
        private Double _shipmentCntDefault;

        /// <summary>出荷数初期値（変更チェック用）</summary>
        /// <remarks>新規:検索結果(出荷数),修正:出荷数</remarks>
        private Double _shipmentCntDefForChk;

        /// <summary>受注数初期値</summary>
        private Double _acceptAnOrderCntDefault;

        /// <summary>受注数初期値（変更チェック用）</summary>
        /// <remarks>新規:検索結果(出荷数),修正:出荷数(受注データ)</remarks>
        private Double _acceptAnOrderCntDefForChk;

        /// <summary>売上単価（税込，浮動）初期値</summary>
        private Double _salesUnPrcTaxIncFlDefault;

        /// <summary>売上単価（税抜，浮動）初期値</summary>
        private Double _salesUnPrcTaxExcFlDefault;

        /// <summary>原価単価（税込）初期値</summary>
        private Double _salesUnitCostTaxIncDefault;

        /// <summary>原価単価（税抜）初期値</summary>
        private Double _salesUnitCostTacExcDefault;

        //>>>2010/02/26
        /// <summary>キャンペーンコード</summary>
        /// <remarks>拠点と連結でキーとなるので注意（管理拠点コード）</remarks>
        private Int32 _campaignCode;

        /// <summary>キャンペーン名称</summary>
        private string _campaignName = "";

        /// <summary>商品種別</summary>
        /// <remarks>0:純正部品 1:優良部品 2:リビルド 3:中古 4:平均相場</remarks>
        private Int32 _goodsDivCd;

        /// <summary>回答納期</summary>
        private string _answerDelivDate = "";

        /// <summary>リサイクル区分</summary>
        /// <remarks>RCのマスタ項目</remarks>
        private Int32 _recycleDiv;

        /// <summary>リサイクル区分名称</summary>
        /// <remarks>RCのマスタ名称</remarks>
        private string _recycleDivNm = "";

        /// <summary>受注方法</summary>
        /// <remarks>0:通常,1:オンライン（SCM）</remarks>
        private Int32 _wayToAcptOdr;

        /// <summary>商品管理番号</summary>
        /// <remarks>PS管理番号</remarks>
        private Int32 _goodsMngNo;

        /// <summary>問合せ行番号</summary>
        private Int32 _inqRowNumber;

        /// <summary>問合せ行番号枝番</summary>
        private Int32 _inqRowNumDerivedNo;
        //<<<2010/02/26

        /// <summary>企業名称</summary>
        private string _enterpriseName = "";

        /// <summary>更新従業員名称</summary>
        private string _updEmployeeName = "";

        /// <summary>BL商品コード名称</summary>
        private string _bLGoodsName = "";

        // --- ADD 2010/04/06 ---------->>>>>
        /// <summary>行状態</summary>
        private int _editStatus;

        /// <summary>行状態</summary>
        private int _rowStatus;

        /// <summary>金額手入力区分</summary>
        private int _salesMoneyInputDiv;

        /// <summary>出荷数(表示用)</summary>
        private double _shipmentCntDisplay;

        /// <summary>現在庫数(表示用)</summary>
        private double _supplierStockDisplay;

        /// <summary>標準価格(表示用)</summary>
        private double _listPriceDisplay;

        /// <summary>仕入日</summary>
        private DateTime _stockDate;

        /// <summary>BO</summary>
        private string _boCode;

        /// <summary>発注先</summary>
        private int _supplierCdForOrder;

        /// <summary>発注先名称</summary>
        private string _supplierSnmForOrder;

        /// <summary>納品区分</summary>
        private string _deliveredGoodsDivNm;

        /// <summary>Ｈ納品区分</summary>
        private string _followDeliGoodsDivNm;

        /// <summary>指定拠点</summary>
        private string _uOEResvdSectionNm;

        /// <summary>納品区分</summary>
        private string _uOEDeliGoodsDiv;

        /// <summary>Ｈ納品区分</summary>
        private string _followDeliGoodsDiv;

        /// <summary>指定拠点</summary>
        private string _uOEResvdSection;

        /// <summary>仕入伝票番号</summary>
        private string _partySalesSlipNum;

        /// <summary>部品検索状態</summary>
        private int _searchPartsModeState;
        // --- ADD 2009/04/06 ----------<<<<<

        // 2012/01/16 Add >>>
        /// <summary>特記事項</summary>
        private string _goodsSpecialNote = string.Empty;
        // 2012/01/16 Add <<<

        //>>>2012/05/02
        /// <summary>貸出同時仕入先</summary>
        private Int32 _rentSyncSupplier = 0;
        /// <summary>貸出同時仕入日</summary>
        private DateTime _rentSyncStockDate = DateTime.MinValue;
        /// <summary>貸出同時仕入伝票番号</summary>
        private string _rentSyncSupSlipNo = string.Empty;
        //<<<2012/05/02

        // ---------------------- ADD START 2011/07/18 朱宝軍 ----------------->>>>>
        /// <summary>自動回答区分(SCM)</summary>
        /// <remarks>0:通常(PCC連携なし)、1:手動回答、2:自動回答</remarks>
        private Int32 _autoAnswerDivSCM;

        /// public propaty name  :  AutoAnswerDivSCM
        /// <summary>自動回答区分(SCM)プロパティ</summary>
        /// <value>1:通常(PCC連携なし)、2:手動回答、3:自動回答</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自動回答区分(SCM)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AutoAnswerDivSCM
        {
            get { return _autoAnswerDivSCM; }
            set { _autoAnswerDivSCM = value; }
        }
        // ---------------------- ADD END   2011.02.09 朱宝軍 -----------------<<<<<

        // 2012/06/15 ADD T.Yoshioka 90 ---------------->>>>>>>>>>>>>>>>>>>>>>>>> 
        /// <summary>純正商品メーカーコード</summary>
        private Int32 _pureGoodsMakerCd;
        /// <summary>純正商品メーカーコード</summary>
        public Int32 PureGoodsMakerCd
        {
            get { return _pureGoodsMakerCd; }
            set { _pureGoodsMakerCd = value; }
        }

        /// <summary>回答純正商品番号</summary>
        // UPD 2012/06/19 C.Yugami 104 ----------------->>>>>
        //private string _ansPureGoodsNo;
        private string _ansPureGoodsNo = string.Empty;
        // UPD 2012/06/19 C.Yugami 104 -----------------<<<<<
        /// <summary>回答純正商品番号</summary>
        public string AnsPureGoodsNo
        {
            get { return _ansPureGoodsNo; }
            set { _ansPureGoodsNo = value; }
        }
        // 2012/06/15 ADD T.Yoshioka 90 ----------------<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
        
        // --- ADD 2011/08/08 ---------->>>>>
        /// <summary>受発注種別</summary>
        private Int16 _acceptOrOrderKind;

        /// <summary>問合せ番号</summary>
        private Int64 _inquiryNumber;
        // --- ADD 2011/08/08 ----------<<<<<        


        // ----ADD 2013/01/24 鄧潘ハン REDMINE#34605---- >>>>>
        /// <summary>標準価格選択区分</summary>
        /// <remarks>0:優良,1:純正,2:高い方(1:N),,3:高い方(1:1)</remarks>
        private Int32 _priceSelectDiv;
        // ----ADD 2013/01/24 鄧潘ハン REDMINE#34605---- <<<<<

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
        /// <value>10:見積,20:受注,30:売上,40:出荷,70:指示書,80:クレーム,99:一時保管  </value>
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

        /// public propaty name  :  SalesSlipNum
        /// <summary>売上伝票番号プロパティ</summary>
        /// <value>見積伝票番号,受注伝票番号,出荷伝票番号,売上伝票番号を兼ねる。</value>
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

        /// public propaty name  :  SalesRowNo
        /// <summary>売上行番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上行番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SalesRowNo
        {
            get { return _salesRowNo; }
            set { _salesRowNo = value; }
        }

        /// public propaty name  :  SalesRowDerivNo
        /// <summary>売上行番号枝番プロパティ</summary>
        /// <value>検索見積の対比で使用する</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上行番号枝番プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SalesRowDerivNo
        {
            get { return _salesRowDerivNo; }
            set { _salesRowDerivNo = value; }
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

        /// public propaty name  :  SalesDate
        /// <summary>売上日付プロパティ</summary>
        /// <value>YYYYMMDD</value>
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

        /// public propaty name  :  SalesDateJpFormal
        /// <summary>売上日付 和暦プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上日付 和暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SalesDateJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _salesDate); }
            set { }
        }

        /// public propaty name  :  SalesDateJpInFormal
        /// <summary>売上日付 和暦(略)プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上日付 和暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SalesDateJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _salesDate); }
            set { }
        }

        /// public propaty name  :  SalesDateAdFormal
        /// <summary>売上日付 西暦プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上日付 西暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SalesDateAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _salesDate); }
            set { }
        }

        /// public propaty name  :  SalesDateAdInFormal
        /// <summary>売上日付 西暦(略)プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上日付 西暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SalesDateAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _salesDate); }
            set { }
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

        /// public propaty name  :  SalesSlipDtlNum
        /// <summary>売上明細通番プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上明細通番プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesSlipDtlNum
        {
            get { return _salesSlipDtlNum; }
            set { _salesSlipDtlNum = value; }
        }

        /// public propaty name  :  AcptAnOdrStatusSrc
        /// <summary>受注ステータス（元）プロパティ</summary>
        /// <value>10:見積,20:受注,30:売上,40:出荷</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   受注ステータス（元）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AcptAnOdrStatusSrc
        {
            get { return _acptAnOdrStatusSrc; }
            set { _acptAnOdrStatusSrc = value; }
        }

        /// public propaty name  :  SalesSlipDtlNumSrc
        /// <summary>売上明細通番（元）プロパティ</summary>
        /// <value>計上時の元データ明細通番をセット</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上明細通番（元）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesSlipDtlNumSrc
        {
            get { return _salesSlipDtlNumSrc; }
            set { _salesSlipDtlNumSrc = value; }
        }

        /// public propaty name  :  SupplierFormalSync
        /// <summary>仕入形式（同時）プロパティ</summary>
        /// <value>0:仕入,1:入荷</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入形式（同時）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SupplierFormalSync
        {
            get { return _supplierFormalSync; }
            set { _supplierFormalSync = value; }
        }

        /// public propaty name  :  StockSlipDtlNumSync
        /// <summary>仕入明細通番（同時）プロパティ</summary>
        /// <value>同時計上時の仕入明細通番をセット</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入明細通番（同時）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 StockSlipDtlNumSync
        {
            get { return _stockSlipDtlNumSync; }
            set { _stockSlipDtlNumSync = value; }
        }

        /// public propaty name  :  SalesSlipCdDtl
        /// <summary>売上伝票区分（明細）プロパティ</summary>
        /// <value>0:売上,1:返品,2:値引,3:注釈,4:小計,5:作業</value>
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

        /// public propaty name  :  DeliGdsCmpltDueDate
        /// <summary>納品完了予定日プロパティ</summary>
        /// <value>客先納期(YYYYMMDD)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   納品完了予定日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime DeliGdsCmpltDueDate
        {
            get { return _deliGdsCmpltDueDate; }
            set { _deliGdsCmpltDueDate = value; }
        }

        /// public propaty name  :  DeliGdsCmpltDueDateJpFormal
        /// <summary>納品完了予定日 和暦プロパティ</summary>
        /// <value>客先納期(YYYYMMDD)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   納品完了予定日 和暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DeliGdsCmpltDueDateJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _deliGdsCmpltDueDate); }
            set { }
        }

        /// public propaty name  :  DeliGdsCmpltDueDateJpInFormal
        /// <summary>納品完了予定日 和暦(略)プロパティ</summary>
        /// <value>客先納期(YYYYMMDD)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   納品完了予定日 和暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DeliGdsCmpltDueDateJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _deliGdsCmpltDueDate); }
            set { }
        }

        /// public propaty name  :  DeliGdsCmpltDueDateAdFormal
        /// <summary>納品完了予定日 西暦プロパティ</summary>
        /// <value>客先納期(YYYYMMDD)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   納品完了予定日 西暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DeliGdsCmpltDueDateAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _deliGdsCmpltDueDate); }
            set { }
        }

        /// public propaty name  :  DeliGdsCmpltDueDateAdInFormal
        /// <summary>納品完了予定日 西暦(略)プロパティ</summary>
        /// <value>客先納期(YYYYMMDD)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   納品完了予定日 西暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DeliGdsCmpltDueDateAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _deliGdsCmpltDueDate); }
            set { }
        }

        /// public propaty name  :  GoodsKindCode
        /// <summary>商品属性プロパティ</summary>
        /// <value>0:純正 1:優良</value>
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

        /// public propaty name  :  GoodsSearchDivCd
        /// <summary>商品検索区分プロパティ</summary>
        /// <value>0:BL検索 1:品番 2:手入力</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品検索区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsSearchDivCd
        {
            get { return _goodsSearchDivCd; }
            set { _goodsSearchDivCd = value; }
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

        /// public propaty name  :  MakerKanaName
        /// <summary>メーカーカナ名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メーカーカナ名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MakerKanaName
        {
            get { return _makerKanaName; }
            set { _makerKanaName = value; }
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

        /// public propaty name  :  GoodsNameKana
        /// <summary>商品名称カナプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品名称カナプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsNameKana
        {
            get { return _goodsNameKana; }
            set { _goodsNameKana = value; }
        }

        /// public propaty name  :  GoodsLGroup
        /// <summary>商品大分類コードプロパティ</summary>
        /// <value>旧大分類（ユーザーガイド）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品大分類コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsLGroup
        {
            get { return _goodsLGroup; }
            set { _goodsLGroup = value; }
        }

        /// public propaty name  :  GoodsLGroupName
        /// <summary>商品大分類名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品大分類名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsLGroupName
        {
            get { return _goodsLGroupName; }
            set { _goodsLGroupName = value; }
        }

        /// public propaty name  :  GoodsMGroup
        /// <summary>商品中分類コードプロパティ</summary>
        /// <value>旧中分類コード</value>
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

        /// public propaty name  :  GoodsMGroupName
        /// <summary>商品中分類名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品中分類名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsMGroupName
        {
            get { return _goodsMGroupName; }
            set { _goodsMGroupName = value; }
        }

        /// public propaty name  :  BLGroupCode
        /// <summary>BLグループコードプロパティ</summary>
        /// <value>旧グループコード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BLグループコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BLGroupCode
        {
            get { return _bLGroupCode; }
            set { _bLGroupCode = value; }
        }

        /// public propaty name  :  BLGroupName
        /// <summary>BLグループコード名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BLグループコード名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string BLGroupName
        {
            get { return _bLGroupName; }
            set { _bLGroupName = value; }
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

        /// public propaty name  :  ListPriceRate
        /// <summary>定価率プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   定価率プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double ListPriceRate
        {
            get { return _listPriceRate; }
            set { _listPriceRate = value; }
        }

        /// public propaty name  :  RateSectPriceUnPrc
        /// <summary>掛率設定拠点（定価）プロパティ</summary>
        /// <value>0:全社設定, その他:拠点コード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   掛率設定拠点（定価）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string RateSectPriceUnPrc
        {
            get { return _rateSectPriceUnPrc; }
            set { _rateSectPriceUnPrc = value; }
        }

        /// public propaty name  :  RateDivLPrice
        /// <summary>掛率設定区分（定価）プロパティ</summary>
        /// <value>A1,A2,…</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   掛率設定区分（定価）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string RateDivLPrice
        {
            get { return _rateDivLPrice; }
            set { _rateDivLPrice = value; }
        }

        /// public propaty name  :  UnPrcCalcCdLPrice
        /// <summary>単価算出区分（定価）プロパティ</summary>
        /// <value>1:掛率,2:原価ＵＰ率,3:粗利率</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   単価算出区分（定価）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 UnPrcCalcCdLPrice
        {
            get { return _unPrcCalcCdLPrice; }
            set { _unPrcCalcCdLPrice = value; }
        }

        /// public propaty name  :  PriceCdLPrice
        /// <summary>価格区分（定価）プロパティ</summary>
        /// <value>0:定価,1:登録販売店価格,… 9:ユーザー定価</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   価格区分（定価）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PriceCdLPrice
        {
            get { return _priceCdLPrice; }
            set { _priceCdLPrice = value; }
        }

        /// public propaty name  :  StdUnPrcLPrice
        /// <summary>基準単価（定価）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   基準単価（定価）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double StdUnPrcLPrice
        {
            get { return _stdUnPrcLPrice; }
            set { _stdUnPrcLPrice = value; }
        }

        /// public propaty name  :  FracProcUnitLPrice
        /// <summary>端数処理単位（定価）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   端数処理単位（定価）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double FracProcUnitLPrice
        {
            get { return _fracProcUnitLPrice; }
            set { _fracProcUnitLPrice = value; }
        }

        /// public propaty name  :  FracProcLPrice
        /// <summary>端数処理（定価）プロパティ</summary>
        /// <value>1：切捨て,2：四捨五入,3:切上げ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   端数処理（定価）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 FracProcLPrice
        {
            get { return _fracProcLPrice; }
            set { _fracProcLPrice = value; }
        }

        /// public propaty name  :  ListPriceTaxIncFl
        /// <summary>定価（税込，浮動）プロパティ</summary>
        /// <value>税抜き</value>
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

        /// public propaty name  :  ListPriceChngCd
        /// <summary>定価変更区分プロパティ</summary>
        /// <value>0:変更なし,1:変更あり　（定価手入力）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   定価変更区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ListPriceChngCd
        {
            get { return _listPriceChngCd; }
            set { _listPriceChngCd = value; }
        }

        /// public propaty name  :  SalesRate
        /// <summary>売価率プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売価率プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double SalesRate
        {
            get { return _salesRate; }
            set { _salesRate = value; }
        }

        /// public propaty name  :  RateSectSalUnPrc
        /// <summary>掛率設定拠点（売上単価）プロパティ</summary>
        /// <value>0:全社設定, その他:拠点コード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   掛率設定拠点（売上単価）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string RateSectSalUnPrc
        {
            get { return _rateSectSalUnPrc; }
            set { _rateSectSalUnPrc = value; }
        }

        /// public propaty name  :  RateDivSalUnPrc
        /// <summary>掛率設定区分（売上単価）プロパティ</summary>
        /// <value>A1,A2,…</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   掛率設定区分（売上単価）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string RateDivSalUnPrc
        {
            get { return _rateDivSalUnPrc; }
            set { _rateDivSalUnPrc = value; }
        }

        /// public propaty name  :  UnPrcCalcCdSalUnPrc
        /// <summary>単価算出区分（売上単価）プロパティ</summary>
        /// <value>1:掛率,2:原価ＵＰ率,3:粗利率</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   単価算出区分（売上単価）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 UnPrcCalcCdSalUnPrc
        {
            get { return _unPrcCalcCdSalUnPrc; }
            set { _unPrcCalcCdSalUnPrc = value; }
        }

        /// public propaty name  :  PriceCdSalUnPrc
        /// <summary>価格区分（売上単価）プロパティ</summary>
        /// <value>0:定価,1:登録販売店価格,…</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   価格区分（売上単価）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PriceCdSalUnPrc
        {
            get { return _priceCdSalUnPrc; }
            set { _priceCdSalUnPrc = value; }
        }

        /// public propaty name  :  StdUnPrcSalUnPrc
        /// <summary>基準単価（売上単価）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   基準単価（売上単価）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double StdUnPrcSalUnPrc
        {
            get { return _stdUnPrcSalUnPrc; }
            set { _stdUnPrcSalUnPrc = value; }
        }

        /// public propaty name  :  FracProcUnitSalUnPrc
        /// <summary>端数処理単位（売上単価）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   端数処理単位（売上単価）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double FracProcUnitSalUnPrc
        {
            get { return _fracProcUnitSalUnPrc; }
            set { _fracProcUnitSalUnPrc = value; }
        }

        /// public propaty name  :  FracProcSalUnPrc
        /// <summary>端数処理（売上単価）プロパティ</summary>
        /// <value>1：切捨て,2：四捨五入,3:切上げ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   端数処理（売上単価）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 FracProcSalUnPrc
        {
            get { return _fracProcSalUnPrc; }
            set { _fracProcSalUnPrc = value; }
        }

        /// public propaty name  :  SalesUnPrcTaxIncFl
        /// <summary>売上単価（税込，浮動）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上単価（税込，浮動）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double SalesUnPrcTaxIncFl
        {
            get { return _salesUnPrcTaxIncFl; }
            set { _salesUnPrcTaxIncFl = value; }
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

        /// public propaty name  :  SalesUnPrcChngCd
        /// <summary>売上単価変更区分プロパティ</summary>
        /// <value>0:変更なし,1:変更あり　（売上単価手入力）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上単価変更区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SalesUnPrcChngCd
        {
            get { return _salesUnPrcChngCd; }
            set { _salesUnPrcChngCd = value; }
        }

        /// public propaty name  :  CostRate
        /// <summary>原価率プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   原価率プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double CostRate
        {
            get { return _costRate; }
            set { _costRate = value; }
        }

        /// public propaty name  :  RateSectCstUnPrc
        /// <summary>掛率設定拠点（原価単価）プロパティ</summary>
        /// <value>0:全社設定, その他:拠点コード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   掛率設定拠点（原価単価）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string RateSectCstUnPrc
        {
            get { return _rateSectCstUnPrc; }
            set { _rateSectCstUnPrc = value; }
        }

        /// public propaty name  :  RateDivUnCst
        /// <summary>掛率設定区分（原価単価）プロパティ</summary>
        /// <value>A7,A8,…</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   掛率設定区分（原価単価）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string RateDivUnCst
        {
            get { return _rateDivUnCst; }
            set { _rateDivUnCst = value; }
        }

        /// public propaty name  :  UnPrcCalcCdUnCst
        /// <summary>単価算出区分（原価単価）プロパティ</summary>
        /// <value>1:掛率,2:原価ＵＰ率,3:粗利率</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   単価算出区分（原価単価）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 UnPrcCalcCdUnCst
        {
            get { return _unPrcCalcCdUnCst; }
            set { _unPrcCalcCdUnCst = value; }
        }

        /// public propaty name  :  PriceCdUnCst
        /// <summary>価格区分（原価単価）プロパティ</summary>
        /// <value>0:定価,1:登録販売店価格,…</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   価格区分（原価単価）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PriceCdUnCst
        {
            get { return _priceCdUnCst; }
            set { _priceCdUnCst = value; }
        }

        /// public propaty name  :  StdUnPrcUnCst
        /// <summary>基準単価（原価単価）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   基準単価（原価単価）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double StdUnPrcUnCst
        {
            get { return _stdUnPrcUnCst; }
            set { _stdUnPrcUnCst = value; }
        }

        /// public propaty name  :  FracProcUnitUnCst
        /// <summary>端数処理単位（原価単価）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   端数処理単位（原価単価）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double FracProcUnitUnCst
        {
            get { return _fracProcUnitUnCst; }
            set { _fracProcUnitUnCst = value; }
        }

        /// public propaty name  :  FracProcUnCst
        /// <summary>端数処理（原価単価）プロパティ</summary>
        /// <value>1：切捨て,2：四捨五入,3:切上げ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   端数処理（原価単価）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 FracProcUnCst
        {
            get { return _fracProcUnCst; }
            set { _fracProcUnCst = value; }
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

        /// public propaty name  :  SalesUnitCostChngDiv
        /// <summary>原価単価変更区分プロパティ</summary>
        /// <value>0:変更なし,1:変更あり　（原価単価手入力）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   原価単価変更区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SalesUnitCostChngDiv
        {
            get { return _salesUnitCostChngDiv; }
            set { _salesUnitCostChngDiv = value; }
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

        /// public propaty name  :  RateGoodsRateGrpCd
        /// <summary>商品掛率グループコード（掛率）プロパティ</summary>
        /// <value>掛率算出時に使用した商品掛率コード（商品検索結果）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品掛率グループコード（掛率）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 RateGoodsRateGrpCd
        {
            get { return _rateGoodsRateGrpCd; }
            set { _rateGoodsRateGrpCd = value; }
        }

        /// public propaty name  :  RateGoodsRateGrpNm
        /// <summary>商品掛率グループ名称（掛率）プロパティ</summary>
        /// <value>掛率算出時に使用した商品掛率名称（商品検索結果）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品掛率グループ名称（掛率）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string RateGoodsRateGrpNm
        {
            get { return _rateGoodsRateGrpNm; }
            set { _rateGoodsRateGrpNm = value; }
        }

        /// public propaty name  :  RateBLGroupCode
        /// <summary>BLグループコード（掛率）プロパティ</summary>
        /// <value>掛率算出時に使用したBLグループコード（商品検索結果）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BLグループコード（掛率）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 RateBLGroupCode
        {
            get { return _rateBLGroupCode; }
            set { _rateBLGroupCode = value; }
        }

        /// public propaty name  :  RateBLGroupName
        /// <summary>BLグループ名称（掛率）プロパティ</summary>
        /// <value>掛率算出時に使用したBLグループ名称（商品検索結果）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BLグループ名称（掛率）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string RateBLGroupName
        {
            get { return _rateBLGroupName; }
            set { _rateBLGroupName = value; }
        }

        /// public propaty name  :  PrtBLGoodsCode
        /// <summary>BL商品コード（印刷）プロパティ</summary>
        /// <value>掛率算出時に使用したBLコード（商品検索結果）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL商品コード（印刷）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PrtBLGoodsCode
        {
            get { return _prtBLGoodsCode; }
            set { _prtBLGoodsCode = value; }
        }

        /// public propaty name  :  PrtBLGoodsName
        /// <summary>BL商品コード名称（印刷）プロパティ</summary>
        /// <value>掛率算出時に使用したBLコード名称（商品検索結果）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL商品コード名称（印刷）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PrtBLGoodsName
        {
            get { return _prtBLGoodsName; }
            set { _prtBLGoodsName = value; }
        }

        /// public propaty name  :  SalesCode
        /// <summary>販売区分コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   販売区分コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SalesCode
        {
            get { return _salesCode; }
            set { _salesCode = value; }
        }

        /// public propaty name  :  SalesCdNm
        /// <summary>販売区分名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   販売区分名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SalesCdNm
        {
            get { return _salesCdNm; }
            set { _salesCdNm = value; }
        }

        /// public propaty name  :  WorkManHour
        /// <summary>作業工数プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   作業工数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double WorkManHour
        {
            get { return _workManHour; }
            set { _workManHour = value; }
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

        /// public propaty name  :  AcceptAnOrderCnt
        /// <summary>受注数量プロパティ</summary>
        /// <value>受注,出荷で使用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   受注数量プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double AcceptAnOrderCnt
        {
            get { return _acceptAnOrderCnt; }
            set { _acceptAnOrderCnt = value; }
        }

        /// public propaty name  :  AcptAnOdrAdjustCnt
        /// <summary>受注調整数プロパティ</summary>
        /// <value>現在の受注数は「受注数量＋受注調整数」で算出</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   受注調整数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double AcptAnOdrAdjustCnt
        {
            get { return _acptAnOdrAdjustCnt; }
            set { _acptAnOdrAdjustCnt = value; }
        }

        /// public propaty name  :  AcptAnOdrRemainCnt
        /// <summary>受注残数プロパティ</summary>
        /// <value>受注数量＋受注調整数－出荷数</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   受注残数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double AcptAnOdrRemainCnt
        {
            get { return _acptAnOdrRemainCnt; }
            set { _acptAnOdrRemainCnt = value; }
        }

        /// public propaty name  :  RemainCntUpdDate
        /// <summary>残数更新日プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   残数更新日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime RemainCntUpdDate
        {
            get { return _remainCntUpdDate; }
            set { _remainCntUpdDate = value; }
        }

        /// public propaty name  :  RemainCntUpdDateJpFormal
        /// <summary>残数更新日 和暦プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   残数更新日 和暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string RemainCntUpdDateJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _remainCntUpdDate); }
            set { }
        }

        /// public propaty name  :  RemainCntUpdDateJpInFormal
        /// <summary>残数更新日 和暦(略)プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   残数更新日 和暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string RemainCntUpdDateJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _remainCntUpdDate); }
            set { }
        }

        /// public propaty name  :  RemainCntUpdDateAdFormal
        /// <summary>残数更新日 西暦プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   残数更新日 西暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string RemainCntUpdDateAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _remainCntUpdDate); }
            set { }
        }

        /// public propaty name  :  RemainCntUpdDateAdInFormal
        /// <summary>残数更新日 西暦(略)プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   残数更新日 西暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string RemainCntUpdDateAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _remainCntUpdDate); }
            set { }
        }

        /// public propaty name  :  SalesMoneyTaxInc
        /// <summary>売上金額（税込み）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上金額（税込み）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesMoneyTaxInc
        {
            get { return _salesMoneyTaxInc; }
            set { _salesMoneyTaxInc = value; }
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

        /// public propaty name  :  GrsProfitChkDiv
        /// <summary>粗利チェック区分プロパティ</summary>
        /// <value>0:正常,1:原価割れ,2:利益の上げ過ぎ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   粗利チェック区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GrsProfitChkDiv
        {
            get { return _grsProfitChkDiv; }
            set { _grsProfitChkDiv = value; }
        }

        /// public propaty name  :  SalesGoodsCd
        /// <summary>売上商品区分プロパティ</summary>
        /// <value>0:商品,1:商品外,2:消費税調整,3:残高調整,4:売掛用消費税調整,5:売掛用残高調整,10:売掛用消費税調整(自動),11:相殺,12:相殺(自動)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上商品区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SalesGoodsCd
        {
            get { return _salesGoodsCd; }
            set { _salesGoodsCd = value; }
        }

        /// public propaty name  :  SalesPriceConsTax
        /// <summary>売上金額消費税額プロパティ</summary>
        /// <value>売上金額（税込み）- 売上金額（税抜き）※消費税調整額も兼ねる</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上金額消費税額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesPriceConsTax
        {
            get { return _salesPriceConsTax; }
            set { _salesPriceConsTax = value; }
        }

        /// public propaty name  :  TaxationDivCd
        /// <summary>課税区分プロパティ</summary>
        /// <value>0:課税,1:非課税,2:課税（内税）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   課税区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 TaxationDivCd
        {
            get { return _taxationDivCd; }
            set { _taxationDivCd = value; }
        }

        /// public propaty name  :  PartySlipNumDtl
        /// <summary>相手先伝票番号（明細）プロパティ</summary>
        /// <value>得意先注文番号（仮伝No）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   相手先伝票番号（明細）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PartySlipNumDtl
        {
            get { return _partySlipNumDtl; }
            set { _partySlipNumDtl = value; }
        }

        /// public propaty name  :  DtlNote
        /// <summary>明細備考プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   明細備考プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DtlNote
        {
            get { return _dtlNote; }
            set { _dtlNote = value; }
        }

        /// public propaty name  :  SupplierCd
        /// <summary>仕入先コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SupplierCd
        {
            get { return _supplierCd; }
            set { _supplierCd = value; }
        }

        /// public propaty name  :  SupplierSnm
        /// <summary>仕入先略称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先略称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SupplierSnm
        {
            get { return _supplierSnm; }
            set { _supplierSnm = value; }
        }

        /// public propaty name  :  OrderNumber
        /// <summary>発注番号プロパティ</summary>
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

        /// public propaty name  :  WayToOrder
        /// <summary>注文方法プロパティ</summary>
        /// <value>0:発注書発注,1:FAX送信,2:オンライン発注,4:発注済事後登録</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   注文方法プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 WayToOrder
        {
            get { return _wayToOrder; }
            set { _wayToOrder = value; }
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

        /// public propaty name  :  BfListPrice
        /// <summary>変更前定価プロパティ</summary>
        /// <value>税抜き、掛率算出結果</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   変更前定価プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double BfListPrice
        {
            get { return _bfListPrice; }
            set { _bfListPrice = value; }
        }

        /// public propaty name  :  BfSalesUnitPrice
        /// <summary>変更前売価プロパティ</summary>
        /// <value>税抜き、掛率算出結果</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   変更前売価プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double BfSalesUnitPrice
        {
            get { return _bfSalesUnitPrice; }
            set { _bfSalesUnitPrice = value; }
        }

        /// public propaty name  :  BfUnitCost
        /// <summary>変更前原価プロパティ</summary>
        /// <value>税抜き、掛率算出結果</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   変更前原価プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double BfUnitCost
        {
            get { return _bfUnitCost; }
            set { _bfUnitCost = value; }
        }

        /// public propaty name  :  CmpltSalesRowNo
        /// <summary>一式明細番号プロパティ</summary>
        /// <value>0:一式なし　1～一式連番</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   一式明細番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CmpltSalesRowNo
        {
            get { return _cmpltSalesRowNo; }
            set { _cmpltSalesRowNo = value; }
        }

        /// public propaty name  :  CmpltGoodsMakerCd
        /// <summary>メーカーコード（一式）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メーカーコード（一式）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CmpltGoodsMakerCd
        {
            get { return _cmpltGoodsMakerCd; }
            set { _cmpltGoodsMakerCd = value; }
        }

        /// public propaty name  :  CmpltMakerName
        /// <summary>メーカー名称（一式）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メーカー名称（一式）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CmpltMakerName
        {
            get { return _cmpltMakerName; }
            set { _cmpltMakerName = value; }
        }

        /// public propaty name  :  CmpltMakerKanaName
        /// <summary>メーカーカナ名称（一式）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メーカーカナ名称（一式）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CmpltMakerKanaName
        {
            get { return _cmpltMakerKanaName; }
            set { _cmpltMakerKanaName = value; }
        }

        /// public propaty name  :  CmpltGoodsName
        /// <summary>商品名称（一式）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品名称（一式）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CmpltGoodsName
        {
            get { return _cmpltGoodsName; }
            set { _cmpltGoodsName = value; }
        }

        /// public propaty name  :  CmpltShipmentCnt
        /// <summary>数量（一式）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   数量（一式）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double CmpltShipmentCnt
        {
            get { return _cmpltShipmentCnt; }
            set { _cmpltShipmentCnt = value; }
        }

        /// public propaty name  :  CmpltSalesUnPrcFl
        /// <summary>売上単価（一式）プロパティ</summary>
        /// <value>売上金額（一式の合計）/ 数量  ※少数第３位四捨五入</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上単価（一式）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double CmpltSalesUnPrcFl
        {
            get { return _cmpltSalesUnPrcFl; }
            set { _cmpltSalesUnPrcFl = value; }
        }

        /// public propaty name  :  CmpltSalesMoney
        /// <summary>売上金額（一式）プロパティ</summary>
        /// <value>売上金額（税抜き）の同一一式明細の合計</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上金額（一式）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 CmpltSalesMoney
        {
            get { return _cmpltSalesMoney; }
            set { _cmpltSalesMoney = value; }
        }

        /// public propaty name  :  CmpltSalesUnitCost
        /// <summary>原価単価（一式）プロパティ</summary>
        /// <value>原価金額（一式の合計）/ 数量  ※少数第３位四捨五入</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   原価単価（一式）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double CmpltSalesUnitCost
        {
            get { return _cmpltSalesUnitCost; }
            set { _cmpltSalesUnitCost = value; }
        }

        /// public propaty name  :  CmpltCost
        /// <summary>原価金額（一式）プロパティ</summary>
        /// <value>原価の同一一式明細の合計</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   原価金額（一式）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 CmpltCost
        {
            get { return _cmpltCost; }
            set { _cmpltCost = value; }
        }

        /// public propaty name  :  CmpltPartySalSlNum
        /// <summary>相手先伝票番号（一式）プロパティ</summary>
        /// <value>得意先注文番号</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   相手先伝票番号（一式）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CmpltPartySalSlNum
        {
            get { return _cmpltPartySalSlNum; }
            set { _cmpltPartySalSlNum = value; }
        }

        /// public propaty name  :  CmpltNote
        /// <summary>一式備考プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   一式備考プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CmpltNote
        {
            get { return _cmpltNote; }
            set { _cmpltNote = value; }
        }

        // --- ADD 2009/10/19 ---------->>>>>
        /// public propaty name  :  SelectedGoodsNoDiv
        /// <summary>印刷用品番有効区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   印刷用品番有効区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SelectedGoodsNoDiv
        {
            get { return _selectedGoodsNoDiv; }
            set { _selectedGoodsNoDiv = value; }
        }
        // --- ADD 2009/10/19 ----------<<<<<

        /// public propaty name  :  PrtGoodsNo
        /// <summary>印刷用品番プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   印刷用品番プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PrtGoodsNo
        {
            get { return _prtGoodsNo; }
            set { _prtGoodsNo = value; }
        }

        /// public propaty name  :  PrtMakerCode
        /// <summary>印刷用メーカーコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   印刷用メーカーコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PrtMakerCode
        {
            get { return _prtMakerCode; }
            set { _prtMakerCode = value; }
        }

        /// public propaty name  :  PrtMakerName
        /// <summary>印刷用メーカー名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   印刷用メーカー名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PrtMakerName
        {
            get { return _prtMakerName; }
            set { _prtMakerName = value; }
        }

        /// public propaty name  :  DtlRelationGuid
        /// <summary>共通キープロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   共通キープロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Guid DtlRelationGuid
        {
            get { return _dtlRelationGuid; }
            set { _dtlRelationGuid = value; }
        }

        /// public propaty name  :  CarRelationGuid
        /// <summary>車両情報共通キープロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車両情報共通キープロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Guid CarRelationGuid
        {
            get { return _carRelationGuid; }
            set { _carRelationGuid = value; }
        }

        /// public propaty name  :  ShipmentCntDefault
        /// <summary>出荷数初期値プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   出荷数初期値プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double ShipmentCntDefault
        {
            get { return _shipmentCntDefault; }
            set { _shipmentCntDefault = value; }
        }

        /// public propaty name  :  ShipmentCntDefForChk
        /// <summary>出荷数初期値（変更チェック用）プロパティ</summary>
        /// <value>新規:検索結果(出荷数),修正:出荷数</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   出荷数初期値（変更チェック用）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double ShipmentCntDefForChk
        {
            get { return _shipmentCntDefForChk; }
            set { _shipmentCntDefForChk = value; }
        }

        /// public propaty name  :  AcceptAnOrderCntDefault
        /// <summary>受注数初期値プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   受注数初期値プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double AcceptAnOrderCntDefault
        {
            get { return _acceptAnOrderCntDefault; }
            set { _acceptAnOrderCntDefault = value; }
        }

        /// public propaty name  :  AcceptAnOrderCntDefForChk
        /// <summary>受注数初期値（変更チェック用）プロパティ</summary>
        /// <value>新規:検索結果(出荷数),修正:出荷数(受注データ)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   受注数初期値（変更チェック用）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double AcceptAnOrderCntDefForChk
        {
            get { return _acceptAnOrderCntDefForChk; }
            set { _acceptAnOrderCntDefForChk = value; }
        }

        /// public propaty name  :  SalesUnPrcTaxIncFlDefault
        /// <summary>売上単価（税込，浮動）初期値プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上単価（税込，浮動）初期値プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double SalesUnPrcTaxIncFlDefault
        {
            get { return _salesUnPrcTaxIncFlDefault; }
            set { _salesUnPrcTaxIncFlDefault = value; }
        }

        /// public propaty name  :  SalesUnPrcTaxExcFlDefault
        /// <summary>売上単価（税抜，浮動）初期値プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上単価（税抜，浮動）初期値プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double SalesUnPrcTaxExcFlDefault
        {
            get { return _salesUnPrcTaxExcFlDefault; }
            set { _salesUnPrcTaxExcFlDefault = value; }
        }

        /// public propaty name  :  SalesUnitCostTaxIncDefault
        /// <summary>原価単価（税込）初期値プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   原価単価（税込）初期値プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double SalesUnitCostTaxIncDefault
        {
            get { return _salesUnitCostTaxIncDefault; }
            set { _salesUnitCostTaxIncDefault = value; }
        }

        /// public propaty name  :  SalesUnitCostTacExcDefault
        /// <summary>原価単価（税抜）初期値プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   原価単価（税抜）初期値プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double SalesUnitCostTacExcDefault
        {
            get { return _salesUnitCostTacExcDefault; }
            set { _salesUnitCostTacExcDefault = value; }
        }

        //>>>2010/02/26
        /// public propaty name  :  CampaignCode
        /// <summary>キャンペーンコードプロパティ</summary>
        /// <value>拠点と連結でキーとなるので注意（管理拠点コード）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   キャンペーンコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CampaignCode
        {
            get { return _campaignCode; }
            set { _campaignCode = value; }
        }

        /// public propaty name  :  CampaignName
        /// <summary>キャンペーン名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   キャンペーン名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CampaignName
        {
            get { return _campaignName; }
            set { _campaignName = value; }
        }

        /// public propaty name  :  GoodsDivCd
        /// <summary>商品種別プロパティ</summary>
        /// <value>0:純正部品 1:優良部品 2:リビルド 3:中古 4:平均相場</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品種別プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsDivCd
        {
            get { return _goodsDivCd; }
            set { _goodsDivCd = value; }
        }

        /// public propaty name  :  AnswerDelivDate
        /// <summary>回答納期プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   回答納期プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AnswerDelivDate
        {
            get { return _answerDelivDate; }
            set { _answerDelivDate = value; }
        }

        /// public propaty name  :  RecycleDiv
        /// <summary>リサイクル区分プロパティ</summary>
        /// <value>RCのマスタ項目</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   リサイクル区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 RecycleDiv
        {
            get { return _recycleDiv; }
            set { _recycleDiv = value; }
        }

        /// public propaty name  :  RecycleDivNm
        /// <summary>リサイクル区分名称プロパティ</summary>
        /// <value>RCのマスタ名称</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   リサイクル区分名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string RecycleDivNm
        {
            get { return _recycleDivNm; }
            set { _recycleDivNm = value; }
        }

        /// public propaty name  :  WayToAcptOdr
        /// <summary>受注方法プロパティ</summary>
        /// <value>0:通常,1:オンライン（SCM）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   受注方法プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 WayToAcptOdr
        {
            get { return _wayToAcptOdr; }
            set { _wayToAcptOdr = value; }
        }

        /// public propaty name  :  GoodsMngNo
        /// <summary>商品管理番号プロパティ</summary>
        /// <value>PS管理番号</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品管理番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsMngNo
        {
            get { return _goodsMngNo; }
            set { _goodsMngNo = value; }
        }

        /// public propaty name  :  InqRowNumber
        /// <summary>問合せ行番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   問合せ行番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 InqRowNumber
        {
            get { return _inqRowNumber; }
            set { _inqRowNumber = value; }
        }

        /// public propaty name  :  InqRowNumDerivedNo
        /// <summary>問合せ行番号枝番プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   問合せ行番号枝番プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 InqRowNumDerivedNo
        {
            get { return _inqRowNumDerivedNo; }
            set { _inqRowNumDerivedNo = value; }
        }
        //<<<2010/02/26

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

        /// public propaty name  :  BLGoodsName
        /// <summary>BL商品コード名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL商品コード名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string BLGoodsName
        {
            get { return _bLGoodsName; }
            set { _bLGoodsName = value; }
        }

        // --- ADD 2010/04/06 ---------->>>>>
        /// public propaty name  :  EditStatus
        /// <summary>行状態プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   行状態プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public int EditStatus
        {
            get { return _editStatus; }
            set { _editStatus = value; }
        }

        /// public propaty name  :  RowStatus
        /// <summary>行状態プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   行状態プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public int RowStatus
        {
            get { return _rowStatus; }
            set { _rowStatus = value; }
        }

        /// public propaty name  :  SalesMoneyInputDiv
        /// <summary>金額手入力区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   金額手入力区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public int SalesMoneyInputDiv
        {
            get { return _salesMoneyInputDiv; }
            set { _salesMoneyInputDiv = value; }
        }

        /// public propaty name  :  ShipmentCntDisplay
        /// <summary>出荷数(表示用)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   出荷数(表示用)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public double ShipmentCntDisplay
        {
            get { return _shipmentCntDisplay; }
            set { _shipmentCntDisplay = value; }
        }

        /// public propaty name  :  SupplierStockDisplay
        /// <summary>現在庫数(表示用)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   現在庫数(表示用)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public double SupplierStockDisplay
        {
            get { return _supplierStockDisplay; }
            set { _supplierStockDisplay = value; }
        }

        /// public propaty name  :  ListPriceDisplay
        /// <summary>標準価格(表示用)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   標準価格(表示用)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public double ListPriceDisplay
        {
            get { return _listPriceDisplay; }
            set { _listPriceDisplay = value; }
        }

        /// public propaty name  :  StockDate
        /// <summary>仕入日プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime StockDate
        {
            get { return _stockDate; }
            set { _stockDate = value; }
        }

        /// public propaty name  :  BoCode
        /// <summary>BOプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BOプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string BoCode
        {
            get { return _boCode; }
            set { _boCode = value; }
        }

        /// public propaty name  :  SupplierCdForOrder
        /// <summary>発注先プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   発注先プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public int SupplierCdForOrder
        {
            get { return _supplierCdForOrder; }
            set { _supplierCdForOrder = value; }
        }

        /// public propaty name  :  SupplierSnmForOrder
        /// <summary>発注先名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   発注先名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SupplierSnmForOrder
        {
            get { return _supplierSnmForOrder; }
            set { _supplierSnmForOrder = value; }
        }

        /// public propaty name  :  DeliveredGoodsDivNm
        /// <summary>納品区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   納品区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DeliveredGoodsDivNm
        {
            get { return _deliveredGoodsDivNm; }
            set { _deliveredGoodsDivNm = value; }
        }

        /// public propaty name  :  FollowDeliGoodsDivNm
        /// <summary>Ｈ納品区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   Ｈ納品区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string FollowDeliGoodsDivNm
        {
            get { return _followDeliGoodsDivNm; }
            set { _followDeliGoodsDivNm = value; }
        }

        /// public propaty name  :  UOEResvdSectionNm
        /// <summary>指定拠点プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   指定拠点プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UOEResvdSectionNm
        {
            get { return _uOEResvdSectionNm; }
            set { _uOEResvdSectionNm = value; }
        }

        /// public propaty name  :  UOEDeliGoodsDiv
        /// <summary>納品区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   納品区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UOEDeliGoodsDiv
        {
            get { return _uOEDeliGoodsDiv; }
            set { _uOEDeliGoodsDiv = value; }
        }

        /// public propaty name  :  FollowDeliGoodsDivNm
        /// <summary>Ｈ納品区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   Ｈ納品区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string FollowDeliGoodsDiv
        {
            get { return _followDeliGoodsDiv; }
            set { _followDeliGoodsDiv = value; }
        }

        /// public propaty name  :  UOEResvdSectionNm
        /// <summary>指定拠点プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   指定拠点プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UOEResvdSection
        {
            get { return _uOEResvdSection; }
            set { _uOEResvdSection = value; }
        }

        /// public propaty name  :  PartySalesSlipNum
        /// <summary>仕入伝票番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入伝票番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PartySalesSlipNum
        {
            get { return _partySalesSlipNum; }
            set { _partySalesSlipNum = value; }
        }

        /// public propaty name  :  SearchPartsModeState
        /// <summary>部品検索状態プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   部品検索状態プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public int SearchPartsModeState
        {
            get { return _searchPartsModeState; }
            set { _searchPartsModeState = value; }
        }

        // --- ADD 2009/04/06 ----------<<<<<

        // --- ADD 2011/08/08 ---------->>>>>
        /// public propaty name  :  AcceptOrOrderKind
        /// <summary>受発注種別プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   受発注種別プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int16 AcceptOrOrderKind
        {
            get { return _acceptOrOrderKind; }
            set { _acceptOrOrderKind = value; }
        }

        /// public propaty name  :  InquiryNumber
        /// <summary>問合せ番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   問合せ番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 InquiryNumber
        {
            get { return _inquiryNumber; }
            set { _inquiryNumber = value; }
        }

        // --- ADD 2011/08/08 ----------<<<<<

        // 2012/01/16 Add >>>
        /// public propaty name  :  GoodsSpecialNote
        /// <summary>特記事項</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   特記事項プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsSpecialNote
        {
            get { return _goodsSpecialNote; }
            set { _goodsSpecialNote = value; }
        }
        // 2012/01/16 Add <<<

        //>>>2012/05/02
        /// <summary>
        /// 貸出同時仕入先
        /// </summary>
        public Int32 RentSyncSupplier
        {
            get { return _rentSyncSupplier; }
            set { _rentSyncSupplier = value; }
        }
        /// <summary>
        /// 貸出同時仕入日
        /// </summary>
        public DateTime RentSyncStockDate
        {
            get { return _rentSyncStockDate; }
            set { _rentSyncStockDate = value; }
        }
        /// <summary>
        /// 貸出同時仕入伝票番号
        /// </summary>
        public string RentSyncSupSlipNo
        {
            get { return _rentSyncSupSlipNo; }
            set { _rentSyncSupSlipNo = value; }
        }
        //<<<2012/05/02

        // ----ADD 2013/01/24 鄧潘ハン REDMINE#34605---- >>>>>
        /// public propaty name  :  PriceSelectDiv
        /// <summary>標準価格選択区分プロパティ</summary>
        /// <value>0:優良,1:純正,2:高い方(1:N),,3:高い方(1:1)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   標準価格選択区分プロパティ</br>
        /// <br>Programer        :   鄧潘ハン</br>
        /// </remarks>
        public Int32 PriceSelectDiv
        {
            get { return _priceSelectDiv; }
            set { _priceSelectDiv = value; }
        }
        // ----ADD 2013/01/24 鄧潘ハン REDMINE#34605---- <<<<<

        /// <summary>
        /// 売上明細データコンストラクタ
        /// </summary>
        /// <returns>SalesDetailクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SalesDetailクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SalesDetail()
        {
        }

        /// <summary>
        /// 売上明細データコンストラクタ
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
        /// <param name="acptAnOdrStatus">受注ステータス(10:見積,20:受注,30:売上,40:出荷,70:指示書,80:クレーム,99:一時保管  )</param>
        /// <param name="salesSlipNum">売上伝票番号(見積伝票番号,受注伝票番号,出荷伝票番号,売上伝票番号を兼ねる。)</param>
        /// <param name="salesRowNo">売上行番号</param>
        /// <param name="salesRowDerivNo">売上行番号枝番(検索見積の対比で使用する)</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="subSectionCode">部門コード</param>
        /// <param name="salesDate">売上日付(YYYYMMDD)</param>
        /// <param name="commonSeqNo">共通通番</param>
        /// <param name="salesSlipDtlNum">売上明細通番</param>
        /// <param name="acptAnOdrStatusSrc">受注ステータス（元）(10:見積,20:受注,30:売上,40:出荷)</param>
        /// <param name="salesSlipDtlNumSrc">売上明細通番（元）(計上時の元データ明細通番をセット)</param>
        /// <param name="supplierFormalSync">仕入形式（同時）(0:仕入,1:入荷)</param>
        /// <param name="stockSlipDtlNumSync">仕入明細通番（同時）(同時計上時の仕入明細通番をセット)</param>
        /// <param name="salesSlipCdDtl">売上伝票区分（明細）(0:売上,1:返品,2:値引,3:注釈,4:小計,5:作業)</param>
        /// <param name="deliGdsCmpltDueDate">納品完了予定日(客先納期(YYYYMMDD))</param>
        /// <param name="goodsKindCode">商品属性(0:純正 1:優良)</param>
        /// <param name="goodsSearchDivCd">商品検索区分(0:BL検索 1:品番 2:手入力)</param>
        /// <param name="goodsMakerCd">商品メーカーコード(ﾊﾟｯｹｰｼﾞ毎にﾕｰｻﾞｰ登録範囲が異なる)</param>
        /// <param name="makerName">メーカー名称</param>
        /// <param name="makerKanaName">メーカーカナ名称</param>
        /// <param name="goodsNo">商品番号</param>
        /// <param name="goodsName">商品名称</param>
        /// <param name="goodsNameKana">商品名称カナ</param>
        /// <param name="goodsLGroup">商品大分類コード(旧大分類（ユーザーガイド）)</param>
        /// <param name="goodsLGroupName">商品大分類名称</param>
        /// <param name="goodsMGroup">商品中分類コード(旧中分類コード)</param>
        /// <param name="goodsMGroupName">商品中分類名称</param>
        /// <param name="bLGroupCode">BLグループコード(旧グループコード)</param>
        /// <param name="bLGroupName">BLグループコード名称</param>
        /// <param name="bLGoodsCode">BL商品コード</param>
        /// <param name="bLGoodsFullName">BL商品コード名称（全角）</param>
        /// <param name="enterpriseGanreCode">自社分類コード</param>
        /// <param name="enterpriseGanreName">自社分類名称</param>
        /// <param name="warehouseCode">倉庫コード</param>
        /// <param name="warehouseName">倉庫名称</param>
        /// <param name="warehouseShelfNo">倉庫棚番</param>
        /// <param name="salesOrderDivCd">売上在庫取寄せ区分(0:取寄せ，1:在庫)</param>
        /// <param name="openPriceDiv">オープン価格区分(0:通常／1:オープン価格)</param>
        /// <param name="goodsRateRank">商品掛率ランク(商品の掛率用ランク)</param>
        /// <param name="custRateGrpCode">得意先掛率グループコード</param>
        /// <param name="listPriceRate">定価率</param>
        /// <param name="rateSectPriceUnPrc">掛率設定拠点（定価）(0:全社設定, その他:拠点コード)</param>
        /// <param name="rateDivLPrice">掛率設定区分（定価）(A1,A2,…)</param>
        /// <param name="unPrcCalcCdLPrice">単価算出区分（定価）(1:掛率,2:原価ＵＰ率,3:粗利率)</param>
        /// <param name="priceCdLPrice">価格区分（定価）(0:定価,1:登録販売店価格,… 9:ユーザー定価)</param>
        /// <param name="stdUnPrcLPrice">基準単価（定価）</param>
        /// <param name="fracProcUnitLPrice">端数処理単位（定価）</param>
        /// <param name="fracProcLPrice">端数処理（定価）(1：切捨て,2：四捨五入,3:切上げ)</param>
        /// <param name="listPriceTaxIncFl">定価（税込，浮動）(税抜き)</param>
        /// <param name="listPriceTaxExcFl">定価（税抜，浮動）(税込み)</param>
        /// <param name="listPriceChngCd">定価変更区分(0:変更なし,1:変更あり　（定価手入力）)</param>
        /// <param name="salesRate">売価率</param>
        /// <param name="rateSectSalUnPrc">掛率設定拠点（売上単価）(0:全社設定, その他:拠点コード)</param>
        /// <param name="rateDivSalUnPrc">掛率設定区分（売上単価）(A1,A2,…)</param>
        /// <param name="unPrcCalcCdSalUnPrc">単価算出区分（売上単価）(1:掛率,2:原価ＵＰ率,3:粗利率)</param>
        /// <param name="priceCdSalUnPrc">価格区分（売上単価）(0:定価,1:登録販売店価格,…)</param>
        /// <param name="stdUnPrcSalUnPrc">基準単価（売上単価）</param>
        /// <param name="fracProcUnitSalUnPrc">端数処理単位（売上単価）</param>
        /// <param name="fracProcSalUnPrc">端数処理（売上単価）(1：切捨て,2：四捨五入,3:切上げ)</param>
        /// <param name="salesUnPrcTaxIncFl">売上単価（税込，浮動）</param>
        /// <param name="salesUnPrcTaxExcFl">売上単価（税抜，浮動）</param>
        /// <param name="salesUnPrcChngCd">売上単価変更区分(0:変更なし,1:変更あり　（売上単価手入力）)</param>
        /// <param name="costRate">原価率</param>
        /// <param name="rateSectCstUnPrc">掛率設定拠点（原価単価）(0:全社設定, その他:拠点コード)</param>
        /// <param name="rateDivUnCst">掛率設定区分（原価単価）(A7,A8,…)</param>
        /// <param name="unPrcCalcCdUnCst">単価算出区分（原価単価）(1:掛率,2:原価ＵＰ率,3:粗利率)</param>
        /// <param name="priceCdUnCst">価格区分（原価単価）(0:定価,1:登録販売店価格,…)</param>
        /// <param name="stdUnPrcUnCst">基準単価（原価単価）</param>
        /// <param name="fracProcUnitUnCst">端数処理単位（原価単価）</param>
        /// <param name="fracProcUnCst">端数処理（原価単価）(1：切捨て,2：四捨五入,3:切上げ)</param>
        /// <param name="salesUnitCost">原価単価</param>
        /// <param name="salesUnitCostChngDiv">原価単価変更区分(0:変更なし,1:変更あり　（原価単価手入力）)</param>
        /// <param name="rateBLGoodsCode">BL商品コード（掛率）(掛率算出時に使用したBLコード（商品検索結果）)</param>
        /// <param name="rateBLGoodsName">BL商品コード名称（掛率）(掛率算出時に使用したBLコード名称（商品検索結果）)</param>
        /// <param name="rateGoodsRateGrpCd">商品掛率グループコード（掛率）(掛率算出時に使用した商品掛率コード（商品検索結果）)</param>
        /// <param name="rateGoodsRateGrpNm">商品掛率グループ名称（掛率）(掛率算出時に使用した商品掛率名称（商品検索結果）)</param>
        /// <param name="rateBLGroupCode">BLグループコード（掛率）(掛率算出時に使用したBLグループコード（商品検索結果）)</param>
        /// <param name="rateBLGroupName">BLグループ名称（掛率）(掛率算出時に使用したBLグループ名称（商品検索結果）)</param>
        /// <param name="prtBLGoodsCode">BL商品コード（印刷）(掛率算出時に使用したBLコード（商品検索結果）)</param>
        /// <param name="prtBLGoodsName">BL商品コード名称（印刷）(掛率算出時に使用したBLコード名称（商品検索結果）)</param>
        /// <param name="salesCode">販売区分コード</param>
        /// <param name="salesCdNm">販売区分名称</param>
        /// <param name="workManHour">作業工数</param>
        /// <param name="shipmentCnt">出荷数</param>
        /// <param name="acceptAnOrderCnt">受注数量(受注,出荷で使用)</param>
        /// <param name="acptAnOdrAdjustCnt">受注調整数(現在の受注数は「受注数量＋受注調整数」で算出)</param>
        /// <param name="acptAnOdrRemainCnt">受注残数(受注数量＋受注調整数－出荷数)</param>
        /// <param name="remainCntUpdDate">残数更新日(YYYYMMDD)</param>
        /// <param name="salesMoneyTaxInc">売上金額（税込み）</param>
        /// <param name="salesMoneyTaxExc">売上金額（税抜き）</param>
        /// <param name="cost">原価</param>
        /// <param name="grsProfitChkDiv">粗利チェック区分(0:正常,1:原価割れ,2:利益の上げ過ぎ)</param>
        /// <param name="salesGoodsCd">売上商品区分(0:商品,1:商品外,2:消費税調整,3:残高調整,4:売掛用消費税調整,5:売掛用残高調整,10:売掛用消費税調整(自動),11:相殺,12:相殺(自動))</param>
        /// <param name="salesPriceConsTax">売上金額消費税額(売上金額（税込み）- 売上金額（税抜き）※消費税調整額も兼ねる)</param>
        /// <param name="taxationDivCd">課税区分(0:課税,1:非課税,2:課税（内税）)</param>
        /// <param name="partySlipNumDtl">相手先伝票番号（明細）(得意先注文番号（仮伝No）)</param>
        /// <param name="dtlNote">明細備考</param>
        /// <param name="supplierCd">仕入先コード</param>
        /// <param name="supplierSnm">仕入先略称</param>
        /// <param name="orderNumber">発注番号</param>
        /// <param name="wayToOrder">注文方法(0:発注書発注,1:FAX送信,2:オンライン発注,4:発注済事後登録)</param>
        /// <param name="slipMemo1">伝票メモ１</param>
        /// <param name="slipMemo2">伝票メモ２</param>
        /// <param name="slipMemo3">伝票メモ３</param>
        /// <param name="insideMemo1">社内メモ１</param>
        /// <param name="insideMemo2">社内メモ２</param>
        /// <param name="insideMemo3">社内メモ３</param>
        /// <param name="bfListPrice">変更前定価(税抜き、掛率算出結果)</param>
        /// <param name="bfSalesUnitPrice">変更前売価(税抜き、掛率算出結果)</param>
        /// <param name="bfUnitCost">変更前原価(税抜き、掛率算出結果)</param>
        /// <param name="cmpltSalesRowNo">一式明細番号(0:一式なし　1～一式連番)</param>
        /// <param name="cmpltGoodsMakerCd">メーカーコード（一式）</param>
        /// <param name="cmpltMakerName">メーカー名称（一式）</param>
        /// <param name="cmpltMakerKanaName">メーカーカナ名称（一式）</param>
        /// <param name="cmpltGoodsName">商品名称（一式）</param>
        /// <param name="cmpltShipmentCnt">数量（一式）</param>
        /// <param name="cmpltSalesUnPrcFl">売上単価（一式）(売上金額（一式の合計）/ 数量  ※少数第３位四捨五入)</param>
        /// <param name="cmpltSalesMoney">売上金額（一式）(売上金額（税抜き）の同一一式明細の合計)</param>
        /// <param name="cmpltSalesUnitCost">原価単価（一式）(原価金額（一式の合計）/ 数量  ※少数第３位四捨五入)</param>
        /// <param name="cmpltCost">原価金額（一式）(原価の同一一式明細の合計)</param>
        /// <param name="cmpltPartySalSlNum">相手先伝票番号（一式）(得意先注文番号)</param>
        /// <param name="cmpltNote">一式備考</param>
        /// <param name="selectedGoodsNoDiv">印刷用品番有効区分</param>
        /// <param name="prtGoodsNo">印刷用品番</param>
        /// <param name="prtMakerCode">印刷用メーカーコード</param>
        /// <param name="prtMakerName">印刷用メーカー名称</param>
        /// <param name="dtlRelationGuid">共通キー</param>
        /// <param name="carRelationGuid">車両情報共通キー</param>
        /// <param name="shipmentCntDefault">出荷数初期値</param>
        /// <param name="shipmentCntDefForChk">出荷数初期値（変更チェック用）(新規:検索結果(出荷数),修正:出荷数)</param>
        /// <param name="acceptAnOrderCntDefault">受注数初期値</param>
        /// <param name="acceptAnOrderCntDefForChk">受注数初期値（変更チェック用）(新規:検索結果(出荷数),修正:出荷数(受注データ))</param>
        /// <param name="salesUnPrcTaxIncFlDefault">売上単価（税込，浮動）初期値</param>
        /// <param name="salesUnPrcTaxExcFlDefault">売上単価（税抜，浮動）初期値</param>
        /// <param name="salesUnitCostTaxIncDefault">原価単価（税込）初期値</param>
        /// <param name="salesUnitCostTacExcDefault">原価単価（税抜）初期値</param>
        /// <param name="enterpriseName">企業名称</param>
        /// <param name="updEmployeeName">更新従業員名称</param>
        /// <param name="bLGoodsName">BL商品コード名称</param>
        /// <param name="editStatus">行状態</param> //ADD 2010/04/06
        /// <param name="rowStatus">行状態</param> //ADD 2010/04/06
        /// <param name="salesMoneyInputDiv">金額手入力区分</param> //ADD 2010/04/06
        /// <param name="shipmentCntDisplay">出荷数(表示用)</param> //ADD 2010/04/06
        /// <param name="supplierStockDisplay">現在庫数(表示用)</param> //ADD 2010/04/06
        /// <param name="listPriceDisplay">標準価格(表示用)</param> //ADD 2010/04/06
        /// <param name="stockDate">仕入日</param> //ADD 2010/04/06
        /// <param name="boCode">BO</param> //ADD 2010/04/06
        /// <param name="supplierCdForOrder">発注先</param> //ADD 2010/04/06
        /// <param name="supplierSnmForOrder">発注先名称</param> //ADD 2010/04/06
        /// <returns>SalesDetailクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SalesDetailクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        //>>>2010/02/26
        //public SalesDetail(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 acceptAnOrderNo, Int32 acptAnOdrStatus, string salesSlipNum, Int32 salesRowNo, Int32 salesRowDerivNo, string sectionCode, Int32 subSectionCode, DateTime salesDate, Int64 commonSeqNo, Int64 salesSlipDtlNum, Int32 acptAnOdrStatusSrc, Int64 salesSlipDtlNumSrc, Int32 supplierFormalSync, Int64 stockSlipDtlNumSync, Int32 salesSlipCdDtl, DateTime deliGdsCmpltDueDate, Int32 goodsKindCode, Int32 goodsSearchDivCd, Int32 goodsMakerCd, string makerName, string makerKanaName, string goodsNo, string goodsName, string goodsNameKana, Int32 goodsLGroup, string goodsLGroupName, Int32 goodsMGroup, string goodsMGroupName, Int32 bLGroupCode, string bLGroupName, Int32 bLGoodsCode, string bLGoodsFullName, Int32 enterpriseGanreCode, string enterpriseGanreName, string warehouseCode, string warehouseName, string warehouseShelfNo, Int32 salesOrderDivCd, Int32 openPriceDiv, string goodsRateRank, Int32 custRateGrpCode, Double listPriceRate, string rateSectPriceUnPrc, string rateDivLPrice, Int32 unPrcCalcCdLPrice, Int32 priceCdLPrice, Double stdUnPrcLPrice, Double fracProcUnitLPrice, Int32 fracProcLPrice, Double listPriceTaxIncFl, Double listPriceTaxExcFl, Int32 listPriceChngCd, Double salesRate, string rateSectSalUnPrc, string rateDivSalUnPrc, Int32 unPrcCalcCdSalUnPrc, Int32 priceCdSalUnPrc, Double stdUnPrcSalUnPrc, Double fracProcUnitSalUnPrc, Int32 fracProcSalUnPrc, Double salesUnPrcTaxIncFl, Double salesUnPrcTaxExcFl, Int32 salesUnPrcChngCd, Double costRate, string rateSectCstUnPrc, string rateDivUnCst, Int32 unPrcCalcCdUnCst, Int32 priceCdUnCst, Double stdUnPrcUnCst, Double fracProcUnitUnCst, Int32 fracProcUnCst, Double salesUnitCost, Int32 salesUnitCostChngDiv, Int32 rateBLGoodsCode, string rateBLGoodsName, Int32 rateGoodsRateGrpCd, string rateGoodsRateGrpNm, Int32 rateBLGroupCode, string rateBLGroupName, Int32 prtBLGoodsCode, string prtBLGoodsName, Int32 salesCode, string salesCdNm, Double workManHour, Double shipmentCnt, Double acceptAnOrderCnt, Double acptAnOdrAdjustCnt, Double acptAnOdrRemainCnt, DateTime remainCntUpdDate, Int64 salesMoneyTaxInc, Int64 salesMoneyTaxExc, Int64 cost, Int32 grsProfitChkDiv, Int32 salesGoodsCd, Int64 salesPriceConsTax, Int32 taxationDivCd, string partySlipNumDtl, string dtlNote, Int32 supplierCd, string supplierSnm, string orderNumber, Int32 wayToOrder, string slipMemo1, string slipMemo2, string slipMemo3, string insideMemo1, string insideMemo2, string insideMemo3, Double bfListPrice, Double bfSalesUnitPrice, Double bfUnitCost, Int32 cmpltSalesRowNo, Int32 cmpltGoodsMakerCd, string cmpltMakerName, string cmpltMakerKanaName, string cmpltGoodsName, Double cmpltShipmentCnt, Double cmpltSalesUnPrcFl, Int64 cmpltSalesMoney, Double cmpltSalesUnitCost, Int64 cmpltCost, string cmpltPartySalSlNum, string cmpltNote, Int32 selectedGoodsNoDiv, string prtGoodsNo, Int32 prtMakerCode, string prtMakerName, Guid dtlRelationGuid, Guid carRelationGuid, Double shipmentCntDefault, Double shipmentCntDefForChk, Double acceptAnOrderCntDefault, Double acceptAnOrderCntDefForChk, Double salesUnPrcTaxIncFlDefault, Double salesUnPrcTaxExcFlDefault, Double salesUnitCostTaxIncDefault, Double salesUnitCostTacExcDefault, string enterpriseName, string updEmployeeName, string bLGoodsName, int editStatus, int rowStatus, int salesMoneyInputDiv, double shipmentCntDisplay, double supplierStockDisplay, double listPriceDisplay, DateTime stockDate, string boCode, int supplierCdForOrder, string supplierSnmForOrder)
        //public SalesDetail(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 acceptAnOrderNo, Int32 acptAnOdrStatus, string salesSlipNum, Int32 salesRowNo, Int32 salesRowDerivNo, string sectionCode, Int32 subSectionCode, DateTime salesDate, Int64 commonSeqNo, Int64 salesSlipDtlNum, Int32 acptAnOdrStatusSrc, Int64 salesSlipDtlNumSrc, Int32 supplierFormalSync, Int64 stockSlipDtlNumSync, Int32 salesSlipCdDtl, DateTime deliGdsCmpltDueDate, Int32 goodsKindCode, Int32 goodsSearchDivCd, Int32 goodsMakerCd, string makerName, string makerKanaName, string goodsNo, string goodsName, string goodsNameKana, Int32 goodsLGroup, string goodsLGroupName, Int32 goodsMGroup, string goodsMGroupName, Int32 bLGroupCode, string bLGroupName, Int32 bLGoodsCode, string bLGoodsFullName, Int32 enterpriseGanreCode, string enterpriseGanreName, string warehouseCode, string warehouseName, string warehouseShelfNo, Int32 salesOrderDivCd, Int32 openPriceDiv, string goodsRateRank, Int32 custRateGrpCode, Double listPriceRate, string rateSectPriceUnPrc, string rateDivLPrice, Int32 unPrcCalcCdLPrice, Int32 priceCdLPrice, Double stdUnPrcLPrice, Double fracProcUnitLPrice, Int32 fracProcLPrice, Double listPriceTaxIncFl, Double listPriceTaxExcFl, Int32 listPriceChngCd, Double salesRate, string rateSectSalUnPrc, string rateDivSalUnPrc, Int32 unPrcCalcCdSalUnPrc, Int32 priceCdSalUnPrc, Double stdUnPrcSalUnPrc, Double fracProcUnitSalUnPrc, Int32 fracProcSalUnPrc, Double salesUnPrcTaxIncFl, Double salesUnPrcTaxExcFl, Int32 salesUnPrcChngCd, Double costRate, string rateSectCstUnPrc, string rateDivUnCst, Int32 unPrcCalcCdUnCst, Int32 priceCdUnCst, Double stdUnPrcUnCst, Double fracProcUnitUnCst, Int32 fracProcUnCst, Double salesUnitCost, Int32 salesUnitCostChngDiv, Int32 rateBLGoodsCode, string rateBLGoodsName, Int32 rateGoodsRateGrpCd, string rateGoodsRateGrpNm, Int32 rateBLGroupCode, string rateBLGroupName, Int32 prtBLGoodsCode, string prtBLGoodsName, Int32 salesCode, string salesCdNm, Double workManHour, Double shipmentCnt, Double acceptAnOrderCnt, Double acptAnOdrAdjustCnt, Double acptAnOdrRemainCnt, DateTime remainCntUpdDate, Int64 salesMoneyTaxInc, Int64 salesMoneyTaxExc, Int64 cost, Int32 grsProfitChkDiv, Int32 salesGoodsCd, Int64 salesPriceConsTax, Int32 taxationDivCd, string partySlipNumDtl, string dtlNote, Int32 supplierCd, string supplierSnm, string orderNumber, Int32 wayToOrder, string slipMemo1, string slipMemo2, string slipMemo3, string insideMemo1, string insideMemo2, string insideMemo3, Double bfListPrice, Double bfSalesUnitPrice, Double bfUnitCost, Int32 cmpltSalesRowNo, Int32 cmpltGoodsMakerCd, string cmpltMakerName, string cmpltMakerKanaName, string cmpltGoodsName, Double cmpltShipmentCnt, Double cmpltSalesUnPrcFl, Int64 cmpltSalesMoney, Double cmpltSalesUnitCost, Int64 cmpltCost, string cmpltPartySalSlNum, string cmpltNote, Int32 selectedGoodsNoDiv, string prtGoodsNo, Int32 prtMakerCode, string prtMakerName, Guid dtlRelationGuid, Guid carRelationGuid, Double shipmentCntDefault, Double shipmentCntDefForChk, Double acceptAnOrderCntDefault, Double acceptAnOrderCntDefForChk, Double salesUnPrcTaxIncFlDefault, Double salesUnPrcTaxExcFlDefault, Double salesUnitCostTaxIncDefault, Double salesUnitCostTacExcDefault, Int32 campaignCode, string campaignName, Int32 goodsDivCd, string answerDelivDate, Int32 recycleDiv, string recycleDivNm, Int32 wayToAcptOdr, Int32 goodsMngNo, Int32 inqRowNumber, Int32 inqRowNumDerivedNo, string enterpriseName, string updEmployeeName, string bLGoodsName, int editStatus, int rowStatus, int salesMoneyInputDiv, double shipmentCntDisplay, double supplierStockDisplay, double listPriceDisplay, DateTime stockDate, string boCode, int supplierCdForOrder, string supplierSnmForOrder)// del 2011/07/18 朱宝軍
        // 2012/01/16 Add >>>
        //public SalesDetail(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 acceptAnOrderNo, Int32 acptAnOdrStatus, string salesSlipNum, Int32 salesRowNo, Int32 salesRowDerivNo, string sectionCode, Int32 subSectionCode, DateTime salesDate, Int64 commonSeqNo, Int64 salesSlipDtlNum, Int32 acptAnOdrStatusSrc, Int64 salesSlipDtlNumSrc, Int32 supplierFormalSync, Int64 stockSlipDtlNumSync, Int32 salesSlipCdDtl, DateTime deliGdsCmpltDueDate, Int32 goodsKindCode, Int32 goodsSearchDivCd, Int32 goodsMakerCd, string makerName, string makerKanaName, string goodsNo, string goodsName, string goodsNameKana, Int32 goodsLGroup, string goodsLGroupName, Int32 goodsMGroup, string goodsMGroupName, Int32 bLGroupCode, string bLGroupName, Int32 bLGoodsCode, string bLGoodsFullName, Int32 enterpriseGanreCode, string enterpriseGanreName, string warehouseCode, string warehouseName, string warehouseShelfNo, Int32 salesOrderDivCd, Int32 openPriceDiv, string goodsRateRank, Int32 custRateGrpCode, Double listPriceRate, string rateSectPriceUnPrc, string rateDivLPrice, Int32 unPrcCalcCdLPrice, Int32 priceCdLPrice, Double stdUnPrcLPrice, Double fracProcUnitLPrice, Int32 fracProcLPrice, Double listPriceTaxIncFl, Double listPriceTaxExcFl, Int32 listPriceChngCd, Double salesRate, string rateSectSalUnPrc, string rateDivSalUnPrc, Int32 unPrcCalcCdSalUnPrc, Int32 priceCdSalUnPrc, Double stdUnPrcSalUnPrc, Double fracProcUnitSalUnPrc, Int32 fracProcSalUnPrc, Double salesUnPrcTaxIncFl, Double salesUnPrcTaxExcFl, Int32 salesUnPrcChngCd, Double costRate, string rateSectCstUnPrc, string rateDivUnCst, Int32 unPrcCalcCdUnCst, Int32 priceCdUnCst, Double stdUnPrcUnCst, Double fracProcUnitUnCst, Int32 fracProcUnCst, Double salesUnitCost, Int32 salesUnitCostChngDiv, Int32 rateBLGoodsCode, string rateBLGoodsName, Int32 rateGoodsRateGrpCd, string rateGoodsRateGrpNm, Int32 rateBLGroupCode, string rateBLGroupName, Int32 prtBLGoodsCode, string prtBLGoodsName, Int32 salesCode, string salesCdNm, Double workManHour, Double shipmentCnt, Double acceptAnOrderCnt, Double acptAnOdrAdjustCnt, Double acptAnOdrRemainCnt, DateTime remainCntUpdDate, Int64 salesMoneyTaxInc, Int64 salesMoneyTaxExc, Int64 cost, Int32 grsProfitChkDiv, Int32 salesGoodsCd, Int64 salesPriceConsTax, Int32 taxationDivCd, string partySlipNumDtl, string dtlNote, Int32 supplierCd, string supplierSnm, string orderNumber, Int32 wayToOrder, string slipMemo1, string slipMemo2, string slipMemo3, string insideMemo1, string insideMemo2, string insideMemo3, Double bfListPrice, Double bfSalesUnitPrice, Double bfUnitCost, Int32 cmpltSalesRowNo, Int32 cmpltGoodsMakerCd, string cmpltMakerName, string cmpltMakerKanaName, string cmpltGoodsName, Double cmpltShipmentCnt, Double cmpltSalesUnPrcFl, Int64 cmpltSalesMoney, Double cmpltSalesUnitCost, Int64 cmpltCost, string cmpltPartySalSlNum, string cmpltNote, Int32 selectedGoodsNoDiv, string prtGoodsNo, Int32 prtMakerCode, string prtMakerName, Guid dtlRelationGuid, Guid carRelationGuid, Double shipmentCntDefault, Double shipmentCntDefForChk, Double acceptAnOrderCntDefault, Double acceptAnOrderCntDefForChk, Double salesUnPrcTaxIncFlDefault, Double salesUnPrcTaxExcFlDefault, Double salesUnitCostTaxIncDefault, Double salesUnitCostTacExcDefault, Int32 campaignCode, string campaignName, Int32 goodsDivCd, string answerDelivDate, Int32 recycleDiv, string recycleDivNm, Int32 wayToAcptOdr, Int32 goodsMngNo, Int32 inqRowNumber, Int32 inqRowNumDerivedNo, string enterpriseName, string updEmployeeName, string bLGoodsName, int editStatus, int rowStatus, int salesMoneyInputDiv, double shipmentCntDisplay, double supplierStockDisplay, double listPriceDisplay, DateTime stockDate, string boCode, int supplierCdForOrder, string supplierSnmForOrder, int autoAnswerDivSCM, Int16 acceptOrOrderKind, Int64 inquiryNumber)// add 2011/07/18 朱宝軍
        //>>>2012/05/02
        //public SalesDetail(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 acceptAnOrderNo, Int32 acptAnOdrStatus, string salesSlipNum, Int32 salesRowNo, Int32 salesRowDerivNo, string sectionCode, Int32 subSectionCode, DateTime salesDate, Int64 commonSeqNo, Int64 salesSlipDtlNum, Int32 acptAnOdrStatusSrc, Int64 salesSlipDtlNumSrc, Int32 supplierFormalSync, Int64 stockSlipDtlNumSync, Int32 salesSlipCdDtl, DateTime deliGdsCmpltDueDate, Int32 goodsKindCode, Int32 goodsSearchDivCd, Int32 goodsMakerCd, string makerName, string makerKanaName, string goodsNo, string goodsName, string goodsNameKana, Int32 goodsLGroup, string goodsLGroupName, Int32 goodsMGroup, string goodsMGroupName, Int32 bLGroupCode, string bLGroupName, Int32 bLGoodsCode, string bLGoodsFullName, Int32 enterpriseGanreCode, string enterpriseGanreName, string warehouseCode, string warehouseName, string warehouseShelfNo, Int32 salesOrderDivCd, Int32 openPriceDiv, string goodsRateRank, Int32 custRateGrpCode, Double listPriceRate, string rateSectPriceUnPrc, string rateDivLPrice, Int32 unPrcCalcCdLPrice, Int32 priceCdLPrice, Double stdUnPrcLPrice, Double fracProcUnitLPrice, Int32 fracProcLPrice, Double listPriceTaxIncFl, Double listPriceTaxExcFl, Int32 listPriceChngCd, Double salesRate, string rateSectSalUnPrc, string rateDivSalUnPrc, Int32 unPrcCalcCdSalUnPrc, Int32 priceCdSalUnPrc, Double stdUnPrcSalUnPrc, Double fracProcUnitSalUnPrc, Int32 fracProcSalUnPrc, Double salesUnPrcTaxIncFl, Double salesUnPrcTaxExcFl, Int32 salesUnPrcChngCd, Double costRate, string rateSectCstUnPrc, string rateDivUnCst, Int32 unPrcCalcCdUnCst, Int32 priceCdUnCst, Double stdUnPrcUnCst, Double fracProcUnitUnCst, Int32 fracProcUnCst, Double salesUnitCost, Int32 salesUnitCostChngDiv, Int32 rateBLGoodsCode, string rateBLGoodsName, Int32 rateGoodsRateGrpCd, string rateGoodsRateGrpNm, Int32 rateBLGroupCode, string rateBLGroupName, Int32 prtBLGoodsCode, string prtBLGoodsName, Int32 salesCode, string salesCdNm, Double workManHour, Double shipmentCnt, Double acceptAnOrderCnt, Double acptAnOdrAdjustCnt, Double acptAnOdrRemainCnt, DateTime remainCntUpdDate, Int64 salesMoneyTaxInc, Int64 salesMoneyTaxExc, Int64 cost, Int32 grsProfitChkDiv, Int32 salesGoodsCd, Int64 salesPriceConsTax, Int32 taxationDivCd, string partySlipNumDtl, string dtlNote, Int32 supplierCd, string supplierSnm, string orderNumber, Int32 wayToOrder, string slipMemo1, string slipMemo2, string slipMemo3, string insideMemo1, string insideMemo2, string insideMemo3, Double bfListPrice, Double bfSalesUnitPrice, Double bfUnitCost, Int32 cmpltSalesRowNo, Int32 cmpltGoodsMakerCd, string cmpltMakerName, string cmpltMakerKanaName, string cmpltGoodsName, Double cmpltShipmentCnt, Double cmpltSalesUnPrcFl, Int64 cmpltSalesMoney, Double cmpltSalesUnitCost, Int64 cmpltCost, string cmpltPartySalSlNum, string cmpltNote, Int32 selectedGoodsNoDiv, string prtGoodsNo, Int32 prtMakerCode, string prtMakerName, Guid dtlRelationGuid, Guid carRelationGuid, Double shipmentCntDefault, Double shipmentCntDefForChk, Double acceptAnOrderCntDefault, Double acceptAnOrderCntDefForChk, Double salesUnPrcTaxIncFlDefault, Double salesUnPrcTaxExcFlDefault, Double salesUnitCostTaxIncDefault, Double salesUnitCostTacExcDefault, Int32 campaignCode, string campaignName, Int32 goodsDivCd, string answerDelivDate, Int32 recycleDiv, string recycleDivNm, Int32 wayToAcptOdr, Int32 goodsMngNo, Int32 inqRowNumber, Int32 inqRowNumDerivedNo, string enterpriseName, string updEmployeeName, string bLGoodsName, int editStatus, int rowStatus, int salesMoneyInputDiv, double shipmentCntDisplay, double supplierStockDisplay, double listPriceDisplay, DateTime stockDate, string boCode, int supplierCdForOrder, string supplierSnmForOrder, int autoAnswerDivSCM, Int16 acceptOrOrderKind, Int64 inquiryNumber, string goodsSpecialNote)
        //public SalesDetail(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 acceptAnOrderNo, Int32 acptAnOdrStatus, string salesSlipNum, Int32 salesRowNo, Int32 salesRowDerivNo, string sectionCode, Int32 subSectionCode, DateTime salesDate, Int64 commonSeqNo, Int64 salesSlipDtlNum, Int32 acptAnOdrStatusSrc, Int64 salesSlipDtlNumSrc, Int32 supplierFormalSync, Int64 stockSlipDtlNumSync, Int32 salesSlipCdDtl, DateTime deliGdsCmpltDueDate, Int32 goodsKindCode, Int32 goodsSearchDivCd, Int32 goodsMakerCd, string makerName, string makerKanaName, string goodsNo, string goodsName, string goodsNameKana, Int32 goodsLGroup, string goodsLGroupName, Int32 goodsMGroup, string goodsMGroupName, Int32 bLGroupCode, string bLGroupName, Int32 bLGoodsCode, string bLGoodsFullName, Int32 enterpriseGanreCode, string enterpriseGanreName, string warehouseCode, string warehouseName, string warehouseShelfNo, Int32 salesOrderDivCd, Int32 openPriceDiv, string goodsRateRank, Int32 custRateGrpCode, Double listPriceRate, string rateSectPriceUnPrc, string rateDivLPrice, Int32 unPrcCalcCdLPrice, Int32 priceCdLPrice, Double stdUnPrcLPrice, Double fracProcUnitLPrice, Int32 fracProcLPrice, Double listPriceTaxIncFl, Double listPriceTaxExcFl, Int32 listPriceChngCd, Double salesRate, string rateSectSalUnPrc, string rateDivSalUnPrc, Int32 unPrcCalcCdSalUnPrc, Int32 priceCdSalUnPrc, Double stdUnPrcSalUnPrc, Double fracProcUnitSalUnPrc, Int32 fracProcSalUnPrc, Double salesUnPrcTaxIncFl, Double salesUnPrcTaxExcFl, Int32 salesUnPrcChngCd, Double costRate, string rateSectCstUnPrc, string rateDivUnCst, Int32 unPrcCalcCdUnCst, Int32 priceCdUnCst, Double stdUnPrcUnCst, Double fracProcUnitUnCst, Int32 fracProcUnCst, Double salesUnitCost, Int32 salesUnitCostChngDiv, Int32 rateBLGoodsCode, string rateBLGoodsName, Int32 rateGoodsRateGrpCd, string rateGoodsRateGrpNm, Int32 rateBLGroupCode, string rateBLGroupName, Int32 prtBLGoodsCode, string prtBLGoodsName, Int32 salesCode, string salesCdNm, Double workManHour, Double shipmentCnt, Double acceptAnOrderCnt, Double acptAnOdrAdjustCnt, Double acptAnOdrRemainCnt, DateTime remainCntUpdDate, Int64 salesMoneyTaxInc, Int64 salesMoneyTaxExc, Int64 cost, Int32 grsProfitChkDiv, Int32 salesGoodsCd, Int64 salesPriceConsTax, Int32 taxationDivCd, string partySlipNumDtl, string dtlNote, Int32 supplierCd, string supplierSnm, string orderNumber, Int32 wayToOrder, string slipMemo1, string slipMemo2, string slipMemo3, string insideMemo1, string insideMemo2, string insideMemo3, Double bfListPrice, Double bfSalesUnitPrice, Double bfUnitCost, Int32 cmpltSalesRowNo, Int32 cmpltGoodsMakerCd, string cmpltMakerName, string cmpltMakerKanaName, string cmpltGoodsName, Double cmpltShipmentCnt, Double cmpltSalesUnPrcFl, Int64 cmpltSalesMoney, Double cmpltSalesUnitCost, Int64 cmpltCost, string cmpltPartySalSlNum, string cmpltNote, Int32 selectedGoodsNoDiv, string prtGoodsNo, Int32 prtMakerCode, string prtMakerName, Guid dtlRelationGuid, Guid carRelationGuid, Double shipmentCntDefault, Double shipmentCntDefForChk, Double acceptAnOrderCntDefault, Double acceptAnOrderCntDefForChk, Double salesUnPrcTaxIncFlDefault, Double salesUnPrcTaxExcFlDefault, Double salesUnitCostTaxIncDefault, Double salesUnitCostTacExcDefault, Int32 campaignCode, string campaignName, Int32 goodsDivCd, string answerDelivDate, Int32 recycleDiv, string recycleDivNm, Int32 wayToAcptOdr, Int32 goodsMngNo, Int32 inqRowNumber, Int32 inqRowNumDerivedNo, string enterpriseName, string updEmployeeName, string bLGoodsName, int editStatus, int rowStatus, int salesMoneyInputDiv, double shipmentCntDisplay, double supplierStockDisplay, double listPriceDisplay, DateTime stockDate, string boCode, int supplierCdForOrder, string supplierSnmForOrder, int autoAnswerDivSCM, Int16 acceptOrOrderKind, Int64 inquiryNumber, string goodsSpecialNote, Int32 rentSyncSupplier, DateTime rentSyncStockDate, string rentSyncSupSlipNo)// DEL 2013/01/24 鄧潘ハン REDMINE#34605
        public SalesDetail(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 acceptAnOrderNo, Int32 acptAnOdrStatus, string salesSlipNum, Int32 salesRowNo, Int32 salesRowDerivNo, string sectionCode, Int32 subSectionCode, DateTime salesDate, Int64 commonSeqNo, Int64 salesSlipDtlNum, Int32 acptAnOdrStatusSrc, Int64 salesSlipDtlNumSrc, Int32 supplierFormalSync, Int64 stockSlipDtlNumSync, Int32 salesSlipCdDtl, DateTime deliGdsCmpltDueDate, Int32 goodsKindCode, Int32 goodsSearchDivCd, Int32 goodsMakerCd, string makerName, string makerKanaName, string goodsNo, string goodsName, string goodsNameKana, Int32 goodsLGroup, string goodsLGroupName, Int32 goodsMGroup, string goodsMGroupName, Int32 bLGroupCode, string bLGroupName, Int32 bLGoodsCode, string bLGoodsFullName, Int32 enterpriseGanreCode, string enterpriseGanreName, string warehouseCode, string warehouseName, string warehouseShelfNo, Int32 salesOrderDivCd, Int32 openPriceDiv, string goodsRateRank, Int32 custRateGrpCode, Double listPriceRate, string rateSectPriceUnPrc, string rateDivLPrice, Int32 unPrcCalcCdLPrice, Int32 priceCdLPrice, Double stdUnPrcLPrice, Double fracProcUnitLPrice, Int32 fracProcLPrice, Double listPriceTaxIncFl, Double listPriceTaxExcFl, Int32 listPriceChngCd, Double salesRate, string rateSectSalUnPrc, string rateDivSalUnPrc, Int32 unPrcCalcCdSalUnPrc, Int32 priceCdSalUnPrc, Double stdUnPrcSalUnPrc, Double fracProcUnitSalUnPrc, Int32 fracProcSalUnPrc, Double salesUnPrcTaxIncFl, Double salesUnPrcTaxExcFl, Int32 salesUnPrcChngCd, Double costRate, string rateSectCstUnPrc, string rateDivUnCst, Int32 unPrcCalcCdUnCst, Int32 priceCdUnCst, Double stdUnPrcUnCst, Double fracProcUnitUnCst, Int32 fracProcUnCst, Double salesUnitCost, Int32 salesUnitCostChngDiv, Int32 rateBLGoodsCode, string rateBLGoodsName, Int32 rateGoodsRateGrpCd, string rateGoodsRateGrpNm, Int32 rateBLGroupCode, string rateBLGroupName, Int32 prtBLGoodsCode, string prtBLGoodsName, Int32 salesCode, string salesCdNm, Double workManHour, Double shipmentCnt, Double acceptAnOrderCnt, Double acptAnOdrAdjustCnt, Double acptAnOdrRemainCnt, DateTime remainCntUpdDate, Int64 salesMoneyTaxInc, Int64 salesMoneyTaxExc, Int64 cost, Int32 grsProfitChkDiv, Int32 salesGoodsCd, Int64 salesPriceConsTax, Int32 taxationDivCd, string partySlipNumDtl, string dtlNote, Int32 supplierCd, string supplierSnm, string orderNumber, Int32 wayToOrder, string slipMemo1, string slipMemo2, string slipMemo3, string insideMemo1, string insideMemo2, string insideMemo3, Double bfListPrice, Double bfSalesUnitPrice, Double bfUnitCost, Int32 cmpltSalesRowNo, Int32 cmpltGoodsMakerCd, string cmpltMakerName, string cmpltMakerKanaName, string cmpltGoodsName, Double cmpltShipmentCnt, Double cmpltSalesUnPrcFl, Int64 cmpltSalesMoney, Double cmpltSalesUnitCost, Int64 cmpltCost, string cmpltPartySalSlNum, string cmpltNote, Int32 selectedGoodsNoDiv, string prtGoodsNo, Int32 prtMakerCode, string prtMakerName, Guid dtlRelationGuid, Guid carRelationGuid, Double shipmentCntDefault, Double shipmentCntDefForChk, Double acceptAnOrderCntDefault, Double acceptAnOrderCntDefForChk, Double salesUnPrcTaxIncFlDefault, Double salesUnPrcTaxExcFlDefault, Double salesUnitCostTaxIncDefault, Double salesUnitCostTacExcDefault, Int32 campaignCode, string campaignName, Int32 goodsDivCd, string answerDelivDate, Int32 recycleDiv, string recycleDivNm, Int32 wayToAcptOdr, Int32 goodsMngNo, Int32 inqRowNumber, Int32 inqRowNumDerivedNo, string enterpriseName, string updEmployeeName, string bLGoodsName, int editStatus, int rowStatus, int salesMoneyInputDiv, double shipmentCntDisplay, double supplierStockDisplay, double listPriceDisplay, DateTime stockDate, string boCode, int supplierCdForOrder, string supplierSnmForOrder, int autoAnswerDivSCM, Int16 acceptOrOrderKind, Int64 inquiryNumber, string goodsSpecialNote, Int32 rentSyncSupplier, DateTime rentSyncStockDate, string rentSyncSupSlipNo, Int32 priceSelectDiv)// ADD 2013/01/24 鄧潘ハン REDMINE#34605
        //<<<2012/05/02
        // 2012/01/16 Add <<<
        //<<<2010/02/26
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
            this._salesSlipNum = salesSlipNum;
            this._salesRowNo = salesRowNo;
            this._salesRowDerivNo = salesRowDerivNo;
            this._sectionCode = sectionCode;
            this._subSectionCode = subSectionCode;
            this.SalesDate = salesDate;
            this._commonSeqNo = commonSeqNo;
            this._salesSlipDtlNum = salesSlipDtlNum;
            this._acptAnOdrStatusSrc = acptAnOdrStatusSrc;
            this._salesSlipDtlNumSrc = salesSlipDtlNumSrc;
            this._supplierFormalSync = supplierFormalSync;
            this._stockSlipDtlNumSync = stockSlipDtlNumSync;
            this._salesSlipCdDtl = salesSlipCdDtl;
            this.DeliGdsCmpltDueDate = deliGdsCmpltDueDate;
            this._goodsKindCode = goodsKindCode;
            this._goodsSearchDivCd = goodsSearchDivCd;
            this._goodsMakerCd = goodsMakerCd;
            this._makerName = makerName;
            this._makerKanaName = makerKanaName;
            this._goodsNo = goodsNo;
            this._goodsName = goodsName;
            this._goodsNameKana = goodsNameKana;
            this._goodsLGroup = goodsLGroup;
            this._goodsLGroupName = goodsLGroupName;
            this._goodsMGroup = goodsMGroup;
            this._goodsMGroupName = goodsMGroupName;
            this._bLGroupCode = bLGroupCode;
            this._bLGroupName = bLGroupName;
            this._bLGoodsCode = bLGoodsCode;
            this._bLGoodsFullName = bLGoodsFullName;
            this._enterpriseGanreCode = enterpriseGanreCode;
            this._enterpriseGanreName = enterpriseGanreName;
            this._warehouseCode = warehouseCode;
            this._warehouseName = warehouseName;
            this._warehouseShelfNo = warehouseShelfNo;
            this._salesOrderDivCd = salesOrderDivCd;
            this._openPriceDiv = openPriceDiv;
            this._goodsRateRank = goodsRateRank;
            this._custRateGrpCode = custRateGrpCode;
            this._listPriceRate = listPriceRate;
            this._rateSectPriceUnPrc = rateSectPriceUnPrc;
            this._rateDivLPrice = rateDivLPrice;
            this._unPrcCalcCdLPrice = unPrcCalcCdLPrice;
            this._priceCdLPrice = priceCdLPrice;
            this._stdUnPrcLPrice = stdUnPrcLPrice;
            this._fracProcUnitLPrice = fracProcUnitLPrice;
            this._fracProcLPrice = fracProcLPrice;
            this._listPriceTaxIncFl = listPriceTaxIncFl;
            this._listPriceTaxExcFl = listPriceTaxExcFl;
            this._listPriceChngCd = listPriceChngCd;
            this._salesRate = salesRate;
            this._rateSectSalUnPrc = rateSectSalUnPrc;
            this._rateDivSalUnPrc = rateDivSalUnPrc;
            this._unPrcCalcCdSalUnPrc = unPrcCalcCdSalUnPrc;
            this._priceCdSalUnPrc = priceCdSalUnPrc;
            this._stdUnPrcSalUnPrc = stdUnPrcSalUnPrc;
            this._fracProcUnitSalUnPrc = fracProcUnitSalUnPrc;
            this._fracProcSalUnPrc = fracProcSalUnPrc;
            this._salesUnPrcTaxIncFl = salesUnPrcTaxIncFl;
            this._salesUnPrcTaxExcFl = salesUnPrcTaxExcFl;
            this._salesUnPrcChngCd = salesUnPrcChngCd;
            this._costRate = costRate;
            this._rateSectCstUnPrc = rateSectCstUnPrc;
            this._rateDivUnCst = rateDivUnCst;
            this._unPrcCalcCdUnCst = unPrcCalcCdUnCst;
            this._priceCdUnCst = priceCdUnCst;
            this._stdUnPrcUnCst = stdUnPrcUnCst;
            this._fracProcUnitUnCst = fracProcUnitUnCst;
            this._fracProcUnCst = fracProcUnCst;
            this._salesUnitCost = salesUnitCost;
            this._salesUnitCostChngDiv = salesUnitCostChngDiv;
            this._rateBLGoodsCode = rateBLGoodsCode;
            this._rateBLGoodsName = rateBLGoodsName;
            this._rateGoodsRateGrpCd = rateGoodsRateGrpCd;
            this._rateGoodsRateGrpNm = rateGoodsRateGrpNm;
            this._rateBLGroupCode = rateBLGroupCode;
            this._rateBLGroupName = rateBLGroupName;
            this._prtBLGoodsCode = prtBLGoodsCode;
            this._prtBLGoodsName = prtBLGoodsName;
            this._salesCode = salesCode;
            this._salesCdNm = salesCdNm;
            this._workManHour = workManHour;
            this._shipmentCnt = shipmentCnt;
            this._acceptAnOrderCnt = acceptAnOrderCnt;
            this._acptAnOdrAdjustCnt = acptAnOdrAdjustCnt;
            this._acptAnOdrRemainCnt = acptAnOdrRemainCnt;
            this.RemainCntUpdDate = remainCntUpdDate;
            this._salesMoneyTaxInc = salesMoneyTaxInc;
            this._salesMoneyTaxExc = salesMoneyTaxExc;
            this._cost = cost;
            this._grsProfitChkDiv = grsProfitChkDiv;
            this._salesGoodsCd = salesGoodsCd;
            this._salesPriceConsTax = salesPriceConsTax;
            this._taxationDivCd = taxationDivCd;
            this._partySlipNumDtl = partySlipNumDtl;
            this._dtlNote = dtlNote;
            this._supplierCd = supplierCd;
            this._supplierSnm = supplierSnm;
            this._orderNumber = orderNumber;
            this._wayToOrder = wayToOrder;
            this._slipMemo1 = slipMemo1;
            this._slipMemo2 = slipMemo2;
            this._slipMemo3 = slipMemo3;
            this._insideMemo1 = insideMemo1;
            this._insideMemo2 = insideMemo2;
            this._insideMemo3 = insideMemo3;
            this._bfListPrice = bfListPrice;
            this._bfSalesUnitPrice = bfSalesUnitPrice;
            this._bfUnitCost = bfUnitCost;
            this._cmpltSalesRowNo = cmpltSalesRowNo;
            this._cmpltGoodsMakerCd = cmpltGoodsMakerCd;
            this._cmpltMakerName = cmpltMakerName;
            this._cmpltMakerKanaName = cmpltMakerKanaName;
            this._cmpltGoodsName = cmpltGoodsName;
            this._cmpltShipmentCnt = cmpltShipmentCnt;
            this._cmpltSalesUnPrcFl = cmpltSalesUnPrcFl;
            this._cmpltSalesMoney = cmpltSalesMoney;
            this._cmpltSalesUnitCost = cmpltSalesUnitCost;
            this._cmpltCost = cmpltCost;
            this._cmpltPartySalSlNum = cmpltPartySalSlNum;
            this._cmpltNote = cmpltNote;
            // --- ADD 2009/10/19 ---------->>>>>
            this._selectedGoodsNoDiv = selectedGoodsNoDiv;
            // --- ADD 2009/10/19 ----------<<<<<
            this._prtGoodsNo = prtGoodsNo;
            this._prtMakerCode = prtMakerCode;
            this._prtMakerName = prtMakerName;
            this._dtlRelationGuid = dtlRelationGuid;
            this._carRelationGuid = carRelationGuid;
            this._shipmentCntDefault = shipmentCntDefault;
            this._shipmentCntDefForChk = shipmentCntDefForChk;
            this._acceptAnOrderCntDefault = acceptAnOrderCntDefault;
            this._acceptAnOrderCntDefForChk = acceptAnOrderCntDefForChk;
            this._salesUnPrcTaxIncFlDefault = salesUnPrcTaxIncFlDefault;
            this._salesUnPrcTaxExcFlDefault = salesUnPrcTaxExcFlDefault;
            this._salesUnitCostTaxIncDefault = salesUnitCostTaxIncDefault;
            this._salesUnitCostTacExcDefault = salesUnitCostTacExcDefault;
            //<<<2010/02/26
            this._campaignCode = campaignCode;
            this._campaignName = campaignName;
            this._goodsDivCd = goodsDivCd;
            this._answerDelivDate = answerDelivDate;
            this._recycleDiv = recycleDiv;
            this._recycleDivNm = recycleDivNm;
            this._wayToAcptOdr = wayToAcptOdr;
            this._goodsMngNo = goodsMngNo;
            this._inqRowNumber = inqRowNumber;
            this._inqRowNumDerivedNo = inqRowNumDerivedNo;
            //<<<2010/02/26
            this._enterpriseName = enterpriseName;
            this._updEmployeeName = updEmployeeName;
            this._bLGoodsName = bLGoodsName;
            this._editStatus = editStatus;//ADD 2010/04/06
            this._rowStatus = rowStatus;//ADD 2010/04/06
            this._salesMoneyInputDiv = salesMoneyInputDiv;//ADD 2010/04/06
            this._shipmentCntDisplay = shipmentCntDisplay;//ADD 2010/04/06
            this._supplierStockDisplay = supplierStockDisplay;//ADD 2010/04/06
            this._listPriceDisplay = listPriceDisplay;//ADD 2010/04/06
            this._stockDate = stockDate;//ADD 2010/04/06

            this._boCode = boCode;//ADD 2010/04/06
            this._supplierCdForOrder = supplierCdForOrder;//ADD 2010/04/06
            this._supplierSnmForOrder = supplierSnmForOrder;//ADD 2010/04/06
            // --- ADD 2011/08/08 ---------->>>>>
            this._autoAnswerDivSCM = autoAnswerDivSCM;
            this._acceptOrOrderKind = acceptOrOrderKind;
            this._inquiryNumber = inquiryNumber;
            // --- ADD 2011/08/08 ----------<<<<<
            // 2012/01/16 Add >>>
            this._goodsSpecialNote = goodsSpecialNote;
            // 2012/01/16 Add <<<
            //>>>2012/05/02
            this._rentSyncSupplier = rentSyncSupplier;
            this._rentSyncStockDate = rentSyncStockDate;
            this._rentSyncSupSlipNo = rentSyncSupSlipNo;
            //<<<2012/05/02
            this._priceSelectDiv = priceSelectDiv;// ADD 2013/01/24 鄧潘ハン REDMINE#34605
        }

        /// <summary>
        /// 売上明細データ複製処理
        /// </summary>
        /// <returns>SalesDetailクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいSalesDetailクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SalesDetail Clone()
        {
            //>>>2010/02/26
            //return new SalesDetail(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._acceptAnOrderNo, this._acptAnOdrStatus, this._salesSlipNum, this._salesRowNo, this._salesRowDerivNo, this._sectionCode, this._subSectionCode, this._salesDate, this._commonSeqNo, this._salesSlipDtlNum, this._acptAnOdrStatusSrc, this._salesSlipDtlNumSrc, this._supplierFormalSync, this._stockSlipDtlNumSync, this._salesSlipCdDtl, this._deliGdsCmpltDueDate, this._goodsKindCode, this._goodsSearchDivCd, this._goodsMakerCd, this._makerName, this._makerKanaName, this._goodsNo, this._goodsName, this._goodsNameKana, this._goodsLGroup, this._goodsLGroupName, this._goodsMGroup, this._goodsMGroupName, this._bLGroupCode, this._bLGroupName, this._bLGoodsCode, this._bLGoodsFullName, this._enterpriseGanreCode, this._enterpriseGanreName, this._warehouseCode, this._warehouseName, this._warehouseShelfNo, this._salesOrderDivCd, this._openPriceDiv, this._goodsRateRank, this._custRateGrpCode, this._listPriceRate, this._rateSectPriceUnPrc, this._rateDivLPrice, this._unPrcCalcCdLPrice, this._priceCdLPrice, this._stdUnPrcLPrice, this._fracProcUnitLPrice, this._fracProcLPrice, this._listPriceTaxIncFl, this._listPriceTaxExcFl, this._listPriceChngCd, this._salesRate, this._rateSectSalUnPrc, this._rateDivSalUnPrc, this._unPrcCalcCdSalUnPrc, this._priceCdSalUnPrc, this._stdUnPrcSalUnPrc, this._fracProcUnitSalUnPrc, this._fracProcSalUnPrc, this._salesUnPrcTaxIncFl, this._salesUnPrcTaxExcFl, this._salesUnPrcChngCd, this._costRate, this._rateSectCstUnPrc, this._rateDivUnCst, this._unPrcCalcCdUnCst, this._priceCdUnCst, this._stdUnPrcUnCst, this._fracProcUnitUnCst, this._fracProcUnCst, this._salesUnitCost, this._salesUnitCostChngDiv, this._rateBLGoodsCode, this._rateBLGoodsName, this._rateGoodsRateGrpCd, this._rateGoodsRateGrpNm, this._rateBLGroupCode, this._rateBLGroupName, this._prtBLGoodsCode, this._prtBLGoodsName, this._salesCode, this._salesCdNm, this._workManHour, this._shipmentCnt, this._acceptAnOrderCnt, this._acptAnOdrAdjustCnt, this._acptAnOdrRemainCnt, this._remainCntUpdDate, this._salesMoneyTaxInc, this._salesMoneyTaxExc, this._cost, this._grsProfitChkDiv, this._salesGoodsCd, this._salesPriceConsTax, this._taxationDivCd, this._partySlipNumDtl, this._dtlNote, this._supplierCd, this._supplierSnm, this._orderNumber, this._wayToOrder, this._slipMemo1, this._slipMemo2, this._slipMemo3, this._insideMemo1, this._insideMemo2, this._insideMemo3, this._bfListPrice, this._bfSalesUnitPrice, this._bfUnitCost, this._cmpltSalesRowNo, this._cmpltGoodsMakerCd, this._cmpltMakerName, this._cmpltMakerKanaName, this._cmpltGoodsName, this._cmpltShipmentCnt, this._cmpltSalesUnPrcFl, this._cmpltSalesMoney, this._cmpltSalesUnitCost, this._cmpltCost, this._cmpltPartySalSlNum, this._cmpltNote, this._selectedGoodsNoDiv, this._prtGoodsNo, this._prtMakerCode, this._prtMakerName, this._dtlRelationGuid, this._carRelationGuid, this._shipmentCntDefault, this._shipmentCntDefForChk, this._acceptAnOrderCntDefault, this._acceptAnOrderCntDefForChk, this._salesUnPrcTaxIncFlDefault, this._salesUnPrcTaxExcFlDefault, this._salesUnitCostTaxIncDefault, this._salesUnitCostTacExcDefault, this._enterpriseName, this._updEmployeeName, this._bLGoodsName, this._editStatus, this._rowStatus, this._salesMoneyInputDiv, this._shipmentCntDisplay, this._supplierStockDisplay, this._listPriceDisplay, this._stockDate, this._boCode, this._supplierCdForOrder, this._supplierSnmForOrder);
            //return new SalesDetail(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._acceptAnOrderNo, this._acptAnOdrStatus, this._salesSlipNum, this._salesRowNo, this._salesRowDerivNo, this._sectionCode, this._subSectionCode, this._salesDate, this._commonSeqNo, this._salesSlipDtlNum, this._acptAnOdrStatusSrc, this._salesSlipDtlNumSrc, this._supplierFormalSync, this._stockSlipDtlNumSync, this._salesSlipCdDtl, this._deliGdsCmpltDueDate, this._goodsKindCode, this._goodsSearchDivCd, this._goodsMakerCd, this._makerName, this._makerKanaName, this._goodsNo, this._goodsName, this._goodsNameKana, this._goodsLGroup, this._goodsLGroupName, this._goodsMGroup, this._goodsMGroupName, this._bLGroupCode, this._bLGroupName, this._bLGoodsCode, this._bLGoodsFullName, this._enterpriseGanreCode, this._enterpriseGanreName, this._warehouseCode, this._warehouseName, this._warehouseShelfNo, this._salesOrderDivCd, this._openPriceDiv, this._goodsRateRank, this._custRateGrpCode, this._listPriceRate, this._rateSectPriceUnPrc, this._rateDivLPrice, this._unPrcCalcCdLPrice, this._priceCdLPrice, this._stdUnPrcLPrice, this._fracProcUnitLPrice, this._fracProcLPrice, this._listPriceTaxIncFl, this._listPriceTaxExcFl, this._listPriceChngCd, this._salesRate, this._rateSectSalUnPrc, this._rateDivSalUnPrc, this._unPrcCalcCdSalUnPrc, this._priceCdSalUnPrc, this._stdUnPrcSalUnPrc, this._fracProcUnitSalUnPrc, this._fracProcSalUnPrc, this._salesUnPrcTaxIncFl, this._salesUnPrcTaxExcFl, this._salesUnPrcChngCd, this._costRate, this._rateSectCstUnPrc, this._rateDivUnCst, this._unPrcCalcCdUnCst, this._priceCdUnCst, this._stdUnPrcUnCst, this._fracProcUnitUnCst, this._fracProcUnCst, this._salesUnitCost, this._salesUnitCostChngDiv, this._rateBLGoodsCode, this._rateBLGoodsName, this._rateGoodsRateGrpCd, this._rateGoodsRateGrpNm, this._rateBLGroupCode, this._rateBLGroupName, this._prtBLGoodsCode, this._prtBLGoodsName, this._salesCode, this._salesCdNm, this._workManHour, this._shipmentCnt, this._acceptAnOrderCnt, this._acptAnOdrAdjustCnt, this._acptAnOdrRemainCnt, this._remainCntUpdDate, this._salesMoneyTaxInc, this._salesMoneyTaxExc, this._cost, this._grsProfitChkDiv, this._salesGoodsCd, this._salesPriceConsTax, this._taxationDivCd, this._partySlipNumDtl, this._dtlNote, this._supplierCd, this._supplierSnm, this._orderNumber, this._wayToOrder, this._slipMemo1, this._slipMemo2, this._slipMemo3, this._insideMemo1, this._insideMemo2, this._insideMemo3, this._bfListPrice, this._bfSalesUnitPrice, this._bfUnitCost, this._cmpltSalesRowNo, this._cmpltGoodsMakerCd, this._cmpltMakerName, this._cmpltMakerKanaName, this._cmpltGoodsName, this._cmpltShipmentCnt, this._cmpltSalesUnPrcFl, this._cmpltSalesMoney, this._cmpltSalesUnitCost, this._cmpltCost, this._cmpltPartySalSlNum, this._cmpltNote, this._selectedGoodsNoDiv, this._prtGoodsNo, this._prtMakerCode, this._prtMakerName, this._dtlRelationGuid, this._carRelationGuid, this._shipmentCntDefault, this._shipmentCntDefForChk, this._acceptAnOrderCntDefault, this._acceptAnOrderCntDefForChk, this._salesUnPrcTaxIncFlDefault, this._salesUnPrcTaxExcFlDefault, this._salesUnitCostTaxIncDefault, this._salesUnitCostTacExcDefault, this._campaignCode, this._campaignName, this._goodsDivCd, this._answerDelivDate, this._recycleDiv, this._recycleDivNm, this._wayToAcptOdr, this._goodsMngNo, this._inqRowNumber, this._inqRowNumDerivedNo, this._enterpriseName, this._updEmployeeName, this._bLGoodsName, this._editStatus, this._rowStatus, this._salesMoneyInputDiv, this._shipmentCntDisplay, this._supplierStockDisplay, this._listPriceDisplay, this._stockDate, this._boCode, this._supplierCdForOrder, this._supplierSnmForOrder);// del 2011/07/18 朱宝軍
            //<<<2010/02/26
            // 2012/01/16 Add >>>
            //return new SalesDetail(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._acceptAnOrderNo, this._acptAnOdrStatus, this._salesSlipNum, this._salesRowNo, this._salesRowDerivNo, this._sectionCode, this._subSectionCode, this._salesDate, this._commonSeqNo, this._salesSlipDtlNum, this._acptAnOdrStatusSrc, this._salesSlipDtlNumSrc, this._supplierFormalSync, this._stockSlipDtlNumSync, this._salesSlipCdDtl, this._deliGdsCmpltDueDate, this._goodsKindCode, this._goodsSearchDivCd, this._goodsMakerCd, this._makerName, this._makerKanaName, this._goodsNo, this._goodsName, this._goodsNameKana, this._goodsLGroup, this._goodsLGroupName, this._goodsMGroup, this._goodsMGroupName, this._bLGroupCode, this._bLGroupName, this._bLGoodsCode, this._bLGoodsFullName, this._enterpriseGanreCode, this._enterpriseGanreName, this._warehouseCode, this._warehouseName, this._warehouseShelfNo, this._salesOrderDivCd, this._openPriceDiv, this._goodsRateRank, this._custRateGrpCode, this._listPriceRate, this._rateSectPriceUnPrc, this._rateDivLPrice, this._unPrcCalcCdLPrice, this._priceCdLPrice, this._stdUnPrcLPrice, this._fracProcUnitLPrice, this._fracProcLPrice, this._listPriceTaxIncFl, this._listPriceTaxExcFl, this._listPriceChngCd, this._salesRate, this._rateSectSalUnPrc, this._rateDivSalUnPrc, this._unPrcCalcCdSalUnPrc, this._priceCdSalUnPrc, this._stdUnPrcSalUnPrc, this._fracProcUnitSalUnPrc, this._fracProcSalUnPrc, this._salesUnPrcTaxIncFl, this._salesUnPrcTaxExcFl, this._salesUnPrcChngCd, this._costRate, this._rateSectCstUnPrc, this._rateDivUnCst, this._unPrcCalcCdUnCst, this._priceCdUnCst, this._stdUnPrcUnCst, this._fracProcUnitUnCst, this._fracProcUnCst, this._salesUnitCost, this._salesUnitCostChngDiv, this._rateBLGoodsCode, this._rateBLGoodsName, this._rateGoodsRateGrpCd, this._rateGoodsRateGrpNm, this._rateBLGroupCode, this._rateBLGroupName, this._prtBLGoodsCode, this._prtBLGoodsName, this._salesCode, this._salesCdNm, this._workManHour, this._shipmentCnt, this._acceptAnOrderCnt, this._acptAnOdrAdjustCnt, this._acptAnOdrRemainCnt, this._remainCntUpdDate, this._salesMoneyTaxInc, this._salesMoneyTaxExc, this._cost, this._grsProfitChkDiv, this._salesGoodsCd, this._salesPriceConsTax, this._taxationDivCd, this._partySlipNumDtl, this._dtlNote, this._supplierCd, this._supplierSnm, this._orderNumber, this._wayToOrder, this._slipMemo1, this._slipMemo2, this._slipMemo3, this._insideMemo1, this._insideMemo2, this._insideMemo3, this._bfListPrice, this._bfSalesUnitPrice, this._bfUnitCost, this._cmpltSalesRowNo, this._cmpltGoodsMakerCd, this._cmpltMakerName, this._cmpltMakerKanaName, this._cmpltGoodsName, this._cmpltShipmentCnt, this._cmpltSalesUnPrcFl, this._cmpltSalesMoney, this._cmpltSalesUnitCost, this._cmpltCost, this._cmpltPartySalSlNum, this._cmpltNote, this._selectedGoodsNoDiv, this._prtGoodsNo, this._prtMakerCode, this._prtMakerName, this._dtlRelationGuid, this._carRelationGuid, this._shipmentCntDefault, this._shipmentCntDefForChk, this._acceptAnOrderCntDefault, this._acceptAnOrderCntDefForChk, this._salesUnPrcTaxIncFlDefault, this._salesUnPrcTaxExcFlDefault, this._salesUnitCostTaxIncDefault, this._salesUnitCostTacExcDefault, this._campaignCode, this._campaignName, this._goodsDivCd, this._answerDelivDate, this._recycleDiv, this._recycleDivNm, this._wayToAcptOdr, this._goodsMngNo, this._inqRowNumber, this._inqRowNumDerivedNo, this._enterpriseName, this._updEmployeeName, this._bLGoodsName, this._editStatus, this._rowStatus, this._salesMoneyInputDiv, this._shipmentCntDisplay, this._supplierStockDisplay, this._listPriceDisplay, this._stockDate, this._boCode, this._supplierCdForOrder, this._supplierSnmForOrder, this._autoAnswerDivSCM, this._acceptOrOrderKind, this._inquiryNumber);// add 2011/07/18 朱宝軍
            //>>>2012/05/02
            //return new SalesDetail(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._acceptAnOrderNo, this._acptAnOdrStatus, this._salesSlipNum, this._salesRowNo, this._salesRowDerivNo, this._sectionCode, this._subSectionCode, this._salesDate, this._commonSeqNo, this._salesSlipDtlNum, this._acptAnOdrStatusSrc, this._salesSlipDtlNumSrc, this._supplierFormalSync, this._stockSlipDtlNumSync, this._salesSlipCdDtl, this._deliGdsCmpltDueDate, this._goodsKindCode, this._goodsSearchDivCd, this._goodsMakerCd, this._makerName, this._makerKanaName, this._goodsNo, this._goodsName, this._goodsNameKana, this._goodsLGroup, this._goodsLGroupName, this._goodsMGroup, this._goodsMGroupName, this._bLGroupCode, this._bLGroupName, this._bLGoodsCode, this._bLGoodsFullName, this._enterpriseGanreCode, this._enterpriseGanreName, this._warehouseCode, this._warehouseName, this._warehouseShelfNo, this._salesOrderDivCd, this._openPriceDiv, this._goodsRateRank, this._custRateGrpCode, this._listPriceRate, this._rateSectPriceUnPrc, this._rateDivLPrice, this._unPrcCalcCdLPrice, this._priceCdLPrice, this._stdUnPrcLPrice, this._fracProcUnitLPrice, this._fracProcLPrice, this._listPriceTaxIncFl, this._listPriceTaxExcFl, this._listPriceChngCd, this._salesRate, this._rateSectSalUnPrc, this._rateDivSalUnPrc, this._unPrcCalcCdSalUnPrc, this._priceCdSalUnPrc, this._stdUnPrcSalUnPrc, this._fracProcUnitSalUnPrc, this._fracProcSalUnPrc, this._salesUnPrcTaxIncFl, this._salesUnPrcTaxExcFl, this._salesUnPrcChngCd, this._costRate, this._rateSectCstUnPrc, this._rateDivUnCst, this._unPrcCalcCdUnCst, this._priceCdUnCst, this._stdUnPrcUnCst, this._fracProcUnitUnCst, this._fracProcUnCst, this._salesUnitCost, this._salesUnitCostChngDiv, this._rateBLGoodsCode, this._rateBLGoodsName, this._rateGoodsRateGrpCd, this._rateGoodsRateGrpNm, this._rateBLGroupCode, this._rateBLGroupName, this._prtBLGoodsCode, this._prtBLGoodsName, this._salesCode, this._salesCdNm, this._workManHour, this._shipmentCnt, this._acceptAnOrderCnt, this._acptAnOdrAdjustCnt, this._acptAnOdrRemainCnt, this._remainCntUpdDate, this._salesMoneyTaxInc, this._salesMoneyTaxExc, this._cost, this._grsProfitChkDiv, this._salesGoodsCd, this._salesPriceConsTax, this._taxationDivCd, this._partySlipNumDtl, this._dtlNote, this._supplierCd, this._supplierSnm, this._orderNumber, this._wayToOrder, this._slipMemo1, this._slipMemo2, this._slipMemo3, this._insideMemo1, this._insideMemo2, this._insideMemo3, this._bfListPrice, this._bfSalesUnitPrice, this._bfUnitCost, this._cmpltSalesRowNo, this._cmpltGoodsMakerCd, this._cmpltMakerName, this._cmpltMakerKanaName, this._cmpltGoodsName, this._cmpltShipmentCnt, this._cmpltSalesUnPrcFl, this._cmpltSalesMoney, this._cmpltSalesUnitCost, this._cmpltCost, this._cmpltPartySalSlNum, this._cmpltNote, this._selectedGoodsNoDiv, this._prtGoodsNo, this._prtMakerCode, this._prtMakerName, this._dtlRelationGuid, this._carRelationGuid, this._shipmentCntDefault, this._shipmentCntDefForChk, this._acceptAnOrderCntDefault, this._acceptAnOrderCntDefForChk, this._salesUnPrcTaxIncFlDefault, this._salesUnPrcTaxExcFlDefault, this._salesUnitCostTaxIncDefault, this._salesUnitCostTacExcDefault, this._campaignCode, this._campaignName, this._goodsDivCd, this._answerDelivDate, this._recycleDiv, this._recycleDivNm, this._wayToAcptOdr, this._goodsMngNo, this._inqRowNumber, this._inqRowNumDerivedNo, this._enterpriseName, this._updEmployeeName, this._bLGoodsName, this._editStatus, this._rowStatus, this._salesMoneyInputDiv, this._shipmentCntDisplay, this._supplierStockDisplay, this._listPriceDisplay, this._stockDate, this._boCode, this._supplierCdForOrder, this._supplierSnmForOrder, this._autoAnswerDivSCM, this._acceptOrOrderKind, this._inquiryNumber, this._goodsSpecialNote);
            //return new SalesDetail(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._acceptAnOrderNo, this._acptAnOdrStatus, this._salesSlipNum, this._salesRowNo, this._salesRowDerivNo, this._sectionCode, this._subSectionCode, this._salesDate, this._commonSeqNo, this._salesSlipDtlNum, this._acptAnOdrStatusSrc, this._salesSlipDtlNumSrc, this._supplierFormalSync, this._stockSlipDtlNumSync, this._salesSlipCdDtl, this._deliGdsCmpltDueDate, this._goodsKindCode, this._goodsSearchDivCd, this._goodsMakerCd, this._makerName, this._makerKanaName, this._goodsNo, this._goodsName, this._goodsNameKana, this._goodsLGroup, this._goodsLGroupName, this._goodsMGroup, this._goodsMGroupName, this._bLGroupCode, this._bLGroupName, this._bLGoodsCode, this._bLGoodsFullName, this._enterpriseGanreCode, this._enterpriseGanreName, this._warehouseCode, this._warehouseName, this._warehouseShelfNo, this._salesOrderDivCd, this._openPriceDiv, this._goodsRateRank, this._custRateGrpCode, this._listPriceRate, this._rateSectPriceUnPrc, this._rateDivLPrice, this._unPrcCalcCdLPrice, this._priceCdLPrice, this._stdUnPrcLPrice, this._fracProcUnitLPrice, this._fracProcLPrice, this._listPriceTaxIncFl, this._listPriceTaxExcFl, this._listPriceChngCd, this._salesRate, this._rateSectSalUnPrc, this._rateDivSalUnPrc, this._unPrcCalcCdSalUnPrc, this._priceCdSalUnPrc, this._stdUnPrcSalUnPrc, this._fracProcUnitSalUnPrc, this._fracProcSalUnPrc, this._salesUnPrcTaxIncFl, this._salesUnPrcTaxExcFl, this._salesUnPrcChngCd, this._costRate, this._rateSectCstUnPrc, this._rateDivUnCst, this._unPrcCalcCdUnCst, this._priceCdUnCst, this._stdUnPrcUnCst, this._fracProcUnitUnCst, this._fracProcUnCst, this._salesUnitCost, this._salesUnitCostChngDiv, this._rateBLGoodsCode, this._rateBLGoodsName, this._rateGoodsRateGrpCd, this._rateGoodsRateGrpNm, this._rateBLGroupCode, this._rateBLGroupName, this._prtBLGoodsCode, this._prtBLGoodsName, this._salesCode, this._salesCdNm, this._workManHour, this._shipmentCnt, this._acceptAnOrderCnt, this._acptAnOdrAdjustCnt, this._acptAnOdrRemainCnt, this._remainCntUpdDate, this._salesMoneyTaxInc, this._salesMoneyTaxExc, this._cost, this._grsProfitChkDiv, this._salesGoodsCd, this._salesPriceConsTax, this._taxationDivCd, this._partySlipNumDtl, this._dtlNote, this._supplierCd, this._supplierSnm, this._orderNumber, this._wayToOrder, this._slipMemo1, this._slipMemo2, this._slipMemo3, this._insideMemo1, this._insideMemo2, this._insideMemo3, this._bfListPrice, this._bfSalesUnitPrice, this._bfUnitCost, this._cmpltSalesRowNo, this._cmpltGoodsMakerCd, this._cmpltMakerName, this._cmpltMakerKanaName, this._cmpltGoodsName, this._cmpltShipmentCnt, this._cmpltSalesUnPrcFl, this._cmpltSalesMoney, this._cmpltSalesUnitCost, this._cmpltCost, this._cmpltPartySalSlNum, this._cmpltNote, this._selectedGoodsNoDiv, this._prtGoodsNo, this._prtMakerCode, this._prtMakerName, this._dtlRelationGuid, this._carRelationGuid, this._shipmentCntDefault, this._shipmentCntDefForChk, this._acceptAnOrderCntDefault, this._acceptAnOrderCntDefForChk, this._salesUnPrcTaxIncFlDefault, this._salesUnPrcTaxExcFlDefault, this._salesUnitCostTaxIncDefault, this._salesUnitCostTacExcDefault, this._campaignCode, this._campaignName, this._goodsDivCd, this._answerDelivDate, this._recycleDiv, this._recycleDivNm, this._wayToAcptOdr, this._goodsMngNo, this._inqRowNumber, this._inqRowNumDerivedNo, this._enterpriseName, this._updEmployeeName, this._bLGoodsName, this._editStatus, this._rowStatus, this._salesMoneyInputDiv, this._shipmentCntDisplay, this._supplierStockDisplay, this._listPriceDisplay, this._stockDate, this._boCode, this._supplierCdForOrder, this._supplierSnmForOrder, this._autoAnswerDivSCM, this._acceptOrOrderKind, this._inquiryNumber, this._goodsSpecialNote, this._rentSyncSupplier, this._rentSyncStockDate, this._rentSyncSupSlipNo);// DEL 2013/01/24 鄧潘ハン REDMINE#34605
            return new SalesDetail(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._acceptAnOrderNo, this._acptAnOdrStatus, this._salesSlipNum, this._salesRowNo, this._salesRowDerivNo, this._sectionCode, this._subSectionCode, this._salesDate, this._commonSeqNo, this._salesSlipDtlNum, this._acptAnOdrStatusSrc, this._salesSlipDtlNumSrc, this._supplierFormalSync, this._stockSlipDtlNumSync, this._salesSlipCdDtl, this._deliGdsCmpltDueDate, this._goodsKindCode, this._goodsSearchDivCd, this._goodsMakerCd, this._makerName, this._makerKanaName, this._goodsNo, this._goodsName, this._goodsNameKana, this._goodsLGroup, this._goodsLGroupName, this._goodsMGroup, this._goodsMGroupName, this._bLGroupCode, this._bLGroupName, this._bLGoodsCode, this._bLGoodsFullName, this._enterpriseGanreCode, this._enterpriseGanreName, this._warehouseCode, this._warehouseName, this._warehouseShelfNo, this._salesOrderDivCd, this._openPriceDiv, this._goodsRateRank, this._custRateGrpCode, this._listPriceRate, this._rateSectPriceUnPrc, this._rateDivLPrice, this._unPrcCalcCdLPrice, this._priceCdLPrice, this._stdUnPrcLPrice, this._fracProcUnitLPrice, this._fracProcLPrice, this._listPriceTaxIncFl, this._listPriceTaxExcFl, this._listPriceChngCd, this._salesRate, this._rateSectSalUnPrc, this._rateDivSalUnPrc, this._unPrcCalcCdSalUnPrc, this._priceCdSalUnPrc, this._stdUnPrcSalUnPrc, this._fracProcUnitSalUnPrc, this._fracProcSalUnPrc, this._salesUnPrcTaxIncFl, this._salesUnPrcTaxExcFl, this._salesUnPrcChngCd, this._costRate, this._rateSectCstUnPrc, this._rateDivUnCst, this._unPrcCalcCdUnCst, this._priceCdUnCst, this._stdUnPrcUnCst, this._fracProcUnitUnCst, this._fracProcUnCst, this._salesUnitCost, this._salesUnitCostChngDiv, this._rateBLGoodsCode, this._rateBLGoodsName, this._rateGoodsRateGrpCd, this._rateGoodsRateGrpNm, this._rateBLGroupCode, this._rateBLGroupName, this._prtBLGoodsCode, this._prtBLGoodsName, this._salesCode, this._salesCdNm, this._workManHour, this._shipmentCnt, this._acceptAnOrderCnt, this._acptAnOdrAdjustCnt, this._acptAnOdrRemainCnt, this._remainCntUpdDate, this._salesMoneyTaxInc, this._salesMoneyTaxExc, this._cost, this._grsProfitChkDiv, this._salesGoodsCd, this._salesPriceConsTax, this._taxationDivCd, this._partySlipNumDtl, this._dtlNote, this._supplierCd, this._supplierSnm, this._orderNumber, this._wayToOrder, this._slipMemo1, this._slipMemo2, this._slipMemo3, this._insideMemo1, this._insideMemo2, this._insideMemo3, this._bfListPrice, this._bfSalesUnitPrice, this._bfUnitCost, this._cmpltSalesRowNo, this._cmpltGoodsMakerCd, this._cmpltMakerName, this._cmpltMakerKanaName, this._cmpltGoodsName, this._cmpltShipmentCnt, this._cmpltSalesUnPrcFl, this._cmpltSalesMoney, this._cmpltSalesUnitCost, this._cmpltCost, this._cmpltPartySalSlNum, this._cmpltNote, this._selectedGoodsNoDiv, this._prtGoodsNo, this._prtMakerCode, this._prtMakerName, this._dtlRelationGuid, this._carRelationGuid, this._shipmentCntDefault, this._shipmentCntDefForChk, this._acceptAnOrderCntDefault, this._acceptAnOrderCntDefForChk, this._salesUnPrcTaxIncFlDefault, this._salesUnPrcTaxExcFlDefault, this._salesUnitCostTaxIncDefault, this._salesUnitCostTacExcDefault, this._campaignCode, this._campaignName, this._goodsDivCd, this._answerDelivDate, this._recycleDiv, this._recycleDivNm, this._wayToAcptOdr, this._goodsMngNo, this._inqRowNumber, this._inqRowNumDerivedNo, this._enterpriseName, this._updEmployeeName, this._bLGoodsName, this._editStatus, this._rowStatus, this._salesMoneyInputDiv, this._shipmentCntDisplay, this._supplierStockDisplay, this._listPriceDisplay, this._stockDate, this._boCode, this._supplierCdForOrder, this._supplierSnmForOrder, this._autoAnswerDivSCM, this._acceptOrOrderKind, this._inquiryNumber, this._goodsSpecialNote, this._rentSyncSupplier, this._rentSyncStockDate, this._rentSyncSupSlipNo, this._priceSelectDiv);// ADD 2013/01/24 鄧潘ハン REDMINE#34605
            //<<<2012/05/02
            // 2012/01/16 Add <<<
        }

        /// <summary>
        /// 売上明細データ比較処理
        /// </summary>
        /// <param name="target">比較対象のSalesDetailクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SalesDetailクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool Equals(SalesDetail target)
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
                 && (this.SalesSlipNum == target.SalesSlipNum)
                 && (this.SalesRowNo == target.SalesRowNo)
                 && (this.SalesRowDerivNo == target.SalesRowDerivNo)
                 && (this.SectionCode == target.SectionCode)
                 && (this.SubSectionCode == target.SubSectionCode)
                 && (this.SalesDate == target.SalesDate)
                 && (this.CommonSeqNo == target.CommonSeqNo)
                 && (this.SalesSlipDtlNum == target.SalesSlipDtlNum)
                 && (this.AcptAnOdrStatusSrc == target.AcptAnOdrStatusSrc)
                 && (this.SalesSlipDtlNumSrc == target.SalesSlipDtlNumSrc)
                 && (this.SupplierFormalSync == target.SupplierFormalSync)
                 && (this.StockSlipDtlNumSync == target.StockSlipDtlNumSync)
                 && (this.SalesSlipCdDtl == target.SalesSlipCdDtl)
                 && (this.DeliGdsCmpltDueDate == target.DeliGdsCmpltDueDate)
                 && (this.GoodsKindCode == target.GoodsKindCode)
                 && (this.GoodsSearchDivCd == target.GoodsSearchDivCd)
                 && (this.GoodsMakerCd == target.GoodsMakerCd)
                 && (this.MakerName == target.MakerName)
                 && (this.MakerKanaName == target.MakerKanaName)
                 && (this.GoodsNo == target.GoodsNo)
                 && (this.GoodsName == target.GoodsName)
                 && (this.GoodsNameKana == target.GoodsNameKana)
                 && (this.GoodsLGroup == target.GoodsLGroup)
                 && (this.GoodsLGroupName == target.GoodsLGroupName)
                 && (this.GoodsMGroup == target.GoodsMGroup)
                 && (this.GoodsMGroupName == target.GoodsMGroupName)
                 && (this.BLGroupCode == target.BLGroupCode)
                 && (this.BLGroupName == target.BLGroupName)
                 && (this.BLGoodsCode == target.BLGoodsCode)
                 && (this.BLGoodsFullName == target.BLGoodsFullName)
                 && (this.EnterpriseGanreCode == target.EnterpriseGanreCode)
                 && (this.EnterpriseGanreName == target.EnterpriseGanreName)
                 && (this.WarehouseCode == target.WarehouseCode)
                 && (this.WarehouseName == target.WarehouseName)
                 && (this.WarehouseShelfNo == target.WarehouseShelfNo)
                 && (this.SalesOrderDivCd == target.SalesOrderDivCd)
                 && (this.OpenPriceDiv == target.OpenPriceDiv)
                 && (this.GoodsRateRank == target.GoodsRateRank)
                 && (this.CustRateGrpCode == target.CustRateGrpCode)
                 && (this.ListPriceRate == target.ListPriceRate)
                 && (this.RateSectPriceUnPrc == target.RateSectPriceUnPrc)
                 && (this.RateDivLPrice == target.RateDivLPrice)
                 && (this.UnPrcCalcCdLPrice == target.UnPrcCalcCdLPrice)
                 && (this.PriceCdLPrice == target.PriceCdLPrice)
                 && (this.StdUnPrcLPrice == target.StdUnPrcLPrice)
                 && (this.FracProcUnitLPrice == target.FracProcUnitLPrice)
                 && (this.FracProcLPrice == target.FracProcLPrice)
                 && (this.ListPriceTaxIncFl == target.ListPriceTaxIncFl)
                 && (this.ListPriceTaxExcFl == target.ListPriceTaxExcFl)
                 && (this.ListPriceChngCd == target.ListPriceChngCd)
                 && (this.SalesRate == target.SalesRate)
                 && (this.RateSectSalUnPrc == target.RateSectSalUnPrc)
                 && (this.RateDivSalUnPrc == target.RateDivSalUnPrc)
                 && (this.UnPrcCalcCdSalUnPrc == target.UnPrcCalcCdSalUnPrc)
                 && (this.PriceCdSalUnPrc == target.PriceCdSalUnPrc)
                 && (this.StdUnPrcSalUnPrc == target.StdUnPrcSalUnPrc)
                 && (this.FracProcUnitSalUnPrc == target.FracProcUnitSalUnPrc)
                 && (this.FracProcSalUnPrc == target.FracProcSalUnPrc)
                 && (this.SalesUnPrcTaxIncFl == target.SalesUnPrcTaxIncFl)
                 && (this.SalesUnPrcTaxExcFl == target.SalesUnPrcTaxExcFl)
                 && (this.SalesUnPrcChngCd == target.SalesUnPrcChngCd)
                 && (this.CostRate == target.CostRate)
                 && (this.RateSectCstUnPrc == target.RateSectCstUnPrc)
                 && (this.RateDivUnCst == target.RateDivUnCst)
                 && (this.UnPrcCalcCdUnCst == target.UnPrcCalcCdUnCst)
                 && (this.PriceCdUnCst == target.PriceCdUnCst)
                 && (this.StdUnPrcUnCst == target.StdUnPrcUnCst)
                 && (this.FracProcUnitUnCst == target.FracProcUnitUnCst)
                 && (this.FracProcUnCst == target.FracProcUnCst)
                 && (this.SalesUnitCost == target.SalesUnitCost)
                 && (this.SalesUnitCostChngDiv == target.SalesUnitCostChngDiv)
                 && (this.RateBLGoodsCode == target.RateBLGoodsCode)
                 && (this.RateBLGoodsName == target.RateBLGoodsName)
                 && (this.RateGoodsRateGrpCd == target.RateGoodsRateGrpCd)
                 && (this.RateGoodsRateGrpNm == target.RateGoodsRateGrpNm)
                 && (this.RateBLGroupCode == target.RateBLGroupCode)
                 && (this.RateBLGroupName == target.RateBLGroupName)
                 && (this.PrtBLGoodsCode == target.PrtBLGoodsCode)
                 && (this.PrtBLGoodsName == target.PrtBLGoodsName)
                 && (this.SalesCode == target.SalesCode)
                 && (this.SalesCdNm == target.SalesCdNm)
                 && (this.WorkManHour == target.WorkManHour)
                 && (this.ShipmentCnt == target.ShipmentCnt)
                 && (this.AcceptAnOrderCnt == target.AcceptAnOrderCnt)
                 && (this.AcptAnOdrAdjustCnt == target.AcptAnOdrAdjustCnt)
                 && (this.AcptAnOdrRemainCnt == target.AcptAnOdrRemainCnt)
                 && (this.RemainCntUpdDate == target.RemainCntUpdDate)
                 && (this.SalesMoneyTaxInc == target.SalesMoneyTaxInc)
                 && (this.SalesMoneyTaxExc == target.SalesMoneyTaxExc)
                 && (this.Cost == target.Cost)
                 && (this.GrsProfitChkDiv == target.GrsProfitChkDiv)
                 && (this.SalesGoodsCd == target.SalesGoodsCd)
                 && (this.SalesPriceConsTax == target.SalesPriceConsTax)
                 && (this.TaxationDivCd == target.TaxationDivCd)
                 && (this.PartySlipNumDtl == target.PartySlipNumDtl)
                 && (this.DtlNote == target.DtlNote)
                 && (this.SupplierCd == target.SupplierCd)
                 && (this.SupplierSnm == target.SupplierSnm)
                 && (this.OrderNumber == target.OrderNumber)
                 && (this.WayToOrder == target.WayToOrder)
                 && (this.SlipMemo1 == target.SlipMemo1)
                 && (this.SlipMemo2 == target.SlipMemo2)
                 && (this.SlipMemo3 == target.SlipMemo3)
                 && (this.InsideMemo1 == target.InsideMemo1)
                 && (this.InsideMemo2 == target.InsideMemo2)
                 && (this.InsideMemo3 == target.InsideMemo3)
                 && (this.BfListPrice == target.BfListPrice)
                 && (this.BfSalesUnitPrice == target.BfSalesUnitPrice)
                 && (this.BfUnitCost == target.BfUnitCost)
                 && (this.CmpltSalesRowNo == target.CmpltSalesRowNo)
                 && (this.CmpltGoodsMakerCd == target.CmpltGoodsMakerCd)
                 && (this.CmpltMakerName == target.CmpltMakerName)
                 && (this.CmpltMakerKanaName == target.CmpltMakerKanaName)
                 && (this.CmpltGoodsName == target.CmpltGoodsName)
                 && (this.CmpltShipmentCnt == target.CmpltShipmentCnt)
                 && (this.CmpltSalesUnPrcFl == target.CmpltSalesUnPrcFl)
                 && (this.CmpltSalesMoney == target.CmpltSalesMoney)
                 && (this.CmpltSalesUnitCost == target.CmpltSalesUnitCost)
                 && (this.CmpltCost == target.CmpltCost)
                 && (this.CmpltPartySalSlNum == target.CmpltPartySalSlNum)
                 && (this.CmpltNote == target.CmpltNote)
                 // --- ADD 2009/10/19 ---------->>>>>
                 && (this.SelectedGoodsNoDiv == target.SelectedGoodsNoDiv)
                 // --- ADD 2009/10/19 ----------<<<<<
                 && (this.PrtGoodsNo == target.PrtGoodsNo)
                 && (this.PrtMakerCode == target.PrtMakerCode)
                 && (this.PrtMakerName == target.PrtMakerName)
                 && (this.DtlRelationGuid == target.DtlRelationGuid)
                 && (this.CarRelationGuid == target.CarRelationGuid)
                 && (this.ShipmentCntDefault == target.ShipmentCntDefault)
                 && (this.ShipmentCntDefForChk == target.ShipmentCntDefForChk)
                 && (this.AcceptAnOrderCntDefault == target.AcceptAnOrderCntDefault)
                 && (this.AcceptAnOrderCntDefForChk == target.AcceptAnOrderCntDefForChk)
                 && (this.SalesUnPrcTaxIncFlDefault == target.SalesUnPrcTaxIncFlDefault)
                 && (this.SalesUnPrcTaxExcFlDefault == target.SalesUnPrcTaxExcFlDefault)
                 && (this.SalesUnitCostTaxIncDefault == target.SalesUnitCostTaxIncDefault)
                 && (this.SalesUnitCostTacExcDefault == target.SalesUnitCostTacExcDefault)
                //>>>2010/02/26
                 && (this.CampaignCode == target.CampaignCode)
                 && (this.CampaignName == target.CampaignName)
                 && (this.GoodsDivCd == target.GoodsDivCd)
                 && (this.AnswerDelivDate == target.AnswerDelivDate)
                 && (this.RecycleDiv == target.RecycleDiv)
                 && (this.RecycleDivNm == target.RecycleDivNm)
                 && (this.WayToAcptOdr == target.WayToAcptOdr)
                 && (this.GoodsMngNo == target.GoodsMngNo)
                 && (this.InqRowNumber == target.InqRowNumber)
                 && (this.InqRowNumDerivedNo == target.InqRowNumDerivedNo)
                //<<<2010/02/26
                 && (this.EnterpriseName == target.EnterpriseName)
                 && (this.UpdEmployeeName == target.UpdEmployeeName)
                 && (this.BLGoodsName == target.BLGoodsName)
                 && (this.EditStatus == target.EditStatus)//ADD 2010/04/06
                 && (this.RowStatus == target.RowStatus)//ADD 2010/04/06
                 && (this.SalesMoneyInputDiv == target.SalesMoneyInputDiv)//ADD 2010/04/06
                 && (this.ShipmentCntDisplay == target.ShipmentCntDisplay)//ADD 2010/04/06
                 && (this.SupplierStockDisplay == target.SupplierStockDisplay)//ADD 2010/04/06
                 && (this.StockDate == target.StockDate)//ADD 2010/04/06
                 && (this.BoCode == target.BoCode)//ADD 2010/04/06
                 && (this.SupplierCdForOrder == target.SupplierCdForOrder)//ADD 2010/04/06
                 && (this.SupplierSnmForOrder == target.SupplierSnmForOrder)//ADD 2010/04/06
                 && (this.AutoAnswerDivSCM == target.AutoAnswerDivSCM)//ADD 2011/07/18 朱宝軍
                 //>>>2012/05/02
                 && (this.RentSyncStockDate == target.RentSyncStockDate)
                 && (this.RentSyncSupplier == target.RentSyncSupplier)
                 && (this.RentSyncSupSlipNo == target.RentSyncSupSlipNo)
                 //<<<2012/05/02
                 && (this.ListPriceDisplay == target.ListPriceDisplay)//ADD 2010/04/06
                 && (this.PriceSelectDiv == target.PriceSelectDiv));// ADD 2013/01/24 鄧潘ハン REDMINE#34605
        }

        /// <summary>
        /// 売上明細データ比較処理
        /// </summary>
        /// <param name="salesDetail1">
        ///                    比較するSalesDetailクラスのインスタンス
        /// </param>
        /// <param name="salesDetail2">比較するSalesDetailクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SalesDetailクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static bool Equals(SalesDetail salesDetail1, SalesDetail salesDetail2)
        {
            return ((salesDetail1.CreateDateTime == salesDetail2.CreateDateTime)
                 && (salesDetail1.UpdateDateTime == salesDetail2.UpdateDateTime)
                 && (salesDetail1.EnterpriseCode == salesDetail2.EnterpriseCode)
                 && (salesDetail1.FileHeaderGuid == salesDetail2.FileHeaderGuid)
                 && (salesDetail1.UpdEmployeeCode == salesDetail2.UpdEmployeeCode)
                 && (salesDetail1.UpdAssemblyId1 == salesDetail2.UpdAssemblyId1)
                 && (salesDetail1.UpdAssemblyId2 == salesDetail2.UpdAssemblyId2)
                 && (salesDetail1.LogicalDeleteCode == salesDetail2.LogicalDeleteCode)
                 && (salesDetail1.AcceptAnOrderNo == salesDetail2.AcceptAnOrderNo)
                 && (salesDetail1.AcptAnOdrStatus == salesDetail2.AcptAnOdrStatus)
                 && (salesDetail1.SalesSlipNum == salesDetail2.SalesSlipNum)
                 && (salesDetail1.SalesRowNo == salesDetail2.SalesRowNo)
                 && (salesDetail1.SalesRowDerivNo == salesDetail2.SalesRowDerivNo)
                 && (salesDetail1.SectionCode == salesDetail2.SectionCode)
                 && (salesDetail1.SubSectionCode == salesDetail2.SubSectionCode)
                 && (salesDetail1.SalesDate == salesDetail2.SalesDate)
                 && (salesDetail1.CommonSeqNo == salesDetail2.CommonSeqNo)
                 && (salesDetail1.SalesSlipDtlNum == salesDetail2.SalesSlipDtlNum)
                 && (salesDetail1.AcptAnOdrStatusSrc == salesDetail2.AcptAnOdrStatusSrc)
                 && (salesDetail1.SalesSlipDtlNumSrc == salesDetail2.SalesSlipDtlNumSrc)
                 && (salesDetail1.SupplierFormalSync == salesDetail2.SupplierFormalSync)
                 && (salesDetail1.StockSlipDtlNumSync == salesDetail2.StockSlipDtlNumSync)
                 && (salesDetail1.SalesSlipCdDtl == salesDetail2.SalesSlipCdDtl)
                 && (salesDetail1.DeliGdsCmpltDueDate == salesDetail2.DeliGdsCmpltDueDate)
                 && (salesDetail1.GoodsKindCode == salesDetail2.GoodsKindCode)
                 && (salesDetail1.GoodsSearchDivCd == salesDetail2.GoodsSearchDivCd)
                 && (salesDetail1.GoodsMakerCd == salesDetail2.GoodsMakerCd)
                 && (salesDetail1.MakerName == salesDetail2.MakerName)
                 && (salesDetail1.MakerKanaName == salesDetail2.MakerKanaName)
                 && (salesDetail1.GoodsNo == salesDetail2.GoodsNo)
                 && (salesDetail1.GoodsName == salesDetail2.GoodsName)
                 && (salesDetail1.GoodsNameKana == salesDetail2.GoodsNameKana)
                 && (salesDetail1.GoodsLGroup == salesDetail2.GoodsLGroup)
                 && (salesDetail1.GoodsLGroupName == salesDetail2.GoodsLGroupName)
                 && (salesDetail1.GoodsMGroup == salesDetail2.GoodsMGroup)
                 && (salesDetail1.GoodsMGroupName == salesDetail2.GoodsMGroupName)
                 && (salesDetail1.BLGroupCode == salesDetail2.BLGroupCode)
                 && (salesDetail1.BLGroupName == salesDetail2.BLGroupName)
                 && (salesDetail1.BLGoodsCode == salesDetail2.BLGoodsCode)
                 && (salesDetail1.BLGoodsFullName == salesDetail2.BLGoodsFullName)
                 && (salesDetail1.EnterpriseGanreCode == salesDetail2.EnterpriseGanreCode)
                 && (salesDetail1.EnterpriseGanreName == salesDetail2.EnterpriseGanreName)
                 && (salesDetail1.WarehouseCode == salesDetail2.WarehouseCode)
                 && (salesDetail1.WarehouseName == salesDetail2.WarehouseName)
                 && (salesDetail1.WarehouseShelfNo == salesDetail2.WarehouseShelfNo)
                 && (salesDetail1.SalesOrderDivCd == salesDetail2.SalesOrderDivCd)
                 && (salesDetail1.OpenPriceDiv == salesDetail2.OpenPriceDiv)
                 && (salesDetail1.GoodsRateRank == salesDetail2.GoodsRateRank)
                 && (salesDetail1.CustRateGrpCode == salesDetail2.CustRateGrpCode)
                 && (salesDetail1.ListPriceRate == salesDetail2.ListPriceRate)
                 && (salesDetail1.RateSectPriceUnPrc == salesDetail2.RateSectPriceUnPrc)
                 && (salesDetail1.RateDivLPrice == salesDetail2.RateDivLPrice)
                 && (salesDetail1.UnPrcCalcCdLPrice == salesDetail2.UnPrcCalcCdLPrice)
                 && (salesDetail1.PriceCdLPrice == salesDetail2.PriceCdLPrice)
                 && (salesDetail1.StdUnPrcLPrice == salesDetail2.StdUnPrcLPrice)
                 && (salesDetail1.FracProcUnitLPrice == salesDetail2.FracProcUnitLPrice)
                 && (salesDetail1.FracProcLPrice == salesDetail2.FracProcLPrice)
                 && (salesDetail1.ListPriceTaxIncFl == salesDetail2.ListPriceTaxIncFl)
                 && (salesDetail1.ListPriceTaxExcFl == salesDetail2.ListPriceTaxExcFl)
                 && (salesDetail1.ListPriceChngCd == salesDetail2.ListPriceChngCd)
                 && (salesDetail1.SalesRate == salesDetail2.SalesRate)
                 && (salesDetail1.RateSectSalUnPrc == salesDetail2.RateSectSalUnPrc)
                 && (salesDetail1.RateDivSalUnPrc == salesDetail2.RateDivSalUnPrc)
                 && (salesDetail1.UnPrcCalcCdSalUnPrc == salesDetail2.UnPrcCalcCdSalUnPrc)
                 && (salesDetail1.PriceCdSalUnPrc == salesDetail2.PriceCdSalUnPrc)
                 && (salesDetail1.StdUnPrcSalUnPrc == salesDetail2.StdUnPrcSalUnPrc)
                 && (salesDetail1.FracProcUnitSalUnPrc == salesDetail2.FracProcUnitSalUnPrc)
                 && (salesDetail1.FracProcSalUnPrc == salesDetail2.FracProcSalUnPrc)
                 && (salesDetail1.SalesUnPrcTaxIncFl == salesDetail2.SalesUnPrcTaxIncFl)
                 && (salesDetail1.SalesUnPrcTaxExcFl == salesDetail2.SalesUnPrcTaxExcFl)
                 && (salesDetail1.SalesUnPrcChngCd == salesDetail2.SalesUnPrcChngCd)
                 && (salesDetail1.CostRate == salesDetail2.CostRate)
                 && (salesDetail1.RateSectCstUnPrc == salesDetail2.RateSectCstUnPrc)
                 && (salesDetail1.RateDivUnCst == salesDetail2.RateDivUnCst)
                 && (salesDetail1.UnPrcCalcCdUnCst == salesDetail2.UnPrcCalcCdUnCst)
                 && (salesDetail1.PriceCdUnCst == salesDetail2.PriceCdUnCst)
                 && (salesDetail1.StdUnPrcUnCst == salesDetail2.StdUnPrcUnCst)
                 && (salesDetail1.FracProcUnitUnCst == salesDetail2.FracProcUnitUnCst)
                 && (salesDetail1.FracProcUnCst == salesDetail2.FracProcUnCst)
                 && (salesDetail1.SalesUnitCost == salesDetail2.SalesUnitCost)
                 && (salesDetail1.SalesUnitCostChngDiv == salesDetail2.SalesUnitCostChngDiv)
                 && (salesDetail1.RateBLGoodsCode == salesDetail2.RateBLGoodsCode)
                 && (salesDetail1.RateBLGoodsName == salesDetail2.RateBLGoodsName)
                 && (salesDetail1.RateGoodsRateGrpCd == salesDetail2.RateGoodsRateGrpCd)
                 && (salesDetail1.RateGoodsRateGrpNm == salesDetail2.RateGoodsRateGrpNm)
                 && (salesDetail1.RateBLGroupCode == salesDetail2.RateBLGroupCode)
                 && (salesDetail1.RateBLGroupName == salesDetail2.RateBLGroupName)
                 && (salesDetail1.PrtBLGoodsCode == salesDetail2.PrtBLGoodsCode)
                 && (salesDetail1.PrtBLGoodsName == salesDetail2.PrtBLGoodsName)
                 && (salesDetail1.SalesCode == salesDetail2.SalesCode)
                 && (salesDetail1.SalesCdNm == salesDetail2.SalesCdNm)
                 && (salesDetail1.WorkManHour == salesDetail2.WorkManHour)
                 && (salesDetail1.ShipmentCnt == salesDetail2.ShipmentCnt)
                 && (salesDetail1.AcceptAnOrderCnt == salesDetail2.AcceptAnOrderCnt)
                 && (salesDetail1.AcptAnOdrAdjustCnt == salesDetail2.AcptAnOdrAdjustCnt)
                 && (salesDetail1.AcptAnOdrRemainCnt == salesDetail2.AcptAnOdrRemainCnt)
                 && (salesDetail1.RemainCntUpdDate == salesDetail2.RemainCntUpdDate)
                 && (salesDetail1.SalesMoneyTaxInc == salesDetail2.SalesMoneyTaxInc)
                 && (salesDetail1.SalesMoneyTaxExc == salesDetail2.SalesMoneyTaxExc)
                 && (salesDetail1.Cost == salesDetail2.Cost)
                 && (salesDetail1.GrsProfitChkDiv == salesDetail2.GrsProfitChkDiv)
                 && (salesDetail1.SalesGoodsCd == salesDetail2.SalesGoodsCd)
                 && (salesDetail1.SalesPriceConsTax == salesDetail2.SalesPriceConsTax)
                 && (salesDetail1.TaxationDivCd == salesDetail2.TaxationDivCd)
                 && (salesDetail1.PartySlipNumDtl == salesDetail2.PartySlipNumDtl)
                 && (salesDetail1.DtlNote == salesDetail2.DtlNote)
                 && (salesDetail1.SupplierCd == salesDetail2.SupplierCd)
                 && (salesDetail1.SupplierSnm == salesDetail2.SupplierSnm)
                 && (salesDetail1.OrderNumber == salesDetail2.OrderNumber)
                 && (salesDetail1.WayToOrder == salesDetail2.WayToOrder)
                 && (salesDetail1.SlipMemo1 == salesDetail2.SlipMemo1)
                 && (salesDetail1.SlipMemo2 == salesDetail2.SlipMemo2)
                 && (salesDetail1.SlipMemo3 == salesDetail2.SlipMemo3)
                 && (salesDetail1.InsideMemo1 == salesDetail2.InsideMemo1)
                 && (salesDetail1.InsideMemo2 == salesDetail2.InsideMemo2)
                 && (salesDetail1.InsideMemo3 == salesDetail2.InsideMemo3)
                 && (salesDetail1.BfListPrice == salesDetail2.BfListPrice)
                 && (salesDetail1.BfSalesUnitPrice == salesDetail2.BfSalesUnitPrice)
                 && (salesDetail1.BfUnitCost == salesDetail2.BfUnitCost)
                 && (salesDetail1.CmpltSalesRowNo == salesDetail2.CmpltSalesRowNo)
                 && (salesDetail1.CmpltGoodsMakerCd == salesDetail2.CmpltGoodsMakerCd)
                 && (salesDetail1.CmpltMakerName == salesDetail2.CmpltMakerName)
                 && (salesDetail1.CmpltMakerKanaName == salesDetail2.CmpltMakerKanaName)
                 && (salesDetail1.CmpltGoodsName == salesDetail2.CmpltGoodsName)
                 && (salesDetail1.CmpltShipmentCnt == salesDetail2.CmpltShipmentCnt)
                 && (salesDetail1.CmpltSalesUnPrcFl == salesDetail2.CmpltSalesUnPrcFl)
                 && (salesDetail1.CmpltSalesMoney == salesDetail2.CmpltSalesMoney)
                 && (salesDetail1.CmpltSalesUnitCost == salesDetail2.CmpltSalesUnitCost)
                 && (salesDetail1.CmpltCost == salesDetail2.CmpltCost)
                 && (salesDetail1.CmpltPartySalSlNum == salesDetail2.CmpltPartySalSlNum)
                 && (salesDetail1.CmpltNote == salesDetail2.CmpltNote)
                 && (salesDetail1.SelectedGoodsNoDiv == salesDetail2.SelectedGoodsNoDiv)
                 && (salesDetail1.PrtGoodsNo == salesDetail2.PrtGoodsNo)
                 && (salesDetail1.PrtMakerCode == salesDetail2.PrtMakerCode)
                 && (salesDetail1.PrtMakerName == salesDetail2.PrtMakerName)
                 && (salesDetail1.DtlRelationGuid == salesDetail2.DtlRelationGuid)
                 && (salesDetail1.CarRelationGuid == salesDetail2.CarRelationGuid)
                 && (salesDetail1.ShipmentCntDefault == salesDetail2.ShipmentCntDefault)
                 && (salesDetail1.ShipmentCntDefForChk == salesDetail2.ShipmentCntDefForChk)
                 && (salesDetail1.AcceptAnOrderCntDefault == salesDetail2.AcceptAnOrderCntDefault)
                 && (salesDetail1.AcceptAnOrderCntDefForChk == salesDetail2.AcceptAnOrderCntDefForChk)
                 && (salesDetail1.SalesUnPrcTaxIncFlDefault == salesDetail2.SalesUnPrcTaxIncFlDefault)
                 && (salesDetail1.SalesUnPrcTaxExcFlDefault == salesDetail2.SalesUnPrcTaxExcFlDefault)
                 && (salesDetail1.SalesUnitCostTaxIncDefault == salesDetail2.SalesUnitCostTaxIncDefault)
                 && (salesDetail1.SalesUnitCostTacExcDefault == salesDetail2.SalesUnitCostTacExcDefault)
                //>>>2010/02/26
                 && (salesDetail1.CampaignCode == salesDetail2.CampaignCode)
                 && (salesDetail1.CampaignName == salesDetail2.CampaignName)
                 && (salesDetail1.GoodsDivCd == salesDetail2.GoodsDivCd)
                 && (salesDetail1.AnswerDelivDate == salesDetail2.AnswerDelivDate)
                 && (salesDetail1.RecycleDiv == salesDetail2.RecycleDiv)
                 && (salesDetail1.RecycleDivNm == salesDetail2.RecycleDivNm)
                 && (salesDetail1.WayToAcptOdr == salesDetail2.WayToAcptOdr)
                 && (salesDetail1.GoodsMngNo == salesDetail2.GoodsMngNo)
                 && (salesDetail1.InqRowNumber == salesDetail2.InqRowNumber)
                 && (salesDetail1.InqRowNumDerivedNo == salesDetail2.InqRowNumDerivedNo)
                //<<<2010/02/26
                 && (salesDetail1.EnterpriseName == salesDetail2.EnterpriseName)
                 && (salesDetail1.UpdEmployeeName == salesDetail2.UpdEmployeeName)
                 && (salesDetail1.BLGoodsName == salesDetail2.BLGoodsName)
                 && (salesDetail1.EditStatus == salesDetail2.EditStatus)// ADD 2010/04/06
                 && (salesDetail1.RowStatus == salesDetail2.RowStatus)// ADD 2010/04/06 
                 && (salesDetail1.SalesMoneyInputDiv == salesDetail2.SalesMoneyInputDiv)// ADD 2010/04/06
                 && (salesDetail1.ShipmentCntDisplay == salesDetail2.ShipmentCntDisplay)// ADD 2010/04/06
                 && (salesDetail1.SupplierStockDisplay == salesDetail2.SupplierStockDisplay)// ADD 2010/04/06
                 && (salesDetail1.StockDate == salesDetail2.StockDate)// ADD 2010/04/06
                 && (salesDetail1.BoCode == salesDetail2.BoCode)// ADD 2010/04/06
                 && (salesDetail1.SupplierCdForOrder == salesDetail2.SupplierCdForOrder)// ADD 2010/04/06
                 && (salesDetail1.SupplierSnmForOrder == salesDetail2.SupplierSnmForOrder)// ADD 2010/04/06
                 && (salesDetail1.AutoAnswerDivSCM == salesDetail2.AutoAnswerDivSCM)// ADD 2011/07/18 朱宝軍
                 //>>>2012/05/02
                 && (salesDetail1.RentSyncStockDate == salesDetail2.RentSyncStockDate)
                 && (salesDetail1.RentSyncSupplier == salesDetail2.RentSyncSupplier)
                 && (salesDetail1.RentSyncSupSlipNo == salesDetail2.RentSyncSupSlipNo)
                //<<<2012/05/02
                 && (salesDetail1.ListPriceDisplay == salesDetail2.ListPriceDisplay)// ADD 2010/04/06
                 && (salesDetail1.PriceSelectDiv == salesDetail2.PriceSelectDiv));// ADD 2013/01/24 鄧潘ハン REDMINE#34605
        }
        /// <summary>
        /// 売上明細データ比較処理
        /// </summary>
        /// <param name="target">比較対象のSalesDetailクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SalesDetailクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList Compare(SalesDetail target)
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
            if (this.SalesSlipNum != target.SalesSlipNum) resList.Add("SalesSlipNum");
            if (this.SalesRowNo != target.SalesRowNo) resList.Add("SalesRowNo");
            if (this.SalesRowDerivNo != target.SalesRowDerivNo) resList.Add("SalesRowDerivNo");
            if (this.SectionCode != target.SectionCode) resList.Add("SectionCode");
            if (this.SubSectionCode != target.SubSectionCode) resList.Add("SubSectionCode");
            if (this.SalesDate != target.SalesDate) resList.Add("SalesDate");
            if (this.CommonSeqNo != target.CommonSeqNo) resList.Add("CommonSeqNo");
            if (this.SalesSlipDtlNum != target.SalesSlipDtlNum) resList.Add("SalesSlipDtlNum");
            if (this.AcptAnOdrStatusSrc != target.AcptAnOdrStatusSrc) resList.Add("AcptAnOdrStatusSrc");
            if (this.SalesSlipDtlNumSrc != target.SalesSlipDtlNumSrc) resList.Add("SalesSlipDtlNumSrc");
            if (this.SupplierFormalSync != target.SupplierFormalSync) resList.Add("SupplierFormalSync");
            if (this.StockSlipDtlNumSync != target.StockSlipDtlNumSync) resList.Add("StockSlipDtlNumSync");
            if (this.SalesSlipCdDtl != target.SalesSlipCdDtl) resList.Add("SalesSlipCdDtl");
            if (this.DeliGdsCmpltDueDate != target.DeliGdsCmpltDueDate) resList.Add("DeliGdsCmpltDueDate");
            if (this.GoodsKindCode != target.GoodsKindCode) resList.Add("GoodsKindCode");
            if (this.GoodsSearchDivCd != target.GoodsSearchDivCd) resList.Add("GoodsSearchDivCd");
            if (this.GoodsMakerCd != target.GoodsMakerCd) resList.Add("GoodsMakerCd");
            if (this.MakerName != target.MakerName) resList.Add("MakerName");
            if (this.MakerKanaName != target.MakerKanaName) resList.Add("MakerKanaName");
            if (this.GoodsNo != target.GoodsNo) resList.Add("GoodsNo");
            if (this.GoodsName != target.GoodsName) resList.Add("GoodsName");
            if (this.GoodsNameKana != target.GoodsNameKana) resList.Add("GoodsNameKana");
            if (this.GoodsLGroup != target.GoodsLGroup) resList.Add("GoodsLGroup");
            if (this.GoodsLGroupName != target.GoodsLGroupName) resList.Add("GoodsLGroupName");
            if (this.GoodsMGroup != target.GoodsMGroup) resList.Add("GoodsMGroup");
            if (this.GoodsMGroupName != target.GoodsMGroupName) resList.Add("GoodsMGroupName");
            if (this.BLGroupCode != target.BLGroupCode) resList.Add("BLGroupCode");
            if (this.BLGroupName != target.BLGroupName) resList.Add("BLGroupName");
            if (this.BLGoodsCode != target.BLGoodsCode) resList.Add("BLGoodsCode");
            if (this.BLGoodsFullName != target.BLGoodsFullName) resList.Add("BLGoodsFullName");
            if (this.EnterpriseGanreCode != target.EnterpriseGanreCode) resList.Add("EnterpriseGanreCode");
            if (this.EnterpriseGanreName != target.EnterpriseGanreName) resList.Add("EnterpriseGanreName");
            if (this.WarehouseCode != target.WarehouseCode) resList.Add("WarehouseCode");
            if (this.WarehouseName != target.WarehouseName) resList.Add("WarehouseName");
            if (this.WarehouseShelfNo != target.WarehouseShelfNo) resList.Add("WarehouseShelfNo");
            if (this.SalesOrderDivCd != target.SalesOrderDivCd) resList.Add("SalesOrderDivCd");
            if (this.OpenPriceDiv != target.OpenPriceDiv) resList.Add("OpenPriceDiv");
            if (this.GoodsRateRank != target.GoodsRateRank) resList.Add("GoodsRateRank");
            if (this.CustRateGrpCode != target.CustRateGrpCode) resList.Add("CustRateGrpCode");
            if (this.ListPriceRate != target.ListPriceRate) resList.Add("ListPriceRate");
            if (this.RateSectPriceUnPrc != target.RateSectPriceUnPrc) resList.Add("RateSectPriceUnPrc");
            if (this.RateDivLPrice != target.RateDivLPrice) resList.Add("RateDivLPrice");
            if (this.UnPrcCalcCdLPrice != target.UnPrcCalcCdLPrice) resList.Add("UnPrcCalcCdLPrice");
            if (this.PriceCdLPrice != target.PriceCdLPrice) resList.Add("PriceCdLPrice");
            if (this.StdUnPrcLPrice != target.StdUnPrcLPrice) resList.Add("StdUnPrcLPrice");
            if (this.FracProcUnitLPrice != target.FracProcUnitLPrice) resList.Add("FracProcUnitLPrice");
            if (this.FracProcLPrice != target.FracProcLPrice) resList.Add("FracProcLPrice");
            if (this.ListPriceTaxIncFl != target.ListPriceTaxIncFl) resList.Add("ListPriceTaxIncFl");
            if (this.ListPriceTaxExcFl != target.ListPriceTaxExcFl) resList.Add("ListPriceTaxExcFl");
            if (this.ListPriceChngCd != target.ListPriceChngCd) resList.Add("ListPriceChngCd");
            if (this.SalesRate != target.SalesRate) resList.Add("SalesRate");
            if (this.RateSectSalUnPrc != target.RateSectSalUnPrc) resList.Add("RateSectSalUnPrc");
            if (this.RateDivSalUnPrc != target.RateDivSalUnPrc) resList.Add("RateDivSalUnPrc");
            if (this.UnPrcCalcCdSalUnPrc != target.UnPrcCalcCdSalUnPrc) resList.Add("UnPrcCalcCdSalUnPrc");
            if (this.PriceCdSalUnPrc != target.PriceCdSalUnPrc) resList.Add("PriceCdSalUnPrc");
            if (this.StdUnPrcSalUnPrc != target.StdUnPrcSalUnPrc) resList.Add("StdUnPrcSalUnPrc");
            if (this.FracProcUnitSalUnPrc != target.FracProcUnitSalUnPrc) resList.Add("FracProcUnitSalUnPrc");
            if (this.FracProcSalUnPrc != target.FracProcSalUnPrc) resList.Add("FracProcSalUnPrc");
            if (this.SalesUnPrcTaxIncFl != target.SalesUnPrcTaxIncFl) resList.Add("SalesUnPrcTaxIncFl");
            if (this.SalesUnPrcTaxExcFl != target.SalesUnPrcTaxExcFl) resList.Add("SalesUnPrcTaxExcFl");
            if (this.SalesUnPrcChngCd != target.SalesUnPrcChngCd) resList.Add("SalesUnPrcChngCd");
            if (this.CostRate != target.CostRate) resList.Add("CostRate");
            if (this.RateSectCstUnPrc != target.RateSectCstUnPrc) resList.Add("RateSectCstUnPrc");
            if (this.RateDivUnCst != target.RateDivUnCst) resList.Add("RateDivUnCst");
            if (this.UnPrcCalcCdUnCst != target.UnPrcCalcCdUnCst) resList.Add("UnPrcCalcCdUnCst");
            if (this.PriceCdUnCst != target.PriceCdUnCst) resList.Add("PriceCdUnCst");
            if (this.StdUnPrcUnCst != target.StdUnPrcUnCst) resList.Add("StdUnPrcUnCst");
            if (this.FracProcUnitUnCst != target.FracProcUnitUnCst) resList.Add("FracProcUnitUnCst");
            if (this.FracProcUnCst != target.FracProcUnCst) resList.Add("FracProcUnCst");
            if (this.SalesUnitCost != target.SalesUnitCost) resList.Add("SalesUnitCost");
            if (this.SalesUnitCostChngDiv != target.SalesUnitCostChngDiv) resList.Add("SalesUnitCostChngDiv");
            if (this.RateBLGoodsCode != target.RateBLGoodsCode) resList.Add("RateBLGoodsCode");
            if (this.RateBLGoodsName != target.RateBLGoodsName) resList.Add("RateBLGoodsName");
            if (this.RateGoodsRateGrpCd != target.RateGoodsRateGrpCd) resList.Add("RateGoodsRateGrpCd");
            if (this.RateGoodsRateGrpNm != target.RateGoodsRateGrpNm) resList.Add("RateGoodsRateGrpNm");
            if (this.RateBLGroupCode != target.RateBLGroupCode) resList.Add("RateBLGroupCode");
            if (this.RateBLGroupName != target.RateBLGroupName) resList.Add("RateBLGroupName");
            if (this.PrtBLGoodsCode != target.PrtBLGoodsCode) resList.Add("PrtBLGoodsCode");
            if (this.PrtBLGoodsName != target.PrtBLGoodsName) resList.Add("PrtBLGoodsName");
            if (this.SalesCode != target.SalesCode) resList.Add("SalesCode");
            if (this.SalesCdNm != target.SalesCdNm) resList.Add("SalesCdNm");
            if (this.WorkManHour != target.WorkManHour) resList.Add("WorkManHour");
            if (this.ShipmentCnt != target.ShipmentCnt) resList.Add("ShipmentCnt");
            if (this.AcceptAnOrderCnt != target.AcceptAnOrderCnt) resList.Add("AcceptAnOrderCnt");
            if (this.AcptAnOdrAdjustCnt != target.AcptAnOdrAdjustCnt) resList.Add("AcptAnOdrAdjustCnt");
            if (this.AcptAnOdrRemainCnt != target.AcptAnOdrRemainCnt) resList.Add("AcptAnOdrRemainCnt");
            if (this.RemainCntUpdDate != target.RemainCntUpdDate) resList.Add("RemainCntUpdDate");
            if (this.SalesMoneyTaxInc != target.SalesMoneyTaxInc) resList.Add("SalesMoneyTaxInc");
            if (this.SalesMoneyTaxExc != target.SalesMoneyTaxExc) resList.Add("SalesMoneyTaxExc");
            if (this.Cost != target.Cost) resList.Add("Cost");
            if (this.GrsProfitChkDiv != target.GrsProfitChkDiv) resList.Add("GrsProfitChkDiv");
            if (this.SalesGoodsCd != target.SalesGoodsCd) resList.Add("SalesGoodsCd");
            if (this.SalesPriceConsTax != target.SalesPriceConsTax) resList.Add("SalesPriceConsTax");
            if (this.TaxationDivCd != target.TaxationDivCd) resList.Add("TaxationDivCd");
            if (this.PartySlipNumDtl != target.PartySlipNumDtl) resList.Add("PartySlipNumDtl");
            if (this.DtlNote != target.DtlNote) resList.Add("DtlNote");
            if (this.SupplierCd != target.SupplierCd) resList.Add("SupplierCd");
            if (this.SupplierSnm != target.SupplierSnm) resList.Add("SupplierSnm");
            if (this.OrderNumber != target.OrderNumber) resList.Add("OrderNumber");
            if (this.WayToOrder != target.WayToOrder) resList.Add("WayToOrder");
            if (this.SlipMemo1 != target.SlipMemo1) resList.Add("SlipMemo1");
            if (this.SlipMemo2 != target.SlipMemo2) resList.Add("SlipMemo2");
            if (this.SlipMemo3 != target.SlipMemo3) resList.Add("SlipMemo3");
            if (this.InsideMemo1 != target.InsideMemo1) resList.Add("InsideMemo1");
            if (this.InsideMemo2 != target.InsideMemo2) resList.Add("InsideMemo2");
            if (this.InsideMemo3 != target.InsideMemo3) resList.Add("InsideMemo3");
            if (this.BfListPrice != target.BfListPrice) resList.Add("BfListPrice");
            if (this.BfSalesUnitPrice != target.BfSalesUnitPrice) resList.Add("BfSalesUnitPrice");
            if (this.BfUnitCost != target.BfUnitCost) resList.Add("BfUnitCost");
            if (this.CmpltSalesRowNo != target.CmpltSalesRowNo) resList.Add("CmpltSalesRowNo");
            if (this.CmpltGoodsMakerCd != target.CmpltGoodsMakerCd) resList.Add("CmpltGoodsMakerCd");
            if (this.CmpltMakerName != target.CmpltMakerName) resList.Add("CmpltMakerName");
            if (this.CmpltMakerKanaName != target.CmpltMakerKanaName) resList.Add("CmpltMakerKanaName");
            if (this.CmpltGoodsName != target.CmpltGoodsName) resList.Add("CmpltGoodsName");
            if (this.CmpltShipmentCnt != target.CmpltShipmentCnt) resList.Add("CmpltShipmentCnt");
            if (this.CmpltSalesUnPrcFl != target.CmpltSalesUnPrcFl) resList.Add("CmpltSalesUnPrcFl");
            if (this.CmpltSalesMoney != target.CmpltSalesMoney) resList.Add("CmpltSalesMoney");
            if (this.CmpltSalesUnitCost != target.CmpltSalesUnitCost) resList.Add("CmpltSalesUnitCost");
            if (this.CmpltCost != target.CmpltCost) resList.Add("CmpltCost");
            if (this.CmpltPartySalSlNum != target.CmpltPartySalSlNum) resList.Add("CmpltPartySalSlNum");
            if (this.CmpltNote != target.CmpltNote) resList.Add("CmpltNote");
            if (this.SelectedGoodsNoDiv != target.SelectedGoodsNoDiv) resList.Add("SelectedGoodsNoDiv");
            if (this.PrtGoodsNo != target.PrtGoodsNo) resList.Add("PrtGoodsNo");
            if (this.PrtMakerCode != target.PrtMakerCode) resList.Add("PrtMakerCode");
            if (this.PrtMakerName != target.PrtMakerName) resList.Add("PrtMakerName");
            if (this.DtlRelationGuid != target.DtlRelationGuid) resList.Add("DtlRelationGuid");
            if (this.CarRelationGuid != target.CarRelationGuid) resList.Add("CarRelationGuid");
            if (this.ShipmentCntDefault != target.ShipmentCntDefault) resList.Add("ShipmentCntDefault");
            if (this.ShipmentCntDefForChk != target.ShipmentCntDefForChk) resList.Add("ShipmentCntDefForChk");
            if (this.AcceptAnOrderCntDefault != target.AcceptAnOrderCntDefault) resList.Add("AcceptAnOrderCntDefault");
            if (this.AcceptAnOrderCntDefForChk != target.AcceptAnOrderCntDefForChk) resList.Add("AcceptAnOrderCntDefForChk");
            if (this.SalesUnPrcTaxIncFlDefault != target.SalesUnPrcTaxIncFlDefault) resList.Add("SalesUnPrcTaxIncFlDefault");
            if (this.SalesUnPrcTaxExcFlDefault != target.SalesUnPrcTaxExcFlDefault) resList.Add("SalesUnPrcTaxExcFlDefault");
            if (this.SalesUnitCostTaxIncDefault != target.SalesUnitCostTaxIncDefault) resList.Add("SalesUnitCostTaxIncDefault");
            if (this.SalesUnitCostTacExcDefault != target.SalesUnitCostTacExcDefault) resList.Add("SalesUnitCostTacExcDefault");
            //>>>2010/02/26
            if (this.CampaignCode != target.CampaignCode) resList.Add("CampaignCode");
            if (this.CampaignName != target.CampaignName) resList.Add("CampaignName");
            if (this.GoodsDivCd != target.GoodsDivCd) resList.Add("GoodsDivCd");
            if (this.AnswerDelivDate != target.AnswerDelivDate) resList.Add("AnswerDelivDate");
            if (this.RecycleDiv != target.RecycleDiv) resList.Add("RecycleDiv");
            if (this.RecycleDivNm != target.RecycleDivNm) resList.Add("RecycleDivNm");
            if (this.WayToAcptOdr != target.WayToAcptOdr) resList.Add("WayToAcptOdr");
            if (this.GoodsMngNo != target.GoodsMngNo) resList.Add("GoodsMngNo");
            if (this.InqRowNumber != target.InqRowNumber) resList.Add("InqRowNumber");
            if (this.InqRowNumDerivedNo != target.InqRowNumDerivedNo) resList.Add("InqRowNumDerivedNo");
            //<<<2010/02/26
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            if (this.UpdEmployeeName != target.UpdEmployeeName) resList.Add("UpdEmployeeName");
            if (this.BLGoodsName != target.BLGoodsName) resList.Add("BLGoodsName");
            if (this.EditStatus != target.EditStatus) resList.Add("EditStatus"); //ADD 2010/04/06 
            if (this.RowStatus != target.RowStatus) resList.Add("RowStatus"); //ADD 2010/04/06 
            if (this.SalesMoneyInputDiv != target.SalesMoneyInputDiv) resList.Add("SalesMoneyInputDiv"); //ADD 2010/04/06
            if (this.ShipmentCntDisplay != target.ShipmentCntDisplay) resList.Add("ShipmentCntDisplay"); //ADD 2010/04/06 
            if (this.SupplierStockDisplay != target.SupplierStockDisplay) resList.Add("SupplierStockDisplay"); //ADD 2010/04/06 
            if (this.ListPriceDisplay != target.ListPriceDisplay) resList.Add("ListPriceDisplay"); //ADD 2010/04/06 
            if (this.StockDate != target.StockDate) resList.Add("StockDate"); //ADD 2010/04/06 
            if (this.BoCode != target.BoCode) resList.Add("BoCode"); //ADD 2010/04/06 
            if (this.SupplierCdForOrder != target.SupplierCdForOrder) resList.Add("SupplierCdForOrder"); //ADD 2010/04/06 
            if (this.SupplierSnmForOrder != target.SupplierSnmForOrder) resList.Add("SupplierSnmForOrder"); //ADD 2010/04/06 
            if (this.AutoAnswerDivSCM != target.AutoAnswerDivSCM) resList.Add("AutoAnswerDivSCM"); //ADD 2011/07/18 朱宝軍
            //>>>2012/05/02
            if (this.RentSyncStockDate != target.RentSyncStockDate) resList.Add("RentSyncStockDate");
            if (this.RentSyncSupplier != target.RentSyncSupplier) resList.Add("RentSyncSupplier");
            if (this.RentSyncSupSlipNo != target.RentSyncSupSlipNo) resList.Add("RentSyncSupSlipNo");
            //<<<2012/05/02
            if (this.PriceSelectDiv != target.PriceSelectDiv) resList.Add("PriceSelectDiv");// ADD 2013/01/24 鄧潘ハン REDMINE#34605

            return resList;
        }

        /// <summary>
        /// 売上明細データ比較処理
        /// </summary>
        /// <param name="salesDetail1">比較するSalesDetailクラスのインスタンス</param>
        /// <param name="salesDetail2">比較するSalesDetailクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SalesDetailクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static ArrayList Compare(SalesDetail salesDetail1, SalesDetail salesDetail2)
        {
            ArrayList resList = new ArrayList();
            if (salesDetail1.CreateDateTime != salesDetail2.CreateDateTime) resList.Add("CreateDateTime");
            if (salesDetail1.UpdateDateTime != salesDetail2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (salesDetail1.EnterpriseCode != salesDetail2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (salesDetail1.FileHeaderGuid != salesDetail2.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (salesDetail1.UpdEmployeeCode != salesDetail2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (salesDetail1.UpdAssemblyId1 != salesDetail2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (salesDetail1.UpdAssemblyId2 != salesDetail2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (salesDetail1.LogicalDeleteCode != salesDetail2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (salesDetail1.AcceptAnOrderNo != salesDetail2.AcceptAnOrderNo) resList.Add("AcceptAnOrderNo");
            if (salesDetail1.AcptAnOdrStatus != salesDetail2.AcptAnOdrStatus) resList.Add("AcptAnOdrStatus");
            if (salesDetail1.SalesSlipNum != salesDetail2.SalesSlipNum) resList.Add("SalesSlipNum");
            if (salesDetail1.SalesRowNo != salesDetail2.SalesRowNo) resList.Add("SalesRowNo");
            if (salesDetail1.SalesRowDerivNo != salesDetail2.SalesRowDerivNo) resList.Add("SalesRowDerivNo");
            if (salesDetail1.SectionCode != salesDetail2.SectionCode) resList.Add("SectionCode");
            if (salesDetail1.SubSectionCode != salesDetail2.SubSectionCode) resList.Add("SubSectionCode");
            if (salesDetail1.SalesDate != salesDetail2.SalesDate) resList.Add("SalesDate");
            if (salesDetail1.CommonSeqNo != salesDetail2.CommonSeqNo) resList.Add("CommonSeqNo");
            if (salesDetail1.SalesSlipDtlNum != salesDetail2.SalesSlipDtlNum) resList.Add("SalesSlipDtlNum");
            if (salesDetail1.AcptAnOdrStatusSrc != salesDetail2.AcptAnOdrStatusSrc) resList.Add("AcptAnOdrStatusSrc");
            if (salesDetail1.SalesSlipDtlNumSrc != salesDetail2.SalesSlipDtlNumSrc) resList.Add("SalesSlipDtlNumSrc");
            if (salesDetail1.SupplierFormalSync != salesDetail2.SupplierFormalSync) resList.Add("SupplierFormalSync");
            if (salesDetail1.StockSlipDtlNumSync != salesDetail2.StockSlipDtlNumSync) resList.Add("StockSlipDtlNumSync");
            if (salesDetail1.SalesSlipCdDtl != salesDetail2.SalesSlipCdDtl) resList.Add("SalesSlipCdDtl");
            if (salesDetail1.DeliGdsCmpltDueDate != salesDetail2.DeliGdsCmpltDueDate) resList.Add("DeliGdsCmpltDueDate");
            if (salesDetail1.GoodsKindCode != salesDetail2.GoodsKindCode) resList.Add("GoodsKindCode");
            if (salesDetail1.GoodsSearchDivCd != salesDetail2.GoodsSearchDivCd) resList.Add("GoodsSearchDivCd");
            if (salesDetail1.GoodsMakerCd != salesDetail2.GoodsMakerCd) resList.Add("GoodsMakerCd");
            if (salesDetail1.MakerName != salesDetail2.MakerName) resList.Add("MakerName");
            if (salesDetail1.MakerKanaName != salesDetail2.MakerKanaName) resList.Add("MakerKanaName");
            if (salesDetail1.GoodsNo != salesDetail2.GoodsNo) resList.Add("GoodsNo");
            if (salesDetail1.GoodsName != salesDetail2.GoodsName) resList.Add("GoodsName");
            if (salesDetail1.GoodsNameKana != salesDetail2.GoodsNameKana) resList.Add("GoodsNameKana");
            if (salesDetail1.GoodsLGroup != salesDetail2.GoodsLGroup) resList.Add("GoodsLGroup");
            if (salesDetail1.GoodsLGroupName != salesDetail2.GoodsLGroupName) resList.Add("GoodsLGroupName");
            if (salesDetail1.GoodsMGroup != salesDetail2.GoodsMGroup) resList.Add("GoodsMGroup");
            if (salesDetail1.GoodsMGroupName != salesDetail2.GoodsMGroupName) resList.Add("GoodsMGroupName");
            if (salesDetail1.BLGroupCode != salesDetail2.BLGroupCode) resList.Add("BLGroupCode");
            if (salesDetail1.BLGroupName != salesDetail2.BLGroupName) resList.Add("BLGroupName");
            if (salesDetail1.BLGoodsCode != salesDetail2.BLGoodsCode) resList.Add("BLGoodsCode");
            if (salesDetail1.BLGoodsFullName != salesDetail2.BLGoodsFullName) resList.Add("BLGoodsFullName");
            if (salesDetail1.EnterpriseGanreCode != salesDetail2.EnterpriseGanreCode) resList.Add("EnterpriseGanreCode");
            if (salesDetail1.EnterpriseGanreName != salesDetail2.EnterpriseGanreName) resList.Add("EnterpriseGanreName");
            if (salesDetail1.WarehouseCode != salesDetail2.WarehouseCode) resList.Add("WarehouseCode");
            if (salesDetail1.WarehouseName != salesDetail2.WarehouseName) resList.Add("WarehouseName");
            if (salesDetail1.WarehouseShelfNo != salesDetail2.WarehouseShelfNo) resList.Add("WarehouseShelfNo");
            if (salesDetail1.SalesOrderDivCd != salesDetail2.SalesOrderDivCd) resList.Add("SalesOrderDivCd");
            if (salesDetail1.OpenPriceDiv != salesDetail2.OpenPriceDiv) resList.Add("OpenPriceDiv");
            if (salesDetail1.GoodsRateRank != salesDetail2.GoodsRateRank) resList.Add("GoodsRateRank");
            if (salesDetail1.CustRateGrpCode != salesDetail2.CustRateGrpCode) resList.Add("CustRateGrpCode");
            if (salesDetail1.ListPriceRate != salesDetail2.ListPriceRate) resList.Add("ListPriceRate");
            if (salesDetail1.RateSectPriceUnPrc != salesDetail2.RateSectPriceUnPrc) resList.Add("RateSectPriceUnPrc");
            if (salesDetail1.RateDivLPrice != salesDetail2.RateDivLPrice) resList.Add("RateDivLPrice");
            if (salesDetail1.UnPrcCalcCdLPrice != salesDetail2.UnPrcCalcCdLPrice) resList.Add("UnPrcCalcCdLPrice");
            if (salesDetail1.PriceCdLPrice != salesDetail2.PriceCdLPrice) resList.Add("PriceCdLPrice");
            if (salesDetail1.StdUnPrcLPrice != salesDetail2.StdUnPrcLPrice) resList.Add("StdUnPrcLPrice");
            if (salesDetail1.FracProcUnitLPrice != salesDetail2.FracProcUnitLPrice) resList.Add("FracProcUnitLPrice");
            if (salesDetail1.FracProcLPrice != salesDetail2.FracProcLPrice) resList.Add("FracProcLPrice");
            if (salesDetail1.ListPriceTaxIncFl != salesDetail2.ListPriceTaxIncFl) resList.Add("ListPriceTaxIncFl");
            if (salesDetail1.ListPriceTaxExcFl != salesDetail2.ListPriceTaxExcFl) resList.Add("ListPriceTaxExcFl");
            if (salesDetail1.ListPriceChngCd != salesDetail2.ListPriceChngCd) resList.Add("ListPriceChngCd");
            if (salesDetail1.SalesRate != salesDetail2.SalesRate) resList.Add("SalesRate");
            if (salesDetail1.RateSectSalUnPrc != salesDetail2.RateSectSalUnPrc) resList.Add("RateSectSalUnPrc");
            if (salesDetail1.RateDivSalUnPrc != salesDetail2.RateDivSalUnPrc) resList.Add("RateDivSalUnPrc");
            if (salesDetail1.UnPrcCalcCdSalUnPrc != salesDetail2.UnPrcCalcCdSalUnPrc) resList.Add("UnPrcCalcCdSalUnPrc");
            if (salesDetail1.PriceCdSalUnPrc != salesDetail2.PriceCdSalUnPrc) resList.Add("PriceCdSalUnPrc");
            if (salesDetail1.StdUnPrcSalUnPrc != salesDetail2.StdUnPrcSalUnPrc) resList.Add("StdUnPrcSalUnPrc");
            if (salesDetail1.FracProcUnitSalUnPrc != salesDetail2.FracProcUnitSalUnPrc) resList.Add("FracProcUnitSalUnPrc");
            if (salesDetail1.FracProcSalUnPrc != salesDetail2.FracProcSalUnPrc) resList.Add("FracProcSalUnPrc");
            if (salesDetail1.SalesUnPrcTaxIncFl != salesDetail2.SalesUnPrcTaxIncFl) resList.Add("SalesUnPrcTaxIncFl");
            if (salesDetail1.SalesUnPrcTaxExcFl != salesDetail2.SalesUnPrcTaxExcFl) resList.Add("SalesUnPrcTaxExcFl");
            if (salesDetail1.SalesUnPrcChngCd != salesDetail2.SalesUnPrcChngCd) resList.Add("SalesUnPrcChngCd");
            if (salesDetail1.CostRate != salesDetail2.CostRate) resList.Add("CostRate");
            if (salesDetail1.RateSectCstUnPrc != salesDetail2.RateSectCstUnPrc) resList.Add("RateSectCstUnPrc");
            if (salesDetail1.RateDivUnCst != salesDetail2.RateDivUnCst) resList.Add("RateDivUnCst");
            if (salesDetail1.UnPrcCalcCdUnCst != salesDetail2.UnPrcCalcCdUnCst) resList.Add("UnPrcCalcCdUnCst");
            if (salesDetail1.PriceCdUnCst != salesDetail2.PriceCdUnCst) resList.Add("PriceCdUnCst");
            if (salesDetail1.StdUnPrcUnCst != salesDetail2.StdUnPrcUnCst) resList.Add("StdUnPrcUnCst");
            if (salesDetail1.FracProcUnitUnCst != salesDetail2.FracProcUnitUnCst) resList.Add("FracProcUnitUnCst");
            if (salesDetail1.FracProcUnCst != salesDetail2.FracProcUnCst) resList.Add("FracProcUnCst");
            if (salesDetail1.SalesUnitCost != salesDetail2.SalesUnitCost) resList.Add("SalesUnitCost");
            if (salesDetail1.SalesUnitCostChngDiv != salesDetail2.SalesUnitCostChngDiv) resList.Add("SalesUnitCostChngDiv");
            if (salesDetail1.RateBLGoodsCode != salesDetail2.RateBLGoodsCode) resList.Add("RateBLGoodsCode");
            if (salesDetail1.RateBLGoodsName != salesDetail2.RateBLGoodsName) resList.Add("RateBLGoodsName");
            if (salesDetail1.RateGoodsRateGrpCd != salesDetail2.RateGoodsRateGrpCd) resList.Add("RateGoodsRateGrpCd");
            if (salesDetail1.RateGoodsRateGrpNm != salesDetail2.RateGoodsRateGrpNm) resList.Add("RateGoodsRateGrpNm");
            if (salesDetail1.RateBLGroupCode != salesDetail2.RateBLGroupCode) resList.Add("RateBLGroupCode");
            if (salesDetail1.RateBLGroupName != salesDetail2.RateBLGroupName) resList.Add("RateBLGroupName");
            if (salesDetail1.PrtBLGoodsCode != salesDetail2.PrtBLGoodsCode) resList.Add("PrtBLGoodsCode");
            if (salesDetail1.PrtBLGoodsName != salesDetail2.PrtBLGoodsName) resList.Add("PrtBLGoodsName");
            if (salesDetail1.SalesCode != salesDetail2.SalesCode) resList.Add("SalesCode");
            if (salesDetail1.SalesCdNm != salesDetail2.SalesCdNm) resList.Add("SalesCdNm");
            if (salesDetail1.WorkManHour != salesDetail2.WorkManHour) resList.Add("WorkManHour");
            if (salesDetail1.ShipmentCnt != salesDetail2.ShipmentCnt) resList.Add("ShipmentCnt");
            if (salesDetail1.AcceptAnOrderCnt != salesDetail2.AcceptAnOrderCnt) resList.Add("AcceptAnOrderCnt");
            if (salesDetail1.AcptAnOdrAdjustCnt != salesDetail2.AcptAnOdrAdjustCnt) resList.Add("AcptAnOdrAdjustCnt");
            if (salesDetail1.AcptAnOdrRemainCnt != salesDetail2.AcptAnOdrRemainCnt) resList.Add("AcptAnOdrRemainCnt");
            if (salesDetail1.RemainCntUpdDate != salesDetail2.RemainCntUpdDate) resList.Add("RemainCntUpdDate");
            if (salesDetail1.SalesMoneyTaxInc != salesDetail2.SalesMoneyTaxInc) resList.Add("SalesMoneyTaxInc");
            if (salesDetail1.SalesMoneyTaxExc != salesDetail2.SalesMoneyTaxExc) resList.Add("SalesMoneyTaxExc");
            if (salesDetail1.Cost != salesDetail2.Cost) resList.Add("Cost");
            if (salesDetail1.GrsProfitChkDiv != salesDetail2.GrsProfitChkDiv) resList.Add("GrsProfitChkDiv");
            if (salesDetail1.SalesGoodsCd != salesDetail2.SalesGoodsCd) resList.Add("SalesGoodsCd");
            if (salesDetail1.SalesPriceConsTax != salesDetail2.SalesPriceConsTax) resList.Add("SalesPriceConsTax");
            if (salesDetail1.TaxationDivCd != salesDetail2.TaxationDivCd) resList.Add("TaxationDivCd");
            if (salesDetail1.PartySlipNumDtl != salesDetail2.PartySlipNumDtl) resList.Add("PartySlipNumDtl");
            if (salesDetail1.DtlNote != salesDetail2.DtlNote) resList.Add("DtlNote");
            if (salesDetail1.SupplierCd != salesDetail2.SupplierCd) resList.Add("SupplierCd");
            if (salesDetail1.SupplierSnm != salesDetail2.SupplierSnm) resList.Add("SupplierSnm");
            if (salesDetail1.OrderNumber != salesDetail2.OrderNumber) resList.Add("OrderNumber");
            if (salesDetail1.WayToOrder != salesDetail2.WayToOrder) resList.Add("WayToOrder");
            if (salesDetail1.SlipMemo1 != salesDetail2.SlipMemo1) resList.Add("SlipMemo1");
            if (salesDetail1.SlipMemo2 != salesDetail2.SlipMemo2) resList.Add("SlipMemo2");
            if (salesDetail1.SlipMemo3 != salesDetail2.SlipMemo3) resList.Add("SlipMemo3");
            if (salesDetail1.InsideMemo1 != salesDetail2.InsideMemo1) resList.Add("InsideMemo1");
            if (salesDetail1.InsideMemo2 != salesDetail2.InsideMemo2) resList.Add("InsideMemo2");
            if (salesDetail1.InsideMemo3 != salesDetail2.InsideMemo3) resList.Add("InsideMemo3");
            if (salesDetail1.BfListPrice != salesDetail2.BfListPrice) resList.Add("BfListPrice");
            if (salesDetail1.BfSalesUnitPrice != salesDetail2.BfSalesUnitPrice) resList.Add("BfSalesUnitPrice");
            if (salesDetail1.BfUnitCost != salesDetail2.BfUnitCost) resList.Add("BfUnitCost");
            if (salesDetail1.CmpltSalesRowNo != salesDetail2.CmpltSalesRowNo) resList.Add("CmpltSalesRowNo");
            if (salesDetail1.CmpltGoodsMakerCd != salesDetail2.CmpltGoodsMakerCd) resList.Add("CmpltGoodsMakerCd");
            if (salesDetail1.CmpltMakerName != salesDetail2.CmpltMakerName) resList.Add("CmpltMakerName");
            if (salesDetail1.CmpltMakerKanaName != salesDetail2.CmpltMakerKanaName) resList.Add("CmpltMakerKanaName");
            if (salesDetail1.CmpltGoodsName != salesDetail2.CmpltGoodsName) resList.Add("CmpltGoodsName");
            if (salesDetail1.CmpltShipmentCnt != salesDetail2.CmpltShipmentCnt) resList.Add("CmpltShipmentCnt");
            if (salesDetail1.CmpltSalesUnPrcFl != salesDetail2.CmpltSalesUnPrcFl) resList.Add("CmpltSalesUnPrcFl");
            if (salesDetail1.CmpltSalesMoney != salesDetail2.CmpltSalesMoney) resList.Add("CmpltSalesMoney");
            if (salesDetail1.CmpltSalesUnitCost != salesDetail2.CmpltSalesUnitCost) resList.Add("CmpltSalesUnitCost");
            if (salesDetail1.CmpltCost != salesDetail2.CmpltCost) resList.Add("CmpltCost");
            if (salesDetail1.CmpltPartySalSlNum != salesDetail2.CmpltPartySalSlNum) resList.Add("CmpltPartySalSlNum");
            if (salesDetail1.CmpltNote != salesDetail2.CmpltNote) resList.Add("CmpltNote");
            if (salesDetail1.SelectedGoodsNoDiv != salesDetail2.SelectedGoodsNoDiv) resList.Add("SelectedGoodsNoDiv");
            if (salesDetail1.PrtGoodsNo != salesDetail2.PrtGoodsNo) resList.Add("PrtGoodsNo");
            if (salesDetail1.PrtMakerCode != salesDetail2.PrtMakerCode) resList.Add("PrtMakerCode");
            if (salesDetail1.PrtMakerName != salesDetail2.PrtMakerName) resList.Add("PrtMakerName");
            if (salesDetail1.DtlRelationGuid != salesDetail2.DtlRelationGuid) resList.Add("DtlRelationGuid");
            if (salesDetail1.CarRelationGuid != salesDetail2.CarRelationGuid) resList.Add("CarRelationGuid");
            if (salesDetail1.ShipmentCntDefault != salesDetail2.ShipmentCntDefault) resList.Add("ShipmentCntDefault");
            if (salesDetail1.ShipmentCntDefForChk != salesDetail2.ShipmentCntDefForChk) resList.Add("ShipmentCntDefForChk");
            if (salesDetail1.AcceptAnOrderCntDefault != salesDetail2.AcceptAnOrderCntDefault) resList.Add("AcceptAnOrderCntDefault");
            if (salesDetail1.AcceptAnOrderCntDefForChk != salesDetail2.AcceptAnOrderCntDefForChk) resList.Add("AcceptAnOrderCntDefForChk");
            if (salesDetail1.SalesUnPrcTaxIncFlDefault != salesDetail2.SalesUnPrcTaxIncFlDefault) resList.Add("SalesUnPrcTaxIncFlDefault");
            if (salesDetail1.SalesUnPrcTaxExcFlDefault != salesDetail2.SalesUnPrcTaxExcFlDefault) resList.Add("SalesUnPrcTaxExcFlDefault");
            if (salesDetail1.SalesUnitCostTaxIncDefault != salesDetail2.SalesUnitCostTaxIncDefault) resList.Add("SalesUnitCostTaxIncDefault");
            if (salesDetail1.SalesUnitCostTacExcDefault != salesDetail2.SalesUnitCostTacExcDefault) resList.Add("SalesUnitCostTacExcDefault");
            //>>>2010/02/26
            if (salesDetail1.CampaignCode != salesDetail2.CampaignCode) resList.Add("CampaignCode");
            if (salesDetail1.CampaignName != salesDetail2.CampaignName) resList.Add("CampaignName");
            if (salesDetail1.GoodsDivCd != salesDetail2.GoodsDivCd) resList.Add("GoodsDivCd");
            if (salesDetail1.AnswerDelivDate != salesDetail2.AnswerDelivDate) resList.Add("AnswerDelivDate");
            if (salesDetail1.RecycleDiv != salesDetail2.RecycleDiv) resList.Add("RecycleDiv");
            if (salesDetail1.RecycleDivNm != salesDetail2.RecycleDivNm) resList.Add("RecycleDivNm");
            if (salesDetail1.WayToAcptOdr != salesDetail2.WayToAcptOdr) resList.Add("WayToAcptOdr");
            if (salesDetail1.GoodsMngNo != salesDetail2.GoodsMngNo) resList.Add("GoodsMngNo");
            if (salesDetail1.InqRowNumber != salesDetail2.InqRowNumber) resList.Add("InqRowNumber");
            if (salesDetail1.InqRowNumDerivedNo != salesDetail2.InqRowNumDerivedNo) resList.Add("InqRowNumDerivedNo");
            //<<<2010/02/26
            if (salesDetail1.EnterpriseName != salesDetail2.EnterpriseName) resList.Add("EnterpriseName");
            if (salesDetail1.UpdEmployeeName != salesDetail2.UpdEmployeeName) resList.Add("UpdEmployeeName");
            if (salesDetail1.BLGoodsName != salesDetail2.BLGoodsName) resList.Add("BLGoodsName");
            if (salesDetail1.EditStatus != salesDetail2.EditStatus) resList.Add("EditStatus"); //ADD 2010/04/06
            if (salesDetail1.RowStatus != salesDetail2.RowStatus) resList.Add("RowStatus"); //ADD 2010/04/06
            if (salesDetail1.SalesMoneyInputDiv != salesDetail2.SalesMoneyInputDiv) resList.Add("SalesMoneyInputDiv"); //ADD 2010/04/06
            if (salesDetail1.ShipmentCntDisplay != salesDetail2.ShipmentCntDisplay) resList.Add("ShipmentCntDisplay"); //ADD 2010/04/06 
            if (salesDetail1.SupplierStockDisplay != salesDetail2.SupplierStockDisplay) resList.Add("SupplierStockDisplay"); //ADD 2010/04/06 
            if (salesDetail1.ListPriceDisplay != salesDetail2.ListPriceDisplay) resList.Add("ListPriceDisplay"); //ADD 2010/04/06 
            if (salesDetail1.StockDate != salesDetail2.StockDate) resList.Add("StockDate"); //ADD 2010/04/06 
            if (salesDetail1.BoCode != salesDetail2.BoCode) resList.Add("BoCode"); //ADD 2010/04/06 
            if (salesDetail1.SupplierCdForOrder != salesDetail2.SupplierCdForOrder) resList.Add("SupplierCdForOrder"); //ADD 2010/04/06 
            if (salesDetail1.SupplierSnmForOrder != salesDetail2.SupplierSnmForOrder) resList.Add("SupplierSnmForOrder"); //ADD 2010/04/06 
            if (salesDetail1.AutoAnswerDivSCM != salesDetail2.AutoAnswerDivSCM) resList.Add("AutoAnswerDivSCM"); //ADD 2011/07/18 朱宝軍
            //>>>2012/05/02
            if (salesDetail1.RentSyncStockDate != salesDetail2.RentSyncStockDate) resList.Add("RentSyncStockDate");
            if (salesDetail1.RentSyncSupplier != salesDetail2.RentSyncSupplier) resList.Add("RentSyncSupplier");
            if (salesDetail1.RentSyncSupSlipNo != salesDetail2.RentSyncSupSlipNo) resList.Add("RentSyncSupSlipNo");
            //<<<2012/05/02
            if (salesDetail1.PriceSelectDiv != salesDetail2.PriceSelectDiv) resList.Add("PriceSelectDiv");// ADD 2013/01/24 鄧潘ハン REDMINE#34605
            return resList;
        }

        /// <summary>
        /// 売上明細データ比較クラス(売上伝票番号(昇順)、売上行番号(昇順)、売上行番号枝番(昇順))
        /// </summary>
        public class SalesDetailComparer : Comparer<SalesDetail>
        {
            /// <summary>
            /// 比較処理
            /// </summary>
            /// <param name="x"></param>
            /// <param name="y"></param>
            /// <returns></returns>
            public override int Compare(SalesDetail x, SalesDetail y)
            {
                int result = x.SalesSlipNum.CompareTo(y.SalesSlipNum);
                if (result != 0) return result;

                result = x.SalesRowNo.CompareTo(y.SalesRowNo);
                if (result != 0) return result;

                result = x.SalesRowDerivNo.CompareTo(y.SalesRowDerivNo);
                return result;
            }
        }
	}
}
