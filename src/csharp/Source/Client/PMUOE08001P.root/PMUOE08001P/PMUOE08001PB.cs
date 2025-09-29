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
using Broadleaf.Application.Controller;
using Broadleaf.Application.Resources;//ADD  2011/08/05

namespace Broadleaf.Drawing.Printing
{
    /// <summary>
    /// 自由帳票(ＵＯＥ伝票)印刷クラス
    /// </summary>
    /// <remarks>
    /// <br>Note         : 印刷DataSourceのテーブル生成を行います。</br>
    /// <br>               (売上伝票をベースに作成)</br>
    /// <br>               </br>
    /// <br>Programmer   : 22018 鈴木　正臣</br>
    /// <br>Date         : 2008.11.18</br>
    /// <br></br>
    /// <br>Update Note  : 劉洋　2009.07.24 オートバックス対応</br>
    /// <br></br>
    /// <br>Update Note  : 2009/10/05  30531 大矢睦美</br>
    /// <br>             : U700の合計部印字制御をPM7と同内容に修正。（印字位置がU600と異なる）</br>
    /// <br></br>
    /// <br>Update Note  : 2010/03/24  22018 鈴木 正臣</br>
    /// <br>             : ＱＲコードの印刷機能を追加。</br>
    /// <br></br>
    /// <br>Update Note  : 2010/03/31  22018 鈴木 正臣</br>
    /// <br>             : ＱＲコードの伝票番号を９桁に変更。（整備側で9桁取込み可能に変更となる為）</br>
    /// <br></br>
    /// <br>Update Note  : 2010/05/14  30531 大矢 睦美</br>
    /// <br>             : 伝票印字項目追加(粗利額、粗利率等)</br>
    /// <br></br>
    /// <br>Update Note  : 2010/11/11  30517 夏野 駿希</br>
    /// <br>             : 大一用品商会個別対応</br>
    /// <br>             : 春日井パーツ商会で作成した項目を追加（伝票小計（春日井用））</br>
    /// <br></br>
    /// <br>Update Note  : 2011/02/16  徐嘉</br>
    /// <br>               自社名称１，２が縦倍角になっていない不具合の対応</br> 
    /// <br></br>
    /// <br>Update Note  : 2011/05/27  30517 夏野 駿希</br>
    /// <br>               中村オートパーツ個別対応</br> 
    /// <br>               粗利率チェックマークの追加</br> 
    /// <br>Update Note  : 2011/07/19  豆昌紅</br>
    /// <br>               自動回答区分(SCM)の追加</br>
    /// <br>Update Note  : 2011/08/05  豆昌紅</br>
    /// <br>               障害報告 #23404: プロジェクトNo1 PCC for NS（SCM）改良 SCM連携課題一覧№59対応</br>
    /// <br>Update Note  : 2011/08/08  豆昌紅</br>
    /// <br>               障害報告 #23459: SCMオプションコードを利用</br>
    /// <br></br>
    /// <br>Update Note  : 2011/08/15 李占川    連番985</br>
    /// <br>             　【PM要望改良9月配信分】Redmine#23541 連番985の対応</br> 
    /// <br>Update Note: 2011/08/30 yangmj</br>
    /// <br>             Redmine#24110 伝票備考の文字数の修正内容の対応</br> 
    /// <br></br>
    /// <br>Update Note  : 2011/09/27  22018 鈴木 正臣</br>
    /// <br>               一度の印刷で伝票が5枚印刷される不具合の修正</br>
    /// <br>Update Note  : 2017/08/30 3H 楊善娟</br>
    /// <br>管理番号     : 11370074-00 ハンディ対応（2次）</br>
    /// </remarks>
    internal class PMUOE08001PB
    {
        # region [public static readonly メンバ]
        /// <summary>自由帳票ＵＯＥ伝票テーブル</summary>
        public static readonly string ct_TBL_FREPSALESSLIP = "FREPSALESSLIP";
        /// <summary>同一ページ内コピーカウントcolumn名称</summary>
        public static readonly string ct_InPageCopyCount = "PMUOE08001P.INPAGECOPYCOUNT";
        /// <summary>複写タイトル１</summary>
        public static readonly string ct_InPageCopyTitle1 = "PMUOE08001P.INPAGECOPYTITLE1";
        /// <summary>複写タイトル２</summary>
        public static readonly string ct_InPageCopyTitle2 = "PMUOE08001P.INPAGECOPYTITLE2";
        /// <summary>複写タイトル３</summary>
        public static readonly string ct_InPageCopyTitle3 = "PMUOE08001P.INPAGECOPYTITLE3";
        /// <summary>複写タイトル４</summary>
        public static readonly string ct_InPageCopyTitle4 = "PMUOE08001P.INPAGECOPYTITLE4";

        /// <summary>頁数</summary>
        public static readonly string ct_PageCount = "PAGE.PAGECOUNTRF";
        ///// <summary>受注数</summary>
        //public static readonly string ct_AcptCount = "DPRT.ACPTCOUNTRF";
        ///// <summary>出荷数</summary>
        //public static readonly string ct_ShipCount = "DPRT.SHIPCUONTRF";
        /// <summary>(先頭)類別型式ハイフン</summary>
        public static readonly string ct_HCategoryHyp = "HPRT.CATEGORYHYPRF";
        /// <summary>類別型式ハイフン</summary>
        public static readonly string ct_DCategoryHyp = "DPRT.CATEGORYHYPRF";

        // --- ADD m.suzuki 2010/03/24 ---------->>>>>
        /// <summary>伝票データＱＲコード</summary>
        public static readonly string ct_QRCode = "HPRT.QRCODERF";
        /// <summary>伝票データＱＲコード(暗号前CSVデータ)</summary>
        public static readonly string ct_QRCodeSource = "HPRT.QRCODESOURCERF";
        // --- ADD m.suzuki 2010/03/24 ----------<<<<<

        ///// <summary>倉庫コード（タイトル１・２）</summary>
        //public static readonly string ct_DWarehouseCodeRF = "DPRT.WAREHOUSECODERF";
        ///// <summary>倉庫名（タイトル１・２）</summary>
        //public static readonly string ct_DWarehouseNameRF = "DPRT.WAREHOUSENAMERF";
        ///// <summary>棚番（タイトル１・２）</summary>
        //public static readonly string ct_DWarehouseShelfNoRF = "DPRT.WAREHOUSESHELFNORF";
        /// <summary>仕入先コード（取寄のみ）</summary>
        public static readonly string ct_SupplierCdExtra = "DPRT.SUPPLIERCDEXTRARF";
        /// <summary>棚番（得意先注番なし時）</summary>
        public static readonly string ct_ShelfNoExtra = "DPRT.SHELFNOEXTRARF";
        /// <summary>受信時刻（時）</summary>
        public static readonly string ct_ReceiveTimeHour = "HADD.RECEIVETIMEHOURRF";
        /// <summary>受信時刻（分）</summary>
        public static readonly string ct_ReceiveTimeMinute = "HADD.RECEIVETIMEMINUTERF";
        /// <summary>受信時刻（秒）</summary>
        public static readonly string ct_ReceiveTimeSecond = "HADD.RECEIVETIMESECONDRF";

        /// <summary>(Label)消費税タイトル</summary>
        public static readonly string ct_TaxTitle = "PMUOE08001P.TAXTITLE";
        /// <summary>(Label)小計タイトル</summary>
        public static readonly string ct_SubTotalTitle = "PMUOE08001P.SUBTOTALTITLE";
        /// <summary>(Label)受信時刻タイトル</summary>
        public static readonly string ct_ReceiveTimeLabel = "PMUOE08001P.RECEIVETIMELABEL";

        /// <summary>印刷用ゼロ文字列</summary>
        public static readonly string ct_ZeroText = "ｾﾞﾛ";
        /// <summary>印刷用ゼロ伝票 伝票番号</summary>
        public static readonly string ct_ZeroSlipNoText = "*********";

        // --- ADD  劉洋  2009.07.27 ---------->>>>>
        /// <summary>(Label)出荷数マイナス符号</summary>
        public static readonly string ct_ShipmentCntMinusSignRF = "PMHNB08001P.SHIPMENTCNTMINUSSIGNRF";
        /// <summary>(Label)売上金額（税抜き）売上金額マイナス符号</summary>
        public static readonly string ct_SalesMoneyTaxExcMinusSignRF = "PMHNB08001P.SALESMONEYTAXEXCMINUSSIGNRF";
        /// <summary>(Label)AB本部原価金額マイナス符号</summary>
        public static readonly string ct_ABHqSalesUnitCostMinusSignRF = "PMHNB08001P.ABHQSALESUNITCOSTMINUSSIGNRF";
        // --- ADD  劉洋  2009.07.27 ----------<<<<<

        // --- ADD 李占川 2011/08/15---------->>>>>
        /// <summary>(Label)サブレポート用伝票タイトル１・１</summary>
        public static readonly string ct_SlipTitle11 = "PMUOE08001PB.SLIPTITLE11";
        /// <summary>(Label)サブレポート用伝票タイトル１・２</summary>
        public static readonly string ct_SlipTitle12 = "PMUOE08001PB.SLIPTITLE12";
        /// <summary>(Label)サブレポート用伝票タイトル１・３</summary>
        public static readonly string ct_SlipTitle13 = "PMUOE08001PB.SLIPTITLE13";
        /// <summary>(Label)サブレポート用伝票タイトル１・４</summary>
        public static readonly string ct_SlipTitle14 = "PMUOE08001PB.SLIPTITLE14";
        /// <summary>(Label)サブレポート用伝票タイトル１・５</summary>
        public static readonly string ct_SlipTitle15 = "PMUOE08001PB.SLIPTITLE15";
        /// <summary>(Label)サブレポート用伝票タイトル２・１</summary>
        public static readonly string ct_SlipTitle21 = "PMUOE08001PB.SLIPTITLE21";
        /// <summary>(Label)サブレポート用伝票タイトル２・２</summary>
        public static readonly string ct_SlipTitle22 = "PMUOE08001PB.SLIPTITLE22";
        /// <summary>(Label)サブレポート用伝票タイトル２・３</summary>
        public static readonly string ct_SlipTitle23 = "PMUOE08001PB.SLIPTITLE23";
        /// <summary>(Label)サブレポート用伝票タイトル２・４</summary>
        public static readonly string ct_SlipTitle24 = "PMUOE08001PB.SLIPTITLE24";
        /// <summary>(Label)サブレポート用伝票タイトル２・５</summary>
        public static readonly string ct_SlipTitle25 = "PMUOE08001PB.SLIPTITLE25";
        /// <summary>(Label)サブレポート用伝票タイトル３・１</summary>
        public static readonly string ct_SlipTitle31 = "PMUOE08001PB.SLIPTITLE31";
        /// <summary>(Label)サブレポート用伝票タイトル３・２</summary>
        public static readonly string ct_SlipTitle32 = "PMUOE08001PB.SLIPTITLE32";
        /// <summary>(Label)サブレポート用伝票タイトル３・３</summary>
        public static readonly string ct_SlipTitle33 = "PMUOE08001PB.SLIPTITLE33";
        /// <summary>(Label)サブレポート用伝票タイトル３・４</summary>
        public static readonly string ct_SlipTitle34 = "PMUOE08001PB.SLIPTITLE34";
        /// <summary>(Label)サブレポート用伝票タイトル３・５</summary>
        public static readonly string ct_SlipTitle35 = "PMUOE08001PB.SLIPTITLE35";
        /// <summary>(Label)サブレポート用伝票タイトル４・１</summary>
        public static readonly string ct_SlipTitle41 = "PMUOE08001PB.SLIPTITLE41";
        /// <summary>(Label)サブレポート用伝票タイトル４・２</summary>
        public static readonly string ct_SlipTitle42 = "PMUOE08001PB.SLIPTITLE42";
        /// <summary>(Label)サブレポート用伝票タイトル４・３</summary>
        public static readonly string ct_SlipTitle43 = "PMUOE08001PB.SLIPTITLE43";
        /// <summary>(Label)サブレポート用伝票タイトル４・４</summary>
        public static readonly string ct_SlipTitle44 = "PMUOE08001PB.SLIPTITLE44";
        /// <summary>(Label)サブレポート用伝票タイトル４・５</summary>
        public static readonly string ct_SlipTitle45 = "PMUOE08001PB.SLIPTITLE45";
        // --- ADD 李占川 2011/08/15----------<<<<<
        # endregion

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.07.21 ADD
        # region [private static メンバ]
        /// <summary>レポート項目ディクショナリ</summary>
        private static Dictionary<string, string> stc_reportItemDic;
        # endregion
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.07.21 ADD
        // --- ADD  大矢睦美  2010/05/14 ---------->>>>>
        private static GrossProfitCalculator stc_grossProfitCalculator;
        // --- ADD  大矢睦美  2010/05/14 ----------<<<<<

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.07.21 ADD
        # region [public static メンバ]
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
        # endregion
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.07.21 ADD

        // 2010/11/11 Add >>>
        private static bool _KSGICustNameFlg = false;
        // 2010/11/11 Add <<<

        # region [データテーブル生成]
        /// <summary>
        /// データテーブル生成処理（スキーマ定義）
        /// </summary>
        /// <remarks>
        /// <br>Update Note  : 2017/08/30 3H 楊善娟</br>
        /// <br>管理番号     : 11370074-00 ハンディ対応（2次）</br>
        /// </remarks>
        public static DataTable CreateFrePSalesSlipTable(int index)
        {
            DataTable table = new DataTable(ct_TBL_FREPSALESSLIP + index.ToString());

            # region [スキーマ定義（伝票項目）]
            table.Columns.Add(new DataColumn("SALESSLIPRF.ACPTANODRSTATUSRF", typeof(Int32)));  // 受注ステータス
            table.Columns.Add(new DataColumn("SALESSLIPRF.SALESSLIPNUMRF", typeof(string)));  // ＵＯＥ伝票番号
            table.Columns.Add(new DataColumn("SALESSLIPRF.SECTIONCODERF", typeof(string)));  // 拠点コード
            table.Columns.Add(new DataColumn("SALESSLIPRF.SUBSECTIONCODERF", typeof(Int32)));  // 部門コード
            table.Columns.Add(new DataColumn("SALESSLIPRF.DEBITNOTEDIVRF", typeof(Int32)));  // 赤伝区分
            table.Columns.Add(new DataColumn("SALESSLIPRF.DEBITNLNKSALESSLNUMRF", typeof(string)));  // 赤黒連結ＵＯＥ伝票番号
            table.Columns.Add(new DataColumn("SALESSLIPRF.SALESSLIPCDRF", typeof(Int32)));  // ＵＯＥ伝票区分
            table.Columns.Add(new DataColumn("SALESSLIPRF.SALESGOODSCDRF", typeof(Int32)));  // 売上商品区分
            table.Columns.Add(new DataColumn("SALESSLIPRF.ACCRECDIVCDRF", typeof(Int32)));  // 売掛区分
            table.Columns.Add(new DataColumn("SALESSLIPRF.SEARCHSLIPDATERF", typeof(Int32)));  // 伝票検索日付
            table.Columns.Add(new DataColumn("SALESSLIPRF.SHIPMENTDAYRF", typeof(Int32)));  // 出荷日付
            table.Columns.Add(new DataColumn("SALESSLIPRF.SALESDATERF", typeof(Int32)));  // 売上日付
            table.Columns.Add(new DataColumn("SALESSLIPRF.ADDUPADATERF", typeof(Int32)));  // 計上日付
            table.Columns.Add(new DataColumn("SALESSLIPRF.DELAYPAYMENTDIVRF", typeof(Int32)));  // 来勘区分
            table.Columns.Add(new DataColumn("SALESSLIPRF.ESTIMATEFORMNORF", typeof(string)));  // 見積書番号
            table.Columns.Add(new DataColumn("SALESSLIPRF.ESTIMATEDIVIDERF", typeof(Int32)));  // 見積区分
            table.Columns.Add(new DataColumn("SALESSLIPRF.SALESINPUTCODERF", typeof(string)));  // 売上入力者コード
            table.Columns.Add(new DataColumn("SALESSLIPRF.SALESINPUTNAMERF", typeof(string)));  // 売上入力者名称
            table.Columns.Add(new DataColumn("SALESSLIPRF.FRONTEMPLOYEECDRF", typeof(string)));  // 受付従業員コード
            table.Columns.Add(new DataColumn("SALESSLIPRF.FRONTEMPLOYEENMRF", typeof(string)));  // 受付従業員名称
            table.Columns.Add(new DataColumn("SALESSLIPRF.SALESEMPLOYEECDRF", typeof(string)));  // 販売従業員コード
            table.Columns.Add(new DataColumn("SALESSLIPRF.SALESEMPLOYEENMRF", typeof(string)));  // 販売従業員名称
            table.Columns.Add(new DataColumn("SALESSLIPRF.TOTALAMOUNTDISPWAYCDRF", typeof(Int32)));  // 総額表示方法区分
            table.Columns.Add(new DataColumn("SALESSLIPRF.TTLAMNTDISPRATEAPYRF", typeof(Int32)));  // 総額表示掛率適用区分
            table.Columns.Add(new DataColumn("SALESSLIPRF.SALESTOTALTAXINCRF", typeof(Int64)));  // ＵＯＥ伝票合計（税込み）
            table.Columns.Add(new DataColumn("SALESSLIPRF.SALESTOTALTAXEXCRF", typeof(Int64)));  // ＵＯＥ伝票合計（税抜き）
            table.Columns.Add(new DataColumn("SALESSLIPRF.SALESSUBTOTALTAXINCRF", typeof(Int64)));  // 売上小計（税込み）
            table.Columns.Add(new DataColumn("SALESSLIPRF.SALESSUBTOTALTAXEXCRF", typeof(Int64)));  // 売上小計（税抜き）
            // 2010/11/11 Add >>>
            table.Columns.Add(new DataColumn("SALESSLIPRF.SALESSUBTOTALTAXEXCKSGIRF", typeof(Int64)));  // 売上小計（税抜き）（春日井用）
            // 2010/11/11 Add <<<
            //table.Columns.Add( new DataColumn( "SALESSLIPRF.SALSENETPRICERF", typeof( Int64 ) ) );  // 売上正価金額
            table.Columns.Add(new DataColumn("SALESSLIPRF.SALESSUBTOTALTAXRF", typeof(Int64)));  // 売上小計（税）
            table.Columns.Add(new DataColumn("SALESSLIPRF.ITDEDSALESOUTTAXRF", typeof(Int64)));  // 売上外税対象額
            table.Columns.Add(new DataColumn("SALESSLIPRF.ITDEDSALESINTAXRF", typeof(Int64)));  // 売上内税対象額
            table.Columns.Add(new DataColumn("SALESSLIPRF.SALSUBTTLSUBTOTAXFRERF", typeof(Int64)));  // 売上小計非課税対象額
            //table.Columns.Add( new DataColumn( "SALESSLIPRF.SALSEOUTTAXRF", typeof( Int64 ) ) );  // 売上金額消費税額（外税）
            table.Columns.Add(new DataColumn("SALESSLIPRF.SALAMNTCONSTAXINCLURF", typeof(Int64)));  // 売上金額消費税額（内税）
            table.Columns.Add(new DataColumn("SALESSLIPRF.SALESDISTTLTAXEXCRF", typeof(Int64)));  // 売上値引金額計（税抜き）
            table.Columns.Add(new DataColumn("SALESSLIPRF.ITDEDSALESDISOUTTAXRF", typeof(Int64)));  // 売上値引外税対象額合計
            table.Columns.Add(new DataColumn("SALESSLIPRF.ITDEDSALESDISINTAXRF", typeof(Int64)));  // 売上値引内税対象額合計
            //table.Columns.Add( new DataColumn( "SALESSLIPRF.ITDEDSALSEDISTAXFRERF", typeof( Int64 ) ) );  // 売上値引非課税対象額合計
            table.Columns.Add(new DataColumn("SALESSLIPRF.SALESDISOUTTAXRF", typeof(Int64)));  // 売上値引消費税額（外税）
            table.Columns.Add(new DataColumn("SALESSLIPRF.SALESDISTTLTAXINCLURF", typeof(Int64)));  // 売上値引消費税額（内税）
            table.Columns.Add(new DataColumn("SALESSLIPRF.TOTALCOSTRF", typeof(Int64)));  // 原価金額計
            table.Columns.Add(new DataColumn("SALESSLIPRF.CONSTAXLAYMETHODRF", typeof(Int32)));  // 消費税転嫁方式
            table.Columns.Add(new DataColumn("SALESSLIPRF.CONSTAXRATERF", typeof(Double)));  // 消費税税率
            table.Columns.Add(new DataColumn("SALESSLIPRF.FRACTIONPROCCDRF", typeof(Int32)));  // 端数処理区分
            table.Columns.Add(new DataColumn("SALESSLIPRF.ACCRECCONSTAXRF", typeof(Int64)));  // 売掛消費税
            table.Columns.Add(new DataColumn("SALESSLIPRF.AUTODEPOSITCDRF", typeof(Int32)));  // 自動入金区分
            table.Columns.Add(new DataColumn("SALESSLIPRF.AUTODEPOSITSLIPNORF", typeof(Int32)));  // 自動入金伝票番号
            table.Columns.Add(new DataColumn("SALESSLIPRF.DEPOSITALLOWANCETTLRF", typeof(Int64)));  // 入金引当合計額
            table.Columns.Add(new DataColumn("SALESSLIPRF.DEPOSITALWCBLNCERF", typeof(Int64)));  // 入金引当残高
            table.Columns.Add(new DataColumn("SALESSLIPRF.CLAIMCODERF", typeof(Int32)));  // 請求先コード
            table.Columns.Add(new DataColumn("SALESSLIPRF.CLAIMSNMRF", typeof(string)));  // 請求先略称
            table.Columns.Add(new DataColumn("SALESSLIPRF.CUSTOMERCODERF", typeof(Int32)));  // 得意先コード
            table.Columns.Add(new DataColumn("SALESSLIPRF.CUSTOMERNAMERF", typeof(string)));  // 得意先名称
            table.Columns.Add(new DataColumn("SALESSLIPRF.CUSTOMERNAME2RF", typeof(string)));  // 得意先名称2
            table.Columns.Add(new DataColumn("SALESSLIPRF.CUSTOMERSNMRF", typeof(string)));  // 得意先略称
            table.Columns.Add(new DataColumn("SALESSLIPRF.HONORIFICTITLERF", typeof(string)));  // 敬称
            table.Columns.Add(new DataColumn("SALESSLIPRF.ADDRESSEECODERF", typeof(Int32)));  // 納品先コード
            table.Columns.Add(new DataColumn("SALESSLIPRF.ADDRESSEENAMERF", typeof(string)));  // 納品先名称
            table.Columns.Add(new DataColumn("SALESSLIPRF.ADDRESSEENAME2RF", typeof(string)));  // 納品先名称2
            table.Columns.Add(new DataColumn("SALESSLIPRF.ADDRESSEEPOSTNORF", typeof(string)));  // 納品先郵便番号
            table.Columns.Add(new DataColumn("SALESSLIPRF.ADDRESSEEADDR1RF", typeof(string)));  // 納品先住所1(都道府県市区郡・町村・字)
            table.Columns.Add(new DataColumn("SALESSLIPRF.ADDRESSEEADDR3RF", typeof(string)));  // 納品先住所3(番地)
            table.Columns.Add(new DataColumn("SALESSLIPRF.ADDRESSEEADDR4RF", typeof(string)));  // 納品先住所4(アパート名称)
            table.Columns.Add(new DataColumn("SALESSLIPRF.ADDRESSEETELNORF", typeof(string)));  // 納品先電話番号
            table.Columns.Add(new DataColumn("SALESSLIPRF.ADDRESSEEFAXNORF", typeof(string)));  // 納品先FAX番号
            table.Columns.Add(new DataColumn("SALESSLIPRF.PARTYSALESLIPNUMRF", typeof(string)));  // 相手先伝票番号
            table.Columns.Add(new DataColumn("SALESSLIPRF.SLIPNOTERF", typeof(string)));  // 伝票備考
            table.Columns.Add(new DataColumn("SALESSLIPRF.SLIPNOTE2RF", typeof(string)));  // 伝票備考２
            table.Columns.Add(new DataColumn("SALESSLIPRF.RETGOODSREASONDIVRF", typeof(Int32)));  // 返品理由コード
            table.Columns.Add(new DataColumn("SALESSLIPRF.RETGOODSREASONRF", typeof(string)));  // 返品理由
            table.Columns.Add(new DataColumn("SALESSLIPRF.REGIPROCDATERF", typeof(Int32)));  // レジ処理日
            table.Columns.Add(new DataColumn("SALESSLIPRF.CASHREGISTERNORF", typeof(Int32)));  // レジ番号
            table.Columns.Add(new DataColumn("SALESSLIPRF.POSRECEIPTNORF", typeof(Int32)));  // POSレシート番号
            table.Columns.Add(new DataColumn("SALESSLIPRF.DETAILROWCOUNTRF", typeof(Int32)));  // 明細行数
            table.Columns.Add(new DataColumn("SALESSLIPRF.EDISENDDATERF", typeof(Int32)));  // ＥＤＩ送信日
            table.Columns.Add(new DataColumn("SALESSLIPRF.EDITAKEINDATERF", typeof(Int32)));  // ＥＤＩ取込日
            table.Columns.Add(new DataColumn("SALESSLIPRF.UOEREMARK1RF", typeof(string)));  // ＵＯＥリマーク１
            table.Columns.Add(new DataColumn("SALESSLIPRF.UOEREMARK2RF", typeof(string)));  // ＵＯＥリマーク２
            table.Columns.Add(new DataColumn("SALESSLIPRF.SLIPPRINTFINISHCDRF", typeof(Int32)));  // 伝票発行済区分
            table.Columns.Add(new DataColumn("SALESSLIPRF.SALESSLIPPRINTDATERF", typeof(Int32)));  // ＵＯＥ伝票発行日
            table.Columns.Add(new DataColumn("SALESSLIPRF.BUSINESSTYPECODERF", typeof(Int32)));  // 業種コード
            table.Columns.Add(new DataColumn("SALESSLIPRF.BUSINESSTYPENAMERF", typeof(string)));  // 業種名称
            table.Columns.Add(new DataColumn("SALESSLIPRF.ORDERNUMBERRF", typeof(string)));  // 発注番号
            table.Columns.Add(new DataColumn("SALESSLIPRF.DELIVEREDGOODSDIVRF", typeof(Int32)));  // 納品区分
            table.Columns.Add(new DataColumn("SALESSLIPRF.DELIVEREDGOODSDIVNMRF", typeof(string)));  // 納品区分名称
            table.Columns.Add(new DataColumn("SALESSLIPRF.SALESAREACODERF", typeof(Int32)));  // 販売エリアコード
            table.Columns.Add(new DataColumn("SALESSLIPRF.SALESAREANAMERF", typeof(string)));  // 販売エリア名称
            table.Columns.Add(new DataColumn("SALESSLIPRF.COMPLETECDRF", typeof(Int32)));  // 一式伝票区分
            table.Columns.Add(new DataColumn("SALESSLIPRF.STOCKGOODSTTLTAXEXCRF", typeof(Int64)));  // 在庫商品合計金額（税抜）
            table.Columns.Add(new DataColumn("SALESSLIPRF.PUREGOODSTTLTAXEXCRF", typeof(Int64)));  // 純正商品合計金額（税抜）
            table.Columns.Add(new DataColumn("SALESSLIPRF.LISTPRICEPRINTDIVRF", typeof(Int32)));  // 定価印刷区分
            table.Columns.Add(new DataColumn("SALESSLIPRF.ERANAMEDISPCD1RF", typeof(Int32)));  // 元号表示区分１
            table.Columns.Add(new DataColumn("SALESSLIPRF.ESTIMATAXDIVCDRF", typeof(Int32)));  // 見積消費税区分
            table.Columns.Add(new DataColumn("SALESSLIPRF.ESTIMATEFORMPRTCDRF", typeof(Int32)));  // 見積書印刷区分
            table.Columns.Add(new DataColumn("SALESSLIPRF.ESTIMATESUBJECTRF", typeof(string)));  // 見積件名
            table.Columns.Add(new DataColumn("SALESSLIPRF.FOOTNOTES1RF", typeof(string)));  // 脚注１
            table.Columns.Add(new DataColumn("SALESSLIPRF.FOOTNOTES2RF", typeof(string)));  // 脚注２
            table.Columns.Add(new DataColumn("SALESSLIPRF.ESTIMATETITLE1RF", typeof(string)));  // 見積タイトル１
            table.Columns.Add(new DataColumn("SALESSLIPRF.ESTIMATETITLE2RF", typeof(string)));  // 見積タイトル２
            table.Columns.Add(new DataColumn("SALESSLIPRF.ESTIMATETITLE3RF", typeof(string)));  // 見積タイトル３
            table.Columns.Add(new DataColumn("SALESSLIPRF.ESTIMATETITLE4RF", typeof(string)));  // 見積タイトル４
            table.Columns.Add(new DataColumn("SALESSLIPRF.ESTIMATETITLE5RF", typeof(string)));  // 見積タイトル５
            table.Columns.Add(new DataColumn("SALESSLIPRF.ESTIMATENOTE1RF", typeof(string)));  // 見積備考１
            table.Columns.Add(new DataColumn("SALESSLIPRF.ESTIMATENOTE2RF", typeof(string)));  // 見積備考２
            table.Columns.Add(new DataColumn("SALESSLIPRF.ESTIMATENOTE3RF", typeof(string)));  // 見積備考３
            table.Columns.Add(new DataColumn("SALESSLIPRF.ESTIMATENOTE4RF", typeof(string)));  // 見積備考４
            table.Columns.Add(new DataColumn("SALESSLIPRF.ESTIMATENOTE5RF", typeof(string)));  // 見積備考５
            table.Columns.Add(new DataColumn("SECINFOSETRF.SECTIONGUIDENMRF", typeof(string)));  // 拠点ガイド名称
            table.Columns.Add(new DataColumn("SECINFOSETRF.SECTIONGUIDESNMRF", typeof(string)));  // 拠点ガイド略称
            table.Columns.Add(new DataColumn("SECINFOSETRF.COMPANYNAMECD1RF", typeof(Int32)));  // 自社名称コード1
            table.Columns.Add(new DataColumn("COMPANYNMRF.COMPANYPRRF", typeof(string)));  // 自社PR文
            table.Columns.Add(new DataColumn("COMPANYNMRF.COMPANYNAME1RF", typeof(string)));  // 自社名称1
            table.Columns.Add(new DataColumn("COMPANYNMRF.COMPANYNAME2RF", typeof(string)));  // 自社名称2
            table.Columns.Add(new DataColumn("COMPANYNMRF.POSTNORF", typeof(string)));  // 郵便番号
            table.Columns.Add(new DataColumn("COMPANYNMRF.ADDRESS1RF", typeof(string)));  // 住所1（都道府県市区郡・町村・字）
            table.Columns.Add(new DataColumn("COMPANYNMRF.ADDRESS3RF", typeof(string)));  // 住所3（番地）
            table.Columns.Add(new DataColumn("COMPANYNMRF.ADDRESS4RF", typeof(string)));  // 住所4（アパート名称）
            table.Columns.Add(new DataColumn("COMPANYNMRF.COMPANYTELNO1RF", typeof(string)));  // 自社電話番号1
            table.Columns.Add(new DataColumn("COMPANYNMRF.COMPANYTELNO2RF", typeof(string)));  // 自社電話番号2
            table.Columns.Add(new DataColumn("COMPANYNMRF.COMPANYTELNO3RF", typeof(string)));  // 自社電話番号3
            table.Columns.Add(new DataColumn("COMPANYNMRF.COMPANYTELTITLE1RF", typeof(string)));  // 自社電話番号タイトル1
            table.Columns.Add(new DataColumn("COMPANYNMRF.COMPANYTELTITLE2RF", typeof(string)));  // 自社電話番号タイトル2
            table.Columns.Add(new DataColumn("COMPANYNMRF.COMPANYTELTITLE3RF", typeof(string)));  // 自社電話番号タイトル3
            table.Columns.Add(new DataColumn("COMPANYNMRF.TRANSFERGUIDANCERF", typeof(string)));  // 銀行振込案内文
            table.Columns.Add(new DataColumn("COMPANYNMRF.ACCOUNTNOINFO1RF", typeof(string)));  // 銀行口座1
            table.Columns.Add(new DataColumn("COMPANYNMRF.ACCOUNTNOINFO2RF", typeof(string)));  // 銀行口座2
            table.Columns.Add(new DataColumn("COMPANYNMRF.ACCOUNTNOINFO3RF", typeof(string)));  // 銀行口座3
            table.Columns.Add(new DataColumn("COMPANYNMRF.COMPANYSETNOTE1RF", typeof(string)));  // 自社設定摘要1
            table.Columns.Add(new DataColumn("COMPANYNMRF.COMPANYSETNOTE2RF", typeof(string)));  // 自社設定摘要2
            table.Columns.Add(new DataColumn("COMPANYNMRF.IMAGEINFODIVRF", typeof(Int32)));  // 画像情報区分
            table.Columns.Add(new DataColumn("COMPANYNMRF.IMAGEINFOCODERF", typeof(Int32)));  // 画像情報コード
            table.Columns.Add(new DataColumn("COMPANYNMRF.COMPANYURLRF", typeof(string)));  // 自社URL
            table.Columns.Add(new DataColumn("COMPANYNMRF.COMPANYPRSENTENCE2RF", typeof(string)));  // 自社PR文2
            table.Columns.Add(new DataColumn("COMPANYNMRF.IMAGECOMMENTFORPRT1RF", typeof(string)));  // 画像印字用コメント1
            table.Columns.Add(new DataColumn("COMPANYNMRF.IMAGECOMMENTFORPRT2RF", typeof(string)));  // 画像印字用コメント2
            table.Columns.Add(new DataColumn("IMAGEINFORF.IMAGEINFODATARF", typeof(Byte[])));  // 自社画像
            table.Columns.Add(new DataColumn("SUBSECTIONRF.SUBSECTIONNAMERF", typeof(string)));  // 部門名称
            table.Columns.Add(new DataColumn("EMPINP.KANARF", typeof(string)));  // 売上入力者カナ
            table.Columns.Add(new DataColumn("EMPINP.SHORTNAMERF", typeof(string)));  // 売上入力者短縮名称
            table.Columns.Add(new DataColumn("EMPFRT.KANARF", typeof(string)));  // 受付従業員カナ
            table.Columns.Add(new DataColumn("EMPFRT.SHORTNAMERF", typeof(string)));  // 受付従業員短縮名称
            table.Columns.Add(new DataColumn("EMPSAL.KANARF", typeof(string)));  // 販売従業員カナ
            table.Columns.Add(new DataColumn("EMPSAL.SHORTNAMERF", typeof(string)));  // 販売従業員短縮名称
            table.Columns.Add(new DataColumn("CSTCLM.CUSTOMERSUBCODERF", typeof(string)));  // 請求先サブコード
            table.Columns.Add(new DataColumn("CSTCLM.NAMERF", typeof(string)));  // 請求先名称
            table.Columns.Add(new DataColumn("CSTCLM.NAME2RF", typeof(string)));  // 請求先名称2
            table.Columns.Add(new DataColumn("CSTCLM.HONORIFICTITLERF", typeof(string)));  // 請求先敬称
            table.Columns.Add(new DataColumn("CSTCLM.KANARF", typeof(string)));  // 請求先カナ
            table.Columns.Add(new DataColumn("CSTCLM.CUSTOMERSNMRF", typeof(string)));  // 請求先略称
            table.Columns.Add(new DataColumn("CSTCLM.OUTPUTNAMECODERF", typeof(Int32)));  // 請求先諸口コード
            table.Columns.Add(new DataColumn("CSTCLM.CUSTANALYSCODE1RF", typeof(Int32)));  // 請求先分析コード1
            table.Columns.Add(new DataColumn("CSTCLM.CUSTANALYSCODE2RF", typeof(Int32)));  // 請求先分析コード2
            table.Columns.Add(new DataColumn("CSTCLM.CUSTANALYSCODE3RF", typeof(Int32)));  // 請求先分析コード3
            table.Columns.Add(new DataColumn("CSTCLM.CUSTANALYSCODE4RF", typeof(Int32)));  // 請求先分析コード4
            table.Columns.Add(new DataColumn("CSTCLM.CUSTANALYSCODE5RF", typeof(Int32)));  // 請求先分析コード5
            table.Columns.Add(new DataColumn("CSTCLM.CUSTANALYSCODE6RF", typeof(Int32)));  // 請求先分析コード6
            table.Columns.Add(new DataColumn("CSTCLM.NOTE1RF", typeof(string)));  // 請求先備考1
            table.Columns.Add(new DataColumn("CSTCLM.NOTE2RF", typeof(string)));  // 請求先備考2
            table.Columns.Add(new DataColumn("CSTCLM.NOTE3RF", typeof(string)));  // 請求先備考3
            table.Columns.Add(new DataColumn("CSTCLM.NOTE4RF", typeof(string)));  // 請求先備考4
            table.Columns.Add(new DataColumn("CSTCLM.NOTE5RF", typeof(string)));  // 請求先備考5
            table.Columns.Add(new DataColumn("CSTCLM.NOTE6RF", typeof(string)));  // 請求先備考6
            table.Columns.Add(new DataColumn("CSTCLM.NOTE7RF", typeof(string)));  // 請求先備考7
            table.Columns.Add(new DataColumn("CSTCLM.NOTE8RF", typeof(string)));  // 請求先備考8
            table.Columns.Add(new DataColumn("CSTCLM.NOTE9RF", typeof(string)));  // 請求先備考9
            table.Columns.Add(new DataColumn("CSTCLM.NOTE10RF", typeof(string)));  // 請求先備考10
            table.Columns.Add(new DataColumn("CSTCST.CUSTOMERSUBCODERF", typeof(string)));  // 得意先サブコード
            table.Columns.Add(new DataColumn("CSTCST.NAMERF", typeof(string)));  // 得意先名称
            table.Columns.Add(new DataColumn("CSTCST.NAME2RF", typeof(string)));  // 得意先名称2
            table.Columns.Add(new DataColumn("CSTCST.HONORIFICTITLERF", typeof(string)));  // 得意先敬称
            table.Columns.Add(new DataColumn("CSTCST.KANARF", typeof(string)));  // 得意先カナ
            table.Columns.Add(new DataColumn("CSTCST.CUSTOMERSNMRF", typeof(string)));  // 得意先略称
            table.Columns.Add(new DataColumn("CSTCST.OUTPUTNAMECODERF", typeof(Int32)));  // 得意先諸口コード
            table.Columns.Add(new DataColumn("CSTCST.CUSTANALYSCODE1RF", typeof(Int32)));  // 得意先分析コード1
            table.Columns.Add(new DataColumn("CSTCST.CUSTANALYSCODE2RF", typeof(Int32)));  // 得意先分析コード2
            table.Columns.Add(new DataColumn("CSTCST.CUSTANALYSCODE3RF", typeof(Int32)));  // 得意先分析コード3
            table.Columns.Add(new DataColumn("CSTCST.CUSTANALYSCODE4RF", typeof(Int32)));  // 得意先分析コード4
            table.Columns.Add(new DataColumn("CSTCST.CUSTANALYSCODE5RF", typeof(Int32)));  // 得意先分析コード5
            table.Columns.Add(new DataColumn("CSTCST.CUSTANALYSCODE6RF", typeof(Int32)));  // 得意先分析コード6
            table.Columns.Add(new DataColumn("CSTCST.NOTE1RF", typeof(string)));  // 得意先備考1
            table.Columns.Add(new DataColumn("CSTCST.NOTE2RF", typeof(string)));  // 得意先備考2
            table.Columns.Add(new DataColumn("CSTCST.NOTE3RF", typeof(string)));  // 得意先備考3
            table.Columns.Add(new DataColumn("CSTCST.NOTE4RF", typeof(string)));  // 得意先備考4
            table.Columns.Add(new DataColumn("CSTCST.NOTE5RF", typeof(string)));  // 得意先備考5
            table.Columns.Add(new DataColumn("CSTCST.NOTE6RF", typeof(string)));  // 得意先備考6
            table.Columns.Add(new DataColumn("CSTCST.NOTE7RF", typeof(string)));  // 得意先備考7
            table.Columns.Add(new DataColumn("CSTCST.NOTE8RF", typeof(string)));  // 得意先備考8
            table.Columns.Add(new DataColumn("CSTCST.NOTE9RF", typeof(string)));  // 得意先備考9
            table.Columns.Add(new DataColumn("CSTCST.NOTE10RF", typeof(string)));  // 得意先備考10
            table.Columns.Add(new DataColumn("CSTADR.CUSTOMERSUBCODERF", typeof(string)));  // 納入先サブコード
            table.Columns.Add(new DataColumn("CSTADR.NAMERF", typeof(string)));  // 納入先名称
            table.Columns.Add(new DataColumn("CSTADR.NAME2RF", typeof(string)));  // 納入先名称2
            table.Columns.Add(new DataColumn("CSTADR.HONORIFICTITLERF", typeof(string)));  // 納入先敬称
            table.Columns.Add(new DataColumn("CSTADR.KANARF", typeof(string)));  // 納入先カナ
            table.Columns.Add(new DataColumn("CSTADR.CUSTOMERSNMRF", typeof(string)));  // 納入先略称
            table.Columns.Add(new DataColumn("CSTADR.OUTPUTNAMECODERF", typeof(Int32)));  // 納入先諸口コード
            table.Columns.Add(new DataColumn("CSTADR.CUSTANALYSCODE1RF", typeof(Int32)));  // 納入先分析コード1
            table.Columns.Add(new DataColumn("CSTADR.CUSTANALYSCODE2RF", typeof(Int32)));  // 納入先分析コード2
            table.Columns.Add(new DataColumn("CSTADR.CUSTANALYSCODE3RF", typeof(Int32)));  // 納入先分析コード3
            table.Columns.Add(new DataColumn("CSTADR.CUSTANALYSCODE4RF", typeof(Int32)));  // 納入先分析コード4
            table.Columns.Add(new DataColumn("CSTADR.CUSTANALYSCODE5RF", typeof(Int32)));  // 納入先分析コード5
            table.Columns.Add(new DataColumn("CSTADR.CUSTANALYSCODE6RF", typeof(Int32)));  // 納入先分析コード6
            table.Columns.Add(new DataColumn("CSTADR.NOTE1RF", typeof(string)));  // 納入先備考1
            table.Columns.Add(new DataColumn("CSTADR.NOTE2RF", typeof(string)));  // 納入先備考2
            table.Columns.Add(new DataColumn("CSTADR.NOTE3RF", typeof(string)));  // 納入先備考3
            table.Columns.Add(new DataColumn("CSTADR.NOTE4RF", typeof(string)));  // 納入先備考4
            table.Columns.Add(new DataColumn("CSTADR.NOTE5RF", typeof(string)));  // 納入先備考5
            table.Columns.Add(new DataColumn("CSTADR.NOTE6RF", typeof(string)));  // 納入先備考6
            table.Columns.Add(new DataColumn("CSTADR.NOTE7RF", typeof(string)));  // 納入先備考7
            table.Columns.Add(new DataColumn("CSTADR.NOTE8RF", typeof(string)));  // 納入先備考8
            table.Columns.Add(new DataColumn("CSTADR.NOTE9RF", typeof(string)));  // 納入先備考9
            table.Columns.Add(new DataColumn("CSTADR.NOTE10RF", typeof(string)));  // 納入先備考10
            table.Columns.Add(new DataColumn("COMPANYINFRF.COMPANYNAME1RF", typeof(string)));  // 自社名称1
            table.Columns.Add(new DataColumn("COMPANYINFRF.COMPANYNAME2RF", typeof(string)));  // 自社名称2
            table.Columns.Add(new DataColumn("COMPANYINFRF.POSTNORF", typeof(string)));  // 郵便番号
            table.Columns.Add(new DataColumn("COMPANYINFRF.ADDRESS1RF", typeof(string)));  // 住所1（都道府県市区郡・町村・字）
            table.Columns.Add(new DataColumn("COMPANYINFRF.ADDRESS3RF", typeof(string)));  // 住所3（番地）
            table.Columns.Add(new DataColumn("COMPANYINFRF.ADDRESS4RF", typeof(string)));  // 住所4（アパート名称）
            table.Columns.Add(new DataColumn("COMPANYINFRF.COMPANYTELNO1RF", typeof(string)));  // 自社電話番号1
            table.Columns.Add(new DataColumn("COMPANYINFRF.COMPANYTELNO2RF", typeof(string)));  // 自社電話番号2
            table.Columns.Add(new DataColumn("COMPANYINFRF.COMPANYTELNO3RF", typeof(string)));  // 自社電話番号3
            table.Columns.Add(new DataColumn("COMPANYINFRF.COMPANYTELTITLE1RF", typeof(string)));  // 自社電話番号タイトル1
            table.Columns.Add(new DataColumn("COMPANYINFRF.COMPANYTELTITLE2RF", typeof(string)));  // 自社電話番号タイトル2
            table.Columns.Add(new DataColumn("COMPANYINFRF.COMPANYTELTITLE3RF", typeof(string)));  // 自社電話番号タイトル3
            table.Columns.Add(new DataColumn("HADD.ACPTANODRSTNMRF", typeof(string)));  // 受注ステータス名称
            table.Columns.Add(new DataColumn("HADD.DEBITNOTEDIVNMRF", typeof(string)));  // 赤伝区分名称
            table.Columns.Add(new DataColumn("HADD.SALESSLIPNMRF", typeof(string)));  // ＵＯＥ伝票区分名称
            table.Columns.Add(new DataColumn("HADD.SALESGOODSNMRF", typeof(string)));  // 売上商品区分名称
            table.Columns.Add(new DataColumn("HADD.ACCRECDIVNMRF", typeof(string)));  // 売掛区分名称
            table.Columns.Add(new DataColumn("HADD.DELAYPAYMENTDIVNMRF", typeof(string)));  // 来勘区分名称
            table.Columns.Add(new DataColumn("HADD.ESTIMATEDIVIDENMRF", typeof(string)));  // 見積区分名称
            table.Columns.Add(new DataColumn("HADD.CONSTAXLAYMETHODNMRF", typeof(string)));  // 消費税転嫁方式名称
            table.Columns.Add(new DataColumn("HADD.AUTODEPOSITNMRF", typeof(string)));  // 自動入金区分名称
            table.Columns.Add(new DataColumn("HADD.SLIPPRINTFINISHNMRF", typeof(string)));  // 伝票発行済区分名称
            table.Columns.Add(new DataColumn("HADD.COMPLETENMRF", typeof(string)));  // 一式伝票区分名称
            table.Columns.Add(new DataColumn("HADD.CARMNGNORF", typeof(Int32)));  // (先頭)車両管理番号
            table.Columns.Add(new DataColumn("HADD.CARMNGCODERF", typeof(string)));  // (先頭)車輌管理コード
            table.Columns.Add(new DataColumn("HADD.NUMBERPLATE1CODERF", typeof(Int32)));  // (先頭)陸運事務所番号
            table.Columns.Add(new DataColumn("HADD.NUMBERPLATE1NAMERF", typeof(string)));  // (先頭)陸運事務局名称
            table.Columns.Add(new DataColumn("HADD.NUMBERPLATE2RF", typeof(string)));  // (先頭)車両登録番号（種別）
            table.Columns.Add(new DataColumn("HADD.NUMBERPLATE3RF", typeof(string)));  // (先頭)車両登録番号（カナ）
            table.Columns.Add(new DataColumn("HADD.NUMBERPLATE4RF", typeof(Int32)));  // (先頭)車両登録番号（プレート番号）
            table.Columns.Add(new DataColumn("HADD.FIRSTENTRYDATERF", typeof(Int32)));  // (先頭)初年度
            table.Columns.Add(new DataColumn("HADD.MAKERCODERF", typeof(Int32)));  // (先頭)メーカーコード
            table.Columns.Add(new DataColumn("HADD.MAKERFULLNAMERF", typeof(string)));  // (先頭)メーカー全角名称
            table.Columns.Add(new DataColumn("HADD.MODELCODERF", typeof(Int32)));  // (先頭)車種コード
            table.Columns.Add(new DataColumn("HADD.MODELSUBCODERF", typeof(Int32)));  // (先頭)車種サブコード
            table.Columns.Add(new DataColumn("HADD.MODELFULLNAMERF", typeof(string)));  // (先頭)車種全角名称
            table.Columns.Add(new DataColumn("HADD.EXHAUSTGASSIGNRF", typeof(string)));  // (先頭)排ガス記号
            table.Columns.Add(new DataColumn("HADD.SERIESMODELRF", typeof(string)));  // (先頭)シリーズ型式
            table.Columns.Add(new DataColumn("HADD.CATEGORYSIGNMODELRF", typeof(string)));  // (先頭)型式（類別記号）
            table.Columns.Add(new DataColumn("HADD.FULLMODELRF", typeof(string)));  // (先頭)型式（フル型）
            table.Columns.Add(new DataColumn("HADD.MODELDESIGNATIONNORF", typeof(Int32)));  // (先頭)型式指定番号
            table.Columns.Add(new DataColumn("HADD.CATEGORYNORF", typeof(Int32)));  // (先頭)類別番号
            table.Columns.Add(new DataColumn("HADD.FRAMEMODELRF", typeof(string)));  // (先頭)車台型式
            table.Columns.Add(new DataColumn("HADD.FRAMENORF", typeof(string)));  // (先頭)車台番号
            table.Columns.Add(new DataColumn("HADD.SEARCHFRAMENORF", typeof(Int32)));  // (先頭)車台番号（検索用）
            table.Columns.Add(new DataColumn("HADD.ENGINEMODELNMRF", typeof(string)));  // (先頭)エンジン型式名称
            table.Columns.Add(new DataColumn("HADD.RELEVANCEMODELRF", typeof(string)));  // (先頭)関連型式
            table.Columns.Add(new DataColumn("HADD.SUBCARNMCDRF", typeof(Int32)));  // (先頭)サブ車名コード
            table.Columns.Add(new DataColumn("HADD.MODELGRADESNAMERF", typeof(string)));  // (先頭)型式グレード略称
            table.Columns.Add(new DataColumn("HADD.COLORCODERF", typeof(string)));  // (先頭)カラーコード
            table.Columns.Add(new DataColumn("HADD.COLORNAME1RF", typeof(string)));  // (先頭)カラー名称1
            table.Columns.Add(new DataColumn("HADD.TRIMCODERF", typeof(string)));  // (先頭)トリムコード
            table.Columns.Add(new DataColumn("HADD.TRIMNAMERF", typeof(string)));  // (先頭)トリム名称
            table.Columns.Add(new DataColumn("HADD.MILEAGERF", typeof(Int32)));  // (先頭)車両走行距離
            table.Columns.Add(new DataColumn("HADD.PRINTERMNGNORF", typeof(Int32)));  // プリンタ管理No
            table.Columns.Add(new DataColumn("HADD.SLIPPRTSETPAPERIDRF", typeof(string)));  // 伝票印刷設定用帳票ID
            table.Columns.Add(new DataColumn("HADD.NOTE1RF", typeof(string)));  // 自社備考１
            table.Columns.Add(new DataColumn("HADD.NOTE2RF", typeof(string)));  // 自社備考２
            table.Columns.Add(new DataColumn("HADD.NOTE3RF", typeof(string)));  // 自社備考３
            table.Columns.Add(new DataColumn("HADD.REISSUEMARKRF", typeof(string)));  // 再発行マーク
            table.Columns.Add(new DataColumn("HADD.REFCONSTAXPRTNMRF", typeof(string)));  // 参考消費税印字名称
            table.Columns.Add(new DataColumn("HADD.PRINTTIMEHOURRF", typeof(Int32))); // 印刷時刻 時
            table.Columns.Add(new DataColumn("HADD.PRINTTIMEMINUTERF", typeof(Int32))); // 印刷時刻 分
            table.Columns.Add(new DataColumn("HADD.PRINTTIMESECONDRF", typeof(Int32))); // 印刷時刻 秒
            table.Columns.Add(new DataColumn("HADD.SEARCHSLIPDATEFYRF", typeof(Int32))); // 伝票検索日付西暦年
            table.Columns.Add(new DataColumn("HADD.SEARCHSLIPDATEFSRF", typeof(Int32))); // 伝票検索日付西暦年略
            table.Columns.Add(new DataColumn("HADD.SEARCHSLIPDATEFWRF", typeof(Int32))); // 伝票検索日付和暦年
            table.Columns.Add(new DataColumn("HADD.SEARCHSLIPDATEFMRF", typeof(Int32))); // 伝票検索日付月
            table.Columns.Add(new DataColumn("HADD.SEARCHSLIPDATEFDRF", typeof(Int32))); // 伝票検索日付日
            table.Columns.Add(new DataColumn("HADD.SEARCHSLIPDATEFGRF", typeof(String))); // 伝票検索日付元号
            table.Columns.Add(new DataColumn("HADD.SEARCHSLIPDATEFRRF", typeof(String))); // 伝票検索日付略号
            table.Columns.Add(new DataColumn("HADD.SEARCHSLIPDATEFLSRF", typeof(String))); // 伝票検索日付リテラル(/)
            table.Columns.Add(new DataColumn("HADD.SEARCHSLIPDATEFLPRF", typeof(String))); // 伝票検索日付リテラル(.)
            table.Columns.Add(new DataColumn("HADD.SEARCHSLIPDATEFLYRF", typeof(String))); // 伝票検索日付リテラル(年)
            table.Columns.Add(new DataColumn("HADD.SEARCHSLIPDATEFLMRF", typeof(String))); // 伝票検索日付リテラル(月)
            table.Columns.Add(new DataColumn("HADD.SEARCHSLIPDATEFLDRF", typeof(String))); // 伝票検索日付リテラル(日)
            table.Columns.Add(new DataColumn("HADD.SHIPMENTDAYFYRF", typeof(Int32))); // 出荷日付西暦年
            table.Columns.Add(new DataColumn("HADD.SHIPMENTDAYFSRF", typeof(Int32))); // 出荷日付西暦年略
            table.Columns.Add(new DataColumn("HADD.SHIPMENTDAYFWRF", typeof(Int32))); // 出荷日付和暦年
            table.Columns.Add(new DataColumn("HADD.SHIPMENTDAYFMRF", typeof(Int32))); // 出荷日付月
            table.Columns.Add(new DataColumn("HADD.SHIPMENTDAYFDRF", typeof(Int32))); // 出荷日付日
            table.Columns.Add(new DataColumn("HADD.SHIPMENTDAYFGRF", typeof(String))); // 出荷日付元号
            table.Columns.Add(new DataColumn("HADD.SHIPMENTDAYFRRF", typeof(String))); // 出荷日付略号
            table.Columns.Add(new DataColumn("HADD.SHIPMENTDAYFLSRF", typeof(String))); // 出荷日付リテラル(/)
            table.Columns.Add(new DataColumn("HADD.SHIPMENTDAYFLPRF", typeof(String))); // 出荷日付リテラル(.)
            table.Columns.Add(new DataColumn("HADD.SHIPMENTDAYFLYRF", typeof(String))); // 出荷日付リテラル(年)
            table.Columns.Add(new DataColumn("HADD.SHIPMENTDAYFLMRF", typeof(String))); // 出荷日付リテラル(月)
            table.Columns.Add(new DataColumn("HADD.SHIPMENTDAYFLDRF", typeof(String))); // 出荷日付リテラル(日)
            table.Columns.Add(new DataColumn("HADD.SALESDATEFYRF", typeof(Int32))); // 売上日付西暦年
            table.Columns.Add(new DataColumn("HADD.SALESDATEFSRF", typeof(Int32))); // 売上日付西暦年略
            table.Columns.Add(new DataColumn("HADD.SALESDATEFWRF", typeof(Int32))); // 売上日付和暦年
            table.Columns.Add(new DataColumn("HADD.SALESDATEFMRF", typeof(Int32))); // 売上日付月
            table.Columns.Add(new DataColumn("HADD.SALESDATEFDRF", typeof(Int32))); // 売上日付日
            table.Columns.Add(new DataColumn("HADD.SALESDATEFGRF", typeof(String))); // 売上日付元号
            table.Columns.Add(new DataColumn("HADD.SALESDATEFRRF", typeof(String))); // 売上日付略号
            table.Columns.Add(new DataColumn("HADD.SALESDATEFLSRF", typeof(String))); // 売上日付リテラル(/)
            table.Columns.Add(new DataColumn("HADD.SALESDATEFLPRF", typeof(String))); // 売上日付リテラル(.)
            table.Columns.Add(new DataColumn("HADD.SALESDATEFLYRF", typeof(String))); // 売上日付リテラル(年)
            table.Columns.Add(new DataColumn("HADD.SALESDATEFLMRF", typeof(String))); // 売上日付リテラル(月)
            table.Columns.Add(new DataColumn("HADD.SALESDATEFLDRF", typeof(String))); // 売上日付リテラル(日)
            table.Columns.Add(new DataColumn("HADD.ADDUPADATEFYRF", typeof(Int32))); // 計上日付西暦年
            table.Columns.Add(new DataColumn("HADD.ADDUPADATEFSRF", typeof(Int32))); // 計上日付西暦年略
            table.Columns.Add(new DataColumn("HADD.ADDUPADATEFWRF", typeof(Int32))); // 計上日付和暦年
            table.Columns.Add(new DataColumn("HADD.ADDUPADATEFMRF", typeof(Int32))); // 計上日付月
            table.Columns.Add(new DataColumn("HADD.ADDUPADATEFDRF", typeof(Int32))); // 計上日付日
            table.Columns.Add(new DataColumn("HADD.ADDUPADATEFGRF", typeof(String))); // 計上日付元号
            table.Columns.Add(new DataColumn("HADD.ADDUPADATEFRRF", typeof(String))); // 計上日付略号
            table.Columns.Add(new DataColumn("HADD.ADDUPADATEFLSRF", typeof(String))); // 計上日付リテラル(/)
            table.Columns.Add(new DataColumn("HADD.ADDUPADATEFLPRF", typeof(String))); // 計上日付リテラル(.)
            table.Columns.Add(new DataColumn("HADD.ADDUPADATEFLYRF", typeof(String))); // 計上日付リテラル(年)
            table.Columns.Add(new DataColumn("HADD.ADDUPADATEFLMRF", typeof(String))); // 計上日付リテラル(月)
            table.Columns.Add(new DataColumn("HADD.ADDUPADATEFLDRF", typeof(String))); // 計上日付リテラル(日)
            table.Columns.Add(new DataColumn("HADD.SALESSLIPPRINTDATEFYRF", typeof(Int32))); // ＵＯＥ伝票発行日西暦年
            table.Columns.Add(new DataColumn("HADD.SALESSLIPPRINTDATEFSRF", typeof(Int32))); // ＵＯＥ伝票発行日西暦年略
            table.Columns.Add(new DataColumn("HADD.SALESSLIPPRINTDATEFWRF", typeof(Int32))); // ＵＯＥ伝票発行日和暦年
            table.Columns.Add(new DataColumn("HADD.SALESSLIPPRINTDATEFMRF", typeof(Int32))); // ＵＯＥ伝票発行日月
            table.Columns.Add(new DataColumn("HADD.SALESSLIPPRINTDATEFDRF", typeof(Int32))); // ＵＯＥ伝票発行日日
            table.Columns.Add(new DataColumn("HADD.SALESSLIPPRINTDATEFGRF", typeof(String))); // ＵＯＥ伝票発行日元号
            table.Columns.Add(new DataColumn("HADD.SALESSLIPPRINTDATEFRRF", typeof(String))); // ＵＯＥ伝票発行日略号
            table.Columns.Add(new DataColumn("HADD.SALESSLIPPRINTDATEFLSRF", typeof(String))); // ＵＯＥ伝票発行日リテラル(/)
            table.Columns.Add(new DataColumn("HADD.SALESSLIPPRINTDATEFLPRF", typeof(String))); // ＵＯＥ伝票発行日リテラル(.)
            table.Columns.Add(new DataColumn("HADD.SALESSLIPPRINTDATEFLYRF", typeof(String))); // ＵＯＥ伝票発行日リテラル(年)
            table.Columns.Add(new DataColumn("HADD.SALESSLIPPRINTDATEFLMRF", typeof(String))); // ＵＯＥ伝票発行日リテラル(月)
            table.Columns.Add(new DataColumn("HADD.SALESSLIPPRINTDATEFLDRF", typeof(String))); // ＵＯＥ伝票発行日リテラル(日)
            table.Columns.Add(new DataColumn("HADD.FIRSTENTRYDATEFYRF", typeof(Int32))); // (先頭)初年度西暦年
            table.Columns.Add(new DataColumn("HADD.FIRSTENTRYDATEFSRF", typeof(Int32))); // (先頭)初年度西暦年略
            table.Columns.Add(new DataColumn("HADD.FIRSTENTRYDATEFWRF", typeof(Int32))); // (先頭)初年度和暦年
            table.Columns.Add(new DataColumn("HADD.FIRSTENTRYDATEFMRF", typeof(Int32))); // (先頭)初年度月
            table.Columns.Add(new DataColumn("HADD.FIRSTENTRYDATEFDRF", typeof(Int32))); // (先頭)初年度日
            table.Columns.Add(new DataColumn("HADD.FIRSTENTRYDATEFGRF", typeof(String))); // (先頭)初年度元号
            table.Columns.Add(new DataColumn("HADD.FIRSTENTRYDATEFRRF", typeof(String))); // (先頭)初年度略号
            table.Columns.Add(new DataColumn("HADD.FIRSTENTRYDATEFLSRF", typeof(String))); // (先頭)初年度リテラル(/)
            table.Columns.Add(new DataColumn("HADD.FIRSTENTRYDATEFLPRF", typeof(String))); // (先頭)初年度リテラル(.)
            table.Columns.Add(new DataColumn("HADD.FIRSTENTRYDATEFLYRF", typeof(String))); // (先頭)初年度リテラル(年)
            table.Columns.Add(new DataColumn("HADD.FIRSTENTRYDATEFLMRF", typeof(String))); // (先頭)初年度リテラル(月)
            table.Columns.Add(new DataColumn("HADD.FIRSTENTRYDATEFLDRF", typeof(String))); // (先頭)初年度リテラル(日)
            table.Columns.Add(new DataColumn("HADD.PRINTCUSTOMERNAME1RF", typeof(String))); // 印刷用得意先名称（上段）
            table.Columns.Add(new DataColumn("HADD.PRINTCUSTOMERNAME2RF", typeof(String))); // 印刷用得意先名称（下段）
            table.Columns.Add(new DataColumn("HADD.PRINTCUSTOMERNAME2HNRF", typeof(String))); // 印刷用得意先名称（下段）＋敬称
            table.Columns.Add(new DataColumn("HADD.MAKERHALFNAMERF", typeof(String))); // (先頭)メーカー半角名称
            table.Columns.Add(new DataColumn("HADD.MODELHALFNAMERF", typeof(String))); // (先頭)車種半角名称
            table.Columns.Add(new DataColumn("SALESSLIPRF.SLIPNOTE3RF", typeof(String))); // 伝票備考３
            table.Columns.Add(new DataColumn("HADD.PRINTCUSTOMERNAMEJOIN12RF", typeof(String))); //得意先名１＋得意先名２
            table.Columns.Add(new DataColumn("HADD.PRINTCUSTOMERNAMEJOIN12HNRF", typeof(String))); // 得意先名１＋得意先名２＋敬称
            table.Columns.Add(new DataColumn("HADD.PRINTENTERPRISENAME1FHRF", typeof(String))); // 自社名１（前半）
            table.Columns.Add(new DataColumn("HADD.PRINTENTERPRISENAME1LHRF", typeof(String))); // 自社名１（後半）
            table.Columns.Add(new DataColumn("HADD.PRINTENTERPRISENAME2FHRF", typeof(String))); // 自社名２（前半）
            table.Columns.Add(new DataColumn("HADD.PRINTENTERPRISENAME2LHRF", typeof(String))); // 自社名２（後半）
            table.Columns.Add(new DataColumn("SALESSLIPRF.RESULTSADDUPSECCDRF", typeof(String))); // 実績計上拠点コード
            // --- ADD 2009.07.24 劉洋 ------ >>>>>>
            table.Columns.Add(new DataColumn("SANDESETTINGRF.SANDEMNGCODERF", typeof(String))); // AB住電管理コード
            table.Columns.Add(new DataColumn("SANDESETTINGRF.DELIVERERNMRF", typeof(String))); // AB納品者名
            table.Columns.Add(new DataColumn("SANDESETTINGRF.DELIVERERADDRESSRF", typeof(String))); // AB納品者住所
            table.Columns.Add(new DataColumn("SANDESETTINGRF.DELIVERERPHONENUMRF", typeof(String))); // AB納品者TEL
            table.Columns.Add(new DataColumn("SANDESETTINGRF.ADDRESSEESHOPCDRF", typeof(String))); // AB納品先店舗コード
            table.Columns.Add(new DataColumn("SANDESETTINGRF.EXPENSEDIVCDRF", typeof(Int32))); // AB経費区分
            table.Columns.Add(new DataColumn("SANDESETTINGRF.DIRECTSENDINGCDRF", typeof(Int32))); // AB直送区分
            table.Columns.Add(new DataColumn("HADD.ABILLCODERF", typeof(String))); // AB請求区分
            table.Columns.Add(new DataColumn("SANDESETTINGRF.ACPTANORDERDIVRF", typeof(Int32))); // AB受注区分
            table.Columns.Add(new DataColumn("SANDESETTINGRF.DELIVERERCDRF", typeof(String))); // AB納品者コード
            table.Columns.Add(new DataColumn("SANDESETTINGRF.TRADCOMPNAMERF", typeof(String))); // AB部品商名
            table.Columns.Add(new DataColumn("HADD.ABTRADCOMPCDRF", typeof(String))); // AB部品商コード
            table.Columns.Add(new DataColumn("SANDESETTINGRF.TRADCOMPSECTNAMERF", typeof(String))); // AB部品商拠点名
            table.Columns.Add(new DataColumn("HADD.ABSLIPNOTE1RF", typeof(String))); // AB伝票備考１
            table.Columns.Add(new DataColumn("HADD.ABSLIPNOTE2RF", typeof(String))); // AB伝票備考２
            table.Columns.Add(new DataColumn("HADD.ABMODELDESIGNATIONNORF", typeof(String))); // (先頭)AB型式指定番号
            table.Columns.Add(new DataColumn("HPRT.ABCATEGORYHYPRF", typeof(String))); // (先頭)AB類別型式ハイフン
            table.Columns.Add(new DataColumn("HADD.ABCATEGORYNORF", typeof(String))); // (先頭)AB類別番号
            table.Columns.Add(new DataColumn("HADD.ABFULLMODELRF", typeof(String))); // (先頭)AB型式（フル型）
            table.Columns.Add(new DataColumn("HADD.ABFIRSTENTRYDATEFYRF", typeof(String))); // (先頭)AB初年度西暦年
            table.Columns.Add(new DataColumn("HADD.ABFIRSTENTRYDATEFSRF", typeof(String))); // (先頭)AB初年度西暦年略
            table.Columns.Add(new DataColumn("HADD.ABFIRSTENTRYDATEFWRF", typeof(String))); // (先頭)AB初年度和暦年
            table.Columns.Add(new DataColumn("HADD.ABFIRSTENTRYDATEFMRF", typeof(String))); // (先頭)AB初年度月
            table.Columns.Add(new DataColumn("HADD.ABFIRSTENTRYDATEFGRF", typeof(String))); // (先頭)AB初年度元号
            table.Columns.Add(new DataColumn("HADD.ABFIRSTENTRYDATEFRRF", typeof(String))); // (先頭)AB初年度略号
            table.Columns.Add(new DataColumn("HADD.ABFIRSTENTRYDATEFLSRF", typeof(String))); // (先頭)AB初年度リテラル(/)
            table.Columns.Add(new DataColumn("HADD.ABFIRSTENTRYDATEFLPRF", typeof(String))); // (先頭)AB初年度リテラル(.)
            table.Columns.Add(new DataColumn("HADD.ABFIRSTENTRYDATEFLYRF", typeof(String))); // (先頭)AB初年度リテラル(年)
            table.Columns.Add(new DataColumn("HADD.ABFIRSTENTRYDATEFLMRF", typeof(String))); // (先頭)AB初年度リテラル(月)
            table.Columns.Add(new DataColumn("HADD.ABFRAMENORF", typeof(String))); // (先頭)AB車台番号
            table.Columns.Add(new DataColumn("HADD.ABMODELHALFNAMERF", typeof(String))); // (先頭)AB車種半角名称
            table.Columns.Add(new DataColumn("HADD.SALESTOTALTAXEXCNOMINUSRF", typeof(Double))); // 売上伝票合計（税抜き）(マイナス符号なし)
            table.Columns.Add(new DataColumn("HADD.LISTPRICEMONEYTOTALTAXEXCRF", typeof(Double))); // 定価金額合計(税抜)
            table.Columns.Add(new DataColumn("HADD.ABHQTOTALCOSTNOMINUSRF", typeof(Double))); // AB本部原価金額合計(マイナス符号なし)
            // --- ADD 2009.07.24 劉洋 ------ <<<<<<
            // --- ADD  大矢睦美  2010/05/14 ---------->>>>>
            table.Columns.Add(new DataColumn("HADD.GROSSPROFITRATETTLRF", typeof(String)));//合計粗利率
            table.Columns.Add(new DataColumn("HADD.GROSSPROFITTTLRF", typeof(Int64)));//合計粗利金額
            // --- ADD  大矢睦美  2010/05/14 ----------<<<<<

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
            table.Columns.Add(new DataColumn("SALESDETAILRF.ACPTANODRSTATUSRF", typeof(Int32)));  // 受注ステータス
            table.Columns.Add(new DataColumn("SALESDETAILRF.SALESSLIPNUMRF", typeof(string)));  // ＵＯＥ伝票番号
            table.Columns.Add(new DataColumn("SALESDETAILRF.ACCEPTANORDERNORF", typeof(Int32)));  // 受注番号
            table.Columns.Add(new DataColumn("SALESDETAILRF.SALESROWNORF", typeof(Int32)));  // 売上行番号
            table.Columns.Add(new DataColumn("SALESDETAILRF.SALESDATERF", typeof(Int32)));  // 売上日付
            table.Columns.Add(new DataColumn("SALESDETAILRF.COMMONSEQNORF", typeof(Int64)));  // 共通通番
            table.Columns.Add(new DataColumn("SALESDETAILRF.SALESSLIPDTLNUMRF", typeof(Int64)));  // 売上明細通番
            table.Columns.Add(new DataColumn("SALESDETAILRF.ACPTANODRSTATUSSRCRF", typeof(Int32)));  // 受注ステータス（元）
            table.Columns.Add(new DataColumn("SALESDETAILRF.SALESSLIPDTLNUMSRCRF", typeof(Int64)));  // 売上明細通番（元）
            table.Columns.Add(new DataColumn("SALESDETAILRF.SUPPLIERFORMALSYNCRF", typeof(Int32)));  // 仕入形式（同時）
            table.Columns.Add(new DataColumn("SALESDETAILRF.STOCKSLIPDTLNUMSYNCRF", typeof(Int64)));  // 仕入明細通番（同時）
            table.Columns.Add(new DataColumn("SALESDETAILRF.SALESSLIPCDDTLRF", typeof(Int32)));  // ＵＯＥ伝票区分（明細）
            table.Columns.Add(new DataColumn("SALESDETAILRF.STOCKMNGEXISTCDRF", typeof(Int32)));  // 在庫管理有無区分
            table.Columns.Add(new DataColumn("SALESDETAILRF.DELIGDSCMPLTDUEDATERF", typeof(Int32)));  // 納品完了予定日
            table.Columns.Add(new DataColumn("SALESDETAILRF.GOODSKINDCODERF", typeof(Int32)));  // 商品属性
            table.Columns.Add(new DataColumn("SALESDETAILRF.GOODSMAKERCDRF", typeof(Int32)));  // 商品メーカーコード
            table.Columns.Add(new DataColumn("SALESDETAILRF.MAKERNAMERF", typeof(string)));  // メーカー名称
            table.Columns.Add(new DataColumn("SALESDETAILRF.GOODSNORF", typeof(string)));  // 商品番号
            table.Columns.Add(new DataColumn("SALESDETAILRF.GOODSNAMERF", typeof(string)));  // 商品名称
            table.Columns.Add(new DataColumn("SALESDETAILRF.GOODSSHORTNAMERF", typeof(string)));  // 商品名略称
            table.Columns.Add(new DataColumn("SALESDETAILRF.LARGEGOODSGANRECODERF", typeof(string)));  // 商品区分グループコード
            table.Columns.Add(new DataColumn("SALESDETAILRF.LARGEGOODSGANRENAMERF", typeof(string)));  // 商品区分グループ名称
            table.Columns.Add(new DataColumn("SALESDETAILRF.MEDIUMGOODSGANRECODERF", typeof(string)));  // 商品区分コード
            table.Columns.Add(new DataColumn("SALESDETAILRF.MEDIUMGOODSGANRENAMERF", typeof(string)));  // 商品区分名称
            table.Columns.Add(new DataColumn("SALESDETAILRF.DETAILGOODSGANRECODERF", typeof(string)));  // 商品区分詳細コード
            table.Columns.Add(new DataColumn("SALESDETAILRF.DETAILGOODSGANRENAMERF", typeof(string)));  // 商品区分詳細名称
            table.Columns.Add(new DataColumn("SALESDETAILRF.BLGOODSCODERF", typeof(Int32)));  // BL商品コード
            table.Columns.Add(new DataColumn("SALESDETAILRF.BLGOODSFULLNAMERF", typeof(string)));  // BL商品コード名称（全角）
            table.Columns.Add(new DataColumn("SALESDETAILRF.ENTERPRISEGANRECODERF", typeof(Int32)));  // 自社分類コード
            table.Columns.Add(new DataColumn("SALESDETAILRF.ENTERPRISEGANRENAMERF", typeof(string)));  // 自社分類名称
            table.Columns.Add(new DataColumn("SALESDETAILRF.WAREHOUSECODERF", typeof(string)));  // 倉庫コード
            table.Columns.Add(new DataColumn("SALESDETAILRF.WAREHOUSENAMERF", typeof(string)));  // 倉庫名称
            table.Columns.Add(new DataColumn("SALESDETAILRF.WAREHOUSESHELFNORF", typeof(string)));  // 倉庫棚番
            table.Columns.Add(new DataColumn("SALESDETAILRF.SALESORDERDIVCDRF", typeof(Int32)));  // 売上在庫取寄せ区分
            table.Columns.Add(new DataColumn("SALESDETAILRF.OPENPRICEDIVRF", typeof(Int32)));  // オープン価格区分
            table.Columns.Add(new DataColumn("SALESDETAILRF.UNITCODERF", typeof(Int32)));  // 単位コード
            table.Columns.Add(new DataColumn("SALESDETAILRF.UNITNAMERF", typeof(string)));  // 単位名称
            table.Columns.Add(new DataColumn("SALESDETAILRF.GOODSRATERANKRF", typeof(string)));  // 商品掛率ランク
            table.Columns.Add(new DataColumn("SALESDETAILRF.CUSTRATEGRPCODERF", typeof(Int32)));  // 得意先掛率グループコード
            table.Columns.Add(new DataColumn("SALESDETAILRF.SUPPRATEGRPCODERF", typeof(Int32)));  // 仕入先掛率グループコード
            table.Columns.Add(new DataColumn("SALESDETAILRF.LISTPRICERATERF", typeof(Double)));  // 定価率
            table.Columns.Add(new DataColumn("SALESDETAILRF.LISTPRICETAXINCFLRF", typeof(Double)));  // 定価（税込，浮動）
            table.Columns.Add(new DataColumn("SALESDETAILRF.LISTPRICETAXEXCFLRF", typeof(Double)));  // 定価（税抜，浮動）
            table.Columns.Add(new DataColumn("SALESDETAILRF.LISTPRICECHNGCDRF", typeof(Int32)));  // 定価変更区分
            table.Columns.Add(new DataColumn("SALESDETAILRF.SALESRATERF", typeof(Double)));  // 売価率
            table.Columns.Add(new DataColumn("SALESDETAILRF.SALESUNPRCTAXINCFLRF", typeof(Double)));  // 売上単価（税込，浮動）
            table.Columns.Add(new DataColumn("SALESDETAILRF.SALESUNPRCTAXEXCFLRF", typeof(Double)));  // 売上単価（税抜，浮動）
            table.Columns.Add(new DataColumn("SALESDETAILRF.COSTRATERF", typeof(Double)));  // 原価率
            table.Columns.Add(new DataColumn("SALESDETAILRF.SALESUNITCOSTRF", typeof(Double)));  // 原価単価
            table.Columns.Add(new DataColumn("SALESDETAILRF.SHIPMENTCNTRF", typeof(Double)));  // 出荷数
            table.Columns.Add(new DataColumn("SALESDETAILRF.ACCEPTANORDERCNTRF", typeof(Double)));  // 受注数量
            table.Columns.Add(new DataColumn("SALESDETAILRF.ACPTANODRADJUSTCNTRF", typeof(Double)));  // 受注調整数
            table.Columns.Add(new DataColumn("SALESDETAILRF.ACPTANODRREMAINCNTRF", typeof(Double)));  // 受注残数
            table.Columns.Add(new DataColumn("SALESDETAILRF.REMAINCNTUPDDATERF", typeof(Int32)));  // 残数更新日
            table.Columns.Add(new DataColumn("SALESDETAILRF.SALESMONEYTAXINCRF", typeof(Int64)));  // 売上金額（税込み）
            table.Columns.Add(new DataColumn("SALESDETAILRF.SALESMONEYTAXEXCRF", typeof(Int64)));  // 売上金額（税抜き）
            table.Columns.Add(new DataColumn("SALESDETAILRF.COSTRF", typeof(Int64)));  // 原価
            table.Columns.Add(new DataColumn("SALESDETAILRF.GRSPROFITCHKDIVRF", typeof(Int32)));  // 粗利チェック区分
            table.Columns.Add(new DataColumn("SALESDETAILRF.SALESGOODSCDRF", typeof(Int32)));  // 売上商品区分
            //table.Columns.Add( new DataColumn( "SALESDETAILRF.SALSEPRICECONSTAXRF", typeof( Int64 ) ) );  // 売上金額消費税額
            table.Columns.Add(new DataColumn("SALESDETAILRF.TAXATIONDIVCDRF", typeof(Int32)));  // 課税区分
            table.Columns.Add(new DataColumn("SALESDETAILRF.PARTYSLIPNUMDTLRF", typeof(string)));  // 相手先伝票番号（明細）
            table.Columns.Add(new DataColumn("SALESDETAILRF.DTLNOTERF", typeof(string)));  // 明細備考
            table.Columns.Add(new DataColumn("SALESDETAILRF.SUPPLIERCDRF", typeof(Int32)));  // 仕入先コード
            table.Columns.Add(new DataColumn("SALESDETAILRF.SUPPLIERSNMRF", typeof(string)));  // 仕入先略称
            table.Columns.Add(new DataColumn("SALESDETAILRF.ORDERNUMBERRF", typeof(string)));  // 発注番号
            table.Columns.Add(new DataColumn("SALESDETAILRF.SLIPMEMO1RF", typeof(string)));  // 伝票メモ１
            table.Columns.Add(new DataColumn("SALESDETAILRF.SLIPMEMO2RF", typeof(string)));  // 伝票メモ２
            table.Columns.Add(new DataColumn("SALESDETAILRF.SLIPMEMO3RF", typeof(string)));  // 伝票メモ３
            table.Columns.Add(new DataColumn("SALESDETAILRF.INSIDEMEMO1RF", typeof(string)));  // 社内メモ１
            table.Columns.Add(new DataColumn("SALESDETAILRF.INSIDEMEMO2RF", typeof(string)));  // 社内メモ２
            table.Columns.Add(new DataColumn("SALESDETAILRF.INSIDEMEMO3RF", typeof(string)));  // 社内メモ３
            table.Columns.Add(new DataColumn("SALESDETAILRF.BFLISTPRICERF", typeof(Double)));  // 変更前定価
            table.Columns.Add(new DataColumn("SALESDETAILRF.BFSALESUNITPRICERF", typeof(Double)));  // 変更前売価
            table.Columns.Add(new DataColumn("SALESDETAILRF.BFUNITCOSTRF", typeof(Double)));  // 変更前原価
            table.Columns.Add(new DataColumn("SALESDETAILRF.PRTGOODSNORF", typeof(string)));  // 印刷用商品番号
            table.Columns.Add(new DataColumn("SALESDETAILRF.PRTGOODSNAMERF", typeof(string)));  // 印刷用商品名称
            table.Columns.Add(new DataColumn("SALESDETAILRF.PRTGOODSMAKERCDRF", typeof(Int32)));  // 印刷用商品メーカーコード
            table.Columns.Add(new DataColumn("SALESDETAILRF.PRTGOODSMAKERNMRF", typeof(string)));  // 印刷用商品メーカー名称
            table.Columns.Add(new DataColumn("SALESDETAILRF.CONTRACTDIVCDDTLRF", typeof(Int32)));  // 契約区分（明細）
            table.Columns.Add(new DataColumn("SALESDETAILRF.CMPLTSALESROWNORF", typeof(Int32)));  // 一式明細番号
            table.Columns.Add(new DataColumn("SALESDETAILRF.CMPLTGOODSMAKERCDRF", typeof(Int32)));  // メーカーコード（一式）
            table.Columns.Add(new DataColumn("SALESDETAILRF.CMPLTMAKERNAMERF", typeof(string)));  // メーカー名称（一式）
            table.Columns.Add(new DataColumn("SALESDETAILRF.CMPLTGOODSNAMERF", typeof(string)));  // 商品名称（一式）
            table.Columns.Add(new DataColumn("SALESDETAILRF.CMPLTSHIPMENTCNTRF", typeof(Double)));  // 数量（一式）
            table.Columns.Add(new DataColumn("SALESDETAILRF.CMPLTUNITCODERF", typeof(Int32)));  // 単位コード（一式）
            table.Columns.Add(new DataColumn("SALESDETAILRF.CMPLTUNITNAMERF", typeof(string)));  // 単位名称（一式）
            table.Columns.Add(new DataColumn("SALESDETAILRF.CMPLTSALESUNPRCFLRF", typeof(Double)));  // 売上単価（一式）
            table.Columns.Add(new DataColumn("SALESDETAILRF.CMPLTSALESMONEYRF", typeof(Int64)));  // 売上金額（一式）
            table.Columns.Add(new DataColumn("SALESDETAILRF.CMPLTSALESUNITCOSTRF", typeof(Double)));  // 原価単価（一式）
            table.Columns.Add(new DataColumn("SALESDETAILRF.CMPLTCOSTRF", typeof(Int64)));  // 原価金額（一式）
            table.Columns.Add(new DataColumn("SALESDETAILRF.CMPLTPARTYSALSLNUMRF", typeof(string)));  // 相手先伝票番号（一式）
            table.Columns.Add(new DataColumn("SALESDETAILRF.CMPLTNOTERF", typeof(string)));  // 一式備考
            table.Columns.Add(new DataColumn("ACCEPTODRCARRF.CARMNGNORF", typeof(Int32)));  // 車両管理番号
            table.Columns.Add(new DataColumn("ACCEPTODRCARRF.CARMNGCODERF", typeof(string)));  // 車輌管理コード
            table.Columns.Add(new DataColumn("ACCEPTODRCARRF.NUMBERPLATE1CODERF", typeof(Int32)));  // 陸運事務所番号
            table.Columns.Add(new DataColumn("ACCEPTODRCARRF.NUMBERPLATE1NAMERF", typeof(string)));  // 陸運事務局名称
            table.Columns.Add(new DataColumn("ACCEPTODRCARRF.NUMBERPLATE2RF", typeof(string)));  // 車両登録番号（種別）
            table.Columns.Add(new DataColumn("ACCEPTODRCARRF.NUMBERPLATE3RF", typeof(string)));  // 車両登録番号（カナ）
            table.Columns.Add(new DataColumn("ACCEPTODRCARRF.NUMBERPLATE4RF", typeof(Int32)));  // 車両登録番号（プレート番号）
            table.Columns.Add(new DataColumn("ACCEPTODRCARRF.FIRSTENTRYDATERF", typeof(Int32)));  // 初年度
            table.Columns.Add(new DataColumn("ACCEPTODRCARRF.MAKERCODERF", typeof(Int32)));  // メーカーコード
            table.Columns.Add(new DataColumn("ACCEPTODRCARRF.MAKERFULLNAMERF", typeof(string)));  // メーカー全角名称
            table.Columns.Add(new DataColumn("ACCEPTODRCARRF.MODELCODERF", typeof(Int32)));  // 車種コード
            table.Columns.Add(new DataColumn("ACCEPTODRCARRF.MODELSUBCODERF", typeof(Int32)));  // 車種サブコード
            table.Columns.Add(new DataColumn("ACCEPTODRCARRF.MODELFULLNAMERF", typeof(string)));  // 車種全角名称
            table.Columns.Add(new DataColumn("ACCEPTODRCARRF.EXHAUSTGASSIGNRF", typeof(string)));  // 排ガス記号
            table.Columns.Add(new DataColumn("ACCEPTODRCARRF.SERIESMODELRF", typeof(string)));  // シリーズ型式
            table.Columns.Add(new DataColumn("ACCEPTODRCARRF.CATEGORYSIGNMODELRF", typeof(string)));  // 型式（類別記号）
            table.Columns.Add(new DataColumn("ACCEPTODRCARRF.FULLMODELRF", typeof(string)));  // 型式（フル型）
            table.Columns.Add(new DataColumn("ACCEPTODRCARRF.MODELDESIGNATIONNORF", typeof(Int32)));  // 型式指定番号
            table.Columns.Add(new DataColumn("ACCEPTODRCARRF.CATEGORYNORF", typeof(Int32)));  // 類別番号
            table.Columns.Add(new DataColumn("ACCEPTODRCARRF.FRAMEMODELRF", typeof(string)));  // 車台型式
            table.Columns.Add(new DataColumn("ACCEPTODRCARRF.FRAMENORF", typeof(string)));  // 車台番号
            table.Columns.Add(new DataColumn("ACCEPTODRCARRF.SEARCHFRAMENORF", typeof(Int32)));  // 車台番号（検索用）
            table.Columns.Add(new DataColumn("ACCEPTODRCARRF.ENGINEMODELNMRF", typeof(string)));  // エンジン型式名称
            table.Columns.Add(new DataColumn("ACCEPTODRCARRF.RELEVANCEMODELRF", typeof(string)));  // 関連型式
            table.Columns.Add(new DataColumn("ACCEPTODRCARRF.SUBCARNMCDRF", typeof(Int32)));  // サブ車名コード
            table.Columns.Add(new DataColumn("ACCEPTODRCARRF.MODELGRADESNAMERF", typeof(string)));  // 型式グレード略称
            table.Columns.Add(new DataColumn("ACCEPTODRCARRF.COLORCODERF", typeof(string)));  // カラーコード
            table.Columns.Add(new DataColumn("ACCEPTODRCARRF.COLORNAME1RF", typeof(string)));  // カラー名称1
            table.Columns.Add(new DataColumn("ACCEPTODRCARRF.TRIMCODERF", typeof(string)));  // トリムコード
            table.Columns.Add(new DataColumn("ACCEPTODRCARRF.TRIMNAMERF", typeof(string)));  // トリム名称
            table.Columns.Add(new DataColumn("ACCEPTODRCARRF.MILEAGERF", typeof(Int32)));  // 車両走行距離
            table.Columns.Add(new DataColumn("MAKGDS.MAKERSHORTNAMERF", typeof(string)));  // 部品メーカー略称
            table.Columns.Add(new DataColumn("MAKGDS.MAKERKANANAMERF", typeof(string)));  // 部品メーカーカナ名称
            table.Columns.Add(new DataColumn("MAKGDS.GOODSMAKERCDRF", typeof(Int32)));  // ユーザー検索部品メーカーコード
            table.Columns.Add(new DataColumn("MAKCMP.MAKERSHORTNAMERF", typeof(string)));  // 一式メーカー略称
            table.Columns.Add(new DataColumn("MAKCMP.MAKERKANANAMERF", typeof(string)));  // 一式メーカーカナ名称
            table.Columns.Add(new DataColumn("MAKCMP.GOODSMAKERCDRF", typeof(Int32)));  // ユーザー検索一式メーカーコード
            table.Columns.Add(new DataColumn("GOODSURF.GOODSNAMEKANARF", typeof(string)));  // 商品名称カナ
            table.Columns.Add(new DataColumn("GOODSURF.JANRF", typeof(string)));  // JANコード
            table.Columns.Add(new DataColumn("GOODSURF.GOODSRATERANKRF", typeof(string)));  // 商品掛率ランク
            table.Columns.Add(new DataColumn("GOODSURF.GOODSNONONEHYPHENRF", typeof(string)));  // ハイフン無商品番号
            table.Columns.Add(new DataColumn("GOODSURF.GOODSNOTE1RF", typeof(string)));  // 商品備考１
            table.Columns.Add(new DataColumn("GOODSURF.GOODSNOTE2RF", typeof(string)));  // 商品備考２
            table.Columns.Add(new DataColumn("GOODSURF.GOODSSPECIALNOTERF", typeof(string)));  // 商品規格・特記事項
            table.Columns.Add(new DataColumn("STOCKRF.SHIPMENTPOSCNTRF", typeof(Double)));  // 出荷可能数
            table.Columns.Add(new DataColumn("STOCKRF.DUPLICATIONSHELFNO1RF", typeof(string)));  // 重複棚番１
            table.Columns.Add(new DataColumn("STOCKRF.DUPLICATIONSHELFNO2RF", typeof(string)));  // 重複棚番２
            table.Columns.Add(new DataColumn("STOCKRF.PARTSMANAGEMENTDIVIDE1RF", typeof(string)));  // 部品管理区分１
            table.Columns.Add(new DataColumn("STOCKRF.PARTSMANAGEMENTDIVIDE2RF", typeof(string)));  // 部品管理区分２
            table.Columns.Add(new DataColumn("STOCKRF.STOCKNOTE1RF", typeof(string)));  // 在庫備考１
            table.Columns.Add(new DataColumn("STOCKRF.STOCKNOTE2RF", typeof(string)));  // 在庫備考２
            table.Columns.Add(new DataColumn("WAREHOUSERF.WAREHOUSENOTE1RF", typeof(string)));  // 倉庫備考1
            table.Columns.Add(new DataColumn("USRCSG.GUIDENAMERF", typeof(string)));  // 得意先掛率ＧＲ名称
            table.Columns.Add(new DataColumn("USRSPG.GUIDENAMERF", typeof(string)));  // 仕入先掛率ＧＲ名称
            table.Columns.Add(new DataColumn("SUPPLIERRF.SUPPLIERCDRF", typeof(Int32)));  // ユーザー検索仕入先コード
            table.Columns.Add(new DataColumn("SUPPLIERRF.SUPPLIERNM1RF", typeof(string)));  // 仕入先名1
            table.Columns.Add(new DataColumn("SUPPLIERRF.SUPPLIERNM2RF", typeof(string)));  // 仕入先名2
            table.Columns.Add(new DataColumn("SUPPLIERRF.SUPPHONORIFICTITLERF", typeof(string)));  // 仕入先敬称
            table.Columns.Add(new DataColumn("SUPPLIERRF.SUPPLIERKANARF", typeof(string)));  // 仕入先カナ
            table.Columns.Add(new DataColumn("SUPPLIERRF.PURECODERF", typeof(Int32)));  // 純正区分
            table.Columns.Add(new DataColumn("SUPPLIERRF.SUPPLIERNOTE1RF", typeof(string)));  // 仕入先備考1
            table.Columns.Add(new DataColumn("SUPPLIERRF.SUPPLIERNOTE2RF", typeof(string)));  // 仕入先備考2
            table.Columns.Add(new DataColumn("SUPPLIERRF.SUPPLIERNOTE3RF", typeof(string)));  // 仕入先備考3
            table.Columns.Add(new DataColumn("SUPPLIERRF.SUPPLIERNOTE4RF", typeof(string)));  // 仕入先備考4
            table.Columns.Add(new DataColumn("BLGOODSCDURF.BLGOODSCODERF", typeof(Int32)));  // ユーザー検索BL商品コード
            table.Columns.Add(new DataColumn("BLGOODSCDURF.BLGOODSHALFNAMERF", typeof(string)));  // BL商品コード名称（半角）
            table.Columns.Add(new DataColumn("DADD.STOCKMNGEXISTNMRF", typeof(string)));  // 在庫管理有無区分名称
            table.Columns.Add(new DataColumn("DADD.GOODSKINDNAMERF", typeof(string)));  // 商品属性名称
            table.Columns.Add(new DataColumn("DADD.SALESORDERDIVNMRF", typeof(string)));  // 売上在庫取寄せ区分名称
            table.Columns.Add(new DataColumn("DADD.OPENPRICEDIVNMRF", typeof(string)));  // オープン価格区分名称
            table.Columns.Add(new DataColumn("DADD.GRSPROFITCHKDIVNMRF", typeof(string)));  // 粗利チェック区分名称
            table.Columns.Add(new DataColumn("DADD.SALESGOODSNMRF", typeof(string)));  // 売上商品区分名称
            table.Columns.Add(new DataColumn("DADD.TAXATIONDIVNMRF", typeof(string)));  // 課税区分名称
            table.Columns.Add(new DataColumn("DADD.PURECODENMRF", typeof(string)));  // 純正区分
            table.Columns.Add(new DataColumn("DADD.DELIGDSCMPLTDUEDATEFYRF", typeof(Int32))); // 納品完了予定日西暦年
            table.Columns.Add(new DataColumn("DADD.DELIGDSCMPLTDUEDATEFSRF", typeof(Int32))); // 納品完了予定日西暦年略
            table.Columns.Add(new DataColumn("DADD.DELIGDSCMPLTDUEDATEFWRF", typeof(Int32))); // 納品完了予定日和暦年
            table.Columns.Add(new DataColumn("DADD.DELIGDSCMPLTDUEDATEFMRF", typeof(Int32))); // 納品完了予定日月
            table.Columns.Add(new DataColumn("DADD.DELIGDSCMPLTDUEDATEFDRF", typeof(Int32))); // 納品完了予定日日
            table.Columns.Add(new DataColumn("DADD.DELIGDSCMPLTDUEDATEFGRF", typeof(String))); // 納品完了予定日元号
            table.Columns.Add(new DataColumn("DADD.DELIGDSCMPLTDUEDATEFRRF", typeof(String))); // 納品完了予定日略号
            table.Columns.Add(new DataColumn("DADD.DELIGDSCMPLTDUEDATEFLSRF", typeof(String))); // 納品完了予定日リテラル(/)
            table.Columns.Add(new DataColumn("DADD.DELIGDSCMPLTDUEDATEFLPRF", typeof(String))); // 納品完了予定日リテラル(.)
            table.Columns.Add(new DataColumn("DADD.DELIGDSCMPLTDUEDATEFLYRF", typeof(String))); // 納品完了予定日リテラル(年)
            table.Columns.Add(new DataColumn("DADD.DELIGDSCMPLTDUEDATEFLMRF", typeof(String))); // 納品完了予定日リテラル(月)
            table.Columns.Add(new DataColumn("DADD.DELIGDSCMPLTDUEDATEFLDRF", typeof(String))); // 納品完了予定日リテラル(日)
            table.Columns.Add(new DataColumn("DADD.FIRSTENTRYDATEFYRF", typeof(Int32))); // 初年度西暦年
            table.Columns.Add(new DataColumn("DADD.FIRSTENTRYDATEFSRF", typeof(Int32))); // 初年度西暦年略
            table.Columns.Add(new DataColumn("DADD.FIRSTENTRYDATEFWRF", typeof(Int32))); // 初年度和暦年
            table.Columns.Add(new DataColumn("DADD.FIRSTENTRYDATEFMRF", typeof(Int32))); // 初年度月
            table.Columns.Add(new DataColumn("DADD.FIRSTENTRYDATEFGRF", typeof(String))); // 初年度元号
            table.Columns.Add(new DataColumn("DADD.FIRSTENTRYDATEFRRF", typeof(String))); // 初年度略号
            table.Columns.Add(new DataColumn("DADD.FIRSTENTRYDATEFLSRF", typeof(String))); // 初年度リテラル(/)
            table.Columns.Add(new DataColumn("DADD.FIRSTENTRYDATEFLPRF", typeof(String))); // 初年度リテラル(.)
            table.Columns.Add(new DataColumn("DADD.FIRSTENTRYDATEFLYRF", typeof(String))); // 初年度リテラル(年)
            table.Columns.Add(new DataColumn("DADD.FIRSTENTRYDATEFLMRF", typeof(String))); // 初年度リテラル(月)
            table.Columns.Add(new DataColumn("DADD.SALESORDERDIVMARKRF", typeof(String))); // 在庫取寄区分マーク
            table.Columns.Add(new DataColumn("ACCEPTODRCARRF.MAKERHALFNAMERF", typeof(String))); // メーカー半角名称
            table.Columns.Add(new DataColumn("ACCEPTODRCARRF.MODELHALFNAMERF", typeof(String))); // 車種半角名称
            table.Columns.Add(new DataColumn("SALESDETAILRF.PRTBLGOODSCODERF", typeof(Int32))); // BL商品コード（印刷）
            table.Columns.Add(new DataColumn("SALESDETAILRF.PRTBLGOODSNAMERF", typeof(String))); // BL商品コード名称（印刷）
            //table.Columns.Add( new DataColumn( "SALESDETAILRF.PRTGOODSNORF", typeof( String ) ) ); // 印刷用品番
            //table.Columns.Add( new DataColumn( "SALESDETAILRF.PRTMAKERCODERF", typeof( Int32 ) ) ); // 印刷用メーカーコード
            //table.Columns.Add( new DataColumn( "SALESDETAILRF.PRTMAKERNAMERF", typeof( String ) ) ); // 印刷用メーカー名称
            table.Columns.Add(new DataColumn("MAKPRT.MAKERKANANAMERF", typeof(String))); // 印刷用メーカーカナ名称
            table.Columns.Add(new DataColumn("SALESDETAILRF.GOODSLGROUPRF", typeof(Int32))); // 商品大分類コード
            table.Columns.Add(new DataColumn("SALESDETAILRF.GOODSLGROUPNAMERF", typeof(String))); // 商品大分類名称
            table.Columns.Add(new DataColumn("SALESDETAILRF.GOODSMGROUPRF", typeof(Int32))); // 商品中分類コード
            table.Columns.Add(new DataColumn("SALESDETAILRF.GOODSMGROUPNAMERF", typeof(String))); // 商品中分類名称
            table.Columns.Add(new DataColumn("SALESDETAILRF.BLGROUPCODERF", typeof(Int32))); // BLグループコード
            table.Columns.Add(new DataColumn("SALESDETAILRF.BLGROUPNAMERF", typeof(String))); // BLグループコード名称
            table.Columns.Add(new DataColumn("SALESDETAILRF.SALESCODERF", typeof(Int32))); // 販売区分コード
            table.Columns.Add(new DataColumn("SALESDETAILRF.SALESCDNMRF", typeof(String))); // 販売区分名称
            table.Columns.Add(new DataColumn("SALESDETAILRF.GOODSNAMEKANARF", typeof(String))); // 商品名称カナ
            // --- ADD 2009.07.24 劉洋 ------ >>>>>>
            table.Columns.Add(new DataColumn("DADD.ABGOODSNOTE2RF", typeof(String))); // ABOEMコード
            table.Columns.Add(new DataColumn("DADD.ABGOODSKINDCODERF", typeof(Int32))); // AB純正区分
            table.Columns.Add(new DataColumn("DADD.SHIPMENTCNTNOMINUSRF", typeof(Double))); // 出荷数(マイナス符号なし)
            table.Columns.Add(new DataColumn("DADD.SALESMONEYTAXEXCNOMINUSRF", typeof(Double))); // 売上金額（税抜き）(マイナス符号なし)
            table.Columns.Add(new DataColumn("DADD.LISTPRICEMONEYTAXEXCRF", typeof(Double))); // 定価金額(税抜)
            table.Columns.Add(new DataColumn("DADD.ABHQSALESUNITCOSTRF", typeof(Double))); // AB本部原価
            table.Columns.Add(new DataColumn("DADD.ABHQSALESUNITCOSTNOMINUSRF", typeof(Double))); // AB本部原価金額(マイナス符号なし)
            table.Columns.Add(new DataColumn("DADD.ABGOODSCODERF", typeof(String))); // AB商品コード

            table.Columns.Add(new DataColumn("DADD.SHIPMENTCNTMINUSSIGNRF", typeof(String)));//出荷数マイナス符号
            table.Columns.Add(new DataColumn("DADD.SALESMONEYTAXEXCMINUSSIGNRF", typeof(String)));//売上金額マイナス符号
            table.Columns.Add(new DataColumn("DADD.ABHQSALESUNITCOSTMINUSSIGNRF", typeof(String)));//AB本部原価金額マイナス符号
            // --- ADD 2009.07.24 劉洋 ------ <<<<<<
            // --- ADD  大矢睦美  2010/05/14 ---------->>>>>
            table.Columns.Add(new DataColumn("DADD.GROSSPROFITRATERF", typeof(String)));//粗利率
            table.Columns.Add(new DataColumn("DADD.GROSSPROFITRF", typeof(Int64)));//粗利金額
            table.Columns.Add(new DataColumn("SALESDETAILRF.UOEREMARK1DETAILRF", typeof(string))); //ＵＯＥリマーク１(明細)
            table.Columns.Add(new DataColumn("DADD.GROSSPROFITRATELTRLRF", typeof(String)));//粗利率リテラル
            // --- ADD  大矢睦美  2010/05/14 ----------<<<<<

            // 2011/05/27 Add >>>
            table.Columns.Add(new DataColumn("DADD.GRSPROFITCHECKMARKRF", typeof(String)));//粗利率チェックマーク
            table.Columns.Add(new DataColumn("HADD.PRINTCUSTNAMEJOIN12HNOFBYTERF", typeof(String)));//得意先名称１＋２＋敬称（バイト計算）
            // 2011/05/27 Add <<<

            // --- ADD  2011/07/19 ---------->>>>>
            table.Columns.Add(new DataColumn("HADD.NORMALPRTMARKRF", typeof(String)));//通常発行マーク
            table.Columns.Add(new DataColumn("HADD.SCMMANUALANSMARKRF", typeof(String)));//SCM手動回答マーク
            table.Columns.Add(new DataColumn("HADD.SCMAUTOANSMARKRF", typeof(String)));//SCM自動回答マーク
            // --- ADD  2011/07/19 ----------<<<<<
            # endregion

            # region [制御項目]
            // 制御項目
            table.Columns.Add(new DataColumn(ct_InPageCopyTitle1, typeof(string)));  // 複写タイトル
            table.Columns.Add(new DataColumn(ct_InPageCopyTitle2, typeof(string)));  // 複写タイトル
            table.Columns.Add(new DataColumn(ct_InPageCopyTitle3, typeof(string)));  // 複写タイトル
            table.Columns.Add(new DataColumn(ct_InPageCopyTitle4, typeof(string)));  // 複写タイトル
            table.Columns.Add(new DataColumn(ct_InPageCopyCount, typeof(int)));  // 同一ページ内コピーカウント
            table.Columns.Add(new DataColumn(ct_PageCount, typeof(int)));  // ページ数
            // 印字制御が特殊な項目
            //table.Columns.Add( new DataColumn( ct_AcptCount, typeof( Double ) ) );  // 受注数
            //table.Columns.Add( new DataColumn( ct_ShipCount, typeof( Double ) ) );  // 出荷数
            table.Columns.Add(new DataColumn(ct_HCategoryHyp, typeof(string)));  // (先頭)類別型式ハイフン
            table.Columns.Add(new DataColumn(ct_DCategoryHyp, typeof(string)));  // 類別型式ハイフン
            // --- ADD m.suzuki 2010/03/24 ---------->>>>>
            table.Columns.Add( new DataColumn( ct_QRCode, typeof( string ) ) ); // ＱＲコード
            table.Columns.Add( new DataColumn( ct_QRCodeSource, typeof( string ) ) ); // ＱＲコード(元データ)
            // --- ADD m.suzuki 2010/03/24 ----------<<<<<
            //table.Columns.Add( new DataColumn( ct_DWarehouseCodeRF, typeof( string ) ) );  // 倉庫コード（タイトル１・２）
            //table.Columns.Add( new DataColumn( ct_DWarehouseNameRF, typeof( string ) ) );  // 倉庫名（タイトル１・２）
            //table.Columns.Add( new DataColumn( ct_DWarehouseShelfNoRF, typeof( string ) ) );  // 棚番（タイトル１・２）
            table.Columns.Add(new DataColumn(ct_SupplierCdExtra, typeof(string)));  // 仕入先コード（取寄のみ）
            table.Columns.Add(new DataColumn(ct_ShelfNoExtra, typeof(string)));  // 棚番（得意先注番なし時）
            table.Columns.Add(new DataColumn(ct_TaxTitle, typeof(string)));  // (Label)消費税タイトル
            table.Columns.Add(new DataColumn(ct_SubTotalTitle, typeof(string)));  // (Label)小計タイトル
            table.Columns.Add(new DataColumn(ct_ReceiveTimeLabel, typeof(string)));  // (Label)受信時刻固定文字
            table.Columns.Add(new DataColumn(ct_ReceiveTimeHour, typeof(int))); // 受信時刻(時)
            table.Columns.Add(new DataColumn(ct_ReceiveTimeMinute, typeof(int))); // 受信時刻(分)
            table.Columns.Add(new DataColumn(ct_ReceiveTimeSecond, typeof(int))); // 受信時刻(秒)
            table.Columns.Add(new DataColumn("HLG.CUSTOMERNAMERF", typeof(string)));  // 【縦倍】得意先名称
            table.Columns.Add(new DataColumn("HLG.CUSTOMERNAME2RF", typeof(string)));  //【縦倍】 得意先名称2
            table.Columns.Add(new DataColumn("HLG.CUSTOMERSNMRF", typeof(string)));  // 【縦倍】得意先略称
            table.Columns.Add(new DataColumn("HLG.HONORIFICTITLERF", typeof(string)));  // 【縦倍】敬称
            table.Columns.Add(new DataColumn("HLG.PRINTCUSTOMERNAMEJOIN12RF", typeof(String))); //【縦倍】得意先名１＋得意先名２
            table.Columns.Add(new DataColumn("HLG.PRINTCUSTOMERNAMEJOIN12HNRF", typeof(String))); // 【縦倍】得意先名１＋得意先名２＋敬称
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.07.21 ADD
            table.Columns.Add(new DataColumn("HLG.COMPANYNAME1RF", typeof(string)));  // 【縦倍】自社名称1
            table.Columns.Add(new DataColumn("HLG.COMPANYNAME2RF", typeof(string)));  // 【縦倍】自社名称2
            table.Columns.Add(new DataColumn("HLG.PRINTENTERPRISENAME1FHRF", typeof(String))); // 【縦倍】自社名１（前半）
            table.Columns.Add(new DataColumn("HLG.PRINTENTERPRISENAME1LHRF", typeof(String))); // 【縦倍】自社名１（後半）
            table.Columns.Add(new DataColumn("HLG.PRINTENTERPRISENAME2FHRF", typeof(String))); // 【縦倍】自社名２（前半）
            table.Columns.Add(new DataColumn("HLG.PRINTENTERPRISENAME2LHRF", typeof(String))); // 【縦倍】自社名２（後半）
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.07.21 ADD
            // 2011/05/27 Add >>>
            table.Columns.Add(new DataColumn("HLG.PRINTCUSTNAMEJOIN12HNOFBYTERF", typeof(String))); // （縦倍）得意先名称１＋２＋敬称（バイト計算）
            // 2011/05/27 Add <<<
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.oya 2009/10/05 ADD
            // U700用の伝票合計の印字位置制御を行うために項目追加。
            table.Columns.Add(new DataColumn("HADD.SALESTOTALTAXINCA700RF", typeof(String))); // 伝票合計（U700）←税込
            table.Columns.Add(new DataColumn("HADD.SALESTOTALTAXEXCA700RF", typeof(String))); // 伝票小計（U700）←税抜
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.oya 2009/10/05 ADD
            // 2010/11/11 Add >>>
            table.Columns.Add(new DataColumn("HADD.SALESTOTALTITLERF", typeof(String))); // 総合計タイトル
            // 2010/11/11 Add <<<
            # endregion

            # region [UOE専用項目（伝票項目）]
            table.Columns.Add(new DataColumn("HUOE.SLIPCDRF", typeof(Int32))); // UOE伝票種別
            table.Columns.Add(new DataColumn("HUOE.SLIPCDNMRF", typeof(String))); // UOE伝票種別名
            table.Columns.Add(new DataColumn("HUOE.TOTALCNTRF", typeof(Int32))); // 出庫数合計
            table.Columns.Add(new DataColumn("HUOE.BOCODERF", typeof(String))); // (先頭)BO区分
            table.Columns.Add(new DataColumn("HUOE.UOEDELIGOODSDIVRF", typeof(String))); // (先頭)UOE納品区分
            table.Columns.Add(new DataColumn("HUOE.DELIVEREDGOODSDIVNMRF", typeof(String))); // (先頭)納品区分名称
            table.Columns.Add(new DataColumn("HUOE.FOLLOWDELIGOODSDIVRF", typeof(String))); // (先頭)フォロー納品区分
            table.Columns.Add(new DataColumn("HUOE.FOLLOWDELIGOODSDIVNMRF", typeof(String))); // (先頭)フォロー納品区分名称
            # endregion

            # region [UOE専用項目（明細項目）]
            table.Columns.Add(new DataColumn("DUOE.BOCODERF", typeof(String))); // BO区分
            table.Columns.Add(new DataColumn("DUOE.UOEDELIGOODSDIVRF", typeof(String))); // UOE納品区分
            table.Columns.Add(new DataColumn("DUOE.DELIVEREDGOODSDIVNMRF", typeof(String))); // 納品区分名称
            table.Columns.Add(new DataColumn("DUOE.FOLLOWDELIGOODSDIVRF", typeof(String))); // フォロー納品区分
            table.Columns.Add(new DataColumn("DUOE.FOLLOWDELIGOODSDIVNMRF", typeof(String))); // フォロー納品区分名称
            table.Columns.Add(new DataColumn("DUOE.DETAILCDRF", typeof(Int32))); // 明細種別
            table.Columns.Add(new DataColumn("DUOE.DETAILCDNMRF", typeof(String))); // 明細種別名
            table.Columns.Add(new DataColumn("DUOE.PRTACCEPTANORDERCNTRF", typeof(Double))); // (印刷用)受注数
            table.Columns.Add(new DataColumn("DUOE.PRTSHIPMENTCNTRF", typeof(Int32))); // (印刷用)出庫数
            table.Columns.Add(new DataColumn("DUOE.PRTSHIPMENTCNTZERORF", typeof(String))); // (印刷用)出庫数ゼロ
            table.Columns.Add(new DataColumn("DUOE.PRTUOESECTOUTGOODSCNTRF", typeof(Int32))); // (印刷用)拠点出庫数
            table.Columns.Add(new DataColumn("DUOE.PRTUOESECTOUTGOODSCNTZERORF", typeof(String))); // (印刷用)拠点出庫数ゼロ
            table.Columns.Add(new DataColumn("DUOE.PRTBOSHIPMENTCNTRF", typeof(Int32))); // (印刷用)BO出庫数
            table.Columns.Add(new DataColumn("DUOE.PRTBOSHIPMENTCNTZERORF", typeof(String))); // (印刷用)BO出庫数ゼロ
            table.Columns.Add(new DataColumn("DUOE.PRTACPTREMAINCNTRF", typeof(Int32))); // (印刷用)受注残数
            // --- ADD 2009.07.24 劉洋 ------ >>>>>>
            table.Columns.Add(new DataColumn("DUOE.PrtUOESectOutGoodsCnt0RF", typeof(String))); // (印刷用)拠点出庫数0
            table.Columns.Add(new DataColumn("DUOE.PrtBOShipmentCnt0RF", typeof(String))); // (印刷用)BO出庫数0
            // --- ADD 2009.07.24 劉洋 ------ <<<<<<
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
        /// <param name="slipWork"></param>
        /// <param name="detailWorks"></param>
        /// <param name="uoeSales"></param>
        /// <param name="slipPrtSet"></param>
        /// <param name="frePrtPSet"></param>
        /// <param name="salesTtlSt"></param>
        /// <remarks>
        /// <br>Update Note: 2011/02/16 徐嘉</br>
        /// <br>             自社名称１，２が縦倍角になっていない不具合の対応</br>  
        /// <br>Update Note: 2011/08/15 李占川</br>
        /// <br>             【PM要望改良9月配信分】Redmine#23541 連番985の対応</br> 
        /// <br>Update Note: 2011/08/30 yangmj</br>
        /// <br>             Redmine#24110 伝票備考の文字数の修正内容の対応</br> 
        /// <br>Update Note  : 2017/08/30 3H 楊善娟</br>
        /// <br>管理番号     : 11370074-00 ハンディ対応（2次）</br>
        /// </remarks>
        // --- UPD m.suzuki 2010/05/17 ---------->>>>>
        //public static void CopyToDataTable(ref DataTable table, FrePSalesSlipWork slipWork, List<FrePSalesDetailWork> detailWorks, UoeSales uoeSales, FrePrtPSetWork frePrtPSet, SlipPrtSetWork slipPrtSet, EachSlipTypeSet eachSlipTypeSet, SalesTtlStWork salesTtlSt, AllDefSetWork allDefSet, SlipPrintParameter slipPrintParameter, Dictionary<string, string> columnVisibleTypeDic, Dictionary<string, string> titleDic)
        // --- UPD 李占川 2011/08/15---------->>>>>
        //public static void CopyToDataTable(ref List<DataTable> retTables, ref int currentIndex, FrePSalesSlipWork slipWork, List<FrePSalesDetailWork> detailWorks, UoeSales uoeSales, FrePrtPSetWork frePrtPSet, SlipPrtSetWork slipPrtSet, EachSlipTypeSet eachSlipTypeSet, SalesTtlStWork salesTtlSt, AllDefSetWork allDefSet, SlipPrintParameter slipPrintParameter, Dictionary<string, string> columnVisibleTypeDic, Dictionary<string, string> titleDic)
        public static void CopyToDataTable(ref List<DataTable> retTables, ref int currentIndex, FrePSalesSlipWork slipWork, List<FrePSalesDetailWork> detailWorks, UoeSales uoeSales, FrePrtPSetWork frePrtPSet, SlipPrtSetWork slipPrtSet, EachSlipTypeSet eachSlipTypeSet, SalesTtlStWork salesTtlSt, AllDefSetWork allDefSet, SlipPrintParameter slipPrintParameter, Dictionary<string, string> columnVisibleTypeDic, Dictionary<string, string> titleDic, Dictionary<string, ar.ActiveReport3> subReportDic)
        // --- UPD 李占川 2011/08/15----------<<<<<
        // --- UPD m.suzuki 2010/05/17 ----------<<<<<
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

            // --- ADD  大矢睦美  2010/05/14 ---------->>>>>
            if (stc_grossProfitCalculator == null)
            {
                stc_grossProfitCalculator = new GrossProfitCalculator();
            }
            // --- ADD  大矢睦美  2010/05/14 ----------<<<<<

            // グループサプレスキー(前回退避)
            GroupSuppressKey prevSuppressKey;

            // 消費税転嫁方式（0:伝票単位1:明細単位2:請求親 3:請求子 9:非課税）
            int consTaxLayMethod = slipWork.SALESSLIPRF_CONSTAXLAYMETHODRF;

            # region [時刻]
            // 印刷時刻
            DateTime printTime = DateTime.Now;
            slipWork.HADD_PRINTTIMEHOURRF = printTime.Hour;
            slipWork.HADD_PRINTTIMEMINUTERF = printTime.Minute;
            slipWork.HADD_PRINTTIMESECONDRF = printTime.Second;

            // 受信時刻
            int receiveTimeHour = 0;
            int receiveTimeMinute = 0;
            int receiveTimeSecond = 0;
            if (uoeSales != null &&
                uoeSales.uoeSalesDetailList != null &&
                uoeSales.uoeSalesDetailList.Count > 0 &&
                uoeSales.uoeSalesDetailList[0].prtSalesDetail != null)
            {
                int receiveTime = uoeSales.uoeSalesDetailList[0].prtSalesDetail.prtReceiveTime;
                receiveTimeHour = ( receiveTime / 10000 );
                receiveTimeMinute = ( receiveTime / 100 ) % 100;
                receiveTimeSecond = ( receiveTime ) % 100;
            }
            # endregion

            # region // DEL
            //// 先頭行車両情報セット
            //# region [先頭行車両情報]
            //if ( detailWorks.Count > 0 )
            //{
            //    slipWork.HADD_CARMNGNORF = detailWorks[0].ACCEPTODRCARRF_CARMNGNORF;
            //    slipWork.HADD_CARMNGCODERF = detailWorks[0].ACCEPTODRCARRF_CARMNGCODERF;
            //    slipWork.HADD_NUMBERPLATE1CODERF = detailWorks[0].ACCEPTODRCARRF_NUMBERPLATE1CODERF;
            //    slipWork.HADD_NUMBERPLATE1NAMERF = detailWorks[0].ACCEPTODRCARRF_NUMBERPLATE1NAMERF;
            //    slipWork.HADD_NUMBERPLATE2RF = detailWorks[0].ACCEPTODRCARRF_NUMBERPLATE2RF;
            //    slipWork.HADD_NUMBERPLATE3RF = detailWorks[0].ACCEPTODRCARRF_NUMBERPLATE3RF;
            //    slipWork.HADD_NUMBERPLATE4RF = detailWorks[0].ACCEPTODRCARRF_NUMBERPLATE4RF;
            //    slipWork.HADD_FIRSTENTRYDATERF = detailWorks[0].ACCEPTODRCARRF_FIRSTENTRYDATERF;
            //    slipWork.HADD_MAKERCODERF = detailWorks[0].ACCEPTODRCARRF_MAKERCODERF;
            //    slipWork.HADD_MAKERFULLNAMERF = detailWorks[0].ACCEPTODRCARRF_MAKERFULLNAMERF;
            //    slipWork.HADD_MODELCODERF = detailWorks[0].ACCEPTODRCARRF_MODELCODERF;
            //    slipWork.HADD_MODELSUBCODERF = detailWorks[0].ACCEPTODRCARRF_MODELSUBCODERF;
            //    slipWork.HADD_MODELFULLNAMERF = detailWorks[0].ACCEPTODRCARRF_MODELFULLNAMERF;
            //    slipWork.HADD_EXHAUSTGASSIGNRF = detailWorks[0].ACCEPTODRCARRF_EXHAUSTGASSIGNRF;
            //    slipWork.HADD_SERIESMODELRF = detailWorks[0].ACCEPTODRCARRF_SERIESMODELRF;
            //    slipWork.HADD_CATEGORYSIGNMODELRF = detailWorks[0].ACCEPTODRCARRF_CATEGORYSIGNMODELRF;
            //    slipWork.HADD_FULLMODELRF = detailWorks[0].ACCEPTODRCARRF_FULLMODELRF;
            //    slipWork.HADD_MODELDESIGNATIONNORF = detailWorks[0].ACCEPTODRCARRF_MODELDESIGNATIONNORF;
            //    slipWork.HADD_CATEGORYNORF = detailWorks[0].ACCEPTODRCARRF_CATEGORYNORF;
            //    slipWork.HADD_FRAMEMODELRF = detailWorks[0].ACCEPTODRCARRF_FRAMEMODELRF;
            //    slipWork.HADD_FRAMENORF = detailWorks[0].ACCEPTODRCARRF_FRAMENORF;
            //    slipWork.HADD_SEARCHFRAMENORF = detailWorks[0].ACCEPTODRCARRF_SEARCHFRAMENORF;
            //    slipWork.HADD_ENGINEMODELNMRF = detailWorks[0].ACCEPTODRCARRF_ENGINEMODELNMRF;
            //    slipWork.HADD_RELEVANCEMODELRF = detailWorks[0].ACCEPTODRCARRF_RELEVANCEMODELRF;
            //    slipWork.HADD_SUBCARNMCDRF = detailWorks[0].ACCEPTODRCARRF_SUBCARNMCDRF;
            //    slipWork.HADD_MODELGRADESNAMERF = detailWorks[0].ACCEPTODRCARRF_MODELGRADESNAMERF;
            //    slipWork.HADD_COLORCODERF = detailWorks[0].ACCEPTODRCARRF_COLORCODERF;
            //    slipWork.HADD_COLORNAME1RF = detailWorks[0].ACCEPTODRCARRF_COLORNAME1RF;
            //    slipWork.HADD_TRIMCODERF = detailWorks[0].ACCEPTODRCARRF_TRIMCODERF;
            //    slipWork.HADD_TRIMNAMERF = detailWorks[0].ACCEPTODRCARRF_TRIMNAMERF;
            //    slipWork.HADD_MILEAGERF = detailWorks[0].ACCEPTODRCARRF_MILEAGERF;
            //    slipWork.HADD_MAKERHALFNAMERF = detailWorks[0].ACCEPTODRCARRF_MAKERHALFNAMERF;
            //    slipWork.HADD_MODELHALFNAMERF = detailWorks[0].ACCEPTODRCARRF_MODELHALFNAMERF;
            //}
            //# endregion
            # endregion

            // 伝票work各種名称
            # region [slipWork各種名称]
            //slipWork.HADD_ACPTANODRSTNMRF = GetHADD_ACPTANODRSTNMRF( slipWork.SALESSLIPRF_ACPTANODRSTATUSRF );
            slipWork.HADD_ACPTANODRSTNMRF = GetHADD_ACPTANODRSTNMRF(slipWork.SALESSLIPRF_ACPTANODRSTATUSRF, slipWork.SALESSLIPRF_SALESSLIPCDRF); // 受注ｽﾃｰﾀｽ+伝票区分
            slipWork.HADD_DEBITNOTEDIVNMRF = GetHADD_DEBITNOTEDIVNMRF(slipWork.SALESSLIPRF_DEBITNOTEDIVRF);
            //slipWork.HADD_SALESSLIPNMRF = GetHADD_SALESSLIPNMRF( slipWork.SALESSLIPRF_SALESSLIPCDRF );
            slipWork.HADD_SALESSLIPNMRF = slipWork.HADD_ACPTANODRSTNMRF;
            slipWork.HADD_SALESGOODSNMRF = GetHADD_SALESGOODSNMRF(slipWork.SALESSLIPRF_SALESGOODSCDRF);
            slipWork.HADD_ACCRECDIVNMRF = GetHADD_ACCRECDIVNMRF(slipWork.SALESSLIPRF_ACCRECDIVCDRF);
            slipWork.HADD_DELAYPAYMENTDIVNMRF = GetHADD_DELAYPAYMENTDIVNMRF(slipWork.SALESSLIPRF_DELAYPAYMENTDIVRF);
            slipWork.HADD_ESTIMATEDIVIDENMRF = GetHADD_ESTIMATEDIVIDENMRF(slipWork.SALESSLIPRF_ESTIMATEDIVIDERF);
            slipWork.HADD_CONSTAXLAYMETHODNMRF = GetHADD_CONSTAXLAYMETHODNMRF(slipWork.SALESSLIPRF_CONSTAXLAYMETHODRF);
            slipWork.HADD_AUTODEPOSITNMRF = GetHADD_AUTODEPOSITNMRF(slipWork.SALESSLIPRF_AUTODEPOSITCDRF);
            slipWork.HADD_SLIPPRINTFINISHNMRF = GetHADD_SLIPPRINTFINISHNMRF(slipWork.SALESSLIPRF_SLIPPRINTFINISHCDRF);
            //slipWork.HADD_COMPLETENMRF = GetHADD_COMPLETENMRF( slipWork.SALESSLIPRF_COMPLETECDRF );
            # endregion

            // --- ADD m.suzuki 2010/03/24 ---------->>>>>
            // ＱＲコードデータ生成
            # region [ＱＲコードデータ生成]
            string qrData = string.Empty;
            string qrDataSource = string.Empty;

            // QRｺｰﾄﾞが貼り付けてあるﾚｲｱｳﾄの場合のみ処理する
            if ( ReportItemDic.ContainsKey( ct_QRCode ) )
            {
                // QRｺｰﾄﾞ印刷判定フラグ
                bool qrCodePrint;

                // qrCodePrintの判定
                # region [qrCodePrintの判定]
                // 得意先マスタ.QRコード印刷区分(0:標準 1:印字しない 2:印字する 3:返品含む)
                switch ( slipWork.CSTCST_QRCODEPRTCDRF )
                {
                    // 0:標準
                    default:
                    case 0:
                        {
                            // 伝票印刷パターン設定.QRコード印刷区分((0:標準) 1:印字しない 2:印字する 3:返品含む)
                            switch ( slipPrtSet.QRCodePrintDivCd )
                            {
                                // (0:標準) 1:しない ... マスメンに合わせて0も"印刷しない"とみなす
                                default:
                                case 0:
                                case 1:
                                    {
                                        qrCodePrint = false;
                                    }
                                    break;
                                // 2:印字する
                                case 2:
                                    {
                                        if ( slipWork.SALESSLIPRF_SALESSLIPCDRF == 0 )
                                        {
                                            // 売上ならば印刷する
                                            qrCodePrint = true;
                                        }
                                        else
                                        {
                                            // 返品ならば印刷しない
                                            qrCodePrint = false;
                                        }
                                    }
                                    break;
                                // 3:返品含む
                                case 3:
                                    {
                                        qrCodePrint = true;
                                    }
                                    break;
                            }
                        }
                        break;
                    // 1:印字しない
                    case 1:
                        {
                            qrCodePrint = false;
                        }
                        break;
                    // 2:印字する
                    case 2:
                        {
                            if ( slipWork.SALESSLIPRF_SALESSLIPCDRF == 0 )
                            {
                                // 売上ならば印刷する
                                qrCodePrint = true;
                            }
                            else
                            {
                                // 返品ならば印刷しない
                                qrCodePrint = false;
                            }
                        }
                        break;
                    // 3:返品含む
                    case 3:
                        {
                            qrCodePrint = true;
                        }
                        break;
                }
                # endregion

                // QRｺｰﾄﾞ抽出
                if ( qrCodePrint )
                {
                    
                    UoeQRDataCreateMediator.CreateData( slipPrtSet.EnterpriseCode, slipWork, detailWorks, uoeSales, out qrDataSource, out qrData );
                }
            }
            # endregion
            // --- ADD m.suzuki 2010/03/24 ----------<<<<<

            // 伝票タイトル取得処理
            List<List<string>> inPageCopyTitle = GetInPageCopyTitles(slipPrtSet);

            // １ページの明細行数を取得
            int feedCount = frePrtPSet.FormFeedLineCount;
            if (feedCount <= 0) feedCount = 1;
            if (slipPrtSet.DetailRowCount <= 0) slipPrtSet.DetailRowCount = feedCount;

            // 総行数取得
            int allDetailCount = GetAllDetailCount(detailWorks.Count, Math.Min(feedCount, slipPrtSet.DetailRowCount));

            // 全ページ数
            int allPageCount = allDetailCount / Math.Min(feedCount, slipPrtSet.DetailRowCount);
            int pageStartIndex = 0;
            int pageEndIndex = pageStartIndex + feedCount - 1;

            int printEndIndex = pageStartIndex + slipPrtSet.DetailRowCount - 1;

            for (int pageIndex = 0; pageIndex < allPageCount; pageIndex++)
            {
                // --- ADD m.suzuki 2010/05/17 ---------->>>>>
                DataTable table = PMUOE08001PB.CreateFrePSalesSlipTable( currentIndex++ );
                retTables.Add( table );
                // --- ADD m.suzuki 2010/05/17 ----------<<<<<

                for (int inPageCopyCount = 0; inPageCopyCount < inPageCopyTitle[0].Count; inPageCopyCount++)
                {
                    // 前回サプレスキー退避用クリア
                    prevSuppressKey = GroupSuppressKey.Create();

                    // 明細行移行
                    for (int index = pageStartIndex; index <= pageEndIndex; index++)
                    {
                        DataRow row = table.NewRow();

                        # region [明細追加]
                        // ページ数
                        row[ct_PageCount] = pageIndex + 1;

                        // 最初のレコード／最後のレコードのみ伝票項目をセットする。
                        // (単純に明細の数だけ倍増させない為)
                        // なおここでの"最後のレコード"とは空白行の可能性も含む。
                        if (index == pageStartIndex || index == pageEndIndex)
                        {
                            # region [ページ先頭の車輛情報]
                            slipWork.HADD_CARMNGNORF = detailWorks[pageStartIndex].ACCEPTODRCARRF_CARMNGNORF;
                            slipWork.HADD_CARMNGCODERF = detailWorks[pageStartIndex].ACCEPTODRCARRF_CARMNGCODERF;
                            slipWork.HADD_NUMBERPLATE1CODERF = detailWorks[pageStartIndex].ACCEPTODRCARRF_NUMBERPLATE1CODERF;
                            slipWork.HADD_NUMBERPLATE1NAMERF = detailWorks[pageStartIndex].ACCEPTODRCARRF_NUMBERPLATE1NAMERF;
                            slipWork.HADD_NUMBERPLATE2RF = detailWorks[pageStartIndex].ACCEPTODRCARRF_NUMBERPLATE2RF;
                            slipWork.HADD_NUMBERPLATE3RF = detailWorks[pageStartIndex].ACCEPTODRCARRF_NUMBERPLATE3RF;
                            slipWork.HADD_NUMBERPLATE4RF = detailWorks[pageStartIndex].ACCEPTODRCARRF_NUMBERPLATE4RF;
                            slipWork.HADD_FIRSTENTRYDATERF = detailWorks[pageStartIndex].ACCEPTODRCARRF_FIRSTENTRYDATERF;
                            slipWork.HADD_MAKERCODERF = detailWorks[pageStartIndex].ACCEPTODRCARRF_MAKERCODERF;
                            slipWork.HADD_MAKERFULLNAMERF = detailWorks[pageStartIndex].ACCEPTODRCARRF_MAKERFULLNAMERF;
                            slipWork.HADD_MODELCODERF = detailWorks[pageStartIndex].ACCEPTODRCARRF_MODELCODERF;
                            slipWork.HADD_MODELSUBCODERF = detailWorks[pageStartIndex].ACCEPTODRCARRF_MODELSUBCODERF;
                            slipWork.HADD_MODELFULLNAMERF = detailWorks[pageStartIndex].ACCEPTODRCARRF_MODELFULLNAMERF;
                            slipWork.HADD_EXHAUSTGASSIGNRF = detailWorks[pageStartIndex].ACCEPTODRCARRF_EXHAUSTGASSIGNRF;
                            slipWork.HADD_SERIESMODELRF = detailWorks[pageStartIndex].ACCEPTODRCARRF_SERIESMODELRF;
                            slipWork.HADD_CATEGORYSIGNMODELRF = detailWorks[pageStartIndex].ACCEPTODRCARRF_CATEGORYSIGNMODELRF;
                            slipWork.HADD_FULLMODELRF = detailWorks[pageStartIndex].ACCEPTODRCARRF_FULLMODELRF;
                            slipWork.HADD_MODELDESIGNATIONNORF = detailWorks[pageStartIndex].ACCEPTODRCARRF_MODELDESIGNATIONNORF;
                            slipWork.HADD_CATEGORYNORF = detailWorks[pageStartIndex].ACCEPTODRCARRF_CATEGORYNORF;
                            slipWork.HADD_FRAMEMODELRF = detailWorks[pageStartIndex].ACCEPTODRCARRF_FRAMEMODELRF;
                            slipWork.HADD_FRAMENORF = detailWorks[pageStartIndex].ACCEPTODRCARRF_FRAMENORF;
                            slipWork.HADD_SEARCHFRAMENORF = detailWorks[pageStartIndex].ACCEPTODRCARRF_SEARCHFRAMENORF;
                            slipWork.HADD_ENGINEMODELNMRF = detailWorks[pageStartIndex].ACCEPTODRCARRF_ENGINEMODELNMRF;
                            slipWork.HADD_RELEVANCEMODELRF = detailWorks[pageStartIndex].ACCEPTODRCARRF_RELEVANCEMODELRF;
                            slipWork.HADD_SUBCARNMCDRF = detailWorks[pageStartIndex].ACCEPTODRCARRF_SUBCARNMCDRF;
                            slipWork.HADD_MODELGRADESNAMERF = detailWorks[pageStartIndex].ACCEPTODRCARRF_MODELGRADESNAMERF;
                            slipWork.HADD_COLORCODERF = detailWorks[pageStartIndex].ACCEPTODRCARRF_COLORCODERF;
                            slipWork.HADD_COLORNAME1RF = detailWorks[pageStartIndex].ACCEPTODRCARRF_COLORNAME1RF;
                            slipWork.HADD_TRIMCODERF = detailWorks[pageStartIndex].ACCEPTODRCARRF_TRIMCODERF;
                            slipWork.HADD_TRIMNAMERF = detailWorks[pageStartIndex].ACCEPTODRCARRF_TRIMNAMERF;
                            slipWork.HADD_MILEAGERF = detailWorks[pageStartIndex].ACCEPTODRCARRF_MILEAGERF;
                            slipWork.HADD_MAKERHALFNAMERF = detailWorks[pageStartIndex].ACCEPTODRCARRF_MAKERHALFNAMERF;
                            slipWork.HADD_MODELHALFNAMERF = detailWorks[pageStartIndex].ACCEPTODRCARRF_MODELHALFNAMERF;
                            # endregion

                            # region [伝票項目Copy]
                            row["SALESSLIPRF.ACPTANODRSTATUSRF"] = slipWork.SALESSLIPRF_ACPTANODRSTATUSRF; // 受注ステータス
                            row["SALESSLIPRF.SALESSLIPNUMRF"] = slipWork.SALESSLIPRF_SALESSLIPNUMRF; // ＵＯＥ伝票番号
                            row["SALESSLIPRF.SECTIONCODERF"] = slipWork.SALESSLIPRF_SECTIONCODERF; // 拠点コード
                            row["SALESSLIPRF.SUBSECTIONCODERF"] = slipWork.SALESSLIPRF_SUBSECTIONCODERF; // 部門コード
                            row["SALESSLIPRF.DEBITNOTEDIVRF"] = slipWork.SALESSLIPRF_DEBITNOTEDIVRF; // 赤伝区分
                            row["SALESSLIPRF.DEBITNLNKSALESSLNUMRF"] = slipWork.SALESSLIPRF_DEBITNLNKSALESSLNUMRF; // 赤黒連結ＵＯＥ伝票番号
                            row["SALESSLIPRF.SALESSLIPCDRF"] = slipWork.SALESSLIPRF_SALESSLIPCDRF; // ＵＯＥ伝票区分
                            row["SALESSLIPRF.SALESGOODSCDRF"] = slipWork.SALESSLIPRF_SALESGOODSCDRF; // 売上商品区分
                            row["SALESSLIPRF.ACCRECDIVCDRF"] = slipWork.SALESSLIPRF_ACCRECDIVCDRF; // 売掛区分
                            row["SALESSLIPRF.SEARCHSLIPDATERF"] = slipWork.SALESSLIPRF_SEARCHSLIPDATERF; // 伝票検索日付
                            row["SALESSLIPRF.SHIPMENTDAYRF"] = slipWork.SALESSLIPRF_SHIPMENTDAYRF; // 出荷日付
                            row["SALESSLIPRF.SALESDATERF"] = slipWork.SALESSLIPRF_SALESDATERF; // 売上日付
                            row["SALESSLIPRF.ADDUPADATERF"] = slipWork.SALESSLIPRF_ADDUPADATERF; // 計上日付
                            row["SALESSLIPRF.DELAYPAYMENTDIVRF"] = slipWork.SALESSLIPRF_DELAYPAYMENTDIVRF; // 来勘区分
                            row["SALESSLIPRF.ESTIMATEFORMNORF"] = slipWork.SALESSLIPRF_ESTIMATEFORMNORF; // 見積書番号
                            row["SALESSLIPRF.ESTIMATEDIVIDERF"] = slipWork.SALESSLIPRF_ESTIMATEDIVIDERF; // 見積区分
                            row["SALESSLIPRF.SALESINPUTCODERF"] = slipWork.SALESSLIPRF_SALESINPUTCODERF; // 売上入力者コード
                            row["SALESSLIPRF.SALESINPUTNAMERF"] = slipWork.SALESSLIPRF_SALESINPUTNAMERF; // 売上入力者名称
                            row["SALESSLIPRF.FRONTEMPLOYEECDRF"] = slipWork.SALESSLIPRF_FRONTEMPLOYEECDRF; // 受付従業員コード
                            row["SALESSLIPRF.FRONTEMPLOYEENMRF"] = slipWork.SALESSLIPRF_FRONTEMPLOYEENMRF; // 受付従業員名称
                            row["SALESSLIPRF.SALESEMPLOYEECDRF"] = slipWork.SALESSLIPRF_SALESEMPLOYEECDRF; // 販売従業員コード
                            row["SALESSLIPRF.SALESEMPLOYEENMRF"] = slipWork.SALESSLIPRF_SALESEMPLOYEENMRF; // 販売従業員名称
                            row["SALESSLIPRF.TOTALAMOUNTDISPWAYCDRF"] = slipWork.SALESSLIPRF_TOTALAMOUNTDISPWAYCDRF; // 総額表示方法区分
                            row["SALESSLIPRF.TTLAMNTDISPRATEAPYRF"] = slipWork.SALESSLIPRF_TTLAMNTDISPRATEAPYRF; // 総額表示掛率適用区分
                            row["SALESSLIPRF.SALESTOTALTAXINCRF"] = slipWork.SALESSLIPRF_SALESTOTALTAXINCRF; // ＵＯＥ伝票合計（税込み）
                            row["SALESSLIPRF.SALESTOTALTAXEXCRF"] = slipWork.SALESSLIPRF_SALESTOTALTAXEXCRF; // ＵＯＥ伝票合計（税抜き）
                            row["SALESSLIPRF.SALESSUBTOTALTAXINCRF"] = slipWork.SALESSLIPRF_SALESSUBTOTALTAXINCRF; // 売上小計（税込み）
                            row["SALESSLIPRF.SALESSUBTOTALTAXEXCRF"] = slipWork.SALESSLIPRF_SALESSUBTOTALTAXEXCRF; // 売上小計（税抜き）
                            // 2010/11/11 Add >>>
                            row["SALESSLIPRF.SALESSUBTOTALTAXEXCKSGIRF"] = slipWork.SALESSLIPRF_SALESTOTALTAXEXCRF; // 売上小計（税抜き）（春日井用）
                            // 2010/11/11 Add <<<
                            //row["SALESSLIPRF.SALSENETPRICERF"] = slipWork.SALESSLIPRF_SALSENETPRICERF; // 売上正価金額
                            row["SALESSLIPRF.SALESSUBTOTALTAXRF"] = slipWork.SALESSLIPRF_SALESSUBTOTALTAXRF; // 売上小計（税）
                            row["SALESSLIPRF.ITDEDSALESOUTTAXRF"] = slipWork.SALESSLIPRF_ITDEDSALESOUTTAXRF; // 売上外税対象額
                            row["SALESSLIPRF.ITDEDSALESINTAXRF"] = slipWork.SALESSLIPRF_ITDEDSALESINTAXRF; // 売上内税対象額
                            row["SALESSLIPRF.SALSUBTTLSUBTOTAXFRERF"] = slipWork.SALESSLIPRF_SALSUBTTLSUBTOTAXFRERF; // 売上小計非課税対象額
                            //row["SALESSLIPRF.SALSEOUTTAXRF"] = slipWork.SALESSLIPRF_SALSEOUTTAXRF; // 売上金額消費税額（外税）
                            row["SALESSLIPRF.SALAMNTCONSTAXINCLURF"] = slipWork.SALESSLIPRF_SALAMNTCONSTAXINCLURF; // 売上金額消費税額（内税）
                            row["SALESSLIPRF.SALESDISTTLTAXEXCRF"] = slipWork.SALESSLIPRF_SALESDISTTLTAXEXCRF; // 売上値引金額計（税抜き）
                            row["SALESSLIPRF.ITDEDSALESDISOUTTAXRF"] = slipWork.SALESSLIPRF_ITDEDSALESDISOUTTAXRF; // 売上値引外税対象額合計
                            row["SALESSLIPRF.ITDEDSALESDISINTAXRF"] = slipWork.SALESSLIPRF_ITDEDSALESDISINTAXRF; // 売上値引内税対象額合計
                            //row["SALESSLIPRF.ITDEDSALSEDISTAXFRERF"] = slipWork.SALESSLIPRF_ITDEDSALSEDISTAXFRERF; // 売上値引非課税対象額合計
                            row["SALESSLIPRF.SALESDISOUTTAXRF"] = slipWork.SALESSLIPRF_SALESDISOUTTAXRF; // 売上値引消費税額（外税）
                            row["SALESSLIPRF.SALESDISTTLTAXINCLURF"] = slipWork.SALESSLIPRF_SALESDISTTLTAXINCLURF; // 売上値引消費税額（内税）
                            row["SALESSLIPRF.TOTALCOSTRF"] = slipWork.SALESSLIPRF_TOTALCOSTRF; // 原価金額計
                            row["SALESSLIPRF.CONSTAXLAYMETHODRF"] = slipWork.SALESSLIPRF_CONSTAXLAYMETHODRF; // 消費税転嫁方式
                            row["SALESSLIPRF.CONSTAXRATERF"] = slipWork.SALESSLIPRF_CONSTAXRATERF; // 消費税税率
                            row["SALESSLIPRF.FRACTIONPROCCDRF"] = slipWork.SALESSLIPRF_FRACTIONPROCCDRF; // 端数処理区分
                            row["SALESSLIPRF.ACCRECCONSTAXRF"] = slipWork.SALESSLIPRF_ACCRECCONSTAXRF; // 売掛消費税
                            row["SALESSLIPRF.AUTODEPOSITCDRF"] = slipWork.SALESSLIPRF_AUTODEPOSITCDRF; // 自動入金区分
                            row["SALESSLIPRF.AUTODEPOSITSLIPNORF"] = slipWork.SALESSLIPRF_AUTODEPOSITSLIPNORF; // 自動入金伝票番号
                            row["SALESSLIPRF.DEPOSITALLOWANCETTLRF"] = slipWork.SALESSLIPRF_DEPOSITALLOWANCETTLRF; // 入金引当合計額
                            row["SALESSLIPRF.DEPOSITALWCBLNCERF"] = slipWork.SALESSLIPRF_DEPOSITALWCBLNCERF; // 入金引当残高
                            row["SALESSLIPRF.CLAIMCODERF"] = slipWork.SALESSLIPRF_CLAIMCODERF; // 請求先コード
                            row["SALESSLIPRF.CLAIMSNMRF"] = slipWork.SALESSLIPRF_CLAIMSNMRF; // 請求先略称
                            row["SALESSLIPRF.CUSTOMERCODERF"] = slipWork.SALESSLIPRF_CUSTOMERCODERF; // 得意先コード
                            row["SALESSLIPRF.CUSTOMERNAMERF"] = slipWork.SALESSLIPRF_CUSTOMERNAMERF; // 得意先名称
                            row["SALESSLIPRF.CUSTOMERNAME2RF"] = slipWork.SALESSLIPRF_CUSTOMERNAME2RF; // 得意先名称2
                            row["SALESSLIPRF.CUSTOMERSNMRF"] = slipWork.SALESSLIPRF_CUSTOMERSNMRF; // 得意先略称
                            //row["SALESSLIPRF.HONORIFICTITLERF"] = slipWork.SALESSLIPRF_HONORIFICTITLERF; // 敬称
                            row["SALESSLIPRF.ADDRESSEECODERF"] = slipWork.SALESSLIPRF_ADDRESSEECODERF; // 納品先コード
                            row["SALESSLIPRF.ADDRESSEENAMERF"] = slipWork.SALESSLIPRF_ADDRESSEENAMERF; // 納品先名称
                            row["SALESSLIPRF.ADDRESSEENAME2RF"] = slipWork.SALESSLIPRF_ADDRESSEENAME2RF; // 納品先名称2
                            row["SALESSLIPRF.ADDRESSEEPOSTNORF"] = slipWork.SALESSLIPRF_ADDRESSEEPOSTNORF; // 納品先郵便番号
                            row["SALESSLIPRF.ADDRESSEEADDR1RF"] = slipWork.SALESSLIPRF_ADDRESSEEADDR1RF; // 納品先住所1(都道府県市区郡・町村・字)
                            row["SALESSLIPRF.ADDRESSEEADDR3RF"] = slipWork.SALESSLIPRF_ADDRESSEEADDR3RF; // 納品先住所3(番地)
                            row["SALESSLIPRF.ADDRESSEEADDR4RF"] = slipWork.SALESSLIPRF_ADDRESSEEADDR4RF; // 納品先住所4(アパート名称)
                            row["SALESSLIPRF.ADDRESSEETELNORF"] = slipWork.SALESSLIPRF_ADDRESSEETELNORF; // 納品先電話番号
                            row["SALESSLIPRF.ADDRESSEEFAXNORF"] = slipWork.SALESSLIPRF_ADDRESSEEFAXNORF; // 納品先FAX番号
                            row["SALESSLIPRF.PARTYSALESLIPNUMRF"] = slipWork.SALESSLIPRF_PARTYSALESLIPNUMRF; // 相手先伝票番号
                            //-----ADD 2011/08/30----->>>>>
                            int len = 0;
                            if (slipPrtSet.SlipNoteCharCnt == 0)
                            {
                                len = 30 * 2;
                            }
                            else
                            {
                                len = slipPrtSet.SlipNoteCharCnt * 2;
                            }
                            row["SALESSLIPRF.SLIPNOTERF"] = SubStringOfByte(slipWork.SALESSLIPRF_SLIPNOTERF, len);

                            int len1 = 0;
                            if (slipPrtSet.SlipNote2CharCnt == 0)
                            {
                                len1 = 30 * 2;
                            }
                            else
                            {
                                len1 = slipPrtSet.SlipNote2CharCnt * 2;
                            }
                            row["SALESSLIPRF.SLIPNOTE2RF"] = SubStringOfByte(slipWork.SALESSLIPRF_SLIPNOTE2RF, len1);

                            //-----ADD 2011/08/30-----<<<<<
                            //row["SALESSLIPRF.SLIPNOTERF"] = slipWork.SALESSLIPRF_SLIPNOTERF; // 伝票備考// DEL 2011/08/30
                            //row["SALESSLIPRF.SLIPNOTE2RF"] = slipWork.SALESSLIPRF_SLIPNOTE2RF; // 伝票備考２// DEL 2011/08/30
                            row["SALESSLIPRF.RETGOODSREASONDIVRF"] = slipWork.SALESSLIPRF_RETGOODSREASONDIVRF; // 返品理由コード
                            row["SALESSLIPRF.RETGOODSREASONRF"] = slipWork.SALESSLIPRF_RETGOODSREASONRF; // 返品理由
                            row["SALESSLIPRF.REGIPROCDATERF"] = slipWork.SALESSLIPRF_REGIPROCDATERF; // レジ処理日
                            row["SALESSLIPRF.CASHREGISTERNORF"] = slipWork.SALESSLIPRF_CASHREGISTERNORF; // レジ番号
                            row["SALESSLIPRF.POSRECEIPTNORF"] = slipWork.SALESSLIPRF_POSRECEIPTNORF; // POSレシート番号
                            row["SALESSLIPRF.DETAILROWCOUNTRF"] = slipWork.SALESSLIPRF_DETAILROWCOUNTRF; // 明細行数
                            row["SALESSLIPRF.EDISENDDATERF"] = slipWork.SALESSLIPRF_EDISENDDATERF; // ＥＤＩ送信日
                            row["SALESSLIPRF.EDITAKEINDATERF"] = slipWork.SALESSLIPRF_EDITAKEINDATERF; // ＥＤＩ取込日
                            //row["SALESSLIPRF.UOEREMARK1RF"] = slipWork.SALESSLIPRF_UOEREMARK1RF; // ＵＯＥリマーク１
                            //row["SALESSLIPRF.UOEREMARK2RF"] = slipWork.SALESSLIPRF_UOEREMARK2RF; // ＵＯＥリマーク２
                            row["SALESSLIPRF.SLIPPRINTFINISHCDRF"] = slipWork.SALESSLIPRF_SLIPPRINTFINISHCDRF; // 伝票発行済区分
                            row["SALESSLIPRF.SALESSLIPPRINTDATERF"] = slipWork.SALESSLIPRF_SALESSLIPPRINTDATERF; // ＵＯＥ伝票発行日
                            row["SALESSLIPRF.BUSINESSTYPECODERF"] = slipWork.SALESSLIPRF_BUSINESSTYPECODERF; // 業種コード
                            row["SALESSLIPRF.BUSINESSTYPENAMERF"] = slipWork.SALESSLIPRF_BUSINESSTYPENAMERF; // 業種名称
                            row["SALESSLIPRF.ORDERNUMBERRF"] = slipWork.SALESSLIPRF_ORDERNUMBERRF; // 発注番号
                            row["SALESSLIPRF.DELIVEREDGOODSDIVRF"] = slipWork.SALESSLIPRF_DELIVEREDGOODSDIVRF; // 納品区分
                            row["SALESSLIPRF.DELIVEREDGOODSDIVNMRF"] = slipWork.SALESSLIPRF_DELIVEREDGOODSDIVNMRF; // 納品区分名称
                            row["SALESSLIPRF.SALESAREACODERF"] = slipWork.SALESSLIPRF_SALESAREACODERF; // 販売エリアコード
                            row["SALESSLIPRF.SALESAREANAMERF"] = slipWork.SALESSLIPRF_SALESAREANAMERF; // 販売エリア名称
                            //row["SALESSLIPRF.COMPLETECDRF"] = slipWork.SALESSLIPRF_COMPLETECDRF; // 一式伝票区分
                            row["SALESSLIPRF.STOCKGOODSTTLTAXEXCRF"] = slipWork.SALESSLIPRF_STOCKGOODSTTLTAXEXCRF; // 在庫商品合計金額（税抜）
                            row["SALESSLIPRF.PUREGOODSTTLTAXEXCRF"] = slipWork.SALESSLIPRF_PUREGOODSTTLTAXEXCRF; // 純正商品合計金額（税抜）
                            row["SALESSLIPRF.LISTPRICEPRINTDIVRF"] = slipWork.SALESSLIPRF_LISTPRICEPRINTDIVRF; // 定価印刷区分
                            row["SALESSLIPRF.ERANAMEDISPCD1RF"] = slipWork.SALESSLIPRF_ERANAMEDISPCD1RF; // 元号表示区分１
                            row["SALESSLIPRF.ESTIMATAXDIVCDRF"] = slipWork.SALESSLIPRF_ESTIMATAXDIVCDRF; // 見積消費税区分
                            row["SALESSLIPRF.ESTIMATEFORMPRTCDRF"] = slipWork.SALESSLIPRF_ESTIMATEFORMPRTCDRF; // 見積書印刷区分
                            row["SALESSLIPRF.ESTIMATESUBJECTRF"] = slipWork.SALESSLIPRF_ESTIMATESUBJECTRF; // 見積件名
                            row["SALESSLIPRF.FOOTNOTES1RF"] = slipWork.SALESSLIPRF_FOOTNOTES1RF; // 脚注１
                            row["SALESSLIPRF.FOOTNOTES2RF"] = slipWork.SALESSLIPRF_FOOTNOTES2RF; // 脚注２
                            row["SALESSLIPRF.ESTIMATETITLE1RF"] = slipWork.SALESSLIPRF_ESTIMATETITLE1RF; // 見積タイトル１
                            row["SALESSLIPRF.ESTIMATETITLE2RF"] = slipWork.SALESSLIPRF_ESTIMATETITLE2RF; // 見積タイトル２
                            row["SALESSLIPRF.ESTIMATETITLE3RF"] = slipWork.SALESSLIPRF_ESTIMATETITLE3RF; // 見積タイトル３
                            row["SALESSLIPRF.ESTIMATETITLE4RF"] = slipWork.SALESSLIPRF_ESTIMATETITLE4RF; // 見積タイトル４
                            row["SALESSLIPRF.ESTIMATETITLE5RF"] = slipWork.SALESSLIPRF_ESTIMATETITLE5RF; // 見積タイトル５
                            row["SALESSLIPRF.ESTIMATENOTE1RF"] = slipWork.SALESSLIPRF_ESTIMATENOTE1RF; // 見積備考１
                            row["SALESSLIPRF.ESTIMATENOTE2RF"] = slipWork.SALESSLIPRF_ESTIMATENOTE2RF; // 見積備考２
                            row["SALESSLIPRF.ESTIMATENOTE3RF"] = slipWork.SALESSLIPRF_ESTIMATENOTE3RF; // 見積備考３
                            row["SALESSLIPRF.ESTIMATENOTE4RF"] = slipWork.SALESSLIPRF_ESTIMATENOTE4RF; // 見積備考４
                            row["SALESSLIPRF.ESTIMATENOTE5RF"] = slipWork.SALESSLIPRF_ESTIMATENOTE5RF; // 見積備考５
                            row["SECINFOSETRF.SECTIONGUIDENMRF"] = slipWork.SECINFOSETRF_SECTIONGUIDENMRF; // 拠点ガイド名称
                            row["SECINFOSETRF.SECTIONGUIDESNMRF"] = slipWork.SECINFOSETRF_SECTIONGUIDESNMRF; // 拠点ガイド略称
                            row["SECINFOSETRF.COMPANYNAMECD1RF"] = slipWork.SECINFOSETRF_COMPANYNAMECD1RF; // 自社名称コード1
                            row["COMPANYNMRF.COMPANYPRRF"] = slipWork.COMPANYNMRF_COMPANYPRRF; // 自社PR文
                            row["COMPANYNMRF.COMPANYNAME1RF"] = slipWork.COMPANYNMRF_COMPANYNAME1RF; // 自社名称1
                            row["COMPANYNMRF.COMPANYNAME2RF"] = slipWork.COMPANYNMRF_COMPANYNAME2RF; // 自社名称2
                            row["COMPANYNMRF.POSTNORF"] = slipWork.COMPANYNMRF_POSTNORF; // 郵便番号
                            row["COMPANYNMRF.ADDRESS1RF"] = slipWork.COMPANYNMRF_ADDRESS1RF; // 住所1（都道府県市区郡・町村・字）
                            row["COMPANYNMRF.ADDRESS3RF"] = slipWork.COMPANYNMRF_ADDRESS3RF; // 住所3（番地）
                            row["COMPANYNMRF.ADDRESS4RF"] = slipWork.COMPANYNMRF_ADDRESS4RF; // 住所4（アパート名称）
                            row["COMPANYNMRF.COMPANYTELNO1RF"] = slipWork.COMPANYNMRF_COMPANYTELNO1RF; // 自社電話番号1
                            row["COMPANYNMRF.COMPANYTELNO2RF"] = slipWork.COMPANYNMRF_COMPANYTELNO2RF; // 自社電話番号2
                            row["COMPANYNMRF.COMPANYTELNO3RF"] = slipWork.COMPANYNMRF_COMPANYTELNO3RF; // 自社電話番号3
                            row["COMPANYNMRF.COMPANYTELTITLE1RF"] = slipWork.COMPANYNMRF_COMPANYTELTITLE1RF; // 自社電話番号タイトル1
                            row["COMPANYNMRF.COMPANYTELTITLE2RF"] = slipWork.COMPANYNMRF_COMPANYTELTITLE2RF; // 自社電話番号タイトル2
                            row["COMPANYNMRF.COMPANYTELTITLE3RF"] = slipWork.COMPANYNMRF_COMPANYTELTITLE3RF; // 自社電話番号タイトル3
                            row["COMPANYNMRF.TRANSFERGUIDANCERF"] = slipWork.COMPANYNMRF_TRANSFERGUIDANCERF; // 銀行振込案内文
                            row["COMPANYNMRF.ACCOUNTNOINFO1RF"] = slipWork.COMPANYNMRF_ACCOUNTNOINFO1RF; // 銀行口座1
                            row["COMPANYNMRF.ACCOUNTNOINFO2RF"] = slipWork.COMPANYNMRF_ACCOUNTNOINFO2RF; // 銀行口座2
                            row["COMPANYNMRF.ACCOUNTNOINFO3RF"] = slipWork.COMPANYNMRF_ACCOUNTNOINFO3RF; // 銀行口座3
                            row["COMPANYNMRF.COMPANYSETNOTE1RF"] = slipWork.COMPANYNMRF_COMPANYSETNOTE1RF; // 自社設定摘要1
                            row["COMPANYNMRF.COMPANYSETNOTE2RF"] = slipWork.COMPANYNMRF_COMPANYSETNOTE2RF; // 自社設定摘要2
                            row["COMPANYNMRF.IMAGEINFODIVRF"] = slipWork.COMPANYNMRF_IMAGEINFODIVRF; // 画像情報区分
                            row["COMPANYNMRF.IMAGEINFOCODERF"] = slipWork.COMPANYNMRF_IMAGEINFOCODERF; // 画像情報コード
                            row["COMPANYNMRF.COMPANYURLRF"] = slipWork.COMPANYNMRF_COMPANYURLRF; // 自社URL
                            row["COMPANYNMRF.COMPANYPRSENTENCE2RF"] = slipWork.COMPANYNMRF_COMPANYPRSENTENCE2RF; // 自社PR文2
                            row["COMPANYNMRF.IMAGECOMMENTFORPRT1RF"] = slipWork.COMPANYNMRF_IMAGECOMMENTFORPRT1RF; // 画像印字用コメント1
                            row["COMPANYNMRF.IMAGECOMMENTFORPRT2RF"] = slipWork.COMPANYNMRF_IMAGECOMMENTFORPRT2RF; // 画像印字用コメント2
                            row["IMAGEINFORF.IMAGEINFODATARF"] = slipWork.IMAGEINFORF_IMAGEINFODATARF; // 自社画像
                            row["SUBSECTIONRF.SUBSECTIONNAMERF"] = slipWork.SUBSECTIONRF_SUBSECTIONNAMERF; // 部門名称
                            row["EMPINP.KANARF"] = slipWork.EMPINP_KANARF; // 売上入力者カナ
                            row["EMPINP.SHORTNAMERF"] = slipWork.EMPINP_SHORTNAMERF; // 売上入力者短縮名称
                            row["EMPFRT.KANARF"] = slipWork.EMPFRT_KANARF; // 受付従業員カナ
                            row["EMPFRT.SHORTNAMERF"] = slipWork.EMPFRT_SHORTNAMERF; // 受付従業員短縮名称
                            row["EMPSAL.KANARF"] = slipWork.EMPSAL_KANARF; // 販売従業員カナ
                            row["EMPSAL.SHORTNAMERF"] = slipWork.EMPSAL_SHORTNAMERF; // 販売従業員短縮名称
                            row["CSTCLM.CUSTOMERSUBCODERF"] = slipWork.CSTCLM_CUSTOMERSUBCODERF; // 請求先サブコード
                            row["CSTCLM.NAMERF"] = slipWork.CSTCLM_NAMERF; // 請求先名称
                            row["CSTCLM.NAME2RF"] = slipWork.CSTCLM_NAME2RF; // 請求先名称2
                            row["CSTCLM.HONORIFICTITLERF"] = slipWork.CSTCLM_HONORIFICTITLERF; // 請求先敬称
                            row["CSTCLM.KANARF"] = slipWork.CSTCLM_KANARF; // 請求先カナ
                            row["CSTCLM.CUSTOMERSNMRF"] = slipWork.CSTCLM_CUSTOMERSNMRF; // 請求先略称
                            row["CSTCLM.OUTPUTNAMECODERF"] = slipWork.CSTCLM_OUTPUTNAMECODERF; // 請求先諸口コード
                            row["CSTCLM.CUSTANALYSCODE1RF"] = slipWork.CSTCLM_CUSTANALYSCODE1RF; // 請求先分析コード1
                            row["CSTCLM.CUSTANALYSCODE2RF"] = slipWork.CSTCLM_CUSTANALYSCODE2RF; // 請求先分析コード2
                            row["CSTCLM.CUSTANALYSCODE3RF"] = slipWork.CSTCLM_CUSTANALYSCODE3RF; // 請求先分析コード3
                            row["CSTCLM.CUSTANALYSCODE4RF"] = slipWork.CSTCLM_CUSTANALYSCODE4RF; // 請求先分析コード4
                            row["CSTCLM.CUSTANALYSCODE5RF"] = slipWork.CSTCLM_CUSTANALYSCODE5RF; // 請求先分析コード5
                            row["CSTCLM.CUSTANALYSCODE6RF"] = slipWork.CSTCLM_CUSTANALYSCODE6RF; // 請求先分析コード6
                            row["CSTCLM.NOTE1RF"] = slipWork.CSTCLM_NOTE1RF; // 請求先備考1
                            row["CSTCLM.NOTE2RF"] = slipWork.CSTCLM_NOTE2RF; // 請求先備考2
                            row["CSTCLM.NOTE3RF"] = slipWork.CSTCLM_NOTE3RF; // 請求先備考3
                            row["CSTCLM.NOTE4RF"] = slipWork.CSTCLM_NOTE4RF; // 請求先備考4
                            row["CSTCLM.NOTE5RF"] = slipWork.CSTCLM_NOTE5RF; // 請求先備考5
                            row["CSTCLM.NOTE6RF"] = slipWork.CSTCLM_NOTE6RF; // 請求先備考6
                            row["CSTCLM.NOTE7RF"] = slipWork.CSTCLM_NOTE7RF; // 請求先備考7
                            row["CSTCLM.NOTE8RF"] = slipWork.CSTCLM_NOTE8RF; // 請求先備考8
                            row["CSTCLM.NOTE9RF"] = slipWork.CSTCLM_NOTE9RF; // 請求先備考9
                            row["CSTCLM.NOTE10RF"] = slipWork.CSTCLM_NOTE10RF; // 請求先備考10
                            row["CSTCST.CUSTOMERSUBCODERF"] = slipWork.CSTCST_CUSTOMERSUBCODERF; // 得意先サブコード
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.07.21 DEL
                            //row["CSTCST.NAMERF"] = slipWork.CSTCST_NAMERF; // 得意先名称
                            //row["CSTCST.NAME2RF"] = slipWork.CSTCST_NAME2RF; // 得意先名称2
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.07.21 DEL
                            row["CSTCST.HONORIFICTITLERF"] = slipWork.CSTCST_HONORIFICTITLERF; // 得意先敬称
                            row["CSTCST.KANARF"] = slipWork.CSTCST_KANARF; // 得意先カナ
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.07.21 DEL
                            //row["CSTCST.CUSTOMERSNMRF"] = slipWork.CSTCST_CUSTOMERSNMRF; // 得意先略称
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.07.21 DEL
                            row["CSTCST.OUTPUTNAMECODERF"] = slipWork.CSTCST_OUTPUTNAMECODERF; // 得意先諸口コード
                            row["CSTCST.CUSTANALYSCODE1RF"] = slipWork.CSTCST_CUSTANALYSCODE1RF; // 得意先分析コード1
                            row["CSTCST.CUSTANALYSCODE2RF"] = slipWork.CSTCST_CUSTANALYSCODE2RF; // 得意先分析コード2
                            row["CSTCST.CUSTANALYSCODE3RF"] = slipWork.CSTCST_CUSTANALYSCODE3RF; // 得意先分析コード3
                            row["CSTCST.CUSTANALYSCODE4RF"] = slipWork.CSTCST_CUSTANALYSCODE4RF; // 得意先分析コード4
                            row["CSTCST.CUSTANALYSCODE5RF"] = slipWork.CSTCST_CUSTANALYSCODE5RF; // 得意先分析コード5
                            row["CSTCST.CUSTANALYSCODE6RF"] = slipWork.CSTCST_CUSTANALYSCODE6RF; // 得意先分析コード6
                            row["CSTCST.NOTE1RF"] = slipWork.CSTCST_NOTE1RF; // 得意先備考1
                            row["CSTCST.NOTE2RF"] = slipWork.CSTCST_NOTE2RF; // 得意先備考2
                            row["CSTCST.NOTE3RF"] = slipWork.CSTCST_NOTE3RF; // 得意先備考3
                            row["CSTCST.NOTE4RF"] = slipWork.CSTCST_NOTE4RF; // 得意先備考4
                            row["CSTCST.NOTE5RF"] = slipWork.CSTCST_NOTE5RF; // 得意先備考5
                            row["CSTCST.NOTE6RF"] = slipWork.CSTCST_NOTE6RF; // 得意先備考6
                            row["CSTCST.NOTE7RF"] = slipWork.CSTCST_NOTE7RF; // 得意先備考7
                            row["CSTCST.NOTE8RF"] = slipWork.CSTCST_NOTE8RF; // 得意先備考8
                            row["CSTCST.NOTE9RF"] = slipWork.CSTCST_NOTE9RF; // 得意先備考9
                            row["CSTCST.NOTE10RF"] = slipWork.CSTCST_NOTE10RF; // 得意先備考10
                            row["CSTADR.CUSTOMERSUBCODERF"] = slipWork.CSTADR_CUSTOMERSUBCODERF; // 納入先サブコード
                            row["CSTADR.NAMERF"] = slipWork.CSTADR_NAMERF; // 納入先名称
                            row["CSTADR.NAME2RF"] = slipWork.CSTADR_NAME2RF; // 納入先名称2
                            row["CSTADR.HONORIFICTITLERF"] = slipWork.CSTADR_HONORIFICTITLERF; // 納入先敬称
                            row["CSTADR.KANARF"] = slipWork.CSTADR_KANARF; // 納入先カナ
                            row["CSTADR.CUSTOMERSNMRF"] = slipWork.CSTADR_CUSTOMERSNMRF; // 納入先略称
                            row["CSTADR.OUTPUTNAMECODERF"] = slipWork.CSTADR_OUTPUTNAMECODERF; // 納入先諸口コード
                            row["CSTADR.CUSTANALYSCODE1RF"] = slipWork.CSTADR_CUSTANALYSCODE1RF; // 納入先分析コード1
                            row["CSTADR.CUSTANALYSCODE2RF"] = slipWork.CSTADR_CUSTANALYSCODE2RF; // 納入先分析コード2
                            row["CSTADR.CUSTANALYSCODE3RF"] = slipWork.CSTADR_CUSTANALYSCODE3RF; // 納入先分析コード3
                            row["CSTADR.CUSTANALYSCODE4RF"] = slipWork.CSTADR_CUSTANALYSCODE4RF; // 納入先分析コード4
                            row["CSTADR.CUSTANALYSCODE5RF"] = slipWork.CSTADR_CUSTANALYSCODE5RF; // 納入先分析コード5
                            row["CSTADR.CUSTANALYSCODE6RF"] = slipWork.CSTADR_CUSTANALYSCODE6RF; // 納入先分析コード6
                            row["CSTADR.NOTE1RF"] = slipWork.CSTADR_NOTE1RF; // 納入先備考1
                            row["CSTADR.NOTE2RF"] = slipWork.CSTADR_NOTE2RF; // 納入先備考2
                            row["CSTADR.NOTE3RF"] = slipWork.CSTADR_NOTE3RF; // 納入先備考3
                            row["CSTADR.NOTE4RF"] = slipWork.CSTADR_NOTE4RF; // 納入先備考4
                            row["CSTADR.NOTE5RF"] = slipWork.CSTADR_NOTE5RF; // 納入先備考5
                            row["CSTADR.NOTE6RF"] = slipWork.CSTADR_NOTE6RF; // 納入先備考6
                            row["CSTADR.NOTE7RF"] = slipWork.CSTADR_NOTE7RF; // 納入先備考7
                            row["CSTADR.NOTE8RF"] = slipWork.CSTADR_NOTE8RF; // 納入先備考8
                            row["CSTADR.NOTE9RF"] = slipWork.CSTADR_NOTE9RF; // 納入先備考9
                            row["CSTADR.NOTE10RF"] = slipWork.CSTADR_NOTE10RF; // 納入先備考10
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
                            row["HADD.ACPTANODRSTNMRF"] = slipWork.HADD_ACPTANODRSTNMRF; // 受注ステータス名称
                            row["HADD.DEBITNOTEDIVNMRF"] = slipWork.HADD_DEBITNOTEDIVNMRF; // 赤伝区分名称
                            row["HADD.SALESSLIPNMRF"] = slipWork.HADD_SALESSLIPNMRF; // ＵＯＥ伝票区分名称
                            row["HADD.SALESGOODSNMRF"] = slipWork.HADD_SALESGOODSNMRF; // 売上商品区分名称
                            row["HADD.ACCRECDIVNMRF"] = slipWork.HADD_ACCRECDIVNMRF; // 売掛区分名称
                            row["HADD.DELAYPAYMENTDIVNMRF"] = slipWork.HADD_DELAYPAYMENTDIVNMRF; // 来勘区分名称
                            row["HADD.ESTIMATEDIVIDENMRF"] = slipWork.HADD_ESTIMATEDIVIDENMRF; // 見積区分名称
                            row["HADD.CONSTAXLAYMETHODNMRF"] = slipWork.HADD_CONSTAXLAYMETHODNMRF; // 消費税転嫁方式名称
                            row["HADD.AUTODEPOSITNMRF"] = slipWork.HADD_AUTODEPOSITNMRF; // 自動入金区分名称
                            row["HADD.SLIPPRINTFINISHNMRF"] = slipWork.HADD_SLIPPRINTFINISHNMRF; // 伝票発行済区分名称
                            row["HADD.COMPLETENMRF"] = slipWork.HADD_COMPLETENMRF; // 一式伝票区分名称
                            row["HADD.CARMNGNORF"] = slipWork.HADD_CARMNGNORF; // (先頭)車両管理番号
                            row["HADD.CARMNGCODERF"] = slipWork.HADD_CARMNGCODERF; // (先頭)車輌管理コード
                            row["HADD.NUMBERPLATE1CODERF"] = slipWork.HADD_NUMBERPLATE1CODERF; // (先頭)陸運事務所番号
                            row["HADD.NUMBERPLATE1NAMERF"] = slipWork.HADD_NUMBERPLATE1NAMERF; // (先頭)陸運事務局名称
                            row["HADD.NUMBERPLATE2RF"] = slipWork.HADD_NUMBERPLATE2RF; // (先頭)車両登録番号（種別）
                            row["HADD.NUMBERPLATE3RF"] = slipWork.HADD_NUMBERPLATE3RF; // (先頭)車両登録番号（カナ）
                            row["HADD.NUMBERPLATE4RF"] = slipWork.HADD_NUMBERPLATE4RF; // (先頭)車両登録番号（プレート番号）
                            row["HADD.FIRSTENTRYDATERF"] = slipWork.HADD_FIRSTENTRYDATERF; // (先頭)初年度
                            row["HADD.MAKERCODERF"] = slipWork.HADD_MAKERCODERF; // (先頭)メーカーコード
                            row["HADD.MAKERFULLNAMERF"] = slipWork.HADD_MAKERFULLNAMERF; // (先頭)メーカー全角名称
                            row["HADD.MODELCODERF"] = slipWork.HADD_MODELCODERF; // (先頭)車種コード
                            row["HADD.MODELSUBCODERF"] = slipWork.HADD_MODELSUBCODERF; // (先頭)車種サブコード
                            row["HADD.MODELFULLNAMERF"] = slipWork.HADD_MODELFULLNAMERF; // (先頭)車種全角名称
                            row["HADD.EXHAUSTGASSIGNRF"] = slipWork.HADD_EXHAUSTGASSIGNRF; // (先頭)排ガス記号
                            row["HADD.SERIESMODELRF"] = slipWork.HADD_SERIESMODELRF; // (先頭)シリーズ型式
                            row["HADD.CATEGORYSIGNMODELRF"] = slipWork.HADD_CATEGORYSIGNMODELRF; // (先頭)型式（類別記号）
                            row["HADD.FULLMODELRF"] = slipWork.HADD_FULLMODELRF; // (先頭)型式（フル型）
                            row["HADD.MODELDESIGNATIONNORF"] = slipWork.HADD_MODELDESIGNATIONNORF; // (先頭)型式指定番号
                            row["HADD.CATEGORYNORF"] = slipWork.HADD_CATEGORYNORF; // (先頭)類別番号
                            row["HADD.FRAMEMODELRF"] = slipWork.HADD_FRAMEMODELRF; // (先頭)車台型式
                            row["HADD.FRAMENORF"] = slipWork.HADD_FRAMENORF; // (先頭)車台番号
                            row["HADD.SEARCHFRAMENORF"] = slipWork.HADD_SEARCHFRAMENORF; // (先頭)車台番号（検索用）
                            row["HADD.ENGINEMODELNMRF"] = slipWork.HADD_ENGINEMODELNMRF; // (先頭)エンジン型式名称
                            row["HADD.RELEVANCEMODELRF"] = slipWork.HADD_RELEVANCEMODELRF; // (先頭)関連型式
                            row["HADD.SUBCARNMCDRF"] = slipWork.HADD_SUBCARNMCDRF; // (先頭)サブ車名コード
                            row["HADD.MODELGRADESNAMERF"] = slipWork.HADD_MODELGRADESNAMERF; // (先頭)型式グレード略称
                            row["HADD.COLORCODERF"] = slipWork.HADD_COLORCODERF; // (先頭)カラーコード
                            row["HADD.COLORNAME1RF"] = slipWork.HADD_COLORNAME1RF; // (先頭)カラー名称1
                            row["HADD.TRIMCODERF"] = slipWork.HADD_TRIMCODERF; // (先頭)トリムコード
                            row["HADD.TRIMNAMERF"] = slipWork.HADD_TRIMNAMERF; // (先頭)トリム名称
                            row["HADD.MILEAGERF"] = slipWork.HADD_MILEAGERF; // (先頭)車両走行距離
                            row["HADD.PRINTERMNGNORF"] = slipWork.HADD_PRINTERMNGNORF; // プリンタ管理No
                            row["HADD.SLIPPRTSETPAPERIDRF"] = slipWork.HADD_SLIPPRTSETPAPERIDRF; // 伝票印刷設定用帳票ID
                            row["HADD.NOTE1RF"] = slipWork.HADD_NOTE1RF; // 自社備考１
                            row["HADD.NOTE2RF"] = slipWork.HADD_NOTE2RF; // 自社備考２
                            row["HADD.NOTE3RF"] = slipWork.HADD_NOTE3RF; // 自社備考３
                            row["HADD.REISSUEMARKRF"] = slipWork.HADD_REISSUEMARKRF; // 再発行マーク
                            row["HADD.REFCONSTAXPRTNMRF"] = slipWork.HADD_REFCONSTAXPRTNMRF; // 参考消費税印字名称
                            //-----ADD 2011/08/30----->>>>>
                            int len2 = 0;
                            if (slipPrtSet.SlipNote3CharCnt == 0)
                            {
                                len2 = 30 * 2;
                            }
                            else
                            {
                                len2 = slipPrtSet.SlipNote3CharCnt * 2;
                            }
                            row["SALESSLIPRF.SLIPNOTE3RF"] = SubStringOfByte(slipWork.SALESSLIPRF_SLIPNOTE3RF, len2);
                            //-----ADD 2011/08/30-----<<<<<
                            //row["SALESSLIPRF.SLIPNOTE3RF"] = slipWork.SALESSLIPRF_SLIPNOTE3RF; // 伝票備考３// DEL 2011/08/30
                            row["HADD.MAKERHALFNAMERF"] = slipWork.HADD_MAKERHALFNAMERF; // (先頭)メーカー半角名称
                            row["HADD.MODELHALFNAMERF"] = slipWork.HADD_MODELHALFNAMERF; // (先頭)車種半角名称
                            // --- ADD  大矢睦美  2010/05/14 ---------->>>>>
                            //合計粗利金額
                            row["HADD.GROSSPROFITTTLRF"] = slipWork.SALESSLIPRF_SALESSUBTOTALTAXEXCRF - slipWork.SALESSLIPRF_TOTALCOSTRF;
                            //合計粗利率
                            row["HADD.GROSSPROFITRATETTLRF"] = stc_grossProfitCalculator.CalcGrossProfitRate(slipWork.SALESSLIPRF_SALESTOTALTAXEXCRF, slipWork.SALESSLIPRF_TOTALCOSTRF);

                            //ＵＯＥリマーク１(明細)
                            if (index == pageStartIndex)
                            {
                                if (!String.IsNullOrEmpty(slipWork.SALESSLIPRF_UOEREMARK1RF) || !String.IsNullOrEmpty(slipWork.SALESSLIPRF_UOEREMARK2RF))
                                {
                                    row["SALESDETAILRF.UOEREMARK1DETAILRF"] = "C." + slipWork.SALESSLIPRF_UOEREMARK1RF; // ＵＯＥリマーク１
                                }
                                else
                                {
                                    row["SALESDETAILRF.UOEREMARK1DETAILRF"] = DBNull.Value; // ＵＯＥリマーク１
                                }
                            }
                            else
                            {
                                row["SALESDETAILRF.UOEREMARK1DETAILRF"] = DBNull.Value; // ＵＯＥリマーク１
                            }
                            // --- ADD  大矢睦美  2010/05/14 ----------<<<<<
                            # endregion

                            # region [伝票項目(自動以外)]

                            // 未設定時 非印字コード
                            # region [未設定]
                            if (IsZero(slipWork.SALESSLIPRF_SUBSECTIONCODERF)) row["SALESSLIPRF.SUBSECTIONCODERF"] = DBNull.Value; // 部門コード
                            if (IsZero(slipWork.SALESSLIPRF_CLAIMCODERF)) row["SALESSLIPRF.CLAIMCODERF"] = DBNull.Value; // 請求先コード
                            if (IsZero(slipWork.SALESSLIPRF_CUSTOMERCODERF)) row["SALESSLIPRF.CUSTOMERCODERF"] = DBNull.Value; // 得意先コード
                            if (IsZero(slipWork.SALESSLIPRF_ADDRESSEECODERF)) row["SALESSLIPRF.ADDRESSEECODERF"] = DBNull.Value; // 納品先コード
                            if (IsZero(slipWork.SALESSLIPRF_RETGOODSREASONDIVRF)) row["SALESSLIPRF.RETGOODSREASONDIVRF"] = DBNull.Value; // 返品理由コード
                            if (IsZero(slipWork.SALESSLIPRF_BUSINESSTYPECODERF)) row["SALESSLIPRF.BUSINESSTYPECODERF"] = DBNull.Value; // 業種コード
                            if (IsZero(slipWork.SALESSLIPRF_DELIVEREDGOODSDIVRF)) row["SALESSLIPRF.DELIVEREDGOODSDIVRF"] = DBNull.Value; // 納品区分
                            if (IsZero(slipWork.SALESSLIPRF_SALESAREACODERF)) row["SALESSLIPRF.SALESAREACODERF"] = DBNull.Value; // 販売エリアコード
                            if (IsZero(slipWork.HADD_MODELDESIGNATIONNORF)) row["HADD.MODELDESIGNATIONNORF"] = DBNull.Value; // (先頭)型式指定番号
                            if (IsZero(slipWork.HADD_CATEGORYNORF)) row["HADD.CATEGORYNORF"] = DBNull.Value; // (先頭)類別番号
                            if (IsZero(slipWork.HADD_MAKERCODERF)) row["HADD.MAKERCODERF"] = DBNull.Value; // (先頭)メーカーコード
                            if (IsZero(slipWork.HADD_MODELCODERF)) row["HADD.MODELCODERF"] = DBNull.Value; // (先頭)車種コード
                            if (IsZero(slipWork.HADD_MODELSUBCODERF)) row["HADD.MODELSUBCODERF"] = DBNull.Value; // (先頭)車種サブコード
                            if (IsZero(slipWork.HADD_CARMNGNORF)) row["HADD.CARMNGNORF"] = DBNull.Value; // (先頭)車両管理番号
                            if (IsZero(slipWork.HADD_NUMBERPLATE1CODERF)) row["HADD.NUMBERPLATE1CODERF"] = DBNull.Value; // (先頭)陸運事務所番号
                            if (IsZero(slipWork.HADD_NUMBERPLATE4RF)) row["HADD.NUMBERPLATE4RF"] = DBNull.Value; // (先頭)車両登録番号（プレート番号）
                            if (IsZero(slipWork.HADD_FIRSTENTRYDATERF)) row["HADD.FIRSTENTRYDATERF"] = DBNull.Value; // (先頭)初年度
                            if (IsZero(slipWork.HADD_SEARCHFRAMENORF)) row["HADD.SEARCHFRAMENORF"] = DBNull.Value; // (先頭)車台番号（検索用）
                            if (IsZero(slipWork.HADD_SUBCARNMCDRF)) row["HADD.SUBCARNMCDRF"] = DBNull.Value; // (先頭)サブ車名コード
                            if (IsZero(slipWork.SALESSLIPRF_SECTIONCODERF)) row["SALESSLIPRF.SECTIONCODERF"] = DBNull.Value; // 拠点コード
                            if (IsZero(slipWork.SALESSLIPRF_SALESINPUTCODERF)) row["SALESSLIPRF.SALESINPUTCODERF"] = DBNull.Value; // 売上入力者コード
                            if (IsZero(slipWork.SALESSLIPRF_FRONTEMPLOYEECDRF)) row["SALESSLIPRF.FRONTEMPLOYEECDRF"] = DBNull.Value; // 受付従業員コード
                            if (IsZero(slipWork.SALESSLIPRF_SALESEMPLOYEECDRF)) row["SALESSLIPRF.SALESEMPLOYEECDRF"] = DBNull.Value; // 販売従業員コード
                            # endregion

                            // 自社情報
                            # region [自社情報の制御]
                            // 0:自社名印字　1:拠点名印字　2:ビットマップを印字　3:印字しない
                            switch (slipPrtSet.EnterpriseNamePrtCd)
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
                                        // 2010/11/11 Add >>>
                                        row["SECINFOSETRF.SECTIONGUIDESNMRF"] = DBNull.Value; // 拠点ガイド略称
                                        // 2010/11/11 Add <<<
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
                                        // 2010/11/11 Add >>>
                                        row["SECINFOSETRF.SECTIONGUIDESNMRF"] = DBNull.Value; // 拠点ガイド略称
                                        // 2010/11/11 Add <<<
                                    }
                                    break;
                            }
                            // 自社名１分割
                            if (row["COMPANYNMRF.COMPANYNAME1RF"] != DBNull.Value)
                            {
                                string firstHalf;
                                string lastHalf;
                                DivideEnterpriseName((string)row["COMPANYNMRF.COMPANYNAME1RF"], out firstHalf, out lastHalf);
                                row["HADD.PRINTENTERPRISENAME1FHRF"] = firstHalf;
                                row["HADD.PRINTENTERPRISENAME1LHRF"] = lastHalf;
                            }
                            else
                            {
                                row["HADD.PRINTENTERPRISENAME1FHRF"] = DBNull.Value;
                                row["HADD.PRINTENTERPRISENAME1LHRF"] = DBNull.Value;
                            }
                            // 自社名２分割
                            if (row["COMPANYNMRF.COMPANYNAME2RF"] != DBNull.Value)
                            {
                                string firstHalf;
                                string lastHalf;
                                DivideEnterpriseName((string)row["COMPANYNMRF.COMPANYNAME2RF"], out firstHalf, out lastHalf);
                                row["HADD.PRINTENTERPRISENAME2FHRF"] = firstHalf;
                                row["HADD.PRINTENTERPRISENAME2LHRF"] = lastHalf;
                            }
                            else
                            {
                                row["HADD.PRINTENTERPRISENAME2FHRF"] = DBNull.Value;
                                row["HADD.PRINTENTERPRISENAME2LHRF"] = DBNull.Value;
                            }

                            // 【未使用項目(COMPANYINFRF.*)を使用していた場合の対処を追加】
                            row["COMPANYINFRF.COMPANYNAME1RF"] = row["COMPANYNMRF.COMPANYNAME1RF"]; // 自社名称1
                            row["COMPANYINFRF.COMPANYNAME2RF"] = row["COMPANYNMRF.COMPANYNAME2RF"]; // 自社名称2
                            row["COMPANYINFRF.POSTNORF"] = row["COMPANYNMRF.POSTNORF"]; // 郵便番号
                            row["COMPANYINFRF.ADDRESS1RF"] = row["COMPANYNMRF.ADDRESS1RF"]; // 住所1（都道府県市区郡・町村・字）
                            row["COMPANYINFRF.ADDRESS3RF"] = row["COMPANYNMRF.ADDRESS3RF"]; // 住所3（番地）
                            row["COMPANYINFRF.ADDRESS4RF"] = row["COMPANYNMRF.ADDRESS4RF"]; // 住所4（アパート名称）
                            row["COMPANYINFRF.COMPANYTELNO1RF"] = row["COMPANYNMRF.COMPANYTELNO1RF"]; // 自社電話番号1
                            row["COMPANYINFRF.COMPANYTELNO2RF"] = row["COMPANYNMRF.COMPANYTELNO2RF"]; // 自社電話番号2
                            row["COMPANYINFRF.COMPANYTELNO3RF"] = row["COMPANYNMRF.COMPANYTELNO3RF"]; // 自社電話番号3
                            row["COMPANYINFRF.COMPANYTELTITLE1RF"] = row["COMPANYNMRF.COMPANYTELTITLE1RF"]; // 自社電話番号タイトル1
                            row["COMPANYINFRF.COMPANYTELTITLE2RF"] = row["COMPANYNMRF.COMPANYTELTITLE2RF"]; // 自社電話番号タイトル2
                            row["COMPANYINFRF.COMPANYTELTITLE3RF"] = row["COMPANYNMRF.COMPANYTELTITLE3RF"]; // 自社電話番号タイトル3

                            # endregion

                            // 自社備考
                            # region [自社備考]
                            row["HADD.NOTE1RF"] = slipPrtSet.Note1; // 自社備考１
                            row["HADD.NOTE2RF"] = slipPrtSet.Note2; // 自社備考２
                            row["HADD.NOTE3RF"] = slipPrtSet.Note3; // 自社備考３
                            # endregion

                            // 再発行マーク
                            # region [再発行マーク]
                            if (slipPrintParameter.ReissueDiv)
                            {
                                row["HADD.REISSUEMARKRF"] = slipPrtSet.ReissueMark; // 再発行マーク
                            }
                            else
                            {
                                row["HADD.REISSUEMARKRF"] = string.Empty;
                            }
                            # endregion

                            // 消費税印字制御
                            # region [合計部]
                            // 非課税含まない計←非課税含む計で書き換える
                            row["SALESSLIPRF.SALESSUBTOTALTAXINCRF"] = row["SALESSLIPRF.SALESTOTALTAXINCRF"];
                            row["SALESSLIPRF.SALESSUBTOTALTAXEXCRF"] = row["SALESSLIPRF.SALESTOTALTAXEXCRF"];
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.oya 2009/10/05 ADD
                            // U700レイアウト用の合計項目を追加。(印字位置を制御する為)
                            row["HADD.SALESTOTALTAXINCA700RF"] = row["SALESSLIPRF.SALESSUBTOTALTAXINCRF"];
                            row["HADD.SALESTOTALTAXEXCA700RF"] = row["SALESSLIPRF.SALESSUBTOTALTAXEXCRF"];
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.oya 2009/10/05 ADD

                            if (pageIndex == allPageCount - 1)
                            {

                                // 転嫁方式
                                switch (consTaxLayMethod)
                                {
                                    case 0:
                                    case 1:
                                        {
                                            // 伝票転嫁・明細転嫁
                                            row["HADD.REFCONSTAXPRTNMRF"] = DBNull.Value;

                                            // 消費税印字有無(0:しない/1:する)
                                            if (slipPrtSet.ConsTaxPrtCdRF == 1)
                                            {
                                            }
                                            else
                                            {
                                                // 合計欄に小計
                                                row["SALESSLIPRF.SALESTOTALTAXINCRF"] = row["SALESSLIPRF.SALESTOTALTAXEXCRF"];
                                                row["SALESSLIPRF.SALESSUBTOTALTAXINCRF"] = row["SALESSLIPRF.SALESSUBTOTALTAXEXCRF"];
                                                // 小計欄は空白
                                                row["SALESSLIPRF.SALESTOTALTAXEXCRF"] = DBNull.Value;
                                                row["SALESSLIPRF.SALESSUBTOTALTAXEXCRF"] = DBNull.Value;
                                                // 消費税は空白
                                                row["SALESSLIPRF.SALESSUBTOTALTAXRF"] = DBNull.Value;

                                                // 2010/11/11 Add >>>
                                                if (_KSGICustNameFlg)
                                                {
                                                    // 合計欄は空白
                                                    row["SALESSLIPRF.SALESTOTALTAXINCRF"] = DBNull.Value;
                                                    row["SALESSLIPRF.SALESSUBTOTALTAXINCRF"] = DBNull.Value;
                                                }
                                                // 2010/11/11 Add <<<

                                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.oya 2009/10/05 ADD
                                                // U700用
                                                // (合計欄は空白)
                                                row["HADD.SALESTOTALTAXINCA700RF"] = DBNull.Value;
                                                //// (小計欄に小計)
                                                //row["HADD.SALESTOTALTAXEXCA700RF"] = row["HADD.SALESTOTALTAXEXCA700RF"];
                                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.oya 2009/10/05 ADD
                                            }
                                        }
                                        break;
                                    case 2:
                                    case 3:
                                        {
                                            // 請求親・請求子

                                            // 参考消費税印字有無制御(0:しない/1:する)
                                            if (slipPrtSet.RefConsTaxDivCd == 1)
                                            {
                                                // 参考消費税印字名称
                                                row["HADD.REFCONSTAXPRTNMRF"] = slipPrtSet.RefConsTaxPrtNm;
                                                // 合計欄に小計
                                                row["SALESSLIPRF.SALESTOTALTAXINCRF"] = row["SALESSLIPRF.SALESTOTALTAXEXCRF"];
                                                row["SALESSLIPRF.SALESSUBTOTALTAXINCRF"] = row["SALESSLIPRF.SALESSUBTOTALTAXEXCRF"];
                                                // 小計欄は空白
                                                row["SALESSLIPRF.SALESTOTALTAXEXCRF"] = DBNull.Value;
                                                row["SALESSLIPRF.SALESSUBTOTALTAXEXCRF"] = DBNull.Value;

                                                // 2010/11/11 Add >>>
                                                if (_KSGICustNameFlg)
                                                {
                                                    // 合計欄は空白
                                                    row["SALESSLIPRF.SALESTOTALTAXINCRF"] = DBNull.Value;
                                                    row["SALESSLIPRF.SALESSUBTOTALTAXINCRF"] = DBNull.Value;
                                                }
                                                // 2010/11/11 Add <<<

                                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.oya 2009/10/05 ADD
                                                // U700用
                                                // (合計欄は空白)
                                                row["HADD.SALESTOTALTAXINCA700RF"] = DBNull.Value;
                                                //// (小計欄に小計)
                                                //row["HADD.SALESTOTALTAXEXCA700RF"] = row["HADD.SALESTOTALTAXEXCA700RF"];
                                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.oya 2009/10/05 ADD
                                            }
                                            else
                                            {
                                                //// 参考消費税印字名称
                                                //row["HADD.REFCONSTAXPRTNMRF"] = string.Empty;
                                                //// 消費税は空白
                                                //row["SALESSLIPRF.SALESSUBTOTALTAXRF"] = DBNull.Value;
                                                ////row["SALESSLIPRF.SALSEOUTTAXRF"] = DBNull.Value;
                                                //row["SALESSLIPRF.SALAMNTCONSTAXINCLURF"] = DBNull.Value;
                                                //row["SALESSLIPRF.SALESDISOUTTAXRF"] = DBNull.Value;
                                                //row["SALESSLIPRF.SALESDISTTLTAXINCLURF"] = DBNull.Value;

                                                // 参考消費税印字名称
                                                row["HADD.REFCONSTAXPRTNMRF"] = DBNull.Value;
                                                // 合計欄に小計
                                                row["SALESSLIPRF.SALESTOTALTAXINCRF"] = row["SALESSLIPRF.SALESTOTALTAXEXCRF"];
                                                row["SALESSLIPRF.SALESSUBTOTALTAXINCRF"] = row["SALESSLIPRF.SALESSUBTOTALTAXEXCRF"];
                                                // 小計欄は空白
                                                row["SALESSLIPRF.SALESTOTALTAXEXCRF"] = DBNull.Value;
                                                row["SALESSLIPRF.SALESSUBTOTALTAXEXCRF"] = DBNull.Value;
                                                // 消費税は空白
                                                row["SALESSLIPRF.SALESSUBTOTALTAXRF"] = DBNull.Value;

                                                // 2010/11/11 Add >>>
                                                if (_KSGICustNameFlg)
                                                {
                                                    // 合計欄は空白
                                                    row["SALESSLIPRF.SALESTOTALTAXINCRF"] = DBNull.Value;
                                                    row["SALESSLIPRF.SALESSUBTOTALTAXINCRF"] = DBNull.Value;
                                                }
                                                // 2010/11/11 Add <<<

                                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.oya 2009/10/05 ADD
                                                // U700用
                                                // (合計欄は空白)
                                                row["HADD.SALESTOTALTAXINCA700RF"] = DBNull.Value;
                                                //// (小計欄に小計)
                                                //row["HADD.SALESTOTALTAXEXCA700RF"] = row["HADD.SALESTOTALTAXEXCA700RF"];
                                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.oya 2009/10/05 ADD
                                            }
                                        }
                                        break;
                                    case 9:
                                    default:
                                        {
                                            // 非課税

                                            // 合計欄に小計
                                            row["SALESSLIPRF.SALESTOTALTAXINCRF"] = row["SALESSLIPRF.SALESTOTALTAXEXCRF"];
                                            row["SALESSLIPRF.SALESSUBTOTALTAXINCRF"] = row["SALESSLIPRF.SALESSUBTOTALTAXEXCRF"];
                                            // 小計欄は空白
                                            row["SALESSLIPRF.SALESTOTALTAXEXCRF"] = DBNull.Value;
                                            row["SALESSLIPRF.SALESSUBTOTALTAXEXCRF"] = DBNull.Value;

                                            // 参考消費税印字名称
                                            row["HADD.REFCONSTAXPRTNMRF"] = DBNull.Value;
                                            // 消費税は空白
                                            row["SALESSLIPRF.SALESSUBTOTALTAXRF"] = DBNull.Value;
                                            //row["SALESSLIPRF.SALSEOUTTAXRF"] = DBNull.Value;
                                            row["SALESSLIPRF.SALAMNTCONSTAXINCLURF"] = DBNull.Value;
                                            row["SALESSLIPRF.SALESDISOUTTAXRF"] = DBNull.Value;
                                            row["SALESSLIPRF.SALESDISTTLTAXINCLURF"] = DBNull.Value;

                                            // 2010/11/11 Add >>>
                                            if (_KSGICustNameFlg)
                                            {
                                                // 合計欄は空白
                                                row["SALESSLIPRF.SALESTOTALTAXINCRF"] = DBNull.Value;
                                                row["SALESSLIPRF.SALESSUBTOTALTAXINCRF"] = DBNull.Value;
                                            }
                                            // 2010/11/11 Add <<<

                                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.oya 2009/10/05 ADD
                                            // U700用
                                            // (合計欄は空白)
                                            row["HADD.SALESTOTALTAXINCA700RF"] = DBNull.Value;
                                            //// (小計欄に小計)
                                            //row["HADD.SALESTOTALTAXEXCA700RF"] = row["HADD.SALESTOTALTAXEXCA700RF"];
                                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.oya 2009/10/05 ADD
                                        }
                                        break;
                                }
                            }
                            else
                            {
                                // 合計欄
                                row["SALESSLIPRF.SALESTOTALTAXINCRF"] = DBNull.Value;
                                row["SALESSLIPRF.SALESSUBTOTALTAXINCRF"] = DBNull.Value;
                                // 小計欄
                                row["SALESSLIPRF.SALESTOTALTAXEXCRF"] = DBNull.Value;
                                row["SALESSLIPRF.SALESSUBTOTALTAXEXCRF"] = DBNull.Value;
                                // 参考消費税印字名称
                                row["HADD.REFCONSTAXPRTNMRF"] = DBNull.Value;
                                // 消費税
                                row["SALESSLIPRF.SALESSUBTOTALTAXRF"] = DBNull.Value;
                                row["SALESSLIPRF.SALAMNTCONSTAXINCLURF"] = DBNull.Value;
                                row["SALESSLIPRF.SALESDISOUTTAXRF"] = DBNull.Value;
                                row["SALESSLIPRF.SALESDISTTLTAXINCLURF"] = DBNull.Value;

                                // 2010/11/11 Add >>>
                                if (_KSGICustNameFlg)
                                {
                                    // 合計欄は空白
                                    row["SALESSLIPRF.SALESSUBTOTALTAXEXCKSGIRF"] = DBNull.Value;
                                }
                                // 2010/11/11 Add <<<

                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.oya 2009/10/05 ADD
                                // U700用
                                row["HADD.SALESTOTALTAXINCA700RF"] = DBNull.Value;
                                row["HADD.SALESTOTALTAXEXCA700RF"] = DBNull.Value;
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.oya 2009/10/05 ADD
                            }
                            # endregion

                            // 敬称の制御
                            # region [敬称]
                            // 伝票印刷設定の内容で差し替える（得意先マスタ優先）
                            if (slipWork.CSTCLM_HONORIFICTITLERF.Trim() == string.Empty) row["CSTCLM.HONORIFICTITLERF"] = slipPrtSet.HonorificTitle;
                            if (slipWork.CSTCST_HONORIFICTITLERF.Trim() == string.Empty) row["CSTCST.HONORIFICTITLERF"] = slipPrtSet.HonorificTitle;
                            if (slipWork.CSTADR_HONORIFICTITLERF.Trim() == string.Empty) row["CSTADR.HONORIFICTITLERF"] = slipPrtSet.HonorificTitle;
                            // 売上データの敬称は使わず、得意先敬称で書き換える
                            row["SALESSLIPRF.HONORIFICTITLERF"] = row["CSTCST.HONORIFICTITLERF"]; // 敬称
                            # endregion

                            // 印刷時刻 (0:非印字,1:印字)
                            # region [印刷時刻]
                            if (slipPrtSet.TimePrintDivCd != 0)
                            {
                                // 印字
                                row["HADD.PRINTTIMEHOURRF"] = slipWork.HADD_PRINTTIMEHOURRF;
                                row["HADD.PRINTTIMEMINUTERF"] = slipWork.HADD_PRINTTIMEMINUTERF;
                                row["HADD.PRINTTIMESECONDRF"] = slipWork.HADD_PRINTTIMESECONDRF;
                                row[ct_ReceiveTimeHour] = receiveTimeHour;
                                row[ct_ReceiveTimeMinute] = receiveTimeMinute;
                                row[ct_ReceiveTimeSecond] = receiveTimeSecond;

                                if (titleDic.ContainsKey(ct_ReceiveTimeLabel))
                                {
                                    row[ct_ReceiveTimeLabel] = titleDic[ct_ReceiveTimeLabel];
                                }
                                else
                                {
                                    row[ct_ReceiveTimeLabel] = ":";
                                }
                            }
                            else
                            {
                                // 非印字
                                row["HADD.PRINTTIMEHOURRF"] = DBNull.Value;
                                row["HADD.PRINTTIMEMINUTERF"] = DBNull.Value;
                                row["HADD.PRINTTIMESECONDRF"] = DBNull.Value;
                                row[ct_ReceiveTimeHour] = DBNull.Value;
                                row[ct_ReceiveTimeMinute] = DBNull.Value;
                                row[ct_ReceiveTimeSecond] = DBNull.Value;
                                row[ct_ReceiveTimeLabel] = DBNull.Value;
                            }
                            # endregion

                            // 日付項目展開
                            # region [日付項目]
                            // 通常
                            ExtractDate(ref row, allDefSet.EraNameDispCd2, slipWork.SALESSLIPRF_SEARCHSLIPDATERF, "HADD.SEARCHSLIPDATE", false); // yyyymmdd
                            ExtractDate(ref row, allDefSet.EraNameDispCd2, slipWork.SALESSLIPRF_SHIPMENTDAYRF, "HADD.SHIPMENTDAY", false);// yyyymmdd
                            ExtractDate(ref row, allDefSet.EraNameDispCd2, slipWork.SALESSLIPRF_SALESDATERF, "HADD.SALESDATE", false);// yyyymmdd
                            ExtractDate(ref row, allDefSet.EraNameDispCd2, slipWork.SALESSLIPRF_ADDUPADATERF, "HADD.ADDUPADATE", false);// yyyymmdd
                            ExtractDate(ref row, allDefSet.EraNameDispCd2, slipWork.SALESSLIPRF_SALESSLIPPRINTDATERF, "HADD.SALESSLIPPRINTDATE", false);// yyyymmdd
                            // 年式
                            ExtractDate(ref row, allDefSet.EraNameDispCd1, slipWork.HADD_FIRSTENTRYDATERF, "HADD.FIRSTENTRYDATE", true);// yyyymm
                            # endregion

                            // 印刷用得意先名称
                            # region [印刷用得意先名称]
                            // 0:売掛なし,1:売掛
                            if (slipWork.SALESSLIPRF_ACCRECDIVCDRF != 0)
                            {
                                //-----------------------------------------------------------
                                // 売掛
                                //-----------------------------------------------------------
                                if (slipWork.SALESSLIPRF_CUSTOMERNAME2RF != null && slipWork.SALESSLIPRF_CUSTOMERNAME2RF.Trim() != string.Empty)
                                {
                                    // 上段：名称１
                                    row["HADD.PRINTCUSTOMERNAME1RF"] = slipWork.SALESSLIPRF_CUSTOMERNAMERF;
                                    // 下段：名称２
                                    row["HADD.PRINTCUSTOMERNAME2RF"] = slipWork.SALESSLIPRF_CUSTOMERNAME2RF;
                                    // 下段：名称２＋スペース＋敬称
                                    row["HADD.PRINTCUSTOMERNAME2HNRF"] = slipWork.SALESSLIPRF_CUSTOMERNAME2RF + "　" + (string)row["CSTCST.HONORIFICTITLERF"];
                                }
                                else
                                {
                                    // 上段：空白
                                    row["HADD.PRINTCUSTOMERNAME1RF"] = DBNull.Value;
                                    // 下段：名称１
                                    row["HADD.PRINTCUSTOMERNAME2RF"] = slipWork.SALESSLIPRF_CUSTOMERNAMERF;
                                    // 下段：名称１＋スペース＋敬称
                                    row["HADD.PRINTCUSTOMERNAME2HNRF"] = slipWork.SALESSLIPRF_CUSTOMERNAMERF + "　" + (string)row["CSTCST.HONORIFICTITLERF"];
                                }

                                // 名称１＋名称２
                                row["HADD.PRINTCUSTOMERNAMEJOIN12RF"] = slipWork.SALESSLIPRF_CUSTOMERNAMERF + slipWork.SALESSLIPRF_CUSTOMERNAME2RF;
                                // 名称１＋名称２＋空白＋敬称
                                row["HADD.PRINTCUSTOMERNAMEJOIN12HNRF"] = (string)row["HADD.PRINTCUSTOMERNAMEJOIN12RF"] + "　" + (string)row["CSTCST.HONORIFICTITLERF"];

                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.07.21 ADD
                                // 得意先名(売上データの内容で統一する)
                                row["CSTCST.NAMERF"] = slipWork.SALESSLIPRF_CUSTOMERNAMERF;
                                row["CSTCST.NAME2RF"] = slipWork.SALESSLIPRF_CUSTOMERNAME2RF;
                                row["CSTCST.CUSTOMERSNMRF"] = slipWork.SALESSLIPRF_CUSTOMERSNMRF;
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.07.21 ADD

                                // 2011/05/27 Add >>>
                                // 名称１＋名称２＋空白＋敬称（バイト計算）
                                // 得意先名称１＋得意先名所２を40バイトまで取得
                                string printCustNameJoin12OfByte = (string)row["HADD.PRINTCUSTOMERNAMEJOIN12RF"];
                                printCustNameJoin12OfByte = SubStringOfByte(printCustNameJoin12OfByte, 40).TrimEnd();
                                row["HADD.PRINTCUSTNAMEJOIN12HNOFBYTERF"] = printCustNameJoin12OfByte + "　" + (string)row["CSTCST.HONORIFICTITLERF"];
                                // 2011/05/27 Add <<<
                            }
                            else
                            {
                                //-----------------------------------------------------------
                                // 現金売り
                                //-----------------------------------------------------------

                                // 名称１←伝票上の略称セット
                                row["SALESSLIPRF.CUSTOMERNAMERF"] = slipWork.SALESSLIPRF_CUSTOMERSNMRF;
                                row["CSTCST.NAMERF"] = slipWork.SALESSLIPRF_CUSTOMERSNMRF;

                                // 名称２←空白
                                row["SALESSLIPRF.CUSTOMERNAME2RF"] = DBNull.Value;
                                row["CSTCST.NAME2RF"] = DBNull.Value;

                                // 略称←伝票上の略称セット
                                row["CSTCST.CUSTOMERSNMRF"] = slipWork.SALESSLIPRF_CUSTOMERSNMRF;

                                // ｶﾅ←空白
                                row["CSTCST.KANARF"] = DBNull.Value;

                                // 上段：空白
                                row["HADD.PRINTCUSTOMERNAME1RF"] = DBNull.Value;
                                // 下段：略称
                                row["HADD.PRINTCUSTOMERNAME2RF"] = slipWork.SALESSLIPRF_CUSTOMERSNMRF;
                                // 下段：略称＋スペース＋敬称
                                row["HADD.PRINTCUSTOMERNAME2HNRF"] = slipWork.SALESSLIPRF_CUSTOMERSNMRF + "　" + (string)row["CSTCST.HONORIFICTITLERF"];

                                // (名称１＋名称２)（←略称セット）
                                row["HADD.PRINTCUSTOMERNAMEJOIN12RF"] = slipWork.SALESSLIPRF_CUSTOMERSNMRF;
                                // (名称１＋名称２)（←略称セット）＋空白＋敬称
                                row["HADD.PRINTCUSTOMERNAMEJOIN12HNRF"] = slipWork.SALESSLIPRF_CUSTOMERSNMRF + "　" + (string)row["CSTCST.HONORIFICTITLERF"];

                                // 2011/05/27 Add >>>
                                // 名称１＋名称２（バイト計算）（←略称セット）＋空白＋敬称
                                row["HADD.PRINTCUSTNAMEJOIN12HNOFBYTERF"] = slipWork.SALESSLIPRF_CUSTOMERSNMRF + "　" + (string)row["CSTCST.HONORIFICTITLERF"];
                                // 2011/05/27 Add <<<
                            }
                            # endregion

                            // 類別型式ハイフン
                            # region [類別型式ハイフン]
                            if (slipWork.HADD_CATEGORYNORF == 0 && slipWork.HADD_MODELDESIGNATIONNORF == 0)
                            {
                                row[ct_HCategoryHyp] = DBNull.Value;
                            }
                            else
                            {
                                row[ct_HCategoryHyp] = "-";
                            }
                            # endregion

                            // 半角名項目対応
                            # region [半角名項目対応]
                            // ※「…半角名」項目が空白の場合「…全角名」の内容をセットする（車種名を手入力した場合など）
                            if (string.IsNullOrEmpty(slipWork.HADD_MAKERHALFNAMERF))
                            {
                                row["HADD.MAKERHALFNAMERF"] = slipWork.HADD_MAKERFULLNAMERF; // (先頭)メーカー半角名称←全角名セット
                            }
                            if (string.IsNullOrEmpty(slipWork.HADD_MODELHALFNAMERF))
                            {
                                row["HADD.MODELHALFNAMERF"] = slipWork.HADD_MODELFULLNAMERF; // (先頭)車種半角名称←全角名セット
                            }
                            # endregion

                            // リマーク１・２
                            # region [リマーク１・２]
                            if (!String.IsNullOrEmpty(slipWork.SALESSLIPRF_UOEREMARK1RF) || !String.IsNullOrEmpty(slipWork.SALESSLIPRF_UOEREMARK2RF))
                            {
                                row["SALESSLIPRF.UOEREMARK1RF"] = "C." + slipWork.SALESSLIPRF_UOEREMARK1RF; // ＵＯＥリマーク１
                                row["SALESSLIPRF.UOEREMARK2RF"] = slipWork.SALESSLIPRF_UOEREMARK2RF; // ＵＯＥリマーク２
                            }
                            else
                            {
                                row["SALESSLIPRF.UOEREMARK1RF"] = DBNull.Value; // ＵＯＥリマーク１
                                row["SALESSLIPRF.UOEREMARK2RF"] = DBNull.Value; // ＵＯＥリマーク２
                            }
                            # endregion

                            // 縦倍角対応
                            # region [縦倍角対応]
                            // ※これ以前の処理でrowにセットした内容を使用します。

                            // 文字サイズ (0:標準,1:大)
                            if (slipPrtSet.SlipFontSize == 0)
                            {
                                // 標準
                                row["HLG.CUSTOMERNAMERF"] = DBNull.Value;  // 【縦倍】得意先名称
                                row["HLG.CUSTOMERNAME2RF"] = DBNull.Value;  //【縦倍】 得意先名称2
                                row["HLG.CUSTOMERSNMRF"] = DBNull.Value;  // 【縦倍】得意先略称
                                row["HLG.HONORIFICTITLERF"] = DBNull.Value;  // 【縦倍】敬称
                                row["HLG.PRINTCUSTOMERNAMEJOIN12RF"] = DBNull.Value; //【縦倍】得意先名１＋得意先名２
                                row["HLG.PRINTCUSTOMERNAMEJOIN12HNRF"] = DBNull.Value; // 【縦倍】得意先名１＋得意先名２＋敬称
                                // 2011/05/27 Add >>>
                                row["HLG.PRINTCUSTNAMEJOIN12HNOFBYTERF"] = DBNull.Value; //（縦倍）得意先名称１＋得意先名称２＋敬称（バイト計算）
                                // 2011/05/27 Add <<<
                            }
                            else
                            {
                                // 縦倍角
                                row["HLG.CUSTOMERNAMERF"] = row["SALESSLIPRF.CUSTOMERNAMERF"];  // 【縦倍】得意先名称
                                row["HLG.CUSTOMERNAME2RF"] = row["SALESSLIPRF.CUSTOMERNAME2RF"];  //【縦倍】 得意先名称2
                                row["HLG.CUSTOMERSNMRF"] = row["SALESSLIPRF.CUSTOMERSNMRF"];  // 【縦倍】得意先略称
                                row["HLG.HONORIFICTITLERF"] = row["SALESSLIPRF.HONORIFICTITLERF"];  // 【縦倍】敬称
                                row["HLG.PRINTCUSTOMERNAMEJOIN12RF"] = row["HADD.PRINTCUSTOMERNAMEJOIN12RF"]; //【縦倍】得意先名１＋得意先名２
                                row["HLG.PRINTCUSTOMERNAMEJOIN12HNRF"] = row["HADD.PRINTCUSTOMERNAMEJOIN12HNRF"]; // 【縦倍】得意先名１＋得意先名２＋敬称
                                // 2011/05/27 Add >>>
                                row["HLG.PRINTCUSTNAMEJOIN12HNOFBYTERF"] = row["HADD.PRINTCUSTNAMEJOIN12HNOFBYTERF"]; //（縦倍）得意先名称１＋得意先名称２＋敬称（バイト計算）
                                // 2011/05/27 Add <<<

                                row["SALESSLIPRF.CUSTOMERNAMERF"] = DBNull.Value;  // 得意先名称
                                row["SALESSLIPRF.CUSTOMERNAME2RF"] = DBNull.Value;  //得意先名称2
                                row["SALESSLIPRF.CUSTOMERSNMRF"] = DBNull.Value;  // 得意先略称
                                row["SALESSLIPRF.HONORIFICTITLERF"] = DBNull.Value;  // 敬称
                                row["HADD.PRINTCUSTOMERNAMEJOIN12RF"] = DBNull.Value; //得意先名１＋得意先名２
                                row["HADD.PRINTCUSTOMERNAMEJOIN12HNRF"] = DBNull.Value; // 得意先名１＋得意先名２＋敬称
                                row["CSTCST.NAMERF"] = DBNull.Value;  // 得意先名称
                                row["CSTCST.NAME2RF"] = DBNull.Value;  // 得意先名称2
                                row["CSTCST.HONORIFICTITLERF"] = DBNull.Value;  // 得意先敬称
                                row["CSTCST.CUSTOMERSNMRF"] = DBNull.Value;  // 得意先略称
                                row["CSTCST.HONORIFICTITLERF"] = DBNull.Value;  // 敬称
                                // 2011/05/27 Add >>>
                                row["HADD.PRINTCUSTNAMEJOIN12HNOFBYTERF"] = DBNull.Value; //（縦倍）得意先名称１＋得意先名称２＋敬称（バイト計算）
                                // 2011/05/27 Add <<<
                            }
                            
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.07.21 ADD
                            // 自社名縦倍角(印字制御なしなので、常にコピー)
                            row["HLG.COMPANYNAME1RF"] = row["COMPANYNMRF.COMPANYNAME1RF"];
                            row["HLG.COMPANYNAME2RF"] = row["COMPANYNMRF.COMPANYNAME2RF"];
                            row["HLG.PRINTENTERPRISENAME1FHRF"] = row["HADD.PRINTENTERPRISENAME1FHRF"];
                            row["HLG.PRINTENTERPRISENAME1LHRF"] = row["HADD.PRINTENTERPRISENAME1LHRF"];
                            row["HLG.PRINTENTERPRISENAME2FHRF"] = row["HADD.PRINTENTERPRISENAME2FHRF"];
                            row["HLG.PRINTENTERPRISENAME2LHRF"] = row["HADD.PRINTENTERPRISENAME2LHRF"];
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.07.21 ADD
                            // --- UPD  2011/02/16 ---------->>>>>
                            //自社名印字(0:標準,1:大)
                            if (slipPrtSet.EntNmPrtExpDiv == 0)
                            {
                                // 標準
                                SettingKmk(row, columnVisibleTypeDic, "COMPANYNMRF.COMPANYNAME1RF", "HLG.COMPANYNAME1RF");
                                SettingKmk(row, columnVisibleTypeDic, "HADD.PRINTENTERPRISENAME1FHRF", "HLG.PRINTENTERPRISENAME1FHRF");
                                SettingKmk(row, columnVisibleTypeDic, "HADD.PRINTENTERPRISENAME1LHRF", "HLG.PRINTENTERPRISENAME1LHRF");

                                SettingKmk(row, columnVisibleTypeDic, "COMPANYNMRF.COMPANYNAME2RF", "HLG.COMPANYNAME2RF");
                                SettingKmk(row, columnVisibleTypeDic, "HADD.PRINTENTERPRISENAME2FHRF", "HLG.PRINTENTERPRISENAME2FHRF");
                                SettingKmk(row, columnVisibleTypeDic, "HADD.PRINTENTERPRISENAME2LHRF", "HLG.PRINTENTERPRISENAME2LHRF");
                            }
                            else
                            {
                                // 大
                                SettingKmk(row, columnVisibleTypeDic, "HLG.COMPANYNAME1RF", "COMPANYNMRF.COMPANYNAME1RF");
                                SettingKmk(row, columnVisibleTypeDic, "HLG.PRINTENTERPRISENAME1FHRF", "HADD.PRINTENTERPRISENAME1FHRF");
                                SettingKmk(row, columnVisibleTypeDic, "HLG.PRINTENTERPRISENAME1LHRF", "HADD.PRINTENTERPRISENAME1LHRF");

                                SettingKmk(row, columnVisibleTypeDic, "HLG.COMPANYNAME2RF", "COMPANYNMRF.COMPANYNAME2RF");
                                SettingKmk(row, columnVisibleTypeDic, "HLG.PRINTENTERPRISENAME2FHRF", "HADD.PRINTENTERPRISENAME2FHRF");
                                SettingKmk(row, columnVisibleTypeDic, "HLG.PRINTENTERPRISENAME2LHRF", "HADD.PRINTENTERPRISENAME2LHRF");
                            }
                            // --- UPD  2011/02/16 ----------<<<<<
                            # endregion

                            // --- ADD m.suzuki 2010/03/24 ---------->>>>>
                            // ＱＲコード
                            # region [ＱＲコード]
                            if ( uoeSales.slipCd != (int)UoeSales.ctSlipCd.ct_Zero && inPageCopyCount == 0)
                            {
                                // ゼロ伝以外かつ
                                // 上段(inPageCopyCount=0)のみ印刷する
                                row[ct_QRCode] = qrData;
                                row[ct_QRCodeSource] = qrDataSource;
                            }
                            else
                            {
                                row[ct_QRCode] = string.Empty;
                                row[ct_QRCodeSource] = string.Empty;
                            }
                            # endregion
                            // --- ADD m.suzuki 2010/03/24 ----------<<<<<

                            // UOE専用項目
                            # region[UOE専用項目]
                            row["HUOE.SLIPCDRF"] = uoeSales.slipCd; // UOE伝票種別
                            row["HUOE.SLIPCDNMRF"] = GetHUOE_SLIPCDNM(uoeSales.slipCd); // UOE伝票種別名
                            row["HUOE.TOTALCNTRF"] = uoeSales.totalCnt; // 出庫数合計
                            if (uoeSales.uoeSalesDetailList.Count > 0 && uoeSales.uoeSalesDetailList[0].prtSalesDetail != null)
                            {
                                //row["HUOE.BOCODERF"] = uoeSales.uoeSalesDetailList[0].uOEOrderDtlWork.BoCode; // (先頭)BO区分
                                //row["HUOE.UOEDELIGOODSDIVRF"] = uoeSales.uoeSalesDetailList[0].uOEOrderDtlWork.UOEDeliGoodsDiv; // (先頭)UOE納品区分
                                //row["HUOE.DELIVEREDGOODSDIVNMRF"] = uoeSales.uoeSalesDetailList[0].uOEOrderDtlWork.DeliveredGoodsDivNm; // (先頭)納品区分名称
                                //row["HUOE.FOLLOWDELIGOODSDIVRF"] = uoeSales.uoeSalesDetailList[0].uOEOrderDtlWork.FollowDeliGoodsDiv; // (先頭)フォロー納品区分
                                //row["HUOE.FOLLOWDELIGOODSDIVNMRF"] = uoeSales.uoeSalesDetailList[0].uOEOrderDtlWork.FollowDeliGoodsDivNm; // (先頭)フォロー納品区分名称
                                row["HUOE.BOCODERF"] = uoeSales.uoeSalesDetailList[0].prtSalesDetail.prtBoCode; // (先頭)BO区分
                                row["HUOE.UOEDELIGOODSDIVRF"] = uoeSales.uoeSalesDetailList[0].prtSalesDetail.prtUOEDeliGoodsDiv; // (先頭)UOE納品区分
                                row["HUOE.DELIVEREDGOODSDIVNMRF"] = uoeSales.uoeSalesDetailList[0].prtSalesDetail.prtDeliveredGoodsDivNm; // (先頭)納品区分名称
                                row["HUOE.FOLLOWDELIGOODSDIVRF"] = uoeSales.uoeSalesDetailList[0].prtSalesDetail.prtFollowDeliGoodsDiv; // (先頭)フォロー納品区分
                                row["HUOE.FOLLOWDELIGOODSDIVNMRF"] = uoeSales.uoeSalesDetailList[0].prtSalesDetail.prtFollowDeliGoodsDivNm; // (先頭)フォロー納品区分名称
                            }
                            else
                            {
                                row["HUOE.BOCODERF"] = DBNull.Value; // (先頭)BO区分
                                row["HUOE.UOEDELIGOODSDIVRF"] = DBNull.Value; // (先頭)UOE納品区分
                                row["HUOE.DELIVEREDGOODSDIVNMRF"] = DBNull.Value; // (先頭)納品区分名称
                                row["HUOE.FOLLOWDELIGOODSDIVRF"] = DBNull.Value; // (先頭)フォロー納品区分
                                row["HUOE.FOLLOWDELIGOODSDIVNMRF"] = DBNull.Value; // (先頭)フォロー納品区分名称
                            }

                            // ｾﾞﾛ伝票の伝票番号
                            if (uoeSales.slipCd == (int)UoeSales.ctSlipCd.ct_Zero)
                            {
                                row["SALESSLIPRF.SALESSLIPNUMRF"] = ct_ZeroSlipNoText;
                            }
                            # endregion

                            // --- ADD 3H 楊善娟 2017/08/30---------->>>>>
                            #region「ハンディ対応（2次）」
                            // ｾﾞﾛ伝票の場合
                            if (uoeSales.slipCd == (int)UoeSales.ctSlipCd.ct_Zero)
                            {
                                // バーコード（伝票番号）
                                row["HPRT.BARCDSALESSLNUMRF"] = "*" + "000000000" + "*";
                            }
                            else
                            {
                                // バーコード（伝票番号）
                                row["HPRT.BARCDSALESSLNUMRF"] = "*" + slipWork.SALESSLIPRF_SALESSLIPNUMRF + "*";
                            }
                            #endregion
                            // --- ADD 3H 楊善娟 2017/08/30----------<<<<<

                            # endregion

                            # region [伝票項目(伝票タイプ別設定)]
                            // 担当者
                            if (eachSlipTypeSet.SalesEmployee == 0)
                            {
                                row["SALESSLIPRF.SALESEMPLOYEECDRF"] = DBNull.Value; // 販売従業員コード
                                row["SALESSLIPRF.SALESEMPLOYEENMRF"] = DBNull.Value; // 販売従業員名称
                                row["EMPSAL.KANARF"] = DBNull.Value; // 販売従業員カナ
                                row["EMPSAL.SHORTNAMERF"] = DBNull.Value; // 販売従業員短縮名称
                            }
                            // 受注者
                            if (eachSlipTypeSet.FrontEmployee == 0)
                            {
                                row["SALESSLIPRF.FRONTEMPLOYEECDRF"] = DBNull.Value; // 受付従業員コード
                                row["SALESSLIPRF.FRONTEMPLOYEENMRF"] = DBNull.Value; // 受付従業員名称
                                row["EMPFRT.KANARF"] = DBNull.Value; // 受付従業員カナ
                                row["EMPFRT.SHORTNAMERF"] = DBNull.Value; // 受付従業員短縮名称
                            }
                            // 発行者
                            if (eachSlipTypeSet.SalesInput == 0)
                            {
                                row["SALESSLIPRF.SALESINPUTCODERF"] = DBNull.Value; // 売上入力者コード
                                row["SALESSLIPRF.SALESINPUTNAMERF"] = DBNull.Value; // 売上入力者名称
                                row["EMPINP.KANARF"] = DBNull.Value; // 売上入力者カナ
                                row["EMPINP.SHORTNAMERF"] = DBNull.Value; // 売上入力者短縮名称
                            }
                            // 売価
                            if (eachSlipTypeSet.SalesPrice == 0)
                            {
                                row["SALESSLIPRF.SALESTOTALTAXINCRF"] = DBNull.Value;
                                row["SALESSLIPRF.SALESSUBTOTALTAXINCRF"] = DBNull.Value;
                                row["SALESSLIPRF.SALESTOTALTAXEXCRF"] = DBNull.Value;
                                row["SALESSLIPRF.SALESSUBTOTALTAXEXCRF"] = DBNull.Value;
                                row["HADD.REFCONSTAXPRTNMRF"] = DBNull.Value;
                                row["SALESSLIPRF.SALESSUBTOTALTAXRF"] = DBNull.Value;
                                //row["SALESSLIPRF.SALSEOUTTAXRF"] = DBNull.Value;
                                row["SALESSLIPRF.SALAMNTCONSTAXINCLURF"] = DBNull.Value;
                                row["SALESSLIPRF.SALESDISOUTTAXRF"] = DBNull.Value;
                                row["SALESSLIPRF.SALESDISTTLTAXINCLURF"] = DBNull.Value;
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.oya 2009/10/05 ADD
                                row["HADD.SALESTOTALTAXINCA700RF"] = DBNull.Value;
                                row["HADD.SALESTOTALTAXEXCA700RF"] = DBNull.Value;
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.oya 2009/10/05 ADD
                                // 2010/11/11 Add >>>
                                if (_KSGICustNameFlg)
                                {
                                    // 合計欄は空白
                                    row["SALESSLIPRF.SALESSUBTOTALTAXEXCKSGIRF"] = DBNull.Value;
                                }
                                // 2010/11/11 Add <<<
                            }
                            # endregion

                            // --- ADD 2009.07.24 劉洋 ------ >>>>>>
                            #region

                            if (slipWork.SANDESETTINGRF_CUSTOMERCODE != 0)
                            {
                                // AB住電管理コード
                                row["SANDESETTINGRF.SANDEMNGCODERF"] = slipWork.SANDESETTINGRF_SANDEMNGCODE;
                                // AB納品者名
                                row["SANDESETTINGRF.DELIVERERNMRF"] = slipWork.SANDESETTINGRF_DELIVERERNM;
                                // AB納品者住所
                                row["SANDESETTINGRF.DELIVERERADDRESSRF"] = slipWork.SANDESETTINGRF_DELIVERERADDRESS;
                            }
                            else
                            {
                                // AB住電管理コード
                                row["SANDESETTINGRF.SANDEMNGCODERF"] = 0;
                                // AB納品者名
                                row["SANDESETTINGRF.DELIVERERNMRF"] = string.Empty;
                                // AB納品者住所
                                row["SANDESETTINGRF.DELIVERERADDRESSRF"] = string.Empty;
                            }

                            // AB納品者ＴＥＬ
                            if (slipWork.SANDESETTINGRF_CUSTOMERCODE != 0)
                            {
                                if (string.IsNullOrEmpty(slipWork.SANDESETTINGRF_DELIVERERPHONENUM))
                                {
                                    row["SANDESETTINGRF.DELIVERERPHONENUMRF"] = string.Empty;
                                }
                                else
                                {
                                    row["SANDESETTINGRF.DELIVERERPHONENUMRF"] = "TEL " + slipWork.SANDESETTINGRF_DELIVERERPHONENUM;
                                }
                            }
                            else
                            {
                                row["SANDESETTINGRF.DELIVERERPHONENUMRF"] = string.Empty;
                            }

                            //AB納品先店舗コード
                            if (slipWork.SANDESETTINGRF_CUSTOMERCODE != 0)
                            {
                                row["SANDESETTINGRF.ADDRESSEESHOPCDRF"] = slipWork.SANDESETTINGRF_ADDRESSEESHOPCD;
                            }
                            else
                            {
                                row["SANDESETTINGRF.ADDRESSEESHOPCDRF"] = 0;
                            }

                            //AB経費区分
                            if (slipWork.SANDESETTINGRF_CUSTOMERCODE != 0)
                            {
                                row["SANDESETTINGRF.EXPENSEDIVCDRF"] = slipWork.SANDESETTINGRF_EXPENSEDIVCD;
                            }
                            else
                            {
                                row["SANDESETTINGRF.EXPENSEDIVCDRF"] = 0;
                            }
                            //AB直送区分
                            if (slipWork.SANDESETTINGRF_CUSTOMERCODE != 0)
                            {
                                row["SANDESETTINGRF.DIRECTSENDINGCDRF"] = slipWork.SANDESETTINGRF_DIRECTSENDINGCD;
                            }
                            else
                            {
                                row["SANDESETTINGRF.DIRECTSENDINGCDRF"] = 0;
                            }

                            // AB請求区分
                            // 受注ステータス
                            if (slipWork.SALESSLIPRF_ACPTANODRSTATUSRF == 30)
                            {
                                // 売上伝票区分
                                if (slipWork.SALESSLIPRF_SALESSLIPCDRF == 0)
                                {
                                    row["HADD.ABILLCODERF"] = "010";
                                }
                                else if (slipWork.SALESSLIPRF_SALESSLIPCDRF == 1)
                                {
                                    row["HADD.ABILLCODERF"] = "020";
                                }
                            }
                            else
                            {
                                row["HADD.ABILLCODERF"] = DBNull.Value;
                            }
                            //AB受注区分
                            if (slipWork.SANDESETTINGRF_CUSTOMERCODE != 0)
                            {
                                row["SANDESETTINGRF.ACPTANORDERDIVRF"] = slipWork.SANDESETTINGRF_ACPTANORDERDIV;
                            }
                            else
                            {
                                row["SANDESETTINGRF.ACPTANORDERDIVRF"] = 0;
                            }
                            //AB納品者コード
                            if (slipWork.SANDESETTINGRF_CUSTOMERCODE != 0)
                            {
                                row["SANDESETTINGRF.DELIVERERCDRF"] = slipWork.SANDESETTINGRF_DELIVERERCD;
                            }
                            else
                            {
                                row["SANDESETTINGRF.DELIVERERCDRF"] = 0;
                            }
                            //AB部品商名
                            if (slipWork.SANDESETTINGRF_CUSTOMERCODE != 0)
                            {
                                row["SANDESETTINGRF.TRADCOMPNAMERF"] = slipWork.SANDESETTINGRF_TRADCOMPNAME;
                            }
                            else
                            {
                                row["SANDESETTINGRF.TRADCOMPNAMERF"] = DBNull.Value;
                            }
                            // AB部品商コード
                            // 先頭明細行AB純正区分判断
                            int goodsKindCd = GetGoodsKindCode(detailWorks[0], slipWork);
                            if (slipWork.SANDESETTINGRF_CUSTOMERCODE != 0)
                            {
                                if (goodsKindCd == 1)
                                {
                                    row["HADD.ABTRADCOMPCDRF"] = slipWork.SANDESETTINGRF_PURETRADCOMPCD;
                                }
                                else if (goodsKindCd == 2)
                                {
                                    row["HADD.ABTRADCOMPCDRF"] = slipWork.SANDESETTINGRF_PRITRADCOMPCD;
                                }
                            }
                            else
                            {
                                row["HADD.ABTRADCOMPCDRF"] = 0;
                            }
                            //AB部品商拠点名
                            if (slipWork.SANDESETTINGRF_CUSTOMERCODE != 0)
                            {
                                row["SANDESETTINGRF.TRADCOMPSECTNAMERF"] = slipWork.SANDESETTINGRF_TRADCOMPSECTNAME;
                            }
                            else
                            {
                                row["SANDESETTINGRF.TRADCOMPSECTNAMERF"] = string.Empty;
                            }
                            // AB伝票備考１
                            row["HADD.ABSLIPNOTE1RF"] = slipWork.SALESSLIPRF_SLIPNOTERF;
                            // AB伝票備考２
                            row["HADD.ABSLIPNOTE2RF"] = slipWork.SALESSLIPRF_SLIPNOTERF;
                            // (先頭)AB型式指定番号
                            row["HADD.ABMODELDESIGNATIONNORF"] = slipWork.HADD_MODELDESIGNATIONNORF;
                            // (先頭)AB類別番号
                            row["HADD.ABCATEGORYNORF"] = slipWork.HADD_CATEGORYNORF;

                            // (先頭)AB類別型式ハイフン
                            if (slipWork.HADD_MODELDESIGNATIONNORF != 0 || slipWork.HADD_CATEGORYNORF != 0)
                            {
                                if (slipWork.HADD_MODELDESIGNATIONNORF == 0)
                                {
                                    row["HADD.ABMODELDESIGNATIONNORF"] = DBNull.Value;
                                }
                                if (slipWork.HADD_CATEGORYNORF == 0)
                                {
                                    row["HADD.ABCATEGORYNORF"] = DBNull.Value;
                                }
                                row["HPRT.ABCATEGORYHYPRF"] = "-";
                            }
                            else
                            {
                                row["HADD.ABMODELDESIGNATIONNORF"] = DBNull.Value;
                                row["HADD.ABCATEGORYNORF"] = DBNull.Value;
                                row["HPRT.ABCATEGORYHYPRF"] = string.Empty;
                            }

                            // (先頭)AB型式（フル型）
                            row["HADD.ABFULLMODELRF"] = slipWork.HADD_FULLMODELRF;
                            // 初年度
                            // 年式
                            ExtractDate(ref row, allDefSet.EraNameDispCd1, slipWork.HADD_FIRSTENTRYDATERF, "HADD.ABFIRSTENTRYDATE", true);// yyyymm


                            // (先頭)AB車台番号
                            row["HADD.ABFRAMENORF"] = slipWork.HADD_FRAMENORF;
                            // (先頭)AB車種半角名称
                            row["HADD.ABMODELHALFNAMERF"] = slipWork.HADD_MODELHALFNAMERF;

                            // コメント指定区分
                            if (slipWork.SANDESETTINGRF_COMMENTRESERVEDDIV == 0)
                            {
                                row["HADD.ABSLIPNOTE1RF"] = DBNull.Value;
                                row["HADD.ABSLIPNOTE2RF"] = DBNull.Value;
                                row["HADD.ABMODELDESIGNATIONNORF"] = DBNull.Value;
                                row["HPRT.ABCATEGORYHYPRF"] = DBNull.Value;
                                row["HADD.ABCATEGORYNORF"] = DBNull.Value;
                                row["HADD.ABFULLMODELRF"] = DBNull.Value;
                                row["HADD.ABFIRSTENTRYDATEFYRF"] = DBNull.Value;
                                row["HADD.ABFIRSTENTRYDATEFSRF"] = DBNull.Value;
                                row["HADD.ABFIRSTENTRYDATEFWRF"] = DBNull.Value;
                                row["HADD.ABFIRSTENTRYDATEFMRF"] = DBNull.Value;
                                row["HADD.ABFIRSTENTRYDATEFGRF"] = DBNull.Value;
                                row["HADD.ABFIRSTENTRYDATEFRRF"] = DBNull.Value;
                                row["HADD.ABFIRSTENTRYDATEFLSRF"] = DBNull.Value;
                                row["HADD.ABFIRSTENTRYDATEFLPRF"] = DBNull.Value;
                                row["HADD.ABFIRSTENTRYDATEFLYRF"] = DBNull.Value;
                                row["HADD.ABFIRSTENTRYDATEFLMRF"] = DBNull.Value;
                                row["HADD.ABFRAMENORF"] = DBNull.Value;
                                row["HADD.ABMODELHALFNAMERF"] = DBNull.Value;
                            }
                            else if (slipWork.SANDESETTINGRF_COMMENTRESERVEDDIV == 1)
                            {
                                row["HADD.ABSLIPNOTE2RF"] = DBNull.Value;
                                row["HADD.ABMODELDESIGNATIONNORF"] = DBNull.Value;
                                row["HPRT.ABCATEGORYHYPRF"] = DBNull.Value;
                                row["HADD.ABCATEGORYNORF"] = DBNull.Value;
                                row["HADD.ABFULLMODELRF"] = DBNull.Value;
                                row["HADD.ABFIRSTENTRYDATEFYRF"] = DBNull.Value;
                                row["HADD.ABFIRSTENTRYDATEFSRF"] = DBNull.Value;
                                row["HADD.ABFIRSTENTRYDATEFWRF"] = DBNull.Value;
                                row["HADD.ABFIRSTENTRYDATEFMRF"] = DBNull.Value;
                                row["HADD.ABFIRSTENTRYDATEFGRF"] = DBNull.Value;
                                row["HADD.ABFIRSTENTRYDATEFRRF"] = DBNull.Value;
                                row["HADD.ABFIRSTENTRYDATEFLSRF"] = DBNull.Value;
                                row["HADD.ABFIRSTENTRYDATEFLPRF"] = DBNull.Value;
                                row["HADD.ABFIRSTENTRYDATEFLYRF"] = DBNull.Value;
                                row["HADD.ABFIRSTENTRYDATEFLMRF"] = DBNull.Value;
                                row["HADD.ABFRAMENORF"] = DBNull.Value;
                                row["HADD.ABMODELHALFNAMERF"] = DBNull.Value;
                            }
                            else if (slipWork.SANDESETTINGRF_COMMENTRESERVEDDIV == 2)
                            {
                                row["HADD.ABSLIPNOTE1RF"] = DBNull.Value;
                                row["HADD.ABSLIPNOTE2RF"] = DBNull.Value;
                            }
                            else if (slipWork.SANDESETTINGRF_COMMENTRESERVEDDIV == 3)
                            {
                                row["HADD.ABSLIPNOTE1RF"] = DBNull.Value;
                            }
                            //>>>>>>>>>>>>>20090814
                            // 売上伝票合計（税抜き）(マイナス符号なし)
                            row["HADD.SALESTOTALTAXEXCNOMINUSRF"] = Math.Abs(slipWork.SALESSLIPRF_SALESTOTALTAXEXCRF);
                            // 売上伝票合計（税抜き）マイナス符号

                            // 定価金額合計(税抜)
                            long result = 0;
                            foreach (FrePSalesDetailWork detailWork in detailWorks)
                            {
                                //result += detailWork.SALESDETAILRF_LISTPRICETAXEXCFLRF * detailWork.SALESDETAILRF_SHIPMENTCNTRF;
                                long afterUnit = 0;
                                double beforeUnit = detailWork.SALESDETAILRF_LISTPRICETAXEXCFLRF * detailWork.SALESDETAILRF_SHIPMENTCNTRF;
                                // 端数処理
                                FractionCalculate.FracCalcMoney(beforeUnit, 1, 2, out afterUnit);
                                result += afterUnit;
                            }
                            row["HADD.LISTPRICEMONEYTOTALTAXEXCRF"] = result;
                            // AB本部原価金額合計(マイナス符号なし)
                            long costResult = 0;
                            foreach (FrePSalesDetailWork detailWork in detailWorks)
                            {
                                //costResult += GetABHqSalesUnitCost(detailWork, slipWork) * detailWork.SALESDETAILRF_SHIPMENTCNTRF;
                                long afterUnit = 0;
                                double beforeUnit = GetABHqSalesUnitCost(detailWork, slipWork) * detailWork.SALESDETAILRF_SHIPMENTCNTRF;
                                // 端数処理
                                FractionCalculate.FracCalcMoney(beforeUnit, 1, 2, out afterUnit);
                                costResult += afterUnit;
                            }
                            row["HADD.ABHQTOTALCOSTNOMINUSRF"] = Math.Abs(costResult);
                            // AB本部原価金額合計マイナス符号

                            #endregion
                            // --- ADD 2009.07.24 劉洋 ------ <<<<<<
                        }

                        if (index <= printEndIndex && index < detailWorks.Count)
                        {
                            //-------------------------------------------
                            // 実明細
                            //-------------------------------------------

                            # region [明細項目Copy]
                            row["SALESDETAILRF.ACPTANODRSTATUSRF"] = detailWorks[index].SALESDETAILRF_ACPTANODRSTATUSRF; // 受注ステータス
                            row["SALESDETAILRF.SALESSLIPNUMRF"] = detailWorks[index].SALESDETAILRF_SALESSLIPNUMRF; // ＵＯＥ伝票番号
                            row["SALESDETAILRF.ACCEPTANORDERNORF"] = detailWorks[index].SALESDETAILRF_ACCEPTANORDERNORF; // 受注番号
                            row["SALESDETAILRF.SALESROWNORF"] = detailWorks[index].SALESDETAILRF_SALESROWNORF; // 売上行番号
                            row["SALESDETAILRF.SALESDATERF"] = detailWorks[index].SALESDETAILRF_SALESDATERF; // 売上日付
                            row["SALESDETAILRF.COMMONSEQNORF"] = detailWorks[index].SALESDETAILRF_COMMONSEQNORF; // 共通通番
                            row["SALESDETAILRF.SALESSLIPDTLNUMRF"] = detailWorks[index].SALESDETAILRF_SALESSLIPDTLNUMRF; // 売上明細通番
                            row["SALESDETAILRF.ACPTANODRSTATUSSRCRF"] = detailWorks[index].SALESDETAILRF_ACPTANODRSTATUSSRCRF; // 受注ステータス（元）
                            row["SALESDETAILRF.SALESSLIPDTLNUMSRCRF"] = detailWorks[index].SALESDETAILRF_SALESSLIPDTLNUMSRCRF; // 売上明細通番（元）
                            row["SALESDETAILRF.SUPPLIERFORMALSYNCRF"] = detailWorks[index].SALESDETAILRF_SUPPLIERFORMALSYNCRF; // 仕入形式（同時）
                            row["SALESDETAILRF.STOCKSLIPDTLNUMSYNCRF"] = detailWorks[index].SALESDETAILRF_STOCKSLIPDTLNUMSYNCRF; // 仕入明細通番（同時）
                            row["SALESDETAILRF.SALESSLIPCDDTLRF"] = detailWorks[index].SALESDETAILRF_SALESSLIPCDDTLRF; // ＵＯＥ伝票区分（明細）
                            row["SALESDETAILRF.STOCKMNGEXISTCDRF"] = detailWorks[index].SALESDETAILRF_STOCKMNGEXISTCDRF; // 在庫管理有無区分
                            row["SALESDETAILRF.DELIGDSCMPLTDUEDATERF"] = detailWorks[index].SALESDETAILRF_DELIGDSCMPLTDUEDATERF; // 納品完了予定日
                            row["SALESDETAILRF.GOODSKINDCODERF"] = detailWorks[index].SALESDETAILRF_GOODSKINDCODERF; // 商品属性
                            row["SALESDETAILRF.GOODSMAKERCDRF"] = detailWorks[index].SALESDETAILRF_GOODSMAKERCDRF; // 商品メーカーコード
                            row["SALESDETAILRF.MAKERNAMERF"] = detailWorks[index].SALESDETAILRF_MAKERNAMERF; // メーカー名称
                            row["SALESDETAILRF.GOODSNORF"] = detailWorks[index].SALESDETAILRF_GOODSNORF; // 商品番号
                            row["SALESDETAILRF.GOODSNAMERF"] = detailWorks[index].SALESDETAILRF_GOODSNAMERF; // 商品名称
                            row["SALESDETAILRF.GOODSSHORTNAMERF"] = detailWorks[index].SALESDETAILRF_GOODSSHORTNAMERF; // 商品名略称
                            //row["SALESDETAILRF.LARGEGOODSGANRECODERF"] = detailWorks[index].SALESDETAILRF_LARGEGOODSGANRECODERF; // 商品区分グループコード
                            //row["SALESDETAILRF.LARGEGOODSGANRENAMERF"] = detailWorks[index].SALESDETAILRF_LARGEGOODSGANRENAMERF; // 商品区分グループ名称
                            //row["SALESDETAILRF.MEDIUMGOODSGANRECODERF"] = detailWorks[index].SALESDETAILRF_MEDIUMGOODSGANRECODERF; // 商品区分コード
                            //row["SALESDETAILRF.MEDIUMGOODSGANRENAMERF"] = detailWorks[index].SALESDETAILRF_MEDIUMGOODSGANRENAMERF; // 商品区分名称
                            //row["SALESDETAILRF.DETAILGOODSGANRECODERF"] = detailWorks[index].SALESDETAILRF_DETAILGOODSGANRECODERF; // 商品区分詳細コード
                            //row["SALESDETAILRF.DETAILGOODSGANRENAMERF"] = detailWorks[index].SALESDETAILRF_DETAILGOODSGANRENAMERF; // 商品区分詳細名称
                            row["SALESDETAILRF.BLGOODSCODERF"] = detailWorks[index].SALESDETAILRF_BLGOODSCODERF; // BL商品コード
                            row["SALESDETAILRF.BLGOODSFULLNAMERF"] = detailWorks[index].SALESDETAILRF_BLGOODSFULLNAMERF; // BL商品コード名称（全角）
                            row["SALESDETAILRF.ENTERPRISEGANRECODERF"] = detailWorks[index].SALESDETAILRF_ENTERPRISEGANRECODERF; // 自社分類コード
                            row["SALESDETAILRF.ENTERPRISEGANRENAMERF"] = detailWorks[index].SALESDETAILRF_ENTERPRISEGANRENAMERF; // 自社分類名称
                            row["SALESDETAILRF.WAREHOUSECODERF"] = detailWorks[index].SALESDETAILRF_WAREHOUSECODERF; // 倉庫コード
                            row["SALESDETAILRF.WAREHOUSENAMERF"] = detailWorks[index].SALESDETAILRF_WAREHOUSENAMERF; // 倉庫名称
                            row["SALESDETAILRF.WAREHOUSESHELFNORF"] = detailWorks[index].SALESDETAILRF_WAREHOUSESHELFNORF; // 倉庫棚番
                            row["SALESDETAILRF.SALESORDERDIVCDRF"] = detailWorks[index].SALESDETAILRF_SALESORDERDIVCDRF; // 売上在庫取寄せ区分
                            row["SALESDETAILRF.OPENPRICEDIVRF"] = detailWorks[index].SALESDETAILRF_OPENPRICEDIVRF; // オープン価格区分
                            //row["SALESDETAILRF.UNITCODERF"] = detailWorks[index].SALESDETAILRF_UNITCODERF; // 単位コード
                            //row["SALESDETAILRF.UNITNAMERF"] = detailWorks[index].SALESDETAILRF_UNITNAMERF; // 単位名称
                            row["SALESDETAILRF.GOODSRATERANKRF"] = detailWorks[index].SALESDETAILRF_GOODSRATERANKRF; // 商品掛率ランク
                            row["SALESDETAILRF.CUSTRATEGRPCODERF"] = detailWorks[index].SALESDETAILRF_CUSTRATEGRPCODERF; // 得意先掛率グループコード
                            //row["SALESDETAILRF.SUPPRATEGRPCODERF"] = detailWorks[index].SALESDETAILRF_SUPPRATEGRPCODERF; // 仕入先掛率グループコード
                            row["SALESDETAILRF.LISTPRICERATERF"] = detailWorks[index].SALESDETAILRF_LISTPRICERATERF; // 定価率
                            row["SALESDETAILRF.LISTPRICETAXINCFLRF"] = detailWorks[index].SALESDETAILRF_LISTPRICETAXINCFLRF; // 定価（税込，浮動）
                            row["SALESDETAILRF.LISTPRICETAXEXCFLRF"] = detailWorks[index].SALESDETAILRF_LISTPRICETAXEXCFLRF; // 定価（税抜，浮動）
                            row["SALESDETAILRF.LISTPRICECHNGCDRF"] = detailWorks[index].SALESDETAILRF_LISTPRICECHNGCDRF; // 定価変更区分
                            row["SALESDETAILRF.SALESRATERF"] = detailWorks[index].SALESDETAILRF_SALESRATERF; // 売価率
                            row["SALESDETAILRF.SALESUNPRCTAXINCFLRF"] = detailWorks[index].SALESDETAILRF_SALESUNPRCTAXINCFLRF; // 売上単価（税込，浮動）
                            row["SALESDETAILRF.SALESUNPRCTAXEXCFLRF"] = detailWorks[index].SALESDETAILRF_SALESUNPRCTAXEXCFLRF; // 売上単価（税抜，浮動）
                            row["SALESDETAILRF.COSTRATERF"] = detailWorks[index].SALESDETAILRF_COSTRATERF; // 原価率
                            row["SALESDETAILRF.SALESUNITCOSTRF"] = detailWorks[index].SALESDETAILRF_SALESUNITCOSTRF; // 原価単価
                            row["SALESDETAILRF.SHIPMENTCNTRF"] = detailWorks[index].SALESDETAILRF_SHIPMENTCNTRF; // 出荷数
                            row["SALESDETAILRF.ACCEPTANORDERCNTRF"] = detailWorks[index].SALESDETAILRF_ACCEPTANORDERCNTRF; // 受注数量
                            row["SALESDETAILRF.ACPTANODRADJUSTCNTRF"] = detailWorks[index].SALESDETAILRF_ACPTANODRADJUSTCNTRF; // 受注調整数
                            row["SALESDETAILRF.ACPTANODRREMAINCNTRF"] = detailWorks[index].SALESDETAILRF_ACPTANODRREMAINCNTRF; // 受注残数
                            row["SALESDETAILRF.REMAINCNTUPDDATERF"] = detailWorks[index].SALESDETAILRF_REMAINCNTUPDDATERF; // 残数更新日
                            row["SALESDETAILRF.SALESMONEYTAXINCRF"] = detailWorks[index].SALESDETAILRF_SALESMONEYTAXINCRF; // 売上金額（税込み）
                            row["SALESDETAILRF.SALESMONEYTAXEXCRF"] = detailWorks[index].SALESDETAILRF_SALESMONEYTAXEXCRF; // 売上金額（税抜き）
                            row["SALESDETAILRF.COSTRF"] = detailWorks[index].SALESDETAILRF_COSTRF; // 原価
                            row["SALESDETAILRF.GRSPROFITCHKDIVRF"] = detailWorks[index].SALESDETAILRF_GRSPROFITCHKDIVRF; // 粗利チェック区分
                            row["SALESDETAILRF.SALESGOODSCDRF"] = detailWorks[index].SALESDETAILRF_SALESGOODSCDRF; // 売上商品区分
                            //row["SALESDETAILRF.SALSEPRICECONSTAXRF"] = detailWorks[index].SALESDETAILRF_SALSEPRICECONSTAXRF; // 売上金額消費税額
                            row["SALESDETAILRF.TAXATIONDIVCDRF"] = detailWorks[index].SALESDETAILRF_TAXATIONDIVCDRF; // 課税区分
                            row["SALESDETAILRF.PARTYSLIPNUMDTLRF"] = detailWorks[index].SALESDETAILRF_PARTYSLIPNUMDTLRF; // 相手先伝票番号（明細）
                            row["SALESDETAILRF.DTLNOTERF"] = detailWorks[index].SALESDETAILRF_DTLNOTERF; // 明細備考
                            row["SALESDETAILRF.SUPPLIERCDRF"] = detailWorks[index].SALESDETAILRF_SUPPLIERCDRF; // 仕入先コード
                            row["SALESDETAILRF.SUPPLIERSNMRF"] = detailWorks[index].SALESDETAILRF_SUPPLIERSNMRF; // 仕入先略称
                            row["SALESDETAILRF.ORDERNUMBERRF"] = detailWorks[index].SALESDETAILRF_ORDERNUMBERRF; // 発注番号
                            row["SALESDETAILRF.SLIPMEMO1RF"] = detailWorks[index].SALESDETAILRF_SLIPMEMO1RF; // 伝票メモ１
                            row["SALESDETAILRF.SLIPMEMO2RF"] = detailWorks[index].SALESDETAILRF_SLIPMEMO2RF; // 伝票メモ２
                            row["SALESDETAILRF.SLIPMEMO3RF"] = detailWorks[index].SALESDETAILRF_SLIPMEMO3RF; // 伝票メモ３
                            row["SALESDETAILRF.INSIDEMEMO1RF"] = detailWorks[index].SALESDETAILRF_INSIDEMEMO1RF; // 社内メモ１
                            row["SALESDETAILRF.INSIDEMEMO2RF"] = detailWorks[index].SALESDETAILRF_INSIDEMEMO2RF; // 社内メモ２
                            row["SALESDETAILRF.INSIDEMEMO3RF"] = detailWorks[index].SALESDETAILRF_INSIDEMEMO3RF; // 社内メモ３
                            row["SALESDETAILRF.BFLISTPRICERF"] = detailWorks[index].SALESDETAILRF_BFLISTPRICERF; // 変更前定価
                            row["SALESDETAILRF.BFSALESUNITPRICERF"] = detailWorks[index].SALESDETAILRF_BFSALESUNITPRICERF; // 変更前売価
                            row["SALESDETAILRF.BFUNITCOSTRF"] = detailWorks[index].SALESDETAILRF_BFUNITCOSTRF; // 変更前原価
                            //row["SALESDETAILRF.PRTGOODSNORF"] = detailWorks[index].SALESDETAILRF_PRTGOODSNORF; // 印刷用商品番号
                            //row["SALESDETAILRF.PRTGOODSNAMERF"] = detailWorks[index].SALESDETAILRF_PRTGOODSNAMERF; // 印刷用商品名称
                            //row["SALESDETAILRF.PRTGOODSMAKERCDRF"] = detailWorks[index].SALESDETAILRF_PRTGOODSMAKERCDRF; // 印刷用商品メーカーコード
                            //row["SALESDETAILRF.PRTGOODSMAKERNMRF"] = detailWorks[index].SALESDETAILRF_PRTGOODSMAKERNMRF; // 印刷用商品メーカー名称
                            //row["SALESDETAILRF.CONTRACTDIVCDDTLRF"] = detailWorks[index].SALESDETAILRF_CONTRACTDIVCDDTLRF; // 契約区分（明細）
                            row["SALESDETAILRF.CMPLTSALESROWNORF"] = detailWorks[index].SALESDETAILRF_CMPLTSALESROWNORF; // 一式明細番号
                            row["SALESDETAILRF.CMPLTGOODSMAKERCDRF"] = detailWorks[index].SALESDETAILRF_CMPLTGOODSMAKERCDRF; // メーカーコード（一式）
                            row["SALESDETAILRF.CMPLTMAKERNAMERF"] = detailWorks[index].SALESDETAILRF_CMPLTMAKERNAMERF; // メーカー名称（一式）
                            row["SALESDETAILRF.CMPLTGOODSNAMERF"] = detailWorks[index].SALESDETAILRF_CMPLTGOODSNAMERF; // 商品名称（一式）
                            row["SALESDETAILRF.CMPLTSHIPMENTCNTRF"] = detailWorks[index].SALESDETAILRF_CMPLTSHIPMENTCNTRF; // 数量（一式）
                            //row["SALESDETAILRF.CMPLTUNITCODERF"] = detailWorks[index].SALESDETAILRF_CMPLTUNITCODERF; // 単位コード（一式）
                            //row["SALESDETAILRF.CMPLTUNITNAMERF"] = detailWorks[index].SALESDETAILRF_CMPLTUNITNAMERF; // 単位名称（一式）
                            row["SALESDETAILRF.CMPLTSALESUNPRCFLRF"] = detailWorks[index].SALESDETAILRF_CMPLTSALESUNPRCFLRF; // 売上単価（一式）
                            row["SALESDETAILRF.CMPLTSALESMONEYRF"] = detailWorks[index].SALESDETAILRF_CMPLTSALESMONEYRF; // 売上金額（一式）
                            row["SALESDETAILRF.CMPLTSALESUNITCOSTRF"] = detailWorks[index].SALESDETAILRF_CMPLTSALESUNITCOSTRF; // 原価単価（一式）
                            row["SALESDETAILRF.CMPLTCOSTRF"] = detailWorks[index].SALESDETAILRF_CMPLTCOSTRF; // 原価金額（一式）
                            row["SALESDETAILRF.CMPLTPARTYSALSLNUMRF"] = detailWorks[index].SALESDETAILRF_CMPLTPARTYSALSLNUMRF; // 相手先伝票番号（一式）
                            row["SALESDETAILRF.CMPLTNOTERF"] = detailWorks[index].SALESDETAILRF_CMPLTNOTERF; // 一式備考
                            row["ACCEPTODRCARRF.CARMNGNORF"] = detailWorks[index].ACCEPTODRCARRF_CARMNGNORF; // 車両管理番号
                            row["ACCEPTODRCARRF.CARMNGCODERF"] = detailWorks[index].ACCEPTODRCARRF_CARMNGCODERF; // 車輌管理コード
                            row["ACCEPTODRCARRF.NUMBERPLATE1CODERF"] = detailWorks[index].ACCEPTODRCARRF_NUMBERPLATE1CODERF; // 陸運事務所番号
                            row["ACCEPTODRCARRF.NUMBERPLATE1NAMERF"] = detailWorks[index].ACCEPTODRCARRF_NUMBERPLATE1NAMERF; // 陸運事務局名称
                            row["ACCEPTODRCARRF.NUMBERPLATE2RF"] = detailWorks[index].ACCEPTODRCARRF_NUMBERPLATE2RF; // 車両登録番号（種別）
                            row["ACCEPTODRCARRF.NUMBERPLATE3RF"] = detailWorks[index].ACCEPTODRCARRF_NUMBERPLATE3RF; // 車両登録番号（カナ）
                            row["ACCEPTODRCARRF.NUMBERPLATE4RF"] = detailWorks[index].ACCEPTODRCARRF_NUMBERPLATE4RF; // 車両登録番号（プレート番号）
                            row["ACCEPTODRCARRF.FIRSTENTRYDATERF"] = detailWorks[index].ACCEPTODRCARRF_FIRSTENTRYDATERF; // 初年度
                            row["ACCEPTODRCARRF.MAKERCODERF"] = detailWorks[index].ACCEPTODRCARRF_MAKERCODERF; // メーカーコード
                            row["ACCEPTODRCARRF.MAKERFULLNAMERF"] = detailWorks[index].ACCEPTODRCARRF_MAKERFULLNAMERF; // メーカー全角名称
                            row["ACCEPTODRCARRF.MODELCODERF"] = detailWorks[index].ACCEPTODRCARRF_MODELCODERF; // 車種コード
                            row["ACCEPTODRCARRF.MODELSUBCODERF"] = detailWorks[index].ACCEPTODRCARRF_MODELSUBCODERF; // 車種サブコード
                            row["ACCEPTODRCARRF.MODELFULLNAMERF"] = detailWorks[index].ACCEPTODRCARRF_MODELFULLNAMERF; // 車種全角名称
                            row["ACCEPTODRCARRF.EXHAUSTGASSIGNRF"] = detailWorks[index].ACCEPTODRCARRF_EXHAUSTGASSIGNRF; // 排ガス記号
                            row["ACCEPTODRCARRF.SERIESMODELRF"] = detailWorks[index].ACCEPTODRCARRF_SERIESMODELRF; // シリーズ型式
                            row["ACCEPTODRCARRF.CATEGORYSIGNMODELRF"] = detailWorks[index].ACCEPTODRCARRF_CATEGORYSIGNMODELRF; // 型式（類別記号）
                            row["ACCEPTODRCARRF.FULLMODELRF"] = detailWorks[index].ACCEPTODRCARRF_FULLMODELRF; // 型式（フル型）
                            row["ACCEPTODRCARRF.MODELDESIGNATIONNORF"] = detailWorks[index].ACCEPTODRCARRF_MODELDESIGNATIONNORF; // 型式指定番号
                            row["ACCEPTODRCARRF.CATEGORYNORF"] = detailWorks[index].ACCEPTODRCARRF_CATEGORYNORF; // 類別番号
                            row["ACCEPTODRCARRF.FRAMEMODELRF"] = detailWorks[index].ACCEPTODRCARRF_FRAMEMODELRF; // 車台型式
                            row["ACCEPTODRCARRF.FRAMENORF"] = detailWorks[index].ACCEPTODRCARRF_FRAMENORF; // 車台番号
                            row["ACCEPTODRCARRF.SEARCHFRAMENORF"] = detailWorks[index].ACCEPTODRCARRF_SEARCHFRAMENORF; // 車台番号（検索用）
                            row["ACCEPTODRCARRF.ENGINEMODELNMRF"] = detailWorks[index].ACCEPTODRCARRF_ENGINEMODELNMRF; // エンジン型式名称
                            row["ACCEPTODRCARRF.RELEVANCEMODELRF"] = detailWorks[index].ACCEPTODRCARRF_RELEVANCEMODELRF; // 関連型式
                            row["ACCEPTODRCARRF.SUBCARNMCDRF"] = detailWorks[index].ACCEPTODRCARRF_SUBCARNMCDRF; // サブ車名コード
                            row["ACCEPTODRCARRF.MODELGRADESNAMERF"] = detailWorks[index].ACCEPTODRCARRF_MODELGRADESNAMERF; // 型式グレード略称
                            row["ACCEPTODRCARRF.COLORCODERF"] = detailWorks[index].ACCEPTODRCARRF_COLORCODERF; // カラーコード
                            row["ACCEPTODRCARRF.COLORNAME1RF"] = detailWorks[index].ACCEPTODRCARRF_COLORNAME1RF; // カラー名称1
                            row["ACCEPTODRCARRF.TRIMCODERF"] = detailWorks[index].ACCEPTODRCARRF_TRIMCODERF; // トリムコード
                            row["ACCEPTODRCARRF.TRIMNAMERF"] = detailWorks[index].ACCEPTODRCARRF_TRIMNAMERF; // トリム名称
                            row["ACCEPTODRCARRF.MILEAGERF"] = detailWorks[index].ACCEPTODRCARRF_MILEAGERF; // 車両走行距離
                            row["MAKGDS.MAKERSHORTNAMERF"] = detailWorks[index].MAKGDS_MAKERSHORTNAMERF; // 部品メーカー略称
                            row["MAKGDS.MAKERKANANAMERF"] = detailWorks[index].MAKGDS_MAKERKANANAMERF; // 部品メーカーカナ名称
                            row["MAKGDS.GOODSMAKERCDRF"] = detailWorks[index].MAKGDS_GOODSMAKERCDRF; // ユーザー検索部品メーカーコード
                            row["MAKCMP.MAKERSHORTNAMERF"] = detailWorks[index].MAKCMP_MAKERSHORTNAMERF; // 一式メーカー略称
                            row["MAKCMP.MAKERKANANAMERF"] = detailWorks[index].MAKCMP_MAKERKANANAMERF; // 一式メーカーカナ名称
                            row["MAKCMP.GOODSMAKERCDRF"] = detailWorks[index].MAKCMP_GOODSMAKERCDRF; // ユーザー検索一式メーカーコード
                            //row["GOODSURF.GOODSNAMEKANARF"] = detailWorks[index].GOODSURF_GOODSNAMEKANARF; // 商品名称カナ
                            row["GOODSURF.JANRF"] = detailWorks[index].GOODSURF_JANRF; // JANコード
                            row["GOODSURF.GOODSRATERANKRF"] = detailWorks[index].GOODSURF_GOODSRATERANKRF; // 商品掛率ランク
                            row["GOODSURF.GOODSNONONEHYPHENRF"] = detailWorks[index].GOODSURF_GOODSNONONEHYPHENRF; // ハイフン無商品番号
                            row["GOODSURF.GOODSNOTE1RF"] = detailWorks[index].GOODSURF_GOODSNOTE1RF; // 商品備考１
                            row["GOODSURF.GOODSNOTE2RF"] = detailWorks[index].GOODSURF_GOODSNOTE2RF; // 商品備考２
                            row["GOODSURF.GOODSSPECIALNOTERF"] = detailWorks[index].GOODSURF_GOODSSPECIALNOTERF; // 商品規格・特記事項
                            row["STOCKRF.SHIPMENTPOSCNTRF"] = detailWorks[index].STOCKRF_SHIPMENTPOSCNTRF; // 出荷可能数
                            row["STOCKRF.DUPLICATIONSHELFNO1RF"] = detailWorks[index].STOCKRF_DUPLICATIONSHELFNO1RF; // 重複棚番１
                            row["STOCKRF.DUPLICATIONSHELFNO2RF"] = detailWorks[index].STOCKRF_DUPLICATIONSHELFNO2RF; // 重複棚番２
                            row["STOCKRF.PARTSMANAGEMENTDIVIDE1RF"] = detailWorks[index].STOCKRF_PARTSMANAGEMENTDIVIDE1RF; // 部品管理区分１
                            row["STOCKRF.PARTSMANAGEMENTDIVIDE2RF"] = detailWorks[index].STOCKRF_PARTSMANAGEMENTDIVIDE2RF; // 部品管理区分２
                            row["STOCKRF.STOCKNOTE1RF"] = detailWorks[index].STOCKRF_STOCKNOTE1RF; // 在庫備考１
                            row["STOCKRF.STOCKNOTE2RF"] = detailWorks[index].STOCKRF_STOCKNOTE2RF; // 在庫備考２
                            row["WAREHOUSERF.WAREHOUSENOTE1RF"] = detailWorks[index].WAREHOUSERF_WAREHOUSENOTE1RF; // 倉庫備考1
                            row["USRCSG.GUIDENAMERF"] = detailWorks[index].USRCSG_GUIDENAMERF; // 得意先掛率ＧＲ名称
                            //row["USRSPG.GUIDENAMERF"] = detailWorks[index].USRSPG_GUIDENAMERF; // 仕入先掛率ＧＲ名称
                            row["SUPPLIERRF.SUPPLIERCDRF"] = detailWorks[index].SUPPLIERRF_SUPPLIERCDRF; // ユーザー検索仕入先コード
                            row["SUPPLIERRF.SUPPLIERNM1RF"] = detailWorks[index].SUPPLIERRF_SUPPLIERNM1RF; // 仕入先名1
                            row["SUPPLIERRF.SUPPLIERNM2RF"] = detailWorks[index].SUPPLIERRF_SUPPLIERNM2RF; // 仕入先名2
                            row["SUPPLIERRF.SUPPHONORIFICTITLERF"] = detailWorks[index].SUPPLIERRF_SUPPHONORIFICTITLERF; // 仕入先敬称
                            row["SUPPLIERRF.SUPPLIERKANARF"] = detailWorks[index].SUPPLIERRF_SUPPLIERKANARF; // 仕入先カナ
                            row["SUPPLIERRF.PURECODERF"] = detailWorks[index].SUPPLIERRF_PURECODERF; // 純正区分
                            row["SUPPLIERRF.SUPPLIERNOTE1RF"] = detailWorks[index].SUPPLIERRF_SUPPLIERNOTE1RF; // 仕入先備考1
                            row["SUPPLIERRF.SUPPLIERNOTE2RF"] = detailWorks[index].SUPPLIERRF_SUPPLIERNOTE2RF; // 仕入先備考2
                            row["SUPPLIERRF.SUPPLIERNOTE3RF"] = detailWorks[index].SUPPLIERRF_SUPPLIERNOTE3RF; // 仕入先備考3
                            row["SUPPLIERRF.SUPPLIERNOTE4RF"] = detailWorks[index].SUPPLIERRF_SUPPLIERNOTE4RF; // 仕入先備考4
                            row["BLGOODSCDURF.BLGOODSCODERF"] = detailWorks[index].BLGOODSCDURF_BLGOODSCODERF; // ユーザー検索BL商品コード
                            row["BLGOODSCDURF.BLGOODSHALFNAMERF"] = detailWorks[index].BLGOODSCDURF_BLGOODSHALFNAMERF; // BL商品コード名称（半角）
                            //row["DADD.STOCKMNGEXISTNMRF"] = detailWorks[index].DADD_STOCKMNGEXISTNMRF; // 在庫管理有無区分名称
                            //row["DADD.GOODSKINDNAMERF"] = detailWorks[index].DADD_GOODSKINDNAMERF; // 商品属性名称
                            //row["DADD.SALESORDERDIVNMRF"] = detailWorks[index].DADD_SALESORDERDIVNMRF; // 売上在庫取寄せ区分名称
                            //row["DADD.OPENPRICEDIVNMRF"] = detailWorks[index].DADD_OPENPRICEDIVNMRF; // オープン価格区分名称
                            //row["DADD.GRSPROFITCHKDIVNMRF"] = detailWorks[index].DADD_GRSPROFITCHKDIVNMRF; // 粗利チェック区分名称
                            //row["DADD.SALESGOODSNMRF"] = detailWorks[index].DADD_SALESGOODSNMRF; // 売上商品区分名称
                            //row["DADD.TAXATIONDIVNMRF"] = detailWorks[index].DADD_TAXATIONDIVNMRF; // 課税区分名称
                            //row["DADD.PURECODENMRF"] = detailWorks[index].DADD_PURECODENMRF; // 純正区分
                            //row["DADD.SALESORDERDIVMARKRF"] = detailWorks[index].DADD_SALESORDERDIVMARKRF; // 在庫取寄区分マーク
                            row["ACCEPTODRCARRF.MAKERHALFNAMERF"] = detailWorks[index].ACCEPTODRCARRF_MAKERHALFNAMERF; // メーカー半角名称
                            row["ACCEPTODRCARRF.MODELHALFNAMERF"] = detailWorks[index].ACCEPTODRCARRF_MODELHALFNAMERF; // 車種半角名称
                            row["SALESDETAILRF.GOODSLGROUPRF"] = detailWorks[index].SALESDETAILRF_GOODSLGROUPRF; // 商品大分類コード
                            row["SALESDETAILRF.GOODSLGROUPNAMERF"] = detailWorks[index].SALESDETAILRF_GOODSLGROUPNAMERF; // 商品大分類名称
                            row["SALESDETAILRF.GOODSMGROUPRF"] = detailWorks[index].SALESDETAILRF_GOODSMGROUPRF; // 商品中分類コード
                            row["SALESDETAILRF.GOODSMGROUPNAMERF"] = detailWorks[index].SALESDETAILRF_GOODSMGROUPNAMERF; // 商品中分類名称
                            row["SALESDETAILRF.BLGROUPCODERF"] = detailWorks[index].SALESDETAILRF_BLGROUPCODERF; // BLグループコード
                            row["SALESDETAILRF.BLGROUPNAMERF"] = detailWorks[index].SALESDETAILRF_BLGROUPNAMERF; // BLグループコード名称
                            row["SALESDETAILRF.SALESCODERF"] = detailWorks[index].SALESDETAILRF_SALESCODERF; // 販売区分コード
                            row["SALESDETAILRF.SALESCDNMRF"] = detailWorks[index].SALESDETAILRF_SALESCDNMRF; // 販売区分名称
                            row["SALESDETAILRF.GOODSNAMEKANARF"] = detailWorks[index].SALESDETAILRF_GOODSNAMEKANARF; // 商品名称カナ
                            // --- ADD  大矢睦美  2010/05/14 ---------->>>>>
                            //粗利金額                         
                            row["DADD.GROSSPROFITRF"] = GetGrossProfit(detailWorks[index].SALESDETAILRF_SALESMONEYTAXEXCRF, (decimal)detailWorks[index].SALESDETAILRF_SALESUNITCOSTRF, (decimal)detailWorks[index].SALESDETAILRF_SHIPMENTCNTRF);
                            //粗利率
                            Double grossProfitRate = 0;
                            grossProfitRate = stc_grossProfitCalculator.CalcGrossProfitRate((long)detailWorks[index].SALESDETAILRF_SALESMONEYTAXEXCRF, (long)detailWorks[index].SALESDETAILRF_COSTRF);
                            row["DADD.GROSSPROFITRATERF"] = grossProfitRate;
                            //粗利率リテラル
                            if (!string.IsNullOrEmpty(grossProfitRate.ToString()))
                            {
                                row["DADD.GROSSPROFITRATELTRLRF"] = "%";
                            }
                            else
                            {
                                row["DADD.GROSSPROFITRATELTRLRF"] = DBNull.Value;
                            }
                            // --- ADD  大矢睦美  2010/05/14 ----------<<<<<
                            
                            // 2011/05/27 Add >>>
                            if (!string.IsNullOrEmpty(grossProfitRate.ToString()))
                            {
                                // 売上全体設定・粗利チェック率と比較
                                if (salesTtlSt.InpGrsProfChkUpper < grossProfitRate)
                                    row["DADD.GRSPROFITCHECKMARKRF"] = "H";
                                else if (salesTtlSt.InpGrsProfChkLower > grossProfitRate)
                                    row["DADD.GRSPROFITCHECKMARKRF"] = "L";
                                else
                                    row["DADD.GRSPROFITCHECKMARKRF"] = DBNull.Value;
                            }
                            else
                            {
                                row["DADD.GRSPROFITCHECKMARKRF"] = DBNull.Value;
                            }
                            // 2011/05/27 Add <<<
                            // --- ADD  2011/07/19 ---------->>>
                            #region[自動回答区分(SCM)]
                            // SCM回答マーク印字区分:0:しない,1:する
                            //if (LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_PM_PCC) != PurchaseStatus.Contract || slipPrtSet.SCMAnsMarkPrtDiv == 0)// ADD  2011/08/05 // DEL  2011/08/08
                            if (LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_PM_SCM) != PurchaseStatus.Contract || slipPrtSet.SCMAnsMarkPrtDiv == 0)// ADD  2011/08/08
                            // if (slipPrtSet.SCMAnsMarkPrtDiv == 0)// DEL 2011/08/05
                            {
                                row["HADD.NORMALPRTMARKRF"] = string.Empty;
                                row["HADD.SCMMANUALANSMARKRF"] = string.Empty;
                                row["HADD.SCMAUTOANSMARKRF"] = string.Empty;
                            }
                            else
                            {
                                // 0:通常(PCC連携なし)、1:手動回答、2:自動回答
                                if (detailWorks[index].SALESDETAILRF_AUTOANSWERDIVSCMRF == 0)
                                {
                                    row["HADD.NORMALPRTMARKRF"] = slipPrtSet.NormalPrtMark;
                                    row["HADD.SCMMANUALANSMARKRF"] = string.Empty;
                                    row["HADD.SCMAUTOANSMARKRF"] = string.Empty;
                                }
                                else if (detailWorks[index].SALESDETAILRF_AUTOANSWERDIVSCMRF == 1)
                                {
                                    row["HADD.NORMALPRTMARKRF"] = string.Empty;
                                    row["HADD.SCMMANUALANSMARKRF"] = slipPrtSet.SCMManualAnsMark;
                                    row["HADD.SCMAUTOANSMARKRF"] = string.Empty;
                                }
                                else if (detailWorks[index].SALESDETAILRF_AUTOANSWERDIVSCMRF == 2)
                                {
                                    row["HADD.NORMALPRTMARKRF"] = string.Empty;
                                    row["HADD.SCMMANUALANSMARKRF"] = string.Empty;
                                    row["HADD.SCMAUTOANSMARKRF"] = slipPrtSet.SCMAutoAnsMark;
                                }
                            }
                            #endregion
                            // --- ADD  2011/07/19 ----------<<<<<
                            # endregion

                            # region [明細項目(自動以外)]

                            // 未設定時 非印字コード
                            # region [未設定]
                            //if ( IsZero( detailWorks[index].SALESDETAILRF_GOODSMAKERCDRF ) ) row["SALESDETAILRF.GOODSMAKERCDRF"] = DBNull.Value; // 商品メーカーコード
                            //if ( IsZero( detailWorks[index].SALESDETAILRF_BLGOODSCODERF )) row["SALESDETAILRF.BLGOODSCODERF"] = DBNull.Value; // BL商品コード
                            if (IsZero(detailWorks[index].SALESDETAILRF_ENTERPRISEGANRECODERF)) row["SALESDETAILRF.ENTERPRISEGANRECODERF"] = DBNull.Value; // 自社分類コード
                            if (IsZero(detailWorks[index].SALESDETAILRF_CUSTRATEGRPCODERF)) row["SALESDETAILRF.CUSTRATEGRPCODERF"] = DBNull.Value; // 得意先掛率グループコード
                            if (IsZero(detailWorks[index].SALESDETAILRF_SUPPLIERCDRF)) row["SALESDETAILRF.SUPPLIERCDRF"] = DBNull.Value; // 仕入先コード
                            if (IsZero(detailWorks[index].ACCEPTODRCARRF_MAKERCODERF)) row["ACCEPTODRCARRF.MAKERCODERF"] = DBNull.Value; // メーカーコード
                            if (IsZero(detailWorks[index].ACCEPTODRCARRF_MODELCODERF)) row["ACCEPTODRCARRF.MODELCODERF"] = DBNull.Value; // 車種コード
                            if (IsZero(detailWorks[index].ACCEPTODRCARRF_MODELDESIGNATIONNORF)) row["ACCEPTODRCARRF.MODELDESIGNATIONNORF"] = DBNull.Value; // 型式指定番号
                            if (IsZero(detailWorks[index].ACCEPTODRCARRF_CATEGORYNORF)) row["ACCEPTODRCARRF.CATEGORYNORF"] = DBNull.Value; // 類別番号
                            if (IsZero(detailWorks[index].ACCEPTODRCARRF_MAKERCODERF)) row["ACCEPTODRCARRF.MAKERCODERF"] = DBNull.Value; // メーカーコード
                            if (IsZero(detailWorks[index].ACCEPTODRCARRF_MODELCODERF)) row["ACCEPTODRCARRF.MODELCODERF"] = DBNull.Value; // 車種コード
                            if (IsZero(detailWorks[index].ACCEPTODRCARRF_MODELSUBCODERF)) row["ACCEPTODRCARRF.MODELSUBCODERF"] = DBNull.Value; // 車種サブコード
                            if (IsZero(detailWorks[index].ACCEPTODRCARRF_CARMNGNORF)) row["ACCEPTODRCARRF.CARMNGNORF"] = DBNull.Value; // 車両管理番号
                            if (IsZero(detailWorks[index].SALESDETAILRF_WAREHOUSECODERF)) row["SALESDETAILRF.WAREHOUSECODERF"] = DBNull.Value; // 倉庫コード
                            if (IsZero(detailWorks[index].SALESDETAILRF_GOODSLGROUPRF)) row["SALESDETAILRF.GOODSLGROUPRF"] = DBNull.Value; // 商品大分類コード
                            if (IsZero(detailWorks[index].SALESDETAILRF_GOODSMGROUPRF)) row["SALESDETAILRF.GOODSMGROUPRF"] = DBNull.Value; // 商品中分類コード
                            if (IsZero(detailWorks[index].SALESDETAILRF_BLGROUPCODERF)) row["SALESDETAILRF.BLGROUPCODERF"] = DBNull.Value; // BLグループコード
                            if (IsZero(detailWorks[index].SALESDETAILRF_SALESCODERF)) row["SALESDETAILRF.SALESCODERF"] = DBNull.Value; // 販売区分コード
                            # endregion

                          

                            // 総額表示
                            # region [総額表示]

                            // 税込フラグ
                            bool taxIn = false;
                            # region [taxIn]
                            // 0:総額表示しない（税抜き）,1:総額表示する（税込み）
                            if (slipWork.SALESSLIPRF_TOTALAMOUNTDISPWAYCDRF == 1)
                            {
                                //------------------------------------------------------------
                                // 総額表示＝する　→　課税区分によらず、常に税込表示
                                //------------------------------------------------------------
                                taxIn = true;
                            }
                            else
                            {
                                //------------------------------------------------------------
                                // 総額表示＝しない　→　課税区分に従う
                                //------------------------------------------------------------
                                // 0:課税,1:非課税,2:課税（内税）
                                if (detailWorks[index].SALESDETAILRF_TAXATIONDIVCDRF == 2)
                                {
                                    // 税込みを印字
                                    taxIn = true;
                                }
                            }
                            # endregion

                            // 印字内容は必ず..TAXINC..に格納し、..TAXEXC..は使用しない
                            # region [set]
                            if (taxIn)
                            {
                                // 税込
                                row["SALESDETAILRF.LISTPRICETAXINCFLRF"] = detailWorks[index].SALESDETAILRF_LISTPRICETAXINCFLRF; // 定価（税込，浮動）
                                row["SALESDETAILRF.SALESUNPRCTAXINCFLRF"] = detailWorks[index].SALESDETAILRF_SALESUNPRCTAXINCFLRF; // 売上単価（税込，浮動）
                                row["SALESDETAILRF.SALESMONEYTAXINCRF"] = detailWorks[index].SALESDETAILRF_SALESMONEYTAXINCRF; // 売上金額（税込み）
                            }
                            else
                            {
                                // 税抜
                                row["SALESDETAILRF.LISTPRICETAXINCFLRF"] = detailWorks[index].SALESDETAILRF_LISTPRICETAXEXCFLRF; // 定価（税抜，浮動）
                                row["SALESDETAILRF.SALESUNPRCTAXINCFLRF"] = detailWorks[index].SALESDETAILRF_SALESUNPRCTAXEXCFLRF; // 売上単価（税抜，浮動）
                                row["SALESDETAILRF.SALESMONEYTAXINCRF"] = detailWorks[index].SALESDETAILRF_SALESMONEYTAXEXCRF; // 売上金額（税抜き）
                            }
                            row["SALESDETAILRF.LISTPRICETAXEXCFLRF"] = DBNull.Value; // 定価（税抜，浮動）
                            row["SALESDETAILRF.SALESUNPRCTAXEXCFLRF"] = DBNull.Value; // 売上単価（税抜，浮動）
                            row["SALESDETAILRF.SALESMONEYTAXEXCRF"] = DBNull.Value; // 売上金額（税抜き）                        
                            # endregion

                            # endregion

                            // "印刷用"項目
                            # region ["印刷用"]
                            // （"印刷用"項目がある、以下のカラムは内容を差し替える）
                            row["SALESDETAILRF.GOODSMAKERCDRF"] = detailWorks[index].SALESDETAILRF_PRTMAKERCODERF; // 商品メーカーコード
                            row["SALESDETAILRF.MAKERNAMERF"] = detailWorks[index].SALESDETAILRF_PRTMAKERNAMERF; // メーカー名称
                            row["SALESDETAILRF.GOODSNORF"] = detailWorks[index].SALESDETAILRF_PRTGOODSNORF; // 商品番号
                            row["SALESDETAILRF.BLGOODSCODERF"] = detailWorks[index].SALESDETAILRF_PRTBLGOODSCODERF; // BL商品コード
                            row["SALESDETAILRF.BLGOODSFULLNAMERF"] = detailWorks[index].SALESDETAILRF_PRTBLGOODSNAMERF; // BL商品コード名称（全角）
                            // 非印字判定
                            if (detailWorks[index].SALESDETAILRF_PRTMAKERCODERF == 0) row["SALESDETAILRF.GOODSMAKERCDRF"] = DBNull.Value; // 商品メーカーコード
                            if (detailWorks[index].SALESDETAILRF_PRTBLGOODSCODERF == 0) row["SALESDETAILRF.BLGOODSCODERF"] = DBNull.Value; // BL商品コード
                            # endregion

                            // 固定名称取得
                            # region [固定名称]
                            row["DADD.STOCKMNGEXISTNMRF"] = GetDADD_STOCKMNGEXISTNMRF(detailWorks[index].SALESDETAILRF_STOCKMNGEXISTCDRF); // 在庫管理有無区分名称
                            row["DADD.GOODSKINDNAMERF"] = GetDADD_GOODSKINDNAMERF(detailWorks[index].SALESDETAILRF_GOODSKINDCODERF); // 商品属性名称
                            row["DADD.SALESORDERDIVNMRF"] = GetDADD_SALESORDERDIVNMRF(detailWorks[index].SALESDETAILRF_SALESORDERDIVCDRF); // 売上在庫取寄せ区分名称
                            row["DADD.OPENPRICEDIVNMRF"] = GetDADD_OPENPRICEDIVNMRF(detailWorks[index].SALESDETAILRF_OPENPRICEDIVRF); // オープン価格区分名称
                            row["DADD.GRSPROFITCHKDIVNMRF"] = GetDADD_GRSPROFITCHKDIVNMRF(detailWorks[index].SALESDETAILRF_GRSPROFITCHKDIVRF); // 粗利チェック区分名称
                            row["DADD.SALESGOODSNMRF"] = GetDADD_SALESGOODSNMRF(detailWorks[index].SALESDETAILRF_SALESGOODSCDRF); // 売上商品区分名称
                            row["DADD.TAXATIONDIVNMRF"] = GetDADD_TAXATIONDIVNMRF(detailWorks[index].SALESDETAILRF_TAXATIONDIVCDRF); // 課税区分名称
                            row["DADD.PURECODENMRF"] = GetDADD_PURECODENMRF(detailWorks[index].SUPPLIERRF_PURECODERF); // 純正区分
                            # endregion

                            // 在庫取寄区分マーク
                            # region [在庫取寄区分マーク]
                            // 0:取寄せ("*")，1:在庫("")
                            if (detailWorks[index].SALESDETAILRF_SALESORDERDIVCDRF == 0)
                            {
                                row["DADD.SALESORDERDIVMARKRF"] = "*"; // 在庫取寄区分マーク

                                // 在庫情報非印字
                                row["SALESDETAILRF.WAREHOUSECODERF"] = DBNull.Value; // 倉庫コード
                                row["STOCKRF.SHIPMENTPOSCNTRF"] = DBNull.Value; // 出荷可能数
                                row["STOCKRF.DUPLICATIONSHELFNO1RF"] = DBNull.Value; // 重複棚番１
                                row["STOCKRF.DUPLICATIONSHELFNO2RF"] = DBNull.Value; // 重複棚番２
                                row["STOCKRF.PARTSMANAGEMENTDIVIDE1RF"] = DBNull.Value; // 部品管理区分１
                                row["STOCKRF.PARTSMANAGEMENTDIVIDE2RF"] = DBNull.Value; // 部品管理区分２
                                row["STOCKRF.STOCKNOTE1RF"] = DBNull.Value; // 在庫備考１
                                row["STOCKRF.STOCKNOTE2RF"] = DBNull.Value; // 在庫備考２
                                row["WAREHOUSERF.WAREHOUSENOTE1RF"] = DBNull.Value; // 倉庫備考1

                                // 仕入先コード(取寄のみ)
                                row[ct_SupplierCdExtra] = row["SALESDETAILRF.SUPPLIERCDRF"];
                            }
                            else
                            {
                                row["DADD.SALESORDERDIVMARKRF"] = string.Empty; // 在庫取寄区分マーク

                                // 仕入先コード(取寄のみ)→在庫ならば非印字
                                row[ct_SupplierCdExtra] = DBNull.Value;

                                // 棚番（得意先注番なし時のみ）
                                if (string.IsNullOrEmpty(detailWorks[index].SALESDETAILRF_PARTYSLIPNUMDTLRF))
                                {
                                    row[ct_ShelfNoExtra] = row["SALESDETAILRF.WAREHOUSESHELFNORF"];
                                }
                            }
                            # endregion

                            // 日付展開
                            # region [日付展開]
                            // 通常
                            ExtractDate(ref row, allDefSet.EraNameDispCd2, detailWorks[index].SALESDETAILRF_DELIGDSCMPLTDUEDATERF, "DADD.DELIGDSCMPLTDUEDATE", false); // 納入完了予定日yyyymmdd
                            // 年式
                            ExtractDate(ref row, allDefSet.EraNameDispCd1, detailWorks[index].ACCEPTODRCARRF_FIRSTENTRYDATERF, "DADD.FIRSTENTRYDATE", true); // 初年度yyyymm
                            # endregion

                            //// 受注数・出荷数
                            //# region [受注数・出荷数]
                            //if ( slipWork.SALESSLIPRF_ACPTANODRSTATUSRF == 20 )
                            //{
                            //    // 受注ステータス＝20:受注
                            //    row[ct_AcptCount] = detailWorks[index].SALESDETAILRF_SHIPMENTCNTRF; // 受注数
                            //    row[ct_ShipCount] = DBNull.Value; // 出荷数
                            //}
                            //else
                            //{
                            //    // 受注ステータス≠20:受注
                            //    row[ct_AcptCount] = DBNull.Value; // 受注数
                            //    row[ct_ShipCount] = detailWorks[index].SALESDETAILRF_SHIPMENTCNTRF; // 出荷数
                            //}
                            //# endregion

                            // 類別型式ハイフン
                            # region [類別型式ハイフン]
                            if (detailWorks[index].ACCEPTODRCARRF_CATEGORYNORF == 0 && detailWorks[index].ACCEPTODRCARRF_MODELDESIGNATIONNORF == 0)
                            {
                                row[ct_DCategoryHyp] = DBNull.Value;
                            }
                            else
                            {
                                row[ct_DCategoryHyp] = "-";
                            }
                            # endregion

                            // UOE専用項目
                            # region [UOE専用項目]

                            //// UOE発注データ
                            //UOEOrderDtlWork uoeOrderDtl = null;
                            // 印刷用明細データ
                            PrtSalesDetail prtSalesDetail = null;

                            if (uoeSales.uoeSalesDetailList.Count > index)
                            {
                                //uoeOrderDtl = uoeSales.uoeSalesDetailList[index].uOEOrderDtlWork;
                                prtSalesDetail = uoeSales.uoeSalesDetailList[index].prtSalesDetail;
                            }

                            //# region [UOE発注データより]
                            //if ( uoeOrderDtl != null )
                            //{
                            //    row["DUOE.BOCODERF"] = uoeOrderDtl.BoCode; // BO区分
                            //    row["DUOE.UOEDELIGOODSDIVRF"] = uoeOrderDtl.UOEDeliGoodsDiv; // UOE納品区分
                            //    row["DUOE.DELIVEREDGOODSDIVNMRF"] = uoeOrderDtl.DeliveredGoodsDivNm; // 納品区分名称
                            //    row["DUOE.FOLLOWDELIGOODSDIVRF"] = uoeOrderDtl.FollowDeliGoodsDiv; // フォロー納品区分
                            //    row["DUOE.FOLLOWDELIGOODSDIVNMRF"] = uoeOrderDtl.FollowDeliGoodsDivNm; // フォロー納品区分名称
                            //}
                            //else
                            //{
                            //    row["DUOE.BOCODERF"] = DBNull.Value; // BO区分
                            //    row["DUOE.UOEDELIGOODSDIVRF"] = DBNull.Value; // UOE納品区分
                            //    row["DUOE.DELIVEREDGOODSDIVNMRF"] = DBNull.Value; // 納品区分名称
                            //    row["DUOE.FOLLOWDELIGOODSDIVRF"] = DBNull.Value; // フォロー納品区分
                            //    row["DUOE.FOLLOWDELIGOODSDIVNMRF"] = DBNull.Value; // フォロー納品区分名称
                            //}
                            //# endregion

                            # region [印刷用明細データより]
                            if (prtSalesDetail != null)
                            {
                                row["DUOE.BOCODERF"] = prtSalesDetail.prtBoCode; // BO区分
                                row["DUOE.UOEDELIGOODSDIVRF"] = prtSalesDetail.prtUOEDeliGoodsDiv; // UOE納品区分
                                row["DUOE.DELIVEREDGOODSDIVNMRF"] = prtSalesDetail.prtDeliveredGoodsDivNm; // 納品区分名称
                                row["DUOE.FOLLOWDELIGOODSDIVRF"] = prtSalesDetail.prtFollowDeliGoodsDiv; // フォロー納品区分
                                row["DUOE.FOLLOWDELIGOODSDIVNMRF"] = prtSalesDetail.prtFollowDeliGoodsDivNm; // フォロー納品区分名称

                                row["DUOE.DETAILCDRF"] = prtSalesDetail.detailCd; // 明細種別
                                row["DUOE.DETAILCDNMRF"] = GetDUOE_DETAILCDNM(prtSalesDetail.detailCd); // 明細種別名

                                switch (uoeSales.slipCd)
                                {
                                    // 確認伝票
                                    case (int)UoeSales.ctSlipCd.ct_Section:
                                        {
                                            ReflectUOEDetailForSlipOfSection(ref row, prtSalesDetail);
                                        }
                                        break;
                                    // ゼロ伝票
                                    case (int)UoeSales.ctSlipCd.ct_Zero:
                                        {
                                            ReflectUOEDetailForSlipOfZero(ref row, prtSalesDetail);
                                        }
                                        break;
                                    // 各種フォロー伝票
                                    default:
                                        {
                                            ReflectUOEDetailForSlipOfFollow(ref row, prtSalesDetail);
                                        }
                                        break;
                                }
                            }
                            else
                            {
                                row["DUOE.BOCODERF"] = DBNull.Value; // BO区分
                                row["DUOE.UOEDELIGOODSDIVRF"] = DBNull.Value; // UOE納品区分
                                row["DUOE.DELIVEREDGOODSDIVNMRF"] = DBNull.Value; // 納品区分名称
                                row["DUOE.FOLLOWDELIGOODSDIVRF"] = DBNull.Value; // フォロー納品区分
                                row["DUOE.FOLLOWDELIGOODSDIVNMRF"] = DBNull.Value; // フォロー納品区分名称
                                row["DUOE.DETAILCDRF"] = DBNull.Value; // 明細種別
                                row["DUOE.DETAILCDNMRF"] = DBNull.Value; // 明細種別名
                                row["DUOE.PRTACCEPTANORDERCNTRF"] = DBNull.Value; // (印刷用)受注数
                                row["DUOE.PRTSHIPMENTCNTRF"] = DBNull.Value; // (印刷用)出庫数
                                row["DUOE.PRTSHIPMENTCNTZERORF"] = DBNull.Value; // (印刷用)出庫数ゼロ
                                row["DUOE.PRTUOESECTOUTGOODSCNTRF"] = DBNull.Value; // (印刷用)拠点出庫数
                                row["DUOE.PRTUOESECTOUTGOODSCNTZERORF"] = DBNull.Value; // (印刷用)拠点出庫数ゼロ
                                row["DUOE.PRTBOSHIPMENTCNTRF"] = DBNull.Value; // (印刷用)BO出庫数
                                row["DUOE.PRTBOSHIPMENTCNTZERORF"] = DBNull.Value; // (印刷用)BO出庫数ゼロ
                                row["DUOE.PRTACPTREMAINCNTRF"] = DBNull.Value; // (印刷用)受注残数
                            }

                            //-------------------------------------------------------
                            // ※出荷数ゼロの場合は、売単価・定価・金額を印字しない
                            //-------------------------------------------------------
                            if (row["DUOE.PRTSHIPMENTCNTRF"] == DBNull.Value ||
                                 ( prtSalesDetail != null && prtSalesDetail.prtShipmentCnt == 0 ))
                            {
                                row["SALESDETAILRF.LISTPRICERATERF"] = DBNull.Value; // 定価率
                                row["SALESDETAILRF.LISTPRICETAXINCFLRF"] = DBNull.Value; // 定価（税込，浮動）
                                row["SALESDETAILRF.LISTPRICETAXEXCFLRF"] = DBNull.Value; // 定価（税抜，浮動）
                                row["SALESDETAILRF.LISTPRICECHNGCDRF"] = DBNull.Value; // 定価変更区分
                                row["SALESDETAILRF.SALESRATERF"] = DBNull.Value; // 売価率
                                row["SALESDETAILRF.SALESUNPRCTAXINCFLRF"] = DBNull.Value; // 売上単価（税込，浮動）
                                row["SALESDETAILRF.SALESUNPRCTAXEXCFLRF"] = DBNull.Value; // 売上単価（税抜，浮動）
                                row["SALESDETAILRF.SALESMONEYTAXINCRF"] = DBNull.Value; // 売上金額（税込み）
                                row["SALESDETAILRF.SALESMONEYTAXEXCRF"] = DBNull.Value; // 売上金額（税抜き）
                                row["SALESDETAILRF.BFLISTPRICERF"] = DBNull.Value; // 変更前定価
                                row["SALESDETAILRF.BFSALESUNITPRICERF"] = DBNull.Value; // 変更前売価
                                row["SALESDETAILRF.CMPLTSALESUNPRCFLRF"] = DBNull.Value; // 売上単価（一式）
                                row["SALESDETAILRF.CMPLTSALESMONEYRF"] = DBNull.Value; // 売上金額（一式）
                            }

                            # endregion

                            # endregion

                            // 行値引・注釈行の制御
                            # region [行値引・注釈行の制御]
                            if (IsRowDiscount(detailWorks[index]))
                            {
                                row["SALESDETAILRF.LISTPRICETAXINCFLRF"] = DBNull.Value; // 定価（税込，浮動）
                                row["SALESDETAILRF.LISTPRICETAXEXCFLRF"] = DBNull.Value; // 定価（税抜，浮動）
                                row["SALESDETAILRF.SALESUNPRCTAXINCFLRF"] = DBNull.Value; // 売上単価（税込，浮動）
                                row["SALESDETAILRF.SALESUNPRCTAXEXCFLRF"] = DBNull.Value; // 売上単価（税抜，浮動）
                                row["SALESDETAILRF.SALESUNITCOSTRF"] = DBNull.Value; // 原価単価
                                row["SALESDETAILRF.SHIPMENTCNTRF"] = DBNull.Value; // 出荷数
                                row["SALESDETAILRF.ACCEPTANORDERCNTRF"] = DBNull.Value; // 受注数量
                                row["SALESDETAILRF.ACPTANODRADJUSTCNTRF"] = DBNull.Value; // 受注調整数
                                row["SALESDETAILRF.ACPTANODRREMAINCNTRF"] = DBNull.Value; // 受注残数
                                //row[ct_AcptCount] = DBNull.Value; // 受注数
                                //row[ct_ShipCount] = DBNull.Value; // 出荷数
                                row["DADD.STOCKMNGEXISTNMRF"] = DBNull.Value; // 在庫管理有無区分名称
                                row["DADD.GOODSKINDNAMERF"] = DBNull.Value; // 商品属性名称
                                row["DADD.SALESORDERDIVNMRF"] = DBNull.Value; // 売上在庫取寄せ区分名称
                                row["DADD.OPENPRICEDIVNMRF"] = DBNull.Value; // オープン価格区分名称
                                row["DADD.GRSPROFITCHKDIVNMRF"] = DBNull.Value; // 粗利チェック区分名称
                                row["DADD.SALESGOODSNMRF"] = DBNull.Value; // 売上商品区分名称
                                row["DADD.TAXATIONDIVNMRF"] = DBNull.Value; // 課税区分名称
                                row["DADD.PURECODENMRF"] = DBNull.Value; // 純正区分
                                row["DADD.SALESORDERDIVMARKRF"] = DBNull.Value; // 在庫取寄区分マーク
                            }
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/25 ADD
                            else if (IsCommentRow(detailWorks[index]))
                            {
                                row["SALESDETAILRF.LISTPRICETAXINCFLRF"] = DBNull.Value; // 定価（税込，浮動）
                                row["SALESDETAILRF.LISTPRICETAXEXCFLRF"] = DBNull.Value; // 定価（税抜，浮動）
                                row["SALESDETAILRF.SALESUNPRCTAXINCFLRF"] = DBNull.Value; // 売上単価（税込，浮動）
                                row["SALESDETAILRF.SALESUNPRCTAXEXCFLRF"] = DBNull.Value; // 売上単価（税抜，浮動）
                                row["SALESDETAILRF.SALESUNITCOSTRF"] = DBNull.Value; // 原価単価
                                row["SALESDETAILRF.SHIPMENTCNTRF"] = DBNull.Value; // 出荷数
                                row["SALESDETAILRF.ACCEPTANORDERCNTRF"] = DBNull.Value; // 受注数量
                                row["SALESDETAILRF.ACPTANODRADJUSTCNTRF"] = DBNull.Value; // 受注調整数
                                row["SALESDETAILRF.ACPTANODRREMAINCNTRF"] = DBNull.Value; // 受注残数
                                //row[ct_AcptCount] = DBNull.Value; // 受注数
                                //row[ct_ShipCount] = DBNull.Value; // 出荷数
                                row["DADD.STOCKMNGEXISTNMRF"] = DBNull.Value; // 在庫管理有無区分名称
                                row["DADD.GOODSKINDNAMERF"] = DBNull.Value; // 商品属性名称
                                row["DADD.SALESORDERDIVNMRF"] = DBNull.Value; // 売上在庫取寄せ区分名称
                                row["DADD.OPENPRICEDIVNMRF"] = DBNull.Value; // オープン価格区分名称
                                row["DADD.GRSPROFITCHKDIVNMRF"] = DBNull.Value; // 粗利チェック区分名称
                                row["DADD.SALESGOODSNMRF"] = DBNull.Value; // 売上商品区分名称
                                row["DADD.TAXATIONDIVNMRF"] = DBNull.Value; // 課税区分名称
                                row["DADD.PURECODENMRF"] = DBNull.Value; // 純正区分
                                row["DADD.SALESORDERDIVMARKRF"] = DBNull.Value; // 在庫取寄区分マーク

                                // 金額非印字
                                row["SALESDETAILRF.OPENPRICEDIVRF"] = DBNull.Value; // オープン価格区分
                                row["SALESDETAILRF.LISTPRICERATERF"] = DBNull.Value; // 定価率
                                row["SALESDETAILRF.LISTPRICETAXINCFLRF"] = DBNull.Value; // 定価（税込，浮動）
                                row["SALESDETAILRF.LISTPRICETAXEXCFLRF"] = DBNull.Value; // 定価（税抜，浮動）
                                row["SALESDETAILRF.BFLISTPRICERF"] = DBNull.Value; // 変更前定価
                                row["DADD.OPENPRICEDIVNMRF"] = DBNull.Value; // オープン価格区分名称
                                row["SALESDETAILRF.SALESRATERF"] = DBNull.Value; // 売価率
                                row["SALESDETAILRF.SALESUNPRCTAXINCFLRF"] = DBNull.Value; // 売上単価（税込，浮動）
                                row["SALESDETAILRF.SALESUNPRCTAXEXCFLRF"] = DBNull.Value; // 売上単価（税抜，浮動）
                                row["SALESDETAILRF.SALESMONEYTAXINCRF"] = DBNull.Value; // 売上金額（税込み）
                                row["SALESDETAILRF.SALESMONEYTAXEXCRF"] = DBNull.Value; // 売上金額（税抜き）
                                row["SALESDETAILRF.BFSALESUNITPRICERF"] = DBNull.Value; // 変更前売価
                                row["SALESDETAILRF.CMPLTSALESUNPRCFLRF"] = DBNull.Value; // 売上単価（一式）
                                row["SALESDETAILRF.CMPLTSALESMONEYRF"] = DBNull.Value; // 売上金額（一式）
                                row["SALESDETAILRF.COSTRATERF"] = DBNull.Value; // 原価率
                                row["SALESDETAILRF.SALESUNITCOSTRF"] = DBNull.Value; // 原価単価
                                row["SALESDETAILRF.COSTRF"] = DBNull.Value; // 原価
                                row["SALESDETAILRF.GRSPROFITCHKDIVRF"] = DBNull.Value; // 粗利チェック区分
                                row["SALESDETAILRF.BFUNITCOSTRF"] = DBNull.Value; // 変更前原価
                                row["SALESDETAILRF.CMPLTSALESUNITCOSTRF"] = DBNull.Value; // 原価単価（一式）
                                row["SALESDETAILRF.CMPLTCOSTRF"] = DBNull.Value; // 原価金額（一式）
                                row["DADD.GRSPROFITCHKDIVNMRF"] = DBNull.Value; // 粗利チェック区分名称
                                // --- ADD  大矢睦美  2010/05/14 ---------->>>>>
                                row["DADD.GROSSPROFITRATERF"] = DBNull.Value;//粗利率
                                row["DADD.GROSSPROFITRF"] = DBNull.Value;//粗利金額
                                row["DADD.GROSSPROFITRATELTRLRF"] = DBNull.Value;//粗利率リテラル
                                // --- ADD  大矢睦美  2010/05/14 ----------<<<<<
                            }
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/25 ADD

                            # endregion

                            // 半角名対応
                            # region [半角名対応]
                            if (string.IsNullOrEmpty(detailWorks[index].SALESDETAILRF_GOODSNAMEKANARF))
                            {
                                row["SALESDETAILRF.GOODSNAMEKANARF"] = detailWorks[index].SALESDETAILRF_GOODSNAMERF; // 品名カナ←品名セット
                            }
                            row["GOODSURF.GOODSNAMEKANARF"] = row["SALESDETAILRF.GOODSNAMEKANARF"];
                            if (string.IsNullOrEmpty(detailWorks[index].ACCEPTODRCARRF_MAKERHALFNAMERF))
                            {
                                row["ACCEPTODRCARRF.MAKERHALFNAMERF"] = detailWorks[index].ACCEPTODRCARRF_MAKERFULLNAMERF; // メーカー半角名称←全角名セット
                            }
                            if (string.IsNullOrEmpty(detailWorks[index].ACCEPTODRCARRF_MODELHALFNAMERF))
                            {
                                row["ACCEPTODRCARRF.MODELHALFNAMERF"] = detailWorks[index].ACCEPTODRCARRF_MODELFULLNAMERF; // 車種半角名称←全角名セット
                            }
                            # endregion

                            # endregion

                            # region [グループサプレス]
                            // 今回サプレスキー取得
                            GroupSuppressKey suppressKey = GroupSuppressKey.CreateKeyOfCar(row);
                            if (suppressKey.CompareTo(prevSuppressKey) == 0) ReflectSuppressOfCar(ref row);
                            // 退避キー更新
                            prevSuppressKey = suppressKey;
                            # endregion

                            # region [明細項目(伝票タイプ別設定)]
                            // 品番
                            if (eachSlipTypeSet.GoodsNo == 0)
                            {
                                row["SALESDETAILRF.GOODSNORF"] = DBNull.Value; // 商品番号
                                row["GOODSURF.GOODSNONONEHYPHENRF"] = DBNull.Value; // ハイフン無商品番号
                            }
                            // ＢＬコード
                            if (eachSlipTypeSet.BLGoodsCode == 0)
                            {
                                row["SALESDETAILRF.BLGOODSCODERF"] = DBNull.Value; // BL商品コード
                                row["SALESDETAILRF.BLGOODSFULLNAMERF"] = DBNull.Value; // BL商品コード名称（全角）
                                row["BLGOODSCDURF.BLGOODSHALFNAMERF"] = DBNull.Value; // BL商品コード名称（半角）
                            }
                            // 標準価格
                            if (CheckListPricePrint(detailWorks[index], eachSlipTypeSet) == false)
                            {
                                row["SALESDETAILRF.OPENPRICEDIVRF"] = DBNull.Value; // オープン価格区分
                                row["SALESDETAILRF.LISTPRICERATERF"] = DBNull.Value; // 定価率
                                row["SALESDETAILRF.LISTPRICETAXINCFLRF"] = DBNull.Value; // 定価（税込，浮動）
                                row["SALESDETAILRF.LISTPRICETAXEXCFLRF"] = DBNull.Value; // 定価（税抜，浮動）
                                row["SALESDETAILRF.BFLISTPRICERF"] = DBNull.Value; // 変更前定価
                                row["DADD.OPENPRICEDIVNMRF"] = DBNull.Value; // オープン価格区分名称
                            }
                            // 売価
                            if (eachSlipTypeSet.SalesPrice == 0)
                            {
                                row["SALESDETAILRF.SALESRATERF"] = DBNull.Value; // 売価率
                                row["SALESDETAILRF.SALESUNPRCTAXINCFLRF"] = DBNull.Value; // 売上単価（税込，浮動）
                                row["SALESDETAILRF.SALESUNPRCTAXEXCFLRF"] = DBNull.Value; // 売上単価（税抜，浮動）
                                row["SALESDETAILRF.SALESMONEYTAXINCRF"] = DBNull.Value; // 売上金額（税込み）
                                row["SALESDETAILRF.SALESMONEYTAXEXCRF"] = DBNull.Value; // 売上金額（税抜き）
                                row["SALESDETAILRF.BFSALESUNITPRICERF"] = DBNull.Value; // 変更前売価
                                row["SALESDETAILRF.CMPLTSALESUNPRCFLRF"] = DBNull.Value; // 売上単価（一式）
                                row["SALESDETAILRF.CMPLTSALESMONEYRF"] = DBNull.Value; // 売上金額（一式）
                            }
                            // 原価
                            if (eachSlipTypeSet.Cost == 0)
                            {
                                row["SALESDETAILRF.COSTRATERF"] = DBNull.Value; // 原価率
                                row["SALESDETAILRF.SALESUNITCOSTRF"] = DBNull.Value; // 原価単価
                                row["SALESDETAILRF.COSTRF"] = DBNull.Value; // 原価
                                row["SALESDETAILRF.GRSPROFITCHKDIVRF"] = DBNull.Value; // 粗利チェック区分
                                row["SALESDETAILRF.BFUNITCOSTRF"] = DBNull.Value; // 変更前原価
                                row["SALESDETAILRF.CMPLTSALESUNITCOSTRF"] = DBNull.Value; // 原価単価（一式）
                                row["SALESDETAILRF.CMPLTCOSTRF"] = DBNull.Value; // 原価金額（一式）
                                row["DADD.GRSPROFITCHKDIVNMRF"] = DBNull.Value; // 粗利チェック区分名称
                            }
                            // 取寄マーク
                            if (eachSlipTypeSet.SalesOrderDiv == 0)
                            {
                                row["DADD.SALESORDERDIVMARKRF"] = DBNull.Value; // 在庫取寄区分マーク
                                row["DADD.SALESORDERDIVNMRF"] = DBNull.Value; // 売上在庫取寄せ区分名称
                            }
                            # endregion

                            //# region [明細項目(同一ページ内複写)]
                            //// 倉庫・棚番（タイトル１・２のみ）
                            //# region [倉庫・棚番（タイトル１・２のみ）]
                            //if ( inPageCopyCount < 2 )
                            //{
                            //    // [0],[1]のみ
                            //    row[ct_DWarehouseCodeRF] = row["SALESDETAILRF.WAREHOUSECODERF"]; // 倉庫コード
                            //    row[ct_DWarehouseNameRF] = row["SALESDETAILRF.WAREHOUSENAMERF"]; // 倉庫名称
                            //    row[ct_DWarehouseShelfNoRF] = row["SALESDETAILRF.WAREHOUSESHELFNORF"]; // 倉庫棚番
                            //}
                            //else
                            //{
                            //    // [2]以降
                            //    row[ct_DWarehouseCodeRF] = DBNull.Value; // 倉庫コード
                            //    row[ct_DWarehouseNameRF] = DBNull.Value; // 倉庫名称
                            //    row[ct_DWarehouseShelfNoRF] = DBNull.Value; // 倉庫棚番
                            //}
                            //# endregion
                            //# endregion
                            // --- ADD 2009.07.24 劉洋 ------ >>>>>>
                            #region
                            // ABOEMコード
                            if (slipWork.SANDESETTINGRF_PARTSOEMDIV == 0)
                            {
                                row["DADD.ABGOODSNOTE2RF"] = DBNull.Value;
                            }
                            else if (slipWork.SANDESETTINGRF_PARTSOEMDIV == 1)
                            {
                                // 商品マスタ検索
                                GoodsAcs _goodsAcs = new GoodsAcs();
                                GoodsUnitData goodsUnitData;
                                int status = _goodsAcs.Read(slipPrtSet.EnterpriseCode, detailWorks[index].SALESDETAILRF_GOODSMAKERCDRF,
                                    detailWorks[index].SALESDETAILRF_GOODSNORF, out goodsUnitData);
                                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL
                                    && !string.IsNullOrEmpty(goodsUnitData.GoodsNo) && goodsUnitData.LogicalDeleteCode == 0)
                                {
                                    row["DADD.ABGOODSNOTE2RF"] = goodsUnitData.GoodsNote2;
                                }
                                else
                                {
                                    row["DADD.ABGOODSNOTE2RF"] = DBNull.Value;
                                }
                            }
                            else
                            {
                                row["DADD.ABGOODSNOTE2RF"] = DBNull.Value;
                            }
                            // AB純正区分
                            row["DADD.ABGOODSKINDCODERF"] = GetGoodsKindCode(detailWorks[index], slipWork);

                            // DEL 20090828 張莉莉　基本仕様書の改訂履歴NO.6------->>>>>>>>
                            //// 出荷数(マイナス符号なし)
                            //if (detailWorks[index].SALESDETAILRF_SHIPMENTCNTRF == 0)
                            //{
                            //    row["DADD.SHIPMENTCNTNOMINUSRF"] = DBNull.Value;
                            //}
                            //else
                            //{
                            //    row["DADD.SHIPMENTCNTNOMINUSRF"] = Math.Abs(detailWorks[index].SALESDETAILRF_SHIPMENTCNTRF);
                            //}
                            //// 出荷数マイナス符号
                            //if (detailWorks[index].SALESDETAILRF_SHIPMENTCNTRF >= 0)
                            //{
                            //    row["DADD.SHIPMENTCNTMINUSSIGNRF"] = string.Empty;
                            //}
                            //else
                            //{
                            //    if (titleDic.ContainsKey(ct_ShipmentCntMinusSignRF))
                            //    {
                            //        row["DADD.SHIPMENTCNTMINUSSIGNRF"] = titleDic[ct_ShipmentCntMinusSignRF];
                            //    }
                            //}
                            // DEL 20090828 張莉莉　基本仕様書の改訂履歴NO.6-------<<<<<<<<

                            // 売上金額（税抜き）(マイナス符号なし)
                            row["DADD.SALESMONEYTAXEXCNOMINUSRF"] = Math.Abs(detailWorks[index].SALESDETAILRF_SALESMONEYTAXEXCRF);
                            // 売上金額（税抜き）売上金額マイナス符号
                            if (detailWorks[index].SALESDETAILRF_SALESMONEYTAXEXCRF >= 0)
                            {
                                row["DADD.SALESMONEYTAXEXCMINUSSIGNRF"] = string.Empty;
                            }
                            else
                            {
                                if (titleDic.ContainsKey(ct_SalesMoneyTaxExcMinusSignRF))
                                {
                                    row["DADD.SALESMONEYTAXEXCMINUSSIGNRF"] = titleDic[ct_SalesMoneyTaxExcMinusSignRF];
                                }
                            }
                            // 定価金額(税抜)
                            //row["DADD.LISTPRICEMONEYTAXEXCRF"] = detailWorks[index].SALESDETAILRF_LISTPRICETAXEXCFLRF * detailWorks[index].SALESDETAILRF_SHIPMENTCNTRF;
                            double beforeDoubleListpricemoneytaxexcrf = detailWorks[index].SALESDETAILRF_LISTPRICETAXEXCFLRF * detailWorks[index].SALESDETAILRF_SHIPMENTCNTRF;
                            long afterLongListpricemoneytaxexcrf = 0;
                            // 端数処理
                            FractionCalculate.FracCalcMoney(beforeDoubleListpricemoneytaxexcrf, 1, 2, out afterLongListpricemoneytaxexcrf);
                            row["DADD.LISTPRICEMONEYTAXEXCRF"] = afterLongListpricemoneytaxexcrf;

                            // AB本部原価
                            double aBHqSalesUnitCost = GetABHqSalesUnitCost(detailWorks[index], slipWork);
                            row["DADD.ABHQSALESUNITCOSTRF"] = aBHqSalesUnitCost;

                            // AB本部原価金額(マイナス符号なし)
                            //row["DADD.ABHQSALESUNITCOSTNOMINUSRF"] = aBHqSalesUnitCost * detailWorks[index].SALESDETAILRF_SHIPMENTCNTRF;
                            double beforeDoubleAbhqsalesunitconstnominusrf = Math.Abs(aBHqSalesUnitCost * detailWorks[index].SALESDETAILRF_SHIPMENTCNTRF);
                            long afterLongAbhqsalesunitconstnominusrf = 0;
                            // 端数処理
                            FractionCalculate.FracCalcMoney(beforeDoubleAbhqsalesunitconstnominusrf, 1, 2, out afterLongAbhqsalesunitconstnominusrf);
                            row["DADD.ABHQSALESUNITCOSTNOMINUSRF"] = afterLongAbhqsalesunitconstnominusrf;

                            // AB本部原価金額マイナス符号
                            if (aBHqSalesUnitCost * detailWorks[index].SALESDETAILRF_SHIPMENTCNTRF >= 0)
                            {
                                row["DADD.ABHQSALESUNITCOSTMINUSSIGNRF"] = string.Empty;
                            }
                            else
                            {
                                if (titleDic.ContainsKey(ct_ABHqSalesUnitCostMinusSignRF))
                                {
                                    row["DADD.ABHQSALESUNITCOSTMINUSSIGNRF"] = titleDic[ct_ABHqSalesUnitCostMinusSignRF];
                                }
                            }
                            // DEL 20090828 張莉莉　基本仕様書の改訂履歴NO.6------->>>>>>>>
                            //// 行値引行と注釈行取得
                            //bool rowFlg1 = false;
                            //bool rowFlg2 = false;
                            //if (detailWorks[index].SALESDETAILRF_SALESSLIPCDDTLRF == 3)
                            //{
                            //    rowFlg1 = true;
                            //}
                            //if (detailWorks[index].SALESDETAILRF_SALESSLIPCDDTLRF == 2
                            //    && detailWorks[index].SALESDETAILRF_SHIPMENTCNTRF == 0)
                            //{
                            //    rowFlg2 = true;
                            //}
                            // AB商品コード
                            //if (rowFlg1 || rowFlg2)
                            //{
                            //    row["DADD.ABGOODSCODERF"] = 0;
                            //}
                            //else
                            //{
                            if (!string.IsNullOrEmpty(detailWorks[index].SANDEGOODSCDCHGRF_ABGOODSCODE))
                            {
                                row["DADD.ABGOODSCODERF"] = detailWorks[index].SANDEGOODSCDCHGRF_ABGOODSCODE;
                            }
                            else
                            {
                                if (!string.IsNullOrEmpty(slipWork.SANDESETTINGRF_ABGOODSCODE))
                                {
                                    row["DADD.ABGOODSCODERF"] = slipWork.SANDESETTINGRF_ABGOODSCODE;
                                }
                                else
                                {
                                    row["DADD.ABGOODSCODERF"] = 0;
                                }
                            }
                            ////}
                            //// 制約
                            //if (rowFlg1 || rowFlg2)
                            //{
                            //    row["DADD.SHIPMENTCNTNOMINUSRF"] = DBNull.Value;
                            //    row["DADD.LISTPRICEMONEYTAXEXCRF"] = DBNull.Value;
                            //    row["DADD.ABHQSALESUNITCOSTRF"] = DBNull.Value;
                            //    row["DADD.ABHQSALESUNITCOSTNOMINUSRF"] = DBNull.Value;
                            //    row["DADD.ABGOODSCODERF"] = DBNull.Value;

                            //}
                            // DEL 20090828 張莉莉　基本仕様書の改訂履歴NO.6-------<<<<<<<<

                            // (印刷用)拠点出庫数0
                            if (prtSalesDetail != null)
                            {
                                if (uoeSales.slipCd == 0)
                                {
                                    // 確認伝票
                                    if (prtSalesDetail.prtUOESectOutGoodsCnt == 0)
                                    {
                                        // row["DUOE.PrtUOESectOutGoodsCnt0RF"] = DBNull.Value;// DEL 20090915 張莉莉　拠点出庫数0の判定方法修正
                                        row["DUOE.PrtUOESectOutGoodsCnt0RF"] = 0;// ADD 20090915 張莉莉　拠点出庫数0の判定方法修正
                                    }
                                    else
                                    {
                                        // row["DUOE.PrtUOESectOutGoodsCnt0RF"] = 0;// DEL 20090915 張莉莉　拠点出庫数0の判定方法修正
                                        row["DUOE.PrtUOESectOutGoodsCnt0RF"] = DBNull.Value;// ADD 20090915 張莉莉　拠点出庫数0の判定方法修正
                                    }
                                }
                                else if (uoeSales.slipCd == 9)
                                {
                                    // ゼロ伝票

                                    row["DUOE.PrtUOESectOutGoodsCnt0RF"] = 0;
                                }
                                else
                                {
                                    // フォロー伝票
                                    row["DUOE.PrtUOESectOutGoodsCnt0RF"] = DBNull.Value;
                                }
                            }
                            else
                            {
                                row["DUOE.PrtUOESectOutGoodsCnt0RF"] = DBNull.Value;
                            }

                            // DEL 20090915 張莉莉　(印刷用)BO出庫数0の判定方法修正------>>>>>
                            // (印刷用)BO出庫数0
                            //if (prtSalesDetail != null)
                            //{
                            //    // 確認伝票
                            //    if (uoeSales.slipCd == 0)
                            //    {
                            //        if (prtSalesDetail.detailCd == 9)
                            //        {
                            //            if (detailWorks[index].SALESDETAILRF_ACPTANODRREMAINCNTRF == 0)
                            //            {
                            //                row["DUOE.PrtBOShipmentCnt0RF"] = DBNull.Value;
                            //            }
                            //            else
                            //            {
                            //                row["DUOE.PrtBOShipmentCnt0RF"] = 0;
                            //            }
                            //        }
                            //        else
                            //        {
                            //            row["DUOE.PrtBOShipmentCnt0RF"] = DBNull.Value;
                            //        }
                            //    }
                            //    else if (uoeSales.slipCd == 9)
                            //    {
                            //        // ゼロ伝票
                            //        row["DUOE.PrtBOShipmentCnt0RF"] = 0;
                            //    }
                            //    else
                            //    {
                            //        // フォロー伝票
                            //        row["DUOE.PrtBOShipmentCnt0RF"] = DBNull.Value;
                            //    }
                            //}
                            //else
                            //{
                            //    row["DUOE.PrtBOShipmentCnt0RF"] = DBNull.Value;
                            //}
                            // DEL 20090915 張莉莉　(印刷用)BO出庫数0の判定方法修正------<<<<<

                            // 制約
                            if (( uoeSales.slipCd == 0 && detailWorks[index].SALESDETAILRF_SHIPMENTCNTRF == 0 )
                                || ( uoeSales.slipCd == 9 ))
                            {
                                row["DADD.SALESMONEYTAXEXCNOMINUSRF"] = DBNull.Value;
                                row["DADD.LISTPRICEMONEYTAXEXCRF"] = DBNull.Value;
                                row["DADD.ABHQSALESUNITCOSTRF"] = DBNull.Value;
                                row["DADD.ABHQSALESUNITCOSTNOMINUSRF"] = DBNull.Value;
                            }
                            #endregion
                            // --- ADD 2009.07.24 劉洋 ------ <<<<<<
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
                        row[ct_InPageCopyCount] = ( pageIndex * 10 ) + inPageCopyCount;    // 同一ページ内コピーカウント

                        // --- ADD 李占川 2011/08/15---------->>>>>
                        // --- UPD m.suzuki 2011/09/27 ---------->>>>>
                        //if (inPageCopyTitle[0].Count < 5)
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
                            row["PMUOE08001PB.SLIPTITLE1" + (i + 1)] = inPageCopyTitle[0][i];
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

                        if (pageIndex == allPageCount - 1)
                        {
                            // 最終頁
                            if (titleDic.ContainsKey(ct_TaxTitle))
                            {
                                row[ct_TaxTitle] = titleDic[ct_TaxTitle];
                            }
                            else
                            {
                                row[ct_TaxTitle] = "消費税";
                            }
                            if (titleDic.ContainsKey(ct_SubTotalTitle))
                            {
                                row[ct_SubTotalTitle] = titleDic[ct_SubTotalTitle];
                            }
                            else
                            {
                                row[ct_SubTotalTitle] = "小計";
                                // 2010/11/11 Add >>>
                                if (eachSlipTypeSet.SalesPrice != 0)
                                {
                                    if (slipPrtSet.ConsTaxPrtCdRF != 0)
                                    {
                                        if (consTaxLayMethod == 0 || consTaxLayMethod == 1)
                                        {
                                            row["HADD.SALESTOTALTITLERF"] = "総合計";
                                        }
                                        else
                                        {
                                            row["HADD.SALESTOTALTITLERF"] = DBNull.Value;
                                        }
                                    }
                                }
                                // 2010/11/11 Add <<<
                            }
                        }
                        else
                        {
                            // 最終以外
                            row[ct_TaxTitle] = string.Empty;
                            row[ct_SubTotalTitle] = string.Empty;
                        }
                        # endregion

                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/16 ADD
                        // タイトル別印字制御対応
                        ReflectColumnVisibleType(ref row, columnVisibleTypeDic, inPageCopyCount);

                        // 受信時刻をタイトル別非印字にした場合
                        if (row[ct_ReceiveTimeHour] == DBNull.Value)
                        {
                            row[ct_ReceiveTimeLabel] = DBNull.Value;
                        }
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/16 ADD
                        # endregion

                        table.Rows.Add(row);
                    }

                    // --- ADD 李占川 2011/08/15---------->>>>>
                    // サブレポートが有る（サブレポート機能の処理）
                    if (subReportDic.Count > 0)
                    {
                        break;
                    }
                    // --- ADD 李占川 2011/08/15----------<<<<<
                }

                pageStartIndex = Math.Min(pageEndIndex, printEndIndex) + 1;
                pageEndIndex = pageStartIndex + feedCount - 1;
                printEndIndex = pageStartIndex + slipPrtSet.DetailRowCount - 1;
            }
        }

        // --- ADD 2009.07.24 劉洋 ------ >>>>>>
        /// <summary>
        /// 純正区分取得
        /// </summary>
        /// <param name="detailWork">明細情報</param>
        /// <param name="slipWork">売上情報</param>
        /// <returns>結果</returns>
        /// <remarks>
        /// <br>Note       : 純正区分取得する</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.07.24</br>
        /// </remarks>	
        private static int GetGoodsKindCode(FrePSalesDetailWork detailWork, FrePSalesSlipWork slipWork)
        {
            int goodsKindCode = 0;

            // 売上明細データの商品メーカーコード(GoodsMakerCdRF)が「1～99」の場合、「1」をセットする
            if (1 <= detailWork.SALESDETAILRF_GOODSMAKERCDRF && 99 >= detailWork.SALESDETAILRF_GOODSMAKERCDRF)
            {
                goodsKindCode = 1;
            }
            else if (detailWork.SALESDETAILRF_GOODSMAKERCDRF > 100)
            {
                // 商品メーカーコード追加
                ArrayList goodsMakerCdList = new ArrayList();
                goodsMakerCdList.Add(slipWork.SANDESETTINGRF_GOODSMAKERCD1);
                goodsMakerCdList.Add(slipWork.SANDESETTINGRF_GOODSMAKERCD2);
                goodsMakerCdList.Add(slipWork.SANDESETTINGRF_GOODSMAKERCD3);
                goodsMakerCdList.Add(slipWork.SANDESETTINGRF_GOODSMAKERCD4);
                goodsMakerCdList.Add(slipWork.SANDESETTINGRF_GOODSMAKERCD5);
                goodsMakerCdList.Add(slipWork.SANDESETTINGRF_GOODSMAKERCD6);
                goodsMakerCdList.Add(slipWork.SANDESETTINGRF_GOODSMAKERCD7);
                goodsMakerCdList.Add(slipWork.SANDESETTINGRF_GOODSMAKERCD8);
                goodsMakerCdList.Add(slipWork.SANDESETTINGRF_GOODSMAKERCD9);
                goodsMakerCdList.Add(slipWork.SANDESETTINGRF_GOODSMAKERCD10);
                goodsMakerCdList.Add(slipWork.SANDESETTINGRF_GOODSMAKERCD11);
                goodsMakerCdList.Add(slipWork.SANDESETTINGRF_GOODSMAKERCD12);
                goodsMakerCdList.Add(slipWork.SANDESETTINGRF_GOODSMAKERCD13);
                goodsMakerCdList.Add(slipWork.SANDESETTINGRF_GOODSMAKERCD14);
                goodsMakerCdList.Add(slipWork.SANDESETTINGRF_GOODSMAKERCD15);

                // データ比較
                bool isExistFlg = false;
                foreach (int goodsMakserCd in goodsMakerCdList)
                {
                    if (detailWork.SALESDETAILRF_GOODSMAKERCDRF == goodsMakserCd)
                    {
                        isExistFlg = true;
                        break;
                    }
                }

                if (isExistFlg)
                {
                    goodsKindCode = 1;
                }
                else
                {
                    goodsKindCode = 2;
                }
            }
            else if (detailWork.SALESDETAILRF_GOODSMAKERCDRF == 0)
            {
                goodsKindCode = 2;
            }

            return goodsKindCode;
        }

        /// <summary>
        /// AB本部原価取得
        /// </summary>
        /// <param name="detailWork">明細情報</param>
        /// <param name="slipWork">売上情報</param>
        /// <returns>結果</returns>
        /// <remarks>
        /// <br>Note       : AB本部原価取得する</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.07.24</br>
        /// </remarks>	
        private static long GetABHqSalesUnitCost(FrePSalesDetailWork detailWork, FrePSalesSlipWork slipWork)
        {
            long salesUnitCos = 0;
            double result = 0.0;

            // 純正区分取得
            int goodsKindCode = GetGoodsKindCode(detailWork, slipWork);
            // 部品商仕切率
            if (goodsKindCode == 1)
            {
                result = slipWork.SANDESETTINGRF_PURETRADCOMPRATE;
            }
            else
            {
                result = slipWork.SANDESETTINGRF_PRITRADCOMPRATE;
            }
            result = detailWork.SALESDETAILRF_SALESUNPRCTAXEXCFLRF * result / 100;
            // 端数処理
            FractionCalculate.FracCalcMoney(result, 1, 2, out salesUnitCos);

            return salesUnitCos;
        }
        // --- ADD 2009.07.24 劉洋 ------ <<<<<<

        /// <summary>
        /// 行値引の判定処理
        /// </summary>
        /// <param name="detailWork"></param>
        /// <returns></returns>
        private static bool IsRowDiscount(FrePSalesDetailWork detailWork)
        {
            // 売上伝票区分(明細)=2:値引、かつ、出荷数＝ゼロならば行値引
            return ( ( detailWork.SALESDETAILRF_SALESSLIPCDDTLRF == 2 ) && ( detailWork.SALESDETAILRF_SHIPMENTCNTRF == 0 ) );
        }
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/25 ADD
        /// <summary>
        /// 注釈行の判定処理
        /// </summary>
        /// <param name="detailWork"></param>
        /// <returns></returns>
        private static bool IsCommentRow(FrePSalesDetailWork detailWork)
        {
            // 売上伝票区分(明細)=3:注釈ならば注釈行
            return ( detailWork.SALESDETAILRF_SALESSLIPCDDTLRF == 3 );
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/25 ADD
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/16 ADD
        /// <summary>
        /// タイトル別印字制御対応
        /// </summary>
        /// <param name="row"></param>
        /// <param name="columnVisibleTypeDic"></param>
        private static void ReflectColumnVisibleType(ref DataRow row, Dictionary<string, string> columnVisibleTypeDic, int inPageCopyCount)
        {
            // 2010/11/11 Add >>>
            _KSGICustNameFlg = false;
            if (columnVisibleTypeDic.ContainsKey("SALESSLIPRF.SALESSUBTOTALTAXEXCKSGIRF"))
            {
                _KSGICustNameFlg = true;
            }
            // 2010/11/11 Add <<<
            foreach (DataColumn column in row.Table.Columns)
            {
                string columnName = column.ColumnName.ToUpper();

                if (columnVisibleTypeDic.ContainsKey(columnName))
                {
                    bool visible = false;

                    # region [タイトル別Visible取得]
                    switch (columnVisibleTypeDic[columnName])
                    {
                        case "1":
                            if (inPageCopyCount == 0) visible = true; break;
                        case "2":
                            if (inPageCopyCount == 1) visible = true; break;
                        case "3":
                            if (inPageCopyCount == 2) visible = true; break;
                        case "4":
                            if (inPageCopyCount == 3) visible = true; break;
                        case "5":
                            if (inPageCopyCount == 4) visible = true; break;
                        case "6":
                            if (inPageCopyCount != 0) visible = true; break;
                        case "7":
                            if (inPageCopyCount != 1) visible = true; break;
                        case "8":
                            if (inPageCopyCount != 2) visible = true; break;
                        case "9":
                            if (inPageCopyCount != 3) visible = true; break;
                        case "10":
                            if (inPageCopyCount != 4) visible = true; break;
                        case "11":
                            if (inPageCopyCount == 0 || inPageCopyCount == 1) visible = true; break;
                        case "12":
                            if (inPageCopyCount == 0 || inPageCopyCount == 1 || inPageCopyCount == 2) visible = true; break;
                        case "13":
                            if (inPageCopyCount == 2 || inPageCopyCount == 3 || inPageCopyCount == 4) visible = true; break;
                        case "14":
                            if (inPageCopyCount == 3 || inPageCopyCount == 4) visible = true; break;
                        default:
                            visible = true; break;
                    }
                    # endregion

                    // 印字キャンセル
                    if (visible == false)
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
        private static void DivideEnterpriseName(string originName, out string firstHalf, out string lastHalf)
        {
            // ＮＳはマスタ設定での入力可能桁数が半角・全角区別しない仕様なので
            // バイト数ではなく文字数で分解する。

            const int fullLength = 20;
            const int divideLength = 10;

            // スペースで詰める
            originName = originName.PadRight(fullLength, ' ');
            // 分解
            firstHalf = originName.Substring(0, divideLength).TrimEnd();
            lastHalf = originName.Substring(divideLength, divideLength).TrimEnd();
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/16 ADD
        /// <summary>
        /// 定価印字チェック（明細毎に判定）
        /// </summary>
        /// <param name="frePSalesDetailWork"></param>
        /// <param name="eachSlipTypeSet"></param>
        /// <returns></returns>
        private static bool CheckListPricePrint(FrePSalesDetailWork frePSalesDetailWork, EachSlipTypeSet eachSlipTypeSet)
        {
            switch (eachSlipTypeSet.ListPrice)
            {
                // 0:印字しない
                case 0:
                default:
                    return false;
                // 1:印字する
                case 1:
                    return true;
                // 2:掛率＜１
                case 2:
                    {
                        // 単価＜定価の場合のみ印字する
                        return ( frePSalesDetailWork.SALESDETAILRF_SALESUNPRCTAXEXCFLRF < frePSalesDetailWork.SALESDETAILRF_LISTPRICETAXEXCFLRF );
                    }
                    break;
            }
            return false;
        }

        # region [UOE用明細項目セット処理]
        /// <summary>
        /// UOE用明細項目セット処理（確認伝票）
        /// </summary>
        /// <param name="row"></param>
        /// <param name="prtSalesDetail"></param>
        private static void ReflectUOEDetailForSlipOfSection(ref DataRow row, PrtSalesDetail prtSalesDetail)
        {
            // 受注残数算出
            double prtAcptRemainCnt = GetPrtAcptRemainCnt(prtSalesDetail);

            // 受注数
            # region [受注数]
            row["DUOE.PRTACCEPTANORDERCNTRF"] = prtSalesDetail.prtAcceptAnOrderCnt;
            # endregion

            // 出庫数
            # region [出庫数]
            SetValueOrZero(ref row, "DUOE.PRTSHIPMENTCNTRF", "DUOE.PRTSHIPMENTCNTZERORF", prtSalesDetail.prtShipmentCnt);
            # endregion

            // 拠点出庫数
            # region [拠点出庫数]
            SetValueOrZero(ref row, "DUOE.PRTUOESECTOUTGOODSCNTRF", "DUOE.PRTUOESECTOUTGOODSCNTZERORF", prtSalesDetail.prtUOESectOutGoodsCnt);
            # endregion

            // BO出庫数(フォロー出庫数)
            # region [フォロー出庫数]
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/27 DEL
            //if ( prtSalesDetail.detailCd != (int)PrtSalesDetail.ctDetailCd.ct_Zero )
            //{
            //// ゼロ明細でない
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/27 DEL
            if (!IsZero(prtSalesDetail.prtBOShipmentCnt))
            {
                // ゼロ以外
                row["DUOE.PRTBOSHIPMENTCNTRF"] = prtSalesDetail.prtBOShipmentCnt; // (印刷用)BO出庫数
                row["DUOE.PRTBOSHIPMENTCNTZERORF"] = DBNull.Value; // (印刷用)BO出庫数ゼロ
                row["DUOE.PrtBOShipmentCnt0RF"] = DBNull.Value; // ADD 20090915 張莉莉　(印刷用)BO出庫数0の判定方法修正
            }
            else
            {
                // ゼロ
                if (!IsZero(prtAcptRemainCnt))
                {
                    // ゼロ
                    row["DUOE.PRTBOSHIPMENTCNTRF"] = DBNull.Value; // (印刷用)BO出庫数
                    row["DUOE.PRTBOSHIPMENTCNTZERORF"] = ct_ZeroText; // (印刷用)BO出庫数ゼロ
                    row["DUOE.PrtBOShipmentCnt0RF"] = 0;// ADD 20090915 張莉莉　(印刷用)BO出庫数0の判定方法修正
                }
                else
                {
                    // 印字しない
                    row["DUOE.PRTBOSHIPMENTCNTRF"] = DBNull.Value; // (印刷用)BO出庫数
                    row["DUOE.PRTBOSHIPMENTCNTZERORF"] = DBNull.Value; // (印刷用)BO出庫数ゼロ
                    row["DUOE.PrtBOShipmentCnt0RF"] = DBNull.Value;// ADD 20090915 張莉莉　(印刷用)BO出庫数0の判定方法修正
                }
            }
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/27 DEL
            //}
            //else
            //{
            //    // ゼロ明細

            //    row["DUOE.PRTBOSHIPMENTCNTRF"] = DBNull.Value; // (印刷用)BO出庫数
            //    row["DUOE.PRTBOSHIPMENTCNTZERORF"] = ct_ZeroText; // (印刷用)BO出庫数ゼロ
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/27 DEL
            # endregion

            // 受注残数
            # region [受注残数]
            if (!IsZero(prtAcptRemainCnt))
            {
                // ゼロ以外
                row["DUOE.PRTACPTREMAINCNTRF"] = prtAcptRemainCnt; // (印刷用)受注残数
            }
            else
            {
                // ゼロならば印字しない
                row["DUOE.PRTACPTREMAINCNTRF"] = DBNull.Value; // (印刷用)受注残数
            }
            # endregion
        }
        /// <summary>
        /// UOE用明細項目セット処理（フォロー伝票）
        /// </summary>
        /// <param name="row"></param>
        /// <param name="prtSalesDetail"></param>
        private static void ReflectUOEDetailForSlipOfFollow(ref DataRow row, PrtSalesDetail prtSalesDetail)
        {
            // 受注残数算出
            double prtAcptRemainCnt = GetPrtAcptRemainCnt(prtSalesDetail);

            // 受注数
            # region [受注数]
            row["DUOE.PRTACCEPTANORDERCNTRF"] = prtSalesDetail.prtAcceptAnOrderCnt;
            # endregion

            // 出庫数
            # region [出庫数]
            row["DUOE.PRTSHIPMENTCNTRF"] = prtSalesDetail.prtShipmentCnt;
            row["DUOE.PRTSHIPMENTCNTZERORF"] = DBNull.Value;
            # endregion

            // 拠点出庫数
            # region [拠点出庫数]
            // 印字しない
            row["DUOE.PRTUOESECTOUTGOODSCNTRF"] = DBNull.Value;
            row["DUOE.PRTUOESECTOUTGOODSCNTZERORF"] = DBNull.Value;
            # endregion

            // BO出庫数(フォロー出庫数)
            # region [フォロー出庫数]
            // ゼロ以外
            row["DUOE.PRTBOSHIPMENTCNTRF"] = prtSalesDetail.prtBOShipmentCnt; // (印刷用)BO出庫数
            row["DUOE.PRTBOSHIPMENTCNTZERORF"] = DBNull.Value; // (印刷用)BO出庫数ゼロ
            row["DUOE.PrtBOShipmentCnt0RF"] = DBNull.Value; // ADD 20090915 張莉莉　(印刷用)BO出庫数0の判定方法修正
            # endregion

            // 受注残数
            # region [受注残数]
            if (!IsZero(prtAcptRemainCnt))
            {
                // ゼロ以外
                row["DUOE.PRTACPTREMAINCNTRF"] = prtAcptRemainCnt; // (印刷用)受注残数
            }
            else
            {
                // ゼロならば印字しない
                row["DUOE.PRTACPTREMAINCNTRF"] = DBNull.Value; // (印刷用)受注残数
            }
            # endregion
        }
        /// <summary>
        /// UOE用明細項目セット処理（ゼロ伝票）
        /// </summary>
        /// <param name="row"></param>
        /// <param name="prtSalesDetail"></param>
        private static void ReflectUOEDetailForSlipOfZero(ref DataRow row, PrtSalesDetail prtSalesDetail)
        {
            // 受注数
            # region [受注数]
            row["DUOE.PRTACCEPTANORDERCNTRF"] = prtSalesDetail.prtAcceptAnOrderCnt;
            # endregion

            // 出庫数
            # region [出庫数]
            // ゼロ
            row["DUOE.PRTSHIPMENTCNTRF"] = DBNull.Value;
            row["DUOE.PRTSHIPMENTCNTZERORF"] = ct_ZeroText;
            # endregion

            // 拠点出庫数
            # region [拠点出庫数]
            // ゼロ
            row["DUOE.PRTUOESECTOUTGOODSCNTRF"] = DBNull.Value;
            row["DUOE.PRTUOESECTOUTGOODSCNTZERORF"] = ct_ZeroText;
            # endregion

            // BO出庫数(フォロー出庫数)
            # region [フォロー出庫数]
            // ゼロ
            row["DUOE.PRTBOSHIPMENTCNTRF"] = DBNull.Value;
            row["DUOE.PRTBOSHIPMENTCNTZERORF"] = ct_ZeroText;
            row["DUOE.PrtBOShipmentCnt0RF"] = 0; // ADD 20090915 張莉莉　(印刷用)BO出庫数0の判定方法修正
            # endregion

            // 受注残数
            # region [受注残数]
            // 受注数を印字
            row["DUOE.PRTACPTREMAINCNTRF"] = prtSalesDetail.prtAcceptAnOrderCnt; // (印刷用)受注残数
            # endregion
        }
        /// <summary>
        /// 数値orゼロ設定処理
        /// </summary>
        /// <param name="row"></param>
        /// <param name="valueColumn"></param>
        /// <param name="zeroColumn"></param>
        /// <param name="value"></param>
        private static void SetValueOrZero(ref DataRow row, string valueColumn, string zeroColumn, double value)
        {
            if (!IsZero(value))
            {
                // ゼロ以外
                row[valueColumn] = value;
                row[zeroColumn] = DBNull.Value;
            }
            else
            {
                // ゼロ
                row[valueColumn] = DBNull.Value;
                row[zeroColumn] = ct_ZeroText;
            }
        }
        /// <summary>
        /// 数値orゼロ設定処理
        /// </summary>
        /// <param name="row"></param>
        /// <param name="valueColumn"></param>
        /// <param name="zeroColumn"></param>
        /// <param name="value"></param>
        private static void SetValueOrZero(ref DataRow row, string valueColumn, string zeroColumn, int value)
        {
            if (!IsZero(value))
            {
                // ゼロ以外
                row[valueColumn] = value;
                row[zeroColumn] = DBNull.Value;
            }
            else
            {
                // ゼロ
                row[valueColumn] = DBNull.Value;
                row[zeroColumn] = ct_ZeroText;
            }
        }
        # endregion

        # region [グループサプレス]
        /// <summary>
        /// グループサプレス処理
        /// </summary>
        /// <param name="row"></param>
        private static void ReflectSuppressOfCar(ref DataRow row)
        {
            row["ACCEPTODRCARRF.CARMNGNORF"] = DBNull.Value;  // 車両管理番号
            row["ACCEPTODRCARRF.CARMNGCODERF"] = DBNull.Value;  // 車輌管理コード
            row["ACCEPTODRCARRF.NUMBERPLATE1CODERF"] = DBNull.Value;  // 陸運事務所番号
            row["ACCEPTODRCARRF.NUMBERPLATE1NAMERF"] = DBNull.Value;  // 陸運事務局名称
            row["ACCEPTODRCARRF.NUMBERPLATE2RF"] = DBNull.Value;  // 車両登録番号（種別）
            row["ACCEPTODRCARRF.NUMBERPLATE3RF"] = DBNull.Value;  // 車両登録番号（カナ）
            row["ACCEPTODRCARRF.NUMBERPLATE4RF"] = DBNull.Value;  // 車両登録番号（プレート番号）
            row["ACCEPTODRCARRF.FIRSTENTRYDATERF"] = DBNull.Value;  // 初年度
            row["ACCEPTODRCARRF.MAKERCODERF"] = DBNull.Value;  // メーカーコード
            row["ACCEPTODRCARRF.MAKERFULLNAMERF"] = DBNull.Value;  // メーカー全角名称
            row["ACCEPTODRCARRF.MODELCODERF"] = DBNull.Value;  // 車種コード
            row["ACCEPTODRCARRF.MODELSUBCODERF"] = DBNull.Value;  // 車種サブコード
            row["ACCEPTODRCARRF.MODELFULLNAMERF"] = DBNull.Value;  // 車種全角名称
            row["ACCEPTODRCARRF.EXHAUSTGASSIGNRF"] = DBNull.Value;  // 排ガス記号
            row["ACCEPTODRCARRF.SERIESMODELRF"] = DBNull.Value;  // シリーズ型式
            row["ACCEPTODRCARRF.CATEGORYSIGNMODELRF"] = DBNull.Value;  // 型式（類別記号）
            row["ACCEPTODRCARRF.FULLMODELRF"] = DBNull.Value;  // 型式（フル型）
            row["ACCEPTODRCARRF.MODELDESIGNATIONNORF"] = DBNull.Value;  // 型式指定番号
            row["ACCEPTODRCARRF.CATEGORYNORF"] = DBNull.Value;  // 類別番号
            row["ACCEPTODRCARRF.FRAMEMODELRF"] = DBNull.Value;  // 車台型式
            row["ACCEPTODRCARRF.FRAMENORF"] = DBNull.Value;  // 車台番号
            row["ACCEPTODRCARRF.SEARCHFRAMENORF"] = DBNull.Value;  // 車台番号（検索用）
            row["ACCEPTODRCARRF.ENGINEMODELNMRF"] = DBNull.Value;  // エンジン型式名称
            row["ACCEPTODRCARRF.RELEVANCEMODELRF"] = DBNull.Value;  // 関連型式
            row["ACCEPTODRCARRF.SUBCARNMCDRF"] = DBNull.Value;  // サブ車名コード
            row["ACCEPTODRCARRF.MODELGRADESNAMERF"] = DBNull.Value;  // 型式グレード略称
            row["ACCEPTODRCARRF.COLORCODERF"] = DBNull.Value;  // カラーコード
            row["ACCEPTODRCARRF.COLORNAME1RF"] = DBNull.Value;  // カラー名称1
            row["ACCEPTODRCARRF.TRIMCODERF"] = DBNull.Value;  // トリムコード
            row["ACCEPTODRCARRF.TRIMNAMERF"] = DBNull.Value;  // トリム名称
            row["ACCEPTODRCARRF.MILEAGERF"] = DBNull.Value;  // 車両走行距離
            row["ACCEPTODRCARRF.MAKERHALFNAMERF"] = DBNull.Value; // メーカー半角名称
            row["ACCEPTODRCARRF.MODELHALFNAMERF"] = DBNull.Value; // 車種半角名称
            row["DADD.FIRSTENTRYDATEFYRF"] = DBNull.Value; // 初年度西暦年
            row["DADD.FIRSTENTRYDATEFSRF"] = DBNull.Value; // 初年度西暦年略
            row["DADD.FIRSTENTRYDATEFWRF"] = DBNull.Value; // 初年度和暦年
            row["DADD.FIRSTENTRYDATEFMRF"] = DBNull.Value; // 初年度月
            row["DADD.FIRSTENTRYDATEFGRF"] = DBNull.Value; // 初年度元号
            row["DADD.FIRSTENTRYDATEFRRF"] = DBNull.Value; // 初年度略号
            row["DADD.FIRSTENTRYDATEFLSRF"] = DBNull.Value; // 初年度リテラル(/)
            row["DADD.FIRSTENTRYDATEFLPRF"] = DBNull.Value; // 初年度リテラル(.)
            row["DADD.FIRSTENTRYDATEFLYRF"] = DBNull.Value; // 初年度リテラル(年)
            row["DADD.FIRSTENTRYDATEFLMRF"] = DBNull.Value; // 初年度リテラル(月)
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
        private static void ExtractDate(ref DataRow targetRow, int eraNameDispCd, DateTime date, string dateColumnName, bool isMonth)
        {
            // DateTimeを対応するInt値に変換
            int dateInt = 0;
            if (date != DateTime.MinValue)
            {
                if (!isMonth)
                {
                    dateInt = ( date.Year * 10000 ) + ( date.Month * 100 ) + ( date.Day );
                }
                else
                {
                    dateInt = ( date.Year * 100 ) + ( date.Month );
                }
            }

            // 日付展開メソッドに渡す
            ExtractDate(ref targetRow, eraNameDispCd, dateInt, dateColumnName, isMonth);
        }
        ///// <summary>
        ///// 日付関連項目　展開
        ///// </summary>
        ///// <param name="targetRow"></param>
        ///// <param name="eraNameDispCd">0:西暦　1:和暦</param>
        ///// <param name="date"></param>
        ///// <param name="dateColumnName"></param>
        ///// <param name="isMonth"></param>
        //private static void ExtractDate( ref DataRow targetRow, int eraNameDispCd, int date, string dateColumnName, bool isMonth )
        //{
        //    // 和暦フラグ
        //    bool jpEra = (eraNameDispCd == 1);

        //    if ( date != 0 )
        //    {
        //        // 年月項目の場合は、和暦変換に備えて指定年月の最終日に変換する
        //        if ( isMonth )
        //        {
        //            // 指定年月の日数を求める(=その月の最終日)
        //            int dd = DateTime.DaysInMonth( date / 100, date % 100 );

        //            // YYYYMMDDにする
        //            date = (date * 100) + dd;
        //        }

        //        // 年（和暦or西暦）
        //        if ( jpEra )
        //        {
        //            // 和暦
        //            targetRow[string.Format( "{0}{1}RF", dateColumnName, "FW" )] = GetDateFW( date ); // 和暦年
        //            targetRow[string.Format( "{0}{1}RF", dateColumnName, "FG" )] = TDateTime.LongDateToString( "GG", date ); // 和暦元号
        //            targetRow[string.Format( "{0}{1}RF", dateColumnName, "FR" )] = TDateTime.LongDateToString( "gg", date ); // 和暦元号略号
        //            // クリア
        //            targetRow[string.Format( "{0}{1}RF", dateColumnName, "FY" )] = DBNull.Value;
        //            targetRow[string.Format( "{0}{1}RF", dateColumnName, "FS" )] = DBNull.Value;
        //        }
        //        else
        //        {
        //            // 西暦
        //            targetRow[string.Format( "{0}{1}RF", dateColumnName, "FY" )] = (date / 10000); // 西暦年
        //            targetRow[string.Format( "{0}{1}RF", dateColumnName, "FS" )] = (date / 10000) % 100; // 西暦年(略)
        //            // クリア
        //            targetRow[string.Format( "{0}{1}RF", dateColumnName, "FW" )] = DBNull.Value;
        //            targetRow[string.Format( "{0}{1}RF", dateColumnName, "FG" )] = DBNull.Value;
        //            targetRow[string.Format( "{0}{1}RF", dateColumnName, "FR" )] = DBNull.Value;
        //        }

        //        // 月
        //        targetRow[string.Format( "{0}{1}RF", dateColumnName, "FM" )] = (date / 100) % 100; // 月

        //        // リテラル系
        //        targetRow[string.Format( "{0}{1}RF", dateColumnName, "FLS" )] = "/";
        //        targetRow[string.Format( "{0}{1}RF", dateColumnName, "FLP" )] = ".";
        //        targetRow[string.Format( "{0}{1}RF", dateColumnName, "FLY" )] = "年";
        //        targetRow[string.Format( "{0}{1}RF", dateColumnName, "FLM" )] = "月";

        //        if ( !isMonth )
        //        {
        //            // 年月日の場合のみセット
        //            targetRow[string.Format( "{0}{1}RF", dateColumnName, "FD" )] = (date % 100); // 日
        //            targetRow[string.Format( "{0}{1}RF", dateColumnName, "FLD" )] = "日";
        //        }
        //    }
        //    else
        //    {
        //        // 無効な日付ならば空白
        //        targetRow[string.Format( "{0}{1}RF", dateColumnName, "FY" )] = DBNull.Value;
        //        targetRow[string.Format( "{0}{1}RF", dateColumnName, "FS" )] = DBNull.Value;
        //        targetRow[string.Format( "{0}{1}RF", dateColumnName, "FW" )] = DBNull.Value;
        //        targetRow[string.Format( "{0}{1}RF", dateColumnName, "FM" )] = DBNull.Value;
        //        targetRow[string.Format( "{0}{1}RF", dateColumnName, "FG" )] = DBNull.Value;
        //        targetRow[string.Format( "{0}{1}RF", dateColumnName, "FR" )] = DBNull.Value;
        //        targetRow[string.Format( "{0}{1}RF", dateColumnName, "FLS" )] = DBNull.Value;
        //        targetRow[string.Format( "{0}{1}RF", dateColumnName, "FLP" )] = DBNull.Value;
        //        targetRow[string.Format( "{0}{1}RF", dateColumnName, "FLY" )] = DBNull.Value;
        //        targetRow[string.Format( "{0}{1}RF", dateColumnName, "FLM" )] = DBNull.Value;

        //        if ( !isMonth )
        //        {
        //            targetRow[string.Format( "{0}{1}RF", dateColumnName, "FD" )] = DBNull.Value;
        //            targetRow[string.Format( "{0}{1}RF", dateColumnName, "FLD" )] = DBNull.Value;
        //        }
        //    }
        //}
        /// <summary>
        /// 日付関連項目　展開
        /// </summary>
        /// <param name="targetRow"></param>
        /// <param name="eraNameDispCd">0:西暦　1:和暦</param>
        /// <param name="date"></param>
        /// <param name="dateColumnName"></param>
        /// <param name="isMonth"></param>
        private static void ExtractDate(ref DataRow targetRow, int eraNameDispCd, int date, string dateColumnName, bool isMonth)
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
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.07.21 DEL
            //bool jpEra = (eraNameDispCd == 1);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.07.21 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.07.21 ADD
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
                jpEra = ( eraNameDispCd == 1 );
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.07.21 ADD
            // 年のみ判定フラグ
            bool isYear = false;

            if (date != 0)
            {
                // 年月項目の場合は、和暦変換に備えて指定年月の最終日に変換する
                if (isMonth)
                {
                    // 年のみ判定("200900"→2009年)
                    isYear = ( date % 100 == 0 );

                    if (isYear)
                    {
                        //-----------------------------------------------
                        // 年のみ
                        //-----------------------------------------------

                        // 指定年月の日数を求める(=その年の最終日)※12/31ですが念のため…
                        int dd = DateTime.DaysInMonth(date / 100, 12);

                        // YYYYMMDDにする
                        date = ( (int)( date / 100 ) * 10000 ) + ( 12 * 100 ) + dd;
                    }
                    else
                    {
                        //-----------------------------------------------
                        // 年月のみ
                        //-----------------------------------------------

                        // 指定年月の日数を求める(=その月の最終日)
                        int dd = DateTime.DaysInMonth(date / 100, date % 100);

                        // YYYYMMDDにする
                        date = ( date * 100 ) + dd;
                    }
                }

                // 年（和暦or西暦）
                if (jpEra)
                {
                    // 和暦
                    targetRow[string.Format("{0}{1}RF", dateColumnName, "FW")] = GetDateFW(date); // 和暦年
                    targetRow[string.Format("{0}{1}RF", dateColumnName, "FG")] = TDateTime.LongDateToString("GG", date); // 和暦元号
                    targetRow[string.Format("{0}{1}RF", dateColumnName, "FR")] = TDateTime.LongDateToString("gg", date); // 和暦元号略号
                    // クリア
                    targetRow[string.Format("{0}{1}RF", dateColumnName, "FY")] = DBNull.Value;
                    targetRow[string.Format("{0}{1}RF", dateColumnName, "FS")] = DBNull.Value;
                }
                else
                {
                    // 西暦
                    targetRow[string.Format("{0}{1}RF", dateColumnName, "FY")] = ( date / 10000 ); // 西暦年
                    targetRow[string.Format("{0}{1}RF", dateColumnName, "FS")] = ( date / 10000 ) % 100; // 西暦年(略)
                    // クリア
                    targetRow[string.Format("{0}{1}RF", dateColumnName, "FW")] = DBNull.Value;
                    targetRow[string.Format("{0}{1}RF", dateColumnName, "FG")] = DBNull.Value;
                    targetRow[string.Format("{0}{1}RF", dateColumnName, "FR")] = DBNull.Value;
                }

                // 年リテラル
                targetRow[string.Format("{0}{1}RF", dateColumnName, "FLY")] = "年";

                if (!isYear)
                {
                    // 月
                    targetRow[string.Format("{0}{1}RF", dateColumnName, "FM")] = ( date / 100 ) % 100; // 月

                    // リテラル系
                    targetRow[string.Format("{0}{1}RF", dateColumnName, "FLS")] = "/";
                    targetRow[string.Format("{0}{1}RF", dateColumnName, "FLP")] = ".";
                    targetRow[string.Format("{0}{1}RF", dateColumnName, "FLM")] = "月";

                    if (!isMonth)
                    {
                        targetRow[string.Format("{0}{1}RF", dateColumnName, "FD")] = ( date % 100 ); // 日
                        targetRow[string.Format("{0}{1}RF", dateColumnName, "FLD")] = "日";
                    }
                }
            }
            else
            {
                // 無効な日付ならば空白
                targetRow[string.Format("{0}{1}RF", dateColumnName, "FY")] = DBNull.Value;
                targetRow[string.Format("{0}{1}RF", dateColumnName, "FS")] = DBNull.Value;
                targetRow[string.Format("{0}{1}RF", dateColumnName, "FW")] = DBNull.Value;
                targetRow[string.Format("{0}{1}RF", dateColumnName, "FM")] = DBNull.Value;
                targetRow[string.Format("{0}{1}RF", dateColumnName, "FG")] = DBNull.Value;
                targetRow[string.Format("{0}{1}RF", dateColumnName, "FR")] = DBNull.Value;
                targetRow[string.Format("{0}{1}RF", dateColumnName, "FLS")] = DBNull.Value;
                targetRow[string.Format("{0}{1}RF", dateColumnName, "FLP")] = DBNull.Value;
                targetRow[string.Format("{0}{1}RF", dateColumnName, "FLY")] = DBNull.Value;
                targetRow[string.Format("{0}{1}RF", dateColumnName, "FLM")] = DBNull.Value;

                if (!isMonth)
                {
                    targetRow[string.Format("{0}{1}RF", dateColumnName, "FD")] = DBNull.Value;
                    targetRow[string.Format("{0}{1}RF", dateColumnName, "FLD")] = DBNull.Value;
                }
            }
        }
        /// <summary>
        /// 和暦年取得処理（H20の"20"のみを取得する）
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        private static int GetDateFW(int date)
        {
            // 和暦略号を取得
            string date_gg = TDateTime.LongDateToString("gg", date);  // H
            string date_exggyy = TDateTime.LongDateToString("exggyy", date);  // H20

            // "H20" から "H" を取り除いて "20" を取得する
            return ToInt(date_exggyy.Substring(date_gg.Length, date_exggyy.Length - date_gg.Length));

        }
        /// <summary>
        /// 数値変換処理
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        private static int ToInt(string text)
        {
            try
            {
                return Int32.Parse(text);
            }
            catch
            {
                return 0;
            }
        }
        /// <summary>
        /// 明細総行数の算出
        /// </summary>
        /// <param name="dataCount"></param>
        /// <param name="feedCount"></param>
        /// <returns></returns>
        private static int GetAllDetailCount(int dataCount, int feedCount)
        {
            if (dataCount % feedCount == 0)
            {
                // 割り切れる → データ行数と明細総行数はイコールでＯＫ
                return dataCount;
            }
            else
            {
                // 割り切れない → 必要な余白を含めた明細行数を返す
                return ( dataCount + ( feedCount - ( dataCount % feedCount ) ) );
            }
        }
        /// <summary>
        /// 現在ページ数取得
        /// </summary>
        /// <param name="index"></param>
        /// <param name="feedCount"></param>
        /// <returns></returns>
        private static int GetPageCount(int index, int feedCount)
        {
            return ( index / feedCount ) + 1;
        }
        # endregion

        # region [複写タイトル取得処理]
        /// <summary>
        /// 複写タイトル取得処理
        /// </summary>
        /// <param name="slipPrtSet"></param>
        /// <returns></returns>
        private static List<List<string>> GetInPageCopyTitles(SlipPrtSetWork slipPrtSet)
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
            retList1.Add(slipPrtSet.TitleName1);
            List<string> title1List = new List<string>(new string[] { slipPrtSet.TitleName102, slipPrtSet.TitleName103, slipPrtSet.TitleName104, slipPrtSet.TitleName105 });
            for (int index = 0; index < title1List.Count; index++)
            {
                // 空白があればそこで終了
                if (title1List[index] == string.Empty) break;
                // １つ追加
                retList1.Add(title1List[index]);
            }
            retList.Add(retList1);

            //----------------------------------------------
            // 複写２枚目以降はベタでコピーする
            //----------------------------------------------
            retList.Add(new List<string>(new string[] { slipPrtSet.TitleName2, slipPrtSet.TitleName202, slipPrtSet.TitleName203, slipPrtSet.TitleName204, slipPrtSet.TitleName205 }));
            retList.Add(new List<string>(new string[] { slipPrtSet.TitleName3, slipPrtSet.TitleName302, slipPrtSet.TitleName303, slipPrtSet.TitleName304, slipPrtSet.TitleName305 }));
            retList.Add(new List<string>(new string[] { slipPrtSet.TitleName4, slipPrtSet.TitleName402, slipPrtSet.TitleName403, slipPrtSet.TitleName404, slipPrtSet.TitleName405 }));

            // 返却
            return retList;
        }
        # endregion

        # region [伝票転嫁方式取得]
        /// <summary>
        /// 伝票転嫁方式取得
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        /// <remarks>
        public static int GetSALESSLIPRF_CONSTAXLAYMETHODRF(DataTable table)
        {
            try
            {
                // 消費税転嫁方式（0:伝票単位1:明細単位2:請求親 3:請求子 9:非課税）
                return (int)table.Rows[0]["SALESSLIPRF.CONSTAXLAYMETHODRF"];
            }
            catch
            {
                return 0;
            }
        }

        // --- ADD 2009.08.05 劉洋 ------ >>>>>>
        /// <summary>
        /// 売上伝票合計（税抜き）(マイナス符号なし)取得
        /// </summary>
        /// <param name="table">テーブル</param>
        /// <returns>結果</returns>
        /// <remarks>
        /// <br>Note       : 売上伝票合計（税抜き）(マイナス符号なし)取得する</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.07.24</br>
        /// </remarks>
        public static Int64 GetHADD_SALESTOTALTAXEXCNOMINUSRF(DataTable table)
        {
            try
            {
                // 売上伝票合計（税抜き）(マイナス符号なし)
                return (Int64)table.Rows[0]["HADD.SALESTOTALTAXEXCNOMINUSRF"];
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// AB本部原価金額合計(マイナス符号なし)  取得
        /// </summary>
        /// <param name="table">テーブル</param>
        /// <returns>結果</returns>
        /// <remarks>
        /// <br>Note       : AB本部原価金額合計(マイナス符号なし)取得する</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.07.24</br>
        /// </remarks>
        public static Int64 GetHADD_ABHQTOTALCOSTNOMINUSRF(DataTable table)
        {
            try
            {
                // AB本部原価金額合計(マイナス符号なし)
                return (Int64)table.Rows[0]["HADD.ABHQTOTALCOSTNOMINUSRF"];
            }
            catch
            {
                return 0;
            }
        }

        // --- ADD 2009.08.05 劉洋 ------ <<<<<<
        # endregion

        # region [データゼロ判定]
        /// <summary>
        /// 文字列コードのゼロ判定
        /// </summary>
        /// <param name="textValue"></param>
        /// <returns></returns>
        private static bool IsZero(string textValue)
        {
            if (textValue == null || textValue.Trim() == string.Empty) return true;

            try
            {
                return ( Int32.Parse(textValue) == 0 );
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
        private static bool IsZero(int intValue)
        {
            return ( intValue == 0 );
        }
        /// <summary>
        /// double値のゼロ判定
        /// </summary>
        /// <param name="doubleValue"></param>
        /// <returns></returns>
        private static bool IsZero(double doubleValue)
        {
            return ( doubleValue == 0 );
        }
        # endregion

        # region [UOE専用項目]
        /// <summary>
        /// UOE伝票種別名称取得
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        private static string GetHUOE_SLIPCDNM(int slipCd)
        {
            //0:確認伝票 1:BO1伝票 2:BO2伝票 3:BO3伝票 4:EO伝票 5:メーカーフォロー伝票 8:他BO伝票 9:ゼロ伝票
            switch (slipCd)
            {
                case 0:
                    return "確認伝票";
                case 1:
                    return "BO1伝票";
                case 2:
                    return "BO2伝票";
                case 3:
                    return "BO3伝票";
                case 4:
                    return "EO伝票";
                case 5:
                    return "メーカーフォロー伝票";
                case 8:
                    return "他BO伝票";
                case 9:
                    return "ゼロ伝票";
                default:
                    return string.Empty;
            }
        }
        /// <summary>
        /// UOE明細種別名取得
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        private static string GetDUOE_DETAILCDNM(int detailCd)
        {
            //0:通常明細 9:ゼロ明細
            switch (detailCd)
            {
                case 0:
                    return "通常明細";
                case 9:
                    return "ゼロ明細";
                default:
                    return string.Empty;
            }
        }
        /// <summary>
        /// 受注残数算出
        /// </summary>
        /// <param name="prtSalesDetail"></param>
        /// <returns></returns>
        private static double GetPrtAcptRemainCnt(PrtSalesDetail prtSalesDetail)
        {
            //--------------------------------------
            // 受注数と出荷数の型が違うため、
            // 一度decimalに変換してから差分をとり、
            // doubleに変換します。
            //--------------------------------------

            // 受注数 (double→decimal)
            decimal decAcceptAnOrderCnt = (decimal)prtSalesDetail.prtAcceptAnOrderCnt;
            // 出荷数（int→decimal）
            decimal decShipmentCnt = (decimal)prtSalesDetail.prtShipmentCnt;

            //（decimal→double）
            return (double)( decAcceptAnOrderCnt - decShipmentCnt );
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

            list.Add("HLG.CUSTOMERNAMERF");  // 【縦倍】得意先名称
            list.Add("HLG.CUSTOMERNAME2RF");  //【縦倍】 得意先名称2
            list.Add("HLG.CUSTOMERSNMRF");  // 【縦倍】得意先略称
            list.Add("HLG.HONORIFICTITLERF");  // 【縦倍】敬称
            list.Add("HLG.PRINTCUSTOMERNAMEJOIN12RF"); //【縦倍】得意先名１＋得意先名２
            list.Add("HLG.PRINTCUSTOMERNAMEJOIN12HNRF"); // 【縦倍】得意先名１＋得意先名２＋敬称
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.07.21 ADD
            list.Add("HLG.COMPANYNAME1RF"); // 【縦倍】自社名称1
            list.Add("HLG.COMPANYNAME2RF"); // 【縦倍】自社名称2
            list.Add("HLG.PRINTENTERPRISENAME1FHRF"); // 【縦倍】自社名１（前半）
            list.Add("HLG.PRINTENTERPRISENAME1LHRF"); // 【縦倍】自社名１（後半）
            list.Add("HLG.PRINTENTERPRISENAME2FHRF"); // 【縦倍】自社名２（前半）
            list.Add("HLG.PRINTENTERPRISENAME2LHRF"); // 【縦倍】自社名２（後半）
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.07.21 ADD
            // 2011/05/27 Add >>>
            list.Add("HLG.PRINTCUSTNAMEJOIN12HNOFBYTERF");//  （縦倍）得意先名称１＋得意先名称２＋敬称（バイト計算）
            // 2011/05/27 Add <<<

            return list;
        }
        # endregion

        // 2011/05/27 Add >>>
        #region [印刷データ情報取得]
        /// <summary>
        /// 車台番号　取得
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public static string GetHADD_FRAMENORF(DataTable table)
        {
            try
            {
                // 車台番号
                return (string)table.Rows[0]["HADD.FRAMENORF"];
            }
            catch
            {
                return string.Empty;
            }
        }
        #endregion
        // 2011/05/27 Add <<<

        # endregion

        # region [グループサプレスキー]
        /// <summary>
        /// グループサプレスキー
        /// </summary>
        private struct GroupSuppressKey : IComparable<GroupSuppressKey>
        {
            /// <summary>ページ数</summary>
            private int _page;
            /// <summary>型式</summary>
            private string _fullModel;
            /// <summary>車種</summary>
            private string _modelFullName;
            /// <summary>年式</summary>
            private int _firstEntryDate;
            /// <summary>
            /// ページ数
            /// </summary>
            public int Page
            {
                get { return _page; }
                set { _page = value; }
            }
            /// <summary>
            /// 型式
            /// </summary>
            /// <remarks>型式・車種・年式でキーとする</remarks>
            public string FullModel
            {
                get { return _fullModel; }
                set { _fullModel = value; }
            }
            /// <summary>
            /// 車種
            /// </summary>
            /// <remarks>型式・車種・年式でキーとする</remarks>
            public string ModelFullName
            {
                get { return _modelFullName; }
                set { _modelFullName = value; }
            }
            /// <summary>
            /// 年式
            /// </summary>
            /// <remarks>型式・車種・年式でキーとする</remarks>
            public int FirstEntryDate
            {
                get { return _firstEntryDate; }
                set { _firstEntryDate = value; }
            }
            /// <summary>
            /// コンストラクタ
            /// </summary>
            /// <param name="page">ページ数</param>
            /// <param name="fullModel">型式</param>
            /// <param name="modelFullName">車種</param>
            /// <param name="firstEntryDate">年式</param>
            public GroupSuppressKey(int page, string fullModel, string modelFullName, int firstEntryDate)
            {
                _page = page;
                _fullModel = fullModel;
                _modelFullName = modelFullName;
                _firstEntryDate = firstEntryDate;
            }
            /// <summary>
            /// 比較処理
            /// </summary>
            /// <param name="other"></param>
            /// <returns></returns>
            public int CompareTo(GroupSuppressKey other)
            {
                int result;

                result = this.Page.CompareTo(other.Page);
                if (result != 0) return result;

                result = this.FullModel.CompareTo(other.FullModel);
                if (result != 0) return result;

                result = this.ModelFullName.CompareTo(other.ModelFullName);
                if (result != 0) return result;

                result = this.FirstEntryDate.CompareTo(other.FirstEntryDate);

                return result;
            }
            /// <summary>
            /// 初期化済みインスタンス取得
            /// </summary>
            /// <returns></returns>
            public static GroupSuppressKey Create()
            {
                GroupSuppressKey key = new GroupSuppressKey();
                key.Page = 0;
                key.FullModel = string.Empty;
                key.ModelFullName = string.Empty;
                key.FirstEntryDate = 0;
                return key;
            }
            /// <summary>
            /// 車輌情報キー
            /// </summary>
            /// <param name="row"></param>
            /// <returns></returns>
            public static GroupSuppressKey CreateKeyOfCar(DataRow row)
            {
                GroupSuppressKey key = Create();
                // ページ数
                if (row[ct_PageCount] != DBNull.Value)
                {
                    key.Page = (int)row[ct_PageCount];
                }
                else
                {
                    key.Page = 0;
                }
                // 型式
                if (row["ACCEPTODRCARRF.FULLMODELRF"] != DBNull.Value)
                {
                    key.FullModel = (string)row["ACCEPTODRCARRF.FULLMODELRF"];
                }
                else
                {
                    key.FullModel = string.Empty;
                }
                // 車種名
                if (row["ACCEPTODRCARRF.MODELFULLNAMERF"] != DBNull.Value)
                {
                    key.ModelFullName = (string)row["ACCEPTODRCARRF.MODELFULLNAMERF"];
                }
                else
                {
                    key.ModelFullName = string.Empty;
                }
                // 年式
                if (row["ACCEPTODRCARRF.FIRSTENTRYDATERF"] != DBNull.Value)
                {
                    key.FirstEntryDate = (int)row["ACCEPTODRCARRF.FIRSTENTRYDATERF"];
                }
                else
                {
                    key.FirstEntryDate = 0;
                }
                return key;
            }
        }
        # endregion

        # region [各種区分名称取得]
        /// <summary>
        /// 受注ステータス名称
        /// </summary>
        /// <param name="acptAnOdrSt"></param>
        /// <param name="salesSlipCd"></param>
        /// <returns></returns>
        private static string GetHADD_ACPTANODRSTNMRF(int acptAnOdrSt, int salesSlipCd)
        {
            // 10:見積,20:受注,30:売上,40:出荷
            switch (acptAnOdrSt)
            {
                case 10:
                    return "見積";
                case 20:
                    return "受注";
                case 30:
                    if (salesSlipCd == 0)
                    {
                        return "売上";
                    }
                    else
                    {
                        return "返品";
                    }
                case 40:
                    return "貸出";
                default:
                    return string.Empty;
            }
        }
        /// <summary>
        /// 赤伝区分名称
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        private static string GetHADD_DEBITNOTEDIVNMRF(int code)
        {
            // 0:黒伝,1:赤伝,2:元黒
            switch (code)
            {
                case 0:
                    return "黒伝";
                case 1:
                    return "赤伝";
                case 2:
                    return "元黒";
                default:
                    return string.Empty;
            }
        }
        ///// <summary>
        ///// ＵＯＥ伝票区分名称
        ///// </summary>
        ///// <param name="code"></param>
        ///// <returns></returns>
        //private static string GetHADD_SALESSLIPNMRF( int code )
        //{
        //    // 0:売上,1:返品
        //    switch ( code )
        //    {
        //        case 0:
        //            return "売上";
        //        case 1:
        //            return "返品";
        //        default:
        //            return string.Empty;
        //    }
        //}
        /// <summary>
        /// 売上商品区分名称
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        private static string GetHADD_SALESGOODSNMRF(int code)
        {
            // 0:商品,1:商品外,2:消費税調整,3:残高調整,4:売掛用消費税調整,5:売掛用残高調整,10:売掛用消費税調整(自動)
            switch (code)
            {
                case 0:
                    return "商品";
                case 1:
                    return "商品外";
                case 2:
                    return "消費税調整";
                case 3:
                    return "残高調整";
                case 4:
                    return "売掛用消費税調整";
                case 5:
                    return "売掛用残高調整";
                case 10:
                    return "売掛用消費税調整(自動)";
                default:
                    return string.Empty;
            }
        }
        /// <summary>
        /// 売掛区分名称
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        private static string GetHADD_ACCRECDIVNMRF(int code)
        {
            // 0:売掛なし,1:売掛
            switch (code)
            {
                case 0:
                    return "売掛なし";
                case 1:
                    return "売掛";
                default:
                    return string.Empty;
            }
        }
        /// <summary>
        /// 来勘区分名称
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        private static string GetHADD_DELAYPAYMENTDIVNMRF(int code)
        {
            // 0:当月(来勘なし),1:来月,2:再来月…9:9ヵ月後
            switch (code)
            {
                case 0:
                    return "当月";
                case 1:
                    return "来月";
                case 2:
                    return "再来月";
                default:
                    return string.Format("{0}ヵ月後", code);
            }
        }
        /// <summary>
        /// 見積区分名称
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        private static string GetHADD_ESTIMATEDIVIDENMRF(int hADD_ESTIMATEDIVIDENMRF)
        {
            // 1:通常見積　2:単価見積
            switch (hADD_ESTIMATEDIVIDENMRF)
            {
                case 1:
                    return "通常見積";
                case 2:
                    return "単価見積";
                default:
                    return string.Empty;
            }
        }
        /// <summary>
        /// 消費税転嫁方式名称
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        private static string GetHADD_CONSTAXLAYMETHODNMRF(int code)
        {
            // 0:伝票単位1:明細単位2:請求親 3:請求子 9:非課税
            switch (code)
            {
                case 0:
                    return "伝票単位";
                case 1:
                    return "明細単位";
                case 2:
                    return "請求(親)";
                case 3:
                    return "請求(子)";
                case 9:
                    return "非課税";
                default:
                    return string.Empty;
            }
        }
        /// <summary>
        /// 自動入金区分名称
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        private static string GetHADD_AUTODEPOSITNMRF(int code)
        {
            // 0:通常入金,1:自動入金
            switch (code)
            {
                case 0:
                    return "通常入金";
                case 1:
                    return "自動入金";
                default:
                    return string.Empty;
            }
        }
        /// <summary>
        /// 伝票発行済区分名称
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        private static string GetHADD_SLIPPRINTFINISHNMRF(int code)
        {
            // 0:未発行 1:発行済
            switch (code)
            {
                case 0:
                    return "未発行";
                case 1:
                    return "発行済";
                default:
                    return string.Empty;
            }
        }
        /// <summary>
        /// 一式伝票区分名称
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        private static string GetHADD_COMPLETENMRF(int code)
        {
            // 0:通常伝票,1:一式伝票
            switch (code)
            {
                case 0:
                    return "通常伝票";
                case 1:
                    return "一式伝票";
                default:
                    return string.Empty;
            }
        }
        /// <summary>
        /// 在庫管理有無区分名称
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        private static string GetDADD_STOCKMNGEXISTNMRF(int code)
        {
            // 0:在庫管理しない,1:在庫管理する
            switch (code)
            {
                case 0:
                    return "";
                case 1:
                    return "在庫管理";
                default:
                    return string.Empty;
            }
        }
        /// <summary>
        /// 商品属性名称
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        private static string GetDADD_GOODSKINDNAMERF(int code)
        {
            // 0:純正 1:優良
            switch (code)
            {
                case 0:
                    return "純正";
                case 1:
                    return "優良";
                default:
                    return string.Empty;
            }
        }
        /// <summary>
        /// 売上在庫取寄せ区分名称
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        private static string GetDADD_SALESORDERDIVNMRF(int code)
        {
            // 0:取寄せ，1:在庫
            switch (code)
            {
                case 0:
                    return "取寄";
                case 1:
                    return "在庫";
                default:
                    return string.Empty;
            }
        }
        /// <summary>
        /// オープン価格区分名称
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        private static string GetDADD_OPENPRICEDIVNMRF(int code)
        {
            // 0:通常／1:オープン価格
            switch (code)
            {
                case 0:
                    return "";
                case 1:
                    return "オープン価格";
                default:
                    return string.Empty;
            }
        }
        /// <summary>
        /// 粗利チェック区分名称
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        private static string GetDADD_GRSPROFITCHKDIVNMRF(int code)
        {
            // 0:正常,1:原価割れ,2:利益の上げ過ぎ
            switch (code)
            {
                case 0:
                    return "正常";
                case 1:
                    return "";
                case 2:
                    return "";
                default:
                    return string.Empty;
            }
        }
        /// <summary>
        /// 売上商品区分名称
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        private static string GetDADD_SALESGOODSNMRF(int code)
        {
            // 0:商品,1:商品外,2:消費税調整,3:残高調整,4:売掛用消費税調整,5:売掛用残高調整,10:売掛用消費税調整(自動),11:相殺,12:相殺(自動)
            switch (code)
            {
                case 0:
                    return "商品";
                case 1:
                    return "商品外";
                case 2:
                    return "消費税調整";
                case 3:
                    return "残高調整";
                case 4:
                    return "売掛用消費税調整";
                case 5:
                    return "売掛用残高調整";
                case 10:
                    return "売掛用消費税調整(自動)";
                case 11:
                    return "相殺";
                case 12:
                    return "相殺(自動)";
                default:
                    return string.Empty;
            }
        }
        /// <summary>
        /// 課税区分名称
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        private static string GetDADD_TAXATIONDIVNMRF(int code)
        {
            // 0:課税,1:非課税,2:課税（内税）
            switch (code)
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
        /// 純正区分
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        private static string GetDADD_PURECODENMRF(int code)
        {
            // 0:純正、1:優良
            switch (code)
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

        #region[粗利額(明細)の計算]
        // --- ADD  大矢睦美  2010/05/14 ---------->>>>>
        /// <summary>
        /// 粗利額(明細)を計算
        /// </summary>
        /// <param name="salesMoney">売上金額</param>
        /// <param name="salesSunitCost">原価単価</param>
        /// <param name="slipmentCnt">出荷数</param>
        /// <returns></returns>
        private static Int64 GetGrossProfit(decimal salesMoney, decimal salesSunitCost, decimal slipmentCnt)
        {
            decimal grossProfit = salesMoney - salesSunitCost * slipmentCnt;
            //切り捨て
            return (Int64)grossProfit;
        }

        
        // --- ADD  大矢睦美  2010/05/14 ----------<<<<<
        #endregion

        // --- ADD m.suzuki 2010/03/24 ---------->>>>>
        # region [ＱＲコードサイズDictionary取得]
        /// <summary>
        /// ＱＲコードサイズDictionary取得
        /// </summary>
        /// <param name="table"></param>
        /// <param name="feedCount"></param>
        public static Dictionary<string, float> GetQRCodeSizeDictionary( DataTable table, int feedCount )
        {
            // --- UPD m.suzuki 2010/03/31 ---------->>>>>
            //int maxByteCount = 7 + 46 + (105 * feedCount); //4明細:473, 6明細:683
            int maxByteCount = 7 + 47 + (105 * feedCount); //4明細:474, 6明細:684
            // --- UPD m.suzuki 2010/03/31 ----------<<<<<

            Dictionary<string, float> dic = new Dictionary<string, float>();
            dic.Add( ct_QRCode, UoeQRDataCreateMediator.GetQRCodeSizeRate( (string)table.Rows[0][ct_QRCodeSource], maxByteCount ) );

            return dic;
        }
        # endregion
        // --- ADD m.suzuki 2010/03/24 ----------<<<<<

        // --- ADD  2011/02/16 ---------->>>>>
        # region [縦倍角項目標準項目設定]
        /// <summary>
        /// 縦倍角項目標準項目設定
        /// </summary>
        /// <param name="row"></param>
        /// <param name="columnVisibleTypeDic"></param>
        /// <param name="target1"></param>
        /// <param name="target2"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 縦倍角項目標準項目設定</br>
        /// <br>Programmer : 徐嘉</br>
        /// <br>Date       : 2011/02/16</br>
        /// </remarks>
        protected static void SettingKmk(DataRow row, Dictionary<string, string> columnVisibleTypeDic, string target1, string target2)
        {
            if (columnVisibleTypeDic.ContainsKey(target1))
            {
                row[target2] = DBNull.Value;
            }
            else if (columnVisibleTypeDic.ContainsKey(target2))
            {
                row[target1] = DBNull.Value;
            }
            else
            {
                row[target1] = DBNull.Value;
                row[target2] = DBNull.Value;
            }    
        }
        #endregion
        // --- ADD  2011/02/16 ----------<<<<<

        // 2011/05/27 Add >>>
        # region [文字列バイト数取得]
        /// <summary>
        /// 文字列　バイト数指定切り抜き
        /// </summary>
        /// <param name="orgString">元の文字列</param>
        /// <param name="byteCount">バイト数</param>
        /// <returns>指定バイト数で切り抜いた文字列</returns>
        protected static string SubStringOfByte(string orgString, int byteCount)
        {
            if (byteCount <= 0)
            {
                return string.Empty;
            }

            Encoding encoding = Encoding.GetEncoding("Shift_JIS");

            string resultString = string.Empty;

            // あらかじめ「文字数」を指定して切り抜いておく
            // (この段階でbyte数は<文字数>～2*<文字数>の間になる)
            orgString = orgString.PadRight(byteCount).Substring(0, byteCount);

            int count;

            for (int i = orgString.Length; i >= 0; i--)
            {
                // 「文字数」を減らす
                resultString = orgString.Substring(0, i);

                // バイト数を取得して判定
                count = encoding.GetByteCount(resultString);
                if (count <= byteCount) break;
            }

            // 終端の空白は削除
            return resultString;

        }
        #endregion
        // 2011/05/27 Add <<<
    }

    // --- ADD m.suzuki 2010/03/24 ---------->>>>>
    # region [ＱＲデータ生成仲介クラス]
    /// <summary>
    /// ＱＲデータ生成仲介クラス
    /// </summary>
    internal class UoeQRDataCreateMediator : QRDataCreateMediator
    {
        /// <summary>
        /// 生成処理
        /// </summary>
        /// <param name="enterpriseCode"></param>
        /// <param name="paraWork"></param>
        /// <param name="slipWork"></param>
        /// <param name="detailWorkList"></param>
        /// <param name="csvData"></param>
        /// <returns></returns>
        public static void CreateData( string enterpriseCode, FrePSalesSlipWork slipWork, List<FrePSalesDetailWork> detailWorkList, UoeSales uoeSales, out string csvData, out string qrData )
        {
            StringBuilder data = new StringBuilder();

            //-------------------------------------------------------
            // ヘッダ
            //-------------------------------------------------------

            // ＰＭユーザーコード
            data.Append( string.Format( "\"{0}\"", GetUserCode( enterpriseCode ) ) );

            // 業務区分(1:ＰＭ)
            AppendTo( ref data, 1 );

            // 伝票区分(0:売上,1:返品)
            int countSign;
            if ( slipWork.SALESSLIPRF_SALESSLIPCDRF == 0 )
            {
                AppendTo( ref data, 0 ); // 売上
                countSign = 1;
            }
            else
            {
                AppendTo( ref data, 1 ); // 返品
                countSign = -1;
            }

            // --- UPD m.suzuki 2010/03/31 ---------->>>>>
            //// 伝票番号(下8桁)
            //AppendTo( ref data, ToInt( GetRight( slipWork.SALESSLIPRF_SALESSLIPNUMRF, 8 ) ) );
            // 伝票番号(9桁)
            AppendTo( ref data, ToInt( GetRight( slipWork.SALESSLIPRF_SALESSLIPNUMRF, 9 ) ) );
            // --- UPD m.suzuki 2010/03/31 ----------<<<<<

            if ( detailWorkList.Count > 0 )
            {
                // 車種メーカーコード
                AppendTo( ref data, detailWorkList[0].ACCEPTODRCARRF_MAKERCODERF );
                // 車種名(半角)
                AppendTo( ref data, SubStringOfByte( detailWorkList[0].ACCEPTODRCARRF_MODELHALFNAMERF, 20 ) );
            }
            else
            {
                // 車種メーカーコード
                AppendTo( ref data, 0 );
                // 車種名(半角)
                AppendTo( ref data, string.Empty );
            }

            //-------------------------------------------------------
            // 明細
            //-------------------------------------------------------
            for ( int index = 0; (index < detailWorkList.Count) && (index < 6); index++ )
            {
                // 売上明細
                FrePSalesDetailWork detailWork = detailWorkList[index];

                // 売上明細に対応する印刷用UOE明細
                PrtSalesDetail prtSalesDetail = null;
                if ( uoeSales.uoeSalesDetailList.Count > index )
                {
                    prtSalesDetail = uoeSales.uoeSalesDetailList[index].prtSalesDetail;
                }
                

                // 取込区分
                switch ( detailWork.SALESDETAILRF_SALESSLIPCDDTLRF )
                {
                    default:
                        // 通常は0:取込可
                        AppendTo( ref data, 0 );
                        break;
                    case 2:
                        // 2:行値引/商品値引⇒取込区分を"1:不可"とする
                        AppendTo( ref data, 1 );
                        break;
                    case 3:
                        // 3:注釈⇒除外して次明細へ
                        continue;
                }

                // 品番
                AppendTo( ref data, SubStringOfByte( detailWork.SALESDETAILRF_PRTGOODSNORF, 24 ) );

                // 品名
                if ( detailWork.SALESDETAILRF_GOODSNAMEKANARF.Trim() != string.Empty )
                {
                    // 品名カナ（半角のみ）
                    AppendTo( ref data, SubStringOfByte( detailWork.SALESDETAILRF_GOODSNAMEKANARF, 40 ) );
                }
                else
                {
                    // 品名（全角含む）
                    AppendTo( ref data, SubStringOfByte( detailWork.SALESDETAILRF_GOODSNAMERF, 40 ) );
                }

                // メーカーコード
                AppendTo( ref data, detailWork.SALESDETAILRF_PRTMAKERCODERF );

                // ＢＬコード
                if ( detailWork.SALESDETAILRF_SALESSLIPCDDTLRF == 2 && detailWork.SALESDETAILRF_SHIPMENTCNTRF == 0 )
                {
                    // 行値引ならばPM7同様にBLｺｰﾄﾞ=-1をセットする
                    AppendTo( ref data, -1 );
                }
                else
                {
                    // BLｺｰﾄﾞをセット
                    AppendTo( ref data, detailWork.SALESDETAILRF_PRTBLGOODSCODERF );
                }

                // 出荷数(小数点以下:四捨五入)
                if ( prtSalesDetail != null )
                {
                    // 印刷用出荷数をセット
                    AppendTo( ref data, Round( prtSalesDetail.prtShipmentCnt ) * countSign );
                }
                else
                {
                    AppendTo( ref data, 0 );
                }

                // 単価(小数点以下:四捨五入)
                AppendTo( ref data, Round( detailWork.SALESDETAILRF_SALESUNPRCTAXEXCFLRF ) );

                // 定価(売上データセット仕様上はまるめ不要だが、四捨五入する)
                AppendTo( ref data, Round( detailWork.SALESDETAILRF_LISTPRICETAXEXCFLRF ) );
            }

            // CSVデータ生成
            csvData = data.ToString();

            // ＱＲコード用データ文字列に変換して返却
            qrData = QRDataCreator.CreateData( csvData );
        }
        /// <summary>
        /// 四捨五入処理
        /// </summary>
        /// <param name="orgValue"></param>
        /// <returns></returns>
        private static int Round( double orgValue )
        {
            Int64 resultValue;

            // 端数処理（1:切捨 2:四捨五入 3:切上）
            FractionCalculate.FracCalcMoney( (double)orgValue, 1.0f, 2, out resultValue );

            return (int)resultValue;
        }
    }
    # endregion
    // --- ADD m.suzuki 2010/03/24 ----------<<<<<
    // --- ADD  大矢睦美  2010/05/14 ---------->>>>>
    #region[粗利率計算処理クラス]
    /// <summary>
    /// 粗利率を計算
    /// </summary>
    internal class GrossProfitCalculator
    {
        private SalesPriceCalculate _salesPriceCalculate;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public GrossProfitCalculator()
        {
            _salesPriceCalculate = new SalesPriceCalculate();
        }

        /// <summary>
        /// 粗利率算出処理
        /// </summary>
        /// <param name="salesMoney">売上金額</param>
        /// <param name="cost">原価金額</param>
        /// <returns></returns>
        public double CalcGrossProfitRate(long salesMoney, long cost)
        {
            double retRate = 0;
            if (salesMoney != 0)
            {
                this.GetRate((salesMoney - cost), salesMoney, out retRate); // 小数第３位を四捨五入固定
            }
            return retRate;
        }

        /// <summary>
        /// 率算定処理
        /// </summary>
        /// <param name="numerator">数値(分子)</param>
        /// <param name="denominator">数値(分母)</param>
        /// <param name="rate">率</param>
        public void GetRate(double numerator, double denominator, out double rate)
        {
            rate = this._salesPriceCalculate.CalculateMarginRate(numerator, denominator);
        }
    }
    #endregion
    // --- ADD  大矢睦美  2010/05/14 ----------<<<<<1
}
