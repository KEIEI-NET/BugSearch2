using System;
using System.Collections;

using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;
using System.Drawing;
using System.IO;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   PdfAllOutputFrePBillHeadWork
    /// <summary>
    ///                      自由帳票請求書ヘッダデータワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   自由帳票請求書ヘッダデータワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Genarated Date   :   2022/03/07  (CSharp File Generated Date)</br>
    /// <br></br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class EBooksFrePBillHeadWork
    {
        /// <summary>計上拠点コード</summary>
        /// <remarks>集計の対象となっている拠点コード</remarks>
        private string _cUSTDMDPRCRF_ADDUPSECCODERF = "";

        /// <summary>請求先コード</summary>
        /// <remarks>請求先親コード</remarks>
        private Int32 _cUSTDMDPRCRF_CLAIMCODERF;

        /// <summary>請求先名称</summary>
        private string _cUSTDMDPRCRF_CLAIMNAMERF = "";

        /// <summary>請求先名称2</summary>
        private string _cUSTDMDPRCRF_CLAIMNAME2RF = "";

        /// <summary>請求先略称</summary>
        private string _cUSTDMDPRCRF_CLAIMSNMRF = "";

        /// <summary>得意先コード</summary>
        private Int32 _cUSTDMDPRCRF_CUSTOMERCODERF;

        /// <summary>得意先名称</summary>
        private string _cUSTDMDPRCRF_CUSTOMERNAMERF = "";

        /// <summary>得意先名称2</summary>
        private string _cUSTDMDPRCRF_CUSTOMERNAME2RF = "";

        /// <summary>得意先略称</summary>
        private string _cUSTDMDPRCRF_CUSTOMERSNMRF = "";

        /// <summary>計上年月日</summary>
        /// <remarks>YYYYMMDD 請求締を行なった日（相手先基準）</remarks>
        private Int32 _cUSTDMDPRCRF_ADDUPDATERF;

        /// <summary>計上年月</summary>
        /// <remarks>YYYYMM</remarks>
        private Int32 _cUSTDMDPRCRF_ADDUPYEARMONTHRF;

        /// <summary>前回請求金額</summary>
        private Int64 _cUSTDMDPRCRF_LASTTIMEDEMANDRF;

        /// <summary>今回手数料額（通常入金）</summary>
        private Int64 _cUSTDMDPRCRF_THISTIMEFEEDMDNRMLRF;

        /// <summary>今回値引額（通常入金）</summary>
        private Int64 _cUSTDMDPRCRF_THISTIMEDISDMDNRMLRF;

        /// <summary>今回入金金額（通常入金）</summary>
        /// <remarks>入金額の合計金額</remarks>
        private Int64 _cUSTDMDPRCRF_THISTIMEDMDNRMLRF;

        /// <summary>今回繰越残高（請求計）</summary>
        /// <remarks>今回繰越残高＝前回請求額－今回入金額合計（通常）</remarks>
        private Int64 _cUSTDMDPRCRF_THISTIMETTLBLCDMDRF;

        /// <summary>相殺後今回売上金額</summary>
        private Int64 _cUSTDMDPRCRF_OFSTHISTIMESALESRF;

        /// <summary>相殺後今回売上消費税</summary>
        private Int64 _cUSTDMDPRCRF_OFSTHISSALESTAXRF;

        /// <summary>相殺後外税対象額</summary>
        /// <remarks>相殺用：外税額（税抜き）の集計</remarks>
        private Int64 _cUSTDMDPRCRF_ITDEDOFFSETOUTTAXRF;

        /// <summary>相殺後内税対象額</summary>
        /// <remarks>相殺用：内税額（税抜き）の集計</remarks>
        private Int64 _cUSTDMDPRCRF_ITDEDOFFSETINTAXRF;

        /// <summary>相殺後非課税対象額</summary>
        /// <remarks>相殺用：非課税額の集計</remarks>
        private Int64 _cUSTDMDPRCRF_ITDEDOFFSETTAXFREERF;

        /// <summary>相殺後外税消費税</summary>
        /// <remarks>相殺用：外税消費税の集計　（請求転嫁時は、課税対象額から算出）</remarks>
        private Int64 _cUSTDMDPRCRF_OFFSETOUTTAXRF;

        /// <summary>相殺後内税消費税</summary>
        /// <remarks>相殺用：内税消費税の集計</remarks>
        private Int64 _cUSTDMDPRCRF_OFFSETINTAXRF;

        /// <summary>今回売上金額</summary>
        /// <remarks>掛売：値引、返品を含まない税抜きの売上金額</remarks>
        private Int64 _cUSTDMDPRCRF_THISTIMESALESRF;

        /// <summary>今回売上消費税</summary>
        private Int64 _cUSTDMDPRCRF_THISSALESTAXRF;

        /// <summary>売上外税対象額</summary>
        /// <remarks>請求用：外税額（税抜き）の集計</remarks>
        private Int64 _cUSTDMDPRCRF_ITDEDSALESOUTTAXRF;

        /// <summary>売上内税対象額</summary>
        /// <remarks>請求用：内税額（税抜き）の集計</remarks>
        private Int64 _cUSTDMDPRCRF_ITDEDSALESINTAXRF;

        /// <summary>売上非課税対象額</summary>
        /// <remarks>請求用：非課税額の集計</remarks>
        private Int64 _cUSTDMDPRCRF_ITDEDSALESTAXFREERF;

        /// <summary>売上外税額</summary>
        /// <remarks>請求用：外税消費税の集計　（請求転嫁時は、課税対象額から算出）</remarks>
        private Int64 _cUSTDMDPRCRF_SALESOUTTAXRF;

        /// <summary>売上内税額</summary>
        /// <remarks>掛売：内税商品売上の内税消費税額（返品、値引含まず）</remarks>
        private Int64 _cUSTDMDPRCRF_SALESINTAXRF;

        /// <summary>今回売上返品金額</summary>
        /// <remarks>掛売：値引を含まない税抜きの売上返品金額</remarks>
        private Int64 _cUSTDMDPRCRF_THISSALESPRICRGDSRF;

        /// <summary>今回売上返品消費税</summary>
        /// <remarks>今回売上返品消費税＝返品外税額合計＋返品内税額合計</remarks>
        private Int64 _cUSTDMDPRCRF_THISSALESPRCTAXRGDSRF;

        /// <summary>返品外税対象額合計</summary>
        private Int64 _cUSTDMDPRCRF_TTLITDEDRETOUTTAXRF;

        /// <summary>返品内税対象額合計</summary>
        private Int64 _cUSTDMDPRCRF_TTLITDEDRETINTAXRF;

        /// <summary>返品非課税対象額合計</summary>
        private Int64 _cUSTDMDPRCRF_TTLITDEDRETTAXFREERF;

        /// <summary>返品外税額合計</summary>
        private Int64 _cUSTDMDPRCRF_TTLRETOUTERTAXRF;

        /// <summary>返品内税額合計</summary>
        /// <remarks>掛売：内税商品返品の内税消費税額（値引含まず）</remarks>
        private Int64 _cUSTDMDPRCRF_TTLRETINNERTAXRF;

        /// <summary>今回売上値引金額</summary>
        /// <remarks>掛売：税抜きの売上値引金額</remarks>
        private Int64 _cUSTDMDPRCRF_THISSALESPRICDISRF;

        /// <summary>今回売上値引消費税</summary>
        /// <remarks>今回売上値引消費税＝値引外税額合計＋値引内税額合計</remarks>
        private Int64 _cUSTDMDPRCRF_THISSALESPRCTAXDISRF;

        /// <summary>値引外税対象額合計</summary>
        private Int64 _cUSTDMDPRCRF_TTLITDEDDISOUTTAXRF;

        /// <summary>値引内税対象額合計</summary>
        private Int64 _cUSTDMDPRCRF_TTLITDEDDISINTAXRF;

        /// <summary>値引非課税対象額合計</summary>
        private Int64 _cUSTDMDPRCRF_TTLITDEDDISTAXFREERF;

        /// <summary>値引外税額合計</summary>
        private Int64 _cUSTDMDPRCRF_TTLDISOUTERTAXRF;

        /// <summary>値引内税額合計</summary>
        /// <remarks>掛売：内税商品返品の内税消費税額</remarks>
        private Int64 _cUSTDMDPRCRF_TTLDISINNERTAXRF;

        /// <summary>消費税調整額</summary>
        private Int64 _cUSTDMDPRCRF_TAXADJUSTRF;

        /// <summary>残高調整額</summary>
        private Int64 _cUSTDMDPRCRF_BALANCEADJUSTRF;

        /// <summary>計算後請求金額</summary>
        /// <remarks>今回請求金額</remarks>
        private Int64 _cUSTDMDPRCRF_AFCALDEMANDPRICERF;

        /// <summary>受注2回前残高（請求計）</summary>
        private Int64 _cUSTDMDPRCRF_ACPODRTTL2TMBFBLDMDRF;

        /// <summary>受注3回前残高（請求計）</summary>
        private Int64 _cUSTDMDPRCRF_ACPODRTTL3TMBFBLDMDRF;

        /// <summary>締次更新開始年月日</summary>
        /// <remarks>"YYYYMMDD"  締次更新対象となる開始年月日</remarks>
        private Int32 _cUSTDMDPRCRF_STARTCADDUPUPDDATERF;

        /// <summary>売上伝票枚数</summary>
        /// <remarks>掛売の伝票枚数</remarks>
        private Int32 _cUSTDMDPRCRF_SALESSLIPCOUNTRF;

        /// <summary>請求書発行日</summary>
        /// <remarks>"YYYYMMDD"  請求書を発行した年月日</remarks>
        private Int32 _cUSTDMDPRCRF_BILLPRINTDATERF;

        /// <summary>入金予定日</summary>
        private Int32 _cUSTDMDPRCRF_EXPECTEDDEPOSITDATERF;

        /// <summary>回収条件</summary>
        /// <remarks>10:現金,20:振込,30:小切手,40:手形,50:手数料,60:相殺,70:値引,80:その他</remarks>
        private Int32 _cUSTDMDPRCRF_COLLECTCONDRF;

        /// <summary>消費税転嫁方式</summary>
        /// <remarks>消費税転嫁区分設定マスタを参照 0:伝票単位1:明細単位2:請求時一括</remarks>
        private Int32 _cUSTDMDPRCRF_CONSTAXLAYMETHODRF;

        /// <summary>消費税率</summary>
        /// <remarks>請求転嫁消費税を算出する場合に使用</remarks>
        private Double _cUSTDMDPRCRF_CONSTAXRATERF;

        /// <summary>拠点ガイド名称</summary>
        /// <remarks>ＵＩ用（既存のコンボボックス等）</remarks>
        private string _sECHED_SECTIONGUIDENMRF = "";

        /// <summary>拠点ガイド略称</summary>
        /// <remarks>帳票印字用</remarks>
        private string _sECHED_SECTIONGUIDESNMRF = "";

        /// <summary>自社名称コード1</summary>
        private Int32 _sECHED_COMPANYNAMECD1RF;

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

        /// <summary>画像情報データ</summary>
        private Byte[] _iMAGEINFORF_IMAGEINFODATARF;

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

        /// <summary>得意先郵便番号</summary>
        /// <remarks>納入先の場合の使用可能項目</remarks>
        private string _cSTCST_POSTNORF = "";

        /// <summary>得意先住所1（都道府県市区郡・町村・字）</summary>
        /// <remarks>納入先の場合の使用可能項目</remarks>
        private string _cSTCST_ADDRESS1RF = "";

        /// <summary>得意先住所3（番地）</summary>
        /// <remarks>納入先の場合の使用可能項目</remarks>
        private string _cSTCST_ADDRESS3RF = "";

        /// <summary>得意先住所4（アパート名称）</summary>
        /// <remarks>納入先の場合の使用可能項目</remarks>
        private string _cSTCST_ADDRESS4RF = "";

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

        // --- ADD START 田村顕成 2022/10/18 ----->>>>>
        /// <summary>売上消費税端数処理コード</summary>
        private Int32 _cSTCLM_SALESCNSTAXFRCPROCCDRF;
        // --- ADD END 田村顕成 2022/10/18 -----<<<<<

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

        /// <summary>請求先郵便番号</summary>
        /// <remarks>納入先の場合の使用可能項目</remarks>
        private string _cSTCLM_POSTNORF = "";

        /// <summary>請求先住所1（都道府県市区郡・町村・字）</summary>
        /// <remarks>納入先の場合の使用可能項目</remarks>
        private string _cSTCLM_ADDRESS1RF = "";

        /// <summary>請求先住所3（番地）</summary>
        /// <remarks>納入先の場合の使用可能項目</remarks>
        private string _cSTCLM_ADDRESS3RF = "";

        /// <summary>請求先住所4（アパート名称）</summary>
        /// <remarks>納入先の場合の使用可能項目</remarks>
        private string _cSTCLM_ADDRESS4RF = "";

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

        /// <summary>入金設定金種コード1</summary>
        private Int32 _dEPOSITSTRF_DEPOSITSTKINDCD1RF;

        /// <summary>入金設定金種コード2</summary>
        private Int32 _dEPOSITSTRF_DEPOSITSTKINDCD2RF;

        /// <summary>入金設定金種コード3</summary>
        private Int32 _dEPOSITSTRF_DEPOSITSTKINDCD3RF;

        /// <summary>入金設定金種コード4</summary>
        private Int32 _dEPOSITSTRF_DEPOSITSTKINDCD4RF;

        /// <summary>入金設定金種コード5</summary>
        private Int32 _dEPOSITSTRF_DEPOSITSTKINDCD5RF;

        /// <summary>入金設定金種コード6</summary>
        private Int32 _dEPOSITSTRF_DEPOSITSTKINDCD6RF;

        /// <summary>入金設定金種コード7</summary>
        private Int32 _dEPOSITSTRF_DEPOSITSTKINDCD7RF;

        /// <summary>入金設定金種コード8</summary>
        private Int32 _dEPOSITSTRF_DEPOSITSTKINDCD8RF;

        /// <summary>入金設定金種コード9</summary>
        private Int32 _dEPOSITSTRF_DEPOSITSTKINDCD9RF;

        /// <summary>入金設定金種コード10</summary>
        private Int32 _dEPOSITSTRF_DEPOSITSTKINDCD10RF;

        /// <summary>入金金種名称1</summary>
        private string _dEPT01_MONEYKINDNAMERF = "";

        /// <summary>入金金額1</summary>
        private Int64 _dEPT01_DEPOSITRF;

        /// <summary>入金金種名称2</summary>
        private string _dEPT02_MONEYKINDNAMERF = "";

        /// <summary>入金金額2</summary>
        private Int64 _dEPT02_DEPOSITRF;

        /// <summary>入金金種名称3</summary>
        private string _dEPT03_MONEYKINDNAMERF = "";

        /// <summary>入金金額3</summary>
        private Int64 _dEPT03_DEPOSITRF;

        /// <summary>入金金種名称4</summary>
        private string _dEPT04_MONEYKINDNAMERF = "";

        /// <summary>入金金額4</summary>
        private Int64 _dEPT04_DEPOSITRF;

        /// <summary>入金金種名称5</summary>
        private string _dEPT05_MONEYKINDNAMERF = "";

        /// <summary>入金金額5</summary>
        private Int64 _dEPT05_DEPOSITRF;

        /// <summary>入金金種名称6</summary>
        private string _dEPT06_MONEYKINDNAMERF = "";

        /// <summary>入金金額6</summary>
        private Int64 _dEPT06_DEPOSITRF;

        /// <summary>入金金種名称7</summary>
        private string _dEPT07_MONEYKINDNAMERF = "";

        /// <summary>入金金額7</summary>
        private Int64 _dEPT07_DEPOSITRF;

        /// <summary>入金金種名称8</summary>
        private string _dEPT08_MONEYKINDNAMERF = "";

        /// <summary>入金金額8</summary>
        private Int64 _dEPT08_DEPOSITRF;

        /// <summary>入金金種名称9</summary>
        private string _dEPT09_MONEYKINDNAMERF = "";

        /// <summary>入金金額9</summary>
        private Int64 _dEPT09_DEPOSITRF;

        /// <summary>入金金種名称10</summary>
        private string _dEPT10_MONEYKINDNAMERF = "";

        /// <summary>入金金額10</summary>
        private Int64 _dEPT10_DEPOSITRF;

        /// <summary>計上年月日西暦年</summary>
        private Int32 _hADD_ADDUPDATEFYRF;

        /// <summary>計上年月日西暦年略</summary>
        private Int32 _hADD_ADDUPDATEFSRF;

        /// <summary>計上年月日和暦年</summary>
        private Int32 _hADD_ADDUPDATEFWRF;

        /// <summary>計上年月日月</summary>
        private Int32 _hADD_ADDUPDATEFMRF;

        /// <summary>計上年月日日</summary>
        private Int32 _hADD_ADDUPDATEFDRF;

        /// <summary>計上年月日元号</summary>
        private string _hADD_ADDUPDATEFGRF = "";

        /// <summary>計上年月日略号</summary>
        private string _hADD_ADDUPDATEFRRF = "";

        /// <summary>計上年月日リテラル(/)</summary>
        private string _hADD_ADDUPDATEFLSRF = "";

        /// <summary>計上年月日リテラル(.)</summary>
        private string _hADD_ADDUPDATEFLPRF = "";

        /// <summary>計上年月日リテラル(年)</summary>
        private string _hADD_ADDUPDATEFLYRF = "";

        /// <summary>計上年月日リテラル(月)</summary>
        private string _hADD_ADDUPDATEFLMRF = "";

        /// <summary>計上年月日リテラル(日)</summary>
        private string _hADD_ADDUPDATEFLDRF = "";

        /// <summary>計上年月西暦年</summary>
        private Int32 _hADD_ADDUPYEARMONTHFYRF;

        /// <summary>計上年月西暦年略</summary>
        private Int32 _hADD_ADDUPYEARMONTHFSRF;

        /// <summary>計上年月和暦年</summary>
        private Int32 _hADD_ADDUPYEARMONTHFWRF;

        /// <summary>計上年月月</summary>
        private Int32 _hADD_ADDUPYEARMONTHFMRF;

        /// <summary>計上年月元号</summary>
        private string _hADD_ADDUPYEARMONTHFGRF = "";

        /// <summary>計上年月略号</summary>
        private string _hADD_ADDUPYEARMONTHFRRF = "";

        /// <summary>計上年月リテラル(/)</summary>
        private string _hADD_ADDUPYEARMONTHFLSRF = "";

        /// <summary>計上年月リテラル(.)</summary>
        private string _hADD_ADDUPYEARMONTHFLPRF = "";

        /// <summary>計上年月リテラル(年)</summary>
        private string _hADD_ADDUPYEARMONTHFLYRF = "";

        /// <summary>計上年月リテラル(月)</summary>
        private string _hADD_ADDUPYEARMONTHFLMRF = "";

        /// <summary>締次更新開始年月日西暦年</summary>
        private Int32 _hADD_STARTCADDUPUPDDATEFYRF;

        /// <summary>締次更新開始年月日西暦年略</summary>
        private Int32 _hADD_STARTCADDUPUPDDATEFSRF;

        /// <summary>締次更新開始年月日和暦年</summary>
        private Int32 _hADD_STARTCADDUPUPDDATEFWRF;

        /// <summary>締次更新開始年月日月</summary>
        private Int32 _hADD_STARTCADDUPUPDDATEFMRF;

        /// <summary>締次更新開始年月日日</summary>
        private Int32 _hADD_STARTCADDUPUPDDATEFDRF;

        /// <summary>締次更新開始年月日元号</summary>
        private string _hADD_STARTCADDUPUPDDATEFGRF = "";

        /// <summary>締次更新開始年月日略号</summary>
        private string _hADD_STARTCADDUPUPDDATEFRRF = "";

        /// <summary>締次更新開始年月日リテラル(/)</summary>
        private string _hADD_STARTCADDUPUPDDATEFLSRF = "";

        /// <summary>締次更新開始年月日リテラル(.)</summary>
        private string _hADD_STARTCADDUPUPDDATEFLPRF = "";

        /// <summary>締次更新開始年月日リテラル(年)</summary>
        private string _hADD_STARTCADDUPUPDDATEFLYRF = "";

        /// <summary>締次更新開始年月日リテラル(月)</summary>
        private string _hADD_STARTCADDUPUPDDATEFLMRF = "";

        /// <summary>締次更新開始年月日リテラル(日)</summary>
        private string _hADD_STARTCADDUPUPDDATEFLDRF = "";

        /// <summary>請求書発行日西暦年</summary>
        private Int32 _hADD_BILLPRINTDATEFYRF;

        /// <summary>請求書発行日西暦年略</summary>
        private Int32 _hADD_BILLPRINTDATEFSRF;

        /// <summary>請求書発行日和暦年</summary>
        private Int32 _hADD_BILLPRINTDATEFWRF;

        /// <summary>請求書発行日月</summary>
        private Int32 _hADD_BILLPRINTDATEFMRF;

        /// <summary>請求書発行日日</summary>
        private Int32 _hADD_BILLPRINTDATEFDRF;

        /// <summary>請求書発行日元号</summary>
        private string _hADD_BILLPRINTDATEFGRF = "";

        /// <summary>請求書発行日略号</summary>
        private string _hADD_BILLPRINTDATEFRRF = "";

        /// <summary>請求書発行日リテラル(/)</summary>
        private string _hADD_BILLPRINTDATEFLSRF = "";

        /// <summary>請求書発行日リテラル(.)</summary>
        private string _hADD_BILLPRINTDATEFLPRF = "";

        /// <summary>請求書発行日リテラル(年)</summary>
        private string _hADD_BILLPRINTDATEFLYRF = "";

        /// <summary>請求書発行日リテラル(月)</summary>
        private string _hADD_BILLPRINTDATEFLMRF = "";

        /// <summary>請求書発行日リテラル(日)</summary>
        private string _hADD_BILLPRINTDATEFLDRF = "";

        /// <summary>入金予定日西暦年</summary>
        private Int32 _hADD_EXPECTEDDEPOSITDATEFYRF;

        /// <summary>入金予定日西暦年略</summary>
        private Int32 _hADD_EXPECTEDDEPOSITDATEFSRF;

        /// <summary>入金予定日和暦年</summary>
        private Int32 _hADD_EXPECTEDDEPOSITDATEFWRF;

        /// <summary>入金予定日月</summary>
        private Int32 _hADD_EXPECTEDDEPOSITDATEFMRF;

        /// <summary>入金予定日日</summary>
        private Int32 _hADD_EXPECTEDDEPOSITDATEFDRF;

        /// <summary>入金予定日元号</summary>
        private string _hADD_EXPECTEDDEPOSITDATEFGRF = "";

        /// <summary>入金予定日略号</summary>
        private string _hADD_EXPECTEDDEPOSITDATEFRRF = "";

        /// <summary>入金予定日リテラル(/)</summary>
        private string _hADD_EXPECTEDDEPOSITDATEFLSRF = "";

        /// <summary>入金予定日リテラル(.)</summary>
        private string _hADD_EXPECTEDDEPOSITDATEFLPRF = "";

        /// <summary>入金予定日リテラル(年)</summary>
        private string _hADD_EXPECTEDDEPOSITDATEFLYRF = "";

        /// <summary>入金予定日リテラル(月)</summary>
        private string _hADD_EXPECTEDDEPOSITDATEFLMRF = "";

        /// <summary>入金予定日リテラル(日)</summary>
        private string _hADD_EXPECTEDDEPOSITDATEFLDRF = "";

        /// <summary>回収条件名称</summary>
        /// <remarks>10:現金,20:振込,30:小切手,40:手形,50:手数料,60:相殺,70:値引,80:その他</remarks>
        private string _hADD_COLLECTCONDNMRF = "";

        /// <summary>請求書タイトル</summary>
        private string _hADD_DMDFORMTITLERF = "";

        /// <summary>請求書タイトル２</summary>
        /// <remarks>控え</remarks>
        private string _hADD_DMDFORMTITLE2RF = "";

        /// <summary>請求書コメント１</summary>
        private string _hADD_DMDFORMCOMENT1RF = "";

        /// <summary>請求書コメント２</summary>
        private string _hADD_DMDFORMCOMENT2RF = "";

        /// <summary>請求書コメント３</summary>
        private string _hADD_DMDFORMCOMENT3RF = "";

        /// <summary>入金金額(値引除く)</summary>
        /// <remarks>算出値：今回入金金額（通常入金）－今回値引額（通常入金）</remarks>
        private Int64 _hADD_DMDNRMLEXDISRF;

        /// <summary>入金金額(手数料除く)</summary>
        /// <remarks>算出値：今回入金金額（通常入金）－今回手数料額（通常入金）</remarks>
        private Int64 _hADD_DMDNRMLEXFEERF;

        /// <summary>入金金額(値引・手数料除く)</summary>
        /// <remarks>算出値：今回入金金額（通常入金）－今回値引額（通常入金）－今回手数料額（通常入金）</remarks>
        private Int64 _hADD_DMDNRMLEXDISFEERF;

        /// <summary>入金金額(値引＋手数料)</summary>
        /// <remarks>算出値：今回値引額（通常入金）＋今回手数料額（通常入金）</remarks>
        private Int64 _hADD_DMDNRMLSAMDISFEERF;

        /// <summary>今回売上額(税抜)</summary>
        /// <remarks>算出値：今回売上額(税抜)＋残高調整額</remarks>
        private Int64 _hADD_THISSALESANDADJUSTRF;

        /// <summary>今回売上消費税</summary>
        /// <remarks>算出値：今回売上消費税＋消費税調整額</remarks>
        private Int64 _hADD_THISTAXANDADJUSTRF;

        /// <summary>入力発行日付</summary>
        private Int32 _hADD_ISSUEDAYRF;

        /// <summary>入力発行日付西暦年</summary>
        private Int32 _hADD_ISSUEDAYFYRF;

        /// <summary>入力発行日付西暦年略</summary>
        private Int32 _hADD_ISSUEDAYFSRF;

        /// <summary>入力発行日付和暦年</summary>
        private Int32 _hADD_ISSUEDAYFWRF;

        /// <summary>入力発行日付月</summary>
        private Int32 _hADD_ISSUEDAYFMRF;

        /// <summary>入力発行日付日</summary>
        private Int32 _hADD_ISSUEDAYFDRF;

        /// <summary>入力発行日付元号</summary>
        private string _hADD_ISSUEDAYFGRF = "";

        /// <summary>入力発行日付略号</summary>
        private string _hADD_ISSUEDAYFRRF = "";

        /// <summary>入力発行日付リテラル(/)</summary>
        private string _hADD_ISSUEDAYFLSRF = "";

        /// <summary>入力発行日付リテラル(.)</summary>
        private string _hADD_ISSUEDAYFLPRF = "";

        /// <summary>入力発行日付リテラル(年)</summary>
        private string _hADD_ISSUEDAYFLYRF = "";

        /// <summary>入力発行日付リテラル(月)</summary>
        private string _hADD_ISSUEDAYFLMRF = "";

        /// <summary>入力発行日付リテラル(日)</summary>
        private string _hADD_ISSUEDAYFLDRF = "";

        /// <summary>印刷得意先サブコード</summary>
        private string _cADD_CUSTOMERSUBCODERF = "";

        /// <summary>印刷得意先名称</summary>
        /// <remarks>納入先の場合の使用可能項目</remarks>
        private string _cADD_NAMERF = "";

        /// <summary>印刷得意先名称2</summary>
        /// <remarks>納入先の場合の使用可能項目</remarks>
        private string _cADD_NAME2RF = "";

        /// <summary>印刷得意先敬称</summary>
        private string _cADD_HONORIFICTITLERF = "";

        /// <summary>印刷得意先カナ</summary>
        private string _cADD_KANARF = "";

        /// <summary>印刷得意先略称</summary>
        private string _cADD_CUSTOMERSNMRF = "";

        /// <summary>印刷得意先諸口コード</summary>
        /// <remarks>0:顧客名称1と2,1:顧客名称1,2:顧客名称2,3:諸口名称</remarks>
        private Int32 _cADD_OUTPUTNAMECODERF;

        /// <summary>印刷得意先郵便番号</summary>
        /// <remarks>納入先の場合の使用可能項目</remarks>
        private string _cADD_POSTNORF = "";

        /// <summary>印刷得意先住所1（都道府県市区郡・町村・字）</summary>
        /// <remarks>納入先の場合の使用可能項目</remarks>
        private string _cADD_ADDRESS1RF = "";

        /// <summary>印刷得意先住所3（番地）</summary>
        /// <remarks>納入先の場合の使用可能項目</remarks>
        private string _cADD_ADDRESS3RF = "";

        /// <summary>印刷得意先住所4（アパート名称）</summary>
        /// <remarks>納入先の場合の使用可能項目</remarks>
        private string _cADD_ADDRESS4RF = "";

        /// <summary>印刷得意先分析コード1</summary>
        private Int32 _cADD_CUSTANALYSCODE1RF;

        /// <summary>印刷得意先分析コード2</summary>
        private Int32 _cADD_CUSTANALYSCODE2RF;

        /// <summary>印刷得意先分析コード3</summary>
        private Int32 _cADD_CUSTANALYSCODE3RF;

        /// <summary>印刷得意先分析コード4</summary>
        private Int32 _cADD_CUSTANALYSCODE4RF;

        /// <summary>印刷得意先分析コード5</summary>
        private Int32 _cADD_CUSTANALYSCODE5RF;

        /// <summary>印刷得意先分析コード6</summary>
        private Int32 _cADD_CUSTANALYSCODE6RF;

        /// <summary>印刷得意先備考1</summary>
        private string _cADD_NOTE1RF = "";

        /// <summary>印刷得意先備考2</summary>
        private string _cADD_NOTE2RF = "";

        /// <summary>印刷得意先備考3</summary>
        private string _cADD_NOTE3RF = "";

        /// <summary>印刷得意先備考4</summary>
        private string _cADD_NOTE4RF = "";

        /// <summary>印刷得意先備考5</summary>
        private string _cADD_NOTE5RF = "";

        /// <summary>印刷得意先備考6</summary>
        private string _cADD_NOTE6RF = "";

        /// <summary>印刷得意先備考7</summary>
        private string _cADD_NOTE7RF = "";

        /// <summary>印刷得意先備考8</summary>
        private string _cADD_NOTE8RF = "";

        /// <summary>印刷得意先備考9</summary>
        private string _cADD_NOTE9RF = "";

        /// <summary>印刷得意先備考10</summary>
        private string _cADD_NOTE10RF = "";

        /// <summary>印刷用得意先名称（上段）</summary>
        private string _cADD_PRINTCUSTOMERNAME1RF = "";

        /// <summary>印刷用得意先名称（下段）</summary>
        private string _cADD_PRINTCUSTOMERNAME2RF = "";

        /// <summary>印刷用得意先名称（下段）＋敬称</summary>
        private string _cADD_PRINTCUSTOMERNAME2HNRF = "";

        /// <summary>集金月区分名称</summary>
        /// <remarks>当月,翌月,翌々月</remarks>
        private string _cSTCST_COLLECTMONEYNAMERF = "";

        /// <summary>集金日</summary>
        /// <remarks>DD</remarks>
        private Int32 _cSTCST_COLLECTMONEYDAYRF;

        /// <summary>印刷得意先コード</summary>
        private Int32 _cADD_CUSTOMERCODERF;

        /// <summary>印刷得意先電話番号（自宅）</summary>
        private string _cADD_HOMETELNORF = "";

        /// <summary>印刷得意先電話番号（勤務先）</summary>
        /// <remarks>納入先の場合の使用可能項目</remarks>
        private string _cADD_OFFICETELNORF = "";

        /// <summary>印刷得意先電話番号（携帯）</summary>
        private string _cADD_PORTABLETELNORF = "";

        /// <summary>印刷得意先FAX番号（自宅）</summary>
        private string _cADD_HOMEFAXNORF = "";

        /// <summary>印刷得意先FAX番号（勤務先）</summary>
        /// <remarks>納入先の場合の使用可能項目</remarks>
        private string _cADD_OFFICEFAXNORF = "";

        /// <summary>印刷得意先電話番号（その他）</summary>
        private string _cADD_OTHERSTELNORF = "";

        /// <summary>得意先電話番号（自宅）</summary>
        private string _cSTCST_HOMETELNORF = "";

        /// <summary>得意先電話番号（勤務先）</summary>
        /// <remarks>納入先の場合の使用可能項目</remarks>
        private string _cSTCST_OFFICETELNORF = "";

        /// <summary>得意先電話番号（携帯）</summary>
        private string _cSTCST_PORTABLETELNORF = "";

        /// <summary>得意先FAX番号（自宅）</summary>
        private string _cSTCST_HOMEFAXNORF = "";

        /// <summary>得意先FAX番号（勤務先）</summary>
        /// <remarks>納入先の場合の使用可能項目</remarks>
        private string _cSTCST_OFFICEFAXNORF = "";

        /// <summary>得意先電話番号（その他）</summary>
        private string _cSTCST_OTHERSTELNORF = "";

        /// <summary>請求先電話番号（自宅）</summary>
        private string _cSTCLM_HOMETELNORF = "";

        /// <summary>請求先電話番号（勤務先）</summary>
        /// <remarks>納入先の場合の使用可能項目</remarks>
        private string _cSTCLM_OFFICETELNORF = "";

        /// <summary>請求先電話番号（携帯）</summary>
        private string _cSTCLM_PORTABLETELNORF = "";

        /// <summary>請求先FAX番号（自宅）</summary>
        private string _cSTCLM_HOMEFAXNORF = "";

        /// <summary>請求先FAX番号（勤務先）</summary>
        /// <remarks>納入先の場合の使用可能項目</remarks>
        private string _cSTCLM_OFFICEFAXNORF = "";

        /// <summary>請求先電話番号（その他）</summary>
        private string _cSTCLM_OTHERSTELNORF = "";

        /// <summary>今回売上額(税込)</summary>
        /// <remarks>算出値：今回売上額(税抜)＋残高調整額＋今回売上消費税＋消費税調整額</remarks>
        private Int64 _hADD_THISSALESANDADJUSTTAXINCRF;

        /// <summary>請求先集金月区分名称</summary>
        /// <remarks>当月,翌月,翌々月</remarks>
        private string _cSTCLM_COLLECTMONEYNAMERF = "";

        /// <summary>請求先集金日</summary>
        /// <remarks>DD</remarks>
        private Int32 _cSTCLM_COLLECTMONEYDAYRF;

        /// <summary>実績拠点コード</summary>
        /// <remarks>実績集計の対象となっている拠点コード</remarks>
        private string _cUSTDMDPRCRF_RESULTSSECTCDRF = "";

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

        /// <summary>自宅TEL表示名称</summary>
        private string _aLITMDSPNMRF_HOMETELNODSPNAMERF = "";

        /// <summary>勤務先TEL表示名称</summary>
        private string _aLITMDSPNMRF_OFFICETELNODSPNAMERF = "";

        /// <summary>携帯TEL表示名称</summary>
        private string _aLITMDSPNMRF_MOBILETELNODSPNAMERF = "";

        /// <summary>自宅FAX表示名称</summary>
        private string _aLITMDSPNMRF_HOMEFAXNODSPNAMERF = "";

        /// <summary>勤務先FAX表示名称</summary>
        private string _aLITMDSPNMRF_OFFICEFAXNODSPNAMERF = "";

        /// <summary>その他TEL表示名称</summary>
        private string _aLITMDSPNMRF_OTHERTELNODSPNAMERF = "";

        /// <summary>販売エリアコード</summary>
        private Int32 _cSTCLM_SALESAREACODERF;

        /// <summary>顧客担当従業員コード</summary>
        /// <remarks>文字型</remarks>
        private string _cSTCLM_CUSTOMERAGENTCDRF = "";

        /// <summary>集金担当従業員コード</summary>
        private string _cSTCLM_BILLCOLLECTERCDRF = "";

        /// <summary>旧顧客担当従業員コード</summary>
        private string _cSTCLM_OLDCUSTOMERAGENTCDRF = "";

        /// <summary>顧客担当変更日</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _cSTCLM_CUSTAGENTCHGDATERF;

        /// <summary>請求書番号</summary>
        private Int32 _cUSTDMDPRCRF_BILLNORF;

        /// <summary>集金月区分コード</summary>
        private Int32 _cSTCST_COLLECTMONEYCODERF;

        /// <summary>請求先集金月区分コード</summary>
        private Int32 _cSTCLM_COLLECTMONEYCODERF;

        /// <summary>締日</summary>
        private Int32 _cSTCLM_TOTALDAYRF;

        /// <summary>税率1タイトル</summary>
        /// <remarks>税率1タイトル</remarks>
        private Int32 _titleTaxRate1;

        /// <summary>税率2タイトル</summary>
        /// <remarks>税率2タイトル</remarks>
        private Int32 _titleTaxRate2;

        /// <summary>税率(1)対象金額合計(税抜き)</summary>
        /// <remarks>税率(1)対象金額合計(税抜き)</remarks>
        private double _totalThisTimeSalesTaxExRate1;

        /// <summary>税率(2)対象金額合計(税抜き)</summary>
        /// <remarks>税率(2)対象金額合計(税抜き)</remarks>
        private double _totalThisTimeSalesTaxExRate2;

        /// <summary>税額(1)</summary>
        /// <remarks>税額(1)</remarks>
        private double _totalThisTimeTaxRate1;

        /// <summary>税額(2)</summary>
        /// <remarks>税額(2)</remarks>
        private double _totalThisTimeTaxRate2;


        /// public propaty name  :  CUSTDMDPRCRF_ADDUPSECCODERF
        /// <summary>計上拠点コードプロパティ</summary>
        /// <value>集計の対象となっている拠点コード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   計上拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CUSTDMDPRCRF_ADDUPSECCODERF
        {
            get { return _cUSTDMDPRCRF_ADDUPSECCODERF; }
            set { _cUSTDMDPRCRF_ADDUPSECCODERF = value; }
        }

        /// public propaty name  :  CUSTDMDPRCRF_CLAIMCODERF
        /// <summary>請求先コードプロパティ</summary>
        /// <value>請求先親コード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   請求先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CUSTDMDPRCRF_CLAIMCODERF
        {
            get { return _cUSTDMDPRCRF_CLAIMCODERF; }
            set { _cUSTDMDPRCRF_CLAIMCODERF = value; }
        }

        /// public propaty name  :  CUSTDMDPRCRF_CLAIMNAMERF
        /// <summary>請求先名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   請求先名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CUSTDMDPRCRF_CLAIMNAMERF
        {
            get { return _cUSTDMDPRCRF_CLAIMNAMERF; }
            set { _cUSTDMDPRCRF_CLAIMNAMERF = value; }
        }

        /// public propaty name  :  CUSTDMDPRCRF_CLAIMNAME2RF
        /// <summary>請求先名称2プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   請求先名称2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CUSTDMDPRCRF_CLAIMNAME2RF
        {
            get { return _cUSTDMDPRCRF_CLAIMNAME2RF; }
            set { _cUSTDMDPRCRF_CLAIMNAME2RF = value; }
        }

        /// public propaty name  :  CUSTDMDPRCRF_CLAIMSNMRF
        /// <summary>請求先略称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   請求先略称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CUSTDMDPRCRF_CLAIMSNMRF
        {
            get { return _cUSTDMDPRCRF_CLAIMSNMRF; }
            set { _cUSTDMDPRCRF_CLAIMSNMRF = value; }
        }

        /// public propaty name  :  CUSTDMDPRCRF_CUSTOMERCODERF
        /// <summary>得意先コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CUSTDMDPRCRF_CUSTOMERCODERF
        {
            get { return _cUSTDMDPRCRF_CUSTOMERCODERF; }
            set { _cUSTDMDPRCRF_CUSTOMERCODERF = value; }
        }

        /// public propaty name  :  CUSTDMDPRCRF_CUSTOMERNAMERF
        /// <summary>得意先名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CUSTDMDPRCRF_CUSTOMERNAMERF
        {
            get { return _cUSTDMDPRCRF_CUSTOMERNAMERF; }
            set { _cUSTDMDPRCRF_CUSTOMERNAMERF = value; }
        }

        /// public propaty name  :  CUSTDMDPRCRF_CUSTOMERNAME2RF
        /// <summary>得意先名称2プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先名称2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CUSTDMDPRCRF_CUSTOMERNAME2RF
        {
            get { return _cUSTDMDPRCRF_CUSTOMERNAME2RF; }
            set { _cUSTDMDPRCRF_CUSTOMERNAME2RF = value; }
        }

        /// public propaty name  :  CUSTDMDPRCRF_CUSTOMERSNMRF
        /// <summary>得意先略称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先略称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CUSTDMDPRCRF_CUSTOMERSNMRF
        {
            get { return _cUSTDMDPRCRF_CUSTOMERSNMRF; }
            set { _cUSTDMDPRCRF_CUSTOMERSNMRF = value; }
        }

        /// public propaty name  :  CUSTDMDPRCRF_ADDUPDATERF
        /// <summary>計上年月日プロパティ</summary>
        /// <value>YYYYMMDD 請求締を行なった日（相手先基準）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   計上年月日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CUSTDMDPRCRF_ADDUPDATERF
        {
            get { return _cUSTDMDPRCRF_ADDUPDATERF; }
            set { _cUSTDMDPRCRF_ADDUPDATERF = value; }
        }

        /// public propaty name  :  CUSTDMDPRCRF_ADDUPYEARMONTHRF
        /// <summary>計上年月プロパティ</summary>
        /// <value>YYYYMM</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   計上年月プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CUSTDMDPRCRF_ADDUPYEARMONTHRF
        {
            get { return _cUSTDMDPRCRF_ADDUPYEARMONTHRF; }
            set { _cUSTDMDPRCRF_ADDUPYEARMONTHRF = value; }
        }

        /// public propaty name  :  CUSTDMDPRCRF_LASTTIMEDEMANDRF
        /// <summary>前回請求金額プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   前回請求金額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 CUSTDMDPRCRF_LASTTIMEDEMANDRF
        {
            get { return _cUSTDMDPRCRF_LASTTIMEDEMANDRF; }
            set { _cUSTDMDPRCRF_LASTTIMEDEMANDRF = value; }
        }

        /// public propaty name  :  CUSTDMDPRCRF_THISTIMEFEEDMDNRMLRF
        /// <summary>今回手数料額（通常入金）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   今回手数料額（通常入金）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 CUSTDMDPRCRF_THISTIMEFEEDMDNRMLRF
        {
            get { return _cUSTDMDPRCRF_THISTIMEFEEDMDNRMLRF; }
            set { _cUSTDMDPRCRF_THISTIMEFEEDMDNRMLRF = value; }
        }

        /// public propaty name  :  CUSTDMDPRCRF_THISTIMEDISDMDNRMLRF
        /// <summary>今回値引額（通常入金）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   今回値引額（通常入金）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 CUSTDMDPRCRF_THISTIMEDISDMDNRMLRF
        {
            get { return _cUSTDMDPRCRF_THISTIMEDISDMDNRMLRF; }
            set { _cUSTDMDPRCRF_THISTIMEDISDMDNRMLRF = value; }
        }

        /// public propaty name  :  CUSTDMDPRCRF_THISTIMEDMDNRMLRF
        /// <summary>今回入金金額（通常入金）プロパティ</summary>
        /// <value>入金額の合計金額</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   今回入金金額（通常入金）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 CUSTDMDPRCRF_THISTIMEDMDNRMLRF
        {
            get { return _cUSTDMDPRCRF_THISTIMEDMDNRMLRF; }
            set { _cUSTDMDPRCRF_THISTIMEDMDNRMLRF = value; }
        }

        /// public propaty name  :  CUSTDMDPRCRF_THISTIMETTLBLCDMDRF
        /// <summary>今回繰越残高（請求計）プロパティ</summary>
        /// <value>今回繰越残高＝前回請求額－今回入金額合計（通常）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   今回繰越残高（請求計）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 CUSTDMDPRCRF_THISTIMETTLBLCDMDRF
        {
            get { return _cUSTDMDPRCRF_THISTIMETTLBLCDMDRF; }
            set { _cUSTDMDPRCRF_THISTIMETTLBLCDMDRF = value; }
        }

        /// public propaty name  :  CUSTDMDPRCRF_OFSTHISTIMESALESRF
        /// <summary>相殺後今回売上金額プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   相殺後今回売上金額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 CUSTDMDPRCRF_OFSTHISTIMESALESRF
        {
            get { return _cUSTDMDPRCRF_OFSTHISTIMESALESRF; }
            set { _cUSTDMDPRCRF_OFSTHISTIMESALESRF = value; }
        }

        /// public propaty name  :  CUSTDMDPRCRF_OFSTHISSALESTAXRF
        /// <summary>相殺後今回売上消費税プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   相殺後今回売上消費税プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 CUSTDMDPRCRF_OFSTHISSALESTAXRF
        {
            get { return _cUSTDMDPRCRF_OFSTHISSALESTAXRF; }
            set { _cUSTDMDPRCRF_OFSTHISSALESTAXRF = value; }
        }

        /// public propaty name  :  CUSTDMDPRCRF_ITDEDOFFSETOUTTAXRF
        /// <summary>相殺後外税対象額プロパティ</summary>
        /// <value>相殺用：外税額（税抜き）の集計</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   相殺後外税対象額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 CUSTDMDPRCRF_ITDEDOFFSETOUTTAXRF
        {
            get { return _cUSTDMDPRCRF_ITDEDOFFSETOUTTAXRF; }
            set { _cUSTDMDPRCRF_ITDEDOFFSETOUTTAXRF = value; }
        }

        /// public propaty name  :  CUSTDMDPRCRF_ITDEDOFFSETINTAXRF
        /// <summary>相殺後内税対象額プロパティ</summary>
        /// <value>相殺用：内税額（税抜き）の集計</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   相殺後内税対象額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 CUSTDMDPRCRF_ITDEDOFFSETINTAXRF
        {
            get { return _cUSTDMDPRCRF_ITDEDOFFSETINTAXRF; }
            set { _cUSTDMDPRCRF_ITDEDOFFSETINTAXRF = value; }
        }

        /// public propaty name  :  CUSTDMDPRCRF_ITDEDOFFSETTAXFREERF
        /// <summary>相殺後非課税対象額プロパティ</summary>
        /// <value>相殺用：非課税額の集計</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   相殺後非課税対象額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 CUSTDMDPRCRF_ITDEDOFFSETTAXFREERF
        {
            get { return _cUSTDMDPRCRF_ITDEDOFFSETTAXFREERF; }
            set { _cUSTDMDPRCRF_ITDEDOFFSETTAXFREERF = value; }
        }

        /// public propaty name  :  CUSTDMDPRCRF_OFFSETOUTTAXRF
        /// <summary>相殺後外税消費税プロパティ</summary>
        /// <value>相殺用：外税消費税の集計　（請求転嫁時は、課税対象額から算出）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   相殺後外税消費税プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 CUSTDMDPRCRF_OFFSETOUTTAXRF
        {
            get { return _cUSTDMDPRCRF_OFFSETOUTTAXRF; }
            set { _cUSTDMDPRCRF_OFFSETOUTTAXRF = value; }
        }

        /// public propaty name  :  CUSTDMDPRCRF_OFFSETINTAXRF
        /// <summary>相殺後内税消費税プロパティ</summary>
        /// <value>相殺用：内税消費税の集計</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   相殺後内税消費税プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 CUSTDMDPRCRF_OFFSETINTAXRF
        {
            get { return _cUSTDMDPRCRF_OFFSETINTAXRF; }
            set { _cUSTDMDPRCRF_OFFSETINTAXRF = value; }
        }

        /// public propaty name  :  CUSTDMDPRCRF_THISTIMESALESRF
        /// <summary>今回売上金額プロパティ</summary>
        /// <value>掛売：値引、返品を含まない税抜きの売上金額</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   今回売上金額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 CUSTDMDPRCRF_THISTIMESALESRF
        {
            get { return _cUSTDMDPRCRF_THISTIMESALESRF; }
            set { _cUSTDMDPRCRF_THISTIMESALESRF = value; }
        }

        /// public propaty name  :  CUSTDMDPRCRF_THISSALESTAXRF
        /// <summary>今回売上消費税プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   今回売上消費税プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 CUSTDMDPRCRF_THISSALESTAXRF
        {
            get { return _cUSTDMDPRCRF_THISSALESTAXRF; }
            set { _cUSTDMDPRCRF_THISSALESTAXRF = value; }
        }

        /// public propaty name  :  CUSTDMDPRCRF_ITDEDSALESOUTTAXRF
        /// <summary>売上外税対象額プロパティ</summary>
        /// <value>請求用：外税額（税抜き）の集計</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上外税対象額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 CUSTDMDPRCRF_ITDEDSALESOUTTAXRF
        {
            get { return _cUSTDMDPRCRF_ITDEDSALESOUTTAXRF; }
            set { _cUSTDMDPRCRF_ITDEDSALESOUTTAXRF = value; }
        }

        /// public propaty name  :  CUSTDMDPRCRF_ITDEDSALESINTAXRF
        /// <summary>売上内税対象額プロパティ</summary>
        /// <value>請求用：内税額（税抜き）の集計</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上内税対象額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 CUSTDMDPRCRF_ITDEDSALESINTAXRF
        {
            get { return _cUSTDMDPRCRF_ITDEDSALESINTAXRF; }
            set { _cUSTDMDPRCRF_ITDEDSALESINTAXRF = value; }
        }

        /// public propaty name  :  CUSTDMDPRCRF_ITDEDSALESTAXFREERF
        /// <summary>売上非課税対象額プロパティ</summary>
        /// <value>請求用：非課税額の集計</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上非課税対象額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 CUSTDMDPRCRF_ITDEDSALESTAXFREERF
        {
            get { return _cUSTDMDPRCRF_ITDEDSALESTAXFREERF; }
            set { _cUSTDMDPRCRF_ITDEDSALESTAXFREERF = value; }
        }

        /// public propaty name  :  CUSTDMDPRCRF_SALESOUTTAXRF
        /// <summary>売上外税額プロパティ</summary>
        /// <value>請求用：外税消費税の集計　（請求転嫁時は、課税対象額から算出）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上外税額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 CUSTDMDPRCRF_SALESOUTTAXRF
        {
            get { return _cUSTDMDPRCRF_SALESOUTTAXRF; }
            set { _cUSTDMDPRCRF_SALESOUTTAXRF = value; }
        }

        /// public propaty name  :  CUSTDMDPRCRF_SALESINTAXRF
        /// <summary>売上内税額プロパティ</summary>
        /// <value>掛売：内税商品売上の内税消費税額（返品、値引含まず）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上内税額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 CUSTDMDPRCRF_SALESINTAXRF
        {
            get { return _cUSTDMDPRCRF_SALESINTAXRF; }
            set { _cUSTDMDPRCRF_SALESINTAXRF = value; }
        }

        /// public propaty name  :  CUSTDMDPRCRF_THISSALESPRICRGDSRF
        /// <summary>今回売上返品金額プロパティ</summary>
        /// <value>掛売：値引を含まない税抜きの売上返品金額</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   今回売上返品金額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 CUSTDMDPRCRF_THISSALESPRICRGDSRF
        {
            get { return _cUSTDMDPRCRF_THISSALESPRICRGDSRF; }
            set { _cUSTDMDPRCRF_THISSALESPRICRGDSRF = value; }
        }

        /// public propaty name  :  CUSTDMDPRCRF_THISSALESPRCTAXRGDSRF
        /// <summary>今回売上返品消費税プロパティ</summary>
        /// <value>今回売上返品消費税＝返品外税額合計＋返品内税額合計</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   今回売上返品消費税プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 CUSTDMDPRCRF_THISSALESPRCTAXRGDSRF
        {
            get { return _cUSTDMDPRCRF_THISSALESPRCTAXRGDSRF; }
            set { _cUSTDMDPRCRF_THISSALESPRCTAXRGDSRF = value; }
        }

        /// public propaty name  :  CUSTDMDPRCRF_TTLITDEDRETOUTTAXRF
        /// <summary>返品外税対象額合計プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   返品外税対象額合計プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 CUSTDMDPRCRF_TTLITDEDRETOUTTAXRF
        {
            get { return _cUSTDMDPRCRF_TTLITDEDRETOUTTAXRF; }
            set { _cUSTDMDPRCRF_TTLITDEDRETOUTTAXRF = value; }
        }

        /// public propaty name  :  CUSTDMDPRCRF_TTLITDEDRETINTAXRF
        /// <summary>返品内税対象額合計プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   返品内税対象額合計プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 CUSTDMDPRCRF_TTLITDEDRETINTAXRF
        {
            get { return _cUSTDMDPRCRF_TTLITDEDRETINTAXRF; }
            set { _cUSTDMDPRCRF_TTLITDEDRETINTAXRF = value; }
        }

        /// public propaty name  :  CUSTDMDPRCRF_TTLITDEDRETTAXFREERF
        /// <summary>返品非課税対象額合計プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   返品非課税対象額合計プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 CUSTDMDPRCRF_TTLITDEDRETTAXFREERF
        {
            get { return _cUSTDMDPRCRF_TTLITDEDRETTAXFREERF; }
            set { _cUSTDMDPRCRF_TTLITDEDRETTAXFREERF = value; }
        }

        /// public propaty name  :  CUSTDMDPRCRF_TTLRETOUTERTAXRF
        /// <summary>返品外税額合計プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   返品外税額合計プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 CUSTDMDPRCRF_TTLRETOUTERTAXRF
        {
            get { return _cUSTDMDPRCRF_TTLRETOUTERTAXRF; }
            set { _cUSTDMDPRCRF_TTLRETOUTERTAXRF = value; }
        }

        /// public propaty name  :  CUSTDMDPRCRF_TTLRETINNERTAXRF
        /// <summary>返品内税額合計プロパティ</summary>
        /// <value>掛売：内税商品返品の内税消費税額（値引含まず）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   返品内税額合計プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 CUSTDMDPRCRF_TTLRETINNERTAXRF
        {
            get { return _cUSTDMDPRCRF_TTLRETINNERTAXRF; }
            set { _cUSTDMDPRCRF_TTLRETINNERTAXRF = value; }
        }

        /// public propaty name  :  CUSTDMDPRCRF_THISSALESPRICDISRF
        /// <summary>今回売上値引金額プロパティ</summary>
        /// <value>掛売：税抜きの売上値引金額</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   今回売上値引金額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 CUSTDMDPRCRF_THISSALESPRICDISRF
        {
            get { return _cUSTDMDPRCRF_THISSALESPRICDISRF; }
            set { _cUSTDMDPRCRF_THISSALESPRICDISRF = value; }
        }

        /// public propaty name  :  CUSTDMDPRCRF_THISSALESPRCTAXDISRF
        /// <summary>今回売上値引消費税プロパティ</summary>
        /// <value>今回売上値引消費税＝値引外税額合計＋値引内税額合計</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   今回売上値引消費税プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 CUSTDMDPRCRF_THISSALESPRCTAXDISRF
        {
            get { return _cUSTDMDPRCRF_THISSALESPRCTAXDISRF; }
            set { _cUSTDMDPRCRF_THISSALESPRCTAXDISRF = value; }
        }

        /// public propaty name  :  CUSTDMDPRCRF_TTLITDEDDISOUTTAXRF
        /// <summary>値引外税対象額合計プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   値引外税対象額合計プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 CUSTDMDPRCRF_TTLITDEDDISOUTTAXRF
        {
            get { return _cUSTDMDPRCRF_TTLITDEDDISOUTTAXRF; }
            set { _cUSTDMDPRCRF_TTLITDEDDISOUTTAXRF = value; }
        }

        /// public propaty name  :  CUSTDMDPRCRF_TTLITDEDDISINTAXRF
        /// <summary>値引内税対象額合計プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   値引内税対象額合計プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 CUSTDMDPRCRF_TTLITDEDDISINTAXRF
        {
            get { return _cUSTDMDPRCRF_TTLITDEDDISINTAXRF; }
            set { _cUSTDMDPRCRF_TTLITDEDDISINTAXRF = value; }
        }

        /// public propaty name  :  CUSTDMDPRCRF_TTLITDEDDISTAXFREERF
        /// <summary>値引非課税対象額合計プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   値引非課税対象額合計プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 CUSTDMDPRCRF_TTLITDEDDISTAXFREERF
        {
            get { return _cUSTDMDPRCRF_TTLITDEDDISTAXFREERF; }
            set { _cUSTDMDPRCRF_TTLITDEDDISTAXFREERF = value; }
        }

        /// public propaty name  :  CUSTDMDPRCRF_TTLDISOUTERTAXRF
        /// <summary>値引外税額合計プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   値引外税額合計プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 CUSTDMDPRCRF_TTLDISOUTERTAXRF
        {
            get { return _cUSTDMDPRCRF_TTLDISOUTERTAXRF; }
            set { _cUSTDMDPRCRF_TTLDISOUTERTAXRF = value; }
        }

        /// public propaty name  :  CUSTDMDPRCRF_TTLDISINNERTAXRF
        /// <summary>値引内税額合計プロパティ</summary>
        /// <value>掛売：内税商品返品の内税消費税額</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   値引内税額合計プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 CUSTDMDPRCRF_TTLDISINNERTAXRF
        {
            get { return _cUSTDMDPRCRF_TTLDISINNERTAXRF; }
            set { _cUSTDMDPRCRF_TTLDISINNERTAXRF = value; }
        }

        /// public propaty name  :  CUSTDMDPRCRF_TAXADJUSTRF
        /// <summary>消費税調整額プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   消費税調整額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 CUSTDMDPRCRF_TAXADJUSTRF
        {
            get { return _cUSTDMDPRCRF_TAXADJUSTRF; }
            set { _cUSTDMDPRCRF_TAXADJUSTRF = value; }
        }

        /// public propaty name  :  CUSTDMDPRCRF_BALANCEADJUSTRF
        /// <summary>残高調整額プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   残高調整額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 CUSTDMDPRCRF_BALANCEADJUSTRF
        {
            get { return _cUSTDMDPRCRF_BALANCEADJUSTRF; }
            set { _cUSTDMDPRCRF_BALANCEADJUSTRF = value; }
        }

        /// public propaty name  :  CUSTDMDPRCRF_AFCALDEMANDPRICERF
        /// <summary>計算後請求金額プロパティ</summary>
        /// <value>今回請求金額</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   計算後請求金額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 CUSTDMDPRCRF_AFCALDEMANDPRICERF
        {
            get { return _cUSTDMDPRCRF_AFCALDEMANDPRICERF; }
            set { _cUSTDMDPRCRF_AFCALDEMANDPRICERF = value; }
        }

        /// public propaty name  :  CUSTDMDPRCRF_ACPODRTTL2TMBFBLDMDRF
        /// <summary>受注2回前残高（請求計）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   受注2回前残高（請求計）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 CUSTDMDPRCRF_ACPODRTTL2TMBFBLDMDRF
        {
            get { return _cUSTDMDPRCRF_ACPODRTTL2TMBFBLDMDRF; }
            set { _cUSTDMDPRCRF_ACPODRTTL2TMBFBLDMDRF = value; }
        }

        /// public propaty name  :  CUSTDMDPRCRF_ACPODRTTL3TMBFBLDMDRF
        /// <summary>受注3回前残高（請求計）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   受注3回前残高（請求計）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 CUSTDMDPRCRF_ACPODRTTL3TMBFBLDMDRF
        {
            get { return _cUSTDMDPRCRF_ACPODRTTL3TMBFBLDMDRF; }
            set { _cUSTDMDPRCRF_ACPODRTTL3TMBFBLDMDRF = value; }
        }

        /// public propaty name  :  CUSTDMDPRCRF_STARTCADDUPUPDDATERF
        /// <summary>締次更新開始年月日プロパティ</summary>
        /// <value>"YYYYMMDD"  締次更新対象となる開始年月日</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   締次更新開始年月日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CUSTDMDPRCRF_STARTCADDUPUPDDATERF
        {
            get { return _cUSTDMDPRCRF_STARTCADDUPUPDDATERF; }
            set { _cUSTDMDPRCRF_STARTCADDUPUPDDATERF = value; }
        }

        /// public propaty name  :  CUSTDMDPRCRF_SALESSLIPCOUNTRF
        /// <summary>売上伝票枚数プロパティ</summary>
        /// <value>掛売の伝票枚数</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上伝票枚数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CUSTDMDPRCRF_SALESSLIPCOUNTRF
        {
            get { return _cUSTDMDPRCRF_SALESSLIPCOUNTRF; }
            set { _cUSTDMDPRCRF_SALESSLIPCOUNTRF = value; }
        }

        /// public propaty name  :  CUSTDMDPRCRF_BILLPRINTDATERF
        /// <summary>請求書発行日プロパティ</summary>
        /// <value>"YYYYMMDD"  請求書を発行した年月日</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   請求書発行日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CUSTDMDPRCRF_BILLPRINTDATERF
        {
            get { return _cUSTDMDPRCRF_BILLPRINTDATERF; }
            set { _cUSTDMDPRCRF_BILLPRINTDATERF = value; }
        }

        /// public propaty name  :  CUSTDMDPRCRF_EXPECTEDDEPOSITDATERF
        /// <summary>入金予定日プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金予定日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CUSTDMDPRCRF_EXPECTEDDEPOSITDATERF
        {
            get { return _cUSTDMDPRCRF_EXPECTEDDEPOSITDATERF; }
            set { _cUSTDMDPRCRF_EXPECTEDDEPOSITDATERF = value; }
        }

        /// public propaty name  :  CUSTDMDPRCRF_COLLECTCONDRF
        /// <summary>回収条件プロパティ</summary>
        /// <value>10:現金,20:振込,30:小切手,40:手形,50:手数料,60:相殺,70:値引,80:その他</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   回収条件プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CUSTDMDPRCRF_COLLECTCONDRF
        {
            get { return _cUSTDMDPRCRF_COLLECTCONDRF; }
            set { _cUSTDMDPRCRF_COLLECTCONDRF = value; }
        }

        /// public propaty name  :  CUSTDMDPRCRF_CONSTAXLAYMETHODRF
        /// <summary>消費税転嫁方式プロパティ</summary>
        /// <value>消費税転嫁区分設定マスタを参照 0:伝票単位1:明細単位2:請求時一括</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   消費税転嫁方式プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CUSTDMDPRCRF_CONSTAXLAYMETHODRF
        {
            get { return _cUSTDMDPRCRF_CONSTAXLAYMETHODRF; }
            set { _cUSTDMDPRCRF_CONSTAXLAYMETHODRF = value; }
        }

        /// public propaty name  :  CUSTDMDPRCRF_CONSTAXRATERF
        /// <summary>消費税率プロパティ</summary>
        /// <value>請求転嫁消費税を算出する場合に使用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   消費税率プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double CUSTDMDPRCRF_CONSTAXRATERF
        {
            get { return _cUSTDMDPRCRF_CONSTAXRATERF; }
            set { _cUSTDMDPRCRF_CONSTAXRATERF = value; }
        }

        /// public propaty name  :  SECHED_SECTIONGUIDENMRF
        /// <summary>拠点ガイド名称プロパティ</summary>
        /// <value>ＵＩ用（既存のコンボボックス等）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点ガイド名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SECHED_SECTIONGUIDENMRF
        {
            get { return _sECHED_SECTIONGUIDENMRF; }
            set { _sECHED_SECTIONGUIDENMRF = value; }
        }

        /// public propaty name  :  SECHED_SECTIONGUIDESNMRF
        /// <summary>拠点ガイド略称プロパティ</summary>
        /// <value>帳票印字用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点ガイド略称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SECHED_SECTIONGUIDESNMRF
        {
            get { return _sECHED_SECTIONGUIDESNMRF; }
            set { _sECHED_SECTIONGUIDESNMRF = value; }
        }

        /// public propaty name  :  SECHED_COMPANYNAMECD1RF
        /// <summary>自社名称コード1プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社名称コード1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SECHED_COMPANYNAMECD1RF
        {
            get { return _sECHED_COMPANYNAMECD1RF; }
            set { _sECHED_COMPANYNAMECD1RF = value; }
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
        /// <summary>画像情報データプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   画像情報データプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Byte[] IMAGEINFORF_IMAGEINFODATARF
        {
            get { return _iMAGEINFORF_IMAGEINFODATARF; }
            set { _iMAGEINFORF_IMAGEINFODATARF = value; }
        }

        /// public propaty field.NameJp  :  IMAGEINFORF_IMAGEINFODATARFImageObject
        /// <summary>画像情報データプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   画像情報データプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Image IMAGEINFORF_IMAGEINFODATARFImageObject
        {
            get
            {
                MemoryStream mem = new MemoryStream( _iMAGEINFORF_IMAGEINFODATARF );
                mem.Position = 0;
                return Image.FromStream( mem );
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

        /// public propaty name  :  CSTCST_POSTNORF
        /// <summary>得意先郵便番号プロパティ</summary>
        /// <value>納入先の場合の使用可能項目</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先郵便番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CSTCST_POSTNORF
        {
            get { return _cSTCST_POSTNORF; }
            set { _cSTCST_POSTNORF = value; }
        }

        /// public propaty name  :  CSTCST_ADDRESS1RF
        /// <summary>得意先住所1（都道府県市区郡・町村・字）プロパティ</summary>
        /// <value>納入先の場合の使用可能項目</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先住所1（都道府県市区郡・町村・字）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CSTCST_ADDRESS1RF
        {
            get { return _cSTCST_ADDRESS1RF; }
            set { _cSTCST_ADDRESS1RF = value; }
        }

        /// public propaty name  :  CSTCST_ADDRESS3RF
        /// <summary>得意先住所3（番地）プロパティ</summary>
        /// <value>納入先の場合の使用可能項目</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先住所3（番地）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CSTCST_ADDRESS3RF
        {
            get { return _cSTCST_ADDRESS3RF; }
            set { _cSTCST_ADDRESS3RF = value; }
        }

        /// public propaty name  :  CSTCST_ADDRESS4RF
        /// <summary>得意先住所4（アパート名称）プロパティ</summary>
        /// <value>納入先の場合の使用可能項目</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先住所4（アパート名称）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CSTCST_ADDRESS4RF
        {
            get { return _cSTCST_ADDRESS4RF; }
            set { _cSTCST_ADDRESS4RF = value; }
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

        // --- ADD START 田村顕成 2022/10/18 ----->>>>>
        /// public propaty name  :  CSTCLM_SALESCNSTAXFRCPROCCDRF
        /// <summary>売上消費税端数処理コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上消費税端数処理コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CSTCLM_SALESCNSTAXFRCPROCCDRF
        {
            get { return _cSTCLM_SALESCNSTAXFRCPROCCDRF; }
            set { _cSTCLM_SALESCNSTAXFRCPROCCDRF = value; }
        }
        // --- ADD END 田村顕成 2022/10/18 -----<<<<<
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

        /// public propaty name  :  CSTCLM_POSTNORF
        /// <summary>請求先郵便番号プロパティ</summary>
        /// <value>納入先の場合の使用可能項目</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   請求先郵便番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CSTCLM_POSTNORF
        {
            get { return _cSTCLM_POSTNORF; }
            set { _cSTCLM_POSTNORF = value; }
        }

        /// public propaty name  :  CSTCLM_ADDRESS1RF
        /// <summary>請求先住所1（都道府県市区郡・町村・字）プロパティ</summary>
        /// <value>納入先の場合の使用可能項目</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   請求先住所1（都道府県市区郡・町村・字）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CSTCLM_ADDRESS1RF
        {
            get { return _cSTCLM_ADDRESS1RF; }
            set { _cSTCLM_ADDRESS1RF = value; }
        }

        /// public propaty name  :  CSTCLM_ADDRESS3RF
        /// <summary>請求先住所3（番地）プロパティ</summary>
        /// <value>納入先の場合の使用可能項目</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   請求先住所3（番地）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CSTCLM_ADDRESS3RF
        {
            get { return _cSTCLM_ADDRESS3RF; }
            set { _cSTCLM_ADDRESS3RF = value; }
        }

        /// public propaty name  :  CSTCLM_ADDRESS4RF
        /// <summary>請求先住所4（アパート名称）プロパティ</summary>
        /// <value>納入先の場合の使用可能項目</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   請求先住所4（アパート名称）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CSTCLM_ADDRESS4RF
        {
            get { return _cSTCLM_ADDRESS4RF; }
            set { _cSTCLM_ADDRESS4RF = value; }
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

        /// public propaty name  :  DEPOSITSTRF_DEPOSITSTKINDCD1RF
        /// <summary>入金設定金種コード1プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金設定金種コード1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DEPOSITSTRF_DEPOSITSTKINDCD1RF
        {
            get { return _dEPOSITSTRF_DEPOSITSTKINDCD1RF; }
            set { _dEPOSITSTRF_DEPOSITSTKINDCD1RF = value; }
        }

        /// public propaty name  :  DEPOSITSTRF_DEPOSITSTKINDCD2RF
        /// <summary>入金設定金種コード2プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金設定金種コード2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DEPOSITSTRF_DEPOSITSTKINDCD2RF
        {
            get { return _dEPOSITSTRF_DEPOSITSTKINDCD2RF; }
            set { _dEPOSITSTRF_DEPOSITSTKINDCD2RF = value; }
        }

        /// public propaty name  :  DEPOSITSTRF_DEPOSITSTKINDCD3RF
        /// <summary>入金設定金種コード3プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金設定金種コード3プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DEPOSITSTRF_DEPOSITSTKINDCD3RF
        {
            get { return _dEPOSITSTRF_DEPOSITSTKINDCD3RF; }
            set { _dEPOSITSTRF_DEPOSITSTKINDCD3RF = value; }
        }

        /// public propaty name  :  DEPOSITSTRF_DEPOSITSTKINDCD4RF
        /// <summary>入金設定金種コード4プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金設定金種コード4プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DEPOSITSTRF_DEPOSITSTKINDCD4RF
        {
            get { return _dEPOSITSTRF_DEPOSITSTKINDCD4RF; }
            set { _dEPOSITSTRF_DEPOSITSTKINDCD4RF = value; }
        }

        /// public propaty name  :  DEPOSITSTRF_DEPOSITSTKINDCD5RF
        /// <summary>入金設定金種コード5プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金設定金種コード5プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DEPOSITSTRF_DEPOSITSTKINDCD5RF
        {
            get { return _dEPOSITSTRF_DEPOSITSTKINDCD5RF; }
            set { _dEPOSITSTRF_DEPOSITSTKINDCD5RF = value; }
        }

        /// public propaty name  :  DEPOSITSTRF_DEPOSITSTKINDCD6RF
        /// <summary>入金設定金種コード6プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金設定金種コード6プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DEPOSITSTRF_DEPOSITSTKINDCD6RF
        {
            get { return _dEPOSITSTRF_DEPOSITSTKINDCD6RF; }
            set { _dEPOSITSTRF_DEPOSITSTKINDCD6RF = value; }
        }

        /// public propaty name  :  DEPOSITSTRF_DEPOSITSTKINDCD7RF
        /// <summary>入金設定金種コード7プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金設定金種コード7プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DEPOSITSTRF_DEPOSITSTKINDCD7RF
        {
            get { return _dEPOSITSTRF_DEPOSITSTKINDCD7RF; }
            set { _dEPOSITSTRF_DEPOSITSTKINDCD7RF = value; }
        }

        /// public propaty name  :  DEPOSITSTRF_DEPOSITSTKINDCD8RF
        /// <summary>入金設定金種コード8プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金設定金種コード8プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DEPOSITSTRF_DEPOSITSTKINDCD8RF
        {
            get { return _dEPOSITSTRF_DEPOSITSTKINDCD8RF; }
            set { _dEPOSITSTRF_DEPOSITSTKINDCD8RF = value; }
        }

        /// public propaty name  :  DEPOSITSTRF_DEPOSITSTKINDCD9RF
        /// <summary>入金設定金種コード9プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金設定金種コード9プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DEPOSITSTRF_DEPOSITSTKINDCD9RF
        {
            get { return _dEPOSITSTRF_DEPOSITSTKINDCD9RF; }
            set { _dEPOSITSTRF_DEPOSITSTKINDCD9RF = value; }
        }

        /// public propaty name  :  DEPOSITSTRF_DEPOSITSTKINDCD10RF
        /// <summary>入金設定金種コード10プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金設定金種コード10プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DEPOSITSTRF_DEPOSITSTKINDCD10RF
        {
            get { return _dEPOSITSTRF_DEPOSITSTKINDCD10RF; }
            set { _dEPOSITSTRF_DEPOSITSTKINDCD10RF = value; }
        }

        /// public propaty name  :  DEPT01_MONEYKINDNAMERF
        /// <summary>入金金種名称1プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金金種名称1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DEPT01_MONEYKINDNAMERF
        {
            get { return _dEPT01_MONEYKINDNAMERF; }
            set { _dEPT01_MONEYKINDNAMERF = value; }
        }

        /// public propaty name  :  DEPT01_DEPOSITRF
        /// <summary>入金金額1プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金金額1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 DEPT01_DEPOSITRF
        {
            get { return _dEPT01_DEPOSITRF; }
            set { _dEPT01_DEPOSITRF = value; }
        }

        /// public propaty name  :  DEPT02_MONEYKINDNAMERF
        /// <summary>入金金種名称2プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金金種名称2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DEPT02_MONEYKINDNAMERF
        {
            get { return _dEPT02_MONEYKINDNAMERF; }
            set { _dEPT02_MONEYKINDNAMERF = value; }
        }

        /// public propaty name  :  DEPT02_DEPOSITRF
        /// <summary>入金金額2プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金金額2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 DEPT02_DEPOSITRF
        {
            get { return _dEPT02_DEPOSITRF; }
            set { _dEPT02_DEPOSITRF = value; }
        }

        /// public propaty name  :  DEPT03_MONEYKINDNAMERF
        /// <summary>入金金種名称3プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金金種名称3プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DEPT03_MONEYKINDNAMERF
        {
            get { return _dEPT03_MONEYKINDNAMERF; }
            set { _dEPT03_MONEYKINDNAMERF = value; }
        }

        /// public propaty name  :  DEPT03_DEPOSITRF
        /// <summary>入金金額3プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金金額3プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 DEPT03_DEPOSITRF
        {
            get { return _dEPT03_DEPOSITRF; }
            set { _dEPT03_DEPOSITRF = value; }
        }

        /// public propaty name  :  DEPT04_MONEYKINDNAMERF
        /// <summary>入金金種名称4プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金金種名称4プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DEPT04_MONEYKINDNAMERF
        {
            get { return _dEPT04_MONEYKINDNAMERF; }
            set { _dEPT04_MONEYKINDNAMERF = value; }
        }

        /// public propaty name  :  DEPT04_DEPOSITRF
        /// <summary>入金金額4プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金金額4プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 DEPT04_DEPOSITRF
        {
            get { return _dEPT04_DEPOSITRF; }
            set { _dEPT04_DEPOSITRF = value; }
        }

        /// public propaty name  :  DEPT05_MONEYKINDNAMERF
        /// <summary>入金金種名称5プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金金種名称5プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DEPT05_MONEYKINDNAMERF
        {
            get { return _dEPT05_MONEYKINDNAMERF; }
            set { _dEPT05_MONEYKINDNAMERF = value; }
        }

        /// public propaty name  :  DEPT05_DEPOSITRF
        /// <summary>入金金額5プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金金額5プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 DEPT05_DEPOSITRF
        {
            get { return _dEPT05_DEPOSITRF; }
            set { _dEPT05_DEPOSITRF = value; }
        }

        /// public propaty name  :  DEPT06_MONEYKINDNAMERF
        /// <summary>入金金種名称6プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金金種名称6プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DEPT06_MONEYKINDNAMERF
        {
            get { return _dEPT06_MONEYKINDNAMERF; }
            set { _dEPT06_MONEYKINDNAMERF = value; }
        }

        /// public propaty name  :  DEPT06_DEPOSITRF
        /// <summary>入金金額6プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金金額6プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 DEPT06_DEPOSITRF
        {
            get { return _dEPT06_DEPOSITRF; }
            set { _dEPT06_DEPOSITRF = value; }
        }

        /// public propaty name  :  DEPT07_MONEYKINDNAMERF
        /// <summary>入金金種名称7プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金金種名称7プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DEPT07_MONEYKINDNAMERF
        {
            get { return _dEPT07_MONEYKINDNAMERF; }
            set { _dEPT07_MONEYKINDNAMERF = value; }
        }

        /// public propaty name  :  DEPT07_DEPOSITRF
        /// <summary>入金金額7プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金金額7プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 DEPT07_DEPOSITRF
        {
            get { return _dEPT07_DEPOSITRF; }
            set { _dEPT07_DEPOSITRF = value; }
        }

        /// public propaty name  :  DEPT08_MONEYKINDNAMERF
        /// <summary>入金金種名称8プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金金種名称8プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DEPT08_MONEYKINDNAMERF
        {
            get { return _dEPT08_MONEYKINDNAMERF; }
            set { _dEPT08_MONEYKINDNAMERF = value; }
        }

        /// public propaty name  :  DEPT08_DEPOSITRF
        /// <summary>入金金額8プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金金額8プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 DEPT08_DEPOSITRF
        {
            get { return _dEPT08_DEPOSITRF; }
            set { _dEPT08_DEPOSITRF = value; }
        }

        /// public propaty name  :  DEPT09_MONEYKINDNAMERF
        /// <summary>入金金種名称9プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金金種名称9プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DEPT09_MONEYKINDNAMERF
        {
            get { return _dEPT09_MONEYKINDNAMERF; }
            set { _dEPT09_MONEYKINDNAMERF = value; }
        }

        /// public propaty name  :  DEPT09_DEPOSITRF
        /// <summary>入金金額9プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金金額9プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 DEPT09_DEPOSITRF
        {
            get { return _dEPT09_DEPOSITRF; }
            set { _dEPT09_DEPOSITRF = value; }
        }

        /// public propaty name  :  DEPT10_MONEYKINDNAMERF
        /// <summary>入金金種名称10プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金金種名称10プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DEPT10_MONEYKINDNAMERF
        {
            get { return _dEPT10_MONEYKINDNAMERF; }
            set { _dEPT10_MONEYKINDNAMERF = value; }
        }

        /// public propaty name  :  DEPT10_DEPOSITRF
        /// <summary>入金金額10プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金金額10プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 DEPT10_DEPOSITRF
        {
            get { return _dEPT10_DEPOSITRF; }
            set { _dEPT10_DEPOSITRF = value; }
        }

        /// public propaty name  :  HADD_ADDUPDATEFYRF
        /// <summary>計上年月日西暦年プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   計上年月日西暦年プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 HADD_ADDUPDATEFYRF
        {
            get { return _hADD_ADDUPDATEFYRF; }
            set { _hADD_ADDUPDATEFYRF = value; }
        }

        /// public propaty name  :  HADD_ADDUPDATEFSRF
        /// <summary>計上年月日西暦年略プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   計上年月日西暦年略プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 HADD_ADDUPDATEFSRF
        {
            get { return _hADD_ADDUPDATEFSRF; }
            set { _hADD_ADDUPDATEFSRF = value; }
        }

        /// public propaty name  :  HADD_ADDUPDATEFWRF
        /// <summary>計上年月日和暦年プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   計上年月日和暦年プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 HADD_ADDUPDATEFWRF
        {
            get { return _hADD_ADDUPDATEFWRF; }
            set { _hADD_ADDUPDATEFWRF = value; }
        }

        /// public propaty name  :  HADD_ADDUPDATEFMRF
        /// <summary>計上年月日月プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   計上年月日月プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 HADD_ADDUPDATEFMRF
        {
            get { return _hADD_ADDUPDATEFMRF; }
            set { _hADD_ADDUPDATEFMRF = value; }
        }

        /// public propaty name  :  HADD_ADDUPDATEFDRF
        /// <summary>計上年月日日プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   計上年月日日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 HADD_ADDUPDATEFDRF
        {
            get { return _hADD_ADDUPDATEFDRF; }
            set { _hADD_ADDUPDATEFDRF = value; }
        }

        /// public propaty name  :  HADD_ADDUPDATEFGRF
        /// <summary>計上年月日元号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   計上年月日元号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_ADDUPDATEFGRF
        {
            get { return _hADD_ADDUPDATEFGRF; }
            set { _hADD_ADDUPDATEFGRF = value; }
        }

        /// public propaty name  :  HADD_ADDUPDATEFRRF
        /// <summary>計上年月日略号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   計上年月日略号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_ADDUPDATEFRRF
        {
            get { return _hADD_ADDUPDATEFRRF; }
            set { _hADD_ADDUPDATEFRRF = value; }
        }

        /// public propaty name  :  HADD_ADDUPDATEFLSRF
        /// <summary>計上年月日リテラル(/)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   計上年月日リテラル(/)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_ADDUPDATEFLSRF
        {
            get { return _hADD_ADDUPDATEFLSRF; }
            set { _hADD_ADDUPDATEFLSRF = value; }
        }

        /// public propaty name  :  HADD_ADDUPDATEFLPRF
        /// <summary>計上年月日リテラル(.)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   計上年月日リテラル(.)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_ADDUPDATEFLPRF
        {
            get { return _hADD_ADDUPDATEFLPRF; }
            set { _hADD_ADDUPDATEFLPRF = value; }
        }

        /// public propaty name  :  HADD_ADDUPDATEFLYRF
        /// <summary>計上年月日リテラル(年)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   計上年月日リテラル(年)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_ADDUPDATEFLYRF
        {
            get { return _hADD_ADDUPDATEFLYRF; }
            set { _hADD_ADDUPDATEFLYRF = value; }
        }

        /// public propaty name  :  HADD_ADDUPDATEFLMRF
        /// <summary>計上年月日リテラル(月)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   計上年月日リテラル(月)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_ADDUPDATEFLMRF
        {
            get { return _hADD_ADDUPDATEFLMRF; }
            set { _hADD_ADDUPDATEFLMRF = value; }
        }

        /// public propaty name  :  HADD_ADDUPDATEFLDRF
        /// <summary>計上年月日リテラル(日)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   計上年月日リテラル(日)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_ADDUPDATEFLDRF
        {
            get { return _hADD_ADDUPDATEFLDRF; }
            set { _hADD_ADDUPDATEFLDRF = value; }
        }

        /// public propaty name  :  HADD_ADDUPYEARMONTHFYRF
        /// <summary>計上年月西暦年プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   計上年月西暦年プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 HADD_ADDUPYEARMONTHFYRF
        {
            get { return _hADD_ADDUPYEARMONTHFYRF; }
            set { _hADD_ADDUPYEARMONTHFYRF = value; }
        }

        /// public propaty name  :  HADD_ADDUPYEARMONTHFSRF
        /// <summary>計上年月西暦年略プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   計上年月西暦年略プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 HADD_ADDUPYEARMONTHFSRF
        {
            get { return _hADD_ADDUPYEARMONTHFSRF; }
            set { _hADD_ADDUPYEARMONTHFSRF = value; }
        }

        /// public propaty name  :  HADD_ADDUPYEARMONTHFWRF
        /// <summary>計上年月和暦年プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   計上年月和暦年プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 HADD_ADDUPYEARMONTHFWRF
        {
            get { return _hADD_ADDUPYEARMONTHFWRF; }
            set { _hADD_ADDUPYEARMONTHFWRF = value; }
        }

        /// public propaty name  :  HADD_ADDUPYEARMONTHFMRF
        /// <summary>計上年月月プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   計上年月月プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 HADD_ADDUPYEARMONTHFMRF
        {
            get { return _hADD_ADDUPYEARMONTHFMRF; }
            set { _hADD_ADDUPYEARMONTHFMRF = value; }
        }

        /// public propaty name  :  HADD_ADDUPYEARMONTHFGRF
        /// <summary>計上年月元号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   計上年月元号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_ADDUPYEARMONTHFGRF
        {
            get { return _hADD_ADDUPYEARMONTHFGRF; }
            set { _hADD_ADDUPYEARMONTHFGRF = value; }
        }

        /// public propaty name  :  HADD_ADDUPYEARMONTHFRRF
        /// <summary>計上年月略号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   計上年月略号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_ADDUPYEARMONTHFRRF
        {
            get { return _hADD_ADDUPYEARMONTHFRRF; }
            set { _hADD_ADDUPYEARMONTHFRRF = value; }
        }

        /// public propaty name  :  HADD_ADDUPYEARMONTHFLSRF
        /// <summary>計上年月リテラル(/)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   計上年月リテラル(/)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_ADDUPYEARMONTHFLSRF
        {
            get { return _hADD_ADDUPYEARMONTHFLSRF; }
            set { _hADD_ADDUPYEARMONTHFLSRF = value; }
        }

        /// public propaty name  :  HADD_ADDUPYEARMONTHFLPRF
        /// <summary>計上年月リテラル(.)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   計上年月リテラル(.)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_ADDUPYEARMONTHFLPRF
        {
            get { return _hADD_ADDUPYEARMONTHFLPRF; }
            set { _hADD_ADDUPYEARMONTHFLPRF = value; }
        }

        /// public propaty name  :  HADD_ADDUPYEARMONTHFLYRF
        /// <summary>計上年月リテラル(年)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   計上年月リテラル(年)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_ADDUPYEARMONTHFLYRF
        {
            get { return _hADD_ADDUPYEARMONTHFLYRF; }
            set { _hADD_ADDUPYEARMONTHFLYRF = value; }
        }

        /// public propaty name  :  HADD_ADDUPYEARMONTHFLMRF
        /// <summary>計上年月リテラル(月)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   計上年月リテラル(月)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_ADDUPYEARMONTHFLMRF
        {
            get { return _hADD_ADDUPYEARMONTHFLMRF; }
            set { _hADD_ADDUPYEARMONTHFLMRF = value; }
        }

        /// public propaty name  :  HADD_STARTCADDUPUPDDATEFYRF
        /// <summary>締次更新開始年月日西暦年プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   締次更新開始年月日西暦年プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 HADD_STARTCADDUPUPDDATEFYRF
        {
            get { return _hADD_STARTCADDUPUPDDATEFYRF; }
            set { _hADD_STARTCADDUPUPDDATEFYRF = value; }
        }

        /// public propaty name  :  HADD_STARTCADDUPUPDDATEFSRF
        /// <summary>締次更新開始年月日西暦年略プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   締次更新開始年月日西暦年略プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 HADD_STARTCADDUPUPDDATEFSRF
        {
            get { return _hADD_STARTCADDUPUPDDATEFSRF; }
            set { _hADD_STARTCADDUPUPDDATEFSRF = value; }
        }

        /// public propaty name  :  HADD_STARTCADDUPUPDDATEFWRF
        /// <summary>締次更新開始年月日和暦年プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   締次更新開始年月日和暦年プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 HADD_STARTCADDUPUPDDATEFWRF
        {
            get { return _hADD_STARTCADDUPUPDDATEFWRF; }
            set { _hADD_STARTCADDUPUPDDATEFWRF = value; }
        }

        /// public propaty name  :  HADD_STARTCADDUPUPDDATEFMRF
        /// <summary>締次更新開始年月日月プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   締次更新開始年月日月プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 HADD_STARTCADDUPUPDDATEFMRF
        {
            get { return _hADD_STARTCADDUPUPDDATEFMRF; }
            set { _hADD_STARTCADDUPUPDDATEFMRF = value; }
        }

        /// public propaty name  :  HADD_STARTCADDUPUPDDATEFDRF
        /// <summary>締次更新開始年月日日プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   締次更新開始年月日日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 HADD_STARTCADDUPUPDDATEFDRF
        {
            get { return _hADD_STARTCADDUPUPDDATEFDRF; }
            set { _hADD_STARTCADDUPUPDDATEFDRF = value; }
        }

        /// public propaty name  :  HADD_STARTCADDUPUPDDATEFGRF
        /// <summary>締次更新開始年月日元号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   締次更新開始年月日元号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_STARTCADDUPUPDDATEFGRF
        {
            get { return _hADD_STARTCADDUPUPDDATEFGRF; }
            set { _hADD_STARTCADDUPUPDDATEFGRF = value; }
        }

        /// public propaty name  :  HADD_STARTCADDUPUPDDATEFRRF
        /// <summary>締次更新開始年月日略号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   締次更新開始年月日略号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_STARTCADDUPUPDDATEFRRF
        {
            get { return _hADD_STARTCADDUPUPDDATEFRRF; }
            set { _hADD_STARTCADDUPUPDDATEFRRF = value; }
        }

        /// public propaty name  :  HADD_STARTCADDUPUPDDATEFLSRF
        /// <summary>締次更新開始年月日リテラル(/)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   締次更新開始年月日リテラル(/)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_STARTCADDUPUPDDATEFLSRF
        {
            get { return _hADD_STARTCADDUPUPDDATEFLSRF; }
            set { _hADD_STARTCADDUPUPDDATEFLSRF = value; }
        }

        /// public propaty name  :  HADD_STARTCADDUPUPDDATEFLPRF
        /// <summary>締次更新開始年月日リテラル(.)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   締次更新開始年月日リテラル(.)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_STARTCADDUPUPDDATEFLPRF
        {
            get { return _hADD_STARTCADDUPUPDDATEFLPRF; }
            set { _hADD_STARTCADDUPUPDDATEFLPRF = value; }
        }

        /// public propaty name  :  HADD_STARTCADDUPUPDDATEFLYRF
        /// <summary>締次更新開始年月日リテラル(年)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   締次更新開始年月日リテラル(年)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_STARTCADDUPUPDDATEFLYRF
        {
            get { return _hADD_STARTCADDUPUPDDATEFLYRF; }
            set { _hADD_STARTCADDUPUPDDATEFLYRF = value; }
        }

        /// public propaty name  :  HADD_STARTCADDUPUPDDATEFLMRF
        /// <summary>締次更新開始年月日リテラル(月)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   締次更新開始年月日リテラル(月)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_STARTCADDUPUPDDATEFLMRF
        {
            get { return _hADD_STARTCADDUPUPDDATEFLMRF; }
            set { _hADD_STARTCADDUPUPDDATEFLMRF = value; }
        }

        /// public propaty name  :  HADD_STARTCADDUPUPDDATEFLDRF
        /// <summary>締次更新開始年月日リテラル(日)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   締次更新開始年月日リテラル(日)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_STARTCADDUPUPDDATEFLDRF
        {
            get { return _hADD_STARTCADDUPUPDDATEFLDRF; }
            set { _hADD_STARTCADDUPUPDDATEFLDRF = value; }
        }

        /// public propaty name  :  HADD_BILLPRINTDATEFYRF
        /// <summary>請求書発行日西暦年プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   請求書発行日西暦年プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 HADD_BILLPRINTDATEFYRF
        {
            get { return _hADD_BILLPRINTDATEFYRF; }
            set { _hADD_BILLPRINTDATEFYRF = value; }
        }

        /// public propaty name  :  HADD_BILLPRINTDATEFSRF
        /// <summary>請求書発行日西暦年略プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   請求書発行日西暦年略プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 HADD_BILLPRINTDATEFSRF
        {
            get { return _hADD_BILLPRINTDATEFSRF; }
            set { _hADD_BILLPRINTDATEFSRF = value; }
        }

        /// public propaty name  :  HADD_BILLPRINTDATEFWRF
        /// <summary>請求書発行日和暦年プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   請求書発行日和暦年プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 HADD_BILLPRINTDATEFWRF
        {
            get { return _hADD_BILLPRINTDATEFWRF; }
            set { _hADD_BILLPRINTDATEFWRF = value; }
        }

        /// public propaty name  :  HADD_BILLPRINTDATEFMRF
        /// <summary>請求書発行日月プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   請求書発行日月プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 HADD_BILLPRINTDATEFMRF
        {
            get { return _hADD_BILLPRINTDATEFMRF; }
            set { _hADD_BILLPRINTDATEFMRF = value; }
        }

        /// public propaty name  :  HADD_BILLPRINTDATEFDRF
        /// <summary>請求書発行日日プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   請求書発行日日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 HADD_BILLPRINTDATEFDRF
        {
            get { return _hADD_BILLPRINTDATEFDRF; }
            set { _hADD_BILLPRINTDATEFDRF = value; }
        }

        /// public propaty name  :  HADD_BILLPRINTDATEFGRF
        /// <summary>請求書発行日元号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   請求書発行日元号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_BILLPRINTDATEFGRF
        {
            get { return _hADD_BILLPRINTDATEFGRF; }
            set { _hADD_BILLPRINTDATEFGRF = value; }
        }

        /// public propaty name  :  HADD_BILLPRINTDATEFRRF
        /// <summary>請求書発行日略号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   請求書発行日略号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_BILLPRINTDATEFRRF
        {
            get { return _hADD_BILLPRINTDATEFRRF; }
            set { _hADD_BILLPRINTDATEFRRF = value; }
        }

        /// public propaty name  :  HADD_BILLPRINTDATEFLSRF
        /// <summary>請求書発行日リテラル(/)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   請求書発行日リテラル(/)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_BILLPRINTDATEFLSRF
        {
            get { return _hADD_BILLPRINTDATEFLSRF; }
            set { _hADD_BILLPRINTDATEFLSRF = value; }
        }

        /// public propaty name  :  HADD_BILLPRINTDATEFLPRF
        /// <summary>請求書発行日リテラル(.)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   請求書発行日リテラル(.)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_BILLPRINTDATEFLPRF
        {
            get { return _hADD_BILLPRINTDATEFLPRF; }
            set { _hADD_BILLPRINTDATEFLPRF = value; }
        }

        /// public propaty name  :  HADD_BILLPRINTDATEFLYRF
        /// <summary>請求書発行日リテラル(年)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   請求書発行日リテラル(年)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_BILLPRINTDATEFLYRF
        {
            get { return _hADD_BILLPRINTDATEFLYRF; }
            set { _hADD_BILLPRINTDATEFLYRF = value; }
        }

        /// public propaty name  :  HADD_BILLPRINTDATEFLMRF
        /// <summary>請求書発行日リテラル(月)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   請求書発行日リテラル(月)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_BILLPRINTDATEFLMRF
        {
            get { return _hADD_BILLPRINTDATEFLMRF; }
            set { _hADD_BILLPRINTDATEFLMRF = value; }
        }

        /// public propaty name  :  HADD_BILLPRINTDATEFLDRF
        /// <summary>請求書発行日リテラル(日)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   請求書発行日リテラル(日)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_BILLPRINTDATEFLDRF
        {
            get { return _hADD_BILLPRINTDATEFLDRF; }
            set { _hADD_BILLPRINTDATEFLDRF = value; }
        }

        /// public propaty name  :  HADD_EXPECTEDDEPOSITDATEFYRF
        /// <summary>入金予定日西暦年プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金予定日西暦年プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 HADD_EXPECTEDDEPOSITDATEFYRF
        {
            get { return _hADD_EXPECTEDDEPOSITDATEFYRF; }
            set { _hADD_EXPECTEDDEPOSITDATEFYRF = value; }
        }

        /// public propaty name  :  HADD_EXPECTEDDEPOSITDATEFSRF
        /// <summary>入金予定日西暦年略プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金予定日西暦年略プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 HADD_EXPECTEDDEPOSITDATEFSRF
        {
            get { return _hADD_EXPECTEDDEPOSITDATEFSRF; }
            set { _hADD_EXPECTEDDEPOSITDATEFSRF = value; }
        }

        /// public propaty name  :  HADD_EXPECTEDDEPOSITDATEFWRF
        /// <summary>入金予定日和暦年プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金予定日和暦年プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 HADD_EXPECTEDDEPOSITDATEFWRF
        {
            get { return _hADD_EXPECTEDDEPOSITDATEFWRF; }
            set { _hADD_EXPECTEDDEPOSITDATEFWRF = value; }
        }

        /// public propaty name  :  HADD_EXPECTEDDEPOSITDATEFMRF
        /// <summary>入金予定日月プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金予定日月プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 HADD_EXPECTEDDEPOSITDATEFMRF
        {
            get { return _hADD_EXPECTEDDEPOSITDATEFMRF; }
            set { _hADD_EXPECTEDDEPOSITDATEFMRF = value; }
        }

        /// public propaty name  :  HADD_EXPECTEDDEPOSITDATEFDRF
        /// <summary>入金予定日日プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金予定日日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 HADD_EXPECTEDDEPOSITDATEFDRF
        {
            get { return _hADD_EXPECTEDDEPOSITDATEFDRF; }
            set { _hADD_EXPECTEDDEPOSITDATEFDRF = value; }
        }

        /// public propaty name  :  HADD_EXPECTEDDEPOSITDATEFGRF
        /// <summary>入金予定日元号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金予定日元号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_EXPECTEDDEPOSITDATEFGRF
        {
            get { return _hADD_EXPECTEDDEPOSITDATEFGRF; }
            set { _hADD_EXPECTEDDEPOSITDATEFGRF = value; }
        }

        /// public propaty name  :  HADD_EXPECTEDDEPOSITDATEFRRF
        /// <summary>入金予定日略号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金予定日略号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_EXPECTEDDEPOSITDATEFRRF
        {
            get { return _hADD_EXPECTEDDEPOSITDATEFRRF; }
            set { _hADD_EXPECTEDDEPOSITDATEFRRF = value; }
        }

        /// public propaty name  :  HADD_EXPECTEDDEPOSITDATEFLSRF
        /// <summary>入金予定日リテラル(/)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金予定日リテラル(/)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_EXPECTEDDEPOSITDATEFLSRF
        {
            get { return _hADD_EXPECTEDDEPOSITDATEFLSRF; }
            set { _hADD_EXPECTEDDEPOSITDATEFLSRF = value; }
        }

        /// public propaty name  :  HADD_EXPECTEDDEPOSITDATEFLPRF
        /// <summary>入金予定日リテラル(.)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金予定日リテラル(.)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_EXPECTEDDEPOSITDATEFLPRF
        {
            get { return _hADD_EXPECTEDDEPOSITDATEFLPRF; }
            set { _hADD_EXPECTEDDEPOSITDATEFLPRF = value; }
        }

        /// public propaty name  :  HADD_EXPECTEDDEPOSITDATEFLYRF
        /// <summary>入金予定日リテラル(年)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金予定日リテラル(年)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_EXPECTEDDEPOSITDATEFLYRF
        {
            get { return _hADD_EXPECTEDDEPOSITDATEFLYRF; }
            set { _hADD_EXPECTEDDEPOSITDATEFLYRF = value; }
        }

        /// public propaty name  :  HADD_EXPECTEDDEPOSITDATEFLMRF
        /// <summary>入金予定日リテラル(月)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金予定日リテラル(月)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_EXPECTEDDEPOSITDATEFLMRF
        {
            get { return _hADD_EXPECTEDDEPOSITDATEFLMRF; }
            set { _hADD_EXPECTEDDEPOSITDATEFLMRF = value; }
        }

        /// public propaty name  :  HADD_EXPECTEDDEPOSITDATEFLDRF
        /// <summary>入金予定日リテラル(日)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金予定日リテラル(日)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_EXPECTEDDEPOSITDATEFLDRF
        {
            get { return _hADD_EXPECTEDDEPOSITDATEFLDRF; }
            set { _hADD_EXPECTEDDEPOSITDATEFLDRF = value; }
        }

        /// public propaty name  :  HADD_COLLECTCONDNMRF
        /// <summary>回収条件名称プロパティ</summary>
        /// <value>10:現金,20:振込,30:小切手,40:手形,50:手数料,60:相殺,70:値引,80:その他</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   回収条件名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_COLLECTCONDNMRF
        {
            get { return _hADD_COLLECTCONDNMRF; }
            set { _hADD_COLLECTCONDNMRF = value; }
        }

        /// public propaty name  :  HADD_DMDFORMTITLERF
        /// <summary>請求書タイトルプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   請求書タイトルプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_DMDFORMTITLERF
        {
            get { return _hADD_DMDFORMTITLERF; }
            set { _hADD_DMDFORMTITLERF = value; }
        }

        /// public propaty name  :  HADD_DMDFORMTITLE2RF
        /// <summary>請求書タイトル２プロパティ</summary>
        /// <value>控え</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   請求書タイトル２プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_DMDFORMTITLE2RF
        {
            get { return _hADD_DMDFORMTITLE2RF; }
            set { _hADD_DMDFORMTITLE2RF = value; }
        }

        /// public propaty name  :  HADD_DMDFORMCOMENT1RF
        /// <summary>請求書コメント１プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   請求書コメント１プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_DMDFORMCOMENT1RF
        {
            get { return _hADD_DMDFORMCOMENT1RF; }
            set { _hADD_DMDFORMCOMENT1RF = value; }
        }

        /// public propaty name  :  HADD_DMDFORMCOMENT2RF
        /// <summary>請求書コメント２プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   請求書コメント２プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_DMDFORMCOMENT2RF
        {
            get { return _hADD_DMDFORMCOMENT2RF; }
            set { _hADD_DMDFORMCOMENT2RF = value; }
        }

        /// public propaty name  :  HADD_DMDFORMCOMENT3RF
        /// <summary>請求書コメント３プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   請求書コメント３プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_DMDFORMCOMENT3RF
        {
            get { return _hADD_DMDFORMCOMENT3RF; }
            set { _hADD_DMDFORMCOMENT3RF = value; }
        }

        /// public propaty name  :  HADD_DMDNRMLEXDISRF
        /// <summary>入金金額(値引除く)プロパティ</summary>
        /// <value>算出値：今回入金金額（通常入金）－今回値引額（通常入金）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金金額(値引除く)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 HADD_DMDNRMLEXDISRF
        {
            get { return _hADD_DMDNRMLEXDISRF; }
            set { _hADD_DMDNRMLEXDISRF = value; }
        }

        /// public propaty name  :  HADD_DMDNRMLEXFEERF
        /// <summary>入金金額(手数料除く)プロパティ</summary>
        /// <value>算出値：今回入金金額（通常入金）－今回手数料額（通常入金）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金金額(手数料除く)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 HADD_DMDNRMLEXFEERF
        {
            get { return _hADD_DMDNRMLEXFEERF; }
            set { _hADD_DMDNRMLEXFEERF = value; }
        }

        /// public propaty name  :  HADD_DMDNRMLEXDISFEERF
        /// <summary>入金金額(値引・手数料除く)プロパティ</summary>
        /// <value>算出値：今回入金金額（通常入金）－今回値引額（通常入金）－今回手数料額（通常入金）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金金額(値引・手数料除く)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 HADD_DMDNRMLEXDISFEERF
        {
            get { return _hADD_DMDNRMLEXDISFEERF; }
            set { _hADD_DMDNRMLEXDISFEERF = value; }
        }

        /// public propaty name  :  HADD_DMDNRMLSAMDISFEERF
        /// <summary>入金金額(値引＋手数料)プロパティ</summary>
        /// <value>算出値：今回値引額（通常入金）＋今回手数料額（通常入金）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金金額(値引＋手数料)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 HADD_DMDNRMLSAMDISFEERF
        {
            get { return _hADD_DMDNRMLSAMDISFEERF; }
            set { _hADD_DMDNRMLSAMDISFEERF = value; }
        }

        /// public propaty name  :  HADD_THISSALESANDADJUSTRF
        /// <summary>今回売上額(税抜)プロパティ</summary>
        /// <value>算出値：今回売上額(税抜)＋残高調整額</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   今回売上額(税抜)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 HADD_THISSALESANDADJUSTRF
        {
            get { return _hADD_THISSALESANDADJUSTRF; }
            set { _hADD_THISSALESANDADJUSTRF = value; }
        }

        /// public propaty name  :  HADD_THISTAXANDADJUSTRF
        /// <summary>今回売上消費税プロパティ</summary>
        /// <value>算出値：今回売上消費税＋消費税調整額</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   今回売上消費税プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 HADD_THISTAXANDADJUSTRF
        {
            get { return _hADD_THISTAXANDADJUSTRF; }
            set { _hADD_THISTAXANDADJUSTRF = value; }
        }

        /// public propaty name  :  HADD_ISSUEDAYRF
        /// <summary>入力発行日付プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入力発行日付プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 HADD_ISSUEDAYRF
        {
            get { return _hADD_ISSUEDAYRF; }
            set { _hADD_ISSUEDAYRF = value; }
        }

        /// public propaty name  :  HADD_ISSUEDAYFYRF
        /// <summary>入力発行日付西暦年プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入力発行日付西暦年プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 HADD_ISSUEDAYFYRF
        {
            get { return _hADD_ISSUEDAYFYRF; }
            set { _hADD_ISSUEDAYFYRF = value; }
        }

        /// public propaty name  :  HADD_ISSUEDAYFSRF
        /// <summary>入力発行日付西暦年略プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入力発行日付西暦年略プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 HADD_ISSUEDAYFSRF
        {
            get { return _hADD_ISSUEDAYFSRF; }
            set { _hADD_ISSUEDAYFSRF = value; }
        }

        /// public propaty name  :  HADD_ISSUEDAYFWRF
        /// <summary>入力発行日付和暦年プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入力発行日付和暦年プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 HADD_ISSUEDAYFWRF
        {
            get { return _hADD_ISSUEDAYFWRF; }
            set { _hADD_ISSUEDAYFWRF = value; }
        }

        /// public propaty name  :  HADD_ISSUEDAYFMRF
        /// <summary>入力発行日付月プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入力発行日付月プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 HADD_ISSUEDAYFMRF
        {
            get { return _hADD_ISSUEDAYFMRF; }
            set { _hADD_ISSUEDAYFMRF = value; }
        }

        /// public propaty name  :  HADD_ISSUEDAYFDRF
        /// <summary>入力発行日付日プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入力発行日付日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 HADD_ISSUEDAYFDRF
        {
            get { return _hADD_ISSUEDAYFDRF; }
            set { _hADD_ISSUEDAYFDRF = value; }
        }

        /// public propaty name  :  HADD_ISSUEDAYFGRF
        /// <summary>入力発行日付元号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入力発行日付元号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_ISSUEDAYFGRF
        {
            get { return _hADD_ISSUEDAYFGRF; }
            set { _hADD_ISSUEDAYFGRF = value; }
        }

        /// public propaty name  :  HADD_ISSUEDAYFRRF
        /// <summary>入力発行日付略号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入力発行日付略号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_ISSUEDAYFRRF
        {
            get { return _hADD_ISSUEDAYFRRF; }
            set { _hADD_ISSUEDAYFRRF = value; }
        }

        /// public propaty name  :  HADD_ISSUEDAYFLSRF
        /// <summary>入力発行日付リテラル(/)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入力発行日付リテラル(/)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_ISSUEDAYFLSRF
        {
            get { return _hADD_ISSUEDAYFLSRF; }
            set { _hADD_ISSUEDAYFLSRF = value; }
        }

        /// public propaty name  :  HADD_ISSUEDAYFLPRF
        /// <summary>入力発行日付リテラル(.)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入力発行日付リテラル(.)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_ISSUEDAYFLPRF
        {
            get { return _hADD_ISSUEDAYFLPRF; }
            set { _hADD_ISSUEDAYFLPRF = value; }
        }

        /// public propaty name  :  HADD_ISSUEDAYFLYRF
        /// <summary>入力発行日付リテラル(年)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入力発行日付リテラル(年)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_ISSUEDAYFLYRF
        {
            get { return _hADD_ISSUEDAYFLYRF; }
            set { _hADD_ISSUEDAYFLYRF = value; }
        }

        /// public propaty name  :  HADD_ISSUEDAYFLMRF
        /// <summary>入力発行日付リテラル(月)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入力発行日付リテラル(月)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_ISSUEDAYFLMRF
        {
            get { return _hADD_ISSUEDAYFLMRF; }
            set { _hADD_ISSUEDAYFLMRF = value; }
        }

        /// public propaty name  :  HADD_ISSUEDAYFLDRF
        /// <summary>入力発行日付リテラル(日)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入力発行日付リテラル(日)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_ISSUEDAYFLDRF
        {
            get { return _hADD_ISSUEDAYFLDRF; }
            set { _hADD_ISSUEDAYFLDRF = value; }
        }

        /// public propaty name  :  CADD_CUSTOMERSUBCODERF
        /// <summary>印刷得意先サブコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   印刷得意先サブコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CADD_CUSTOMERSUBCODERF
        {
            get { return _cADD_CUSTOMERSUBCODERF; }
            set { _cADD_CUSTOMERSUBCODERF = value; }
        }

        /// public propaty name  :  CADD_NAMERF
        /// <summary>印刷得意先名称プロパティ</summary>
        /// <value>納入先の場合の使用可能項目</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   印刷得意先名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CADD_NAMERF
        {
            get { return _cADD_NAMERF; }
            set { _cADD_NAMERF = value; }
        }

        /// public propaty name  :  CADD_NAME2RF
        /// <summary>印刷得意先名称2プロパティ</summary>
        /// <value>納入先の場合の使用可能項目</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   印刷得意先名称2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CADD_NAME2RF
        {
            get { return _cADD_NAME2RF; }
            set { _cADD_NAME2RF = value; }
        }

        /// public propaty name  :  CADD_HONORIFICTITLERF
        /// <summary>印刷得意先敬称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   印刷得意先敬称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CADD_HONORIFICTITLERF
        {
            get { return _cADD_HONORIFICTITLERF; }
            set { _cADD_HONORIFICTITLERF = value; }
        }

        /// public propaty name  :  CADD_KANARF
        /// <summary>印刷得意先カナプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   印刷得意先カナプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CADD_KANARF
        {
            get { return _cADD_KANARF; }
            set { _cADD_KANARF = value; }
        }

        /// public propaty name  :  CADD_CUSTOMERSNMRF
        /// <summary>印刷得意先略称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   印刷得意先略称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CADD_CUSTOMERSNMRF
        {
            get { return _cADD_CUSTOMERSNMRF; }
            set { _cADD_CUSTOMERSNMRF = value; }
        }

        /// public propaty name  :  CADD_OUTPUTNAMECODERF
        /// <summary>印刷得意先諸口コードプロパティ</summary>
        /// <value>0:顧客名称1と2,1:顧客名称1,2:顧客名称2,3:諸口名称</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   印刷得意先諸口コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CADD_OUTPUTNAMECODERF
        {
            get { return _cADD_OUTPUTNAMECODERF; }
            set { _cADD_OUTPUTNAMECODERF = value; }
        }

        /// public propaty name  :  CADD_POSTNORF
        /// <summary>印刷得意先郵便番号プロパティ</summary>
        /// <value>納入先の場合の使用可能項目</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   印刷得意先郵便番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CADD_POSTNORF
        {
            get { return _cADD_POSTNORF; }
            set { _cADD_POSTNORF = value; }
        }

        /// public propaty name  :  CADD_ADDRESS1RF
        /// <summary>印刷得意先住所1（都道府県市区郡・町村・字）プロパティ</summary>
        /// <value>納入先の場合の使用可能項目</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   印刷得意先住所1（都道府県市区郡・町村・字）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CADD_ADDRESS1RF
        {
            get { return _cADD_ADDRESS1RF; }
            set { _cADD_ADDRESS1RF = value; }
        }

        /// public propaty name  :  CADD_ADDRESS3RF
        /// <summary>印刷得意先住所3（番地）プロパティ</summary>
        /// <value>納入先の場合の使用可能項目</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   印刷得意先住所3（番地）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CADD_ADDRESS3RF
        {
            get { return _cADD_ADDRESS3RF; }
            set { _cADD_ADDRESS3RF = value; }
        }

        /// public propaty name  :  CADD_ADDRESS4RF
        /// <summary>印刷得意先住所4（アパート名称）プロパティ</summary>
        /// <value>納入先の場合の使用可能項目</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   印刷得意先住所4（アパート名称）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CADD_ADDRESS4RF
        {
            get { return _cADD_ADDRESS4RF; }
            set { _cADD_ADDRESS4RF = value; }
        }

        /// public propaty name  :  CADD_CUSTANALYSCODE1RF
        /// <summary>印刷得意先分析コード1プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   印刷得意先分析コード1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CADD_CUSTANALYSCODE1RF
        {
            get { return _cADD_CUSTANALYSCODE1RF; }
            set { _cADD_CUSTANALYSCODE1RF = value; }
        }

        /// public propaty name  :  CADD_CUSTANALYSCODE2RF
        /// <summary>印刷得意先分析コード2プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   印刷得意先分析コード2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CADD_CUSTANALYSCODE2RF
        {
            get { return _cADD_CUSTANALYSCODE2RF; }
            set { _cADD_CUSTANALYSCODE2RF = value; }
        }

        /// public propaty name  :  CADD_CUSTANALYSCODE3RF
        /// <summary>印刷得意先分析コード3プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   印刷得意先分析コード3プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CADD_CUSTANALYSCODE3RF
        {
            get { return _cADD_CUSTANALYSCODE3RF; }
            set { _cADD_CUSTANALYSCODE3RF = value; }
        }

        /// public propaty name  :  CADD_CUSTANALYSCODE4RF
        /// <summary>印刷得意先分析コード4プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   印刷得意先分析コード4プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CADD_CUSTANALYSCODE4RF
        {
            get { return _cADD_CUSTANALYSCODE4RF; }
            set { _cADD_CUSTANALYSCODE4RF = value; }
        }

        /// public propaty name  :  CADD_CUSTANALYSCODE5RF
        /// <summary>印刷得意先分析コード5プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   印刷得意先分析コード5プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CADD_CUSTANALYSCODE5RF
        {
            get { return _cADD_CUSTANALYSCODE5RF; }
            set { _cADD_CUSTANALYSCODE5RF = value; }
        }

        /// public propaty name  :  CADD_CUSTANALYSCODE6RF
        /// <summary>印刷得意先分析コード6プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   印刷得意先分析コード6プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CADD_CUSTANALYSCODE6RF
        {
            get { return _cADD_CUSTANALYSCODE6RF; }
            set { _cADD_CUSTANALYSCODE6RF = value; }
        }

        /// public propaty name  :  CADD_NOTE1RF
        /// <summary>印刷得意先備考1プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   印刷得意先備考1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CADD_NOTE1RF
        {
            get { return _cADD_NOTE1RF; }
            set { _cADD_NOTE1RF = value; }
        }

        /// public propaty name  :  CADD_NOTE2RF
        /// <summary>印刷得意先備考2プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   印刷得意先備考2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CADD_NOTE2RF
        {
            get { return _cADD_NOTE2RF; }
            set { _cADD_NOTE2RF = value; }
        }

        /// public propaty name  :  CADD_NOTE3RF
        /// <summary>印刷得意先備考3プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   印刷得意先備考3プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CADD_NOTE3RF
        {
            get { return _cADD_NOTE3RF; }
            set { _cADD_NOTE3RF = value; }
        }

        /// public propaty name  :  CADD_NOTE4RF
        /// <summary>印刷得意先備考4プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   印刷得意先備考4プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CADD_NOTE4RF
        {
            get { return _cADD_NOTE4RF; }
            set { _cADD_NOTE4RF = value; }
        }

        /// public propaty name  :  CADD_NOTE5RF
        /// <summary>印刷得意先備考5プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   印刷得意先備考5プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CADD_NOTE5RF
        {
            get { return _cADD_NOTE5RF; }
            set { _cADD_NOTE5RF = value; }
        }

        /// public propaty name  :  CADD_NOTE6RF
        /// <summary>印刷得意先備考6プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   印刷得意先備考6プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CADD_NOTE6RF
        {
            get { return _cADD_NOTE6RF; }
            set { _cADD_NOTE6RF = value; }
        }

        /// public propaty name  :  CADD_NOTE7RF
        /// <summary>印刷得意先備考7プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   印刷得意先備考7プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CADD_NOTE7RF
        {
            get { return _cADD_NOTE7RF; }
            set { _cADD_NOTE7RF = value; }
        }

        /// public propaty name  :  CADD_NOTE8RF
        /// <summary>印刷得意先備考8プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   印刷得意先備考8プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CADD_NOTE8RF
        {
            get { return _cADD_NOTE8RF; }
            set { _cADD_NOTE8RF = value; }
        }

        /// public propaty name  :  CADD_NOTE9RF
        /// <summary>印刷得意先備考9プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   印刷得意先備考9プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CADD_NOTE9RF
        {
            get { return _cADD_NOTE9RF; }
            set { _cADD_NOTE9RF = value; }
        }

        /// public propaty name  :  CADD_NOTE10RF
        /// <summary>印刷得意先備考10プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   印刷得意先備考10プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CADD_NOTE10RF
        {
            get { return _cADD_NOTE10RF; }
            set { _cADD_NOTE10RF = value; }
        }

        /// public propaty name  :  CADD_PRINTCUSTOMERNAME1RF
        /// <summary>印刷用得意先名称（上段）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   印刷用得意先名称（上段）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CADD_PRINTCUSTOMERNAME1RF
        {
            get { return _cADD_PRINTCUSTOMERNAME1RF; }
            set { _cADD_PRINTCUSTOMERNAME1RF = value; }
        }

        /// public propaty name  :  CADD_PRINTCUSTOMERNAME2RF
        /// <summary>印刷用得意先名称（下段）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   印刷用得意先名称（下段）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CADD_PRINTCUSTOMERNAME2RF
        {
            get { return _cADD_PRINTCUSTOMERNAME2RF; }
            set { _cADD_PRINTCUSTOMERNAME2RF = value; }
        }

        /// public propaty name  :  CADD_PRINTCUSTOMERNAME2HNRF
        /// <summary>印刷用得意先名称（下段）＋敬称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   印刷用得意先名称（下段）＋敬称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CADD_PRINTCUSTOMERNAME2HNRF
        {
            get { return _cADD_PRINTCUSTOMERNAME2HNRF; }
            set { _cADD_PRINTCUSTOMERNAME2HNRF = value; }
        }

        /// public propaty name  :  CSTCST_COLLECTMONEYNAMERF
        /// <summary>集金月区分名称プロパティ</summary>
        /// <value>当月,翌月,翌々月</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   集金月区分名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CSTCST_COLLECTMONEYNAMERF
        {
            get { return _cSTCST_COLLECTMONEYNAMERF; }
            set { _cSTCST_COLLECTMONEYNAMERF = value; }
        }

        /// public propaty name  :  CSTCST_COLLECTMONEYDAYRF
        /// <summary>集金日プロパティ</summary>
        /// <value>DD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   集金日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CSTCST_COLLECTMONEYDAYRF
        {
            get { return _cSTCST_COLLECTMONEYDAYRF; }
            set { _cSTCST_COLLECTMONEYDAYRF = value; }
        }

        /// public propaty name  :  CADD_CUSTOMERCODERF
        /// <summary>印刷得意先コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   印刷得意先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CADD_CUSTOMERCODERF
        {
            get { return _cADD_CUSTOMERCODERF; }
            set { _cADD_CUSTOMERCODERF = value; }
        }

        /// public propaty name  :  CADD_HOMETELNORF
        /// <summary>印刷得意先電話番号（自宅）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   印刷得意先電話番号（自宅）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CADD_HOMETELNORF
        {
            get { return _cADD_HOMETELNORF; }
            set { _cADD_HOMETELNORF = value; }
        }

        /// public propaty name  :  CADD_OFFICETELNORF
        /// <summary>印刷得意先電話番号（勤務先）プロパティ</summary>
        /// <value>納入先の場合の使用可能項目</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   印刷得意先電話番号（勤務先）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CADD_OFFICETELNORF
        {
            get { return _cADD_OFFICETELNORF; }
            set { _cADD_OFFICETELNORF = value; }
        }

        /// public propaty name  :  CADD_PORTABLETELNORF
        /// <summary>印刷得意先電話番号（携帯）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   印刷得意先電話番号（携帯）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CADD_PORTABLETELNORF
        {
            get { return _cADD_PORTABLETELNORF; }
            set { _cADD_PORTABLETELNORF = value; }
        }

        /// public propaty name  :  CADD_HOMEFAXNORF
        /// <summary>印刷得意先FAX番号（自宅）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   印刷得意先FAX番号（自宅）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CADD_HOMEFAXNORF
        {
            get { return _cADD_HOMEFAXNORF; }
            set { _cADD_HOMEFAXNORF = value; }
        }

        /// public propaty name  :  CADD_OFFICEFAXNORF
        /// <summary>印刷得意先FAX番号（勤務先）プロパティ</summary>
        /// <value>納入先の場合の使用可能項目</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   印刷得意先FAX番号（勤務先）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CADD_OFFICEFAXNORF
        {
            get { return _cADD_OFFICEFAXNORF; }
            set { _cADD_OFFICEFAXNORF = value; }
        }

        /// public propaty name  :  CADD_OTHERSTELNORF
        /// <summary>印刷得意先電話番号（その他）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   印刷得意先電話番号（その他）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CADD_OTHERSTELNORF
        {
            get { return _cADD_OTHERSTELNORF; }
            set { _cADD_OTHERSTELNORF = value; }
        }

        /// public propaty name  :  CSTCST_HOMETELNORF
        /// <summary>得意先電話番号（自宅）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先電話番号（自宅）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CSTCST_HOMETELNORF
        {
            get { return _cSTCST_HOMETELNORF; }
            set { _cSTCST_HOMETELNORF = value; }
        }

        /// public propaty name  :  CSTCST_OFFICETELNORF
        /// <summary>得意先電話番号（勤務先）プロパティ</summary>
        /// <value>納入先の場合の使用可能項目</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先電話番号（勤務先）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CSTCST_OFFICETELNORF
        {
            get { return _cSTCST_OFFICETELNORF; }
            set { _cSTCST_OFFICETELNORF = value; }
        }

        /// public propaty name  :  CSTCST_PORTABLETELNORF
        /// <summary>得意先電話番号（携帯）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先電話番号（携帯）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CSTCST_PORTABLETELNORF
        {
            get { return _cSTCST_PORTABLETELNORF; }
            set { _cSTCST_PORTABLETELNORF = value; }
        }

        /// public propaty name  :  CSTCST_HOMEFAXNORF
        /// <summary>得意先FAX番号（自宅）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先FAX番号（自宅）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CSTCST_HOMEFAXNORF
        {
            get { return _cSTCST_HOMEFAXNORF; }
            set { _cSTCST_HOMEFAXNORF = value; }
        }

        /// public propaty name  :  CSTCST_OFFICEFAXNORF
        /// <summary>得意先FAX番号（勤務先）プロパティ</summary>
        /// <value>納入先の場合の使用可能項目</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先FAX番号（勤務先）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CSTCST_OFFICEFAXNORF
        {
            get { return _cSTCST_OFFICEFAXNORF; }
            set { _cSTCST_OFFICEFAXNORF = value; }
        }

        /// public propaty name  :  CSTCST_OTHERSTELNORF
        /// <summary>得意先電話番号（その他）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先電話番号（その他）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CSTCST_OTHERSTELNORF
        {
            get { return _cSTCST_OTHERSTELNORF; }
            set { _cSTCST_OTHERSTELNORF = value; }
        }

        /// public propaty name  :  CSTCLM_HOMETELNORF
        /// <summary>請求先電話番号（自宅）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   請求先電話番号（自宅）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CSTCLM_HOMETELNORF
        {
            get { return _cSTCLM_HOMETELNORF; }
            set { _cSTCLM_HOMETELNORF = value; }
        }

        /// public propaty name  :  CSTCLM_OFFICETELNORF
        /// <summary>請求先電話番号（勤務先）プロパティ</summary>
        /// <value>納入先の場合の使用可能項目</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   請求先電話番号（勤務先）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CSTCLM_OFFICETELNORF
        {
            get { return _cSTCLM_OFFICETELNORF; }
            set { _cSTCLM_OFFICETELNORF = value; }
        }

        /// public propaty name  :  CSTCLM_PORTABLETELNORF
        /// <summary>請求先電話番号（携帯）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   請求先電話番号（携帯）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CSTCLM_PORTABLETELNORF
        {
            get { return _cSTCLM_PORTABLETELNORF; }
            set { _cSTCLM_PORTABLETELNORF = value; }
        }

        /// public propaty name  :  CSTCLM_HOMEFAXNORF
        /// <summary>請求先FAX番号（自宅）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   請求先FAX番号（自宅）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CSTCLM_HOMEFAXNORF
        {
            get { return _cSTCLM_HOMEFAXNORF; }
            set { _cSTCLM_HOMEFAXNORF = value; }
        }

        /// public propaty name  :  CSTCLM_OFFICEFAXNORF
        /// <summary>請求先FAX番号（勤務先）プロパティ</summary>
        /// <value>納入先の場合の使用可能項目</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   請求先FAX番号（勤務先）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CSTCLM_OFFICEFAXNORF
        {
            get { return _cSTCLM_OFFICEFAXNORF; }
            set { _cSTCLM_OFFICEFAXNORF = value; }
        }

        /// public propaty name  :  CSTCLM_OTHERSTELNORF
        /// <summary>請求先電話番号（その他）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   請求先電話番号（その他）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CSTCLM_OTHERSTELNORF
        {
            get { return _cSTCLM_OTHERSTELNORF; }
            set { _cSTCLM_OTHERSTELNORF = value; }
        }

        /// public propaty name  :  HADD_THISSALESANDADJUSTTAXINCRF
        /// <summary>今回売上額(税込)プロパティ</summary>
        /// <value>算出値：今回売上額(税抜)＋残高調整額＋今回売上消費税＋消費税調整額</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   今回売上額(税込)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 HADD_THISSALESANDADJUSTTAXINCRF
        {
            get { return _hADD_THISSALESANDADJUSTTAXINCRF; }
            set { _hADD_THISSALESANDADJUSTTAXINCRF = value; }
        }

        /// public propaty name  :  CSTCLM_COLLECTMONEYNAMERF
        /// <summary>請求先集金月区分名称プロパティ</summary>
        /// <value>当月,翌月,翌々月</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   請求先集金月区分名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CSTCLM_COLLECTMONEYNAMERF
        {
            get { return _cSTCLM_COLLECTMONEYNAMERF; }
            set { _cSTCLM_COLLECTMONEYNAMERF = value; }
        }

        /// public propaty name  :  CSTCLM_COLLECTMONEYDAYRF
        /// <summary>請求先集金日プロパティ</summary>
        /// <value>DD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   請求先集金日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CSTCLM_COLLECTMONEYDAYRF
        {
            get { return _cSTCLM_COLLECTMONEYDAYRF; }
            set { _cSTCLM_COLLECTMONEYDAYRF = value; }
        }

        /// public propaty name  :  CUSTDMDPRCRF_RESULTSSECTCDRF
        /// <summary>実績拠点コードプロパティ</summary>
        /// <value>実績集計の対象となっている拠点コード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   実績拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CUSTDMDPRCRF_RESULTSSECTCDRF
        {
            get { return _cUSTDMDPRCRF_RESULTSSECTCDRF; }
            set { _cUSTDMDPRCRF_RESULTSSECTCDRF = value; }
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

        /// public propaty name  :  ALITMDSPNMRF_HOMETELNODSPNAMERF
        /// <summary>自宅TEL表示名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自宅TEL表示名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ALITMDSPNMRF_HOMETELNODSPNAMERF
        {
            get { return _aLITMDSPNMRF_HOMETELNODSPNAMERF; }
            set { _aLITMDSPNMRF_HOMETELNODSPNAMERF = value; }
        }

        /// public propaty name  :  ALITMDSPNMRF_OFFICETELNODSPNAMERF
        /// <summary>勤務先TEL表示名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   勤務先TEL表示名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ALITMDSPNMRF_OFFICETELNODSPNAMERF
        {
            get { return _aLITMDSPNMRF_OFFICETELNODSPNAMERF; }
            set { _aLITMDSPNMRF_OFFICETELNODSPNAMERF = value; }
        }

        /// public propaty name  :  ALITMDSPNMRF_MOBILETELNODSPNAMERF
        /// <summary>携帯TEL表示名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   携帯TEL表示名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ALITMDSPNMRF_MOBILETELNODSPNAMERF
        {
            get { return _aLITMDSPNMRF_MOBILETELNODSPNAMERF; }
            set { _aLITMDSPNMRF_MOBILETELNODSPNAMERF = value; }
        }

        /// public propaty name  :  ALITMDSPNMRF_HOMEFAXNODSPNAMERF
        /// <summary>自宅FAX表示名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自宅FAX表示名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ALITMDSPNMRF_HOMEFAXNODSPNAMERF
        {
            get { return _aLITMDSPNMRF_HOMEFAXNODSPNAMERF; }
            set { _aLITMDSPNMRF_HOMEFAXNODSPNAMERF = value; }
        }

        /// public propaty name  :  ALITMDSPNMRF_OFFICEFAXNODSPNAMERF
        /// <summary>勤務先FAX表示名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   勤務先FAX表示名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ALITMDSPNMRF_OFFICEFAXNODSPNAMERF
        {
            get { return _aLITMDSPNMRF_OFFICEFAXNODSPNAMERF; }
            set { _aLITMDSPNMRF_OFFICEFAXNODSPNAMERF = value; }
        }

        /// public propaty name  :  ALITMDSPNMRF_OTHERTELNODSPNAMERF
        /// <summary>その他TEL表示名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   その他TEL表示名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ALITMDSPNMRF_OTHERTELNODSPNAMERF
        {
            get { return _aLITMDSPNMRF_OTHERTELNODSPNAMERF; }
            set { _aLITMDSPNMRF_OTHERTELNODSPNAMERF = value; }
        }

        /// public propaty name  :  CSTCLM_SALESAREACODERF
        /// <summary>販売エリアコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   販売エリアコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CSTCLM_SALESAREACODERF
        {
            get { return _cSTCLM_SALESAREACODERF; }
            set { _cSTCLM_SALESAREACODERF = value; }
        }

        /// public propaty name  :  CSTCLM_CUSTOMERAGENTCDRF
        /// <summary>顧客担当従業員コードプロパティ</summary>
        /// <value>文字型</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   顧客担当従業員コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CSTCLM_CUSTOMERAGENTCDRF
        {
            get { return _cSTCLM_CUSTOMERAGENTCDRF; }
            set { _cSTCLM_CUSTOMERAGENTCDRF = value; }
        }

        /// public propaty name  :  CSTCLM_BILLCOLLECTERCDRF
        /// <summary>集金担当従業員コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   集金担当従業員コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CSTCLM_BILLCOLLECTERCDRF
        {
            get { return _cSTCLM_BILLCOLLECTERCDRF; }
            set { _cSTCLM_BILLCOLLECTERCDRF = value; }
        }

        /// public propaty name  :  CSTCLM_OLDCUSTOMERAGENTCDRF
        /// <summary>旧顧客担当従業員コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   旧顧客担当従業員コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CSTCLM_OLDCUSTOMERAGENTCDRF
        {
            get { return _cSTCLM_OLDCUSTOMERAGENTCDRF; }
            set { _cSTCLM_OLDCUSTOMERAGENTCDRF = value; }
        }

        /// public propaty name  :  CSTCLM_CUSTAGENTCHGDATERF
        /// <summary>顧客担当変更日プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   顧客担当変更日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CSTCLM_CUSTAGENTCHGDATERF
        {
            get { return _cSTCLM_CUSTAGENTCHGDATERF; }
            set { _cSTCLM_CUSTAGENTCHGDATERF = value; }
        }

        /// public propaty name  :  CUSTDMDPRCRF_BILLNORF
        /// <summary>請求書番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   請求書番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CUSTDMDPRCRF_BILLNORF
        {
            get { return _cUSTDMDPRCRF_BILLNORF; }
            set { _cUSTDMDPRCRF_BILLNORF = value; }
        }

        /// public propaty name  :  CSTCST_COLLECTMONEYCODERF
        /// <summary>集金月区分コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   集金月区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CSTCST_COLLECTMONEYCODERF
        {
            get { return _cSTCST_COLLECTMONEYCODERF; }
            set { _cSTCST_COLLECTMONEYCODERF = value; }
        }

        /// public propaty name  :  CSTCLM_COLLECTMONEYCODERF
        /// <summary>請求先集金月区分コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   集金月区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CSTCLM_COLLECTMONEYCODERF
        {
            get { return _cSTCLM_COLLECTMONEYCODERF; }
            set { _cSTCLM_COLLECTMONEYCODERF = value; }
        }

        /// public propaty name  :  CSTCLM_TOTALDAYRF
        /// <summary>締日プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   締日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CSTCLM_TOTALDAYRF
        {
            get { return _cSTCLM_TOTALDAYRF; }
            set { _cSTCLM_TOTALDAYRF = value; }
        }

        /// public propaty name  :  TitleTaxRate1
        /// <summary>税率1タイトル</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   税率1タイトル</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public int TitleTaxRate1
        {
            get { return _titleTaxRate1; }
            set { _titleTaxRate1 = value; }
        }

        /// public propaty name  :  TitleTaxRate2
        /// <summary>税率2タイトル</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   税率2タイトル</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public int TitleTaxRate2
        {
            get { return _titleTaxRate2; }
            set { _titleTaxRate2 = value; }
        }

        /// public propaty name  :  TotalThisTimeSalesTaxInRate1
        /// <summary>税率(1)対象金額合計(税抜き) </summary>
        /// <value>税率(1)対象金額合計(税抜き)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   税率(1)対象金額合計(税抜き) プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public double TotalThisTimeSalesTaxExRate1
        {
            get { return _totalThisTimeSalesTaxExRate1; }
            set { _totalThisTimeSalesTaxExRate1 = value; }
        }

        /// public propaty name  :  TotalThisTimeSalesTaxExRate2
        /// <summary>税率(2)対象金額合計(税抜き) </summary>
        /// <value>税率(2)対象金額合計(税抜き)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   税率(2)対象金額合計(税抜き) プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public double TotalThisTimeSalesTaxExRate2
        {
            get { return _totalThisTimeSalesTaxExRate2; }
            set { _totalThisTimeSalesTaxExRate2 = value; }
        }

        /// public propaty name  :  TotalThisTimeTaxRate1
        /// <summary>税額(1) </summary>
        /// <value>税額(1)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   税率(1)対象金額合計(税抜き) プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public double TotalThisTimeTaxRate1
        {
            get { return _totalThisTimeTaxRate1; }
            set { _totalThisTimeTaxRate1 = value; }
        }

        /// public propaty name  :  TotalThisTimeTaxRate2
        /// <summary>税額(2) </summary>
        /// <value>税額(2)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   税率(2)対象金額合計(税抜き) プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public double TotalThisTimeTaxRate2
        {
            get { return _totalThisTimeTaxRate2; }
            set { _totalThisTimeTaxRate2 = value; }
        }


        /// <summary>
        /// 自由帳票請求書ヘッダデータワークコンストラクタ
        /// </summary>
        /// <returns>EBooksFrePBillHeadWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   EBooksFrePBillHeadWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public EBooksFrePBillHeadWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>EBooksFrePBillHeadWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   EBooksFrePBillHeadWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// <br>Update Note      : 2022/10/18 田村顕成</br>
    /// <br>管理番号         : 11870141-00 インボイス残対応（軽減税率対応）</br>
    /// </remarks>
    public class EBooksFrePBillHeadWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   EBooksFrePBillHeadWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize( System.IO.BinaryWriter writer, object graph )
        {
            // TODO:  EBooksFrePBillHeadWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if ( writer == null )
                throw new ArgumentNullException();

            if ( graph != null && !(graph is EBooksFrePBillHeadWork || graph is ArrayList || graph is EBooksFrePBillHeadWork[]) )
                throw new ArgumentException( string.Format( "graphが{0}のインスタンスでありません", typeof( EBooksFrePBillHeadWork ).FullName ) );

            if ( graph != null && graph is EBooksFrePBillHeadWork )
            {
                Type t = graph.GetType();
                if ( !CustomFormatterServices.NeedCustomSerialization( t ) )
                    throw new ArgumentException( string.Format( "graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName ) );
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo( ", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.EBooksFrePBillHeadWork" );

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if ( graph is ArrayList )
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if ( graph is EBooksFrePBillHeadWork[] )
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((EBooksFrePBillHeadWork[])graph).Length;
            }
            else if ( graph is EBooksFrePBillHeadWork )
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //計上拠点コード
            serInfo.MemberInfo.Add( typeof( string ) ); //CUSTDMDPRCRF_ADDUPSECCODERF
            //請求先コード
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //CUSTDMDPRCRF_CLAIMCODERF
            //請求先名称
            serInfo.MemberInfo.Add( typeof( string ) ); //CUSTDMDPRCRF_CLAIMNAMERF
            //請求先名称2
            serInfo.MemberInfo.Add( typeof( string ) ); //CUSTDMDPRCRF_CLAIMNAME2RF
            //請求先略称
            serInfo.MemberInfo.Add( typeof( string ) ); //CUSTDMDPRCRF_CLAIMSNMRF
            //得意先コード
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //CUSTDMDPRCRF_CUSTOMERCODERF
            //得意先名称
            serInfo.MemberInfo.Add( typeof( string ) ); //CUSTDMDPRCRF_CUSTOMERNAMERF
            //得意先名称2
            serInfo.MemberInfo.Add( typeof( string ) ); //CUSTDMDPRCRF_CUSTOMERNAME2RF
            //得意先略称
            serInfo.MemberInfo.Add( typeof( string ) ); //CUSTDMDPRCRF_CUSTOMERSNMRF
            //計上年月日
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //CUSTDMDPRCRF_ADDUPDATERF
            //計上年月
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //CUSTDMDPRCRF_ADDUPYEARMONTHRF
            //前回請求金額
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //CUSTDMDPRCRF_LASTTIMEDEMANDRF
            //今回手数料額（通常入金）
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //CUSTDMDPRCRF_THISTIMEFEEDMDNRMLRF
            //今回値引額（通常入金）
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //CUSTDMDPRCRF_THISTIMEDISDMDNRMLRF
            //今回入金金額（通常入金）
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //CUSTDMDPRCRF_THISTIMEDMDNRMLRF
            //今回繰越残高（請求計）
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //CUSTDMDPRCRF_THISTIMETTLBLCDMDRF
            //相殺後今回売上金額
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //CUSTDMDPRCRF_OFSTHISTIMESALESRF
            //相殺後今回売上消費税
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //CUSTDMDPRCRF_OFSTHISSALESTAXRF
            //相殺後外税対象額
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //CUSTDMDPRCRF_ITDEDOFFSETOUTTAXRF
            //相殺後内税対象額
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //CUSTDMDPRCRF_ITDEDOFFSETINTAXRF
            //相殺後非課税対象額
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //CUSTDMDPRCRF_ITDEDOFFSETTAXFREERF
            //相殺後外税消費税
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //CUSTDMDPRCRF_OFFSETOUTTAXRF
            //相殺後内税消費税
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //CUSTDMDPRCRF_OFFSETINTAXRF
            //今回売上金額
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //CUSTDMDPRCRF_THISTIMESALESRF
            //今回売上消費税
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //CUSTDMDPRCRF_THISSALESTAXRF
            //売上外税対象額
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //CUSTDMDPRCRF_ITDEDSALESOUTTAXRF
            //売上内税対象額
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //CUSTDMDPRCRF_ITDEDSALESINTAXRF
            //売上非課税対象額
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //CUSTDMDPRCRF_ITDEDSALESTAXFREERF
            //売上外税額
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //CUSTDMDPRCRF_SALESOUTTAXRF
            //売上内税額
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //CUSTDMDPRCRF_SALESINTAXRF
            //今回売上返品金額
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //CUSTDMDPRCRF_THISSALESPRICRGDSRF
            //今回売上返品消費税
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //CUSTDMDPRCRF_THISSALESPRCTAXRGDSRF
            //返品外税対象額合計
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //CUSTDMDPRCRF_TTLITDEDRETOUTTAXRF
            //返品内税対象額合計
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //CUSTDMDPRCRF_TTLITDEDRETINTAXRF
            //返品非課税対象額合計
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //CUSTDMDPRCRF_TTLITDEDRETTAXFREERF
            //返品外税額合計
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //CUSTDMDPRCRF_TTLRETOUTERTAXRF
            //返品内税額合計
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //CUSTDMDPRCRF_TTLRETINNERTAXRF
            //今回売上値引金額
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //CUSTDMDPRCRF_THISSALESPRICDISRF
            //今回売上値引消費税
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //CUSTDMDPRCRF_THISSALESPRCTAXDISRF
            //値引外税対象額合計
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //CUSTDMDPRCRF_TTLITDEDDISOUTTAXRF
            //値引内税対象額合計
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //CUSTDMDPRCRF_TTLITDEDDISINTAXRF
            //値引非課税対象額合計
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //CUSTDMDPRCRF_TTLITDEDDISTAXFREERF
            //値引外税額合計
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //CUSTDMDPRCRF_TTLDISOUTERTAXRF
            //値引内税額合計
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //CUSTDMDPRCRF_TTLDISINNERTAXRF
            //消費税調整額
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //CUSTDMDPRCRF_TAXADJUSTRF
            //残高調整額
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //CUSTDMDPRCRF_BALANCEADJUSTRF
            //計算後請求金額
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //CUSTDMDPRCRF_AFCALDEMANDPRICERF
            //受注2回前残高（請求計）
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //CUSTDMDPRCRF_ACPODRTTL2TMBFBLDMDRF
            //受注3回前残高（請求計）
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //CUSTDMDPRCRF_ACPODRTTL3TMBFBLDMDRF
            //締次更新開始年月日
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //CUSTDMDPRCRF_STARTCADDUPUPDDATERF
            //売上伝票枚数
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //CUSTDMDPRCRF_SALESSLIPCOUNTRF
            //請求書発行日
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //CUSTDMDPRCRF_BILLPRINTDATERF
            //入金予定日
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //CUSTDMDPRCRF_EXPECTEDDEPOSITDATERF
            //回収条件
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //CUSTDMDPRCRF_COLLECTCONDRF
            //消費税転嫁方式
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //CUSTDMDPRCRF_CONSTAXLAYMETHODRF
            //消費税率
            serInfo.MemberInfo.Add( typeof( Double ) ); //CUSTDMDPRCRF_CONSTAXRATERF
            //拠点ガイド名称
            serInfo.MemberInfo.Add( typeof( string ) ); //SECHED_SECTIONGUIDENMRF
            //拠点ガイド略称
            serInfo.MemberInfo.Add( typeof( string ) ); //SECHED_SECTIONGUIDESNMRF
            //自社名称コード1
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SECHED_COMPANYNAMECD1RF
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
            //画像情報データ
            serInfo.MemberInfo.Add( typeof( Byte[] ) ); //IMAGEINFORF_IMAGEINFODATARF
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
            //得意先郵便番号
            serInfo.MemberInfo.Add( typeof( string ) ); //CSTCST_POSTNORF
            //得意先住所1（都道府県市区郡・町村・字）
            serInfo.MemberInfo.Add( typeof( string ) ); //CSTCST_ADDRESS1RF
            //得意先住所3（番地）
            serInfo.MemberInfo.Add( typeof( string ) ); //CSTCST_ADDRESS3RF
            //得意先住所4（アパート名称）
            serInfo.MemberInfo.Add( typeof( string ) ); //CSTCST_ADDRESS4RF
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
            // --- ADD START 田村顕成 2022/10/18 ----->>>>>
            //売上消費税端数処理コード
            serInfo.MemberInfo.Add(typeof(Int32));      // CSTCLM_SALESCNSTAXFRCPROCCDRF
            // --- ADD END 田村顕成 2022/10/18 -----<<<<<
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
            //請求先郵便番号
            serInfo.MemberInfo.Add( typeof( string ) ); //CSTCLM_POSTNORF
            //請求先住所1（都道府県市区郡・町村・字）
            serInfo.MemberInfo.Add( typeof( string ) ); //CSTCLM_ADDRESS1RF
            //請求先住所3（番地）
            serInfo.MemberInfo.Add( typeof( string ) ); //CSTCLM_ADDRESS3RF
            //請求先住所4（アパート名称）
            serInfo.MemberInfo.Add( typeof( string ) ); //CSTCLM_ADDRESS4RF
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
            //入金設定金種コード1
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //DEPOSITSTRF_DEPOSITSTKINDCD1RF
            //入金設定金種コード2
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //DEPOSITSTRF_DEPOSITSTKINDCD2RF
            //入金設定金種コード3
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //DEPOSITSTRF_DEPOSITSTKINDCD3RF
            //入金設定金種コード4
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //DEPOSITSTRF_DEPOSITSTKINDCD4RF
            //入金設定金種コード5
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //DEPOSITSTRF_DEPOSITSTKINDCD5RF
            //入金設定金種コード6
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //DEPOSITSTRF_DEPOSITSTKINDCD6RF
            //入金設定金種コード7
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //DEPOSITSTRF_DEPOSITSTKINDCD7RF
            //入金設定金種コード8
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //DEPOSITSTRF_DEPOSITSTKINDCD8RF
            //入金設定金種コード9
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //DEPOSITSTRF_DEPOSITSTKINDCD9RF
            //入金設定金種コード10
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //DEPOSITSTRF_DEPOSITSTKINDCD10RF
            //入金金種名称1
            serInfo.MemberInfo.Add( typeof( string ) ); //DEPT01_MONEYKINDNAMERF
            //入金金額1
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //DEPT01_DEPOSITRF
            //入金金種名称2
            serInfo.MemberInfo.Add( typeof( string ) ); //DEPT02_MONEYKINDNAMERF
            //入金金額2
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //DEPT02_DEPOSITRF
            //入金金種名称3
            serInfo.MemberInfo.Add( typeof( string ) ); //DEPT03_MONEYKINDNAMERF
            //入金金額3
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //DEPT03_DEPOSITRF
            //入金金種名称4
            serInfo.MemberInfo.Add( typeof( string ) ); //DEPT04_MONEYKINDNAMERF
            //入金金額4
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //DEPT04_DEPOSITRF
            //入金金種名称5
            serInfo.MemberInfo.Add( typeof( string ) ); //DEPT05_MONEYKINDNAMERF
            //入金金額5
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //DEPT05_DEPOSITRF
            //入金金種名称6
            serInfo.MemberInfo.Add( typeof( string ) ); //DEPT06_MONEYKINDNAMERF
            //入金金額6
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //DEPT06_DEPOSITRF
            //入金金種名称7
            serInfo.MemberInfo.Add( typeof( string ) ); //DEPT07_MONEYKINDNAMERF
            //入金金額7
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //DEPT07_DEPOSITRF
            //入金金種名称8
            serInfo.MemberInfo.Add( typeof( string ) ); //DEPT08_MONEYKINDNAMERF
            //入金金額8
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //DEPT08_DEPOSITRF
            //入金金種名称9
            serInfo.MemberInfo.Add( typeof( string ) ); //DEPT09_MONEYKINDNAMERF
            //入金金額9
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //DEPT09_DEPOSITRF
            //入金金種名称10
            serInfo.MemberInfo.Add( typeof( string ) ); //DEPT10_MONEYKINDNAMERF
            //入金金額10
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //DEPT10_DEPOSITRF
            //計上年月日西暦年
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_ADDUPDATEFYRF
            //計上年月日西暦年略
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_ADDUPDATEFSRF
            //計上年月日和暦年
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_ADDUPDATEFWRF
            //計上年月日月
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_ADDUPDATEFMRF
            //計上年月日日
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_ADDUPDATEFDRF
            //計上年月日元号
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_ADDUPDATEFGRF
            //計上年月日略号
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_ADDUPDATEFRRF
            //計上年月日リテラル(/)
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_ADDUPDATEFLSRF
            //計上年月日リテラル(.)
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_ADDUPDATEFLPRF
            //計上年月日リテラル(年)
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_ADDUPDATEFLYRF
            //計上年月日リテラル(月)
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_ADDUPDATEFLMRF
            //計上年月日リテラル(日)
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_ADDUPDATEFLDRF
            //計上年月西暦年
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_ADDUPYEARMONTHFYRF
            //計上年月西暦年略
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_ADDUPYEARMONTHFSRF
            //計上年月和暦年
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_ADDUPYEARMONTHFWRF
            //計上年月月
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_ADDUPYEARMONTHFMRF
            //計上年月元号
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_ADDUPYEARMONTHFGRF
            //計上年月略号
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_ADDUPYEARMONTHFRRF
            //計上年月リテラル(/)
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_ADDUPYEARMONTHFLSRF
            //計上年月リテラル(.)
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_ADDUPYEARMONTHFLPRF
            //計上年月リテラル(年)
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_ADDUPYEARMONTHFLYRF
            //計上年月リテラル(月)
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_ADDUPYEARMONTHFLMRF
            //締次更新開始年月日西暦年
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_STARTCADDUPUPDDATEFYRF
            //締次更新開始年月日西暦年略
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_STARTCADDUPUPDDATEFSRF
            //締次更新開始年月日和暦年
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_STARTCADDUPUPDDATEFWRF
            //締次更新開始年月日月
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_STARTCADDUPUPDDATEFMRF
            //締次更新開始年月日日
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_STARTCADDUPUPDDATEFDRF
            //締次更新開始年月日元号
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_STARTCADDUPUPDDATEFGRF
            //締次更新開始年月日略号
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_STARTCADDUPUPDDATEFRRF
            //締次更新開始年月日リテラル(/)
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_STARTCADDUPUPDDATEFLSRF
            //締次更新開始年月日リテラル(.)
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_STARTCADDUPUPDDATEFLPRF
            //締次更新開始年月日リテラル(年)
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_STARTCADDUPUPDDATEFLYRF
            //締次更新開始年月日リテラル(月)
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_STARTCADDUPUPDDATEFLMRF
            //締次更新開始年月日リテラル(日)
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_STARTCADDUPUPDDATEFLDRF
            //請求書発行日西暦年
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_BILLPRINTDATEFYRF
            //請求書発行日西暦年略
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_BILLPRINTDATEFSRF
            //請求書発行日和暦年
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_BILLPRINTDATEFWRF
            //請求書発行日月
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_BILLPRINTDATEFMRF
            //請求書発行日日
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_BILLPRINTDATEFDRF
            //請求書発行日元号
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_BILLPRINTDATEFGRF
            //請求書発行日略号
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_BILLPRINTDATEFRRF
            //請求書発行日リテラル(/)
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_BILLPRINTDATEFLSRF
            //請求書発行日リテラル(.)
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_BILLPRINTDATEFLPRF
            //請求書発行日リテラル(年)
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_BILLPRINTDATEFLYRF
            //請求書発行日リテラル(月)
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_BILLPRINTDATEFLMRF
            //請求書発行日リテラル(日)
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_BILLPRINTDATEFLDRF
            //入金予定日西暦年
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_EXPECTEDDEPOSITDATEFYRF
            //入金予定日西暦年略
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_EXPECTEDDEPOSITDATEFSRF
            //入金予定日和暦年
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_EXPECTEDDEPOSITDATEFWRF
            //入金予定日月
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_EXPECTEDDEPOSITDATEFMRF
            //入金予定日日
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_EXPECTEDDEPOSITDATEFDRF
            //入金予定日元号
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_EXPECTEDDEPOSITDATEFGRF
            //入金予定日略号
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_EXPECTEDDEPOSITDATEFRRF
            //入金予定日リテラル(/)
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_EXPECTEDDEPOSITDATEFLSRF
            //入金予定日リテラル(.)
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_EXPECTEDDEPOSITDATEFLPRF
            //入金予定日リテラル(年)
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_EXPECTEDDEPOSITDATEFLYRF
            //入金予定日リテラル(月)
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_EXPECTEDDEPOSITDATEFLMRF
            //入金予定日リテラル(日)
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_EXPECTEDDEPOSITDATEFLDRF
            //回収条件名称
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_COLLECTCONDNMRF
            //請求書タイトル
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_DMDFORMTITLERF
            //請求書タイトル２
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_DMDFORMTITLE2RF
            //請求書コメント１
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_DMDFORMCOMENT1RF
            //請求書コメント２
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_DMDFORMCOMENT2RF
            //請求書コメント３
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_DMDFORMCOMENT3RF
            //入金金額(値引除く)
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //HADD_DMDNRMLEXDISRF
            //入金金額(手数料除く)
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //HADD_DMDNRMLEXFEERF
            //入金金額(値引・手数料除く)
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //HADD_DMDNRMLEXDISFEERF
            //入金金額(値引＋手数料)
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //HADD_DMDNRMLSAMDISFEERF
            //今回売上額(税抜)
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //HADD_THISSALESANDADJUSTRF
            //今回売上消費税
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //HADD_THISTAXANDADJUSTRF
            //入力発行日付
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_ISSUEDAYRF
            //入力発行日付西暦年
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_ISSUEDAYFYRF
            //入力発行日付西暦年略
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_ISSUEDAYFSRF
            //入力発行日付和暦年
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_ISSUEDAYFWRF
            //入力発行日付月
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_ISSUEDAYFMRF
            //入力発行日付日
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_ISSUEDAYFDRF
            //入力発行日付元号
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_ISSUEDAYFGRF
            //入力発行日付略号
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_ISSUEDAYFRRF
            //入力発行日付リテラル(/)
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_ISSUEDAYFLSRF
            //入力発行日付リテラル(.)
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_ISSUEDAYFLPRF
            //入力発行日付リテラル(年)
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_ISSUEDAYFLYRF
            //入力発行日付リテラル(月)
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_ISSUEDAYFLMRF
            //入力発行日付リテラル(日)
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_ISSUEDAYFLDRF
            //印刷得意先サブコード
            serInfo.MemberInfo.Add( typeof( string ) ); //CADD_CUSTOMERSUBCODERF
            //印刷得意先名称
            serInfo.MemberInfo.Add( typeof( string ) ); //CADD_NAMERF
            //印刷得意先名称2
            serInfo.MemberInfo.Add( typeof( string ) ); //CADD_NAME2RF
            //印刷得意先敬称
            serInfo.MemberInfo.Add( typeof( string ) ); //CADD_HONORIFICTITLERF
            //印刷得意先カナ
            serInfo.MemberInfo.Add( typeof( string ) ); //CADD_KANARF
            //印刷得意先略称
            serInfo.MemberInfo.Add( typeof( string ) ); //CADD_CUSTOMERSNMRF
            //印刷得意先諸口コード
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //CADD_OUTPUTNAMECODERF
            //印刷得意先郵便番号
            serInfo.MemberInfo.Add( typeof( string ) ); //CADD_POSTNORF
            //印刷得意先住所1（都道府県市区郡・町村・字）
            serInfo.MemberInfo.Add( typeof( string ) ); //CADD_ADDRESS1RF
            //印刷得意先住所3（番地）
            serInfo.MemberInfo.Add( typeof( string ) ); //CADD_ADDRESS3RF
            //印刷得意先住所4（アパート名称）
            serInfo.MemberInfo.Add( typeof( string ) ); //CADD_ADDRESS4RF
            //印刷得意先分析コード1
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //CADD_CUSTANALYSCODE1RF
            //印刷得意先分析コード2
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //CADD_CUSTANALYSCODE2RF
            //印刷得意先分析コード3
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //CADD_CUSTANALYSCODE3RF
            //印刷得意先分析コード4
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //CADD_CUSTANALYSCODE4RF
            //印刷得意先分析コード5
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //CADD_CUSTANALYSCODE5RF
            //印刷得意先分析コード6
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //CADD_CUSTANALYSCODE6RF
            //印刷得意先備考1
            serInfo.MemberInfo.Add( typeof( string ) ); //CADD_NOTE1RF
            //印刷得意先備考2
            serInfo.MemberInfo.Add( typeof( string ) ); //CADD_NOTE2RF
            //印刷得意先備考3
            serInfo.MemberInfo.Add( typeof( string ) ); //CADD_NOTE3RF
            //印刷得意先備考4
            serInfo.MemberInfo.Add( typeof( string ) ); //CADD_NOTE4RF
            //印刷得意先備考5
            serInfo.MemberInfo.Add( typeof( string ) ); //CADD_NOTE5RF
            //印刷得意先備考6
            serInfo.MemberInfo.Add( typeof( string ) ); //CADD_NOTE6RF
            //印刷得意先備考7
            serInfo.MemberInfo.Add( typeof( string ) ); //CADD_NOTE7RF
            //印刷得意先備考8
            serInfo.MemberInfo.Add( typeof( string ) ); //CADD_NOTE8RF
            //印刷得意先備考9
            serInfo.MemberInfo.Add( typeof( string ) ); //CADD_NOTE9RF
            //印刷得意先備考10
            serInfo.MemberInfo.Add( typeof( string ) ); //CADD_NOTE10RF
            //印刷用得意先名称（上段）
            serInfo.MemberInfo.Add( typeof( string ) ); //CADD_PRINTCUSTOMERNAME1RF
            //印刷用得意先名称（下段）
            serInfo.MemberInfo.Add( typeof( string ) ); //CADD_PRINTCUSTOMERNAME2RF
            //印刷用得意先名称（下段）＋敬称
            serInfo.MemberInfo.Add( typeof( string ) ); //CADD_PRINTCUSTOMERNAME2HNRF
            //集金月区分名称
            serInfo.MemberInfo.Add( typeof( string ) ); //CSTCST_COLLECTMONEYNAMERF
            //集金日
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //CSTCST_COLLECTMONEYDAYRF
            //印刷得意先コード
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //CADD_CUSTOMERCODERF
            //印刷得意先電話番号（自宅）
            serInfo.MemberInfo.Add( typeof( string ) ); //CADD_HOMETELNORF
            //印刷得意先電話番号（勤務先）
            serInfo.MemberInfo.Add( typeof( string ) ); //CADD_OFFICETELNORF
            //印刷得意先電話番号（携帯）
            serInfo.MemberInfo.Add( typeof( string ) ); //CADD_PORTABLETELNORF
            //印刷得意先FAX番号（自宅）
            serInfo.MemberInfo.Add( typeof( string ) ); //CADD_HOMEFAXNORF
            //印刷得意先FAX番号（勤務先）
            serInfo.MemberInfo.Add( typeof( string ) ); //CADD_OFFICEFAXNORF
            //印刷得意先電話番号（その他）
            serInfo.MemberInfo.Add( typeof( string ) ); //CADD_OTHERSTELNORF
            //得意先電話番号（自宅）
            serInfo.MemberInfo.Add( typeof( string ) ); //CSTCST_HOMETELNORF
            //得意先電話番号（勤務先）
            serInfo.MemberInfo.Add( typeof( string ) ); //CSTCST_OFFICETELNORF
            //得意先電話番号（携帯）
            serInfo.MemberInfo.Add( typeof( string ) ); //CSTCST_PORTABLETELNORF
            //得意先FAX番号（自宅）
            serInfo.MemberInfo.Add( typeof( string ) ); //CSTCST_HOMEFAXNORF
            //得意先FAX番号（勤務先）
            serInfo.MemberInfo.Add( typeof( string ) ); //CSTCST_OFFICEFAXNORF
            //得意先電話番号（その他）
            serInfo.MemberInfo.Add( typeof( string ) ); //CSTCST_OTHERSTELNORF
            //請求先電話番号（自宅）
            serInfo.MemberInfo.Add( typeof( string ) ); //CSTCLM_HOMETELNORF
            //請求先電話番号（勤務先）
            serInfo.MemberInfo.Add( typeof( string ) ); //CSTCLM_OFFICETELNORF
            //請求先電話番号（携帯）
            serInfo.MemberInfo.Add( typeof( string ) ); //CSTCLM_PORTABLETELNORF
            //請求先FAX番号（自宅）
            serInfo.MemberInfo.Add( typeof( string ) ); //CSTCLM_HOMEFAXNORF
            //請求先FAX番号（勤務先）
            serInfo.MemberInfo.Add( typeof( string ) ); //CSTCLM_OFFICEFAXNORF
            //請求先電話番号（その他）
            serInfo.MemberInfo.Add( typeof( string ) ); //CSTCLM_OTHERSTELNORF
            //今回売上額(税込)
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //HADD_THISSALESANDADJUSTTAXINCRF
            //請求先集金月区分名称
            serInfo.MemberInfo.Add( typeof( string ) ); //CSTCLM_COLLECTMONEYNAMERF
            //請求先集金日
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //CSTCLM_COLLECTMONEYDAYRF
            //実績拠点コード
            serInfo.MemberInfo.Add( typeof( string ) ); //CUSTDMDPRCRF_RESULTSSECTCDRF
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
            //自宅TEL表示名称
            serInfo.MemberInfo.Add( typeof( string ) ); //ALITMDSPNMRF_HOMETELNODSPNAMERF
            //勤務先TEL表示名称
            serInfo.MemberInfo.Add( typeof( string ) ); //ALITMDSPNMRF_OFFICETELNODSPNAMERF
            //携帯TEL表示名称
            serInfo.MemberInfo.Add( typeof( string ) ); //ALITMDSPNMRF_MOBILETELNODSPNAMERF
            //自宅FAX表示名称
            serInfo.MemberInfo.Add( typeof( string ) ); //ALITMDSPNMRF_HOMEFAXNODSPNAMERF
            //勤務先FAX表示名称
            serInfo.MemberInfo.Add( typeof( string ) ); //ALITMDSPNMRF_OFFICEFAXNODSPNAMERF
            //その他TEL表示名称
            serInfo.MemberInfo.Add( typeof( string ) ); //ALITMDSPNMRF_OTHERTELNODSPNAMERF
            //販売エリアコード
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //CSTCLM_SALESAREACODERF
            //顧客担当従業員コード
            serInfo.MemberInfo.Add( typeof( string ) ); //CSTCLM_CUSTOMERAGENTCDRF
            //集金担当従業員コード
            serInfo.MemberInfo.Add( typeof( string ) ); //CSTCLM_BILLCOLLECTERCDRF
            //旧顧客担当従業員コード
            serInfo.MemberInfo.Add( typeof( string ) ); //CSTCLM_OLDCUSTOMERAGENTCDRF
            //顧客担当変更日
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //CSTCLM_CUSTAGENTCHGDATERF
            //請求書番号
            serInfo.MemberInfo.Add(typeof(Int32)); //CUSTDMDPRCRF_BILLNORF
            //集金月区分コード
            serInfo.MemberInfo.Add(typeof(Int32)); //CSTCST_COLLECTMONEYCODERF

            //請求先集金月区分コード
            serInfo.MemberInfo.Add(typeof(Int32)); //CSTCLM_COLLECTMONEYCODERF

            //締日
            serInfo.MemberInfo.Add(typeof(Int32)); //CSTCLM_TOTALDAYRF

            // 税率1タイトル
            serInfo.MemberInfo.Add(typeof(string)); //TtitleTaxRate1
            // 税率2タイトル
            serInfo.MemberInfo.Add(typeof(string)); //TtitleTaxRate2
            // 税率(1)対象金額合計(税抜き)
            serInfo.MemberInfo.Add(typeof(Double)); //TotalThisTimeSalesTaxExRate1
            // 税率(2)対象金額合計(税抜き)
            serInfo.MemberInfo.Add(typeof(Double)); //TotalThisTimeSalesTaxExRate2
            // 税額(1)
            serInfo.MemberInfo.Add(typeof(Double)); //TotalThisTimeTaxRate1
            // 税額(2)
            serInfo.MemberInfo.Add(typeof(Double)); //TotalThisTimeTaxRate2


            serInfo.Serialize( writer, serInfo );
            if ( graph is EBooksFrePBillHeadWork )
            {
                EBooksFrePBillHeadWork temp = (EBooksFrePBillHeadWork)graph;

                SetEBooksFrePBillHeadWork( writer, temp );
            }
            else
            {
                ArrayList lst = null;
                if ( graph is EBooksFrePBillHeadWork[] )
                {
                    lst = new ArrayList();
                    lst.AddRange( (EBooksFrePBillHeadWork[])graph );
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach ( EBooksFrePBillHeadWork temp in lst )
                {
                    SetEBooksFrePBillHeadWork( writer, temp );
                }

            }


        }


        /// <summary>
        /// EBooksFrePBillHeadWorkメンバ数(publicプロパティ数)
        /// </summary>
        //private const int currentMemberCount = 345; // --- DEL 田村顕成 2022/10/18
        private const int currentMemberCount = 346; // --- ADD 田村顕成 2022/10/18

        /// <summary>
        ///  EBooksFrePBillHeadWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   EBooksFrePBillHeadWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// <br>Update Note      : 2022/10/18 田村顕成</br>
        /// <br>管理番号         : 11870141-00 インボイス残対応（軽減税率対応）</br>
        /// </remarks>
        private void SetEBooksFrePBillHeadWork( System.IO.BinaryWriter writer, EBooksFrePBillHeadWork temp )
        {
            //計上拠点コード
            writer.Write( temp.CUSTDMDPRCRF_ADDUPSECCODERF );
            //請求先コード
            writer.Write( temp.CUSTDMDPRCRF_CLAIMCODERF );
            //請求先名称
            writer.Write( temp.CUSTDMDPRCRF_CLAIMNAMERF );
            //請求先名称2
            writer.Write( temp.CUSTDMDPRCRF_CLAIMNAME2RF );
            //請求先略称
            writer.Write( temp.CUSTDMDPRCRF_CLAIMSNMRF );
            //得意先コード
            writer.Write( temp.CUSTDMDPRCRF_CUSTOMERCODERF );
            //得意先名称
            writer.Write( temp.CUSTDMDPRCRF_CUSTOMERNAMERF );
            //得意先名称2
            writer.Write( temp.CUSTDMDPRCRF_CUSTOMERNAME2RF );
            //得意先略称
            writer.Write( temp.CUSTDMDPRCRF_CUSTOMERSNMRF );
            //計上年月日
            writer.Write( temp.CUSTDMDPRCRF_ADDUPDATERF );
            //計上年月
            writer.Write( temp.CUSTDMDPRCRF_ADDUPYEARMONTHRF );
            //前回請求金額
            writer.Write( temp.CUSTDMDPRCRF_LASTTIMEDEMANDRF );
            //今回手数料額（通常入金）
            writer.Write( temp.CUSTDMDPRCRF_THISTIMEFEEDMDNRMLRF );
            //今回値引額（通常入金）
            writer.Write( temp.CUSTDMDPRCRF_THISTIMEDISDMDNRMLRF );
            //今回入金金額（通常入金）
            writer.Write( temp.CUSTDMDPRCRF_THISTIMEDMDNRMLRF );
            //今回繰越残高（請求計）
            writer.Write( temp.CUSTDMDPRCRF_THISTIMETTLBLCDMDRF );
            //相殺後今回売上金額
            writer.Write( temp.CUSTDMDPRCRF_OFSTHISTIMESALESRF );
            //相殺後今回売上消費税
            writer.Write( temp.CUSTDMDPRCRF_OFSTHISSALESTAXRF );
            //相殺後外税対象額
            writer.Write( temp.CUSTDMDPRCRF_ITDEDOFFSETOUTTAXRF );
            //相殺後内税対象額
            writer.Write( temp.CUSTDMDPRCRF_ITDEDOFFSETINTAXRF );
            //相殺後非課税対象額
            writer.Write( temp.CUSTDMDPRCRF_ITDEDOFFSETTAXFREERF );
            //相殺後外税消費税
            writer.Write( temp.CUSTDMDPRCRF_OFFSETOUTTAXRF );
            //相殺後内税消費税
            writer.Write( temp.CUSTDMDPRCRF_OFFSETINTAXRF );
            //今回売上金額
            writer.Write( temp.CUSTDMDPRCRF_THISTIMESALESRF );
            //今回売上消費税
            writer.Write( temp.CUSTDMDPRCRF_THISSALESTAXRF );
            //売上外税対象額
            writer.Write( temp.CUSTDMDPRCRF_ITDEDSALESOUTTAXRF );
            //売上内税対象額
            writer.Write( temp.CUSTDMDPRCRF_ITDEDSALESINTAXRF );
            //売上非課税対象額
            writer.Write( temp.CUSTDMDPRCRF_ITDEDSALESTAXFREERF );
            //売上外税額
            writer.Write( temp.CUSTDMDPRCRF_SALESOUTTAXRF );
            //売上内税額
            writer.Write( temp.CUSTDMDPRCRF_SALESINTAXRF );
            //今回売上返品金額
            writer.Write( temp.CUSTDMDPRCRF_THISSALESPRICRGDSRF );
            //今回売上返品消費税
            writer.Write( temp.CUSTDMDPRCRF_THISSALESPRCTAXRGDSRF );
            //返品外税対象額合計
            writer.Write( temp.CUSTDMDPRCRF_TTLITDEDRETOUTTAXRF );
            //返品内税対象額合計
            writer.Write( temp.CUSTDMDPRCRF_TTLITDEDRETINTAXRF );
            //返品非課税対象額合計
            writer.Write( temp.CUSTDMDPRCRF_TTLITDEDRETTAXFREERF );
            //返品外税額合計
            writer.Write( temp.CUSTDMDPRCRF_TTLRETOUTERTAXRF );
            //返品内税額合計
            writer.Write( temp.CUSTDMDPRCRF_TTLRETINNERTAXRF );
            //今回売上値引金額
            writer.Write( temp.CUSTDMDPRCRF_THISSALESPRICDISRF );
            //今回売上値引消費税
            writer.Write( temp.CUSTDMDPRCRF_THISSALESPRCTAXDISRF );
            //値引外税対象額合計
            writer.Write( temp.CUSTDMDPRCRF_TTLITDEDDISOUTTAXRF );
            //値引内税対象額合計
            writer.Write( temp.CUSTDMDPRCRF_TTLITDEDDISINTAXRF );
            //値引非課税対象額合計
            writer.Write( temp.CUSTDMDPRCRF_TTLITDEDDISTAXFREERF );
            //値引外税額合計
            writer.Write( temp.CUSTDMDPRCRF_TTLDISOUTERTAXRF );
            //値引内税額合計
            writer.Write( temp.CUSTDMDPRCRF_TTLDISINNERTAXRF );
            //消費税調整額
            writer.Write( temp.CUSTDMDPRCRF_TAXADJUSTRF );
            //残高調整額
            writer.Write( temp.CUSTDMDPRCRF_BALANCEADJUSTRF );
            //計算後請求金額
            writer.Write( temp.CUSTDMDPRCRF_AFCALDEMANDPRICERF );
            //受注2回前残高（請求計）
            writer.Write( temp.CUSTDMDPRCRF_ACPODRTTL2TMBFBLDMDRF );
            //受注3回前残高（請求計）
            writer.Write( temp.CUSTDMDPRCRF_ACPODRTTL3TMBFBLDMDRF );
            //締次更新開始年月日
            writer.Write( temp.CUSTDMDPRCRF_STARTCADDUPUPDDATERF );
            //売上伝票枚数
            writer.Write( temp.CUSTDMDPRCRF_SALESSLIPCOUNTRF );
            //請求書発行日
            writer.Write( temp.CUSTDMDPRCRF_BILLPRINTDATERF );
            //入金予定日
            writer.Write( temp.CUSTDMDPRCRF_EXPECTEDDEPOSITDATERF );
            //回収条件
            writer.Write( temp.CUSTDMDPRCRF_COLLECTCONDRF );
            //消費税転嫁方式
            writer.Write( temp.CUSTDMDPRCRF_CONSTAXLAYMETHODRF );
            //消費税率
            writer.Write( temp.CUSTDMDPRCRF_CONSTAXRATERF );
            //拠点ガイド名称
            writer.Write( temp.SECHED_SECTIONGUIDENMRF );
            //拠点ガイド略称
            writer.Write( temp.SECHED_SECTIONGUIDESNMRF );
            //自社名称コード1
            writer.Write( temp.SECHED_COMPANYNAMECD1RF );
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
            //画像情報データ
            writer.Write( temp.IMAGEINFORF_IMAGEINFODATARF );
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
            //得意先郵便番号
            writer.Write( temp.CSTCST_POSTNORF );
            //得意先住所1（都道府県市区郡・町村・字）
            writer.Write( temp.CSTCST_ADDRESS1RF );
            //得意先住所3（番地）
            writer.Write( temp.CSTCST_ADDRESS3RF );
            //得意先住所4（アパート名称）
            writer.Write( temp.CSTCST_ADDRESS4RF );
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
            // --- ADD START 田村顕成 2022/10/18 ----->>>>>
            //売上消費税端数処理コード
            writer.Write(temp.CSTCLM_SALESCNSTAXFRCPROCCDRF);
            // --- ADD END 田村顕成 2022/10/18 -----<<<<<
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
            //請求先郵便番号
            writer.Write( temp.CSTCLM_POSTNORF );
            //請求先住所1（都道府県市区郡・町村・字）
            writer.Write( temp.CSTCLM_ADDRESS1RF );
            //請求先住所3（番地）
            writer.Write( temp.CSTCLM_ADDRESS3RF );
            //請求先住所4（アパート名称）
            writer.Write( temp.CSTCLM_ADDRESS4RF );
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
            //入金設定金種コード1
            writer.Write( temp.DEPOSITSTRF_DEPOSITSTKINDCD1RF );
            //入金設定金種コード2
            writer.Write( temp.DEPOSITSTRF_DEPOSITSTKINDCD2RF );
            //入金設定金種コード3
            writer.Write( temp.DEPOSITSTRF_DEPOSITSTKINDCD3RF );
            //入金設定金種コード4
            writer.Write( temp.DEPOSITSTRF_DEPOSITSTKINDCD4RF );
            //入金設定金種コード5
            writer.Write( temp.DEPOSITSTRF_DEPOSITSTKINDCD5RF );
            //入金設定金種コード6
            writer.Write( temp.DEPOSITSTRF_DEPOSITSTKINDCD6RF );
            //入金設定金種コード7
            writer.Write( temp.DEPOSITSTRF_DEPOSITSTKINDCD7RF );
            //入金設定金種コード8
            writer.Write( temp.DEPOSITSTRF_DEPOSITSTKINDCD8RF );
            //入金設定金種コード9
            writer.Write( temp.DEPOSITSTRF_DEPOSITSTKINDCD9RF );
            //入金設定金種コード10
            writer.Write( temp.DEPOSITSTRF_DEPOSITSTKINDCD10RF );
            //入金金種名称1
            writer.Write( temp.DEPT01_MONEYKINDNAMERF );
            //入金金額1
            writer.Write( temp.DEPT01_DEPOSITRF );
            //入金金種名称2
            writer.Write( temp.DEPT02_MONEYKINDNAMERF );
            //入金金額2
            writer.Write( temp.DEPT02_DEPOSITRF );
            //入金金種名称3
            writer.Write( temp.DEPT03_MONEYKINDNAMERF );
            //入金金額3
            writer.Write( temp.DEPT03_DEPOSITRF );
            //入金金種名称4
            writer.Write( temp.DEPT04_MONEYKINDNAMERF );
            //入金金額4
            writer.Write( temp.DEPT04_DEPOSITRF );
            //入金金種名称5
            writer.Write( temp.DEPT05_MONEYKINDNAMERF );
            //入金金額5
            writer.Write( temp.DEPT05_DEPOSITRF );
            //入金金種名称6
            writer.Write( temp.DEPT06_MONEYKINDNAMERF );
            //入金金額6
            writer.Write( temp.DEPT06_DEPOSITRF );
            //入金金種名称7
            writer.Write( temp.DEPT07_MONEYKINDNAMERF );
            //入金金額7
            writer.Write( temp.DEPT07_DEPOSITRF );
            //入金金種名称8
            writer.Write( temp.DEPT08_MONEYKINDNAMERF );
            //入金金額8
            writer.Write( temp.DEPT08_DEPOSITRF );
            //入金金種名称9
            writer.Write( temp.DEPT09_MONEYKINDNAMERF );
            //入金金額9
            writer.Write( temp.DEPT09_DEPOSITRF );
            //入金金種名称10
            writer.Write( temp.DEPT10_MONEYKINDNAMERF );
            //入金金額10
            writer.Write( temp.DEPT10_DEPOSITRF );
            //計上年月日西暦年
            writer.Write( temp.HADD_ADDUPDATEFYRF );
            //計上年月日西暦年略
            writer.Write( temp.HADD_ADDUPDATEFSRF );
            //計上年月日和暦年
            writer.Write( temp.HADD_ADDUPDATEFWRF );
            //計上年月日月
            writer.Write( temp.HADD_ADDUPDATEFMRF );
            //計上年月日日
            writer.Write( temp.HADD_ADDUPDATEFDRF );
            //計上年月日元号
            writer.Write( temp.HADD_ADDUPDATEFGRF );
            //計上年月日略号
            writer.Write( temp.HADD_ADDUPDATEFRRF );
            //計上年月日リテラル(/)
            writer.Write( temp.HADD_ADDUPDATEFLSRF );
            //計上年月日リテラル(.)
            writer.Write( temp.HADD_ADDUPDATEFLPRF );
            //計上年月日リテラル(年)
            writer.Write( temp.HADD_ADDUPDATEFLYRF );
            //計上年月日リテラル(月)
            writer.Write( temp.HADD_ADDUPDATEFLMRF );
            //計上年月日リテラル(日)
            writer.Write( temp.HADD_ADDUPDATEFLDRF );
            //計上年月西暦年
            writer.Write( temp.HADD_ADDUPYEARMONTHFYRF );
            //計上年月西暦年略
            writer.Write( temp.HADD_ADDUPYEARMONTHFSRF );
            //計上年月和暦年
            writer.Write( temp.HADD_ADDUPYEARMONTHFWRF );
            //計上年月月
            writer.Write( temp.HADD_ADDUPYEARMONTHFMRF );
            //計上年月元号
            writer.Write( temp.HADD_ADDUPYEARMONTHFGRF );
            //計上年月略号
            writer.Write( temp.HADD_ADDUPYEARMONTHFRRF );
            //計上年月リテラル(/)
            writer.Write( temp.HADD_ADDUPYEARMONTHFLSRF );
            //計上年月リテラル(.)
            writer.Write( temp.HADD_ADDUPYEARMONTHFLPRF );
            //計上年月リテラル(年)
            writer.Write( temp.HADD_ADDUPYEARMONTHFLYRF );
            //計上年月リテラル(月)
            writer.Write( temp.HADD_ADDUPYEARMONTHFLMRF );
            //締次更新開始年月日西暦年
            writer.Write( temp.HADD_STARTCADDUPUPDDATEFYRF );
            //締次更新開始年月日西暦年略
            writer.Write( temp.HADD_STARTCADDUPUPDDATEFSRF );
            //締次更新開始年月日和暦年
            writer.Write( temp.HADD_STARTCADDUPUPDDATEFWRF );
            //締次更新開始年月日月
            writer.Write( temp.HADD_STARTCADDUPUPDDATEFMRF );
            //締次更新開始年月日日
            writer.Write( temp.HADD_STARTCADDUPUPDDATEFDRF );
            //締次更新開始年月日元号
            writer.Write( temp.HADD_STARTCADDUPUPDDATEFGRF );
            //締次更新開始年月日略号
            writer.Write( temp.HADD_STARTCADDUPUPDDATEFRRF );
            //締次更新開始年月日リテラル(/)
            writer.Write( temp.HADD_STARTCADDUPUPDDATEFLSRF );
            //締次更新開始年月日リテラル(.)
            writer.Write( temp.HADD_STARTCADDUPUPDDATEFLPRF );
            //締次更新開始年月日リテラル(年)
            writer.Write( temp.HADD_STARTCADDUPUPDDATEFLYRF );
            //締次更新開始年月日リテラル(月)
            writer.Write( temp.HADD_STARTCADDUPUPDDATEFLMRF );
            //締次更新開始年月日リテラル(日)
            writer.Write( temp.HADD_STARTCADDUPUPDDATEFLDRF );
            //請求書発行日西暦年
            writer.Write( temp.HADD_BILLPRINTDATEFYRF );
            //請求書発行日西暦年略
            writer.Write( temp.HADD_BILLPRINTDATEFSRF );
            //請求書発行日和暦年
            writer.Write( temp.HADD_BILLPRINTDATEFWRF );
            //請求書発行日月
            writer.Write( temp.HADD_BILLPRINTDATEFMRF );
            //請求書発行日日
            writer.Write( temp.HADD_BILLPRINTDATEFDRF );
            //請求書発行日元号
            writer.Write( temp.HADD_BILLPRINTDATEFGRF );
            //請求書発行日略号
            writer.Write( temp.HADD_BILLPRINTDATEFRRF );
            //請求書発行日リテラル(/)
            writer.Write( temp.HADD_BILLPRINTDATEFLSRF );
            //請求書発行日リテラル(.)
            writer.Write( temp.HADD_BILLPRINTDATEFLPRF );
            //請求書発行日リテラル(年)
            writer.Write( temp.HADD_BILLPRINTDATEFLYRF );
            //請求書発行日リテラル(月)
            writer.Write( temp.HADD_BILLPRINTDATEFLMRF );
            //請求書発行日リテラル(日)
            writer.Write( temp.HADD_BILLPRINTDATEFLDRF );
            //入金予定日西暦年
            writer.Write( temp.HADD_EXPECTEDDEPOSITDATEFYRF );
            //入金予定日西暦年略
            writer.Write( temp.HADD_EXPECTEDDEPOSITDATEFSRF );
            //入金予定日和暦年
            writer.Write( temp.HADD_EXPECTEDDEPOSITDATEFWRF );
            //入金予定日月
            writer.Write( temp.HADD_EXPECTEDDEPOSITDATEFMRF );
            //入金予定日日
            writer.Write( temp.HADD_EXPECTEDDEPOSITDATEFDRF );
            //入金予定日元号
            writer.Write( temp.HADD_EXPECTEDDEPOSITDATEFGRF );
            //入金予定日略号
            writer.Write( temp.HADD_EXPECTEDDEPOSITDATEFRRF );
            //入金予定日リテラル(/)
            writer.Write( temp.HADD_EXPECTEDDEPOSITDATEFLSRF );
            //入金予定日リテラル(.)
            writer.Write( temp.HADD_EXPECTEDDEPOSITDATEFLPRF );
            //入金予定日リテラル(年)
            writer.Write( temp.HADD_EXPECTEDDEPOSITDATEFLYRF );
            //入金予定日リテラル(月)
            writer.Write( temp.HADD_EXPECTEDDEPOSITDATEFLMRF );
            //入金予定日リテラル(日)
            writer.Write( temp.HADD_EXPECTEDDEPOSITDATEFLDRF );
            //回収条件名称
            writer.Write( temp.HADD_COLLECTCONDNMRF );
            //請求書タイトル
            writer.Write( temp.HADD_DMDFORMTITLERF );
            //請求書タイトル２
            writer.Write( temp.HADD_DMDFORMTITLE2RF );
            //請求書コメント１
            writer.Write( temp.HADD_DMDFORMCOMENT1RF );
            //請求書コメント２
            writer.Write( temp.HADD_DMDFORMCOMENT2RF );
            //請求書コメント３
            writer.Write( temp.HADD_DMDFORMCOMENT3RF );
            //入金金額(値引除く)
            writer.Write( temp.HADD_DMDNRMLEXDISRF );
            //入金金額(手数料除く)
            writer.Write( temp.HADD_DMDNRMLEXFEERF );
            //入金金額(値引・手数料除く)
            writer.Write( temp.HADD_DMDNRMLEXDISFEERF );
            //入金金額(値引＋手数料)
            writer.Write( temp.HADD_DMDNRMLSAMDISFEERF );
            //今回売上額(税抜)
            writer.Write( temp.HADD_THISSALESANDADJUSTRF );
            //今回売上消費税
            writer.Write( temp.HADD_THISTAXANDADJUSTRF );
            //入力発行日付
            writer.Write( temp.HADD_ISSUEDAYRF );
            //入力発行日付西暦年
            writer.Write( temp.HADD_ISSUEDAYFYRF );
            //入力発行日付西暦年略
            writer.Write( temp.HADD_ISSUEDAYFSRF );
            //入力発行日付和暦年
            writer.Write( temp.HADD_ISSUEDAYFWRF );
            //入力発行日付月
            writer.Write( temp.HADD_ISSUEDAYFMRF );
            //入力発行日付日
            writer.Write( temp.HADD_ISSUEDAYFDRF );
            //入力発行日付元号
            writer.Write( temp.HADD_ISSUEDAYFGRF );
            //入力発行日付略号
            writer.Write( temp.HADD_ISSUEDAYFRRF );
            //入力発行日付リテラル(/)
            writer.Write( temp.HADD_ISSUEDAYFLSRF );
            //入力発行日付リテラル(.)
            writer.Write( temp.HADD_ISSUEDAYFLPRF );
            //入力発行日付リテラル(年)
            writer.Write( temp.HADD_ISSUEDAYFLYRF );
            //入力発行日付リテラル(月)
            writer.Write( temp.HADD_ISSUEDAYFLMRF );
            //入力発行日付リテラル(日)
            writer.Write( temp.HADD_ISSUEDAYFLDRF );
            //印刷得意先サブコード
            writer.Write( temp.CADD_CUSTOMERSUBCODERF );
            //印刷得意先名称
            writer.Write( temp.CADD_NAMERF );
            //印刷得意先名称2
            writer.Write( temp.CADD_NAME2RF );
            //印刷得意先敬称
            writer.Write( temp.CADD_HONORIFICTITLERF );
            //印刷得意先カナ
            writer.Write( temp.CADD_KANARF );
            //印刷得意先略称
            writer.Write( temp.CADD_CUSTOMERSNMRF );
            //印刷得意先諸口コード
            writer.Write( temp.CADD_OUTPUTNAMECODERF );
            //印刷得意先郵便番号
            writer.Write( temp.CADD_POSTNORF );
            //印刷得意先住所1（都道府県市区郡・町村・字）
            writer.Write( temp.CADD_ADDRESS1RF );
            //印刷得意先住所3（番地）
            writer.Write( temp.CADD_ADDRESS3RF );
            //印刷得意先住所4（アパート名称）
            writer.Write( temp.CADD_ADDRESS4RF );
            //印刷得意先分析コード1
            writer.Write( temp.CADD_CUSTANALYSCODE1RF );
            //印刷得意先分析コード2
            writer.Write( temp.CADD_CUSTANALYSCODE2RF );
            //印刷得意先分析コード3
            writer.Write( temp.CADD_CUSTANALYSCODE3RF );
            //印刷得意先分析コード4
            writer.Write( temp.CADD_CUSTANALYSCODE4RF );
            //印刷得意先分析コード5
            writer.Write( temp.CADD_CUSTANALYSCODE5RF );
            //印刷得意先分析コード6
            writer.Write( temp.CADD_CUSTANALYSCODE6RF );
            //印刷得意先備考1
            writer.Write( temp.CADD_NOTE1RF );
            //印刷得意先備考2
            writer.Write( temp.CADD_NOTE2RF );
            //印刷得意先備考3
            writer.Write( temp.CADD_NOTE3RF );
            //印刷得意先備考4
            writer.Write( temp.CADD_NOTE4RF );
            //印刷得意先備考5
            writer.Write( temp.CADD_NOTE5RF );
            //印刷得意先備考6
            writer.Write( temp.CADD_NOTE6RF );
            //印刷得意先備考7
            writer.Write( temp.CADD_NOTE7RF );
            //印刷得意先備考8
            writer.Write( temp.CADD_NOTE8RF );
            //印刷得意先備考9
            writer.Write( temp.CADD_NOTE9RF );
            //印刷得意先備考10
            writer.Write( temp.CADD_NOTE10RF );
            //印刷用得意先名称（上段）
            writer.Write( temp.CADD_PRINTCUSTOMERNAME1RF );
            //印刷用得意先名称（下段）
            writer.Write( temp.CADD_PRINTCUSTOMERNAME2RF );
            //印刷用得意先名称（下段）＋敬称
            writer.Write( temp.CADD_PRINTCUSTOMERNAME2HNRF );
            //集金月区分名称
            writer.Write( temp.CSTCST_COLLECTMONEYNAMERF );
            //集金日
            writer.Write( temp.CSTCST_COLLECTMONEYDAYRF );
            //印刷得意先コード
            writer.Write( temp.CADD_CUSTOMERCODERF );
            //印刷得意先電話番号（自宅）
            writer.Write( temp.CADD_HOMETELNORF );
            //印刷得意先電話番号（勤務先）
            writer.Write( temp.CADD_OFFICETELNORF );
            //印刷得意先電話番号（携帯）
            writer.Write( temp.CADD_PORTABLETELNORF );
            //印刷得意先FAX番号（自宅）
            writer.Write( temp.CADD_HOMEFAXNORF );
            //印刷得意先FAX番号（勤務先）
            writer.Write( temp.CADD_OFFICEFAXNORF );
            //印刷得意先電話番号（その他）
            writer.Write( temp.CADD_OTHERSTELNORF );
            //得意先電話番号（自宅）
            writer.Write( temp.CSTCST_HOMETELNORF );
            //得意先電話番号（勤務先）
            writer.Write( temp.CSTCST_OFFICETELNORF );
            //得意先電話番号（携帯）
            writer.Write( temp.CSTCST_PORTABLETELNORF );
            //得意先FAX番号（自宅）
            writer.Write( temp.CSTCST_HOMEFAXNORF );
            //得意先FAX番号（勤務先）
            writer.Write( temp.CSTCST_OFFICEFAXNORF );
            //得意先電話番号（その他）
            writer.Write( temp.CSTCST_OTHERSTELNORF );
            //請求先電話番号（自宅）
            writer.Write( temp.CSTCLM_HOMETELNORF );
            //請求先電話番号（勤務先）
            writer.Write( temp.CSTCLM_OFFICETELNORF );
            //請求先電話番号（携帯）
            writer.Write( temp.CSTCLM_PORTABLETELNORF );
            //請求先FAX番号（自宅）
            writer.Write( temp.CSTCLM_HOMEFAXNORF );
            //請求先FAX番号（勤務先）
            writer.Write( temp.CSTCLM_OFFICEFAXNORF );
            //請求先電話番号（その他）
            writer.Write( temp.CSTCLM_OTHERSTELNORF );
            //今回売上額(税込)
            writer.Write( temp.HADD_THISSALESANDADJUSTTAXINCRF );
            //請求先集金月区分名称
            writer.Write( temp.CSTCLM_COLLECTMONEYNAMERF );
            //請求先集金日
            writer.Write( temp.CSTCLM_COLLECTMONEYDAYRF );
            //実績拠点コード
            writer.Write( temp.CUSTDMDPRCRF_RESULTSSECTCDRF );
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
            //自宅TEL表示名称
            writer.Write( temp.ALITMDSPNMRF_HOMETELNODSPNAMERF );
            //勤務先TEL表示名称
            writer.Write( temp.ALITMDSPNMRF_OFFICETELNODSPNAMERF );
            //携帯TEL表示名称
            writer.Write( temp.ALITMDSPNMRF_MOBILETELNODSPNAMERF );
            //自宅FAX表示名称
            writer.Write( temp.ALITMDSPNMRF_HOMEFAXNODSPNAMERF );
            //勤務先FAX表示名称
            writer.Write( temp.ALITMDSPNMRF_OFFICEFAXNODSPNAMERF );
            //その他TEL表示名称
            writer.Write( temp.ALITMDSPNMRF_OTHERTELNODSPNAMERF );
            //販売エリアコード
            writer.Write( temp.CSTCLM_SALESAREACODERF );
            //顧客担当従業員コード
            writer.Write( temp.CSTCLM_CUSTOMERAGENTCDRF );
            //集金担当従業員コード
            writer.Write( temp.CSTCLM_BILLCOLLECTERCDRF );
            //旧顧客担当従業員コード
            writer.Write( temp.CSTCLM_OLDCUSTOMERAGENTCDRF );
            //顧客担当変更日
            writer.Write( temp.CSTCLM_CUSTAGENTCHGDATERF );
            //請求書番号
            writer.Write(temp.CUSTDMDPRCRF_BILLNORF);
            //集金月区分コード
            writer.Write(temp.CSTCST_COLLECTMONEYCODERF);

            //請求先集金月区分コード
            writer.Write(temp.CSTCLM_COLLECTMONEYCODERF);

            //締日
            writer.Write(temp.CSTCLM_TOTALDAYRF);

            //税率1タイトル
            writer.Write(temp.TitleTaxRate1);
            //税率2タイトル
            writer.Write(temp.TitleTaxRate2);
            // 税率(1)対象金額合計(税抜き)
            writer.Write(temp.TotalThisTimeSalesTaxExRate1);
            // 税率(2)対象金額合計(税抜き)
            writer.Write(temp.TotalThisTimeSalesTaxExRate2);
            // 税額(1)
            writer.Write(temp.TotalThisTimeTaxRate1);
            // 税額(2)
            writer.Write(temp.TotalThisTimeTaxRate2);

        }

        /// <summary>
        ///  EBooksFrePBillHeadWorkインスタンス取得
        /// </summary>
        /// <returns>EBooksFrePBillHeadWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   EBooksFrePBillHeadWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// <br>Update Note  : 2022/10/18 田村顕成</br>
        /// <br>管理番号     : 11870141-00 インボイス残対応（軽減税率対応）</br>
        /// </remarks>
        private EBooksFrePBillHeadWork GetEBooksFrePBillHeadWork( System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo )
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            EBooksFrePBillHeadWork temp = new EBooksFrePBillHeadWork();

            //計上拠点コード
            temp.CUSTDMDPRCRF_ADDUPSECCODERF = reader.ReadString();
            //請求先コード
            temp.CUSTDMDPRCRF_CLAIMCODERF = reader.ReadInt32();
            //請求先名称
            temp.CUSTDMDPRCRF_CLAIMNAMERF = reader.ReadString();
            //請求先名称2
            temp.CUSTDMDPRCRF_CLAIMNAME2RF = reader.ReadString();
            //請求先略称
            temp.CUSTDMDPRCRF_CLAIMSNMRF = reader.ReadString();
            //得意先コード
            temp.CUSTDMDPRCRF_CUSTOMERCODERF = reader.ReadInt32();
            //得意先名称
            temp.CUSTDMDPRCRF_CUSTOMERNAMERF = reader.ReadString();
            //得意先名称2
            temp.CUSTDMDPRCRF_CUSTOMERNAME2RF = reader.ReadString();
            //得意先略称
            temp.CUSTDMDPRCRF_CUSTOMERSNMRF = reader.ReadString();
            //計上年月日
            temp.CUSTDMDPRCRF_ADDUPDATERF = reader.ReadInt32();
            //計上年月
            temp.CUSTDMDPRCRF_ADDUPYEARMONTHRF = reader.ReadInt32();
            //前回請求金額
            temp.CUSTDMDPRCRF_LASTTIMEDEMANDRF = reader.ReadInt64();
            //今回手数料額（通常入金）
            temp.CUSTDMDPRCRF_THISTIMEFEEDMDNRMLRF = reader.ReadInt64();
            //今回値引額（通常入金）
            temp.CUSTDMDPRCRF_THISTIMEDISDMDNRMLRF = reader.ReadInt64();
            //今回入金金額（通常入金）
            temp.CUSTDMDPRCRF_THISTIMEDMDNRMLRF = reader.ReadInt64();
            //今回繰越残高（請求計）
            temp.CUSTDMDPRCRF_THISTIMETTLBLCDMDRF = reader.ReadInt64();
            //相殺後今回売上金額
            temp.CUSTDMDPRCRF_OFSTHISTIMESALESRF = reader.ReadInt64();
            //相殺後今回売上消費税
            temp.CUSTDMDPRCRF_OFSTHISSALESTAXRF = reader.ReadInt64();
            //相殺後外税対象額
            temp.CUSTDMDPRCRF_ITDEDOFFSETOUTTAXRF = reader.ReadInt64();
            //相殺後内税対象額
            temp.CUSTDMDPRCRF_ITDEDOFFSETINTAXRF = reader.ReadInt64();
            //相殺後非課税対象額
            temp.CUSTDMDPRCRF_ITDEDOFFSETTAXFREERF = reader.ReadInt64();
            //相殺後外税消費税
            temp.CUSTDMDPRCRF_OFFSETOUTTAXRF = reader.ReadInt64();
            //相殺後内税消費税
            temp.CUSTDMDPRCRF_OFFSETINTAXRF = reader.ReadInt64();
            //今回売上金額
            temp.CUSTDMDPRCRF_THISTIMESALESRF = reader.ReadInt64();
            //今回売上消費税
            temp.CUSTDMDPRCRF_THISSALESTAXRF = reader.ReadInt64();
            //売上外税対象額
            temp.CUSTDMDPRCRF_ITDEDSALESOUTTAXRF = reader.ReadInt64();
            //売上内税対象額
            temp.CUSTDMDPRCRF_ITDEDSALESINTAXRF = reader.ReadInt64();
            //売上非課税対象額
            temp.CUSTDMDPRCRF_ITDEDSALESTAXFREERF = reader.ReadInt64();
            //売上外税額
            temp.CUSTDMDPRCRF_SALESOUTTAXRF = reader.ReadInt64();
            //売上内税額
            temp.CUSTDMDPRCRF_SALESINTAXRF = reader.ReadInt64();
            //今回売上返品金額
            temp.CUSTDMDPRCRF_THISSALESPRICRGDSRF = reader.ReadInt64();
            //今回売上返品消費税
            temp.CUSTDMDPRCRF_THISSALESPRCTAXRGDSRF = reader.ReadInt64();
            //返品外税対象額合計
            temp.CUSTDMDPRCRF_TTLITDEDRETOUTTAXRF = reader.ReadInt64();
            //返品内税対象額合計
            temp.CUSTDMDPRCRF_TTLITDEDRETINTAXRF = reader.ReadInt64();
            //返品非課税対象額合計
            temp.CUSTDMDPRCRF_TTLITDEDRETTAXFREERF = reader.ReadInt64();
            //返品外税額合計
            temp.CUSTDMDPRCRF_TTLRETOUTERTAXRF = reader.ReadInt64();
            //返品内税額合計
            temp.CUSTDMDPRCRF_TTLRETINNERTAXRF = reader.ReadInt64();
            //今回売上値引金額
            temp.CUSTDMDPRCRF_THISSALESPRICDISRF = reader.ReadInt64();
            //今回売上値引消費税
            temp.CUSTDMDPRCRF_THISSALESPRCTAXDISRF = reader.ReadInt64();
            //値引外税対象額合計
            temp.CUSTDMDPRCRF_TTLITDEDDISOUTTAXRF = reader.ReadInt64();
            //値引内税対象額合計
            temp.CUSTDMDPRCRF_TTLITDEDDISINTAXRF = reader.ReadInt64();
            //値引非課税対象額合計
            temp.CUSTDMDPRCRF_TTLITDEDDISTAXFREERF = reader.ReadInt64();
            //値引外税額合計
            temp.CUSTDMDPRCRF_TTLDISOUTERTAXRF = reader.ReadInt64();
            //値引内税額合計
            temp.CUSTDMDPRCRF_TTLDISINNERTAXRF = reader.ReadInt64();
            //消費税調整額
            temp.CUSTDMDPRCRF_TAXADJUSTRF = reader.ReadInt64();
            //残高調整額
            temp.CUSTDMDPRCRF_BALANCEADJUSTRF = reader.ReadInt64();
            //計算後請求金額
            temp.CUSTDMDPRCRF_AFCALDEMANDPRICERF = reader.ReadInt64();
            //受注2回前残高（請求計）
            temp.CUSTDMDPRCRF_ACPODRTTL2TMBFBLDMDRF = reader.ReadInt64();
            //受注3回前残高（請求計）
            temp.CUSTDMDPRCRF_ACPODRTTL3TMBFBLDMDRF = reader.ReadInt64();
            //締次更新開始年月日
            temp.CUSTDMDPRCRF_STARTCADDUPUPDDATERF = reader.ReadInt32();
            //売上伝票枚数
            temp.CUSTDMDPRCRF_SALESSLIPCOUNTRF = reader.ReadInt32();
            //請求書発行日
            temp.CUSTDMDPRCRF_BILLPRINTDATERF = reader.ReadInt32();
            //入金予定日
            temp.CUSTDMDPRCRF_EXPECTEDDEPOSITDATERF = reader.ReadInt32();
            //回収条件
            temp.CUSTDMDPRCRF_COLLECTCONDRF = reader.ReadInt32();
            //消費税転嫁方式
            temp.CUSTDMDPRCRF_CONSTAXLAYMETHODRF = reader.ReadInt32();
            //消費税率
            temp.CUSTDMDPRCRF_CONSTAXRATERF = reader.ReadDouble();
            //拠点ガイド名称
            temp.SECHED_SECTIONGUIDENMRF = reader.ReadString();
            //拠点ガイド略称
            temp.SECHED_SECTIONGUIDESNMRF = reader.ReadString();
            //自社名称コード1
            temp.SECHED_COMPANYNAMECD1RF = reader.ReadInt32();
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
            //画像情報データ
            //判別不能//IMAGEINFORF_IMAGEINFODATARF
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
            //得意先郵便番号
            temp.CSTCST_POSTNORF = reader.ReadString();
            //得意先住所1（都道府県市区郡・町村・字）
            temp.CSTCST_ADDRESS1RF = reader.ReadString();
            //得意先住所3（番地）
            temp.CSTCST_ADDRESS3RF = reader.ReadString();
            //得意先住所4（アパート名称）
            temp.CSTCST_ADDRESS4RF = reader.ReadString();
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
            // --- ADD START 田村顕成 2022/10/18 ----->>>>>
            //売上消費税端数処理コード
            temp.CSTCLM_SALESCNSTAXFRCPROCCDRF = reader.ReadInt32();
            // --- ADD END 田村顕成 2022/10/18 -----<<<<<
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
            //請求先郵便番号
            temp.CSTCLM_POSTNORF = reader.ReadString();
            //請求先住所1（都道府県市区郡・町村・字）
            temp.CSTCLM_ADDRESS1RF = reader.ReadString();
            //請求先住所3（番地）
            temp.CSTCLM_ADDRESS3RF = reader.ReadString();
            //請求先住所4（アパート名称）
            temp.CSTCLM_ADDRESS4RF = reader.ReadString();
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
            //入金設定金種コード1
            temp.DEPOSITSTRF_DEPOSITSTKINDCD1RF = reader.ReadInt32();
            //入金設定金種コード2
            temp.DEPOSITSTRF_DEPOSITSTKINDCD2RF = reader.ReadInt32();
            //入金設定金種コード3
            temp.DEPOSITSTRF_DEPOSITSTKINDCD3RF = reader.ReadInt32();
            //入金設定金種コード4
            temp.DEPOSITSTRF_DEPOSITSTKINDCD4RF = reader.ReadInt32();
            //入金設定金種コード5
            temp.DEPOSITSTRF_DEPOSITSTKINDCD5RF = reader.ReadInt32();
            //入金設定金種コード6
            temp.DEPOSITSTRF_DEPOSITSTKINDCD6RF = reader.ReadInt32();
            //入金設定金種コード7
            temp.DEPOSITSTRF_DEPOSITSTKINDCD7RF = reader.ReadInt32();
            //入金設定金種コード8
            temp.DEPOSITSTRF_DEPOSITSTKINDCD8RF = reader.ReadInt32();
            //入金設定金種コード9
            temp.DEPOSITSTRF_DEPOSITSTKINDCD9RF = reader.ReadInt32();
            //入金設定金種コード10
            temp.DEPOSITSTRF_DEPOSITSTKINDCD10RF = reader.ReadInt32();
            //入金金種名称1
            temp.DEPT01_MONEYKINDNAMERF = reader.ReadString();
            //入金金額1
            temp.DEPT01_DEPOSITRF = reader.ReadInt64();
            //入金金種名称2
            temp.DEPT02_MONEYKINDNAMERF = reader.ReadString();
            //入金金額2
            temp.DEPT02_DEPOSITRF = reader.ReadInt64();
            //入金金種名称3
            temp.DEPT03_MONEYKINDNAMERF = reader.ReadString();
            //入金金額3
            temp.DEPT03_DEPOSITRF = reader.ReadInt64();
            //入金金種名称4
            temp.DEPT04_MONEYKINDNAMERF = reader.ReadString();
            //入金金額4
            temp.DEPT04_DEPOSITRF = reader.ReadInt64();
            //入金金種名称5
            temp.DEPT05_MONEYKINDNAMERF = reader.ReadString();
            //入金金額5
            temp.DEPT05_DEPOSITRF = reader.ReadInt64();
            //入金金種名称6
            temp.DEPT06_MONEYKINDNAMERF = reader.ReadString();
            //入金金額6
            temp.DEPT06_DEPOSITRF = reader.ReadInt64();
            //入金金種名称7
            temp.DEPT07_MONEYKINDNAMERF = reader.ReadString();
            //入金金額7
            temp.DEPT07_DEPOSITRF = reader.ReadInt64();
            //入金金種名称8
            temp.DEPT08_MONEYKINDNAMERF = reader.ReadString();
            //入金金額8
            temp.DEPT08_DEPOSITRF = reader.ReadInt64();
            //入金金種名称9
            temp.DEPT09_MONEYKINDNAMERF = reader.ReadString();
            //入金金額9
            temp.DEPT09_DEPOSITRF = reader.ReadInt64();
            //入金金種名称10
            temp.DEPT10_MONEYKINDNAMERF = reader.ReadString();
            //入金金額10
            temp.DEPT10_DEPOSITRF = reader.ReadInt64();
            //計上年月日西暦年
            temp.HADD_ADDUPDATEFYRF = reader.ReadInt32();
            //計上年月日西暦年略
            temp.HADD_ADDUPDATEFSRF = reader.ReadInt32();
            //計上年月日和暦年
            temp.HADD_ADDUPDATEFWRF = reader.ReadInt32();
            //計上年月日月
            temp.HADD_ADDUPDATEFMRF = reader.ReadInt32();
            //計上年月日日
            temp.HADD_ADDUPDATEFDRF = reader.ReadInt32();
            //計上年月日元号
            temp.HADD_ADDUPDATEFGRF = reader.ReadString();
            //計上年月日略号
            temp.HADD_ADDUPDATEFRRF = reader.ReadString();
            //計上年月日リテラル(/)
            temp.HADD_ADDUPDATEFLSRF = reader.ReadString();
            //計上年月日リテラル(.)
            temp.HADD_ADDUPDATEFLPRF = reader.ReadString();
            //計上年月日リテラル(年)
            temp.HADD_ADDUPDATEFLYRF = reader.ReadString();
            //計上年月日リテラル(月)
            temp.HADD_ADDUPDATEFLMRF = reader.ReadString();
            //計上年月日リテラル(日)
            temp.HADD_ADDUPDATEFLDRF = reader.ReadString();
            //計上年月西暦年
            temp.HADD_ADDUPYEARMONTHFYRF = reader.ReadInt32();
            //計上年月西暦年略
            temp.HADD_ADDUPYEARMONTHFSRF = reader.ReadInt32();
            //計上年月和暦年
            temp.HADD_ADDUPYEARMONTHFWRF = reader.ReadInt32();
            //計上年月月
            temp.HADD_ADDUPYEARMONTHFMRF = reader.ReadInt32();
            //計上年月元号
            temp.HADD_ADDUPYEARMONTHFGRF = reader.ReadString();
            //計上年月略号
            temp.HADD_ADDUPYEARMONTHFRRF = reader.ReadString();
            //計上年月リテラル(/)
            temp.HADD_ADDUPYEARMONTHFLSRF = reader.ReadString();
            //計上年月リテラル(.)
            temp.HADD_ADDUPYEARMONTHFLPRF = reader.ReadString();
            //計上年月リテラル(年)
            temp.HADD_ADDUPYEARMONTHFLYRF = reader.ReadString();
            //計上年月リテラル(月)
            temp.HADD_ADDUPYEARMONTHFLMRF = reader.ReadString();
            //締次更新開始年月日西暦年
            temp.HADD_STARTCADDUPUPDDATEFYRF = reader.ReadInt32();
            //締次更新開始年月日西暦年略
            temp.HADD_STARTCADDUPUPDDATEFSRF = reader.ReadInt32();
            //締次更新開始年月日和暦年
            temp.HADD_STARTCADDUPUPDDATEFWRF = reader.ReadInt32();
            //締次更新開始年月日月
            temp.HADD_STARTCADDUPUPDDATEFMRF = reader.ReadInt32();
            //締次更新開始年月日日
            temp.HADD_STARTCADDUPUPDDATEFDRF = reader.ReadInt32();
            //締次更新開始年月日元号
            temp.HADD_STARTCADDUPUPDDATEFGRF = reader.ReadString();
            //締次更新開始年月日略号
            temp.HADD_STARTCADDUPUPDDATEFRRF = reader.ReadString();
            //締次更新開始年月日リテラル(/)
            temp.HADD_STARTCADDUPUPDDATEFLSRF = reader.ReadString();
            //締次更新開始年月日リテラル(.)
            temp.HADD_STARTCADDUPUPDDATEFLPRF = reader.ReadString();
            //締次更新開始年月日リテラル(年)
            temp.HADD_STARTCADDUPUPDDATEFLYRF = reader.ReadString();
            //締次更新開始年月日リテラル(月)
            temp.HADD_STARTCADDUPUPDDATEFLMRF = reader.ReadString();
            //締次更新開始年月日リテラル(日)
            temp.HADD_STARTCADDUPUPDDATEFLDRF = reader.ReadString();
            //請求書発行日西暦年
            temp.HADD_BILLPRINTDATEFYRF = reader.ReadInt32();
            //請求書発行日西暦年略
            temp.HADD_BILLPRINTDATEFSRF = reader.ReadInt32();
            //請求書発行日和暦年
            temp.HADD_BILLPRINTDATEFWRF = reader.ReadInt32();
            //請求書発行日月
            temp.HADD_BILLPRINTDATEFMRF = reader.ReadInt32();
            //請求書発行日日
            temp.HADD_BILLPRINTDATEFDRF = reader.ReadInt32();
            //請求書発行日元号
            temp.HADD_BILLPRINTDATEFGRF = reader.ReadString();
            //請求書発行日略号
            temp.HADD_BILLPRINTDATEFRRF = reader.ReadString();
            //請求書発行日リテラル(/)
            temp.HADD_BILLPRINTDATEFLSRF = reader.ReadString();
            //請求書発行日リテラル(.)
            temp.HADD_BILLPRINTDATEFLPRF = reader.ReadString();
            //請求書発行日リテラル(年)
            temp.HADD_BILLPRINTDATEFLYRF = reader.ReadString();
            //請求書発行日リテラル(月)
            temp.HADD_BILLPRINTDATEFLMRF = reader.ReadString();
            //請求書発行日リテラル(日)
            temp.HADD_BILLPRINTDATEFLDRF = reader.ReadString();
            //入金予定日西暦年
            temp.HADD_EXPECTEDDEPOSITDATEFYRF = reader.ReadInt32();
            //入金予定日西暦年略
            temp.HADD_EXPECTEDDEPOSITDATEFSRF = reader.ReadInt32();
            //入金予定日和暦年
            temp.HADD_EXPECTEDDEPOSITDATEFWRF = reader.ReadInt32();
            //入金予定日月
            temp.HADD_EXPECTEDDEPOSITDATEFMRF = reader.ReadInt32();
            //入金予定日日
            temp.HADD_EXPECTEDDEPOSITDATEFDRF = reader.ReadInt32();
            //入金予定日元号
            temp.HADD_EXPECTEDDEPOSITDATEFGRF = reader.ReadString();
            //入金予定日略号
            temp.HADD_EXPECTEDDEPOSITDATEFRRF = reader.ReadString();
            //入金予定日リテラル(/)
            temp.HADD_EXPECTEDDEPOSITDATEFLSRF = reader.ReadString();
            //入金予定日リテラル(.)
            temp.HADD_EXPECTEDDEPOSITDATEFLPRF = reader.ReadString();
            //入金予定日リテラル(年)
            temp.HADD_EXPECTEDDEPOSITDATEFLYRF = reader.ReadString();
            //入金予定日リテラル(月)
            temp.HADD_EXPECTEDDEPOSITDATEFLMRF = reader.ReadString();
            //入金予定日リテラル(日)
            temp.HADD_EXPECTEDDEPOSITDATEFLDRF = reader.ReadString();
            //回収条件名称
            temp.HADD_COLLECTCONDNMRF = reader.ReadString();
            //請求書タイトル
            temp.HADD_DMDFORMTITLERF = reader.ReadString();
            //請求書タイトル２
            temp.HADD_DMDFORMTITLE2RF = reader.ReadString();
            //請求書コメント１
            temp.HADD_DMDFORMCOMENT1RF = reader.ReadString();
            //請求書コメント２
            temp.HADD_DMDFORMCOMENT2RF = reader.ReadString();
            //請求書コメント３
            temp.HADD_DMDFORMCOMENT3RF = reader.ReadString();
            //入金金額(値引除く)
            temp.HADD_DMDNRMLEXDISRF = reader.ReadInt64();
            //入金金額(手数料除く)
            temp.HADD_DMDNRMLEXFEERF = reader.ReadInt64();
            //入金金額(値引・手数料除く)
            temp.HADD_DMDNRMLEXDISFEERF = reader.ReadInt64();
            //入金金額(値引＋手数料)
            temp.HADD_DMDNRMLSAMDISFEERF = reader.ReadInt64();
            //今回売上額(税抜)
            temp.HADD_THISSALESANDADJUSTRF = reader.ReadInt64();
            //今回売上消費税
            temp.HADD_THISTAXANDADJUSTRF = reader.ReadInt64();
            //入力発行日付
            temp.HADD_ISSUEDAYRF = reader.ReadInt32();
            //入力発行日付西暦年
            temp.HADD_ISSUEDAYFYRF = reader.ReadInt32();
            //入力発行日付西暦年略
            temp.HADD_ISSUEDAYFSRF = reader.ReadInt32();
            //入力発行日付和暦年
            temp.HADD_ISSUEDAYFWRF = reader.ReadInt32();
            //入力発行日付月
            temp.HADD_ISSUEDAYFMRF = reader.ReadInt32();
            //入力発行日付日
            temp.HADD_ISSUEDAYFDRF = reader.ReadInt32();
            //入力発行日付元号
            temp.HADD_ISSUEDAYFGRF = reader.ReadString();
            //入力発行日付略号
            temp.HADD_ISSUEDAYFRRF = reader.ReadString();
            //入力発行日付リテラル(/)
            temp.HADD_ISSUEDAYFLSRF = reader.ReadString();
            //入力発行日付リテラル(.)
            temp.HADD_ISSUEDAYFLPRF = reader.ReadString();
            //入力発行日付リテラル(年)
            temp.HADD_ISSUEDAYFLYRF = reader.ReadString();
            //入力発行日付リテラル(月)
            temp.HADD_ISSUEDAYFLMRF = reader.ReadString();
            //入力発行日付リテラル(日)
            temp.HADD_ISSUEDAYFLDRF = reader.ReadString();
            //印刷得意先サブコード
            temp.CADD_CUSTOMERSUBCODERF = reader.ReadString();
            //印刷得意先名称
            temp.CADD_NAMERF = reader.ReadString();
            //印刷得意先名称2
            temp.CADD_NAME2RF = reader.ReadString();
            //印刷得意先敬称
            temp.CADD_HONORIFICTITLERF = reader.ReadString();
            //印刷得意先カナ
            temp.CADD_KANARF = reader.ReadString();
            //印刷得意先略称
            temp.CADD_CUSTOMERSNMRF = reader.ReadString();
            //印刷得意先諸口コード
            temp.CADD_OUTPUTNAMECODERF = reader.ReadInt32();
            //印刷得意先郵便番号
            temp.CADD_POSTNORF = reader.ReadString();
            //印刷得意先住所1（都道府県市区郡・町村・字）
            temp.CADD_ADDRESS1RF = reader.ReadString();
            //印刷得意先住所3（番地）
            temp.CADD_ADDRESS3RF = reader.ReadString();
            //印刷得意先住所4（アパート名称）
            temp.CADD_ADDRESS4RF = reader.ReadString();
            //印刷得意先分析コード1
            temp.CADD_CUSTANALYSCODE1RF = reader.ReadInt32();
            //印刷得意先分析コード2
            temp.CADD_CUSTANALYSCODE2RF = reader.ReadInt32();
            //印刷得意先分析コード3
            temp.CADD_CUSTANALYSCODE3RF = reader.ReadInt32();
            //印刷得意先分析コード4
            temp.CADD_CUSTANALYSCODE4RF = reader.ReadInt32();
            //印刷得意先分析コード5
            temp.CADD_CUSTANALYSCODE5RF = reader.ReadInt32();
            //印刷得意先分析コード6
            temp.CADD_CUSTANALYSCODE6RF = reader.ReadInt32();
            //印刷得意先備考1
            temp.CADD_NOTE1RF = reader.ReadString();
            //印刷得意先備考2
            temp.CADD_NOTE2RF = reader.ReadString();
            //印刷得意先備考3
            temp.CADD_NOTE3RF = reader.ReadString();
            //印刷得意先備考4
            temp.CADD_NOTE4RF = reader.ReadString();
            //印刷得意先備考5
            temp.CADD_NOTE5RF = reader.ReadString();
            //印刷得意先備考6
            temp.CADD_NOTE6RF = reader.ReadString();
            //印刷得意先備考7
            temp.CADD_NOTE7RF = reader.ReadString();
            //印刷得意先備考8
            temp.CADD_NOTE8RF = reader.ReadString();
            //印刷得意先備考9
            temp.CADD_NOTE9RF = reader.ReadString();
            //印刷得意先備考10
            temp.CADD_NOTE10RF = reader.ReadString();
            //印刷用得意先名称（上段）
            temp.CADD_PRINTCUSTOMERNAME1RF = reader.ReadString();
            //印刷用得意先名称（下段）
            temp.CADD_PRINTCUSTOMERNAME2RF = reader.ReadString();
            //印刷用得意先名称（下段）＋敬称
            temp.CADD_PRINTCUSTOMERNAME2HNRF = reader.ReadString();
            //集金月区分名称
            temp.CSTCST_COLLECTMONEYNAMERF = reader.ReadString();
            //集金日
            temp.CSTCST_COLLECTMONEYDAYRF = reader.ReadInt32();
            //印刷得意先コード
            temp.CADD_CUSTOMERCODERF = reader.ReadInt32();
            //印刷得意先電話番号（自宅）
            temp.CADD_HOMETELNORF = reader.ReadString();
            //印刷得意先電話番号（勤務先）
            temp.CADD_OFFICETELNORF = reader.ReadString();
            //印刷得意先電話番号（携帯）
            temp.CADD_PORTABLETELNORF = reader.ReadString();
            //印刷得意先FAX番号（自宅）
            temp.CADD_HOMEFAXNORF = reader.ReadString();
            //印刷得意先FAX番号（勤務先）
            temp.CADD_OFFICEFAXNORF = reader.ReadString();
            //印刷得意先電話番号（その他）
            temp.CADD_OTHERSTELNORF = reader.ReadString();
            //得意先電話番号（自宅）
            temp.CSTCST_HOMETELNORF = reader.ReadString();
            //得意先電話番号（勤務先）
            temp.CSTCST_OFFICETELNORF = reader.ReadString();
            //得意先電話番号（携帯）
            temp.CSTCST_PORTABLETELNORF = reader.ReadString();
            //得意先FAX番号（自宅）
            temp.CSTCST_HOMEFAXNORF = reader.ReadString();
            //得意先FAX番号（勤務先）
            temp.CSTCST_OFFICEFAXNORF = reader.ReadString();
            //得意先電話番号（その他）
            temp.CSTCST_OTHERSTELNORF = reader.ReadString();
            //請求先電話番号（自宅）
            temp.CSTCLM_HOMETELNORF = reader.ReadString();
            //請求先電話番号（勤務先）
            temp.CSTCLM_OFFICETELNORF = reader.ReadString();
            //請求先電話番号（携帯）
            temp.CSTCLM_PORTABLETELNORF = reader.ReadString();
            //請求先FAX番号（自宅）
            temp.CSTCLM_HOMEFAXNORF = reader.ReadString();
            //請求先FAX番号（勤務先）
            temp.CSTCLM_OFFICEFAXNORF = reader.ReadString();
            //請求先電話番号（その他）
            temp.CSTCLM_OTHERSTELNORF = reader.ReadString();
            //今回売上額(税込)
            temp.HADD_THISSALESANDADJUSTTAXINCRF = reader.ReadInt64();
            //請求先集金月区分名称
            temp.CSTCLM_COLLECTMONEYNAMERF = reader.ReadString();
            //請求先集金日
            temp.CSTCLM_COLLECTMONEYDAYRF = reader.ReadInt32();
            //実績拠点コード
            temp.CUSTDMDPRCRF_RESULTSSECTCDRF = reader.ReadString();
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
            //自宅TEL表示名称
            temp.ALITMDSPNMRF_HOMETELNODSPNAMERF = reader.ReadString();
            //勤務先TEL表示名称
            temp.ALITMDSPNMRF_OFFICETELNODSPNAMERF = reader.ReadString();
            //携帯TEL表示名称
            temp.ALITMDSPNMRF_MOBILETELNODSPNAMERF = reader.ReadString();
            //自宅FAX表示名称
            temp.ALITMDSPNMRF_HOMEFAXNODSPNAMERF = reader.ReadString();
            //勤務先FAX表示名称
            temp.ALITMDSPNMRF_OFFICEFAXNODSPNAMERF = reader.ReadString();
            //その他TEL表示名称
            temp.ALITMDSPNMRF_OTHERTELNODSPNAMERF = reader.ReadString();
            //販売エリアコード
            temp.CSTCLM_SALESAREACODERF = reader.ReadInt32();
            //顧客担当従業員コード
            temp.CSTCLM_CUSTOMERAGENTCDRF = reader.ReadString();
            //集金担当従業員コード
            temp.CSTCLM_BILLCOLLECTERCDRF = reader.ReadString();
            //旧顧客担当従業員コード
            temp.CSTCLM_OLDCUSTOMERAGENTCDRF = reader.ReadString();
            //顧客担当変更日
            temp.CSTCLM_CUSTAGENTCHGDATERF = reader.ReadInt32();
            //請求書番号
            temp.CUSTDMDPRCRF_BILLNORF = reader.ReadInt32();
            //集金月区分コード
            temp.CSTCST_COLLECTMONEYCODERF = reader.ReadInt32();

            //請求先集金月区分コード
            temp.CSTCLM_COLLECTMONEYCODERF = reader.ReadInt32();

            //締日
            temp.CSTCLM_TOTALDAYRF = reader.ReadInt32();
            //税率1タイトル
            temp.TitleTaxRate1 = reader.ReadInt32();
            //税率2タイトル
            temp.TitleTaxRate2 = reader.ReadInt32();
            // 税率(1)対象金額合計(税抜き)
            temp.TotalThisTimeSalesTaxExRate1 = reader.ReadDouble();
            // 税率(2)対象金額合計(税抜き)
            temp.TotalThisTimeSalesTaxExRate2 = reader.ReadDouble();
            // 税額(1)
            temp.TotalThisTimeTaxRate1 = reader.ReadDouble();
            // 税額(2)
            temp.TotalThisTimeTaxRate2 = reader.ReadDouble();


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
        /// <returns>EBooksFrePBillHeadWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   EBooksFrePBillHeadWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize( System.IO.BinaryReader reader )
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject( reader );
            ArrayList lst = new ArrayList();
            for ( int cnt = 0; cnt < serInfo.Occurrence; ++cnt )
            {
                EBooksFrePBillHeadWork temp = GetEBooksFrePBillHeadWork( reader, serInfo );
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
                    retValue = (EBooksFrePBillHeadWork[])lst.ToArray( typeof( EBooksFrePBillHeadWork ) );
                    break;
            }
            return retValue;
        }

        #endregion
    }

}
