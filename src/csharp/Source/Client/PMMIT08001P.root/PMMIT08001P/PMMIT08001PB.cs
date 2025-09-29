using System;
using System.IO;
using System.Text;
using System.Data;
using System.Collections;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.Collections.Generic;

using ar=DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

using Broadleaf.Library.Resources;
//using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Globarization;
using Broadleaf.Application.UIData;

namespace Broadleaf.Drawing.Printing
{
	/// <summary>
	/// 自由帳票(見積書)印刷クラス
	/// </summary>
	/// <remarks>
    /// <br>Note         : 印刷DataSourceのテーブル生成を行います。</br>
    /// <br>               </br>
	/// <br>Programmer   : 22018 鈴木　正臣</br>
	/// <br>Date         : 2008.06.03</br>
	/// <br></br>
	/// <br>Update Note  : 2010.03.08 22018 鈴木  正臣</br>
    /// <br>             : ㈱日商の対応。（ＰＭ７パッケージ同様の得意先名称の制御を組み込み）</br>
    /// <br></br>
    /// </remarks>
	internal class PMMIT08001PB
    {
        # region [public static readonly メンバ]
        /// <summary>自由帳票見積書テーブル</summary>
        public static readonly string ct_TBL_FREPESTFM = "FREPESTFM";
        /// <summary>同一ページ内コピーカウントcolumn名称</summary>
        public static readonly string ct_InPageCopyCount = "PMMIT08001P.INPAGECOPYCOUNT";
        /// <summary>複写タイトル１</summary>
        public static readonly string ct_InPageCopyTitle1 = "PMMIT08001P.INPAGECOPYTITLE1";
        /// <summary>複写タイトル２</summary>
        public static readonly string ct_InPageCopyTitle2 = "PMMIT08001P.INPAGECOPYTITLE2";
        /// <summary>複写タイトル３</summary>
        public static readonly string ct_InPageCopyTitle3 = "PMMIT08001P.INPAGECOPYTITLE3";
        /// <summary>複写タイトル４</summary>
        public static readonly string ct_InPageCopyTitle4 = "PMMIT08001P.INPAGECOPYTITLE4";
        /// <summary>頁数</summary>
        public static readonly string ct_PageCount = "PAGE.PAGECOUNTRF";
        /// <summary>(先頭)類別型式ハイフン</summary>
        public static readonly string ct_HCategoryHyp = "HPRT.CATEGORYHYPRF";
        /// <summary>得意先名１＋得意先名２</summary>
        public static readonly string ct_HPrintCustomerNameJoin12 = "HPRT.PRINTCUSTOMERNAMEJOIN12RF";
        /// <summary>得意先名１＋得意先名２＋敬称</summary>
        public static readonly string ct_HPrintCustomerNameJoinHn12 = "HPRT.PRINTCUSTOMERNAMEJOIN12HNRF";
        /// <summary>自社名１（前半）</summary>
        public static readonly string ct_HPrintEnterpriseName1FH = "HPRT.PRINTENTERPRISENAME1FHRF";
        /// <summary>自社名１（後半）</summary>
        public static readonly string ct_HPrintEnterpriseName1LH = "HPRT.PRINTENTERPRISENAME1LHRF";
        /// <summary>自社名２（前半）</summary>
        public static readonly string ct_HPrintEnterpriseName2FH = "HPRT.PRINTENTERPRISENAME2FHRF";
        /// <summary>自社名２（後半）</summary>
        public static readonly string ct_HPrintEnterpriseName2LH = "HPRT.PRINTENTERPRISENAME2LHRF";
        # endregion

        # region [データテーブル生成]
        /// <summary>
        /// データテーブル生成処理（スキーマ定義）
        /// </summary>
        /// <remarks></remarks>
        public static DataTable CreateFrePEstFmHeadTable( int subNo )
        {
            DataTable table = new DataTable( ct_TBL_FREPESTFM + subNo.ToString() );
            
            # region [スキーマ定義（伝票項目）]
            table.Columns.Add( new DataColumn( "SALESSLIPRF.SALESSLIPNUMRF", typeof( String ) ) ); // 売上伝票番号
            table.Columns.Add( new DataColumn( "SALESSLIPRF.SECTIONCODERF", typeof( String ) ) ); // 拠点コード
            table.Columns.Add( new DataColumn( "SALESSLIPRF.SALESDATERF", typeof( Int32 ) ) ); // 売上日付
            table.Columns.Add( new DataColumn( "SALESSLIPRF.ESTIMATEFORMNORF", typeof( String ) ) ); // 見積書番号
            table.Columns.Add( new DataColumn( "SALESSLIPRF.ESTIMATEDIVIDERF", typeof( Int32 ) ) ); // 見積区分
            table.Columns.Add( new DataColumn( "SALESSLIPRF.SALESINPUTCODERF", typeof( String ) ) ); // 売上入力者コード
            table.Columns.Add( new DataColumn( "SALESSLIPRF.SALESINPUTNAMERF", typeof( String ) ) ); // 売上入力者名称
            table.Columns.Add( new DataColumn( "SALESSLIPRF.FRONTEMPLOYEECDRF", typeof( String ) ) ); // 受付従業員コード
            table.Columns.Add( new DataColumn( "SALESSLIPRF.FRONTEMPLOYEENMRF", typeof( String ) ) ); // 受付従業員名称
            table.Columns.Add( new DataColumn( "SALESSLIPRF.SALESEMPLOYEECDRF", typeof( String ) ) ); // 販売従業員コード
            table.Columns.Add( new DataColumn( "SALESSLIPRF.SALESEMPLOYEENMRF", typeof( String ) ) ); // 販売従業員名称
            table.Columns.Add( new DataColumn( "SALESSLIPRF.CONSTAXLAYMETHODRF", typeof( Int32 ) ) ); // 消費税転嫁方式
            table.Columns.Add( new DataColumn( "SALESSLIPRF.CUSTOMERCODERF", typeof( Int32 ) ) ); // 得意先コード
            table.Columns.Add( new DataColumn( "SALESSLIPRF.CUSTOMERNAMERF", typeof( String ) ) ); // 得意先名称
            table.Columns.Add( new DataColumn( "SALESSLIPRF.CUSTOMERNAME2RF", typeof( String ) ) ); // 得意先名称2
            table.Columns.Add( new DataColumn( "SALESSLIPRF.CUSTOMERSNMRF", typeof( String ) ) ); // 得意先略称
            table.Columns.Add( new DataColumn( "SALESSLIPRF.HONORIFICTITLERF", typeof( String ) ) ); // 得意先敬称
            table.Columns.Add( new DataColumn( "SALESSLIPRF.SALESSLIPPRINTDATERF", typeof( Int32 ) ) ); // 売上伝票発行日
            table.Columns.Add( new DataColumn( "SALESSLIPRF.TOTALAMOUNTDISPWAYCDRF", typeof( Int32 ) ) ); // 総額表示方法区分
            table.Columns.Add( new DataColumn( "SECINFOSETRF.SECTIONGUIDENMRF", typeof( String ) ) ); // 拠点ガイド名称
            table.Columns.Add( new DataColumn( "COMPANYNMRF.COMPANYPRRF", typeof( String ) ) ); // 拠点自社PR文
            table.Columns.Add( new DataColumn( "COMPANYNMRF.COMPANYNAME1RF", typeof( String ) ) ); // 拠点自社名称1
            table.Columns.Add( new DataColumn( "COMPANYNMRF.COMPANYNAME2RF", typeof( String ) ) ); // 拠点自社名称2
            table.Columns.Add( new DataColumn( "COMPANYNMRF.POSTNORF", typeof( String ) ) ); // 拠点郵便番号
            table.Columns.Add( new DataColumn( "COMPANYNMRF.ADDRESS1RF", typeof( String ) ) ); // 拠点住所1（都道府県市区郡・町村・字）
            table.Columns.Add( new DataColumn( "COMPANYNMRF.ADDRESS3RF", typeof( String ) ) ); // 拠点住所3（番地）
            table.Columns.Add( new DataColumn( "COMPANYNMRF.ADDRESS4RF", typeof( String ) ) ); // 拠点住所4（アパート名称）
            table.Columns.Add( new DataColumn( "COMPANYNMRF.COMPANYTELNO1RF", typeof( String ) ) ); // 拠点自社電話番号1
            table.Columns.Add( new DataColumn( "COMPANYNMRF.COMPANYTELNO2RF", typeof( String ) ) ); // 拠点自社電話番号2
            table.Columns.Add( new DataColumn( "COMPANYNMRF.COMPANYTELNO3RF", typeof( String ) ) ); // 拠点自社電話番号3
            table.Columns.Add( new DataColumn( "COMPANYNMRF.COMPANYTELTITLE1RF", typeof( String ) ) ); // 拠点自社電話番号タイトル1
            table.Columns.Add( new DataColumn( "COMPANYNMRF.COMPANYTELTITLE2RF", typeof( String ) ) ); // 拠点自社電話番号タイトル2
            table.Columns.Add( new DataColumn( "COMPANYNMRF.COMPANYTELTITLE3RF", typeof( String ) ) ); // 拠点自社電話番号タイトル3
            table.Columns.Add( new DataColumn( "COMPANYNMRF.TRANSFERGUIDANCERF", typeof( String ) ) ); // 拠点銀行振込案内文
            table.Columns.Add( new DataColumn( "COMPANYNMRF.ACCOUNTNOINFO1RF", typeof( String ) ) ); // 拠点銀行口座1
            table.Columns.Add( new DataColumn( "COMPANYNMRF.ACCOUNTNOINFO2RF", typeof( String ) ) ); // 拠点銀行口座2
            table.Columns.Add( new DataColumn( "COMPANYNMRF.ACCOUNTNOINFO3RF", typeof( String ) ) ); // 拠点銀行口座3
            table.Columns.Add( new DataColumn( "COMPANYNMRF.COMPANYSETNOTE1RF", typeof( String ) ) ); // 拠点自社設定摘要1
            table.Columns.Add( new DataColumn( "COMPANYNMRF.COMPANYSETNOTE2RF", typeof( String ) ) ); // 拠点自社設定摘要2
            table.Columns.Add( new DataColumn( "COMPANYNMRF.COMPANYURLRF", typeof( String ) ) ); // 拠点自社URL
            table.Columns.Add( new DataColumn( "COMPANYNMRF.COMPANYPRSENTENCE2RF", typeof( String ) ) ); // 拠点自社PR文2
            table.Columns.Add( new DataColumn( "COMPANYNMRF.IMAGECOMMENTFORPRT1RF", typeof( String ) ) ); // 拠点画像印字用コメント1
            table.Columns.Add( new DataColumn( "COMPANYNMRF.IMAGECOMMENTFORPRT2RF", typeof( String ) ) ); // 拠点画像印字用コメント2
            table.Columns.Add( new DataColumn( "IMAGEINFORF.IMAGEINFODATARF", typeof( Byte[] ) ) ); // 拠点自社画像
            table.Columns.Add( new DataColumn( "COMPANYINFRF.COMPANYNAME1RF", typeof( String ) ) ); // 自社名称1
            table.Columns.Add( new DataColumn( "COMPANYINFRF.COMPANYNAME2RF", typeof( String ) ) ); // 自社名称2
            table.Columns.Add( new DataColumn( "COMPANYINFRF.POSTNORF", typeof( String ) ) ); // 郵便番号
            table.Columns.Add( new DataColumn( "COMPANYINFRF.ADDRESS1RF", typeof( String ) ) ); // 住所1（都道府県市区郡・町村・字）
            table.Columns.Add( new DataColumn( "COMPANYINFRF.ADDRESS3RF", typeof( String ) ) ); // 住所3（番地）
            table.Columns.Add( new DataColumn( "COMPANYINFRF.ADDRESS4RF", typeof( String ) ) ); // 住所4（アパート名称）
            table.Columns.Add( new DataColumn( "COMPANYINFRF.COMPANYTELNO1RF", typeof( String ) ) ); // 自社電話番号1
            table.Columns.Add( new DataColumn( "COMPANYINFRF.COMPANYTELNO2RF", typeof( String ) ) ); // 自社電話番号2
            table.Columns.Add( new DataColumn( "COMPANYINFRF.COMPANYTELNO3RF", typeof( String ) ) ); // 自社電話番号3
            table.Columns.Add( new DataColumn( "COMPANYINFRF.COMPANYTELTITLE1RF", typeof( String ) ) ); // 自社電話番号タイトル1
            table.Columns.Add( new DataColumn( "COMPANYINFRF.COMPANYTELTITLE2RF", typeof( String ) ) ); // 自社電話番号タイトル2
            table.Columns.Add( new DataColumn( "COMPANYINFRF.COMPANYTELTITLE3RF", typeof( String ) ) ); // 自社電話番号タイトル3
            table.Columns.Add( new DataColumn( "HEST.FOOTNOTES1RF", typeof( String ) ) ); // 脚注１
            table.Columns.Add( new DataColumn( "HEST.FOOTNOTES2RF", typeof( String ) ) ); // 脚注２
            table.Columns.Add( new DataColumn( "HEST.ESTIMATETITLE1RF", typeof( String ) ) ); // 見積タイトル１
            table.Columns.Add( new DataColumn( "HEST.ESTIMATETITLE2RF", typeof( String ) ) ); // 見積タイトル２
            table.Columns.Add( new DataColumn( "HEST.ESTIMATETITLE3RF", typeof( String ) ) ); // 見積タイトル３
            table.Columns.Add( new DataColumn( "HEST.ESTIMATETITLE4RF", typeof( String ) ) ); // 見積タイトル４
            table.Columns.Add( new DataColumn( "HEST.ESTIMATETITLE5RF", typeof( String ) ) ); // 見積タイトル５
            table.Columns.Add( new DataColumn( "HEST.ESTIMATENOTE1RF", typeof( String ) ) ); // 見積備考１
            table.Columns.Add( new DataColumn( "HEST.ESTIMATENOTE2RF", typeof( String ) ) ); // 見積備考２
            table.Columns.Add( new DataColumn( "HEST.ESTIMATENOTE3RF", typeof( String ) ) ); // 見積備考３
            table.Columns.Add( new DataColumn( "HEST.ESTIMATENOTE4RF", typeof( String ) ) ); // 見積備考４
            table.Columns.Add( new DataColumn( "HEST.ESTIMATENOTE5RF", typeof( String ) ) ); // 見積備考５
            table.Columns.Add( new DataColumn( "HEST.ESTIMATEVALIDITYLIMITRF", typeof( Int32 ) ) ); // 見積書有効期日
            table.Columns.Add( new DataColumn( "HEST.ESTIMATEVALIDITYLIMITFYRF", typeof( Int32 ) ) ); // 見積書有効期日西暦年
            table.Columns.Add( new DataColumn( "HEST.ESTIMATEVALIDITYLIMITFSRF", typeof( Int32 ) ) ); // 見積書有効期日西暦年略
            table.Columns.Add( new DataColumn( "HEST.ESTIMATEVALIDITYLIMITFWRF", typeof( Int32 ) ) ); // 見積書有効期日和暦年
            table.Columns.Add( new DataColumn( "HEST.ESTIMATEVALIDITYLIMITFMRF", typeof( Int32 ) ) ); // 見積書有効期日月
            table.Columns.Add( new DataColumn( "HEST.ESTIMATEVALIDITYLIMITFDRF", typeof( Int32 ) ) ); // 見積書有効期日日
            table.Columns.Add( new DataColumn( "HEST.ESTIMATEVALIDITYLIMITFGRF", typeof( String ) ) ); // 見積書有効期日元号
            table.Columns.Add( new DataColumn( "HEST.ESTIMATEVALIDITYLIMITFRRF", typeof( String ) ) ); // 見積書有効期日略号
            table.Columns.Add( new DataColumn( "HEST.ESTIMATEVALIDITYLIMITFLSRF", typeof( String ) ) ); // 見積書有効期日リテラル(/)
            table.Columns.Add( new DataColumn( "HEST.ESTIMATEVALIDITYLIMITFLPRF", typeof( String ) ) ); // 見積書有効期日リテラル(.)
            table.Columns.Add( new DataColumn( "HEST.ESTIMATEVALIDITYLIMITFLYRF", typeof( String ) ) ); // 見積書有効期日リテラル(年)
            table.Columns.Add( new DataColumn( "HEST.ESTIMATEVALIDITYLIMITFLMRF", typeof( String ) ) ); // 見積書有効期日リテラル(月)
            table.Columns.Add( new DataColumn( "HEST.ESTIMATEVALIDITYLIMITFLDRF", typeof( String ) ) ); // 見積書有効期日リテラル(日)
            table.Columns.Add( new DataColumn( "HADD.CARMNGNORF", typeof( Int32 ) ) ); // 車両管理番号
            table.Columns.Add( new DataColumn( "HADD.CARMNGCODERF", typeof( String ) ) ); // 車輌管理コード
            table.Columns.Add( new DataColumn( "HADD.NUMBERPLATE1CODERF", typeof( Int32 ) ) ); // 陸運事務所番号
            table.Columns.Add( new DataColumn( "HADD.NUMBERPLATE1NAMERF", typeof( String ) ) ); // 陸運事務局名称
            table.Columns.Add( new DataColumn( "HADD.NUMBERPLATE2RF", typeof( String ) ) ); // 車両登録番号（種別）
            table.Columns.Add( new DataColumn( "HADD.NUMBERPLATE3RF", typeof( String ) ) ); // 車両登録番号（カナ）
            table.Columns.Add( new DataColumn( "HADD.NUMBERPLATE4RF", typeof( Int32 ) ) ); // 車両登録番号（プレート番号）
            table.Columns.Add( new DataColumn( "HADD.FIRSTENTRYDATERF", typeof( Int32 ) ) ); // 初年度
            table.Columns.Add( new DataColumn( "HADD.MAKERCODERF", typeof( Int32 ) ) ); // メーカーコード
            table.Columns.Add( new DataColumn( "HADD.MAKERFULLNAMERF", typeof( String ) ) ); // メーカー全角名称
            table.Columns.Add( new DataColumn( "HADD.MAKERHALFNAMERF", typeof( String ) ) ); // メーカー半角名称
            table.Columns.Add( new DataColumn( "HADD.MODELCODERF", typeof( Int32 ) ) ); // 車種コード
            table.Columns.Add( new DataColumn( "HADD.MODELSUBCODERF", typeof( Int32 ) ) ); // 車種サブコード
            table.Columns.Add( new DataColumn( "HADD.MODELFULLNAMERF", typeof( String ) ) ); // 車種全角名称
            table.Columns.Add( new DataColumn( "HADD.MODELHALFNAMERF", typeof( String ) ) ); // 車種半角名称
            table.Columns.Add( new DataColumn( "HADD.EXHAUSTGASSIGNRF", typeof( String ) ) ); // 排ガス記号
            table.Columns.Add( new DataColumn( "HADD.SERIESMODELRF", typeof( String ) ) ); // シリーズ型式
            table.Columns.Add( new DataColumn( "HADD.CATEGORYSIGNMODELRF", typeof( String ) ) ); // 型式（類別記号）
            table.Columns.Add( new DataColumn( "HADD.FULLMODELRF", typeof( String ) ) ); // 型式（フル型）
            table.Columns.Add( new DataColumn( "HADD.MODELDESIGNATIONNORF", typeof( Int32 ) ) ); // 型式指定番号
            table.Columns.Add( new DataColumn( "HADD.CATEGORYNORF", typeof( Int32 ) ) ); // 類別番号
            table.Columns.Add( new DataColumn( "HADD.FRAMEMODELRF", typeof( String ) ) ); // 車台型式
            table.Columns.Add( new DataColumn( "HADD.FRAMENORF", typeof( String ) ) ); // 車台番号
            table.Columns.Add( new DataColumn( "HADD.SEARCHFRAMENORF", typeof( Int32 ) ) ); // 車台番号（検索用）
            table.Columns.Add( new DataColumn( "HADD.ENGINEMODELNMRF", typeof( String ) ) ); // エンジン型式名称
            table.Columns.Add( new DataColumn( "HADD.RELEVANCEMODELRF", typeof( String ) ) ); // 関連型式
            table.Columns.Add( new DataColumn( "HADD.SUBCARNMCDRF", typeof( Int32 ) ) ); // サブ車名コード
            table.Columns.Add( new DataColumn( "HADD.MODELGRADESNAMERF", typeof( String ) ) ); // 型式グレード略称
            table.Columns.Add( new DataColumn( "HADD.COLORCODERF", typeof( String ) ) ); // カラーコード
            table.Columns.Add( new DataColumn( "HADD.COLORNAME1RF", typeof( String ) ) ); // カラー名称1
            table.Columns.Add( new DataColumn( "HADD.TRIMCODERF", typeof( String ) ) ); // トリムコード
            table.Columns.Add( new DataColumn( "HADD.TRIMNAMERF", typeof( String ) ) ); // トリム名称
            table.Columns.Add( new DataColumn( "HADD.MILEAGERF", typeof( Int32 ) ) ); // 車両走行距離
            table.Columns.Add( new DataColumn( "HADD.PRINTERMNGNORF", typeof( Int32 ) ) ); // プリンタ管理No
            table.Columns.Add( new DataColumn( "HADD.SLIPPRTSETPAPERIDRF", typeof( String ) ) ); // 伝票印刷設定用帳票ID
            table.Columns.Add( new DataColumn( "HADD.NOTE1RF", typeof( String ) ) ); // 自社備考１
            table.Columns.Add( new DataColumn( "HADD.NOTE2RF", typeof( String ) ) ); // 自社備考２
            table.Columns.Add( new DataColumn( "HADD.NOTE3RF", typeof( String ) ) ); // 自社備考３
            table.Columns.Add( new DataColumn( "HADD.FIRSTENTRYDATEFYRF", typeof( Int32 ) ) ); // 初年度西暦年
            table.Columns.Add( new DataColumn( "HADD.FIRSTENTRYDATEFSRF", typeof( Int32 ) ) ); // 初年度西暦年略
            table.Columns.Add( new DataColumn( "HADD.FIRSTENTRYDATEFWRF", typeof( Int32 ) ) ); // 初年度和暦年
            table.Columns.Add( new DataColumn( "HADD.FIRSTENTRYDATEFMRF", typeof( Int32 ) ) ); // 初年度月
            table.Columns.Add( new DataColumn( "HADD.FIRSTENTRYDATEFGRF", typeof( String ) ) ); // 初年度元号
            table.Columns.Add( new DataColumn( "HADD.FIRSTENTRYDATEFRRF", typeof( String ) ) ); // 初年度略号
            table.Columns.Add( new DataColumn( "HADD.FIRSTENTRYDATEFLSRF", typeof( String ) ) ); // 初年度リテラル(/)
            table.Columns.Add( new DataColumn( "HADD.FIRSTENTRYDATEFLPRF", typeof( String ) ) ); // 初年度リテラル(.)
            table.Columns.Add( new DataColumn( "HADD.FIRSTENTRYDATEFLYRF", typeof( String ) ) ); // 初年度リテラル(年)
            table.Columns.Add( new DataColumn( "HADD.FIRSTENTRYDATEFLMRF", typeof( String ) ) ); // 初年度リテラル(月)
            table.Columns.Add( new DataColumn( "HADD.PRINTCUSTOMERNM1RF", typeof( String ) ) ); // 印刷用得意先名称(上段)
            table.Columns.Add( new DataColumn( "HADD.PRINTCUSTOMERNM2RF", typeof( String ) ) ); // 印刷用得意先名称(下段)
            table.Columns.Add( new DataColumn( "HPURE.SALESTOTALTAXINCRF", typeof( Int64 ) ) ); // 純正売上伝票合計（税込み）
            table.Columns.Add( new DataColumn( "HPURE.SALESTOTALTAXEXCRF", typeof( Int64 ) ) ); // 純正売上伝票合計（税抜き）
            table.Columns.Add( new DataColumn( "HPURE.SALESSUBTOTALTAXINCRF", typeof( Int64 ) ) ); // 純正売上小計（税込み）
            table.Columns.Add( new DataColumn( "HPURE.SALESSUBTOTALTAXEXCRF", typeof( Int64 ) ) ); // 純正売上小計（税抜き）
            table.Columns.Add( new DataColumn( "HPURE.SALESSUBTOTALTAXRF", typeof( Int64 ) ) ); // 純正売上小計（税）
            table.Columns.Add( new DataColumn( "HPRIME.SALESTOTALTAXINCRF", typeof( Int64 ) ) ); // 優良売上伝票合計（税込み）
            table.Columns.Add( new DataColumn( "HPRIME.SALESTOTALTAXEXCRF", typeof( Int64 ) ) ); // 優良売上伝票合計（税抜き）
            table.Columns.Add( new DataColumn( "HPRIME.SALESSUBTOTALTAXINCRF", typeof( Int64 ) ) ); // 優良売上小計（税込み）
            table.Columns.Add( new DataColumn( "HPRIME.SALESSUBTOTALTAXEXCRF", typeof( Int64 ) ) ); // 優良売上小計（税抜き）
            table.Columns.Add( new DataColumn( "HPRIME.SALESSUBTOTALTAXRF", typeof( Int64 ) ) ); // 優良売上小計（税）
            table.Columns.Add( new DataColumn( "HADD.PRINTTIMEHOURRF", typeof( Int32 ) ) ); // 印刷時刻 時
            table.Columns.Add( new DataColumn( "HADD.PRINTTIMEMINUTERF", typeof( Int32 ) ) ); // 印刷時刻 分
            table.Columns.Add( new DataColumn( "HADD.PRINTTIMESECONDRF", typeof( Int32 ) ) ); // 印刷時刻 秒
            table.Columns.Add( new DataColumn( "HADD.ESTFMDIVRF", typeof( Int32 ) ) ); // 見積書印刷制御区分
            table.Columns.Add( new DataColumn( "HADD.SALESDATEFYRF", typeof( Int32 ) ) ); // 売上日付西暦年
            table.Columns.Add( new DataColumn( "HADD.SALESDATEFSRF", typeof( Int32 ) ) ); // 売上日付西暦年略
            table.Columns.Add( new DataColumn( "HADD.SALESDATEFWRF", typeof( Int32 ) ) ); // 売上日付和暦年
            table.Columns.Add( new DataColumn( "HADD.SALESDATEFMRF", typeof( Int32 ) ) ); // 売上日付月
            table.Columns.Add( new DataColumn( "HADD.SALESDATEFDRF", typeof( Int32 ) ) ); // 売上日付日
            table.Columns.Add( new DataColumn( "HADD.SALESDATEFGRF", typeof( String ) ) ); // 売上日付元号
            table.Columns.Add( new DataColumn( "HADD.SALESDATEFRRF", typeof( String ) ) ); // 売上日付略号
            table.Columns.Add( new DataColumn( "HADD.SALESDATEFLSRF", typeof( String ) ) ); // 売上日付リテラル(/)
            table.Columns.Add( new DataColumn( "HADD.SALESDATEFLPRF", typeof( String ) ) ); // 売上日付リテラル(.)
            table.Columns.Add( new DataColumn( "HADD.SALESDATEFLYRF", typeof( String ) ) ); // 売上日付リテラル(年)
            table.Columns.Add( new DataColumn( "HADD.SALESDATEFLMRF", typeof( String ) ) ); // 売上日付リテラル(月)
            table.Columns.Add( new DataColumn( "HADD.SALESDATEFLDRF", typeof( String ) ) ); // 売上日付リテラル(日)
            table.Columns.Add( new DataColumn( "HADD.SALESSLIPPRINTDATEFYRF", typeof( Int32 ) ) ); // 売上伝票発行日西暦年
            table.Columns.Add( new DataColumn( "HADD.SALESSLIPPRINTDATEFSRF", typeof( Int32 ) ) ); // 売上伝票発行日西暦年略
            table.Columns.Add( new DataColumn( "HADD.SALESSLIPPRINTDATEFWRF", typeof( Int32 ) ) ); // 売上伝票発行日和暦年
            table.Columns.Add( new DataColumn( "HADD.SALESSLIPPRINTDATEFMRF", typeof( Int32 ) ) ); // 売上伝票発行日月
            table.Columns.Add( new DataColumn( "HADD.SALESSLIPPRINTDATEFDRF", typeof( Int32 ) ) ); // 売上伝票発行日日
            table.Columns.Add( new DataColumn( "HADD.SALESSLIPPRINTDATEFGRF", typeof( String ) ) ); // 売上伝票発行日元号
            table.Columns.Add( new DataColumn( "HADD.SALESSLIPPRINTDATEFRRF", typeof( String ) ) ); // 売上伝票発行日略号
            table.Columns.Add( new DataColumn( "HADD.SALESSLIPPRINTDATEFLSRF", typeof( String ) ) ); // 売上伝票発行日リテラル(/)
            table.Columns.Add( new DataColumn( "HADD.SALESSLIPPRINTDATEFLPRF", typeof( String ) ) ); // 売上伝票発行日リテラル(.)
            table.Columns.Add( new DataColumn( "HADD.SALESSLIPPRINTDATEFLYRF", typeof( String ) ) ); // 売上伝票発行日リテラル(年)
            table.Columns.Add( new DataColumn( "HADD.SALESSLIPPRINTDATEFLMRF", typeof( String ) ) ); // 売上伝票発行日リテラル(月)
            table.Columns.Add( new DataColumn( "HADD.SALESSLIPPRINTDATEFLDRF", typeof( String ) ) ); // 売上伝票発行日リテラル(日)
            table.Columns.Add( new DataColumn( "HADD.SYSTEMATICCODERF", typeof( Int32 ) ) ); // 系統コード
            table.Columns.Add( new DataColumn( "HADD.SYSTEMATICNAMERF", typeof( String ) ) ); // 系統名称
            table.Columns.Add( new DataColumn( "HADD.STPRODUCETYPEOFYEARRF", typeof( Int32 ) ) ); // 開始生産年式
            table.Columns.Add( new DataColumn( "HADD.EDPRODUCETYPEOFYEARRF", typeof( Int32 ) ) ); // 終了生産年式
            table.Columns.Add( new DataColumn( "HADD.DOORCOUNTRF", typeof( Int32 ) ) ); // ドア数
            table.Columns.Add( new DataColumn( "HADD.BODYNAMECODERF", typeof( Int32 ) ) ); // ボディー名コード
            table.Columns.Add( new DataColumn( "HADD.BODYNAMERF", typeof( String ) ) ); // ボディー名称
            table.Columns.Add( new DataColumn( "HADD.STPRODUCEFRAMENORF", typeof( Int32 ) ) ); // 生産車台番号開始
            table.Columns.Add( new DataColumn( "HADD.EDPRODUCEFRAMENORF", typeof( Int32 ) ) ); // 生産車台番号終了
            table.Columns.Add( new DataColumn( "HADD.ENGINEMODELRF", typeof( String ) ) ); // 原動機型式（エンジン）
            table.Columns.Add( new DataColumn( "HADD.MODELGRADENMRF", typeof( String ) ) ); // 型式グレード名称
            table.Columns.Add( new DataColumn( "HADD.ENGINEDISPLACENMRF", typeof( String ) ) ); // 排気量名称
            table.Columns.Add( new DataColumn( "HADD.EDIVNMRF", typeof( String ) ) ); // E区分名称
            table.Columns.Add( new DataColumn( "HADD.TRANSMISSIONNMRF", typeof( String ) ) ); // ミッション名称
            table.Columns.Add( new DataColumn( "HADD.SHIFTNMRF", typeof( String ) ) ); // シフト名称
            table.Columns.Add( new DataColumn( "HADD.WHEELDRIVEMETHODNMRF", typeof( String ) ) ); // 駆動方式名称
            table.Columns.Add( new DataColumn( "HADD.ADDICARSPEC1RF", typeof( String ) ) ); // 追加諸元1
            table.Columns.Add( new DataColumn( "HADD.ADDICARSPEC2RF", typeof( String ) ) ); // 追加諸元2
            table.Columns.Add( new DataColumn( "HADD.ADDICARSPEC3RF", typeof( String ) ) ); // 追加諸元3
            table.Columns.Add( new DataColumn( "HADD.ADDICARSPEC4RF", typeof( String ) ) ); // 追加諸元4
            table.Columns.Add( new DataColumn( "HADD.ADDICARSPEC5RF", typeof( String ) ) ); // 追加諸元5
            table.Columns.Add( new DataColumn( "HADD.ADDICARSPEC6RF", typeof( String ) ) ); // 追加諸元6
            table.Columns.Add( new DataColumn( "HADD.ADDICARSPECTITLE1RF", typeof( String ) ) ); // 追加諸元タイトル1
            table.Columns.Add( new DataColumn( "HADD.ADDICARSPECTITLE2RF", typeof( String ) ) ); // 追加諸元タイトル2
            table.Columns.Add( new DataColumn( "HADD.ADDICARSPECTITLE3RF", typeof( String ) ) ); // 追加諸元タイトル3
            table.Columns.Add( new DataColumn( "HADD.ADDICARSPECTITLE4RF", typeof( String ) ) ); // 追加諸元タイトル4
            table.Columns.Add( new DataColumn( "HADD.ADDICARSPECTITLE5RF", typeof( String ) ) ); // 追加諸元タイトル5
            table.Columns.Add( new DataColumn( "HADD.ADDICARSPECTITLE6RF", typeof( String ) ) ); // 追加諸元タイトル6
            table.Columns.Add( new DataColumn( "HADD.STPRODUCETYPEOFYEARFYRF", typeof( Int32 ) ) ); // 開始生産年式西暦年
            table.Columns.Add( new DataColumn( "HADD.STPRODUCETYPEOFYEARFSRF", typeof( Int32 ) ) ); // 開始生産年式西暦年略
            table.Columns.Add( new DataColumn( "HADD.STPRODUCETYPEOFYEARFWRF", typeof( Int32 ) ) ); // 開始生産年式和暦年
            table.Columns.Add( new DataColumn( "HADD.STPRODUCETYPEOFYEARFMRF", typeof( Int32 ) ) ); // 開始生産年式月
            table.Columns.Add( new DataColumn( "HADD.STPRODUCETYPEOFYEARFGRF", typeof( String ) ) ); // 開始生産年式元号
            table.Columns.Add( new DataColumn( "HADD.STPRODUCETYPEOFYEARFRRF", typeof( String ) ) ); // 開始生産年式略号
            table.Columns.Add( new DataColumn( "HADD.STPRODUCETYPEOFYEARFLSRF", typeof( String ) ) ); // 開始生産年式リテラル(/)
            table.Columns.Add( new DataColumn( "HADD.STPRODUCETYPEOFYEARFLPRF", typeof( String ) ) ); // 開始生産年式リテラル(.)
            table.Columns.Add( new DataColumn( "HADD.STPRODUCETYPEOFYEARFLYRF", typeof( String ) ) ); // 開始生産年式リテラル(年)
            table.Columns.Add( new DataColumn( "HADD.STPRODUCETYPEOFYEARFLMRF", typeof( String ) ) ); // 開始生産年式リテラル(月)
            table.Columns.Add( new DataColumn( "HADD.EDPRODUCETYPEOFYEARFYRF", typeof( Int32 ) ) ); // 終了生産年式西暦年
            table.Columns.Add( new DataColumn( "HADD.EDPRODUCETYPEOFYEARFSRF", typeof( Int32 ) ) ); // 終了生産年式西暦年略
            table.Columns.Add( new DataColumn( "HADD.EDPRODUCETYPEOFYEARFWRF", typeof( Int32 ) ) ); // 終了生産年式和暦年
            table.Columns.Add( new DataColumn( "HADD.EDPRODUCETYPEOFYEARFMRF", typeof( Int32 ) ) ); // 終了生産年式月
            table.Columns.Add( new DataColumn( "HADD.EDPRODUCETYPEOFYEARFGRF", typeof( String ) ) ); // 終了生産年式元号
            table.Columns.Add( new DataColumn( "HADD.EDPRODUCETYPEOFYEARFRRF", typeof( String ) ) ); // 終了生産年式略号
            table.Columns.Add( new DataColumn( "HADD.EDPRODUCETYPEOFYEARFLSRF", typeof( String ) ) ); // 終了生産年式リテラル(/)
            table.Columns.Add( new DataColumn( "HADD.EDPRODUCETYPEOFYEARFLPRF", typeof( String ) ) ); // 終了生産年式リテラル(.)
            table.Columns.Add( new DataColumn( "HADD.EDPRODUCETYPEOFYEARFLYRF", typeof( String ) ) ); // 終了生産年式リテラル(年)
            table.Columns.Add( new DataColumn( "HADD.EDPRODUCETYPEOFYEARFLMRF", typeof( String ) ) ); // 終了生産年式リテラル(月)
            # endregion

            # region [スキーマ定義（明細項目）]
            table.Columns.Add( new DataColumn( "SALESDETAILRF.SALESSLIPNUMRF", typeof( String ) ) ); // 売上伝票番号
            table.Columns.Add( new DataColumn( "SALESDETAILRF.SALESROWNORF", typeof( Int32 ) ) ); // 売上行番号
            table.Columns.Add( new DataColumn( "DPURE.GOODSMAKERCDRF", typeof( Int32 ) ) ); // 純正商品メーカーコード
            table.Columns.Add( new DataColumn( "DPURE.MAKERNAMERF", typeof( String ) ) ); // 純正メーカー名称
            table.Columns.Add( new DataColumn( "DPURE.MAKERKANANAMERF", typeof( String ) ) ); // 純正メーカーカナ名称
            table.Columns.Add( new DataColumn( "DPURE.GOODSNORF", typeof( String ) ) ); // 純正商品番号
            table.Columns.Add( new DataColumn( "DPURE.GOODSNAMERF", typeof( String ) ) ); // 純正商品名称
            table.Columns.Add( new DataColumn( "DPURE.GOODSNAMEKANARF", typeof( String ) ) ); // 純正商品名称カナ
            table.Columns.Add( new DataColumn( "DPURE.BLGOODSCODERF", typeof( Int32 ) ) ); // 純正BL商品コード
            table.Columns.Add( new DataColumn( "DPURE.SALESUNPRCTAXINCFLRF", typeof( Double ) ) ); // 純正売上単価（税込，浮動）
            table.Columns.Add( new DataColumn( "DPURE.SALESUNPRCTAXEXCFLRF", typeof( Double ) ) ); // 純正売上単価（税抜，浮動）
            table.Columns.Add( new DataColumn( "DPURE.LISTPRICETAXINCFLRF", typeof( Double ) ) ); // 純正定価（税込，浮動）
            table.Columns.Add( new DataColumn( "DPURE.LISTPRICETAXEXCFLRF", typeof( Double ) ) ); // 純正定価（税抜，浮動）
            table.Columns.Add( new DataColumn( "DPURE.SALESMONEYTAXINCRF", typeof( Int64 ) ) ); // 純正売上金額（税込み）
            table.Columns.Add( new DataColumn( "DPURE.SALESMONEYTAXEXCRF", typeof( Int64 ) ) ); // 純正売上金額（税抜き）
            table.Columns.Add( new DataColumn( "DPURE.TAXATIONDIVCDRF", typeof( Int32 ) ) ); // 純正課税区分
            table.Columns.Add( new DataColumn( "DPURE.SALESUNPRCFLRF", typeof( Double ) ) ); // 純正売上単価
            table.Columns.Add( new DataColumn( "DPURE.LISTPRICERF", typeof( Double ) ) ); // 純正定価
            table.Columns.Add( new DataColumn( "DPURE.SHIPMENTCNTRF", typeof( Double ) ) ); // 純正出荷数
            table.Columns.Add( new DataColumn( "DPURE.SALESMONEYRF", typeof( Int64 ) ) ); // 純正売上金額
            table.Columns.Add( new DataColumn( "DPRIM.GOODSMAKERCDRF", typeof( Int32 ) ) ); // 優良商品メーカーコード
            table.Columns.Add( new DataColumn( "DPRIM.MAKERNAMERF", typeof( String ) ) ); // 優良メーカー名称
            table.Columns.Add( new DataColumn( "DPRIM.MAKERKANANAMERF", typeof( String ) ) ); // 優良メーカーカナ名称
            table.Columns.Add( new DataColumn( "DPRIM.GOODSNORF", typeof( String ) ) ); // 優良商品番号
            table.Columns.Add( new DataColumn( "DPRIM.GOODSNAMERF", typeof( String ) ) ); // 優良商品名称
            table.Columns.Add( new DataColumn( "DPRIM.GOODSNAMEKANARF", typeof( String ) ) ); // 優良商品名称カナ
            table.Columns.Add( new DataColumn( "DPRIM.BLGOODSCODERF", typeof( Int32 ) ) ); // 優良BL商品コード
            table.Columns.Add( new DataColumn( "DPRIM.SALESUNPRCTAXINCFLRF", typeof( Double ) ) ); // 優良売上単価（税込，浮動）
            table.Columns.Add( new DataColumn( "DPRIM.SALESUNPRCTAXEXCFLRF", typeof( Double ) ) ); // 優良売上単価（税抜，浮動）
            table.Columns.Add( new DataColumn( "DPRIM.LISTPRICETAXINCFLRF", typeof( Double ) ) ); // 優良定価（税込，浮動）
            table.Columns.Add( new DataColumn( "DPRIM.LISTPRICETAXEXCFLRF", typeof( Double ) ) ); // 優良定価（税抜，浮動）
            table.Columns.Add( new DataColumn( "DPRIM.SALESMONEYTAXINCRF", typeof( Int64 ) ) ); // 優良売上金額（税込み）
            table.Columns.Add( new DataColumn( "DPRIM.SALESMONEYTAXEXCRF", typeof( Int64 ) ) ); // 優良売上金額（税抜き）
            table.Columns.Add( new DataColumn( "DPRIM.TAXATIONDIVCDRF", typeof( Int32 ) ) ); // 優良課税区分
            table.Columns.Add( new DataColumn( "DPRIM.SALESUNPRCFLRF", typeof( Double ) ) ); // 優良売上単価
            table.Columns.Add( new DataColumn( "DPRIM.LISTPRICERF", typeof( Double ) ) ); // 優良定価
            table.Columns.Add( new DataColumn( "DPRIM.SHIPMENTCNTRF", typeof( Double ) ) ); // 優良出荷数
            table.Columns.Add( new DataColumn( "DPRIM.SALESMONEYRF", typeof( Int64 ) ) ); // 優良売上金額
            table.Columns.Add( new DataColumn( "DADD.SPECIALNOTERF", typeof( String ) ) ); // オプション・規格情報
            # endregion

            # region [制御項目]
            table.Columns.Add( new DataColumn( ct_InPageCopyTitle1, typeof( string ) ) );  // 複写タイトル
            table.Columns.Add( new DataColumn( ct_InPageCopyTitle2, typeof( string ) ) );  // 複写タイトル
            table.Columns.Add( new DataColumn( ct_InPageCopyTitle3, typeof( string ) ) );  // 複写タイトル
            table.Columns.Add( new DataColumn( ct_InPageCopyTitle4, typeof( string ) ) );  // 複写タイトル
            table.Columns.Add( new DataColumn( ct_InPageCopyCount, typeof( int ) ) );  // 同一ページ内コピーカウント
            table.Columns.Add( new DataColumn( ct_PageCount, typeof( int ) ) ); // 頁数
            table.Columns.Add( new DataColumn( ct_HCategoryHyp, typeof( string ) ) );  // (先頭)類別型式ハイフン
            table.Columns.Add( new DataColumn( ct_HPrintCustomerNameJoin12, typeof( string ) ) );  // (先頭)類別型式ハイフン
            table.Columns.Add( new DataColumn( ct_HPrintCustomerNameJoinHn12, typeof( string ) ) );  // (先頭)類別型式ハイフン
            table.Columns.Add( new DataColumn( ct_HPrintEnterpriseName1FH, typeof( string ) ) );  // (先頭)類別型式ハイフン
            table.Columns.Add( new DataColumn( ct_HPrintEnterpriseName1LH, typeof( string ) ) );  // (先頭)類別型式ハイフン
            table.Columns.Add( new DataColumn( ct_HPrintEnterpriseName2FH, typeof( string ) ) );  // (先頭)類別型式ハイフン
            table.Columns.Add( new DataColumn( ct_HPrintEnterpriseName2LH, typeof( string ) ) );  // (先頭)類別型式ハイフン
            table.Columns.Add( new DataColumn( "HLG.PRINTCUSTOMERNAMEJOIN12RF", typeof( string ) ) );  // （縦倍）得意先名１＋得意先名２
            table.Columns.Add( new DataColumn( "HLG.PRINTCUSTOMERNAMEJOIN12HNRF", typeof( string ) ) );  // （縦倍）得意先名１＋得意先名２＋敬称
            table.Columns.Add( new DataColumn( "HLG.CUSTOMERNAMERF", typeof( string ) ) );  // （縦倍）得意先名称
            table.Columns.Add( new DataColumn( "HLG.CUSTOMERNAME2RF", typeof( string ) ) );  // （縦倍）得意先名称2
            table.Columns.Add( new DataColumn( "HLG.CUSTOMERSNMRF", typeof( string ) ) );  // （縦倍）得意先略称
            table.Columns.Add( new DataColumn( "HLG.HONORIFICTITLERF", typeof( string ) ) );  // （縦倍）得意先敬称
            table.Columns.Add( new DataColumn( "HLG.PRINTCUSTOMERNM1RF", typeof( string ) ) );  // （縦倍）印刷用得意先名称(上段)
            table.Columns.Add( new DataColumn( "HLG.PRINTCUSTOMERNM2RF", typeof( string ) ) );  // （縦倍）印刷用得意先名称(下段)
            # endregion

            return table;
        }
        # endregion

        # region [データ移行（DataClass→DataTable）]
        /// <summary>
        /// データ移行処理
        /// </summary>
        /// <param name="table"></param>
        /// <param name="slipWork"></param>
        /// <param name="detailWorks"></param>
        /// <param name="slipPrtSet"></param>
        /// <param name="frePrtPSetWork"></param>
        /// <param name="slipPrintParameter"></param>
        /// <param name="estimateDefSet"></param>
        public static void CopyToDataTable( ref DataTable table, FrePEstFmHead slipWork, List<FrePEstFmDetail> detailWorks, SlipPrtSetWork slipPrtSet, EachSlipTypeSet eachSlipTypeSet,FrePrtPSetWork frePrtPSetWork, SlipPrintParameter slipPrintParameter, EstimateDefSet estimateDefSet, AllDefSetWork allDefSet, Dictionary<string, string> columnVisibleTypeDic )
        {
            //----------------------------------------------------
            // 以下の処理は、基本的に次のポリシーに従い記述します。
            // 
            // 　・伝票情報に対する、固定名称のセットなどは
            // 　　forの前に予め行います。
            //    （１回で終わらせる為）
            // 
            // 　・明細情報に対する処理は、forの中で行います。
            //   　（ループを２回まわさない為）
            //
            // ※原則は処理速度を重視します。
            //----------------------------------------------------

            # region [時刻]
            DateTime printTime = DateTime.Now;
            slipWork.HADD_PRINTTIMEHOURRF = printTime.Hour;
            slipWork.HADD_PRINTTIMEMINUTERF = printTime.Minute;
            slipWork.HADD_PRINTTIMESECONDRF = printTime.Second;
            # endregion

            # region [伝票データの編集]
            
            // 見積書発行日（←システム日付をセット）
            //   ※UI入力した日付は伝票日付にセットされている。
            slipWork.SALESSLIPRF_SALESSLIPPRINTDATERF = DateTime.Today;

            // 伝票番号ゼロ
            if ( IsZero( slipWork.SALESSLIPRF_SALESSLIPNUMRF ) )
            {
                slipWork.SALESSLIPRF_SALESSLIPNUMRF = string.Empty;
            }
            // 見積書番号（←伝票番号をセット）
            slipWork.SALESSLIPRF_ESTIMATEFORMNORF = slipWork.SALESSLIPRF_SALESSLIPNUMRF;

            // 敬称
            if ( string.IsNullOrEmpty( slipWork.SALESSLIPRF_HONORIFICTITLERF ) )
            {
                slipWork.SALESSLIPRF_HONORIFICTITLERF = slipPrtSet.HonorificTitle;
            }
            
            # endregion


            // 伝票タイトル取得処理
            List<List<string>> inPageCopyTitle = GetInPageCopyTitles( slipPrtSet );

            // １ページ内の行数算出
            int feedCount = GetFeedCount( frePrtPSetWork, slipWork, estimateDefSet );

            // 明細総行数の算出
            int allDetailCount = GetAllDetailCount( detailWorks.Count, feedCount );

            for ( int inPageCopyCount = 0; inPageCopyCount < inPageCopyTitle[0].Count; inPageCopyCount++ )
            {
                // 明細行移行
                //for ( int index = 0; index < slipPrtSet.DetailRowCount; index++ )
                for ( int index = 0; index < allDetailCount; index++ )
                {
                    DataRow row = table.NewRow();

                    // ※改ページ制御に使用するので、全明細にセットする。
                    // ページ数
                    row[ct_PageCount] = GetPageCount( index, feedCount );

                    // 最初のレコード／最後のレコードのみ伝票項目をセットする。
                    // (単純に明細の数だけ倍増させない為)
                    // なおここでの"最後のレコード"とは空白行の可能性も含む。
                    //if ( index == 0 || index == slipPrtSet.DetailRowCount - 1 )
                    if ( index % feedCount == 0 || (index + 1) % feedCount == 0 )
                    {
                        # region [伝票項目Copy]
                        row["SALESSLIPRF.SALESSLIPNUMRF"] = slipWork.SALESSLIPRF_SALESSLIPNUMRF; // 売上伝票番号
                        row["SALESSLIPRF.SECTIONCODERF"] = slipWork.SALESSLIPRF_SECTIONCODERF; // 拠点コード
                        //row["SALESSLIPRF.SALESDATERF"] = slipWork.SALESSLIPRF_SALESDATERF; // 売上日付
                        row["SALESSLIPRF.ESTIMATEFORMNORF"] = slipWork.SALESSLIPRF_ESTIMATEFORMNORF; // 見積書番号
                        row["SALESSLIPRF.ESTIMATEDIVIDERF"] = slipWork.SALESSLIPRF_ESTIMATEDIVIDERF; // 見積区分
                        row["SALESSLIPRF.SALESINPUTCODERF"] = slipWork.SALESSLIPRF_SALESINPUTCODERF; // 売上入力者コード
                        row["SALESSLIPRF.SALESINPUTNAMERF"] = slipWork.SALESSLIPRF_SALESINPUTNAMERF; // 売上入力者名称
                        row["SALESSLIPRF.FRONTEMPLOYEECDRF"] = slipWork.SALESSLIPRF_FRONTEMPLOYEECDRF; // 受付従業員コード
                        row["SALESSLIPRF.FRONTEMPLOYEENMRF"] = slipWork.SALESSLIPRF_FRONTEMPLOYEENMRF; // 受付従業員名称
                        row["SALESSLIPRF.SALESEMPLOYEECDRF"] = slipWork.SALESSLIPRF_SALESEMPLOYEECDRF; // 販売従業員コード
                        row["SALESSLIPRF.SALESEMPLOYEENMRF"] = slipWork.SALESSLIPRF_SALESEMPLOYEENMRF; // 販売従業員名称
                        row["SALESSLIPRF.CONSTAXLAYMETHODRF"] = slipWork.SALESSLIPRF_CONSTAXLAYMETHODRF; // 消費税転嫁方式
                        row["SALESSLIPRF.CUSTOMERCODERF"] = slipWork.SALESSLIPRF_CUSTOMERCODERF; // 得意先コード
                        row["SALESSLIPRF.CUSTOMERNAMERF"] = slipWork.SALESSLIPRF_CUSTOMERNAMERF; // 得意先名称
                        row["SALESSLIPRF.CUSTOMERNAME2RF"] = slipWork.SALESSLIPRF_CUSTOMERNAME2RF; // 得意先名称2
                        row["SALESSLIPRF.CUSTOMERSNMRF"] = slipWork.SALESSLIPRF_CUSTOMERSNMRF; // 得意先略称
                        row["SALESSLIPRF.HONORIFICTITLERF"] = slipWork.SALESSLIPRF_HONORIFICTITLERF; // 得意先敬称
                        //row["SALESSLIPRF.SALESSLIPPRINTDATERF"] = slipWork.SALESSLIPRF_SALESSLIPPRINTDATERF; // 売上伝票発行日
                        row["SALESSLIPRF.TOTALAMOUNTDISPWAYCDRF"] = slipWork.SALESSLIPRF_TOTALAMOUNTDISPWAYCDRF; // 総額表示方法区分
                        row["SECINFOSETRF.SECTIONGUIDENMRF"] = slipWork.SECINFOSETRF_SECTIONGUIDENMRF; // 拠点ガイド名称
                        row["COMPANYNMRF.COMPANYPRRF"] = slipWork.COMPANYNMRF_COMPANYPRRF; // 拠点自社PR文
                        row["COMPANYNMRF.COMPANYNAME1RF"] = slipWork.COMPANYNMRF_COMPANYNAME1RF; // 拠点自社名称1
                        row["COMPANYNMRF.COMPANYNAME2RF"] = slipWork.COMPANYNMRF_COMPANYNAME2RF; // 拠点自社名称2
                        row["COMPANYNMRF.POSTNORF"] = slipWork.COMPANYNMRF_POSTNORF; // 拠点郵便番号
                        row["COMPANYNMRF.ADDRESS1RF"] = slipWork.COMPANYNMRF_ADDRESS1RF; // 拠点住所1（都道府県市区郡・町村・字）
                        row["COMPANYNMRF.ADDRESS3RF"] = slipWork.COMPANYNMRF_ADDRESS3RF; // 拠点住所3（番地）
                        row["COMPANYNMRF.ADDRESS4RF"] = slipWork.COMPANYNMRF_ADDRESS4RF; // 拠点住所4（アパート名称）
                        row["COMPANYNMRF.COMPANYTELNO1RF"] = slipWork.COMPANYNMRF_COMPANYTELNO1RF; // 拠点自社電話番号1
                        row["COMPANYNMRF.COMPANYTELNO2RF"] = slipWork.COMPANYNMRF_COMPANYTELNO2RF; // 拠点自社電話番号2
                        row["COMPANYNMRF.COMPANYTELNO3RF"] = slipWork.COMPANYNMRF_COMPANYTELNO3RF; // 拠点自社電話番号3
                        row["COMPANYNMRF.COMPANYTELTITLE1RF"] = slipWork.COMPANYNMRF_COMPANYTELTITLE1RF; // 拠点自社電話番号タイトル1
                        row["COMPANYNMRF.COMPANYTELTITLE2RF"] = slipWork.COMPANYNMRF_COMPANYTELTITLE2RF; // 拠点自社電話番号タイトル2
                        row["COMPANYNMRF.COMPANYTELTITLE3RF"] = slipWork.COMPANYNMRF_COMPANYTELTITLE3RF; // 拠点自社電話番号タイトル3
                        row["COMPANYNMRF.TRANSFERGUIDANCERF"] = slipWork.COMPANYNMRF_TRANSFERGUIDANCERF; // 拠点銀行振込案内文
                        row["COMPANYNMRF.ACCOUNTNOINFO1RF"] = slipWork.COMPANYNMRF_ACCOUNTNOINFO1RF; // 拠点銀行口座1
                        row["COMPANYNMRF.ACCOUNTNOINFO2RF"] = slipWork.COMPANYNMRF_ACCOUNTNOINFO2RF; // 拠点銀行口座2
                        row["COMPANYNMRF.ACCOUNTNOINFO3RF"] = slipWork.COMPANYNMRF_ACCOUNTNOINFO3RF; // 拠点銀行口座3
                        row["COMPANYNMRF.COMPANYSETNOTE1RF"] = slipWork.COMPANYNMRF_COMPANYSETNOTE1RF; // 拠点自社設定摘要1
                        row["COMPANYNMRF.COMPANYSETNOTE2RF"] = slipWork.COMPANYNMRF_COMPANYSETNOTE2RF; // 拠点自社設定摘要2
                        row["COMPANYNMRF.COMPANYURLRF"] = slipWork.COMPANYNMRF_COMPANYURLRF; // 拠点自社URL
                        row["COMPANYNMRF.COMPANYPRSENTENCE2RF"] = slipWork.COMPANYNMRF_COMPANYPRSENTENCE2RF; // 拠点自社PR文2
                        row["COMPANYNMRF.IMAGECOMMENTFORPRT1RF"] = slipWork.COMPANYNMRF_IMAGECOMMENTFORPRT1RF; // 拠点画像印字用コメント1
                        row["COMPANYNMRF.IMAGECOMMENTFORPRT2RF"] = slipWork.COMPANYNMRF_IMAGECOMMENTFORPRT2RF; // 拠点画像印字用コメント2
                        row["IMAGEINFORF.IMAGEINFODATARF"] = slipWork.IMAGEINFORF_IMAGEINFODATARF; // 拠点自社画像
                        row["COMPANYINFRF.COMPANYNAME1RF"] = slipWork.COMPANYINFRF_COMPANYNAME1RF; // 自社名称1
                        row["COMPANYINFRF.COMPANYNAME2RF"] = slipWork.COMPANYINFRF_COMPANYNAME2RF; // 自社名称2
                        row["COMPANYINFRF.POSTNORF"] = slipWork.COMPANYINFRF_POSTNORF; // 郵便番号
                        row["COMPANYINFRF.ADDRESS1RF"] = slipWork.COMPANYINFRF_ADDRESS1RF; // 住所1（都道府県市区郡・町村・字）
                        row["COMPANYINFRF.ADDRESS3RF"] = slipWork.COMPANYINFRF_ADDRESS3RF; // 住所3（番地）
                        row["COMPANYINFRF.ADDRESS4RF"] = slipWork.COMPANYINFRF_ADDRESS4RF; // 住所4（アパート名称）
                        row["COMPANYINFRF.COMPANYTELNO1RF"] = slipWork.COMPANYINFRF_COMPANYTELNO1RF; // 自社電話番号1
                        row["COMPANYINFRF.COMPANYTELNO2RF"] = slipWork.COMPANYINFRF_COMPANYTELNO2RF; // 自社電話番号2
                        row["COMPANYINFRF.COMPANYTELNO3RF"] = slipWork.COMPANYINFRF_COMPANYTELNO3RF; // 自社電話番号3
                        row["COMPANYINFRF.COMPANYTELTITLE1RF"] = slipWork.COMPANYINFRF_COMPANYTELTITLE1RF; // 自社電話番号タイトル1
                        row["COMPANYINFRF.COMPANYTELTITLE2RF"] = slipWork.COMPANYINFRF_COMPANYTELTITLE2RF; // 自社電話番号タイトル2
                        row["COMPANYINFRF.COMPANYTELTITLE3RF"] = slipWork.COMPANYINFRF_COMPANYTELTITLE3RF; // 自社電話番号タイトル3
                        row["HEST.FOOTNOTES1RF"] = slipWork.HEST_FOOTNOTES1RF; // 脚注１
                        row["HEST.FOOTNOTES2RF"] = slipWork.HEST_FOOTNOTES2RF; // 脚注２
                        row["HEST.ESTIMATETITLE1RF"] = slipWork.HEST_ESTIMATETITLE1RF; // 見積タイトル１
                        row["HEST.ESTIMATETITLE2RF"] = slipWork.HEST_ESTIMATETITLE2RF; // 見積タイトル２
                        row["HEST.ESTIMATETITLE3RF"] = slipWork.HEST_ESTIMATETITLE3RF; // 見積タイトル３
                        row["HEST.ESTIMATETITLE4RF"] = slipWork.HEST_ESTIMATETITLE4RF; // 見積タイトル４
                        row["HEST.ESTIMATETITLE5RF"] = slipWork.HEST_ESTIMATETITLE5RF; // 見積タイトル５
                        row["HEST.ESTIMATENOTE1RF"] = slipWork.HEST_ESTIMATENOTE1RF; // 見積備考１
                        row["HEST.ESTIMATENOTE2RF"] = slipWork.HEST_ESTIMATENOTE2RF; // 見積備考２
                        row["HEST.ESTIMATENOTE3RF"] = slipWork.HEST_ESTIMATENOTE3RF; // 見積備考３
                        row["HEST.ESTIMATENOTE4RF"] = slipWork.HEST_ESTIMATENOTE4RF; // 見積備考４
                        row["HEST.ESTIMATENOTE5RF"] = slipWork.HEST_ESTIMATENOTE5RF; // 見積備考５
                        //row["HEST.ESTIMATEVALIDITYLIMITRF"] = slipWork.HEST_ESTIMATEVALIDITYLIMITRF; // 見積書有効期日
                        //row["HEST.ESTIMATEVALIDITYLIMITFYRF"] = slipWork.HEST_ESTIMATEVALIDITYLIMITFYRF; // 見積書有効期日西暦年
                        //row["HEST.ESTIMATEVALIDITYLIMITFSRF"] = slipWork.HEST_ESTIMATEVALIDITYLIMITFSRF; // 見積書有効期日西暦年略
                        //row["HEST.ESTIMATEVALIDITYLIMITFWRF"] = slipWork.HEST_ESTIMATEVALIDITYLIMITFWRF; // 見積書有効期日和暦年
                        //row["HEST.ESTIMATEVALIDITYLIMITFMRF"] = slipWork.HEST_ESTIMATEVALIDITYLIMITFMRF; // 見積書有効期日月
                        //row["HEST.ESTIMATEVALIDITYLIMITFDRF"] = slipWork.HEST_ESTIMATEVALIDITYLIMITFDRF; // 見積書有効期日日
                        //row["HEST.ESTIMATEVALIDITYLIMITFGRF"] = slipWork.HEST_ESTIMATEVALIDITYLIMITFGRF; // 見積書有効期日元号
                        //row["HEST.ESTIMATEVALIDITYLIMITFRRF"] = slipWork.HEST_ESTIMATEVALIDITYLIMITFRRF; // 見積書有効期日略号
                        //row["HEST.ESTIMATEVALIDITYLIMITFLSRF"] = slipWork.HEST_ESTIMATEVALIDITYLIMITFLSRF; // 見積書有効期日リテラル(/)
                        //row["HEST.ESTIMATEVALIDITYLIMITFLPRF"] = slipWork.HEST_ESTIMATEVALIDITYLIMITFLPRF; // 見積書有効期日リテラル(.)
                        //row["HEST.ESTIMATEVALIDITYLIMITFLYRF"] = slipWork.HEST_ESTIMATEVALIDITYLIMITFLYRF; // 見積書有効期日リテラル(年)
                        //row["HEST.ESTIMATEVALIDITYLIMITFLMRF"] = slipWork.HEST_ESTIMATEVALIDITYLIMITFLMRF; // 見積書有効期日リテラル(月)
                        //row["HEST.ESTIMATEVALIDITYLIMITFLDRF"] = slipWork.HEST_ESTIMATEVALIDITYLIMITFLDRF; // 見積書有効期日リテラル(日)
                        row["HADD.CARMNGNORF"] = slipWork.HADD_CARMNGNORF; // 車両管理番号
                        row["HADD.CARMNGCODERF"] = slipWork.HADD_CARMNGCODERF; // 車輌管理コード
                        row["HADD.NUMBERPLATE1CODERF"] = slipWork.HADD_NUMBERPLATE1CODERF; // 陸運事務所番号
                        row["HADD.NUMBERPLATE1NAMERF"] = slipWork.HADD_NUMBERPLATE1NAMERF; // 陸運事務局名称
                        row["HADD.NUMBERPLATE2RF"] = slipWork.HADD_NUMBERPLATE2RF; // 車両登録番号（種別）
                        row["HADD.NUMBERPLATE3RF"] = slipWork.HADD_NUMBERPLATE3RF; // 車両登録番号（カナ）
                        row["HADD.NUMBERPLATE4RF"] = slipWork.HADD_NUMBERPLATE4RF; // 車両登録番号（プレート番号）
                        //row["HADD.FIRSTENTRYDATERF"] = slipWork.HADD_FIRSTENTRYDATERF; // 初年度
                        row["HADD.MAKERCODERF"] = slipWork.HADD_MAKERCODERF; // メーカーコード
                        row["HADD.MAKERFULLNAMERF"] = slipWork.HADD_MAKERFULLNAMERF; // メーカー全角名称
                        row["HADD.MAKERHALFNAMERF"] = slipWork.HADD_MAKERHALFNAMERF; // メーカー半角名称
                        row["HADD.MODELCODERF"] = slipWork.HADD_MODELCODERF; // 車種コード
                        row["HADD.MODELSUBCODERF"] = slipWork.HADD_MODELSUBCODERF; // 車種サブコード
                        row["HADD.MODELFULLNAMERF"] = slipWork.HADD_MODELFULLNAMERF; // 車種全角名称
                        row["HADD.MODELHALFNAMERF"] = slipWork.HADD_MODELHALFNAMERF; // 車種半角名称
                        row["HADD.EXHAUSTGASSIGNRF"] = slipWork.HADD_EXHAUSTGASSIGNRF; // 排ガス記号
                        row["HADD.SERIESMODELRF"] = slipWork.HADD_SERIESMODELRF; // シリーズ型式
                        row["HADD.CATEGORYSIGNMODELRF"] = slipWork.HADD_CATEGORYSIGNMODELRF; // 型式（類別記号）
                        row["HADD.FULLMODELRF"] = slipWork.HADD_FULLMODELRF; // 型式（フル型）
                        row["HADD.MODELDESIGNATIONNORF"] = slipWork.HADD_MODELDESIGNATIONNORF; // 型式指定番号
                        row["HADD.CATEGORYNORF"] = slipWork.HADD_CATEGORYNORF; // 類別番号
                        row["HADD.FRAMEMODELRF"] = slipWork.HADD_FRAMEMODELRF; // 車台型式
                        row["HADD.FRAMENORF"] = slipWork.HADD_FRAMENORF; // 車台番号
                        row["HADD.SEARCHFRAMENORF"] = slipWork.HADD_SEARCHFRAMENORF; // 車台番号（検索用）
                        row["HADD.ENGINEMODELNMRF"] = slipWork.HADD_ENGINEMODELNMRF; // エンジン型式名称
                        row["HADD.RELEVANCEMODELRF"] = slipWork.HADD_RELEVANCEMODELRF; // 関連型式
                        row["HADD.SUBCARNMCDRF"] = slipWork.HADD_SUBCARNMCDRF; // サブ車名コード
                        row["HADD.MODELGRADESNAMERF"] = slipWork.HADD_MODELGRADESNAMERF; // 型式グレード略称
                        row["HADD.COLORCODERF"] = slipWork.HADD_COLORCODERF; // カラーコード
                        row["HADD.COLORNAME1RF"] = slipWork.HADD_COLORNAME1RF; // カラー名称1
                        row["HADD.TRIMCODERF"] = slipWork.HADD_TRIMCODERF; // トリムコード
                        row["HADD.TRIMNAMERF"] = slipWork.HADD_TRIMNAMERF; // トリム名称
                        row["HADD.MILEAGERF"] = slipWork.HADD_MILEAGERF; // 車両走行距離
                        //row["HADD.PRINTERMNGNORF"] = slipWork.HADD_PRINTERMNGNORF; // プリンタ管理No
                        //row["HADD.SLIPPRTSETPAPERIDRF"] = slipWork.HADD_SLIPPRTSETPAPERIDRF; // 伝票印刷設定用帳票ID
                        //row["HADD.NOTE1RF"] = slipWork.HADD_NOTE1RF; // 自社備考１
                        //row["HADD.NOTE2RF"] = slipWork.HADD_NOTE2RF; // 自社備考２
                        //row["HADD.NOTE3RF"] = slipWork.HADD_NOTE3RF; // 自社備考３
                        //row["HADD.FIRSTENTRYDATEFYRF"] = slipWork.HADD_FIRSTENTRYDATEFYRF; // 初年度西暦年
                        //row["HADD.FIRSTENTRYDATEFSRF"] = slipWork.HADD_FIRSTENTRYDATEFSRF; // 初年度西暦年略
                        //row["HADD.FIRSTENTRYDATEFWRF"] = slipWork.HADD_FIRSTENTRYDATEFWRF; // 初年度和暦年
                        //row["HADD.FIRSTENTRYDATEFMRF"] = slipWork.HADD_FIRSTENTRYDATEFMRF; // 初年度月
                        //row["HADD.FIRSTENTRYDATEFGRF"] = slipWork.HADD_FIRSTENTRYDATEFGRF; // 初年度元号
                        //row["HADD.FIRSTENTRYDATEFRRF"] = slipWork.HADD_FIRSTENTRYDATEFRRF; // 初年度略号
                        //row["HADD.FIRSTENTRYDATEFLSRF"] = slipWork.HADD_FIRSTENTRYDATEFLSRF; // 初年度リテラル(/)
                        //row["HADD.FIRSTENTRYDATEFLPRF"] = slipWork.HADD_FIRSTENTRYDATEFLPRF; // 初年度リテラル(.)
                        //row["HADD.FIRSTENTRYDATEFLYRF"] = slipWork.HADD_FIRSTENTRYDATEFLYRF; // 初年度リテラル(年)
                        //row["HADD.FIRSTENTRYDATEFLMRF"] = slipWork.HADD_FIRSTENTRYDATEFLMRF; // 初年度リテラル(月)
                        //row["HADD.PRINTCUSTOMERNM1RF"] = slipWork.HADD_PRINTCUSTOMERNM1RF; // 印刷用得意先名称(上段)
                        //row["HADD.PRINTCUSTOMERNM2RF"] = slipWork.HADD_PRINTCUSTOMERNM2RF; // 印刷用得意先名称(下段)
                        row["HPURE.SALESTOTALTAXINCRF"] = slipWork.HPURE_SALESTOTALTAXINCRF; // 純正売上伝票合計（税込み）
                        row["HPURE.SALESTOTALTAXEXCRF"] = slipWork.HPURE_SALESTOTALTAXEXCRF; // 純正売上伝票合計（税抜き）
                        row["HPURE.SALESSUBTOTALTAXINCRF"] = slipWork.HPURE_SALESSUBTOTALTAXINCRF; // 純正売上小計（税込み）
                        row["HPURE.SALESSUBTOTALTAXEXCRF"] = slipWork.HPURE_SALESSUBTOTALTAXEXCRF; // 純正売上小計（税抜き）
                        row["HPURE.SALESSUBTOTALTAXRF"] = slipWork.HPURE_SALESSUBTOTALTAXRF; // 純正売上小計（税）
                        row["HPRIME.SALESTOTALTAXINCRF"] = slipWork.HPRIME_SALESTOTALTAXINCRF; // 優良売上伝票合計（税込み）
                        row["HPRIME.SALESTOTALTAXEXCRF"] = slipWork.HPRIME_SALESTOTALTAXEXCRF; // 優良売上伝票合計（税抜き）
                        row["HPRIME.SALESSUBTOTALTAXINCRF"] = slipWork.HPRIME_SALESSUBTOTALTAXINCRF; // 優良売上小計（税込み）
                        row["HPRIME.SALESSUBTOTALTAXEXCRF"] = slipWork.HPRIME_SALESSUBTOTALTAXEXCRF; // 優良売上小計（税抜き）
                        row["HPRIME.SALESSUBTOTALTAXRF"] = slipWork.HPRIME_SALESSUBTOTALTAXRF; // 優良売上小計（税）
                        //row["HADD.PRINTTIMEHOURRF"] = slipWork.HADD_PRINTTIMEHOURRF; // 印刷時刻 時
                        //row["HADD.PRINTTIMEMINUTERF"] = slipWork.HADD_PRINTTIMEMINUTERF; // 印刷時刻 分
                        //row["HADD.PRINTTIMESECONDRF"] = slipWork.HADD_PRINTTIMESECONDRF; // 印刷時刻 秒
                        row["HADD.ESTFMDIVRF"] = (int)slipWork.HADD_ESTFMDIVRF; // 見積書印刷制御区分
                        //row["HADD.SALESDATEFYRF"] = slipWork.HADD_SALESDATEFYRF; // 売上日付西暦年
                        //row["HADD.SALESDATEFSRF"] = slipWork.HADD_SALESDATEFSRF; // 売上日付西暦年略
                        //row["HADD.SALESDATEFWRF"] = slipWork.HADD_SALESDATEFWRF; // 売上日付和暦年
                        //row["HADD.SALESDATEFMRF"] = slipWork.HADD_SALESDATEFMRF; // 売上日付月
                        //row["HADD.SALESDATEFDRF"] = slipWork.HADD_SALESDATEFDRF; // 売上日付日
                        //row["HADD.SALESDATEFGRF"] = slipWork.HADD_SALESDATEFGRF; // 売上日付元号
                        //row["HADD.SALESDATEFRRF"] = slipWork.HADD_SALESDATEFRRF; // 売上日付略号
                        //row["HADD.SALESDATEFLSRF"] = slipWork.HADD_SALESDATEFLSRF; // 売上日付リテラル(/)
                        //row["HADD.SALESDATEFLPRF"] = slipWork.HADD_SALESDATEFLPRF; // 売上日付リテラル(.)
                        //row["HADD.SALESDATEFLYRF"] = slipWork.HADD_SALESDATEFLYRF; // 売上日付リテラル(年)
                        //row["HADD.SALESDATEFLMRF"] = slipWork.HADD_SALESDATEFLMRF; // 売上日付リテラル(月)
                        //row["HADD.SALESDATEFLDRF"] = slipWork.HADD_SALESDATEFLDRF; // 売上日付リテラル(日)
                        //row["HADD.SALESSLIPPRINTDATEFYRF"] = slipWork.HADD_SALESSLIPPRINTDATEFYRF; // 売上伝票発行日西暦年
                        //row["HADD.SALESSLIPPRINTDATEFSRF"] = slipWork.HADD_SALESSLIPPRINTDATEFSRF; // 売上伝票発行日西暦年略
                        //row["HADD.SALESSLIPPRINTDATEFWRF"] = slipWork.HADD_SALESSLIPPRINTDATEFWRF; // 売上伝票発行日和暦年
                        //row["HADD.SALESSLIPPRINTDATEFMRF"] = slipWork.HADD_SALESSLIPPRINTDATEFMRF; // 売上伝票発行日月
                        //row["HADD.SALESSLIPPRINTDATEFDRF"] = slipWork.HADD_SALESSLIPPRINTDATEFDRF; // 売上伝票発行日日
                        //row["HADD.SALESSLIPPRINTDATEFGRF"] = slipWork.HADD_SALESSLIPPRINTDATEFGRF; // 売上伝票発行日元号
                        //row["HADD.SALESSLIPPRINTDATEFRRF"] = slipWork.HADD_SALESSLIPPRINTDATEFRRF; // 売上伝票発行日略号
                        //row["HADD.SALESSLIPPRINTDATEFLSRF"] = slipWork.HADD_SALESSLIPPRINTDATEFLSRF; // 売上伝票発行日リテラル(/)
                        //row["HADD.SALESSLIPPRINTDATEFLPRF"] = slipWork.HADD_SALESSLIPPRINTDATEFLPRF; // 売上伝票発行日リテラル(.)
                        //row["HADD.SALESSLIPPRINTDATEFLYRF"] = slipWork.HADD_SALESSLIPPRINTDATEFLYRF; // 売上伝票発行日リテラル(年)
                        //row["HADD.SALESSLIPPRINTDATEFLMRF"] = slipWork.HADD_SALESSLIPPRINTDATEFLMRF; // 売上伝票発行日リテラル(月)
                        //row["HADD.SALESSLIPPRINTDATEFLDRF"] = slipWork.HADD_SALESSLIPPRINTDATEFLDRF; // 売上伝票発行日リテラル(日)
                        row["HADD.SYSTEMATICCODERF"] = slipWork.HADD_SYSTEMATICCODERF; // 系統コード
                        row["HADD.SYSTEMATICNAMERF"] = slipWork.HADD_SYSTEMATICNAMERF; // 系統名称
                        //row["HADD.STPRODUCETYPEOFYEARRF"] = slipWork.HADD_STPRODUCETYPEOFYEARRF; // 開始生産年式
                        //row["HADD.EDPRODUCETYPEOFYEARRF"] = slipWork.HADD_EDPRODUCETYPEOFYEARRF; // 終了生産年式
                        row["HADD.DOORCOUNTRF"] = slipWork.HADD_DOORCOUNTRF; // ドア数
                        row["HADD.BODYNAMECODERF"] = slipWork.HADD_BODYNAMECODERF; // ボディー名コード
                        row["HADD.BODYNAMERF"] = slipWork.HADD_BODYNAMERF; // ボディー名称
                        row["HADD.STPRODUCEFRAMENORF"] = slipWork.HADD_STPRODUCEFRAMENORF; // 生産車台番号開始
                        row["HADD.EDPRODUCEFRAMENORF"] = slipWork.HADD_EDPRODUCEFRAMENORF; // 生産車台番号終了
                        row["HADD.ENGINEMODELRF"] = slipWork.HADD_ENGINEMODELRF; // 原動機型式（エンジン）
                        row["HADD.MODELGRADENMRF"] = slipWork.HADD_MODELGRADENMRF; // 型式グレード名称
                        row["HADD.ENGINEDISPLACENMRF"] = slipWork.HADD_ENGINEDISPLACENMRF; // 排気量名称
                        row["HADD.EDIVNMRF"] = slipWork.HADD_EDIVNMRF; // E区分名称
                        row["HADD.TRANSMISSIONNMRF"] = slipWork.HADD_TRANSMISSIONNMRF; // ミッション名称
                        row["HADD.SHIFTNMRF"] = slipWork.HADD_SHIFTNMRF; // シフト名称
                        row["HADD.WHEELDRIVEMETHODNMRF"] = slipWork.HADD_WHEELDRIVEMETHODNMRF; // 駆動方式名称
                        row["HADD.ADDICARSPEC1RF"] = slipWork.HADD_ADDICARSPEC1RF; // 追加諸元1
                        row["HADD.ADDICARSPEC2RF"] = slipWork.HADD_ADDICARSPEC2RF; // 追加諸元2
                        row["HADD.ADDICARSPEC3RF"] = slipWork.HADD_ADDICARSPEC3RF; // 追加諸元3
                        row["HADD.ADDICARSPEC4RF"] = slipWork.HADD_ADDICARSPEC4RF; // 追加諸元4
                        row["HADD.ADDICARSPEC5RF"] = slipWork.HADD_ADDICARSPEC5RF; // 追加諸元5
                        row["HADD.ADDICARSPEC6RF"] = slipWork.HADD_ADDICARSPEC6RF; // 追加諸元6
                        row["HADD.ADDICARSPECTITLE1RF"] = slipWork.HADD_ADDICARSPECTITLE1RF; // 追加諸元タイトル1
                        row["HADD.ADDICARSPECTITLE2RF"] = slipWork.HADD_ADDICARSPECTITLE2RF; // 追加諸元タイトル2
                        row["HADD.ADDICARSPECTITLE3RF"] = slipWork.HADD_ADDICARSPECTITLE3RF; // 追加諸元タイトル3
                        row["HADD.ADDICARSPECTITLE4RF"] = slipWork.HADD_ADDICARSPECTITLE4RF; // 追加諸元タイトル4
                        row["HADD.ADDICARSPECTITLE5RF"] = slipWork.HADD_ADDICARSPECTITLE5RF; // 追加諸元タイトル5
                        row["HADD.ADDICARSPECTITLE6RF"] = slipWork.HADD_ADDICARSPECTITLE6RF; // 追加諸元タイトル6
                        //row["HADD.STPRODUCETYPEOFYEARFYRF"] = slipWork.HADD_STPRODUCETYPEOFYEARFYRF; // 開始生産年式西暦年
                        //row["HADD.STPRODUCETYPEOFYEARFSRF"] = slipWork.HADD_STPRODUCETYPEOFYEARFSRF; // 開始生産年式西暦年略
                        //row["HADD.STPRODUCETYPEOFYEARFWRF"] = slipWork.HADD_STPRODUCETYPEOFYEARFWRF; // 開始生産年式和暦年
                        //row["HADD.STPRODUCETYPEOFYEARFMRF"] = slipWork.HADD_STPRODUCETYPEOFYEARFMRF; // 開始生産年式月
                        //row["HADD.STPRODUCETYPEOFYEARFGRF"] = slipWork.HADD_STPRODUCETYPEOFYEARFGRF; // 開始生産年式元号
                        //row["HADD.STPRODUCETYPEOFYEARFRRF"] = slipWork.HADD_STPRODUCETYPEOFYEARFRRF; // 開始生産年式略号
                        //row["HADD.STPRODUCETYPEOFYEARFLSRF"] = slipWork.HADD_STPRODUCETYPEOFYEARFLSRF; // 開始生産年式リテラル(/)
                        //row["HADD.STPRODUCETYPEOFYEARFLPRF"] = slipWork.HADD_STPRODUCETYPEOFYEARFLPRF; // 開始生産年式リテラル(.)
                        //row["HADD.STPRODUCETYPEOFYEARFLYRF"] = slipWork.HADD_STPRODUCETYPEOFYEARFLYRF; // 開始生産年式リテラル(年)
                        //row["HADD.STPRODUCETYPEOFYEARFLMRF"] = slipWork.HADD_STPRODUCETYPEOFYEARFLMRF; // 開始生産年式リテラル(月)
                        //row["HADD.EDPRODUCETYPEOFYEARFYRF"] = slipWork.HADD_EDPRODUCETYPEOFYEARFYRF; // 終了生産年式西暦年
                        //row["HADD.EDPRODUCETYPEOFYEARFSRF"] = slipWork.HADD_EDPRODUCETYPEOFYEARFSRF; // 終了生産年式西暦年略
                        //row["HADD.EDPRODUCETYPEOFYEARFWRF"] = slipWork.HADD_EDPRODUCETYPEOFYEARFWRF; // 終了生産年式和暦年
                        //row["HADD.EDPRODUCETYPEOFYEARFMRF"] = slipWork.HADD_EDPRODUCETYPEOFYEARFMRF; // 終了生産年式月
                        //row["HADD.EDPRODUCETYPEOFYEARFGRF"] = slipWork.HADD_EDPRODUCETYPEOFYEARFGRF; // 終了生産年式元号
                        //row["HADD.EDPRODUCETYPEOFYEARFRRF"] = slipWork.HADD_EDPRODUCETYPEOFYEARFRRF; // 終了生産年式略号
                        //row["HADD.EDPRODUCETYPEOFYEARFLSRF"] = slipWork.HADD_EDPRODUCETYPEOFYEARFLSRF; // 終了生産年式リテラル(/)
                        //row["HADD.EDPRODUCETYPEOFYEARFLPRF"] = slipWork.HADD_EDPRODUCETYPEOFYEARFLPRF; // 終了生産年式リテラル(.)
                        //row["HADD.EDPRODUCETYPEOFYEARFLYRF"] = slipWork.HADD_EDPRODUCETYPEOFYEARFLYRF; // 終了生産年式リテラル(年)
                        //row["HADD.EDPRODUCETYPEOFYEARFLMRF"] = slipWork.HADD_EDPRODUCETYPEOFYEARFLMRF; // 終了生産年式リテラル(月)
                        # endregion

                        # region [伝票項目(自動以外)]

                        // 未設定時 非印字コード
                        # region [未設定]
                        if ( IsZero( slipWork.SALESSLIPRF_SECTIONCODERF ) ) row["SALESSLIPRF.SECTIONCODERF"] = DBNull.Value; // 拠点コード
                        if ( IsZero( slipWork.SALESSLIPRF_SALESINPUTCODERF ) ) row["SALESSLIPRF.SALESINPUTCODERF"] = DBNull.Value; // 売上入力者コード
                        if ( IsZero( slipWork.SALESSLIPRF_SALESINPUTNAMERF ) ) row["SALESSLIPRF.SALESINPUTNAMERF"] = DBNull.Value; // 売上入力者名称
                        if ( IsZero( slipWork.SALESSLIPRF_FRONTEMPLOYEECDRF ) ) row["SALESSLIPRF.FRONTEMPLOYEECDRF"] = DBNull.Value; // 受付従業員コード
                        if ( IsZero( slipWork.SALESSLIPRF_FRONTEMPLOYEENMRF ) ) row["SALESSLIPRF.FRONTEMPLOYEENMRF"] = DBNull.Value; // 受付従業員名称
                        if ( IsZero( slipWork.SALESSLIPRF_SALESEMPLOYEECDRF ) ) row["SALESSLIPRF.SALESEMPLOYEECDRF"] = DBNull.Value; // 販売従業員コード
                        if ( IsZero( slipWork.SALESSLIPRF_CUSTOMERCODERF ) ) row["SALESSLIPRF.CUSTOMERCODERF"] = DBNull.Value; // 得意先コード
                        if ( IsZero( slipWork.HADD_MAKERCODERF ) ) row["HADD.MAKERCODERF"] = DBNull.Value; // メーカーコード
                        if ( IsZero( slipWork.HADD_MODELCODERF ) ) row["HADD.MODELCODERF"] = DBNull.Value; // 車種コード
                        if ( IsZero( slipWork.HADD_MODELSUBCODERF ) ) row["HADD.MODELSUBCODERF"] = DBNull.Value; // 車種サブコード
                        if ( IsZero( slipWork.HADD_MODELDESIGNATIONNORF ) ) row["HADD.MODELDESIGNATIONNORF"] = DBNull.Value; // 型式指定番号
                        if ( IsZero( slipWork.HADD_CATEGORYNORF ) ) row["HADD.CATEGORYNORF"] = DBNull.Value; // 類別番号
                        if ( IsZero( slipWork.HADD_SYSTEMATICCODERF ) ) row["HADD.SYSTEMATICCODERF"] = DBNull.Value; // 系統コード
                        if ( IsZero( slipWork.HADD_DOORCOUNTRF ) ) row["HADD.DOORCOUNTRF"] = DBNull.Value; // ドア数
                        if ( IsZero( slipWork.HADD_BODYNAMECODERF ) ) row["HADD.BODYNAMECODERF"] = DBNull.Value; // ボディー名コード
                        if ( IsZero( slipWork.HADD_CARMNGNORF ) ) row["HADD.CARMNGNORF"] = DBNull.Value; // 車両管理番号
                        if ( IsZero( slipWork.HADD_NUMBERPLATE1CODERF ) ) row["HADD.NUMBERPLATE1CODERF"] = DBNull.Value; // 陸運事務所番号
                        if ( IsZero( slipWork.HADD_NUMBERPLATE4RF ) ) row["HADD.NUMBERPLATE4RF"] = DBNull.Value; // 車両登録番号（プレート番号）
                        if ( IsZero( slipWork.HADD_SEARCHFRAMENORF ) ) row["HADD.SEARCHFRAMENORF"] = DBNull.Value; // 車台番号（検索用）
                        if ( IsZero( slipWork.HADD_SUBCARNMCDRF ) ) row["HADD.SUBCARNMCDRF"] = DBNull.Value; // サブ車名コード
                        # endregion

                        // 自社備考
                        # region [自社備考]
                        row["HADD.NOTE1RF"] = slipPrtSet.Note1; // 自社備考１
                        row["HADD.NOTE2RF"] = slipPrtSet.Note2; // 自社備考２
                        row["HADD.NOTE3RF"] = slipPrtSet.Note3; // 自社備考３
                        # endregion

                        ////// 再発行マーク
                        ////if ( slipPrintParameter.ReissueDiv )
                        ////{
                        ////    row["HADD.REISSUEMARKRF"] = slipPrtSet.ReissueMark; // 再発行マーク
                        ////}
                        ////else
                        ////{
                        ////    row["HADD.REISSUEMARKRF"] = string.Empty;
                        ////}

                        // 日付関連展開
                        # region [日付]
                        // 通常
                        ExtractDate( ref row, allDefSet.EraNameDispCd2, slipWork.HEST_ESTIMATEVALIDITYLIMITRF, "HEST.ESTIMATEVALIDITYLIMIT", false ); // 見積書有効期日
                        ExtractDate( ref row, allDefSet.EraNameDispCd2, slipWork.SALESSLIPRF_SALESDATERF, "HADD.SALESDATE", false ); // 売上日付
                        ExtractDate( ref row, allDefSet.EraNameDispCd2, slipWork.SALESSLIPRF_SALESSLIPPRINTDATERF, "HADD.SALESSLIPPRINTDATE", false ); // 売上伝票発行日
                        // 年式
                        ExtractDate( ref row, allDefSet.EraNameDispCd1, slipWork.HADD_FIRSTENTRYDATERF, "HADD.FIRSTENTRYDATE", true ); // 初年度
                        ExtractDate( ref row, allDefSet.EraNameDispCd1, slipWork.HADD_STPRODUCETYPEOFYEARRF, "HADD.STPRODUCETYPEOFYEAR", true ); // 開始生産年式
                        ExtractDate( ref row, allDefSet.EraNameDispCd1, slipWork.HADD_EDPRODUCETYPEOFYEARRF, "HADD.EDPRODUCETYPEOFYEAR", true ); // 終了生産年式
                        # endregion

                        // 得意先名称
                        # region [得意先名称]
                        if ( slipWork.SALESSLIPRF_CUSTOMERNAME2RF.Trim() != string.Empty )
                        {
                            // 上：名称１
                            // 下：名称２＋敬称
                            row["HADD.PRINTCUSTOMERNM1RF"] = slipWork.SALESSLIPRF_CUSTOMERNAMERF.Trim();
                            row["HADD.PRINTCUSTOMERNM2RF"] = slipWork.SALESSLIPRF_CUSTOMERNAME2RF.Trim() + "  " + slipWork.SALESSLIPRF_HONORIFICTITLERF.Trim();
                        }
                        else
                        {
                            //// 上：空白
                            //// 下：名称１＋敬称
                            //row["HADD.PRINTCUSTOMERNM1RF"] = DBNull.Value;
                            //row["HADD.PRINTCUSTOMERNM2RF"] = slipWork.SALESSLIPRF_CUSTOMERNAMERF.Trim() + "  " + slipWork.SALESSLIPRF_HONORIFICTITLERF.Trim();

                            // 上：名称１＋敬称
                            // 下：空白
                            row["HADD.PRINTCUSTOMERNM1RF"] = slipWork.SALESSLIPRF_CUSTOMERNAMERF.Trim() + "  " + slipWork.SALESSLIPRF_HONORIFICTITLERF.Trim();
                            row["HADD.PRINTCUSTOMERNM2RF"] = DBNull.Value;
                        }
                        // 名称１＋名称２
                        row["HPRT.PRINTCUSTOMERNAMEJOIN12RF"] = slipWork.SALESSLIPRF_CUSTOMERNAMERF + slipWork.SALESSLIPRF_CUSTOMERNAME2RF;

                        // --- UPD m.suzuki 2010/03/08 ---------->>>>>
                        //// 名称１＋名称２＋空白＋敬称
                        //row["HPRT.PRINTCUSTOMERNAMEJOIN12HNRF"] = (string)row["HPRT.PRINTCUSTOMERNAMEJOIN12RF"] + "　" + slipWork.SALESSLIPRF_HONORIFICTITLERF.Trim();

                        // 得意先名称１＋得意先名称２を20桁まで取得
                        string printCustomerNameJoin12 = (string)row["HPRT.PRINTCUSTOMERNAMEJOIN12RF"];
                        printCustomerNameJoin12 = printCustomerNameJoin12.PadRight( 20, ' ' ).Substring( 0, 20 ).TrimEnd();

                        // PM7の得意先名称と同様の制御を行う
                        if ( slipWork.SALESSLIPRF_CUSTOMERNAMERF.Trim() != string.Empty )
                        {
                            if ( slipWork.SALESSLIPRF_CUSTOMERNAME2RF.Trim() != string.Empty )
                            {
                                // 名称１＋名称２＋敬称
                                row["HPRT.PRINTCUSTOMERNAMEJOIN12HNRF"] = printCustomerNameJoin12 + slipWork.SALESSLIPRF_HONORIFICTITLERF.Trim();
                            }
                            else
                            {
                                // 名称１＋(名称２＋)空白＋敬称
                                row["HPRT.PRINTCUSTOMERNAMEJOIN12HNRF"] = printCustomerNameJoin12 + "　" + slipWork.SALESSLIPRF_HONORIFICTITLERF.Trim();
                            }
                        }
                        else
                        {
                            if ( slipWork.SALESSLIPRF_CUSTOMERNAME2RF.Trim() != string.Empty )
                            {
                                // (名称１＋)名称２＋空白＋敬称
                                row["HPRT.PRINTCUSTOMERNAMEJOIN12HNRF"] = printCustomerNameJoin12 + "　" + slipWork.SALESSLIPRF_HONORIFICTITLERF.Trim();
                            }
                            else
                            {
                                // 空白
                                row["HPRT.PRINTCUSTOMERNAMEJOIN12HNRF"] = string.Empty;
                            }
                        }
                        // --- UPD m.suzuki 2010/03/08 ----------<<<<<
                        # endregion

                        // 縦倍角対応
                        # region [縦倍角対応]
                        // ※これ以前の処理でrowにセットした内容を使用します。

                        // 文字サイズ (0:標準,1:大)
                        if ( slipPrtSet.SlipFontSize == 0 )
                        {
                            // 標準
                            row["HLG.PRINTCUSTOMERNAMEJOIN12RF"] = DBNull.Value;  // （縦倍）得意先名１＋得意先名２
                            row["HLG.PRINTCUSTOMERNAMEJOIN12HNRF"] = DBNull.Value;  // （縦倍）得意先名１＋得意先名２＋敬称
                            row["HLG.CUSTOMERNAMERF"] = DBNull.Value;  // （縦倍）得意先名称
                            row["HLG.CUSTOMERNAME2RF"] = DBNull.Value;  // （縦倍）得意先名称2
                            row["HLG.CUSTOMERSNMRF"] = DBNull.Value;  // （縦倍）得意先略称
                            row["HLG.HONORIFICTITLERF"] = DBNull.Value;  // （縦倍）得意先敬称
                            row["HLG.PRINTCUSTOMERNM1RF"] = DBNull.Value;  // （縦倍）印刷用得意先名称(上段)
                            row["HLG.PRINTCUSTOMERNM2RF"] = DBNull.Value;  // （縦倍）印刷用得意先名称(下段)
                        
                        }
                        else
                        {
                            // 縦倍角
                            row["HLG.PRINTCUSTOMERNAMEJOIN12RF"] = row["HPRT.PRINTCUSTOMERNAMEJOIN12RF"];  // （縦倍）得意先名１＋得意先名２
                            row["HLG.PRINTCUSTOMERNAMEJOIN12HNRF"] = row["HPRT.PRINTCUSTOMERNAMEJOIN12HNRF"];  // （縦倍）得意先名１＋得意先名２＋敬称
                            row["HLG.CUSTOMERNAMERF"] = row["SALESSLIPRF.CUSTOMERNAMERF"];  // （縦倍）得意先名称
                            row["HLG.CUSTOMERNAME2RF"] = row["SALESSLIPRF.CUSTOMERNAME2RF"];  // （縦倍）得意先名称2
                            row["HLG.CUSTOMERSNMRF"] = row["SALESSLIPRF.CUSTOMERSNMRF"];  // （縦倍）得意先略称
                            row["HLG.HONORIFICTITLERF"] = row["SALESSLIPRF.HONORIFICTITLERF"];  // （縦倍）得意先敬称
                            row["HLG.PRINTCUSTOMERNM1RF"] = row["HADD.PRINTCUSTOMERNM1RF"];  // （縦倍）印刷用得意先名称(上段)
                            row["HLG.PRINTCUSTOMERNM2RF"] = row["HADD.PRINTCUSTOMERNM2RF"];  // （縦倍）印刷用得意先名称(下段)

                            row["SALESSLIPRF.CUSTOMERNAMERF"] = DBNull.Value; // 得意先名称
                            row["SALESSLIPRF.CUSTOMERNAME2RF"] = DBNull.Value; // 得意先名称2
                            row["SALESSLIPRF.CUSTOMERSNMRF"] = DBNull.Value; // 得意先略称
                            row["SALESSLIPRF.HONORIFICTITLERF"] = DBNull.Value; // 得意先敬称
                            row["HADD.PRINTCUSTOMERNM1RF"] = DBNull.Value; // 印刷用得意先名称(上段)
                            row["HADD.PRINTCUSTOMERNM2RF"] = DBNull.Value; // 印刷用得意先名称(下段)
                            row["HPRT.PRINTCUSTOMERNAMEJOIN12RF"] = DBNull.Value; // 得意先名１＋得意先名２
                            row["HPRT.PRINTCUSTOMERNAMEJOIN12HNRF"] = DBNull.Value; // 得意先名１＋得意先名２＋敬称
                        }
                        # endregion

                        // 時刻
                        # region [時刻]
                        row["HADD.PRINTTIMEHOURRF"] = slipWork.HADD_PRINTTIMEHOURRF; // 印刷時刻HH
                        row["HADD.PRINTTIMEMINUTERF"] = slipWork.HADD_PRINTTIMEMINUTERF; // 印刷時刻MM
                        row["HADD.PRINTTIMESECONDRF"] = slipWork.HADD_PRINTTIMESECONDRF; // 印刷時刻SS
                        # endregion

                        // 合計部
                        # region [合計部の制御]

                        bool subTotalPrintEnable = true;
                        bool totalPrintEnable = true;
                        bool taxPrintEnable = true;

                        // 合計部は最初のヘッダまたは最終のフッタのみ印字
                        if ( index == 0 || index == allDetailCount - 1 )
                        {
                            // 消費税区分 0:する　1:しない
                            if ( estimateDefSet.ConsTaxPrintDiv == 0 )
                            {
                                // 転嫁方式　0:伝票単位1:明細単位2:請求親 3:請求子 9:非課税
                                switch ( slipWork.SALESSLIPRF_CONSTAXLAYMETHODRF )
                                {
                                    case 0:
                                    case 1:
                                        {
                                        }
                                        break;
                                    case 2:
                                    case 3:
                                        {
                                            totalPrintEnable = false;
                                        }
                                        break;
                                    case 9:
                                    default:
                                        {
                                            totalPrintEnable = false;
                                            taxPrintEnable = false;
                                        }
                                        break;
                                }
                            }
                            else
                            {
                                totalPrintEnable = false;
                                taxPrintEnable = false;
                            }
                        }
                        else
                        {
                            subTotalPrintEnable = false;
                            totalPrintEnable = false;
                            taxPrintEnable = false;
                        }

                        // 小計（税抜）
                        if ( subTotalPrintEnable == false )
                        {
                            row["HPURE.SALESTOTALTAXEXCRF"] = DBNull.Value; // 純正売上伝票合計（税抜き）
                            row["HPURE.SALESSUBTOTALTAXEXCRF"] = DBNull.Value; // 純正売上小計（税抜き）
                            row["HPRIME.SALESTOTALTAXEXCRF"] = DBNull.Value; // 優良売上伝票合計（税抜き）
                            row["HPRIME.SALESSUBTOTALTAXEXCRF"] = DBNull.Value; // 優良売上小計（税抜き）
                        }
                        // 合計（税込）
                        if ( totalPrintEnable == false )
                        {
                            row["HPURE.SALESTOTALTAXINCRF"] = DBNull.Value; // 純正売上伝票合計（税込み）
                            row["HPURE.SALESSUBTOTALTAXINCRF"] = DBNull.Value; // 純正売上小計（税込み）
                            row["HPRIME.SALESTOTALTAXINCRF"] = DBNull.Value; // 優良売上伝票合計（税込み）
                            row["HPRIME.SALESSUBTOTALTAXINCRF"] = DBNull.Value; // 優良売上小計（税込み）
                        }
                        // 税
                        if ( taxPrintEnable == false )
                        {
                            row["HPURE.SALESSUBTOTALTAXRF"] = DBNull.Value; // 純正売上小計（税）
                            row["HPRIME.SALESSUBTOTALTAXRF"] = DBNull.Value; // 優良売上小計（税）
                        }
                        # endregion

                        // 類別型式ハイフン
                        # region [類別型式ハイフン]
                        if ( slipWork.HADD_CATEGORYNORF == 0 && slipWork.HADD_MODELDESIGNATIONNORF == 0 )
                        {
                            row[ct_HCategoryHyp] = DBNull.Value;
                        }
                        else
                        {
                            row[ct_HCategoryHyp] = "-";
                        }
                        # endregion

                        # endregion

                        // 自社情報
                        # region [自社情報の制御]
                        // 0:自社名印字　1:拠点名印字　2:ビットマップを印字　3:印字しない
                        switch ( slipPrtSet.EnterpriseNamePrtCd )
                        {
                            // 自社名
                            case 0:
                                {
                                    // CompanyInfの内容に差し替える
                                    row["COMPANYNMRF.COMPANYNAME1RF"] = slipWork.COMPANYINFRF_COMPANYNAME1RF; // 自社名称1
                                    row["COMPANYNMRF.COMPANYNAME2RF"] = slipWork.COMPANYINFRF_COMPANYNAME2RF; // 自社名称2
                                    row["COMPANYNMRF.POSTNORF"] = slipWork.COMPANYINFRF_POSTNORF; // 郵便番号
                                    row["COMPANYNMRF.ADDRESS1RF"] = slipWork.COMPANYINFRF_ADDRESS1RF; // 住所1（都道府県市区郡・町村・字）
                                    row["COMPANYNMRF.ADDRESS3RF"] = slipWork.COMPANYINFRF_ADDRESS3RF; // 住所3（番地）
                                    row["COMPANYNMRF.ADDRESS4RF"] = slipWork.COMPANYINFRF_ADDRESS4RF; // 住所4（アパート名称）
                                    row["COMPANYNMRF.COMPANYTELNO1RF"] = slipWork.COMPANYINFRF_COMPANYTELNO1RF; // 自社電話番号1
                                    row["COMPANYNMRF.COMPANYTELNO2RF"] = slipWork.COMPANYINFRF_COMPANYTELNO2RF; // 自社電話番号2
                                    row["COMPANYNMRF.COMPANYTELNO3RF"] = slipWork.COMPANYINFRF_COMPANYTELNO3RF; // 自社電話番号3
                                    row["COMPANYNMRF.COMPANYTELTITLE1RF"] = slipWork.COMPANYINFRF_COMPANYTELTITLE1RF; // 自社電話番号タイトル1
                                    row["COMPANYNMRF.COMPANYTELTITLE2RF"] = slipWork.COMPANYINFRF_COMPANYTELTITLE2RF; // 自社電話番号タイトル2
                                    row["COMPANYNMRF.COMPANYTELTITLE3RF"] = slipWork.COMPANYINFRF_COMPANYTELTITLE3RF; // 自社電話番号タイトル3
                                    // bitmapなし
                                    row["COMPANYNMRF.IMAGECOMMENTFORPRT1RF"] = DBNull.Value; // 画像印字用コメント1
                                    row["COMPANYNMRF.IMAGECOMMENTFORPRT2RF"] = DBNull.Value; // 画像印字用コメント2
                                    row["IMAGEINFORF.IMAGEINFODATARF"] = DBNull.Value; // 画像情報データ
                                }
                                break;
                            // 拠点名
                            case 1:
                                {
                                    // bitmapなし
                                    row["COMPANYNMRF.IMAGECOMMENTFORPRT1RF"] = DBNull.Value; // 画像印字用コメント1
                                    row["COMPANYNMRF.IMAGECOMMENTFORPRT2RF"] = DBNull.Value; // 画像印字用コメント2
                                    row["IMAGEINFORF.IMAGEINFODATARF"] = DBNull.Value; // 画像情報データ
                                }
                                break;
                            // ビットマップ
                            case 2:
                                {
                                    // 自社情報文字列なし
                                    row["COMPANYNMRF.COMPANYNAME1RF"] = DBNull.Value; // 自社名称1
                                    row["COMPANYNMRF.COMPANYNAME2RF"] = DBNull.Value; // 自社名称2
                                    row["COMPANYNMRF.POSTNORF"] = DBNull.Value; // 郵便番号
                                    row["COMPANYNMRF.ADDRESS1RF"] = DBNull.Value; // 住所1（都道府県市区郡・町村・字）
                                    row["COMPANYNMRF.ADDRESS3RF"] = DBNull.Value; // 住所3（番地）
                                    row["COMPANYNMRF.ADDRESS4RF"] = DBNull.Value; // 住所4（アパート名称）
                                    row["COMPANYNMRF.COMPANYTELNO1RF"] = DBNull.Value; // 自社電話番号1
                                    row["COMPANYNMRF.COMPANYTELNO2RF"] = DBNull.Value; // 自社電話番号2
                                    row["COMPANYNMRF.COMPANYTELNO3RF"] = DBNull.Value; // 自社電話番号3
                                    row["COMPANYNMRF.COMPANYTELTITLE1RF"] = DBNull.Value; // 自社電話番号タイトル1
                                    row["COMPANYNMRF.COMPANYTELTITLE2RF"] = DBNull.Value; // 自社電話番号タイトル2
                                    row["COMPANYNMRF.COMPANYTELTITLE3RF"] = DBNull.Value; // 自社電話番号タイトル3
                                }
                                break;
                            // 印字しない
                            case 3:
                            default:
                                {
                                    // 自社情報文字列なし
                                    row["COMPANYNMRF.COMPANYNAME1RF"] = DBNull.Value; // 自社名称1
                                    row["COMPANYNMRF.COMPANYNAME2RF"] = DBNull.Value; // 自社名称2
                                    row["COMPANYNMRF.POSTNORF"] = DBNull.Value; // 郵便番号
                                    row["COMPANYNMRF.ADDRESS1RF"] = DBNull.Value; // 住所1（都道府県市区郡・町村・字）
                                    row["COMPANYNMRF.ADDRESS3RF"] = DBNull.Value; // 住所3（番地）
                                    row["COMPANYNMRF.ADDRESS4RF"] = DBNull.Value; // 住所4（アパート名称）
                                    row["COMPANYNMRF.COMPANYTELNO1RF"] = DBNull.Value; // 自社電話番号1
                                    row["COMPANYNMRF.COMPANYTELNO2RF"] = DBNull.Value; // 自社電話番号2
                                    row["COMPANYNMRF.COMPANYTELNO3RF"] = DBNull.Value; // 自社電話番号3
                                    row["COMPANYNMRF.COMPANYTELTITLE1RF"] = DBNull.Value; // 自社電話番号タイトル1
                                    row["COMPANYNMRF.COMPANYTELTITLE2RF"] = DBNull.Value; // 自社電話番号タイトル2
                                    row["COMPANYNMRF.COMPANYTELTITLE3RF"] = DBNull.Value; // 自社電話番号タイトル3
                                    // bitmapなし
                                    row["COMPANYNMRF.IMAGECOMMENTFORPRT1RF"] = DBNull.Value; // 画像印字用コメント1
                                    row["COMPANYNMRF.IMAGECOMMENTFORPRT2RF"] = DBNull.Value; // 画像印字用コメント2
                                    row["IMAGEINFORF.IMAGEINFODATARF"] = DBNull.Value; // 画像情報データ
                                }
                                break;
                        }
                        // 自社名１分割
                        if ( row["COMPANYNMRF.COMPANYNAME1RF"] != DBNull.Value )
                        {
                            string firstHalf;
                            string lastHalf;
                            DivideEnterpriseName( (string)row["COMPANYNMRF.COMPANYNAME1RF"], out firstHalf, out lastHalf );
                            row["HPRT.PRINTENTERPRISENAME1FHRF"] = firstHalf;
                            row["HPRT.PRINTENTERPRISENAME1LHRF"] = lastHalf;
                        }
                        else
                        {
                            row["HPRT.PRINTENTERPRISENAME1FHRF"] = DBNull.Value;
                            row["HPRT.PRINTENTERPRISENAME1LHRF"] = DBNull.Value;
                        }
                        // 自社名２分割
                        if ( row["COMPANYNMRF.COMPANYNAME2RF"] != DBNull.Value )
                        {
                            string firstHalf;
                            string lastHalf;
                            DivideEnterpriseName( (string)row["COMPANYNMRF.COMPANYNAME2RF"], out firstHalf, out lastHalf );
                            row["HPRT.PRINTENTERPRISENAME2FHRF"] = firstHalf;
                            row["HPRT.PRINTENTERPRISENAME2LHRF"] = lastHalf;
                        }
                        else
                        {
                            row["HPRT.PRINTENTERPRISENAME2FHRF"] = DBNull.Value;
                            row["HPRT.PRINTENTERPRISENAME2LHRF"] = DBNull.Value;
                        }
                        # endregion
                    }

                    if ( index < detailWorks.Count )
                    {
                        //-------------------------------------------
                        // 実明細
                        //-------------------------------------------

                        # region [明細項目Copy]
                        row["SALESDETAILRF.SALESSLIPNUMRF"] = detailWorks[index].SALESDETAILRF_SALESSLIPNUMRF; // 売上伝票番号
                        row["SALESDETAILRF.SALESROWNORF"] = detailWorks[index].SALESDETAILRF_SALESROWNORF; // 売上行番号
                        row["DPURE.GOODSMAKERCDRF"] = detailWorks[index].DPURE_GOODSMAKERCDRF; // 純正商品メーカーコード
                        row["DPURE.MAKERNAMERF"] = detailWorks[index].DPURE_MAKERNAMERF; // 純正メーカー名称
                        row["DPURE.MAKERKANANAMERF"] = detailWorks[index].DPURE_MAKERKANANAMERF; // 純正メーカーカナ名称
                        row["DPURE.GOODSNORF"] = detailWorks[index].DPURE_GOODSNORF; // 純正商品番号
                        row["DPURE.GOODSNAMERF"] = detailWorks[index].DPURE_GOODSNAMERF; // 純正商品名称
                        row["DPURE.GOODSNAMEKANARF"] = detailWorks[index].DPURE_GOODSNAMEKANARF; // 純正商品名称カナ
                        row["DPURE.BLGOODSCODERF"] = detailWorks[index].DPURE_BLGOODSCODERF; // 純正BL商品コード
                        row["DPURE.SALESUNPRCTAXINCFLRF"] = detailWorks[index].DPURE_SALESUNPRCTAXINCFLRF; // 純正売上単価（税込，浮動）
                        row["DPURE.SALESUNPRCTAXEXCFLRF"] = detailWorks[index].DPURE_SALESUNPRCTAXEXCFLRF; // 純正売上単価（税抜，浮動）
                        row["DPURE.LISTPRICETAXINCFLRF"] = detailWorks[index].DPURE_LISTPRICETAXINCFLRF; // 純正定価（税込，浮動）
                        row["DPURE.LISTPRICETAXEXCFLRF"] = detailWorks[index].DPURE_LISTPRICETAXEXCFLRF; // 純正定価（税抜，浮動）
                        row["DPURE.SALESMONEYTAXINCRF"] = detailWorks[index].DPURE_SALESMONEYTAXINCRF; // 純正売上金額（税込み）
                        row["DPURE.SALESMONEYTAXEXCRF"] = detailWorks[index].DPURE_SALESMONEYTAXEXCRF; // 純正売上金額（税抜き）
                        row["DPURE.TAXATIONDIVCDRF"] = detailWorks[index].DPURE_TAXATIONDIVCDRF; // 純正課税区分
                        //row["DPURE.SALESUNPRCFLRF"] = detailWorks[index].DPURE_SALESUNPRCFLRF; // 純正売上単価
                        //row["DPURE.LISTPRICERF"] = detailWorks[index].DPURE_LISTPRICERF; // 純正定価
                        row["DPURE.SHIPMENTCNTRF"] = detailWorks[index].DPURE_SHIPMENTCNTRF; // 純正出荷数
                        //row["DPURE.SALESMONEYRF"] = detailWorks[index].DPURE_SALESMONEYRF; // 純正売上金額
                        row["DPRIM.GOODSMAKERCDRF"] = detailWorks[index].DPRIM_GOODSMAKERCDRF; // 優良商品メーカーコード
                        row["DPRIM.MAKERNAMERF"] = detailWorks[index].DPRIM_MAKERNAMERF; // 優良メーカー名称
                        row["DPRIM.MAKERKANANAMERF"] = detailWorks[index].DPRIM_MAKERKANANAMERF; // 優良メーカーカナ名称
                        row["DPRIM.GOODSNORF"] = detailWorks[index].DPRIM_GOODSNORF; // 優良商品番号
                        row["DPRIM.GOODSNAMERF"] = detailWorks[index].DPRIM_GOODSNAMERF; // 優良商品名称
                        row["DPRIM.GOODSNAMEKANARF"] = detailWorks[index].DPRIM_GOODSNAMEKANARF; // 優良商品名称カナ
                        row["DPRIM.BLGOODSCODERF"] = detailWorks[index].DPRIM_BLGOODSCODERF; // 優良BL商品コード
                        row["DPRIM.SALESUNPRCTAXINCFLRF"] = detailWorks[index].DPRIM_SALESUNPRCTAXINCFLRF; // 優良売上単価（税込，浮動）
                        row["DPRIM.SALESUNPRCTAXEXCFLRF"] = detailWorks[index].DPRIM_SALESUNPRCTAXEXCFLRF; // 優良売上単価（税抜，浮動）
                        row["DPRIM.LISTPRICETAXINCFLRF"] = detailWorks[index].DPRIM_LISTPRICETAXINCFLRF; // 優良定価（税込，浮動）
                        row["DPRIM.LISTPRICETAXEXCFLRF"] = detailWorks[index].DPRIM_LISTPRICETAXEXCFLRF; // 優良定価（税抜，浮動）
                        row["DPRIM.SALESMONEYTAXINCRF"] = detailWorks[index].DPRIM_SALESMONEYTAXINCRF; // 優良売上金額（税込み）
                        row["DPRIM.SALESMONEYTAXEXCRF"] = detailWorks[index].DPRIM_SALESMONEYTAXEXCRF; // 優良売上金額（税抜き）
                        row["DPRIM.TAXATIONDIVCDRF"] = detailWorks[index].DPRIM_TAXATIONDIVCDRF; // 優良課税区分
                        //row["DPRIM.SALESUNPRCFLRF"] = detailWorks[index].DPRIM_SALESUNPRCFLRF; // 優良売上単価
                        //row["DPRIM.LISTPRICERF"] = detailWorks[index].DPRIM_LISTPRICERF; // 優良定価
                        row["DPRIM.SHIPMENTCNTRF"] = detailWorks[index].DPRIM_SHIPMENTCNTRF; // 優良出荷数
                        //row["DPRIM.SALESMONEYRF"] = detailWorks[index].DPRIM_SALESMONEYRF; // 優良売上金額
                        row["DADD.SPECIALNOTERF"] = detailWorks[index].DADD_SPECIALNOTE; // オプション・規格情報
                        # endregion

                        # region [明細項目(自動以外)]
                        // 未設定時 非印字コード
                        # region [未設定]
                        if ( IsZero( detailWorks[index].DPURE_GOODSMAKERCDRF ) ) row["DPURE.GOODSMAKERCDRF"] = DBNull.Value; // 純正商品メーカーコード
                        if ( IsZero( detailWorks[index].DPRIM_GOODSMAKERCDRF ) ) row["DPRIM.GOODSMAKERCDRF"] = DBNull.Value; // 優良商品メーカーコード
                        if ( IsZero( detailWorks[index].DPURE_BLGOODSCODERF ) ) row["DPURE.BLGOODSCODERF"] = DBNull.Value; // 純正BL商品コード
                        if ( IsZero( detailWorks[index].DPRIM_BLGOODSCODERF ) ) row["DPRIM.BLGOODSCODERF"] = DBNull.Value; // 優良BL商品コード
                        # endregion

                        // 印刷単価・印刷定価・印刷金額の確定
                        # region [税込・税抜]
                        // 純正税込フラグ
                        bool pureTaxIn = false;
                        // 優良税込フラグ
                        bool primeTaxIn = false;

                        # region [印字選択]
                        // 消費税区分 0:する　1:しない
                        if ( estimateDefSet.ConsTaxPrintDiv == 0 )
                        {
                            // 0:総額表示しない（税抜き）,1:総額表示する（税込み）
                            if ( slipWork.SALESSLIPRF_TOTALAMOUNTDISPWAYCDRF == 1 )
                            {
                                //------------------------------------------------------------
                                // 総額表示＝する　→　課税区分によらず、常に税込表示
                                //------------------------------------------------------------
                                pureTaxIn = true;
                                primeTaxIn = true;
                            }
                            else
                            {
                                //------------------------------------------------------------
                                // 総額表示＝しない　→　それぞれの課税区分に従う
                                //------------------------------------------------------------
                                // 0:課税,1:非課税,2:課税（内税）
                                if ( detailWorks[index].DPURE_TAXATIONDIVCDRF == 2 )
                                {
                                    // 税込みを印字
                                    pureTaxIn = true;
                                }
                                // 0:課税,1:非課税,2:課税（内税）
                                if ( detailWorks[index].DPRIM_TAXATIONDIVCDRF == 2 )
                                {
                                    // 税込を印字
                                    primeTaxIn = true;
                                }
                            }
                        }
                        # endregion

                        # region [印字項目セット]
                        // 純正
                        if ( pureTaxIn )
                        {
                            // 税込みを印字
                            row["DPURE.SALESUNPRCFLRF"] = detailWorks[index].DPURE_SALESUNPRCTAXINCFLRF; // 純正売上単価
                            row["DPURE.LISTPRICERF"] = detailWorks[index].DPURE_LISTPRICETAXINCFLRF; // 純正定価
                            row["DPURE.SALESMONEYRF"] = detailWorks[index].DPURE_SALESMONEYTAXINCRF; // 純正売上金額
                        }
                        else
                        {
                            // 税抜きを印字
                            row["DPURE.SALESUNPRCFLRF"] = detailWorks[index].DPURE_SALESUNPRCTAXEXCFLRF; // 純正売上単価
                            row["DPURE.LISTPRICERF"] = detailWorks[index].DPURE_LISTPRICETAXEXCFLRF; // 純正定価
                            row["DPURE.SALESMONEYRF"] = detailWorks[index].DPURE_SALESMONEYTAXEXCRF; // 純正売上金額
                        }

                        // 優良
                        if (primeTaxIn)
                        {
                            // 税込みを印字
                            row["DPRIM.SALESUNPRCFLRF"] = detailWorks[index].DPRIM_SALESUNPRCTAXINCFLRF; // 優良売上単価
                            row["DPRIM.LISTPRICERF"] = detailWorks[index].DPRIM_LISTPRICETAXINCFLRF; // 優良定価
                            row["DPRIM.SALESMONEYRF"] = detailWorks[index].DPRIM_SALESMONEYTAXINCRF; // 優良売上金額
                        }
                        else
                        {
                            // 税抜きを印字
                            row["DPRIM.SALESUNPRCFLRF"] = detailWorks[index].DPRIM_SALESUNPRCTAXEXCFLRF; // 優良売上単価
                            row["DPRIM.LISTPRICERF"] = detailWorks[index].DPRIM_LISTPRICETAXEXCFLRF; // 優良定価
                            row["DPRIM.SALESMONEYRF"] = detailWorks[index].DPRIM_SALESMONEYTAXEXCRF; // 優良売上金額
                        }
                        # endregion

                        # endregion

                        // 印字有無区分の反映
                        # region [印字有無区分の反映]
                        // 品番印字区分 
                        if ( estimateDefSet.PartsNoPrtCd == 0 )
                        {
                            // 0:しない→品番空白にする
                            row["DPURE.GOODSNORF"] = DBNull.Value; // 純正商品番号
                            row["DPRIM.GOODSNORF"] = DBNull.Value; // 優良商品番号
                        }
                        // 定価印字区分
                        if ( estimateDefSet.ListPricePrintDiv == 0 )
                        {
                            // 0:しない→定価空白にする
                            row["DPURE.LISTPRICERF"] = DBNull.Value; // 純正定価
                            row["DPRIM.LISTPRICERF"] = DBNull.Value; // 優良定価
                        }
                        # endregion

                        // 優良情報が無い場合は非印字
                        # region [優良情報が無い場合は非印字]
                        // 品番=空白かつ品名=空白なら、優良情報なしと判断する
                        if (string.IsNullOrEmpty(detailWorks[index].DPRIM_GOODSNORF) && string.IsNullOrEmpty(detailWorks[index].DPRIM_GOODSNAMERF))
                        {
                            // 優良情報を全てクリア
                            row["DPRIM.GOODSMAKERCDRF"] = DBNull.Value; // 優良商品メーカーコード
                            row["DPRIM.MAKERNAMERF"] = DBNull.Value; // 優良メーカー名称
                            row["DPRIM.MAKERKANANAMERF"] = DBNull.Value; // 優良メーカーカナ名称
                            row["DPRIM.GOODSNORF"] = DBNull.Value; // 優良商品番号
                            row["DPRIM.GOODSNAMERF"] = DBNull.Value; // 優良商品名称
                            row["DPRIM.GOODSNAMEKANARF"] = DBNull.Value; // 優良商品名称カナ
                            row["DPRIM.BLGOODSCODERF"] = DBNull.Value; // 優良BL商品コード
                            row["DPRIM.SALESUNPRCTAXINCFLRF"] = DBNull.Value; // 優良売上単価（税込，浮動）
                            row["DPRIM.SALESUNPRCTAXEXCFLRF"] = DBNull.Value; // 優良売上単価（税抜，浮動）
                            row["DPRIM.LISTPRICETAXINCFLRF"] = DBNull.Value; // 優良定価（税込，浮動）
                            row["DPRIM.LISTPRICETAXEXCFLRF"] = DBNull.Value; // 優良定価（税抜，浮動）
                            row["DPRIM.SALESMONEYTAXINCRF"] = DBNull.Value; // 優良売上金額（税込み）
                            row["DPRIM.SALESMONEYTAXEXCRF"] = DBNull.Value; // 優良売上金額（税抜き）
                            row["DPRIM.TAXATIONDIVCDRF"] = DBNull.Value; // 優良課税区分
                            row["DPRIM.SALESUNPRCFLRF"] = DBNull.Value; // 優良売上単価
                            row["DPRIM.LISTPRICERF"] = DBNull.Value; // 優良定価
                            row["DPRIM.SHIPMENTCNTRF"] = DBNull.Value; // 優良出荷数
                            row["DPRIM.SALESMONEYRF"] = DBNull.Value; // 優良売上金額
                        }
                        # endregion

                        # endregion
                    }
                    else
                    {
                        //-------------------------------------------
                        // 空明細
                        //-------------------------------------------
                    }

                    # region [制御項目]
                    row[ct_InPageCopyTitle1] = inPageCopyTitle[0][inPageCopyCount];    // 複写タイトル
                    row[ct_InPageCopyTitle2] = inPageCopyTitle[1][inPageCopyCount];    // 複写タイトル
                    row[ct_InPageCopyTitle3] = inPageCopyTitle[2][inPageCopyCount];    // 複写タイトル
                    row[ct_InPageCopyTitle4] = inPageCopyTitle[3][inPageCopyCount];    // 複写タイトル
                    row[ct_InPageCopyCount] = inPageCopyCount;    // 同一ページ内コピーカウント
                    # endregion

                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/16 ADD
                    // タイトル別印字制御対応
                    ReflectColumnVisibleType( ref row, columnVisibleTypeDic, inPageCopyCount );
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/16 ADD

                    table.Rows.Add( row );
                }
            }
        }
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/16 ADD
        /// <summary>
        /// タイトル別印字制御対応
        /// </summary>
        /// <param name="row"></param>
        /// <param name="columnVisibleTypeDic"></param>
        private static void ReflectColumnVisibleType( ref DataRow row, Dictionary<string, string> columnVisibleTypeDic, int inPageCopyCount )
        {
            foreach ( DataColumn column in row.Table.Columns )
            {
                string columnName = column.ColumnName.ToUpper();

                if ( columnVisibleTypeDic.ContainsKey( columnName ) )
                {
                    bool visible = false;

                    # region [タイトル別Visible取得]
                    switch ( columnVisibleTypeDic[columnName] )
                    {
                        case "1":
                            if ( inPageCopyCount == 0 ) visible = true; break;
                        case "2":
                            if ( inPageCopyCount == 1 ) visible = true; break;
                        case "3":
                            if ( inPageCopyCount == 2 ) visible = true; break;
                        case "4":
                            if ( inPageCopyCount == 3 ) visible = true; break;
                        case "5":
                            if ( inPageCopyCount == 4 ) visible = true; break;
                        case "6":
                            if ( inPageCopyCount != 0 ) visible = true; break;
                        case "7":
                            if ( inPageCopyCount != 1 ) visible = true; break;
                        case "8":
                            if ( inPageCopyCount != 2 ) visible = true; break;
                        case "9":
                            if ( inPageCopyCount != 3 ) visible = true; break;
                        case "10":
                            if ( inPageCopyCount != 4 ) visible = true; break;
                        case "11":
                            if ( inPageCopyCount == 0 || inPageCopyCount == 1 ) visible = true; break;
                        case "12":
                            if ( inPageCopyCount == 0 || inPageCopyCount == 1 || inPageCopyCount == 2 ) visible = true; break;
                        case "13":
                            if ( inPageCopyCount == 2 || inPageCopyCount == 3 || inPageCopyCount == 4 ) visible = true; break;
                        case "14":
                            if ( inPageCopyCount == 3 || inPageCopyCount == 4 ) visible = true; break;
                        default:
                            visible = true; break;
                    }
                    # endregion

                    // 印字キャンセル
                    if ( visible == false )
                    {
                        row[columnName] = DBNull.Value;
                    }
                }
            }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/16 ADD
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/16 ADD
        /// <summary>
        /// 自社名称分解処理
        /// </summary>
        /// <param name="originName"></param>
        /// <param name="firstHalf"></param>
        /// <param name="lastHalf"></param>
        private static void DivideEnterpriseName( string originName, out string firstHalf, out string lastHalf )
        {
            # region // DEL
            //// 自社名称の最大長(byte)
            //const int fullByteCount = 40;
            //// 分割後の長さ(byte)
            //const int halfByteCount = 20;

            //// スペースで詰める
            //originName = originName.PadRight( fullByteCount, ' ' );
            //// 前半を取得
            //firstHalf = SubStringOfByte( originName, halfByteCount );
            //// 後半を取得
            //lastHalf = originName.Substring( firstHalf.Length, originName.Length - firstHalf.Length );

            //// 後ろスペースカット
            //firstHalf = firstHalf.TrimEnd();
            //lastHalf = lastHalf.TrimEnd();
            # endregion

            // ＮＳはマスタ設定での入力可能桁数が半角・全角区別しない仕様なので
            // バイト数ではなく文字数で分解する。

            const int fullLength = 20;
            const int divideLength = 10;

            // スペースで詰める
            originName = originName.PadRight( fullLength, ' ' );
            // 分解
            firstHalf = originName.Substring( 0, divideLength ).TrimEnd();
            lastHalf = originName.Substring( divideLength, divideLength ).TrimEnd();
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/16 ADD

        /// <summary>
        /// 明細行数
        /// </summary>
        /// <param name="frePrtPSetWork"></param>
        /// <param name="slipWork"></param>
        /// <param name="estimateDefSet"></param>
        /// <returns></returns>
        private static int GetFeedCount( FrePrtPSetWork frePrtPSetWork, FrePEstFmHead slipWork, EstimateDefSet estimateDefSet )
        {
//# if DEBUG
//            slipWork.HADD_ESTFMDIVRF = EstFmDivState.All;
//            estimateDefSet.OptionPringDivCd = 1;
//            // →ここも　ReflectDetailDesign
//# endif


            // 基本の値は自由帳票印刷設定から取得する
            int feedCount = frePrtPSetWork.FormFeedLineCount;
            if ( feedCount <= 0 ) feedCount = 1;

            // ※見積書の特殊仕様として、１明細の高さが条件により変動するので、
            // 　レイアウト情報によってデータテーブル上の明細数を算出する。

            int countInRow = 1;
            # region [countInRowの算出]
            using ( MemoryStream stream = new MemoryStream( frePrtPSetWork.PrintPosClassData ) )
            {
                // レイアウト情報の展開
                ar.ActiveReport3 prtRpt = new ar.ActiveReport3();
                stream.Position = 0;
                prtRpt.LoadLayout( stream );

                try
                {
                    ar.Section detail = prtRpt.Sections["Detail1"];
                    // 明細デザイン用ラベル
                    ar.Label designDetail2 = null;
                    ar.Label designDetail3 = null;

                    // 明細セクションのコントロールを調査
                    foreach ( ar.ARControl control in detail.Controls )
                    {
                        string tagText = (string)control.Tag;
                        tagText = tagText.Substring( 0, 3 );

                        switch ( tagText )
                        {
                            case "69,":
                                designDetail2 = (ar.Label)control;
                                break;
                            case "70,":
                                designDetail3 = (ar.Label)control;
                                break;
                            default:
                                break;
                        }
                    }

                    //// １明細の行数をカウントする
                    //countInRow = 1;
                    //if ( designDetail2 != null ) countInRow++;
                    //if ( designDetail3 != null ) countInRow++;


                    if ( estimateDefSet.OptionPringDivCd > 0 )
                    {
                        // オプション印刷＝１：する
                        if ( slipWork.HADD_ESTFMDIVRF == EstFmDivState.All )
                        {
                            //--------------------------------------------------------
                            // 純正＋優良＋オプション
                            //--------------------------------------------------------
                            countInRow = 1;
                            if ( designDetail2 != null ) countInRow++;
                            if ( designDetail3 != null ) countInRow++;
                        }
                        else
                        {
                            //--------------------------------------------------------
                            // 純正or優良＋オプション
                            //--------------------------------------------------------
                            countInRow = 1;
                            if ( designDetail3 != null ) countInRow++;
                        }
                    }
                    else
                    {
                        // オプション印刷＝０：しない
                        if ( slipWork.HADD_ESTFMDIVRF == EstFmDivState.All )
                        {
                            //--------------------------------------------------------
                            // 純正＋優良
                            //--------------------------------------------------------
                            countInRow = 1;
                            if ( designDetail2 != null ) countInRow++;
                        }
                        else
                        {
                            //--------------------------------------------------------
                            // 純正or優良
                            //--------------------------------------------------------
                            countInRow = 1;
                        }
                    }

                }
                catch
                {
                }
            }
            # endregion

            // １明細分の行数で割って、切り捨てる
            return (feedCount / countInRow);
        }

        /// <summary>
        /// 明細総行数の算出
        /// </summary>
        /// <param name="dataCount"></param>
        /// <param name="feedCount"></param>
        /// <returns></returns>
        private static int GetAllDetailCount( int dataCount, int feedCount )
        {
            if ( dataCount % feedCount == 0 )
            {
                // 割り切れる → データ行数と明細総行数はイコールでＯＫ
                return dataCount;
            }
            else
            {
                // 割り切れない → 必要な余白を含めた明細行数を返す
                return (dataCount + (feedCount - (dataCount % feedCount)));
            }
        }
        /// <summary>
        /// 現在ページ数取得
        /// </summary>
        /// <param name="index"></param>
        /// <param name="feedCount"></param>
        /// <returns></returns>
        private static int GetPageCount( int index, int feedCount )
        {
            return (index / feedCount) + 1;
        }
        ///// <summary>
        ///// 移動金額
        ///// </summary>
        ///// <param name="frePEstFmDetailWork"></param>
        ///// <returns></returns>
        //private static Int64 GetSTOCKMOVEPRICERF( FrePEstFmDetail frePEstFmDetailWork )
        //{
        //    decimal unitPrice = (decimal)frePEstFmDetailWork.MOVD_STOCKUNITPRICEFLRF; // 仕入単価（税抜,浮動）
        //    decimal moveCount = (decimal)frePEstFmDetailWork.MOVD_MOVECOUNTRF; // 移動数
        //    return (Int64)Round( unitPrice * moveCount );
        //}
        ///// <summary>
        ///// 移動金額（標準価格）
        ///// </summary>
        ///// <param name="frePEstFmDetailWork"></param>
        ///// <returns></returns>
        //private static Int64 GetSTOCKMOVELISTPRICERF( FrePEstFmDetail frePEstFmDetailWork )
        //{
        //    decimal unitPrice = (decimal)frePEstFmDetailWork.MOVD_LISTPRICEFLRF; // 定価（浮動）
        //    decimal moveCount = (decimal)frePEstFmDetailWork.MOVD_MOVECOUNTRF; // 移動数
        //    return (Int64)Round( unitPrice * moveCount );
        //}
        /// <summary>
        /// 複写タイトル取得処理
        /// </summary>
        /// <param name="slipPrtSet"></param>
        /// <returns></returns>
        private static List<List<string>> GetInPageCopyTitles( SlipPrtSetWork slipPrtSet )
        {
            //*********************************************************************
            // 複写１枚目のタイトル数によって、1ページ内のコピー数を決定する為、
            // １枚目のみ string.Empty の判定を行います。
            // 
            // ２枚目以降は１ページ内コピー数への影響が無いので、そのまま全てセットします。
            //*********************************************************************

            List<List<string>> retList = new List<List<string>>();
            List<string> retList1 = new List<string>();

            //----------------------------------------------
            // 複写１枚目のタイトル群
            //----------------------------------------------
            retList1.Add( slipPrtSet.TitleName1 );
            List<string> title1List = new List<string>( new string[] { slipPrtSet.TitleName102, slipPrtSet.TitleName103, slipPrtSet.TitleName104, slipPrtSet.TitleName105 } );
            for ( int index = 0; index < title1List.Count; index++ )
            {
                // 空白があればそこで終了
                if ( title1List[index] == string.Empty ) break;
                // １つ追加
                retList1.Add( title1List[index] );
            }
            retList.Add( retList1 );

            //----------------------------------------------
            // 複写２枚目以降はベタでコピーする
            //----------------------------------------------
            retList.Add( new List<string>( new string[] { slipPrtSet.TitleName2, slipPrtSet.TitleName202, slipPrtSet.TitleName203, slipPrtSet.TitleName204, slipPrtSet.TitleName205 } ) );
            retList.Add( new List<string>( new string[] { slipPrtSet.TitleName3, slipPrtSet.TitleName302, slipPrtSet.TitleName303, slipPrtSet.TitleName304, slipPrtSet.TitleName305 } ) );
            retList.Add( new List<string>( new string[] { slipPrtSet.TitleName4, slipPrtSet.TitleName402, slipPrtSet.TitleName403, slipPrtSet.TitleName404, slipPrtSet.TitleName405 } ) );

            // 返却
            return retList;
        }
        # endregion

        # region [各種区分名称取得]
        /// <summary>
        /// 在庫移動形式名称
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        private static string GetHADD_STOCKMOVEFORMALNMRFRF( int code )
        {
            // 1:在庫移動、2：倉庫移動
            switch ( code )
            {
                case 1:
                    return "在庫移動";
                case 2:
                    return "倉庫移動";
                default:
                    return string.Empty;
            }
        }
        /// <summary>
        /// 在庫区分名称
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        private static string GetDADD_STOCKDIVNMRFRF( int code )
        {
            // 0:自社、1:受託
            switch ( code )
            {
                case 0:
                    return "自社";
                case 1:
                    return "受託";
                default:
                    return string.Empty;
            }
        }
        /// <summary>
        /// 課税区分名称
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        private static string GetDADD_TAXATIONDIVCDNMRFRF( int code )
        {
            // 0:外税,1:非課税,2:内税
            switch ( code )
            {
                case 0:
                    return "外税";
                case 1:
                    return "非課税";
                case 2:
                    return "内税";
                default:
                    return string.Empty;
            }
        }
        /// <summary>
        /// 純正区分名称
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        private static string GetDADD_PURECODENMRFRF( int code )
        {
            // 0:純正、1:優良
            switch ( code )
            {
                case 0:
                    return "純正";
                case 1:
                    return "優良";
                default:
                    return string.Empty;
            }
        }
        # endregion

        # region [日付関連項目 展開処理]
        /// <summary>
        /// 日付関連項目　展開
        /// </summary>
        /// <param name="targetRow"></param>
        /// <param name="eraNameDispCd"></param>
        /// <param name="date"></param>
        /// <param name="dateColumnName"></param>
        /// <param name="isMonth"></param>
        private static void ExtractDate( ref DataRow targetRow, int eraNameDispCd, DateTime date, string dateColumnName, bool isMonth )
        {
            // DateTimeを対応するInt値に変換
            int dateInt = 0;
            if ( date != DateTime.MinValue )
            {
                if ( !isMonth )
                {
                    dateInt = (date.Year * 10000) + (date.Month * 100) + (date.Day);
                }
                else
                {
                    dateInt = (date.Year * 100) + (date.Month);
                }
            }

            // 日付展開メソッドに渡す
            ExtractDate( ref targetRow, eraNameDispCd, dateInt, dateColumnName, isMonth );
        }
        /// <summary>
        /// 日付関連項目　展開
        /// </summary>
        /// <param name="targetRow"></param>
        /// <param name="eraNameDispCd">0:西暦　1:和暦</param>
        /// <param name="date"></param>
        /// <param name="dateColumnName"></param>
        /// <param name="isMonth"></param>
        private static void ExtractDate( ref DataRow targetRow, int eraNameDispCd, int date, string dateColumnName, bool isMonth )
        {
            //-------------------------------------------------------------------
            // 【項目の印字有無】
            //         YMD YM Y
            // 2009    ○　○　○
            // 01      ○　○　×
            // 31      ○　×　×
            // 年      ○　○　○
            // 月      ○　○　×
            // 日      ○　×　×
            // /       ○　○　×
            // .       ○　○　×
            // 平成    ○　○　○
            // H       ○　○　○
            // 21      ○　○　○
            //-------------------------------------------------------------------

            // 和暦フラグ
            bool jpEra = (eraNameDispCd == 1);
            // 年のみ判定フラグ
            bool isYear = false;

            if ( date != 0 )
            {
                // 年月項目の場合は、和暦変換に備えて指定年月の最終日に変換する
                if ( isMonth )
                {
                    // 年のみ判定("200900"→2009年)
                    isYear = (date % 100 == 0);

                    if ( isYear )
                    {
                        //-----------------------------------------------
                        // 年のみ
                        //-----------------------------------------------

                        // 指定年月の日数を求める(=その年の最終日)※12/31ですが念のため…
                        int dd = DateTime.DaysInMonth( date / 100, 12 );

                        // YYYYMMDDにする
                        date = ((int)(date / 100) * 10000) + (12 * 100) + dd;
                    }
                    else
                    {
                        //-----------------------------------------------
                        // 年月のみ
                        //-----------------------------------------------

                        // 指定年月の日数を求める(=その月の最終日)
                        int dd = DateTime.DaysInMonth( date / 100, date % 100 );

                        // YYYYMMDDにする
                        date = (date * 100) + dd;
                    }
                }

                // 年（和暦or西暦）
                if ( jpEra )
                {
                    // 和暦
                    targetRow[string.Format( "{0}{1}RF", dateColumnName, "FW" )] = GetDateFW( date ); // 和暦年
                    targetRow[string.Format( "{0}{1}RF", dateColumnName, "FG" )] = TDateTime.LongDateToString( "GG", date ); // 和暦元号
                    targetRow[string.Format( "{0}{1}RF", dateColumnName, "FR" )] = TDateTime.LongDateToString( "gg", date ); // 和暦元号略号
                    // クリア
                    targetRow[string.Format( "{0}{1}RF", dateColumnName, "FY" )] = DBNull.Value;
                    targetRow[string.Format( "{0}{1}RF", dateColumnName, "FS" )] = DBNull.Value;
                }
                else
                {
                    // 西暦
                    targetRow[string.Format( "{0}{1}RF", dateColumnName, "FY" )] = (date / 10000); // 西暦年
                    targetRow[string.Format( "{0}{1}RF", dateColumnName, "FS" )] = (date / 10000) % 100; // 西暦年(略)
                    // クリア
                    targetRow[string.Format( "{0}{1}RF", dateColumnName, "FW" )] = DBNull.Value;
                    targetRow[string.Format( "{0}{1}RF", dateColumnName, "FG" )] = DBNull.Value;
                    targetRow[string.Format( "{0}{1}RF", dateColumnName, "FR" )] = DBNull.Value;
                }

                // 年リテラル
                targetRow[string.Format( "{0}{1}RF", dateColumnName, "FLY" )] = "年";

                if ( !isYear )
                {
                    // 月
                    targetRow[string.Format( "{0}{1}RF", dateColumnName, "FM" )] = (date / 100) % 100; // 月

                    // リテラル系
                    targetRow[string.Format( "{0}{1}RF", dateColumnName, "FLS" )] = "/";
                    targetRow[string.Format( "{0}{1}RF", dateColumnName, "FLP" )] = ".";
                    targetRow[string.Format( "{0}{1}RF", dateColumnName, "FLM" )] = "月";

                    if ( !isMonth )
                    {
                        targetRow[string.Format( "{0}{1}RF", dateColumnName, "FD" )] = (date % 100); // 日
                        targetRow[string.Format( "{0}{1}RF", dateColumnName, "FLD" )] = "日";
                    }
                }
            }
            else
            {
                // 無効な日付ならば空白
                targetRow[string.Format( "{0}{1}RF", dateColumnName, "FY" )] = DBNull.Value;
                targetRow[string.Format( "{0}{1}RF", dateColumnName, "FS" )] = DBNull.Value;
                targetRow[string.Format( "{0}{1}RF", dateColumnName, "FW" )] = DBNull.Value;
                targetRow[string.Format( "{0}{1}RF", dateColumnName, "FM" )] = DBNull.Value;
                targetRow[string.Format( "{0}{1}RF", dateColumnName, "FG" )] = DBNull.Value;
                targetRow[string.Format( "{0}{1}RF", dateColumnName, "FR" )] = DBNull.Value;
                targetRow[string.Format( "{0}{1}RF", dateColumnName, "FLS" )] = DBNull.Value;
                targetRow[string.Format( "{0}{1}RF", dateColumnName, "FLP" )] = DBNull.Value;
                targetRow[string.Format( "{0}{1}RF", dateColumnName, "FLY" )] = DBNull.Value;
                targetRow[string.Format( "{0}{1}RF", dateColumnName, "FLM" )] = DBNull.Value;

                if ( !isMonth )
                {
                    targetRow[string.Format( "{0}{1}RF", dateColumnName, "FD" )] = DBNull.Value;
                    targetRow[string.Format( "{0}{1}RF", dateColumnName, "FLD" )] = DBNull.Value;
                }
            }
        }
        /// <summary>
        /// 和暦年取得処理（H20の"20"のみを取得する）
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        private static int GetDateFW( int date )
        {
            // 和暦略号を取得
            string date_gg = TDateTime.LongDateToString( "gg", date );  // H
            string date_exggyy = TDateTime.LongDateToString( "exggyy", date );  // H20

            // "H20" から "H" を取り除いて "20" を取得する
            return ToInt( date_exggyy.Substring( date_gg.Length, date_exggyy.Length - date_gg.Length ) );

        }
        /// <summary>
        /// 数値変換処理
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        private static int ToInt( string text )
        {
            try
            {
                return Int32.Parse( text );
            }
            catch
            {
                return 0;
            }
        }

        # endregion

        # region [共通処理]
        /// <summary>
        /// 四捨五入処理
        /// </summary>
        /// <param name="parameter">端数処理するdecimal値</param>
        /// <returns>四捨五入されたdecimal</returns>
        public static decimal Round( decimal parameter )
        {
            // 四捨五入
            return Round( parameter, 0, 5 );
        }
        /// <summary>
        /// 四捨五入処理
        /// </summary>
        /// <param name="parameter">端数処理するDouble値</param>
        /// <param name="digits">小数点以下の有効桁数</param>
        /// <param name="divide">切り上げる境界の値 1～9　(ex. 5→四捨五入)</param>
        /// <returns>四捨五入されたdecimal</returns>
        public static decimal Round( decimal parameter, int digits, int divide )
        {
            decimal dCoef = (decimal)Math.Pow( 10, digits );
            decimal dDiv = 1.0m - ((decimal)divide / 10);

            if ( parameter > 0 )
            {
                // 0.5を足して「＋のときの切り捨て」（ゼロに近づける）
                return Math.Floor( (parameter * dCoef) + dDiv ) / dCoef;
            }
            else
            {
                // -0.5を足して「－のときの切り捨て」（ゼロに近づける）
                return Math.Ceiling( (parameter * dCoef) - dDiv ) / dCoef;
            }
        }
        /// <summary>
        /// 文字列コードのゼロ判定
        /// </summary>
        /// <param name="textValue"></param>
        /// <returns></returns>
        private static bool IsZero( string textValue )
        {
            if ( textValue == null || textValue.Trim() == string.Empty ) return true;

            try
            {
                return (Int32.Parse( textValue ) == 0);
            }
            catch
            {
                return true;
            }
        }
        /// <summary>
        /// 数値コードのゼロ判定
        /// </summary>
        /// <param name="intValue"></param>
        /// <returns></returns>
        private static bool IsZero( int intValue )
        {
            return (intValue == 0);
        }
        # endregion

        # region [明細項目分類]
        /// <summary>
        /// 明細１項目
        /// </summary>
        /// <returns></returns>
        public static List<string> GetDesignDetail1List()
        {
            List<string> list = new List<string>();
            list.Add( "SALESDETAILRF.SALESSLIPNUMRF" );
            list.Add( "SALESDETAILRF.SALESROWNORF" );
            list.Add( "DPURE.GOODSMAKERCDRF" );
            list.Add( "DPURE.MAKERNAMERF" );
            list.Add( "DPURE.MAKERKANANAMERF" );
            list.Add( "DPURE.GOODSNORF" );
            list.Add( "DPURE.GOODSNAMERF" );
            list.Add( "DPURE.GOODSNAMEKANARF" );
            list.Add( "DPURE.BLGOODSCODERF" );
            list.Add( "DPURE.SALESUNPRCTAXINCFLRF" );
            list.Add( "DPURE.SALESUNPRCTAXEXCFLRF" );
            list.Add( "DPURE.LISTPRICETAXINCFLRF" );
            list.Add( "DPURE.LISTPRICETAXEXCFLRF" );
            list.Add( "DPURE.SALESMONEYTAXINCRF" );
            list.Add( "DPURE.SALESMONEYTAXEXCRF" );
            list.Add( "DPURE.TAXATIONDIVCDRF" );
            list.Add( "DPURE.SALESUNPRCFLRF" );
            list.Add( "DPURE.LISTPRICERF" );
            list.Add( "DPURE.SHIPMENTCNTRF" );
            list.Add( "DPURE.SALESMONEYRF" );
            return list;
        }
        /// <summary>
        /// 明細２項目
        /// </summary>
        /// <returns></returns>
        public static List<string> GetDesignDetail2List()
        {
            List<string> list = new List<string>();
            list.Add( "DPRIM.GOODSMAKERCDRF" );
            list.Add( "DPRIM.MAKERNAMERF" );
            list.Add( "DPRIM.MAKERKANANAMERF" );
            list.Add( "DPRIM.GOODSNORF" );
            list.Add( "DPRIM.GOODSNAMERF" );
            list.Add( "DPRIM.GOODSNAMEKANARF" );
            list.Add( "DPRIM.BLGOODSCODERF" );
            list.Add( "DPRIM.SALESUNPRCTAXINCFLRF" );
            list.Add( "DPRIM.SALESUNPRCTAXEXCFLRF" );
            list.Add( "DPRIM.LISTPRICETAXINCFLRF" );
            list.Add( "DPRIM.LISTPRICETAXEXCFLRF" );
            list.Add( "DPRIM.SALESMONEYTAXINCRF" );
            list.Add( "DPRIM.SALESMONEYTAXEXCRF" );
            list.Add( "DPRIM.TAXATIONDIVCDRF" );
            list.Add( "DPRIM.SALESUNPRCFLRF" );
            list.Add( "DPRIM.LISTPRICERF" );
            list.Add( "DPRIM.SHIPMENTCNTRF" );
            list.Add( "DPRIM.SALESMONEYRF" );
            return list;
        }
        /// <summary>
        /// 明細３項目
        /// </summary>
        /// <returns></returns>
        public static List<string> GetDesignDetail3List()
        {
            List<string> list = new List<string>();
            list.Add( "DADD.SPECIALNOTERF" );
            return list;
        }
        # endregion

        # region [行からの情報取得]
        /// <summary>
        /// 見積書区分取得
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public static EstFmDivState GetRowInfoEstFmDiv( DataRow row )
        {
            return (EstFmDivState)row["HADD.ESTFMDIVRF"];
        }
        /// <summary>
        /// 課税区分取得
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public static int GetRowInfoConsTaxLayMethod( DataRow row )
        {
            return (int)row["SALESSLIPRF.CONSTAXLAYMETHODRF"];
        }
        /// <summary>
        /// 伝票番号取得
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public static string GetRowInfoSalesSlipNum( DataRow row )
        {
            return (string)row["SALESSLIPRF.SALESSLIPNUMRF"];
        }
        # endregion

        # region [合計項目分類]
        /// <summary>
        /// 小計
        /// </summary>
        /// <returns></returns>
        public static List<string> GetDesignSubTotalList()
        {
            List<string> list = new List<string>();
            list.Add( "HPURE.SALESTOTALTAXEXCRF" ); // 純正売上伝票合計（税抜き）
            list.Add( "HPURE.SALESSUBTOTALTAXEXCRF" ); // 純正売上小計（税抜き）
            list.Add( "HPRIME.SALESTOTALTAXEXCRF" ); // 優良売上伝票合計（税抜き）
            list.Add( "HPRIME.SALESSUBTOTALTAXEXCRF" ); // 優良売上小計（税抜き）
            return list;
        }
        /// <summary>
        /// 税
        /// </summary>
        /// <returns></returns>
        public static List<string> GetDesignTaxList()
        {
            List<string> list = new List<string>();
            list.Add( "HPURE.SALESSUBTOTALTAXRF" ); // 純正売上小計（税）
            list.Add( "HPRIME.SALESSUBTOTALTAXRF" ); // 優良売上小計（税）
            return list;
        }
        /// <summary>
        /// 合計
        /// </summary>
        /// <returns></returns>
        public static List<string> GetDesignTotalList()
        {
            List<string> list = new List<string>();
            list.Add( "HPURE.SALESTOTALTAXINCRF" ); // 純正売上伝票合計（税込み）
            list.Add( "HPURE.SALESSUBTOTALTAXINCRF" ); // 純正売上小計（税込み）
            list.Add( "HPRIME.SALESTOTALTAXINCRF" ); // 優良売上伝票合計（税込み）
            list.Add( "HPRIME.SALESSUBTOTALTAXINCRF" ); // 優良売上小計（税込み）
            return list;
        }
        /// <summary>
        /// 優良計
        /// </summary>
        /// <returns></returns>
        public static List<string> GetDesignTotalPrimeList()
        {
            List<string> list = new List<string>();
            list.Add( "HPRIME.SALESTOTALTAXINCRF" ); // 優良売上伝票合計（税込み）
            list.Add( "HPRIME.SALESTOTALTAXEXCRF" ); // 優良売上伝票合計（税抜き）
            list.Add( "HPRIME.SALESSUBTOTALTAXINCRF" ); // 優良売上小計（税込み）
            list.Add( "HPRIME.SALESSUBTOTALTAXEXCRF" ); // 優良売上小計（税抜き）
            list.Add( "HPRIME.SALESSUBTOTALTAXRF" ); // 優良売上小計（税）
            return list;
        }
        # endregion

        # region [縦倍角対応リスト]
        /// <summary>
        /// 縦倍角対応リスト取得処理
        /// </summary>
        /// <returns></returns>
        public static List<string> GetDoubleHeightTargetList()
        {
            List<string> list = new List<string>();

            list.Add( "HLG.PRINTCUSTOMERNAMEJOIN12RF" );  // （縦倍）得意先名１＋得意先名２
            list.Add( "HLG.PRINTCUSTOMERNAMEJOIN12HNRF" );  // （縦倍）得意先名１＋得意先名２＋敬称
            list.Add( "HLG.CUSTOMERNAMERF" );  // （縦倍）得意先名称
            list.Add( "HLG.CUSTOMERNAME2RF" );  // （縦倍）得意先名称2
            list.Add( "HLG.CUSTOMERSNMRF" );  // （縦倍）得意先略称
            list.Add( "HLG.HONORIFICTITLERF" );  // （縦倍）得意先敬称
            list.Add( "HLG.PRINTCUSTOMERNM1RF" );  // （縦倍）印刷用得意先名称(上段)
            list.Add( "HLG.PRINTCUSTOMERNM2RF" );  // （縦倍）印刷用得意先名称(下段)

            return list;
        }
        # endregion
    }
}
