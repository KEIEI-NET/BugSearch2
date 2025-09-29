using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   StockTemp
    /// <summary>
    ///                      仕入情報（売仕入同時入力）
    /// </summary>
    /// <remarks>
    /// <br>note             :   仕入情報（売仕入同時入力）ヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2008/3/25</br>
    /// <br>Genarated Date   :   2008/09/09  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2008/9/9  對馬</br>
    /// <br>                 :   売仕入同時入力用データクラス。</br>
    /// <br>                 :   仕入データおよび仕入明細データを結合。</br>
    /// <br>                 :   重複項目は、仕入明細データに存在する項目の末尾に「Detail」を付加。</br>
    /// <br>                 :   以下を追加。</br>
    /// <br>                 :   締日　次回勘定開始日</br>
    /// <br>                 :   支払先名称　支払先名称２</br>
    /// <br>                 :   計上可能数量　計上済数量</br>
    /// <br>                 :   エディットステータス</br>
    /// </remarks>
    public class StockTemp
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

        /// <summary>仕入形式</summary>
        /// <remarks>0:仕入,1:入荷,2:発注　（受注ステータス）</remarks>
        private Int32 _supplierFormal;

        /// <summary>仕入伝票番号</summary>
        /// <remarks>仕入伝票番号,入荷伝票番号,注文書番号(発注)を兼ねる</remarks>
        private Int32 _supplierSlipNo;

        /// <summary>拠点コード</summary>
        private string _sectionCode = "";

        /// <summary>部門コード</summary>
        private Int32 _subSectionCode;

        /// <summary>赤伝区分</summary>
        /// <remarks>0:黒伝,1:赤伝,2:元黒</remarks>
        private Int32 _debitNoteDiv;

        /// <summary>赤黒連結仕入伝票番号</summary>
        private Int32 _debitNLnkSuppSlipNo;

        /// <summary>仕入伝票区分</summary>
        /// <remarks>10:仕入,20:返品</remarks>
        private Int32 _supplierSlipCd;

        /// <summary>仕入商品区分</summary>
        /// <remarks>0:商品,1:商品外,2:消費税調整,3:残高調整,4:買掛用消費税調整,5:買掛用残高調整,6:合計入力,10:買用消費税調整(自動),11:相殺,12:相殺(自動)</remarks>
        private Int32 _stockGoodsCd;

        /// <summary>買掛区分</summary>
        /// <remarks>0:買掛なし,1:買掛</remarks>
        private Int32 _accPayDivCd;

        /// <summary>仕入拠点コード</summary>
        private string _stockSectionCd = "";

        /// <summary>仕入計上拠点コード</summary>
        /// <remarks>文字型 仕入計上対象の拠点コード(拠点制御の支払計上拠点のこと)</remarks>
        private string _stockAddUpSectionCd = "";

        /// <summary>仕入伝票更新区分</summary>
        /// <remarks>0:未更新,1:更新あり</remarks>
        private Int32 _stockSlipUpdateCd;

        /// <summary>入力日</summary>
        /// <remarks>YYYYMMDD　（更新年月日）</remarks>
        private DateTime _inputDay;

        /// <summary>入荷日</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _arrivalGoodsDay;

        /// <summary>仕入日</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _stockDate;

        /// <summary>仕入計上日付</summary>
        /// <remarks>仕入計上日</remarks>
        private DateTime _stockAddUpADate;

        /// <summary>来勘区分</summary>
        /// <remarks>0:当月(来勘なし),1:来月,2:再来月…9:9ヵ月後</remarks>
        private Int32 _delayPaymentDiv;

        /// <summary>支払先コード</summary>
        /// <remarks>支払先(精算先)コード。支払締時は支払先単位で集計・計算。</remarks>
        private Int32 _payeeCode;

        /// <summary>支払先略称</summary>
        private string _payeeSnm = "";

        /// <summary>仕入先コード</summary>
        private Int32 _supplierCd;

        /// <summary>仕入先名1</summary>
        private string _supplierNm1 = "";

        /// <summary>仕入先名2</summary>
        private string _supplierNm2 = "";

        /// <summary>仕入先略称</summary>
        private string _supplierSnm = "";

        /// <summary>業種コード</summary>
        private Int32 _businessTypeCode;

        /// <summary>業種名称</summary>
        private string _businessTypeName = "";

        /// <summary>販売エリアコード</summary>
        /// <remarks>地区コード</remarks>
        private Int32 _salesAreaCode;

        /// <summary>販売エリア名称</summary>
        private string _salesAreaName = "";

        /// <summary>仕入入力者コード</summary>
        private string _stockInputCode = "";

        /// <summary>仕入入力者名称</summary>
        private string _stockInputName = "";

        /// <summary>仕入担当者コード</summary>
        /// <remarks>発注者をセット</remarks>
        private string _stockAgentCode = "";

        /// <summary>仕入担当者名称</summary>
        /// <remarks>発注者をセット</remarks>
        private string _stockAgentName = "";

        /// <summary>仕入先総額表示方法区分</summary>
        /// <remarks>0:総額表示しない（税抜き）,1:総額表示する（税込み）</remarks>
        private Int32 _suppTtlAmntDspWayCd;

        /// <summary>総額表示掛率適用区分</summary>
        /// <remarks>0：基準価格(税込)×掛率, 1:基準価格(税抜)×掛率</remarks>
        private Int32 _ttlAmntDispRateApy;

        /// <summary>仕入金額合計</summary>
        /// <remarks>仕入金額合計＝仕入金額計（税込み）＋非課税対象額合計</remarks>
        private Int64 _stockTotalPrice;

        /// <summary>仕入金額小計</summary>
        /// <remarks>仕入金額小計＝仕入金額計（税抜き）＋非課税対象額合計</remarks>
        private Int64 _stockSubttlPrice;

        /// <summary>仕入金額計（税込み）</summary>
        /// <remarks>外税時：税抜き＋消費税、内税時：内税価格（税込）の集計</remarks>
        private Int64 _stockTtlPricTaxInc;

        /// <summary>仕入金額計（税抜き）</summary>
        /// <remarks>外税時：税抜価格の集計、内税時：内税価格（税込）の集計－消費税</remarks>
        private Int64 _stockTtlPricTaxExc;

        /// <summary>仕入正価金額</summary>
        /// <remarks>値引前の税抜仕入金額</remarks>
        private Int64 _stockNetPrice;

        /// <summary>仕入金額消費税額</summary>
        /// <remarks>仕入金額消費税額（外税）+仕入金額消費税額（内税）</remarks>
        private Int64 _stockPriceConsTax;

        /// <summary>仕入外税対象額合計</summary>
        /// <remarks>外税対象金額の集計（税抜、値引含まず）</remarks>
        private Int64 _ttlItdedStcOutTax;

        /// <summary>仕入内税対象額合計</summary>
        /// <remarks>内税対象金額の集計（税抜、値引含まず） </remarks>
        private Int64 _ttlItdedStcInTax;

        /// <summary>仕入非課税対象額合計</summary>
        /// <remarks>非課税対象金額の集計（値引含まず）</remarks>
        private Int64 _ttlItdedStcTaxFree;

        /// <summary>仕入金額消費税額（外税）</summary>
        /// <remarks>値引前の外税商品の消費税</remarks>
        private Int64 _stockOutTax;

        /// <summary>仕入金額消費税額（内税）</summary>
        /// <remarks>値引前の内税商品の消費税</remarks>
        private Int64 _stckPrcConsTaxInclu;

        /// <summary>仕入値引金額計（税抜き）</summary>
        /// <remarks>仕入値引外税対象額合計+仕入値引内税対象額合計+仕入値引非課税対象額合計</remarks>
        private Int64 _stckDisTtlTaxExc;

        /// <summary>仕入値引外税対象額合計</summary>
        /// <remarks>外税商品値引の外税対象額（税抜）</remarks>
        private Int64 _itdedStockDisOutTax;

        /// <summary>仕入値引内税対象額合計</summary>
        /// <remarks>内税商品値引の内税対象額（税抜）</remarks>
        private Int64 _itdedStockDisInTax;

        /// <summary>仕入値引非課税対象額合計</summary>
        /// <remarks>非課税商品値引の非課税対象額</remarks>
        private Int64 _itdedStockDisTaxFre;

        /// <summary>仕入値引消費税額（外税）</summary>
        /// <remarks>外税商品値引の消費税額</remarks>
        private Int64 _stockDisOutTax;

        /// <summary>仕入値引消費税額（内税）</summary>
        /// <remarks>内税商品値引の消費税額</remarks>
        private Int64 _stckDisTtlTaxInclu;

        /// <summary>消費税調整額</summary>
        private Int64 _taxAdjust;

        /// <summary>残高調整額</summary>
        private Int64 _balanceAdjust;

        /// <summary>仕入先消費税転嫁方式コード</summary>
        /// <remarks>0:伝票単位1:明細単位2:支払親 3:支払子 9:非課税</remarks>
        private Int32 _suppCTaxLayCd;

        /// <summary>仕入先消費税税率</summary>
        private Double _supplierConsTaxRate;

        /// <summary>買掛消費税</summary>
        private Int64 _accPayConsTax;

        /// <summary>仕入端数処理区分</summary>
        /// <remarks>1:切捨て,2:四捨五入,3:切上げ　（消費税）</remarks>
        private Int32 _stockFractionProcCd;

        /// <summary>自動支払区分</summary>
        /// <remarks>0:通常支払,1:自動支払</remarks>
        private Int32 _autoPayment;

        /// <summary>自動支払伝票番号</summary>
        /// <remarks>自動支払時の支払伝票番号</remarks>
        private Int32 _autoPaySlipNum;

        /// <summary>返品理由コード</summary>
        private Int32 _retGoodsReasonDiv;

        /// <summary>返品理由</summary>
        private string _retGoodsReason = "";

        /// <summary>相手先伝票番号</summary>
        /// <remarks>仕入先伝票番号に使用する</remarks>
        private string _partySaleSlipNum = "";

        /// <summary>仕入伝票備考1</summary>
        private string _supplierSlipNote1 = "";

        /// <summary>仕入伝票備考2</summary>
        private string _supplierSlipNote2 = "";

        /// <summary>明細行数</summary>
        /// <remarks>伝票内の明細の行数（諸費用明細は除く）</remarks>
        private Int32 _detailRowCount;

        /// <summary>ＥＤＩ送信日</summary>
        /// <remarks>YYYYMMDD （ErectricDataInterface）</remarks>
        private DateTime _ediSendDate;

        /// <summary>ＥＤＩ取込日</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _ediTakeInDate;

        /// <summary>ＵＯＥリマーク１</summary>
        /// <remarks>UserOrderEntory</remarks>
        private string _uoeRemark1 = "";

        /// <summary>ＵＯＥリマーク２</summary>
        private string _uoeRemark2 = "";

        /// <summary>伝票発行区分</summary>
        /// <remarks>0:しない 1:する</remarks>
        private Int32 _slipPrintDivCd;

        /// <summary>伝票発行済区分</summary>
        /// <remarks>0:未発行 1:発行済</remarks>
        private Int32 _slipPrintFinishCd;

        /// <summary>仕入伝票発行日</summary>
        /// <remarks>入荷では入荷伝票発行日（発注書発行日もここを使用）</remarks>
        private DateTime _stockSlipPrintDate;

        /// <summary>伝票印刷設定用帳票ID</summary>
        /// <remarks>仕入形式とセットで伝票タイプ管理マスタを参照　（発注,入荷用）</remarks>
        private string _slipPrtSetPaperId = "";

        /// <summary>伝票住所区分</summary>
        /// <remarks>1:得意先,2:納入先</remarks>
        private Int32 _slipAddressDiv;

        /// <summary>納品先コード</summary>
        private Int32 _addresseeCode;

        /// <summary>納品先名称</summary>
        private string _addresseeName = "";

        /// <summary>納品先名称2</summary>
        /// <remarks>追加(登録漏れ) 塩原</remarks>
        private string _addresseeName2 = "";

        /// <summary>納品先郵便番号</summary>
        /// <remarks>伝票住所区分に従う内容</remarks>
        private string _addresseePostNo = "";

        /// <summary>納品先住所1(都道府県市区郡・町村・字)</summary>
        /// <remarks>伝票住所区分に従う内容</remarks>
        private string _addresseeAddr1 = "";

        /// <summary>納品先住所3(番地)</summary>
        /// <remarks>伝票住所区分に従う内容</remarks>
        private string _addresseeAddr3 = "";

        /// <summary>納品先住所4(アパート名称)</summary>
        /// <remarks>伝票住所区分に従う内容</remarks>
        private string _addresseeAddr4 = "";

        /// <summary>納品先電話番号</summary>
        /// <remarks>伝票住所区分に従う内容</remarks>
        private string _addresseeTelNo = "";

        /// <summary>納品先FAX番号</summary>
        /// <remarks>伝票住所区分に従う内容</remarks>
        private string _addresseeFaxNo = "";

        /// <summary>直送区分</summary>
        /// <remarks>0:直送なし,1:直送あり　（発注書の直送先印字制御）</remarks>
        private Int32 _directSendingCd;

        /// <summary>受注番号</summary>
        private Int32 _acceptAnOrderNo;

        /// <summary>仕入形式</summary>
        /// <remarks>0:仕入,1:入荷,2:発注　（受注ステータス）</remarks>
        private Int32 _supplierFormalDetail;

        /// <summary>仕入伝票番号</summary>
        /// <remarks>仕入伝票番号,入荷伝票番号,注文書番号(発注)を兼ねる。（未発注はゼロ）</remarks>
        private Int32 _supplierSlipNoDetail;

        /// <summary>仕入行番号</summary>
        private Int32 _stockRowNo;

        /// <summary>拠点コード</summary>
        private string _sectionCodeDetail = "";

        /// <summary>部門コード</summary>
        private Int32 _subSectionCodeDetail;

        /// <summary>共通通番</summary>
        private Int64 _commonSeqNo;

        /// <summary>仕入明細通番</summary>
        private Int64 _stockSlipDtlNum;

        /// <summary>仕入形式（元）</summary>
        /// <remarks>0:仕入,1:入荷,2:発注</remarks>
        private Int32 _supplierFormalSrc;

        /// <summary>仕入明細通番（元）</summary>
        /// <remarks>計上時の元データ明細通番をセット</remarks>
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

        /// <summary>仕入入力者コード</summary>
        private string _stockInputCodeDetail = "";

        /// <summary>仕入入力者名称</summary>
        private string _stockInputNameDetail = "";

        /// <summary>仕入担当者コード</summary>
        private string _stockAgentCodeDetail = "";

        /// <summary>仕入担当者名称</summary>
        private string _stockAgentNameDetail = "";

        /// <summary>商品属性</summary>
        private Int32 _goodsKindCode;

        /// <summary>商品メーカーコード</summary>
        /// <remarks>ﾊﾟｯｹｰｼﾞ毎にﾕｰｻﾞｰ登録範囲が異なる</remarks>
        private Int32 _goodsMakerCd;

        /// <summary>メーカー名称</summary>
        private string _makerName = "";

        /// <summary>メーカーカナ名称</summary>
        private string _makerKanaName = "";

        /// <summary>メーカーカナ名称（一式）</summary>
        private string _cmpltMakerKanaName = "";

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

        /// <summary>仕入在庫取寄せ区分</summary>
        /// <remarks>0:取寄せ,1:在庫</remarks>
        private Int32 _stockOrderDivCd;

        /// <summary>オープン価格区分</summary>
        /// <remarks>0:通常／1:オープン価格</remarks>
        private Int32 _openPriceDiv;

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
        /// <remarks>1：切捨て,2：四捨五入,3:切上げ</remarks>
        private Int32 _fracProcStckUnPrc;

        /// <summary>仕入単価（税抜，浮動）</summary>
        /// <remarks>税抜き</remarks>
        private Double _stockUnitPriceFl;

        /// <summary>仕入単価（税込，浮動）</summary>
        /// <remarks>税込み</remarks>
        private Double _stockUnitTaxPriceFl;

        /// <summary>仕入単価変更区分</summary>
        /// <remarks>0:変更なし,1:変更あり　（仕入単価手入力）</remarks>
        private Int32 _stockUnitChngDiv;

        /// <summary>変更前仕入単価（浮動）</summary>
        /// <remarks>税抜き、掛率算出結果</remarks>
        private Double _bfStockUnitPriceFl;

        /// <summary>変更前定価</summary>
        /// <remarks>税抜き、掛率算出結果</remarks>
        private Double _bfListPrice;

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

        /// <summary>仕入数</summary>
        private Double _stockCount;

        /// <summary>発注数量</summary>
        /// <remarks>発注,入荷で使用</remarks>
        private Double _orderCnt;

        /// <summary>発注調整数</summary>
        /// <remarks>現在の発注数は「発注数量＋発注調整数」で算出</remarks>
        private Double _orderAdjustCnt;

        /// <summary>発注残数</summary>
        /// <remarks>発注数量＋発注調整数－仕入数</remarks>
        private Double _orderRemainCnt;

        /// <summary>残数更新日</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _remainCntUpdDate;

        /// <summary>仕入金額（税抜き）</summary>
        private Int64 _stockPriceTaxExc;

        /// <summary>仕入金額（税込み）</summary>
        private Int64 _stockPriceTaxInc;

        /// <summary>仕入商品区分</summary>
        /// <remarks>0:商品,1:商品外,2:消費税調整,3:残高調整,4:買掛用消費税調整,5:買掛用残高調整,6:合計入力,10:買用消費税調整(自動)</remarks>
        private Int32 _stockGoodsCdDetail;

        /// <summary>仕入金額消費税額</summary>
        /// <remarks>仕入金額（税込み）- 仕入金額（税抜き）※消費税調整額も兼ねる</remarks>
        private Int64 _stockPriceConsTaxDetail;

        /// <summary>課税区分</summary>
        /// <remarks>0:課税,1:非課税,2:課税（内税）</remarks>
        private Int32 _taxationCode;

        /// <summary>仕入伝票明細備考1</summary>
        private string _stockDtiSlipNote1 = "";

        /// <summary>販売先コード</summary>
        private Int32 _salesCustomerCode;

        /// <summary>販売先略称</summary>
        private string _salesCustomerSnm = "";

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

        /// <summary>仕入先コード</summary>
        /// <remarks>発注用</remarks>
        private Int32 _supplierCdDetail;

        /// <summary>仕入先略称</summary>
        /// <remarks>発注用</remarks>
        private string _supplierSnmDetail = "";

        /// <summary>納品先コード</summary>
        /// <remarks>発注用</remarks>
        private Int32 _addresseeCodeDetail;

        /// <summary>納品先名称</summary>
        /// <remarks>発注用</remarks>
        private string _addresseeNameDetail = "";

        /// <summary>直送区分</summary>
        /// <remarks>0:直送なし,1:直送あり　（発注書の直送先印字制御）</remarks>
        private Int32 _directSendingCdDetail;

        /// <summary>発注番号</summary>
        /// <remarks>発注用</remarks>
        private string _orderNumber = "";

        /// <summary>注文方法</summary>
        /// <remarks>0:発注書発注,1:FAX送信,2:オンライン発注,4:発注済事後登録</remarks>
        private Int32 _wayToOrder;

        /// <summary>納品完了予定日</summary>
        /// <remarks>発注用　（発注回答納期）</remarks>
        private DateTime _deliGdsCmpltDueDate;

        /// <summary>希望納期</summary>
        /// <remarks>発注用</remarks>
        private DateTime _expectDeliveryDate;

        /// <summary>発注データ作成区分</summary>
        /// <remarks>1:受発注売上入力,2:発注入力,3:在庫補充発注,4:発注点割れ　（発生元）</remarks>
        private Int32 _orderDataCreateDiv;

        /// <summary>発注データ作成日</summary>
        /// <remarks>発注用</remarks>
        private DateTime _orderDataCreateDate;

        /// <summary>発注書発行済区分</summary>
        /// <remarks>0:未発行,1:発行済</remarks>
        private Int32 _orderFormIssuedDiv;

        /// <summary>締日</summary>
        /// <remarks>DD</remarks>
        private Int32 _totalDay;

        /// <summary>次回勘定開始日</summary>
        /// <remarks>01～31まで（省略可能）</remarks>
        private Int32 _nTimeCalcStDate;

        /// <summary>支払先名称</summary>
        private string _payeeName = "";

        /// <summary>支払先名称２</summary>
        private string _payeeName2 = "";

        /// <summary>計上可能数量</summary>
        private Double _addUpEnableCnt;

        /// <summary>計上済数量</summary>
        private Double _alreadyAddUpCnt;

        /// <summary>エディットステータス</summary>
        private Int32 _editStatus;

        /// <summary>共通キー</summary>
        private Guid _dtlRelationGuid;

        /// <summary>企業名称</summary>
        private string _enterpriseName = "";

        /// <summary>更新従業員名称</summary>
        private string _updEmployeeName = "";

        /// <summary>仕入拠点名称</summary>
        private string _stockSectionNm = "";

        /// <summary>仕入計上拠点名称</summary>
        private string _stockAddUpSectionNm = "";

        /// <summary>仕入先消費税転嫁方式名称</summary>
        /// <remarks>伝票単位、明細単位、請求単位</remarks>
        private string _suppCTaxLayMethodNm = "";

        /// <summary>BL商品コード名称</summary>
        private string _bLGoodsName = "";


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

        /// public propaty name  :  SupplierFormal
        /// <summary>仕入形式プロパティ</summary>
        /// <value>0:仕入,1:入荷,2:発注　（受注ステータス）</value>
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
        /// <value>仕入伝票番号,入荷伝票番号,注文書番号(発注)を兼ねる</value>
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

        /// public propaty name  :  DebitNoteDiv
        /// <summary>赤伝区分プロパティ</summary>
        /// <value>0:黒伝,1:赤伝,2:元黒</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   赤伝区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DebitNoteDiv
        {
            get { return _debitNoteDiv; }
            set { _debitNoteDiv = value; }
        }

        /// public propaty name  :  DebitNLnkSuppSlipNo
        /// <summary>赤黒連結仕入伝票番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   赤黒連結仕入伝票番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DebitNLnkSuppSlipNo
        {
            get { return _debitNLnkSuppSlipNo; }
            set { _debitNLnkSuppSlipNo = value; }
        }

        /// public propaty name  :  SupplierSlipCd
        /// <summary>仕入伝票区分プロパティ</summary>
        /// <value>10:仕入,20:返品</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入伝票区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SupplierSlipCd
        {
            get { return _supplierSlipCd; }
            set { _supplierSlipCd = value; }
        }

        /// public propaty name  :  StockGoodsCd
        /// <summary>仕入商品区分プロパティ</summary>
        /// <value>0:商品,1:商品外,2:消費税調整,3:残高調整,4:買掛用消費税調整,5:買掛用残高調整,6:合計入力,10:買用消費税調整(自動),11:相殺,12:相殺(自動)</value>
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

        /// public propaty name  :  AccPayDivCd
        /// <summary>買掛区分プロパティ</summary>
        /// <value>0:買掛なし,1:買掛</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   買掛区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AccPayDivCd
        {
            get { return _accPayDivCd; }
            set { _accPayDivCd = value; }
        }

        /// public propaty name  :  StockSectionCd
        /// <summary>仕入拠点コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string StockSectionCd
        {
            get { return _stockSectionCd; }
            set { _stockSectionCd = value; }
        }

        /// public propaty name  :  StockAddUpSectionCd
        /// <summary>仕入計上拠点コードプロパティ</summary>
        /// <value>文字型 仕入計上対象の拠点コード(拠点制御の支払計上拠点のこと)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入計上拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string StockAddUpSectionCd
        {
            get { return _stockAddUpSectionCd; }
            set { _stockAddUpSectionCd = value; }
        }

        /// public propaty name  :  StockSlipUpdateCd
        /// <summary>仕入伝票更新区分プロパティ</summary>
        /// <value>0:未更新,1:更新あり</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入伝票更新区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 StockSlipUpdateCd
        {
            get { return _stockSlipUpdateCd; }
            set { _stockSlipUpdateCd = value; }
        }

        /// public propaty name  :  InputDay
        /// <summary>入力日プロパティ</summary>
        /// <value>YYYYMMDD　（更新年月日）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入力日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime InputDay
        {
            get { return _inputDay; }
            set { _inputDay = value; }
        }

        /// public propaty name  :  InputDayJpFormal
        /// <summary>入力日 和暦プロパティ</summary>
        /// <value>YYYYMMDD　（更新年月日）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入力日 和暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string InputDayJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _inputDay); }
            set { }
        }

        /// public propaty name  :  InputDayJpInFormal
        /// <summary>入力日 和暦(略)プロパティ</summary>
        /// <value>YYYYMMDD　（更新年月日）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入力日 和暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string InputDayJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _inputDay); }
            set { }
        }

        /// public propaty name  :  InputDayAdFormal
        /// <summary>入力日 西暦プロパティ</summary>
        /// <value>YYYYMMDD　（更新年月日）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入力日 西暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string InputDayAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _inputDay); }
            set { }
        }

        /// public propaty name  :  InputDayAdInFormal
        /// <summary>入力日 西暦(略)プロパティ</summary>
        /// <value>YYYYMMDD　（更新年月日）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入力日 西暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string InputDayAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _inputDay); }
            set { }
        }

        /// public propaty name  :  ArrivalGoodsDay
        /// <summary>入荷日プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入荷日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime ArrivalGoodsDay
        {
            get { return _arrivalGoodsDay; }
            set { _arrivalGoodsDay = value; }
        }

        /// public propaty name  :  ArrivalGoodsDayJpFormal
        /// <summary>入荷日 和暦プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入荷日 和暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ArrivalGoodsDayJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _arrivalGoodsDay); }
            set { }
        }

        /// public propaty name  :  ArrivalGoodsDayJpInFormal
        /// <summary>入荷日 和暦(略)プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入荷日 和暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ArrivalGoodsDayJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _arrivalGoodsDay); }
            set { }
        }

        /// public propaty name  :  ArrivalGoodsDayAdFormal
        /// <summary>入荷日 西暦プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入荷日 西暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ArrivalGoodsDayAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _arrivalGoodsDay); }
            set { }
        }

        /// public propaty name  :  ArrivalGoodsDayAdInFormal
        /// <summary>入荷日 西暦(略)プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入荷日 西暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ArrivalGoodsDayAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _arrivalGoodsDay); }
            set { }
        }

        /// public propaty name  :  StockDate
        /// <summary>仕入日プロパティ</summary>
        /// <value>YYYYMMDD</value>
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

        /// public propaty name  :  StockDateJpFormal
        /// <summary>仕入日 和暦プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入日 和暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string StockDateJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _stockDate); }
            set { }
        }

        /// public propaty name  :  StockDateJpInFormal
        /// <summary>仕入日 和暦(略)プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入日 和暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string StockDateJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _stockDate); }
            set { }
        }

        /// public propaty name  :  StockDateAdFormal
        /// <summary>仕入日 西暦プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入日 西暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string StockDateAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _stockDate); }
            set { }
        }

        /// public propaty name  :  StockDateAdInFormal
        /// <summary>仕入日 西暦(略)プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入日 西暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string StockDateAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _stockDate); }
            set { }
        }

        /// public propaty name  :  StockAddUpADate
        /// <summary>仕入計上日付プロパティ</summary>
        /// <value>仕入計上日</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入計上日付プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime StockAddUpADate
        {
            get { return _stockAddUpADate; }
            set { _stockAddUpADate = value; }
        }

        /// public propaty name  :  StockAddUpADateJpFormal
        /// <summary>仕入計上日付 和暦プロパティ</summary>
        /// <value>仕入計上日</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入計上日付 和暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string StockAddUpADateJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _stockAddUpADate); }
            set { }
        }

        /// public propaty name  :  StockAddUpADateJpInFormal
        /// <summary>仕入計上日付 和暦(略)プロパティ</summary>
        /// <value>仕入計上日</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入計上日付 和暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string StockAddUpADateJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _stockAddUpADate); }
            set { }
        }

        /// public propaty name  :  StockAddUpADateAdFormal
        /// <summary>仕入計上日付 西暦プロパティ</summary>
        /// <value>仕入計上日</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入計上日付 西暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string StockAddUpADateAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _stockAddUpADate); }
            set { }
        }

        /// public propaty name  :  StockAddUpADateAdInFormal
        /// <summary>仕入計上日付 西暦(略)プロパティ</summary>
        /// <value>仕入計上日</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入計上日付 西暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string StockAddUpADateAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _stockAddUpADate); }
            set { }
        }

        /// public propaty name  :  DelayPaymentDiv
        /// <summary>来勘区分プロパティ</summary>
        /// <value>0:当月(来勘なし),1:来月,2:再来月…9:9ヵ月後</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   来勘区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DelayPaymentDiv
        {
            get { return _delayPaymentDiv; }
            set { _delayPaymentDiv = value; }
        }

        /// public propaty name  :  PayeeCode
        /// <summary>支払先コードプロパティ</summary>
        /// <value>支払先(精算先)コード。支払締時は支払先単位で集計・計算。</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PayeeCode
        {
            get { return _payeeCode; }
            set { _payeeCode = value; }
        }

        /// public propaty name  :  PayeeSnm
        /// <summary>支払先略称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払先略称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PayeeSnm
        {
            get { return _payeeSnm; }
            set { _payeeSnm = value; }
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

        /// public propaty name  :  SupplierNm1
        /// <summary>仕入先名1プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先名1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SupplierNm1
        {
            get { return _supplierNm1; }
            set { _supplierNm1 = value; }
        }

        /// public propaty name  :  SupplierNm2
        /// <summary>仕入先名2プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先名2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SupplierNm2
        {
            get { return _supplierNm2; }
            set { _supplierNm2 = value; }
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

        /// public propaty name  :  BusinessTypeCode
        /// <summary>業種コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   業種コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BusinessTypeCode
        {
            get { return _businessTypeCode; }
            set { _businessTypeCode = value; }
        }

        /// public propaty name  :  BusinessTypeName
        /// <summary>業種名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   業種名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string BusinessTypeName
        {
            get { return _businessTypeName; }
            set { _businessTypeName = value; }
        }

        /// public propaty name  :  SalesAreaCode
        /// <summary>販売エリアコードプロパティ</summary>
        /// <value>地区コード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   販売エリアコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SalesAreaCode
        {
            get { return _salesAreaCode; }
            set { _salesAreaCode = value; }
        }

        /// public propaty name  :  SalesAreaName
        /// <summary>販売エリア名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   販売エリア名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SalesAreaName
        {
            get { return _salesAreaName; }
            set { _salesAreaName = value; }
        }

        /// public propaty name  :  StockInputCode
        /// <summary>仕入入力者コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入入力者コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string StockInputCode
        {
            get { return _stockInputCode; }
            set { _stockInputCode = value; }
        }

        /// public propaty name  :  StockInputName
        /// <summary>仕入入力者名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入入力者名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string StockInputName
        {
            get { return _stockInputName; }
            set { _stockInputName = value; }
        }

        /// public propaty name  :  StockAgentCode
        /// <summary>仕入担当者コードプロパティ</summary>
        /// <value>発注者をセット</value>
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
        /// <value>発注者をセット</value>
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

        /// public propaty name  :  SuppTtlAmntDspWayCd
        /// <summary>仕入先総額表示方法区分プロパティ</summary>
        /// <value>0:総額表示しない（税抜き）,1:総額表示する（税込み）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先総額表示方法区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SuppTtlAmntDspWayCd
        {
            get { return _suppTtlAmntDspWayCd; }
            set { _suppTtlAmntDspWayCd = value; }
        }

        /// public propaty name  :  TtlAmntDispRateApy
        /// <summary>総額表示掛率適用区分プロパティ</summary>
        /// <value>0：基準価格(税込)×掛率, 1:基準価格(税抜)×掛率</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   総額表示掛率適用区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 TtlAmntDispRateApy
        {
            get { return _ttlAmntDispRateApy; }
            set { _ttlAmntDispRateApy = value; }
        }

        /// public propaty name  :  StockTotalPrice
        /// <summary>仕入金額合計プロパティ</summary>
        /// <value>仕入金額合計＝仕入金額計（税込み）＋非課税対象額合計</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入金額合計プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 StockTotalPrice
        {
            get { return _stockTotalPrice; }
            set { _stockTotalPrice = value; }
        }

        /// public propaty name  :  StockSubttlPrice
        /// <summary>仕入金額小計プロパティ</summary>
        /// <value>仕入金額小計＝仕入金額計（税抜き）＋非課税対象額合計</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入金額小計プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 StockSubttlPrice
        {
            get { return _stockSubttlPrice; }
            set { _stockSubttlPrice = value; }
        }

        /// public propaty name  :  StockTtlPricTaxInc
        /// <summary>仕入金額計（税込み）プロパティ</summary>
        /// <value>外税時：税抜き＋消費税、内税時：内税価格（税込）の集計</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入金額計（税込み）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 StockTtlPricTaxInc
        {
            get { return _stockTtlPricTaxInc; }
            set { _stockTtlPricTaxInc = value; }
        }

        /// public propaty name  :  StockTtlPricTaxExc
        /// <summary>仕入金額計（税抜き）プロパティ</summary>
        /// <value>外税時：税抜価格の集計、内税時：内税価格（税込）の集計－消費税</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入金額計（税抜き）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 StockTtlPricTaxExc
        {
            get { return _stockTtlPricTaxExc; }
            set { _stockTtlPricTaxExc = value; }
        }

        /// public propaty name  :  StockNetPrice
        /// <summary>仕入正価金額プロパティ</summary>
        /// <value>値引前の税抜仕入金額</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入正価金額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 StockNetPrice
        {
            get { return _stockNetPrice; }
            set { _stockNetPrice = value; }
        }

        /// public propaty name  :  StockPriceConsTax
        /// <summary>仕入金額消費税額プロパティ</summary>
        /// <value>仕入金額消費税額（外税）+仕入金額消費税額（内税）</value>
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

        /// public propaty name  :  TtlItdedStcOutTax
        /// <summary>仕入外税対象額合計プロパティ</summary>
        /// <value>外税対象金額の集計（税抜、値引含まず）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入外税対象額合計プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 TtlItdedStcOutTax
        {
            get { return _ttlItdedStcOutTax; }
            set { _ttlItdedStcOutTax = value; }
        }

        /// public propaty name  :  TtlItdedStcInTax
        /// <summary>仕入内税対象額合計プロパティ</summary>
        /// <value>内税対象金額の集計（税抜、値引含まず） </value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入内税対象額合計プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 TtlItdedStcInTax
        {
            get { return _ttlItdedStcInTax; }
            set { _ttlItdedStcInTax = value; }
        }

        /// public propaty name  :  TtlItdedStcTaxFree
        /// <summary>仕入非課税対象額合計プロパティ</summary>
        /// <value>非課税対象金額の集計（値引含まず）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入非課税対象額合計プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 TtlItdedStcTaxFree
        {
            get { return _ttlItdedStcTaxFree; }
            set { _ttlItdedStcTaxFree = value; }
        }

        /// public propaty name  :  StockOutTax
        /// <summary>仕入金額消費税額（外税）プロパティ</summary>
        /// <value>値引前の外税商品の消費税</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入金額消費税額（外税）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 StockOutTax
        {
            get { return _stockOutTax; }
            set { _stockOutTax = value; }
        }

        /// public propaty name  :  StckPrcConsTaxInclu
        /// <summary>仕入金額消費税額（内税）プロパティ</summary>
        /// <value>値引前の内税商品の消費税</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入金額消費税額（内税）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 StckPrcConsTaxInclu
        {
            get { return _stckPrcConsTaxInclu; }
            set { _stckPrcConsTaxInclu = value; }
        }

        /// public propaty name  :  StckDisTtlTaxExc
        /// <summary>仕入値引金額計（税抜き）プロパティ</summary>
        /// <value>仕入値引外税対象額合計+仕入値引内税対象額合計+仕入値引非課税対象額合計</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入値引金額計（税抜き）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 StckDisTtlTaxExc
        {
            get { return _stckDisTtlTaxExc; }
            set { _stckDisTtlTaxExc = value; }
        }

        /// public propaty name  :  ItdedStockDisOutTax
        /// <summary>仕入値引外税対象額合計プロパティ</summary>
        /// <value>外税商品値引の外税対象額（税抜）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入値引外税対象額合計プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 ItdedStockDisOutTax
        {
            get { return _itdedStockDisOutTax; }
            set { _itdedStockDisOutTax = value; }
        }

        /// public propaty name  :  ItdedStockDisInTax
        /// <summary>仕入値引内税対象額合計プロパティ</summary>
        /// <value>内税商品値引の内税対象額（税抜）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入値引内税対象額合計プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 ItdedStockDisInTax
        {
            get { return _itdedStockDisInTax; }
            set { _itdedStockDisInTax = value; }
        }

        /// public propaty name  :  ItdedStockDisTaxFre
        /// <summary>仕入値引非課税対象額合計プロパティ</summary>
        /// <value>非課税商品値引の非課税対象額</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入値引非課税対象額合計プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 ItdedStockDisTaxFre
        {
            get { return _itdedStockDisTaxFre; }
            set { _itdedStockDisTaxFre = value; }
        }

        /// public propaty name  :  StockDisOutTax
        /// <summary>仕入値引消費税額（外税）プロパティ</summary>
        /// <value>外税商品値引の消費税額</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入値引消費税額（外税）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 StockDisOutTax
        {
            get { return _stockDisOutTax; }
            set { _stockDisOutTax = value; }
        }

        /// public propaty name  :  StckDisTtlTaxInclu
        /// <summary>仕入値引消費税額（内税）プロパティ</summary>
        /// <value>内税商品値引の消費税額</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入値引消費税額（内税）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 StckDisTtlTaxInclu
        {
            get { return _stckDisTtlTaxInclu; }
            set { _stckDisTtlTaxInclu = value; }
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

        /// public propaty name  :  SuppCTaxLayCd
        /// <summary>仕入先消費税転嫁方式コードプロパティ</summary>
        /// <value>0:伝票単位1:明細単位2:支払親 3:支払子 9:非課税</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先消費税転嫁方式コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SuppCTaxLayCd
        {
            get { return _suppCTaxLayCd; }
            set { _suppCTaxLayCd = value; }
        }

        /// public propaty name  :  SupplierConsTaxRate
        /// <summary>仕入先消費税税率プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先消費税税率プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double SupplierConsTaxRate
        {
            get { return _supplierConsTaxRate; }
            set { _supplierConsTaxRate = value; }
        }

        /// public propaty name  :  AccPayConsTax
        /// <summary>買掛消費税プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   買掛消費税プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 AccPayConsTax
        {
            get { return _accPayConsTax; }
            set { _accPayConsTax = value; }
        }

        /// public propaty name  :  StockFractionProcCd
        /// <summary>仕入端数処理区分プロパティ</summary>
        /// <value>1:切捨て,2:四捨五入,3:切上げ　（消費税）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入端数処理区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 StockFractionProcCd
        {
            get { return _stockFractionProcCd; }
            set { _stockFractionProcCd = value; }
        }

        /// public propaty name  :  AutoPayment
        /// <summary>自動支払区分プロパティ</summary>
        /// <value>0:通常支払,1:自動支払</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自動支払区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AutoPayment
        {
            get { return _autoPayment; }
            set { _autoPayment = value; }
        }

        /// public propaty name  :  AutoPaySlipNum
        /// <summary>自動支払伝票番号プロパティ</summary>
        /// <value>自動支払時の支払伝票番号</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自動支払伝票番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AutoPaySlipNum
        {
            get { return _autoPaySlipNum; }
            set { _autoPaySlipNum = value; }
        }

        /// public propaty name  :  RetGoodsReasonDiv
        /// <summary>返品理由コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   返品理由コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 RetGoodsReasonDiv
        {
            get { return _retGoodsReasonDiv; }
            set { _retGoodsReasonDiv = value; }
        }

        /// public propaty name  :  RetGoodsReason
        /// <summary>返品理由プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   返品理由プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string RetGoodsReason
        {
            get { return _retGoodsReason; }
            set { _retGoodsReason = value; }
        }

        /// public propaty name  :  PartySaleSlipNum
        /// <summary>相手先伝票番号プロパティ</summary>
        /// <value>仕入先伝票番号に使用する</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   相手先伝票番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PartySaleSlipNum
        {
            get { return _partySaleSlipNum; }
            set { _partySaleSlipNum = value; }
        }

        /// public propaty name  :  SupplierSlipNote1
        /// <summary>仕入伝票備考1プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入伝票備考1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SupplierSlipNote1
        {
            get { return _supplierSlipNote1; }
            set { _supplierSlipNote1 = value; }
        }

        /// public propaty name  :  SupplierSlipNote2
        /// <summary>仕入伝票備考2プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入伝票備考2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SupplierSlipNote2
        {
            get { return _supplierSlipNote2; }
            set { _supplierSlipNote2 = value; }
        }

        /// public propaty name  :  DetailRowCount
        /// <summary>明細行数プロパティ</summary>
        /// <value>伝票内の明細の行数（諸費用明細は除く）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   明細行数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DetailRowCount
        {
            get { return _detailRowCount; }
            set { _detailRowCount = value; }
        }

        /// public propaty name  :  EdiSendDate
        /// <summary>ＥＤＩ送信日プロパティ</summary>
        /// <value>YYYYMMDD （ErectricDataInterface）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ＥＤＩ送信日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime EdiSendDate
        {
            get { return _ediSendDate; }
            set { _ediSendDate = value; }
        }

        /// public propaty name  :  EdiSendDateJpFormal
        /// <summary>ＥＤＩ送信日 和暦プロパティ</summary>
        /// <value>YYYYMMDD （ErectricDataInterface）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ＥＤＩ送信日 和暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EdiSendDateJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _ediSendDate); }
            set { }
        }

        /// public propaty name  :  EdiSendDateJpInFormal
        /// <summary>ＥＤＩ送信日 和暦(略)プロパティ</summary>
        /// <value>YYYYMMDD （ErectricDataInterface）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ＥＤＩ送信日 和暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EdiSendDateJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _ediSendDate); }
            set { }
        }

        /// public propaty name  :  EdiSendDateAdFormal
        /// <summary>ＥＤＩ送信日 西暦プロパティ</summary>
        /// <value>YYYYMMDD （ErectricDataInterface）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ＥＤＩ送信日 西暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EdiSendDateAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _ediSendDate); }
            set { }
        }

        /// public propaty name  :  EdiSendDateAdInFormal
        /// <summary>ＥＤＩ送信日 西暦(略)プロパティ</summary>
        /// <value>YYYYMMDD （ErectricDataInterface）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ＥＤＩ送信日 西暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EdiSendDateAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _ediSendDate); }
            set { }
        }

        /// public propaty name  :  EdiTakeInDate
        /// <summary>ＥＤＩ取込日プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ＥＤＩ取込日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime EdiTakeInDate
        {
            get { return _ediTakeInDate; }
            set { _ediTakeInDate = value; }
        }

        /// public propaty name  :  EdiTakeInDateJpFormal
        /// <summary>ＥＤＩ取込日 和暦プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ＥＤＩ取込日 和暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EdiTakeInDateJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _ediTakeInDate); }
            set { }
        }

        /// public propaty name  :  EdiTakeInDateJpInFormal
        /// <summary>ＥＤＩ取込日 和暦(略)プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ＥＤＩ取込日 和暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EdiTakeInDateJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _ediTakeInDate); }
            set { }
        }

        /// public propaty name  :  EdiTakeInDateAdFormal
        /// <summary>ＥＤＩ取込日 西暦プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ＥＤＩ取込日 西暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EdiTakeInDateAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _ediTakeInDate); }
            set { }
        }

        /// public propaty name  :  EdiTakeInDateAdInFormal
        /// <summary>ＥＤＩ取込日 西暦(略)プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ＥＤＩ取込日 西暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EdiTakeInDateAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _ediTakeInDate); }
            set { }
        }

        /// public propaty name  :  UoeRemark1
        /// <summary>ＵＯＥリマーク１プロパティ</summary>
        /// <value>UserOrderEntory</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ＵＯＥリマーク１プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UoeRemark1
        {
            get { return _uoeRemark1; }
            set { _uoeRemark1 = value; }
        }

        /// public propaty name  :  UoeRemark2
        /// <summary>ＵＯＥリマーク２プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ＵＯＥリマーク２プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UoeRemark2
        {
            get { return _uoeRemark2; }
            set { _uoeRemark2 = value; }
        }

        /// public propaty name  :  SlipPrintDivCd
        /// <summary>伝票発行区分プロパティ</summary>
        /// <value>0:しない 1:する</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票発行区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SlipPrintDivCd
        {
            get { return _slipPrintDivCd; }
            set { _slipPrintDivCd = value; }
        }

        /// public propaty name  :  SlipPrintFinishCd
        /// <summary>伝票発行済区分プロパティ</summary>
        /// <value>0:未発行 1:発行済</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票発行済区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SlipPrintFinishCd
        {
            get { return _slipPrintFinishCd; }
            set { _slipPrintFinishCd = value; }
        }

        /// public propaty name  :  StockSlipPrintDate
        /// <summary>仕入伝票発行日プロパティ</summary>
        /// <value>入荷では入荷伝票発行日（発注書発行日もここを使用）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入伝票発行日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime StockSlipPrintDate
        {
            get { return _stockSlipPrintDate; }
            set { _stockSlipPrintDate = value; }
        }

        /// public propaty name  :  StockSlipPrintDateJpFormal
        /// <summary>仕入伝票発行日 和暦プロパティ</summary>
        /// <value>入荷では入荷伝票発行日（発注書発行日もここを使用）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入伝票発行日 和暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string StockSlipPrintDateJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _stockSlipPrintDate); }
            set { }
        }

        /// public propaty name  :  StockSlipPrintDateJpInFormal
        /// <summary>仕入伝票発行日 和暦(略)プロパティ</summary>
        /// <value>入荷では入荷伝票発行日（発注書発行日もここを使用）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入伝票発行日 和暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string StockSlipPrintDateJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _stockSlipPrintDate); }
            set { }
        }

        /// public propaty name  :  StockSlipPrintDateAdFormal
        /// <summary>仕入伝票発行日 西暦プロパティ</summary>
        /// <value>入荷では入荷伝票発行日（発注書発行日もここを使用）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入伝票発行日 西暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string StockSlipPrintDateAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _stockSlipPrintDate); }
            set { }
        }

        /// public propaty name  :  StockSlipPrintDateAdInFormal
        /// <summary>仕入伝票発行日 西暦(略)プロパティ</summary>
        /// <value>入荷では入荷伝票発行日（発注書発行日もここを使用）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入伝票発行日 西暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string StockSlipPrintDateAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _stockSlipPrintDate); }
            set { }
        }

        /// public propaty name  :  SlipPrtSetPaperId
        /// <summary>伝票印刷設定用帳票IDプロパティ</summary>
        /// <value>仕入形式とセットで伝票タイプ管理マスタを参照　（発注,入荷用）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票印刷設定用帳票IDプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SlipPrtSetPaperId
        {
            get { return _slipPrtSetPaperId; }
            set { _slipPrtSetPaperId = value; }
        }

        /// public propaty name  :  SlipAddressDiv
        /// <summary>伝票住所区分プロパティ</summary>
        /// <value>1:得意先,2:納入先</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票住所区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SlipAddressDiv
        {
            get { return _slipAddressDiv; }
            set { _slipAddressDiv = value; }
        }

        /// public propaty name  :  AddresseeCode
        /// <summary>納品先コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   納品先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AddresseeCode
        {
            get { return _addresseeCode; }
            set { _addresseeCode = value; }
        }

        /// public propaty name  :  AddresseeName
        /// <summary>納品先名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   納品先名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AddresseeName
        {
            get { return _addresseeName; }
            set { _addresseeName = value; }
        }

        /// public propaty name  :  AddresseeName2
        /// <summary>納品先名称2プロパティ</summary>
        /// <value>追加(登録漏れ) 塩原</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   納品先名称2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AddresseeName2
        {
            get { return _addresseeName2; }
            set { _addresseeName2 = value; }
        }

        /// public propaty name  :  AddresseePostNo
        /// <summary>納品先郵便番号プロパティ</summary>
        /// <value>伝票住所区分に従う内容</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   納品先郵便番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AddresseePostNo
        {
            get { return _addresseePostNo; }
            set { _addresseePostNo = value; }
        }

        /// public propaty name  :  AddresseeAddr1
        /// <summary>納品先住所1(都道府県市区郡・町村・字)プロパティ</summary>
        /// <value>伝票住所区分に従う内容</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   納品先住所1(都道府県市区郡・町村・字)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AddresseeAddr1
        {
            get { return _addresseeAddr1; }
            set { _addresseeAddr1 = value; }
        }

        /// public propaty name  :  AddresseeAddr3
        /// <summary>納品先住所3(番地)プロパティ</summary>
        /// <value>伝票住所区分に従う内容</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   納品先住所3(番地)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AddresseeAddr3
        {
            get { return _addresseeAddr3; }
            set { _addresseeAddr3 = value; }
        }

        /// public propaty name  :  AddresseeAddr4
        /// <summary>納品先住所4(アパート名称)プロパティ</summary>
        /// <value>伝票住所区分に従う内容</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   納品先住所4(アパート名称)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AddresseeAddr4
        {
            get { return _addresseeAddr4; }
            set { _addresseeAddr4 = value; }
        }

        /// public propaty name  :  AddresseeTelNo
        /// <summary>納品先電話番号プロパティ</summary>
        /// <value>伝票住所区分に従う内容</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   納品先電話番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AddresseeTelNo
        {
            get { return _addresseeTelNo; }
            set { _addresseeTelNo = value; }
        }

        /// public propaty name  :  AddresseeFaxNo
        /// <summary>納品先FAX番号プロパティ</summary>
        /// <value>伝票住所区分に従う内容</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   納品先FAX番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AddresseeFaxNo
        {
            get { return _addresseeFaxNo; }
            set { _addresseeFaxNo = value; }
        }

        /// public propaty name  :  DirectSendingCd
        /// <summary>直送区分プロパティ</summary>
        /// <value>0:直送なし,1:直送あり　（発注書の直送先印字制御）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   直送区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DirectSendingCd
        {
            get { return _directSendingCd; }
            set { _directSendingCd = value; }
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

        /// public propaty name  :  SupplierFormalDetail
        /// <summary>仕入形式プロパティ</summary>
        /// <value>0:仕入,1:入荷,2:発注　（受注ステータス）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入形式プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SupplierFormalDetail
        {
            get { return _supplierFormalDetail; }
            set { _supplierFormalDetail = value; }
        }

        /// public propaty name  :  SupplierSlipNoDetail
        /// <summary>仕入伝票番号プロパティ</summary>
        /// <value>仕入伝票番号,入荷伝票番号,注文書番号(発注)を兼ねる。（未発注はゼロ）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入伝票番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SupplierSlipNoDetail
        {
            get { return _supplierSlipNoDetail; }
            set { _supplierSlipNoDetail = value; }
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

        /// public propaty name  :  SectionCodeDetail
        /// <summary>拠点コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SectionCodeDetail
        {
            get { return _sectionCodeDetail; }
            set { _sectionCodeDetail = value; }
        }

        /// public propaty name  :  SubSectionCodeDetail
        /// <summary>部門コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   部門コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SubSectionCodeDetail
        {
            get { return _subSectionCodeDetail; }
            set { _subSectionCodeDetail = value; }
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
        /// <value>0:仕入,1:入荷,2:発注</value>
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
        /// <value>計上時の元データ明細通番をセット</value>
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

        /// public propaty name  :  StockInputCodeDetail
        /// <summary>仕入入力者コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入入力者コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string StockInputCodeDetail
        {
            get { return _stockInputCodeDetail; }
            set { _stockInputCodeDetail = value; }
        }

        /// public propaty name  :  StockInputNameDetail
        /// <summary>仕入入力者名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入入力者名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string StockInputNameDetail
        {
            get { return _stockInputNameDetail; }
            set { _stockInputNameDetail = value; }
        }

        /// public propaty name  :  StockAgentCodeDetail
        /// <summary>仕入担当者コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入担当者コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string StockAgentCodeDetail
        {
            get { return _stockAgentCodeDetail; }
            set { _stockAgentCodeDetail = value; }
        }

        /// public propaty name  :  StockAgentNameDetail
        /// <summary>仕入担当者名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入担当者名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string StockAgentNameDetail
        {
            get { return _stockAgentNameDetail; }
            set { _stockAgentNameDetail = value; }
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
        /// <value>1：切捨て,2：四捨五入,3:切上げ</value>
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
        /// <value>0:変更なし,1:変更あり　（仕入単価手入力）</value>
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

        /// public propaty name  :  OrderCnt
        /// <summary>発注数量プロパティ</summary>
        /// <value>発注,入荷で使用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   発注数量プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double OrderCnt
        {
            get { return _orderCnt; }
            set { _orderCnt = value; }
        }

        /// public propaty name  :  OrderAdjustCnt
        /// <summary>発注調整数プロパティ</summary>
        /// <value>現在の発注数は「発注数量＋発注調整数」で算出</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   発注調整数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double OrderAdjustCnt
        {
            get { return _orderAdjustCnt; }
            set { _orderAdjustCnt = value; }
        }

        /// public propaty name  :  OrderRemainCnt
        /// <summary>発注残数プロパティ</summary>
        /// <value>発注数量＋発注調整数－仕入数</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   発注残数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double OrderRemainCnt
        {
            get { return _orderRemainCnt; }
            set { _orderRemainCnt = value; }
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

        /// public propaty name  :  StockGoodsCdDetail
        /// <summary>仕入商品区分プロパティ</summary>
        /// <value>0:商品,1:商品外,2:消費税調整,3:残高調整,4:買掛用消費税調整,5:買掛用残高調整,6:合計入力,10:買用消費税調整(自動)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入商品区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 StockGoodsCdDetail
        {
            get { return _stockGoodsCdDetail; }
            set { _stockGoodsCdDetail = value; }
        }

        /// public propaty name  :  StockPriceConsTaxDetail
        /// <summary>仕入金額消費税額プロパティ</summary>
        /// <value>仕入金額（税込み）- 仕入金額（税抜き）※消費税調整額も兼ねる</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入金額消費税額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 StockPriceConsTaxDetail
        {
            get { return _stockPriceConsTaxDetail; }
            set { _stockPriceConsTaxDetail = value; }
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

        /// public propaty name  :  SalesCustomerSnm
        /// <summary>販売先略称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   販売先略称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SalesCustomerSnm
        {
            get { return _salesCustomerSnm; }
            set { _salesCustomerSnm = value; }
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

        /// public propaty name  :  SupplierCdDetail
        /// <summary>仕入先コードプロパティ</summary>
        /// <value>発注用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SupplierCdDetail
        {
            get { return _supplierCdDetail; }
            set { _supplierCdDetail = value; }
        }

        /// public propaty name  :  SupplierSnmDetail
        /// <summary>仕入先略称プロパティ</summary>
        /// <value>発注用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先略称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SupplierSnmDetail
        {
            get { return _supplierSnmDetail; }
            set { _supplierSnmDetail = value; }
        }

        /// public propaty name  :  AddresseeCodeDetail
        /// <summary>納品先コードプロパティ</summary>
        /// <value>発注用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   納品先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AddresseeCodeDetail
        {
            get { return _addresseeCodeDetail; }
            set { _addresseeCodeDetail = value; }
        }

        /// public propaty name  :  AddresseeNameDetail
        /// <summary>納品先名称プロパティ</summary>
        /// <value>発注用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   納品先名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AddresseeNameDetail
        {
            get { return _addresseeNameDetail; }
            set { _addresseeNameDetail = value; }
        }

        /// public propaty name  :  DirectSendingCdDetail
        /// <summary>直送区分プロパティ</summary>
        /// <value>0:直送なし,1:直送あり　（発注書の直送先印字制御）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   直送区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DirectSendingCdDetail
        {
            get { return _directSendingCdDetail; }
            set { _directSendingCdDetail = value; }
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

        /// public propaty name  :  DeliGdsCmpltDueDate
        /// <summary>納品完了予定日プロパティ</summary>
        /// <value>発注用　（発注回答納期）</value>
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
        /// <value>発注用　（発注回答納期）</value>
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
        /// <value>発注用　（発注回答納期）</value>
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
        /// <value>発注用　（発注回答納期）</value>
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
        /// <value>発注用　（発注回答納期）</value>
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

        /// public propaty name  :  ExpectDeliveryDate
        /// <summary>希望納期プロパティ</summary>
        /// <value>発注用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   希望納期プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime ExpectDeliveryDate
        {
            get { return _expectDeliveryDate; }
            set { _expectDeliveryDate = value; }
        }

        /// public propaty name  :  ExpectDeliveryDateJpFormal
        /// <summary>希望納期 和暦プロパティ</summary>
        /// <value>発注用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   希望納期 和暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ExpectDeliveryDateJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _expectDeliveryDate); }
            set { }
        }

        /// public propaty name  :  ExpectDeliveryDateJpInFormal
        /// <summary>希望納期 和暦(略)プロパティ</summary>
        /// <value>発注用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   希望納期 和暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ExpectDeliveryDateJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _expectDeliveryDate); }
            set { }
        }

        /// public propaty name  :  ExpectDeliveryDateAdFormal
        /// <summary>希望納期 西暦プロパティ</summary>
        /// <value>発注用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   希望納期 西暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ExpectDeliveryDateAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _expectDeliveryDate); }
            set { }
        }

        /// public propaty name  :  ExpectDeliveryDateAdInFormal
        /// <summary>希望納期 西暦(略)プロパティ</summary>
        /// <value>発注用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   希望納期 西暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ExpectDeliveryDateAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _expectDeliveryDate); }
            set { }
        }

        /// public propaty name  :  OrderDataCreateDiv
        /// <summary>発注データ作成区分プロパティ</summary>
        /// <value>1:受発注売上入力,2:発注入力,3:在庫補充発注,4:発注点割れ　（発生元）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   発注データ作成区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 OrderDataCreateDiv
        {
            get { return _orderDataCreateDiv; }
            set { _orderDataCreateDiv = value; }
        }

        /// public propaty name  :  OrderDataCreateDate
        /// <summary>発注データ作成日プロパティ</summary>
        /// <value>発注用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   発注データ作成日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime OrderDataCreateDate
        {
            get { return _orderDataCreateDate; }
            set { _orderDataCreateDate = value; }
        }

        /// public propaty name  :  OrderDataCreateDateJpFormal
        /// <summary>発注データ作成日 和暦プロパティ</summary>
        /// <value>発注用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   発注データ作成日 和暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string OrderDataCreateDateJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _orderDataCreateDate); }
            set { }
        }

        /// public propaty name  :  OrderDataCreateDateJpInFormal
        /// <summary>発注データ作成日 和暦(略)プロパティ</summary>
        /// <value>発注用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   発注データ作成日 和暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string OrderDataCreateDateJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _orderDataCreateDate); }
            set { }
        }

        /// public propaty name  :  OrderDataCreateDateAdFormal
        /// <summary>発注データ作成日 西暦プロパティ</summary>
        /// <value>発注用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   発注データ作成日 西暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string OrderDataCreateDateAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _orderDataCreateDate); }
            set { }
        }

        /// public propaty name  :  OrderDataCreateDateAdInFormal
        /// <summary>発注データ作成日 西暦(略)プロパティ</summary>
        /// <value>発注用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   発注データ作成日 西暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string OrderDataCreateDateAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _orderDataCreateDate); }
            set { }
        }

        /// public propaty name  :  OrderFormIssuedDiv
        /// <summary>発注書発行済区分プロパティ</summary>
        /// <value>0:未発行,1:発行済</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   発注書発行済区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 OrderFormIssuedDiv
        {
            get { return _orderFormIssuedDiv; }
            set { _orderFormIssuedDiv = value; }
        }

        /// public propaty name  :  TotalDay
        /// <summary>締日プロパティ</summary>
        /// <value>DD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   締日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 TotalDay
        {
            get { return _totalDay; }
            set { _totalDay = value; }
        }

        /// public propaty name  :  NTimeCalcStDate
        /// <summary>次回勘定開始日プロパティ</summary>
        /// <value>01～31まで（省略可能）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   次回勘定開始日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 NTimeCalcStDate
        {
            get { return _nTimeCalcStDate; }
            set { _nTimeCalcStDate = value; }
        }

        /// public propaty name  :  PayeeName
        /// <summary>支払先名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払先名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PayeeName
        {
            get { return _payeeName; }
            set { _payeeName = value; }
        }

        /// public propaty name  :  PayeeName2
        /// <summary>支払先名称２プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払先名称２プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PayeeName2
        {
            get { return _payeeName2; }
            set { _payeeName2 = value; }
        }

        /// public propaty name  :  AddUpEnableCnt
        /// <summary>計上可能数量プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   計上可能数量プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double AddUpEnableCnt
        {
            get { return _addUpEnableCnt; }
            set { _addUpEnableCnt = value; }
        }

        /// public propaty name  :  AlreadyAddUpCnt
        /// <summary>計上済数量プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   計上済数量プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double AlreadyAddUpCnt
        {
            get { return _alreadyAddUpCnt; }
            set { _alreadyAddUpCnt = value; }
        }

        /// public propaty name  :  EditStatus
        /// <summary>エディットステータスプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   エディットステータスプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 EditStatus
        {
            get { return _editStatus; }
            set { _editStatus = value; }
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

        /// public propaty name  :  StockSectionNm
        /// <summary>仕入拠点名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入拠点名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string StockSectionNm
        {
            get { return _stockSectionNm; }
            set { _stockSectionNm = value; }
        }

        /// public propaty name  :  StockAddUpSectionNm
        /// <summary>仕入計上拠点名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入計上拠点名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string StockAddUpSectionNm
        {
            get { return _stockAddUpSectionNm; }
            set { _stockAddUpSectionNm = value; }
        }

        /// public propaty name  :  SuppCTaxLayMethodNm
        /// <summary>仕入先消費税転嫁方式名称プロパティ</summary>
        /// <value>伝票単位、明細単位、請求単位</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先消費税転嫁方式名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SuppCTaxLayMethodNm
        {
            get { return _suppCTaxLayMethodNm; }
            set { _suppCTaxLayMethodNm = value; }
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


        /// <summary>
        /// 仕入情報（売仕入同時入力）コンストラクタ
        /// </summary>
        /// <returns>StockTempクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockTempクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public StockTemp()
        {
        }

        /// <summary>
        /// 仕入情報（売仕入同時入力）コンストラクタ
        /// </summary>
        /// <param name="createDateTime">作成日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="updateDateTime">更新日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
        /// <param name="fileHeaderGuid">GUID(共通ファイルヘッダ)</param>
        /// <param name="updEmployeeCode">更新従業員コード(共通ファイルヘッダ)</param>
        /// <param name="updAssemblyId1">更新アセンブリID1(共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）)</param>
        /// <param name="updAssemblyId2">更新アセンブリID2(共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）)</param>
        /// <param name="logicalDeleteCode">論理削除区分(共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除))</param>
        /// <param name="supplierFormal">仕入形式(0:仕入,1:入荷,2:発注　（受注ステータス）)</param>
        /// <param name="supplierSlipNo">仕入伝票番号(仕入伝票番号,入荷伝票番号,注文書番号(発注)を兼ねる)</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="subSectionCode">部門コード</param>
        /// <param name="debitNoteDiv">赤伝区分(0:黒伝,1:赤伝,2:元黒)</param>
        /// <param name="debitNLnkSuppSlipNo">赤黒連結仕入伝票番号</param>
        /// <param name="supplierSlipCd">仕入伝票区分(10:仕入,20:返品)</param>
        /// <param name="stockGoodsCd">仕入商品区分(0:商品,1:商品外,2:消費税調整,3:残高調整,4:買掛用消費税調整,5:買掛用残高調整,6:合計入力,10:買用消費税調整(自動),11:相殺,12:相殺(自動))</param>
        /// <param name="accPayDivCd">買掛区分(0:買掛なし,1:買掛)</param>
        /// <param name="stockSectionCd">仕入拠点コード</param>
        /// <param name="stockAddUpSectionCd">仕入計上拠点コード(文字型 仕入計上対象の拠点コード(拠点制御の支払計上拠点のこと))</param>
        /// <param name="stockSlipUpdateCd">仕入伝票更新区分(0:未更新,1:更新あり)</param>
        /// <param name="inputDay">入力日(YYYYMMDD　（更新年月日）)</param>
        /// <param name="arrivalGoodsDay">入荷日(YYYYMMDD)</param>
        /// <param name="stockDate">仕入日(YYYYMMDD)</param>
        /// <param name="stockAddUpADate">仕入計上日付(仕入計上日)</param>
        /// <param name="delayPaymentDiv">来勘区分(0:当月(来勘なし),1:来月,2:再来月…9:9ヵ月後)</param>
        /// <param name="payeeCode">支払先コード(支払先(精算先)コード。支払締時は支払先単位で集計・計算。)</param>
        /// <param name="payeeSnm">支払先略称</param>
        /// <param name="supplierCd">仕入先コード</param>
        /// <param name="supplierNm1">仕入先名1</param>
        /// <param name="supplierNm2">仕入先名2</param>
        /// <param name="supplierSnm">仕入先略称</param>
        /// <param name="businessTypeCode">業種コード</param>
        /// <param name="businessTypeName">業種名称</param>
        /// <param name="salesAreaCode">販売エリアコード(地区コード)</param>
        /// <param name="salesAreaName">販売エリア名称</param>
        /// <param name="stockInputCode">仕入入力者コード</param>
        /// <param name="stockInputName">仕入入力者名称</param>
        /// <param name="stockAgentCode">仕入担当者コード(発注者をセット)</param>
        /// <param name="stockAgentName">仕入担当者名称(発注者をセット)</param>
        /// <param name="suppTtlAmntDspWayCd">仕入先総額表示方法区分(0:総額表示しない（税抜き）,1:総額表示する（税込み）)</param>
        /// <param name="ttlAmntDispRateApy">総額表示掛率適用区分(0：基準価格(税込)×掛率, 1:基準価格(税抜)×掛率)</param>
        /// <param name="stockTotalPrice">仕入金額合計(仕入金額合計＝仕入金額計（税込み）＋非課税対象額合計)</param>
        /// <param name="stockSubttlPrice">仕入金額小計(仕入金額小計＝仕入金額計（税抜き）＋非課税対象額合計)</param>
        /// <param name="stockTtlPricTaxInc">仕入金額計（税込み）(外税時：税抜き＋消費税、内税時：内税価格（税込）の集計)</param>
        /// <param name="stockTtlPricTaxExc">仕入金額計（税抜き）(外税時：税抜価格の集計、内税時：内税価格（税込）の集計－消費税)</param>
        /// <param name="stockNetPrice">仕入正価金額(値引前の税抜仕入金額)</param>
        /// <param name="stockPriceConsTax">仕入金額消費税額(仕入金額消費税額（外税）+仕入金額消費税額（内税）)</param>
        /// <param name="ttlItdedStcOutTax">仕入外税対象額合計(外税対象金額の集計（税抜、値引含まず）)</param>
        /// <param name="ttlItdedStcInTax">仕入内税対象額合計(内税対象金額の集計（税抜、値引含まず） )</param>
        /// <param name="ttlItdedStcTaxFree">仕入非課税対象額合計(非課税対象金額の集計（値引含まず）)</param>
        /// <param name="stockOutTax">仕入金額消費税額（外税）(値引前の外税商品の消費税)</param>
        /// <param name="stckPrcConsTaxInclu">仕入金額消費税額（内税）(値引前の内税商品の消費税)</param>
        /// <param name="stckDisTtlTaxExc">仕入値引金額計（税抜き）(仕入値引外税対象額合計+仕入値引内税対象額合計+仕入値引非課税対象額合計)</param>
        /// <param name="itdedStockDisOutTax">仕入値引外税対象額合計(外税商品値引の外税対象額（税抜）)</param>
        /// <param name="itdedStockDisInTax">仕入値引内税対象額合計(内税商品値引の内税対象額（税抜）)</param>
        /// <param name="itdedStockDisTaxFre">仕入値引非課税対象額合計(非課税商品値引の非課税対象額)</param>
        /// <param name="stockDisOutTax">仕入値引消費税額（外税）(外税商品値引の消費税額)</param>
        /// <param name="stckDisTtlTaxInclu">仕入値引消費税額（内税）(内税商品値引の消費税額)</param>
        /// <param name="taxAdjust">消費税調整額</param>
        /// <param name="balanceAdjust">残高調整額</param>
        /// <param name="suppCTaxLayCd">仕入先消費税転嫁方式コード(0:伝票単位1:明細単位2:支払親 3:支払子 9:非課税)</param>
        /// <param name="supplierConsTaxRate">仕入先消費税税率</param>
        /// <param name="accPayConsTax">買掛消費税</param>
        /// <param name="stockFractionProcCd">仕入端数処理区分(1:切捨て,2:四捨五入,3:切上げ　（消費税）)</param>
        /// <param name="autoPayment">自動支払区分(0:通常支払,1:自動支払)</param>
        /// <param name="autoPaySlipNum">自動支払伝票番号(自動支払時の支払伝票番号)</param>
        /// <param name="retGoodsReasonDiv">返品理由コード</param>
        /// <param name="retGoodsReason">返品理由</param>
        /// <param name="partySaleSlipNum">相手先伝票番号(仕入先伝票番号に使用する)</param>
        /// <param name="supplierSlipNote1">仕入伝票備考1</param>
        /// <param name="supplierSlipNote2">仕入伝票備考2</param>
        /// <param name="detailRowCount">明細行数(伝票内の明細の行数（諸費用明細は除く）)</param>
        /// <param name="ediSendDate">ＥＤＩ送信日(YYYYMMDD （ErectricDataInterface）)</param>
        /// <param name="ediTakeInDate">ＥＤＩ取込日(YYYYMMDD)</param>
        /// <param name="uoeRemark1">ＵＯＥリマーク１(UserOrderEntory)</param>
        /// <param name="uoeRemark2">ＵＯＥリマーク２</param>
        /// <param name="slipPrintDivCd">伝票発行区分(0:しない 1:する)</param>
        /// <param name="slipPrintFinishCd">伝票発行済区分(0:未発行 1:発行済)</param>
        /// <param name="stockSlipPrintDate">仕入伝票発行日(入荷では入荷伝票発行日（発注書発行日もここを使用）)</param>
        /// <param name="slipPrtSetPaperId">伝票印刷設定用帳票ID(仕入形式とセットで伝票タイプ管理マスタを参照　（発注,入荷用）)</param>
        /// <param name="slipAddressDiv">伝票住所区分(1:得意先,2:納入先)</param>
        /// <param name="addresseeCode">納品先コード</param>
        /// <param name="addresseeName">納品先名称</param>
        /// <param name="addresseeName2">納品先名称2(追加(登録漏れ) 塩原)</param>
        /// <param name="addresseePostNo">納品先郵便番号(伝票住所区分に従う内容)</param>
        /// <param name="addresseeAddr1">納品先住所1(都道府県市区郡・町村・字)(伝票住所区分に従う内容)</param>
        /// <param name="addresseeAddr3">納品先住所3(番地)(伝票住所区分に従う内容)</param>
        /// <param name="addresseeAddr4">納品先住所4(アパート名称)(伝票住所区分に従う内容)</param>
        /// <param name="addresseeTelNo">納品先電話番号(伝票住所区分に従う内容)</param>
        /// <param name="addresseeFaxNo">納品先FAX番号(伝票住所区分に従う内容)</param>
        /// <param name="directSendingCd">直送区分(0:直送なし,1:直送あり　（発注書の直送先印字制御）)</param>
        /// <param name="acceptAnOrderNo">受注番号</param>
        /// <param name="supplierFormalDetail">仕入形式(0:仕入,1:入荷,2:発注　（受注ステータス）)</param>
        /// <param name="supplierSlipNoDetail">仕入伝票番号(仕入伝票番号,入荷伝票番号,注文書番号(発注)を兼ねる。（未発注はゼロ）)</param>
        /// <param name="stockRowNo">仕入行番号</param>
        /// <param name="sectionCodeDetail">拠点コード</param>
        /// <param name="subSectionCodeDetail">部門コード</param>
        /// <param name="commonSeqNo">共通通番</param>
        /// <param name="stockSlipDtlNum">仕入明細通番</param>
        /// <param name="supplierFormalSrc">仕入形式（元）(0:仕入,1:入荷,2:発注)</param>
        /// <param name="stockSlipDtlNumSrc">仕入明細通番（元）(計上時の元データ明細通番をセット)</param>
        /// <param name="acptAnOdrStatusSync">受注ステータス（同時）(30:売上,40:出荷)</param>
        /// <param name="salesSlipDtlNumSync">売上明細通番（同時）(同時計上時の仕入明細通番をセット)</param>
        /// <param name="stockSlipCdDtl">仕入伝票区分（明細）(0:仕入,1:返品,2:値引)</param>
        /// <param name="stockInputCodeDetail">仕入入力者コード</param>
        /// <param name="stockInputNameDetail">仕入入力者名称</param>
        /// <param name="stockAgentCodeDetail">仕入担当者コード</param>
        /// <param name="stockAgentNameDetail">仕入担当者名称</param>
        /// <param name="goodsKindCode">商品属性</param>
        /// <param name="goodsMakerCd">商品メーカーコード(ﾊﾟｯｹｰｼﾞ毎にﾕｰｻﾞｰ登録範囲が異なる)</param>
        /// <param name="makerName">メーカー名称</param>
        /// <param name="makerKanaName">メーカーカナ名称</param>
        /// <param name="cmpltMakerKanaName">メーカーカナ名称（一式）</param>
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
        /// <param name="stockOrderDivCd">仕入在庫取寄せ区分(0:取寄せ,1:在庫)</param>
        /// <param name="openPriceDiv">オープン価格区分(0:通常／1:オープン価格)</param>
        /// <param name="goodsRateRank">商品掛率ランク(商品の掛率用ランク)</param>
        /// <param name="custRateGrpCode">得意先掛率グループコード</param>
        /// <param name="suppRateGrpCode">仕入先掛率グループコード</param>
        /// <param name="listPriceTaxExcFl">定価（税抜，浮動）(税抜き)</param>
        /// <param name="listPriceTaxIncFl">定価（税込，浮動）(税込み)</param>
        /// <param name="stockRate">仕入率</param>
        /// <param name="rateSectStckUnPrc">掛率設定拠点（仕入単価）(0:全社設定, その他:拠点コード)</param>
        /// <param name="rateDivStckUnPrc">掛率設定区分（仕入単価）(A7,A8,…)</param>
        /// <param name="unPrcCalcCdStckUnPrc">単価算出区分（仕入単価）(1:掛率,2:原価ＵＰ率,3:粗利率)</param>
        /// <param name="priceCdStckUnPrc">価格区分（仕入単価）(0:定価,1:登録販売店価格,…)</param>
        /// <param name="stdUnPrcStckUnPrc">基準単価（仕入単価）</param>
        /// <param name="fracProcUnitStcUnPrc">端数処理単位（仕入単価）</param>
        /// <param name="fracProcStckUnPrc">端数処理（仕入単価）(1：切捨て,2：四捨五入,3:切上げ)</param>
        /// <param name="stockUnitPriceFl">仕入単価（税抜，浮動）(税抜き)</param>
        /// <param name="stockUnitTaxPriceFl">仕入単価（税込，浮動）(税込み)</param>
        /// <param name="stockUnitChngDiv">仕入単価変更区分(0:変更なし,1:変更あり　（仕入単価手入力）)</param>
        /// <param name="bfStockUnitPriceFl">変更前仕入単価（浮動）(税抜き、掛率算出結果)</param>
        /// <param name="bfListPrice">変更前定価(税抜き、掛率算出結果)</param>
        /// <param name="rateBLGoodsCode">BL商品コード（掛率）(掛率算出時に使用したBLコード（商品検索結果）)</param>
        /// <param name="rateBLGoodsName">BL商品コード名称（掛率）(掛率算出時に使用したBLコード名称（商品検索結果）)</param>
        /// <param name="rateGoodsRateGrpCd">商品掛率グループコード（掛率）(掛率算出時に使用した商品掛率コード（商品検索結果）)</param>
        /// <param name="rateGoodsRateGrpNm">商品掛率グループ名称（掛率）(掛率算出時に使用した商品掛率名称（商品検索結果）)</param>
        /// <param name="rateBLGroupCode">BLグループコード（掛率）(掛率算出時に使用したBLグループコード（商品検索結果）)</param>
        /// <param name="rateBLGroupName">BLグループ名称（掛率）(掛率算出時に使用したBLグループ名称（商品検索結果）)</param>
        /// <param name="stockCount">仕入数</param>
        /// <param name="orderCnt">発注数量(発注,入荷で使用)</param>
        /// <param name="orderAdjustCnt">発注調整数(現在の発注数は「発注数量＋発注調整数」で算出)</param>
        /// <param name="orderRemainCnt">発注残数(発注数量＋発注調整数－仕入数)</param>
        /// <param name="remainCntUpdDate">残数更新日(YYYYMMDD)</param>
        /// <param name="stockPriceTaxExc">仕入金額（税抜き）</param>
        /// <param name="stockPriceTaxInc">仕入金額（税込み）</param>
        /// <param name="stockGoodsCdDetail">仕入商品区分(0:商品,1:商品外,2:消費税調整,3:残高調整,4:買掛用消費税調整,5:買掛用残高調整,6:合計入力,10:買用消費税調整(自動))</param>
        /// <param name="stockPriceConsTaxDetail">仕入金額消費税額(仕入金額（税込み）- 仕入金額（税抜き）※消費税調整額も兼ねる)</param>
        /// <param name="taxationCode">課税区分(0:課税,1:非課税,2:課税（内税）)</param>
        /// <param name="stockDtiSlipNote1">仕入伝票明細備考1</param>
        /// <param name="salesCustomerCode">販売先コード</param>
        /// <param name="salesCustomerSnm">販売先略称</param>
        /// <param name="slipMemo1">伝票メモ１</param>
        /// <param name="slipMemo2">伝票メモ２</param>
        /// <param name="slipMemo3">伝票メモ３</param>
        /// <param name="insideMemo1">社内メモ１</param>
        /// <param name="insideMemo2">社内メモ２</param>
        /// <param name="insideMemo3">社内メモ３</param>
        /// <param name="supplierCdDetail">仕入先コード(発注用)</param>
        /// <param name="supplierSnmDetail">仕入先略称(発注用)</param>
        /// <param name="addresseeCodeDetail">納品先コード(発注用)</param>
        /// <param name="addresseeNameDetail">納品先名称(発注用)</param>
        /// <param name="directSendingCdDetail">直送区分(0:直送なし,1:直送あり　（発注書の直送先印字制御）)</param>
        /// <param name="orderNumber">発注番号(発注用)</param>
        /// <param name="wayToOrder">注文方法(0:発注書発注,1:FAX送信,2:オンライン発注,4:発注済事後登録)</param>
        /// <param name="deliGdsCmpltDueDate">納品完了予定日(発注用　（発注回答納期）)</param>
        /// <param name="expectDeliveryDate">希望納期(発注用)</param>
        /// <param name="orderDataCreateDiv">発注データ作成区分(1:受発注売上入力,2:発注入力,3:在庫補充発注,4:発注点割れ　（発生元）)</param>
        /// <param name="orderDataCreateDate">発注データ作成日(発注用)</param>
        /// <param name="orderFormIssuedDiv">発注書発行済区分(0:未発行,1:発行済)</param>
        /// <param name="totalDay">締日(DD)</param>
        /// <param name="nTimeCalcStDate">次回勘定開始日(01～31まで（省略可能）)</param>
        /// <param name="payeeName">支払先名称</param>
        /// <param name="payeeName2">支払先名称２</param>
        /// <param name="addUpEnableCnt">計上可能数量</param>
        /// <param name="alreadyAddUpCnt">計上済数量</param>
        /// <param name="editStatus">エディットステータス</param>
        /// <param name="dtlRelationGuid">共通キー</param>
        /// <param name="enterpriseName">企業名称</param>
        /// <param name="updEmployeeName">更新従業員名称</param>
        /// <param name="stockSectionNm">仕入拠点名称</param>
        /// <param name="stockAddUpSectionNm">仕入計上拠点名称</param>
        /// <param name="suppCTaxLayMethodNm">仕入先消費税転嫁方式名称(伝票単位、明細単位、請求単位)</param>
        /// <param name="bLGoodsName">BL商品コード名称</param>
        /// <returns>StockTempクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockTempクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public StockTemp(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 supplierFormal, Int32 supplierSlipNo, string sectionCode, Int32 subSectionCode, Int32 debitNoteDiv, Int32 debitNLnkSuppSlipNo, Int32 supplierSlipCd, Int32 stockGoodsCd, Int32 accPayDivCd, string stockSectionCd, string stockAddUpSectionCd, Int32 stockSlipUpdateCd, DateTime inputDay, DateTime arrivalGoodsDay, DateTime stockDate, DateTime stockAddUpADate, Int32 delayPaymentDiv, Int32 payeeCode, string payeeSnm, Int32 supplierCd, string supplierNm1, string supplierNm2, string supplierSnm, Int32 businessTypeCode, string businessTypeName, Int32 salesAreaCode, string salesAreaName, string stockInputCode, string stockInputName, string stockAgentCode, string stockAgentName, Int32 suppTtlAmntDspWayCd, Int32 ttlAmntDispRateApy, Int64 stockTotalPrice, Int64 stockSubttlPrice, Int64 stockTtlPricTaxInc, Int64 stockTtlPricTaxExc, Int64 stockNetPrice, Int64 stockPriceConsTax, Int64 ttlItdedStcOutTax, Int64 ttlItdedStcInTax, Int64 ttlItdedStcTaxFree, Int64 stockOutTax, Int64 stckPrcConsTaxInclu, Int64 stckDisTtlTaxExc, Int64 itdedStockDisOutTax, Int64 itdedStockDisInTax, Int64 itdedStockDisTaxFre, Int64 stockDisOutTax, Int64 stckDisTtlTaxInclu, Int64 taxAdjust, Int64 balanceAdjust, Int32 suppCTaxLayCd, Double supplierConsTaxRate, Int64 accPayConsTax, Int32 stockFractionProcCd, Int32 autoPayment, Int32 autoPaySlipNum, Int32 retGoodsReasonDiv, string retGoodsReason, string partySaleSlipNum, string supplierSlipNote1, string supplierSlipNote2, Int32 detailRowCount, DateTime ediSendDate, DateTime ediTakeInDate, string uoeRemark1, string uoeRemark2, Int32 slipPrintDivCd, Int32 slipPrintFinishCd, DateTime stockSlipPrintDate, string slipPrtSetPaperId, Int32 slipAddressDiv, Int32 addresseeCode, string addresseeName, string addresseeName2, string addresseePostNo, string addresseeAddr1, string addresseeAddr3, string addresseeAddr4, string addresseeTelNo, string addresseeFaxNo, Int32 directSendingCd, Int32 acceptAnOrderNo, Int32 supplierFormalDetail, Int32 supplierSlipNoDetail, Int32 stockRowNo, string sectionCodeDetail, Int32 subSectionCodeDetail, Int64 commonSeqNo, Int64 stockSlipDtlNum, Int32 supplierFormalSrc, Int64 stockSlipDtlNumSrc, Int32 acptAnOdrStatusSync, Int64 salesSlipDtlNumSync, Int32 stockSlipCdDtl, string stockInputCodeDetail, string stockInputNameDetail, string stockAgentCodeDetail, string stockAgentNameDetail, Int32 goodsKindCode, Int32 goodsMakerCd, string makerName, string makerKanaName, string cmpltMakerKanaName, string goodsNo, string goodsName, string goodsNameKana, Int32 goodsLGroup, string goodsLGroupName, Int32 goodsMGroup, string goodsMGroupName, Int32 bLGroupCode, string bLGroupName, Int32 bLGoodsCode, string bLGoodsFullName, Int32 enterpriseGanreCode, string enterpriseGanreName, string warehouseCode, string warehouseName, string warehouseShelfNo, Int32 stockOrderDivCd, Int32 openPriceDiv, string goodsRateRank, Int32 custRateGrpCode, Int32 suppRateGrpCode, Double listPriceTaxExcFl, Double listPriceTaxIncFl, Double stockRate, string rateSectStckUnPrc, string rateDivStckUnPrc, Int32 unPrcCalcCdStckUnPrc, Int32 priceCdStckUnPrc, Double stdUnPrcStckUnPrc, Double fracProcUnitStcUnPrc, Int32 fracProcStckUnPrc, Double stockUnitPriceFl, Double stockUnitTaxPriceFl, Int32 stockUnitChngDiv, Double bfStockUnitPriceFl, Double bfListPrice, Int32 rateBLGoodsCode, string rateBLGoodsName, Int32 rateGoodsRateGrpCd, string rateGoodsRateGrpNm, Int32 rateBLGroupCode, string rateBLGroupName, Double stockCount, Double orderCnt, Double orderAdjustCnt, Double orderRemainCnt, DateTime remainCntUpdDate, Int64 stockPriceTaxExc, Int64 stockPriceTaxInc, Int32 stockGoodsCdDetail, Int64 stockPriceConsTaxDetail, Int32 taxationCode, string stockDtiSlipNote1, Int32 salesCustomerCode, string salesCustomerSnm, string slipMemo1, string slipMemo2, string slipMemo3, string insideMemo1, string insideMemo2, string insideMemo3, Int32 supplierCdDetail, string supplierSnmDetail, Int32 addresseeCodeDetail, string addresseeNameDetail, Int32 directSendingCdDetail, string orderNumber, Int32 wayToOrder, DateTime deliGdsCmpltDueDate, DateTime expectDeliveryDate, Int32 orderDataCreateDiv, DateTime orderDataCreateDate, Int32 orderFormIssuedDiv, Int32 totalDay, Int32 nTimeCalcStDate, string payeeName, string payeeName2, Double addUpEnableCnt, Double alreadyAddUpCnt, Int32 editStatus, Guid dtlRelationGuid, string enterpriseName, string updEmployeeName, string stockSectionNm, string stockAddUpSectionNm, string suppCTaxLayMethodNm, string bLGoodsName)
        {
            this.CreateDateTime = createDateTime;
            this.UpdateDateTime = updateDateTime;
            this._enterpriseCode = enterpriseCode;
            this._fileHeaderGuid = fileHeaderGuid;
            this._updEmployeeCode = updEmployeeCode;
            this._updAssemblyId1 = updAssemblyId1;
            this._updAssemblyId2 = updAssemblyId2;
            this._logicalDeleteCode = logicalDeleteCode;
            this._supplierFormal = supplierFormal;
            this._supplierSlipNo = supplierSlipNo;
            this._sectionCode = sectionCode;
            this._subSectionCode = subSectionCode;
            this._debitNoteDiv = debitNoteDiv;
            this._debitNLnkSuppSlipNo = debitNLnkSuppSlipNo;
            this._supplierSlipCd = supplierSlipCd;
            this._stockGoodsCd = stockGoodsCd;
            this._accPayDivCd = accPayDivCd;
            this._stockSectionCd = stockSectionCd;
            this._stockAddUpSectionCd = stockAddUpSectionCd;
            this._stockSlipUpdateCd = stockSlipUpdateCd;
            this.InputDay = inputDay;
            this.ArrivalGoodsDay = arrivalGoodsDay;
            this.StockDate = stockDate;
            this.StockAddUpADate = stockAddUpADate;
            this._delayPaymentDiv = delayPaymentDiv;
            this._payeeCode = payeeCode;
            this._payeeSnm = payeeSnm;
            this._supplierCd = supplierCd;
            this._supplierNm1 = supplierNm1;
            this._supplierNm2 = supplierNm2;
            this._supplierSnm = supplierSnm;
            this._businessTypeCode = businessTypeCode;
            this._businessTypeName = businessTypeName;
            this._salesAreaCode = salesAreaCode;
            this._salesAreaName = salesAreaName;
            this._stockInputCode = stockInputCode;
            this._stockInputName = stockInputName;
            this._stockAgentCode = stockAgentCode;
            this._stockAgentName = stockAgentName;
            this._suppTtlAmntDspWayCd = suppTtlAmntDspWayCd;
            this._ttlAmntDispRateApy = ttlAmntDispRateApy;
            this._stockTotalPrice = stockTotalPrice;
            this._stockSubttlPrice = stockSubttlPrice;
            this._stockTtlPricTaxInc = stockTtlPricTaxInc;
            this._stockTtlPricTaxExc = stockTtlPricTaxExc;
            this._stockNetPrice = stockNetPrice;
            this._stockPriceConsTax = stockPriceConsTax;
            this._ttlItdedStcOutTax = ttlItdedStcOutTax;
            this._ttlItdedStcInTax = ttlItdedStcInTax;
            this._ttlItdedStcTaxFree = ttlItdedStcTaxFree;
            this._stockOutTax = stockOutTax;
            this._stckPrcConsTaxInclu = stckPrcConsTaxInclu;
            this._stckDisTtlTaxExc = stckDisTtlTaxExc;
            this._itdedStockDisOutTax = itdedStockDisOutTax;
            this._itdedStockDisInTax = itdedStockDisInTax;
            this._itdedStockDisTaxFre = itdedStockDisTaxFre;
            this._stockDisOutTax = stockDisOutTax;
            this._stckDisTtlTaxInclu = stckDisTtlTaxInclu;
            this._taxAdjust = taxAdjust;
            this._balanceAdjust = balanceAdjust;
            this._suppCTaxLayCd = suppCTaxLayCd;
            this._supplierConsTaxRate = supplierConsTaxRate;
            this._accPayConsTax = accPayConsTax;
            this._stockFractionProcCd = stockFractionProcCd;
            this._autoPayment = autoPayment;
            this._autoPaySlipNum = autoPaySlipNum;
            this._retGoodsReasonDiv = retGoodsReasonDiv;
            this._retGoodsReason = retGoodsReason;
            this._partySaleSlipNum = partySaleSlipNum;
            this._supplierSlipNote1 = supplierSlipNote1;
            this._supplierSlipNote2 = supplierSlipNote2;
            this._detailRowCount = detailRowCount;
            this.EdiSendDate = ediSendDate;
            this.EdiTakeInDate = ediTakeInDate;
            this._uoeRemark1 = uoeRemark1;
            this._uoeRemark2 = uoeRemark2;
            this._slipPrintDivCd = slipPrintDivCd;
            this._slipPrintFinishCd = slipPrintFinishCd;
            this.StockSlipPrintDate = stockSlipPrintDate;
            this._slipPrtSetPaperId = slipPrtSetPaperId;
            this._slipAddressDiv = slipAddressDiv;
            this._addresseeCode = addresseeCode;
            this._addresseeName = addresseeName;
            this._addresseeName2 = addresseeName2;
            this._addresseePostNo = addresseePostNo;
            this._addresseeAddr1 = addresseeAddr1;
            this._addresseeAddr3 = addresseeAddr3;
            this._addresseeAddr4 = addresseeAddr4;
            this._addresseeTelNo = addresseeTelNo;
            this._addresseeFaxNo = addresseeFaxNo;
            this._directSendingCd = directSendingCd;
            this._acceptAnOrderNo = acceptAnOrderNo;
            this._supplierFormalDetail = supplierFormalDetail;
            this._supplierSlipNoDetail = supplierSlipNoDetail;
            this._stockRowNo = stockRowNo;
            this._sectionCodeDetail = sectionCodeDetail;
            this._subSectionCodeDetail = subSectionCodeDetail;
            this._commonSeqNo = commonSeqNo;
            this._stockSlipDtlNum = stockSlipDtlNum;
            this._supplierFormalSrc = supplierFormalSrc;
            this._stockSlipDtlNumSrc = stockSlipDtlNumSrc;
            this._acptAnOdrStatusSync = acptAnOdrStatusSync;
            this._salesSlipDtlNumSync = salesSlipDtlNumSync;
            this._stockSlipCdDtl = stockSlipCdDtl;
            this._stockInputCodeDetail = stockInputCodeDetail;
            this._stockInputNameDetail = stockInputNameDetail;
            this._stockAgentCodeDetail = stockAgentCodeDetail;
            this._stockAgentNameDetail = stockAgentNameDetail;
            this._goodsKindCode = goodsKindCode;
            this._goodsMakerCd = goodsMakerCd;
            this._makerName = makerName;
            this._makerKanaName = makerKanaName;
            this._cmpltMakerKanaName = cmpltMakerKanaName;
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
            this._stockOrderDivCd = stockOrderDivCd;
            this._openPriceDiv = openPriceDiv;
            this._goodsRateRank = goodsRateRank;
            this._custRateGrpCode = custRateGrpCode;
            this._suppRateGrpCode = suppRateGrpCode;
            this._listPriceTaxExcFl = listPriceTaxExcFl;
            this._listPriceTaxIncFl = listPriceTaxIncFl;
            this._stockRate = stockRate;
            this._rateSectStckUnPrc = rateSectStckUnPrc;
            this._rateDivStckUnPrc = rateDivStckUnPrc;
            this._unPrcCalcCdStckUnPrc = unPrcCalcCdStckUnPrc;
            this._priceCdStckUnPrc = priceCdStckUnPrc;
            this._stdUnPrcStckUnPrc = stdUnPrcStckUnPrc;
            this._fracProcUnitStcUnPrc = fracProcUnitStcUnPrc;
            this._fracProcStckUnPrc = fracProcStckUnPrc;
            this._stockUnitPriceFl = stockUnitPriceFl;
            this._stockUnitTaxPriceFl = stockUnitTaxPriceFl;
            this._stockUnitChngDiv = stockUnitChngDiv;
            this._bfStockUnitPriceFl = bfStockUnitPriceFl;
            this._bfListPrice = bfListPrice;
            this._rateBLGoodsCode = rateBLGoodsCode;
            this._rateBLGoodsName = rateBLGoodsName;
            this._rateGoodsRateGrpCd = rateGoodsRateGrpCd;
            this._rateGoodsRateGrpNm = rateGoodsRateGrpNm;
            this._rateBLGroupCode = rateBLGroupCode;
            this._rateBLGroupName = rateBLGroupName;
            this._stockCount = stockCount;
            this._orderCnt = orderCnt;
            this._orderAdjustCnt = orderAdjustCnt;
            this._orderRemainCnt = orderRemainCnt;
            this.RemainCntUpdDate = remainCntUpdDate;
            this._stockPriceTaxExc = stockPriceTaxExc;
            this._stockPriceTaxInc = stockPriceTaxInc;
            this._stockGoodsCdDetail = stockGoodsCdDetail;
            this._stockPriceConsTaxDetail = stockPriceConsTaxDetail;
            this._taxationCode = taxationCode;
            this._stockDtiSlipNote1 = stockDtiSlipNote1;
            this._salesCustomerCode = salesCustomerCode;
            this._salesCustomerSnm = salesCustomerSnm;
            this._slipMemo1 = slipMemo1;
            this._slipMemo2 = slipMemo2;
            this._slipMemo3 = slipMemo3;
            this._insideMemo1 = insideMemo1;
            this._insideMemo2 = insideMemo2;
            this._insideMemo3 = insideMemo3;
            this._supplierCdDetail = supplierCdDetail;
            this._supplierSnmDetail = supplierSnmDetail;
            this._addresseeCodeDetail = addresseeCodeDetail;
            this._addresseeNameDetail = addresseeNameDetail;
            this._directSendingCdDetail = directSendingCdDetail;
            this._orderNumber = orderNumber;
            this._wayToOrder = wayToOrder;
            this.DeliGdsCmpltDueDate = deliGdsCmpltDueDate;
            this.ExpectDeliveryDate = expectDeliveryDate;
            this._orderDataCreateDiv = orderDataCreateDiv;
            this.OrderDataCreateDate = orderDataCreateDate;
            this._orderFormIssuedDiv = orderFormIssuedDiv;
            this._totalDay = totalDay;
            this._nTimeCalcStDate = nTimeCalcStDate;
            this._payeeName = payeeName;
            this._payeeName2 = payeeName2;
            this._addUpEnableCnt = addUpEnableCnt;
            this._alreadyAddUpCnt = alreadyAddUpCnt;
            this._editStatus = editStatus;
            this._dtlRelationGuid = dtlRelationGuid;
            this._enterpriseName = enterpriseName;
            this._updEmployeeName = updEmployeeName;
            this._stockSectionNm = stockSectionNm;
            this._stockAddUpSectionNm = stockAddUpSectionNm;
            this._suppCTaxLayMethodNm = suppCTaxLayMethodNm;
            this._bLGoodsName = bLGoodsName;

        }

        /// <summary>
        /// 仕入情報（売仕入同時入力）複製処理
        /// </summary>
        /// <returns>StockTempクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいStockTempクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public StockTemp Clone()
        {
            return new StockTemp(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._supplierFormal, this._supplierSlipNo, this._sectionCode, this._subSectionCode, this._debitNoteDiv, this._debitNLnkSuppSlipNo, this._supplierSlipCd, this._stockGoodsCd, this._accPayDivCd, this._stockSectionCd, this._stockAddUpSectionCd, this._stockSlipUpdateCd, this._inputDay, this._arrivalGoodsDay, this._stockDate, this._stockAddUpADate, this._delayPaymentDiv, this._payeeCode, this._payeeSnm, this._supplierCd, this._supplierNm1, this._supplierNm2, this._supplierSnm, this._businessTypeCode, this._businessTypeName, this._salesAreaCode, this._salesAreaName, this._stockInputCode, this._stockInputName, this._stockAgentCode, this._stockAgentName, this._suppTtlAmntDspWayCd, this._ttlAmntDispRateApy, this._stockTotalPrice, this._stockSubttlPrice, this._stockTtlPricTaxInc, this._stockTtlPricTaxExc, this._stockNetPrice, this._stockPriceConsTax, this._ttlItdedStcOutTax, this._ttlItdedStcInTax, this._ttlItdedStcTaxFree, this._stockOutTax, this._stckPrcConsTaxInclu, this._stckDisTtlTaxExc, this._itdedStockDisOutTax, this._itdedStockDisInTax, this._itdedStockDisTaxFre, this._stockDisOutTax, this._stckDisTtlTaxInclu, this._taxAdjust, this._balanceAdjust, this._suppCTaxLayCd, this._supplierConsTaxRate, this._accPayConsTax, this._stockFractionProcCd, this._autoPayment, this._autoPaySlipNum, this._retGoodsReasonDiv, this._retGoodsReason, this._partySaleSlipNum, this._supplierSlipNote1, this._supplierSlipNote2, this._detailRowCount, this._ediSendDate, this._ediTakeInDate, this._uoeRemark1, this._uoeRemark2, this._slipPrintDivCd, this._slipPrintFinishCd, this._stockSlipPrintDate, this._slipPrtSetPaperId, this._slipAddressDiv, this._addresseeCode, this._addresseeName, this._addresseeName2, this._addresseePostNo, this._addresseeAddr1, this._addresseeAddr3, this._addresseeAddr4, this._addresseeTelNo, this._addresseeFaxNo, this._directSendingCd, this._acceptAnOrderNo, this._supplierFormalDetail, this._supplierSlipNoDetail, this._stockRowNo, this._sectionCodeDetail, this._subSectionCodeDetail, this._commonSeqNo, this._stockSlipDtlNum, this._supplierFormalSrc, this._stockSlipDtlNumSrc, this._acptAnOdrStatusSync, this._salesSlipDtlNumSync, this._stockSlipCdDtl, this._stockInputCodeDetail, this._stockInputNameDetail, this._stockAgentCodeDetail, this._stockAgentNameDetail, this._goodsKindCode, this._goodsMakerCd, this._makerName, this._makerKanaName, this._cmpltMakerKanaName, this._goodsNo, this._goodsName, this._goodsNameKana, this._goodsLGroup, this._goodsLGroupName, this._goodsMGroup, this._goodsMGroupName, this._bLGroupCode, this._bLGroupName, this._bLGoodsCode, this._bLGoodsFullName, this._enterpriseGanreCode, this._enterpriseGanreName, this._warehouseCode, this._warehouseName, this._warehouseShelfNo, this._stockOrderDivCd, this._openPriceDiv, this._goodsRateRank, this._custRateGrpCode, this._suppRateGrpCode, this._listPriceTaxExcFl, this._listPriceTaxIncFl, this._stockRate, this._rateSectStckUnPrc, this._rateDivStckUnPrc, this._unPrcCalcCdStckUnPrc, this._priceCdStckUnPrc, this._stdUnPrcStckUnPrc, this._fracProcUnitStcUnPrc, this._fracProcStckUnPrc, this._stockUnitPriceFl, this._stockUnitTaxPriceFl, this._stockUnitChngDiv, this._bfStockUnitPriceFl, this._bfListPrice, this._rateBLGoodsCode, this._rateBLGoodsName, this._rateGoodsRateGrpCd, this._rateGoodsRateGrpNm, this._rateBLGroupCode, this._rateBLGroupName, this._stockCount, this._orderCnt, this._orderAdjustCnt, this._orderRemainCnt, this._remainCntUpdDate, this._stockPriceTaxExc, this._stockPriceTaxInc, this._stockGoodsCdDetail, this._stockPriceConsTaxDetail, this._taxationCode, this._stockDtiSlipNote1, this._salesCustomerCode, this._salesCustomerSnm, this._slipMemo1, this._slipMemo2, this._slipMemo3, this._insideMemo1, this._insideMemo2, this._insideMemo3, this._supplierCdDetail, this._supplierSnmDetail, this._addresseeCodeDetail, this._addresseeNameDetail, this._directSendingCdDetail, this._orderNumber, this._wayToOrder, this._deliGdsCmpltDueDate, this._expectDeliveryDate, this._orderDataCreateDiv, this._orderDataCreateDate, this._orderFormIssuedDiv, this._totalDay, this._nTimeCalcStDate, this._payeeName, this._payeeName2, this._addUpEnableCnt, this._alreadyAddUpCnt, this._editStatus, this._dtlRelationGuid, this._enterpriseName, this._updEmployeeName, this._stockSectionNm, this._stockAddUpSectionNm, this._suppCTaxLayMethodNm, this._bLGoodsName);
        }

        /// <summary>
        /// 仕入情報（売仕入同時入力）比較処理
        /// </summary>
        /// <param name="target">比較対象のStockTempクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockTempクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool Equals(StockTemp target)
        {
            return ((this.CreateDateTime == target.CreateDateTime)
                 && (this.UpdateDateTime == target.UpdateDateTime)
                 && (this.EnterpriseCode == target.EnterpriseCode)
                 && (this.FileHeaderGuid == target.FileHeaderGuid)
                 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
                 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
                 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
                 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
                 && (this.SupplierFormal == target.SupplierFormal)
                 && (this.SupplierSlipNo == target.SupplierSlipNo)
                 && (this.SectionCode == target.SectionCode)
                 && (this.SubSectionCode == target.SubSectionCode)
                 && (this.DebitNoteDiv == target.DebitNoteDiv)
                 && (this.DebitNLnkSuppSlipNo == target.DebitNLnkSuppSlipNo)
                 && (this.SupplierSlipCd == target.SupplierSlipCd)
                 && (this.StockGoodsCd == target.StockGoodsCd)
                 && (this.AccPayDivCd == target.AccPayDivCd)
                 && (this.StockSectionCd == target.StockSectionCd)
                 && (this.StockAddUpSectionCd == target.StockAddUpSectionCd)
                 && (this.StockSlipUpdateCd == target.StockSlipUpdateCd)
                 && (this.InputDay == target.InputDay)
                 && (this.ArrivalGoodsDay == target.ArrivalGoodsDay)
                 && (this.StockDate == target.StockDate)
                 && (this.StockAddUpADate == target.StockAddUpADate)
                 && (this.DelayPaymentDiv == target.DelayPaymentDiv)
                 && (this.PayeeCode == target.PayeeCode)
                 && (this.PayeeSnm == target.PayeeSnm)
                 && (this.SupplierCd == target.SupplierCd)
                 && (this.SupplierNm1 == target.SupplierNm1)
                 && (this.SupplierNm2 == target.SupplierNm2)
                 && (this.SupplierSnm == target.SupplierSnm)
                 && (this.BusinessTypeCode == target.BusinessTypeCode)
                 && (this.BusinessTypeName == target.BusinessTypeName)
                 && (this.SalesAreaCode == target.SalesAreaCode)
                 && (this.SalesAreaName == target.SalesAreaName)
                 && (this.StockInputCode == target.StockInputCode)
                 && (this.StockInputName == target.StockInputName)
                 && (this.StockAgentCode == target.StockAgentCode)
                 && (this.StockAgentName == target.StockAgentName)
                 && (this.SuppTtlAmntDspWayCd == target.SuppTtlAmntDspWayCd)
                 && (this.TtlAmntDispRateApy == target.TtlAmntDispRateApy)
                 && (this.StockTotalPrice == target.StockTotalPrice)
                 && (this.StockSubttlPrice == target.StockSubttlPrice)
                 && (this.StockTtlPricTaxInc == target.StockTtlPricTaxInc)
                 && (this.StockTtlPricTaxExc == target.StockTtlPricTaxExc)
                 && (this.StockNetPrice == target.StockNetPrice)
                 && (this.StockPriceConsTax == target.StockPriceConsTax)
                 && (this.TtlItdedStcOutTax == target.TtlItdedStcOutTax)
                 && (this.TtlItdedStcInTax == target.TtlItdedStcInTax)
                 && (this.TtlItdedStcTaxFree == target.TtlItdedStcTaxFree)
                 && (this.StockOutTax == target.StockOutTax)
                 && (this.StckPrcConsTaxInclu == target.StckPrcConsTaxInclu)
                 && (this.StckDisTtlTaxExc == target.StckDisTtlTaxExc)
                 && (this.ItdedStockDisOutTax == target.ItdedStockDisOutTax)
                 && (this.ItdedStockDisInTax == target.ItdedStockDisInTax)
                 && (this.ItdedStockDisTaxFre == target.ItdedStockDisTaxFre)
                 && (this.StockDisOutTax == target.StockDisOutTax)
                 && (this.StckDisTtlTaxInclu == target.StckDisTtlTaxInclu)
                 && (this.TaxAdjust == target.TaxAdjust)
                 && (this.BalanceAdjust == target.BalanceAdjust)
                 && (this.SuppCTaxLayCd == target.SuppCTaxLayCd)
                 && (this.SupplierConsTaxRate == target.SupplierConsTaxRate)
                 && (this.AccPayConsTax == target.AccPayConsTax)
                 && (this.StockFractionProcCd == target.StockFractionProcCd)
                 && (this.AutoPayment == target.AutoPayment)
                 && (this.AutoPaySlipNum == target.AutoPaySlipNum)
                 && (this.RetGoodsReasonDiv == target.RetGoodsReasonDiv)
                 && (this.RetGoodsReason == target.RetGoodsReason)
                 && (this.PartySaleSlipNum == target.PartySaleSlipNum)
                 && (this.SupplierSlipNote1 == target.SupplierSlipNote1)
                 && (this.SupplierSlipNote2 == target.SupplierSlipNote2)
                 && (this.DetailRowCount == target.DetailRowCount)
                 && (this.EdiSendDate == target.EdiSendDate)
                 && (this.EdiTakeInDate == target.EdiTakeInDate)
                 && (this.UoeRemark1 == target.UoeRemark1)
                 && (this.UoeRemark2 == target.UoeRemark2)
                 && (this.SlipPrintDivCd == target.SlipPrintDivCd)
                 && (this.SlipPrintFinishCd == target.SlipPrintFinishCd)
                 && (this.StockSlipPrintDate == target.StockSlipPrintDate)
                 && (this.SlipPrtSetPaperId == target.SlipPrtSetPaperId)
                 && (this.SlipAddressDiv == target.SlipAddressDiv)
                 && (this.AddresseeCode == target.AddresseeCode)
                 && (this.AddresseeName == target.AddresseeName)
                 && (this.AddresseeName2 == target.AddresseeName2)
                 && (this.AddresseePostNo == target.AddresseePostNo)
                 && (this.AddresseeAddr1 == target.AddresseeAddr1)
                 && (this.AddresseeAddr3 == target.AddresseeAddr3)
                 && (this.AddresseeAddr4 == target.AddresseeAddr4)
                 && (this.AddresseeTelNo == target.AddresseeTelNo)
                 && (this.AddresseeFaxNo == target.AddresseeFaxNo)
                 && (this.DirectSendingCd == target.DirectSendingCd)
                 && (this.AcceptAnOrderNo == target.AcceptAnOrderNo)
                 && (this.SupplierFormalDetail == target.SupplierFormalDetail)
                 && (this.SupplierSlipNoDetail == target.SupplierSlipNoDetail)
                 && (this.StockRowNo == target.StockRowNo)
                 && (this.SectionCodeDetail == target.SectionCodeDetail)
                 && (this.SubSectionCodeDetail == target.SubSectionCodeDetail)
                 && (this.CommonSeqNo == target.CommonSeqNo)
                 && (this.StockSlipDtlNum == target.StockSlipDtlNum)
                 && (this.SupplierFormalSrc == target.SupplierFormalSrc)
                 && (this.StockSlipDtlNumSrc == target.StockSlipDtlNumSrc)
                 && (this.AcptAnOdrStatusSync == target.AcptAnOdrStatusSync)
                 && (this.SalesSlipDtlNumSync == target.SalesSlipDtlNumSync)
                 && (this.StockSlipCdDtl == target.StockSlipCdDtl)
                 && (this.StockInputCodeDetail == target.StockInputCodeDetail)
                 && (this.StockInputNameDetail == target.StockInputNameDetail)
                 && (this.StockAgentCodeDetail == target.StockAgentCodeDetail)
                 && (this.StockAgentNameDetail == target.StockAgentNameDetail)
                 && (this.GoodsKindCode == target.GoodsKindCode)
                 && (this.GoodsMakerCd == target.GoodsMakerCd)
                 && (this.MakerName == target.MakerName)
                 && (this.MakerKanaName == target.MakerKanaName)
                 && (this.CmpltMakerKanaName == target.CmpltMakerKanaName)
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
                 && (this.StockOrderDivCd == target.StockOrderDivCd)
                 && (this.OpenPriceDiv == target.OpenPriceDiv)
                 && (this.GoodsRateRank == target.GoodsRateRank)
                 && (this.CustRateGrpCode == target.CustRateGrpCode)
                 && (this.SuppRateGrpCode == target.SuppRateGrpCode)
                 && (this.ListPriceTaxExcFl == target.ListPriceTaxExcFl)
                 && (this.ListPriceTaxIncFl == target.ListPriceTaxIncFl)
                 && (this.StockRate == target.StockRate)
                 && (this.RateSectStckUnPrc == target.RateSectStckUnPrc)
                 && (this.RateDivStckUnPrc == target.RateDivStckUnPrc)
                 && (this.UnPrcCalcCdStckUnPrc == target.UnPrcCalcCdStckUnPrc)
                 && (this.PriceCdStckUnPrc == target.PriceCdStckUnPrc)
                 && (this.StdUnPrcStckUnPrc == target.StdUnPrcStckUnPrc)
                 && (this.FracProcUnitStcUnPrc == target.FracProcUnitStcUnPrc)
                 && (this.FracProcStckUnPrc == target.FracProcStckUnPrc)
                 && (this.StockUnitPriceFl == target.StockUnitPriceFl)
                 && (this.StockUnitTaxPriceFl == target.StockUnitTaxPriceFl)
                 && (this.StockUnitChngDiv == target.StockUnitChngDiv)
                 && (this.BfStockUnitPriceFl == target.BfStockUnitPriceFl)
                 && (this.BfListPrice == target.BfListPrice)
                 && (this.RateBLGoodsCode == target.RateBLGoodsCode)
                 && (this.RateBLGoodsName == target.RateBLGoodsName)
                 && (this.RateGoodsRateGrpCd == target.RateGoodsRateGrpCd)
                 && (this.RateGoodsRateGrpNm == target.RateGoodsRateGrpNm)
                 && (this.RateBLGroupCode == target.RateBLGroupCode)
                 && (this.RateBLGroupName == target.RateBLGroupName)
                 && (this.StockCount == target.StockCount)
                 && (this.OrderCnt == target.OrderCnt)
                 && (this.OrderAdjustCnt == target.OrderAdjustCnt)
                 && (this.OrderRemainCnt == target.OrderRemainCnt)
                 && (this.RemainCntUpdDate == target.RemainCntUpdDate)
                 && (this.StockPriceTaxExc == target.StockPriceTaxExc)
                 && (this.StockPriceTaxInc == target.StockPriceTaxInc)
                 && (this.StockGoodsCdDetail == target.StockGoodsCdDetail)
                 && (this.StockPriceConsTaxDetail == target.StockPriceConsTaxDetail)
                 && (this.TaxationCode == target.TaxationCode)
                 && (this.StockDtiSlipNote1 == target.StockDtiSlipNote1)
                 && (this.SalesCustomerCode == target.SalesCustomerCode)
                 && (this.SalesCustomerSnm == target.SalesCustomerSnm)
                 && (this.SlipMemo1 == target.SlipMemo1)
                 && (this.SlipMemo2 == target.SlipMemo2)
                 && (this.SlipMemo3 == target.SlipMemo3)
                 && (this.InsideMemo1 == target.InsideMemo1)
                 && (this.InsideMemo2 == target.InsideMemo2)
                 && (this.InsideMemo3 == target.InsideMemo3)
                 && (this.SupplierCdDetail == target.SupplierCdDetail)
                 && (this.SupplierSnmDetail == target.SupplierSnmDetail)
                 && (this.AddresseeCodeDetail == target.AddresseeCodeDetail)
                 && (this.AddresseeNameDetail == target.AddresseeNameDetail)
                 && (this.DirectSendingCdDetail == target.DirectSendingCdDetail)
                 && (this.OrderNumber == target.OrderNumber)
                 && (this.WayToOrder == target.WayToOrder)
                 && (this.DeliGdsCmpltDueDate == target.DeliGdsCmpltDueDate)
                 && (this.ExpectDeliveryDate == target.ExpectDeliveryDate)
                 && (this.OrderDataCreateDiv == target.OrderDataCreateDiv)
                 && (this.OrderDataCreateDate == target.OrderDataCreateDate)
                 && (this.OrderFormIssuedDiv == target.OrderFormIssuedDiv)
                 && (this.TotalDay == target.TotalDay)
                 && (this.NTimeCalcStDate == target.NTimeCalcStDate)
                 && (this.PayeeName == target.PayeeName)
                 && (this.PayeeName2 == target.PayeeName2)
                 && (this.AddUpEnableCnt == target.AddUpEnableCnt)
                 && (this.AlreadyAddUpCnt == target.AlreadyAddUpCnt)
                 && (this.EditStatus == target.EditStatus)
                 && (this.DtlRelationGuid == target.DtlRelationGuid)
                 && (this.EnterpriseName == target.EnterpriseName)
                 && (this.UpdEmployeeName == target.UpdEmployeeName)
                 && (this.StockSectionNm == target.StockSectionNm)
                 && (this.StockAddUpSectionNm == target.StockAddUpSectionNm)
                 && (this.SuppCTaxLayMethodNm == target.SuppCTaxLayMethodNm)
                 && (this.BLGoodsName == target.BLGoodsName));
        }

        /// <summary>
        /// 仕入情報（売仕入同時入力）比較処理
        /// </summary>
        /// <param name="stockTemp1">
        ///                    比較するStockTempクラスのインスタンス
        /// </param>
        /// <param name="stockTemp2">比較するStockTempクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockTempクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static bool Equals(StockTemp stockTemp1, StockTemp stockTemp2)
        {
            return ((stockTemp1.CreateDateTime == stockTemp2.CreateDateTime)
                 && (stockTemp1.UpdateDateTime == stockTemp2.UpdateDateTime)
                 && (stockTemp1.EnterpriseCode == stockTemp2.EnterpriseCode)
                 && (stockTemp1.FileHeaderGuid == stockTemp2.FileHeaderGuid)
                 && (stockTemp1.UpdEmployeeCode == stockTemp2.UpdEmployeeCode)
                 && (stockTemp1.UpdAssemblyId1 == stockTemp2.UpdAssemblyId1)
                 && (stockTemp1.UpdAssemblyId2 == stockTemp2.UpdAssemblyId2)
                 && (stockTemp1.LogicalDeleteCode == stockTemp2.LogicalDeleteCode)
                 && (stockTemp1.SupplierFormal == stockTemp2.SupplierFormal)
                 && (stockTemp1.SupplierSlipNo == stockTemp2.SupplierSlipNo)
                 && (stockTemp1.SectionCode == stockTemp2.SectionCode)
                 && (stockTemp1.SubSectionCode == stockTemp2.SubSectionCode)
                 && (stockTemp1.DebitNoteDiv == stockTemp2.DebitNoteDiv)
                 && (stockTemp1.DebitNLnkSuppSlipNo == stockTemp2.DebitNLnkSuppSlipNo)
                 && (stockTemp1.SupplierSlipCd == stockTemp2.SupplierSlipCd)
                 && (stockTemp1.StockGoodsCd == stockTemp2.StockGoodsCd)
                 && (stockTemp1.AccPayDivCd == stockTemp2.AccPayDivCd)
                 && (stockTemp1.StockSectionCd == stockTemp2.StockSectionCd)
                 && (stockTemp1.StockAddUpSectionCd == stockTemp2.StockAddUpSectionCd)
                 && (stockTemp1.StockSlipUpdateCd == stockTemp2.StockSlipUpdateCd)
                 && (stockTemp1.InputDay == stockTemp2.InputDay)
                 && (stockTemp1.ArrivalGoodsDay == stockTemp2.ArrivalGoodsDay)
                 && (stockTemp1.StockDate == stockTemp2.StockDate)
                 && (stockTemp1.StockAddUpADate == stockTemp2.StockAddUpADate)
                 && (stockTemp1.DelayPaymentDiv == stockTemp2.DelayPaymentDiv)
                 && (stockTemp1.PayeeCode == stockTemp2.PayeeCode)
                 && (stockTemp1.PayeeSnm == stockTemp2.PayeeSnm)
                 && (stockTemp1.SupplierCd == stockTemp2.SupplierCd)
                 && (stockTemp1.SupplierNm1 == stockTemp2.SupplierNm1)
                 && (stockTemp1.SupplierNm2 == stockTemp2.SupplierNm2)
                 && (stockTemp1.SupplierSnm == stockTemp2.SupplierSnm)
                 && (stockTemp1.BusinessTypeCode == stockTemp2.BusinessTypeCode)
                 && (stockTemp1.BusinessTypeName == stockTemp2.BusinessTypeName)
                 && (stockTemp1.SalesAreaCode == stockTemp2.SalesAreaCode)
                 && (stockTemp1.SalesAreaName == stockTemp2.SalesAreaName)
                 && (stockTemp1.StockInputCode == stockTemp2.StockInputCode)
                 && (stockTemp1.StockInputName == stockTemp2.StockInputName)
                 && (stockTemp1.StockAgentCode == stockTemp2.StockAgentCode)
                 && (stockTemp1.StockAgentName == stockTemp2.StockAgentName)
                 && (stockTemp1.SuppTtlAmntDspWayCd == stockTemp2.SuppTtlAmntDspWayCd)
                 && (stockTemp1.TtlAmntDispRateApy == stockTemp2.TtlAmntDispRateApy)
                 && (stockTemp1.StockTotalPrice == stockTemp2.StockTotalPrice)
                 && (stockTemp1.StockSubttlPrice == stockTemp2.StockSubttlPrice)
                 && (stockTemp1.StockTtlPricTaxInc == stockTemp2.StockTtlPricTaxInc)
                 && (stockTemp1.StockTtlPricTaxExc == stockTemp2.StockTtlPricTaxExc)
                 && (stockTemp1.StockNetPrice == stockTemp2.StockNetPrice)
                 && (stockTemp1.StockPriceConsTax == stockTemp2.StockPriceConsTax)
                 && (stockTemp1.TtlItdedStcOutTax == stockTemp2.TtlItdedStcOutTax)
                 && (stockTemp1.TtlItdedStcInTax == stockTemp2.TtlItdedStcInTax)
                 && (stockTemp1.TtlItdedStcTaxFree == stockTemp2.TtlItdedStcTaxFree)
                 && (stockTemp1.StockOutTax == stockTemp2.StockOutTax)
                 && (stockTemp1.StckPrcConsTaxInclu == stockTemp2.StckPrcConsTaxInclu)
                 && (stockTemp1.StckDisTtlTaxExc == stockTemp2.StckDisTtlTaxExc)
                 && (stockTemp1.ItdedStockDisOutTax == stockTemp2.ItdedStockDisOutTax)
                 && (stockTemp1.ItdedStockDisInTax == stockTemp2.ItdedStockDisInTax)
                 && (stockTemp1.ItdedStockDisTaxFre == stockTemp2.ItdedStockDisTaxFre)
                 && (stockTemp1.StockDisOutTax == stockTemp2.StockDisOutTax)
                 && (stockTemp1.StckDisTtlTaxInclu == stockTemp2.StckDisTtlTaxInclu)
                 && (stockTemp1.TaxAdjust == stockTemp2.TaxAdjust)
                 && (stockTemp1.BalanceAdjust == stockTemp2.BalanceAdjust)
                 && (stockTemp1.SuppCTaxLayCd == stockTemp2.SuppCTaxLayCd)
                 && (stockTemp1.SupplierConsTaxRate == stockTemp2.SupplierConsTaxRate)
                 && (stockTemp1.AccPayConsTax == stockTemp2.AccPayConsTax)
                 && (stockTemp1.StockFractionProcCd == stockTemp2.StockFractionProcCd)
                 && (stockTemp1.AutoPayment == stockTemp2.AutoPayment)
                 && (stockTemp1.AutoPaySlipNum == stockTemp2.AutoPaySlipNum)
                 && (stockTemp1.RetGoodsReasonDiv == stockTemp2.RetGoodsReasonDiv)
                 && (stockTemp1.RetGoodsReason == stockTemp2.RetGoodsReason)
                 && (stockTemp1.PartySaleSlipNum == stockTemp2.PartySaleSlipNum)
                 && (stockTemp1.SupplierSlipNote1 == stockTemp2.SupplierSlipNote1)
                 && (stockTemp1.SupplierSlipNote2 == stockTemp2.SupplierSlipNote2)
                 && (stockTemp1.DetailRowCount == stockTemp2.DetailRowCount)
                 && (stockTemp1.EdiSendDate == stockTemp2.EdiSendDate)
                 && (stockTemp1.EdiTakeInDate == stockTemp2.EdiTakeInDate)
                 && (stockTemp1.UoeRemark1 == stockTemp2.UoeRemark1)
                 && (stockTemp1.UoeRemark2 == stockTemp2.UoeRemark2)
                 && (stockTemp1.SlipPrintDivCd == stockTemp2.SlipPrintDivCd)
                 && (stockTemp1.SlipPrintFinishCd == stockTemp2.SlipPrintFinishCd)
                 && (stockTemp1.StockSlipPrintDate == stockTemp2.StockSlipPrintDate)
                 && (stockTemp1.SlipPrtSetPaperId == stockTemp2.SlipPrtSetPaperId)
                 && (stockTemp1.SlipAddressDiv == stockTemp2.SlipAddressDiv)
                 && (stockTemp1.AddresseeCode == stockTemp2.AddresseeCode)
                 && (stockTemp1.AddresseeName == stockTemp2.AddresseeName)
                 && (stockTemp1.AddresseeName2 == stockTemp2.AddresseeName2)
                 && (stockTemp1.AddresseePostNo == stockTemp2.AddresseePostNo)
                 && (stockTemp1.AddresseeAddr1 == stockTemp2.AddresseeAddr1)
                 && (stockTemp1.AddresseeAddr3 == stockTemp2.AddresseeAddr3)
                 && (stockTemp1.AddresseeAddr4 == stockTemp2.AddresseeAddr4)
                 && (stockTemp1.AddresseeTelNo == stockTemp2.AddresseeTelNo)
                 && (stockTemp1.AddresseeFaxNo == stockTemp2.AddresseeFaxNo)
                 && (stockTemp1.DirectSendingCd == stockTemp2.DirectSendingCd)
                 && (stockTemp1.AcceptAnOrderNo == stockTemp2.AcceptAnOrderNo)
                 && (stockTemp1.SupplierFormalDetail == stockTemp2.SupplierFormalDetail)
                 && (stockTemp1.SupplierSlipNoDetail == stockTemp2.SupplierSlipNoDetail)
                 && (stockTemp1.StockRowNo == stockTemp2.StockRowNo)
                 && (stockTemp1.SectionCodeDetail == stockTemp2.SectionCodeDetail)
                 && (stockTemp1.SubSectionCodeDetail == stockTemp2.SubSectionCodeDetail)
                 && (stockTemp1.CommonSeqNo == stockTemp2.CommonSeqNo)
                 && (stockTemp1.StockSlipDtlNum == stockTemp2.StockSlipDtlNum)
                 && (stockTemp1.SupplierFormalSrc == stockTemp2.SupplierFormalSrc)
                 && (stockTemp1.StockSlipDtlNumSrc == stockTemp2.StockSlipDtlNumSrc)
                 && (stockTemp1.AcptAnOdrStatusSync == stockTemp2.AcptAnOdrStatusSync)
                 && (stockTemp1.SalesSlipDtlNumSync == stockTemp2.SalesSlipDtlNumSync)
                 && (stockTemp1.StockSlipCdDtl == stockTemp2.StockSlipCdDtl)
                 && (stockTemp1.StockInputCodeDetail == stockTemp2.StockInputCodeDetail)
                 && (stockTemp1.StockInputNameDetail == stockTemp2.StockInputNameDetail)
                 && (stockTemp1.StockAgentCodeDetail == stockTemp2.StockAgentCodeDetail)
                 && (stockTemp1.StockAgentNameDetail == stockTemp2.StockAgentNameDetail)
                 && (stockTemp1.GoodsKindCode == stockTemp2.GoodsKindCode)
                 && (stockTemp1.GoodsMakerCd == stockTemp2.GoodsMakerCd)
                 && (stockTemp1.MakerName == stockTemp2.MakerName)
                 && (stockTemp1.MakerKanaName == stockTemp2.MakerKanaName)
                 && (stockTemp1.CmpltMakerKanaName == stockTemp2.CmpltMakerKanaName)
                 && (stockTemp1.GoodsNo == stockTemp2.GoodsNo)
                 && (stockTemp1.GoodsName == stockTemp2.GoodsName)
                 && (stockTemp1.GoodsNameKana == stockTemp2.GoodsNameKana)
                 && (stockTemp1.GoodsLGroup == stockTemp2.GoodsLGroup)
                 && (stockTemp1.GoodsLGroupName == stockTemp2.GoodsLGroupName)
                 && (stockTemp1.GoodsMGroup == stockTemp2.GoodsMGroup)
                 && (stockTemp1.GoodsMGroupName == stockTemp2.GoodsMGroupName)
                 && (stockTemp1.BLGroupCode == stockTemp2.BLGroupCode)
                 && (stockTemp1.BLGroupName == stockTemp2.BLGroupName)
                 && (stockTemp1.BLGoodsCode == stockTemp2.BLGoodsCode)
                 && (stockTemp1.BLGoodsFullName == stockTemp2.BLGoodsFullName)
                 && (stockTemp1.EnterpriseGanreCode == stockTemp2.EnterpriseGanreCode)
                 && (stockTemp1.EnterpriseGanreName == stockTemp2.EnterpriseGanreName)
                 && (stockTemp1.WarehouseCode == stockTemp2.WarehouseCode)
                 && (stockTemp1.WarehouseName == stockTemp2.WarehouseName)
                 && (stockTemp1.WarehouseShelfNo == stockTemp2.WarehouseShelfNo)
                 && (stockTemp1.StockOrderDivCd == stockTemp2.StockOrderDivCd)
                 && (stockTemp1.OpenPriceDiv == stockTemp2.OpenPriceDiv)
                 && (stockTemp1.GoodsRateRank == stockTemp2.GoodsRateRank)
                 && (stockTemp1.CustRateGrpCode == stockTemp2.CustRateGrpCode)
                 && (stockTemp1.SuppRateGrpCode == stockTemp2.SuppRateGrpCode)
                 && (stockTemp1.ListPriceTaxExcFl == stockTemp2.ListPriceTaxExcFl)
                 && (stockTemp1.ListPriceTaxIncFl == stockTemp2.ListPriceTaxIncFl)
                 && (stockTemp1.StockRate == stockTemp2.StockRate)
                 && (stockTemp1.RateSectStckUnPrc == stockTemp2.RateSectStckUnPrc)
                 && (stockTemp1.RateDivStckUnPrc == stockTemp2.RateDivStckUnPrc)
                 && (stockTemp1.UnPrcCalcCdStckUnPrc == stockTemp2.UnPrcCalcCdStckUnPrc)
                 && (stockTemp1.PriceCdStckUnPrc == stockTemp2.PriceCdStckUnPrc)
                 && (stockTemp1.StdUnPrcStckUnPrc == stockTemp2.StdUnPrcStckUnPrc)
                 && (stockTemp1.FracProcUnitStcUnPrc == stockTemp2.FracProcUnitStcUnPrc)
                 && (stockTemp1.FracProcStckUnPrc == stockTemp2.FracProcStckUnPrc)
                 && (stockTemp1.StockUnitPriceFl == stockTemp2.StockUnitPriceFl)
                 && (stockTemp1.StockUnitTaxPriceFl == stockTemp2.StockUnitTaxPriceFl)
                 && (stockTemp1.StockUnitChngDiv == stockTemp2.StockUnitChngDiv)
                 && (stockTemp1.BfStockUnitPriceFl == stockTemp2.BfStockUnitPriceFl)
                 && (stockTemp1.BfListPrice == stockTemp2.BfListPrice)
                 && (stockTemp1.RateBLGoodsCode == stockTemp2.RateBLGoodsCode)
                 && (stockTemp1.RateBLGoodsName == stockTemp2.RateBLGoodsName)
                 && (stockTemp1.RateGoodsRateGrpCd == stockTemp2.RateGoodsRateGrpCd)
                 && (stockTemp1.RateGoodsRateGrpNm == stockTemp2.RateGoodsRateGrpNm)
                 && (stockTemp1.RateBLGroupCode == stockTemp2.RateBLGroupCode)
                 && (stockTemp1.RateBLGroupName == stockTemp2.RateBLGroupName)
                 && (stockTemp1.StockCount == stockTemp2.StockCount)
                 && (stockTemp1.OrderCnt == stockTemp2.OrderCnt)
                 && (stockTemp1.OrderAdjustCnt == stockTemp2.OrderAdjustCnt)
                 && (stockTemp1.OrderRemainCnt == stockTemp2.OrderRemainCnt)
                 && (stockTemp1.RemainCntUpdDate == stockTemp2.RemainCntUpdDate)
                 && (stockTemp1.StockPriceTaxExc == stockTemp2.StockPriceTaxExc)
                 && (stockTemp1.StockPriceTaxInc == stockTemp2.StockPriceTaxInc)
                 && (stockTemp1.StockGoodsCdDetail == stockTemp2.StockGoodsCdDetail)
                 && (stockTemp1.StockPriceConsTaxDetail == stockTemp2.StockPriceConsTaxDetail)
                 && (stockTemp1.TaxationCode == stockTemp2.TaxationCode)
                 && (stockTemp1.StockDtiSlipNote1 == stockTemp2.StockDtiSlipNote1)
                 && (stockTemp1.SalesCustomerCode == stockTemp2.SalesCustomerCode)
                 && (stockTemp1.SalesCustomerSnm == stockTemp2.SalesCustomerSnm)
                 && (stockTemp1.SlipMemo1 == stockTemp2.SlipMemo1)
                 && (stockTemp1.SlipMemo2 == stockTemp2.SlipMemo2)
                 && (stockTemp1.SlipMemo3 == stockTemp2.SlipMemo3)
                 && (stockTemp1.InsideMemo1 == stockTemp2.InsideMemo1)
                 && (stockTemp1.InsideMemo2 == stockTemp2.InsideMemo2)
                 && (stockTemp1.InsideMemo3 == stockTemp2.InsideMemo3)
                 && (stockTemp1.SupplierCdDetail == stockTemp2.SupplierCdDetail)
                 && (stockTemp1.SupplierSnmDetail == stockTemp2.SupplierSnmDetail)
                 && (stockTemp1.AddresseeCodeDetail == stockTemp2.AddresseeCodeDetail)
                 && (stockTemp1.AddresseeNameDetail == stockTemp2.AddresseeNameDetail)
                 && (stockTemp1.DirectSendingCdDetail == stockTemp2.DirectSendingCdDetail)
                 && (stockTemp1.OrderNumber == stockTemp2.OrderNumber)
                 && (stockTemp1.WayToOrder == stockTemp2.WayToOrder)
                 && (stockTemp1.DeliGdsCmpltDueDate == stockTemp2.DeliGdsCmpltDueDate)
                 && (stockTemp1.ExpectDeliveryDate == stockTemp2.ExpectDeliveryDate)
                 && (stockTemp1.OrderDataCreateDiv == stockTemp2.OrderDataCreateDiv)
                 && (stockTemp1.OrderDataCreateDate == stockTemp2.OrderDataCreateDate)
                 && (stockTemp1.OrderFormIssuedDiv == stockTemp2.OrderFormIssuedDiv)
                 && (stockTemp1.TotalDay == stockTemp2.TotalDay)
                 && (stockTemp1.NTimeCalcStDate == stockTemp2.NTimeCalcStDate)
                 && (stockTemp1.PayeeName == stockTemp2.PayeeName)
                 && (stockTemp1.PayeeName2 == stockTemp2.PayeeName2)
                 && (stockTemp1.AddUpEnableCnt == stockTemp2.AddUpEnableCnt)
                 && (stockTemp1.AlreadyAddUpCnt == stockTemp2.AlreadyAddUpCnt)
                 && (stockTemp1.EditStatus == stockTemp2.EditStatus)
                 && (stockTemp1.DtlRelationGuid == stockTemp2.DtlRelationGuid)
                 && (stockTemp1.EnterpriseName == stockTemp2.EnterpriseName)
                 && (stockTemp1.UpdEmployeeName == stockTemp2.UpdEmployeeName)
                 && (stockTemp1.StockSectionNm == stockTemp2.StockSectionNm)
                 && (stockTemp1.StockAddUpSectionNm == stockTemp2.StockAddUpSectionNm)
                 && (stockTemp1.SuppCTaxLayMethodNm == stockTemp2.SuppCTaxLayMethodNm)
                 && (stockTemp1.BLGoodsName == stockTemp2.BLGoodsName));
        }
        /// <summary>
        /// 仕入情報（売仕入同時入力）比較処理
        /// </summary>
        /// <param name="target">比較対象のStockTempクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockTempクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList Compare(StockTemp target)
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
            if (this.SupplierFormal != target.SupplierFormal) resList.Add("SupplierFormal");
            if (this.SupplierSlipNo != target.SupplierSlipNo) resList.Add("SupplierSlipNo");
            if (this.SectionCode != target.SectionCode) resList.Add("SectionCode");
            if (this.SubSectionCode != target.SubSectionCode) resList.Add("SubSectionCode");
            if (this.DebitNoteDiv != target.DebitNoteDiv) resList.Add("DebitNoteDiv");
            if (this.DebitNLnkSuppSlipNo != target.DebitNLnkSuppSlipNo) resList.Add("DebitNLnkSuppSlipNo");
            if (this.SupplierSlipCd != target.SupplierSlipCd) resList.Add("SupplierSlipCd");
            if (this.StockGoodsCd != target.StockGoodsCd) resList.Add("StockGoodsCd");
            if (this.AccPayDivCd != target.AccPayDivCd) resList.Add("AccPayDivCd");
            if (this.StockSectionCd != target.StockSectionCd) resList.Add("StockSectionCd");
            if (this.StockAddUpSectionCd != target.StockAddUpSectionCd) resList.Add("StockAddUpSectionCd");
            if (this.StockSlipUpdateCd != target.StockSlipUpdateCd) resList.Add("StockSlipUpdateCd");
            if (this.InputDay != target.InputDay) resList.Add("InputDay");
            if (this.ArrivalGoodsDay != target.ArrivalGoodsDay) resList.Add("ArrivalGoodsDay");
            if (this.StockDate != target.StockDate) resList.Add("StockDate");
            if (this.StockAddUpADate != target.StockAddUpADate) resList.Add("StockAddUpADate");
            if (this.DelayPaymentDiv != target.DelayPaymentDiv) resList.Add("DelayPaymentDiv");
            if (this.PayeeCode != target.PayeeCode) resList.Add("PayeeCode");
            if (this.PayeeSnm != target.PayeeSnm) resList.Add("PayeeSnm");
            if (this.SupplierCd != target.SupplierCd) resList.Add("SupplierCd");
            if (this.SupplierNm1 != target.SupplierNm1) resList.Add("SupplierNm1");
            if (this.SupplierNm2 != target.SupplierNm2) resList.Add("SupplierNm2");
            if (this.SupplierSnm != target.SupplierSnm) resList.Add("SupplierSnm");
            if (this.BusinessTypeCode != target.BusinessTypeCode) resList.Add("BusinessTypeCode");
            if (this.BusinessTypeName != target.BusinessTypeName) resList.Add("BusinessTypeName");
            if (this.SalesAreaCode != target.SalesAreaCode) resList.Add("SalesAreaCode");
            if (this.SalesAreaName != target.SalesAreaName) resList.Add("SalesAreaName");
            if (this.StockInputCode != target.StockInputCode) resList.Add("StockInputCode");
            if (this.StockInputName != target.StockInputName) resList.Add("StockInputName");
            if (this.StockAgentCode != target.StockAgentCode) resList.Add("StockAgentCode");
            if (this.StockAgentName != target.StockAgentName) resList.Add("StockAgentName");
            if (this.SuppTtlAmntDspWayCd != target.SuppTtlAmntDspWayCd) resList.Add("SuppTtlAmntDspWayCd");
            if (this.TtlAmntDispRateApy != target.TtlAmntDispRateApy) resList.Add("TtlAmntDispRateApy");
            if (this.StockTotalPrice != target.StockTotalPrice) resList.Add("StockTotalPrice");
            if (this.StockSubttlPrice != target.StockSubttlPrice) resList.Add("StockSubttlPrice");
            if (this.StockTtlPricTaxInc != target.StockTtlPricTaxInc) resList.Add("StockTtlPricTaxInc");
            if (this.StockTtlPricTaxExc != target.StockTtlPricTaxExc) resList.Add("StockTtlPricTaxExc");
            if (this.StockNetPrice != target.StockNetPrice) resList.Add("StockNetPrice");
            if (this.StockPriceConsTax != target.StockPriceConsTax) resList.Add("StockPriceConsTax");
            if (this.TtlItdedStcOutTax != target.TtlItdedStcOutTax) resList.Add("TtlItdedStcOutTax");
            if (this.TtlItdedStcInTax != target.TtlItdedStcInTax) resList.Add("TtlItdedStcInTax");
            if (this.TtlItdedStcTaxFree != target.TtlItdedStcTaxFree) resList.Add("TtlItdedStcTaxFree");
            if (this.StockOutTax != target.StockOutTax) resList.Add("StockOutTax");
            if (this.StckPrcConsTaxInclu != target.StckPrcConsTaxInclu) resList.Add("StckPrcConsTaxInclu");
            if (this.StckDisTtlTaxExc != target.StckDisTtlTaxExc) resList.Add("StckDisTtlTaxExc");
            if (this.ItdedStockDisOutTax != target.ItdedStockDisOutTax) resList.Add("ItdedStockDisOutTax");
            if (this.ItdedStockDisInTax != target.ItdedStockDisInTax) resList.Add("ItdedStockDisInTax");
            if (this.ItdedStockDisTaxFre != target.ItdedStockDisTaxFre) resList.Add("ItdedStockDisTaxFre");
            if (this.StockDisOutTax != target.StockDisOutTax) resList.Add("StockDisOutTax");
            if (this.StckDisTtlTaxInclu != target.StckDisTtlTaxInclu) resList.Add("StckDisTtlTaxInclu");
            if (this.TaxAdjust != target.TaxAdjust) resList.Add("TaxAdjust");
            if (this.BalanceAdjust != target.BalanceAdjust) resList.Add("BalanceAdjust");
            if (this.SuppCTaxLayCd != target.SuppCTaxLayCd) resList.Add("SuppCTaxLayCd");
            if (this.SupplierConsTaxRate != target.SupplierConsTaxRate) resList.Add("SupplierConsTaxRate");
            if (this.AccPayConsTax != target.AccPayConsTax) resList.Add("AccPayConsTax");
            if (this.StockFractionProcCd != target.StockFractionProcCd) resList.Add("StockFractionProcCd");
            if (this.AutoPayment != target.AutoPayment) resList.Add("AutoPayment");
            if (this.AutoPaySlipNum != target.AutoPaySlipNum) resList.Add("AutoPaySlipNum");
            if (this.RetGoodsReasonDiv != target.RetGoodsReasonDiv) resList.Add("RetGoodsReasonDiv");
            if (this.RetGoodsReason != target.RetGoodsReason) resList.Add("RetGoodsReason");
            if (this.PartySaleSlipNum != target.PartySaleSlipNum) resList.Add("PartySaleSlipNum");
            if (this.SupplierSlipNote1 != target.SupplierSlipNote1) resList.Add("SupplierSlipNote1");
            if (this.SupplierSlipNote2 != target.SupplierSlipNote2) resList.Add("SupplierSlipNote2");
            if (this.DetailRowCount != target.DetailRowCount) resList.Add("DetailRowCount");
            if (this.EdiSendDate != target.EdiSendDate) resList.Add("EdiSendDate");
            if (this.EdiTakeInDate != target.EdiTakeInDate) resList.Add("EdiTakeInDate");
            if (this.UoeRemark1 != target.UoeRemark1) resList.Add("UoeRemark1");
            if (this.UoeRemark2 != target.UoeRemark2) resList.Add("UoeRemark2");
            if (this.SlipPrintDivCd != target.SlipPrintDivCd) resList.Add("SlipPrintDivCd");
            if (this.SlipPrintFinishCd != target.SlipPrintFinishCd) resList.Add("SlipPrintFinishCd");
            if (this.StockSlipPrintDate != target.StockSlipPrintDate) resList.Add("StockSlipPrintDate");
            if (this.SlipPrtSetPaperId != target.SlipPrtSetPaperId) resList.Add("SlipPrtSetPaperId");
            if (this.SlipAddressDiv != target.SlipAddressDiv) resList.Add("SlipAddressDiv");
            if (this.AddresseeCode != target.AddresseeCode) resList.Add("AddresseeCode");
            if (this.AddresseeName != target.AddresseeName) resList.Add("AddresseeName");
            if (this.AddresseeName2 != target.AddresseeName2) resList.Add("AddresseeName2");
            if (this.AddresseePostNo != target.AddresseePostNo) resList.Add("AddresseePostNo");
            if (this.AddresseeAddr1 != target.AddresseeAddr1) resList.Add("AddresseeAddr1");
            if (this.AddresseeAddr3 != target.AddresseeAddr3) resList.Add("AddresseeAddr3");
            if (this.AddresseeAddr4 != target.AddresseeAddr4) resList.Add("AddresseeAddr4");
            if (this.AddresseeTelNo != target.AddresseeTelNo) resList.Add("AddresseeTelNo");
            if (this.AddresseeFaxNo != target.AddresseeFaxNo) resList.Add("AddresseeFaxNo");
            if (this.DirectSendingCd != target.DirectSendingCd) resList.Add("DirectSendingCd");
            if (this.AcceptAnOrderNo != target.AcceptAnOrderNo) resList.Add("AcceptAnOrderNo");
            if (this.SupplierFormalDetail != target.SupplierFormalDetail) resList.Add("SupplierFormalDetail");
            if (this.SupplierSlipNoDetail != target.SupplierSlipNoDetail) resList.Add("SupplierSlipNoDetail");
            if (this.StockRowNo != target.StockRowNo) resList.Add("StockRowNo");
            if (this.SectionCodeDetail != target.SectionCodeDetail) resList.Add("SectionCodeDetail");
            if (this.SubSectionCodeDetail != target.SubSectionCodeDetail) resList.Add("SubSectionCodeDetail");
            if (this.CommonSeqNo != target.CommonSeqNo) resList.Add("CommonSeqNo");
            if (this.StockSlipDtlNum != target.StockSlipDtlNum) resList.Add("StockSlipDtlNum");
            if (this.SupplierFormalSrc != target.SupplierFormalSrc) resList.Add("SupplierFormalSrc");
            if (this.StockSlipDtlNumSrc != target.StockSlipDtlNumSrc) resList.Add("StockSlipDtlNumSrc");
            if (this.AcptAnOdrStatusSync != target.AcptAnOdrStatusSync) resList.Add("AcptAnOdrStatusSync");
            if (this.SalesSlipDtlNumSync != target.SalesSlipDtlNumSync) resList.Add("SalesSlipDtlNumSync");
            if (this.StockSlipCdDtl != target.StockSlipCdDtl) resList.Add("StockSlipCdDtl");
            if (this.StockInputCodeDetail != target.StockInputCodeDetail) resList.Add("StockInputCodeDetail");
            if (this.StockInputNameDetail != target.StockInputNameDetail) resList.Add("StockInputNameDetail");
            if (this.StockAgentCodeDetail != target.StockAgentCodeDetail) resList.Add("StockAgentCodeDetail");
            if (this.StockAgentNameDetail != target.StockAgentNameDetail) resList.Add("StockAgentNameDetail");
            if (this.GoodsKindCode != target.GoodsKindCode) resList.Add("GoodsKindCode");
            if (this.GoodsMakerCd != target.GoodsMakerCd) resList.Add("GoodsMakerCd");
            if (this.MakerName != target.MakerName) resList.Add("MakerName");
            if (this.MakerKanaName != target.MakerKanaName) resList.Add("MakerKanaName");
            if (this.CmpltMakerKanaName != target.CmpltMakerKanaName) resList.Add("CmpltMakerKanaName");
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
            if (this.StockOrderDivCd != target.StockOrderDivCd) resList.Add("StockOrderDivCd");
            if (this.OpenPriceDiv != target.OpenPriceDiv) resList.Add("OpenPriceDiv");
            if (this.GoodsRateRank != target.GoodsRateRank) resList.Add("GoodsRateRank");
            if (this.CustRateGrpCode != target.CustRateGrpCode) resList.Add("CustRateGrpCode");
            if (this.SuppRateGrpCode != target.SuppRateGrpCode) resList.Add("SuppRateGrpCode");
            if (this.ListPriceTaxExcFl != target.ListPriceTaxExcFl) resList.Add("ListPriceTaxExcFl");
            if (this.ListPriceTaxIncFl != target.ListPriceTaxIncFl) resList.Add("ListPriceTaxIncFl");
            if (this.StockRate != target.StockRate) resList.Add("StockRate");
            if (this.RateSectStckUnPrc != target.RateSectStckUnPrc) resList.Add("RateSectStckUnPrc");
            if (this.RateDivStckUnPrc != target.RateDivStckUnPrc) resList.Add("RateDivStckUnPrc");
            if (this.UnPrcCalcCdStckUnPrc != target.UnPrcCalcCdStckUnPrc) resList.Add("UnPrcCalcCdStckUnPrc");
            if (this.PriceCdStckUnPrc != target.PriceCdStckUnPrc) resList.Add("PriceCdStckUnPrc");
            if (this.StdUnPrcStckUnPrc != target.StdUnPrcStckUnPrc) resList.Add("StdUnPrcStckUnPrc");
            if (this.FracProcUnitStcUnPrc != target.FracProcUnitStcUnPrc) resList.Add("FracProcUnitStcUnPrc");
            if (this.FracProcStckUnPrc != target.FracProcStckUnPrc) resList.Add("FracProcStckUnPrc");
            if (this.StockUnitPriceFl != target.StockUnitPriceFl) resList.Add("StockUnitPriceFl");
            if (this.StockUnitTaxPriceFl != target.StockUnitTaxPriceFl) resList.Add("StockUnitTaxPriceFl");
            if (this.StockUnitChngDiv != target.StockUnitChngDiv) resList.Add("StockUnitChngDiv");
            if (this.BfStockUnitPriceFl != target.BfStockUnitPriceFl) resList.Add("BfStockUnitPriceFl");
            if (this.BfListPrice != target.BfListPrice) resList.Add("BfListPrice");
            if (this.RateBLGoodsCode != target.RateBLGoodsCode) resList.Add("RateBLGoodsCode");
            if (this.RateBLGoodsName != target.RateBLGoodsName) resList.Add("RateBLGoodsName");
            if (this.RateGoodsRateGrpCd != target.RateGoodsRateGrpCd) resList.Add("RateGoodsRateGrpCd");
            if (this.RateGoodsRateGrpNm != target.RateGoodsRateGrpNm) resList.Add("RateGoodsRateGrpNm");
            if (this.RateBLGroupCode != target.RateBLGroupCode) resList.Add("RateBLGroupCode");
            if (this.RateBLGroupName != target.RateBLGroupName) resList.Add("RateBLGroupName");
            if (this.StockCount != target.StockCount) resList.Add("StockCount");
            if (this.OrderCnt != target.OrderCnt) resList.Add("OrderCnt");
            if (this.OrderAdjustCnt != target.OrderAdjustCnt) resList.Add("OrderAdjustCnt");
            if (this.OrderRemainCnt != target.OrderRemainCnt) resList.Add("OrderRemainCnt");
            if (this.RemainCntUpdDate != target.RemainCntUpdDate) resList.Add("RemainCntUpdDate");
            if (this.StockPriceTaxExc != target.StockPriceTaxExc) resList.Add("StockPriceTaxExc");
            if (this.StockPriceTaxInc != target.StockPriceTaxInc) resList.Add("StockPriceTaxInc");
            if (this.StockGoodsCdDetail != target.StockGoodsCdDetail) resList.Add("StockGoodsCdDetail");
            if (this.StockPriceConsTaxDetail != target.StockPriceConsTaxDetail) resList.Add("StockPriceConsTaxDetail");
            if (this.TaxationCode != target.TaxationCode) resList.Add("TaxationCode");
            if (this.StockDtiSlipNote1 != target.StockDtiSlipNote1) resList.Add("StockDtiSlipNote1");
            if (this.SalesCustomerCode != target.SalesCustomerCode) resList.Add("SalesCustomerCode");
            if (this.SalesCustomerSnm != target.SalesCustomerSnm) resList.Add("SalesCustomerSnm");
            if (this.SlipMemo1 != target.SlipMemo1) resList.Add("SlipMemo1");
            if (this.SlipMemo2 != target.SlipMemo2) resList.Add("SlipMemo2");
            if (this.SlipMemo3 != target.SlipMemo3) resList.Add("SlipMemo3");
            if (this.InsideMemo1 != target.InsideMemo1) resList.Add("InsideMemo1");
            if (this.InsideMemo2 != target.InsideMemo2) resList.Add("InsideMemo2");
            if (this.InsideMemo3 != target.InsideMemo3) resList.Add("InsideMemo3");
            if (this.SupplierCdDetail != target.SupplierCdDetail) resList.Add("SupplierCdDetail");
            if (this.SupplierSnmDetail != target.SupplierSnmDetail) resList.Add("SupplierSnmDetail");
            if (this.AddresseeCodeDetail != target.AddresseeCodeDetail) resList.Add("AddresseeCodeDetail");
            if (this.AddresseeNameDetail != target.AddresseeNameDetail) resList.Add("AddresseeNameDetail");
            if (this.DirectSendingCdDetail != target.DirectSendingCdDetail) resList.Add("DirectSendingCdDetail");
            if (this.OrderNumber != target.OrderNumber) resList.Add("OrderNumber");
            if (this.WayToOrder != target.WayToOrder) resList.Add("WayToOrder");
            if (this.DeliGdsCmpltDueDate != target.DeliGdsCmpltDueDate) resList.Add("DeliGdsCmpltDueDate");
            if (this.ExpectDeliveryDate != target.ExpectDeliveryDate) resList.Add("ExpectDeliveryDate");
            if (this.OrderDataCreateDiv != target.OrderDataCreateDiv) resList.Add("OrderDataCreateDiv");
            if (this.OrderDataCreateDate != target.OrderDataCreateDate) resList.Add("OrderDataCreateDate");
            if (this.OrderFormIssuedDiv != target.OrderFormIssuedDiv) resList.Add("OrderFormIssuedDiv");
            if (this.TotalDay != target.TotalDay) resList.Add("TotalDay");
            if (this.NTimeCalcStDate != target.NTimeCalcStDate) resList.Add("NTimeCalcStDate");
            if (this.PayeeName != target.PayeeName) resList.Add("PayeeName");
            if (this.PayeeName2 != target.PayeeName2) resList.Add("PayeeName2");
            if (this.AddUpEnableCnt != target.AddUpEnableCnt) resList.Add("AddUpEnableCnt");
            if (this.AlreadyAddUpCnt != target.AlreadyAddUpCnt) resList.Add("AlreadyAddUpCnt");
            if (this.EditStatus != target.EditStatus) resList.Add("EditStatus");
            if (this.DtlRelationGuid != target.DtlRelationGuid) resList.Add("DtlRelationGuid");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            if (this.UpdEmployeeName != target.UpdEmployeeName) resList.Add("UpdEmployeeName");
            if (this.StockSectionNm != target.StockSectionNm) resList.Add("StockSectionNm");
            if (this.StockAddUpSectionNm != target.StockAddUpSectionNm) resList.Add("StockAddUpSectionNm");
            if (this.SuppCTaxLayMethodNm != target.SuppCTaxLayMethodNm) resList.Add("SuppCTaxLayMethodNm");
            if (this.BLGoodsName != target.BLGoodsName) resList.Add("BLGoodsName");

            return resList;
        }

        /// <summary>
        /// 仕入情報（売仕入同時入力）比較処理
        /// </summary>
        /// <param name="stockTemp1">比較するStockTempクラスのインスタンス</param>
        /// <param name="stockTemp2">比較するStockTempクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockTempクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static ArrayList Compare(StockTemp stockTemp1, StockTemp stockTemp2)
        {
            ArrayList resList = new ArrayList();
            if (stockTemp1.CreateDateTime != stockTemp2.CreateDateTime) resList.Add("CreateDateTime");
            if (stockTemp1.UpdateDateTime != stockTemp2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (stockTemp1.EnterpriseCode != stockTemp2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (stockTemp1.FileHeaderGuid != stockTemp2.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (stockTemp1.UpdEmployeeCode != stockTemp2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (stockTemp1.UpdAssemblyId1 != stockTemp2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (stockTemp1.UpdAssemblyId2 != stockTemp2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (stockTemp1.LogicalDeleteCode != stockTemp2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (stockTemp1.SupplierFormal != stockTemp2.SupplierFormal) resList.Add("SupplierFormal");
            if (stockTemp1.SupplierSlipNo != stockTemp2.SupplierSlipNo) resList.Add("SupplierSlipNo");
            if (stockTemp1.SectionCode != stockTemp2.SectionCode) resList.Add("SectionCode");
            if (stockTemp1.SubSectionCode != stockTemp2.SubSectionCode) resList.Add("SubSectionCode");
            if (stockTemp1.DebitNoteDiv != stockTemp2.DebitNoteDiv) resList.Add("DebitNoteDiv");
            if (stockTemp1.DebitNLnkSuppSlipNo != stockTemp2.DebitNLnkSuppSlipNo) resList.Add("DebitNLnkSuppSlipNo");
            if (stockTemp1.SupplierSlipCd != stockTemp2.SupplierSlipCd) resList.Add("SupplierSlipCd");
            if (stockTemp1.StockGoodsCd != stockTemp2.StockGoodsCd) resList.Add("StockGoodsCd");
            if (stockTemp1.AccPayDivCd != stockTemp2.AccPayDivCd) resList.Add("AccPayDivCd");
            if (stockTemp1.StockSectionCd != stockTemp2.StockSectionCd) resList.Add("StockSectionCd");
            if (stockTemp1.StockAddUpSectionCd != stockTemp2.StockAddUpSectionCd) resList.Add("StockAddUpSectionCd");
            if (stockTemp1.StockSlipUpdateCd != stockTemp2.StockSlipUpdateCd) resList.Add("StockSlipUpdateCd");
            if (stockTemp1.InputDay != stockTemp2.InputDay) resList.Add("InputDay");
            if (stockTemp1.ArrivalGoodsDay != stockTemp2.ArrivalGoodsDay) resList.Add("ArrivalGoodsDay");
            if (stockTemp1.StockDate != stockTemp2.StockDate) resList.Add("StockDate");
            if (stockTemp1.StockAddUpADate != stockTemp2.StockAddUpADate) resList.Add("StockAddUpADate");
            if (stockTemp1.DelayPaymentDiv != stockTemp2.DelayPaymentDiv) resList.Add("DelayPaymentDiv");
            if (stockTemp1.PayeeCode != stockTemp2.PayeeCode) resList.Add("PayeeCode");
            if (stockTemp1.PayeeSnm != stockTemp2.PayeeSnm) resList.Add("PayeeSnm");
            if (stockTemp1.SupplierCd != stockTemp2.SupplierCd) resList.Add("SupplierCd");
            if (stockTemp1.SupplierNm1 != stockTemp2.SupplierNm1) resList.Add("SupplierNm1");
            if (stockTemp1.SupplierNm2 != stockTemp2.SupplierNm2) resList.Add("SupplierNm2");
            if (stockTemp1.SupplierSnm != stockTemp2.SupplierSnm) resList.Add("SupplierSnm");
            if (stockTemp1.BusinessTypeCode != stockTemp2.BusinessTypeCode) resList.Add("BusinessTypeCode");
            if (stockTemp1.BusinessTypeName != stockTemp2.BusinessTypeName) resList.Add("BusinessTypeName");
            if (stockTemp1.SalesAreaCode != stockTemp2.SalesAreaCode) resList.Add("SalesAreaCode");
            if (stockTemp1.SalesAreaName != stockTemp2.SalesAreaName) resList.Add("SalesAreaName");
            if (stockTemp1.StockInputCode != stockTemp2.StockInputCode) resList.Add("StockInputCode");
            if (stockTemp1.StockInputName != stockTemp2.StockInputName) resList.Add("StockInputName");
            if (stockTemp1.StockAgentCode != stockTemp2.StockAgentCode) resList.Add("StockAgentCode");
            if (stockTemp1.StockAgentName != stockTemp2.StockAgentName) resList.Add("StockAgentName");
            if (stockTemp1.SuppTtlAmntDspWayCd != stockTemp2.SuppTtlAmntDspWayCd) resList.Add("SuppTtlAmntDspWayCd");
            if (stockTemp1.TtlAmntDispRateApy != stockTemp2.TtlAmntDispRateApy) resList.Add("TtlAmntDispRateApy");
            if (stockTemp1.StockTotalPrice != stockTemp2.StockTotalPrice) resList.Add("StockTotalPrice");
            if (stockTemp1.StockSubttlPrice != stockTemp2.StockSubttlPrice) resList.Add("StockSubttlPrice");
            if (stockTemp1.StockTtlPricTaxInc != stockTemp2.StockTtlPricTaxInc) resList.Add("StockTtlPricTaxInc");
            if (stockTemp1.StockTtlPricTaxExc != stockTemp2.StockTtlPricTaxExc) resList.Add("StockTtlPricTaxExc");
            if (stockTemp1.StockNetPrice != stockTemp2.StockNetPrice) resList.Add("StockNetPrice");
            if (stockTemp1.StockPriceConsTax != stockTemp2.StockPriceConsTax) resList.Add("StockPriceConsTax");
            if (stockTemp1.TtlItdedStcOutTax != stockTemp2.TtlItdedStcOutTax) resList.Add("TtlItdedStcOutTax");
            if (stockTemp1.TtlItdedStcInTax != stockTemp2.TtlItdedStcInTax) resList.Add("TtlItdedStcInTax");
            if (stockTemp1.TtlItdedStcTaxFree != stockTemp2.TtlItdedStcTaxFree) resList.Add("TtlItdedStcTaxFree");
            if (stockTemp1.StockOutTax != stockTemp2.StockOutTax) resList.Add("StockOutTax");
            if (stockTemp1.StckPrcConsTaxInclu != stockTemp2.StckPrcConsTaxInclu) resList.Add("StckPrcConsTaxInclu");
            if (stockTemp1.StckDisTtlTaxExc != stockTemp2.StckDisTtlTaxExc) resList.Add("StckDisTtlTaxExc");
            if (stockTemp1.ItdedStockDisOutTax != stockTemp2.ItdedStockDisOutTax) resList.Add("ItdedStockDisOutTax");
            if (stockTemp1.ItdedStockDisInTax != stockTemp2.ItdedStockDisInTax) resList.Add("ItdedStockDisInTax");
            if (stockTemp1.ItdedStockDisTaxFre != stockTemp2.ItdedStockDisTaxFre) resList.Add("ItdedStockDisTaxFre");
            if (stockTemp1.StockDisOutTax != stockTemp2.StockDisOutTax) resList.Add("StockDisOutTax");
            if (stockTemp1.StckDisTtlTaxInclu != stockTemp2.StckDisTtlTaxInclu) resList.Add("StckDisTtlTaxInclu");
            if (stockTemp1.TaxAdjust != stockTemp2.TaxAdjust) resList.Add("TaxAdjust");
            if (stockTemp1.BalanceAdjust != stockTemp2.BalanceAdjust) resList.Add("BalanceAdjust");
            if (stockTemp1.SuppCTaxLayCd != stockTemp2.SuppCTaxLayCd) resList.Add("SuppCTaxLayCd");
            if (stockTemp1.SupplierConsTaxRate != stockTemp2.SupplierConsTaxRate) resList.Add("SupplierConsTaxRate");
            if (stockTemp1.AccPayConsTax != stockTemp2.AccPayConsTax) resList.Add("AccPayConsTax");
            if (stockTemp1.StockFractionProcCd != stockTemp2.StockFractionProcCd) resList.Add("StockFractionProcCd");
            if (stockTemp1.AutoPayment != stockTemp2.AutoPayment) resList.Add("AutoPayment");
            if (stockTemp1.AutoPaySlipNum != stockTemp2.AutoPaySlipNum) resList.Add("AutoPaySlipNum");
            if (stockTemp1.RetGoodsReasonDiv != stockTemp2.RetGoodsReasonDiv) resList.Add("RetGoodsReasonDiv");
            if (stockTemp1.RetGoodsReason != stockTemp2.RetGoodsReason) resList.Add("RetGoodsReason");
            if (stockTemp1.PartySaleSlipNum != stockTemp2.PartySaleSlipNum) resList.Add("PartySaleSlipNum");
            if (stockTemp1.SupplierSlipNote1 != stockTemp2.SupplierSlipNote1) resList.Add("SupplierSlipNote1");
            if (stockTemp1.SupplierSlipNote2 != stockTemp2.SupplierSlipNote2) resList.Add("SupplierSlipNote2");
            if (stockTemp1.DetailRowCount != stockTemp2.DetailRowCount) resList.Add("DetailRowCount");
            if (stockTemp1.EdiSendDate != stockTemp2.EdiSendDate) resList.Add("EdiSendDate");
            if (stockTemp1.EdiTakeInDate != stockTemp2.EdiTakeInDate) resList.Add("EdiTakeInDate");
            if (stockTemp1.UoeRemark1 != stockTemp2.UoeRemark1) resList.Add("UoeRemark1");
            if (stockTemp1.UoeRemark2 != stockTemp2.UoeRemark2) resList.Add("UoeRemark2");
            if (stockTemp1.SlipPrintDivCd != stockTemp2.SlipPrintDivCd) resList.Add("SlipPrintDivCd");
            if (stockTemp1.SlipPrintFinishCd != stockTemp2.SlipPrintFinishCd) resList.Add("SlipPrintFinishCd");
            if (stockTemp1.StockSlipPrintDate != stockTemp2.StockSlipPrintDate) resList.Add("StockSlipPrintDate");
            if (stockTemp1.SlipPrtSetPaperId != stockTemp2.SlipPrtSetPaperId) resList.Add("SlipPrtSetPaperId");
            if (stockTemp1.SlipAddressDiv != stockTemp2.SlipAddressDiv) resList.Add("SlipAddressDiv");
            if (stockTemp1.AddresseeCode != stockTemp2.AddresseeCode) resList.Add("AddresseeCode");
            if (stockTemp1.AddresseeName != stockTemp2.AddresseeName) resList.Add("AddresseeName");
            if (stockTemp1.AddresseeName2 != stockTemp2.AddresseeName2) resList.Add("AddresseeName2");
            if (stockTemp1.AddresseePostNo != stockTemp2.AddresseePostNo) resList.Add("AddresseePostNo");
            if (stockTemp1.AddresseeAddr1 != stockTemp2.AddresseeAddr1) resList.Add("AddresseeAddr1");
            if (stockTemp1.AddresseeAddr3 != stockTemp2.AddresseeAddr3) resList.Add("AddresseeAddr3");
            if (stockTemp1.AddresseeAddr4 != stockTemp2.AddresseeAddr4) resList.Add("AddresseeAddr4");
            if (stockTemp1.AddresseeTelNo != stockTemp2.AddresseeTelNo) resList.Add("AddresseeTelNo");
            if (stockTemp1.AddresseeFaxNo != stockTemp2.AddresseeFaxNo) resList.Add("AddresseeFaxNo");
            if (stockTemp1.DirectSendingCd != stockTemp2.DirectSendingCd) resList.Add("DirectSendingCd");
            if (stockTemp1.AcceptAnOrderNo != stockTemp2.AcceptAnOrderNo) resList.Add("AcceptAnOrderNo");
            if (stockTemp1.SupplierFormalDetail != stockTemp2.SupplierFormalDetail) resList.Add("SupplierFormalDetail");
            if (stockTemp1.SupplierSlipNoDetail != stockTemp2.SupplierSlipNoDetail) resList.Add("SupplierSlipNoDetail");
            if (stockTemp1.StockRowNo != stockTemp2.StockRowNo) resList.Add("StockRowNo");
            if (stockTemp1.SectionCodeDetail != stockTemp2.SectionCodeDetail) resList.Add("SectionCodeDetail");
            if (stockTemp1.SubSectionCodeDetail != stockTemp2.SubSectionCodeDetail) resList.Add("SubSectionCodeDetail");
            if (stockTemp1.CommonSeqNo != stockTemp2.CommonSeqNo) resList.Add("CommonSeqNo");
            if (stockTemp1.StockSlipDtlNum != stockTemp2.StockSlipDtlNum) resList.Add("StockSlipDtlNum");
            if (stockTemp1.SupplierFormalSrc != stockTemp2.SupplierFormalSrc) resList.Add("SupplierFormalSrc");
            if (stockTemp1.StockSlipDtlNumSrc != stockTemp2.StockSlipDtlNumSrc) resList.Add("StockSlipDtlNumSrc");
            if (stockTemp1.AcptAnOdrStatusSync != stockTemp2.AcptAnOdrStatusSync) resList.Add("AcptAnOdrStatusSync");
            if (stockTemp1.SalesSlipDtlNumSync != stockTemp2.SalesSlipDtlNumSync) resList.Add("SalesSlipDtlNumSync");
            if (stockTemp1.StockSlipCdDtl != stockTemp2.StockSlipCdDtl) resList.Add("StockSlipCdDtl");
            if (stockTemp1.StockInputCodeDetail != stockTemp2.StockInputCodeDetail) resList.Add("StockInputCodeDetail");
            if (stockTemp1.StockInputNameDetail != stockTemp2.StockInputNameDetail) resList.Add("StockInputNameDetail");
            if (stockTemp1.StockAgentCodeDetail != stockTemp2.StockAgentCodeDetail) resList.Add("StockAgentCodeDetail");
            if (stockTemp1.StockAgentNameDetail != stockTemp2.StockAgentNameDetail) resList.Add("StockAgentNameDetail");
            if (stockTemp1.GoodsKindCode != stockTemp2.GoodsKindCode) resList.Add("GoodsKindCode");
            if (stockTemp1.GoodsMakerCd != stockTemp2.GoodsMakerCd) resList.Add("GoodsMakerCd");
            if (stockTemp1.MakerName != stockTemp2.MakerName) resList.Add("MakerName");
            if (stockTemp1.MakerKanaName != stockTemp2.MakerKanaName) resList.Add("MakerKanaName");
            if (stockTemp1.CmpltMakerKanaName != stockTemp2.CmpltMakerKanaName) resList.Add("CmpltMakerKanaName");
            if (stockTemp1.GoodsNo != stockTemp2.GoodsNo) resList.Add("GoodsNo");
            if (stockTemp1.GoodsName != stockTemp2.GoodsName) resList.Add("GoodsName");
            if (stockTemp1.GoodsNameKana != stockTemp2.GoodsNameKana) resList.Add("GoodsNameKana");
            if (stockTemp1.GoodsLGroup != stockTemp2.GoodsLGroup) resList.Add("GoodsLGroup");
            if (stockTemp1.GoodsLGroupName != stockTemp2.GoodsLGroupName) resList.Add("GoodsLGroupName");
            if (stockTemp1.GoodsMGroup != stockTemp2.GoodsMGroup) resList.Add("GoodsMGroup");
            if (stockTemp1.GoodsMGroupName != stockTemp2.GoodsMGroupName) resList.Add("GoodsMGroupName");
            if (stockTemp1.BLGroupCode != stockTemp2.BLGroupCode) resList.Add("BLGroupCode");
            if (stockTemp1.BLGroupName != stockTemp2.BLGroupName) resList.Add("BLGroupName");
            if (stockTemp1.BLGoodsCode != stockTemp2.BLGoodsCode) resList.Add("BLGoodsCode");
            if (stockTemp1.BLGoodsFullName != stockTemp2.BLGoodsFullName) resList.Add("BLGoodsFullName");
            if (stockTemp1.EnterpriseGanreCode != stockTemp2.EnterpriseGanreCode) resList.Add("EnterpriseGanreCode");
            if (stockTemp1.EnterpriseGanreName != stockTemp2.EnterpriseGanreName) resList.Add("EnterpriseGanreName");
            if (stockTemp1.WarehouseCode != stockTemp2.WarehouseCode) resList.Add("WarehouseCode");
            if (stockTemp1.WarehouseName != stockTemp2.WarehouseName) resList.Add("WarehouseName");
            if (stockTemp1.WarehouseShelfNo != stockTemp2.WarehouseShelfNo) resList.Add("WarehouseShelfNo");
            if (stockTemp1.StockOrderDivCd != stockTemp2.StockOrderDivCd) resList.Add("StockOrderDivCd");
            if (stockTemp1.OpenPriceDiv != stockTemp2.OpenPriceDiv) resList.Add("OpenPriceDiv");
            if (stockTemp1.GoodsRateRank != stockTemp2.GoodsRateRank) resList.Add("GoodsRateRank");
            if (stockTemp1.CustRateGrpCode != stockTemp2.CustRateGrpCode) resList.Add("CustRateGrpCode");
            if (stockTemp1.SuppRateGrpCode != stockTemp2.SuppRateGrpCode) resList.Add("SuppRateGrpCode");
            if (stockTemp1.ListPriceTaxExcFl != stockTemp2.ListPriceTaxExcFl) resList.Add("ListPriceTaxExcFl");
            if (stockTemp1.ListPriceTaxIncFl != stockTemp2.ListPriceTaxIncFl) resList.Add("ListPriceTaxIncFl");
            if (stockTemp1.StockRate != stockTemp2.StockRate) resList.Add("StockRate");
            if (stockTemp1.RateSectStckUnPrc != stockTemp2.RateSectStckUnPrc) resList.Add("RateSectStckUnPrc");
            if (stockTemp1.RateDivStckUnPrc != stockTemp2.RateDivStckUnPrc) resList.Add("RateDivStckUnPrc");
            if (stockTemp1.UnPrcCalcCdStckUnPrc != stockTemp2.UnPrcCalcCdStckUnPrc) resList.Add("UnPrcCalcCdStckUnPrc");
            if (stockTemp1.PriceCdStckUnPrc != stockTemp2.PriceCdStckUnPrc) resList.Add("PriceCdStckUnPrc");
            if (stockTemp1.StdUnPrcStckUnPrc != stockTemp2.StdUnPrcStckUnPrc) resList.Add("StdUnPrcStckUnPrc");
            if (stockTemp1.FracProcUnitStcUnPrc != stockTemp2.FracProcUnitStcUnPrc) resList.Add("FracProcUnitStcUnPrc");
            if (stockTemp1.FracProcStckUnPrc != stockTemp2.FracProcStckUnPrc) resList.Add("FracProcStckUnPrc");
            if (stockTemp1.StockUnitPriceFl != stockTemp2.StockUnitPriceFl) resList.Add("StockUnitPriceFl");
            if (stockTemp1.StockUnitTaxPriceFl != stockTemp2.StockUnitTaxPriceFl) resList.Add("StockUnitTaxPriceFl");
            if (stockTemp1.StockUnitChngDiv != stockTemp2.StockUnitChngDiv) resList.Add("StockUnitChngDiv");
            if (stockTemp1.BfStockUnitPriceFl != stockTemp2.BfStockUnitPriceFl) resList.Add("BfStockUnitPriceFl");
            if (stockTemp1.BfListPrice != stockTemp2.BfListPrice) resList.Add("BfListPrice");
            if (stockTemp1.RateBLGoodsCode != stockTemp2.RateBLGoodsCode) resList.Add("RateBLGoodsCode");
            if (stockTemp1.RateBLGoodsName != stockTemp2.RateBLGoodsName) resList.Add("RateBLGoodsName");
            if (stockTemp1.RateGoodsRateGrpCd != stockTemp2.RateGoodsRateGrpCd) resList.Add("RateGoodsRateGrpCd");
            if (stockTemp1.RateGoodsRateGrpNm != stockTemp2.RateGoodsRateGrpNm) resList.Add("RateGoodsRateGrpNm");
            if (stockTemp1.RateBLGroupCode != stockTemp2.RateBLGroupCode) resList.Add("RateBLGroupCode");
            if (stockTemp1.RateBLGroupName != stockTemp2.RateBLGroupName) resList.Add("RateBLGroupName");
            if (stockTemp1.StockCount != stockTemp2.StockCount) resList.Add("StockCount");
            if (stockTemp1.OrderCnt != stockTemp2.OrderCnt) resList.Add("OrderCnt");
            if (stockTemp1.OrderAdjustCnt != stockTemp2.OrderAdjustCnt) resList.Add("OrderAdjustCnt");
            if (stockTemp1.OrderRemainCnt != stockTemp2.OrderRemainCnt) resList.Add("OrderRemainCnt");
            if (stockTemp1.RemainCntUpdDate != stockTemp2.RemainCntUpdDate) resList.Add("RemainCntUpdDate");
            if (stockTemp1.StockPriceTaxExc != stockTemp2.StockPriceTaxExc) resList.Add("StockPriceTaxExc");
            if (stockTemp1.StockPriceTaxInc != stockTemp2.StockPriceTaxInc) resList.Add("StockPriceTaxInc");
            if (stockTemp1.StockGoodsCdDetail != stockTemp2.StockGoodsCdDetail) resList.Add("StockGoodsCdDetail");
            if (stockTemp1.StockPriceConsTaxDetail != stockTemp2.StockPriceConsTaxDetail) resList.Add("StockPriceConsTaxDetail");
            if (stockTemp1.TaxationCode != stockTemp2.TaxationCode) resList.Add("TaxationCode");
            if (stockTemp1.StockDtiSlipNote1 != stockTemp2.StockDtiSlipNote1) resList.Add("StockDtiSlipNote1");
            if (stockTemp1.SalesCustomerCode != stockTemp2.SalesCustomerCode) resList.Add("SalesCustomerCode");
            if (stockTemp1.SalesCustomerSnm != stockTemp2.SalesCustomerSnm) resList.Add("SalesCustomerSnm");
            if (stockTemp1.SlipMemo1 != stockTemp2.SlipMemo1) resList.Add("SlipMemo1");
            if (stockTemp1.SlipMemo2 != stockTemp2.SlipMemo2) resList.Add("SlipMemo2");
            if (stockTemp1.SlipMemo3 != stockTemp2.SlipMemo3) resList.Add("SlipMemo3");
            if (stockTemp1.InsideMemo1 != stockTemp2.InsideMemo1) resList.Add("InsideMemo1");
            if (stockTemp1.InsideMemo2 != stockTemp2.InsideMemo2) resList.Add("InsideMemo2");
            if (stockTemp1.InsideMemo3 != stockTemp2.InsideMemo3) resList.Add("InsideMemo3");
            if (stockTemp1.SupplierCdDetail != stockTemp2.SupplierCdDetail) resList.Add("SupplierCdDetail");
            if (stockTemp1.SupplierSnmDetail != stockTemp2.SupplierSnmDetail) resList.Add("SupplierSnmDetail");
            if (stockTemp1.AddresseeCodeDetail != stockTemp2.AddresseeCodeDetail) resList.Add("AddresseeCodeDetail");
            if (stockTemp1.AddresseeNameDetail != stockTemp2.AddresseeNameDetail) resList.Add("AddresseeNameDetail");
            if (stockTemp1.DirectSendingCdDetail != stockTemp2.DirectSendingCdDetail) resList.Add("DirectSendingCdDetail");
            if (stockTemp1.OrderNumber != stockTemp2.OrderNumber) resList.Add("OrderNumber");
            if (stockTemp1.WayToOrder != stockTemp2.WayToOrder) resList.Add("WayToOrder");
            if (stockTemp1.DeliGdsCmpltDueDate != stockTemp2.DeliGdsCmpltDueDate) resList.Add("DeliGdsCmpltDueDate");
            if (stockTemp1.ExpectDeliveryDate != stockTemp2.ExpectDeliveryDate) resList.Add("ExpectDeliveryDate");
            if (stockTemp1.OrderDataCreateDiv != stockTemp2.OrderDataCreateDiv) resList.Add("OrderDataCreateDiv");
            if (stockTemp1.OrderDataCreateDate != stockTemp2.OrderDataCreateDate) resList.Add("OrderDataCreateDate");
            if (stockTemp1.OrderFormIssuedDiv != stockTemp2.OrderFormIssuedDiv) resList.Add("OrderFormIssuedDiv");
            if (stockTemp1.TotalDay != stockTemp2.TotalDay) resList.Add("TotalDay");
            if (stockTemp1.NTimeCalcStDate != stockTemp2.NTimeCalcStDate) resList.Add("NTimeCalcStDate");
            if (stockTemp1.PayeeName != stockTemp2.PayeeName) resList.Add("PayeeName");
            if (stockTemp1.PayeeName2 != stockTemp2.PayeeName2) resList.Add("PayeeName2");
            if (stockTemp1.AddUpEnableCnt != stockTemp2.AddUpEnableCnt) resList.Add("AddUpEnableCnt");
            if (stockTemp1.AlreadyAddUpCnt != stockTemp2.AlreadyAddUpCnt) resList.Add("AlreadyAddUpCnt");
            if (stockTemp1.EditStatus != stockTemp2.EditStatus) resList.Add("EditStatus");
            if (stockTemp1.DtlRelationGuid != stockTemp2.DtlRelationGuid) resList.Add("DtlRelationGuid");
            if (stockTemp1.EnterpriseName != stockTemp2.EnterpriseName) resList.Add("EnterpriseName");
            if (stockTemp1.UpdEmployeeName != stockTemp2.UpdEmployeeName) resList.Add("UpdEmployeeName");
            if (stockTemp1.StockSectionNm != stockTemp2.StockSectionNm) resList.Add("StockSectionNm");
            if (stockTemp1.StockAddUpSectionNm != stockTemp2.StockAddUpSectionNm) resList.Add("StockAddUpSectionNm");
            if (stockTemp1.SuppCTaxLayMethodNm != stockTemp2.SuppCTaxLayMethodNm) resList.Add("SuppCTaxLayMethodNm");
            if (stockTemp1.BLGoodsName != stockTemp2.BLGoodsName) resList.Add("BLGoodsName");

            return resList;
        }
    }
}
