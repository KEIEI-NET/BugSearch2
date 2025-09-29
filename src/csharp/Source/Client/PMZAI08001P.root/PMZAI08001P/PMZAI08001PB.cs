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

namespace Broadleaf.Drawing.Printing
{
	/// <summary>
	/// 自由帳票(在庫移動伝票)印刷クラス
	/// </summary>
	/// <remarks>
    /// <br>Note         : 印刷DataSourceのテーブル生成を行います。</br>
    /// <br>               </br>
	/// <br>Programmer   : 22018 鈴木　正臣</br>
	/// <br>Date         : 2008.06.03</br>
	/// <br></br>
	/// <br>Update Note  : 2010/03/31  30531 大矢 睦美</br>
    /// <br>             : Mantis【14813】和歴・西暦の印字制御の修正</br>
    /// <br></br>
    /// <br>Update Note  : 2010/05/27  30531 大矢 睦美</br>
    /// <br>             : 出庫、入庫タイトルの印字内容を設定できるように修正</br>
    /// <br></br>
    /// <br>Update Note  : 2011/08/15 李占川 連番985</br>
    /// <br>             　【PM要望改良9月配信分】Redmine#23541 連番985の対応</br> 
    /// <br></br>
    /// <br>Update Note  : 2011/09/27  22018 鈴木 正臣</br>
    /// <br>               一度の印刷で伝票が5枚印刷される不具合の修正</br>
    /// <br>Update Note  : 2017/08/30 3H 楊善娟</br>
    /// <br>管理番号     : 11370074-00 ハンディ対応（2次）</br>
    /// <br></br>
	/// </remarks>
	internal class PMZAI08001PB
    {
        # region [public static readonly メンバ]
        /// <summary>自由帳票在庫移動伝票テーブル</summary>
        public static readonly string ct_TBL_FREPSTOCKMOVESLIP = "FREPSTOCKMOVESLIP";
        /// <summary>同一ページ内コピーカウントcolumn名称</summary>
        public static readonly string ct_InPageCopyCount = "PMZAI08001P.INPAGECOPYCOUNT";
        /// <summary>複写タイトル１</summary>
        public static readonly string ct_InPageCopyTitle1 = "PMZAI08001P.INPAGECOPYTITLE1";
        /// <summary>複写タイトル２</summary>
        public static readonly string ct_InPageCopyTitle2 = "PMZAI08001P.INPAGECOPYTITLE2";
        /// <summary>複写タイトル３</summary>
        public static readonly string ct_InPageCopyTitle3 = "PMZAI08001P.INPAGECOPYTITLE3";
        /// <summary>複写タイトル４</summary>
        public static readonly string ct_InPageCopyTitle4 = "PMZAI08001P.INPAGECOPYTITLE4";
        /// <summary>頁数</summary>
        public static readonly string ct_PageCount = "PAGE.PAGECOUNTRF";
        /// <summary>出庫タイトル</summary>
        public static readonly string ct_BfTitle = "LABEL.BFTITLERF";
        /// <summary>入庫タイトル</summary>
        public static readonly string ct_AfTitle = "LABEL.AFTITLERF";

        // --- ADD 李占川 2011/08/15---------->>>>>
        /// <summary>(Label)サブレポート用伝票タイトル１・１</summary>
        public static readonly string ct_SlipTitle11 = "PMZAI08001P.SLIPTITLE11";
        /// <summary>(Label)サブレポート用伝票タイトル１・２</summary>
        public static readonly string ct_SlipTitle12 = "PMZAI08001P.SLIPTITLE12";
        /// <summary>(Label)サブレポート用伝票タイトル１・３</summary>
        public static readonly string ct_SlipTitle13 = "PMZAI08001P.SLIPTITLE13";
        /// <summary>(Label)サブレポート用伝票タイトル１・４</summary>
        public static readonly string ct_SlipTitle14 = "PMZAI08001P.SLIPTITLE14";
        /// <summary>(Label)サブレポート用伝票タイトル１・５</summary>
        public static readonly string ct_SlipTitle15 = "PMZAI08001P.SLIPTITLE15";
        /// <summary>(Label)サブレポート用伝票タイトル２・１</summary>
        public static readonly string ct_SlipTitle21 = "PMZAI08001P.SLIPTITLE21";
        /// <summary>(Label)サブレポート用伝票タイトル２・２</summary>
        public static readonly string ct_SlipTitle22 = "PMZAI08001P.SLIPTITLE22";
        /// <summary>(Label)サブレポート用伝票タイトル２・３</summary>
        public static readonly string ct_SlipTitle23 = "PMZAI08001P.SLIPTITLE23";
        /// <summary>(Label)サブレポート用伝票タイトル２・４</summary>
        public static readonly string ct_SlipTitle24 = "PMZAI08001P.SLIPTITLE24";
        /// <summary>(Label)サブレポート用伝票タイトル２・５</summary>
        public static readonly string ct_SlipTitle25 = "PMZAI08001P.SLIPTITLE25";
        /// <summary>(Label)サブレポート用伝票タイトル３・１</summary>
        public static readonly string ct_SlipTitle31 = "PMZAI08001P.SLIPTITLE31";
        /// <summary>(Label)サブレポート用伝票タイトル３・２</summary>
        public static readonly string ct_SlipTitle32 = "PMZAI08001P.SLIPTITLE32";
        /// <summary>(Label)サブレポート用伝票タイトル３・３</summary>
        public static readonly string ct_SlipTitle33 = "PMZAI08001P.SLIPTITLE33";
        /// <summary>(Label)サブレポート用伝票タイトル３・４</summary>
        public static readonly string ct_SlipTitle34 = "PMZAI08001P.SLIPTITLE34";
        /// <summary>(Label)サブレポート用伝票タイトル３・５</summary>
        public static readonly string ct_SlipTitle35 = "PMZAI08001P.SLIPTITLE35";
        /// <summary>(Label)サブレポート用伝票タイトル４・１</summary>
        public static readonly string ct_SlipTitle41 = "PMZAI08001P.SLIPTITLE41";
        /// <summary>(Label)サブレポート用伝票タイトル４・２</summary>
        public static readonly string ct_SlipTitle42 = "PMZAI08001P.SLIPTITLE42";
        /// <summary>(Label)サブレポート用伝票タイトル４・３</summary>
        public static readonly string ct_SlipTitle43 = "PMZAI08001P.SLIPTITLE43";
        /// <summary>(Label)サブレポート用伝票タイトル４・４</summary>
        public static readonly string ct_SlipTitle44 = "PMZAI08001P.SLIPTITLE44";
        /// <summary>(Label)サブレポート用伝票タイトル４・５</summary>
        public static readonly string ct_SlipTitle45 = "PMZAI08001P.SLIPTITLE45";
        // --- ADD 李占川 2011/08/15----------<<<<<
        # endregion

        // --- ADD  大矢睦美  2010/03/31 ---------->>>>>
        #region [private static メンバ]
        /// <summary>レポート項目ディクショナリ</summary>
        private static Dictionary<string, string> stc_reportItemDic;
        #endregion
        
        #region [public static メンバ]
        /// <summary>レポート項目ディクショナリ</summary>
        public static Dictionary<string, string> ReportItemDic
        {
            get
            {
                if (stc_reportItemDic == null)
                {
                    stc_reportItemDic = new Dictionary<string, string>();
                }
                return stc_reportItemDic;
            }
            set { stc_reportItemDic = value; }
        }
        #endregion
        // --- ADD  大矢睦美  2010/03/31 ----------<<<<<

        # region [データテーブル生成]
        /// <summary>
        /// データテーブル生成処理（スキーマ定義）
        /// </summary>
        /// <remarks>
        /// <br>Update Note  : 2017/08/30 3H 楊善娟</br>
        /// <br>管理番号     : 11370074-00 ハンディ対応（2次）</br>
        /// </remarks>
        public static DataTable CreateFrePStockMoveSlipTable( int index)
        {
            DataTable table = new DataTable( ct_TBL_FREPSTOCKMOVESLIP + index.ToString() );
            
            # region [スキーマ定義（伝票項目）]
            table.Columns.Add( new DataColumn( "MOVH.STOCKMOVEFORMALRF", typeof( Int32 ) ) ); // 在庫移動形式
            table.Columns.Add( new DataColumn( "MOVH.STOCKMOVESLIPNORF", typeof( Int32 ) ) ); // 在庫移動伝票番号
            table.Columns.Add( new DataColumn( "MOVH.BFSECTIONCODERF", typeof( String ) ) ); // 移動元拠点コード
            table.Columns.Add( new DataColumn( "MOVH.BFSECTIONGUIDESNMRF", typeof( String ) ) ); // 移動元拠点ガイド略称
            table.Columns.Add( new DataColumn( "MOVH.BFENTERWAREHCODERF", typeof( String ) ) ); // 移動元倉庫コード
            table.Columns.Add( new DataColumn( "MOVH.BFENTERWAREHNAMERF", typeof( String ) ) ); // 移動元倉庫名称
            table.Columns.Add( new DataColumn( "MOVH.AFSECTIONCODERF", typeof( String ) ) ); // 移動先拠点コード
            table.Columns.Add( new DataColumn( "MOVH.AFSECTIONGUIDESNMRF", typeof( String ) ) ); // 移動先拠点ガイド略称
            table.Columns.Add( new DataColumn( "MOVH.AFENTERWAREHCODERF", typeof( String ) ) ); // 移動先倉庫コード
            table.Columns.Add( new DataColumn( "MOVH.AFENTERWAREHNAMERF", typeof( String ) ) ); // 移動先倉庫名称
            table.Columns.Add( new DataColumn( "MOVH.SHIPMENTSCDLDAYRF", typeof( Int32 ) ) ); // 出荷予定日
            table.Columns.Add( new DataColumn( "MOVH.INPUTDAYRF", typeof( Int32 ) ) ); // 入力日
            table.Columns.Add( new DataColumn( "MOVH.STOCKMVEMPCODERF", typeof( String ) ) ); // 在庫移動入力従業員コード
            table.Columns.Add( new DataColumn( "MOVH.STOCKMVEMPNAMERF", typeof( String ) ) ); // 在庫移動入力従業員名称
            table.Columns.Add( new DataColumn( "MOVH.SHIPAGENTCDRF", typeof( String ) ) ); // 出荷担当従業員コード
            table.Columns.Add( new DataColumn( "MOVH.SHIPAGENTNMRF", typeof( String ) ) ); // 出荷担当従業員名称
            table.Columns.Add( new DataColumn( "MOVH.RECEIVEAGENTCDRF", typeof( String ) ) ); // 引取担当従業員コード
            table.Columns.Add( new DataColumn( "MOVH.RECEIVEAGENTNMRF", typeof( String ) ) ); // 引取担当従業員名称
            table.Columns.Add( new DataColumn( "MOVH.OUTLINERF", typeof( String ) ) ); // 伝票摘要
            table.Columns.Add( new DataColumn( "MOVH.WAREHOUSENOTE1RF", typeof( String ) ) ); // 倉庫備考1
            table.Columns.Add( new DataColumn( "MOVH.SLIPPRINTFINISHCDRF", typeof( Int32 ) ) ); // 伝票発行済区分
            table.Columns.Add( new DataColumn( "SEC1.SECTIONGUIDENMRF", typeof( String ) ) ); // 拠点ガイド名称
            table.Columns.Add( new DataColumn( "SEC1.COMPANYNAMECD1RF", typeof( Int32 ) ) ); // 自社名称コード1
            table.Columns.Add( new DataColumn( "SEC2.SECTIONGUIDENMRF", typeof( String ) ) ); // 拠点ガイド名称
            table.Columns.Add( new DataColumn( "SEC2.COMPANYNAMECD1RF", typeof( Int32 ) ) ); // 自社名称コード1
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
            table.Columns.Add( new DataColumn( "CMP1.COMPANYPRRF", typeof( String ) ) ); // 自社PR文
            table.Columns.Add( new DataColumn( "CMP1.COMPANYNAME1RF", typeof( String ) ) ); // 自社名称1
            table.Columns.Add( new DataColumn( "CMP1.COMPANYNAME2RF", typeof( String ) ) ); // 自社名称2
            table.Columns.Add( new DataColumn( "CMP1.POSTNORF", typeof( String ) ) ); // 郵便番号
            table.Columns.Add( new DataColumn( "CMP1.ADDRESS1RF", typeof( String ) ) ); // 住所1（都道府県市区郡・町村・字）
            table.Columns.Add( new DataColumn( "CMP1.ADDRESS3RF", typeof( String ) ) ); // 住所3（番地）
            table.Columns.Add( new DataColumn( "CMP1.ADDRESS4RF", typeof( String ) ) ); // 住所4（アパート名称）
            table.Columns.Add( new DataColumn( "CMP1.COMPANYTELNO1RF", typeof( String ) ) ); // 自社電話番号1
            table.Columns.Add( new DataColumn( "CMP1.COMPANYTELNO2RF", typeof( String ) ) ); // 自社電話番号2
            table.Columns.Add( new DataColumn( "CMP1.COMPANYTELNO3RF", typeof( String ) ) ); // 自社電話番号3
            table.Columns.Add( new DataColumn( "CMP1.COMPANYTELTITLE1RF", typeof( String ) ) ); // 自社電話番号タイトル1
            table.Columns.Add( new DataColumn( "CMP1.COMPANYTELTITLE2RF", typeof( String ) ) ); // 自社電話番号タイトル2
            table.Columns.Add( new DataColumn( "CMP1.COMPANYTELTITLE3RF", typeof( String ) ) ); // 自社電話番号タイトル3
            table.Columns.Add( new DataColumn( "CMP1.TRANSFERGUIDANCERF", typeof( String ) ) ); // 銀行振込案内文
            table.Columns.Add( new DataColumn( "CMP1.ACCOUNTNOINFO1RF", typeof( String ) ) ); // 銀行口座1
            table.Columns.Add( new DataColumn( "CMP1.ACCOUNTNOINFO2RF", typeof( String ) ) ); // 銀行口座2
            table.Columns.Add( new DataColumn( "CMP1.ACCOUNTNOINFO3RF", typeof( String ) ) ); // 銀行口座3
            table.Columns.Add( new DataColumn( "CMP1.COMPANYSETNOTE1RF", typeof( String ) ) ); // 自社設定摘要1
            table.Columns.Add( new DataColumn( "CMP1.COMPANYSETNOTE2RF", typeof( String ) ) ); // 自社設定摘要2
            table.Columns.Add( new DataColumn( "CMP1.IMAGEINFODIVRF", typeof( Int32 ) ) ); // 画像情報区分
            table.Columns.Add( new DataColumn( "CMP1.IMAGEINFOCODERF", typeof( Int32 ) ) ); // 画像情報コード
            table.Columns.Add( new DataColumn( "CMP1.COMPANYURLRF", typeof( String ) ) ); // 自社URL
            table.Columns.Add( new DataColumn( "CMP1.COMPANYPRSENTENCE2RF", typeof( String ) ) ); // 自社PR文2
            table.Columns.Add( new DataColumn( "CMP1.IMAGECOMMENTFORPRT1RF", typeof( String ) ) ); // 画像印字用コメント1
            table.Columns.Add( new DataColumn( "CMP1.IMAGECOMMENTFORPRT2RF", typeof( String ) ) ); // 画像印字用コメント2
            table.Columns.Add( new DataColumn( "CMP2.COMPANYPRRF", typeof( String ) ) ); // 自社PR文
            table.Columns.Add( new DataColumn( "CMP2.COMPANYNAME1RF", typeof( String ) ) ); // 自社名称1
            table.Columns.Add( new DataColumn( "CMP2.COMPANYNAME2RF", typeof( String ) ) ); // 自社名称2
            table.Columns.Add( new DataColumn( "CMP2.POSTNORF", typeof( String ) ) ); // 郵便番号
            table.Columns.Add( new DataColumn( "CMP2.ADDRESS1RF", typeof( String ) ) ); // 住所1（都道府県市区郡・町村・字）
            table.Columns.Add( new DataColumn( "CMP2.ADDRESS3RF", typeof( String ) ) ); // 住所3（番地）
            table.Columns.Add( new DataColumn( "CMP2.ADDRESS4RF", typeof( String ) ) ); // 住所4（アパート名称）
            table.Columns.Add( new DataColumn( "CMP2.COMPANYTELNO1RF", typeof( String ) ) ); // 自社電話番号1
            table.Columns.Add( new DataColumn( "CMP2.COMPANYTELNO2RF", typeof( String ) ) ); // 自社電話番号2
            table.Columns.Add( new DataColumn( "CMP2.COMPANYTELNO3RF", typeof( String ) ) ); // 自社電話番号3
            table.Columns.Add( new DataColumn( "CMP2.COMPANYTELTITLE1RF", typeof( String ) ) ); // 自社電話番号タイトル1
            table.Columns.Add( new DataColumn( "CMP2.COMPANYTELTITLE2RF", typeof( String ) ) ); // 自社電話番号タイトル2
            table.Columns.Add( new DataColumn( "CMP2.COMPANYTELTITLE3RF", typeof( String ) ) ); // 自社電話番号タイトル3
            table.Columns.Add( new DataColumn( "CMP2.TRANSFERGUIDANCERF", typeof( String ) ) ); // 銀行振込案内文
            table.Columns.Add( new DataColumn( "CMP2.ACCOUNTNOINFO1RF", typeof( String ) ) ); // 銀行口座1
            table.Columns.Add( new DataColumn( "CMP2.ACCOUNTNOINFO2RF", typeof( String ) ) ); // 銀行口座2
            table.Columns.Add( new DataColumn( "CMP2.ACCOUNTNOINFO3RF", typeof( String ) ) ); // 銀行口座3
            table.Columns.Add( new DataColumn( "CMP2.COMPANYSETNOTE1RF", typeof( String ) ) ); // 自社設定摘要1
            table.Columns.Add( new DataColumn( "CMP2.COMPANYSETNOTE2RF", typeof( String ) ) ); // 自社設定摘要2
            table.Columns.Add( new DataColumn( "CMP2.COMPANYURLRF", typeof( String ) ) ); // 自社URL
            table.Columns.Add( new DataColumn( "CMP2.COMPANYPRSENTENCE2RF", typeof( String ) ) ); // 自社PR文2
            table.Columns.Add( new DataColumn( "CMP2.IMAGECOMMENTFORPRT1RF", typeof( String ) ) ); // 画像印字用コメント1
            table.Columns.Add( new DataColumn( "CMP2.IMAGECOMMENTFORPRT2RF", typeof( String ) ) ); // 画像印字用コメント2
            table.Columns.Add( new DataColumn( "EMP1.KANARF", typeof( String ) ) ); // カナ
            table.Columns.Add( new DataColumn( "EMP1.SHORTNAMERF", typeof( String ) ) ); // 短縮名称
            table.Columns.Add( new DataColumn( "EMP2.KANARF", typeof( String ) ) ); // カナ
            table.Columns.Add( new DataColumn( "EMP2.SHORTNAMERF", typeof( String ) ) ); // 短縮名称
            table.Columns.Add( new DataColumn( "EMP3.KANARF", typeof( String ) ) ); // カナ
            table.Columns.Add( new DataColumn( "EMP3.SHORTNAMERF", typeof( String ) ) ); // 短縮名称
            table.Columns.Add( new DataColumn( "IMAGEINFORF.IMAGEINFODATARF", typeof( Byte[] ) ) ); // 画像情報データ
            table.Columns.Add( new DataColumn( "HADD.STOCKMOVEFORMALNMRF", typeof( String ) ) ); // 在庫移動形式名称
            table.Columns.Add( new DataColumn( "HADD.SHIPMENTSCDLDFYRF", typeof( Int32 ) ) ); // 出荷予定日西暦年
            table.Columns.Add( new DataColumn( "HADD.SHIPMENTSCDLDFSRF", typeof( Int32 ) ) ); // 出荷予定日西暦年略
            table.Columns.Add( new DataColumn( "HADD.SHIPMENTSCDLDFWRF", typeof( Int32 ) ) ); // 出荷予定日和暦年
            table.Columns.Add( new DataColumn( "HADD.SHIPMENTSCDLDFMRF", typeof( Int32 ) ) ); // 出荷予定日月
            table.Columns.Add( new DataColumn( "HADD.SHIPMENTSCDLDFDRF", typeof( Int32 ) ) ); // 出荷予定日日
            table.Columns.Add( new DataColumn( "HADD.SHIPMENTSCDLDFGRF", typeof( String ) ) ); // 出荷予定日元号
            table.Columns.Add( new DataColumn( "HADD.SHIPMENTSCDLDFRRF", typeof( String ) ) ); // 出荷予定日略号
            table.Columns.Add( new DataColumn( "HADD.SHIPMENTSCDLDFLSRF", typeof( String ) ) ); // 出荷予定日リテラル(/)
            table.Columns.Add( new DataColumn( "HADD.SHIPMENTSCDLDFLPRF", typeof( String ) ) ); // 出荷予定日リテラル(.)
            table.Columns.Add( new DataColumn( "HADD.SHIPMENTSCDLDFLYRF", typeof( String ) ) ); // 出荷予定日リテラル(年)
            table.Columns.Add( new DataColumn( "HADD.SHIPMENTSCDLDFLMRF", typeof( String ) ) ); // 出荷予定日リテラル(月)
            table.Columns.Add( new DataColumn( "HADD.SHIPMENTSCDLDFLDRF", typeof( String ) ) ); // 出荷予定日リテラル(日)
            table.Columns.Add( new DataColumn( "HADD.INPUTDFYRF", typeof( Int32 ) ) ); // 入力日西暦年
            table.Columns.Add( new DataColumn( "HADD.INPUTDFSRF", typeof( Int32 ) ) ); // 入力日西暦年略
            table.Columns.Add( new DataColumn( "HADD.INPUTDFWRF", typeof( Int32 ) ) ); // 入力日和暦年
            table.Columns.Add( new DataColumn( "HADD.INPUTDFMRF", typeof( Int32 ) ) ); // 入力日月
            table.Columns.Add( new DataColumn( "HADD.INPUTDFDRF", typeof( Int32 ) ) ); // 入力日日
            table.Columns.Add( new DataColumn( "HADD.INPUTDFGRF", typeof( String ) ) ); // 入力日元号
            table.Columns.Add( new DataColumn( "HADD.INPUTDFRRF", typeof( String ) ) ); // 入力日略号
            table.Columns.Add( new DataColumn( "HADD.INPUTDFLSRF", typeof( String ) ) ); // 入力日リテラル(/)
            table.Columns.Add( new DataColumn( "HADD.INPUTDFLPRF", typeof( String ) ) ); // 入力日リテラル(.)
            table.Columns.Add( new DataColumn( "HADD.INPUTDFLYRF", typeof( String ) ) ); // 入力日リテラル(年)
            table.Columns.Add( new DataColumn( "HADD.INPUTDFLMRF", typeof( String ) ) ); // 入力日リテラル(月)
            table.Columns.Add( new DataColumn( "HADD.INPUTDFLDRF", typeof( String ) ) ); // 入力日リテラル(日)
            table.Columns.Add( new DataColumn( "HADD.NOTE1RF", typeof( String ) ) ); // 自社備考１
            table.Columns.Add( new DataColumn( "HADD.NOTE2RF", typeof( String ) ) ); // 自社備考２
            table.Columns.Add( new DataColumn( "HADD.NOTE3RF", typeof( String ) ) ); // 自社備考３
            table.Columns.Add( new DataColumn( "HADD.REISSUEMARKRF", typeof( String ) ) ); // 再発行マーク
            table.Columns.Add( new DataColumn( "HADD.PRINTERMNGNORF", typeof( Int32 ) ) ); // プリンタ管理No
            table.Columns.Add( new DataColumn( "HADD.SLIPPRTSETPAPERIDRF", typeof( String ) ) ); // 伝票印刷設定用帳票ID
            table.Columns.Add( new DataColumn( "HADD.PRINTTIMEHOURRF", typeof( Int32 ) ) ); // 印刷時刻HH
            table.Columns.Add( new DataColumn( "HADD.PRINTTIMEMINUTERF", typeof( Int32 ) ) ); // 印刷時刻MM
            table.Columns.Add( new DataColumn( "HADD.PRINTTIMESECONDRF", typeof( Int32 ) ) ); // 印刷時刻SS
            table.Columns.Add( new DataColumn( "HADD.TTLSTOCKMOVEPRICERF", typeof( Int64 ) ) ); // 伝票合計金額
            table.Columns.Add( new DataColumn( "HADD.TTLSTOCKMOVELISTPRICERF", typeof( Int64 ) ) ); // 伝票合計金額(標準価格)
            table.Columns.Add( new DataColumn( "HADD.PRINTENTERPRISENAME1FHRF", typeof( String ) ) ); // 自社名１（前半）
            table.Columns.Add( new DataColumn( "HADD.PRINTENTERPRISENAME1LHRF", typeof( String ) ) ); // 自社名１（後半）
            table.Columns.Add( new DataColumn( "HADD.PRINTENTERPRISENAME2FHRF", typeof( String ) ) ); // 自社名２（前半）
            table.Columns.Add( new DataColumn( "HADD.PRINTENTERPRISENAME2LHRF", typeof( String ) ) ); // 自社名２（後半）
            table.Columns.Add( new DataColumn( "MOVH.UPDATESECCDRF", typeof( String ) ) ); // 入力拠点コード
            table.Columns.Add( new DataColumn( "SEC0.SECTIONGUIDESNMRF", typeof( String ) ) ); // 入力拠点ガイド略称
            table.Columns.Add( new DataColumn( "SEC0.SECTIONGUIDENMRF", typeof( String ) ) ); // 入力拠点ガイド名称

            // --- ADD 李占川 2011/08/15---------->>>>>
            table.Columns.Add(new DataColumn(ct_SlipTitle11, typeof(string))); //タイトル１・１
            table.Columns.Add(new DataColumn(ct_SlipTitle12, typeof(string))); //タイトル１・２
            table.Columns.Add(new DataColumn(ct_SlipTitle13, typeof(string))); //タイトル１・３
            table.Columns.Add(new DataColumn(ct_SlipTitle14, typeof(string))); //タイトル１・４
            table.Columns.Add(new DataColumn(ct_SlipTitle15, typeof(string))); //タイトル１・５

            table.Columns.Add(new DataColumn(ct_SlipTitle21, typeof(string))); //タイトル２・１
            table.Columns.Add(new DataColumn(ct_SlipTitle22, typeof(string))); //タイトル２・２
            table.Columns.Add(new DataColumn(ct_SlipTitle23, typeof(string))); //タイトル２・３
            table.Columns.Add(new DataColumn(ct_SlipTitle24, typeof(string))); //タイトル２・４
            table.Columns.Add(new DataColumn(ct_SlipTitle25, typeof(string))); //タイトル２・５

            table.Columns.Add(new DataColumn(ct_SlipTitle31, typeof(string))); //タイトル３・１
            table.Columns.Add(new DataColumn(ct_SlipTitle32, typeof(string))); //タイトル３・２
            table.Columns.Add(new DataColumn(ct_SlipTitle33, typeof(string))); //タイトル３・３
            table.Columns.Add(new DataColumn(ct_SlipTitle34, typeof(string))); //タイトル３・４
            table.Columns.Add(new DataColumn(ct_SlipTitle35, typeof(string))); //タイトル３・５

            table.Columns.Add(new DataColumn(ct_SlipTitle41, typeof(string))); //タイトル４・１
            table.Columns.Add(new DataColumn(ct_SlipTitle42, typeof(string))); //タイトル４・２
            table.Columns.Add(new DataColumn(ct_SlipTitle43, typeof(string))); //タイトル４・３
            table.Columns.Add(new DataColumn(ct_SlipTitle44, typeof(string))); //タイトル４・４
            table.Columns.Add(new DataColumn(ct_SlipTitle45, typeof(string))); //タイトル４・５
            // --- ADD 李占川 2011/08/15----------<<<<<
            # endregion

            # region [スキーマ定義（明細項目）]
            table.Columns.Add( new DataColumn( "MOVD.STOCKMOVEFORMALRF", typeof( Int32 ) ) ); // 在庫移動形式
            table.Columns.Add( new DataColumn( "MOVD.STOCKMOVESLIPNORF", typeof( Int32 ) ) ); // 在庫移動伝票番号
            table.Columns.Add( new DataColumn( "MOVD.STOCKMOVEROWNORF", typeof( Int32 ) ) ); // 在庫移動行番号
            table.Columns.Add( new DataColumn( "MOVD.BFSECTIONCODERF", typeof( String ) ) ); // 移動元拠点コード
            table.Columns.Add( new DataColumn( "MOVD.BFENTERWAREHCODERF", typeof( String ) ) ); // 移動元倉庫コード
            table.Columns.Add( new DataColumn( "MOVD.AFSECTIONCODERF", typeof( String ) ) ); // 移動先拠点コード
            table.Columns.Add( new DataColumn( "MOVD.AFENTERWAREHCODERF", typeof( String ) ) ); // 移動先倉庫コード
            table.Columns.Add( new DataColumn( "MOVD.SUPPLIERCDRF", typeof( Int32 ) ) ); // 仕入先コード
            table.Columns.Add( new DataColumn( "MOVD.SUPPLIERSNMRF", typeof( String ) ) ); // 仕入先略称
            table.Columns.Add( new DataColumn( "MOVD.GOODSMAKERCDRF", typeof( Int32 ) ) ); // 商品メーカーコード
            table.Columns.Add( new DataColumn( "MOVD.MAKERNAMERF", typeof( String ) ) ); // メーカー名称
            table.Columns.Add( new DataColumn( "MOVD.GOODSNORF", typeof( String ) ) ); // 商品番号
            table.Columns.Add( new DataColumn( "MOVD.GOODSNAMERF", typeof( String ) ) ); // 商品名称
            table.Columns.Add( new DataColumn( "MOVD.GOODSNAMEKANARF", typeof( String ) ) ); // 商品名称カナ
            table.Columns.Add( new DataColumn( "MOVD.STOCKDIVRF", typeof( Int32 ) ) ); // 在庫区分
            table.Columns.Add( new DataColumn( "MOVD.STOCKUNITPRICEFLRF", typeof( Double ) ) ); // 仕入単価（税抜,浮動）
            table.Columns.Add( new DataColumn( "MOVD.TAXATIONDIVCDRF", typeof( Int32 ) ) ); // 課税区分
            table.Columns.Add( new DataColumn( "MOVD.MOVECOUNTRF", typeof( Double ) ) ); // 移動数
            table.Columns.Add( new DataColumn( "MOVD.BFSHELFNORF", typeof( String ) ) ); // 移動元棚番
            table.Columns.Add( new DataColumn( "MOVD.AFSHELFNORF", typeof( String ) ) ); // 移動先棚番
            table.Columns.Add( new DataColumn( "MOVD.BLGOODSCODERF", typeof( Int32 ) ) ); // BL商品コード
            table.Columns.Add( new DataColumn( "MOVD.BLGOODSFULLNAMERF", typeof( String ) ) ); // BL商品コード名称（全角）
            table.Columns.Add( new DataColumn( "MOVD.LISTPRICEFLRF", typeof( Double ) ) ); // 定価（浮動）
            table.Columns.Add( new DataColumn( "MOVD.MOVESTATUSRF", typeof( Int32 ) ) ); // 移動状態
            table.Columns.Add( new DataColumn( "BLGOODSCDURF.BLGOODSHALFNAMERF", typeof( String ) ) ); // BL商品コード名称（半角）
            table.Columns.Add( new DataColumn( "MAKERURF.MAKERSHORTNAMERF", typeof( String ) ) ); // メーカー略称
            table.Columns.Add( new DataColumn( "MAKERURF.MAKERKANANAMERF", typeof( String ) ) ); // メーカーカナ名称
            table.Columns.Add( new DataColumn( "STC1.DUPLICATIONSHELFNO1RF", typeof( String ) ) ); // 重複棚番１
            table.Columns.Add( new DataColumn( "STC1.DUPLICATIONSHELFNO2RF", typeof( String ) ) ); // 重複棚番２
            table.Columns.Add( new DataColumn( "STC1.PARTSMANAGEMENTDIVIDE1RF", typeof( String ) ) ); // 部品管理区分１
            table.Columns.Add( new DataColumn( "STC1.PARTSMANAGEMENTDIVIDE2RF", typeof( String ) ) ); // 部品管理区分２
            table.Columns.Add( new DataColumn( "STC1.STOCKNOTE1RF", typeof( String ) ) ); // 在庫備考１
            table.Columns.Add( new DataColumn( "STC1.STOCKNOTE2RF", typeof( String ) ) ); // 在庫備考２
            table.Columns.Add( new DataColumn( "STC1.SHIPMENTPOSCNTRF", typeof( Double ) ) ); // 出荷可能数
            table.Columns.Add( new DataColumn( "STC2.DUPLICATIONSHELFNO1RF", typeof( String ) ) ); // 重複棚番１
            table.Columns.Add( new DataColumn( "STC2.DUPLICATIONSHELFNO2RF", typeof( String ) ) ); // 重複棚番２
            table.Columns.Add( new DataColumn( "STC2.PARTSMANAGEMENTDIVIDE1RF", typeof( String ) ) ); // 部品管理区分１
            table.Columns.Add( new DataColumn( "STC2.PARTSMANAGEMENTDIVIDE2RF", typeof( String ) ) ); // 部品管理区分２
            table.Columns.Add( new DataColumn( "STC2.STOCKNOTE1RF", typeof( String ) ) ); // 在庫備考１
            table.Columns.Add( new DataColumn( "STC2.STOCKNOTE2RF", typeof( String ) ) ); // 在庫備考２
            table.Columns.Add( new DataColumn( "STC2.SHIPMENTPOSCNTRF", typeof( Double ) ) ); // 出荷可能数
            table.Columns.Add( new DataColumn( "SUP.SUPPLIERNM1RF", typeof( String ) ) ); // 仕入先名1
            table.Columns.Add( new DataColumn( "SUP.SUPPLIERNM2RF", typeof( String ) ) ); // 仕入先名2
            table.Columns.Add( new DataColumn( "SUP.SUPPHONORIFICTITLERF", typeof( String ) ) ); // 仕入先敬称
            table.Columns.Add( new DataColumn( "SUP.SUPPLIERKANARF", typeof( String ) ) ); // 仕入先カナ
            table.Columns.Add( new DataColumn( "SUP.PURECODERF", typeof( Int32 ) ) ); // 純正区分
            table.Columns.Add( new DataColumn( "SUP.SUPPLIERNOTE1RF", typeof( String ) ) ); // 仕入先備考1
            table.Columns.Add( new DataColumn( "SUP.SUPPLIERNOTE2RF", typeof( String ) ) ); // 仕入先備考2
            table.Columns.Add( new DataColumn( "SUP.SUPPLIERNOTE3RF", typeof( String ) ) ); // 仕入先備考3
            table.Columns.Add( new DataColumn( "SUP.SUPPLIERNOTE4RF", typeof( String ) ) ); // 仕入先備考4
            table.Columns.Add( new DataColumn( "GDS.GOODSNAMEKANARF", typeof( String ) ) ); // 商品名称カナ
            table.Columns.Add( new DataColumn( "GDS.JANRF", typeof( String ) ) ); // JANコード
            table.Columns.Add( new DataColumn( "GDS.GOODSRATERANKRF", typeof( String ) ) ); // 商品掛率ランク
            table.Columns.Add( new DataColumn( "GDS.GOODSNONONEHYPHENRF", typeof( String ) ) ); // ハイフン無商品番号
            table.Columns.Add( new DataColumn( "GDS.GOODSNOTE1RF", typeof( String ) ) ); // 商品備考１
            table.Columns.Add( new DataColumn( "GDS.GOODSNOTE2RF", typeof( String ) ) ); // 商品備考２
            table.Columns.Add( new DataColumn( "GDS.GOODSSPECIALNOTERF", typeof( String ) ) ); // 商品規格・特記事項
            table.Columns.Add( new DataColumn( "DADD.STOCKDIVNMRF", typeof( String ) ) ); // 在庫区分名称
            table.Columns.Add( new DataColumn( "DADD.TAXATIONDIVCDNMRF", typeof( String ) ) ); // 課税区分名称
            table.Columns.Add( new DataColumn( "DADD.PURECODENMRF", typeof( String ) ) ); // 純正区分名称
            table.Columns.Add( new DataColumn( "DADD.STOCKMOVEPRICERF", typeof( Int64 ) ) ); // 移動金額
            table.Columns.Add( new DataColumn( "DADD.STOCKMOVELISTPRICERF", typeof( Int64 ) ) ); // 移動金額(標準価格)
            table.Columns.Add( new DataColumn( "DADD.BFSTOCKCOUNTPREVRF", typeof( Double ) ) ); // 移動元移動前数
            table.Columns.Add( new DataColumn( "DADD.BFSTOCKCOUNTRF", typeof( Double ) ) ); // 移動元移動後数
            table.Columns.Add( new DataColumn( "DADD.AFSTOCKCOUNTPREVRF", typeof( Double ) ) ); // 移動先移動前数
            table.Columns.Add( new DataColumn( "DADD.AFSTOCKCOUNTRF", typeof( Double ) ) ); // 移動先移動後数
            table.Columns.Add( new DataColumn( "MOVD.STOCKMOVEPRICERF", typeof( Int64 ) ) ); // 移動金額
            # endregion

            # region [制御項目]
            table.Columns.Add( new DataColumn( ct_InPageCopyTitle1, typeof( string ) ) );  // 複写タイトル
            table.Columns.Add( new DataColumn( ct_InPageCopyTitle2, typeof( string ) ) );  // 複写タイトル
            table.Columns.Add( new DataColumn( ct_InPageCopyTitle3, typeof( string ) ) );  // 複写タイトル
            table.Columns.Add( new DataColumn( ct_InPageCopyTitle4, typeof( string ) ) );  // 複写タイトル
            table.Columns.Add( new DataColumn( ct_InPageCopyCount, typeof( int ) ) );  // 同一ページ内コピーカウント
            table.Columns.Add( new DataColumn( ct_PageCount, typeof( int ) ) );  // ページ数
            table.Columns.Add( new DataColumn( ct_BfTitle, typeof( string ) ) );  // 出庫タイトル
            table.Columns.Add( new DataColumn( ct_AfTitle, typeof( string ) ) );  // 入庫タイトル
            # endregion
            table.Columns.Add(new DataColumn("HPRT.BARCDSALESSLNUMRF", typeof(string)));  // バーコード（伝票番号） // --- ADD 3H 楊善娟 2017/08/30

            return table;
        }
        # endregion

        # region [データ移行（DataClass→DataTable）]
        /// <summary>
        /// データ移行処理
        /// </summary>
        /// <param name="table"></param>
        /// <param name="currentIndex"></param>
        /// <param name="slipWork"></param>
        /// <param name="detailWorks"></param>
        /// <param name="frePrtPSet"></param>
        /// <param name="slipPrtSet"></param>
        /// <param name="stockMngTtlSt"></param>
        /// <param name="slipPrintParameter"></param>
        /// <remarks>
        /// <br>Update Note  : 2017/08/30 3H 楊善娟</br>
        /// <br>管理番号     : 11370074-00 ハンディ対応（2次）</br>
        /// </remarks>
        // --- UPD  大矢睦美  2010/05/27 ---------->>>>>
        // --- UPD m.suzuki 2010/05/17 ---------->>>>>
        //public static void CopyToDataTable( ref DataTable table, FrePStockMoveSlipWork slipWork, List<FrePStockMoveDetailWork> detailWorks, FrePrtPSetWork frePrtPSet, SlipPrtSetWork slipPrtSet, EachSlipTypeSet eachSlipTypeSet, StockMngTtlStWork stockMngTtlSt, AllDefSetWork allDefSet, SlipPrintParameter slipPrintParameter, Dictionary<string, string> columnVisibleTypeDic )
        //public static void CopyToDataTable( ref List<DataTable> retTables, ref int currentIndex, FrePStockMoveSlipWork slipWork, List<FrePStockMoveDetailWork> detailWorks, FrePrtPSetWork frePrtPSet, SlipPrtSetWork slipPrtSet, EachSlipTypeSet eachSlipTypeSet, StockMngTtlStWork stockMngTtlSt, AllDefSetWork allDefSet, SlipPrintParameter slipPrintParameter, Dictionary<string, string> columnVisibleTypeDic )
        // --- UPD 李占川 2011/08/15---------->>>>>
        //public static void CopyToDataTable( ref List<DataTable> retTables, ref int currentIndex, FrePStockMoveSlipWork slipWork, List<FrePStockMoveDetailWork> detailWorks, FrePrtPSetWork frePrtPSet, SlipPrtSetWork slipPrtSet, EachSlipTypeSet eachSlipTypeSet, StockMngTtlStWork stockMngTtlSt, AllDefSetWork allDefSet, SlipPrintParameter slipPrintParameter, Dictionary<string, string> columnVisibleTypeDic, Dictionary<string, string> titleDic)
        public static void CopyToDataTable(ref List<DataTable> retTables, ref int currentIndex, FrePStockMoveSlipWork slipWork, List<FrePStockMoveDetailWork> detailWorks, FrePrtPSetWork frePrtPSet, SlipPrtSetWork slipPrtSet, EachSlipTypeSet eachSlipTypeSet, StockMngTtlStWork stockMngTtlSt, AllDefSetWork allDefSet, SlipPrintParameter slipPrintParameter, Dictionary<string, string> columnVisibleTypeDic, Dictionary<string, string> titleDic, Dictionary<string, ar.ActiveReport3> subReportDic)
        // --- UPD 李占川 2011/08/15----------<<<<<
        // --- UPD m.suzuki 2010/05/17 ----------<<<<<
        // --- UPD  大矢睦美  2010/05/27 ----------<<<<<
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
            //   ・伝票合計金額は明細を集計しますが、ヘッダに印字する
            //     可能性もある為、例外的にforで予め集計します。
            // 
            // ※原則は処理速度を重視します。
            //----------------------------------------------------

            // 伝票work各種名称
            # region [slipWork各種名称]
            slipWork.HADD_STOCKMOVEFORMALNMRF = GetHADD_STOCKMOVEFORMALNMRFRF( slipWork.MOVH_STOCKMOVEFORMALRF );
            # endregion

            // 合計金額の算出
            # region [合計金額]
            // 合計金額
            slipWork.HADD_TTLSTOCKMOVEPRICERF = 0;
            slipWork.HADD_TTLSTOCKMOVELISTPRICERF = 0;
            foreach ( FrePStockMoveDetailWork detail in detailWorks )
            {
                // 金額算出
                detail.DADD_STOCKMOVEPRICERF = GetSTOCKMOVEPRICERF( detail );// 移動金額
                detail.DADD_STOCKMOVELISTPRICERF = GetSTOCKMOVELISTPRICERF( detail );// 移動金額(標準価格)

                // 集計値に合算
                slipWork.HADD_TTLSTOCKMOVEPRICERF += detail.DADD_STOCKMOVEPRICERF; // 移動金額
                slipWork.HADD_TTLSTOCKMOVELISTPRICERF += detail.DADD_STOCKMOVELISTPRICERF; // 移動金額(標準価格)
            }
            # endregion

            # region [時刻]
            DateTime printTime = DateTime.Now;
            slipWork.HADD_PRINTTIMEHOURRF = printTime.Hour;
            slipWork.HADD_PRINTTIMEMINUTERF = printTime.Minute;
            slipWork.HADD_PRINTTIMESECONDRF = printTime.Second;
            # endregion

            // 伝票タイトル取得処理
            List<List<string>> inPageCopyTitle = GetInPageCopyTitles( slipPrtSet );

            // １ページの明細行数を取得
            int feedCount = frePrtPSet.FormFeedLineCount;
            if ( feedCount <= 0 ) feedCount = 1;
            if ( slipPrtSet.DetailRowCount <= 0 ) slipPrtSet.DetailRowCount = feedCount;

            // 総行数取得
            int allDetailCount = GetAllDetailCount( detailWorks.Count, Math.Min( feedCount, slipPrtSet.DetailRowCount ) );

            // 全ページ数
            int allPageCount = allDetailCount / Math.Min( feedCount, slipPrtSet.DetailRowCount );
            int pageStartIndex = 0;
            int pageEndIndex = pageStartIndex + feedCount - 1;

            int printEndIndex = pageStartIndex + slipPrtSet.DetailRowCount - 1;

            for ( int pageIndex = 0; pageIndex < allPageCount; pageIndex++ )
            {
                // --- ADD m.suzuki 2010/05/17 ---------->>>>>
                DataTable table = PMZAI08001PB.CreateFrePStockMoveSlipTable( currentIndex++ );
                retTables.Add( table );
                // --- ADD m.suzuki 2010/05/17 ----------<<<<<

                for ( int inPageCopyCount = 0; inPageCopyCount < inPageCopyTitle[0].Count; inPageCopyCount++ )
                {
                    // 明細行移行
                    for ( int index = pageStartIndex; index <= pageEndIndex; index++ )
                    {
                        DataRow row = table.NewRow();

                        # region [明細追加]
                        // ページ数
                        row[ct_PageCount] = pageIndex + 1;

                        // 最初のレコード／最後のレコードのみ伝票項目をセットする。
                        // (単純に明細の数だけ倍増させない為)
                        // なおここでの"最後のレコード"とは空白行の可能性も含む。
                        if ( index == pageStartIndex || index == pageEndIndex )
                        {
                            # region [伝票項目Copy]
                            row["MOVH.STOCKMOVEFORMALRF"] = slipWork.MOVH_STOCKMOVEFORMALRF; // 在庫移動形式
                            row["MOVH.STOCKMOVESLIPNORF"] = slipWork.MOVH_STOCKMOVESLIPNORF; // 在庫移動伝票番号
                            row["MOVH.BFSECTIONCODERF"] = slipWork.MOVH_BFSECTIONCODERF; // 移動元拠点コード
                            row["MOVH.BFSECTIONGUIDESNMRF"] = slipWork.MOVH_BFSECTIONGUIDESNMRF; // 移動元拠点ガイド略称
                            row["MOVH.BFENTERWAREHCODERF"] = slipWork.MOVH_BFENTERWAREHCODERF; // 移動元倉庫コード
                            row["MOVH.BFENTERWAREHNAMERF"] = slipWork.MOVH_BFENTERWAREHNAMERF; // 移動元倉庫名称
                            row["MOVH.AFSECTIONCODERF"] = slipWork.MOVH_AFSECTIONCODERF; // 移動先拠点コード
                            row["MOVH.AFSECTIONGUIDESNMRF"] = slipWork.MOVH_AFSECTIONGUIDESNMRF; // 移動先拠点ガイド略称
                            row["MOVH.AFENTERWAREHCODERF"] = slipWork.MOVH_AFENTERWAREHCODERF; // 移動先倉庫コード
                            row["MOVH.AFENTERWAREHNAMERF"] = slipWork.MOVH_AFENTERWAREHNAMERF; // 移動先倉庫名称
                            row["MOVH.SHIPMENTSCDLDAYRF"] = slipWork.MOVH_SHIPMENTSCDLDAYRF; // 出荷予定日
                            row["MOVH.INPUTDAYRF"] = slipWork.MOVH_INPUTDAYRF; // 入力日
                            row["MOVH.STOCKMVEMPCODERF"] = slipWork.MOVH_STOCKMVEMPCODERF; // 在庫移動入力従業員コード
                            row["MOVH.STOCKMVEMPNAMERF"] = slipWork.MOVH_STOCKMVEMPNAMERF; // 在庫移動入力従業員名称
                            row["MOVH.SHIPAGENTCDRF"] = slipWork.MOVH_SHIPAGENTCDRF; // 出荷担当従業員コード
                            row["MOVH.SHIPAGENTNMRF"] = slipWork.MOVH_SHIPAGENTNMRF; // 出荷担当従業員名称
                            row["MOVH.RECEIVEAGENTCDRF"] = slipWork.MOVH_RECEIVEAGENTCDRF; // 引取担当従業員コード
                            row["MOVH.RECEIVEAGENTNMRF"] = slipWork.MOVH_RECEIVEAGENTNMRF; // 引取担当従業員名称
                            row["MOVH.OUTLINERF"] = slipWork.MOVH_OUTLINERF; // 伝票摘要
                            row["MOVH.WAREHOUSENOTE1RF"] = slipWork.MOVH_WAREHOUSENOTE1RF; // 倉庫備考1
                            row["MOVH.SLIPPRINTFINISHCDRF"] = slipWork.MOVH_SLIPPRINTFINISHCDRF; // 伝票発行済区分
                            row["SEC1.SECTIONGUIDENMRF"] = slipWork.SEC1_SECTIONGUIDENMRF; // 拠点ガイド名称
                            row["SEC1.COMPANYNAMECD1RF"] = slipWork.SEC1_COMPANYNAMECD1RF; // 自社名称コード1
                            row["SEC2.SECTIONGUIDENMRF"] = slipWork.SEC2_SECTIONGUIDENMRF; // 拠点ガイド名称
                            row["SEC2.COMPANYNAMECD1RF"] = slipWork.SEC2_COMPANYNAMECD1RF; // 自社名称コード1
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
                            row["CMP1.COMPANYPRRF"] = slipWork.CMP1_COMPANYPRRF; // 自社PR文
                            row["CMP1.COMPANYNAME1RF"] = slipWork.CMP1_COMPANYNAME1RF; // 自社名称1
                            row["CMP1.COMPANYNAME2RF"] = slipWork.CMP1_COMPANYNAME2RF; // 自社名称2
                            row["CMP1.POSTNORF"] = slipWork.CMP1_POSTNORF; // 郵便番号
                            row["CMP1.ADDRESS1RF"] = slipWork.CMP1_ADDRESS1RF; // 住所1（都道府県市区郡・町村・字）
                            row["CMP1.ADDRESS3RF"] = slipWork.CMP1_ADDRESS3RF; // 住所3（番地）
                            row["CMP1.ADDRESS4RF"] = slipWork.CMP1_ADDRESS4RF; // 住所4（アパート名称）
                            row["CMP1.COMPANYTELNO1RF"] = slipWork.CMP1_COMPANYTELNO1RF; // 自社電話番号1
                            row["CMP1.COMPANYTELNO2RF"] = slipWork.CMP1_COMPANYTELNO2RF; // 自社電話番号2
                            row["CMP1.COMPANYTELNO3RF"] = slipWork.CMP1_COMPANYTELNO3RF; // 自社電話番号3
                            row["CMP1.COMPANYTELTITLE1RF"] = slipWork.CMP1_COMPANYTELTITLE1RF; // 自社電話番号タイトル1
                            row["CMP1.COMPANYTELTITLE2RF"] = slipWork.CMP1_COMPANYTELTITLE2RF; // 自社電話番号タイトル2
                            row["CMP1.COMPANYTELTITLE3RF"] = slipWork.CMP1_COMPANYTELTITLE3RF; // 自社電話番号タイトル3
                            row["CMP1.TRANSFERGUIDANCERF"] = slipWork.CMP1_TRANSFERGUIDANCERF; // 銀行振込案内文
                            row["CMP1.ACCOUNTNOINFO1RF"] = slipWork.CMP1_ACCOUNTNOINFO1RF; // 銀行口座1
                            row["CMP1.ACCOUNTNOINFO2RF"] = slipWork.CMP1_ACCOUNTNOINFO2RF; // 銀行口座2
                            row["CMP1.ACCOUNTNOINFO3RF"] = slipWork.CMP1_ACCOUNTNOINFO3RF; // 銀行口座3
                            row["CMP1.COMPANYSETNOTE1RF"] = slipWork.CMP1_COMPANYSETNOTE1RF; // 自社設定摘要1
                            row["CMP1.COMPANYSETNOTE2RF"] = slipWork.CMP1_COMPANYSETNOTE2RF; // 自社設定摘要2
                            row["CMP1.IMAGEINFODIVRF"] = slipWork.CMP1_IMAGEINFODIVRF; // 画像情報区分
                            row["CMP1.IMAGEINFOCODERF"] = slipWork.CMP1_IMAGEINFOCODERF; // 画像情報コード
                            row["CMP1.COMPANYURLRF"] = slipWork.CMP1_COMPANYURLRF; // 自社URL
                            row["CMP1.COMPANYPRSENTENCE2RF"] = slipWork.CMP1_COMPANYPRSENTENCE2RF; // 自社PR文2
                            row["CMP1.IMAGECOMMENTFORPRT1RF"] = slipWork.CMP1_IMAGECOMMENTFORPRT1RF; // 画像印字用コメント1
                            row["CMP1.IMAGECOMMENTFORPRT2RF"] = slipWork.CMP1_IMAGECOMMENTFORPRT2RF; // 画像印字用コメント2
                            row["CMP2.COMPANYPRRF"] = slipWork.CMP2_COMPANYPRRF; // 自社PR文
                            row["CMP2.COMPANYNAME1RF"] = slipWork.CMP2_COMPANYNAME1RF; // 自社名称1
                            row["CMP2.COMPANYNAME2RF"] = slipWork.CMP2_COMPANYNAME2RF; // 自社名称2
                            row["CMP2.POSTNORF"] = slipWork.CMP2_POSTNORF; // 郵便番号
                            row["CMP2.ADDRESS1RF"] = slipWork.CMP2_ADDRESS1RF; // 住所1（都道府県市区郡・町村・字）
                            row["CMP2.ADDRESS3RF"] = slipWork.CMP2_ADDRESS3RF; // 住所3（番地）
                            row["CMP2.ADDRESS4RF"] = slipWork.CMP2_ADDRESS4RF; // 住所4（アパート名称）
                            row["CMP2.COMPANYTELNO1RF"] = slipWork.CMP2_COMPANYTELNO1RF; // 自社電話番号1
                            row["CMP2.COMPANYTELNO2RF"] = slipWork.CMP2_COMPANYTELNO2RF; // 自社電話番号2
                            row["CMP2.COMPANYTELNO3RF"] = slipWork.CMP2_COMPANYTELNO3RF; // 自社電話番号3
                            row["CMP2.COMPANYTELTITLE1RF"] = slipWork.CMP2_COMPANYTELTITLE1RF; // 自社電話番号タイトル1
                            row["CMP2.COMPANYTELTITLE2RF"] = slipWork.CMP2_COMPANYTELTITLE2RF; // 自社電話番号タイトル2
                            row["CMP2.COMPANYTELTITLE3RF"] = slipWork.CMP2_COMPANYTELTITLE3RF; // 自社電話番号タイトル3
                            row["CMP2.TRANSFERGUIDANCERF"] = slipWork.CMP2_TRANSFERGUIDANCERF; // 銀行振込案内文
                            row["CMP2.ACCOUNTNOINFO1RF"] = slipWork.CMP2_ACCOUNTNOINFO1RF; // 銀行口座1
                            row["CMP2.ACCOUNTNOINFO2RF"] = slipWork.CMP2_ACCOUNTNOINFO2RF; // 銀行口座2
                            row["CMP2.ACCOUNTNOINFO3RF"] = slipWork.CMP2_ACCOUNTNOINFO3RF; // 銀行口座3
                            row["CMP2.COMPANYSETNOTE1RF"] = slipWork.CMP2_COMPANYSETNOTE1RF; // 自社設定摘要1
                            row["CMP2.COMPANYSETNOTE2RF"] = slipWork.CMP2_COMPANYSETNOTE2RF; // 自社設定摘要2
                            row["CMP2.COMPANYURLRF"] = slipWork.CMP2_COMPANYURLRF; // 自社URL
                            row["CMP2.COMPANYPRSENTENCE2RF"] = slipWork.CMP2_COMPANYPRSENTENCE2RF; // 自社PR文2
                            row["CMP2.IMAGECOMMENTFORPRT1RF"] = slipWork.CMP2_IMAGECOMMENTFORPRT1RF; // 画像印字用コメント1
                            row["CMP2.IMAGECOMMENTFORPRT2RF"] = slipWork.CMP2_IMAGECOMMENTFORPRT2RF; // 画像印字用コメント2
                            row["EMP1.KANARF"] = slipWork.EMP1_KANARF; // カナ
                            row["EMP1.SHORTNAMERF"] = slipWork.EMP1_SHORTNAMERF; // 短縮名称
                            row["EMP2.KANARF"] = slipWork.EMP2_KANARF; // カナ
                            row["EMP2.SHORTNAMERF"] = slipWork.EMP2_SHORTNAMERF; // 短縮名称
                            row["EMP3.KANARF"] = slipWork.EMP3_KANARF; // カナ
                            row["EMP3.SHORTNAMERF"] = slipWork.EMP3_SHORTNAMERF; // 短縮名称
                            row["IMAGEINFORF.IMAGEINFODATARF"] = slipWork.IMAGEINFORF_IMAGEINFODATARF; // 画像情報データ
                            row["HADD.STOCKMOVEFORMALNMRF"] = slipWork.HADD_STOCKMOVEFORMALNMRF; // 在庫移動形式名称
                            //row["HADD.SHIPMENTSCDLDFYRF"] = slipWork.HADD_SHIPMENTSCDLDFYRF; // 出荷予定日西暦年
                            //row["HADD.SHIPMENTSCDLDFSRF"] = slipWork.HADD_SHIPMENTSCDLDFSRF; // 出荷予定日西暦年略
                            //row["HADD.SHIPMENTSCDLDFWRF"] = slipWork.HADD_SHIPMENTSCDLDFWRF; // 出荷予定日和暦年
                            //row["HADD.SHIPMENTSCDLDFMRF"] = slipWork.HADD_SHIPMENTSCDLDFMRF; // 出荷予定日月
                            //row["HADD.SHIPMENTSCDLDFDRF"] = slipWork.HADD_SHIPMENTSCDLDFDRF; // 出荷予定日日
                            //row["HADD.SHIPMENTSCDLDFGRF"] = slipWork.HADD_SHIPMENTSCDLDFGRF; // 出荷予定日元号
                            //row["HADD.SHIPMENTSCDLDFRRF"] = slipWork.HADD_SHIPMENTSCDLDFRRF; // 出荷予定日略号
                            //row["HADD.SHIPMENTSCDLDFLSRF"] = slipWork.HADD_SHIPMENTSCDLDFLSRF; // 出荷予定日リテラル(/)
                            //row["HADD.SHIPMENTSCDLDFLPRF"] = slipWork.HADD_SHIPMENTSCDLDFLPRF; // 出荷予定日リテラル(.)
                            //row["HADD.SHIPMENTSCDLDFLYRF"] = slipWork.HADD_SHIPMENTSCDLDFLYRF; // 出荷予定日リテラル(年)
                            //row["HADD.SHIPMENTSCDLDFLMRF"] = slipWork.HADD_SHIPMENTSCDLDFLMRF; // 出荷予定日リテラル(月)
                            //row["HADD.SHIPMENTSCDLDFLDRF"] = slipWork.HADD_SHIPMENTSCDLDFLDRF; // 出荷予定日リテラル(日)
                            //row["HADD.INPUTDFYRF"] = slipWork.HADD_INPUTDFYRF; // 入力日西暦年
                            //row["HADD.INPUTDFSRF"] = slipWork.HADD_INPUTDFSRF; // 入力日西暦年略
                            //row["HADD.INPUTDFWRF"] = slipWork.HADD_INPUTDFWRF; // 入力日和暦年
                            //row["HADD.INPUTDFMRF"] = slipWork.HADD_INPUTDFMRF; // 入力日月
                            //row["HADD.INPUTDFDRF"] = slipWork.HADD_INPUTDFDRF; // 入力日日
                            //row["HADD.INPUTDFGRF"] = slipWork.HADD_INPUTDFGRF; // 入力日元号
                            //row["HADD.INPUTDFRRF"] = slipWork.HADD_INPUTDFRRF; // 入力日略号
                            //row["HADD.INPUTDFLSRF"] = slipWork.HADD_INPUTDFLSRF; // 入力日リテラル(/)
                            //row["HADD.INPUTDFLPRF"] = slipWork.HADD_INPUTDFLPRF; // 入力日リテラル(.)
                            //row["HADD.INPUTDFLYRF"] = slipWork.HADD_INPUTDFLYRF; // 入力日リテラル(年)
                            //row["HADD.INPUTDFLMRF"] = slipWork.HADD_INPUTDFLMRF; // 入力日リテラル(月)
                            //row["HADD.INPUTDFLDRF"] = slipWork.HADD_INPUTDFLDRF; // 入力日リテラル(日)
                            //row["HADD.NOTE1RF"] = slipWork.HADD_NOTE1RF; // 自社備考１
                            //row["HADD.NOTE2RF"] = slipWork.HADD_NOTE2RF; // 自社備考２
                            //row["HADD.NOTE3RF"] = slipWork.HADD_NOTE2RF; // 自社備考３
                            //row["HADD.REISSUEMARKRF"] = slipWork.HADD_REISSUEMARKRF; // 再発行マーク
                            //row["HADD.PRINTERMNGNORF"] = slipWork.HADD_PRINTERMNGNORF; // プリンタ管理No
                            //row["HADD.SLIPPRTSETPAPERIDRF"] = slipWork.HADD_SLIPPRTSETPAPERIDRF; // 伝票印刷設定用帳票ID
                            row["MOVH.UPDATESECCDRF"] = slipWork.MOVH_UPDATESECCDRF; // 入力拠点コード
                            row["SEC0.SECTIONGUIDESNMRF"] = slipWork.SEC0_SECTIONGUIDESNMRF; // 入力拠点ガイド略称
                            row["SEC0.SECTIONGUIDENMRF"] = slipWork.SEC0_SECTIONGUIDENMRF; // 入力拠点ガイド名称

                            // --- ADD 3H 楊善娟 2017/08/30---------->>>>>
                            #region「ハンディ対応（2次）」
                            // バーコード（伝票番号）
                            row["HPRT.BARCDSALESSLNUMRF"] = "*" + string.Format("{0:D9}", slipWork.MOVH_STOCKMOVESLIPNORF) + "*";
                            #endregion
                            // --- ADD 3H 楊善娟 2017/08/30----------<<<<<

                            # endregion

                            # region [伝票項目(自動以外)]

                            // 未設定時 非印字コード
                            # region [未設定]
                            // 文字列コード
                            if ( IsZero( slipWork.MOVH_BFSECTIONCODERF ) ) row["MOVH.BFSECTIONCODERF"] = DBNull.Value; // 移動元拠点コード
                            if ( IsZero( slipWork.MOVH_BFENTERWAREHCODERF ) ) row["MOVH.BFENTERWAREHCODERF"] = DBNull.Value; // 移動元倉庫コード
                            if ( IsZero( slipWork.MOVH_AFSECTIONCODERF ) ) row["MOVH.AFSECTIONCODERF"] = DBNull.Value; // 移動先拠点コード
                            if ( IsZero( slipWork.MOVH_AFENTERWAREHCODERF ) ) row["MOVH.AFENTERWAREHCODERF"] = DBNull.Value; // 移動先倉庫コード
                            if ( IsZero( slipWork.MOVH_STOCKMVEMPCODERF ) ) row["MOVH.STOCKMVEMPCODERF"] = DBNull.Value; // 在庫移動入力従業員コード
                            if ( IsZero( slipWork.MOVH_SHIPAGENTCDRF ) ) row["MOVH.SHIPAGENTCDRF"] = DBNull.Value; // 出荷担当従業員コード
                            if ( IsZero( slipWork.MOVH_RECEIVEAGENTCDRF ) ) row["MOVH.RECEIVEAGENTCDRF"] = DBNull.Value; // 引取担当従業員コード
                            # endregion

                            // 自社備考
                            # region [自社備考]
                            row["HADD.NOTE1RF"] = slipPrtSet.Note1; // 自社備考１
                            row["HADD.NOTE2RF"] = slipPrtSet.Note2; // 自社備考２
                            row["HADD.NOTE3RF"] = slipPrtSet.Note3; // 自社備考３
                            # endregion

                            // 再発行マーク
                            # region [再発行]
                            if ( slipPrintParameter.ReissueDiv )
                            {
                                row["HADD.REISSUEMARKRF"] = slipPrtSet.ReissueMark; // 再発行マーク
                            }
                            else
                            {
                                row["HADD.REISSUEMARKRF"] = string.Empty;
                            }
                            # endregion

                            // 日付関連展開
                            # region [日付展開]
                            // 通常
                            ExtractDate( ref row, allDefSet.EraNameDispCd2, slipWork.MOVH_SHIPMENTSCDLDAYRF, "HADD.SHIPMENTSCDLD", false ); // 出荷予定日
                            ExtractDate( ref row, allDefSet.EraNameDispCd2, slipWork.MOVH_INPUTDAYRF, "HADD.INPUTD", false ); // 入力日
                            # endregion

                            // 時刻
                            # region [時刻]
                            if ( slipPrtSet.TimePrintDivCd != 0 )
                            {
                                // 印字
                                row["HADD.PRINTTIMEHOURRF"] = slipWork.HADD_PRINTTIMEHOURRF; // 印刷時刻HH
                                row["HADD.PRINTTIMEMINUTERF"] = slipWork.HADD_PRINTTIMEMINUTERF; // 印刷時刻MM
                                row["HADD.PRINTTIMESECONDRF"] = slipWork.HADD_PRINTTIMESECONDRF; // 印刷時刻SS
                            }
                            else
                            {
                                // 非印字
                                row["HADD.PRINTTIMEHOURRF"] = DBNull.Value; // 印刷時刻HH
                                row["HADD.PRINTTIMEMINUTERF"] = DBNull.Value; // 印刷時刻MM
                                row["HADD.PRINTTIMESECONDRF"] = DBNull.Value; // 印刷時刻SS
                            }
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
                                        row["CMP1.COMPANYNAME1RF"] = slipWork.COMPANYINFRF_COMPANYNAME1RF; // 自社名称1
                                        row["CMP1.COMPANYNAME2RF"] = slipWork.COMPANYINFRF_COMPANYNAME2RF; // 自社名称2
                                        row["CMP1.POSTNORF"] = slipWork.COMPANYINFRF_POSTNORF; // 郵便番号
                                        row["CMP1.ADDRESS1RF"] = slipWork.COMPANYINFRF_ADDRESS1RF; // 住所1（都道府県市区郡・町村・字）
                                        row["CMP1.ADDRESS3RF"] = slipWork.COMPANYINFRF_ADDRESS3RF; // 住所3（番地）
                                        row["CMP1.ADDRESS4RF"] = slipWork.COMPANYINFRF_ADDRESS4RF; // 住所4（アパート名称）
                                        row["CMP1.COMPANYTELNO1RF"] = slipWork.COMPANYINFRF_COMPANYTELNO1RF; // 自社電話番号1
                                        row["CMP1.COMPANYTELNO2RF"] = slipWork.COMPANYINFRF_COMPANYTELNO2RF; // 自社電話番号2
                                        row["CMP1.COMPANYTELNO3RF"] = slipWork.COMPANYINFRF_COMPANYTELNO3RF; // 自社電話番号3
                                        row["CMP1.COMPANYTELTITLE1RF"] = slipWork.COMPANYINFRF_COMPANYTELTITLE1RF; // 自社電話番号タイトル1
                                        row["CMP1.COMPANYTELTITLE2RF"] = slipWork.COMPANYINFRF_COMPANYTELTITLE2RF; // 自社電話番号タイトル2
                                        row["CMP1.COMPANYTELTITLE3RF"] = slipWork.COMPANYINFRF_COMPANYTELTITLE3RF; // 自社電話番号タイトル3
                                        // bitmapなし
                                        row["CMP1.IMAGECOMMENTFORPRT1RF"] = DBNull.Value; // 画像印字用コメント1
                                        row["CMP1.IMAGECOMMENTFORPRT2RF"] = DBNull.Value; // 画像印字用コメント2
                                        row["IMAGEINFORF.IMAGEINFODATARF"] = DBNull.Value; // 画像情報データ
                                    }
                                    break;
                                // 拠点名
                                case 1:
                                    {
                                        // bitmapなし
                                        row["CMP1.IMAGECOMMENTFORPRT1RF"] = DBNull.Value; // 画像印字用コメント1
                                        row["CMP1.IMAGECOMMENTFORPRT2RF"] = DBNull.Value; // 画像印字用コメント2
                                        row["IMAGEINFORF.IMAGEINFODATARF"] = DBNull.Value; // 画像情報データ
                                    }
                                    break;
                                // ビットマップ
                                case 2:
                                    {
                                        // 自社情報文字列なし
                                        row["CMP1.COMPANYNAME1RF"] = DBNull.Value; // 自社名称1
                                        row["CMP1.COMPANYNAME2RF"] = DBNull.Value; // 自社名称2
                                        row["CMP1.POSTNORF"] = DBNull.Value; // 郵便番号
                                        row["CMP1.ADDRESS1RF"] = DBNull.Value; // 住所1（都道府県市区郡・町村・字）
                                        row["CMP1.ADDRESS3RF"] = DBNull.Value; // 住所3（番地）
                                        row["CMP1.ADDRESS4RF"] = DBNull.Value; // 住所4（アパート名称）
                                        row["CMP1.COMPANYTELNO1RF"] = DBNull.Value; // 自社電話番号1
                                        row["CMP1.COMPANYTELNO2RF"] = DBNull.Value; // 自社電話番号2
                                        row["CMP1.COMPANYTELNO3RF"] = DBNull.Value; // 自社電話番号3
                                        row["CMP1.COMPANYTELTITLE1RF"] = DBNull.Value; // 自社電話番号タイトル1
                                        row["CMP1.COMPANYTELTITLE2RF"] = DBNull.Value; // 自社電話番号タイトル2
                                        row["CMP1.COMPANYTELTITLE3RF"] = DBNull.Value; // 自社電話番号タイトル3
                                    }
                                    break;
                                // 印字しない
                                case 3:
                                default:
                                    {
                                        // 自社情報文字列なし
                                        row["CMP1.COMPANYNAME1RF"] = DBNull.Value; // 自社名称1
                                        row["CMP1.COMPANYNAME2RF"] = DBNull.Value; // 自社名称2
                                        row["CMP1.POSTNORF"] = DBNull.Value; // 郵便番号
                                        row["CMP1.ADDRESS1RF"] = DBNull.Value; // 住所1（都道府県市区郡・町村・字）
                                        row["CMP1.ADDRESS3RF"] = DBNull.Value; // 住所3（番地）
                                        row["CMP1.ADDRESS4RF"] = DBNull.Value; // 住所4（アパート名称）
                                        row["CMP1.COMPANYTELNO1RF"] = DBNull.Value; // 自社電話番号1
                                        row["CMP1.COMPANYTELNO2RF"] = DBNull.Value; // 自社電話番号2
                                        row["CMP1.COMPANYTELNO3RF"] = DBNull.Value; // 自社電話番号3
                                        row["CMP1.COMPANYTELTITLE1RF"] = DBNull.Value; // 自社電話番号タイトル1
                                        row["CMP1.COMPANYTELTITLE2RF"] = DBNull.Value; // 自社電話番号タイトル2
                                        row["CMP1.COMPANYTELTITLE3RF"] = DBNull.Value; // 自社電話番号タイトル3
                                        // bitmapなし
                                        row["CMP1.IMAGECOMMENTFORPRT1RF"] = DBNull.Value; // 画像印字用コメント1
                                        row["CMP1.IMAGECOMMENTFORPRT2RF"] = DBNull.Value; // 画像印字用コメント2
                                        row["IMAGEINFORF.IMAGEINFODATARF"] = DBNull.Value; // 画像情報データ
                                    }
                                    break;
                            }

                            // 自社名１分割
                            if ( row["CMP1.COMPANYNAME1RF"] != DBNull.Value )
                            {
                                string firstHalf;
                                string lastHalf;
                                DivideEnterpriseName( (string)row["CMP1.COMPANYNAME1RF"], out firstHalf, out lastHalf );
                                row["HADD.PRINTENTERPRISENAME1FHRF"] = firstHalf;
                                row["HADD.PRINTENTERPRISENAME1LHRF"] = lastHalf;
                            }
                            else
                            {
                                row["HADD.PRINTENTERPRISENAME1FHRF"] = DBNull.Value;
                                row["HADD.PRINTENTERPRISENAME1LHRF"] = DBNull.Value;
                            }
                            // 自社名２分割
                            if ( row["CMP1.COMPANYNAME2RF"] != DBNull.Value )
                            {
                                string firstHalf;
                                string lastHalf;
                                DivideEnterpriseName( (string)row["CMP1.COMPANYNAME2RF"], out firstHalf, out lastHalf );
                                row["HADD.PRINTENTERPRISENAME2FHRF"] = firstHalf;
                                row["HADD.PRINTENTERPRISENAME2LHRF"] = lastHalf;
                            }
                            else
                            {
                                row["HADD.PRINTENTERPRISENAME2FHRF"] = DBNull.Value;
                                row["HADD.PRINTENTERPRISENAME2LHRF"] = DBNull.Value;
                            }

                            # endregion

                            // 伝票合計金額
                            # region [伝票合計金額]
                            if ( pageIndex == allPageCount - 1 )
                            {
                                row["HADD.TTLSTOCKMOVEPRICERF"] = slipWork.HADD_TTLSTOCKMOVEPRICERF; // 移動金額
                                row["HADD.TTLSTOCKMOVELISTPRICERF"] = slipWork.HADD_TTLSTOCKMOVELISTPRICERF; // 移動金額(標準価格)
                            }
                            else
                            {
                                row["HADD.TTLSTOCKMOVEPRICERF"] = DBNull.Value; // 移動金額
                                row["HADD.TTLSTOCKMOVELISTPRICERF"] = DBNull.Value; // 移動金額(標準価格)
                            }
                            # endregion

                            # endregion

                            # region [伝票項目(伝票タイプ別設定)]
                            // 担当者
                            if ( eachSlipTypeSet.SalesEmployee == 0 )
                            {
                                row["MOVH.SHIPAGENTCDRF"] = DBNull.Value; // 出荷担当従業員コード
                                row["MOVH.SHIPAGENTNMRF"] = DBNull.Value; // 出荷担当従業員名称
                            }
                            // 発行者
                            if ( eachSlipTypeSet.SalesInput == 0 )
                            {
                                row["MOVH.STOCKMVEMPCODERF"] = DBNull.Value; // 在庫移動入力従業員コード
                                row["MOVH.STOCKMVEMPNAMERF"] = DBNull.Value; // 在庫移動入力従業員名称
                            }
                            // 標準価格
                            if ( eachSlipTypeSet.ListPrice1 == 0 )
                            {
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/00/00 DEL
                                //row["HADD.STOCKMOVELISTPRICERF"] = DBNull.Value; // 移動金額(標準価格)
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/00/00 DEL
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/00/00 ADD
                                row["HADD.TTLSTOCKMOVELISTPRICERF"] = DBNull.Value; // 伝票合計金額(標準価格)
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/00/00 ADD
                            }
                            // 原価
                            if ( eachSlipTypeSet.Cost == 0 )
                            {
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/00/00 DEL
                                //row["HADD.STOCKMOVEPRICERF"] = DBNull.Value; // 移動金額
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/00/00 DEL
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/00/00 ADD
                                row["HADD.TTLSTOCKMOVEPRICERF"] = DBNull.Value; // 伝票合計金額
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/00/00 ADD
                            }
                            # endregion
                        }

                        if ( index <= printEndIndex && index < detailWorks.Count )
                        {
                            //-------------------------------------------
                            // 実明細
                            //-------------------------------------------

                            # region [明細項目Copy]
                            row["MOVD.STOCKMOVEFORMALRF"] = detailWorks[index].MOVD_STOCKMOVEFORMALRF; // 在庫移動形式
                            row["MOVD.STOCKMOVESLIPNORF"] = detailWorks[index].MOVD_STOCKMOVESLIPNORF; // 在庫移動伝票番号
                            row["MOVD.STOCKMOVEROWNORF"] = detailWorks[index].MOVD_STOCKMOVEROWNORF; // 在庫移動行番号
                            row["MOVD.BFSECTIONCODERF"] = detailWorks[index].MOVD_BFSECTIONCODERF; // 移動元拠点コード
                            row["MOVD.BFENTERWAREHCODERF"] = detailWorks[index].MOVD_BFENTERWAREHCODERF; // 移動元倉庫コード
                            row["MOVD.AFSECTIONCODERF"] = detailWorks[index].MOVD_AFSECTIONCODERF; // 移動先拠点コード
                            row["MOVD.AFENTERWAREHCODERF"] = detailWorks[index].MOVD_AFENTERWAREHCODERF; // 移動先倉庫コード
                            row["MOVD.SUPPLIERCDRF"] = detailWorks[index].MOVD_SUPPLIERCDRF; // 仕入先コード
                            row["MOVD.SUPPLIERSNMRF"] = detailWorks[index].MOVD_SUPPLIERSNMRF; // 仕入先略称
                            row["MOVD.GOODSMAKERCDRF"] = detailWorks[index].MOVD_GOODSMAKERCDRF; // 商品メーカーコード
                            row["MOVD.MAKERNAMERF"] = detailWorks[index].MOVD_MAKERNAMERF; // メーカー名称
                            row["MOVD.GOODSNORF"] = detailWorks[index].MOVD_GOODSNORF; // 商品番号
                            row["MOVD.GOODSNAMERF"] = detailWorks[index].MOVD_GOODSNAMERF; // 商品名称
                            row["MOVD.GOODSNAMEKANARF"] = detailWorks[index].MOVD_GOODSNAMEKANARF; // 商品名称カナ
                            row["MOVD.STOCKDIVRF"] = detailWorks[index].MOVD_STOCKDIVRF; // 在庫区分
                            row["MOVD.STOCKUNITPRICEFLRF"] = detailWorks[index].MOVD_STOCKUNITPRICEFLRF; // 仕入単価（税抜,浮動）
                            row["MOVD.TAXATIONDIVCDRF"] = detailWorks[index].MOVD_TAXATIONDIVCDRF; // 課税区分
                            row["MOVD.MOVECOUNTRF"] = detailWorks[index].MOVD_MOVECOUNTRF; // 移動数
                            row["MOVD.BFSHELFNORF"] = detailWorks[index].MOVD_BFSHELFNORF; // 移動元棚番
                            row["MOVD.AFSHELFNORF"] = detailWorks[index].MOVD_AFSHELFNORF; // 移動先棚番
                            row["MOVD.BLGOODSCODERF"] = detailWorks[index].MOVD_BLGOODSCODERF; // BL商品コード
                            row["MOVD.BLGOODSFULLNAMERF"] = detailWorks[index].MOVD_BLGOODSFULLNAMERF; // BL商品コード名称（全角）
                            row["MOVD.LISTPRICEFLRF"] = detailWorks[index].MOVD_LISTPRICEFLRF; // 定価（浮動）
                            row["MOVD.MOVESTATUSRF"] = detailWorks[index].MOVD_MOVESTATUSRF; // 移動状態
                            row["BLGOODSCDURF.BLGOODSHALFNAMERF"] = detailWorks[index].BLGOODSCDURF_BLGOODSHALFNAMERF; // BL商品コード名称（半角）
                            row["MAKERURF.MAKERSHORTNAMERF"] = detailWorks[index].MAKERURF_MAKERSHORTNAMERF; // メーカー略称
                            row["MAKERURF.MAKERKANANAMERF"] = detailWorks[index].MAKERURF_MAKERKANANAMERF; // メーカーカナ名称
                            row["STC1.DUPLICATIONSHELFNO1RF"] = detailWorks[index].STC1_DUPLICATIONSHELFNO1RF; // 重複棚番１
                            row["STC1.DUPLICATIONSHELFNO2RF"] = detailWorks[index].STC1_DUPLICATIONSHELFNO2RF; // 重複棚番２
                            row["STC1.PARTSMANAGEMENTDIVIDE1RF"] = detailWorks[index].STC1_PARTSMANAGEMENTDIVIDE1RF; // 部品管理区分１
                            row["STC1.PARTSMANAGEMENTDIVIDE2RF"] = detailWorks[index].STC1_PARTSMANAGEMENTDIVIDE2RF; // 部品管理区分２
                            row["STC1.STOCKNOTE1RF"] = detailWorks[index].STC1_STOCKNOTE1RF; // 在庫備考１
                            row["STC1.STOCKNOTE2RF"] = detailWorks[index].STC1_STOCKNOTE2RF; // 在庫備考２
                            row["STC1.SHIPMENTPOSCNTRF"] = detailWorks[index].STC1_SHIPMENTPOSCNTRF; // 出荷可能数
                            row["STC2.DUPLICATIONSHELFNO1RF"] = detailWorks[index].STC2_DUPLICATIONSHELFNO1RF; // 重複棚番１
                            row["STC2.DUPLICATIONSHELFNO2RF"] = detailWorks[index].STC2_DUPLICATIONSHELFNO2RF; // 重複棚番２
                            row["STC2.PARTSMANAGEMENTDIVIDE1RF"] = detailWorks[index].STC2_PARTSMANAGEMENTDIVIDE1RF; // 部品管理区分１
                            row["STC2.PARTSMANAGEMENTDIVIDE2RF"] = detailWorks[index].STC2_PARTSMANAGEMENTDIVIDE2RF; // 部品管理区分２
                            row["STC2.STOCKNOTE1RF"] = detailWorks[index].STC2_STOCKNOTE1RF; // 在庫備考１
                            row["STC2.STOCKNOTE2RF"] = detailWorks[index].STC2_STOCKNOTE2RF; // 在庫備考２
                            row["STC2.SHIPMENTPOSCNTRF"] = detailWorks[index].STC2_SHIPMENTPOSCNTRF; // 出荷可能数
                            row["SUP.SUPPLIERNM1RF"] = detailWorks[index].SUP_SUPPLIERNM1RF; // 仕入先名1
                            row["SUP.SUPPLIERNM2RF"] = detailWorks[index].SUP_SUPPLIERNM2RF; // 仕入先名2
                            row["SUP.SUPPHONORIFICTITLERF"] = detailWorks[index].SUP_SUPPHONORIFICTITLERF; // 仕入先敬称
                            row["SUP.SUPPLIERKANARF"] = detailWorks[index].SUP_SUPPLIERKANARF; // 仕入先カナ
                            row["SUP.PURECODERF"] = detailWorks[index].SUP_PURECODERF; // 純正区分
                            row["SUP.SUPPLIERNOTE1RF"] = detailWorks[index].SUP_SUPPLIERNOTE1RF; // 仕入先備考1
                            row["SUP.SUPPLIERNOTE2RF"] = detailWorks[index].SUP_SUPPLIERNOTE2RF; // 仕入先備考2
                            row["SUP.SUPPLIERNOTE3RF"] = detailWorks[index].SUP_SUPPLIERNOTE3RF; // 仕入先備考3
                            row["SUP.SUPPLIERNOTE4RF"] = detailWorks[index].SUP_SUPPLIERNOTE4RF; // 仕入先備考4
                            row["GDS.GOODSNAMEKANARF"] = detailWorks[index].GDS_GOODSNAMEKANARF; // 商品名称カナ
                            row["GDS.JANRF"] = detailWorks[index].GDS_JANRF; // JANコード
                            row["GDS.GOODSRATERANKRF"] = detailWorks[index].GDS_GOODSRATERANKRF; // 商品掛率ランク
                            row["GDS.GOODSNONONEHYPHENRF"] = detailWorks[index].GDS_GOODSNONONEHYPHENRF; // ハイフン無商品番号
                            row["GDS.GOODSNOTE1RF"] = detailWorks[index].GDS_GOODSNOTE1RF; // 商品備考１
                            row["GDS.GOODSNOTE2RF"] = detailWorks[index].GDS_GOODSNOTE2RF; // 商品備考２
                            row["GDS.GOODSSPECIALNOTERF"] = detailWorks[index].GDS_GOODSSPECIALNOTERF; // 商品規格・特記事項
                            //row["DADD.STOCKDIVNMRF"] = detailWorks[index].DADD_STOCKDIVNMRF; // 在庫区分名称
                            //row["DADD.TAXATIONDIVCDNMRF"] = detailWorks[index].DADD_TAXATIONDIVCDNMRF; // 課税区分名称
                            //row["DADD.PURECODENMRF"] = detailWorks[index].DADD_PURECODENMRF; // 純正区分名称
                            //row["DADD.STOCKMOVEPRICERF"] = detailWorks[index].DADD_STOCKMOVEPRICERF; // 移動金額
                            //row["DADD.STOCKMOVELISTPRICERF"] = detailWorks[index].DADD_STOCKMOVELISTPRICERF; // 移動金額(標準価格)
                            //row["DADD.BFSTOCKCOUNTPREVRF"] = detailWorks[index].DADD_BFSTOCKCOUNTPREVRF; // 移動元移動前数
                            //row["DADD.BFSTOCKCOUNTRF"] = detailWorks[index].DADD_BFSTOCKCOUNTRF; // 移動元移動後数
                            //row["DADD.AFSTOCKCOUNTPREVRF"] = detailWorks[index].DADD_AFSTOCKCOUNTPREVRF; // 移動先移動前数
                            //row["DADD.AFSTOCKCOUNTRF"] = detailWorks[index].DADD_AFSTOCKCOUNTRF; // 移動先移動後数
                            # endregion

                            # region [明細項目(自動以外)]

                            // 未設定時 非印字コード
                            # region [未設定]
                            // 数値コード
                            if ( IsZero( detailWorks[index].MOVD_SUPPLIERCDRF ) ) row["MOVD.SUPPLIERCDRF"] = DBNull.Value; // 仕入先コード
                            if ( IsZero( detailWorks[index].MOVD_GOODSMAKERCDRF ) ) row["MOVD.GOODSMAKERCDRF"] = DBNull.Value; // 商品メーカーコード
                            if ( IsZero( detailWorks[index].MOVD_BLGOODSCODERF ) ) row["MOVD.BLGOODSCODERF"] = DBNull.Value; // BL商品コード
                            // 文字列コード
                            if ( IsZero( detailWorks[index].MOVD_BFSECTIONCODERF ) ) row["MOVD.BFSECTIONCODERF"] = DBNull.Value; // 移動元拠点コード
                            if ( IsZero( detailWorks[index].MOVD_BFENTERWAREHCODERF ) ) row["MOVD.BFENTERWAREHCODERF"] = DBNull.Value; // 移動元倉庫コード
                            if ( IsZero( detailWorks[index].MOVD_AFSECTIONCODERF ) ) row["MOVD.AFSECTIONCODERF"] = DBNull.Value; // 移動先拠点コード
                            if ( IsZero( detailWorks[index].MOVD_AFENTERWAREHCODERF ) ) row["MOVD.AFENTERWAREHCODERF"] = DBNull.Value; // 移動先倉庫コード
                            # endregion

                            // 区分名称
                            # region [区分名称]
                            row["DADD.STOCKDIVNMRF"] = GetDADD_STOCKDIVNMRFRF( detailWorks[index].MOVD_STOCKDIVRF ); // 在庫区分名称
                            row["DADD.TAXATIONDIVCDNMRF"] = GetDADD_TAXATIONDIVCDNMRFRF( detailWorks[index].MOVD_TAXATIONDIVCDRF ); // 課税区分名称
                            row["DADD.PURECODENMRF"] = GetDADD_PURECODENMRFRF( detailWorks[index].SUP_PURECODERF ); // 純正区分名称
                            # endregion

                            // 移動金額・移動金額(標準価格)
                            # region [金額]
                            row["DADD.STOCKMOVEPRICERF"] = detailWorks[index].DADD_STOCKMOVEPRICERF; // 移動金額
                            row["DADD.STOCKMOVELISTPRICERF"] = detailWorks[index].DADD_STOCKMOVELISTPRICERF; // 移動金額(標準価格)
                            # endregion

                            // 移動元・移動先の移動前後在庫数
                            # region [移動前後数]
                            // 0:移動対象外、1:未出荷状態、2:移動中、9:入荷済
                            switch ( detailWorks[index].MOVD_MOVESTATUSRF )
                            {
                                case 1:
                                    {
                                        // 未出荷状態
                                        row["DADD.BFSTOCKCOUNTPREVRF"] = detailWorks[index].STC1_SHIPMENTPOSCNTRF; // 移動元・移動前数
                                        row["DADD.BFSTOCKCOUNTRF"] = detailWorks[index].STC1_SHIPMENTPOSCNTRF - detailWorks[index].MOVD_MOVECOUNTRF; // 移動元・移動後数
                                        row["DADD.AFSTOCKCOUNTPREVRF"] = detailWorks[index].STC2_SHIPMENTPOSCNTRF; // 移動先・移動前数
                                        row["DADD.AFSTOCKCOUNTRF"] = detailWorks[index].STC2_SHIPMENTPOSCNTRF + detailWorks[index].MOVD_MOVECOUNTRF; // 移動先・移動後数
                                    }
                                    break;
                                case 2:
                                    {
                                        // 移動中
                                        row["DADD.BFSTOCKCOUNTPREVRF"] = detailWorks[index].STC1_SHIPMENTPOSCNTRF + detailWorks[index].MOVD_MOVECOUNTRF; // 移動元・移動前数
                                        row["DADD.BFSTOCKCOUNTRF"] = detailWorks[index].STC1_SHIPMENTPOSCNTRF; // 移動元・移動後数
                                        row["DADD.AFSTOCKCOUNTPREVRF"] = detailWorks[index].STC2_SHIPMENTPOSCNTRF; // 移動先・移動前数
                                        row["DADD.AFSTOCKCOUNTRF"] = detailWorks[index].STC2_SHIPMENTPOSCNTRF + detailWorks[index].MOVD_MOVECOUNTRF; // 移動先・移動後数
                                    }
                                    break;
                                case 9:
                                    {
                                        // 入荷済
                                        row["DADD.BFSTOCKCOUNTPREVRF"] = detailWorks[index].STC1_SHIPMENTPOSCNTRF + detailWorks[index].MOVD_MOVECOUNTRF; // 移動元・移動前数
                                        row["DADD.BFSTOCKCOUNTRF"] = detailWorks[index].STC1_SHIPMENTPOSCNTRF; // 移動元・移動後数
                                        row["DADD.AFSTOCKCOUNTPREVRF"] = detailWorks[index].STC2_SHIPMENTPOSCNTRF - detailWorks[index].MOVD_MOVECOUNTRF; // 移動先・移動前数
                                        row["DADD.AFSTOCKCOUNTRF"] = detailWorks[index].STC2_SHIPMENTPOSCNTRF; // 移動先・移動後数
                                    }
                                    break;
                                default:
                                    {
                                        // 印字しない(DBNullを入れる)
                                        row["DADD.BFSTOCKCOUNTPREVRF"] = DBNull.Value; // 移動元・移動前数
                                        row["DADD.BFSTOCKCOUNTRF"] = DBNull.Value; // 移動元・移動後数
                                        row["DADD.AFSTOCKCOUNTPREVRF"] = DBNull.Value; // 移動先・移動前数
                                        row["DADD.AFSTOCKCOUNTRF"] = DBNull.Value; // 移動先・移動後数
                                    }
                                    break;
                            }
                            # endregion

                            // 出庫・入庫タイトル
                            # region [出庫・入庫タイトル]
                            // --- ADD  大矢睦美  2010/05/27 ---------->>>>>
                            if (titleDic.ContainsKey(ct_BfTitle))
                            {
                                row[ct_BfTitle] = titleDic[ct_BfTitle];
                            }
                            else
                            {
                                row[ct_BfTitle] = "出";
                            }
                            if (titleDic.ContainsKey(ct_AfTitle))
                            {
                                row[ct_AfTitle] = titleDic[ct_AfTitle];
                            }
                            else
                            {
                                row[ct_AfTitle] = "入";
                            }
                            //row[ct_BfTitle] = "出";
                            //row[ct_AfTitle] = "入";
                            // --- ADD  大矢睦美  2010/05/27 ----------<<<<<
                            # endregion

                            // 半角名対応
                            # region [半角名対応]
                            if ( string.IsNullOrEmpty( detailWorks[index].MOVD_GOODSNAMEKANARF ) )
                            {
                                row["MOVD.GOODSNAMEKANARF"] = detailWorks[index].MOVD_GOODSNAMERF; // 品名カナ←品名セット
                            }
                            # endregion

                            # endregion

                            # region [明細項目(伝票タイプ別設定)]
                            // 品番
                            if ( eachSlipTypeSet.GoodsNo == 0 )
                            {
                                row["MOVD.GOODSNORF"] = DBNull.Value; // 商品番号
                                row["GDS.GOODSNONONEHYPHENRF"] = DBNull.Value; // ハイフン無商品番号
                            }
                            // ＢＬコード
                            if ( eachSlipTypeSet.BLGoodsCode == 0 )
                            {
                                row["MOVD.BLGOODSCODERF"] = DBNull.Value; // BL商品コード
                                row["MOVD.BLGOODSFULLNAMERF"] = DBNull.Value; // BL商品コード名称（全角）
                                row["BLGOODSCDURF.BLGOODSHALFNAMERF"] = DBNull.Value; // BL商品コード名称（半角）
                            }
                            // 標準価格
                            if ( eachSlipTypeSet.ListPrice1 == 0 )
                            {
                                row["MOVD.LISTPRICEFLRF"] = DBNull.Value; // 定価（浮動）
                                row["DADD.STOCKMOVELISTPRICERF"] = DBNull.Value; // 移動金額(標準価格)
                            }
                            // 原価
                            if ( eachSlipTypeSet.Cost == 0 )
                            {
                                row["MOVD.STOCKUNITPRICEFLRF"] = DBNull.Value; // 仕入単価（税抜,浮動）
                                row["DADD.STOCKMOVEPRICERF"] = DBNull.Value; // 移動金額
                            }
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
                        row[ct_InPageCopyCount] = (pageIndex * 10) + inPageCopyCount;    // 同一ページ内コピーカウント

                        // --- ADD 李占川 2011/08/15---------->>>>>
                        // --- UPD m.suzuki 2011/09/27 ---------->>>>>
                        //if ( inPageCopyTitle[0].Count < 5 )
                        //{
                        //    for (int i = inPageCopyTitle[0].Count; i < 5; i++)
                        //    {
                        //        inPageCopyTitle[0].Add(string.Empty);
                        //    }
                        //}
                        //row[ct_SlipTitle11] = inPageCopyTitle[0][0]; // タイトル１・１
                        //row[ct_SlipTitle12] = inPageCopyTitle[0][1]; // タイトル１・２
                        //row[ct_SlipTitle13] = inPageCopyTitle[0][2]; // タイトル１・３
                        //row[ct_SlipTitle14] = inPageCopyTitle[0][3]; // タイトル１・４
                        //row[ct_SlipTitle15] = inPageCopyTitle[0][4]; // タイトル１・５

                        for ( int i = 0; i < inPageCopyTitle[0].Count; i++ )
                            {
                            row["PMZAI08001P.SLIPTITLE1" + (i + 1)] = inPageCopyTitle[0][i];
                            }
                        // --- UPD m.suzuki 2011/09/27 ----------<<<<<

                        row[ct_SlipTitle21] = inPageCopyTitle[1][0]; // タイトル２・１
                        row[ct_SlipTitle22] = inPageCopyTitle[1][1]; // タイトル２・２
                        row[ct_SlipTitle23] = inPageCopyTitle[1][2]; // タイトル２・３
                        row[ct_SlipTitle24] = inPageCopyTitle[1][3]; // タイトル２・４
                        row[ct_SlipTitle25] = inPageCopyTitle[1][4]; // タイトル２・５

                        row[ct_SlipTitle31] = inPageCopyTitle[2][0]; // タイトル３・１
                        row[ct_SlipTitle32] = inPageCopyTitle[2][1]; // タイトル３・２
                        row[ct_SlipTitle33] = inPageCopyTitle[2][2]; // タイトル３・３
                        row[ct_SlipTitle34] = inPageCopyTitle[2][3]; // タイトル３・４
                        row[ct_SlipTitle35] = inPageCopyTitle[2][4]; // タイトル３・５

                        row[ct_SlipTitle41] = inPageCopyTitle[3][0]; // タイトル４・１
                        row[ct_SlipTitle42] = inPageCopyTitle[3][1]; // タイトル４・２
                        row[ct_SlipTitle43] = inPageCopyTitle[3][2]; // タイトル４・３
                        row[ct_SlipTitle44] = inPageCopyTitle[3][3]; // タイトル４・４
                        row[ct_SlipTitle45] = inPageCopyTitle[3][4]; // タイトル４・５
                        // --- ADD 李占川 2011/08/15----------<<<<<
                        # endregion

                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/16 ADD
                        // タイトル別印字制御対応
                        ReflectColumnVisibleType( ref row, columnVisibleTypeDic, inPageCopyCount );
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/16 ADD
                        # endregion

                        table.Rows.Add( row );
                    }

                    // --- ADD 李占川 2011/08/15---------->>>>>
                    // サブレポートが有る（サブレポート機能の処理）
                    if (subReportDic.Count > 0)
                    {
                        break;
                    }
                    // --- ADD 李占川 2011/08/15----------<<<<<
                }

                pageStartIndex = Math.Min( pageEndIndex, printEndIndex ) + 1;
                pageEndIndex = pageStartIndex + feedCount - 1;
                printEndIndex = pageStartIndex + slipPrtSet.DetailRowCount - 1;
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
        /// 移動金額
        /// </summary>
        /// <param name="frePStockMoveDetailWork"></param>
        /// <returns></returns>
        private static Int64 GetSTOCKMOVEPRICERF( FrePStockMoveDetailWork frePStockMoveDetailWork )
        {
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/22 DEL
            //decimal unitPrice = (decimal)frePStockMoveDetailWork.MOVD_STOCKUNITPRICEFLRF; // 仕入単価（税抜,浮動）
            //decimal moveCount = (decimal)frePStockMoveDetailWork.MOVD_MOVECOUNTRF; // 移動数
            //return (Int64)Round( unitPrice * moveCount );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/22 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/22 ADD
            return frePStockMoveDetailWork.MOVD_STOCKMOVEPRICERF;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/22 ADD
        }
        /// <summary>
        /// 移動金額（標準価格）
        /// </summary>
        /// <param name="frePStockMoveDetailWork"></param>
        /// <returns></returns>
        private static Int64 GetSTOCKMOVELISTPRICERF( FrePStockMoveDetailWork frePStockMoveDetailWork )
        {
            decimal unitPrice = (decimal)frePStockMoveDetailWork.MOVD_LISTPRICEFLRF; // 定価（浮動）
            decimal moveCount = (decimal)frePStockMoveDetailWork.MOVD_MOVECOUNTRF; // 移動数
            return (Int64)Round( unitPrice * moveCount );
        }
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

            // --- DEL  大矢睦美  2010/03/31 ---------->>>>>
            // 和暦フラグ
            //bool jpEra = (eraNameDispCd == 1);
            // --- DEL  大矢睦美  2010/03/31 ----------<<<<<
            // --- ADD  大矢睦美  2010/03/31 ---------->>>>>
            bool jpEra;
            if (!ReportItemDic.ContainsKey(string.Format("{0}{1}RF", dateColumnName, "FW")))
            {
                // "和暦年"項目が無い→西暦固定
                jpEra = false;
            }
            else if (!ReportItemDic.ContainsKey(string.Format("{0}{1}RF", dateColumnName, "FY")) &&
                      !ReportItemDic.ContainsKey(string.Format("{0}{1}RF", dateColumnName, "FS")))
            {
                // "西暦年"・"西暦年略"項目が両方無い→和暦固定
                jpEra = true;
            }
            else
            {
                // 通常は区分値に従う
                jpEra = (eraNameDispCd == 1);
            }
            // --- ADD  大矢睦美  2010/03/31 ----------<<<<<
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
    }
}
