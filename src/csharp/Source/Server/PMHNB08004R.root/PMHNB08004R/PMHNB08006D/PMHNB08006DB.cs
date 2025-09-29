using System;
using System.Collections;

//using Broadleaf.Library.Data; // DEL caohh 2011/08/17
using Broadleaf.Library.Runtime.Serialization;
using System.Drawing;
using System.IO;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   FrePSalesSlipWork
    /// <summary>
    ///                      自由帳票売上伝票データワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   自由帳票売上伝票データワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2008/3/25</br>
    /// <br>Genarated Date   :   2009/02/09  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2009.07.24 劉洋 add オートバックス設定追加</br>
    /// <br>Update Note      :   2010/03/01 30531  大矢 睦美</br>
    /// <br>                 :   Mantis【】得意先マスタの端数処理設定(３項目)追加</br>
    /// <br></br>
    /// <br>Update Note      :   2010/03/24 22018  鈴木 正臣</br>
    /// <br>                 :   ＱＲコード印刷対応の為、得意先マスタのＱＲコード印字区分を追加</br>
    /// <br></br>
    /// <br>Update Note      :   2010/07/06 30517 夏野 駿希</br>
    /// <br>                 :   QRコード携帯メール対応</br>
    /// <br>Update Note      :   2011/08/17 caohh</br>
    /// <br>                 :   リモート伝発：伝票P001対応</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class FrePSalesSlipWork
    {
        /// <summary>受注ステータス</summary>
        /// <remarks>10:見積,20:受注,30:売上,40:出荷</remarks>
        private Int32 _sALESSLIPRF_ACPTANODRSTATUSRF;

        /// <summary>売上伝票番号</summary>
        /// <remarks>見積伝票番号,受注伝票番号,出荷伝票番号,売上伝票番号を兼ねる。</remarks>
        private string _sALESSLIPRF_SALESSLIPNUMRF = "";

        /// <summary>拠点コード</summary>
        /// <remarks>※注意：伝票に印字しない。ログイン拠点。</remarks>
        private string _sALESSLIPRF_SECTIONCODERF = "";

        /// <summary>部門コード</summary>
        private Int32 _sALESSLIPRF_SUBSECTIONCODERF;

        /// <summary>赤伝区分</summary>
        /// <remarks>0:黒伝,1:赤伝,2:元黒</remarks>
        private Int32 _sALESSLIPRF_DEBITNOTEDIVRF;

        /// <summary>赤黒連結売上伝票番号</summary>
        /// <remarks>赤黒の相手方売上伝票番号</remarks>
        private string _sALESSLIPRF_DEBITNLNKSALESSLNUMRF = "";

        /// <summary>売上伝票区分</summary>
        /// <remarks>0:売上,1:返品</remarks>
        private Int32 _sALESSLIPRF_SALESSLIPCDRF;

        /// <summary>売上商品区分</summary>
        /// <remarks>0:商品,1:商品外,2:消費税調整,3:残高調整,4:売掛用消費税調整,5:売掛用残高調整,10:売掛用消費税調整(自動)</remarks>
        private Int32 _sALESSLIPRF_SALESGOODSCDRF;

        /// <summary>売掛区分</summary>
        /// <remarks>0:売掛なし,1:売掛</remarks>
        private Int32 _sALESSLIPRF_ACCRECDIVCDRF;

        /// <summary>伝票検索日付</summary>
        /// <remarks>YYYYMMDD　（更新年月日）</remarks>
        private Int32 _sALESSLIPRF_SEARCHSLIPDATERF;

        /// <summary>出荷日付</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _sALESSLIPRF_SHIPMENTDAYRF;

        /// <summary>売上日付</summary>
        /// <remarks>見積日、受注日、売上日を兼ねる。(YYYYMMDD)</remarks>
        private Int32 _sALESSLIPRF_SALESDATERF;

        /// <summary>計上日付</summary>
        /// <remarks>請求日　(YYYYMMDD)</remarks>
        private Int32 _sALESSLIPRF_ADDUPADATERF;

        /// <summary>来勘区分</summary>
        /// <remarks>0:当月(来勘なし),1:来月,2:再来月…9:9ヵ月後</remarks>
        private Int32 _sALESSLIPRF_DELAYPAYMENTDIVRF;

        /// <summary>見積書番号</summary>
        private string _sALESSLIPRF_ESTIMATEFORMNORF = "";

        /// <summary>見積区分</summary>
        /// <remarks>1:通常見積　2:単価見積</remarks>
        private Int32 _sALESSLIPRF_ESTIMATEDIVIDERF;

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

        /// <summary>総額表示方法区分</summary>
        /// <remarks>0:総額表示しない（税抜き）,1:総額表示する（税込み）</remarks>
        private Int32 _sALESSLIPRF_TOTALAMOUNTDISPWAYCDRF;

        /// <summary>総額表示掛率適用区分</summary>
        /// <remarks>0：基準価格(税込)×掛率, 1:基準価格(税抜)×掛率</remarks>
        private Int32 _sALESSLIPRF_TTLAMNTDISPRATEAPYRF;

        /// <summary>売上伝票合計（税込み）</summary>
        /// <remarks>売上正価金額＋売上値引金額計（税抜き）＋売上金額消費税額</remarks>
        private Int64 _sALESSLIPRF_SALESTOTALTAXINCRF;

        /// <summary>売上伝票合計（税抜き）</summary>
        /// <remarks>売上正価金額＋売上値引金額計（税抜き）</remarks>
        private Int64 _sALESSLIPRF_SALESTOTALTAXEXCRF;

        /// <summary>売上小計（税込み）</summary>
        /// <remarks>値引後の明細金額の合計（非課税含まず）</remarks>
        private Int64 _sALESSLIPRF_SALESSUBTOTALTAXINCRF;

        /// <summary>売上小計（税抜き）</summary>
        /// <remarks>値引後の明細金額の合計（非課税含まず）</remarks>
        private Int64 _sALESSLIPRF_SALESSUBTOTALTAXEXCRF;

        /// <summary>売上小計（税）</summary>
        /// <remarks>外税対象金額の集計（税抜、値引含まず）</remarks>
        private Int64 _sALESSLIPRF_SALESSUBTOTALTAXRF;

        /// <summary>売上外税対象額</summary>
        /// <remarks>内税対象金額の集計（税抜、値引含まず） </remarks>
        private Int64 _sALESSLIPRF_ITDEDSALESOUTTAXRF;

        /// <summary>売上内税対象額</summary>
        /// <remarks>非課税対象金額の集計（値引含まず）</remarks>
        private Int64 _sALESSLIPRF_ITDEDSALESINTAXRF;

        /// <summary>売上小計非課税対象額</summary>
        /// <remarks>売上金額消費税額（外税）+売上金額消費税額（内税）値引き含まず</remarks>
        private Int64 _sALESSLIPRF_SALSUBTTLSUBTOTAXFRERF;

        /// <summary>売上金額消費税額（内税）</summary>
        /// <remarks>値引前の内税商品の消費税</remarks>
        private Int64 _sALESSLIPRF_SALAMNTCONSTAXINCLURF;

        /// <summary>売上値引金額計（税抜き）</summary>
        private Int64 _sALESSLIPRF_SALESDISTTLTAXEXCRF;

        /// <summary>売上値引外税対象額合計</summary>
        /// <remarks>外税商品値引の外税対象額（税抜）</remarks>
        private Int64 _sALESSLIPRF_ITDEDSALESDISOUTTAXRF;

        /// <summary>売上値引内税対象額合計</summary>
        /// <remarks>内税商品値引の内税対象額（税抜）</remarks>
        private Int64 _sALESSLIPRF_ITDEDSALESDISINTAXRF;

        /// <summary>売上値引消費税額（外税）</summary>
        /// <remarks>外税商品値引の消費税額</remarks>
        private Int64 _sALESSLIPRF_SALESDISOUTTAXRF;

        /// <summary>売上値引消費税額（内税）</summary>
        private Int64 _sALESSLIPRF_SALESDISTTLTAXINCLURF;

        /// <summary>原価金額計</summary>
        private Int64 _sALESSLIPRF_TOTALCOSTRF;

        /// <summary>消費税転嫁方式</summary>
        /// <remarks>0:伝票単位1:明細単位2:請求親 3:請求子 9:非課税</remarks>
        private Int32 _sALESSLIPRF_CONSTAXLAYMETHODRF;

        /// <summary>消費税税率</summary>
        private Double _sALESSLIPRF_CONSTAXRATERF;

        /// <summary>端数処理区分</summary>
        /// <remarks>1:切捨て,2:四捨五入,3:切上げ　（消費税）</remarks>
        private Int32 _sALESSLIPRF_FRACTIONPROCCDRF;

        /// <summary>売掛消費税</summary>
        private Int64 _sALESSLIPRF_ACCRECCONSTAXRF;

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

        /// <summary>請求先略称</summary>
        private string _sALESSLIPRF_CLAIMSNMRF = "";

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

        /// <summary>納品先郵便番号</summary>
        /// <remarks>伝票住所区分に従う内容</remarks>
        private string _sALESSLIPRF_ADDRESSEEPOSTNORF = "";

        /// <summary>納品先住所1(都道府県市区郡・町村・字)</summary>
        /// <remarks>伝票住所区分に従う内容</remarks>
        private string _sALESSLIPRF_ADDRESSEEADDR1RF = "";

        /// <summary>納品先住所3(番地)</summary>
        /// <remarks>伝票住所区分に従う内容</remarks>
        private string _sALESSLIPRF_ADDRESSEEADDR3RF = "";

        /// <summary>納品先住所4(アパート名称)</summary>
        /// <remarks>伝票住所区分に従う内容</remarks>
        private string _sALESSLIPRF_ADDRESSEEADDR4RF = "";

        /// <summary>納品先電話番号</summary>
        /// <remarks>伝票住所区分に従う内容</remarks>
        private string _sALESSLIPRF_ADDRESSEETELNORF = "";

        /// <summary>納品先FAX番号</summary>
        /// <remarks>伝票住所区分に従う内容</remarks>
        private string _sALESSLIPRF_ADDRESSEEFAXNORF = "";

        /// <summary>相手先伝票番号</summary>
        /// <remarks>得意先注文番号</remarks>
        private string _sALESSLIPRF_PARTYSALESLIPNUMRF = "";

        /// <summary>伝票備考</summary>
        private string _sALESSLIPRF_SLIPNOTERF = "";

        /// <summary>伝票備考２</summary>
        private string _sALESSLIPRF_SLIPNOTE2RF = "";

        /// <summary>返品理由コード</summary>
        private Int32 _sALESSLIPRF_RETGOODSREASONDIVRF;

        /// <summary>返品理由</summary>
        private string _sALESSLIPRF_RETGOODSREASONRF = "";

        /// <summary>レジ処理日</summary>
        /// <remarks>YYYYMMDD　（サーバー未接続時、売上伝票発行するための情報）</remarks>
        private Int32 _sALESSLIPRF_REGIPROCDATERF;

        /// <summary>レジ番号</summary>
        /// <remarks>　　　　　（サーバー未接続時、売上伝票発行するための情報）</remarks>
        private Int32 _sALESSLIPRF_CASHREGISTERNORF;

        /// <summary>POSレシート番号</summary>
        /// <remarks>　　　　　（サーバー未接続時、売上伝票発行するための情報）</remarks>
        private Int32 _sALESSLIPRF_POSRECEIPTNORF;

        /// <summary>明細行数</summary>
        private Int32 _sALESSLIPRF_DETAILROWCOUNTRF;

        /// <summary>ＥＤＩ送信日</summary>
        /// <remarks>YYYYMMDD （ErectricDataInterface）</remarks>
        private Int32 _sALESSLIPRF_EDISENDDATERF;

        /// <summary>ＥＤＩ取込日</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _sALESSLIPRF_EDITAKEINDATERF;

        /// <summary>ＵＯＥリマーク１</summary>
        /// <remarks>UserOrderEntory</remarks>
        private string _sALESSLIPRF_UOEREMARK1RF = "";

        /// <summary>ＵＯＥリマーク２</summary>
        private string _sALESSLIPRF_UOEREMARK2RF = "";

        /// <summary>伝票発行済区分</summary>
        /// <remarks>0:未発行 1:発行済</remarks>
        private Int32 _sALESSLIPRF_SLIPPRINTFINISHCDRF;

        /// <summary>売上伝票発行日</summary>
        private Int32 _sALESSLIPRF_SALESSLIPPRINTDATERF;

        /// <summary>業種コード</summary>
        private Int32 _sALESSLIPRF_BUSINESSTYPECODERF;

        /// <summary>業種名称</summary>
        private string _sALESSLIPRF_BUSINESSTYPENAMERF = "";

        /// <summary>発注番号</summary>
        /// <remarks>売上形式＝"受注"の時にセット</remarks>
        private string _sALESSLIPRF_ORDERNUMBERRF = "";

        /// <summary>納品区分</summary>
        /// <remarks>例) 1:配達,2:店頭渡し,3:直送,…</remarks>
        private Int32 _sALESSLIPRF_DELIVEREDGOODSDIVRF;

        /// <summary>納品区分名称</summary>
        private string _sALESSLIPRF_DELIVEREDGOODSDIVNMRF = "";

        /// <summary>販売エリアコード</summary>
        /// <remarks>地区コード</remarks>
        private Int32 _sALESSLIPRF_SALESAREACODERF;

        /// <summary>販売エリア名称</summary>
        private string _sALESSLIPRF_SALESAREANAMERF = "";

        /// <summary>在庫商品合計金額（税抜）</summary>
        /// <remarks>在庫取寄区分が０の明細金額の集計</remarks>
        private Int64 _sALESSLIPRF_STOCKGOODSTTLTAXEXCRF;

        /// <summary>純正商品合計金額（税抜）</summary>
        /// <remarks>商品属性が０の明細金額の集計</remarks>
        private Int64 _sALESSLIPRF_PUREGOODSTTLTAXEXCRF;

        /// <summary>定価印刷区分</summary>
        private Int32 _sALESSLIPRF_LISTPRICEPRINTDIVRF;

        /// <summary>元号表示区分１</summary>
        /// <remarks>通常　　0:西暦　1:和暦</remarks>
        private Int32 _sALESSLIPRF_ERANAMEDISPCD1RF;

        /// <summary>見積消費税区分</summary>
        /// <remarks>0:非表示 1:外税（明細）2:総額表示 3:外税（伝票）</remarks>
        private Int32 _sALESSLIPRF_ESTIMATAXDIVCDRF;

        /// <summary>見積書印刷区分</summary>
        private Int32 _sALESSLIPRF_ESTIMATEFORMPRTCDRF;

        /// <summary>見積件名</summary>
        private string _sALESSLIPRF_ESTIMATESUBJECTRF = "";

        /// <summary>脚注１</summary>
        private string _sALESSLIPRF_FOOTNOTES1RF = "";

        /// <summary>脚注２</summary>
        private string _sALESSLIPRF_FOOTNOTES2RF = "";

        /// <summary>見積タイトル１</summary>
        private string _sALESSLIPRF_ESTIMATETITLE1RF = "";

        /// <summary>見積タイトル２</summary>
        private string _sALESSLIPRF_ESTIMATETITLE2RF = "";

        /// <summary>見積タイトル３</summary>
        private string _sALESSLIPRF_ESTIMATETITLE3RF = "";

        /// <summary>見積タイトル４</summary>
        private string _sALESSLIPRF_ESTIMATETITLE4RF = "";

        /// <summary>見積タイトル５</summary>
        private string _sALESSLIPRF_ESTIMATETITLE5RF = "";

        /// <summary>見積備考１</summary>
        private string _sALESSLIPRF_ESTIMATENOTE1RF = "";

        /// <summary>見積備考２</summary>
        private string _sALESSLIPRF_ESTIMATENOTE2RF = "";

        /// <summary>見積備考３</summary>
        private string _sALESSLIPRF_ESTIMATENOTE3RF = "";

        /// <summary>見積備考４</summary>
        private string _sALESSLIPRF_ESTIMATENOTE4RF = "";

        /// <summary>見積備考５</summary>
        private string _sALESSLIPRF_ESTIMATENOTE5RF = "";

        /// <summary>拠点ガイド名称</summary>
        /// <remarks>ＵＩ用（既存のコンボボックス等）</remarks>
        private string _sECINFOSETRF_SECTIONGUIDENMRF = "";

        /// <summary>拠点ガイド略称</summary>
        /// <remarks>帳票印字用</remarks>
        private string _sECINFOSETRF_SECTIONGUIDESNMRF = "";

        /// <summary>自社名称コード1</summary>
        private Int32 _sECINFOSETRF_COMPANYNAMECD1RF;

        /// <summary>自社PR文</summary>
        private string _cOMPANYNMRF_COMPANYPRRF = "";

        /// <summary>自社名称1</summary>
        private string _cOMPANYNMRF_COMPANYNAME1RF = "";

        /// <summary>自社名称2</summary>
        private string _cOMPANYNMRF_COMPANYNAME2RF = "";

        /// <summary>郵便番号</summary>
        private string _cOMPANYNMRF_POSTNORF = "";

        /// <summary>住所1（都道府県市区郡・町村・字）</summary>
        private string _cOMPANYNMRF_ADDRESS1RF = "";

        /// <summary>住所3（番地）</summary>
        private string _cOMPANYNMRF_ADDRESS3RF = "";

        /// <summary>住所4（アパート名称）</summary>
        private string _cOMPANYNMRF_ADDRESS4RF = "";

        /// <summary>自社電話番号1</summary>
        /// <remarks>TEL</remarks>
        private string _cOMPANYNMRF_COMPANYTELNO1RF = "";

        /// <summary>自社電話番号2</summary>
        /// <remarks>TEL2</remarks>
        private string _cOMPANYNMRF_COMPANYTELNO2RF = "";

        /// <summary>自社電話番号3</summary>
        /// <remarks>FAX</remarks>
        private string _cOMPANYNMRF_COMPANYTELNO3RF = "";

        /// <summary>自社電話番号タイトル1</summary>
        /// <remarks>TEL</remarks>
        private string _cOMPANYNMRF_COMPANYTELTITLE1RF = "";

        /// <summary>自社電話番号タイトル2</summary>
        /// <remarks>TEL2</remarks>
        private string _cOMPANYNMRF_COMPANYTELTITLE2RF = "";

        /// <summary>自社電話番号タイトル3</summary>
        /// <remarks>FAX</remarks>
        private string _cOMPANYNMRF_COMPANYTELTITLE3RF = "";

        /// <summary>銀行振込案内文</summary>
        private string _cOMPANYNMRF_TRANSFERGUIDANCERF = "";

        /// <summary>銀行口座1</summary>
        private string _cOMPANYNMRF_ACCOUNTNOINFO1RF = "";

        /// <summary>銀行口座2</summary>
        private string _cOMPANYNMRF_ACCOUNTNOINFO2RF = "";

        /// <summary>銀行口座3</summary>
        private string _cOMPANYNMRF_ACCOUNTNOINFO3RF = "";

        /// <summary>自社設定摘要1</summary>
        private string _cOMPANYNMRF_COMPANYSETNOTE1RF = "";

        /// <summary>自社設定摘要2</summary>
        private string _cOMPANYNMRF_COMPANYSETNOTE2RF = "";

        /// <summary>画像情報区分</summary>
        /// <remarks>10:自社画像,20:POSで使用する画像</remarks>
        private Int32 _cOMPANYNMRF_IMAGEINFODIVRF;

        /// <summary>画像情報コード</summary>
        private Int32 _cOMPANYNMRF_IMAGEINFOCODERF;

        /// <summary>自社URL</summary>
        private string _cOMPANYNMRF_COMPANYURLRF = "";

        /// <summary>自社PR文2</summary>
        /// <remarks>代表取締役等の情報を入力</remarks>
        private string _cOMPANYNMRF_COMPANYPRSENTENCE2RF = "";

        /// <summary>画像印字用コメント1</summary>
        /// <remarks>画像印字する場合、画像の下に印字する（拠点名等）</remarks>
        private string _cOMPANYNMRF_IMAGECOMMENTFORPRT1RF = "";

        /// <summary>画像印字用コメント2</summary>
        /// <remarks>画像印字する場合、画像の下に印字する（拠点名等）</remarks>
        private string _cOMPANYNMRF_IMAGECOMMENTFORPRT2RF = "";

        /// <summary>自社画像</summary>
        private Byte[] _iMAGEINFORF_IMAGEINFODATARF;

        /// <summary>部門名称</summary>
        private string _sUBSECTIONRF_SUBSECTIONNAMERF = "";

        /// <summary>売上入力者カナ</summary>
        private string _eMPINP_KANARF = "";

        /// <summary>売上入力者短縮名称</summary>
        private string _eMPINP_SHORTNAMERF = "";

        /// <summary>受付従業員カナ</summary>
        private string _eMPFRT_KANARF = "";

        /// <summary>受付従業員短縮名称</summary>
        private string _eMPFRT_SHORTNAMERF = "";

        /// <summary>販売従業員カナ</summary>
        private string _eMPSAL_KANARF = "";

        /// <summary>販売従業員短縮名称</summary>
        private string _eMPSAL_SHORTNAMERF = "";

        /// <summary>請求先サブコード</summary>
        private string _cSTCLM_CUSTOMERSUBCODERF = "";

        /// <summary>請求先名称</summary>
        /// <remarks>納入先の場合の使用可能項目</remarks>
        private string _cSTCLM_NAMERF = "";

        /// <summary>請求先名称2</summary>
        /// <remarks>納入先の場合の使用可能項目</remarks>
        private string _cSTCLM_NAME2RF = "";

        /// <summary>請求先敬称</summary>
        private string _cSTCLM_HONORIFICTITLERF = "";

        /// <summary>請求先カナ</summary>
        private string _cSTCLM_KANARF = "";

        /// <summary>請求先略称</summary>
        private string _cSTCLM_CUSTOMERSNMRF = "";

        /// <summary>請求先諸口コード</summary>
        /// <remarks>0:顧客名称1と2,1:顧客名称1,2:顧客名称2,3:諸口名称</remarks>
        private Int32 _cSTCLM_OUTPUTNAMECODERF;

        /// <summary>請求先分析コード1</summary>
        private Int32 _cSTCLM_CUSTANALYSCODE1RF;

        /// <summary>請求先分析コード2</summary>
        private Int32 _cSTCLM_CUSTANALYSCODE2RF;

        /// <summary>請求先分析コード3</summary>
        private Int32 _cSTCLM_CUSTANALYSCODE3RF;

        /// <summary>請求先分析コード4</summary>
        private Int32 _cSTCLM_CUSTANALYSCODE4RF;

        /// <summary>請求先分析コード5</summary>
        private Int32 _cSTCLM_CUSTANALYSCODE5RF;

        /// <summary>請求先分析コード6</summary>
        private Int32 _cSTCLM_CUSTANALYSCODE6RF;

        /// <summary>請求先備考1</summary>
        private string _cSTCLM_NOTE1RF = "";

        /// <summary>請求先備考2</summary>
        private string _cSTCLM_NOTE2RF = "";

        /// <summary>請求先備考3</summary>
        private string _cSTCLM_NOTE3RF = "";

        /// <summary>請求先備考4</summary>
        private string _cSTCLM_NOTE4RF = "";

        /// <summary>請求先備考5</summary>
        private string _cSTCLM_NOTE5RF = "";

        /// <summary>請求先備考6</summary>
        private string _cSTCLM_NOTE6RF = "";

        /// <summary>請求先備考7</summary>
        private string _cSTCLM_NOTE7RF = "";

        /// <summary>請求先備考8</summary>
        private string _cSTCLM_NOTE8RF = "";

        /// <summary>請求先備考9</summary>
        private string _cSTCLM_NOTE9RF = "";

        /// <summary>請求先備考10</summary>
        private string _cSTCLM_NOTE10RF = "";

        /// <summary>得意先サブコード</summary>
        private string _cSTCST_CUSTOMERSUBCODERF = "";

        /// <summary>得意先名称</summary>
        /// <remarks>納入先の場合の使用可能項目</remarks>
        private string _cSTCST_NAMERF = "";

        /// <summary>得意先名称2</summary>
        /// <remarks>納入先の場合の使用可能項目</remarks>
        private string _cSTCST_NAME2RF = "";

        /// <summary>得意先敬称</summary>
        private string _cSTCST_HONORIFICTITLERF = "";

        /// <summary>得意先カナ</summary>
        private string _cSTCST_KANARF = "";

        /// <summary>得意先略称</summary>
        private string _cSTCST_CUSTOMERSNMRF = "";

        /// <summary>得意先諸口コード</summary>
        /// <remarks>0:顧客名称1と2,1:顧客名称1,2:顧客名称2,3:諸口名称</remarks>
        private Int32 _cSTCST_OUTPUTNAMECODERF;

        /// <summary>得意先分析コード1</summary>
        private Int32 _cSTCST_CUSTANALYSCODE1RF;

        /// <summary>得意先分析コード2</summary>
        private Int32 _cSTCST_CUSTANALYSCODE2RF;

        /// <summary>得意先分析コード3</summary>
        private Int32 _cSTCST_CUSTANALYSCODE3RF;

        /// <summary>得意先分析コード4</summary>
        private Int32 _cSTCST_CUSTANALYSCODE4RF;

        /// <summary>得意先分析コード5</summary>
        private Int32 _cSTCST_CUSTANALYSCODE5RF;

        /// <summary>得意先分析コード6</summary>
        private Int32 _cSTCST_CUSTANALYSCODE6RF;

        /// <summary>得意先備考1</summary>
        private string _cSTCST_NOTE1RF = "";

        /// <summary>得意先備考2</summary>
        private string _cSTCST_NOTE2RF = "";

        /// <summary>得意先備考3</summary>
        private string _cSTCST_NOTE3RF = "";

        /// <summary>得意先備考4</summary>
        private string _cSTCST_NOTE4RF = "";

        /// <summary>得意先備考5</summary>
        private string _cSTCST_NOTE5RF = "";

        /// <summary>得意先備考6</summary>
        private string _cSTCST_NOTE6RF = "";

        /// <summary>得意先備考7</summary>
        private string _cSTCST_NOTE7RF = "";

        /// <summary>得意先備考8</summary>
        private string _cSTCST_NOTE8RF = "";

        /// <summary>得意先備考9</summary>
        private string _cSTCST_NOTE9RF = "";

        /// <summary>得意先備考10</summary>
        private string _cSTCST_NOTE10RF = "";

        /// <summary>納入先サブコード</summary>
        private string _cSTADR_CUSTOMERSUBCODERF = "";

        /// <summary>納入先名称</summary>
        /// <remarks>納入先の場合の使用可能項目</remarks>
        private string _cSTADR_NAMERF = "";

        /// <summary>納入先名称2</summary>
        /// <remarks>納入先の場合の使用可能項目</remarks>
        private string _cSTADR_NAME2RF = "";

        /// <summary>納入先敬称</summary>
        private string _cSTADR_HONORIFICTITLERF = "";

        /// <summary>納入先カナ</summary>
        private string _cSTADR_KANARF = "";

        /// <summary>納入先略称</summary>
        private string _cSTADR_CUSTOMERSNMRF = "";

        /// <summary>納入先諸口コード</summary>
        /// <remarks>0:顧客名称1と2,1:顧客名称1,2:顧客名称2,3:諸口名称</remarks>
        private Int32 _cSTADR_OUTPUTNAMECODERF;

        /// <summary>納入先分析コード1</summary>
        private Int32 _cSTADR_CUSTANALYSCODE1RF;

        /// <summary>納入先分析コード2</summary>
        private Int32 _cSTADR_CUSTANALYSCODE2RF;

        /// <summary>納入先分析コード3</summary>
        private Int32 _cSTADR_CUSTANALYSCODE3RF;

        /// <summary>納入先分析コード4</summary>
        private Int32 _cSTADR_CUSTANALYSCODE4RF;

        /// <summary>納入先分析コード5</summary>
        private Int32 _cSTADR_CUSTANALYSCODE5RF;

        /// <summary>納入先分析コード6</summary>
        private Int32 _cSTADR_CUSTANALYSCODE6RF;

        /// <summary>納入先備考1</summary>
        private string _cSTADR_NOTE1RF = "";

        /// <summary>納入先備考2</summary>
        private string _cSTADR_NOTE2RF = "";

        /// <summary>納入先備考3</summary>
        private string _cSTADR_NOTE3RF = "";

        /// <summary>納入先備考4</summary>
        private string _cSTADR_NOTE4RF = "";

        /// <summary>納入先備考5</summary>
        private string _cSTADR_NOTE5RF = "";

        /// <summary>納入先備考6</summary>
        private string _cSTADR_NOTE6RF = "";

        /// <summary>納入先備考7</summary>
        private string _cSTADR_NOTE7RF = "";

        /// <summary>納入先備考8</summary>
        private string _cSTADR_NOTE8RF = "";

        /// <summary>納入先備考9</summary>
        private string _cSTADR_NOTE9RF = "";

        /// <summary>納入先備考10</summary>
        private string _cSTADR_NOTE10RF = "";

        /// <summary>自社名称1</summary>
        private string _cOMPANYINFRF_COMPANYNAME1RF = "";

        /// <summary>自社名称2</summary>
        private string _cOMPANYINFRF_COMPANYNAME2RF = "";

        /// <summary>郵便番号</summary>
        private string _cOMPANYINFRF_POSTNORF = "";

        /// <summary>住所1（都道府県市区郡・町村・字）</summary>
        private string _cOMPANYINFRF_ADDRESS1RF = "";

        /// <summary>住所3（番地）</summary>
        private string _cOMPANYINFRF_ADDRESS3RF = "";

        /// <summary>住所4（アパート名称）</summary>
        private string _cOMPANYINFRF_ADDRESS4RF = "";

        /// <summary>自社電話番号1</summary>
        /// <remarks>TEL</remarks>
        private string _cOMPANYINFRF_COMPANYTELNO1RF = "";

        /// <summary>自社電話番号2</summary>
        /// <remarks>TEL2</remarks>
        private string _cOMPANYINFRF_COMPANYTELNO2RF = "";

        /// <summary>自社電話番号3</summary>
        /// <remarks>FAX</remarks>
        private string _cOMPANYINFRF_COMPANYTELNO3RF = "";

        /// <summary>自社電話番号タイトル1</summary>
        /// <remarks>TEL</remarks>
        private string _cOMPANYINFRF_COMPANYTELTITLE1RF = "";

        /// <summary>自社電話番号タイトル2</summary>
        /// <remarks>TEL2</remarks>
        private string _cOMPANYINFRF_COMPANYTELTITLE2RF = "";

        /// <summary>自社電話番号タイトル3</summary>
        /// <remarks>FAX</remarks>
        private string _cOMPANYINFRF_COMPANYTELTITLE3RF = "";

        /// <summary>受注ステータス名称</summary>
        /// <remarks>10:見積,20:受注,30:売上,40:出荷</remarks>
        private string _hADD_ACPTANODRSTNMRF = "";

        /// <summary>赤伝区分名称</summary>
        /// <remarks>0:黒伝,1:赤伝,2:元黒</remarks>
        private string _hADD_DEBITNOTEDIVNMRF = "";

        /// <summary>売上伝票区分名称</summary>
        /// <remarks>0:売上,1:返品</remarks>
        private string _hADD_SALESSLIPNMRF = "";

        /// <summary>売上商品区分名称</summary>
        /// <remarks>0:商品,1:商品外,2:消費税調整,3:残高調整,4:売掛用消費税調整,5:売掛用残高調整,10:売掛用消費税調整(自動)</remarks>
        private string _hADD_SALESGOODSNMRF = "";

        /// <summary>売掛区分名称</summary>
        /// <remarks>0:売掛なし,1:売掛</remarks>
        private string _hADD_ACCRECDIVNMRF = "";

        /// <summary>来勘区分名称</summary>
        /// <remarks>0:当月(来勘なし),1:来月,2:再来月…9:9ヵ月後</remarks>
        private string _hADD_DELAYPAYMENTDIVNMRF = "";

        /// <summary>見積区分名称</summary>
        /// <remarks>1:通常見積　2:単価見積</remarks>
        private string _hADD_ESTIMATEDIVIDENMRF = "";

        /// <summary>消費税転嫁方式名称</summary>
        /// <remarks>0:伝票単位1:明細単位2:請求親 3:請求子 9:非課税</remarks>
        private string _hADD_CONSTAXLAYMETHODNMRF = "";

        /// <summary>自動入金区分名称</summary>
        /// <remarks>0:通常入金,1:自動入金</remarks>
        private string _hADD_AUTODEPOSITNMRF = "";

        /// <summary>伝票発行済区分名称</summary>
        /// <remarks>0:未発行 1:発行済</remarks>
        private string _hADD_SLIPPRINTFINISHNMRF = "";

        /// <summary>一式伝票区分名称</summary>
        /// <remarks>0:通常伝票,1:一式伝票</remarks>
        private string _hADD_COMPLETENMRF = "";

        /// <summary>(先頭)車両管理番号</summary>
        /// <remarks>自動採番（無重複のシーケンス）PM7での車両SEQ</remarks>
        private Int32 _hADD_CARMNGNORF;

        /// <summary>(先頭)車輌管理コード</summary>
        /// <remarks>※PM7での車両管理番号</remarks>
        private string _hADD_CARMNGCODERF = "";

        /// <summary>(先頭)陸運事務所番号</summary>
        private Int32 _hADD_NUMBERPLATE1CODERF;

        /// <summary>(先頭)陸運事務局名称</summary>
        private string _hADD_NUMBERPLATE1NAMERF = "";

        /// <summary>(先頭)車両登録番号（種別）</summary>
        private string _hADD_NUMBERPLATE2RF = "";

        /// <summary>(先頭)車両登録番号（カナ）</summary>
        private string _hADD_NUMBERPLATE3RF = "";

        /// <summary>(先頭)車両登録番号（プレート番号）</summary>
        private Int32 _hADD_NUMBERPLATE4RF;

        /// <summary>(先頭)初年度</summary>
        /// <remarks>YYYYMM</remarks>
        private Int32 _hADD_FIRSTENTRYDATERF;

        /// <summary>(先頭)メーカーコード</summary>
        /// <remarks>1～899:提供分, 900～ユーザー登録</remarks>
        private Int32 _hADD_MAKERCODERF;

        /// <summary>(先頭)メーカー全角名称</summary>
        /// <remarks>正式名称（カナ漢字混在で全角管理）</remarks>
        private string _hADD_MAKERFULLNAMERF = "";

        /// <summary>(先頭)車種コード</summary>
        /// <remarks>車名コード(翼) 1～899:提供分, 900～ユーザー登録</remarks>
        private Int32 _hADD_MODELCODERF;

        /// <summary>(先頭)車種サブコード</summary>
        /// <remarks>0～899:提供分,900～ﾕｰｻﾞｰ登録</remarks>
        private Int32 _hADD_MODELSUBCODERF;

        /// <summary>(先頭)車種全角名称</summary>
        /// <remarks>正式名称（カナ漢字混在で全角管理）</remarks>
        private string _hADD_MODELFULLNAMERF = "";

        /// <summary>(先頭)排ガス記号</summary>
        private string _hADD_EXHAUSTGASSIGNRF = "";

        /// <summary>(先頭)シリーズ型式</summary>
        private string _hADD_SERIESMODELRF = "";

        /// <summary>(先頭)型式（類別記号）</summary>
        private string _hADD_CATEGORYSIGNMODELRF = "";

        /// <summary>(先頭)型式（フル型）</summary>
        /// <remarks>フル型式(44桁用)</remarks>
        private string _hADD_FULLMODELRF = "";

        /// <summary>(先頭)型式指定番号</summary>
        private Int32 _hADD_MODELDESIGNATIONNORF;

        /// <summary>(先頭)類別番号</summary>
        private Int32 _hADD_CATEGORYNORF;

        /// <summary>(先頭)車台型式</summary>
        private string _hADD_FRAMEMODELRF = "";

        /// <summary>(先頭)車台番号</summary>
        /// <remarks>車検証記載フォーマット対応（ HCR32-100251584 等）</remarks>
        private string _hADD_FRAMENORF = "";

        /// <summary>(先頭)車台番号（検索用）</summary>
        /// <remarks>PM7の車台番号と同意</remarks>
        private Int32 _hADD_SEARCHFRAMENORF;

        /// <summary>(先頭)エンジン型式名称</summary>
        /// <remarks>エンジン検索</remarks>
        private string _hADD_ENGINEMODELNMRF = "";

        /// <summary>(先頭)関連型式</summary>
        /// <remarks>リサイクル系で使用</remarks>
        private string _hADD_RELEVANCEMODELRF = "";

        /// <summary>(先頭)サブ車名コード</summary>
        /// <remarks>リサイクル系で使用</remarks>
        private Int32 _hADD_SUBCARNMCDRF;

        /// <summary>(先頭)型式グレード略称</summary>
        /// <remarks>リサイクル系で使用</remarks>
        private string _hADD_MODELGRADESNAMERF = "";

        /// <summary>(先頭)カラーコード</summary>
        /// <remarks>カタログの色コード</remarks>
        private string _hADD_COLORCODERF = "";

        /// <summary>(先頭)カラー名称1</summary>
        /// <remarks>画面表示用正式名称</remarks>
        private string _hADD_COLORNAME1RF = "";

        /// <summary>(先頭)トリムコード</summary>
        private string _hADD_TRIMCODERF = "";

        /// <summary>(先頭)トリム名称</summary>
        private string _hADD_TRIMNAMERF = "";

        /// <summary>(先頭)車両走行距離</summary>
        private Int32 _hADD_MILEAGERF;

        /// <summary>プリンタ管理No</summary>
        /// <remarks>※このレコードの伝票を印刷するプリンタの決定結果(default)</remarks>
        private Int32 _hADD_PRINTERMNGNORF;

        /// <summary>伝票印刷設定用帳票ID</summary>
        /// <remarks>※このレコードの伝票を印刷する伝票タイプの決定結果(default)</remarks>
        private string _hADD_SLIPPRTSETPAPERIDRF = "";

        /// <summary>自社備考１</summary>
        private string _hADD_NOTE1RF = "";

        /// <summary>自社備考２</summary>
        private string _hADD_NOTE2RF = "";

        /// <summary>自社備考３</summary>
        private string _hADD_NOTE3RF = "";

        /// <summary>再発行マーク</summary>
        /// <remarks>全角３文字まで</remarks>
        private string _hADD_REISSUEMARKRF = "";

        /// <summary>参考消費税印字名称</summary>
        /// <remarks>全角５文字まで</remarks>
        private string _hADD_REFCONSTAXPRTNMRF = "";

        /// <summary>印刷時刻 時</summary>
        /// <remarks>HH</remarks>
        private Int32 _hADD_PRINTTIMEHOURRF;

        /// <summary>印刷時刻 分</summary>
        /// <remarks>MM</remarks>
        private Int32 _hADD_PRINTTIMEMINUTERF;

        /// <summary>印刷時刻 秒</summary>
        /// <remarks>DD</remarks>
        private Int32 _hADD_PRINTTIMESECONDRF;

        /// <summary>伝票検索日付西暦年</summary>
        private Int32 _hADD_SEARCHSLIPDATEFYRF;

        /// <summary>伝票検索日付西暦年略</summary>
        private Int32 _hADD_SEARCHSLIPDATEFSRF;

        /// <summary>伝票検索日付和暦年</summary>
        private Int32 _hADD_SEARCHSLIPDATEFWRF;

        /// <summary>伝票検索日付月</summary>
        private Int32 _hADD_SEARCHSLIPDATEFMRF;

        /// <summary>伝票検索日付日</summary>
        private Int32 _hADD_SEARCHSLIPDATEFDRF;

        /// <summary>伝票検索日付元号</summary>
        private string _hADD_SEARCHSLIPDATEFGRF = "";

        /// <summary>伝票検索日付略号</summary>
        private string _hADD_SEARCHSLIPDATEFRRF = "";

        /// <summary>伝票検索日付リテラル(/)</summary>
        private string _hADD_SEARCHSLIPDATEFLSRF = "";

        /// <summary>伝票検索日付リテラル(.)</summary>
        private string _hADD_SEARCHSLIPDATEFLPRF = "";

        /// <summary>伝票検索日付リテラル(年)</summary>
        private string _hADD_SEARCHSLIPDATEFLYRF = "";

        /// <summary>伝票検索日付リテラル(月)</summary>
        private string _hADD_SEARCHSLIPDATEFLMRF = "";

        /// <summary>伝票検索日付リテラル(日)</summary>
        private string _hADD_SEARCHSLIPDATEFLDRF = "";

        /// <summary>出荷日付西暦年</summary>
        private Int32 _hADD_SHIPMENTDAYFYRF;

        /// <summary>出荷日付西暦年略</summary>
        private Int32 _hADD_SHIPMENTDAYFSRF;

        /// <summary>出荷日付和暦年</summary>
        private Int32 _hADD_SHIPMENTDAYFWRF;

        /// <summary>出荷日付月</summary>
        private Int32 _hADD_SHIPMENTDAYFMRF;

        /// <summary>出荷日付日</summary>
        private Int32 _hADD_SHIPMENTDAYFDRF;

        /// <summary>出荷日付元号</summary>
        private string _hADD_SHIPMENTDAYFGRF = "";

        /// <summary>出荷日付略号</summary>
        private string _hADD_SHIPMENTDAYFRRF = "";

        /// <summary>出荷日付リテラル(/)</summary>
        private string _hADD_SHIPMENTDAYFLSRF = "";

        /// <summary>出荷日付リテラル(.)</summary>
        private string _hADD_SHIPMENTDAYFLPRF = "";

        /// <summary>出荷日付リテラル(年)</summary>
        private string _hADD_SHIPMENTDAYFLYRF = "";

        /// <summary>出荷日付リテラル(月)</summary>
        private string _hADD_SHIPMENTDAYFLMRF = "";

        /// <summary>出荷日付リテラル(日)</summary>
        private string _hADD_SHIPMENTDAYFLDRF = "";

        /// <summary>売上日付西暦年</summary>
        private Int32 _hADD_SALESDATEFYRF;

        /// <summary>売上日付西暦年略</summary>
        private Int32 _hADD_SALESDATEFSRF;

        /// <summary>売上日付和暦年</summary>
        private Int32 _hADD_SALESDATEFWRF;

        /// <summary>売上日付月</summary>
        private Int32 _hADD_SALESDATEFMRF;

        /// <summary>売上日付日</summary>
        private Int32 _hADD_SALESDATEFDRF;

        /// <summary>売上日付元号</summary>
        private string _hADD_SALESDATEFGRF = "";

        /// <summary>売上日付略号</summary>
        private string _hADD_SALESDATEFRRF = "";

        /// <summary>売上日付リテラル(/)</summary>
        private string _hADD_SALESDATEFLSRF = "";

        /// <summary>売上日付リテラル(.)</summary>
        private string _hADD_SALESDATEFLPRF = "";

        /// <summary>売上日付リテラル(年)</summary>
        private string _hADD_SALESDATEFLYRF = "";

        /// <summary>売上日付リテラル(月)</summary>
        private string _hADD_SALESDATEFLMRF = "";

        /// <summary>売上日付リテラル(日)</summary>
        private string _hADD_SALESDATEFLDRF = "";

        /// <summary>計上日付西暦年</summary>
        private Int32 _hADD_ADDUPADATEFYRF;

        /// <summary>計上日付西暦年略</summary>
        private Int32 _hADD_ADDUPADATEFSRF;

        /// <summary>計上日付和暦年</summary>
        private Int32 _hADD_ADDUPADATEFWRF;

        /// <summary>計上日付月</summary>
        private Int32 _hADD_ADDUPADATEFMRF;

        /// <summary>計上日付日</summary>
        private Int32 _hADD_ADDUPADATEFDRF;

        /// <summary>計上日付元号</summary>
        private string _hADD_ADDUPADATEFGRF = "";

        /// <summary>計上日付略号</summary>
        private string _hADD_ADDUPADATEFRRF = "";

        /// <summary>計上日付リテラル(/)</summary>
        private string _hADD_ADDUPADATEFLSRF = "";

        /// <summary>計上日付リテラル(.)</summary>
        private string _hADD_ADDUPADATEFLPRF = "";

        /// <summary>計上日付リテラル(年)</summary>
        private string _hADD_ADDUPADATEFLYRF = "";

        /// <summary>計上日付リテラル(月)</summary>
        private string _hADD_ADDUPADATEFLMRF = "";

        /// <summary>計上日付リテラル(日)</summary>
        private string _hADD_ADDUPADATEFLDRF = "";

        /// <summary>売上伝票発行日西暦年</summary>
        private Int32 _hADD_SALESSLIPPRINTDATEFYRF;

        /// <summary>売上伝票発行日西暦年略</summary>
        private Int32 _hADD_SALESSLIPPRINTDATEFSRF;

        /// <summary>売上伝票発行日和暦年</summary>
        private Int32 _hADD_SALESSLIPPRINTDATEFWRF;

        /// <summary>売上伝票発行日月</summary>
        private Int32 _hADD_SALESSLIPPRINTDATEFMRF;

        /// <summary>売上伝票発行日日</summary>
        private Int32 _hADD_SALESSLIPPRINTDATEFDRF;

        /// <summary>売上伝票発行日元号</summary>
        private string _hADD_SALESSLIPPRINTDATEFGRF = "";

        /// <summary>売上伝票発行日略号</summary>
        private string _hADD_SALESSLIPPRINTDATEFRRF = "";

        /// <summary>売上伝票発行日リテラル(/)</summary>
        private string _hADD_SALESSLIPPRINTDATEFLSRF = "";

        /// <summary>売上伝票発行日リテラル(.)</summary>
        private string _hADD_SALESSLIPPRINTDATEFLPRF = "";

        /// <summary>売上伝票発行日リテラル(年)</summary>
        private string _hADD_SALESSLIPPRINTDATEFLYRF = "";

        /// <summary>売上伝票発行日リテラル(月)</summary>
        private string _hADD_SALESSLIPPRINTDATEFLMRF = "";

        /// <summary>売上伝票発行日リテラル(日)</summary>
        private string _hADD_SALESSLIPPRINTDATEFLDRF = "";

        /// <summary>(先頭)初年度西暦年</summary>
        private Int32 _hADD_FIRSTENTRYDATEFYRF;

        /// <summary>(先頭)初年度西暦年略</summary>
        private Int32 _hADD_FIRSTENTRYDATEFSRF;

        /// <summary>(先頭)初年度和暦年</summary>
        private Int32 _hADD_FIRSTENTRYDATEFWRF;

        /// <summary>(先頭)初年度月</summary>
        private Int32 _hADD_FIRSTENTRYDATEFMRF;

        /// <summary>(先頭)初年度日</summary>
        private Int32 _hADD_FIRSTENTRYDATEFDRF;

        /// <summary>(先頭)初年度元号</summary>
        private string _hADD_FIRSTENTRYDATEFGRF = "";

        /// <summary>(先頭)初年度略号</summary>
        private string _hADD_FIRSTENTRYDATEFRRF = "";

        /// <summary>(先頭)初年度リテラル(/)</summary>
        private string _hADD_FIRSTENTRYDATEFLSRF = "";

        /// <summary>(先頭)初年度リテラル(.)</summary>
        private string _hADD_FIRSTENTRYDATEFLPRF = "";

        /// <summary>(先頭)初年度リテラル(年)</summary>
        private string _hADD_FIRSTENTRYDATEFLYRF = "";

        /// <summary>(先頭)初年度リテラル(月)</summary>
        private string _hADD_FIRSTENTRYDATEFLMRF = "";

        /// <summary>(先頭)初年度リテラル(日)</summary>
        private string _hADD_FIRSTENTRYDATEFLDRF = "";

        /// <summary>印刷用得意先名称（上段）</summary>
        /// <remarks>名称２がないとき空白</remarks>
        private string _hADD_PRINTCUSTOMERNAME1RF = "";

        /// <summary>印刷用得意先名称（下段）</summary>
        /// <remarks>名称２がないとき名称１</remarks>
        private string _hADD_PRINTCUSTOMERNAME2RF = "";

        /// <summary>印刷用得意先名称（下段）＋敬称</summary>
        /// <remarks>名称２がないとき名称１＋空白＋敬称</remarks>
        private string _hADD_PRINTCUSTOMERNAME2HNRF = "";

        /// <summary>(先頭)メーカー半角名称</summary>
        private string _hADD_MAKERHALFNAMERF = "";

        /// <summary>(先頭)車種半角名称</summary>
        private string _hADD_MODELHALFNAMERF = "";

        /// <summary>伝票備考３</summary>
        private string _sALESSLIPRF_SLIPNOTE3RF = "";

        /// <summary>得意先名１＋得意先名２</summary>
        /// <remarks>名称１＋名称２</remarks>
        private string _hADD_PRINTCUSTOMERNAMEJOIN12RF = "";

        /// <summary>得意先名１＋得意先名２＋敬称</summary>
        /// <remarks>名称１＋名称２＋空白＋敬称</remarks>
        private string _hADD_PRINTCUSTOMERNAMEJOIN12HNRF = "";

        /// <summary>自社名１（前半）</summary>
        private string _hADD_PRINTENTERPRISENAME1FHRF = "";

        /// <summary>自社名１（後半）</summary>
        private string _hADD_PRINTENTERPRISENAME1LHRF = "";

        /// <summary>自社名２（前半）</summary>
        private string _hADD_PRINTENTERPRISENAME2FHRF = "";

        /// <summary>自社名２（後半）</summary>
        private string _hADD_PRINTENTERPRISENAME2LHRF = "";

        /// <summary>実績計上拠点コード</summary>
        /// <remarks>実績計上を行う企業内の拠点コード</remarks>
        private string _sALESSLIPRF_RESULTSADDUPSECCDRF = "";

        /// <summary>更新日時</summary>
        /// <remarks>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</remarks>
        private Int64 _sALESSLIPRF_UPDATEDATETIMERF;

        // --- ADD 2009.07.24 劉洋 ------ >>>>>>
        /// <summary>得意先コード</summary>
        private Int32 _sANDESETTINGRF_CUSTOMERCODE;

        /// <summary>納品先店舗コード</summary>
        private string _sANDESETTINGRF_ADDRESSEESHOPCD = "";

        /// <summary>住電管理コード</summary>
        private string _sANDESETTINGRF_SANDEMNGCODE = "";

        /// <summary>経費区分</summary>
        private Int32 _sANDESETTINGRF_EXPENSEDIVCD;

        /// <summary>直送区分</summary>
        private Int32 _sANDESETTINGRF_DIRECTSENDINGCD;

        /// <summary>受注区分</summary>
        private Int32 _sANDESETTINGRF_ACPTANORDERDIV;

        /// <summary>納品者コード</summary>
        private string _sANDESETTINGRF_DELIVERERCD = "";

        /// <summary>納品者名</summary>
        private string _sANDESETTINGRF_DELIVERERNM = "";

        /// <summary>納品者住所</summary>
        private string _sANDESETTINGRF_DELIVERERADDRESS = "";

        /// <summary>納品者ＴＥＬ</summary>
        private string _sANDESETTINGRF_DELIVERERPHONENUM = "";

        /// <summary>部品商名</summary>
        private string _sANDESETTINGRF_TRADCOMPNAME = "";

        /// <summary>部品商拠点名</summary>
        private string _sANDESETTINGRF_TRADCOMPSECTNAME = "";

        /// <summary>部品商コード（純正）</summary>
        private string _sANDESETTINGRF_PURETRADCOMPCD = "";

        /// <summary>部品商仕切率（純正）</summary>
        private Double _sANDESETTINGRF_PURETRADCOMPRATE;

        /// <summary>部品商コード（優良）</summary>
        private string _sANDESETTINGRF_PRITRADCOMPCD = "";

        /// <summary>部品商仕切率（優良）</summary>
        private Double _sANDESETTINGRF_PRITRADCOMPRATE;

        /// <summary>AB商品コード</summary>
        private string _sANDESETTINGRF_ABGOODSCODE = "";

        /// <summary>コメント指定区分</summary>
        /// <remarks>"７行目コメント指定区分"</remarks>
        private Int32 _sANDESETTINGRF_COMMENTRESERVEDDIV;

        /// <summary>商品メーカーコード１</summary>
        private Int32 _sANDESETTINGRF_GOODSMAKERCD1;

        /// <summary>商品メーカーコード２</summary>
        private Int32 _sANDESETTINGRF_GOODSMAKERCD2;

        /// <summary>商品メーカーコード３</summary>
        private Int32 _sANDESETTINGRF_GOODSMAKERCD3;

        /// <summary>商品メーカーコード４</summary>
        private Int32 _sANDESETTINGRF_GOODSMAKERCD4;

        /// <summary>商品メーカーコード５</summary>
        private Int32 _sANDESETTINGRF_GOODSMAKERCD5;

        /// <summary>商品メーカーコード６</summary>
        private Int32 _sANDESETTINGRF_GOODSMAKERCD6;

        /// <summary>商品メーカーコード７</summary>
        private Int32 _sANDESETTINGRF_GOODSMAKERCD7;

        /// <summary>商品メーカーコード８</summary>
        private Int32 _sANDESETTINGRF_GOODSMAKERCD8;

        /// <summary>商品メーカーコード９</summary>
        private Int32 _sANDESETTINGRF_GOODSMAKERCD9;

        /// <summary>商品メーカーコード１０</summary>
        private Int32 _sANDESETTINGRF_GOODSMAKERCD10;

        /// <summary>商品メーカーコード１１</summary>
        private Int32 _sANDESETTINGRF_GOODSMAKERCD11;

        /// <summary>商品メーカーコード１２</summary>
        private Int32 _sANDESETTINGRF_GOODSMAKERCD12;

        /// <summary>商品メーカーコード１３</summary>
        private Int32 _sANDESETTINGRF_GOODSMAKERCD13;

        /// <summary>商品メーカーコード１４</summary>
        private Int32 _sANDESETTINGRF_GOODSMAKERCD14;

        /// <summary>商品メーカーコード１５</summary>
        private Int32 _sANDESETTINGRF_GOODSMAKERCD15;

        /// <summary>部品ＯＥＭ区分</summary>
        private Int32 _sANDESETTINGRF_PARTSOEMDIV;
        // --- ADD 2009.07.24 劉洋 ------ <<<<<<
        // --- ADD  大矢睦美  2010/03/01 ---------->>>>>
        /// <summary>売上単価端数処理コード</summary>
        /// <remarks>0の場合は 標準設定とする。</remarks>
        private Int32 _cSTCST_SALESUNPRCFRCPROCCDRF;

        /// <summary>売上金額端数処理コード</summary>
        /// <remarks>0の場合は 標準設定とする。</remarks>
        private Int32 _cSTCST_SALESMONEYFRCPROCCDRF;

        /// <summary>売上消費税端数処理コード</summary>
        /// <remarks>0の場合は 標準設定とする。</remarks>
        private Int32 _cSTCST_SALESCNSTAXFRCPROCCDRF;
        // --- ADD  大矢睦美  2010/03/01 ----------<<<<<
        // --- ADD m.suzuki 2010/03/24 ---------->>>>>
        /// <summary>QRコード印刷</summary>
        /// <remarks>0:標準 1:印字しない 2:印字する 3:返品含む</remarks>
        private Int32 _cSTCST_QRCODEPRTCDRF;
        // --- ADD m.suzuki 2010/03/24 ----------<<<<<

        // 2010/07/06 Add >>>
        /// <summary>売上データヘッダガイド</summary>
        private Guid _sALESSLIPRF_FILEHEADERGUID;
        // 2010/07/06 Add <<<

        // ---- ADD caohh 2011/08/17 ------>>>>>
        /// <summary>郵便番号</summary>
        /// <remarks>納入先の場合の使用可能項目</remarks>
        private string _cSTCST_POSTNORF = "";

        /// <summary>住所1（都道府県市区郡・町村・字）</summary>
        /// <remarks>納入先の場合の使用可能項目</remarks>
        private string _cSTCST_ADDRESS1RF = "";

        /// <summary>住所3（番地）</summary>
        /// <remarks>納入先の場合の使用可能項目</remarks>
        private string _cSTCST_ADDRESS3RF = "";

        /// <summary>住所4（アパート名称）</summary>
        /// <remarks>納入先の場合の使用可能項目</remarks>
        private string _cSTCST_ADDRESS4RF = "";

        /// <summary>電話番号（自宅）</summary>
        private string _cSTCST_HOMETELNORF = "";

        /// <summary>電話番号（勤務先）</summary>
        /// <remarks>納入先の場合の使用可能項目</remarks>
        private string _cSTCST_OFFICETELNORF = "";

        /// <summary>電話番号（携帯）</summary>
        private string _cSTCST_PORTABLETELNORF = "";

        /// <summary>FAX番号（自宅）</summary>
        private string _cSTCST_HOMEFAXNORF = "";

        /// <summary>FAX番号（勤務先）</summary>
        /// <remarks>納入先の場合の使用可能項目</remarks>
        private string _cSTCST_OFFICEFAXNORF = "";

        /// <summary>電話番号（その他）</summary>
        private string _cSTCST_OTHERSTELNORF = "";
        // ---- ADD caohh 2011/08/17 ------<<<<<

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
        /// <value>※注意：伝票に印字しない。ログイン拠点。</value>
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

        /// public propaty name  :  SALESSLIPRF_DEBITNLNKSALESSLNUMRF
        /// <summary>赤黒連結売上伝票番号プロパティ</summary>
        /// <value>赤黒の相手方売上伝票番号</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   赤黒連結売上伝票番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SALESSLIPRF_DEBITNLNKSALESSLNUMRF
        {
            get { return _sALESSLIPRF_DEBITNLNKSALESSLNUMRF; }
            set { _sALESSLIPRF_DEBITNLNKSALESSLNUMRF = value; }
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

        /// public propaty name  :  SALESSLIPRF_SEARCHSLIPDATERF
        /// <summary>伝票検索日付プロパティ</summary>
        /// <value>YYYYMMDD　（更新年月日）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票検索日付プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SALESSLIPRF_SEARCHSLIPDATERF
        {
            get { return _sALESSLIPRF_SEARCHSLIPDATERF; }
            set { _sALESSLIPRF_SEARCHSLIPDATERF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_SHIPMENTDAYRF
        /// <summary>出荷日付プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   出荷日付プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SALESSLIPRF_SHIPMENTDAYRF
        {
            get { return _sALESSLIPRF_SHIPMENTDAYRF; }
            set { _sALESSLIPRF_SHIPMENTDAYRF = value; }
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

        /// public propaty name  :  SALESSLIPRF_DELAYPAYMENTDIVRF
        /// <summary>来勘区分プロパティ</summary>
        /// <value>0:当月(来勘なし),1:来月,2:再来月…9:9ヵ月後</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   来勘区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SALESSLIPRF_DELAYPAYMENTDIVRF
        {
            get { return _sALESSLIPRF_DELAYPAYMENTDIVRF; }
            set { _sALESSLIPRF_DELAYPAYMENTDIVRF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_ESTIMATEFORMNORF
        /// <summary>見積書番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   見積書番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SALESSLIPRF_ESTIMATEFORMNORF
        {
            get { return _sALESSLIPRF_ESTIMATEFORMNORF; }
            set { _sALESSLIPRF_ESTIMATEFORMNORF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_ESTIMATEDIVIDERF
        /// <summary>見積区分プロパティ</summary>
        /// <value>1:通常見積　2:単価見積</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   見積区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SALESSLIPRF_ESTIMATEDIVIDERF
        {
            get { return _sALESSLIPRF_ESTIMATEDIVIDERF; }
            set { _sALESSLIPRF_ESTIMATEDIVIDERF = value; }
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

        /// public propaty name  :  SALESSLIPRF_TOTALAMOUNTDISPWAYCDRF
        /// <summary>総額表示方法区分プロパティ</summary>
        /// <value>0:総額表示しない（税抜き）,1:総額表示する（税込み）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   総額表示方法区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SALESSLIPRF_TOTALAMOUNTDISPWAYCDRF
        {
            get { return _sALESSLIPRF_TOTALAMOUNTDISPWAYCDRF; }
            set { _sALESSLIPRF_TOTALAMOUNTDISPWAYCDRF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_TTLAMNTDISPRATEAPYRF
        /// <summary>総額表示掛率適用区分プロパティ</summary>
        /// <value>0：基準価格(税込)×掛率, 1:基準価格(税抜)×掛率</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   総額表示掛率適用区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SALESSLIPRF_TTLAMNTDISPRATEAPYRF
        {
            get { return _sALESSLIPRF_TTLAMNTDISPRATEAPYRF; }
            set { _sALESSLIPRF_TTLAMNTDISPRATEAPYRF = value; }
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

        /// public propaty name  :  SALESSLIPRF_ITDEDSALESOUTTAXRF
        /// <summary>売上外税対象額プロパティ</summary>
        /// <value>内税対象金額の集計（税抜、値引含まず） </value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上外税対象額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SALESSLIPRF_ITDEDSALESOUTTAXRF
        {
            get { return _sALESSLIPRF_ITDEDSALESOUTTAXRF; }
            set { _sALESSLIPRF_ITDEDSALESOUTTAXRF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_ITDEDSALESINTAXRF
        /// <summary>売上内税対象額プロパティ</summary>
        /// <value>非課税対象金額の集計（値引含まず）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上内税対象額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SALESSLIPRF_ITDEDSALESINTAXRF
        {
            get { return _sALESSLIPRF_ITDEDSALESINTAXRF; }
            set { _sALESSLIPRF_ITDEDSALESINTAXRF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_SALSUBTTLSUBTOTAXFRERF
        /// <summary>売上小計非課税対象額プロパティ</summary>
        /// <value>売上金額消費税額（外税）+売上金額消費税額（内税）値引き含まず</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上小計非課税対象額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SALESSLIPRF_SALSUBTTLSUBTOTAXFRERF
        {
            get { return _sALESSLIPRF_SALSUBTTLSUBTOTAXFRERF; }
            set { _sALESSLIPRF_SALSUBTTLSUBTOTAXFRERF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_SALAMNTCONSTAXINCLURF
        /// <summary>売上金額消費税額（内税）プロパティ</summary>
        /// <value>値引前の内税商品の消費税</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上金額消費税額（内税）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SALESSLIPRF_SALAMNTCONSTAXINCLURF
        {
            get { return _sALESSLIPRF_SALAMNTCONSTAXINCLURF; }
            set { _sALESSLIPRF_SALAMNTCONSTAXINCLURF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_SALESDISTTLTAXEXCRF
        /// <summary>売上値引金額計（税抜き）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上値引金額計（税抜き）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SALESSLIPRF_SALESDISTTLTAXEXCRF
        {
            get { return _sALESSLIPRF_SALESDISTTLTAXEXCRF; }
            set { _sALESSLIPRF_SALESDISTTLTAXEXCRF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_ITDEDSALESDISOUTTAXRF
        /// <summary>売上値引外税対象額合計プロパティ</summary>
        /// <value>外税商品値引の外税対象額（税抜）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上値引外税対象額合計プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SALESSLIPRF_ITDEDSALESDISOUTTAXRF
        {
            get { return _sALESSLIPRF_ITDEDSALESDISOUTTAXRF; }
            set { _sALESSLIPRF_ITDEDSALESDISOUTTAXRF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_ITDEDSALESDISINTAXRF
        /// <summary>売上値引内税対象額合計プロパティ</summary>
        /// <value>内税商品値引の内税対象額（税抜）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上値引内税対象額合計プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SALESSLIPRF_ITDEDSALESDISINTAXRF
        {
            get { return _sALESSLIPRF_ITDEDSALESDISINTAXRF; }
            set { _sALESSLIPRF_ITDEDSALESDISINTAXRF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_SALESDISOUTTAXRF
        /// <summary>売上値引消費税額（外税）プロパティ</summary>
        /// <value>外税商品値引の消費税額</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上値引消費税額（外税）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SALESSLIPRF_SALESDISOUTTAXRF
        {
            get { return _sALESSLIPRF_SALESDISOUTTAXRF; }
            set { _sALESSLIPRF_SALESDISOUTTAXRF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_SALESDISTTLTAXINCLURF
        /// <summary>売上値引消費税額（内税）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上値引消費税額（内税）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SALESSLIPRF_SALESDISTTLTAXINCLURF
        {
            get { return _sALESSLIPRF_SALESDISTTLTAXINCLURF; }
            set { _sALESSLIPRF_SALESDISTTLTAXINCLURF = value; }
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

        /// public propaty name  :  SALESSLIPRF_FRACTIONPROCCDRF
        /// <summary>端数処理区分プロパティ</summary>
        /// <value>1:切捨て,2:四捨五入,3:切上げ　（消費税）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   端数処理区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SALESSLIPRF_FRACTIONPROCCDRF
        {
            get { return _sALESSLIPRF_FRACTIONPROCCDRF; }
            set { _sALESSLIPRF_FRACTIONPROCCDRF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_ACCRECCONSTAXRF
        /// <summary>売掛消費税プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売掛消費税プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SALESSLIPRF_ACCRECCONSTAXRF
        {
            get { return _sALESSLIPRF_ACCRECCONSTAXRF; }
            set { _sALESSLIPRF_ACCRECCONSTAXRF = value; }
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

        /// public propaty name  :  SALESSLIPRF_CLAIMSNMRF
        /// <summary>請求先略称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   請求先略称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SALESSLIPRF_CLAIMSNMRF
        {
            get { return _sALESSLIPRF_CLAIMSNMRF; }
            set { _sALESSLIPRF_CLAIMSNMRF = value; }
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

        /// public propaty name  :  SALESSLIPRF_ADDRESSEEPOSTNORF
        /// <summary>納品先郵便番号プロパティ</summary>
        /// <value>伝票住所区分に従う内容</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   納品先郵便番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SALESSLIPRF_ADDRESSEEPOSTNORF
        {
            get { return _sALESSLIPRF_ADDRESSEEPOSTNORF; }
            set { _sALESSLIPRF_ADDRESSEEPOSTNORF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_ADDRESSEEADDR1RF
        /// <summary>納品先住所1(都道府県市区郡・町村・字)プロパティ</summary>
        /// <value>伝票住所区分に従う内容</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   納品先住所1(都道府県市区郡・町村・字)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SALESSLIPRF_ADDRESSEEADDR1RF
        {
            get { return _sALESSLIPRF_ADDRESSEEADDR1RF; }
            set { _sALESSLIPRF_ADDRESSEEADDR1RF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_ADDRESSEEADDR3RF
        /// <summary>納品先住所3(番地)プロパティ</summary>
        /// <value>伝票住所区分に従う内容</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   納品先住所3(番地)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SALESSLIPRF_ADDRESSEEADDR3RF
        {
            get { return _sALESSLIPRF_ADDRESSEEADDR3RF; }
            set { _sALESSLIPRF_ADDRESSEEADDR3RF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_ADDRESSEEADDR4RF
        /// <summary>納品先住所4(アパート名称)プロパティ</summary>
        /// <value>伝票住所区分に従う内容</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   納品先住所4(アパート名称)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SALESSLIPRF_ADDRESSEEADDR4RF
        {
            get { return _sALESSLIPRF_ADDRESSEEADDR4RF; }
            set { _sALESSLIPRF_ADDRESSEEADDR4RF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_ADDRESSEETELNORF
        /// <summary>納品先電話番号プロパティ</summary>
        /// <value>伝票住所区分に従う内容</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   納品先電話番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SALESSLIPRF_ADDRESSEETELNORF
        {
            get { return _sALESSLIPRF_ADDRESSEETELNORF; }
            set { _sALESSLIPRF_ADDRESSEETELNORF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_ADDRESSEEFAXNORF
        /// <summary>納品先FAX番号プロパティ</summary>
        /// <value>伝票住所区分に従う内容</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   納品先FAX番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SALESSLIPRF_ADDRESSEEFAXNORF
        {
            get { return _sALESSLIPRF_ADDRESSEEFAXNORF; }
            set { _sALESSLIPRF_ADDRESSEEFAXNORF = value; }
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

        /// public propaty name  :  SALESSLIPRF_REGIPROCDATERF
        /// <summary>レジ処理日プロパティ</summary>
        /// <value>YYYYMMDD　（サーバー未接続時、売上伝票発行するための情報）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   レジ処理日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SALESSLIPRF_REGIPROCDATERF
        {
            get { return _sALESSLIPRF_REGIPROCDATERF; }
            set { _sALESSLIPRF_REGIPROCDATERF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_CASHREGISTERNORF
        /// <summary>レジ番号プロパティ</summary>
        /// <value>　　　　　（サーバー未接続時、売上伝票発行するための情報）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   レジ番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SALESSLIPRF_CASHREGISTERNORF
        {
            get { return _sALESSLIPRF_CASHREGISTERNORF; }
            set { _sALESSLIPRF_CASHREGISTERNORF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_POSRECEIPTNORF
        /// <summary>POSレシート番号プロパティ</summary>
        /// <value>　　　　　（サーバー未接続時、売上伝票発行するための情報）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   POSレシート番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SALESSLIPRF_POSRECEIPTNORF
        {
            get { return _sALESSLIPRF_POSRECEIPTNORF; }
            set { _sALESSLIPRF_POSRECEIPTNORF = value; }
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

        /// public propaty name  :  SALESSLIPRF_EDISENDDATERF
        /// <summary>ＥＤＩ送信日プロパティ</summary>
        /// <value>YYYYMMDD （ErectricDataInterface）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ＥＤＩ送信日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SALESSLIPRF_EDISENDDATERF
        {
            get { return _sALESSLIPRF_EDISENDDATERF; }
            set { _sALESSLIPRF_EDISENDDATERF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_EDITAKEINDATERF
        /// <summary>ＥＤＩ取込日プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ＥＤＩ取込日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SALESSLIPRF_EDITAKEINDATERF
        {
            get { return _sALESSLIPRF_EDITAKEINDATERF; }
            set { _sALESSLIPRF_EDITAKEINDATERF = value; }
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

        /// public propaty name  :  SALESSLIPRF_SLIPPRINTFINISHCDRF
        /// <summary>伝票発行済区分プロパティ</summary>
        /// <value>0:未発行 1:発行済</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票発行済区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SALESSLIPRF_SLIPPRINTFINISHCDRF
        {
            get { return _sALESSLIPRF_SLIPPRINTFINISHCDRF; }
            set { _sALESSLIPRF_SLIPPRINTFINISHCDRF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_SALESSLIPPRINTDATERF
        /// <summary>売上伝票発行日プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上伝票発行日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SALESSLIPRF_SALESSLIPPRINTDATERF
        {
            get { return _sALESSLIPRF_SALESSLIPPRINTDATERF; }
            set { _sALESSLIPRF_SALESSLIPPRINTDATERF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_BUSINESSTYPECODERF
        /// <summary>業種コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   業種コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SALESSLIPRF_BUSINESSTYPECODERF
        {
            get { return _sALESSLIPRF_BUSINESSTYPECODERF; }
            set { _sALESSLIPRF_BUSINESSTYPECODERF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_BUSINESSTYPENAMERF
        /// <summary>業種名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   業種名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SALESSLIPRF_BUSINESSTYPENAMERF
        {
            get { return _sALESSLIPRF_BUSINESSTYPENAMERF; }
            set { _sALESSLIPRF_BUSINESSTYPENAMERF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_ORDERNUMBERRF
        /// <summary>発注番号プロパティ</summary>
        /// <value>売上形式＝"受注"の時にセット</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   発注番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SALESSLIPRF_ORDERNUMBERRF
        {
            get { return _sALESSLIPRF_ORDERNUMBERRF; }
            set { _sALESSLIPRF_ORDERNUMBERRF = value; }
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

        /// public propaty name  :  SALESSLIPRF_SALESAREACODERF
        /// <summary>販売エリアコードプロパティ</summary>
        /// <value>地区コード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   販売エリアコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SALESSLIPRF_SALESAREACODERF
        {
            get { return _sALESSLIPRF_SALESAREACODERF; }
            set { _sALESSLIPRF_SALESAREACODERF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_SALESAREANAMERF
        /// <summary>販売エリア名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   販売エリア名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SALESSLIPRF_SALESAREANAMERF
        {
            get { return _sALESSLIPRF_SALESAREANAMERF; }
            set { _sALESSLIPRF_SALESAREANAMERF = value; }
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

        /// public propaty name  :  SALESSLIPRF_LISTPRICEPRINTDIVRF
        /// <summary>定価印刷区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   定価印刷区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SALESSLIPRF_LISTPRICEPRINTDIVRF
        {
            get { return _sALESSLIPRF_LISTPRICEPRINTDIVRF; }
            set { _sALESSLIPRF_LISTPRICEPRINTDIVRF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_ERANAMEDISPCD1RF
        /// <summary>元号表示区分１プロパティ</summary>
        /// <value>通常　　0:西暦　1:和暦</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   元号表示区分１プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SALESSLIPRF_ERANAMEDISPCD1RF
        {
            get { return _sALESSLIPRF_ERANAMEDISPCD1RF; }
            set { _sALESSLIPRF_ERANAMEDISPCD1RF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_ESTIMATAXDIVCDRF
        /// <summary>見積消費税区分プロパティ</summary>
        /// <value>0:非表示 1:外税（明細）2:総額表示 3:外税（伝票）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   見積消費税区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SALESSLIPRF_ESTIMATAXDIVCDRF
        {
            get { return _sALESSLIPRF_ESTIMATAXDIVCDRF; }
            set { _sALESSLIPRF_ESTIMATAXDIVCDRF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_ESTIMATEFORMPRTCDRF
        /// <summary>見積書印刷区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   見積書印刷区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SALESSLIPRF_ESTIMATEFORMPRTCDRF
        {
            get { return _sALESSLIPRF_ESTIMATEFORMPRTCDRF; }
            set { _sALESSLIPRF_ESTIMATEFORMPRTCDRF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_ESTIMATESUBJECTRF
        /// <summary>見積件名プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   見積件名プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SALESSLIPRF_ESTIMATESUBJECTRF
        {
            get { return _sALESSLIPRF_ESTIMATESUBJECTRF; }
            set { _sALESSLIPRF_ESTIMATESUBJECTRF = value; }
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

        /// public propaty name  :  SALESSLIPRF_ESTIMATETITLE1RF
        /// <summary>見積タイトル１プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   見積タイトル１プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SALESSLIPRF_ESTIMATETITLE1RF
        {
            get { return _sALESSLIPRF_ESTIMATETITLE1RF; }
            set { _sALESSLIPRF_ESTIMATETITLE1RF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_ESTIMATETITLE2RF
        /// <summary>見積タイトル２プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   見積タイトル２プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SALESSLIPRF_ESTIMATETITLE2RF
        {
            get { return _sALESSLIPRF_ESTIMATETITLE2RF; }
            set { _sALESSLIPRF_ESTIMATETITLE2RF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_ESTIMATETITLE3RF
        /// <summary>見積タイトル３プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   見積タイトル３プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SALESSLIPRF_ESTIMATETITLE3RF
        {
            get { return _sALESSLIPRF_ESTIMATETITLE3RF; }
            set { _sALESSLIPRF_ESTIMATETITLE3RF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_ESTIMATETITLE4RF
        /// <summary>見積タイトル４プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   見積タイトル４プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SALESSLIPRF_ESTIMATETITLE4RF
        {
            get { return _sALESSLIPRF_ESTIMATETITLE4RF; }
            set { _sALESSLIPRF_ESTIMATETITLE4RF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_ESTIMATETITLE5RF
        /// <summary>見積タイトル５プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   見積タイトル５プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SALESSLIPRF_ESTIMATETITLE5RF
        {
            get { return _sALESSLIPRF_ESTIMATETITLE5RF; }
            set { _sALESSLIPRF_ESTIMATETITLE5RF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_ESTIMATENOTE1RF
        /// <summary>見積備考１プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   見積備考１プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SALESSLIPRF_ESTIMATENOTE1RF
        {
            get { return _sALESSLIPRF_ESTIMATENOTE1RF; }
            set { _sALESSLIPRF_ESTIMATENOTE1RF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_ESTIMATENOTE2RF
        /// <summary>見積備考２プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   見積備考２プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SALESSLIPRF_ESTIMATENOTE2RF
        {
            get { return _sALESSLIPRF_ESTIMATENOTE2RF; }
            set { _sALESSLIPRF_ESTIMATENOTE2RF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_ESTIMATENOTE3RF
        /// <summary>見積備考３プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   見積備考３プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SALESSLIPRF_ESTIMATENOTE3RF
        {
            get { return _sALESSLIPRF_ESTIMATENOTE3RF; }
            set { _sALESSLIPRF_ESTIMATENOTE3RF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_ESTIMATENOTE4RF
        /// <summary>見積備考４プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   見積備考４プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SALESSLIPRF_ESTIMATENOTE4RF
        {
            get { return _sALESSLIPRF_ESTIMATENOTE4RF; }
            set { _sALESSLIPRF_ESTIMATENOTE4RF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_ESTIMATENOTE5RF
        /// <summary>見積備考５プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   見積備考５プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SALESSLIPRF_ESTIMATENOTE5RF
        {
            get { return _sALESSLIPRF_ESTIMATENOTE5RF; }
            set { _sALESSLIPRF_ESTIMATENOTE5RF = value; }
        }

        /// public propaty name  :  SECINFOSETRF_SECTIONGUIDENMRF
        /// <summary>拠点ガイド名称プロパティ</summary>
        /// <value>ＵＩ用（既存のコンボボックス等）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点ガイド名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SECINFOSETRF_SECTIONGUIDENMRF
        {
            get { return _sECINFOSETRF_SECTIONGUIDENMRF; }
            set { _sECINFOSETRF_SECTIONGUIDENMRF = value; }
        }

        /// public propaty name  :  SECINFOSETRF_SECTIONGUIDESNMRF
        /// <summary>拠点ガイド略称プロパティ</summary>
        /// <value>帳票印字用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点ガイド略称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SECINFOSETRF_SECTIONGUIDESNMRF
        {
            get { return _sECINFOSETRF_SECTIONGUIDESNMRF; }
            set { _sECINFOSETRF_SECTIONGUIDESNMRF = value; }
        }

        /// public propaty name  :  SECINFOSETRF_COMPANYNAMECD1RF
        /// <summary>自社名称コード1プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社名称コード1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SECINFOSETRF_COMPANYNAMECD1RF
        {
            get { return _sECINFOSETRF_COMPANYNAMECD1RF; }
            set { _sECINFOSETRF_COMPANYNAMECD1RF = value; }
        }

        /// public propaty name  :  COMPANYNMRF_COMPANYPRRF
        /// <summary>自社PR文プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社PR文プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string COMPANYNMRF_COMPANYPRRF
        {
            get { return _cOMPANYNMRF_COMPANYPRRF; }
            set { _cOMPANYNMRF_COMPANYPRRF = value; }
        }

        /// public propaty name  :  COMPANYNMRF_COMPANYNAME1RF
        /// <summary>自社名称1プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社名称1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string COMPANYNMRF_COMPANYNAME1RF
        {
            get { return _cOMPANYNMRF_COMPANYNAME1RF; }
            set { _cOMPANYNMRF_COMPANYNAME1RF = value; }
        }

        /// public propaty name  :  COMPANYNMRF_COMPANYNAME2RF
        /// <summary>自社名称2プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社名称2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string COMPANYNMRF_COMPANYNAME2RF
        {
            get { return _cOMPANYNMRF_COMPANYNAME2RF; }
            set { _cOMPANYNMRF_COMPANYNAME2RF = value; }
        }

        /// public propaty name  :  COMPANYNMRF_POSTNORF
        /// <summary>郵便番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   郵便番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string COMPANYNMRF_POSTNORF
        {
            get { return _cOMPANYNMRF_POSTNORF; }
            set { _cOMPANYNMRF_POSTNORF = value; }
        }

        /// public propaty name  :  COMPANYNMRF_ADDRESS1RF
        /// <summary>住所1（都道府県市区郡・町村・字）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   住所1（都道府県市区郡・町村・字）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string COMPANYNMRF_ADDRESS1RF
        {
            get { return _cOMPANYNMRF_ADDRESS1RF; }
            set { _cOMPANYNMRF_ADDRESS1RF = value; }
        }

        /// public propaty name  :  COMPANYNMRF_ADDRESS3RF
        /// <summary>住所3（番地）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   住所3（番地）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string COMPANYNMRF_ADDRESS3RF
        {
            get { return _cOMPANYNMRF_ADDRESS3RF; }
            set { _cOMPANYNMRF_ADDRESS3RF = value; }
        }

        /// public propaty name  :  COMPANYNMRF_ADDRESS4RF
        /// <summary>住所4（アパート名称）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   住所4（アパート名称）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string COMPANYNMRF_ADDRESS4RF
        {
            get { return _cOMPANYNMRF_ADDRESS4RF; }
            set { _cOMPANYNMRF_ADDRESS4RF = value; }
        }

        /// public propaty name  :  COMPANYNMRF_COMPANYTELNO1RF
        /// <summary>自社電話番号1プロパティ</summary>
        /// <value>TEL</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社電話番号1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string COMPANYNMRF_COMPANYTELNO1RF
        {
            get { return _cOMPANYNMRF_COMPANYTELNO1RF; }
            set { _cOMPANYNMRF_COMPANYTELNO1RF = value; }
        }

        /// public propaty name  :  COMPANYNMRF_COMPANYTELNO2RF
        /// <summary>自社電話番号2プロパティ</summary>
        /// <value>TEL2</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社電話番号2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string COMPANYNMRF_COMPANYTELNO2RF
        {
            get { return _cOMPANYNMRF_COMPANYTELNO2RF; }
            set { _cOMPANYNMRF_COMPANYTELNO2RF = value; }
        }

        /// public propaty name  :  COMPANYNMRF_COMPANYTELNO3RF
        /// <summary>自社電話番号3プロパティ</summary>
        /// <value>FAX</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社電話番号3プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string COMPANYNMRF_COMPANYTELNO3RF
        {
            get { return _cOMPANYNMRF_COMPANYTELNO3RF; }
            set { _cOMPANYNMRF_COMPANYTELNO3RF = value; }
        }

        /// public propaty name  :  COMPANYNMRF_COMPANYTELTITLE1RF
        /// <summary>自社電話番号タイトル1プロパティ</summary>
        /// <value>TEL</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社電話番号タイトル1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string COMPANYNMRF_COMPANYTELTITLE1RF
        {
            get { return _cOMPANYNMRF_COMPANYTELTITLE1RF; }
            set { _cOMPANYNMRF_COMPANYTELTITLE1RF = value; }
        }

        /// public propaty name  :  COMPANYNMRF_COMPANYTELTITLE2RF
        /// <summary>自社電話番号タイトル2プロパティ</summary>
        /// <value>TEL2</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社電話番号タイトル2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string COMPANYNMRF_COMPANYTELTITLE2RF
        {
            get { return _cOMPANYNMRF_COMPANYTELTITLE2RF; }
            set { _cOMPANYNMRF_COMPANYTELTITLE2RF = value; }
        }

        /// public propaty name  :  COMPANYNMRF_COMPANYTELTITLE3RF
        /// <summary>自社電話番号タイトル3プロパティ</summary>
        /// <value>FAX</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社電話番号タイトル3プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string COMPANYNMRF_COMPANYTELTITLE3RF
        {
            get { return _cOMPANYNMRF_COMPANYTELTITLE3RF; }
            set { _cOMPANYNMRF_COMPANYTELTITLE3RF = value; }
        }

        /// public propaty name  :  COMPANYNMRF_TRANSFERGUIDANCERF
        /// <summary>銀行振込案内文プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   銀行振込案内文プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string COMPANYNMRF_TRANSFERGUIDANCERF
        {
            get { return _cOMPANYNMRF_TRANSFERGUIDANCERF; }
            set { _cOMPANYNMRF_TRANSFERGUIDANCERF = value; }
        }

        /// public propaty name  :  COMPANYNMRF_ACCOUNTNOINFO1RF
        /// <summary>銀行口座1プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   銀行口座1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string COMPANYNMRF_ACCOUNTNOINFO1RF
        {
            get { return _cOMPANYNMRF_ACCOUNTNOINFO1RF; }
            set { _cOMPANYNMRF_ACCOUNTNOINFO1RF = value; }
        }

        /// public propaty name  :  COMPANYNMRF_ACCOUNTNOINFO2RF
        /// <summary>銀行口座2プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   銀行口座2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string COMPANYNMRF_ACCOUNTNOINFO2RF
        {
            get { return _cOMPANYNMRF_ACCOUNTNOINFO2RF; }
            set { _cOMPANYNMRF_ACCOUNTNOINFO2RF = value; }
        }

        /// public propaty name  :  COMPANYNMRF_ACCOUNTNOINFO3RF
        /// <summary>銀行口座3プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   銀行口座3プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string COMPANYNMRF_ACCOUNTNOINFO3RF
        {
            get { return _cOMPANYNMRF_ACCOUNTNOINFO3RF; }
            set { _cOMPANYNMRF_ACCOUNTNOINFO3RF = value; }
        }

        /// public propaty name  :  COMPANYNMRF_COMPANYSETNOTE1RF
        /// <summary>自社設定摘要1プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社設定摘要1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string COMPANYNMRF_COMPANYSETNOTE1RF
        {
            get { return _cOMPANYNMRF_COMPANYSETNOTE1RF; }
            set { _cOMPANYNMRF_COMPANYSETNOTE1RF = value; }
        }

        /// public propaty name  :  COMPANYNMRF_COMPANYSETNOTE2RF
        /// <summary>自社設定摘要2プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社設定摘要2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string COMPANYNMRF_COMPANYSETNOTE2RF
        {
            get { return _cOMPANYNMRF_COMPANYSETNOTE2RF; }
            set { _cOMPANYNMRF_COMPANYSETNOTE2RF = value; }
        }

        /// public propaty name  :  COMPANYNMRF_IMAGEINFODIVRF
        /// <summary>画像情報区分プロパティ</summary>
        /// <value>10:自社画像,20:POSで使用する画像</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   画像情報区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 COMPANYNMRF_IMAGEINFODIVRF
        {
            get { return _cOMPANYNMRF_IMAGEINFODIVRF; }
            set { _cOMPANYNMRF_IMAGEINFODIVRF = value; }
        }

        /// public propaty name  :  COMPANYNMRF_IMAGEINFOCODERF
        /// <summary>画像情報コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   画像情報コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 COMPANYNMRF_IMAGEINFOCODERF
        {
            get { return _cOMPANYNMRF_IMAGEINFOCODERF; }
            set { _cOMPANYNMRF_IMAGEINFOCODERF = value; }
        }

        /// public propaty name  :  COMPANYNMRF_COMPANYURLRF
        /// <summary>自社URLプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社URLプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string COMPANYNMRF_COMPANYURLRF
        {
            get { return _cOMPANYNMRF_COMPANYURLRF; }
            set { _cOMPANYNMRF_COMPANYURLRF = value; }
        }

        /// public propaty name  :  COMPANYNMRF_COMPANYPRSENTENCE2RF
        /// <summary>自社PR文2プロパティ</summary>
        /// <value>代表取締役等の情報を入力</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社PR文2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string COMPANYNMRF_COMPANYPRSENTENCE2RF
        {
            get { return _cOMPANYNMRF_COMPANYPRSENTENCE2RF; }
            set { _cOMPANYNMRF_COMPANYPRSENTENCE2RF = value; }
        }

        /// public propaty name  :  COMPANYNMRF_IMAGECOMMENTFORPRT1RF
        /// <summary>画像印字用コメント1プロパティ</summary>
        /// <value>画像印字する場合、画像の下に印字する（拠点名等）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   画像印字用コメント1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string COMPANYNMRF_IMAGECOMMENTFORPRT1RF
        {
            get { return _cOMPANYNMRF_IMAGECOMMENTFORPRT1RF; }
            set { _cOMPANYNMRF_IMAGECOMMENTFORPRT1RF = value; }
        }

        /// public propaty name  :  COMPANYNMRF_IMAGECOMMENTFORPRT2RF
        /// <summary>画像印字用コメント2プロパティ</summary>
        /// <value>画像印字する場合、画像の下に印字する（拠点名等）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   画像印字用コメント2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string COMPANYNMRF_IMAGECOMMENTFORPRT2RF
        {
            get { return _cOMPANYNMRF_IMAGECOMMENTFORPRT2RF; }
            set { _cOMPANYNMRF_IMAGECOMMENTFORPRT2RF = value; }
        }

        /// public propaty name  :  IMAGEINFORF_IMAGEINFODATARF
        /// <summary>自社画像プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社画像プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Byte[] IMAGEINFORF_IMAGEINFODATARF
        {
            get { return _iMAGEINFORF_IMAGEINFODATARF; }
            set { _iMAGEINFORF_IMAGEINFODATARF = value; }
        }

        /// public propaty field.NameJp  :  IMAGEINFORF_IMAGEINFODATARFImageObject
        /// <summary>自社画像プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社画像プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Image IMAGEINFORF_IMAGEINFODATARFImageObject
        {
            get
            {
                if ( _iMAGEINFORF_IMAGEINFODATARF != null )
                {
                    MemoryStream mem = new MemoryStream( _iMAGEINFORF_IMAGEINFODATARF );
                    mem.Position = 0;
                    return Image.FromStream( mem );
                }
                else
                {
                    return null;
                }
            }
            set
            {
                _iMAGEINFORF_IMAGEINFODATARF = null;
                MemoryStream mem = new MemoryStream();
                Image img = value;
                img.Save( mem, System.Drawing.Imaging.ImageFormat.Bmp );
                _iMAGEINFORF_IMAGEINFODATARF = mem.ToArray();
            }
        }

        /// public propaty name  :  SUBSECTIONRF_SUBSECTIONNAMERF
        /// <summary>部門名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   部門名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SUBSECTIONRF_SUBSECTIONNAMERF
        {
            get { return _sUBSECTIONRF_SUBSECTIONNAMERF; }
            set { _sUBSECTIONRF_SUBSECTIONNAMERF = value; }
        }

        /// public propaty name  :  EMPINP_KANARF
        /// <summary>売上入力者カナプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上入力者カナプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EMPINP_KANARF
        {
            get { return _eMPINP_KANARF; }
            set { _eMPINP_KANARF = value; }
        }

        /// public propaty name  :  EMPINP_SHORTNAMERF
        /// <summary>売上入力者短縮名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上入力者短縮名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EMPINP_SHORTNAMERF
        {
            get { return _eMPINP_SHORTNAMERF; }
            set { _eMPINP_SHORTNAMERF = value; }
        }

        /// public propaty name  :  EMPFRT_KANARF
        /// <summary>受付従業員カナプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   受付従業員カナプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EMPFRT_KANARF
        {
            get { return _eMPFRT_KANARF; }
            set { _eMPFRT_KANARF = value; }
        }

        /// public propaty name  :  EMPFRT_SHORTNAMERF
        /// <summary>受付従業員短縮名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   受付従業員短縮名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EMPFRT_SHORTNAMERF
        {
            get { return _eMPFRT_SHORTNAMERF; }
            set { _eMPFRT_SHORTNAMERF = value; }
        }

        /// public propaty name  :  EMPSAL_KANARF
        /// <summary>販売従業員カナプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   販売従業員カナプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EMPSAL_KANARF
        {
            get { return _eMPSAL_KANARF; }
            set { _eMPSAL_KANARF = value; }
        }

        /// public propaty name  :  EMPSAL_SHORTNAMERF
        /// <summary>販売従業員短縮名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   販売従業員短縮名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EMPSAL_SHORTNAMERF
        {
            get { return _eMPSAL_SHORTNAMERF; }
            set { _eMPSAL_SHORTNAMERF = value; }
        }

        /// public propaty name  :  CSTCLM_CUSTOMERSUBCODERF
        /// <summary>請求先サブコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   請求先サブコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CSTCLM_CUSTOMERSUBCODERF
        {
            get { return _cSTCLM_CUSTOMERSUBCODERF; }
            set { _cSTCLM_CUSTOMERSUBCODERF = value; }
        }

        /// public propaty name  :  CSTCLM_NAMERF
        /// <summary>請求先名称プロパティ</summary>
        /// <value>納入先の場合の使用可能項目</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   請求先名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CSTCLM_NAMERF
        {
            get { return _cSTCLM_NAMERF; }
            set { _cSTCLM_NAMERF = value; }
        }

        /// public propaty name  :  CSTCLM_NAME2RF
        /// <summary>請求先名称2プロパティ</summary>
        /// <value>納入先の場合の使用可能項目</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   請求先名称2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CSTCLM_NAME2RF
        {
            get { return _cSTCLM_NAME2RF; }
            set { _cSTCLM_NAME2RF = value; }
        }

        /// public propaty name  :  CSTCLM_HONORIFICTITLERF
        /// <summary>請求先敬称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   請求先敬称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CSTCLM_HONORIFICTITLERF
        {
            get { return _cSTCLM_HONORIFICTITLERF; }
            set { _cSTCLM_HONORIFICTITLERF = value; }
        }

        /// public propaty name  :  CSTCLM_KANARF
        /// <summary>請求先カナプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   請求先カナプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CSTCLM_KANARF
        {
            get { return _cSTCLM_KANARF; }
            set { _cSTCLM_KANARF = value; }
        }

        /// public propaty name  :  CSTCLM_CUSTOMERSNMRF
        /// <summary>請求先略称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   請求先略称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CSTCLM_CUSTOMERSNMRF
        {
            get { return _cSTCLM_CUSTOMERSNMRF; }
            set { _cSTCLM_CUSTOMERSNMRF = value; }
        }

        /// public propaty name  :  CSTCLM_OUTPUTNAMECODERF
        /// <summary>請求先諸口コードプロパティ</summary>
        /// <value>0:顧客名称1と2,1:顧客名称1,2:顧客名称2,3:諸口名称</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   請求先諸口コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CSTCLM_OUTPUTNAMECODERF
        {
            get { return _cSTCLM_OUTPUTNAMECODERF; }
            set { _cSTCLM_OUTPUTNAMECODERF = value; }
        }

        /// public propaty name  :  CSTCLM_CUSTANALYSCODE1RF
        /// <summary>請求先分析コード1プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   請求先分析コード1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CSTCLM_CUSTANALYSCODE1RF
        {
            get { return _cSTCLM_CUSTANALYSCODE1RF; }
            set { _cSTCLM_CUSTANALYSCODE1RF = value; }
        }

        /// public propaty name  :  CSTCLM_CUSTANALYSCODE2RF
        /// <summary>請求先分析コード2プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   請求先分析コード2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CSTCLM_CUSTANALYSCODE2RF
        {
            get { return _cSTCLM_CUSTANALYSCODE2RF; }
            set { _cSTCLM_CUSTANALYSCODE2RF = value; }
        }

        /// public propaty name  :  CSTCLM_CUSTANALYSCODE3RF
        /// <summary>請求先分析コード3プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   請求先分析コード3プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CSTCLM_CUSTANALYSCODE3RF
        {
            get { return _cSTCLM_CUSTANALYSCODE3RF; }
            set { _cSTCLM_CUSTANALYSCODE3RF = value; }
        }

        /// public propaty name  :  CSTCLM_CUSTANALYSCODE4RF
        /// <summary>請求先分析コード4プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   請求先分析コード4プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CSTCLM_CUSTANALYSCODE4RF
        {
            get { return _cSTCLM_CUSTANALYSCODE4RF; }
            set { _cSTCLM_CUSTANALYSCODE4RF = value; }
        }

        /// public propaty name  :  CSTCLM_CUSTANALYSCODE5RF
        /// <summary>請求先分析コード5プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   請求先分析コード5プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CSTCLM_CUSTANALYSCODE5RF
        {
            get { return _cSTCLM_CUSTANALYSCODE5RF; }
            set { _cSTCLM_CUSTANALYSCODE5RF = value; }
        }

        /// public propaty name  :  CSTCLM_CUSTANALYSCODE6RF
        /// <summary>請求先分析コード6プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   請求先分析コード6プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CSTCLM_CUSTANALYSCODE6RF
        {
            get { return _cSTCLM_CUSTANALYSCODE6RF; }
            set { _cSTCLM_CUSTANALYSCODE6RF = value; }
        }

        /// public propaty name  :  CSTCLM_NOTE1RF
        /// <summary>請求先備考1プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   請求先備考1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CSTCLM_NOTE1RF
        {
            get { return _cSTCLM_NOTE1RF; }
            set { _cSTCLM_NOTE1RF = value; }
        }

        /// public propaty name  :  CSTCLM_NOTE2RF
        /// <summary>請求先備考2プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   請求先備考2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CSTCLM_NOTE2RF
        {
            get { return _cSTCLM_NOTE2RF; }
            set { _cSTCLM_NOTE2RF = value; }
        }

        /// public propaty name  :  CSTCLM_NOTE3RF
        /// <summary>請求先備考3プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   請求先備考3プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CSTCLM_NOTE3RF
        {
            get { return _cSTCLM_NOTE3RF; }
            set { _cSTCLM_NOTE3RF = value; }
        }

        /// public propaty name  :  CSTCLM_NOTE4RF
        /// <summary>請求先備考4プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   請求先備考4プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CSTCLM_NOTE4RF
        {
            get { return _cSTCLM_NOTE4RF; }
            set { _cSTCLM_NOTE4RF = value; }
        }

        /// public propaty name  :  CSTCLM_NOTE5RF
        /// <summary>請求先備考5プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   請求先備考5プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CSTCLM_NOTE5RF
        {
            get { return _cSTCLM_NOTE5RF; }
            set { _cSTCLM_NOTE5RF = value; }
        }

        /// public propaty name  :  CSTCLM_NOTE6RF
        /// <summary>請求先備考6プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   請求先備考6プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CSTCLM_NOTE6RF
        {
            get { return _cSTCLM_NOTE6RF; }
            set { _cSTCLM_NOTE6RF = value; }
        }

        /// public propaty name  :  CSTCLM_NOTE7RF
        /// <summary>請求先備考7プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   請求先備考7プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CSTCLM_NOTE7RF
        {
            get { return _cSTCLM_NOTE7RF; }
            set { _cSTCLM_NOTE7RF = value; }
        }

        /// public propaty name  :  CSTCLM_NOTE8RF
        /// <summary>請求先備考8プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   請求先備考8プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CSTCLM_NOTE8RF
        {
            get { return _cSTCLM_NOTE8RF; }
            set { _cSTCLM_NOTE8RF = value; }
        }

        /// public propaty name  :  CSTCLM_NOTE9RF
        /// <summary>請求先備考9プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   請求先備考9プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CSTCLM_NOTE9RF
        {
            get { return _cSTCLM_NOTE9RF; }
            set { _cSTCLM_NOTE9RF = value; }
        }

        /// public propaty name  :  CSTCLM_NOTE10RF
        /// <summary>請求先備考10プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   請求先備考10プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CSTCLM_NOTE10RF
        {
            get { return _cSTCLM_NOTE10RF; }
            set { _cSTCLM_NOTE10RF = value; }
        }

        /// public propaty name  :  CSTCST_CUSTOMERSUBCODERF
        /// <summary>得意先サブコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先サブコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CSTCST_CUSTOMERSUBCODERF
        {
            get { return _cSTCST_CUSTOMERSUBCODERF; }
            set { _cSTCST_CUSTOMERSUBCODERF = value; }
        }

        /// public propaty name  :  CSTCST_NAMERF
        /// <summary>得意先名称プロパティ</summary>
        /// <value>納入先の場合の使用可能項目</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CSTCST_NAMERF
        {
            get { return _cSTCST_NAMERF; }
            set { _cSTCST_NAMERF = value; }
        }

        /// public propaty name  :  CSTCST_NAME2RF
        /// <summary>得意先名称2プロパティ</summary>
        /// <value>納入先の場合の使用可能項目</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先名称2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CSTCST_NAME2RF
        {
            get { return _cSTCST_NAME2RF; }
            set { _cSTCST_NAME2RF = value; }
        }

        /// public propaty name  :  CSTCST_HONORIFICTITLERF
        /// <summary>得意先敬称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先敬称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CSTCST_HONORIFICTITLERF
        {
            get { return _cSTCST_HONORIFICTITLERF; }
            set { _cSTCST_HONORIFICTITLERF = value; }
        }

        /// public propaty name  :  CSTCST_KANARF
        /// <summary>得意先カナプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先カナプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CSTCST_KANARF
        {
            get { return _cSTCST_KANARF; }
            set { _cSTCST_KANARF = value; }
        }

        /// public propaty name  :  CSTCST_CUSTOMERSNMRF
        /// <summary>得意先略称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先略称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CSTCST_CUSTOMERSNMRF
        {
            get { return _cSTCST_CUSTOMERSNMRF; }
            set { _cSTCST_CUSTOMERSNMRF = value; }
        }

        /// public propaty name  :  CSTCST_OUTPUTNAMECODERF
        /// <summary>得意先諸口コードプロパティ</summary>
        /// <value>0:顧客名称1と2,1:顧客名称1,2:顧客名称2,3:諸口名称</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先諸口コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CSTCST_OUTPUTNAMECODERF
        {
            get { return _cSTCST_OUTPUTNAMECODERF; }
            set { _cSTCST_OUTPUTNAMECODERF = value; }
        }

        /// public propaty name  :  CSTCST_CUSTANALYSCODE1RF
        /// <summary>得意先分析コード1プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先分析コード1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CSTCST_CUSTANALYSCODE1RF
        {
            get { return _cSTCST_CUSTANALYSCODE1RF; }
            set { _cSTCST_CUSTANALYSCODE1RF = value; }
        }

        /// public propaty name  :  CSTCST_CUSTANALYSCODE2RF
        /// <summary>得意先分析コード2プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先分析コード2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CSTCST_CUSTANALYSCODE2RF
        {
            get { return _cSTCST_CUSTANALYSCODE2RF; }
            set { _cSTCST_CUSTANALYSCODE2RF = value; }
        }

        /// public propaty name  :  CSTCST_CUSTANALYSCODE3RF
        /// <summary>得意先分析コード3プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先分析コード3プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CSTCST_CUSTANALYSCODE3RF
        {
            get { return _cSTCST_CUSTANALYSCODE3RF; }
            set { _cSTCST_CUSTANALYSCODE3RF = value; }
        }

        /// public propaty name  :  CSTCST_CUSTANALYSCODE4RF
        /// <summary>得意先分析コード4プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先分析コード4プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CSTCST_CUSTANALYSCODE4RF
        {
            get { return _cSTCST_CUSTANALYSCODE4RF; }
            set { _cSTCST_CUSTANALYSCODE4RF = value; }
        }

        /// public propaty name  :  CSTCST_CUSTANALYSCODE5RF
        /// <summary>得意先分析コード5プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先分析コード5プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CSTCST_CUSTANALYSCODE5RF
        {
            get { return _cSTCST_CUSTANALYSCODE5RF; }
            set { _cSTCST_CUSTANALYSCODE5RF = value; }
        }

        /// public propaty name  :  CSTCST_CUSTANALYSCODE6RF
        /// <summary>得意先分析コード6プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先分析コード6プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CSTCST_CUSTANALYSCODE6RF
        {
            get { return _cSTCST_CUSTANALYSCODE6RF; }
            set { _cSTCST_CUSTANALYSCODE6RF = value; }
        }

        /// public propaty name  :  CSTCST_NOTE1RF
        /// <summary>得意先備考1プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先備考1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CSTCST_NOTE1RF
        {
            get { return _cSTCST_NOTE1RF; }
            set { _cSTCST_NOTE1RF = value; }
        }

        /// public propaty name  :  CSTCST_NOTE2RF
        /// <summary>得意先備考2プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先備考2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CSTCST_NOTE2RF
        {
            get { return _cSTCST_NOTE2RF; }
            set { _cSTCST_NOTE2RF = value; }
        }

        /// public propaty name  :  CSTCST_NOTE3RF
        /// <summary>得意先備考3プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先備考3プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CSTCST_NOTE3RF
        {
            get { return _cSTCST_NOTE3RF; }
            set { _cSTCST_NOTE3RF = value; }
        }

        /// public propaty name  :  CSTCST_NOTE4RF
        /// <summary>得意先備考4プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先備考4プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CSTCST_NOTE4RF
        {
            get { return _cSTCST_NOTE4RF; }
            set { _cSTCST_NOTE4RF = value; }
        }

        /// public propaty name  :  CSTCST_NOTE5RF
        /// <summary>得意先備考5プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先備考5プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CSTCST_NOTE5RF
        {
            get { return _cSTCST_NOTE5RF; }
            set { _cSTCST_NOTE5RF = value; }
        }

        /// public propaty name  :  CSTCST_NOTE6RF
        /// <summary>得意先備考6プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先備考6プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CSTCST_NOTE6RF
        {
            get { return _cSTCST_NOTE6RF; }
            set { _cSTCST_NOTE6RF = value; }
        }

        /// public propaty name  :  CSTCST_NOTE7RF
        /// <summary>得意先備考7プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先備考7プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CSTCST_NOTE7RF
        {
            get { return _cSTCST_NOTE7RF; }
            set { _cSTCST_NOTE7RF = value; }
        }

        /// public propaty name  :  CSTCST_NOTE8RF
        /// <summary>得意先備考8プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先備考8プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CSTCST_NOTE8RF
        {
            get { return _cSTCST_NOTE8RF; }
            set { _cSTCST_NOTE8RF = value; }
        }

        /// public propaty name  :  CSTCST_NOTE9RF
        /// <summary>得意先備考9プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先備考9プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CSTCST_NOTE9RF
        {
            get { return _cSTCST_NOTE9RF; }
            set { _cSTCST_NOTE9RF = value; }
        }

        /// public propaty name  :  CSTCST_NOTE10RF
        /// <summary>得意先備考10プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先備考10プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CSTCST_NOTE10RF
        {
            get { return _cSTCST_NOTE10RF; }
            set { _cSTCST_NOTE10RF = value; }
        }

        /// public propaty name  :  CSTADR_CUSTOMERSUBCODERF
        /// <summary>納入先サブコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   納入先サブコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CSTADR_CUSTOMERSUBCODERF
        {
            get { return _cSTADR_CUSTOMERSUBCODERF; }
            set { _cSTADR_CUSTOMERSUBCODERF = value; }
        }

        /// public propaty name  :  CSTADR_NAMERF
        /// <summary>納入先名称プロパティ</summary>
        /// <value>納入先の場合の使用可能項目</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   納入先名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CSTADR_NAMERF
        {
            get { return _cSTADR_NAMERF; }
            set { _cSTADR_NAMERF = value; }
        }

        /// public propaty name  :  CSTADR_NAME2RF
        /// <summary>納入先名称2プロパティ</summary>
        /// <value>納入先の場合の使用可能項目</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   納入先名称2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CSTADR_NAME2RF
        {
            get { return _cSTADR_NAME2RF; }
            set { _cSTADR_NAME2RF = value; }
        }

        /// public propaty name  :  CSTADR_HONORIFICTITLERF
        /// <summary>納入先敬称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   納入先敬称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CSTADR_HONORIFICTITLERF
        {
            get { return _cSTADR_HONORIFICTITLERF; }
            set { _cSTADR_HONORIFICTITLERF = value; }
        }

        /// public propaty name  :  CSTADR_KANARF
        /// <summary>納入先カナプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   納入先カナプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CSTADR_KANARF
        {
            get { return _cSTADR_KANARF; }
            set { _cSTADR_KANARF = value; }
        }

        /// public propaty name  :  CSTADR_CUSTOMERSNMRF
        /// <summary>納入先略称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   納入先略称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CSTADR_CUSTOMERSNMRF
        {
            get { return _cSTADR_CUSTOMERSNMRF; }
            set { _cSTADR_CUSTOMERSNMRF = value; }
        }

        /// public propaty name  :  CSTADR_OUTPUTNAMECODERF
        /// <summary>納入先諸口コードプロパティ</summary>
        /// <value>0:顧客名称1と2,1:顧客名称1,2:顧客名称2,3:諸口名称</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   納入先諸口コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CSTADR_OUTPUTNAMECODERF
        {
            get { return _cSTADR_OUTPUTNAMECODERF; }
            set { _cSTADR_OUTPUTNAMECODERF = value; }
        }

        /// public propaty name  :  CSTADR_CUSTANALYSCODE1RF
        /// <summary>納入先分析コード1プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   納入先分析コード1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CSTADR_CUSTANALYSCODE1RF
        {
            get { return _cSTADR_CUSTANALYSCODE1RF; }
            set { _cSTADR_CUSTANALYSCODE1RF = value; }
        }

        /// public propaty name  :  CSTADR_CUSTANALYSCODE2RF
        /// <summary>納入先分析コード2プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   納入先分析コード2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CSTADR_CUSTANALYSCODE2RF
        {
            get { return _cSTADR_CUSTANALYSCODE2RF; }
            set { _cSTADR_CUSTANALYSCODE2RF = value; }
        }

        /// public propaty name  :  CSTADR_CUSTANALYSCODE3RF
        /// <summary>納入先分析コード3プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   納入先分析コード3プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CSTADR_CUSTANALYSCODE3RF
        {
            get { return _cSTADR_CUSTANALYSCODE3RF; }
            set { _cSTADR_CUSTANALYSCODE3RF = value; }
        }

        /// public propaty name  :  CSTADR_CUSTANALYSCODE4RF
        /// <summary>納入先分析コード4プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   納入先分析コード4プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CSTADR_CUSTANALYSCODE4RF
        {
            get { return _cSTADR_CUSTANALYSCODE4RF; }
            set { _cSTADR_CUSTANALYSCODE4RF = value; }
        }

        /// public propaty name  :  CSTADR_CUSTANALYSCODE5RF
        /// <summary>納入先分析コード5プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   納入先分析コード5プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CSTADR_CUSTANALYSCODE5RF
        {
            get { return _cSTADR_CUSTANALYSCODE5RF; }
            set { _cSTADR_CUSTANALYSCODE5RF = value; }
        }

        /// public propaty name  :  CSTADR_CUSTANALYSCODE6RF
        /// <summary>納入先分析コード6プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   納入先分析コード6プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CSTADR_CUSTANALYSCODE6RF
        {
            get { return _cSTADR_CUSTANALYSCODE6RF; }
            set { _cSTADR_CUSTANALYSCODE6RF = value; }
        }

        /// public propaty name  :  CSTADR_NOTE1RF
        /// <summary>納入先備考1プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   納入先備考1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CSTADR_NOTE1RF
        {
            get { return _cSTADR_NOTE1RF; }
            set { _cSTADR_NOTE1RF = value; }
        }

        /// public propaty name  :  CSTADR_NOTE2RF
        /// <summary>納入先備考2プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   納入先備考2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CSTADR_NOTE2RF
        {
            get { return _cSTADR_NOTE2RF; }
            set { _cSTADR_NOTE2RF = value; }
        }

        /// public propaty name  :  CSTADR_NOTE3RF
        /// <summary>納入先備考3プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   納入先備考3プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CSTADR_NOTE3RF
        {
            get { return _cSTADR_NOTE3RF; }
            set { _cSTADR_NOTE3RF = value; }
        }

        /// public propaty name  :  CSTADR_NOTE4RF
        /// <summary>納入先備考4プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   納入先備考4プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CSTADR_NOTE4RF
        {
            get { return _cSTADR_NOTE4RF; }
            set { _cSTADR_NOTE4RF = value; }
        }

        /// public propaty name  :  CSTADR_NOTE5RF
        /// <summary>納入先備考5プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   納入先備考5プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CSTADR_NOTE5RF
        {
            get { return _cSTADR_NOTE5RF; }
            set { _cSTADR_NOTE5RF = value; }
        }

        /// public propaty name  :  CSTADR_NOTE6RF
        /// <summary>納入先備考6プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   納入先備考6プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CSTADR_NOTE6RF
        {
            get { return _cSTADR_NOTE6RF; }
            set { _cSTADR_NOTE6RF = value; }
        }

        /// public propaty name  :  CSTADR_NOTE7RF
        /// <summary>納入先備考7プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   納入先備考7プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CSTADR_NOTE7RF
        {
            get { return _cSTADR_NOTE7RF; }
            set { _cSTADR_NOTE7RF = value; }
        }

        /// public propaty name  :  CSTADR_NOTE8RF
        /// <summary>納入先備考8プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   納入先備考8プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CSTADR_NOTE8RF
        {
            get { return _cSTADR_NOTE8RF; }
            set { _cSTADR_NOTE8RF = value; }
        }

        /// public propaty name  :  CSTADR_NOTE9RF
        /// <summary>納入先備考9プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   納入先備考9プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CSTADR_NOTE9RF
        {
            get { return _cSTADR_NOTE9RF; }
            set { _cSTADR_NOTE9RF = value; }
        }

        /// public propaty name  :  CSTADR_NOTE10RF
        /// <summary>納入先備考10プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   納入先備考10プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CSTADR_NOTE10RF
        {
            get { return _cSTADR_NOTE10RF; }
            set { _cSTADR_NOTE10RF = value; }
        }

        /// public propaty name  :  COMPANYINFRF_COMPANYNAME1RF
        /// <summary>自社名称1プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社名称1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string COMPANYINFRF_COMPANYNAME1RF
        {
            get { return _cOMPANYINFRF_COMPANYNAME1RF; }
            set { _cOMPANYINFRF_COMPANYNAME1RF = value; }
        }

        /// public propaty name  :  COMPANYINFRF_COMPANYNAME2RF
        /// <summary>自社名称2プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社名称2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string COMPANYINFRF_COMPANYNAME2RF
        {
            get { return _cOMPANYINFRF_COMPANYNAME2RF; }
            set { _cOMPANYINFRF_COMPANYNAME2RF = value; }
        }

        /// public propaty name  :  COMPANYINFRF_POSTNORF
        /// <summary>郵便番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   郵便番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string COMPANYINFRF_POSTNORF
        {
            get { return _cOMPANYINFRF_POSTNORF; }
            set { _cOMPANYINFRF_POSTNORF = value; }
        }

        /// public propaty name  :  COMPANYINFRF_ADDRESS1RF
        /// <summary>住所1（都道府県市区郡・町村・字）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   住所1（都道府県市区郡・町村・字）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string COMPANYINFRF_ADDRESS1RF
        {
            get { return _cOMPANYINFRF_ADDRESS1RF; }
            set { _cOMPANYINFRF_ADDRESS1RF = value; }
        }

        /// public propaty name  :  COMPANYINFRF_ADDRESS3RF
        /// <summary>住所3（番地）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   住所3（番地）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string COMPANYINFRF_ADDRESS3RF
        {
            get { return _cOMPANYINFRF_ADDRESS3RF; }
            set { _cOMPANYINFRF_ADDRESS3RF = value; }
        }

        /// public propaty name  :  COMPANYINFRF_ADDRESS4RF
        /// <summary>住所4（アパート名称）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   住所4（アパート名称）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string COMPANYINFRF_ADDRESS4RF
        {
            get { return _cOMPANYINFRF_ADDRESS4RF; }
            set { _cOMPANYINFRF_ADDRESS4RF = value; }
        }

        /// public propaty name  :  COMPANYINFRF_COMPANYTELNO1RF
        /// <summary>自社電話番号1プロパティ</summary>
        /// <value>TEL</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社電話番号1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string COMPANYINFRF_COMPANYTELNO1RF
        {
            get { return _cOMPANYINFRF_COMPANYTELNO1RF; }
            set { _cOMPANYINFRF_COMPANYTELNO1RF = value; }
        }

        /// public propaty name  :  COMPANYINFRF_COMPANYTELNO2RF
        /// <summary>自社電話番号2プロパティ</summary>
        /// <value>TEL2</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社電話番号2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string COMPANYINFRF_COMPANYTELNO2RF
        {
            get { return _cOMPANYINFRF_COMPANYTELNO2RF; }
            set { _cOMPANYINFRF_COMPANYTELNO2RF = value; }
        }

        /// public propaty name  :  COMPANYINFRF_COMPANYTELNO3RF
        /// <summary>自社電話番号3プロパティ</summary>
        /// <value>FAX</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社電話番号3プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string COMPANYINFRF_COMPANYTELNO3RF
        {
            get { return _cOMPANYINFRF_COMPANYTELNO3RF; }
            set { _cOMPANYINFRF_COMPANYTELNO3RF = value; }
        }

        /// public propaty name  :  COMPANYINFRF_COMPANYTELTITLE1RF
        /// <summary>自社電話番号タイトル1プロパティ</summary>
        /// <value>TEL</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社電話番号タイトル1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string COMPANYINFRF_COMPANYTELTITLE1RF
        {
            get { return _cOMPANYINFRF_COMPANYTELTITLE1RF; }
            set { _cOMPANYINFRF_COMPANYTELTITLE1RF = value; }
        }

        /// public propaty name  :  COMPANYINFRF_COMPANYTELTITLE2RF
        /// <summary>自社電話番号タイトル2プロパティ</summary>
        /// <value>TEL2</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社電話番号タイトル2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string COMPANYINFRF_COMPANYTELTITLE2RF
        {
            get { return _cOMPANYINFRF_COMPANYTELTITLE2RF; }
            set { _cOMPANYINFRF_COMPANYTELTITLE2RF = value; }
        }

        /// public propaty name  :  COMPANYINFRF_COMPANYTELTITLE3RF
        /// <summary>自社電話番号タイトル3プロパティ</summary>
        /// <value>FAX</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社電話番号タイトル3プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string COMPANYINFRF_COMPANYTELTITLE3RF
        {
            get { return _cOMPANYINFRF_COMPANYTELTITLE3RF; }
            set { _cOMPANYINFRF_COMPANYTELTITLE3RF = value; }
        }

        /// public propaty name  :  HADD_ACPTANODRSTNMRF
        /// <summary>受注ステータス名称プロパティ</summary>
        /// <value>10:見積,20:受注,30:売上,40:出荷</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   受注ステータス名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_ACPTANODRSTNMRF
        {
            get { return _hADD_ACPTANODRSTNMRF; }
            set { _hADD_ACPTANODRSTNMRF = value; }
        }

        /// public propaty name  :  HADD_DEBITNOTEDIVNMRF
        /// <summary>赤伝区分名称プロパティ</summary>
        /// <value>0:黒伝,1:赤伝,2:元黒</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   赤伝区分名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_DEBITNOTEDIVNMRF
        {
            get { return _hADD_DEBITNOTEDIVNMRF; }
            set { _hADD_DEBITNOTEDIVNMRF = value; }
        }

        /// public propaty name  :  HADD_SALESSLIPNMRF
        /// <summary>売上伝票区分名称プロパティ</summary>
        /// <value>0:売上,1:返品</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上伝票区分名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_SALESSLIPNMRF
        {
            get { return _hADD_SALESSLIPNMRF; }
            set { _hADD_SALESSLIPNMRF = value; }
        }

        /// public propaty name  :  HADD_SALESGOODSNMRF
        /// <summary>売上商品区分名称プロパティ</summary>
        /// <value>0:商品,1:商品外,2:消費税調整,3:残高調整,4:売掛用消費税調整,5:売掛用残高調整,10:売掛用消費税調整(自動)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上商品区分名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_SALESGOODSNMRF
        {
            get { return _hADD_SALESGOODSNMRF; }
            set { _hADD_SALESGOODSNMRF = value; }
        }

        /// public propaty name  :  HADD_ACCRECDIVNMRF
        /// <summary>売掛区分名称プロパティ</summary>
        /// <value>0:売掛なし,1:売掛</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売掛区分名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_ACCRECDIVNMRF
        {
            get { return _hADD_ACCRECDIVNMRF; }
            set { _hADD_ACCRECDIVNMRF = value; }
        }

        /// public propaty name  :  HADD_DELAYPAYMENTDIVNMRF
        /// <summary>来勘区分名称プロパティ</summary>
        /// <value>0:当月(来勘なし),1:来月,2:再来月…9:9ヵ月後</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   来勘区分名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_DELAYPAYMENTDIVNMRF
        {
            get { return _hADD_DELAYPAYMENTDIVNMRF; }
            set { _hADD_DELAYPAYMENTDIVNMRF = value; }
        }

        /// public propaty name  :  HADD_ESTIMATEDIVIDENMRF
        /// <summary>見積区分名称プロパティ</summary>
        /// <value>1:通常見積　2:単価見積</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   見積区分名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_ESTIMATEDIVIDENMRF
        {
            get { return _hADD_ESTIMATEDIVIDENMRF; }
            set { _hADD_ESTIMATEDIVIDENMRF = value; }
        }

        /// public propaty name  :  HADD_CONSTAXLAYMETHODNMRF
        /// <summary>消費税転嫁方式名称プロパティ</summary>
        /// <value>0:伝票単位1:明細単位2:請求親 3:請求子 9:非課税</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   消費税転嫁方式名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_CONSTAXLAYMETHODNMRF
        {
            get { return _hADD_CONSTAXLAYMETHODNMRF; }
            set { _hADD_CONSTAXLAYMETHODNMRF = value; }
        }

        /// public propaty name  :  HADD_AUTODEPOSITNMRF
        /// <summary>自動入金区分名称プロパティ</summary>
        /// <value>0:通常入金,1:自動入金</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自動入金区分名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_AUTODEPOSITNMRF
        {
            get { return _hADD_AUTODEPOSITNMRF; }
            set { _hADD_AUTODEPOSITNMRF = value; }
        }

        /// public propaty name  :  HADD_SLIPPRINTFINISHNMRF
        /// <summary>伝票発行済区分名称プロパティ</summary>
        /// <value>0:未発行 1:発行済</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票発行済区分名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_SLIPPRINTFINISHNMRF
        {
            get { return _hADD_SLIPPRINTFINISHNMRF; }
            set { _hADD_SLIPPRINTFINISHNMRF = value; }
        }

        /// public propaty name  :  HADD_COMPLETENMRF
        /// <summary>一式伝票区分名称プロパティ</summary>
        /// <value>0:通常伝票,1:一式伝票</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   一式伝票区分名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_COMPLETENMRF
        {
            get { return _hADD_COMPLETENMRF; }
            set { _hADD_COMPLETENMRF = value; }
        }

        /// public propaty name  :  HADD_CARMNGNORF
        /// <summary>(先頭)車両管理番号プロパティ</summary>
        /// <value>自動採番（無重複のシーケンス）PM7での車両SEQ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   (先頭)車両管理番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 HADD_CARMNGNORF
        {
            get { return _hADD_CARMNGNORF; }
            set { _hADD_CARMNGNORF = value; }
        }

        /// public propaty name  :  HADD_CARMNGCODERF
        /// <summary>(先頭)車輌管理コードプロパティ</summary>
        /// <value>※PM7での車両管理番号</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   (先頭)車輌管理コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_CARMNGCODERF
        {
            get { return _hADD_CARMNGCODERF; }
            set { _hADD_CARMNGCODERF = value; }
        }

        /// public propaty name  :  HADD_NUMBERPLATE1CODERF
        /// <summary>(先頭)陸運事務所番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   (先頭)陸運事務所番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 HADD_NUMBERPLATE1CODERF
        {
            get { return _hADD_NUMBERPLATE1CODERF; }
            set { _hADD_NUMBERPLATE1CODERF = value; }
        }

        /// public propaty name  :  HADD_NUMBERPLATE1NAMERF
        /// <summary>(先頭)陸運事務局名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   (先頭)陸運事務局名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_NUMBERPLATE1NAMERF
        {
            get { return _hADD_NUMBERPLATE1NAMERF; }
            set { _hADD_NUMBERPLATE1NAMERF = value; }
        }

        /// public propaty name  :  HADD_NUMBERPLATE2RF
        /// <summary>(先頭)車両登録番号（種別）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   (先頭)車両登録番号（種別）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_NUMBERPLATE2RF
        {
            get { return _hADD_NUMBERPLATE2RF; }
            set { _hADD_NUMBERPLATE2RF = value; }
        }

        /// public propaty name  :  HADD_NUMBERPLATE3RF
        /// <summary>(先頭)車両登録番号（カナ）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   (先頭)車両登録番号（カナ）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_NUMBERPLATE3RF
        {
            get { return _hADD_NUMBERPLATE3RF; }
            set { _hADD_NUMBERPLATE3RF = value; }
        }

        /// public propaty name  :  HADD_NUMBERPLATE4RF
        /// <summary>(先頭)車両登録番号（プレート番号）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   (先頭)車両登録番号（プレート番号）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 HADD_NUMBERPLATE4RF
        {
            get { return _hADD_NUMBERPLATE4RF; }
            set { _hADD_NUMBERPLATE4RF = value; }
        }

        /// public propaty name  :  HADD_FIRSTENTRYDATERF
        /// <summary>(先頭)初年度プロパティ</summary>
        /// <value>YYYYMM</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   (先頭)初年度プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 HADD_FIRSTENTRYDATERF
        {
            get { return _hADD_FIRSTENTRYDATERF; }
            set { _hADD_FIRSTENTRYDATERF = value; }
        }

        /// public propaty name  :  HADD_MAKERCODERF
        /// <summary>(先頭)メーカーコードプロパティ</summary>
        /// <value>1～899:提供分, 900～ユーザー登録</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   (先頭)メーカーコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 HADD_MAKERCODERF
        {
            get { return _hADD_MAKERCODERF; }
            set { _hADD_MAKERCODERF = value; }
        }

        /// public propaty name  :  HADD_MAKERFULLNAMERF
        /// <summary>(先頭)メーカー全角名称プロパティ</summary>
        /// <value>正式名称（カナ漢字混在で全角管理）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   (先頭)メーカー全角名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_MAKERFULLNAMERF
        {
            get { return _hADD_MAKERFULLNAMERF; }
            set { _hADD_MAKERFULLNAMERF = value; }
        }

        /// public propaty name  :  HADD_MODELCODERF
        /// <summary>(先頭)車種コードプロパティ</summary>
        /// <value>車名コード(翼) 1～899:提供分, 900～ユーザー登録</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   (先頭)車種コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 HADD_MODELCODERF
        {
            get { return _hADD_MODELCODERF; }
            set { _hADD_MODELCODERF = value; }
        }

        /// public propaty name  :  HADD_MODELSUBCODERF
        /// <summary>(先頭)車種サブコードプロパティ</summary>
        /// <value>0～899:提供分,900～ﾕｰｻﾞｰ登録</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   (先頭)車種サブコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 HADD_MODELSUBCODERF
        {
            get { return _hADD_MODELSUBCODERF; }
            set { _hADD_MODELSUBCODERF = value; }
        }

        /// public propaty name  :  HADD_MODELFULLNAMERF
        /// <summary>(先頭)車種全角名称プロパティ</summary>
        /// <value>正式名称（カナ漢字混在で全角管理）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   (先頭)車種全角名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_MODELFULLNAMERF
        {
            get { return _hADD_MODELFULLNAMERF; }
            set { _hADD_MODELFULLNAMERF = value; }
        }

        /// public propaty name  :  HADD_EXHAUSTGASSIGNRF
        /// <summary>(先頭)排ガス記号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   (先頭)排ガス記号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_EXHAUSTGASSIGNRF
        {
            get { return _hADD_EXHAUSTGASSIGNRF; }
            set { _hADD_EXHAUSTGASSIGNRF = value; }
        }

        /// public propaty name  :  HADD_SERIESMODELRF
        /// <summary>(先頭)シリーズ型式プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   (先頭)シリーズ型式プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_SERIESMODELRF
        {
            get { return _hADD_SERIESMODELRF; }
            set { _hADD_SERIESMODELRF = value; }
        }

        /// public propaty name  :  HADD_CATEGORYSIGNMODELRF
        /// <summary>(先頭)型式（類別記号）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   (先頭)型式（類別記号）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_CATEGORYSIGNMODELRF
        {
            get { return _hADD_CATEGORYSIGNMODELRF; }
            set { _hADD_CATEGORYSIGNMODELRF = value; }
        }

        /// public propaty name  :  HADD_FULLMODELRF
        /// <summary>(先頭)型式（フル型）プロパティ</summary>
        /// <value>フル型式(44桁用)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   (先頭)型式（フル型）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_FULLMODELRF
        {
            get { return _hADD_FULLMODELRF; }
            set { _hADD_FULLMODELRF = value; }
        }

        /// public propaty name  :  HADD_MODELDESIGNATIONNORF
        /// <summary>(先頭)型式指定番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   (先頭)型式指定番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 HADD_MODELDESIGNATIONNORF
        {
            get { return _hADD_MODELDESIGNATIONNORF; }
            set { _hADD_MODELDESIGNATIONNORF = value; }
        }

        /// public propaty name  :  HADD_CATEGORYNORF
        /// <summary>(先頭)類別番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   (先頭)類別番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 HADD_CATEGORYNORF
        {
            get { return _hADD_CATEGORYNORF; }
            set { _hADD_CATEGORYNORF = value; }
        }

        /// public propaty name  :  HADD_FRAMEMODELRF
        /// <summary>(先頭)車台型式プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   (先頭)車台型式プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_FRAMEMODELRF
        {
            get { return _hADD_FRAMEMODELRF; }
            set { _hADD_FRAMEMODELRF = value; }
        }

        /// public propaty name  :  HADD_FRAMENORF
        /// <summary>(先頭)車台番号プロパティ</summary>
        /// <value>車検証記載フォーマット対応（ HCR32-100251584 等）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   (先頭)車台番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_FRAMENORF
        {
            get { return _hADD_FRAMENORF; }
            set { _hADD_FRAMENORF = value; }
        }

        /// public propaty name  :  HADD_SEARCHFRAMENORF
        /// <summary>(先頭)車台番号（検索用）プロパティ</summary>
        /// <value>PM7の車台番号と同意</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   (先頭)車台番号（検索用）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 HADD_SEARCHFRAMENORF
        {
            get { return _hADD_SEARCHFRAMENORF; }
            set { _hADD_SEARCHFRAMENORF = value; }
        }

        /// public propaty name  :  HADD_ENGINEMODELNMRF
        /// <summary>(先頭)エンジン型式名称プロパティ</summary>
        /// <value>エンジン検索</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   (先頭)エンジン型式名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_ENGINEMODELNMRF
        {
            get { return _hADD_ENGINEMODELNMRF; }
            set { _hADD_ENGINEMODELNMRF = value; }
        }

        /// public propaty name  :  HADD_RELEVANCEMODELRF
        /// <summary>(先頭)関連型式プロパティ</summary>
        /// <value>リサイクル系で使用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   (先頭)関連型式プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_RELEVANCEMODELRF
        {
            get { return _hADD_RELEVANCEMODELRF; }
            set { _hADD_RELEVANCEMODELRF = value; }
        }

        /// public propaty name  :  HADD_SUBCARNMCDRF
        /// <summary>(先頭)サブ車名コードプロパティ</summary>
        /// <value>リサイクル系で使用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   (先頭)サブ車名コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 HADD_SUBCARNMCDRF
        {
            get { return _hADD_SUBCARNMCDRF; }
            set { _hADD_SUBCARNMCDRF = value; }
        }

        /// public propaty name  :  HADD_MODELGRADESNAMERF
        /// <summary>(先頭)型式グレード略称プロパティ</summary>
        /// <value>リサイクル系で使用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   (先頭)型式グレード略称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_MODELGRADESNAMERF
        {
            get { return _hADD_MODELGRADESNAMERF; }
            set { _hADD_MODELGRADESNAMERF = value; }
        }

        /// public propaty name  :  HADD_COLORCODERF
        /// <summary>(先頭)カラーコードプロパティ</summary>
        /// <value>カタログの色コード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   (先頭)カラーコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_COLORCODERF
        {
            get { return _hADD_COLORCODERF; }
            set { _hADD_COLORCODERF = value; }
        }

        /// public propaty name  :  HADD_COLORNAME1RF
        /// <summary>(先頭)カラー名称1プロパティ</summary>
        /// <value>画面表示用正式名称</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   (先頭)カラー名称1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_COLORNAME1RF
        {
            get { return _hADD_COLORNAME1RF; }
            set { _hADD_COLORNAME1RF = value; }
        }

        /// public propaty name  :  HADD_TRIMCODERF
        /// <summary>(先頭)トリムコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   (先頭)トリムコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_TRIMCODERF
        {
            get { return _hADD_TRIMCODERF; }
            set { _hADD_TRIMCODERF = value; }
        }

        /// public propaty name  :  HADD_TRIMNAMERF
        /// <summary>(先頭)トリム名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   (先頭)トリム名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_TRIMNAMERF
        {
            get { return _hADD_TRIMNAMERF; }
            set { _hADD_TRIMNAMERF = value; }
        }

        /// public propaty name  :  HADD_MILEAGERF
        /// <summary>(先頭)車両走行距離プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   (先頭)車両走行距離プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 HADD_MILEAGERF
        {
            get { return _hADD_MILEAGERF; }
            set { _hADD_MILEAGERF = value; }
        }

        /// public propaty name  :  HADD_PRINTERMNGNORF
        /// <summary>プリンタ管理Noプロパティ</summary>
        /// <value>※このレコードの伝票を印刷するプリンタの決定結果(default)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   プリンタ管理Noプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 HADD_PRINTERMNGNORF
        {
            get { return _hADD_PRINTERMNGNORF; }
            set { _hADD_PRINTERMNGNORF = value; }
        }

        /// public propaty name  :  HADD_SLIPPRTSETPAPERIDRF
        /// <summary>伝票印刷設定用帳票IDプロパティ</summary>
        /// <value>※このレコードの伝票を印刷する伝票タイプの決定結果(default)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票印刷設定用帳票IDプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_SLIPPRTSETPAPERIDRF
        {
            get { return _hADD_SLIPPRTSETPAPERIDRF; }
            set { _hADD_SLIPPRTSETPAPERIDRF = value; }
        }

        /// public propaty name  :  HADD_NOTE1RF
        /// <summary>自社備考１プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社備考１プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_NOTE1RF
        {
            get { return _hADD_NOTE1RF; }
            set { _hADD_NOTE1RF = value; }
        }

        /// public propaty name  :  HADD_NOTE2RF
        /// <summary>自社備考２プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社備考２プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_NOTE2RF
        {
            get { return _hADD_NOTE2RF; }
            set { _hADD_NOTE2RF = value; }
        }

        /// public propaty name  :  HADD_NOTE3RF
        /// <summary>自社備考３プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社備考３プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_NOTE3RF
        {
            get { return _hADD_NOTE3RF; }
            set { _hADD_NOTE3RF = value; }
        }

        /// public propaty name  :  HADD_REISSUEMARKRF
        /// <summary>再発行マークプロパティ</summary>
        /// <value>全角３文字まで</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   再発行マークプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_REISSUEMARKRF
        {
            get { return _hADD_REISSUEMARKRF; }
            set { _hADD_REISSUEMARKRF = value; }
        }

        /// public propaty name  :  HADD_REFCONSTAXPRTNMRF
        /// <summary>参考消費税印字名称プロパティ</summary>
        /// <value>全角５文字まで</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   参考消費税印字名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_REFCONSTAXPRTNMRF
        {
            get { return _hADD_REFCONSTAXPRTNMRF; }
            set { _hADD_REFCONSTAXPRTNMRF = value; }
        }

        /// public propaty name  :  HADD_PRINTTIMEHOURRF
        /// <summary>印刷時刻 時プロパティ</summary>
        /// <value>HH</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   印刷時刻 時プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 HADD_PRINTTIMEHOURRF
        {
            get { return _hADD_PRINTTIMEHOURRF; }
            set { _hADD_PRINTTIMEHOURRF = value; }
        }

        /// public propaty name  :  HADD_PRINTTIMEMINUTERF
        /// <summary>印刷時刻 分プロパティ</summary>
        /// <value>MM</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   印刷時刻 分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 HADD_PRINTTIMEMINUTERF
        {
            get { return _hADD_PRINTTIMEMINUTERF; }
            set { _hADD_PRINTTIMEMINUTERF = value; }
        }

        /// public propaty name  :  HADD_PRINTTIMESECONDRF
        /// <summary>印刷時刻 秒プロパティ</summary>
        /// <value>DD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   印刷時刻 秒プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 HADD_PRINTTIMESECONDRF
        {
            get { return _hADD_PRINTTIMESECONDRF; }
            set { _hADD_PRINTTIMESECONDRF = value; }
        }

        /// public propaty name  :  HADD_SEARCHSLIPDATEFYRF
        /// <summary>伝票検索日付西暦年プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票検索日付西暦年プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 HADD_SEARCHSLIPDATEFYRF
        {
            get { return _hADD_SEARCHSLIPDATEFYRF; }
            set { _hADD_SEARCHSLIPDATEFYRF = value; }
        }

        /// public propaty name  :  HADD_SEARCHSLIPDATEFSRF
        /// <summary>伝票検索日付西暦年略プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票検索日付西暦年略プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 HADD_SEARCHSLIPDATEFSRF
        {
            get { return _hADD_SEARCHSLIPDATEFSRF; }
            set { _hADD_SEARCHSLIPDATEFSRF = value; }
        }

        /// public propaty name  :  HADD_SEARCHSLIPDATEFWRF
        /// <summary>伝票検索日付和暦年プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票検索日付和暦年プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 HADD_SEARCHSLIPDATEFWRF
        {
            get { return _hADD_SEARCHSLIPDATEFWRF; }
            set { _hADD_SEARCHSLIPDATEFWRF = value; }
        }

        /// public propaty name  :  HADD_SEARCHSLIPDATEFMRF
        /// <summary>伝票検索日付月プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票検索日付月プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 HADD_SEARCHSLIPDATEFMRF
        {
            get { return _hADD_SEARCHSLIPDATEFMRF; }
            set { _hADD_SEARCHSLIPDATEFMRF = value; }
        }

        /// public propaty name  :  HADD_SEARCHSLIPDATEFDRF
        /// <summary>伝票検索日付日プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票検索日付日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 HADD_SEARCHSLIPDATEFDRF
        {
            get { return _hADD_SEARCHSLIPDATEFDRF; }
            set { _hADD_SEARCHSLIPDATEFDRF = value; }
        }

        /// public propaty name  :  HADD_SEARCHSLIPDATEFGRF
        /// <summary>伝票検索日付元号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票検索日付元号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_SEARCHSLIPDATEFGRF
        {
            get { return _hADD_SEARCHSLIPDATEFGRF; }
            set { _hADD_SEARCHSLIPDATEFGRF = value; }
        }

        /// public propaty name  :  HADD_SEARCHSLIPDATEFRRF
        /// <summary>伝票検索日付略号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票検索日付略号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_SEARCHSLIPDATEFRRF
        {
            get { return _hADD_SEARCHSLIPDATEFRRF; }
            set { _hADD_SEARCHSLIPDATEFRRF = value; }
        }

        /// public propaty name  :  HADD_SEARCHSLIPDATEFLSRF
        /// <summary>伝票検索日付リテラル(/)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票検索日付リテラル(/)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_SEARCHSLIPDATEFLSRF
        {
            get { return _hADD_SEARCHSLIPDATEFLSRF; }
            set { _hADD_SEARCHSLIPDATEFLSRF = value; }
        }

        /// public propaty name  :  HADD_SEARCHSLIPDATEFLPRF
        /// <summary>伝票検索日付リテラル(.)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票検索日付リテラル(.)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_SEARCHSLIPDATEFLPRF
        {
            get { return _hADD_SEARCHSLIPDATEFLPRF; }
            set { _hADD_SEARCHSLIPDATEFLPRF = value; }
        }

        /// public propaty name  :  HADD_SEARCHSLIPDATEFLYRF
        /// <summary>伝票検索日付リテラル(年)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票検索日付リテラル(年)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_SEARCHSLIPDATEFLYRF
        {
            get { return _hADD_SEARCHSLIPDATEFLYRF; }
            set { _hADD_SEARCHSLIPDATEFLYRF = value; }
        }

        /// public propaty name  :  HADD_SEARCHSLIPDATEFLMRF
        /// <summary>伝票検索日付リテラル(月)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票検索日付リテラル(月)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_SEARCHSLIPDATEFLMRF
        {
            get { return _hADD_SEARCHSLIPDATEFLMRF; }
            set { _hADD_SEARCHSLIPDATEFLMRF = value; }
        }

        /// public propaty name  :  HADD_SEARCHSLIPDATEFLDRF
        /// <summary>伝票検索日付リテラル(日)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票検索日付リテラル(日)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_SEARCHSLIPDATEFLDRF
        {
            get { return _hADD_SEARCHSLIPDATEFLDRF; }
            set { _hADD_SEARCHSLIPDATEFLDRF = value; }
        }

        /// public propaty name  :  HADD_SHIPMENTDAYFYRF
        /// <summary>出荷日付西暦年プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   出荷日付西暦年プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 HADD_SHIPMENTDAYFYRF
        {
            get { return _hADD_SHIPMENTDAYFYRF; }
            set { _hADD_SHIPMENTDAYFYRF = value; }
        }

        /// public propaty name  :  HADD_SHIPMENTDAYFSRF
        /// <summary>出荷日付西暦年略プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   出荷日付西暦年略プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 HADD_SHIPMENTDAYFSRF
        {
            get { return _hADD_SHIPMENTDAYFSRF; }
            set { _hADD_SHIPMENTDAYFSRF = value; }
        }

        /// public propaty name  :  HADD_SHIPMENTDAYFWRF
        /// <summary>出荷日付和暦年プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   出荷日付和暦年プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 HADD_SHIPMENTDAYFWRF
        {
            get { return _hADD_SHIPMENTDAYFWRF; }
            set { _hADD_SHIPMENTDAYFWRF = value; }
        }

        /// public propaty name  :  HADD_SHIPMENTDAYFMRF
        /// <summary>出荷日付月プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   出荷日付月プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 HADD_SHIPMENTDAYFMRF
        {
            get { return _hADD_SHIPMENTDAYFMRF; }
            set { _hADD_SHIPMENTDAYFMRF = value; }
        }

        /// public propaty name  :  HADD_SHIPMENTDAYFDRF
        /// <summary>出荷日付日プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   出荷日付日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 HADD_SHIPMENTDAYFDRF
        {
            get { return _hADD_SHIPMENTDAYFDRF; }
            set { _hADD_SHIPMENTDAYFDRF = value; }
        }

        /// public propaty name  :  HADD_SHIPMENTDAYFGRF
        /// <summary>出荷日付元号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   出荷日付元号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_SHIPMENTDAYFGRF
        {
            get { return _hADD_SHIPMENTDAYFGRF; }
            set { _hADD_SHIPMENTDAYFGRF = value; }
        }

        /// public propaty name  :  HADD_SHIPMENTDAYFRRF
        /// <summary>出荷日付略号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   出荷日付略号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_SHIPMENTDAYFRRF
        {
            get { return _hADD_SHIPMENTDAYFRRF; }
            set { _hADD_SHIPMENTDAYFRRF = value; }
        }

        /// public propaty name  :  HADD_SHIPMENTDAYFLSRF
        /// <summary>出荷日付リテラル(/)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   出荷日付リテラル(/)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_SHIPMENTDAYFLSRF
        {
            get { return _hADD_SHIPMENTDAYFLSRF; }
            set { _hADD_SHIPMENTDAYFLSRF = value; }
        }

        /// public propaty name  :  HADD_SHIPMENTDAYFLPRF
        /// <summary>出荷日付リテラル(.)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   出荷日付リテラル(.)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_SHIPMENTDAYFLPRF
        {
            get { return _hADD_SHIPMENTDAYFLPRF; }
            set { _hADD_SHIPMENTDAYFLPRF = value; }
        }

        /// public propaty name  :  HADD_SHIPMENTDAYFLYRF
        /// <summary>出荷日付リテラル(年)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   出荷日付リテラル(年)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_SHIPMENTDAYFLYRF
        {
            get { return _hADD_SHIPMENTDAYFLYRF; }
            set { _hADD_SHIPMENTDAYFLYRF = value; }
        }

        /// public propaty name  :  HADD_SHIPMENTDAYFLMRF
        /// <summary>出荷日付リテラル(月)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   出荷日付リテラル(月)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_SHIPMENTDAYFLMRF
        {
            get { return _hADD_SHIPMENTDAYFLMRF; }
            set { _hADD_SHIPMENTDAYFLMRF = value; }
        }

        /// public propaty name  :  HADD_SHIPMENTDAYFLDRF
        /// <summary>出荷日付リテラル(日)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   出荷日付リテラル(日)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_SHIPMENTDAYFLDRF
        {
            get { return _hADD_SHIPMENTDAYFLDRF; }
            set { _hADD_SHIPMENTDAYFLDRF = value; }
        }

        /// public propaty name  :  HADD_SALESDATEFYRF
        /// <summary>売上日付西暦年プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上日付西暦年プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 HADD_SALESDATEFYRF
        {
            get { return _hADD_SALESDATEFYRF; }
            set { _hADD_SALESDATEFYRF = value; }
        }

        /// public propaty name  :  HADD_SALESDATEFSRF
        /// <summary>売上日付西暦年略プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上日付西暦年略プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 HADD_SALESDATEFSRF
        {
            get { return _hADD_SALESDATEFSRF; }
            set { _hADD_SALESDATEFSRF = value; }
        }

        /// public propaty name  :  HADD_SALESDATEFWRF
        /// <summary>売上日付和暦年プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上日付和暦年プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 HADD_SALESDATEFWRF
        {
            get { return _hADD_SALESDATEFWRF; }
            set { _hADD_SALESDATEFWRF = value; }
        }

        /// public propaty name  :  HADD_SALESDATEFMRF
        /// <summary>売上日付月プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上日付月プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 HADD_SALESDATEFMRF
        {
            get { return _hADD_SALESDATEFMRF; }
            set { _hADD_SALESDATEFMRF = value; }
        }

        /// public propaty name  :  HADD_SALESDATEFDRF
        /// <summary>売上日付日プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上日付日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 HADD_SALESDATEFDRF
        {
            get { return _hADD_SALESDATEFDRF; }
            set { _hADD_SALESDATEFDRF = value; }
        }

        /// public propaty name  :  HADD_SALESDATEFGRF
        /// <summary>売上日付元号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上日付元号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_SALESDATEFGRF
        {
            get { return _hADD_SALESDATEFGRF; }
            set { _hADD_SALESDATEFGRF = value; }
        }

        /// public propaty name  :  HADD_SALESDATEFRRF
        /// <summary>売上日付略号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上日付略号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_SALESDATEFRRF
        {
            get { return _hADD_SALESDATEFRRF; }
            set { _hADD_SALESDATEFRRF = value; }
        }

        /// public propaty name  :  HADD_SALESDATEFLSRF
        /// <summary>売上日付リテラル(/)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上日付リテラル(/)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_SALESDATEFLSRF
        {
            get { return _hADD_SALESDATEFLSRF; }
            set { _hADD_SALESDATEFLSRF = value; }
        }

        /// public propaty name  :  HADD_SALESDATEFLPRF
        /// <summary>売上日付リテラル(.)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上日付リテラル(.)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_SALESDATEFLPRF
        {
            get { return _hADD_SALESDATEFLPRF; }
            set { _hADD_SALESDATEFLPRF = value; }
        }

        /// public propaty name  :  HADD_SALESDATEFLYRF
        /// <summary>売上日付リテラル(年)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上日付リテラル(年)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_SALESDATEFLYRF
        {
            get { return _hADD_SALESDATEFLYRF; }
            set { _hADD_SALESDATEFLYRF = value; }
        }

        /// public propaty name  :  HADD_SALESDATEFLMRF
        /// <summary>売上日付リテラル(月)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上日付リテラル(月)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_SALESDATEFLMRF
        {
            get { return _hADD_SALESDATEFLMRF; }
            set { _hADD_SALESDATEFLMRF = value; }
        }

        /// public propaty name  :  HADD_SALESDATEFLDRF
        /// <summary>売上日付リテラル(日)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上日付リテラル(日)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_SALESDATEFLDRF
        {
            get { return _hADD_SALESDATEFLDRF; }
            set { _hADD_SALESDATEFLDRF = value; }
        }

        /// public propaty name  :  HADD_ADDUPADATEFYRF
        /// <summary>計上日付西暦年プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   計上日付西暦年プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 HADD_ADDUPADATEFYRF
        {
            get { return _hADD_ADDUPADATEFYRF; }
            set { _hADD_ADDUPADATEFYRF = value; }
        }

        /// public propaty name  :  HADD_ADDUPADATEFSRF
        /// <summary>計上日付西暦年略プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   計上日付西暦年略プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 HADD_ADDUPADATEFSRF
        {
            get { return _hADD_ADDUPADATEFSRF; }
            set { _hADD_ADDUPADATEFSRF = value; }
        }

        /// public propaty name  :  HADD_ADDUPADATEFWRF
        /// <summary>計上日付和暦年プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   計上日付和暦年プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 HADD_ADDUPADATEFWRF
        {
            get { return _hADD_ADDUPADATEFWRF; }
            set { _hADD_ADDUPADATEFWRF = value; }
        }

        /// public propaty name  :  HADD_ADDUPADATEFMRF
        /// <summary>計上日付月プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   計上日付月プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 HADD_ADDUPADATEFMRF
        {
            get { return _hADD_ADDUPADATEFMRF; }
            set { _hADD_ADDUPADATEFMRF = value; }
        }

        /// public propaty name  :  HADD_ADDUPADATEFDRF
        /// <summary>計上日付日プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   計上日付日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 HADD_ADDUPADATEFDRF
        {
            get { return _hADD_ADDUPADATEFDRF; }
            set { _hADD_ADDUPADATEFDRF = value; }
        }

        /// public propaty name  :  HADD_ADDUPADATEFGRF
        /// <summary>計上日付元号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   計上日付元号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_ADDUPADATEFGRF
        {
            get { return _hADD_ADDUPADATEFGRF; }
            set { _hADD_ADDUPADATEFGRF = value; }
        }

        /// public propaty name  :  HADD_ADDUPADATEFRRF
        /// <summary>計上日付略号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   計上日付略号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_ADDUPADATEFRRF
        {
            get { return _hADD_ADDUPADATEFRRF; }
            set { _hADD_ADDUPADATEFRRF = value; }
        }

        /// public propaty name  :  HADD_ADDUPADATEFLSRF
        /// <summary>計上日付リテラル(/)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   計上日付リテラル(/)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_ADDUPADATEFLSRF
        {
            get { return _hADD_ADDUPADATEFLSRF; }
            set { _hADD_ADDUPADATEFLSRF = value; }
        }

        /// public propaty name  :  HADD_ADDUPADATEFLPRF
        /// <summary>計上日付リテラル(.)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   計上日付リテラル(.)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_ADDUPADATEFLPRF
        {
            get { return _hADD_ADDUPADATEFLPRF; }
            set { _hADD_ADDUPADATEFLPRF = value; }
        }

        /// public propaty name  :  HADD_ADDUPADATEFLYRF
        /// <summary>計上日付リテラル(年)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   計上日付リテラル(年)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_ADDUPADATEFLYRF
        {
            get { return _hADD_ADDUPADATEFLYRF; }
            set { _hADD_ADDUPADATEFLYRF = value; }
        }

        /// public propaty name  :  HADD_ADDUPADATEFLMRF
        /// <summary>計上日付リテラル(月)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   計上日付リテラル(月)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_ADDUPADATEFLMRF
        {
            get { return _hADD_ADDUPADATEFLMRF; }
            set { _hADD_ADDUPADATEFLMRF = value; }
        }

        /// public propaty name  :  HADD_ADDUPADATEFLDRF
        /// <summary>計上日付リテラル(日)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   計上日付リテラル(日)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_ADDUPADATEFLDRF
        {
            get { return _hADD_ADDUPADATEFLDRF; }
            set { _hADD_ADDUPADATEFLDRF = value; }
        }

        /// public propaty name  :  HADD_SALESSLIPPRINTDATEFYRF
        /// <summary>売上伝票発行日西暦年プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上伝票発行日西暦年プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 HADD_SALESSLIPPRINTDATEFYRF
        {
            get { return _hADD_SALESSLIPPRINTDATEFYRF; }
            set { _hADD_SALESSLIPPRINTDATEFYRF = value; }
        }

        /// public propaty name  :  HADD_SALESSLIPPRINTDATEFSRF
        /// <summary>売上伝票発行日西暦年略プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上伝票発行日西暦年略プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 HADD_SALESSLIPPRINTDATEFSRF
        {
            get { return _hADD_SALESSLIPPRINTDATEFSRF; }
            set { _hADD_SALESSLIPPRINTDATEFSRF = value; }
        }

        /// public propaty name  :  HADD_SALESSLIPPRINTDATEFWRF
        /// <summary>売上伝票発行日和暦年プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上伝票発行日和暦年プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 HADD_SALESSLIPPRINTDATEFWRF
        {
            get { return _hADD_SALESSLIPPRINTDATEFWRF; }
            set { _hADD_SALESSLIPPRINTDATEFWRF = value; }
        }

        /// public propaty name  :  HADD_SALESSLIPPRINTDATEFMRF
        /// <summary>売上伝票発行日月プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上伝票発行日月プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 HADD_SALESSLIPPRINTDATEFMRF
        {
            get { return _hADD_SALESSLIPPRINTDATEFMRF; }
            set { _hADD_SALESSLIPPRINTDATEFMRF = value; }
        }

        /// public propaty name  :  HADD_SALESSLIPPRINTDATEFDRF
        /// <summary>売上伝票発行日日プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上伝票発行日日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 HADD_SALESSLIPPRINTDATEFDRF
        {
            get { return _hADD_SALESSLIPPRINTDATEFDRF; }
            set { _hADD_SALESSLIPPRINTDATEFDRF = value; }
        }

        /// public propaty name  :  HADD_SALESSLIPPRINTDATEFGRF
        /// <summary>売上伝票発行日元号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上伝票発行日元号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_SALESSLIPPRINTDATEFGRF
        {
            get { return _hADD_SALESSLIPPRINTDATEFGRF; }
            set { _hADD_SALESSLIPPRINTDATEFGRF = value; }
        }

        /// public propaty name  :  HADD_SALESSLIPPRINTDATEFRRF
        /// <summary>売上伝票発行日略号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上伝票発行日略号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_SALESSLIPPRINTDATEFRRF
        {
            get { return _hADD_SALESSLIPPRINTDATEFRRF; }
            set { _hADD_SALESSLIPPRINTDATEFRRF = value; }
        }

        /// public propaty name  :  HADD_SALESSLIPPRINTDATEFLSRF
        /// <summary>売上伝票発行日リテラル(/)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上伝票発行日リテラル(/)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_SALESSLIPPRINTDATEFLSRF
        {
            get { return _hADD_SALESSLIPPRINTDATEFLSRF; }
            set { _hADD_SALESSLIPPRINTDATEFLSRF = value; }
        }

        /// public propaty name  :  HADD_SALESSLIPPRINTDATEFLPRF
        /// <summary>売上伝票発行日リテラル(.)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上伝票発行日リテラル(.)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_SALESSLIPPRINTDATEFLPRF
        {
            get { return _hADD_SALESSLIPPRINTDATEFLPRF; }
            set { _hADD_SALESSLIPPRINTDATEFLPRF = value; }
        }

        /// public propaty name  :  HADD_SALESSLIPPRINTDATEFLYRF
        /// <summary>売上伝票発行日リテラル(年)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上伝票発行日リテラル(年)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_SALESSLIPPRINTDATEFLYRF
        {
            get { return _hADD_SALESSLIPPRINTDATEFLYRF; }
            set { _hADD_SALESSLIPPRINTDATEFLYRF = value; }
        }

        /// public propaty name  :  HADD_SALESSLIPPRINTDATEFLMRF
        /// <summary>売上伝票発行日リテラル(月)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上伝票発行日リテラル(月)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_SALESSLIPPRINTDATEFLMRF
        {
            get { return _hADD_SALESSLIPPRINTDATEFLMRF; }
            set { _hADD_SALESSLIPPRINTDATEFLMRF = value; }
        }

        /// public propaty name  :  HADD_SALESSLIPPRINTDATEFLDRF
        /// <summary>売上伝票発行日リテラル(日)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上伝票発行日リテラル(日)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_SALESSLIPPRINTDATEFLDRF
        {
            get { return _hADD_SALESSLIPPRINTDATEFLDRF; }
            set { _hADD_SALESSLIPPRINTDATEFLDRF = value; }
        }

        /// public propaty name  :  HADD_FIRSTENTRYDATEFYRF
        /// <summary>(先頭)初年度西暦年プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   (先頭)初年度西暦年プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 HADD_FIRSTENTRYDATEFYRF
        {
            get { return _hADD_FIRSTENTRYDATEFYRF; }
            set { _hADD_FIRSTENTRYDATEFYRF = value; }
        }

        /// public propaty name  :  HADD_FIRSTENTRYDATEFSRF
        /// <summary>(先頭)初年度西暦年略プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   (先頭)初年度西暦年略プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 HADD_FIRSTENTRYDATEFSRF
        {
            get { return _hADD_FIRSTENTRYDATEFSRF; }
            set { _hADD_FIRSTENTRYDATEFSRF = value; }
        }

        /// public propaty name  :  HADD_FIRSTENTRYDATEFWRF
        /// <summary>(先頭)初年度和暦年プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   (先頭)初年度和暦年プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 HADD_FIRSTENTRYDATEFWRF
        {
            get { return _hADD_FIRSTENTRYDATEFWRF; }
            set { _hADD_FIRSTENTRYDATEFWRF = value; }
        }

        /// public propaty name  :  HADD_FIRSTENTRYDATEFMRF
        /// <summary>(先頭)初年度月プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   (先頭)初年度月プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 HADD_FIRSTENTRYDATEFMRF
        {
            get { return _hADD_FIRSTENTRYDATEFMRF; }
            set { _hADD_FIRSTENTRYDATEFMRF = value; }
        }

        /// public propaty name  :  HADD_FIRSTENTRYDATEFDRF
        /// <summary>(先頭)初年度日プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   (先頭)初年度日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 HADD_FIRSTENTRYDATEFDRF
        {
            get { return _hADD_FIRSTENTRYDATEFDRF; }
            set { _hADD_FIRSTENTRYDATEFDRF = value; }
        }

        /// public propaty name  :  HADD_FIRSTENTRYDATEFGRF
        /// <summary>(先頭)初年度元号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   (先頭)初年度元号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_FIRSTENTRYDATEFGRF
        {
            get { return _hADD_FIRSTENTRYDATEFGRF; }
            set { _hADD_FIRSTENTRYDATEFGRF = value; }
        }

        /// public propaty name  :  HADD_FIRSTENTRYDATEFRRF
        /// <summary>(先頭)初年度略号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   (先頭)初年度略号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_FIRSTENTRYDATEFRRF
        {
            get { return _hADD_FIRSTENTRYDATEFRRF; }
            set { _hADD_FIRSTENTRYDATEFRRF = value; }
        }

        /// public propaty name  :  HADD_FIRSTENTRYDATEFLSRF
        /// <summary>(先頭)初年度リテラル(/)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   (先頭)初年度リテラル(/)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_FIRSTENTRYDATEFLSRF
        {
            get { return _hADD_FIRSTENTRYDATEFLSRF; }
            set { _hADD_FIRSTENTRYDATEFLSRF = value; }
        }

        /// public propaty name  :  HADD_FIRSTENTRYDATEFLPRF
        /// <summary>(先頭)初年度リテラル(.)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   (先頭)初年度リテラル(.)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_FIRSTENTRYDATEFLPRF
        {
            get { return _hADD_FIRSTENTRYDATEFLPRF; }
            set { _hADD_FIRSTENTRYDATEFLPRF = value; }
        }

        /// public propaty name  :  HADD_FIRSTENTRYDATEFLYRF
        /// <summary>(先頭)初年度リテラル(年)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   (先頭)初年度リテラル(年)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_FIRSTENTRYDATEFLYRF
        {
            get { return _hADD_FIRSTENTRYDATEFLYRF; }
            set { _hADD_FIRSTENTRYDATEFLYRF = value; }
        }

        /// public propaty name  :  HADD_FIRSTENTRYDATEFLMRF
        /// <summary>(先頭)初年度リテラル(月)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   (先頭)初年度リテラル(月)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_FIRSTENTRYDATEFLMRF
        {
            get { return _hADD_FIRSTENTRYDATEFLMRF; }
            set { _hADD_FIRSTENTRYDATEFLMRF = value; }
        }

        /// public propaty name  :  HADD_FIRSTENTRYDATEFLDRF
        /// <summary>(先頭)初年度リテラル(日)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   (先頭)初年度リテラル(日)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_FIRSTENTRYDATEFLDRF
        {
            get { return _hADD_FIRSTENTRYDATEFLDRF; }
            set { _hADD_FIRSTENTRYDATEFLDRF = value; }
        }

        /// public propaty name  :  HADD_PRINTCUSTOMERNAME1RF
        /// <summary>印刷用得意先名称（上段）プロパティ</summary>
        /// <value>名称２がないとき空白</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   印刷用得意先名称（上段）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_PRINTCUSTOMERNAME1RF
        {
            get { return _hADD_PRINTCUSTOMERNAME1RF; }
            set { _hADD_PRINTCUSTOMERNAME1RF = value; }
        }

        /// public propaty name  :  HADD_PRINTCUSTOMERNAME2RF
        /// <summary>印刷用得意先名称（下段）プロパティ</summary>
        /// <value>名称２がないとき名称１</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   印刷用得意先名称（下段）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_PRINTCUSTOMERNAME2RF
        {
            get { return _hADD_PRINTCUSTOMERNAME2RF; }
            set { _hADD_PRINTCUSTOMERNAME2RF = value; }
        }

        /// public propaty name  :  HADD_PRINTCUSTOMERNAME2HNRF
        /// <summary>印刷用得意先名称（下段）＋敬称プロパティ</summary>
        /// <value>名称２がないとき名称１＋空白＋敬称</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   印刷用得意先名称（下段）＋敬称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_PRINTCUSTOMERNAME2HNRF
        {
            get { return _hADD_PRINTCUSTOMERNAME2HNRF; }
            set { _hADD_PRINTCUSTOMERNAME2HNRF = value; }
        }

        /// public propaty name  :  HADD_MAKERHALFNAMERF
        /// <summary>(先頭)メーカー半角名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   (先頭)メーカー半角名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_MAKERHALFNAMERF
        {
            get { return _hADD_MAKERHALFNAMERF; }
            set { _hADD_MAKERHALFNAMERF = value; }
        }

        /// public propaty name  :  HADD_MODELHALFNAMERF
        /// <summary>(先頭)車種半角名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   (先頭)車種半角名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_MODELHALFNAMERF
        {
            get { return _hADD_MODELHALFNAMERF; }
            set { _hADD_MODELHALFNAMERF = value; }
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

        /// public propaty name  :  HADD_PRINTCUSTOMERNAMEJOIN12RF
        /// <summary>得意先名１＋得意先名２プロパティ</summary>
        /// <value>名称１＋名称２</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先名１＋得意先名２プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_PRINTCUSTOMERNAMEJOIN12RF
        {
            get { return _hADD_PRINTCUSTOMERNAMEJOIN12RF; }
            set { _hADD_PRINTCUSTOMERNAMEJOIN12RF = value; }
        }

        /// public propaty name  :  HADD_PRINTCUSTOMERNAMEJOIN12HNRF
        /// <summary>得意先名１＋得意先名２＋敬称プロパティ</summary>
        /// <value>名称１＋名称２＋空白＋敬称</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先名１＋得意先名２＋敬称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_PRINTCUSTOMERNAMEJOIN12HNRF
        {
            get { return _hADD_PRINTCUSTOMERNAMEJOIN12HNRF; }
            set { _hADD_PRINTCUSTOMERNAMEJOIN12HNRF = value; }
        }

        /// public propaty name  :  HADD_PRINTENTERPRISENAME1FHRF
        /// <summary>自社名１（前半）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社名１（前半）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_PRINTENTERPRISENAME1FHRF
        {
            get { return _hADD_PRINTENTERPRISENAME1FHRF; }
            set { _hADD_PRINTENTERPRISENAME1FHRF = value; }
        }

        /// public propaty name  :  HADD_PRINTENTERPRISENAME1LHRF
        /// <summary>自社名１（後半）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社名１（後半）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_PRINTENTERPRISENAME1LHRF
        {
            get { return _hADD_PRINTENTERPRISENAME1LHRF; }
            set { _hADD_PRINTENTERPRISENAME1LHRF = value; }
        }

        /// public propaty name  :  HADD_PRINTENTERPRISENAME2FHRF
        /// <summary>自社名２（前半）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社名２（前半）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_PRINTENTERPRISENAME2FHRF
        {
            get { return _hADD_PRINTENTERPRISENAME2FHRF; }
            set { _hADD_PRINTENTERPRISENAME2FHRF = value; }
        }

        /// public propaty name  :  HADD_PRINTENTERPRISENAME2LHRF
        /// <summary>自社名２（後半）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社名２（後半）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_PRINTENTERPRISENAME2LHRF
        {
            get { return _hADD_PRINTENTERPRISENAME2LHRF; }
            set { _hADD_PRINTENTERPRISENAME2LHRF = value; }
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

        /// public propaty name  :  SALESSLIPRF_UPDATEDATETIMERF
        /// <summary>更新日時プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新日時プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SALESSLIPRF_UPDATEDATETIMERF
        {
            get { return _sALESSLIPRF_UPDATEDATETIMERF; }
            set { _sALESSLIPRF_UPDATEDATETIMERF = value; }
        }

        // --- ADD 2009.07.24 劉洋 ------ >>>>>>
        /// public propaty name  :  SANDESETTINGRF_CUSTOMERCODE
        /// <summary>得意先コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SANDESETTINGRF_CUSTOMERCODE
        {
            get { return _sANDESETTINGRF_CUSTOMERCODE; }
            set { _sANDESETTINGRF_CUSTOMERCODE = value; }
        }

        /// public propaty name  :  SANDESETTINGRF_ADDRESSEESHOPCD
        /// <summary>納品先店舗コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   納品先店舗コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SANDESETTINGRF_ADDRESSEESHOPCD
        {
            get { return _sANDESETTINGRF_ADDRESSEESHOPCD; }
            set { _sANDESETTINGRF_ADDRESSEESHOPCD = value; }
        }

        /// public propaty name  :  SANDESETTINGRF_SANDEMNGCODE
        /// <summary>住電管理コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   住電管理コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SANDESETTINGRF_SANDEMNGCODE
        {
            get { return _sANDESETTINGRF_SANDEMNGCODE; }
            set { _sANDESETTINGRF_SANDEMNGCODE = value; }
        }

        /// public propaty name  :  SANDESETTINGRF_EXPENSEDIVCD
        /// <summary>経費区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   経費区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SANDESETTINGRF_EXPENSEDIVCD
        {
            get { return _sANDESETTINGRF_EXPENSEDIVCD; }
            set { _sANDESETTINGRF_EXPENSEDIVCD = value; }
        }

        /// public propaty name  :  SANDESETTINGRF_DIRECTSENDINGCD
        /// <summary>直送区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   直送区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SANDESETTINGRF_DIRECTSENDINGCD
        {
            get { return _sANDESETTINGRF_DIRECTSENDINGCD; }
            set { _sANDESETTINGRF_DIRECTSENDINGCD = value; }
        }

        /// public propaty name  :  SANDESETTINGRF_ACPTANORDERDIV
        /// <summary>受注区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   受注区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SANDESETTINGRF_ACPTANORDERDIV
        {
            get { return _sANDESETTINGRF_ACPTANORDERDIV; }
            set { _sANDESETTINGRF_ACPTANORDERDIV = value; }
        }

        /// public propaty name  :  SANDESETTINGRF_DElIVERERCD
        /// <summary>納品者コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   納品者コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SANDESETTINGRF_DELIVERERCD
        {
            get { return _sANDESETTINGRF_DELIVERERCD; }
            set { _sANDESETTINGRF_DELIVERERCD = value; }
        }

        /// public propaty name  :  SANDESETTINGRF_DElIVERERNM
        /// <summary>納品者名プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   納品者名プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SANDESETTINGRF_DELIVERERNM
        {
            get { return _sANDESETTINGRF_DELIVERERNM; }
            set { _sANDESETTINGRF_DELIVERERNM = value; }
        }

        /// public propaty name  :  SANDESETTINGRF_DElIVERERADDRESS
        /// <summary>納品者住所プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   納品者住所プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SANDESETTINGRF_DELIVERERADDRESS
        {
            get { return _sANDESETTINGRF_DELIVERERADDRESS; }
            set { _sANDESETTINGRF_DELIVERERADDRESS = value; }
        }

        /// public propaty name  :  SANDESETTINGRF_DElIVERERPHONENUM
        /// <summary>納品者ＴＥＬプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   納品者ＴＥＬプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SANDESETTINGRF_DELIVERERPHONENUM
        {
            get { return _sANDESETTINGRF_DELIVERERPHONENUM; }
            set { _sANDESETTINGRF_DELIVERERPHONENUM = value; }
        }

        /// public propaty name  :  SANDESETTINGRF_TRADCOMPNAME
        /// <summary>部品商名プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   部品商名プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SANDESETTINGRF_TRADCOMPNAME
        {
            get { return _sANDESETTINGRF_TRADCOMPNAME; }
            set { _sANDESETTINGRF_TRADCOMPNAME = value; }
        }

        /// public propaty name  :  SANDESETTINGRF_TRADCOMPSECTNAME
        /// <summary>部品商拠点名プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   部品商拠点名プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SANDESETTINGRF_TRADCOMPSECTNAME
        {
            get { return _sANDESETTINGRF_TRADCOMPSECTNAME; }
            set { _sANDESETTINGRF_TRADCOMPSECTNAME = value; }
        }

        /// public propaty name  :  SANDESETTINGRF_PURETRADCOMPCD
        /// <summary>部品商コード（純正）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   部品商コード（純正）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SANDESETTINGRF_PURETRADCOMPCD
        {
            get { return _sANDESETTINGRF_PURETRADCOMPCD; }
            set { _sANDESETTINGRF_PURETRADCOMPCD = value; }
        }

        /// public propaty name  :  SANDESETTINGRF_PURETRADCOMPRATE
        /// <summary>部品商仕切率（純正）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   部品商仕切率（純正）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double SANDESETTINGRF_PURETRADCOMPRATE
        {
            get { return _sANDESETTINGRF_PURETRADCOMPRATE; }
            set { _sANDESETTINGRF_PURETRADCOMPRATE = value; }
        }

        /// public propaty name  :  SANDESETTINGRF_PRITRADCOMPCD
        /// <summary>部品商コード（優良）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   部品商コード（優良）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SANDESETTINGRF_PRITRADCOMPCD
        {
            get { return _sANDESETTINGRF_PRITRADCOMPCD; }
            set { _sANDESETTINGRF_PRITRADCOMPCD = value; }
        }

        /// public propaty name  :  SANDESETTINGRF_PRITRADCOMPRATE
        /// <summary>部品商仕切率（優良）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   部品商仕切率（優良）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double SANDESETTINGRF_PRITRADCOMPRATE
        {
            get { return _sANDESETTINGRF_PRITRADCOMPRATE; }
            set { _sANDESETTINGRF_PRITRADCOMPRATE = value; }
        }

        /// public propaty name  :  SANDESETTINGRF_ABGOODSCODE
        /// <summary>AB商品コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   AB商品コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SANDESETTINGRF_ABGOODSCODE
        {
            get { return _sANDESETTINGRF_ABGOODSCODE; }
            set { _sANDESETTINGRF_ABGOODSCODE = value; }
        }

        /// public propaty name  :  SANDESETTINGRF_COMMENTRESERVEDDIV
        /// <summary>コメント指定区分プロパティ</summary>
        /// <value>"７行目コメント指定区分"</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   コメント指定区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SANDESETTINGRF_COMMENTRESERVEDDIV
        {
            get { return _sANDESETTINGRF_COMMENTRESERVEDDIV; }
            set { _sANDESETTINGRF_COMMENTRESERVEDDIV = value; }
        }

        /// public propaty name  :  SANDESETTINGRF_GOODSMAKERCD1
        /// <summary>商品メーカーコード１プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品メーカーコード１プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SANDESETTINGRF_GOODSMAKERCD1
        {
            get { return _sANDESETTINGRF_GOODSMAKERCD1; }
            set { _sANDESETTINGRF_GOODSMAKERCD1 = value; }
        }

        /// public propaty name  :  SANDESETTINGRF_GOODSMAKERCD2
        /// <summary>商品メーカーコード２プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品メーカーコード２プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SANDESETTINGRF_GOODSMAKERCD2
        {
            get { return _sANDESETTINGRF_GOODSMAKERCD2; }
            set { _sANDESETTINGRF_GOODSMAKERCD2 = value; }
        }

        /// public propaty name  :  SANDESETTINGRF_GOODSMAKERCD3
        /// <summary>商品メーカーコード３プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品メーカーコード３プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SANDESETTINGRF_GOODSMAKERCD3
        {
            get { return _sANDESETTINGRF_GOODSMAKERCD3; }
            set { _sANDESETTINGRF_GOODSMAKERCD3 = value; }
        }

        /// public propaty name  :  SANDESETTINGRF_GOODSMAKERCD4
        /// <summary>商品メーカーコード４プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品メーカーコード４プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SANDESETTINGRF_GOODSMAKERCD4
        {
            get { return _sANDESETTINGRF_GOODSMAKERCD4; }
            set { _sANDESETTINGRF_GOODSMAKERCD4 = value; }
        }

        /// public propaty name  :  SANDESETTINGRF_GOODSMAKERCD5
        /// <summary>商品メーカーコード５プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品メーカーコード５プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SANDESETTINGRF_GOODSMAKERCD5
        {
            get { return _sANDESETTINGRF_GOODSMAKERCD5; }
            set { _sANDESETTINGRF_GOODSMAKERCD5 = value; }
        }

        /// public propaty name  :  SANDESETTINGRF_GOODSMAKERCD6
        /// <summary>商品メーカーコード６プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品メーカーコード６プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SANDESETTINGRF_GOODSMAKERCD6
        {
            get { return _sANDESETTINGRF_GOODSMAKERCD6; }
            set { _sANDESETTINGRF_GOODSMAKERCD6 = value; }
        }

        /// public propaty name  :  SANDESETTINGRF_GOODSMAKERCD7
        /// <summary>商品メーカーコード７プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品メーカーコード７プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SANDESETTINGRF_GOODSMAKERCD7
        {
            get { return _sANDESETTINGRF_GOODSMAKERCD7; }
            set { _sANDESETTINGRF_GOODSMAKERCD7 = value; }
        }

        /// public propaty name  :  SANDESETTINGRF_GOODSMAKERCD8
        /// <summary>商品メーカーコード８プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品メーカーコード８プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SANDESETTINGRF_GOODSMAKERCD8
        {
            get { return _sANDESETTINGRF_GOODSMAKERCD8; }
            set { _sANDESETTINGRF_GOODSMAKERCD8 = value; }
        }

        /// public propaty name  :  SANDESETTINGRF_GOODSMAKERCD9
        /// <summary>商品メーカーコード９プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品メーカーコード９プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SANDESETTINGRF_GOODSMAKERCD9
        {
            get { return _sANDESETTINGRF_GOODSMAKERCD9; }
            set { _sANDESETTINGRF_GOODSMAKERCD9 = value; }
        }

        /// public propaty name  :  SANDESETTINGRF_GOODSMAKERCD10
        /// <summary>商品メーカーコード１０プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品メーカーコード１０プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SANDESETTINGRF_GOODSMAKERCD10
        {
            get { return _sANDESETTINGRF_GOODSMAKERCD10; }
            set { _sANDESETTINGRF_GOODSMAKERCD10 = value; }
        }

        /// public propaty name  :  SANDESETTINGRF_GOODSMAKERCD11
        /// <summary>商品メーカーコード１１プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品メーカーコード１１プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SANDESETTINGRF_GOODSMAKERCD11
        {
            get { return _sANDESETTINGRF_GOODSMAKERCD11; }
            set { _sANDESETTINGRF_GOODSMAKERCD11 = value; }
        }

        /// public propaty name  :  SANDESETTINGRF_GOODSMAKERCD12
        /// <summary>商品メーカーコード１２プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品メーカーコード１２プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SANDESETTINGRF_GOODSMAKERCD12
        {
            get { return _sANDESETTINGRF_GOODSMAKERCD12; }
            set { _sANDESETTINGRF_GOODSMAKERCD12 = value; }
        }

        /// public propaty name  :  SANDESETTINGRF_GOODSMAKERCD13
        /// <summary>商品メーカーコード１３プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品メーカーコード１３プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SANDESETTINGRF_GOODSMAKERCD13
        {
            get { return _sANDESETTINGRF_GOODSMAKERCD13; }
            set { _sANDESETTINGRF_GOODSMAKERCD13 = value; }
        }

        /// public propaty name  :  SANDESETTINGRF_GOODSMAKERCD14
        /// <summary>商品メーカーコード１４プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品メーカーコード１４プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SANDESETTINGRF_GOODSMAKERCD14
        {
            get { return _sANDESETTINGRF_GOODSMAKERCD14; }
            set { _sANDESETTINGRF_GOODSMAKERCD14 = value; }
        }

        /// public propaty name  :  SANDESETTINGRF_GOODSMAKERCD15
        /// <summary>商品メーカーコード１５プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品メーカーコード１５プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SANDESETTINGRF_GOODSMAKERCD15
        {
            get { return _sANDESETTINGRF_GOODSMAKERCD15; }
            set { _sANDESETTINGRF_GOODSMAKERCD15 = value; }
        }

        /// public propaty name  :  SANDESETTINGRF_PARTSOEMDIV
        /// <summary>部品ＯＥＭ区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   部品ＯＥＭ区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SANDESETTINGRF_PARTSOEMDIV
        {
            get { return _sANDESETTINGRF_PARTSOEMDIV; }
            set { _sANDESETTINGRF_PARTSOEMDIV = value; }
        }
        // --- ADD 2009.07.24 劉洋 ------ <<<<<<
        // --- ADD  大矢睦美  2010/03/01 ---------->>>>>
        /// public propaty name  :  CSTCST_SALESUNPRCFRCPROCCDRF
        /// <summary>売上単価端数処理コードプロパティ</summary>
        /// <value>0の場合は 標準設定とする。</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上単価端数処理コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CSTCST_SALESUNPRCFRCPROCCDRF
        {
            get { return _cSTCST_SALESUNPRCFRCPROCCDRF; }
            set { _cSTCST_SALESUNPRCFRCPROCCDRF = value; }
        }

        /// public propaty name  :  CSTCST_SALESMONEYFRCPROCCDRF
        /// <summary>売上金額端数処理コードプロパティ</summary>
        /// <value>0の場合は 標準設定とする。</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上金額端数処理コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CSTCST_SALESMONEYFRCPROCCDRF
        {
            get { return _cSTCST_SALESMONEYFRCPROCCDRF; }
            set { _cSTCST_SALESMONEYFRCPROCCDRF = value; }
        }

        /// public propaty name  :  CSTCST_SALESCNSTAXFRCPROCCDRF
        /// <summary>売上消費税端数処理コードプロパティ</summary>
        /// <value>0の場合は 標準設定とする。</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上消費税端数処理コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CSTCST_SALESCNSTAXFRCPROCCDRF
        {
            get { return _cSTCST_SALESCNSTAXFRCPROCCDRF; }
            set { _cSTCST_SALESCNSTAXFRCPROCCDRF = value; }
        }

        // --- ADD  大矢睦美  2010/03/01 ----------<<<<<
        // --- ADD m.suzuki 2010/03/24 ---------->>>>>
        /// public propaty name  :  CSTCST_SALESCNSTAXFRCPROCCDRF
        /// <summary>QRコード印刷プロパティ</summary>
        /// <value>0:標準 1:印字しない 2:印字する 3:返品含む</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   QRコード印刷プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CSTCST_QRCODEPRTCDRF
        {
            get { return _cSTCST_QRCODEPRTCDRF; }
            set { _cSTCST_QRCODEPRTCDRF = value; }
        }
        // --- ADD m.suzuki 2010/03/24 ----------<<<<<

        // 2010/07/06 Add >>>
        /// public propaty name  :  SALESSLIPRF_FILEHEADERGUID
        /// <summary>売上データヘッダガイドプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上データヘッダガイドプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Guid SALESSLIPRF_FILEHEADERGUID
        {
            get { return _sALESSLIPRF_FILEHEADERGUID; }
            set { _sALESSLIPRF_FILEHEADERGUID = value; }
        }
        // 2010/07/06 Add <<<

        // ---- ADD caohh 2011/08/17 ------>>>>>
        /// public propaty name  :  CSTCST_POSTNORF
        /// <summary>郵便番号プロパティ</summary>
        /// <value>納入先の場合の使用可能項目</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   郵便番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CSTCST_POSTNORF
        {
            get { return _cSTCST_POSTNORF; }
            set { _cSTCST_POSTNORF = value; }
        }

        /// public propaty name  :  CSTCST_ADDRESS1RF
        /// <summary>住所1（都道府県市区郡・町村・字）プロパティ</summary>
        /// <value>納入先の場合の使用可能項目</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   住所1（都道府県市区郡・町村・字）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CSTCST_ADDRESS1RF
        {
            get { return _cSTCST_ADDRESS1RF; }
            set { _cSTCST_ADDRESS1RF = value; }
        }

        /// public propaty name  :  CSTCST_ADDRESS3RF
        /// <summary>住所3（番地）プロパティ</summary>
        /// <value>納入先の場合の使用可能項目</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   住所3（番地）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CSTCST_ADDRESS3RF
        {
            get { return _cSTCST_ADDRESS3RF; }
            set { _cSTCST_ADDRESS3RF = value; }
        }

        /// public propaty name  :  CSTCST_ADDRESS4RF
        /// <summary>住所4（アパート名称）プロパティ</summary>
        /// <value>納入先の場合の使用可能項目</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   住所4（アパート名称）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CSTCST_ADDRESS4RF
        {
            get { return _cSTCST_ADDRESS4RF; }
            set { _cSTCST_ADDRESS4RF = value; }
        }

        /// public propaty name  :  CSTCST_HOMETELNORF
        /// <summary>電話番号（自宅）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   電話番号（自宅）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CSTCST_HOMETELNORF
        {
            get { return _cSTCST_HOMETELNORF; }
            set { _cSTCST_HOMETELNORF = value; }
        }

        /// public propaty name  :  CSTCST_OFFICETELNORF
        /// <summary>電話番号（勤務先）プロパティ</summary>
        /// <value>納入先の場合の使用可能項目</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   電話番号（勤務先）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CSTCST_OFFICETELNORF
        {
            get { return _cSTCST_OFFICETELNORF; }
            set { _cSTCST_OFFICETELNORF = value; }
        }

        /// public propaty name  :  CSTCST_PORTABLETELNORF
        /// <summary>電話番号（携帯）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   電話番号（携帯）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CSTCST_PORTABLETELNORF
        {
            get { return _cSTCST_PORTABLETELNORF; }
            set { _cSTCST_PORTABLETELNORF = value; }
        }

        /// public propaty name  :  CSTCST_HOMEFAXNORF
        /// <summary>FAX番号（自宅）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   FAX番号（自宅）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CSTCST_HOMEFAXNORF
        {
            get { return _cSTCST_HOMEFAXNORF; }
            set { _cSTCST_HOMEFAXNORF = value; }
        }

        /// public propaty name  :  CSTCST_OFFICEFAXNORF
        /// <summary>FAX番号（勤務先）プロパティ</summary>
        /// <value>納入先の場合の使用可能項目</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   FAX番号（勤務先）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CSTCST_OFFICEFAXNORF
        {
            get { return _cSTCST_OFFICEFAXNORF; }
            set { _cSTCST_OFFICEFAXNORF = value; }
        }

        /// public propaty name  :  CSTCST_OTHERSTELNORF
        /// <summary>電話番号（その他）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   電話番号（その他）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CSTCST_OTHERSTELNORF
        {
            get { return _cSTCST_OTHERSTELNORF; }
            set { _cSTCST_OTHERSTELNORF = value; }
        }
        // ---- ADD caohh 2011/08/17 ------<<<<<

        /// <summary>
        /// 自由帳票売上伝票データワークコンストラクタ
        /// </summary>
        /// <returns>FrePSalesSlipWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   FrePSalesSlipWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public FrePSalesSlipWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>FrePSalesSlipWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   FrePSalesSlipWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class FrePSalesSlipWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   FrePSalesSlipWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize( System.IO.BinaryWriter writer, object graph )
        {
            // TODO:  FrePSalesSlipWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if ( writer == null )
                throw new ArgumentNullException();

            if ( graph != null && !(graph is FrePSalesSlipWork || graph is ArrayList || graph is FrePSalesSlipWork[]) )
                throw new ArgumentException( string.Format( "graphが{0}のインスタンスでありません", typeof( FrePSalesSlipWork ).FullName ) );

            if ( graph != null && graph is FrePSalesSlipWork )
            {
                Type t = graph.GetType();
                if ( !CustomFormatterServices.NeedCustomSerialization( t ) )
                    throw new ArgumentException( string.Format( "graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName ) );
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo( ", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.FrePSalesSlipWork" );

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if ( graph is ArrayList )
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if ( graph is FrePSalesSlipWork[] )
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((FrePSalesSlipWork[])graph).Length;
            }
            else if ( graph is FrePSalesSlipWork )
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
            //赤黒連結売上伝票番号
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESSLIPRF_DEBITNLNKSALESSLNUMRF
            //売上伝票区分
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SALESSLIPRF_SALESSLIPCDRF
            //売上商品区分
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SALESSLIPRF_SALESGOODSCDRF
            //売掛区分
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SALESSLIPRF_ACCRECDIVCDRF
            //伝票検索日付
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SALESSLIPRF_SEARCHSLIPDATERF
            //出荷日付
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SALESSLIPRF_SHIPMENTDAYRF
            //売上日付
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SALESSLIPRF_SALESDATERF
            //計上日付
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SALESSLIPRF_ADDUPADATERF
            //来勘区分
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SALESSLIPRF_DELAYPAYMENTDIVRF
            //見積書番号
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESSLIPRF_ESTIMATEFORMNORF
            //見積区分
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SALESSLIPRF_ESTIMATEDIVIDERF
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
            //総額表示方法区分
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SALESSLIPRF_TOTALAMOUNTDISPWAYCDRF
            //総額表示掛率適用区分
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SALESSLIPRF_TTLAMNTDISPRATEAPYRF
            //売上伝票合計（税込み）
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //SALESSLIPRF_SALESTOTALTAXINCRF
            //売上伝票合計（税抜き）
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //SALESSLIPRF_SALESTOTALTAXEXCRF
            //売上小計（税込み）
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //SALESSLIPRF_SALESSUBTOTALTAXINCRF
            //売上小計（税抜き）
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //SALESSLIPRF_SALESSUBTOTALTAXEXCRF
            //売上小計（税）
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //SALESSLIPRF_SALESSUBTOTALTAXRF
            //売上外税対象額
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //SALESSLIPRF_ITDEDSALESOUTTAXRF
            //売上内税対象額
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //SALESSLIPRF_ITDEDSALESINTAXRF
            //売上小計非課税対象額
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //SALESSLIPRF_SALSUBTTLSUBTOTAXFRERF
            //売上金額消費税額（内税）
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //SALESSLIPRF_SALAMNTCONSTAXINCLURF
            //売上値引金額計（税抜き）
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //SALESSLIPRF_SALESDISTTLTAXEXCRF
            //売上値引外税対象額合計
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //SALESSLIPRF_ITDEDSALESDISOUTTAXRF
            //売上値引内税対象額合計
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //SALESSLIPRF_ITDEDSALESDISINTAXRF
            //売上値引消費税額（外税）
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //SALESSLIPRF_SALESDISOUTTAXRF
            //売上値引消費税額（内税）
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //SALESSLIPRF_SALESDISTTLTAXINCLURF
            //原価金額計
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //SALESSLIPRF_TOTALCOSTRF
            //消費税転嫁方式
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SALESSLIPRF_CONSTAXLAYMETHODRF
            //消費税税率
            serInfo.MemberInfo.Add( typeof( Double ) ); //SALESSLIPRF_CONSTAXRATERF
            //端数処理区分
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SALESSLIPRF_FRACTIONPROCCDRF
            //売掛消費税
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //SALESSLIPRF_ACCRECCONSTAXRF
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
            //請求先略称
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESSLIPRF_CLAIMSNMRF
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
            //納品先郵便番号
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESSLIPRF_ADDRESSEEPOSTNORF
            //納品先住所1(都道府県市区郡・町村・字)
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESSLIPRF_ADDRESSEEADDR1RF
            //納品先住所3(番地)
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESSLIPRF_ADDRESSEEADDR3RF
            //納品先住所4(アパート名称)
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESSLIPRF_ADDRESSEEADDR4RF
            //納品先電話番号
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESSLIPRF_ADDRESSEETELNORF
            //納品先FAX番号
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESSLIPRF_ADDRESSEEFAXNORF
            //相手先伝票番号
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESSLIPRF_PARTYSALESLIPNUMRF
            //伝票備考
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESSLIPRF_SLIPNOTERF
            //伝票備考２
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESSLIPRF_SLIPNOTE2RF
            //返品理由コード
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SALESSLIPRF_RETGOODSREASONDIVRF
            //返品理由
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESSLIPRF_RETGOODSREASONRF
            //レジ処理日
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SALESSLIPRF_REGIPROCDATERF
            //レジ番号
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SALESSLIPRF_CASHREGISTERNORF
            //POSレシート番号
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SALESSLIPRF_POSRECEIPTNORF
            //明細行数
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SALESSLIPRF_DETAILROWCOUNTRF
            //ＥＤＩ送信日
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SALESSLIPRF_EDISENDDATERF
            //ＥＤＩ取込日
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SALESSLIPRF_EDITAKEINDATERF
            //ＵＯＥリマーク１
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESSLIPRF_UOEREMARK1RF
            //ＵＯＥリマーク２
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESSLIPRF_UOEREMARK2RF
            //伝票発行済区分
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SALESSLIPRF_SLIPPRINTFINISHCDRF
            //売上伝票発行日
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SALESSLIPRF_SALESSLIPPRINTDATERF
            //業種コード
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SALESSLIPRF_BUSINESSTYPECODERF
            //業種名称
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESSLIPRF_BUSINESSTYPENAMERF
            //発注番号
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESSLIPRF_ORDERNUMBERRF
            //納品区分
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SALESSLIPRF_DELIVEREDGOODSDIVRF
            //納品区分名称
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESSLIPRF_DELIVEREDGOODSDIVNMRF
            //販売エリアコード
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SALESSLIPRF_SALESAREACODERF
            //販売エリア名称
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESSLIPRF_SALESAREANAMERF
            //在庫商品合計金額（税抜）
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //SALESSLIPRF_STOCKGOODSTTLTAXEXCRF
            //純正商品合計金額（税抜）
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //SALESSLIPRF_PUREGOODSTTLTAXEXCRF
            //定価印刷区分
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SALESSLIPRF_LISTPRICEPRINTDIVRF
            //元号表示区分１
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SALESSLIPRF_ERANAMEDISPCD1RF
            //見積消費税区分
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SALESSLIPRF_ESTIMATAXDIVCDRF
            //見積書印刷区分
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SALESSLIPRF_ESTIMATEFORMPRTCDRF
            //見積件名
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESSLIPRF_ESTIMATESUBJECTRF
            //脚注１
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESSLIPRF_FOOTNOTES1RF
            //脚注２
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESSLIPRF_FOOTNOTES2RF
            //見積タイトル１
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESSLIPRF_ESTIMATETITLE1RF
            //見積タイトル２
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESSLIPRF_ESTIMATETITLE2RF
            //見積タイトル３
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESSLIPRF_ESTIMATETITLE3RF
            //見積タイトル４
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESSLIPRF_ESTIMATETITLE4RF
            //見積タイトル５
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESSLIPRF_ESTIMATETITLE5RF
            //見積備考１
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESSLIPRF_ESTIMATENOTE1RF
            //見積備考２
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESSLIPRF_ESTIMATENOTE2RF
            //見積備考３
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESSLIPRF_ESTIMATENOTE3RF
            //見積備考４
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESSLIPRF_ESTIMATENOTE4RF
            //見積備考５
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESSLIPRF_ESTIMATENOTE5RF
            //拠点ガイド名称
            serInfo.MemberInfo.Add( typeof( string ) ); //SECINFOSETRF_SECTIONGUIDENMRF
            //拠点ガイド略称
            serInfo.MemberInfo.Add( typeof( string ) ); //SECINFOSETRF_SECTIONGUIDESNMRF
            //自社名称コード1
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SECINFOSETRF_COMPANYNAMECD1RF
            //自社PR文
            serInfo.MemberInfo.Add( typeof( string ) ); //COMPANYNMRF_COMPANYPRRF
            //自社名称1
            serInfo.MemberInfo.Add( typeof( string ) ); //COMPANYNMRF_COMPANYNAME1RF
            //自社名称2
            serInfo.MemberInfo.Add( typeof( string ) ); //COMPANYNMRF_COMPANYNAME2RF
            //郵便番号
            serInfo.MemberInfo.Add( typeof( string ) ); //COMPANYNMRF_POSTNORF
            //住所1（都道府県市区郡・町村・字）
            serInfo.MemberInfo.Add( typeof( string ) ); //COMPANYNMRF_ADDRESS1RF
            //住所3（番地）
            serInfo.MemberInfo.Add( typeof( string ) ); //COMPANYNMRF_ADDRESS3RF
            //住所4（アパート名称）
            serInfo.MemberInfo.Add( typeof( string ) ); //COMPANYNMRF_ADDRESS4RF
            //自社電話番号1
            serInfo.MemberInfo.Add( typeof( string ) ); //COMPANYNMRF_COMPANYTELNO1RF
            //自社電話番号2
            serInfo.MemberInfo.Add( typeof( string ) ); //COMPANYNMRF_COMPANYTELNO2RF
            //自社電話番号3
            serInfo.MemberInfo.Add( typeof( string ) ); //COMPANYNMRF_COMPANYTELNO3RF
            //自社電話番号タイトル1
            serInfo.MemberInfo.Add( typeof( string ) ); //COMPANYNMRF_COMPANYTELTITLE1RF
            //自社電話番号タイトル2
            serInfo.MemberInfo.Add( typeof( string ) ); //COMPANYNMRF_COMPANYTELTITLE2RF
            //自社電話番号タイトル3
            serInfo.MemberInfo.Add( typeof( string ) ); //COMPANYNMRF_COMPANYTELTITLE3RF
            //銀行振込案内文
            serInfo.MemberInfo.Add( typeof( string ) ); //COMPANYNMRF_TRANSFERGUIDANCERF
            //銀行口座1
            serInfo.MemberInfo.Add( typeof( string ) ); //COMPANYNMRF_ACCOUNTNOINFO1RF
            //銀行口座2
            serInfo.MemberInfo.Add( typeof( string ) ); //COMPANYNMRF_ACCOUNTNOINFO2RF
            //銀行口座3
            serInfo.MemberInfo.Add( typeof( string ) ); //COMPANYNMRF_ACCOUNTNOINFO3RF
            //自社設定摘要1
            serInfo.MemberInfo.Add( typeof( string ) ); //COMPANYNMRF_COMPANYSETNOTE1RF
            //自社設定摘要2
            serInfo.MemberInfo.Add( typeof( string ) ); //COMPANYNMRF_COMPANYSETNOTE2RF
            //画像情報区分
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //COMPANYNMRF_IMAGEINFODIVRF
            //画像情報コード
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //COMPANYNMRF_IMAGEINFOCODERF
            //自社URL
            serInfo.MemberInfo.Add( typeof( string ) ); //COMPANYNMRF_COMPANYURLRF
            //自社PR文2
            serInfo.MemberInfo.Add( typeof( string ) ); //COMPANYNMRF_COMPANYPRSENTENCE2RF
            //画像印字用コメント1
            serInfo.MemberInfo.Add( typeof( string ) ); //COMPANYNMRF_IMAGECOMMENTFORPRT1RF
            //画像印字用コメント2
            serInfo.MemberInfo.Add( typeof( string ) ); //COMPANYNMRF_IMAGECOMMENTFORPRT2RF
            //自社画像
            serInfo.MemberInfo.Add( typeof( Byte[] ) ); //IMAGEINFORF_IMAGEINFODATARF
            //部門名称
            serInfo.MemberInfo.Add( typeof( string ) ); //SUBSECTIONRF_SUBSECTIONNAMERF
            //売上入力者カナ
            serInfo.MemberInfo.Add( typeof( string ) ); //EMPINP_KANARF
            //売上入力者短縮名称
            serInfo.MemberInfo.Add( typeof( string ) ); //EMPINP_SHORTNAMERF
            //受付従業員カナ
            serInfo.MemberInfo.Add( typeof( string ) ); //EMPFRT_KANARF
            //受付従業員短縮名称
            serInfo.MemberInfo.Add( typeof( string ) ); //EMPFRT_SHORTNAMERF
            //販売従業員カナ
            serInfo.MemberInfo.Add( typeof( string ) ); //EMPSAL_KANARF
            //販売従業員短縮名称
            serInfo.MemberInfo.Add( typeof( string ) ); //EMPSAL_SHORTNAMERF
            //請求先サブコード
            serInfo.MemberInfo.Add( typeof( string ) ); //CSTCLM_CUSTOMERSUBCODERF
            //請求先名称
            serInfo.MemberInfo.Add( typeof( string ) ); //CSTCLM_NAMERF
            //請求先名称2
            serInfo.MemberInfo.Add( typeof( string ) ); //CSTCLM_NAME2RF
            //請求先敬称
            serInfo.MemberInfo.Add( typeof( string ) ); //CSTCLM_HONORIFICTITLERF
            //請求先カナ
            serInfo.MemberInfo.Add( typeof( string ) ); //CSTCLM_KANARF
            //請求先略称
            serInfo.MemberInfo.Add( typeof( string ) ); //CSTCLM_CUSTOMERSNMRF
            //請求先諸口コード
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //CSTCLM_OUTPUTNAMECODERF
            //請求先分析コード1
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //CSTCLM_CUSTANALYSCODE1RF
            //請求先分析コード2
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //CSTCLM_CUSTANALYSCODE2RF
            //請求先分析コード3
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //CSTCLM_CUSTANALYSCODE3RF
            //請求先分析コード4
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //CSTCLM_CUSTANALYSCODE4RF
            //請求先分析コード5
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //CSTCLM_CUSTANALYSCODE5RF
            //請求先分析コード6
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //CSTCLM_CUSTANALYSCODE6RF
            //請求先備考1
            serInfo.MemberInfo.Add( typeof( string ) ); //CSTCLM_NOTE1RF
            //請求先備考2
            serInfo.MemberInfo.Add( typeof( string ) ); //CSTCLM_NOTE2RF
            //請求先備考3
            serInfo.MemberInfo.Add( typeof( string ) ); //CSTCLM_NOTE3RF
            //請求先備考4
            serInfo.MemberInfo.Add( typeof( string ) ); //CSTCLM_NOTE4RF
            //請求先備考5
            serInfo.MemberInfo.Add( typeof( string ) ); //CSTCLM_NOTE5RF
            //請求先備考6
            serInfo.MemberInfo.Add( typeof( string ) ); //CSTCLM_NOTE6RF
            //請求先備考7
            serInfo.MemberInfo.Add( typeof( string ) ); //CSTCLM_NOTE7RF
            //請求先備考8
            serInfo.MemberInfo.Add( typeof( string ) ); //CSTCLM_NOTE8RF
            //請求先備考9
            serInfo.MemberInfo.Add( typeof( string ) ); //CSTCLM_NOTE9RF
            //請求先備考10
            serInfo.MemberInfo.Add( typeof( string ) ); //CSTCLM_NOTE10RF
            //得意先サブコード
            serInfo.MemberInfo.Add( typeof( string ) ); //CSTCST_CUSTOMERSUBCODERF
            //得意先名称
            serInfo.MemberInfo.Add( typeof( string ) ); //CSTCST_NAMERF
            //得意先名称2
            serInfo.MemberInfo.Add( typeof( string ) ); //CSTCST_NAME2RF
            //得意先敬称
            serInfo.MemberInfo.Add( typeof( string ) ); //CSTCST_HONORIFICTITLERF
            //得意先カナ
            serInfo.MemberInfo.Add( typeof( string ) ); //CSTCST_KANARF
            //得意先略称
            serInfo.MemberInfo.Add( typeof( string ) ); //CSTCST_CUSTOMERSNMRF
            //得意先諸口コード
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //CSTCST_OUTPUTNAMECODERF
            //得意先分析コード1
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //CSTCST_CUSTANALYSCODE1RF
            //得意先分析コード2
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //CSTCST_CUSTANALYSCODE2RF
            //得意先分析コード3
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //CSTCST_CUSTANALYSCODE3RF
            //得意先分析コード4
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //CSTCST_CUSTANALYSCODE4RF
            //得意先分析コード5
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //CSTCST_CUSTANALYSCODE5RF
            //得意先分析コード6
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //CSTCST_CUSTANALYSCODE6RF
            //得意先備考1
            serInfo.MemberInfo.Add( typeof( string ) ); //CSTCST_NOTE1RF
            //得意先備考2
            serInfo.MemberInfo.Add( typeof( string ) ); //CSTCST_NOTE2RF
            //得意先備考3
            serInfo.MemberInfo.Add( typeof( string ) ); //CSTCST_NOTE3RF
            //得意先備考4
            serInfo.MemberInfo.Add( typeof( string ) ); //CSTCST_NOTE4RF
            //得意先備考5
            serInfo.MemberInfo.Add( typeof( string ) ); //CSTCST_NOTE5RF
            //得意先備考6
            serInfo.MemberInfo.Add( typeof( string ) ); //CSTCST_NOTE6RF
            //得意先備考7
            serInfo.MemberInfo.Add( typeof( string ) ); //CSTCST_NOTE7RF
            //得意先備考8
            serInfo.MemberInfo.Add( typeof( string ) ); //CSTCST_NOTE8RF
            //得意先備考9
            serInfo.MemberInfo.Add( typeof( string ) ); //CSTCST_NOTE9RF
            //得意先備考10
            serInfo.MemberInfo.Add( typeof( string ) ); //CSTCST_NOTE10RF
            //納入先サブコード
            serInfo.MemberInfo.Add( typeof( string ) ); //CSTADR_CUSTOMERSUBCODERF
            //納入先名称
            serInfo.MemberInfo.Add( typeof( string ) ); //CSTADR_NAMERF
            //納入先名称2
            serInfo.MemberInfo.Add( typeof( string ) ); //CSTADR_NAME2RF
            //納入先敬称
            serInfo.MemberInfo.Add( typeof( string ) ); //CSTADR_HONORIFICTITLERF
            //納入先カナ
            serInfo.MemberInfo.Add( typeof( string ) ); //CSTADR_KANARF
            //納入先略称
            serInfo.MemberInfo.Add( typeof( string ) ); //CSTADR_CUSTOMERSNMRF
            //納入先諸口コード
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //CSTADR_OUTPUTNAMECODERF
            //納入先分析コード1
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //CSTADR_CUSTANALYSCODE1RF
            //納入先分析コード2
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //CSTADR_CUSTANALYSCODE2RF
            //納入先分析コード3
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //CSTADR_CUSTANALYSCODE3RF
            //納入先分析コード4
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //CSTADR_CUSTANALYSCODE4RF
            //納入先分析コード5
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //CSTADR_CUSTANALYSCODE5RF
            //納入先分析コード6
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //CSTADR_CUSTANALYSCODE6RF
            //納入先備考1
            serInfo.MemberInfo.Add( typeof( string ) ); //CSTADR_NOTE1RF
            //納入先備考2
            serInfo.MemberInfo.Add( typeof( string ) ); //CSTADR_NOTE2RF
            //納入先備考3
            serInfo.MemberInfo.Add( typeof( string ) ); //CSTADR_NOTE3RF
            //納入先備考4
            serInfo.MemberInfo.Add( typeof( string ) ); //CSTADR_NOTE4RF
            //納入先備考5
            serInfo.MemberInfo.Add( typeof( string ) ); //CSTADR_NOTE5RF
            //納入先備考6
            serInfo.MemberInfo.Add( typeof( string ) ); //CSTADR_NOTE6RF
            //納入先備考7
            serInfo.MemberInfo.Add( typeof( string ) ); //CSTADR_NOTE7RF
            //納入先備考8
            serInfo.MemberInfo.Add( typeof( string ) ); //CSTADR_NOTE8RF
            //納入先備考9
            serInfo.MemberInfo.Add( typeof( string ) ); //CSTADR_NOTE9RF
            //納入先備考10
            serInfo.MemberInfo.Add( typeof( string ) ); //CSTADR_NOTE10RF
            //自社名称1
            serInfo.MemberInfo.Add( typeof( string ) ); //COMPANYINFRF_COMPANYNAME1RF
            //自社名称2
            serInfo.MemberInfo.Add( typeof( string ) ); //COMPANYINFRF_COMPANYNAME2RF
            //郵便番号
            serInfo.MemberInfo.Add( typeof( string ) ); //COMPANYINFRF_POSTNORF
            //住所1（都道府県市区郡・町村・字）
            serInfo.MemberInfo.Add( typeof( string ) ); //COMPANYINFRF_ADDRESS1RF
            //住所3（番地）
            serInfo.MemberInfo.Add( typeof( string ) ); //COMPANYINFRF_ADDRESS3RF
            //住所4（アパート名称）
            serInfo.MemberInfo.Add( typeof( string ) ); //COMPANYINFRF_ADDRESS4RF
            //自社電話番号1
            serInfo.MemberInfo.Add( typeof( string ) ); //COMPANYINFRF_COMPANYTELNO1RF
            //自社電話番号2
            serInfo.MemberInfo.Add( typeof( string ) ); //COMPANYINFRF_COMPANYTELNO2RF
            //自社電話番号3
            serInfo.MemberInfo.Add( typeof( string ) ); //COMPANYINFRF_COMPANYTELNO3RF
            //自社電話番号タイトル1
            serInfo.MemberInfo.Add( typeof( string ) ); //COMPANYINFRF_COMPANYTELTITLE1RF
            //自社電話番号タイトル2
            serInfo.MemberInfo.Add( typeof( string ) ); //COMPANYINFRF_COMPANYTELTITLE2RF
            //自社電話番号タイトル3
            serInfo.MemberInfo.Add( typeof( string ) ); //COMPANYINFRF_COMPANYTELTITLE3RF
            //受注ステータス名称
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_ACPTANODRSTNMRF
            //赤伝区分名称
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_DEBITNOTEDIVNMRF
            //売上伝票区分名称
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_SALESSLIPNMRF
            //売上商品区分名称
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_SALESGOODSNMRF
            //売掛区分名称
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_ACCRECDIVNMRF
            //来勘区分名称
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_DELAYPAYMENTDIVNMRF
            //見積区分名称
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_ESTIMATEDIVIDENMRF
            //消費税転嫁方式名称
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_CONSTAXLAYMETHODNMRF
            //自動入金区分名称
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_AUTODEPOSITNMRF
            //伝票発行済区分名称
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_SLIPPRINTFINISHNMRF
            //一式伝票区分名称
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_COMPLETENMRF
            //(先頭)車両管理番号
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_CARMNGNORF
            //(先頭)車輌管理コード
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_CARMNGCODERF
            //(先頭)陸運事務所番号
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_NUMBERPLATE1CODERF
            //(先頭)陸運事務局名称
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_NUMBERPLATE1NAMERF
            //(先頭)車両登録番号（種別）
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_NUMBERPLATE2RF
            //(先頭)車両登録番号（カナ）
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_NUMBERPLATE3RF
            //(先頭)車両登録番号（プレート番号）
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_NUMBERPLATE4RF
            //(先頭)初年度
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_FIRSTENTRYDATERF
            //(先頭)メーカーコード
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_MAKERCODERF
            //(先頭)メーカー全角名称
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_MAKERFULLNAMERF
            //(先頭)車種コード
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_MODELCODERF
            //(先頭)車種サブコード
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_MODELSUBCODERF
            //(先頭)車種全角名称
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_MODELFULLNAMERF
            //(先頭)排ガス記号
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_EXHAUSTGASSIGNRF
            //(先頭)シリーズ型式
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_SERIESMODELRF
            //(先頭)型式（類別記号）
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_CATEGORYSIGNMODELRF
            //(先頭)型式（フル型）
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_FULLMODELRF
            //(先頭)型式指定番号
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_MODELDESIGNATIONNORF
            //(先頭)類別番号
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_CATEGORYNORF
            //(先頭)車台型式
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_FRAMEMODELRF
            //(先頭)車台番号
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_FRAMENORF
            //(先頭)車台番号（検索用）
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_SEARCHFRAMENORF
            //(先頭)エンジン型式名称
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_ENGINEMODELNMRF
            //(先頭)関連型式
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_RELEVANCEMODELRF
            //(先頭)サブ車名コード
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_SUBCARNMCDRF
            //(先頭)型式グレード略称
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_MODELGRADESNAMERF
            //(先頭)カラーコード
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_COLORCODERF
            //(先頭)カラー名称1
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_COLORNAME1RF
            //(先頭)トリムコード
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_TRIMCODERF
            //(先頭)トリム名称
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_TRIMNAMERF
            //(先頭)車両走行距離
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_MILEAGERF
            //プリンタ管理No
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_PRINTERMNGNORF
            //伝票印刷設定用帳票ID
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_SLIPPRTSETPAPERIDRF
            //自社備考１
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_NOTE1RF
            //自社備考２
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_NOTE2RF
            //自社備考３
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_NOTE3RF
            //再発行マーク
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_REISSUEMARKRF
            //参考消費税印字名称
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_REFCONSTAXPRTNMRF
            //印刷時刻 時
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_PRINTTIMEHOURRF
            //印刷時刻 分
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_PRINTTIMEMINUTERF
            //印刷時刻 秒
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_PRINTTIMESECONDRF
            //伝票検索日付西暦年
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_SEARCHSLIPDATEFYRF
            //伝票検索日付西暦年略
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_SEARCHSLIPDATEFSRF
            //伝票検索日付和暦年
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_SEARCHSLIPDATEFWRF
            //伝票検索日付月
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_SEARCHSLIPDATEFMRF
            //伝票検索日付日
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_SEARCHSLIPDATEFDRF
            //伝票検索日付元号
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_SEARCHSLIPDATEFGRF
            //伝票検索日付略号
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_SEARCHSLIPDATEFRRF
            //伝票検索日付リテラル(/)
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_SEARCHSLIPDATEFLSRF
            //伝票検索日付リテラル(.)
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_SEARCHSLIPDATEFLPRF
            //伝票検索日付リテラル(年)
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_SEARCHSLIPDATEFLYRF
            //伝票検索日付リテラル(月)
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_SEARCHSLIPDATEFLMRF
            //伝票検索日付リテラル(日)
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_SEARCHSLIPDATEFLDRF
            //出荷日付西暦年
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_SHIPMENTDAYFYRF
            //出荷日付西暦年略
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_SHIPMENTDAYFSRF
            //出荷日付和暦年
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_SHIPMENTDAYFWRF
            //出荷日付月
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_SHIPMENTDAYFMRF
            //出荷日付日
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_SHIPMENTDAYFDRF
            //出荷日付元号
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_SHIPMENTDAYFGRF
            //出荷日付略号
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_SHIPMENTDAYFRRF
            //出荷日付リテラル(/)
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_SHIPMENTDAYFLSRF
            //出荷日付リテラル(.)
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_SHIPMENTDAYFLPRF
            //出荷日付リテラル(年)
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_SHIPMENTDAYFLYRF
            //出荷日付リテラル(月)
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_SHIPMENTDAYFLMRF
            //出荷日付リテラル(日)
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_SHIPMENTDAYFLDRF
            //売上日付西暦年
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_SALESDATEFYRF
            //売上日付西暦年略
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_SALESDATEFSRF
            //売上日付和暦年
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_SALESDATEFWRF
            //売上日付月
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_SALESDATEFMRF
            //売上日付日
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_SALESDATEFDRF
            //売上日付元号
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_SALESDATEFGRF
            //売上日付略号
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_SALESDATEFRRF
            //売上日付リテラル(/)
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_SALESDATEFLSRF
            //売上日付リテラル(.)
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_SALESDATEFLPRF
            //売上日付リテラル(年)
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_SALESDATEFLYRF
            //売上日付リテラル(月)
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_SALESDATEFLMRF
            //売上日付リテラル(日)
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_SALESDATEFLDRF
            //計上日付西暦年
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_ADDUPADATEFYRF
            //計上日付西暦年略
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_ADDUPADATEFSRF
            //計上日付和暦年
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_ADDUPADATEFWRF
            //計上日付月
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_ADDUPADATEFMRF
            //計上日付日
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_ADDUPADATEFDRF
            //計上日付元号
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_ADDUPADATEFGRF
            //計上日付略号
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_ADDUPADATEFRRF
            //計上日付リテラル(/)
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_ADDUPADATEFLSRF
            //計上日付リテラル(.)
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_ADDUPADATEFLPRF
            //計上日付リテラル(年)
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_ADDUPADATEFLYRF
            //計上日付リテラル(月)
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_ADDUPADATEFLMRF
            //計上日付リテラル(日)
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_ADDUPADATEFLDRF
            //売上伝票発行日西暦年
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_SALESSLIPPRINTDATEFYRF
            //売上伝票発行日西暦年略
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_SALESSLIPPRINTDATEFSRF
            //売上伝票発行日和暦年
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_SALESSLIPPRINTDATEFWRF
            //売上伝票発行日月
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_SALESSLIPPRINTDATEFMRF
            //売上伝票発行日日
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_SALESSLIPPRINTDATEFDRF
            //売上伝票発行日元号
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_SALESSLIPPRINTDATEFGRF
            //売上伝票発行日略号
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_SALESSLIPPRINTDATEFRRF
            //売上伝票発行日リテラル(/)
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_SALESSLIPPRINTDATEFLSRF
            //売上伝票発行日リテラル(.)
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_SALESSLIPPRINTDATEFLPRF
            //売上伝票発行日リテラル(年)
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_SALESSLIPPRINTDATEFLYRF
            //売上伝票発行日リテラル(月)
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_SALESSLIPPRINTDATEFLMRF
            //売上伝票発行日リテラル(日)
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_SALESSLIPPRINTDATEFLDRF
            //(先頭)初年度西暦年
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_FIRSTENTRYDATEFYRF
            //(先頭)初年度西暦年略
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_FIRSTENTRYDATEFSRF
            //(先頭)初年度和暦年
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_FIRSTENTRYDATEFWRF
            //(先頭)初年度月
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_FIRSTENTRYDATEFMRF
            //(先頭)初年度日
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_FIRSTENTRYDATEFDRF
            //(先頭)初年度元号
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_FIRSTENTRYDATEFGRF
            //(先頭)初年度略号
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_FIRSTENTRYDATEFRRF
            //(先頭)初年度リテラル(/)
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_FIRSTENTRYDATEFLSRF
            //(先頭)初年度リテラル(.)
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_FIRSTENTRYDATEFLPRF
            //(先頭)初年度リテラル(年)
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_FIRSTENTRYDATEFLYRF
            //(先頭)初年度リテラル(月)
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_FIRSTENTRYDATEFLMRF
            //(先頭)初年度リテラル(日)
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_FIRSTENTRYDATEFLDRF
            //印刷用得意先名称（上段）
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_PRINTCUSTOMERNAME1RF
            //印刷用得意先名称（下段）
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_PRINTCUSTOMERNAME2RF
            //印刷用得意先名称（下段）＋敬称
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_PRINTCUSTOMERNAME2HNRF
            //(先頭)メーカー半角名称
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_MAKERHALFNAMERF
            //(先頭)車種半角名称
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_MODELHALFNAMERF
            //伝票備考３
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESSLIPRF_SLIPNOTE3RF
            //得意先名１＋得意先名２
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_PRINTCUSTOMERNAMEJOIN12RF
            //得意先名１＋得意先名２＋敬称
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_PRINTCUSTOMERNAMEJOIN12HNRF
            //自社名１（前半）
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_PRINTENTERPRISENAME1FHRF
            //自社名１（後半）
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_PRINTENTERPRISENAME1LHRF
            //自社名２（前半）
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_PRINTENTERPRISENAME2FHRF
            //自社名２（後半）
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_PRINTENTERPRISENAME2LHRF
            //実績計上拠点コード
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESSLIPRF_RESULTSADDUPSECCDRF
            //更新日時
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //SALESSLIPRF_UPDATEDATETIMERF

            // --- ADD 2009.07.24 劉洋 ------ >>>>>>
            //得意先コード
            serInfo.MemberInfo.Add(typeof(Int32)); //SAndESettingRF_CustomerCode
            //納品先店舗コード
            serInfo.MemberInfo.Add(typeof(string)); //SAndESettingRF_AddresseeShopCd
            //住電管理コード
            serInfo.MemberInfo.Add(typeof(string)); //SAndESettingRF_SAndEMngCode
            //経費区分
            serInfo.MemberInfo.Add(typeof(Int32)); //SAndESettingRF_ExpenseDivCd
            //直送区分
            serInfo.MemberInfo.Add(typeof(Int32)); //SAndESettingRF_DirectSendingCd
            //受注区分
            serInfo.MemberInfo.Add(typeof(Int32)); //SAndESettingRF_AcptAnOrderDiv
            //納品者コード
            serInfo.MemberInfo.Add(typeof(string)); //SAndESettingRF_DelivererCd
            //納品者名
            serInfo.MemberInfo.Add(typeof(string)); //SAndESettingRF_DelivererNm
            //納品者住所
            serInfo.MemberInfo.Add(typeof(string)); //SAndESettingRF_DelivererAddress
            //納品者ＴＥＬ
            serInfo.MemberInfo.Add(typeof(string)); //SAndESettingRF_DelivererPhoneNum
            //部品商名
            serInfo.MemberInfo.Add(typeof(string)); //SAndESettingRF_TradCompName
            //部品商拠点名
            serInfo.MemberInfo.Add(typeof(string)); //SAndESettingRF_TradCompSectName
            //部品商コード（純正）
            serInfo.MemberInfo.Add(typeof(string)); //SAndESettingRF_PureTradCompCd
            //部品商仕切率（純正）
            serInfo.MemberInfo.Add(typeof(Double)); //SAndESettingRF_PureTradCompRate
            //部品商コード（優良）
            serInfo.MemberInfo.Add(typeof(string)); //SAndESettingRF_PriTradCompCd
            //部品商仕切率（優良）
            serInfo.MemberInfo.Add(typeof(Double)); //SAndESettingRF_PriTradCompRate
            //AB商品コード
            serInfo.MemberInfo.Add(typeof(string)); //SAndESettingRF_ABGoodsCode
            //コメント指定区分
            serInfo.MemberInfo.Add(typeof(Int32)); //SAndESettingRF_CommentReservedDiv
            //商品メーカーコード１
            serInfo.MemberInfo.Add(typeof(Int32)); //SAndESettingRF_GoodsMakerCd1
            //商品メーカーコード２
            serInfo.MemberInfo.Add(typeof(Int32)); //SAndESettingRF_GoodsMakerCd2
            //商品メーカーコード３
            serInfo.MemberInfo.Add(typeof(Int32)); //SAndESettingRF_GoodsMakerCd3
            //商品メーカーコード４
            serInfo.MemberInfo.Add(typeof(Int32)); //SAndESettingRF_GoodsMakerCd4
            //商品メーカーコード５
            serInfo.MemberInfo.Add(typeof(Int32)); //SAndESettingRF_GoodsMakerCd5
            //商品メーカーコード６
            serInfo.MemberInfo.Add(typeof(Int32)); //SAndESettingRF_GoodsMakerCd6
            //商品メーカーコード７
            serInfo.MemberInfo.Add(typeof(Int32)); //SAndESettingRF_GoodsMakerCd7
            //商品メーカーコード８
            serInfo.MemberInfo.Add(typeof(Int32)); //SAndESettingRF_GoodsMakerCd8
            //商品メーカーコード９
            serInfo.MemberInfo.Add(typeof(Int32)); //SAndESettingRF_GoodsMakerCd9
            //商品メーカーコード１０
            serInfo.MemberInfo.Add(typeof(Int32)); //SAndESettingRF_GoodsMakerCd10
            //商品メーカーコード１１
            serInfo.MemberInfo.Add(typeof(Int32)); //SAndESettingRF_GoodsMakerCd11
            //商品メーカーコード１２
            serInfo.MemberInfo.Add(typeof(Int32)); //SAndESettingRF_GoodsMakerCd12
            //商品メーカーコード１３
            serInfo.MemberInfo.Add(typeof(Int32)); //SAndESettingRF_GoodsMakerCd13
            //商品メーカーコード１４
            serInfo.MemberInfo.Add(typeof(Int32)); //SAndESettingRF_GoodsMakerCd14
            //商品メーカーコード１５
            serInfo.MemberInfo.Add(typeof(Int32)); //SAndESettingRF_GoodsMakerCd15
            //部品ＯＥＭ区分
            serInfo.MemberInfo.Add(typeof(Int32)); //SAndESettingRF_PartsOEMDiv
            // --- ADD 2009.07.24 劉洋 ------ <<<<<<
            // --- ADD  大矢睦美  2010/03/01 ---------->>>>>
            //売上単価端数処理コード
            serInfo.MemberInfo.Add(typeof(Int32)); //CSTCST_SALESUNPRCFRCPROCCD
            //売上金額端数処理コード
            serInfo.MemberInfo.Add(typeof(Int32)); //CSTCST_SALESMONEYFRCPROCCDRF
            //売上消費税端数処理コード
            serInfo.MemberInfo.Add(typeof(Int32)); //CSTCST_SALESCNSTAXFRCPROCCDRF
            // --- ADD  大矢睦美  2010/03/01 ----------<<<<<
            // --- ADD m.suzuki 2010/03/24 ---------->>>>>
            //QRコード印刷
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //CSTCST_QRCODEPRTCDRF
            // --- ADD m.suzuki 2010/03/24 ----------<<<<<
            // 2010/07/06 Add >>>
            //売上データヘッダガイド
            serInfo.MemberInfo.Add(typeof(byte[])); //SALESSLIPRF_FILEHEADERGUID
            // 2010/07/06 Add <<<
            // ---- ADD caohh 2011/08/17 ------>>>>>
            //郵便番号
            serInfo.MemberInfo.Add(typeof(string)); //CSTCST_POSTNORF
            //住所1（都道府県市区郡・町村・字）
            serInfo.MemberInfo.Add(typeof(string)); //CSTCST_ADDRESS1RF
            //住所3（番地）
            serInfo.MemberInfo.Add(typeof(string)); //CSTCST_ADDRESS3RF
            //住所4（アパート名称）
            serInfo.MemberInfo.Add(typeof(string)); //CSTCST_ADDRESS4RF
            //電話番号（自宅）
            serInfo.MemberInfo.Add(typeof(string)); //CSTCST_HOMETELNORF
            //電話番号（勤務先）
            serInfo.MemberInfo.Add(typeof(string)); //CSTCST_OFFICETELNORF
            //電話番号（携帯）
            serInfo.MemberInfo.Add(typeof(string)); //CSTCST_PORTABLETELNORF
            //FAX番号（自宅）
            serInfo.MemberInfo.Add(typeof(string)); //CSTCST_HOMEFAXNORF
            //FAX番号（勤務先）
            serInfo.MemberInfo.Add(typeof(string)); //CSTCST_OFFICEFAXNORF
            //電話番号（その他）
            serInfo.MemberInfo.Add(typeof(string)); //CSTCST_OTHERSTELNORF
            // ---- ADD caohh 2011/08/17 ------<<<<< 

            serInfo.Serialize( writer, serInfo );
            if ( graph is FrePSalesSlipWork )
            {
                FrePSalesSlipWork temp = (FrePSalesSlipWork)graph;

                SetFrePSalesSlipWork( writer, temp );
            }
            else
            {
                ArrayList lst = null;
                if ( graph is FrePSalesSlipWork[] )
                {
                    lst = new ArrayList();
                    lst.AddRange( (FrePSalesSlipWork[])graph );
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach ( FrePSalesSlipWork temp in lst )
                {
                    SetFrePSalesSlipWork( writer, temp );
                }

            }


        }


        /// <summary>
        /// FrePSalesSlipWorkメンバ数(publicプロパティ数)
        /// </summary>
        // --- UPD m.suzuki 2010/03/24 ---------->>>>>
        //// private const int currentMemberCount = 359; // DEL 2009.07.24 劉洋
        //// --- ADD  大矢睦美  2010/03/01 ---------->>>>>
        ////private const int currentMemberCount = 393;  // ADD 2009.07.24 劉洋
        //private const int currentMemberCount = 396;
        //// --- ADD  大矢睦美  2010/03/01 ----------<<<<<
        // 2010/07/06 >>>
        //private const int currentMemberCount = 397;
        //private const int currentMemberCount = 398;// DEL 2011/08/17 caohh
        private const int currentMemberCount = 408;  // ADD 2011/08/17 caohh
        // 2010/07/06 <<<
        // --- UPD m.suzuki 2010/03/24 ----------<<<<<

        /// <summary>
        ///  FrePSalesSlipWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   FrePSalesSlipWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetFrePSalesSlipWork( System.IO.BinaryWriter writer, FrePSalesSlipWork temp )
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
            //赤黒連結売上伝票番号
            writer.Write( temp.SALESSLIPRF_DEBITNLNKSALESSLNUMRF );
            //売上伝票区分
            writer.Write( temp.SALESSLIPRF_SALESSLIPCDRF );
            //売上商品区分
            writer.Write( temp.SALESSLIPRF_SALESGOODSCDRF );
            //売掛区分
            writer.Write( temp.SALESSLIPRF_ACCRECDIVCDRF );
            //伝票検索日付
            writer.Write( temp.SALESSLIPRF_SEARCHSLIPDATERF );
            //出荷日付
            writer.Write( temp.SALESSLIPRF_SHIPMENTDAYRF );
            //売上日付
            writer.Write( temp.SALESSLIPRF_SALESDATERF );
            //計上日付
            writer.Write( temp.SALESSLIPRF_ADDUPADATERF );
            //来勘区分
            writer.Write( temp.SALESSLIPRF_DELAYPAYMENTDIVRF );
            //見積書番号
            writer.Write( temp.SALESSLIPRF_ESTIMATEFORMNORF );
            //見積区分
            writer.Write( temp.SALESSLIPRF_ESTIMATEDIVIDERF );
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
            //総額表示方法区分
            writer.Write( temp.SALESSLIPRF_TOTALAMOUNTDISPWAYCDRF );
            //総額表示掛率適用区分
            writer.Write( temp.SALESSLIPRF_TTLAMNTDISPRATEAPYRF );
            //売上伝票合計（税込み）
            writer.Write( temp.SALESSLIPRF_SALESTOTALTAXINCRF );
            //売上伝票合計（税抜き）
            writer.Write( temp.SALESSLIPRF_SALESTOTALTAXEXCRF );
            //売上小計（税込み）
            writer.Write( temp.SALESSLIPRF_SALESSUBTOTALTAXINCRF );
            //売上小計（税抜き）
            writer.Write( temp.SALESSLIPRF_SALESSUBTOTALTAXEXCRF );
            //売上小計（税）
            writer.Write( temp.SALESSLIPRF_SALESSUBTOTALTAXRF );
            //売上外税対象額
            writer.Write( temp.SALESSLIPRF_ITDEDSALESOUTTAXRF );
            //売上内税対象額
            writer.Write( temp.SALESSLIPRF_ITDEDSALESINTAXRF );
            //売上小計非課税対象額
            writer.Write( temp.SALESSLIPRF_SALSUBTTLSUBTOTAXFRERF );
            //売上金額消費税額（内税）
            writer.Write( temp.SALESSLIPRF_SALAMNTCONSTAXINCLURF );
            //売上値引金額計（税抜き）
            writer.Write( temp.SALESSLIPRF_SALESDISTTLTAXEXCRF );
            //売上値引外税対象額合計
            writer.Write( temp.SALESSLIPRF_ITDEDSALESDISOUTTAXRF );
            //売上値引内税対象額合計
            writer.Write( temp.SALESSLIPRF_ITDEDSALESDISINTAXRF );
            //売上値引消費税額（外税）
            writer.Write( temp.SALESSLIPRF_SALESDISOUTTAXRF );
            //売上値引消費税額（内税）
            writer.Write( temp.SALESSLIPRF_SALESDISTTLTAXINCLURF );
            //原価金額計
            writer.Write( temp.SALESSLIPRF_TOTALCOSTRF );
            //消費税転嫁方式
            writer.Write( temp.SALESSLIPRF_CONSTAXLAYMETHODRF );
            //消費税税率
            writer.Write( temp.SALESSLIPRF_CONSTAXRATERF );
            //端数処理区分
            writer.Write( temp.SALESSLIPRF_FRACTIONPROCCDRF );
            //売掛消費税
            writer.Write( temp.SALESSLIPRF_ACCRECCONSTAXRF );
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
            //請求先略称
            writer.Write( temp.SALESSLIPRF_CLAIMSNMRF );
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
            //納品先郵便番号
            writer.Write( temp.SALESSLIPRF_ADDRESSEEPOSTNORF );
            //納品先住所1(都道府県市区郡・町村・字)
            writer.Write( temp.SALESSLIPRF_ADDRESSEEADDR1RF );
            //納品先住所3(番地)
            writer.Write( temp.SALESSLIPRF_ADDRESSEEADDR3RF );
            //納品先住所4(アパート名称)
            writer.Write( temp.SALESSLIPRF_ADDRESSEEADDR4RF );
            //納品先電話番号
            writer.Write( temp.SALESSLIPRF_ADDRESSEETELNORF );
            //納品先FAX番号
            writer.Write( temp.SALESSLIPRF_ADDRESSEEFAXNORF );
            //相手先伝票番号
            writer.Write( temp.SALESSLIPRF_PARTYSALESLIPNUMRF );
            //伝票備考
            writer.Write( temp.SALESSLIPRF_SLIPNOTERF );
            //伝票備考２
            writer.Write( temp.SALESSLIPRF_SLIPNOTE2RF );
            //返品理由コード
            writer.Write( temp.SALESSLIPRF_RETGOODSREASONDIVRF );
            //返品理由
            writer.Write( temp.SALESSLIPRF_RETGOODSREASONRF );
            //レジ処理日
            writer.Write( temp.SALESSLIPRF_REGIPROCDATERF );
            //レジ番号
            writer.Write( temp.SALESSLIPRF_CASHREGISTERNORF );
            //POSレシート番号
            writer.Write( temp.SALESSLIPRF_POSRECEIPTNORF );
            //明細行数
            writer.Write( temp.SALESSLIPRF_DETAILROWCOUNTRF );
            //ＥＤＩ送信日
            writer.Write( temp.SALESSLIPRF_EDISENDDATERF );
            //ＥＤＩ取込日
            writer.Write( temp.SALESSLIPRF_EDITAKEINDATERF );
            //ＵＯＥリマーク１
            writer.Write( temp.SALESSLIPRF_UOEREMARK1RF );
            //ＵＯＥリマーク２
            writer.Write( temp.SALESSLIPRF_UOEREMARK2RF );
            //伝票発行済区分
            writer.Write( temp.SALESSLIPRF_SLIPPRINTFINISHCDRF );
            //売上伝票発行日
            writer.Write( temp.SALESSLIPRF_SALESSLIPPRINTDATERF );
            //業種コード
            writer.Write( temp.SALESSLIPRF_BUSINESSTYPECODERF );
            //業種名称
            writer.Write( temp.SALESSLIPRF_BUSINESSTYPENAMERF );
            //発注番号
            writer.Write( temp.SALESSLIPRF_ORDERNUMBERRF );
            //納品区分
            writer.Write( temp.SALESSLIPRF_DELIVEREDGOODSDIVRF );
            //納品区分名称
            writer.Write( temp.SALESSLIPRF_DELIVEREDGOODSDIVNMRF );
            //販売エリアコード
            writer.Write( temp.SALESSLIPRF_SALESAREACODERF );
            //販売エリア名称
            writer.Write( temp.SALESSLIPRF_SALESAREANAMERF );
            //在庫商品合計金額（税抜）
            writer.Write( temp.SALESSLIPRF_STOCKGOODSTTLTAXEXCRF );
            //純正商品合計金額（税抜）
            writer.Write( temp.SALESSLIPRF_PUREGOODSTTLTAXEXCRF );
            //定価印刷区分
            writer.Write( temp.SALESSLIPRF_LISTPRICEPRINTDIVRF );
            //元号表示区分１
            writer.Write( temp.SALESSLIPRF_ERANAMEDISPCD1RF );
            //見積消費税区分
            writer.Write( temp.SALESSLIPRF_ESTIMATAXDIVCDRF );
            //見積書印刷区分
            writer.Write( temp.SALESSLIPRF_ESTIMATEFORMPRTCDRF );
            //見積件名
            writer.Write( temp.SALESSLIPRF_ESTIMATESUBJECTRF );
            //脚注１
            writer.Write( temp.SALESSLIPRF_FOOTNOTES1RF );
            //脚注２
            writer.Write( temp.SALESSLIPRF_FOOTNOTES2RF );
            //見積タイトル１
            writer.Write( temp.SALESSLIPRF_ESTIMATETITLE1RF );
            //見積タイトル２
            writer.Write( temp.SALESSLIPRF_ESTIMATETITLE2RF );
            //見積タイトル３
            writer.Write( temp.SALESSLIPRF_ESTIMATETITLE3RF );
            //見積タイトル４
            writer.Write( temp.SALESSLIPRF_ESTIMATETITLE4RF );
            //見積タイトル５
            writer.Write( temp.SALESSLIPRF_ESTIMATETITLE5RF );
            //見積備考１
            writer.Write( temp.SALESSLIPRF_ESTIMATENOTE1RF );
            //見積備考２
            writer.Write( temp.SALESSLIPRF_ESTIMATENOTE2RF );
            //見積備考３
            writer.Write( temp.SALESSLIPRF_ESTIMATENOTE3RF );
            //見積備考４
            writer.Write( temp.SALESSLIPRF_ESTIMATENOTE4RF );
            //見積備考５
            writer.Write( temp.SALESSLIPRF_ESTIMATENOTE5RF );
            //拠点ガイド名称
            writer.Write( temp.SECINFOSETRF_SECTIONGUIDENMRF );
            //拠点ガイド略称
            writer.Write( temp.SECINFOSETRF_SECTIONGUIDESNMRF );
            //自社名称コード1
            writer.Write( temp.SECINFOSETRF_COMPANYNAMECD1RF );
            //自社PR文
            writer.Write( temp.COMPANYNMRF_COMPANYPRRF );
            //自社名称1
            writer.Write( temp.COMPANYNMRF_COMPANYNAME1RF );
            //自社名称2
            writer.Write( temp.COMPANYNMRF_COMPANYNAME2RF );
            //郵便番号
            writer.Write( temp.COMPANYNMRF_POSTNORF );
            //住所1（都道府県市区郡・町村・字）
            writer.Write( temp.COMPANYNMRF_ADDRESS1RF );
            //住所3（番地）
            writer.Write( temp.COMPANYNMRF_ADDRESS3RF );
            //住所4（アパート名称）
            writer.Write( temp.COMPANYNMRF_ADDRESS4RF );
            //自社電話番号1
            writer.Write( temp.COMPANYNMRF_COMPANYTELNO1RF );
            //自社電話番号2
            writer.Write( temp.COMPANYNMRF_COMPANYTELNO2RF );
            //自社電話番号3
            writer.Write( temp.COMPANYNMRF_COMPANYTELNO3RF );
            //自社電話番号タイトル1
            writer.Write( temp.COMPANYNMRF_COMPANYTELTITLE1RF );
            //自社電話番号タイトル2
            writer.Write( temp.COMPANYNMRF_COMPANYTELTITLE2RF );
            //自社電話番号タイトル3
            writer.Write( temp.COMPANYNMRF_COMPANYTELTITLE3RF );
            //銀行振込案内文
            writer.Write( temp.COMPANYNMRF_TRANSFERGUIDANCERF );
            //銀行口座1
            writer.Write( temp.COMPANYNMRF_ACCOUNTNOINFO1RF );
            //銀行口座2
            writer.Write( temp.COMPANYNMRF_ACCOUNTNOINFO2RF );
            //銀行口座3
            writer.Write( temp.COMPANYNMRF_ACCOUNTNOINFO3RF );
            //自社設定摘要1
            writer.Write( temp.COMPANYNMRF_COMPANYSETNOTE1RF );
            //自社設定摘要2
            writer.Write( temp.COMPANYNMRF_COMPANYSETNOTE2RF );
            //画像情報区分
            writer.Write( temp.COMPANYNMRF_IMAGEINFODIVRF );
            //画像情報コード
            writer.Write( temp.COMPANYNMRF_IMAGEINFOCODERF );
            //自社URL
            writer.Write( temp.COMPANYNMRF_COMPANYURLRF );
            //自社PR文2
            writer.Write( temp.COMPANYNMRF_COMPANYPRSENTENCE2RF );
            //画像印字用コメント1
            writer.Write( temp.COMPANYNMRF_IMAGECOMMENTFORPRT1RF );
            //画像印字用コメント2
            writer.Write( temp.COMPANYNMRF_IMAGECOMMENTFORPRT2RF );
            //自社画像
            writer.Write( temp.IMAGEINFORF_IMAGEINFODATARF );
            //部門名称
            writer.Write( temp.SUBSECTIONRF_SUBSECTIONNAMERF );
            //売上入力者カナ
            writer.Write( temp.EMPINP_KANARF );
            //売上入力者短縮名称
            writer.Write( temp.EMPINP_SHORTNAMERF );
            //受付従業員カナ
            writer.Write( temp.EMPFRT_KANARF );
            //受付従業員短縮名称
            writer.Write( temp.EMPFRT_SHORTNAMERF );
            //販売従業員カナ
            writer.Write( temp.EMPSAL_KANARF );
            //販売従業員短縮名称
            writer.Write( temp.EMPSAL_SHORTNAMERF );
            //請求先サブコード
            writer.Write( temp.CSTCLM_CUSTOMERSUBCODERF );
            //請求先名称
            writer.Write( temp.CSTCLM_NAMERF );
            //請求先名称2
            writer.Write( temp.CSTCLM_NAME2RF );
            //請求先敬称
            writer.Write( temp.CSTCLM_HONORIFICTITLERF );
            //請求先カナ
            writer.Write( temp.CSTCLM_KANARF );
            //請求先略称
            writer.Write( temp.CSTCLM_CUSTOMERSNMRF );
            //請求先諸口コード
            writer.Write( temp.CSTCLM_OUTPUTNAMECODERF );
            //請求先分析コード1
            writer.Write( temp.CSTCLM_CUSTANALYSCODE1RF );
            //請求先分析コード2
            writer.Write( temp.CSTCLM_CUSTANALYSCODE2RF );
            //請求先分析コード3
            writer.Write( temp.CSTCLM_CUSTANALYSCODE3RF );
            //請求先分析コード4
            writer.Write( temp.CSTCLM_CUSTANALYSCODE4RF );
            //請求先分析コード5
            writer.Write( temp.CSTCLM_CUSTANALYSCODE5RF );
            //請求先分析コード6
            writer.Write( temp.CSTCLM_CUSTANALYSCODE6RF );
            //請求先備考1
            writer.Write( temp.CSTCLM_NOTE1RF );
            //請求先備考2
            writer.Write( temp.CSTCLM_NOTE2RF );
            //請求先備考3
            writer.Write( temp.CSTCLM_NOTE3RF );
            //請求先備考4
            writer.Write( temp.CSTCLM_NOTE4RF );
            //請求先備考5
            writer.Write( temp.CSTCLM_NOTE5RF );
            //請求先備考6
            writer.Write( temp.CSTCLM_NOTE6RF );
            //請求先備考7
            writer.Write( temp.CSTCLM_NOTE7RF );
            //請求先備考8
            writer.Write( temp.CSTCLM_NOTE8RF );
            //請求先備考9
            writer.Write( temp.CSTCLM_NOTE9RF );
            //請求先備考10
            writer.Write( temp.CSTCLM_NOTE10RF );
            //得意先サブコード
            writer.Write( temp.CSTCST_CUSTOMERSUBCODERF );
            //得意先名称
            writer.Write( temp.CSTCST_NAMERF );
            //得意先名称2
            writer.Write( temp.CSTCST_NAME2RF );
            //得意先敬称
            writer.Write( temp.CSTCST_HONORIFICTITLERF );
            //得意先カナ
            writer.Write( temp.CSTCST_KANARF );
            //得意先略称
            writer.Write( temp.CSTCST_CUSTOMERSNMRF );
            //得意先諸口コード
            writer.Write( temp.CSTCST_OUTPUTNAMECODERF );
            //得意先分析コード1
            writer.Write( temp.CSTCST_CUSTANALYSCODE1RF );
            //得意先分析コード2
            writer.Write( temp.CSTCST_CUSTANALYSCODE2RF );
            //得意先分析コード3
            writer.Write( temp.CSTCST_CUSTANALYSCODE3RF );
            //得意先分析コード4
            writer.Write( temp.CSTCST_CUSTANALYSCODE4RF );
            //得意先分析コード5
            writer.Write( temp.CSTCST_CUSTANALYSCODE5RF );
            //得意先分析コード6
            writer.Write( temp.CSTCST_CUSTANALYSCODE6RF );
            //得意先備考1
            writer.Write( temp.CSTCST_NOTE1RF );
            //得意先備考2
            writer.Write( temp.CSTCST_NOTE2RF );
            //得意先備考3
            writer.Write( temp.CSTCST_NOTE3RF );
            //得意先備考4
            writer.Write( temp.CSTCST_NOTE4RF );
            //得意先備考5
            writer.Write( temp.CSTCST_NOTE5RF );
            //得意先備考6
            writer.Write( temp.CSTCST_NOTE6RF );
            //得意先備考7
            writer.Write( temp.CSTCST_NOTE7RF );
            //得意先備考8
            writer.Write( temp.CSTCST_NOTE8RF );
            //得意先備考9
            writer.Write( temp.CSTCST_NOTE9RF );
            //得意先備考10
            writer.Write( temp.CSTCST_NOTE10RF );
            //納入先サブコード
            writer.Write( temp.CSTADR_CUSTOMERSUBCODERF );
            //納入先名称
            writer.Write( temp.CSTADR_NAMERF );
            //納入先名称2
            writer.Write( temp.CSTADR_NAME2RF );
            //納入先敬称
            writer.Write( temp.CSTADR_HONORIFICTITLERF );
            //納入先カナ
            writer.Write( temp.CSTADR_KANARF );
            //納入先略称
            writer.Write( temp.CSTADR_CUSTOMERSNMRF );
            //納入先諸口コード
            writer.Write( temp.CSTADR_OUTPUTNAMECODERF );
            //納入先分析コード1
            writer.Write( temp.CSTADR_CUSTANALYSCODE1RF );
            //納入先分析コード2
            writer.Write( temp.CSTADR_CUSTANALYSCODE2RF );
            //納入先分析コード3
            writer.Write( temp.CSTADR_CUSTANALYSCODE3RF );
            //納入先分析コード4
            writer.Write( temp.CSTADR_CUSTANALYSCODE4RF );
            //納入先分析コード5
            writer.Write( temp.CSTADR_CUSTANALYSCODE5RF );
            //納入先分析コード6
            writer.Write( temp.CSTADR_CUSTANALYSCODE6RF );
            //納入先備考1
            writer.Write( temp.CSTADR_NOTE1RF );
            //納入先備考2
            writer.Write( temp.CSTADR_NOTE2RF );
            //納入先備考3
            writer.Write( temp.CSTADR_NOTE3RF );
            //納入先備考4
            writer.Write( temp.CSTADR_NOTE4RF );
            //納入先備考5
            writer.Write( temp.CSTADR_NOTE5RF );
            //納入先備考6
            writer.Write( temp.CSTADR_NOTE6RF );
            //納入先備考7
            writer.Write( temp.CSTADR_NOTE7RF );
            //納入先備考8
            writer.Write( temp.CSTADR_NOTE8RF );
            //納入先備考9
            writer.Write( temp.CSTADR_NOTE9RF );
            //納入先備考10
            writer.Write( temp.CSTADR_NOTE10RF );
            //自社名称1
            writer.Write( temp.COMPANYINFRF_COMPANYNAME1RF );
            //自社名称2
            writer.Write( temp.COMPANYINFRF_COMPANYNAME2RF );
            //郵便番号
            writer.Write( temp.COMPANYINFRF_POSTNORF );
            //住所1（都道府県市区郡・町村・字）
            writer.Write( temp.COMPANYINFRF_ADDRESS1RF );
            //住所3（番地）
            writer.Write( temp.COMPANYINFRF_ADDRESS3RF );
            //住所4（アパート名称）
            writer.Write( temp.COMPANYINFRF_ADDRESS4RF );
            //自社電話番号1
            writer.Write( temp.COMPANYINFRF_COMPANYTELNO1RF );
            //自社電話番号2
            writer.Write( temp.COMPANYINFRF_COMPANYTELNO2RF );
            //自社電話番号3
            writer.Write( temp.COMPANYINFRF_COMPANYTELNO3RF );
            //自社電話番号タイトル1
            writer.Write( temp.COMPANYINFRF_COMPANYTELTITLE1RF );
            //自社電話番号タイトル2
            writer.Write( temp.COMPANYINFRF_COMPANYTELTITLE2RF );
            //自社電話番号タイトル3
            writer.Write( temp.COMPANYINFRF_COMPANYTELTITLE3RF );
            //受注ステータス名称
            writer.Write( temp.HADD_ACPTANODRSTNMRF );
            //赤伝区分名称
            writer.Write( temp.HADD_DEBITNOTEDIVNMRF );
            //売上伝票区分名称
            writer.Write( temp.HADD_SALESSLIPNMRF );
            //売上商品区分名称
            writer.Write( temp.HADD_SALESGOODSNMRF );
            //売掛区分名称
            writer.Write( temp.HADD_ACCRECDIVNMRF );
            //来勘区分名称
            writer.Write( temp.HADD_DELAYPAYMENTDIVNMRF );
            //見積区分名称
            writer.Write( temp.HADD_ESTIMATEDIVIDENMRF );
            //消費税転嫁方式名称
            writer.Write( temp.HADD_CONSTAXLAYMETHODNMRF );
            //自動入金区分名称
            writer.Write( temp.HADD_AUTODEPOSITNMRF );
            //伝票発行済区分名称
            writer.Write( temp.HADD_SLIPPRINTFINISHNMRF );
            //一式伝票区分名称
            writer.Write( temp.HADD_COMPLETENMRF );
            //(先頭)車両管理番号
            writer.Write( temp.HADD_CARMNGNORF );
            //(先頭)車輌管理コード
            writer.Write( temp.HADD_CARMNGCODERF );
            //(先頭)陸運事務所番号
            writer.Write( temp.HADD_NUMBERPLATE1CODERF );
            //(先頭)陸運事務局名称
            writer.Write( temp.HADD_NUMBERPLATE1NAMERF );
            //(先頭)車両登録番号（種別）
            writer.Write( temp.HADD_NUMBERPLATE2RF );
            //(先頭)車両登録番号（カナ）
            writer.Write( temp.HADD_NUMBERPLATE3RF );
            //(先頭)車両登録番号（プレート番号）
            writer.Write( temp.HADD_NUMBERPLATE4RF );
            //(先頭)初年度
            writer.Write( temp.HADD_FIRSTENTRYDATERF );
            //(先頭)メーカーコード
            writer.Write( temp.HADD_MAKERCODERF );
            //(先頭)メーカー全角名称
            writer.Write( temp.HADD_MAKERFULLNAMERF );
            //(先頭)車種コード
            writer.Write( temp.HADD_MODELCODERF );
            //(先頭)車種サブコード
            writer.Write( temp.HADD_MODELSUBCODERF );
            //(先頭)車種全角名称
            writer.Write( temp.HADD_MODELFULLNAMERF );
            //(先頭)排ガス記号
            writer.Write( temp.HADD_EXHAUSTGASSIGNRF );
            //(先頭)シリーズ型式
            writer.Write( temp.HADD_SERIESMODELRF );
            //(先頭)型式（類別記号）
            writer.Write( temp.HADD_CATEGORYSIGNMODELRF );
            //(先頭)型式（フル型）
            writer.Write( temp.HADD_FULLMODELRF );
            //(先頭)型式指定番号
            writer.Write( temp.HADD_MODELDESIGNATIONNORF );
            //(先頭)類別番号
            writer.Write( temp.HADD_CATEGORYNORF );
            //(先頭)車台型式
            writer.Write( temp.HADD_FRAMEMODELRF );
            //(先頭)車台番号
            writer.Write( temp.HADD_FRAMENORF );
            //(先頭)車台番号（検索用）
            writer.Write( temp.HADD_SEARCHFRAMENORF );
            //(先頭)エンジン型式名称
            writer.Write( temp.HADD_ENGINEMODELNMRF );
            //(先頭)関連型式
            writer.Write( temp.HADD_RELEVANCEMODELRF );
            //(先頭)サブ車名コード
            writer.Write( temp.HADD_SUBCARNMCDRF );
            //(先頭)型式グレード略称
            writer.Write( temp.HADD_MODELGRADESNAMERF );
            //(先頭)カラーコード
            writer.Write( temp.HADD_COLORCODERF );
            //(先頭)カラー名称1
            writer.Write( temp.HADD_COLORNAME1RF );
            //(先頭)トリムコード
            writer.Write( temp.HADD_TRIMCODERF );
            //(先頭)トリム名称
            writer.Write( temp.HADD_TRIMNAMERF );
            //(先頭)車両走行距離
            writer.Write( temp.HADD_MILEAGERF );
            //プリンタ管理No
            writer.Write( temp.HADD_PRINTERMNGNORF );
            //伝票印刷設定用帳票ID
            writer.Write( temp.HADD_SLIPPRTSETPAPERIDRF );
            //自社備考１
            writer.Write( temp.HADD_NOTE1RF );
            //自社備考２
            writer.Write( temp.HADD_NOTE2RF );
            //自社備考３
            writer.Write( temp.HADD_NOTE3RF );
            //再発行マーク
            writer.Write( temp.HADD_REISSUEMARKRF );
            //参考消費税印字名称
            writer.Write( temp.HADD_REFCONSTAXPRTNMRF );
            //印刷時刻 時
            writer.Write( temp.HADD_PRINTTIMEHOURRF );
            //印刷時刻 分
            writer.Write( temp.HADD_PRINTTIMEMINUTERF );
            //印刷時刻 秒
            writer.Write( temp.HADD_PRINTTIMESECONDRF );
            //伝票検索日付西暦年
            writer.Write( temp.HADD_SEARCHSLIPDATEFYRF );
            //伝票検索日付西暦年略
            writer.Write( temp.HADD_SEARCHSLIPDATEFSRF );
            //伝票検索日付和暦年
            writer.Write( temp.HADD_SEARCHSLIPDATEFWRF );
            //伝票検索日付月
            writer.Write( temp.HADD_SEARCHSLIPDATEFMRF );
            //伝票検索日付日
            writer.Write( temp.HADD_SEARCHSLIPDATEFDRF );
            //伝票検索日付元号
            writer.Write( temp.HADD_SEARCHSLIPDATEFGRF );
            //伝票検索日付略号
            writer.Write( temp.HADD_SEARCHSLIPDATEFRRF );
            //伝票検索日付リテラル(/)
            writer.Write( temp.HADD_SEARCHSLIPDATEFLSRF );
            //伝票検索日付リテラル(.)
            writer.Write( temp.HADD_SEARCHSLIPDATEFLPRF );
            //伝票検索日付リテラル(年)
            writer.Write( temp.HADD_SEARCHSLIPDATEFLYRF );
            //伝票検索日付リテラル(月)
            writer.Write( temp.HADD_SEARCHSLIPDATEFLMRF );
            //伝票検索日付リテラル(日)
            writer.Write( temp.HADD_SEARCHSLIPDATEFLDRF );
            //出荷日付西暦年
            writer.Write( temp.HADD_SHIPMENTDAYFYRF );
            //出荷日付西暦年略
            writer.Write( temp.HADD_SHIPMENTDAYFSRF );
            //出荷日付和暦年
            writer.Write( temp.HADD_SHIPMENTDAYFWRF );
            //出荷日付月
            writer.Write( temp.HADD_SHIPMENTDAYFMRF );
            //出荷日付日
            writer.Write( temp.HADD_SHIPMENTDAYFDRF );
            //出荷日付元号
            writer.Write( temp.HADD_SHIPMENTDAYFGRF );
            //出荷日付略号
            writer.Write( temp.HADD_SHIPMENTDAYFRRF );
            //出荷日付リテラル(/)
            writer.Write( temp.HADD_SHIPMENTDAYFLSRF );
            //出荷日付リテラル(.)
            writer.Write( temp.HADD_SHIPMENTDAYFLPRF );
            //出荷日付リテラル(年)
            writer.Write( temp.HADD_SHIPMENTDAYFLYRF );
            //出荷日付リテラル(月)
            writer.Write( temp.HADD_SHIPMENTDAYFLMRF );
            //出荷日付リテラル(日)
            writer.Write( temp.HADD_SHIPMENTDAYFLDRF );
            //売上日付西暦年
            writer.Write( temp.HADD_SALESDATEFYRF );
            //売上日付西暦年略
            writer.Write( temp.HADD_SALESDATEFSRF );
            //売上日付和暦年
            writer.Write( temp.HADD_SALESDATEFWRF );
            //売上日付月
            writer.Write( temp.HADD_SALESDATEFMRF );
            //売上日付日
            writer.Write( temp.HADD_SALESDATEFDRF );
            //売上日付元号
            writer.Write( temp.HADD_SALESDATEFGRF );
            //売上日付略号
            writer.Write( temp.HADD_SALESDATEFRRF );
            //売上日付リテラル(/)
            writer.Write( temp.HADD_SALESDATEFLSRF );
            //売上日付リテラル(.)
            writer.Write( temp.HADD_SALESDATEFLPRF );
            //売上日付リテラル(年)
            writer.Write( temp.HADD_SALESDATEFLYRF );
            //売上日付リテラル(月)
            writer.Write( temp.HADD_SALESDATEFLMRF );
            //売上日付リテラル(日)
            writer.Write( temp.HADD_SALESDATEFLDRF );
            //計上日付西暦年
            writer.Write( temp.HADD_ADDUPADATEFYRF );
            //計上日付西暦年略
            writer.Write( temp.HADD_ADDUPADATEFSRF );
            //計上日付和暦年
            writer.Write( temp.HADD_ADDUPADATEFWRF );
            //計上日付月
            writer.Write( temp.HADD_ADDUPADATEFMRF );
            //計上日付日
            writer.Write( temp.HADD_ADDUPADATEFDRF );
            //計上日付元号
            writer.Write( temp.HADD_ADDUPADATEFGRF );
            //計上日付略号
            writer.Write( temp.HADD_ADDUPADATEFRRF );
            //計上日付リテラル(/)
            writer.Write( temp.HADD_ADDUPADATEFLSRF );
            //計上日付リテラル(.)
            writer.Write( temp.HADD_ADDUPADATEFLPRF );
            //計上日付リテラル(年)
            writer.Write( temp.HADD_ADDUPADATEFLYRF );
            //計上日付リテラル(月)
            writer.Write( temp.HADD_ADDUPADATEFLMRF );
            //計上日付リテラル(日)
            writer.Write( temp.HADD_ADDUPADATEFLDRF );
            //売上伝票発行日西暦年
            writer.Write( temp.HADD_SALESSLIPPRINTDATEFYRF );
            //売上伝票発行日西暦年略
            writer.Write( temp.HADD_SALESSLIPPRINTDATEFSRF );
            //売上伝票発行日和暦年
            writer.Write( temp.HADD_SALESSLIPPRINTDATEFWRF );
            //売上伝票発行日月
            writer.Write( temp.HADD_SALESSLIPPRINTDATEFMRF );
            //売上伝票発行日日
            writer.Write( temp.HADD_SALESSLIPPRINTDATEFDRF );
            //売上伝票発行日元号
            writer.Write( temp.HADD_SALESSLIPPRINTDATEFGRF );
            //売上伝票発行日略号
            writer.Write( temp.HADD_SALESSLIPPRINTDATEFRRF );
            //売上伝票発行日リテラル(/)
            writer.Write( temp.HADD_SALESSLIPPRINTDATEFLSRF );
            //売上伝票発行日リテラル(.)
            writer.Write( temp.HADD_SALESSLIPPRINTDATEFLPRF );
            //売上伝票発行日リテラル(年)
            writer.Write( temp.HADD_SALESSLIPPRINTDATEFLYRF );
            //売上伝票発行日リテラル(月)
            writer.Write( temp.HADD_SALESSLIPPRINTDATEFLMRF );
            //売上伝票発行日リテラル(日)
            writer.Write( temp.HADD_SALESSLIPPRINTDATEFLDRF );
            //(先頭)初年度西暦年
            writer.Write( temp.HADD_FIRSTENTRYDATEFYRF );
            //(先頭)初年度西暦年略
            writer.Write( temp.HADD_FIRSTENTRYDATEFSRF );
            //(先頭)初年度和暦年
            writer.Write( temp.HADD_FIRSTENTRYDATEFWRF );
            //(先頭)初年度月
            writer.Write( temp.HADD_FIRSTENTRYDATEFMRF );
            //(先頭)初年度日
            writer.Write( temp.HADD_FIRSTENTRYDATEFDRF );
            //(先頭)初年度元号
            writer.Write( temp.HADD_FIRSTENTRYDATEFGRF );
            //(先頭)初年度略号
            writer.Write( temp.HADD_FIRSTENTRYDATEFRRF );
            //(先頭)初年度リテラル(/)
            writer.Write( temp.HADD_FIRSTENTRYDATEFLSRF );
            //(先頭)初年度リテラル(.)
            writer.Write( temp.HADD_FIRSTENTRYDATEFLPRF );
            //(先頭)初年度リテラル(年)
            writer.Write( temp.HADD_FIRSTENTRYDATEFLYRF );
            //(先頭)初年度リテラル(月)
            writer.Write( temp.HADD_FIRSTENTRYDATEFLMRF );
            //(先頭)初年度リテラル(日)
            writer.Write( temp.HADD_FIRSTENTRYDATEFLDRF );
            //印刷用得意先名称（上段）
            writer.Write( temp.HADD_PRINTCUSTOMERNAME1RF );
            //印刷用得意先名称（下段）
            writer.Write( temp.HADD_PRINTCUSTOMERNAME2RF );
            //印刷用得意先名称（下段）＋敬称
            writer.Write( temp.HADD_PRINTCUSTOMERNAME2HNRF );
            //(先頭)メーカー半角名称
            writer.Write( temp.HADD_MAKERHALFNAMERF );
            //(先頭)車種半角名称
            writer.Write( temp.HADD_MODELHALFNAMERF );
            //伝票備考３
            writer.Write( temp.SALESSLIPRF_SLIPNOTE3RF );
            //得意先名１＋得意先名２
            writer.Write( temp.HADD_PRINTCUSTOMERNAMEJOIN12RF );
            //得意先名１＋得意先名２＋敬称
            writer.Write( temp.HADD_PRINTCUSTOMERNAMEJOIN12HNRF );
            //自社名１（前半）
            writer.Write( temp.HADD_PRINTENTERPRISENAME1FHRF );
            //自社名１（後半）
            writer.Write( temp.HADD_PRINTENTERPRISENAME1LHRF );
            //自社名２（前半）
            writer.Write( temp.HADD_PRINTENTERPRISENAME2FHRF );
            //自社名２（後半）
            writer.Write( temp.HADD_PRINTENTERPRISENAME2LHRF );
            //実績計上拠点コード
            writer.Write( temp.SALESSLIPRF_RESULTSADDUPSECCDRF );
            //更新日時
            writer.Write( temp.SALESSLIPRF_UPDATEDATETIMERF );

            // --- ADD 2009.07.24 劉洋 ------ >>>>>>
            //得意先コード
            writer.Write(temp.SANDESETTINGRF_CUSTOMERCODE);
            //納品先店舗コード
            writer.Write(temp.SANDESETTINGRF_ADDRESSEESHOPCD);
            //住電管理コード
            writer.Write(temp.SANDESETTINGRF_SANDEMNGCODE);
            //経費区分
            writer.Write(temp.SANDESETTINGRF_EXPENSEDIVCD);
            //直送区分
            writer.Write(temp.SANDESETTINGRF_DIRECTSENDINGCD);
            //受注区分
            writer.Write(temp.SANDESETTINGRF_ACPTANORDERDIV);
            //納品者コード
            writer.Write(temp.SANDESETTINGRF_DELIVERERCD);
            //納品者名
            writer.Write(temp.SANDESETTINGRF_DELIVERERNM);
            //納品者住所
            writer.Write(temp.SANDESETTINGRF_DELIVERERADDRESS);
            //納品者ＴＥＬ
            writer.Write(temp.SANDESETTINGRF_DELIVERERPHONENUM);
            //部品商名
            writer.Write(temp.SANDESETTINGRF_TRADCOMPNAME);
            //部品商拠点名
            writer.Write(temp.SANDESETTINGRF_TRADCOMPSECTNAME);
            //部品商コード（純正）
            writer.Write(temp.SANDESETTINGRF_PURETRADCOMPCD);
            //部品商仕切率（純正）
            writer.Write(temp.SANDESETTINGRF_PURETRADCOMPRATE);
            //部品商コード（優良）
            writer.Write(temp.SANDESETTINGRF_PRITRADCOMPCD);
            //部品商仕切率（優良）
            writer.Write(temp.SANDESETTINGRF_PRITRADCOMPRATE);
            //AB商品コード
            writer.Write(temp.SANDESETTINGRF_ABGOODSCODE);
            //コメント指定区分
            writer.Write(temp.SANDESETTINGRF_COMMENTRESERVEDDIV);
            //商品メーカーコード１
            writer.Write(temp.SANDESETTINGRF_GOODSMAKERCD1);
            //商品メーカーコード２
            writer.Write(temp.SANDESETTINGRF_GOODSMAKERCD2);
            //商品メーカーコード３
            writer.Write(temp.SANDESETTINGRF_GOODSMAKERCD3);
            //商品メーカーコード４
            writer.Write(temp.SANDESETTINGRF_GOODSMAKERCD4);
            //商品メーカーコード５
            writer.Write(temp.SANDESETTINGRF_GOODSMAKERCD5);
            //商品メーカーコード６
            writer.Write(temp.SANDESETTINGRF_GOODSMAKERCD6);
            //商品メーカーコード７
            writer.Write(temp.SANDESETTINGRF_GOODSMAKERCD7);
            //商品メーカーコード８
            writer.Write(temp.SANDESETTINGRF_GOODSMAKERCD8);
            //商品メーカーコード９
            writer.Write(temp.SANDESETTINGRF_GOODSMAKERCD9);
            //商品メーカーコード１０
            writer.Write(temp.SANDESETTINGRF_GOODSMAKERCD10);
            //商品メーカーコード１１
            writer.Write(temp.SANDESETTINGRF_GOODSMAKERCD11);
            //商品メーカーコード１２
            writer.Write(temp.SANDESETTINGRF_GOODSMAKERCD12);
            //商品メーカーコード１３
            writer.Write(temp.SANDESETTINGRF_GOODSMAKERCD13);
            //商品メーカーコード１４
            writer.Write(temp.SANDESETTINGRF_GOODSMAKERCD14);
            //商品メーカーコード１５
            writer.Write(temp.SANDESETTINGRF_GOODSMAKERCD15);
            //部品ＯＥＭ区分
            writer.Write(temp.SANDESETTINGRF_PARTSOEMDIV);
            // --- ADD 2009.07.24 劉洋 ------ <<<<<<
            // --- ADD  大矢睦美  2010/03/01 ---------->>>>>
            //売上単価端数処理コード
            writer.Write(temp.CSTCST_SALESUNPRCFRCPROCCDRF);
            //売上金額端数処理コード
            writer.Write(temp.CSTCST_SALESMONEYFRCPROCCDRF);
            //売上消費税端数処理コード
            writer.Write(temp.CSTCST_SALESCNSTAXFRCPROCCDRF);
            // --- ADD  大矢睦美  2010/03/01 ----------<<<<<
            // --- ADD m.suzuki 2010/03/24 ---------->>>>>
            //QRコード印刷
            writer.Write( temp.CSTCST_QRCODEPRTCDRF );
            // --- ADD m.suzuki 2010/03/24 ----------<<<<<
            // 2010/07/06 Add >>>
            //売上ヘッダガイド
            byte[] fileHeaderGuidArray = temp.SALESSLIPRF_FILEHEADERGUID.ToByteArray();
            writer.Write(fileHeaderGuidArray.Length);
            writer.Write(temp.SALESSLIPRF_FILEHEADERGUID.ToByteArray());
            // 2010/07/06 Add <<<
            // ---- ADD caohh 2011/08/17 ------>>>>>
            //郵便番号
            writer.Write(temp.CSTCST_POSTNORF);
            //住所1（都道府県市区郡・町村・字）
            writer.Write(temp.CSTCST_ADDRESS1RF);
            //住所3（番地）
            writer.Write(temp.CSTCST_ADDRESS3RF);
            //住所4（アパート名称）
            writer.Write(temp.CSTCST_ADDRESS4RF);
            //電話番号（自宅）
            writer.Write(temp.CSTCST_HOMETELNORF);
            //電話番号（勤務先）
            writer.Write(temp.CSTCST_OFFICETELNORF);
            //電話番号（携帯）
            writer.Write(temp.CSTCST_PORTABLETELNORF);
            //FAX番号（自宅）
            writer.Write(temp.CSTCST_HOMEFAXNORF);
            //FAX番号（勤務先）
            writer.Write(temp.CSTCST_OFFICEFAXNORF);
            //電話番号（その他）
            writer.Write(temp.CSTCST_OTHERSTELNORF);
            // ---- ADD caohh 2011/08/17 ------<<<<<

        }

        /// <summary>
        ///  FrePSalesSlipWorkインスタンス取得
        /// </summary>
        /// <returns>FrePSalesSlipWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   FrePSalesSlipWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private FrePSalesSlipWork GetFrePSalesSlipWork( System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo )
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            FrePSalesSlipWork temp = new FrePSalesSlipWork();

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
            //赤黒連結売上伝票番号
            temp.SALESSLIPRF_DEBITNLNKSALESSLNUMRF = reader.ReadString();
            //売上伝票区分
            temp.SALESSLIPRF_SALESSLIPCDRF = reader.ReadInt32();
            //売上商品区分
            temp.SALESSLIPRF_SALESGOODSCDRF = reader.ReadInt32();
            //売掛区分
            temp.SALESSLIPRF_ACCRECDIVCDRF = reader.ReadInt32();
            //伝票検索日付
            temp.SALESSLIPRF_SEARCHSLIPDATERF = reader.ReadInt32();
            //出荷日付
            temp.SALESSLIPRF_SHIPMENTDAYRF = reader.ReadInt32();
            //売上日付
            temp.SALESSLIPRF_SALESDATERF = reader.ReadInt32();
            //計上日付
            temp.SALESSLIPRF_ADDUPADATERF = reader.ReadInt32();
            //来勘区分
            temp.SALESSLIPRF_DELAYPAYMENTDIVRF = reader.ReadInt32();
            //見積書番号
            temp.SALESSLIPRF_ESTIMATEFORMNORF = reader.ReadString();
            //見積区分
            temp.SALESSLIPRF_ESTIMATEDIVIDERF = reader.ReadInt32();
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
            //総額表示方法区分
            temp.SALESSLIPRF_TOTALAMOUNTDISPWAYCDRF = reader.ReadInt32();
            //総額表示掛率適用区分
            temp.SALESSLIPRF_TTLAMNTDISPRATEAPYRF = reader.ReadInt32();
            //売上伝票合計（税込み）
            temp.SALESSLIPRF_SALESTOTALTAXINCRF = reader.ReadInt64();
            //売上伝票合計（税抜き）
            temp.SALESSLIPRF_SALESTOTALTAXEXCRF = reader.ReadInt64();
            //売上小計（税込み）
            temp.SALESSLIPRF_SALESSUBTOTALTAXINCRF = reader.ReadInt64();
            //売上小計（税抜き）
            temp.SALESSLIPRF_SALESSUBTOTALTAXEXCRF = reader.ReadInt64();
            //売上小計（税）
            temp.SALESSLIPRF_SALESSUBTOTALTAXRF = reader.ReadInt64();
            //売上外税対象額
            temp.SALESSLIPRF_ITDEDSALESOUTTAXRF = reader.ReadInt64();
            //売上内税対象額
            temp.SALESSLIPRF_ITDEDSALESINTAXRF = reader.ReadInt64();
            //売上小計非課税対象額
            temp.SALESSLIPRF_SALSUBTTLSUBTOTAXFRERF = reader.ReadInt64();
            //売上金額消費税額（内税）
            temp.SALESSLIPRF_SALAMNTCONSTAXINCLURF = reader.ReadInt64();
            //売上値引金額計（税抜き）
            temp.SALESSLIPRF_SALESDISTTLTAXEXCRF = reader.ReadInt64();
            //売上値引外税対象額合計
            temp.SALESSLIPRF_ITDEDSALESDISOUTTAXRF = reader.ReadInt64();
            //売上値引内税対象額合計
            temp.SALESSLIPRF_ITDEDSALESDISINTAXRF = reader.ReadInt64();
            //売上値引消費税額（外税）
            temp.SALESSLIPRF_SALESDISOUTTAXRF = reader.ReadInt64();
            //売上値引消費税額（内税）
            temp.SALESSLIPRF_SALESDISTTLTAXINCLURF = reader.ReadInt64();
            //原価金額計
            temp.SALESSLIPRF_TOTALCOSTRF = reader.ReadInt64();
            //消費税転嫁方式
            temp.SALESSLIPRF_CONSTAXLAYMETHODRF = reader.ReadInt32();
            //消費税税率
            temp.SALESSLIPRF_CONSTAXRATERF = reader.ReadDouble();
            //端数処理区分
            temp.SALESSLIPRF_FRACTIONPROCCDRF = reader.ReadInt32();
            //売掛消費税
            temp.SALESSLIPRF_ACCRECCONSTAXRF = reader.ReadInt64();
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
            //請求先略称
            temp.SALESSLIPRF_CLAIMSNMRF = reader.ReadString();
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
            //納品先郵便番号
            temp.SALESSLIPRF_ADDRESSEEPOSTNORF = reader.ReadString();
            //納品先住所1(都道府県市区郡・町村・字)
            temp.SALESSLIPRF_ADDRESSEEADDR1RF = reader.ReadString();
            //納品先住所3(番地)
            temp.SALESSLIPRF_ADDRESSEEADDR3RF = reader.ReadString();
            //納品先住所4(アパート名称)
            temp.SALESSLIPRF_ADDRESSEEADDR4RF = reader.ReadString();
            //納品先電話番号
            temp.SALESSLIPRF_ADDRESSEETELNORF = reader.ReadString();
            //納品先FAX番号
            temp.SALESSLIPRF_ADDRESSEEFAXNORF = reader.ReadString();
            //相手先伝票番号
            temp.SALESSLIPRF_PARTYSALESLIPNUMRF = reader.ReadString();
            //伝票備考
            temp.SALESSLIPRF_SLIPNOTERF = reader.ReadString();
            //伝票備考２
            temp.SALESSLIPRF_SLIPNOTE2RF = reader.ReadString();
            //返品理由コード
            temp.SALESSLIPRF_RETGOODSREASONDIVRF = reader.ReadInt32();
            //返品理由
            temp.SALESSLIPRF_RETGOODSREASONRF = reader.ReadString();
            //レジ処理日
            temp.SALESSLIPRF_REGIPROCDATERF = reader.ReadInt32();
            //レジ番号
            temp.SALESSLIPRF_CASHREGISTERNORF = reader.ReadInt32();
            //POSレシート番号
            temp.SALESSLIPRF_POSRECEIPTNORF = reader.ReadInt32();
            //明細行数
            temp.SALESSLIPRF_DETAILROWCOUNTRF = reader.ReadInt32();
            //ＥＤＩ送信日
            temp.SALESSLIPRF_EDISENDDATERF = reader.ReadInt32();
            //ＥＤＩ取込日
            temp.SALESSLIPRF_EDITAKEINDATERF = reader.ReadInt32();
            //ＵＯＥリマーク１
            temp.SALESSLIPRF_UOEREMARK1RF = reader.ReadString();
            //ＵＯＥリマーク２
            temp.SALESSLIPRF_UOEREMARK2RF = reader.ReadString();
            //伝票発行済区分
            temp.SALESSLIPRF_SLIPPRINTFINISHCDRF = reader.ReadInt32();
            //売上伝票発行日
            temp.SALESSLIPRF_SALESSLIPPRINTDATERF = reader.ReadInt32();
            //業種コード
            temp.SALESSLIPRF_BUSINESSTYPECODERF = reader.ReadInt32();
            //業種名称
            temp.SALESSLIPRF_BUSINESSTYPENAMERF = reader.ReadString();
            //発注番号
            temp.SALESSLIPRF_ORDERNUMBERRF = reader.ReadString();
            //納品区分
            temp.SALESSLIPRF_DELIVEREDGOODSDIVRF = reader.ReadInt32();
            //納品区分名称
            temp.SALESSLIPRF_DELIVEREDGOODSDIVNMRF = reader.ReadString();
            //販売エリアコード
            temp.SALESSLIPRF_SALESAREACODERF = reader.ReadInt32();
            //販売エリア名称
            temp.SALESSLIPRF_SALESAREANAMERF = reader.ReadString();
            //在庫商品合計金額（税抜）
            temp.SALESSLIPRF_STOCKGOODSTTLTAXEXCRF = reader.ReadInt64();
            //純正商品合計金額（税抜）
            temp.SALESSLIPRF_PUREGOODSTTLTAXEXCRF = reader.ReadInt64();
            //定価印刷区分
            temp.SALESSLIPRF_LISTPRICEPRINTDIVRF = reader.ReadInt32();
            //元号表示区分１
            temp.SALESSLIPRF_ERANAMEDISPCD1RF = reader.ReadInt32();
            //見積消費税区分
            temp.SALESSLIPRF_ESTIMATAXDIVCDRF = reader.ReadInt32();
            //見積書印刷区分
            temp.SALESSLIPRF_ESTIMATEFORMPRTCDRF = reader.ReadInt32();
            //見積件名
            temp.SALESSLIPRF_ESTIMATESUBJECTRF = reader.ReadString();
            //脚注１
            temp.SALESSLIPRF_FOOTNOTES1RF = reader.ReadString();
            //脚注２
            temp.SALESSLIPRF_FOOTNOTES2RF = reader.ReadString();
            //見積タイトル１
            temp.SALESSLIPRF_ESTIMATETITLE1RF = reader.ReadString();
            //見積タイトル２
            temp.SALESSLIPRF_ESTIMATETITLE2RF = reader.ReadString();
            //見積タイトル３
            temp.SALESSLIPRF_ESTIMATETITLE3RF = reader.ReadString();
            //見積タイトル４
            temp.SALESSLIPRF_ESTIMATETITLE4RF = reader.ReadString();
            //見積タイトル５
            temp.SALESSLIPRF_ESTIMATETITLE5RF = reader.ReadString();
            //見積備考１
            temp.SALESSLIPRF_ESTIMATENOTE1RF = reader.ReadString();
            //見積備考２
            temp.SALESSLIPRF_ESTIMATENOTE2RF = reader.ReadString();
            //見積備考３
            temp.SALESSLIPRF_ESTIMATENOTE3RF = reader.ReadString();
            //見積備考４
            temp.SALESSLIPRF_ESTIMATENOTE4RF = reader.ReadString();
            //見積備考５
            temp.SALESSLIPRF_ESTIMATENOTE5RF = reader.ReadString();
            //拠点ガイド名称
            temp.SECINFOSETRF_SECTIONGUIDENMRF = reader.ReadString();
            //拠点ガイド略称
            temp.SECINFOSETRF_SECTIONGUIDESNMRF = reader.ReadString();
            //自社名称コード1
            temp.SECINFOSETRF_COMPANYNAMECD1RF = reader.ReadInt32();
            //自社PR文
            temp.COMPANYNMRF_COMPANYPRRF = reader.ReadString();
            //自社名称1
            temp.COMPANYNMRF_COMPANYNAME1RF = reader.ReadString();
            //自社名称2
            temp.COMPANYNMRF_COMPANYNAME2RF = reader.ReadString();
            //郵便番号
            temp.COMPANYNMRF_POSTNORF = reader.ReadString();
            //住所1（都道府県市区郡・町村・字）
            temp.COMPANYNMRF_ADDRESS1RF = reader.ReadString();
            //住所3（番地）
            temp.COMPANYNMRF_ADDRESS3RF = reader.ReadString();
            //住所4（アパート名称）
            temp.COMPANYNMRF_ADDRESS4RF = reader.ReadString();
            //自社電話番号1
            temp.COMPANYNMRF_COMPANYTELNO1RF = reader.ReadString();
            //自社電話番号2
            temp.COMPANYNMRF_COMPANYTELNO2RF = reader.ReadString();
            //自社電話番号3
            temp.COMPANYNMRF_COMPANYTELNO3RF = reader.ReadString();
            //自社電話番号タイトル1
            temp.COMPANYNMRF_COMPANYTELTITLE1RF = reader.ReadString();
            //自社電話番号タイトル2
            temp.COMPANYNMRF_COMPANYTELTITLE2RF = reader.ReadString();
            //自社電話番号タイトル3
            temp.COMPANYNMRF_COMPANYTELTITLE3RF = reader.ReadString();
            //銀行振込案内文
            temp.COMPANYNMRF_TRANSFERGUIDANCERF = reader.ReadString();
            //銀行口座1
            temp.COMPANYNMRF_ACCOUNTNOINFO1RF = reader.ReadString();
            //銀行口座2
            temp.COMPANYNMRF_ACCOUNTNOINFO2RF = reader.ReadString();
            //銀行口座3
            temp.COMPANYNMRF_ACCOUNTNOINFO3RF = reader.ReadString();
            //自社設定摘要1
            temp.COMPANYNMRF_COMPANYSETNOTE1RF = reader.ReadString();
            //自社設定摘要2
            temp.COMPANYNMRF_COMPANYSETNOTE2RF = reader.ReadString();
            //画像情報区分
            temp.COMPANYNMRF_IMAGEINFODIVRF = reader.ReadInt32();
            //画像情報コード
            temp.COMPANYNMRF_IMAGEINFOCODERF = reader.ReadInt32();
            //自社URL
            temp.COMPANYNMRF_COMPANYURLRF = reader.ReadString();
            //自社PR文2
            temp.COMPANYNMRF_COMPANYPRSENTENCE2RF = reader.ReadString();
            //画像印字用コメント1
            temp.COMPANYNMRF_IMAGECOMMENTFORPRT1RF = reader.ReadString();
            //画像印字用コメント2
            temp.COMPANYNMRF_IMAGECOMMENTFORPRT2RF = reader.ReadString();
            //自社画像
            //部門名称
            temp.SUBSECTIONRF_SUBSECTIONNAMERF = reader.ReadString();
            //売上入力者カナ
            temp.EMPINP_KANARF = reader.ReadString();
            //売上入力者短縮名称
            temp.EMPINP_SHORTNAMERF = reader.ReadString();
            //受付従業員カナ
            temp.EMPFRT_KANARF = reader.ReadString();
            //受付従業員短縮名称
            temp.EMPFRT_SHORTNAMERF = reader.ReadString();
            //販売従業員カナ
            temp.EMPSAL_KANARF = reader.ReadString();
            //販売従業員短縮名称
            temp.EMPSAL_SHORTNAMERF = reader.ReadString();
            //請求先サブコード
            temp.CSTCLM_CUSTOMERSUBCODERF = reader.ReadString();
            //請求先名称
            temp.CSTCLM_NAMERF = reader.ReadString();
            //請求先名称2
            temp.CSTCLM_NAME2RF = reader.ReadString();
            //請求先敬称
            temp.CSTCLM_HONORIFICTITLERF = reader.ReadString();
            //請求先カナ
            temp.CSTCLM_KANARF = reader.ReadString();
            //請求先略称
            temp.CSTCLM_CUSTOMERSNMRF = reader.ReadString();
            //請求先諸口コード
            temp.CSTCLM_OUTPUTNAMECODERF = reader.ReadInt32();
            //請求先分析コード1
            temp.CSTCLM_CUSTANALYSCODE1RF = reader.ReadInt32();
            //請求先分析コード2
            temp.CSTCLM_CUSTANALYSCODE2RF = reader.ReadInt32();
            //請求先分析コード3
            temp.CSTCLM_CUSTANALYSCODE3RF = reader.ReadInt32();
            //請求先分析コード4
            temp.CSTCLM_CUSTANALYSCODE4RF = reader.ReadInt32();
            //請求先分析コード5
            temp.CSTCLM_CUSTANALYSCODE5RF = reader.ReadInt32();
            //請求先分析コード6
            temp.CSTCLM_CUSTANALYSCODE6RF = reader.ReadInt32();
            //請求先備考1
            temp.CSTCLM_NOTE1RF = reader.ReadString();
            //請求先備考2
            temp.CSTCLM_NOTE2RF = reader.ReadString();
            //請求先備考3
            temp.CSTCLM_NOTE3RF = reader.ReadString();
            //請求先備考4
            temp.CSTCLM_NOTE4RF = reader.ReadString();
            //請求先備考5
            temp.CSTCLM_NOTE5RF = reader.ReadString();
            //請求先備考6
            temp.CSTCLM_NOTE6RF = reader.ReadString();
            //請求先備考7
            temp.CSTCLM_NOTE7RF = reader.ReadString();
            //請求先備考8
            temp.CSTCLM_NOTE8RF = reader.ReadString();
            //請求先備考9
            temp.CSTCLM_NOTE9RF = reader.ReadString();
            //請求先備考10
            temp.CSTCLM_NOTE10RF = reader.ReadString();
            //得意先サブコード
            temp.CSTCST_CUSTOMERSUBCODERF = reader.ReadString();
            //得意先名称
            temp.CSTCST_NAMERF = reader.ReadString();
            //得意先名称2
            temp.CSTCST_NAME2RF = reader.ReadString();
            //得意先敬称
            temp.CSTCST_HONORIFICTITLERF = reader.ReadString();
            //得意先カナ
            temp.CSTCST_KANARF = reader.ReadString();
            //得意先略称
            temp.CSTCST_CUSTOMERSNMRF = reader.ReadString();
            //得意先諸口コード
            temp.CSTCST_OUTPUTNAMECODERF = reader.ReadInt32();
            //得意先分析コード1
            temp.CSTCST_CUSTANALYSCODE1RF = reader.ReadInt32();
            //得意先分析コード2
            temp.CSTCST_CUSTANALYSCODE2RF = reader.ReadInt32();
            //得意先分析コード3
            temp.CSTCST_CUSTANALYSCODE3RF = reader.ReadInt32();
            //得意先分析コード4
            temp.CSTCST_CUSTANALYSCODE4RF = reader.ReadInt32();
            //得意先分析コード5
            temp.CSTCST_CUSTANALYSCODE5RF = reader.ReadInt32();
            //得意先分析コード6
            temp.CSTCST_CUSTANALYSCODE6RF = reader.ReadInt32();
            //得意先備考1
            temp.CSTCST_NOTE1RF = reader.ReadString();
            //得意先備考2
            temp.CSTCST_NOTE2RF = reader.ReadString();
            //得意先備考3
            temp.CSTCST_NOTE3RF = reader.ReadString();
            //得意先備考4
            temp.CSTCST_NOTE4RF = reader.ReadString();
            //得意先備考5
            temp.CSTCST_NOTE5RF = reader.ReadString();
            //得意先備考6
            temp.CSTCST_NOTE6RF = reader.ReadString();
            //得意先備考7
            temp.CSTCST_NOTE7RF = reader.ReadString();
            //得意先備考8
            temp.CSTCST_NOTE8RF = reader.ReadString();
            //得意先備考9
            temp.CSTCST_NOTE9RF = reader.ReadString();
            //得意先備考10
            temp.CSTCST_NOTE10RF = reader.ReadString();
            //納入先サブコード
            temp.CSTADR_CUSTOMERSUBCODERF = reader.ReadString();
            //納入先名称
            temp.CSTADR_NAMERF = reader.ReadString();
            //納入先名称2
            temp.CSTADR_NAME2RF = reader.ReadString();
            //納入先敬称
            temp.CSTADR_HONORIFICTITLERF = reader.ReadString();
            //納入先カナ
            temp.CSTADR_KANARF = reader.ReadString();
            //納入先略称
            temp.CSTADR_CUSTOMERSNMRF = reader.ReadString();
            //納入先諸口コード
            temp.CSTADR_OUTPUTNAMECODERF = reader.ReadInt32();
            //納入先分析コード1
            temp.CSTADR_CUSTANALYSCODE1RF = reader.ReadInt32();
            //納入先分析コード2
            temp.CSTADR_CUSTANALYSCODE2RF = reader.ReadInt32();
            //納入先分析コード3
            temp.CSTADR_CUSTANALYSCODE3RF = reader.ReadInt32();
            //納入先分析コード4
            temp.CSTADR_CUSTANALYSCODE4RF = reader.ReadInt32();
            //納入先分析コード5
            temp.CSTADR_CUSTANALYSCODE5RF = reader.ReadInt32();
            //納入先分析コード6
            temp.CSTADR_CUSTANALYSCODE6RF = reader.ReadInt32();
            //納入先備考1
            temp.CSTADR_NOTE1RF = reader.ReadString();
            //納入先備考2
            temp.CSTADR_NOTE2RF = reader.ReadString();
            //納入先備考3
            temp.CSTADR_NOTE3RF = reader.ReadString();
            //納入先備考4
            temp.CSTADR_NOTE4RF = reader.ReadString();
            //納入先備考5
            temp.CSTADR_NOTE5RF = reader.ReadString();
            //納入先備考6
            temp.CSTADR_NOTE6RF = reader.ReadString();
            //納入先備考7
            temp.CSTADR_NOTE7RF = reader.ReadString();
            //納入先備考8
            temp.CSTADR_NOTE8RF = reader.ReadString();
            //納入先備考9
            temp.CSTADR_NOTE9RF = reader.ReadString();
            //納入先備考10
            temp.CSTADR_NOTE10RF = reader.ReadString();
            //自社名称1
            temp.COMPANYINFRF_COMPANYNAME1RF = reader.ReadString();
            //自社名称2
            temp.COMPANYINFRF_COMPANYNAME2RF = reader.ReadString();
            //郵便番号
            temp.COMPANYINFRF_POSTNORF = reader.ReadString();
            //住所1（都道府県市区郡・町村・字）
            temp.COMPANYINFRF_ADDRESS1RF = reader.ReadString();
            //住所3（番地）
            temp.COMPANYINFRF_ADDRESS3RF = reader.ReadString();
            //住所4（アパート名称）
            temp.COMPANYINFRF_ADDRESS4RF = reader.ReadString();
            //自社電話番号1
            temp.COMPANYINFRF_COMPANYTELNO1RF = reader.ReadString();
            //自社電話番号2
            temp.COMPANYINFRF_COMPANYTELNO2RF = reader.ReadString();
            //自社電話番号3
            temp.COMPANYINFRF_COMPANYTELNO3RF = reader.ReadString();
            //自社電話番号タイトル1
            temp.COMPANYINFRF_COMPANYTELTITLE1RF = reader.ReadString();
            //自社電話番号タイトル2
            temp.COMPANYINFRF_COMPANYTELTITLE2RF = reader.ReadString();
            //自社電話番号タイトル3
            temp.COMPANYINFRF_COMPANYTELTITLE3RF = reader.ReadString();
            //受注ステータス名称
            temp.HADD_ACPTANODRSTNMRF = reader.ReadString();
            //赤伝区分名称
            temp.HADD_DEBITNOTEDIVNMRF = reader.ReadString();
            //売上伝票区分名称
            temp.HADD_SALESSLIPNMRF = reader.ReadString();
            //売上商品区分名称
            temp.HADD_SALESGOODSNMRF = reader.ReadString();
            //売掛区分名称
            temp.HADD_ACCRECDIVNMRF = reader.ReadString();
            //来勘区分名称
            temp.HADD_DELAYPAYMENTDIVNMRF = reader.ReadString();
            //見積区分名称
            temp.HADD_ESTIMATEDIVIDENMRF = reader.ReadString();
            //消費税転嫁方式名称
            temp.HADD_CONSTAXLAYMETHODNMRF = reader.ReadString();
            //自動入金区分名称
            temp.HADD_AUTODEPOSITNMRF = reader.ReadString();
            //伝票発行済区分名称
            temp.HADD_SLIPPRINTFINISHNMRF = reader.ReadString();
            //一式伝票区分名称
            temp.HADD_COMPLETENMRF = reader.ReadString();
            //(先頭)車両管理番号
            temp.HADD_CARMNGNORF = reader.ReadInt32();
            //(先頭)車輌管理コード
            temp.HADD_CARMNGCODERF = reader.ReadString();
            //(先頭)陸運事務所番号
            temp.HADD_NUMBERPLATE1CODERF = reader.ReadInt32();
            //(先頭)陸運事務局名称
            temp.HADD_NUMBERPLATE1NAMERF = reader.ReadString();
            //(先頭)車両登録番号（種別）
            temp.HADD_NUMBERPLATE2RF = reader.ReadString();
            //(先頭)車両登録番号（カナ）
            temp.HADD_NUMBERPLATE3RF = reader.ReadString();
            //(先頭)車両登録番号（プレート番号）
            temp.HADD_NUMBERPLATE4RF = reader.ReadInt32();
            //(先頭)初年度
            temp.HADD_FIRSTENTRYDATERF = reader.ReadInt32();
            //(先頭)メーカーコード
            temp.HADD_MAKERCODERF = reader.ReadInt32();
            //(先頭)メーカー全角名称
            temp.HADD_MAKERFULLNAMERF = reader.ReadString();
            //(先頭)車種コード
            temp.HADD_MODELCODERF = reader.ReadInt32();
            //(先頭)車種サブコード
            temp.HADD_MODELSUBCODERF = reader.ReadInt32();
            //(先頭)車種全角名称
            temp.HADD_MODELFULLNAMERF = reader.ReadString();
            //(先頭)排ガス記号
            temp.HADD_EXHAUSTGASSIGNRF = reader.ReadString();
            //(先頭)シリーズ型式
            temp.HADD_SERIESMODELRF = reader.ReadString();
            //(先頭)型式（類別記号）
            temp.HADD_CATEGORYSIGNMODELRF = reader.ReadString();
            //(先頭)型式（フル型）
            temp.HADD_FULLMODELRF = reader.ReadString();
            //(先頭)型式指定番号
            temp.HADD_MODELDESIGNATIONNORF = reader.ReadInt32();
            //(先頭)類別番号
            temp.HADD_CATEGORYNORF = reader.ReadInt32();
            //(先頭)車台型式
            temp.HADD_FRAMEMODELRF = reader.ReadString();
            //(先頭)車台番号
            temp.HADD_FRAMENORF = reader.ReadString();
            //(先頭)車台番号（検索用）
            temp.HADD_SEARCHFRAMENORF = reader.ReadInt32();
            //(先頭)エンジン型式名称
            temp.HADD_ENGINEMODELNMRF = reader.ReadString();
            //(先頭)関連型式
            temp.HADD_RELEVANCEMODELRF = reader.ReadString();
            //(先頭)サブ車名コード
            temp.HADD_SUBCARNMCDRF = reader.ReadInt32();
            //(先頭)型式グレード略称
            temp.HADD_MODELGRADESNAMERF = reader.ReadString();
            //(先頭)カラーコード
            temp.HADD_COLORCODERF = reader.ReadString();
            //(先頭)カラー名称1
            temp.HADD_COLORNAME1RF = reader.ReadString();
            //(先頭)トリムコード
            temp.HADD_TRIMCODERF = reader.ReadString();
            //(先頭)トリム名称
            temp.HADD_TRIMNAMERF = reader.ReadString();
            //(先頭)車両走行距離
            temp.HADD_MILEAGERF = reader.ReadInt32();
            //プリンタ管理No
            temp.HADD_PRINTERMNGNORF = reader.ReadInt32();
            //伝票印刷設定用帳票ID
            temp.HADD_SLIPPRTSETPAPERIDRF = reader.ReadString();
            //自社備考１
            temp.HADD_NOTE1RF = reader.ReadString();
            //自社備考２
            temp.HADD_NOTE2RF = reader.ReadString();
            //自社備考３
            temp.HADD_NOTE3RF = reader.ReadString();
            //再発行マーク
            temp.HADD_REISSUEMARKRF = reader.ReadString();
            //参考消費税印字名称
            temp.HADD_REFCONSTAXPRTNMRF = reader.ReadString();
            //印刷時刻 時
            temp.HADD_PRINTTIMEHOURRF = reader.ReadInt32();
            //印刷時刻 分
            temp.HADD_PRINTTIMEMINUTERF = reader.ReadInt32();
            //印刷時刻 秒
            temp.HADD_PRINTTIMESECONDRF = reader.ReadInt32();
            //伝票検索日付西暦年
            temp.HADD_SEARCHSLIPDATEFYRF = reader.ReadInt32();
            //伝票検索日付西暦年略
            temp.HADD_SEARCHSLIPDATEFSRF = reader.ReadInt32();
            //伝票検索日付和暦年
            temp.HADD_SEARCHSLIPDATEFWRF = reader.ReadInt32();
            //伝票検索日付月
            temp.HADD_SEARCHSLIPDATEFMRF = reader.ReadInt32();
            //伝票検索日付日
            temp.HADD_SEARCHSLIPDATEFDRF = reader.ReadInt32();
            //伝票検索日付元号
            temp.HADD_SEARCHSLIPDATEFGRF = reader.ReadString();
            //伝票検索日付略号
            temp.HADD_SEARCHSLIPDATEFRRF = reader.ReadString();
            //伝票検索日付リテラル(/)
            temp.HADD_SEARCHSLIPDATEFLSRF = reader.ReadString();
            //伝票検索日付リテラル(.)
            temp.HADD_SEARCHSLIPDATEFLPRF = reader.ReadString();
            //伝票検索日付リテラル(年)
            temp.HADD_SEARCHSLIPDATEFLYRF = reader.ReadString();
            //伝票検索日付リテラル(月)
            temp.HADD_SEARCHSLIPDATEFLMRF = reader.ReadString();
            //伝票検索日付リテラル(日)
            temp.HADD_SEARCHSLIPDATEFLDRF = reader.ReadString();
            //出荷日付西暦年
            temp.HADD_SHIPMENTDAYFYRF = reader.ReadInt32();
            //出荷日付西暦年略
            temp.HADD_SHIPMENTDAYFSRF = reader.ReadInt32();
            //出荷日付和暦年
            temp.HADD_SHIPMENTDAYFWRF = reader.ReadInt32();
            //出荷日付月
            temp.HADD_SHIPMENTDAYFMRF = reader.ReadInt32();
            //出荷日付日
            temp.HADD_SHIPMENTDAYFDRF = reader.ReadInt32();
            //出荷日付元号
            temp.HADD_SHIPMENTDAYFGRF = reader.ReadString();
            //出荷日付略号
            temp.HADD_SHIPMENTDAYFRRF = reader.ReadString();
            //出荷日付リテラル(/)
            temp.HADD_SHIPMENTDAYFLSRF = reader.ReadString();
            //出荷日付リテラル(.)
            temp.HADD_SHIPMENTDAYFLPRF = reader.ReadString();
            //出荷日付リテラル(年)
            temp.HADD_SHIPMENTDAYFLYRF = reader.ReadString();
            //出荷日付リテラル(月)
            temp.HADD_SHIPMENTDAYFLMRF = reader.ReadString();
            //出荷日付リテラル(日)
            temp.HADD_SHIPMENTDAYFLDRF = reader.ReadString();
            //売上日付西暦年
            temp.HADD_SALESDATEFYRF = reader.ReadInt32();
            //売上日付西暦年略
            temp.HADD_SALESDATEFSRF = reader.ReadInt32();
            //売上日付和暦年
            temp.HADD_SALESDATEFWRF = reader.ReadInt32();
            //売上日付月
            temp.HADD_SALESDATEFMRF = reader.ReadInt32();
            //売上日付日
            temp.HADD_SALESDATEFDRF = reader.ReadInt32();
            //売上日付元号
            temp.HADD_SALESDATEFGRF = reader.ReadString();
            //売上日付略号
            temp.HADD_SALESDATEFRRF = reader.ReadString();
            //売上日付リテラル(/)
            temp.HADD_SALESDATEFLSRF = reader.ReadString();
            //売上日付リテラル(.)
            temp.HADD_SALESDATEFLPRF = reader.ReadString();
            //売上日付リテラル(年)
            temp.HADD_SALESDATEFLYRF = reader.ReadString();
            //売上日付リテラル(月)
            temp.HADD_SALESDATEFLMRF = reader.ReadString();
            //売上日付リテラル(日)
            temp.HADD_SALESDATEFLDRF = reader.ReadString();
            //計上日付西暦年
            temp.HADD_ADDUPADATEFYRF = reader.ReadInt32();
            //計上日付西暦年略
            temp.HADD_ADDUPADATEFSRF = reader.ReadInt32();
            //計上日付和暦年
            temp.HADD_ADDUPADATEFWRF = reader.ReadInt32();
            //計上日付月
            temp.HADD_ADDUPADATEFMRF = reader.ReadInt32();
            //計上日付日
            temp.HADD_ADDUPADATEFDRF = reader.ReadInt32();
            //計上日付元号
            temp.HADD_ADDUPADATEFGRF = reader.ReadString();
            //計上日付略号
            temp.HADD_ADDUPADATEFRRF = reader.ReadString();
            //計上日付リテラル(/)
            temp.HADD_ADDUPADATEFLSRF = reader.ReadString();
            //計上日付リテラル(.)
            temp.HADD_ADDUPADATEFLPRF = reader.ReadString();
            //計上日付リテラル(年)
            temp.HADD_ADDUPADATEFLYRF = reader.ReadString();
            //計上日付リテラル(月)
            temp.HADD_ADDUPADATEFLMRF = reader.ReadString();
            //計上日付リテラル(日)
            temp.HADD_ADDUPADATEFLDRF = reader.ReadString();
            //売上伝票発行日西暦年
            temp.HADD_SALESSLIPPRINTDATEFYRF = reader.ReadInt32();
            //売上伝票発行日西暦年略
            temp.HADD_SALESSLIPPRINTDATEFSRF = reader.ReadInt32();
            //売上伝票発行日和暦年
            temp.HADD_SALESSLIPPRINTDATEFWRF = reader.ReadInt32();
            //売上伝票発行日月
            temp.HADD_SALESSLIPPRINTDATEFMRF = reader.ReadInt32();
            //売上伝票発行日日
            temp.HADD_SALESSLIPPRINTDATEFDRF = reader.ReadInt32();
            //売上伝票発行日元号
            temp.HADD_SALESSLIPPRINTDATEFGRF = reader.ReadString();
            //売上伝票発行日略号
            temp.HADD_SALESSLIPPRINTDATEFRRF = reader.ReadString();
            //売上伝票発行日リテラル(/)
            temp.HADD_SALESSLIPPRINTDATEFLSRF = reader.ReadString();
            //売上伝票発行日リテラル(.)
            temp.HADD_SALESSLIPPRINTDATEFLPRF = reader.ReadString();
            //売上伝票発行日リテラル(年)
            temp.HADD_SALESSLIPPRINTDATEFLYRF = reader.ReadString();
            //売上伝票発行日リテラル(月)
            temp.HADD_SALESSLIPPRINTDATEFLMRF = reader.ReadString();
            //売上伝票発行日リテラル(日)
            temp.HADD_SALESSLIPPRINTDATEFLDRF = reader.ReadString();
            //(先頭)初年度西暦年
            temp.HADD_FIRSTENTRYDATEFYRF = reader.ReadInt32();
            //(先頭)初年度西暦年略
            temp.HADD_FIRSTENTRYDATEFSRF = reader.ReadInt32();
            //(先頭)初年度和暦年
            temp.HADD_FIRSTENTRYDATEFWRF = reader.ReadInt32();
            //(先頭)初年度月
            temp.HADD_FIRSTENTRYDATEFMRF = reader.ReadInt32();
            //(先頭)初年度日
            temp.HADD_FIRSTENTRYDATEFDRF = reader.ReadInt32();
            //(先頭)初年度元号
            temp.HADD_FIRSTENTRYDATEFGRF = reader.ReadString();
            //(先頭)初年度略号
            temp.HADD_FIRSTENTRYDATEFRRF = reader.ReadString();
            //(先頭)初年度リテラル(/)
            temp.HADD_FIRSTENTRYDATEFLSRF = reader.ReadString();
            //(先頭)初年度リテラル(.)
            temp.HADD_FIRSTENTRYDATEFLPRF = reader.ReadString();
            //(先頭)初年度リテラル(年)
            temp.HADD_FIRSTENTRYDATEFLYRF = reader.ReadString();
            //(先頭)初年度リテラル(月)
            temp.HADD_FIRSTENTRYDATEFLMRF = reader.ReadString();
            //(先頭)初年度リテラル(日)
            temp.HADD_FIRSTENTRYDATEFLDRF = reader.ReadString();
            //印刷用得意先名称（上段）
            temp.HADD_PRINTCUSTOMERNAME1RF = reader.ReadString();
            //印刷用得意先名称（下段）
            temp.HADD_PRINTCUSTOMERNAME2RF = reader.ReadString();
            //印刷用得意先名称（下段）＋敬称
            temp.HADD_PRINTCUSTOMERNAME2HNRF = reader.ReadString();
            //(先頭)メーカー半角名称
            temp.HADD_MAKERHALFNAMERF = reader.ReadString();
            //(先頭)車種半角名称
            temp.HADD_MODELHALFNAMERF = reader.ReadString();
            //伝票備考３
            temp.SALESSLIPRF_SLIPNOTE3RF = reader.ReadString();
            //得意先名１＋得意先名２
            temp.HADD_PRINTCUSTOMERNAMEJOIN12RF = reader.ReadString();
            //得意先名１＋得意先名２＋敬称
            temp.HADD_PRINTCUSTOMERNAMEJOIN12HNRF = reader.ReadString();
            //自社名１（前半）
            temp.HADD_PRINTENTERPRISENAME1FHRF = reader.ReadString();
            //自社名１（後半）
            temp.HADD_PRINTENTERPRISENAME1LHRF = reader.ReadString();
            //自社名２（前半）
            temp.HADD_PRINTENTERPRISENAME2FHRF = reader.ReadString();
            //自社名２（後半）
            temp.HADD_PRINTENTERPRISENAME2LHRF = reader.ReadString();
            //実績計上拠点コード
            temp.SALESSLIPRF_RESULTSADDUPSECCDRF = reader.ReadString();
            //更新日時
            temp.SALESSLIPRF_UPDATEDATETIMERF = reader.ReadInt64();

            // --- ADD 2009.07.24 劉洋 ------ >>>>>>
            //得意先コード
            temp.SANDESETTINGRF_CUSTOMERCODE = reader.ReadInt32();
            //納品先店舗コード
            temp.SANDESETTINGRF_ADDRESSEESHOPCD = reader.ReadString();
            //住電管理コード
            temp.SANDESETTINGRF_SANDEMNGCODE = reader.ReadString();
            //経費区分
            temp.SANDESETTINGRF_EXPENSEDIVCD = reader.ReadInt32();
            //直送区分
            temp.SANDESETTINGRF_DIRECTSENDINGCD = reader.ReadInt32();
            //受注区分
            temp.SANDESETTINGRF_ACPTANORDERDIV = reader.ReadInt32();
            //納品者コード
            temp.SANDESETTINGRF_DELIVERERCD = reader.ReadString();
            //納品者名
            temp.SANDESETTINGRF_DELIVERERNM = reader.ReadString();
            //納品者住所
            temp.SANDESETTINGRF_DELIVERERADDRESS = reader.ReadString();
            //納品者ＴＥＬ
            temp.SANDESETTINGRF_DELIVERERPHONENUM = reader.ReadString();
            //部品商名
            temp.SANDESETTINGRF_TRADCOMPNAME = reader.ReadString();
            //部品商拠点名
            temp.SANDESETTINGRF_TRADCOMPSECTNAME = reader.ReadString();
            //部品商コード（純正）
            temp.SANDESETTINGRF_PURETRADCOMPCD = reader.ReadString();
            //部品商仕切率（純正）
            temp.SANDESETTINGRF_PURETRADCOMPRATE = reader.ReadDouble();
            //部品商コード（優良）
            temp.SANDESETTINGRF_PRITRADCOMPCD = reader.ReadString();
            //部品商仕切率（優良）
            temp.SANDESETTINGRF_PRITRADCOMPRATE = reader.ReadDouble();
            //AB商品コード
            temp.SANDESETTINGRF_ABGOODSCODE = reader.ReadString();
            //コメント指定区分
            temp.SANDESETTINGRF_COMMENTRESERVEDDIV = reader.ReadInt32();
            //商品メーカーコード１
            temp.SANDESETTINGRF_GOODSMAKERCD1 = reader.ReadInt32();
            //商品メーカーコード２
            temp.SANDESETTINGRF_GOODSMAKERCD2 = reader.ReadInt32();
            //商品メーカーコード３
            temp.SANDESETTINGRF_GOODSMAKERCD3 = reader.ReadInt32();
            //商品メーカーコード４
            temp.SANDESETTINGRF_GOODSMAKERCD4 = reader.ReadInt32();
            //商品メーカーコード５
            temp.SANDESETTINGRF_GOODSMAKERCD5 = reader.ReadInt32();
            //商品メーカーコード６
            temp.SANDESETTINGRF_GOODSMAKERCD6 = reader.ReadInt32();
            //商品メーカーコード７
            temp.SANDESETTINGRF_GOODSMAKERCD7 = reader.ReadInt32();
            //商品メーカーコード８
            temp.SANDESETTINGRF_GOODSMAKERCD8 = reader.ReadInt32();
            //商品メーカーコード９
            temp.SANDESETTINGRF_GOODSMAKERCD9 = reader.ReadInt32();
            //商品メーカーコード１０
            temp.SANDESETTINGRF_GOODSMAKERCD10 = reader.ReadInt32();
            //商品メーカーコード１１
            temp.SANDESETTINGRF_GOODSMAKERCD11 = reader.ReadInt32();
            //商品メーカーコード１２
            temp.SANDESETTINGRF_GOODSMAKERCD12 = reader.ReadInt32();
            //商品メーカーコード１３
            temp.SANDESETTINGRF_GOODSMAKERCD13 = reader.ReadInt32();
            //商品メーカーコード１４
            temp.SANDESETTINGRF_GOODSMAKERCD14 = reader.ReadInt32();
            //商品メーカーコード１５
            temp.SANDESETTINGRF_GOODSMAKERCD15 = reader.ReadInt32();
            //部品ＯＥＭ区分
            temp.SANDESETTINGRF_PARTSOEMDIV = reader.ReadInt32();
            // --- ADD 2009.07.24 劉洋 ------ <<<<<<
            // --- ADD  大矢睦美  2010/03/01 ---------->>>>>
            //売上単価端数処理コード
            temp.CSTCST_SALESUNPRCFRCPROCCDRF = reader.ReadInt32();
            //売上金額端数処理コード
            temp.CSTCST_SALESMONEYFRCPROCCDRF = reader.ReadInt32();
            //売上消費税端数処理コード
            temp.CSTCST_SALESCNSTAXFRCPROCCDRF = reader.ReadInt32();
            // --- ADD  大矢睦美  2010/03/01 ----------<<<<<
            // --- ADD m.suzuki 2010/03/24 ---------->>>>>
            //QRコード印刷
            temp.CSTCST_QRCODEPRTCDRF = reader.ReadInt32();
            // --- ADD m.suzuki 2010/03/24 ----------<<<<<
            // 2010/07/06 Add >>>
            //売上データヘッダガイド
            int lenOfFileHeaderGuidArray = reader.ReadInt32();
            byte[] fileHeaderGuidArray = reader.ReadBytes(lenOfFileHeaderGuidArray);
            temp.SALESSLIPRF_FILEHEADERGUID = new Guid(fileHeaderGuidArray);
            // 2010/07/06 Add <<<
            // ---- ADD caohh 2011/08/17 ------>>>>>
            //郵便番号
            temp.CSTCST_POSTNORF = reader.ReadString();
            //住所1（都道府県市区郡・町村・字）
            temp.CSTCST_ADDRESS1RF = reader.ReadString();
            //住所3（番地）
            temp.CSTCST_ADDRESS3RF = reader.ReadString();
            //住所4（アパート名称）
            temp.CSTCST_ADDRESS4RF = reader.ReadString();
            //電話番号（自宅）
            temp.CSTCST_HOMETELNORF = reader.ReadString();
            //電話番号（勤務先）
            temp.CSTCST_OFFICETELNORF = reader.ReadString();
            //電話番号（携帯）
            temp.CSTCST_PORTABLETELNORF = reader.ReadString();
            //FAX番号（自宅）
            temp.CSTCST_HOMEFAXNORF = reader.ReadString();
            //FAX番号（勤務先）
            temp.CSTCST_OFFICEFAXNORF = reader.ReadString();
            //電話番号（その他）
            temp.CSTCST_OTHERSTELNORF = reader.ReadString();
            // ---- ADD caohh 2011/08/17 ------<<<<<

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
        /// <returns>FrePSalesSlipWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   FrePSalesSlipWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize( System.IO.BinaryReader reader )
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject( reader );
            ArrayList lst = new ArrayList();
            for ( int cnt = 0; cnt < serInfo.Occurrence; ++cnt )
            {
                FrePSalesSlipWork temp = GetFrePSalesSlipWork( reader, serInfo );
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
                    retValue = (FrePSalesSlipWork[])lst.ToArray( typeof( FrePSalesSlipWork ) );
                    break;
            }
            return retValue;
        }

        #endregion
    }
}
