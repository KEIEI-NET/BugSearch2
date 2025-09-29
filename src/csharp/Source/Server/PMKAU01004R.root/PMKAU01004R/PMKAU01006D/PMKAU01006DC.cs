using System;
using System.Collections;

using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   EBooksFrePBillDetailWork
    /// <summary>
    ///                      自由帳票(請求書)明細データワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   自由帳票(請求書)明細データワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Genarated Date   :   2022/03/07  (CSharp File Generated Date)</br>
    /// <br></br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class EBooksFrePBillDetailWork
    {
        /// <summary>受注ステータス</summary>
        /// <remarks>10:見積,20:受注,30:売上,40:出荷</remarks>
        private Int32 _sALESSLIPRF_ACPTANODRSTATUSRF;

        /// <summary>売上伝票番号</summary>
        /// <remarks>見積伝票番号,受注伝票番号,出荷伝票番号,売上伝票番号を兼ねる。</remarks>
        private string _sALESSLIPRF_SALESSLIPNUMRF = "";

        /// <summary>拠点コード</summary>
        private string _sALESSLIPRF_SECTIONCODERF = "";

        /// <summary>部門コード</summary>
        private Int32 _sALESSLIPRF_SUBSECTIONCODERF;

        /// <summary>赤伝区分</summary>
        /// <remarks>0:黒伝,1:赤伝,2:元黒</remarks>
        private Int32 _sALESSLIPRF_DEBITNOTEDIVRF;

        /// <summary>売上伝票区分</summary>
        /// <remarks>0:売上,1:返品</remarks>
        private Int32 _sALESSLIPRF_SALESSLIPCDRF;

        /// <summary>売上商品区分</summary>
        /// <remarks>0:商品,1:商品外,2:消費税調整,3:残高調整,4:売掛用消費税調整,5:売掛用残高調整,10:売掛用消費税調整(自動)</remarks>
        private Int32 _sALESSLIPRF_SALESGOODSCDRF;

        /// <summary>売掛区分</summary>
        /// <remarks>0:売掛なし,1:売掛</remarks>
        private Int32 _sALESSLIPRF_ACCRECDIVCDRF;

        /// <summary>請求計上拠点コード</summary>
        /// <remarks>文字型</remarks>
        private string _sALESSLIPRF_DEMANDADDUPSECCDRF = "";

        /// <summary>売上日付</summary>
        /// <remarks>見積日、受注日、売上日を兼ねる。(YYYYMMDD)</remarks>
        private Int32 _sALESSLIPRF_SALESDATERF;

        /// <summary>計上日付</summary>
        /// <remarks>請求日　(YYYYMMDD)</remarks>
        private Int32 _sALESSLIPRF_ADDUPADATERF;

        /// <summary>入力担当者コード</summary>
        /// <remarks>ログイン担当者（ＵＳＢ）</remarks>
        private string _sALESSLIPRF_INPUTAGENCDRF = "";

        /// <summary>入力担当者名称</summary>
        private string _sALESSLIPRF_INPUTAGENNMRF = "";

        /// <summary>売上入力者コード</summary>
        /// <remarks>入力担当者（発行者）</remarks>
        private string _sALESSLIPRF_SALESINPUTCODERF = "";

        /// <summary>売上入力者名称</summary>
        private string _sALESSLIPRF_SALESINPUTNAMERF = "";

        /// <summary>受付従業員コード</summary>
        /// <remarks>受付担当者（受注者）</remarks>
        private string _sALESSLIPRF_FRONTEMPLOYEECDRF = "";

        /// <summary>受付従業員名称</summary>
        private string _sALESSLIPRF_FRONTEMPLOYEENMRF = "";

        /// <summary>販売従業員コード</summary>
        /// <remarks>計上担当者（担当者）</remarks>
        private string _sALESSLIPRF_SALESEMPLOYEECDRF = "";

        /// <summary>販売従業員名称</summary>
        private string _sALESSLIPRF_SALESEMPLOYEENMRF = "";

        /// <summary>売上伝票合計（税込み）</summary>
        /// <remarks>売上正価金額＋売上値引金額計（税抜き）＋売上金額消費税額</remarks>
        private Int64 _sALESSLIPRF_SALESTOTALTAXINCRF;

        /// <summary>売上伝票合計（税抜き）</summary>
        /// <remarks>売上正価金額＋売上値引金額計（税抜き）</remarks>
        private Int64 _sALESSLIPRF_SALESTOTALTAXEXCRF;

        /// <summary>売上部品合計（税込み）</summary>
        /// <remarks>売上部品小計（税込み）＋部品値引対象額合計（税込み）</remarks>
        private Int64 _sALESSLIPRF_SALESPRTTOTALTAXINCRF;

        /// <summary>売上部品合計（税抜き）</summary>
        /// <remarks>売上部品小計（税抜き）＋部品値引対象額合計（税抜き）</remarks>
        private Int64 _sALESSLIPRF_SALESPRTTOTALTAXEXCRF;

        /// <summary>売上作業合計（税込み）</summary>
        /// <remarks>売上作業小計（税込み）＋作業値引対象額合計（税込み）</remarks>
        private Int64 _sALESSLIPRF_SALESWORKTOTALTAXINCRF;

        /// <summary>売上作業合計（税抜き）</summary>
        /// <remarks>売上作業小計（税抜き）＋作業値引対象額合計（税抜き）</remarks>
        private Int64 _sALESSLIPRF_SALESWORKTOTALTAXEXCRF;

        /// <summary>売上小計（税込み）</summary>
        /// <remarks>値引後の明細金額の合計（非課税含まず）</remarks>
        private Int64 _sALESSLIPRF_SALESSUBTOTALTAXINCRF;

        /// <summary>売上小計（税抜き）</summary>
        /// <remarks>値引後の明細金額の合計（非課税含まず）</remarks>
        private Int64 _sALESSLIPRF_SALESSUBTOTALTAXEXCRF;

        /// <summary>売上部品小計（税込み）</summary>
        /// <remarks>部品明細金額の税込合計</remarks>
        private Int64 _sALESSLIPRF_SALESPRTSUBTTLINCRF;

        /// <summary>売上部品小計（税抜き）</summary>
        /// <remarks>部品明細金額の税抜合計</remarks>
        private Int64 _sALESSLIPRF_SALESPRTSUBTTLEXCRF;

        /// <summary>売上作業小計（税込み）</summary>
        /// <remarks>作業明細金額の税込合計</remarks>
        private Int64 _sALESSLIPRF_SALESWORKSUBTTLINCRF;

        /// <summary>売上作業小計（税抜き）</summary>
        /// <remarks>作業明細金額の税抜合計</remarks>
        private Int64 _sALESSLIPRF_SALESWORKSUBTTLEXCRF;

        /// <summary>売上小計（税）</summary>
        /// <remarks>外税対象金額の集計（税抜、値引含まず）</remarks>
        private Int64 _sALESSLIPRF_SALESSUBTOTALTAXRF;

        /// <summary>部品値引対象額合計（税抜き）</summary>
        /// <remarks>部品値引額（税抜き）</remarks>
        private Int64 _sALESSLIPRF_ITDEDPARTSDISOUTTAXRF;

        /// <summary>部品値引対象額合計（税込み）</summary>
        /// <remarks>部品値引額（税込み）</remarks>
        private Int64 _sALESSLIPRF_ITDEDPARTSDISINTAXRF;

        /// <summary>作業値引対象額合計（税抜き）</summary>
        /// <remarks>作業値引額（税抜き）</remarks>
        private Int64 _sALESSLIPRF_ITDEDWORKDISOUTTAXRF;

        /// <summary>作業値引対象額合計（税込み）</summary>
        /// <remarks>作業値引額（税込み）</remarks>
        private Int64 _sALESSLIPRF_ITDEDWORKDISINTAXRF;

        /// <summary>部品値引率</summary>
        /// <remarks>小計に対しての部品値引率</remarks>
        private Double _sALESSLIPRF_PARTSDISCOUNTRATERF;

        /// <summary>工賃値引率</summary>
        /// <remarks>小計に対しての工賃値引率</remarks>
        private Double _sALESSLIPRF_RAVORDISCOUNTRATERF;

        /// <summary>原価金額計</summary>
        private Int64 _sALESSLIPRF_TOTALCOSTRF;

        /// <summary>消費税税率</summary>
        private Double _sALESSLIPRF_CONSTAXRATERF;

        /// <summary>自動入金区分</summary>
        /// <remarks>0:通常入金,1:自動入金</remarks>
        private Int32 _sALESSLIPRF_AUTODEPOSITCDRF;

        /// <summary>自動入金伝票番号</summary>
        /// <remarks>自動入金時の入金伝票番号</remarks>
        private Int32 _sALESSLIPRF_AUTODEPOSITSLIPNORF;

        /// <summary>入金引当合計額</summary>
        /// <remarks>預り金引当合計額を含む</remarks>
        private Int64 _sALESSLIPRF_DEPOSITALLOWANCETTLRF;

        /// <summary>入金引当残高</summary>
        private Int64 _sALESSLIPRF_DEPOSITALWCBLNCERF;

        /// <summary>請求先コード</summary>
        private Int32 _sALESSLIPRF_CLAIMCODERF;

        /// <summary>得意先コード</summary>
        private Int32 _sALESSLIPRF_CUSTOMERCODERF;

        /// <summary>得意先名称</summary>
        private string _sALESSLIPRF_CUSTOMERNAMERF = "";

        /// <summary>得意先名称2</summary>
        private string _sALESSLIPRF_CUSTOMERNAME2RF = "";

        /// <summary>得意先略称</summary>
        private string _sALESSLIPRF_CUSTOMERSNMRF = "";

        /// <summary>敬称</summary>
        private string _sALESSLIPRF_HONORIFICTITLERF = "";

        /// <summary>納品先コード</summary>
        private Int32 _sALESSLIPRF_ADDRESSEECODERF;

        /// <summary>納品先名称</summary>
        private string _sALESSLIPRF_ADDRESSEENAMERF = "";

        /// <summary>納品先名称2</summary>
        private string _sALESSLIPRF_ADDRESSEENAME2RF = "";

        /// <summary>相手先伝票番号</summary>
        /// <remarks>得意先注文番号</remarks>
        private string _sALESSLIPRF_PARTYSALESLIPNUMRF = "";

        /// <summary>伝票備考</summary>
        private string _sALESSLIPRF_SLIPNOTERF = "";

        /// <summary>伝票備考２</summary>
        private string _sALESSLIPRF_SLIPNOTE2RF = "";

        /// <summary>伝票備考３</summary>
        private string _sALESSLIPRF_SLIPNOTE3RF = "";

        /// <summary>返品理由コード</summary>
        private Int32 _sALESSLIPRF_RETGOODSREASONDIVRF;

        /// <summary>返品理由</summary>
        private string _sALESSLIPRF_RETGOODSREASONRF = "";

        /// <summary>明細行数</summary>
        private Int32 _sALESSLIPRF_DETAILROWCOUNTRF;

        /// <summary>ＵＯＥリマーク１</summary>
        /// <remarks>UserOrderEntory</remarks>
        private string _sALESSLIPRF_UOEREMARK1RF = "";

        /// <summary>ＵＯＥリマーク２</summary>
        private string _sALESSLIPRF_UOEREMARK2RF = "";

        /// <summary>納品区分</summary>
        /// <remarks>例) 1:配達,2:店頭渡し,3:直送,…</remarks>
        private Int32 _sALESSLIPRF_DELIVEREDGOODSDIVRF;

        /// <summary>納品区分名称</summary>
        private string _sALESSLIPRF_DELIVEREDGOODSDIVNMRF = "";

        /// <summary>在庫商品合計金額（税抜）</summary>
        /// <remarks>在庫取寄区分が０の明細金額の集計</remarks>
        private Int64 _sALESSLIPRF_STOCKGOODSTTLTAXEXCRF;

        /// <summary>純正商品合計金額（税抜）</summary>
        /// <remarks>商品属性が０の明細金額の集計</remarks>
        private Int64 _sALESSLIPRF_PUREGOODSTTLTAXEXCRF;

        /// <summary>脚注１</summary>
        private string _sALESSLIPRF_FOOTNOTES1RF = "";

        /// <summary>脚注２</summary>
        private string _sALESSLIPRF_FOOTNOTES2RF = "";

        /// <summary>拠点ガイド名称</summary>
        /// <remarks>ＵＩ用（既存のコンボボックス等）</remarks>
        private string _sECDTL_SECTIONGUIDENMRF = "";

        /// <summary>拠点ガイド略称</summary>
        /// <remarks>帳票印字用</remarks>
        private string _sECDTL_SECTIONGUIDESNMRF = "";

        /// <summary>自社名称コード1</summary>
        private Int32 _sECDTL_COMPANYNAMECD1RF;

        /// <summary>売上部門名称</summary>
        private string _sUBSAL_SUBSECTIONNAMERF = "";

        /// <summary>受注番号</summary>
        private Int32 _sALESDETAILRF_ACCEPTANORDERNORF;

        /// <summary>売上行番号</summary>
        private Int32 _sALESDETAILRF_SALESROWNORF;

        /// <summary>納品完了予定日</summary>
        /// <remarks>客先納期(YYYYMMDD)</remarks>
        private Int32 _sALESDETAILRF_DELIGDSCMPLTDUEDATERF;

        /// <summary>商品属性</summary>
        /// <remarks>0:純正 1:優良</remarks>
        private Int32 _sALESDETAILRF_GOODSKINDCODERF;

        /// <summary>商品メーカーコード</summary>
        /// <remarks>ﾊﾟｯｹｰｼﾞ毎にﾕｰｻﾞｰ登録範囲が異なる</remarks>
        private Int32 _sALESDETAILRF_GOODSMAKERCDRF;

        /// <summary>メーカー名称</summary>
        private string _sALESDETAILRF_MAKERNAMERF = "";

        /// <summary>商品番号</summary>
        private string _sALESDETAILRF_GOODSNORF = "";

        /// <summary>商品名称</summary>
        private string _sALESDETAILRF_GOODSNAMERF = "";

        /// <summary>商品名略称</summary>
        private string _sALESDETAILRF_GOODSSHORTNAMERF = "";

        /// <summary>商品大分類コード</summary>
        /// <remarks>旧大分類（ユーザーガイド）</remarks>
        private Int32 _sALESDETAILRF_GOODSLGROUPRF;

        /// <summary>商品大分類名称</summary>
        private string _sALESDETAILRF_GOODSLGROUPNAMERF = "";

        /// <summary>商品中分類コード</summary>
        /// <remarks>旧中分類コード</remarks>
        private Int32 _sALESDETAILRF_GOODSMGROUPRF;

        /// <summary>商品中分類名称</summary>
        private string _sALESDETAILRF_GOODSMGROUPNAMERF = "";

        /// <summary>BLグループコード</summary>
        /// <remarks>旧グループコード</remarks>
        private Int32 _sALESDETAILRF_BLGROUPCODERF;

        /// <summary>BLグループコード名称</summary>
        private string _sALESDETAILRF_BLGROUPNAMERF = "";

        /// <summary>BL商品コード</summary>
        private Int32 _sALESDETAILRF_BLGOODSCODERF;

        /// <summary>BL商品コード名称（全角）</summary>
        private string _sALESDETAILRF_BLGOODSFULLNAMERF = "";

        /// <summary>自社分類コード</summary>
        private Int32 _sALESDETAILRF_ENTERPRISEGANRECODERF;

        /// <summary>自社分類名称</summary>
        private string _sALESDETAILRF_ENTERPRISEGANRENAMERF = "";

        /// <summary>倉庫コード</summary>
        private string _sALESDETAILRF_WAREHOUSECODERF = "";

        /// <summary>倉庫名称</summary>
        private string _sALESDETAILRF_WAREHOUSENAMERF = "";

        /// <summary>倉庫棚番</summary>
        private string _sALESDETAILRF_WAREHOUSESHELFNORF = "";

        /// <summary>売上在庫取寄せ区分</summary>
        /// <remarks>0:取寄せ，1:在庫</remarks>
        private Int32 _sALESDETAILRF_SALESORDERDIVCDRF;

        /// <summary>オープン価格区分</summary>
        /// <remarks>0:通常／1:オープン価格</remarks>
        private Int32 _sALESDETAILRF_OPENPRICEDIVRF;

        /// <summary>商品掛率ランク</summary>
        /// <remarks>商品の掛率用ランク</remarks>
        private string _sALESDETAILRF_GOODSRATERANKRF = "";

        /// <summary>定価率</summary>
        private Double _sALESDETAILRF_LISTPRICERATERF;

        /// <summary>定価（税込，浮動）</summary>
        /// <remarks>税抜き</remarks>
        private Double _sALESDETAILRF_LISTPRICETAXINCFLRF;

        /// <summary>定価（税抜，浮動）</summary>
        /// <remarks>税込み</remarks>
        private Double _sALESDETAILRF_LISTPRICETAXEXCFLRF;

        /// <summary>売価率</summary>
        private Double _sALESDETAILRF_SALESRATERF;

        /// <summary>売上単価（税込，浮動）</summary>
        private Double _sALESDETAILRF_SALESUNPRCTAXINCFLRF;

        /// <summary>売上単価（税抜，浮動）</summary>
        private Double _sALESDETAILRF_SALESUNPRCTAXEXCFLRF;

        /// <summary>原価率</summary>
        private Double _sALESDETAILRF_COSTRATERF;

        /// <summary>原価単価</summary>
        private Double _sALESDETAILRF_SALESUNITCOSTRF;

        /// <summary>BL商品コード（印刷）</summary>
        /// <remarks>掛率算出時に使用したBLコード（商品検索結果）</remarks>
        private Int32 _sALESDETAILRF_PRTBLGOODSCODERF;

        /// <summary>BL商品コード名称（印刷）</summary>
        /// <remarks>掛率算出時に使用したBLコード名称（商品検索結果）</remarks>
        private string _sALESDETAILRF_PRTBLGOODSNAMERF = "";

        /// <summary>作業工数</summary>
        private Double _sALESDETAILRF_WORKMANHOURRF;

        /// <summary>出荷数</summary>
        private Double _sALESDETAILRF_SHIPMENTCNTRF;

        /// <summary>売上金額（税込み）</summary>
        private Int64 _sALESDETAILRF_SALESMONEYTAXINCRF;

        /// <summary>売上金額（税抜き）</summary>
        private Int64 _sALESDETAILRF_SALESMONEYTAXEXCRF;

        /// <summary>原価</summary>
        private Int64 _sALESDETAILRF_COSTRF;

        /// <summary>課税区分</summary>
        /// <remarks>0:課税,1:非課税,2:課税（内税）</remarks>
        private Int32 _sALESDETAILRF_TAXATIONDIVCDRF;

        /// <summary>相手先伝票番号（明細）</summary>
        /// <remarks>得意先注文番号</remarks>
        private string _sALESDETAILRF_PARTYSLIPNUMDTLRF = "";

        /// <summary>明細備考</summary>
        private string _sALESDETAILRF_DTLNOTERF = "";

        /// <summary>仕入先コード</summary>
        private Int32 _sALESDETAILRF_SUPPLIERCDRF;

        /// <summary>仕入先略称</summary>
        private string _sALESDETAILRF_SUPPLIERSNMRF = "";

        /// <summary>伝票メモ１</summary>
        private string _sALESDETAILRF_SLIPMEMO1RF = "";

        /// <summary>伝票メモ２</summary>
        private string _sALESDETAILRF_SLIPMEMO2RF = "";

        /// <summary>伝票メモ３</summary>
        private string _sALESDETAILRF_SLIPMEMO3RF = "";

        /// <summary>社内メモ１</summary>
        private string _sALESDETAILRF_INSIDEMEMO1RF = "";

        /// <summary>社内メモ２</summary>
        private string _sALESDETAILRF_INSIDEMEMO2RF = "";

        /// <summary>社内メモ３</summary>
        private string _sALESDETAILRF_INSIDEMEMO3RF = "";

        /// <summary>変更前定価</summary>
        /// <remarks>税抜き、掛率算出結果</remarks>
        private Double _sALESDETAILRF_BFLISTPRICERF;

        /// <summary>変更前売価</summary>
        /// <remarks>税抜き、掛率算出結果</remarks>
        private Double _sALESDETAILRF_BFSALESUNITPRICERF;

        /// <summary>変更前原価</summary>
        /// <remarks>税抜き、掛率算出結果</remarks>
        private Double _sALESDETAILRF_BFUNITCOSTRF;

        /// <summary>一式明細番号</summary>
        /// <remarks>0:一式なし　1～一式連番</remarks>
        private Int32 _sALESDETAILRF_CMPLTSALESROWNORF;

        /// <summary>メーカーコード（一式）</summary>
        private Int32 _sALESDETAILRF_CMPLTGOODSMAKERCDRF;

        /// <summary>メーカー名称（一式）</summary>
        private string _sALESDETAILRF_CMPLTMAKERNAMERF = "";

        /// <summary>商品名称（一式）</summary>
        private string _sALESDETAILRF_CMPLTGOODSNAMERF = "";

        /// <summary>数量（一式）</summary>
        private Double _sALESDETAILRF_CMPLTSHIPMENTCNTRF;

        /// <summary>売上単価（一式）</summary>
        /// <remarks>売上金額（一式の合計）/ 数量  ※少数第３位四捨五入</remarks>
        private Double _sALESDETAILRF_CMPLTSALESUNPRCFLRF;

        /// <summary>売上金額（一式）</summary>
        /// <remarks>売上金額（税抜き）の同一一式明細の合計</remarks>
        private Int64 _sALESDETAILRF_CMPLTSALESMONEYRF;

        /// <summary>原価単価（一式）</summary>
        /// <remarks>原価金額（一式の合計）/ 数量  ※少数第３位四捨五入</remarks>
        private Double _sALESDETAILRF_CMPLTSALESUNITCOSTRF;

        /// <summary>原価金額（一式）</summary>
        /// <remarks>原価の同一一式明細の合計</remarks>
        private Int64 _sALESDETAILRF_CMPLTCOSTRF;

        /// <summary>相手先伝票番号（一式）</summary>
        /// <remarks>得意先注文番号</remarks>
        private string _sALESDETAILRF_CMPLTPARTYSALSLNUMRF = "";

        /// <summary>一式備考</summary>
        private string _sALESDETAILRF_CMPLTNOTERF = "";

        /// <summary>車両管理番号</summary>
        /// <remarks>自動採番（無重複のシーケンス）PM7での車両SEQ</remarks>
        private Int32 _aCCEPTODRCARRF_CARMNGNORF;

        /// <summary>車輌管理コード</summary>
        /// <remarks>※PM7での車両管理番号</remarks>
        private string _aCCEPTODRCARRF_CARMNGCODERF = "";

        /// <summary>陸運事務所番号</summary>
        private Int32 _aCCEPTODRCARRF_NUMBERPLATE1CODERF;

        /// <summary>陸運事務局名称</summary>
        private string _aCCEPTODRCARRF_NUMBERPLATE1NAMERF = "";

        /// <summary>車両登録番号（種別）</summary>
        private string _aCCEPTODRCARRF_NUMBERPLATE2RF = "";

        /// <summary>車両登録番号（カナ）</summary>
        private string _aCCEPTODRCARRF_NUMBERPLATE3RF = "";

        /// <summary>車両登録番号（プレート番号）</summary>
        private Int32 _aCCEPTODRCARRF_NUMBERPLATE4RF;

        /// <summary>初年度</summary>
        /// <remarks>YYYYMM</remarks>
        private Int32 _aCCEPTODRCARRF_FIRSTENTRYDATERF;

        /// <summary>メーカーコード</summary>
        /// <remarks>1～899:提供分, 900～ユーザー登録</remarks>
        private Int32 _aCCEPTODRCARRF_MAKERCODERF;

        /// <summary>メーカー全角名称</summary>
        /// <remarks>正式名称（カナ漢字混在で全角管理）</remarks>
        private string _aCCEPTODRCARRF_MAKERFULLNAMERF = "";

        /// <summary>車種コード</summary>
        /// <remarks>車名コード(翼) 1～899:提供分, 900～ユーザー登録</remarks>
        private Int32 _aCCEPTODRCARRF_MODELCODERF;

        /// <summary>車種サブコード</summary>
        /// <remarks>0～899:提供分,900～ﾕｰｻﾞｰ登録</remarks>
        private Int32 _aCCEPTODRCARRF_MODELSUBCODERF;

        /// <summary>車種全角名称</summary>
        /// <remarks>正式名称（カナ漢字混在で全角管理）</remarks>
        private string _aCCEPTODRCARRF_MODELFULLNAMERF = "";

        /// <summary>排ガス記号</summary>
        private string _aCCEPTODRCARRF_EXHAUSTGASSIGNRF = "";

        /// <summary>シリーズ型式</summary>
        private string _aCCEPTODRCARRF_SERIESMODELRF = "";

        /// <summary>型式（類別記号）</summary>
        private string _aCCEPTODRCARRF_CATEGORYSIGNMODELRF = "";

        /// <summary>型式（フル型）</summary>
        /// <remarks>フル型式(44桁用)</remarks>
        private string _aCCEPTODRCARRF_FULLMODELRF = "";

        /// <summary>型式指定番号</summary>
        private Int32 _aCCEPTODRCARRF_MODELDESIGNATIONNORF;

        /// <summary>類別番号</summary>
        private Int32 _aCCEPTODRCARRF_CATEGORYNORF;

        /// <summary>車台型式</summary>
        private string _aCCEPTODRCARRF_FRAMEMODELRF = "";

        /// <summary>車台番号</summary>
        /// <remarks>車検証記載フォーマット対応（ HCR32-100251584 等）</remarks>
        private string _aCCEPTODRCARRF_FRAMENORF = "";

        /// <summary>車台番号（検索用）</summary>
        /// <remarks>PM7の車台番号と同意</remarks>
        private Int32 _aCCEPTODRCARRF_SEARCHFRAMENORF;

        /// <summary>エンジン型式名称</summary>
        /// <remarks>エンジン検索</remarks>
        private string _aCCEPTODRCARRF_ENGINEMODELNMRF = "";

        /// <summary>関連型式</summary>
        /// <remarks>リサイクル系で使用</remarks>
        private string _aCCEPTODRCARRF_RELEVANCEMODELRF = "";

        /// <summary>サブ車名コード</summary>
        /// <remarks>リサイクル系で使用</remarks>
        private Int32 _aCCEPTODRCARRF_SUBCARNMCDRF;

        /// <summary>型式グレード略称</summary>
        /// <remarks>リサイクル系で使用</remarks>
        private string _aCCEPTODRCARRF_MODELGRADESNAMERF = "";

        /// <summary>カラーコード</summary>
        /// <remarks>カタログの色コード</remarks>
        private string _aCCEPTODRCARRF_COLORCODERF = "";

        /// <summary>カラー名称1</summary>
        /// <remarks>画面表示用正式名称</remarks>
        private string _aCCEPTODRCARRF_COLORNAME1RF = "";

        /// <summary>トリムコード</summary>
        private string _aCCEPTODRCARRF_TRIMCODERF = "";

        /// <summary>トリム名称</summary>
        private string _aCCEPTODRCARRF_TRIMNAMERF = "";

        /// <summary>車両走行距離</summary>
        private Int32 _aCCEPTODRCARRF_MILEAGERF;

        /// <summary>受注ステータス</summary>
        /// <remarks>10:見積,20:受注,30:売上,40:出荷</remarks>
        private Int32 _dEPSITMAINRF_ACPTANODRSTATUSRF;

        /// <summary>入金伝票番号</summary>
        private Int32 _dEPSITMAINRF_DEPOSITSLIPNORF;

        /// <summary>売上伝票番号</summary>
        private string _dEPSITMAINRF_SALESSLIPNUMRF = "";

        /// <summary>計上拠点コード</summary>
        /// <remarks>集計の対象となっている拠点コード</remarks>
        private string _dEPSITMAINRF_ADDUPSECCODERF = "";

        /// <summary>部門コード</summary>
        private Int32 _dEPSITMAINRF_SUBSECTIONCODERF;

        /// <summary>入金日付</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _dEPSITMAINRF_DEPOSITDATERF;

        /// <summary>計上日付</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _dEPSITMAINRF_ADDUPADATERF;

        /// <summary>入金金額</summary>
        /// <remarks>値引・手数料を除いた額</remarks>
        private Int64 _dEPSITMAINRF_DEPOSITRF;

        /// <summary>手数料入金額</summary>
        private Int64 _dEPSITMAINRF_FEEDEPOSITRF;

        /// <summary>値引入金額</summary>
        private Int64 _dEPSITMAINRF_DISCOUNTDEPOSITRF;

        /// <summary>自動入金区分</summary>
        /// <remarks>0:通常入金,1:自動入金</remarks>
        private Int32 _dEPSITMAINRF_AUTODEPOSITCDRF;

        /// <summary>預り金区分</summary>
        /// <remarks>0:通常入金,1:預り金入金</remarks>
        private Int32 _dEPSITMAINRF_DEPOSITCDRF;

        /// <summary>手形振出日</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _dEPSITMAINRF_DRAFTDRAWINGDATERF;

        /// <summary>手形種類</summary>
        private Int32 _dEPSITMAINRF_DRAFTKINDRF;

        /// <summary>手形種類名称</summary>
        /// <remarks>約束、為替、小切手</remarks>
        private string _dEPSITMAINRF_DRAFTKINDNAMERF = "";

        /// <summary>手形区分名称</summary>
        /// <remarks>自振、廻し</remarks>
        private string _dEPSITMAINRF_DRAFTDIVIDENAMERF = "";

        /// <summary>手形番号</summary>
        private string _dEPSITMAINRF_DRAFTNORF = "";

        /// <summary>得意先コード</summary>
        private Int32 _dEPSITMAINRF_CUSTOMERCODERF;

        /// <summary>請求先コード</summary>
        /// <remarks>請求先得意先</remarks>
        private Int32 _dEPSITMAINRF_CLAIMCODERF;

        /// <summary>伝票摘要</summary>
        private string _dEPSITMAINRF_OUTLINERF = "";

        /// <summary>入金請求部門名称</summary>
        private string _sUBDEP_SUBSECTIONNAMERF = "";

        /// <summary>入金伝票番号</summary>
        private Int32 _dEPSITDTLRF_DEPOSITSLIPNORF;

        /// <summary>入金行番号</summary>
        /// <remarks>※入金設定金種コードの設定番号をセット</remarks>
        private Int32 _dEPSITDTLRF_DEPOSITROWNORF;

        /// <summary>金種コード</summary>
        /// <remarks>1～899:提供分,900～ユーザー登録　※8:値引 9:預かり金</remarks>
        private Int32 _dEPSITDTLRF_MONEYKINDCODERF;

        /// <summary>金種名称</summary>
        private string _dEPSITDTLRF_MONEYKINDNAMERF = "";

        /// <summary>金種区分</summary>
        private Int32 _dEPSITDTLRF_MONEYKINDDIVRF;

        /// <summary>入金金額</summary>
        private Int64 _dEPSITDTLRF_DEPOSITRF;

        /// <summary>有効期限</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _dEPSITDTLRF_VALIDITYTERMRF;

        /// <summary>受注ステータス名称</summary>
        /// <remarks>10:見積,20:受注,30:売上,40:出荷</remarks>
        private Int32 _dADD_ACPTANODRSTATUSRF;

        /// <summary>赤伝区分名称</summary>
        /// <remarks>0:黒伝,1:赤伝,2:元黒</remarks>
        private Int32 _dADD_DEBITNOTEDIVRF;

        /// <summary>売上伝票区分名称</summary>
        /// <remarks>0:売上,1:返品</remarks>
        private Int32 _dADD_SALESSLIPCDRF;

        /// <summary>売上日付</summary>
        /// <remarks>見積日、受注日、売上日を兼ねる。(YYYYMMDD)</remarks>
        private Int32 _dADD_SALESDATERF;

        /// <summary>売上日付西暦年</summary>
        private Int32 _dADD_SALESDATEFYRF;

        /// <summary>売上日付西暦年略</summary>
        private Int32 _dADD_SALESDATEFSRF;

        /// <summary>売上日付和暦年</summary>
        private Int32 _dADD_SALESDATEFWRF;

        /// <summary>売上日付月</summary>
        private Int32 _dADD_SALESDATEFMRF;

        /// <summary>売上日付日</summary>
        private Int32 _dADD_SALESDATEFDRF;

        /// <summary>売上日付元号</summary>
        private string _dADD_SALESDATEFGRF = "";

        /// <summary>売上日付略号</summary>
        private string _dADD_SALESDATEFRRF = "";

        /// <summary>売上日付リテラル(/)</summary>
        private string _dADD_SALESDATEFLSRF = "";

        /// <summary>売上日付リテラル(.)</summary>
        private string _dADD_SALESDATEFLPRF = "";

        /// <summary>売上日付リテラル(年)</summary>
        private string _dADD_SALESDATEFLYRF = "";

        /// <summary>売上日付リテラル(月)</summary>
        private string _dADD_SALESDATEFLMRF = "";

        /// <summary>売上日付リテラル(日)</summary>
        private string _dADD_SALESDATEFLDRF = "";

        /// <summary>取寄商品合計金額（税抜）</summary>
        /// <remarks>在庫取寄区分が０でない明細金額の集計</remarks>
        private Int64 _dADD_STOCKGOODSTTLTAXEXCRF;

        /// <summary>優良商品合計金額（税抜）</summary>
        /// <remarks>商品属性が０でない明細金額の集計</remarks>
        private Int64 _dADD_PUREGOODSTTLTAXEXCRF;

        /// <summary>商品属性名称</summary>
        /// <remarks>0:純正 1:優良</remarks>
        private Int32 _dADD_GOODSKINDCODERF;

        /// <summary>売上在庫取寄せ区分名称</summary>
        /// <remarks>0:取寄せ，1:在庫</remarks>
        private Int32 _dADD_SALESORDERDIVCDRF;

        /// <summary>オープン価格区分名称</summary>
        /// <remarks>0:通常／1:オープン価格</remarks>
        private Int32 _dADD_OPENPRICEDIVRF;

        /// <summary>課税区分名称</summary>
        /// <remarks>0:課税,1:非課税,2:課税（内税）</remarks>
        private Int32 _dADD_TAXATIONDIVCDRF;

        /// <summary>初年度西暦年</summary>
        private Int32 _dADD_FIRSTENTRYDATEFYRF;

        /// <summary>初年度西暦年略</summary>
        private Int32 _dADD_FIRSTENTRYDATEFSRF;

        /// <summary>初年度和暦年</summary>
        private Int32 _dADD_FIRSTENTRYDATEFWRF;

        /// <summary>初年度月</summary>
        private Int32 _dADD_FIRSTENTRYDATEFMRF;

        /// <summary>初年度元号</summary>
        private string _dADD_FIRSTENTRYDATEFGRF = "";

        /// <summary>初年度略号</summary>
        private string _dADD_FIRSTENTRYDATEFRRF = "";

        /// <summary>初年度リテラル(/)</summary>
        private string _dADD_FIRSTENTRYDATEFLSRF = "";

        /// <summary>初年度リテラル(.)</summary>
        private string _dADD_FIRSTENTRYDATEFLPRF = "";

        /// <summary>初年度リテラル(年)</summary>
        private string _dADD_FIRSTENTRYDATEFLYRF = "";

        /// <summary>初年度リテラル(月)</summary>
        private string _dADD_FIRSTENTRYDATEFLMRF = "";

        /// <summary>入金日付西暦年</summary>
        private Int32 _dADD_DEPOSITDATEFYRF;

        /// <summary>入金日付西暦年略</summary>
        private Int32 _dADD_DEPOSITDATEFSRF;

        /// <summary>入金日付和暦年</summary>
        private Int32 _dADD_DEPOSITDATEFWRF;

        /// <summary>入金日付月</summary>
        private Int32 _dADD_DEPOSITDATEFMRF;

        /// <summary>入金日付日</summary>
        private Int32 _dADD_DEPOSITDATEFDRF;

        /// <summary>入金日付元号</summary>
        private string _dADD_DEPOSITDATEFGRF = "";

        /// <summary>入金日付略号</summary>
        private string _dADD_DEPOSITDATEFRRF = "";

        /// <summary>入金日付リテラル(/)</summary>
        private string _dADD_DEPOSITDATEFLSRF = "";

        /// <summary>入金日付リテラル(.)</summary>
        private string _dADD_DEPOSITDATEFLPRF = "";

        /// <summary>入金日付リテラル(年)</summary>
        private string _dADD_DEPOSITDATEFLYRF = "";

        /// <summary>入金日付リテラル(月)</summary>
        private string _dADD_DEPOSITDATEFLMRF = "";

        /// <summary>入金日付リテラル(日)</summary>
        private string _dADD_DEPOSITDATEFLDRF = "";

        /// <summary>自動入金区分名称</summary>
        /// <remarks>0:通常入金,1:自動入金</remarks>
        private Int32 _dADD_AUTODEPOSITCDRF;

        /// <summary>預り金区分名称</summary>
        /// <remarks>0:通常入金,1:預り金入金</remarks>
        private Int32 _dADD_DEPOSITCDRF;

        /// <summary>手形振出日西暦年</summary>
        private Int32 _dADD_DRAFTDRAWINGDATEFYRF;

        /// <summary>手形振出日西暦年略</summary>
        private Int32 _dADD_DRAFTDRAWINGDATEFSRF;

        /// <summary>手形振出日和暦年</summary>
        private Int32 _dADD_DRAFTDRAWINGDATEFWRF;

        /// <summary>手形振出日月</summary>
        private Int32 _dADD_DRAFTDRAWINGDATEFMRF;

        /// <summary>手形振出日日</summary>
        private Int32 _dADD_DRAFTDRAWINGDATEFDRF;

        /// <summary>手形振出日元号</summary>
        private string _dADD_DRAFTDRAWINGDATEFGRF = "";

        /// <summary>手形振出日略号</summary>
        private string _dADD_DRAFTDRAWINGDATEFRRF = "";

        /// <summary>手形振出日リテラル(/)</summary>
        private string _dADD_DRAFTDRAWINGDATEFLSRF = "";

        /// <summary>手形振出日リテラル(.)</summary>
        private string _dADD_DRAFTDRAWINGDATEFLPRF = "";

        /// <summary>手形振出日リテラル(年)</summary>
        private string _dADD_DRAFTDRAWINGDATEFLYRF = "";

        /// <summary>手形振出日リテラル(月)</summary>
        private string _dADD_DRAFTDRAWINGDATEFLMRF = "";

        /// <summary>手形振出日リテラル(日)</summary>
        private string _dADD_DRAFTDRAWINGDATEFLDRF = "";

        /// <summary>手形支払期日西暦年</summary>
        /// <remarks>有効期限と同じ内容をセットする</remarks>
        private Int32 _dADD_DRAFTPAYTIMELIMITFYRF;

        /// <summary>手形支払期日西暦年略</summary>
        /// <remarks>有効期限と同じ内容をセットする</remarks>
        private Int32 _dADD_DRAFTPAYTIMELIMITFSRF;

        /// <summary>手形支払期日和暦年</summary>
        /// <remarks>有効期限と同じ内容をセットする</remarks>
        private Int32 _dADD_DRAFTPAYTIMELIMITFWRF;

        /// <summary>手形支払期日月</summary>
        /// <remarks>有効期限と同じ内容をセットする</remarks>
        private Int32 _dADD_DRAFTPAYTIMELIMITFMRF;

        /// <summary>手形支払期日日</summary>
        /// <remarks>有効期限と同じ内容をセットする</remarks>
        private Int32 _dADD_DRAFTPAYTIMELIMITFDRF;

        /// <summary>手形支払期日元号</summary>
        /// <remarks>有効期限と同じ内容をセットする</remarks>
        private string _dADD_DRAFTPAYTIMELIMITFGRF = "";

        /// <summary>手形支払期日略号</summary>
        /// <remarks>有効期限と同じ内容をセットする</remarks>
        private string _dADD_DRAFTPAYTIMELIMITFRRF = "";

        /// <summary>手形支払期日リテラル(/)</summary>
        /// <remarks>有効期限と同じ内容をセットする</remarks>
        private string _dADD_DRAFTPAYTIMELIMITFLSRF = "";

        /// <summary>手形支払期日リテラル(.)</summary>
        /// <remarks>有効期限と同じ内容をセットする</remarks>
        private string _dADD_DRAFTPAYTIMELIMITFLPRF = "";

        /// <summary>手形支払期日リテラル(年)</summary>
        /// <remarks>有効期限と同じ内容をセットする</remarks>
        private string _dADD_DRAFTPAYTIMELIMITFLYRF = "";

        /// <summary>手形支払期日リテラル(月)</summary>
        /// <remarks>有効期限と同じ内容をセットする</remarks>
        private string _dADD_DRAFTPAYTIMELIMITFLMRF = "";

        /// <summary>手形支払期日リテラル(日)</summary>
        /// <remarks>有効期限と同じ内容をセットする</remarks>
        private string _dADD_DRAFTPAYTIMELIMITFLDRF = "";

        /// <summary>有効期限西暦年</summary>
        private Int32 _dADD_VALIDITYTERMFYRF;

        /// <summary>有効期限西暦年略</summary>
        private Int32 _dADD_VALIDITYTERMFSRF;

        /// <summary>有効期限和暦年</summary>
        private Int32 _dADD_VALIDITYTERMFWRF;

        /// <summary>有効期限月</summary>
        private Int32 _dADD_VALIDITYTERMFMRF;

        /// <summary>有効期限日</summary>
        private Int32 _dADD_VALIDITYTERMFDRF;

        /// <summary>有効期限元号</summary>
        private string _dADD_VALIDITYTERMFGRF = "";

        /// <summary>有効期限略号</summary>
        private string _dADD_VALIDITYTERMFRRF = "";

        /// <summary>有効期限リテラル(/)</summary>
        private string _dADD_VALIDITYTERMFLSRF = "";

        /// <summary>有効期限リテラル(.)</summary>
        private string _dADD_VALIDITYTERMFLPRF = "";

        /// <summary>有効期限リテラル(年)</summary>
        private string _dADD_VALIDITYTERMFLYRF = "";

        /// <summary>有効期限リテラル(月)</summary>
        private string _dADD_VALIDITYTERMFLMRF = "";

        /// <summary>有効期限リテラル(日)</summary>
        private string _dADD_VALIDITYTERMFLDRF = "";

        /// <summary>請求明細摘要</summary>
        /// <remarks>DmdDtlOutlineCodeRF = 0:印字しない 1:品番 2:定価</remarks>
        private string _dADD_DMDDTLOUTLINERF = "";

        /// <summary>売上伝票計タイトル</summary>
        /// <remarks>明細請求書の売上伝票計用</remarks>
        private string _dADD_SALESFTTITLERF = "";

        /// <summary>売上伝票計金額</summary>
        /// <remarks>明細請求書の売上伝票計用</remarks>
        private Int64 _dADD_SALESFTPRICERF;

        /// <summary>売上伝票計備考１</summary>
        /// <remarks>明細請求書の売上伝票計用</remarks>
        private string _dADD_SALESFTNOTE1RF = "";

        /// <summary>売上伝票計備考２</summary>
        /// <remarks>明細請求書の売上伝票計用</remarks>
        private string _dADD_SALESFTNOTE2RF = "";

        /// <summary>売上伝票計備考３</summary>
        /// <remarks>明細請求書の売上伝票計用</remarks>
        private string _dADD_SALESFTNOTE3RF = "";

        /// <summary>明細伝票タイトル(売上/返品)</summary>
        private string _dSAL_DETAILTITLE = "";

        /// <summary>売上集計タイトル</summary>
        private string _dSAL_DETAILSUMTITLE = "";

        /// <summary>売上集計金額</summary>
        private Int64 _dSAL_DETAILSUMPRICE;

        /// <summary>明細伝票タイトル(入金)</summary>
        private string _dDEP_DETAILTITLE = "";

        /// <summary>入金集計タイトル</summary>
        private string _dDEP_DETAILSUMTITLE = "";

        /// <summary>入金集計金額</summary>
        private Int64 _dDEP_DETAILSUMPRICE;

        /// <summary>売上伝票区分（明細）</summary>
        /// <remarks>0:売上,1:返品,2:値引,3:注釈,4:小計</remarks>
        private Int32 _sALESDETAILRF_SALESSLIPCDDTLRF;

        /// <summary>実績計上拠点コード</summary>
        /// <remarks>実績計上を行う企業内の拠点コード</remarks>
        private string _sALESSLIPRF_RESULTSADDUPSECCDRF = "";

        /// <summary>入金入力拠点コード</summary>
        /// <remarks>入金入力した拠点コード</remarks>
        private string _dEPSITMAINRF_INPUTDEPOSITSECCDRF = "";

        /// <summary>商品名称カナ</summary>
        private string _sALESDETAILRF_GOODSNAMEKANARF = "";

        /// <summary>メーカーカナ名称</summary>
        private string _sALESDETAILRF_MAKERKANANAMERF = "";

        /// <summary>車種半角名称</summary>
        private string _aCCEPTODRCARRF_MODELHALFNAMERF = "";

        /// <summary>印刷用品番</summary>
        private string _sALESDETAILRF_PRTGOODSNORF = "";

        /// <summary>印刷用メーカーコード</summary>
        private Int32 _sALESDETAILRF_PRTMAKERCODERF;

        /// <summary>印刷用メーカー名称</summary>
        private string _sALESDETAILRF_PRTMAKERNAMERF = "";

        /// <summary>相手先伝票番号（ヘッダ用）</summary>
        /// <remarks>得意先注文番号</remarks>
        private string _dADD_PARTYSALESLIPNUMRF = "";
        /// <summary>消費税転嫁方式</summary>
        /// <remarks>0:伝票単位1:明細単位2:請求親 3:請求子 9:非課税</remarks>
        private Int32 _sALESSLIPRF_CONSTAXLAYMETHODRF;


        /// public propaty name  :  SALESSLIPRF_ACPTANODRSTATUSRF
        /// <summary>受注ステータスプロパティ</summary>
        /// <value>10:見積,20:受注,30:売上,40:出荷</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   受注ステータスプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SALESSLIPRF_ACPTANODRSTATUSRF
        {
            get { return _sALESSLIPRF_ACPTANODRSTATUSRF; }
            set { _sALESSLIPRF_ACPTANODRSTATUSRF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_SALESSLIPNUMRF
        /// <summary>売上伝票番号プロパティ</summary>
        /// <value>見積伝票番号,受注伝票番号,出荷伝票番号,売上伝票番号を兼ねる。</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上伝票番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SALESSLIPRF_SALESSLIPNUMRF
        {
            get { return _sALESSLIPRF_SALESSLIPNUMRF; }
            set { _sALESSLIPRF_SALESSLIPNUMRF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_SECTIONCODERF
        /// <summary>拠点コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SALESSLIPRF_SECTIONCODERF
        {
            get { return _sALESSLIPRF_SECTIONCODERF; }
            set { _sALESSLIPRF_SECTIONCODERF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_SUBSECTIONCODERF
        /// <summary>部門コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   部門コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SALESSLIPRF_SUBSECTIONCODERF
        {
            get { return _sALESSLIPRF_SUBSECTIONCODERF; }
            set { _sALESSLIPRF_SUBSECTIONCODERF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_DEBITNOTEDIVRF
        /// <summary>赤伝区分プロパティ</summary>
        /// <value>0:黒伝,1:赤伝,2:元黒</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   赤伝区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SALESSLIPRF_DEBITNOTEDIVRF
        {
            get { return _sALESSLIPRF_DEBITNOTEDIVRF; }
            set { _sALESSLIPRF_DEBITNOTEDIVRF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_SALESSLIPCDRF
        /// <summary>売上伝票区分プロパティ</summary>
        /// <value>0:売上,1:返品</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上伝票区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SALESSLIPRF_SALESSLIPCDRF
        {
            get { return _sALESSLIPRF_SALESSLIPCDRF; }
            set { _sALESSLIPRF_SALESSLIPCDRF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_SALESGOODSCDRF
        /// <summary>売上商品区分プロパティ</summary>
        /// <value>0:商品,1:商品外,2:消費税調整,3:残高調整,4:売掛用消費税調整,5:売掛用残高調整,10:売掛用消費税調整(自動)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上商品区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SALESSLIPRF_SALESGOODSCDRF
        {
            get { return _sALESSLIPRF_SALESGOODSCDRF; }
            set { _sALESSLIPRF_SALESGOODSCDRF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_ACCRECDIVCDRF
        /// <summary>売掛区分プロパティ</summary>
        /// <value>0:売掛なし,1:売掛</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売掛区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SALESSLIPRF_ACCRECDIVCDRF
        {
            get { return _sALESSLIPRF_ACCRECDIVCDRF; }
            set { _sALESSLIPRF_ACCRECDIVCDRF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_DEMANDADDUPSECCDRF
        /// <summary>請求計上拠点コードプロパティ</summary>
        /// <value>文字型</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   請求計上拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SALESSLIPRF_DEMANDADDUPSECCDRF
        {
            get { return _sALESSLIPRF_DEMANDADDUPSECCDRF; }
            set { _sALESSLIPRF_DEMANDADDUPSECCDRF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_SALESDATERF
        /// <summary>売上日付プロパティ</summary>
        /// <value>見積日、受注日、売上日を兼ねる。(YYYYMMDD)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上日付プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SALESSLIPRF_SALESDATERF
        {
            get { return _sALESSLIPRF_SALESDATERF; }
            set { _sALESSLIPRF_SALESDATERF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_ADDUPADATERF
        /// <summary>計上日付プロパティ</summary>
        /// <value>請求日　(YYYYMMDD)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   計上日付プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SALESSLIPRF_ADDUPADATERF
        {
            get { return _sALESSLIPRF_ADDUPADATERF; }
            set { _sALESSLIPRF_ADDUPADATERF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_INPUTAGENCDRF
        /// <summary>入力担当者コードプロパティ</summary>
        /// <value>ログイン担当者（ＵＳＢ）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入力担当者コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SALESSLIPRF_INPUTAGENCDRF
        {
            get { return _sALESSLIPRF_INPUTAGENCDRF; }
            set { _sALESSLIPRF_INPUTAGENCDRF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_INPUTAGENNMRF
        /// <summary>入力担当者名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入力担当者名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SALESSLIPRF_INPUTAGENNMRF
        {
            get { return _sALESSLIPRF_INPUTAGENNMRF; }
            set { _sALESSLIPRF_INPUTAGENNMRF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_SALESINPUTCODERF
        /// <summary>売上入力者コードプロパティ</summary>
        /// <value>入力担当者（発行者）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上入力者コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SALESSLIPRF_SALESINPUTCODERF
        {
            get { return _sALESSLIPRF_SALESINPUTCODERF; }
            set { _sALESSLIPRF_SALESINPUTCODERF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_SALESINPUTNAMERF
        /// <summary>売上入力者名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上入力者名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SALESSLIPRF_SALESINPUTNAMERF
        {
            get { return _sALESSLIPRF_SALESINPUTNAMERF; }
            set { _sALESSLIPRF_SALESINPUTNAMERF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_FRONTEMPLOYEECDRF
        /// <summary>受付従業員コードプロパティ</summary>
        /// <value>受付担当者（受注者）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   受付従業員コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SALESSLIPRF_FRONTEMPLOYEECDRF
        {
            get { return _sALESSLIPRF_FRONTEMPLOYEECDRF; }
            set { _sALESSLIPRF_FRONTEMPLOYEECDRF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_FRONTEMPLOYEENMRF
        /// <summary>受付従業員名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   受付従業員名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SALESSLIPRF_FRONTEMPLOYEENMRF
        {
            get { return _sALESSLIPRF_FRONTEMPLOYEENMRF; }
            set { _sALESSLIPRF_FRONTEMPLOYEENMRF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_SALESEMPLOYEECDRF
        /// <summary>販売従業員コードプロパティ</summary>
        /// <value>計上担当者（担当者）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   販売従業員コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SALESSLIPRF_SALESEMPLOYEECDRF
        {
            get { return _sALESSLIPRF_SALESEMPLOYEECDRF; }
            set { _sALESSLIPRF_SALESEMPLOYEECDRF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_SALESEMPLOYEENMRF
        /// <summary>販売従業員名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   販売従業員名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SALESSLIPRF_SALESEMPLOYEENMRF
        {
            get { return _sALESSLIPRF_SALESEMPLOYEENMRF; }
            set { _sALESSLIPRF_SALESEMPLOYEENMRF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_SALESTOTALTAXINCRF
        /// <summary>売上伝票合計（税込み）プロパティ</summary>
        /// <value>売上正価金額＋売上値引金額計（税抜き）＋売上金額消費税額</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上伝票合計（税込み）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SALESSLIPRF_SALESTOTALTAXINCRF
        {
            get { return _sALESSLIPRF_SALESTOTALTAXINCRF; }
            set { _sALESSLIPRF_SALESTOTALTAXINCRF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_SALESTOTALTAXEXCRF
        /// <summary>売上伝票合計（税抜き）プロパティ</summary>
        /// <value>売上正価金額＋売上値引金額計（税抜き）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上伝票合計（税抜き）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SALESSLIPRF_SALESTOTALTAXEXCRF
        {
            get { return _sALESSLIPRF_SALESTOTALTAXEXCRF; }
            set { _sALESSLIPRF_SALESTOTALTAXEXCRF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_SALESPRTTOTALTAXINCRF
        /// <summary>売上部品合計（税込み）プロパティ</summary>
        /// <value>売上部品小計（税込み）＋部品値引対象額合計（税込み）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上部品合計（税込み）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SALESSLIPRF_SALESPRTTOTALTAXINCRF
        {
            get { return _sALESSLIPRF_SALESPRTTOTALTAXINCRF; }
            set { _sALESSLIPRF_SALESPRTTOTALTAXINCRF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_SALESPRTTOTALTAXEXCRF
        /// <summary>売上部品合計（税抜き）プロパティ</summary>
        /// <value>売上部品小計（税抜き）＋部品値引対象額合計（税抜き）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上部品合計（税抜き）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SALESSLIPRF_SALESPRTTOTALTAXEXCRF
        {
            get { return _sALESSLIPRF_SALESPRTTOTALTAXEXCRF; }
            set { _sALESSLIPRF_SALESPRTTOTALTAXEXCRF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_SALESWORKTOTALTAXINCRF
        /// <summary>売上作業合計（税込み）プロパティ</summary>
        /// <value>売上作業小計（税込み）＋作業値引対象額合計（税込み）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上作業合計（税込み）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SALESSLIPRF_SALESWORKTOTALTAXINCRF
        {
            get { return _sALESSLIPRF_SALESWORKTOTALTAXINCRF; }
            set { _sALESSLIPRF_SALESWORKTOTALTAXINCRF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_SALESWORKTOTALTAXEXCRF
        /// <summary>売上作業合計（税抜き）プロパティ</summary>
        /// <value>売上作業小計（税抜き）＋作業値引対象額合計（税抜き）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上作業合計（税抜き）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SALESSLIPRF_SALESWORKTOTALTAXEXCRF
        {
            get { return _sALESSLIPRF_SALESWORKTOTALTAXEXCRF; }
            set { _sALESSLIPRF_SALESWORKTOTALTAXEXCRF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_SALESSUBTOTALTAXINCRF
        /// <summary>売上小計（税込み）プロパティ</summary>
        /// <value>値引後の明細金額の合計（非課税含まず）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上小計（税込み）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SALESSLIPRF_SALESSUBTOTALTAXINCRF
        {
            get { return _sALESSLIPRF_SALESSUBTOTALTAXINCRF; }
            set { _sALESSLIPRF_SALESSUBTOTALTAXINCRF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_SALESSUBTOTALTAXEXCRF
        /// <summary>売上小計（税抜き）プロパティ</summary>
        /// <value>値引後の明細金額の合計（非課税含まず）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上小計（税抜き）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SALESSLIPRF_SALESSUBTOTALTAXEXCRF
        {
            get { return _sALESSLIPRF_SALESSUBTOTALTAXEXCRF; }
            set { _sALESSLIPRF_SALESSUBTOTALTAXEXCRF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_SALESPRTSUBTTLINCRF
        /// <summary>売上部品小計（税込み）プロパティ</summary>
        /// <value>部品明細金額の税込合計</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上部品小計（税込み）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SALESSLIPRF_SALESPRTSUBTTLINCRF
        {
            get { return _sALESSLIPRF_SALESPRTSUBTTLINCRF; }
            set { _sALESSLIPRF_SALESPRTSUBTTLINCRF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_SALESPRTSUBTTLEXCRF
        /// <summary>売上部品小計（税抜き）プロパティ</summary>
        /// <value>部品明細金額の税抜合計</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上部品小計（税抜き）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SALESSLIPRF_SALESPRTSUBTTLEXCRF
        {
            get { return _sALESSLIPRF_SALESPRTSUBTTLEXCRF; }
            set { _sALESSLIPRF_SALESPRTSUBTTLEXCRF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_SALESWORKSUBTTLINCRF
        /// <summary>売上作業小計（税込み）プロパティ</summary>
        /// <value>作業明細金額の税込合計</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上作業小計（税込み）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SALESSLIPRF_SALESWORKSUBTTLINCRF
        {
            get { return _sALESSLIPRF_SALESWORKSUBTTLINCRF; }
            set { _sALESSLIPRF_SALESWORKSUBTTLINCRF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_SALESWORKSUBTTLEXCRF
        /// <summary>売上作業小計（税抜き）プロパティ</summary>
        /// <value>作業明細金額の税抜合計</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上作業小計（税抜き）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SALESSLIPRF_SALESWORKSUBTTLEXCRF
        {
            get { return _sALESSLIPRF_SALESWORKSUBTTLEXCRF; }
            set { _sALESSLIPRF_SALESWORKSUBTTLEXCRF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_SALESSUBTOTALTAXRF
        /// <summary>売上小計（税）プロパティ</summary>
        /// <value>外税対象金額の集計（税抜、値引含まず）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上小計（税）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SALESSLIPRF_SALESSUBTOTALTAXRF
        {
            get { return _sALESSLIPRF_SALESSUBTOTALTAXRF; }
            set { _sALESSLIPRF_SALESSUBTOTALTAXRF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_ITDEDPARTSDISOUTTAXRF
        /// <summary>部品値引対象額合計（税抜き）プロパティ</summary>
        /// <value>部品値引額（税抜き）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   部品値引対象額合計（税抜き）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SALESSLIPRF_ITDEDPARTSDISOUTTAXRF
        {
            get { return _sALESSLIPRF_ITDEDPARTSDISOUTTAXRF; }
            set { _sALESSLIPRF_ITDEDPARTSDISOUTTAXRF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_ITDEDPARTSDISINTAXRF
        /// <summary>部品値引対象額合計（税込み）プロパティ</summary>
        /// <value>部品値引額（税込み）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   部品値引対象額合計（税込み）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SALESSLIPRF_ITDEDPARTSDISINTAXRF
        {
            get { return _sALESSLIPRF_ITDEDPARTSDISINTAXRF; }
            set { _sALESSLIPRF_ITDEDPARTSDISINTAXRF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_ITDEDWORKDISOUTTAXRF
        /// <summary>作業値引対象額合計（税抜き）プロパティ</summary>
        /// <value>作業値引額（税抜き）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   作業値引対象額合計（税抜き）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SALESSLIPRF_ITDEDWORKDISOUTTAXRF
        {
            get { return _sALESSLIPRF_ITDEDWORKDISOUTTAXRF; }
            set { _sALESSLIPRF_ITDEDWORKDISOUTTAXRF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_ITDEDWORKDISINTAXRF
        /// <summary>作業値引対象額合計（税込み）プロパティ</summary>
        /// <value>作業値引額（税込み）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   作業値引対象額合計（税込み）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SALESSLIPRF_ITDEDWORKDISINTAXRF
        {
            get { return _sALESSLIPRF_ITDEDWORKDISINTAXRF; }
            set { _sALESSLIPRF_ITDEDWORKDISINTAXRF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_PARTSDISCOUNTRATERF
        /// <summary>部品値引率プロパティ</summary>
        /// <value>小計に対しての部品値引率</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   部品値引率プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double SALESSLIPRF_PARTSDISCOUNTRATERF
        {
            get { return _sALESSLIPRF_PARTSDISCOUNTRATERF; }
            set { _sALESSLIPRF_PARTSDISCOUNTRATERF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_RAVORDISCOUNTRATERF
        /// <summary>工賃値引率プロパティ</summary>
        /// <value>小計に対しての工賃値引率</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   工賃値引率プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double SALESSLIPRF_RAVORDISCOUNTRATERF
        {
            get { return _sALESSLIPRF_RAVORDISCOUNTRATERF; }
            set { _sALESSLIPRF_RAVORDISCOUNTRATERF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_TOTALCOSTRF
        /// <summary>原価金額計プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   原価金額計プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SALESSLIPRF_TOTALCOSTRF
        {
            get { return _sALESSLIPRF_TOTALCOSTRF; }
            set { _sALESSLIPRF_TOTALCOSTRF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_CONSTAXRATERF
        /// <summary>消費税税率プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   消費税税率プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double SALESSLIPRF_CONSTAXRATERF
        {
            get { return _sALESSLIPRF_CONSTAXRATERF; }
            set { _sALESSLIPRF_CONSTAXRATERF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_AUTODEPOSITCDRF
        /// <summary>自動入金区分プロパティ</summary>
        /// <value>0:通常入金,1:自動入金</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自動入金区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SALESSLIPRF_AUTODEPOSITCDRF
        {
            get { return _sALESSLIPRF_AUTODEPOSITCDRF; }
            set { _sALESSLIPRF_AUTODEPOSITCDRF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_AUTODEPOSITSLIPNORF
        /// <summary>自動入金伝票番号プロパティ</summary>
        /// <value>自動入金時の入金伝票番号</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自動入金伝票番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SALESSLIPRF_AUTODEPOSITSLIPNORF
        {
            get { return _sALESSLIPRF_AUTODEPOSITSLIPNORF; }
            set { _sALESSLIPRF_AUTODEPOSITSLIPNORF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_DEPOSITALLOWANCETTLRF
        /// <summary>入金引当合計額プロパティ</summary>
        /// <value>預り金引当合計額を含む</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金引当合計額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SALESSLIPRF_DEPOSITALLOWANCETTLRF
        {
            get { return _sALESSLIPRF_DEPOSITALLOWANCETTLRF; }
            set { _sALESSLIPRF_DEPOSITALLOWANCETTLRF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_DEPOSITALWCBLNCERF
        /// <summary>入金引当残高プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金引当残高プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SALESSLIPRF_DEPOSITALWCBLNCERF
        {
            get { return _sALESSLIPRF_DEPOSITALWCBLNCERF; }
            set { _sALESSLIPRF_DEPOSITALWCBLNCERF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_CLAIMCODERF
        /// <summary>請求先コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   請求先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SALESSLIPRF_CLAIMCODERF
        {
            get { return _sALESSLIPRF_CLAIMCODERF; }
            set { _sALESSLIPRF_CLAIMCODERF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_CUSTOMERCODERF
        /// <summary>得意先コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SALESSLIPRF_CUSTOMERCODERF
        {
            get { return _sALESSLIPRF_CUSTOMERCODERF; }
            set { _sALESSLIPRF_CUSTOMERCODERF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_CUSTOMERNAMERF
        /// <summary>得意先名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SALESSLIPRF_CUSTOMERNAMERF
        {
            get { return _sALESSLIPRF_CUSTOMERNAMERF; }
            set { _sALESSLIPRF_CUSTOMERNAMERF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_CUSTOMERNAME2RF
        /// <summary>得意先名称2プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先名称2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SALESSLIPRF_CUSTOMERNAME2RF
        {
            get { return _sALESSLIPRF_CUSTOMERNAME2RF; }
            set { _sALESSLIPRF_CUSTOMERNAME2RF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_CUSTOMERSNMRF
        /// <summary>得意先略称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先略称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SALESSLIPRF_CUSTOMERSNMRF
        {
            get { return _sALESSLIPRF_CUSTOMERSNMRF; }
            set { _sALESSLIPRF_CUSTOMERSNMRF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_HONORIFICTITLERF
        /// <summary>敬称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   敬称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SALESSLIPRF_HONORIFICTITLERF
        {
            get { return _sALESSLIPRF_HONORIFICTITLERF; }
            set { _sALESSLIPRF_HONORIFICTITLERF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_ADDRESSEECODERF
        /// <summary>納品先コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   納品先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SALESSLIPRF_ADDRESSEECODERF
        {
            get { return _sALESSLIPRF_ADDRESSEECODERF; }
            set { _sALESSLIPRF_ADDRESSEECODERF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_ADDRESSEENAMERF
        /// <summary>納品先名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   納品先名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SALESSLIPRF_ADDRESSEENAMERF
        {
            get { return _sALESSLIPRF_ADDRESSEENAMERF; }
            set { _sALESSLIPRF_ADDRESSEENAMERF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_ADDRESSEENAME2RF
        /// <summary>納品先名称2プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   納品先名称2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SALESSLIPRF_ADDRESSEENAME2RF
        {
            get { return _sALESSLIPRF_ADDRESSEENAME2RF; }
            set { _sALESSLIPRF_ADDRESSEENAME2RF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_PARTYSALESLIPNUMRF
        /// <summary>相手先伝票番号プロパティ</summary>
        /// <value>得意先注文番号</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   相手先伝票番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SALESSLIPRF_PARTYSALESLIPNUMRF
        {
            get { return _sALESSLIPRF_PARTYSALESLIPNUMRF; }
            set { _sALESSLIPRF_PARTYSALESLIPNUMRF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_SLIPNOTERF
        /// <summary>伝票備考プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票備考プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SALESSLIPRF_SLIPNOTERF
        {
            get { return _sALESSLIPRF_SLIPNOTERF; }
            set { _sALESSLIPRF_SLIPNOTERF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_SLIPNOTE2RF
        /// <summary>伝票備考２プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票備考２プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SALESSLIPRF_SLIPNOTE2RF
        {
            get { return _sALESSLIPRF_SLIPNOTE2RF; }
            set { _sALESSLIPRF_SLIPNOTE2RF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_SLIPNOTE3RF
        /// <summary>伝票備考３プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票備考３プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SALESSLIPRF_SLIPNOTE3RF
        {
            get { return _sALESSLIPRF_SLIPNOTE3RF; }
            set { _sALESSLIPRF_SLIPNOTE3RF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_RETGOODSREASONDIVRF
        /// <summary>返品理由コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   返品理由コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SALESSLIPRF_RETGOODSREASONDIVRF
        {
            get { return _sALESSLIPRF_RETGOODSREASONDIVRF; }
            set { _sALESSLIPRF_RETGOODSREASONDIVRF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_RETGOODSREASONRF
        /// <summary>返品理由プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   返品理由プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SALESSLIPRF_RETGOODSREASONRF
        {
            get { return _sALESSLIPRF_RETGOODSREASONRF; }
            set { _sALESSLIPRF_RETGOODSREASONRF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_DETAILROWCOUNTRF
        /// <summary>明細行数プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   明細行数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SALESSLIPRF_DETAILROWCOUNTRF
        {
            get { return _sALESSLIPRF_DETAILROWCOUNTRF; }
            set { _sALESSLIPRF_DETAILROWCOUNTRF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_UOEREMARK1RF
        /// <summary>ＵＯＥリマーク１プロパティ</summary>
        /// <value>UserOrderEntory</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ＵＯＥリマーク１プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SALESSLIPRF_UOEREMARK1RF
        {
            get { return _sALESSLIPRF_UOEREMARK1RF; }
            set { _sALESSLIPRF_UOEREMARK1RF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_UOEREMARK2RF
        /// <summary>ＵＯＥリマーク２プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ＵＯＥリマーク２プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SALESSLIPRF_UOEREMARK2RF
        {
            get { return _sALESSLIPRF_UOEREMARK2RF; }
            set { _sALESSLIPRF_UOEREMARK2RF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_DELIVEREDGOODSDIVRF
        /// <summary>納品区分プロパティ</summary>
        /// <value>例) 1:配達,2:店頭渡し,3:直送,…</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   納品区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SALESSLIPRF_DELIVEREDGOODSDIVRF
        {
            get { return _sALESSLIPRF_DELIVEREDGOODSDIVRF; }
            set { _sALESSLIPRF_DELIVEREDGOODSDIVRF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_DELIVEREDGOODSDIVNMRF
        /// <summary>納品区分名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   納品区分名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SALESSLIPRF_DELIVEREDGOODSDIVNMRF
        {
            get { return _sALESSLIPRF_DELIVEREDGOODSDIVNMRF; }
            set { _sALESSLIPRF_DELIVEREDGOODSDIVNMRF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_STOCKGOODSTTLTAXEXCRF
        /// <summary>在庫商品合計金額（税抜）プロパティ</summary>
        /// <value>在庫取寄区分が０の明細金額の集計</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   在庫商品合計金額（税抜）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SALESSLIPRF_STOCKGOODSTTLTAXEXCRF
        {
            get { return _sALESSLIPRF_STOCKGOODSTTLTAXEXCRF; }
            set { _sALESSLIPRF_STOCKGOODSTTLTAXEXCRF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_PUREGOODSTTLTAXEXCRF
        /// <summary>純正商品合計金額（税抜）プロパティ</summary>
        /// <value>商品属性が０の明細金額の集計</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   純正商品合計金額（税抜）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SALESSLIPRF_PUREGOODSTTLTAXEXCRF
        {
            get { return _sALESSLIPRF_PUREGOODSTTLTAXEXCRF; }
            set { _sALESSLIPRF_PUREGOODSTTLTAXEXCRF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_FOOTNOTES1RF
        /// <summary>脚注１プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   脚注１プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SALESSLIPRF_FOOTNOTES1RF
        {
            get { return _sALESSLIPRF_FOOTNOTES1RF; }
            set { _sALESSLIPRF_FOOTNOTES1RF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_FOOTNOTES2RF
        /// <summary>脚注２プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   脚注２プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SALESSLIPRF_FOOTNOTES2RF
        {
            get { return _sALESSLIPRF_FOOTNOTES2RF; }
            set { _sALESSLIPRF_FOOTNOTES2RF = value; }
        }

        /// public propaty name  :  SECDTL_SECTIONGUIDENMRF
        /// <summary>拠点ガイド名称プロパティ</summary>
        /// <value>ＵＩ用（既存のコンボボックス等）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点ガイド名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SECDTL_SECTIONGUIDENMRF
        {
            get { return _sECDTL_SECTIONGUIDENMRF; }
            set { _sECDTL_SECTIONGUIDENMRF = value; }
        }

        /// public propaty name  :  SECDTL_SECTIONGUIDESNMRF
        /// <summary>拠点ガイド略称プロパティ</summary>
        /// <value>帳票印字用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点ガイド略称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SECDTL_SECTIONGUIDESNMRF
        {
            get { return _sECDTL_SECTIONGUIDESNMRF; }
            set { _sECDTL_SECTIONGUIDESNMRF = value; }
        }

        /// public propaty name  :  SECDTL_COMPANYNAMECD1RF
        /// <summary>自社名称コード1プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社名称コード1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SECDTL_COMPANYNAMECD1RF
        {
            get { return _sECDTL_COMPANYNAMECD1RF; }
            set { _sECDTL_COMPANYNAMECD1RF = value; }
        }

        /// public propaty name  :  SUBSAL_SUBSECTIONNAMERF
        /// <summary>売上部門名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上部門名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SUBSAL_SUBSECTIONNAMERF
        {
            get { return _sUBSAL_SUBSECTIONNAMERF; }
            set { _sUBSAL_SUBSECTIONNAMERF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_ACCEPTANORDERNORF
        /// <summary>受注番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   受注番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SALESDETAILRF_ACCEPTANORDERNORF
        {
            get { return _sALESDETAILRF_ACCEPTANORDERNORF; }
            set { _sALESDETAILRF_ACCEPTANORDERNORF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_SALESROWNORF
        /// <summary>売上行番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上行番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SALESDETAILRF_SALESROWNORF
        {
            get { return _sALESDETAILRF_SALESROWNORF; }
            set { _sALESDETAILRF_SALESROWNORF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_DELIGDSCMPLTDUEDATERF
        /// <summary>納品完了予定日プロパティ</summary>
        /// <value>客先納期(YYYYMMDD)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   納品完了予定日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SALESDETAILRF_DELIGDSCMPLTDUEDATERF
        {
            get { return _sALESDETAILRF_DELIGDSCMPLTDUEDATERF; }
            set { _sALESDETAILRF_DELIGDSCMPLTDUEDATERF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_GOODSKINDCODERF
        /// <summary>商品属性プロパティ</summary>
        /// <value>0:純正 1:優良</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品属性プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SALESDETAILRF_GOODSKINDCODERF
        {
            get { return _sALESDETAILRF_GOODSKINDCODERF; }
            set { _sALESDETAILRF_GOODSKINDCODERF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_GOODSMAKERCDRF
        /// <summary>商品メーカーコードプロパティ</summary>
        /// <value>ﾊﾟｯｹｰｼﾞ毎にﾕｰｻﾞｰ登録範囲が異なる</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品メーカーコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SALESDETAILRF_GOODSMAKERCDRF
        {
            get { return _sALESDETAILRF_GOODSMAKERCDRF; }
            set { _sALESDETAILRF_GOODSMAKERCDRF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_MAKERNAMERF
        /// <summary>メーカー名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メーカー名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SALESDETAILRF_MAKERNAMERF
        {
            get { return _sALESDETAILRF_MAKERNAMERF; }
            set { _sALESDETAILRF_MAKERNAMERF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_GOODSNORF
        /// <summary>商品番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SALESDETAILRF_GOODSNORF
        {
            get { return _sALESDETAILRF_GOODSNORF; }
            set { _sALESDETAILRF_GOODSNORF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_GOODSNAMERF
        /// <summary>商品名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SALESDETAILRF_GOODSNAMERF
        {
            get { return _sALESDETAILRF_GOODSNAMERF; }
            set { _sALESDETAILRF_GOODSNAMERF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_GOODSSHORTNAMERF
        /// <summary>商品名略称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品名略称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SALESDETAILRF_GOODSSHORTNAMERF
        {
            get { return _sALESDETAILRF_GOODSSHORTNAMERF; }
            set { _sALESDETAILRF_GOODSSHORTNAMERF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_GOODSLGROUPRF
        /// <summary>商品大分類コードプロパティ</summary>
        /// <value>旧大分類（ユーザーガイド）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品大分類コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SALESDETAILRF_GOODSLGROUPRF
        {
            get { return _sALESDETAILRF_GOODSLGROUPRF; }
            set { _sALESDETAILRF_GOODSLGROUPRF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_GOODSLGROUPNAMERF
        /// <summary>商品大分類名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品大分類名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SALESDETAILRF_GOODSLGROUPNAMERF
        {
            get { return _sALESDETAILRF_GOODSLGROUPNAMERF; }
            set { _sALESDETAILRF_GOODSLGROUPNAMERF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_GOODSMGROUPRF
        /// <summary>商品中分類コードプロパティ</summary>
        /// <value>旧中分類コード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品中分類コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SALESDETAILRF_GOODSMGROUPRF
        {
            get { return _sALESDETAILRF_GOODSMGROUPRF; }
            set { _sALESDETAILRF_GOODSMGROUPRF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_GOODSMGROUPNAMERF
        /// <summary>商品中分類名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品中分類名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SALESDETAILRF_GOODSMGROUPNAMERF
        {
            get { return _sALESDETAILRF_GOODSMGROUPNAMERF; }
            set { _sALESDETAILRF_GOODSMGROUPNAMERF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_BLGROUPCODERF
        /// <summary>BLグループコードプロパティ</summary>
        /// <value>旧グループコード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BLグループコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SALESDETAILRF_BLGROUPCODERF
        {
            get { return _sALESDETAILRF_BLGROUPCODERF; }
            set { _sALESDETAILRF_BLGROUPCODERF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_BLGROUPNAMERF
        /// <summary>BLグループコード名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BLグループコード名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SALESDETAILRF_BLGROUPNAMERF
        {
            get { return _sALESDETAILRF_BLGROUPNAMERF; }
            set { _sALESDETAILRF_BLGROUPNAMERF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_BLGOODSCODERF
        /// <summary>BL商品コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL商品コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SALESDETAILRF_BLGOODSCODERF
        {
            get { return _sALESDETAILRF_BLGOODSCODERF; }
            set { _sALESDETAILRF_BLGOODSCODERF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_BLGOODSFULLNAMERF
        /// <summary>BL商品コード名称（全角）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL商品コード名称（全角）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SALESDETAILRF_BLGOODSFULLNAMERF
        {
            get { return _sALESDETAILRF_BLGOODSFULLNAMERF; }
            set { _sALESDETAILRF_BLGOODSFULLNAMERF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_ENTERPRISEGANRECODERF
        /// <summary>自社分類コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社分類コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SALESDETAILRF_ENTERPRISEGANRECODERF
        {
            get { return _sALESDETAILRF_ENTERPRISEGANRECODERF; }
            set { _sALESDETAILRF_ENTERPRISEGANRECODERF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_ENTERPRISEGANRENAMERF
        /// <summary>自社分類名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社分類名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SALESDETAILRF_ENTERPRISEGANRENAMERF
        {
            get { return _sALESDETAILRF_ENTERPRISEGANRENAMERF; }
            set { _sALESDETAILRF_ENTERPRISEGANRENAMERF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_WAREHOUSECODERF
        /// <summary>倉庫コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   倉庫コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SALESDETAILRF_WAREHOUSECODERF
        {
            get { return _sALESDETAILRF_WAREHOUSECODERF; }
            set { _sALESDETAILRF_WAREHOUSECODERF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_WAREHOUSENAMERF
        /// <summary>倉庫名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   倉庫名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SALESDETAILRF_WAREHOUSENAMERF
        {
            get { return _sALESDETAILRF_WAREHOUSENAMERF; }
            set { _sALESDETAILRF_WAREHOUSENAMERF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_WAREHOUSESHELFNORF
        /// <summary>倉庫棚番プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   倉庫棚番プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SALESDETAILRF_WAREHOUSESHELFNORF
        {
            get { return _sALESDETAILRF_WAREHOUSESHELFNORF; }
            set { _sALESDETAILRF_WAREHOUSESHELFNORF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_SALESORDERDIVCDRF
        /// <summary>売上在庫取寄せ区分プロパティ</summary>
        /// <value>0:取寄せ，1:在庫</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上在庫取寄せ区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SALESDETAILRF_SALESORDERDIVCDRF
        {
            get { return _sALESDETAILRF_SALESORDERDIVCDRF; }
            set { _sALESDETAILRF_SALESORDERDIVCDRF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_OPENPRICEDIVRF
        /// <summary>オープン価格区分プロパティ</summary>
        /// <value>0:通常／1:オープン価格</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   オープン価格区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SALESDETAILRF_OPENPRICEDIVRF
        {
            get { return _sALESDETAILRF_OPENPRICEDIVRF; }
            set { _sALESDETAILRF_OPENPRICEDIVRF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_GOODSRATERANKRF
        /// <summary>商品掛率ランクプロパティ</summary>
        /// <value>商品の掛率用ランク</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品掛率ランクプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SALESDETAILRF_GOODSRATERANKRF
        {
            get { return _sALESDETAILRF_GOODSRATERANKRF; }
            set { _sALESDETAILRF_GOODSRATERANKRF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_LISTPRICERATERF
        /// <summary>定価率プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   定価率プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double SALESDETAILRF_LISTPRICERATERF
        {
            get { return _sALESDETAILRF_LISTPRICERATERF; }
            set { _sALESDETAILRF_LISTPRICERATERF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_LISTPRICETAXINCFLRF
        /// <summary>定価（税込，浮動）プロパティ</summary>
        /// <value>税抜き</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   定価（税込，浮動）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double SALESDETAILRF_LISTPRICETAXINCFLRF
        {
            get { return _sALESDETAILRF_LISTPRICETAXINCFLRF; }
            set { _sALESDETAILRF_LISTPRICETAXINCFLRF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_LISTPRICETAXEXCFLRF
        /// <summary>定価（税抜，浮動）プロパティ</summary>
        /// <value>税込み</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   定価（税抜，浮動）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double SALESDETAILRF_LISTPRICETAXEXCFLRF
        {
            get { return _sALESDETAILRF_LISTPRICETAXEXCFLRF; }
            set { _sALESDETAILRF_LISTPRICETAXEXCFLRF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_SALESRATERF
        /// <summary>売価率プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売価率プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double SALESDETAILRF_SALESRATERF
        {
            get { return _sALESDETAILRF_SALESRATERF; }
            set { _sALESDETAILRF_SALESRATERF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_SALESUNPRCTAXINCFLRF
        /// <summary>売上単価（税込，浮動）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上単価（税込，浮動）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double SALESDETAILRF_SALESUNPRCTAXINCFLRF
        {
            get { return _sALESDETAILRF_SALESUNPRCTAXINCFLRF; }
            set { _sALESDETAILRF_SALESUNPRCTAXINCFLRF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_SALESUNPRCTAXEXCFLRF
        /// <summary>売上単価（税抜，浮動）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上単価（税抜，浮動）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double SALESDETAILRF_SALESUNPRCTAXEXCFLRF
        {
            get { return _sALESDETAILRF_SALESUNPRCTAXEXCFLRF; }
            set { _sALESDETAILRF_SALESUNPRCTAXEXCFLRF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_COSTRATERF
        /// <summary>原価率プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   原価率プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double SALESDETAILRF_COSTRATERF
        {
            get { return _sALESDETAILRF_COSTRATERF; }
            set { _sALESDETAILRF_COSTRATERF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_SALESUNITCOSTRF
        /// <summary>原価単価プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   原価単価プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double SALESDETAILRF_SALESUNITCOSTRF
        {
            get { return _sALESDETAILRF_SALESUNITCOSTRF; }
            set { _sALESDETAILRF_SALESUNITCOSTRF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_PRTBLGOODSCODERF
        /// <summary>BL商品コード（印刷）プロパティ</summary>
        /// <value>掛率算出時に使用したBLコード（商品検索結果）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL商品コード（印刷）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SALESDETAILRF_PRTBLGOODSCODERF
        {
            get { return _sALESDETAILRF_PRTBLGOODSCODERF; }
            set { _sALESDETAILRF_PRTBLGOODSCODERF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_PRTBLGOODSNAMERF
        /// <summary>BL商品コード名称（印刷）プロパティ</summary>
        /// <value>掛率算出時に使用したBLコード名称（商品検索結果）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL商品コード名称（印刷）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SALESDETAILRF_PRTBLGOODSNAMERF
        {
            get { return _sALESDETAILRF_PRTBLGOODSNAMERF; }
            set { _sALESDETAILRF_PRTBLGOODSNAMERF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_WORKMANHOURRF
        /// <summary>作業工数プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   作業工数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double SALESDETAILRF_WORKMANHOURRF
        {
            get { return _sALESDETAILRF_WORKMANHOURRF; }
            set { _sALESDETAILRF_WORKMANHOURRF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_SHIPMENTCNTRF
        /// <summary>出荷数プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   出荷数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double SALESDETAILRF_SHIPMENTCNTRF
        {
            get { return _sALESDETAILRF_SHIPMENTCNTRF; }
            set { _sALESDETAILRF_SHIPMENTCNTRF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_SALESMONEYTAXINCRF
        /// <summary>売上金額（税込み）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上金額（税込み）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SALESDETAILRF_SALESMONEYTAXINCRF
        {
            get { return _sALESDETAILRF_SALESMONEYTAXINCRF; }
            set { _sALESDETAILRF_SALESMONEYTAXINCRF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_SALESMONEYTAXEXCRF
        /// <summary>売上金額（税抜き）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上金額（税抜き）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SALESDETAILRF_SALESMONEYTAXEXCRF
        {
            get { return _sALESDETAILRF_SALESMONEYTAXEXCRF; }
            set { _sALESDETAILRF_SALESMONEYTAXEXCRF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_COSTRF
        /// <summary>原価プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   原価プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SALESDETAILRF_COSTRF
        {
            get { return _sALESDETAILRF_COSTRF; }
            set { _sALESDETAILRF_COSTRF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_TAXATIONDIVCDRF
        /// <summary>課税区分プロパティ</summary>
        /// <value>0:課税,1:非課税,2:課税（内税）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   課税区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SALESDETAILRF_TAXATIONDIVCDRF
        {
            get { return _sALESDETAILRF_TAXATIONDIVCDRF; }
            set { _sALESDETAILRF_TAXATIONDIVCDRF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_PARTYSLIPNUMDTLRF
        /// <summary>相手先伝票番号（明細）プロパティ</summary>
        /// <value>得意先注文番号</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   相手先伝票番号（明細）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SALESDETAILRF_PARTYSLIPNUMDTLRF
        {
            get { return _sALESDETAILRF_PARTYSLIPNUMDTLRF; }
            set { _sALESDETAILRF_PARTYSLIPNUMDTLRF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_DTLNOTERF
        /// <summary>明細備考プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   明細備考プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SALESDETAILRF_DTLNOTERF
        {
            get { return _sALESDETAILRF_DTLNOTERF; }
            set { _sALESDETAILRF_DTLNOTERF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_SUPPLIERCDRF
        /// <summary>仕入先コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SALESDETAILRF_SUPPLIERCDRF
        {
            get { return _sALESDETAILRF_SUPPLIERCDRF; }
            set { _sALESDETAILRF_SUPPLIERCDRF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_SUPPLIERSNMRF
        /// <summary>仕入先略称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先略称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SALESDETAILRF_SUPPLIERSNMRF
        {
            get { return _sALESDETAILRF_SUPPLIERSNMRF; }
            set { _sALESDETAILRF_SUPPLIERSNMRF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_SLIPMEMO1RF
        /// <summary>伝票メモ１プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票メモ１プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SALESDETAILRF_SLIPMEMO1RF
        {
            get { return _sALESDETAILRF_SLIPMEMO1RF; }
            set { _sALESDETAILRF_SLIPMEMO1RF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_SLIPMEMO2RF
        /// <summary>伝票メモ２プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票メモ２プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SALESDETAILRF_SLIPMEMO2RF
        {
            get { return _sALESDETAILRF_SLIPMEMO2RF; }
            set { _sALESDETAILRF_SLIPMEMO2RF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_SLIPMEMO3RF
        /// <summary>伝票メモ３プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票メモ３プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SALESDETAILRF_SLIPMEMO3RF
        {
            get { return _sALESDETAILRF_SLIPMEMO3RF; }
            set { _sALESDETAILRF_SLIPMEMO3RF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_INSIDEMEMO1RF
        /// <summary>社内メモ１プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   社内メモ１プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SALESDETAILRF_INSIDEMEMO1RF
        {
            get { return _sALESDETAILRF_INSIDEMEMO1RF; }
            set { _sALESDETAILRF_INSIDEMEMO1RF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_INSIDEMEMO2RF
        /// <summary>社内メモ２プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   社内メモ２プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SALESDETAILRF_INSIDEMEMO2RF
        {
            get { return _sALESDETAILRF_INSIDEMEMO2RF; }
            set { _sALESDETAILRF_INSIDEMEMO2RF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_INSIDEMEMO3RF
        /// <summary>社内メモ３プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   社内メモ３プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SALESDETAILRF_INSIDEMEMO3RF
        {
            get { return _sALESDETAILRF_INSIDEMEMO3RF; }
            set { _sALESDETAILRF_INSIDEMEMO3RF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_BFLISTPRICERF
        /// <summary>変更前定価プロパティ</summary>
        /// <value>税抜き、掛率算出結果</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   変更前定価プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double SALESDETAILRF_BFLISTPRICERF
        {
            get { return _sALESDETAILRF_BFLISTPRICERF; }
            set { _sALESDETAILRF_BFLISTPRICERF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_BFSALESUNITPRICERF
        /// <summary>変更前売価プロパティ</summary>
        /// <value>税抜き、掛率算出結果</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   変更前売価プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double SALESDETAILRF_BFSALESUNITPRICERF
        {
            get { return _sALESDETAILRF_BFSALESUNITPRICERF; }
            set { _sALESDETAILRF_BFSALESUNITPRICERF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_BFUNITCOSTRF
        /// <summary>変更前原価プロパティ</summary>
        /// <value>税抜き、掛率算出結果</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   変更前原価プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double SALESDETAILRF_BFUNITCOSTRF
        {
            get { return _sALESDETAILRF_BFUNITCOSTRF; }
            set { _sALESDETAILRF_BFUNITCOSTRF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_CMPLTSALESROWNORF
        /// <summary>一式明細番号プロパティ</summary>
        /// <value>0:一式なし　1～一式連番</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   一式明細番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SALESDETAILRF_CMPLTSALESROWNORF
        {
            get { return _sALESDETAILRF_CMPLTSALESROWNORF; }
            set { _sALESDETAILRF_CMPLTSALESROWNORF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_CMPLTGOODSMAKERCDRF
        /// <summary>メーカーコード（一式）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メーカーコード（一式）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SALESDETAILRF_CMPLTGOODSMAKERCDRF
        {
            get { return _sALESDETAILRF_CMPLTGOODSMAKERCDRF; }
            set { _sALESDETAILRF_CMPLTGOODSMAKERCDRF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_CMPLTMAKERNAMERF
        /// <summary>メーカー名称（一式）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メーカー名称（一式）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SALESDETAILRF_CMPLTMAKERNAMERF
        {
            get { return _sALESDETAILRF_CMPLTMAKERNAMERF; }
            set { _sALESDETAILRF_CMPLTMAKERNAMERF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_CMPLTGOODSNAMERF
        /// <summary>商品名称（一式）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品名称（一式）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SALESDETAILRF_CMPLTGOODSNAMERF
        {
            get { return _sALESDETAILRF_CMPLTGOODSNAMERF; }
            set { _sALESDETAILRF_CMPLTGOODSNAMERF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_CMPLTSHIPMENTCNTRF
        /// <summary>数量（一式）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   数量（一式）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double SALESDETAILRF_CMPLTSHIPMENTCNTRF
        {
            get { return _sALESDETAILRF_CMPLTSHIPMENTCNTRF; }
            set { _sALESDETAILRF_CMPLTSHIPMENTCNTRF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_CMPLTSALESUNPRCFLRF
        /// <summary>売上単価（一式）プロパティ</summary>
        /// <value>売上金額（一式の合計）/ 数量  ※少数第３位四捨五入</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上単価（一式）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double SALESDETAILRF_CMPLTSALESUNPRCFLRF
        {
            get { return _sALESDETAILRF_CMPLTSALESUNPRCFLRF; }
            set { _sALESDETAILRF_CMPLTSALESUNPRCFLRF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_CMPLTSALESMONEYRF
        /// <summary>売上金額（一式）プロパティ</summary>
        /// <value>売上金額（税抜き）の同一一式明細の合計</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上金額（一式）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SALESDETAILRF_CMPLTSALESMONEYRF
        {
            get { return _sALESDETAILRF_CMPLTSALESMONEYRF; }
            set { _sALESDETAILRF_CMPLTSALESMONEYRF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_CMPLTSALESUNITCOSTRF
        /// <summary>原価単価（一式）プロパティ</summary>
        /// <value>原価金額（一式の合計）/ 数量  ※少数第３位四捨五入</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   原価単価（一式）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double SALESDETAILRF_CMPLTSALESUNITCOSTRF
        {
            get { return _sALESDETAILRF_CMPLTSALESUNITCOSTRF; }
            set { _sALESDETAILRF_CMPLTSALESUNITCOSTRF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_CMPLTCOSTRF
        /// <summary>原価金額（一式）プロパティ</summary>
        /// <value>原価の同一一式明細の合計</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   原価金額（一式）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SALESDETAILRF_CMPLTCOSTRF
        {
            get { return _sALESDETAILRF_CMPLTCOSTRF; }
            set { _sALESDETAILRF_CMPLTCOSTRF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_CMPLTPARTYSALSLNUMRF
        /// <summary>相手先伝票番号（一式）プロパティ</summary>
        /// <value>得意先注文番号</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   相手先伝票番号（一式）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SALESDETAILRF_CMPLTPARTYSALSLNUMRF
        {
            get { return _sALESDETAILRF_CMPLTPARTYSALSLNUMRF; }
            set { _sALESDETAILRF_CMPLTPARTYSALSLNUMRF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_CMPLTNOTERF
        /// <summary>一式備考プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   一式備考プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SALESDETAILRF_CMPLTNOTERF
        {
            get { return _sALESDETAILRF_CMPLTNOTERF; }
            set { _sALESDETAILRF_CMPLTNOTERF = value; }
        }

        /// public propaty name  :  ACCEPTODRCARRF_CARMNGNORF
        /// <summary>車両管理番号プロパティ</summary>
        /// <value>自動採番（無重複のシーケンス）PM7での車両SEQ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車両管理番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ACCEPTODRCARRF_CARMNGNORF
        {
            get { return _aCCEPTODRCARRF_CARMNGNORF; }
            set { _aCCEPTODRCARRF_CARMNGNORF = value; }
        }

        /// public propaty name  :  ACCEPTODRCARRF_CARMNGCODERF
        /// <summary>車輌管理コードプロパティ</summary>
        /// <value>※PM7での車両管理番号</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車輌管理コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ACCEPTODRCARRF_CARMNGCODERF
        {
            get { return _aCCEPTODRCARRF_CARMNGCODERF; }
            set { _aCCEPTODRCARRF_CARMNGCODERF = value; }
        }

        /// public propaty name  :  ACCEPTODRCARRF_NUMBERPLATE1CODERF
        /// <summary>陸運事務所番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   陸運事務所番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ACCEPTODRCARRF_NUMBERPLATE1CODERF
        {
            get { return _aCCEPTODRCARRF_NUMBERPLATE1CODERF; }
            set { _aCCEPTODRCARRF_NUMBERPLATE1CODERF = value; }
        }

        /// public propaty name  :  ACCEPTODRCARRF_NUMBERPLATE1NAMERF
        /// <summary>陸運事務局名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   陸運事務局名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ACCEPTODRCARRF_NUMBERPLATE1NAMERF
        {
            get { return _aCCEPTODRCARRF_NUMBERPLATE1NAMERF; }
            set { _aCCEPTODRCARRF_NUMBERPLATE1NAMERF = value; }
        }

        /// public propaty name  :  ACCEPTODRCARRF_NUMBERPLATE2RF
        /// <summary>車両登録番号（種別）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車両登録番号（種別）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ACCEPTODRCARRF_NUMBERPLATE2RF
        {
            get { return _aCCEPTODRCARRF_NUMBERPLATE2RF; }
            set { _aCCEPTODRCARRF_NUMBERPLATE2RF = value; }
        }

        /// public propaty name  :  ACCEPTODRCARRF_NUMBERPLATE3RF
        /// <summary>車両登録番号（カナ）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車両登録番号（カナ）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ACCEPTODRCARRF_NUMBERPLATE3RF
        {
            get { return _aCCEPTODRCARRF_NUMBERPLATE3RF; }
            set { _aCCEPTODRCARRF_NUMBERPLATE3RF = value; }
        }

        /// public propaty name  :  ACCEPTODRCARRF_NUMBERPLATE4RF
        /// <summary>車両登録番号（プレート番号）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車両登録番号（プレート番号）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ACCEPTODRCARRF_NUMBERPLATE4RF
        {
            get { return _aCCEPTODRCARRF_NUMBERPLATE4RF; }
            set { _aCCEPTODRCARRF_NUMBERPLATE4RF = value; }
        }

        /// public propaty name  :  ACCEPTODRCARRF_FIRSTENTRYDATERF
        /// <summary>初年度プロパティ</summary>
        /// <value>YYYYMM</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   初年度プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ACCEPTODRCARRF_FIRSTENTRYDATERF
        {
            get { return _aCCEPTODRCARRF_FIRSTENTRYDATERF; }
            set { _aCCEPTODRCARRF_FIRSTENTRYDATERF = value; }
        }

        /// public propaty name  :  ACCEPTODRCARRF_MAKERCODERF
        /// <summary>メーカーコードプロパティ</summary>
        /// <value>1～899:提供分, 900～ユーザー登録</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メーカーコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ACCEPTODRCARRF_MAKERCODERF
        {
            get { return _aCCEPTODRCARRF_MAKERCODERF; }
            set { _aCCEPTODRCARRF_MAKERCODERF = value; }
        }

        /// public propaty name  :  ACCEPTODRCARRF_MAKERFULLNAMERF
        /// <summary>メーカー全角名称プロパティ</summary>
        /// <value>正式名称（カナ漢字混在で全角管理）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メーカー全角名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ACCEPTODRCARRF_MAKERFULLNAMERF
        {
            get { return _aCCEPTODRCARRF_MAKERFULLNAMERF; }
            set { _aCCEPTODRCARRF_MAKERFULLNAMERF = value; }
        }

        /// public propaty name  :  ACCEPTODRCARRF_MODELCODERF
        /// <summary>車種コードプロパティ</summary>
        /// <value>車名コード(翼) 1～899:提供分, 900～ユーザー登録</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車種コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ACCEPTODRCARRF_MODELCODERF
        {
            get { return _aCCEPTODRCARRF_MODELCODERF; }
            set { _aCCEPTODRCARRF_MODELCODERF = value; }
        }

        /// public propaty name  :  ACCEPTODRCARRF_MODELSUBCODERF
        /// <summary>車種サブコードプロパティ</summary>
        /// <value>0～899:提供分,900～ﾕｰｻﾞｰ登録</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車種サブコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ACCEPTODRCARRF_MODELSUBCODERF
        {
            get { return _aCCEPTODRCARRF_MODELSUBCODERF; }
            set { _aCCEPTODRCARRF_MODELSUBCODERF = value; }
        }

        /// public propaty name  :  ACCEPTODRCARRF_MODELFULLNAMERF
        /// <summary>車種全角名称プロパティ</summary>
        /// <value>正式名称（カナ漢字混在で全角管理）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車種全角名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ACCEPTODRCARRF_MODELFULLNAMERF
        {
            get { return _aCCEPTODRCARRF_MODELFULLNAMERF; }
            set { _aCCEPTODRCARRF_MODELFULLNAMERF = value; }
        }

        /// public propaty name  :  ACCEPTODRCARRF_EXHAUSTGASSIGNRF
        /// <summary>排ガス記号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   排ガス記号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ACCEPTODRCARRF_EXHAUSTGASSIGNRF
        {
            get { return _aCCEPTODRCARRF_EXHAUSTGASSIGNRF; }
            set { _aCCEPTODRCARRF_EXHAUSTGASSIGNRF = value; }
        }

        /// public propaty name  :  ACCEPTODRCARRF_SERIESMODELRF
        /// <summary>シリーズ型式プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   シリーズ型式プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ACCEPTODRCARRF_SERIESMODELRF
        {
            get { return _aCCEPTODRCARRF_SERIESMODELRF; }
            set { _aCCEPTODRCARRF_SERIESMODELRF = value; }
        }

        /// public propaty name  :  ACCEPTODRCARRF_CATEGORYSIGNMODELRF
        /// <summary>型式（類別記号）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   型式（類別記号）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ACCEPTODRCARRF_CATEGORYSIGNMODELRF
        {
            get { return _aCCEPTODRCARRF_CATEGORYSIGNMODELRF; }
            set { _aCCEPTODRCARRF_CATEGORYSIGNMODELRF = value; }
        }

        /// public propaty name  :  ACCEPTODRCARRF_FULLMODELRF
        /// <summary>型式（フル型）プロパティ</summary>
        /// <value>フル型式(44桁用)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   型式（フル型）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ACCEPTODRCARRF_FULLMODELRF
        {
            get { return _aCCEPTODRCARRF_FULLMODELRF; }
            set { _aCCEPTODRCARRF_FULLMODELRF = value; }
        }

        /// public propaty name  :  ACCEPTODRCARRF_MODELDESIGNATIONNORF
        /// <summary>型式指定番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   型式指定番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ACCEPTODRCARRF_MODELDESIGNATIONNORF
        {
            get { return _aCCEPTODRCARRF_MODELDESIGNATIONNORF; }
            set { _aCCEPTODRCARRF_MODELDESIGNATIONNORF = value; }
        }

        /// public propaty name  :  ACCEPTODRCARRF_CATEGORYNORF
        /// <summary>類別番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   類別番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ACCEPTODRCARRF_CATEGORYNORF
        {
            get { return _aCCEPTODRCARRF_CATEGORYNORF; }
            set { _aCCEPTODRCARRF_CATEGORYNORF = value; }
        }

        /// public propaty name  :  ACCEPTODRCARRF_FRAMEMODELRF
        /// <summary>車台型式プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車台型式プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ACCEPTODRCARRF_FRAMEMODELRF
        {
            get { return _aCCEPTODRCARRF_FRAMEMODELRF; }
            set { _aCCEPTODRCARRF_FRAMEMODELRF = value; }
        }

        /// public propaty name  :  ACCEPTODRCARRF_FRAMENORF
        /// <summary>車台番号プロパティ</summary>
        /// <value>車検証記載フォーマット対応（ HCR32-100251584 等）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車台番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ACCEPTODRCARRF_FRAMENORF
        {
            get { return _aCCEPTODRCARRF_FRAMENORF; }
            set { _aCCEPTODRCARRF_FRAMENORF = value; }
        }

        /// public propaty name  :  ACCEPTODRCARRF_SEARCHFRAMENORF
        /// <summary>車台番号（検索用）プロパティ</summary>
        /// <value>PM7の車台番号と同意</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車台番号（検索用）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ACCEPTODRCARRF_SEARCHFRAMENORF
        {
            get { return _aCCEPTODRCARRF_SEARCHFRAMENORF; }
            set { _aCCEPTODRCARRF_SEARCHFRAMENORF = value; }
        }

        /// public propaty name  :  ACCEPTODRCARRF_ENGINEMODELNMRF
        /// <summary>エンジン型式名称プロパティ</summary>
        /// <value>エンジン検索</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   エンジン型式名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ACCEPTODRCARRF_ENGINEMODELNMRF
        {
            get { return _aCCEPTODRCARRF_ENGINEMODELNMRF; }
            set { _aCCEPTODRCARRF_ENGINEMODELNMRF = value; }
        }

        /// public propaty name  :  ACCEPTODRCARRF_RELEVANCEMODELRF
        /// <summary>関連型式プロパティ</summary>
        /// <value>リサイクル系で使用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   関連型式プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ACCEPTODRCARRF_RELEVANCEMODELRF
        {
            get { return _aCCEPTODRCARRF_RELEVANCEMODELRF; }
            set { _aCCEPTODRCARRF_RELEVANCEMODELRF = value; }
        }

        /// public propaty name  :  ACCEPTODRCARRF_SUBCARNMCDRF
        /// <summary>サブ車名コードプロパティ</summary>
        /// <value>リサイクル系で使用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   サブ車名コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ACCEPTODRCARRF_SUBCARNMCDRF
        {
            get { return _aCCEPTODRCARRF_SUBCARNMCDRF; }
            set { _aCCEPTODRCARRF_SUBCARNMCDRF = value; }
        }

        /// public propaty name  :  ACCEPTODRCARRF_MODELGRADESNAMERF
        /// <summary>型式グレード略称プロパティ</summary>
        /// <value>リサイクル系で使用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   型式グレード略称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ACCEPTODRCARRF_MODELGRADESNAMERF
        {
            get { return _aCCEPTODRCARRF_MODELGRADESNAMERF; }
            set { _aCCEPTODRCARRF_MODELGRADESNAMERF = value; }
        }

        /// public propaty name  :  ACCEPTODRCARRF_COLORCODERF
        /// <summary>カラーコードプロパティ</summary>
        /// <value>カタログの色コード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   カラーコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ACCEPTODRCARRF_COLORCODERF
        {
            get { return _aCCEPTODRCARRF_COLORCODERF; }
            set { _aCCEPTODRCARRF_COLORCODERF = value; }
        }

        /// public propaty name  :  ACCEPTODRCARRF_COLORNAME1RF
        /// <summary>カラー名称1プロパティ</summary>
        /// <value>画面表示用正式名称</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   カラー名称1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ACCEPTODRCARRF_COLORNAME1RF
        {
            get { return _aCCEPTODRCARRF_COLORNAME1RF; }
            set { _aCCEPTODRCARRF_COLORNAME1RF = value; }
        }

        /// public propaty name  :  ACCEPTODRCARRF_TRIMCODERF
        /// <summary>トリムコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   トリムコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ACCEPTODRCARRF_TRIMCODERF
        {
            get { return _aCCEPTODRCARRF_TRIMCODERF; }
            set { _aCCEPTODRCARRF_TRIMCODERF = value; }
        }

        /// public propaty name  :  ACCEPTODRCARRF_TRIMNAMERF
        /// <summary>トリム名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   トリム名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ACCEPTODRCARRF_TRIMNAMERF
        {
            get { return _aCCEPTODRCARRF_TRIMNAMERF; }
            set { _aCCEPTODRCARRF_TRIMNAMERF = value; }
        }

        /// public propaty name  :  ACCEPTODRCARRF_MILEAGERF
        /// <summary>車両走行距離プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車両走行距離プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ACCEPTODRCARRF_MILEAGERF
        {
            get { return _aCCEPTODRCARRF_MILEAGERF; }
            set { _aCCEPTODRCARRF_MILEAGERF = value; }
        }

        /// public propaty name  :  DEPSITMAINRF_ACPTANODRSTATUSRF
        /// <summary>受注ステータスプロパティ</summary>
        /// <value>10:見積,20:受注,30:売上,40:出荷</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   受注ステータスプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DEPSITMAINRF_ACPTANODRSTATUSRF
        {
            get { return _dEPSITMAINRF_ACPTANODRSTATUSRF; }
            set { _dEPSITMAINRF_ACPTANODRSTATUSRF = value; }
        }

        /// public propaty name  :  DEPSITMAINRF_DEPOSITSLIPNORF
        /// <summary>入金伝票番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金伝票番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DEPSITMAINRF_DEPOSITSLIPNORF
        {
            get { return _dEPSITMAINRF_DEPOSITSLIPNORF; }
            set { _dEPSITMAINRF_DEPOSITSLIPNORF = value; }
        }

        /// public propaty name  :  DEPSITMAINRF_SALESSLIPNUMRF
        /// <summary>売上伝票番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上伝票番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DEPSITMAINRF_SALESSLIPNUMRF
        {
            get { return _dEPSITMAINRF_SALESSLIPNUMRF; }
            set { _dEPSITMAINRF_SALESSLIPNUMRF = value; }
        }

        /// public propaty name  :  DEPSITMAINRF_ADDUPSECCODERF
        /// <summary>計上拠点コードプロパティ</summary>
        /// <value>集計の対象となっている拠点コード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   計上拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DEPSITMAINRF_ADDUPSECCODERF
        {
            get { return _dEPSITMAINRF_ADDUPSECCODERF; }
            set { _dEPSITMAINRF_ADDUPSECCODERF = value; }
        }

        /// public propaty name  :  DEPSITMAINRF_SUBSECTIONCODERF
        /// <summary>部門コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   部門コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DEPSITMAINRF_SUBSECTIONCODERF
        {
            get { return _dEPSITMAINRF_SUBSECTIONCODERF; }
            set { _dEPSITMAINRF_SUBSECTIONCODERF = value; }
        }

        /// public propaty name  :  DEPSITMAINRF_DEPOSITDATERF
        /// <summary>入金日付プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金日付プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DEPSITMAINRF_DEPOSITDATERF
        {
            get { return _dEPSITMAINRF_DEPOSITDATERF; }
            set { _dEPSITMAINRF_DEPOSITDATERF = value; }
        }

        /// public propaty name  :  DEPSITMAINRF_ADDUPADATERF
        /// <summary>計上日付プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   計上日付プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DEPSITMAINRF_ADDUPADATERF
        {
            get { return _dEPSITMAINRF_ADDUPADATERF; }
            set { _dEPSITMAINRF_ADDUPADATERF = value; }
        }

        /// public propaty name  :  DEPSITMAINRF_DEPOSITRF
        /// <summary>入金金額プロパティ</summary>
        /// <value>値引・手数料を除いた額</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金金額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 DEPSITMAINRF_DEPOSITRF
        {
            get { return _dEPSITMAINRF_DEPOSITRF; }
            set { _dEPSITMAINRF_DEPOSITRF = value; }
        }

        /// public propaty name  :  DEPSITMAINRF_FEEDEPOSITRF
        /// <summary>手数料入金額プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   手数料入金額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 DEPSITMAINRF_FEEDEPOSITRF
        {
            get { return _dEPSITMAINRF_FEEDEPOSITRF; }
            set { _dEPSITMAINRF_FEEDEPOSITRF = value; }
        }

        /// public propaty name  :  DEPSITMAINRF_DISCOUNTDEPOSITRF
        /// <summary>値引入金額プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   値引入金額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 DEPSITMAINRF_DISCOUNTDEPOSITRF
        {
            get { return _dEPSITMAINRF_DISCOUNTDEPOSITRF; }
            set { _dEPSITMAINRF_DISCOUNTDEPOSITRF = value; }
        }

        /// public propaty name  :  DEPSITMAINRF_AUTODEPOSITCDRF
        /// <summary>自動入金区分プロパティ</summary>
        /// <value>0:通常入金,1:自動入金</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自動入金区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DEPSITMAINRF_AUTODEPOSITCDRF
        {
            get { return _dEPSITMAINRF_AUTODEPOSITCDRF; }
            set { _dEPSITMAINRF_AUTODEPOSITCDRF = value; }
        }

        /// public propaty name  :  DEPSITMAINRF_DEPOSITCDRF
        /// <summary>預り金区分プロパティ</summary>
        /// <value>0:通常入金,1:預り金入金</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   預り金区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DEPSITMAINRF_DEPOSITCDRF
        {
            get { return _dEPSITMAINRF_DEPOSITCDRF; }
            set { _dEPSITMAINRF_DEPOSITCDRF = value; }
        }

        /// public propaty name  :  DEPSITMAINRF_DRAFTDRAWINGDATERF
        /// <summary>手形振出日プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   手形振出日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DEPSITMAINRF_DRAFTDRAWINGDATERF
        {
            get { return _dEPSITMAINRF_DRAFTDRAWINGDATERF; }
            set { _dEPSITMAINRF_DRAFTDRAWINGDATERF = value; }
        }

        /// public propaty name  :  DEPSITMAINRF_DRAFTKINDRF
        /// <summary>手形種類プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   手形種類プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DEPSITMAINRF_DRAFTKINDRF
        {
            get { return _dEPSITMAINRF_DRAFTKINDRF; }
            set { _dEPSITMAINRF_DRAFTKINDRF = value; }
        }

        /// public propaty name  :  DEPSITMAINRF_DRAFTKINDNAMERF
        /// <summary>手形種類名称プロパティ</summary>
        /// <value>約束、為替、小切手</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   手形種類名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DEPSITMAINRF_DRAFTKINDNAMERF
        {
            get { return _dEPSITMAINRF_DRAFTKINDNAMERF; }
            set { _dEPSITMAINRF_DRAFTKINDNAMERF = value; }
        }

        /// public propaty name  :  DEPSITMAINRF_DRAFTDIVIDENAMERF
        /// <summary>手形区分名称プロパティ</summary>
        /// <value>自振、廻し</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   手形区分名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DEPSITMAINRF_DRAFTDIVIDENAMERF
        {
            get { return _dEPSITMAINRF_DRAFTDIVIDENAMERF; }
            set { _dEPSITMAINRF_DRAFTDIVIDENAMERF = value; }
        }

        /// public propaty name  :  DEPSITMAINRF_DRAFTNORF
        /// <summary>手形番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   手形番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DEPSITMAINRF_DRAFTNORF
        {
            get { return _dEPSITMAINRF_DRAFTNORF; }
            set { _dEPSITMAINRF_DRAFTNORF = value; }
        }

        /// public propaty name  :  DEPSITMAINRF_CUSTOMERCODERF
        /// <summary>得意先コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DEPSITMAINRF_CUSTOMERCODERF
        {
            get { return _dEPSITMAINRF_CUSTOMERCODERF; }
            set { _dEPSITMAINRF_CUSTOMERCODERF = value; }
        }

        /// public propaty name  :  DEPSITMAINRF_CLAIMCODERF
        /// <summary>請求先コードプロパティ</summary>
        /// <value>請求先得意先</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   請求先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DEPSITMAINRF_CLAIMCODERF
        {
            get { return _dEPSITMAINRF_CLAIMCODERF; }
            set { _dEPSITMAINRF_CLAIMCODERF = value; }
        }

        /// public propaty name  :  DEPSITMAINRF_OUTLINERF
        /// <summary>伝票摘要プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票摘要プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DEPSITMAINRF_OUTLINERF
        {
            get { return _dEPSITMAINRF_OUTLINERF; }
            set { _dEPSITMAINRF_OUTLINERF = value; }
        }

        /// public propaty name  :  SUBDEP_SUBSECTIONNAMERF
        /// <summary>入金請求部門名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金請求部門名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SUBDEP_SUBSECTIONNAMERF
        {
            get { return _sUBDEP_SUBSECTIONNAMERF; }
            set { _sUBDEP_SUBSECTIONNAMERF = value; }
        }

        /// public propaty name  :  DEPSITDTLRF_DEPOSITSLIPNORF
        /// <summary>入金伝票番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金伝票番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DEPSITDTLRF_DEPOSITSLIPNORF
        {
            get { return _dEPSITDTLRF_DEPOSITSLIPNORF; }
            set { _dEPSITDTLRF_DEPOSITSLIPNORF = value; }
        }

        /// public propaty name  :  DEPSITDTLRF_DEPOSITROWNORF
        /// <summary>入金行番号プロパティ</summary>
        /// <value>※入金設定金種コードの設定番号をセット</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金行番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DEPSITDTLRF_DEPOSITROWNORF
        {
            get { return _dEPSITDTLRF_DEPOSITROWNORF; }
            set { _dEPSITDTLRF_DEPOSITROWNORF = value; }
        }

        /// public propaty name  :  DEPSITDTLRF_MONEYKINDCODERF
        /// <summary>金種コードプロパティ</summary>
        /// <value>1～899:提供分,900～ユーザー登録　※8:値引 9:預かり金</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   金種コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DEPSITDTLRF_MONEYKINDCODERF
        {
            get { return _dEPSITDTLRF_MONEYKINDCODERF; }
            set { _dEPSITDTLRF_MONEYKINDCODERF = value; }
        }

        /// public propaty name  :  DEPSITDTLRF_MONEYKINDNAMERF
        /// <summary>金種名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   金種名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DEPSITDTLRF_MONEYKINDNAMERF
        {
            get { return _dEPSITDTLRF_MONEYKINDNAMERF; }
            set { _dEPSITDTLRF_MONEYKINDNAMERF = value; }
        }

        /// public propaty name  :  DEPSITDTLRF_MONEYKINDDIVRF
        /// <summary>金種区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   金種区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DEPSITDTLRF_MONEYKINDDIVRF
        {
            get { return _dEPSITDTLRF_MONEYKINDDIVRF; }
            set { _dEPSITDTLRF_MONEYKINDDIVRF = value; }
        }

        /// public propaty name  :  DEPSITDTLRF_DEPOSITRF
        /// <summary>入金金額プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金金額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 DEPSITDTLRF_DEPOSITRF
        {
            get { return _dEPSITDTLRF_DEPOSITRF; }
            set { _dEPSITDTLRF_DEPOSITRF = value; }
        }

        /// public propaty name  :  DEPSITDTLRF_VALIDITYTERMRF
        /// <summary>有効期限プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   有効期限プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DEPSITDTLRF_VALIDITYTERMRF
        {
            get { return _dEPSITDTLRF_VALIDITYTERMRF; }
            set { _dEPSITDTLRF_VALIDITYTERMRF = value; }
        }

        /// public propaty name  :  DADD_ACPTANODRSTATUSRF
        /// <summary>受注ステータス名称プロパティ</summary>
        /// <value>10:見積,20:受注,30:売上,40:出荷</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   受注ステータス名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DADD_ACPTANODRSTATUSRF
        {
            get { return _dADD_ACPTANODRSTATUSRF; }
            set { _dADD_ACPTANODRSTATUSRF = value; }
        }

        /// public propaty name  :  DADD_DEBITNOTEDIVRF
        /// <summary>赤伝区分名称プロパティ</summary>
        /// <value>0:黒伝,1:赤伝,2:元黒</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   赤伝区分名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DADD_DEBITNOTEDIVRF
        {
            get { return _dADD_DEBITNOTEDIVRF; }
            set { _dADD_DEBITNOTEDIVRF = value; }
        }

        /// public propaty name  :  DADD_SALESSLIPCDRF
        /// <summary>売上伝票区分名称プロパティ</summary>
        /// <value>0:売上,1:返品</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上伝票区分名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DADD_SALESSLIPCDRF
        {
            get { return _dADD_SALESSLIPCDRF; }
            set { _dADD_SALESSLIPCDRF = value; }
        }

        /// public propaty name  :  DADD_SALESDATERF
        /// <summary>売上日付プロパティ</summary>
        /// <value>見積日、受注日、売上日を兼ねる。(YYYYMMDD)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上日付プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DADD_SALESDATERF
        {
            get { return _dADD_SALESDATERF; }
            set { _dADD_SALESDATERF = value; }
        }

        /// public propaty name  :  DADD_SALESDATEFYRF
        /// <summary>売上日付西暦年プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上日付西暦年プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DADD_SALESDATEFYRF
        {
            get { return _dADD_SALESDATEFYRF; }
            set { _dADD_SALESDATEFYRF = value; }
        }

        /// public propaty name  :  DADD_SALESDATEFSRF
        /// <summary>売上日付西暦年略プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上日付西暦年略プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DADD_SALESDATEFSRF
        {
            get { return _dADD_SALESDATEFSRF; }
            set { _dADD_SALESDATEFSRF = value; }
        }

        /// public propaty name  :  DADD_SALESDATEFWRF
        /// <summary>売上日付和暦年プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上日付和暦年プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DADD_SALESDATEFWRF
        {
            get { return _dADD_SALESDATEFWRF; }
            set { _dADD_SALESDATEFWRF = value; }
        }

        /// public propaty name  :  DADD_SALESDATEFMRF
        /// <summary>売上日付月プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上日付月プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DADD_SALESDATEFMRF
        {
            get { return _dADD_SALESDATEFMRF; }
            set { _dADD_SALESDATEFMRF = value; }
        }

        /// public propaty name  :  DADD_SALESDATEFDRF
        /// <summary>売上日付日プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上日付日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DADD_SALESDATEFDRF
        {
            get { return _dADD_SALESDATEFDRF; }
            set { _dADD_SALESDATEFDRF = value; }
        }

        /// public propaty name  :  DADD_SALESDATEFGRF
        /// <summary>売上日付元号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上日付元号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DADD_SALESDATEFGRF
        {
            get { return _dADD_SALESDATEFGRF; }
            set { _dADD_SALESDATEFGRF = value; }
        }

        /// public propaty name  :  DADD_SALESDATEFRRF
        /// <summary>売上日付略号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上日付略号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DADD_SALESDATEFRRF
        {
            get { return _dADD_SALESDATEFRRF; }
            set { _dADD_SALESDATEFRRF = value; }
        }

        /// public propaty name  :  DADD_SALESDATEFLSRF
        /// <summary>売上日付リテラル(/)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上日付リテラル(/)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DADD_SALESDATEFLSRF
        {
            get { return _dADD_SALESDATEFLSRF; }
            set { _dADD_SALESDATEFLSRF = value; }
        }

        /// public propaty name  :  DADD_SALESDATEFLPRF
        /// <summary>売上日付リテラル(.)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上日付リテラル(.)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DADD_SALESDATEFLPRF
        {
            get { return _dADD_SALESDATEFLPRF; }
            set { _dADD_SALESDATEFLPRF = value; }
        }

        /// public propaty name  :  DADD_SALESDATEFLYRF
        /// <summary>売上日付リテラル(年)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上日付リテラル(年)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DADD_SALESDATEFLYRF
        {
            get { return _dADD_SALESDATEFLYRF; }
            set { _dADD_SALESDATEFLYRF = value; }
        }

        /// public propaty name  :  DADD_SALESDATEFLMRF
        /// <summary>売上日付リテラル(月)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上日付リテラル(月)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DADD_SALESDATEFLMRF
        {
            get { return _dADD_SALESDATEFLMRF; }
            set { _dADD_SALESDATEFLMRF = value; }
        }

        /// public propaty name  :  DADD_SALESDATEFLDRF
        /// <summary>売上日付リテラル(日)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上日付リテラル(日)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DADD_SALESDATEFLDRF
        {
            get { return _dADD_SALESDATEFLDRF; }
            set { _dADD_SALESDATEFLDRF = value; }
        }

        /// public propaty name  :  DADD_STOCKGOODSTTLTAXEXCRF
        /// <summary>取寄商品合計金額（税抜）プロパティ</summary>
        /// <value>在庫取寄区分が０でない明細金額の集計</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   取寄商品合計金額（税抜）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 DADD_STOCKGOODSTTLTAXEXCRF
        {
            get { return _dADD_STOCKGOODSTTLTAXEXCRF; }
            set { _dADD_STOCKGOODSTTLTAXEXCRF = value; }
        }

        /// public propaty name  :  DADD_PUREGOODSTTLTAXEXCRF
        /// <summary>優良商品合計金額（税抜）プロパティ</summary>
        /// <value>商品属性が０でない明細金額の集計</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   優良商品合計金額（税抜）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 DADD_PUREGOODSTTLTAXEXCRF
        {
            get { return _dADD_PUREGOODSTTLTAXEXCRF; }
            set { _dADD_PUREGOODSTTLTAXEXCRF = value; }
        }

        /// public propaty name  :  DADD_GOODSKINDCODERF
        /// <summary>商品属性名称プロパティ</summary>
        /// <value>0:純正 1:優良</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品属性名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DADD_GOODSKINDCODERF
        {
            get { return _dADD_GOODSKINDCODERF; }
            set { _dADD_GOODSKINDCODERF = value; }
        }

        /// public propaty name  :  DADD_SALESORDERDIVCDRF
        /// <summary>売上在庫取寄せ区分名称プロパティ</summary>
        /// <value>0:取寄せ，1:在庫</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上在庫取寄せ区分名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DADD_SALESORDERDIVCDRF
        {
            get { return _dADD_SALESORDERDIVCDRF; }
            set { _dADD_SALESORDERDIVCDRF = value; }
        }

        /// public propaty name  :  DADD_OPENPRICEDIVRF
        /// <summary>オープン価格区分名称プロパティ</summary>
        /// <value>0:通常／1:オープン価格</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   オープン価格区分名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DADD_OPENPRICEDIVRF
        {
            get { return _dADD_OPENPRICEDIVRF; }
            set { _dADD_OPENPRICEDIVRF = value; }
        }

        /// public propaty name  :  DADD_TAXATIONDIVCDRF
        /// <summary>課税区分名称プロパティ</summary>
        /// <value>0:課税,1:非課税,2:課税（内税）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   課税区分名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DADD_TAXATIONDIVCDRF
        {
            get { return _dADD_TAXATIONDIVCDRF; }
            set { _dADD_TAXATIONDIVCDRF = value; }
        }

        /// public propaty name  :  DADD_FIRSTENTRYDATEFYRF
        /// <summary>初年度西暦年プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   初年度西暦年プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DADD_FIRSTENTRYDATEFYRF
        {
            get { return _dADD_FIRSTENTRYDATEFYRF; }
            set { _dADD_FIRSTENTRYDATEFYRF = value; }
        }

        /// public propaty name  :  DADD_FIRSTENTRYDATEFSRF
        /// <summary>初年度西暦年略プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   初年度西暦年略プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DADD_FIRSTENTRYDATEFSRF
        {
            get { return _dADD_FIRSTENTRYDATEFSRF; }
            set { _dADD_FIRSTENTRYDATEFSRF = value; }
        }

        /// public propaty name  :  DADD_FIRSTENTRYDATEFWRF
        /// <summary>初年度和暦年プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   初年度和暦年プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DADD_FIRSTENTRYDATEFWRF
        {
            get { return _dADD_FIRSTENTRYDATEFWRF; }
            set { _dADD_FIRSTENTRYDATEFWRF = value; }
        }

        /// public propaty name  :  DADD_FIRSTENTRYDATEFMRF
        /// <summary>初年度月プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   初年度月プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DADD_FIRSTENTRYDATEFMRF
        {
            get { return _dADD_FIRSTENTRYDATEFMRF; }
            set { _dADD_FIRSTENTRYDATEFMRF = value; }
        }

        /// public propaty name  :  DADD_FIRSTENTRYDATEFGRF
        /// <summary>初年度元号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   初年度元号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DADD_FIRSTENTRYDATEFGRF
        {
            get { return _dADD_FIRSTENTRYDATEFGRF; }
            set { _dADD_FIRSTENTRYDATEFGRF = value; }
        }

        /// public propaty name  :  DADD_FIRSTENTRYDATEFRRF
        /// <summary>初年度略号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   初年度略号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DADD_FIRSTENTRYDATEFRRF
        {
            get { return _dADD_FIRSTENTRYDATEFRRF; }
            set { _dADD_FIRSTENTRYDATEFRRF = value; }
        }

        /// public propaty name  :  DADD_FIRSTENTRYDATEFLSRF
        /// <summary>初年度リテラル(/)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   初年度リテラル(/)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DADD_FIRSTENTRYDATEFLSRF
        {
            get { return _dADD_FIRSTENTRYDATEFLSRF; }
            set { _dADD_FIRSTENTRYDATEFLSRF = value; }
        }

        /// public propaty name  :  DADD_FIRSTENTRYDATEFLPRF
        /// <summary>初年度リテラル(.)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   初年度リテラル(.)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DADD_FIRSTENTRYDATEFLPRF
        {
            get { return _dADD_FIRSTENTRYDATEFLPRF; }
            set { _dADD_FIRSTENTRYDATEFLPRF = value; }
        }

        /// public propaty name  :  DADD_FIRSTENTRYDATEFLYRF
        /// <summary>初年度リテラル(年)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   初年度リテラル(年)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DADD_FIRSTENTRYDATEFLYRF
        {
            get { return _dADD_FIRSTENTRYDATEFLYRF; }
            set { _dADD_FIRSTENTRYDATEFLYRF = value; }
        }

        /// public propaty name  :  DADD_FIRSTENTRYDATEFLMRF
        /// <summary>初年度リテラル(月)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   初年度リテラル(月)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DADD_FIRSTENTRYDATEFLMRF
        {
            get { return _dADD_FIRSTENTRYDATEFLMRF; }
            set { _dADD_FIRSTENTRYDATEFLMRF = value; }
        }

        /// public propaty name  :  DADD_DEPOSITDATEFYRF
        /// <summary>入金日付西暦年プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金日付西暦年プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DADD_DEPOSITDATEFYRF
        {
            get { return _dADD_DEPOSITDATEFYRF; }
            set { _dADD_DEPOSITDATEFYRF = value; }
        }

        /// public propaty name  :  DADD_DEPOSITDATEFSRF
        /// <summary>入金日付西暦年略プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金日付西暦年略プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DADD_DEPOSITDATEFSRF
        {
            get { return _dADD_DEPOSITDATEFSRF; }
            set { _dADD_DEPOSITDATEFSRF = value; }
        }

        /// public propaty name  :  DADD_DEPOSITDATEFWRF
        /// <summary>入金日付和暦年プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金日付和暦年プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DADD_DEPOSITDATEFWRF
        {
            get { return _dADD_DEPOSITDATEFWRF; }
            set { _dADD_DEPOSITDATEFWRF = value; }
        }

        /// public propaty name  :  DADD_DEPOSITDATEFMRF
        /// <summary>入金日付月プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金日付月プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DADD_DEPOSITDATEFMRF
        {
            get { return _dADD_DEPOSITDATEFMRF; }
            set { _dADD_DEPOSITDATEFMRF = value; }
        }

        /// public propaty name  :  DADD_DEPOSITDATEFDRF
        /// <summary>入金日付日プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金日付日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DADD_DEPOSITDATEFDRF
        {
            get { return _dADD_DEPOSITDATEFDRF; }
            set { _dADD_DEPOSITDATEFDRF = value; }
        }

        /// public propaty name  :  DADD_DEPOSITDATEFGRF
        /// <summary>入金日付元号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金日付元号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DADD_DEPOSITDATEFGRF
        {
            get { return _dADD_DEPOSITDATEFGRF; }
            set { _dADD_DEPOSITDATEFGRF = value; }
        }

        /// public propaty name  :  DADD_DEPOSITDATEFRRF
        /// <summary>入金日付略号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金日付略号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DADD_DEPOSITDATEFRRF
        {
            get { return _dADD_DEPOSITDATEFRRF; }
            set { _dADD_DEPOSITDATEFRRF = value; }
        }

        /// public propaty name  :  DADD_DEPOSITDATEFLSRF
        /// <summary>入金日付リテラル(/)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金日付リテラル(/)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DADD_DEPOSITDATEFLSRF
        {
            get { return _dADD_DEPOSITDATEFLSRF; }
            set { _dADD_DEPOSITDATEFLSRF = value; }
        }

        /// public propaty name  :  DADD_DEPOSITDATEFLPRF
        /// <summary>入金日付リテラル(.)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金日付リテラル(.)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DADD_DEPOSITDATEFLPRF
        {
            get { return _dADD_DEPOSITDATEFLPRF; }
            set { _dADD_DEPOSITDATEFLPRF = value; }
        }

        /// public propaty name  :  DADD_DEPOSITDATEFLYRF
        /// <summary>入金日付リテラル(年)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金日付リテラル(年)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DADD_DEPOSITDATEFLYRF
        {
            get { return _dADD_DEPOSITDATEFLYRF; }
            set { _dADD_DEPOSITDATEFLYRF = value; }
        }

        /// public propaty name  :  DADD_DEPOSITDATEFLMRF
        /// <summary>入金日付リテラル(月)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金日付リテラル(月)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DADD_DEPOSITDATEFLMRF
        {
            get { return _dADD_DEPOSITDATEFLMRF; }
            set { _dADD_DEPOSITDATEFLMRF = value; }
        }

        /// public propaty name  :  DADD_DEPOSITDATEFLDRF
        /// <summary>入金日付リテラル(日)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金日付リテラル(日)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DADD_DEPOSITDATEFLDRF
        {
            get { return _dADD_DEPOSITDATEFLDRF; }
            set { _dADD_DEPOSITDATEFLDRF = value; }
        }

        /// public propaty name  :  DADD_AUTODEPOSITCDRF
        /// <summary>自動入金区分名称プロパティ</summary>
        /// <value>0:通常入金,1:自動入金</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自動入金区分名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DADD_AUTODEPOSITCDRF
        {
            get { return _dADD_AUTODEPOSITCDRF; }
            set { _dADD_AUTODEPOSITCDRF = value; }
        }

        /// public propaty name  :  DADD_DEPOSITCDRF
        /// <summary>預り金区分名称プロパティ</summary>
        /// <value>0:通常入金,1:預り金入金</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   預り金区分名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DADD_DEPOSITCDRF
        {
            get { return _dADD_DEPOSITCDRF; }
            set { _dADD_DEPOSITCDRF = value; }
        }

        /// public propaty name  :  DADD_DRAFTDRAWINGDATEFYRF
        /// <summary>手形振出日西暦年プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   手形振出日西暦年プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DADD_DRAFTDRAWINGDATEFYRF
        {
            get { return _dADD_DRAFTDRAWINGDATEFYRF; }
            set { _dADD_DRAFTDRAWINGDATEFYRF = value; }
        }

        /// public propaty name  :  DADD_DRAFTDRAWINGDATEFSRF
        /// <summary>手形振出日西暦年略プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   手形振出日西暦年略プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DADD_DRAFTDRAWINGDATEFSRF
        {
            get { return _dADD_DRAFTDRAWINGDATEFSRF; }
            set { _dADD_DRAFTDRAWINGDATEFSRF = value; }
        }

        /// public propaty name  :  DADD_DRAFTDRAWINGDATEFWRF
        /// <summary>手形振出日和暦年プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   手形振出日和暦年プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DADD_DRAFTDRAWINGDATEFWRF
        {
            get { return _dADD_DRAFTDRAWINGDATEFWRF; }
            set { _dADD_DRAFTDRAWINGDATEFWRF = value; }
        }

        /// public propaty name  :  DADD_DRAFTDRAWINGDATEFMRF
        /// <summary>手形振出日月プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   手形振出日月プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DADD_DRAFTDRAWINGDATEFMRF
        {
            get { return _dADD_DRAFTDRAWINGDATEFMRF; }
            set { _dADD_DRAFTDRAWINGDATEFMRF = value; }
        }

        /// public propaty name  :  DADD_DRAFTDRAWINGDATEFDRF
        /// <summary>手形振出日日プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   手形振出日日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DADD_DRAFTDRAWINGDATEFDRF
        {
            get { return _dADD_DRAFTDRAWINGDATEFDRF; }
            set { _dADD_DRAFTDRAWINGDATEFDRF = value; }
        }

        /// public propaty name  :  DADD_DRAFTDRAWINGDATEFGRF
        /// <summary>手形振出日元号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   手形振出日元号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DADD_DRAFTDRAWINGDATEFGRF
        {
            get { return _dADD_DRAFTDRAWINGDATEFGRF; }
            set { _dADD_DRAFTDRAWINGDATEFGRF = value; }
        }

        /// public propaty name  :  DADD_DRAFTDRAWINGDATEFRRF
        /// <summary>手形振出日略号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   手形振出日略号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DADD_DRAFTDRAWINGDATEFRRF
        {
            get { return _dADD_DRAFTDRAWINGDATEFRRF; }
            set { _dADD_DRAFTDRAWINGDATEFRRF = value; }
        }

        /// public propaty name  :  DADD_DRAFTDRAWINGDATEFLSRF
        /// <summary>手形振出日リテラル(/)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   手形振出日リテラル(/)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DADD_DRAFTDRAWINGDATEFLSRF
        {
            get { return _dADD_DRAFTDRAWINGDATEFLSRF; }
            set { _dADD_DRAFTDRAWINGDATEFLSRF = value; }
        }

        /// public propaty name  :  DADD_DRAFTDRAWINGDATEFLPRF
        /// <summary>手形振出日リテラル(.)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   手形振出日リテラル(.)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DADD_DRAFTDRAWINGDATEFLPRF
        {
            get { return _dADD_DRAFTDRAWINGDATEFLPRF; }
            set { _dADD_DRAFTDRAWINGDATEFLPRF = value; }
        }

        /// public propaty name  :  DADD_DRAFTDRAWINGDATEFLYRF
        /// <summary>手形振出日リテラル(年)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   手形振出日リテラル(年)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DADD_DRAFTDRAWINGDATEFLYRF
        {
            get { return _dADD_DRAFTDRAWINGDATEFLYRF; }
            set { _dADD_DRAFTDRAWINGDATEFLYRF = value; }
        }

        /// public propaty name  :  DADD_DRAFTDRAWINGDATEFLMRF
        /// <summary>手形振出日リテラル(月)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   手形振出日リテラル(月)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DADD_DRAFTDRAWINGDATEFLMRF
        {
            get { return _dADD_DRAFTDRAWINGDATEFLMRF; }
            set { _dADD_DRAFTDRAWINGDATEFLMRF = value; }
        }

        /// public propaty name  :  DADD_DRAFTDRAWINGDATEFLDRF
        /// <summary>手形振出日リテラル(日)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   手形振出日リテラル(日)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DADD_DRAFTDRAWINGDATEFLDRF
        {
            get { return _dADD_DRAFTDRAWINGDATEFLDRF; }
            set { _dADD_DRAFTDRAWINGDATEFLDRF = value; }
        }

        /// public propaty name  :  DADD_DRAFTPAYTIMELIMITFYRF
        /// <summary>手形支払期日西暦年プロパティ</summary>
        /// <value>有効期限と同じ内容をセットする</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   手形支払期日西暦年プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DADD_DRAFTPAYTIMELIMITFYRF
        {
            get { return _dADD_DRAFTPAYTIMELIMITFYRF; }
            set { _dADD_DRAFTPAYTIMELIMITFYRF = value; }
        }

        /// public propaty name  :  DADD_DRAFTPAYTIMELIMITFSRF
        /// <summary>手形支払期日西暦年略プロパティ</summary>
        /// <value>有効期限と同じ内容をセットする</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   手形支払期日西暦年略プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DADD_DRAFTPAYTIMELIMITFSRF
        {
            get { return _dADD_DRAFTPAYTIMELIMITFSRF; }
            set { _dADD_DRAFTPAYTIMELIMITFSRF = value; }
        }

        /// public propaty name  :  DADD_DRAFTPAYTIMELIMITFWRF
        /// <summary>手形支払期日和暦年プロパティ</summary>
        /// <value>有効期限と同じ内容をセットする</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   手形支払期日和暦年プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DADD_DRAFTPAYTIMELIMITFWRF
        {
            get { return _dADD_DRAFTPAYTIMELIMITFWRF; }
            set { _dADD_DRAFTPAYTIMELIMITFWRF = value; }
        }

        /// public propaty name  :  DADD_DRAFTPAYTIMELIMITFMRF
        /// <summary>手形支払期日月プロパティ</summary>
        /// <value>有効期限と同じ内容をセットする</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   手形支払期日月プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DADD_DRAFTPAYTIMELIMITFMRF
        {
            get { return _dADD_DRAFTPAYTIMELIMITFMRF; }
            set { _dADD_DRAFTPAYTIMELIMITFMRF = value; }
        }

        /// public propaty name  :  DADD_DRAFTPAYTIMELIMITFDRF
        /// <summary>手形支払期日日プロパティ</summary>
        /// <value>有効期限と同じ内容をセットする</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   手形支払期日日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DADD_DRAFTPAYTIMELIMITFDRF
        {
            get { return _dADD_DRAFTPAYTIMELIMITFDRF; }
            set { _dADD_DRAFTPAYTIMELIMITFDRF = value; }
        }

        /// public propaty name  :  DADD_DRAFTPAYTIMELIMITFGRF
        /// <summary>手形支払期日元号プロパティ</summary>
        /// <value>有効期限と同じ内容をセットする</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   手形支払期日元号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DADD_DRAFTPAYTIMELIMITFGRF
        {
            get { return _dADD_DRAFTPAYTIMELIMITFGRF; }
            set { _dADD_DRAFTPAYTIMELIMITFGRF = value; }
        }

        /// public propaty name  :  DADD_DRAFTPAYTIMELIMITFRRF
        /// <summary>手形支払期日略号プロパティ</summary>
        /// <value>有効期限と同じ内容をセットする</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   手形支払期日略号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DADD_DRAFTPAYTIMELIMITFRRF
        {
            get { return _dADD_DRAFTPAYTIMELIMITFRRF; }
            set { _dADD_DRAFTPAYTIMELIMITFRRF = value; }
        }

        /// public propaty name  :  DADD_DRAFTPAYTIMELIMITFLSRF
        /// <summary>手形支払期日リテラル(/)プロパティ</summary>
        /// <value>有効期限と同じ内容をセットする</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   手形支払期日リテラル(/)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DADD_DRAFTPAYTIMELIMITFLSRF
        {
            get { return _dADD_DRAFTPAYTIMELIMITFLSRF; }
            set { _dADD_DRAFTPAYTIMELIMITFLSRF = value; }
        }

        /// public propaty name  :  DADD_DRAFTPAYTIMELIMITFLPRF
        /// <summary>手形支払期日リテラル(.)プロパティ</summary>
        /// <value>有効期限と同じ内容をセットする</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   手形支払期日リテラル(.)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DADD_DRAFTPAYTIMELIMITFLPRF
        {
            get { return _dADD_DRAFTPAYTIMELIMITFLPRF; }
            set { _dADD_DRAFTPAYTIMELIMITFLPRF = value; }
        }

        /// public propaty name  :  DADD_DRAFTPAYTIMELIMITFLYRF
        /// <summary>手形支払期日リテラル(年)プロパティ</summary>
        /// <value>有効期限と同じ内容をセットする</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   手形支払期日リテラル(年)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DADD_DRAFTPAYTIMELIMITFLYRF
        {
            get { return _dADD_DRAFTPAYTIMELIMITFLYRF; }
            set { _dADD_DRAFTPAYTIMELIMITFLYRF = value; }
        }

        /// public propaty name  :  DADD_DRAFTPAYTIMELIMITFLMRF
        /// <summary>手形支払期日リテラル(月)プロパティ</summary>
        /// <value>有効期限と同じ内容をセットする</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   手形支払期日リテラル(月)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DADD_DRAFTPAYTIMELIMITFLMRF
        {
            get { return _dADD_DRAFTPAYTIMELIMITFLMRF; }
            set { _dADD_DRAFTPAYTIMELIMITFLMRF = value; }
        }

        /// public propaty name  :  DADD_DRAFTPAYTIMELIMITFLDRF
        /// <summary>手形支払期日リテラル(日)プロパティ</summary>
        /// <value>有効期限と同じ内容をセットする</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   手形支払期日リテラル(日)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DADD_DRAFTPAYTIMELIMITFLDRF
        {
            get { return _dADD_DRAFTPAYTIMELIMITFLDRF; }
            set { _dADD_DRAFTPAYTIMELIMITFLDRF = value; }
        }

        /// public propaty name  :  DADD_VALIDITYTERMFYRF
        /// <summary>有効期限西暦年プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   有効期限西暦年プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DADD_VALIDITYTERMFYRF
        {
            get { return _dADD_VALIDITYTERMFYRF; }
            set { _dADD_VALIDITYTERMFYRF = value; }
        }

        /// public propaty name  :  DADD_VALIDITYTERMFSRF
        /// <summary>有効期限西暦年略プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   有効期限西暦年略プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DADD_VALIDITYTERMFSRF
        {
            get { return _dADD_VALIDITYTERMFSRF; }
            set { _dADD_VALIDITYTERMFSRF = value; }
        }

        /// public propaty name  :  DADD_VALIDITYTERMFWRF
        /// <summary>有効期限和暦年プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   有効期限和暦年プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DADD_VALIDITYTERMFWRF
        {
            get { return _dADD_VALIDITYTERMFWRF; }
            set { _dADD_VALIDITYTERMFWRF = value; }
        }

        /// public propaty name  :  DADD_VALIDITYTERMFMRF
        /// <summary>有効期限月プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   有効期限月プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DADD_VALIDITYTERMFMRF
        {
            get { return _dADD_VALIDITYTERMFMRF; }
            set { _dADD_VALIDITYTERMFMRF = value; }
        }

        /// public propaty name  :  DADD_VALIDITYTERMFDRF
        /// <summary>有効期限日プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   有効期限日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DADD_VALIDITYTERMFDRF
        {
            get { return _dADD_VALIDITYTERMFDRF; }
            set { _dADD_VALIDITYTERMFDRF = value; }
        }

        /// public propaty name  :  DADD_VALIDITYTERMFGRF
        /// <summary>有効期限元号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   有効期限元号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DADD_VALIDITYTERMFGRF
        {
            get { return _dADD_VALIDITYTERMFGRF; }
            set { _dADD_VALIDITYTERMFGRF = value; }
        }

        /// public propaty name  :  DADD_VALIDITYTERMFRRF
        /// <summary>有効期限略号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   有効期限略号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DADD_VALIDITYTERMFRRF
        {
            get { return _dADD_VALIDITYTERMFRRF; }
            set { _dADD_VALIDITYTERMFRRF = value; }
        }

        /// public propaty name  :  DADD_VALIDITYTERMFLSRF
        /// <summary>有効期限リテラル(/)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   有効期限リテラル(/)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DADD_VALIDITYTERMFLSRF
        {
            get { return _dADD_VALIDITYTERMFLSRF; }
            set { _dADD_VALIDITYTERMFLSRF = value; }
        }

        /// public propaty name  :  DADD_VALIDITYTERMFLPRF
        /// <summary>有効期限リテラル(.)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   有効期限リテラル(.)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DADD_VALIDITYTERMFLPRF
        {
            get { return _dADD_VALIDITYTERMFLPRF; }
            set { _dADD_VALIDITYTERMFLPRF = value; }
        }

        /// public propaty name  :  DADD_VALIDITYTERMFLYRF
        /// <summary>有効期限リテラル(年)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   有効期限リテラル(年)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DADD_VALIDITYTERMFLYRF
        {
            get { return _dADD_VALIDITYTERMFLYRF; }
            set { _dADD_VALIDITYTERMFLYRF = value; }
        }

        /// public propaty name  :  DADD_VALIDITYTERMFLMRF
        /// <summary>有効期限リテラル(月)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   有効期限リテラル(月)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DADD_VALIDITYTERMFLMRF
        {
            get { return _dADD_VALIDITYTERMFLMRF; }
            set { _dADD_VALIDITYTERMFLMRF = value; }
        }

        /// public propaty name  :  DADD_VALIDITYTERMFLDRF
        /// <summary>有効期限リテラル(日)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   有効期限リテラル(日)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DADD_VALIDITYTERMFLDRF
        {
            get { return _dADD_VALIDITYTERMFLDRF; }
            set { _dADD_VALIDITYTERMFLDRF = value; }
        }

        /// public propaty name  :  DADD_DMDDTLOUTLINERF
        /// <summary>請求明細摘要プロパティ</summary>
        /// <value>DmdDtlOutlineCodeRF = 0:印字しない 1:品番 2:定価</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   請求明細摘要プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DADD_DMDDTLOUTLINERF
        {
            get { return _dADD_DMDDTLOUTLINERF; }
            set { _dADD_DMDDTLOUTLINERF = value; }
        }

        /// public propaty name  :  DADD_SALESFTTITLERF
        /// <summary>売上伝票計タイトルプロパティ</summary>
        /// <value>明細請求書の売上伝票計用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上伝票計タイトルプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DADD_SALESFTTITLERF
        {
            get { return _dADD_SALESFTTITLERF; }
            set { _dADD_SALESFTTITLERF = value; }
        }

        /// public propaty name  :  DADD_SALESFTPRICERF
        /// <summary>売上伝票計金額プロパティ</summary>
        /// <value>明細請求書の売上伝票計用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上伝票計金額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 DADD_SALESFTPRICERF
        {
            get { return _dADD_SALESFTPRICERF; }
            set { _dADD_SALESFTPRICERF = value; }
        }

        /// public propaty name  :  DADD_SALESFTNOTE1RF
        /// <summary>売上伝票計備考１プロパティ</summary>
        /// <value>明細請求書の売上伝票計用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上伝票計備考１プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DADD_SALESFTNOTE1RF
        {
            get { return _dADD_SALESFTNOTE1RF; }
            set { _dADD_SALESFTNOTE1RF = value; }
        }

        /// public propaty name  :  DADD_SALESFTNOTE2RF
        /// <summary>売上伝票計備考２プロパティ</summary>
        /// <value>明細請求書の売上伝票計用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上伝票計備考２プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DADD_SALESFTNOTE2RF
        {
            get { return _dADD_SALESFTNOTE2RF; }
            set { _dADD_SALESFTNOTE2RF = value; }
        }

        /// public propaty name  :  DADD_SALESFTNOTE3RF
        /// <summary>売上伝票計備考３プロパティ</summary>
        /// <value>明細請求書の売上伝票計用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上伝票計備考３プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DADD_SALESFTNOTE3RF
        {
            get { return _dADD_SALESFTNOTE3RF; }
            set { _dADD_SALESFTNOTE3RF = value; }
        }

        /// public propaty name  :  DSAL_DETAILTITLE
        /// <summary>明細伝票タイトル(売上/返品)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   明細伝票タイトル(売上/返品)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DSAL_DETAILTITLE
        {
            get { return _dSAL_DETAILTITLE; }
            set { _dSAL_DETAILTITLE = value; }
        }

        /// public propaty name  :  DSAL_DETAILSUMTITLE
        /// <summary>売上集計タイトルプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上集計タイトルプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DSAL_DETAILSUMTITLE
        {
            get { return _dSAL_DETAILSUMTITLE; }
            set { _dSAL_DETAILSUMTITLE = value; }
        }

        /// public propaty name  :  DSAL_DETAILSUMPRICE
        /// <summary>売上集計金額プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上集計金額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 DSAL_DETAILSUMPRICE
        {
            get { return _dSAL_DETAILSUMPRICE; }
            set { _dSAL_DETAILSUMPRICE = value; }
        }

        /// public propaty name  :  DDEP_DETAILTITLE
        /// <summary>明細伝票タイトル(入金)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   明細伝票タイトル(入金)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DDEP_DETAILTITLE
        {
            get { return _dDEP_DETAILTITLE; }
            set { _dDEP_DETAILTITLE = value; }
        }

        /// public propaty name  :  DDEP_DETAILSUMTITLE
        /// <summary>入金集計タイトルプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金集計タイトルプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DDEP_DETAILSUMTITLE
        {
            get { return _dDEP_DETAILSUMTITLE; }
            set { _dDEP_DETAILSUMTITLE = value; }
        }

        /// public propaty name  :  DDEP_DETAILSUMPRICE
        /// <summary>入金集計金額プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金集計金額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 DDEP_DETAILSUMPRICE
        {
            get { return _dDEP_DETAILSUMPRICE; }
            set { _dDEP_DETAILSUMPRICE = value; }
        }

        /// public propaty name  :  SALESDETAILRF_SALESSLIPCDDTLRF
        /// <summary>売上伝票区分（明細）プロパティ</summary>
        /// <value>0:売上,1:返品,2:値引,3:注釈,4:小計</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上伝票区分（明細）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SALESDETAILRF_SALESSLIPCDDTLRF
        {
            get { return _sALESDETAILRF_SALESSLIPCDDTLRF; }
            set { _sALESDETAILRF_SALESSLIPCDDTLRF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_RESULTSADDUPSECCDRF
        /// <summary>実績計上拠点コードプロパティ</summary>
        /// <value>実績計上を行う企業内の拠点コード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   実績計上拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SALESSLIPRF_RESULTSADDUPSECCDRF
        {
            get { return _sALESSLIPRF_RESULTSADDUPSECCDRF; }
            set { _sALESSLIPRF_RESULTSADDUPSECCDRF = value; }
        }

        /// public propaty name  :  DEPSITMAINRF_INPUTDEPOSITSECCDRF
        /// <summary>入金入力拠点コードプロパティ</summary>
        /// <value>入金入力した拠点コード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金入力拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DEPSITMAINRF_INPUTDEPOSITSECCDRF
        {
            get { return _dEPSITMAINRF_INPUTDEPOSITSECCDRF; }
            set { _dEPSITMAINRF_INPUTDEPOSITSECCDRF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_GOODSNAMEKANARF
        /// <summary>商品名称カナプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品名称カナプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SALESDETAILRF_GOODSNAMEKANARF
        {
            get { return _sALESDETAILRF_GOODSNAMEKANARF; }
            set { _sALESDETAILRF_GOODSNAMEKANARF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_MAKERKANANAMERF
        /// <summary>メーカーカナ名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メーカーカナ名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SALESDETAILRF_MAKERKANANAMERF
        {
            get { return _sALESDETAILRF_MAKERKANANAMERF; }
            set { _sALESDETAILRF_MAKERKANANAMERF = value; }
        }

        /// public propaty name  :  ACCEPTODRCARRF_MODELHALFNAMERF
        /// <summary>車種半角名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車種半角名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ACCEPTODRCARRF_MODELHALFNAMERF
        {
            get { return _aCCEPTODRCARRF_MODELHALFNAMERF; }
            set { _aCCEPTODRCARRF_MODELHALFNAMERF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_PRTGOODSNORF
        /// <summary>印刷用品番プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   印刷用品番プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SALESDETAILRF_PRTGOODSNORF
        {
            get { return _sALESDETAILRF_PRTGOODSNORF; }
            set { _sALESDETAILRF_PRTGOODSNORF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_PRTMAKERCODERF
        /// <summary>印刷用メーカーコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   印刷用メーカーコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SALESDETAILRF_PRTMAKERCODERF
        {
            get { return _sALESDETAILRF_PRTMAKERCODERF; }
            set { _sALESDETAILRF_PRTMAKERCODERF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_PRTMAKERNAMERF
        /// <summary>印刷用メーカー名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   印刷用メーカー名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SALESDETAILRF_PRTMAKERNAMERF
        {
            get { return _sALESDETAILRF_PRTMAKERNAMERF; }
            set { _sALESDETAILRF_PRTMAKERNAMERF = value; }
        }

        /// public propaty name  :  DADD_PARTYSALESLIPNUMRF
        /// <summary>相手先伝票番号（ヘッダ用）プロパティ</summary>
        /// <value>得意先注文番号</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   相手先伝票番号（ヘッダ用）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DADD_PARTYSALESLIPNUMRF
        {
            get { return _dADD_PARTYSALESLIPNUMRF; }
            set { _dADD_PARTYSALESLIPNUMRF = value; }
        }
        /// public propaty name  :  SALESSLIPRF_CONSTAXLAYMETHODRF
        /// <summary>消費税転嫁方式プロパティ</summary>
        /// <value>0:伝票単位1:明細単位2:請求親 3:請求子 9:非課税</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   消費税転嫁方式プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SALESSLIPRF_CONSTAXLAYMETHODRF
        {
            get { return _sALESSLIPRF_CONSTAXLAYMETHODRF; }
            set { _sALESSLIPRF_CONSTAXLAYMETHODRF = value; }
        }


        /// <summary>
        /// 自由帳票(請求書)明細データワークコンストラクタ
        /// </summary>
        /// <returns>EBooksFrePBillDetailWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   EBooksFrePBillDetailWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public EBooksFrePBillDetailWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>EBooksFrePBillDetailWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   EBooksFrePBillDetailWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class EBooksFrePBillDetailWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   EBooksFrePBillDetailWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize( System.IO.BinaryWriter writer, object graph )
        {
            // TODO:  EBooksFrePBillDetailWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if ( writer == null )
                throw new ArgumentNullException();

            if ( graph != null && !(graph is EBooksFrePBillDetailWork || graph is ArrayList || graph is EBooksFrePBillDetailWork[]) )
                throw new ArgumentException( string.Format( "graphが{0}のインスタンスでありません", typeof( EBooksFrePBillDetailWork ).FullName ) );

            if ( graph != null && graph is EBooksFrePBillDetailWork )
            {
                Type t = graph.GetType();
                if ( !CustomFormatterServices.NeedCustomSerialization( t ) )
                    throw new ArgumentException( string.Format( "graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName ) );
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo( ", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.EBooksFrePBillDetailWork" );

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if ( graph is ArrayList )
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if ( graph is EBooksFrePBillDetailWork[] )
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((EBooksFrePBillDetailWork[])graph).Length;
            }
            else if ( graph is EBooksFrePBillDetailWork )
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //受注ステータス
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SALESSLIPRF_ACPTANODRSTATUSRF
            //売上伝票番号
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESSLIPRF_SALESSLIPNUMRF
            //拠点コード
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESSLIPRF_SECTIONCODERF
            //部門コード
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SALESSLIPRF_SUBSECTIONCODERF
            //赤伝区分
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SALESSLIPRF_DEBITNOTEDIVRF
            //売上伝票区分
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SALESSLIPRF_SALESSLIPCDRF
            //売上商品区分
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SALESSLIPRF_SALESGOODSCDRF
            //売掛区分
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SALESSLIPRF_ACCRECDIVCDRF
            //請求計上拠点コード
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESSLIPRF_DEMANDADDUPSECCDRF
            //売上日付
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SALESSLIPRF_SALESDATERF
            //計上日付
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SALESSLIPRF_ADDUPADATERF
            //入力担当者コード
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESSLIPRF_INPUTAGENCDRF
            //入力担当者名称
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESSLIPRF_INPUTAGENNMRF
            //売上入力者コード
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESSLIPRF_SALESINPUTCODERF
            //売上入力者名称
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESSLIPRF_SALESINPUTNAMERF
            //受付従業員コード
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESSLIPRF_FRONTEMPLOYEECDRF
            //受付従業員名称
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESSLIPRF_FRONTEMPLOYEENMRF
            //販売従業員コード
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESSLIPRF_SALESEMPLOYEECDRF
            //販売従業員名称
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESSLIPRF_SALESEMPLOYEENMRF
            //売上伝票合計（税込み）
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //SALESSLIPRF_SALESTOTALTAXINCRF
            //売上伝票合計（税抜き）
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //SALESSLIPRF_SALESTOTALTAXEXCRF
            //売上部品合計（税込み）
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //SALESSLIPRF_SALESPRTTOTALTAXINCRF
            //売上部品合計（税抜き）
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //SALESSLIPRF_SALESPRTTOTALTAXEXCRF
            //売上作業合計（税込み）
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //SALESSLIPRF_SALESWORKTOTALTAXINCRF
            //売上作業合計（税抜き）
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //SALESSLIPRF_SALESWORKTOTALTAXEXCRF
            //売上小計（税込み）
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //SALESSLIPRF_SALESSUBTOTALTAXINCRF
            //売上小計（税抜き）
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //SALESSLIPRF_SALESSUBTOTALTAXEXCRF
            //売上部品小計（税込み）
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //SALESSLIPRF_SALESPRTSUBTTLINCRF
            //売上部品小計（税抜き）
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //SALESSLIPRF_SALESPRTSUBTTLEXCRF
            //売上作業小計（税込み）
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //SALESSLIPRF_SALESWORKSUBTTLINCRF
            //売上作業小計（税抜き）
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //SALESSLIPRF_SALESWORKSUBTTLEXCRF
            //売上小計（税）
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //SALESSLIPRF_SALESSUBTOTALTAXRF
            //部品値引対象額合計（税抜き）
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //SALESSLIPRF_ITDEDPARTSDISOUTTAXRF
            //部品値引対象額合計（税込み）
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //SALESSLIPRF_ITDEDPARTSDISINTAXRF
            //作業値引対象額合計（税抜き）
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //SALESSLIPRF_ITDEDWORKDISOUTTAXRF
            //作業値引対象額合計（税込み）
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //SALESSLIPRF_ITDEDWORKDISINTAXRF
            //部品値引率
            serInfo.MemberInfo.Add( typeof( Double ) ); //SALESSLIPRF_PARTSDISCOUNTRATERF
            //工賃値引率
            serInfo.MemberInfo.Add( typeof( Double ) ); //SALESSLIPRF_RAVORDISCOUNTRATERF
            //原価金額計
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //SALESSLIPRF_TOTALCOSTRF
            //消費税税率
            serInfo.MemberInfo.Add( typeof( Double ) ); //SALESSLIPRF_CONSTAXRATERF
            //自動入金区分
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SALESSLIPRF_AUTODEPOSITCDRF
            //自動入金伝票番号
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SALESSLIPRF_AUTODEPOSITSLIPNORF
            //入金引当合計額
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //SALESSLIPRF_DEPOSITALLOWANCETTLRF
            //入金引当残高
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //SALESSLIPRF_DEPOSITALWCBLNCERF
            //請求先コード
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SALESSLIPRF_CLAIMCODERF
            //得意先コード
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SALESSLIPRF_CUSTOMERCODERF
            //得意先名称
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESSLIPRF_CUSTOMERNAMERF
            //得意先名称2
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESSLIPRF_CUSTOMERNAME2RF
            //得意先略称
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESSLIPRF_CUSTOMERSNMRF
            //敬称
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESSLIPRF_HONORIFICTITLERF
            //納品先コード
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SALESSLIPRF_ADDRESSEECODERF
            //納品先名称
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESSLIPRF_ADDRESSEENAMERF
            //納品先名称2
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESSLIPRF_ADDRESSEENAME2RF
            //相手先伝票番号
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESSLIPRF_PARTYSALESLIPNUMRF
            //伝票備考
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESSLIPRF_SLIPNOTERF
            //伝票備考２
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESSLIPRF_SLIPNOTE2RF
            //伝票備考３
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESSLIPRF_SLIPNOTE3RF
            //返品理由コード
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SALESSLIPRF_RETGOODSREASONDIVRF
            //返品理由
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESSLIPRF_RETGOODSREASONRF
            //明細行数
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SALESSLIPRF_DETAILROWCOUNTRF
            //ＵＯＥリマーク１
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESSLIPRF_UOEREMARK1RF
            //ＵＯＥリマーク２
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESSLIPRF_UOEREMARK2RF
            //納品区分
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SALESSLIPRF_DELIVEREDGOODSDIVRF
            //納品区分名称
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESSLIPRF_DELIVEREDGOODSDIVNMRF
            //在庫商品合計金額（税抜）
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //SALESSLIPRF_STOCKGOODSTTLTAXEXCRF
            //純正商品合計金額（税抜）
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //SALESSLIPRF_PUREGOODSTTLTAXEXCRF
            //脚注１
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESSLIPRF_FOOTNOTES1RF
            //脚注２
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESSLIPRF_FOOTNOTES2RF
            //拠点ガイド名称
            serInfo.MemberInfo.Add( typeof( string ) ); //SECDTL_SECTIONGUIDENMRF
            //拠点ガイド略称
            serInfo.MemberInfo.Add( typeof( string ) ); //SECDTL_SECTIONGUIDESNMRF
            //自社名称コード1
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SECDTL_COMPANYNAMECD1RF
            //売上部門名称
            serInfo.MemberInfo.Add( typeof( string ) ); //SUBSAL_SUBSECTIONNAMERF
            //受注番号
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SALESDETAILRF_ACCEPTANORDERNORF
            //売上行番号
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SALESDETAILRF_SALESROWNORF
            //納品完了予定日
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SALESDETAILRF_DELIGDSCMPLTDUEDATERF
            //商品属性
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SALESDETAILRF_GOODSKINDCODERF
            //商品メーカーコード
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SALESDETAILRF_GOODSMAKERCDRF
            //メーカー名称
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESDETAILRF_MAKERNAMERF
            //商品番号
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESDETAILRF_GOODSNORF
            //商品名称
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESDETAILRF_GOODSNAMERF
            //商品名略称
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESDETAILRF_GOODSSHORTNAMERF
            //商品大分類コード
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SALESDETAILRF_GOODSLGROUPRF
            //商品大分類名称
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESDETAILRF_GOODSLGROUPNAMERF
            //商品中分類コード
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SALESDETAILRF_GOODSMGROUPRF
            //商品中分類名称
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESDETAILRF_GOODSMGROUPNAMERF
            //BLグループコード
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SALESDETAILRF_BLGROUPCODERF
            //BLグループコード名称
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESDETAILRF_BLGROUPNAMERF
            //BL商品コード
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SALESDETAILRF_BLGOODSCODERF
            //BL商品コード名称（全角）
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESDETAILRF_BLGOODSFULLNAMERF
            //自社分類コード
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SALESDETAILRF_ENTERPRISEGANRECODERF
            //自社分類名称
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESDETAILRF_ENTERPRISEGANRENAMERF
            //倉庫コード
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESDETAILRF_WAREHOUSECODERF
            //倉庫名称
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESDETAILRF_WAREHOUSENAMERF
            //倉庫棚番
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESDETAILRF_WAREHOUSESHELFNORF
            //売上在庫取寄せ区分
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SALESDETAILRF_SALESORDERDIVCDRF
            //オープン価格区分
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SALESDETAILRF_OPENPRICEDIVRF
            //商品掛率ランク
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESDETAILRF_GOODSRATERANKRF
            //定価率
            serInfo.MemberInfo.Add( typeof( Double ) ); //SALESDETAILRF_LISTPRICERATERF
            //定価（税込，浮動）
            serInfo.MemberInfo.Add( typeof( Double ) ); //SALESDETAILRF_LISTPRICETAXINCFLRF
            //定価（税抜，浮動）
            serInfo.MemberInfo.Add( typeof( Double ) ); //SALESDETAILRF_LISTPRICETAXEXCFLRF
            //売価率
            serInfo.MemberInfo.Add( typeof( Double ) ); //SALESDETAILRF_SALESRATERF
            //売上単価（税込，浮動）
            serInfo.MemberInfo.Add( typeof( Double ) ); //SALESDETAILRF_SALESUNPRCTAXINCFLRF
            //売上単価（税抜，浮動）
            serInfo.MemberInfo.Add( typeof( Double ) ); //SALESDETAILRF_SALESUNPRCTAXEXCFLRF
            //原価率
            serInfo.MemberInfo.Add( typeof( Double ) ); //SALESDETAILRF_COSTRATERF
            //原価単価
            serInfo.MemberInfo.Add( typeof( Double ) ); //SALESDETAILRF_SALESUNITCOSTRF
            //BL商品コード（印刷）
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SALESDETAILRF_PRTBLGOODSCODERF
            //BL商品コード名称（印刷）
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESDETAILRF_PRTBLGOODSNAMERF
            //作業工数
            serInfo.MemberInfo.Add( typeof( Double ) ); //SALESDETAILRF_WORKMANHOURRF
            //出荷数
            serInfo.MemberInfo.Add( typeof( Double ) ); //SALESDETAILRF_SHIPMENTCNTRF
            //売上金額（税込み）
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //SALESDETAILRF_SALESMONEYTAXINCRF
            //売上金額（税抜き）
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //SALESDETAILRF_SALESMONEYTAXEXCRF
            //原価
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //SALESDETAILRF_COSTRF
            //課税区分
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SALESDETAILRF_TAXATIONDIVCDRF
            //相手先伝票番号（明細）
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESDETAILRF_PARTYSLIPNUMDTLRF
            //明細備考
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESDETAILRF_DTLNOTERF
            //仕入先コード
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SALESDETAILRF_SUPPLIERCDRF
            //仕入先略称
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESDETAILRF_SUPPLIERSNMRF
            //伝票メモ１
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESDETAILRF_SLIPMEMO1RF
            //伝票メモ２
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESDETAILRF_SLIPMEMO2RF
            //伝票メモ３
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESDETAILRF_SLIPMEMO3RF
            //社内メモ１
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESDETAILRF_INSIDEMEMO1RF
            //社内メモ２
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESDETAILRF_INSIDEMEMO2RF
            //社内メモ３
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESDETAILRF_INSIDEMEMO3RF
            //変更前定価
            serInfo.MemberInfo.Add( typeof( Double ) ); //SALESDETAILRF_BFLISTPRICERF
            //変更前売価
            serInfo.MemberInfo.Add( typeof( Double ) ); //SALESDETAILRF_BFSALESUNITPRICERF
            //変更前原価
            serInfo.MemberInfo.Add( typeof( Double ) ); //SALESDETAILRF_BFUNITCOSTRF
            //一式明細番号
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SALESDETAILRF_CMPLTSALESROWNORF
            //メーカーコード（一式）
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SALESDETAILRF_CMPLTGOODSMAKERCDRF
            //メーカー名称（一式）
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESDETAILRF_CMPLTMAKERNAMERF
            //商品名称（一式）
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESDETAILRF_CMPLTGOODSNAMERF
            //数量（一式）
            serInfo.MemberInfo.Add( typeof( Double ) ); //SALESDETAILRF_CMPLTSHIPMENTCNTRF
            //売上単価（一式）
            serInfo.MemberInfo.Add( typeof( Double ) ); //SALESDETAILRF_CMPLTSALESUNPRCFLRF
            //売上金額（一式）
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //SALESDETAILRF_CMPLTSALESMONEYRF
            //原価単価（一式）
            serInfo.MemberInfo.Add( typeof( Double ) ); //SALESDETAILRF_CMPLTSALESUNITCOSTRF
            //原価金額（一式）
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //SALESDETAILRF_CMPLTCOSTRF
            //相手先伝票番号（一式）
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESDETAILRF_CMPLTPARTYSALSLNUMRF
            //一式備考
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESDETAILRF_CMPLTNOTERF
            //車両管理番号
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //ACCEPTODRCARRF_CARMNGNORF
            //車輌管理コード
            serInfo.MemberInfo.Add( typeof( string ) ); //ACCEPTODRCARRF_CARMNGCODERF
            //陸運事務所番号
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //ACCEPTODRCARRF_NUMBERPLATE1CODERF
            //陸運事務局名称
            serInfo.MemberInfo.Add( typeof( string ) ); //ACCEPTODRCARRF_NUMBERPLATE1NAMERF
            //車両登録番号（種別）
            serInfo.MemberInfo.Add( typeof( string ) ); //ACCEPTODRCARRF_NUMBERPLATE2RF
            //車両登録番号（カナ）
            serInfo.MemberInfo.Add( typeof( string ) ); //ACCEPTODRCARRF_NUMBERPLATE3RF
            //車両登録番号（プレート番号）
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //ACCEPTODRCARRF_NUMBERPLATE4RF
            //初年度
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //ACCEPTODRCARRF_FIRSTENTRYDATERF
            //メーカーコード
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //ACCEPTODRCARRF_MAKERCODERF
            //メーカー全角名称
            serInfo.MemberInfo.Add( typeof( string ) ); //ACCEPTODRCARRF_MAKERFULLNAMERF
            //車種コード
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //ACCEPTODRCARRF_MODELCODERF
            //車種サブコード
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //ACCEPTODRCARRF_MODELSUBCODERF
            //車種全角名称
            serInfo.MemberInfo.Add( typeof( string ) ); //ACCEPTODRCARRF_MODELFULLNAMERF
            //排ガス記号
            serInfo.MemberInfo.Add( typeof( string ) ); //ACCEPTODRCARRF_EXHAUSTGASSIGNRF
            //シリーズ型式
            serInfo.MemberInfo.Add( typeof( string ) ); //ACCEPTODRCARRF_SERIESMODELRF
            //型式（類別記号）
            serInfo.MemberInfo.Add( typeof( string ) ); //ACCEPTODRCARRF_CATEGORYSIGNMODELRF
            //型式（フル型）
            serInfo.MemberInfo.Add( typeof( string ) ); //ACCEPTODRCARRF_FULLMODELRF
            //型式指定番号
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //ACCEPTODRCARRF_MODELDESIGNATIONNORF
            //類別番号
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //ACCEPTODRCARRF_CATEGORYNORF
            //車台型式
            serInfo.MemberInfo.Add( typeof( string ) ); //ACCEPTODRCARRF_FRAMEMODELRF
            //車台番号
            serInfo.MemberInfo.Add( typeof( string ) ); //ACCEPTODRCARRF_FRAMENORF
            //車台番号（検索用）
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //ACCEPTODRCARRF_SEARCHFRAMENORF
            //エンジン型式名称
            serInfo.MemberInfo.Add( typeof( string ) ); //ACCEPTODRCARRF_ENGINEMODELNMRF
            //関連型式
            serInfo.MemberInfo.Add( typeof( string ) ); //ACCEPTODRCARRF_RELEVANCEMODELRF
            //サブ車名コード
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //ACCEPTODRCARRF_SUBCARNMCDRF
            //型式グレード略称
            serInfo.MemberInfo.Add( typeof( string ) ); //ACCEPTODRCARRF_MODELGRADESNAMERF
            //カラーコード
            serInfo.MemberInfo.Add( typeof( string ) ); //ACCEPTODRCARRF_COLORCODERF
            //カラー名称1
            serInfo.MemberInfo.Add( typeof( string ) ); //ACCEPTODRCARRF_COLORNAME1RF
            //トリムコード
            serInfo.MemberInfo.Add( typeof( string ) ); //ACCEPTODRCARRF_TRIMCODERF
            //トリム名称
            serInfo.MemberInfo.Add( typeof( string ) ); //ACCEPTODRCARRF_TRIMNAMERF
            //車両走行距離
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //ACCEPTODRCARRF_MILEAGERF
            //受注ステータス
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //DEPSITMAINRF_ACPTANODRSTATUSRF
            //入金伝票番号
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //DEPSITMAINRF_DEPOSITSLIPNORF
            //売上伝票番号
            serInfo.MemberInfo.Add( typeof( string ) ); //DEPSITMAINRF_SALESSLIPNUMRF
            //計上拠点コード
            serInfo.MemberInfo.Add( typeof( string ) ); //DEPSITMAINRF_ADDUPSECCODERF
            //部門コード
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //DEPSITMAINRF_SUBSECTIONCODERF
            //入金日付
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //DEPSITMAINRF_DEPOSITDATERF
            //計上日付
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //DEPSITMAINRF_ADDUPADATERF
            //入金金額
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //DEPSITMAINRF_DEPOSITRF
            //手数料入金額
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //DEPSITMAINRF_FEEDEPOSITRF
            //値引入金額
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //DEPSITMAINRF_DISCOUNTDEPOSITRF
            //自動入金区分
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //DEPSITMAINRF_AUTODEPOSITCDRF
            //預り金区分
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //DEPSITMAINRF_DEPOSITCDRF
            //手形振出日
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //DEPSITMAINRF_DRAFTDRAWINGDATERF
            //手形種類
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //DEPSITMAINRF_DRAFTKINDRF
            //手形種類名称
            serInfo.MemberInfo.Add( typeof( string ) ); //DEPSITMAINRF_DRAFTKINDNAMERF
            //手形区分名称
            serInfo.MemberInfo.Add( typeof( string ) ); //DEPSITMAINRF_DRAFTDIVIDENAMERF
            //手形番号
            serInfo.MemberInfo.Add( typeof( string ) ); //DEPSITMAINRF_DRAFTNORF
            //得意先コード
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //DEPSITMAINRF_CUSTOMERCODERF
            //請求先コード
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //DEPSITMAINRF_CLAIMCODERF
            //伝票摘要
            serInfo.MemberInfo.Add( typeof( string ) ); //DEPSITMAINRF_OUTLINERF
            //入金請求部門名称
            serInfo.MemberInfo.Add( typeof( string ) ); //SUBDEP_SUBSECTIONNAMERF
            //入金伝票番号
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //DEPSITDTLRF_DEPOSITSLIPNORF
            //入金行番号
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //DEPSITDTLRF_DEPOSITROWNORF
            //金種コード
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //DEPSITDTLRF_MONEYKINDCODERF
            //金種名称
            serInfo.MemberInfo.Add( typeof( string ) ); //DEPSITDTLRF_MONEYKINDNAMERF
            //金種区分
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //DEPSITDTLRF_MONEYKINDDIVRF
            //入金金額
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //DEPSITDTLRF_DEPOSITRF
            //有効期限
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //DEPSITDTLRF_VALIDITYTERMRF
            //受注ステータス名称
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //DADD_ACPTANODRSTATUSRF
            //赤伝区分名称
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //DADD_DEBITNOTEDIVRF
            //売上伝票区分名称
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //DADD_SALESSLIPCDRF
            //売上日付
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //DADD_SALESDATERF
            //売上日付西暦年
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //DADD_SALESDATEFYRF
            //売上日付西暦年略
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //DADD_SALESDATEFSRF
            //売上日付和暦年
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //DADD_SALESDATEFWRF
            //売上日付月
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //DADD_SALESDATEFMRF
            //売上日付日
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //DADD_SALESDATEFDRF
            //売上日付元号
            serInfo.MemberInfo.Add( typeof( string ) ); //DADD_SALESDATEFGRF
            //売上日付略号
            serInfo.MemberInfo.Add( typeof( string ) ); //DADD_SALESDATEFRRF
            //売上日付リテラル(/)
            serInfo.MemberInfo.Add( typeof( string ) ); //DADD_SALESDATEFLSRF
            //売上日付リテラル(.)
            serInfo.MemberInfo.Add( typeof( string ) ); //DADD_SALESDATEFLPRF
            //売上日付リテラル(年)
            serInfo.MemberInfo.Add( typeof( string ) ); //DADD_SALESDATEFLYRF
            //売上日付リテラル(月)
            serInfo.MemberInfo.Add( typeof( string ) ); //DADD_SALESDATEFLMRF
            //売上日付リテラル(日)
            serInfo.MemberInfo.Add( typeof( string ) ); //DADD_SALESDATEFLDRF
            //取寄商品合計金額（税抜）
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //DADD_STOCKGOODSTTLTAXEXCRF
            //優良商品合計金額（税抜）
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //DADD_PUREGOODSTTLTAXEXCRF
            //商品属性名称
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //DADD_GOODSKINDCODERF
            //売上在庫取寄せ区分名称
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //DADD_SALESORDERDIVCDRF
            //オープン価格区分名称
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //DADD_OPENPRICEDIVRF
            //課税区分名称
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //DADD_TAXATIONDIVCDRF
            //初年度西暦年
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //DADD_FIRSTENTRYDATEFYRF
            //初年度西暦年略
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //DADD_FIRSTENTRYDATEFSRF
            //初年度和暦年
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //DADD_FIRSTENTRYDATEFWRF
            //初年度月
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //DADD_FIRSTENTRYDATEFMRF
            //初年度元号
            serInfo.MemberInfo.Add( typeof( string ) ); //DADD_FIRSTENTRYDATEFGRF
            //初年度略号
            serInfo.MemberInfo.Add( typeof( string ) ); //DADD_FIRSTENTRYDATEFRRF
            //初年度リテラル(/)
            serInfo.MemberInfo.Add( typeof( string ) ); //DADD_FIRSTENTRYDATEFLSRF
            //初年度リテラル(.)
            serInfo.MemberInfo.Add( typeof( string ) ); //DADD_FIRSTENTRYDATEFLPRF
            //初年度リテラル(年)
            serInfo.MemberInfo.Add( typeof( string ) ); //DADD_FIRSTENTRYDATEFLYRF
            //初年度リテラル(月)
            serInfo.MemberInfo.Add( typeof( string ) ); //DADD_FIRSTENTRYDATEFLMRF
            //入金日付西暦年
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //DADD_DEPOSITDATEFYRF
            //入金日付西暦年略
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //DADD_DEPOSITDATEFSRF
            //入金日付和暦年
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //DADD_DEPOSITDATEFWRF
            //入金日付月
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //DADD_DEPOSITDATEFMRF
            //入金日付日
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //DADD_DEPOSITDATEFDRF
            //入金日付元号
            serInfo.MemberInfo.Add( typeof( string ) ); //DADD_DEPOSITDATEFGRF
            //入金日付略号
            serInfo.MemberInfo.Add( typeof( string ) ); //DADD_DEPOSITDATEFRRF
            //入金日付リテラル(/)
            serInfo.MemberInfo.Add( typeof( string ) ); //DADD_DEPOSITDATEFLSRF
            //入金日付リテラル(.)
            serInfo.MemberInfo.Add( typeof( string ) ); //DADD_DEPOSITDATEFLPRF
            //入金日付リテラル(年)
            serInfo.MemberInfo.Add( typeof( string ) ); //DADD_DEPOSITDATEFLYRF
            //入金日付リテラル(月)
            serInfo.MemberInfo.Add( typeof( string ) ); //DADD_DEPOSITDATEFLMRF
            //入金日付リテラル(日)
            serInfo.MemberInfo.Add( typeof( string ) ); //DADD_DEPOSITDATEFLDRF
            //自動入金区分名称
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //DADD_AUTODEPOSITCDRF
            //預り金区分名称
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //DADD_DEPOSITCDRF
            //手形振出日西暦年
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //DADD_DRAFTDRAWINGDATEFYRF
            //手形振出日西暦年略
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //DADD_DRAFTDRAWINGDATEFSRF
            //手形振出日和暦年
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //DADD_DRAFTDRAWINGDATEFWRF
            //手形振出日月
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //DADD_DRAFTDRAWINGDATEFMRF
            //手形振出日日
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //DADD_DRAFTDRAWINGDATEFDRF
            //手形振出日元号
            serInfo.MemberInfo.Add( typeof( string ) ); //DADD_DRAFTDRAWINGDATEFGRF
            //手形振出日略号
            serInfo.MemberInfo.Add( typeof( string ) ); //DADD_DRAFTDRAWINGDATEFRRF
            //手形振出日リテラル(/)
            serInfo.MemberInfo.Add( typeof( string ) ); //DADD_DRAFTDRAWINGDATEFLSRF
            //手形振出日リテラル(.)
            serInfo.MemberInfo.Add( typeof( string ) ); //DADD_DRAFTDRAWINGDATEFLPRF
            //手形振出日リテラル(年)
            serInfo.MemberInfo.Add( typeof( string ) ); //DADD_DRAFTDRAWINGDATEFLYRF
            //手形振出日リテラル(月)
            serInfo.MemberInfo.Add( typeof( string ) ); //DADD_DRAFTDRAWINGDATEFLMRF
            //手形振出日リテラル(日)
            serInfo.MemberInfo.Add( typeof( string ) ); //DADD_DRAFTDRAWINGDATEFLDRF
            //手形支払期日西暦年
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //DADD_DRAFTPAYTIMELIMITFYRF
            //手形支払期日西暦年略
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //DADD_DRAFTPAYTIMELIMITFSRF
            //手形支払期日和暦年
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //DADD_DRAFTPAYTIMELIMITFWRF
            //手形支払期日月
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //DADD_DRAFTPAYTIMELIMITFMRF
            //手形支払期日日
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //DADD_DRAFTPAYTIMELIMITFDRF
            //手形支払期日元号
            serInfo.MemberInfo.Add( typeof( string ) ); //DADD_DRAFTPAYTIMELIMITFGRF
            //手形支払期日略号
            serInfo.MemberInfo.Add( typeof( string ) ); //DADD_DRAFTPAYTIMELIMITFRRF
            //手形支払期日リテラル(/)
            serInfo.MemberInfo.Add( typeof( string ) ); //DADD_DRAFTPAYTIMELIMITFLSRF
            //手形支払期日リテラル(.)
            serInfo.MemberInfo.Add( typeof( string ) ); //DADD_DRAFTPAYTIMELIMITFLPRF
            //手形支払期日リテラル(年)
            serInfo.MemberInfo.Add( typeof( string ) ); //DADD_DRAFTPAYTIMELIMITFLYRF
            //手形支払期日リテラル(月)
            serInfo.MemberInfo.Add( typeof( string ) ); //DADD_DRAFTPAYTIMELIMITFLMRF
            //手形支払期日リテラル(日)
            serInfo.MemberInfo.Add( typeof( string ) ); //DADD_DRAFTPAYTIMELIMITFLDRF
            //有効期限西暦年
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //DADD_VALIDITYTERMFYRF
            //有効期限西暦年略
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //DADD_VALIDITYTERMFSRF
            //有効期限和暦年
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //DADD_VALIDITYTERMFWRF
            //有効期限月
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //DADD_VALIDITYTERMFMRF
            //有効期限日
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //DADD_VALIDITYTERMFDRF
            //有効期限元号
            serInfo.MemberInfo.Add( typeof( string ) ); //DADD_VALIDITYTERMFGRF
            //有効期限略号
            serInfo.MemberInfo.Add( typeof( string ) ); //DADD_VALIDITYTERMFRRF
            //有効期限リテラル(/)
            serInfo.MemberInfo.Add( typeof( string ) ); //DADD_VALIDITYTERMFLSRF
            //有効期限リテラル(.)
            serInfo.MemberInfo.Add( typeof( string ) ); //DADD_VALIDITYTERMFLPRF
            //有効期限リテラル(年)
            serInfo.MemberInfo.Add( typeof( string ) ); //DADD_VALIDITYTERMFLYRF
            //有効期限リテラル(月)
            serInfo.MemberInfo.Add( typeof( string ) ); //DADD_VALIDITYTERMFLMRF
            //有効期限リテラル(日)
            serInfo.MemberInfo.Add( typeof( string ) ); //DADD_VALIDITYTERMFLDRF
            //請求明細摘要
            serInfo.MemberInfo.Add( typeof( string ) ); //DADD_DMDDTLOUTLINERF
            //売上伝票計タイトル
            serInfo.MemberInfo.Add( typeof( string ) ); //DADD_SALESFTTITLERF
            //売上伝票計金額
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //DADD_SALESFTPRICERF
            //売上伝票計備考１
            serInfo.MemberInfo.Add( typeof( string ) ); //DADD_SALESFTNOTE1RF
            //売上伝票計備考２
            serInfo.MemberInfo.Add( typeof( string ) ); //DADD_SALESFTNOTE2RF
            //売上伝票計備考３
            serInfo.MemberInfo.Add( typeof( string ) ); //DADD_SALESFTNOTE3RF
            //明細伝票タイトル(売上/返品)
            serInfo.MemberInfo.Add( typeof( string ) ); //DSAL_DETAILTITLE
            //売上集計タイトル
            serInfo.MemberInfo.Add( typeof( string ) ); //DSAL_DETAILSUMTITLE
            //売上集計金額
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //DSAL_DETAILSUMPRICE
            //明細伝票タイトル(入金)
            serInfo.MemberInfo.Add( typeof( string ) ); //DDEP_DETAILTITLE
            //入金集計タイトル
            serInfo.MemberInfo.Add( typeof( string ) ); //DDEP_DETAILSUMTITLE
            //入金集計金額
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //DDEP_DETAILSUMPRICE
            //売上伝票区分（明細）
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SALESDETAILRF_SALESSLIPCDDTLRF
            //実績計上拠点コード
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESSLIPRF_RESULTSADDUPSECCDRF
            //入金入力拠点コード
            serInfo.MemberInfo.Add( typeof( string ) ); //DEPSITMAINRF_INPUTDEPOSITSECCDRF
            //商品名称カナ
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESDETAILRF_GOODSNAMEKANARF
            //メーカーカナ名称
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESDETAILRF_MAKERKANANAMERF
            //車種半角名称
            serInfo.MemberInfo.Add( typeof( string ) ); //ACCEPTODRCARRF_MODELHALFNAMERF
            //印刷用品番
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESDETAILRF_PRTGOODSNORF
            //印刷用メーカーコード
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SALESDETAILRF_PRTMAKERCODERF
            //印刷用メーカー名称
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESDETAILRF_PRTMAKERNAMERF
            //相手先伝票番号（ヘッダ用）
            serInfo.MemberInfo.Add( typeof( string ) ); //DADD_PARTYSALESLIPNUMRF
            //消費税転嫁方式
            serInfo.MemberInfo.Add(typeof(Int32)); //SALESSLIPRF_CONSTAXLAYMETHODRF


            serInfo.Serialize( writer, serInfo );
            if ( graph is EBooksFrePBillDetailWork )
            {
                EBooksFrePBillDetailWork temp = (EBooksFrePBillDetailWork)graph;

                SetEBooksFrePBillDetailWork( writer, temp );
            }
            else
            {
                ArrayList lst = null;
                if ( graph is EBooksFrePBillDetailWork[] )
                {
                    lst = new ArrayList();
                    lst.AddRange( (EBooksFrePBillDetailWork[])graph );
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach ( EBooksFrePBillDetailWork temp in lst )
                {
                    SetEBooksFrePBillDetailWork( writer, temp );
                }

            }


        }


        /// <summary>
        /// EBooksFrePBillDetailWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 301;

        /// <summary>
        ///  EBooksFrePBillDetailWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   EBooksFrePBillDetailWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetEBooksFrePBillDetailWork( System.IO.BinaryWriter writer, EBooksFrePBillDetailWork temp )
        {
            //受注ステータス
            writer.Write( temp.SALESSLIPRF_ACPTANODRSTATUSRF );
            //売上伝票番号
            writer.Write( temp.SALESSLIPRF_SALESSLIPNUMRF );
            //拠点コード
            writer.Write( temp.SALESSLIPRF_SECTIONCODERF );
            //部門コード
            writer.Write( temp.SALESSLIPRF_SUBSECTIONCODERF );
            //赤伝区分
            writer.Write( temp.SALESSLIPRF_DEBITNOTEDIVRF );
            //売上伝票区分
            writer.Write( temp.SALESSLIPRF_SALESSLIPCDRF );
            //売上商品区分
            writer.Write( temp.SALESSLIPRF_SALESGOODSCDRF );
            //売掛区分
            writer.Write( temp.SALESSLIPRF_ACCRECDIVCDRF );
            //請求計上拠点コード
            writer.Write( temp.SALESSLIPRF_DEMANDADDUPSECCDRF );
            //売上日付
            writer.Write( temp.SALESSLIPRF_SALESDATERF );
            //計上日付
            writer.Write( temp.SALESSLIPRF_ADDUPADATERF );
            //入力担当者コード
            writer.Write( temp.SALESSLIPRF_INPUTAGENCDRF );
            //入力担当者名称
            writer.Write( temp.SALESSLIPRF_INPUTAGENNMRF );
            //売上入力者コード
            writer.Write( temp.SALESSLIPRF_SALESINPUTCODERF );
            //売上入力者名称
            writer.Write( temp.SALESSLIPRF_SALESINPUTNAMERF );
            //受付従業員コード
            writer.Write( temp.SALESSLIPRF_FRONTEMPLOYEECDRF );
            //受付従業員名称
            writer.Write( temp.SALESSLIPRF_FRONTEMPLOYEENMRF );
            //販売従業員コード
            writer.Write( temp.SALESSLIPRF_SALESEMPLOYEECDRF );
            //販売従業員名称
            writer.Write( temp.SALESSLIPRF_SALESEMPLOYEENMRF );
            //売上伝票合計（税込み）
            writer.Write( temp.SALESSLIPRF_SALESTOTALTAXINCRF );
            //売上伝票合計（税抜き）
            writer.Write( temp.SALESSLIPRF_SALESTOTALTAXEXCRF );
            //売上部品合計（税込み）
            writer.Write( temp.SALESSLIPRF_SALESPRTTOTALTAXINCRF );
            //売上部品合計（税抜き）
            writer.Write( temp.SALESSLIPRF_SALESPRTTOTALTAXEXCRF );
            //売上作業合計（税込み）
            writer.Write( temp.SALESSLIPRF_SALESWORKTOTALTAXINCRF );
            //売上作業合計（税抜き）
            writer.Write( temp.SALESSLIPRF_SALESWORKTOTALTAXEXCRF );
            //売上小計（税込み）
            writer.Write( temp.SALESSLIPRF_SALESSUBTOTALTAXINCRF );
            //売上小計（税抜き）
            writer.Write( temp.SALESSLIPRF_SALESSUBTOTALTAXEXCRF );
            //売上部品小計（税込み）
            writer.Write( temp.SALESSLIPRF_SALESPRTSUBTTLINCRF );
            //売上部品小計（税抜き）
            writer.Write( temp.SALESSLIPRF_SALESPRTSUBTTLEXCRF );
            //売上作業小計（税込み）
            writer.Write( temp.SALESSLIPRF_SALESWORKSUBTTLINCRF );
            //売上作業小計（税抜き）
            writer.Write( temp.SALESSLIPRF_SALESWORKSUBTTLEXCRF );
            //売上小計（税）
            writer.Write( temp.SALESSLIPRF_SALESSUBTOTALTAXRF );
            //部品値引対象額合計（税抜き）
            writer.Write( temp.SALESSLIPRF_ITDEDPARTSDISOUTTAXRF );
            //部品値引対象額合計（税込み）
            writer.Write( temp.SALESSLIPRF_ITDEDPARTSDISINTAXRF );
            //作業値引対象額合計（税抜き）
            writer.Write( temp.SALESSLIPRF_ITDEDWORKDISOUTTAXRF );
            //作業値引対象額合計（税込み）
            writer.Write( temp.SALESSLIPRF_ITDEDWORKDISINTAXRF );
            //部品値引率
            writer.Write( temp.SALESSLIPRF_PARTSDISCOUNTRATERF );
            //工賃値引率
            writer.Write( temp.SALESSLIPRF_RAVORDISCOUNTRATERF );
            //原価金額計
            writer.Write( temp.SALESSLIPRF_TOTALCOSTRF );
            //消費税税率
            writer.Write( temp.SALESSLIPRF_CONSTAXRATERF );
            //自動入金区分
            writer.Write( temp.SALESSLIPRF_AUTODEPOSITCDRF );
            //自動入金伝票番号
            writer.Write( temp.SALESSLIPRF_AUTODEPOSITSLIPNORF );
            //入金引当合計額
            writer.Write( temp.SALESSLIPRF_DEPOSITALLOWANCETTLRF );
            //入金引当残高
            writer.Write( temp.SALESSLIPRF_DEPOSITALWCBLNCERF );
            //請求先コード
            writer.Write( temp.SALESSLIPRF_CLAIMCODERF );
            //得意先コード
            writer.Write( temp.SALESSLIPRF_CUSTOMERCODERF );
            //得意先名称
            writer.Write( temp.SALESSLIPRF_CUSTOMERNAMERF );
            //得意先名称2
            writer.Write( temp.SALESSLIPRF_CUSTOMERNAME2RF );
            //得意先略称
            writer.Write( temp.SALESSLIPRF_CUSTOMERSNMRF );
            //敬称
            writer.Write( temp.SALESSLIPRF_HONORIFICTITLERF );
            //納品先コード
            writer.Write( temp.SALESSLIPRF_ADDRESSEECODERF );
            //納品先名称
            writer.Write( temp.SALESSLIPRF_ADDRESSEENAMERF );
            //納品先名称2
            writer.Write( temp.SALESSLIPRF_ADDRESSEENAME2RF );
            //相手先伝票番号
            writer.Write( temp.SALESSLIPRF_PARTYSALESLIPNUMRF );
            //伝票備考
            writer.Write( temp.SALESSLIPRF_SLIPNOTERF );
            //伝票備考２
            writer.Write( temp.SALESSLIPRF_SLIPNOTE2RF );
            //伝票備考３
            writer.Write( temp.SALESSLIPRF_SLIPNOTE3RF );
            //返品理由コード
            writer.Write( temp.SALESSLIPRF_RETGOODSREASONDIVRF );
            //返品理由
            writer.Write( temp.SALESSLIPRF_RETGOODSREASONRF );
            //明細行数
            writer.Write( temp.SALESSLIPRF_DETAILROWCOUNTRF );
            //ＵＯＥリマーク１
            writer.Write( temp.SALESSLIPRF_UOEREMARK1RF );
            //ＵＯＥリマーク２
            writer.Write( temp.SALESSLIPRF_UOEREMARK2RF );
            //納品区分
            writer.Write( temp.SALESSLIPRF_DELIVEREDGOODSDIVRF );
            //納品区分名称
            writer.Write( temp.SALESSLIPRF_DELIVEREDGOODSDIVNMRF );
            //在庫商品合計金額（税抜）
            writer.Write( temp.SALESSLIPRF_STOCKGOODSTTLTAXEXCRF );
            //純正商品合計金額（税抜）
            writer.Write( temp.SALESSLIPRF_PUREGOODSTTLTAXEXCRF );
            //脚注１
            writer.Write( temp.SALESSLIPRF_FOOTNOTES1RF );
            //脚注２
            writer.Write( temp.SALESSLIPRF_FOOTNOTES2RF );
            //拠点ガイド名称
            writer.Write( temp.SECDTL_SECTIONGUIDENMRF );
            //拠点ガイド略称
            writer.Write( temp.SECDTL_SECTIONGUIDESNMRF );
            //自社名称コード1
            writer.Write( temp.SECDTL_COMPANYNAMECD1RF );
            //売上部門名称
            writer.Write( temp.SUBSAL_SUBSECTIONNAMERF );
            //受注番号
            writer.Write( temp.SALESDETAILRF_ACCEPTANORDERNORF );
            //売上行番号
            writer.Write( temp.SALESDETAILRF_SALESROWNORF );
            //納品完了予定日
            writer.Write( temp.SALESDETAILRF_DELIGDSCMPLTDUEDATERF );
            //商品属性
            writer.Write( temp.SALESDETAILRF_GOODSKINDCODERF );
            //商品メーカーコード
            writer.Write( temp.SALESDETAILRF_GOODSMAKERCDRF );
            //メーカー名称
            writer.Write( temp.SALESDETAILRF_MAKERNAMERF );
            //商品番号
            writer.Write( temp.SALESDETAILRF_GOODSNORF );
            //商品名称
            writer.Write( temp.SALESDETAILRF_GOODSNAMERF );
            //商品名略称
            writer.Write( temp.SALESDETAILRF_GOODSSHORTNAMERF );
            //商品大分類コード
            writer.Write( temp.SALESDETAILRF_GOODSLGROUPRF );
            //商品大分類名称
            writer.Write( temp.SALESDETAILRF_GOODSLGROUPNAMERF );
            //商品中分類コード
            writer.Write( temp.SALESDETAILRF_GOODSMGROUPRF );
            //商品中分類名称
            writer.Write( temp.SALESDETAILRF_GOODSMGROUPNAMERF );
            //BLグループコード
            writer.Write( temp.SALESDETAILRF_BLGROUPCODERF );
            //BLグループコード名称
            writer.Write( temp.SALESDETAILRF_BLGROUPNAMERF );
            //BL商品コード
            writer.Write( temp.SALESDETAILRF_BLGOODSCODERF );
            //BL商品コード名称（全角）
            writer.Write( temp.SALESDETAILRF_BLGOODSFULLNAMERF );
            //自社分類コード
            writer.Write( temp.SALESDETAILRF_ENTERPRISEGANRECODERF );
            //自社分類名称
            writer.Write( temp.SALESDETAILRF_ENTERPRISEGANRENAMERF );
            //倉庫コード
            writer.Write( temp.SALESDETAILRF_WAREHOUSECODERF );
            //倉庫名称
            writer.Write( temp.SALESDETAILRF_WAREHOUSENAMERF );
            //倉庫棚番
            writer.Write( temp.SALESDETAILRF_WAREHOUSESHELFNORF );
            //売上在庫取寄せ区分
            writer.Write( temp.SALESDETAILRF_SALESORDERDIVCDRF );
            //オープン価格区分
            writer.Write( temp.SALESDETAILRF_OPENPRICEDIVRF );
            //商品掛率ランク
            writer.Write( temp.SALESDETAILRF_GOODSRATERANKRF );
            //定価率
            writer.Write( temp.SALESDETAILRF_LISTPRICERATERF );
            //定価（税込，浮動）
            writer.Write( temp.SALESDETAILRF_LISTPRICETAXINCFLRF );
            //定価（税抜，浮動）
            writer.Write( temp.SALESDETAILRF_LISTPRICETAXEXCFLRF );
            //売価率
            writer.Write( temp.SALESDETAILRF_SALESRATERF );
            //売上単価（税込，浮動）
            writer.Write( temp.SALESDETAILRF_SALESUNPRCTAXINCFLRF );
            //売上単価（税抜，浮動）
            writer.Write( temp.SALESDETAILRF_SALESUNPRCTAXEXCFLRF );
            //原価率
            writer.Write( temp.SALESDETAILRF_COSTRATERF );
            //原価単価
            writer.Write( temp.SALESDETAILRF_SALESUNITCOSTRF );
            //BL商品コード（印刷）
            writer.Write( temp.SALESDETAILRF_PRTBLGOODSCODERF );
            //BL商品コード名称（印刷）
            writer.Write( temp.SALESDETAILRF_PRTBLGOODSNAMERF );
            //作業工数
            writer.Write( temp.SALESDETAILRF_WORKMANHOURRF );
            //出荷数
            writer.Write( temp.SALESDETAILRF_SHIPMENTCNTRF );
            //売上金額（税込み）
            writer.Write( temp.SALESDETAILRF_SALESMONEYTAXINCRF );
            //売上金額（税抜き）
            writer.Write( temp.SALESDETAILRF_SALESMONEYTAXEXCRF );
            //原価
            writer.Write( temp.SALESDETAILRF_COSTRF );
            //課税区分
            writer.Write( temp.SALESDETAILRF_TAXATIONDIVCDRF );
            //相手先伝票番号（明細）
            writer.Write( temp.SALESDETAILRF_PARTYSLIPNUMDTLRF );
            //明細備考
            writer.Write( temp.SALESDETAILRF_DTLNOTERF );
            //仕入先コード
            writer.Write( temp.SALESDETAILRF_SUPPLIERCDRF );
            //仕入先略称
            writer.Write( temp.SALESDETAILRF_SUPPLIERSNMRF );
            //伝票メモ１
            writer.Write( temp.SALESDETAILRF_SLIPMEMO1RF );
            //伝票メモ２
            writer.Write( temp.SALESDETAILRF_SLIPMEMO2RF );
            //伝票メモ３
            writer.Write( temp.SALESDETAILRF_SLIPMEMO3RF );
            //社内メモ１
            writer.Write( temp.SALESDETAILRF_INSIDEMEMO1RF );
            //社内メモ２
            writer.Write( temp.SALESDETAILRF_INSIDEMEMO2RF );
            //社内メモ３
            writer.Write( temp.SALESDETAILRF_INSIDEMEMO3RF );
            //変更前定価
            writer.Write( temp.SALESDETAILRF_BFLISTPRICERF );
            //変更前売価
            writer.Write( temp.SALESDETAILRF_BFSALESUNITPRICERF );
            //変更前原価
            writer.Write( temp.SALESDETAILRF_BFUNITCOSTRF );
            //一式明細番号
            writer.Write( temp.SALESDETAILRF_CMPLTSALESROWNORF );
            //メーカーコード（一式）
            writer.Write( temp.SALESDETAILRF_CMPLTGOODSMAKERCDRF );
            //メーカー名称（一式）
            writer.Write( temp.SALESDETAILRF_CMPLTMAKERNAMERF );
            //商品名称（一式）
            writer.Write( temp.SALESDETAILRF_CMPLTGOODSNAMERF );
            //数量（一式）
            writer.Write( temp.SALESDETAILRF_CMPLTSHIPMENTCNTRF );
            //売上単価（一式）
            writer.Write( temp.SALESDETAILRF_CMPLTSALESUNPRCFLRF );
            //売上金額（一式）
            writer.Write( temp.SALESDETAILRF_CMPLTSALESMONEYRF );
            //原価単価（一式）
            writer.Write( temp.SALESDETAILRF_CMPLTSALESUNITCOSTRF );
            //原価金額（一式）
            writer.Write( temp.SALESDETAILRF_CMPLTCOSTRF );
            //相手先伝票番号（一式）
            writer.Write( temp.SALESDETAILRF_CMPLTPARTYSALSLNUMRF );
            //一式備考
            writer.Write( temp.SALESDETAILRF_CMPLTNOTERF );
            //車両管理番号
            writer.Write( temp.ACCEPTODRCARRF_CARMNGNORF );
            //車輌管理コード
            writer.Write( temp.ACCEPTODRCARRF_CARMNGCODERF );
            //陸運事務所番号
            writer.Write( temp.ACCEPTODRCARRF_NUMBERPLATE1CODERF );
            //陸運事務局名称
            writer.Write( temp.ACCEPTODRCARRF_NUMBERPLATE1NAMERF );
            //車両登録番号（種別）
            writer.Write( temp.ACCEPTODRCARRF_NUMBERPLATE2RF );
            //車両登録番号（カナ）
            writer.Write( temp.ACCEPTODRCARRF_NUMBERPLATE3RF );
            //車両登録番号（プレート番号）
            writer.Write( temp.ACCEPTODRCARRF_NUMBERPLATE4RF );
            //初年度
            writer.Write( temp.ACCEPTODRCARRF_FIRSTENTRYDATERF );
            //メーカーコード
            writer.Write( temp.ACCEPTODRCARRF_MAKERCODERF );
            //メーカー全角名称
            writer.Write( temp.ACCEPTODRCARRF_MAKERFULLNAMERF );
            //車種コード
            writer.Write( temp.ACCEPTODRCARRF_MODELCODERF );
            //車種サブコード
            writer.Write( temp.ACCEPTODRCARRF_MODELSUBCODERF );
            //車種全角名称
            writer.Write( temp.ACCEPTODRCARRF_MODELFULLNAMERF );
            //排ガス記号
            writer.Write( temp.ACCEPTODRCARRF_EXHAUSTGASSIGNRF );
            //シリーズ型式
            writer.Write( temp.ACCEPTODRCARRF_SERIESMODELRF );
            //型式（類別記号）
            writer.Write( temp.ACCEPTODRCARRF_CATEGORYSIGNMODELRF );
            //型式（フル型）
            writer.Write( temp.ACCEPTODRCARRF_FULLMODELRF );
            //型式指定番号
            writer.Write( temp.ACCEPTODRCARRF_MODELDESIGNATIONNORF );
            //類別番号
            writer.Write( temp.ACCEPTODRCARRF_CATEGORYNORF );
            //車台型式
            writer.Write( temp.ACCEPTODRCARRF_FRAMEMODELRF );
            //車台番号
            writer.Write( temp.ACCEPTODRCARRF_FRAMENORF );
            //車台番号（検索用）
            writer.Write( temp.ACCEPTODRCARRF_SEARCHFRAMENORF );
            //エンジン型式名称
            writer.Write( temp.ACCEPTODRCARRF_ENGINEMODELNMRF );
            //関連型式
            writer.Write( temp.ACCEPTODRCARRF_RELEVANCEMODELRF );
            //サブ車名コード
            writer.Write( temp.ACCEPTODRCARRF_SUBCARNMCDRF );
            //型式グレード略称
            writer.Write( temp.ACCEPTODRCARRF_MODELGRADESNAMERF );
            //カラーコード
            writer.Write( temp.ACCEPTODRCARRF_COLORCODERF );
            //カラー名称1
            writer.Write( temp.ACCEPTODRCARRF_COLORNAME1RF );
            //トリムコード
            writer.Write( temp.ACCEPTODRCARRF_TRIMCODERF );
            //トリム名称
            writer.Write( temp.ACCEPTODRCARRF_TRIMNAMERF );
            //車両走行距離
            writer.Write( temp.ACCEPTODRCARRF_MILEAGERF );
            //受注ステータス
            writer.Write( temp.DEPSITMAINRF_ACPTANODRSTATUSRF );
            //入金伝票番号
            writer.Write( temp.DEPSITMAINRF_DEPOSITSLIPNORF );
            //売上伝票番号
            writer.Write( temp.DEPSITMAINRF_SALESSLIPNUMRF );
            //計上拠点コード
            writer.Write( temp.DEPSITMAINRF_ADDUPSECCODERF );
            //部門コード
            writer.Write( temp.DEPSITMAINRF_SUBSECTIONCODERF );
            //入金日付
            writer.Write( temp.DEPSITMAINRF_DEPOSITDATERF );
            //計上日付
            writer.Write( temp.DEPSITMAINRF_ADDUPADATERF );
            //入金金額
            writer.Write( temp.DEPSITMAINRF_DEPOSITRF );
            //手数料入金額
            writer.Write( temp.DEPSITMAINRF_FEEDEPOSITRF );
            //値引入金額
            writer.Write( temp.DEPSITMAINRF_DISCOUNTDEPOSITRF );
            //自動入金区分
            writer.Write( temp.DEPSITMAINRF_AUTODEPOSITCDRF );
            //預り金区分
            writer.Write( temp.DEPSITMAINRF_DEPOSITCDRF );
            //手形振出日
            writer.Write( temp.DEPSITMAINRF_DRAFTDRAWINGDATERF );
            //手形種類
            writer.Write( temp.DEPSITMAINRF_DRAFTKINDRF );
            //手形種類名称
            writer.Write( temp.DEPSITMAINRF_DRAFTKINDNAMERF );
            //手形区分名称
            writer.Write( temp.DEPSITMAINRF_DRAFTDIVIDENAMERF );
            //手形番号
            writer.Write( temp.DEPSITMAINRF_DRAFTNORF );
            //得意先コード
            writer.Write( temp.DEPSITMAINRF_CUSTOMERCODERF );
            //請求先コード
            writer.Write( temp.DEPSITMAINRF_CLAIMCODERF );
            //伝票摘要
            writer.Write( temp.DEPSITMAINRF_OUTLINERF );
            //入金請求部門名称
            writer.Write( temp.SUBDEP_SUBSECTIONNAMERF );
            //入金伝票番号
            writer.Write( temp.DEPSITDTLRF_DEPOSITSLIPNORF );
            //入金行番号
            writer.Write( temp.DEPSITDTLRF_DEPOSITROWNORF );
            //金種コード
            writer.Write( temp.DEPSITDTLRF_MONEYKINDCODERF );
            //金種名称
            writer.Write( temp.DEPSITDTLRF_MONEYKINDNAMERF );
            //金種区分
            writer.Write( temp.DEPSITDTLRF_MONEYKINDDIVRF );
            //入金金額
            writer.Write( temp.DEPSITDTLRF_DEPOSITRF );
            //有効期限
            writer.Write( temp.DEPSITDTLRF_VALIDITYTERMRF );
            //受注ステータス名称
            writer.Write( temp.DADD_ACPTANODRSTATUSRF );
            //赤伝区分名称
            writer.Write( temp.DADD_DEBITNOTEDIVRF );
            //売上伝票区分名称
            writer.Write( temp.DADD_SALESSLIPCDRF );
            //売上日付
            writer.Write( temp.DADD_SALESDATERF );
            //売上日付西暦年
            writer.Write( temp.DADD_SALESDATEFYRF );
            //売上日付西暦年略
            writer.Write( temp.DADD_SALESDATEFSRF );
            //売上日付和暦年
            writer.Write( temp.DADD_SALESDATEFWRF );
            //売上日付月
            writer.Write( temp.DADD_SALESDATEFMRF );
            //売上日付日
            writer.Write( temp.DADD_SALESDATEFDRF );
            //売上日付元号
            writer.Write( temp.DADD_SALESDATEFGRF );
            //売上日付略号
            writer.Write( temp.DADD_SALESDATEFRRF );
            //売上日付リテラル(/)
            writer.Write( temp.DADD_SALESDATEFLSRF );
            //売上日付リテラル(.)
            writer.Write( temp.DADD_SALESDATEFLPRF );
            //売上日付リテラル(年)
            writer.Write( temp.DADD_SALESDATEFLYRF );
            //売上日付リテラル(月)
            writer.Write( temp.DADD_SALESDATEFLMRF );
            //売上日付リテラル(日)
            writer.Write( temp.DADD_SALESDATEFLDRF );
            //取寄商品合計金額（税抜）
            writer.Write( temp.DADD_STOCKGOODSTTLTAXEXCRF );
            //優良商品合計金額（税抜）
            writer.Write( temp.DADD_PUREGOODSTTLTAXEXCRF );
            //商品属性名称
            writer.Write( temp.DADD_GOODSKINDCODERF );
            //売上在庫取寄せ区分名称
            writer.Write( temp.DADD_SALESORDERDIVCDRF );
            //オープン価格区分名称
            writer.Write( temp.DADD_OPENPRICEDIVRF );
            //課税区分名称
            writer.Write( temp.DADD_TAXATIONDIVCDRF );
            //初年度西暦年
            writer.Write( temp.DADD_FIRSTENTRYDATEFYRF );
            //初年度西暦年略
            writer.Write( temp.DADD_FIRSTENTRYDATEFSRF );
            //初年度和暦年
            writer.Write( temp.DADD_FIRSTENTRYDATEFWRF );
            //初年度月
            writer.Write( temp.DADD_FIRSTENTRYDATEFMRF );
            //初年度元号
            writer.Write( temp.DADD_FIRSTENTRYDATEFGRF );
            //初年度略号
            writer.Write( temp.DADD_FIRSTENTRYDATEFRRF );
            //初年度リテラル(/)
            writer.Write( temp.DADD_FIRSTENTRYDATEFLSRF );
            //初年度リテラル(.)
            writer.Write( temp.DADD_FIRSTENTRYDATEFLPRF );
            //初年度リテラル(年)
            writer.Write( temp.DADD_FIRSTENTRYDATEFLYRF );
            //初年度リテラル(月)
            writer.Write( temp.DADD_FIRSTENTRYDATEFLMRF );
            //入金日付西暦年
            writer.Write( temp.DADD_DEPOSITDATEFYRF );
            //入金日付西暦年略
            writer.Write( temp.DADD_DEPOSITDATEFSRF );
            //入金日付和暦年
            writer.Write( temp.DADD_DEPOSITDATEFWRF );
            //入金日付月
            writer.Write( temp.DADD_DEPOSITDATEFMRF );
            //入金日付日
            writer.Write( temp.DADD_DEPOSITDATEFDRF );
            //入金日付元号
            writer.Write( temp.DADD_DEPOSITDATEFGRF );
            //入金日付略号
            writer.Write( temp.DADD_DEPOSITDATEFRRF );
            //入金日付リテラル(/)
            writer.Write( temp.DADD_DEPOSITDATEFLSRF );
            //入金日付リテラル(.)
            writer.Write( temp.DADD_DEPOSITDATEFLPRF );
            //入金日付リテラル(年)
            writer.Write( temp.DADD_DEPOSITDATEFLYRF );
            //入金日付リテラル(月)
            writer.Write( temp.DADD_DEPOSITDATEFLMRF );
            //入金日付リテラル(日)
            writer.Write( temp.DADD_DEPOSITDATEFLDRF );
            //自動入金区分名称
            writer.Write( temp.DADD_AUTODEPOSITCDRF );
            //預り金区分名称
            writer.Write( temp.DADD_DEPOSITCDRF );
            //手形振出日西暦年
            writer.Write( temp.DADD_DRAFTDRAWINGDATEFYRF );
            //手形振出日西暦年略
            writer.Write( temp.DADD_DRAFTDRAWINGDATEFSRF );
            //手形振出日和暦年
            writer.Write( temp.DADD_DRAFTDRAWINGDATEFWRF );
            //手形振出日月
            writer.Write( temp.DADD_DRAFTDRAWINGDATEFMRF );
            //手形振出日日
            writer.Write( temp.DADD_DRAFTDRAWINGDATEFDRF );
            //手形振出日元号
            writer.Write( temp.DADD_DRAFTDRAWINGDATEFGRF );
            //手形振出日略号
            writer.Write( temp.DADD_DRAFTDRAWINGDATEFRRF );
            //手形振出日リテラル(/)
            writer.Write( temp.DADD_DRAFTDRAWINGDATEFLSRF );
            //手形振出日リテラル(.)
            writer.Write( temp.DADD_DRAFTDRAWINGDATEFLPRF );
            //手形振出日リテラル(年)
            writer.Write( temp.DADD_DRAFTDRAWINGDATEFLYRF );
            //手形振出日リテラル(月)
            writer.Write( temp.DADD_DRAFTDRAWINGDATEFLMRF );
            //手形振出日リテラル(日)
            writer.Write( temp.DADD_DRAFTDRAWINGDATEFLDRF );
            //手形支払期日西暦年
            writer.Write( temp.DADD_DRAFTPAYTIMELIMITFYRF );
            //手形支払期日西暦年略
            writer.Write( temp.DADD_DRAFTPAYTIMELIMITFSRF );
            //手形支払期日和暦年
            writer.Write( temp.DADD_DRAFTPAYTIMELIMITFWRF );
            //手形支払期日月
            writer.Write( temp.DADD_DRAFTPAYTIMELIMITFMRF );
            //手形支払期日日
            writer.Write( temp.DADD_DRAFTPAYTIMELIMITFDRF );
            //手形支払期日元号
            writer.Write( temp.DADD_DRAFTPAYTIMELIMITFGRF );
            //手形支払期日略号
            writer.Write( temp.DADD_DRAFTPAYTIMELIMITFRRF );
            //手形支払期日リテラル(/)
            writer.Write( temp.DADD_DRAFTPAYTIMELIMITFLSRF );
            //手形支払期日リテラル(.)
            writer.Write( temp.DADD_DRAFTPAYTIMELIMITFLPRF );
            //手形支払期日リテラル(年)
            writer.Write( temp.DADD_DRAFTPAYTIMELIMITFLYRF );
            //手形支払期日リテラル(月)
            writer.Write( temp.DADD_DRAFTPAYTIMELIMITFLMRF );
            //手形支払期日リテラル(日)
            writer.Write( temp.DADD_DRAFTPAYTIMELIMITFLDRF );
            //有効期限西暦年
            writer.Write( temp.DADD_VALIDITYTERMFYRF );
            //有効期限西暦年略
            writer.Write( temp.DADD_VALIDITYTERMFSRF );
            //有効期限和暦年
            writer.Write( temp.DADD_VALIDITYTERMFWRF );
            //有効期限月
            writer.Write( temp.DADD_VALIDITYTERMFMRF );
            //有効期限日
            writer.Write( temp.DADD_VALIDITYTERMFDRF );
            //有効期限元号
            writer.Write( temp.DADD_VALIDITYTERMFGRF );
            //有効期限略号
            writer.Write( temp.DADD_VALIDITYTERMFRRF );
            //有効期限リテラル(/)
            writer.Write( temp.DADD_VALIDITYTERMFLSRF );
            //有効期限リテラル(.)
            writer.Write( temp.DADD_VALIDITYTERMFLPRF );
            //有効期限リテラル(年)
            writer.Write( temp.DADD_VALIDITYTERMFLYRF );
            //有効期限リテラル(月)
            writer.Write( temp.DADD_VALIDITYTERMFLMRF );
            //有効期限リテラル(日)
            writer.Write( temp.DADD_VALIDITYTERMFLDRF );
            //請求明細摘要
            writer.Write( temp.DADD_DMDDTLOUTLINERF );
            //売上伝票計タイトル
            writer.Write( temp.DADD_SALESFTTITLERF );
            //売上伝票計金額
            writer.Write( temp.DADD_SALESFTPRICERF );
            //売上伝票計備考１
            writer.Write( temp.DADD_SALESFTNOTE1RF );
            //売上伝票計備考２
            writer.Write( temp.DADD_SALESFTNOTE2RF );
            //売上伝票計備考３
            writer.Write( temp.DADD_SALESFTNOTE3RF );
            //明細伝票タイトル(売上/返品)
            writer.Write( temp.DSAL_DETAILTITLE );
            //売上集計タイトル
            writer.Write( temp.DSAL_DETAILSUMTITLE );
            //売上集計金額
            writer.Write( temp.DSAL_DETAILSUMPRICE );
            //明細伝票タイトル(入金)
            writer.Write( temp.DDEP_DETAILTITLE );
            //入金集計タイトル
            writer.Write( temp.DDEP_DETAILSUMTITLE );
            //入金集計金額
            writer.Write( temp.DDEP_DETAILSUMPRICE );
            //売上伝票区分（明細）
            writer.Write( temp.SALESDETAILRF_SALESSLIPCDDTLRF );
            //実績計上拠点コード
            writer.Write( temp.SALESSLIPRF_RESULTSADDUPSECCDRF );
            //入金入力拠点コード
            writer.Write( temp.DEPSITMAINRF_INPUTDEPOSITSECCDRF );
            //商品名称カナ
            writer.Write( temp.SALESDETAILRF_GOODSNAMEKANARF );
            //メーカーカナ名称
            writer.Write( temp.SALESDETAILRF_MAKERKANANAMERF );
            //車種半角名称
            writer.Write( temp.ACCEPTODRCARRF_MODELHALFNAMERF );
            //印刷用品番
            writer.Write( temp.SALESDETAILRF_PRTGOODSNORF );
            //印刷用メーカーコード
            writer.Write( temp.SALESDETAILRF_PRTMAKERCODERF );
            //印刷用メーカー名称
            writer.Write( temp.SALESDETAILRF_PRTMAKERNAMERF );
            //相手先伝票番号（ヘッダ用）
            writer.Write( temp.DADD_PARTYSALESLIPNUMRF );
            //消費税転嫁方式
            writer.Write(temp.SALESSLIPRF_CONSTAXLAYMETHODRF);
        }

        /// <summary>
        ///  EBooksFrePBillDetailWorkインスタンス取得
        /// </summary>
        /// <returns>EBooksFrePBillDetailWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   EBooksFrePBillDetailWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private EBooksFrePBillDetailWork GetEBooksFrePBillDetailWork( System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo )
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            EBooksFrePBillDetailWork temp = new EBooksFrePBillDetailWork();

            //受注ステータス
            temp.SALESSLIPRF_ACPTANODRSTATUSRF = reader.ReadInt32();
            //売上伝票番号
            temp.SALESSLIPRF_SALESSLIPNUMRF = reader.ReadString();
            //拠点コード
            temp.SALESSLIPRF_SECTIONCODERF = reader.ReadString();
            //部門コード
            temp.SALESSLIPRF_SUBSECTIONCODERF = reader.ReadInt32();
            //赤伝区分
            temp.SALESSLIPRF_DEBITNOTEDIVRF = reader.ReadInt32();
            //売上伝票区分
            temp.SALESSLIPRF_SALESSLIPCDRF = reader.ReadInt32();
            //売上商品区分
            temp.SALESSLIPRF_SALESGOODSCDRF = reader.ReadInt32();
            //売掛区分
            temp.SALESSLIPRF_ACCRECDIVCDRF = reader.ReadInt32();
            //請求計上拠点コード
            temp.SALESSLIPRF_DEMANDADDUPSECCDRF = reader.ReadString();
            //売上日付
            temp.SALESSLIPRF_SALESDATERF = reader.ReadInt32();
            //計上日付
            temp.SALESSLIPRF_ADDUPADATERF = reader.ReadInt32();
            //入力担当者コード
            temp.SALESSLIPRF_INPUTAGENCDRF = reader.ReadString();
            //入力担当者名称
            temp.SALESSLIPRF_INPUTAGENNMRF = reader.ReadString();
            //売上入力者コード
            temp.SALESSLIPRF_SALESINPUTCODERF = reader.ReadString();
            //売上入力者名称
            temp.SALESSLIPRF_SALESINPUTNAMERF = reader.ReadString();
            //受付従業員コード
            temp.SALESSLIPRF_FRONTEMPLOYEECDRF = reader.ReadString();
            //受付従業員名称
            temp.SALESSLIPRF_FRONTEMPLOYEENMRF = reader.ReadString();
            //販売従業員コード
            temp.SALESSLIPRF_SALESEMPLOYEECDRF = reader.ReadString();
            //販売従業員名称
            temp.SALESSLIPRF_SALESEMPLOYEENMRF = reader.ReadString();
            //売上伝票合計（税込み）
            temp.SALESSLIPRF_SALESTOTALTAXINCRF = reader.ReadInt64();
            //売上伝票合計（税抜き）
            temp.SALESSLIPRF_SALESTOTALTAXEXCRF = reader.ReadInt64();
            //売上部品合計（税込み）
            temp.SALESSLIPRF_SALESPRTTOTALTAXINCRF = reader.ReadInt64();
            //売上部品合計（税抜き）
            temp.SALESSLIPRF_SALESPRTTOTALTAXEXCRF = reader.ReadInt64();
            //売上作業合計（税込み）
            temp.SALESSLIPRF_SALESWORKTOTALTAXINCRF = reader.ReadInt64();
            //売上作業合計（税抜き）
            temp.SALESSLIPRF_SALESWORKTOTALTAXEXCRF = reader.ReadInt64();
            //売上小計（税込み）
            temp.SALESSLIPRF_SALESSUBTOTALTAXINCRF = reader.ReadInt64();
            //売上小計（税抜き）
            temp.SALESSLIPRF_SALESSUBTOTALTAXEXCRF = reader.ReadInt64();
            //売上部品小計（税込み）
            temp.SALESSLIPRF_SALESPRTSUBTTLINCRF = reader.ReadInt64();
            //売上部品小計（税抜き）
            temp.SALESSLIPRF_SALESPRTSUBTTLEXCRF = reader.ReadInt64();
            //売上作業小計（税込み）
            temp.SALESSLIPRF_SALESWORKSUBTTLINCRF = reader.ReadInt64();
            //売上作業小計（税抜き）
            temp.SALESSLIPRF_SALESWORKSUBTTLEXCRF = reader.ReadInt64();
            //売上小計（税）
            temp.SALESSLIPRF_SALESSUBTOTALTAXRF = reader.ReadInt64();
            //部品値引対象額合計（税抜き）
            temp.SALESSLIPRF_ITDEDPARTSDISOUTTAXRF = reader.ReadInt64();
            //部品値引対象額合計（税込み）
            temp.SALESSLIPRF_ITDEDPARTSDISINTAXRF = reader.ReadInt64();
            //作業値引対象額合計（税抜き）
            temp.SALESSLIPRF_ITDEDWORKDISOUTTAXRF = reader.ReadInt64();
            //作業値引対象額合計（税込み）
            temp.SALESSLIPRF_ITDEDWORKDISINTAXRF = reader.ReadInt64();
            //部品値引率
            temp.SALESSLIPRF_PARTSDISCOUNTRATERF = reader.ReadDouble();
            //工賃値引率
            temp.SALESSLIPRF_RAVORDISCOUNTRATERF = reader.ReadDouble();
            //原価金額計
            temp.SALESSLIPRF_TOTALCOSTRF = reader.ReadInt64();
            //消費税税率
            temp.SALESSLIPRF_CONSTAXRATERF = reader.ReadDouble();
            //自動入金区分
            temp.SALESSLIPRF_AUTODEPOSITCDRF = reader.ReadInt32();
            //自動入金伝票番号
            temp.SALESSLIPRF_AUTODEPOSITSLIPNORF = reader.ReadInt32();
            //入金引当合計額
            temp.SALESSLIPRF_DEPOSITALLOWANCETTLRF = reader.ReadInt64();
            //入金引当残高
            temp.SALESSLIPRF_DEPOSITALWCBLNCERF = reader.ReadInt64();
            //請求先コード
            temp.SALESSLIPRF_CLAIMCODERF = reader.ReadInt32();
            //得意先コード
            temp.SALESSLIPRF_CUSTOMERCODERF = reader.ReadInt32();
            //得意先名称
            temp.SALESSLIPRF_CUSTOMERNAMERF = reader.ReadString();
            //得意先名称2
            temp.SALESSLIPRF_CUSTOMERNAME2RF = reader.ReadString();
            //得意先略称
            temp.SALESSLIPRF_CUSTOMERSNMRF = reader.ReadString();
            //敬称
            temp.SALESSLIPRF_HONORIFICTITLERF = reader.ReadString();
            //納品先コード
            temp.SALESSLIPRF_ADDRESSEECODERF = reader.ReadInt32();
            //納品先名称
            temp.SALESSLIPRF_ADDRESSEENAMERF = reader.ReadString();
            //納品先名称2
            temp.SALESSLIPRF_ADDRESSEENAME2RF = reader.ReadString();
            //相手先伝票番号
            temp.SALESSLIPRF_PARTYSALESLIPNUMRF = reader.ReadString();
            //伝票備考
            temp.SALESSLIPRF_SLIPNOTERF = reader.ReadString();
            //伝票備考２
            temp.SALESSLIPRF_SLIPNOTE2RF = reader.ReadString();
            //伝票備考３
            temp.SALESSLIPRF_SLIPNOTE3RF = reader.ReadString();
            //返品理由コード
            temp.SALESSLIPRF_RETGOODSREASONDIVRF = reader.ReadInt32();
            //返品理由
            temp.SALESSLIPRF_RETGOODSREASONRF = reader.ReadString();
            //明細行数
            temp.SALESSLIPRF_DETAILROWCOUNTRF = reader.ReadInt32();
            //ＵＯＥリマーク１
            temp.SALESSLIPRF_UOEREMARK1RF = reader.ReadString();
            //ＵＯＥリマーク２
            temp.SALESSLIPRF_UOEREMARK2RF = reader.ReadString();
            //納品区分
            temp.SALESSLIPRF_DELIVEREDGOODSDIVRF = reader.ReadInt32();
            //納品区分名称
            temp.SALESSLIPRF_DELIVEREDGOODSDIVNMRF = reader.ReadString();
            //在庫商品合計金額（税抜）
            temp.SALESSLIPRF_STOCKGOODSTTLTAXEXCRF = reader.ReadInt64();
            //純正商品合計金額（税抜）
            temp.SALESSLIPRF_PUREGOODSTTLTAXEXCRF = reader.ReadInt64();
            //脚注１
            temp.SALESSLIPRF_FOOTNOTES1RF = reader.ReadString();
            //脚注２
            temp.SALESSLIPRF_FOOTNOTES2RF = reader.ReadString();
            //拠点ガイド名称
            temp.SECDTL_SECTIONGUIDENMRF = reader.ReadString();
            //拠点ガイド略称
            temp.SECDTL_SECTIONGUIDESNMRF = reader.ReadString();
            //自社名称コード1
            temp.SECDTL_COMPANYNAMECD1RF = reader.ReadInt32();
            //売上部門名称
            temp.SUBSAL_SUBSECTIONNAMERF = reader.ReadString();
            //受注番号
            temp.SALESDETAILRF_ACCEPTANORDERNORF = reader.ReadInt32();
            //売上行番号
            temp.SALESDETAILRF_SALESROWNORF = reader.ReadInt32();
            //納品完了予定日
            temp.SALESDETAILRF_DELIGDSCMPLTDUEDATERF = reader.ReadInt32();
            //商品属性
            temp.SALESDETAILRF_GOODSKINDCODERF = reader.ReadInt32();
            //商品メーカーコード
            temp.SALESDETAILRF_GOODSMAKERCDRF = reader.ReadInt32();
            //メーカー名称
            temp.SALESDETAILRF_MAKERNAMERF = reader.ReadString();
            //商品番号
            temp.SALESDETAILRF_GOODSNORF = reader.ReadString();
            //商品名称
            temp.SALESDETAILRF_GOODSNAMERF = reader.ReadString();
            //商品名略称
            temp.SALESDETAILRF_GOODSSHORTNAMERF = reader.ReadString();
            //商品大分類コード
            temp.SALESDETAILRF_GOODSLGROUPRF = reader.ReadInt32();
            //商品大分類名称
            temp.SALESDETAILRF_GOODSLGROUPNAMERF = reader.ReadString();
            //商品中分類コード
            temp.SALESDETAILRF_GOODSMGROUPRF = reader.ReadInt32();
            //商品中分類名称
            temp.SALESDETAILRF_GOODSMGROUPNAMERF = reader.ReadString();
            //BLグループコード
            temp.SALESDETAILRF_BLGROUPCODERF = reader.ReadInt32();
            //BLグループコード名称
            temp.SALESDETAILRF_BLGROUPNAMERF = reader.ReadString();
            //BL商品コード
            temp.SALESDETAILRF_BLGOODSCODERF = reader.ReadInt32();
            //BL商品コード名称（全角）
            temp.SALESDETAILRF_BLGOODSFULLNAMERF = reader.ReadString();
            //自社分類コード
            temp.SALESDETAILRF_ENTERPRISEGANRECODERF = reader.ReadInt32();
            //自社分類名称
            temp.SALESDETAILRF_ENTERPRISEGANRENAMERF = reader.ReadString();
            //倉庫コード
            temp.SALESDETAILRF_WAREHOUSECODERF = reader.ReadString();
            //倉庫名称
            temp.SALESDETAILRF_WAREHOUSENAMERF = reader.ReadString();
            //倉庫棚番
            temp.SALESDETAILRF_WAREHOUSESHELFNORF = reader.ReadString();
            //売上在庫取寄せ区分
            temp.SALESDETAILRF_SALESORDERDIVCDRF = reader.ReadInt32();
            //オープン価格区分
            temp.SALESDETAILRF_OPENPRICEDIVRF = reader.ReadInt32();
            //商品掛率ランク
            temp.SALESDETAILRF_GOODSRATERANKRF = reader.ReadString();
            //定価率
            temp.SALESDETAILRF_LISTPRICERATERF = reader.ReadDouble();
            //定価（税込，浮動）
            temp.SALESDETAILRF_LISTPRICETAXINCFLRF = reader.ReadDouble();
            //定価（税抜，浮動）
            temp.SALESDETAILRF_LISTPRICETAXEXCFLRF = reader.ReadDouble();
            //売価率
            temp.SALESDETAILRF_SALESRATERF = reader.ReadDouble();
            //売上単価（税込，浮動）
            temp.SALESDETAILRF_SALESUNPRCTAXINCFLRF = reader.ReadDouble();
            //売上単価（税抜，浮動）
            temp.SALESDETAILRF_SALESUNPRCTAXEXCFLRF = reader.ReadDouble();
            //原価率
            temp.SALESDETAILRF_COSTRATERF = reader.ReadDouble();
            //原価単価
            temp.SALESDETAILRF_SALESUNITCOSTRF = reader.ReadDouble();
            //BL商品コード（印刷）
            temp.SALESDETAILRF_PRTBLGOODSCODERF = reader.ReadInt32();
            //BL商品コード名称（印刷）
            temp.SALESDETAILRF_PRTBLGOODSNAMERF = reader.ReadString();
            //作業工数
            temp.SALESDETAILRF_WORKMANHOURRF = reader.ReadDouble();
            //出荷数
            temp.SALESDETAILRF_SHIPMENTCNTRF = reader.ReadDouble();
            //売上金額（税込み）
            temp.SALESDETAILRF_SALESMONEYTAXINCRF = reader.ReadInt64();
            //売上金額（税抜き）
            temp.SALESDETAILRF_SALESMONEYTAXEXCRF = reader.ReadInt64();
            //原価
            temp.SALESDETAILRF_COSTRF = reader.ReadInt64();
            //課税区分
            temp.SALESDETAILRF_TAXATIONDIVCDRF = reader.ReadInt32();
            //相手先伝票番号（明細）
            temp.SALESDETAILRF_PARTYSLIPNUMDTLRF = reader.ReadString();
            //明細備考
            temp.SALESDETAILRF_DTLNOTERF = reader.ReadString();
            //仕入先コード
            temp.SALESDETAILRF_SUPPLIERCDRF = reader.ReadInt32();
            //仕入先略称
            temp.SALESDETAILRF_SUPPLIERSNMRF = reader.ReadString();
            //伝票メモ１
            temp.SALESDETAILRF_SLIPMEMO1RF = reader.ReadString();
            //伝票メモ２
            temp.SALESDETAILRF_SLIPMEMO2RF = reader.ReadString();
            //伝票メモ３
            temp.SALESDETAILRF_SLIPMEMO3RF = reader.ReadString();
            //社内メモ１
            temp.SALESDETAILRF_INSIDEMEMO1RF = reader.ReadString();
            //社内メモ２
            temp.SALESDETAILRF_INSIDEMEMO2RF = reader.ReadString();
            //社内メモ３
            temp.SALESDETAILRF_INSIDEMEMO3RF = reader.ReadString();
            //変更前定価
            temp.SALESDETAILRF_BFLISTPRICERF = reader.ReadDouble();
            //変更前売価
            temp.SALESDETAILRF_BFSALESUNITPRICERF = reader.ReadDouble();
            //変更前原価
            temp.SALESDETAILRF_BFUNITCOSTRF = reader.ReadDouble();
            //一式明細番号
            temp.SALESDETAILRF_CMPLTSALESROWNORF = reader.ReadInt32();
            //メーカーコード（一式）
            temp.SALESDETAILRF_CMPLTGOODSMAKERCDRF = reader.ReadInt32();
            //メーカー名称（一式）
            temp.SALESDETAILRF_CMPLTMAKERNAMERF = reader.ReadString();
            //商品名称（一式）
            temp.SALESDETAILRF_CMPLTGOODSNAMERF = reader.ReadString();
            //数量（一式）
            temp.SALESDETAILRF_CMPLTSHIPMENTCNTRF = reader.ReadDouble();
            //売上単価（一式）
            temp.SALESDETAILRF_CMPLTSALESUNPRCFLRF = reader.ReadDouble();
            //売上金額（一式）
            temp.SALESDETAILRF_CMPLTSALESMONEYRF = reader.ReadInt64();
            //原価単価（一式）
            temp.SALESDETAILRF_CMPLTSALESUNITCOSTRF = reader.ReadDouble();
            //原価金額（一式）
            temp.SALESDETAILRF_CMPLTCOSTRF = reader.ReadInt64();
            //相手先伝票番号（一式）
            temp.SALESDETAILRF_CMPLTPARTYSALSLNUMRF = reader.ReadString();
            //一式備考
            temp.SALESDETAILRF_CMPLTNOTERF = reader.ReadString();
            //車両管理番号
            temp.ACCEPTODRCARRF_CARMNGNORF = reader.ReadInt32();
            //車輌管理コード
            temp.ACCEPTODRCARRF_CARMNGCODERF = reader.ReadString();
            //陸運事務所番号
            temp.ACCEPTODRCARRF_NUMBERPLATE1CODERF = reader.ReadInt32();
            //陸運事務局名称
            temp.ACCEPTODRCARRF_NUMBERPLATE1NAMERF = reader.ReadString();
            //車両登録番号（種別）
            temp.ACCEPTODRCARRF_NUMBERPLATE2RF = reader.ReadString();
            //車両登録番号（カナ）
            temp.ACCEPTODRCARRF_NUMBERPLATE3RF = reader.ReadString();
            //車両登録番号（プレート番号）
            temp.ACCEPTODRCARRF_NUMBERPLATE4RF = reader.ReadInt32();
            //初年度
            temp.ACCEPTODRCARRF_FIRSTENTRYDATERF = reader.ReadInt32();
            //メーカーコード
            temp.ACCEPTODRCARRF_MAKERCODERF = reader.ReadInt32();
            //メーカー全角名称
            temp.ACCEPTODRCARRF_MAKERFULLNAMERF = reader.ReadString();
            //車種コード
            temp.ACCEPTODRCARRF_MODELCODERF = reader.ReadInt32();
            //車種サブコード
            temp.ACCEPTODRCARRF_MODELSUBCODERF = reader.ReadInt32();
            //車種全角名称
            temp.ACCEPTODRCARRF_MODELFULLNAMERF = reader.ReadString();
            //排ガス記号
            temp.ACCEPTODRCARRF_EXHAUSTGASSIGNRF = reader.ReadString();
            //シリーズ型式
            temp.ACCEPTODRCARRF_SERIESMODELRF = reader.ReadString();
            //型式（類別記号）
            temp.ACCEPTODRCARRF_CATEGORYSIGNMODELRF = reader.ReadString();
            //型式（フル型）
            temp.ACCEPTODRCARRF_FULLMODELRF = reader.ReadString();
            //型式指定番号
            temp.ACCEPTODRCARRF_MODELDESIGNATIONNORF = reader.ReadInt32();
            //類別番号
            temp.ACCEPTODRCARRF_CATEGORYNORF = reader.ReadInt32();
            //車台型式
            temp.ACCEPTODRCARRF_FRAMEMODELRF = reader.ReadString();
            //車台番号
            temp.ACCEPTODRCARRF_FRAMENORF = reader.ReadString();
            //車台番号（検索用）
            temp.ACCEPTODRCARRF_SEARCHFRAMENORF = reader.ReadInt32();
            //エンジン型式名称
            temp.ACCEPTODRCARRF_ENGINEMODELNMRF = reader.ReadString();
            //関連型式
            temp.ACCEPTODRCARRF_RELEVANCEMODELRF = reader.ReadString();
            //サブ車名コード
            temp.ACCEPTODRCARRF_SUBCARNMCDRF = reader.ReadInt32();
            //型式グレード略称
            temp.ACCEPTODRCARRF_MODELGRADESNAMERF = reader.ReadString();
            //カラーコード
            temp.ACCEPTODRCARRF_COLORCODERF = reader.ReadString();
            //カラー名称1
            temp.ACCEPTODRCARRF_COLORNAME1RF = reader.ReadString();
            //トリムコード
            temp.ACCEPTODRCARRF_TRIMCODERF = reader.ReadString();
            //トリム名称
            temp.ACCEPTODRCARRF_TRIMNAMERF = reader.ReadString();
            //車両走行距離
            temp.ACCEPTODRCARRF_MILEAGERF = reader.ReadInt32();
            //受注ステータス
            temp.DEPSITMAINRF_ACPTANODRSTATUSRF = reader.ReadInt32();
            //入金伝票番号
            temp.DEPSITMAINRF_DEPOSITSLIPNORF = reader.ReadInt32();
            //売上伝票番号
            temp.DEPSITMAINRF_SALESSLIPNUMRF = reader.ReadString();
            //計上拠点コード
            temp.DEPSITMAINRF_ADDUPSECCODERF = reader.ReadString();
            //部門コード
            temp.DEPSITMAINRF_SUBSECTIONCODERF = reader.ReadInt32();
            //入金日付
            temp.DEPSITMAINRF_DEPOSITDATERF = reader.ReadInt32();
            //計上日付
            temp.DEPSITMAINRF_ADDUPADATERF = reader.ReadInt32();
            //入金金額
            temp.DEPSITMAINRF_DEPOSITRF = reader.ReadInt64();
            //手数料入金額
            temp.DEPSITMAINRF_FEEDEPOSITRF = reader.ReadInt64();
            //値引入金額
            temp.DEPSITMAINRF_DISCOUNTDEPOSITRF = reader.ReadInt64();
            //自動入金区分
            temp.DEPSITMAINRF_AUTODEPOSITCDRF = reader.ReadInt32();
            //預り金区分
            temp.DEPSITMAINRF_DEPOSITCDRF = reader.ReadInt32();
            //手形振出日
            temp.DEPSITMAINRF_DRAFTDRAWINGDATERF = reader.ReadInt32();
            //手形種類
            temp.DEPSITMAINRF_DRAFTKINDRF = reader.ReadInt32();
            //手形種類名称
            temp.DEPSITMAINRF_DRAFTKINDNAMERF = reader.ReadString();
            //手形区分名称
            temp.DEPSITMAINRF_DRAFTDIVIDENAMERF = reader.ReadString();
            //手形番号
            temp.DEPSITMAINRF_DRAFTNORF = reader.ReadString();
            //得意先コード
            temp.DEPSITMAINRF_CUSTOMERCODERF = reader.ReadInt32();
            //請求先コード
            temp.DEPSITMAINRF_CLAIMCODERF = reader.ReadInt32();
            //伝票摘要
            temp.DEPSITMAINRF_OUTLINERF = reader.ReadString();
            //入金請求部門名称
            temp.SUBDEP_SUBSECTIONNAMERF = reader.ReadString();
            //入金伝票番号
            temp.DEPSITDTLRF_DEPOSITSLIPNORF = reader.ReadInt32();
            //入金行番号
            temp.DEPSITDTLRF_DEPOSITROWNORF = reader.ReadInt32();
            //金種コード
            temp.DEPSITDTLRF_MONEYKINDCODERF = reader.ReadInt32();
            //金種名称
            temp.DEPSITDTLRF_MONEYKINDNAMERF = reader.ReadString();
            //金種区分
            temp.DEPSITDTLRF_MONEYKINDDIVRF = reader.ReadInt32();
            //入金金額
            temp.DEPSITDTLRF_DEPOSITRF = reader.ReadInt64();
            //有効期限
            temp.DEPSITDTLRF_VALIDITYTERMRF = reader.ReadInt32();
            //受注ステータス名称
            temp.DADD_ACPTANODRSTATUSRF = reader.ReadInt32();
            //赤伝区分名称
            temp.DADD_DEBITNOTEDIVRF = reader.ReadInt32();
            //売上伝票区分名称
            temp.DADD_SALESSLIPCDRF = reader.ReadInt32();
            //売上日付
            temp.DADD_SALESDATERF = reader.ReadInt32();
            //売上日付西暦年
            temp.DADD_SALESDATEFYRF = reader.ReadInt32();
            //売上日付西暦年略
            temp.DADD_SALESDATEFSRF = reader.ReadInt32();
            //売上日付和暦年
            temp.DADD_SALESDATEFWRF = reader.ReadInt32();
            //売上日付月
            temp.DADD_SALESDATEFMRF = reader.ReadInt32();
            //売上日付日
            temp.DADD_SALESDATEFDRF = reader.ReadInt32();
            //売上日付元号
            temp.DADD_SALESDATEFGRF = reader.ReadString();
            //売上日付略号
            temp.DADD_SALESDATEFRRF = reader.ReadString();
            //売上日付リテラル(/)
            temp.DADD_SALESDATEFLSRF = reader.ReadString();
            //売上日付リテラル(.)
            temp.DADD_SALESDATEFLPRF = reader.ReadString();
            //売上日付リテラル(年)
            temp.DADD_SALESDATEFLYRF = reader.ReadString();
            //売上日付リテラル(月)
            temp.DADD_SALESDATEFLMRF = reader.ReadString();
            //売上日付リテラル(日)
            temp.DADD_SALESDATEFLDRF = reader.ReadString();
            //取寄商品合計金額（税抜）
            temp.DADD_STOCKGOODSTTLTAXEXCRF = reader.ReadInt64();
            //優良商品合計金額（税抜）
            temp.DADD_PUREGOODSTTLTAXEXCRF = reader.ReadInt64();
            //商品属性名称
            temp.DADD_GOODSKINDCODERF = reader.ReadInt32();
            //売上在庫取寄せ区分名称
            temp.DADD_SALESORDERDIVCDRF = reader.ReadInt32();
            //オープン価格区分名称
            temp.DADD_OPENPRICEDIVRF = reader.ReadInt32();
            //課税区分名称
            temp.DADD_TAXATIONDIVCDRF = reader.ReadInt32();
            //初年度西暦年
            temp.DADD_FIRSTENTRYDATEFYRF = reader.ReadInt32();
            //初年度西暦年略
            temp.DADD_FIRSTENTRYDATEFSRF = reader.ReadInt32();
            //初年度和暦年
            temp.DADD_FIRSTENTRYDATEFWRF = reader.ReadInt32();
            //初年度月
            temp.DADD_FIRSTENTRYDATEFMRF = reader.ReadInt32();
            //初年度元号
            temp.DADD_FIRSTENTRYDATEFGRF = reader.ReadString();
            //初年度略号
            temp.DADD_FIRSTENTRYDATEFRRF = reader.ReadString();
            //初年度リテラル(/)
            temp.DADD_FIRSTENTRYDATEFLSRF = reader.ReadString();
            //初年度リテラル(.)
            temp.DADD_FIRSTENTRYDATEFLPRF = reader.ReadString();
            //初年度リテラル(年)
            temp.DADD_FIRSTENTRYDATEFLYRF = reader.ReadString();
            //初年度リテラル(月)
            temp.DADD_FIRSTENTRYDATEFLMRF = reader.ReadString();
            //入金日付西暦年
            temp.DADD_DEPOSITDATEFYRF = reader.ReadInt32();
            //入金日付西暦年略
            temp.DADD_DEPOSITDATEFSRF = reader.ReadInt32();
            //入金日付和暦年
            temp.DADD_DEPOSITDATEFWRF = reader.ReadInt32();
            //入金日付月
            temp.DADD_DEPOSITDATEFMRF = reader.ReadInt32();
            //入金日付日
            temp.DADD_DEPOSITDATEFDRF = reader.ReadInt32();
            //入金日付元号
            temp.DADD_DEPOSITDATEFGRF = reader.ReadString();
            //入金日付略号
            temp.DADD_DEPOSITDATEFRRF = reader.ReadString();
            //入金日付リテラル(/)
            temp.DADD_DEPOSITDATEFLSRF = reader.ReadString();
            //入金日付リテラル(.)
            temp.DADD_DEPOSITDATEFLPRF = reader.ReadString();
            //入金日付リテラル(年)
            temp.DADD_DEPOSITDATEFLYRF = reader.ReadString();
            //入金日付リテラル(月)
            temp.DADD_DEPOSITDATEFLMRF = reader.ReadString();
            //入金日付リテラル(日)
            temp.DADD_DEPOSITDATEFLDRF = reader.ReadString();
            //自動入金区分名称
            temp.DADD_AUTODEPOSITCDRF = reader.ReadInt32();
            //預り金区分名称
            temp.DADD_DEPOSITCDRF = reader.ReadInt32();
            //手形振出日西暦年
            temp.DADD_DRAFTDRAWINGDATEFYRF = reader.ReadInt32();
            //手形振出日西暦年略
            temp.DADD_DRAFTDRAWINGDATEFSRF = reader.ReadInt32();
            //手形振出日和暦年
            temp.DADD_DRAFTDRAWINGDATEFWRF = reader.ReadInt32();
            //手形振出日月
            temp.DADD_DRAFTDRAWINGDATEFMRF = reader.ReadInt32();
            //手形振出日日
            temp.DADD_DRAFTDRAWINGDATEFDRF = reader.ReadInt32();
            //手形振出日元号
            temp.DADD_DRAFTDRAWINGDATEFGRF = reader.ReadString();
            //手形振出日略号
            temp.DADD_DRAFTDRAWINGDATEFRRF = reader.ReadString();
            //手形振出日リテラル(/)
            temp.DADD_DRAFTDRAWINGDATEFLSRF = reader.ReadString();
            //手形振出日リテラル(.)
            temp.DADD_DRAFTDRAWINGDATEFLPRF = reader.ReadString();
            //手形振出日リテラル(年)
            temp.DADD_DRAFTDRAWINGDATEFLYRF = reader.ReadString();
            //手形振出日リテラル(月)
            temp.DADD_DRAFTDRAWINGDATEFLMRF = reader.ReadString();
            //手形振出日リテラル(日)
            temp.DADD_DRAFTDRAWINGDATEFLDRF = reader.ReadString();
            //手形支払期日西暦年
            temp.DADD_DRAFTPAYTIMELIMITFYRF = reader.ReadInt32();
            //手形支払期日西暦年略
            temp.DADD_DRAFTPAYTIMELIMITFSRF = reader.ReadInt32();
            //手形支払期日和暦年
            temp.DADD_DRAFTPAYTIMELIMITFWRF = reader.ReadInt32();
            //手形支払期日月
            temp.DADD_DRAFTPAYTIMELIMITFMRF = reader.ReadInt32();
            //手形支払期日日
            temp.DADD_DRAFTPAYTIMELIMITFDRF = reader.ReadInt32();
            //手形支払期日元号
            temp.DADD_DRAFTPAYTIMELIMITFGRF = reader.ReadString();
            //手形支払期日略号
            temp.DADD_DRAFTPAYTIMELIMITFRRF = reader.ReadString();
            //手形支払期日リテラル(/)
            temp.DADD_DRAFTPAYTIMELIMITFLSRF = reader.ReadString();
            //手形支払期日リテラル(.)
            temp.DADD_DRAFTPAYTIMELIMITFLPRF = reader.ReadString();
            //手形支払期日リテラル(年)
            temp.DADD_DRAFTPAYTIMELIMITFLYRF = reader.ReadString();
            //手形支払期日リテラル(月)
            temp.DADD_DRAFTPAYTIMELIMITFLMRF = reader.ReadString();
            //手形支払期日リテラル(日)
            temp.DADD_DRAFTPAYTIMELIMITFLDRF = reader.ReadString();
            //有効期限西暦年
            temp.DADD_VALIDITYTERMFYRF = reader.ReadInt32();
            //有効期限西暦年略
            temp.DADD_VALIDITYTERMFSRF = reader.ReadInt32();
            //有効期限和暦年
            temp.DADD_VALIDITYTERMFWRF = reader.ReadInt32();
            //有効期限月
            temp.DADD_VALIDITYTERMFMRF = reader.ReadInt32();
            //有効期限日
            temp.DADD_VALIDITYTERMFDRF = reader.ReadInt32();
            //有効期限元号
            temp.DADD_VALIDITYTERMFGRF = reader.ReadString();
            //有効期限略号
            temp.DADD_VALIDITYTERMFRRF = reader.ReadString();
            //有効期限リテラル(/)
            temp.DADD_VALIDITYTERMFLSRF = reader.ReadString();
            //有効期限リテラル(.)
            temp.DADD_VALIDITYTERMFLPRF = reader.ReadString();
            //有効期限リテラル(年)
            temp.DADD_VALIDITYTERMFLYRF = reader.ReadString();
            //有効期限リテラル(月)
            temp.DADD_VALIDITYTERMFLMRF = reader.ReadString();
            //有効期限リテラル(日)
            temp.DADD_VALIDITYTERMFLDRF = reader.ReadString();
            //請求明細摘要
            temp.DADD_DMDDTLOUTLINERF = reader.ReadString();
            //売上伝票計タイトル
            temp.DADD_SALESFTTITLERF = reader.ReadString();
            //売上伝票計金額
            temp.DADD_SALESFTPRICERF = reader.ReadInt64();
            //売上伝票計備考１
            temp.DADD_SALESFTNOTE1RF = reader.ReadString();
            //売上伝票計備考２
            temp.DADD_SALESFTNOTE2RF = reader.ReadString();
            //売上伝票計備考３
            temp.DADD_SALESFTNOTE3RF = reader.ReadString();
            //明細伝票タイトル(売上/返品)
            temp.DSAL_DETAILTITLE = reader.ReadString();
            //売上集計タイトル
            temp.DSAL_DETAILSUMTITLE = reader.ReadString();
            //売上集計金額
            temp.DSAL_DETAILSUMPRICE = reader.ReadInt64();
            //明細伝票タイトル(入金)
            temp.DDEP_DETAILTITLE = reader.ReadString();
            //入金集計タイトル
            temp.DDEP_DETAILSUMTITLE = reader.ReadString();
            //入金集計金額
            temp.DDEP_DETAILSUMPRICE = reader.ReadInt64();
            //売上伝票区分（明細）
            temp.SALESDETAILRF_SALESSLIPCDDTLRF = reader.ReadInt32();
            //実績計上拠点コード
            temp.SALESSLIPRF_RESULTSADDUPSECCDRF = reader.ReadString();
            //入金入力拠点コード
            temp.DEPSITMAINRF_INPUTDEPOSITSECCDRF = reader.ReadString();
            //商品名称カナ
            temp.SALESDETAILRF_GOODSNAMEKANARF = reader.ReadString();
            //メーカーカナ名称
            temp.SALESDETAILRF_MAKERKANANAMERF = reader.ReadString();
            //車種半角名称
            temp.ACCEPTODRCARRF_MODELHALFNAMERF = reader.ReadString();
            //印刷用品番
            temp.SALESDETAILRF_PRTGOODSNORF = reader.ReadString();
            //印刷用メーカーコード
            temp.SALESDETAILRF_PRTMAKERCODERF = reader.ReadInt32();
            //印刷用メーカー名称
            temp.SALESDETAILRF_PRTMAKERNAMERF = reader.ReadString();
            //相手先伝票番号（ヘッダ用）
            temp.DADD_PARTYSALESLIPNUMRF = reader.ReadString();
            //消費税転嫁方式
            temp.SALESSLIPRF_CONSTAXLAYMETHODRF = reader.ReadInt32();


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
        /// <returns>EBooksFrePBillDetailWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   EBooksFrePBillDetailWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize( System.IO.BinaryReader reader )
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject( reader );
            ArrayList lst = new ArrayList();
            for ( int cnt = 0; cnt < serInfo.Occurrence; ++cnt )
            {
                EBooksFrePBillDetailWork temp = GetEBooksFrePBillDetailWork( reader, serInfo );
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
                    retValue = (EBooksFrePBillDetailWork[])lst.ToArray( typeof( EBooksFrePBillDetailWork ) );
                    break;
            }
            return retValue;
        }

        #endregion
    }

}
