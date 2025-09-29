using System;
using System.Collections;
using System.Drawing;
using System.IO;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   FrePEstFmHead
    /// <summary>
    ///                      自由帳票見積書ヘッダデータ
    /// </summary>
    /// <remarks>
    /// <br>note             :   自由帳票見積書ヘッダデータヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2008/3/25</br>
    /// <br>Genarated Date   :   2008/10/07  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class FrePEstFmHead
    {
        /// <summary>売上伝票番号</summary>
        /// <remarks>見積伝票番号,受注伝票番号,出荷伝票番号,売上伝票番号を兼ねる。</remarks>
        private string _sALESSLIPRF_SALESSLIPNUMRF = "";

        /// <summary>拠点コード</summary>
        private string _sALESSLIPRF_SECTIONCODERF = "";

        /// <summary>売上日付</summary>
        /// <remarks>見積日、受注日、売上日を兼ねる。(YYYYMMDD)</remarks>
        private DateTime _sALESSLIPRF_SALESDATERF;

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

        /// <summary>消費税転嫁方式</summary>
        /// <remarks>0:伝票単位1:明細単位2:請求親 3:請求子 9:非課税</remarks>
        private Int32 _sALESSLIPRF_CONSTAXLAYMETHODRF;

        /// <summary>得意先コード</summary>
        private Int32 _sALESSLIPRF_CUSTOMERCODERF;

        /// <summary>得意先名称</summary>
        private string _sALESSLIPRF_CUSTOMERNAMERF = "";

        /// <summary>得意先名称2</summary>
        private string _sALESSLIPRF_CUSTOMERNAME2RF = "";

        /// <summary>得意先略称</summary>
        private string _sALESSLIPRF_CUSTOMERSNMRF = "";

        /// <summary>得意先敬称</summary>
        private string _sALESSLIPRF_HONORIFICTITLERF = "";

        /// <summary>売上伝票発行日</summary>
        private DateTime _sALESSLIPRF_SALESSLIPPRINTDATERF;

        /// <summary>総額表示方法区分</summary>
        /// <remarks>0:総額表示しない（税抜き）,1:総額表示する（税込み）</remarks>
        private Int32 _sALESSLIPRF_TOTALAMOUNTDISPWAYCDRF;

        /// <summary>拠点ガイド名称</summary>
        /// <remarks>ＵＩ用（既存のコンボボックス等）</remarks>
        private string _sECINFOSETRF_SECTIONGUIDENMRF = "";

        /// <summary>拠点自社PR文</summary>
        private string _cOMPANYNMRF_COMPANYPRRF = "";

        /// <summary>拠点自社名称1</summary>
        private string _cOMPANYNMRF_COMPANYNAME1RF = "";

        /// <summary>拠点自社名称2</summary>
        private string _cOMPANYNMRF_COMPANYNAME2RF = "";

        /// <summary>拠点郵便番号</summary>
        private string _cOMPANYNMRF_POSTNORF = "";

        /// <summary>拠点住所1（都道府県市区郡・町村・字）</summary>
        private string _cOMPANYNMRF_ADDRESS1RF = "";

        /// <summary>拠点住所3（番地）</summary>
        private string _cOMPANYNMRF_ADDRESS3RF = "";

        /// <summary>拠点住所4（アパート名称）</summary>
        private string _cOMPANYNMRF_ADDRESS4RF = "";

        /// <summary>拠点自社電話番号1</summary>
        /// <remarks>TEL</remarks>
        private string _cOMPANYNMRF_COMPANYTELNO1RF = "";

        /// <summary>拠点自社電話番号2</summary>
        /// <remarks>TEL2</remarks>
        private string _cOMPANYNMRF_COMPANYTELNO2RF = "";

        /// <summary>拠点自社電話番号3</summary>
        /// <remarks>FAX</remarks>
        private string _cOMPANYNMRF_COMPANYTELNO3RF = "";

        /// <summary>拠点自社電話番号タイトル1</summary>
        /// <remarks>TEL</remarks>
        private string _cOMPANYNMRF_COMPANYTELTITLE1RF = "";

        /// <summary>拠点自社電話番号タイトル2</summary>
        /// <remarks>TEL2</remarks>
        private string _cOMPANYNMRF_COMPANYTELTITLE2RF = "";

        /// <summary>拠点自社電話番号タイトル3</summary>
        /// <remarks>FAX</remarks>
        private string _cOMPANYNMRF_COMPANYTELTITLE3RF = "";

        /// <summary>拠点銀行振込案内文</summary>
        private string _cOMPANYNMRF_TRANSFERGUIDANCERF = "";

        /// <summary>拠点銀行口座1</summary>
        private string _cOMPANYNMRF_ACCOUNTNOINFO1RF = "";

        /// <summary>拠点銀行口座2</summary>
        private string _cOMPANYNMRF_ACCOUNTNOINFO2RF = "";

        /// <summary>拠点銀行口座3</summary>
        private string _cOMPANYNMRF_ACCOUNTNOINFO3RF = "";

        /// <summary>拠点自社設定摘要1</summary>
        private string _cOMPANYNMRF_COMPANYSETNOTE1RF = "";

        /// <summary>拠点自社設定摘要2</summary>
        private string _cOMPANYNMRF_COMPANYSETNOTE2RF = "";

        /// <summary>拠点自社URL</summary>
        private string _cOMPANYNMRF_COMPANYURLRF = "";

        /// <summary>拠点自社PR文2</summary>
        /// <remarks>代表取締役等の情報を入力</remarks>
        private string _cOMPANYNMRF_COMPANYPRSENTENCE2RF = "";

        /// <summary>拠点画像印字用コメント1</summary>
        /// <remarks>画像印字する場合、画像の下に印字する（拠点名等）</remarks>
        private string _cOMPANYNMRF_IMAGECOMMENTFORPRT1RF = "";

        /// <summary>拠点画像印字用コメント2</summary>
        /// <remarks>画像印字する場合、画像の下に印字する（拠点名等）</remarks>
        private string _cOMPANYNMRF_IMAGECOMMENTFORPRT2RF = "";

        /// <summary>拠点自社画像</summary>
        private Byte[] _iMAGEINFORF_IMAGEINFODATARF;

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

        /// <summary>脚注１</summary>
        private string _hEST_FOOTNOTES1RF = "";

        /// <summary>脚注２</summary>
        private string _hEST_FOOTNOTES2RF = "";

        /// <summary>見積タイトル１</summary>
        private string _hEST_ESTIMATETITLE1RF = "";

        /// <summary>見積タイトル２</summary>
        private string _hEST_ESTIMATETITLE2RF = "";

        /// <summary>見積タイトル３</summary>
        private string _hEST_ESTIMATETITLE3RF = "";

        /// <summary>見積タイトル４</summary>
        private string _hEST_ESTIMATETITLE4RF = "";

        /// <summary>見積タイトル５</summary>
        private string _hEST_ESTIMATETITLE5RF = "";

        /// <summary>見積備考１</summary>
        private string _hEST_ESTIMATENOTE1RF = "";

        /// <summary>見積備考２</summary>
        private string _hEST_ESTIMATENOTE2RF = "";

        /// <summary>見積備考３</summary>
        private string _hEST_ESTIMATENOTE3RF = "";

        /// <summary>見積備考４</summary>
        private string _hEST_ESTIMATENOTE4RF = "";

        /// <summary>見積備考５</summary>
        private string _hEST_ESTIMATENOTE5RF = "";

        /// <summary>見積書有効期日</summary>
        /// <remarks>YYYYMMDD　発行日から見積書有効期限に設定された月数分あと</remarks>
        private DateTime _hEST_ESTIMATEVALIDITYLIMITRF;

        /// <summary>見積書有効期日西暦年</summary>
        private Int32 _hEST_ESTIMATEVALIDITYLIMITFYRF;

        /// <summary>見積書有効期日西暦年略</summary>
        private Int32 _hEST_ESTIMATEVALIDITYLIMITFSRF;

        /// <summary>見積書有効期日和暦年</summary>
        private Int32 _hEST_ESTIMATEVALIDITYLIMITFWRF;

        /// <summary>見積書有効期日月</summary>
        private Int32 _hEST_ESTIMATEVALIDITYLIMITFMRF;

        /// <summary>見積書有効期日日</summary>
        private Int32 _hEST_ESTIMATEVALIDITYLIMITFDRF;

        /// <summary>見積書有効期日元号</summary>
        private string _hEST_ESTIMATEVALIDITYLIMITFGRF = "";

        /// <summary>見積書有効期日略号</summary>
        private string _hEST_ESTIMATEVALIDITYLIMITFRRF = "";

        /// <summary>見積書有効期日リテラル(/)</summary>
        private string _hEST_ESTIMATEVALIDITYLIMITFLSRF = "";

        /// <summary>見積書有効期日リテラル(.)</summary>
        private string _hEST_ESTIMATEVALIDITYLIMITFLPRF = "";

        /// <summary>見積書有効期日リテラル(年)</summary>
        private string _hEST_ESTIMATEVALIDITYLIMITFLYRF = "";

        /// <summary>見積書有効期日リテラル(月)</summary>
        private string _hEST_ESTIMATEVALIDITYLIMITFLMRF = "";

        /// <summary>見積書有効期日リテラル(日)</summary>
        private string _hEST_ESTIMATEVALIDITYLIMITFLDRF = "";

        /// <summary>車両管理番号</summary>
        /// <remarks>自動採番（無重複のシーケンス）PM7での車両SEQ</remarks>
        private Int32 _hADD_CARMNGNORF;

        /// <summary>車輌管理コード</summary>
        /// <remarks>※PM7での車両管理番号</remarks>
        private string _hADD_CARMNGCODERF = "";

        /// <summary>陸運事務所番号</summary>
        private Int32 _hADD_NUMBERPLATE1CODERF;

        /// <summary>陸運事務局名称</summary>
        private string _hADD_NUMBERPLATE1NAMERF = "";

        /// <summary>車両登録番号（種別）</summary>
        private string _hADD_NUMBERPLATE2RF = "";

        /// <summary>車両登録番号（カナ）</summary>
        private string _hADD_NUMBERPLATE3RF = "";

        /// <summary>車両登録番号（プレート番号）</summary>
        private Int32 _hADD_NUMBERPLATE4RF;

        /// <summary>初年度</summary>
        /// <remarks>YYYYMM</remarks>
        private int _hADD_FIRSTENTRYDATERF;

        /// <summary>メーカーコード</summary>
        /// <remarks>1～899:提供分, 900～ユーザー登録</remarks>
        private Int32 _hADD_MAKERCODERF;

        /// <summary>メーカー全角名称</summary>
        /// <remarks>正式名称（カナ漢字混在で全角管理）</remarks>
        private string _hADD_MAKERFULLNAMERF = "";

        /// <summary>メーカー半角名称</summary>
        private string _hADD_MAKERHALFNAMERF = "";

        /// <summary>車種コード</summary>
        /// <remarks>車名コード(翼) 1～899:提供分, 900～ユーザー登録</remarks>
        private Int32 _hADD_MODELCODERF;

        /// <summary>車種サブコード</summary>
        /// <remarks>0～899:提供分,900～ﾕｰｻﾞｰ登録</remarks>
        private Int32 _hADD_MODELSUBCODERF;

        /// <summary>車種全角名称</summary>
        /// <remarks>正式名称（カナ漢字混在で全角管理）</remarks>
        private string _hADD_MODELFULLNAMERF = "";

        /// <summary>車種半角名称</summary>
        private string _hADD_MODELHALFNAMERF = "";

        /// <summary>排ガス記号</summary>
        private string _hADD_EXHAUSTGASSIGNRF = "";

        /// <summary>シリーズ型式</summary>
        private string _hADD_SERIESMODELRF = "";

        /// <summary>型式（類別記号）</summary>
        private string _hADD_CATEGORYSIGNMODELRF = "";

        /// <summary>型式（フル型）</summary>
        /// <remarks>フル型式(44桁用)</remarks>
        private string _hADD_FULLMODELRF = "";

        /// <summary>型式指定番号</summary>
        private Int32 _hADD_MODELDESIGNATIONNORF;

        /// <summary>類別番号</summary>
        private Int32 _hADD_CATEGORYNORF;

        /// <summary>車台型式</summary>
        private string _hADD_FRAMEMODELRF = "";

        /// <summary>車台番号</summary>
        /// <remarks>車検証記載フォーマット対応（ HCR32-100251584 等）</remarks>
        private string _hADD_FRAMENORF = "";

        /// <summary>車台番号（検索用）</summary>
        /// <remarks>PM7の車台番号と同意</remarks>
        private Int32 _hADD_SEARCHFRAMENORF;

        /// <summary>エンジン型式名称</summary>
        /// <remarks>エンジン検索</remarks>
        private string _hADD_ENGINEMODELNMRF = "";

        /// <summary>関連型式</summary>
        /// <remarks>リサイクル系で使用</remarks>
        private string _hADD_RELEVANCEMODELRF = "";

        /// <summary>サブ車名コード</summary>
        /// <remarks>リサイクル系で使用</remarks>
        private Int32 _hADD_SUBCARNMCDRF;

        /// <summary>型式グレード略称</summary>
        /// <remarks>リサイクル系で使用</remarks>
        private string _hADD_MODELGRADESNAMERF = "";

        /// <summary>カラーコード</summary>
        /// <remarks>カタログの色コード</remarks>
        private string _hADD_COLORCODERF = "";

        /// <summary>カラー名称1</summary>
        /// <remarks>画面表示用正式名称</remarks>
        private string _hADD_COLORNAME1RF = "";

        /// <summary>トリムコード</summary>
        private string _hADD_TRIMCODERF = "";

        /// <summary>トリム名称</summary>
        private string _hADD_TRIMNAMERF = "";

        /// <summary>車両走行距離</summary>
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

        /// <summary>初年度西暦年</summary>
        private Int32 _hADD_FIRSTENTRYDATEFYRF;

        /// <summary>初年度西暦年略</summary>
        private Int32 _hADD_FIRSTENTRYDATEFSRF;

        /// <summary>初年度和暦年</summary>
        private Int32 _hADD_FIRSTENTRYDATEFWRF;

        /// <summary>初年度月</summary>
        private Int32 _hADD_FIRSTENTRYDATEFMRF;

        /// <summary>初年度元号</summary>
        private string _hADD_FIRSTENTRYDATEFGRF = "";

        /// <summary>初年度略号</summary>
        private string _hADD_FIRSTENTRYDATEFRRF = "";

        /// <summary>初年度リテラル(/)</summary>
        private string _hADD_FIRSTENTRYDATEFLSRF = "";

        /// <summary>初年度リテラル(.)</summary>
        private string _hADD_FIRSTENTRYDATEFLPRF = "";

        /// <summary>初年度リテラル(年)</summary>
        private string _hADD_FIRSTENTRYDATEFLYRF = "";

        /// <summary>初年度リテラル(月)</summary>
        private string _hADD_FIRSTENTRYDATEFLMRF = "";

        /// <summary>印刷用得意先名称(上段)</summary>
        /// <remarks>印刷プログラムで制御する得意先名称項目</remarks>
        private string _hADD_PRINTCUSTOMERNM1RF = "";

        /// <summary>印刷用得意先名称(下段)</summary>
        /// <remarks>印刷プログラムで制御する得意先名称項目</remarks>
        private string _hADD_PRINTCUSTOMERNM2RF = "";

        /// <summary>純正売上伝票合計（税込み）</summary>
        /// <remarks>売上正価金額＋売上値引金額計（税抜き）＋売上金額消費税額</remarks>
        private Int64 _hPURE_SALESTOTALTAXINCRF;

        /// <summary>純正売上伝票合計（税抜き）</summary>
        /// <remarks>売上正価金額＋売上値引金額計（税抜き）</remarks>
        private Int64 _hPURE_SALESTOTALTAXEXCRF;

        /// <summary>純正売上小計（税込み）</summary>
        /// <remarks>値引後の明細金額の合計（非課税含まず）</remarks>
        private Int64 _hPURE_SALESSUBTOTALTAXINCRF;

        /// <summary>純正売上小計（税抜き）</summary>
        /// <remarks>値引後の明細金額の合計（非課税含まず）</remarks>
        private Int64 _hPURE_SALESSUBTOTALTAXEXCRF;

        /// <summary>純正売上小計（税）</summary>
        /// <remarks>外税対象金額の集計（税抜、値引含まず）</remarks>
        private Int64 _hPURE_SALESSUBTOTALTAXRF;

        /// <summary>優良売上伝票合計（税込み）</summary>
        /// <remarks>売上正価金額＋売上値引金額計（税抜き）＋売上金額消費税額</remarks>
        private Int64 _hPRIME_SALESTOTALTAXINCRF;

        /// <summary>優良売上伝票合計（税抜き）</summary>
        /// <remarks>売上正価金額＋売上値引金額計（税抜き）</remarks>
        private Int64 _hPRIME_SALESTOTALTAXEXCRF;

        /// <summary>優良売上小計（税込み）</summary>
        /// <remarks>値引後の明細金額の合計（非課税含まず）</remarks>
        private Int64 _hPRIME_SALESSUBTOTALTAXINCRF;

        /// <summary>優良売上小計（税抜き）</summary>
        /// <remarks>値引後の明細金額の合計（非課税含まず）</remarks>
        private Int64 _hPRIME_SALESSUBTOTALTAXEXCRF;

        /// <summary>優良売上小計（税）</summary>
        /// <remarks>外税対象金額の集計（税抜、値引含まず）</remarks>
        private Int64 _hPRIME_SALESSUBTOTALTAXRF;

        /// <summary>印刷時刻 時</summary>
        /// <remarks>HH</remarks>
        private Int32 _hADD_PRINTTIMEHOURRF;

        /// <summary>印刷時刻 分</summary>
        /// <remarks>MM</remarks>
        private Int32 _hADD_PRINTTIMEMINUTERF;

        /// <summary>印刷時刻 秒</summary>
        /// <remarks>DD</remarks>
        private Int32 _hADD_PRINTTIMESECONDRF;

        /// <summary>見積書印刷制御区分</summary>
        /// <remarks>0:全て,1:純正のみ,2:優良のみ,3:選択分のみ</remarks>
        private EstFmDivState _hADD_ESTFMDIVRF;

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

        /// <summary>系統コード</summary>
        private Int32 _hADD_SYSTEMATICCODERF;

        /// <summary>系統名称</summary>
        /// <remarks>140系,180系等</remarks>
        private string _hADD_SYSTEMATICNAMERF = "";

        /// <summary>開始生産年式</summary>
        /// <remarks>YYYYMM</remarks>
        private DateTime _hADD_STPRODUCETYPEOFYEARRF;

        /// <summary>終了生産年式</summary>
        /// <remarks>YYYYMM</remarks>
        private DateTime _hADD_EDPRODUCETYPEOFYEARRF;

        /// <summary>ドア数</summary>
        private Int32 _hADD_DOORCOUNTRF;

        /// <summary>ボディー名コード</summary>
        private Int32 _hADD_BODYNAMECODERF;

        /// <summary>ボディー名称</summary>
        private string _hADD_BODYNAMERF = "";

        /// <summary>生産車台番号開始</summary>
        private Int32 _hADD_STPRODUCEFRAMENORF;

        /// <summary>生産車台番号終了</summary>
        private Int32 _hADD_EDPRODUCEFRAMENORF;

        /// <summary>原動機型式（エンジン）</summary>
        /// <remarks>車検証記載原動機型式</remarks>
        private string _hADD_ENGINEMODELRF = "";

        /// <summary>型式グレード名称</summary>
        private string _hADD_MODELGRADENMRF = "";

        /// <summary>排気量名称</summary>
        /// <remarks>型式により変動</remarks>
        private string _hADD_ENGINEDISPLACENMRF = "";

        /// <summary>E区分名称</summary>
        /// <remarks>型式により変動</remarks>
        private string _hADD_EDIVNMRF = "";

        /// <summary>ミッション名称</summary>
        private string _hADD_TRANSMISSIONNMRF = "";

        /// <summary>シフト名称</summary>
        private string _hADD_SHIFTNMRF = "";

        /// <summary>駆動方式名称</summary>
        /// <remarks>新規追加</remarks>
        private string _hADD_WHEELDRIVEMETHODNMRF = "";

        /// <summary>追加諸元1</summary>
        /// <remarks>型式により変動</remarks>
        private string _hADD_ADDICARSPEC1RF = "";

        /// <summary>追加諸元2</summary>
        /// <remarks>型式により変動</remarks>
        private string _hADD_ADDICARSPEC2RF = "";

        /// <summary>追加諸元3</summary>
        /// <remarks>型式により変動</remarks>
        private string _hADD_ADDICARSPEC3RF = "";

        /// <summary>追加諸元4</summary>
        /// <remarks>型式により変動</remarks>
        private string _hADD_ADDICARSPEC4RF = "";

        /// <summary>追加諸元5</summary>
        /// <remarks>型式により変動</remarks>
        private string _hADD_ADDICARSPEC5RF = "";

        /// <summary>追加諸元6</summary>
        /// <remarks>型式により変動</remarks>
        private string _hADD_ADDICARSPEC6RF = "";

        /// <summary>追加諸元タイトル1</summary>
        /// <remarks>型式により変動</remarks>
        private string _hADD_ADDICARSPECTITLE1RF = "";

        /// <summary>追加諸元タイトル2</summary>
        /// <remarks>型式により変動</remarks>
        private string _hADD_ADDICARSPECTITLE2RF = "";

        /// <summary>追加諸元タイトル3</summary>
        /// <remarks>型式により変動</remarks>
        private string _hADD_ADDICARSPECTITLE3RF = "";

        /// <summary>追加諸元タイトル4</summary>
        /// <remarks>型式により変動</remarks>
        private string _hADD_ADDICARSPECTITLE4RF = "";

        /// <summary>追加諸元タイトル5</summary>
        /// <remarks>型式により変動</remarks>
        private string _hADD_ADDICARSPECTITLE5RF = "";

        /// <summary>追加諸元タイトル6</summary>
        /// <remarks>型式により変動</remarks>
        private string _hADD_ADDICARSPECTITLE6RF = "";

        /// <summary>開始生産年式西暦年</summary>
        private Int32 _hADD_STPRODUCETYPEOFYEARFYRF;

        /// <summary>開始生産年式西暦年略</summary>
        private Int32 _hADD_STPRODUCETYPEOFYEARFSRF;

        /// <summary>開始生産年式和暦年</summary>
        private Int32 _hADD_STPRODUCETYPEOFYEARFWRF;

        /// <summary>開始生産年式月</summary>
        private Int32 _hADD_STPRODUCETYPEOFYEARFMRF;

        /// <summary>開始生産年式元号</summary>
        private string _hADD_STPRODUCETYPEOFYEARFGRF = "";

        /// <summary>開始生産年式略号</summary>
        private string _hADD_STPRODUCETYPEOFYEARFRRF = "";

        /// <summary>開始生産年式リテラル(/)</summary>
        private string _hADD_STPRODUCETYPEOFYEARFLSRF = "";

        /// <summary>開始生産年式リテラル(.)</summary>
        private string _hADD_STPRODUCETYPEOFYEARFLPRF = "";

        /// <summary>開始生産年式リテラル(年)</summary>
        private string _hADD_STPRODUCETYPEOFYEARFLYRF = "";

        /// <summary>開始生産年式リテラル(月)</summary>
        private string _hADD_STPRODUCETYPEOFYEARFLMRF = "";

        /// <summary>終了生産年式西暦年</summary>
        private Int32 _hADD_EDPRODUCETYPEOFYEARFYRF;

        /// <summary>終了生産年式西暦年略</summary>
        private Int32 _hADD_EDPRODUCETYPEOFYEARFSRF;

        /// <summary>終了生産年式和暦年</summary>
        private Int32 _hADD_EDPRODUCETYPEOFYEARFWRF;

        /// <summary>終了生産年式月</summary>
        private Int32 _hADD_EDPRODUCETYPEOFYEARFMRF;

        /// <summary>終了生産年式元号</summary>
        private string _hADD_EDPRODUCETYPEOFYEARFGRF = "";

        /// <summary>終了生産年式略号</summary>
        private string _hADD_EDPRODUCETYPEOFYEARFRRF = "";

        /// <summary>終了生産年式リテラル(/)</summary>
        private string _hADD_EDPRODUCETYPEOFYEARFLSRF = "";

        /// <summary>終了生産年式リテラル(.)</summary>
        private string _hADD_EDPRODUCETYPEOFYEARFLPRF = "";

        /// <summary>終了生産年式リテラル(年)</summary>
        private string _hADD_EDPRODUCETYPEOFYEARFLYRF = "";

        /// <summary>終了生産年式リテラル(月)</summary>
        private string _hADD_EDPRODUCETYPEOFYEARFLMRF = "";


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

        /// public propaty name  :  SALESSLIPRF_SALESDATERF
        /// <summary>売上日付プロパティ</summary>
        /// <value>見積日、受注日、売上日を兼ねる。(YYYYMMDD)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上日付プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime SALESSLIPRF_SALESDATERF
        {
            get { return _sALESSLIPRF_SALESDATERF; }
            set { _sALESSLIPRF_SALESDATERF = value; }
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
        /// <summary>得意先敬称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先敬称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SALESSLIPRF_HONORIFICTITLERF
        {
            get { return _sALESSLIPRF_HONORIFICTITLERF; }
            set { _sALESSLIPRF_HONORIFICTITLERF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_SALESSLIPPRINTDATERF
        /// <summary>売上伝票発行日プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上伝票発行日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime SALESSLIPRF_SALESSLIPPRINTDATERF
        {
            get { return _sALESSLIPRF_SALESSLIPPRINTDATERF; }
            set { _sALESSLIPRF_SALESSLIPPRINTDATERF = value; }
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

        /// public propaty name  :  COMPANYNMRF_COMPANYPRRF
        /// <summary>拠点自社PR文プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点自社PR文プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string COMPANYNMRF_COMPANYPRRF
        {
            get { return _cOMPANYNMRF_COMPANYPRRF; }
            set { _cOMPANYNMRF_COMPANYPRRF = value; }
        }

        /// public propaty name  :  COMPANYNMRF_COMPANYNAME1RF
        /// <summary>拠点自社名称1プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点自社名称1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string COMPANYNMRF_COMPANYNAME1RF
        {
            get { return _cOMPANYNMRF_COMPANYNAME1RF; }
            set { _cOMPANYNMRF_COMPANYNAME1RF = value; }
        }

        /// public propaty name  :  COMPANYNMRF_COMPANYNAME2RF
        /// <summary>拠点自社名称2プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点自社名称2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string COMPANYNMRF_COMPANYNAME2RF
        {
            get { return _cOMPANYNMRF_COMPANYNAME2RF; }
            set { _cOMPANYNMRF_COMPANYNAME2RF = value; }
        }

        /// public propaty name  :  COMPANYNMRF_POSTNORF
        /// <summary>拠点郵便番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点郵便番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string COMPANYNMRF_POSTNORF
        {
            get { return _cOMPANYNMRF_POSTNORF; }
            set { _cOMPANYNMRF_POSTNORF = value; }
        }

        /// public propaty name  :  COMPANYNMRF_ADDRESS1RF
        /// <summary>拠点住所1（都道府県市区郡・町村・字）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点住所1（都道府県市区郡・町村・字）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string COMPANYNMRF_ADDRESS1RF
        {
            get { return _cOMPANYNMRF_ADDRESS1RF; }
            set { _cOMPANYNMRF_ADDRESS1RF = value; }
        }

        /// public propaty name  :  COMPANYNMRF_ADDRESS3RF
        /// <summary>拠点住所3（番地）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点住所3（番地）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string COMPANYNMRF_ADDRESS3RF
        {
            get { return _cOMPANYNMRF_ADDRESS3RF; }
            set { _cOMPANYNMRF_ADDRESS3RF = value; }
        }

        /// public propaty name  :  COMPANYNMRF_ADDRESS4RF
        /// <summary>拠点住所4（アパート名称）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点住所4（アパート名称）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string COMPANYNMRF_ADDRESS4RF
        {
            get { return _cOMPANYNMRF_ADDRESS4RF; }
            set { _cOMPANYNMRF_ADDRESS4RF = value; }
        }

        /// public propaty name  :  COMPANYNMRF_COMPANYTELNO1RF
        /// <summary>拠点自社電話番号1プロパティ</summary>
        /// <value>TEL</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点自社電話番号1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string COMPANYNMRF_COMPANYTELNO1RF
        {
            get { return _cOMPANYNMRF_COMPANYTELNO1RF; }
            set { _cOMPANYNMRF_COMPANYTELNO1RF = value; }
        }

        /// public propaty name  :  COMPANYNMRF_COMPANYTELNO2RF
        /// <summary>拠点自社電話番号2プロパティ</summary>
        /// <value>TEL2</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点自社電話番号2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string COMPANYNMRF_COMPANYTELNO2RF
        {
            get { return _cOMPANYNMRF_COMPANYTELNO2RF; }
            set { _cOMPANYNMRF_COMPANYTELNO2RF = value; }
        }

        /// public propaty name  :  COMPANYNMRF_COMPANYTELNO3RF
        /// <summary>拠点自社電話番号3プロパティ</summary>
        /// <value>FAX</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点自社電話番号3プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string COMPANYNMRF_COMPANYTELNO3RF
        {
            get { return _cOMPANYNMRF_COMPANYTELNO3RF; }
            set { _cOMPANYNMRF_COMPANYTELNO3RF = value; }
        }

        /// public propaty name  :  COMPANYNMRF_COMPANYTELTITLE1RF
        /// <summary>拠点自社電話番号タイトル1プロパティ</summary>
        /// <value>TEL</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点自社電話番号タイトル1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string COMPANYNMRF_COMPANYTELTITLE1RF
        {
            get { return _cOMPANYNMRF_COMPANYTELTITLE1RF; }
            set { _cOMPANYNMRF_COMPANYTELTITLE1RF = value; }
        }

        /// public propaty name  :  COMPANYNMRF_COMPANYTELTITLE2RF
        /// <summary>拠点自社電話番号タイトル2プロパティ</summary>
        /// <value>TEL2</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点自社電話番号タイトル2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string COMPANYNMRF_COMPANYTELTITLE2RF
        {
            get { return _cOMPANYNMRF_COMPANYTELTITLE2RF; }
            set { _cOMPANYNMRF_COMPANYTELTITLE2RF = value; }
        }

        /// public propaty name  :  COMPANYNMRF_COMPANYTELTITLE3RF
        /// <summary>拠点自社電話番号タイトル3プロパティ</summary>
        /// <value>FAX</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点自社電話番号タイトル3プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string COMPANYNMRF_COMPANYTELTITLE3RF
        {
            get { return _cOMPANYNMRF_COMPANYTELTITLE3RF; }
            set { _cOMPANYNMRF_COMPANYTELTITLE3RF = value; }
        }

        /// public propaty name  :  COMPANYNMRF_TRANSFERGUIDANCERF
        /// <summary>拠点銀行振込案内文プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点銀行振込案内文プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string COMPANYNMRF_TRANSFERGUIDANCERF
        {
            get { return _cOMPANYNMRF_TRANSFERGUIDANCERF; }
            set { _cOMPANYNMRF_TRANSFERGUIDANCERF = value; }
        }

        /// public propaty name  :  COMPANYNMRF_ACCOUNTNOINFO1RF
        /// <summary>拠点銀行口座1プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点銀行口座1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string COMPANYNMRF_ACCOUNTNOINFO1RF
        {
            get { return _cOMPANYNMRF_ACCOUNTNOINFO1RF; }
            set { _cOMPANYNMRF_ACCOUNTNOINFO1RF = value; }
        }

        /// public propaty name  :  COMPANYNMRF_ACCOUNTNOINFO2RF
        /// <summary>拠点銀行口座2プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点銀行口座2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string COMPANYNMRF_ACCOUNTNOINFO2RF
        {
            get { return _cOMPANYNMRF_ACCOUNTNOINFO2RF; }
            set { _cOMPANYNMRF_ACCOUNTNOINFO2RF = value; }
        }

        /// public propaty name  :  COMPANYNMRF_ACCOUNTNOINFO3RF
        /// <summary>拠点銀行口座3プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点銀行口座3プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string COMPANYNMRF_ACCOUNTNOINFO3RF
        {
            get { return _cOMPANYNMRF_ACCOUNTNOINFO3RF; }
            set { _cOMPANYNMRF_ACCOUNTNOINFO3RF = value; }
        }

        /// public propaty name  :  COMPANYNMRF_COMPANYSETNOTE1RF
        /// <summary>拠点自社設定摘要1プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点自社設定摘要1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string COMPANYNMRF_COMPANYSETNOTE1RF
        {
            get { return _cOMPANYNMRF_COMPANYSETNOTE1RF; }
            set { _cOMPANYNMRF_COMPANYSETNOTE1RF = value; }
        }

        /// public propaty name  :  COMPANYNMRF_COMPANYSETNOTE2RF
        /// <summary>拠点自社設定摘要2プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点自社設定摘要2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string COMPANYNMRF_COMPANYSETNOTE2RF
        {
            get { return _cOMPANYNMRF_COMPANYSETNOTE2RF; }
            set { _cOMPANYNMRF_COMPANYSETNOTE2RF = value; }
        }

        /// public propaty name  :  COMPANYNMRF_COMPANYURLRF
        /// <summary>拠点自社URLプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点自社URLプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string COMPANYNMRF_COMPANYURLRF
        {
            get { return _cOMPANYNMRF_COMPANYURLRF; }
            set { _cOMPANYNMRF_COMPANYURLRF = value; }
        }

        /// public propaty name  :  COMPANYNMRF_COMPANYPRSENTENCE2RF
        /// <summary>拠点自社PR文2プロパティ</summary>
        /// <value>代表取締役等の情報を入力</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点自社PR文2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string COMPANYNMRF_COMPANYPRSENTENCE2RF
        {
            get { return _cOMPANYNMRF_COMPANYPRSENTENCE2RF; }
            set { _cOMPANYNMRF_COMPANYPRSENTENCE2RF = value; }
        }

        /// public propaty name  :  COMPANYNMRF_IMAGECOMMENTFORPRT1RF
        /// <summary>拠点画像印字用コメント1プロパティ</summary>
        /// <value>画像印字する場合、画像の下に印字する（拠点名等）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点画像印字用コメント1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string COMPANYNMRF_IMAGECOMMENTFORPRT1RF
        {
            get { return _cOMPANYNMRF_IMAGECOMMENTFORPRT1RF; }
            set { _cOMPANYNMRF_IMAGECOMMENTFORPRT1RF = value; }
        }

        /// public propaty name  :  COMPANYNMRF_IMAGECOMMENTFORPRT2RF
        /// <summary>拠点画像印字用コメント2プロパティ</summary>
        /// <value>画像印字する場合、画像の下に印字する（拠点名等）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点画像印字用コメント2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string COMPANYNMRF_IMAGECOMMENTFORPRT2RF
        {
            get { return _cOMPANYNMRF_IMAGECOMMENTFORPRT2RF; }
            set { _cOMPANYNMRF_IMAGECOMMENTFORPRT2RF = value; }
        }

        /// public propaty name  :  IMAGEINFORF_IMAGEINFODATARF
        /// <summary>拠点自社画像プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点自社画像プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Byte[] IMAGEINFORF_IMAGEINFODATARF
        {
            get { return _iMAGEINFORF_IMAGEINFODATARF; }
            set { _iMAGEINFORF_IMAGEINFODATARF = value; }
        }

        /// public propaty field.NameJp  :  IMAGEINFORF_IMAGEINFODATARFImageObject
        /// <summary>拠点自社画像プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点自社画像プロパティ</br>
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

        /// public propaty name  :  HEST_FOOTNOTES1RF
        /// <summary>脚注１プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   脚注１プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HEST_FOOTNOTES1RF
        {
            get { return _hEST_FOOTNOTES1RF; }
            set { _hEST_FOOTNOTES1RF = value; }
        }

        /// public propaty name  :  HEST_FOOTNOTES2RF
        /// <summary>脚注２プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   脚注２プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HEST_FOOTNOTES2RF
        {
            get { return _hEST_FOOTNOTES2RF; }
            set { _hEST_FOOTNOTES2RF = value; }
        }

        /// public propaty name  :  HEST_ESTIMATETITLE1RF
        /// <summary>見積タイトル１プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   見積タイトル１プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HEST_ESTIMATETITLE1RF
        {
            get { return _hEST_ESTIMATETITLE1RF; }
            set { _hEST_ESTIMATETITLE1RF = value; }
        }

        /// public propaty name  :  HEST_ESTIMATETITLE2RF
        /// <summary>見積タイトル２プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   見積タイトル２プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HEST_ESTIMATETITLE2RF
        {
            get { return _hEST_ESTIMATETITLE2RF; }
            set { _hEST_ESTIMATETITLE2RF = value; }
        }

        /// public propaty name  :  HEST_ESTIMATETITLE3RF
        /// <summary>見積タイトル３プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   見積タイトル３プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HEST_ESTIMATETITLE3RF
        {
            get { return _hEST_ESTIMATETITLE3RF; }
            set { _hEST_ESTIMATETITLE3RF = value; }
        }

        /// public propaty name  :  HEST_ESTIMATETITLE4RF
        /// <summary>見積タイトル４プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   見積タイトル４プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HEST_ESTIMATETITLE4RF
        {
            get { return _hEST_ESTIMATETITLE4RF; }
            set { _hEST_ESTIMATETITLE4RF = value; }
        }

        /// public propaty name  :  HEST_ESTIMATETITLE5RF
        /// <summary>見積タイトル５プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   見積タイトル５プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HEST_ESTIMATETITLE5RF
        {
            get { return _hEST_ESTIMATETITLE5RF; }
            set { _hEST_ESTIMATETITLE5RF = value; }
        }

        /// public propaty name  :  HEST_ESTIMATENOTE1RF
        /// <summary>見積備考１プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   見積備考１プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HEST_ESTIMATENOTE1RF
        {
            get { return _hEST_ESTIMATENOTE1RF; }
            set { _hEST_ESTIMATENOTE1RF = value; }
        }

        /// public propaty name  :  HEST_ESTIMATENOTE2RF
        /// <summary>見積備考２プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   見積備考２プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HEST_ESTIMATENOTE2RF
        {
            get { return _hEST_ESTIMATENOTE2RF; }
            set { _hEST_ESTIMATENOTE2RF = value; }
        }

        /// public propaty name  :  HEST_ESTIMATENOTE3RF
        /// <summary>見積備考３プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   見積備考３プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HEST_ESTIMATENOTE3RF
        {
            get { return _hEST_ESTIMATENOTE3RF; }
            set { _hEST_ESTIMATENOTE3RF = value; }
        }

        /// public propaty name  :  HEST_ESTIMATENOTE4RF
        /// <summary>見積備考４プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   見積備考４プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HEST_ESTIMATENOTE4RF
        {
            get { return _hEST_ESTIMATENOTE4RF; }
            set { _hEST_ESTIMATENOTE4RF = value; }
        }

        /// public propaty name  :  HEST_ESTIMATENOTE5RF
        /// <summary>見積備考５プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   見積備考５プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HEST_ESTIMATENOTE5RF
        {
            get { return _hEST_ESTIMATENOTE5RF; }
            set { _hEST_ESTIMATENOTE5RF = value; }
        }

        /// public propaty name  :  HEST_ESTIMATEVALIDITYLIMITRF
        /// <summary>見積書有効期日プロパティ</summary>
        /// <value>YYYYMMDD　発行日から見積書有効期限に設定された月数分あと</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   見積書有効期日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime HEST_ESTIMATEVALIDITYLIMITRF
        {
            get { return _hEST_ESTIMATEVALIDITYLIMITRF; }
            set { _hEST_ESTIMATEVALIDITYLIMITRF = value; }
        }

        /// public propaty name  :  HEST_ESTIMATEVALIDITYLIMITFYRF
        /// <summary>見積書有効期日西暦年プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   見積書有効期日西暦年プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 HEST_ESTIMATEVALIDITYLIMITFYRF
        {
            get { return _hEST_ESTIMATEVALIDITYLIMITFYRF; }
            set { _hEST_ESTIMATEVALIDITYLIMITFYRF = value; }
        }

        /// public propaty name  :  HEST_ESTIMATEVALIDITYLIMITFSRF
        /// <summary>見積書有効期日西暦年略プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   見積書有効期日西暦年略プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 HEST_ESTIMATEVALIDITYLIMITFSRF
        {
            get { return _hEST_ESTIMATEVALIDITYLIMITFSRF; }
            set { _hEST_ESTIMATEVALIDITYLIMITFSRF = value; }
        }

        /// public propaty name  :  HEST_ESTIMATEVALIDITYLIMITFWRF
        /// <summary>見積書有効期日和暦年プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   見積書有効期日和暦年プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 HEST_ESTIMATEVALIDITYLIMITFWRF
        {
            get { return _hEST_ESTIMATEVALIDITYLIMITFWRF; }
            set { _hEST_ESTIMATEVALIDITYLIMITFWRF = value; }
        }

        /// public propaty name  :  HEST_ESTIMATEVALIDITYLIMITFMRF
        /// <summary>見積書有効期日月プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   見積書有効期日月プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 HEST_ESTIMATEVALIDITYLIMITFMRF
        {
            get { return _hEST_ESTIMATEVALIDITYLIMITFMRF; }
            set { _hEST_ESTIMATEVALIDITYLIMITFMRF = value; }
        }

        /// public propaty name  :  HEST_ESTIMATEVALIDITYLIMITFDRF
        /// <summary>見積書有効期日日プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   見積書有効期日日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 HEST_ESTIMATEVALIDITYLIMITFDRF
        {
            get { return _hEST_ESTIMATEVALIDITYLIMITFDRF; }
            set { _hEST_ESTIMATEVALIDITYLIMITFDRF = value; }
        }

        /// public propaty name  :  HEST_ESTIMATEVALIDITYLIMITFGRF
        /// <summary>見積書有効期日元号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   見積書有効期日元号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HEST_ESTIMATEVALIDITYLIMITFGRF
        {
            get { return _hEST_ESTIMATEVALIDITYLIMITFGRF; }
            set { _hEST_ESTIMATEVALIDITYLIMITFGRF = value; }
        }

        /// public propaty name  :  HEST_ESTIMATEVALIDITYLIMITFRRF
        /// <summary>見積書有効期日略号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   見積書有効期日略号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HEST_ESTIMATEVALIDITYLIMITFRRF
        {
            get { return _hEST_ESTIMATEVALIDITYLIMITFRRF; }
            set { _hEST_ESTIMATEVALIDITYLIMITFRRF = value; }
        }

        /// public propaty name  :  HEST_ESTIMATEVALIDITYLIMITFLSRF
        /// <summary>見積書有効期日リテラル(/)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   見積書有効期日リテラル(/)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HEST_ESTIMATEVALIDITYLIMITFLSRF
        {
            get { return _hEST_ESTIMATEVALIDITYLIMITFLSRF; }
            set { _hEST_ESTIMATEVALIDITYLIMITFLSRF = value; }
        }

        /// public propaty name  :  HEST_ESTIMATEVALIDITYLIMITFLPRF
        /// <summary>見積書有効期日リテラル(.)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   見積書有効期日リテラル(.)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HEST_ESTIMATEVALIDITYLIMITFLPRF
        {
            get { return _hEST_ESTIMATEVALIDITYLIMITFLPRF; }
            set { _hEST_ESTIMATEVALIDITYLIMITFLPRF = value; }
        }

        /// public propaty name  :  HEST_ESTIMATEVALIDITYLIMITFLYRF
        /// <summary>見積書有効期日リテラル(年)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   見積書有効期日リテラル(年)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HEST_ESTIMATEVALIDITYLIMITFLYRF
        {
            get { return _hEST_ESTIMATEVALIDITYLIMITFLYRF; }
            set { _hEST_ESTIMATEVALIDITYLIMITFLYRF = value; }
        }

        /// public propaty name  :  HEST_ESTIMATEVALIDITYLIMITFLMRF
        /// <summary>見積書有効期日リテラル(月)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   見積書有効期日リテラル(月)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HEST_ESTIMATEVALIDITYLIMITFLMRF
        {
            get { return _hEST_ESTIMATEVALIDITYLIMITFLMRF; }
            set { _hEST_ESTIMATEVALIDITYLIMITFLMRF = value; }
        }

        /// public propaty name  :  HEST_ESTIMATEVALIDITYLIMITFLDRF
        /// <summary>見積書有効期日リテラル(日)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   見積書有効期日リテラル(日)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HEST_ESTIMATEVALIDITYLIMITFLDRF
        {
            get { return _hEST_ESTIMATEVALIDITYLIMITFLDRF; }
            set { _hEST_ESTIMATEVALIDITYLIMITFLDRF = value; }
        }

        /// public propaty name  :  HADD_CARMNGNORF
        /// <summary>車両管理番号プロパティ</summary>
        /// <value>自動採番（無重複のシーケンス）PM7での車両SEQ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車両管理番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 HADD_CARMNGNORF
        {
            get { return _hADD_CARMNGNORF; }
            set { _hADD_CARMNGNORF = value; }
        }

        /// public propaty name  :  HADD_CARMNGCODERF
        /// <summary>車輌管理コードプロパティ</summary>
        /// <value>※PM7での車両管理番号</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車輌管理コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_CARMNGCODERF
        {
            get { return _hADD_CARMNGCODERF; }
            set { _hADD_CARMNGCODERF = value; }
        }

        /// public propaty name  :  HADD_NUMBERPLATE1CODERF
        /// <summary>陸運事務所番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   陸運事務所番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 HADD_NUMBERPLATE1CODERF
        {
            get { return _hADD_NUMBERPLATE1CODERF; }
            set { _hADD_NUMBERPLATE1CODERF = value; }
        }

        /// public propaty name  :  HADD_NUMBERPLATE1NAMERF
        /// <summary>陸運事務局名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   陸運事務局名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_NUMBERPLATE1NAMERF
        {
            get { return _hADD_NUMBERPLATE1NAMERF; }
            set { _hADD_NUMBERPLATE1NAMERF = value; }
        }

        /// public propaty name  :  HADD_NUMBERPLATE2RF
        /// <summary>車両登録番号（種別）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車両登録番号（種別）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_NUMBERPLATE2RF
        {
            get { return _hADD_NUMBERPLATE2RF; }
            set { _hADD_NUMBERPLATE2RF = value; }
        }

        /// public propaty name  :  HADD_NUMBERPLATE3RF
        /// <summary>車両登録番号（カナ）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車両登録番号（カナ）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_NUMBERPLATE3RF
        {
            get { return _hADD_NUMBERPLATE3RF; }
            set { _hADD_NUMBERPLATE3RF = value; }
        }

        /// public propaty name  :  HADD_NUMBERPLATE4RF
        /// <summary>車両登録番号（プレート番号）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車両登録番号（プレート番号）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 HADD_NUMBERPLATE4RF
        {
            get { return _hADD_NUMBERPLATE4RF; }
            set { _hADD_NUMBERPLATE4RF = value; }
        }

        /// public propaty name  :  HADD_FIRSTENTRYDATERF
        /// <summary>初年度プロパティ</summary>
        /// <value>YYYYMM</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   初年度プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public int HADD_FIRSTENTRYDATERF
        {
            get { return _hADD_FIRSTENTRYDATERF; }
            set { _hADD_FIRSTENTRYDATERF = value; }
        }

        /// public propaty name  :  HADD_MAKERCODERF
        /// <summary>メーカーコードプロパティ</summary>
        /// <value>1～899:提供分, 900～ユーザー登録</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メーカーコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 HADD_MAKERCODERF
        {
            get { return _hADD_MAKERCODERF; }
            set { _hADD_MAKERCODERF = value; }
        }

        /// public propaty name  :  HADD_MAKERFULLNAMERF
        /// <summary>メーカー全角名称プロパティ</summary>
        /// <value>正式名称（カナ漢字混在で全角管理）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メーカー全角名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_MAKERFULLNAMERF
        {
            get { return _hADD_MAKERFULLNAMERF; }
            set { _hADD_MAKERFULLNAMERF = value; }
        }

        /// public propaty name  :  HADD_MAKERHALFNAMERF
        /// <summary>メーカー半角名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メーカー半角名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_MAKERHALFNAMERF
        {
            get { return _hADD_MAKERHALFNAMERF; }
            set { _hADD_MAKERHALFNAMERF = value; }
        }

        /// public propaty name  :  HADD_MODELCODERF
        /// <summary>車種コードプロパティ</summary>
        /// <value>車名コード(翼) 1～899:提供分, 900～ユーザー登録</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車種コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 HADD_MODELCODERF
        {
            get { return _hADD_MODELCODERF; }
            set { _hADD_MODELCODERF = value; }
        }

        /// public propaty name  :  HADD_MODELSUBCODERF
        /// <summary>車種サブコードプロパティ</summary>
        /// <value>0～899:提供分,900～ﾕｰｻﾞｰ登録</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車種サブコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 HADD_MODELSUBCODERF
        {
            get { return _hADD_MODELSUBCODERF; }
            set { _hADD_MODELSUBCODERF = value; }
        }

        /// public propaty name  :  HADD_MODELFULLNAMERF
        /// <summary>車種全角名称プロパティ</summary>
        /// <value>正式名称（カナ漢字混在で全角管理）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車種全角名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_MODELFULLNAMERF
        {
            get { return _hADD_MODELFULLNAMERF; }
            set { _hADD_MODELFULLNAMERF = value; }
        }

        /// public propaty name  :  HADD_MODELHALFNAMERF
        /// <summary>車種半角名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車種半角名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_MODELHALFNAMERF
        {
            get { return _hADD_MODELHALFNAMERF; }
            set { _hADD_MODELHALFNAMERF = value; }
        }

        /// public propaty name  :  HADD_EXHAUSTGASSIGNRF
        /// <summary>排ガス記号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   排ガス記号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_EXHAUSTGASSIGNRF
        {
            get { return _hADD_EXHAUSTGASSIGNRF; }
            set { _hADD_EXHAUSTGASSIGNRF = value; }
        }

        /// public propaty name  :  HADD_SERIESMODELRF
        /// <summary>シリーズ型式プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   シリーズ型式プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_SERIESMODELRF
        {
            get { return _hADD_SERIESMODELRF; }
            set { _hADD_SERIESMODELRF = value; }
        }

        /// public propaty name  :  HADD_CATEGORYSIGNMODELRF
        /// <summary>型式（類別記号）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   型式（類別記号）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_CATEGORYSIGNMODELRF
        {
            get { return _hADD_CATEGORYSIGNMODELRF; }
            set { _hADD_CATEGORYSIGNMODELRF = value; }
        }

        /// public propaty name  :  HADD_FULLMODELRF
        /// <summary>型式（フル型）プロパティ</summary>
        /// <value>フル型式(44桁用)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   型式（フル型）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_FULLMODELRF
        {
            get { return _hADD_FULLMODELRF; }
            set { _hADD_FULLMODELRF = value; }
        }

        /// public propaty name  :  HADD_MODELDESIGNATIONNORF
        /// <summary>型式指定番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   型式指定番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 HADD_MODELDESIGNATIONNORF
        {
            get { return _hADD_MODELDESIGNATIONNORF; }
            set { _hADD_MODELDESIGNATIONNORF = value; }
        }

        /// public propaty name  :  HADD_CATEGORYNORF
        /// <summary>類別番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   類別番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 HADD_CATEGORYNORF
        {
            get { return _hADD_CATEGORYNORF; }
            set { _hADD_CATEGORYNORF = value; }
        }

        /// public propaty name  :  HADD_FRAMEMODELRF
        /// <summary>車台型式プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車台型式プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_FRAMEMODELRF
        {
            get { return _hADD_FRAMEMODELRF; }
            set { _hADD_FRAMEMODELRF = value; }
        }

        /// public propaty name  :  HADD_FRAMENORF
        /// <summary>車台番号プロパティ</summary>
        /// <value>車検証記載フォーマット対応（ HCR32-100251584 等）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車台番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_FRAMENORF
        {
            get { return _hADD_FRAMENORF; }
            set { _hADD_FRAMENORF = value; }
        }

        /// public propaty name  :  HADD_SEARCHFRAMENORF
        /// <summary>車台番号（検索用）プロパティ</summary>
        /// <value>PM7の車台番号と同意</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車台番号（検索用）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 HADD_SEARCHFRAMENORF
        {
            get { return _hADD_SEARCHFRAMENORF; }
            set { _hADD_SEARCHFRAMENORF = value; }
        }

        /// public propaty name  :  HADD_ENGINEMODELNMRF
        /// <summary>エンジン型式名称プロパティ</summary>
        /// <value>エンジン検索</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   エンジン型式名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_ENGINEMODELNMRF
        {
            get { return _hADD_ENGINEMODELNMRF; }
            set { _hADD_ENGINEMODELNMRF = value; }
        }

        /// public propaty name  :  HADD_RELEVANCEMODELRF
        /// <summary>関連型式プロパティ</summary>
        /// <value>リサイクル系で使用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   関連型式プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_RELEVANCEMODELRF
        {
            get { return _hADD_RELEVANCEMODELRF; }
            set { _hADD_RELEVANCEMODELRF = value; }
        }

        /// public propaty name  :  HADD_SUBCARNMCDRF
        /// <summary>サブ車名コードプロパティ</summary>
        /// <value>リサイクル系で使用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   サブ車名コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 HADD_SUBCARNMCDRF
        {
            get { return _hADD_SUBCARNMCDRF; }
            set { _hADD_SUBCARNMCDRF = value; }
        }

        /// public propaty name  :  HADD_MODELGRADESNAMERF
        /// <summary>型式グレード略称プロパティ</summary>
        /// <value>リサイクル系で使用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   型式グレード略称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_MODELGRADESNAMERF
        {
            get { return _hADD_MODELGRADESNAMERF; }
            set { _hADD_MODELGRADESNAMERF = value; }
        }

        /// public propaty name  :  HADD_COLORCODERF
        /// <summary>カラーコードプロパティ</summary>
        /// <value>カタログの色コード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   カラーコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_COLORCODERF
        {
            get { return _hADD_COLORCODERF; }
            set { _hADD_COLORCODERF = value; }
        }

        /// public propaty name  :  HADD_COLORNAME1RF
        /// <summary>カラー名称1プロパティ</summary>
        /// <value>画面表示用正式名称</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   カラー名称1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_COLORNAME1RF
        {
            get { return _hADD_COLORNAME1RF; }
            set { _hADD_COLORNAME1RF = value; }
        }

        /// public propaty name  :  HADD_TRIMCODERF
        /// <summary>トリムコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   トリムコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_TRIMCODERF
        {
            get { return _hADD_TRIMCODERF; }
            set { _hADD_TRIMCODERF = value; }
        }

        /// public propaty name  :  HADD_TRIMNAMERF
        /// <summary>トリム名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   トリム名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_TRIMNAMERF
        {
            get { return _hADD_TRIMNAMERF; }
            set { _hADD_TRIMNAMERF = value; }
        }

        /// public propaty name  :  HADD_MILEAGERF
        /// <summary>車両走行距離プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車両走行距離プロパティ</br>
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

        /// public propaty name  :  HADD_FIRSTENTRYDATEFYRF
        /// <summary>初年度西暦年プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   初年度西暦年プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 HADD_FIRSTENTRYDATEFYRF
        {
            get { return _hADD_FIRSTENTRYDATEFYRF; }
            set { _hADD_FIRSTENTRYDATEFYRF = value; }
        }

        /// public propaty name  :  HADD_FIRSTENTRYDATEFSRF
        /// <summary>初年度西暦年略プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   初年度西暦年略プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 HADD_FIRSTENTRYDATEFSRF
        {
            get { return _hADD_FIRSTENTRYDATEFSRF; }
            set { _hADD_FIRSTENTRYDATEFSRF = value; }
        }

        /// public propaty name  :  HADD_FIRSTENTRYDATEFWRF
        /// <summary>初年度和暦年プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   初年度和暦年プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 HADD_FIRSTENTRYDATEFWRF
        {
            get { return _hADD_FIRSTENTRYDATEFWRF; }
            set { _hADD_FIRSTENTRYDATEFWRF = value; }
        }

        /// public propaty name  :  HADD_FIRSTENTRYDATEFMRF
        /// <summary>初年度月プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   初年度月プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 HADD_FIRSTENTRYDATEFMRF
        {
            get { return _hADD_FIRSTENTRYDATEFMRF; }
            set { _hADD_FIRSTENTRYDATEFMRF = value; }
        }

        /// public propaty name  :  HADD_FIRSTENTRYDATEFGRF
        /// <summary>初年度元号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   初年度元号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_FIRSTENTRYDATEFGRF
        {
            get { return _hADD_FIRSTENTRYDATEFGRF; }
            set { _hADD_FIRSTENTRYDATEFGRF = value; }
        }

        /// public propaty name  :  HADD_FIRSTENTRYDATEFRRF
        /// <summary>初年度略号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   初年度略号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_FIRSTENTRYDATEFRRF
        {
            get { return _hADD_FIRSTENTRYDATEFRRF; }
            set { _hADD_FIRSTENTRYDATEFRRF = value; }
        }

        /// public propaty name  :  HADD_FIRSTENTRYDATEFLSRF
        /// <summary>初年度リテラル(/)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   初年度リテラル(/)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_FIRSTENTRYDATEFLSRF
        {
            get { return _hADD_FIRSTENTRYDATEFLSRF; }
            set { _hADD_FIRSTENTRYDATEFLSRF = value; }
        }

        /// public propaty name  :  HADD_FIRSTENTRYDATEFLPRF
        /// <summary>初年度リテラル(.)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   初年度リテラル(.)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_FIRSTENTRYDATEFLPRF
        {
            get { return _hADD_FIRSTENTRYDATEFLPRF; }
            set { _hADD_FIRSTENTRYDATEFLPRF = value; }
        }

        /// public propaty name  :  HADD_FIRSTENTRYDATEFLYRF
        /// <summary>初年度リテラル(年)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   初年度リテラル(年)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_FIRSTENTRYDATEFLYRF
        {
            get { return _hADD_FIRSTENTRYDATEFLYRF; }
            set { _hADD_FIRSTENTRYDATEFLYRF = value; }
        }

        /// public propaty name  :  HADD_FIRSTENTRYDATEFLMRF
        /// <summary>初年度リテラル(月)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   初年度リテラル(月)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_FIRSTENTRYDATEFLMRF
        {
            get { return _hADD_FIRSTENTRYDATEFLMRF; }
            set { _hADD_FIRSTENTRYDATEFLMRF = value; }
        }

        /// public propaty name  :  HADD_PRINTCUSTOMERNM1RF
        /// <summary>印刷用得意先名称(上段)プロパティ</summary>
        /// <value>印刷プログラムで制御する得意先名称項目</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   印刷用得意先名称(上段)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_PRINTCUSTOMERNM1RF
        {
            get { return _hADD_PRINTCUSTOMERNM1RF; }
            set { _hADD_PRINTCUSTOMERNM1RF = value; }
        }

        /// public propaty name  :  HADD_PRINTCUSTOMERNM2RF
        /// <summary>印刷用得意先名称(下段)プロパティ</summary>
        /// <value>印刷プログラムで制御する得意先名称項目</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   印刷用得意先名称(下段)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_PRINTCUSTOMERNM2RF
        {
            get { return _hADD_PRINTCUSTOMERNM2RF; }
            set { _hADD_PRINTCUSTOMERNM2RF = value; }
        }

        /// public propaty name  :  HPURE_SALESTOTALTAXINCRF
        /// <summary>純正売上伝票合計（税込み）プロパティ</summary>
        /// <value>売上正価金額＋売上値引金額計（税抜き）＋売上金額消費税額</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   純正売上伝票合計（税込み）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 HPURE_SALESTOTALTAXINCRF
        {
            get { return _hPURE_SALESTOTALTAXINCRF; }
            set { _hPURE_SALESTOTALTAXINCRF = value; }
        }

        /// public propaty name  :  HPURE_SALESTOTALTAXEXCRF
        /// <summary>純正売上伝票合計（税抜き）プロパティ</summary>
        /// <value>売上正価金額＋売上値引金額計（税抜き）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   純正売上伝票合計（税抜き）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 HPURE_SALESTOTALTAXEXCRF
        {
            get { return _hPURE_SALESTOTALTAXEXCRF; }
            set { _hPURE_SALESTOTALTAXEXCRF = value; }
        }

        /// public propaty name  :  HPURE_SALESSUBTOTALTAXINCRF
        /// <summary>純正売上小計（税込み）プロパティ</summary>
        /// <value>値引後の明細金額の合計（非課税含まず）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   純正売上小計（税込み）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 HPURE_SALESSUBTOTALTAXINCRF
        {
            get { return _hPURE_SALESSUBTOTALTAXINCRF; }
            set { _hPURE_SALESSUBTOTALTAXINCRF = value; }
        }

        /// public propaty name  :  HPURE_SALESSUBTOTALTAXEXCRF
        /// <summary>純正売上小計（税抜き）プロパティ</summary>
        /// <value>値引後の明細金額の合計（非課税含まず）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   純正売上小計（税抜き）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 HPURE_SALESSUBTOTALTAXEXCRF
        {
            get { return _hPURE_SALESSUBTOTALTAXEXCRF; }
            set { _hPURE_SALESSUBTOTALTAXEXCRF = value; }
        }

        /// public propaty name  :  HPURE_SALESSUBTOTALTAXRF
        /// <summary>純正売上小計（税）プロパティ</summary>
        /// <value>外税対象金額の集計（税抜、値引含まず）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   純正売上小計（税）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 HPURE_SALESSUBTOTALTAXRF
        {
            get { return _hPURE_SALESSUBTOTALTAXRF; }
            set { _hPURE_SALESSUBTOTALTAXRF = value; }
        }

        /// public propaty name  :  HPRIME_SALESTOTALTAXINCRF
        /// <summary>優良売上伝票合計（税込み）プロパティ</summary>
        /// <value>売上正価金額＋売上値引金額計（税抜き）＋売上金額消費税額</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   優良売上伝票合計（税込み）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 HPRIME_SALESTOTALTAXINCRF
        {
            get { return _hPRIME_SALESTOTALTAXINCRF; }
            set { _hPRIME_SALESTOTALTAXINCRF = value; }
        }

        /// public propaty name  :  HPRIME_SALESTOTALTAXEXCRF
        /// <summary>優良売上伝票合計（税抜き）プロパティ</summary>
        /// <value>売上正価金額＋売上値引金額計（税抜き）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   優良売上伝票合計（税抜き）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 HPRIME_SALESTOTALTAXEXCRF
        {
            get { return _hPRIME_SALESTOTALTAXEXCRF; }
            set { _hPRIME_SALESTOTALTAXEXCRF = value; }
        }

        /// public propaty name  :  HPRIME_SALESSUBTOTALTAXINCRF
        /// <summary>優良売上小計（税込み）プロパティ</summary>
        /// <value>値引後の明細金額の合計（非課税含まず）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   優良売上小計（税込み）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 HPRIME_SALESSUBTOTALTAXINCRF
        {
            get { return _hPRIME_SALESSUBTOTALTAXINCRF; }
            set { _hPRIME_SALESSUBTOTALTAXINCRF = value; }
        }

        /// public propaty name  :  HPRIME_SALESSUBTOTALTAXEXCRF
        /// <summary>優良売上小計（税抜き）プロパティ</summary>
        /// <value>値引後の明細金額の合計（非課税含まず）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   優良売上小計（税抜き）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 HPRIME_SALESSUBTOTALTAXEXCRF
        {
            get { return _hPRIME_SALESSUBTOTALTAXEXCRF; }
            set { _hPRIME_SALESSUBTOTALTAXEXCRF = value; }
        }

        /// public propaty name  :  HPRIME_SALESSUBTOTALTAXRF
        /// <summary>優良売上小計（税）プロパティ</summary>
        /// <value>外税対象金額の集計（税抜、値引含まず）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   優良売上小計（税）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 HPRIME_SALESSUBTOTALTAXRF
        {
            get { return _hPRIME_SALESSUBTOTALTAXRF; }
            set { _hPRIME_SALESSUBTOTALTAXRF = value; }
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

        /// public propaty name  :  HADD_ESTFMDIVRF
        /// <summary>見積書印刷制御区分プロパティ</summary>
        /// <value>0:全て,1:純正のみ,2:優良のみ,3:選択分のみ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   見積書印刷制御区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public EstFmDivState HADD_ESTFMDIVRF
        {
            get { return _hADD_ESTFMDIVRF; }
            set { _hADD_ESTFMDIVRF = value; }
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

        /// public propaty name  :  HADD_SYSTEMATICCODERF
        /// <summary>系統コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   系統コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 HADD_SYSTEMATICCODERF
        {
            get { return _hADD_SYSTEMATICCODERF; }
            set { _hADD_SYSTEMATICCODERF = value; }
        }

        /// public propaty name  :  HADD_SYSTEMATICNAMERF
        /// <summary>系統名称プロパティ</summary>
        /// <value>140系,180系等</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   系統名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_SYSTEMATICNAMERF
        {
            get { return _hADD_SYSTEMATICNAMERF; }
            set { _hADD_SYSTEMATICNAMERF = value; }
        }

        /// public propaty name  :  HADD_STPRODUCETYPEOFYEARRF
        /// <summary>開始生産年式プロパティ</summary>
        /// <value>YYYYMM</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始生産年式プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime HADD_STPRODUCETYPEOFYEARRF
        {
            get { return _hADD_STPRODUCETYPEOFYEARRF; }
            set { _hADD_STPRODUCETYPEOFYEARRF = value; }
        }

        /// public propaty name  :  HADD_EDPRODUCETYPEOFYEARRF
        /// <summary>終了生産年式プロパティ</summary>
        /// <value>YYYYMM</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了生産年式プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime HADD_EDPRODUCETYPEOFYEARRF
        {
            get { return _hADD_EDPRODUCETYPEOFYEARRF; }
            set { _hADD_EDPRODUCETYPEOFYEARRF = value; }
        }

        /// public propaty name  :  HADD_DOORCOUNTRF
        /// <summary>ドア数プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ドア数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 HADD_DOORCOUNTRF
        {
            get { return _hADD_DOORCOUNTRF; }
            set { _hADD_DOORCOUNTRF = value; }
        }

        /// public propaty name  :  HADD_BODYNAMECODERF
        /// <summary>ボディー名コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ボディー名コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 HADD_BODYNAMECODERF
        {
            get { return _hADD_BODYNAMECODERF; }
            set { _hADD_BODYNAMECODERF = value; }
        }

        /// public propaty name  :  HADD_BODYNAMERF
        /// <summary>ボディー名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ボディー名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_BODYNAMERF
        {
            get { return _hADD_BODYNAMERF; }
            set { _hADD_BODYNAMERF = value; }
        }

        /// public propaty name  :  HADD_STPRODUCEFRAMENORF
        /// <summary>生産車台番号開始プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   生産車台番号開始プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 HADD_STPRODUCEFRAMENORF
        {
            get { return _hADD_STPRODUCEFRAMENORF; }
            set { _hADD_STPRODUCEFRAMENORF = value; }
        }

        /// public propaty name  :  HADD_EDPRODUCEFRAMENORF
        /// <summary>生産車台番号終了プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   生産車台番号終了プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 HADD_EDPRODUCEFRAMENORF
        {
            get { return _hADD_EDPRODUCEFRAMENORF; }
            set { _hADD_EDPRODUCEFRAMENORF = value; }
        }

        /// public propaty name  :  HADD_ENGINEMODELRF
        /// <summary>原動機型式（エンジン）プロパティ</summary>
        /// <value>車検証記載原動機型式</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   原動機型式（エンジン）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_ENGINEMODELRF
        {
            get { return _hADD_ENGINEMODELRF; }
            set { _hADD_ENGINEMODELRF = value; }
        }

        /// public propaty name  :  HADD_MODELGRADENMRF
        /// <summary>型式グレード名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   型式グレード名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_MODELGRADENMRF
        {
            get { return _hADD_MODELGRADENMRF; }
            set { _hADD_MODELGRADENMRF = value; }
        }

        /// public propaty name  :  HADD_ENGINEDISPLACENMRF
        /// <summary>排気量名称プロパティ</summary>
        /// <value>型式により変動</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   排気量名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_ENGINEDISPLACENMRF
        {
            get { return _hADD_ENGINEDISPLACENMRF; }
            set { _hADD_ENGINEDISPLACENMRF = value; }
        }

        /// public propaty name  :  HADD_EDIVNMRF
        /// <summary>E区分名称プロパティ</summary>
        /// <value>型式により変動</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   E区分名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_EDIVNMRF
        {
            get { return _hADD_EDIVNMRF; }
            set { _hADD_EDIVNMRF = value; }
        }

        /// public propaty name  :  HADD_TRANSMISSIONNMRF
        /// <summary>ミッション名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ミッション名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_TRANSMISSIONNMRF
        {
            get { return _hADD_TRANSMISSIONNMRF; }
            set { _hADD_TRANSMISSIONNMRF = value; }
        }

        /// public propaty name  :  HADD_SHIFTNMRF
        /// <summary>シフト名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   シフト名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_SHIFTNMRF
        {
            get { return _hADD_SHIFTNMRF; }
            set { _hADD_SHIFTNMRF = value; }
        }

        /// public propaty name  :  HADD_WHEELDRIVEMETHODNMRF
        /// <summary>駆動方式名称プロパティ</summary>
        /// <value>新規追加</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   駆動方式名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_WHEELDRIVEMETHODNMRF
        {
            get { return _hADD_WHEELDRIVEMETHODNMRF; }
            set { _hADD_WHEELDRIVEMETHODNMRF = value; }
        }

        /// public propaty name  :  HADD_ADDICARSPEC1RF
        /// <summary>追加諸元1プロパティ</summary>
        /// <value>型式により変動</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   追加諸元1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_ADDICARSPEC1RF
        {
            get { return _hADD_ADDICARSPEC1RF; }
            set { _hADD_ADDICARSPEC1RF = value; }
        }

        /// public propaty name  :  HADD_ADDICARSPEC2RF
        /// <summary>追加諸元2プロパティ</summary>
        /// <value>型式により変動</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   追加諸元2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_ADDICARSPEC2RF
        {
            get { return _hADD_ADDICARSPEC2RF; }
            set { _hADD_ADDICARSPEC2RF = value; }
        }

        /// public propaty name  :  HADD_ADDICARSPEC3RF
        /// <summary>追加諸元3プロパティ</summary>
        /// <value>型式により変動</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   追加諸元3プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_ADDICARSPEC3RF
        {
            get { return _hADD_ADDICARSPEC3RF; }
            set { _hADD_ADDICARSPEC3RF = value; }
        }

        /// public propaty name  :  HADD_ADDICARSPEC4RF
        /// <summary>追加諸元4プロパティ</summary>
        /// <value>型式により変動</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   追加諸元4プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_ADDICARSPEC4RF
        {
            get { return _hADD_ADDICARSPEC4RF; }
            set { _hADD_ADDICARSPEC4RF = value; }
        }

        /// public propaty name  :  HADD_ADDICARSPEC5RF
        /// <summary>追加諸元5プロパティ</summary>
        /// <value>型式により変動</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   追加諸元5プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_ADDICARSPEC5RF
        {
            get { return _hADD_ADDICARSPEC5RF; }
            set { _hADD_ADDICARSPEC5RF = value; }
        }

        /// public propaty name  :  HADD_ADDICARSPEC6RF
        /// <summary>追加諸元6プロパティ</summary>
        /// <value>型式により変動</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   追加諸元6プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_ADDICARSPEC6RF
        {
            get { return _hADD_ADDICARSPEC6RF; }
            set { _hADD_ADDICARSPEC6RF = value; }
        }

        /// public propaty name  :  HADD_ADDICARSPECTITLE1RF
        /// <summary>追加諸元タイトル1プロパティ</summary>
        /// <value>型式により変動</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   追加諸元タイトル1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_ADDICARSPECTITLE1RF
        {
            get { return _hADD_ADDICARSPECTITLE1RF; }
            set { _hADD_ADDICARSPECTITLE1RF = value; }
        }

        /// public propaty name  :  HADD_ADDICARSPECTITLE2RF
        /// <summary>追加諸元タイトル2プロパティ</summary>
        /// <value>型式により変動</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   追加諸元タイトル2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_ADDICARSPECTITLE2RF
        {
            get { return _hADD_ADDICARSPECTITLE2RF; }
            set { _hADD_ADDICARSPECTITLE2RF = value; }
        }

        /// public propaty name  :  HADD_ADDICARSPECTITLE3RF
        /// <summary>追加諸元タイトル3プロパティ</summary>
        /// <value>型式により変動</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   追加諸元タイトル3プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_ADDICARSPECTITLE3RF
        {
            get { return _hADD_ADDICARSPECTITLE3RF; }
            set { _hADD_ADDICARSPECTITLE3RF = value; }
        }

        /// public propaty name  :  HADD_ADDICARSPECTITLE4RF
        /// <summary>追加諸元タイトル4プロパティ</summary>
        /// <value>型式により変動</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   追加諸元タイトル4プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_ADDICARSPECTITLE4RF
        {
            get { return _hADD_ADDICARSPECTITLE4RF; }
            set { _hADD_ADDICARSPECTITLE4RF = value; }
        }

        /// public propaty name  :  HADD_ADDICARSPECTITLE5RF
        /// <summary>追加諸元タイトル5プロパティ</summary>
        /// <value>型式により変動</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   追加諸元タイトル5プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_ADDICARSPECTITLE5RF
        {
            get { return _hADD_ADDICARSPECTITLE5RF; }
            set { _hADD_ADDICARSPECTITLE5RF = value; }
        }

        /// public propaty name  :  HADD_ADDICARSPECTITLE6RF
        /// <summary>追加諸元タイトル6プロパティ</summary>
        /// <value>型式により変動</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   追加諸元タイトル6プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_ADDICARSPECTITLE6RF
        {
            get { return _hADD_ADDICARSPECTITLE6RF; }
            set { _hADD_ADDICARSPECTITLE6RF = value; }
        }

        /// public propaty name  :  HADD_STPRODUCETYPEOFYEARFYRF
        /// <summary>開始生産年式西暦年プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始生産年式西暦年プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 HADD_STPRODUCETYPEOFYEARFYRF
        {
            get { return _hADD_STPRODUCETYPEOFYEARFYRF; }
            set { _hADD_STPRODUCETYPEOFYEARFYRF = value; }
        }

        /// public propaty name  :  HADD_STPRODUCETYPEOFYEARFSRF
        /// <summary>開始生産年式西暦年略プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始生産年式西暦年略プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 HADD_STPRODUCETYPEOFYEARFSRF
        {
            get { return _hADD_STPRODUCETYPEOFYEARFSRF; }
            set { _hADD_STPRODUCETYPEOFYEARFSRF = value; }
        }

        /// public propaty name  :  HADD_STPRODUCETYPEOFYEARFWRF
        /// <summary>開始生産年式和暦年プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始生産年式和暦年プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 HADD_STPRODUCETYPEOFYEARFWRF
        {
            get { return _hADD_STPRODUCETYPEOFYEARFWRF; }
            set { _hADD_STPRODUCETYPEOFYEARFWRF = value; }
        }

        /// public propaty name  :  HADD_STPRODUCETYPEOFYEARFMRF
        /// <summary>開始生産年式月プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始生産年式月プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 HADD_STPRODUCETYPEOFYEARFMRF
        {
            get { return _hADD_STPRODUCETYPEOFYEARFMRF; }
            set { _hADD_STPRODUCETYPEOFYEARFMRF = value; }
        }

        /// public propaty name  :  HADD_STPRODUCETYPEOFYEARFGRF
        /// <summary>開始生産年式元号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始生産年式元号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_STPRODUCETYPEOFYEARFGRF
        {
            get { return _hADD_STPRODUCETYPEOFYEARFGRF; }
            set { _hADD_STPRODUCETYPEOFYEARFGRF = value; }
        }

        /// public propaty name  :  HADD_STPRODUCETYPEOFYEARFRRF
        /// <summary>開始生産年式略号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始生産年式略号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_STPRODUCETYPEOFYEARFRRF
        {
            get { return _hADD_STPRODUCETYPEOFYEARFRRF; }
            set { _hADD_STPRODUCETYPEOFYEARFRRF = value; }
        }

        /// public propaty name  :  HADD_STPRODUCETYPEOFYEARFLSRF
        /// <summary>開始生産年式リテラル(/)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始生産年式リテラル(/)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_STPRODUCETYPEOFYEARFLSRF
        {
            get { return _hADD_STPRODUCETYPEOFYEARFLSRF; }
            set { _hADD_STPRODUCETYPEOFYEARFLSRF = value; }
        }

        /// public propaty name  :  HADD_STPRODUCETYPEOFYEARFLPRF
        /// <summary>開始生産年式リテラル(.)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始生産年式リテラル(.)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_STPRODUCETYPEOFYEARFLPRF
        {
            get { return _hADD_STPRODUCETYPEOFYEARFLPRF; }
            set { _hADD_STPRODUCETYPEOFYEARFLPRF = value; }
        }

        /// public propaty name  :  HADD_STPRODUCETYPEOFYEARFLYRF
        /// <summary>開始生産年式リテラル(年)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始生産年式リテラル(年)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_STPRODUCETYPEOFYEARFLYRF
        {
            get { return _hADD_STPRODUCETYPEOFYEARFLYRF; }
            set { _hADD_STPRODUCETYPEOFYEARFLYRF = value; }
        }

        /// public propaty name  :  HADD_STPRODUCETYPEOFYEARFLMRF
        /// <summary>開始生産年式リテラル(月)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始生産年式リテラル(月)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_STPRODUCETYPEOFYEARFLMRF
        {
            get { return _hADD_STPRODUCETYPEOFYEARFLMRF; }
            set { _hADD_STPRODUCETYPEOFYEARFLMRF = value; }
        }

        /// public propaty name  :  HADD_EDPRODUCETYPEOFYEARFYRF
        /// <summary>終了生産年式西暦年プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了生産年式西暦年プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 HADD_EDPRODUCETYPEOFYEARFYRF
        {
            get { return _hADD_EDPRODUCETYPEOFYEARFYRF; }
            set { _hADD_EDPRODUCETYPEOFYEARFYRF = value; }
        }

        /// public propaty name  :  HADD_EDPRODUCETYPEOFYEARFSRF
        /// <summary>終了生産年式西暦年略プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了生産年式西暦年略プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 HADD_EDPRODUCETYPEOFYEARFSRF
        {
            get { return _hADD_EDPRODUCETYPEOFYEARFSRF; }
            set { _hADD_EDPRODUCETYPEOFYEARFSRF = value; }
        }

        /// public propaty name  :  HADD_EDPRODUCETYPEOFYEARFWRF
        /// <summary>終了生産年式和暦年プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了生産年式和暦年プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 HADD_EDPRODUCETYPEOFYEARFWRF
        {
            get { return _hADD_EDPRODUCETYPEOFYEARFWRF; }
            set { _hADD_EDPRODUCETYPEOFYEARFWRF = value; }
        }

        /// public propaty name  :  HADD_EDPRODUCETYPEOFYEARFMRF
        /// <summary>終了生産年式月プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了生産年式月プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 HADD_EDPRODUCETYPEOFYEARFMRF
        {
            get { return _hADD_EDPRODUCETYPEOFYEARFMRF; }
            set { _hADD_EDPRODUCETYPEOFYEARFMRF = value; }
        }

        /// public propaty name  :  HADD_EDPRODUCETYPEOFYEARFGRF
        /// <summary>終了生産年式元号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了生産年式元号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_EDPRODUCETYPEOFYEARFGRF
        {
            get { return _hADD_EDPRODUCETYPEOFYEARFGRF; }
            set { _hADD_EDPRODUCETYPEOFYEARFGRF = value; }
        }

        /// public propaty name  :  HADD_EDPRODUCETYPEOFYEARFRRF
        /// <summary>終了生産年式略号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了生産年式略号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_EDPRODUCETYPEOFYEARFRRF
        {
            get { return _hADD_EDPRODUCETYPEOFYEARFRRF; }
            set { _hADD_EDPRODUCETYPEOFYEARFRRF = value; }
        }

        /// public propaty name  :  HADD_EDPRODUCETYPEOFYEARFLSRF
        /// <summary>終了生産年式リテラル(/)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了生産年式リテラル(/)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_EDPRODUCETYPEOFYEARFLSRF
        {
            get { return _hADD_EDPRODUCETYPEOFYEARFLSRF; }
            set { _hADD_EDPRODUCETYPEOFYEARFLSRF = value; }
        }

        /// public propaty name  :  HADD_EDPRODUCETYPEOFYEARFLPRF
        /// <summary>終了生産年式リテラル(.)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了生産年式リテラル(.)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_EDPRODUCETYPEOFYEARFLPRF
        {
            get { return _hADD_EDPRODUCETYPEOFYEARFLPRF; }
            set { _hADD_EDPRODUCETYPEOFYEARFLPRF = value; }
        }

        /// public propaty name  :  HADD_EDPRODUCETYPEOFYEARFLYRF
        /// <summary>終了生産年式リテラル(年)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了生産年式リテラル(年)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_EDPRODUCETYPEOFYEARFLYRF
        {
            get { return _hADD_EDPRODUCETYPEOFYEARFLYRF; }
            set { _hADD_EDPRODUCETYPEOFYEARFLYRF = value; }
        }

        /// public propaty name  :  HADD_EDPRODUCETYPEOFYEARFLMRF
        /// <summary>終了生産年式リテラル(月)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了生産年式リテラル(月)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_EDPRODUCETYPEOFYEARFLMRF
        {
            get { return _hADD_EDPRODUCETYPEOFYEARFLMRF; }
            set { _hADD_EDPRODUCETYPEOFYEARFLMRF = value; }
        }


        /// <summary>
        /// 自由帳票見積書ヘッダデータコンストラクタ
        /// </summary>
        /// <returns>FrePEstFmHeadクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   FrePEstFmHeadクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public FrePEstFmHead()
        {
        }

        /// <summary>
        /// 自由帳票見積書ヘッダデータコンストラクタ
        /// </summary>
        /// <param name="sALESSLIPRF_SALESSLIPNUMRF">売上伝票番号(見積伝票番号,受注伝票番号,出荷伝票番号,売上伝票番号を兼ねる。)</param>
        /// <param name="sALESSLIPRF_SECTIONCODERF">拠点コード</param>
        /// <param name="sALESSLIPRF_SALESDATERF">売上日付(見積日、受注日、売上日を兼ねる。(YYYYMMDD))</param>
        /// <param name="sALESSLIPRF_ESTIMATEFORMNORF">見積書番号</param>
        /// <param name="sALESSLIPRF_ESTIMATEDIVIDERF">見積区分(1:通常見積　2:単価見積)</param>
        /// <param name="sALESSLIPRF_SALESINPUTCODERF">売上入力者コード(入力担当者（発行者）)</param>
        /// <param name="sALESSLIPRF_SALESINPUTNAMERF">売上入力者名称</param>
        /// <param name="sALESSLIPRF_FRONTEMPLOYEECDRF">受付従業員コード(受付担当者（受注者）)</param>
        /// <param name="sALESSLIPRF_FRONTEMPLOYEENMRF">受付従業員名称</param>
        /// <param name="sALESSLIPRF_SALESEMPLOYEECDRF">販売従業員コード(計上担当者（担当者）)</param>
        /// <param name="sALESSLIPRF_SALESEMPLOYEENMRF">販売従業員名称</param>
        /// <param name="sALESSLIPRF_CONSTAXLAYMETHODRF">消費税転嫁方式(0:伝票単位1:明細単位2:請求親 3:請求子 9:非課税)</param>
        /// <param name="sALESSLIPRF_CUSTOMERCODERF">得意先コード</param>
        /// <param name="sALESSLIPRF_CUSTOMERNAMERF">得意先名称</param>
        /// <param name="sALESSLIPRF_CUSTOMERNAME2RF">得意先名称2</param>
        /// <param name="sALESSLIPRF_CUSTOMERSNMRF">得意先略称</param>
        /// <param name="sALESSLIPRF_HONORIFICTITLERF">得意先敬称</param>
        /// <param name="sALESSLIPRF_SALESSLIPPRINTDATERF">売上伝票発行日</param>
        /// <param name="sALESSLIPRF_TOTALAMOUNTDISPWAYCDRF">総額表示方法区分(0:総額表示しない（税抜き）,1:総額表示する（税込み）)</param>
        /// <param name="sECINFOSETRF_SECTIONGUIDENMRF">拠点ガイド名称(ＵＩ用（既存のコンボボックス等）)</param>
        /// <param name="cOMPANYNMRF_COMPANYPRRF">拠点自社PR文</param>
        /// <param name="cOMPANYNMRF_COMPANYNAME1RF">拠点自社名称1</param>
        /// <param name="cOMPANYNMRF_COMPANYNAME2RF">拠点自社名称2</param>
        /// <param name="cOMPANYNMRF_POSTNORF">拠点郵便番号</param>
        /// <param name="cOMPANYNMRF_ADDRESS1RF">拠点住所1（都道府県市区郡・町村・字）</param>
        /// <param name="cOMPANYNMRF_ADDRESS3RF">拠点住所3（番地）</param>
        /// <param name="cOMPANYNMRF_ADDRESS4RF">拠点住所4（アパート名称）</param>
        /// <param name="cOMPANYNMRF_COMPANYTELNO1RF">拠点自社電話番号1(TEL)</param>
        /// <param name="cOMPANYNMRF_COMPANYTELNO2RF">拠点自社電話番号2(TEL2)</param>
        /// <param name="cOMPANYNMRF_COMPANYTELNO3RF">拠点自社電話番号3(FAX)</param>
        /// <param name="cOMPANYNMRF_COMPANYTELTITLE1RF">拠点自社電話番号タイトル1(TEL)</param>
        /// <param name="cOMPANYNMRF_COMPANYTELTITLE2RF">拠点自社電話番号タイトル2(TEL2)</param>
        /// <param name="cOMPANYNMRF_COMPANYTELTITLE3RF">拠点自社電話番号タイトル3(FAX)</param>
        /// <param name="cOMPANYNMRF_TRANSFERGUIDANCERF">拠点銀行振込案内文</param>
        /// <param name="cOMPANYNMRF_ACCOUNTNOINFO1RF">拠点銀行口座1</param>
        /// <param name="cOMPANYNMRF_ACCOUNTNOINFO2RF">拠点銀行口座2</param>
        /// <param name="cOMPANYNMRF_ACCOUNTNOINFO3RF">拠点銀行口座3</param>
        /// <param name="cOMPANYNMRF_COMPANYSETNOTE1RF">拠点自社設定摘要1</param>
        /// <param name="cOMPANYNMRF_COMPANYSETNOTE2RF">拠点自社設定摘要2</param>
        /// <param name="cOMPANYNMRF_COMPANYURLRF">拠点自社URL</param>
        /// <param name="cOMPANYNMRF_COMPANYPRSENTENCE2RF">拠点自社PR文2(代表取締役等の情報を入力)</param>
        /// <param name="cOMPANYNMRF_IMAGECOMMENTFORPRT1RF">拠点画像印字用コメント1(画像印字する場合、画像の下に印字する（拠点名等）)</param>
        /// <param name="cOMPANYNMRF_IMAGECOMMENTFORPRT2RF">拠点画像印字用コメント2(画像印字する場合、画像の下に印字する（拠点名等）)</param>
        /// <param name="iMAGEINFORF_IMAGEINFODATARF">拠点自社画像</param>
        /// <param name="cOMPANYINFRF_COMPANYNAME1RF">自社名称1</param>
        /// <param name="cOMPANYINFRF_COMPANYNAME2RF">自社名称2</param>
        /// <param name="cOMPANYINFRF_POSTNORF">郵便番号</param>
        /// <param name="cOMPANYINFRF_ADDRESS1RF">住所1（都道府県市区郡・町村・字）</param>
        /// <param name="cOMPANYINFRF_ADDRESS3RF">住所3（番地）</param>
        /// <param name="cOMPANYINFRF_ADDRESS4RF">住所4（アパート名称）</param>
        /// <param name="cOMPANYINFRF_COMPANYTELNO1RF">自社電話番号1(TEL)</param>
        /// <param name="cOMPANYINFRF_COMPANYTELNO2RF">自社電話番号2(TEL2)</param>
        /// <param name="cOMPANYINFRF_COMPANYTELNO3RF">自社電話番号3(FAX)</param>
        /// <param name="cOMPANYINFRF_COMPANYTELTITLE1RF">自社電話番号タイトル1(TEL)</param>
        /// <param name="cOMPANYINFRF_COMPANYTELTITLE2RF">自社電話番号タイトル2(TEL2)</param>
        /// <param name="cOMPANYINFRF_COMPANYTELTITLE3RF">自社電話番号タイトル3(FAX)</param>
        /// <param name="hEST_FOOTNOTES1RF">脚注１</param>
        /// <param name="hEST_FOOTNOTES2RF">脚注２</param>
        /// <param name="hEST_ESTIMATETITLE1RF">見積タイトル１</param>
        /// <param name="hEST_ESTIMATETITLE2RF">見積タイトル２</param>
        /// <param name="hEST_ESTIMATETITLE3RF">見積タイトル３</param>
        /// <param name="hEST_ESTIMATETITLE4RF">見積タイトル４</param>
        /// <param name="hEST_ESTIMATETITLE5RF">見積タイトル５</param>
        /// <param name="hEST_ESTIMATENOTE1RF">見積備考１</param>
        /// <param name="hEST_ESTIMATENOTE2RF">見積備考２</param>
        /// <param name="hEST_ESTIMATENOTE3RF">見積備考３</param>
        /// <param name="hEST_ESTIMATENOTE4RF">見積備考４</param>
        /// <param name="hEST_ESTIMATENOTE5RF">見積備考５</param>
        /// <param name="hEST_ESTIMATEVALIDITYLIMITRF">見積書有効期日(YYYYMMDD　発行日から見積書有効期限に設定された月数分あと)</param>
        /// <param name="hEST_ESTIMATEVALIDITYLIMITFYRF">見積書有効期日西暦年</param>
        /// <param name="hEST_ESTIMATEVALIDITYLIMITFSRF">見積書有効期日西暦年略</param>
        /// <param name="hEST_ESTIMATEVALIDITYLIMITFWRF">見積書有効期日和暦年</param>
        /// <param name="hEST_ESTIMATEVALIDITYLIMITFMRF">見積書有効期日月</param>
        /// <param name="hEST_ESTIMATEVALIDITYLIMITFDRF">見積書有効期日日</param>
        /// <param name="hEST_ESTIMATEVALIDITYLIMITFGRF">見積書有効期日元号</param>
        /// <param name="hEST_ESTIMATEVALIDITYLIMITFRRF">見積書有効期日略号</param>
        /// <param name="hEST_ESTIMATEVALIDITYLIMITFLSRF">見積書有効期日リテラル(/)</param>
        /// <param name="hEST_ESTIMATEVALIDITYLIMITFLPRF">見積書有効期日リテラル(.)</param>
        /// <param name="hEST_ESTIMATEVALIDITYLIMITFLYRF">見積書有効期日リテラル(年)</param>
        /// <param name="hEST_ESTIMATEVALIDITYLIMITFLMRF">見積書有効期日リテラル(月)</param>
        /// <param name="hEST_ESTIMATEVALIDITYLIMITFLDRF">見積書有効期日リテラル(日)</param>
        /// <param name="hADD_CARMNGNORF">車両管理番号(自動採番（無重複のシーケンス）PM7での車両SEQ)</param>
        /// <param name="hADD_CARMNGCODERF">車輌管理コード(※PM7での車両管理番号)</param>
        /// <param name="hADD_NUMBERPLATE1CODERF">陸運事務所番号</param>
        /// <param name="hADD_NUMBERPLATE1NAMERF">陸運事務局名称</param>
        /// <param name="hADD_NUMBERPLATE2RF">車両登録番号（種別）</param>
        /// <param name="hADD_NUMBERPLATE3RF">車両登録番号（カナ）</param>
        /// <param name="hADD_NUMBERPLATE4RF">車両登録番号（プレート番号）</param>
        /// <param name="hADD_FIRSTENTRYDATERF">初年度(YYYYMM)</param>
        /// <param name="hADD_MAKERCODERF">メーカーコード(1～899:提供分, 900～ユーザー登録)</param>
        /// <param name="hADD_MAKERFULLNAMERF">メーカー全角名称(正式名称（カナ漢字混在で全角管理）)</param>
        /// <param name="hADD_MAKERHALFNAMERF">メーカー半角名称</param>
        /// <param name="hADD_MODELCODERF">車種コード(車名コード(翼) 1～899:提供分, 900～ユーザー登録)</param>
        /// <param name="hADD_MODELSUBCODERF">車種サブコード(0～899:提供分,900～ﾕｰｻﾞｰ登録)</param>
        /// <param name="hADD_MODELFULLNAMERF">車種全角名称(正式名称（カナ漢字混在で全角管理）)</param>
        /// <param name="hADD_MODELHALFNAMERF">車種半角名称</param>
        /// <param name="hADD_EXHAUSTGASSIGNRF">排ガス記号</param>
        /// <param name="hADD_SERIESMODELRF">シリーズ型式</param>
        /// <param name="hADD_CATEGORYSIGNMODELRF">型式（類別記号）</param>
        /// <param name="hADD_FULLMODELRF">型式（フル型）(フル型式(44桁用))</param>
        /// <param name="hADD_MODELDESIGNATIONNORF">型式指定番号</param>
        /// <param name="hADD_CATEGORYNORF">類別番号</param>
        /// <param name="hADD_FRAMEMODELRF">車台型式</param>
        /// <param name="hADD_FRAMENORF">車台番号(車検証記載フォーマット対応（ HCR32-100251584 等）)</param>
        /// <param name="hADD_SEARCHFRAMENORF">車台番号（検索用）(PM7の車台番号と同意)</param>
        /// <param name="hADD_ENGINEMODELNMRF">エンジン型式名称(エンジン検索)</param>
        /// <param name="hADD_RELEVANCEMODELRF">関連型式(リサイクル系で使用)</param>
        /// <param name="hADD_SUBCARNMCDRF">サブ車名コード(リサイクル系で使用)</param>
        /// <param name="hADD_MODELGRADESNAMERF">型式グレード略称(リサイクル系で使用)</param>
        /// <param name="hADD_COLORCODERF">カラーコード(カタログの色コード)</param>
        /// <param name="hADD_COLORNAME1RF">カラー名称1(画面表示用正式名称)</param>
        /// <param name="hADD_TRIMCODERF">トリムコード</param>
        /// <param name="hADD_TRIMNAMERF">トリム名称</param>
        /// <param name="hADD_MILEAGERF">車両走行距離</param>
        /// <param name="hADD_PRINTERMNGNORF">プリンタ管理No(※このレコードの伝票を印刷するプリンタの決定結果(default))</param>
        /// <param name="hADD_SLIPPRTSETPAPERIDRF">伝票印刷設定用帳票ID(※このレコードの伝票を印刷する伝票タイプの決定結果(default))</param>
        /// <param name="hADD_NOTE1RF">自社備考１</param>
        /// <param name="hADD_NOTE2RF">自社備考２</param>
        /// <param name="hADD_NOTE3RF">自社備考３</param>
        /// <param name="hADD_FIRSTENTRYDATEFYRF">初年度西暦年</param>
        /// <param name="hADD_FIRSTENTRYDATEFSRF">初年度西暦年略</param>
        /// <param name="hADD_FIRSTENTRYDATEFWRF">初年度和暦年</param>
        /// <param name="hADD_FIRSTENTRYDATEFMRF">初年度月</param>
        /// <param name="hADD_FIRSTENTRYDATEFGRF">初年度元号</param>
        /// <param name="hADD_FIRSTENTRYDATEFRRF">初年度略号</param>
        /// <param name="hADD_FIRSTENTRYDATEFLSRF">初年度リテラル(/)</param>
        /// <param name="hADD_FIRSTENTRYDATEFLPRF">初年度リテラル(.)</param>
        /// <param name="hADD_FIRSTENTRYDATEFLYRF">初年度リテラル(年)</param>
        /// <param name="hADD_FIRSTENTRYDATEFLMRF">初年度リテラル(月)</param>
        /// <param name="hADD_PRINTCUSTOMERNM1RF">印刷用得意先名称(上段)(印刷プログラムで制御する得意先名称項目)</param>
        /// <param name="hADD_PRINTCUSTOMERNM2RF">印刷用得意先名称(下段)(印刷プログラムで制御する得意先名称項目)</param>
        /// <param name="hPURE_SALESTOTALTAXINCRF">純正売上伝票合計（税込み）(売上正価金額＋売上値引金額計（税抜き）＋売上金額消費税額)</param>
        /// <param name="hPURE_SALESTOTALTAXEXCRF">純正売上伝票合計（税抜き）(売上正価金額＋売上値引金額計（税抜き）)</param>
        /// <param name="hPURE_SALESSUBTOTALTAXINCRF">純正売上小計（税込み）(値引後の明細金額の合計（非課税含まず）)</param>
        /// <param name="hPURE_SALESSUBTOTALTAXEXCRF">純正売上小計（税抜き）(値引後の明細金額の合計（非課税含まず）)</param>
        /// <param name="hPURE_SALESSUBTOTALTAXRF">純正売上小計（税）(外税対象金額の集計（税抜、値引含まず）)</param>
        /// <param name="hPRIME_SALESTOTALTAXINCRF">優良売上伝票合計（税込み）(売上正価金額＋売上値引金額計（税抜き）＋売上金額消費税額)</param>
        /// <param name="hPRIME_SALESTOTALTAXEXCRF">優良売上伝票合計（税抜き）(売上正価金額＋売上値引金額計（税抜き）)</param>
        /// <param name="hPRIME_SALESSUBTOTALTAXINCRF">優良売上小計（税込み）(値引後の明細金額の合計（非課税含まず）)</param>
        /// <param name="hPRIME_SALESSUBTOTALTAXEXCRF">優良売上小計（税抜き）(値引後の明細金額の合計（非課税含まず）)</param>
        /// <param name="hPRIME_SALESSUBTOTALTAXRF">優良売上小計（税）(外税対象金額の集計（税抜、値引含まず）)</param>
        /// <param name="hADD_PRINTTIMEHOURRF">印刷時刻 時(HH)</param>
        /// <param name="hADD_PRINTTIMEMINUTERF">印刷時刻 分(MM)</param>
        /// <param name="hADD_PRINTTIMESECONDRF">印刷時刻 秒(DD)</param>
        /// <param name="hADD_ESTFMDIVRF">見積書印刷制御区分(0:全て,1:純正のみ,2:優良のみ,3:選択分のみ)</param>
        /// <param name="hADD_SALESDATEFYRF">売上日付西暦年</param>
        /// <param name="hADD_SALESDATEFSRF">売上日付西暦年略</param>
        /// <param name="hADD_SALESDATEFWRF">売上日付和暦年</param>
        /// <param name="hADD_SALESDATEFMRF">売上日付月</param>
        /// <param name="hADD_SALESDATEFDRF">売上日付日</param>
        /// <param name="hADD_SALESDATEFGRF">売上日付元号</param>
        /// <param name="hADD_SALESDATEFRRF">売上日付略号</param>
        /// <param name="hADD_SALESDATEFLSRF">売上日付リテラル(/)</param>
        /// <param name="hADD_SALESDATEFLPRF">売上日付リテラル(.)</param>
        /// <param name="hADD_SALESDATEFLYRF">売上日付リテラル(年)</param>
        /// <param name="hADD_SALESDATEFLMRF">売上日付リテラル(月)</param>
        /// <param name="hADD_SALESDATEFLDRF">売上日付リテラル(日)</param>
        /// <param name="hADD_SALESSLIPPRINTDATEFYRF">売上伝票発行日西暦年</param>
        /// <param name="hADD_SALESSLIPPRINTDATEFSRF">売上伝票発行日西暦年略</param>
        /// <param name="hADD_SALESSLIPPRINTDATEFWRF">売上伝票発行日和暦年</param>
        /// <param name="hADD_SALESSLIPPRINTDATEFMRF">売上伝票発行日月</param>
        /// <param name="hADD_SALESSLIPPRINTDATEFDRF">売上伝票発行日日</param>
        /// <param name="hADD_SALESSLIPPRINTDATEFGRF">売上伝票発行日元号</param>
        /// <param name="hADD_SALESSLIPPRINTDATEFRRF">売上伝票発行日略号</param>
        /// <param name="hADD_SALESSLIPPRINTDATEFLSRF">売上伝票発行日リテラル(/)</param>
        /// <param name="hADD_SALESSLIPPRINTDATEFLPRF">売上伝票発行日リテラル(.)</param>
        /// <param name="hADD_SALESSLIPPRINTDATEFLYRF">売上伝票発行日リテラル(年)</param>
        /// <param name="hADD_SALESSLIPPRINTDATEFLMRF">売上伝票発行日リテラル(月)</param>
        /// <param name="hADD_SALESSLIPPRINTDATEFLDRF">売上伝票発行日リテラル(日)</param>
        /// <param name="hADD_SYSTEMATICCODERF">系統コード</param>
        /// <param name="hADD_SYSTEMATICNAMERF">系統名称(140系,180系等)</param>
        /// <param name="hADD_STPRODUCETYPEOFYEARRF">開始生産年式(YYYYMM)</param>
        /// <param name="hADD_EDPRODUCETYPEOFYEARRF">終了生産年式(YYYYMM)</param>
        /// <param name="hADD_DOORCOUNTRF">ドア数</param>
        /// <param name="hADD_BODYNAMECODERF">ボディー名コード</param>
        /// <param name="hADD_BODYNAMERF">ボディー名称</param>
        /// <param name="hADD_STPRODUCEFRAMENORF">生産車台番号開始</param>
        /// <param name="hADD_EDPRODUCEFRAMENORF">生産車台番号終了</param>
        /// <param name="hADD_ENGINEMODELRF">原動機型式（エンジン）(車検証記載原動機型式)</param>
        /// <param name="hADD_MODELGRADENMRF">型式グレード名称</param>
        /// <param name="hADD_ENGINEDISPLACENMRF">排気量名称(型式により変動)</param>
        /// <param name="hADD_EDIVNMRF">E区分名称(型式により変動)</param>
        /// <param name="hADD_TRANSMISSIONNMRF">ミッション名称</param>
        /// <param name="hADD_SHIFTNMRF">シフト名称</param>
        /// <param name="hADD_WHEELDRIVEMETHODNMRF">駆動方式名称(新規追加)</param>
        /// <param name="hADD_ADDICARSPEC1RF">追加諸元1(型式により変動)</param>
        /// <param name="hADD_ADDICARSPEC2RF">追加諸元2(型式により変動)</param>
        /// <param name="hADD_ADDICARSPEC3RF">追加諸元3(型式により変動)</param>
        /// <param name="hADD_ADDICARSPEC4RF">追加諸元4(型式により変動)</param>
        /// <param name="hADD_ADDICARSPEC5RF">追加諸元5(型式により変動)</param>
        /// <param name="hADD_ADDICARSPEC6RF">追加諸元6(型式により変動)</param>
        /// <param name="hADD_ADDICARSPECTITLE1RF">追加諸元タイトル1(型式により変動)</param>
        /// <param name="hADD_ADDICARSPECTITLE2RF">追加諸元タイトル2(型式により変動)</param>
        /// <param name="hADD_ADDICARSPECTITLE3RF">追加諸元タイトル3(型式により変動)</param>
        /// <param name="hADD_ADDICARSPECTITLE4RF">追加諸元タイトル4(型式により変動)</param>
        /// <param name="hADD_ADDICARSPECTITLE5RF">追加諸元タイトル5(型式により変動)</param>
        /// <param name="hADD_ADDICARSPECTITLE6RF">追加諸元タイトル6(型式により変動)</param>
        /// <param name="hADD_STPRODUCETYPEOFYEARFYRF">開始生産年式西暦年</param>
        /// <param name="hADD_STPRODUCETYPEOFYEARFSRF">開始生産年式西暦年略</param>
        /// <param name="hADD_STPRODUCETYPEOFYEARFWRF">開始生産年式和暦年</param>
        /// <param name="hADD_STPRODUCETYPEOFYEARFMRF">開始生産年式月</param>
        /// <param name="hADD_STPRODUCETYPEOFYEARFGRF">開始生産年式元号</param>
        /// <param name="hADD_STPRODUCETYPEOFYEARFRRF">開始生産年式略号</param>
        /// <param name="hADD_STPRODUCETYPEOFYEARFLSRF">開始生産年式リテラル(/)</param>
        /// <param name="hADD_STPRODUCETYPEOFYEARFLPRF">開始生産年式リテラル(.)</param>
        /// <param name="hADD_STPRODUCETYPEOFYEARFLYRF">開始生産年式リテラル(年)</param>
        /// <param name="hADD_STPRODUCETYPEOFYEARFLMRF">開始生産年式リテラル(月)</param>
        /// <param name="hADD_EDPRODUCETYPEOFYEARFYRF">終了生産年式西暦年</param>
        /// <param name="hADD_EDPRODUCETYPEOFYEARFSRF">終了生産年式西暦年略</param>
        /// <param name="hADD_EDPRODUCETYPEOFYEARFWRF">終了生産年式和暦年</param>
        /// <param name="hADD_EDPRODUCETYPEOFYEARFMRF">終了生産年式月</param>
        /// <param name="hADD_EDPRODUCETYPEOFYEARFGRF">終了生産年式元号</param>
        /// <param name="hADD_EDPRODUCETYPEOFYEARFRRF">終了生産年式略号</param>
        /// <param name="hADD_EDPRODUCETYPEOFYEARFLSRF">終了生産年式リテラル(/)</param>
        /// <param name="hADD_EDPRODUCETYPEOFYEARFLPRF">終了生産年式リテラル(.)</param>
        /// <param name="hADD_EDPRODUCETYPEOFYEARFLYRF">終了生産年式リテラル(年)</param>
        /// <param name="hADD_EDPRODUCETYPEOFYEARFLMRF">終了生産年式リテラル(月)</param>
        /// <returns>FrePEstFmHeadクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   FrePEstFmHeadクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public FrePEstFmHead( string sALESSLIPRF_SALESSLIPNUMRF, string sALESSLIPRF_SECTIONCODERF, DateTime sALESSLIPRF_SALESDATERF, string sALESSLIPRF_ESTIMATEFORMNORF, Int32 sALESSLIPRF_ESTIMATEDIVIDERF, string sALESSLIPRF_SALESINPUTCODERF, string sALESSLIPRF_SALESINPUTNAMERF, string sALESSLIPRF_FRONTEMPLOYEECDRF, string sALESSLIPRF_FRONTEMPLOYEENMRF, string sALESSLIPRF_SALESEMPLOYEECDRF, string sALESSLIPRF_SALESEMPLOYEENMRF, Int32 sALESSLIPRF_CONSTAXLAYMETHODRF, Int32 sALESSLIPRF_CUSTOMERCODERF, string sALESSLIPRF_CUSTOMERNAMERF, string sALESSLIPRF_CUSTOMERNAME2RF, string sALESSLIPRF_CUSTOMERSNMRF, string sALESSLIPRF_HONORIFICTITLERF, DateTime sALESSLIPRF_SALESSLIPPRINTDATERF, Int32 sALESSLIPRF_TOTALAMOUNTDISPWAYCDRF, string sECINFOSETRF_SECTIONGUIDENMRF, string cOMPANYNMRF_COMPANYPRRF, string cOMPANYNMRF_COMPANYNAME1RF, string cOMPANYNMRF_COMPANYNAME2RF, string cOMPANYNMRF_POSTNORF, string cOMPANYNMRF_ADDRESS1RF, string cOMPANYNMRF_ADDRESS3RF, string cOMPANYNMRF_ADDRESS4RF, string cOMPANYNMRF_COMPANYTELNO1RF, string cOMPANYNMRF_COMPANYTELNO2RF, string cOMPANYNMRF_COMPANYTELNO3RF, string cOMPANYNMRF_COMPANYTELTITLE1RF, string cOMPANYNMRF_COMPANYTELTITLE2RF, string cOMPANYNMRF_COMPANYTELTITLE3RF, string cOMPANYNMRF_TRANSFERGUIDANCERF, string cOMPANYNMRF_ACCOUNTNOINFO1RF, string cOMPANYNMRF_ACCOUNTNOINFO2RF, string cOMPANYNMRF_ACCOUNTNOINFO3RF, string cOMPANYNMRF_COMPANYSETNOTE1RF, string cOMPANYNMRF_COMPANYSETNOTE2RF, string cOMPANYNMRF_COMPANYURLRF, string cOMPANYNMRF_COMPANYPRSENTENCE2RF, string cOMPANYNMRF_IMAGECOMMENTFORPRT1RF, string cOMPANYNMRF_IMAGECOMMENTFORPRT2RF, Byte[] iMAGEINFORF_IMAGEINFODATARF, string cOMPANYINFRF_COMPANYNAME1RF, string cOMPANYINFRF_COMPANYNAME2RF, string cOMPANYINFRF_POSTNORF, string cOMPANYINFRF_ADDRESS1RF, string cOMPANYINFRF_ADDRESS3RF, string cOMPANYINFRF_ADDRESS4RF, string cOMPANYINFRF_COMPANYTELNO1RF, string cOMPANYINFRF_COMPANYTELNO2RF, string cOMPANYINFRF_COMPANYTELNO3RF, string cOMPANYINFRF_COMPANYTELTITLE1RF, string cOMPANYINFRF_COMPANYTELTITLE2RF, string cOMPANYINFRF_COMPANYTELTITLE3RF, string hEST_FOOTNOTES1RF, string hEST_FOOTNOTES2RF, string hEST_ESTIMATETITLE1RF, string hEST_ESTIMATETITLE2RF, string hEST_ESTIMATETITLE3RF, string hEST_ESTIMATETITLE4RF, string hEST_ESTIMATETITLE5RF, string hEST_ESTIMATENOTE1RF, string hEST_ESTIMATENOTE2RF, string hEST_ESTIMATENOTE3RF, string hEST_ESTIMATENOTE4RF, string hEST_ESTIMATENOTE5RF, DateTime hEST_ESTIMATEVALIDITYLIMITRF, Int32 hEST_ESTIMATEVALIDITYLIMITFYRF, Int32 hEST_ESTIMATEVALIDITYLIMITFSRF, Int32 hEST_ESTIMATEVALIDITYLIMITFWRF, Int32 hEST_ESTIMATEVALIDITYLIMITFMRF, Int32 hEST_ESTIMATEVALIDITYLIMITFDRF, string hEST_ESTIMATEVALIDITYLIMITFGRF, string hEST_ESTIMATEVALIDITYLIMITFRRF, string hEST_ESTIMATEVALIDITYLIMITFLSRF, string hEST_ESTIMATEVALIDITYLIMITFLPRF, string hEST_ESTIMATEVALIDITYLIMITFLYRF, string hEST_ESTIMATEVALIDITYLIMITFLMRF, string hEST_ESTIMATEVALIDITYLIMITFLDRF, Int32 hADD_CARMNGNORF, string hADD_CARMNGCODERF, Int32 hADD_NUMBERPLATE1CODERF, string hADD_NUMBERPLATE1NAMERF, string hADD_NUMBERPLATE2RF, string hADD_NUMBERPLATE3RF, Int32 hADD_NUMBERPLATE4RF, int hADD_FIRSTENTRYDATERF, Int32 hADD_MAKERCODERF, string hADD_MAKERFULLNAMERF, string hADD_MAKERHALFNAMERF, Int32 hADD_MODELCODERF, Int32 hADD_MODELSUBCODERF, string hADD_MODELFULLNAMERF, string hADD_MODELHALFNAMERF, string hADD_EXHAUSTGASSIGNRF, string hADD_SERIESMODELRF, string hADD_CATEGORYSIGNMODELRF, string hADD_FULLMODELRF, Int32 hADD_MODELDESIGNATIONNORF, Int32 hADD_CATEGORYNORF, string hADD_FRAMEMODELRF, string hADD_FRAMENORF, Int32 hADD_SEARCHFRAMENORF, string hADD_ENGINEMODELNMRF, string hADD_RELEVANCEMODELRF, Int32 hADD_SUBCARNMCDRF, string hADD_MODELGRADESNAMERF, string hADD_COLORCODERF, string hADD_COLORNAME1RF, string hADD_TRIMCODERF, string hADD_TRIMNAMERF, Int32 hADD_MILEAGERF, Int32 hADD_PRINTERMNGNORF, string hADD_SLIPPRTSETPAPERIDRF, string hADD_NOTE1RF, string hADD_NOTE2RF, string hADD_NOTE3RF, Int32 hADD_FIRSTENTRYDATEFYRF, Int32 hADD_FIRSTENTRYDATEFSRF, Int32 hADD_FIRSTENTRYDATEFWRF, Int32 hADD_FIRSTENTRYDATEFMRF, string hADD_FIRSTENTRYDATEFGRF, string hADD_FIRSTENTRYDATEFRRF, string hADD_FIRSTENTRYDATEFLSRF, string hADD_FIRSTENTRYDATEFLPRF, string hADD_FIRSTENTRYDATEFLYRF, string hADD_FIRSTENTRYDATEFLMRF, string hADD_PRINTCUSTOMERNM1RF, string hADD_PRINTCUSTOMERNM2RF, Int64 hPURE_SALESTOTALTAXINCRF, Int64 hPURE_SALESTOTALTAXEXCRF, Int64 hPURE_SALESSUBTOTALTAXINCRF, Int64 hPURE_SALESSUBTOTALTAXEXCRF, Int64 hPURE_SALESSUBTOTALTAXRF, Int64 hPRIME_SALESTOTALTAXINCRF, Int64 hPRIME_SALESTOTALTAXEXCRF, Int64 hPRIME_SALESSUBTOTALTAXINCRF, Int64 hPRIME_SALESSUBTOTALTAXEXCRF, Int64 hPRIME_SALESSUBTOTALTAXRF, Int32 hADD_PRINTTIMEHOURRF, Int32 hADD_PRINTTIMEMINUTERF, Int32 hADD_PRINTTIMESECONDRF, EstFmDivState hADD_ESTFMDIVRF, Int32 hADD_SALESDATEFYRF, Int32 hADD_SALESDATEFSRF, Int32 hADD_SALESDATEFWRF, Int32 hADD_SALESDATEFMRF, Int32 hADD_SALESDATEFDRF, string hADD_SALESDATEFGRF, string hADD_SALESDATEFRRF, string hADD_SALESDATEFLSRF, string hADD_SALESDATEFLPRF, string hADD_SALESDATEFLYRF, string hADD_SALESDATEFLMRF, string hADD_SALESDATEFLDRF, Int32 hADD_SALESSLIPPRINTDATEFYRF, Int32 hADD_SALESSLIPPRINTDATEFSRF, Int32 hADD_SALESSLIPPRINTDATEFWRF, Int32 hADD_SALESSLIPPRINTDATEFMRF, Int32 hADD_SALESSLIPPRINTDATEFDRF, string hADD_SALESSLIPPRINTDATEFGRF, string hADD_SALESSLIPPRINTDATEFRRF, string hADD_SALESSLIPPRINTDATEFLSRF, string hADD_SALESSLIPPRINTDATEFLPRF, string hADD_SALESSLIPPRINTDATEFLYRF, string hADD_SALESSLIPPRINTDATEFLMRF, string hADD_SALESSLIPPRINTDATEFLDRF, Int32 hADD_SYSTEMATICCODERF, string hADD_SYSTEMATICNAMERF, DateTime hADD_STPRODUCETYPEOFYEARRF, DateTime hADD_EDPRODUCETYPEOFYEARRF, Int32 hADD_DOORCOUNTRF, Int32 hADD_BODYNAMECODERF, string hADD_BODYNAMERF, Int32 hADD_STPRODUCEFRAMENORF, Int32 hADD_EDPRODUCEFRAMENORF, string hADD_ENGINEMODELRF, string hADD_MODELGRADENMRF, string hADD_ENGINEDISPLACENMRF, string hADD_EDIVNMRF, string hADD_TRANSMISSIONNMRF, string hADD_SHIFTNMRF, string hADD_WHEELDRIVEMETHODNMRF, string hADD_ADDICARSPEC1RF, string hADD_ADDICARSPEC2RF, string hADD_ADDICARSPEC3RF, string hADD_ADDICARSPEC4RF, string hADD_ADDICARSPEC5RF, string hADD_ADDICARSPEC6RF, string hADD_ADDICARSPECTITLE1RF, string hADD_ADDICARSPECTITLE2RF, string hADD_ADDICARSPECTITLE3RF, string hADD_ADDICARSPECTITLE4RF, string hADD_ADDICARSPECTITLE5RF, string hADD_ADDICARSPECTITLE6RF, Int32 hADD_STPRODUCETYPEOFYEARFYRF, Int32 hADD_STPRODUCETYPEOFYEARFSRF, Int32 hADD_STPRODUCETYPEOFYEARFWRF, Int32 hADD_STPRODUCETYPEOFYEARFMRF, string hADD_STPRODUCETYPEOFYEARFGRF, string hADD_STPRODUCETYPEOFYEARFRRF, string hADD_STPRODUCETYPEOFYEARFLSRF, string hADD_STPRODUCETYPEOFYEARFLPRF, string hADD_STPRODUCETYPEOFYEARFLYRF, string hADD_STPRODUCETYPEOFYEARFLMRF, Int32 hADD_EDPRODUCETYPEOFYEARFYRF, Int32 hADD_EDPRODUCETYPEOFYEARFSRF, Int32 hADD_EDPRODUCETYPEOFYEARFWRF, Int32 hADD_EDPRODUCETYPEOFYEARFMRF, string hADD_EDPRODUCETYPEOFYEARFGRF, string hADD_EDPRODUCETYPEOFYEARFRRF, string hADD_EDPRODUCETYPEOFYEARFLSRF, string hADD_EDPRODUCETYPEOFYEARFLPRF, string hADD_EDPRODUCETYPEOFYEARFLYRF, string hADD_EDPRODUCETYPEOFYEARFLMRF )
        {
            this._sALESSLIPRF_SALESSLIPNUMRF = sALESSLIPRF_SALESSLIPNUMRF;
            this._sALESSLIPRF_SECTIONCODERF = sALESSLIPRF_SECTIONCODERF;
            this._sALESSLIPRF_SALESDATERF = sALESSLIPRF_SALESDATERF;
            this._sALESSLIPRF_ESTIMATEFORMNORF = sALESSLIPRF_ESTIMATEFORMNORF;
            this._sALESSLIPRF_ESTIMATEDIVIDERF = sALESSLIPRF_ESTIMATEDIVIDERF;
            this._sALESSLIPRF_SALESINPUTCODERF = sALESSLIPRF_SALESINPUTCODERF;
            this._sALESSLIPRF_SALESINPUTNAMERF = sALESSLIPRF_SALESINPUTNAMERF;
            this._sALESSLIPRF_FRONTEMPLOYEECDRF = sALESSLIPRF_FRONTEMPLOYEECDRF;
            this._sALESSLIPRF_FRONTEMPLOYEENMRF = sALESSLIPRF_FRONTEMPLOYEENMRF;
            this._sALESSLIPRF_SALESEMPLOYEECDRF = sALESSLIPRF_SALESEMPLOYEECDRF;
            this._sALESSLIPRF_SALESEMPLOYEENMRF = sALESSLIPRF_SALESEMPLOYEENMRF;
            this._sALESSLIPRF_CONSTAXLAYMETHODRF = sALESSLIPRF_CONSTAXLAYMETHODRF;
            this._sALESSLIPRF_CUSTOMERCODERF = sALESSLIPRF_CUSTOMERCODERF;
            this._sALESSLIPRF_CUSTOMERNAMERF = sALESSLIPRF_CUSTOMERNAMERF;
            this._sALESSLIPRF_CUSTOMERNAME2RF = sALESSLIPRF_CUSTOMERNAME2RF;
            this._sALESSLIPRF_CUSTOMERSNMRF = sALESSLIPRF_CUSTOMERSNMRF;
            this._sALESSLIPRF_HONORIFICTITLERF = sALESSLIPRF_HONORIFICTITLERF;
            this._sALESSLIPRF_SALESSLIPPRINTDATERF = sALESSLIPRF_SALESSLIPPRINTDATERF;
            this._sALESSLIPRF_TOTALAMOUNTDISPWAYCDRF = sALESSLIPRF_TOTALAMOUNTDISPWAYCDRF;
            this._sECINFOSETRF_SECTIONGUIDENMRF = sECINFOSETRF_SECTIONGUIDENMRF;
            this._cOMPANYNMRF_COMPANYPRRF = cOMPANYNMRF_COMPANYPRRF;
            this._cOMPANYNMRF_COMPANYNAME1RF = cOMPANYNMRF_COMPANYNAME1RF;
            this._cOMPANYNMRF_COMPANYNAME2RF = cOMPANYNMRF_COMPANYNAME2RF;
            this._cOMPANYNMRF_POSTNORF = cOMPANYNMRF_POSTNORF;
            this._cOMPANYNMRF_ADDRESS1RF = cOMPANYNMRF_ADDRESS1RF;
            this._cOMPANYNMRF_ADDRESS3RF = cOMPANYNMRF_ADDRESS3RF;
            this._cOMPANYNMRF_ADDRESS4RF = cOMPANYNMRF_ADDRESS4RF;
            this._cOMPANYNMRF_COMPANYTELNO1RF = cOMPANYNMRF_COMPANYTELNO1RF;
            this._cOMPANYNMRF_COMPANYTELNO2RF = cOMPANYNMRF_COMPANYTELNO2RF;
            this._cOMPANYNMRF_COMPANYTELNO3RF = cOMPANYNMRF_COMPANYTELNO3RF;
            this._cOMPANYNMRF_COMPANYTELTITLE1RF = cOMPANYNMRF_COMPANYTELTITLE1RF;
            this._cOMPANYNMRF_COMPANYTELTITLE2RF = cOMPANYNMRF_COMPANYTELTITLE2RF;
            this._cOMPANYNMRF_COMPANYTELTITLE3RF = cOMPANYNMRF_COMPANYTELTITLE3RF;
            this._cOMPANYNMRF_TRANSFERGUIDANCERF = cOMPANYNMRF_TRANSFERGUIDANCERF;
            this._cOMPANYNMRF_ACCOUNTNOINFO1RF = cOMPANYNMRF_ACCOUNTNOINFO1RF;
            this._cOMPANYNMRF_ACCOUNTNOINFO2RF = cOMPANYNMRF_ACCOUNTNOINFO2RF;
            this._cOMPANYNMRF_ACCOUNTNOINFO3RF = cOMPANYNMRF_ACCOUNTNOINFO3RF;
            this._cOMPANYNMRF_COMPANYSETNOTE1RF = cOMPANYNMRF_COMPANYSETNOTE1RF;
            this._cOMPANYNMRF_COMPANYSETNOTE2RF = cOMPANYNMRF_COMPANYSETNOTE2RF;
            this._cOMPANYNMRF_COMPANYURLRF = cOMPANYNMRF_COMPANYURLRF;
            this._cOMPANYNMRF_COMPANYPRSENTENCE2RF = cOMPANYNMRF_COMPANYPRSENTENCE2RF;
            this._cOMPANYNMRF_IMAGECOMMENTFORPRT1RF = cOMPANYNMRF_IMAGECOMMENTFORPRT1RF;
            this._cOMPANYNMRF_IMAGECOMMENTFORPRT2RF = cOMPANYNMRF_IMAGECOMMENTFORPRT2RF;
            this._iMAGEINFORF_IMAGEINFODATARF = iMAGEINFORF_IMAGEINFODATARF;
            this._cOMPANYINFRF_COMPANYNAME1RF = cOMPANYINFRF_COMPANYNAME1RF;
            this._cOMPANYINFRF_COMPANYNAME2RF = cOMPANYINFRF_COMPANYNAME2RF;
            this._cOMPANYINFRF_POSTNORF = cOMPANYINFRF_POSTNORF;
            this._cOMPANYINFRF_ADDRESS1RF = cOMPANYINFRF_ADDRESS1RF;
            this._cOMPANYINFRF_ADDRESS3RF = cOMPANYINFRF_ADDRESS3RF;
            this._cOMPANYINFRF_ADDRESS4RF = cOMPANYINFRF_ADDRESS4RF;
            this._cOMPANYINFRF_COMPANYTELNO1RF = cOMPANYINFRF_COMPANYTELNO1RF;
            this._cOMPANYINFRF_COMPANYTELNO2RF = cOMPANYINFRF_COMPANYTELNO2RF;
            this._cOMPANYINFRF_COMPANYTELNO3RF = cOMPANYINFRF_COMPANYTELNO3RF;
            this._cOMPANYINFRF_COMPANYTELTITLE1RF = cOMPANYINFRF_COMPANYTELTITLE1RF;
            this._cOMPANYINFRF_COMPANYTELTITLE2RF = cOMPANYINFRF_COMPANYTELTITLE2RF;
            this._cOMPANYINFRF_COMPANYTELTITLE3RF = cOMPANYINFRF_COMPANYTELTITLE3RF;
            this._hEST_FOOTNOTES1RF = hEST_FOOTNOTES1RF;
            this._hEST_FOOTNOTES2RF = hEST_FOOTNOTES2RF;
            this._hEST_ESTIMATETITLE1RF = hEST_ESTIMATETITLE1RF;
            this._hEST_ESTIMATETITLE2RF = hEST_ESTIMATETITLE2RF;
            this._hEST_ESTIMATETITLE3RF = hEST_ESTIMATETITLE3RF;
            this._hEST_ESTIMATETITLE4RF = hEST_ESTIMATETITLE4RF;
            this._hEST_ESTIMATETITLE5RF = hEST_ESTIMATETITLE5RF;
            this._hEST_ESTIMATENOTE1RF = hEST_ESTIMATENOTE1RF;
            this._hEST_ESTIMATENOTE2RF = hEST_ESTIMATENOTE2RF;
            this._hEST_ESTIMATENOTE3RF = hEST_ESTIMATENOTE3RF;
            this._hEST_ESTIMATENOTE4RF = hEST_ESTIMATENOTE4RF;
            this._hEST_ESTIMATENOTE5RF = hEST_ESTIMATENOTE5RF;
            this._hEST_ESTIMATEVALIDITYLIMITRF = hEST_ESTIMATEVALIDITYLIMITRF;
            this._hEST_ESTIMATEVALIDITYLIMITFYRF = hEST_ESTIMATEVALIDITYLIMITFYRF;
            this._hEST_ESTIMATEVALIDITYLIMITFSRF = hEST_ESTIMATEVALIDITYLIMITFSRF;
            this._hEST_ESTIMATEVALIDITYLIMITFWRF = hEST_ESTIMATEVALIDITYLIMITFWRF;
            this._hEST_ESTIMATEVALIDITYLIMITFMRF = hEST_ESTIMATEVALIDITYLIMITFMRF;
            this._hEST_ESTIMATEVALIDITYLIMITFDRF = hEST_ESTIMATEVALIDITYLIMITFDRF;
            this._hEST_ESTIMATEVALIDITYLIMITFGRF = hEST_ESTIMATEVALIDITYLIMITFGRF;
            this._hEST_ESTIMATEVALIDITYLIMITFRRF = hEST_ESTIMATEVALIDITYLIMITFRRF;
            this._hEST_ESTIMATEVALIDITYLIMITFLSRF = hEST_ESTIMATEVALIDITYLIMITFLSRF;
            this._hEST_ESTIMATEVALIDITYLIMITFLPRF = hEST_ESTIMATEVALIDITYLIMITFLPRF;
            this._hEST_ESTIMATEVALIDITYLIMITFLYRF = hEST_ESTIMATEVALIDITYLIMITFLYRF;
            this._hEST_ESTIMATEVALIDITYLIMITFLMRF = hEST_ESTIMATEVALIDITYLIMITFLMRF;
            this._hEST_ESTIMATEVALIDITYLIMITFLDRF = hEST_ESTIMATEVALIDITYLIMITFLDRF;
            this._hADD_CARMNGNORF = hADD_CARMNGNORF;
            this._hADD_CARMNGCODERF = hADD_CARMNGCODERF;
            this._hADD_NUMBERPLATE1CODERF = hADD_NUMBERPLATE1CODERF;
            this._hADD_NUMBERPLATE1NAMERF = hADD_NUMBERPLATE1NAMERF;
            this._hADD_NUMBERPLATE2RF = hADD_NUMBERPLATE2RF;
            this._hADD_NUMBERPLATE3RF = hADD_NUMBERPLATE3RF;
            this._hADD_NUMBERPLATE4RF = hADD_NUMBERPLATE4RF;
            this._hADD_FIRSTENTRYDATERF = hADD_FIRSTENTRYDATERF;
            this._hADD_MAKERCODERF = hADD_MAKERCODERF;
            this._hADD_MAKERFULLNAMERF = hADD_MAKERFULLNAMERF;
            this._hADD_MAKERHALFNAMERF = hADD_MAKERHALFNAMERF;
            this._hADD_MODELCODERF = hADD_MODELCODERF;
            this._hADD_MODELSUBCODERF = hADD_MODELSUBCODERF;
            this._hADD_MODELFULLNAMERF = hADD_MODELFULLNAMERF;
            this._hADD_MODELHALFNAMERF = hADD_MODELHALFNAMERF;
            this._hADD_EXHAUSTGASSIGNRF = hADD_EXHAUSTGASSIGNRF;
            this._hADD_SERIESMODELRF = hADD_SERIESMODELRF;
            this._hADD_CATEGORYSIGNMODELRF = hADD_CATEGORYSIGNMODELRF;
            this._hADD_FULLMODELRF = hADD_FULLMODELRF;
            this._hADD_MODELDESIGNATIONNORF = hADD_MODELDESIGNATIONNORF;
            this._hADD_CATEGORYNORF = hADD_CATEGORYNORF;
            this._hADD_FRAMEMODELRF = hADD_FRAMEMODELRF;
            this._hADD_FRAMENORF = hADD_FRAMENORF;
            this._hADD_SEARCHFRAMENORF = hADD_SEARCHFRAMENORF;
            this._hADD_ENGINEMODELNMRF = hADD_ENGINEMODELNMRF;
            this._hADD_RELEVANCEMODELRF = hADD_RELEVANCEMODELRF;
            this._hADD_SUBCARNMCDRF = hADD_SUBCARNMCDRF;
            this._hADD_MODELGRADESNAMERF = hADD_MODELGRADESNAMERF;
            this._hADD_COLORCODERF = hADD_COLORCODERF;
            this._hADD_COLORNAME1RF = hADD_COLORNAME1RF;
            this._hADD_TRIMCODERF = hADD_TRIMCODERF;
            this._hADD_TRIMNAMERF = hADD_TRIMNAMERF;
            this._hADD_MILEAGERF = hADD_MILEAGERF;
            this._hADD_PRINTERMNGNORF = hADD_PRINTERMNGNORF;
            this._hADD_SLIPPRTSETPAPERIDRF = hADD_SLIPPRTSETPAPERIDRF;
            this._hADD_NOTE1RF = hADD_NOTE1RF;
            this._hADD_NOTE2RF = hADD_NOTE2RF;
            this._hADD_NOTE3RF = hADD_NOTE3RF;
            this._hADD_FIRSTENTRYDATEFYRF = hADD_FIRSTENTRYDATEFYRF;
            this._hADD_FIRSTENTRYDATEFSRF = hADD_FIRSTENTRYDATEFSRF;
            this._hADD_FIRSTENTRYDATEFWRF = hADD_FIRSTENTRYDATEFWRF;
            this._hADD_FIRSTENTRYDATEFMRF = hADD_FIRSTENTRYDATEFMRF;
            this._hADD_FIRSTENTRYDATEFGRF = hADD_FIRSTENTRYDATEFGRF;
            this._hADD_FIRSTENTRYDATEFRRF = hADD_FIRSTENTRYDATEFRRF;
            this._hADD_FIRSTENTRYDATEFLSRF = hADD_FIRSTENTRYDATEFLSRF;
            this._hADD_FIRSTENTRYDATEFLPRF = hADD_FIRSTENTRYDATEFLPRF;
            this._hADD_FIRSTENTRYDATEFLYRF = hADD_FIRSTENTRYDATEFLYRF;
            this._hADD_FIRSTENTRYDATEFLMRF = hADD_FIRSTENTRYDATEFLMRF;
            this._hADD_PRINTCUSTOMERNM1RF = hADD_PRINTCUSTOMERNM1RF;
            this._hADD_PRINTCUSTOMERNM2RF = hADD_PRINTCUSTOMERNM2RF;
            this._hPURE_SALESTOTALTAXINCRF = hPURE_SALESTOTALTAXINCRF;
            this._hPURE_SALESTOTALTAXEXCRF = hPURE_SALESTOTALTAXEXCRF;
            this._hPURE_SALESSUBTOTALTAXINCRF = hPURE_SALESSUBTOTALTAXINCRF;
            this._hPURE_SALESSUBTOTALTAXEXCRF = hPURE_SALESSUBTOTALTAXEXCRF;
            this._hPURE_SALESSUBTOTALTAXRF = hPURE_SALESSUBTOTALTAXRF;
            this._hPRIME_SALESTOTALTAXINCRF = hPRIME_SALESTOTALTAXINCRF;
            this._hPRIME_SALESTOTALTAXEXCRF = hPRIME_SALESTOTALTAXEXCRF;
            this._hPRIME_SALESSUBTOTALTAXINCRF = hPRIME_SALESSUBTOTALTAXINCRF;
            this._hPRIME_SALESSUBTOTALTAXEXCRF = hPRIME_SALESSUBTOTALTAXEXCRF;
            this._hPRIME_SALESSUBTOTALTAXRF = hPRIME_SALESSUBTOTALTAXRF;
            this._hADD_PRINTTIMEHOURRF = hADD_PRINTTIMEHOURRF;
            this._hADD_PRINTTIMEMINUTERF = hADD_PRINTTIMEMINUTERF;
            this._hADD_PRINTTIMESECONDRF = hADD_PRINTTIMESECONDRF;
            this._hADD_ESTFMDIVRF = hADD_ESTFMDIVRF;
            this._hADD_SALESDATEFYRF = hADD_SALESDATEFYRF;
            this._hADD_SALESDATEFSRF = hADD_SALESDATEFSRF;
            this._hADD_SALESDATEFWRF = hADD_SALESDATEFWRF;
            this._hADD_SALESDATEFMRF = hADD_SALESDATEFMRF;
            this._hADD_SALESDATEFDRF = hADD_SALESDATEFDRF;
            this._hADD_SALESDATEFGRF = hADD_SALESDATEFGRF;
            this._hADD_SALESDATEFRRF = hADD_SALESDATEFRRF;
            this._hADD_SALESDATEFLSRF = hADD_SALESDATEFLSRF;
            this._hADD_SALESDATEFLPRF = hADD_SALESDATEFLPRF;
            this._hADD_SALESDATEFLYRF = hADD_SALESDATEFLYRF;
            this._hADD_SALESDATEFLMRF = hADD_SALESDATEFLMRF;
            this._hADD_SALESDATEFLDRF = hADD_SALESDATEFLDRF;
            this._hADD_SALESSLIPPRINTDATEFYRF = hADD_SALESSLIPPRINTDATEFYRF;
            this._hADD_SALESSLIPPRINTDATEFSRF = hADD_SALESSLIPPRINTDATEFSRF;
            this._hADD_SALESSLIPPRINTDATEFWRF = hADD_SALESSLIPPRINTDATEFWRF;
            this._hADD_SALESSLIPPRINTDATEFMRF = hADD_SALESSLIPPRINTDATEFMRF;
            this._hADD_SALESSLIPPRINTDATEFDRF = hADD_SALESSLIPPRINTDATEFDRF;
            this._hADD_SALESSLIPPRINTDATEFGRF = hADD_SALESSLIPPRINTDATEFGRF;
            this._hADD_SALESSLIPPRINTDATEFRRF = hADD_SALESSLIPPRINTDATEFRRF;
            this._hADD_SALESSLIPPRINTDATEFLSRF = hADD_SALESSLIPPRINTDATEFLSRF;
            this._hADD_SALESSLIPPRINTDATEFLPRF = hADD_SALESSLIPPRINTDATEFLPRF;
            this._hADD_SALESSLIPPRINTDATEFLYRF = hADD_SALESSLIPPRINTDATEFLYRF;
            this._hADD_SALESSLIPPRINTDATEFLMRF = hADD_SALESSLIPPRINTDATEFLMRF;
            this._hADD_SALESSLIPPRINTDATEFLDRF = hADD_SALESSLIPPRINTDATEFLDRF;
            this._hADD_SYSTEMATICCODERF = hADD_SYSTEMATICCODERF;
            this._hADD_SYSTEMATICNAMERF = hADD_SYSTEMATICNAMERF;
            this._hADD_STPRODUCETYPEOFYEARRF = hADD_STPRODUCETYPEOFYEARRF;
            this._hADD_EDPRODUCETYPEOFYEARRF = hADD_EDPRODUCETYPEOFYEARRF;
            this._hADD_DOORCOUNTRF = hADD_DOORCOUNTRF;
            this._hADD_BODYNAMECODERF = hADD_BODYNAMECODERF;
            this._hADD_BODYNAMERF = hADD_BODYNAMERF;
            this._hADD_STPRODUCEFRAMENORF = hADD_STPRODUCEFRAMENORF;
            this._hADD_EDPRODUCEFRAMENORF = hADD_EDPRODUCEFRAMENORF;
            this._hADD_ENGINEMODELRF = hADD_ENGINEMODELRF;
            this._hADD_MODELGRADENMRF = hADD_MODELGRADENMRF;
            this._hADD_ENGINEDISPLACENMRF = hADD_ENGINEDISPLACENMRF;
            this._hADD_EDIVNMRF = hADD_EDIVNMRF;
            this._hADD_TRANSMISSIONNMRF = hADD_TRANSMISSIONNMRF;
            this._hADD_SHIFTNMRF = hADD_SHIFTNMRF;
            this._hADD_WHEELDRIVEMETHODNMRF = hADD_WHEELDRIVEMETHODNMRF;
            this._hADD_ADDICARSPEC1RF = hADD_ADDICARSPEC1RF;
            this._hADD_ADDICARSPEC2RF = hADD_ADDICARSPEC2RF;
            this._hADD_ADDICARSPEC3RF = hADD_ADDICARSPEC3RF;
            this._hADD_ADDICARSPEC4RF = hADD_ADDICARSPEC4RF;
            this._hADD_ADDICARSPEC5RF = hADD_ADDICARSPEC5RF;
            this._hADD_ADDICARSPEC6RF = hADD_ADDICARSPEC6RF;
            this._hADD_ADDICARSPECTITLE1RF = hADD_ADDICARSPECTITLE1RF;
            this._hADD_ADDICARSPECTITLE2RF = hADD_ADDICARSPECTITLE2RF;
            this._hADD_ADDICARSPECTITLE3RF = hADD_ADDICARSPECTITLE3RF;
            this._hADD_ADDICARSPECTITLE4RF = hADD_ADDICARSPECTITLE4RF;
            this._hADD_ADDICARSPECTITLE5RF = hADD_ADDICARSPECTITLE5RF;
            this._hADD_ADDICARSPECTITLE6RF = hADD_ADDICARSPECTITLE6RF;
            this._hADD_STPRODUCETYPEOFYEARFYRF = hADD_STPRODUCETYPEOFYEARFYRF;
            this._hADD_STPRODUCETYPEOFYEARFSRF = hADD_STPRODUCETYPEOFYEARFSRF;
            this._hADD_STPRODUCETYPEOFYEARFWRF = hADD_STPRODUCETYPEOFYEARFWRF;
            this._hADD_STPRODUCETYPEOFYEARFMRF = hADD_STPRODUCETYPEOFYEARFMRF;
            this._hADD_STPRODUCETYPEOFYEARFGRF = hADD_STPRODUCETYPEOFYEARFGRF;
            this._hADD_STPRODUCETYPEOFYEARFRRF = hADD_STPRODUCETYPEOFYEARFRRF;
            this._hADD_STPRODUCETYPEOFYEARFLSRF = hADD_STPRODUCETYPEOFYEARFLSRF;
            this._hADD_STPRODUCETYPEOFYEARFLPRF = hADD_STPRODUCETYPEOFYEARFLPRF;
            this._hADD_STPRODUCETYPEOFYEARFLYRF = hADD_STPRODUCETYPEOFYEARFLYRF;
            this._hADD_STPRODUCETYPEOFYEARFLMRF = hADD_STPRODUCETYPEOFYEARFLMRF;
            this._hADD_EDPRODUCETYPEOFYEARFYRF = hADD_EDPRODUCETYPEOFYEARFYRF;
            this._hADD_EDPRODUCETYPEOFYEARFSRF = hADD_EDPRODUCETYPEOFYEARFSRF;
            this._hADD_EDPRODUCETYPEOFYEARFWRF = hADD_EDPRODUCETYPEOFYEARFWRF;
            this._hADD_EDPRODUCETYPEOFYEARFMRF = hADD_EDPRODUCETYPEOFYEARFMRF;
            this._hADD_EDPRODUCETYPEOFYEARFGRF = hADD_EDPRODUCETYPEOFYEARFGRF;
            this._hADD_EDPRODUCETYPEOFYEARFRRF = hADD_EDPRODUCETYPEOFYEARFRRF;
            this._hADD_EDPRODUCETYPEOFYEARFLSRF = hADD_EDPRODUCETYPEOFYEARFLSRF;
            this._hADD_EDPRODUCETYPEOFYEARFLPRF = hADD_EDPRODUCETYPEOFYEARFLPRF;
            this._hADD_EDPRODUCETYPEOFYEARFLYRF = hADD_EDPRODUCETYPEOFYEARFLYRF;
            this._hADD_EDPRODUCETYPEOFYEARFLMRF = hADD_EDPRODUCETYPEOFYEARFLMRF;

        }

        /// <summary>
        /// 自由帳票見積書ヘッダデータ複製処理
        /// </summary>
        /// <returns>FrePEstFmHeadクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいFrePEstFmHeadクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public FrePEstFmHead Clone()
        {
            return new FrePEstFmHead( this._sALESSLIPRF_SALESSLIPNUMRF, this._sALESSLIPRF_SECTIONCODERF, this._sALESSLIPRF_SALESDATERF, this._sALESSLIPRF_ESTIMATEFORMNORF, this._sALESSLIPRF_ESTIMATEDIVIDERF, this._sALESSLIPRF_SALESINPUTCODERF, this._sALESSLIPRF_SALESINPUTNAMERF, this._sALESSLIPRF_FRONTEMPLOYEECDRF, this._sALESSLIPRF_FRONTEMPLOYEENMRF, this._sALESSLIPRF_SALESEMPLOYEECDRF, this._sALESSLIPRF_SALESEMPLOYEENMRF, this._sALESSLIPRF_CONSTAXLAYMETHODRF, this._sALESSLIPRF_CUSTOMERCODERF, this._sALESSLIPRF_CUSTOMERNAMERF, this._sALESSLIPRF_CUSTOMERNAME2RF, this._sALESSLIPRF_CUSTOMERSNMRF, this._sALESSLIPRF_HONORIFICTITLERF, this._sALESSLIPRF_SALESSLIPPRINTDATERF, this._sALESSLIPRF_TOTALAMOUNTDISPWAYCDRF, this._sECINFOSETRF_SECTIONGUIDENMRF, this._cOMPANYNMRF_COMPANYPRRF, this._cOMPANYNMRF_COMPANYNAME1RF, this._cOMPANYNMRF_COMPANYNAME2RF, this._cOMPANYNMRF_POSTNORF, this._cOMPANYNMRF_ADDRESS1RF, this._cOMPANYNMRF_ADDRESS3RF, this._cOMPANYNMRF_ADDRESS4RF, this._cOMPANYNMRF_COMPANYTELNO1RF, this._cOMPANYNMRF_COMPANYTELNO2RF, this._cOMPANYNMRF_COMPANYTELNO3RF, this._cOMPANYNMRF_COMPANYTELTITLE1RF, this._cOMPANYNMRF_COMPANYTELTITLE2RF, this._cOMPANYNMRF_COMPANYTELTITLE3RF, this._cOMPANYNMRF_TRANSFERGUIDANCERF, this._cOMPANYNMRF_ACCOUNTNOINFO1RF, this._cOMPANYNMRF_ACCOUNTNOINFO2RF, this._cOMPANYNMRF_ACCOUNTNOINFO3RF, this._cOMPANYNMRF_COMPANYSETNOTE1RF, this._cOMPANYNMRF_COMPANYSETNOTE2RF, this._cOMPANYNMRF_COMPANYURLRF, this._cOMPANYNMRF_COMPANYPRSENTENCE2RF, this._cOMPANYNMRF_IMAGECOMMENTFORPRT1RF, this._cOMPANYNMRF_IMAGECOMMENTFORPRT2RF, this._iMAGEINFORF_IMAGEINFODATARF, this._cOMPANYINFRF_COMPANYNAME1RF, this._cOMPANYINFRF_COMPANYNAME2RF, this._cOMPANYINFRF_POSTNORF, this._cOMPANYINFRF_ADDRESS1RF, this._cOMPANYINFRF_ADDRESS3RF, this._cOMPANYINFRF_ADDRESS4RF, this._cOMPANYINFRF_COMPANYTELNO1RF, this._cOMPANYINFRF_COMPANYTELNO2RF, this._cOMPANYINFRF_COMPANYTELNO3RF, this._cOMPANYINFRF_COMPANYTELTITLE1RF, this._cOMPANYINFRF_COMPANYTELTITLE2RF, this._cOMPANYINFRF_COMPANYTELTITLE3RF, this._hEST_FOOTNOTES1RF, this._hEST_FOOTNOTES2RF, this._hEST_ESTIMATETITLE1RF, this._hEST_ESTIMATETITLE2RF, this._hEST_ESTIMATETITLE3RF, this._hEST_ESTIMATETITLE4RF, this._hEST_ESTIMATETITLE5RF, this._hEST_ESTIMATENOTE1RF, this._hEST_ESTIMATENOTE2RF, this._hEST_ESTIMATENOTE3RF, this._hEST_ESTIMATENOTE4RF, this._hEST_ESTIMATENOTE5RF, this._hEST_ESTIMATEVALIDITYLIMITRF, this._hEST_ESTIMATEVALIDITYLIMITFYRF, this._hEST_ESTIMATEVALIDITYLIMITFSRF, this._hEST_ESTIMATEVALIDITYLIMITFWRF, this._hEST_ESTIMATEVALIDITYLIMITFMRF, this._hEST_ESTIMATEVALIDITYLIMITFDRF, this._hEST_ESTIMATEVALIDITYLIMITFGRF, this._hEST_ESTIMATEVALIDITYLIMITFRRF, this._hEST_ESTIMATEVALIDITYLIMITFLSRF, this._hEST_ESTIMATEVALIDITYLIMITFLPRF, this._hEST_ESTIMATEVALIDITYLIMITFLYRF, this._hEST_ESTIMATEVALIDITYLIMITFLMRF, this._hEST_ESTIMATEVALIDITYLIMITFLDRF, this._hADD_CARMNGNORF, this._hADD_CARMNGCODERF, this._hADD_NUMBERPLATE1CODERF, this._hADD_NUMBERPLATE1NAMERF, this._hADD_NUMBERPLATE2RF, this._hADD_NUMBERPLATE3RF, this._hADD_NUMBERPLATE4RF, this._hADD_FIRSTENTRYDATERF, this._hADD_MAKERCODERF, this._hADD_MAKERFULLNAMERF, this._hADD_MAKERHALFNAMERF, this._hADD_MODELCODERF, this._hADD_MODELSUBCODERF, this._hADD_MODELFULLNAMERF, this._hADD_MODELHALFNAMERF, this._hADD_EXHAUSTGASSIGNRF, this._hADD_SERIESMODELRF, this._hADD_CATEGORYSIGNMODELRF, this._hADD_FULLMODELRF, this._hADD_MODELDESIGNATIONNORF, this._hADD_CATEGORYNORF, this._hADD_FRAMEMODELRF, this._hADD_FRAMENORF, this._hADD_SEARCHFRAMENORF, this._hADD_ENGINEMODELNMRF, this._hADD_RELEVANCEMODELRF, this._hADD_SUBCARNMCDRF, this._hADD_MODELGRADESNAMERF, this._hADD_COLORCODERF, this._hADD_COLORNAME1RF, this._hADD_TRIMCODERF, this._hADD_TRIMNAMERF, this._hADD_MILEAGERF, this._hADD_PRINTERMNGNORF, this._hADD_SLIPPRTSETPAPERIDRF, this._hADD_NOTE1RF, this._hADD_NOTE2RF, this._hADD_NOTE3RF, this._hADD_FIRSTENTRYDATEFYRF, this._hADD_FIRSTENTRYDATEFSRF, this._hADD_FIRSTENTRYDATEFWRF, this._hADD_FIRSTENTRYDATEFMRF, this._hADD_FIRSTENTRYDATEFGRF, this._hADD_FIRSTENTRYDATEFRRF, this._hADD_FIRSTENTRYDATEFLSRF, this._hADD_FIRSTENTRYDATEFLPRF, this._hADD_FIRSTENTRYDATEFLYRF, this._hADD_FIRSTENTRYDATEFLMRF, this._hADD_PRINTCUSTOMERNM1RF, this._hADD_PRINTCUSTOMERNM2RF, this._hPURE_SALESTOTALTAXINCRF, this._hPURE_SALESTOTALTAXEXCRF, this._hPURE_SALESSUBTOTALTAXINCRF, this._hPURE_SALESSUBTOTALTAXEXCRF, this._hPURE_SALESSUBTOTALTAXRF, this._hPRIME_SALESTOTALTAXINCRF, this._hPRIME_SALESTOTALTAXEXCRF, this._hPRIME_SALESSUBTOTALTAXINCRF, this._hPRIME_SALESSUBTOTALTAXEXCRF, this._hPRIME_SALESSUBTOTALTAXRF, this._hADD_PRINTTIMEHOURRF, this._hADD_PRINTTIMEMINUTERF, this._hADD_PRINTTIMESECONDRF, this._hADD_ESTFMDIVRF, this._hADD_SALESDATEFYRF, this._hADD_SALESDATEFSRF, this._hADD_SALESDATEFWRF, this._hADD_SALESDATEFMRF, this._hADD_SALESDATEFDRF, this._hADD_SALESDATEFGRF, this._hADD_SALESDATEFRRF, this._hADD_SALESDATEFLSRF, this._hADD_SALESDATEFLPRF, this._hADD_SALESDATEFLYRF, this._hADD_SALESDATEFLMRF, this._hADD_SALESDATEFLDRF, this._hADD_SALESSLIPPRINTDATEFYRF, this._hADD_SALESSLIPPRINTDATEFSRF, this._hADD_SALESSLIPPRINTDATEFWRF, this._hADD_SALESSLIPPRINTDATEFMRF, this._hADD_SALESSLIPPRINTDATEFDRF, this._hADD_SALESSLIPPRINTDATEFGRF, this._hADD_SALESSLIPPRINTDATEFRRF, this._hADD_SALESSLIPPRINTDATEFLSRF, this._hADD_SALESSLIPPRINTDATEFLPRF, this._hADD_SALESSLIPPRINTDATEFLYRF, this._hADD_SALESSLIPPRINTDATEFLMRF, this._hADD_SALESSLIPPRINTDATEFLDRF, this._hADD_SYSTEMATICCODERF, this._hADD_SYSTEMATICNAMERF, this._hADD_STPRODUCETYPEOFYEARRF, this._hADD_EDPRODUCETYPEOFYEARRF, this._hADD_DOORCOUNTRF, this._hADD_BODYNAMECODERF, this._hADD_BODYNAMERF, this._hADD_STPRODUCEFRAMENORF, this._hADD_EDPRODUCEFRAMENORF, this._hADD_ENGINEMODELRF, this._hADD_MODELGRADENMRF, this._hADD_ENGINEDISPLACENMRF, this._hADD_EDIVNMRF, this._hADD_TRANSMISSIONNMRF, this._hADD_SHIFTNMRF, this._hADD_WHEELDRIVEMETHODNMRF, this._hADD_ADDICARSPEC1RF, this._hADD_ADDICARSPEC2RF, this._hADD_ADDICARSPEC3RF, this._hADD_ADDICARSPEC4RF, this._hADD_ADDICARSPEC5RF, this._hADD_ADDICARSPEC6RF, this._hADD_ADDICARSPECTITLE1RF, this._hADD_ADDICARSPECTITLE2RF, this._hADD_ADDICARSPECTITLE3RF, this._hADD_ADDICARSPECTITLE4RF, this._hADD_ADDICARSPECTITLE5RF, this._hADD_ADDICARSPECTITLE6RF, this._hADD_STPRODUCETYPEOFYEARFYRF, this._hADD_STPRODUCETYPEOFYEARFSRF, this._hADD_STPRODUCETYPEOFYEARFWRF, this._hADD_STPRODUCETYPEOFYEARFMRF, this._hADD_STPRODUCETYPEOFYEARFGRF, this._hADD_STPRODUCETYPEOFYEARFRRF, this._hADD_STPRODUCETYPEOFYEARFLSRF, this._hADD_STPRODUCETYPEOFYEARFLPRF, this._hADD_STPRODUCETYPEOFYEARFLYRF, this._hADD_STPRODUCETYPEOFYEARFLMRF, this._hADD_EDPRODUCETYPEOFYEARFYRF, this._hADD_EDPRODUCETYPEOFYEARFSRF, this._hADD_EDPRODUCETYPEOFYEARFWRF, this._hADD_EDPRODUCETYPEOFYEARFMRF, this._hADD_EDPRODUCETYPEOFYEARFGRF, this._hADD_EDPRODUCETYPEOFYEARFRRF, this._hADD_EDPRODUCETYPEOFYEARFLSRF, this._hADD_EDPRODUCETYPEOFYEARFLPRF, this._hADD_EDPRODUCETYPEOFYEARFLYRF, this._hADD_EDPRODUCETYPEOFYEARFLMRF );
        }

        /// <summary>
        /// 自由帳票見積書ヘッダデータ比較処理
        /// </summary>
        /// <param name="target">比較対象のFrePEstFmHeadクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   FrePEstFmHeadクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool Equals( FrePEstFmHead target )
        {
            return ((this.SALESSLIPRF_SALESSLIPNUMRF == target.SALESSLIPRF_SALESSLIPNUMRF)
                 && (this.SALESSLIPRF_SECTIONCODERF == target.SALESSLIPRF_SECTIONCODERF)
                 && (this.SALESSLIPRF_SALESDATERF == target.SALESSLIPRF_SALESDATERF)
                 && (this.SALESSLIPRF_ESTIMATEFORMNORF == target.SALESSLIPRF_ESTIMATEFORMNORF)
                 && (this.SALESSLIPRF_ESTIMATEDIVIDERF == target.SALESSLIPRF_ESTIMATEDIVIDERF)
                 && (this.SALESSLIPRF_SALESINPUTCODERF == target.SALESSLIPRF_SALESINPUTCODERF)
                 && (this.SALESSLIPRF_SALESINPUTNAMERF == target.SALESSLIPRF_SALESINPUTNAMERF)
                 && (this.SALESSLIPRF_FRONTEMPLOYEECDRF == target.SALESSLIPRF_FRONTEMPLOYEECDRF)
                 && (this.SALESSLIPRF_FRONTEMPLOYEENMRF == target.SALESSLIPRF_FRONTEMPLOYEENMRF)
                 && (this.SALESSLIPRF_SALESEMPLOYEECDRF == target.SALESSLIPRF_SALESEMPLOYEECDRF)
                 && (this.SALESSLIPRF_SALESEMPLOYEENMRF == target.SALESSLIPRF_SALESEMPLOYEENMRF)
                 && (this.SALESSLIPRF_CONSTAXLAYMETHODRF == target.SALESSLIPRF_CONSTAXLAYMETHODRF)
                 && (this.SALESSLIPRF_CUSTOMERCODERF == target.SALESSLIPRF_CUSTOMERCODERF)
                 && (this.SALESSLIPRF_CUSTOMERNAMERF == target.SALESSLIPRF_CUSTOMERNAMERF)
                 && (this.SALESSLIPRF_CUSTOMERNAME2RF == target.SALESSLIPRF_CUSTOMERNAME2RF)
                 && (this.SALESSLIPRF_CUSTOMERSNMRF == target.SALESSLIPRF_CUSTOMERSNMRF)
                 && (this.SALESSLIPRF_HONORIFICTITLERF == target.SALESSLIPRF_HONORIFICTITLERF)
                 && (this.SALESSLIPRF_SALESSLIPPRINTDATERF == target.SALESSLIPRF_SALESSLIPPRINTDATERF)
                 && (this.SALESSLIPRF_TOTALAMOUNTDISPWAYCDRF == target.SALESSLIPRF_TOTALAMOUNTDISPWAYCDRF)
                 && (this.SECINFOSETRF_SECTIONGUIDENMRF == target.SECINFOSETRF_SECTIONGUIDENMRF)
                 && (this.COMPANYNMRF_COMPANYPRRF == target.COMPANYNMRF_COMPANYPRRF)
                 && (this.COMPANYNMRF_COMPANYNAME1RF == target.COMPANYNMRF_COMPANYNAME1RF)
                 && (this.COMPANYNMRF_COMPANYNAME2RF == target.COMPANYNMRF_COMPANYNAME2RF)
                 && (this.COMPANYNMRF_POSTNORF == target.COMPANYNMRF_POSTNORF)
                 && (this.COMPANYNMRF_ADDRESS1RF == target.COMPANYNMRF_ADDRESS1RF)
                 && (this.COMPANYNMRF_ADDRESS3RF == target.COMPANYNMRF_ADDRESS3RF)
                 && (this.COMPANYNMRF_ADDRESS4RF == target.COMPANYNMRF_ADDRESS4RF)
                 && (this.COMPANYNMRF_COMPANYTELNO1RF == target.COMPANYNMRF_COMPANYTELNO1RF)
                 && (this.COMPANYNMRF_COMPANYTELNO2RF == target.COMPANYNMRF_COMPANYTELNO2RF)
                 && (this.COMPANYNMRF_COMPANYTELNO3RF == target.COMPANYNMRF_COMPANYTELNO3RF)
                 && (this.COMPANYNMRF_COMPANYTELTITLE1RF == target.COMPANYNMRF_COMPANYTELTITLE1RF)
                 && (this.COMPANYNMRF_COMPANYTELTITLE2RF == target.COMPANYNMRF_COMPANYTELTITLE2RF)
                 && (this.COMPANYNMRF_COMPANYTELTITLE3RF == target.COMPANYNMRF_COMPANYTELTITLE3RF)
                 && (this.COMPANYNMRF_TRANSFERGUIDANCERF == target.COMPANYNMRF_TRANSFERGUIDANCERF)
                 && (this.COMPANYNMRF_ACCOUNTNOINFO1RF == target.COMPANYNMRF_ACCOUNTNOINFO1RF)
                 && (this.COMPANYNMRF_ACCOUNTNOINFO2RF == target.COMPANYNMRF_ACCOUNTNOINFO2RF)
                 && (this.COMPANYNMRF_ACCOUNTNOINFO3RF == target.COMPANYNMRF_ACCOUNTNOINFO3RF)
                 && (this.COMPANYNMRF_COMPANYSETNOTE1RF == target.COMPANYNMRF_COMPANYSETNOTE1RF)
                 && (this.COMPANYNMRF_COMPANYSETNOTE2RF == target.COMPANYNMRF_COMPANYSETNOTE2RF)
                 && (this.COMPANYNMRF_COMPANYURLRF == target.COMPANYNMRF_COMPANYURLRF)
                 && (this.COMPANYNMRF_COMPANYPRSENTENCE2RF == target.COMPANYNMRF_COMPANYPRSENTENCE2RF)
                 && (this.COMPANYNMRF_IMAGECOMMENTFORPRT1RF == target.COMPANYNMRF_IMAGECOMMENTFORPRT1RF)
                 && (this.COMPANYNMRF_IMAGECOMMENTFORPRT2RF == target.COMPANYNMRF_IMAGECOMMENTFORPRT2RF)
                 && (this.IMAGEINFORF_IMAGEINFODATARF == target.IMAGEINFORF_IMAGEINFODATARF)
                 && (this.COMPANYINFRF_COMPANYNAME1RF == target.COMPANYINFRF_COMPANYNAME1RF)
                 && (this.COMPANYINFRF_COMPANYNAME2RF == target.COMPANYINFRF_COMPANYNAME2RF)
                 && (this.COMPANYINFRF_POSTNORF == target.COMPANYINFRF_POSTNORF)
                 && (this.COMPANYINFRF_ADDRESS1RF == target.COMPANYINFRF_ADDRESS1RF)
                 && (this.COMPANYINFRF_ADDRESS3RF == target.COMPANYINFRF_ADDRESS3RF)
                 && (this.COMPANYINFRF_ADDRESS4RF == target.COMPANYINFRF_ADDRESS4RF)
                 && (this.COMPANYINFRF_COMPANYTELNO1RF == target.COMPANYINFRF_COMPANYTELNO1RF)
                 && (this.COMPANYINFRF_COMPANYTELNO2RF == target.COMPANYINFRF_COMPANYTELNO2RF)
                 && (this.COMPANYINFRF_COMPANYTELNO3RF == target.COMPANYINFRF_COMPANYTELNO3RF)
                 && (this.COMPANYINFRF_COMPANYTELTITLE1RF == target.COMPANYINFRF_COMPANYTELTITLE1RF)
                 && (this.COMPANYINFRF_COMPANYTELTITLE2RF == target.COMPANYINFRF_COMPANYTELTITLE2RF)
                 && (this.COMPANYINFRF_COMPANYTELTITLE3RF == target.COMPANYINFRF_COMPANYTELTITLE3RF)
                 && (this.HEST_FOOTNOTES1RF == target.HEST_FOOTNOTES1RF)
                 && (this.HEST_FOOTNOTES2RF == target.HEST_FOOTNOTES2RF)
                 && (this.HEST_ESTIMATETITLE1RF == target.HEST_ESTIMATETITLE1RF)
                 && (this.HEST_ESTIMATETITLE2RF == target.HEST_ESTIMATETITLE2RF)
                 && (this.HEST_ESTIMATETITLE3RF == target.HEST_ESTIMATETITLE3RF)
                 && (this.HEST_ESTIMATETITLE4RF == target.HEST_ESTIMATETITLE4RF)
                 && (this.HEST_ESTIMATETITLE5RF == target.HEST_ESTIMATETITLE5RF)
                 && (this.HEST_ESTIMATENOTE1RF == target.HEST_ESTIMATENOTE1RF)
                 && (this.HEST_ESTIMATENOTE2RF == target.HEST_ESTIMATENOTE2RF)
                 && (this.HEST_ESTIMATENOTE3RF == target.HEST_ESTIMATENOTE3RF)
                 && (this.HEST_ESTIMATENOTE4RF == target.HEST_ESTIMATENOTE4RF)
                 && (this.HEST_ESTIMATENOTE5RF == target.HEST_ESTIMATENOTE5RF)
                 && (this.HEST_ESTIMATEVALIDITYLIMITRF == target.HEST_ESTIMATEVALIDITYLIMITRF)
                 && (this.HEST_ESTIMATEVALIDITYLIMITFYRF == target.HEST_ESTIMATEVALIDITYLIMITFYRF)
                 && (this.HEST_ESTIMATEVALIDITYLIMITFSRF == target.HEST_ESTIMATEVALIDITYLIMITFSRF)
                 && (this.HEST_ESTIMATEVALIDITYLIMITFWRF == target.HEST_ESTIMATEVALIDITYLIMITFWRF)
                 && (this.HEST_ESTIMATEVALIDITYLIMITFMRF == target.HEST_ESTIMATEVALIDITYLIMITFMRF)
                 && (this.HEST_ESTIMATEVALIDITYLIMITFDRF == target.HEST_ESTIMATEVALIDITYLIMITFDRF)
                 && (this.HEST_ESTIMATEVALIDITYLIMITFGRF == target.HEST_ESTIMATEVALIDITYLIMITFGRF)
                 && (this.HEST_ESTIMATEVALIDITYLIMITFRRF == target.HEST_ESTIMATEVALIDITYLIMITFRRF)
                 && (this.HEST_ESTIMATEVALIDITYLIMITFLSRF == target.HEST_ESTIMATEVALIDITYLIMITFLSRF)
                 && (this.HEST_ESTIMATEVALIDITYLIMITFLPRF == target.HEST_ESTIMATEVALIDITYLIMITFLPRF)
                 && (this.HEST_ESTIMATEVALIDITYLIMITFLYRF == target.HEST_ESTIMATEVALIDITYLIMITFLYRF)
                 && (this.HEST_ESTIMATEVALIDITYLIMITFLMRF == target.HEST_ESTIMATEVALIDITYLIMITFLMRF)
                 && (this.HEST_ESTIMATEVALIDITYLIMITFLDRF == target.HEST_ESTIMATEVALIDITYLIMITFLDRF)
                 && (this.HADD_CARMNGNORF == target.HADD_CARMNGNORF)
                 && (this.HADD_CARMNGCODERF == target.HADD_CARMNGCODERF)
                 && (this.HADD_NUMBERPLATE1CODERF == target.HADD_NUMBERPLATE1CODERF)
                 && (this.HADD_NUMBERPLATE1NAMERF == target.HADD_NUMBERPLATE1NAMERF)
                 && (this.HADD_NUMBERPLATE2RF == target.HADD_NUMBERPLATE2RF)
                 && (this.HADD_NUMBERPLATE3RF == target.HADD_NUMBERPLATE3RF)
                 && (this.HADD_NUMBERPLATE4RF == target.HADD_NUMBERPLATE4RF)
                 && (this.HADD_FIRSTENTRYDATERF == target.HADD_FIRSTENTRYDATERF)
                 && (this.HADD_MAKERCODERF == target.HADD_MAKERCODERF)
                 && (this.HADD_MAKERFULLNAMERF == target.HADD_MAKERFULLNAMERF)
                 && (this.HADD_MAKERHALFNAMERF == target.HADD_MAKERHALFNAMERF)
                 && (this.HADD_MODELCODERF == target.HADD_MODELCODERF)
                 && (this.HADD_MODELSUBCODERF == target.HADD_MODELSUBCODERF)
                 && (this.HADD_MODELFULLNAMERF == target.HADD_MODELFULLNAMERF)
                 && (this.HADD_MODELHALFNAMERF == target.HADD_MODELHALFNAMERF)
                 && (this.HADD_EXHAUSTGASSIGNRF == target.HADD_EXHAUSTGASSIGNRF)
                 && (this.HADD_SERIESMODELRF == target.HADD_SERIESMODELRF)
                 && (this.HADD_CATEGORYSIGNMODELRF == target.HADD_CATEGORYSIGNMODELRF)
                 && (this.HADD_FULLMODELRF == target.HADD_FULLMODELRF)
                 && (this.HADD_MODELDESIGNATIONNORF == target.HADD_MODELDESIGNATIONNORF)
                 && (this.HADD_CATEGORYNORF == target.HADD_CATEGORYNORF)
                 && (this.HADD_FRAMEMODELRF == target.HADD_FRAMEMODELRF)
                 && (this.HADD_FRAMENORF == target.HADD_FRAMENORF)
                 && (this.HADD_SEARCHFRAMENORF == target.HADD_SEARCHFRAMENORF)
                 && (this.HADD_ENGINEMODELNMRF == target.HADD_ENGINEMODELNMRF)
                 && (this.HADD_RELEVANCEMODELRF == target.HADD_RELEVANCEMODELRF)
                 && (this.HADD_SUBCARNMCDRF == target.HADD_SUBCARNMCDRF)
                 && (this.HADD_MODELGRADESNAMERF == target.HADD_MODELGRADESNAMERF)
                 && (this.HADD_COLORCODERF == target.HADD_COLORCODERF)
                 && (this.HADD_COLORNAME1RF == target.HADD_COLORNAME1RF)
                 && (this.HADD_TRIMCODERF == target.HADD_TRIMCODERF)
                 && (this.HADD_TRIMNAMERF == target.HADD_TRIMNAMERF)
                 && (this.HADD_MILEAGERF == target.HADD_MILEAGERF)
                 && (this.HADD_PRINTERMNGNORF == target.HADD_PRINTERMNGNORF)
                 && (this.HADD_SLIPPRTSETPAPERIDRF == target.HADD_SLIPPRTSETPAPERIDRF)
                 && (this.HADD_NOTE1RF == target.HADD_NOTE1RF)
                 && (this.HADD_NOTE2RF == target.HADD_NOTE2RF)
                 && (this.HADD_NOTE3RF == target.HADD_NOTE3RF)
                 && (this.HADD_FIRSTENTRYDATEFYRF == target.HADD_FIRSTENTRYDATEFYRF)
                 && (this.HADD_FIRSTENTRYDATEFSRF == target.HADD_FIRSTENTRYDATEFSRF)
                 && (this.HADD_FIRSTENTRYDATEFWRF == target.HADD_FIRSTENTRYDATEFWRF)
                 && (this.HADD_FIRSTENTRYDATEFMRF == target.HADD_FIRSTENTRYDATEFMRF)
                 && (this.HADD_FIRSTENTRYDATEFGRF == target.HADD_FIRSTENTRYDATEFGRF)
                 && (this.HADD_FIRSTENTRYDATEFRRF == target.HADD_FIRSTENTRYDATEFRRF)
                 && (this.HADD_FIRSTENTRYDATEFLSRF == target.HADD_FIRSTENTRYDATEFLSRF)
                 && (this.HADD_FIRSTENTRYDATEFLPRF == target.HADD_FIRSTENTRYDATEFLPRF)
                 && (this.HADD_FIRSTENTRYDATEFLYRF == target.HADD_FIRSTENTRYDATEFLYRF)
                 && (this.HADD_FIRSTENTRYDATEFLMRF == target.HADD_FIRSTENTRYDATEFLMRF)
                 && (this.HADD_PRINTCUSTOMERNM1RF == target.HADD_PRINTCUSTOMERNM1RF)
                 && (this.HADD_PRINTCUSTOMERNM2RF == target.HADD_PRINTCUSTOMERNM2RF)
                 && (this.HPURE_SALESTOTALTAXINCRF == target.HPURE_SALESTOTALTAXINCRF)
                 && (this.HPURE_SALESTOTALTAXEXCRF == target.HPURE_SALESTOTALTAXEXCRF)
                 && (this.HPURE_SALESSUBTOTALTAXINCRF == target.HPURE_SALESSUBTOTALTAXINCRF)
                 && (this.HPURE_SALESSUBTOTALTAXEXCRF == target.HPURE_SALESSUBTOTALTAXEXCRF)
                 && (this.HPURE_SALESSUBTOTALTAXRF == target.HPURE_SALESSUBTOTALTAXRF)
                 && (this.HPRIME_SALESTOTALTAXINCRF == target.HPRIME_SALESTOTALTAXINCRF)
                 && (this.HPRIME_SALESTOTALTAXEXCRF == target.HPRIME_SALESTOTALTAXEXCRF)
                 && (this.HPRIME_SALESSUBTOTALTAXINCRF == target.HPRIME_SALESSUBTOTALTAXINCRF)
                 && (this.HPRIME_SALESSUBTOTALTAXEXCRF == target.HPRIME_SALESSUBTOTALTAXEXCRF)
                 && (this.HPRIME_SALESSUBTOTALTAXRF == target.HPRIME_SALESSUBTOTALTAXRF)
                 && (this.HADD_PRINTTIMEHOURRF == target.HADD_PRINTTIMEHOURRF)
                 && (this.HADD_PRINTTIMEMINUTERF == target.HADD_PRINTTIMEMINUTERF)
                 && (this.HADD_PRINTTIMESECONDRF == target.HADD_PRINTTIMESECONDRF)
                 && (this.HADD_ESTFMDIVRF == target.HADD_ESTFMDIVRF)
                 && (this.HADD_SALESDATEFYRF == target.HADD_SALESDATEFYRF)
                 && (this.HADD_SALESDATEFSRF == target.HADD_SALESDATEFSRF)
                 && (this.HADD_SALESDATEFWRF == target.HADD_SALESDATEFWRF)
                 && (this.HADD_SALESDATEFMRF == target.HADD_SALESDATEFMRF)
                 && (this.HADD_SALESDATEFDRF == target.HADD_SALESDATEFDRF)
                 && (this.HADD_SALESDATEFGRF == target.HADD_SALESDATEFGRF)
                 && (this.HADD_SALESDATEFRRF == target.HADD_SALESDATEFRRF)
                 && (this.HADD_SALESDATEFLSRF == target.HADD_SALESDATEFLSRF)
                 && (this.HADD_SALESDATEFLPRF == target.HADD_SALESDATEFLPRF)
                 && (this.HADD_SALESDATEFLYRF == target.HADD_SALESDATEFLYRF)
                 && (this.HADD_SALESDATEFLMRF == target.HADD_SALESDATEFLMRF)
                 && (this.HADD_SALESDATEFLDRF == target.HADD_SALESDATEFLDRF)
                 && (this.HADD_SALESSLIPPRINTDATEFYRF == target.HADD_SALESSLIPPRINTDATEFYRF)
                 && (this.HADD_SALESSLIPPRINTDATEFSRF == target.HADD_SALESSLIPPRINTDATEFSRF)
                 && (this.HADD_SALESSLIPPRINTDATEFWRF == target.HADD_SALESSLIPPRINTDATEFWRF)
                 && (this.HADD_SALESSLIPPRINTDATEFMRF == target.HADD_SALESSLIPPRINTDATEFMRF)
                 && (this.HADD_SALESSLIPPRINTDATEFDRF == target.HADD_SALESSLIPPRINTDATEFDRF)
                 && (this.HADD_SALESSLIPPRINTDATEFGRF == target.HADD_SALESSLIPPRINTDATEFGRF)
                 && (this.HADD_SALESSLIPPRINTDATEFRRF == target.HADD_SALESSLIPPRINTDATEFRRF)
                 && (this.HADD_SALESSLIPPRINTDATEFLSRF == target.HADD_SALESSLIPPRINTDATEFLSRF)
                 && (this.HADD_SALESSLIPPRINTDATEFLPRF == target.HADD_SALESSLIPPRINTDATEFLPRF)
                 && (this.HADD_SALESSLIPPRINTDATEFLYRF == target.HADD_SALESSLIPPRINTDATEFLYRF)
                 && (this.HADD_SALESSLIPPRINTDATEFLMRF == target.HADD_SALESSLIPPRINTDATEFLMRF)
                 && (this.HADD_SALESSLIPPRINTDATEFLDRF == target.HADD_SALESSLIPPRINTDATEFLDRF)
                 && (this.HADD_SYSTEMATICCODERF == target.HADD_SYSTEMATICCODERF)
                 && (this.HADD_SYSTEMATICNAMERF == target.HADD_SYSTEMATICNAMERF)
                 && (this.HADD_STPRODUCETYPEOFYEARRF == target.HADD_STPRODUCETYPEOFYEARRF)
                 && (this.HADD_EDPRODUCETYPEOFYEARRF == target.HADD_EDPRODUCETYPEOFYEARRF)
                 && (this.HADD_DOORCOUNTRF == target.HADD_DOORCOUNTRF)
                 && (this.HADD_BODYNAMECODERF == target.HADD_BODYNAMECODERF)
                 && (this.HADD_BODYNAMERF == target.HADD_BODYNAMERF)
                 && (this.HADD_STPRODUCEFRAMENORF == target.HADD_STPRODUCEFRAMENORF)
                 && (this.HADD_EDPRODUCEFRAMENORF == target.HADD_EDPRODUCEFRAMENORF)
                 && (this.HADD_ENGINEMODELRF == target.HADD_ENGINEMODELRF)
                 && (this.HADD_MODELGRADENMRF == target.HADD_MODELGRADENMRF)
                 && (this.HADD_ENGINEDISPLACENMRF == target.HADD_ENGINEDISPLACENMRF)
                 && (this.HADD_EDIVNMRF == target.HADD_EDIVNMRF)
                 && (this.HADD_TRANSMISSIONNMRF == target.HADD_TRANSMISSIONNMRF)
                 && (this.HADD_SHIFTNMRF == target.HADD_SHIFTNMRF)
                 && (this.HADD_WHEELDRIVEMETHODNMRF == target.HADD_WHEELDRIVEMETHODNMRF)
                 && (this.HADD_ADDICARSPEC1RF == target.HADD_ADDICARSPEC1RF)
                 && (this.HADD_ADDICARSPEC2RF == target.HADD_ADDICARSPEC2RF)
                 && (this.HADD_ADDICARSPEC3RF == target.HADD_ADDICARSPEC3RF)
                 && (this.HADD_ADDICARSPEC4RF == target.HADD_ADDICARSPEC4RF)
                 && (this.HADD_ADDICARSPEC5RF == target.HADD_ADDICARSPEC5RF)
                 && (this.HADD_ADDICARSPEC6RF == target.HADD_ADDICARSPEC6RF)
                 && (this.HADD_ADDICARSPECTITLE1RF == target.HADD_ADDICARSPECTITLE1RF)
                 && (this.HADD_ADDICARSPECTITLE2RF == target.HADD_ADDICARSPECTITLE2RF)
                 && (this.HADD_ADDICARSPECTITLE3RF == target.HADD_ADDICARSPECTITLE3RF)
                 && (this.HADD_ADDICARSPECTITLE4RF == target.HADD_ADDICARSPECTITLE4RF)
                 && (this.HADD_ADDICARSPECTITLE5RF == target.HADD_ADDICARSPECTITLE5RF)
                 && (this.HADD_ADDICARSPECTITLE6RF == target.HADD_ADDICARSPECTITLE6RF)
                 && (this.HADD_STPRODUCETYPEOFYEARFYRF == target.HADD_STPRODUCETYPEOFYEARFYRF)
                 && (this.HADD_STPRODUCETYPEOFYEARFSRF == target.HADD_STPRODUCETYPEOFYEARFSRF)
                 && (this.HADD_STPRODUCETYPEOFYEARFWRF == target.HADD_STPRODUCETYPEOFYEARFWRF)
                 && (this.HADD_STPRODUCETYPEOFYEARFMRF == target.HADD_STPRODUCETYPEOFYEARFMRF)
                 && (this.HADD_STPRODUCETYPEOFYEARFGRF == target.HADD_STPRODUCETYPEOFYEARFGRF)
                 && (this.HADD_STPRODUCETYPEOFYEARFRRF == target.HADD_STPRODUCETYPEOFYEARFRRF)
                 && (this.HADD_STPRODUCETYPEOFYEARFLSRF == target.HADD_STPRODUCETYPEOFYEARFLSRF)
                 && (this.HADD_STPRODUCETYPEOFYEARFLPRF == target.HADD_STPRODUCETYPEOFYEARFLPRF)
                 && (this.HADD_STPRODUCETYPEOFYEARFLYRF == target.HADD_STPRODUCETYPEOFYEARFLYRF)
                 && (this.HADD_STPRODUCETYPEOFYEARFLMRF == target.HADD_STPRODUCETYPEOFYEARFLMRF)
                 && (this.HADD_EDPRODUCETYPEOFYEARFYRF == target.HADD_EDPRODUCETYPEOFYEARFYRF)
                 && (this.HADD_EDPRODUCETYPEOFYEARFSRF == target.HADD_EDPRODUCETYPEOFYEARFSRF)
                 && (this.HADD_EDPRODUCETYPEOFYEARFWRF == target.HADD_EDPRODUCETYPEOFYEARFWRF)
                 && (this.HADD_EDPRODUCETYPEOFYEARFMRF == target.HADD_EDPRODUCETYPEOFYEARFMRF)
                 && (this.HADD_EDPRODUCETYPEOFYEARFGRF == target.HADD_EDPRODUCETYPEOFYEARFGRF)
                 && (this.HADD_EDPRODUCETYPEOFYEARFRRF == target.HADD_EDPRODUCETYPEOFYEARFRRF)
                 && (this.HADD_EDPRODUCETYPEOFYEARFLSRF == target.HADD_EDPRODUCETYPEOFYEARFLSRF)
                 && (this.HADD_EDPRODUCETYPEOFYEARFLPRF == target.HADD_EDPRODUCETYPEOFYEARFLPRF)
                 && (this.HADD_EDPRODUCETYPEOFYEARFLYRF == target.HADD_EDPRODUCETYPEOFYEARFLYRF)
                 && (this.HADD_EDPRODUCETYPEOFYEARFLMRF == target.HADD_EDPRODUCETYPEOFYEARFLMRF));
        }

        /// <summary>
        /// 自由帳票見積書ヘッダデータ比較処理
        /// </summary>
        /// <param name="frePEstFmHead1">
        ///                    比較するFrePEstFmHeadクラスのインスタンス
        /// </param>
        /// <param name="frePEstFmHead2">比較するFrePEstFmHeadクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   FrePEstFmHeadクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static bool Equals( FrePEstFmHead frePEstFmHead1, FrePEstFmHead frePEstFmHead2 )
        {
            return ((frePEstFmHead1.SALESSLIPRF_SALESSLIPNUMRF == frePEstFmHead2.SALESSLIPRF_SALESSLIPNUMRF)
                 && (frePEstFmHead1.SALESSLIPRF_SECTIONCODERF == frePEstFmHead2.SALESSLIPRF_SECTIONCODERF)
                 && (frePEstFmHead1.SALESSLIPRF_SALESDATERF == frePEstFmHead2.SALESSLIPRF_SALESDATERF)
                 && (frePEstFmHead1.SALESSLIPRF_ESTIMATEFORMNORF == frePEstFmHead2.SALESSLIPRF_ESTIMATEFORMNORF)
                 && (frePEstFmHead1.SALESSLIPRF_ESTIMATEDIVIDERF == frePEstFmHead2.SALESSLIPRF_ESTIMATEDIVIDERF)
                 && (frePEstFmHead1.SALESSLIPRF_SALESINPUTCODERF == frePEstFmHead2.SALESSLIPRF_SALESINPUTCODERF)
                 && (frePEstFmHead1.SALESSLIPRF_SALESINPUTNAMERF == frePEstFmHead2.SALESSLIPRF_SALESINPUTNAMERF)
                 && (frePEstFmHead1.SALESSLIPRF_FRONTEMPLOYEECDRF == frePEstFmHead2.SALESSLIPRF_FRONTEMPLOYEECDRF)
                 && (frePEstFmHead1.SALESSLIPRF_FRONTEMPLOYEENMRF == frePEstFmHead2.SALESSLIPRF_FRONTEMPLOYEENMRF)
                 && (frePEstFmHead1.SALESSLIPRF_SALESEMPLOYEECDRF == frePEstFmHead2.SALESSLIPRF_SALESEMPLOYEECDRF)
                 && (frePEstFmHead1.SALESSLIPRF_SALESEMPLOYEENMRF == frePEstFmHead2.SALESSLIPRF_SALESEMPLOYEENMRF)
                 && (frePEstFmHead1.SALESSLIPRF_CONSTAXLAYMETHODRF == frePEstFmHead2.SALESSLIPRF_CONSTAXLAYMETHODRF)
                 && (frePEstFmHead1.SALESSLIPRF_CUSTOMERCODERF == frePEstFmHead2.SALESSLIPRF_CUSTOMERCODERF)
                 && (frePEstFmHead1.SALESSLIPRF_CUSTOMERNAMERF == frePEstFmHead2.SALESSLIPRF_CUSTOMERNAMERF)
                 && (frePEstFmHead1.SALESSLIPRF_CUSTOMERNAME2RF == frePEstFmHead2.SALESSLIPRF_CUSTOMERNAME2RF)
                 && (frePEstFmHead1.SALESSLIPRF_CUSTOMERSNMRF == frePEstFmHead2.SALESSLIPRF_CUSTOMERSNMRF)
                 && (frePEstFmHead1.SALESSLIPRF_HONORIFICTITLERF == frePEstFmHead2.SALESSLIPRF_HONORIFICTITLERF)
                 && (frePEstFmHead1.SALESSLIPRF_SALESSLIPPRINTDATERF == frePEstFmHead2.SALESSLIPRF_SALESSLIPPRINTDATERF)
                 && (frePEstFmHead1.SALESSLIPRF_TOTALAMOUNTDISPWAYCDRF == frePEstFmHead2.SALESSLIPRF_TOTALAMOUNTDISPWAYCDRF)
                 && (frePEstFmHead1.SECINFOSETRF_SECTIONGUIDENMRF == frePEstFmHead2.SECINFOSETRF_SECTIONGUIDENMRF)
                 && (frePEstFmHead1.COMPANYNMRF_COMPANYPRRF == frePEstFmHead2.COMPANYNMRF_COMPANYPRRF)
                 && (frePEstFmHead1.COMPANYNMRF_COMPANYNAME1RF == frePEstFmHead2.COMPANYNMRF_COMPANYNAME1RF)
                 && (frePEstFmHead1.COMPANYNMRF_COMPANYNAME2RF == frePEstFmHead2.COMPANYNMRF_COMPANYNAME2RF)
                 && (frePEstFmHead1.COMPANYNMRF_POSTNORF == frePEstFmHead2.COMPANYNMRF_POSTNORF)
                 && (frePEstFmHead1.COMPANYNMRF_ADDRESS1RF == frePEstFmHead2.COMPANYNMRF_ADDRESS1RF)
                 && (frePEstFmHead1.COMPANYNMRF_ADDRESS3RF == frePEstFmHead2.COMPANYNMRF_ADDRESS3RF)
                 && (frePEstFmHead1.COMPANYNMRF_ADDRESS4RF == frePEstFmHead2.COMPANYNMRF_ADDRESS4RF)
                 && (frePEstFmHead1.COMPANYNMRF_COMPANYTELNO1RF == frePEstFmHead2.COMPANYNMRF_COMPANYTELNO1RF)
                 && (frePEstFmHead1.COMPANYNMRF_COMPANYTELNO2RF == frePEstFmHead2.COMPANYNMRF_COMPANYTELNO2RF)
                 && (frePEstFmHead1.COMPANYNMRF_COMPANYTELNO3RF == frePEstFmHead2.COMPANYNMRF_COMPANYTELNO3RF)
                 && (frePEstFmHead1.COMPANYNMRF_COMPANYTELTITLE1RF == frePEstFmHead2.COMPANYNMRF_COMPANYTELTITLE1RF)
                 && (frePEstFmHead1.COMPANYNMRF_COMPANYTELTITLE2RF == frePEstFmHead2.COMPANYNMRF_COMPANYTELTITLE2RF)
                 && (frePEstFmHead1.COMPANYNMRF_COMPANYTELTITLE3RF == frePEstFmHead2.COMPANYNMRF_COMPANYTELTITLE3RF)
                 && (frePEstFmHead1.COMPANYNMRF_TRANSFERGUIDANCERF == frePEstFmHead2.COMPANYNMRF_TRANSFERGUIDANCERF)
                 && (frePEstFmHead1.COMPANYNMRF_ACCOUNTNOINFO1RF == frePEstFmHead2.COMPANYNMRF_ACCOUNTNOINFO1RF)
                 && (frePEstFmHead1.COMPANYNMRF_ACCOUNTNOINFO2RF == frePEstFmHead2.COMPANYNMRF_ACCOUNTNOINFO2RF)
                 && (frePEstFmHead1.COMPANYNMRF_ACCOUNTNOINFO3RF == frePEstFmHead2.COMPANYNMRF_ACCOUNTNOINFO3RF)
                 && (frePEstFmHead1.COMPANYNMRF_COMPANYSETNOTE1RF == frePEstFmHead2.COMPANYNMRF_COMPANYSETNOTE1RF)
                 && (frePEstFmHead1.COMPANYNMRF_COMPANYSETNOTE2RF == frePEstFmHead2.COMPANYNMRF_COMPANYSETNOTE2RF)
                 && (frePEstFmHead1.COMPANYNMRF_COMPANYURLRF == frePEstFmHead2.COMPANYNMRF_COMPANYURLRF)
                 && (frePEstFmHead1.COMPANYNMRF_COMPANYPRSENTENCE2RF == frePEstFmHead2.COMPANYNMRF_COMPANYPRSENTENCE2RF)
                 && (frePEstFmHead1.COMPANYNMRF_IMAGECOMMENTFORPRT1RF == frePEstFmHead2.COMPANYNMRF_IMAGECOMMENTFORPRT1RF)
                 && (frePEstFmHead1.COMPANYNMRF_IMAGECOMMENTFORPRT2RF == frePEstFmHead2.COMPANYNMRF_IMAGECOMMENTFORPRT2RF)
                 && (frePEstFmHead1.IMAGEINFORF_IMAGEINFODATARF == frePEstFmHead2.IMAGEINFORF_IMAGEINFODATARF)
                 && (frePEstFmHead1.COMPANYINFRF_COMPANYNAME1RF == frePEstFmHead2.COMPANYINFRF_COMPANYNAME1RF)
                 && (frePEstFmHead1.COMPANYINFRF_COMPANYNAME2RF == frePEstFmHead2.COMPANYINFRF_COMPANYNAME2RF)
                 && (frePEstFmHead1.COMPANYINFRF_POSTNORF == frePEstFmHead2.COMPANYINFRF_POSTNORF)
                 && (frePEstFmHead1.COMPANYINFRF_ADDRESS1RF == frePEstFmHead2.COMPANYINFRF_ADDRESS1RF)
                 && (frePEstFmHead1.COMPANYINFRF_ADDRESS3RF == frePEstFmHead2.COMPANYINFRF_ADDRESS3RF)
                 && (frePEstFmHead1.COMPANYINFRF_ADDRESS4RF == frePEstFmHead2.COMPANYINFRF_ADDRESS4RF)
                 && (frePEstFmHead1.COMPANYINFRF_COMPANYTELNO1RF == frePEstFmHead2.COMPANYINFRF_COMPANYTELNO1RF)
                 && (frePEstFmHead1.COMPANYINFRF_COMPANYTELNO2RF == frePEstFmHead2.COMPANYINFRF_COMPANYTELNO2RF)
                 && (frePEstFmHead1.COMPANYINFRF_COMPANYTELNO3RF == frePEstFmHead2.COMPANYINFRF_COMPANYTELNO3RF)
                 && (frePEstFmHead1.COMPANYINFRF_COMPANYTELTITLE1RF == frePEstFmHead2.COMPANYINFRF_COMPANYTELTITLE1RF)
                 && (frePEstFmHead1.COMPANYINFRF_COMPANYTELTITLE2RF == frePEstFmHead2.COMPANYINFRF_COMPANYTELTITLE2RF)
                 && (frePEstFmHead1.COMPANYINFRF_COMPANYTELTITLE3RF == frePEstFmHead2.COMPANYINFRF_COMPANYTELTITLE3RF)
                 && (frePEstFmHead1.HEST_FOOTNOTES1RF == frePEstFmHead2.HEST_FOOTNOTES1RF)
                 && (frePEstFmHead1.HEST_FOOTNOTES2RF == frePEstFmHead2.HEST_FOOTNOTES2RF)
                 && (frePEstFmHead1.HEST_ESTIMATETITLE1RF == frePEstFmHead2.HEST_ESTIMATETITLE1RF)
                 && (frePEstFmHead1.HEST_ESTIMATETITLE2RF == frePEstFmHead2.HEST_ESTIMATETITLE2RF)
                 && (frePEstFmHead1.HEST_ESTIMATETITLE3RF == frePEstFmHead2.HEST_ESTIMATETITLE3RF)
                 && (frePEstFmHead1.HEST_ESTIMATETITLE4RF == frePEstFmHead2.HEST_ESTIMATETITLE4RF)
                 && (frePEstFmHead1.HEST_ESTIMATETITLE5RF == frePEstFmHead2.HEST_ESTIMATETITLE5RF)
                 && (frePEstFmHead1.HEST_ESTIMATENOTE1RF == frePEstFmHead2.HEST_ESTIMATENOTE1RF)
                 && (frePEstFmHead1.HEST_ESTIMATENOTE2RF == frePEstFmHead2.HEST_ESTIMATENOTE2RF)
                 && (frePEstFmHead1.HEST_ESTIMATENOTE3RF == frePEstFmHead2.HEST_ESTIMATENOTE3RF)
                 && (frePEstFmHead1.HEST_ESTIMATENOTE4RF == frePEstFmHead2.HEST_ESTIMATENOTE4RF)
                 && (frePEstFmHead1.HEST_ESTIMATENOTE5RF == frePEstFmHead2.HEST_ESTIMATENOTE5RF)
                 && (frePEstFmHead1.HEST_ESTIMATEVALIDITYLIMITRF == frePEstFmHead2.HEST_ESTIMATEVALIDITYLIMITRF)
                 && (frePEstFmHead1.HEST_ESTIMATEVALIDITYLIMITFYRF == frePEstFmHead2.HEST_ESTIMATEVALIDITYLIMITFYRF)
                 && (frePEstFmHead1.HEST_ESTIMATEVALIDITYLIMITFSRF == frePEstFmHead2.HEST_ESTIMATEVALIDITYLIMITFSRF)
                 && (frePEstFmHead1.HEST_ESTIMATEVALIDITYLIMITFWRF == frePEstFmHead2.HEST_ESTIMATEVALIDITYLIMITFWRF)
                 && (frePEstFmHead1.HEST_ESTIMATEVALIDITYLIMITFMRF == frePEstFmHead2.HEST_ESTIMATEVALIDITYLIMITFMRF)
                 && (frePEstFmHead1.HEST_ESTIMATEVALIDITYLIMITFDRF == frePEstFmHead2.HEST_ESTIMATEVALIDITYLIMITFDRF)
                 && (frePEstFmHead1.HEST_ESTIMATEVALIDITYLIMITFGRF == frePEstFmHead2.HEST_ESTIMATEVALIDITYLIMITFGRF)
                 && (frePEstFmHead1.HEST_ESTIMATEVALIDITYLIMITFRRF == frePEstFmHead2.HEST_ESTIMATEVALIDITYLIMITFRRF)
                 && (frePEstFmHead1.HEST_ESTIMATEVALIDITYLIMITFLSRF == frePEstFmHead2.HEST_ESTIMATEVALIDITYLIMITFLSRF)
                 && (frePEstFmHead1.HEST_ESTIMATEVALIDITYLIMITFLPRF == frePEstFmHead2.HEST_ESTIMATEVALIDITYLIMITFLPRF)
                 && (frePEstFmHead1.HEST_ESTIMATEVALIDITYLIMITFLYRF == frePEstFmHead2.HEST_ESTIMATEVALIDITYLIMITFLYRF)
                 && (frePEstFmHead1.HEST_ESTIMATEVALIDITYLIMITFLMRF == frePEstFmHead2.HEST_ESTIMATEVALIDITYLIMITFLMRF)
                 && (frePEstFmHead1.HEST_ESTIMATEVALIDITYLIMITFLDRF == frePEstFmHead2.HEST_ESTIMATEVALIDITYLIMITFLDRF)
                 && (frePEstFmHead1.HADD_CARMNGNORF == frePEstFmHead2.HADD_CARMNGNORF)
                 && (frePEstFmHead1.HADD_CARMNGCODERF == frePEstFmHead2.HADD_CARMNGCODERF)
                 && (frePEstFmHead1.HADD_NUMBERPLATE1CODERF == frePEstFmHead2.HADD_NUMBERPLATE1CODERF)
                 && (frePEstFmHead1.HADD_NUMBERPLATE1NAMERF == frePEstFmHead2.HADD_NUMBERPLATE1NAMERF)
                 && (frePEstFmHead1.HADD_NUMBERPLATE2RF == frePEstFmHead2.HADD_NUMBERPLATE2RF)
                 && (frePEstFmHead1.HADD_NUMBERPLATE3RF == frePEstFmHead2.HADD_NUMBERPLATE3RF)
                 && (frePEstFmHead1.HADD_NUMBERPLATE4RF == frePEstFmHead2.HADD_NUMBERPLATE4RF)
                 && (frePEstFmHead1.HADD_FIRSTENTRYDATERF == frePEstFmHead2.HADD_FIRSTENTRYDATERF)
                 && (frePEstFmHead1.HADD_MAKERCODERF == frePEstFmHead2.HADD_MAKERCODERF)
                 && (frePEstFmHead1.HADD_MAKERFULLNAMERF == frePEstFmHead2.HADD_MAKERFULLNAMERF)
                 && (frePEstFmHead1.HADD_MAKERHALFNAMERF == frePEstFmHead2.HADD_MAKERHALFNAMERF)
                 && (frePEstFmHead1.HADD_MODELCODERF == frePEstFmHead2.HADD_MODELCODERF)
                 && (frePEstFmHead1.HADD_MODELSUBCODERF == frePEstFmHead2.HADD_MODELSUBCODERF)
                 && (frePEstFmHead1.HADD_MODELFULLNAMERF == frePEstFmHead2.HADD_MODELFULLNAMERF)
                 && (frePEstFmHead1.HADD_MODELHALFNAMERF == frePEstFmHead2.HADD_MODELHALFNAMERF)
                 && (frePEstFmHead1.HADD_EXHAUSTGASSIGNRF == frePEstFmHead2.HADD_EXHAUSTGASSIGNRF)
                 && (frePEstFmHead1.HADD_SERIESMODELRF == frePEstFmHead2.HADD_SERIESMODELRF)
                 && (frePEstFmHead1.HADD_CATEGORYSIGNMODELRF == frePEstFmHead2.HADD_CATEGORYSIGNMODELRF)
                 && (frePEstFmHead1.HADD_FULLMODELRF == frePEstFmHead2.HADD_FULLMODELRF)
                 && (frePEstFmHead1.HADD_MODELDESIGNATIONNORF == frePEstFmHead2.HADD_MODELDESIGNATIONNORF)
                 && (frePEstFmHead1.HADD_CATEGORYNORF == frePEstFmHead2.HADD_CATEGORYNORF)
                 && (frePEstFmHead1.HADD_FRAMEMODELRF == frePEstFmHead2.HADD_FRAMEMODELRF)
                 && (frePEstFmHead1.HADD_FRAMENORF == frePEstFmHead2.HADD_FRAMENORF)
                 && (frePEstFmHead1.HADD_SEARCHFRAMENORF == frePEstFmHead2.HADD_SEARCHFRAMENORF)
                 && (frePEstFmHead1.HADD_ENGINEMODELNMRF == frePEstFmHead2.HADD_ENGINEMODELNMRF)
                 && (frePEstFmHead1.HADD_RELEVANCEMODELRF == frePEstFmHead2.HADD_RELEVANCEMODELRF)
                 && (frePEstFmHead1.HADD_SUBCARNMCDRF == frePEstFmHead2.HADD_SUBCARNMCDRF)
                 && (frePEstFmHead1.HADD_MODELGRADESNAMERF == frePEstFmHead2.HADD_MODELGRADESNAMERF)
                 && (frePEstFmHead1.HADD_COLORCODERF == frePEstFmHead2.HADD_COLORCODERF)
                 && (frePEstFmHead1.HADD_COLORNAME1RF == frePEstFmHead2.HADD_COLORNAME1RF)
                 && (frePEstFmHead1.HADD_TRIMCODERF == frePEstFmHead2.HADD_TRIMCODERF)
                 && (frePEstFmHead1.HADD_TRIMNAMERF == frePEstFmHead2.HADD_TRIMNAMERF)
                 && (frePEstFmHead1.HADD_MILEAGERF == frePEstFmHead2.HADD_MILEAGERF)
                 && (frePEstFmHead1.HADD_PRINTERMNGNORF == frePEstFmHead2.HADD_PRINTERMNGNORF)
                 && (frePEstFmHead1.HADD_SLIPPRTSETPAPERIDRF == frePEstFmHead2.HADD_SLIPPRTSETPAPERIDRF)
                 && (frePEstFmHead1.HADD_NOTE1RF == frePEstFmHead2.HADD_NOTE1RF)
                 && (frePEstFmHead1.HADD_NOTE2RF == frePEstFmHead2.HADD_NOTE2RF)
                 && (frePEstFmHead1.HADD_NOTE3RF == frePEstFmHead2.HADD_NOTE3RF)
                 && (frePEstFmHead1.HADD_FIRSTENTRYDATEFYRF == frePEstFmHead2.HADD_FIRSTENTRYDATEFYRF)
                 && (frePEstFmHead1.HADD_FIRSTENTRYDATEFSRF == frePEstFmHead2.HADD_FIRSTENTRYDATEFSRF)
                 && (frePEstFmHead1.HADD_FIRSTENTRYDATEFWRF == frePEstFmHead2.HADD_FIRSTENTRYDATEFWRF)
                 && (frePEstFmHead1.HADD_FIRSTENTRYDATEFMRF == frePEstFmHead2.HADD_FIRSTENTRYDATEFMRF)
                 && (frePEstFmHead1.HADD_FIRSTENTRYDATEFGRF == frePEstFmHead2.HADD_FIRSTENTRYDATEFGRF)
                 && (frePEstFmHead1.HADD_FIRSTENTRYDATEFRRF == frePEstFmHead2.HADD_FIRSTENTRYDATEFRRF)
                 && (frePEstFmHead1.HADD_FIRSTENTRYDATEFLSRF == frePEstFmHead2.HADD_FIRSTENTRYDATEFLSRF)
                 && (frePEstFmHead1.HADD_FIRSTENTRYDATEFLPRF == frePEstFmHead2.HADD_FIRSTENTRYDATEFLPRF)
                 && (frePEstFmHead1.HADD_FIRSTENTRYDATEFLYRF == frePEstFmHead2.HADD_FIRSTENTRYDATEFLYRF)
                 && (frePEstFmHead1.HADD_FIRSTENTRYDATEFLMRF == frePEstFmHead2.HADD_FIRSTENTRYDATEFLMRF)
                 && (frePEstFmHead1.HADD_PRINTCUSTOMERNM1RF == frePEstFmHead2.HADD_PRINTCUSTOMERNM1RF)
                 && (frePEstFmHead1.HADD_PRINTCUSTOMERNM2RF == frePEstFmHead2.HADD_PRINTCUSTOMERNM2RF)
                 && (frePEstFmHead1.HPURE_SALESTOTALTAXINCRF == frePEstFmHead2.HPURE_SALESTOTALTAXINCRF)
                 && (frePEstFmHead1.HPURE_SALESTOTALTAXEXCRF == frePEstFmHead2.HPURE_SALESTOTALTAXEXCRF)
                 && (frePEstFmHead1.HPURE_SALESSUBTOTALTAXINCRF == frePEstFmHead2.HPURE_SALESSUBTOTALTAXINCRF)
                 && (frePEstFmHead1.HPURE_SALESSUBTOTALTAXEXCRF == frePEstFmHead2.HPURE_SALESSUBTOTALTAXEXCRF)
                 && (frePEstFmHead1.HPURE_SALESSUBTOTALTAXRF == frePEstFmHead2.HPURE_SALESSUBTOTALTAXRF)
                 && (frePEstFmHead1.HPRIME_SALESTOTALTAXINCRF == frePEstFmHead2.HPRIME_SALESTOTALTAXINCRF)
                 && (frePEstFmHead1.HPRIME_SALESTOTALTAXEXCRF == frePEstFmHead2.HPRIME_SALESTOTALTAXEXCRF)
                 && (frePEstFmHead1.HPRIME_SALESSUBTOTALTAXINCRF == frePEstFmHead2.HPRIME_SALESSUBTOTALTAXINCRF)
                 && (frePEstFmHead1.HPRIME_SALESSUBTOTALTAXEXCRF == frePEstFmHead2.HPRIME_SALESSUBTOTALTAXEXCRF)
                 && (frePEstFmHead1.HPRIME_SALESSUBTOTALTAXRF == frePEstFmHead2.HPRIME_SALESSUBTOTALTAXRF)
                 && (frePEstFmHead1.HADD_PRINTTIMEHOURRF == frePEstFmHead2.HADD_PRINTTIMEHOURRF)
                 && (frePEstFmHead1.HADD_PRINTTIMEMINUTERF == frePEstFmHead2.HADD_PRINTTIMEMINUTERF)
                 && (frePEstFmHead1.HADD_PRINTTIMESECONDRF == frePEstFmHead2.HADD_PRINTTIMESECONDRF)
                 && (frePEstFmHead1.HADD_ESTFMDIVRF == frePEstFmHead2.HADD_ESTFMDIVRF)
                 && (frePEstFmHead1.HADD_SALESDATEFYRF == frePEstFmHead2.HADD_SALESDATEFYRF)
                 && (frePEstFmHead1.HADD_SALESDATEFSRF == frePEstFmHead2.HADD_SALESDATEFSRF)
                 && (frePEstFmHead1.HADD_SALESDATEFWRF == frePEstFmHead2.HADD_SALESDATEFWRF)
                 && (frePEstFmHead1.HADD_SALESDATEFMRF == frePEstFmHead2.HADD_SALESDATEFMRF)
                 && (frePEstFmHead1.HADD_SALESDATEFDRF == frePEstFmHead2.HADD_SALESDATEFDRF)
                 && (frePEstFmHead1.HADD_SALESDATEFGRF == frePEstFmHead2.HADD_SALESDATEFGRF)
                 && (frePEstFmHead1.HADD_SALESDATEFRRF == frePEstFmHead2.HADD_SALESDATEFRRF)
                 && (frePEstFmHead1.HADD_SALESDATEFLSRF == frePEstFmHead2.HADD_SALESDATEFLSRF)
                 && (frePEstFmHead1.HADD_SALESDATEFLPRF == frePEstFmHead2.HADD_SALESDATEFLPRF)
                 && (frePEstFmHead1.HADD_SALESDATEFLYRF == frePEstFmHead2.HADD_SALESDATEFLYRF)
                 && (frePEstFmHead1.HADD_SALESDATEFLMRF == frePEstFmHead2.HADD_SALESDATEFLMRF)
                 && (frePEstFmHead1.HADD_SALESDATEFLDRF == frePEstFmHead2.HADD_SALESDATEFLDRF)
                 && (frePEstFmHead1.HADD_SALESSLIPPRINTDATEFYRF == frePEstFmHead2.HADD_SALESSLIPPRINTDATEFYRF)
                 && (frePEstFmHead1.HADD_SALESSLIPPRINTDATEFSRF == frePEstFmHead2.HADD_SALESSLIPPRINTDATEFSRF)
                 && (frePEstFmHead1.HADD_SALESSLIPPRINTDATEFWRF == frePEstFmHead2.HADD_SALESSLIPPRINTDATEFWRF)
                 && (frePEstFmHead1.HADD_SALESSLIPPRINTDATEFMRF == frePEstFmHead2.HADD_SALESSLIPPRINTDATEFMRF)
                 && (frePEstFmHead1.HADD_SALESSLIPPRINTDATEFDRF == frePEstFmHead2.HADD_SALESSLIPPRINTDATEFDRF)
                 && (frePEstFmHead1.HADD_SALESSLIPPRINTDATEFGRF == frePEstFmHead2.HADD_SALESSLIPPRINTDATEFGRF)
                 && (frePEstFmHead1.HADD_SALESSLIPPRINTDATEFRRF == frePEstFmHead2.HADD_SALESSLIPPRINTDATEFRRF)
                 && (frePEstFmHead1.HADD_SALESSLIPPRINTDATEFLSRF == frePEstFmHead2.HADD_SALESSLIPPRINTDATEFLSRF)
                 && (frePEstFmHead1.HADD_SALESSLIPPRINTDATEFLPRF == frePEstFmHead2.HADD_SALESSLIPPRINTDATEFLPRF)
                 && (frePEstFmHead1.HADD_SALESSLIPPRINTDATEFLYRF == frePEstFmHead2.HADD_SALESSLIPPRINTDATEFLYRF)
                 && (frePEstFmHead1.HADD_SALESSLIPPRINTDATEFLMRF == frePEstFmHead2.HADD_SALESSLIPPRINTDATEFLMRF)
                 && (frePEstFmHead1.HADD_SALESSLIPPRINTDATEFLDRF == frePEstFmHead2.HADD_SALESSLIPPRINTDATEFLDRF)
                 && (frePEstFmHead1.HADD_SYSTEMATICCODERF == frePEstFmHead2.HADD_SYSTEMATICCODERF)
                 && (frePEstFmHead1.HADD_SYSTEMATICNAMERF == frePEstFmHead2.HADD_SYSTEMATICNAMERF)
                 && (frePEstFmHead1.HADD_STPRODUCETYPEOFYEARRF == frePEstFmHead2.HADD_STPRODUCETYPEOFYEARRF)
                 && (frePEstFmHead1.HADD_EDPRODUCETYPEOFYEARRF == frePEstFmHead2.HADD_EDPRODUCETYPEOFYEARRF)
                 && (frePEstFmHead1.HADD_DOORCOUNTRF == frePEstFmHead2.HADD_DOORCOUNTRF)
                 && (frePEstFmHead1.HADD_BODYNAMECODERF == frePEstFmHead2.HADD_BODYNAMECODERF)
                 && (frePEstFmHead1.HADD_BODYNAMERF == frePEstFmHead2.HADD_BODYNAMERF)
                 && (frePEstFmHead1.HADD_STPRODUCEFRAMENORF == frePEstFmHead2.HADD_STPRODUCEFRAMENORF)
                 && (frePEstFmHead1.HADD_EDPRODUCEFRAMENORF == frePEstFmHead2.HADD_EDPRODUCEFRAMENORF)
                 && (frePEstFmHead1.HADD_ENGINEMODELRF == frePEstFmHead2.HADD_ENGINEMODELRF)
                 && (frePEstFmHead1.HADD_MODELGRADENMRF == frePEstFmHead2.HADD_MODELGRADENMRF)
                 && (frePEstFmHead1.HADD_ENGINEDISPLACENMRF == frePEstFmHead2.HADD_ENGINEDISPLACENMRF)
                 && (frePEstFmHead1.HADD_EDIVNMRF == frePEstFmHead2.HADD_EDIVNMRF)
                 && (frePEstFmHead1.HADD_TRANSMISSIONNMRF == frePEstFmHead2.HADD_TRANSMISSIONNMRF)
                 && (frePEstFmHead1.HADD_SHIFTNMRF == frePEstFmHead2.HADD_SHIFTNMRF)
                 && (frePEstFmHead1.HADD_WHEELDRIVEMETHODNMRF == frePEstFmHead2.HADD_WHEELDRIVEMETHODNMRF)
                 && (frePEstFmHead1.HADD_ADDICARSPEC1RF == frePEstFmHead2.HADD_ADDICARSPEC1RF)
                 && (frePEstFmHead1.HADD_ADDICARSPEC2RF == frePEstFmHead2.HADD_ADDICARSPEC2RF)
                 && (frePEstFmHead1.HADD_ADDICARSPEC3RF == frePEstFmHead2.HADD_ADDICARSPEC3RF)
                 && (frePEstFmHead1.HADD_ADDICARSPEC4RF == frePEstFmHead2.HADD_ADDICARSPEC4RF)
                 && (frePEstFmHead1.HADD_ADDICARSPEC5RF == frePEstFmHead2.HADD_ADDICARSPEC5RF)
                 && (frePEstFmHead1.HADD_ADDICARSPEC6RF == frePEstFmHead2.HADD_ADDICARSPEC6RF)
                 && (frePEstFmHead1.HADD_ADDICARSPECTITLE1RF == frePEstFmHead2.HADD_ADDICARSPECTITLE1RF)
                 && (frePEstFmHead1.HADD_ADDICARSPECTITLE2RF == frePEstFmHead2.HADD_ADDICARSPECTITLE2RF)
                 && (frePEstFmHead1.HADD_ADDICARSPECTITLE3RF == frePEstFmHead2.HADD_ADDICARSPECTITLE3RF)
                 && (frePEstFmHead1.HADD_ADDICARSPECTITLE4RF == frePEstFmHead2.HADD_ADDICARSPECTITLE4RF)
                 && (frePEstFmHead1.HADD_ADDICARSPECTITLE5RF == frePEstFmHead2.HADD_ADDICARSPECTITLE5RF)
                 && (frePEstFmHead1.HADD_ADDICARSPECTITLE6RF == frePEstFmHead2.HADD_ADDICARSPECTITLE6RF)
                 && (frePEstFmHead1.HADD_STPRODUCETYPEOFYEARFYRF == frePEstFmHead2.HADD_STPRODUCETYPEOFYEARFYRF)
                 && (frePEstFmHead1.HADD_STPRODUCETYPEOFYEARFSRF == frePEstFmHead2.HADD_STPRODUCETYPEOFYEARFSRF)
                 && (frePEstFmHead1.HADD_STPRODUCETYPEOFYEARFWRF == frePEstFmHead2.HADD_STPRODUCETYPEOFYEARFWRF)
                 && (frePEstFmHead1.HADD_STPRODUCETYPEOFYEARFMRF == frePEstFmHead2.HADD_STPRODUCETYPEOFYEARFMRF)
                 && (frePEstFmHead1.HADD_STPRODUCETYPEOFYEARFGRF == frePEstFmHead2.HADD_STPRODUCETYPEOFYEARFGRF)
                 && (frePEstFmHead1.HADD_STPRODUCETYPEOFYEARFRRF == frePEstFmHead2.HADD_STPRODUCETYPEOFYEARFRRF)
                 && (frePEstFmHead1.HADD_STPRODUCETYPEOFYEARFLSRF == frePEstFmHead2.HADD_STPRODUCETYPEOFYEARFLSRF)
                 && (frePEstFmHead1.HADD_STPRODUCETYPEOFYEARFLPRF == frePEstFmHead2.HADD_STPRODUCETYPEOFYEARFLPRF)
                 && (frePEstFmHead1.HADD_STPRODUCETYPEOFYEARFLYRF == frePEstFmHead2.HADD_STPRODUCETYPEOFYEARFLYRF)
                 && (frePEstFmHead1.HADD_STPRODUCETYPEOFYEARFLMRF == frePEstFmHead2.HADD_STPRODUCETYPEOFYEARFLMRF)
                 && (frePEstFmHead1.HADD_EDPRODUCETYPEOFYEARFYRF == frePEstFmHead2.HADD_EDPRODUCETYPEOFYEARFYRF)
                 && (frePEstFmHead1.HADD_EDPRODUCETYPEOFYEARFSRF == frePEstFmHead2.HADD_EDPRODUCETYPEOFYEARFSRF)
                 && (frePEstFmHead1.HADD_EDPRODUCETYPEOFYEARFWRF == frePEstFmHead2.HADD_EDPRODUCETYPEOFYEARFWRF)
                 && (frePEstFmHead1.HADD_EDPRODUCETYPEOFYEARFMRF == frePEstFmHead2.HADD_EDPRODUCETYPEOFYEARFMRF)
                 && (frePEstFmHead1.HADD_EDPRODUCETYPEOFYEARFGRF == frePEstFmHead2.HADD_EDPRODUCETYPEOFYEARFGRF)
                 && (frePEstFmHead1.HADD_EDPRODUCETYPEOFYEARFRRF == frePEstFmHead2.HADD_EDPRODUCETYPEOFYEARFRRF)
                 && (frePEstFmHead1.HADD_EDPRODUCETYPEOFYEARFLSRF == frePEstFmHead2.HADD_EDPRODUCETYPEOFYEARFLSRF)
                 && (frePEstFmHead1.HADD_EDPRODUCETYPEOFYEARFLPRF == frePEstFmHead2.HADD_EDPRODUCETYPEOFYEARFLPRF)
                 && (frePEstFmHead1.HADD_EDPRODUCETYPEOFYEARFLYRF == frePEstFmHead2.HADD_EDPRODUCETYPEOFYEARFLYRF)
                 && (frePEstFmHead1.HADD_EDPRODUCETYPEOFYEARFLMRF == frePEstFmHead2.HADD_EDPRODUCETYPEOFYEARFLMRF));
        }
        /// <summary>
        /// 自由帳票見積書ヘッダデータ比較処理
        /// </summary>
        /// <param name="target">比較対象のFrePEstFmHeadクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   FrePEstFmHeadクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList Compare( FrePEstFmHead target )
        {
            ArrayList resList = new ArrayList();
            if ( this.SALESSLIPRF_SALESSLIPNUMRF != target.SALESSLIPRF_SALESSLIPNUMRF ) resList.Add( "SALESSLIPRF_SALESSLIPNUMRF" );
            if ( this.SALESSLIPRF_SECTIONCODERF != target.SALESSLIPRF_SECTIONCODERF ) resList.Add( "SALESSLIPRF_SECTIONCODERF" );
            if ( this.SALESSLIPRF_SALESDATERF != target.SALESSLIPRF_SALESDATERF ) resList.Add( "SALESSLIPRF_SALESDATERF" );
            if ( this.SALESSLIPRF_ESTIMATEFORMNORF != target.SALESSLIPRF_ESTIMATEFORMNORF ) resList.Add( "SALESSLIPRF_ESTIMATEFORMNORF" );
            if ( this.SALESSLIPRF_ESTIMATEDIVIDERF != target.SALESSLIPRF_ESTIMATEDIVIDERF ) resList.Add( "SALESSLIPRF_ESTIMATEDIVIDERF" );
            if ( this.SALESSLIPRF_SALESINPUTCODERF != target.SALESSLIPRF_SALESINPUTCODERF ) resList.Add( "SALESSLIPRF_SALESINPUTCODERF" );
            if ( this.SALESSLIPRF_SALESINPUTNAMERF != target.SALESSLIPRF_SALESINPUTNAMERF ) resList.Add( "SALESSLIPRF_SALESINPUTNAMERF" );
            if ( this.SALESSLIPRF_FRONTEMPLOYEECDRF != target.SALESSLIPRF_FRONTEMPLOYEECDRF ) resList.Add( "SALESSLIPRF_FRONTEMPLOYEECDRF" );
            if ( this.SALESSLIPRF_FRONTEMPLOYEENMRF != target.SALESSLIPRF_FRONTEMPLOYEENMRF ) resList.Add( "SALESSLIPRF_FRONTEMPLOYEENMRF" );
            if ( this.SALESSLIPRF_SALESEMPLOYEECDRF != target.SALESSLIPRF_SALESEMPLOYEECDRF ) resList.Add( "SALESSLIPRF_SALESEMPLOYEECDRF" );
            if ( this.SALESSLIPRF_SALESEMPLOYEENMRF != target.SALESSLIPRF_SALESEMPLOYEENMRF ) resList.Add( "SALESSLIPRF_SALESEMPLOYEENMRF" );
            if ( this.SALESSLIPRF_CONSTAXLAYMETHODRF != target.SALESSLIPRF_CONSTAXLAYMETHODRF ) resList.Add( "SALESSLIPRF_CONSTAXLAYMETHODRF" );
            if ( this.SALESSLIPRF_CUSTOMERCODERF != target.SALESSLIPRF_CUSTOMERCODERF ) resList.Add( "SALESSLIPRF_CUSTOMERCODERF" );
            if ( this.SALESSLIPRF_CUSTOMERNAMERF != target.SALESSLIPRF_CUSTOMERNAMERF ) resList.Add( "SALESSLIPRF_CUSTOMERNAMERF" );
            if ( this.SALESSLIPRF_CUSTOMERNAME2RF != target.SALESSLIPRF_CUSTOMERNAME2RF ) resList.Add( "SALESSLIPRF_CUSTOMERNAME2RF" );
            if ( this.SALESSLIPRF_CUSTOMERSNMRF != target.SALESSLIPRF_CUSTOMERSNMRF ) resList.Add( "SALESSLIPRF_CUSTOMERSNMRF" );
            if ( this.SALESSLIPRF_HONORIFICTITLERF != target.SALESSLIPRF_HONORIFICTITLERF ) resList.Add( "SALESSLIPRF_HONORIFICTITLERF" );
            if ( this.SALESSLIPRF_SALESSLIPPRINTDATERF != target.SALESSLIPRF_SALESSLIPPRINTDATERF ) resList.Add( "SALESSLIPRF_SALESSLIPPRINTDATERF" );
            if ( this.SALESSLIPRF_TOTALAMOUNTDISPWAYCDRF != target.SALESSLIPRF_TOTALAMOUNTDISPWAYCDRF ) resList.Add( "SALESSLIPRF_TOTALAMOUNTDISPWAYCDRF" );
            if ( this.SECINFOSETRF_SECTIONGUIDENMRF != target.SECINFOSETRF_SECTIONGUIDENMRF ) resList.Add( "SECINFOSETRF_SECTIONGUIDENMRF" );
            if ( this.COMPANYNMRF_COMPANYPRRF != target.COMPANYNMRF_COMPANYPRRF ) resList.Add( "COMPANYNMRF_COMPANYPRRF" );
            if ( this.COMPANYNMRF_COMPANYNAME1RF != target.COMPANYNMRF_COMPANYNAME1RF ) resList.Add( "COMPANYNMRF_COMPANYNAME1RF" );
            if ( this.COMPANYNMRF_COMPANYNAME2RF != target.COMPANYNMRF_COMPANYNAME2RF ) resList.Add( "COMPANYNMRF_COMPANYNAME2RF" );
            if ( this.COMPANYNMRF_POSTNORF != target.COMPANYNMRF_POSTNORF ) resList.Add( "COMPANYNMRF_POSTNORF" );
            if ( this.COMPANYNMRF_ADDRESS1RF != target.COMPANYNMRF_ADDRESS1RF ) resList.Add( "COMPANYNMRF_ADDRESS1RF" );
            if ( this.COMPANYNMRF_ADDRESS3RF != target.COMPANYNMRF_ADDRESS3RF ) resList.Add( "COMPANYNMRF_ADDRESS3RF" );
            if ( this.COMPANYNMRF_ADDRESS4RF != target.COMPANYNMRF_ADDRESS4RF ) resList.Add( "COMPANYNMRF_ADDRESS4RF" );
            if ( this.COMPANYNMRF_COMPANYTELNO1RF != target.COMPANYNMRF_COMPANYTELNO1RF ) resList.Add( "COMPANYNMRF_COMPANYTELNO1RF" );
            if ( this.COMPANYNMRF_COMPANYTELNO2RF != target.COMPANYNMRF_COMPANYTELNO2RF ) resList.Add( "COMPANYNMRF_COMPANYTELNO2RF" );
            if ( this.COMPANYNMRF_COMPANYTELNO3RF != target.COMPANYNMRF_COMPANYTELNO3RF ) resList.Add( "COMPANYNMRF_COMPANYTELNO3RF" );
            if ( this.COMPANYNMRF_COMPANYTELTITLE1RF != target.COMPANYNMRF_COMPANYTELTITLE1RF ) resList.Add( "COMPANYNMRF_COMPANYTELTITLE1RF" );
            if ( this.COMPANYNMRF_COMPANYTELTITLE2RF != target.COMPANYNMRF_COMPANYTELTITLE2RF ) resList.Add( "COMPANYNMRF_COMPANYTELTITLE2RF" );
            if ( this.COMPANYNMRF_COMPANYTELTITLE3RF != target.COMPANYNMRF_COMPANYTELTITLE3RF ) resList.Add( "COMPANYNMRF_COMPANYTELTITLE3RF" );
            if ( this.COMPANYNMRF_TRANSFERGUIDANCERF != target.COMPANYNMRF_TRANSFERGUIDANCERF ) resList.Add( "COMPANYNMRF_TRANSFERGUIDANCERF" );
            if ( this.COMPANYNMRF_ACCOUNTNOINFO1RF != target.COMPANYNMRF_ACCOUNTNOINFO1RF ) resList.Add( "COMPANYNMRF_ACCOUNTNOINFO1RF" );
            if ( this.COMPANYNMRF_ACCOUNTNOINFO2RF != target.COMPANYNMRF_ACCOUNTNOINFO2RF ) resList.Add( "COMPANYNMRF_ACCOUNTNOINFO2RF" );
            if ( this.COMPANYNMRF_ACCOUNTNOINFO3RF != target.COMPANYNMRF_ACCOUNTNOINFO3RF ) resList.Add( "COMPANYNMRF_ACCOUNTNOINFO3RF" );
            if ( this.COMPANYNMRF_COMPANYSETNOTE1RF != target.COMPANYNMRF_COMPANYSETNOTE1RF ) resList.Add( "COMPANYNMRF_COMPANYSETNOTE1RF" );
            if ( this.COMPANYNMRF_COMPANYSETNOTE2RF != target.COMPANYNMRF_COMPANYSETNOTE2RF ) resList.Add( "COMPANYNMRF_COMPANYSETNOTE2RF" );
            if ( this.COMPANYNMRF_COMPANYURLRF != target.COMPANYNMRF_COMPANYURLRF ) resList.Add( "COMPANYNMRF_COMPANYURLRF" );
            if ( this.COMPANYNMRF_COMPANYPRSENTENCE2RF != target.COMPANYNMRF_COMPANYPRSENTENCE2RF ) resList.Add( "COMPANYNMRF_COMPANYPRSENTENCE2RF" );
            if ( this.COMPANYNMRF_IMAGECOMMENTFORPRT1RF != target.COMPANYNMRF_IMAGECOMMENTFORPRT1RF ) resList.Add( "COMPANYNMRF_IMAGECOMMENTFORPRT1RF" );
            if ( this.COMPANYNMRF_IMAGECOMMENTFORPRT2RF != target.COMPANYNMRF_IMAGECOMMENTFORPRT2RF ) resList.Add( "COMPANYNMRF_IMAGECOMMENTFORPRT2RF" );
            if ( this.IMAGEINFORF_IMAGEINFODATARF != target.IMAGEINFORF_IMAGEINFODATARF ) resList.Add( "IMAGEINFORF_IMAGEINFODATARF" );
            if ( this.COMPANYINFRF_COMPANYNAME1RF != target.COMPANYINFRF_COMPANYNAME1RF ) resList.Add( "COMPANYINFRF_COMPANYNAME1RF" );
            if ( this.COMPANYINFRF_COMPANYNAME2RF != target.COMPANYINFRF_COMPANYNAME2RF ) resList.Add( "COMPANYINFRF_COMPANYNAME2RF" );
            if ( this.COMPANYINFRF_POSTNORF != target.COMPANYINFRF_POSTNORF ) resList.Add( "COMPANYINFRF_POSTNORF" );
            if ( this.COMPANYINFRF_ADDRESS1RF != target.COMPANYINFRF_ADDRESS1RF ) resList.Add( "COMPANYINFRF_ADDRESS1RF" );
            if ( this.COMPANYINFRF_ADDRESS3RF != target.COMPANYINFRF_ADDRESS3RF ) resList.Add( "COMPANYINFRF_ADDRESS3RF" );
            if ( this.COMPANYINFRF_ADDRESS4RF != target.COMPANYINFRF_ADDRESS4RF ) resList.Add( "COMPANYINFRF_ADDRESS4RF" );
            if ( this.COMPANYINFRF_COMPANYTELNO1RF != target.COMPANYINFRF_COMPANYTELNO1RF ) resList.Add( "COMPANYINFRF_COMPANYTELNO1RF" );
            if ( this.COMPANYINFRF_COMPANYTELNO2RF != target.COMPANYINFRF_COMPANYTELNO2RF ) resList.Add( "COMPANYINFRF_COMPANYTELNO2RF" );
            if ( this.COMPANYINFRF_COMPANYTELNO3RF != target.COMPANYINFRF_COMPANYTELNO3RF ) resList.Add( "COMPANYINFRF_COMPANYTELNO3RF" );
            if ( this.COMPANYINFRF_COMPANYTELTITLE1RF != target.COMPANYINFRF_COMPANYTELTITLE1RF ) resList.Add( "COMPANYINFRF_COMPANYTELTITLE1RF" );
            if ( this.COMPANYINFRF_COMPANYTELTITLE2RF != target.COMPANYINFRF_COMPANYTELTITLE2RF ) resList.Add( "COMPANYINFRF_COMPANYTELTITLE2RF" );
            if ( this.COMPANYINFRF_COMPANYTELTITLE3RF != target.COMPANYINFRF_COMPANYTELTITLE3RF ) resList.Add( "COMPANYINFRF_COMPANYTELTITLE3RF" );
            if ( this.HEST_FOOTNOTES1RF != target.HEST_FOOTNOTES1RF ) resList.Add( "HEST_FOOTNOTES1RF" );
            if ( this.HEST_FOOTNOTES2RF != target.HEST_FOOTNOTES2RF ) resList.Add( "HEST_FOOTNOTES2RF" );
            if ( this.HEST_ESTIMATETITLE1RF != target.HEST_ESTIMATETITLE1RF ) resList.Add( "HEST_ESTIMATETITLE1RF" );
            if ( this.HEST_ESTIMATETITLE2RF != target.HEST_ESTIMATETITLE2RF ) resList.Add( "HEST_ESTIMATETITLE2RF" );
            if ( this.HEST_ESTIMATETITLE3RF != target.HEST_ESTIMATETITLE3RF ) resList.Add( "HEST_ESTIMATETITLE3RF" );
            if ( this.HEST_ESTIMATETITLE4RF != target.HEST_ESTIMATETITLE4RF ) resList.Add( "HEST_ESTIMATETITLE4RF" );
            if ( this.HEST_ESTIMATETITLE5RF != target.HEST_ESTIMATETITLE5RF ) resList.Add( "HEST_ESTIMATETITLE5RF" );
            if ( this.HEST_ESTIMATENOTE1RF != target.HEST_ESTIMATENOTE1RF ) resList.Add( "HEST_ESTIMATENOTE1RF" );
            if ( this.HEST_ESTIMATENOTE2RF != target.HEST_ESTIMATENOTE2RF ) resList.Add( "HEST_ESTIMATENOTE2RF" );
            if ( this.HEST_ESTIMATENOTE3RF != target.HEST_ESTIMATENOTE3RF ) resList.Add( "HEST_ESTIMATENOTE3RF" );
            if ( this.HEST_ESTIMATENOTE4RF != target.HEST_ESTIMATENOTE4RF ) resList.Add( "HEST_ESTIMATENOTE4RF" );
            if ( this.HEST_ESTIMATENOTE5RF != target.HEST_ESTIMATENOTE5RF ) resList.Add( "HEST_ESTIMATENOTE5RF" );
            if ( this.HEST_ESTIMATEVALIDITYLIMITRF != target.HEST_ESTIMATEVALIDITYLIMITRF ) resList.Add( "HEST_ESTIMATEVALIDITYLIMITRF" );
            if ( this.HEST_ESTIMATEVALIDITYLIMITFYRF != target.HEST_ESTIMATEVALIDITYLIMITFYRF ) resList.Add( "HEST_ESTIMATEVALIDITYLIMITFYRF" );
            if ( this.HEST_ESTIMATEVALIDITYLIMITFSRF != target.HEST_ESTIMATEVALIDITYLIMITFSRF ) resList.Add( "HEST_ESTIMATEVALIDITYLIMITFSRF" );
            if ( this.HEST_ESTIMATEVALIDITYLIMITFWRF != target.HEST_ESTIMATEVALIDITYLIMITFWRF ) resList.Add( "HEST_ESTIMATEVALIDITYLIMITFWRF" );
            if ( this.HEST_ESTIMATEVALIDITYLIMITFMRF != target.HEST_ESTIMATEVALIDITYLIMITFMRF ) resList.Add( "HEST_ESTIMATEVALIDITYLIMITFMRF" );
            if ( this.HEST_ESTIMATEVALIDITYLIMITFDRF != target.HEST_ESTIMATEVALIDITYLIMITFDRF ) resList.Add( "HEST_ESTIMATEVALIDITYLIMITFDRF" );
            if ( this.HEST_ESTIMATEVALIDITYLIMITFGRF != target.HEST_ESTIMATEVALIDITYLIMITFGRF ) resList.Add( "HEST_ESTIMATEVALIDITYLIMITFGRF" );
            if ( this.HEST_ESTIMATEVALIDITYLIMITFRRF != target.HEST_ESTIMATEVALIDITYLIMITFRRF ) resList.Add( "HEST_ESTIMATEVALIDITYLIMITFRRF" );
            if ( this.HEST_ESTIMATEVALIDITYLIMITFLSRF != target.HEST_ESTIMATEVALIDITYLIMITFLSRF ) resList.Add( "HEST_ESTIMATEVALIDITYLIMITFLSRF" );
            if ( this.HEST_ESTIMATEVALIDITYLIMITFLPRF != target.HEST_ESTIMATEVALIDITYLIMITFLPRF ) resList.Add( "HEST_ESTIMATEVALIDITYLIMITFLPRF" );
            if ( this.HEST_ESTIMATEVALIDITYLIMITFLYRF != target.HEST_ESTIMATEVALIDITYLIMITFLYRF ) resList.Add( "HEST_ESTIMATEVALIDITYLIMITFLYRF" );
            if ( this.HEST_ESTIMATEVALIDITYLIMITFLMRF != target.HEST_ESTIMATEVALIDITYLIMITFLMRF ) resList.Add( "HEST_ESTIMATEVALIDITYLIMITFLMRF" );
            if ( this.HEST_ESTIMATEVALIDITYLIMITFLDRF != target.HEST_ESTIMATEVALIDITYLIMITFLDRF ) resList.Add( "HEST_ESTIMATEVALIDITYLIMITFLDRF" );
            if ( this.HADD_CARMNGNORF != target.HADD_CARMNGNORF ) resList.Add( "HADD_CARMNGNORF" );
            if ( this.HADD_CARMNGCODERF != target.HADD_CARMNGCODERF ) resList.Add( "HADD_CARMNGCODERF" );
            if ( this.HADD_NUMBERPLATE1CODERF != target.HADD_NUMBERPLATE1CODERF ) resList.Add( "HADD_NUMBERPLATE1CODERF" );
            if ( this.HADD_NUMBERPLATE1NAMERF != target.HADD_NUMBERPLATE1NAMERF ) resList.Add( "HADD_NUMBERPLATE1NAMERF" );
            if ( this.HADD_NUMBERPLATE2RF != target.HADD_NUMBERPLATE2RF ) resList.Add( "HADD_NUMBERPLATE2RF" );
            if ( this.HADD_NUMBERPLATE3RF != target.HADD_NUMBERPLATE3RF ) resList.Add( "HADD_NUMBERPLATE3RF" );
            if ( this.HADD_NUMBERPLATE4RF != target.HADD_NUMBERPLATE4RF ) resList.Add( "HADD_NUMBERPLATE4RF" );
            if ( this.HADD_FIRSTENTRYDATERF != target.HADD_FIRSTENTRYDATERF ) resList.Add( "HADD_FIRSTENTRYDATERF" );
            if ( this.HADD_MAKERCODERF != target.HADD_MAKERCODERF ) resList.Add( "HADD_MAKERCODERF" );
            if ( this.HADD_MAKERFULLNAMERF != target.HADD_MAKERFULLNAMERF ) resList.Add( "HADD_MAKERFULLNAMERF" );
            if ( this.HADD_MAKERHALFNAMERF != target.HADD_MAKERHALFNAMERF ) resList.Add( "HADD_MAKERHALFNAMERF" );
            if ( this.HADD_MODELCODERF != target.HADD_MODELCODERF ) resList.Add( "HADD_MODELCODERF" );
            if ( this.HADD_MODELSUBCODERF != target.HADD_MODELSUBCODERF ) resList.Add( "HADD_MODELSUBCODERF" );
            if ( this.HADD_MODELFULLNAMERF != target.HADD_MODELFULLNAMERF ) resList.Add( "HADD_MODELFULLNAMERF" );
            if ( this.HADD_MODELHALFNAMERF != target.HADD_MODELHALFNAMERF ) resList.Add( "HADD_MODELHALFNAMERF" );
            if ( this.HADD_EXHAUSTGASSIGNRF != target.HADD_EXHAUSTGASSIGNRF ) resList.Add( "HADD_EXHAUSTGASSIGNRF" );
            if ( this.HADD_SERIESMODELRF != target.HADD_SERIESMODELRF ) resList.Add( "HADD_SERIESMODELRF" );
            if ( this.HADD_CATEGORYSIGNMODELRF != target.HADD_CATEGORYSIGNMODELRF ) resList.Add( "HADD_CATEGORYSIGNMODELRF" );
            if ( this.HADD_FULLMODELRF != target.HADD_FULLMODELRF ) resList.Add( "HADD_FULLMODELRF" );
            if ( this.HADD_MODELDESIGNATIONNORF != target.HADD_MODELDESIGNATIONNORF ) resList.Add( "HADD_MODELDESIGNATIONNORF" );
            if ( this.HADD_CATEGORYNORF != target.HADD_CATEGORYNORF ) resList.Add( "HADD_CATEGORYNORF" );
            if ( this.HADD_FRAMEMODELRF != target.HADD_FRAMEMODELRF ) resList.Add( "HADD_FRAMEMODELRF" );
            if ( this.HADD_FRAMENORF != target.HADD_FRAMENORF ) resList.Add( "HADD_FRAMENORF" );
            if ( this.HADD_SEARCHFRAMENORF != target.HADD_SEARCHFRAMENORF ) resList.Add( "HADD_SEARCHFRAMENORF" );
            if ( this.HADD_ENGINEMODELNMRF != target.HADD_ENGINEMODELNMRF ) resList.Add( "HADD_ENGINEMODELNMRF" );
            if ( this.HADD_RELEVANCEMODELRF != target.HADD_RELEVANCEMODELRF ) resList.Add( "HADD_RELEVANCEMODELRF" );
            if ( this.HADD_SUBCARNMCDRF != target.HADD_SUBCARNMCDRF ) resList.Add( "HADD_SUBCARNMCDRF" );
            if ( this.HADD_MODELGRADESNAMERF != target.HADD_MODELGRADESNAMERF ) resList.Add( "HADD_MODELGRADESNAMERF" );
            if ( this.HADD_COLORCODERF != target.HADD_COLORCODERF ) resList.Add( "HADD_COLORCODERF" );
            if ( this.HADD_COLORNAME1RF != target.HADD_COLORNAME1RF ) resList.Add( "HADD_COLORNAME1RF" );
            if ( this.HADD_TRIMCODERF != target.HADD_TRIMCODERF ) resList.Add( "HADD_TRIMCODERF" );
            if ( this.HADD_TRIMNAMERF != target.HADD_TRIMNAMERF ) resList.Add( "HADD_TRIMNAMERF" );
            if ( this.HADD_MILEAGERF != target.HADD_MILEAGERF ) resList.Add( "HADD_MILEAGERF" );
            if ( this.HADD_PRINTERMNGNORF != target.HADD_PRINTERMNGNORF ) resList.Add( "HADD_PRINTERMNGNORF" );
            if ( this.HADD_SLIPPRTSETPAPERIDRF != target.HADD_SLIPPRTSETPAPERIDRF ) resList.Add( "HADD_SLIPPRTSETPAPERIDRF" );
            if ( this.HADD_NOTE1RF != target.HADD_NOTE1RF ) resList.Add( "HADD_NOTE1RF" );
            if ( this.HADD_NOTE2RF != target.HADD_NOTE2RF ) resList.Add( "HADD_NOTE2RF" );
            if ( this.HADD_NOTE3RF != target.HADD_NOTE3RF ) resList.Add( "HADD_NOTE3RF" );
            if ( this.HADD_FIRSTENTRYDATEFYRF != target.HADD_FIRSTENTRYDATEFYRF ) resList.Add( "HADD_FIRSTENTRYDATEFYRF" );
            if ( this.HADD_FIRSTENTRYDATEFSRF != target.HADD_FIRSTENTRYDATEFSRF ) resList.Add( "HADD_FIRSTENTRYDATEFSRF" );
            if ( this.HADD_FIRSTENTRYDATEFWRF != target.HADD_FIRSTENTRYDATEFWRF ) resList.Add( "HADD_FIRSTENTRYDATEFWRF" );
            if ( this.HADD_FIRSTENTRYDATEFMRF != target.HADD_FIRSTENTRYDATEFMRF ) resList.Add( "HADD_FIRSTENTRYDATEFMRF" );
            if ( this.HADD_FIRSTENTRYDATEFGRF != target.HADD_FIRSTENTRYDATEFGRF ) resList.Add( "HADD_FIRSTENTRYDATEFGRF" );
            if ( this.HADD_FIRSTENTRYDATEFRRF != target.HADD_FIRSTENTRYDATEFRRF ) resList.Add( "HADD_FIRSTENTRYDATEFRRF" );
            if ( this.HADD_FIRSTENTRYDATEFLSRF != target.HADD_FIRSTENTRYDATEFLSRF ) resList.Add( "HADD_FIRSTENTRYDATEFLSRF" );
            if ( this.HADD_FIRSTENTRYDATEFLPRF != target.HADD_FIRSTENTRYDATEFLPRF ) resList.Add( "HADD_FIRSTENTRYDATEFLPRF" );
            if ( this.HADD_FIRSTENTRYDATEFLYRF != target.HADD_FIRSTENTRYDATEFLYRF ) resList.Add( "HADD_FIRSTENTRYDATEFLYRF" );
            if ( this.HADD_FIRSTENTRYDATEFLMRF != target.HADD_FIRSTENTRYDATEFLMRF ) resList.Add( "HADD_FIRSTENTRYDATEFLMRF" );
            if ( this.HADD_PRINTCUSTOMERNM1RF != target.HADD_PRINTCUSTOMERNM1RF ) resList.Add( "HADD_PRINTCUSTOMERNM1RF" );
            if ( this.HADD_PRINTCUSTOMERNM2RF != target.HADD_PRINTCUSTOMERNM2RF ) resList.Add( "HADD_PRINTCUSTOMERNM2RF" );
            if ( this.HPURE_SALESTOTALTAXINCRF != target.HPURE_SALESTOTALTAXINCRF ) resList.Add( "HPURE_SALESTOTALTAXINCRF" );
            if ( this.HPURE_SALESTOTALTAXEXCRF != target.HPURE_SALESTOTALTAXEXCRF ) resList.Add( "HPURE_SALESTOTALTAXEXCRF" );
            if ( this.HPURE_SALESSUBTOTALTAXINCRF != target.HPURE_SALESSUBTOTALTAXINCRF ) resList.Add( "HPURE_SALESSUBTOTALTAXINCRF" );
            if ( this.HPURE_SALESSUBTOTALTAXEXCRF != target.HPURE_SALESSUBTOTALTAXEXCRF ) resList.Add( "HPURE_SALESSUBTOTALTAXEXCRF" );
            if ( this.HPURE_SALESSUBTOTALTAXRF != target.HPURE_SALESSUBTOTALTAXRF ) resList.Add( "HPURE_SALESSUBTOTALTAXRF" );
            if ( this.HPRIME_SALESTOTALTAXINCRF != target.HPRIME_SALESTOTALTAXINCRF ) resList.Add( "HPRIME_SALESTOTALTAXINCRF" );
            if ( this.HPRIME_SALESTOTALTAXEXCRF != target.HPRIME_SALESTOTALTAXEXCRF ) resList.Add( "HPRIME_SALESTOTALTAXEXCRF" );
            if ( this.HPRIME_SALESSUBTOTALTAXINCRF != target.HPRIME_SALESSUBTOTALTAXINCRF ) resList.Add( "HPRIME_SALESSUBTOTALTAXINCRF" );
            if ( this.HPRIME_SALESSUBTOTALTAXEXCRF != target.HPRIME_SALESSUBTOTALTAXEXCRF ) resList.Add( "HPRIME_SALESSUBTOTALTAXEXCRF" );
            if ( this.HPRIME_SALESSUBTOTALTAXRF != target.HPRIME_SALESSUBTOTALTAXRF ) resList.Add( "HPRIME_SALESSUBTOTALTAXRF" );
            if ( this.HADD_PRINTTIMEHOURRF != target.HADD_PRINTTIMEHOURRF ) resList.Add( "HADD_PRINTTIMEHOURRF" );
            if ( this.HADD_PRINTTIMEMINUTERF != target.HADD_PRINTTIMEMINUTERF ) resList.Add( "HADD_PRINTTIMEMINUTERF" );
            if ( this.HADD_PRINTTIMESECONDRF != target.HADD_PRINTTIMESECONDRF ) resList.Add( "HADD_PRINTTIMESECONDRF" );
            if ( this.HADD_ESTFMDIVRF != target.HADD_ESTFMDIVRF ) resList.Add( "HADD_ESTFMDIVRF" );
            if ( this.HADD_SALESDATEFYRF != target.HADD_SALESDATEFYRF ) resList.Add( "HADD_SALESDATEFYRF" );
            if ( this.HADD_SALESDATEFSRF != target.HADD_SALESDATEFSRF ) resList.Add( "HADD_SALESDATEFSRF" );
            if ( this.HADD_SALESDATEFWRF != target.HADD_SALESDATEFWRF ) resList.Add( "HADD_SALESDATEFWRF" );
            if ( this.HADD_SALESDATEFMRF != target.HADD_SALESDATEFMRF ) resList.Add( "HADD_SALESDATEFMRF" );
            if ( this.HADD_SALESDATEFDRF != target.HADD_SALESDATEFDRF ) resList.Add( "HADD_SALESDATEFDRF" );
            if ( this.HADD_SALESDATEFGRF != target.HADD_SALESDATEFGRF ) resList.Add( "HADD_SALESDATEFGRF" );
            if ( this.HADD_SALESDATEFRRF != target.HADD_SALESDATEFRRF ) resList.Add( "HADD_SALESDATEFRRF" );
            if ( this.HADD_SALESDATEFLSRF != target.HADD_SALESDATEFLSRF ) resList.Add( "HADD_SALESDATEFLSRF" );
            if ( this.HADD_SALESDATEFLPRF != target.HADD_SALESDATEFLPRF ) resList.Add( "HADD_SALESDATEFLPRF" );
            if ( this.HADD_SALESDATEFLYRF != target.HADD_SALESDATEFLYRF ) resList.Add( "HADD_SALESDATEFLYRF" );
            if ( this.HADD_SALESDATEFLMRF != target.HADD_SALESDATEFLMRF ) resList.Add( "HADD_SALESDATEFLMRF" );
            if ( this.HADD_SALESDATEFLDRF != target.HADD_SALESDATEFLDRF ) resList.Add( "HADD_SALESDATEFLDRF" );
            if ( this.HADD_SALESSLIPPRINTDATEFYRF != target.HADD_SALESSLIPPRINTDATEFYRF ) resList.Add( "HADD_SALESSLIPPRINTDATEFYRF" );
            if ( this.HADD_SALESSLIPPRINTDATEFSRF != target.HADD_SALESSLIPPRINTDATEFSRF ) resList.Add( "HADD_SALESSLIPPRINTDATEFSRF" );
            if ( this.HADD_SALESSLIPPRINTDATEFWRF != target.HADD_SALESSLIPPRINTDATEFWRF ) resList.Add( "HADD_SALESSLIPPRINTDATEFWRF" );
            if ( this.HADD_SALESSLIPPRINTDATEFMRF != target.HADD_SALESSLIPPRINTDATEFMRF ) resList.Add( "HADD_SALESSLIPPRINTDATEFMRF" );
            if ( this.HADD_SALESSLIPPRINTDATEFDRF != target.HADD_SALESSLIPPRINTDATEFDRF ) resList.Add( "HADD_SALESSLIPPRINTDATEFDRF" );
            if ( this.HADD_SALESSLIPPRINTDATEFGRF != target.HADD_SALESSLIPPRINTDATEFGRF ) resList.Add( "HADD_SALESSLIPPRINTDATEFGRF" );
            if ( this.HADD_SALESSLIPPRINTDATEFRRF != target.HADD_SALESSLIPPRINTDATEFRRF ) resList.Add( "HADD_SALESSLIPPRINTDATEFRRF" );
            if ( this.HADD_SALESSLIPPRINTDATEFLSRF != target.HADD_SALESSLIPPRINTDATEFLSRF ) resList.Add( "HADD_SALESSLIPPRINTDATEFLSRF" );
            if ( this.HADD_SALESSLIPPRINTDATEFLPRF != target.HADD_SALESSLIPPRINTDATEFLPRF ) resList.Add( "HADD_SALESSLIPPRINTDATEFLPRF" );
            if ( this.HADD_SALESSLIPPRINTDATEFLYRF != target.HADD_SALESSLIPPRINTDATEFLYRF ) resList.Add( "HADD_SALESSLIPPRINTDATEFLYRF" );
            if ( this.HADD_SALESSLIPPRINTDATEFLMRF != target.HADD_SALESSLIPPRINTDATEFLMRF ) resList.Add( "HADD_SALESSLIPPRINTDATEFLMRF" );
            if ( this.HADD_SALESSLIPPRINTDATEFLDRF != target.HADD_SALESSLIPPRINTDATEFLDRF ) resList.Add( "HADD_SALESSLIPPRINTDATEFLDRF" );
            if ( this.HADD_SYSTEMATICCODERF != target.HADD_SYSTEMATICCODERF ) resList.Add( "HADD_SYSTEMATICCODERF" );
            if ( this.HADD_SYSTEMATICNAMERF != target.HADD_SYSTEMATICNAMERF ) resList.Add( "HADD_SYSTEMATICNAMERF" );
            if ( this.HADD_STPRODUCETYPEOFYEARRF != target.HADD_STPRODUCETYPEOFYEARRF ) resList.Add( "HADD_STPRODUCETYPEOFYEARRF" );
            if ( this.HADD_EDPRODUCETYPEOFYEARRF != target.HADD_EDPRODUCETYPEOFYEARRF ) resList.Add( "HADD_EDPRODUCETYPEOFYEARRF" );
            if ( this.HADD_DOORCOUNTRF != target.HADD_DOORCOUNTRF ) resList.Add( "HADD_DOORCOUNTRF" );
            if ( this.HADD_BODYNAMECODERF != target.HADD_BODYNAMECODERF ) resList.Add( "HADD_BODYNAMECODERF" );
            if ( this.HADD_BODYNAMERF != target.HADD_BODYNAMERF ) resList.Add( "HADD_BODYNAMERF" );
            if ( this.HADD_STPRODUCEFRAMENORF != target.HADD_STPRODUCEFRAMENORF ) resList.Add( "HADD_STPRODUCEFRAMENORF" );
            if ( this.HADD_EDPRODUCEFRAMENORF != target.HADD_EDPRODUCEFRAMENORF ) resList.Add( "HADD_EDPRODUCEFRAMENORF" );
            if ( this.HADD_ENGINEMODELRF != target.HADD_ENGINEMODELRF ) resList.Add( "HADD_ENGINEMODELRF" );
            if ( this.HADD_MODELGRADENMRF != target.HADD_MODELGRADENMRF ) resList.Add( "HADD_MODELGRADENMRF" );
            if ( this.HADD_ENGINEDISPLACENMRF != target.HADD_ENGINEDISPLACENMRF ) resList.Add( "HADD_ENGINEDISPLACENMRF" );
            if ( this.HADD_EDIVNMRF != target.HADD_EDIVNMRF ) resList.Add( "HADD_EDIVNMRF" );
            if ( this.HADD_TRANSMISSIONNMRF != target.HADD_TRANSMISSIONNMRF ) resList.Add( "HADD_TRANSMISSIONNMRF" );
            if ( this.HADD_SHIFTNMRF != target.HADD_SHIFTNMRF ) resList.Add( "HADD_SHIFTNMRF" );
            if ( this.HADD_WHEELDRIVEMETHODNMRF != target.HADD_WHEELDRIVEMETHODNMRF ) resList.Add( "HADD_WHEELDRIVEMETHODNMRF" );
            if ( this.HADD_ADDICARSPEC1RF != target.HADD_ADDICARSPEC1RF ) resList.Add( "HADD_ADDICARSPEC1RF" );
            if ( this.HADD_ADDICARSPEC2RF != target.HADD_ADDICARSPEC2RF ) resList.Add( "HADD_ADDICARSPEC2RF" );
            if ( this.HADD_ADDICARSPEC3RF != target.HADD_ADDICARSPEC3RF ) resList.Add( "HADD_ADDICARSPEC3RF" );
            if ( this.HADD_ADDICARSPEC4RF != target.HADD_ADDICARSPEC4RF ) resList.Add( "HADD_ADDICARSPEC4RF" );
            if ( this.HADD_ADDICARSPEC5RF != target.HADD_ADDICARSPEC5RF ) resList.Add( "HADD_ADDICARSPEC5RF" );
            if ( this.HADD_ADDICARSPEC6RF != target.HADD_ADDICARSPEC6RF ) resList.Add( "HADD_ADDICARSPEC6RF" );
            if ( this.HADD_ADDICARSPECTITLE1RF != target.HADD_ADDICARSPECTITLE1RF ) resList.Add( "HADD_ADDICARSPECTITLE1RF" );
            if ( this.HADD_ADDICARSPECTITLE2RF != target.HADD_ADDICARSPECTITLE2RF ) resList.Add( "HADD_ADDICARSPECTITLE2RF" );
            if ( this.HADD_ADDICARSPECTITLE3RF != target.HADD_ADDICARSPECTITLE3RF ) resList.Add( "HADD_ADDICARSPECTITLE3RF" );
            if ( this.HADD_ADDICARSPECTITLE4RF != target.HADD_ADDICARSPECTITLE4RF ) resList.Add( "HADD_ADDICARSPECTITLE4RF" );
            if ( this.HADD_ADDICARSPECTITLE5RF != target.HADD_ADDICARSPECTITLE5RF ) resList.Add( "HADD_ADDICARSPECTITLE5RF" );
            if ( this.HADD_ADDICARSPECTITLE6RF != target.HADD_ADDICARSPECTITLE6RF ) resList.Add( "HADD_ADDICARSPECTITLE6RF" );
            if ( this.HADD_STPRODUCETYPEOFYEARFYRF != target.HADD_STPRODUCETYPEOFYEARFYRF ) resList.Add( "HADD_STPRODUCETYPEOFYEARFYRF" );
            if ( this.HADD_STPRODUCETYPEOFYEARFSRF != target.HADD_STPRODUCETYPEOFYEARFSRF ) resList.Add( "HADD_STPRODUCETYPEOFYEARFSRF" );
            if ( this.HADD_STPRODUCETYPEOFYEARFWRF != target.HADD_STPRODUCETYPEOFYEARFWRF ) resList.Add( "HADD_STPRODUCETYPEOFYEARFWRF" );
            if ( this.HADD_STPRODUCETYPEOFYEARFMRF != target.HADD_STPRODUCETYPEOFYEARFMRF ) resList.Add( "HADD_STPRODUCETYPEOFYEARFMRF" );
            if ( this.HADD_STPRODUCETYPEOFYEARFGRF != target.HADD_STPRODUCETYPEOFYEARFGRF ) resList.Add( "HADD_STPRODUCETYPEOFYEARFGRF" );
            if ( this.HADD_STPRODUCETYPEOFYEARFRRF != target.HADD_STPRODUCETYPEOFYEARFRRF ) resList.Add( "HADD_STPRODUCETYPEOFYEARFRRF" );
            if ( this.HADD_STPRODUCETYPEOFYEARFLSRF != target.HADD_STPRODUCETYPEOFYEARFLSRF ) resList.Add( "HADD_STPRODUCETYPEOFYEARFLSRF" );
            if ( this.HADD_STPRODUCETYPEOFYEARFLPRF != target.HADD_STPRODUCETYPEOFYEARFLPRF ) resList.Add( "HADD_STPRODUCETYPEOFYEARFLPRF" );
            if ( this.HADD_STPRODUCETYPEOFYEARFLYRF != target.HADD_STPRODUCETYPEOFYEARFLYRF ) resList.Add( "HADD_STPRODUCETYPEOFYEARFLYRF" );
            if ( this.HADD_STPRODUCETYPEOFYEARFLMRF != target.HADD_STPRODUCETYPEOFYEARFLMRF ) resList.Add( "HADD_STPRODUCETYPEOFYEARFLMRF" );
            if ( this.HADD_EDPRODUCETYPEOFYEARFYRF != target.HADD_EDPRODUCETYPEOFYEARFYRF ) resList.Add( "HADD_EDPRODUCETYPEOFYEARFYRF" );
            if ( this.HADD_EDPRODUCETYPEOFYEARFSRF != target.HADD_EDPRODUCETYPEOFYEARFSRF ) resList.Add( "HADD_EDPRODUCETYPEOFYEARFSRF" );
            if ( this.HADD_EDPRODUCETYPEOFYEARFWRF != target.HADD_EDPRODUCETYPEOFYEARFWRF ) resList.Add( "HADD_EDPRODUCETYPEOFYEARFWRF" );
            if ( this.HADD_EDPRODUCETYPEOFYEARFMRF != target.HADD_EDPRODUCETYPEOFYEARFMRF ) resList.Add( "HADD_EDPRODUCETYPEOFYEARFMRF" );
            if ( this.HADD_EDPRODUCETYPEOFYEARFGRF != target.HADD_EDPRODUCETYPEOFYEARFGRF ) resList.Add( "HADD_EDPRODUCETYPEOFYEARFGRF" );
            if ( this.HADD_EDPRODUCETYPEOFYEARFRRF != target.HADD_EDPRODUCETYPEOFYEARFRRF ) resList.Add( "HADD_EDPRODUCETYPEOFYEARFRRF" );
            if ( this.HADD_EDPRODUCETYPEOFYEARFLSRF != target.HADD_EDPRODUCETYPEOFYEARFLSRF ) resList.Add( "HADD_EDPRODUCETYPEOFYEARFLSRF" );
            if ( this.HADD_EDPRODUCETYPEOFYEARFLPRF != target.HADD_EDPRODUCETYPEOFYEARFLPRF ) resList.Add( "HADD_EDPRODUCETYPEOFYEARFLPRF" );
            if ( this.HADD_EDPRODUCETYPEOFYEARFLYRF != target.HADD_EDPRODUCETYPEOFYEARFLYRF ) resList.Add( "HADD_EDPRODUCETYPEOFYEARFLYRF" );
            if ( this.HADD_EDPRODUCETYPEOFYEARFLMRF != target.HADD_EDPRODUCETYPEOFYEARFLMRF ) resList.Add( "HADD_EDPRODUCETYPEOFYEARFLMRF" );

            return resList;
        }

        /// <summary>
        /// 自由帳票見積書ヘッダデータ比較処理
        /// </summary>
        /// <param name="frePEstFmHead1">比較するFrePEstFmHeadクラスのインスタンス</param>
        /// <param name="frePEstFmHead2">比較するFrePEstFmHeadクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   FrePEstFmHeadクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static ArrayList Compare( FrePEstFmHead frePEstFmHead1, FrePEstFmHead frePEstFmHead2 )
        {
            ArrayList resList = new ArrayList();
            if ( frePEstFmHead1.SALESSLIPRF_SALESSLIPNUMRF != frePEstFmHead2.SALESSLIPRF_SALESSLIPNUMRF ) resList.Add( "SALESSLIPRF_SALESSLIPNUMRF" );
            if ( frePEstFmHead1.SALESSLIPRF_SECTIONCODERF != frePEstFmHead2.SALESSLIPRF_SECTIONCODERF ) resList.Add( "SALESSLIPRF_SECTIONCODERF" );
            if ( frePEstFmHead1.SALESSLIPRF_SALESDATERF != frePEstFmHead2.SALESSLIPRF_SALESDATERF ) resList.Add( "SALESSLIPRF_SALESDATERF" );
            if ( frePEstFmHead1.SALESSLIPRF_ESTIMATEFORMNORF != frePEstFmHead2.SALESSLIPRF_ESTIMATEFORMNORF ) resList.Add( "SALESSLIPRF_ESTIMATEFORMNORF" );
            if ( frePEstFmHead1.SALESSLIPRF_ESTIMATEDIVIDERF != frePEstFmHead2.SALESSLIPRF_ESTIMATEDIVIDERF ) resList.Add( "SALESSLIPRF_ESTIMATEDIVIDERF" );
            if ( frePEstFmHead1.SALESSLIPRF_SALESINPUTCODERF != frePEstFmHead2.SALESSLIPRF_SALESINPUTCODERF ) resList.Add( "SALESSLIPRF_SALESINPUTCODERF" );
            if ( frePEstFmHead1.SALESSLIPRF_SALESINPUTNAMERF != frePEstFmHead2.SALESSLIPRF_SALESINPUTNAMERF ) resList.Add( "SALESSLIPRF_SALESINPUTNAMERF" );
            if ( frePEstFmHead1.SALESSLIPRF_FRONTEMPLOYEECDRF != frePEstFmHead2.SALESSLIPRF_FRONTEMPLOYEECDRF ) resList.Add( "SALESSLIPRF_FRONTEMPLOYEECDRF" );
            if ( frePEstFmHead1.SALESSLIPRF_FRONTEMPLOYEENMRF != frePEstFmHead2.SALESSLIPRF_FRONTEMPLOYEENMRF ) resList.Add( "SALESSLIPRF_FRONTEMPLOYEENMRF" );
            if ( frePEstFmHead1.SALESSLIPRF_SALESEMPLOYEECDRF != frePEstFmHead2.SALESSLIPRF_SALESEMPLOYEECDRF ) resList.Add( "SALESSLIPRF_SALESEMPLOYEECDRF" );
            if ( frePEstFmHead1.SALESSLIPRF_SALESEMPLOYEENMRF != frePEstFmHead2.SALESSLIPRF_SALESEMPLOYEENMRF ) resList.Add( "SALESSLIPRF_SALESEMPLOYEENMRF" );
            if ( frePEstFmHead1.SALESSLIPRF_CONSTAXLAYMETHODRF != frePEstFmHead2.SALESSLIPRF_CONSTAXLAYMETHODRF ) resList.Add( "SALESSLIPRF_CONSTAXLAYMETHODRF" );
            if ( frePEstFmHead1.SALESSLIPRF_CUSTOMERCODERF != frePEstFmHead2.SALESSLIPRF_CUSTOMERCODERF ) resList.Add( "SALESSLIPRF_CUSTOMERCODERF" );
            if ( frePEstFmHead1.SALESSLIPRF_CUSTOMERNAMERF != frePEstFmHead2.SALESSLIPRF_CUSTOMERNAMERF ) resList.Add( "SALESSLIPRF_CUSTOMERNAMERF" );
            if ( frePEstFmHead1.SALESSLIPRF_CUSTOMERNAME2RF != frePEstFmHead2.SALESSLIPRF_CUSTOMERNAME2RF ) resList.Add( "SALESSLIPRF_CUSTOMERNAME2RF" );
            if ( frePEstFmHead1.SALESSLIPRF_CUSTOMERSNMRF != frePEstFmHead2.SALESSLIPRF_CUSTOMERSNMRF ) resList.Add( "SALESSLIPRF_CUSTOMERSNMRF" );
            if ( frePEstFmHead1.SALESSLIPRF_HONORIFICTITLERF != frePEstFmHead2.SALESSLIPRF_HONORIFICTITLERF ) resList.Add( "SALESSLIPRF_HONORIFICTITLERF" );
            if ( frePEstFmHead1.SALESSLIPRF_SALESSLIPPRINTDATERF != frePEstFmHead2.SALESSLIPRF_SALESSLIPPRINTDATERF ) resList.Add( "SALESSLIPRF_SALESSLIPPRINTDATERF" );
            if ( frePEstFmHead1.SALESSLIPRF_TOTALAMOUNTDISPWAYCDRF != frePEstFmHead2.SALESSLIPRF_TOTALAMOUNTDISPWAYCDRF ) resList.Add( "SALESSLIPRF_TOTALAMOUNTDISPWAYCDRF" );
            if ( frePEstFmHead1.SECINFOSETRF_SECTIONGUIDENMRF != frePEstFmHead2.SECINFOSETRF_SECTIONGUIDENMRF ) resList.Add( "SECINFOSETRF_SECTIONGUIDENMRF" );
            if ( frePEstFmHead1.COMPANYNMRF_COMPANYPRRF != frePEstFmHead2.COMPANYNMRF_COMPANYPRRF ) resList.Add( "COMPANYNMRF_COMPANYPRRF" );
            if ( frePEstFmHead1.COMPANYNMRF_COMPANYNAME1RF != frePEstFmHead2.COMPANYNMRF_COMPANYNAME1RF ) resList.Add( "COMPANYNMRF_COMPANYNAME1RF" );
            if ( frePEstFmHead1.COMPANYNMRF_COMPANYNAME2RF != frePEstFmHead2.COMPANYNMRF_COMPANYNAME2RF ) resList.Add( "COMPANYNMRF_COMPANYNAME2RF" );
            if ( frePEstFmHead1.COMPANYNMRF_POSTNORF != frePEstFmHead2.COMPANYNMRF_POSTNORF ) resList.Add( "COMPANYNMRF_POSTNORF" );
            if ( frePEstFmHead1.COMPANYNMRF_ADDRESS1RF != frePEstFmHead2.COMPANYNMRF_ADDRESS1RF ) resList.Add( "COMPANYNMRF_ADDRESS1RF" );
            if ( frePEstFmHead1.COMPANYNMRF_ADDRESS3RF != frePEstFmHead2.COMPANYNMRF_ADDRESS3RF ) resList.Add( "COMPANYNMRF_ADDRESS3RF" );
            if ( frePEstFmHead1.COMPANYNMRF_ADDRESS4RF != frePEstFmHead2.COMPANYNMRF_ADDRESS4RF ) resList.Add( "COMPANYNMRF_ADDRESS4RF" );
            if ( frePEstFmHead1.COMPANYNMRF_COMPANYTELNO1RF != frePEstFmHead2.COMPANYNMRF_COMPANYTELNO1RF ) resList.Add( "COMPANYNMRF_COMPANYTELNO1RF" );
            if ( frePEstFmHead1.COMPANYNMRF_COMPANYTELNO2RF != frePEstFmHead2.COMPANYNMRF_COMPANYTELNO2RF ) resList.Add( "COMPANYNMRF_COMPANYTELNO2RF" );
            if ( frePEstFmHead1.COMPANYNMRF_COMPANYTELNO3RF != frePEstFmHead2.COMPANYNMRF_COMPANYTELNO3RF ) resList.Add( "COMPANYNMRF_COMPANYTELNO3RF" );
            if ( frePEstFmHead1.COMPANYNMRF_COMPANYTELTITLE1RF != frePEstFmHead2.COMPANYNMRF_COMPANYTELTITLE1RF ) resList.Add( "COMPANYNMRF_COMPANYTELTITLE1RF" );
            if ( frePEstFmHead1.COMPANYNMRF_COMPANYTELTITLE2RF != frePEstFmHead2.COMPANYNMRF_COMPANYTELTITLE2RF ) resList.Add( "COMPANYNMRF_COMPANYTELTITLE2RF" );
            if ( frePEstFmHead1.COMPANYNMRF_COMPANYTELTITLE3RF != frePEstFmHead2.COMPANYNMRF_COMPANYTELTITLE3RF ) resList.Add( "COMPANYNMRF_COMPANYTELTITLE3RF" );
            if ( frePEstFmHead1.COMPANYNMRF_TRANSFERGUIDANCERF != frePEstFmHead2.COMPANYNMRF_TRANSFERGUIDANCERF ) resList.Add( "COMPANYNMRF_TRANSFERGUIDANCERF" );
            if ( frePEstFmHead1.COMPANYNMRF_ACCOUNTNOINFO1RF != frePEstFmHead2.COMPANYNMRF_ACCOUNTNOINFO1RF ) resList.Add( "COMPANYNMRF_ACCOUNTNOINFO1RF" );
            if ( frePEstFmHead1.COMPANYNMRF_ACCOUNTNOINFO2RF != frePEstFmHead2.COMPANYNMRF_ACCOUNTNOINFO2RF ) resList.Add( "COMPANYNMRF_ACCOUNTNOINFO2RF" );
            if ( frePEstFmHead1.COMPANYNMRF_ACCOUNTNOINFO3RF != frePEstFmHead2.COMPANYNMRF_ACCOUNTNOINFO3RF ) resList.Add( "COMPANYNMRF_ACCOUNTNOINFO3RF" );
            if ( frePEstFmHead1.COMPANYNMRF_COMPANYSETNOTE1RF != frePEstFmHead2.COMPANYNMRF_COMPANYSETNOTE1RF ) resList.Add( "COMPANYNMRF_COMPANYSETNOTE1RF" );
            if ( frePEstFmHead1.COMPANYNMRF_COMPANYSETNOTE2RF != frePEstFmHead2.COMPANYNMRF_COMPANYSETNOTE2RF ) resList.Add( "COMPANYNMRF_COMPANYSETNOTE2RF" );
            if ( frePEstFmHead1.COMPANYNMRF_COMPANYURLRF != frePEstFmHead2.COMPANYNMRF_COMPANYURLRF ) resList.Add( "COMPANYNMRF_COMPANYURLRF" );
            if ( frePEstFmHead1.COMPANYNMRF_COMPANYPRSENTENCE2RF != frePEstFmHead2.COMPANYNMRF_COMPANYPRSENTENCE2RF ) resList.Add( "COMPANYNMRF_COMPANYPRSENTENCE2RF" );
            if ( frePEstFmHead1.COMPANYNMRF_IMAGECOMMENTFORPRT1RF != frePEstFmHead2.COMPANYNMRF_IMAGECOMMENTFORPRT1RF ) resList.Add( "COMPANYNMRF_IMAGECOMMENTFORPRT1RF" );
            if ( frePEstFmHead1.COMPANYNMRF_IMAGECOMMENTFORPRT2RF != frePEstFmHead2.COMPANYNMRF_IMAGECOMMENTFORPRT2RF ) resList.Add( "COMPANYNMRF_IMAGECOMMENTFORPRT2RF" );
            if ( frePEstFmHead1.IMAGEINFORF_IMAGEINFODATARF != frePEstFmHead2.IMAGEINFORF_IMAGEINFODATARF ) resList.Add( "IMAGEINFORF_IMAGEINFODATARF" );
            if ( frePEstFmHead1.COMPANYINFRF_COMPANYNAME1RF != frePEstFmHead2.COMPANYINFRF_COMPANYNAME1RF ) resList.Add( "COMPANYINFRF_COMPANYNAME1RF" );
            if ( frePEstFmHead1.COMPANYINFRF_COMPANYNAME2RF != frePEstFmHead2.COMPANYINFRF_COMPANYNAME2RF ) resList.Add( "COMPANYINFRF_COMPANYNAME2RF" );
            if ( frePEstFmHead1.COMPANYINFRF_POSTNORF != frePEstFmHead2.COMPANYINFRF_POSTNORF ) resList.Add( "COMPANYINFRF_POSTNORF" );
            if ( frePEstFmHead1.COMPANYINFRF_ADDRESS1RF != frePEstFmHead2.COMPANYINFRF_ADDRESS1RF ) resList.Add( "COMPANYINFRF_ADDRESS1RF" );
            if ( frePEstFmHead1.COMPANYINFRF_ADDRESS3RF != frePEstFmHead2.COMPANYINFRF_ADDRESS3RF ) resList.Add( "COMPANYINFRF_ADDRESS3RF" );
            if ( frePEstFmHead1.COMPANYINFRF_ADDRESS4RF != frePEstFmHead2.COMPANYINFRF_ADDRESS4RF ) resList.Add( "COMPANYINFRF_ADDRESS4RF" );
            if ( frePEstFmHead1.COMPANYINFRF_COMPANYTELNO1RF != frePEstFmHead2.COMPANYINFRF_COMPANYTELNO1RF ) resList.Add( "COMPANYINFRF_COMPANYTELNO1RF" );
            if ( frePEstFmHead1.COMPANYINFRF_COMPANYTELNO2RF != frePEstFmHead2.COMPANYINFRF_COMPANYTELNO2RF ) resList.Add( "COMPANYINFRF_COMPANYTELNO2RF" );
            if ( frePEstFmHead1.COMPANYINFRF_COMPANYTELNO3RF != frePEstFmHead2.COMPANYINFRF_COMPANYTELNO3RF ) resList.Add( "COMPANYINFRF_COMPANYTELNO3RF" );
            if ( frePEstFmHead1.COMPANYINFRF_COMPANYTELTITLE1RF != frePEstFmHead2.COMPANYINFRF_COMPANYTELTITLE1RF ) resList.Add( "COMPANYINFRF_COMPANYTELTITLE1RF" );
            if ( frePEstFmHead1.COMPANYINFRF_COMPANYTELTITLE2RF != frePEstFmHead2.COMPANYINFRF_COMPANYTELTITLE2RF ) resList.Add( "COMPANYINFRF_COMPANYTELTITLE2RF" );
            if ( frePEstFmHead1.COMPANYINFRF_COMPANYTELTITLE3RF != frePEstFmHead2.COMPANYINFRF_COMPANYTELTITLE3RF ) resList.Add( "COMPANYINFRF_COMPANYTELTITLE3RF" );
            if ( frePEstFmHead1.HEST_FOOTNOTES1RF != frePEstFmHead2.HEST_FOOTNOTES1RF ) resList.Add( "HEST_FOOTNOTES1RF" );
            if ( frePEstFmHead1.HEST_FOOTNOTES2RF != frePEstFmHead2.HEST_FOOTNOTES2RF ) resList.Add( "HEST_FOOTNOTES2RF" );
            if ( frePEstFmHead1.HEST_ESTIMATETITLE1RF != frePEstFmHead2.HEST_ESTIMATETITLE1RF ) resList.Add( "HEST_ESTIMATETITLE1RF" );
            if ( frePEstFmHead1.HEST_ESTIMATETITLE2RF != frePEstFmHead2.HEST_ESTIMATETITLE2RF ) resList.Add( "HEST_ESTIMATETITLE2RF" );
            if ( frePEstFmHead1.HEST_ESTIMATETITLE3RF != frePEstFmHead2.HEST_ESTIMATETITLE3RF ) resList.Add( "HEST_ESTIMATETITLE3RF" );
            if ( frePEstFmHead1.HEST_ESTIMATETITLE4RF != frePEstFmHead2.HEST_ESTIMATETITLE4RF ) resList.Add( "HEST_ESTIMATETITLE4RF" );
            if ( frePEstFmHead1.HEST_ESTIMATETITLE5RF != frePEstFmHead2.HEST_ESTIMATETITLE5RF ) resList.Add( "HEST_ESTIMATETITLE5RF" );
            if ( frePEstFmHead1.HEST_ESTIMATENOTE1RF != frePEstFmHead2.HEST_ESTIMATENOTE1RF ) resList.Add( "HEST_ESTIMATENOTE1RF" );
            if ( frePEstFmHead1.HEST_ESTIMATENOTE2RF != frePEstFmHead2.HEST_ESTIMATENOTE2RF ) resList.Add( "HEST_ESTIMATENOTE2RF" );
            if ( frePEstFmHead1.HEST_ESTIMATENOTE3RF != frePEstFmHead2.HEST_ESTIMATENOTE3RF ) resList.Add( "HEST_ESTIMATENOTE3RF" );
            if ( frePEstFmHead1.HEST_ESTIMATENOTE4RF != frePEstFmHead2.HEST_ESTIMATENOTE4RF ) resList.Add( "HEST_ESTIMATENOTE4RF" );
            if ( frePEstFmHead1.HEST_ESTIMATENOTE5RF != frePEstFmHead2.HEST_ESTIMATENOTE5RF ) resList.Add( "HEST_ESTIMATENOTE5RF" );
            if ( frePEstFmHead1.HEST_ESTIMATEVALIDITYLIMITRF != frePEstFmHead2.HEST_ESTIMATEVALIDITYLIMITRF ) resList.Add( "HEST_ESTIMATEVALIDITYLIMITRF" );
            if ( frePEstFmHead1.HEST_ESTIMATEVALIDITYLIMITFYRF != frePEstFmHead2.HEST_ESTIMATEVALIDITYLIMITFYRF ) resList.Add( "HEST_ESTIMATEVALIDITYLIMITFYRF" );
            if ( frePEstFmHead1.HEST_ESTIMATEVALIDITYLIMITFSRF != frePEstFmHead2.HEST_ESTIMATEVALIDITYLIMITFSRF ) resList.Add( "HEST_ESTIMATEVALIDITYLIMITFSRF" );
            if ( frePEstFmHead1.HEST_ESTIMATEVALIDITYLIMITFWRF != frePEstFmHead2.HEST_ESTIMATEVALIDITYLIMITFWRF ) resList.Add( "HEST_ESTIMATEVALIDITYLIMITFWRF" );
            if ( frePEstFmHead1.HEST_ESTIMATEVALIDITYLIMITFMRF != frePEstFmHead2.HEST_ESTIMATEVALIDITYLIMITFMRF ) resList.Add( "HEST_ESTIMATEVALIDITYLIMITFMRF" );
            if ( frePEstFmHead1.HEST_ESTIMATEVALIDITYLIMITFDRF != frePEstFmHead2.HEST_ESTIMATEVALIDITYLIMITFDRF ) resList.Add( "HEST_ESTIMATEVALIDITYLIMITFDRF" );
            if ( frePEstFmHead1.HEST_ESTIMATEVALIDITYLIMITFGRF != frePEstFmHead2.HEST_ESTIMATEVALIDITYLIMITFGRF ) resList.Add( "HEST_ESTIMATEVALIDITYLIMITFGRF" );
            if ( frePEstFmHead1.HEST_ESTIMATEVALIDITYLIMITFRRF != frePEstFmHead2.HEST_ESTIMATEVALIDITYLIMITFRRF ) resList.Add( "HEST_ESTIMATEVALIDITYLIMITFRRF" );
            if ( frePEstFmHead1.HEST_ESTIMATEVALIDITYLIMITFLSRF != frePEstFmHead2.HEST_ESTIMATEVALIDITYLIMITFLSRF ) resList.Add( "HEST_ESTIMATEVALIDITYLIMITFLSRF" );
            if ( frePEstFmHead1.HEST_ESTIMATEVALIDITYLIMITFLPRF != frePEstFmHead2.HEST_ESTIMATEVALIDITYLIMITFLPRF ) resList.Add( "HEST_ESTIMATEVALIDITYLIMITFLPRF" );
            if ( frePEstFmHead1.HEST_ESTIMATEVALIDITYLIMITFLYRF != frePEstFmHead2.HEST_ESTIMATEVALIDITYLIMITFLYRF ) resList.Add( "HEST_ESTIMATEVALIDITYLIMITFLYRF" );
            if ( frePEstFmHead1.HEST_ESTIMATEVALIDITYLIMITFLMRF != frePEstFmHead2.HEST_ESTIMATEVALIDITYLIMITFLMRF ) resList.Add( "HEST_ESTIMATEVALIDITYLIMITFLMRF" );
            if ( frePEstFmHead1.HEST_ESTIMATEVALIDITYLIMITFLDRF != frePEstFmHead2.HEST_ESTIMATEVALIDITYLIMITFLDRF ) resList.Add( "HEST_ESTIMATEVALIDITYLIMITFLDRF" );
            if ( frePEstFmHead1.HADD_CARMNGNORF != frePEstFmHead2.HADD_CARMNGNORF ) resList.Add( "HADD_CARMNGNORF" );
            if ( frePEstFmHead1.HADD_CARMNGCODERF != frePEstFmHead2.HADD_CARMNGCODERF ) resList.Add( "HADD_CARMNGCODERF" );
            if ( frePEstFmHead1.HADD_NUMBERPLATE1CODERF != frePEstFmHead2.HADD_NUMBERPLATE1CODERF ) resList.Add( "HADD_NUMBERPLATE1CODERF" );
            if ( frePEstFmHead1.HADD_NUMBERPLATE1NAMERF != frePEstFmHead2.HADD_NUMBERPLATE1NAMERF ) resList.Add( "HADD_NUMBERPLATE1NAMERF" );
            if ( frePEstFmHead1.HADD_NUMBERPLATE2RF != frePEstFmHead2.HADD_NUMBERPLATE2RF ) resList.Add( "HADD_NUMBERPLATE2RF" );
            if ( frePEstFmHead1.HADD_NUMBERPLATE3RF != frePEstFmHead2.HADD_NUMBERPLATE3RF ) resList.Add( "HADD_NUMBERPLATE3RF" );
            if ( frePEstFmHead1.HADD_NUMBERPLATE4RF != frePEstFmHead2.HADD_NUMBERPLATE4RF ) resList.Add( "HADD_NUMBERPLATE4RF" );
            if ( frePEstFmHead1.HADD_FIRSTENTRYDATERF != frePEstFmHead2.HADD_FIRSTENTRYDATERF ) resList.Add( "HADD_FIRSTENTRYDATERF" );
            if ( frePEstFmHead1.HADD_MAKERCODERF != frePEstFmHead2.HADD_MAKERCODERF ) resList.Add( "HADD_MAKERCODERF" );
            if ( frePEstFmHead1.HADD_MAKERFULLNAMERF != frePEstFmHead2.HADD_MAKERFULLNAMERF ) resList.Add( "HADD_MAKERFULLNAMERF" );
            if ( frePEstFmHead1.HADD_MAKERHALFNAMERF != frePEstFmHead2.HADD_MAKERHALFNAMERF ) resList.Add( "HADD_MAKERHALFNAMERF" );
            if ( frePEstFmHead1.HADD_MODELCODERF != frePEstFmHead2.HADD_MODELCODERF ) resList.Add( "HADD_MODELCODERF" );
            if ( frePEstFmHead1.HADD_MODELSUBCODERF != frePEstFmHead2.HADD_MODELSUBCODERF ) resList.Add( "HADD_MODELSUBCODERF" );
            if ( frePEstFmHead1.HADD_MODELFULLNAMERF != frePEstFmHead2.HADD_MODELFULLNAMERF ) resList.Add( "HADD_MODELFULLNAMERF" );
            if ( frePEstFmHead1.HADD_MODELHALFNAMERF != frePEstFmHead2.HADD_MODELHALFNAMERF ) resList.Add( "HADD_MODELHALFNAMERF" );
            if ( frePEstFmHead1.HADD_EXHAUSTGASSIGNRF != frePEstFmHead2.HADD_EXHAUSTGASSIGNRF ) resList.Add( "HADD_EXHAUSTGASSIGNRF" );
            if ( frePEstFmHead1.HADD_SERIESMODELRF != frePEstFmHead2.HADD_SERIESMODELRF ) resList.Add( "HADD_SERIESMODELRF" );
            if ( frePEstFmHead1.HADD_CATEGORYSIGNMODELRF != frePEstFmHead2.HADD_CATEGORYSIGNMODELRF ) resList.Add( "HADD_CATEGORYSIGNMODELRF" );
            if ( frePEstFmHead1.HADD_FULLMODELRF != frePEstFmHead2.HADD_FULLMODELRF ) resList.Add( "HADD_FULLMODELRF" );
            if ( frePEstFmHead1.HADD_MODELDESIGNATIONNORF != frePEstFmHead2.HADD_MODELDESIGNATIONNORF ) resList.Add( "HADD_MODELDESIGNATIONNORF" );
            if ( frePEstFmHead1.HADD_CATEGORYNORF != frePEstFmHead2.HADD_CATEGORYNORF ) resList.Add( "HADD_CATEGORYNORF" );
            if ( frePEstFmHead1.HADD_FRAMEMODELRF != frePEstFmHead2.HADD_FRAMEMODELRF ) resList.Add( "HADD_FRAMEMODELRF" );
            if ( frePEstFmHead1.HADD_FRAMENORF != frePEstFmHead2.HADD_FRAMENORF ) resList.Add( "HADD_FRAMENORF" );
            if ( frePEstFmHead1.HADD_SEARCHFRAMENORF != frePEstFmHead2.HADD_SEARCHFRAMENORF ) resList.Add( "HADD_SEARCHFRAMENORF" );
            if ( frePEstFmHead1.HADD_ENGINEMODELNMRF != frePEstFmHead2.HADD_ENGINEMODELNMRF ) resList.Add( "HADD_ENGINEMODELNMRF" );
            if ( frePEstFmHead1.HADD_RELEVANCEMODELRF != frePEstFmHead2.HADD_RELEVANCEMODELRF ) resList.Add( "HADD_RELEVANCEMODELRF" );
            if ( frePEstFmHead1.HADD_SUBCARNMCDRF != frePEstFmHead2.HADD_SUBCARNMCDRF ) resList.Add( "HADD_SUBCARNMCDRF" );
            if ( frePEstFmHead1.HADD_MODELGRADESNAMERF != frePEstFmHead2.HADD_MODELGRADESNAMERF ) resList.Add( "HADD_MODELGRADESNAMERF" );
            if ( frePEstFmHead1.HADD_COLORCODERF != frePEstFmHead2.HADD_COLORCODERF ) resList.Add( "HADD_COLORCODERF" );
            if ( frePEstFmHead1.HADD_COLORNAME1RF != frePEstFmHead2.HADD_COLORNAME1RF ) resList.Add( "HADD_COLORNAME1RF" );
            if ( frePEstFmHead1.HADD_TRIMCODERF != frePEstFmHead2.HADD_TRIMCODERF ) resList.Add( "HADD_TRIMCODERF" );
            if ( frePEstFmHead1.HADD_TRIMNAMERF != frePEstFmHead2.HADD_TRIMNAMERF ) resList.Add( "HADD_TRIMNAMERF" );
            if ( frePEstFmHead1.HADD_MILEAGERF != frePEstFmHead2.HADD_MILEAGERF ) resList.Add( "HADD_MILEAGERF" );
            if ( frePEstFmHead1.HADD_PRINTERMNGNORF != frePEstFmHead2.HADD_PRINTERMNGNORF ) resList.Add( "HADD_PRINTERMNGNORF" );
            if ( frePEstFmHead1.HADD_SLIPPRTSETPAPERIDRF != frePEstFmHead2.HADD_SLIPPRTSETPAPERIDRF ) resList.Add( "HADD_SLIPPRTSETPAPERIDRF" );
            if ( frePEstFmHead1.HADD_NOTE1RF != frePEstFmHead2.HADD_NOTE1RF ) resList.Add( "HADD_NOTE1RF" );
            if ( frePEstFmHead1.HADD_NOTE2RF != frePEstFmHead2.HADD_NOTE2RF ) resList.Add( "HADD_NOTE2RF" );
            if ( frePEstFmHead1.HADD_NOTE3RF != frePEstFmHead2.HADD_NOTE3RF ) resList.Add( "HADD_NOTE3RF" );
            if ( frePEstFmHead1.HADD_FIRSTENTRYDATEFYRF != frePEstFmHead2.HADD_FIRSTENTRYDATEFYRF ) resList.Add( "HADD_FIRSTENTRYDATEFYRF" );
            if ( frePEstFmHead1.HADD_FIRSTENTRYDATEFSRF != frePEstFmHead2.HADD_FIRSTENTRYDATEFSRF ) resList.Add( "HADD_FIRSTENTRYDATEFSRF" );
            if ( frePEstFmHead1.HADD_FIRSTENTRYDATEFWRF != frePEstFmHead2.HADD_FIRSTENTRYDATEFWRF ) resList.Add( "HADD_FIRSTENTRYDATEFWRF" );
            if ( frePEstFmHead1.HADD_FIRSTENTRYDATEFMRF != frePEstFmHead2.HADD_FIRSTENTRYDATEFMRF ) resList.Add( "HADD_FIRSTENTRYDATEFMRF" );
            if ( frePEstFmHead1.HADD_FIRSTENTRYDATEFGRF != frePEstFmHead2.HADD_FIRSTENTRYDATEFGRF ) resList.Add( "HADD_FIRSTENTRYDATEFGRF" );
            if ( frePEstFmHead1.HADD_FIRSTENTRYDATEFRRF != frePEstFmHead2.HADD_FIRSTENTRYDATEFRRF ) resList.Add( "HADD_FIRSTENTRYDATEFRRF" );
            if ( frePEstFmHead1.HADD_FIRSTENTRYDATEFLSRF != frePEstFmHead2.HADD_FIRSTENTRYDATEFLSRF ) resList.Add( "HADD_FIRSTENTRYDATEFLSRF" );
            if ( frePEstFmHead1.HADD_FIRSTENTRYDATEFLPRF != frePEstFmHead2.HADD_FIRSTENTRYDATEFLPRF ) resList.Add( "HADD_FIRSTENTRYDATEFLPRF" );
            if ( frePEstFmHead1.HADD_FIRSTENTRYDATEFLYRF != frePEstFmHead2.HADD_FIRSTENTRYDATEFLYRF ) resList.Add( "HADD_FIRSTENTRYDATEFLYRF" );
            if ( frePEstFmHead1.HADD_FIRSTENTRYDATEFLMRF != frePEstFmHead2.HADD_FIRSTENTRYDATEFLMRF ) resList.Add( "HADD_FIRSTENTRYDATEFLMRF" );
            if ( frePEstFmHead1.HADD_PRINTCUSTOMERNM1RF != frePEstFmHead2.HADD_PRINTCUSTOMERNM1RF ) resList.Add( "HADD_PRINTCUSTOMERNM1RF" );
            if ( frePEstFmHead1.HADD_PRINTCUSTOMERNM2RF != frePEstFmHead2.HADD_PRINTCUSTOMERNM2RF ) resList.Add( "HADD_PRINTCUSTOMERNM2RF" );
            if ( frePEstFmHead1.HPURE_SALESTOTALTAXINCRF != frePEstFmHead2.HPURE_SALESTOTALTAXINCRF ) resList.Add( "HPURE_SALESTOTALTAXINCRF" );
            if ( frePEstFmHead1.HPURE_SALESTOTALTAXEXCRF != frePEstFmHead2.HPURE_SALESTOTALTAXEXCRF ) resList.Add( "HPURE_SALESTOTALTAXEXCRF" );
            if ( frePEstFmHead1.HPURE_SALESSUBTOTALTAXINCRF != frePEstFmHead2.HPURE_SALESSUBTOTALTAXINCRF ) resList.Add( "HPURE_SALESSUBTOTALTAXINCRF" );
            if ( frePEstFmHead1.HPURE_SALESSUBTOTALTAXEXCRF != frePEstFmHead2.HPURE_SALESSUBTOTALTAXEXCRF ) resList.Add( "HPURE_SALESSUBTOTALTAXEXCRF" );
            if ( frePEstFmHead1.HPURE_SALESSUBTOTALTAXRF != frePEstFmHead2.HPURE_SALESSUBTOTALTAXRF ) resList.Add( "HPURE_SALESSUBTOTALTAXRF" );
            if ( frePEstFmHead1.HPRIME_SALESTOTALTAXINCRF != frePEstFmHead2.HPRIME_SALESTOTALTAXINCRF ) resList.Add( "HPRIME_SALESTOTALTAXINCRF" );
            if ( frePEstFmHead1.HPRIME_SALESTOTALTAXEXCRF != frePEstFmHead2.HPRIME_SALESTOTALTAXEXCRF ) resList.Add( "HPRIME_SALESTOTALTAXEXCRF" );
            if ( frePEstFmHead1.HPRIME_SALESSUBTOTALTAXINCRF != frePEstFmHead2.HPRIME_SALESSUBTOTALTAXINCRF ) resList.Add( "HPRIME_SALESSUBTOTALTAXINCRF" );
            if ( frePEstFmHead1.HPRIME_SALESSUBTOTALTAXEXCRF != frePEstFmHead2.HPRIME_SALESSUBTOTALTAXEXCRF ) resList.Add( "HPRIME_SALESSUBTOTALTAXEXCRF" );
            if ( frePEstFmHead1.HPRIME_SALESSUBTOTALTAXRF != frePEstFmHead2.HPRIME_SALESSUBTOTALTAXRF ) resList.Add( "HPRIME_SALESSUBTOTALTAXRF" );
            if ( frePEstFmHead1.HADD_PRINTTIMEHOURRF != frePEstFmHead2.HADD_PRINTTIMEHOURRF ) resList.Add( "HADD_PRINTTIMEHOURRF" );
            if ( frePEstFmHead1.HADD_PRINTTIMEMINUTERF != frePEstFmHead2.HADD_PRINTTIMEMINUTERF ) resList.Add( "HADD_PRINTTIMEMINUTERF" );
            if ( frePEstFmHead1.HADD_PRINTTIMESECONDRF != frePEstFmHead2.HADD_PRINTTIMESECONDRF ) resList.Add( "HADD_PRINTTIMESECONDRF" );
            if ( frePEstFmHead1.HADD_ESTFMDIVRF != frePEstFmHead2.HADD_ESTFMDIVRF ) resList.Add( "HADD_ESTFMDIVRF" );
            if ( frePEstFmHead1.HADD_SALESDATEFYRF != frePEstFmHead2.HADD_SALESDATEFYRF ) resList.Add( "HADD_SALESDATEFYRF" );
            if ( frePEstFmHead1.HADD_SALESDATEFSRF != frePEstFmHead2.HADD_SALESDATEFSRF ) resList.Add( "HADD_SALESDATEFSRF" );
            if ( frePEstFmHead1.HADD_SALESDATEFWRF != frePEstFmHead2.HADD_SALESDATEFWRF ) resList.Add( "HADD_SALESDATEFWRF" );
            if ( frePEstFmHead1.HADD_SALESDATEFMRF != frePEstFmHead2.HADD_SALESDATEFMRF ) resList.Add( "HADD_SALESDATEFMRF" );
            if ( frePEstFmHead1.HADD_SALESDATEFDRF != frePEstFmHead2.HADD_SALESDATEFDRF ) resList.Add( "HADD_SALESDATEFDRF" );
            if ( frePEstFmHead1.HADD_SALESDATEFGRF != frePEstFmHead2.HADD_SALESDATEFGRF ) resList.Add( "HADD_SALESDATEFGRF" );
            if ( frePEstFmHead1.HADD_SALESDATEFRRF != frePEstFmHead2.HADD_SALESDATEFRRF ) resList.Add( "HADD_SALESDATEFRRF" );
            if ( frePEstFmHead1.HADD_SALESDATEFLSRF != frePEstFmHead2.HADD_SALESDATEFLSRF ) resList.Add( "HADD_SALESDATEFLSRF" );
            if ( frePEstFmHead1.HADD_SALESDATEFLPRF != frePEstFmHead2.HADD_SALESDATEFLPRF ) resList.Add( "HADD_SALESDATEFLPRF" );
            if ( frePEstFmHead1.HADD_SALESDATEFLYRF != frePEstFmHead2.HADD_SALESDATEFLYRF ) resList.Add( "HADD_SALESDATEFLYRF" );
            if ( frePEstFmHead1.HADD_SALESDATEFLMRF != frePEstFmHead2.HADD_SALESDATEFLMRF ) resList.Add( "HADD_SALESDATEFLMRF" );
            if ( frePEstFmHead1.HADD_SALESDATEFLDRF != frePEstFmHead2.HADD_SALESDATEFLDRF ) resList.Add( "HADD_SALESDATEFLDRF" );
            if ( frePEstFmHead1.HADD_SALESSLIPPRINTDATEFYRF != frePEstFmHead2.HADD_SALESSLIPPRINTDATEFYRF ) resList.Add( "HADD_SALESSLIPPRINTDATEFYRF" );
            if ( frePEstFmHead1.HADD_SALESSLIPPRINTDATEFSRF != frePEstFmHead2.HADD_SALESSLIPPRINTDATEFSRF ) resList.Add( "HADD_SALESSLIPPRINTDATEFSRF" );
            if ( frePEstFmHead1.HADD_SALESSLIPPRINTDATEFWRF != frePEstFmHead2.HADD_SALESSLIPPRINTDATEFWRF ) resList.Add( "HADD_SALESSLIPPRINTDATEFWRF" );
            if ( frePEstFmHead1.HADD_SALESSLIPPRINTDATEFMRF != frePEstFmHead2.HADD_SALESSLIPPRINTDATEFMRF ) resList.Add( "HADD_SALESSLIPPRINTDATEFMRF" );
            if ( frePEstFmHead1.HADD_SALESSLIPPRINTDATEFDRF != frePEstFmHead2.HADD_SALESSLIPPRINTDATEFDRF ) resList.Add( "HADD_SALESSLIPPRINTDATEFDRF" );
            if ( frePEstFmHead1.HADD_SALESSLIPPRINTDATEFGRF != frePEstFmHead2.HADD_SALESSLIPPRINTDATEFGRF ) resList.Add( "HADD_SALESSLIPPRINTDATEFGRF" );
            if ( frePEstFmHead1.HADD_SALESSLIPPRINTDATEFRRF != frePEstFmHead2.HADD_SALESSLIPPRINTDATEFRRF ) resList.Add( "HADD_SALESSLIPPRINTDATEFRRF" );
            if ( frePEstFmHead1.HADD_SALESSLIPPRINTDATEFLSRF != frePEstFmHead2.HADD_SALESSLIPPRINTDATEFLSRF ) resList.Add( "HADD_SALESSLIPPRINTDATEFLSRF" );
            if ( frePEstFmHead1.HADD_SALESSLIPPRINTDATEFLPRF != frePEstFmHead2.HADD_SALESSLIPPRINTDATEFLPRF ) resList.Add( "HADD_SALESSLIPPRINTDATEFLPRF" );
            if ( frePEstFmHead1.HADD_SALESSLIPPRINTDATEFLYRF != frePEstFmHead2.HADD_SALESSLIPPRINTDATEFLYRF ) resList.Add( "HADD_SALESSLIPPRINTDATEFLYRF" );
            if ( frePEstFmHead1.HADD_SALESSLIPPRINTDATEFLMRF != frePEstFmHead2.HADD_SALESSLIPPRINTDATEFLMRF ) resList.Add( "HADD_SALESSLIPPRINTDATEFLMRF" );
            if ( frePEstFmHead1.HADD_SALESSLIPPRINTDATEFLDRF != frePEstFmHead2.HADD_SALESSLIPPRINTDATEFLDRF ) resList.Add( "HADD_SALESSLIPPRINTDATEFLDRF" );
            if ( frePEstFmHead1.HADD_SYSTEMATICCODERF != frePEstFmHead2.HADD_SYSTEMATICCODERF ) resList.Add( "HADD_SYSTEMATICCODERF" );
            if ( frePEstFmHead1.HADD_SYSTEMATICNAMERF != frePEstFmHead2.HADD_SYSTEMATICNAMERF ) resList.Add( "HADD_SYSTEMATICNAMERF" );
            if ( frePEstFmHead1.HADD_STPRODUCETYPEOFYEARRF != frePEstFmHead2.HADD_STPRODUCETYPEOFYEARRF ) resList.Add( "HADD_STPRODUCETYPEOFYEARRF" );
            if ( frePEstFmHead1.HADD_EDPRODUCETYPEOFYEARRF != frePEstFmHead2.HADD_EDPRODUCETYPEOFYEARRF ) resList.Add( "HADD_EDPRODUCETYPEOFYEARRF" );
            if ( frePEstFmHead1.HADD_DOORCOUNTRF != frePEstFmHead2.HADD_DOORCOUNTRF ) resList.Add( "HADD_DOORCOUNTRF" );
            if ( frePEstFmHead1.HADD_BODYNAMECODERF != frePEstFmHead2.HADD_BODYNAMECODERF ) resList.Add( "HADD_BODYNAMECODERF" );
            if ( frePEstFmHead1.HADD_BODYNAMERF != frePEstFmHead2.HADD_BODYNAMERF ) resList.Add( "HADD_BODYNAMERF" );
            if ( frePEstFmHead1.HADD_STPRODUCEFRAMENORF != frePEstFmHead2.HADD_STPRODUCEFRAMENORF ) resList.Add( "HADD_STPRODUCEFRAMENORF" );
            if ( frePEstFmHead1.HADD_EDPRODUCEFRAMENORF != frePEstFmHead2.HADD_EDPRODUCEFRAMENORF ) resList.Add( "HADD_EDPRODUCEFRAMENORF" );
            if ( frePEstFmHead1.HADD_ENGINEMODELRF != frePEstFmHead2.HADD_ENGINEMODELRF ) resList.Add( "HADD_ENGINEMODELRF" );
            if ( frePEstFmHead1.HADD_MODELGRADENMRF != frePEstFmHead2.HADD_MODELGRADENMRF ) resList.Add( "HADD_MODELGRADENMRF" );
            if ( frePEstFmHead1.HADD_ENGINEDISPLACENMRF != frePEstFmHead2.HADD_ENGINEDISPLACENMRF ) resList.Add( "HADD_ENGINEDISPLACENMRF" );
            if ( frePEstFmHead1.HADD_EDIVNMRF != frePEstFmHead2.HADD_EDIVNMRF ) resList.Add( "HADD_EDIVNMRF" );
            if ( frePEstFmHead1.HADD_TRANSMISSIONNMRF != frePEstFmHead2.HADD_TRANSMISSIONNMRF ) resList.Add( "HADD_TRANSMISSIONNMRF" );
            if ( frePEstFmHead1.HADD_SHIFTNMRF != frePEstFmHead2.HADD_SHIFTNMRF ) resList.Add( "HADD_SHIFTNMRF" );
            if ( frePEstFmHead1.HADD_WHEELDRIVEMETHODNMRF != frePEstFmHead2.HADD_WHEELDRIVEMETHODNMRF ) resList.Add( "HADD_WHEELDRIVEMETHODNMRF" );
            if ( frePEstFmHead1.HADD_ADDICARSPEC1RF != frePEstFmHead2.HADD_ADDICARSPEC1RF ) resList.Add( "HADD_ADDICARSPEC1RF" );
            if ( frePEstFmHead1.HADD_ADDICARSPEC2RF != frePEstFmHead2.HADD_ADDICARSPEC2RF ) resList.Add( "HADD_ADDICARSPEC2RF" );
            if ( frePEstFmHead1.HADD_ADDICARSPEC3RF != frePEstFmHead2.HADD_ADDICARSPEC3RF ) resList.Add( "HADD_ADDICARSPEC3RF" );
            if ( frePEstFmHead1.HADD_ADDICARSPEC4RF != frePEstFmHead2.HADD_ADDICARSPEC4RF ) resList.Add( "HADD_ADDICARSPEC4RF" );
            if ( frePEstFmHead1.HADD_ADDICARSPEC5RF != frePEstFmHead2.HADD_ADDICARSPEC5RF ) resList.Add( "HADD_ADDICARSPEC5RF" );
            if ( frePEstFmHead1.HADD_ADDICARSPEC6RF != frePEstFmHead2.HADD_ADDICARSPEC6RF ) resList.Add( "HADD_ADDICARSPEC6RF" );
            if ( frePEstFmHead1.HADD_ADDICARSPECTITLE1RF != frePEstFmHead2.HADD_ADDICARSPECTITLE1RF ) resList.Add( "HADD_ADDICARSPECTITLE1RF" );
            if ( frePEstFmHead1.HADD_ADDICARSPECTITLE2RF != frePEstFmHead2.HADD_ADDICARSPECTITLE2RF ) resList.Add( "HADD_ADDICARSPECTITLE2RF" );
            if ( frePEstFmHead1.HADD_ADDICARSPECTITLE3RF != frePEstFmHead2.HADD_ADDICARSPECTITLE3RF ) resList.Add( "HADD_ADDICARSPECTITLE3RF" );
            if ( frePEstFmHead1.HADD_ADDICARSPECTITLE4RF != frePEstFmHead2.HADD_ADDICARSPECTITLE4RF ) resList.Add( "HADD_ADDICARSPECTITLE4RF" );
            if ( frePEstFmHead1.HADD_ADDICARSPECTITLE5RF != frePEstFmHead2.HADD_ADDICARSPECTITLE5RF ) resList.Add( "HADD_ADDICARSPECTITLE5RF" );
            if ( frePEstFmHead1.HADD_ADDICARSPECTITLE6RF != frePEstFmHead2.HADD_ADDICARSPECTITLE6RF ) resList.Add( "HADD_ADDICARSPECTITLE6RF" );
            if ( frePEstFmHead1.HADD_STPRODUCETYPEOFYEARFYRF != frePEstFmHead2.HADD_STPRODUCETYPEOFYEARFYRF ) resList.Add( "HADD_STPRODUCETYPEOFYEARFYRF" );
            if ( frePEstFmHead1.HADD_STPRODUCETYPEOFYEARFSRF != frePEstFmHead2.HADD_STPRODUCETYPEOFYEARFSRF ) resList.Add( "HADD_STPRODUCETYPEOFYEARFSRF" );
            if ( frePEstFmHead1.HADD_STPRODUCETYPEOFYEARFWRF != frePEstFmHead2.HADD_STPRODUCETYPEOFYEARFWRF ) resList.Add( "HADD_STPRODUCETYPEOFYEARFWRF" );
            if ( frePEstFmHead1.HADD_STPRODUCETYPEOFYEARFMRF != frePEstFmHead2.HADD_STPRODUCETYPEOFYEARFMRF ) resList.Add( "HADD_STPRODUCETYPEOFYEARFMRF" );
            if ( frePEstFmHead1.HADD_STPRODUCETYPEOFYEARFGRF != frePEstFmHead2.HADD_STPRODUCETYPEOFYEARFGRF ) resList.Add( "HADD_STPRODUCETYPEOFYEARFGRF" );
            if ( frePEstFmHead1.HADD_STPRODUCETYPEOFYEARFRRF != frePEstFmHead2.HADD_STPRODUCETYPEOFYEARFRRF ) resList.Add( "HADD_STPRODUCETYPEOFYEARFRRF" );
            if ( frePEstFmHead1.HADD_STPRODUCETYPEOFYEARFLSRF != frePEstFmHead2.HADD_STPRODUCETYPEOFYEARFLSRF ) resList.Add( "HADD_STPRODUCETYPEOFYEARFLSRF" );
            if ( frePEstFmHead1.HADD_STPRODUCETYPEOFYEARFLPRF != frePEstFmHead2.HADD_STPRODUCETYPEOFYEARFLPRF ) resList.Add( "HADD_STPRODUCETYPEOFYEARFLPRF" );
            if ( frePEstFmHead1.HADD_STPRODUCETYPEOFYEARFLYRF != frePEstFmHead2.HADD_STPRODUCETYPEOFYEARFLYRF ) resList.Add( "HADD_STPRODUCETYPEOFYEARFLYRF" );
            if ( frePEstFmHead1.HADD_STPRODUCETYPEOFYEARFLMRF != frePEstFmHead2.HADD_STPRODUCETYPEOFYEARFLMRF ) resList.Add( "HADD_STPRODUCETYPEOFYEARFLMRF" );
            if ( frePEstFmHead1.HADD_EDPRODUCETYPEOFYEARFYRF != frePEstFmHead2.HADD_EDPRODUCETYPEOFYEARFYRF ) resList.Add( "HADD_EDPRODUCETYPEOFYEARFYRF" );
            if ( frePEstFmHead1.HADD_EDPRODUCETYPEOFYEARFSRF != frePEstFmHead2.HADD_EDPRODUCETYPEOFYEARFSRF ) resList.Add( "HADD_EDPRODUCETYPEOFYEARFSRF" );
            if ( frePEstFmHead1.HADD_EDPRODUCETYPEOFYEARFWRF != frePEstFmHead2.HADD_EDPRODUCETYPEOFYEARFWRF ) resList.Add( "HADD_EDPRODUCETYPEOFYEARFWRF" );
            if ( frePEstFmHead1.HADD_EDPRODUCETYPEOFYEARFMRF != frePEstFmHead2.HADD_EDPRODUCETYPEOFYEARFMRF ) resList.Add( "HADD_EDPRODUCETYPEOFYEARFMRF" );
            if ( frePEstFmHead1.HADD_EDPRODUCETYPEOFYEARFGRF != frePEstFmHead2.HADD_EDPRODUCETYPEOFYEARFGRF ) resList.Add( "HADD_EDPRODUCETYPEOFYEARFGRF" );
            if ( frePEstFmHead1.HADD_EDPRODUCETYPEOFYEARFRRF != frePEstFmHead2.HADD_EDPRODUCETYPEOFYEARFRRF ) resList.Add( "HADD_EDPRODUCETYPEOFYEARFRRF" );
            if ( frePEstFmHead1.HADD_EDPRODUCETYPEOFYEARFLSRF != frePEstFmHead2.HADD_EDPRODUCETYPEOFYEARFLSRF ) resList.Add( "HADD_EDPRODUCETYPEOFYEARFLSRF" );
            if ( frePEstFmHead1.HADD_EDPRODUCETYPEOFYEARFLPRF != frePEstFmHead2.HADD_EDPRODUCETYPEOFYEARFLPRF ) resList.Add( "HADD_EDPRODUCETYPEOFYEARFLPRF" );
            if ( frePEstFmHead1.HADD_EDPRODUCETYPEOFYEARFLYRF != frePEstFmHead2.HADD_EDPRODUCETYPEOFYEARFLYRF ) resList.Add( "HADD_EDPRODUCETYPEOFYEARFLYRF" );
            if ( frePEstFmHead1.HADD_EDPRODUCETYPEOFYEARFLMRF != frePEstFmHead2.HADD_EDPRODUCETYPEOFYEARFLMRF ) resList.Add( "HADD_EDPRODUCETYPEOFYEARFLMRF" );

            return resList;
        }
    }

}
